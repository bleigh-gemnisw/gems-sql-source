Imports System.Text
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim WrkFirstCAFee As Boolean
  Dim WrkFirstCCAdd As Boolean
  Dim WrkFirstCCDt As Boolean
  Dim WrkFirstMVFee As Boolean
  Dim WrkFirstIntBond As Boolean
#Region "Variables"
  'Set the Local variable and the Property
  Dim myGNET As GNET.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXINVLP As TXINVLP.MyData
  Dim myTXHSTL4 As TXHSTL4.MyData
  Dim myTXPROF As TXPROF.MyData
  Dim myTXTYPE As TXTYPE.MyData
  Dim myTXCOEA As TXCOEAL1.MyData
  Dim myUTCOEA As UTCOEAL1.MyData
  Dim myTXMVFEE As TXMVFEE.MyData
  Dim mvarIn_ListNo As Integer
  Dim mvarIn_Year As Integer
  Dim mvarIn_Type As String
  Dim mvarIn_Date As Date
  Dim mvarOut_Int As Decimal
  Dim mvarOut_Lien As Decimal
  Dim mvarOut_Fee As Decimal
  Dim mvarOut_CAFee As Decimal
  Dim mvarOut_Prin As Decimal
  Dim mvarOut_Tot As Decimal
  Dim mvarOut_Bond As Decimal
  Dim mvarOut_IntPaid As Decimal
  Dim mvarOut_FeePaid As Decimal
  Dim mvarOut_BondPaid As Decimal
  Dim mvarOut_Unposted As Boolean
  Dim mvarOut_GracePeriod As Boolean
  Dim mvarOut_Method As String
  Dim mvarOut_Date As Date
  Dim mvarOut_Debug As String
  Dim sbDebug As StringBuilder
  Dim myCCAddDate As Boolean
  Dim myCAFee As Boolean
  Dim MyCCDateInt As Boolean
  Dim MyIntBond As Boolean
  Dim myLowInt As Boolean
  '---------------------------------------
  ' ken added 6/21/24
  '------------------------------------------
  Dim mvarOut_ProfDate1 As Date
  Dim mvarOut_ProfDate2 As Date
  Dim mvarOut_ProfDate3 As Date
  Dim mvarOut_ProfDate4 As Date
  Dim mvarOut_Date1 As Date
  Dim mvarOut_Date2 As Date
  Dim mvarOut_Date3 As Date
  Dim mvarOut_Date4 As Date
  Dim mvarOut_Int1 As Decimal
  Dim mvarOut_Int2 As Decimal
  Dim mvarOut_Int3 As Decimal
  Dim mvarOut_Int4 As Decimal
  Dim mvarOut_Prin1 As Decimal
  Dim mvarOut_Prin2 As Decimal
  Dim mvarOut_Prin3 As Decimal
  Dim mvarOut_Prin4 As Decimal
  Dim mvarOut_Fee1 As Decimal
  Dim mvarOut_Fee2 As Decimal
  Dim mvarOut_Fee3 As Decimal
  Dim mvarOut_Fee4 As Decimal

  Dim mvarOut_Lien1 As Decimal
  Dim mvarOut_Lien2 As Decimal
  Dim mvarOut_Lien3 As Decimal
  Dim mvarOut_Lien4 As Decimal
  Dim mvarOut_Due1 As Decimal
  Dim mvarOut_Due2 As Decimal
  Dim mvarOut_Due3 As Decimal
  Dim mvarOut_Due4 As Decimal

  'end add ----------------------------------

#End Region

#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
    myTXPROF = New TXPROF.MyData(MyDBConn)
    myGNET = New GNET.MyData()
    myGNET.MyDBConn = MyDBConn
    myTXINV = New TXINV.MyData(MyDBConn)
    myTXINVLP = New TXINVLP.MyData(MyDBConn)
    myTXHSTL4 = New TXHSTL4.MyData(MyDBConn)
    myTXPROF = New TXPROF.MyData(MyDBConn)
    myTXTYPE = New TXTYPE.MyData(MyDBConn)
    myTXCOEA = New TXCOEAL1.MyData(MyDBConn)
    myUTCOEA = New UTCOEAL1.MyData(MyDBConn)
    myTXMVFEE = New TXMVFEE.MyData(MyDBConn)
  End Sub
