Imports System.IO
Imports System.Xml
Imports System.Text

Public Class AppSettings

  Private m_FromYear As Integer
  Private m_ToYear As Integer
  Private m_Types As String
  Private m_NonPublic As String
  Private m_Status As String
  Private m_Liened As String
  Private m_LienMsg As String
  Private m_Omit As String
  Private m_NonCodes As String
  Private m_BlockSusp As Boolean
  Private m_BlockBackTax As Boolean
  Private m_OmitSusp As Boolean
  Private m_MVRegNo As Boolean
  Private m_FilePath As String
  Private m_WebTown As Integer
  Private m_WebName As String
  Private m_WebScript As String
  Private m_QRCode As Boolean
  Private m_PrintOrient As String
  Private m_WebPrefix As String
  Public Property FromYear() As Integer
    Get
      Return m_FromYear
    End Get
    Set(ByVal Value As Integer)
      m_FromYear = Value
    End Set
  End Property

  Public Property ToYear() As Integer
    Get
      Return m_ToYear
    End Get
    Set(ByVal Value As Integer)
      m_ToYear = Value
    End Set
  End Property

  Public Property Types() As String
    Get
      Return m_Types
    End Get
    Set(ByVal Value As String)
      m_Types = Value
    End Set
  End Property

  Public Property NonPublic() As String
    Get
      Return m_NonPublic
    End Get
    Set(ByVal Value As String)
      m_NonPublic = Value
    End Set
  End Property

  Public Property Status() As String
    Get
      Return m_Status
    End Get
    Set(ByVal Value As String)
      m_Status = Value
    End Set
  End Property

  Public Property Liened() As String
    Get
      Return m_Liened
    End Get
    Set(ByVal Value As String)
      m_Liened = Value
    End Set
  End Property

  Public Property LienMsg() As String
    Get
      Return m_LienMsg
    End Get
    Set(ByVal Value As String)
      m_LienMsg = Value
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

  Public Property BlockSusp() As Boolean
    Get
      Return m_BlockSusp
    End Get
    Set(ByVal Value As Boolean)
      m_BlockSusp = Value
    End Set
  End Property

  Public Property BlockBackTax() As Boolean
    Get
      Return m_BlockBackTax
    End Get
    Set(ByVal Value As Boolean)
      m_BlockBackTax = Value
    End Set
  End Property

  Public Property OmitSusp() As Boolean
    Get
      Return m_OmitSusp
    End Get
    Set(ByVal Value As Boolean)
      m_OmitSusp = Value
    End Set
  End Property

  Public Property MVRegNo() As Boolean
    Get
      Return m_MVRegNo
    End Get
    Set(ByVal Value As Boolean)
      m_MVRegNo = Value
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

  Public Property WebTown() As Integer
    Get
      Return m_WebTown
    End Get
    Set(ByVal Value As Integer)
      m_WebTown = Value
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

  Public Property WebScript() As String
    Get
      Return m_WebScript
    End Get
    Set(ByVal Value As String)
      m_WebScript = Value
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

  Public Property WebPrefix As String
    Get
      Return m_WebPrefix
    End Get
    Set(value As String)
      m_WebPrefix = value
    End Set
  End Property
  Public Property QRCode() As Boolean
    Get
      Return m_QRCode
    End Get
    Set(ByVal Value As Boolean)
      m_QRCode = Value
    End Set
  End Property

End Class
