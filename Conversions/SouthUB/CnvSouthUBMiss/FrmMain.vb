Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing.Reader
Imports System.IO
Imports System.Net.WebRequestMethods
Imports System.Reflection
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
  Dim MyTXPROF As TXPROF
  Dim MyTXINV As TXINV
  Dim MyTXHST As TXHST
  Dim MyUTCUST As UTCUST
  Dim MyUTCUSTMT As UTCUSTMT
  Dim MyUTCUSTRT As UTCUSTRT
  Dim MyUTXREF As UTXREF
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
    sw = New StreamWriter(GetDataPath() & "CnvSouthUBMiss-" & WrkTimeStamp & ".csv")
    ProgBar1.Visible = True
    MyTOWN = New TOWN(myDBConnectGEMS.MyConn2)
    With MyTOWN
      .GetOneRecordP(1)
    End With
    Missing7()
    'MissTXINV()
    'MissTXHST()
    sw.Flush()
    sw.Close()
    ProgBar1.Visible = False
    LblMsg.Text = ""
    TxtErrorMsg.Text = TxtErrorMsg.Text & " DONE"
  End Sub
  Private Sub DoNotRun()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "UTCUST/RT" & vbCrLf
    'WriteUTCUST()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "UTCUSTMT" & vbCrLf
    'WriteUTCUSTMT() 'UB Meter Readings
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXINV" & vbCrLf
    'WriteINV() 'Invoice file
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TXHST" & vbCrLf
    'WriteHST() 'History file
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "Miss UTCUSTRT" & vbCrLf
    'MissUTCUSTRT()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "Missing4" & vbCrLf
    'MissUTCUSTMT()
    'MissTXINV()
    'MissTXHST()
    'Missing5()
    'x TxtErrorMsg.Text = TxtErrorMsg.Text & "TXINV Fee" & vbCrLf
    'x WriteINVFee()
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
    myDBConnectGEMS2 = New DBConnection()
    myDBConnectGEMS2.Open2()
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
    Dim WrkOldYear As Integer
    Dim WrkMunAcct As String
    Dim WrkMunCid As Integer
    Dim WrkBillNo As Integer
    Dim WrkInstallNo As Integer
    Dim WrkPrinPaid As Decimal
    Dim WrkIntPaid As Decimal
    Dim WrkLastPaid As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer
    Dim J As Integer

    MyTXINV = New TXINV(myDBConnectGEMS2.MyConn2)
    myDBConnectGEMS.DeleteRecords2("TXINV", "where prf='Missing'")
    myDBConnectGEMS.OpenQry2("UTCUST", "where oid='Missing'")
    WrkFile = "TXINV"
    WrkType = "D"
    WrkOldYear = 2012 '15 Years

