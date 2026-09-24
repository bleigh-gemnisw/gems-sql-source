Public Class AppSettings

  Private m_CurrYear As Integer
  Private m_CurrYearSU As Integer
  Private m_PrintOrient As String
  Public Property CurrYear() As Integer
      Get
          Return m_CurrYear
      End Get
      Set(ByVal Value As Integer)
          m_CurrYear = Value
      End Set
  End Property
  Public Property CurrYearSU() As Integer
      Get
          Return m_CurrYearSU
      End Get
      Set(ByVal Value As Integer)
          m_CurrYearSU = Value
      End Set
  End Property
  Public Property PrintOrient() As String
      Get
          Return m_PrintOrient
      End Get
      Set(ByVal Value As String)
          m_PrintOrient = Value
      End Set
  End Property
End Class






