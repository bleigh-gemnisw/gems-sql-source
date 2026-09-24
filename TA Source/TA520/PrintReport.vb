Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXSUPPQ As TXSUPPQ.myData
Dim myTXSUPP As TXSupp.myData

Dim ds As DataSet = New DataSet
Dim DsTXSUPP As DataSet = New DataSet
Dim dr As Data.DataRow
Dim WrkPost As Boolean

  Public Sub PrtReport()

	myTXSUPPQ = New TXSUPPQ.mydata(MyDBConnect)
	myTXSUPP = New TXSupp.mydata(MyDBConnect)

  With MyFrmTA520B
    If .ChkPost.Checked Then WrkPost = True
  End With

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If

  GetDetail()

Done:
  MyCRViewer = New FrmCrViewer
  MyCRViewer.wrkds = ds
  MyCRViewer.WrkPost = WrkPost
  MyCRViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Sort", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("Make", Type.GetType("System.String"))
      .Columns.Add("Model", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Regno", Type.GetType("System.String"))
      .Columns.Add("Class", Type.GetType("System.Int32"))
      .Columns.Add("Vinno", Type.GetType("System.String"))
      .Columns.Add("Pclr", Type.GetType("System.String"))
      .Columns.Add("Lwt", Type.GetType("System.Int32"))
      .Columns.Add("Value", Type.GetType("System.Int32"))
      .Columns.Add("Scap", Type.GetType("System.Int32"))
      .Columns.Add("Sclr", Type.GetType("System.String"))
      .Columns.Add("Gwt", Type.GetType("System.Int32"))
      .Columns.Add("Ass", Type.GetType("System.String"))
			.Columns.Add("OMake", Type.GetType("System.String"))
			.Columns.Add("OMod", Type.GetType("System.String"))
			.Columns.Add("OYear", Type.GetType("System.Int32"))
			.Columns.Add("ORegno", Type.GetType("System.String"))
			.Columns.Add("OCls", Type.GetType("System.Int32"))
			.Columns.Add("OVin", Type.GetType("System.String"))
			.Columns.Add("OVal", Type.GetType("System.Int32"))
			.Columns.Add("OAss", Type.GetType("System.String"))
      .Columns.Add("PCustid", Type.GetType("System.Int32"))
      .Columns.Add("SCustid", Type.GetType("System.Int32"))
      .Columns.Add("Vehid", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Private Sub GetDetail()
Dim AddrLine() As String
Dim WrkQry As String
Dim WrkSort As String
Dim I As Integer
Dim WrkAnd As String

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

WrkSort = "ZIP5, NAME"
WrkQry = "CAT = 'T'"

DsTXSUPP = myTXSUPPQ.GetQry(WrkSort, WrkQry, 0)
If DsTXSUPP.Tables(0).Rows.Count = 0 Then Exit Sub
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

If DsTXSUPP.Tables(0).Rows.Count = 0 Then Exit Sub

For I = 0 To (DsTXSUPP.Tables(0).Rows.Count - 1)
  If MyReportCancel Then Exit Sub
  dr = ds.Tables(0).NewRow
  With DsTXSUPP.Tables(0).Rows(I)
    dr.Item("sort") = .Item("city")
    dr.Item("listno") = .Item("list#")
    AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"), _
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
    dr.Item("addr1") = AddrLine(0)
    dr.Item("addr2") = AddrLine(1)
    dr.Item("addr3") = AddrLine(2)
    dr.Item("addr4") = AddrLine(3)
    dr.Item("addr5") = AddrLine(4)
    dr.Item("make") = .Item("make")
    dr.Item("model") = .Item("model")
    dr.Item("year") = .Item("year")
    dr.Item("regno") = .Item("regno")
    dr.Item("class") = .Item("class")
    dr.Item("vinno") = .Item("vinno")
    dr.Item("pclr") = .Item("pclr")
    dr.Item("lwt") = .Item("lwt")
    dr.Item("value") = .Item("value")
    dr.Item("scap") = .Item("scap")
    dr.Item("sclr") = .Item("sclr")
    dr.Item("gwt") = .Item("gwt")
    dr.Item("ass") = .Item("ass")
		dr.Item("omake") = .Item("omake")
		dr.Item("omod") = .Item("omod")
		dr.Item("oyear") = .Item("oyear")
		dr.Item("oregno") = .Item("oreg#")
		dr.Item("ocls") = .Item("ocls")
		dr.Item("ovin") = .Item("ovin")
		dr.Item("oval") = .Item("oval")
		dr.Item("oass") = .Item("oass")
    dr.Item("pcustid") = .Item("ss#")
    dr.Item("scustid") = .Item("ss2")
    dr.Item("vehid") = .Item("oid")
    ds.Tables(0).Rows.Add(dr)

    If WrkPost Then
      DeleteTXSUPP(DsTXSUPP.Tables(0).Rows(I).Item("list#"))
    End If
  End With

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
myTXSUPP.CloseFile()

End Sub
Private Sub DeleteTXSUPP(ByVal List As Integer)
	myTXSUPP.GetOneRecordP(List)
	If Not myTXSUPP.RecordNotFound Then
		myTXSUPP.DeleteOneRecordP()
	End If
End Sub
End Module






