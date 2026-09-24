Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINVQ As TXINVQ.myData
Dim myTXMRATE As TXMRATE.myData
Dim myTXPROF As TXPROF.myData
Dim myTXTYPE As TXTYPE.myData

Dim ds As DataSet = New DataSet
Dim dsTot As DataSet = New DataSet
Dim dsTotEx As DataSet = New DataSet
Dim dr As Data.DataRow
Dim drTot As Data.DataRow
Dim drTotEx As Data.DataRow

Dim WrkGLYear As Integer
Dim WrkDist As Integer
Dim WrkElderly As Boolean
Dim WrkSortBy As String
Dim WrkBillType As String
Dim WrkExCode(200) As String
Dim WrkExDesc(200) As String
Dim WrkExFixedAmt(200) As Integer
Dim WrkExPerc(200) As Decimal
Dim WrkList As Integer
Dim WrkType As String
Dim WrkFamily As String
Dim WrkExcd(6) As String
Dim WrkExam(6) As Integer
Dim WrkGross As Integer
Dim WrkExemption As Integer
Dim WrkNet As Integer
Dim WrkTaxTotal As Decimal
'Total Page
Dim WrkTAccts As Integer
Dim WrkTBills As Integer
Dim WrkTGross As Long
Dim WrkTPartial As Long
Dim WrkTCredit As Long
Dim WrkTExempt As Long
Dim WrkTNet As Long
Dim WrkTFull As Long
Dim WrkTProrate As Long
Dim WrkTFullCredit As Long
Dim WrkTProrateCredit As Long
Dim WrkTTax As Decimal
Dim WrkTWaiveredAccts As Integer
Dim WrkTWaiveredGross As Integer
Dim WrkTWaiveredExempt As Long
Dim WrkTWaiveredNet As Long
Dim WrkTWaivered As Decimal
'PP Descriptions
Dim WrkPropDesc As String
Dim WrkPPCode(100) As Integer
Dim WrkPPDesc(100) As String
'MV Supl Codes
Dim WrkSupCode(25) As String
Dim WrkSupPct(25) As Decimal
'Exemption Totals
Dim WrkTExCount(200) As Integer
Dim WrkTExam(200) As Integer
 Public Sub PrtReport()
 myTXINVQ = New TXINVQ.mydata(MyDBConnect)

 'Clear Totals
 ClearTotals()

 With MyFrmTX351B
  WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
  WrkDist = MyUtils.CnvSng(.TxtDist.Text)
  WrkType = .TxtType.Text
  WrkElderly = .ChkElderly.Checked
 End With
 WrkFamily = GetTXTypeFamily(WrkType)

 If ds.Tables.Count = 0 Then
  BuildDS(ds)
  BuildDSTot(dsTot)
  BuildDSTotEx(dsTotEx)
 Else
  ds.Clear()
  dsTot.Clear()
  dsTotEx.Clear()
 End If

 Select Case WrkFamily
 Case "P"
   BufferPPDesc()
 Case "S"
   BufferTXSupcd()
 End Select
 BufferExem()
 GetDetail()

Done:
 MyCrViewer = New FrmCrViewer
 With MyCrViewer
  .Wrkds = ds
  .WrkdsTot = dsTot
  .WrkdsTotEx = dsTotEx
  .WrkType = WrkType
  .WrkFamily = WrkFamily
  .WrkTypeDesc = WrkBillType
  .Show()
 End With

 End Sub
Private Sub ClearTotals()
  WrkTGross = 0
  WrkTPartial = 0
  WrkTCredit = 0
  WrkTExempt = 0
  WrkTNet = 0
  WrkTFull = 0
  WrkTProrate = 0
  WrkTFullCredit = 0
  WrkTProrateCredit = 0
  WrkTTax = 0
  WrkTAccts = 0
  WrkTBills = 0