ReadNext:
    myDBConnectGEMS.ReadQry()
    If Not myDBConnectGEMS.IsEOF Then
      With MyTXINV
        Counter = Counter + 1
        WrkListNo = myDBConnectGEMS.objReader.Item("cuacct")
        WrkMunAcct = Trim(myDBConnectGEMS.objReader.Item("cumetn"))
        WrkMunCid = myDBConnectGEMS.objReader.Item("cucnt#")
        ds2 = myDBConnect.RunQuery("ub_bill_header", "where a_acct=" & WrkMunCid & "and a_account='" & WrkMunAcct & "' and bh_bill_amount<>0")
        For I = 0 To ds2.Tables(0).Rows.Count - 1
          WrkYear = ds2.Tables(0).Rows(I).Item("a_bill_year")
          If WrkYear < WrkOldYear Then
            Continue For
          End If
          .GetOneRecordP(WrkListNo, WrkYear, WrkType)
          WrkInstallNo = CalcInstallNo(myDBConnectGEMS.objReader.Item("cudst"), ds2.Tables(0).Rows(I).Item("bh_bill_date1"))
          ._ADD1 = myDBConnectGEMS.objReader.Item("cuadd1")
          ._ADD2 = myDBConnectGEMS.objReader.Item("cuadd2")
          ._CITY = myDBConnectGEMS.objReader.Item("cucity")
          ._DIST = myDBConnectGEMS.objReader.Item("cudst")
          ._LETT = Mid(myDBConnectGEMS.objReader.Item("cunam1"), 1, 1)
          ._LISTNo = WrkListNo
          ._LOC = myDBConnectGEMS.objReader.Item("culoc")
          ._LOCNo = myDBConnectGEMS.objReader.Item("culoc#")
          ._NAME = myDBConnectGEMS.objReader.Item("cunam1")
          ._SNAME = myDBConnectGEMS.objReader.Item("cunam2")
          ._STATE = myDBConnectGEMS.objReader.Item("cust")
          ._TXIDT = 0
          ._TYPE = WrkType
          ._YEAR = WrkYear
          ._ZIP5 = CnvSng(Mid(myDBConnectGEMS.objReader.Item("cuzip"), 1, 5))
          ._ZIP4 = 0
          If Len(myDBConnectGEMS.objReader.Item("cuzip")) > 5 Then
            ._ZIP4 = CnvSng(Mid(myDBConnectGEMS.objReader.Item("cuzip"), 7, 4))
          End If
          WrkPrinPaid = 0
          WrkIntPaid = 0
          WrkLastPaid = 0
          WrkBillNo = ds2.Tables(0).Rows(I).Item("a_bill_number")
          ds3 = myDBConnect.RunQuery("ub_bill_detail", "where a_acct=" & WrkMunCid & " and a_bill_number=" & WrkBillNo & " and bd_paid_amount<>0")
          For J = 0 To ds3.Tables(0).Rows.Count - 1
            If ds3.Tables(0).Rows(J).Item("bd_original_amount") <> 0 Then
              WrkPrinPaid = WrkPrinPaid + ds3.Tables(0).Rows(J).Item("bd_paid_amount")
              WrkLastPaid = ConvertDate(ds3.Tables(0).Rows(J).Item("bd_last_activity"))
            End If
            If ds3.Tables(0).Rows(J).Item("bd_adjust_amount") <> 0 And CnvSng(ds3.Tables(0).Rows(J).Item("a_serv_code")) = 100000 Then 'Lien Payment
              WrkPrinPaid = WrkPrinPaid + ds3.Tables(0).Rows(J).Item("bd_paid_amount")
              WrkLastPaid = ConvertDate(ds3.Tables(0).Rows(J).Item("bd_last_activity"))
            End If
            If CnvSng(ds3.Tables(0).Rows(J).Item("a_serv_code")) = 91000 Then 'Interest
              WrkIntPaid = WrkIntPaid + ds3.Tables(0).Rows(J).Item("bd_paid_amount")
            End If
          Next
          ._TXIDT = WrkLastPaid
          If .RecordNotFound Then
            ._TAX1 = 0
            ._TAX2 = 0
            ._TX3RD = 0
            ._TX4TH = 0
            Select Case WrkInstallNo
              Case 1
                ._TAX1 = ds2.Tables(0).Rows(I).Item("bh_bill_amount")
              Case 2
                ._TAX2 = ds2.Tables(0).Rows(I).Item("bh_bill_amount")
              Case 3
                ._TX3RD = ds2.Tables(0).Rows(I).Item("bh_bill_amount")
              Case 4
                ._TX4TH = ds2.Tables(0).Rows(I).Item("bh_bill_amount")
            End Select
            ._TAXT = ._TAX1 + ._TAX2 + ._TX3RD + ._TX4TH
            ._PAYREC = WrkPrinPaid
            ._BALD = ._TAXT - ._PAYREC
            ._INTPD = WrkIntPaid
            ._PRF = "Missing"
            .InsertOneRecordP()
          Else
            If Trim(._PRF) = "Missing" Then
              Select Case WrkInstallNo
                Case 1
                  ._TAX1 = ._TAX1 + ds2.Tables(0).Rows(I).Item("bh_bill_amount")
                Case 2
                  ._TAX2 = ._TAX2 + ds2.Tables(0).Rows(I).Item("bh_bill_amount")
                Case 3
                  ._TX3RD = ._TX3RD + ds2.Tables(0).Rows(I).Item("bh_bill_amount")
                Case 4
                  ._TX4TH = ._TX4TH + ds2.Tables(0).Rows(I).Item("bh_bill_amount")
              End Select
              ._TAXT = ._TAX1 + ._TAX2 + ._TX3RD + ._TX4TH
              ._PAYREC = ._PAYREC + WrkPrinPaid
              ._BALD = ._TAXT - ._PAYREC
              ._INTPD = ._INTPD + WrkIntPaid
              .UpdateOneRecordP()
            End If
          End If
        Next
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

    ds2 = Nothing
  End Sub
  Private Function CalcInstallNo(ByVal WrkDist As Integer, ByVal WrkDate As Date) As Integer
    Dim WrkInstallNo As Integer
    Dim WrkMonth As Integer
    Dim WrkMonths As Integer

    WrkMonth = Month(WrkDate) 'Bill Date
    If WrkMonth < 7 Then 'Billing period is July to June
      WrkMonth = WrkMonth + 12
    End If
    Select Case WrkDist 'Calc how many months have passed
      Case 1 '1st period is August
        WrkMonths = WrkMonth - 7
      Case 2, 5 '1st period is September
        WrkMonths = WrkMonth - 8
      Case 3 '1st period is July
        WrkMonths = WrkMonth - 6
      Case 4 '1st period is November
        WrkMonths = WrkMonth - 10
      Case 6 'Annual bill
        WrkMonths = 1
    End Select

    Select Case WrkMonths
      Case 1, 2, 3
        WrkInstallNo = 1
      Case 4, 5, 6
        WrkInstallNo = 2
      Case 7, 8, 9
        WrkInstallNo = 3
      Case 10, 11, 12
        WrkInstallNo = 4
    End Select

    Return WrkInstallNo
  End Function
  Private Sub WriteHST()
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim ds3 As DataSet = New DataSet
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkMunCid As Integer
    Dim WrkMeter As String
    Dim WrkMunBillNo As Integer
    Dim SaveBillNo As Integer
    Dim WrkPrin As Decimal
    Dim WrkInt As Decimal
    Dim I As Integer
    Dim J As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Integer
    Dim WrkRecID As Integer
    MyTXHST = New TXHST(myDBConnectGEMS2.MyConn2)
    myDBConnectGEMS.DeleteRecords2("TXHST", "where prf='Missing'")
    ds = myDBConnectGEMS.RunQuery2("UTCUST", "where oid='Missing'")
    WrkFile = "TXHST"
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTXHST
        Counter = Counter + 1
        WrkType = "D"
        WrkListNo = ds.Tables(0).Rows(I).Item("cuacct")
        WrkMunCid = ds.Tables(0).Rows(I).Item("cucnt#")
        WrkMeter = ds.Tables(0).Rows(I).Item("cumetn")
        ds2 = myDBConnect.RunQuery("ar_history_header", "where a_account=" & WrkMunCid & " and a_property_code='" & WrkMeter & "' order by a_bill_number")
        For J = 0 To ds2.Tables(0).Rows.Count - 1
          WrkYear = ds2.Tables(0).Rows(J).Item("a_bill_year")
          WrkMunBillNo = ds2.Tables(0).Rows(J).Item("a_bill_number")
          If WrkMunBillNo = SaveBillNo Then
            Continue For
          End If
          SaveBillNo = WrkMunBillNo
          ds3 = myDBConnect.RunQuery("ar_history_detail", "where a_ar_customer_cid=" & WrkMunCid & " And a_bill_number=" & WrkMunBillNo & " And a_bill_year=" & WrkYear &
           " And bd_paid_amount<>0")
          ' Dictionary to group and sum by date
          Dim dict As New Dictionary(Of Date, (IAMT As Decimal, PAMT As Decimal, Rows As List(Of DataRow)))()
          For Each row As DataRow In ds3.Tables(0).Rows
            Dim postDate As Date = row("bd_last_activity")
            WrkPrin = 0
            WrkInt = 0
            If row("bd_original_amount") <> 0 Then
              WrkPrin = row("bd_paid_amount")
            End If
            If CnvSng(row("a_charge_code")) = 0 Then
              Continue For
            End If
            If CnvSng(row("a_charge_code")) = 100000 Then 'Lien Payment
              WrkPrin = row("bd_paid_amount")
            End If
            If CnvSng(row("a_charge_code")) = 91000 Then 'Interest
              WrkInt = row("bd_paid_amount")
            End If

            ' Add to dictionary
            If dict.ContainsKey(postDate) Then
              dict(postDate) = (dict(postDate).IAMT + WrkInt, dict(postDate).PAMT + WrkPrin, dict(postDate).Rows)
              dict(postDate).Rows.Add(row)
            Else
              dict(postDate) = (WrkInt, WrkPrin, New List(Of DataRow)() From {row})
            End If
          Next

          ' Now insert one record per posting date with sums
          For Each kvp In dict
            Dim postDate As Date = kvp.Key
            Dim sumIAMT As Decimal = kvp.Value.IAMT
            Dim sumPAMT As Decimal = kvp.Value.PAMT
            Dim rows As List(Of DataRow) = kvp.Value.Rows

            ' Use the first row in the group for other fields like hh_batch, a_effective_date
            Dim firstRow As DataRow = rows(0)
            WrkRecID = WrkRecID + 1
            ' Initialize your record
            If sumPAMT >= 0 Then
              ._ADJCD = ""
            Else
              ._ADJCD = "A"
            End If
            ._BATCHA = ""
            ._BATCHN = 0 'ds2.Tables(0).Rows(J).Item("hh_batch")
            ._BATCHS = 0
            ._CASH = 0
            ._CDATE = ConvertDate(firstRow("bd_last_activity"))
            ._CHDATE = ConvertDate(postDate)
            ._CHECK = 0
            ._CHTIME = 0
            ._CORC = ""
            ._CREDIT = 0
            ._DIST = ds.Tables(0).Rows(I).Item("cudst")
            ._IAMT = sumIAMT
            ._INTOR = 0
            ._LAMT = 0
            ._LISTNO = WrkListNo
            ._PAMT = sumPAMT
            ._PCAMT = 0
            ._PDATE = ConvertDate(postDate)
            ._PENCD = ""
            ._RCODE = ""
            ._RECID = WrkRecID
            ._REF = ""
            ._SUSCD = ""
            ._THAJCD = ""
            ._THINPD = 0
            ._TYPE = WrkType
            ._YEAR = WrkYear
            ._PRF = "Missing"
            .InsertOneRecordP()
          Next
        Next
      End With

NextRec:
      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed:  " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next

    ds = Nothing
  End Sub
  Private Sub WriteINVFee()
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkOldYear As Integer
    Dim WrkMunCid As Integer
    Dim WrkFee As Decimal
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer

    MyTXINV = New TXINV(myDBConnectGEMS2.MyConn2)
    ds = myDBConnect.RunQuery("ub_bill_detail", "where bd_adjust_amount>0 and a_serv_code>=700000 and bd_adjust_amount<>bd_paid_amount order by a_acct,a_bill_year,a_bill_number")
    WrkFile = "TXINV"
    WrkType = "D"
    WrkOldYear = 2012 '15 Years

