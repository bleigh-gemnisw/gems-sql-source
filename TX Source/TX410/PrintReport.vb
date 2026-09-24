Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALCQ As TXREALCQ.MyData
Dim myTXREALC As TXREALC.MyData

Dim ds As DataSet = New DataSet
Dim DsTXREALC As DataSet = New DataSet
Dim dr As Data.DataRow
  'Screen fields
  Dim WrkBankCd As String
  Dim WrkBankSvc As String
  Dim WrkBankCd2 As String
  Dim WrkRemove As Boolean
  Dim WrkPost As Boolean
  Public Sub PrtReport()

	myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)
	myTXREALC = New TXREALC.mydata(MyDBConnect)

    WrkRemove = False
    WrkPost = False
    With MyFrmTX410B
      WrkBankCd = .TxtBankCd.Text
      WrkBankSvc = .TxtBankSvc.Text
      WrkBankCd2 = .TxtBankCd2.Text
      If .RbRemove.Checked Then WrkRemove = True
      If .ChkPost.Checked Then WrkPost = True
    End With

	If ds.Tables.Count = 0 Then
		BuildDS()
	Else
		ds.Clear()
	End If

	GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.WrkBankCd = WrkBankCd
    MyCrViewer.WrkBankSvc = WrkBankSvc
    MyCrViewer.WrkBankCd2 = WrkBankCd2
    MyCrViewer.WrkPost = WrkPost
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Bankcd", Type.GetType("System.String"))
      .Columns.Add("BankSvc", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim I As Integer
    Dim WrkAnd As String
    Dim WrkOr As String

    If myDBConnect.ServerName = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkSort = "NAME"
    If WrkRemove Then
      WrkQry = "BKCD<>''" & WrkOr & "BKSV<>''"
    Else
      WrkQry = "BKCD=" & MyUtils.Quo(WrkBankCd)
    End If

    DsTXREALC = myTXREALCQ.GetQry(WrkSort, WrkQry, 0)
    If DsTXREALC.Tables(0).Rows.Count = 0 Then Exit Sub
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    If DsTXREALC.Tables(0).Rows.Count = 0 Then Exit Sub

    For I = 0 To (DsTXREALC.Tables(0).Rows.Count - 1)
      If MyReportCancel Then Exit Sub
      With DsTXREALC.Tables(0).Rows(I)
        'Filter Bank Code 
        If WrkRemove And WrkBankCd <> "" Then
          If WrkBankCd <> .Item("bkcd") Then Continue For
        End If
        'Filter Bank Service 
        If WrkRemove And WrkBankSvc <> "" Then
          If WrkBankSvc <> .Item("bksv") Then Continue For
        End If
        dr = ds.Tables(0).NewRow
        dr.Item("listno") = .Item("list#")
        dr.Item("name") = .Item("name")
        dr.Item("bankcd") = .Item("bkcd")
        dr.Item("banksvc") = .Item("bksv")
      End With
      ds.Tables(0).Rows.Add(dr)

      If WrkPost Then
        UpdateTXREALC(DsTXREALC.Tables(0).Rows(I).Item("list#"))
      End If

NextRec:
      With myFrmProgress
        If DsTXREALC.Tables(0).Rows.Count > 1 Then
          WrkPct = ((I + 1) / DsTXREALC.Tables(0).Rows.Count) * 100
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
    myTXREALCQ.CloseFile()
    myTXREALC.CloseFile()

  End Sub
Private Sub UpdateTXREALC(ByVal List As Integer)

    myTXREALC.GetOneRecordP(List)
    If Not myTXREALC.RecordNotFound Then
      With myTXREALC
        If WrkRemove Then
          ._BKCD = ""
          ._BKSV = ""
        Else
          ._BKCD = WrkBankCd2
        End If
        .UpdateOneRecordP()
      End With
    End If
End Sub
End Module






