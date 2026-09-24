Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim found As Boolean
Dim myTXSUPPQ As TXSUPPQ.myData

Dim ds As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim DsTXMVD As DataSet = New DataSet
Dim dr As Data.DataRow
Dim dr2 As Data.DataRow

Dim WrkTCount As Integer
Dim WrkTVal70 As Integer
Dim WrkTLYVal As Integer
Dim WrkTLNVal As Integer
Dim WrkTTIVal As Integer
Dim WrkTMSRPVal As Integer

  Public Sub PrtReport()

	myTXSUPPQ = New TXSUPPQ.mydata(MyDBConnect)

	If ds.Tables.Count = 0 Then
		BuildDS()
	Else
		ds.Clear()
		ds2.Clear()
		ClearTotals()

	End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds
  MyCrViewer.wrkds2 = ds2
  MyCrViewer.Show()

  End Sub
Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With (myTable)
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("value70", Type.GetType("System.Int32"))
      .Columns.Add("msrp", Type.GetType("System.Int32"))
      .Columns.Add("lnvalue", Type.GetType("System.Int32"))
      .Columns.Add("tradein", Type.GetType("System.Int32"))
      .Columns.Add("ecode", Type.GetType("System.String"))
      .Columns.Add("class", Type.GetType("System.Int32"))
      .Columns.Add("make", Type.GetType("System.String"))
      .Columns.Add("year", Type.GetType("System.Int32"))
      .Columns.Add("idno", Type.GetType("System.String"))
      .Columns.Add("model", Type.GetType("System.String"))
      .Columns.Add("body", Type.GetType("System.String"))
      .Columns.Add("cyl", Type.GetType("System.Int32"))
      .Columns.Add("lwt", Type.GetType("System.Int32"))
      .Columns.Add("gwt", Type.GetType("System.Int32"))
      .Columns.Add("oname", Type.GetType("System.String"))
      .Columns.Add("regno", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)


    With myTable2
      .TableName = "mytable2"
      .Columns.Add("TCount", Type.GetType("System.Int32"))
      .Columns.Add("TVal70", Type.GetType("System.Int32"))
      .Columns.Add("TLNVal", Type.GetType("System.Int32"))
      .Columns.Add("TTIVal", Type.GetType("System.Int32"))
      .Columns.Add("TMSRPVal", Type.GetType("System.Int32"))
    End With
    ds2.Tables.Add(myTable2)

  End Sub
Private Sub ClearTotals()
  WrkTCount = 0
  WrkTVal70 = 0
  WrkTLYVal = 0
  WrkTLNVal = 0
  WrkTTIVal = 0
  WrkTMSRPVal = 0
End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim I As Integer
Dim WrkAnd As String
Dim WrkOr As String

WrkSort = "CLASS, MAKE, YEAR, MODEL"
With MyFrmTA5071B
End With

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

WrkQry = "CAT = '1'"

DsTXMVD = myTXSUPPQ.GetQry(WrkSort, WrkQry, 0)
If DsTXMVD.Tables(0).Rows.Count = 0 Then Exit Sub
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

For I = 0 To (DsTXMVD.Tables(0).Rows.Count - 1)
  If MyReportCancel Then Exit Sub
  With DsTXMVD.Tables(0).Rows(I)
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = .Item("list#")
    dr.Item("value70") = .Item("value")
    dr.Item("msrp") = .Item("msrp")
    dr.Item("lnvalue") = .Item("lnval")
    dr.Item("tradein") = .Item("trval")
    dr.Item("ecode") = .Item("nada")
    dr.Item("class") = .Item("class")
    dr.Item("make") = .Item("make")
    dr.Item("year") = .Item("year")
    dr.Item("idno") = .Item("vinno")
    dr.Item("model") = .Item("model")
    dr.Item("body") = .Item("body")
    dr.Item("cyl") = .Item("cylax")
    dr.Item("lwt") = .Item("lwt")
    dr.Item("gwt") = .Item("gwt")
    dr.Item("regno") = .Item("regno")
    dr.Item("Oname") = .Item("name")

    WrkTVal70 = WrkTVal70 + .Item("value")
    WrkTLNVal = WrkTLNVal + .Item("lnval")
    WrkTTIVal = WrkTTIVal + .Item("trval")
    WrkTMSRPVal = WrkTMSRPVal + .Item("msrp")


End With
  ds.Tables(0).Rows.Add(dr)
  WrkTCount = WrkTCount + 1
  WriteTotals()

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
myTXSUPPQ.CloseFile()

End Sub
Private Sub WriteTotals()
  If WrkTCount = 0 Then Exit Sub

  dr2 = ds2.Tables(0).NewRow
  dr2.Item("tcount") = WrkTCount
  dr2.Item("tVal70") = WrkTVal70
  dr2.Item("tLNVal") = WrkTLNVal
  dr2.Item("tTIVal") = WrkTTIVal
  dr2.Item("tMSRPVal") = WrkTMSRPVal
  ds2.Tables(0).Rows.Add(dr2)
End Sub
End Module






