Imports System.Text
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim WrkFirstCAFee As Boolean
  Dim WrkFirstCCAdd As Boolean
  Dim WrkFirstCCDt As Boolean
  Dim WrkFirstMVFee As Boolean
  Dim WrkFirstIntBond As Boolean
  Dim WrkLowInt As Boolean
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
  Dim mvarIn_IntDate As Date
  Dim mvarOut_Int As Decimal
  Dim mvarOut_IntOrig As Decimal
  Dim mvarOut_ProfMinInt As Decimal
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
  Dim mvarOut_IntDate As Date
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
  Dim mvarOut_IntDate1 As Date
  Dim mvarOut_IntDate2 As Date
  Dim mvarOut_IntDate3 As Date
  Dim mvarOut_IntDate4 As Date
  Dim mvarOut_Int1 As Decimal
  Dim mvarOut_Int2 As Decimal
  Dim mvarOut_Int3 As Decimal
  Dim mvarOut_Int4 As Decimal
  Dim mvarOut_IntOrig1 As Decimal 'added 5/21/25
  Dim mvarOut_IntOrig2 As Decimal 'added 5/21/25
  Dim mvarOut_IntOrig3 As Decimal 'added 5/21/25
  Dim mvarOut_IntOrig4 As Decimal 'added 5/21/25
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

  Public Sub CalcInterest()
    Dim Found As Boolean
    Dim FoundCC As Boolean
    Dim ChkDate As Date
    Dim WrkDate As Integer
    Dim WrkTotInt As Decimal
    Dim WrkLienAmt As Decimal
    Dim WrkOrigTax(3) As Decimal
    Dim WrkAdj(3) As Decimal
    Dim WrkPaid(3) As Decimal
    Dim WrkBond(3) As Decimal
    Dim WrkBondPaid(3) As Decimal
    Dim WrkInstallAmt As Decimal
    Dim WrkLeft As Decimal
    Dim WrkFees As Decimal
    Dim WrkTotRec As Decimal
    Dim WrkTotBondRec As Decimal
    Dim WrkIntDate(3) As Date
    Dim WrkInt(3) As Decimal
    Dim WrkIntOrig(3) As Decimal
    Dim WrkIntCollect(3) As Boolean
    Dim WrkTotIntPaid As Decimal
    Dim WrkIntPartialPaid As Decimal
    Dim WrkTotFeePaid As Decimal
    Dim WrkTotBondPaid As Decimal
    Dim WrkLienPaid As Decimal
    Dim WrkPrinPd(3) As Boolean
    Dim WrkTPerc As Decimal
    Dim WrkMonths As Integer
    Dim WrkYear As Integer
    Dim WrkAdjFnd As Boolean
    Dim WrkAdjAmt As Decimal
    Dim WrkCCAdd As Boolean
    Dim WrkCCDt As Date
    Dim WrkCCDtAdd As Date
    Dim WrkProrateDt As Date
    Dim WrkUnposted As Boolean
    Dim WrkGracePeriod As Boolean
    Dim WrkHighListNo As Integer
    Dim WrkInstallNo As Integer
    Dim X As Integer
    'TXPROF
    Dim ProfPrPerd As Integer
    Dim ProfPrLien As Decimal
    Dim ProfTxDt(3) As Date
    Dim ProfTxGd(3) As Date
    Dim ProfPrmini As Decimal
    Dim ProfPrInt As Decimal
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
    Dim HstPamt As Decimal
    Dim HstIamt As Decimal
    Dim HstPCamt As Decimal
    Dim HstPencd As String
    Dim HstLamt As Decimal
    'Based on 2 fields: Pdate or cdate
    Dim HstIntDate As Date

    If Not WrkFirstCAFee Then
      myCAFee = GetGNET("CAFEE")
      WrkFirstCAFee = True
    End If

    If Not WrkFirstCCAdd Then
      myCCAddDate = GetGNET("CCADD")
      WrkFirstCCAdd = True
    End If

    If Not WrkFirstCCDt Then
      myCCDateInt = GetGNET("CCDT")
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

    If Not WrkLowInt Then
      myLowInt = GetGNET("LOWIN")
      WrkLowInt = True
    End If

    sbDebug = New StringBuilder

    '==============================================
    ' ken 6/21/24
    '==============================================
    Out_Prin1 = 0
    Out_Prin2 = 0
    Out_Prin3 = 0
    Out_Prin4 = 0
    Out_Lien1 = 0
    Out_Lien2 = 0
    Out_Lien3 = 0
    Out_Lien4 = 0
    Out_Due1 = 0
    Out_Due2 = 0
    Out_Due3 = 0
    Out_Due4 = 0
    Out_Fee1 = 0
    Out_Fee2 = 0
    Out_Fee3 = 0
    Out_Fee4 = 0



    ' end add =====================================

    Out_Int = 0
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
    In_IntDate = In_IntDate.ToShortDateString
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
    ProfPrmini = myTXPROF._PRMINI

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

    'Amounts are not due if before Billing Dates
    If In_IntDate < ProfTxDt(0) Then
      sbDebug.Append(vbCrLf & "Before Bill Date(0): " & ProfTxDt(0))
      WrkAdj(0) = 0
    End If
    If In_IntDate < ProfTxDt(1) Then
      sbDebug.Append(vbCrLf & "Before Bill Date(1): " & ProfTxDt(1))
      WrkAdj(1) = 0
    End If
    If In_IntDate < ProfTxDt(2) Then
      sbDebug.Append(vbCrLf & "Before Bill Date(2): " & ProfTxDt(2))
      WrkAdj(2) = 0
    End If
    If In_IntDate < ProfTxDt(3) Then
      sbDebug.Append(vbCrLf & "Before Bill Date(3): " & ProfTxDt(3))
      WrkAdj(3) = 0
    End If

    If Trim$(InvLien) = "L" Then
      WrkLienAmt = ProfPrLien
    End If
    X = -1

    WrkAdjFnd = False
    WrkDate = 0
    WrkTotIntPaid = 0
    WrkTotBondPaid = 0
    WrkTotFeePaid = 0

    myTXHSTL4.SetRange(In_ListNo, In_Year, In_Type, WrkDate, False)
