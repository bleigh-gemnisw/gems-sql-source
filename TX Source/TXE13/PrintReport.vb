Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim MyCASHASOF As CASHASOF.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  'General
  Dim WrkAnd As String
  Dim WrkOr As String
  Dim WrkOmitStatus As String
  Dim WrkAddress As Boolean
  Dim WrkSortBy As String
  Dim WrkDate As Date
  Public Sub PrtReport()

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    MyCASHASOF = New CASHASOF.MyData(myDBConnect)

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
      .Columns.Add("Group", Type.GetType("System.String"))
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("Taxt", Type.GetType("System.Decimal"))
      .Columns.Add("Paid", Type.GetType("System.Decimal"))
      .Columns.Add("StartOver", Type.GetType("System.Decimal"))
      .Columns.Add("Ovrpaid", Type.GetType("System.Decimal"))
      .Columns.Add("lastpaiddt", Type.GetType("System.DateTime"))
      .Columns.Add("ccno", Type.GetType("System.Int32"))
      .Columns.Add("ccdate", Type.GetType("System.DateTime"))
      .Columns.Add("ccresn", Type.GetType("System.String"))
      .Columns.Add("bkcd", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub GetDetail()
    Dim AddrLine() As String
    Dim WrkType As String
    Dim WrkFromYear As Integer
    Dim WrkToYear As Integer
    Dim WrkDist As Integer
    Dim WrkDistAll As Boolean
    Dim WrkPhase As Integer
    Dim WrkStartChk As Boolean
    Dim WrkStartDt As Date
    Dim WrkAsofChk As Boolean
    Dim WrkAsofDt As Date
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkCC As Boolean
    Dim Counter As Integer
    Dim WrkInterest As Decimal
    Dim WrkBond As Decimal
    Dim WrkFees As Decimal
    Dim WrkLiens As Decimal
    Dim WrkTax As Decimal
    Dim WrkBilled As Decimal
    Dim WrkBilledStart As Decimal
    Dim WrkPrinPaid As Decimal
    Dim WrkPrinPaidStart As Decimal
    Dim WrkMin As Decimal
    Dim WrkBalance As Decimal
    Dim WrkGroup As String
    Dim Pos As Integer

    With MyFrmTXE13B
      WrkType = .TxtTypes.Text
      WrkFromYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
      WrkToYear = MyUtils.CnvSng(.TxtToGLYear.Text)
      MyTypes = .TxtTypes.Text
      WrkOmitStatus = .TxtOmitStatus.Text
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkDistAll = False
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
      WrkAddress = False
      If .ChkAddress.Checked Then
        WrkAddress = True
      End If
      If .RbSortYear.Checked Then
        WrkSortBy = "Year"
      End If
      If .RbSortName.Checked Then
        WrkSortBy = "Name"
      End If
      If .RbSortDistrict.Checked Then
        WrkSortBy = "District"
      End If
      If .RbSortBank.Checked Then
        WrkSortBy = "Bank"
      End If
      WrkStartChk = False
      If .DtPckStart.Checked Then WrkStartChk = True
      WrkStartDt = DateAdd(DateInterval.Day, -1, .DtPckStart.Value)
      WrkAsofChk = False
      If .DtPckAsof.Checked Then WrkAsofChk = True
      WrkAsofDt = .DtPckAsof.Value
      WrkMin = MyUtils.CnvSng(.TxtMin.Text)
    End With

    WrkDate = Date.Today

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkSort = ""
    Select Case WrkSortBy
      Case "Year"
        WrkSort = "YEAR, TYPE"
      Case "Name"
        WrkSort = "NAME"
      Case "District"
        WrkSort = "DIST, YEAR, TYPE"
      Case "Bank"
        WrkSort = "BKCD, NAME"
    End Select

    If WrkAsofChk Then
      WrkQry = "icode<>'I'"
    Else
      If WrkMin = 0 Then
        WrkQry = "icode<>'I'" & WrkAnd & "BALD < 0"
      Else
        WrkQry = "icode<>'I'" & WrkAnd & "BALD <= " & (WrkMin * -1)
      End If
    End If

    If WrkFromYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromYear & WrkAnd & "YEAR <= " & WrkToYear
    End If

    If Not WrkDistAll Then
      WrkQry = WrkQry & WrkAnd & "DIST=" & WrkDist
    End If

    If WrkPhase > 0 Then
      WrkQry = WrkQry & WrkAnd & "PHASE = " & WrkPhase
    End If

    MyTypes = MyFrmTXE13B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    Counter = 0
    'WrkQry = WrkQry & WrkAnd & "list#=6585"
    myTXINVQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()

ReadNext:
    myTXINVQ.ReadQry()
    If Not myTXINVQ.IsEOF Then
      With myTXINVQ
        Counter = Counter + 1
        WrkBilled = 0
        WrkBilledStart = 0
        'Filter - Omit Status Codes
        If Trim(WrkOmitStatus) > "" Then
          Pos = 0
          If Trim(._STCD1) <> "" Then
            Pos = InStr(1, WrkOmitStatus, Trim(._STCD1), 1)
          End If
          If Pos = 0 And Trim(._STCD2) <> "" Then
            Pos = InStr(1, WrkOmitStatus, Trim(._STCD2), 1)
          End If
          If Pos = 0 And Trim(._STCD3) <> "" Then
            Pos = InStr(1, WrkOmitStatus, Trim(._STCD3), 1)
          End If
          If Pos = 0 And Trim(._STCD4) <> "" Then
            Pos = InStr(1, WrkOmitStatus, Trim(._STCD4), 1)
          End If
          If Pos = 0 And Trim(._STCD5) <> "" Then
            Pos = InStr(1, WrkOmitStatus, Trim(._STCD5), 1)
          End If
          If Pos > 0 Then GoTo NextRec
        End If

        If WrkAsofChk Then
          CalcAsof(WrkAsofDt, ._LISTNo, ._YEAR, ._TYPE, WrkInterest, WrkFees, WrkLiens, WrkBond,
        WrkTax, 0, WrkPrinPaid, WrkBilled)
          'Filter - Omit amount due
          If WrkBilled - WrkPrinPaid >= (WrkMin * -1) Then
            GoTo NextRec
          End If
        End If
        If WrkStartChk Then
          CalcAsof(WrkStartDt, ._LISTNo, ._YEAR, ._TYPE, 0, 0, 0, 0,
        0, 0, WrkPrinPaidStart, WrkBilledStart)
          If WrkBilledStart - WrkPrinPaidStart = WrkBilled - WrkPrinPaid Then
            GoTo NextRec
          End If
        End If
        'Billed amount same and adjustment made then skip
        If WrkStartChk Then
          If WrkBilled = WrkBilledStart And WrkPrinPaidStart > WrkPrinPaid Then
            GoTo NextRec
          End If
        End If
        If WrkAsofChk Then
          'If ._CCNO > 0 Then
          '  WrkBalance = ._CCETAX - WrkPrinPaid
          'Else
          '  WrkBalance = ._TAXT - WrkPrinPaid
          'End If
          WrkBalance = WrkBilled - WrkPrinPaid
          '      If WrkBalance >= (WrkMin * -1) Then GoTo NextRec
        End If

        dr = ds.Tables(0).NewRow
        dr.Item("listno") = ._LISTNo
        dr.Item("year") = ._YEAR
        dr.Item("type") = ._TYPE
        AddrLine = MyUtils.SetAddrLine(._NAME, ._SNAME, ._ADD1, ._ADD2,
      ._CITY, ._STATE, ._ZIP5, ._ZIP4)
        dr.Item("addr1") = AddrLine(0)
        dr.Item("addr2") = AddrLine(1)
        dr.Item("addr3") = AddrLine(2)
        dr.Item("addr4") = AddrLine(3)
        dr.Item("addr5") = AddrLine(4)
        WrkCC = False
        If ._CCNO > 0 Then
          If MyUtils.GetDBDate(._CDATE) <= WrkDate Then
            WrkCC = True
          End If
        End If
        If WrkCC Then
          dr.Item("taxt") = ._CCETAX
        Else
          dr.Item("taxt") = ._TAXT
        End If
        dr.Item("paid") = ._PAYREC
        WrkGroup = ""
        If WrkAsofChk Then
          WrkGroup = " Total"
          If WrkBilledStart > 0 And WrkBilledStart - WrkPrinPaid < 0 Then
            dr.Item("startover") = WrkBilledStart - WrkPrinPaidStart
            dr.Item("ovrpaid") = WrkBilled - WrkPrinPaid
            If dr.Item("startover") < 0 Then
              WrkGroup = "Credit"
              dr.Item("ovrpaid") = WrkBilled - WrkPrinPaid - dr.Item("startover")
            End If
          Else
            dr.Item("startover") = 0
            dr.Item("ovrpaid") = WrkBalance
          End If
        Else
          dr.Item("startover") = 0
          dr.Item("ovrpaid") = Math.Abs(._BALD)
        End If
        dr.Item("lastpaiddt") = MyUtils.GetDBDate(._TXIDT)
        If WrkCC Then
          dr.Item("ccno") = ._CCNO
          dr.Item("ccdate") = MyUtils.GetDBDate(._CDATE)
          dr.Item("ccresn") = Trim(._CCRSN)
        End If
        dr.Item("bkcd") = Trim(._BKCD)
        dr.Item("group") = WrkGroup
        ds.Tables(0).Rows.Add(dr)
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
        GoTo ReadNext
      End With
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
  Public Sub CalcAsof(ByVal WrkAsofDt As Date, ByVal wrklist As Integer, ByVal wrkyear As Integer,
    ByVal wrktype As String, ByRef OutInterest As Decimal, ByRef OutFee As Decimal,
    ByRef OutLien As Decimal, ByRef OutBond As Decimal, ByRef OutTax As Decimal,
    ByRef OutDue As Decimal, ByRef OutPrinPaid As Decimal, ByRef OutBilled As Decimal)

    With MyCASHASOF
      .In_AsofDate = WrkAsofDt
      .In_ListNo = wrklist
      .In_Type = wrktype
      .In_Year = wrkyear
      .CalcAsof()
      OutInterest = Format(.Out_Int(), "standard")
      OutFee = Format(.Out_Fee(), "standard")
      OutLien = Format(.Out_Lien(), "standard")
      OutBond = Format(.Out_Bond(), "standard")
      OutTax = Format(.Out_Prin(), "standard")
      OutDue = Format(.Out_Tot(), "standard")
      OutPrinPaid = Format(.Out_PrinPaid(), "standard")
      OutBilled = Format(.Out_Billed(), "standard")
    End With
  End Sub
End Module