#End Region


#Region "Subroutines"

  Public Sub CalcDue()
    Dim Found As Boolean
    Dim WrkDate As Integer
    Dim WrkLienAmt As Decimal
    Dim WrkOrigTax(3) As Decimal
    Dim WrkAdj(3) As Decimal
    Dim WrkPaid(3) As Decimal
    Dim WrkBond(3) As Decimal
    Dim WrkBondPaid(3) As Decimal
    Dim WrkInstallAmt As Decimal
    Dim WrkFees As Decimal
    Dim WrkTotRec As Decimal
    Dim WrkTotBondRec As Decimal
    Dim WrkTotFeePaid As Decimal
    Dim WrkTotBondPaid As Decimal
    Dim WrkLienPaid As Decimal
    Dim WrkPrinPd(3) As Boolean
    Dim WrkCCAdd As Boolean
    Dim WrkGracePeriod As Boolean
    Dim WrkInstallNo As Integer
    Dim X As Integer
    'TXPROF
    Dim ProfPrPerd As Integer
    Dim ProfPrLien As Decimal
    Dim ProfTxDt(3) As Date
    Dim ProfTxGd(3) As Date
    'TXINV
    Dim InvDist As Integer
    Dim InvPhs As String
    Dim InvPayRec As Decimal
    Dim InvNewPay As Decimal
    Dim InvCCNo As Integer
    Dim InvCCTx1 As Decimal
    Dim InvCCTx2 As Decimal
    Dim InvCCTx3 As Decimal
    Dim InvCCTx4 As Decimal
    Dim InvCCDate As Date
    Dim InvTaxT As Decimal
    Dim InvTax1 As Decimal
    Dim InvTax2 As Decimal
    Dim InvTax3 As Decimal
    Dim InvTax4 As Decimal
    Dim InvDeferT As Decimal
    Dim InvDefer1 As Decimal
    Dim InvDefer2 As Decimal
    Dim InvDefer3 As Decimal
    Dim InvDefer4 As Decimal
    Dim InvLien As String
    Dim InvBond As Decimal
    Dim InvBondPaid As Decimal
    Dim InvBondTemp As Decimal
    Dim InvProrateDt As Date
    'TXHST
    Dim HstAdjcd As String
    Dim HstRcode As String
    'Dim HstPamt As Decimal
    'Dim HstPCamt As Decimal
    'Dim HstPencd As String
    Dim HstLamt As Decimal
    Dim HstPDate As Date
    Dim ChkDate As Date

    If Not WrkFirstCAFee Then
      myCAFee = GetGNET("CAFEE")
      WrkFirstCAFee = True
    End If

    If Not WrkFirstCCAdd Then
      myCCAddDate = GetGNET("CCADD")
      WrkFirstCCAdd = True
    End If

    If Not WrkFirstCCDt Then
      MyCCDateInt = GetGNET("CCDT")
      WrkFirstCCDt = True
    End If

    If Not WrkFirstMVFee Then
      myTXMVFEE.GetOneRecordP(1)
      WrkFirstMVFee = True
    End If

    If Not WrkFirstIntBond Then
      MyIntBond = GetGNET("INTBI")
      WrkFirstIntBond = True
    End If

    sbDebug = New StringBuilder

    Out_Lien = 0
    Out_Fee = 0
    Out_CAFee = 0
    Out_Prin = 0
    Out_Tot = 0
    Out_Bond = 0
    Out_BondPaid = 0
    Out_FeePaid = 0
    Out_GracePeriod = False
    Out_Method = ""
    'Strip off time from date/time 
    In_Date = In_Date.ToShortDateString
    sbDebug.Append(In_ListNo & "-" & In_Type & "-" & In_Year)

    myTXINV.GetOneRecordP(In_ListNo, In_Year, In_Type)
    If myTXINV.IsEOF Then
      Out_Debug = "Invalid Invoice Record"
      Exit Sub
    End If
    If myTXINV._PHASE = "0" Then
      InvPhs = ""
    Else
      InvPhs = myTXINV._PHASE
    End If
    InvDist = myTXINV._DIST
    InvPayRec = myTXINV._PAYREC
    InvNewPay = myTXINV._NEWPAY
    InvCCNo = myTXINV._CCNO
    InvCCTx1 = myTXINV._CCTX1
    InvCCTx2 = myTXINV._CCTX2
    InvCCTx3 = myTXINV._CCTX3
    InvCCTx4 = myTXINV._CCTX4
    InvCCDate = GetDBDate(myTXINV._CDATE)
    InvTaxT = myTXINV._TAXT
    InvTax1 = myTXINV._TAX1
    InvTax2 = myTXINV._TAX2
    InvTax3 = myTXINV._TX3RD
    InvTax4 = myTXINV._TX4TH
    If InvTax1 = 0 And InvTax2 = 0 And InvTax3 = 0 And InvTax4 = 0 And InvTaxT > 0 Then
      InvTax1 = InvTaxT
    End If
    If myTXINV._ICODE = "D" Then
      InvDeferT = myTXINV._DEFERT
      InvDefer1 = myTXINV._DEFER1
      InvDefer2 = myTXINV._DEFER2
      InvDefer3 = myTXINV._DEFER3
      InvDefer4 = myTXINV._DEFER4
      sbDebug.Append(vbCrLf & "Deferred:" & InvDeferT)
    Else
      InvDeferT = 0
      InvDefer1 = 0
      InvDefer2 = 0
      InvDefer3 = 0
      InvDefer4 = 0
    End If
    WrkFees = 0
    If myTXINV._MVFLAG = "Y" Or myTXINV._MVFLAG = "M" Then
      If Not myTXMVFEE.RecordNotFound Then
        WrkFees = myTXMVFEE._MVFEE
      End If
    End If
    WrkFees = WrkFees + myTXINV._FED1 + myTXINV._FED2 + myTXINV._FED3 +
  myTXINV._FED4 + myTXINV._FED5
    InvLien = myTXINV._LIEN
    InvBond = myTXINV._BOND
    InvBondPaid = myTXINV._BONDP
    InvBondTemp = myTXINV._BONT
    InvProrateDt = GetDBDate(myTXINV._PDAT)

    If myTXTYPE._TYCODE <> In_Type Then
      myTXTYPE.GetOneRecordP(In_Type)
      If myTXTYPE.IsEOF Then
        Out_Debug = "Invalid Type-" & In_Type
        Exit Sub
      End If
      If myTXTYPE._TXFAM = "M" Or myTXTYPE._TXFAM = "S" Then 'MV/SU: always use C/C add date 
        myCCAddDate = True
      End If
    End If

    If myTXTYPE._TXREV = "P" Then
      InvDist = myTXINV._PDST
      sbDebug.Append(vbCrLf & "Use Print District")
    End If

    sbDebug.Append(vbCrLf & "Dist: " & InvDist & ", Phase: " & InvPhs)
    WrkTotRec = InvPayRec + InvNewPay
    WrkTotBondRec = InvBondPaid

    Found = False
    If In_Type <> myTXPROF._PRTYPE Or
   In_Year <> myTXPROF._PRYEAR Or
   InvPhs <> Trim(myTXPROF._PHS) Or
   InvDist <> myTXPROF._DIST Then
      myTXPROF.GetOneRecordP(In_Type, In_Year, InvPhs, InvDist)
      If myTXPROF.IsEOF Then
        Out_Debug = "Invalid Profile-" & In_Type & " " & Str(In_Year) & " " &
        InvDist & "/" & InvPhs
        Exit Sub
      End If
    End If

    ProfPrPerd = myTXPROF._PRPERD
    ProfPrLien = myTXPROF._PRLIEN
    ProfTxDt(0) = GetDBDateMDY(myTXPROF._PRDUE1)
    ProfTxDt(1) = GetDBDateMDY(myTXPROF._PRDUE2)
    ProfTxDt(2) = GetDBDateMDY(myTXPROF._PRDUE3)
    ProfTxDt(3) = GetDBDateMDY(myTXPROF._PRDUE4)
    ProfTxGd(0) = GetDBDateMDY(myTXPROF._PRGRD1)
    ProfTxGd(1) = GetDBDateMDY(myTXPROF._PRGRD2)
    ProfTxGd(2) = GetDBDateMDY(myTXPROF._PRGRD3)
    ProfTxGd(3) = GetDBDateMDY(myTXPROF._PRGRD4)

    WrkOrigTax(0) = InvTax1
    WrkOrigTax(1) = InvTax2
    WrkOrigTax(2) = InvTax3
    WrkOrigTax(3) = InvTax4
    If InvCCNo = 0 Then
      sbDebug.Append(vbCrLf & "Tax")
      WrkAdj(0) = InvTax1 - InvDefer1
      WrkAdj(1) = InvTax2 - InvDefer2
      WrkAdj(2) = InvTax3 - InvDefer3
      WrkAdj(3) = InvTax4 - InvDefer4
    Else
      If InvTaxT = 0 Then
        sbDebug.Append(vbCrLf & "C/C Add: " & InvCCNo)
        WrkCCAdd = True
      Else
        sbDebug.Append(vbCrLf & "C/C: " & InvCCNo)
      End If
      WrkAdj(0) = InvCCTx1
      WrkAdj(1) = InvCCTx2
      WrkAdj(2) = InvCCTx3
      WrkAdj(3) = InvCCTx4
    End If

    If MyIntBond And myTXTYPE._TXFAM = "A" Then
      If WrkAdj(1) > 0 Then
        WrkInstallAmt = (WrkAdj(0) + WrkAdj(1) + InvBond) / 2
        WrkBond(0) = WrkInstallAmt - WrkAdj(0)
        WrkBond(1) = WrkInstallAmt - WrkAdj(1)
      Else
        WrkBond(0) = InvBond
        WrkBond(1) = 0
      End If
      WrkBond(2) = 0
      WrkBond(3) = 0
    End If

    'Amounts are not due if before Grace Dates
    If In_Date < ProfTxGd(0) Then
      sbDebug.Append(vbCrLf & "Before Grace Date(0): " & ProfTxGd(0))
      WrkAdj(0) = 0
    End If
    If In_Date < ProfTxGd(1) Then
      sbDebug.Append(vbCrLf & "Before Grace Date(1): " & ProfTxGd(1))
      WrkAdj(1) = 0
    End If
    If In_Date < ProfTxGd(2) Then
      sbDebug.Append(vbCrLf & "Before Grace Date(2): " & ProfTxGd(2))
      WrkAdj(2) = 0
    End If
    If In_Date < ProfTxGd(3) Then
      sbDebug.Append(vbCrLf & "Before Grace Date(3): " & ProfTxGd(3))
      WrkAdj(3) = 0
    End If

    If Trim$(InvLien) = "L" Then
      WrkLienAmt = ProfPrLien
    End If
    X = -1

    WrkDate = 0
    WrkTotBondPaid = 0
    WrkTotFeePaid = 0

    myTXHSTL4.SetRange(In_ListNo, In_Year, In_Type, WrkDate, False)
