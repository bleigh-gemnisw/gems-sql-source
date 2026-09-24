Imports System.Text
Module PrintReport
  Public MyReportCancel As Boolean
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.myData
  Dim myTXPROF As TXPROF.myData
  Dim myCASHINT As CASHINT.MyData
  Dim WrkReport As Boolean
  Dim WrkPayFirst As Boolean
  Dim WrkMaxLen As Integer
  Dim WrkMod As Integer
  Dim WrkGLYear As Integer
  Dim WrkOmitMail As Boolean
  Dim WrkOmitDelq As Boolean
  Dim WrkNewOwner As Boolean
  Dim WrkBalances As Boolean
  Dim WrkNonEscrow As Boolean
  Dim WrkNonEscrowBank As Boolean
  Dim WrkShowList As Boolean
  Dim WrkHAdjust1 As Integer
  Dim WrkHAdjust2 As Integer
  Dim WrkHAdjust3 As Integer
  Dim WrkSortBy As String
  Dim WrkAnd As String
  Dim WrkOr As String
  Dim DsFile As DataSet = New DataSet
  'Buffer Banks
  Dim WrkBanksCode(500) As String
  Dim WrkBanksPrnt(500) As Boolean
  'Buffer Types
  Dim WrkCode(50) As String
  Dim WrkDesc(50) As String
  Dim WrkFamily(50) As String

  Public Sub PrtReport()

    myTXINVQ = New TXINVQ.mydata(MyDBConnect)
    myTXPROF = New TXPROF.mydata(MyDBConnect)
    myCASHINT = New CASHINT.mydata(MyDBConnect)

    With MyFrmTXE12B
      WrkPayFirst = False
      If .RbPayFirst.Checked Then
        WrkPayFirst = True
      End If
      WrkReport = False
      If .RbReport.Checked Then
        WrkReport = True
      End If
      If .RbSortName.Checked Then WrkSortBy = "Name"
      If .RbSortZip.Checked Then WrkSortBy = "Zip"
      WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
      WrkOmitMail = False
      If .ChkOmitMail.Checked Then
        WrkOmitMail = True
      End If
      WrkOmitDelq = False
      If .ChkOmitDelq.Checked Then
        WrkOmitDelq = True
      End If
      WrkNewOwner = False
      If .ChkNewOwner.Checked Then
        WrkNewOwner = True
      End If
      WrkBalances = False
      If .ChkBalances.Checked Then
        WrkBalances = True
      End If
      WrkNonEscrow = .RbSelNon.Checked
      WrkNonEscrowBank = .RbSelNonBanks.Checked
      WrkShowList = .ChkShowList.Checked
      If .Rb1Across.Checked Then WrkMod = 1
      If .Rb2Across.Checked Then WrkMod = 2
      If .Rb3Across.Checked Then WrkMod = 3
      WrkMaxLen = MyUtils.CnvSng(.TxtMaxLen.Text)
      WrkHAdjust1 = MyUtils.CnvSng(.TxtHAdjust1.Text)
      WrkHAdjust2 = MyUtils.CnvSng(.TxtHAdjust2.Text)
      WrkHAdjust3 = MyUtils.CnvSng(.TxtHAdjust3.Text)

    End With

    ds = New DataSet
    If ds.Tables.Count = 0 Then
      If WrkReport Then
        BuildDS()
      Else
        BuildDSLbl()
      End If
    Else
      ds.Clear()
    End If

    BufferBanksEscrow()
    BufferType()
    GetDetail()

    myTXPROF.GetOneRecordP(Mid(MyFrmTXE12B.TxtTypes.Text, 1, 1), WrkGLYear, "", 0)
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .WrkReport = WrkReport
      .Wrkds = ds
      If WrkPayFirst Then
        .WrkDueDate = myTXPROF._PRDUE1
        .WrkGraceDate = myTXPROF._PRGRD1
      Else
        .WrkDueDate = myTXPROF._PRDUE2
        .WrkGraceDate = myTXPROF._PRGRD2
      End If
      .Show()
    End With
    ds = Nothing
  End Sub
  Private Sub GetDetail()
    Dim AddrLine() As String
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkTXType As String()
    Dim SaveSortData As String
    Dim RecCounter As Integer
    Dim LblCounter As Integer
    Dim sb0 As StringBuilder
    Dim sb1 As StringBuilder
    Dim sb2 As StringBuilder
    Dim sb3 As StringBuilder
    Dim sb4 As StringBuilder
    Dim sb5 As StringBuilder
    Dim WrkNew As Boolean
    Dim WrkEscrowPrint As Boolean
    Dim WrkBankCode As String
    Dim WrkTypes As String
    Dim WrkBal As Decimal
    Dim WrkDue As Decimal
    Dim WrkInt As Decimal

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    RecCounter = 0
    LblCounter = 0
    WrkQry = String.Empty
    WrkSort = String.Empty
    Select Case WrkSortBy
      Case "Name"
        WrkSort = "NAME"
      Case "Zip"
        WrkSort = "ZIP5, ZIP4, NAME"
    End Select

    WrkQry = "icode<>'I'" & WrkAnd & "YEAR = " & WrkGLYear
    If WrkOmitMail Then
      WrkQry = WrkQry & WrkAnd & "ICODE<>'M'"
    End If
    If WrkBalances Then
      WrkQry = WrkQry & WrkAnd & "BALD > 0"
    End If
    MyTypes = MyFrmTXE12B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkNew = True
    myTXINVQ.OpenQry(WrkSort, WrkQry)

