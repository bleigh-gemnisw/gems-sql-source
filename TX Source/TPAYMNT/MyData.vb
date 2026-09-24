Imports System.Text
Public Class MyData
#Region "Variables"
  'Set the Local variable and the Property
  Dim myTXPROF As TXPROF.MyData
  Dim mvarIn_ListNo As Integer
  Dim mvarIn_Year As Integer
  Dim mvarIn_Type As String
  Dim mvarIn_Phs As String
  Dim mvarIn_Dst As Integer
  Dim mvarIn_TaxT As Decimal
  Dim mvarIn_Tax1 As Decimal
  Dim mvarIn_NoSbil As Boolean
  Dim mvarOut_TaxT As Decimal
  Dim mvarOut_Tax1 As Decimal
  Dim mvarOut_Tax2 As Decimal
  Dim mvarOut_Tax3 As Decimal
  Dim mvarOut_Tax4 As Decimal
  Dim mvarOut_Waivered As Decimal
  Dim mvarOut_Debug As String

#End Region

  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
    myTXPROF = New TXPROF.MyData(MyDBConn)
  End Sub
#End Region


#Region "Subroutines"

  Public Sub CalcPaySplit()
    Dim WrkNegAmount As Boolean
    Dim sbDebug As New StringBuilder
    Dim WrkTaxDiv As Decimal
    Dim WrkTax As Decimal
    Dim WrkTaxDiff As Decimal
    Dim WrkDown As Boolean
    'TXPROF
    Dim ProfPrPerd As Integer
    Dim ProfPrpayc As String
    Dim ProfPrwav As Decimal
    Dim ProfPrsbil As Decimal

    If In_Phs = "0" Then
      In_Phs = ""
      sbDebug.Append("0 Phase changed to blanks")
    End If

    If In_Type <> myTXPROF._PRTYPE Or
   In_Year <> myTXPROF._PRYEAR Or
   In_Phs <> myTXPROF._PHS Or
   In_Dst <> myTXPROF._DIST Then
      myTXPROF.GetOneRecordP(In_Type, In_Year, In_Phs, In_Dst)
      If myTXPROF.RecordNotFound Then
        sbDebug.Append(vbCrLf & "Invalid profile: " & In_Type & "-" & In_Year & " " & In_Dst & "/" & In_Phs)
        'Use Default profile if Dist/Phase not found
        myTXPROF.GetOneRecordP(In_Type, In_Year, "", 0)
        If myTXPROF.RecordNotFound Then
          sbDebug.Append(vbCrLf & "Invalid profile (default): " & In_Type & "-" & In_Year)
          Out_Debug = sbDebug.ToString
          Exit Sub
        End If
      End If
    End If

    ProfPrPerd = myTXPROF._PRPERD
    ProfPrpayc = Trim(myTXPROF._PRPAYC)
    '  =Equal Payments drop difference   
    'AC=Actual/No rounding
    'DE=round down with equal payments
    'ED=Make UB EDU rate be the 1st payment and rest is 2nd payment
    'HU=Half round unequal payments (pennies up front)
    'UE=Round up with equal payments
    ProfPrwav = myTXPROF._PRWAV
    ProfPrsbil = myTXPROF._PRSBIL
    sbDebug.Append(vbCrLf & "Periods: " & ProfPrPerd)
    sbDebug.Append(vbCrLf & "Pay Calc: " & ProfPrpayc)
    sbDebug.Append(vbCrLf & "Waivered: " & ProfPrwav)
    sbDebug.Append(vbCrLf & "Min. Single Bill: " & ProfPrsbil)

    WrkDown = False
    If ProfPrpayc = "DE" Then
      WrkDown = True
    End If

    Out_TaxT = Round(In_TaxT, 2, WrkDown)
    Out_Tax1 = 0
    Out_Tax2 = 0
    Out_Tax3 = 0
    Out_Tax4 = 0
    Out_Waivered = 0

    WrkNegAmount = False
    If Out_TaxT < 0 Then
      Out_TaxT = Math.Abs(Out_TaxT)
      WrkNegAmount = True
    End If

    If Out_TaxT > 0 And Out_TaxT <= ProfPrwav Then
      Out_Waivered = Out_TaxT
      Out_TaxT = 0
      Out_Tax1 = 0
      Out_Tax2 = 0
      Out_Tax3 = 0
      Out_Tax4 = 0
      Out_Debug = sbDebug.ToString
      sbDebug = Nothing
      Exit Sub
    End If

    If ProfPrPerd = 1 Then
      Out_Tax1 = Out_TaxT
      Out_Tax2 = 0
      Out_Tax3 = 0
      Out_Tax4 = 0
      Out_Debug = sbDebug.ToString
      sbDebug = Nothing
      Exit Sub
    Else
      If Not In_NoSbil Then
        If In_TaxT <= ProfPrsbil Then
          Out_Tax1 = Out_TaxT
          Out_Tax2 = 0
          Out_Tax3 = 0
          Out_Tax4 = 0
          Out_Debug = sbDebug.ToString
          sbDebug = Nothing
          Exit Sub
        End If
      End If
    End If

      Select Case ProfPrpayc
      Case "", "DE"
        WrkTaxDiv = Round(Out_TaxT / ProfPrPerd, 2, WrkDown)
        Out_Tax1 = WrkTaxDiv
        If ProfPrPerd > 1 Then
          Out_Tax2 = WrkTaxDiv
        End If
        If ProfPrPerd > 2 Then
          Out_Tax3 = WrkTaxDiv
        End If
        If ProfPrPerd > 3 Then
          Out_Tax4 = WrkTaxDiv
        End If
      Case "AC"
        WrkTaxDiv = Round(Out_TaxT / ProfPrPerd, 2, WrkDown)
        Out_Tax1 = Round(WrkTaxDiv, 2, WrkDown)
        If ProfPrPerd = 2 Then
          Out_Tax2 = Out_TaxT - Out_Tax1
        End If
        If ProfPrPerd = 4 Then
          Out_Tax2 = Out_Tax1
          Out_Tax3 = Out_Tax1
          Out_Tax4 = Out_TaxT - Out_Tax1 - Out_Tax2 - Out_Tax3
        End If
      Case "ED"
        If In_TaxT > In_Tax1 And In_Tax1 > 0 Then
          Out_Tax1 = In_Tax1
          Out_Tax2 = In_TaxT - In_Tax1
        Else
          'If Taxt=Tax1 then use UE split
          WrkTaxDiv = Round(Out_TaxT / ProfPrPerd, 2, WrkDown)
          Out_Tax1 = WrkTaxDiv
          If ProfPrPerd > 1 Then
            Out_Tax2 = WrkTaxDiv
          End If
          If ProfPrPerd > 2 Then
            Out_Tax3 = WrkTaxDiv
          End If
          If ProfPrPerd > 3 Then
            Out_Tax4 = WrkTaxDiv
          End If
        End If
      Case "UE"
        WrkTaxDiv = Round(Out_TaxT / ProfPrPerd, 2, WrkDown)
        Out_Tax1 = WrkTaxDiv
        If ProfPrPerd > 1 Then
          Out_Tax2 = WrkTaxDiv
        End If
        If ProfPrPerd > 2 Then
          Out_Tax3 = WrkTaxDiv
        End If
        If ProfPrPerd > 3 Then
          Out_Tax4 = WrkTaxDiv
        End If
      Case Else
        WrkTaxDiv = Round(Out_TaxT / ProfPrPerd, 2, WrkDown)
        WrkTax = WrkTaxDiv * ProfPrPerd
        WrkTaxDiff = Out_TaxT - WrkTax
        Out_Tax1 = WrkTaxDiv + WrkTaxDiff
        If ProfPrPerd > 1 Then
          Out_Tax2 = WrkTaxDiv
        End If
        If ProfPrPerd > 2 Then
          Out_Tax3 = WrkTaxDiv
        End If
        If ProfPrPerd > 3 Then
          Out_Tax4 = WrkTaxDiv
        End If
    End Select

    If WrkNegAmount Then
      Out_Tax1 = Out_Tax1 * -1
      Out_Tax2 = Out_Tax2 * -1
      Out_Tax3 = Out_Tax3 * -1
      Out_Tax4 = Out_Tax4 * -1
    End If

    Out_TaxT = Out_Tax1 + Out_Tax2 + Out_Tax3 + Out_Tax4
    Out_Debug = sbDebug.ToString
    sbDebug = Nothing
  End Sub

