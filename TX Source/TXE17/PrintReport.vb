Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXHSTQ As TXHSTQ.myData
Dim myTXHST As TXHSTL4.myData
Dim myTXINV As TXINV.myData
Dim ds As DataSet = New DataSet
Dim DsTXHSTQ As DataSet = New DataSet
Dim DsTXHST As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkType As String
Dim WrkFrom As Integer
Dim WrkTo As Integer
Dim WrkFromGLYear As Integer
Dim WrkToGLYear As Integer
Dim WrkAnd As String
Dim WrkOr As String
Public Sub PrtReport()

	myTXHSTQ = New TXHSTQ.mydata(MyDBConnect)
	myTXHST = New TXHSTL4.mydata(MyDBConnect)
	myTXINV = New TXINV.mydata(MyDBConnect)

  With MyFrmTXE17B
    WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
    WrkFromGLYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
    WrkToGLYear = MyUtils.CnvSng(.TxtToGLYear.Text)
  End With

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds
  MyCrViewer.Show()

End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("Principal", Type.GetType("System.Decimal"))
      .Columns.Add("Balance", Type.GetType("System.Decimal"))
      .Columns.Add("LienDt", Type.GetType("System.DateTime"))
      .Columns.Add("PaidDt", Type.GetType("System.DateTime"))
      .Columns.Add("Pamt", Type.GetType("System.Decimal"))
      .Columns.Add("Iamt", Type.GetType("System.Decimal"))
      .Columns.Add("Lamt", Type.GetType("System.Decimal"))
      .Columns.Add("PCamt", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()
Dim AddrLine() As String
Dim WrkSort As String
Dim WrkQry As String
Dim J As Integer
Dim WrkTypes As String
Dim Counter As Integer

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

Counter = 0
WrkQry = "RCODE = 'I'" & WrkAnd & "BATCHA='L'"
'  "PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo

If WrkFromGLYear > 0 Then
  WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromGLYear _
  & WrkAnd & "YEAR <= " & WrkToGLYear
End If

MyTypes = MyFrmTXE17B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    WrkSort = "YEAR, TYPE"
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
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = ._LISTNo
    dr.Item("year") = ._YEAR
    dr.Item("type") = ._TYPE
    dr.Item("principal") = ._PAMT
    dr.Item("liendt") = MyUtils.GetDBDate(._PDATE)
    myTXINV.GetOneRecordP(._LISTNo, ._YEAR, ._TYPE)
    If Not myTXINV.RecordNotFound Then
      With myTXINV
        AddrLine = MyUtils.SetAddrLine(._NAME, ._SNAME, ._ADD1, ._ADD2, ._CITY, ._STATE, ._ZIP5, ._ZIP4)
        dr.Item("addr1") = AddrLine(0)
        dr.Item("addr2") = AddrLine(1)
        dr.Item("addr3") = AddrLine(2)
        dr.Item("addr4") = AddrLine(3)
        dr.Item("addr5") = AddrLine(4)
        dr.Item("balance") = ._BALD
      End With
    End If
    dr.Item("pamt") = 0
    dr.Item("iamt") = 0
    dr.Item("lamt") = 0
    dr.Item("pcamt") = 0
    ds.Tables(0).Rows.Add(dr)

    DsTXHST = myTXHST.GetViewbyList(._LISTNo, ._YEAR, ._TYPE, WrkFrom, 999999)
    For J = 0 To (DsTXHST.Tables(0).Rows.Count - 1)
      With DsTXHST.Tables(0).Rows(J)
        If .Item("rcode") = "I" Then Continue For
        If .Item("rcode") = "V" Then Continue For
        If .Item("pdate") > WrkTo Then Exit For
        dr = ds.Tables(0).NewRow
        dr.Item("listno") = .Item("list#")
        dr.Item("year") = .Item("year")
        dr.Item("type") = .Item("type")
        dr.Item("principal") = 0
        dr.Item("pamt") = .Item("pamt")
        dr.Item("iamt") = .Item("iamt")
        dr.Item("lamt") = .Item("lamt")
        dr.Item("pcamt") = .Item("pcamt")
        dr.Item("paiddt") = MyUtils.GetDBDate(.Item("pdate"))
        ds.Tables(0).Rows.Add(dr)
      End With
    Next
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

myFrmProgress.Close()

CloseFiles:
myTXHSTQ.CloseFile()

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






