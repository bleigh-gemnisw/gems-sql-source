Imports System.text
Public Class BillMetered
#Region "Variables"
  'Set the Local variable and the Property
  Dim MyDBConn As SQLConnect.DBConnection
  Dim myUTRATEMT As UTRATEMT.MyData
  Dim myUTMUSER As UTMUSER.MyData
  Dim mvarIn_RateType As String
  Dim mvarIn_RateCode As String
  Dim mvarIn_TotalUse As Integer
  Dim mvarIn_MinBill As Decimal
  Dim mvarIn_UseMinCharge As Boolean
  Dim mvarIn_UnitCharge As Decimal
  Dim mvarIn_EDUCharge As Decimal
  Dim mvarIn_User1Charge As Decimal
  Dim mvarIn_User2Charge As Decimal
  Dim mvarIn_User3Charge As Decimal
  Dim mvarIn_MarkupPct As Decimal
  Dim mvarOut_Bill As Decimal
	Dim mvarOut_UsagePart As Decimal
	Dim mvarOut_MinBillPart As Decimal
	Dim mvarOut_UnitPart As Decimal
  Dim mvarOut_UnitCalc As String
  Dim mvarOut_EDUPart As Decimal
  Dim mvarOut_EduCalc As String
  Dim mvarOut_User1Part As Decimal
  Dim mvarOut_User2Part As Decimal
  Dim mvarOut_User3Part As Decimal
  Dim mvarOut_BasePart As Decimal
  Dim mvarOut_MarkUpPart As Decimal
  Dim mvarOut_RateCalc1 As String
  Dim mvarOut_RateCalc2 As String
  Dim mvarOut_Debug As String
#End Region

#Region "Constructors"
  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
    myUTRATEMT = New UTRATEMT.MyData(MyDBConn)
    myUTMUSER = New UTMUSER.MyData(MyDBConn)
  End Sub

#End Region


