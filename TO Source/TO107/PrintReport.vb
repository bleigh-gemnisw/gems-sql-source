Module PrintReport
	Dim myFrmProgress As FrmProgress
	Dim WrkPct As Integer
	Dim SavePct As Integer
	Dim myTXREALQ As TXREALQ.MyData
	Dim myTXREALCQ As TXREALCQ.MyData
	Dim myTXM37LND As TXM37LND.MyData
	Dim DsTXREAL As DataSet = New DataSet
	Dim ds As DataSet = New DataSet
	Dim dr As Data.DataRow
	Dim dsStateProp As dsStateProp

	Dim WrkType As String
	Dim WrkYear As Integer
	Dim WrkDist As Integer
	Dim WrkDistAll As Boolean
	Dim WrkFrozenFile As Boolean
	Dim WrkTotal As Integer
	Dim WrkReval As Boolean
	Dim WrkZeroes As Boolean
	Dim WrkPrintDist As Boolean
	Dim WrkPurDt As Integer
	Dim WrkPage As String
	'Buffered files
	Dim WrkCode(100) As Integer
	Dim WrkGroup(100) As String
	Public Sub PrtReport()

		myTXREALQ = New TXREALQ.MyData(myDBConnect)
		myTXREALCQ = New TXREALCQ.MyData(myDBConnect)
		myTXM37LND = New TXM37LND.MyData(myDBConnect)

		With MyFrmTO107B
			WrkType = "R"
			WrkYear = .TxtGLYear.Text
			WrkDist = MyUtils.CnvSng(.TxtDist.Text)
			If .TxtDist.Text = "" Then
				WrkDistAll = True
			End If
			WrkReval = False
			If .ChkReval.Checked Then
				WrkReval = True
			End If
			WrkZeroes = False
			If .ChkZeroes.Checked Then
				WrkZeroes = True
			End If
			WrkPrintDist = False
			If .ChkPrtDist.Checked Then
				WrkPrintDist = True
			End If
			WrkFrozenFile = False
			If .ChkFrozenFile.Checked Then
				WrkFrozenFile = True
			End If
			WrkPurDt = 0
			If .DtPckPurDate.Checked Then
				WrkPurDt = MyUtils.SetDBDate(.DtPckPurDate.Value)
			End If
		End With

		If ds.Tables.Count = 0 Then
			BuildDS()
		Else
			ds.Clear()
		End If

		dsStateProp = New dsStateProp
		BufferGroups()
		GetDetail()

		MyCrViewer = New FrmCrViewer
		With MyCrViewer
			.Wrkds = ds
			.Show()
		End With
	End Sub
	Friend Sub BuildDS()
		Dim myTable As New DataTable

		With myTable
			.TableName = "mytable"
			.Columns.Add("group", Type.GetType("System.String"))
			.Columns.Add("groupdesc", Type.GetType("System.String"))
			.Columns.Add("listno", Type.GetType("System.Int32"))
			.Columns.Add("name", Type.GetType("System.String"))
			.Columns.Add("proploc", Type.GetType("System.String"))
			.Columns.Add("map", Type.GetType("System.String"))
			.Columns.Add("volpage", Type.GetType("System.String"))
			.Columns.Add("units", Type.GetType("System.Int32"))
			.Columns.Add("buildings", Type.GetType("System.Int32"))
			.Columns.Add("acres", Type.GetType("System.Decimal"))
			.Columns.Add("land", Type.GetType("System.Int32"))
			.Columns.Add("total", Type.GetType("System.Int32"))
		End With
		ds.Tables.Add(myTable)
	End Sub
	Private Sub GetDetail()
		Dim WrkSort As String
		Dim WrkQry As String
		Dim WrkAssCode(6) As Integer
		Dim WrkGross(6) As Integer
		Dim WrkUnits(6) As Integer
		Dim WrkAcres(6) As Decimal
		Dim WrkOPMGroup As String
		Dim WrkTAcres As Decimal
		Dim WrkLand As Integer
		Dim WrkBuildings As Integer
		Dim I As Integer
		Dim J As Integer
		Dim WrkAnd As String

		If myDBConnect.ServerName = "DB2" Then
			WrkAnd = " *and "
		Else
			WrkAnd = " and "
		End If

		WrkSort = ""
		WrkQry = "EXMPT>='O'" & WrkAnd & "EXMPT<'Q'" & WrkAnd & "EXMPT<>'OJAX'"
		If Not WrkDistAll Then
			If Not WrkPrintDist Then
				WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
			Else
				WrkQry = WrkQry & WrkAnd & "pdst=" & WrkDist
			End If
		End If
		If Not WrkFrozenFile Then
			DsTXREAL = myTXREALQ.GetQry(WrkSort, WrkQry, 0)
		Else
			DsTXREAL = myTXREALCQ.GetQry(WrkSort, WrkQry, 0)
		End If
		If DsTXREAL.Tables(0).Rows.Count = 0 Then Exit Sub
		myFrmProgress = New FrmProgress
		myFrmProgress.LblMsg.Text = ""
		myFrmProgress.Show()
		myFrmProgress.Refresh()
		Application.DoEvents()

		For I = 0 To (DsTXREAL.Tables(0).Rows.Count - 1)
			With DsTXREAL.Tables(0).Rows(I)
				WrkAssCode(0) = .Item("code1")
				WrkAssCode(1) = .Item("code2")
				WrkAssCode(2) = .Item("code3")
				WrkAssCode(3) = .Item("code4")
				WrkAssCode(4) = .Item("code5")
				WrkAssCode(5) = .Item("code6")
				WrkAssCode(6) = .Item("code7")
				WrkGross(0) = .Item("ass1")
				WrkGross(1) = .Item("ass2")
				WrkGross(2) = .Item("ass3")
				WrkGross(3) = .Item("ass4")
				WrkGross(4) = .Item("ass5")
				WrkGross(5) = .Item("ass6")
				WrkGross(6) = .Item("ass7")
				WrkUnits(0) = .Item("unit1")
				WrkUnits(1) = .Item("unit2")
				WrkUnits(2) = .Item("unit3")
				WrkUnits(3) = .Item("unit4")
				WrkUnits(4) = .Item("unit5")
				WrkUnits(5) = .Item("unit6")
				WrkUnits(6) = .Item("unit7")
				WrkAcres(0) = .Item("acre1")
				WrkAcres(1) = .Item("acre2")
				WrkAcres(2) = .Item("acre3")
				WrkAcres(3) = .Item("acre4")
				WrkAcres(4) = .Item("acre5")
				WrkAcres(5) = .Item("acre6")
				WrkAcres(6) = .Item("acre7")
				dr = ds.Tables(0).NewRow
				dr.Item("group") = .Item("exmpt")
				dr.Item("groupdesc") = GetTXXPROPDesc(.Item("exmpt"))
				dr.Item("listno") = .Item("list#")
				dr.Item("name") = .Item("name")
				dr.Item("proploc") = .Item("loc#") & " " & .Item("loc")
				dr.Item("map") = .Item("map")
				dr.Item("volpage") = .Item("vol") & " " & .Item("pge")
				dr.Item("units") = WrkUnits(0) + WrkUnits(1) + WrkUnits(2) + WrkUnits(3) +
			WrkUnits(4) + WrkUnits(5) + WrkUnits(6)
				WrkBuildings = 0
				WrkLand = 0
				'Add Gross to Land or Building total
				For J = 0 To 6
					If WrkAssCode(J) > 0 Then
						WrkOPMGroup = LookupOPMCode(WrkAssCode(J))
						If WrkOPMGroup = "L" Then
							WrkLand = WrkLand + WrkGross(J)
						End If
						If WrkOPMGroup = "B" Then
							WrkBuildings = WrkBuildings + WrkGross(J)
						End If
					End If
				Next J
				myTXM37LND.GetOneRecordP(.Item("exmpt"))
				If Not myTXM37LND.RecordNotFound Then
					WrkBuildings = 0
				End If
				If WrkPurDt > 0 Then
					If .Item("purdt") >= WrkPurDt Then
						dr.Item("buildings") = WrkBuildings
					Else
						WrkBuildings = 0
					End If
				Else
					dr.Item("buildings") = WrkBuildings
				End If
				WrkTAcres = WrkAcres(0) + WrkAcres(1) + WrkAcres(2) + WrkAcres(3) +
			WrkAcres(4) + WrkAcres(5) + WrkAcres(6)
				dr.Item("acres") = WrkTAcres
				dr.Item("land") = WrkLand
				dr.Item("total") = WrkLand + WrkBuildings
				ds.Tables(0).Rows.Add(dr)
				BuildFile(I, WrkTAcres, WrkLand, WrkBuildings)
			End With

