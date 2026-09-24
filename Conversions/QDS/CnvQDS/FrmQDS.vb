Imports System.Text
Imports System.IO
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Public Class FrmQDS
  Dim sw As StreamWriter
  Public myDBConnect As DBConnection 'QDS Connection #1
  Public myDBConnect2 As DBConnection 'QDS Connection #2
  Public myDBConnect3 As DBConnection 'QDS Connection #3
  Public myDBConnect4 As DBConnection 'QDS Connection #4
  Public myDBConnectGEMS As DBConnection 'GEMS Connection
  Dim MyTOWN As TOWN
  Dim MyTAXCOM As TAXCOM
  Dim MyTXMRATE As TXMRATE
  Dim MyTXPROF As TXPROF
  Dim MyTXTYPE As TXTYPE
  Dim MyTXBANKS As TXBANKS
  Dim MyTXINV As TXINV
  Dim MyTXHST As TXHST
  Dim MyTXREAA As TXREAA
  Dim MyTXREAL As TXREAL
  Dim MyTXPPRA As TXPPRA
  Dim MyTXPPRP As TXPPRP
  Dim MyTXMVA As TXMVA
  Dim MyTXMVD As TXMVD
  Dim MyTXSUPP As TXSUPP
  Dim MyTXSUPA As TXSUPA
  Dim MyTXCOEA As TXCOEA
  Dim MyTXCOEB As TXCOEB
  Dim MyTXM35H As TXM35H
  Dim MyTXM59A As TXM59A
  Dim MyTXVEH As TXVEH
  Dim MyTXVCUS As TXVCUS
  Dim MyTXVCLS As TXVCLS
  Dim MyUTCUST As UTCUST
  Dim MyUTCUSTAS As UTCUSTAS
  Dim MyUTCUSTMT As UTCUSTMT
  Dim MyUTCUSTRT As UTCUSTRT
  Dim WrkGLYear As Integer
  Dim WrkListNo As Integer
  Dim WrkFile As String
  Dim MyGLYear As Integer
  Dim MyMVChgDate As Date
  Dim ProfYear(250) As Integer
  Dim ProfType(250) As String
  Dim ProfNumBills(250) As Integer
  Private Sub BtnConvert_Click(sender As Object, e As EventArgs) Handles BtnConvert.Click
    Dim WrkTimeStamp As String
    'RE/PP/MV/SU Archive only 2022 records for winchester
    MyTXVCLS = New TXVCLS(myDBConnectGEMS.MyConn2)
    WrkTimeStamp = Format(Date.Now, "MMddyyyy HHmmss")
    sw = New StreamWriter(GetDataPath() & "CnvQDS-" & WrkTimeStamp & ".csv")
    ProgBar1.Visible = True
    WrkGLYear = CnvSng(TxtGLYear.Text)
    'WriteTOWN()
    MyGLYear = CnvSng(TxtGLYear.Text)
    MyTOWN = New TOWN(myDBConnectGEMS.MyConn2)
    MyMVChgDate = "#1/31/" & MyGLYear & "#"
    With MyTOWN
      .GetOneRecordP(1)
    End With
    sw.WriteLine(WrkFile & "," & Date.Now)
    FixLiens
    sw.WriteLine(WrkFile & "," & Date.Now)
    sw.Flush()
    sw.Close()
    ProgBar1.Visible = False
    LblMsg.Text = ""
    TxtErrorMsg.Text = TxtErrorMsg.Text & " DONE"
  End Sub
  Private Sub DoNotRun()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXPROF" & vbCrLf
    'WriteMRATE_PROF() 'Millrate/Tax Profile
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TYPE" & vbCrLf
    'WriteTYPE() 'Tax Types
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXBANKS" & vbCrLf
    'WriteBANKS() 'Bank Codes
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXINV" & vbCrLf
    'BufferProf() 'Tax Profile
    'WriteINV() 'Invoice file
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXHST" & vbCrLf
    'WriteHST() 'History file
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXREAL" & vbCrLf
    'WriteRE("TXREAL", WrkGLYear) 'Assessor Real Estate
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXREALC" & vbCrLf
    'WriteRE("TXREALC", WrkGLYear - 1) 'Assessor Real Estate Frozen
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXREAA" & vbCrLf
    'WriteREA("TXREAA") 'Assessor Real Estate Archive
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXM35H" & vbCrLf
    'WriteM35H("TXM35H") 'Assessor M35H Elderly
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXM59A" & vbCrLf
    'WriteM59A("TXM59A") 'Assessor M59A Elderly
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXPPRP" & vbCrLf
    'WritePP("TXPPRP", WrkGLYear) 'Assessor Personal Property
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXPPRPC" & vbCrLf
    'WritePP("TXPPRPC", WrkGLYear - 1) 'Assessor Personal Property Frozen
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXPPRA" & vbCrLf
    'WritePPA("TXPPRA") 'Assessor Personal Property Archive
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXMVD" & vbCrLf
    'WriteMV("TXMVD", WrkGLYear - 1) 'Assessor Motor Vehicle
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXMVDC" & vbCrLf
    'WriteMV("TXMVDC", WrkGLYear - 1) 'Assessor Motor Vehicle Frozen
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXMVA" & vbCrLf
    'WriteMVA("TXMVA") 'Assessor Motor Vehicle Archive
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXCOEB" & vbCrLf
    'WriteCOEB(MyGLYear - 1) 'Before C/C's
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXSUPP" & vbCrLf
    'WriteSU("TXSUPP", WrkGLYear) 'Assessor Supplemental
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXSUPA" & vbCrLf
    'WriteSUA("TXSUPA") 'Assessor Supplemental Archive
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXVCUS" & vbCrLf
    'WriteVEH_VCUS() 'DMV Vehicles & Customers
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXINV-CustID" & vbCrLf
    'UpdateCustID() 'Tax Invoice Customer ID
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TAXCOM2" & vbCrLf
    'WriteTAXCOM2() 'Tax Invoice Comments
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "UpdateINVSuspense" & vbCrLf
    'UpdateINVSuspense() 'Add Suspense Flag, Date & History
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXVCLS" & vbCrLf
    'WriteVCLS() 'DMV Vehicle classes
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "UTCUST" & vbCrLf
    'WriteUTCUST() 'UB Customer file
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "UTCUSTAS" & vbCrLf
    'WriteUTCUSTAS() 'UB Customer Assessment data
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "UTCUSTRT" & vbCrLf
    'WriteUTCUSTRT() 'UB Rate file
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "UTCUST2" & vbCrLf
    'WriteUTCUST2() 'UB Customer file (Meter size/Meter number/Latitude/Longitude)
    'txtErrorMsg.Text = TxtErrorMsg.Text & "UTCUSTMT" & vbCrLf
    'WriteUTCUSTMT() 'UB Meter Readings
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TAXCOM" & vbCrLf
    'WriteTAXCOM() 'UB Comments
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXINVO" & vbCrLf
    'BufferProf() 'Tax Profile
    'TestINV() 'Invoice file
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "FIXUTCUSTRT" & vbCrLf
    'FixUTCUSTRT()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "FixBanks" & vbCrLf
    'FixBanks()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "UpdateInvBond" & vbCrLf
    'UpdateINVBond()
  End Sub

  Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    GetAppSettings()
    myDBConnect = New DBConnection()
    myDBConnect.Open()
    myDBConnect2 = New DBConnection()
    myDBConnect2.Open()
    myDBConnect3 = New DBConnection()
    myDBConnect3.Open()
    myDBConnect4 = New DBConnection()
    myDBConnect4.Open()
    myDBConnectGEMS = New DBConnection()
    myDBConnectGEMS.Open2()
    TxtGLYear.Text = "2024"
  End Sub
  Private Sub WriteTOWN(ByVal WrkFromFile As String)
    Dim ds As DataSet = New DataSet
    Dim I As Integer
    MyTOWN = New TOWN(myDBConnectGEMS.MyConn2)
    myDBConnectGEMS.DeleteRecords2(WrkFromFile)
    ds = myDBConnect.RunQuery("ASSRPARAMETERS", "")
    I = 0
    With MyTOWN
      .GetOneRecordP(1)
      ._ADDR1 = ds.Tables(0).Rows(I).Item("street")
      ._ADDR2 = ""
      ._ASSR = ds.Tables(0).Rows(I).Item("assr_name")
      ._CEREC = ""
      ._CITY = ds.Tables(0).Rows(I).Item("city")
      ._CLERK = ""
      ._COLCTR = ""
      ._COUNTY = ""
      ._PHONE = ""
      ._RECCOD = ""
      ._TOWN = ds.Tables(0).Rows(I).Item("town_title")
      ._TOWNBR = ds.Tables(0).Rows(I).Item("town_code")
      ._ZIP = ds.Tables(0).Rows(I).Item("zip1")
      .AddOneRecordP()
      If .ErrMsg <> String.Empty Then
        sw.WriteLine("TOWN " & .ErrMsg)
      End If
    End With
    ds = Nothing
  End Sub
  Private Sub WriteMRATE_PROF()
    Dim ds As DataSet = New DataSet
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim I As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    MyTXMRATE = New TXMRATE(myDBConnectGEMS.MyConn2)
    myDBConnectGEMS.DeleteRecords2("TXMRATE")
    MyTXPROF = New TXPROF(myDBConnectGEMS.MyConn2)
    myDBConnectGEMS.DeleteRecords2("TXPROF")
    ds = myDBConnect.RunQuery("MILLFILE", "")
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTXMRATE
        Counter = Counter + 1
        WrkType = GetTaxType(MyTOWN._TOWNBR, ds.Tables(0).Rows(I).Item("mill_type"))
        WrkYear = ds.Tables(0).Rows(I).Item("mill_year")
        .GetOneRecordP(WrkYear, WrkType, 0)
        If .RecordNotFound Then
          ._DIST = 0
          ._MRDESC = "TOWN WIDE"
          ._MRFIRE = 0
          ._MRRATE = ds.Tables(0).Rows(I).Item("town_mill_rate") / 1000
          ._TYPE = WrkType
          ._YEAR = WrkYear
          .AddOneRecordP()
          If .ErrMsg <> String.Empty Then
            sw.WriteLine("TXMRATE " & WrkType & WrkYear & " " & .ErrMsg)
          End If
        End If
      End With

      With MyTXPROF
        Counter = Counter + 1
        WrkType = GetTaxType(MyTOWN._TOWNBR, ds.Tables(0).Rows(I).Item("mill_type"))
        WrkYear = ds.Tables(0).Rows(I).Item("mill_year")
        .GetOneRecordP(WrkType, WrkYear, "", 0)
        If .RecordNotFound Then
          ._DIST = 0
          ._PHS = ""
          ._POSTED = "Y"
          ._PRPERD = ds.Tables(0).Rows(I).Item("mill_no_of_inst")
          ._PRDUE1 = ConvertDateMDY(ds.Tables(0).Rows(I).Item("mill_inst1_due_date"))
          ._PRDUE2 = 0
          ._PRDUE3 = 0
          ._PRDUE4 = 0
          ._PRGRD1 = ConvertDateMDY(ds.Tables(0).Rows(I).Item("mill_inst1_last_date"))
          ._PRGRD2 = 0
          ._PRGRD3 = 0
          ._PRGRD4 = 0
          If ._PRPERD >= 2 Then
            ._PRDUE2 = ConvertDateMDY(ds.Tables(0).Rows(I).Item("mill_inst2_due_date"))
            ._PRGRD2 = ConvertDateMDY(ds.Tables(0).Rows(I).Item("mill_inst2_last_date"))
          End If
          If ._PRPERD >= 3 Then
            ._PRDUE3 = ConvertDateMDY(ds.Tables(0).Rows(I).Item("mill_inst3_due_date"))
            ._PRGRD3 = ConvertDateMDY(ds.Tables(0).Rows(I).Item("mill_inst3_last_date"))
          End If
          If ._PRPERD >= 4 Then
            ._PRDUE4 = ConvertDateMDY(ds.Tables(0).Rows(I).Item("mill_inst4_due_date"))
            ._PRGRD4 = ConvertDateMDY(ds.Tables(0).Rows(I).Item("mill_inst4_last_date"))
          End If
          ._PRINT = 0.015
          ._PRLIEN = 24
          ._PRMINI = ds.Tables(0).Rows(I).Item("mill_min_int")
          ._PRPAYC = "UE"
          ._PRPENI = 0
          If ds.Tables(0).Rows(I).Item("mill_town_split_amt") > 0 Then
            ._PRSBIL = ds.Tables(0).Rows(I).Item("mill_town_split_amt")
          Else
            ._PRSBIL = ds.Tables(0).Rows(I).Item("mill_other_split_amt")
          End If
          ._PRTYPE = WrkType
          ._PRWAV = 0
          ._PRYEAR = WrkYear
          .AddOneRecordP()
          If .ErrMsg <> String.Empty Then
            sw.WriteLine("TXPROF " & WrkType & WrkYear & " " & .ErrMsg)
          End If
        End If
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next
    ds = Nothing
  End Sub
  Private Sub WriteTYPE()
    Dim ds As DataSet = New DataSet
    Dim WrkType As String
    Dim I As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    MyTXTYPE = New TXTYPE(myDBConnectGEMS.MyConn2)
    myDBConnectGEMS.DeleteRecords2("TXTYPE")
    ds = myDBConnect.RunQuery("TAX_BILL_TYPES", "")
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTXTYPE
        Counter = Counter + 1
        WrkType = GetTaxType(MyTOWN._TOWNBR, ds.Tables(0).Rows(I).Item("bill_type"))
        .GetOneRecordP(WrkType)
        If .RecordNotFound Then
          ._TXFAM = GetTaxFamily(MyTOWN._TOWNBR, ds.Tables(0).Rows(I).Item("bill_type"))
          ._TXREV = ""
          ._TYCODE = WrkType
          If Trim(ds.Tables(0).Rows(I).Item("long_type_desc")) <> "" Then
            ._TYDESC = ds.Tables(0).Rows(I).Item("long_type_desc")
          Else
            ._TYDESC = ds.Tables(0).Rows(I).Item("type_desc")
          End If
          .AddOneRecordP()
          If .ErrMsg <> String.Empty Then
            sw.WriteLine("TXTYPE " & WrkType & " " & .ErrMsg)
          End If
        End If
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next
    ds = Nothing
  End Sub
  Private Sub WriteBANKS()
    Dim ds As DataSet = New DataSet
    Dim WrkCode As String
    Dim I As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    MyTXBANKS = New TXBANKS(myDBConnectGEMS.MyConn2)
    myDBConnectGEMS.DeleteRecords2("TXBANKS")
    ds = myDBConnect.RunQuery("TAX_BANKS", "")
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTXBANKS
        Counter = Counter + 1
        WrkCode = Trim(ds.Tables(0).Rows(I).Item("bank_code"))
        .GetOneRecordP(WrkCode)
        ._BKADD1 = ConvertString("ADD1", ds.Tables(0).Rows(I).Item("addr1"), 30)
        ._BKADD2 = ConvertString("ADD2", ds.Tables(0).Rows(I).Item("addr2"), 30)
        ._BKADD3 = ""
        ._BKCODE = WrkCode
        ._BKCTY = ConvertString("CITY", ds.Tables(0).Rows(I).Item("city"), 25)
        ._BKNAME = ConvertString("NAME", ds.Tables(0).Rows(I).Item("bank_name"), 30)
        ._BKPRNT = "Y"
        ._BKST = ConvertString("ADD1", ds.Tables(0).Rows(I).Item("state"), 2)
        ._ZIP9 = ds.Tables(0).Rows(I).Item("zip1") & ds.Tables(0).Rows(I).Item("zip2")
        If .RecordNotFound Then
          .AddOneRecordP()
          If .ErrMsg <> String.Empty Then
            sw.WriteLine("TXBANK " & WrkCode & " " & .ErrMsg)
          End If
        End If
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next
    ds = Nothing
  End Sub
  Private Sub BufferProf()
    Dim ds As DataSet = New DataSet
    ds = myDBConnect.RunQuery("MILLFILE", "where mill_year>=" & WrkGLYear - 14 & " and mill_year<=" & WrkGLYear)

    For I = 0 To ds.Tables(0).Rows.Count - 1
      ProfType(I) = GetTaxType(MyTOWN._TOWNBR, ds.Tables(0).Rows(I).Item("mill_type"))
      ProfYear(I) = ds.Tables(0).Rows(I).Item("mill_year")
      ProfNumBills(I) = ds.Tables(0).Rows(I).Item("mill_no_of_inst")
    Next
    ds = Nothing

  End Sub
  Private Function LookupProf(ByVal Year As Integer, ByVal Type As String) As Integer
    Dim I As Integer

    For I = 0 To ProfYear.GetUpperBound(0)
      If ProfYear(I) = 0 Then
        Return -1
      End If
      If Year = ProfYear(I) And Type = ProfType(I) Then
        Return I
      End If
    Next

    Return I
  End Function
  Private Sub WriteINV()
    Dim ds2 As DataSet = New DataSet
    Dim ds3 As DataSet = New DataSet
    Dim ds4 As DataSet = New DataSet
    Dim ds5 As DataSet = New DataSet
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkLien As Boolean
    Dim WrkLienDate As Integer
    Dim WrkLen As Integer
    Dim WrkCCno As Integer
    Dim WrkCCDate As Integer
    Dim WrkSalePct As Decimal
    Dim ArrCode(7) As Integer
    Dim ArrAss(7) As Integer
    Dim WrkFields As String
    Dim WrkRecID As Long
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer
    Dim J As Integer

    MyTXINV = New TXINV(myDBConnectGEMS.MyConn2)
    MyTXCOEA = New TXCOEA(myDBConnectGEMS.MyConn2)
    MyTXHST = New TXHST(myDBConnectGEMS.MyConn2) 'Only for Liens
    myDBConnectGEMS.DeleteRecords2("TXINV") ', " where type='S' and year=2022")
    myDBConnectGEMS.DeleteRecords2("TXCOEA") ', " where type='S' and year=2022")
    myDBConnectGEMS.DeleteRecords2("TXHST", " where rcode='I'")
    'myDBConnect.OpenQry("TAXMAST", " where bill_type=4 And yr=2022")
    myDBConnect.OpenQry("TAXMAST", "")
    WrkFile = "TXINV"
    WrkFields = ""

