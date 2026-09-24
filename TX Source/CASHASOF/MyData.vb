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
  Dim myTPAYMNT As TPAYMNT.MyData
  Dim myTXMVFEE As TXMVFEE.MyData

  Dim mvarIn_ListNo As Integer
  Dim mvarIn_Year As Integer
  Dim mvarIn_Type As String
  Dim mvarIn_AsofDate As Date
  Dim mvarOut_Int As Decimal
  Dim mvarOut_Lien As Decimal
  Dim mvarOut_Fee As Decimal
  Dim mvarOut_CAFee As Decimal
  Dim mvarOut_Prin As Decimal
  Dim mvarOut_Billed As Decimal
  Dim mvarOut_Tot As Decimal
  Dim mvarOut_Bond As Decimal
  Dim mvarOut_PrinPaid As Decimal
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

#End Region

#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
    myTPAYMNT = New TPAYMNT.MyData(MyDBConn)
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

  Public Sub CalcAsof()
    Dim Found As Boolean
    Dim FoundCC As Boolean
    Dim ChkDate As Date
    Dim WrkDate As Integer
    Dim WrkTotInt As Decimal
    Dim WrkLienAmt As Decimal
    Dim WrkAdj(3) As Decimal
    'MK 9/4/25 Begin
    Dim WrkOrigTax(3) As Decimal
    'MK 9/4/25 End
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
    Dim WrkIntCollect(3) As Boolean
    Dim WrkTotIntPaid As Decimal
    Dim WrkIntPartialPaid As Decimal
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
    'MK 9/3/25 Begin
    Dim InvCCInt30 As Date
    'MK 9/3/25 Begin
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
    Dim InvCCDate As Date
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
    'Calculated fields
    Dim CCNo As Integer
    Dim CCTx As Decimal
    Dim CCTx1 As Decimal
    Dim CCTx2 As Decimal
    Dim CCTx3 As Decimal
    Dim CCTx4 As Decimal
    Dim CCDate As Date

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

    CCNo = 0
    sbDebug = New StringBuilder
    Out_Int = 0
    Out_Lien = 0
    Out_Fee = 0
    Out_CAFee = 0
    Out_Prin = 0
    Out_Billed = 0
    Out_Tot = 0
    Out_Bond = 0
    Out_BondPaid = 0
    Out_FeePaid = 0
    Out_GracePeriod = False
    Out_Method = ""
    'Strip off time from date/time 
    In_AsofDate = In_AsofDate.ToShortDateString
    sbDebug.Append(In_ListNo & "-" & In_Type & "-" & In_Year)

    myTXINV.GetOneRecordP(In_ListNo, In_Year, In_Type)
    If myTXINV.RecordNotFound Then
      Out_Debug = "Invalid Invoice Record"
      Exit Sub
    End If
    With myTXINV
      If ._PHASE = "0" Then
        InvPhs = ""
      Else
        InvPhs = ._PHASE
      End If
      InvDist = ._DIST
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
        InvDist = ._PDST
        sbDebug.Append(vbCrLf & "Use Print District")
      End If
      FoundCC = False
      CCTx1 = 0
      CCTx2 = 0
      CCTx3 = 0
      CCTx4 = 0
      If ._CCNO > 0 Then
        If myTXTYPE._TXFAM = "U" Or myTXTYPE._TXFAM = "A" Then
          GetPrevCCUB(FoundCC, CCNo, CCTx, CCTx1, CCTx2, CCTx3, CCTx4, CCDate)
        Else
          GetPrevCC(FoundCC, CCNo, CCTx, CCDate)
        End If
        If FoundCC Then
          With myTPAYMNT
            .In_ListNo = In_ListNo
            .In_Year = In_Year
            .In_Type = In_Type
            .In_Dst = 0
            .In_Phs = ""
            .In_TaxT = CCTx
            .CalcPaySplit()
            CCTx1 = .Out_Tax1
            CCTx2 = .Out_Tax2
            CCTx3 = .Out_Tax3
            CCTx4 = .Out_Tax4
          End With
        Else
          If ._CDATE <= SetDBDate(In_AsofDate) Then
            FoundCC = True
            CCNo = ._CCNO
            CCTx = ._CCETAX
            CCTx1 = ._CCTX1
            CCTx2 = ._CCTX2
            CCTx3 = ._CCTX3
            CCTx4 = ._CCTX4
            CCDate = GetDBDate(myTXINV._CDATE)
            'MK 9/4/25 Begin    
            If myTXINV._CCINT30 > 0 Then
              InvCCInt30 = GetDBDate(myTXINV._CCINT30)
            End If
            'MK 9/4/25 End    
          End If
        End If
      End If
      InvTaxT = ._TAXT
      InvTax1 = ._TAX1
      InvTax2 = ._TAX2
      InvTax3 = ._TX3RD
      InvTax4 = ._TX4TH
      If InvTax1 = 0 And InvTax2 = 0 And InvTax3 = 0 And InvTax4 = 0 And InvTaxT > 0 Then
        InvTax1 = InvTaxT
      End If
      If myTXINV._ICODE = "D" Then
        InvDeferT = myTXINV._DEFERT
        InvDefer1 = myTXINV._DEFER1
        InvDefer2 = myTXINV._DEFER2
        InvDefer3 = myTXINV._DEFER3
        InvDefer4 = myTXINV._DEFER4
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
      WrkFees = WrkFees + myTXINV._FED1 + myTXINV._FED2 + myTXINV._FED3 + myTXINV._FED4 + myTXINV._FED5
      InvLien = ._LIEN
      InvBond = ._BOND
      InvBondPaid = ._BONDP
      InvBondTemp = ._BONT
      InvProrateDt = GetDBDate(._PDAT)
      InvCCDate = GetDBDate(myTXINV._CDATE)
    End With

    sbDebug.Append(vbCrLf & "Dist: " & InvDist & ", Phase: " & InvPhs)

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
    'MK 9/4/25 Begin	
    WrkOrigTax(0) = InvTax1
    WrkOrigTax(1) = InvTax2
    WrkOrigTax(2) = InvTax3
    WrkOrigTax(3) = InvTax4
    'MK 9/4/25 End
    If Not FoundCC Then
      sbDebug.Append(vbCrLf & "Tax")
      If myTXINV._ICODE = "D" Then
        'MK 10/2/25 Begin
        WrkAdj(0) = InvTax1 - InvDefer1
        WrkAdj(1) = InvTax2 - InvDefer2
        WrkAdj(2) = InvTax3 - InvDefer3
        WrkAdj(3) = InvTax4 - InvDefer4
        'MK 10/2/25 End
      Else
        WrkAdj(0) = InvTax1
        WrkAdj(1) = InvTax2
        WrkAdj(2) = InvTax3
        WrkAdj(3) = InvTax4
      End If
    Else
        sbDebug.Append(vbCrLf & "C/C: " & CCNo & "  Date:" & CCDate & " Amt:" & CCTx)
      If InvTaxT = 0 Then
        WrkCCAdd = True
      End If
      'MK 10/2/25 Begin
      If myTXINV._ICODE = "E" Then
        WrkAdj(0) = CCTx1 + InvDefer1
        WrkAdj(1) = CCTx2 + InvDefer2
        WrkAdj(2) = CCTx3 + InvDefer3
        WrkAdj(3) = CCTx4 + InvDefer4
      Else
        'MK 10/2/25 End
        WrkAdj(0) = CCTx1
        WrkAdj(1) = CCTx2
        WrkAdj(2) = CCTx3
        WrkAdj(3) = CCTx4
      End If

      If InvDeferT > 0 Then
        WrkAdj(0) = InvDefer1
        WrkAdj(1) = InvDefer2
        WrkAdj(2) = InvDefer3
        WrkAdj(3) = InvDefer4
      End If
    End If

    If myTXTYPE._TXFAM = "A" Then
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
    If In_AsofDate < ProfTxDt(0) Then
      sbDebug.Append(vbCrLf & "Before Bill Date(0): " & ProfTxDt(0))
      WrkAdj(0) = 0
    End If
    If In_AsofDate < ProfTxDt(1) Then
      sbDebug.Append(vbCrLf & "Before Bill Date(1): " & ProfTxDt(1))
      WrkAdj(1) = 0
    End If
    If In_AsofDate < ProfTxDt(2) Then
      sbDebug.Append(vbCrLf & "Before Bill Date(2): " & ProfTxDt(2))
      WrkAdj(2) = 0
    End If
    If In_AsofDate < ProfTxDt(3) Then
      sbDebug.Append(vbCrLf & "Before Bill Date(3): " & ProfTxDt(3))
      WrkAdj(3) = 0
    End If

    If Trim$(InvLien) = "L" Then
      WrkLienAmt = ProfPrLien
    End If
    X = -1

    WrkAdjFnd = False
    WrkDate = 0
    WrkTotRec = 0
    myTXHSTL4.SetRange(In_ListNo, In_Year, In_Type, WrkDate, False)
