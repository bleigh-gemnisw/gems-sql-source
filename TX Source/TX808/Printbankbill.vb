Imports System.io
Imports System.Text
Module Printbankbill
Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINVQ As TXINVQ.myData

Dim ds As DataSet = New DataSet
Dim DsTXINV As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkGLYear As Integer
Dim WrkSelType As String
Dim WrkShowList As Boolean
Dim WrkBalDue As Boolean
Dim WrkPaid As Boolean
Dim WrkPaidCount As Integer
Dim WrkSortBy As String
Dim WrkAnd As String
Dim WrkOr As String
  Public Sub PrtBankbill()

	myTXINVQ = New TXINVQ.mydata(MyDBConnect)

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .wrkds = ds
    .wrkpaidcount = WrkPaidCount
    .Show()
  End With

  End Sub
Private Sub GetDetail()
Dim sb As StringBuilder
Dim sw As StreamWriter = New StreamWriter(MyFrmTX808B.LblFilePath.Text)
Dim WrkQry As String
Dim WrkSort As String
    Dim Counter As Integer
    Dim WrkName As String
Dim wrkinteger As Integer
Dim wrktaxt As Decimal
Dim wrktax1 As Decimal
Dim wrktax2 As Decimal
Dim wrktax3 As Decimal
Dim wrktax4 As Decimal
Dim wrktaxbal As Decimal
Dim wrktaxrec As Decimal
Dim wrkcest As String
Dim wrkinstal As String
Dim wrkstring As String
Dim wrkbankcode As String
Dim wrkinstala As Decimal
Dim WrkBserDesc As String
Dim SaveBksr As String
Dim WrkBkcdDesc As String
Dim SaveBkcd As String

wrkinstal = " "
WrkPaidCount = 0
With MyFrmTX808B
  WrkGLYear = .TxtGlYear.Text
  If .rb1.Checked Then Mypayment = "1"
  If .rb2.Checked Then Mypayment = "2"
  If .rb3.Checked Then Mypayment = "3"
  If .rb4.Checked Then Mypayment = "4"
  wrkbankcode = Trim(.TxtBankCd.Text)
  WrkBalDue = .ChkBalDue.Checked
  WrkPaid = .ChkPaid.Checked
	WrkSortBy = ""
	If .RbSortType.Checked Then
		WrkSortBy = "Type"
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

WrkQry = "icode<>'I'" & WrkAnd & "YEAR = " & WrkGLYear
If wrkbankcode > "" Then
 WrkQry = WrkQry & WrkAnd & " BKCD = " & MyUtils.Quo(wrkbankcode)
End If
MyTypes = MyFrmTX808B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    Counter = 0
WrkSort = ""
WrkBserDesc = ""
SaveBksr = ""
WrkBkcdDesc = ""
SaveBkcd = ""
Select Case WrkSortBy
Case "Type"
	WrkSort = "BKSR, BKCD, TYPE, NAME, LIST#"
Case "Name"
	WrkSort = "BKSR, BKCD, NAME, LIST#, TYPE"
