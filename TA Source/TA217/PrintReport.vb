Module PrintReport
Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALQ As TXREALQ.myData
Dim myTXREALCQ As TXREALCQ.myData
Dim DsTXREAL As DataSet = New DataSet
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkSortby As String
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkPrintDist As Boolean
Dim WrkFrozenFile As Boolean

Dim WrkCode(6) As Integer

  Public Sub PrtReport()

	myTXREALQ = New TXREALQ.mydata(MyDBConnect)
	myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)

  With MyFrmTA217B
    If .RbDist.Checked Then
      WrkSortby = "Dist"
    End If
    If .RbMap.Checked Then
      WrkSortby = "Map"
    End If
    If .RbMapDetail.Checked Then
      WrkSortby = "MapDetail"
    End If
    If .RbLoc.Checked Then
      WrkSortby = "Loc"
    End If
    If .RbName.Checked Then
      WrkSortby = "Name"
    End If
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    If .TxtDist.Text = "" Then
      WrkDistAll = True
    End If
    WrkPrintDist = False
    If .ChkPrtDist.Checked Then
      WrkPrintDist = True
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

  GetDetail()

  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .wrkds = ds
    .wrksortby = WrkSortby
    .WrkDist = WrkDist
    .WrkPrintDist = WrkPrintDist
    .Show()
  End With
  End Sub
Friend Sub BuildDS()
  Dim myTable As New DataTable

  With myTable
    .TableName = "mytable"
    .Columns.Add("listno", Type.GetType("System.Int64"))
    .Columns.Add("dist", Type.GetType("System.Int64"))
    .Columns.Add("name", Type.GetType("System.String"))
    .Columns.Add("add1", Type.GetType("System.String"))
    .Columns.Add("city", Type.GetType("System.String"))
    .Columns.Add("state", Type.GetType("System.String"))
    .Columns.Add("zip", Type.GetType("System.String"))
    .Columns.Add("locno", Type.GetType("System.String"))
    .Columns.Add("loc", Type.GetType("System.String"))
    .Columns.Add("map", Type.GetType("System.String"))
    .Columns.Add("vol", Type.GetType("System.String"))
    .Columns.Add("pge", Type.GetType("System.String"))
    .Columns.Add("purdate", Type.GetType("System.String"))
    .Columns.Add("gross", Type.GetType("System.Int64"))
    .Columns.Add("net", Type.GetType("System.Int64"))
  End With
  ds.Tables.Add(myTable)
End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim I As Integer
Dim WrkAnd As String
Dim WrkOr As String

If myDBConnect.ServerAS400 Then
  WrkOr = " *or "
  WrkAnd = " *and "
Else
  WrkOr = " or "
  WrkAnd = " and "
 End If

WrkSort = ""
Select Case WrkSortby
Case "Dist"
  WrkSort = "DIST, LOC, LOC#, NAME"
Case "Map", "MapDetail"
  WrkSort = "MAP, NAME, LIST#"
Case "Loc"
  WrkSort = "LOC, LOC#, NAME"
Case "Name"
  WrkSort = "NAME, LOC, LOC#"
End Select
WrkQry = ""
If Not WrkDistAll Then
  If Not WrkPrintDist Then
    WrkQry = "dist=" & WrkDist
  Else
    WrkQry = "pdst=" & WrkDist
  End If
End If

If Not WrkFrozenFile Then
	DsTXREAL = myTXREALQ.GetQry(WrkSort, WrkQry, 0)
Else
	DsTXREAL = myTXREALCQ.GetQry(WrkSort, WrkQry, 0)
End If
If DsTXREAL.Tables(0).Rows.Count = 0 Then
	If Not WrkFrozenFile Then
		myTXREALQ.CloseFile()
	Else
		myTXREALCQ.CloseFile()
	End If
	Exit Sub
End If

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

For I = 0 To (DsTXREAL.Tables(0).Rows.Count - 1)
  With DsTXREAL.Tables(0).Rows(I)
    WrkCode(0) = .Item("code1")
    WrkCode(1) = .Item("code2")
    WrkCode(2) = .Item("code3")
    WrkCode(3) = .Item("code4")
    WrkCode(4) = .Item("code5")
    WrkCode(5) = .Item("code6")
    WrkCode(6) = .Item("code7")

    dr = ds.Tables(0).NewRow
    dr.Item("listno") = .Item("list#")
    If WrkPrintDist Then
      WrkDist = .Item("pdst")
    Else
      WrkDist = .Item("dist")
    End If
    dr.Item("dist") = WrkDist
    dr.Item("name") = .Item("name")
    dr.Item("add1") = .Item("add1")
    dr.Item("city") = .Item("city")
    dr.Item("state") = .Item("state")
    If .Item("zip5") > 0 Then
      dr.Item("zip") = Format(.Item("zip5"), "00000")
    Else
      dr.Item("zip") = ""
    End If
    dr.Item("locno") = .Item("loc#")
    dr.Item("loc") = .Item("loc")
    dr.Item("map") = .Item("map")
    dr.Item("vol") = .Item("vol")
    dr.Item("pge") = .Item("pge")
    dr.Item("purdate") = Format(MyUtils.GetDBDate(.Item("purdt")), "M/dd/yyyy")
    dr.Item("gross") = .Item("gross")
    dr.Item("net") = .Item("net")
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
End Module






