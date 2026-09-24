Imports System.IO
Public Class AppSettings

  Private m_RegCode As String
  Private m_SoldCode As String
  Private m_RegSize As String
  Private m_SoldSize As String
  Public Property RegCode() As String
    Get
      Return m_RegCode
    End Get
    Set(ByVal Value As String)
      m_RegCode = Value
    End Set
  End Property
  Public Property SoldCode() As String
    Get
      Return m_SoldCode
    End Get
    Set(ByVal Value As String)
      m_SoldCode = Value
    End Set
  End Property
  Public Property RegSize() As String
    Get
      Return m_RegSize
    End Get
    Set(ByVal Value As String)
      m_RegSize = Value
    End Set
  End Property
  Public Property SoldSize() As String
    Get
      Return m_SoldSize
    End Get
    Set(ByVal Value As String)
      m_SoldSize = Value
    End Set
  End Property
End Class