ReadHist:
    myTXHSTL4.ReadFileE()
    If Not myTXHSTL4.IsEOF Then
      HstRcode = myTXHSTL4._RCODE
      If HstRcode = "I" Then GoTo ReadHist
      If HstRcode = "V" Then GoTo ReadHist
      HstAdjcd = myTXHSTL4._ADJCD
      'HstPamt = myTXHSTL4._PAMT
      'HstPCamt = myTXHSTL4._PCAMT
      'HstPencd = myTXHSTL4._PENCD
      'HstLamt = myTXHSTL4._LAMT
      WrkLienPaid = WrkLienPaid + HstLamt
      If HstAdjcd <> "A" And HstAdjcd <> "R" Then
        If myTXHSTL4._CDATE < myTXHSTL4._PDATE Then
          HstPDate = GetDBDate(myTXHSTL4._CDATE)
        Else
          HstPDate = GetDBDate(myTXHSTL4._PDATE)
        End If
        Select Case Trim(myTXHSTL4._CORC)
          Case 1
            Out_Method = "Cash"
          Case 2
            If myTXHSTL4._BATCHA = "W" Then
              Out_Method = "ECheck"
            Else
              Out_Method = "Check"
            End If
          Case 3
            Out_Method = "Credit"
          Case Else
            Out_Method = ""
        End Select
      End If
      GoTo ReadHist
    End If

    If WrkLienPaid < 0 Then
      WrkLienPaid = 0
    End If