NextRec:
			With myFrmProgress
				WrkPct = ((I + 1) / DsTXREAL.Tables(0).Rows.Count) * 100
				If SavePct <> WrkPct Then
					.ProgBar1.Value = WrkPct
					.Refresh()
					SavePct = WrkPct
					Application.DoEvents()
				End If
			End With
		Next

		If dsStateProp.Tables("document").Rows.Count > 0 Then
			dsStateProp.WriteXml(MyFrmTO107B.LblFilePath.Text)
		End If

		myFrmProgress.Close()
		Application.DoEvents()
		myTXREALQ.CloseFile()
		myTXREALCQ.CloseFile()

	End Sub
	Private Sub BufferGroups()
		Dim I As Integer

		Dim myTXCode As TXCODE.MyData
		Dim dsTXCode As DataSet = New DataSet

		Array.Clear(WrkCode, 0, 101)
		Array.Clear(WrkGroup, 0, 101)

		myTXCode = New TXCODE.MyData(myDBConnect)

		dsTXCode = myTXCode.GetAllType(WrkType)
		For I = 0 To dsTXCode.Tables(0).Rows.Count - 1
			With dsTXCode.Tables(0).Rows(I)
				WrkCode(I) = .Item("tccode")
				WrkGroup(I) = .Item("tcgrp")
			End With
		Next

	End Sub
	Private Function LookupOPMCode(ByVal Code As Integer) As String
		Dim I As Integer
		Dim WrkResult As String

		For I = 0 To WrkCode.GetUpperBound(0)
			If WrkCode(I) = 0 Then
				Return ""
			End If
			If Code = WrkCode(I) Then
				WrkResult = WrkGroup(I)
				Return WrkResult
			End If
		Next

		Return ""
	End Function
	Public Sub BuildFile(I As Integer, WrkTAcres As Decimal, WrkLand As Integer, WrkBuildings As Integer)
		Dim drDocument As dsStateProp.DocumentRow
		Dim drProperty As dsStateProp._PropertyRow

		If I = 0 Then
			drDocument = dsStateProp.Document.NewDocumentRow
			With drDocument
				.Document_Id = 1
				.GrandListYear = WrkYear
				.IsRevalYear = WrkReval
				.PrimaryTownCode = myTOWN._TOWNBR
				dsStateProp.Document.AddDocumentRow(drDocument)
			End With
		End If

		drProperty = dsStateProp._Property.New_PropertyRow()
		With drProperty
			.Acreage = WrkTAcres
			.Address = Trim(DsTXREAL.Tables(0).Rows(I).Item("loc#")) & " " & DsTXREAL.Tables(0).Rows(I).Item("loc")
			.BoroughCode = 0
			.BuildingAssessment = WrkBuildings
			.Document_Id = 1
			.DistrictName = ""
			.ExemptAbstractCode = DsTXREAL.Tables(0).Rows(I).Item("exmpt")
			.FireDistrictCode = 0
			.LandAssessment = WrkLand
			.OwnerOrFacilityName = DsTXREAL.Tables(0).Rows(I).Item("name")
			.TotalAssessment = WrkLand + WrkBuildings
			If WrkZeroes Then
				.UniqueProprtyID = Format(DsTXREAL.Tables(0).Rows(I).Item("list#"), "000000")
			Else
				.UniqueProprtyID = DsTXREAL.Tables(0).Rows(I).Item("list#")
			End If
			.VolumeAndPage = Trim(DsTXREAL.Tables(0).Rows(I).Item("vol")) & " " & Trim(DsTXREAL.Tables(0).Rows(I).Item("pge"))
			dsStateProp._Property.Add_PropertyRow(drProperty)
		End With
	End Sub
End Module