ReadNext:
    For I = 0 To ds.Tables(0).Rows.Count - 1
      Counter = Counter + 1
      WrkYear = ds.Tables(0).Rows(I).Item("a_bill_year")
      WrkMunCid = ds.Tables(0).Rows(I).Item("a_acct")
      WrkFee = ds.Tables(0).Rows(I).Item("bd_adjust_amount") - ds.Tables(0).Rows(I).Item("bd_paid_amount")
      If WrkFee < 0 Then
        GoTo NextRec
      End If
      ds2 = myDBConnectGEMS.RunQuery2("utcust", "where cucnt#=" & WrkMunCid)
      If ds2.Tables(0).Rows.Count <> 1 Then
        sw.WriteLine("Error,NO unique match," & WrkMunCid & "," & WrkFee & ",,")
        GoTo NextRec
      End If
      WrkListNo = ds2.Tables(0).Rows(0).Item("CUACCT")

      With MyTXINV
        If WrkYear < WrkOldYear Then
          Continue For
        End If
        .GetOneRecordP(WrkListNo, WrkYear, WrkType)
        ._FEC1 = "FE"
        ._FED1 = ._FED1 + WrkFee
        '.UpdateOneRecordP()
        sw.WriteLine(",Matched," & WrkMunCid & "," & WrkFee & "," & WrkListNo & "," & WrkYear)
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

    ds2 = Nothing
  End Sub
  Private Sub WriteUTCUST()
    Dim dsfile As DataSet = New DataSet
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim ds3 As DataSet = New DataSet
    Dim ds4 As DataSet = New DataSet
    Dim dstemp As DataSet = New DataSet
    Dim WrkMunCid As Integer
    Dim Good As Boolean
    Dim WrkStatus As String
    Dim WrkMunACMKey As Integer
    Dim WrkMunACDKey As Integer
    Dim WrkAcct As Integer
    Dim WrkRateCd As Integer
    Dim WrkServiceCd As Integer
    Dim WrkMeterSize As String
    Dim WrkMeter As String
    Dim WrkCode As String
    Dim WrkName As String
    Dim WrkName2 As String
    Dim WrkMap As String
    Dim WrkLoc As String
    Dim WrkLocNo As String
    Dim WrkLocSuff As String
    Dim WrkServDesc As String
    Dim WrkNewList As Integer
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
    myDBConnectGEMS.DeleteRecords2("UTCUST", " where oid='Missing'")
    WrkNewList = 200000 'Starting list# for unmatched Accounts

    dsfile = myDBConnectGEMS.RunQuery2("missing", "")
    For I = 0 To dsfile.Tables(0).Rows.Count - 1
      With MyUTCUST
        Counter = Counter + 1
        WrkMunCid = dsfile.Tables(0).Rows(I).Item("cid")
        ds = myDBConnect.RunQuery("ub_customers", "where a_customer=" & WrkMunCid)
        ds2 = myDBConnect.RunQuery("utactcid", "where utacd_cid=" & WrkMunCid & " order by utacd_account")
        If ds2.Tables(0).Rows.Count = 0 Then
          sw.WriteLine("skip,utactid not found " & WrkMunCid)
          Continue For
        End If
        WrkMunACMKey = 0
        WrkMunACDKey = 0
        WrkMeter = ""
        Good = False
        WrkStatus = ""
        For J = 0 To ds2.Tables(0).Rows.Count - 1
          If ds2.Tables(0).Rows(J).Item("utacd_stop_date") <> "9999-12-31 00:00:00.000" Then
            WrkStatus = "I" 'Inactive
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
          sw.WriteLine("skip,utactid missing " & WrkMunCid)
          Continue For
        End If
        If Not Good Then
          sw.WriteLine("skip,utsvcmst missing " & WrkMunCid)
          Continue For
        End If
        WrkAcct = 0
        WrkServDesc = ConvertString("servdesc", ds3.Tables(0).Rows(0).Item("utacm_prop_desc"), 35)
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
          WrkAcct = WrkNewList
          WrkNewList = WrkNewList + 1
        End If

Retry:
        WrkRateCd = 0
        WrkServiceCd = 0
        WrkMeterSize = ""
        WrkCode = ""
        .GetOneRecordP(WrkAcct)
        If .RecordNotFound Then
          dstemp = myDBConnect.RunQuery("utsvcmst", "where utsvm_utacd_key=" & WrkMunACDKey & " and utsvm_rate_code<>'900'", "utsvm_serv_code, utsvm_rate_code")
          For J = 0 To dstemp.Tables(0).Rows.Count - 1
            WrkRateCd = dstemp.Tables(0).Rows(J).Item("utsvm_rate_code")
            WrkServiceCd = dstemp.Tables(0).Rows(J).Item("utsvm_serv_code")
          Next

          Dim result = ConvertRate(WrkServiceCd, WrkRateCd)
          WrkMeterSize = result.Meter
          WrkCode = result.Code
          'If ds.Tables(0).Rows(I).Item("cs_nh_sw") = "E" Then
          '  WrkBusiness = True
          'Else
          '  WrkBusiness = False
          'End If
          ._CUACCT = WrkAcct
          'If WrkBusiness Then
          WrkName = ds.Tables(0).Rows(0).Item("cs_name1") & ""
          If WrkName = "" Then
            Continue For
          End If
          WrkName2 = ds.Tables(0).Rows(0).Item("cs_name2") & ""
          'Else
          'WrkName = FlipName(ds.Tables(0).Rows(I).Item("cs_name1"))
          'WrkName2 = FlipName(ds.Tables(0).Rows(I).Item("cs_name2"))
          'Ed If
          ._CUNAM1 = ConvertString("NAM1", WrkName, 35)
          ._CUNAM2 = ConvertString("NAM2", WrkName2, 35)
          ._CUADD1 = ConvertString("ADD1", ds.Tables(0).Rows(0).Item("cs_address1") & "", 35)
          ._CUADD2 = ConvertString("ADD2", ds.Tables(0).Rows(0).Item("cs_address2") & "", 35)
          ._CUCITY = ConvertString("CITY", ds.Tables(0).Rows(0).Item("cs_city") & "", 25)
          ._CUST = ds.Tables(0).Rows(0).Item("cs_state") & ""
          ._CUZIP = ds.Tables(0).Rows(0).Item("cs_zip") & ""
          ._CUMAD1 = ""
          ._CUMAD2 = ""
          ._CUMCTY = ""
          ._CUMST = ""
          ._CUMZIP = ""
          ._CUTELNO = ConvertString("Telno", ds.Tables(0).Rows(0).Item("cs_phone"), 15)
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
          ._OID = "Missing"
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
          ._CUSDES = WrkServDesc
          ._RCODE = WrkStatus
          .AddOneRecordP()
          If .ErrMsg <> String.Empty Then
            sw.WriteLine("Error, UTCUST " & WrkAcct & " " & .ErrMsg)
          End If
        Else
          WrkNewList = WrkNewList + 1
          WrkAcct = WrkNewList 'Change List # and retry
          GoTo Retry
        End If
      End With

      WriteUTCUSTRT(WrkAcct, WrkCode)

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed:  " & Counter
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
      Else
        ._CRCODE = WrkCode
        .UpdateOneRecordP()
      End If
    End With
  End Sub
  Private Sub WriteUTCUSTMT()
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkMunCid As Integer
    Dim WrkMeter As String
    Dim WrkDate As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer

    MyUTCUST = New UTCUST(myDBConnectGEMS.MyConn2)
    MyUTCUSTMT = New UTCUSTMT(myDBConnectGEMS2.MyConn2)
    myDBConnectGEMS.DeleteRecords2("UTCUSTMT", "where cmresn='M'")
    myDBConnectGEMS.OpenQry2("UTCUST", "where cumetn<>'' and cumsiz not like 'W%'")

ReadNext:
    myDBConnectGEMS.ReadQry()
    If Not myDBConnectGEMS.IsEOF Then
      With MyUTCUSTMT
        Counter = Counter + 1
        WrkListNo = myDBConnectGEMS.objReader.Item("cuacct")
        WrkMunCid = myDBConnectGEMS.objReader.Item("cucnt#")
        WrkMeter = Trim(myDBConnectGEMS.objReader.Item("cumetn"))
        ds2 = .GetLastbyDate(WrkListNo, "", 99999999)
        If ds2.Tables(0).Rows.Count > 0 Then
          GoTo ShowPct
        End If
        ds = myDBConnect.RunQuery("utbilmtr", " where utbmt_account='" & WrkMeter & "' and utbmt_read_date>='2023-01-01'")
        For I = 0 To ds.Tables(0).Rows.Count - 1
          WrkDate = ConvertDate(ds.Tables(0).Rows(I).Item("utbmt_read_date"))
          .GetOneRecordP(WrkListNo, "", WrkDate)
          If .RecordNotFound Then
            ._CMACCT = WrkListNo
            ._CMDATE = WrkDate
            ._CMREAD = CnvSng(ds.Tables(0).Rows(I).Item("utbmt_act_usage"))
            ._CMRESN = "M"
            ._CMTYPE = ""
            ._CMUSE = CnvSng(ds.Tables(0).Rows(I).Item("utbmt_billed_usage"))
            If ._CMUSE > 0 Then
              .InsertOneRecordP()
              If .ErrMsg <> String.Empty Then
                sw.WriteLine("UTCUSTMT " & WrkListNo & " " & .ErrMsg)
              End If
            End If
          End If
        Next
      End With

