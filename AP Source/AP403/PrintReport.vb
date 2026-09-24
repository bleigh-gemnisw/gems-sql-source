Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myAPEOPNQ As APEOPNQ.MyData
  Dim myAPEOPN As APEOPN.MyData
  Dim myAPEOPNL1 As APEOPNL1.MyData
  Dim myAPEBNC As APEBNC.MyData
  Dim myAPEBNK As APEBNK.MyData
  Dim myVENDOR As VENDOR.MyData
  Dim myGLACCT As GLACCT.MyData
  Dim myGLFUND As GLFUND.MyData

  Dim ds As DataSet = New DataSet
  Dim dsChk As DataSet = New DataSet
  Dim dsChk2 As DataSet = New DataSet
  Dim dsChkOvr As DataSet = New DataSet
  Dim dsGL As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim dr2 As Data.DataRow
  Dim drGL As Data.DataRow

  'Screen fields
  Dim WrkSortBy As String
  Dim WrkCheckDate As Date
  Dim WrkCheckNo As Integer
  Dim WrkBank As String

  Dim SaveVendor As String
  Dim WrkAmount As Decimal
  Dim WrkError As Boolean
  'G/L totals
  Dim WrkGLFund(25) As Integer
  Dim WrkGLAmount(25) As Decimal

  Dim CMaxLines As Integer

  Public Sub PrtReport()
    myAPEOPNQ = New APEOPNQ.MyData()
    myAPEOPNQ.MyDBConn = myDBConnect
    myAPEOPN = New APEOPN.MyData()
    myAPEOPN.MyDBConn = myDBConnect
    myAPEOPNL1 = New APEOPNL1.MyData()
    myAPEOPNL1.MyDBConn = myDBConnect
    myAPEBNC = New APEBNC.MyData()
    myAPEBNC.MyDBConn = myDBConnect
    myAPEBNK = New APEBNK.MyData()
    myAPEBNK.MyDBConn = myDBConnect
    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    myGLFUND = New GLFUND.MyData()
    myGLFUND.MyDBConn = myDBConnect

    WrkError = False
    If MyCheckType = "R" Then
      With MyFrmAP403B
        WrkCheckDate = .DtPckCheck.Value
        WrkCheckNo = MyUtils.CnvSng(.TxtCheckNo.Text)
        WrkBank = .TxtBank.Text
        If .RbSortName.Checked Then
          WrkSortBy = "Name"
        End If
        If .RbSortNumber.Checked Then
          WrkSortBy = "Number"
        End If
      End With
    End If

    If myTOWN._TOWNBR = 99 Then
      CMaxLines = 35
    Else
      CMaxLines = 14
    End If

    If ds.Tables.Count = 0 Then
      BuildDS()
      BuildDSChk()
      BuildDSGL()
    Else
      ds.Clear()
      dsChk.Clear()
      dsChk2.Clear()
      dsChkOvr.Clear()
      dsGL.Clear()
    End If

    If MyCheckType = "M" Then
      GetManual()
    Else
      Array.Clear(WrkGLFund, 0, 25)
      Array.Clear(WrkGLAmount, 0, 25)
      GetCheck()
      GetPCard()
    End If

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .WrkError = WrkError
      .wrkds = ds
      .wrkdsChk = dsChk
      .wrkdsChk2 = dsChk2
      .wrkdsChkOvr = dsChkOvr
      .wrkdsGL = dsGL
      .WrkBank = WrkBank
      .Show()
    End With
  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("CheckNo", Type.GetType("System.Int32"))
      .Columns.Add("CheckDt", Type.GetType("System.DateTime"))
      .Columns.Add("Vndnr", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("PoNbr", Type.GetType("System.Int32"))
      .Columns.Add("Descr", Type.GetType("System.String"))
      .Columns.Add("PayAmt", Type.GetType("System.Decimal"))
      .Columns.Add("AcctFull", Type.GetType("System.String"))
      .Columns.Add("Fund", Type.GetType("System.String"))
      .Columns.Add("Dept", Type.GetType("System.String"))
      .Columns.Add("Object", Type.GetType("System.String"))
      .Columns.Add("Function", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub BuildDSChk()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("CheckNo", Type.GetType("System.Int32"))
      .Columns.Add("CheckNoA", Type.GetType("System.String"))
      .Columns.Add("CheckDt", Type.GetType("System.DateTime"))
      .Columns.Add("Vndnr", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("FlipName", Type.GetType("System.String"))
      .Columns.Add("PayAmt", Type.GetType("System.Decimal"))
      .Columns.Add("PayAmtFill", Type.GetType("System.String"))
      .Columns.Add("PayWords", Type.GetType("System.String"))
      .Columns.Add("PayWordsFill", Type.GetType("System.String"))
      .Columns.Add("Bnkac", Type.GetType("System.String"))
      .Columns.Add("AcDes1", Type.GetType("System.String"))
      .Columns.Add("AcDes2", Type.GetType("System.String"))
      .Columns.Add("AcDes3", Type.GetType("System.String"))
      .Columns.Add("BnDes1", Type.GetType("System.String"))
      .Columns.Add("BnDes2", Type.GetType("System.String"))
      .Columns.Add("BnDes3", Type.GetType("System.String"))
      .Columns.Add("Fract1", Type.GetType("System.String"))
      .Columns.Add("Fract2", Type.GetType("System.String"))
      .Columns.Add("Rout", Type.GetType("System.String"))
      .Columns.Add("Sig1", Type.GetType("System.String"))
      .Columns.Add("Sig2", Type.GetType("System.String"))
      .Columns.Add("Sig3", Type.GetType("System.String"))
    End With
    dsChk.Tables.Add(myTable)

    With myTable2
      .TableName = "mytable2"
      .Columns.Add("CheckNo", Type.GetType("System.Int32"))
      .Columns.Add("PoNbr", Type.GetType("System.Int32"))
      .Columns.Add("InvDt", Type.GetType("System.DateTime"))
      .Columns.Add("InvNo", Type.GetType("System.String"))
      .Columns.Add("Descr", Type.GetType("System.String"))
      .Columns.Add("PayAmt", Type.GetType("System.Decimal"))
      .Columns.Add("AcctNo", Type.GetType("System.String"))
      .Columns.Add("Fund", Type.GetType("System.String"))
      .Columns.Add("Dept", Type.GetType("System.String"))
      .Columns.Add("Object", Type.GetType("System.String"))
      .Columns.Add("Function", Type.GetType("System.String"))
    End With
    dsChk2.Tables.Add(myTable2)
    dsChkOvr = dsChk2.Clone
  End Sub
  Private Sub BuildDSGL()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("CheckDt", Type.GetType("System.DateTime"))
      .Columns.Add("AcctNo", Type.GetType("System.String"))
      .Columns.Add("AcctDesc", Type.GetType("System.String"))
      .Columns.Add("AcctType", Type.GetType("System.String"))
      .Columns.Add("TranType", Type.GetType("System.String"))
      .Columns.Add("Credit", Type.GetType("System.Decimal"))
      .Columns.Add("Debit", Type.GetType("System.Decimal"))
    End With
    dsGL.Tables.Add(myTable)
  End Sub
  Private Sub GetCheck()
    Dim SaveDescr As String
    Dim SaveVendorName As String
    Dim SavePONbr As Integer
    Dim SaveInvDate As Date
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAmtgr As Decimal
    Dim I As Integer
    Dim WrkAnd As String
    Dim Counter As Integer


    WrkAnd = " and "
    WrkQry = "SLTPY='1'" & WrkAnd & "HINV<>'P'"
    WrkSort = ""
    Select Case WrkSortBy
      Case "Name"
        WrkSort = "VSORT, VNDNR, INVNO, RECNO"
      Case "Number"
        WrkSort = "VNDNR, INVNO, RECNO"
    End Select

    myAPEOPNQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    SaveVendor = ""
    SaveVendorName = ""
    SaveDescr = ""
    SavePONbr = 0
    Counter = 0
    WrkAmount = 0

ReadNext:
    myAPEOPNQ.ReadQry()
    If Not myAPEOPNQ.IsEOF Then
      With myAPEOPNQ
        If SaveVendor <> "" And Trim(._VNDNR) <> SaveVendor Then
          If WrkAmtgr > 0 Then
            WriteCheckTot()
            WrkCheckNo = WrkCheckNo + 1
          End If
          WrkAmount = 0
          Counter = 0
        End If
        If SaveVendor <> Trim(._VNDNR) Then
          myVENDOR.GetOneRecordP(Trim(._VNDNR))
          With myVENDOR
            If Trim(._PYNAM) = "" Then
              SaveVendorName = Trim(._VENNM)
            Else
              SaveVendorName = Trim(._PYNAM)
            End If
          End With
        End If
        WrkAmtgr = myAPEOPNL1.GetVndnrAmtgr(._VNDNR)
        SaveVendor = Trim(._VNDNR)

        If ._RECNO = 0 Then
          If WrkAmtgr > 0 Then
            Counter = Counter + 1
            WrkAmount = WrkAmount + ._AMTGR
            SavePONbr = ._PONBR
            SaveDescr = Trim(._DSCTX)
            SaveInvDate = MyUtils.GetDBDateMDY(._INVD8)
            If Not MyCheckDetail Then
              If Counter <= CMaxLines Then
                dr2 = dsChk2.Tables(0).NewRow
              Else
                dr2 = dsChkOvr.Tables(0).NewRow
              End If
              dr2.Item("checkno") = WrkCheckNo
              dr2.Item("ponbr") = ._PONBR
              dr2.Item("invno") = ._INVNO
              dr2.Item("invdt") = MyUtils.GetDBDateMDY(._INVD8)
              dr2.Item("descr") = Trim(._DSCTX)
              dr2.Item("payamt") = ._AMTGR
              dr2.Item("fund") = Format(._FDNBR, "000")
              dr2.Item("dept") = Format(._DPNBR, "0000")
              dr2.Item("object") = Format(._OBNBR, "000")
              dr2.Item("function") = Format(._FNPGM, "0000")
              dr2.Item("acctno") = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
              If Counter <= CMaxLines Then
                dsChk2.Tables(0).Rows.Add(dr2)
              Else
                dsChkOvr.Tables(0).Rows.Add(dr2)
              End If
            End If
            UpdateAPEOPN(Trim(._VNDNR), Trim(._INVNO), ._RECNO, ._AMTGR, True)
          End If
        Else
          Select Case WrkAmtgr
            Case > 0
              Counter = Counter + 1
              dr = ds.Tables(0).NewRow
              dr.Item("checkno") = WrkCheckNo
              dr.Item("checkdt") = WrkCheckDate
              dr.Item("vndnr") = SaveVendor
              dr.Item("name") = SaveVendorName
              dr.Item("ponbr") = SavePONbr
              dr.Item("descr") = SaveDescr
              dr.Item("payamt") = ._AMTGR
              dr.Item("fund") = Format(._FDNBR, "000")
              dr.Item("dept") = Format(._DPNBR, "0000")
              dr.Item("object") = Format(._OBNBR, "000")
              dr.Item("function") = Format(._FNPGM, "0000")
              dr.Item("acctfull") = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN) &
      "  " & GetGLACCTDesc(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
              ds.Tables(0).Rows.Add(dr)
              AddFundAmt(._FDNBR, ._AMTGR)

              If MyCheckDetail Then
                If Counter <= CMaxLines Then
                  dr2 = dsChk2.Tables(0).NewRow
                Else
                  dr2 = dsChkOvr.Tables(0).NewRow
                End If
                dr2.Item("checkno") = WrkCheckNo
                dr2.Item("ponbr") = SavePONbr
                dr2.Item("invno") = ._INVNO
                If ._INVD8 > 0 Then
                  dr2.Item("invdt") = MyUtils.GetDBDateMDY(._INVD8)
                Else
                  dr2.Item("invdt") = SaveInvDate
                End If
                dr2.Item("descr") = SaveDescr
                dr2.Item("payamt") = ._AMTGR
                dr2.Item("fund") = Format(._FDNBR, "000")
                dr2.Item("dept") = Format(._DPNBR, "0000")
                dr2.Item("object") = Format(._OBNBR, "000")
                dr2.Item("function") = Format(._FNPGM, "0000")
                dr2.Item("acctno") = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
                If Counter <= CMaxLines Then
                  dsChk2.Tables(0).Rows.Add(dr2)
                Else
                  dsChkOvr.Tables(0).Rows.Add(dr2)
                End If
              End If
            Case < 0
              WrkError = True
              dr = ds.Tables(0).NewRow
              dr.Item("checkno") = 0
              dr.Item("checkdt") = WrkCheckDate
              dr.Item("vndnr") = SaveVendor
              dr.Item("name") = SaveVendorName
              dr.Item("ponbr") = 0
              dr.Item("descr") = "** Negative Amount **"
              dr.Item("payamt") = ._AMTGR
              dr.Item("fund") = Format(._FDNBR, "000")
              dr.Item("dept") = Format(._DPNBR, "0000")
              dr.Item("object") = Format(._OBNBR, "000")
              dr.Item("function") = Format(._FNPGM, "0000")
              dr.Item("acctfull") = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN) &
      "  " & GetGLACCTDesc(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
              ds.Tables(0).Rows.Add(dr)
            Case Else
          End Select
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

    If SaveVendor <> "" And WrkAmtgr > 0 Then
      WriteCheckTot()
    End If

    For I = 0 To 25
      If WrkGLFund(I) = 0 Then Exit For
      WriteGL(WrkGLFund(I), WrkGLAmount(I))
    Next

    myFrmProgress.Close()
    myAPEOPN.CloseFile()

  End Sub
  Private Sub GetPCard()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAnd As String
    Dim Counter As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = "SLTPY='1'" & WrkAnd & "HINV='P'"
    WrkSort = ""
    myAPEOPNQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0

ReadNext:
    myAPEOPNQ.ReadQry()
    If Not myAPEOPNQ.IsEOF Then
      With myAPEOPNQ
        If ._RECNO = 0 Then
          Counter = Counter + 1
          UpdateAPEOPN(Trim(._VNDNR), Trim(._INVNO), ._RECNO, ._AMTGR, False)
        End If
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
      End With
    End If

    myFrmProgress.Close()
    myAPEOPN.CloseFile()

  End Sub
  Private Sub GetManual()
    Dim MaxI As Integer
    Dim I As Integer
    Dim Counter As Integer

    With MyFrmAP403C
      WrkCheckNo = MyUtils.CnvSng(.TxtCheckNo.Text)
    End With

    Counter = 0
    MaxI = MyFrmAP403C.DataGrdView.Rows.Count - 1

    With MyFrmAP403C.DataGrdView
      For I = 0 To MaxI
        Counter = Counter + 1
        If Counter <= CMaxLines Then
          dr2 = dsChk2.Tables(0).NewRow
        Else
          dr2 = dsChkOvr.Tables(0).NewRow
        End If
        dr2.Item("checkno") = WrkCheckNo
        dr2.Item("ponbr") = .Item(0, I).Value
        dr2.Item("invdt") = .Item(1, I).Value
        dr2.Item("payamt") = .Item(2, I).Value
        dr2.Item("invno") = .Item(3, I).Value
        dr2.Item("descr") = .Item(4, I).Value
        If Counter <= CMaxLines Then
          dsChk2.Tables(0).Rows.Add(dr2)
        Else
          dsChkOvr.Tables(0).Rows.Add(dr2)
        End If
      Next
    End With

    GetManualTot()

  End Sub
  Private Sub GetManualTot()
    Dim WrkMICR As String

    With MyFrmAP403C
      WrkBank = .TxtBank.Text
      WrkCheckNo = MyUtils.CnvSng(.TxtCheckNo.Text)
      WrkCheckDate = .DtPckChk.Value
      WrkAmount = MyUtils.CnvSng(.LblTot.Text)
      SaveVendor = .TxtVendor.Text
    End With

    myAPEBNK.GetOneRecordP(WrkBank)
    myAPEBNC.GetOneRecordP(WrkBank)
    With myAPEBNC
      WrkMICR = Trim(._MICR)
    End With

    dr = dsChk.Tables(0).NewRow
    dr.Item("checkno") = WrkCheckNo
    If WrkMICR = "" And myTOWN._TOWNBR <> 37 Then
      dr.Item("checknoa") = "C" & Format(WrkCheckNo, "0000000000") & "C"
    Else
      dr.Item("checknoa") = "C" & Format(WrkCheckNo, "000000") & "C"
    End If
    dr.Item("Checkdt") = WrkCheckDate
    dr.Item("vndnr") = MyFrmAP403C.TxtVendor.Text
    dr.Item("payamt") = WrkAmount
    dr.Item("payamtfill") = MyUtils.JustifyRight(WrkAmount, 18, "*")
    If myTOWN._TOWNBR = 99 Then
      dr.Item("paywords") = Trim(CurrencyToText(WrkAmount, 0)) & " DOLLARS"
    Else
      dr.Item("paywords") = Trim(CurrencyToText(WrkAmount, 0))
    End If
    dr.Item("paywordsfill") = Trim(CurrencyToText(WrkAmount, 79))
    dr.Item("name") = Trim(MyFrmAP403C.TxtName.Text)
    dr.Item("flipname") = DoFlipName(Trim(MyFrmAP403C.TxtName.Text))
    dr.Item("addr1") = Trim(MyFrmAP403C.TxtAddr1.Text)
    dr.Item("addr2") = Trim(MyFrmAP403C.TxtAddr2.Text)
    dr.Item("addr3") = Trim(MyFrmAP403C.TxtAddr3.Text)
    dr.Item("addr4") = Trim(MyFrmAP403C.TxtAddr4.Text)
    With myAPEBNK
      Select Case WrkMICR
        Case "6"
          dr.Item("bnkac") = Format(._BNKAC, "000 000 000") & "C"
        Case "N"
          dr.Item("bnkac") = Format(._BNKAC, "000000000") & "C"
        Case "W"
          dr.Item("bnkac") = "10 " & Format(._BNKAC, "0000000000") & "C"
        Case Else
          dr.Item("bnkac") = Format(._BNKAC, "000000000000") & "C"
      End Select
    End With
    With myAPEBNC
      dr.Item("acdes1") = Trim(._ACDES1)
      dr.Item("acdes2") = Trim(._ACDES2)
      dr.Item("acdes3") = Trim(._ACDES3)
      dr.Item("bndes1") = Trim(._BNDES1)
      dr.Item("bndes2") = Trim(._BNDES2)
      dr.Item("bndes3") = Trim(._BNDES3)
      dr.Item("fract1") = Trim(._FRACT1)
      dr.Item("fract2") = Trim(._FRACT2)
      If WrkMICR = "" Then
        dr.Item("rout") = "A" & Trim(._ROUT) & "A"
      Else
        dr.Item("rout") = "A" & Trim(._ROUT) & "A"
      End If
      dr.Item("sig1") = Trim(._SIG1)
      dr.Item("sig2") = Trim(._SIG2)
      dr.Item("sig3") = Trim(._SIG3)
    End With
    dsChk.Tables(0).Rows.Add(dr)
  End Sub
  Private Sub UpdateAPEOPN(ByVal Vndnr As String, ByVal InvNo As String,
  ByVal RecNo As Integer, ByVal Amount As Decimal, ByVal IsCheck As Boolean)

    myAPEOPN.GetOneRecordP(Vndnr, InvNo, RecNo)
    If myAPEOPN.RecordNotFound Then Exit Sub

    With myAPEOPN
      ._PAYAM = Amount
      ._PPDT8 = MyUtils.SetDBDateMDY(WrkCheckDate)
      If IsCheck Then
        ._PAYCK = WrkCheckNo
        ._PAYBN = WrkBank
      End If
      .UpdateOneRecordP()
    End With

  End Sub
  Public Function SetVndrAddrLine(ByVal Add1 As String, ByVal Add2 As String,
   ByVal Add3 As String, ByVal Add4 As String, ByVal Zip5 As String,
   ByVal Zip4 As String) As String()
    'Returns Address as string array. Blank lines are stripped out. 
    Dim AddrLine(3) As String
    Dim sb As StringBuilder
    Dim I As Integer

    Add1 = Trim(Add1)
    Add2 = Trim(Add2)
    Add3 = Trim(Add3)
    Add4 = Trim(Add4)
    Zip5 = Trim(Zip5)
    Zip4 = Trim(Zip4)

    AddrLine(I) = Add1
    If Add2 <> "" Then
      I = I + 1
      AddrLine(I) = Add2
    End If
    If Add3 <> "" Then
      I = I + 1
      AddrLine(I) = Add3
    End If
    If Add4 <> "" Then
      I = I + 1
      AddrLine(I) = Add4
    End If
    If Zip5 <> "" Then
      sb = New StringBuilder
      sb.Append(Zip5)
      If Zip4 <> "" Then
        sb.Append("-")
        sb.Append(Zip4)
      End If
      AddrLine(I) = AddrLine(I) & " " & sb.ToString
    End If
    For I = 2 To 3
      If AddrLine(I) Is Nothing Then
        AddrLine(I) = ""
      End If
    Next
    Return AddrLine

  End Function
  Private Sub WriteCheckTot()
    Dim WrkName As String
    Dim WrkFlipName As String
    Dim WrkMICR As String
    Dim AddrLine() As String

    myAPEBNK.GetOneRecordP(WrkBank)
    myAPEBNC.GetOneRecordP(WrkBank)
    With myAPEBNC
      WrkMICR = Trim(._MICR)
    End With

    dr = dsChk.Tables(0).NewRow
    dr.Item("checkno") = WrkCheckNo
    If WrkMICR = "" And myTOWN._TOWNBR <> 37 Then
      dr.Item("checknoa") = "C" & Format(WrkCheckNo, "0000000000") & "C"
    Else
      dr.Item("checknoa") = "C" & Format(WrkCheckNo, "000000") & "C"
    End If
    dr.Item("Checkdt") = WrkCheckDate
    dr.Item("vndnr") = SaveVendor
    dr.Item("payamt") = WrkAmount
    dr.Item("payamtfill") = MyUtils.JustifyRight(WrkAmount, 18, "*")
    If myTOWN._TOWNBR = 99 Then
      dr.Item("paywords") = Trim(CurrencyToText(WrkAmount, 0)) & " DOLLARS"
    Else
      dr.Item("paywords") = Trim(CurrencyToText(WrkAmount, 0))
    End If
    dr.Item("paywordsfill") = Trim(CurrencyToText(WrkAmount, 79))
    myVENDOR.GetOneRecordP(SaveVendor)
    With myVENDOR
      If Trim(._PYNAM) = "" Then
        WrkName = Trim(._VENNM)
        WrkFlipName = DoFlipName(Trim(._VENNM))
        AddrLine = SetVndrAddrLine(._VADD1, ._VADD2, ._VADD3,
    ._VADD4, ._VZIP, ._VZIPE)
      Else
        WrkName = Trim(._PYNAM)
        WrkFlipName = DoFlipName(Trim(._PYNAM))
        AddrLine = SetVndrAddrLine(._PYAD1, ._PYAD2, ._PYAD3,
    ._PYAD4, ._PYZIP, ._PYZIPE)
      End If
    End With
    dr.Item("name") = WrkName
    dr.Item("flipname") = WrkFlipName
    dr.Item("addr1") = AddrLine(0)
    dr.Item("addr2") = AddrLine(1)
    dr.Item("addr3") = AddrLine(2)
    dr.Item("addr4") = AddrLine(3)
    With myAPEBNK
      Select Case WrkMICR
        Case "6"
          dr.Item("bnkac") = Format(._BNKAC, "000 000 000") & "C"
        Case "N"
          dr.Item("bnkac") = Format(._BNKAC, "000000000") & "C"
        Case "W"
          dr.Item("bnkac") = "10 " & Format(._BNKAC, "0000000000") & "C"
        Case Else
          dr.Item("bnkac") = Format(._BNKAC, "000000000000") & "C"
      End Select
    End With
    With myAPEBNC
      dr.Item("acdes1") = Trim(._ACDES1)
      dr.Item("acdes2") = Trim(._ACDES2)
      dr.Item("acdes3") = Trim(._ACDES3)
      dr.Item("bndes1") = Trim(._BNDES1)
      dr.Item("bndes2") = Trim(._BNDES2)
      dr.Item("bndes3") = Trim(._BNDES3)
      dr.Item("fract1") = Trim(._FRACT1)
      dr.Item("fract2") = Trim(._FRACT2)
      If WrkMICR = "" Then
        dr.Item("rout") = "A" & Trim(._ROUT) & "A"
      Else
        dr.Item("rout") = "A" & Trim(._ROUT) & "A"
      End If
      dr.Item("sig1") = Trim(._SIG1)
      dr.Item("sig2") = Trim(._SIG2)
      dr.Item("sig3") = Trim(._SIG3)
    End With
    dsChk.Tables(0).Rows.Add(dr)
  End Sub
  Public Sub WriteGL(ByVal Fund As Integer, ByVal Amount As Decimal)
    Dim dsGLACCT As DataSet = New DataSet

    myGLFUND.GetOneRecordP(Fund, 0)
    'Write Cash (G/L Entry)
    drGL = dsGL.Tables(0).NewRow
    drGL.Item("checkdt") = WrkCheckDate
    With myAPEBNK
      .GetOneRecordP(WrkBank)
      If ._FDNBR > 0 Then
        drGL.Item("acctno") = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
        myGLACCT.GetOneRecordP(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
      Else
        With myGLFUND
          drGL.Item("acctno") = BuildAcct(._FDNBRC, ._SFUNDC, ._DPNBRC, ._OBNBRC, ._FNPGMC, ._SUBFNC)
          myGLACCT.GetOneRecordP(._FDNBRC, ._SFUNDC, ._DPNBRC, ._OBNBRC, ._FNPGMC, ._SUBFNC)
        End With
      End If
    End With
    With myGLACCT
      If Not .RecordNotFound Then
        drGL.Item("acctdesc") = Trim(._GLDSC)
      Else
        drGL.Item("acctdesc") = "*** Invalid Acct ***"
      End If
      drGL.Item("accttype") = ._GLTYP
      drGL.Item("trantype") = "X"
      drGL.Item("credit") = Amount
      drGL.Item("debit") = 0
    End With
    dsGL.Tables(0).Rows.Add(drGL)

    'Write A/P (G/L Entry)
    drGL = dsGL.Tables(0).NewRow
    With myGLFUND
      drGL.Item("checkdt") = WrkCheckDate
      drGL.Item("acctno") = BuildAcct(._FDNBRA, ._SFUNDA, ._DPNBRA,
  ._OBNBRA, ._FNPGMA, ._SUBFNA)
      myGLACCT.GetOneRecordP(._FDNBRA, ._SFUNDA, ._DPNBRA,
    ._OBNBRA, ._FNPGMA, ._SUBFNA)
    End With
    With myGLACCT
      If Not .RecordNotFound Then
        drGL.Item("acctdesc") = Trim(._GLDSC)
      Else
        drGL.Item("acctdesc") = "*** Invalid Acct ***"
      End If
      drGL.Item("accttype") = ._GLTYP
      drGL.Item("trantype") = "X"
      drGL.Item("credit") = 0
      drGL.Item("debit") = Amount
    End With
    dsGL.Tables(0).Rows.Add(drGL)
  End Sub

  Public Function GetGLACCTDesc(ByVal PFund As Integer, ByVal PSubFund As Integer,
    ByVal PDept As Integer, ByVal PObject As Integer, ByVal PFunction As Integer,
    ByVal PSubFunc As Integer) As String

    If PFund = 0 Then
      Return ""
    End If

    myGLACCT.GetOneRecordP(PFund, PSubFund, PDept, PObject, PFunction, PSubFunc)
    If Not myGLACCT.RecordNotFound Then
      GetGLACCTDesc = Trim(myGLACCT._GLDSC)
    Else
      GetGLACCTDesc = "*** Unknown ***"
    End If
    Return GetGLACCTDesc

  End Function
  Private Function BuildAcct(ByVal Fund As Integer, ByVal SFund As Integer,
  ByVal Dept As Integer, ByVal Obj As Integer, ByVal Func As Integer,
  ByVal SFunc As Integer) As String
    Dim sb As StringBuilder = New StringBuilder

    sb.Append(Format(Fund, "000"))
    sb.Append("-")
    sb.Append(Format(SFund, "000"))
    sb.Append("-")
    sb.Append(Format(Dept, "0000"))
    sb.Append("-")
    sb.Append(Format(Obj, "000"))
    sb.Append("-")
    sb.Append(Format(Func, "0000"))
    sb.Append("-")
    sb.Append(Format(SFunc, "0000"))
    Return sb.ToString
  End Function
  Private Sub AddFundAmt(ByVal Fund As Integer, ByVal Amount As Decimal)
    Dim I As Integer

    For I = 0 To WrkGLFund.GetUpperBound(0) - 1
      If WrkGLFund(I) = 0 Then
        WrkGLFund(I) = Fund
        WrkGLAmount(I) = Amount
        Exit For
      Else
        If Fund = WrkGLFund(I) Then
          WrkGLAmount(I) = WrkGLAmount(I) + Amount
          Exit For
        End If
      End If
    Next
  End Sub
  Private Function DoFlipName(ByVal Name As String) As String
    Dim WrkName As String
    Dim Pos As Integer

    WrkName = ""
    Pos = InStr(Name, ",", CompareMethod.Text)
    If Pos > 0 Then
      WrkName = Trim(Mid(Name, Pos + 1, 40)) & " " & Mid(Name, 1, Pos - 1)
    Else
      WrkName = Name
    End If

    Return WrkName
  End Function

End Module
