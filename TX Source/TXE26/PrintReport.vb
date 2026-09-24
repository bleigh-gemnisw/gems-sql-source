Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXHSTQ As TXHSTQ.myData
Dim myTXINV As TXINV.myData
Dim ds1 As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim dr As Data.DataRow
Dim dr2 As Data.DataRow

Dim WrkSortby As String
Dim WrkType As String
Dim WrkFromGLYear As Integer
Dim WrkToGLYear As Integer
Dim WrkFrom As Integer
Dim WrkTo As Integer
Dim WrkIncRegno As Boolean
Dim WrkSelection As String
Dim WrkListNo As Integer
Dim WrkCustID As Long
Dim WrkName As String
Dim WrkAnd As String
Dim WrkOr As String

Dim WrkTCount As Integer
Dim WrkTPrinPaid As Decimal
Dim WrkTFeePaid As Decimal
Dim WrkTIntPaid As Decimal
Dim WrkTLienPaid As Decimal
Public Sub PrtReport()

	myTXHSTQ = New TXHSTQ.mydata(MyDBConnect)
	myTXINV = New TXINV.mydata(MyDBConnect)

	With MyFrmTXE26B
		If .RbDateList.Checked Then WrkSortby = "DateList"
		If .RbDateName.Checked Then WrkSortby = "DateName"
		If .RbNameDate.Checked Then WrkSortby = "NameDate"
    WrkFromGLYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
    WrkToGLYear = MyUtils.CnvSng(.TxtToGLYear.Text)
    WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
    WrkIncRegno = .ChkRegno.Checked
    WrkListNo = MyUtils.CnvSng(.TxtListNo.Text)
    WrkCustID = MyUtils.CnvSng(.TxtCustID.Text)
		WrkName = .TxtName.Text
	End With

	If ds1.Tables.Count = 0 Then
		BuildDS()
	Else
		ds1.Clear()
		ds2.Clear()
		ClearTotals()
	End If

	GetDetail()

Done:
	MyCrViewer = New FrmCrViewer
	MyCrViewer.wrkds = ds1
	MyCrViewer.wrkds2 = ds2
	MyCrViewer.WrkListNo = WrkListNo
  MyCrViewer.WrkCustID = WrkCustID
	MyCrViewer.WrkName = WrkName
	MyCrViewer.Show()

End Sub

	Private Sub BuildDS()
		Dim myTable As New DataTable
		Dim myTable2 As New DataTable

		With myTable
			.TableName = "mytable"
			.Columns.Add("Sortby", Type.GetType("System.String"))
			.Columns.Add("ListNo", Type.GetType("System.Int32"))
			.Columns.Add("Type", Type.GetType("System.String"))
			.Columns.Add("Year", Type.GetType("System.Int32"))
			.Columns.Add("Name", Type.GetType("System.String"))
			.Columns.Add("PropDesc", Type.GetType("System.String"))
			.Columns.Add("Reference", Type.GetType("System.String"))
			.Columns.Add("PrinPaid", Type.GetType("System.Double"))
			.Columns.Add("FeePaid", Type.GetType("System.Double"))
			.Columns.Add("IntPaid", Type.GetType("System.Double"))
			.Columns.Add("LienPaid", Type.GetType("System.Double"))
			.Columns.Add("TotPaid", Type.GetType("System.Double"))
			.Columns.Add("DatePaid", Type.GetType("System.DateTime"))
		End With
		ds1.Tables.Add(myTable)

		With myTable2
			.TableName = "mytable2"
			.Columns.Add("TCount", Type.GetType("System.Int32"))
			.Columns.Add("TPrinPaid", Type.GetType("System.Double"))
			.Columns.Add("TFeePaid", Type.GetType("System.Double"))
			.Columns.Add("TIntPaid", Type.GetType("System.Double"))
			.Columns.Add("TLienPaid", Type.GetType("System.Double"))
			.Columns.Add("TTotPaid", Type.GetType("System.Double"))
		End With
		ds2.Tables.Add(myTable2)

	End Sub
Private Sub ClearTotals()
	WrkTCount = 0
	WrkTPrinPaid = 0
	WrkTFeePaid = 0
	WrkTIntPaid = 0
	WrkTLienPaid = 0
End Sub
Private Sub GetDetail()
Dim sb As StringBuilder
Dim WrkSort As String
Dim WrkQry As String
Dim WrkTypes As String
Dim WrkFamily As String
Dim SaveYear As Integer
Dim SaveType As String
Dim Counter As Integer

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