End Sub
Private Sub GetDetail()
Dim AddrLine() As String
Dim WrkQry As String
Dim WrkSort As String
Dim I As Integer
Dim J As Integer
Dim K As Integer
Dim Counter As Integer
Dim WrkAnd As String
Dim SaveExLetter As String
Dim WrkTxSupCd As String()
Dim WrkProratePct As Decimal
Dim WrkCreditPct As Decimal
Dim WrkProrate As Integer
Dim WrkCredit As Integer
Dim WrkWaivered As Boolean

WrkBillType = GetTXTypeDesc(WrkType)

If MyServer = "DB2" Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

WrkQry = "icode<>'I'" & WrkAnd & "YEAR=" & WrkGLYear & WrkAnd & "TYPE=" & MyUtils.Quo(WrkFamily) & WrkAnd & "FRCD<>'F'"
If Not WrkElderly Then
  WrkQry = WrkQry & WrkAnd & "FRCD<>'C'"
End If
WrkSort = "NAME, SNAME, ADD1"
Counter = 0

myTXINVQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

SaveExLetter = ""
GetTaxProfile(WrkType, WrkGLYear, "", WrkDist)
GetMillRate(WrkGLYear, WrkType, WrkDist)

ReadNext:
 myTXINVQ.ReadQry()
 If Not myTXINVQ.IsEOF Then
 With myTXINVQ
    Counter = Counter + 1
    WrkGross = 0
    WrkExemption = 0
    WrkNet = 0
    If ._CCNO > 0 Then
      If ._CCETAX > 0 Then
        WrkGross = ._CGRS
        WrkExemption = ._CCEXP
        WrkNet = ._CGRS - ._CCEXP
      End If
    Else
      WrkGross = ._GROSS
      WrkExemption = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5 + ._EXAM6 + ._EXAM7
      WrkNet = ._NETASS
    End If
    WrkTaxTotal = MyUtils.Round(WrkNet * MrateMillrt, 2)
    WrkWaivered = False
    If ProfWaiver >= WrkTaxTotal Then 'Waivered
      WrkWaivered = True
      WrkTWaiveredAccts = WrkTWaiveredAccts + 1
      WrkTWaivered = WrkTWaivered + WrkTaxTotal
      WrkTWaiveredGross = WrkTWaiveredGross + WrkGross
      WrkTWaiveredExempt = WrkTWaiveredExempt + WrkExemption
      WrkTWaiveredNet = WrkTWaiveredNet + WrkNet
      GoTo NextRec
    End If
    If WrkFamily = "M" Or WrkFamily = "S" Then
      WrkTxSupCd = GetTXSupCd(._ASS)
      WrkProratePct = MyUtils.CnvSng(WrkTxSupCd(0))
      WrkProrate = ._GROSS * WrkProratePct
      WrkCredit = ._ICVGRS * WrkProratePct
    End If
    WrkList = ._LISTNo
    WrkExcd(0) = Trim(._EXCD1)
    WrkExcd(1) = Trim(._EXCD2)
    WrkExcd(2) = Trim(._EXCD3)
    WrkExcd(3) = Trim(._EXCD4)
    WrkExcd(4) = Trim(._EXCD5)
    WrkExcd(5) = Trim(._EXCD6)
    WrkExcd(6) = Trim(._EXCD7)
    WrkExam(0) = ._EXAM1
    WrkExam(1) = ._EXAM2
    WrkExam(2) = ._EXAM3
    WrkExam(3) = ._EXAM4
    WrkExam(4) = ._EXAM5
    WrkExam(5) = ._EXAM6
    WrkExam(6) = ._EXAM7

    'Create Rate Book
    dr = ds.Tables(0).NewRow
    dr.Item("letter") = ._LETT
    dr.Item("TypeDesc") = WrkBillType
    dr.Item("listno") = WrkList
    dr.Item("year") = WrkGLYear
    AddrLine = MyUtils.SetAddrLine(._NAME, ._SNAME, ._ADD1, ._ADD2, _
      ._CITY, ._STATE, ._ZIP5, ._ZIP4)
    dr.Item("addr1") = AddrLine(0)
    dr.Item("addr2") = AddrLine(1)
    dr.Item("addr3") = AddrLine(2)
    dr.Item("addr4") = AddrLine(3)
    dr.Item("addr5") = AddrLine(4)
    dr.Item("gross") = WrkGross
    dr.Item("exemption") = WrkExemption
    dr.Item("prorate") = WrkProrate
    dr.Item("credit") = WrkCredit
    dr.Item("net") = WrkNet
    dr.Item("taxtot") = WrkTaxTotal
    Select Case WrkFamily
    Case "P"
      WrkPropDesc = LookupPPDesc(._IPPCD1)
      If ._IPPCD2 > 0 Then
        WrkPropDesc = WrkPropDesc & "," & LookupPPDesc(._IPPCD2)
      End If
      If ._IPPCD3 > 0 Then
        WrkPropDesc = WrkPropDesc & "," & LookupPPDesc(._IPPCD3)
      End If
      If ._IPPCD4 > 0 Then
        WrkPropDesc = WrkPropDesc & "," & LookupPPDesc(._IPPCD4)
      End If
      dr.Item("propdesc") = WrkPropDesc
      WrkPropDesc = ""
      If ._IPPCD5 > 0 Then
        WrkPropDesc = LookupPPDesc(._IPPCD5)
      End If
      If ._IPPCD6 > 0 Then
        WrkPropDesc = WrkPropDesc & "," & LookupPPDesc(._IPPCD6)
      End If
      If ._IPPCD7 > 0 Then
        WrkPropDesc = WrkPropDesc & "," & LookupPPDesc(._IPPCD7)
      End If
      If ._IPPCD8 > 0 Then
        WrkPropDesc = WrkPropDesc & "," & LookupPPDesc(._IPPCD8)
      End If
      dr.Item("propdesc2") = WrkPropDesc
    Case "R"
      dr.Item("propdesc") = Trim(._LOCNo) & " " & Trim(._LOC)
      dr.Item("propdesc2") = Trim(._VOL) & Trim(._IPAGE) & ", " & Trim(._MAP)
    Case "M"
      dr.Item("propdesc") = ._MVYR & " " & Trim(._MAKE) & " " & _
        Trim(._MODEL) & " " & Trim(._IMVIDNo) & " " & Trim(._IMVREG)
      dr.Item("propdesc2") = WrkPropDesc
    Case "S"
      dr.Item("propdesc") = ._MVYR & " " & Trim(._MAKE) & " " & _
        Trim(._MODEL) & " " & Trim(._IMVIDNo) & " " & Trim(._IMVREG)
      If WrkCredit > 0 Then
        dr.Item("propdesc2") = ._ICVYR & " " & Trim(._ICVMKE) & " " & _
          Trim(._ICVMOD) & " " & Trim(._ICVIDNo) & " " & Trim(._ICVREG)
      End If
    End Select
    'Add to Report Totals
    WrkTAccts = WrkTAccts + 1
    If Not WrkWaivered Then
      WrkTBills = WrkTBills + 1
    End If
    'Add to Exemption totals
    For J = 0 To 6
      If WrkExcd(J) <> "" Then
        K = LookupExem(WrkExcd(J))
        If K >= 0 Then
          WrkTExCount(K) = WrkTExCount(K) + 1
          WrkTExam(K) = WrkTExam(K) + WrkExam(J)
        End If
      End If
    Next
    ds.Tables(0).Rows.Add(dr)
  End With

  WrkTGross = WrkTGross + WrkGross
  WrkTPartial = WrkTPartial + WrkProrate
  WrkTCredit = WrkTCredit + WrkCredit
  WrkTExempt = WrkTExempt + WrkExemption
  WrkTNet = WrkTNet + WrkNet
  If WrkProratePct = 1 Then
    WrkTFull = WrkTFull + WrkGross
  Else
    WrkTProrate = WrkTProrate + WrkGross
  End If
  If WrkCredit > 0 Then
    If WrkCreditPct = 1 Then
      WrkTFullCredit = WrkTFullCredit + WrkCredit
    Else
      WrkTProrateCredit = WrkTProrateCredit + WrkCredit
    End If
  End If
  If Not WrkWaivered Then
    WrkTTax = WrkTTax + WrkTaxTotal
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
 End If