ReadNext:
    myDBConnect.ReadQry()
    If Not myDBConnect.IsEOF Then
      With MyTXINV
        Counter = Counter + 1
        WrkLien = False
        If myDBConnect.objReader.Item("transfer_flag") = "Y" Then GoTo ReadNext
        WrkListNo = myDBConnect.objReader.Item("bill_num")
        WrkType = GetTaxType(MyTOWN._TOWNBR, myDBConnect.objReader.Item("bill_type"))
        WrkYear = myDBConnect.objReader.Item("yr")
        .GetOneRecordP(WrkListNo, WrkYear, WrkType)
        If .RecordNotFound Then
          ._ABAT = 0
          ._ACD = ""
          ._ACCTN = ""
          ._ADATE = 0
          ._ADD1 = ConvertString("Add1", myDBConnect.objReader.Item("addr"), 35)
          ._ADD2 = ConvertString("Add2", myDBConnect.objReader.Item("addr2"), 35)
          ._AGY = ""
          ._ASS = myDBConnect.objReader.Item("assr_code")
          ._BKCD = ""
          ._BKSR = ""
          ._BODY = ""
          ._BOND = 0
          ._BONDP = 0
          ._BONT = 0
          ._CASS1 = 0
          ._CASS2 = 0
          ._CASS3 = 0
          ._CASS4 = 0
          ._CASS5 = 0
          ._CASS6 = 0
          ._CASS7 = 0
          ._CASS8 = 0
          ._CASS9 = 0
          ._CASS10 = 0
          ._CCCD1 = ""
          ._CCCD2 = ""
          ._CCCD3 = ""
          ._CCCD4 = ""
          ._CCCD5 = ""
          ._CCCD6 = ""
          ._CCCD7 = ""
          ._CCETAX = 0
          ._CCEXP = 0
          ._CCM = ""
          ._CCNO = 0
          ._CCRSN = ""
          ._CCTX1 = 0
          ._CCTX2 = 0
          ._CCTX3 = 0
          ._CCTX4 = 0
          ._CDATE = 0
          ._CEODC = ""
          ._CEXA1 = 0
          ._CEXA2 = 0
          ._CEXA3 = 0
          ._CEXA4 = 0
          ._CEXA5 = 0
          ._CEXA6 = 0
          ._CEXA7 = 0
          ._CGRS = 0
          ._CHDATE = 0
          ._CHTIME = 0
          ._CIRAD = 0
          ._CITY = ConvertString("City", myDBConnect.objReader.Item("city"), 25)
          ._CLASS = CnvSng(myDBConnect.objReader.Item("class"))
          ._CMAX = 0
          ._CMIN = 0
          ._CMVDC = ""
          ._CPERC = 0
          ._DECD = ""
          ._DIST = 0
          ._DOB = ConvertDate(myDBConnect.objReader.Item("dob"))
          ._ETC1 = ""
          ._ETC2 = ""
          ._ETC3 = ""
          ._ETC4 = ""
          ._ETC5 = ""
          ._ETC6 = ""
          ._ETC7 = ""
          ._ETC8 = ""
          ._ETC9 = ""
          ._ETCA = ""
          ._EXAM1 = myDBConnect.objReader.Item("tot_ex")
          ._EXAM2 = 0
          ._EXAM3 = 0
          ._EXAM4 = 0
          ._EXAM5 = 0
          ._EXAM6 = 0
          ._EXAM7 = 0
          If ._EXAM1 > 0 Then
            ._EXCD1 = "A"
          Else
            ._EXCD1 = ""
          End If
          ._EXCD2 = ""
          ._EXCD3 = ""
          ._EXCD4 = ""
          ._EXCD5 = ""
          ._EXCD6 = ""
          ._EXCD7 = ""
          ._FASS = 0
          ._FEC1 = ""
          ._FEC2 = ""
          ._FEC3 = ""
          ._FEC4 = ""
          ._FEC5 = ""
          ._FED1 = 0
          ._FED2 = 0
          ._FED3 = 0
          ._FED4 = 0
          ._FED5 = 0
          ._FRCD = ""
          ._FRYR = 0
          ._FTAX = 0
          ._GROSS = myDBConnect.objReader.Item("prop_val")
          ._ICODE = ""
          ._SUSCD = ""
          ._SUSDT = 0
          ._ICODE = ""
          ._ICVACD = ""
          ._ICVCLS = 0
          ._ICVGRS = 0 ' myDBConnect.objReader.Item("prop_val")
          ._ICVIDNo = ""
          ._ICVMKE = ""
          ._ICVMOD = ""
          ._ICVREG = ""
          ._ICVYR = 0
          ._ILEASE = ""
          ._IMVIDNo = myDBConnect.objReader.Item("vin_id")
          ._IMVREG = myDBConnect.objReader.Item("reg_no")
          ._INPCT = 0
          ._INTPD = 0
          ._INTY = ""
          ._IPAGE = myDBConnect.objReader.Item("pag")
          ._IPPCD1 = 0
          ._IPPCD2 = 0
          ._IPPCD3 = 0
          ._IPPCD4 = 0
          ._IPPCD5 = 0
          ._IPPCD6 = 0
          ._IPPCD7 = 0
          ._IPPCD8 = 0
          ._IPPCD9 = 0
          ._IPPCDA = 0
          ._OAS1 = 0
          ._OAS10 = 0
          ._OAS2 = 0
          ._OAS3 = 0
          ._OAS4 = 0
          ._OAS5 = 0
          ._OAS6 = 0
          ._OAS7 = 0
          ._OAS8 = 0
          ._OAS9 = 0
          Array.Clear(ArrCode, 0, 7)
          Array.Clear(ArrAss, 0, 7)
          If WrkType = "P" Then
            J = -1
            ds4 = myDBConnect2.RunQuery("ASSRPERS", "where record_year=" & WrkYear & " And list_no=" & WrkListNo)
            If ds4.Tables(0).Rows.Count > 0 Then
              If ds4.Tables(0).Rows(0).Item("code1") > 0 Then
                J = J + 1
                ArrCode(J) = ds4.Tables(0).Rows(0).Item("code1")
                ArrAss(J) = ds4.Tables(0).Rows(0).Item("amount1")
              End If
              If ds4.Tables(0).Rows(0).Item("code2") > 0 Then
                J = J + 1
                ArrCode(J) = ds4.Tables(0).Rows(0).Item("code2")
                ArrAss(J) = ds4.Tables(0).Rows(0).Item("amount2")
              End If
              If ds4.Tables(0).Rows(0).Item("code3") > 0 Then
                J = J + 1
                ArrCode(J) = ds4.Tables(0).Rows(0).Item("code3")
                ArrAss(J) = ds4.Tables(0).Rows(0).Item("amount3")
              End If
              If ds4.Tables(0).Rows(0).Item("code4") > 0 Then
                J = J + 1
                ArrCode(J) = ds4.Tables(0).Rows(0).Item("code4")
                ArrAss(J) = ds4.Tables(0).Rows(0).Item("amount4")
              End If
              If ds4.Tables(0).Rows(0).Item("code5") > 0 Then
                J = J + 1
                ArrCode(J) = ds4.Tables(0).Rows(0).Item("code5")
                ArrAss(J) = ds4.Tables(0).Rows(0).Item("amount5")
              End If
              If ds4.Tables(0).Rows(0).Item("code6") > 0 Then
                J = J + 1
                ArrCode(J) = ds4.Tables(0).Rows(0).Item("code6")
                ArrAss(J) = ds4.Tables(0).Rows(0).Item("amount6")
              End If
              If ds4.Tables(0).Rows(0).Item("code7") > 0 Then
                J = J + 1
                ArrCode(J) = ds4.Tables(0).Rows(0).Item("code7")
                ArrAss(J) = ds4.Tables(0).Rows(0).Item("amount7")
              End If
              If ds4.Tables(0).Rows(0).Item("code8") > 0 Then
                J = J + 1
                ArrCode(J) = ds4.Tables(0).Rows(0).Item("code8")
                ArrAss(J) = ds4.Tables(0).Rows(0).Item("amount8")
              End If
              ._IPPCD1 = ArrCode(0)
              ._IPPCD2 = ArrCode(1)
              ._IPPCD3 = ArrCode(2)
              ._IPPCD4 = ArrCode(3)
              ._IPPCD5 = ArrCode(4)
              ._IPPCD6 = ArrCode(5)
              ._IPPCD7 = ArrCode(6)
              ._IPPCD8 = ArrCode(7)
              ._OAS1 = ArrAss(0)
              ._OAS2 = ArrAss(1)
              ._OAS3 = ArrAss(2)
              ._OAS4 = ArrAss(3)
              ._OAS5 = ArrAss(4)
              ._OAS6 = ArrAss(5)
              ._OAS7 = ArrAss(6)
              ._OAS8 = ArrAss(7)
            End If
          End If
          If WrkType = "R" Then
            J = -1
            ds4 = myDBConnect2.RunQuery("ASSRREAL", "where record_year=" & WrkYear & " And list_no=" & WrkListNo)
            If ds4.Tables(0).Rows.Count > 0 Then
              If ds4.Tables(0).Rows(0).Item("code_old1") > 0 Then
                J = J + 1
                ArrCode(J) = ds4.Tables(0).Rows(0).Item("code_old1")
                ArrAss(J) = ds4.Tables(0).Rows(0).Item("amount1")
              End If
              If ds4.Tables(0).Rows(0).Item("code_old2") > 0 Then
                J = J + 1
                ArrCode(J) = ds4.Tables(0).Rows(0).Item("code_old2")
                ArrAss(J) = ds4.Tables(0).Rows(0).Item("amount2")
              End If
              If ds4.Tables(0).Rows(0).Item("code_old3") > 0 Then
                J = J + 1
                ArrCode(J) = ds4.Tables(0).Rows(0).Item("code_old3")
                ArrAss(J) = ds4.Tables(0).Rows(0).Item("amount3")
              End If
              If ds4.Tables(0).Rows(0).Item("code_old4") > 0 Then
                J = J + 1
                ArrCode(J) = ds4.Tables(0).Rows(0).Item("code_old4")
                ArrAss(J) = ds4.Tables(0).Rows(0).Item("amount4")
              End If
              If ds4.Tables(0).Rows(0).Item("code_old5") > 0 Then
                J = J + 1
                ArrCode(J) = ds4.Tables(0).Rows(0).Item("code_old5")
                ArrAss(J) = ds4.Tables(0).Rows(0).Item("amount5")
              End If
              If ds4.Tables(0).Rows(0).Item("code_old6") > 0 Then
                J = J + 1
                ArrCode(J) = ds4.Tables(0).Rows(0).Item("code_old6")
                ArrAss(J) = ds4.Tables(0).Rows(0).Item("amount6")
              End If
              If ds4.Tables(0).Rows(0).Item("code_old7") > 0 Then
                J = J + 1
                ArrCode(J) = ds4.Tables(0).Rows(0).Item("code_old7")
                ArrAss(J) = ds4.Tables(0).Rows(0).Item("amount7")
              End If
              If ds4.Tables(0).Rows(0).Item("code_old8") > 0 Then
                J = J + 1
                ArrCode(J) = ds4.Tables(0).Rows(0).Item("code_old8")
                ArrAss(J) = ds4.Tables(0).Rows(0).Item("amount8")
              End If
              ._IPPCD1 = ArrCode(0)
              ._IPPCD2 = ArrCode(1)
              ._IPPCD3 = ArrCode(2)
              ._IPPCD4 = ArrCode(3)
              ._IPPCD5 = ArrCode(4)
              ._IPPCD6 = ArrCode(5)
              ._IPPCD7 = ArrCode(6)
              ._IPPCD8 = ArrCode(7)
              ._OAS1 = ArrAss(0)
              ._OAS2 = ArrAss(1)
              ._OAS3 = ArrAss(2)
              ._OAS4 = ArrAss(3)
              ._OAS5 = ArrAss(4)
              ._OAS6 = ArrAss(5)
              ._OAS7 = ArrAss(6)
              ._OAS8 = ArrAss(7)
            End If
          End If
          ._LETT = Mid(myDBConnect.objReader.Item("txpr_name"), 1, 1)
          If Trim(myDBConnect.objReader.Item("lien_code")) <> "" Then
            ._LIEN = myDBConnect.objReader.Item("lien_code")
            WrkLien = True
          Else
            ._LIEN = ""
          End If
          ._LISTNo = WrkListNo
          ._LNPD = 0
          ._LOC = ConvertString("Loc", myDBConnect.objReader.Item("prop_loc_name"), 25)
          ._LOCNo = JustifyRight(myDBConnect.objReader.Item("prop_loc_num"), 7)
          ._MAKE = myDBConnect.objReader.Item("make")
          ._MAP = ConvertString("Map", myDBConnect.objReader.Item("mbl"), 17)
          ._MODEL = myDBConnect.objReader.Item("model")
          ._MVFLAG = ""
          ._MVYR = myDBConnect.objReader.Item("year")
          If Trim(myDBConnect.objReader.Item("current_owner")) <> "" Then
            ._NAME = ConvertString("Name", myDBConnect.objReader.Item("current_owner"), 35)
          Else
            ._NAME = ConvertString("Name", myDBConnect.objReader.Item("txpr_name"), 35)
          End If
          ._NEWPAY = 0
          ._SNAME = ConvertString("Sname", myDBConnect.objReader.Item("co_name"), 35)
          ._OID = ""
          ._PCD = ""
          ._PDAT = 0
          ._PDST = 0
          ._PHASE = 0
          ._PINPD = 0
          ._PDST = 0
          ._PRF = ""
          ._PRINT = 0
          ._PRLIN = 0
          ._PRPRI = 0
          ._RLST = 0
          ._SS2 = 0
          ._SSNo = 0
          ._STATE = myDBConnect.objReader.Item("state")
          If myDBConnect.objReader.Item("warrant_flag") = "Y" Then
            ._STCD1 = "S"
          Else
            ._STCD1 = ""
          End If
          ._STCD2 = ""
          ._STCD3 = ""
          ._STCD4 = ""
          ._STCD5 = ""
          ._SUSCD = ""
          ._SUSDT = 0
          ._TIN = ""
          ._TOTEXP = myDBConnect.objReader.Item("tot_ex")
          ._TWNBN = 0
          ._TXIDT = 0
          ._TXINT = 0
          ._TYPE = WrkType
          ._UNIT1 = 0
          ._UNIT2 = 0
          ._UNIT3 = 0
          ._UNIT4 = 0
          ._UNIT5 = 0
          ._UNIT6 = 0
          ._UNIT7 = 0
          ._UNIT8 = 0
          ._UNIT9 = 0
          ._UNITA = 0
          ._VOL = myDBConnect.objReader.Item("vol")
          ._XDATE = 0
          ._YEAR = myDBConnect.objReader.Item("yr")
          ._ZIP4 = CnvSng(myDBConnect.objReader.Item("zip2"))
          ._ZIP5 = CnvSng(myDBConnect.objReader.Item("zip1"))
          ._NETASS = ._GROSS - ._EXAM1
          ._TAX1 = 0
          ._TAX2 = 0
          ._TX3RD = 0
          ._TX4TH = 0
          ._TAXT = 0
          ._BALD = 0
          ._PAYREC = 0

          WrkCCno = 0
          WrkFields = "coc_number,coc_date,Tax_Due_Old,Adj_Tax,coc_type,Org_Net,Change_Reason,Tax_Due_New,
           New_Net,Adj_Net,Net_Inc_Dec,t_cb_or_freeze,Org_Net,Total_Exempt_New,New_Gross,MV_Vehicle_ID,TaxPayer,User_ID"
          ds3 = myDBConnect3.RunQuery("COC_DATA", "where grand_list_year=" & WrkYear & " And bill_type=" &
          myDBConnect.objReader.Item("bill_type") & " And bill_number=" & WrkListNo & " Order By coc_date", WrkFields)
          If ds3.Tables(0).Rows.Count > 0 Then
            For I = 0 To ds3.Tables(0).Rows.Count - 1
              WrkLen = Len(Trim(ds3.Tables(0).Rows(I).Item("coc_number")))
              WrkCCno = Mid(ds3.Tables(0).Rows(I).Item("coc_number"), 1, WrkLen - 1) 'All digits 
              WrkCCDate = SetDBDate(ds3.Tables(0).Rows(I).Item("coc_date"))
              If CnvSng(ds3.Tables(0).Rows(I).Item("Tax_Due_Old")) > 0 Then
                WrkSalePct = CnvSng(ds3.Tables(0).Rows(I).Item("Adj_Tax")) / CnvSng(ds3.Tables(0).Rows(I).Item("Tax_Due_Old"))
              Else
                WrkSalePct = 1
              End If
              WrkSalePct = Math.Round(WrkSalePct, 3)
              If Trim(ds3.Tables(0).Rows(I).Item("coc_type")) = "B" Then
                WrkCCno = 0
              End If
              If WrkCCno > 0 Then
                With MyTXCOEA
                  Counter = Counter + 1
                  .GetOneRecordP(WrkCCno)
                  If .RecordNotFound Then
                    ._AFTER = ""
                    ._ASS1 = ds3.Tables(0).Rows(I).Item("Org_Net")
                    ._ASS10 = 0
                    ._ASS2 = 0
                    ._ASS3 = 0
                    ._ASS4 = 0
                    ._ASS5 = 0
                    ._ASS6 = 0
                    ._ASS7 = 0
                    ._ASS8 = 0
                    ._ASS9 = 0
                    ._C1CPCD = ""
                    ._C1CSCD = ""
                    Select Case WrkType
                      Case "M"
                        ._C1MPCD = "A"
                      Case "S"
                        ._C1MPCD = ""
                        ds5 = myDBConnect2.RunQuery("MVS_COC_VALUES", "where coc_year=" & WrkYear & " And unique_id=" & WrkListNo)
                        If ds5.Tables(0).Rows.Count > 0 Then
                          ._C1MPCD = ds5.Tables(0).Rows(0).Item("Month_code")
                        End If
                        If ._C1MPCD = "" Then
                          ._C1MPCD = "A"
                        End If
                        ._C1MSCD = GetSaleCode(WrkType, WrkSalePct)
                      Case Else
                        ._C1MPCD = ""
                    End Select
                    ._C2CPCD = ""
                    ._C2CSCD = ""
                    ._C2MPCD = ""
                    ._CCNO = WrkCCno
                    ._CDATE = WrkCCDate
                    ._CDESC = ConvertString("CDESC", ds3.Tables(0).Rows(I).Item("Change_Reason"), 25)
                    ._CETAX = ds3.Tables(0).Rows(I).Item("Tax_Due_New")
                    ._CGRS = ds3.Tables(0).Rows(I).Item("New_Net")
                    ._CHDATE = WrkCCDate
                    ._CHTIME = 0
                    If Trim(ds3.Tables(0).Rows(I).Item("Net_Inc_Dec")) = "NC" And Trim(ds3.Tables(0).Rows(I).Item("t_cb_or_freeze") = "") Then
                      ._CNETAS = Math.Round(ds3.Tables(0).Rows(I).Item("Org_Net") * (1 - WrkSalePct))
                    Else
                      ._CNETAS = ds3.Tables(0).Rows(I).Item("Org_Net")
                    End If
                    ._CPCD1 = ArrCode(0)
                    ._CPCD2 = 0
                    ._CPCD3 = 0
                    ._CPCD4 = 0
                    ._CPCD5 = 0
                    ._CPCD6 = 0
                    ._CPCD7 = 0
                    ._CPCD8 = 0
                    ._CPCD9 = 0
                    ._CPCDA = 0
                    If WrkType = "M" Or WrkType = "S" Then
                      ._CTXOV = "Y"
                    Else
                      ._CTXOV = "N"
                    End If
                    ._DIST = 0
                    If ds3.Tables(0).Rows(I).Item("Total_Exempt_New") < 9999999 Then
                      ._EX1 = ds3.Tables(0).Rows(I).Item("Total_Exempt_New")
                    Else
                      ._EX1 = 0
                      sw.WriteLine("TXCOEA: EX1 " & ds3.Tables(0).Rows(I).Item("Total_Exempt_New"))
                    End If
                    ._EX2 = 0
                    ._EX3 = 0
                    ._EX4 = 0
                    ._EX5 = 0
                    ._EX6 = 0
                    ._EX7 = 0
                    ._EXCD1 = ""
                    ._EXCD2 = ""
                    ._EXCD3 = ""
                    ._EXCD4 = ""
                    ._EXCD5 = ""
                    ._EXCD6 = ""
                    ._EXCD7 = ""
                    ._EXCHG = 0
                    'If Trim(ds3.Tables(0).Rows(I).Item("Ex_Inc_Dec")) = "DEC" Then
                    ' ._EXCHG = ds3.Tables(0).Rows(I).Item("Adj_Exempt") * -1
                    ' Else
                    ' ._EXCHG = ds3.Tables(0).Rows(I).Item("Adj_Exempt")
                    'End If
                    If Trim(ds3.Tables(0).Rows(I).Item("Net_Inc_Dec")) = "DEC" Then
                      ._GRCHG = ds3.Tables(0).Rows(I).Item("Adj_Net") * -1
                    Else
                      ._GRCHG = ds3.Tables(0).Rows(I).Item("Adj_Net")
                    End If
                    ._IMVIDNo = ds3.Tables(0).Rows(I).Item("MV_Vehicle_ID")
                    ._LISTNo = WrkListNo
                    ._NAME = ConvertString("NAME", ds3.Tables(0).Rows(I).Item("TaxPayer"), 35)
                    ._NEWMVC = 0
                    ._PRF = ds3.Tables(0).Rows(I).Item("User_ID")
                    ._RSNCD = ""
                    ._SUSCD = ""
                    ._TYPE = WrkType
                    ._YEAR = WrkYear
                    .AddOneRecordP()
                    If .ErrMsg <> String.Empty Then
                      sw.WriteLine("COEA " & .ErrMsg)
                    End If
                  Else
                    sw.WriteLine(WrkFile & ", " & WrkListNo & ", Dup CC:  ," & WrkCCno)
                  End If
                End With
              End If
            Next
          End If

          I = I - 1
          WrkFields = "city_tax1,city_tax2,city_tax3,city_tax4,city_total_due,city_paid_tax1,lien_date,
           City_Adj1,City_Adj2,City_Adj3,City_Adj4,City_Total_Adj,adj_date"
          ds2 = myDBConnect2.RunQuery("INSTFILE", "where yr=" & WrkYear & " and bill_type=" &
          myDBConnect.objReader.Item("bill_type") & " and bill_num=" & WrkListNo, WrkFields)
          If ds2.Tables(0).Rows.Count > 0 Then
            ._TAX1 = ds2.Tables(0).Rows(0).Item("city_tax1")
            ._TAX2 = ds2.Tables(0).Rows(0).Item("city_tax2")
            ._TX3RD = ds2.Tables(0).Rows(0).Item("city_tax3")
            ._TX4TH = ds2.Tables(0).Rows(0).Item("city_tax4")
            ._BALD = ds2.Tables(0).Rows(0).Item("city_total_due")
            ._PAYREC = ds2.Tables(0).Rows(0).Item("city_paid_tax1")
            ._TAXT = ._TAX1 + ._TAX2 + ._TX3RD + ._TX4TH
            If WrkLien Then
              WrkLienDate = ConvertDate(ds2.Tables(0).Rows(0).Item("lien_date"))
              If WrkLienDate = 0 Then
                WrkLienDate = 20000101 'if no lien date then make it 1/1/2000
              End If
            End If
            If WrkCCno > 0 Then
              ._CCNO = WrkCCno
              ._CDATE = WrkCCDate
              ._CCETAX = CnvSng(ds3.Tables(0).Rows(I).Item("Tax_Due_New"))
              ._CCEXP = CnvSng(ds3.Tables(0).Rows(I).Item("Total_Exempt_New"))
              ._CCRSN = ""
              ._CCTX1 = CnvSng(ds2.Tables(0).Rows(0).Item("City_Tax1")) + CnvSng(ds2.Tables(0).Rows(0).Item("City_Adj1"))
              ._CCTX2 = CnvSng(ds2.Tables(0).Rows(0).Item("City_Tax2")) + CnvSng(ds2.Tables(0).Rows(0).Item("City_Adj2"))
              ._CCTX3 = CnvSng(ds2.Tables(0).Rows(0).Item("City_Tax3")) + CnvSng(ds2.Tables(0).Rows(0).Item("City_Adj3"))
              ._CCTX4 = CnvSng(ds2.Tables(0).Rows(0).Item("City_Tax4")) + CnvSng(ds2.Tables(0).Rows(0).Item("City_Adj4"))
              ._CEODC = ""
              ._CASS1 = ds3.Tables(0).Rows(I).Item("New_Net")
              ._CEXA1 = CnvSng(ds3.Tables(0).Rows(I).Item("Total_Exempt_New"))
              ._CEXA2 = 0
              ._CEXA3 = 0
              ._CEXA4 = 0
              ._CEXA5 = 0
              ._CEXA6 = 0
              ._CEXA7 = 0
              ._CGRS = ds3.Tables(0).Rows(I).Item("New_Gross")
              ._BALD = ._CCETAX - ._PAYREC
            Else
              If CnvSng(ds2.Tables(0).Rows(0).Item("City_Total_Adj")) <> 0 Then
                ._CCNO = 99999
                ._CDATE = SetDBDate(ds2.Tables(0).Rows(0).Item("adj_date"))
                ._CCEXP = 0
                ._CCRSN = ""
                ._CCTX1 = CnvSng(ds2.Tables(0).Rows(0).Item("City_Tax1")) + CnvSng(ds2.Tables(0).Rows(0).Item("City_Adj1"))
                ._CCTX2 = CnvSng(ds2.Tables(0).Rows(0).Item("City_Tax2")) + CnvSng(ds2.Tables(0).Rows(0).Item("City_Adj2"))
                ._CCTX3 = CnvSng(ds2.Tables(0).Rows(0).Item("City_Tax3")) + CnvSng(ds2.Tables(0).Rows(0).Item("City_Adj3"))
                ._CCTX4 = CnvSng(ds2.Tables(0).Rows(0).Item("City_Tax4")) + CnvSng(ds2.Tables(0).Rows(0).Item("City_Adj4"))
                ._CCETAX = ._CCTX1 + ._CCTX2 + ._CCTX3 + ._CCTX4
                ._CEODC = ""
                ._CEXA1 = 0
                ._CEXA2 = 0
                ._CEXA3 = 0
                ._CEXA4 = 0
                ._CEXA5 = 0
                ._CEXA6 = 0
                ._CEXA7 = 0
                ._CGRS = 0
                ._BALD = ._CCETAX - ._PAYREC
              End If
            End If
          End If
          .InsertOneRecordP()
        End If
      End With

      If WrkLien Then
        With MyTXHST
          WrkRecID = .AutoGenKey(0, 0)
          .GetOneRecordP(WrkRecID)
          ._RECID = WrkRecID
          ._RCODE = "I"
          ._LISTNO = WrkListNo
          ._YEAR = WrkYear
          ._TYPE = WrkType
          ._PAMT = 0
          ._IAMT = 0
          ._LAMT = 0
          ._PCAMT = 0
          ._DIST = 0
          ._COMM = "LIENED" 'BchComm
          ._CORC = ""
          ._BATCHN = 0
          ._BATCHA = "L"
          ._PDATE = WrkLienDate
          ._CDATE = ._PDATE
          ._THINPD = ""
          ._PRF = ""
          ._CHDATE = 0
          ._CHTIME = 0
          .InsertOneRecordP()
        End With
      End If

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
        GoTo ReadNext
      End If
    End If
  End Sub
  Private Sub WriteHST()
    Const cMaxInt As Decimal = 99999.99
    Dim ds As DataSet = New DataSet
    Dim dsBulk As DataSet = New DataSet
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkOrigType As String
    Dim I As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Integer
    Dim WrkRecID As Integer
    MyTXHST = New TXHST(myDBConnectGEMS.MyConn2)
    myDBConnectGEMS.DeleteRecords2("TXHST")
    'ds = myDBConnect.RunQuery("HISTORY", " where yr=2017")
    ds = myDBConnect.RunQuery("HISTORY", "")
    WrkFile = "TXHST"
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTXHST
        Counter = Counter + 1
        WrkListNo = ds.Tables(0).Rows(I).Item("bill_num")
        WrkType = GetTaxType(MyTOWN._TOWNBR, ds.Tables(0).Rows(I).Item("bill_type"))
        WrkYear = ds.Tables(0).Rows(I).Item("yr")
        If WrkYear < cOldYearHist And WrkType <> "A" Then
          GoTo NextRec
        End If
        WrkRecID = WrkRecID + 1
        ._ADJCD = ""
        ._COMM = ""
        ._PRF = ds.Tables(0).Rows(I).Item("reg_batch_clerk_id")
        If ds.Tables(0).Rows(I).Item("pay_type") = "A" Then
          GoTo NextRec
        End If
        If ds.Tables(0).Rows(I).Item("pay_type") = "C" Then
          If ds.Tables(0).Rows(I).Item("city_amt") < 0 Then
            ._ADJCD = "A"
          End If
        End If
        If ds.Tables(0).Rows(I).Item("pay_type") = "R" Then
          If ds.Tables(0).Rows(I).Item("city_amt") < 0 Then
            ._ADJCD = "R"
          End If
        End If
        If ds.Tables(0).Rows(I).Item("pay_type") = "V" Then
          If ds.Tables(0).Rows(I).Item("prepay_flag") = "TRF" Then
            If ds.Tables(0).Rows(I).Item("city_amt") < 0 Then
              ._ADJCD = "A"
              ._PRF = "TXA12"
              WrkOrigType = GetTaxType(MyTOWN._TOWNBR, ds.Tables(0).Rows(I).Item("orig_bill_type"))
              ._COMM = "TO " & ds.Tables(0).Rows(I).Item("orig_bill_num") & "-" & WrkOrigType & "-" &
                ds.Tables(0).Rows(I).Item("orig_yr")
            End If
          Else
            If ds.Tables(0).Rows(I).Item("city_amt") < 0 Then
              ._ADJCD = "A"
            End If
          End If
        End If
        If ds.Tables(0).Rows(I).Item("pay_type") = "P" Then
          If ds.Tables(0).Rows(I).Item("prepay_flag") = "TRP" Then
            ._ADJCD = "A"
            ._PRF = "TXA12"
            WrkOrigType = GetTaxType(MyTOWN._TOWNBR, ds.Tables(0).Rows(I).Item("orig_bill_type"))
            ._COMM = "FROM " & ds.Tables(0).Rows(I).Item("orig_bill_num") & "-" & WrkOrigType & "-" &
                ds.Tables(0).Rows(I).Item("orig_yr")
          End If
        End If
        ._BATCHA = ""
        ._BATCHN = ds.Tables(0).Rows(I).Item("batch_no")
        ._BATCHS = ds.Tables(0).Rows(I).Item("trans_no")
        ._CASH = 0
        ._CDATE = ConvertDate(ds.Tables(0).Rows(I).Item("effective_date"))
        ._CHDATE = ConvertDate(ds.Tables(0).Rows(I).Item("pay_date"))
        ._CHECK = 0
        ._CHTIME = 0
        ._CORC = ""
        ._CREDIT = 0
        ._DIST = 0
        If ds.Tables(0).Rows(I).Item("city_int") <= cMaxInt Then
          ._IAMT = ds.Tables(0).Rows(I).Item("city_int")
        Else
          ._IAMT = cMaxInt
          sw.WriteLine(WrkFile & ",Iamt:," & ds.Tables(0).Rows(I).Item("city_int"))
        End If
        ._INTOR = 0
        ._LAMT = ds.Tables(0).Rows(I).Item("city_lien")
        ._LISTNO = WrkListNo
        If ds.Tables(0).Rows(I).Item("city_adj_amt") <> 0 Then
          ._PAMT = ds.Tables(0).Rows(I).Item("city_adj_amt")
        Else
          ._PAMT = ds.Tables(0).Rows(I).Item("city_amt")
        End If
        ._PCAMT = ds.Tables(0).Rows(I).Item("city_fees") + ds.Tables(0).Rows(I).Item("city_b_int")
        ._PDATE = ConvertDate(ds.Tables(0).Rows(I).Item("pay_date"))
        ._PENCD = ds.Tables(0).Rows(I).Item("fee_code")
        ._RCODE = ""
        If ds.Tables(0).Rows(I).Item("suspense_flag") = "S" Or ds.Tables(0).Rows(I).Item("suspense_flag") = "Y" Then
          ._RCODE = "S"
        End If
        ._RECID = WrkRecID
        ._REF = ""
        ._SUSCD = ""
        ._THAJCD = ""
        ._THINPD = 0
        ._TYPE = WrkType
        ._YEAR = WrkYear
        .InsertOneRecordP()
      End With