ShowPct:
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
  Private Sub MissUTCUSTRT()
    Dim dsfile As DataSet = New DataSet
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim ds3 As DataSet = New DataSet
    Dim ds4 As DataSet = New DataSet
    Dim dstemp As DataSet = New DataSet
    Dim WrkMunCid As Integer
    Dim Good As Boolean
    Dim WrkStatus As String
    Dim WrkType As String
    Dim WrkMunACMKey As Integer
    Dim WrkMunACDKey As Integer
    Dim WrkAcct As Integer
    Dim WrkRateCd As Integer
    Dim WrkServiceCd As Integer
    Dim WrkMeterSize As String
    Dim WrkMeter As String
    Dim WrkCode As String
    Dim I As Integer
    Dim J As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal

    WrkType = "Z"
    MyUTCUST = New UTCUST(myDBConnectGEMS.MyConn2)
    MyUTCUSTRT = New UTCUSTRT(myDBConnectGEMS.MyConn2)
    myDBConnectGEMS.DeleteRecords2("UTCUSTRT", " where crtype='Z'")

    dsfile = myDBConnectGEMS.RunQuery2("utcust", "where oid='Manual2' and rcode='' or oid='Missing'  and rcode=''")
    For I = 0 To dsfile.Tables(0).Rows.Count - 1
      With MyUTCUSTRT
        Counter = Counter + 1
        WrkAcct = dsfile.Tables(0).Rows(I).Item("cuacct")
        WrkMunCid = dsfile.Tables(0).Rows(I).Item("cucnt#")
        ds = myDBConnect.RunQuery("ub_customers", "where a_customer=" & WrkMunCid)
        ds2 = myDBConnect.RunQuery("utactcid", "where utacd_cid=" & WrkMunCid & " order by utacd_account")
        If ds2.Tables(0).Rows.Count = 0 Then
          sw.WriteLine("skip,utactid not found " & WrkMunCid)
          Continue For
        End If
        WrkMunACMKey = 0
        WrkMunACDKey = 0
        WrkMeter = ""
        Good = False
        WrkStatus = ""
        For J = 0 To ds2.Tables(0).Rows.Count - 1
          If ds2.Tables(0).Rows(J).Item("utacd_stop_date") <> "9999-12-31 00:00:00.000" Then
            WrkStatus = "I" 'Inactive
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
          sw.WriteLine("skip,utactid missing " & WrkMunCid)
          Continue For
        End If
        If Not Good Then
          sw.WriteLine("skip,utsvcmst missing " & WrkMunCid)
          Continue For
        End If

Retry:
        WrkRateCd = 0
        WrkServiceCd = 0
        WrkMeterSize = ""
        WrkCode = ""
        .GetOneRecordP(WrkAcct, WrkType)
        If .RecordNotFound Then
          dstemp = myDBConnect.RunQuery("utsvcmst", "where utsvm_utacd_key=" & WrkMunACDKey & " and utsvm_rate_code<>'900'", "utsvm_serv_code, utsvm_rate_code")
          For J = 0 To dstemp.Tables(0).Rows.Count - 1
            WrkRateCd = dstemp.Tables(0).Rows(J).Item("utsvm_rate_code")
            WrkServiceCd = dstemp.Tables(0).Rows(J).Item("utsvm_serv_code")
          Next

          Dim result = ConvertRate(WrkServiceCd, WrkRateCd)
          WrkMeterSize = result.Meter
          WrkCode = result.Code
          ._CRACCT = WrkAcct
          ._CRTYPE = WrkType
          ._CRCODE = WrkCode
          .AddOneRecordP()
          If .ErrMsg <> String.Empty Then
            sw.WriteLine("Error, UTCUST " & WrkAcct & " " & .ErrMsg)
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
    Next
    ds = Nothing
  End Sub

  Private Sub MissUTCUSTMT()
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkMeter As String
    Dim WrkDate As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer

    MyUTCUSTMT = New UTCUSTMT(myDBConnectGEMS2.MyConn2)
    myDBConnectGEMS.DeleteRecords2("UTCUSTMT", "where cmresn='M'")
    myDBConnectGEMS.OpenQry2("Missing4", "where meter<>''")

ReadNext:
    myDBConnectGEMS.ReadQry()
    If Not myDBConnectGEMS.IsEOF Then
      With MyUTCUSTMT
        Counter = Counter + 1
        WrkListNo = myDBConnectGEMS.objReader.Item("listno")
        WrkMeter = Trim(myDBConnectGEMS.objReader.Item("meter"))
        ds2 = .GetLastbyDate(WrkListNo, "", 99999999)
        If ds2.Tables(0).Rows.Count > 0 Then
          GoTo ShowPct
        End If
        ds = myDBConnect.RunQuery("utbilmtr", " where utbmt_account='" & WrkMeter & "' and utbmt_read_date>='2023-01-01'")
        For I = 0 To ds.Tables(0).Rows.Count - 1
          WrkDate = ConvertDate(ds.Tables(0).Rows(I).Item("utbmt_read_date"))
          .GetOneRecordP(WrkListNo, "", WrkDate)
          If .RecordNotFound Then
            ._CMACCT = WrkListNo
            ._CMDATE = WrkDate
            ._CMREAD = CnvSng(ds.Tables(0).Rows(I).Item("utbmt_act_usage"))
            ._CMRESN = "M"
            ._CMTYPE = ""
            ._CMUSE = CnvSng(ds.Tables(0).Rows(I).Item("utbmt_billed_usage"))
            If ._CMUSE > 0 Then
              .InsertOneRecordP()
              If .ErrMsg <> String.Empty Then
                sw.WriteLine("UTCUSTMT " & WrkListNo & " " & .ErrMsg)
              End If
            End If
          End If
        Next
      End With

ShowPct:
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
  Private Sub MissTXINV()
    Dim ds2 As DataSet = New DataSet
    Dim ds3 As DataSet = New DataSet
    Dim ds4 As DataSet = New DataSet
    Dim ds5 As DataSet = New DataSet
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkOldYear As Integer
    Dim WrkMunAcct As String
    Dim WrkMunCid As Integer
    Dim WrkBillNo As Integer
    Dim WrkInstallNo As Integer
    Dim WrkPrinPaid As Decimal
    Dim WrkIntPaid As Decimal
    Dim WrkLastPaid As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer
    Dim J As Integer

    MyUTCUST = New UTCUST(myDBConnectGEMS2.MyConn2)
    MyTXINV = New TXINV(myDBConnectGEMS2.MyConn2)
    myDBConnectGEMS.DeleteRecords2("TXINV", "where prf='Miss7'")
    myDBConnectGEMS.OpenQry2("Missing7", "")
    WrkFile = "TXINV"
    WrkType = "D"
    WrkOldYear = 2012 '15 Years