'Totals
drTot = dsTot.Tables(0).NewRow
drTot.Item("taccts") = WrkTAccts
drTot.Item("tbills") = WrkTBills
drTot.Item("tgross") = WrkTGross
drTot.Item("texempt") = WrkTExempt
drTot.Item("tprorate") = WrkTProrate
drTot.Item("tcredit") = WrkTCredit
drTot.Item("tnet") = WrkTNet
drTot.Item("tfull") = WrkTFull
drTot.Item("tpartial") = WrkTPartial
drTot.Item("tfullcredit") = WrkTFullCredit
drTot.Item("tproratecredit") = WrkTProrateCredit
drTot.Item("ttax") = WrkTTax
drTot.Item("twaiveredaccts") = WrkTWaiveredAccts
drTot.Item("twaivered") = WrkTWaivered
drTot.Item("twaiveredgross") = WrkTWaiveredGross
drTot.Item("twaiveredexempt") = WrkTWaiveredExempt
drTot.Item("twaiverednet") = WrkTWaiveredNet
dsTot.Tables(0).Rows.Add(drTot)

'Exemption Totals
drTotEx = dsTotEx.Tables(0).NewRow
drTotEx.Item("tcode") = ""
drTotEx.Item("tdesc") = "GROSS"
drTotEx.Item("tcount") = 0
drTotEx.Item("texempt") = WrkTGross
dsTotEx.Tables(0).Rows.Add(drTotEx)
drTotEx = dsTotEx.Tables(0).NewRow
drTotEx.Item("tcode") = ""
drTotEx.Item("tdesc") = "NET"
drTotEx.Item("tcount") = 0
drTotEx.Item("texempt") = WrkTNet
dsTotEx.Tables(0).Rows.Add(drTotEx)
'Add a Blank line to report
drTotEx = dsTotEx.Tables(0).NewRow
drTotEx.Item("tcode") = ""
drTotEx.Item("tdesc") = ""
drTotEx.Item("tcount") = 0
drTotEx.Item("texempt") = 0
dsTotEx.Tables(0).Rows.Add(drTotEx)