NextRec:
      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next

    ds = Nothing
  End Sub
  'Private Sub WriteCOEA()
  '  Dim ds As DataSet = New DataSet
  '  Dim ds2 As DataSet = New DataSet
  '  Dim WrkPct As Decimal
  '  Dim SavePct As Decimal
  '  Dim Counter As Decimal
  '  Dim I As Integer
  '  Dim WrkType As String
  '  Dim WrkYear As Integer
  '  Dim WrkLen As Integer
  '  Dim WrkCCNo As Integer
  '  Dim WrkCCDate As Integer
  '  Dim WrkCCTax1 As Decimal
  '  Dim WrkCCTax2 As Decimal
  '  Dim WrkCCTax3 As Decimal
  '  Dim WrkCCTax4 As Decimal
  '  Dim WrkSalePct As Decimal

  '  MyTOWN = New TOWN(myDBConnectGEMS.MyConn2)
  '  MyTXCOEA = New TXCOEA(myDBConnectGEMS.MyConn2)
  '  MyTXINV = New TXINV(myDBConnectGEMS.MyConn2)
  '  myDBConnectGEMS.DeleteRecords2("TXCOEA")
  '  ds = myDBConnect.RunQuery("COC_DATA", " order by coc_number")
  '  'ds = myDBConnect.RunQuery("COC_DATA", " where Grand_list_year=2017 order by coc_number")
  '  For I = 0 To ds.Tables(0).Rows.Count - 1
  '    WrkListNo = ds.Tables(0).Rows(I).Item("bill_number")
  '    WrkLen = Len(Trim(ds.Tables(0).Rows(I).Item("coc_number")))
  '    WrkType = Mid(ds.Tables(0).Rows(I).Item("coc_number"), WrkLen, 1) 'Last char
  '    WrkYear = ds.Tables(0).Rows(I).Item("grand_list_year")
  '    WrkCCNo = Mid(ds.Tables(0).Rows(I).Item("coc_number"), 1, WrkLen - 1) 'All digits 
  '    WrkCCDate = SetDBDate(ds.Tables(0).Rows(I).Item("coc_date"))
  '    If CnvSng(ds.Tables(0).Rows(I).Item("Tax_Due_Old")) > 0 Then
  '      WrkSalePct = CnvSng(ds.Tables(0).Rows(I).Item("Adj_Tax")) / CnvSng(ds.Tables(0).Rows(I).Item("Tax_Due_Old"))
  '    Else
  '      WrkSalePct = 1
  '    End If
  '    WrkSalePct = Math.Round(WrkSalePct, 3)
  '    If Trim(ds.Tables(0).Rows(I).Item("coc_type")) = "B" Then
  '      Continue For
  '    End If
  '    With MyTXCOEA
  '      Counter = Counter + 1
  '      .GetOneRecordP(WrkCCNo)
  '      If Not .RecordNotFound Then
  '        sw.WriteLine(WrkFile & "," & WrkListNo & ",Dup CC:," & WrkCCNo)
  '        Continue For
  '      End If
  '      ._AFTER = ""
  '      ._ASS1 = ds.Tables(0).Rows(I).Item("New_Gross")
  '      ._ASS10 = 0
  '      ._ASS2 = 0
  '      ._ASS3 = 0
  '      ._ASS4 = 0
  '      ._ASS5 = 0
  '      ._ASS6 = 0
  '      ._ASS7 = 0
  '      ._ASS8 = 0
  '      ._ASS9 = 0
  '      ._C1CPCD = ""
  '      ._C1CSCD = ""
  '      ._C1MPCD = ""
  '      ._C1MSCD = GetSaleCode(WrkType, WrkSalePct)
  '      ._C2CPCD = ""
  '      ._C2CSCD = ""
  '      ._C2MPCD = ""
  '      ._CCNO = WrkCCNo
  '      ._CDATE = WrkCCDate
  '      ._CDESC = ConvertString("CDESC", ds.Tables(0).Rows(I).Item("Change_Reason"), 25)
  '      ._CETAX = ds.Tables(0).Rows(I).Item("Tax_Due_New")
  '      ._CGRS = ds.Tables(0).Rows(I).Item("New_Gross")
  '      ._CHDATE = WrkCCDate
  '      ._CHTIME = 0
  '      If Trim(ds.Tables(0).Rows(I).Item("Net_Inc_Dec")) = "NC" And Trim(ds.Tables(0).Rows(I).Item("t_cb_or_freeze") = "") Then
  '        ._CNETAS = Math.Round(ds.Tables(0).Rows(I).Item("New_Net") * (1 - WrkSalePct))
  '      Else
  '        ._CNETAS = ds.Tables(0).Rows(I).Item("New_Net")
  '      End If
  '      ._CPCD1 = 0
  '      ._CPCD2 = 0
  '      ._CPCD3 = 0
  '      ._CPCD4 = 0
  '      ._CPCD5 = 0
  '      ._CPCD6 = 0
  '      ._CPCD7 = 0
  '      ._CPCD8 = 0
  '      ._CPCD9 = 0
  '      ._CPCDA = 0
  '      If WrkType = "M" Or WrkType = "S" Then
  '        ._CTXOV = "Y"
  '      Else
  '        ._CTXOV = "N"
  '      End If
  '      ._DIST = 0
  '      ._EX1 = ds.Tables(0).Rows(I).Item("Adj_Exempt")
  '      ._EX2 = 0
  '      ._EX3 = 0
  '      ._EX4 = 0
  '      ._EX5 = 0
  '      ._EX6 = 0
  '      ._EX7 = 0
  '      ._EXCD1 = ""
  '      ._EXCD2 = ""
  '      ._EXCD3 = ""
  '      ._EXCD4 = ""
  '      ._EXCD5 = ""
  '      ._EXCD6 = ""
  '      ._EXCD7 = ""
  '      ._EXCHG = ds.Tables(0).Rows(I).Item("Adj_Exempt")
  '      If Trim(ds.Tables(0).Rows(I).Item("Gross_Inc_Dec")) = "DEC" Then
  '        ._GRCHG = ds.Tables(0).Rows(I).Item("Adj_Gross") * -1
  '      Else
  '        ._GRCHG = ds.Tables(0).Rows(I).Item("Adj_Gross")
  '      End If
  '      ._IMVIDNo = ds.Tables(0).Rows(I).Item("MV_Vehicle_ID")
  '      ._LISTNo = WrkListNo
  '      ._NAME = ConvertString("NAME", ds.Tables(0).Rows(I).Item("TaxPayer"), 35)
  '      ._NEWMVC = 0
  '      ._PRF = ds.Tables(0).Rows(I).Item("User_ID")
  '      ._RSNCD = ""
  '      ._SUSCD = ""
  '      ._TYPE = WrkType
  '      ._YEAR = WrkYear
  '      .AddOneRecordP()
  '      WrkPct = (Counter / 10) Mod 100
  '      If SavePct <> WrkPct Then
  '        ProgBar1.Value = WrkPct
  '        LblMsg.Text = "Records processed: " & Counter
  '        SavePct = WrkPct
  '        Application.DoEvents()
  '      End If
  '      If .ErrMsg <> String.Empty Then
  '        sw.WriteLine("COEA " & .ErrMsg)
  '      End If
  '    End With
  '    WrkCCTax1 = 0
  '    WrkCCTax2 = 0
  '    WrkCCTax3 = 0
  '    WrkCCTax4 = 0
  '    ds2 = myDBConnect.RunQuery("INSTFILE", "where yr=" & WrkYear & " and bill_type=" &
  '     ds.Tables(0).Rows(I).Item("bill_type") & " and bill_num=" & WrkListNo)
  '    If ds2.Tables(0).Rows.Count > 0 Then
  '      WrkCCTax1 = CnvSng(ds2.Tables(0).Rows(0).Item("City_Tax1")) + CnvSng(ds2.Tables(0).Rows(0).Item("City_Adj1"))
  '      WrkCCTax2 = CnvSng(ds2.Tables(0).Rows(0).Item("City_Tax2")) + CnvSng(ds2.Tables(0).Rows(0).Item("City_Adj2"))
  '      WrkCCTax3 = CnvSng(ds2.Tables(0).Rows(0).Item("City_Tax3")) + CnvSng(ds2.Tables(0).Rows(0).Item("City_Adj3"))
  '      WrkCCTax4 = CnvSng(ds2.Tables(0).Rows(0).Item("City_Tax4")) + CnvSng(ds2.Tables(0).Rows(0).Item("City_Adj4"))
  '    End If
  '    With MyTXINV
  '      .GetOneRecordP(WrkListNo, WrkYear, WrkType)
  '      If Not .RecordNotFound Then
  '        ._CCNO = WrkCCNo
  '        ._CDATE = WrkCCDate
  '        ._CCETAX = CnvSng(ds.Tables(0).Rows(I).Item("Tax_Due_New"))
  '        ._CCEXP = CnvSng(ds.Tables(0).Rows(I).Item("Total_Exempt_New"))
  '        ._CCRSN = ""
  '        ._CCTX1 = WrkCCTax1
  '        ._CCTX2 = WrkCCTax2
  '        ._CCTX3 = WrkCCTax3
  '        ._CCTX4 = WrkCCTax4
  '        ._CEODC = ""
  '        ._CEXA1 = 0
  '        ._CEXA2 = 0
  '        ._CEXA3 = 0
  '        ._CEXA4 = 0
  '        ._CEXA5 = 0
  '        ._CEXA6 = 0
  '        ._CEXA7 = 0
  '        ._CGRS = ds.Tables(0).Rows(I).Item("Adj_Gross")
  '        ._BALD = ._CCETAX - ._PAYREC
  '        .UpdateOneRecordP()
  '      Else
  '        sw.WriteLine(WrkFile & "," & WrkListNo & ",No INV:," & WrkListNo & " " & WrkYear & " " & WrkType)
  '      End If
  '    End With
  '  Next
  '  ds = Nothing
  'End Sub
  Private Sub WriteREA(ByVal WrkFileName As String)
    Dim ds As DataSet = New DataSet
    Const cMaxExam As Long = 9999999
    Dim WrkTxyr As Integer
    Dim I As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    MyTXREAA = New TXREAA(myDBConnectGEMS.MyConn2, WrkFileName)
    myDBConnectGEMS.DeleteRecords2(WrkFileName, "where txyear>=" & cArchiveOldYear & " and txyear<=" & cArchiveNewYear)
    ds = myDBConnect.RunQuery("ASSRREAL", "where record_year>=" & cArchiveOldYear & " and record_year<=" & cArchiveNewYear)
    WrkFile = WrkFileName
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTXREAA
        Counter = Counter + 1
        WrkListNo = ds.Tables(0).Rows(I).Item("list_no")
        WrkTxyr = ds.Tables(0).Rows(I).Item("record_year")
        .GetOneRecordP(WrkListNo, WrkTxyr)
        ._AACRE = 0
        ._ACCTN = ""
        ._ACRE1 = ds.Tables(0).Rows(I).Item("acreage")
        ._ACRE2 = 0
        ._ACRE3 = 0
        ._ACRE4 = 0
        ._ACRE5 = 0
        ._ACRE6 = 0
        ._ACRE7 = 0
        ._ADD1 = ConvertString("Add1", ds.Tables(0).Rows(I).Item("Street"), 35)
        ._ADD2 = ConvertString("Add2", ds.Tables(0).Rows(I).Item("Country_Mailing_Addr"), 35)
        ._AEDATE = 0
        ._AIDTE = 0
        ._ASS1 = ds.Tables(0).Rows(I).Item("amount_org1")
        ._ASS2 = ds.Tables(0).Rows(I).Item("amount_org2")
        ._ASS3 = ds.Tables(0).Rows(I).Item("amount_org3")
        ._ASS4 = ds.Tables(0).Rows(I).Item("amount_org4")
        ._ASS5 = ds.Tables(0).Rows(I).Item("amount_org5")
        ._ASS6 = ds.Tables(0).Rows(I).Item("amount_org6")
        ._ASS7 = ds.Tables(0).Rows(I).Item("amount_org7")
        Select Case Len(ds.Tables(0).Rows(I).Item("bank_no"))
          Case > 2
            ._BKCD = ""
          Case Else
            ._BKCD = ds.Tables(0).Rows(I).Item("bank_no")
        End Select
        ._BKSV = ""
        ._BTC = ""
        ._BTR = 0
        ._CARD = "N"
        ._CASS1 = 0
        ._CASS2 = 0
        ._CASS3 = 0
        ._CASS4 = 0
        ._CASS5 = 0
        ._CASS6 = 0
        ._CASS7 = 0
        If Len(Trim(ds.Tables(0).Rows(I).Item("code_exempt1"))) = 4 Then
          ._CAT = "3"
          ._EXMPT = ds.Tables(0).Rows(I).Item("code_exempt1")
        Else
          ._CAT = "1"
          ._EXMPT = ""
        End If
        ._CCCD1 = ""
        ._CCCD2 = ""
        ._CCCD3 = ""
        ._CCCD4 = ""
        ._CCCD5 = ""
        ._CCCD6 = ""
        ._CCCD7 = ""
        ._CCEX = 0
        ._CCGRS = 0
        ._CCNO = CnvSng(ds.Tables(0).Rows(I).Item("boa_coc_no"))
        ._CCRS = ""
        ._CDATE = 0
        ._CENBK = 0
        ._CENTR = 0
        ._CEXA1 = 0
        ._CEXA2 = 0
        ._CEXA3 = 0
        ._CEXA4 = 0
        ._CEXA5 = 0
        ._CEXA6 = 0
        ._CEXA7 = 0
        ._CHDATE = 0
        ._CHTIME = 0
        ._CIRAD = 0
        ._CITY = ConvertString("City", ds.Tables(0).Rows(I).Item("city"), 25)
        ._CMAX = 0
        ._CMIN = 0
        ._CODE1 = ds.Tables(0).Rows(I).Item("code_old_org1")
        ._CODE2 = ds.Tables(0).Rows(I).Item("code_old_org2")
        ._CODE3 = ds.Tables(0).Rows(I).Item("code_old_org3")
        ._CODE4 = ds.Tables(0).Rows(I).Item("code_old_org4")
        ._CODE5 = ds.Tables(0).Rows(I).Item("code_old_org5")
        ._CODE6 = ds.Tables(0).Rows(I).Item("code_old_org6")
        ._CODE7 = ds.Tables(0).Rows(I).Item("code_old_org7")
        ._CPERC = 0
        ._DIST = 0
        ._DNBTR = ""
        ._DTBTR = 0
        If Len(Trim(ds.Tables(0).Rows(I).Item("code_exempt1"))) = 3 Then
          If ds.Tables(0).Rows(I).Item("amnt_exmpt_org1") <= cMaxExam Then
            ._EXAM1 = ds.Tables(0).Rows(I).Item("amnt_exmpt_org1")
          Else
            ._EXAM1 = cMaxExam
            sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam1:," & ds.Tables(0).Rows(I).Item("amnt_exmpt_org1"))
          End If
          If ds.Tables(0).Rows(I).Item("amnt_exmpt_org2") <= cMaxExam Then
            ._EXAM2 = ds.Tables(0).Rows(I).Item("amnt_exmpt_org2")
          Else
            ._EXAM2 = cMaxExam
            sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam2:," & ds.Tables(0).Rows(I).Item("amnt_exmpt_org2"))
          End If
          If ds.Tables(0).Rows(I).Item("amnt_exmpt_org3") <= cMaxExam Then
            ._EXAM3 = ds.Tables(0).Rows(I).Item("amnt_exmpt_org3")
          Else
            ._EXAM3 = cMaxExam
            sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam3:," & ds.Tables(0).Rows(I).Item("amnt_exmpt_org3"))
          End If
          If ds.Tables(0).Rows(I).Item("amnt_exmpt_org4") <= cMaxExam Then
            ._EXAM4 = ds.Tables(0).Rows(I).Item("amnt_exmpt_org4")
          Else
            ._EXAM4 = cMaxExam
            sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam1:," & ds.Tables(0).Rows(I).Item("amnt_exmpt_org1"))
          End If
          If ds.Tables(0).Rows(I).Item("amnt_exmpt_org5") <= cMaxExam Then
            ._EXAM5 = ds.Tables(0).Rows(I).Item("amnt_exmpt_org5")
          Else
            ._EXAM5 = cMaxExam
            sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam5:," & ds.Tables(0).Rows(I).Item("amnt_exmpt_org5"))
          End If
          If ds.Tables(0).Rows(I).Item("amnt_exmpt_org6") <= cMaxExam Then
            ._EXAM6 = ds.Tables(0).Rows(I).Item("amnt_exmpt_org6")
          Else
            ._EXAM6 = cMaxExam
            sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam6:," & ds.Tables(0).Rows(I).Item("amnt_exmpt_org6"))
          End If
          If ds.Tables(0).Rows(I).Item("amnt_exmpt_org7") <= cMaxExam Then
            ._EXAM7 = ds.Tables(0).Rows(I).Item("amnt_exmpt_org7")
          Else
            ._EXAM7 = cMaxExam
            sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam7:," & ds.Tables(0).Rows(I).Item("amnt_exmpt_org7"))
          End If
          ._EXCD1 = ds.Tables(0).Rows(I).Item("code_exempt1")
          ._EXCD2 = ds.Tables(0).Rows(I).Item("code_exempt2")
          ._EXCD3 = ds.Tables(0).Rows(I).Item("code_exempt3")
          ._EXCD4 = ds.Tables(0).Rows(I).Item("code_exempt4")
          ._EXCD5 = ds.Tables(0).Rows(I).Item("code_exempt5")
          ._EXCD6 = ds.Tables(0).Rows(I).Item("code_exempt6")
          ._EXCD7 = ds.Tables(0).Rows(I).Item("code_exempt7")
        Else
          ._EXAM1 = 0
          ._EXAM2 = 0
          ._EXAM3 = 0
          ._EXAM4 = 0
          ._EXAM5 = 0
          ._EXAM6 = 0
          ._EXAM7 = 0
          ._EXCD1 = ""
          ._EXCD2 = ""
          ._EXCD3 = ""
          ._EXCD4 = ""
          ._EXCD5 = ""
          ._EXCD6 = ""
          ._EXCD7 = ""
        End If
        ._FASS = 0
        ._FCCOD = ""
        ._FCYR = 0
        ._FTAX = 0
        ._GROSS = ds.Tables(0).Rows(I).Item("new_gross_org")
        ._LETT = Mid(ds.Tables(0).Rows(I).Item("taxpayer"), 1, 1)
        ._LISTNo = WrkListNo
        ._LOC = ConvertString("Loc", ds.Tables(0).Rows(I).Item("prop_loc_st_name"), 25)
        ._LOCNo = JustifyRight(ds.Tables(0).Rows(I).Item("Prop_loc_st_no"), 7)
        ._MAP = ConvertString("Map", ds.Tables(0).Rows(I).Item("map_block_lot"), 17)
        ._NAME = ConvertString("Name", ds.Tables(0).Rows(I).Item("taxpayer"), 35)
        ._SNAME = ConvertString("Sname", ds.Tables(0).Rows(I).Item("in_care_of"), 35)
        If Len(Trim(ds.Tables(0).Rows(I).Item("code_exempt1"))) = 4 Then
          ._NET = ._GROSS
        Else
          If ds.Tables(0).Rows(I).Item("total_exempt_org") > 0 Then
            ._NET = ._GROSS - ds.Tables(0).Rows(I).Item("total_exempt_org")
          Else
            ._NET = ds.Tables(0).Rows(I).Item("net_org")
          End If
        End If
        ._OID = ""
        ._PDST = 0
        ._PERC = 0
        ._PGE = ConvertString("Pge", ds.Tables(0).Rows(I).Item("page"), 5)
        ._PRF = Trim(Mid(ds.Tables(0).Rows(I).Item("change_user"), 1, 10))
        ._PURDT = ConvertDate(ds.Tables(0).Rows(I).Item("sale_date"))
        ._PURPR = ds.Tables(0).Rows(I).Item("sale_price")
        ._RLST = 0
        ._SEWER = "Y"
        ._SMAP = ""
        ._SS2 = 0
        ._SSNo = 0
        ._STATE = ConvertString("State", ds.Tables(0).Rows(I).Item("state"), 2)
        ._TIN = ""
        ._TWNBN = CnvSng(ds.Tables(0).Rows(I).Item("tbenefits1"))
        ._TXYEAR = WrkTxyr
        ._TYPE = "R"
        ._UNIT1 = 0
        ._UNIT2 = 0
        ._UNIT3 = 0
        ._UNIT4 = 0
        ._UNIT5 = 0
        ._UNIT6 = 0
        ._UNIT7 = 0
        ._UNITNo = ""
        ._VOL = ConvertString("Vol", ds.Tables(0).Rows(I).Item("volume"), 5)
        ._VTYR = 0
        ._WMAIL = ""
        ._ZIP4 = CnvSng(ds.Tables(0).Rows(I).Item("zip2"))
        ._ZIP5 = CnvSng(ds.Tables(0).Rows(I).Item("zip1"))
        .AddOneRecordP()
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next
    ds = Nothing
  End Sub
  Private Sub WritePP(ByVal WrkFileName As String, WrkYear As Integer)
    Dim ds As DataSet = New DataSet
    Dim Code(9) As Integer
    Dim Amount(9) As Long
    Dim Excd(4) As String
    Dim Exam(4) As Long
    Const cMaxExam As Long = 9999999
    Dim I As Integer
    Dim J As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal

    MyTXPPRP = New TXPPRP(myDBConnectGEMS.MyConn2, WrkFileName)
    myDBConnectGEMS.DeleteRecords2(WrkFileName)
    ds = myDBConnect.RunQuery("ASSRPERS", "where record_year=" & WrkYear & " order by list_no")
    WrkFile = WrkFileName
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTXPPRP
        Counter = Counter + 1
        J = -1
        Array.Clear(Amount, 0, 9)
        Array.Clear(Code, 0, 9)
        WrkListNo = ds.Tables(0).Rows(I).Item("list_no")
        If WrkYear = MyGLYear Then
          If ds.Tables(0).Rows(I).Item("amount1") > 0 Then
            J = J + 1
            Amount(J) = ds.Tables(0).Rows(I).Item("amount1")
            Code(J) = ds.Tables(0).Rows(I).Item("code1")
          End If
          If ds.Tables(0).Rows(I).Item("amount2") > 0 Then
            J = J + 1
            Amount(J) = ds.Tables(0).Rows(I).Item("amount2")
            Code(J) = ds.Tables(0).Rows(I).Item("code2")
          End If
          If ds.Tables(0).Rows(I).Item("amount3") > 0 Then
            J = J + 1
            Amount(J) = ds.Tables(0).Rows(I).Item("amount3")
            Code(J) = ds.Tables(0).Rows(I).Item("code3")
          End If
          If ds.Tables(0).Rows(I).Item("amount4") > 0 Then
            J = J + 1
            Amount(J) = ds.Tables(0).Rows(I).Item("amount4")
            Code(J) = ds.Tables(0).Rows(I).Item("code4")
          End If
          If ds.Tables(0).Rows(I).Item("amount5") > 0 Then
            J = J + 1
            Amount(J) = ds.Tables(0).Rows(I).Item("amount5")
            Code(J) = ds.Tables(0).Rows(I).Item("code5")
          End If
          If ds.Tables(0).Rows(I).Item("amount6") > 0 Then
            J = J + 1
            Amount(J) = ds.Tables(0).Rows(I).Item("amount6")
            Code(J) = ds.Tables(0).Rows(I).Item("code6")
          End If
          If ds.Tables(0).Rows(I).Item("amount7") > 0 Then
            J = J + 1
            Amount(J) = ds.Tables(0).Rows(I).Item("amount7")
            Code(J) = ds.Tables(0).Rows(I).Item("code7")
          End If
          If ds.Tables(0).Rows(I).Item("amount8") > 0 Then
            J = J + 1
            Amount(J) = ds.Tables(0).Rows(I).Item("amount8")
            Code(J) = ds.Tables(0).Rows(I).Item("code8")
          End If
        Else
          If ds.Tables(0).Rows(I).Item("amount_org1") > 0 Then
            J = J + 1
            Amount(J) = ds.Tables(0).Rows(I).Item("amount_org1")
            Code(J) = ds.Tables(0).Rows(I).Item("code_org1")
          End If
          If ds.Tables(0).Rows(I).Item("amount_org2") > 0 Then
            J = J + 1
            Amount(J) = ds.Tables(0).Rows(I).Item("amount_org2")
            Code(J) = ds.Tables(0).Rows(I).Item("code_org2")
          End If
          If ds.Tables(0).Rows(I).Item("amount_org3") > 0 Then
            J = J + 1
            Amount(J) = ds.Tables(0).Rows(I).Item("amount_org3")
            Code(J) = ds.Tables(0).Rows(I).Item("code_org3")
          End If
          If ds.Tables(0).Rows(I).Item("amount_org4") > 0 Then
            J = J + 1
            Amount(J) = ds.Tables(0).Rows(I).Item("amount_org4")
            Code(J) = ds.Tables(0).Rows(I).Item("code_org4")
          End If
          If ds.Tables(0).Rows(I).Item("amount_org5") > 0 Then
            J = J + 1
            Amount(J) = ds.Tables(0).Rows(I).Item("amount_org5")
            Code(J) = ds.Tables(0).Rows(I).Item("code_org5")
          End If
          If ds.Tables(0).Rows(I).Item("amount_org6") > 0 Then
            J = J + 1
            Amount(J) = ds.Tables(0).Rows(I).Item("amount_org6")
            Code(J) = ds.Tables(0).Rows(I).Item("code_org6")
          End If
          If ds.Tables(0).Rows(I).Item("amount_org7") > 0 Then
            J = J + 1
            Amount(J) = ds.Tables(0).Rows(I).Item("amount_org7")
            Code(J) = ds.Tables(0).Rows(I).Item("code_org7")
          End If
          If ds.Tables(0).Rows(I).Item("amount_org8") > 0 Then
            J = J + 1
            Amount(J) = ds.Tables(0).Rows(I).Item("amount_org8")
            Code(J) = ds.Tables(0).Rows(I).Item("code_org8")
          End If
        End If
        J = -1
        Array.Clear(Exam, 0, 4)
        Array.Clear(Excd, 0, 4)
        Excd(0) = Trim(ds.Tables(0).Rows(I).Item("code_exempt1"))
        Excd(1) = Trim(ds.Tables(0).Rows(I).Item("code_exempt2"))
        Excd(2) = Trim(ds.Tables(0).Rows(I).Item("code_exempt3"))
        Excd(3) = Trim(ds.Tables(0).Rows(I).Item("code_exempt4"))
        Excd(4) = Trim(ds.Tables(0).Rows(I).Item("code_exempt5"))
        If WrkYear = MyGLYear Then
          Exam(0) = ds.Tables(0).Rows(I).Item("amount_exempt1")
          Exam(1) = ds.Tables(0).Rows(I).Item("amount_exempt2")
          Exam(2) = ds.Tables(0).Rows(I).Item("amount_exempt3")
          Exam(3) = ds.Tables(0).Rows(I).Item("amount_exempt4")
          Exam(4) = ds.Tables(0).Rows(I).Item("amount_exempt5")
        Else
          Exam(0) = ds.Tables(0).Rows(I).Item("amnt_exmpt_org1")
          Exam(1) = ds.Tables(0).Rows(I).Item("amnt_exmpt_org2")
          Exam(2) = ds.Tables(0).Rows(I).Item("amnt_exmpt_org3")
          Exam(3) = ds.Tables(0).Rows(I).Item("amnt_exmpt_org4")
          Exam(4) = ds.Tables(0).Rows(I).Item("amnt_exmpt_org5")
        End If
        .GetOneRecordP(WrkListNo)
        ._ADD1 = ConvertString("Add1", ds.Tables(0).Rows(I).Item("Street"), 35)
        ._ADD2 = ConvertString("Add2", ds.Tables(0).Rows(I).Item("Street2"), 35)
        ._ADYR = 0
        ._ASS1 = Amount(0)
        ._ASS2 = Amount(1)
        ._ASS3 = Amount(2)
        ._ASS4 = Amount(3)
        ._ASS5 = Amount(4)
        ._ASS6 = Amount(5)
        ._ASS7 = Amount(6)
        ._ASS8 = Amount(7)
        ._ASS9 = 0
        ._ASS10 = 0
        ._BTC = ""
        ._BTR = 0
        ._BUS = ""
        ._BUSTY = ConvertString("busty", ds.Tables(0).Rows(I).Item("bus_type"), 4)
        ._CASS1 = 0
        ._CASS2 = 0
        ._CASS3 = 0
        ._CASS4 = 0
        ._CASS5 = 0
        ._CASS6 = 0
        ._CASS7 = 0
        ._CASS8 = 0
        ._CASS9 = 0
        ._CASSA = 0
        ._CAT = "5"
        ._CCCD1 = ""
        ._CCCD2 = ""
        ._CCCD3 = ""
        ._CCCD4 = ""
        ._CCCD5 = ""
        ._CCEX = 0
        ._CCGRS = 0
        ._CCNO = 0
        ._CCRS = ""
        ._CDATE = 0
        ._CEXA1 = 0
        ._CEXA2 = 0
        ._CEXA3 = 0
        ._CEXA4 = 0
        ._CEXA5 = 0
        ._CHDATE = 0
        ._CHTIME = 0
        ._CITY = ConvertString("City", ds.Tables(0).Rows(I).Item("city"), 25)
        ._CODE1 = Code(0)
        ._CODE2 = Code(1)
        ._CODE3 = Code(2)
        ._CODE4 = Code(3)
        ._CODE5 = Code(4)
        ._CODE6 = Code(5)
        ._CODE7 = Code(6)
        ._CODE8 = Code(7)
        ._CODE9 = 0
        ._CODEA = 0
        ._DIST = 0
        ._DNBTR = ""
        ._DTBTR = 0
        ._EXAM1 = 0
        ._EXAM2 = 0
        ._EXAM3 = 0
        ._EXAM4 = 0
        ._EXAM5 = 0
        ._EXCD1 = ""
        ._EXCD2 = ""
        ._EXCD3 = ""
        ._EXCD4 = ""
        ._EXCD5 = ""
        If Exam(0) <= cMaxExam Then
          ._EXAM1 = Exam(0)
        Else
          ._EXAM1 = cMaxExam
          sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam1:," & Exam(0))
        End If
        If Exam(1) <= cMaxExam Then
          ._EXAM2 = Exam(1)
        Else
          ._EXAM2 = cMaxExam
          sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam2:," & Exam(1))
        End If
        If Exam(2) <= cMaxExam Then
          ._EXAM3 = Exam(2)
        Else
          ._EXAM3 = cMaxExam
          sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam3:," & Exam(2))
        End If
        If Exam(3) <= cMaxExam Then
          ._EXAM4 = Exam(3)
        Else
          ._EXAM4 = cMaxExam
          sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam4:," & Exam(3))
        End If
        If Exam(4) <= cMaxExam Then
          ._EXAM5 = Exam(4)
        Else
          ._EXAM5 = cMaxExam
          sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam5:," & Exam(4))
        End If
        If ._EXAM1 > 0 Then
          ._EXCD1 = Excd(0)
        End If
        If ._EXAM2 > 0 Then
          ._EXCD2 = Excd(1)
        End If
        If ._EXAM3 > 0 Then
          ._EXCD3 = Excd(2)
        End If
        If ._EXAM4 > 0 Then
          ._EXCD4 = Excd(3)
        End If
        If ._EXAM5 > 0 Then
          ._EXCD5 = Excd(4)
        End If
        If WrkYear = MyGLYear Then
          ._GROSS = ds.Tables(0).Rows(I).Item("new_gross")
        Else
          ._GROSS = ds.Tables(0).Rows(I).Item("new_gross_org")
        End If
        ._LETT = Mid(ds.Tables(0).Rows(I).Item("taxpayer"), 1, 1)
        ._LISTNO = WrkListNo
        ._LOCNO = JustifyRight(ds.Tables(0).Rows(I).Item("Prop_loc_st_no"), 7)
        ._LOC = ConvertString("Loc", ds.Tables(0).Rows(I).Item("prop_loc_st_name"), 25)
        ._NAME = ConvertString("Name", ds.Tables(0).Rows(I).Item("taxpayer"), 35)
        ._SNAME = ConvertString("Sname", ds.Tables(0).Rows(I).Item("in_care_of"), 35)
        If Len(Trim(ds.Tables(0).Rows(I).Item("code_exempt1"))) = 4 Then
          ._NET = ._GROSS
        Else
          If WrkYear = MyGLYear Then
            If ds.Tables(0).Rows(I).Item("total_exempt") > 0 Then
              ._NET = ._GROSS - ds.Tables(0).Rows(I).Item("total_exempt")
            Else
              ._NET = ds.Tables(0).Rows(I).Item("net")
            End If
          Else
            If ds.Tables(0).Rows(I).Item("total_exempt_org") > 0 Then
              ._NET = ._GROSS - ds.Tables(0).Rows(I).Item("total_exempt_org")
            Else
              ._NET = ds.Tables(0).Rows(I).Item("net_org")
            End If
          End If
        End If
        ._OID = ""
        ._PDST = 0
        ._PRF = Trim(Mid(ds.Tables(0).Rows(I).Item("change_user"), 1, 10))
        ._RDATE = 0
        ._SQFT = ds.Tables(0).Rows(I).Item("bus_sq_foot")
        ._SS2 = 0
        ._SSNO = 0
        ._STATE = ds.Tables(0).Rows(I).Item("state")
        ._TIN = ""
        ._TYPE = "P"
        ._UNIT1 = 0
        ._UNIT2 = 0
        ._UNIT3 = 0
        ._UNIT4 = 0
        ._UNIT5 = 0
        ._UNIT6 = 0
        ._UNIT7 = 0
        ._UNIT8 = 0
        ._UNIT9 = 0
        ._UNITA = 0
        ._ZIP4 = CnvSng(ds.Tables(0).Rows(I).Item("zip2"))
        ._ZIP5 = CnvSng(ds.Tables(0).Rows(I).Item("zip1"))
        .AddOneRecordP()
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next
    ds = Nothing
  End Sub
  Private Sub WritePPA(ByVal WrkFileName As String)
    Dim ds As DataSet = New DataSet
    Dim WrkTxyr As Integer
    Dim Code(9) As Integer
    Dim Amount(9) As Long
    Const cMaxExam As Long = 9999999
    Dim I As Integer
    Dim J As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal

    MyTXPPRA = New TXPPRA(myDBConnectGEMS.MyConn2, WrkFileName)
    myDBConnectGEMS.DeleteRecords2(WrkFileName, "where txyear>=" & cArchiveOldYear & " and txyear<=" & cArchiveNewYear)
    ds = myDBConnect.RunQuery("ASSRPERS", "where record_year>=" & cArchiveOldYear & " and record_year<=" & cArchiveNewYear)
    WrkFile = WrkFileName
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTXPPRA
        Counter = Counter + 1
        J = -1
        Array.Clear(Amount, 0, 9)
        Array.Clear(Code, 0, 9)
        WrkListNo = ds.Tables(0).Rows(I).Item("list_no")
        WrkTxyr = ds.Tables(0).Rows(I).Item("record_year")
        If ds.Tables(0).Rows(I).Item("amount_org1") > 0 Then
          J = J + 1
          Amount(J) = ds.Tables(0).Rows(I).Item("amount_org1")
          Code(J) = ds.Tables(0).Rows(I).Item("code_org1")
        End If
        If ds.Tables(0).Rows(I).Item("amount_org2") > 0 Then
          J = J + 1
          Amount(J) = ds.Tables(0).Rows(I).Item("amount_org2")
          Code(J) = ds.Tables(0).Rows(I).Item("code_org2")
        End If
        If ds.Tables(0).Rows(I).Item("amount_org3") > 0 Then
          J = J + 1
          Amount(J) = ds.Tables(0).Rows(I).Item("amount_org3")
          Code(J) = ds.Tables(0).Rows(I).Item("code_org3")
        End If
        If ds.Tables(0).Rows(I).Item("amount_org4") > 0 Then
          J = J + 1
          Amount(J) = ds.Tables(0).Rows(I).Item("amount_org4")
          Code(J) = ds.Tables(0).Rows(I).Item("code_org4")
        End If
        If ds.Tables(0).Rows(I).Item("amount_org5") > 0 Then
          J = J + 1
          Amount(J) = ds.Tables(0).Rows(I).Item("amount_org5")
          Code(J) = ds.Tables(0).Rows(I).Item("code_org5")
        End If
        If ds.Tables(0).Rows(I).Item("amount_org6") > 0 Then
          J = J + 1
          Amount(J) = ds.Tables(0).Rows(I).Item("amount_org6")
          Code(J) = ds.Tables(0).Rows(I).Item("code_org6")
        End If
        If ds.Tables(0).Rows(I).Item("amount_org7") > 0 Then
          J = J + 1
          Amount(J) = ds.Tables(0).Rows(I).Item("amount_org7")
          Code(J) = ds.Tables(0).Rows(I).Item("code_org7")
        End If
        If ds.Tables(0).Rows(I).Item("amount_org8") > 0 Then
          J = J + 1
          Amount(J) = ds.Tables(0).Rows(I).Item("amount_org8")
          Code(J) = ds.Tables(0).Rows(I).Item("code_org8")
        End If
        .GetOneRecordP(WrkListNo, WrkTxyr)
        ._ADD1 = ConvertString("Add1", ds.Tables(0).Rows(I).Item("Street"), 35)
        ._ADD2 = ConvertString("Add2", ds.Tables(0).Rows(I).Item("Street2"), 35)
        ._ADYR = 0
        ._ASS1 = Amount(0)
        ._ASS2 = Amount(1)
        ._ASS3 = Amount(2)
        ._ASS4 = Amount(3)
        ._ASS5 = Amount(4)
        ._ASS6 = Amount(5)
        ._ASS7 = Amount(6)
        ._ASS8 = Amount(7)
        ._ASS9 = 0
        ._ASS10 = 0
        ._BTC = ""
        ._BTR = 0
        ._BUS = ""
        ._BUSTY = "" 'ds.Tables(0).Rows(I).Item("bus_type")
        ._CASS1 = 0
        ._CASS2 = 0
        ._CASS3 = 0
        ._CASS4 = 0
        ._CASS5 = 0
        ._CASS6 = 0
        ._CASS7 = 0
        ._CASS8 = 0
        ._CASS9 = 0
        ._CASSA = 0
        ._CAT = "5"
        ._CCCD1 = ""
        ._CCCD2 = ""
        ._CCCD3 = ""
        ._CCCD4 = ""
        ._CCCD5 = ""
        ._CCEX = 0
        ._CCGRS = 0
        ._CCNO = CnvSng(ds.Tables(0).Rows(I).Item("boa_coc_no"))
        ._CCRS = ""
        ._CDATE = 0
        ._CEXA1 = 0
        ._CEXA2 = 0
        ._CEXA3 = 0
        ._CEXA4 = 0
        ._CEXA5 = 0
        ._CHDATE = 0
        ._CHTIME = 0
        ._CITY = ConvertString("City", ds.Tables(0).Rows(I).Item("city"), 25)
        ._CODE1 = Code(0)
        ._CODE2 = Code(1)
        ._CODE3 = Code(2)
        ._CODE4 = Code(3)
        ._CODE5 = Code(4)
        ._CODE6 = Code(5)
        ._CODE7 = Code(6)
        ._CODE8 = Code(7)
        ._CODE9 = 0
        ._CODEA = 0
        ._DIST = 0
        ._DNBTR = ""
        ._DTBTR = 0
        ._EXAM1 = 0
        ._EXAM2 = 0
        ._EXAM3 = 0
        ._EXAM4 = 0
        ._EXAM5 = 0
        If ds.Tables(0).Rows(I).Item("amnt_exmpt_org1") <= cMaxExam Then
          ._EXAM1 = ds.Tables(0).Rows(I).Item("amnt_exmpt_org1")
        Else
          ._EXAM1 = cMaxExam
          sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam1:," & ds.Tables(0).Rows(I).Item("amnt_exmpt_org1"))
        End If
        If ds.Tables(0).Rows(I).Item("amnt_exmpt_org2") <= cMaxExam Then
          ._EXAM2 = ds.Tables(0).Rows(I).Item("amnt_exmpt_org2")
        Else
          ._EXAM2 = cMaxExam
          sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam2:," & ds.Tables(0).Rows(I).Item("amnt_exmpt_org2"))
        End If
        If ds.Tables(0).Rows(I).Item("amnt_exmpt_org3") <= cMaxExam Then
          ._EXAM3 = ds.Tables(0).Rows(I).Item("amnt_exmpt_org3")
        Else
          ._EXAM3 = cMaxExam
          sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam3:," & ds.Tables(0).Rows(I).Item("amnt_exmpt_org3"))
        End If
        If ds.Tables(0).Rows(I).Item("amnt_exmpt_org4") <= cMaxExam Then
          ._EXAM4 = ds.Tables(0).Rows(I).Item("amnt_exmpt_org4")
        Else
          ._EXAM4 = cMaxExam
          sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam1:," & ds.Tables(0).Rows(I).Item("amnt_exmpt_org1"))
        End If
        If ds.Tables(0).Rows(I).Item("amnt_exmpt_org5") <= cMaxExam Then
          ._EXAM5 = ds.Tables(0).Rows(I).Item("amnt_exmpt_org5")
        Else
          ._EXAM5 = cMaxExam
          sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam5:," & ds.Tables(0).Rows(I).Item("amnt_exmpt_org5"))
        End If
        ._EXCD1 = ""
        ._EXCD2 = ""
        ._EXCD3 = ""
        ._EXCD4 = ""
        ._EXCD5 = ""
        If ._EXAM1 > 0 Then
          ._EXCD1 = ds.Tables(0).Rows(I).Item("code_exempt1")
        End If
        If ._EXAM2 > 0 Then
          ._EXCD2 = ds.Tables(0).Rows(I).Item("code_exempt2")
        End If
        If ._EXAM3 > 0 Then
          ._EXCD3 = ds.Tables(0).Rows(I).Item("code_exempt3")
        End If
        If ._EXAM4 > 0 Then
          ._EXCD4 = ds.Tables(0).Rows(I).Item("code_exempt4")
        End If
        If ._EXAM5 > 0 Then
          ._EXCD5 = ds.Tables(0).Rows(I).Item("code_exempt5")
        End If
        ._GROSS = ds.Tables(0).Rows(I).Item("new_gross_org")
        ._LETT = Mid(ds.Tables(0).Rows(I).Item("taxpayer"), 1, 1)
        ._LISTNo = WrkListNo
        ._LOCNo = JustifyRight(ds.Tables(0).Rows(I).Item("Prop_loc_st_no"), 7)
        ._LOC = ConvertString("Loc", ds.Tables(0).Rows(I).Item("prop_loc_st_name"), 25)
        ._NAME = ConvertString("Name", ds.Tables(0).Rows(I).Item("taxpayer"), 35)
        ._SNAME = ConvertString("Sname", ds.Tables(0).Rows(I).Item("in_care_of"), 35)
        If Len(Trim(ds.Tables(0).Rows(I).Item("code_exempt1"))) = 4 Then
          ._NET = ._GROSS
        Else
          If ds.Tables(0).Rows(I).Item("total_exempt_org") > 0 Then
            ._NET = ._GROSS - ds.Tables(0).Rows(I).Item("total_exempt_org")
          Else
            ._NET = ds.Tables(0).Rows(I).Item("net_org")
          End If
        End If
        ._OID = ""
        ._PDST = 0
        ._PRF = Trim(Mid(ds.Tables(0).Rows(I).Item("change_user"), 1, 10))
        ._RDATE = 0
        ._SQFT = ds.Tables(0).Rows(I).Item("bus_sq_foot")
        ._SS2 = 0
        ._SSNo = 0
        ._STATE = ds.Tables(0).Rows(I).Item("state")
        ._TIN = ""
        ._TXYEAR = WrkTxyr
        ._TYPE = "P"
        ._UNIT1 = 0
        ._UNIT2 = 0
        ._UNIT3 = 0
        ._UNIT4 = 0
        ._UNIT5 = 0
        ._UNIT6 = 0
        ._UNIT7 = 0
        ._UNIT8 = 0
        ._UNIT9 = 0
        ._UNITA = 0
        ._ZIP4 = CnvSng(ds.Tables(0).Rows(I).Item("zip2"))
        ._ZIP5 = CnvSng(ds.Tables(0).Rows(I).Item("zip1"))
        .AddOneRecordP()
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next
    ds = Nothing
  End Sub
  Private Sub WriteMV(ByVal WrkFileName As String, WrkYear As Integer)
    Dim ds As DataSet = New DataSet
    Dim Excd(4) As String
    Dim Exam(4) As Long
    Dim I As Integer
    Dim J As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal

    MyTXMVD = New TXMVD(myDBConnectGEMS.MyConn2, WrkFileName)
    myDBConnectGEMS.DeleteRecords2(WrkFileName)
    ds = myDBConnect.RunQuery("ASSRMV", "where record_year=" & WrkYear & " order by list_no")
    WrkFile = WrkFileName
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTXMVD
        Counter = Counter + 1
        WrkListNo = ds.Tables(0).Rows(I).Item("list_no")
        J = -1
        Array.Clear(Exam, 0, 4)
        Array.Clear(Excd, 0, 4)
        Excd(0) = Trim(ds.Tables(0).Rows(I).Item("code_exempt1"))
        Excd(1) = Trim(ds.Tables(0).Rows(I).Item("code_exempt2"))
        Excd(2) = Trim(ds.Tables(0).Rows(I).Item("code_exempt3"))
        Excd(3) = Trim(ds.Tables(0).Rows(I).Item("code_exempt4"))
        Excd(4) = Trim(ds.Tables(0).Rows(I).Item("code_exempt5"))
        If WrkYear = MyGLYear Then
          Exam(0) = ds.Tables(0).Rows(I).Item("amount_exempt1")
          Exam(1) = ds.Tables(0).Rows(I).Item("amount_exempt2")
          Exam(2) = ds.Tables(0).Rows(I).Item("amount_exempt3")
          Exam(3) = ds.Tables(0).Rows(I).Item("amount_exempt4")
          Exam(4) = ds.Tables(0).Rows(I).Item("amount_exempt5")
        Else
          Exam(0) = ds.Tables(0).Rows(I).Item("amnt_exmpt_org1")
          Exam(1) = ds.Tables(0).Rows(I).Item("amnt_exmpt_org2")
          Exam(2) = ds.Tables(0).Rows(I).Item("amnt_exmpt_org3")
          Exam(3) = ds.Tables(0).Rows(I).Item("amnt_exmpt_org4")
          Exam(4) = ds.Tables(0).Rows(I).Item("amnt_exmpt_org5")
        End If
        .GetOneRecordP(WrkListNo)
        ._ADD1 = ConvertString("Add1", ds.Tables(0).Rows(I).Item("Street"), 35)
        ._ADD2 = ConvertString("Add1", ds.Tables(0).Rows(I).Item("Street2"), 35)
        ._ASS = "Z" 'ds.Tables(0).Rows(I).Item("assr_code")
        ._BODY = ds.Tables(0).Rows(I).Item("vehicle_body_style")
        ._BTC = ""
        ._BTR = 0
        ._CAT = "1"
        ._CCCD1 = ""
        ._CCCD2 = ""
        ._CCCD3 = ""
        ._CCCD4 = ""
        ._CCCD5 = ""
        ._CCEX = 0
        ._CCGRS = 0
        ._CCNO = CnvSng(ds.Tables(0).Rows(I).Item("boa_coc_no"))
        ._CCRS = ""
        ._CDATE = 0
        ._CEXA1 = 0
        ._CEXA2 = 0
        ._CEXA3 = 0
        ._CEXA4 = 0
        ._CEXA5 = 0
        ._CHDATE = 0
        ._CHTIME = 0
        ._CLASS = ds.Tables(0).Rows(I).Item("vehicle_class")
        ._CYCLE = 0
        ._CYLAX = 0
        ._CITY = ConvertString("City", ds.Tables(0).Rows(I).Item("city"), 25)
        ._DIST = 0
        ._DNBTR = ""
        ._DOB = ConvertDate(ds.Tables(0).Rows(I).Item("dob"))
        ._DTBTR = 0
        ._EXAM1 = 0
        ._EXAM2 = 0
        ._EXAM3 = 0
        ._EXAM4 = 0
        ._EXAM5 = 0
        ._EXCD1 = ""
        ._EXCD2 = ""
        ._EXCD3 = ""
        ._EXCD4 = ""
        ._EXCD5 = ""
        ._EXAM1 = Exam(0)
        ._EXAM2 = Exam(1)
        ._EXAM3 = Exam(2)
        ._EXAM4 = Exam(3)
        ._EXAM5 = Exam(4)
        If ._EXAM1 > 0 Then
          ._EXCD1 = Excd(0)
        End If
        If ._EXAM2 > 0 Then
          ._EXCD2 = Excd(1)
        End If
        If ._EXAM3 > 0 Then
          ._EXCD3 = Excd(2)
        End If
        If ._EXAM4 > 0 Then
          ._EXCD4 = Excd(3)
        End If
        If ._EXAM5 > 0 Then
          ._EXCD5 = Excd(4)
        End If
        ._GWT = ds.Tables(0).Rows(I).Item("vehicle_gross_weight")
        ._LEASE = ""
        ._LETT = Mid(ds.Tables(0).Rows(I).Item("taxpayer"), 1, 1)
        ._LISTNO = WrkListNo
        ._LNVAL = ds.Tables(0).Rows(I).Item("loanvalue")
        ._LOC = ConvertString("Loc", ds.Tables(0).Rows(I).Item("location_name"), 25)
        ._LOCNO = JustifyRight(ds.Tables(0).Rows(I).Item("location_no"), 7)
        ._LWT = ds.Tables(0).Rows(I).Item("vehicle_light_weight")
        ._MAKE = ds.Tables(0).Rows(I).Item("vehicle_make")
        ._MODEL = ds.Tables(0).Rows(I).Item("vehicle_model")
        ._MSRP = ds.Tables(0).Rows(I).Item("msr")
        ._NADA = ""
        ._NAME = ConvertString("Name", ds.Tables(0).Rows(I).Item("taxpayer"), 35)
        ._SNAME = ConvertString("Sname", ds.Tables(0).Rows(I).Item("in_care_of"), 35)
        ._OASS = ""
        ._OCLS = 0
        ._OCODE = 0
        ._OID = ds.Tables(0).Rows(I).Item("dmv_vehicleid")
        ._OLIST = 0
        ._OMAKE = ""
        ._OMOD = ""
        ._OPVAL = 0
        ._OREGNO = ""
        ._ORIG = 0
        ._OVAL = 0
        ._OVIN = ""
        ._OYEAR = 0
        ._PCCOD = 0
        ._PCLR = ds.Tables(0).Rows(I).Item("vehicle_p_color")
        ._PDST = 0
        ._PNET = 0
        ._PREG = ""
        ._PRF = ds.Tables(0).Rows(I).Item("change_user")
        If Trim(ds.Tables(0).Rows(I).Item("street_mailing_addr")) <> "" Then
          ._RAD1 = ds.Tables(0).Rows(I).Item("street_mailing_addr")
          ._RAD2 = ds.Tables(0).Rows(I).Item("street_mailing_addr2")
          ._RCTY = ds.Tables(0).Rows(I).Item("city_mailing_addr")
          ._RST = ds.Tables(0).Rows(I).Item("state_mailing_addr")
          ._RZ4 = CnvSng(ds.Tables(0).Rows(I).Item("zip2_mailing_addr"))
          ._RZ5 = CnvSng(ds.Tables(0).Rows(I).Item("zip1_mailing_addr"))
        Else
          ._RAD1 = ConvertString("Add1", ds.Tables(0).Rows(I).Item("Street"), 35)
          ._RAD2 = ConvertString("Add1", ds.Tables(0).Rows(I).Item("Street2"), 35)
          ._RCTY = ConvertString("City", ds.Tables(0).Rows(I).Item("city"), 25)
          ._RST = ds.Tables(0).Rows(I).Item("state")
          ._RZ4 = CnvSng(ds.Tables(0).Rows(I).Item("zip2"))
          ._RZ5 = CnvSng(ds.Tables(0).Rows(I).Item("zip1"))
        End If
        ._RATE = 70
        ._RCODE = 0
        ._REGNO = ds.Tables(0).Rows(I).Item("vehicle_registration")
        ._SCAP = 0
        ._SCLR = ds.Tables(0).Rows(I).Item("vehicle_2nd_color")
        ._SEAT = 0
        ._SS2 = CnvSng(ds.Tables(0).Rows(I).Item("secondaryownercustomerid"))
        ._SSNO = CnvSng(ds.Tables(0).Rows(I).Item("primaryownercustomerid"))
        ._STATE = ds.Tables(0).Rows(I).Item("state")
        ._TDATE = 0
        ._TIN = ""
        ._TRVAL = ds.Tables(0).Rows(I).Item("tradein")
        ._TYPE = "M"
        ._VALUE = ds.Tables(0).Rows(I).Item("gl_value")
        ._VINNO = ds.Tables(0).Rows(I).Item("vehicle_id")
        ._XDATE = 0
        ._YEAR = ds.Tables(0).Rows(I).Item("vehicle_year")
        ._ZIP4 = CnvSng(ds.Tables(0).Rows(I).Item("zip2"))
        ._ZIP5 = CnvSng(ds.Tables(0).Rows(I).Item("zip1"))
        .AddOneRecordP()
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '          .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next
    ds = Nothing
  End Sub
  Private Sub WriteMVA(ByVal WrkFileName As String)
    Dim ds As DataSet = New DataSet
    Dim Excd(4) As String
    Dim Exam(4) As Long
    Dim WrkTxyr As Integer
    Dim I As Integer
    Dim J As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal

    MyTXMVA = New TXMVA(myDBConnectGEMS.MyConn2, WrkFileName)
    myDBConnectGEMS.DeleteRecords2(WrkFileName, "where txyear>=" & cArchiveOldYear & " and txyear<=" & cArchiveNewYear)
    ds = myDBConnect.RunQuery("ASSRMV", "where record_year>=" & cArchiveOldYear & " and record_year<=" & cArchiveNewYear)
    WrkFile = WrkFileName
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTXMVA
        Counter = Counter + 1
        WrkListNo = ds.Tables(0).Rows(I).Item("list_no")
        WrkTxyr = ds.Tables(0).Rows(I).Item("record_year")
        J = -1
        Array.Clear(Exam, 0, 4)
        Array.Clear(Excd, 0, 4)
        Excd(0) = Trim(ds.Tables(0).Rows(I).Item("code_exempt1"))
        Excd(1) = Trim(ds.Tables(0).Rows(I).Item("code_exempt2"))
        Excd(2) = Trim(ds.Tables(0).Rows(I).Item("code_exempt3"))
        Excd(3) = Trim(ds.Tables(0).Rows(I).Item("code_exempt4"))
        Excd(4) = Trim(ds.Tables(0).Rows(I).Item("code_exempt5"))
        Exam(0) = ds.Tables(0).Rows(I).Item("amnt_exmpt_org1")
        Exam(1) = ds.Tables(0).Rows(I).Item("amnt_exmpt_org2")
        Exam(2) = ds.Tables(0).Rows(I).Item("amnt_exmpt_org3")
        Exam(3) = ds.Tables(0).Rows(I).Item("amnt_exmpt_org4")
        Exam(4) = ds.Tables(0).Rows(I).Item("amnt_exmpt_org5")
        .GetOneRecordP(WrkListNo, WrkTxyr)
        ._ADD1 = ConvertString("Add1", ds.Tables(0).Rows(I).Item("Street"), 35)
        ._ADD2 = ConvertString("Add1", ds.Tables(0).Rows(I).Item("Street2"), 35)
        ._ASS = "Z" 'ds.Tables(0).Rows(I).Item("assr_code")
        ._BODY = ds.Tables(0).Rows(I).Item("vehicle_body_style")
        ._BTC = ""
        ._BTR = 0
        ._CAT = "1"
        ._CCCD1 = ""
        ._CCCD2 = ""
        ._CCCD3 = ""
        ._CCCD4 = ""
        ._CCCD5 = ""
        ._CCEX = 0
        ._CCGRS = 0
        ._CCNO = CnvSng(ds.Tables(0).Rows(I).Item("boa_coc_no"))
        ._CCRS = ""
        ._CDATE = 0
        ._CEXA1 = 0
        ._CEXA2 = 0
        ._CEXA3 = 0
        ._CEXA4 = 0
        ._CEXA5 = 0
        ._CHDATE = 0
        ._CHTIME = 0
        ._CLASS = ds.Tables(0).Rows(I).Item("vehicle_class")
        ._CYCLE = 0
        ._CYLAX = 0
        ._CITY = ConvertString("City", ds.Tables(0).Rows(I).Item("city"), 25)
        ._DIST = 0
        ._DNBTR = ""
        ._DOB = ConvertDate(ds.Tables(0).Rows(I).Item("dob"))
        ._DTBTR = 0
        ._EXAM1 = 0
        ._EXAM2 = 0
        ._EXAM3 = 0
        ._EXAM4 = 0
        ._EXAM5 = 0
        ._EXCD1 = ""
        ._EXCD2 = ""
        ._EXCD3 = ""
        ._EXCD4 = ""
        ._EXCD5 = ""
        ._EXAM1 = Exam(0)
        ._EXAM2 = Exam(1)
        ._EXAM3 = Exam(2)
        ._EXAM4 = Exam(3)
        ._EXAM5 = Exam(4)
        If ._EXAM1 > 0 Then
          ._EXCD1 = Excd(0)
        End If
        If ._EXAM2 > 0 Then
          ._EXCD2 = Excd(1)
        End If
        If ._EXAM3 > 0 Then
          ._EXCD3 = Excd(2)
        End If
        If ._EXAM4 > 0 Then
          ._EXCD4 = Excd(3)
        End If
        If ._EXAM5 > 0 Then
          ._EXCD5 = Excd(4)
        End If
        ._GWT = ds.Tables(0).Rows(I).Item("vehicle_gross_weight")
        ._LEASE = ""
        ._LETT = Mid(ds.Tables(0).Rows(I).Item("taxpayer"), 1, 1)
        ._LISTNO = WrkListNo
        ._LNVAL = ds.Tables(0).Rows(I).Item("loanvalue")
        ._LOC = ConvertString("Loc", ds.Tables(0).Rows(I).Item("location_name"), 25)
        ._LOCNO = JustifyRight(ds.Tables(0).Rows(I).Item("location_no"), 7)
        ._LWT = ds.Tables(0).Rows(I).Item("vehicle_light_weight")
        ._MAKE = ds.Tables(0).Rows(I).Item("vehicle_make")
        ._MODEL = ds.Tables(0).Rows(I).Item("vehicle_model")
        ._MSRP = ds.Tables(0).Rows(I).Item("msr")
        ._NADA = ""
        ._NAME = ConvertString("Name", ds.Tables(0).Rows(I).Item("taxpayer"), 35)
        ._SNAME = ConvertString("Sname", ds.Tables(0).Rows(I).Item("in_care_of"), 35)
        ._OASS = ""
        ._OCLS = 0
        ._OCODE = 0
        ._OID = ds.Tables(0).Rows(I).Item("dmv_vehicleid")
        ._OLIST = 0
        ._OMAKE = ""
        ._OMOD = ""
        ._OPVAL = 0
        ._OREGNO = ""
        ._ORIG = 0
        ._OVAL = 0
        ._OVIN = ""
        ._OYEAR = 0
        ._PCCOD = 0
        ._PCLR = ds.Tables(0).Rows(I).Item("vehicle_p_color")
        ._PDST = 0
        ._PNET = 0
        ._PREG = ""
        ._PRF = ds.Tables(0).Rows(I).Item("change_user")
        If Trim(ds.Tables(0).Rows(I).Item("street_mailing_addr")) <> "" Then
          ._RAD1 = ds.Tables(0).Rows(I).Item("street_mailing_addr")
          ._RAD2 = ds.Tables(0).Rows(I).Item("street_mailing_addr2")
          ._RCTY = ds.Tables(0).Rows(I).Item("city_mailing_addr")
          ._RST = ds.Tables(0).Rows(I).Item("state_mailing_addr")
          ._RZ4 = CnvSng(ds.Tables(0).Rows(I).Item("zip2_mailing_addr"))
          ._RZ5 = CnvSng(ds.Tables(0).Rows(I).Item("zip1_mailing_addr"))
        Else
          ._RAD1 = ConvertString("Add1", ds.Tables(0).Rows(I).Item("Street"), 35)
          ._RAD2 = ConvertString("Add1", ds.Tables(0).Rows(I).Item("Street2"), 35)
          ._RCTY = ConvertString("City", ds.Tables(0).Rows(I).Item("city"), 25)
          ._RST = ds.Tables(0).Rows(I).Item("state")
          ._RZ4 = CnvSng(ds.Tables(0).Rows(I).Item("zip2"))
          ._RZ5 = CnvSng(ds.Tables(0).Rows(I).Item("zip1"))
        End If
        ._RATE = 70
        ._RCODE = 0
        ._REGNO = ds.Tables(0).Rows(I).Item("vehicle_registration")
        ._SCAP = 0
        ._SCLR = ds.Tables(0).Rows(I).Item("vehicle_2nd_color")
        ._SEAT = 0
        ._SS2 = CnvSng(ds.Tables(0).Rows(I).Item("secondaryownercustomerid"))
        ._SSNO = CnvSng(ds.Tables(0).Rows(I).Item("primaryownercustomerid"))
        ._STATE = ds.Tables(0).Rows(I).Item("state")
        ._TDATE = 0
        ._TIN = ""
        ._TRVAL = ds.Tables(0).Rows(I).Item("tradein")
        ._TXYEAR = WrkTxyr
        ._TYPE = "M"
        ._VALUE = ds.Tables(0).Rows(I).Item("gl_value")
        ._VINNO = ds.Tables(0).Rows(I).Item("vehicle_id")
        ._XDATE = 0
        ._YEAR = ds.Tables(0).Rows(I).Item("vehicle_year")
        ._ZIP4 = CnvSng(ds.Tables(0).Rows(I).Item("zip2"))
        ._ZIP5 = CnvSng(ds.Tables(0).Rows(I).Item("zip1"))
        .AddOneRecordP()
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '          .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next
    ds = Nothing
  End Sub
  Private Sub WriteSU(ByVal WrkFileName As String, WrkYear As Integer)
    Dim ds As DataSet = New DataSet
    Dim ds3 As DataSet = New DataSet
    Dim I As Integer
    Dim J As Integer
    Dim WrkCCNo As Integer
    Dim WrkCCDate As Integer
    Dim WrkLen As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal

    MyTXSUPP = New TXSUPP(myDBConnectGEMS.MyConn2, WrkFileName)
    myDBConnectGEMS.DeleteRecords2(WrkFileName, "")
    ds = myDBConnect.RunQuery("ASSRMVS", "where record_year=" & WrkYear - 2)
    WrkFile = WrkFileName
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTXSUPP
        Counter = Counter + 1
        WrkListNo = ds.Tables(0).Rows(I).Item("list_no")
        .GetOneRecordP(WrkListNo)
        ._ADD1 = ConvertString("Add1", ds.Tables(0).Rows(I).Item("Street"), 35)
        ._ADD2 = ConvertString("Add1", ds.Tables(0).Rows(I).Item("Street2"), 35)
        ._ASS = ds.Tables(0).Rows(I).Item("month_code")
        ._BODY = ds.Tables(0).Rows(I).Item("vehicle_body_style")
        ._BTC = ""
        ._BTR = 0
        ._CAT = "1"
        ._CCCD1 = ""
        ._CCCD2 = ""
        ._CCCD3 = ""
        ._CCCD4 = ""
        ._CCCD5 = ""
        ._CCEX = 0
        ._CCGRS = 0
        WrkLen = Len(Trim(ds.Tables(0).Rows(I).Item("boa_coc_no")))
        If WrkLen > 1 Then
          WrkCCNo = Mid(Trim(ds.Tables(0).Rows(I).Item("boa_coc_no")), 1, WrkLen - 1) 'All digits 
        Else
          WrkCCNo = 0
        End If
        WrkCCDate = 0
        ._CCNO = WrkCCNo
        If WrkCCNo > 0 And Trim(ds.Tables(0).Rows(I).Item("coc_form")) = "M" Then
          ds3 = myDBConnect3.RunQuery("COC_DATA", "where coc_number='" & ds.Tables(0).Rows(I).Item("boa_coc_no") & "'")
          If ds3.Tables(0).Rows.Count > 0 Then
            For J = 0 To ds3.Tables(0).Rows.Count - 1
              WrkCCDate = SetDBDate(ds3.Tables(0).Rows(J).Item("coc_date"))
              ._CCEX = ds3.Tables(0).Rows(J).Item("total_exempt_new")
              ._CCGRS = ds3.Tables(0).Rows(J).Item("new_gross")
            Next
          End If
        End If
        ._CCRS = ""
        ._CDATE = WrkCCDate
        ._CEXA1 = 0
        ._CEXA2 = 0
        ._CEXA3 = 0
        ._CEXA4 = 0
        ._CEXA5 = 0
        ._CHDATE = 0
        ._CHTIME = 0
        ._CLASS = ds.Tables(0).Rows(I).Item("vehicle_class")
        ._CYCLE = 0
        ._CYLAX = 0
        ._CITY = ConvertString("City", ds.Tables(0).Rows(I).Item("city"), 25)
        ._DIST = 0
        ._DOB = ConvertDate(ds.Tables(0).Rows(I).Item("dob"))
        If ds.Tables(0).Rows(I).Item("gl_exmpt") > 0 Then
          ._EXAM1 = ds.Tables(0).Rows(I).Item("amount_exempt1")
          ._EXAM2 = ds.Tables(0).Rows(I).Item("amount_exempt2")
          ._EXAM3 = ds.Tables(0).Rows(I).Item("amount_exempt3")
          ._EXAM4 = ds.Tables(0).Rows(I).Item("amount_exempt4")
          ._EXAM5 = ds.Tables(0).Rows(I).Item("amount_exempt5")
          ._EXCD1 = ds.Tables(0).Rows(I).Item("code_exempt1")
          ._EXCD2 = ds.Tables(0).Rows(I).Item("code_exempt2")
          ._EXCD3 = ds.Tables(0).Rows(I).Item("code_exempt3")
          ._EXCD4 = ds.Tables(0).Rows(I).Item("code_exempt4")
          ._EXCD5 = ds.Tables(0).Rows(I).Item("code_exempt5")
        Else
          ._EXAM1 = 0
          ._EXAM2 = 0
          ._EXAM3 = 0
          ._EXAM4 = 0
          ._EXAM5 = 0
          ._EXCD1 = ""
          ._EXCD2 = ""
          ._EXCD3 = ""
          ._EXCD4 = ""
          ._EXCD5 = ""
        End If
        ._GWT = ds.Tables(0).Rows(I).Item("vehicle_gross_weight")
        ._LEASE = ""
        ._LETT = Mid(ds.Tables(0).Rows(I).Item("taxpayer"), 1, 1)
        ._LISTNO = WrkListNo
        ._LNVAL = ds.Tables(0).Rows(I).Item("loanvalue")
        ._LWT = ds.Tables(0).Rows(I).Item("vehicle_light_weight")
        ._MAKE = ds.Tables(0).Rows(I).Item("vehicle_make")
        ._MODEL = ds.Tables(0).Rows(I).Item("vehicle_model")
        ._MSRP = 0
        ._NADA = ""
        ._NAME = ConvertString("Name", ds.Tables(0).Rows(I).Item("taxpayer"), 35)
        ._SNAME = ConvertString("Sname", ds.Tables(0).Rows(I).Item("in_care_of"), 35)
        ._OASS = ""
        If Trim(ds.Tables(0).Rows(I).Item("old_vehicle_registration")) <> "" Then
          ._OASS = ds.Tables(0).Rows(I).Item("assr_code")
        End If
        ._OCLS = ds.Tables(0).Rows(I).Item("old_vehicle_class")
        ._OCODE = 0
        ._OID = ds.Tables(0).Rows(I).Item("dmv_vehicleid")
        ._OLIST = 0
        ._OMAKE = ds.Tables(0).Rows(I).Item("old_vehicle_make")
        ._OMOD = ds.Tables(0).Rows(I).Item("old_vehicle_model")
        ._OREGNO = ds.Tables(0).Rows(I).Item("old_vehicle_registration")
        ._ORIG = 0
        ._OVAL = ds.Tables(0).Rows(I).Item("old_value")
        ._OVIN = ds.Tables(0).Rows(I).Item("old_vehicle_id")
        ._OYEAR = ds.Tables(0).Rows(I).Item("old_vehicle_year")
        ._PCCOD = 0
        ._PCLR = ds.Tables(0).Rows(I).Item("vehicle_p_color")
        ._PDST = 0
        ._PNET = ds.Tables(0).Rows(I).Item("net")
        ._PREG = ""
        ._PRF = ds.Tables(0).Rows(I).Item("change_user")
        ._PVAL = ds.Tables(0).Rows(I).Item("gl_adj_value")
        ._OPVAL = ._PVAL - ._PNET
        ._RATE = 70
        ._RCODE = 0
        ._REGNO = ds.Tables(0).Rows(I).Item("vehicle_registration")
        ._SCAP = 0
        ._SCLR = ds.Tables(0).Rows(I).Item("vehicle_2nd_color")
        ._SEAT = 0
        ._SS2 = CnvSng(ds.Tables(0).Rows(I).Item("secondaryownercustomerid"))
        ._SSNO = CnvSng(ds.Tables(0).Rows(I).Item("primaryownercustomerid"))
        ._STATE = ds.Tables(0).Rows(I).Item("state")
        ._TDATE = 0
        ._TIN = ""
        ._TRVAL = ds.Tables(0).Rows(I).Item("tradein")
        ._TYPE = "S"
        ._VALUE = ds.Tables(0).Rows(I).Item("GL_value")
        ._VINNO = ds.Tables(0).Rows(I).Item("vehicle_id")
        ._XDATE = 0
        ._YEAR = ds.Tables(0).Rows(I).Item("vehicle_year")
        ._ZIP4 = CnvSng(ds.Tables(0).Rows(I).Item("zip2"))
        ._ZIP5 = CnvSng(ds.Tables(0).Rows(I).Item("zip1"))
        .AddOneRecordP()
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '          .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next
    ds = Nothing
  End Sub
  Private Sub WriteSUA(ByVal WrkFileName As String)
    Dim ds As DataSet = New DataSet
    Dim WrkTxyr As Integer
    Dim I As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal

    MyTXSUPA = New TXSUPA(myDBConnectGEMS.MyConn2, WrkFileName)
    myDBConnectGEMS.DeleteRecords2(WrkFileName, "where txyear>=" & cArchiveOldYear & " and txyear<=" & cArchiveNewYear)
    ds = myDBConnect.RunQuery("ASSRMVS", "where record_year>=" & cArchiveOldYear & " and record_year<=" & cArchiveNewYear)
    WrkFile = WrkFileName
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTXSUPA
        Counter = Counter + 1
        WrkListNo = ds.Tables(0).Rows(I).Item("list_no")
        WrkTxyr = ds.Tables(0).Rows(I).Item("record_year")
        .GetOneRecordP(WrkListNo, WrkTxyr)
        ._ADD1 = ConvertString("Add1", ds.Tables(0).Rows(I).Item("Street"), 35)
        ._ADD2 = ConvertString("Add1", ds.Tables(0).Rows(I).Item("Street2"), 35)
        ._ASS = ds.Tables(0).Rows(I).Item("month_code")
        ._BODY = ds.Tables(0).Rows(I).Item("vehicle_body_style")
        ._BTC = ""
        ._BTR = 0
        ._CAT = "1"
        ._CCCD1 = ""
        ._CCCD2 = ""
        ._CCCD3 = ""
        ._CCCD4 = ""
        ._CCCD5 = ""
        ._CCEX = 0
        ._CCGRS = 0
        ._CCNO = CnvSng(ds.Tables(0).Rows(I).Item("boa_coc_no"))
        ._CCRS = ""
        ._CDATE = 0
        ._CEXA1 = 0
        ._CEXA2 = 0
        ._CEXA3 = 0
        ._CEXA4 = 0
        ._CEXA5 = 0
        ._CHDATE = 0
        ._CHTIME = 0
        ._CLASS = ds.Tables(0).Rows(I).Item("vehicle_class")
        ._CYCLE = 0
        ._CYLAX = 0
        ._CITY = ConvertString("City", ds.Tables(0).Rows(I).Item("city"), 25)
        ._DIST = 0
        ._DOB = ConvertDate(ds.Tables(0).Rows(I).Item("dob"))
        ._EXAM1 = ds.Tables(0).Rows(I).Item("amount_exempt1")
        ._EXAM2 = ds.Tables(0).Rows(I).Item("amount_exempt2")
        ._EXAM3 = ds.Tables(0).Rows(I).Item("amount_exempt3")
        ._EXAM4 = ds.Tables(0).Rows(I).Item("amount_exempt4")
        ._EXAM5 = ds.Tables(0).Rows(I).Item("amount_exempt5")
        ._EXCD1 = ds.Tables(0).Rows(I).Item("code_exempt1")
        ._EXCD2 = ds.Tables(0).Rows(I).Item("code_exempt2")
        ._EXCD3 = ds.Tables(0).Rows(I).Item("code_exempt3")
        ._EXCD4 = ds.Tables(0).Rows(I).Item("code_exempt4")
        ._EXCD5 = ds.Tables(0).Rows(I).Item("code_exempt5")
        ._GWT = ds.Tables(0).Rows(I).Item("vehicle_gross_weight")
        ._LEASE = ""
        ._LETT = Mid(ds.Tables(0).Rows(I).Item("taxpayer"), 1, 1)
        ._LISTNo = WrkListNo
        ._LNVAL = ds.Tables(0).Rows(I).Item("loanvalue")
        ._LWT = ds.Tables(0).Rows(I).Item("vehicle_light_weight")
        ._MAKE = ds.Tables(0).Rows(I).Item("vehicle_make")
        ._MODEL = ds.Tables(0).Rows(I).Item("vehicle_model")
        ._MSRP = 0
        ._NADA = ""
        ._NAME = ConvertString("Name", ds.Tables(0).Rows(I).Item("taxpayer"), 35)
        ._SNAME = ConvertString("Sname", ds.Tables(0).Rows(I).Item("in_care_of"), 35)
        ._OASS = ""
        If Trim(ds.Tables(0).Rows(I).Item("old_vehicle_registration")) <> "" Then
          ._OASS = ds.Tables(0).Rows(I).Item("assr_code")
        End If
        ._OCLS = ds.Tables(0).Rows(I).Item("old_vehicle_class")
        ._OCODE = 0
        ._OID = ds.Tables(0).Rows(I).Item("dmv_vehicleid")
        ._OLIST = 0
        ._OMAKE = ds.Tables(0).Rows(I).Item("old_vehicle_make")
        ._OMOD = ds.Tables(0).Rows(I).Item("old_vehicle_model")
        ._OREGNo = ds.Tables(0).Rows(I).Item("old_vehicle_registration")
        ._ORIG = 0
        ._OVAL = ds.Tables(0).Rows(I).Item("old_value")
        ._OVIN = ds.Tables(0).Rows(I).Item("old_vehicle_id")
        ._OYEAR = ds.Tables(0).Rows(I).Item("old_vehicle_year")
        ._PCCOD = 0
        ._PCLR = ds.Tables(0).Rows(I).Item("vehicle_p_color")
        ._PDST = 0
        ._PNET = ds.Tables(0).Rows(I).Item("net")
        ._PREG = ""
        ._PRF = ds.Tables(0).Rows(I).Item("change_user")
        ._PVAL = ds.Tables(0).Rows(I).Item("adj_value")
        ._OPVAL = ._PVAL - ._PNET
        ._RATE = 70
        ._RCODE = 0
        ._REGNO = ds.Tables(0).Rows(I).Item("vehicle_registration")
        ._SCAP = 0
        ._SCLR = ds.Tables(0).Rows(I).Item("vehicle_2nd_color")
        ._SEAT = 0
        ._SS2 = CnvSng(ds.Tables(0).Rows(I).Item("secondaryownercustomerid"))
        ._SSNo = CnvSng(ds.Tables(0).Rows(I).Item("primaryownercustomerid"))
        ._STATE = ds.Tables(0).Rows(I).Item("state")
        ._TDATE = 0
        ._TIN = ""
        ._TRVAL = ds.Tables(0).Rows(I).Item("tradein")
        ._TXYEAR = WrkTxyr
        ._TYPE = "S"
        ._VALUE = ds.Tables(0).Rows(I).Item("value")
        ._VINNO = ds.Tables(0).Rows(I).Item("vehicle_id")
        ._XDATE = 0
        ._YEAR = ds.Tables(0).Rows(I).Item("vehicle_year")
        ._ZIP4 = CnvSng(ds.Tables(0).Rows(I).Item("zip2"))
        ._ZIP5 = CnvSng(ds.Tables(0).Rows(I).Item("zip1"))
        .AddOneRecordP()
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '          .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next
    ds = Nothing
  End Sub
  Private Sub WriteRE(ByVal WrkFileName As String, WrkYear As Integer)
    Dim ds As DataSet = New DataSet
    Const cMaxExam As Long = 9999999
    Dim I As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    MyTXREAL = New TXREAL(myDBConnectGEMS.MyConn2, WrkFileName)
    myDBConnectGEMS.DeleteRecords2(WrkFileName)
    ds = myDBConnect.RunQuery("ASSRREAL", "where record_year=" & WrkYear & " order by list_no")
    WrkFile = WrkFileName
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTXREAL
        Counter = Counter + 1
        WrkListNo = ds.Tables(0).Rows(I).Item("list_no")
        .GetOneRecordP(WrkListNo)
        ._AACRE = 0
        ._ACCTN = ""
        ._ACRE1 = ds.Tables(0).Rows(I).Item("acreage")
        ._ACRE2 = 0
        ._ACRE3 = 0
        ._ACRE4 = 0
        ._ACRE5 = 0
        ._ACRE6 = 0
        ._ACRE7 = 0
        ._ADD1 = ConvertString("Add1", ds.Tables(0).Rows(I).Item("Street"), 35)
        ._ADD2 = ConvertString("Add2", ds.Tables(0).Rows(I).Item("Country_Mailing_Addr"), 35)
        ._AEDATE = 0
        ._AIDTE = 0
        If WrkYear = MyGLYear Then
          ._ASS1 = ds.Tables(0).Rows(I).Item("amount1")
          ._ASS2 = ds.Tables(0).Rows(I).Item("amount2")
          ._ASS3 = ds.Tables(0).Rows(I).Item("amount3")
          ._ASS4 = ds.Tables(0).Rows(I).Item("amount4")
          ._ASS5 = ds.Tables(0).Rows(I).Item("amount5")
          ._ASS6 = ds.Tables(0).Rows(I).Item("amount6")
          ._ASS7 = ds.Tables(0).Rows(I).Item("amount7")
        Else
          ._ASS1 = ds.Tables(0).Rows(I).Item("amount_org1")
          ._ASS2 = ds.Tables(0).Rows(I).Item("amount_org2")
          ._ASS3 = ds.Tables(0).Rows(I).Item("amount_org3")
          ._ASS4 = ds.Tables(0).Rows(I).Item("amount_org4")
          ._ASS5 = ds.Tables(0).Rows(I).Item("amount_org5")
          ._ASS6 = ds.Tables(0).Rows(I).Item("amount_org6")
          ._ASS7 = ds.Tables(0).Rows(I).Item("amount_org7")
        End If
        Select Case Len(ds.Tables(0).Rows(I).Item("bank_no"))
          Case > 2
            ._BKCD = ""
          Case Else
            ._BKCD = ds.Tables(0).Rows(I).Item("bank_no")
        End Select
        ._BKSV = ""
        ._BTC = ""
        ._BTR = 0
        ._CARD = "N"
        ._CASS1 = 0
        ._CASS2 = 0
        ._CASS3 = 0
        ._CASS4 = 0
        ._CASS5 = 0
        ._CASS6 = 0
        ._CASS7 = 0
        If Len(Trim(ds.Tables(0).Rows(I).Item("code_exempt1"))) = 4 Then
          ._CAT = "3"
          ._EXMPT = ds.Tables(0).Rows(I).Item("code_exempt1")
        Else
          ._CAT = "1"
          ._EXMPT = ""
        End If
        ._CCCD1 = ""
        ._CCCD2 = ""
        ._CCCD3 = ""
        ._CCCD4 = ""
        ._CCCD5 = ""
        ._CCCD6 = ""
        ._CCCD7 = ""
        ._CCEX = 0
        ._CCGRS = 0
        ._CCNO = CnvSng(ds.Tables(0).Rows(I).Item("boa_coc_no"))
        ._CCRS = ""
        ._CDATE = 0
        ._CENBK = 0
        ._CENTR = 0
        ._CEXA1 = 0
        ._CEXA2 = 0
        ._CEXA3 = 0
        ._CEXA4 = 0
        ._CEXA5 = 0
        ._CEXA6 = 0
        ._CEXA7 = 0
        ._CHDATE = 0
        ._CHTIME = 0
        ._CIRAD = 0
        ._CITY = ConvertString("City", ds.Tables(0).Rows(I).Item("city"), 25)
        ._CMAX = 0
        ._CMIN = 0
        If WrkYear = MyGLYear Then
          ._CODE1 = ds.Tables(0).Rows(I).Item("code_old1")
          ._CODE2 = ds.Tables(0).Rows(I).Item("code_old2")
          ._CODE3 = ds.Tables(0).Rows(I).Item("code_old3")
          ._CODE4 = ds.Tables(0).Rows(I).Item("code_old4")
          ._CODE5 = ds.Tables(0).Rows(I).Item("code_old5")
          ._CODE6 = ds.Tables(0).Rows(I).Item("code_old6")
          ._CODE7 = ds.Tables(0).Rows(I).Item("code_old7")
        Else
          ._CODE1 = ds.Tables(0).Rows(I).Item("code_old_org1")
          ._CODE2 = ds.Tables(0).Rows(I).Item("code_old_org2")
          ._CODE3 = ds.Tables(0).Rows(I).Item("code_old_org3")
          ._CODE4 = ds.Tables(0).Rows(I).Item("code_old_org4")
          ._CODE5 = ds.Tables(0).Rows(I).Item("code_old_org5")
          ._CODE6 = ds.Tables(0).Rows(I).Item("code_old_org6")
          ._CODE7 = ds.Tables(0).Rows(I).Item("code_old_org7")
        End If
        ._CPERC = 0
        ._DIST = 0
        ._DNBTR = ""
        ._DTBTR = 0
        If WrkYear = MyGLYear Then
          If Len(Trim(ds.Tables(0).Rows(I).Item("code_exempt1"))) = 3 Then
            If ds.Tables(0).Rows(I).Item("amount_exempt1") <= cMaxExam Then
              ._EXAM1 = ds.Tables(0).Rows(I).Item("amount_exempt1")
            Else
              ._EXAM1 = cMaxExam
              sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam1:," & ds.Tables(0).Rows(I).Item("amount_exempt1"))
            End If
            If ds.Tables(0).Rows(I).Item("amount_exempt2") <= cMaxExam Then
              ._EXAM2 = ds.Tables(0).Rows(I).Item("amount_exempt2")
            Else
              ._EXAM2 = cMaxExam
              sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam2:," & ds.Tables(0).Rows(I).Item("amount_exempt2"))
            End If
            If ds.Tables(0).Rows(I).Item("amount_exempt3") <= cMaxExam Then
              ._EXAM3 = ds.Tables(0).Rows(I).Item("amount_exempt3")
            Else
              ._EXAM3 = cMaxExam
              sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam3:," & ds.Tables(0).Rows(I).Item("amount_exempt3"))
            End If
            If ds.Tables(0).Rows(I).Item("amount_exempt4") <= cMaxExam Then
              ._EXAM4 = ds.Tables(0).Rows(I).Item("amount_exempt4")
            Else
              ._EXAM4 = cMaxExam
              sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam1:," & ds.Tables(0).Rows(I).Item("amount_exempt1"))
            End If
            If ds.Tables(0).Rows(I).Item("amount_exempt5") <= cMaxExam Then
              ._EXAM5 = ds.Tables(0).Rows(I).Item("amount_exempt5")
            Else
              ._EXAM5 = cMaxExam
              sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam5:," & ds.Tables(0).Rows(I).Item("amount_exempt5"))
            End If
            If ds.Tables(0).Rows(I).Item("amount_exempt6") <= cMaxExam Then
              ._EXAM6 = ds.Tables(0).Rows(I).Item("amount_exempt6")
            Else
              ._EXAM6 = cMaxExam
              sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam6:," & ds.Tables(0).Rows(I).Item("amount_exempt6"))
            End If
            If ds.Tables(0).Rows(I).Item("amount_exempt7") <= cMaxExam Then
              ._EXAM7 = ds.Tables(0).Rows(I).Item("amount_exempt7")
            Else
              ._EXAM7 = cMaxExam
              sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam7:," & ds.Tables(0).Rows(I).Item("amount_exempt7"))
            End If
            ._EXCD1 = ds.Tables(0).Rows(I).Item("code_exempt1")
            ._EXCD2 = ds.Tables(0).Rows(I).Item("code_exempt2")
            ._EXCD3 = ds.Tables(0).Rows(I).Item("code_exempt3")
            ._EXCD4 = ds.Tables(0).Rows(I).Item("code_exempt4")
            ._EXCD5 = ds.Tables(0).Rows(I).Item("code_exempt5")
            ._EXCD6 = ds.Tables(0).Rows(I).Item("code_exempt6")
            ._EXCD7 = ds.Tables(0).Rows(I).Item("code_exempt7")
          Else
            ._EXAM1 = 0
            ._EXAM2 = 0
            ._EXAM3 = 0
            ._EXAM4 = 0
            ._EXAM5 = 0
            ._EXAM6 = 0
            ._EXAM7 = 0
            ._EXCD1 = ""
            ._EXCD2 = ""
            ._EXCD3 = ""
            ._EXCD4 = ""
            ._EXCD5 = ""
            ._EXCD6 = ""
            ._EXCD7 = ""
          End If
        Else
          If Len(Trim(ds.Tables(0).Rows(I).Item("code_exempt1"))) = 3 Then
            If ds.Tables(0).Rows(I).Item("amnt_exmpt_org1") <= cMaxExam Then
              ._EXAM1 = ds.Tables(0).Rows(I).Item("amnt_exmpt_org1")
            Else
              ._EXAM1 = cMaxExam
              sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam1:," & ds.Tables(0).Rows(I).Item("amnt_exmpt_org1"))
            End If
            If ds.Tables(0).Rows(I).Item("amnt_exmpt_org2") <= cMaxExam Then
              ._EXAM2 = ds.Tables(0).Rows(I).Item("amnt_exmpt_org2")
            Else
              ._EXAM2 = cMaxExam
              sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam2:," & ds.Tables(0).Rows(I).Item("amnt_exmpt_org2"))
            End If
            If ds.Tables(0).Rows(I).Item("amnt_exmpt_org3") <= cMaxExam Then
              ._EXAM3 = ds.Tables(0).Rows(I).Item("amnt_exmpt_org3")
            Else
              ._EXAM3 = cMaxExam
              sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam3:," & ds.Tables(0).Rows(I).Item("amnt_exmpt_org3"))
            End If
            If ds.Tables(0).Rows(I).Item("amnt_exmpt_org4") <= cMaxExam Then
              ._EXAM4 = ds.Tables(0).Rows(I).Item("amnt_exmpt_org4")
            Else
              ._EXAM4 = cMaxExam
              sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam1:," & ds.Tables(0).Rows(I).Item("amnt_exmpt_org1"))
            End If
            If ds.Tables(0).Rows(I).Item("amnt_exmpt_org5") <= cMaxExam Then
              ._EXAM5 = ds.Tables(0).Rows(I).Item("amnt_exmpt_org5")
            Else
              ._EXAM5 = cMaxExam
              sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam5:," & ds.Tables(0).Rows(I).Item("amnt_exmpt_org5"))
            End If
            If ds.Tables(0).Rows(I).Item("amnt_exmpt_org6") <= cMaxExam Then
              ._EXAM6 = ds.Tables(0).Rows(I).Item("amnt_exmpt_org6")
            Else
              ._EXAM6 = cMaxExam
              sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam6:," & ds.Tables(0).Rows(I).Item("amnt_exmpt_org6"))
            End If
            If ds.Tables(0).Rows(I).Item("amnt_exmpt_org7") <= cMaxExam Then
              ._EXAM7 = ds.Tables(0).Rows(I).Item("amnt_exmpt_org7")
            Else
              ._EXAM7 = cMaxExam
              sw.WriteLine(WrkFile & "," & WrkListNo & ",Exam7:," & ds.Tables(0).Rows(I).Item("amnt_exmpt_org7"))
            End If
            ._EXCD1 = ds.Tables(0).Rows(I).Item("code_exempt1")
            ._EXCD2 = ds.Tables(0).Rows(I).Item("code_exempt2")
            ._EXCD3 = ds.Tables(0).Rows(I).Item("code_exempt3")
            ._EXCD4 = ds.Tables(0).Rows(I).Item("code_exempt4")
            ._EXCD5 = ds.Tables(0).Rows(I).Item("code_exempt5")
            ._EXCD6 = ds.Tables(0).Rows(I).Item("code_exempt6")
            ._EXCD7 = ds.Tables(0).Rows(I).Item("code_exempt7")
          Else
            ._EXAM1 = 0
            ._EXAM2 = 0
            ._EXAM3 = 0
            ._EXAM4 = 0
            ._EXAM5 = 0
            ._EXAM6 = 0
            ._EXAM7 = 0
            ._EXCD1 = ""
            ._EXCD2 = ""
            ._EXCD3 = ""
            ._EXCD4 = ""
            ._EXCD5 = ""
            ._EXCD6 = ""
            ._EXCD7 = ""
          End If
        End If
        ._FASS = 0
        ._FCCOD = ""
        ._FCYR = 0
        ._FTAX = 0
        If WrkYear = MyGLYear Then
          ._GROSS = ds.Tables(0).Rows(I).Item("new_gross")
        Else
          ._GROSS = ds.Tables(0).Rows(I).Item("new_gross_org")
        End If
        ._LETT = Mid(ds.Tables(0).Rows(I).Item("taxpayer"), 1, 1)
        ._LISTNO = WrkListNo
        ._LOC = ConvertString("Loc", ds.Tables(0).Rows(I).Item("prop_loc_st_name"), 25)
        ._LOCNO = JustifyRight(ds.Tables(0).Rows(I).Item("Prop_loc_st_no"), 7)
        ._MAP = ConvertString("Map", ds.Tables(0).Rows(I).Item("map_block_lot"), 17)
        ._NAME = ConvertString("Name", ds.Tables(0).Rows(I).Item("taxpayer"), 35)
        ._SNAME = ConvertString("Sname", ds.Tables(0).Rows(I).Item("in_care_of"), 35)
        If Len(Trim(ds.Tables(0).Rows(I).Item("code_exempt1"))) = 4 Then
          ._NET = ._GROSS
        Else
          If WrkYear = MyGLYear Then
            If ds.Tables(0).Rows(I).Item("total_exempt") > 0 Then
              ._NET = ._GROSS - ds.Tables(0).Rows(I).Item("total_exempt")
            Else
              ._NET = ds.Tables(0).Rows(I).Item("net")
            End If
          Else
            If ds.Tables(0).Rows(I).Item("total_exempt_org") > 0 Then
              ._NET = ._GROSS - ds.Tables(0).Rows(I).Item("total_exempt_org")
            Else
              ._NET = ds.Tables(0).Rows(I).Item("net_org")
            End If
          End If
        End If
        ._OID = ""
        ._PDST = 0
        ._PERC = 0
        ._PGE = ConvertString("Pge", ds.Tables(0).Rows(I).Item("page"), 5)
        ._PRF = Trim(Mid(ds.Tables(0).Rows(I).Item("change_user"), 1, 10))
        ._PURDT = ConvertDate(ds.Tables(0).Rows(I).Item("sale_date"))
        ._PURPR = ds.Tables(0).Rows(I).Item("sale_price")
        ._RLST = 0
        ._SEWER = "Y"
        ._SMAP = ""
        ._SS2 = 0
        ._SSNO = 0
        ._STATE = ConvertString("State", ds.Tables(0).Rows(I).Item("state"), 2)
        ._TIN = ""
        ._TWNBN = CnvSng(ds.Tables(0).Rows(I).Item("tbenefits1"))
        ._TYPE = "R"
        ._UNIT1 = 0
        ._UNIT2 = 0
        ._UNIT3 = 0
        ._UNIT4 = 0
        ._UNIT5 = 0
        ._UNIT6 = 0
        ._UNIT7 = 0
        ._UNITNO = ""
        ._VOL = ConvertString("Vol", ds.Tables(0).Rows(I).Item("volume"), 5)
        ._VTYR = 0
        ._WMAIL = ""
        ._ZIP4 = CnvSng(ds.Tables(0).Rows(I).Item("zip2"))
        ._ZIP5 = CnvSng(ds.Tables(0).Rows(I).Item("zip1"))
        .AddOneRecordP()
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next
    ds = Nothing
  End Sub
  Private Sub WriteCOEB(ByVal WrkGlYear As Integer)
    Dim ds As DataSet = New DataSet
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer
    Dim WrkYear As Integer
    Dim WrkType As String
    Dim WrkCCNo As Integer
    Dim WrkCCDate As Integer
    Dim WrkCode As Integer
    Dim WrkCat As String
    Dim WrkLen As Integer

    MyTXREAL = New TXREAL(myDBConnectGEMS.MyConn2, "TXREALC")
    MyTXPPRP = New TXPPRP(myDBConnectGEMS.MyConn2, "TXPPRPC")
    MyTXMVD = New TXMVD(myDBConnectGEMS.MyConn2, "TXMVDC")
    MyTXCOEB = New TXCOEB(myDBConnectGEMS.MyConn2)
    myDBConnectGEMS.DeleteRecords2("TXCOEB")
    ds = myDBConnect.RunQuery("COC_DATA", " where grand_list_year=" & WrkGlYear & " Order by coc_number")
    For I = 0 To ds.Tables(0).Rows.Count - 1
      WrkListNo = ds.Tables(0).Rows(I).Item("bill_number")
      WrkLen = Len(Trim(ds.Tables(0).Rows(I).Item("coc_number")))
      WrkType = GetTaxType(MyTOWN._TOWNBR, ds.Tables(0).Rows(I).Item("bill_type"))
      WrkCCNo = Mid(ds.Tables(0).Rows(I).Item("coc_number"), 1, WrkLen - 1)
      WrkYear = ds.Tables(0).Rows(I).Item("grand_list_year")
      WrkCat = ""
      WrkCCDate = ConvertDate(ds.Tables(0).Rows(I).Item("COC_DATE"))
      Select Case WrkType
        Case "R"
          With MyTXREAL
            .GetOneRecordP(WrkListNo)
            If Not .RecordNotFound Then
              ._CCNO = WrkCCNo
              ._CDATE = WrkCCDate
              WrkCode = Trim(._CODE1)
              ._CCGRS = ds.Tables(0).Rows(I).Item("New_Gross")
              ._CASS1 = ds.Tables(0).Rows(I).Item("New_Gross")
              ._CCCD1 = WrkCode
              ._CCEX = ds.Tables(0).Rows(I).Item("Total_Exempt_New")
              ._CEXA1 = ds.Tables(0).Rows(I).Item("Total_Exempt_New")
              WrkCat = "1"
              .UpdateOneRecordP()
            Else
              sw.WriteLine("COEB: RE not found " & WrkListNo & " " & .ErrMsg)
            End If
          End With
        Case "P"
          With MyTXPPRP
            .GetOneRecordP(WrkListNo)
            If Not .RecordNotFound Then
              ._CCNO = WrkCCNo
              ._CDATE = WrkCCDate
              WrkCode = Trim(._CODE1)
              ._CCGRS = ds.Tables(0).Rows(I).Item("New_Gross")
              ._CASS1 = ds.Tables(0).Rows(I).Item("New_Gross")
              ._CCCD1 = WrkCode
              ._CCEX = ds.Tables(0).Rows(I).Item("Total_Exempt_New")
              ._CEXA1 = ds.Tables(0).Rows(I).Item("Total_Exempt_New")
              WrkCat = "5"
              .UpdateOneRecordP()
            Else
              sw.WriteLine("COEB: PP not found " & WrkListNo & " " & .ErrMsg)
            End If
          End With
        Case "M"
          With MyTXMVD
            .GetOneRecordP(WrkListNo)
            If Not .RecordNotFound Then
              ._CCNO = WrkCCNo
              ._CDATE = WrkCCDate
              ._CCGRS = ds.Tables(0).Rows(I).Item("New_Gross")
              ._CCEX = ds.Tables(0).Rows(I).Item("Total_Exempt_New")
              ._CEXA1 = ds.Tables(0).Rows(I).Item("Total_Exempt_New")
              WrkCat = "1"
              .UpdateOneRecordP()
            Else
              sw.WriteLine("COEB: MV not found " & WrkListNo & " " & .ErrMsg)
            End If
          End With
        Case Else
          WrkCode = 0
          WrkCat = ""
      End Select

      With MyTXCOEB
        Counter = Counter + 1
        .GetOneRecordP(WrkCCNo)
        ._CATG = WrkCat
        ._CCNO = WrkCCNo
        ._CDATE = WrkCCDate
        ._CDESC = ConvertString("CDESC", ds.Tables(0).Rows(I).Item("CHANGE_REASON"), 25)
        ._CGRS = ds.Tables(0).Rows(I).Item("Org_Gross")
        If Trim(ds.Tables(0).Rows(I).Item("Gross_Inc_Dec")) = "DEC" Then
          ._CGRSCH = ds.Tables(0).Rows(I).Item("Adj_Gross") * -1
        Else
          ._CGRSCH = ds.Tables(0).Rows(I).Item("Adj_Gross")
        End If
        ._CHDATE = WrkCCDate
        ._CHTIME = 0
        ._CT2MC1 = ""
        ._CT2MC2 = ""
        ._CT2MC3 = ""
        ._CT2MC4 = ""
        ._CTYPE = WrkType
        ._CYEAR = WrkYear
        ._DIST = CnvSng(ds.Tables(0).Rows(I).Item("DISTRICT"))
        If Trim(ds.Tables(0).Rows(I).Item("Ex_Inc_Dec")) = "DEC" Then
          ._EXCHG = ds.Tables(0).Rows(I).Item("Adj_Exempt") * -1
        Else
          ._EXCHG = ds.Tables(0).Rows(I).Item("Adj_Exempt")
        End If
        ._EXEMP = ""
        ._LISTNo = WrkListNo
        ._NAME = ConvertString("NAME", ds.Tables(0).Rows(I).Item("TaxPayer"), 35)
        ._NTASS1 = ds.Tables(0).Rows(I).Item("New_Net")
        ._NTECD1 = ""
        ._NTEX1 = ds.Tables(0).Rows(I).Item("Total_Exempt_New")
        ._NTNET = ds.Tables(0).Rows(I).Item("New_Net")
        ._NTPCD1 = WrkCode
        ._PRF = ""
        ._RSNCD = ""
        ._VINNO = ""
        .AddOneRecordP()
        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          ProgBar1.Value = WrkPct
          LblMsg.Text = "Records processed: " & Counter
          SavePct = WrkPct
          Application.DoEvents()
        End If
        If .ErrMsg <> String.Empty Then
          sw.WriteLine("COEB " & .ErrMsg)
        End If
      End With

    Next
    ds = Nothing
  End Sub
  Private Sub WriteM35H(ByVal WrkFromFile As String)
    Dim MyTXREALC As TXREAL
    Dim ds As DataSet = New DataSet
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer
    Dim WrkYear As Integer
    Dim WrkSeq As Integer
    MyTOWN = New TOWN(myDBConnectGEMS.MyConn2)
    MyTXM35H = New TXM35H(myDBConnectGEMS.MyConn2)
    MyTXREAL = New TXREAL(myDBConnectGEMS.MyConn2, "TXREAL")
    MyTXREALC = New TXREAL(myDBConnectGEMS.MyConn2, "TXREALC")
    myDBConnectGEMS.DeleteRecords2(WrkFromFile, " where year>=" & cElderlyYear)
    ds = myDBConnect.RunQuery("ASSR_ELDERLY_FILE", " where gl_year>=" & cElderlyYear)
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTXM35H
        Counter = Counter + 1
        WrkListNo = ds.Tables(0).Rows(I).Item("list_no")
        WrkYear = ds.Tables(0).Rows(I).Item("gl_year")
        WrkSeq = CnvSng(ds.Tables(0).Rows(I).Item("APP_SEQUENCE"))
        .GetOneRecordP(WrkListNo, WrkYear, WrkSeq)
        ._ADOB = ConvertDate(ds.Tables(0).Rows(I).Item("APPLICANT_DOB"))
        ._AFNAME = ConvertString("AFNAME", ds.Tables(0).Rows(I).Item("APPLICANT_FIRST_NAME"), 10)
        ._AINIT = Trim(ds.Tables(0).Rows(I).Item("APPLICANT_MIDDLE_INITIAL"))
        If ds.Tables(0).Rows(I).Item("APPLICATION_ACCEPTED") = "Application Accepted" Then
          ._ALLOW = "Y"
        Else
          ._ALLOW = "N"
        End If
        ._ALNAME = ConvertString("ALNAME", ds.Tables(0).Rows(I).Item("APPLICANT_NAME"), 20)
        ._ASSN = Replace(ds.Tables(0).Rows(I).Item("APPLICANT_SSN"), "-", "")
        ._DISAB = Mid(ds.Tables(0).Rows(I).Item("TOTALLY_DISABLED"), 1, 1)
        ._DISRSN = ds.Tables(0).Rows(I).Item("REJECTION_REASON")
        ._DTASSR = ConvertDate(ds.Tables(0).Rows(I).Item("SIGNATURE_DATE"))
        ._DTRECV = ConvertDate(ds.Tables(0).Rows(I).Item("APPLICATION_RECEIVED_DATE"))
        ._DTSIGN = ConvertDate(ds.Tables(0).Rows(I).Item("APPLICANT_SIGN_DATE"))
        Select Case Trim(ds.Tables(0).Rows(I).Item("FILING_STATUS"))
          Case "Civil Union"
            ._FILING = "C"
          Case "Married"
            ._FILING = "M"
          Case "Unmarried"
            ._FILING = "U"
          Case Else
            ._FILING = "S"
        End Select
        ._FRZTAX = CnvSng(ds.Tables(0).Rows(I).Item("GROSS_FROZEN_TAX"))
        ._GROSS = CnvSng(ds.Tables(0).Rows(I).Item("APPLICANT_GROSS"))
        ._INCOME = ds.Tables(0).Rows(I).Item("TAXABLE_INCOME")
        ._INT = ds.Tables(0).Rows(I).Item("NON_TAXABLE_INTEREST")
        ._LISTNO = WrkListNo
        ._MAX = CnvSng(ds.Tables(0).Rows(I).Item("TABLE_CEILING"))
        ._MIN = CnvSng(ds.Tables(0).Rows(I).Item("MINIMUM_GRANT"))
        ._MADDR = Trim(ds.Tables(0).Rows(I).Item("MAILING_ADDRESS"))
        ._MCITY = Trim(ds.Tables(0).Rows(I).Item("MAILING_CITY"))
        ._MSTATE = ds.Tables(0).Rows(I).Item("MAILING_STATE")
        ._MZIP = CnvSng(ds.Tables(0).Rows(I).Item("MAILING_ZIPCODE"))
        ._NET = CnvSng(ds.Tables(0).Rows(I).Item("NET_ASSESSMENT"))
        ._NRSHOM = ""
        ._OTHER = ds.Tables(0).Rows(I).Item("OTHER_INCOME")
        ._OWNER = Trim(ds.Tables(0).Rows(I).Item("OTHER_PROP_NAME"))
        ._PCT = CnvSng(ds.Tables(0).Rows(I).Item("ALLOWED_TABLE_PERCENTAGE"))
        ._PGROSS = CnvSng(ds.Tables(0).Rows(I).Item("APPLICANT_GROSS"))
        ._PROPCT = CnvSng(ds.Tables(0).Rows(I).Item("OWNERSHIP_PERCENTAGE"))
        ._PADDR = Trim(ds.Tables(0).Rows(I).Item("PROPERTY_ADDRESS"))
        ._PCITY = Trim(ds.Tables(0).Rows(I).Item("PROPERTY_CITY"))
        ._PSTATE = ds.Tables(0).Rows(I).Item("PROPERTY_STATE")
        ._PZIP = CnvSng(ds.Tables(0).Rows(I).Item("PROPERTY_ZIPCODE"))
        ._PHONE = CnvSng(ds.Tables(0).Rows(I).Item("SIGNER_PHONE_NUMBER"))
        ._RELATE = Trim(ds.Tables(0).Rows(I).Item("AGENT_RELATIONSHIP"))
        ._SDOB = ConvertDate(ds.Tables(0).Rows(I).Item("SPOUSE_DOB"))
        ._SEQ = WrkSeq
        ._SFNAME = ConvertString("SFNAME", ds.Tables(0).Rows(I).Item("SPOUSE_FIRST_NAME"), 10)
        ._SINIT = Trim(ds.Tables(0).Rows(I).Item("SPOUSE_MI"))
        ._SLNAME = ConvertString("SLNAME", ds.Tables(0).Rows(I).Item("SPOUSE_NAME"), 20)
        ._SSRR = ds.Tables(0).Rows(I).Item("SOCIAL_SECURITY_INCOME")
        If Trim(ds.Tables(0).Rows(I).Item("SPOUSE_NAME")) <> "" Then
          ._SSSN = Replace(ds.Tables(0).Rows(I).Item("SPOUSE_SSN"), "-", "")
        Else
          ._SSSN = 0
        End If
        ._TAX = CnvSng(ds.Tables(0).Rows(I).Item("APPLICANT_TAX_DUE")) '+CnvSng(ds.Tables(0).Rows(I).Item("CREDIT_AMOUNT"))
        ._TAXRTN = Mid(ds.Tables(0).Rows(I).Item("FILED_TAX_RETURN"), 1, 1)
        ._XADDL = CnvSng(ds.Tables(0).Rows(I).Item("VETERAN_EXEMPTION2"))
        ._XBLIND = CnvSng(ds.Tables(0).Rows(I).Item("BLIND_EXEMPTION"))
        ._XDISAB = CnvSng(ds.Tables(0).Rows(I).Item("DISABLED_EXEMPTION"))
        ._XLOCAL = CnvSng(ds.Tables(0).Rows(I).Item("LOCAL_OPTIONS"))
        ._XVET = CnvSng(ds.Tables(0).Rows(I).Item("VETERAN_EXEMPTION1"))
        ._YEAR = WrkYear
        .AddOneRecordP()
        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          ProgBar1.Value = WrkPct
          LblMsg.Text = "Records processed: " & Counter
          SavePct = WrkPct
          Application.DoEvents()
        End If
        If .ErrMsg <> String.Empty Then
          sw.WriteLine("M35H " & .ErrMsg)
        End If
      End With
      If WrkYear = MyGLYear - 1 Then
        With MyTXREAL
          .GetOneRecordP(WrkListNo)
          If Not .RecordNotFound Then
            If MyTXM35H._ALLOW = "Y" Then
              ._FCCOD = "C"
              ._FCYR = WrkYear
              ._CPERC = CnvSng(ds.Tables(0).Rows(I).Item("ALLOWED_TABLE_PERCENTAGE")) / 100
              ._CMAX = CnvSng(ds.Tables(0).Rows(I).Item("TABLE_CEILING"))
              ._CMIN = CnvSng(ds.Tables(0).Rows(I).Item("MINIMUM_GRANT"))
              ._FTAX = CnvSng(ds.Tables(0).Rows(I).Item("CREDIT_AMOUNT"))
            Else
              ._FCCOD = ""
              ._FCYR = 0
              ._CPERC = 0
              ._CMAX = 0
              ._CMIN = 0
              ._FTAX = 0
            End If
            .UpdateOneRecordP()
          End If
        End With
        With MyTXREALC
          .GetOneRecordP(WrkListNo)
          If Not .RecordNotFound Then
            If MyTXM35H._ALLOW = "Y" Then
              ._FCCOD = "C"
              ._FCYR = WrkYear
              ._CPERC = CnvSng(ds.Tables(0).Rows(I).Item("ALLOWED_TABLE_PERCENTAGE")) / 100
              ._CMAX = CnvSng(ds.Tables(0).Rows(I).Item("TABLE_CEILING"))
              ._CMIN = CnvSng(ds.Tables(0).Rows(I).Item("MINIMUM_GRANT"))
              ._FTAX = CnvSng(ds.Tables(0).Rows(I).Item("CREDIT_AMOUNT"))
            Else
              ._FCCOD = ""
              ._FCYR = 0
              ._CPERC = 0
              ._CMAX = 0
              ._CMIN = 0
              ._FTAX = 0
            End If
            .UpdateOneRecordP()
          End If
        End With
      End If
    Next
    ds = Nothing
  End Sub
  Private Sub WriteM59A(ByVal WrkFromFile As String)
    Dim ds As DataSet = New DataSet
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer
    Dim WrkType As String
    Dim WrkYear As Integer
    MyTOWN = New TOWN(myDBConnectGEMS.MyConn2)
    MyTXM59A = New TXM59A(myDBConnectGEMS.MyConn2)
    myDBConnectGEMS.DeleteRecords2(WrkFromFile, " where year>=" & cElderlyYear)
    ds = myDBConnect.RunQuery("ADVET_APPLICATION", " where current_gl>=" & cElderlyYear)
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTXM59A
        Counter = Counter + 1
        WrkType = ds.Tables(0).Rows(I).Item("record_type")
        Select Case WrkType
          Case "R"
            WrkListNo = ds.Tables(0).Rows(I).Item("unique_id")
          Case Else
            WrkListNo = ds.Tables(0).Rows(I).Item("list_no")
        End Select
        WrkYear = ds.Tables(0).Rows(I).Item("current_gl")
        .GetOneRecordP(WrkListNo, WrkType, WrkYear)
        ._AFNAME = ds.Tables(0).Rows(I).Item("APPLICANT_FIRST")
        ._AINIT = ds.Tables(0).Rows(I).Item("APPLICANT_INITIAL")
        If ds.Tables(0).Rows(I).Item("ACCEPTED") = "A" Then
          ._ALLOW = "Y"
        Else
          ._ALLOW = "N"
        End If
        ._ALNAME = ds.Tables(0).Rows(I).Item("APPLICANT_LAST")
        ._ASSN = CnvSng(ds.Tables(0).Rows(I).Item("APPLICANT_SSN"))
        ._CITY = ds.Tables(0).Rows(I).Item("PL_CITY")
        ._DISRSN = ds.Tables(0).Rows(I).Item("DISALLOW_REASON")
        ._DTASSR = ConvertDate(ds.Tables(0).Rows(I).Item("ASSR_SIGN_DATE"))
        ._DTSIGN = ConvertDate(ds.Tables(0).Rows(I).Item("APPLICANT_SIGN_DATE"))
        ._FILING = ds.Tables(0).Rows(I).Item("MARITAL_STATUS")
        ._INCOME = ds.Tables(0).Rows(I).Item("INC_GROSS")
        ._INT = ds.Tables(0).Rows(I).Item("INC_INTEREST")
        ._LISTNO = WrkListNo
        ._LOC = ds.Tables(0).Rows(I).Item("PL_STREET")
        '._LOCNO = ds.Tables(0).Rows(I).Item("")
        ._MADDR = ds.Tables(0).Rows(I).Item("STREET")
        ._MCITY = ds.Tables(0).Rows(I).Item("CITY")
        ._MZIP = CnvSng(ds.Tables(0).Rows(I).Item("PL_ZIP1"))
        ._OTHER = ds.Tables(0).Rows(I).Item("INC_OTHER")
        ._PHONE = CnvSng(ds.Tables(0).Rows(I).Item("PHONE"))
        If ds.Tables(0).Rows(I).Item("DISABILITY_RATING") = 100 Then
          ._RATING = "Y"
        Else
          ._RATING = "N"
        End If
        ._SFNAME = ds.Tables(0).Rows(I).Item("SPOUSE_FIRST")
        ._SINIT = ds.Tables(0).Rows(I).Item("SPOUSE_INITIAL")
        ._SLNAME = ds.Tables(0).Rows(I).Item("SPOUSE_LAST")
        ._SSRR = ds.Tables(0).Rows(I).Item("INC_SOCSEC")
        ._SSSN = CnvSng(ds.Tables(0).Rows(I).Item("SPOUSE_SSN"))
        ._STATE = ds.Tables(0).Rows(I).Item("STATE")
        ._TYPE = WrkType
        ._XADDL = ds.Tables(0).Rows(I).Item("EX_USED_AMT")
        ._XFULL = ds.Tables(0).Rows(I).Item("EX_FULL_AMT")
        ._XFULLO = 0 'ds.Tables(0).Rows(I).Item("")
        ._XLOCAL = 0 ' ds.Tables(0).Rows(I).Item("")
        ._XVET = ds.Tables(0).Rows(I).Item("VET_EX_AMT")
        ._YEAR = WrkYear
        ._ZIP = ds.Tables(0).Rows(I).Item("ZIP1")
        .AddOneRecordP()
        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          ProgBar1.Value = WrkPct
          LblMsg.Text = "Records processed: " & Counter
          SavePct = WrkPct
          Application.DoEvents()
        End If
        If .ErrMsg <> String.Empty Then
          sw.WriteLine("M59A " & .ErrMsg)
        End If
      End With
    Next
    ds = Nothing
  End Sub
  Private Sub WriteVCLS()
    Dim mystream As System.IO.Stream
    Dim sArray As String()
    Dim WrkStr As String
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal

    myDBConnectGEMS.DeleteRecords2("TXVCLS")
    mystream = System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream("CnvQDS.txvcls.csv")

    Using reader As New IO.StreamReader(mystream)
      ' Read the contents in MsgBox for example
