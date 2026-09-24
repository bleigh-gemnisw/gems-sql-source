Imports System.text
Public Class BillAssessment
#Region "Variables"
  'Set the Local variable and the Property
  Dim MyDBConn As SQLConnect.DBConnection
  Dim myUTRATEAS As UTRATEAS.MyData
  Dim mvarIn_RateType As String
  Dim mvarIn_RateCode As String
  Dim mvarIn_DwellUnits As Decimal
  Dim mvarIn_PropVal As Integer
  Dim mvarIn_Acreage As Decimal
  Dim mvarIn_Footage As Decimal
  Dim mvarIn_LateralFee As Decimal
  Dim mvarIn_UniformFee As Decimal
  Dim mvarIn_AssmntAdjust As Decimal
  Dim mvarIn_DeferredAmt As Decimal
  Dim mvarIn_PrevBilled As Decimal
  Dim mvarOut_OrigBill As Decimal
  Dim mvarOut_AmtLeft As Decimal
	Dim mvarOut_UnitPart As Decimal
	Dim mvarOut_PropValPart As Decimal
	Dim mvarOut_FootagePart As Decimal
	Dim mvarOut_AcreagePart As Decimal
	Dim mvarOut_OtherPart As Decimal
	Dim mvarOut_Debug As String

#End Region

#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
    myUTRATEAS = New UTRATEAS.MyData(MyDBConn)
  End Sub
#End Region


#Region "Subroutines"

  Public Sub CalcAssessment()
    Dim SbDebug As New StringBuilder
    Dim WrkUnitChg As Decimal
    Dim WrkPropValChg As Decimal
    Dim WrkFootChg As Decimal
    Dim WrkAcreChg As Decimal

    myUTRATEAS.GetOneRecordP(In_RateType, In_RateCode)
    SbDebug.Append("Rate Type " & In_RateType & vbCrLf)
    SbDebug.Append("Rate Code " & In_RateCode & vbCrLf)
    If myUTRATEAS.RecordNotFound Then
      Out_Debug = "Record not found"
      Exit Sub
    End If

    With myUTRATEAS
      WrkUnitChg = Round(In_DwellUnits * ._RAUNIT, 2)
      SbDebug.Append("UnitChg: " & WrkUnitChg & " = " & In_DwellUnits & " * " & ._RAUNIT & vbCrLf)
      WrkPropValChg = Round(In_PropVal * ._RAPVAL, 2)
      SbDebug.Append("PropValChg: " & WrkPropValChg & " = " & In_PropVal & " * " & ._RAPVAL & vbCrLf)
      WrkFootChg = Round(In_Footage * ._RAFOOT, 2)
      SbDebug.Append("FootageChg: " & WrkFootChg & " = " & In_Footage & " * " & ._RAFOOT & vbCrLf)
      WrkAcreChg = Round(In_Acreage * ._RAACRE, 2)
      SbDebug.Append("AcreageChg: " & WrkAcreChg & " = " & In_Acreage & " * " & ._RAACRE & vbCrLf)
      SbDebug.Append("LateralFee: " & In_LateralFee & vbCrLf)
      SbDebug.Append("UniformFee: " & In_UniformFee & vbCrLf)
			Out_UnitPart = WrkUnitChg 
			Out_PropValPart = WrkPropValChg
			Out_FootagePart = WrkFootChg
			Out_AcreagePart = WrkAcreChg
			Out_OtherPart = In_LateralFee + In_UniformFee + In_AssmntAdjust
			Out_OrigBill = WrkUnitChg + WrkPropValChg + WrkFootChg + _
				WrkAcreChg + In_LateralFee + In_UniformFee
      SbDebug.Append("Total: " & Out_OrigBill & vbCrLf)
      Out_OrigBill = Out_OrigBill + In_AssmntAdjust
      SbDebug.Append("Adjust: " & In_AssmntAdjust & vbCrLf)
      Out_OrigBill = Out_OrigBill - In_DeferredAmt
      SbDebug.Append("Deferred: " & In_DeferredAmt & vbCrLf)
      Out_AmtLeft = 0
      If Out_OrigBill > 0 Then
        Out_AmtLeft = Out_OrigBill - In_PrevBilled
        SbDebug.Append("PrevBilled: " & In_PrevBilled & vbCrLf)
      End If
      SbDebug.Append("OrigBill: " & Out_OrigBill & vbCrLf)
      Out_OrigBill = Round(Out_OrigBill, 2)
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
  Public Property In_DwellUnits() As Decimal
    Get
      In_DwellUnits = mvarIn_DwellUnits
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_DwellUnits = Value
    End Set
  End Property
  Public Property In_PropVal() As Integer
    Get
      In_PropVal = mvarIn_PropVal
    End Get
    Set(ByVal Value As Integer)
      mvarIn_PropVal = Value
    End Set
  End Property
  Public Property In_Acreage() As Decimal
    Get
      In_Acreage = mvarIn_Acreage
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_Acreage = Value
    End Set
  End Property
  Public Property In_Footage() As Decimal
    Get
      In_Footage = mvarIn_Footage
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_Footage = Value
    End Set
  End Property
  Public Property In_LateralFee() As Decimal
    Get
      In_LateralFee = mvarIn_LateralFee
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_LateralFee = Value
    End Set
  End Property
  Public Property In_UniformFee() As Decimal
    Get
      In_UniformFee = mvarIn_UniformFee
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_UniformFee = Value
    End Set
  End Property
  Public Property In_AssmntAdjust() As Decimal
    Get
      In_AssmntAdjust = mvarIn_AssmntAdjust
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_AssmntAdjust = Value
    End Set
  End Property
  Public Property In_DeferredAmt() As Decimal
    Get
      In_DeferredAmt = mvarIn_DeferredAmt
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_DeferredAmt = Value
    End Set
  End Property
  Public Property In_PrevBilled() As Decimal
    Get
      In_PrevBilled = mvarIn_PrevBilled
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_PrevBilled = Value
    End Set
  End Property
  Public Property Out_OrigBill() As Decimal
    Get
      Out_OrigBill = mvarOut_OrigBill
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_OrigBill = Value
    End Set
  End Property
  Public Property Out_AmtLeft() As Decimal
    Get
      Out_AmtLeft = mvarOut_AmtLeft
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_AmtLeft = Value
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
	Public Property Out_PropValPart() As Decimal
		Get
			Out_PropValPart = mvarOut_PropValPart
		End Get
		Set(ByVal Value As Decimal)
			mvarOut_PropValPart = Value
		End Set
	End Property
	Public Property Out_FootagePart() As Decimal
		Get
			Out_FootagePart = mvarOut_FootagePart
		End Get
		Set(ByVal Value As Decimal)
			mvarOut_FootagePart = Value
		End Set
	End Property
	Public Property Out_AcreagePart() As Decimal
		Get
			Out_AcreagePart = mvarOut_AcreagePart
		End Get
		Set(ByVal Value As Decimal)
			mvarOut_AcreagePart = Value
		End Set
	End Property
	Public Property Out_OtherPart() As Decimal
		Get
			Out_OtherPart = mvarOut_OtherPart
		End Get
		Set(ByVal Value As Decimal)
			mvarOut_OtherPart = Value
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