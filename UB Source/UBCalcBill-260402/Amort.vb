Imports System.text
Public Class Amort

#Region "Variables"
  'Set the Local variable and the Property
  Dim MyDBConn As SQLConnect.DBConnection
  Dim myUTRATEAS As UTRATEAS.MyData
  Dim myUTCNTL As UTCNTL.myData
  Dim mvarIn_RateType As String
  Dim mvarIn_RateCode As String
  Dim mvarIn_OrigBill As Decimal
  Dim mvarIn_AmtLeft As Decimal
  Dim mvarIn_Balance As Decimal
  Dim mvarIn_NumBills As Integer
  Dim mvarIn_PctDeferred As Integer
  Dim mvarIn_OverrideBill As Decimal
  Dim mvarOut_Bill As Decimal
  Dim mvarOut_BillDeferred As Decimal
  Dim mvarOut_Bond As Decimal
  Dim mvarOut_BondSchedule As Decimal
  Dim mvarOut_BillsLeft As Integer
  Dim mvarOut_Debug As String
#End Region

#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
    myUTRATEAS = New UTRATEAS.MyData(MyDBConn)
    myUTCNTL = New UTCNTL.MyData(MyDBConn)
  End Sub

#End Region


#Region "Subroutines"

  Public Sub CalcAmort()
		Dim SbDebug As New StringBuilder
    Dim WrkAsmtLeft As Decimal
    Dim WrkNumLeft As Integer
    Dim WrkNumTotalBills As Integer
    Dim WrkProratePct As Decimal
    Dim WrkBond As Decimal
    Dim WrkBondPct As Decimal
    Dim WrkM1 As Decimal
    Dim WrkM2 As Decimal
    Dim I As Integer
    Dim WrkAmortCalc As String

    WrkAmortCalc = ""
    'Control File
    myUTCNTL.GetOneRecordP(1)
    If Not myUTCNTL.RecordNotFound Then
      With myUTCNTL
        WrkAmortCalc = ._UASDV
      End With
    End If

    Out_Bill = 0
    Out_BillDeferred = 0
    Out_Bond = 0
    Out_BondSchedule = 0
    If In_AmtLeft < 0 Then
      SbDebug.Append("Negative Assessment Left " & In_AmtLeft & vbCrLf)
      Exit Sub
    End If

    myUTRATEAS.GetOneRecordP(In_RateType, In_RateCode)
    If myUTRATEAS.RecordNotFound Then Exit Sub
    With myUTRATEAS
      If Trim(._RAMORT) <> "" Then
        WrkAmortCalc = ._RAMORT
      End If
      SbDebug.Append("Amortization Type " & WrkAmortCalc & vbCrLf)
      WrkProratePct = ._RAMNTH / 12
      SbDebug.Append("Prorate Pct " & WrkProratePct & vbCrLf)
      If ._RABOND = 0 Then
        SbDebug.Append("Annual Bond Pct " & ._RAPCT & vbCrLf)
        WrkBondPct = ._RAPCT * WrkProratePct
        SbDebug.Append("Actual Bond Pct " & WrkBondPct & vbCrLf)
      Else
        SbDebug.Append("Fixed Bond Amount " & ._RABOND & vbCrLf)
      End If
      WrkNumTotalBills = 0
      If WrkProratePct > 0 Then
        WrkNumTotalBills = Round(._RANOYR * (1 / WrkProratePct), 0)
      End If
      SbDebug.Append("Num Total Bills " & WrkNumTotalBills & vbCrLf)
      Out_BillsLeft = WrkNumTotalBills - In_NumBills
      SbDebug.Append("Bills Left " & Out_BillsLeft & vbCrLf)

      Select Case WrkAmortCalc
      Case "S", "N" 'Simple Amort, No Delq Bond Interest
        If WrkNumTotalBills > 0 Then
          Out_Bill = In_OrigBill / WrkNumTotalBills
        End If
      Case "R" 'REDIVIDE BY NUMBER OF BILLS LEFT 
        If In_Balance < 0 Then
          WrkAsmtLeft = In_AmtLeft + In_Balance
        Else
          WrkAsmtLeft = In_AmtLeft
        End If
          WrkNumLeft = WrkNumTotalBills - In_NumBills
          If WrkNumLeft > 0 Then
            Out_Bill = Round(WrkAsmtLeft / WrkNumLeft, 2)
          End If
      Case "P" 'Equal Payments
        WrkM1 = WrkBondPct + 1
        WrkM2 = WrkM1
        If WrkNumTotalBills > 1 Then
          For I = 1 To WrkNumTotalBills - 1
            WrkM2 = WrkM2 * WrkM1
            SbDebug.Append("WrkM2 " & I & " " & WrkM2 & vbCrLf)
          Next
        End If
        If WrkM2 > 0 Then
          WrkM2 = 1 / WrkM2
        End If
        WrkM2 = 1 - WrkM2
        If WrkM2 <> 0 Then
          WrkM2 = WrkBondPct / WrkM2
        Else
          WrkM2 = 0
        End If
        SbDebug.Append("WrkM2 Done " & WrkM2 & vbCrLf)
        Out_Bill = Round(In_OrigBill * WrkM2, 2)
      End Select

      If In_NumBills >= 0 Then
        Out_Bond = Round((In_AmtLeft + In_Balance) * WrkBondPct, 2)
        Out_BondSchedule = Round(In_AmtLeft * WrkBondPct, 2)
      End If
      If WrkAmortCalc = "N" And In_AmtLeft > 0 Then
        If ._RABOND = 0 Then
          Out_Bond = Out_BondSchedule
        Else
          Out_Bond = ._RABOND
        End If
      End If
      If WrkAmortCalc = "S" Then
        If ._RABOND > 0 Then
          If In_Balance > 0 Then
            Out_Bond = ._RABOND + Round(In_Balance * WrkBondPct, 2)
          Else
            Out_Bond = ._RABOND
          End If
          Out_BondSchedule = ._RABOND
        End If
      End If
      If WrkAmortCalc = "P" Then
        Out_Bond = Round((In_AmtLeft + In_Balance) * WrkBondPct, 2)
        Out_BondSchedule = Round(In_AmtLeft * WrkBondPct, 2)
        WrkBond = Round(In_AmtLeft * WrkBondPct, 2)
        If In_Balance >= 0 Then
          Out_Bill = Out_Bill - WrkBond
        Else
          Out_Bill = Out_Bill - Out_Bond
        End If
      End If
      If In_PctDeferred > 0 Then
        Out_BillDeferred = Out_Bill * (In_PctDeferred / 100)
        Out_Bill = Out_Bill - Out_BillDeferred
      End If
      'OVERRIDE BILL AMT                                                                                       03/12/03
      If In_OverrideBill > 0 And In_AmtLeft > 0 Then
        If WrkAmortCalc = "P" Then
          If ._RAYR1 <> "Y" And In_NumBills = 0 Then
            Out_Bill = In_OverrideBill
          Else
            'If In_Balance >= 0 Then
            '  Out_Bill = In_OverrideBill - WrkBond
            'Else
              Out_Bill = In_OverrideBill - Out_Bond
            'End If
          End If
        Else
          Out_Bill = In_OverrideBill
        End If
        SbDebug.Append("Override Bill " & Out_Bill & vbCrLf)
      End If
      'If Amount left is less than Bill amount then use it
      If In_AmtLeft < Out_Bill Then
        Out_Bill = In_AmtLeft
        SbDebug.Append("Remaining Amount Left " & In_AmtLeft & vbCrLf)
      End If
      'If no years left or less than 0 then make it 0
      If Out_BillsLeft = 0 Or Out_Bill < 0 Then
        Out_Bill = 0
      End If
      'Last Bill                                                                                      03/12/03
      If Out_BillsLeft = 1 Then
        Out_Bill = In_AmtLeft
        SbDebug.Append("Last Bill " & Out_Bill & vbCrLf)
      End If
      '1st Year Bond?
      If ._RAYR1 <> "Y" And In_NumBills = 0 Then
        Out_Bond = 0
        Out_BondSchedule = 0
        SbDebug.Append("No Bond 1st Year" & vbCrLf)
      End If
    End With

    Out_Bill = Round(Out_Bill, 2)
    Out_Bond = Round(Out_Bond, 2)
    Out_BondSchedule = Round(Out_BondSchedule, 2)
    Out_Debug = SbDebug.ToString
  End Sub