ReadNext:
      If reader.EndOfStream Then Exit Sub
      WrkStr = reader.ReadLine
      sArray = Parse(WrkStr, ",")
      With MyTXVCLS
        Counter = Counter + 1
        .GetOneRecordP(sArray(0))
        ._CLASS = CnvSng(sArray(1))
        ._DESC = sArray(0)
        .AddOneRecordP()
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        SavePct = WrkPct
        Application.DoEvents()
      End If
      GoTo ReadNext
    End Using
  End Sub
  Private Sub WriteVEH_VCUS()
    Dim ds As DataSet = New DataSet
    Dim WrkVehID As Integer
    Dim WrkPName As String
    Dim WrkSName As String
    Dim WrkLname As String
    Dim WrkValue As Integer
    Dim WrkTrVal As Integer
    Dim WrkLnVal As Integer
    Dim WrkClass As Integer
    Dim WrkNewValue As Integer
    Dim I As Integer
    Dim J As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal

    MyTXVEH = New TXVEH(myDBConnectGEMS.MyConn2)
    MyTXVCUS = New TXVCUS(myDBConnectGEMS.MyConn2)
    MyTXMVD = New TXMVD(myDBConnectGEMS.MyConn2, "TXMVD")
    MyTXSUPP = New TXSUPP(myDBConnectGEMS.MyConn2, "TXSUPP")
    myDBConnectGEMS.DeleteRecords2("TXVEH")
    myDBConnectGEMS.DeleteRecords2("TXVCUS")
    ds = myDBConnect.RunQuery("MOTOR_CIVLS", "")
    For I = 0 To ds.Tables(0).Rows.Count - 1
      Counter = Counter + 1
      WrkPName = ""
      If Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerOrganizationName")) <> String.Empty Then
        WrkPName = Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerOrganizationName"))
      Else
        WrkPName = Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerLastName"))
        If Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerFirstName")) <> String.Empty Then
          WrkPName = WrkPName & " " & Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerFirstName"))
        End If
        If Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerMiddleName")) <> String.Empty Then
          WrkPName = WrkPName & " " & Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerMiddleName"))
        End If
        If Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerSuffix")) <> String.Empty Then
          WrkPName = WrkPName & " " & Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerSuffix"))
        End If
      End If

      WrkSName = ""
      If Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerOrganizationName")) <> String.Empty Then
        WrkSName = Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerOrganizationName"))
      Else
        WrkSName = Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerLastName"))
        If Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerFirstName")) <> String.Empty Then
          WrkSName = WrkSName & " " & Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerFirstName"))
        End If
        If Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerMiddleName")) <> String.Empty Then
          WrkSName = WrkSName & " " & Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerMiddleName"))
        End If
        If Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerSuffix")) <> String.Empty Then
          WrkSName = WrkSName & " " & Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerSuffix"))
        End If
      End If
      WrkClass = GetTXVCLSCode(ds.Tables(0).Rows(I).Item("PlateClassName"))

      'Calculate Assessment Values
      WrkValue = CnvSng(ds.Tables(0).Rows(I).Item("AdjustedRetailValue")) * cAssPct
      WrkTrVal = CnvSng(ds.Tables(0).Rows(I).Item("AdjustedTradeInValue")) * cAssPct
      WrkLnVal = CnvSng(ds.Tables(0).Rows(I).Item("SalesPriceAmount")) * cAssPct
      If cMinValue > WrkValue And WrkValue > 0 Then
        WrkNewValue = cMinValue
      Else
        WrkNewValue = WrkValue
      End If
      'Class 25 = Classic vehicle
      If WrkClass = 25 Then
        WrkNewValue = cClassicVehicle
      End If
      'Round down to nearest 10 dollars
      J = WrkNewValue Mod 10
      If J <> 0 Then
        WrkNewValue = WrkNewValue - J
      End If

      WrkFile = "TXVEH"
      With MyTXVEH
        WrkVehID = CnvSng(ds.Tables(0).Rows(I).Item("VehicleID"))
        If WrkVehID > 0 Then
          .GetOneRecordP(WrkVehID)
          ._BODY = ConvertString("Body", ds.Tables(0).Rows(I).Item("BodyStyle"), 30)
          If Trim(ds.Tables(0).Rows(I).Item("FileCreationDate")) <> "" Then
            ._CHDATE = SetDBDate(ds.Tables(0).Rows(I).Item("FileCreationDate"))
          Else
            ._CHDATE = 0
          End If
          ._CLASS = WrkClass
          ._CLASSD = ds.Tables(0).Rows(I).Item("PlateClassName")
          If CnvSng(ds.Tables(0).Rows(I).Item("NumberOfCylinders")) < 10 Then
            ._CYLAX = CnvSng(ds.Tables(0).Rows(I).Item("NumberOfCylinders"))
          Else
            ._CYLAX = 0
          End If
          ._DADD1 = ConvertString("DAdd1", ds.Tables(0).Rows(I).Item("DomiciledAddressLine1"), 35)
          ._DADD2 = ConvertString("DAdd2", ds.Tables(0).Rows(I).Item("DomiciledAddressLine2"), 35)
          ._DCITY = ConvertString("DCity", ds.Tables(0).Rows(I).Item("DomiciledAddressCity"), 25)
          ._DSTATE = ds.Tables(0).Rows(I).Item("DomiciledAddressStateCode")
          ._DZIPA = ds.Tables(0).Rows(I).Item("DomiciledAddressZip")
          ._ENDDT = SetDBDate(ds.Tables(0).Rows(I).Item("RegistrationEndDate"))
          ._GWT = CnvSng(ds.Tables(0).Rows(I).Item("GVWR"))
          WrkLname = String.Empty
          If ds.Tables(0).Rows(I).Item("LesseeOrganizationName") <> String.Empty Then
            ._LBUS = "Y"
            WrkLname = ds.Tables(0).Rows(I).Item("LesseeOrganizationName")
          Else
            ._LBUS = "N"
            WrkLname = ds.Tables(0).Rows(I).Item("LesseeLastName")
            If ds.Tables(0).Rows(I).Item("LesseeFirstName") <> String.Empty Then
              WrkLname = WrkLname & " " & ds.Tables(0).Rows(I).Item("LesseeFirstName")
            End If
            If ds.Tables(0).Rows(I).Item("LesseeMiddleName") <> String.Empty Then
              WrkLname = WrkLname & " " & ds.Tables(0).Rows(I).Item("LesseeMiddleName")
            End If
          End If
          If WrkLname <> String.Empty Then
            ._LEASE = "Y"
          Else
            ._LEASE = ""
            ._LBUS = ""
          End If
          ._LNAME = ConvertString("LName", WrkLname, 35)
          ._LCUST = CnvSng(ds.Tables(0).Rows(I).Item("LesseeVestedPartyID"))
          ._LADD1 = ConvertString("LAdd1", ds.Tables(0).Rows(I).Item("LesseeResidencyAddressLine1"), 35)
          ._LADD2 = ConvertString("LAdd2", ds.Tables(0).Rows(I).Item("LesseeResidencyAddressLine2"), 35)
          ._LCITY = ConvertString("LCity", ds.Tables(0).Rows(I).Item("LesseeResidencyCity"), 35)
          ._LSTATE = ds.Tables(0).Rows(I).Item("LesseeResidencyState")
          ._LZIPA = FormatZip(ds.Tables(0).Rows(I).Item("LesseeResidencyZip"))
          ._LNVAL = WrkLnVal
          ._LWT = CnvSng(ds.Tables(0).Rows(I).Item("UnladenWeight"))
          ._MSRP = CnvSng(ds.Tables(0).Rows(I).Item("MSRP"))
          ._NADA = ds.Tables(0).Rows(I).Item("NADAReturnCodes")
          ._ORIG = WrkValue
          ._PCUST = CnvSng(ds.Tables(0).Rows(I).Item("PrimaryOwnerCustomerID"))
          ._REGID = CnvSng(ds.Tables(0).Rows(I).Item("VehicleRegistrationID"))
          ._REGNO = ds.Tables(0).Rows(I).Item("PlateNumber")
          If ds.Tables(0).Rows(I).Item("FineIndicator") Then
            ._RGLATE = "Y"
          Else
            ._RGLATE = ""
          End If
          ._SCUST = CnvSng(ds.Tables(0).Rows(I).Item("SecondaryOwnerCustomerID"))
          ._SEAT = CnvSng(ds.Tables(0).Rows(I).Item("NumberOfSeats"))
          ._STRDT = SetDBDate(ds.Tables(0).Rows(I).Item("RegistrationStartDate"))
          ._TRVAL = WrkTrVal
          ._VINNO = ConvertString("VIN", ds.Tables(0).Rows(I).Item("VIN"), 17)
          ._VMAKE = ConvertString("Make", ds.Tables(0).Rows(I).Item("Make"), 15)
          ._VMODEL = ConvertString("Model", ds.Tables(0).Rows(I).Item("Model"), 15)
          ._VPCLR = ds.Tables(0).Rows(I).Item("PrimaryColor")
          ._VSCLR = ds.Tables(0).Rows(I).Item("SecondaryColor")
          ._YEAR = CnvSng(ds.Tables(0).Rows(I).Item("Year"))
          If .RecordNotFound Then
            ._VEHID = WrkVehID
            .AddOneRecordP()
          Else
            .UpdateOneRecordP()
          End If
        End If
      End With

      If MyTXVEH._PCUST > 0 Then
        WrkFile = "TXVCUS"
        With MyTXVCUS
          .GetOneRecordP(MyTXVEH._PCUST)
          ._ADD1 = ConvertString("Add1", ds.Tables(0).Rows(I).Item("PrimaryOwnerMailingAddressLine1"), 35)
          ._ADD2 = ConvertString("Add2", ds.Tables(0).Rows(I).Item("PrimaryOwnerMailingAddressLine2"), 35)
          ._CHDATE = MyTXVEH._CHDATE
          ._CITY = ConvertString("City", ds.Tables(0).Rows(I).Item("PrimaryOwnerMailingCity"), 25)
          ._CONFID = ds.Tables(0).Rows(I).Item("PrimaryOwnerConfidential")
          If Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerDOB")) <> "" Then
            ._DOB = SetDBDate(ds.Tables(0).Rows(I).Item("PrimaryOwnerDOB"))
          Else
            ._DOB = 0
          End If
          If Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerOrganizationName")) <> String.Empty Then
            ._BUS = "Y"
          Else
            ._BUS = "N"
          End If
          ._NAME = ConvertString("PName", WrkPName, 35)
          ._RADD1 = ConvertString("Radd1", ds.Tables(0).Rows(I).Item("PrimaryOwnerResidencyAddressLine1"), 35)
          ._RADD2 = ConvertString("Radd2", ds.Tables(0).Rows(I).Item("PrimaryOwnerResidencyAddressLine2"), 35)
          ._RCITY = ConvertString("Rcity", ds.Tables(0).Rows(I).Item("PrimaryOwnerResidencyCity"), 35)
          ._RSTATE = ds.Tables(0).Rows(I).Item("PrimaryOwnerResidencyState")
          ._RZIPA = FormatZip(ds.Tables(0).Rows(I).Item("PrimaryOwnerResidencyZip"))
          ._SEX = Mid(ds.Tables(0).Rows(I).Item("PrimaryOwnerGender"), 1, 1)
          ._STATE = ds.Tables(0).Rows(I).Item("PrimaryOwnerMailingState")
          ._ZIPA = FormatZip(ds.Tables(0).Rows(I).Item("PrimaryOwnerMailingZip"))
          If .RecordNotFound Then
            ._CUSTID = MyTXVEH._PCUST
            .AddOneRecordP()
          Else
            .UpdateOneRecordP()
          End If
        End With
      End If

      With MyTXMVD
        .GetVehID(MyTXVEH._VEHID)
        If Not .RecordNotFound Then
          If CnvSng(ds.Tables(0).Rows(I).Item("NumberOfCylinders")) <= 9 Then
            ._CYLAX = CnvSng(ds.Tables(0).Rows(I).Item("NumberOfCylinders"))
          Else
            ._CYLAX = 0
          End If
          ._PCLR = CnvColorAbbr(ds.Tables(0).Rows(I).Item("PrimaryColor"))
          ._SCLR = CnvColorAbbr(ds.Tables(0).Rows(I).Item("SecondaryColor"))
          .UpdateOneRecordP()
        End If
      End With

      With MyTXSUPP
        .GetVehID(MyTXVEH._VEHID)
        If Not .RecordNotFound Then
          If CnvSng(ds.Tables(0).Rows(I).Item("NumberOfCylinders")) <= 9 Then
            ._CYLAX = CnvSng(ds.Tables(0).Rows(I).Item("NumberOfCylinders"))
          Else
            ._CYLAX = 0
          End If
          ._PCLR = CnvColorAbbr(ds.Tables(0).Rows(I).Item("PrimaryColor"))
          ._SCLR = CnvColorAbbr(ds.Tables(0).Rows(I).Item("SecondaryColor"))
          .UpdateOneRecordP()
        End If
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next
    ds = Nothing
  End Sub
  Private Sub WriteUTCUST()
    Dim ds As DataSet = New DataSet
    Dim WrkAcct As Integer
    Dim I As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    MyUTCUST = New UTCUST(myDBConnectGEMS.MyConn2)
    myDBConnectGEMS.DeleteRecords2("UTCUST")
    ds = myDBConnect.RunQuery("MASTER_SEWER", "")
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyUTCUST
        Counter = Counter + 1
        WrkAcct = ds.Tables(0).Rows(I).Item("Acct_NO")
        .GetOneRecordP(WrkAcct)
        If .RecordNotFound Then
          ._CUACCT = WrkAcct
          ._CUNAM1 = ConvertString("NAM1", ds.Tables(0).Rows(I).Item("Txpr_Name"), 35)
          ._CUNAM2 = ConvertString("NAM2", ds.Tables(0).Rows(I).Item("Co_Name"), 35)
          ._CUADD1 = ConvertString("ADD1", ds.Tables(0).Rows(I).Item("Addr"), 35)
          ._CUADD2 = ConvertString("ADD2", ds.Tables(0).Rows(I).Item("Addr2"), 35)
          ._CUCITY = ConvertString("CITY", ds.Tables(0).Rows(I).Item("CITY"), 25)
          ._CUST = ds.Tables(0).Rows(I).Item("State")
          If CnvSng(ds.Tables(0).Rows(I).Item("ZIP2")) > 0 Then
            ._CUZIP = ds.Tables(0).Rows(I).Item("ZIP1") & "-" & ds.Tables(0).Rows(I).Item("ZIP2")
          Else
            ._CUZIP = ds.Tables(0).Rows(I).Item("ZIP1")
          End If
          ._CUMAD1 = ""
          ._CUMAD2 = ""
          ._CUMCTY = ""
          ._CUMST = ""
          ._CUMZIP = ""
          If Mid(ds.Tables(0).Rows(I).Item("Phone"), 1, 2) <> "(_" Then
            ._CUTELNO = ConvertString("Telno", ds.Tables(0).Rows(I).Item("Phone"), 15)
          Else
            ._CUTELNO = ""
          End If
          ._CUDST = 1
          ._CUPHAS = 1
          If Trim(ds.Tables(0).Rows(I).Item("Plan_Code")) = "8" Then
            ._CUDST = 8
            ._CUPHAS = 8
          End If
          ._CUADDX = ""
          ._CUTIE = 0
          ._CUMAP = ""
          ._CUVOLM = Trim(ds.Tables(0).Rows(I).Item("Vol"))
          ._CUPAGE = Trim(ds.Tables(0).Rows(I).Item("Page"))
          ._CUZONE = ""
          ._CUPCAT = ""
          ._CUXREF = ""
          ._CUMSIZ = ""
          ._CUUPMT = ""
          ._CUUNIT = 0
          ._CUEDU = 1
          ._CUSFIX = 0
          ._CUXTRA = 0
          ._CUWFIX = 0
          ._CUSCHR = 0
          ._CUAPMT = 0
          ._CUAUNT = 0
          ._CUPVAL = 0
          ._CUFOOT = 0
          ._CUACRE = 0
          ._CYC = ""
          ._OID = ""
          ._CUSERN = ""
          ._CUROUT = ds.Tables(0).Rows(I).Item("Read_Route")
          ._CUMETN = ""
          ._CUMETP = ""
          ._CUREGN = ""
          ._CULOCNO = JustifyRight(ds.Tables(0).Rows(I).Item("Prop_no"), 7)
          ._CULOC = ConvertString("Loc", ds.Tables(0).Rows(I).Item("Prop_name"), 25)
          ._CUCNTNO = ""
          ._CUAPLNO = ""
          ._CUFUND = 0
          ._CUSECT = ""
          ._CUSDES = ConvertString("Loc", ds.Tables(0).Rows(I).Item("buildingtype"), 35)
          .AddOneRecordP()
          If .ErrMsg <> String.Empty Then
            sw.WriteLine("UTCUST " & WrkAcct & " " & .ErrMsg)
          End If
        End If
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next
    ds = Nothing
  End Sub
  Private Sub WriteUTCUSTAS()
    Dim WrkAcct As Integer
    Dim WrkType As String
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    MyUTCUSTAS = New UTCUSTAS(myDBConnectGEMS.MyConn2)
    MyUTCUST = New UTCUST(myDBConnectGEMS.MyConn2)
    'myDBConnectGEMS.DeleteRecords2("UTCUSTAS")
    myDBConnect.OpenQry("TAXMAST", " where yr=2022 and orig_ass>0 and plan_code='" & cAssmntCode & "'")

