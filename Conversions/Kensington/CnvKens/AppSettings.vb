Imports System.IO
Public Class AppSettings
  Private m_ServerIP As String
  Private m_FileTAXCOM As String
  Private m_FileINV As String
  Private m_FileHST As String
  Private m_FileUT As String
  Private m_FileUTAS As String
  Private m_FileUTMT As String
  Private m_FileUTMT2 As String
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
  Public Property FileTAXCOM() As String
    Get
      Return m_FileTAXCOM
    End Get
    Set(ByVal Value As String)
      m_FileTAXCOM = Value
    End Set
  End Property
  Public Property FileUT() As String
    Get
      Return m_FileUT
    End Get
    Set(ByVal Value As String)
      m_FileUT = Value
    End Set
  End Property
  Public Property FileUTMT() As String
    Get
      Return m_FileUTMT
    End Get
    Set(ByVal Value As String)
      m_FileUTMT = Value
    End Set
  End Property
  Public Property FileUTMT2() As String
    Get
      Return m_FileUTMT2
    End Get
    Set(ByVal Value As String)
      m_FileUTMT2 = Value
    End Set
  End Property
  Public Property FileUTAS() As String
    Get
      Return m_FileUTAS
    End Get
    Set(ByVal Value As String)
      m_FileUTAS = Value
    End Set
  End Property
  Public Property FileINV() As String
    Get
      Return m_FileINV
    End Get
    Set(ByVal Value As String)
      m_FileINV = Value
    End Set
  End Property
  Public Property FileHST() As String
    Get
      Return m_FileHST
    End Get
    Set(ByVal Value As String)
      m_FileHST = Value
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


