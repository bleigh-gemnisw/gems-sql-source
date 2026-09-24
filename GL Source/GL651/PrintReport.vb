Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myGLBUDGETQ As GLBUDGETQ.myData

Dim ds As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim dr As Data.DataRow
  Public Sub PrtReport()

  myGLBUDGETQ = New GLBUDGETQ.MyData()
  myGLBUDGETQ.MyDBConn = myDBConnect

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
      .Columns.Add("Group", Type.GetType("System.String"))
      .Columns.Add("GroupDesc", Type.GetType("System.String"))
      .Columns.Add("Acct", Type.GetType("System.String"))
      .Columns.Add("Descr", Type.GetType("System.String"))
      .Columns.Add("Actual3Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Actual2Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Actual1Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Adopted", Type.GetType("System.Decimal"))
      .Columns.Add("Received", Type.GetType("System.Decimal"))
      .Columns.Add("Projected", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()
Dim WrkSelFund As Integer
Dim WrkSelDept As Integer
Dim WrkAcct As String
Dim WrkQry As String
Dim WrkSort As String
Dim Counter As Integer
Dim WrkAnd As String

With MyFrmGL651B
  WrkSelFund = MyUtils.CnvSng(.TxtFund.Text)
  WrkSelDept = MyUtils.CnvSng(.TxtDept.Text)
End With

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
End If

WrkSort = "DEPT"
WrkQry = "FUND=" & WrkSelFund & WrkAnd & "GLTYP='R'"
If WrkSelDept > 0 Then
  WrkQry = WrkQry & WrkAnd & "DEPT=" & WrkSelDept
End If
myGLBUDGETQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myGLBUDGETQ.ReadQry()
  If Not myGLBUDGETQ.IsEOF Then
  With myGLBUDGETQ
    Counter = Counter + 1
    WrkAcct = BuildAcct(._FUND, ._DEPT, ._OBJ, ._FUNC)
    dr = ds.Tables(0).NewRow
    dr.Item("group") = ._OBJ
    dr.Item("groupdesc") = GetGLOBJTDesc(._OBJ)
    dr.Item("acct") = WrkAcct
    dr.Item("descr") = ._DESCD
    dr.Item("actual3yr") = ._ACT3
    dr.Item("actual2yr") = ._ACT2
    dr.Item("actual1yr") = ._ACT1
    dr.Item("Received") = ._EXP
    dr.Item("Adopted") = ._CURR
    dr.Item("Projected") = ._BAMT3
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
myGLBUDGETQ.CloseFile()

End Sub
Private Function BuildAcct(ByVal Fund As Integer, ByVal Dept As Integer, ByVal Obj As Integer, ByVal Func As Integer) As String
  Dim sb As StringBuilder = New StringBuilder

  sb.Append(Fund)
  sb.Append("-")
  sb.Append(Dept)
  sb.Append("-")
  sb.Append(Obj)
  sb.Append("-")
  sb.Append(Func)
  Return sb.ToString
End Function
End Module