ReadNext:
    myDBConnectGEMS.ReadQry()
    If Not myDBConnectGEMS.IsEOF Then
      With MyTXINV
        Counter = Counter + 1
        WrkListNo = myDBConnectGEMS.objReader.Item("cuacct") 'listno")
        WrkMunAcct = myDBConnectGEMS.objReader.Item("cumetn")
        MyUTCUST.GetOneRecordP(WrkListNo)
        WrkMunCid = CnvSng(MyUTCUST._CUCNTNO)
        ds3 = myDBConnectGEMS2.RunQuery2("utcust", "where cucnt#=" & WrkMunCid & " and rcode=''")
        If ds3.Tables(0).Rows.Count = 1 Then
          WrkMunAcct = ""
        End If
        If WrkMunAcct = "" And WrkMunCid = 0 Then
          sw.WriteLine("TXINV " & WrkListNo & " no lookup")
          GoTo ReadNext
        End If
        If WrkMunAcct <> "" And WrkMunCid > 0 Then
          ds2 = myDBConnect.RunQuery("ub_bill_header", "where a_acct=" & WrkMunCid & " and a_account='" & WrkMunAcct & "' and bh_bill_amount<>0")
        Else
          If WrkMunAcct <> "" Then
            ds2 = myDBConnect.RunQuery("ub_bill_header", "where a_account='" & WrkMunAcct & "' and bh_bill_amount<>0")
          Else
            ds2 = myDBConnect.RunQuery("ub_bill_header", "where a_acct=" & WrkMunCid & " and bh_bill_amount<>0")
          End If
        End If
        For I = 0 To ds2.Tables(0).Rows.Count - 1
          WrkYear = ds2.Tables(0).Rows(I).Item("a_bill_year")
          If WrkYear < WrkOldYear Then
            Continue For
          End If
          .GetOneRecordP(WrkListNo, WrkYear, WrkType)
          WrkInstallNo = CalcInstallNo(MyUTCUST._CUDST, ds2.Tables(0).Rows(I).Item("bh_bill_date1"))
          ._ADD1 = Trim(MyUTCUST._CUADD1)
          ._ADD2 = Trim(MyUTCUST._CUADD2)
          ._CITY = Trim(MyUTCUST._CUCITY)
          ._DIST = MyUTCUST._CUDST
          ._LETT = Mid(MyUTCUST._CUNAM1, 1, 1)
          ._LISTNo = WrkListNo
          ._LOC = Trim(MyUTCUST._CULOC)
          ._LOCNo = MyUTCUST._CULOCNO
          ._NAME = Trim(MyUTCUST._CUNAM1)
          ._SNAME = Trim(MyUTCUST._CUNAM2)
          ._STATE = Trim(MyUTCUST._CUST)
          ._TXIDT = 0
          ._TYPE = WrkType
          ._YEAR = WrkYear
          ._ZIP5 = CnvSng(Mid(MyUTCUST._CUZIP, 1, 5))
          ._ZIP4 = 0
          If Len(Trim(MyUTCUST._CUZIP)) > 5 Then
            ._ZIP4 = CnvSng(Mid(MyUTCUST._CUZIP, 7, 4))
          End If
          WrkPrinPaid = 0
          WrkIntPaid = 0
          WrkLastPaid = 0
          WrkBillNo = ds2.Tables(0).Rows(I).Item("a_bill_number")
          If WrkMunCid = 0 Then
            WrkMunCid = ds2.Tables(0).Rows(I).Item("a_acct")
          End If
          ds3 = myDBConnect.RunQuery("ub_bill_detail", "where a_acct=" & WrkMunCid & " and a_bill_number=" & WrkBillNo & " and bd_paid_amount<>0")
          For J = 0 To ds3.Tables(0).Rows.Count - 1
            If ds3.Tables(0).Rows(J).Item("bd_original_amount") <> 0 Then
              WrkPrinPaid = WrkPrinPaid + ds3.Tables(0).Rows(J).Item("bd_paid_amount")
              WrkLastPaid = ConvertDate(ds3.Tables(0).Rows(J).Item("bd_last_activity"))
            End If
            If ds3.Tables(0).Rows(J).Item("bd_adjust_amount") <> 0 And CnvSng(ds3.Tables(0).Rows(J).Item("a_serv_code")) = 100000 Then 'Lien Payment
              WrkPrinPaid = WrkPrinPaid + ds3.Tables(0).Rows(J).Item("bd_paid_amount")
              WrkLastPaid = ConvertDate(ds3.Tables(0).Rows(J).Item("bd_last_activity"))
            End If
            If CnvSng(ds3.Tables(0).Rows(J).Item("a_serv_code")) = 91000 Then 'Interest
              WrkIntPaid = WrkIntPaid + ds3.Tables(0).Rows(J).Item("bd_paid_amount")
            End If
          Next
          ._TXIDT = WrkLastPaid
          If .RecordNotFound Then
            ._TAX1 = 0
            ._TAX2 = 0
            ._TX3RD = 0
            ._TX4TH = 0
            Select Case WrkInstallNo
              Case 1
                ._TAX1 = ds2.Tables(0).Rows(I).Item("bh_bill_amount")
              Case 2
                ._TAX2 = ds2.Tables(0).Rows(I).Item("bh_bill_amount")
              Case 3
                ._TX3RD = ds2.Tables(0).Rows(I).Item("bh_bill_amount")
              Case 4
                ._TX4TH = ds2.Tables(0).Rows(I).Item("bh_bill_amount")
            End Select
            ._TAXT = ._TAX1 + ._TAX2 + ._TX3RD + ._TX4TH
            ._PAYREC = WrkPrinPaid
            ._BALD = ._TAXT - ._PAYREC
            ._INTPD = WrkIntPaid
            ._PRF = "Miss7"
            .InsertOneRecordP()
            sw.WriteLine("TXINV,Add," & WrkListNo & "," & WrkYear & "," & ds2.Tables(0).Rows(I).Item("a_acct") & "," & ds2.Tables(0).Rows(I).Item("a_account"))
          Else
            If Trim(._PRF) = "Miss7" Then
              Select Case WrkInstallNo
                Case 1
                  ._TAX1 = ._TAX1 + ds2.Tables(0).Rows(I).Item("bh_bill_amount")
                Case 2
                  ._TAX2 = ._TAX2 + ds2.Tables(0).Rows(I).Item("bh_bill_amount")
                Case 3
                  ._TX3RD = ._TX3RD + ds2.Tables(0).Rows(I).Item("bh_bill_amount")
                Case 4
                  ._TX4TH = ._TX4TH + ds2.Tables(0).Rows(I).Item("bh_bill_amount")
              End Select
              ._TAXT = ._TAX1 + ._TAX2 + ._TX3RD + ._TX4TH
              ._PAYREC = ._PAYREC + WrkPrinPaid
              ._BALD = ._TAXT - ._PAYREC
              ._INTPD = ._INTPD + WrkIntPaid
              .UpdateOneRecordP()
              sw.WriteLine("TXINV,Upd," & WrkListNo & "," & WrkYear & "," & ds2.Tables(0).Rows(I).Item("a_acct") & "," & ds2.Tables(0).Rows(I).Item("a_account"))
            Else
              If Mid(._PRF, 1, 4) <> "Miss" Then
                Select Case WrkInstallNo
                  Case 1
                    ._TAX1 = ds2.Tables(0).Rows(I).Item("bh_bill_amount")
                  Case 2
                    ._TAX2 = ds2.Tables(0).Rows(I).Item("bh_bill_amount")
                  Case 3
                    ._TX3RD = ds2.Tables(0).Rows(I).Item("bh_bill_amount")
                  Case 4
                    ._TX4TH = ds2.Tables(0).Rows(I).Item("bh_bill_amount")
                End Select
                ._TAXT = ._TAX1 + ._TAX2 + ._TX3RD + ._TX4TH
                ._PAYREC = ._PAYREC + WrkPrinPaid
                ._BALD = ._TAXT - ._PAYREC
                ._INTPD = ._INTPD + WrkIntPaid
                .UpdateOneRecordP()
                sw.WriteLine("TXINV,Upd," & WrkListNo & "," & WrkYear & "," & ds2.Tables(0).Rows(I).Item("a_acct") & "," & ds2.Tables(0).Rows(I).Item("a_account"))
              Else
                sw.WriteLine("TXINV,Skip," & WrkListNo & "," & WrkYear & "," & ds2.Tables(0).Rows(I).Item("a_acct") & "," & ds2.Tables(0).Rows(I).Item("a_account"))
              End If
            End If
          End If
        Next
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

    ds2 = Nothing
  End Sub
  Private Sub MissTXHST()
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim ds3 As DataSet = New DataSet
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkMunCid As Integer
    Dim WrkMeter As String
    Dim WrkMunBillNo As Integer
    Dim SaveListNo As Integer
    Dim SaveBillNo As Integer
    Dim WrkPrin As Decimal
    Dim WrkInt As Decimal
    Dim I As Integer
    Dim J As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Integer
    Dim WrkRecID As Integer
    MyTXHST = New TXHST(myDBConnectGEMS2.MyConn2)
    MyUTCUST = New UTCUST(myDBConnectGEMS2.MyConn2)
    myDBConnectGEMS.DeleteRecords2("TXHST", "where prf='Miss7'")
    ds = myDBConnectGEMS.RunQuery2("TXINV", "where prf='Miss7'")
    WrkFile = "TXHST"
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTXHST
        Counter = Counter + 1
        WrkType = "D"
        WrkListNo = ds.Tables(0).Rows(I).Item("list#")
        If WrkListNo = SaveListNo Then
          Continue For
        End If
        SaveListNo = WrkListNo
        MyUTCUST.GetOneRecordP(WrkListNo)
        WrkMeter = Trim(MyUTCUST._CUMETN)
        WrkMunCid = CnvSng(MyUTCUST._CUCNTNO)
        If WrkMeter = "" And WrkMunCid = 0 Then
          GoTo NextRec
        End If
        If WrkMeter <> "" And WrkMunCid > 0 Then
          ds2 = myDBConnect.RunQuery("ar_history_header", "where a_account=" & WrkMunCid & " and a_property_code='" & WrkMeter & "' order by a_bill_number")
        Else
          If WrkMeter <> "" Then
            ds2 = myDBConnect.RunQuery("ar_history_header", "where a_account=" & WrkMunCid & " order by a_bill_number")
          Else
            ds2 = myDBConnect.RunQuery("ar_history_header", "where a_property_code='" & WrkMeter & "' order by a_bill_number")
          End If
        End If
        For J = 0 To ds2.Tables(0).Rows.Count - 1
          WrkYear = ds2.Tables(0).Rows(J).Item("a_bill_year")
          WrkMunBillNo = ds2.Tables(0).Rows(J).Item("a_bill_number")
          If WrkMunBillNo = SaveBillNo Then
            Continue For
          End If
          SaveBillNo = WrkMunBillNo
          If WrkMunCid = 0 Then
            WrkMunCid = ds2.Tables(0).Rows(J).Item("a_account")
          End If
          ds3 = myDBConnect.RunQuery("ar_history_detail", "where a_ar_customer_cid=" & WrkMunCid & " And a_bill_number=" & WrkMunBillNo & " And a_bill_year=" & WrkYear &
           " And bd_paid_amount<>0")
          ' Dictionary to group and sum by date
          Dim dict As New Dictionary(Of Date, (IAMT As Decimal, PAMT As Decimal, Rows As List(Of DataRow)))()
          For Each row As DataRow In ds3.Tables(0).Rows
            Dim postDate As Date = row("bd_last_activity")
            WrkPrin = 0
            WrkInt = 0
            If row("bd_original_amount") <> 0 Then
              WrkPrin = row("bd_paid_amount")
            End If
            If CnvSng(row("a_charge_code")) = 0 Then
              Continue For
            End If
            If CnvSng(row("a_charge_code")) = 100000 Then 'Lien Payment
              WrkPrin = row("bd_paid_amount")
            End If
            If CnvSng(row("a_charge_code")) = 91000 Then 'Interest
              WrkInt = row("bd_paid_amount")
            End If

            ' Add to dictionary
            If dict.ContainsKey(postDate) Then
              dict(postDate) = (dict(postDate).IAMT + WrkInt, dict(postDate).PAMT + WrkPrin, dict(postDate).Rows)
              dict(postDate).Rows.Add(row)
            Else
              dict(postDate) = (WrkInt, WrkPrin, New List(Of DataRow)() From {row})
            End If
          Next

          ' Now insert one record per posting date with sums
          For Each kvp In dict
            Dim postDate As Date = kvp.Key
            Dim sumIAMT As Decimal = kvp.Value.IAMT
            Dim sumPAMT As Decimal = kvp.Value.PAMT
            Dim rows As List(Of DataRow) = kvp.Value.Rows

            ' Use the first row in the group for other fields like hh_batch, a_effective_date
            Dim firstRow As DataRow = rows(0)
            WrkRecID = WrkRecID + 1
            ' Initialize your record
            If sumPAMT >= 0 Then
              ._ADJCD = ""
            Else
              ._ADJCD = "A"
            End If
            ._BATCHA = ""
            ._BATCHN = 0 'ds2.Tables(0).Rows(J).Item("hh_batch")
            ._BATCHS = 0
            ._CASH = 0
            ._CDATE = ConvertDate(firstRow("bd_last_activity"))
            ._CHDATE = ConvertDate(postDate)
            ._CHECK = 0
            ._CHTIME = 0
            ._CORC = ""
            ._CREDIT = 0
            ._DIST = ds.Tables(0).Rows(I).Item("dist")
            ._IAMT = sumIAMT
            ._INTOR = 0
            ._LAMT = 0
            ._LISTNO = WrkListNo
            ._PAMT = sumPAMT
            ._PCAMT = 0
            ._PDATE = ConvertDate(postDate)
            ._PENCD = ""
            ._RCODE = ""
            ._RECID = WrkRecID
            ._REF = ""
            ._SUSCD = ""
            ._THAJCD = ""
            ._THINPD = 0
            ._TYPE = WrkType
            ._YEAR = WrkYear
            ._PRF = "Miss7"
            .InsertOneRecordP()
          Next
        Next
      End With

