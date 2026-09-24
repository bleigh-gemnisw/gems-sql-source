Imports System.Text
Public Class MyData
#Region "Variables"
  'Set the Local variable and the Property
  Dim MyDBConn As SQLConnect.DBConnection
  Dim myUTCUSTMT As UTCUSTMT.MyData
  Dim mvarIn_ListNo As Integer
  Dim mvarIn_RateType As String
  Dim mvarIn_AnnualBill As Boolean
  Dim mvarIn_BillDate As Date
  Dim mvarOut_ActualCurr As Integer
  Dim mvarOut_ActualPrev As Integer
  Dim mvarOut_MeterReadCurr As Integer
  Dim mvarOut_MeterReadPrev As Integer
  Dim mvarOut_MeterRead2 As Integer
  Dim mvarOut_MeterRead3 As Integer
  Dim mvarOut_Debug As String
#End Region

#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
    myUTCUSTMT = New UTCUSTMT.MyData(MyDBConn)
  End Sub

#End Region


#Region "Subroutines"

  Public Sub GetMeterReadings()
    Dim ds2 As DataSet = New DataSet
    Dim sb As StringBuilder
    Dim WrkBillDate1 As Date
    Dim WrkBillDate2 As Date
    Dim WrkBillDate3 As Date
    Dim WrkBillDate4 As Date
    Dim WrkDate As Date
    Dim WrkDBStrDate As Integer
    Dim WrkDBEndDate As Integer
    Dim I As Integer
    Dim MaxI As Integer

    In_BillDate = In_BillDate.ToShortDateString 'Strip Time
    Out_ActualCurr = 0
    Out_ActualPrev = 0
    Out_MeterReadCurr = 0
    Out_MeterReadPrev = 0
    Out_MeterRead2 = 0
    Out_MeterRead3 = 0
    Out_Debug = ""
    WrkDBEndDate = SetDBDate(In_BillDate)
    If In_AnnualBill Then
      WrkDBStrDate = SetDBDate(DateAdd(DateInterval.Year, -1, In_BillDate))
    Else
      WrkDBStrDate = SetDBDate(DateAdd(DateInterval.Month, -4, In_BillDate))
    End If

    sb = New StringBuilder
    sb.Append("Rate Type: ")
    ds2 = myUTCUSTMT.GetAllListNo(In_ListNo, In_RateType, WrkDBStrDate, WrkDBEndDate)
    If ds2.Tables(0).Rows.Count = 0 Then
      ds2.Clear()
      ds2 = myUTCUSTMT.GetAllListNo(In_ListNo, "", WrkDBStrDate, WrkDBEndDate)
      sb.Append("")
    Else
      sb.Append(In_RateType)
    End If
    Out_Debug = Out_Debug & sb.ToString & vbCrLf
    sb = Nothing

    If ds2.Tables(0).Rows.Count = 0 Then Exit Sub

    MaxI = ds2.Tables(0).Rows.Count - 1
    If Not In_AnnualBill Then
      WrkBillDate1 = DateAdd(DateInterval.Month, -1, In_BillDate)
      WrkBillDate2 = DateAdd(DateInterval.Month, -2, In_BillDate)
      WrkBillDate3 = DateAdd(DateInterval.Month, -3, In_BillDate)
      WrkBillDate4 = DateAdd(DateInterval.Month, -4, In_BillDate)
    Else
      WrkBillDate1 = DateAdd(DateInterval.Month, -3, In_BillDate)
      WrkBillDate2 = DateAdd(DateInterval.Month, -6, In_BillDate)
      WrkBillDate3 = DateAdd(DateInterval.Month, -9, In_BillDate)
      WrkBillDate4 = DateAdd(DateInterval.Month, -12, In_BillDate)
    End If

    'Get readings for past 3 months 
    For I = 0 To MaxI
      With ds2.Tables(0).Rows(I)
        WrkDate = GetDBDate(.Item("cmdate"))
        If WrkDate < WrkBillDate4 Then Exit For
        If WrkDate <= In_BillDate And WrkDate > WrkBillDate1 Then
          If Out_ActualCurr = 0 Then
            Out_ActualCurr = .Item("cmread")
          End If
          Out_MeterReadCurr = Out_MeterReadCurr + .Item("cmuse")
          sb = New StringBuilder
          sb.Append("Current: ")
          sb.Append(Format(WrkDate, "Short Date"))
          sb.Append(" ")
          sb.Append(.Item("cmuse"))
          Out_Debug = Out_Debug & sb.ToString & vbCrLf
          sb = Nothing
        End If
        If WrkDate <= WrkBillDate1 And WrkDate > WrkBillDate2 Then
          Out_MeterReadPrev = Out_MeterReadPrev + .Item("cmuse")
          sb = New StringBuilder
          sb.Append("Previous: ")
          sb.Append(Format(WrkDate, "Short Date"))
          sb.Append(" ")
          sb.Append(.Item("cmuse"))
          Out_Debug = Out_Debug & sb.ToString & vbCrLf
          sb = Nothing
        End If
        If WrkDate <= WrkBillDate2 And WrkDate > WrkBillDate3 Then
          Out_MeterRead2 = Out_MeterRead2 + .Item("cmuse")
          sb = New StringBuilder
          sb.Append("Read2: ")
          sb.Append(Format(WrkDate, "Short Date"))
          sb.Append(" ")
          sb.Append(.Item("cmuse"))
          Out_Debug = Out_Debug & sb.ToString & vbCrLf
          sb = Nothing
        End If
        If In_AnnualBill Then
          If WrkDate <= WrkBillDate3 And WrkDate > WrkBillDate4 Then
            Out_MeterRead3 = Out_MeterRead3 + .Item("cmuse")
            sb = New StringBuilder
            sb.Append("Read3: ")
            sb.Append(Format(WrkDate, "Short Date"))
            sb.Append(" ")
            sb.Append(.Item("cmuse"))
            Out_Debug = Out_Debug & sb.ToString & vbCrLf
            sb = Nothing
          End If
        Else
          If WrkDate <= WrkBillDate3 And WrkDate > WrkBillDate4 Then
            If Out_ActualPrev = 0 Then
              Out_ActualPrev = .Item("cmread")
            End If
          End If
        End If
      End With
    Next

  End Sub