For I = 0 To 200
If WrkTExCount(I) > 0 Then
  If SaveExLetter <> Left(WrkExCode(I), 1) Then
    SaveExLetter = Left(WrkExCode(I), 1)
    K = LookupExem(SaveExLetter)
    drTotEx = dsTotEx.Tables(0).NewRow
    drTotEx.Item("tcode") = ""
    drTotEx.Item("tdesc") = WrkExDesc(K)
    drTotEx.Item("tcount") = 0
    drTotEx.Item("texempt") = 0
    dsTotEx.Tables(0).Rows.Add(drTotEx)
  End If
  drTotEx = dsTotEx.Tables(0).NewRow
  drTotEx.Item("tcode") = WrkExCode(I)
  drTotEx.Item("tdesc") = WrkExDesc(I)
  drTotEx.Item("tcount") = WrkTExCount(I)
  drTotEx.Item("texempt") = WrkTExam(I)
  dsTotEx.Tables(0).Rows.Add(drTotEx)
End If
Next

myFrmProgress.Close()
myTXINVQ.CloseFile()

End Sub
  Public Function CalcPct(ByVal AssCd As String) As Decimal
    Dim K As Integer
    Dim WrkPct As Decimal

    K = LookupTxSupcd(AssCd)
    WrkPct = WrkSupPct(K)
    Return WrkPct
  End Function
  Public Function CalcAssmt(ByVal Value As Integer, ByVal Pct As Decimal) As Integer
    Dim WrkProRate As Integer
    WrkProRate = MyUtils.Round(Value * Pct, 0)
    Return WrkProRate
  End Function