NextRec:
      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed:  " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next

    ds = Nothing
  End Sub
  Private Sub UBTXINV()
    Dim ds2 As DataSet = New DataSet
    Dim ds3 As DataSet = New DataSet
    Dim ds4 As DataSet = New DataSet
    Dim ds5 As DataSet = New DataSet
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkOldYear As Integer
    Dim WrkMunAcct As String
    Dim WrkMunCid As Integer
    Dim WrkBillNo As Integer
    Dim WrkInstallNo As Integer
    Dim WrkPrinPaid As Decimal
    Dim WrkIntPaid As Decimal
    Dim WrkLastPaid As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer
    Dim J As Integer

    MyUTCUST = New UTCUST(myDBConnectGEMS2.MyConn2)
    MyTXINV = New TXINV(myDBConnectGEMS2.MyConn2)
    myDBConnectGEMS.DeleteRecords2("UBINV", "")
    myDBConnectGEMS.OpenQry2("UTCUST", "")
    WrkFile = "UBINV"
    WrkType = "D"
    WrkOldYear = 2012 '15 Years

ReadNext:
    myDBConnectGEMS.ReadQry()
    If Not myDBConnectGEMS.IsEOF Then
      With MyTXINV
        Counter = Counter + 1
        WrkListNo = myDBConnectGEMS.objReader.Item("cuacct")
        WrkMunAcct = myDBConnectGEMS.objReader.Item("cumetn")
        MyUTCUST.GetOneRecordP(WrkListNo)
        WrkMunCid = CnvSng(MyUTCUST._CUCNTNO)
        If WrkMunAcct = "" And WrkMunCid = 0 Then
          sw.WriteLine("TXINV " & WrkListNo & " no lookup")
          GoTo ReadNext
        End If
        If WrkMunAcct <> "" And WrkMunCid > 0 Then
          ds2 = myDBConnect.RunQuery("ub_bill_header", "where a_acct=" & WrkMunCid & " and a_account='" & WrkMunAcct & "' and bh_bill_amount<>0")
        Else
          If WrkMunAcct <> "" Then
            ds2 = myDBConnect.RunQuery("ub_bill_header", "where a_account='" & WrkMunAcct & "' and bh_bill_amount<>0")
          Else
            ds2 = myDBConnect.RunQuery("ub_bill_header", "where a_acct=" & WrkMunCid & " and bh_bill_amount<>0")
          End If
        End If
        For I = 0 To ds2.Tables(0).Rows.Count - 1
          WrkYear = ds2.Tables(0).Rows(I).Item("a_bill_year")
          If WrkYear < WrkOldYear Then
            Continue For
          End If
          .GetOneRecordP(WrkListNo, WrkYear, WrkType)
          WrkInstallNo = CalcInstallNo(MyUTCUST._CUDST, ds2.Tables(0).Rows(I).Item("bh_bill_date1"))
          ._ADD1 = Trim(MyUTCUST._CUADD1)
          ._ADD2 = Trim(MyUTCUST._CUADD2)
          ._CITY = Trim(MyUTCUST._CUCITY)
          ._DIST = MyUTCUST._CUDST
          ._LETT = Mid(MyUTCUST._CUNAM1, 1, 1)
          ._LISTNo = WrkListNo
          ._LOC = Trim(MyUTCUST._CULOC)
          ._LOCNo = MyUTCUST._CULOCNO
          ._NAME = Trim(MyUTCUST._CUNAM1)
          ._SNAME = Trim(MyUTCUST._CUNAM2)
          ._STATE = Trim(MyUTCUST._CUST)
          ._TXIDT = 0
          ._TYPE = WrkType
          ._YEAR = WrkYear
          ._ZIP5 = CnvSng(Mid(MyUTCUST._CUZIP, 1, 5))
          ._ZIP4 = 0
          If Len(Trim(MyUTCUST._CUZIP)) > 5 Then
            ._ZIP4 = CnvSng(Mid(MyUTCUST._CUZIP, 7, 4))
          End If
          WrkPrinPaid = 0
          WrkIntPaid = 0
          WrkLastPaid = 0
          WrkBillNo = ds2.Tables(0).Rows(I).Item("a_bill_number")
          If WrkMunCid = 0 Then
            WrkMunCid = ds2.Tables(0).Rows(I).Item("a_acct")
          End If
          ds3 = myDBConnect.RunQuery("ub_bill_detail", "where a_acct=" & WrkMunCid & " and a_bill_number=" & WrkBillNo & " and bd_paid_amount<>0")
          For J = 0 To ds3.Tables(0).Rows.Count - 1
            If ds3.Tables(0).Rows(J).Item("bd_original_amount") <> 0 Then
              WrkPrinPaid = WrkPrinPaid + ds3.Tables(0).Rows(J).Item("bd_paid_amount")
              WrkLastPaid = ConvertDate(ds3.Tables(0).Rows(J).Item("bd_last_activity"))
            End If
            If ds3.Tables(0).Rows(J).Item("bd_adjust_amount") <> 0 And CnvSng(ds3.Tables(0).Rows(J).Item("a_serv_code")) = 100000 Then 'Lien Payment
              WrkPrinPaid = WrkPrinPaid + ds3.Tables(0).Rows(J).Item("bd_paid_amount")
              WrkLastPaid = ConvertDate(ds3.Tables(0).Rows(J).Item("bd_last_activity"))
            End If
            If CnvSng(ds3.Tables(0).Rows(J).Item("a_serv_code")) = 91000 Then 'Interest
              WrkIntPaid = WrkIntPaid + ds3.Tables(0).Rows(J).Item("bd_paid_amount")
            End If
          Next
          ._TXIDT = WrkLastPaid
          If .RecordNotFound Then
            ._TAX1 = 0
            ._TAX2 = 0
            ._TX3RD = 0
            ._TX4TH = 0
            Select Case WrkInstallNo
              Case 1
                ._TAX1 = ds2.Tables(0).Rows(I).Item("bh_bill_amount")
              Case 2
                ._TAX2 = ds2.Tables(0).Rows(I).Item("bh_bill_amount")
              Case 3
                ._TX3RD = ds2.Tables(0).Rows(I).Item("bh_bill_amount")
              Case 4
                ._TX4TH = ds2.Tables(0).Rows(I).Item("bh_bill_amount")
            End Select
            ._TAXT = ._TAX1 + ._TAX2 + ._TX3RD + ._TX4TH
            ._PAYREC = WrkPrinPaid
            ._BALD = ._TAXT - ._PAYREC
            ._INTPD = WrkIntPaid
            ._PRF = "Miss7"
            .InsertOneRecordP()
            sw.WriteLine("TXINV,Add," & WrkListNo & "," & WrkYear & "," & ds2.Tables(0).Rows(I).Item("a_acct") & "," & ds2.Tables(0).Rows(I).Item("a_account"))
          Else
            If Trim(._PRF) = "Miss7" Then
              Select Case WrkInstallNo
                Case 1
                  ._TAX1 = ._TAX1 + ds2.Tables(0).Rows(I).Item("bh_bill_amount")
                Case 2
                  ._TAX2 = ._TAX2 + ds2.Tables(0).Rows(I).Item("bh_bill_amount")
                Case 3
                  ._TX3RD = ._TX3RD + ds2.Tables(0).Rows(I).Item("bh_bill_amount")
                Case 4
                  ._TX4TH = ._TX4TH + ds2.Tables(0).Rows(I).Item("bh_bill_amount")
              End Select
              ._TAXT = ._TAX1 + ._TAX2 + ._TX3RD + ._TX4TH
              ._PAYREC = ._PAYREC + WrkPrinPaid
              ._BALD = ._TAXT - ._PAYREC
              ._INTPD = ._INTPD + WrkIntPaid
              .UpdateOneRecordP()
              sw.WriteLine("TXINV,Upd," & WrkListNo & "," & WrkYear & "," & ds2.Tables(0).Rows(I).Item("a_acct") & "," & ds2.Tables(0).Rows(I).Item("a_account"))
            Else
              If Mid(._PRF, 1, 4) <> "Miss" Then
                Select Case WrkInstallNo
                  Case 1
                    ._TAX1 = ds2.Tables(0).Rows(I).Item("bh_bill_amount")
                  Case 2
                    ._TAX2 = ds2.Tables(0).Rows(I).Item("bh_bill_amount")
                  Case 3
                    ._TX3RD = ds2.Tables(0).Rows(I).Item("bh_bill_amount")
                  Case 4
                    ._TX4TH = ds2.Tables(0).Rows(I).Item("bh_bill_amount")
                End Select
                ._TAXT = ._TAX1 + ._TAX2 + ._TX3RD + ._TX4TH
                ._PAYREC = ._PAYREC + WrkPrinPaid
                ._BALD = ._TAXT - ._PAYREC
                ._INTPD = ._INTPD + WrkIntPaid
                .UpdateOneRecordP()
                sw.WriteLine("TXINV,Upd," & WrkListNo & "," & WrkYear & "," & ds2.Tables(0).Rows(I).Item("a_acct") & "," & ds2.Tables(0).Rows(I).Item("a_account"))
              Else
                sw.WriteLine("TXINV,Skip," & WrkListNo & "," & WrkYear & "," & ds2.Tables(0).Rows(I).Item("a_acct") & "," & ds2.Tables(0).Rows(I).Item("a_account"))
              End If
            End If
          End If
        Next
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

    ds2 = Nothing
  End Sub
  Private Sub CustTXHST()
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim ds3 As DataSet = New DataSet
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkMunCid As Integer
    Dim WrkMeter As String
    Dim WrkMunBillNo As Integer
    Dim SaveListNo As Integer
    Dim SaveBillNo As Integer
    Dim WrkPrin As Decimal
    Dim WrkInt As Decimal
    Dim I As Integer
    Dim J As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Integer
    Dim WrkRecID As Integer
    MyTXHST = New TXHST(myDBConnectGEMS2.MyConn2)
    MyUTCUST = New UTCUST(myDBConnectGEMS2.MyConn2)
    myDBConnectGEMS.DeleteRecords2("TXHST", "where prf='Miss7'")
    ds = myDBConnectGEMS.RunQuery2("TXINV", "where prf='Miss7'")
    WrkFile = "TXHST"
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTXHST
        Counter = Counter + 1
        WrkType = "D"
        WrkListNo = ds.Tables(0).Rows(I).Item("list#")
        If WrkListNo = SaveListNo Then
          Continue For
        End If
        SaveListNo = WrkListNo
        MyUTCUST.GetOneRecordP(WrkListNo)
        WrkMeter = Trim(MyUTCUST._CUMETN)
        WrkMunCid = CnvSng(MyUTCUST._CUCNTNO)
        If WrkMeter = "" And WrkMunCid = 0 Then
          GoTo NextRec
        End If
        If WrkMeter <> "" And WrkMunCid > 0 Then
          ds2 = myDBConnect.RunQuery("ar_history_header", "where a_account=" & WrkMunCid & " and a_property_code='" & WrkMeter & "' order by a_bill_number")
        Else
          If WrkMeter <> "" Then
            ds2 = myDBConnect.RunQuery("ar_history_header", "where a_account=" & WrkMunCid & " order by a_bill_number")
          Else
            ds2 = myDBConnect.RunQuery("ar_history_header", "where a_property_code='" & WrkMeter & "' order by a_bill_number")
          End If
        End If
        For J = 0 To ds2.Tables(0).Rows.Count - 1
          WrkYear = ds2.Tables(0).Rows(J).Item("a_bill_year")
          WrkMunBillNo = ds2.Tables(0).Rows(J).Item("a_bill_number")
          If WrkMunBillNo = SaveBillNo Then
            Continue For
          End If
          SaveBillNo = WrkMunBillNo
          If WrkMunCid = 0 Then
            WrkMunCid = ds2.Tables(0).Rows(J).Item("a_account")
          End If
          ds3 = myDBConnect.RunQuery("ar_history_detail", "where a_ar_customer_cid=" & WrkMunCid & " And a_bill_number=" & WrkMunBillNo & " And a_bill_year=" & WrkYear &
           " And bd_paid_amount<>0")
          ' Dictionary to group and sum by date
          Dim dict As New Dictionary(Of Date, (IAMT As Decimal, PAMT As Decimal, Rows As List(Of DataRow)))()
          For Each row As DataRow In ds3.Tables(0).Rows
            Dim postDate As Date = row("bd_last_activity")
            WrkPrin = 0
            WrkInt = 0
            If row("bd_original_amount") <> 0 Then
              WrkPrin = row("bd_paid_amount")
            End If
            If CnvSng(row("a_charge_code")) = 0 Then
              Continue For
            End If
            If CnvSng(row("a_charge_code")) = 100000 Then 'Lien Payment
              WrkPrin = row("bd_paid_amount")
            End If
            If CnvSng(row("a_charge_code")) = 91000 Then 'Interest
              WrkInt = row("bd_paid_amount")
            End If

            ' Add to dictionary
            If dict.ContainsKey(postDate) Then
              dict(postDate) = (dict(postDate).IAMT + WrkInt, dict(postDate).PAMT + WrkPrin, dict(postDate).Rows)
              dict(postDate).Rows.Add(row)
            Else
              dict(postDate) = (WrkInt, WrkPrin, New List(Of DataRow)() From {row})
            End If
          Next

          ' Now insert one record per posting date with sums
          For Each kvp In dict
            Dim postDate As Date = kvp.Key
            Dim sumIAMT As Decimal = kvp.Value.IAMT
            Dim sumPAMT As Decimal = kvp.Value.PAMT
            Dim rows As List(Of DataRow) = kvp.Value.Rows

            ' Use the first row in the group for other fields like hh_batch, a_effective_date
            Dim firstRow As DataRow = rows(0)
            WrkRecID = WrkRecID + 1
            ' Initialize your record
            If sumPAMT >= 0 Then
              ._ADJCD = ""
            Else
              ._ADJCD = "A"
            End If
            ._BATCHA = ""
            ._BATCHN = 0 'ds2.Tables(0).Rows(J).Item("hh_batch")
            ._BATCHS = 0
            ._CASH = 0
            ._CDATE = ConvertDate(firstRow("bd_last_activity"))
            ._CHDATE = ConvertDate(postDate)
            ._CHECK = 0
            ._CHTIME = 0
            ._CORC = ""
            ._CREDIT = 0
            ._DIST = ds.Tables(0).Rows(I).Item("dist")
            ._IAMT = sumIAMT
            ._INTOR = 0
            ._LAMT = 0
            ._LISTNO = WrkListNo
            ._PAMT = sumPAMT
            ._PCAMT = 0
            ._PDATE = ConvertDate(postDate)
            ._PENCD = ""
            ._RCODE = ""
            ._RECID = WrkRecID
            ._REF = ""
            ._SUSCD = ""
            ._THAJCD = ""
            ._THINPD = 0
            ._TYPE = WrkType
            ._YEAR = WrkYear
            ._PRF = "Miss7"
            .InsertOneRecordP()
          Next
        Next
      End With

