Imports System.IO
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim ds1 As DataSet = New DataSet
  Dim DsTXINV As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim WrkStatus As String
  Dim WrkFromGLYear As Integer
  Dim WrkToGLYear As Integer
  Dim WrkBalances As Boolean
  Dim WrkShowAddr As Boolean
  Dim WrkSortBy As String
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtReport()

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    With MyFrmTXE24B
      WrkStatus = .TxtSts.Text
      WrkFromGLYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
      WrkToGLYear = MyUtils.CnvSng(.TxtToGLYear.Text)
      WrkBalances = .ChkBalances.Checked
      WrkSortBy = ""
      If .RbSortYear.Checked Then
        WrkSortBy = "Year"
      End If
      If .RbSortType.Checked Then
        WrkSortBy = "Type"
      End If
      If .RbSortName.Checked Then
        WrkSortBy = "Name"
      End If
      If .RbSortNameList.Checked Then
        WrkSortBy = "NameList"
      End If
      WrkShowAddr = .ChkAddress.Checked
    End With

    If ds1.Tables.Count = 0 Then
      BuildDS()
    Else
      ds1.Clear()
    End If
    GetDetail()
Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.WrkSortBy = WrkSortBy
    MyCrViewer.wrkds = ds1
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
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Status", Type.GetType("System.String"))
      .Columns.Add("TaxT", Type.GetType("System.Decimal"))
      .Columns.Add("Payrec", Type.GetType("System.Decimal"))
      .Columns.Add("Bald", Type.GetType("System.Decimal"))
      .Columns.Add("NetAss", Type.GetType("System.Decimal"))
    End With
    ds1.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim sw As StreamWriter
    Dim WrkSort As String
    Dim WrkQry As String
    Dim Counter As Integer
    Dim WrkTypes As String
    Dim AddrLine(2) As String
    Dim Good As Boolean
    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If
    WrkQry = "ICODE <> 'I'"
    If WrkFromGLYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromGLYear _
& WrkAnd & "YEAR <= " & WrkToGLYear
    End If
    If WrkBalances Then
      WrkQry = WrkQry & WrkAnd & "BALD > 0"
    End If
    MyTypes = MyFrmTXE24B.TxtTypes.Text
    If MyTypes <> "" Then
      If MyServer = "DB2" Then
        WrkTypes = BuildSelectTypes()
        WrkQry = WrkQry & WrkAnd & WrkTypes
      Else
        WrkQry = BuildSelectTypesPC(WrkQry)
      End If
    End If
    WrkSort = ""
    If MyFrmTXE24B.LblFilePath.Text <> String.Empty Then
      sw = New StreamWriter(MyFrmTXE24B.LblFilePath.Text)
      sw.WriteLine(HeadingsCSV)
    End If

    Counter = 0
    Select Case WrkSortBy
      Case "Year"
        WrkSort = "YEAR, TYPE, DIST, LIST#"
      Case "Type"
        WrkSort = "TYPE, YEAR, DIST, LIST#"
      Case "Name"
        WrkSort = "NAME, TYPE, LIST#"
      Case "NameList"
        WrkSort = "LOC,NAME, TYPE, LIST#,YEAR"
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
        Good = False
        'Filter - Include Status Codes
        If WrkStatus = String.Empty Then
          Good = True
        End If
        If Not Good And Trim(._STCD1) <> String.Empty Then
          If InStr(WrkStatus, Trim(._STCD1)) > 0 Then
            Good = True
          End If
        End If
        If Not Good And Trim(._STCD2) <> String.Empty Then
          If InStr(WrkStatus, Trim(._STCD2)) > 0 Then
            Good = True
          End If
        End If
        If Not Good And Trim(._STCD3) <> String.Empty Then
          If InStr(WrkStatus, Trim(._STCD3)) > 0 Then
            Good = True
          End If
        End If
        If Not Good And Trim(._STCD4) <> String.Empty Then
          If InStr(WrkStatus, Trim(._STCD4)) > 0 Then
            Good = True
          End If
        End If
        If Not Good And Trim(._STCD5) <> String.Empty Then
          If InStr(WrkStatus, Trim(._STCD5)) > 0 Then
            Good = True
          End If
        End If
        If Not Good Then GoTo NextRec

        dr = ds1.Tables(0).NewRow
        dr.Item("listno") = ._LISTNo
        dr.Item("year") = ._YEAR
        dr.Item("type") = ._TYPE
        dr.Item("name") = Trim(._NAME)
        dr.Item("addr1") = Trim(._ADD1)
        If WrkShowAddr Then
          AddrLine = SetAddrShort(._ADD2, ._CITY, ._STATE, ._ZIP5, ._ZIP4)
          dr.Item("addr2") = AddrLine(0)
          dr.Item("addr3") = AddrLine(1)
        End If
        dr.Item("status") = ._STCD1 & " " & ._STCD2 & " " & ._STCD3 & " " & ._STCD4 & " " & ._STCD5
        If ._CCNO > 0 Then
          dr.Item("taxt") = ._CCETAX
        Else
          dr.Item("taxt") = ._TAXT
        End If
        dr.Item("payrec") = ._PAYREC
        dr.Item("bald") = ._BALD
        dr.Item("netass") = ._NETASS

        If MyFrmTXE24B.LblFilePath.Text <> String.Empty Then
          sw.WriteLine(DownloadCSV())
        End If

      End With
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

    If MyFrmTXE24B.LblFilePath.Text <> String.Empty Then
      sw.Flush()
      sw.Close()
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
  Private Function BuildSelectTypesPC(ByVal WrkStrIn As String) As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim WrkStrOut As String
    Dim StrLen As Integer
    Dim I As Integer

    WrkStrOut = ""
    If MyTypes = "" Then
      Return ""
    End If

    StrLen = Len(MyTypes)

    For I = 1 To StrLen
      sbSelect = New System.Text.StringBuilder
      If I > 1 Then
        sbSelect.Append(WrkOr)
      End If
      sbSelect.Append(WrkStrIn)
      sbSelect.Append(WrkAnd)
      sbSelect.Append("TYPE=")
      WrkType = Mid(MyTypes, I, 1)
      sbSelect.Append(MyUtils.Quo(WrkType))
      WrkStrOut = WrkStrOut & sbSelect.ToString
    Next

    Return WrkStrOut
  End Function
  Public Function SetAddrShort(ByVal Add2 As String, ByVal City As String, ByVal State As String,
     ByVal Zip5 As Integer, ByVal Zip4 As Integer) As String()
    'Returns Address as string array. Blank lines are stripped out. 
    'City, State, Zip5 and Zip4 are combined into one line
    Dim AddrLine(2) As String
    Dim sb As StringBuilder
    Dim I As Integer

    If Trim(Add2) <> "" Then
      AddrLine(I) = Trim(Add2)
      I = I + 1
    End If
    sb = New StringBuilder
    sb.Append(Trim(City))
    sb.Append(", ")
    sb.Append(Trim(State))
    sb.Append(" ")
    sb.Append(Format(Zip5, "00000"))
    If Zip4 > 0 Then
      sb.Append("-")
      sb.Append(Format(Zip4, "0000"))
    End If
    AddrLine(I) = sb.ToString
    For I = 2 To 2
      If AddrLine(I) Is Nothing Then
        AddrLine(I) = ""
      End If
    Next
    Return AddrLine

  End Function
  Private Function DownloadCSV() As String
    Dim sb As StringBuilder
    Const CComma As String = ","
    Const CQuote As String = Chr(34)

    With myTXINVQ
      sb = New StringBuilder
      sb.Append(._LISTNo)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(._TYPE)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(._YEAR)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._NAME))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(._ADD1)
      sb.Append(CQuote)

      If WrkShowAddr Then
        sb.Append(CComma)

        sb.Append(CQuote)
        sb.Append(._ADD2)
        sb.Append(CQuote)

        sb.Append(CComma)

        sb.Append(CQuote)
        sb.Append(._CITY)
        sb.Append(CQuote)

        sb.Append(CComma)

        sb.Append(CQuote)
        sb.Append(._STATE)
        sb.Append(CQuote)

        sb.Append(CComma)

        sb.Append(CQuote)
        sb.Append(._ZIP5)
        sb.Append(CQuote)

        sb.Append(CComma)

        sb.Append(CQuote)
        sb.Append(._ZIP4)
        sb.Append(CQuote)

      End If

      sb.Append(CComma)

      sb.Append(CQuote)
      sb.Append(Trim(._LOCNo) & " " & Trim(._LOC))
      sb.Append(CQuote)

      sb.Append(CComma)

      sb.Append(CQuote)
      sb.Append(._STCD1 & " " & ._STCD2 & " " & ._STCD3 & " " & ._STCD4 & " " & ._STCD5)
      sb.Append(CQuote)
      sb.Append(CComma)

      sb.Append(._BALD)
      sb.Append(CComma)
      sb.Append(._NETASS)


    End With
    Return sb.ToString
  End Function

  Private Function HeadingsCSV() As String
    Dim sb As StringBuilder
    Dim CComma As String = ","

    sb = New StringBuilder
    sb.Append("List No")
    sb.Append(CComma)
    sb.Append("Type")
    sb.Append(CComma)
    sb.Append("Year")
    sb.Append(CComma)
    sb.Append("Name")
    sb.Append(CComma)
    sb.Append("Address")
    If WrkShowAddr Then
      sb.Append(CComma)
      sb.Append("Address 2")
      sb.Append(CComma)
      sb.Append("City")
      sb.Append(CComma)
      sb.Append("State")
      sb.Append(CComma)
      sb.Append("Zip Code")
      sb.Append(CComma)
      sb.Append("Zip Ext")
    End If

    sb.Append(CComma)
    sb.Append("Property Location")

    sb.Append(CComma)
    sb.Append("Status Codes")
    sb.Append(CComma)

    sb.Append("Balance")
    sb.Append(CComma)
    sb.Append("Net Assessment")

    Return sb.ToString
  End Function



End Module






