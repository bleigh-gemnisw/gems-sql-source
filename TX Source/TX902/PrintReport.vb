Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINVQ As TXINVQ.MyData
Dim myBCHHDR As BCHHDR.MyData
Dim myTSPBCH As TSPBCH.MyData

Dim ds As DataSet = New DataSet
Dim dr As DataRow

'General
Dim WrkAnd As String
Dim WrkOr As String
Dim WrkBatchNo As Integer
Dim WrkStatus1 As String
Dim WrkStatus2 As String
Dim WrkStatus3 As String
Dim WrkStatus4 As String
Dim WrkPostDate As Date
Dim WrkMail As Boolean
Dim WrkSusp As String
Dim WrkSortBy As String
  Public Sub PrtReport()

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myTSPBCH = New TSPBCH.MyData(myDBConnect)

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
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Balance", Type.GetType("System.Decimal"))
      .Columns.Add("lastpaiddt", Type.GetType("System.DateTime"))
    End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()
Dim WrkType As String
Dim WrkFromYear As Integer
Dim WrkToYear As Integer
Dim WrkCreateBatch As Boolean
Dim Counter As Integer
Dim WrkQry As String
Dim WrkSort As String
Dim WrkTypes As String
Dim Good As Boolean
Const CBatchType As String = "PTS"

With MyFrmTX902B
  WrkType = .TxtTypes.Text
  WrkFromYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
  WrkToYear = MyUtils.CnvSng(.TxtToGLYear.Text)
  MyTypes = .TxtTypes.Text
  WrkStatus1 = .TxtStatus1.Text
  WrkStatus2 = .TxtStatus2.Text
  WrkStatus3 = .TxtStatus3.Text
  WrkStatus4 = .TxtStatus4.Text
  WrkPostDate = .DtPckPost.Value
  WrkMail = .ChkMail.Checked
  WrkSusp = .TxtSusp.Text
  WrkCreateBatch = .ChkBatch.Checked
  If .RbSortYear.Checked Then
    WrkSortBy = "Year"
  End If
  If .RbSortName.Checked Then
    WrkSortBy = "Name"
  End If
End With

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

Counter = 0
WrkSort = "'"
Select Case WrkSortBy
Case "Year"
  WrkSort = "YEAR, TYPE"
Case "Name"
  WrkSort = "NAME"
End Select

WrkQry = "icode<>'I'" & WrkAnd & "BALD > 0" & WrkAnd & "SUSDT=0"
If WrkMail Then
  WrkQry = WrkQry & WrkAnd & "ICODE='M'"
End If
If WrkFromYear > 0 Then
  WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromYear _
  & WrkAnd & "YEAR <= " & WrkToYear
End If

    MyTypes = MyFrmTX902B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    myTXINVQ.OpenQry(WrkSort, WrkQry)
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

If WrkCreateBatch Then
  WrkBatchNo = myBCHHDR.AutoGenKey(CBatchType)
	myBCHHDR.GetOneRecordP(CBatchType, WrkBatchNo)
End If

ReadNext:
	myTXINVQ.ReadQry()
	If Not myTXINVQ.IsEOF Then
	With myTXINVQ
		Counter = Counter + 1
		Good = False
		'Filter - Include Status Codes
		If WrkStatus1 <> String.Empty Then
			If Trim(._STCD1) = WrkStatus1 Then Good = True
			If Trim(._STCD2) = WrkStatus1 Then Good = True
			If Trim(._STCD3) = WrkStatus1 Then Good = True
			If Trim(._STCD4) = WrkStatus1 Then Good = True
			If Trim(._STCD5) = WrkStatus1 Then Good = True
		End If
		If Not Good And WrkStatus2 <> String.Empty Then
			If Trim(._STCD1) = WrkStatus2 Then Good = True
			If Trim(._STCD2) = WrkStatus2 Then Good = True
			If Trim(._STCD3) = WrkStatus2 Then Good = True
			If Trim(._STCD4) = WrkStatus2 Then Good = True
			If Trim(._STCD5) = WrkStatus2 Then Good = True
		End If
		If Not Good And WrkStatus3 <> String.Empty Then
			If Trim(._STCD1) = WrkStatus3 Then Good = True
			If Trim(._STCD2) = WrkStatus3 Then Good = True
			If Trim(._STCD3) = WrkStatus3 Then Good = True
			If Trim(._STCD4) = WrkStatus3 Then Good = True
			If Trim(._STCD5) = WrkStatus3 Then Good = True
		End If
		If Not Good And WrkStatus4 <> String.Empty Then
			If Trim(._STCD1) = WrkStatus4 Then Good = True
			If Trim(._STCD2) = WrkStatus4 Then Good = True
			If Trim(._STCD3) = WrkStatus4 Then Good = True
			If Trim(._STCD4) = WrkStatus4 Then Good = True
			If Trim(._STCD5) = WrkStatus4 Then Good = True
		End If
		If WrkStatus1 = String.Empty And WrkStatus2 = String.Empty And WrkStatus3 = String.Empty And WrkStatus4 = String.Empty Then
			Good = True
		End If
		If Not Good Then GoTo NextRec

		dr = ds.Tables(0).NewRow
		dr.Item("listno") = ._LISTNo
		dr.Item("year") = ._YEAR
		dr.Item("type") = GetTXTypeDesc(._TYPE)
		dr.Item("name") = Trim(._NAME)
		dr.Item("balance") = ._BALD
	End With
	ds.Tables(0).Rows.Add(dr)

	If WrkCreateBatch Then
		CreateBatch()
	End If

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

