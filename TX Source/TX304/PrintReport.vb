Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXHST As TXHST.MyData
  Dim myCASHINT As CASHINT.MyData

  Dim ds As DataSet = New DataSet
  Dim dsinv As DataSet = New DataSet
  Dim dsTot As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkType As String
  Dim WrkTypeDesc As String
  Dim WrkFamily As String
  Dim WrkRev As String
  Dim WrkUsePrintDist As Boolean
  Dim WrkGLYear As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkPhase As Integer
  Dim WrkStatus As String
  Dim WrkOmitStatus As String
  Dim WrkIntDate As Date
  Dim WrkLienDate As Date
  Dim WrkRptId As String
  Dim WrkSortBy As String
  Dim WrkPost As Boolean
  Dim WrkReprint As Boolean
  Dim WrkSelName As String
  Dim WrkAddr As String
  Dim WrkMaxAccts As Integer
  Dim WrkOmitBelow As Decimal
  'Personal Property
  Dim WrkCode(9) As Integer
  Dim WrkPropDesc As String
  Dim WrkPPCode(100) As Integer
  Dim WrkPPDesc(100) As String
  'TXPROF
  Dim ProfLien As Decimal
  Dim ProfDueDate1 As String
  Dim ProfDueDate2 As String

  Public Sub PrtReport()

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXHST = New TXHST.MyData(myDBConnect)
    myCASHINT = New CASHINT.MyData(myDBConnect)

    With MyFrmTX304B
      WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkDistAll = False
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
      WrkStatus = .TxtStatus.Text
      WrkOmitStatus = .TxtOmitStatus.Text
      WrkIntDate = .DtPckInt.Value
      WrkLienDate = .DtPckLien.Value
      WrkPost = False
      If .ChkPost.Checked Then
        WrkPost = True
      End If
      WrkReprint = False
      If .ChkReprint.Checked Then
        WrkReprint = True
      End If
      If .RbPrtBlanket.Checked Then
        WrkRptId = "Blanket"
      End If
      If .RbPrtEdit.Checked Then
        WrkRptId = "Edit"
      End If
      If .RbPrtNotice.Checked Then
        WrkRptId = "Notice"
      End If
      If .RbPrtTownClerk.Checked Then
        WrkRptId = "TownClerk"
      End If
      If .RbSortName.Checked Then
        WrkSortBy = "Name"
      End If
      If .RbSortZip.Checked Then
        WrkSortBy = "Zip"
      End If
      If .RbSortList.Checked Then
        WrkSortBy = "List"
      End If
      WrkSelName = .TxtName.Text
      WrkAddr = .TxtAddr.Text
      WrkMaxAccts = MyUtils.CnvSng(.TxtMaxAccts.Text)
      WrkOmitBelow = MyUtils.CnvSng(.TxtOmitBelow.Text)
    End With

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
      BuildDSTot(dsTot)
    Else
      ds.Clear()
      dsTot.Clear()
    End If

    BufferPPDesc()
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .wrkdsTot = dsTot
      .WrkRptID = WrkRptId
      .WrkLienFee = ProfLien
      .WrkDueDate1 = ProfDueDate1
      .WrkDueDate2 = ProfDueDate2
      .WrkIntDate = WrkIntDate
      .WrkLienDate = WrkLienDate
      MyCrViewer.Show()
    End With

  End Sub
  Private Sub GetDetail()
    Dim myBuffer_TXTYPE As Buffer_TXTYPE
    Dim AddrLine() As String
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAnd As String
    Dim WrkName As String
    Dim WrkName2 As String
    Dim WrkInterest As Decimal
    Dim WrkInterestPaid As Decimal
    Dim WrkFee As Decimal
    Dim WrkLien As Decimal
    Dim WrkBond As Decimal
    Dim WrkDue As Decimal
    Dim WrkTax As Decimal
    Dim WrkTotCount As Integer
    Dim WrkTotTax As Decimal
    Dim WrkTotInt As Decimal
    Dim WrkTotFee As Decimal
    Dim WrkTotLien As Decimal
    Dim WrkTotal As Decimal
    Dim InvDist As Integer
    Dim InvPhs As String
    Dim Counter As Integer
    Dim Pos As Integer
    Dim Good As Boolean
    Dim I As Integer

    myBuffer_TXTYPE = New Buffer_TXTYPE
    myBuffer_TXTYPE.BufferFile()

    If MyServer = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    If WrkReprint Then
      WrkQry = "icode<>'I'" & WrkAnd & "lien='L'"
    Else
      WrkQry = "icode<>'I'" & WrkAnd & "bald > 0" & WrkAnd & "lien=' '"
    End If
    WrkQry = WrkQry & WrkAnd & "YEAR = " & WrkGLYear
    If Not WrkDistAll Then
      WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
    End If
    If WrkPhase > 0 Then
      WrkQry = WrkQry & WrkAnd & "PHASE = " & WrkPhase
    End If
    If WrkSelName <> String.Empty Then
      WrkQry = WrkQry & WrkAnd & "NAME=" & MyUtils.Quo(WrkSelName)
    End If
    If WrkAddr <> String.Empty Then
      WrkQry = WrkQry & WrkAnd & "ADD1=" & MyUtils.Quo(WrkAddr)
    End If
    MyTypes = MyFrmTX304B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    Counter = 0
    WrkSort = ""
    ProfDueDate1 = ""
    ProfDueDate2 = ""
    WrkTotCount = 0
    WrkTotTax = 0
    WrkTotInt = 0
    WrkTotFee = 0
    WrkTotLien = 0
    WrkTotal = 0

    Select Case WrkSortBy
      Case "Name"
        WrkSort = "NAME, LIST#"
      Case "Zip"
        WrkSort = "ZIP5, NAME, LIST#"
      Case "List"
        WrkSort = "LIST#"
    End Select

    dsinv = myTXINVQ.GetQry(WrkSort, WrkQry, 0)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    For I = 0 To dsinv.Tables(0).Rows.Count - 1
      dr = dsinv.Tables(0).Rows(I)
      Counter = Counter + 1
      With myTXINVQ
        .GetFieldsDr(dr)
        Counter = Counter + 1
        If WrkMaxAccts > 0 And WrkTotCount >= WrkMaxAccts Then GoTo DoTotals
        'Filter - Status Codes
        If Trim(WrkStatus) > "" Then
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

        If Trim(WrkOmitStatus) > "" Then
          'Omit
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

        WrkType = ._TYPE
        WrkUsePrintDist = False
        With myBuffer_TXTYPE
          .In_Type = WrkType
          .LookupType()
          WrkTypeDesc = .Out_Desc
          WrkFamily = .Out_Family
          WrkRev = .Out_Rev
        End With

        If WrkRev = "P" Then
          WrkUsePrintDist = True
        End If

        WrkCode(0) = ._IPPCD1
        WrkCode(1) = ._IPPCD2
        WrkCode(2) = ._IPPCD3
        WrkCode(3) = ._IPPCD4
        WrkCode(4) = ._IPPCD5
        WrkCode(5) = ._IPPCD6
        WrkCode(6) = ._IPPCD7
        WrkCode(7) = ._IPPCD8
        WrkCode(8) = ._IPPCD9
        WrkCode(9) = ._IPPCDA
        dr = ds.Tables(0).NewRow
        dr.Item("typedesc") = WrkTypeDesc
        WrkName = Trim(._NAME)
        WrkName2 = Trim(._SNAME)
        dr = ds.Tables(0).NewRow
        Select Case WrkSortBy
          Case "Zip"
            dr.Item("sortdata") = Format(._ZIP5, "00000") & " " & WrkName & " " & ._LISTNo
          Case "Name"
            '3/17/25 ATTEMPTING TO FIX ISSUE WHERE CERTAIN LIST# DO NOT SHOW UP WHEN RUN BY NAME 
            'dr.Item("sortdata") = WrkName
            dr.Item("sortdata") = WrkName & " " & ._LISTNo
          Case "List"
            dr.Item("sortdata") = Format(._LISTNo, "000000")
        End Select
        dr.Item("listno") = ._LISTNo
        dr.Item("year") = ._YEAR
        dr.Item("type") = WrkType
        dr.Item("typedesc") = WrkTypeDesc
        AddrLine = MyUtils.SetAddrLine(WrkName, WrkName2, ._ADD1, ._ADD2, ._CITY, ._STATE, ._ZIP5, ._ZIP4)
        dr.Item("addr1") = AddrLine(0)
        dr.Item("addr2") = AddrLine(1)
        dr.Item("addr3") = AddrLine(2)
        dr.Item("addr4") = AddrLine(3)
        dr.Item("addr5") = AddrLine(4)
        dr.Item("name") = WrkName
        dr.Item("sname") = WrkName2
        CalcInterest(._LISTNo, WrkType, ._YEAR, WrkInterest, WrkInterestPaid,
   WrkFee, WrkLien, WrkBond, WrkTax, WrkDue)
        'Filter - Omit no amount due 
        'note does wrkdue take into concideration if it is defer??????   
        If WrkDue = 0 Then
          GoTo NextRec
        End If
        'Filter - Omit below amount due 
        If WrkDue <= WrkOmitBelow Then
          GoTo NextRec
        End If
        ' 7-2-25 changed to use defert if icode = D
        'dr.Item("amtdue") = ._BALD
        If ._ICODE = "D" Then
          dr.Item("amtdue") = ._DEFERT
        Else
          dr.Item("amtdue") = ._BALD
        End If


        dr.Item("Interest") = Format(WrkInterest, "fixed")
        dr.Item("liens") = Format(WrkLien, "fixed")
        dr.Item("fees") = Format(WrkFee, "fixed")
        dr.Item("bond") = Format(WrkBond, "fixed")
        dr.Item("Balance") = Format(WrkDue, "fixed")
        dr.Item("Total") = Format(WrkDue, "fixed")
        If Trim(._ICODE) = "B" Then
          dr.Item("backtax") = True
        Else
          dr.Item("backtax") = False
        End If
        Select Case WrkFamily
          Case "M", "S"
            dr.Item("propdesc") = Trim(._MAKE) & " " & ._MVYR & " " & Trim(._IMVREG)
            dr.Item("propdesc2") = Trim(._IMVIDNo)
          Case "R"
            dr.Item("propdesc") = Trim(._LOCNo) & " " & Trim(._LOC)
            dr.Item("propdesc2") = Trim(._MAP)
          Case "P"
            WrkPropDesc = LookupPPDesc(WrkCode(0))
            If WrkCode(1) > 0 Then
              WrkPropDesc = WrkPropDesc & "," & LookupPPDesc(WrkCode(1))
            End If
            If WrkCode(2) > 0 Then
              WrkPropDesc = WrkPropDesc & "," & LookupPPDesc(WrkCode(2))
            End If
            If WrkCode(3) > 0 Then
              WrkPropDesc = WrkPropDesc & "," & LookupPPDesc(WrkCode(3))
            End If
            dr.Item("propdesc") = WrkPropDesc
            dr.Item("propdesc2") = Trim(._MAP)
          Case Else
            dr.Item("propdesc") = Trim(._LOCNo) & " " & Trim(._LOC)
            dr.Item("propdesc2") = Trim(._MAP)
        End Select
        dr.Item("volpage") = Trim(._VOL) & " " & Trim(._IPAGE)

        If ProfDueDate1 = "" Then
          If ._PHASE = 0 Then
            InvPhs = ""
          Else
            InvPhs = ._PHASE
          End If
          InvDist = ._DIST
          If WrkUsePrintDist Then
            InvDist = ._PDST
          End If
          GetTXPROF(WrkType, WrkGLYear, InvPhs, InvDist)
        End If
        dr.Item("duedate1") = ProfDueDate1
        dr.Item("duedate2") = ProfDueDate2
        dr.Item("barcode") = BuildBarCode(._LISTNo, WrkType, WrkGLYear)

        ds.Tables(0).Rows.Add(dr)
        If WrkPost Then
          UpdateTXINV(._LISTNo, ._YEAR, WrkType)
          WriteTXHST(._LISTNo, ._YEAR, WrkType, WrkTax)
        End If
      End With

      WrkTotCount = WrkTotCount + 1
      WrkTotTax = WrkTotTax + WrkTax
      WrkTotInt = WrkTotInt + WrkInterest
      WrkTotFee = WrkTotFee + WrkFee
      WrkTotLien = WrkTotLien + WrkLien
      WrkTotal = WrkTotal + WrkDue

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
    Next