NextRec:
      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed:  " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next

    ds = Nothing
  End Sub
  Private Sub Missing5()
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkMeter As String
    Dim WrkUnitNo As String
    Dim StrTemp As String
    Dim WrkDate As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer

    MyUTCUST = New UTCUST(myDBConnectGEMS2.MyConn2)
    MyUTCUSTMT = New UTCUSTMT(myDBConnectGEMS2.MyConn2)
    myDBConnectGEMS.DeleteRecords2("UTCUSTMT", "where cmresn='M'")
    myDBConnectGEMS.OpenQry2("Missing5", "")

ReadNext:
    myDBConnectGEMS.ReadQry()
    If Not myDBConnectGEMS.IsEOF Then
      WrkListNo = myDBConnectGEMS.objReader.Item("cuacct")
      WrkMeter = Trim(myDBConnectGEMS.objReader.Item("cumetn"))
      WrkUnitNo = Trim(myDBConnectGEMS.objReader.Item("mununit"))
      With MyUTCUST
        .GetOneRecordP(WrkListNo)
        ._CUMETN = WrkMeter
        If WrkUnitNo <> "" Then
          StrTemp = Trim(._CULOCNO) & WrkUnitNo
          ._CULOCNO = JustifyRight(StrTemp, 7)
        End If
        ._OID = "Miss5"
        .UpdateOneRecordP()
      End With

      With MyUTCUSTMT
        Counter = Counter + 1
        ds2 = .GetLastbyDate(WrkListNo, "", 99999999)
        If ds2.Tables(0).Rows.Count > 0 Then
          GoTo ShowPct
        End If
        ds = myDBConnect.RunQuery("utbilmtr", " where utbmt_account='" & WrkMeter & "' and utbmt_read_date>='2023-01-01'")
        For I = 0 To ds.Tables(0).Rows.Count - 1
          WrkDate = ConvertDate(ds.Tables(0).Rows(I).Item("utbmt_read_date"))
          .GetOneRecordP(WrkListNo, "", WrkDate)
          If .RecordNotFound Then
            ._CMACCT = WrkListNo
            ._CMDATE = WrkDate
            ._CMREAD = CnvSng(ds.Tables(0).Rows(I).Item("utbmt_act_usage"))
            ._CMRESN = "M"
            ._CMTYPE = ""
            ._CMUSE = CnvSng(ds.Tables(0).Rows(I).Item("utbmt_billed_usage"))
            If ._CMUSE > 0 Then
              .InsertOneRecordP()
              If .ErrMsg <> String.Empty Then
                sw.WriteLine("UTCUSTMT " & WrkListNo & " " & .ErrMsg)
              End If
            End If
          End If
        Next
      End With

