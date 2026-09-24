Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXMVFEE As TXMVFEE.MyData
  Dim myCASHASOF As CASHASOF.MyData
  Dim myCASHINT As CASHINT.MyData

  Dim ds As DataSet = New DataSet
  Dim dsErr As DataSet = New DataSet
  Dim dsTot As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkGLFromYear As Integer
  Dim WrkGLToYear As Integer
  Dim WrkAsofDate As Date
  Dim WrkCalcAsof As Boolean
  Dim WrkStatus As String
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkBankCode As String
  Dim WrkOmitSuspense As Boolean
  Dim WrkOmitStatus As Boolean
  Dim WrkOmitAgency As Boolean
  Dim WrkGrace As Boolean
  Dim WrkFmt As String
  Dim WrkSortBy As String
  Dim WrkAnd As String
  Dim WrkOr As String
  'Type
  Dim WrkCode(50) As String
  Dim WrkDesc(50) As String
  Dim WrkFamily(50) As String
  'Totals
  Dim WrkTCount As Integer
  Dim WrkTAmtDue As Decimal
  Dim WrkTInterest As Decimal
  Dim WrkTFees As Decimal
  Dim WrkTLiens As Decimal
  Dim WrkTBond As Decimal
  Dim WrkTTotal As Decimal
  'General
  Dim ProfDuedt As Date
  Dim SaveYear As Integer
  Dim SaveType As String

  Public Sub PrtReport()

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXMVFEE = New TXMVFEE.MyData(myDBConnect)
    myCASHASOF = New CASHASOF.MyData(myDBConnect)
    myCASHINT = New CASHINT.MyData(myDBConnect)

    With MyFrmTX810B
      WrkGLFromYear = MyUtils.CnvSng(.TxtGLFromYear.Text)
      WrkGLToYear = MyUtils.CnvSng(.TxtGLToYear.Text)
      WrkAsofDate = .DtPckAsof.Value.Date
      If Date.Today > .DtPckAsof.Value.Date Then
        WrkCalcAsof = True
      Else
        WrkCalcAsof = False
      End If
      WrkStatus = .TxtStatus.Text
      WrkOmitStatus = False
      If .ChkOmitStatus.Checked Then
        WrkOmitStatus = True
      End If
      WrkOmitAgency = False
      If .ChkOmitAgency.Checked Then
        WrkOmitAgency = True
      End If
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      If .ChkSuspense.Checked Then WrkOmitSuspense = True
      If .RbSortList.Checked Then
        WrkSortBy = "List"
      End If
      If .RbSortName.Checked Then
        WrkSortBy = "Name"
      End If
      WrkBankCode = Trim(.TxtBankCd.Text)
      WrkFmt = String.Empty
      If .RbFmtOrig.Checked Then WrkFmt = "Original"
      If .RbFmtExtendFixed.Checked Then WrkFmt = "ExtendedFixed"
      If .RbFmtExtendCSV.Checked Then WrkFmt = "ExtendedCSV"
      If .RbFmtMailSol.Checked Then WrkFmt = "MailSol"
      WrkGrace = False
      If .ChkGrace.Checked Then
        WrkGrace = True
      End If
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
      dsErr = ds.Clone
    Else
      ds.Clear()
      dsErr.Clear()
      dsTot.Clear()
      ClearTotals()
    End If

    BufferType()
    GetDetail()

Done:
    MyCRViewer = New FrmCrViewer
    With MyCRViewer
      .wrkds = ds
      .wrkdsTot = dsTot
      .wrkdsErr = dsErr
      .WrkAsofDate = Format(WrkAsofDate, "short date")
      .Show()
    End With

  End Sub
  Private Sub ClearTotals()
    WrkTCount = 0
    WrkTAmtDue = 0
    WrkTInterest = 0
    WrkTFees = 0
    WrkTLiens = 0
    WrkTBond = 0
    WrkTTotal = 0
  End Sub
  Private Sub GetDetail()
    Dim sw As StreamWriter = New StreamWriter(MyFrmTX810B.LblFilePath.Text)
    Dim WrkQry As String
    Dim WrkSort As String
    Dim K As Integer
    Dim SaveYear As Integer
    Dim SaveType As String

    Dim WrkDue As Decimal
    Dim WrkFee As Decimal

    Dim Pos As Integer
    Dim WrkInterest As Decimal
    Dim WrkBond As Decimal
    Dim WrkFees As Decimal
    Dim WrkLiens As Decimal
    Dim WrkTax As Decimal
    Dim WrkPrinPaid As Decimal
    Dim WrkGracePeriod As Boolean
    Dim Good As Boolean
    Dim Counter As Integer
    Dim WrkStr As String

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    myTXMVFEE.GetOneRecordP(1)
    If Not myTXMVFEE.RecordNotFound Then
      WrkFee = myTXMVFEE._MVFEE
    End If

    WrkQry = "icode<>'I'" & WrkAnd & "icode<>'D'"
    If Not WrkDistAll Then
      WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
    End If
    'Filter Grand List Years
    If WrkGLFromYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "year>=" & WrkGLFromYear
    End If
    If WrkGLToYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "year<=" & WrkGLToYear
    End If
    If WrkOmitSuspense Then
      WrkQry = WrkQry & WrkAnd & "icode<>'S'"
    End If
    If WrkOmitAgency Then
      WrkQry = WrkQry & WrkAnd & " AGY=' '"
    End If
    If WrkBankCode > "" Then
      WrkQry = WrkQry & WrkAnd & " BKCD = " & MyUtils.Quo(WrkBankCode)
    End If
    MyTypes = MyFrmTX810B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    WrkSort = "YEAR, TYPE,"
    Select Case WrkSortBy
      Case "List"
        WrkSort = WrkSort & " LIST#"
      Case "Name"
        WrkSort = WrkSort & " NAME"
    End Select

    'WrkQry = WrkQry & WrkAnd & "list#=9391" 'For Testing
    myTXINVQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    SaveType = ""
    Counter = 0

    WrkStr = String.Empty
    Select Case WrkFmt
      Case "ExtendedCSV"
        WrkStr = HdrExtendedCSV()
      Case Else
    End Select
    sw.WriteLine(WrkStr)

