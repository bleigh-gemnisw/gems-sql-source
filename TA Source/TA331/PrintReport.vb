Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myLOGMVQ As LOGMVQ.myData
Dim myLOGPPQ As LOGPPQ.myData
Dim myLOGREQ As LOGREQ.myData
Dim myLOGSUQ As LOGSUQ.myData

Dim WrkFrom As Integer
Dim WrkTo As Integer
Dim WrkType As String
Dim WrkAnd As String
Dim WrkOr As String
Dim WrkSort As String
Dim WrkQry As String
Dim ds As DataSet = New DataSet
Dim dr As DataRow
Public Sub PrtReport()

  myLOGMVQ = New LOGMVQ.mydata(MyDBConnect)
  myLOGPPQ = New LOGPPQ.mydata(MyDBConnect)
  myLOGREQ = New LOGREQ.mydata(MyDBConnect)
  myLOGSUQ = New LOGSUQ.mydata(MyDBConnect)

  With MyFrmTA331B
    WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
    If .RbMV.Checked Then WrkType = "M"
    If .RbPP.Checked Then WrkType = "P"
    If .RbRE.Checked Then WrkType = "R"
    If .RbSU.Checked Then WrkType = "S"
  End With

  If MyServer = "DB2" Then
    WrkAnd = " *and "
    WrkOr = " *or "
  Else
    WrkAnd = " and "
    WrkOr = " or "
  End If
  WrkQry = "logdte >=" & WrkFrom & WrkAnd & "logdte <=" & WrkTo
  If Not MyFrmTA331B.ChkAdds.Checked Then
    WrkQry = WrkQry & WrkAnd & "LOGCMT<>'Record Added'"
  End If
  If Not MyFrmTA331B.ChkChanges.Checked Then
    WrkQry = WrkQry & WrkAnd & "LOGCMT<>'Record Changed'"
  End If
  If Not MyFrmTA331B.ChkDeletes.Checked Then
    WrkQry = WrkQry & WrkAnd & "LOGCMT<>'Record Deleted'"
  End If
  WrkSort = "NAME"

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If

  Select Case WrkType
  Case "R"
    GetDetailRE()
  Case "P"
    GetDetailPP()
  Case "M"
    GetDetailMV()
  Case "S"
    GetDetailSU()
  End Select

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds
  MyCrViewer.WrkType = WrkType
  MyCrViewer.Show()

End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("Net", Type.GetType("System.Int32"))
      .Columns.Add("Action", Type.GetType("System.String"))
      .Columns.Add("Date", Type.GetType("System.DateTime"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Private Sub GetDetailRE()
Dim Counter As Integer

myLOGREQ.OpenQry(WrkSort, WrkQry)
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myLOGREQ.ReadQry()
  If Not myLOGREQ.IsEOF Then
  With myLOGREQ
    Counter = Counter + 1
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = ._LISTNo
    dr.Item("name") = Trim(._NAME)
    dr.Item("desc") = Trim(._LOCNO) & " " & Trim(._LOC)
    dr.Item("net") = ._NET
    dr.Item("action") = ._LOGCMT
    dr.Item("date") = MyUtils.GetDBDate(._LOGDTE)
  End With
  ds.Tables(0).Rows.Add(dr)
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
myLOGREQ.CloseFile()

End Sub
Private Sub GetDetailPP()
Dim Counter As Integer

myLOGPPQ.OpenQry(WrkSort, WrkQry)
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myLOGPPQ.ReadQry()
  If Not myLOGPPQ.IsEOF Then
  With myLOGPPQ
    Counter = Counter + 1
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = ._LISTno
    dr.Item("name") = Trim(._NAME)
    dr.Item("desc") = Trim(._LOCNo) & " " & Trim(._LOC)
    dr.Item("net") = ._NET
    dr.Item("action") = ._LOGCMT
    dr.Item("date") = MyUtils.GetDBDate(._LOGDTE)
  End With
  ds.Tables(0).Rows.Add(dr)
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
myLOGPPQ.CloseFile()

End Sub
Private Sub GetDetailMV()
Dim Counter As Integer

myLOGMVQ.OpenQry(WrkSort, WrkQry)
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myLOGMVQ.ReadQry()
  If Not myLOGMVQ.IsEOF Then
  With myLOGMVQ
    Counter = Counter + 1
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = ._LISTNo
    dr.Item("name") = Trim(._NAME)
    dr.Item("desc") = Trim(._MAKE) & " " & Trim(._YEAR) & " " & ._REGNO
    dr.Item("net") = ._VALUE
    dr.Item("action") = ._LOGCMT
    dr.Item("date") = MyUtils.GetDBDate(._LOGDTE)
  End With
  ds.Tables(0).Rows.Add(dr)
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
myLOGMVQ.CloseFile()

End Sub
Private Sub GetDetailSU()
Dim Counter As Integer

myLOGSUQ.OpenQry(WrkSort, WrkQry)
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myLOGSUQ.ReadQry()
  If Not myLOGSUQ.IsEOF Then
  With myLOGSUQ
    Counter = Counter + 1
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = ._LISTNo
    dr.Item("name") = Trim(._NAME)
    dr.Item("desc") = Trim(._MAKE) & " " & Trim(._YEAR) & " " & ._REGNO
    dr.Item("net") = ._VALUE
    dr.Item("action") = ._LOGCMT
    dr.Item("date") = MyUtils.GetDBDate(._LOGDTE)
  End With
  ds.Tables(0).Rows.Add(dr)
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
myLOGSUQ.CloseFile()

End Sub
End Module