ReadHist:
    myTXHSTL4.ReadFileE()
    If Not myTXHSTL4.IsEOF Then
      HstRcode = myTXHSTL4._RCODE
      If HstRcode = "I" Then GoTo NextHist
      If HstRcode = "V" Then GoTo NextHist
      HstAdjcd = myTXHSTL4._ADJCD
      HstPamt = myTXHSTL4._PAMT
      HstIamt = myTXHSTL4._IAMT
      HstPCamt = myTXHSTL4._PCAMT
      HstPencd = myTXHSTL4._PENCD
      HstLamt = myTXHSTL4._LAMT
      If myTXHSTL4._CDATE < myTXHSTL4._PDATE Then
        HstIntDate = GetDBDate(myTXHSTL4._CDATE)
      Else
        HstIntDate = GetDBDate(myTXHSTL4._PDATE)
      End If
      If HstPamt > 0 Or HstIamt > 0 Then
        WrkInstallNo = 0
        If ProfPrPerd > 1 And HstIntDate > ProfTxGd(1) And WrkAdj(1) > 0 Then
          WrkInstallNo = 1
        End If
        If ProfPrPerd > 1 And HstIntDate > ProfTxGd(2) And WrkAdj(2) > 0 Then
          WrkInstallNo = 2
        End If
        If ProfPrPerd > 1 And HstIntDate > ProfTxGd(3) And WrkAdj(3) > 0 Then
          WrkInstallNo = 3
        End If
      End If
      If HstAdjcd <> "A" And HstAdjcd <> "R" Then
        If HstPamt > 0 Or (MyIntBond And HstPCamt > 0 And myTXHSTL4._PENCD = "BI") Then
          WrkIntDate(WrkInstallNo) = HstIntDate
          WrkPrinPd(WrkInstallNo) = True
          WrkIntPartialPaid = 0
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
          Out_IntDate = HstIntDate
          If WrkIntDate(0) < HstIntDate Then
            WrkIntDate(0) = HstIntDate
            WrkPrinPd(0) = True
          End If
          If WrkIntDate(1) < HstIntDate Then
            WrkIntDate(1) = HstIntDate
            WrkPrinPd(1) = True
          End If
          If WrkIntDate(2) < HstIntDate Then
            WrkIntDate(2) = HstIntDate
            WrkPrinPd(2) = True
          End If
          If WrkIntDate(3) < HstIntDate Then
            WrkIntDate(3) = HstIntDate
            WrkPrinPd(3) = True
          End If
        Else
          WrkIntPartialPaid = WrkIntPartialPaid + HstIamt
        End If
        WrkTotIntPaid = WrkTotIntPaid + HstIamt
        WrkLienPaid = WrkLienPaid + HstLamt
      Else
        If HstPamt = 0 And HstIamt <> 0 Then
          WrkIntPartialPaid = WrkIntPartialPaid + HstIamt
        End If
        WrkTotIntPaid = WrkTotIntPaid + HstIamt
        WrkLienPaid = WrkLienPaid + HstLamt
        WrkAdjFnd = True
      End If
      If HstIamt <> 0 Then
        Select Case WrkInstallNo
          Case 0
            WrkIntCollect(0) = True
          Case 1
            WrkIntCollect(0) = True
            WrkIntCollect(1) = True
          Case 2
            WrkIntCollect(0) = True
            WrkIntCollect(1) = True
            WrkIntCollect(2) = True
          Case 3
            WrkIntCollect(0) = True
            WrkIntCollect(1) = True
            WrkIntCollect(2) = True
            WrkIntCollect(3) = True
        End Select
      End If
      If HstPCamt <> 0 Then
        If HstPencd = "BI" Then
          WrkTotBondPaid = WrkTotBondPaid + HstPCamt
        Else
          WrkTotFeePaid = WrkTotFeePaid + HstPCamt
        End If
      End If
