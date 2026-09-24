Imports System.IO
Public Class AppSettings2

  Private m_FilePath As String
  Private m_FileName As String
  Private m_Address As String
  Private m_User As String
  Private m_Password As String
  Public Property FilePath() As String
    Get
      Return m_FilePath
    End Get
    Set(ByVal Value As String)
      m_FilePath = Value
    End Set
  End Property
  Public Property FileName() As String
    Get
      Return m_FileName
    End Get
    Set(ByVal Value As String)
      m_FileName = Value
    End Set
  End Property
  Public Property Address() As String
    Get
      Return m_Address
    End Get
    Set(ByVal Value As String)
      m_Address = Value
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






