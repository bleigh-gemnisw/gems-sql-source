Imports System.Text
Imports System.IO
Public Class FrmQDS
  Dim sw As StreamWriter
  Public myDBConnect As DBConnection 'QDS Connection #1
  Public myDBConnect2 As DBConnection 'QDS Connection #2
  Public myDBConnect3 As DBConnection 'QDS Connection #3
  Public myDBConnectGEMS As DBConnection 'GEMS Connection
  Dim MyTOWN As TOWN
  Dim MyTAXCOM As TAXCOM
  Dim MyTXPROF As TXPROF
  Dim MyTXTYPE As TXTYPE
  Dim MyTXINV As TXINV
  Dim MyTXHST As TXHST
  Dim MyTXCOEA As TXCOEA
  Dim MyTXCOEB As TXCOEB
  Dim MyUTCUST As UTCUST
  Dim MyUTCUSTAS As UTCUSTAS
  Dim MyUTCUSTMT As UTCUSTMT
  Dim MyUTCUSTRT As UTCUSTRT
  Dim WrkGLYear As Integer
  Dim WrkListNo As Integer
  Dim WrkFile As String
  Dim ProfYear(250) As Integer
  Dim ProfType(250) As String
  Dim ProfNumBills(250) As Integer
  Private Sub BtnConvert_Click(sender As Object, e As EventArgs) Handles BtnConvert.Click
    Dim WrkTimeStamp As String
    WrkTimeStamp = Format(Date.Now, "MMddyyyy HHmmss")
    sw = New StreamWriter(GetDataPath() & "CnvQDSUB-" & WrkTimeStamp & ".csv")
    ProgBar1.Visible = True
    'WriteTOWN()
    MyTOWN = New TOWN(myDBConnectGEMS.MyConn2)
    With MyTOWN
      .GetOneRecordP(1)
    End With
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXPROF" & vbCrLf
    'Write_PROF() 'Tax Profile
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TYPE" & vbCrLf
    'WriteTYPE() 'Tax Types
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXINV" & vbCrLf
    'BufferProf() 'Tax Profile
    'WriteINV() 'Invoice file
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXHST" & vbCrLf
    'WriteHST() 'History file
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "UTCUST" & vbCrLf
    'WriteUTCUST() 'UB Customer file
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "UTCUSTAS" & vbCrLf
    'WriteUTCUSTAS() 'UB Customer Assessment data
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "UTCUSTRT" & vbCrLf
    'WriteUTCUSTRT() 'UB Rate file
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "UTCUST2" & vbCrLf
    'WriteUTCUST2() 'UB Customer file (Meter size/Meter number/Latitude/Longitude)
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "UTCUSTMT" & vbCrLf
    'WriteUTCUSTMT() 'UB Meter Readings
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TAXCOM" & vbCrLf
    'WriteTAXCOM() 'UB Comments
    sw.Flush()
    sw.Close()
    ProgBar1.Visible = False
    LblMsg.Text = ""
    TxtErrorMsg.Text = TxtErrorMsg.Text & " DONE"
  End Sub
  Private Sub DoNotRun()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXCOEA" & vbCrLf
    'WriteCOEA() 'After bill C/C's
  End Sub

  Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    GetAppSettings()
    myDBConnect = New DBConnection()
    myDBConnect.Open()
    myDBConnect2 = New DBConnection()
    myDBConnect2.Open()
    myDBConnect3 = New DBConnection()
    myDBConnect3.Open()
    myDBConnectGEMS = New DBConnection()
    myDBConnectGEMS.Open2()
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
  Private Sub Write_PROF()
    Dim ds As DataSet = New DataSet
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim I As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    MyTXPROF = New TXPROF(myDBConnectGEMS.MyConn2)
    myDBConnectGEMS.DeleteRecords2("TXPROF")
    ds = myDBConnect.RunQuery("MILLFILE", "")
    For I = 0 To ds.Tables(0).Rows.Count - 1
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
        If WrkType = "" Then
          Continue For
        End If
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
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkLen As Integer
    Dim WrkCCno As Integer
    Dim WrkCCDate As Integer
    Dim WrkSalePct As Decimal
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer

    MyTXINV = New TXINV(myDBConnectGEMS.MyConn2)
    MyTXCOEA = New TXCOEA(myDBConnectGEMS.MyConn2)
    myDBConnectGEMS.DeleteRecords2("TXINV") ', " where year>=2018")
    myDBConnectGEMS.DeleteRecords2("TXCOEA") '), " where year>=2018")
    'myDBConnect.OpenQry("TAXMAST", " where yr>=2018")
    myDBConnect.OpenQry("TAXMAST", "")
    WrkFile = "TXINV"

