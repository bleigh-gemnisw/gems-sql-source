Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myLEDGERQ As LEDGERQ.MyData
Dim myGLFUND As GLFUND.MyData

Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkFundFrom As Integer
Dim WrkFundTo As Integer
Dim WrkNoActivity As Boolean
Dim WrkInactiveRpt As Boolean
Dim WrkDateFrom As Integer
Dim WrkDateTo As Integer
Dim WrkAnd As String
Dim WrkOr As String
  Public Sub PrtReport()
  myLEDGERQ = New LEDGERQ.MyData()
  myLEDGERQ.MyDBConn = myDBConnect
  myGLFUND = New GLFUND.MyData()
  myGLFUND.MyDBConn = myDBConnect

  With MyFrmGL704B
    WrkDateFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    WrkDateTo = MyUtils.SetDBDate(.DtPckTo.Value)
    WrkFundFrom = MyUtils.CnvSng(.TxtFundFrom.Text)
    WrkFundTo = MyUtils.CnvSng(.TxtFundTo.Text)
    WrkNoActivity = .ChkNoActivity.Checked
    WrkInactiveRpt = .ChkInactiveRpt.Checked
  End With


  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.ds = ds
  MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Fund", Type.GetType("System.Int32"))
      .Columns.Add("FundDesc", Type.GetType("System.String"))
      .Columns.Add("Debit", Type.GetType("System.Decimal"))
      .Columns.Add("Credit", Type.GetType("System.Decimal"))
      .Columns.Add("Diff", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Private Sub GetDetail()
Dim WrkQry As String
Dim WrkSort As String
Dim SaveQry As String
Dim SaveFund As Integer
Dim SaveAcct As String
Dim WrkAcct As String
Dim WrkFundDesc As String
Dim WrkFundBal As Decimal
Dim WrkDebit As Decimal
Dim WrkCredit As Decimal
Dim WrkFundDebit As Decimal
Dim WrkFundCredit As Decimal
Dim Counter As Integer

WrkAnd = " and "
WrkOr = " or "
Counter = 0

WrkQry = "PSTDT <= " & WrkDateTo
If WrkFundFrom > 0 Then
  WrkQry = WrkQry & WrkAnd & "FDNBR >= " & WrkFundFrom
End If
If WrkFundTo > 0 Then
  WrkQry = WrkQry & WrkAnd & "FDNBR <= " & WrkFundTo
End If
SaveQry = WrkQry
WrkQry = SaveQry & WrkAnd & "GLTYP = 'A'" & _
 WrkOr & SaveQry & WrkAnd & "GLTYP = 'L'" & _
 WrkOr & SaveQry & WrkAnd & "GLTYP = 'Q'"
WrkSort = "FDNBR, GLTYP, SFUND, DPNBR, OBNBR, FNPGM, SUBFN, PSTDT"

SaveFund = 0
SaveAcct = ""
WrkFundBal = 0
WrkDebit = 0
WrkCredit = 0
WrkFundDebit = 0
WrkFundCredit = 0
WrkFundDesc = ""
myLEDGERQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myLEDGERQ.ReadQry()
  If Not myLEDGERQ.IsEOF Then
  With myLEDGERQ
    Counter = Counter + 1
    If ._GLTYP = "Q" Then
      If ._FIL10 = 9999999999 And ._PSTDT < WrkDateFrom Then
        GoTo NextRec
      End If
    End If
    WrkAcct = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
    If SaveAcct <> "" Then
      If SaveAcct <> WrkAcct Then
        If WrkCredit > WrkDebit Then
          WrkFundCredit = WrkFundCredit + WrkCredit - WrkDebit
        End If
        If WrkDebit > WrkCredit Then
          WrkFundDebit = WrkFundDebit + WrkDebit - WrkCredit
        End If
        'dr = ds.Tables(0).NewRow
        'dr.Item("fund") = SaveFund
        'dr.Item("funddesc") = SaveAcct
        'dr.Item("debit") = WrkFundDebit
        'dr.Item("credit") = WrkFundCredit
        'dr.Item("diff") = WrkDebit - WrkCredit
        'ds.Tables(0).Rows.Add(dr)
        WrkDebit = 0
        WrkCredit = 0
     End If
    End If
    If SaveFund > 0 Then
      If ._FDNBR <> SaveFund Then
        WrkFundDesc = GetFundDesc(SaveFund, WrkInactiveRpt)
        If WrkFundDebit - WrkFundCredit <> 0 And WrkFundDesc <> "" Or WrkNoActivity And WrkFundDesc <> "" Then
          dr = ds.Tables(0).NewRow
          dr.Item("fund") = SaveFund
          dr.Item("funddesc") = GetFundDesc(SaveFund, WrkInactiveRpt)
          dr.Item("debit") = WrkFundDebit
          dr.Item("credit") = WrkFundCredit
          dr.Item("diff") = WrkFundDebit - WrkFundCredit
          ds.Tables(0).Rows.Add(dr)
        End If
        WrkFundDebit = 0
        WrkFundCredit = 0
      End If
    End If

    SaveFund = ._FDNBR
    SaveAcct = WrkAcct
    If ._AMTYP = "D" Then
      WrkDebit = WrkDebit + ._TRAMT
    Else
      WrkCredit = WrkCredit + ._TRAMT
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

  WrkFundDesc = GetFundDesc(SaveFund, WrkInactiveRpt)
  If WrkFundDebit - WrkFundCredit <> 0 And WrkFundDesc <> "" Or WrkNoActivity And WrkFundDesc <> "" Then
    dr = ds.Tables(0).NewRow
    dr.Item("fund") = SaveFund
    dr.Item("funddesc") = GetFundDesc(SaveFund, WrkInactiveRpt)
    dr.Item("debit") = WrkFundDebit
    dr.Item("credit") = WrkFundCredit
    dr.Item("diff") = WrkFundCredit - WrkFundDebit
    ds.Tables(0).Rows.Add(dr)
  End If

myFrmProgress.Close()
myLEDGERQ.CloseFile()
End Sub
Private Function BuildAcct(ByVal mfund As Integer, ByVal msfund As Integer, ByVal mdept As Integer, ByVal mobj As Integer, ByVal mfnpgm As Integer, ByVal msubfn As Integer) As String
  Dim sb As StringBuilder
  Dim WrkStr As String
  sb = New StringBuilder
  sb.Append(Format(mfund, "000"))
  sb.Append("-")
  sb.Append(Format(msfund, "000"))
  sb.Append("-")
  sb.Append(Format(mdept, "0000"))
  sb.Append("-")
  sb.Append(Format(mobj, "000"))
  sb.Append("-")
  sb.Append(Format(mfnpgm, "0000"))
  sb.Append("-")
  sb.Append(Format(msubfn, "0000"))
  WrkStr = sb.ToString
  sb = Nothing
  Return WrkStr
End Function
End Module
