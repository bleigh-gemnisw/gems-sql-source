Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINVQ As TXINVQ.MyData
Dim myTXREALC As TXREALC.MyData
Dim myTXPPRPC As TXPPRPC.MyData
Dim myTXMVDC As TXMVDC.MyData
Dim ds As DataSet = New DataSet
Dim DsTXINVQ As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkType As String
Dim WrkFrom As Integer
Dim WrkTo As Integer
Dim WrkFromGLYear As Integer
Dim WrkToGLYear As Integer
Dim WrkRE As Boolean
Dim WrkPP As Boolean
Dim WrkMV As Boolean
Dim WrkAnd As String
Dim WrkOr As String
Public Sub PrtReport()

	myTXINVQ = New TXINVQ.mydata(MyDBConnect)
	myTXREALC = New TXREALC.mydata(MyDBConnect)
	myTXPPRPC = New TXPPRPC.mydata(MyDBConnect)
	myTXMVDC = New TXMVDC.mydata(MyDBConnect)

	With MyFrmTXE25B
    WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
    WrkFromGLYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
    WrkToGLYear = MyUtils.CnvSng(.TxtToGLYear.Text)
		WrkRE = .ChkRE.Checked
		WrkPP = .ChkPP.Checked
		WrkMV = .ChkMV.Checked
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
	MyCrViewer.Show()

End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("Map", Type.GetType("System.String"))
      .Columns.Add("NAddr1", Type.GetType("System.String"))
      .Columns.Add("NAddr2", Type.GetType("System.String"))
      .Columns.Add("NAddr3", Type.GetType("System.String"))
      .Columns.Add("NAddr4", Type.GetType("System.String"))
      .Columns.Add("NAddr5", Type.GetType("System.String"))
      .Columns.Add("NMap", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()
Dim AddrLine() As String
Dim WrkSort As String
Dim WrkQry As String
Dim I As Integer
Dim WrkTypes As String
Dim Found As Boolean

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

WrkQry = "ICODE <> 'I'" & WrkAnd & "CHDATE >= " & WrkFrom _
  & WrkAnd & "CHDATE <= " & WrkTo

If WrkFromGLYear > 0 Then
  WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromGLYear _
  & WrkAnd & "YEAR <= " & WrkToGLYear
End If

MyTypes = ""
If WrkRE Then
  MyTypes = "R"
End If
If WrkPP Then
  MyTypes = MyTypes & "P"
End If
If WrkMV Then
  MyTypes = MyTypes & "M"
End If
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    WrkSort = "YEAR, TYPE"
DsTXINVQ = myTXINVQ.GetQry(WrkSort, WrkQry, 0)
If DsTXINVQ.Tables(0).Rows.Count = 0 Then GoTo CloseFiles
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

For I = 0 To (DsTXINVQ.Tables(0).Rows.Count - 1)
  With DsTXINVQ.Tables(0).Rows(I)
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = .Item("list#")
    dr.Item("year") = .Item("year")
    dr.Item("type") = .Item("type")
    AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"), _
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
		dr.Item("naddr1") = AddrLine(0)
		dr.Item("naddr2") = AddrLine(1)
		dr.Item("naddr3") = AddrLine(2)
		dr.Item("naddr4") = AddrLine(3)
    dr.Item("naddr5") = AddrLine(4)
    Found = False
    Select Case .Item("type")
    Case "R"
			myTXREALC.GetOneRecordP(.Item("list#"))
      If Not myTXREALC.RecordNotFound Then
        Found = True
      End If
    Case "P"
      myTXPPRPC.GetOneRecordP(.Item("list#"))
      If Not myTXPPRPC.RecordNotFound Then
        Found = True
      End If
    Case "M"
      myTXMVDC.GetOneRecordP(.Item("list#"))
      If Not myTXMVDC.RecordNotFound Then
        Found = True
      End If
    End Select
		dr.Item("addr1") = String.Empty
		dr.Item("addr2") = String.Empty
		dr.Item("addr3") = String.Empty
		dr.Item("addr4") = String.Empty
		dr.Item("addr5") = String.Empty
    If Not Found Then GoTo NextRec

		Select Case .Item("type")
		Case "R"
			With myTXREALC
        AddrLine = MyUtils.SetAddrLine(._NAME, ._SNAME, ._ADD1, ._ADD2, ._CITY, ._STATE, ._ZIP5, ._ZIP4)
			End With
		Case "P"
			With myTXPPRPC
        AddrLine = MyUtils.SetAddrLine(._NAME, ._SNAME, ._ADD1, ._ADD2, ._CITY, ._STATE, ._ZIP5, ._ZIP4)
			End With
		Case "M"
			With myTXMVDC
        AddrLine = MyUtils.SetAddrLine(._NAME, ._SNAME, ._ADD1, ._ADD2, ._CITY, ._STATE, ._ZIP5, ._ZIP4)
			End With
		End Select
		dr.Item("addr1") = AddrLine(0)
		dr.Item("addr2") = AddrLine(1)
		dr.Item("addr3") = AddrLine(2)
		dr.Item("addr4") = AddrLine(3)
		dr.Item("addr5") = AddrLine(4)
		If dr.Item("addr1") <> dr.Item("naddr1") Or _
		 dr.Item("addr2") <> dr.Item("naddr2") Or _
		 dr.Item("addr3") <> dr.Item("naddr3") Or _
		 dr.Item("addr4") <> dr.Item("naddr4") Or _
		 dr.Item("addr5") <> dr.Item("naddr5") Then
			ds.Tables(0).Rows.Add(dr)
	End If
	End With

NextRec:
With myFrmProgress
	WrkPct = ((I + 1) / DsTXINVQ.Tables(0).Rows.Count) * 100
	If SavePct <> WrkPct Then
		.ProgBar1.Value = WrkPct
		.Refresh()
		SavePct = WrkPct
		Application.DoEvents()
	End If
End With
Next

myFrmProgress.Close()

CloseFiles:
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

End Module






