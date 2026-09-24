Public Class FrmUB102Payoff
Friend WrkListNo As Integer
Friend WrkUBType As String

Dim myUTTYPE As UTTYPE.myData
Dim myUTCUST As UTCUST.myData
Dim myUTCUSTAS As UTCUSTAS.myData
Dim myUTCUSTRT As UTCUSTRT.myData
Dim myTXINV As TXINV.myData
Dim DsUTCUST As DataSet = New DataSet
Dim myTXPROF As TXPROF.myData
Dim myUTCNTL As UTCNTL.myData
Dim myCashInt As CASHINT.MyData

'TXPROF
Dim ProfPrPerd As Integer
Dim ProfTxDt(3) As Date

Dim WrkTaxType As String
Dim WrkInterestDate As Date
Dim WrkTaxTotal As Double
Dim WrkNoAddlBond As Boolean
'Assessment Work Fields
Dim WrkOrigAssmnt As Decimal
Dim WrkBillAmt As Decimal
Dim WrkBond As Decimal
Dim WrkBillsLeft As Integer
Dim WrkBillNo As Integer
Dim WrkAssmntLeft As Decimal
Dim WrkDeferAmt As Decimal
Dim WrkAssmntAdjust As Decimal
Dim WrkCaveat As Decimal
'Deliquent work fields
Dim WrkDelqInterest As Decimal
Dim WrkDelqFee As Decimal
Dim WrkDelqLien As Decimal
Dim WrkDelqBond As Decimal
Dim WrkDelqPrincipal As Decimal
Dim WrkPayments As Decimal
'Debug
Dim StrDebug As String
Private Sub FrmUB102Payoff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Dim AddrLine As String()

	myUTTYPE = New UTTYPE.myData(myDBConnect)
	myUTCUST = New UTCUST.myData(myDBConnect)
	myUTCUSTAS = New UTCUSTAS.myData(myDBConnect)
	myUTCUSTRT = New UTCUSTRT.myData(myDBConnect)
  myTXINV = New TXINV.myData(myDBConnect)
	myTXPROF = New TXPROF.myData(myDBConnect)
	myUTCNTL = New UTCNTL.myData(myDBConnect)
  myCashInt = New CASHINT.MyData(myDBConnect)

  With MyFrmUB102
    .TBarSave.Enabled = False
    .TBarComments.Enabled = False
  End With

  WrkCaveat = 0
  WrkNoAddlBond = False
	myUTCNTL.GetOneRecordP(1)
	If Not myUTCNTL.RecordNotFound Then
		WrkCaveat = Trim(myUTCNTL._UBCAV)
		If myUTCNTL._UASDV = "N" Then
			WrkNoAddlBond = True
		End If
	End If

  LblListNo.Text = WrkListNo
  With MyFrmUB102C
    AddrLine = MyUtils.SetAddrLine(.TxtName.Text, .TxtSname.Text, .TxtAdd1.Text, .TxtAdd2.Text, _
    .TxtCity.Text, .TxtState.Text, 0, 0, .TxtZip.Text)
  End With
  LblAddr1.Text = AddrLine(0)
  LblAddr2.Text = AddrLine(1)
  LblAddr3.Text = AddrLine(2)
  LblAddr4.Text = AddrLine(3)
  LblAddr5.Text = AddrLine(4)
  LblLoc.Text = Trim(MyFrmUB102C.TxtLocNo.Text) & " " & Trim(MyFrmUB102C.TxtLoc.Text)
  WrkOrigAssmnt = MyUtils.CnvSng(MyFrmUB102AS.LblOrigAssmnt.Text)
  LblOrigAssmnt.Text = MyFrmUB102AS.LblOrigAssmnt.Text
  LblAssmntAdj.Text = MyUtils.FmtCurrency(MyUtils.CnvSng(MyFrmUB102AS.TxtAssmntAdj.Text))
  WrkDeferAmt = MyUtils.CnvSng(MyFrmUB102AS.TxtDeferAmt.Text)
  LblDeferAmt.Text = MyUtils.FmtCurrency(MyUtils.CnvSng(MyFrmUB102AS.TxtDeferAmt.Text))
  WrkAssmntLeft = MyUtils.CnvSng(MyFrmUB102AS.LblAssmntLeft.Text)
  LblAssmntLeft.Text = MyUtils.FmtCurrency(MyUtils.CnvSng(MyFrmUB102AS.LblAssmntLeft.Text))
  If MyUtils.CnvSng(LblAssmntLeft.Text) > 0 Or MyUtils.CnvSng(LblAssmntLeft.Text) = 0 _
   And MyUtils.CnvSng(LblDelqBal.Text) > 0 And MyUtils.CnvSng(LblLiens.Text) = 0 Then
    LblCaveat.Text = MyUtils.FmtCurrency(MyUtils.CnvSng(WrkCaveat))
  Else
    LblCaveat.Text = MyUtils.FmtCurrency(0)
  End If
  WrkBillNo = MyUtils.CnvSng(MyFrmUB102AS.TxtPrevBills.Text)
  Call FormatGrid()

