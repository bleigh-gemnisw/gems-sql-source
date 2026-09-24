Imports System.IO
Public Class AppSettings
  Private m_ServerIP As String
  Private m_ConnName As String
  Private m_DatabaseName As String
  Private m_UserID As String
  Private m_Password As String
  Private m_ConnName2 As String
  Private m_DatabaseName2 As String
  Private m_UserID2 As String
  Private m_Password2 As String
  Public Property ServerIP() As String
    Get
      Return m_ServerIP
    End Get
    Set(ByVal Value As String)
      m_ServerIP = Value
    End Set
  End Property
  Public Property ConnName() As String
    Get
      Return m_ConnName
    End Get
    Set(ByVal Value As String)
      m_ConnName = Value
    End Set
  End Property
  Public Property DatabaseName() As String
    Get
      Return m_DatabaseName
    End Get
    Set(ByVal Value As String)
      m_DatabaseName = Value
    End Set
  End Property
  Public Property UserID() As String
    Get
      Return m_UserID
    End Get
    Set(ByVal Value As String)
      m_UserID = Value
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
  Public Property ConnName2() As String
    Get
      Return m_ConnName2
    End Get
    Set(ByVal Value As String)
      m_ConnName2 = Value
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
  Public Property UserID2() As String
    Get
      Return m_UserID2
    End Get
    Set(ByVal Value As String)
      m_UserID2 = Value
    End Set
  End Property
  Public Property Password2() As String
    Get
      Return m_Password2
    End Get
    Set(ByVal Value As String)
      m_Password2 = Value
    End Set
  End Property
End Class


