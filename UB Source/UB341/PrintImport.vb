Imports System.io
Imports System.Text
Module PrintImport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer

Dim myUTCUST As UTCUST.myData

Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkPost As Boolean
Dim WrkAnd As String
Dim WrkOr As String
	Public Sub PrtImport()

	myUTCUST = New UTCUST.mydata(MyDBConnect)

	With MyFrmUB341B
		WrkPost = .ChkPost.Checked
	End With

	If ds.Tables.Count = 0 Then
		BuildDs(ds)
	Else
		ds.Clear()
	End If

	GetDetail()

Done:
	MyCrViewer = New FrmCrViewer
	With MyCrViewer
		.wrkds = ds
		.WrkDist = 0
		.WrkExport = False
		.WrkPost = WrkPost
		.Show()
	End With

	End Sub
  Private Sub GetDetail()
    Dim WrkStream As FileStream = New FileStream(MyFrmUB341B.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim WrkAcct As Integer
    Dim WrkUnits As Decimal
    Dim SArray() As String

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length

NextLine:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo Cleanup
    End If

    SArray = Parse(strBuffer, ",")
    I = I + strBuffer.Length
    WrkAcct = MyUtils.CnvSng(SArray(0))
    If WrkAcct = 0 Then GoTo NextRec
    myUTCUST.GetOneRecordP(WrkAcct)

    With myUTCUST
      If .RecordNotFound Then Exit Sub
      WrkUnits = MyUtils.CnvSng(SArray(10))
      dr = ds.Tables(0).NewRow
      dr.Item("listno") = WrkAcct
      dr.Item("name") = Trim(._CUNAM1)
      dr.Item("location") = Trim(._CULOCNO) & " " & Trim(._CULOC)
      dr.Item("dist") = ._CUDST
      dr.Item("ratecd") = String.Empty 'Trim(myUTCUSTRT._CRCODE)
      dr.Item("units") = WrkUnits
      ds.Tables(0).Rows.Add(dr)
      dr = Nothing

      If WrkPost Then
        With myUTCUST
          ._CUUNIT = WrkUnits
          .UpdateOneRecordP()
        End With
      End If
    End With

NextRec:
    With myFrmProgress
      WrkPct = (I / WrkFileSize) * 100
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo NextLine

Cleanup:
    sr.Close()
    myFrmProgress.Close()

  End Sub
End Module