ReadNext:
    myDBConnect.ReadQry()
    If Not myDBConnect.IsEOF Then
      With MyUTCUSTAS
        WrkAcct = myDBConnect.objReader.Item("bill_num")
        WrkType = GetTaxType(MyTOWN._TOWNBR, myDBConnect.objReader.Item("bill_type"))
        Counter = Counter + 1
        .GetOneRecordP(WrkAcct, WrkType)
        ._CAADJ = 0
        ._CADEF = 0
        ._CADEP = 0
        If myDBConnect.objReader.Item("unpaid_bal") >= 0 Then
          ._CAAMT = myDBConnect.objReader.Item("orig_ass") - myDBConnect.objReader.Item("unpaid_bal")
        Else
          ._CAAMT = myDBConnect.objReader.Item("orig_ass")
        End If
        ._CAOVR = 0
        ._CALAT = 0
        ._CAUNIF = 0
        If .RecordNotFound Then
          ._CAACCT = WrkAcct
          ._CATYPE = WrkType
          ._CAPNO = 1
          .AddOneRecordP()
          If .ErrMsg <> String.Empty Then
            sw.WriteLine("UTCUSTAS " & .ErrMsg)
          End If
        Else
          .UpdateOneRecordP()
        End If
      End With

      With MyUTCUST
        .GetOneRecordP(WrkAcct)
        If Not .RecordNotFound Then
          ._CUAUNT = 1
          .UpdateOneRecordP()
        End If
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
        GoTo ReadNext
      End If
    End If
  End Sub
  Private Sub WriteUTCUSTRT()
    Dim ds As DataSet = New DataSet
    Dim ds3 As DataSet = New DataSet
    Dim WrkAcct As Integer
    Dim WrkType As String
    Dim WrkCode As String
    Dim I As Integer
    Dim J As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    MyUTCUST = New UTCUST(myDBConnectGEMS.MyConn2)
    MyUTCUSTRT = New UTCUSTRT(myDBConnectGEMS.MyConn2)
    myDBConnectGEMS.DeleteRecords2("UTCUSTRT", " where crtype<>'A'")
    ds = myDBConnect.RunQuery("MASTER_USAGE", " order by acct_no, Wt_Id")
    For I = 0 To ds.Tables(0).Rows.Count - 1
      WrkAcct = ds.Tables(0).Rows(I).Item("Acct_NO")
      WrkType = GetTaxType(MyTOWN._TOWNBR, CnvSng(ds.Tables(0).Rows(I).Item("Service_Acct_Type")))
      If WrkType = "" Then
        WrkType = GetTaxType(MyTOWN._TOWNBR, CnvSng(ds.Tables(0).Rows(I).Item("Acct_Type")))
      End If
      WrkCode = GetSewerCode(WrkType, ds.Tables(0).Rows(I).Item("Wt_id"))
      ds3 = myDBConnect3.RunQuery("MASTER_SEWER", "where acct_no=" & WrkAcct & " and acct_type=" &
      ds.Tables(0).Rows(I).Item("acct_type"))
      If ds3.Tables(0).Rows.Count > 0 Then
        If Trim(ds3.Tables(0).Rows(0).Item("plan_code")) = cRateOmit Then
          Continue For
        End If
      End If
      With MyUTCUST
        Counter = Counter + 1
        Select Case WrkCode
          Case "*"
            'Change meter size for Grinder Pump
            WrkCode = ""
            .GetOneRecordP(WrkAcct)
            Select Case ._CUMSIZ
              Case "1"
                ._CUMSIZ = "A"
              Case "2"
                ._CUMSIZ = "B"
              Case "3"
                ._CUMSIZ = "C"
              Case "4"
                ._CUMSIZ = "D"
              Case "5"
                ._CUMSIZ = "E"
              Case "6"
                ._CUMSIZ = "F"
              Case "7"
                ._CUMSIZ = "G"
              Case Else
            End Select
            WrkCode = ""
            .UpdateOneRecordP()
          Case "N"
            ._CUMSIZ = "L"
            .UpdateOneRecordP()
          Case Else
            If WrkCode <> "" Then
              .GetOneRecordP(WrkAcct)
              If Not .RecordNotFound Then
                If WrkType = "U" Then
                  ._CUSFIX = ds.Tables(0).Rows(I).Item("occ")
                  .UpdateOneRecordP()
                End If
                If WrkType = "W" Then
                  ._CUWFIX = ds.Tables(0).Rows(I).Item("occ")
                  .UpdateOneRecordP()
                End If
              End If
            End If
        End Select
      End With

      With MyUTCUSTRT
        If WrkCode <> "" Then
          .GetOneRecordP(WrkAcct, WrkType)
          ._CRCODE = WrkCode
          If .RecordNotFound Then
            ._CRACCT = WrkAcct
            ._CRTYPE = WrkType
            .AddOneRecordP()
            If .ErrMsg <> String.Empty Then
              sw.WriteLine("UTCUSTRT " & WrkType & " " & .ErrMsg)
            End If
          End If
        End If
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next
    ds = Nothing
  End Sub
  Private Sub WriteUTCUSTMT()
    Dim WrkAcct As Integer
    Dim WrkDate As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    MyUTCUSTMT = New UTCUSTMT(myDBConnectGEMS.MyConn2)
    MyUTCUST = New UTCUST(myDBConnectGEMS.MyConn2)
    myDBConnectGEMS.DeleteRecords2("UTCUSTMT")
    myDBConnect.OpenQry("MASTER_READING", " where wt_id in ('" & cReadCode & "','" & cReadCode2 & "','" & cReadCode3 &
     "') order by bill_num, record_date")