Counter = 0
WrkQry = "RCODE <> 'I'" & WrkAnd & "RCODE <>'V'" & WrkAnd & _
	"PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo

If WrkFromGLYear > 0 Then
	WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromGLYear _
	& WrkAnd & "YEAR <= " & WrkToGLYear
End If

If WrkListNo > 0 Then
  WrkQry = WrkQry & WrkAnd & "LIST#= " & WrkListNo
End If

MyTypes = MyFrmTXE26B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    SaveType = ""
WrkSort = "PDATE, LIST#"
myTXHSTQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
	myTXHSTQ.ReadQry()
	If Not myTXHSTQ.IsEOF Then
	With myTXHSTQ
		Counter = Counter + 1
		dr = ds1.Tables(0).NewRow
		If SaveType <> "" And SaveType <> ._TYPE Then
			WriteTotals(SaveYear, SaveType)
			ClearTotals()
		End If
		If SaveYear > 0 And SaveYear <> ._YEAR Then
			WriteTotals(SaveYear, SaveType)
			ClearTotals()
		End If
		SaveYear = ._YEAR
		SaveType = ._TYPE

		dr.Item("listno") = ._LISTNo
		dr.Item("year") = ._YEAR
		dr.Item("type") = ._TYPE
		dr.Item("prinpaid") = ._PAMT
		dr.Item("FeePaid") = ._PCAMT
		dr.Item("intpaid") = ._IAMT
		dr.Item("lienpaid") = ._LAMT
		dr.Item("totpaid") = ._PAMT + ._PCAMT + ._IAMT + ._LAMT
    dr.Item("datepaid") = MyUtils.GetDBDate(._PDATE)
		myTXINV.GetOneRecordP(._LISTNo, ._YEAR, ._TYPE)
		If Not myTXINV.RecordNotFound Then
			With myTXINV
				'Filter records based on selection
        If WrkCustID > 0 Then
          If WrkCustID <> ._SSNo And WrkCustID <> ._SS2 Then
            GoTo NextRec
          End If
        End If

				If WrkName <> "" Then
					If WrkName <> Trim(._NAME) Then
						GoTo NextRec
					End If
				End If

				dr.Item("name") = Trim(._NAME)
				WrkFamily = GetTXTypeFamily(._TYPE)
				Select Case WrkFamily
        Case "M", "S"
          If WrkIncRegno Then
            dr.Item("propdesc") = Trim(._MAKE) & " " & Trim(._MVYR) & " " & Trim(._IMVREG)
          Else
            dr.Item("propdesc") = Trim(._MAKE) & " " & Trim(._MVYR)
          End If
        Case Else
          dr.Item("propdesc") = Trim(._LOCNo) & " " & ._LOC
        End Select
			End With
		Else
      If WrkCustID > 0 Or WrkName <> "" Then GoTo NextRec
		End If

		sb = New StringBuilder
		Select Case WrkSortby
		Case "DateList"
			sb.Append(._PDATE)
			sb.Append(._LISTNo)
		Case "DateName"
			sb.Append(._PDATE)
			sb.Append(dr.Item("name"))
		Case "NameDate"
			sb.Append(dr.Item("name"))
			sb.Append(._PDATE)
		End Select
		dr.Item("sortby") = sb.ToString
		sb = Nothing
		WrkTPrinPaid = WrkTPrinPaid + ._PAMT
		WrkTFeePaid = WrkTFeePaid + ._PCAMT
		WrkTIntPaid = WrkTIntPaid + ._IAMT
		WrkTLienPaid = WrkTLienPaid + ._LAMT
	End With
	WrkTCount = WrkTCount + 1
	ds1.Tables(0).Rows.Add(dr)

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

WriteTotals(SaveYear, SaveType)
myFrmProgress.Close()

CloseFiles:
myTXHSTQ.CloseFile()
myTXINV.CloseFile()

End Sub
Private Sub WriteTotals(ByVal SaveYear As Integer, ByVal SaveType As String)
	If WrkTCount = 0 Then Exit Sub

	dr2 = ds2.Tables(0).NewRow
	dr2.Item("tcount") = WrkTCount
	dr2.Item("tprinpaid") = WrkTPrinPaid
	dr2.Item("tFeePaid") = WrkTFeePaid
	dr2.Item("tintpaid") = WrkTIntPaid
	dr2.Item("tlienpaid") = WrkTLienPaid
	dr2.Item("ttotpaid") = WrkTPrinPaid + WrkTFeePaid + WrkTIntPaid + WrkTLienPaid
	ds2.Tables(0).Rows.Add(dr2)
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

End Module