NextPerd:
    X += 1
    If X >= ProfPrPerd Then GoTo IntDone
    If WrkTotRec >= WrkAdj(X) Then
      WrkPaid(X) = WrkAdj(X)
      WrkTotRec = WrkTotRec - WrkAdj(X)
    Else
      WrkPaid(X) = WrkTotRec
      WrkTotRec = 0
    End If

    If MyIntBond And myTXTYPE._TXFAM = "A" Then
      If WrkTotBondRec >= WrkBond(X) Then
        WrkBondPaid(X) = WrkBond(X)
        WrkTotBondRec = WrkTotBondRec - WrkBond(X)
      Else
        WrkBondPaid(X) = WrkTotBondRec
        WrkTotBondRec = 0
      End If
      sbDebug.Append(vbCrLf & "(IntBond) Bond: " & Round(WrkBond(X), 2))
      sbDebug.Append(vbCrLf & "(IntBond) Bond Paid: " & Round(WrkBondPaid(X), 2))
    End If

    sbDebug.Append(vbCrLf & "WrkAdj-WrkPaid: " & Round(WrkAdj(X) - WrkPaid(X), 2))
    If MyIntBond And myTXTYPE._TXFAM = "A" Then
      sbDebug.Append(vbCrLf & "WrkBond-WrkBondPaid: " & Round(WrkBond(X) - WrkBondPaid(X), 2))
      sbDebug.Append(vbCrLf & "WrkInstallAmt: " & Round(WrkInstallAmt, 2))
    End If
    GoTo NextPerd