ReadNext:
    myDBConnect.ReadQry()
    If Not myDBConnect.IsEOF Then
      With MyUTCUSTMT
        WrkAcct = myDBConnect.objReader.Item("bill_num")
        WrkDate = ConvertDate(myDBConnect.objReader.Item("record_date"))
        Counter = Counter + 1
        .GetOneRecordP(WrkAcct, "", WrkDate)
        ._CMACCT = WrkAcct
        ._CMDATE = WrkDate
        ._CMREAD = CnvSng(myDBConnect.objReader.Item("curr_reading"))
        ._CMRESN = ""
        ._CMTYPE = ""
        ._CMUSE = CnvSng(myDBConnect.objReader.Item("curr_reading")) - CnvSng(myDBConnect.objReader.Item("prior_reading"))
        If .RecordNotFound Then
          .AddOneRecordP()
          If .ErrMsg <> String.Empty Then
            sw.WriteLine("UTCUSTMT " & .ErrMsg)
          End If
        End If
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed:  " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
        GoTo ReadNext
      End If
    End If
  End Sub
  Private Sub WriteUTCUST2()
    Dim WrkAcct As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    MyUTCUST = New UTCUST(myDBConnectGEMS.MyConn2)
    myDBConnect.OpenQry("METER_SERVICE", " where serv_status='A'")