ReadNext:
    myTXINVQ.ReadQry()
    If Not myTXINVQ.IsEOF Then
      RecCounter = RecCounter + 1
      With myTXINVQ
        'Filter - Omit Unposted Zero Balances 
        WrkBal = ._BALD - ._NEWPAY
        If WrkBal <= 0 Then
          GoTo NextRec
        End If

        WrkBankCode = Trim(._BKCD)
        If WrkNonEscrow Then
          If WrkBankCode <> String.Empty Or Trim(._BKSR) <> String.Empty Then
            GoTo NextRec
          End If
        End If

        If WrkNonEscrowBank Then
          WrkEscrowPrint = LookupBanksEscrow(WrkBankCode)
          If Not WrkEscrowPrint Or Trim(._BKSR) <> String.Empty Then
            GoTo NextRec
          End If
        End If

        'Filter - Only New Owner
        If WrkNewOwner Then
          If Left(Trim(._SNAME), 3) <> "N/O" And Right(Trim(._SNAME), 3) <> "N/O" Then
            GoTo NextRec
          End If
        End If
      End With

      LblCounter = LblCounter + 1
      With myTXINVQ
        CalcInterest(._LISTNo, ._TYPE, ._YEAR, WrkDue, WrkInt)
      End With
      'Filter - Omit delinquents
      If WrkOmitDelq And WrkInt > 0 Then
        GoTo NextRec
      End If
      If WrkReport Then
        With myTXINVQ
          dr = ds.Tables(0).NewRow
          Select Case WrkSortBy
            Case "Zip"
              dr.Item("sortdata") = Format(._ZIP5, "00000") & " " & Trim(._NAME)
            Case "Name"
              dr.Item("sortdata") = Trim(._NAME)
          End Select
          If ._ICODE = "B" Then
            dr.Item("backtax") = "B"
          Else
            dr.Item("backtax") = String.Empty
          End If
          dr.Item("listno") = ._LISTNo
          dr.Item("year") = ._YEAR
          WrkTXType = LookupType(._TYPE)
          dr.Item("type") = ._TYPE
          dr.Item("typedesc") = WrkTXType(0)
          If SaveSortData <> dr.Item("sortdata") Then
            AddrLine = MyUtils.SetAddrLine(._NAME, ._SNAME, ._ADD1, ._ADD2,
            ._CITY, ._STATE, ._ZIP5, ._ZIP4)
          End If
          SaveSortData = dr.Item("sortdata")
          dr.Item("addr1") = AddrLine(0)
          dr.Item("addr2") = AddrLine(1)
          dr.Item("addr3") = AddrLine(2)
          dr.Item("addr4") = AddrLine(3)
          dr.Item("addr5") = AddrLine(4)

          Select Case WrkTXType(1) 'Family
            Case "M", "S"
              dr.Item("propdesc") = Trim(._MAKE) & " " & Trim(._MVYR) & " " & ._IMVREG
              dr.Item("propdesc2") = ._IMVIDNo
            Case Else
              dr.Item("propdesc") = Trim(._LOCNo) & " " & ._LOC
              dr.Item("propdesc2") = ""
          End Select
          If WrkPayFirst Then
            dr.Item("Balance") = Format(WrkDue, "fixed")
          Else
            dr.Item("Balance") = Format(._BALD, "fixed")
          End If
          'Needed if First payment selected
          If WrkBalances And dr.Item("balance") = 0 Then
            GoTo NextRec
          End If
          ds.Tables(0).Rows.Add(dr)
        End With
      Else
        If WrkNew Then
          sb0 = New StringBuilder
          sb1 = New StringBuilder
          sb2 = New StringBuilder
          sb3 = New StringBuilder
          sb4 = New StringBuilder
          sb5 = New StringBuilder
          'Adjust space before 1st column
          If WrkHAdjust1 > 0 Then
            sb0.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
            sb1.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
            sb2.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
            sb3.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
            sb4.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
            sb5.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
          End If
        End If

        WrkNew = False
        With myTXINVQ
          sb0.Append(MyUtils.JustifyLeft(._LISTNo, WrkMaxLen))
          AddrLine = MyUtils.SetAddrLine(Trim(._NAME), Trim(._SNAME), Trim(._ADD1), Trim(._ADD2),
          Trim(._CITY), Trim(._STATE), ._ZIP5, ._ZIP4)
        End With
        sb1.Append(MyUtils.JustifyLeft(AddrLine(0), WrkMaxLen))
        sb2.Append(MyUtils.JustifyLeft(AddrLine(1), WrkMaxLen))
        sb3.Append(MyUtils.JustifyLeft(AddrLine(2), WrkMaxLen))
        sb4.Append(MyUtils.JustifyLeft(AddrLine(3), WrkMaxLen))
        sb5.Append(MyUtils.JustifyLeft(AddrLine(4), WrkMaxLen))
        'Adjust space between 1st and 2nd columns
        If WrkMod > 1 And LblCounter Mod WrkMod = 1 And WrkHAdjust2 > 0 Then
          sb0.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
          sb1.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
          sb2.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
          sb3.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
          sb4.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
          sb5.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
        End If
        'Adjust space between 2nd and 3rd columns
        If WrkMod > 2 And LblCounter Mod WrkMod = 2 And WrkHAdjust3 > 0 Then
          sb0.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
          sb1.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
          sb2.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
          sb3.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
          sb4.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
          sb5.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
        End If
        If LblCounter Mod WrkMod = 0 Then
          dr = ds.Tables(0).NewRow
          If WrkShowList Then
            dr.Item("line0") = sb0.ToString
          Else
            dr.Item("line0") = String.Empty
          End If
          dr.Item("line1") = sb1.ToString
          dr.Item("line2") = sb2.ToString
          dr.Item("line3") = sb3.ToString
          dr.Item("line4") = sb4.ToString
          dr.Item("line5") = sb5.ToString
          ds.Tables(0).Rows.Add(dr)
          sb0 = Nothing
          sb1 = Nothing
          sb2 = Nothing
          sb3 = Nothing
          sb4 = Nothing
          sb5 = Nothing
          WrkNew = True
        End If
      End If