ReadHist:
    myTXHSTL4.ReadFileE()
    If Not myTXHSTL4.IsEOF Then
      HstRcode = myTXHSTL4._RCODE
      If HstRcode = "I" Then GoTo NextHist
      If HstRcode = "V" Then GoTo NextHist
      If In_AsofDate < GetDBDate(myTXHSTL4._PDATE) Then
        GoTo NextHist
      End If
      HstAdjcd = myTXHSTL4._ADJCD
      HstPamt = myTXHSTL4._PAMT
      HstIamt = myTXHSTL4._IAMT
      HstPCamt = myTXHSTL4._PCAMT
      HstPencd = myTXHSTL4._PENCD
      HstLamt = myTXHSTL4._LAMT
      WrkTotRec = WrkTotRec + HstPamt
      If myTXHSTL4._PENCD = "BI" Then
        WrkTotBondRec = WrkTotBondRec + myTXHSTL4._PCAMT
      End If
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
        If HstIamt > 0 Then
          If HstIntDate > ProfTxGd(0) And Not WrkIntCollect(0) Then
            WrkIntCollect(0) = True
          End If
          If ProfPrPerd > 1 And HstIntDate > ProfTxGd(1) And Not WrkIntCollect(1) Then
            WrkIntCollect(1) = True
          End If
          If ProfPrPerd > 2 And HstIntDate > ProfTxGd(2) And Not WrkIntCollect(2) Then
            WrkIntCollect(2) = True
          End If
          If ProfPrPerd > 3 And HstIntDate > ProfTxGd(3) And Not WrkIntCollect(3) Then
            WrkIntCollect(3) = True
          End If
        End If
        If HstPamt > 0 Then
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
        Else
          WrkTotIntPaid = WrkTotIntPaid + HstIamt
        End If
        WrkLienPaid = WrkLienPaid + HstLamt
        WrkAdjFnd = True
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
        If In_AsofDate < GetDBDate(myTXHSTL4._PDATE) Then
          GoTo NextHistAdj
        End If
        HstAdjcd = myTXHSTL4._ADJCD
        HstPamt = myTXHSTL4._PAMT
        HstIamt = myTXHSTL4._IAMT
        'Adjustment/Refund is not last principal entry
        If HstAdjcd <> "A" And HstAdjcd <> "R" And HstPamt > 0 And Not WrkAdjFnd Then
          GoTo NextPerd
        End If
        WrkAdjFnd = True
        WrkIntDate(0) = ChkDate
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
          sbDebug.Append(vbCrLf & "Int (Adjust) Date " & HstIntDate)
          WrkIntDate(0) = HstIntDate
          GoTo NextPerd
        End If
