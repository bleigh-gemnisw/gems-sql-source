Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myBDMASTQ As BDMASTQ.myData
Dim myBDCOM As BDCOM.myData

Dim WrkFrom As Integer
Dim WrkTo As Integer
Dim WrkType As String
Dim WrkAnd As String
Dim WrkOr As String
Dim WrkSortby As String
Dim ds As DataSet = New DataSet
Dim dsTot As DataSet = New DataSet
Dim dr As DataRow
Public Sub PrtReport()

  myBDMASTQ = New BDMASTQ.mydata(MyDBConnect)
  myBDCOM = New BDCOM.mydata(MyDBConnect)
  With MyFrmBD202B
    WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
    WrkType = .TxtType.Text
    If .RbSortDate.Checked Then WrkSortby = "Date"
    If .RbSortLoc.Checked Then WrkSortby = "Loc"
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
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("PropLoc", Type.GetType("System.String"))
      .Columns.Add("PermNo", Type.GetType("System.String"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("JobValue", Type.GetType("System.Int32"))
      .Columns.Add("Trdate", Type.GetType("System.DateTime"))
      .Columns.Add("Comment", Type.GetType("System.String"))
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

WrkQry = "APDATE >= " & WrkFrom & WrkAnd & "APDATE <=" & WrkTo
If WrkType <> "" Then
  WrkQry = WrkQry & WrkAnd & "TYPE='" & WrkType & "'"
End If
WrkSort = ""
Select Case WrkSortby
Case "Date"
  WrkSort = "APDATE, NAME"
Case "Loc"
  WrkSort = "LOC, LOCNO"
End Select
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
    dr.Item("listno") = ._LISTNO
    dr.Item("name") = Trim(._NAME)
    dr.Item("proploc") = Trim(._LOCNO) & " " & Trim(._LOC)
    dr.Item("permno") = Trim(._PERMNO)
    dr.Item("type") = ._TYPE
    dr.Item("jobvalue") = ._VALUE + ._MISCHG
    dr.Item("trdate") = MyUtils.GetDBDate(._TRDATE)
    myBDCOM.GetOneRecordP(._RECID, 1)
    If Not myBDCOM.RecordNotFound Then
      dr.Item("comment") = myBDCOM._CMNT
    Else
      dr.Item("comment") = String.Empty
    End If
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










