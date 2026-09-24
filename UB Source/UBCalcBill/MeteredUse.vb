Imports System.Text
Public Class MeteredUse
#Region "Variables"
  'Set the Local variable and the Property
  Dim MyDBConn As SQLConnect.DBConnection
  Dim myUTMETER As UTMETER.MyData
  Dim mvarIn_RateType As String
  Dim mvarIn_MeterSize As String
  Dim mvarIn_MeterReadCurr As Integer
  Dim mvarIn_MeterReadPrev As Integer
  Dim mvarIn_MeterRead2 As Integer
  Dim mvarIn_MeterRead3 As Integer
  Dim mvarIn_MeterRead4 As Integer
  Dim mvarIn_Units As Decimal
  Dim mvarIn_EDUs As Decimal
  Dim mvarOut_TotalUse As Integer
  Dim mvarOut_ActualUse As Integer
  Dim mvarOut_MinBill As Decimal
  Dim mvarOut_UseMinCharge As Boolean
  Dim mvarOut_UnitCharge As Decimal
  Dim mvarOut_UnitCalc As String
  Dim mvarOut_EDUCharge As Decimal
  Dim mvarOut_EDUCalc As String
  Dim mvarOut_User1Charge As Decimal
  Dim mvarOut_User2Charge As Decimal
  Dim mvarOut_User3Charge As Decimal
  Dim mvarOut_MarkupPct As Decimal
  Dim mvarOut_Debug As String
#End Region

#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
    myUTMETER = New UTMETER.MyData(MyDBConn)
  End Sub

#End Region


