Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim WrkPriced As Boolean
Dim myTXSUPPQ As TXSUPPQ.myData

Dim ds As DataSet = New DataSet
Dim DsTXSUPP As DataSet = New DataSet
Dim dr As Data.DataRow

  Public Sub PrtReport()

	myTXSUPPQ = New TXSUPPQ.mydata(MyDBConnect)

  With MyFrmTA518B
    WrkPriced = .ChkPriced.Checked
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
      .Columns.Add("Make", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Model", Type.GetType("System.String"))
      .Columns.Add("Regno", Type.GetType("System.String"))
      .Columns.Add("Class", Type.GetType("System.Int32"))
      .Columns.Add("OMake", Type.GetType("System.String"))
      .Columns.Add("OYear", Type.GetType("System.Int32"))
      .Columns.Add("OMod", Type.GetType("System.String"))
      .Columns.Add("OReg", Type.GetType("System.String"))
      .Columns.Add("OVin", Type.GetType("System.String"))
      .Columns.Add("OList", Type.GetType("System.Int32"))
      .Columns.Add("OAss", Type.GetType("System.String"))
      .Columns.Add("OVal", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Private Sub GetDetail()
Dim WrkQry As String
Dim WrkSort As String
Dim I As Integer
Dim WrkAnd As String

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

WrkSort = "NAME"
WrkQry = "ASS>'M'"
If Not WrkPriced Then
  WrkQry = WrkQry & WrkAnd & "VALUE=0"
End If

DsTXSUPP = myTXSUPPQ.GetQry(WrkSort, WrkQry, 0)
If DsTXSUPP.Tables(0).Rows.Count = 0 Then Exit Sub
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

If DsTXSUPP.Tables(0).Rows.Count = 0 Then Exit Sub

For I = 0 To (DsTXSUPP.Tables(0).Rows.Count - 1)
  With DsTXSUPP.Tables(0).Rows(I)
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = .Item("list#")
    dr.Item("name") = .Item("name")
    dr.Item("make") = .Item("make")
    dr.Item("year") = .Item("year")
    dr.Item("model") = .Item("model")
    dr.Item("regno") = .Item("regno")
    dr.Item("class") = .Item("class")
    dr.Item("omake") = .Item("omake")
    dr.Item("oyear") = .Item("oyear")
    dr.Item("omod") = .Item("omod")
    dr.Item("oreg") = .Item("oreg#")
    dr.Item("ovin") = .Item("ovin")
    dr.Item("olist") = .Item("olist")
    dr.Item("oass") = .Item("oass")
    dr.Item("oval") = .Item("oval")
  End With
  ds.Tables(0).Rows.Add(dr)

NextRec:
With myFrmProgress
  If DsTXSUPP.Tables(0).Rows.Count > 1 Then
    WrkPct = ((I + 1) / DsTXSUPP.Tables(0).Rows.Count) * 100
    If SavePct <> WrkPct Then
      .ProgBar1.Value = WrkPct
      .Refresh()
      SavePct = WrkPct
      Application.DoEvents()
    End If
  End If
End With
Next

myFrmProgress.Close()
myTXSUPPQ.CloseFile()

End Sub
End Module






