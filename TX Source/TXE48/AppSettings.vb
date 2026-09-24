Imports System.IO
Public Class AppSettings

    Private m_FileMode As Boolean
    Private m_Host As String
    Private m_User As String
    Private m_Password As String
  Public Property FileMode() As Boolean
    Get
      Return m_FileMode
    End Get
    Set(ByVal Value As Boolean)
      m_FileMode = Value
    End Set
  End Property
    Public Property Host() As String
        Get
            Return m_Host
        End Get
        Set(ByVal Value As String)
            m_Host = Value
        End Set
    End Property
  Public Property User() As String
    Get
      Return m_User
    End Get
    Set(ByVal Value As String)
      m_User = Value
    End Set
  End Property
    Public Property Password() As String
        Get
            Return m_Password
        End Get
        Set(ByVal Value As String)
            m_Password = Value
        End Set
    End Property
End Class






