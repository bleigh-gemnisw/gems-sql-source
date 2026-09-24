Imports System.Text
Imports System.IO
Imports System.Data.SqlClient
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
    WrkTimeStamp = Format(Date.Now, "MMddyyyy HHmmss")
    sw = New StreamWriter(GetDataPath() & "TestQDS-" & WrkTimeStamp & ".csv")
    ProgBar1.Visible = True
    WrkGLYear = CnvSng(TxtGLYear.Text)
    MyGLYear = CnvSng(TxtGLYear.Text)
    MyTOWN = New TOWN(myDBConnectGEMS.MyConn2)
    MyMVChgDate = "#1/31/" & MyGLYear & "#"
    With MyTOWN
      .GetOneRecordP(1)
    End With
    TxtErrorMsg.Text = TxtErrorMsg.Text & "TXINVO" & vbCrLf
    BufferProf() 'Tax Profile
    'TestINV() 'Invoice file
    WriteINV() 'Invoice file
    sw.Flush()
    sw.Close()
    ProgBar1.Visible = False
    LblMsg.Text = ""
    TxtErrorMsg.Text = TxtErrorMsg.Text & " DONE"
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
    Dim WrkRecID As Long
    Dim WrkFields As String
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer
    Dim J As Integer

    MyTXINV = New TXINV(myDBConnectGEMS.MyConn2)
    MyTXCOEA = New TXCOEA(myDBConnectGEMS.MyConn2)
    MyTXHST = New TXHST(myDBConnectGEMS.MyConn2) 'Only for Liens
    myDBConnectGEMS.DeleteRecords2("TXINVO", " where year=2020")
    myDBConnectGEMS.DeleteRecords2("TXCOEAO", " where year=2020")
    myDBConnectGEMS.DeleteRecords2("TXHSTO", " where rcode='I' and year=2020")
    myDBConnect.OpenQry("TAXMAST", " where yr=2020")
    'myDBConnect.OpenQry("TAXMAST", "")
    WrkFile = "TXINV"
    WrkFields = ""
    sw.WriteLine(WrkFile & "," & Date.Now)

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
          If myDBConnect.objReader.Item("suspense_flag") = "Y" Then
            ._ICODE = "S"
            ._SUSCD = "S"
            ._SUSDT = ConvertDate(myDBConnect.objReader.Item("transfer_date"))
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
            ._STCD1 = "Y"
          Else
            ._STCD1 = ""
          End If
          ._STCD2 = ""
          ._STCD3 = ""
          ._STCD4 = ""
          ._STCD5 = ""
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
    sw.WriteLine(WrkFile & "," & Date.Now)
  End Sub
  Private Sub TestINV()
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
    Dim WrkRecID As Long
    Dim dsBulk As DataSet = New DataSet
    Dim dtTemp As DataTable
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer
    Dim J As Integer

    MyTXINV = New TXINV(myDBConnectGEMS.MyConn2)
    MyTXCOEA = New TXCOEA(myDBConnectGEMS.MyConn2)
    MyTXHST = New TXHST(myDBConnectGEMS.MyConn2)
    myDBConnectGEMS.DeleteRecords2("TXINVO", " where type='M' and year=2020")
    myDBConnectGEMS.DeleteRecords2("TXCOEAO", " where type='M' and year=2020")
    myDBConnectGEMS.DeleteRecords2("TXHSTO", " where rcode='I' and type='M' and year=2020")
    myDBConnect.OpenQry("TAXMAST", " where bill_type=3 And yr=2020")
    'myDBConnect.OpenQry("TAXMAST", "")
    WrkFile = "TXINV"
    sw.WriteLine(WrkFile & "," & Date.Now)

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
            ._STCD1 = "Y"
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
          ds3 = myDBConnect3.RunQuery("COC_DATA", "where grand_list_year=" & WrkYear & " And bill_type=" &
          myDBConnect.objReader.Item("bill_type") & " And bill_number=" & WrkListNo & " Order By coc_date")
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
                    '.AddOneRecordP()
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
          '.InsertOneRecordP()
          dtTemp = .AddBulk()
          If dsBulk.Tables.Count = 0 Then
            dsBulk.Tables.Add(dtTemp.Clone)
          End If
          dsBulk.Tables(0).Rows.Add(dtTemp.Rows)
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
    MyTXINV.AddBulkRecords(dsBulk.Tables(0))
    sw.WriteLine(WrkFile & "," & Date.Now)
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
End Class