ReadNext:
    myDBConnect.ReadQry()
    If Not myDBConnect.IsEOF Then
      With MyUTCUST
        WrkAcct = myDBConnect.objReader.Item("acct_no")
        Counter = Counter + 1
        .GetOneRecordP(WrkAcct)
        If Trim(._CUMSIZ) = "" And Trim(myDBConnect.objReader.Item("Meter_Size")) <> "" Then
          ._CUMSIZ = GetMeterSize(Trim(myDBConnect.objReader.Item("Meter_Size")), myDBConnect.objReader.Item("meter_multiplyer"))
          ._CUMETN = Trim(myDBConnect.objReader.Item("Meter"))
          ._CULAT = CnvSng(myDBConnect.objReader.Item("YCoordinate"))
          ._CULONG = CnvSng(myDBConnect.objReader.Item("XCoordinate"))
          If Not .RecordNotFound Then
            .UpdateOneRecordP()
            If .ErrMsg <> String.Empty Then
              sw.WriteLine("UTCUST2 " & .ErrMsg)
            End If
          End If
        End If
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
        GoTo ReadNext
      End If
    End If
  End Sub
  Private Sub WriteTAXCOM()
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkMsgID As Integer
    Dim WrkAcct As Integer
    Dim WrkLen As Integer
    Dim WrkRecs As Integer
    Dim WrkPos As Integer
    Dim WrkStr As String
    Dim I As Integer
    Dim J As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    MyUTCUST = New UTCUST(myDBConnectGEMS.MyConn2)
    MyTAXCOM = New TAXCOM(myDBConnectGEMS.MyConn2)
    myDBConnectGEMS.DeleteRecords2("TAXCOM", " Where year=0")
    ds = myDBConnect.RunQuery("MASTER_SEWER", "")
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTAXCOM
        Counter = Counter + 1
        WrkAcct = ds.Tables(0).Rows(I).Item("Acct_No")
        WrkMsgID = ds.Tables(0).Rows(I).Item("MSG_ID")
        ds2 = myDBConnect.RunQuery("MASTER_MESSAGE", "Where MSG_ID=" & WrkMsgID)
        If ds2.Tables(0).Rows.Count > 0 Then
          WrkStr = Trim(ds2.Tables(0).Rows(0).Item("Message"))
          WrkLen = Len(WrkStr)
          WrkRecs = Math.Ceiling(WrkLen / 60)
          For J = 0 To WrkRecs - 1
            WrkPos = (J * 60) + 1
            With MyTAXCOM
              .GetOneRecordP(WrkAcct, "U", 0, J + 1)
              If Not .RecordNotFound Then
                Exit For
              End If
              ._CMNT = Mid(WrkStr, WrkPos, 60)
              ._CSEQ = J + 1
              ._LISTNO = WrkAcct
              ._TYPE = "U"
              ._YEAR = 0
              .AddOneRecordP()
              If .ErrMsg <> String.Empty Then
                sw.WriteLine("TAXCOM " & WrkAcct & " " & WrkMsgID & " " & .ErrMsg)
              End If
            End With
          Next
        End If
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next
    ds = Nothing
  End Sub
  Private Sub WriteTAXCOM2()
    Dim ds As DataSet = New DataSet
    Dim WrkAcct As Integer
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkLen As Integer
    Dim WrkRecs As Integer
    Dim WrkPos As Integer
    Dim WrkStr As String
    Dim I As Integer
    Dim J As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    MyTAXCOM = New TAXCOM(myDBConnectGEMS.MyConn2)
    myDBConnectGEMS.DeleteRecords2("TAXCOM", " Where year>0")
    ds = myDBConnect.RunQuery("TAXMSG", "")
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTAXCOM
        Counter = Counter + 1
        WrkAcct = ds.Tables(0).Rows(I).Item("bill_num")
        WrkType = GetTaxType(MyTOWN._TOWNBR, CnvSng(ds.Tables(0).Rows(I).Item("bill_type")))
        WrkYear = ds.Tables(0).Rows(I).Item("yr")
        WrkStr = Trim(ds.Tables(0).Rows(I).Item("msg"))
        If WrkStr = "" Then
          WrkStr = Trim(ds.Tables(0).Rows(I).Item("addmsg"))
        Else
          WrkStr = WrkStr & " " & Trim(ds.Tables(0).Rows(I).Item("addmsg"))
        End If
        WrkLen = Len(WrkStr)
        WrkRecs = Math.Ceiling(WrkLen / 60)
        For J = 0 To WrkRecs - 1
          WrkPos = (J * 60) + 1
          With MyTAXCOM
            .GetOneRecordP(WrkAcct, WrkType, WrkYear, J)
            If .RecordNotFound Then
              ._CMNT = Mid(WrkStr, WrkPos, 60)
              ._CSEQ = J
              ._LISTNO = WrkAcct
              ._TYPE = WrkType
              ._YEAR = WrkYear
              .AddOneRecordP()
              If .ErrMsg <> String.Empty Then
                sw.WriteLine("TAXCOM2 " & WrkAcct & WrkType & WrkYear & " " & .ErrMsg)
              End If
            End If
          End With
        Next
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next
    ds = Nothing
  End Sub
  Private Sub UpdateCustID()
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal

    MyTXINV = New TXINV(myDBConnectGEMS.MyConn2)
    myDBConnect.OpenQry("MOTOR_CIVLS", "")
    WrkFile = "TXINV"

