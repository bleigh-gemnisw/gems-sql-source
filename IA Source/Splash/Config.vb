Imports System.IO
Public Class AppSplash

  Private m_UserName As Boolean
  Public Property UserName() As Boolean
    Get
      Return m_UserName
    End Get
    Set(ByVal Value As Boolean)
      m_UserName = Value
    End Set
  End Property
End Class

