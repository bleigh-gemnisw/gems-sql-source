Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXMVDQ As TXMVDQ.myData
Dim dsTXMVD As DataSet = New DataSet
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow
Dim WrkFromClass As Integer
Dim WrkToClass As Integer
Dim WrkFromYear As Integer
Dim WrkToYear As Integer
Dim WrkUnpriced As Boolean
Dim WrkSortby As String

  Public Sub PrtReport(ByVal WrkClassDesc As String)
  Dim WrkFromClassDesc As String
  Dim WrkToClassDesc As String

	myTXMVDQ = New TXMVDQ.mydata(MyDBConnect)

  With MyFrmTA413B
    WrkFromClass = MyUtils.CnvSng(.TxtFromClass.Text)
    WrkToClass = MyUtils.CnvSng(.TxtToClass.Text)
    WrkFromYear = MyUtils.CnvSng(.TxtFromYear.Text)
    WrkToYear = MyUtils.CnvSng(.TxtToYear.Text)
		WrkUnpriced = .Chkunpriced.Checked
    If .RbSortMake.Checked Then WrkSortby = "Make"
    If .RbSortList.Checked Then WrkSortby = "List"
    If .RbSortName.Checked Then WrkSortby = "Name"
  End With

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If

  GetDetail()
  WrkFromClassDesc = GetTXCodeDesc(WrkFromClass, "M")
  WrkToClassDesc = GetTXCodeDesc(WrkToClass, "M")

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.Wrkds = ds
  MyCrViewer.WrkFromClass = WrkFromClass
  MyCrViewer.WrkFromClassDesc = WrkFromClassDesc
  MyCrViewer.WrkToClass = WrkToClass
  MyCrViewer.WrkToClassDesc = WrkToClassDesc
  MyCrViewer.WrkFromYear = WrkFromYear
  MyCrViewer.WrkToYear = WrkToYear
	MyCrViewer.WrkUnpriced = WrkUnpriced
	MyCrViewer.Show()
  End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("value", Type.GetType("System.Int32"))
      .Columns.Add("class", Type.GetType("System.Int32"))
      .Columns.Add("make", Type.GetType("System.String"))
      .Columns.Add("year", Type.GetType("System.Int32"))
      .Columns.Add("vinno", Type.GetType("System.String"))
      .Columns.Add("model", Type.GetType("System.String"))
      .Columns.Add("body", Type.GetType("System.String"))
      .Columns.Add("lwt", Type.GetType("System.Int32"))
      .Columns.Add("gwt", Type.GetType("System.Int32"))
      .Columns.Add("regno", Type.GetType("System.String"))
      .Columns.Add("seat", Type.GetType("System.Int32"))
      .Columns.Add("pclr", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()
Dim AddrLine() As String
Dim WrkQry As String
Dim WrkSort As String
Dim WrkAnd As String
Dim Counter As Integer

If myDBConnect.ServerAS400 Then
	WrkAnd = " *and "
Else
	WrkAnd = " And "
 End If

Counter = 0
WrkQry = ""
If WrkFromClass > 0 Then
	WrkQry = "class>=" & WrkFromClass
End If
If WrkToClass > 0 Then
	If WrkQry = String.Empty Then
		WrkQry = "class<=" & WrkToClass
	Else
		WrkQry = WrkQry & WrkAnd & "class<=" & WrkToClass
	End If
End If
If WrkFromYear > 0 Then
	If WrkQry = String.Empty Then
		WrkQry = "year>=" & WrkFromYear
	Else
		WrkQry = WrkQry & WrkAnd & "year>=" & WrkFromYear
	End If
End If
If WrkToYear > 0 Then
	If WrkQry = String.Empty Then
		WrkQry = "year<=" & WrkToYear
	Else
		WrkQry = WrkQry & WrkAnd & "year<=" & WrkToYear
	End If
End If
If WrkUnpriced Then
	If WrkQry = String.Empty Then
		WrkQry = "value=0"
	Else
		WrkQry = WrkQry & WrkAnd & "value=0"
	End If
End If

WrkSort = String.Empty
Select Case WrkSortby
Case "Make"
  WrkSort = "CLASS, MAKE, YEAR, MODEL"
Case "List"
  WrkSort = "LIST#"
Case "Name"
  WrkSort = "NAME, LIST#"
End Select
myTXMVDQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
	myTXMVDQ.ReadQry()
	If Not myTXMVDQ.IsEOF Then
		With myTXMVDQ
			Counter = Counter + 1
			dr = ds.Tables(0).NewRow
			dr.Item("listno") = ._LISTNo
      AddrLine = MyUtils.SetAddrLine(._NAME, ._SNAME, ._ADD1, ._ADD2, _
        ._CITY, ._STATE, ._ZIP5, ._ZIP4)
			dr.Item("addr1") = AddrLine(0)
			dr.Item("addr2") = AddrLine(1)
			dr.Item("addr3") = AddrLine(2)
			dr.Item("addr4") = AddrLine(3)
			dr.Item("addr5") = AddrLine(4)
			dr.Item("value") = ._VALUE
			dr.Item("class") = ._CLASS
			dr.Item("make") = Trim(._MAKE)
			dr.Item("year") = ._YEAR
			dr.Item("vinno") = Trim(._VINNO)
			dr.Item("model") = Trim(._MODEL)
			dr.Item("body") = Trim(._BODY)
			dr.Item("lwt") = ._LWT
			dr.Item("gwt") = ._GWT
			dr.Item("regno") = Trim(._REGNO)
			dr.Item("seat") = ._SEAT
			dr.Item("pclr") = Trim(._PCLR)
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
myTXMVDQ.CloseFile()

End Sub
End Module






