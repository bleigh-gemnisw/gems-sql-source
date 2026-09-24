Imports System.text
Module PrintReport
Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXCOOQ As TXCOOQ.MyData
Dim myTXREAL As TXREAL.MyData
Dim myTXREALC As TXREALC.MyData
Dim myTXOPM As TXOPM.myData
Dim myTXINV As TXINV.myData
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkType As String
Dim WrkYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkFrozenFile As Boolean
Dim WrkPrintDist As Boolean

'Globals
Public WrkTown As String
Public WrkAssrPhone As String
Public WrkAccts As Integer
Public WrkM35GForms As Integer
Public WrkReduction As Decimal
Dim cMaxBenefit As Integer = 2000
	Public Sub PrtReport()

	myTXCOOQ = New TXCOOQ.mydata(MyDBConnect)
	myTXREAL = New TXREAL.mydata(MyDBConnect)
	myTXREALC = New TXREALC.mydata(MyDBConnect)
	myTXOPM = New TXOPM.mydata(MyDBConnect)
  myTXINV = New TXINV.mydata(MyDBConnect)

	With MyFrmTO104B
    WrkYear = MyUtils.CnvSng(.TxtGLYear.Text)
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
		If .TxtDist.Text = "" Then
			WrkDistAll = True
		End If
		WrkFrozenFile = False
		If .ChkFrozenFile.Checked Then
			WrkFrozenFile = True
		End If
	End With

	If ds.Tables.Count = 0 Then
		BuildDS()
	Else
		ds.Clear()
	End If

	GetOPMAssr()
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
    .Columns.Add("listno", Type.GetType("System.Int64"))
    .Columns.Add("name", Type.GetType("System.String"))
    .Columns.Add("proploc", Type.GetType("System.String"))
    .Columns.Add("taxcredit", Type.GetType("System.Decimal"))
  End With
  ds.Tables.Add(myTable)
End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim Counter As Integer
Dim WrkAnd As String
Dim WrkOr As String
Dim WrkPropLoc As String
Dim WrkProratePct As Decimal
Dim WrkProrated As Decimal
Dim WrkMonth As Integer
Dim WrkCCNo As Integer

If myDBConnect.ServerName = "DB2" Then
  WrkOr = " *or "
  WrkAnd = " *and "
Else
  WrkOr = " or "
  WrkAnd = " and "
 End If

WrkSort = "CONAM, LIST#"
WrkQry = "PCD='E'"
WrkM35GForms = 0
WrkAccts = 0
WrkReduction = 0
Counter = 0

myTXCOOQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
	myTXCOOQ.ReadQry()
	If Not myTXCOOQ.IsEOF Then
	With myTXCOOQ
		Counter = Counter + 1
		WrkPropLoc = ""
		If Not WrkFrozenFile Then
			myTXREAL.GetOneRecordP(._LISTNo)
			If Not myTXREAL.RecordNotFound Then
				With myTXREAL
'					If Trim(._FCCOD) <> "C" Then GoTo NextRec
					If Not WrkDistAll Then
						If ._DIST <> WrkDist Then GoTo NextRec
					End If
					WrkPropLoc = Trim(._LOCNO) & " " & Trim(._LOC)
				End With
			End If
		Else
			myTXREALC.GetOneRecordP(._LISTNo)
			If Not myTXREALC.RecordNotFound Then
				With myTXREALC
'					If Trim(._FCCOD) <> "C" Then GoTo NextRec
					If Not WrkDistAll Then
						If ._DIST <> WrkDist Then GoTo NextRec
					End If
					WrkPropLoc = Trim(._LOCNO) & " " & Trim(._LOC)
				End With
			End If
		End If

    myTXINV.GetOneRecordP(._LISTNo, WrkYear, "X")
    If Not myTXINV.RecordNotFound Then
      WrkCCNo = myTXINV._CCNO
    Else
      WrkCCNo = 0
    End If
    If WrkCCNo = 0 Then
      WrkMonth = Month(MyUtils.GetDBDate(._DATE))
      WrkProratePct = CalcPct(WrkMonth)
      WrkProrated = MyUtils.Round(._BENAMT * WrkProratePct, 2)
    Else
      WrkProrated = myTXINV._CCETAX
    End If
    If WrkProrated > 0 Then
      dr = ds.Tables(0).NewRow
      dr.Item("listno") = ._LISTNo
      dr.Item("name") = Trim(._CONAM)
      dr.Item("proploc") = WrkPropLoc
      dr.Item("taxcredit") = WrkProrated
      WrkAccts = WrkAccts + 1
      WrkReduction = WrkReduction + dr.Item("taxcredit")
      ds.Tables(0).Rows.Add(dr)
    End If
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
Application.DoEvents()
myTXCOOQ.CloseFile()

End Sub
Private Function CalcPct(ByVal Month As Integer) As Decimal
  Dim WrkPct As Decimal

  Select Case Month
  Case 1
    WrkPct = 0.75
  Case 2
    WrkPct = 0.667
  Case 3
    WrkPct = 0.583
  Case 4
    WrkPct = 0.5
  Case 5
    WrkPct = 0.417
  Case 6
    WrkPct = 0.333
  Case 7
    WrkPct = 0.25
  Case 8
    WrkPct = 0.167
  Case 9
    WrkPct = 0.083
  Case 10
    WrkPct = 1
  Case 11
    WrkPct = 0.917
  Case 12
    WrkPct = 0.833
  End Select

  Return WrkPct
End Function
Public Sub GetOPMAssr()

  Dim sb As StringBuilder = New StringBuilder

  WrkAssrPhone = ""
  WrkTown = ""
  myTXOPM.GetOneRecordP("A")
  If myTXOPM.RecordNotFound Then Exit Sub

  WrkAssrPhone = Format(myTXOPM._PHONE, "###-###-####")
  If myTXOPM._PHONEX > 0 Then
    WrkAssrPhone = WrkAssrPhone & " ext " & myTXOPM._PHONEX
  End If

	sb.Append(Trim(myTOWN._TOWN))
  sb.Append(",")
  sb.Append(Trim(myTXOPM._ADDR1))
  sb.Append(",")
  sb.Append(Trim(myTXOPM._CITY))
  sb.Append(",")
  sb.Append(Trim(myTXOPM._STATE))
  sb.Append(" ")
  sb.Append(Format(myTXOPM._ZIP, "00000"))
  If myTXOPM._ZIP4 > 0 Then
    sb.Append("-")
    sb.Append(Format(myTXOPM._ZIP4, "0000"))
  End If
  WrkTown = sb.ToString
  sb = Nothing

End Sub
End Module






