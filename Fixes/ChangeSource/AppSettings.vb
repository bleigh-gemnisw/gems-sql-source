Public Class AppSettings

  Private m_FilePath As String
  Public Property FilePath() As String
    Get
      Return m_FilePath
    End Get
    Set(ByVal Value As String)
      m_FilePath = Value
    End Set
  End Property
End Class
