Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection.Emit
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms.VisualStyles
Public Class FrmMain
  Dim sw As StreamWriter
  Public myDBConnect As DBConnection 'Connection #1
  Public myDBConnect2 As DBConnection 'Connection #2
  Public myDBConnect3 As DBConnection 'Connection #3
  Public myDBConnect4 As DBConnection 'Connection #4
  Public myDBConnectGEMS As DBConnection 'GEMS Connection
  Public myDBConnectGEMS2 As DBConnection 'GEMS Connection 2
  Dim AcctXref As New Dictionary(Of String, List(Of Integer))()
  Dim MyTOWN As TOWN
  Dim MyTAXCOM As TAXCOM
  Dim MyTXPROF As TXPROF
  Dim MyTXTYPE As TXTYPE
  Dim MyTXINV As TXINV
  Dim MyTXHST As TXHST
  Dim MyUTCUST As UTCUST
  Dim MyUTCUSTMT As UTCUSTMT
  Dim MyUTCUSTRT As UTCUSTRT
  Dim MyLOGUT As LOGUT
  Dim WrkGLYear As Integer
  Dim WrkListNo As Integer
  Dim WrkFile As String
  Dim MyGLYear As Integer
  Dim ProfYear(250) As Integer
  Dim ProfType(250) As String
  Dim ProfNumBills(250) As Integer
  Private Sub BtnConvert_Click(sender As Object, e As EventArgs) Handles BtnConvert.Click
    Dim WrkTimeStamp As String
    WrkTimeStamp = Format(Date.Now, "MMddyyyy HHmmss")
    sw = New StreamWriter(GetDataPath() & "CnvSouthUB-" & WrkTimeStamp & ".csv")
    ProgBar1.Visible = True
    MyTOWN = New TOWN(myDBConnectGEMS.MyConn2)
    With MyTOWN
      .GetOneRecordP(1)
    End With
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TYPE" & vbCrLf
    'WriteTYPE() 'Tax Types
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXINV" & vbCrLf
    'BufferProf() 'Tax Profile
    'WriteINV() 'Invoice file
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXHST" & vbCrLf
    'WriteHST() 'History file
    TxtErrorMsg.Text = TxtErrorMsg.Text & "UTCUST/RT" & vbCrLf
    WriteUTCUST() 'UB Customer & Rate file
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "UTCUSTMT" & vbCrLf
    'WriteUTCUSTMT() 'UB Meter Readings
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "LOGUT" & vbCrLf
    'WriteLOGUT() 'UB Log
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TAXCOM" & vbCrLf
    'WriteTAXCOM() 'UB Comments
    sw.Flush()
    sw.Close()
    ProgBar1.Visible = False
    LblMsg.Text = ""
    TxtErrorMsg.Text = TxtErrorMsg.Text & " DONE"
  End Sub
  Private Sub DoNotRun()
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
  End Sub
  Private Sub WriteTXPROF()
    Dim ds As DataSet = New DataSet
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim I As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    MyTXPROF = New TXPROF(myDBConnectGEMS.MyConn2)

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
    Dim WrkCCno As Integer
    Dim WrkCCDate As Integer
    Dim WrkFields As String
    Dim WrkRecID As Long
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer

    MyTXINV = New TXINV(myDBConnectGEMS.MyConn2)
    MyTXHST = New TXHST(myDBConnectGEMS.MyConn2) 'Only for Liens
    myDBConnectGEMS.DeleteRecords2("TXINV")
    myDBConnectGEMS.DeleteRecords2("TXHST")
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
  Private Sub WriteUTCUST()
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim ds3 As DataSet = New DataSet
    Dim ds4 As DataSet = New DataSet
    Dim dstemp As DataSet = New DataSet
    Dim WrkMunCid As Integer
    Dim Good As Boolean
    Dim WrkMunACMKey As Integer
    Dim WrkMunACDKey As Integer
    Dim WrkAcct As Integer
    Dim WrkRateCd As Integer
    Dim WrkServiceCd As Integer
    Dim WrkMeterSize As String
    Dim WrkMeter As String
    Dim WrkCode As String
    Dim WrkBusiness As Boolean
    Dim WrkName As String
    Dim WrkName2 As String
    Dim WrkMap As String
    Dim WrkLoc As String
    Dim WrkLocNo As String
    Dim WrkLocSuff As String
    Dim StrLoc As String
    Dim StrLocNo As String
    Dim StrLocSuff As String
    Dim StrTemp As String
    Dim I As Integer
    Dim J As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal

    MyUTCUST = New UTCUST(myDBConnectGEMS.MyConn2)
    MyUTCUSTRT = New UTCUSTRT(myDBConnectGEMS.MyConn2)
    myDBConnectGEMS.DeleteRecords2("UTCUST")
    myDBConnectGEMS.DeleteRecords2("UTCUSTRT", "")
    ds = myDBConnect.RunQuery("ub_customers", "") '"where a_customer=18091")
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyUTCUST
        Counter = Counter + 1
        WrkMunCid = ds.Tables(0).Rows(I).Item("a_customer")
        ds2 = myDBConnect.RunQuery("utactcid", "where utacd_cid=" & WrkMunCid)
        If ds2.Tables(0).Rows.Count = 0 Then
          sw.WriteLine("skip,utactid not found " & WrkMunCid)
          Continue For
        End If
        WrkMunACMKey = 0
        WrkMunACDKey = 0
        WrkMeter = ""
        Good = False
        For J = 0 To ds2.Tables(0).Rows.Count - 1
          If ds2.Tables(0).Rows(J).Item("utacd_stop_date") <> "9999-12-31 00:00:00.000" Then
            Continue For
          End If
          WrkMunACMKey = ds2.Tables(0).Rows(J).Item("utacd_utacm_key")
          WrkMunACDKey = ds2.Tables(0).Rows(J).Item("utacd_key")
          WrkMeter = ds2.Tables(0).Rows(J).Item("utacd_account")
          ds3 = myDBConnect.RunQuery("utactmst", "where utacm_key=" & WrkMunACMKey)
          If ds3.Tables(0).Rows.Count > 0 Then
            ds4 = myDBConnect.RunQuery("utsvcmst", "where utsvm_utacd_key=" & WrkMunACDKey)
            If ds4.Tables(0).Rows.Count > 0 Then
              Good = True
              ds4.Clear()
              Exit For
            End If
          End If
        Next
        If WrkMunACMKey = 0 Then
          sw.WriteLine("skip,utactid expired/missing " & WrkMunCid)
          Continue For
        End If
        If Not Good Then
          sw.WriteLine("skip,utsvcmst missing " & WrkMunCid)
          Continue For
        End If
        WrkAcct = 0
        WrkMap = Replace(ds3.Tables(0).Rows(0).Item("utacm_loc_subd"), "-", " ")
        WrkMap = Trim(WrkMap)
        WrkLocNo = JustifyRight(ds3.Tables(0).Rows(0).Item("utacm_loc_no"), 7)
        WrkLoc = Trim(ds3.Tables(0).Rows(0).Item("utacm_loc_street")) & " " & Trim(ds3.Tables(0).Rows(0).Item("utacm_loc_str_typ"))
        StrLoc = ConvertLoc(WrkLoc)
        StrLocNo = WrkLocNo
        StrLocSuff = Trim(ds3.Tables(0).Rows(0).Item("utacm_loc_no_suff"))
        WrkLocSuff = StrLocSuff
        If WrkMap <> "" Then
          ds4 = myDBConnectGEMS.RunQuery2("txreal", "where map='" & WrkMap & "'")
          If ds4.Tables(0).Rows.Count = 1 Then
            WrkAcct = ds4.Tables(0).Rows(0).Item("list#")
          End If
        End If
        If WrkAcct = 0 Then
          'Exact Location
          ds4 = myDBConnectGEMS.RunQuery2("txreal", "where loc='" & StrLoc & "' and loc#='" & StrLocNo & "'")
          If ds4.Tables(0).Rows.Count = 1 Then
            WrkAcct = ds4.Tables(0).Rows(0).Item("list#")
            GoTo Retry
          End If

          If StrLocSuff = "" Then
            'Wildcard Location only 1 match
            ds4 = myDBConnectGEMS.RunQuery2("txreal", "where loc like '" & StrLoc & "%' and loc#='" & StrLocNo & "'")
            If ds4.Tables(0).Rows.Count = 1 Then
              WrkAcct = ds4.Tables(0).Rows(0).Item("list#")
              GoTo Retry
            End If

            'PP Exact Location
            ds4 = myDBConnectGEMS.RunQuery2("txpprp", "where loc='" & StrLoc & "' and loc#='" & StrLocNo & "'")
            If ds4.Tables(0).Rows.Count = 1 Then
              WrkAcct = ds4.Tables(0).Rows(0).Item("list#")
              GoTo Retry
            End If
          Else
            'Location with house number 
            StrTemp = CnvSng(WrkLocNo) & " " & Trim(StrLoc)
            StrLocSuff = JustifyRight(CnvSng(WrkLocSuff), 7)
            ds4 = myDBConnectGEMS.RunQuery2("txreal", "where loc='" & StrTemp & "' and loc#='" & StrLocSuff & "'")
            If ds4.Tables(0).Rows.Count = 1 Then
              WrkAcct = ds4.Tables(0).Rows(0).Item("list#")
              GoTo Retry
            End If

            'Location add dash
            StrLocSuff = "-" & WrkLocSuff
            StrTemp = Trim(WrkLocNo & StrLocSuff)
            StrTemp = JustifyRight(StrTemp, 7)
            ds4 = myDBConnectGEMS.RunQuery2("txreal", "where loc='" & StrLoc & "' and loc#='" & StrTemp & "'")
            If ds4.Tables(0).Rows.Count = 1 Then
              WrkAcct = ds4.Tables(0).Rows(0).Item("list#")
              GoTo Retry
            End If

            'Location change space to dash
            StrLocSuff = Replace(WrkLocSuff, " ", "-")
            StrTemp = Trim(WrkLocNo & StrLocSuff)
            StrTemp = JustifyRight(StrTemp, 7)
            ds4 = myDBConnectGEMS.RunQuery2("txreal", "where loc='" & StrLoc & "' and loc#='" & StrTemp & "'")
            If ds4.Tables(0).Rows.Count = 1 Then
              WrkAcct = ds4.Tables(0).Rows(0).Item("list#")
              GoTo Retry
            End If

            'Location add leading 0 to dash
            StrLocSuff = Replace(StrLocSuff, "-", "-0")
            StrTemp = Trim(WrkLocNo & StrLocSuff)
            StrTemp = JustifyRight(StrTemp, 7)
            ds4 = myDBConnectGEMS.RunQuery2("txreal", "where loc='" & StrLoc & "' and loc#='" & StrTemp & "'")
            If ds4.Tables(0).Rows.Count = 1 Then
              WrkAcct = ds4.Tables(0).Rows(0).Item("list#")
              GoTo Retry
            End If

            'PP Exact Location
            ds4 = myDBConnectGEMS.RunQuery2("txpprp", "where loc='" & StrLoc & "' and loc#='" & StrLocNo & "'")
            If ds4.Tables(0).Rows.Count = 1 Then
              WrkAcct = ds4.Tables(0).Rows(0).Item("list#")
              GoTo Retry
            End If
          End If

          sw.WriteLine("error,Not found " & WrkMunCid & ":  " & Trim(WrkLoc) & " " & Trim(WrkLocNo) & " " & WrkLocSuff)
          Continue For
          End If

