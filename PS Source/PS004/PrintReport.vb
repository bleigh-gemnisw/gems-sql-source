Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myMFPARKQ As MFPARKQ.myData

Dim ds1 As DataSet = New DataSet
Dim DSMFPARK As DataSet = New DataSet
Dim dr As Data.DataRow
Dim dr2 As Data.DataRow
Dim ds As DataSet = New DataSet
Dim WrkSortby As String
Dim WrkType As String
Dim WrkFromGLYear As Integer

Dim WrkSelection As String

Dim WrkAnd As String
Dim WrkOr As String


Public Sub PrtReport()

  myMFPARKQ = New MFPARKQ.mydata(MyDBConnect)

  With MyFrmPS004B
    If .Rbregno.Checked Then WrkSortby = "Regno"
    If .RbName.Checked Then WrkSortby = "Name"
    If .Rbperno.Checked Then WrkSortby = "Permit"
    WrkFromGLYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
  End With

  If ds1.Tables.Count = 0 Then
    BuildDS(ds1)

  Else
    ds1.Clear()

  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds1
  
  MyCrViewer.Show()

End Sub

  Private Sub BuildDS(ByRef ds1 As DataSet)
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
     .TableName = "mytable"
      .Columns.Add("Sortby", Type.GetType("System.String"))
      .Columns.Add("Mfliss", Type.GetType("System.DateTime"))
      .Columns.Add("Mfregno", Type.GetType("System.String"))
      .Columns.Add("mfcatg", Type.GetType("System.String"))
      .Columns.Add("Mfnam", Type.GetType("System.String"))
      .Columns.Add("Mfadd1", Type.GetType("System.String"))
      .Columns.Add("Mfperno", Type.GetType("System.Int32"))

    End With
    ds1.Tables.Add(myTable)

  End Sub


Private Sub GetDetail()
Dim sb As StringBuilder
Dim WrkSort As String
Dim WrkQry As String

Dim Counter As Integer
Dim SaveSortData As String
If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

WrkQry = "MFYEAR >= " & WrkFromGLYear 

WrkSort = "MFREG#"

Select Case WrkSortby
   Case "Regno"
      WrkSort = "MFREG#"
    Case "Name"
      WrkSort = "MFNAM"
    Case "Permit"
      WrkSort = "MFPER#"
 End Select

myMFPARKQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

SaveSortData = ""
ReadNext:
  myMFPARKQ.ReadQry()
  If Not myMFPARKQ.IsEOF Then
    Counter = Counter + 1
    With myMFPARKQ

    dr = ds1.Tables(0).NewRow
    dr.Item("mfliss") = MyUtils.GetDBDate(._MFLISS)
    dr.Item("mfregno") = ._MFREGNo
    dr.Item("mfnam") = ._MFNAM
    dr.Item("mfadd1") = ._MFADD1
    dr.Item("mfperno") = ._MFPERNo

    sb = New StringBuilder
    Select Case WrkSortby

    Case "Regno"
      sb.Append(._MFREGNo)
    Case "Name"
      sb.Append(._MFNAM)
    Case "Permit"
      sb.Append(._MFPERNo)
    End Select
    dr.Item("sortby") = sb.ToString
    sb = Nothing

  End With

  ds1.Tables(0).Rows.Add(dr)
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
myMFPARKQ.CloseFile()
End Sub

End Module






