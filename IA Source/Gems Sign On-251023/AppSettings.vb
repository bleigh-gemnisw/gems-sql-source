Public Class AppSettings

  Private m_ServerIP As String
  Private m_DatabaseName As String
  Private m_DatabaseName2 As String
  Public Property DatabaseName() As String
    Get
      Return m_DatabaseName
    End Get
    Set(ByVal Value As String)
      m_DatabaseName = Value
    End Set
  End Property
  Public Property DatabaseName2() As String
    Get
      Return m_DatabaseName2
    End Get
    Set(ByVal Value As String)
      m_DatabaseName2 = Value
    End Set
  End Property
End Class
