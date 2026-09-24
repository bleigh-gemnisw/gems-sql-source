Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Const cFileName As String = "PKTICK"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub OpenQry(ByVal WrkSort As String, ByVal WrkQry As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand

    StrSQL = "Select * from " & cFileName
    If WrkQry <> String.Empty Then
      StrSQL = StrSQL & " where " & WrkQry
    End If
    If WrkSort <> String.Empty Then
      StrSQL = StrSQL & " order by " & WrkSort
    End If
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    objReader = objCommand.ExecuteReader()
  End Sub
  Public Sub ReadQry()
    Dim Good As Boolean

    IsEOF = False
    Good = objReader.Read
    If Good Then
      GetFields()
    Else
      IsEOF = True
      objReader.Close()
    End If
  End Sub
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
  End Sub
#End Region

#Region "Properties: Get/Put"
  Public Sub GetFields()
    With objReader
      _STATUS = .Item("STATUS")
      _TICKNO = .Item("TICKNO")
      _OFFCNO = .Item("OFFCNO")
      _REGNO = .Item("REGNO")
      _REGST = .Item("REGST")
      _VEHTYP = .Item("VEHTYP")
      _VDATE = .Item("VDATE")
      _VTIME = .Item("VTIME")
      _AMPM = .Item("AMPM")
      _METERNo = .Item("METER#")
      _STREET = .Item("STREET")
      _VIOL1 = .Item("VIOL1")
      _VIOL2 = .Item("VIOL2")
      _VIOL3 = .Item("VIOL3")
      _VIOL4 = .Item("VIOL4")
      _VIOL5 = .Item("VIOL5")
      _VIAMT = .Item("VIAMT")
      _AMT1 = .Item("AMT1")
      _DATE1 = .Item("DATE1")
      _AMT2 = .Item("AMT2")
      _DATE2 = .Item("DATE2")
      _AMT3 = .Item("AMT3")
      _DATE3 = .Item("DATE3")
      _OVERCD = .Item("OVERCD")
      _NAME = .Item("NAME")
      _ADDR = .Item("ADDR")
      _CITY = .Item("CITY")
      _STATE = .Item("STATE")
      _ZIP = .Item("ZIP")
    End With
  End Sub
#End Region

#Region "Properties: Fields"
  Dim mRecordNotFound As Boolean
Public Property RecordNotFound() As Boolean
  Set(ByVal value As Boolean)
    mRecordNotFound = value
  End Set
  Get
    Return mRecordNotFound
  End Get
End Property
Dim mIsEOF As Boolean
Public Property IsEOF() As Boolean
  Set(ByVal value As Boolean)
    mIsEOF = value
  End Set
  Get
    Return mIsEOF
  End Get
End Property
Dim mErrMsg As String
Public Property ErrMsg() As String
    Get
      Return mErrMsg
    End Get
    Set(ByVal value As String)
        mErrMsg = value
    End Set
End Property
  Dim mSTATUS As String
  Public Property _STATUS As String
    Get
      Return mSTATUS
    End Get
    Set(ByVal value As String)
      mSTATUS = value
    End Set
  End Property

  Dim mTICKNO As Integer
  Public Property _TICKNO As Integer
    Get
      Return mTICKNO
    End Get
    Set(ByVal value As Integer)
      mTICKNO = value
    End Set
  End Property

  Dim mOFFCNO As String
  Public Property _OFFCNO As String
    Get
      Return mOFFCNO
    End Get
    Set(ByVal value As String)
      mOFFCNO = value
    End Set
  End Property

  Dim mREGNO As String
  Public Property _REGNO As String
    Get
      Return mREGNO
    End Get
    Set(ByVal value As String)
      mREGNO = value
    End Set
  End Property

  Dim mREGST As String
  Public Property _REGST As String
    Get
      Return mREGST
    End Get
    Set(ByVal value As String)
      mREGST = value
    End Set
  End Property

  Dim mVEHTYP As String
  Public Property _VEHTYP As String
    Get
      Return mVEHTYP
    End Get
    Set(ByVal value As String)
      mVEHTYP = value
    End Set
  End Property

  Dim mVDATE As Integer
  Public Property _VDATE As Integer
    Get
      Return mVDATE
    End Get
    Set(ByVal value As Integer)
      mVDATE = value
    End Set
  End Property

  Dim mVTIME As Integer
  Public Property _VTIME As Integer
    Get
      Return mVTIME
    End Get
    Set(ByVal value As Integer)
      mVTIME = value
    End Set
  End Property

  Dim mAMPM As String
  Public Property _AMPM As String
    Get
      Return mAMPM
    End Get
    Set(ByVal value As String)
      mAMPM = value
    End Set
  End Property

  Dim mMETERNo As Integer
  Public Property _METERNo As Integer
    Get
      Return mMETERNo
    End Get
    Set(ByVal value As Integer)
      mMETERNo = value
    End Set
  End Property

  Dim mSTREET As String
  Public Property _STREET As String
    Get
      Return mSTREET
    End Get
    Set(ByVal value As String)
      mSTREET = value
    End Set
  End Property

  Dim mVIOL1 As Integer
  Public Property _VIOL1 As Integer
    Get
      Return mVIOL1
    End Get
    Set(ByVal value As Integer)
      mVIOL1 = value
    End Set
  End Property

  Dim mVIOL2 As Integer
  Public Property _VIOL2 As Integer
    Get
      Return mVIOL2
    End Get
    Set(ByVal value As Integer)
      mVIOL2 = value
    End Set
  End Property

  Dim mVIOL3 As Integer
  Public Property _VIOL3 As Integer
    Get
      Return mVIOL3
    End Get
    Set(ByVal value As Integer)
      mVIOL3 = value
    End Set
  End Property

  Dim mVIOL4 As Integer
  Public Property _VIOL4 As Integer
    Get
      Return mVIOL4
    End Get
    Set(ByVal value As Integer)
      mVIOL4 = value
    End Set
  End Property

  Dim mVIOL5 As Integer
  Public Property _VIOL5 As Integer
    Get
      Return mVIOL5
    End Get
    Set(ByVal value As Integer)
      mVIOL5 = value
    End Set
  End Property

  Dim mVIAMT As Decimal
  Public Property _VIAMT As Decimal
    Get
      Return mVIAMT
    End Get
    Set(ByVal value As Decimal)
      mVIAMT = value
    End Set
  End Property

  Dim mAMT1 As Decimal
  Public Property _AMT1 As Decimal
    Get
      Return mAMT1
    End Get
    Set(ByVal value As Decimal)
      mAMT1 = value
    End Set
  End Property

  Dim mDATE1 As Integer
  Public Property _DATE1 As Integer
    Get
      Return mDATE1
    End Get
    Set(ByVal value As Integer)
      mDATE1 = value
    End Set
  End Property

  Dim mAMT2 As Decimal
  Public Property _AMT2 As Decimal
    Get
      Return mAMT2
    End Get
    Set(ByVal value As Decimal)
      mAMT2 = value
    End Set
  End Property

  Dim mDATE2 As Integer
  Public Property _DATE2 As Integer
    Get
      Return mDATE2
    End Get
    Set(ByVal value As Integer)
      mDATE2 = value
    End Set
  End Property

  Dim mAMT3 As Decimal
  Public Property _AMT3 As Decimal
    Get
      Return mAMT3
    End Get
    Set(ByVal value As Decimal)
      mAMT3 = value
    End Set
  End Property

  Dim mDATE3 As Integer
  Public Property _DATE3 As Integer
    Get
      Return mDATE3
    End Get
    Set(ByVal value As Integer)
      mDATE3 = value
    End Set
  End Property

  Dim mOVERCD As String
  Public Property _OVERCD As String
    Get
      Return mOVERCD
    End Get
    Set(ByVal value As String)
      mOVERCD = value
    End Set
  End Property

  Dim mNAME As String
  Public Property _NAME As String
    Get
      Return mNAME
    End Get
    Set(ByVal value As String)
      mNAME = value
    End Set
  End Property

  Dim mADDR As String
  Public Property _ADDR As String
    Get
      Return mADDR
    End Get
    Set(ByVal value As String)
      mADDR = value
    End Set
  End Property

  Dim mCITY As String
  Public Property _CITY As String
    Get
      Return mCITY
    End Get
    Set(ByVal value As String)
      mCITY = value
    End Set
  End Property

  Dim mSTATE As String
  Public Property _STATE As String
    Get
      Return mSTATE
    End Get
    Set(ByVal value As String)
      mSTATE = value
    End Set
  End Property

  Dim mZIP As String
  Public Property _ZIP As String
    Get
      Return mZIP
    End Get
    Set(ByVal value As String)
      mZIP = value
    End Set
  End Property
#End Region
End Class

