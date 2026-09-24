Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINVQ As TXINVQ.myData
Dim ds1 As DataSet = New DataSet
Dim dsTotEx As DataSet = New DataSet
Dim dsTot As DataSet = New DataSet
Dim dsTotMC As DataSet = New DataSet
Dim dsErr As DataSet = New DataSet
Dim dr As Data.DataRow
Dim drErr As Data.DataRow

Dim WrkType As String
Dim WrkFamily As String
Dim WrkGLYear As Integer
Dim WrkDist As Integer
Dim WrkElderly As Boolean
Dim WrkNewOPM As Boolean

Dim WrkExcd(6) As String
Dim WrkExam(6) As Integer
'Totals
Dim WrkTGross As Long
Dim WrkTExempt As Long
Dim WrkTNet As Long
Dim WrkTNumAccts As Integer
'Buffered files
Dim WrkCode(100) As Integer
Dim WrkDesc(100) As String
'Report fields
Dim RptCode(9) As String
Dim RptDesc(9) As String
Dim RptGross(9) As Integer
Dim RptExCode(4) As String
Dim RptExam(4) As Integer
'MC & Exemption Totals 
Dim WrkTMCCode(100) As String
Dim WrkTMCCount(100) As Integer
Dim WrkTMCGross(100) As Long
Dim WrkTExCode(100) As String
Dim WrkTExCount(100) As Integer
Dim WrkTExam(100) As Long
'PP Descriptions
Dim WrkPropDesc As String
Dim WrkPPCode(100) As Integer
Dim WrkPPDesc(100) As String
'MV Supl Codes
Dim WrkSupCode(25) As String
Dim WrkSupPct(25) As Decimal

  Public Sub PrtReport()

  myTXINVQ = New TXINVQ.mydata(MyDBConnect)

  With MyFrmTX352B
    WrkGLYear = .TxtGLYear.Text
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    WrkType = .TxtType.Text
    WrkElderly = .ChkElderly.Checked
    WrkNewOPM = False
    If .ChkNewOPM.Checked Then
      WrkNewOPM = True
    End If
  End With
  WrkFamily = GetTXTypeFamily(WrkType)

  If ds1.Tables.Count = 0 Then
    BuildDS()
    BuildDSTot(dsTot)
    BuildDSTotEx(dsTotEx)
    BuildDSTotMC(dsTotMC)
    BuildDSErr(dsErr)
    BufferCodes()
  Else
    ds1.Clear()
    dsTot.Clear()
    dsTotEx.Clear()
    dsTotMC.Clear()
    dsErr.Clear()
    ClearTotals()
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
    .Wrkds1 = ds1
    .WrkdsTot = dsTot
    .WrkdsTotEx = dsTotEx
    .WrkdsTotMC = dsTotMC
    .wrkdsErr = dsErr
    .WrkType = WrkType
    .Show()
  End With

  End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("Dist", Type.GetType("System.Int32"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("PropDesc2", Type.GetType("System.String"))
      .Columns.Add("Gross", Type.GetType("System.Int64"))
      .Columns.Add("Exempt", Type.GetType("System.Int64"))
      .Columns.Add("Net", Type.GetType("System.Int64"))
      .Columns.Add("AssCd1", Type.GetType("System.String"))
      .Columns.Add("AssDesc1", Type.GetType("System.String"))
      .Columns.Add("AssAmt1", Type.GetType("System.Int32"))
      .Columns.Add("AssCd2", Type.GetType("System.String"))
      .Columns.Add("AssDesc2", Type.GetType("System.String"))
      .Columns.Add("AssAmt2", Type.GetType("System.Int32"))
      .Columns.Add("AssCd3", Type.GetType("System.String"))
      .Columns.Add("AssDesc3", Type.GetType("System.String"))
      .Columns.Add("AssAmt3", Type.GetType("System.Int32"))
      .Columns.Add("AssCd4", Type.GetType("System.String"))
      .Columns.Add("AssDesc4", Type.GetType("System.String"))
      .Columns.Add("AssAmt4", Type.GetType("System.Int32"))
      .Columns.Add("AssCd5", Type.GetType("System.String"))
      .Columns.Add("AssDesc5", Type.GetType("System.String"))
      .Columns.Add("AssAmt5", Type.GetType("System.Int32"))
      .Columns.Add("AssCd6", Type.GetType("System.String"))
      .Columns.Add("AssDesc6", Type.GetType("System.String"))
      .Columns.Add("AssAmt6", Type.GetType("System.Int32"))
      .Columns.Add("AssCd7", Type.GetType("System.String"))
      .Columns.Add("AssDesc7", Type.GetType("System.String"))
      .Columns.Add("AssAmt7", Type.GetType("System.Int32"))
      .Columns.Add("AssCd8", Type.GetType("System.String"))
      .Columns.Add("AssDesc8", Type.GetType("System.String"))
      .Columns.Add("AssAmt8", Type.GetType("System.Int32"))
      .Columns.Add("AssCd9", Type.GetType("System.String"))
      .Columns.Add("AssDesc9", Type.GetType("System.String"))
      .Columns.Add("AssAmt9", Type.GetType("System.Int32"))
      .Columns.Add("AssCdA", Type.GetType("System.String"))
      .Columns.Add("AssDescA", Type.GetType("System.String"))
      .Columns.Add("AssAmtA", Type.GetType("System.Int32"))
      .Columns.Add("ExCd1", Type.GetType("System.String"))
      .Columns.Add("ExAmt1", Type.GetType("System.Int32"))
      .Columns.Add("ExCd2", Type.GetType("System.String"))
      .Columns.Add("ExAmt2", Type.GetType("System.Int32"))
      .Columns.Add("ExCd3", Type.GetType("System.String"))
      .Columns.Add("ExAmt3", Type.GetType("System.Int32"))
      .Columns.Add("ExCd4", Type.GetType("System.String"))
      .Columns.Add("ExAmt4", Type.GetType("System.Int32"))
      .Columns.Add("ExCd5", Type.GetType("System.String"))
      .Columns.Add("ExAmt5", Type.GetType("System.Int32"))
    End With
    ds1.Tables.Add(myTable)

  End Sub
Private Sub ClearTotals()
  WrkTGross = 0
  WrkTExempt = 0
  WrkTNet = 0
  WrkTNumAccts = 0
  ReDim WrkTMCCode(100)
  ReDim WrkTMCCount(100)
  ReDim WrkTMCGross(100)
  ReDim WrkTExCode(100)
  ReDim WrkTExCount(100)
  ReDim WrkTExam(100)
End Sub
Private Sub GetDetail()
Dim AddrLine() As String
Dim WrkTypeDesc As String
Dim WrkQry As String
Dim WrkSort As String
Dim WrkAssCode(9) As Integer
Dim WrkAss(9) As Integer
Dim WrkAssXFoot As Integer
Dim WrkUnit(9) As Integer
Dim WrkGross As Decimal
Dim WrkExemption As Integer
Dim WrkNet As Decimal
Dim WrkEx As Integer
Dim WrkTaxTotal As Decimal
Dim I As Integer
Dim J As Integer
Dim K As Integer
Dim L As Integer
Dim Counter As Integer
Dim WrkAnd As String

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

WrkTypeDesc = GetTXTypeDesc(WrkType)

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
    If ProfWaiver >= WrkTaxTotal Then 'Waivered
      GoTo ReadNext
    End If
    WrkTNumAccts = WrkTNumAccts + 1
    dr = ds1.Tables(0).NewRow
    dr.Item("dist") = WrkDist
    dr.Item("listno") = ._LISTNo
    dr.Item("year") = WrkGLYear
    dr.Item("typedesc") = WrkTypeDesc
    AddrLine = MyUtils.SetAddrLine(._NAME, ._SNAME, ._ADD1, ._ADD2, _
      ._CITY, ._STATE, ._ZIP5, ._ZIP4)
    dr.Item("addr1") = AddrLine(0)
    dr.Item("addr2") = AddrLine(1)
    dr.Item("addr3") = AddrLine(2)
    dr.Item("addr4") = AddrLine(3)
    dr.Item("addr5") = AddrLine(4)
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
'      If WrkCredit > 0 Then
'        dr.Item("propdesc2") = ._ICVYR & " " & Trim(._ICVMKE) & " " & _
'          Trim(._ICVMOD) & " " & Trim(._ICVIDNo) & " " & Trim(._ICVREG)
'      End If
    End Select
    WrkAssCode(0) = ._IPPCD1
    WrkAssCode(1) = ._IPPCD2
    WrkAssCode(2) = ._IPPCD3
    WrkAssCode(3) = ._IPPCD4
    WrkAssCode(4) = ._IPPCD5
    WrkAssCode(5) = ._IPPCD6
    WrkAssCode(6) = ._IPPCD7
    WrkAssCode(7) = ._IPPCD8
    WrkAssCode(8) = ._IPPCD9
    WrkAssCode(9) = ._IPPCDA
    WrkAss(0) = ._OAS1
    WrkAss(1) = ._OAS2
    WrkAss(2) = ._OAS3
    WrkAss(3) = ._OAS4
    WrkAss(4) = ._OAS5
    WrkAss(5) = ._OAS6
    WrkAss(6) = ._OAS7
    WrkAss(7) = ._OAS8
    WrkAss(8) = ._OAS9
    WrkAss(9) = ._OAS10
    WrkUnit(0) = ._UNIT1
    WrkUnit(1) = ._UNIT2
    WrkUnit(2) = ._UNIT3
    WrkUnit(3) = ._UNIT4
    WrkUnit(4) = ._UNIT5
    WrkUnit(5) = ._UNIT6
    WrkUnit(6) = ._UNIT7
    WrkUnit(7) = ._UNIT8
    WrkUnit(8) = ._UNIT9
    WrkUnit(9) = ._UNITA
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
    'Combine Gross into OPM groups
    Array.Clear(RptCode, 0, 10)
    Array.Clear(RptDesc, 0, 10)
    Array.Clear(RptGross, 0, 10)
    WrkAssXFoot = 0
    For J = 0 To 9
      WrkAssXFoot = WrkAssXFoot + WrkAss(J)
      If WrkAssCode(J) > 0 Then
        K = LookupRptCode(Format(WrkAssCode(J), "000"))
        RptCode(K) = Format(WrkAssCode(J), "000")
        RptDesc(K) = LookupOPMCode(WrkAssCode(J))
        RptGross(K) = RptGross(K) + WrkAss(J)
      End If
    Next J

    'Add OPM groups to totals
    For J = 0 To 9
      If Not IsNothing(RptCode(J)) Then
        K = LookupWrkTMCCode(RptCode(J))
        WrkTMCCode(K) = RptCode(J)
        WrkTMCCount(K) = WrkTMCCount(K) + 1
        WrkTMCGross(K) = WrkTMCGross(K) + RptGross(J)
      End If
    Next J

    dr.Item("asscd1") = RptCode(0)
    dr.Item("assdesc1") = RptDesc(0)
    dr.Item("assamt1") = RptGross(0)
    dr.Item("asscd2") = RptCode(1)
    dr.Item("assdesc2") = RptDesc(1)
    dr.Item("assamt2") = RptGross(1)
    dr.Item("asscd3") = RptCode(2)
    dr.Item("assdesc3") = RptDesc(2)
    dr.Item("assamt3") = RptGross(2)
    dr.Item("asscd4") = RptCode(3)
    dr.Item("assdesc4") = RptDesc(3)
    dr.Item("assamt4") = RptGross(3)
    dr.Item("asscd5") = RptCode(4)
    dr.Item("assdesc5") = RptDesc(4)
    dr.Item("assamt5") = RptGross(4)
    dr.Item("asscd6") = RptCode(5)
    dr.Item("assdesc6") = RptDesc(5)
    dr.Item("assamt6") = RptGross(5)
    dr.Item("asscd7") = RptCode(6)
    dr.Item("assdesc7") = RptDesc(6)
    dr.Item("assamt7") = RptGross(6)
    dr.Item("asscd8") = RptCode(7)
    dr.Item("assdesc8") = RptDesc(7)
    dr.Item("assamt8") = RptGross(7)
    dr.Item("asscd9") = RptCode(8)
    dr.Item("assdesc9") = RptDesc(8)
    dr.Item("assamt9") = RptGross(8)
    dr.Item("asscda") = RptCode(9)
    dr.Item("assdesca") = RptDesc(9)
    dr.Item("assamta") = RptGross(9)

    'Combine Exemptions into Letter groups
    Array.Clear(RptExCode, 0, 5)
    Array.Clear(RptExam, 0, 5)
    For J = 0 To 4
      WrkEx = 0
      If WrkExcd(J) <> "" Then
        K = LookupExem(WrkExcd(J))
        'Check for Invalid exemptions
        If K = -1 Then
          drErr = dsErr.Tables(0).NewRow
          drErr.Item("listno") = ._LISTNo
          drErr.Item("addr1") = AddrLine(0)
          drErr.Item("gross") = 0
          drErr.Item("exempt") = 0
          drErr.Item("net") = 0
          drErr.Item("errmsg") = "Invalid Exemption Code - " & WrkExcd(J)
          dsErr.Tables(0).Rows.Add(drErr)
        End If
        If WrkExam(J) = 0 And K >= 0 Then
          WrkEx = WrkExFixedAmt(K)
        Else
          WrkEx = WrkExam(J)
        End If
        If WrkNewOPM Then
          If K >= 0 Then
            L = LookupRptExCode(WrkExLetter(K))
            RptExCode(L) = WrkExLetter(K)
            RptExam(L) = RptExam(L) + WrkEx
          End If
        Else
          L = LookupRptExCode(WrkExcd(J))
          RptExCode(L) = WrkExcd(J)
          RptExam(L) = RptExam(L) + WrkEx
        End If
      End If
    Next
    'Add Exemption Letter groups
    For J = 0 To 4
      If Not IsNothing(RptExCode(J)) Then
        K = LookupWrkTExCode(RptExCode(J))
        WrkTExCode(K) = RptExCode(J)
        WrkTExCount(K) = WrkTExCount(K) + 1
        WrkTExam(K) = WrkTExam(K) + RptExam(J)
      End If
    Next J

    dr.Item("gross") = WrkGross
    dr.Item("exempt") = WrkExemption
    dr.Item("net") = WrkNet
    dr.Item("excd1") = RptExCode(0)
    dr.Item("examt1") = RptExam(0)
    dr.Item("excd2") = RptExCode(1)
    dr.Item("examt2") = RptExam(1)
    dr.Item("excd3") = RptExCode(2)
    dr.Item("examt3") = RptExam(2)
    dr.Item("excd4") = RptExCode(3)
    dr.Item("examt4") = RptExam(3)
    dr.Item("excd5") = RptExCode(4)
    dr.Item("examt5") = RptExam(4)

    WrkTGross = WrkTGross + dr.Item("gross")
    WrkTExempt = WrkTExempt + WrkExemption
    WrkTNet = WrkTNet + dr.Item("net")
    ds1.Tables(0).Rows.Add(dr)
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

'Totals
dr = dsTot.Tables(0).NewRow
dr.Item("totdesc") = "Total Gross Assessment"
dr.Item("totcount") = WrkTNumAccts
dr.Item("totamount") = WrkTGross
dsTot.Tables(0).Rows.Add(dr)

dr = dsTot.Tables(0).NewRow
dr.Item("totdesc") = "Total Exemptions"
dr.Item("totcount") = 0
dr.Item("totamount") = WrkTExempt
dsTot.Tables(0).Rows.Add(dr)

dr = dsTot.Tables(0).NewRow
dr.Item("totdesc") = "Total Net Assessment"
dr.Item("totcount") = WrkTNumAccts
dr.Item("totamount") = WrkTNet
dsTot.Tables(0).Rows.Add(dr)

For I = 0 To 100
  If IsNothing(WrkTMCCode(I)) Then Exit For
  dr = dsTotMC.Tables(0).NewRow
  dr.Item("tmcformat") = "B"
  dr.Item("tmccode") = WrkTMCCode(I)
  dr.Item("tmcdesc") = GetTXCodeDesc(WrkTMCCode(I), WrkType)
  dr.Item("tmccount") = WrkTMCCount(I)
  dr.Item("tmcgross") = WrkTMCGross(I)
  dsTotMC.Tables(0).Rows.Add(dr)
Next I

For I = 0 To 100
  If IsNothing(WrkTExCode(I)) Then Exit For
  dr = dsTotEx.Tables(0).NewRow
  dr.Item("texformat") = "B"
  dr.Item("texcode") = WrkTExCode(I)
  K = LookupExem(WrkTExCode(I))
 If K >= 0 Then
  dr.Item("texdesc") = WrkExDesc(K)
 Else
    If WrkTExCode(I) = "*" Then
     dr.Item("texdesc") = "LOCAL EXEMPTIONS"
    Else
     dr.Item("texdesc") = "*** Invalid OPM Group ***"
    End If
 End If
 dr.Item("texcount") = WrkTExCount(I)
  dr.Item("tex") = WrkTExam(I)
  dsTotEx.Tables(0).Rows.Add(dr)
Next I

myFrmProgress.Close()
myTXINVQ.CloseFile()

End Sub
Private Sub BufferCodes()
     Dim I As Integer

   Dim myTXCode As TXCode.myData
     Dim dsTXCode As DataSet = New DataSet

   myTXCode = New TXCode.mydata(MyDBConnect)

     dsTXCode = myTXCode.GetAllType(WrkFamily)
     For I = 0 To dsTXCode.Tables(0).Rows.Count - 1
      With dsTXCode.Tables(0).Rows(I)
        WrkCode(I) = .Item("tccode")
        WrkDesc(I) = .Item("tcdesc")
      End With
    Next

End Sub
Private Function LookupOPMCode(ByVal Code As Integer) As String
     Dim I As Integer
     Dim WrkResult As String

     For I = 0 To WrkCode.GetUpperBound(0)
       If WrkCode(I) = 0 Then
         Return ""
       End If
       If Code = WrkCode(I) Then
         WrkResult = WrkDesc(I)
         Return WrkResult
       End If
    Next

    Return ""
End Function
Private Function LookupRptCode(ByVal Code As Integer) As Integer
     Dim I As Integer

     For I = 0 To RptCode.GetUpperBound(0)
       If RptCode(I) = 0 Then
         Return I
       End If
       If Code = RptCode(I) Then
         Return I
       End If
    Next

End Function
Private Function LookupRptExCode(ByVal Code As String) As Integer
     Dim I As Integer

     For I = 0 To RptExCode.GetUpperBound(0)
      If Trim(RptExCode(I)) = "" Then
        Return I
      End If
      If Trim(Code) = Trim(RptExCode(I)) Then
        Return I
      End If
    Next

End Function
Private Function LookupWrkTMCCode(ByVal Code As Integer) As Integer
     Dim I As Integer

     For I = 0 To WrkTMCCode.GetUpperBound(0)
       If WrkTMCCode(I) = "" Then
         Return I
       End If
       If Code = WrkTMCCode(I) Then
         Return I
       End If
    Next

End Function
Private Function LookupWrkTExCode(ByVal Code As String) As Integer
     Dim I As Integer

     For I = 0 To WrkTExCode.GetUpperBound(0)
      If Trim(WrkTExCode(I)) = "" Then
        Return I
      End If
      If Trim(Code) = Trim(WrkTExCode(I)) Then
        Return I
      End If
    Next

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






