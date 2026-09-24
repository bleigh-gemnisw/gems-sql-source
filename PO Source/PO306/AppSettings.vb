Imports System.IO
Public Class AppSettings

  Private m_Year As Integer
  Private m_Printer As String
  Private m_Printer2 As String
  Private m_Printer3 As String
  Private m_Drawers As Boolean
  Private m_PrintOrient As String
  Public Property Year() As Integer
    Get
      Return m_Year
    End Get
    Set(ByVal Value As Integer)
      m_Year = Value
    End Set
  End Property
  Public Property Printer() As String
    Get
      Return m_Printer
    End Get
    Set(ByVal Value As String)
      m_Printer = Value
    End Set
  End Property
  Public Property Printer2() As String
    Get
      Return m_Printer2
    End Get
    Set(ByVal Value As String)
      m_Printer2 = Value
    End Set
  End Property
  Public Property Printer3() As String
    Get
      Return m_Printer3
    End Get
    Set(ByVal Value As String)
      m_Printer3 = Value
    End Set
  End Property
  Public Property Drawers() As Boolean
    Get
      Return m_Drawers
    End Get
    Set(ByVal Value As Boolean)
      m_Drawers = Value
    End Set
  End Property
  Public Property PrintOrient() As String
    Get
      Return m_PrintOrient
    End Get
    Set(ByVal Value As String)
      m_PrintOrient = Value
    End Set
  End Property
End Class

