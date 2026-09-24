Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXMVDQ As TXMVDQ.myData
Dim dsTXMVD As DataSet = New DataSet
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow
Dim WrkClass As Integer
  Public Sub PrtReport(ByVal WrkClassDesc As String)
	myTXMVDQ = New TXMVDQ.mydata(MyDBConnect)

  With MyFrmTA408B
    WrkClass = MyUtils.CnvSng(.TxtClass.Text)
  End With

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.Wrkds = ds
  MyCrViewer.WrkClass = WrkClass
  MyCrViewer.WrkClassDesc = WrkClassDesc
  MyCrViewer.Show()
  End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("class", Type.GetType("System.Int32"))
      .Columns.Add("make", Type.GetType("System.String"))
      .Columns.Add("year", Type.GetType("System.Int32"))
      .Columns.Add("vinno", Type.GetType("System.String"))
      .Columns.Add("model", Type.GetType("System.String"))
      .Columns.Add("gwt", Type.GetType("System.Int32"))
      .Columns.Add("lwt", Type.GetType("System.Int32"))
      .Columns.Add("capacity", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim I As Integer
Dim WrkAnd As String

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

WrkSort = "CLASS, YEAR, MAKE, MODEL, VINNO"
WrkQry = ""
If WrkClass > 0 Then
  WrkQry = "class=" & WrkClass
End If
dsTXMVD = myTXMVDQ.GetQry(WrkSort, WrkQry, 0)
If dsTXMVD.Tables(0).Rows.Count = 0 Then Exit Sub

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

For I = 0 To (dsTXMVD.Tables(0).Rows.Count - 1)
  With dsTXMVD.Tables(0).Rows(I)
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = .Item("list#")
    dr.Item("name") = .Item("name")
    dr.Item("class") = .Item("class")
    dr.Item("make") = .Item("make")
    dr.Item("year") = .Item("year")
    dr.Item("vinno") = .Item("vinno")
    dr.Item("model") = .Item("model")
    dr.Item("gwt") = .Item("gwt")
    dr.Item("lwt") = .Item("lwt")
    dr.Item("capacity") = Math.Abs(.Item("gwt") - .Item("lwt"))
    ds.Tables(0).Rows.Add(dr)
  End With

NextRec:
With myFrmProgress
  WrkPct = ((I + 1) / dsTXMVD.Tables(0).Rows.Count) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
  End If
End With
Next

myFrmProgress.Close()
myTXMVDQ.CloseFile()

End Sub
End Module