Retry:
        WrkRateCd = 0
        WrkServiceCd = 0
        WrkMeterSize = ""
        WrkCode = ""
        .GetOneRecordP(WrkAcct)
        If .RecordNotFound Then
          dstemp = myDBConnect.RunQuery("utsvcmst", "where utsvm_utacd_key=" & WrkMunACDKey, "utsvm_serv_code,utsvm_rate_code")
          For J = 0 To dstemp.Tables(0).Rows.Count - 1
            WrkRateCd = dstemp.Tables(0).Rows(J).Item("utsvm_rate_code")
            WrkServiceCd = dstemp.Tables(0).Rows(J).Item("utsvm_serv_code")
          Next

          Dim result = ConvertRate(WrkServiceCd, WrkRateCd)
          WrkMeterSize = result.Meter
          WrkCode = result.Code
          If ds.Tables(0).Rows(I).Item("cs_nh_sw") = "E" Then
            WrkBusiness = True
          Else
            WrkBusiness = False
          End If
          ._CUACCT = WrkAcct
          'If WrkBusiness Then
          WrkName = ds.Tables(0).Rows(I).Item("cs_name1") & ""
          If WrkName = "" Then
            Continue For
          End If
          WrkName2 = ds.Tables(0).Rows(I).Item("cs_name2") & ""
          'Else
          'WrkName = FlipName(ds.Tables(0).Rows(I).Item("cs_name1"))
          'WrkName2 = FlipName(ds.Tables(0).Rows(I).Item("cs_name2"))
          'Ed If
          ._CUNAM1 = ConvertString("NAM1", WrkName, 35)
          ._CUNAM2 = ConvertString("NAM2", WrkName2, 35)
          ._CUADD1 = ConvertString("ADD1", ds.Tables(0).Rows(I).Item("cs_address1") & "", 35)
          ._CUADD2 = ConvertString("ADD2", ds.Tables(0).Rows(I).Item("cs_address2") & "", 35)
          ._CUCITY = ConvertString("CITY", ds.Tables(0).Rows(I).Item("cs_city") & "", 25)
          ._CUST = ds.Tables(0).Rows(I).Item("cs_state") & ""
          ._CUZIP = ds.Tables(0).Rows(I).Item("cs_zip") & ""
          ._CUMAD1 = ""
          ._CUMAD2 = ""
          ._CUMCTY = ""
          ._CUMST = ""
          ._CUMZIP = ""
          ._CUTELNO = ConvertString("Telno", ds.Tables(0).Rows(I).Item("cs_phone"), 15)
          ._CUDST = CnvSng(ds3.Tables(0).Rows(0).Item("utacm_district"))
          ._CUPHAS = 0
          ._CUADDX = ""
          ._CUTIE = 0
          ._CUMAP = ""
          ._CUVOLM = ""
          ._CUPAGE = ""
          ._CUZONE = ""
          ._CUPCAT = ""
          ._CUXREF = ""
          ._CUMSIZ = WrkMeterSize
          ._CUUPMT = ""
          ._CUUNIT = 0
          ._CUEDU = 0
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
          ._CUROUT = ""
          ._CUMETN = WrkMeter
          ._CUMETP = ""
          ._CUREGN = ""
          ._CULOCNO = WrkLocNo
          ._CULOC = WrkLoc
          ._CUCNTNO = WrkMunCid
          ._CUAPLNO = ""
          ._CUFUND = 0
          ._CUSECT = ""
          ._CUSDES = ""
          .AddOneRecordP()
          If .ErrMsg <> String.Empty Then
            sw.WriteLine("Error,UTCUST " & WrkAcct & " " & .ErrMsg)
          End If
        Else
          If WrkAcct < 900000 Then 'Max limit (9 dups) 
            WrkAcct = 100000 + WrkAcct 'Change List # and retry
            GoTo Retry
          Else
            sw.WriteLine("Error,Dup " & WrkMunCid & ":" & WrkAcct & " " & WrkLoc & " " & WrkLocNo)
          End If
        End If
      End With

      'BuildXref(WrkAcct, WrkListNo)
      WriteUTCUSTRT(WrkAcct, WrkCode)

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

  Private Sub WriteUTCUSTRT(ByVal WrkAcct As Integer, ByVal WrkCode As String)
    Dim WrkType As String
    WrkType = "D"

    With MyUTCUSTRT
      .GetOneRecordP(WrkAcct, WrkType)
      If .RecordNotFound Then
        ._CRACCT = WrkAcct
        ._CRTYPE = WrkType
        ._CRCODE = WrkCode
        .AddOneRecordP()
        If .ErrMsg <> String.Empty Then
          sw.WriteLine("UTCUSTRT " & .ErrMsg)
        End If
      End If
    End With
  End Sub
  Private Sub WriteUTCUSTMT()
    Dim ds As DataSet = New DataSet
    Dim WrkMunCid As Integer
    Dim WrkMeter As String
    Dim WrkDate As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    MyUTCUSTMT = New UTCUSTMT(myDBConnectGEMS.MyConn2)
    MyUTCUST = New UTCUST(myDBConnectGEMS.MyConn2)
    myDBConnectGEMS.DeleteRecords2("UTCUSTMT")
    myDBConnect.OpenQry("utbilmtr", " where utbmt_read_date>='2023-01-01'")