IntDone:
    If HstPDate = ChkDate Then
      If WrkCCAdd Then
        HstPDate = InvCCDate
      Else
        If HstPDate <= ProfTxGd(0) Then
          HstPDate = ProfTxDt(0)
          sbDebug.Append(vbCrLf & "Hist Date/Pre-Grace(" & X & "):" & HstPDate)
        End If
      End If
    End If

    Out_Prin = WrkAdj(0) + WrkAdj(1) + WrkAdj(2) + WrkAdj(3)
    Out_Prin = Round(Out_Prin - WrkPaid(0) - WrkPaid(1) - WrkPaid(2) - WrkPaid(3), 2)
    If WrkLienAmt > 0 Then
      Out_Lien = WrkLienAmt - WrkLienPaid
    Else
      Out_Lien = 0
    End If
    If Out_Prin > 0 Then
      Out_Fee = WrkFees
    Else
      Out_Fee = 0
    End If
    If Out_Prin > 0 Then
      Out_Bond = InvBond - InvBondPaid - InvBondTemp
    Else
      Out_Bond = 0
    End If
    If Out_Bond < 0 Then
      Out_Bond = 0
    End If
    Out_Tot = Round(Out_Prin + Out_Fee + Out_Lien + Out_Bond, 2)
    If myCAFee And myTXINV._AGY <> " " Then
      Out_CAFee = Round(Out_Tot * 0.15, 2)
      Out_Fee = Out_Fee + Out_CAFee
      Out_Tot = Out_Tot + Out_CAFee
      sbDebug.Append(vbCrLf & "CA Fee: " & Out_CAFee)
    End If
    Out_Date = HstPDate
    Out_FeePaid = WrkTotFeePaid
    Out_BondPaid = WrkTotBondPaid
    Out_GracePeriod = WrkGracePeriod
    sbDebug.Append(vbCrLf & "Method " & myTXHSTL4._CORC)
    sbDebug.Append(vbCrLf & "Grace Period?: " & WrkGracePeriod)
    sbDebug.Append(vbCrLf & "Install No: " & WrkInstallNo)
    Out_Debug = sbDebug.ToString
    sbDebug = Nothing
  End Sub