NextHistAdj:
        GoTo ReadHist2
      End If
    End If

NextPerd:
    If X >= (ProfPrPerd - 1) Then GoTo IntDone

    X += 1
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

    FoundCC = False
    If WrkCCAdd Then
      sbDebug.Append("GNET/CCADD: " & myCCAddDate & vbCrLf)
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

    If myTXTYPE._TXFAM = "A" Then
      If WrkTotBondRec >= WrkBond(X) Then
        WrkBondPaid(X) = WrkBond(X)
        WrkTotBondRec = WrkTotBondRec - WrkBond(X)
      Else
        WrkBondPaid(X) = WrkTotBondRec
        WrkTotBondRec = 0
      End If
    End If

    If WrkAdj(X) - WrkPaid(X) < 0 Then GoTo IntDone
    WrkMonths = 0
    If WrkPrinPd(X) And WrkIntDate(X) > ProfTxGd(X) Then
      WrkMonths = DateDiff(DateInterval.Month, WrkIntDate(X), In_AsofDate)
    Else
      WrkMonths = DateDiff(DateInterval.Month, WrkIntDate(X), In_AsofDate) + 1
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

    'CALC INTEREST FOR # OF MONTHS UNPAID INTEREST
    If WrkPaid(X) > 0 Then
      WrkLeft = WrkAdj(X) - WrkPaid(X)
    Else
      WrkLeft = WrkAdj(X)
    End If
    'MK 9/4/25 Begin
    If InvCCInt30 <> ChkDate And CCTx > InvTaxT Then
      WrkCCDt = DateAdd(DateInterval.Month, 1, InvCCInt30)
      sbDebug.Append(vbCrLf & "CCInt30 " & InvCCInt30)
      If In_AsofDate <= WrkCCDt Then
        If WrkPaid(X) > 0 Then
          WrkLeft = WrkOrigTax(X) - WrkPaid(X)
        Else
          WrkLeft = WrkOrigTax(X)
        End If
      End If
    End If
    'MK 9/4/25 End
    If myTXTYPE._TXFAM = "A" And MyIntBond Then
      If WrkLeft > 0 Then
        WrkLeft = WrkAdj(X) + WrkBond(X) - WrkPaid(X) - WrkBondPaid(X)
      End If
    End If
    WrkInt(X) = WrkTPerc * WrkLeft

    'MK 9/4/25 Begin							 
    'If WrkInt(X) > 0 Then 'Replaced by line below
    If WrkTPerc * WrkLeft > 0 Then 'Handle even fractions of a cent
      'MK 9/4/25 End
      'Check to see if less than minimum interest amount 
      If WrkInt(X) < ProfPrmini Then
        'If no previous interest paid then charge Minimum interest   
        If Not WrkIntCollect(X) Then
          sbDebug.Append(vbCrLf & "Min Interest")
          WrkInt(X) = ProfPrmini
        End If
        'If previous interest paid but less than Minimum interest then charge difference  
        If WrkIntCollect(X) And WrkTotIntPaid < ProfPrmini Then
          sbDebug.Append(vbCrLf & " Min Interest left: " & Round(WrkInt(X), 2))
          WrkInt(X) = ProfPrmini
        End If
      End If
    End If

    WrkInt(X) = Round(WrkInt(X), 2)
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
      If In_AsofDate <= WrkCCDt Then
        If myTXTYPE._TXFAM = "P" Then
          WrkHighListNo = myTXINVLP.AutoGenKey(In_Year + 1, In_Type)
          If WrkHighListNo > 1 Then
            sbDebug.Append(vbCrLf & "PP-C/C Add 1st Month Previous Year")
          Else
            WrkInt(X) = 0
            sbDebug.Append(vbCrLf & "PP-C/C Add 1st Month Current Year (no interest)")
          End If
        Else
          WrkInt(X) = 0
          sbDebug.Append(vbCrLf & "C/C Add 1st Month (no interest)")
        End If
      End If
    End If
    GoTo NextPerd