ReadNext:
    myTXINVQ.ReadQry()
    If Not myTXINVQ.IsEOF Then
      With myTXINVQ
        Counter = Counter + 1
        If SaveType <> "" And SaveType <> ._TYPE Then
          WriteTotals(SaveYear, SaveType)
          ClearTotals()
          SaveYear = ._YEAR
          SaveType = ._TYPE
        End If
        If SaveYear > 0 And SaveYear <> ._YEAR Then
          WriteTotals(SaveYear, SaveType)
          ClearTotals()
        End If

        SaveYear = ._YEAR
        SaveType = ._TYPE
        'Filter - Status Codes
        If Trim(WrkStatus) > "" Then
          If WrkOmitStatus Then
            'Omit
            Pos = 0
            If Trim(._STCD1) <> "" Then
              Pos = InStr(1, WrkStatus, Trim(._STCD1), 1)
            End If
            If Pos = 0 And Trim(._STCD2) <> "" Then
              Pos = InStr(1, WrkStatus, Trim(._STCD2), 1)
            End If
            If Pos = 0 And Trim(._STCD3) <> "" Then
              Pos = InStr(1, WrkStatus, Trim(._STCD3), 1)
            End If
            If Pos = 0 And Trim(._STCD4) <> "" Then
              Pos = InStr(1, WrkStatus, Trim(._STCD4), 1)
            End If
            If Pos = 0 And Trim(._STCD5) <> "" Then
              Pos = InStr(1, WrkStatus, Trim(._STCD5), 1)
            End If
            If Pos > 0 Then GoTo NextRec
          Else
            'Select
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
          End If
        End If

        If WrkCalcAsof Then
          CalcAsof(._LISTNo, ._YEAR, ._TYPE, WrkInterest, WrkFees, WrkLiens, WrkBond,
        WrkTax, WrkDue, WrkPrinPaid, WrkGracePeriod)
        Else
          CalcInt(._LISTNo, ._YEAR, ._TYPE, WrkInterest, WrkFees, WrkLiens, WrkBond,
        WrkTax, WrkDue, WrkGracePeriod)
          WrkPrinPaid = ._PAYREC
        End If
        'Filter - Omit no amount due 
        If WrkDue <= 0 Then
          GoTo NextRec
        End If
        If WrkGrace And WrkGracePeriod Then
          GoTo NextRec
        End If

        dr = ds.Tables(0).NewRow
        Select Case WrkSortBy
          Case "Name"
            dr.Item("sortdata") = ._NAME
          Case "List"
            dr.Item("sortdata") = Format(._LISTNo, "000000")
        End Select
        dr.Item("listno") = ._LISTNo
        dr.Item("year") = ._YEAR
        K = LookupType(._TYPE)
        dr.Item("typedesc") = WrkDesc(K)
        dr.Item("name") = Trim(._NAME)
        dr.Item("amtdue") = Format(WrkTax, "fixed")
        dr.Item("Interest") = Format(WrkInterest, "fixed")
        dr.Item("fees") = Format(WrkFees, "fixed")
        dr.Item("liens") = Format(WrkLiens, "fixed")
        dr.Item("bond") = Format(WrkBond, "fixed")
        dr.Item("total") = Format(WrkDue, "fixed")
        ds.Tables(0).Rows.Add(dr)
        dr = Nothing

        WrkTCount = WrkTCount + 1
        WrkTAmtDue = WrkTAmtDue + WrkTax
        WrkTInterest = WrkTInterest + WrkInterest
        WrkTFees = WrkTFees + WrkFees
        WrkTLiens = WrkTLiens + WrkLiens
        WrkTBond = WrkTBond + WrkBond
        WrkTTotal = WrkTTotal + WrkDue

        'Write all fields to text file
        WrkStr = String.Empty
        Select Case WrkFmt
          Case "Original"
            WrkStr = BuildOrig(WrkDue, WrkTax, WrkInterest, WrkBond, WrkLiens, WrkPrinPaid)
          Case "ExtendedFixed"
            WrkStr = BuildOrig(WrkDue, WrkTax, WrkInterest, WrkBond, WrkLiens, WrkPrinPaid)
            WrkStr = WrkStr & BuildExtendedFixed(WrkFees)
          Case "ExtendedCSV"
            WrkStr = BuildExtendedCSV(WrkDue, WrkTax, WrkInterest, WrkBond, WrkLiens, WrkPrinPaid, WrkFees)
          Case "MailSol"
            WrkStr = BuildMailSol(WrkDue, WrkTax, WrkInterest, WrkFees + WrkBond + WrkLiens)
        End Select
        sw.WriteLine(WrkStr)

        If WrkFmt = "Original" And Len(WrkStr) <> CLenOrig Or WrkFmt = "Extended" And Len(WrkStr) <> CLenExtend Then
          dr = dsErr.Tables(0).NewRow
          Select Case WrkSortBy
            Case "Name"
              dr.Item("sortdata") = ._NAME
            Case "List"
              dr.Item("sortdata") = Format(._LISTNo, "000000")
          End Select
          dr.Item("listno") = ._LISTNo
          dr.Item("year") = ._YEAR
          K = LookupType(._TYPE)
          dr.Item("typedesc") = WrkDesc(K)
          dr.Item("name") = Trim(._NAME)
          dr.Item("amtdue") = Format(WrkTax, "fixed")
          dr.Item("Interest") = Format(WrkInterest, "fixed")
          dr.Item("fees") = Format(WrkFees, "fixed")
          dr.Item("liens") = Format(WrkLiens, "fixed")
          dr.Item("bond") = Format(WrkBond, "fixed")
          dr.Item("total") = Format(WrkDue, "fixed")
          dsErr.Tables(0).Rows.Add(dr)
          dr = Nothing
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
        GoTo ReadNext
      End With
    End If

    WriteTotals(SaveYear, SaveType)
    sw.Close()
    myFrmProgress.Close()
    myTXINVQ.CloseFile()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTableTot As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("SortData", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("AmtDue", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Fees", Type.GetType("System.Decimal"))
      .Columns.Add("Liens", Type.GetType("System.Decimal"))
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)

    With myTableTot
      .TableName = "mytabletot"
      .Columns.Add("TCount", Type.GetType("System.Int32"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("TAmtDue", Type.GetType("System.Decimal"))
      .Columns.Add("TInterest", Type.GetType("System.Decimal"))
      .Columns.Add("TFees", Type.GetType("System.Decimal"))
      .Columns.Add("TLiens", Type.GetType("System.Decimal"))
      .Columns.Add("TBond", Type.GetType("System.Decimal"))
      .Columns.Add("TTotal", Type.GetType("System.Decimal"))
    End With
    dsTot.Tables.Add(myTableTot)
  End Sub
  Private Sub WriteTotals(ByVal SaveYear As Integer, ByVal SaveType As String)
    Dim K As Integer
    If WrkTCount = 0 Then Exit Sub

    dr = dsTot.Tables(0).NewRow
    dr.Item("tcount") = WrkTCount
    dr.Item("year") = SaveYear
    K = LookupType(SaveType)
    dr.Item("typedesc") = WrkDesc(K)
    dr.Item("tamtdue") = WrkTAmtDue
    dr.Item("tinterest") = WrkTInterest
    dr.Item("tfees") = WrkTFees
    dr.Item("tliens") = WrkTLiens
    dr.Item("tbond") = WrkTBond
    dr.Item("ttotal") = WrkTTotal
    dsTot.Tables(0).Rows.Add(dr)
    dr = Nothing
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
  Public Sub CalcAsof(ByVal wrklist As Integer, ByVal wrkyear As Integer,
    ByVal wrktype As String, ByRef OutInterest As Decimal, ByRef OutFee As Decimal,
    ByRef OutLien As Decimal, ByRef OutBond As Decimal, ByRef OutTax As Decimal,
    ByRef OutDue As Decimal, ByRef OutPrinPaid As Decimal, ByRef OutGracePeriod As Boolean)

    With myCASHASOF
      .In_AsofDate = WrkAsofDate
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
      OutGracePeriod = .Out_GracePeriod
    End With
  End Sub
  Public Sub CalcInt(ByVal wrklist As Integer, ByVal wrkyear As Integer,
    ByVal wrktype As String, ByRef OutInterest As Decimal, ByRef OutFee As Decimal,
    ByRef OutLien As Decimal, ByRef OutBond As Decimal, ByRef OutTax As Decimal,
    ByRef OutDue As Decimal, ByRef OutGracePeriod As Boolean)

    With myCASHINT
      .In_IntDate = WrkAsofDate
      .In_ListNo = wrklist
      .In_Type = wrktype
      .In_Year = wrkyear
      .CalcInterest()
      OutInterest = Format(.Out_Int(), "standard")
      OutFee = Format(.Out_Fee(), "standard")
      OutLien = Format(.Out_Lien(), "standard")
      OutBond = Format(.Out_Bond(), "standard")
      OutTax = Format(.Out_Prin(), "standard")
      OutDue = Format(.Out_Tot(), "standard")
      OutGracePeriod = .Out_GracePeriod
    End With
  End Sub
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
  Private Function LookupType(ByVal Type As String) As Integer
    Dim I As Integer

    For I = 0 To WrkCode.GetUpperBound(0)
      If WrkCode(I) = "" Then
        Return 0
      End If
      If Type = WrkCode(I) Then
        Return I
      End If
    Next

    Return 0
  End Function
  Private Function BuildOrig(ByVal WrkDue As Decimal, ByVal WrkTax As Decimal, ByVal WrkInterest As Decimal,
  ByVal WrkBond As Decimal, ByVal WrkLiens As Decimal, ByVal WrkPrinPaid As Decimal) As String
    Dim sb As StringBuilder
    Dim wrkinteger As Integer
    Dim WrkTax1 As Decimal
    Dim WrkTax2 As Decimal
    Dim WrkTax3 As Decimal
    Dim WrkTax4 As Decimal
    Dim WrkLeft As Decimal
    With myTXINVQ
      sb = New StringBuilder
      sb.Append(Format(._LISTNo, "000000"))
      sb.Append(Format(._YEAR, "0000"))
      sb.Append(._TYPE)
      sb.Append(MyUtils.JustifyLeft(._NAME, 35))
      sb.Append(MyUtils.JustifyLeft(._SNAME, 35))
      sb.Append(MyUtils.JustifyLeft(._ADD1, 35))
      sb.Append(MyUtils.JustifyLeft(._ADD2, 35))
      sb.Append(MyUtils.JustifyLeft(._CITY, 25))
      sb.Append(MyUtils.JustifyLeft(._STATE, 2))
      sb.Append(Format(._ZIP5, "00000"))
      sb.Append(Format(._ZIP4, "0000"))
      wrkinteger = WrkDue * 100
      sb.Append(Format(wrkinteger, "000000000"))
      If ._CCNO > 0 Then
        wrkinteger = ._CCETAX * 100
      Else
        wrkinteger = ._TAXT * 100
      End If
      sb.Append(Format(wrkinteger, "00000000000"))
      wrkinteger = WrkPrinPaid * 100
      sb.Append(Format(wrkinteger, "00000000000"))
      WrkLeft = WrkTax
      If ._CCNO > 0 Then
        WrkTax1 = ._CCTX1
        WrkTax2 = ._CCTX2
        WrkTax3 = ._CCTX3
        WrkTax4 = ._CCTX4
      Else
        WrkTax1 = ._TAX1
        WrkTax2 = ._TAX2
        WrkTax3 = ._TX3RD
        WrkTax4 = ._TX4TH
      End If
      If WrkLeft >= WrkTax1 Then
        WrkLeft = WrkLeft - WrkTax1
      Else
        WrkTax1 = WrkLeft
        WrkLeft = 0
      End If
      If WrkLeft >= WrkTax2 Then
        WrkLeft = WrkLeft - WrkTax2
      Else
        WrkTax2 = WrkLeft
        WrkLeft = 0
      End If
      If WrkLeft >= WrkTax3 Then
        WrkLeft = WrkLeft - WrkTax3
      Else
        WrkTax3 = WrkLeft
        WrkLeft = 0
      End If
      WrkTax4 = WrkLeft
      wrkinteger = WrkTax * 100
      sb.Append(Format(wrkinteger, "00000000000"))
      wrkinteger = WrkTax1 * 100  'Remaining Tax 1st
      sb.Append(Format(wrkinteger, "00000000000"))
      wrkinteger = WrkTax2 * 100 'Remaining Tax 2nd
      sb.Append(Format(wrkinteger, "00000000000"))
      wrkinteger = WrkTax3 * 100 'Remaining Tax 3rd
      sb.Append(Format(wrkinteger, "00000000000"))
      wrkinteger = WrkTax4 * 100 'Remaining Tax 4th
      sb.Append(Format(wrkinteger, "00000000000"))
      wrkinteger = WrkInterest * 100
      sb.Append(Format(wrkinteger, "00000000000"))
      wrkinteger = WrkLiens * 100
      sb.Append(Format(wrkinteger, "00000"))
      wrkinteger = WrkBond * 100
      sb.Append(Format(wrkinteger, "00000000000"))
      sb.Append(Format(._TXIDT, "00000000"))
      sb.Append(MyUtils.JustifyLeft(._VOL, 5))
      sb.Append(MyUtils.JustifyLeft(._IPAGE, 5))
      sb.Append(MyUtils.JustifyRight(Trim(._LOCNo), 7))
      sb.Append(MyUtils.JustifyLeft(._LOC, 25))
      sb.Append(MyUtils.JustifyLeft(._MAP, 17))
      sb.Append(Format(._DIST, "000"))
      sb.Append(Format(._GROSS, "000000000"))
      sb.Append(Format(._TOTEXP, "000000000"))
      sb.Append(Format(._NETASS, "000000000"))
      sb.Append(MyUtils.JustifyLeft(._LIEN, 1))
      sb.Append(MyUtils.JustifyLeft(._SUSCD, 1))
      sb.Append(Format(._SUSDT, "00000000"))
      sb.Append(Format(._CCNO, "00000"))
      sb.Append(Format(._CGRS, "000000000"))
      sb.Append(Format(._CCEXP, "000000000"))
      sb.Append(Format(._CDATE, "00000000"))
      sb.Append(MyUtils.JustifyLeft(._CCRSN, 1))
      sb.Append(MyUtils.JustifyLeft(._BKSR, 1))
      sb.Append(MyUtils.JustifyLeft(._BKCD, 2))
      sb.Append(Format(._IPPCD1, "000"))
      sb.Append(Format(._IPPCD2, "000"))
      sb.Append(Format(._IPPCD3, "000"))
      sb.Append(Format(._IPPCD4, "000"))
      sb.Append(Format(._IPPCD5, "000"))
      sb.Append(Format(._IPPCD6, "000"))
      sb.Append(Format(._IPPCD7, "000"))
      sb.Append(Format(._IPPCD8, "000"))
      sb.Append(Format(._IPPCD9, "000"))
      sb.Append(Format(._IPPCDA, "000"))
      sb.Append(Format(._DOB, "00000000"))
      sb.Append(Format(._OAS1, "000000000"))
      sb.Append(Format(._OAS2, "000000000"))
      sb.Append(Format(._OAS3, "000000000"))
      sb.Append(Format(._OAS4, "000000000"))
      sb.Append(Format(._OAS5, "000000000"))
      sb.Append(Format(._OAS6, "000000000"))
      sb.Append(Format(._OAS7, "000000000"))
      sb.Append(Format(._OAS8, "000000000"))
      sb.Append(Format(._OAS9, "000000000"))
      sb.Append(Format(._OAS10, "000000000"))
      sb.Append(Format(._CASS1, "000000000"))
      sb.Append(Format(._CASS2, "000000000"))
      sb.Append(Format(._CASS3, "000000000"))
      sb.Append(Format(._CASS4, "000000000"))
      sb.Append(Format(._CASS5, "000000000"))
      sb.Append(Format(._CASS6, "000000000"))
      sb.Append(Format(._CASS7, "000000000"))
      sb.Append(Format(._CASS8, "000000000"))
      sb.Append(Format(._CASS9, "000000000"))
      sb.Append(Format(._CASS10, "000000000"))
      sb.Append(Format(._UNIT1, "000"))
      sb.Append(Format(._UNIT2, "000"))
      sb.Append(Format(._UNIT3, "000"))
      sb.Append(Format(._UNIT4, "000"))
      sb.Append(Format(._UNIT5, "000"))
      sb.Append(Format(._UNIT6, "000"))
      sb.Append(Format(._UNIT7, "000"))
      sb.Append(Format(._UNIT8, "000"))
      sb.Append(Format(._UNIT9, "000"))
      sb.Append(Format(._UNITA, "000"))
      sb.Append(MyUtils.JustifyLeft(._EXCD1, 3))
      sb.Append(MyUtils.JustifyLeft(._EXCD2, 3))
      sb.Append(MyUtils.JustifyLeft(._EXCD3, 3))
      sb.Append(MyUtils.JustifyLeft(._EXCD4, 3))
      sb.Append(MyUtils.JustifyLeft(._EXCD5, 3))
      sb.Append(MyUtils.JustifyLeft(._EXCD6, 3))
      sb.Append(MyUtils.JustifyLeft(._EXCD7, 3))
      sb.Append(Format(._EXAM1, "0000000"))
      sb.Append(Format(._EXAM2, "0000000"))
      sb.Append(Format(._EXAM3, "0000000"))
      sb.Append(Format(._EXAM4, "0000000"))
      sb.Append(Format(._EXAM5, "0000000"))
      sb.Append(Format(._EXAM6, "0000000"))
      sb.Append(Format(._EXAM7, "0000000"))
      sb.Append(MyUtils.JustifyLeft(._CCCD1, 3))
      sb.Append(MyUtils.JustifyLeft(._CCCD2, 3))
      sb.Append(MyUtils.JustifyLeft(._CCCD3, 3))
      sb.Append(MyUtils.JustifyLeft(._CCCD4, 3))
      sb.Append(MyUtils.JustifyLeft(._CCCD5, 3))
      sb.Append(MyUtils.JustifyLeft(._CCCD6, 3))
      sb.Append(MyUtils.JustifyLeft(._CCCD7, 3))
      sb.Append(Format(._CEXA1, "0000000"))
      sb.Append(Format(._CEXA2, "0000000"))
      sb.Append(Format(._CEXA3, "0000000"))
      sb.Append(Format(._CEXA4, "0000000"))
      sb.Append(Format(._CEXA5, "0000000"))
      sb.Append(Format(._CEXA6, "0000000"))
      sb.Append(Format(._CEXA7, "0000000"))
      sb.Append(MyUtils.JustifyLeft(._ASS, 1))
      wrkinteger = ._INTPD * 100
      sb.Append(Format(wrkinteger, "0000000"))
      wrkinteger = ._TXINT * 100
      sb.Append(Format(wrkinteger, "0000000"))
      wrkinteger = ._LNPD * 100
      sb.Append(Format(wrkinteger, "00000"))
      wrkinteger = ._BONDP * 100
      sb.Append(Format(wrkinteger, "000000000"))
      sb.Append(MyUtils.JustifyLeft(._STCD1, 1))
      sb.Append(MyUtils.JustifyLeft(._STCD2, 1))
      sb.Append(MyUtils.JustifyLeft(._STCD3, 1))
      sb.Append(MyUtils.JustifyLeft(._STCD4, 1))
      sb.Append(MyUtils.JustifyLeft(._STCD5, 1))
    End With
    Return sb.ToString
  End Function
  Private Function BuildExtendedFixed(ByVal WrkFees As Decimal) As String
    Dim sb As StringBuilder
    Dim wrkinteger As Integer
    With myTXINVQ
      sb = New StringBuilder
      wrkinteger = WrkFees * 100 'Fee
      sb.Append(Format(wrkinteger, "000000000"))
      sb.Append(MyUtils.JustifyLeft(._IMVREG, 8))
      sb.Append(MyUtils.JustifyLeft(._MODEL, 8))
      sb.Append(MyUtils.JustifyLeft(._MAKE, 5))
      sb.Append(Format(._MVYR, "0000"))
      sb.Append(Format(._CLASS, "00"))
      sb.Append(MyUtils.JustifyLeft(._IMVIDNo, 17))
    End With
    Return sb.ToString
  End Function
  Private Function HdrExtendedCSV() As String
    Dim sb As StringBuilder
    sb = New StringBuilder
    sb.Append("LISTNO")
    sb.Append(",")
    sb.Append("YEAR")
    sb.Append(",")
    sb.Append("TYPE")
    sb.Append(",")
    sb.Append("NAME")
    sb.Append(",")
    sb.Append("SECOND NAME")
    sb.Append(",")
    sb.Append("ADDRESS 1")
    sb.Append(",")
    sb.Append("ADDRESS 2")
    sb.Append(",")
    sb.Append("CITY")
    sb.Append(",")
    sb.Append("STATE")
    sb.Append(",")
    sb.Append("ZIP 5")
    sb.Append(",")
    sb.Append("ZIP 4")
    sb.Append(",")
    sb.Append("TOTAL DUE")
    sb.Append(",")
    sb.Append("TAX TOTAL")
    sb.Append(",")
    sb.Append("PRINCIPAL PAID")
    sb.Append(",")
    sb.Append(",")
    sb.Append("TAX DUE")
    sb.Append(",")
    sb.Append("TAX DUE 1ST") 'Remaining Tax 1st
    sb.Append(",")
    sb.Append("TAX DUE 2ND") 'Remaining Tax 2nd
    sb.Append(",")
    sb.Append("TAX DUE 3RD") 'Remaining Tax 3rd
    sb.Append(",")
    sb.Append("TAX DUE 4TH") 'Remaining Tax 4th
    sb.Append(",")
    sb.Append("INTEREST")
    sb.Append(",")
    sb.Append("LIENS")
    sb.Append(",")
    sb.Append("BOND INTEREST")
    sb.Append(",")
    sb.Append("INTEREST DATE")
    sb.Append(",")
    sb.Append("VOL")
    sb.Append(",")
    sb.Append("PAGE")
    sb.Append(",")
    sb.Append("LOC No")
    sb.Append(",")
    sb.Append("LOC")
    sb.Append(",")
    sb.Append("MAP")
    sb.Append(",")
    sb.Append("DIST")
    sb.Append(",")
    sb.Append("GROSS")
    sb.Append(",")
    sb.Append("EXEMPTIONS")
    sb.Append(",")
    sb.Append("NET")
    sb.Append(",")
    sb.Append("LIEN CODE")
    sb.Append(",")
    sb.Append("SUSPENSE CODE")
    sb.Append(",")
    sb.Append("SUSPENSE DATE")
    sb.Append(",")
    sb.Append("C/C NO")
    sb.Append(",")
    sb.Append("C/C GROSS")
    sb.Append(",")
    sb.Append("C/C EXEMPTIONS")
    sb.Append(",")
    sb.Append("C/C DATE")
    sb.Append(",")
    sb.Append("C/C REASON")
    sb.Append(",")
    sb.Append("BANK SVC")
    sb.Append(",")
    sb.Append("BANK CODE")
    sb.Append(",")
    sb.Append("PROPERTY CODE 1")
    sb.Append(",")
    sb.Append("PROPERTY CODE 2")
    sb.Append(",")
    sb.Append("PROPERTY CODE 3")
    sb.Append(",")
    sb.Append("PROPERTY CODE 4")
    sb.Append(",")
    sb.Append("PROPERTY CODE 5")
    sb.Append(",")
    sb.Append("PROPERTY CODE 6")
    sb.Append(",")
    sb.Append("PROPERTY CODE 7")
    sb.Append(",")
    sb.Append("PROPERTY CODE 8")
    sb.Append(",")
    sb.Append("PROPERTY CODE 9")
    sb.Append(",")
    sb.Append("PROPERTY CODE 10")
    sb.Append(",")
    sb.Append("DOB")
    sb.Append(",")
    sb.Append("ASSESSMENT AMT 1")
    sb.Append(",")
    sb.Append("ASSESSMENT AMT 2")
    sb.Append(",")
    sb.Append("ASSESSMENT AMT 3")
    sb.Append(",")
    sb.Append("ASSESSMENT AMT 4")
    sb.Append(",")
    sb.Append("ASSESSMENT AMT 5")
    sb.Append(",")
    sb.Append("ASSESSMENT AMT 6")
    sb.Append(",")
    sb.Append("ASSESSMENT AMT 7")
    sb.Append(",")
    sb.Append("ASSESSMENT AMT 8")
    sb.Append(",")
    sb.Append("ASSESSMENT AMT 9")
    sb.Append(",")
    sb.Append("ASSESSMENT AMT 10")
    sb.Append(",")
    sb.Append("C/C ASSESSMENT AMT S1")
    sb.Append(",")
    sb.Append("C/C ASSESSMENT AMT S2")
    sb.Append(",")
    sb.Append("C/C ASSESSMENT AMT S3")
    sb.Append(",")
    sb.Append("C/C ASSESSMENT AMT S4")
    sb.Append(",")
    sb.Append("C/C ASSESSMENT AMT S5")
    sb.Append(",")
    sb.Append("C/C ASSESSMENT AMT S6")
    sb.Append(",")
    sb.Append("C/C ASSESSMENT AMT S7")
    sb.Append(",")
    sb.Append("C/C ASSESSMENT AMT S8")
    sb.Append(",")
    sb.Append("C/C ASSESSMENT AMT S9")
    sb.Append(",")
    sb.Append("C/C ASSESSMENT AMT S10")
    sb.Append(",")
    sb.Append("UNIT 1")
    sb.Append(",")
    sb.Append("UNIT 2")
    sb.Append(",")
    sb.Append("UNIT 3")
    sb.Append(",")
    sb.Append("UNIT 4")
    sb.Append(",")
    sb.Append("UNIT 5")
    sb.Append(",")
    sb.Append("UNIT 6")
    sb.Append(",")
    sb.Append("UNIT 7")
    sb.Append(",")
    sb.Append("UNIT 8")
    sb.Append(",")
    sb.Append("UNIT 9")
    sb.Append(",")
    sb.Append("UNIT 10")
    sb.Append(",")
    sb.Append("EXEMPTION CODE 1")
    sb.Append(",")
    sb.Append("EXEMPTION CODE 2")
    sb.Append(",")
    sb.Append("EXEMPTION CODE 3")
    sb.Append(",")
    sb.Append("EXEMPTION CODE 4")
    sb.Append(",")
    sb.Append("EXEMPTION CODE 5")
    sb.Append(",")
    sb.Append("EXEMPTION CODE 6")
    sb.Append(",")
    sb.Append("EXEMPTION CODE 7")
    sb.Append(",")
    sb.Append("EXEMPTION AMT 1")
    sb.Append(",")
    sb.Append("EXEMPTION AMT 2")
    sb.Append(",")
    sb.Append("EXEMPTION AMT 3")
    sb.Append(",")
    sb.Append("EXEMPTION AMT 4")
    sb.Append(",")
    sb.Append("EXEMPTION AMT 5")
    sb.Append(",")
    sb.Append("EXEMPTION AMT 6")
    sb.Append(",")
    sb.Append("EXEMPTION AMT 7")
    sb.Append(",")
    sb.Append("C/C PROPERTY CODE 1")
    sb.Append(",")
    sb.Append("C/C PROPERTY CODE 2")
    sb.Append(",")
    sb.Append("C/C PROPERTY CODE 3")
    sb.Append(",")
    sb.Append("C/C PROPERTY CODE 4")
    sb.Append(",")
    sb.Append("C/C PROPERTY CODE 5")
    sb.Append(",")
    sb.Append("C/C PROPERTY CODE 6")
    sb.Append(",")
    sb.Append("C/C PROPERTY CODE 7")
    sb.Append(",")
    sb.Append("C/C EXEMPTION AMT 1")
    sb.Append(",")
    sb.Append("C/C EXEMPTION AMT 2")
    sb.Append(",")
    sb.Append("C/C EXEMPTION AMT 3")
    sb.Append(",")
    sb.Append("C/C EXEMPTION AMT 4")
    sb.Append(",")
    sb.Append("C/C EXEMPTION AMT 5")
    sb.Append(",")
    sb.Append("C/C EXEMPTION AMT 6")
    sb.Append(",")
    sb.Append("C/C EXEMPTION AMT 7")
    sb.Append(",")
    sb.Append("MV ASSESSMENT CODE")
    sb.Append(",")
    sb.Append("INTEREST PAID")
    sb.Append(",")
    sb.Append("INTEREST DATE")
    sb.Append(",")
    sb.Append("LIEN PAID")
    sb.Append(",")
    sb.Append("BOND PAID")
    sb.Append(",")
    sb.Append("STATUS CODE 1")
    sb.Append(",")
    sb.Append("STATUS CODE 2")
    sb.Append(",")
    sb.Append("STATUS CODE 3")
    sb.Append(",")
    sb.Append("STATUS CODE 4")
    sb.Append(",")
    sb.Append("STATUS CODE 5")
    sb.Append(",")
    sb.Append("FEES")
    sb.Append(",")
    sb.Append("PLATE")
    sb.Append(",")
    sb.Append("MODEL")
    sb.Append(",")
    sb.Append("MAKE")
    sb.Append(",")
    sb.Append("MV YEAR")
    sb.Append(",")
    sb.Append("CLASS")
    sb.Append(",")
    sb.Append("VIN")
    Return sb.ToString
  End Function
  Private Function BuildExtendedCSV(ByVal WrkDue As Decimal, ByVal WrkTax As Decimal, ByVal WrkInterest As Decimal,
  ByVal WrkBond As Decimal, ByVal WrkLiens As Decimal, ByVal WrkPrinPaid As Decimal, ByVal WrkFees As Decimal) As String
    Dim sb As StringBuilder
    Dim WrkTax1 As Decimal
    Dim WrkTax2 As Decimal
    Dim WrkTax3 As Decimal
    Dim WrkTax4 As Decimal
    Dim WrkLeft As Decimal
    With myTXINVQ
      sb = New StringBuilder
      sb.Append(._LISTNo)
      sb.Append(",")
      sb.Append(._YEAR)
      sb.Append(",")
      sb.Append(._TYPE)
      sb.Append(",")
      sb.Append(Trim(._NAME))
      sb.Append(",")
      sb.Append(Trim(._SNAME))
      sb.Append(",")
      sb.Append(Trim(._ADD1))
      sb.Append(",")
      sb.Append(Trim(._ADD2))
      sb.Append(",")
      sb.Append(Trim(._CITY))
      sb.Append(",")
      sb.Append(Trim(._STATE))
      sb.Append(",")
      sb.Append(._ZIP5)
      sb.Append(",")
      sb.Append(Format(._ZIP4, "0000"))
      sb.Append(",")
      sb.Append(Format(WrkDue, "fixed"))
      sb.Append(",")
      If ._CCNO > 0 Then
        sb.Append(Format(._CCETAX, "fixed"))
      Else
        sb.Append(Format(._TAXT, "fixed"))
      End If
      sb.Append(",")
      sb.Append(Format(WrkPrinPaid, "fixed"))
      sb.Append(",")
      WrkLeft = WrkTax
      If ._CCNO > 0 Then
        WrkTax1 = ._CCTX1
        WrkTax2 = ._CCTX2
        WrkTax3 = ._CCTX3
        WrkTax4 = ._CCTX4
      Else
        WrkTax1 = ._TAX1
        WrkTax2 = ._TAX2
        WrkTax3 = ._TX3RD
        WrkTax4 = ._TX4TH
      End If
      If WrkLeft >= WrkTax1 Then
        WrkLeft = WrkLeft - WrkTax1
      Else
        WrkTax1 = WrkLeft
        WrkLeft = 0
      End If
      If WrkLeft >= WrkTax2 Then
        WrkLeft = WrkLeft - WrkTax2
      Else
        WrkTax2 = WrkLeft
        WrkLeft = 0
      End If
      If WrkLeft >= WrkTax3 Then
        WrkLeft = WrkLeft - WrkTax3
      Else
        WrkTax3 = WrkLeft
        WrkLeft = 0
      End If
      WrkTax4 = WrkLeft
      sb.Append(",")
      sb.Append(Format(WrkTax, "fixed"))
      sb.Append(",")
      sb.Append(Format(WrkTax1, "fixed")) 'Remaining Tax 1st
      sb.Append(",")
      sb.Append(Format(WrkTax2, "fixed")) 'Remaining Tax 2nd
      sb.Append(",")
      sb.Append(Format(WrkTax3, "fixed")) 'Remaining Tax 3rd
      sb.Append(",")
      sb.Append(Format(WrkTax4, "fixed")) 'Remaining Tax 4th
      sb.Append(",")
      sb.Append(Format(WrkInterest, "fixed"))
      sb.Append(",")
      sb.Append(Format(WrkLiens, "fixed"))
      sb.Append(",")
      sb.Append(Format(WrkBond, "fixed"))
      sb.Append(",")
      If ._TXIDT > 0 Then
        sb.Append(Format(MyUtils.GetDBDate(._TXIDT), "M/d/yyyy"))
      Else
        sb.Append("")
      End If
      sb.Append(",")
      sb.Append(Trim(._VOL))
      sb.Append(",")
      sb.Append(Trim(._IPAGE))
      sb.Append(",")
      sb.Append(Trim(._LOCNo))
      sb.Append(",")
      sb.Append(Trim(._LOC))
      sb.Append(",")
      sb.Append(Trim(._MAP))
      sb.Append(",")
      sb.Append(._DIST)
      sb.Append(",")
      sb.Append(._GROSS)
      sb.Append(",")
      sb.Append(._TOTEXP)
      sb.Append(",")
      sb.Append(._NETASS)
      sb.Append(",")
      sb.Append(Trim(._LIEN))
      sb.Append(",")
      sb.Append(Trim(._SUSCD))
      sb.Append(",")
      If ._SUSDT > 0 Then
        sb.Append(Format(MyUtils.GetDBDate(._SUSDT), "M/d/yyyy"))
      Else
        sb.Append("")
      End If
      sb.Append(",")
      sb.Append(._CCNO)
      sb.Append(",")
      sb.Append(._CGRS)
      sb.Append(",")
      sb.Append(._CCEXP)
      sb.Append(",")
      If ._CDATE > 0 Then
        sb.Append(Format(MyUtils.GetDBDate(._CDATE), "M/d/yyyy"))
      Else
        sb.Append("")
      End If
      sb.Append(",")
      sb.Append(Trim(._CCRSN))
      sb.Append(",")
      sb.Append(Trim(._BKSR))
      sb.Append(",")
      sb.Append(Trim(._BKCD))
      sb.Append(",")
      sb.Append(._IPPCD1)
      sb.Append(",")
      sb.Append(._IPPCD2)
      sb.Append(",")
      sb.Append(._IPPCD3)
      sb.Append(",")
      sb.Append(._IPPCD4)
      sb.Append(",")
      sb.Append(._IPPCD5)
      sb.Append(",")
      sb.Append(._IPPCD6)
      sb.Append(",")
      sb.Append(._IPPCD7)
      sb.Append(",")
      sb.Append(._IPPCD8)
      sb.Append(",")
      sb.Append(._IPPCD9)
      sb.Append(",")
      sb.Append(._IPPCDA)
      sb.Append(",")
      If ._DOB > 0 Then
        sb.Append(Format(MyUtils.GetDBDate(._DOB), "M/d/yyyy"))
      Else
        sb.Append("")
      End If
      sb.Append(",")
      sb.Append(._OAS1)
      sb.Append(",")
      sb.Append(._OAS2)
      sb.Append(",")
      sb.Append(._OAS3)
      sb.Append(",")
      sb.Append(._OAS4)
      sb.Append(",")
      sb.Append(._OAS5)
      sb.Append(",")
      sb.Append(._OAS6)
      sb.Append(",")
      sb.Append(._OAS7)
      sb.Append(",")
      sb.Append(._OAS8)
      sb.Append(",")
      sb.Append(._OAS9)
      sb.Append(",")
      sb.Append(._OAS10)
      sb.Append(",")
      sb.Append(._CASS1)
      sb.Append(",")
      sb.Append(._CASS2)
      sb.Append(",")
      sb.Append(._CASS3)
      sb.Append(",")
      sb.Append(._CASS4)
      sb.Append(",")
      sb.Append(._CASS5)
      sb.Append(",")
      sb.Append(._CASS6)
      sb.Append(",")
      sb.Append(._CASS7)
      sb.Append(",")
      sb.Append(._CASS8)
      sb.Append(",")
      sb.Append(._CASS9)
      sb.Append(",")
      sb.Append(._CASS10)
      sb.Append(",")
      sb.Append(._UNIT1)
      sb.Append(",")
      sb.Append(._UNIT2)
      sb.Append(",")
      sb.Append(._UNIT3)
      sb.Append(",")
      sb.Append(._UNIT4)
      sb.Append(",")
      sb.Append(._UNIT5)
      sb.Append(",")
      sb.Append(._UNIT6)
      sb.Append(",")
      sb.Append(._UNIT7)
      sb.Append(",")
      sb.Append(._UNIT8)
      sb.Append(",")
      sb.Append(._UNIT9)
      sb.Append(",")
      sb.Append(._UNITA)
      sb.Append(",")
      sb.Append(Trim(._EXCD1))
      sb.Append(",")
      sb.Append(Trim(._EXCD2))
      sb.Append(",")
      sb.Append(Trim(._EXCD3))
      sb.Append(",")
      sb.Append(Trim(._EXCD4))
      sb.Append(",")
      sb.Append(Trim(._EXCD5))
      sb.Append(",")
      sb.Append(Trim(._EXCD6))
      sb.Append(",")
      sb.Append(Trim(._EXCD7))
      sb.Append(",")
      sb.Append(._EXAM1)
      sb.Append(",")
      sb.Append(._EXAM2)
      sb.Append(",")
      sb.Append(._EXAM3)
      sb.Append(",")
      sb.Append(._EXAM4)
      sb.Append(",")
      sb.Append(._EXAM5)
      sb.Append(",")
      sb.Append(._EXAM6)
      sb.Append(",")
      sb.Append(._EXAM7)
      sb.Append(",")
      sb.Append(Trim(._CCCD1))
      sb.Append(",")
      sb.Append(Trim(._CCCD2))
      sb.Append(",")
      sb.Append(Trim(._CCCD3))
      sb.Append(",")
      sb.Append(Trim(._CCCD4))
      sb.Append(",")
      sb.Append(Trim(._CCCD5))
      sb.Append(",")
      sb.Append(Trim(._CCCD6))
      sb.Append(",")
      sb.Append(Trim(._CCCD7))
      sb.Append(",")
      sb.Append(._CEXA1)
      sb.Append(",")
      sb.Append(._CEXA2)
      sb.Append(",")
      sb.Append(._CEXA3)
      sb.Append(",")
      sb.Append(._CEXA4)
      sb.Append(",")
      sb.Append(._CEXA5)
      sb.Append(",")
      sb.Append(._CEXA6)
      sb.Append(",")
      sb.Append(._CEXA7)
      sb.Append(",")
      sb.Append(Trim(._ASS))
      sb.Append(",")
      sb.Append(Format(._INTPD, "fixed"))
      sb.Append(",")
      sb.Append(Format(._TXINT, "fixed"))
      sb.Append(",")
      sb.Append(Format(._LNPD, "fixed"))
      sb.Append(",")
      sb.Append(Format(._BONDP, "fixed"))
      sb.Append(",")
      sb.Append(Trim(._STCD1))
      sb.Append(",")
      sb.Append(Trim(._STCD2))
      sb.Append(",")
      sb.Append(Trim(._STCD3))
      sb.Append(",")
      sb.Append(Trim(._STCD4))
      sb.Append(",")
      sb.Append(Trim(._STCD5))
      sb.Append(",")
      sb.Append(Format(WrkFees, "fixed"))
      sb.Append(",")
      sb.Append(Trim(._IMVREG))
      sb.Append(",")
      sb.Append(Trim(._MODEL))
      sb.Append(",")
      sb.Append(Trim(._MAKE))
      sb.Append(",")
      sb.Append(._MVYR)
      sb.Append(",")
      sb.Append(._CLASS)
      sb.Append(",")
      sb.Append(Trim(._IMVIDNo))
    End With
    Return sb.ToString
  End Function
  Private Function BuildMailSol(ByVal WrkDue As Decimal, ByVal WrkTax As Decimal, ByVal WrkInterest As Decimal,
  ByVal WrkLiens As Decimal) As String
    Dim sb As StringBuilder
    Dim WrkLoc As String

    With myTXINVQ
      sb = New StringBuilder
      sb.Append(MyUtils.JustifyLeft(._NAME, 35))
      sb.Append(MyUtils.JustifyLeft(._SNAME, 35))
      sb.Append(MyUtils.JustifyLeft(._ADD1, 35))
      sb.Append(MyUtils.JustifyLeft(._CITY, 25))
      sb.Append(MyUtils.JustifyLeft(._STATE, 3))
      sb.Append(Format(Math.Abs(._ZIP5), "00000 "))
      sb.Append(Format(._YEAR, "0000"))
      Select Case ._TYPE
        Case "M"
          sb.Append("03")
        Case "P"
          sb.Append("02")
        Case "S"
          sb.Append("04")
      End Select
      sb.Append(Format(._LISTNo, "00000000"))
      Select Case ._TYPE
        Case "M", "S"
          sb.Append(MyUtils.JustifyLeft(._MAKE, 6))
          sb.Append(MyUtils.JustifyLeft(._MODEL, 9))
          sb.Append(Format(._MVYR, "0000"))
          sb.Append(Format(._CLASS, "00"))
          sb.Append(MyUtils.JustifyLeft(._IMVREG, 8))
          sb.Append(MyUtils.JustifyLeft(._IMVIDNo, 17))
        Case Else
          WrkLoc = Trim(._LOCNo) & " " & Trim(._LOC)
          sb.Append(MyUtils.JustifyLeft(WrkLoc, 30))
          sb.Append(MyUtils.JustifyLeft("", 16))
      End Select
      sb.Append(MyUtils.JustifyRight(Format(WrkTax, "fixed"), 11))
      sb.Append(MyUtils.JustifyRight(Format(WrkInterest, "fixed"), 11))
      sb.Append(MyUtils.JustifyRight(Format(WrkLiens, "fixed"), 11))
      sb.Append(MyUtils.JustifyRight(Format(WrkDue, "fixed"), 13))
      sb.Append(Format(._NETASS, "0000000000"))
    End With
    Return sb.ToString
  End Function
End Module