#End Region

  Private Function GetDBDate(ByVal DateIn As Integer) As Date
    Dim WrkDate As Date
    Dim StrDate As String

    If DateIn > 0 Then
      StrDate = Trim$(Str(DateIn))
      WrkDate = Mid$(StrDate, 5, 2) & "/" & Right$(StrDate, 2) & "/" & Left$(StrDate, 4)
    End If
    Return WrkDate
  End Function

  Private Function GetDBDateMDY(ByVal DateIn As Integer) As Date
    Dim WrkDate As Date
    Dim StrDate As String
    Dim WrkLen As Integer

    StrDate = Trim$(Str(DateIn))
    WrkLen = Len(StrDate)
    If WrkLen = 8 Then
      WrkDate = Left$(StrDate, 2) & "/" & Mid$(StrDate, 3, 2) & "/" & Right$(StrDate, 4)
    End If
    If WrkLen = 7 Then
      WrkDate = Left$(StrDate, 1) & "/" & Mid$(StrDate, 2, 2) & "/" & Right$(StrDate, 4)
    End If
    Return WrkDate
  End Function

  Private Function SetDBDate(ByVal DateIn As Date) As Integer
    Dim WrkDate As Integer
    Dim StrDate As String

    StrDate = Year(DateIn) & Format(Month(DateIn), "00") &
    Format(DatePart(DateInterval.Day, DateIn), "00")
    WrkDate = Val(StrDate)
    Return WrkDate
  End Function
  Private Function Round(ByVal Number As Decimal, ByVal Decimals As Integer) As Double
    'Round numbers normally. Note that Math.round uses banker's rounding.
    Dim WrkNo As Decimal
    Dim WrkInt As Long
    Select Case Decimals
      Case 0
        WrkNo = Math.Floor(Number + 0.5)
      Case 1
        WrkNo = Number * 10
        WrkInt = Math.Floor(WrkNo + 0.5)
        WrkNo = WrkInt / 10
      Case 2
        WrkNo = Number * 100
        WrkInt = Math.Floor(WrkNo + 0.5)
        WrkNo = WrkInt / 100
      Case 3
        WrkNo = Number * 1000
        WrkInt = Math.Floor(WrkNo + 0.5)
        WrkNo = WrkInt / 1000
      Case 4
        WrkNo = Number * 10000
        WrkInt = Math.Floor(WrkNo + 0.5)
        WrkNo = WrkInt / 10000
    End Select

    Return WrkNo
  End Function

  Public Sub GetOrigCCDate(ByRef Found As Boolean, ByRef Out_CCDate As Date)
    Found = False
    myTXCOEA.SetRange(In_ListNo, In_Year, In_Type, 0, 0, False)
    myTXCOEA.ReadFileE()
    If Not myTXCOEA.IsEOF Then
      Out_CCDate = GetDBDate(myTXCOEA._CDATE)
      Found = True
    End If
  End Sub
  Public Sub GetOrigCCDateUB(ByRef Found As Boolean, ByRef Out_CCDate As Date)
    Found = False
    myUTCOEA.SetRange(In_ListNo, In_Year, In_Type, 0, 0, False)
    myUTCOEA.ReadFileE()
    If Not myUTCOEA.IsEOF Then
      Out_CCDate = GetDBDate(myUTCOEA._CDATE)
      Found = True
    End If
  End Sub
  Public Function GetGNET(ByVal Code As String) As Boolean
    If IsNothing(Code) Or Code = "" Then
      Return False
    End If

    myGNET.GetOneRecordP(Code)
    If Not myGNET.RecordNotFound Then
      If myGNET._VALUE = "Y" Then
        GetGNET = True
      End If
    Else
      GetGNET = False
    End If
    Return GetGNET

  End Function
  Public Sub CloseFiles()
    myTXINV.CloseFile()
    myTXHSTL4.CloseFile()
    myTXPROF.CloseFile()
    myTXTYPE.CloseFile()
    myTXCOEA.CloseFile()
    myUTCOEA.CloseFile()
    myTXMVFEE.CloseFile()
    myTXINV = Nothing
    myTXHSTL4 = Nothing
    myTXPROF = Nothing
    myTXTYPE = Nothing
    myTXCOEA = Nothing
    myUTCOEA = Nothing
    myTXMVFEE = Nothing
  End Sub