#End Region

#Region "Properties"

  Public Property In_RateType() As String
    Get
      In_RateType = mvarIn_RateType
    End Get
    Set(ByVal Value As String)
      mvarIn_RateType = Value
    End Set
  End Property
  Public Property In_RateCode() As String
    Get
      In_RateCode = mvarIn_RateCode
    End Get
    Set(ByVal Value As String)
      mvarIn_RateCode = Value
    End Set
  End Property
  Public Property In_OrigBill() As Decimal
    Get
      In_OrigBill = mvarIn_OrigBill
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_OrigBill = Value
    End Set
  End Property
  Public Property In_AmtLeft() As Decimal
    Get
      In_AmtLeft = mvarIn_AmtLeft
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_AmtLeft = Value
    End Set
  End Property
  Public Property In_Balance() As Decimal
    Get
      In_Balance = mvarIn_Balance
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_Balance = Value
    End Set
  End Property
  Public Property In_NumBills() As Integer
    Get
      In_NumBills = mvarIn_NumBills
    End Get
    Set(ByVal Value As Integer)
      mvarIn_NumBills = Value
    End Set
  End Property
  Public Property In_PctDeferred() As Integer
    Get
      In_PctDeferred = mvarIn_PctDeferred
    End Get
    Set(ByVal Value As Integer)
      mvarIn_PctDeferred = Value
    End Set
  End Property
  Public Property In_OverrideBill() As Decimal
    Get
      In_OverrideBill = mvarIn_OverrideBill
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_OverrideBill = Value
    End Set
  End Property
  Public Property Out_Bill() As Decimal
    Get
      Out_Bill = mvarOut_Bill
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Bill = Value
    End Set
  End Property
  Public Property Out_BillDeferred() As Decimal
    Get
      Out_BillDeferred = mvarOut_BillDeferred
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_BillDeferred = Value
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
  Public Property Out_BondSchedule() As Decimal
    Get
      Out_BondSchedule = mvarOut_BondSchedule
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_BondSchedule = Value
    End Set
  End Property
  Public Property Out_BillsLeft() As Integer
    Get
      Out_BillsLeft = mvarOut_BillsLeft
    End Get
    Set(ByVal Value As Integer)
      mvarOut_BillsLeft = Value
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