End Sub
Public Sub FormatGrid()
 Call ShowGrid()

 With C1DataGrdPrev
   .Rebind(True)
   .FetchRowStyles = True
   .Columns(0).Caption = "Status"
   .Splits(0).DisplayColumns(0).Width = 45
   .Columns(1).Caption = "Year"
   .Splits(0).DisplayColumns(1).Width = 40
   .Columns(2).Caption = "Bill Amt"
   .Splits(0).DisplayColumns(2).Width = 70
   .Columns(3).Caption = "Balance"
   .Splits(0).DisplayColumns(3).Width = 70
   .Columns(4).Caption = "Interest"
   .Splits(0).DisplayColumns(4).Width = 60
   .Columns(5).Caption = "Fee"
   .Splits(0).DisplayColumns(5).Width = 60
   .Columns(6).Caption = "Bond Due"
   .Splits(0).DisplayColumns(6).Width = 70
   .Columns(7).Caption = "Lien"
   .Splits(0).DisplayColumns(7).Width = 50
 End With

End Sub
Public Sub ShowGrid()
  Windows.Forms.Cursor.Current = Cursors.WaitCursor

  Dim dsPrev As DataSet = New DataSet
  Dim dsinv As DataSet = New DataSet
  Dim dr As DataRow
  Dim myTable As New DataTable
  Dim myTable2 As New DataTable
  Dim I As Integer
  Dim WrkBillAmt As Decimal
  Dim WrkPurgedTax As Decimal
  Dim WrkBondPayoff As Decimal
  Dim WrkYear As Integer
  Dim WrkDist As Integer
  Dim WrkPhaseA As String
  Dim WrkInterest As Decimal
  Dim WrkFee As Decimal
  Dim WrkLien As Decimal
  Dim WrkInActive As Boolean

  With myTable
    .TableName = "mytable"
    .Columns.Add("Status", Type.GetType("System.String"))
    .Columns.Add("Year", Type.GetType("System.Int16"))
    .Columns.Add("BillAmt", Type.GetType("System.Decimal"))
    .Columns.Add("Balance", Type.GetType("System.Decimal"))
    .Columns.Add("Interest", Type.GetType("System.Decimal"))
    .Columns.Add("Fee", Type.GetType("System.Decimal"))
    .Columns.Add("BondDue", Type.GetType("System.Decimal"))
    .Columns.Add("Lien", Type.GetType("System.Decimal"))
  End With
  dsPrev.Tables.Add(myTable)

  With MyFrmUB102C
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    If .TxtPhase.Text = "0" Then
      WrkPhaseA = ""
    Else
      WrkPhaseA = .TxtPhase.Text
    End If
  End With

  myUTTYPE.GetOneRecordP(WrkUBType)
  If myUTTYPE.RecordNotFound Then Exit Sub

  WrkTaxType = myUTTYPE._TYTXTP

  WrkBillAmt = 0
  WrkPayments = 0
  WrkDelqPrincipal = 0
  WrkDelqInterest = 0
  WrkDelqFee = 0
  WrkDelqBond = 0
  WrkDelqLien = 0
  WrkInterestDate = DtPckInterest.Value

  dsinv = myTXINV.GetAllListNoType(WrkListNo, WrkTaxType)
  If dsinv.Tables(0).Rows.Count = 0 Then GoTo CheckPurged

  For I = 0 To dsinv.Tables(0).Rows.Count - 1
    With dsinv.Tables(0).Rows(I)
      dsPrev.Tables(0).NewRow()
      dr = dsPrev.Tables(0).NewRow
      If .Item("icode") = "I" Then
        dr("Status") = "Inactive"
        WrkInActive = True
      Else
        dr("Status") = "Billed"
        WrkInActive = False
      End If
      dr("Year") = .Item("year")
      WrkYear = .Item("year")
      If .Item("ccno") > 0 Then
        dr("BillAmt") = .Item("ccetax")
        If Not WrkInActive Then
          WrkBillAmt = WrkBillAmt + .Item("ccetax")
        End If
      Else
        dr("BillAmt") = .Item("taxt")
        If Not WrkInActive Then
          WrkBillAmt = WrkBillAmt + .Item("taxt")
        End If
      End If
      dr("Balance") = .Item("bald")
      If Not WrkInActive Then
        WrkDelqPrincipal = WrkDelqPrincipal + .Item("bald")
      End If
      If .Item("bald") <> 0 Then
        dr("BondDue") = .Item("bond") - .Item("bondp")
      Else
        dr("BondDue") = 0
      End If
      If Not WrkInActive Then
        WrkDelqBond = WrkDelqBond + dr("bonddue")
      End If
      If WrkDelqPrincipal > 0 Then
        CalcInterest(WrkYear, WrkInterest, WrkFee, WrkLien)
        dr.Item("interest") = WrkInterest
        dr.Item("fee") = WrkFee
        dr.Item("lien") = WrkLien
        If Not WrkInActive Then
          WrkDelqInterest = WrkDelqInterest + WrkInterest
          WrkDelqFee = WrkDelqFee + WrkFee
          WrkDelqLien = WrkDelqLien + WrkLien
        End If
      Else
        dr.Item("interest") = 0
        dr.Item("fee") = 0
        dr.Item("lien") = 0
      End If
      dsPrev.Tables(0).Rows.Add(dr)
    End With
  Next

  If Not WrkInActive Then
    WrkPayments = WrkBillAmt - WrkDelqPrincipal
  End If
