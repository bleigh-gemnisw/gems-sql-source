Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINVQ As TXINVQ.myData
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkType As String
Dim WrkICode As String
Dim WrkFromGLYear As Integer
Dim WrkToGLYear As Integer
Dim WrkAnd As String
Dim WrkOr As String
Public Sub PrtReport()

	myTXINVQ = New TXINVQ.mydata(MyDBConnect)

  With MyFrmTXE09B
    WrkFromGLYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
    WrkToGLYear = MyUtils.CnvSng(.TxtToGLYear.Text)
    If .RbBackTax.Checked Then WrkICode = "B"
    If .RbForeclosure.Checked Then WrkICode = "F"
    If .RbInactive.Checked Then WrkICode = "I"
    If .RbSuspense.Checked Then WrkICode = "S"
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
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Sname", Type.GetType("System.String"))
      .Columns.Add("Add1", Type.GetType("System.String"))
      .Columns.Add("Add2", Type.GetType("System.String"))
      .Columns.Add("City", Type.GetType("System.String"))
      .Columns.Add("State", Type.GetType("System.String"))
      .Columns.Add("Zip", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Private Sub GetDetail()
Dim sb As StringBuilder
Dim WrkSort As String
Dim WrkQry As String
Dim Counter As Integer
Dim WrkTypes As String

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

WrkQry = "ICODE = " & MyUtils.Quo(WrkICode)
If WrkFromGLYear > 0 Then
  WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromGLYear _
  & WrkAnd & "YEAR <= " & WrkToGLYear
End If

MyTypes = MyFrmTXE09B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    WrkSort = "NAME"
myTXINVQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
	myTXINVQ.ReadQry()
	If Not myTXINVQ.IsEOF Then
	With myTXINVQ
		Counter = Counter + 1
		dr = ds.Tables(0).NewRow
		dr.Item("listno") = ._LISTNo
		dr.Item("year") = ._YEAR
		dr.Item("type") = ._TYPE
		dr.Item("name") = Trim(._NAME)
		dr.Item("sname") = Trim(._SNAME)
		dr.Item("add1") = Trim(._ADD1)
		dr.Item("add2") = Trim(._ADD2)
		dr.Item("city") = Trim(._CITY)
		dr.Item("state") = Trim(._STATE)
		sb = New StringBuilder
		sb.Append(Format(._ZIP5, "00000"))
		If ._ZIP4 > 0 Then
			sb.Append("-")
			sb.Append(Format(._ZIP4, "0000"))
		End If
		dr.Item("zip") = sb.ToString
		sb = Nothing
	End With
	ds.Tables(0).Rows.Add(dr)

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