NextRec:
      With myFrmProgress
        WrkPct = (RecCounter / 10) Mod 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .LblMsg.Text = "Records processed: " & RecCounter
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
      GoTo ReadNext
    End If

    'Write out any remaining data
    If Not WrkReport Then
      If Not WrkNew Then
        If sb1.ToString <> String.Empty Then
          dr = ds.Tables(0).NewRow
          If WrkShowList Then
            dr.Item("line0") = sb0.ToString
          Else
            dr.Item("line0") = String.Empty
          End If
          dr.Item("line1") = sb1.ToString
          dr.Item("line2") = sb2.ToString
          dr.Item("line3") = sb3.ToString
          dr.Item("line4") = sb4.ToString
          dr.Item("line5") = sb5.ToString
          ds.Tables(0).Rows.Add(dr)
        End If
      End If
    End If

    myFrmProgress.Close()
    Application.DoEvents()
    myTXINVQ.CloseFile()
  End Sub
  Private Sub BufferBanksEscrow()
    Dim I As Integer

    Dim myTXBANKS As TXBANKS.myData
    Dim dsTXBANKS As DataSet = New DataSet

    myTXBANKS = New TXBANKS.mydata(MyDBConnect)

    dsTXBANKS = myTXBANKS.GetAllData
    For I = 0 To dsTXBANKS.Tables(0).Rows.Count - 1
      With dsTXBANKS.Tables(0).Rows(I)
        WrkBanksCode(I) = .Item("bkcode")
        If .Item("bkprnt") = "Y" Then
          WrkBanksPrnt(I) = True
        Else
          WrkBanksPrnt(I) = False
        End If
      End With
    Next

  End Sub
  Private Function LookupBanksEscrow(ByVal Code As String) As Boolean
    Dim I As Integer

    If Code = "" Then Return True

    For I = 0 To WrkBanksCode.GetUpperBound(0)
      If Trim(WrkBanksCode(I)) = "" Then
        Return False
      End If
      If Trim(Code) = Trim(WrkBanksCode(I)) Then
        Return WrkBanksPrnt(I)
      End If
    Next

  End Function
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
  Public Sub CalcInterest(ByVal InListNo As Integer, ByVal InType As String,
  ByVal InYear As Integer, ByRef OutTax As Decimal, ByRef OutInt As Decimal)
    With myCASHINT
      .In_IntDate = Date.Today
      .In_ListNo = InListNo
      .In_Type = InType
      .In_Year = InYear
      .CalcInterest()
      OutTax = Format(.Out_Prin(), "standard")
      OutInt = Format(.Out_Int(), "standard")
    End With
  End Sub
End Module






