Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXHSTQ As TXHSTQ.MyData

  'ds used by both TXE561 & TXE563
  Dim ds As DataSet = New DataSet
  'ds2 used by TXE562
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
  Dim WrkTransfer As Boolean
  Dim WrkShowTransfer As Boolean
  Dim WrkTransferTotal As Decimal
  Dim WrkTransferTotalOther As Decimal
  Dim SaveYear As Integer
  Dim SaveType As String
  Dim WrkAnd As String
  Dim WrkOr As String
  'Used in Adjustment report  
  Dim WrkRefundPrin As Decimal
  Dim WrkAdjustPrin As Decimal
  Dim WrkTransferPrin As Decimal
  Dim WrkATRInt As Decimal
  Dim WrkATRLiens As Decimal
  Dim WrkATRFees As Decimal
  'TXE562
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
    MyCrViewer.WrkTransfer = WrkTransfer
    MyCrViewer.WrkTransferTotal = WrkTransferTotal
    MyCrViewer.WrkTransferTotalOther = WrkTransferTotalOther
    MyCrViewer.WrkShowAdjust = WrkShowAdjust
    MyCrViewer.WrkShowTransfer = WrkShowTransfer
    MyCrViewer.WrkGrandTotal = WrkGrandTotal
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("AdjustPrin", Type.GetType("System.Decimal"))
      .Columns.Add("TransferPrin", Type.GetType("System.Decimal"))
      .Columns.Add("RefundPrin", Type.GetType("System.Decimal"))
      .Columns.Add("ATRInt", Type.GetType("System.Decimal"))
      .Columns.Add("ATRLiens", Type.GetType("System.Decimal"))
      .Columns.Add("ATRFees", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub BuildDS2()
    Dim myTable2 As New DataTable
    With myTable2
      .TableName = "mytable2"
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Paid", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Liens", Type.GetType("System.Decimal"))
      .Columns.Add("Fees", Type.GetType("System.Decimal"))
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
    End With
    ds2.Tables.Add(myTable2)

  End Sub
  Private Sub GetDetail()
    Dim dsType As DataSet = New DataSet
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
    WrkTransferTotal = 0
    WrkTransferTotalOther = 0
    WrkGrandTotal = 0

    With MyFrmTXE56B
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
      WrkTransfer = False
      If .ChkTransfer.Checked Then
        WrkTransfer = True
      End If
      WrkShowTransfer = False
      If .ChkShowTransfer.Checked Then
        WrkShowTransfer = True
      End If
    End With

    WrkSort = "YEAR desc, TYPE"
    WrkQry = "RCODE <> 'I'" & WrkAnd & "RCODE <>'V'" & WrkAnd &
  "PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo
    If Not WrkDistAll Then
      WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
    End If
    MyTypes = MyFrmTXE56B.TxtTypes.Text
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
        'TXE562
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
            WrkRefundPrin = WrkRefundPrin + ._PAMT
            WrkATRInt = WrkATRInt + ._IAMT
            WrkATRLiens = WrkATRLiens + ._LAMT
            WrkATRFees = WrkATRFees + ._PCAMT
            WrkRefundTotalOther = WrkRefundTotalOther + ._PAMT + ._IAMT + ._LAMT + ._PCAMT
          Else
            GoTo NextRec
          End If
        End If

        'Filter Adjustments
        If ._ADJCD = "A" And Trim(._PRF) <> "TXA12" Then
          If WrkAdjust Then
            WrkAdjustPrin = WrkAdjustPrin + ._PAMT
            WrkATRInt = WrkATRInt + ._IAMT
            WrkATRLiens = WrkATRLiens + ._LAMT
            WrkATRFees = WrkATRFees + ._PCAMT
            WrkAdjustTotalOther = WrkAdjustTotalOther + ._PAMT + ._IAMT + ._LAMT + ._PCAMT
          Else
            GoTo NextRec
          End If
        End If

        'Filter Transfers
        If ._ADJCD = "A" And Trim(._PRF) = "TXA12" Then
          If WrkTransfer Then
            WrkTransferPrin = WrkTransferPrin + ._PAMT
            WrkATRInt = WrkATRInt + ._IAMT
            WrkATRLiens = WrkATRLiens + ._LAMT
            WrkATRFees = WrkATRFees + ._PCAMT
            WrkTransferTotalOther = WrkTransferTotalOther + ._PAMT + ._IAMT + ._LAMT + ._PCAMT
          Else
            GoTo NextRec
          End If
        End If

        If ._RCODE <> "S" Then
          WrkType = ._TYPE
          Wrk2Paid = Wrk2Paid + ._PAMT
          Wrk2Int = Wrk2Int + ._IAMT
          Wrk2Lien = Wrk2Lien + ._LAMT
          If ._PENCD = "BI" Then
            Wrk2Bond = Wrk2Bond + ._PCAMT
          Else
            Wrk2Fee = Wrk2Fee + ._PCAMT
          End If
        Else
          WrkType = ._TYPE
          Wrk2PaidSusp = Wrk2PaidSusp + ._PAMT
          Wrk2IntSusp = Wrk2IntSusp + ._IAMT
          Wrk2LienSusp = Wrk2LienSusp + ._LAMT
          If ._PENCD = "BI" Then
            Wrk2BondSusp = Wrk2BondSusp + ._PCAMT
          Else
            Wrk2FeeSusp = Wrk2FeeSusp + ._PCAMT
          End If
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

    'TXE561 & TXE563 
    WriteDetail()

    'TXE562
    WriteDetail2()

    myFrmProgress.Close()
    myTXHSTQ.CloseFile()

  End Sub
  Private Sub WriteDetail()
    'TXE561  
    Dim WrkTotal As Decimal

    'Regular
    WrkGrandTotal = WrkGrandTotal + WrkTotal
    dr = ds.Tables(0).NewRow
    dr.Item("year") = SaveYear
    dr.Item("RefundPrin") = WrkRefundPrin
    dr.Item("AdjustPrin") = WrkAdjustPrin
    dr.Item("TransferPrin") = WrkTransferPrin
    dr.Item("ATRInt") = WrkATRInt
    dr.Item("ATRLiens") = WrkATRLiens
    dr.Item("ATRFees") = WrkATRFees
    ds.Tables(0).Rows.Add(dr)
  End Sub
  Private Sub WriteDetail2()
    'TXE562
    Dim WrkTotal As Decimal

    'Regular
    WrkTotal = Wrk2Paid + Wrk2Int + Wrk2Lien + Wrk2Fee + Wrk2Bond
    If Wrk2Paid <> 0 Or Wrk2Int <> 0 Or Wrk2Lien <> 0 Or Wrk2Fee <> 0 Or Wrk2Bond <> 0 Then
      WrkGrandTotal = WrkGrandTotal + WrkTotal
      dr2 = ds2.Tables(0).NewRow
      dr2.Item("year") = SaveYear
      dr2.Item("type") = GetTXTypeDesc(SaveType)
      dr2.Item("paid") = Wrk2Paid
      dr2.Item("interest") = Wrk2Int
      dr2.Item("liens") = Wrk2Lien
      dr2.Item("fees") = Wrk2Fee
      dr2.Item("bond") = Wrk2Bond
      ds2.Tables(0).Rows.Add(dr2)
    End If
  End Sub
  Private Sub ClearTotals()
    WrkRefundPrin = 0
    WrkAdjustPrin = 0
    WrkTransferPrin = 0
    WrkATRInt = 0
    WrkATRLiens = 0
    WrkATRFees = 0
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
