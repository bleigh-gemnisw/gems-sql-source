Imports System.io
Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALC As TXREALC.myData

Dim ds As DataSet = New DataSet
Dim dr As DataRow
Dim wrklistno As Int32
Dim WrkBankcd As String
Dim WrkBankSvc As String
Dim wrkerrorcount As Int32
Dim wrkcount As Int32
Dim wrkname As String
Dim Wrkpost As Boolean
	Public Sub PrtReport()
	myTXREALC = New TXREALC.mydata(MyDBConnect)
	With MyFrmTX802B
    WrkBankSvc = .TxtBankSv.Text
    WrkBankcd = .TxtBankCd.Text
		Wrkpost = .Chkpost.Checked
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
		.wrkcount = wrkcount
		.wrkerrorcount = wrkerrorcount
		.Wrkpost = Wrkpost
		.Show()
	End With

	End Sub
Public Sub BuildDs(ByRef Ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
			.Columns.Add("Bksv", Type.GetType("System.String"))
			.Columns.Add("Bkcd", Type.GetType("System.String"))
      .Columns.Add("bname", Type.GetType("System.String"))
  End With
  Ds.Tables.Add(myTable)
End Sub
  Private Sub GetDetail()
    Dim WrkStream As FileStream = New FileStream(MyFrmTX802B.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim I As Integer

    Dim WrkCode As String
    Dim WrkRecNo As Integer
    Dim Good As Boolean

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    WrkRecNo = 0
    wrkcount = 0
    wrkerrorcount = 0

NextLine:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo End_of_file
      Exit Sub
    End If

    WrkRecNo = WrkRecNo + 1
    I = I + strBuffer.Length

    Good = CheckNumeric(Mid(strBuffer, 1, 6))
    If Not Good Then
      MsgBox("Record # " & WrkRecNo & " is not valid", MsgBoxStyle.Critical, "Processing has been stopped")
      GoTo End_of_file
    End If

    If MyList7 Then
      wrklistno = Mid(strBuffer, 1, 7)
      WrkCode = Mid(strBuffer, 8, 2)
    Else
      wrklistno = Mid(strBuffer, 1, 6)
      WrkCode = Mid(strBuffer, 7, 2)
    End If

    myTXREALC.GetOneRecordP(wrklistno)
    If Not myTXREALC.RecordNotFound Then
      wrkcount = wrkcount + 1
      With myTXREALC
        If WrkBankcd <> String.Empty Then
          ._BKCD = WrkBankcd
        Else
          ._BKCD = WrkCode
        End If
        ._BKSV = WrkBankSvc
        wrkname = Trim(._NAME)
      End With
      If Wrkpost = True Then
        myTXREALC.UpdateOneRecordP()
        If myTXREALC.ErrMsg <> "" Then
          WriteErrorLog(myTXREALC.ErrMsg)
          Exit Sub
        End If
      End If
    Else
      wrkerrorcount = wrkerrorcount + 1
      wrkname = "*** Not Found ***"
    End If

    dr = ds.Tables(0).NewRow
    dr.Item("listno") = wrklistno
    dr.Item("name") = wrkname
    If WrkBankcd <> String.Empty Then
      dr.Item("bkcd") = WrkBankcd
      dr.Item("bname") = GetTXBanksDesc(WrkBankcd)
    Else
      dr.Item("bkcd") = WrkCode
      dr.Item("bname") = GetTXBanksDesc(WrkCode)
    End If
    ds.Tables(0).Rows.Add(dr)

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

End_of_file:
    sr.Close()
    myFrmProgress.Close()

  End Sub
  Private Function CheckNumeric(ByVal Str As String) As Boolean
  Dim Good As Boolean

  If IsNumeric(Str) Then Good = True

  Return Good
End Function
End Module






