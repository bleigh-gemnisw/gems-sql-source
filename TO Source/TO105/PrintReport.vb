Module PrintReport
Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALQ As TXREALQ.MyData
Dim myTXREALCQ As TXREALCQ.myData
Dim DsTXREAL As DataSet = New DataSet
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow

'Mill Rate
Public MrateMillrt As Double

Dim WrkType As String
Dim WrkYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkFrozenFile As Boolean
Dim WrkPrintDist As Boolean

Dim WrkExcd(6) As String
Dim WrkExam(6) As Integer

Dim cMaxBenefit As Integer = 2000
  Public Sub PrtReport()

	myTXREALQ = New TXREALQ.mydata(MyDBConnect)
	myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)

  With MyFrmTO105B
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

  GetMillRate(WrkYear, "R", WrkDist)
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
    .Columns.Add("year", Type.GetType("System.Int64"))
    .Columns.Add("code", Type.GetType("System.String"))
    .Columns.Add("netass", Type.GetType("System.Int64"))
    .Columns.Add("tax", Type.GetType("System.Decimal"))
    .Columns.Add("frztax", Type.GetType("System.Decimal"))
    .Columns.Add("taxcredit", Type.GetType("System.Decimal"))
  End With
  ds.Tables.Add(myTable)
End Sub
Private Sub GetDetail()
Dim WrkGross As Integer
Dim WrkTotExam As Integer
Dim WrkNet As Integer
Dim WrkBenefit As Decimal
Dim WrkSort As String
Dim WrkQry As String
Dim I As Integer
Dim J As Integer
Dim WrkAnd As String
Dim WrkOr As String

If myDBConnect.ServerName = "DB2" Then
  WrkOr = " *or "
  WrkAnd = " *and "
Else
  WrkOr = " or "
  WrkAnd = " and "
 End If

WrkSort = "NAME, LIST#"
WrkQry = "CAT='1'" & WrkAnd & "FCCOD='F'"
If Not WrkDistAll Then
  WrkQry = "dist=" & WrkDist
End If
If Not WrkFrozenFile Then
  DsTXREAL = myTXREALQ.GetQry(WrkSort, WrkQry, 0)
Else
  DsTXREAL = myTXREALCQ.GetQry(WrkSort, WrkQry, 0)
End If

If DsTXREAL.Tables(0).Rows.Count = 0 Then Exit Sub

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

For I = 0 To (DsTXREAL.Tables(0).Rows.Count - 1)
	With DsTXREAL.Tables(0).Rows(I)
		If .Item("ccno") > 0 Then
			WrkGross = .Item("ccgrs")
			WrkExcd(0) = .Item("cccd1")
			WrkExcd(1) = .Item("cccd2")
			WrkExcd(2) = .Item("cccd3")
			WrkExcd(3) = .Item("cccd4")
			WrkExcd(4) = .Item("cccd5")
			WrkExcd(4) = .Item("cccd5")
			WrkExcd(5) = .Item("cccd6")
			WrkExcd(6) = .Item("cccd7")
			WrkExam(0) = .Item("cexa1")
			WrkExam(1) = .Item("cexa2")
			WrkExam(2) = .Item("cexa3")
			WrkExam(3) = .Item("cexa4")
			WrkExam(4) = .Item("cexa5")
			WrkExam(5) = .Item("cexa6")
			WrkExam(6) = .Item("cexa7")
		Else
			WrkGross = .Item("gross") + .Item("btr")
			WrkExcd(0) = .Item("excd1")
			WrkExcd(1) = .Item("excd2")
			WrkExcd(2) = .Item("excd3")
			WrkExcd(3) = .Item("excd4")
			WrkExcd(4) = .Item("excd5")
			WrkExcd(4) = .Item("excd5")
			WrkExcd(5) = .Item("excd6")
			WrkExcd(6) = .Item("excd7")
			WrkExam(0) = .Item("exam1")
			WrkExam(1) = .Item("exam2")
			WrkExam(2) = .Item("exam3")
			WrkExam(3) = .Item("exam4")
			WrkExam(4) = .Item("exam5")
			WrkExam(5) = .Item("exam6")
			WrkExam(6) = .Item("exam7")
		End If

		WrkTotExam = 0
		For J = 0 To 6
			WrkTotExam = WrkTotExam + WrkExam(J)
		Next J
		WrkNet = WrkGross - WrkTotExam

		dr = ds.Tables(0).NewRow
		dr.Item("listno") = .Item("list#")
		dr.Item("name") = .Item("name")
		dr.Item("proploc") = .Item("loc#") & " " & .Item("loc")
		dr.Item("year") = .Item("fcyr")
		dr.Item("code") = "F"
		dr.Item("netass") = WrkNet
    dr.Item("tax") = MyUtils.Round(WrkNet * MrateMillrt, 2)
		dr.Item("frztax") = .Item("ftax")
		WrkBenefit = dr.Item("tax") - dr.Item("frztax")
		If WrkBenefit > cMaxBenefit Then
			dr.Item("taxcredit") = cMaxBenefit
		Else
			dr.Item("taxcredit") = WrkBenefit
		End If
		ds.Tables(0).Rows.Add(dr)
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

myFrmProgress.Close()
Application.DoEvents()
myTXREALQ.CloseFile()
myTXREALCQ.CloseFile()

End Sub
Public Sub GetMillRate(ByVal WrkGLYear As Integer, ByVal WrkType As String, ByVal WrkDist As Integer)
Dim myTXMRATE As TXMRATE.myData

myTXMRATE = New TXMRATE.mydata(MyDBConnect)
myTXMRATE.GetOneRecordP(WrkGLYear, WrkType, WrkDist)
If myTXMRATE.RecordNotFound Then
  myTXMRATE.GetOneRecordP(WrkGLYear, "", WrkDist)
End If
If Not myTXMRATE.RecordNotFound Then
  With myTXMRATE
    MrateMillrt = ._MRRATE
  End With
End If
myTXMRATE.CloseFile()
End Sub

End Module






