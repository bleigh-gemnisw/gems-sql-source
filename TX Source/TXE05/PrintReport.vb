Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXHSTQ As TXHSTQ.MyData

  'ds used by both TXE051 & TXE053
  Dim ds As DataSet = New DataSet
  'ds2 used by TXE052
  Dim ds2 As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim dr2 As Data.DataRow
  'General
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkRefunds As Boolean
  Dim WrkRefundTotal As Decimal
  Dim WrkRefundTotalOther As Decimal
  Dim WrkAdjust As Boolean
  Dim WrkShowAdjust As Boolean
  Dim WrkAdjustTotal As Decimal
  Dim WrkAdjustTotalOther As Decimal
  Dim SaveYear As Integer
  Dim SaveType As String
  Dim WrkAnd As String
  Dim WrkOr As String
  'TXE051 & TXE053
  Dim WrkREPaid As Decimal
  Dim WrkPPPaid As Decimal
  Dim WrkMVPaid As Decimal
  Dim WrkSUPaid As Decimal
  Dim WrkProPaid As Decimal
  Dim WrkSUInt As Decimal
  Dim WrkOtherInt As Decimal
  Dim WrkProInt As Decimal
  Dim WrkLien As Decimal
  Dim WrkProLien As Decimal
  Dim WrkFee As Decimal
  Dim WrkProFee As Decimal
  Dim WrkREPaidSusp As Decimal
  Dim WrkPPPaidSusp As Decimal
  Dim WrkMVPaidSusp As Decimal
  Dim WrkSUPaidSusp As Decimal
  Dim WrkSUIntSusp As Decimal 'Interest
  Dim WrkOtherIntSusp As Decimal 'Interest
  Dim WrkLienSusp As Decimal
  Dim WrkFeeSusp As Decimal 'Penalty/Fees
  'TXE052
  Dim Wrk2Paid As Decimal
  Dim Wrk2Int As Decimal
  Dim Wrk2Lien As Decimal
  Dim Wrk2Fee As Decimal
  Dim Wrk2Bond As Decimal
  Dim Wrk2PaidSusp As Decimal
  Dim Wrk2IntSusp As Decimal 'Interest
  Dim Wrk2LienSusp As Decimal
  Dim Wrk2FeeSusp As Decimal
  Dim Wrk2BondSusp As Decimal
  Dim WrkGrandTotal As Decimal
  Public Sub PrtReport()

    myTXHSTQ = New TXHSTQ.MyData(myDBConnect)

    If ds.Tables.Count = 0 Then
      BuildDS()
      BuildDS2()
    Else
      ds.Clear()
      ds2.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.wrkds2 = ds2
    MyCrViewer.WrkRefunds = WrkRefunds
    MyCrViewer.WrkRefundTotal = WrkRefundTotal
    MyCrViewer.WrkRefundTotalOther = WrkRefundTotalOther
    MyCrViewer.WrkAdjust = WrkAdjust
    MyCrViewer.WrkAdjustTotal = WrkAdjustTotal
    MyCrViewer.WrkAdjustTotalOther = WrkAdjustTotalOther
    MyCrViewer.WrkShowAdjust = WrkShowAdjust
    MyCrViewer.WrkGrandTotal = WrkGrandTotal
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Suspense", Type.GetType("System.Boolean"))
      .Columns.Add("Prorate", Type.GetType("System.String"))
      .Columns.Add("REPaid", Type.GetType("System.Decimal"))
      .Columns.Add("PPPaid", Type.GetType("System.Decimal"))
      .Columns.Add("MVPaid", Type.GetType("System.Decimal"))
      .Columns.Add("SUPaid", Type.GetType("System.Decimal"))
      .Columns.Add("SUInt", Type.GetType("System.Decimal"))
      .Columns.Add("OtherInt", Type.GetType("System.Decimal"))
      .Columns.Add("TotalInt", Type.GetType("System.Decimal"))
      .Columns.Add("Liens", Type.GetType("System.Decimal"))
      .Columns.Add("Fees", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub BuildDS2()
    Dim myTable2 As New DataTable
    With myTable2
      .TableName = "mytable2"
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Suspense", Type.GetType("System.Boolean"))
      .Columns.Add("Paid", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Liens", Type.GetType("System.Decimal"))
      .Columns.Add("Fees", Type.GetType("System.Decimal"))
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
    End With
    ds2.Tables.Add(myTable2)

  End Sub
  Private Sub GetDetail()
    Dim WrkFrom As Integer
    Dim WrkTo As Integer
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkType As String
    Dim Counter As Integer

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    Counter = 0
    SaveYear = 0
    SaveType = ""
    ClearTotals()
    ClearTotals2()
    WrkRefundTotal = 0
    WrkRefundTotalOther = 0
    WrkAdjustTotal = 0
    WrkAdjustTotalOther = 0
    WrkGrandTotal = 0

    With MyFrmTXE05B
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkDistAll = False
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkRefunds = False
      If .ChkRefunds.Checked Then
        WrkRefunds = True
      End If
      WrkAdjust = False
      If .ChkAdjust.Checked Then
        WrkAdjust = True
      End If
      WrkShowAdjust = False
      If .ChkShowAdjust.Checked Then
        WrkShowAdjust = True
      End If
    End With

    WrkSort = "YEAR desc, TYPE"
    WrkQry = "RCODE <> 'I'" & WrkAnd & "RCODE <>'V'" & WrkAnd &
  "PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo
    If Not WrkDistAll Then
      WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
    End If
    MyTypes = MyFrmTXE05B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    myTXHSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXHSTQ.ReadQry()
    If Not myTXHSTQ.IsEOF Then
      With myTXHSTQ
        Counter = Counter + 1
        If SaveYear > 0 And SaveYear <> ._YEAR Then
          WriteDetail()
          ClearTotals()
        End If
        'TXE052
        If SaveYear > 0 Then
          If SaveYear <> ._YEAR Or SaveType <> ._TYPE Then
            WriteDetail2()
            ClearTotals2()
          End If
        End If
        SaveYear = ._YEAR
        SaveType = ._TYPE
        WrkType = ._TYPE
        'Filter Refunds
        If ._ADJCD = "R" Then
          If WrkRefunds Then
            Select Case WrkType
              Case "P", "M", "R", "S", "X"
                WrkRefundTotal = WrkRefundTotal + ._PAMT + ._IAMT +
     ._LAMT + ._PCAMT
              Case Else
                WrkRefundTotalOther = WrkRefundTotalOther + ._PAMT + ._IAMT +
     ._LAMT + ._PCAMT
            End Select
          Else
            GoTo NextRec
          End If
        End If

        'Filter Adjustments
        If ._ADJCD = "A" Then
          If WrkAdjust Then
            Select Case WrkType
              Case "P", "M", "R", "S", "X"
                WrkAdjustTotal = WrkAdjustTotal + ._PAMT + ._IAMT +
     ._LAMT + ._PCAMT
              Case Else
                WrkAdjustTotalOther = WrkAdjustTotalOther + ._PAMT + ._IAMT +
     ._LAMT + ._PCAMT
            End Select
          Else
            GoTo NextRec
          End If
        End If

        If ._RCODE <> "S" Then
          WrkType = ._TYPE
          Select Case WrkType
            Case "M"
              WrkMVPaid = WrkMVPaid + ._PAMT
              WrkOtherInt = WrkOtherInt + ._IAMT
              WrkLien = WrkLien + ._LAMT
              WrkFee = WrkFee + ._PCAMT
            Case "P"
              WrkPPPaid = WrkPPPaid + ._PAMT
              WrkOtherInt = WrkOtherInt + ._IAMT
              WrkLien = WrkLien + ._LAMT
              WrkFee = WrkFee + ._PCAMT
            Case "R"
              WrkREPaid = WrkREPaid + ._PAMT
              WrkOtherInt = WrkOtherInt + ._IAMT
              WrkLien = WrkLien + ._LAMT
              WrkFee = WrkFee + ._PCAMT
            Case "S"
              WrkSUPaid = WrkSUPaid + ._PAMT
              WrkSUInt = WrkSUInt + ._IAMT
              WrkLien = WrkLien + ._LAMT
              WrkFee = WrkFee + ._PCAMT
            Case "X"
              WrkProPaid = WrkProPaid + ._PAMT
              WrkProInt = WrkProInt + ._IAMT
              WrkProLien = WrkProLien + ._LAMT
              WrkProFee = WrkProFee + ._PCAMT
            Case Else
              Wrk2Paid = Wrk2Paid + ._PAMT
              Wrk2Int = Wrk2Int + ._IAMT
              Wrk2Lien = Wrk2Lien + ._LAMT
              If ._PENCD = "BI" Then
                Wrk2Bond = Wrk2Bond + ._PCAMT
              Else
                Wrk2Fee = Wrk2Fee + ._PCAMT
              End If
          End Select
        Else
          WrkType = ._TYPE
          Select Case WrkType
            Case "M"
              WrkMVPaidSusp = WrkMVPaidSusp + ._PAMT
              WrkOtherIntSusp = WrkOtherIntSusp + ._IAMT
              WrkLienSusp = WrkLienSusp + ._LAMT
              WrkFeeSusp = WrkFeeSusp + ._PCAMT
            Case "P"
              WrkPPPaidSusp = WrkPPPaidSusp + ._PAMT
              WrkOtherIntSusp = WrkOtherIntSusp + ._IAMT
              WrkLienSusp = WrkLienSusp + ._LAMT
              WrkFeeSusp = WrkFeeSusp + ._PCAMT
            Case "R"
              WrkREPaidSusp = WrkREPaidSusp + ._PAMT
              WrkOtherIntSusp = WrkOtherIntSusp + ._IAMT
              WrkLienSusp = WrkLienSusp + ._LAMT
              WrkFeeSusp = WrkFeeSusp + ._PCAMT
            Case "S"
              WrkSUPaidSusp = WrkSUPaidSusp + ._PAMT
              WrkSUIntSusp = WrkSUIntSusp + ._IAMT
              WrkLienSusp = WrkLienSusp + ._LAMT
              WrkFeeSusp = WrkFeeSusp + ._PCAMT
            Case Else
              Wrk2PaidSusp = Wrk2PaidSusp + ._PAMT
              Wrk2IntSusp = Wrk2IntSusp + ._IAMT
              Wrk2LienSusp = Wrk2LienSusp + ._LAMT
              If ._PENCD = "BI" Then
                Wrk2BondSusp = Wrk2BondSusp + ._PCAMT
              Else
                Wrk2FeeSusp = Wrk2FeeSusp + ._PCAMT
              End If
          End Select
        End If
      End With

NextRec:
      With myFrmProgress
        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .LblMsg.Text = "Records processed: " & Counter
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
      GoTo ReadNext
    End If

    'TXE051 & TXE053
    WriteDetail()

    'TXE052
    WriteDetail2()

    myFrmProgress.Close()
    myTXHSTQ.CloseFile()

  End Sub
  Private Sub WriteDetail()
    'TXE051  
    Dim WrkTotal As Decimal

    'Regular
    WrkTotal = WrkREPaid + WrkPPPaid + WrkMVPaid + WrkSUPaid + WrkSUInt + WrkOtherInt + WrkLien + WrkFee
    If WrkREPaid <> 0 Or WrkPPPaid <> 0 Or WrkMVPaid <> 0 Or WrkSUPaid <> 0 Or
  WrkSUInt <> 0 Or WrkOtherInt <> 0 Or WrkLien <> 0 Or WrkFee <> 0 Then
      WrkGrandTotal = WrkGrandTotal + WrkTotal
      dr = ds.Tables(0).NewRow
      dr.Item("year") = SaveYear
      dr.Item("suspense") = False
      dr.Item("prorate") = ""
      dr.Item("repaid") = WrkREPaid
      dr.Item("pppaid") = WrkPPPaid
      dr.Item("mvpaid") = WrkMVPaid
      dr.Item("supaid") = WrkSUPaid
      dr.Item("suint") = WrkSUInt
      dr.Item("otherint") = WrkOtherInt
      dr.Item("totalint") = WrkSUInt + WrkOtherInt
      dr.Item("liens") = WrkLien
      dr.Item("Fees") = WrkFee
      ds.Tables(0).Rows.Add(dr)
    End If

    'Prorate
    WrkTotal = WrkProPaid + WrkProInt + WrkProLien + WrkProFee
    If WrkProPaid <> 0 Or WrkProInt <> 0 Or WrkProLien <> 0 Or WrkProFee <> 0 Then
      WrkGrandTotal = WrkGrandTotal + WrkTotal
      dr = ds.Tables(0).NewRow
      dr.Item("year") = SaveYear
      dr.Item("suspense") = False
      dr.Item("prorate") = "*"
      dr.Item("repaid") = WrkProPaid
      dr.Item("pppaid") = 0
      dr.Item("mvpaid") = 0
      dr.Item("supaid") = 0
      dr.Item("suint") = 0
      dr.Item("otherint") = WrkProInt
      dr.Item("totalint") = WrkProInt
      dr.Item("liens") = WrkProLien
      dr.Item("Fees") = WrkProFee
      ds.Tables(0).Rows.Add(dr)
    End If

    'Suspense
    WrkTotal = WrkREPaidSusp + WrkPPPaidSusp + WrkMVPaidSusp + WrkSUPaidSusp +
  WrkSUIntSusp + WrkOtherIntSusp + WrkLienSusp + WrkFeeSusp
    If WrkREPaidSusp <> 0 Or WrkPPPaidSusp <> 0 Or WrkMVPaidSusp <> 0 Or WrkSUPaidSusp <> 0 Or
  WrkSUIntSusp <> 0 Or WrkOtherIntSusp <> 0 Or WrkLienSusp <> 0 Or WrkFeeSusp <> 0 Then
      WrkGrandTotal = WrkGrandTotal + WrkTotal
      dr = ds.Tables(0).NewRow
      dr.Item("year") = SaveYear
      dr.Item("suspense") = True
      dr.Item("repaid") = WrkREPaidSusp
      dr.Item("pppaid") = WrkPPPaidSusp
      dr.Item("mvpaid") = WrkMVPaidSusp
      dr.Item("supaid") = WrkSUPaidSusp
      dr.Item("suint") = WrkSUIntSusp
      dr.Item("otherint") = WrkOtherIntSusp
      dr.Item("totalint") = WrkSUIntSusp + WrkOtherIntSusp
      dr.Item("liens") = WrkLienSusp
      dr.Item("Fees") = WrkFeeSusp
      ds.Tables(0).Rows.Add(dr)
    End If
  End Sub
  Private Sub WriteDetail2()
    'TXE052
    Dim WrkTotal As Decimal

    'Regular
    WrkTotal = Wrk2Paid + Wrk2Int + Wrk2Lien + Wrk2Fee + Wrk2Bond
    If Wrk2Paid <> 0 Or Wrk2Int <> 0 Or Wrk2Lien <> 0 Or Wrk2Fee <> 0 Or Wrk2Bond <> 0 Then
      WrkGrandTotal = WrkGrandTotal + WrkTotal
      dr2 = ds2.Tables(0).NewRow
      dr2.Item("year") = SaveYear
      dr2.Item("type") = GetTXTypeDesc(SaveType)
      dr2.Item("suspense") = False
      dr2.Item("paid") = Wrk2Paid
      dr2.Item("interest") = Wrk2Int
      dr2.Item("liens") = Wrk2Lien
      dr2.Item("fees") = Wrk2Fee
      dr2.Item("bond") = Wrk2Bond
      ds2.Tables(0).Rows.Add(dr2)
    End If

    'Suspense
    WrkTotal = Wrk2PaidSusp + Wrk2IntSusp + Wrk2LienSusp + Wrk2FeeSusp + Wrk2BondSusp
    If Wrk2PaidSusp <> 0 Or Wrk2IntSusp <> 0 Or Wrk2LienSusp <> 0 Or Wrk2FeeSusp <> 0 Or Wrk2BondSusp <> 0 Then
      WrkGrandTotal = WrkGrandTotal + WrkTotal
      dr2 = ds2.Tables(0).NewRow
      dr2.Item("year") = SaveYear
      dr2.Item("type") = GetTXTypeDesc(SaveType)
      dr2.Item("suspense") = True
      dr2.Item("paid") = Wrk2PaidSusp
      dr2.Item("interest") = Wrk2IntSusp
      dr2.Item("liens") = Wrk2LienSusp
      dr2.Item("fees") = Wrk2FeeSusp
      dr2.Item("bond") = Wrk2BondSusp
      ds2.Tables(0).Rows.Add(dr2)
    End If
  End Sub
  Private Sub ClearTotals()
    WrkREPaid = 0
    WrkPPPaid = 0
    WrkMVPaid = 0
    WrkSUPaid = 0
    WrkProPaid = 0
    WrkSUInt = 0
    WrkOtherInt = 0
    WrkProInt = 0
    WrkLien = 0
    WrkProLien = 0
    WrkFee = 0
    WrkProFee = 0
    WrkREPaidSusp = 0
    WrkPPPaidSusp = 0
    WrkMVPaidSusp = 0
    WrkSUPaidSusp = 0
    WrkSUIntSusp = 0
    WrkOtherIntSusp = 0
    WrkLienSusp = 0
    WrkFeeSusp = 0
  End Sub
  Private Sub ClearTotals2()
    Wrk2Paid = 0
    Wrk2Int = 0
    Wrk2Lien = 0
    Wrk2Fee = 0
    Wrk2Bond = 0
    Wrk2PaidSusp = 0
    Wrk2IntSusp = 0
    Wrk2LienSusp = 0
    Wrk2FeeSusp = 0
    Wrk2BondSusp = 0
  End Sub
  Private Function BuildSelectTypes() As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim StrLen As Integer
    Dim I As Integer

    If MyTypes = "" Then
      Return ""
    End If

    sbSelect = New System.Text.StringBuilder
    sbSelect.Append("TYPE=%Values(")
    StrLen = Len(MyTypes)

    For I = 1 To StrLen
      WrkType = Mid(MyTypes, I, 1)
      sbSelect.Append(Chr(34) & WrkType & Chr(34) & " ")
    Next

    sbSelect.Append(")")
    Return sbSelect.ToString
  End Function
  Private Function BuildSelectQryPC(ByVal WrkStrIn As String, ByVal WrkSelTypes As String) As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim WrkStrOut As String
    Dim StrLen As Integer
    Dim I As Integer

    WrkStrOut = ""
    If WrkSelTypes = "" Then
      Return ""
    End If

    StrLen = Len(WrkSelTypes)
    sbSelect = New System.Text.StringBuilder
    For I = 1 To StrLen
      If I > 1 Then
        sbSelect.Append(",")
      End If
      WrkType = Mid(WrkSelTypes, I, 1)
      sbSelect.Append(MyUtils.Quo(WrkType))
    Next
    If WrkStrIn = "" Then
      WrkStrOut = "TYPE IN(" & sbSelect.ToString & ")"
    Else
      WrkStrOut = WrkStrIn & WrkAnd & "TYPE IN(" & sbSelect.ToString & ")"
    End If
    sbSelect = Nothing
    Return WrkStrOut
  End Function

End Module