CheckPurged:
  'Check for past purged bills and create entry
  WrkPurgedTax = WrkOrigAssmnt - WrkAssmntLeft - WrkBillAmt
  WrkPurgedTax = MyUtils.Round(WrkPurgedTax, 2)
  If WrkPurgedTax > 0 Then
    dsPrev.Tables(0).NewRow()
    dr = dsPrev.Tables(0).NewRow
    dr("Status") = "Purged"
    dr("BillAmt") = Format(WrkPurgedTax, "fixed")
    dsPrev.Tables(0).Rows.Add(dr)
    WrkPayments = WrkPayments + WrkPurgedTax
  End If

  If TxtYear.Text <> "" Then
    WrkYear = MyUtils.CnvSng(TxtYear.Text)
  End If

  myTXPROF.GetOneRecordP(WrkTaxType, WrkYear, WrkPhaseA, WrkDist)
  'If not found, use generic profile instead
  If myTXPROF.RecordNotFound Then
    myTXPROF.GetOneRecordP(WrkTaxType, WrkYear, String.Empty, 0)
  End If
  If Not myTXPROF.RecordNotFound Then
    With myTXPROF
      ProfPrPerd = ._PRPERD
      ProfTxDt(0) = MyUtils.GetDBDateMDY(._PRDUE1)
      ProfTxDt(1) = MyUtils.GetDBDateMDY(._PRDUE2)
      ProfTxDt(2) = MyUtils.GetDBDateMDY(._PRDUE3)
      ProfTxDt(3) = MyUtils.GetDBDateMDY(._PRDUE4)
    End With
  End If

  LblPayments.Text = MyUtils.FmtCurrency(WrkPayments)
  LblDelqBal.Text = MyUtils.FmtCurrency(WrkDelqPrincipal)
  LblDelqInt.Text = MyUtils.FmtCurrency(WrkDelqInterest)
  LblDelqFee.Text = MyUtils.FmtCurrency(WrkDelqFee)
  LblDelqBond.Text = MyUtils.FmtCurrency(WrkDelqBond)
  LblLiens.Text = MyUtils.FmtCurrency(WrkDelqLien)
  CalcAssmnt()
  If WrkYear > 0 Then
    If Not WrkNoAddlBond Then
      WrkBondPayoff = CalcBond()
    End If
    If TxtYear.Text = "" Then
      TxtYear.Text = WrkYear
    End If
  End If
  LblBond.Text = MyUtils.FmtCurrency(WrkBondPayoff)
  If MyUtils.CnvSng(LblAssmntLeft.Text) = 0 And WrkDelqPrincipal > 0 And WrkDelqLien = 0 Then
    LblCaveat.Text = MyUtils.FmtCurrency(MyUtils.CnvSng(WrkCaveat))
  End If
  LblAmountDue.Text = MyUtils.FmtCurrency(WrkDelqPrincipal + WrkDelqInterest + WrkDelqLien + _
    WrkDelqBond + WrkAssmntLeft + WrkDeferAmt + WrkBondPayoff + MyUtils.CnvSng(LblCaveat.Text))

  C1DataGrdPrev.DataSource = dsPrev.Tables(0)
  C1DataGrdPrev.Refresh()
  Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub FrmUB102Payoff_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB102.SbpScreen.Text = "UB102Payoff"
  MyUtils.CenterForm(Me.ParentForm, Me)
  With MyFrmUB102
    .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
    .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
  End With