ReadNext:
    myDBConnect.ReadQry()
    If Not myDBConnect.IsEOF Then
      With MyTXINV
        Counter = Counter + 1
        If myDBConnect.objReader.Item("transfer_flag") = "Y" Then GoTo ReadNext
        WrkListNo = myDBConnect.objReader.Item("bill_num")
        WrkType = GetTaxType(MyTOWN._TOWNBR, myDBConnect.objReader.Item("bill_type"))
        If WrkType = "" Then
          GoTo ReadNext
        End If
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
          ._EXCD1 = ""
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
          If myDBConnect.objReader.Item("suspense_flag") = "Y" Then
            ._ICODE = "S"
          End If
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
          ._LETT = Mid(myDBConnect.objReader.Item("txpr_name"), 1, 1)
          ._LIEN = myDBConnect.objReader.Item("lien_code")
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
          ._OAS1 = myDBConnect.objReader.Item("orig_ass")
          ._OAS10 = 0
          ._OAS2 = 0
          ._OAS3 = 0
          ._OAS4 = 0
          ._OAS5 = 0
          ._OAS6 = 0
          ._OAS7 = 0
          ._OAS8 = 0
          ._OAS9 = 0
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
          ._STCD1 = ""
          ._STCD2 = ""
          ._STCD3 = ""
          ._STCD4 = ""
          ._STCD5 = ""
          ._SUSCD = ""
          ._SUSDT = 0
          ._TIN = ""
          ._TOTEXP = 0
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
          ds3 = myDBConnect3.RunQuery("COC_DATA", "where grand_list_year=" & WrkYear & " and bill_type=" &
          myDBConnect.objReader.Item("bill_type") & " and bill_number=" & WrkListNo & " Order By coc_date")
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
                    ._ASS1 = ds3.Tables(0).Rows(I).Item("New_Gross")
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
                    ._C1MPCD = ""
                    ._C1MSCD = ""
                    ._C2CPCD = ""
                    ._C2CSCD = ""
                    ._C2MPCD = ""
                    ._CCNO = WrkCCno
                    ._CDATE = WrkCCDate
                    ._CDESC = ConvertString("CDESC", ds3.Tables(0).Rows(I).Item("Change_Reason"), 25)
                    ._CETAX = ds3.Tables(0).Rows(I).Item("Tax_Due_New")
                    ._CGRS = ds3.Tables(0).Rows(I).Item("New_Gross")
                    ._CHDATE = WrkCCDate
                    ._CHTIME = 0
                    If Trim(ds3.Tables(0).Rows(I).Item("Net_Inc_Dec")) = "NC" And Trim(ds3.Tables(0).Rows(I).Item("t_cb_or_freeze") = "") Then
                      ._CNETAS = Math.Round(ds3.Tables(0).Rows(I).Item("New_Net") * (1 - WrkSalePct))
                    Else
                      ._CNETAS = ds3.Tables(0).Rows(I).Item("New_Net")
                    End If
                    ._CPCD1 = 0
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
                    ._EX1 = ds3.Tables(0).Rows(I).Item("Adj_Exempt")
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
                    ._EXCHG = ds3.Tables(0).Rows(I).Item("Adj_Exempt")
                    If Trim(ds3.Tables(0).Rows(I).Item("Gross_Inc_Dec")) = "DEC" Then
                      ._GRCHG = ds3.Tables(0).Rows(I).Item("Adj_Gross") * -1
                    Else
                      ._GRCHG = ds3.Tables(0).Rows(I).Item("Adj_Gross")
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
                    sw.WriteLine(WrkFile & ", " & WrkListNo & ", Dup CC: ," & WrkCCno)
                  End If
                End With
              End If
            Next
          End If

          I = I - 1
          ds2 = myDBConnect2.RunQuery("INSTFILE", "where yr=" & WrkYear & " and bill_type=" &
            myDBConnect.objReader.Item("bill_type") & " and bill_num=" & WrkListNo)
          If ds2.Tables(0).Rows.Count > 0 Then
            ._TAX1 = ds2.Tables(0).Rows(0).Item("city_tax1")
            ._TAX2 = ds2.Tables(0).Rows(0).Item("city_tax2")
            ._TX3RD = ds2.Tables(0).Rows(0).Item("city_tax3")
            ._TX4TH = ds2.Tables(0).Rows(0).Item("city_tax4")
            ._BALD = ds2.Tables(0).Rows(0).Item("city_total_due")
            ._PAYREC = ds2.Tables(0).Rows(0).Item("city_paid_tax1")
            ._TAXT = ._TAX1 + ._TAX2 + ._TX3RD + ._TX4TH
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
              ._CEXA1 = 0
              ._CEXA2 = 0
              ._CEXA3 = 0
              ._CEXA4 = 0
              ._CEXA5 = 0
              ._CEXA6 = 0
              ._CEXA7 = 0
              ._CGRS = ds3.Tables(0).Rows(I).Item("Adj_Gross")
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
        If WrkType = "" Then
          GoTo NextRec
        End If
        WrkYear = ds.Tables(0).Rows(I).Item("yr")
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
        If ds.Tables(0).Rows(I).Item("suspense_flag") = "S" Then
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
    '    myDBConnectGEMS.DeleteRecords2("UTCUSTRT", " where crtype<>'A'")
    ds = myDBConnect.RunQuery("MASTER_USAGE", " order by acct_no, Wt_Id")
    For I = 0 To ds.Tables(0).Rows.Count - 1
      WrkAcct = ds.Tables(0).Rows(I).Item("Acct_NO")
      WrkType = GetTaxType(MyTOWN._TOWNBR, CnvSng(ds.Tables(0).Rows(I).Item("Service_Acct_Type")))
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
        If WrkCode <> "*" Then
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
        Else
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
          .UpdateOneRecordP()
        End If
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
            'Else
            '  .UpdateOneRecordP()
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
    myDBConnect.OpenQry("METER_SERVICE", "")

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
            ._CMNT = Mid(WrkStr, WrkPos, 60)
            ._CSEQ = J
            ._LISTNO = WrkAcct
            ._TYPE = WrkType
            ._YEAR = WrkYear
            .AddOneRecordP()
            If .ErrMsg <> String.Empty Then
              sw.WriteLine("TAXCOM2 " & WrkAcct & WrkType & WrkYear & " " & .ErrMsg)
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
End Class