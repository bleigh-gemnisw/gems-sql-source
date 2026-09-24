Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXHSTQ As TXHSTQ.myData
Dim myTXINV As TXINV.myData
Dim ds As DataSet = New DataSet
Dim DsTXHST As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkType As String
Dim WrkFrom As Integer
Dim WrkTo As Integer
Dim WrkAnd As String
Dim WrkOr As String
Public Sub PrtReport()

	myTXHSTQ = New TXHSTQ.mydata(MyDBConnect)
	myTXINV = New TXINV.mydata(MyDBConnect)

  With MyFrmTXE16B
    WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
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
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("OrigInt", Type.GetType("System.Decimal"))
      .Columns.Add("IntPaid", Type.GetType("System.Decimal"))
      .Columns.Add("DatePaid", Type.GetType("System.DateTime"))
      .Columns.Add("Comment", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim Counter As Integer
Dim WrkTypes As String

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

Counter = 0
WrkQry = "RCODE <>'V'" & WrkAnd & "RCODE <>'I'" & WrkAnd & "INTOR <> 0" & WrkAnd & _
  "INTOR<>IAMT" & WrkAnd & "PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo

MyTypes = MyFrmTXE16B.TxtTypes.Text
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
    myTXINV.GetOneRecordP(._LISTNo, ._YEAR, ._TYPE)
    If Not myTXINV.RecordNotFound Then
      dr.Item("name") = Trim(myTXINV._NAME)
    End If
    dr.Item("origint") = ._INTOR
    dr.Item("intpaid") = ._IAMT
    dr.Item("datepaid") = MyUtils.GetDBDate(._PDATE)
    dr.Item("comment") = Trim(._COMM)
    ds.Tables(0).Rows.Add(dr)
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






