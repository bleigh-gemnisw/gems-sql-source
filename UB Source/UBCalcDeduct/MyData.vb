Imports System.Text

Public Class MyData
#Region "Variables"
  'Set the Local variable and the Property
  Dim MyDBConn As SQLConnect.DBConnection
  Dim myUTDEDDIFF As UTDEDDIFF.MyData
  Dim mvarIn_ListNo As Integer
  Dim mvarIn_MeterNo As String
  Dim mvarIn_BillDate As Date
  Dim mvarIn_AnnualBill As Boolean
  Dim mvarIn_SemiAnnualBill As Boolean
  Dim mvarOut_Deduct As Integer
  Dim mvarOut_DateDeduct As String
#End Region

#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
    myUTDEDDIFF = New UTDEDDIFF.MyData(MyDBConn)
  End Sub

#End Region


#Region "Subroutines"

  Public Sub GetMeterDeduct()
    Dim ds2 As DataSet = New DataSet
    Dim WrkDate As Date
    Dim WrkDBStrDate As Integer

    In_BillDate = In_BillDate.ToShortDateString 'Strip Time
    Out_Deduct = 0
    Out_DateDeduct = ""
    If In_AnnualBill Then
      WrkDBStrDate = SetDBDate(DateAdd(DateInterval.Year, -1, In_BillDate))
    ElseIf mvarIn_SemiAnnualBill Then
      WrkDBStrDate = SetDBDate(DateAdd(DateInterval.Month, -7, In_BillDate))
    Else
      WrkDBStrDate = SetDBDate(DateAdd(DateInterval.Month, -4, In_BillDate))
    End If

    ds2 = myUTDEDDIFF.GetLastDiff(In_ListNo, In_MeterNo, SetDBDate(In_BillDate))
    If ds2.Tables(0).Rows.Count = 0 Then Exit Sub

    'Get Last deduct from past x months 
    With ds2.Tables(0).Rows(0)
      WrkDate = GetDBDate(.Item("dddate"))
      If WrkDate <= In_BillDate Then 'And WrkDate > GetDBDate(WrkDBStrDate) Then
        Out_Deduct = .Item("dddiff")
        Out_DateDeduct = GetDBDate(.Item("dddate"))
      End If
    End With
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
  Public Property In_MeterNo() As String
    Get
      In_MeterNo = mvarIn_MeterNo
    End Get
    Set(ByVal Value As String)
      mvarIn_MeterNo = Value
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
  Public Property In_SemiAnnualBill() As Boolean
    Get
      In_SemiAnnualBill = mvarIn_SemiAnnualBill
    End Get
    Set(ByVal Value As Boolean)
      mvarIn_SemiAnnualBill = Value
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
  Public Property Out_Deduct() As Integer
    Get
      Out_Deduct = mvarOut_Deduct
    End Get
    Set(ByVal Value As Integer)
      mvarOut_Deduct = Value
    End Set
  End Property
  Public Property Out_DateDeduct() As String
    Get
      Out_DateDeduct = mvarOut_DateDeduct
    End Get
    Set(ByVal Value As String)
      mvarOut_DateDeduct = Value
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

