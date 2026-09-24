Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINVQ As TXINVQ.MyData
Dim myTXBANKS As TXBANKS.myData

Dim ds As DataSet = New DataSet
Dim DsTXINV As DataSet = New DataSet
Dim dr As Data.DataRow
'General
Dim WrkAnd As String
Dim WrkOr As String
'Buffered Types
Dim WrkCode(50) As String
Dim WrkDesc(50) As String
Dim WrkFamily(50) As String


  Public Sub PrtReport()

	myTXINVQ = New TXINVQ.mydata(MyDBConnect)
	myTXBANKS = New TXBANKS.mydata(MyDBConnect)

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If

  BufferType()
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
      .Columns.Add("Address", Type.GetType("System.String"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("Bkcd", Type.GetType("System.String"))
      .Columns.Add("Tax1st", Type.GetType("System.Decimal"))
      .Columns.Add("Tax2nd", Type.GetType("System.Decimal"))
      .Columns.Add("Payments", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()
Dim WrkType As String
Dim WrkYearFrom As Integer
Dim WrkYearTo As Integer
Dim WrkBank As String
Dim WrkListNo As Integer
Dim WrkQry As String
Dim WrkSort As String
Dim WrkSortBy As String
Dim WrkTypes As String
Dim WrkTXType As String()
Dim sb As StringBuilder
Dim Counter As Integer

WrkSortBy = ""
With MyFrmTXE06B
  WrkType = .TxtTypes.Text
  WrkYearFrom = MyUtils.CnvSng(.TxtGLYearFrom.Text)
  WrkYearTo = MyUtils.CnvSng(.TxtGLYearTo.Text)
  MyTypes = .TxtTypes.Text
  WrkBank = .TxtBankCd.Text
  WrkListNo = MyUtils.CnvSng(.TxtListNo.Text)
  If .RbName.Checked Then
    WrkSortBy = "Name"
  End If
  If .RbBank.Checked Then
    WrkSortBy = "Bank"
  End If
End With

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

WrkSort = ""
Counter = 0
Select Case WrkSortBy
Case "Bank"
	WrkSort = "BKCD, NAME"
Case "Name"
	WrkSort = "NAME"
End Select

WrkQry = "ICODE<>'I'"
If WrkYearFrom > 0 Then
  WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkYearFrom
End If
If WrkYearTo > 0 Then
  WrkQry = WrkQry & WrkAnd & "YEAR <= " & WrkYearTo
End If
If WrkBank <> String.Empty Then
  WrkQry = WrkQry & WrkAnd & "BKCD=" & MyUtils.Quo(WrkBank)
End If
If WrkListNo > 0 Then
  WrkQry = WrkQry & WrkAnd & "LIST#= " & WrkListNo
End If
If WrkSortBy = "Bank" Then
  WrkQry = WrkQry & WrkAnd & "BKCD>'  '"
End If

MyTypes = MyFrmTXE06B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

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
		dr.Item("address") = Trim(._ADD1)
		WrkTXType = LookupType(._TYPE)
		Select Case WrkTXType(1)
		Case "M", "S"
			sb = New StringBuilder
      sb.Append(MyUtils.JustifyLeft(._MAKE, 5))
			sb.Append(" ")
      sb.Append(MyUtils.JustifyLeft(._MODEL, 8))
			sb.Append(" ")
			sb.Append(._MVYR)
			sb.Append(" ")
      sb.Append(MyUtils.JustifyLeft(._IMVREG, 8))
			sb.Append(" ")
			sb.Append(._IMVIDNo)
			dr.Item("desc") = sb.ToString
			sb = Nothing
		Case Else
      dr.Item("desc") = MyUtils.JustifyRight(Trim(._LOCNo), 7) & " " & Trim(._LOC)
		End Select
		dr.Item("bkcd") = Trim(._BKCD)
		If ._CCNO > 0 Then
			dr.Item("tax1st") = ._CCTX1
			dr.Item("tax2nd") = ._CCTX2
		Else
			dr.Item("tax1st") = ._TAX1
			dr.Item("tax2nd") = ._TAX2
		End If
		dr.Item("payments") = ._PAYREC + ._NEWPAY
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
  Private Sub BufferType()
    Dim I As Integer

    Dim myTXTYPE As TXTYPE.MyData
    Dim dsTXType As DataSet = New DataSet

    myTXTYPE = New TXTYPE.MyData(myDBConnect)

    dsTXType = myTXTYPE.GetAllData
    For I = 0 To dsTXType.Tables(0).Rows.Count - 1
      With dsTXType.Tables(0).Rows(I)
        WrkCode(I) = .Item("tycode")
        WrkDesc(I) = .Item("tydesc")
        WrkFamily(I) = .Item("txfam")
      End With
    Next

  End Sub
  Private Function LookupType(ByVal Type As String) As String()
     Dim I As Integer
     Dim WrkResult(1) As String

     WrkResult(0) = ""
     WrkResult(1) = ""

     For I = 0 To WrkCode.GetUpperBound(0)
       If WrkCode(I) = "" Then
         Return WrkResult
       End If
       If Type = WrkCode(I) Then
         WrkResult(0) = WrkDesc(I)
         WrkResult(1) = WrkFamily(I)
         Return WrkResult
       End If
    Next

    Return WrkResult
End Function

End Module