ShowPct:
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
  Private Sub Missing6()
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkMeter As String
    Dim WrkUnitNo As String
    Dim StrTemp As String
    Dim WrkDate As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer

    MyUTCUST = New UTCUST(myDBConnectGEMS2.MyConn2)
    MyUTCUSTMT = New UTCUSTMT(myDBConnectGEMS2.MyConn2)
    myDBConnectGEMS.DeleteRecords2("UTCUSTMT", "where cmresn='M'")
    myDBConnectGEMS.OpenQry2("Missing6", "")

ReadNext:
    myDBConnectGEMS.ReadQry()
    If Not myDBConnectGEMS.IsEOF Then
      WrkListNo = myDBConnectGEMS.objReader.Item("cuacct")
      WrkMeter = Trim(myDBConnectGEMS.objReader.Item("cumetn"))
      WrkUnitNo = Trim(myDBConnectGEMS.objReader.Item("mununit"))
      With MyUTCUST
        .GetOneRecordP(WrkListNo)
        ._CUMETN = WrkMeter
        If WrkUnitNo <> "" Then
          StrTemp = Trim(._CULOCNO) & WrkUnitNo
          ._CULOCNO = JustifyRight(StrTemp, 7)
        End If
        ._OID = "Miss6"
        .UpdateOneRecordP()
      End With

      With MyUTCUSTMT
        Counter = Counter + 1
        ds2 = .GetLastbyDate(WrkListNo, "", 99999999)
        If ds2.Tables(0).Rows.Count > 0 Then
          GoTo ShowPct
        End If
        ds = myDBConnect.RunQuery("utbilmtr", " where utbmt_account='" & WrkMeter & "' and utbmt_read_date>='2023-01-01'")
        For I = 0 To ds.Tables(0).Rows.Count - 1
          WrkDate = ConvertDate(ds.Tables(0).Rows(I).Item("utbmt_read_date"))
          .GetOneRecordP(WrkListNo, "", WrkDate)
          If .RecordNotFound Then
            ._CMACCT = WrkListNo
            ._CMDATE = WrkDate
            ._CMREAD = CnvSng(ds.Tables(0).Rows(I).Item("utbmt_act_usage"))
            ._CMRESN = "M"
            ._CMTYPE = ""
            ._CMUSE = CnvSng(ds.Tables(0).Rows(I).Item("utbmt_billed_usage"))
            If ._CMUSE > 0 Then
              .InsertOneRecordP()
              If .ErrMsg <> String.Empty Then
                sw.WriteLine("UTCUSTMT " & WrkListNo & " " & .ErrMsg)
              End If
            End If
          End If
        Next
      End With

ShowPct:
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
  Private Sub Missing7()
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkMeter As String
    Dim WrkDate As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer

    MyUTCUSTMT = New UTCUSTMT(myDBConnectGEMS2.MyConn2)
    myDBConnectGEMS.DeleteRecords2("UTCUSTMT", "where cmresn='M'")
    myDBConnectGEMS.OpenQry2("Missing7", "")

ReadNext:
    myDBConnectGEMS.ReadQry()
    If Not myDBConnectGEMS.IsEOF Then
      WrkListNo = myDBConnectGEMS.objReader.Item("cuacct")
      WrkMeter = Trim(myDBConnectGEMS.objReader.Item("cumetn"))

      With MyUTCUSTMT
        Counter = Counter + 1
        ds2 = .GetLastbyDate(WrkListNo, "", 99999999)
        If ds2.Tables(0).Rows.Count > 0 Then
          GoTo ShowPct
        End If
        ds = myDBConnect.RunQuery("utbilmtr", " where utbmt_account='" & WrkMeter & "' and utbmt_read_date>='2023-01-01'")
        For I = 0 To ds.Tables(0).Rows.Count - 1
          WrkDate = ConvertDate(ds.Tables(0).Rows(I).Item("utbmt_read_date"))
          .GetOneRecordP(WrkListNo, "", WrkDate)
          If .RecordNotFound Then
            ._CMACCT = WrkListNo
            ._CMDATE = WrkDate
            ._CMREAD = CnvSng(ds.Tables(0).Rows(I).Item("utbmt_act_usage"))
            ._CMRESN = "M"
            ._CMTYPE = ""
            ._CMUSE = CnvSng(ds.Tables(0).Rows(I).Item("utbmt_billed_usage"))
            If ._CMUSE > 0 Then
              .InsertOneRecordP()
              If .ErrMsg <> String.Empty Then
                sw.WriteLine("UTCUSTMT " & WrkListNo & " " & .ErrMsg)
              End If
            End If
          End If
        Next
      End With

ShowPct:
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