End Select

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
		If ._CCNO = 0 Then
			wrkcest = "N"
			wrktaxt = ._TAXT
			wrktax1 = ._TAX1
			wrktax2 = ._TAX2
			wrktax3 = ._TX3RD
			wrktax4 = ._TX4TH
		Else
			wrkcest = "Y"
			wrktaxt = ._CCETAX
			wrktax1 = ._CCTX1
			wrktax2 = ._CCTX2
			wrktax3 = ._CCTX3
			wrktax4 = ._CCTX4
		End If
    wrktaxrec = ._NEWPAY + ._PAYREC
    If WrkBalDue Then
      If Mypayment = "1" Then
        wrktax1 = wrktax1 - wrktaxrec
        If wrktax1 < 0 Then wrktax1 = 0
      End If
      If Mypayment = "2" Then
        wrktax2 = wrktax1 + wrktax2 - wrktaxrec
        If wrktax2 < 0 Then wrktax2 = 0
      End If
      If Mypayment = "3" Then
        wrktax3 = wrktax1 + wrktax2 + wrktax3 - wrktaxrec
        If wrktax3 < 0 Then wrktax3 = 0
      End If
      If Mypayment = "4" Then
        wrktax4 = wrktaxt - wrktaxrec
      End If
    End If
    wrkinstala = 0
		If Mypayment = "1" Then wrkinstala = wrktax1
		If Mypayment = "2" Then wrkinstala = wrktax2
		If Mypayment = "3" Then wrkinstala = wrktax3
		If Mypayment = "4" Then wrkinstala = wrktax4

    wrktaxbal = wrktaxt - wrktaxrec
		If wrktaxbal > 0 Or WrkPaid Then
			dr = ds.Tables(0).NewRow
			dr.Item("listno") = ._LISTNo
			dr.Item("type") = ._TYPE
			dr.Item("year") = ._YEAR
			dr.Item("bksr") = Trim(._BKSR)
			If Trim(._BKSR) <> SaveBksr Then
				WrkBserDesc = GetTXBSerDesc(Trim(._BKSR))
			End If
			dr.Item("bksrdesc") = WrkBserDesc
			dr.Item("bkcd") = Trim(._BKCD)
			If Trim(._BKCD) <> SaveBkcd Then
				WrkBkcdDesc = GetTXBanksDesc(Trim(._BKCD))
			End If
			dr.Item("bkcddesc") = WrkBkcdDesc
			dr.Item("name") = Trim(._NAME)
			dr.Item("loc") = Trim(._LOC)
			dr.Item("locno") = ._LOCNo
			dr.Item("map") = Trim(._MAP)
			dr.Item("icode") = ._ICODE
			dr.Item("cest") = wrkcest
			dr.Item("taxt") = wrktaxt
			dr.Item("tax1") = wrktax1
			dr.Item("tax2") = wrktax2
			dr.Item("tax3") = wrktax3
			dr.Item("tax4") = wrktax4
			If wrktaxbal < 0 Then
				wrktaxbal = 0
			End If
			dr.Item("bald") = wrktaxbal
			dr.Item("gross") = ._GROSS
			dr.Item("texmp") = ._TOTEXP
			dr.Item("net") = ._NETASS
			dr.Item("vol") = Trim(._VOL)
			dr.Item("ipage") = Trim(._IPAGE)
			dr.Item("frcd") = Trim(._FRCD)
			dr.Item("instal") = Mypayment
			dr.Item("instala") = wrkinstala
			ds.Tables(0).Rows.Add(dr)

			sb = New StringBuilder
			sb.Append(Format(._LISTNo, "000000"))
			sb.Append(Format(._YEAR, "0000"))
			sb.Append(Mid(._TYPE, 1, 1))
			wrkstring = Mid(._BKCD, 1, 2)
      wrkstring = MyUtils.JustifyLeft(wrkstring, 2)
      sb.Append(wrkstring)
      sb.Append(Format(myTOWN._TOWNBR, "000"))
      WrkName = MyUtils.JustifyLeft(._NAME, 35)
      sb.Append(WrkName)
      wrkstring = MyUtils.JustifyLeft(._LOC, 25)
      sb.Append(wrkstring)
      wrkstring = MyUtils.JustifyRight(._LOCNo, 7)
      sb.Append(wrkstring)
      wrkstring = MyUtils.JustifyLeft(._MAP, 17)
      sb.Append(wrkstring)
      wrkstring = MyUtils.JustifyLeft(._ICODE, 1)
      sb.Append(wrkstring)
      wrkstring = Mid(wrkcest, 1, 1)
      wrkstring = MyUtils.JustifyLeft(wrkstring, 1)
      sb.Append(wrkstring)
      wrkinteger = wrktaxt * 100
      sb.Append(Format(wrkinteger, "00000000000"))
      wrkinteger = wrktax1 * 100
      sb.Append(Format(wrkinteger, "00000000000"))
      wrkinteger = wrktax2 * 100
      sb.Append(Format(wrkinteger, "00000000000"))
      wrkinteger = wrktax3 * 100
      sb.Append(Format(wrkinteger, "00000000000"))
      wrkinteger = wrktax4 * 100
      sb.Append(Format(wrkinteger, "00000000000"))
      wrkinteger = wrktaxbal * 100
      sb.Append(Format(wrkinteger, "000000000"))
      wrkinteger = ._GROSS
      sb.Append(Format(wrkinteger, "000000000"))
      wrkinteger = ._TOTEXP
      sb.Append(Format(wrkinteger, "000000000"))
      wrkinteger = ._NETASS
      sb.Append(Format(wrkinteger, "000000000"))
      wrkstring = MyUtils.JustifyLeft(._VOL, 5)
      sb.Append(wrkstring)
      wrkstring = MyUtils.JustifyLeft(._IPAGE, 5)
      sb.Append(wrkstring)
      wrkstring = MyUtils.JustifyLeft(._FRCD, 1)
      sb.Append(wrkstring)
      wrkstring = Mid(wrkinstal, 1, 1)
      wrkstring = MyUtils.JustifyLeft(wrkstring, 1)
			sb.Append(wrkstring)
			sw.WriteLine(sb.ToString)
		End If
		If wrktaxbal <= 0 Then
			WrkPaidCount = WrkPaidCount + 1
		End If
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

sw.Close()
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
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("RptID", Type.GetType("System.String"))
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Bksr", Type.GetType("System.String"))
      .Columns.Add("BksrDesc", Type.GetType("System.String"))
      .Columns.Add("Bkcd", Type.GetType("System.String"))
      .Columns.Add("BkcdDesc", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Loc", Type.GetType("System.String"))
      .Columns.Add("Locno", Type.GetType("System.String"))
      .Columns.Add("Map", Type.GetType("System.String"))
      .Columns.Add("Icode", Type.GetType("System.String"))
      .Columns.Add("Cest", Type.GetType("System.String"))
      .Columns.Add("TaxT", Type.GetType("System.Decimal"))
      .Columns.Add("Tax1", Type.GetType("System.Decimal"))
      .Columns.Add("Tax2", Type.GetType("System.Decimal"))
      .Columns.Add("Tax3", Type.GetType("System.Decimal"))
      .Columns.Add("Tax4", Type.GetType("System.Decimal"))
      .Columns.Add("Bald", Type.GetType("System.Decimal"))
      .Columns.Add("Gross", Type.GetType("System.Decimal"))
      .Columns.Add("Texmp", Type.GetType("System.Decimal"))
      .Columns.Add("Net", Type.GetType("System.Decimal"))
      .Columns.Add("Vol", Type.GetType("System.String"))
      .Columns.Add("Ipage", Type.GetType("System.String"))
      .Columns.Add("Frcd", Type.GetType("System.String"))
      .Columns.Add("Instal", Type.GetType("System.String"))
      .Columns.Add("Instala", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
End Module