#End Region

  Public Function GetDBDate(ByVal DateIn As Integer) As Date
    Dim WrkDate As Date
    Dim StrDate As String

    If DateIn > 0 Then
      StrDate = Trim$(Str(DateIn))
      WrkDate = Mid$(StrDate, 5, 2) & "/" & Right$(StrDate, 2) & "/" & Left$(StrDate, 4)
    End If
    Return WrkDate
  End Function

  Public Function GetDBDateMDY(ByVal DateIn As Integer) As Date
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

  Public Function SetDBDate(ByVal DateIn As Date) As Integer
    Dim WrkDate As Integer
    Dim StrDate As String

    StrDate = Year(DateIn) & Format(Month(DateIn), "00") &
    Format(DatePart(DateInterval.Day, DateIn), "00")
    WrkDate = Val(StrDate)
    Return WrkDate
  End Function
  Private Function Round(ByVal Number As Decimal, ByVal Decimals As Integer,
  ByVal Down As Boolean) As Decimal

    'Modifed to handle Down & Equal (DE)
    Dim WrkNo As Decimal
    Dim WrkInt As Long
    Dim WrkAdjust As Decimal

    If Down Then
      WrkAdjust = 0
    Else
      WrkAdjust = 0.5
    End If

    Select Case Decimals
      Case 0
        WrkNo = Math.Floor(Number + WrkAdjust)
      Case 1
        WrkNo = Number * 10
        WrkInt = Math.Floor(WrkNo + WrkAdjust)
        WrkNo = WrkInt / 10
      Case 2
        WrkNo = Number * 100
        WrkInt = Math.Floor(WrkNo + WrkAdjust)
        WrkNo = WrkInt / 100
      Case 3
        WrkNo = Number * 1000
        WrkInt = Math.Floor(WrkNo + WrkAdjust)
        WrkNo = WrkInt / 1000
      Case 4
        WrkNo = Number * 10000
        WrkInt = Math.Floor(WrkNo + WrkAdjust)
        WrkNo = WrkInt / 10000
    End Select

    Return WrkNo
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
  Public Property In_Phs() As String
    Get
      In_Phs = mvarIn_Phs
    End Get
    Set(ByVal Value As String)
      mvarIn_Phs = Value
    End Set
  End Property
  Public Property In_Dst() As Integer
    Get
      In_Dst = mvarIn_Dst
    End Get
    Set(ByVal Value As Integer)
      mvarIn_Dst = Value
    End Set
  End Property

  Public Property In_TaxT() As Decimal
    Get
      In_TaxT = mvarIn_TaxT
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_TaxT = Value
    End Set
  End Property
  Public Property In_Tax1() As Decimal
    Get
      In_Tax1 = mvarIn_Tax1
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_Tax1 = Value
    End Set
  End Property
  Public Property In_NoSbil() As Boolean
    Get
      In_NoSbil = mvarIn_NoSbil
    End Get
    Set(ByVal Value As Boolean)
      mvarIn_NoSbil = Value
    End Set
  End Property
  Public Property Out_TaxT() As Decimal
    Get
      Out_TaxT = mvarOut_TaxT
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_TaxT = Value
    End Set
  End Property

  Public Property Out_Tax1() As Decimal
    Get
      Out_Tax1 = mvarOut_Tax1
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Tax1 = Value
    End Set
  End Property

  Public Property Out_Tax2() As Decimal
    Get
      Out_Tax2 = mvarOut_Tax2
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Tax2 = Value
    End Set
  End Property

  Public Property Out_Tax3() As Decimal
    Get
      Out_Tax3 = mvarOut_Tax3
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Tax3 = Value
    End Set
  End Property

  Public Property Out_Tax4() As Decimal
    Get
      Out_Tax4 = mvarOut_Tax4
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Tax4 = Value
    End Set
  End Property
  Public Property Out_Waivered() As Decimal
    Get
      Out_Waivered = mvarOut_Waivered
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_Waivered = Value
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