NextHist:
      GoTo ReadHist
    End If

    If WrkIntPartialPaid < 0 Then
      WrkIntPartialPaid = 0
    End If
    If WrkLienPaid < 0 Then
      WrkLienPaid = 0
    End If

    'Adjustment - Change interest date to last principal payment date
    If WrkAdjFnd Then
      WrkAdjFnd = False 'Reset flag
      WrkAdjAmt = 0
      WrkDate = 99999999
      WrkIntPartialPaid = 0

      myTXHSTL4.SetRange(In_ListNo, In_Year, In_Type, WrkDate, True)
ReadHist2:
      myTXHSTL4.ReadFilePE()
      If Not myTXHSTL4.IsEOF Then
        HstRcode = myTXHSTL4._RCODE
        If HstRcode = "I" Then GoTo NextHistAdj
        If HstRcode = "V" Then GoTo NextHistAdj
        HstAdjcd = myTXHSTL4._ADJCD
        HstPamt = myTXHSTL4._PAMT
        HstIamt = myTXHSTL4._IAMT
        'Adjustment/Refund is not last principal entry
        If HstAdjcd <> "A" And HstAdjcd <> "R" And HstPamt > 0 And Not WrkAdjFnd Then
          GoTo NextPerd
        End If
        WrkAdjFnd = True
        WrkAdjAmt = WrkAdjAmt + HstPamt
        If HstPamt = 0 And HstIamt <> 0 Then
          WrkIntPartialPaid = WrkIntPartialPaid + HstIamt
        End If
        If HstAdjcd <> "A" And WrkAdjAmt > 0 Then
          If myTXHSTL4._CDATE < myTXHSTL4._PDATE Then
            HstIntDate = GetDBDate(myTXHSTL4._CDATE)
          Else
            HstIntDate = GetDBDate(myTXHSTL4._PDATE)
          End If
          sbDebug.Append(vbCrLf & "Adjust Amount " & WrkAdjAmt)
          sbDebug.Append(vbCrLf & "Int (Adjust) Date " & HstIntDate & " " & WrkInstallNo)
          WrkIntDate(WrkInstallNo) = HstIntDate
          If HstIntDate < ProfTxGd(WrkInstallNo) Then
            WrkIntDate(WrkInstallNo) = HstIntDate
            If WrkAdjAmt = WrkAdj(WrkInstallNo) Then
              WrkPrinPd(WrkInstallNo) = False
            End If
          End If
          GoTo NextPerd
        End If
NextHistAdj:
        GoTo ReadHist2
      End If
    End If