End Sub
Private Sub FrmUB102Payoff_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmUB102.TBarSave.Enabled = True
  MyFrmUB102.TBarComments.Enabled = True
  MyFrmUB102AS.Show()
  'Memory Cleanup
  myUTTYPE = Nothing
  myUTCUST = Nothing
  myUTCUSTAS = Nothing
  myUTCUSTRT = Nothing
  myTXINV = Nothing
  MyFrmUB102Payoff = Nothing
End Sub
  Private Sub CalcAssmnt()
    Dim MyUBCalcBill2 As UBCalcBill.Amort

    MyUBCalcBill2 = New UBCalcBill.Amort(myDBConnect)

    WrkBillAmt = 0
    WrkBond = 0

    If MyUtils.CnvSng(LblOrigAssmnt.Text) = 0 Then Exit Sub

    With MyUBCalcBill2
      .In_OrigBill = MyUtils.CnvSng(LblOrigAssmnt.Text)
      .In_AmtLeft = WrkAssmntLeft
      .In_Balance = WrkDelqPrincipal
      .In_RateType = WrkUBType
      .In_RateCode = MyFrmUB102AS.TxtCode.Text
      .In_NumBills = WrkBillNo
      .In_OverrideBill = MyUtils.CnvSng(MyFrmUB102AS.TxtOverride.Text)
      .In_PctDeferred = MyUtils.CnvSng(MyFrmUB102AS.TxtDeferPct.Text)
      .CalcAmort()
      WrkBillAmt = MyUtils.FmtCurrency(.Out_Bill)
      WrkBond = MyUtils.FmtCurrency(.Out_Bond)
      WrkBillsLeft = .Out_BillsLeft
    End With
  End Sub
  Private Function CalcBond() As Decimal
    Dim WrkBondPayoff As Decimal
    Dim WrkMonths As Integer
    Dim WrkProMonths As Integer
    Dim WrkProfDate As Date
    Dim WrkFactor As Decimal
    Dim WrkDays As Integer

    If WrkAssmntLeft = 0 Then Exit Function

    WrkBondPayoff = 0
    WrkProfDate = ProfTxDt(0)
    WrkProMonths = 12
    If ProfPrPerd > 1 Then
      WrkProMonths = 6
      WrkDays = DateTime.Compare(WrkInterestDate, ProfTxDt(1))
      If WrkDays > 0 Then
        WrkProfDate = ProfTxDt(1)
      End If
    End If
    WrkMonths = DateDiff(DateInterval.Month, WrkProfDate, WrkInterestDate)
    WrkFactor = WrkMonths / WrkProMonths
    WrkBondPayoff = MyUtils.Round(WrkBond * WrkFactor, 2)

    Return WrkBondPayoff

  End Function
Private Sub CalcInterest(ByVal WrkYear As Integer, ByRef OutInt As Decimal, _
	ByRef OutFee As Decimal, ByRef OutLien As Decimal)

	With myCashInt
		.In_IntDate = WrkInterestDate
		.In_ListNo = WrkListNo
		.In_Type = WrkTaxType
		.In_Year = WrkYear
		.CalcInterest()
		OutInt = .Out_Int
		OutFee = .Out_Fee
		OutLien = .Out_Lien
		StrDebug = .Out_Debug
	End With

End Sub

Private Sub BtnRecalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRecalc.Click
  FormatGrid()
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter
  MsgBox(StrDebug)
End Sub
 Private Sub C1DataGrdList_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles C1DataGrdPrev.FetchRowStyle
   If C1DataGrdPrev.Columns("status").CellValue(e.Row) = "Inactive" Then
     e.CellStyle.BackColor = System.Drawing.Color.Pink
   End If
End Sub

Private Sub LnkPayoff_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkPayoff.LinkClicked
  MyFrmUB102Payoff2 = New FrmUB102Payoff2
  MyFrmUB102Payoff2.MdiParent = Me.ParentForm
  MyFrmUB102Payoff2.Show()
  Me.Hide()
End Sub
End Class