#Region "Subroutines"

  Public Sub CalcMeteredUse()
    Dim WrkMeterCode As String
    Dim WrkQtr As Integer
    Dim Usage(3) As Integer
    Dim SbDebug As New StringBuilder

    Out_TotalUse = 0
    Out_ActualUse = 0
    Out_MinBill = 0
    Out_UseMinCharge = False
    Out_UnitCharge = 0
    Out_EDUCharge = 0
    Out_MarkupPct = 0

    SbDebug.Append("Meter Size " & In_MeterSize & vbCrLf)
    If In_MeterSize = "" Then
      Out_TotalUse = In_MeterReadCurr - In_MeterReadPrev
      Out_ActualUse = Out_TotalUse
      Out_Debug = SbDebug.ToString
      Exit Sub
    End If

    myUTMETER.GetOneRecordP(In_RateType, In_MeterSize)
    If myUTMETER.RecordNotFound Then
      SbDebug.Append("Meter Size not found" & vbCrLf)
      Out_Debug = SbDebug.ToString
      Exit Sub
    End If

    With myUTMETER
      Out_TotalUse = In_MeterReadCurr
      Out_ActualUse = Out_TotalUse
      SbDebug.Append("Meter Bill Code " & Trim(._MTBLCD) & vbCrLf)
      WrkMeterCode = Trim(._MTBLCD)
      Select Case WrkMeterCode
        Case "C" 'CURRENT QTR * 3
          Out_TotalUse = In_MeterReadCurr * 3
          Out_ActualUse = Out_TotalUse
        Case "D" 'Annual: DROP 2 HIGHEST QUARTERS THEN DOUBLE 
          Usage(0) = In_MeterReadCurr
          Usage(1) = In_MeterReadPrev
          Usage(2) = In_MeterRead2
          Usage(3) = In_MeterRead3
          Array.Sort(Usage)
          SbDebug.Append(Usage(0) & " " & Usage(1) & " " & Usage(2) & " " & Usage(3) & vbCrLf)
          Out_TotalUse = Usage(0) + Usage(1)
          Out_ActualUse = In_MeterReadCurr + In_MeterReadPrev + In_MeterRead2 + In_MeterRead3
          Out_TotalUse = Out_TotalUse * 2
        Case "H" 'Annual: DROP HIGH QUARTER 
          WrkQtr = In_MeterReadCurr
          If In_MeterReadPrev > WrkQtr Then
            WrkQtr = In_MeterReadPrev
          End If
          If In_MeterRead2 > WrkQtr Then
            WrkQtr = In_MeterRead2
          End If
          Out_TotalUse = In_MeterReadCurr + In_MeterReadPrev + In_MeterRead2
          Out_ActualUse = Out_TotalUse
          Out_TotalUse = ((Out_TotalUse - WrkQtr) / 2) * 3
        Case "Q" 'QUARTERLY BILL 
          Out_TotalUse = In_MeterReadCurr '+ In_MeterReadPrev + In_MeterRead2
          Out_ActualUse = Out_TotalUse
        Case "S" 'SEMI ANNUAL BILL
          Out_TotalUse = In_MeterReadCurr '+ In_MeterReadPrev + In_MeterRead2
          Out_ActualUse = Out_TotalUse
        Case "W" 'Annual: DOUBLE Winter and Drop summer
          Out_TotalUse = (In_MeterReadCurr * 2) + In_MeterReadPrev + In_MeterRead3
          Out_ActualUse = Out_TotalUse
        Case "Y" 'Annual: Full Year 
          Out_TotalUse = In_MeterReadCurr + In_MeterReadPrev + In_MeterRead2 + In_MeterRead3
          Out_ActualUse = Out_TotalUse
      End Select

      Out_MinBill = ._MTMIN
      SbDebug.Append("Min Bill " & Out_MinBill & vbCrLf)
      If ._MTMINC = "Y" Then
        Out_UseMinCharge = True
      End If
      If ._MTMINC = "U" Then
        Out_UnitCharge = In_Units * ._MTMIN
      End If
      Out_EDUCharge = In_EDUs * ._MTEDU
      Out_User1Charge = ._MTUSER1
      Out_User2Charge = ._MTUSER2
      Out_User3Charge = ._MTUSER3
      Out_MarkupPct = ._MTPCT
      SbDebug.Append("UseMinCharge " & Out_UseMinCharge & vbCrLf)
      Out_Debug = SbDebug.ToString
      If ._MTMINC = "U" Then
        SbDebug.Append("UnitCharge " & Out_UnitCharge & " = " & In_Units & " * " & ._MTMIN & vbCrLf)
        Out_UnitCalc = In_Units & " X " & ._MTMIN
      Else
        SbDebug.Append("UnitCharge " & Out_UnitCharge & vbCrLf)
        Out_UnitCalc = ""
      End If
      Out_Debug = SbDebug.ToString
      SbDebug.Append("EDUCharge " & Out_EDUCharge & " = " & In_EDUs & " * " & ._MTEDU & vbCrLf)
      Out_EDUCalc = In_EDUs & " X " & ._MTEDU
      Out_Debug = SbDebug.ToString
      SbDebug.Append("MarkupPct " & Out_MarkupPct & vbCrLf)
      Out_Debug = SbDebug.ToString
      SbDebug.Append("TotalUse " & Out_TotalUse & vbCrLf)
      Out_Debug = SbDebug.ToString
    End With
    If Out_TotalUse < 0 Then Out_TotalUse = 0
    If Out_ActualUse < 0 Then Out_ActualUse = 0
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
  Public Property In_MeterSize() As String
    Get
      In_MeterSize = mvarIn_MeterSize
    End Get
    Set(ByVal Value As String)
      mvarIn_MeterSize = Value
    End Set
  End Property
  Public Property In_MeterReadCurr() As Integer
    Get
      In_MeterReadCurr = mvarIn_MeterReadCurr
    End Get
    Set(ByVal Value As Integer)
      mvarIn_MeterReadCurr = Value
    End Set
  End Property
  Public Property In_MeterReadPrev() As Integer
    Get
      In_MeterReadPrev = mvarIn_MeterReadPrev
    End Get
    Set(ByVal Value As Integer)
      mvarIn_MeterReadPrev = Value
    End Set
  End Property
  Public Property In_MeterRead2() As Integer
    Get
      In_MeterRead2 = mvarIn_MeterRead2
    End Get
    Set(ByVal Value As Integer)
      mvarIn_MeterRead2 = Value
    End Set
  End Property
  Public Property In_MeterRead3() As Integer
    Get
      In_MeterRead3 = mvarIn_MeterRead3
    End Get
    Set(ByVal Value As Integer)
      mvarIn_MeterRead3 = Value
    End Set
  End Property
  Public Property In_Units() As Decimal
    Get
      In_Units = mvarIn_Units
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_Units = Value
    End Set
  End Property
  Public Property In_EDUs() As Decimal
    Get
      In_EDUs = mvarIn_EDUs
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_EDUs = Value
    End Set
  End Property
  Public Property Out_TotalUse() As Integer
    Get
      Out_TotalUse = mvarOut_TotalUse
    End Get
    Set(ByVal Value As Integer)
      mvarOut_TotalUse = Value
    End Set
  End Property
  Public Property Out_ActualUse() As Integer
    Get
      Out_ActualUse = mvarOut_ActualUse
    End Get
    Set(ByVal Value As Integer)
      mvarOut_ActualUse = Value
    End Set
  End Property
  Public Property Out_MinBill() As Double
    Get
      Out_MinBill = mvarOut_MinBill
    End Get
    Set(ByVal Value As Double)
      mvarOut_MinBill = Value
    End Set
  End Property
  Public Property Out_UseMinCharge() As Boolean
    Get
      Out_UseMinCharge = mvarOut_UseMinCharge
    End Get
    Set(ByVal Value As Boolean)
      mvarOut_UseMinCharge = Value
    End Set
  End Property
  Public Property Out_UnitCharge() As Decimal
    Get
      Out_UnitCharge = mvarOut_UnitCharge
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_UnitCharge = Value
    End Set
  End Property
  Public Property Out_UnitCalc() As String
    Get
      Out_UnitCalc = mvarOut_UnitCalc
    End Get
    Set(ByVal Value As String)
      mvarOut_UnitCalc = Value
    End Set
  End Property
  Public Property Out_EDUCharge() As Decimal
    Get
      Out_EDUCharge = mvarOut_EDUCharge
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_EDUCharge = Value
    End Set
  End Property
  Public Property Out_EDUCalc() As String
    Get
      Out_EDUCalc = mvarOut_EDUCalc
    End Get
    Set(ByVal Value As String)
      mvarOut_EDUCalc = Value
    End Set
  End Property
  Public Property Out_User1Charge() As Decimal
    Get
      Out_User1Charge = mvarOut_User1Charge
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_User1Charge = Value
    End Set
  End Property
  Public Property Out_User2Charge() As Decimal
    Get
      Out_User2Charge = mvarOut_User2Charge
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_User2Charge = Value
    End Set
  End Property
  Public Property Out_User3Charge() As Decimal
    Get
      Out_User3Charge = mvarOut_User3Charge
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_User3Charge = Value
    End Set
  End Property
  Public Property Out_MarkupPct() As Decimal
    Get
      Out_MarkupPct = mvarOut_MarkupPct
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_MarkupPct = Value
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


