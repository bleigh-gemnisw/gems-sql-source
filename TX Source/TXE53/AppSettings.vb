Imports System.IO
Public Class AppSettings

  Private m_Types As String
  Private m_Format As String
  Private m_FilePath As String
  Private m_Header As Boolean
  Private m_Implicit As Boolean
  Private m_Address As String
  Private m_User As String
  Private m_Password As String
  Private m_Port As Integer
  Public Property Types() As String
    Get
      Return m_Types
    End Get
    Set(ByVal Value As String)
      m_Types = Value
    End Set
  End Property
  Public Property Format() As String
    Get
      Return m_Format
    End Get
    Set(ByVal Value As String)
      m_Format = Value
    End Set
  End Property
  Public Property FilePath() As String
    Get
      Return m_FilePath
    End Get
    Set(ByVal Value As String)
      m_FilePath = Value
    End Set
  End Property
  Public Property Header() As Boolean
    Get
      Return m_Header
    End Get
    Set(ByVal Value As Boolean)
      m_Header = Value
    End Set
  End Property
  Public Property Implicit() As Boolean
    Get
      Return m_Implicit
    End Get
    Set(ByVal Value As Boolean)
      m_Implicit = Value
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
  Public Property Port() As Integer
    Get
      Return m_Port
    End Get
    Set(ByVal Value As Integer)
      m_Port = Value
    End Set
  End Property
End Class