NextPerd:
    X += 1
    If X >= ProfPrPerd Then GoTo IntDone
    If WrkAdjFnd Then
      If WrkAdjAmt = 0 Then
        WrkIntDate(X) = ProfTxDt(X)
        WrkPrinPd(X) = False
      End If
      If WrkIntDate(X) > WrkIntDate(WrkInstallNo) Then
        If WrkAdjAmt = 0 Then
          WrkIntDate(X) = ProfTxDt(X)
          WrkPrinPd(X) = False
        Else
          WrkIntDate(X) = HstIntDate
        End If
      End If
    End If

    sbDebug.Append(vbCrLf & "Profile Due Date: " & ProfTxDt(X))
    If ProfTxGd(X) <> ChkDate Then
      sbDebug.Append(vbCrLf & "Profile Grace Date: " & ProfTxGd(X))
    Else
      ProfTxGd(X) = DateAdd(DateInterval.Month, 1, ProfTxDt(X))
      sbDebug.Append(vbCrLf & "Calc Grace Date: " & ProfTxGd(X))
    End If
    WrkInt(X) = 0
    WrkIntOrig(X) = 0

    If MyCCDateInt Then
      If myTXTYPE._TXFAM = "U" Or myTXTYPE._TXFAM = "A" Then
        GetOrigCCDateUB(FoundCC, WrkCCDtAdd)
      Else
        GetOrigCCDate(FoundCC, WrkCCDtAdd)
      End If
    End If

    If WrkIntDate(X) = ChkDate Then
      WrkPrinPd(X) = False
      If myCCAddDate And WrkCCAdd Then
        If myTXTYPE._TXFAM = "U" Or myTXTYPE._TXFAM = "A" Then
          GetOrigCCDateUB(FoundCC, WrkCCDtAdd)
        Else
          GetOrigCCDate(FoundCC, WrkCCDtAdd)
        End If
        If Not FoundCC Then
          WrkCCDtAdd = InvCCDate
        End If
        If myTXTYPE._TXFAM = "P" Then
          WrkHighListNo = myTXINVLP.AutoGenKey(In_Year + 1, In_Type)
          If WrkHighListNo > 1 Then
            WrkIntDate(X) = ProfTxDt(X)
            sbDebug.Append(vbCrLf & "Int (Profile-Prev Yr PP) Date: " & WrkIntDate(X) & " /X: " & X)
          Else
            WrkIntDate(X) = WrkCCDtAdd
            sbDebug.Append(vbCrLf & "Int (Orig. C/C-Curr Yr PP) Date: " & WrkIntDate(X) & " /X: " & X)
          End If
        Else
          If WrkCCDtAdd <> ProfTxDt(X) Then
            WrkIntDate(X) = WrkCCDtAdd
            sbDebug.Append(vbCrLf & "Int (Orig. C/C) Date: " & WrkIntDate(X) & " /X: " & X)
          Else
            WrkIntDate(X) = ProfTxDt(X)
            sbDebug.Append(vbCrLf & "Int (Profile) Date: " & WrkIntDate(X) & " /X: " & X)
          End If
        End If
      Else
        WrkIntDate(X) = ProfTxDt(X)
        sbDebug.Append(vbCrLf & "Int (Profile) Date: " & WrkIntDate(X) & " /X: " & X)
      End If
    End If


    'Prorates - Use Prorate date instead of normal interest date
    If In_Type = "X" Then
      If WrkIntDate(X) < InvProrateDt Then
        WrkIntDate(X) = InvProrateDt
        sbDebug.Append(vbCrLf & "Use Prorate date: " & InvProrateDt)
      End If
    End If

    If HstIntDate <> ChkDate Then
      'If WrkIntDate(0) > WrkIntDate(X) Then
      '  WrkIntDate(X) = WrkIntDate(0)
      '  WrkPrinPd(X) = True
      'End If
      If WrkIntDate(X) <= ProfTxGd(X) Then
        WrkIntDate(X) = ProfTxDt(X)
        sbDebug.Append(vbCrLf & "Hist Date/Pre-Grace(" & X & "):" & HstIntDate)
      End If
    End If

    If WrkTotRec >= WrkAdj(X) Then
      WrkPaid(X) = WrkAdj(X)
      WrkTotRec = WrkTotRec - WrkAdj(X)
    Else
      WrkPaid(X) = WrkTotRec
      WrkTotRec = 0
    End If

    If WrkAdj(X) - WrkPaid(X) < 0 Then GoTo IntDone
    WrkMonths = 0
    If WrkPrinPd(X) And WrkIntDate(X) > ProfTxGd(X) Then
      WrkMonths = DateDiff(DateInterval.Month, WrkIntDate(X), In_IntDate)
    Else
      WrkMonths = DateDiff(DateInterval.Month, WrkIntDate(X), In_IntDate) + 1
    End If

    If MyCCDateInt And WrkOrigTax(X) - WrkPaid(X) = 0 Then
      WrkCCDt = DateAdd(DateInterval.Month, 1, WrkCCDtAdd)
      If In_IntDate <= WrkCCDt Then
        WrkIntDate(X) = WrkCCDtAdd
        WrkMonths = DateDiff(DateInterval.Month, WrkIntDate(X), In_IntDate)
        sbDebug.Append(vbCrLf & "Orig Tax Paid-CC Date: " & WrkIntDate(X))
      End If
    End If
    sbDebug.Append(vbCrLf & "Prin PD?: " & WrkPrinPd(X))
    sbDebug.Append(vbCrLf & "Int Months: " & WrkMonths)

    'ACCUMULATE INTEREST BY YEARLY RATE
    WrkYear = In_Year
    'myTXPROF.GetOneRecordP(In_Type, WrkYear, InvPhs, InvDist)
    If Not myTXPROF.IsEOF Then
      If myTXINV._ICODE = "I" Then
        WrkTPerc = 0
        sbDebug.Append(vbCrLf & "Int Pct: *INACTIVE*")
      Else
        ProfPrInt = myTXPROF._PRINT
        WrkTPerc = Round(WrkMonths * ProfPrInt, 4)
        sbDebug.Append(vbCrLf & "Int Pct: " & WrkTPerc)
      End If
    End If

    If myLowInt And WrkTPerc > 0 And In_Type = "R" And Trim(myTXINV._BKCD) = "" And In_Year = 2019 _
   Or myLowInt And WrkTPerc > 0 And In_Type = "P" And InvDist = 7 And In_Year = 2019 Then
      If In_IntDate >= #2/1/2021# And In_IntDate <= #4/30/2021# And ProfPrInt = 0.015 Then
        Select Case In_IntDate.Month
          Case 2
            WrkTPerc = WrkTPerc - 0.0125
          Case 3
            If WrkMonths > 1 Then
              WrkTPerc = WrkTPerc - 0.025
            Else
              WrkTPerc = 0.0025
            End If
          Case 4
            Select Case WrkMonths
              Case 1
                WrkTPerc = 0.0025
              Case 2
                WrkTPerc = 0.005
              Case Else
                WrkTPerc = WrkTPerc - 0.0375
            End Select
        End Select
        sbDebug.Append(vbCrLf & "Low Int Pct: " & WrkTPerc)
      End If
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

    'CALC INTEREST FOR # OF MONTHS UNPAID INTEREST
    If WrkPaid(X) > 0 Then
      WrkLeft = WrkAdj(X) - WrkPaid(X)
    Else
      WrkLeft = WrkAdj(X)
    End If
    sbDebug.Append(vbCrLf & "Amount Left: " & Round(WrkLeft, 2))
    If MyIntBond And myTXTYPE._TXFAM = "A" Then
      If WrkLeft > 0 Then
        WrkLeft = WrkAdj(X) + WrkBond(X) - WrkPaid(X) - WrkBondPaid(X)
      End If
      sbDebug.Append(vbCrLf & "(IntBond) Amount Left: " & Round(WrkLeft, 2))
    End If
    WrkInt(X) = Round(WrkTPerc * WrkLeft, 2)
    WrkIntOrig(X) = WrkInt(X)
    If WrkInt(X) > 0 Then
      'Check to see if less than minimum interest amount 
      If WrkInt(X) < ProfPrmini Then
        'If no previous interest paid then charge Minimum interest   
        If Not WrkIntCollect(X) Then
          sbDebug.Append(vbCrLf & " " & ProfPrmini & " Min Interest applied: " & WrkInt(X))
          WrkInt(X) = ProfPrmini
        End If
        'If previous interest paid but less than Minimum interest then charge difference  
        If WrkIntCollect(X) And WrkTotIntPaid < ProfPrmini Then
          sbDebug.Append(vbCrLf & " Min Interest left: " & WrkInt(X))
          WrkInt(X) = ProfPrmini
        End If
      End If
    End If

    sbDebug.Append(vbCrLf & "Int Date: " & WrkIntDate(X) & " /X: " & X)
    sbDebug.Append(vbCrLf & "WrkAdj-WrkPaid: " & Round(WrkAdj(X) - WrkPaid(X), 2))
    If MyIntBond And myTXTYPE._TXFAM = "A" Then
      sbDebug.Append(vbCrLf & "WrkBond-WrkBondPaid: " & Round(WrkBond(X) - WrkBondPaid(X), 2))
      sbDebug.Append(vbCrLf & "WrkInstallAmt: " & Round(WrkInstallAmt, 2))
    End If
    sbDebug.Append(vbCrLf & "Interest: " & WrkInt(X))
    'No Interest due during 1st month of C/C Add
    If WrkCCAdd And InvCCDate >= ProfTxDt(X) Then
      If myTXTYPE._TXFAM = "U" Or myTXTYPE._TXFAM = "A" Then
        GetOrigCCDateUB(FoundCC, WrkCCDtAdd)
      Else
        GetOrigCCDate(FoundCC, WrkCCDtAdd)
      End If
      WrkCCDt = DateAdd(DateInterval.Month, 1, WrkCCDtAdd)
      If In_IntDate <= WrkCCDt Then
        If myTXTYPE._TXFAM = "P" Then
          WrkHighListNo = myTXINVLP.AutoGenKey(In_Year + 1, In_Type)
          If WrkHighListNo > 1 Then
            sbDebug.Append(vbCrLf & "PP-C/C Add 1st Month Previous Year")
          Else
            WrkInt(X) = 0
            WrkIntOrig(X) = 0
            sbDebug.Append(vbCrLf & "PP-C/C Add 1st Month Current Year (no interest)")
            WrkGracePeriod = True
          End If
        Else
          WrkInt(X) = 0
          WrkIntOrig(X) = 0
          sbDebug.Append(vbCrLf & "C/C Add 1st Month (no interest)")
          WrkGracePeriod = True
        End If
      End If
    End If
    GoTo NextPerd

