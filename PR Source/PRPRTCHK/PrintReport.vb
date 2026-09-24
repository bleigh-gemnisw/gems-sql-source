Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myPRCHK As PRCHK.MyData
  Dim myPRCHKD As PRCHKD.myData
  Dim myPRSUP As PRSUP.myData
  Dim myPRSUPD As PRSUPD.myData
  Dim myAPEBNC As APEBNC.MyData
  Dim myAPEBNK As APEBNK.MyData

  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim dsDD As DataSet = New DataSet
  Dim dsDD2 As DataSet = New DataSet
  Dim DSPR As DataSet = New DataSet
  Dim DSPRD As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim dr2 As Data.DataRow

  Dim WrkPayroll As Boolean
  Dim WrkBank As String
  Public Sub PrtReport()
    myPRCHK = New PRCHK.MyData(myDBConnect)
    myPRCHKD = New PRCHKD.myData(myDBConnect)
    myPRSUP = New PRSUP.myData(myDBConnect)
    myPRSUPD = New PRSUPD.myData(myDBConnect)
    myAPEBNC = New APEBNC.MyData()
    myAPEBNC.MyDBConn = myDBConnect
    myAPEBNK = New APEBNK.MyData()
    myAPEBNK.MyDBConn = myDBConnect

    With MyFrmPRPRTCHKB
      WrkPayroll = .RbPayroll.Checked
      WrkBank = .TxtBank.Text
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
      ds2.Clear()
      dsDD.Clear()
      dsDD2.Clear()
    End If

    If MyCheckType = "M" Then
      GetManual()
    Else
      GetDetail()
    End If

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .wrkds2 = ds2
      .wrkdsDD = dsDD
      .wrkdsDD2 = dsDD2
      .Show()
    End With
  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("CheckNo", Type.GetType("System.Int32"))
      .Columns.Add("CheckNoA", Type.GetType("System.String"))
      .Columns.Add("UnqCheckNo", Type.GetType("System.String"))
      .Columns.Add("CheckDt", Type.GetType("System.DateTime"))
      .Columns.Add("PayType", Type.GetType("System.String"))
      .Columns.Add("EmpNo", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Zip", Type.GetType("System.String"))
      .Columns.Add("Zip4", Type.GetType("System.String"))
      .Columns.Add("FlipName", Type.GetType("System.String"))
      .Columns.Add("Fund", Type.GetType("System.Int32"))
      .Columns.Add("Dept", Type.GetType("System.Int32"))
      .Columns.Add("GrossPay", Type.GetType("System.Decimal"))
      .Columns.Add("NetPay", Type.GetType("System.Decimal"))
      .Columns.Add("NetPayFill", Type.GetType("System.String"))
      .Columns.Add("NetWords", Type.GetType("System.String"))
      .Columns.Add("NetWordsFill", Type.GetType("System.String"))
      .Columns.Add("YTDDed", Type.GetType("System.Decimal"))
      .Columns.Add("YTDGrs", Type.GetType("System.Decimal"))
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
    ds.Tables.Add(myTable)
    dsDD = ds.Clone

    With myTable2
      .TableName = "mytable2"
      .Columns.Add("CheckNo", Type.GetType("System.Int32"))
      .Columns.Add("EHours", Type.GetType("System.Decimal"))
      .Columns.Add("EDesc", Type.GetType("System.String"))
      .Columns.Add("EAmt", Type.GetType("System.Decimal"))
      .Columns.Add("EYTD", Type.GetType("System.Decimal"))
      .Columns.Add("DDesc", Type.GetType("System.String"))
      .Columns.Add("DAmt", Type.GetType("System.Decimal"))
      .Columns.Add("DYTD", Type.GetType("System.Decimal"))
      .Columns.Add("ACode", Type.GetType("System.String"))
    End With
    ds2.Tables.Add(myTable2)
    dsDD2 = ds2.Clone
  End Sub
  Private Sub GetDetail()
    Dim WrkPayType As String
    Dim WrkMICR As String
    Dim AddrLine(4) As String
    Dim WrkStr As String
    Dim I As Integer

    If WrkPayroll Then
      DSPR = myPRCHK.PosData(0)
    Else
      DSPR = myPRSUP.PosData(0)
    End If
    If DSPR.Tables(0).Rows.Count = 0 Then Exit Sub

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DSPR.Tables(0).Rows.Count - 1)
      With DSPR.Tables(0).Rows(I)
        WrkPayType = .Item("paytyp")
        Select Case WrkPayType
          Case "R"
            dr = ds.Tables(0).NewRow
          Case "D"
            dr = dsDD.Tables(0).NewRow
          Case "S"
            dr = ds.Tables(0).NewRow
        End Select
        dr.Item("checkno") = .Item("cpckno")
        dr.Item("Checkdt") = MyUtils.GetDBDateMDY(.Item("cpckdt"))
        dr.Item("empno") = Trim(.Item("cpemp"))
        dr.Item("paytype") = WrkPayType
        If WrkPayType = "S" Then
          AddrLine = SetVendorAddrLine(.Item("name"), .Item("addr1"), .Item("addr2"), .Item("addr3"), .Item("addr4"), .Item("zip"), .Item("zip4"))
          dr.Item("name") = AddrLine(0)
          dr.Item("addr1") = AddrLine(1)
          dr.Item("addr2") = AddrLine(2)
          dr.Item("addr3") = AddrLine(3)
          dr.Item("addr4") = AddrLine(4)
        Else
          dr.Item("name") = .Item("name")
          dr.Item("addr1") = .Item("addr1")
          dr.Item("addr2") = .Item("addr2")
          dr.Item("addr3") = .Item("addr3")
          dr.Item("addr4") = String.Empty
        End If
        dr.Item("flipname") = DoFlipName(.Item("name"))
        dr.Item("fund") = .Item("cpfnd")
        dr.Item("dept") = .Item("cpdept")
        dr.Item("grosspay") = .Item("gross")
        dr.Item("netpay") = .Item("netpay")
        dr.Item("netpayfill") = MyUtils.JustifyRight(.Item("netpay"), 14, "*")
        dr.Item("ytdded") = .Item("ytdded")
        dr.Item("ytdgrs") = .Item("ytdgrs")
        If WrkPayType = "R" Or WrkPayType = "S" Then
          myAPEBNK.GetOneRecordP(WrkBank)
          myAPEBNC.GetOneRecordP(WrkBank)
          With myAPEBNC
            WrkMICR = Trim(._MICR)
          End With
          If WrkMICR = "" And myTOWN._TOWNBR <> 37 Then
            dr.Item("checknoa") = "C" & Format(.Item("cpckno"), "0000000000") & "C"
          Else
            dr.Item("checknoa") = "C" & Format(.Item("cpckno"), "000000") & "C"
          End If
          dr.Item("unqcheckno") = .Item("cpckno")
          If myTOWN._TOWNBR = 99 Then
            dr.Item("networds") = Trim(CurrencyToText(.Item("netpay"), 0)) & " DOLLARS"
          Else
            dr.Item("networds") = Trim(CurrencyToText(.Item("netpay"), 0))
          End If
          dr.Item("networdsfill") = CurrencyToText(.Item("netpay"), 67)
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
        Else
          WrkStr = .Item("cpckdt")
          If Len(WrkStr) = 7 Then
            dr.Item("unqcheckno") = Mid(WrkStr, 4, 4) & "0" & Mid(WrkStr, 1, 3) & Format(.Item("cpemp"), "0000000")
          Else
            dr.Item("unqcheckno") = Mid(WrkStr, 5, 4) & Mid(WrkStr, 1, 4) & Format(.Item("cpemp"), "0000000")
          End If
          myAPEBNC.GetOneRecordP(WrkBank)
          With myAPEBNC
            dr.Item("acdes1") = Trim(._ACDES1)
            dr.Item("acdes2") = Trim(._ACDES2)
            dr.Item("acdes3") = Trim(._ACDES3)
          End With
        End If
        If WrkPayType = "R" Or WrkPayType = "S" Then
          ds.Tables(0).Rows.Add(dr)
        Else
          dsDD.Tables(0).Rows.Add(dr)
        End If
        WriteCheckDetail(.Item("cpckno"), WrkPayType)
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DSPR.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    myFrmProgress.Close()
    If WrkPayroll Then
      myPRCHKD.CloseFile()
    Else
      myPRSUPD.CloseFile()
    End If

  End Sub
  Private Sub WriteCheckDetail(ByVal WrkCheckNo As Integer, ByVal WrkPayType As String)
    Dim I As Integer

    If WrkCheckNo = 0 Then Exit Sub

    If WrkPayroll Then
      DSPRD = myPRCHKD.GetbyCheckNo(WrkCheckNo, 99)
    Else
      DSPRD = myPRSUPD.GetbyCheckNo(WrkCheckNo, 99)
    End If
    If DSPRD.Tables(0).Rows.Count = 0 Then Exit Sub

    For I = 0 To (DSPRD.Tables(0).Rows.Count - 1)
      With DSPRD.Tables(0).Rows(I)
        If WrkPayType = "R" Or WrkPayType = "S" Then
          dr2 = ds2.Tables(0).NewRow
        Else
          dr2 = dsDD2.Tables(0).NewRow
        End If
        dr2.Item("checkno") = WrkCheckNo
        dr2.Item("ehours") = .Item("ehours")
        dr2.Item("edesc") = .Item("edesc")
        dr2.Item("eamt") = .Item("eamt")
        dr2.Item("eytd") = .Item("eytd")
        dr2.Item("ddesc") = .Item("ddesc")
        dr2.Item("damt") = .Item("damt")
        dr2.Item("dytd") = .Item("dytd")
        If WrkPayroll Then
          dr2.Item("acode") = .Item("acode")
        Else
          dr2.Item("acode") = String.Empty
        End If
        If WrkPayType = "R" Or WrkPayType = "S" Then
          ds2.Tables(0).Rows.Add(dr2)
        Else
          dsDD2.Tables(0).Rows.Add(dr2)
        End If
      End With
    Next
  End Sub
  Private Sub GetManual()
    Dim WrkChkNo As Integer
    Dim WrkBank As String
    Dim WrkMICR As String
    Dim WrkPayType As String

    WrkBank = MyFrmPRPRTCHKB.TxtBank.Text
    WrkPayType = "R"
    WrkMICR = ""
    With MyFrmPRPRTCHKC
      WrkChkNo = MyUtils.CnvSng(.TxtChkNo.Text)
      dr = ds.Tables(0).NewRow
      dr.Item("checkno") = WrkChkNo
      dr.Item("Checkdt") = .DtPckChk.Value
      dr.Item("empno") = Trim(.TxtEmpNo.Text)
      dr.Item("paytype") = "R"
      dr.Item("name") = .TxtName.Text
      dr.Item("flipname") = .TxtName.Text
      dr.Item("addr1") = ""
      dr.Item("addr2") = ""
      dr.Item("addr3") = ""
      dr.Item("addr4") = ""
      dr.Item("zip") = ""
      dr.Item("zip4") = ""
      dr.Item("fund") = 0
      dr.Item("dept") = MyUtils.CnvSng(.TxtDept.Text)
      dr.Item("grosspay") = 0
      dr.Item("netpay") = MyUtils.CnvSng(.LblNetPay.Text)
      dr.Item("ytdded") = 0
      dr.Item("ytdgrs") = 0
      If WrkPayType = "R" Or WrkPayType = "S" Then
        myAPEBNK.GetOneRecordP(WrkBank)
        myAPEBNC.GetOneRecordP(WrkBank)
        With myAPEBNC
          WrkMICR = Trim(._MICR)
        End With
        If WrkMICR = "" And myTOWN._TOWNBR <> 37 Then
          dr.Item("checknoa") = "C" & Format(WrkChkNo, "0000000000") & "C"
        Else
          dr.Item("checknoa") = "C" & Format(WrkChkNo, "000000") & "C"
        End If
        If myTOWN._TOWNBR = 99 Then
          dr.Item("networds") = Trim(CurrencyToText(MyUtils.CnvSng(.LblNetPay.Text), 0)) & " DOLLARS"
        Else
          dr.Item("networds") = Trim(CurrencyToText(MyUtils.CnvSng(.LblNetPay.Text), 0))
        End If
        dr.Item("networdsfill") = CurrencyToText(MyUtils.CnvSng(.LblNetPay.Text), 67)
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
      End If
      myAPEBNC.GetOneRecordP(WrkBank)
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
      ds.Tables(0).Rows.Add(dr)
      WriteManualDetail(WrkChkNo, "R")
    End With

  End Sub
  Private Sub WriteManualDetail(ByVal WrkCheckNo As Integer, ByVal WrkPayType As String)
    Dim ErnHrs(0) As Decimal
    Dim ErnDesc(0) As String
    Dim ErnAmt(0) As Decimal
    Dim DedDesc(0) As String
    Dim DedAmt(0) As Decimal

    Dim I As Integer
    Dim MaxI As Integer

    If WrkCheckNo = 0 Then Exit Sub

    If MyFrmPRPRTCHKC.C1DataGrdErn.Splits(0).Rows.Count >= MyFrmPRPRTCHKC.C1DataGrdDed.Splits(0).Rows.Count Then
      MaxI = MyFrmPRPRTCHKC.C1DataGrdErn.Splits(0).Rows.Count - 1
    Else
      MaxI = MyFrmPRPRTCHKC.C1DataGrdDed.Splits(0).Rows.Count - 1
    End If

    ReDim ErnHrs(MaxI)
    ReDim ErnDesc(MaxI)
    ReDim ErnAmt(MaxI)
    ReDim DedDesc(MaxI)
    ReDim DedAmt(MaxI)

    For I = 0 To (MyFrmPRPRTCHKC.C1DataGrdErn.Splits(0).Rows.Count - 1)
      With MyFrmPRPRTCHKC.C1DataGrdErn
        ErnHrs(I) = .Item(I, 0)
        ErnDesc(I) = .Item(I, 1)
        ErnAmt(I) = .Item(I, 2)
      End With
    Next

    For I = 0 To (MyFrmPRPRTCHKC.C1DataGrdDed.Splits(0).Rows.Count - 1)
      With MyFrmPRPRTCHKC.C1DataGrdDed
        DedDesc(I) = .Item(I, 0)
        DedAmt(I) = .Item(I, 1)
      End With
    Next

    With MyFrmPRPRTCHKC.C1DataGrdErn
      For I = 0 To MaxI
        dr2 = ds2.Tables(0).NewRow
        dr2.Item("checkno") = WrkCheckNo
        dr2.Item("ehours") = ErnHrs(I)
        dr2.Item("edesc") = ErnDesc(I)
        dr2.Item("eamt") = ErnAmt(I)
        dr2.Item("eytd") = 0
        dr2.Item("ddesc") = DedDesc(I)
        dr2.Item("damt") = DedAmt(I)
        dr2.Item("dytd") = 0
        dr2.Item("acode") = String.Empty
        ds2.Tables(0).Rows.Add(dr2)
      Next
    End With
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
  Private Function SetVendorAddrLine(ByVal Name As String, ByVal Add1 As String, ByVal Add2 As String,
   ByVal Add3 As String, ByVal Add4 As String, ByVal Zip As String, ByVal Zip4 As String) As String()
    'Returns Address as string array. Blank lines are stripped out. 
    'City, State, Zip5 and Zip4 are combined into one line
    Dim AddrLine(4) As String
    Dim sb As StringBuilder
    Dim I As Integer
    Dim J As Integer

    AddrLine(0) = Trim(Name)
    AddrLine(1) = Trim(Add1)
    AddrLine(2) = Trim(Add2)
    AddrLine(3) = Trim(Add3)
    AddrLine(4) = Trim(Add4)

    sb = New StringBuilder
    If Zip <> String.Empty Then
      sb.Append(Zip)
      If Zip4 <> String.Empty Then
        sb.Append("-")
        sb.Append(Zip4)
      End If
    End If

    J = 4
    For I = 2 To 4
      If AddrLine(I) = String.Empty Then
        J = I - 1
        Exit For
      End If
    Next

    AddrLine(J) = AddrLine(J) & " " & sb.ToString
    Return AddrLine

  End Function
End Module