#Region "Subroutines"

  Public Sub CalcMetered()
    Dim dsrate As DataSet = New DataSet
    Dim WrkUse As Integer
    Dim WrkUseLeft As Integer
    Dim WrkRate(14) As Decimal
    Dim WrkMeterUsage(14) As Integer
		Dim WrkAmt As Decimal
		Dim WrkPct As Decimal
    Dim I As Integer
    Dim SbDebug As New StringBuilder

		Out_Bill = 0
		Out_UsagePart = 0
		Out_MinBillPart = 0
		Out_UnitPart = 0
    Out_EDUPart = 0
    Out_user1Part = 0
    Out_user2Part = 0
    Out_user3Part = 0
    Out_EDUCalc = ""
    Out_BasePart = 0
    Out_MarkupPart = 0
    Out_RateCalc1 = ""
    Out_RateCalc2 = ""

    dsrate = myUTRATEMT.GetAllCode(In_RateType, In_RateCode, 999)

    SbDebug.Append("Rate Type " & In_RateType & vbCrLf)
    SbDebug.Append("Rate Code " & In_RateCode & vbCrLf)

    For I = 0 To dsrate.Tables(0).Rows.Count - 1
      With dsrate.Tables(0).Rows(I)
        WrkMeterUsage(I) = .Item("rmtier")
        WrkRate(I) = .Item("rmrate")
      End With
    Next

    WrkUseLeft = In_TotalUse
    Out_RateCalc1 = ""
    Out_RateCalc2 = ""

    For I = 0 To 14
      If WrkUseLeft > WrkMeterUsage(I) Then
        WrkUseLeft = WrkUseLeft - WrkMeterUsage(I)
        WrkUse = WrkMeterUsage(I)
      Else
        WrkUse = WrkUseLeft
        WrkUseLeft = 0
      End If
      WrkAmt = Round(WrkUse * WrkRate(I), 2)
			Out_UsagePart = Out_UsagePart + WrkAmt
			Out_Bill = Out_Bill + WrkAmt
      Select Case I
        Case 0
          Out_RateCalc1 = WrkUse & " x " & WrkRate(0)
        Case 1
          Out_RateCalc2 = WrkUse & " x " & WrkRate(1)
        Case Else
      End Select
      If WrkUse > 0 Then
        SbDebug.Append("Usage " & I & ": " & WrkAmt & " = " & WrkUse & " * " & WrkRate(I) & vbCrLf)
      End If
    Next

    If In_UnitCharge = 0 Then
      If In_UseMinCharge Then
        If Out_Bill < In_MinBill Then
					Out_MinBillPart = In_MinBill - Out_Bill
					Out_Bill = In_MinBill
          SbDebug.Append("Min Bill: " & Out_MinBillPart & vbCrLf)
				End If
      Else
				Out_BasePart = In_MinBill
				Out_Bill = Out_Bill + In_MinBill
        SbDebug.Append("Base Chg: " & Out_BasePart & vbCrLf)
			End If
    Else
      Out_UnitPart = In_UnitCharge
      Out_Bill = Out_Bill + In_UnitCharge
      SbDebug.Append("Unit Charge: " & Out_UnitPart & vbCrLf)
		End If
    If Out_UsagePart > 0 Then
      SbDebug.Append("Usage Charge: " & Out_UsagePart & vbCrLf)
    End If
    If In_EDUCharge > 0 Then
      Out_EDUPart = In_EDUCharge
      Out_EDUCalc = Out_EDUCalc
      Out_Bill = Out_Bill + In_EDUCharge
      SbDebug.Append("EDU Charge: " & Out_EDUPart & vbCrLf)
    End If
    myUTMUSER.GetOneRecordP(1)
    If In_User1Charge > 0 Then
      Out_User1Part = In_User1Charge
      Out_Bill = Out_Bill + In_User1Charge
      SbDebug.Append(Trim(myUTMUSER._USER1) & " Charge: " & Out_User1Part & vbCrLf)
    End If
    If In_User2Charge > 0 Then
      Out_User2Part = In_user2Charge
      Out_Bill = Out_Bill + In_User2Charge
      SbDebug.Append(Trim(myUTMUSER._USER2) & " Charge: " & Out_User2Part & vbCrLf)
    End If
    If In_User3Charge > 0 Then
      Out_User3Part = In_user3Charge
      Out_Bill = Out_Bill + In_User3Charge
      SbDebug.Append(Trim(myUTMUSER._USER3) & " Charge: " & Out_User3Part & vbCrLf)
    End If
    If In_MarkupPct > 0 Then
      WrkPct = In_MarkupPct / 100
      WrkAmt = Round((Out_Bill * WrkPct), 2)
      SbDebug.Append("MarkUp Pct: " & WrkAmt & " = " & Out_Bill & " * " & In_MarkupPct & "%" & vbCrLf)
      Out_MarkupPart = WrkAmt
      Out_Bill = Out_Bill + WrkAmt
    End If

    Out_Bill = Round(Out_Bill, 2)
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
  Public Property In_TotalUse() As Integer
    Get
      In_TotalUse = mvarIn_TotalUse
    End Get
    Set(ByVal Value As Integer)
      mvarIn_TotalUse = Value
    End Set
  End Property
  Public Property In_MinBill() As Decimal
    Get
      In_MinBill = mvarIn_MinBill
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_MinBill = Value
    End Set
  End Property
  Public Property In_UseMinCharge() As Boolean
    Get
      In_UseMinCharge = mvarIn_UseMinCharge
    End Get
    Set(ByVal Value As Boolean)
      mvarIn_UseMinCharge = Value
    End Set
  End Property
  Public Property In_UnitCharge() As Decimal
    Get
      In_UnitCharge = mvarIn_UnitCharge
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_UnitCharge = Value
    End Set
  End Property
  Public Property In_EDUCharge() As Decimal
    Get
      In_EDUCharge = mvarIn_EDUCharge
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_EDUCharge = Value
    End Set
  End Property
  Public Property In_User1Charge() As Decimal
    Get
      In_User1Charge = mvarIn_User1Charge
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_User1Charge = Value
    End Set
  End Property
  Public Property In_User2Charge() As Decimal
    Get
      In_User2Charge = mvarIn_User2Charge
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_User2Charge = Value
    End Set
  End Property
  Public Property In_User3Charge() As Decimal
    Get
      In_User3Charge = mvarIn_User3Charge
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_User3Charge = Value
    End Set
  End Property
  Public Property In_MarkupPct() As Decimal
    Get
      In_MarkupPct = mvarIn_MarkupPct
    End Get
    Set(ByVal Value As Decimal)
      mvarIn_MarkupPct = Value
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
	Public Property Out_UsagePart() As Decimal
		Get
			Out_UsagePart = mvarOut_UsagePart
		End Get
		Set(ByVal Value As Decimal)
			mvarOut_UsagePart = Value
		End Set
	End Property
	Public Property Out_MinBillPart() As Decimal
		Get
			Out_MinBillPart = mvarOut_MinBillPart
		End Get
		Set(ByVal Value As Decimal)
			mvarOut_MinBillPart = Value
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
  Public Property Out_EDUCalc() As String
    Get
      Out_EDUCalc = mvarOut_EduCalc
    End Get
    Set(ByVal Value As String)
      mvarOut_EduCalc = Value
    End Set
  End Property
  Public Property Out_User1Part() As Decimal
    Get
      Out_User1Part = mvarOut_User1Part
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_User1Part = Value
    End Set
  End Property
  Public Property Out_User2Part() As Decimal
    Get
      Out_User2Part = mvarOut_User2Part
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_User2Part = Value
    End Set
  End Property
  Public Property Out_User3Part() As Decimal
    Get
      Out_User3Part = mvarOut_User3Part
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_User3Part = Value
    End Set
  End Property
  Public Property Out_MarkupPart() As Decimal
    Get
      Out_MarkupPart = mvarOut_MarkUpPart
    End Get
    Set(ByVal Value As Decimal)
      mvarOut_MarkUpPart = Value
    End Set
  End Property
  Public Property Out_RateCalc1() As String
    Get
      Out_RateCalc1 = mvarOut_RateCalc1
    End Get
    Set(ByVal Value As String)
      mvarOut_RateCalc1 = Value
    End Set
  End Property
  Public Property Out_RateCalc2() As String
    Get
      Out_RateCalc2 = mvarOut_RateCalc2
    End Get
    Set(ByVal Value As String)
      mvarOut_RateCalc2 = Value
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




