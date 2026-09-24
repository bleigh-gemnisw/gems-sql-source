Public Class FrmPO306C

  Dim myPOMAST As POMAST.MyData
  Dim myPOMASTL1 As POMASTL1.MyData
  Dim myAPEHSTL1 As APEHSTL1.MyData
  Friend WrkFscyr As Integer
  Friend WrkPonbr As Integer
  Private Sub FrmPO306E_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    myPOMAST = New POMAST.MyData()
    myPOMAST.MyDBConn = myDBConnect
    myPOMASTL1 = New POMASTL1.MyData()
    myPOMASTL1.MyDBConn = myDBConnect
    myAPEHSTL1 = New APEHSTL1.MyData()
    myAPEHSTL1.MyDBConn = myDBConnect

    LblFscyr.Text = WrkFscyr
    LblPoNbr.Text = WrkPonbr
    MyFrmPO306.TBarSettings.Visible = False
    MyFrmPO306.TBarPrint.Text = "Detail"

    With myPOMAST
      .GetOneRecordP(WrkFscyr, WrkPonbr, 0, 0, 0)
      Select Case Trim(._CMPCD)
        Case "C"
          LblCmpcd.Text = "CLOSED"
        Case "D"
          LblCmpcd.Text = "DELETED"
        Case Else
          LblCmpcd.Text = "OPEN"
      End Select
      If ._RENTD > 0 Then
        LblRentd.Text = MyUtils.GetDBDate(._RENTD)
      Else
        LblRentd.Text = ""
      End If
      LblVndnr.Text = Trim(._VNDNR)
      LblVennm.Text = Trim(._VENNM)
      If ._AMTNT > 0 Then
        LblAmtnt.Text = Format(._AMTNT, "fixed")
      Else
        LblAmtnt.Text = ""
      End If
      If ._AMTGR > 0 Then
        LblAmtgr.Text = Format(._AMTGR, "fixed")
      Else
        LblAmtgr.Text = ""
      End If
      If ._POPEN > 0 Then
        LblPopen.Text = Format(._POPEN, "fixed")
      Else
        LblPopen.Text = ""
      End If
      LblSname.Text = Trim(._SNAME)
      LblSadr1.Text = Trim(._SADR1)
      LblSadr2.Text = Trim(._SADR2)
      LblSadr3.Text = Trim(._SADR3)
      LblSzip.Text = Trim(._SZIP)
      If Trim(._SZIPE) <> "" Then
        LblSzip.Text = LblSzip.Text & "-" & Trim(._SZIPE)
      End If
      LblSadr4.Text = Trim(._SADR4)
      LblRname.Text = Trim(._RNAME)
      LblRadr1.Text = Trim(._RADR1)
      LblRadr2.Text = Trim(._RADR2)
      LblRadr3.Text = Trim(._RADR3)
      LblRadr4.Text = Trim(._RADR4)
      LblRzip.Text = Trim(._RZIP)
      If Trim(._RZIPE) <> "" Then
        LblRzip.Text = LblRzip.Text & "-" & Trim(._RZIPE)
      End If
      If ._FDNBR > 0 Then
        LblAcctNo.Text = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
      Else
        LblAcctNo.Text = ""
      End If
      If ._ORDSP > 0 Then
        LblOrdsp.Text = ._ORDSP
      Else
        LblOrdsp.Text = ""
      End If
      If ._DSCDL > 0 Then
        LblDscdl.Text = Format(._DSCDL, "fixed")
      Else
        LblDscdl.Text = ""
      End If
      If ._FDNBD > 0 Then
        LblAcctDsc.Text = BuildAcct(._FDNBD, ._SFUDD, ._DPNBD, ._OBNBD, ._FNPGD, ._SUBFD)
      Else
        LblAcctDsc.Text = ""
      End If
      If ._ORSHP > 0 Then
        LblOrshp.Text = ._ORSHP
      Else
        LblOrshp.Text = ""
      End If
      If ._SHPDL > 0 Then
        LblShpdl.Text = Format(._SHPDL, "fixed")
      Else
        LblShpdl.Text = ""
      End If
      If ._FDNBS > 0 Then
        LblAcctShp.Text = BuildAcct(._FDNBS, ._SFUNS, ._DPNBS, ._OBNBS, ._FNPGS, ._SUBFS)
      Else
        LblAcctShp.Text = ""
      End If
      LblManual.Visible = False
      If ._MNAYN = "Y" Then
        LblManual.Visible = True
      End If
      LblPOHasDlt.Visible = False
      If ._PODYN = "Y" Then
        LblPOHasDlt.Visible = True
      End If
    End With
    CalcChangedAmount()
    FormatGridPO()
  End Sub
  Private Sub FrmPO306C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmPO306.SbpScreen.Text = "PO306C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub FrmPO306C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmPO306.TBarPrint.Text = "Print PO"
    MyFrmPO306.TBarSettings.Visible = True
    MyFrmPO306B.Show()
  End Sub
  Public Sub FormatGridPO()
    Dim ds As DataSet
    ds = myPOMASTL1.GetViewbyPOL6(WrkFscyr, WrkPonbr, 100)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()
    With C1DataGrdList
      .Rebind(True)
      .Splits(0).DisplayColumns(0).Visible = False
      .Splits(0).DisplayColumns(1).Visible = False
      .Columns(2).Caption = "Seq"
      .Splits(0).DisplayColumns(2).Width = 25
      .Splits(0).DisplayColumns(3).Visible = False
      .Columns(4).Caption = "Catalog Number"
      .Splits(0).DisplayColumns(4).Width = 140
      .Columns(5).Caption = "Description"
      .Splits(0).DisplayColumns(5).Width = 200
      .Splits(0).DisplayColumns(6).Visible = False
      .Splits(0).DisplayColumns(7).Visible = False
      .Columns(8).Caption = "Amount"
      .Columns(8).NumberFormat = "Fixed"
      .Splits(0).DisplayColumns(8).Width = 60
      .Columns(9).Caption = "Fund"
      .Splits(0).DisplayColumns(9).Width = 30
      .Columns(10).Caption = "Sfund"
      .Splits(0).DisplayColumns(10).Width = 35
      .Columns(11).Caption = "Dept"
      .Splits(0).DisplayColumns(11).Width = 30
      .Columns(12).Caption = "Obj"
      .Splits(0).DisplayColumns(12).Width = 30
      .Columns(13).Caption = "Func"
      .Splits(0).DisplayColumns(13).Width = 30
      .Columns(14).Caption = "Sfcn"
      .Splits(0).DisplayColumns(14).Width = 30
    End With
  End Sub
  Public Sub FormatGridAP()
    Dim ds As DataSet
    ds = myAPEHSTL1.GetViewbyPO(WrkFscyr, WrkPonbr)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()
    With C1DataGrdList
      .Rebind(True)
      .Splits(0).DisplayColumns(0).Visible = False
      .Columns(1).Caption = "Check Date"
      .Columns(1).NumberFormat = "##/##/####"
      .Splits(0).DisplayColumns(1).Width = 65
      .Columns(2).Caption = "Invoice Date"
      .Columns(2).NumberFormat = "##/##/####"
      .Splits(0).DisplayColumns(2).Width = 70
      .Columns(3).Caption = "Check No"
      .Splits(0).DisplayColumns(3).Width = 65
      .Columns(4).Caption = "Invoice No"
      .Splits(0).DisplayColumns(4).Width = 75
      .Splits(0).DisplayColumns(5).Visible = False
      .Columns(6).Caption = "Amount"
      .Splits(0).DisplayColumns(6).Width = 65
      .Columns(6).NumberFormat = "Fixed"
      .Columns(7).Caption = "Void?"
      .Splits(0).DisplayColumns(7).Width = 50
    End With
  End Sub
  Private Sub CalcChangedAmount()
    Dim ds As DataSet
    Dim I As Integer
    Dim WrkAmount As Decimal
    LblPOChange.Visible = False
    WrkAmount = 0
    ds = myPOMASTL1.GetAllPONo(WrkFscyr, WrkPonbr, 0)
    For I = 1 To ds.Tables(0).Rows.Count - 1
      WrkAmount = WrkAmount + ds.Tables(0).Rows(I).Item("amtnt")
    Next
    If WrkAmount <> 0 Then
      LblPOChange.Visible = True
      LblPOChange.Text = "PO changed by " & Format(WrkAmount, "fixed")
    End If
  End Sub
  Private Sub RbDetail_Click(sender As Object, e As EventArgs) Handles RbDetail.Click
    FormatGridPO()
  End Sub
  Private Sub RbAP_Click(sender As Object, e As EventArgs) Handles RbAP.Click
    FormatGridAP()
  End Sub
  Public Sub PrintData()
    PrtDtlPay()
  End Sub
End Class