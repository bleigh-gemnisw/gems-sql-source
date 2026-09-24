Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINVQ As TXINVQ.myData
Dim myBCHHDR As BCHHDR.myData
Dim myTCRBCH As TCRBCH.myData

Dim ds As DataSet = New DataSet
Dim DsTXINV As DataSet = New DataSet
Dim dr As DataRow

'General
Dim WrkAnd As String
Dim WrkOr As String
Dim WrkBatchNo As Integer
Dim WrkSortBy As String
  Public Sub PrtReport()

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myTCRBCH = New TCRBCH.MyData(myDBConnect)

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.WrkBatchNo = WrkBatchNo
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
			.Columns.Add("Over", Type.GetType("System.Decimal"))
			.Columns.Add("Under", Type.GetType("System.Decimal"))
			.Columns.Add("LastPaidDt", Type.GetType("System.DateTime"))
    End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()
Dim WrkType As String
Dim WrkFromYear As Integer
Dim WrkToYear As Integer
Dim WrkUnder As Decimal
Dim WrkOver As Decimal
Dim WrkListNo As Integer
Dim WrkCreateBatch As Boolean
Dim WrkQry As String
Dim SaveQry As String
Dim WrkSort As String
Dim Counter As Integer
Dim WrkTypes As String
Const CBatchType As String = "PTC"

With MyFrmTXA05B
  WrkType = .TxtTypes.Text
  WrkFromYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
  WrkToYear = MyUtils.CnvSng(.TxtToGLYear.Text)
  MyTypes = .TxtTypes.Text
  WrkUnder = MyUtils.CnvSng(.TxtUnder.Text)
  WrkOver = MyUtils.CnvSng(.TxtOver.Text)
  WrkListNo = MyUtils.CnvSng(.TxtListNo.Text)
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

WrkQry = "icode<>'I'" & WrkAnd & "TXIDT > 0" & WrkAnd & "BALD <> 0"
If WrkFromYear > 0 And WrkListNo = 0 Then
  WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromYear _
  & WrkAnd & "YEAR <= " & WrkToYear
End If
If WrkFromYear > 0 And WrkListNo > 0 Then
  WrkQry = WrkQry & WrkAnd & "YEAR = " & WrkFromYear & WrkAnd & "LIST#=" & WrkListNo
End If
SaveQry = WrkQry
If WrkUnder > 0 And WrkOver = 0 Then
  WrkQry = SaveQry & WrkAnd & "BALD > 0" & WrkAnd & "BALD <= " & WrkUnder
End If
If WrkOver > 0 And WrkUnder = 0 Then
  WrkQry = SaveQry & WrkAnd & "BALD < 0" & WrkAnd & "BALD >= " & (WrkOver * -1)
End If
If WrkOver > 0 And WrkUnder > 0 Then
	WrkQry = SaveQry & WrkAnd & "BALD <= " & WrkUnder & WrkAnd & "BALD >= " & (WrkOver * -1)
End If

MyTypes = MyFrmTXA05B.TxtTypes.Text
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
		dr = ds.Tables(0).NewRow
		dr.Item("listno") = ._LISTNo
		dr.Item("year") = ._YEAR
		dr.Item("type") = GetTXTypeDesc(._TYPE)
		dr.Item("name") = Trim(._NAME)
		dr.Item("balance") = ._BALD
		If ._BALD > 0 Then
			dr.Item("over") = ._BALD
		Else
			dr.Item("under") = ._BALD
		End If
    dr.Item("lastpaiddt") = MyUtils.GetDBDate(._TXIDT)
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
    ._SUBST = "M"
		._ORGUS = "NET-TXA05"
		._STATS = "S"
    ._PSDT = MyUtils.SetDBDate(Date.Today)
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
    Dim WrkTrnbr As Integer

    With myTCRBCH
      WrkTrnbr = .AutoGenKey(WrkBatchNo)
      .GetOneRecordP(WrkBatchNo, WrkTrnbr)
      ._BCHNO = WrkBatchNo
      ._TRNBR = WrkTrnbr
      ._RDTE = MyUtils.SetDBDate(Date.Today)
      ._LISTNo = myTXINVQ._LISTNo
      ._YEAR = myTXINVQ._YEAR
      ._TYPE = myTXINVQ._TYPE
      ._NAME = myTXINVQ._NAME
      ._PAMT = myTXINVQ._BALD
      ._ADJ = ""
      If ._PAMT < 0 Then
        ._ADJ = "A"
      End If
      ._IAMT = 0
      ._LAMT = 0
      ._REF = ""
      ._COMM = "Penny Batch"
      ._PMETH = ""
      ._SRC = 0
      .AddOneRecordP()
    End With

  End Sub
End Module






