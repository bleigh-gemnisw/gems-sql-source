Imports System.IO
Public Class AppSettings

  Private m_Types As String
  Private m_Omit As String
  Private m_NonCodes As String
  Private m_WebTown As Integer
  Public Property Types() As String
    Get
      Return m_Types
    End Get
    Set(ByVal Value As String)
      m_Types = Value
    End Set
  End Property
  Public Property Omit() As String
    Get
      Return m_Omit
    End Get
    Set(ByVal Value As String)
      m_Omit = Value
    End Set
  End Property
  Public Property NonCodes() As String
    Get
      Return m_NonCodes
    End Get
    Set(ByVal Value As String)
      m_NonCodes = Value
    End Set
  End Property
  Public Property WebTown() As Integer
    Get
      Return m_WebTown
    End Get
    Set(ByVal Value As Integer)
      m_WebTown = Value
    End Set
  End Property
End Class