IntDone:
    If InvNewPay > 0 Then
      WrkUnposted = True
      WrkInt(0) = 0
      WrkInt(1) = 0
      WrkInt(2) = 0
      WrkInt(3) = 0
      WrkIntOrig(0) = 0
      WrkIntOrig(1) = 0
      WrkIntOrig(2) = 0
      WrkIntOrig(3) = 0
      sbDebug.Append(vbCrLf & "Unposted payment (no int)")
    End If

    'No interest due if before Grace Date
    If In_IntDate <= ProfTxGd(0) Then
      WrkInt(0) = 0
      WrkIntOrig(0) = 0
      WrkGracePeriod = True
      sbDebug.Append(vbCrLf & "Before Grace Date 1 (no int)")
    End If
    If In_IntDate <= ProfTxGd(1) Then
      If WrkInt(1) > 0 And WrkInt(0) = 0 Then WrkGracePeriod = True
      WrkInt(1) = 0
      WrkIntOrig(1) = 0
      sbDebug.Append(vbCrLf & "Before Grace Date 2 (no int)")
    End If
    If In_IntDate <= ProfTxGd(2) Then
      If WrkInt(2) > 0 And WrkInt(1) = 0 Then WrkGracePeriod = True
      WrkInt(2) = 0
      WrkIntOrig(2) = 0
      sbDebug.Append(vbCrLf & "Before Grace Date 3 (no int)")
    End If
    If In_IntDate <= ProfTxGd(3) Then
      If WrkInt(3) > 0 And WrkInt(2) = 0 Then WrkGracePeriod = True
      WrkInt(3) = 0
      WrkIntOrig(3) = 0
      sbDebug.Append(vbCrLf & "Before Grace Date 4 (no int)")
    End If
    'No interest due during 1st month of pro rate
    If In_Type = "X" Then
      WrkProrateDt = DateAdd(DateInterval.Month, 1, InvProrateDt)
      If In_IntDate <= WrkProrateDt Then
        WrkInt(0) = 0
        sbDebug.Append(vbCrLf & "Prorate 1st Month (no interest)")
        WrkGracePeriod = True
      End If
    End If
    If WrkLienPaid > 0 Then
      sbDebug.Append(vbCrLf & "Lien Paid: " & WrkLienPaid)
    End If

    Out_Prin = WrkAdj(0) + WrkAdj(1) + WrkAdj(2) + WrkAdj(3)
    Out_Prin = Round(Out_Prin - WrkPaid(0) - WrkPaid(1) - WrkPaid(2) - WrkPaid(3), 2)
    WrkTotInt = WrkInt(0) + WrkInt(1) + WrkInt(2) + WrkInt(3)
    sbDebug.Append(vbCrLf & "Total Interest: " & Round(WrkTotInt, 2))
    If WrkAdj(WrkInstallNo) - WrkPaid(WrkInstallNo) > 0 Then
      WrkTotInt = WrkTotInt - WrkIntPartialPaid
    End If
    If WrkTotInt < 0 Then
      WrkTotInt = 0
    End If
    Out_Int = Round(WrkTotInt, 2)
    Out_IntOrig = WrkIntOrig(0) + WrkIntOrig(1) + WrkIntOrig(2) + WrkIntOrig(3)
    Out_ProfMinInt = ProfPrmini
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
    Out_Tot = Round(WrkTotInt + Out_Prin + Out_Fee + Out_Lien + Out_Bond, 2)
    If myCAFee And myTXINV._AGY <> " " Then
      Out_CAFee = Round(Out_Tot * 0.15, 2)
      Out_Fee = Out_Fee + Out_CAFee
      Out_Tot = Out_Tot + Out_CAFee
      sbDebug.Append(vbCrLf & "CA Fee: " & Out_CAFee)
    End If

    '=====================================
    ' Ken added 6/21/24
    '=====================================

    Out_Prin1 = WrkAdj(0) - WrkPaid(0)
    Out_Prin2 = WrkAdj(1) - WrkPaid(1)
    Out_Prin3 = WrkAdj(2) - WrkPaid(2)
    Out_Prin4 = WrkAdj(3) - WrkPaid(3)
    Out_profDate1 = ProfTxDt(0)
    Out_profDate2 = ProfTxDt(1)
    Out_profDate3 = ProfTxDt(2)
    Out_profDate4 = ProfTxDt(3)
    Out_Int1 = WrkInt(0)
    Out_Int2 = WrkInt(1)
    Out_Int3 = WrkInt(2)
    Out_Int4 = WrkInt(3)
    Out_IntOrig1 = WrkIntOrig(0)
    Out_IntOrig2 = WrkIntOrig(1)
    Out_IntOrig3 = WrkIntOrig(2)
    Out_IntOrig4 = WrkIntOrig(3)
    Out_Fee1 = 0
    Out_Fee2 = WrkFees    ' Note will need more work if more than 2 periods
    Out_Lien1 = 0          'Lien may be wrong
    Out_Lien2 = Out_Lien ' Note will need more work if more than 2 periods
    Out_Due1 = Out_Prin1 + Out_Int1 + Out_Fee1 + Out_Lien1
    Out_Due2 = Out_Prin2 + Out_Int2 + Out_Fee2 + Out_Lien2
    Out_Due3 = Out_Prin3 + Out_Int3 + Out_Fee3 + Out_Lien3
    Out_Due4 = Out_Prin4 + Out_Int4 + Out_Fee4 + Out_Lien4

    'End add ==============================




    Out_IntPaid = WrkTotIntPaid
    Out_FeePaid = WrkTotFeePaid
    Out_BondPaid = WrkTotBondPaid
    Out_Unposted = WrkUnposted
    Out_GracePeriod = WrkGracePeriod
    sbDebug.Append(vbCrLf & "HstIntDate " & HstIntDate)
    sbDebug.Append(vbCrLf & "Method " & myTXHSTL4._CORC)
    sbDebug.Append(vbCrLf & "Grace Period?: " & WrkGracePeriod)
    sbDebug.Append(vbCrLf & "Partial Int Pd: " & WrkIntPartialPaid)
    sbDebug.Append(vbCrLf & "Install No: " & WrkInstallNo)
    sbDebug.Append(vbCrLf & "Total Interest Left: " & WrkTotInt)
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

  Public Property In_IntDate() As Date
    Get
      In_IntDate = mvarIn_IntDate
    End Get
    Set(ByVal Value As Date)
      mvarIn_IntDate = Value
    End Set
  End Property
  Public Property Out_Int() As Decimal
    Get
      Out_Int = mvarOut_Int
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Int = Value
    End Set
  End Property
  Public Property Out_IntOrig() As Decimal
    Get
      Out_IntOrig = mvarOut_IntOrig
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_IntOrig = Value
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
  Public Property Out_IntPaid() As Decimal
    Get
      Out_IntPaid = mvarOut_IntPaid
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_IntPaid = Value
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
  Public Property Out_Unposted() As Boolean
    Get
      Out_Unposted = mvarOut_Unposted
    End Get
    Set(ByVal Value As Boolean)
      mvarOut_Unposted = Value
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
  Public Property Out_IntDate() As Date
    Get
      Out_IntDate = mvarOut_IntDate
    End Get
    Set(ByVal Value As Date)
      mvarOut_IntDate = Value
    End Set
  End Property
  Public Property Out_ProfMinInt() As Decimal
    Get
      Out_ProfMinInt = mvarOut_ProfMinInt
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_ProfMinInt = Value
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

  '---------------------------------------
  ' ken added  6/21/24
  '------------------------------------------
  Public Property Out_profDate1() As Date
    Get
      Out_profDate1 = mvarOut_ProfDate1
    End Get
    Set(ByVal Value As Date)
      mvarOut_ProfDate1 = Value
    End Set
  End Property
  Public Property Out_profDate2() As Date
    Get
      Out_profDate2 = mvarOut_ProfDate2
    End Get
    Set(ByVal Value As Date)
      mvarOut_ProfDate2 = Value
    End Set
  End Property
  Public Property Out_profDate3() As Date
    Get
      Out_profDate3 = mvarOut_ProfDate3
    End Get
    Set(ByVal Value As Date)
      mvarOut_ProfDate3 = Value
    End Set
  End Property
  Public Property Out_profDate4() As Date
    Get
      Out_profDate4 = mvarOut_ProfDate4
    End Get
    Set(ByVal Value As Date)
      mvarOut_ProfDate4 = Value
    End Set
  End Property
  Public Property Out_IntDate1() As Date
    Get
      Out_IntDate1 = mvarOut_IntDate1
    End Get
    Set(ByVal Value As Date)
      mvarOut_IntDate1 = Value
    End Set
  End Property
  Public Property Out_IntDate2() As Date
    Get
      Out_IntDate2 = mvarOut_IntDate2
    End Get
    Set(ByVal Value As Date)
      mvarOut_IntDate2 = Value
    End Set
  End Property
  Public Property Out_IntDate3() As Date
    Get
      Out_IntDate3 = mvarOut_IntDate3
    End Get
    Set(ByVal Value As Date)
      mvarOut_IntDate3 = Value
    End Set
  End Property
  Public Property Out_IntDate4() As Date
    Get
      Out_IntDate4 = mvarOut_IntDate4
    End Get
    Set(ByVal Value As Date)
      mvarOut_IntDate4 = Value
    End Set
  End Property
  Public Property Out_Int1() As Decimal
    Get
      Out_Int1 = mvarOut_Int1
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Int1 = Value
    End Set
  End Property
  Public Property Out_Int2() As Decimal
    Get
      Out_Int2 = mvarOut_Int2
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Int2 = Value
    End Set
  End Property
  Public Property Out_Int3() As Decimal
    Get
      Out_Int3 = mvarOut_Int3
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Int3 = Value
    End Set
  End Property
  Public Property Out_Int4() As Decimal
    Get
      Out_Int4 = mvarOut_Int4
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Int4 = Value
    End Set
  End Property
  Public Property Out_IntOrig1() As Decimal
    Get
      Out_IntOrig1 = mvarOut_IntOrig1
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_IntOrig1 = Value
    End Set
  End Property
  Public Property Out_IntOrig2() As Decimal
    Get
      Out_IntOrig2 = mvarOut_IntOrig2
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_IntOrig2 = Value
    End Set
  End Property
  Public Property Out_IntOrig3() As Decimal
    Get
      Out_IntOrig3 = mvarOut_IntOrig3
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_IntOrig3 = Value
    End Set
  End Property
  Public Property Out_IntOrig4() As Decimal
    Get
      Out_IntOrig4 = mvarOut_IntOrig4
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_IntOrig4 = Value
    End Set
  End Property
  Public Property Out_Prin1() As Decimal
    Get
      Out_Prin1 = mvarOut_Prin1
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Prin1 = Value
    End Set
  End Property
  Public Property Out_Prin2() As Decimal
    Get
      Out_Prin2 = mvarOut_Prin2
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Prin2 = Value
    End Set
  End Property
  Public Property Out_Prin3() As Decimal
    Get
      Out_Prin3 = mvarOut_Prin3
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Prin3 = Value
    End Set
  End Property
  Public Property Out_Prin4() As Decimal
    Get
      Out_Prin4 = mvarOut_Prin4
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Prin4 = Value
    End Set
  End Property
  Public Property Out_Lien1() As Decimal
    Get
      Out_Lien1 = mvarOut_Lien1
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Lien1 = Value
    End Set
  End Property
  Public Property Out_Lien2() As Decimal
    Get
      Out_Lien2 = mvarOut_Lien2
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Lien2 = Value
    End Set
  End Property
  Public Property Out_Lien3() As Decimal
    Get
      Out_Lien3 = mvarOut_Lien3
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Lien3 = Value
    End Set
  End Property
  Public Property Out_Lien4() As Decimal
    Get
      Out_Lien4 = mvarOut_Lien4
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Lien4 = Value
    End Set
  End Property
  Public Property Out_Fee1() As Decimal
    Get
      Out_Fee1 = mvarOut_Fee1
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Fee1 = Value
    End Set
  End Property
  Public Property Out_Fee2() As Decimal
    Get
      Out_Fee2 = mvarOut_Fee2
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Fee2 = Value
    End Set
  End Property
  Public Property Out_Fee3() As Decimal
    Get
      Out_Fee3 = mvarOut_Fee3
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Fee3 = Value
    End Set
  End Property
  Public Property Out_Fee4() As Decimal
    Get
      Out_Fee4 = mvarOut_Fee4
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Fee4 = Value
    End Set
  End Property
  Public Property Out_Due1() As Decimal
    Get
      Out_Due1 = mvarOut_Due1
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Due1 = Value
    End Set
  End Property
  Public Property Out_Due2() As Decimal
    Get
      Out_Due2 = mvarOut_Due2
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Due2 = Value
    End Set
  End Property
  Public Property Out_Due3() As Decimal
    Get
      Out_Due3 = mvarOut_Due3
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Due3 = Value
    End Set
  End Property
  Public Property Out_Due4() As Decimal
    Get
      Out_Due4 = mvarOut_Due4
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Due4 = Value
    End Set
  End Property
#End Region
End Class