ReadNext:
    myDBConnect.ReadQry()
    If Not myDBConnect.IsEOF Then
      With MyTXINV
        Counter = Counter + 1
        WrkListNo = myDBConnect.objReader.Item("list_no")
        WrkType = myDBConnect.objReader.Item("record_type")
        WrkYear = myDBConnect.objReader.Item("record_year")
        .GetOneRecordP(WrkListNo, WrkYear, WrkType)
        If Not .RecordNotFound Then
          ._OID = CnvSng(myDBConnect.objReader.Item("vehicleid"))
          ._SSNo = CnvSng(myDBConnect.objReader.Item("primaryownercustomerid"))
          ._SS2 = CnvSng(myDBConnect.objReader.Item("secondaryownercustomerid"))
          .UpdateOneRecordP()
        End If
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
        GoTo ReadNext
      End If
    End If
  End Sub
  Private Function ConvertString(ByVal WrkField As String, ByVal WrkStr As String, ByVal WrkLen As Integer) As String

    Dim ReturnStr As String
    WrkStr = Trim(WrkStr)
    WrkStr = Replace(WrkStr, "'", "")
    ReturnStr = Mid(WrkStr, 1, WrkLen)
    If Len(WrkStr) > WrkLen Then
      sw.WriteLine(WrkFile & "," & WrkListNo & "," & WrkField & "," & WrkStr & "," & ReturnStr)
    End If

    Return Trim(ReturnStr)
  End Function
  Private Function ConvertDate(ByVal DateIn As Date) As Integer

    Dim ReturnDate
    If DateIn = #1/1/1900# Then
      ReturnDate = 0
    Else
      ReturnDate = SetDBDate(DateIn)
    End If

    Return ReturnDate
  End Function
  Private Function ConvertDateMDY(ByVal DateIn As Date) As Integer

    Dim ReturnDate
    If DateIn = #1/1/1900# Then
      ReturnDate = 0
    Else
      ReturnDate = SetDBDateMDY(DateIn)
    End If

    Return ReturnDate
  End Function
  Private Function FormatZip(ByVal WrkZip As String) As String
    Dim Pos As Integer
    Dim WrkZipA As String

    If Trim(WrkZip) <> "" Then
      If Len(WrkZip) > 5 Then
        Pos = InStr(WrkZip, "-")
        If Pos = 0 Then
          WrkZipA = Mid(WrkZip, 1, 5) & "-" & Mid(WrkZip, 6, 4)
        Else
          WrkZipA = WrkZip
        End If
      Else
        WrkZipA = WrkZip
      End If
    Else
      WrkZipA = ""
    End If

    Return WrkZipA
  End Function
  Public Function GetTXVCLSCode(ByVal Desc As String) As Integer

    If Desc = "" Then
      Return 0
    End If

    MyTXVCLS.GetOneRecordP(Desc)
    If Not MyTXVCLS.RecordNotFound Then
      GetTXVCLSCode = MyTXVCLS._CLASS
    Else
      GetTXVCLSCode = 0
    End If
    Return GetTXVCLSCode

  End Function
  Private Function CnvColorAbbr(ByVal WrkColor As String) As String

    Dim WrkAbbr As String

    WrkAbbr = ""
    Select Case Trim(WrkColor)
      Case "Beige"
        WrkAbbr = "BGE"
      Case "Black"
        WrkAbbr = "BLK"
      Case "Blue"
        WrkAbbr = "BLU"
      Case "Brown"
        WrkAbbr = "BRN"
      Case "Gold"
        WrkAbbr = "GLD"
      Case "Gray"
        WrkAbbr = "GRY"
      Case "Green"
        WrkAbbr = "GRN"
      Case "Orange"
        WrkAbbr = "ORN"
      Case "Purple"
        WrkAbbr = "PUR"
      Case "Red"
        WrkAbbr = "RED"
      Case "Silver"
        WrkAbbr = "SLV"
      Case "Tan"
        WrkAbbr = "TAN"
      Case "Unk"
        WrkAbbr = ""
      Case "White"
        WrkAbbr = "WHT"
      Case "Yellow"
        WrkAbbr = "YEL"
      Case Else
        WrkAbbr = UCase(Mid(WrkColor, 1, 3))
    End Select

    Return WrkAbbr
  End Function
  Private Function GetSaleCode(ByVal WrkTYpe As String, ByVal WrkPct As Decimal)
    Dim WrkCode As String

    Select Case WrkTYpe
      Case "M"
        Select Case WrkPct
          Case 1
            WrkCode = "L"
          Case 0.917
            WrkCode = "A"
          Case 0.833
            WrkCode = "B"
          Case 0.75
            WrkCode = "C"
          Case 0.667
            WrkCode = "D"
          Case 0.583
            WrkCode = "E"
          Case 0.5
            WrkCode = "F"
          Case 0.417
            WrkCode = "G"
          Case 0.333
            WrkCode = "H"
          Case 0.25
            WrkCode = "I"
          Case 0.167
            WrkCode = "J"
          Case 0.083
            WrkCode = "K"
          Case Else
            WrkCode = ""
        End Select
      Case "S"
        Select Case WrkPct
          Case 1
            WrkCode = "A"
          Case 0.917
            WrkCode = "B"
          Case 0.833
            WrkCode = "C"
          Case 0.75
            WrkCode = "D"
          Case 0.667
            WrkCode = "E"
          Case 0.583
            WrkCode = "F"
          Case 0.5
            WrkCode = "G"
          Case 0.417
            WrkCode = "H"
          Case 0.333
            WrkCode = "I"
          Case 0.25
            WrkCode = "J"
          Case Else
            WrkCode = ""
        End Select
      Case Else
        WrkCode = ""
        WrkPct = 0
    End Select
    Return WrkCode
  End Function
  Private Sub FixUTCUSTRT()
    Dim ds As DataSet = New DataSet
    Dim ds3 As DataSet = New DataSet
    Dim WrkAcct As Integer
    Dim WrkType As String
    Dim WrkCode As String
    Dim I As Integer
    Dim J As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    MyUTCUST = New UTCUST(myDBConnectGEMS.MyConn2)
    MyUTCUSTRT = New UTCUSTRT(myDBConnectGEMS.MyConn2)
    ds = myDBConnect.RunQuery("MASTER_USAGE", " order by acct_no, Wt_Id")
    For I = 0 To ds.Tables(0).Rows.Count - 1
      WrkAcct = ds.Tables(0).Rows(I).Item("Acct_NO")
      WrkType = GetTaxType(MyTOWN._TOWNBR, CnvSng(ds.Tables(0).Rows(I).Item("Service_Acct_Type")))
      If WrkType = "" Then
        WrkType = GetTaxType(MyTOWN._TOWNBR, CnvSng(ds.Tables(0).Rows(I).Item("Acct_Type")))
      End If
      WrkCode = GetSewerCode(WrkType, ds.Tables(0).Rows(I).Item("Wt_id"))
      If WrkType <> "U" And WrkType <> "W" Then
        Continue For
      End If
      ds3 = myDBConnect3.RunQuery("MASTER_SEWER", "where acct_no=" & WrkAcct & " and acct_type=" &
      ds.Tables(0).Rows(I).Item("acct_type"))
      If ds3.Tables(0).Rows.Count > 0 Then
        If Trim(ds3.Tables(0).Rows(0).Item("plan_code")) = cRateOmit Then
          Continue For
        End If
      End If
      With MyUTCUST
        Counter = Counter + 1
        If WrkCode <> "" Then
          .GetOneRecordP(WrkAcct)
          If Not .RecordNotFound Then
            If WrkType = "U" And ds.Tables(0).Rows(I).Item("Wt_id") = "FIX" Then
              ._CUSFIX = ds.Tables(0).Rows(I).Item("occ")
              .UpdateOneRecordP()
            End If
            If WrkType = "W" And ds.Tables(0).Rows(I).Item("Wt_id") = "FIX" Then
              ._CUWFIX = ds.Tables(0).Rows(I).Item("occ")
              .UpdateOneRecordP()
            End If
          End If
        End If
      End With

      With MyUTCUSTRT
        If WrkCode <> "" Then
          .GetOneRecordP(WrkAcct, WrkType)
          If Not .RecordNotFound Then
            ._CRCODE = WrkCode
            .UpdateOneRecordP()
            If .ErrMsg <> String.Empty Then
              sw.WriteLine("UTCUSTRT " & WrkType & " " & .ErrMsg)
            End If
          End If
        End If
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next
    ds = Nothing
  End Sub
  Private Sub UpdateINVSuspense()
    Dim ds2 As DataSet = New DataSet
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkRecID As Integer
    Dim WrkFields As String
    Dim WrkSusp As Boolean
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal

    MyTXINV = New TXINV(myDBConnectGEMS.MyConn2)
    MyTXHST = New TXHST(myDBConnectGEMS.MyConn2)
    myDBConnect.OpenQry("TAX_SUSPENSE", "")
    WrkFile = "TXINV"
    WrkFields = ""

ReadNext:
    myDBConnect.ReadQry()
    If Not myDBConnect.IsEOF Then
      With MyTXINV
        WrkSusp = False
        Counter = Counter + 1
        WrkListNo = myDBConnect.objReader.Item("bill_num")
        WrkType = GetTaxType(MyTOWN._TOWNBR, myDBConnect.objReader.Item("bill_type"))
        WrkYear = myDBConnect.objReader.Item("yr")
        .GetOneRecordP(WrkListNo, WrkYear, WrkType)
        If Not .RecordNotFound Then
          WrkSusp = True
          ._ICODE = "S"
          ._SUSCD = "S"
          ._SUSDT = ConvertDate(myDBConnect.objReader.Item("date_of_suspense"))
          .UpdateOneRecordP()
        End If
      End With

      If WrkSusp Then
        With MyTXHST
          WrkRecID = .AutoGenKey(0, 0)
          .GetOneRecordP(WrkRecID)
          ._RECID = WrkRecID
          ._RCODE = "I"
          ._LISTNO = WrkListNo
          ._YEAR = WrkYear
          ._TYPE = WrkType
          ._PAMT = 0
          ._IAMT = 0
          ._LAMT = 0
          ._PCAMT = CnvSng(myDBConnect.objReader.Item("town_amt_suspended"))
          ._DIST = 0
          ._COMM = "SUSPENDED"
          ._SUSCD = "S"
          ._CORC = ""
          ._BATCHN = 0
          ._BATCHA = "S"
          ._PDATE = ConvertDate(myDBConnect.objReader.Item("date_of_suspense"))
          ._CDATE = ._PDATE
          ._THINPD = ""
          ._PRF = ""
          ._CHDATE = 0
          ._CHTIME = 0
          .InsertOneRecordP()
        End With
      End If

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
        GoTo ReadNext
      End If
    End If
  End Sub
  Private Sub UpdateINVBond()
    Dim ds2 As DataSet = New DataSet
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkFields As String
    Dim WrkSusp As Boolean
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal

    MyTXINV = New TXINV(myDBConnectGEMS.MyConn2)
    MyTXHST = New TXHST(myDBConnectGEMS.MyConn2)
    myDBConnect.OpenQry("INSTFILE", " where Bill_type=5")
    WrkFile = "TXINV"
    WrkFields = ""

ReadNext:
    myDBConnect.ReadQry()
    If Not myDBConnect.IsEOF Then
      With MyTXINV
        WrkSusp = False
        Counter = Counter + 1
        WrkListNo = myDBConnect.objReader.Item("bill_num")
        WrkType = GetTaxType(MyTOWN._TOWNBR, myDBConnect.objReader.Item("bill_type"))
        WrkYear = myDBConnect.objReader.Item("yr")
        .GetOneRecordP(WrkListNo, WrkYear, WrkType)
        If Not .RecordNotFound Then
          ._BOND = myDBConnect.objReader.Item("city_b_int1")
          ._BONDP = myDBConnect.objReader.Item("city_paid_b_int1")
          .UpdateOneRecordP()
        End If
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
        GoTo ReadNext
      End If
    End If
  End Sub
  Private Sub FixBanks()
    Dim ds As DataSet = New DataSet
    Dim WrkTxyr As Integer
    Dim I As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    MyTXREAA = New TXREAA(myDBConnectGEMS.MyConn2, "TXREAA")
    ds = myDBConnect.RunQuery("ASSRREAL", "where record_year>=" & cArchiveOldYear & " and record_year<=" & cArchiveNewYear)
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTXREAA
        Counter = Counter + 1
        WrkListNo = ds.Tables(0).Rows(I).Item("list_no")
        WrkTxyr = ds.Tables(0).Rows(I).Item("record_year")
        .GetOneRecordP(WrkListNo, WrkTxyr)
        Select Case Len(Trim(ds.Tables(0).Rows(I).Item("bank_no")))
          Case > 2
            ._BKCD = ""
          Case Else
            ._BKCD = ds.Tables(0).Rows(I).Item("bank_no")
        End Select
        .UpdateOneRecordP()
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next
    ds = Nothing
  End Sub
  Private Sub FixLiens()
    Dim ds As DataSet = New DataSet
    Dim WrkYear As Integer
    Dim WrkType As String
    Dim WrkRecID As Integer
    Dim WrkAmount As Decimal
    Dim WrkLienDate As Integer
    Dim I As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal

    MyTXHST = New TXHST(myDBConnectGEMS.MyConn2)
    ds = myDBConnect.RunQuery("TAX_LIEN_TABLE", "where yr>=" & cOldYearHist)
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTXHST
        Counter = Counter + 1
        WrkListNo = ds.Tables(0).Rows(I).Item("bill_num")
        WrkYear = ds.Tables(0).Rows(I).Item("yr")
        WrkType = GetTaxType(MyTOWN._TOWNBR, ds.Tables(0).Rows(I).Item("bill_type"))
        WrkLienDate = ConvertDate(ds.Tables(0).Rows(I).Item("liened_date"))
        WrkAmount = ds.Tables(0).Rows(I).Item("liened_amt")
        WrkRecID = .AutoGenKey(0, 0)
        .GetOneRecordP(WrkRecID)
        ._RECID = WrkRecID
        ._RCODE = "I"
        ._LISTNO = WrkListNo
        ._YEAR = WrkYear
        ._TYPE = WrkType
        ._PAMT = WrkAmount
        ._IAMT = 0
        ._LAMT = 0
        ._PCAMT = 0
        ._DIST = 0
        ._COMM = "LIENED" 'BchComm
        ._CORC = ""
        ._BATCHN = 0
        ._BATCHA = "L"
        ._PDATE = WrkLienDate
        ._CDATE = ._PDATE
        ._THINPD = ""
        ._PRF = ""
        ._CHDATE = 0
        ._CHTIME = 0
        .InsertOneRecordP()
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next
    ds = Nothing
  End Sub
End Class