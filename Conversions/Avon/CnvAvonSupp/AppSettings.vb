Imports System.IO
Public Class AppSettings
  Private m_ServerIP As String
  Private m_FileMRATE As String
  Private m_FileRE As String
  Private m_FilePP As String
  Private m_FileMV As String
  Private m_FileSU As String
  Private m_FilePPA As String
  Private m_FileINV As String
  Private m_FileHST As String
  Private m_FilePrvINV As String
  Private m_FilePrvHST As String
  Private m_FileDlqINV As String
  Private m_FileDlqHST As String
  Private m_FileCC As String
  Private m_FileUT As String
  Private m_FileUT2 As String
  Private m_FileUTAS As String
  Private m_FileUTAS2 As String
  Private m_FileUTXREF As String
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
  Public Property FileMRATE() As String
    Get
      Return m_FileMRATE
    End Get
    Set(ByVal Value As String)
      m_FileMRATE = Value
    End Set
  End Property
  Public Property FileRE() As String
    Get
      Return m_FileRE
    End Get
    Set(ByVal Value As String)
      m_FileRE = Value
    End Set
  End Property
  Public Property FilePP() As String
    Get
      Return m_FilePP
    End Get
    Set(ByVal Value As String)
      m_FilePP = Value
    End Set
  End Property
  Public Property FileMV() As String
    Get
      Return m_FileMV
    End Get
    Set(ByVal Value As String)
      m_FileMV = Value
    End Set
  End Property
  Public Property FileSU() As String
    Get
      Return m_FileSU
    End Get
    Set(ByVal Value As String)
      m_FileSU = Value
    End Set
  End Property
  Public Property FilePPA() As String
    Get
      Return m_FilePPA
    End Get
    Set(ByVal Value As String)
      m_FilePPA = Value
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
  Public Property FileUT2() As String
    Get
      Return m_FileUT2
    End Get
    Set(ByVal Value As String)
      m_FileUT2 = Value
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
  Public Property FileUTAS2() As String
    Get
      Return m_FileUTAS2
    End Get
    Set(ByVal Value As String)
      m_FileUTAS2 = Value
    End Set
  End Property
  Public Property FileUTXREF() As String
    Get
      Return m_FileUTXREF
    End Get
    Set(ByVal Value As String)
      m_FileUTXREF = Value
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
  Public Property FilePrvINV() As String
    Get
      Return m_FilePrvINV
    End Get
    Set(ByVal Value As String)
      m_FilePrvINV = Value
    End Set
  End Property
  Public Property FilePrvHST() As String
    Get
      Return m_FilePrvHST
    End Get
    Set(ByVal Value As String)
      m_FilePrvHST = Value
    End Set
  End Property
  Public Property FileDlqINV() As String
    Get
      Return m_FileDlqINV
    End Get
    Set(ByVal Value As String)
      m_FileDlqINV = Value
    End Set
  End Property
  Public Property FileDlqHST() As String
    Get
      Return m_FileDlqHST
    End Get
    Set(ByVal Value As String)
      m_FileDlqHST = Value
    End Set
  End Property
  Public Property FileCC() As String
    Get
      Return m_FileCC
    End Get
    Set(ByVal Value As String)
      m_FileCC = Value
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