IntDone:
    'No interest due if before Grace Date
    If In_AsofDate <= ProfTxGd(0) Then
      WrkInt(0) = 0
      WrkGracePeriod = True
      sbDebug.Append(vbCrLf & "Before Grace Date 1 (no int)")
    End If
    If In_AsofDate <= ProfTxGd(1) Then
      If WrkInt(1) > 0 And WrkInt(0) = 0 Then WrkGracePeriod = True
      WrkInt(1) = 0
      sbDebug.Append(vbCrLf & "Before Grace Date 2 (no int)")
    End If
    If In_AsofDate <= ProfTxGd(2) Then
      If WrkInt(2) > 0 And WrkInt(1) = 0 Then WrkGracePeriod = True
      WrkInt(2) = 0
      sbDebug.Append(vbCrLf & "Before Grace Date 3 (no int)")
    End If
    If In_AsofDate <= ProfTxGd(3) Then
      If WrkInt(3) > 0 And WrkInt(2) = 0 Then WrkGracePeriod = True
      WrkInt(3) = 0
      sbDebug.Append(vbCrLf & "Before Grace Date 4 (no int)")
    End If
    'No interest due during 1st month of pro rate
    If In_Type = "X" Then
      WrkProrateDt = DateAdd(DateInterval.Month, 1, InvProrateDt)
      If In_AsofDate <= WrkProrateDt Then
        WrkInt(0) = 0
        sbDebug.Append(vbCrLf & "Prorate 1st Month (no interest)")
      End If
    End If
    If WrkLienPaid > 0 Then
      sbDebug.Append(vbCrLf & "Lien Paid: " & WrkLienPaid)
    End If

    Out_Prin = WrkAdj(0) + WrkAdj(1) + WrkAdj(2) + WrkAdj(3)
    Out_Prin = Round(Out_Prin - WrkPaid(0) - WrkPaid(1) - WrkPaid(2) - WrkPaid(3) - WrkTotRec, 2)
    If CCNo > 0 Then
      Out_Billed = CCTx
    Else
      Out_Billed = InvTaxT
    End If
    sbDebug.Append(vbCrLf & "Billed: " & Out_Billed)
    WrkTotInt = WrkInt(0) + WrkInt(1) + WrkInt(2) + WrkInt(3)
    sbDebug.Append(vbCrLf & "Total Interest: " & Round(WrkTotInt, 2))
    If WrkAdj(WrkInstallNo) - WrkPaid(WrkInstallNo) > 0 Then
      WrkTotInt = WrkTotInt - WrkIntPartialPaid
    End If
    If WrkTotInt < 0 Then
      WrkTotInt = 0
    End If
    Out_Int = Round(WrkTotInt, 2)
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
    Out_PrinPaid = WrkPaid(0) + WrkPaid(1) + WrkPaid(2) + WrkPaid(3) + WrkTotRec
    Out_IntPaid = WrkTotIntPaid
    Out_GracePeriod = WrkGracePeriod
    sbDebug.Append(vbCrLf & "Grace Period?: " & WrkGracePeriod)
    sbDebug.Append(vbCrLf & "Principal Paid: " & Out_PrinPaid)
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
  Private Function Round(ByVal Number As Decimal, ByVal Decimals As Integer) As Decimal
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
  Public Sub GetPrevCC(ByRef Found As Boolean, ByRef Out_CCNo As Integer, ByRef Out_Due As Decimal,
    ByRef Out_CCDate As Date)
    Dim WrkDBDate As Integer

    Out_CCNo = 0
    Out_Due = 0
    Found = False
    WrkDBDate = SetDBDate(In_AsofDate)
    myTXCOEA.SetRange(In_ListNo, In_Year, In_Type, WrkDBDate, 999999, True)
    If Not myTXCOEA.IsEOF Then
      With myTXCOEA
        .ReadFilePE()
        If Not myTXCOEA.IsEOF Then
          Found = True
          Out_CCNo = ._CCNO
          Out_Due = ._CETAX
          Out_CCDate = GetDBDate(._CDATE)
        End If
      End With
    End If
  End Sub
  Public Sub GetPrevCCUB(ByRef Found As Boolean, ByRef Out_CCNo As Integer, ByRef Out_Due As Decimal,
    ByRef Out_Due1 As Decimal, ByRef Out_Due2 As Decimal, ByRef Out_Due3 As Decimal,
    ByRef Out_Due4 As Decimal, ByRef Out_CCDate As Date)
    Dim WrkDBDate As Integer

    Out_CCNo = 0
    Out_Due = 0
    Out_Due1 = 0
    Out_Due2 = 0
    Out_Due3 = 0
    Out_Due4 = 0
    Found = False
    WrkDBDate = SetDBDate(In_AsofDate)
    myUTCOEA.SetRange(In_ListNo, In_Year, In_Type, WrkDBDate, 999999, True)
    If Not myUTCOEA.IsEOF Then
      With myUTCOEA
        .ReadFilePE()
        If Not myUTCOEA.IsEOF Then
          Found = True
          Out_CCNo = ._CCNO
          Out_Due = ._CETAX
          Out_Due1 = ._CETAX1
          Out_Due2 = ._CETAX2
          Out_Due3 = ._CETAX3
          Out_Due4 = ._CETAX4
          Out_CCDate = GetDBDate(._CDATE)
        End If
      End With
    End If
  End Sub
  Public Sub GetOrigCCDate(ByRef Found As Boolean, ByRef Out_CCDate As Date)
    Dim dsTXCOEAL1 As DataSet = New DataSet

    Found = False
    dsTXCOEAL1 = myTXCOEA.GetViewbyList(In_ListNo, In_Year, In_Type, 1)
    If dsTXCOEAL1.Tables(0).Rows.Count > 0 Then
      With dsTXCOEAL1.Tables(0).Rows(0)
        Found = True
        Out_CCDate = GetDBDate(.Item("cdate"))
      End With
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

  Public Property In_AsofDate() As Date
    Get
      In_AsofDate = mvarIn_AsofDate
    End Get
    Set(ByVal Value As Date)
      mvarIn_AsofDate = Value
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
  Public Property Out_Billed() As Decimal
    Get
      Out_Billed = mvarOut_Billed
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Billed = Value
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
  Public Property Out_PrinPaid() As Decimal
    Get
      Out_PrinPaid = mvarOut_PrinPaid
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_PrinPaid = Value
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