If WrkCreateBatch Then
	With myBCHHDR
		._APPID = CBatchType
		._BCHNO = WrkBatchNo
		._ORGUS = "NET-TX902"
		._STATS = "S"
		._SUBST = "S"
    ._PSDT = MyUtils.SetDBDate(WrkPostDate)
		.AddOneRecordP()
	End With
	myBCHHDR.GetOneRecordP(CBatchType, 0)
	If Not myBCHHDR.RecordNotFound Then
		With myBCHHDR
			._LSBCH = WrkBatchNo
			.UpdateOneRecordP()
		End With
	Else
		With myBCHHDR
			._APPID = CBatchType
			._BCHNO = 0
			._LSBCH = WrkBatchNo
			.AddOneRecordP()
		End With
	End If
End If

myFrmProgress.Close()
myTXINVQ.CloseFile()

End Sub
  Private Function BuildSelectTypes() As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim StrLen As Integer
    Dim I As Integer

    If MyTypes = "" Then
      Return ""
    End If

    sbSelect = New System.Text.StringBuilder
    sbSelect.Append("TYPE=%Values(")
    StrLen = Len(MyTypes)

    For I = 1 To StrLen
      WrkType = Mid(MyTypes, I, 1)
      sbSelect.Append(Chr(34) & WrkType & Chr(34) & " ")
    Next

    sbSelect.Append(")")
    Return sbSelect.ToString
  End Function
  Private Function BuildSelectQryPC(ByVal WrkStrIn As String, ByVal WrkSelTypes As String) As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim WrkStrOut As String
    Dim StrLen As Integer
    Dim I As Integer

    WrkStrOut = ""
    If WrkSelTypes = "" Then
      Return ""
    End If

    StrLen = Len(WrkSelTypes)
    sbSelect = New System.Text.StringBuilder
    For I = 1 To StrLen
      If I > 1 Then
        sbSelect.Append(",")
      End If
      WrkType = Mid(WrkSelTypes, I, 1)
      sbSelect.Append(MyUtils.Quo(WrkType))
    Next
    If WrkStrIn = "" Then
      WrkStrOut = "TYPE IN(" & sbSelect.ToString & ")"
    Else
      WrkStrOut = WrkStrIn & WrkAnd & "TYPE IN(" & sbSelect.ToString & ")"
    End If
    sbSelect = Nothing
    Return WrkStrOut
  End Function
  Private Sub CreateBatch()

    With myTSPBCH
      .GetOneRecordP(WrkBatchNo, myTXINVQ._LISTNo, myTXINVQ._YEAR, myTXINVQ._TYPE)
      ._BCHNO = WrkBatchNo
      ._LISTNo = myTXINVQ._LISTNo
      ._YEAR = myTXINVQ._YEAR
      ._TYPE = myTXINVQ._TYPE
      ._DIST = 0
      ._COMM = ""
      ._SCD = WrkSusp
      ._PDATE = 0
      ._NAME = Trim(myTXINVQ._NAME)
      ._TAXT = myTXINVQ._BALD
      .AddOneRecordP()
    End With

  End Sub
End Module






