Imports System.text
Public Class BillUsage
#Region "Variables"
  'Set the Local variable and the Property
  Dim MyDBConn As SQLConnect.DBConnection
  Dim myUTRATEUS As UTRATEUS.MyData
  Dim mvarIn_RateType As String
  Dim mvarIn_RateCode As String
  Dim mvarIn_Units As Decimal
  Dim mvarIn_EDUs As Decimal
  Dim mvarIn_Fixtures As Integer
  Dim mvarIn_Extras As Integer
  Dim mvarIn_SurChg As Decimal
  Dim mvarOut_Bill As Decimal
  Dim mvarOut_UnitPart As Decimal
  Dim mvarOut_EDUPart As Decimal
  Dim mvarOut_FixtPart As Decimal
	Dim mvarOut_ExtraPart As Decimal
	Dim mvarOut_BasePart As Decimal
	Dim mvarOut_MarkUpPart As Decimal
	Dim mvarOut_Debug As String

#End Region

#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
    myUTRATEUS = New UTRATEUS.MyData(MyDBConn)
  End Sub
#End Region

#Region "Subroutines"

  Public Sub CalcUsage()
    Dim WrkUnitChg As Decimal
    Dim WrkEDUChg As Decimal
    Dim WrkFixtChg As Decimal
		Dim WrkExtraChg As Decimal
    Dim WrkPct As Decimal
    Dim WrkAmt As Decimal
    Dim SbDebug As New StringBuilder

    Out_Bill = 0
		Out_UnitPart = 0
    Out_EDUPart = 0
    Out_FixtPart = 0
		Out_ExtraPart = 0
		Out_BasePart = 0
		Out_MarkupPart = 0

    myUTRATEUS.GetOneRecordP(In_RateType, In_RateCode)
    If myUTRATEUS.RecordNotFound Then Exit Sub

    SbDebug.Append("Rate Type " & In_RateType & vbCrLf)
    SbDebug.Append("Rate Code " & In_RateCode & vbCrLf)
    With myUTRATEUS
      WrkUnitChg = In_Units * ._RUUNIT
      WrkEDUChg = In_EDUs * ._RUEDU
      WrkFixtChg = In_Fixtures * ._RUFIXT
      WrkExtraChg = In_Extras * ._RUXTRA
      Out_Bill = ._RUBASE + WrkUnitChg + WrkEDUChg + WrkFixtChg + WrkExtraChg
			Out_UnitPart = WrkUnitChg
      Out_EDUPart = WrkEDUChg
      Out_FixtPart = WrkFixtChg
			Out_ExtraPart = WrkExtraChg
			Out_BasePart = ._RUBASE
			SbDebug.Append("UnitChg: " & WrkUnitChg & " = " & In_Units & " * " & ._RUUNIT & vbCrLf)
      SbDebug.Append("EDUChg: " & WrkEDUChg & " = " & In_EDUs & " * " & ._RUEDU & vbCrLf)
      SbDebug.Append("FixtChg: " & WrkFixtChg & " = " & In_Fixtures & " * " & ._RUFIXT & vbCrLf)
      SbDebug.Append("ExtraChg: " & WrkExtraChg & " = " & In_Extras & " * " & ._RUXTRA & vbCrLf)
      SbDebug.Append("BaseChg: " & ._RUBASE & vbCrLf)
			If In_SurChg > 0 Then
				SbDebug.Append("SurChg: " & (Out_Bill * In_SurChg) & " = " & Out_Bill & " * " & In_SurChg & vbCrLf)
				WrkAmt = Round(Out_Bill * In_SurChg, 2)
				Out_MarkupPart = WrkAmt
				Out_Bill = Out_Bill + WrkAmt
			Else
				WrkPct = ._RUPCT / 100
				WrkAmt = Round(Out_Bill * WrkPct, 2)
        SbDebug.Append("MarkUp Pct: " & WrkAmt & " = " & Out_Bill & " * " & ._RUPCT & "%" & vbCrLf)
        Out_MarkupPart = WrkAmt
        Out_Bill = Out_Bill + WrkAmt
			End If
			Out_Bill = Round(Out_Bill, 2)
			Out_Debug = SbDebug.ToString
		End With
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
  Public Property In_Fixtures() As Integer
    Get
      In_Fixtures = mvarIn_Fixtures
    End Get
    Set(ByVal Value As Integer)
      mvarIn_Fixtures = Value
    End Set
  End Property
  Public Property In_Extras() As Integer
    Get
      In_Extras = mvarIn_Extras
    End Get
    Set(ByVal Value As Integer)
      mvarIn_Extras = Value
    End Set
  End Property
	Public Property In_SurChg() As Decimal
		Get
			In_SurChg = mvarIn_SurChg
		End Get
		Set(ByVal Value As Decimal)
			mvarIn_SurChg = Value
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
	Public Property Out_UnitPart() As Decimal
		Get
			Out_UnitPart = mvarOut_UnitPart
		End Get
		Set(ByVal Value As Decimal)
			mvarOut_UnitPart = Value
		End Set
	End Property
  Public Property Out_EDUPart() As Decimal
    Get
      Out_EDUPart = mvarOut_EDUPart
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_EDUPart = Value
    End Set
  End Property
  Public Property Out_FixtPart() As Decimal
    Get
      Out_FixtPart = mvarOut_FixtPart
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_FixtPart = Value
    End Set
  End Property
	Public Property Out_ExtraPart() As Decimal
		Get
			Out_ExtraPart = mvarOut_ExtraPart
		End Get
		Set(ByVal Value As Decimal)
			mvarOut_ExtraPart = Value
		End Set
	End Property
	Public Property Out_BasePart() As Decimal
		Get
			Out_BasePart = mvarOut_BasePart
		End Get
		Set(ByVal Value As Decimal)
			mvarOut_BasePart = Value
		End Set
	End Property
	Public Property Out_MarkupPart() As Decimal
		Get
			Out_MarkupPart = mvarOut_MarkupPart
		End Get
		Set(ByVal Value As Decimal)
			mvarOut_MarkupPart = Value
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

