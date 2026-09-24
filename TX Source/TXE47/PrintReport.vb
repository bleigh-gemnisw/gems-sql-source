Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINVQ As TXINVQ.MyData

Dim ds As DataSet = New DataSet
Dim DsTXINV As DataSet = New DataSet
Dim dr As Data.DataRow
'General
Dim WrkAnd As String
Dim WrkOr As String
	Public Sub PrtReport()

	myTXINVQ = New TXINVQ.mydata(MyDBConnect)

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
			.Columns.Add("SortData", Type.GetType("System.String"))
			.Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Desc", Type.GetType("System.String"))
			.Columns.Add("Tax1st", Type.GetType("System.Decimal"))
      .Columns.Add("Tax2nd", Type.GetType("System.Decimal"))
			.Columns.Add("Taxt", Type.GetType("System.Decimal"))
			.Columns.Add("Date", Type.GetType("System.DateTime"))
		End With
		ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()
Dim WrkYear As Integer
Dim WrkFrom As Integer
Dim WrkTo As Integer
Dim WrkQry As String
Dim WrkSort As String
Dim WrkSortBy As String
Dim Counter As Integer

WrkSortBy = ""
WrkFrom = 0
WrkTo = 0
With MyFrmTXE47B
  WrkYear = MyUtils.CnvSng(.TxtGLYear.Text)
	If .DtPckFrom.Checked Then
    WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
	End If
	If .DtPckTo.Checked Then
    WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
	End If
	If .RbName.Checked Then
		WrkSortBy = "Name"
	End If
	If .RbListNo.Checked Then
		WrkSortBy = "ListNo"
	End If
End With

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

WrkSort = ""
Counter = 0
Select Case WrkSortBy
Case "Name"
	WrkSort = "NAME"
Case "ListNo"
	WrkSort = "LIST#"
End Select

WrkQry = "ICODE<>'I'" & WrkAnd & "TYPE='X'" & WrkAnd & "YEAR = " & WrkYear
If WrkFrom > 0 Then
	WrkQry = WrkQry & WrkAnd & "PDAT >= " & WrkFrom
End If
If WrkTo > 0 Then
	WrkQry = WrkQry & WrkAnd & "PDAT <= " & WrkTo
End If
myTXINVQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
	myTXINVQ.ReadQry()
	If Not myTXINVQ.IsEOF Then
		With myTXINVQ
		Counter = Counter + 1
		dr = ds.Tables(0).NewRow
		Select Case WrkSortBy
		Case "Name"
			dr.Item("sortdata") = Trim(._NAME)
		Case "List"
			dr.Item("sortdata") = Format(._LISTNo, "000000")
		End Select
		dr.Item("listno") = ._LISTNo
		dr.Item("year") = ._YEAR
		dr.Item("name") = Trim(._NAME)
    dr.Item("desc") = MyUtils.JustifyRight(Trim(._LOCNo), 7) & " " & Trim(._LOC)
		dr.Item("tax1st") = ._TAX1
		dr.Item("tax2nd") = ._TAX2
		dr.Item("taxt") = ._TAXT
    dr.Item("date") = MyUtils.GetDBDate(._PDAT)
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
myTXINVQ.CloseFile()

End Sub
End Module