#End Region

#Region "Properties"

  Public Property In_ListNo() As Integer
    Get
      In_ListNo = mvarIn_ListNo
    End Get
    Set(ByVal Value As Integer)
      mvarIn_ListNo = Value
    End Set
  End Property
  Public Property In_RateType() As String
    Get
      In_RateType = mvarIn_RateType
    End Get
    Set(ByVal Value As String)
      mvarIn_RateType = Value
    End Set
  End Property
  Public Property In_AnnualBill() As Boolean
    Get
      In_AnnualBill = mvarIn_AnnualBill
    End Get
    Set(ByVal Value As Boolean)
      mvarIn_AnnualBill = Value
    End Set
  End Property
  Public Property In_BillDate() As Date
    Get
      In_BillDate = mvarIn_BillDate
    End Get
    Set(ByVal Value As Date)
      mvarIn_BillDate = Value
    End Set
  End Property
  Public Property Out_ActualCurr() As Integer
    Get
      Out_ActualCurr = mvarOut_ActualCurr
    End Get
    Set(ByVal Value As Integer)
      mvarOut_ActualCurr = Value
    End Set
  End Property
  Public Property Out_ActualPrev() As Integer
    Get
      Out_ActualPrev = mvarOut_ActualPrev
    End Get
    Set(ByVal Value As Integer)
      mvarOut_ActualPrev = Value
    End Set
  End Property
  Public Property Out_MeterReadCurr() As Integer
    Get
      Out_MeterReadCurr = mvarOut_MeterReadCurr
    End Get
    Set(ByVal Value As Integer)
      mvarOut_MeterReadCurr = Value
    End Set
  End Property
  Public Property Out_MeterReadPrev() As Integer
    Get
      Out_MeterReadPrev = mvarOut_MeterReadPrev
    End Get
    Set(ByVal Value As Integer)
      mvarOut_MeterReadPrev = Value
    End Set
  End Property
  Public Property Out_MeterRead2() As Integer
    Get
      Out_MeterRead2 = mvarOut_MeterRead2
    End Get
    Set(ByVal Value As Integer)
      mvarOut_MeterRead2 = Value
    End Set
  End Property
  Public Property Out_MeterRead3() As Integer
    Get
      Out_MeterRead3 = mvarOut_MeterRead3
    End Get
    Set(ByVal Value As Integer)
      mvarOut_MeterRead3 = Value
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

  Public Function GetDBDate(ByVal DateIn As Integer) As Date
    Dim WrkDate As Date
    Dim StrDate As String

    If DateIn > 0 Then
      StrDate = Trim$(Str(DateIn))
      Try
        WrkDate = Mid$(StrDate, 5, 2) & "/" & Right$(StrDate, 2) & "/" & Left$(StrDate, 4)
      Catch
      End Try
    End If
    Return WrkDate
  End Function
  Public Function SetDBDate(ByVal DateIn As Date) As Integer
    Dim WrkDate As Integer
    Dim StrDate As String

    StrDate = Year(DateIn) & Format(Month(DateIn), "00") &
    Format(DatePart(DateInterval.Day, DateIn), "00")
    WrkDate = CnvSng(StrDate)
    Return WrkDate
  End Function
  Public Function CnvSng(ByVal WrkNum As String) As Decimal
    'Convert string to decimal
    Dim WrkDbl As Decimal

    If WrkNum = "" Then
      WrkDbl = 0
      Return WrkDbl
    End If

    If Not IsNumeric(WrkNum) Then
      WrkDbl = 0
      Return WrkDbl
    End If

    WrkDbl = CDbl(WrkNum)
    Return WrkDbl
  End Function
End Class

