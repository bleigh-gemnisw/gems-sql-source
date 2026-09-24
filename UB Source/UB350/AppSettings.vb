Imports System.IO
Public Class AppSettings

    Private m_Add As Boolean
    Private m_Name As Boolean
    Private m_Dist As Boolean
    Private m_PDist As Boolean
    Private m_Loc As Boolean
    Private m_Map As Boolean
    Private m_Vol As Boolean
    Private m_FilePath As String
    Private m_WebName As String
  Public Property Add() As Boolean
    Get
      Return m_Add
    End Get
    Set(ByVal Value As Boolean)
      m_Add = Value
    End Set
  End Property
  Public Property Name() As Boolean
    Get
      Return m_Name
    End Get
    Set(ByVal Value As Boolean)
      m_Name = Value
    End Set
  End Property
  Public Property Dist() As Boolean
    Get
      Return m_Dist
    End Get
    Set(ByVal Value As Boolean)
      m_Dist = Value
    End Set
  End Property
  Public Property PDist() As Boolean
    Get
      Return m_PDist
    End Get
    Set(ByVal Value As Boolean)
      m_PDist = Value
    End Set
  End Property
  Public Property Loc() As Boolean
    Get
      Return m_Loc
    End Get
    Set(ByVal Value As Boolean)
      m_Loc = Value
    End Set
  End Property
  Public Property Map() As Boolean
    Get
      Return m_Map
    End Get
    Set(ByVal Value As Boolean)
      m_Map = Value
    End Set
  End Property
  Public Property Vol() As Boolean
    Get
      Return m_Vol
    End Get
    Set(ByVal Value As Boolean)
      m_Vol = Value
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
  Public Property WebName() As String
    Get
      Return m_WebName
    End Get
    Set(ByVal Value As String)
      m_WebName = Value
    End Set
  End Property
End Class