#Region "Properties"


  Public Property In_ListNo() As Integer
    Get
      In_ListNo = mvarIn_ListNo
    End Get
    Set(ByVal Value As Integer)
      mvarIn_ListNo = Value
    End Set
  End Property

  Public Property In_Year() As Integer
    Get
      In_Year = mvarIn_Year
    End Get
    Set(ByVal Value As Integer)
      mvarIn_Year = Value
    End Set
  End Property

  Public Property In_Type() As String
    Get
      In_Type = mvarIn_Type
    End Get
    Set(ByVal Value As String)
      mvarIn_Type = Value
    End Set
  End Property

  Public Property In_Date() As Date
    Get
      In_Date = mvarIn_Date
    End Get
    Set(ByVal Value As Date)
      mvarIn_Date = Value
    End Set
  End Property

  Public Property Out_Lien() As Decimal
    Get
      Out_Lien = mvarOut_Lien
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Lien = Value
    End Set
  End Property
  Public Property Out_Fee() As Decimal
    Get
      Out_Fee = mvarOut_Fee
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Fee = Value
    End Set
  End Property
  Public Property Out_CAFee() As Decimal
    Get
      Out_CAFee = mvarOut_CAFee
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_CAFee = Value
    End Set
  End Property
  Public Property Out_Prin() As Decimal
    Get
      Out_Prin = mvarOut_Prin
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Prin = Value
    End Set
  End Property
  Public Property Out_Tot() As Decimal
    Get
      Out_Tot = mvarOut_Tot
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Tot = Value
    End Set
  End Property
  Public Property Out_Bond() As Decimal
    Get
      Out_Bond = mvarOut_Bond
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Bond = Value
    End Set
  End Property
  Public Property Out_FeePaid() As Decimal
    Get
      Out_FeePaid = mvarOut_FeePaid
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_FeePaid = Value
    End Set
  End Property
  Public Property Out_BondPaid() As Decimal
    Get
      Out_BondPaid = mvarOut_BondPaid
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_BondPaid = Value
    End Set
  End Property
  Public Property Out_GracePeriod() As Boolean
    Get
      Out_GracePeriod = mvarOut_GracePeriod
    End Get
    Set(ByVal Value As Boolean)
      mvarOut_GracePeriod = Value
    End Set
  End Property
  Public Property Out_Method() As String
    Get
      Out_Method = mvarOut_Method
    End Get
    Set(ByVal Value As String)
      mvarOut_Method = Value
    End Set
  End Property
  Public Property Out_Date() As Date
    Get
      Out_Date = mvarOut_Date
    End Get
    Set(ByVal Value As Date)
      mvarOut_Date = Value
    End Set
  End Property
  Public Property Out_Debug() As String
    Get
      Out_Debug = mvarOut_Debug
    End Get
    Set(ByVal Value As String)
      mvarOut_Debug = Value
    End Set
  End Property
#End Region
End Class


