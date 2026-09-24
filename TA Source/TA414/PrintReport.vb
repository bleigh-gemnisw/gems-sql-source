Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXMVDQ As TXMVDQ.myData
Dim ds As DataSet = New DataSet
Dim DsTXMVD As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkAnd As String
Dim WrkOr As String

Public Sub PrtReport()

	myTXMVDQ = New TXMVDQ.mydata(MyDBConnect)

  With MyFrmTA414B
  End With

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
    ClearTotals()
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
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Vinno", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Regno", Type.GetType("System.String"))
      .Columns.Add("Class", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Make", Type.GetType("System.String"))
      .Columns.Add("Model", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub ClearTotals()
End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim I As Integer
Dim NextVIN As String
Dim Good As Boolean

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

WrkQry = ""

WrkSort = "VINNO"
DsTXMVD = myTXMVDQ.GetQry(WrkSort, WrkQry, 0)
If DsTXMVD.Tables(0).Rows.Count = 0 Then GoTo CloseFiles
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

NextVIN = ""
For I = 0 To (DsTXMVD.Tables(0).Rows.Count - 1)
  With DsTXMVD.Tables(0).Rows(I)
    If I <> (DsTXMVD.Tables(0).Rows.Count - 1) Then
      NextVIN = DsTXMVD.Tables(0).Rows(I + 1).Item("vinno")
    Else
      NextVIN = ""
    End If
    If .Item("vinno") = NextVIN Or Good Then
      Good = False
      dr = ds.Tables(0).NewRow
      dr.Item("listno") = .Item("list#")
      dr.Item("vinno") = .Item("vinno")
      dr.Item("name") = .Item("name")
      dr.Item("regno") = .Item("regno")
      dr.Item("class") = .Item("class")
      dr.Item("year") = .Item("year")
      dr.Item("make") = .Item("make")
      dr.Item("model") = .Item("model")
      ds.Tables(0).Rows.Add(dr)
      If .Item("vinno") = NextVIN Then Good = True
    End If
  End With
NextRec:
With myFrmProgress
  WrkPct = ((I + 1) / DsTXMVD.Tables(0).Rows.Count) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
  End If
End With
Next

myFrmProgress.Close()

CloseFiles:
myTXMVDQ.CloseFile()

End Sub
End Module