ReadNext:
    myDBConnect.ReadQry()
    If Not myDBConnect.IsEOF Then
      With MyUTCUSTMT
        Counter = Counter + 1
        WrkMunCid = myDBConnect.objReader.Item("utbmt_cid")
        WrkMeter = myDBConnect.objReader.Item("utbmt_account")
        WrkListNo = 0
        'ds = myDBConnectGEMS.RunQuery2("UTCUST", " where cucnt#='" & WrkMunCid & "'")
        ds = myDBConnectGEMS.RunQuery2("UTCUST", " where cumetn='" & WrkMeter & "'")
        If ds.Tables(0).Rows.Count > 0 Then
          WrkListNo = ds.Tables(0).Rows(0).Item("cuacct")
        End If
        If WrkListNo > 0 Then
          WrkDate = ConvertDate(myDBConnect.objReader.Item("utbmt_read_date"))
          .GetOneRecordP(WrkListNo, "", WrkDate)
          If MyUTCUSTMT.RecordNotFound Then
            ._CMACCT = WrkListNo
            ._CMDATE = WrkDate
            ._CMREAD = CnvSng(myDBConnect.objReader.Item("utbmt_act_usage"))
            ._CMRESN = ""
            ._CMTYPE = ""
            ._CMUSE = CnvSng(myDBConnect.objReader.Item("utbmt_billed_usage"))
            If ._CMUSE > 0 Then
              .InsertOneRecordP()
              If .ErrMsg <> String.Empty Then
                sw.WriteLine("UTCUSTMT " & WrkListNo & " " & .ErrMsg)
              End If
            End If
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
      End If
      GoTo ReadNext
    End If
  End Sub
  Private Sub WriteLOGUT()
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkMeter As String
    Dim WrkMunCid As Integer
    Dim WrkName As String
    Dim WrkName2 As String
    Dim WrkPct As Decimal
    Dim I As Integer
    Dim Counter As Integer
    Dim SavePct As Decimal
    MyUTCUST = New UTCUST(myDBConnectGEMS.MyConn2)
    MyLOGUT = New LOGUT(myDBConnectGEMS.MyConn2)
    myDBConnectGEMS.DeleteRecords2("LOGUT")

    ds = myDBConnect.RunQuery("utactcid", "")
    For I = 0 To ds.Tables(0).Rows.Count - 1
      WrkListNo = 0
      Counter = Counter + 1
      WrkMeter = ds.Tables(0).Rows(I).Item("utacd_account")
      WrkMunCid = ds.Tables(0).Rows(I).Item("utacd_cid")
      ds2 = myDBConnectGEMS.RunQuery2("UTCUST", " where cumetn='" & WrkMeter & "'")
      If ds2.Tables(0).Rows.Count > 0 Then
        WrkListNo = ds2.Tables(0).Rows(0).Item("cuacct")
      Else
        Continue For
      End If
      ds2 = myDBConnect.RunQuery("ub_customers", " where a_customer=" & WrkMunCid)
      If ds2.Tables(0).Rows.Count = 0 Then
        Continue For
      End If
      MyUTCUST.GetOneRecordP(WrkListNo)
      With MyLOGUT
        .GetOneRecordP(WrkListNo, Counter, 0)
        ._CUACCT = WrkListNo
        WrkName = ds2.Tables(0).Rows(0).Item("cs_name1") & ""
        If WrkName = "" Then
          Continue For
        End If
        WrkName2 = ds2.Tables(0).Rows(0).Item("cs_name2") & ""
        ._CUNAM1 = ConvertString("NAM1", WrkName, 35)
        ._CUNAM2 = ConvertString("NAM2", WrkName2, 35)
        ._CUADD1 = ConvertString("ADD1", ds2.Tables(0).Rows(0).Item("cs_address1") & "", 35)
        ._CUADD2 = ConvertString("ADD2", ds2.Tables(0).Rows(0).Item("cs_address2") & "", 35)
        ._CUCITY = ConvertString("CITY", ds2.Tables(0).Rows(0).Item("cs_city") & "", 25)
        ._CUST = ds2.Tables(0).Rows(0).Item("cs_state") & ""
        ._CUZIP = ds2.Tables(0).Rows(0).Item("cs_zip") & ""
        ._CUMAD1 = ""
        ._CUMAD2 = ""
        ._CUMCTY = ""
        ._CUMST = ""
        ._CUMZIP = ""
        ._CUTELNO = ""
        ._CUDST = MyUTCUST._CUDST
        ._CUPHAS = 0
        ._CUADDX = ""
        ._CUTIE = 0
        ._CUMAP = ""
        ._CUVOLM = ""
        ._CUPAGE = ""
        ._CUZONE = ""
        ._CUPCAT = ""
        ._CUXREF = ""
        ._CUMSIZ = ""
        ._CYC = ""
        ._OID = ""
        ._CUSERN = ""
        ._CUROUT = ""
        ._CUMETN = WrkMeter
        ._CUMETP = ""
        ._CUREGN = ""
        ._CULOCNO = MyUTCUST._CULOCNO
        ._CULOC = MyUTCUST._CULOC
        ._CUCNTNO = WrkMunCid
        ._CUAPLNO = ""
        ._CUFUND = 0
        ._CUSECT = ""
        ._CUSDES = ""
        ._LOGCMT = ""
        ._LOGDTE = Counter
        ._LOGTIM = 0
        .AddOneRecordP()
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
  Private Sub BuildXref(ByVal WrkAcct As Integer, ByVal WrkListNo As Integer)

    If Not AcctXref.ContainsKey(WrkAcct) Then
      AcctXref(WrkAcct) = New List(Of Integer)()
    End If

    AcctXref(WrkAcct).Add(WrkListNo)
  End Sub
  Private Function FindXref(ByVal WrkAcct As Integer) As Integer
    For Each kvp In AcctXref
      Dim acct As Integer = kvp.Key
      Dim lists As List(Of Integer) = kvp.Value

      For Each n In lists
        If acct = WrkAcct Then
          Return n
        End If
      Next
    Next
    Return 0
  End Function
  Private Function ConvertString(ByVal WrkField As String, ByVal WrkStr As String, ByVal WrkLen As Integer) As String

    Dim ReturnStr As String
    WrkStr = Trim(WrkStr)
    WrkStr = Replace(WrkStr, "'", "")
    ReturnStr = Mid(WrkStr, 1, WrkLen)
    If Len(WrkStr) > WrkLen Then
      sw.WriteLine("Truncate," & WrkFile & "," & WrkListNo & "," & WrkField & "," & WrkStr & "," & ReturnStr)
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
  Private Function ConvertRate(WrkServiceCd As Integer, WrkRateCd As Integer) As (Meter As String, Code As String)

    Select Case WrkServiceCd
      Case 1000, 1500
        Select Case WrkRateCd
          Case 210
            Return ("RES", "RES")
          Case 211
            Return ("RE1", "RES")
          Case 212
            Return ("RE2", "RES")
          Case 213
            Return ("REA", "RES")
          Case 220, 240
            Return ("COM", "COM")
          Case 230
            Return ("IND", "IND")
          Case 290
            Return ("MUN", "COM")
        End Select
      Case 2000
        Select Case WrkRateCd
          Case 210
            Return ("WRE", "WEL")
          Case 211
            Return ("WE1", "WEL")
          Case 212
            Return ("WE2", "WEL")
          Case 220, 240
            Return ("WCO", "WEL")
          Case 230
            Return ("WIN", "WEL")
          Case 290
            Return ("WMU", "WEL")
        End Select
      Case 2500 : Return ("CHG", WrkRateCd.ToString())
      Case 3000 : Return ("PLN", "PLN")
      Case 4000 : Return ("MER", "MER")
      Case 5000 : Return ("GRO", "GRO")
      Case 9028, 9029, 9032, 9033
        Return ("", "")
      Case Else
        Return ("", "")
    End Select
    Return ("", "")
  End Function
  Private Function ConvertLoc(ByVal WrkLoc As String) As String
    WrkLoc = Replace(WrkLoc, "TERRACE", "TERR")
    WrkLoc = Replace(WrkLoc, "TER", "TERR")
    WrkLoc = Replace(WrkLoc, "TERRR", "TERR")
    WrkLoc = Replace(WrkLoc, "WDS", "WOODS")
    WrkLoc = Replace(WrkLoc, "MERIDEN WATERRBURY TPKE", "MERIDEN WATERBURY TPKE")
    WrkLoc = Replace(WrkLoc, "CENTERR", "CENTER")
    WrkLoc = Replace(WrkLoc, "PONDVIEW", "POND VIEW")
    WrkLoc = Replace(WrkLoc, "SOUTH FARM ", "SOUTH FARMS ")
    WrkLoc = Replace(WrkLoc, "WALKERS XING", "WALKERS CROSSING")
    Return WrkLoc
  End Function
  Private Function TrimAfterStreetSuffix(address As String) As String
    If String.IsNullOrWhiteSpace(address) Then Return address

    ' Common US street suffixes (add/remove as needed)
    Dim suffixes As String =
        "ALY|AV|AVE|BLVD|CIR|CT|DR|HWY|LN|PKWY|PL|PLZ|RD|SQ|ST|TER|TRL|WAY"

    ' Pattern:
    ' Start → any chars → space → suffix → optional period → stop
    Dim pattern As String =
        "\b(.+?\s(" & suffixes & ")\.?)\b"

    Dim match As Match = Regex.Match(address.ToUpper(), pattern)

    If match.Success Then
      Return match.Groups(1).Value.Trim()
    Else
      Return address.Trim() ' Return original if no suffix found
    End If
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
  Public Function FlipName(inputName As String) As String
    Dim name As String = inputName.Trim()

    '---- 1. Detect businesses (NO FLIP) ----
    Dim businessKeywords() As String = {
        "LLC", "INC", "CO", "CORP", "COMPANY", "LTD", "LLP"
    }

    For Each word In businessKeywords
      If name.ToUpper().Contains(" " & word) Then
        Return name   ' Business name → do not flip
      End If
    Next

    '---- 2. Detect couples: "John & Mary Smith" ----
    Dim normalized As String = name.Trim()

    ' Normalize delimiters
    normalized = normalized.Replace(" AND ", " & ")
    normalized = normalized.Replace(",", " & ")

    Dim suffixes() As String = {"JR", "SR", "II", "III", "IV"}

    ' Split owners
    Dim owners() As String = normalized.Split("&"c)
    Dim cleanedOwners As New List(Of String)
    For Each o In owners
      If o.Trim() <> "" Then cleanedOwners.Add(o.Trim())
    Next

    ' Extract last names
    Dim lastNames As New List(Of String)
    Dim firstNames As New List(Of String)

    Dim Owner As String
    For Each Owner In cleanedOwners
      Dim words() As String = Owner.Split(" "c)
      If words.Length = 0 Then Continue For

      ' Handle suffix
      Dim suffix As String = ""
      Dim lastNameIndex As Integer = words.Length - 1
      If suffixes.Contains(words(lastNameIndex).ToUpper()) AndAlso words.Length >= 2 Then
        suffix = " " & words(lastNameIndex)
        lastNameIndex -= 1
      End If

      Dim lastName As String = words(lastNameIndex)
      Dim firstName As String = String.Join(" ", words, 0, lastNameIndex)

      lastNames.Add(lastName & suffix)
      firstNames.Add(firstName)
    Next

    ' Check if all last names are the same
    Dim allSame As Boolean = lastNames.Distinct(StringComparer.OrdinalIgnoreCase).Count() = 1

    If allSame Then
      ' Combine first names
      Return lastNames(0) & ", " & String.Join(" & ", firstNames)
    Else
      ' Keep each owner separately
      Dim result As New List(Of String)
      For i As Integer = 0 To cleanedOwners.Count - 1
        result.Add(lastNames(i) & ", " & firstNames(i))
      Next
      Return String.Join(" & ", result)
    End If

    '---- 3. Standard names: single person ----
    Dim p() As String = name.Split(" "c)
    If p.Length < 2 Then Return name ' single word → no flip

    Dim ln As String = p(p.Length - 1)                    ' last name
    Dim fn As String = String.Join(" ", p, 0, p.Length - 1) ' first + middle

    Return ln & ", " & fn
  End Function
  Public Function JustifyRight(ByVal StrInput As String, ByVal MaxLength As Integer,
  Optional ByVal StrPadChar As String = " ") As String
    'Right justify a string and pad to left. If it's too big then chop it at max length.
    Dim InputLength As Integer
    Dim StrOutput As String
    InputLength = Len(StrInput)
    StrOutput = StrInput
    If InputLength > MaxLength Then 'Error
      Return Mid(StrInput, 1, MaxLength)
    End If

    Do Until InputLength = MaxLength
      StrOutput = StrPadChar & StrOutput
      InputLength = InputLength + 1
    Loop
    Return StrOutput
  End Function
End Class