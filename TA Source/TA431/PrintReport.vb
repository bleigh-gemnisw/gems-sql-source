Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim found As Boolean
Dim myTXMVDQ As TXMVDQ.myData
Dim myTXMVD As TXMVD.myData

Dim ds As DataSet = New DataSet
Dim DsTXMVDQ As DataSet = New DataSet
Dim dr As Data.DataRow

'Screen
Dim WrkRoundDown As Boolean
Dim WrkPost As Boolean

	Public Sub PrtReport()

	myTXMVDQ = New TXMVDQ.mydata(MyDBConnect)
	myTXMVD = New TXMVD.mydata(MyDBConnect)

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

		With (myTable)
			.TableName = "mytable"
			.Columns.Add("ListNo", Type.GetType("System.Int32"))
			.Columns.Add("oname", Type.GetType("System.String"))
			.Columns.Add("class", Type.GetType("System.Int32"))
			.Columns.Add("make", Type.GetType("System.String"))
			.Columns.Add("year", Type.GetType("System.Int32"))
			.Columns.Add("idno", Type.GetType("System.String"))
			.Columns.Add("model", Type.GetType("System.String"))
			.Columns.Add("value", Type.GetType("System.Int32"))
		End With
		ds.Tables.Add(myTable)
	End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim I As Integer
Dim J As Integer
Dim WrkAnd As String
Dim WrkOr As String
Dim WrkValue As Integer

WrkSort = "MAKE, YEAR, MODEL, CLASS"
With MyFrmTA431B
	WrkRoundDown = .RbDown.Checked
	WrkPost = .ChkUpdate.Checked
End With

If myDBConnect.ServerAS400 Then
	WrkAnd = " *and "
	WrkOr = " *or "
Else
	WrkAnd = " and "
	WrkOr = " or "
End If

WrkQry = "CAT = '1'" & WrkAnd & "VALUE>0"

DsTXMVDQ = myTXMVDQ.GetQry(WrkSort, WrkQry, 0)
If DsTXMVDQ.Tables(0).Rows.Count = 0 Then Exit Sub
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

For I = 0 To (DsTXMVDQ.Tables(0).Rows.Count - 1)
	With DsTXMVDQ.Tables(0).Rows(I)
		WrkValue = 0
		dr = ds.Tables(0).NewRow
		dr.Item("listno") = .Item("list#")
		dr.Item("Oname") = .Item("name")
		dr.Item("class") = .Item("class")
		dr.Item("year") = .Item("year")
		dr.Item("make") = .Item("make")
		dr.Item("model") = .Item("model")
		dr.Item("idno") = .Item("vinno")

		WrkValue = 0
		J = .Item("value") Mod 10
		If J <> 0 Then
			WrkValue = .Item("value")
			If WrkRoundDown Then
				WrkValue = WrkValue - J
			Else
				If J < 5 Then
					WrkValue = WrkValue - J
				Else
					WrkValue = WrkValue + (10 - J)
				End If
			End If
		End If

		If WrkValue > 0 Then
			dr.Item("value") = WrkValue
			ds.Tables(0).Rows.Add(dr)
			If WrkPost Then
				UpdateTXMVD(.Item("list#"), WrkValue)
			End If
		End If
	End With

NextRec:
With myFrmProgress
	WrkPct = ((I + 1) / DsTXMVDQ.Tables(0).Rows.Count) * 100
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
myTXMVD.CloseFile()

End Sub
Private Sub UpdateTXMVD(ByVal WrkListNo As Integer, ByVal WrkValue As Integer)

	myTXMVD.GetOneRecordP(WrkListNo)
	If myTXMVD.RecordNotFound Then Exit Sub

	With myTXMVD
		._VALUE = WrkValue
		myTXMVD.UpdateOneRecordP()
	End With
End Sub
End Module