DoTotals:
    'Bill Totals
    dr = dsTot.Tables(0).NewRow
    dr.Item("description") = "Liens"
    dr.Item("count") = WrkTotCount
    dr.Item("tax") = WrkTotTax
    dr.Item("interest") = WrkTotInt
    dr.Item("fee") = WrkTotFee
    dr.Item("lien") = WrkTotLien
    dr.Item("total") = WrkTotal
    dsTot.Tables(0).Rows.Add(dr)

    myFrmProgress.Close()
    myTXINVQ.CloseFile()

  End Sub
  Public Sub CalcInterest(ByVal InListNo As Integer, ByVal InType As String,
    ByVal InYear As Integer, ByRef OutInterest As Decimal, ByRef OutInterestPaid As Decimal,
    ByRef OutFee As Decimal, ByRef OutLien As Decimal, ByRef OutBond As Decimal, ByRef OutTax As Decimal,
    ByRef OutDue As Decimal)
    With myCASHINT
      .In_IntDate = WrkIntDate
      .In_ListNo = InListNo
      .In_Type = InType
      .In_Year = InYear
      .CalcInterest()
      OutInterest = Format(.Out_Int(), "standard")
      OutInterestPaid = Format(.Out_IntPaid(), "standard")
      OutLien = Format(.Out_Lien(), "standard")
      OutFee = Format(.Out_Fee(), "standard")
      OutBond = Format(.Out_Bond(), "standard")
      OutTax = Format(.Out_Prin(), "standard")
      OutDue = Format(.Out_Tot(), "standard")
    End With
  End Sub
  Private Sub BufferPPDesc()
    Dim I As Integer

    Dim myTXCode As TXCODE.MyData
    Dim dsTXCode As DataSet = New DataSet

    myTXCode = New TXCODE.MyData(myDBConnect)

    dsTXCode = myTXCode.GetAllType("P")
    For I = 0 To dsTXCode.Tables(0).Rows.Count - 1
      With dsTXCode.Tables(0).Rows(I)
        WrkPPCode(I) = .Item("tccode")
        WrkPPDesc(I) = Trim(.Item("tcdesc"))
      End With
    Next

  End Sub
  Private Function LookupPPDesc(ByVal Code As Integer) As String
    Dim I As Integer
    Dim WrkDesc As String

    For I = 0 To WrkPPCode.GetUpperBound(0)
      If WrkPPCode(I) = 0 Then
        Return ""
      End If
      If Code = WrkPPCode(I) Then
        WrkDesc = WrkPPDesc(I)
        Return WrkDesc
      End If
    Next

    Return ""
  End Function
  Private Sub GetTXPROF(ByVal Type As String, ByVal Year As Integer,
    ByVal Phase As String, ByVal District As Integer)
    Dim myTXPROF As TXPROF.MyData

    ProfLien = 0
    ProfDueDate1 = ""
    ProfDueDate2 = ""
    myTXPROF = New TXPROF.MyData(myDBConnect)
    myTXPROF.GetOneRecordP(Type, Year, Phase, District)
    If Not myTXPROF.RecordNotFound Then
      With myTXPROF
        ProfLien = ._PRLIEN
        ProfDueDate1 = MyUtils.GetDBDateMDY(._PRDUE1)
        If ._PRDUE2 > 1 Then
          ProfDueDate2 = MyUtils.GetDBDateMDY(._PRDUE2)
        End If
      End With
    End If

  End Sub
  Private Sub UpdateTXINV(ByVal List As Integer, ByVal Year As Integer, ByVal Type As String)

    myTXINV.GetOneRecordP(List, Year, Type)
    If Not myTXINV.RecordNotFound Then
      With myTXINV
        ._LIEN = "L"
        .UpdateOneRecordP()
      End With
    End If
  End Sub
  Private Sub WriteTXHST(ByVal ListNo As Integer, ByVal Year As Integer, ByVal Type As String,
  ByVal Amount As Decimal)
    Dim WrkRecID As Integer
    With myTXHST
      WrkRecID = .AutoGenKey()
      myTXHST.GetOneRecordP(WrkRecID)
      ._RECID = WrkRecID
      ._RCODE = "I"
      ._LISTNO = ListNo
      ._YEAR = Year
      ._TYPE = Type
      ._PAMT = Amount
      ._IAMT = 0
      ._LAMT = 0
      ._PCAMT = 0
      ._DIST = 0
      ._COMM = "LIENED" 'BchComm
      ._CORC = ""
      ._BATCHN = 0
      ._BATCHA = "L"
      ._PDATE = MyUtils.SetDBDate(MyFrmTX304B.DtPckLien.Value)
      ._CDATE = MyUtils.SetDBDate(Date.Now.Date)
      ._THINPD = ""
      ._PRF = Mid(MyUserID, 1, 10)
      ._CHDATE = MyUtils.SetDBDate(Date.Now.Date)
      ._CHTIME = MyUtils.SetDBTime(Date.Now)
      .AddOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        Exit Sub
      End If
    End With
  End Sub
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
      WrkStrOut = WrkStrIn & " and " & "TYPE IN(" & sbSelect.ToString & ")"
    End If
    sbSelect = Nothing
    Return WrkStrOut
  End Function
End Module
