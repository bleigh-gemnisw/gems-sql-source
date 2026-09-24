Imports System.IO
Public Class AppConfig

  Private m_WebName As String
  Public Property WebName() As String
    Get
      Return m_WebName
    End Get
    Set(ByVal Value As String)
      m_WebName = Value
    End Set
  End Property
End Class

