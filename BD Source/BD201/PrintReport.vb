Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myBDMASTQ As BDMASTQ.myData
Dim myBDRATE As BDRATE.myData

Dim WrkTrDate As Integer
Dim WrkType As String
Dim WrkAnd As String
Dim WrkOr As String
Dim ds As DataSet = New DataSet
Dim dsTot As DataSet = New DataSet
Dim dr As DataRow
Public Sub PrtReport()

  myBDMASTQ = New BDMASTQ.mydata(MyDBConnect)
  myBDRATE = New BDRATE.mydata(MyDBConnect)

  With MyFrmBD201B
    WrkTrDate = MyUtils.SetDBDate(.DtPckTr.Value)
    WrkType = .TxtType.Text
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
      .Columns.Add("Trdate", Type.GetType("System.DateTime"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("PropLoc", Type.GetType("System.String"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("PermNo", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim Counter As Integer

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

WrkQry = "TRDATE <=" & WrkTrDate & WrkAnd & "INDATE=0"
If WrkType <> "" Then
  WrkQry = WrkQry & WrkAnd & "TYPE='" & WrkType & "'"
End If
WrkSort = "TRDATE, NAME"
myBDMASTQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myBDMASTQ.ReadQry()
  If Not myBDMASTQ.IsEOF Then
  With myBDMASTQ
    Counter = Counter + 1
    dr = ds.Tables(0).NewRow
    dr.Item("trdate") = MyUtils.GetDBDate(._TRDATE)
    dr.Item("name") = Trim(._NAME)
    dr.Item("proploc") = Trim(._LOCNO) & " " & Trim(._LOC)
    dr.Item("type") = ._TYPE
    dr.Item("permno") = Trim(._PERMNO)
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
myBDMASTQ.CloseFile()

End Sub
End Module