Private Sub BufferTXSupcd()
     Dim I As Integer

   Dim myTXSUPCD As TXSUPCD.myData
     Dim dsTXSupcd As DataSet = New DataSet

   myTXSUPCD = New TXSUPCD.mydata(MyDBConnect)

     dsTXSupcd = myTXSUPCD.GetAllData
     For I = 0 To dsTXSupcd.Tables(0).Rows.Count - 1
      With dsTXSupcd.Tables(0).Rows(I)
        WrkSupCode(I) = .Item("scod")
        WrkSupPct(I) = .Item("spct")
      End With
    Next

End Sub
Private Function LookupTxSupcd(ByVal Code As String) As Integer
     Dim I As Integer

     For I = 0 To WrkSupCode.GetUpperBound(0)
      If Trim(WrkSupCode(I)) = "" Then
        Return I
      End If
      If Trim(Code) = Trim(WrkSupCode(I)) Then
        Return I
      End If
    Next

End Function
Private Sub BufferExem()
     Dim I As Integer

   Dim myTXEXEM As TXEXEM.myData
     Dim dsTXEXEM As DataSet = New DataSet

   myTXEXEM = New TXEXEM.mydata(MyDBConnect)

     dsTXEXEM = myTXEXEM.GetAllData
     For I = 0 To dsTXEXEM.Tables(0).Rows.Count - 1
      With dsTXEXEM.Tables(0).Rows(I)
        WrkExCode(I) = .Item("texem")
        WrkExDesc(I) = .Item("tdesc")
        WrkExFixedAmt(I) = .Item("tfixam")
        If .Item("tfixam") = 0 And .Item("tperc") = 0 Then
          WrkExPerc(I) = 1
        Else
          WrkExPerc(I) = .Item("tperc")
        End If
      End With
    Next

End Sub
Private Function LookupExem(ByVal Exem As String) As Integer
     Dim I As Integer

     For I = 0 To WrkExCode.GetUpperBound(0)
      If Trim(WrkExCode(I)) = "" Then
        Return -1
      End If
      If Trim(Exem) = Trim(WrkExCode(I)) Then
        Return I
      End If
    Next

End Function
Private Sub BufferPPDesc()
     Dim I As Integer

   Dim myTXCode As TXCode.myData
     Dim dsTXCode As DataSet = New DataSet

   myTXCode = New TXCode.mydata(MyDBConnect)

     dsTXCode = myTXCode.GetAllType(WrkFamily)
     For I = 0 To dsTXCode.Tables(0).Rows.Count - 1
      With dsTXCode.Tables(0).Rows(I)
        WrkPPCode(I) = .Item("tccode")
        WrkPPDesc(I) = .Item("tcdesc")
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
 Public Function GetTXSupCd(ByVal Code As String) As String()
  Dim Wrkstr(2) As String
  Dim myTXSUPCD As TXSUPCD.myData

  myTXSUPCD = New TXSUPCD.mydata(MyDBConnect)
  If IsNothing(Code) Or Code = "" Then
   Wrkstr(0) = ""
   Wrkstr(1) = ""
   Wrkstr(2) = ""
   Return Wrkstr
  End If

  myTXSUPCD.GetOneRecordP(Code)
  If Not myTXSUPCD.RecordNotFound Then
   Wrkstr(0) = Format(myTXSUPCD._SPCT, ".000")
   Wrkstr(1) = Trim(myTXSUPCD._SMON)
   Wrkstr(2) = Trim(myTXSUPCD._SCRD)
  Else
   Wrkstr(1) = "*** Unknown ***"
  End If
  Return Wrkstr

 End Function
End Module







