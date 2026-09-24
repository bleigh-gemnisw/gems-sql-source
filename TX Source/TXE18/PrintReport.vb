Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXHSTQ As TXHSTQ.myData
Dim myTXINV As TXINV.myData
Dim ds As DataSet = New DataSet
Dim dsTot As DataSet = New DataSet
Dim DsTXHST As DataSet = New DataSet
Dim dr As Data.DataRow
Dim drTot As Data.DataRow

Dim WrkType As String
Dim WrkFrom As Integer
Dim WrkTo As Integer
Dim WrkFromCode As String
Dim WrkToCode As String
Dim WrkDetail As Boolean
Dim WrkAnd As String
Dim WrkOr As String

Dim WrkTCount As Integer
Dim WrkTFeePaid As Decimal
Public Sub PrtReport()

	myTXHSTQ = New TXHSTQ.mydata(MyDBConnect)
	myTXINV = New TXINV.mydata(MyDBConnect)

	With MyFrmTXE18B
    WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
		WrkFromCode = .TxtFromCode.Text
		WrkToCode = .TxtToCode.Text
		WrkDetail = .ChkDetail.Checked
	End With

	If ds.Tables.Count = 0 Then
		BuildDS()
	Else
		ds.Clear()
		dsTot.Clear()
		ClearTotals()
	End If

	GetDetail()

Done:
	MyCrViewer = New FrmCrViewer
	MyCrViewer.wrkds = ds
	MyCrViewer.wrkdsTot = dsTot
	MyCrViewer.WrkFromCode = WrkFromCode
	MyCrViewer.WrkToCode = WrkToCode
	MyCrViewer.Show()

End Sub

	Private Sub BuildDS()
		Dim myTable As New DataTable
		Dim myTableTot As New DataTable

		With myTable
			.TableName = "mytable"
			.Columns.Add("Code", Type.GetType("System.String"))
			.Columns.Add("List", Type.GetType("System.Int32"))
			.Columns.Add("Year", Type.GetType("System.Int32"))
			.Columns.Add("Type", Type.GetType("System.String"))
			.Columns.Add("Name", Type.GetType("System.String"))
			.Columns.Add("FeePaid", Type.GetType("System.Double"))
			.Columns.Add("DatePaid", Type.GetType("System.DateTime"))
		End With
		ds.Tables.Add(myTable)

		With myTableTot
			.TableName = "mytable"
			.Columns.Add("Code", Type.GetType("System.String"))
			.Columns.Add("Descr", Type.GetType("System.String"))
			.Columns.Add("Year", Type.GetType("System.Int32"))
			.Columns.Add("Type", Type.GetType("System.String"))
			.Columns.Add("TCount", Type.GetType("System.Int32"))
			.Columns.Add("TFeePaid", Type.GetType("System.Double"))
		End With
		dsTot.Tables.Add(myTableTot)
	End Sub
Private Sub ClearTotals()
	WrkTCount = 0
	WrkTFeePaid = 0
End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim WrkTypes As String
Dim SaveCode As String
Dim SaveYear As Integer
Dim SaveType As String
Dim SaveTypeDesc As String
Dim Counter As Integer

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

Counter = 0
WrkQry = "RCODE <>'I'" & WrkAnd & "RCODE <>'V'" & WrkAnd & "PCAMT <> 0" & WrkAnd & _
	"PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo

If WrkFromCode <> "" Then
  WrkQry = WrkQry & WrkAnd & "PENCD>=" & MyUtils.Quo(WrkFromCode)
End If

If WrkToCode <> "" Then
  WrkQry = WrkQry & WrkAnd & "PENCD<=" & MyUtils.Quo(WrkToCode)
End If

MyTypes = MyFrmTXE18B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    WrkSort = "PENCD, YEAR, TYPE"
myTXHSTQ.OpenQry(WrkSort, WrkQry)
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

SaveType = ""
SaveTypeDesc = ""
SaveCode = ""

ReadNext:
  myTXHSTQ.ReadQry()
  If Not myTXHSTQ.IsEOF Then
  With myTXHSTQ
    Counter = Counter + 1
    If SaveCode <> "" And SaveCode <> ._PENCD Or _
      SaveYear > 0 And SaveYear <> ._YEAR Or _
      SaveType <> "" And SaveType <> ._TYPE Then
      WriteTotals(SaveCode, SaveYear, SaveType)
      ClearTotals()
    End If
    SaveCode = ._PENCD
    SaveYear = ._YEAR
    If WrkDetail Then
      If SaveType <> ._TYPE Then
        SaveTypeDesc = GetTXTypeDesc(._TYPE)
      End If
    End If
    SaveType = ._TYPE

    If WrkDetail Then
      dr = ds.Tables(0).NewRow
      dr.Item("code") = SaveCode
      dr.Item("list") = ._LISTNo
      dr.Item("year") = SaveYear
      dr.Item("type") = SaveTypeDesc
      myTXINV.GetOneRecordP(._LISTNo, ._YEAR, ._TYPE)
      If Not myTXINV.RecordNotFound Then
        With myTXINV
          dr.Item("name") = Trim(._NAME)
        End With
      End If
      dr.Item("Feepaid") = ._PCAMT
      dr.Item("datepaid") = MyUtils.GetDBDate(._PDATE)
      ds.Tables(0).Rows.Add(dr)
    End If

    WrkTCount = WrkTCount + 1
    WrkTFeePaid = WrkTFeePaid + ._PCAMT
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

WriteTotals(SaveCode, SaveYear, SaveType)
myFrmProgress.Close()

CloseFiles:
myTXHSTQ.CloseFile()

End Sub
Private Sub WriteTotals(ByVal SaveCode As String, ByVal SaveYear As Integer, _
	ByVal SaveType As String)
	If WrkTCount = 0 Then Exit Sub

	drTot = dsTot.Tables(0).NewRow
	drTot.Item("code") = SaveCode
	drTot.Item("descr") = GetTXPENDesc(SaveCode)
	drTot.Item("year") = SaveYear
	drTot.Item("type") = GetTXTypeDesc(SaveType)
	drTot.Item("tcount") = WrkTCount
	drTot.Item("tFeepaid") = WrkTFeePaid
	dsTot.Tables(0).Rows.Add(drTot)
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






