Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Const cFileName As String = "TXCOO"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Function GetQry(ByVal WrkSort As String, ByVal WrkQry As String, ByVal NumRecs As Long) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    RecordNotFound = False
    StrSQL = "Select " & WrkTop & " * from " & cFileName
    If WrkQry <> String.Empty Then
      StrSQL = StrSQL & " where " & WrkQry
    End If
    If WrkSort <> String.Empty Then
      StrSQL = StrSQL & " order by " & WrkSort
    End If
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)

    If ds.Tables(0).Rows.Count = 0 Then
      RecordNotFound = True
    End If
    objCommand = Nothing
    Conn.Close()
    Return ds
  End Function
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
      _LISTNo = .Item("LIST#")
      _DEVLT = .Item("DEVLT")
      _CONAM = .Item("CONAM")
      _CONAM2 = .Item("CONAM2")
      _AMT = .Item("AMT")
      _DATE = .Item("DATE")
      _DAYS = .Item("DAYS")
      _PCT = .Item("PCT")
      _PINC = .Item("PINC")
      _COADD1 = .Item("COADD1")
      _COADD2 = .Item("COADD2")
      _COCITY = .Item("COCITY")
      _COSTE = .Item("COSTE")
      _COZIP5 = .Item("COZIP5")
      _COZIP4 = .Item("COZIP4")
      _PCD = .Item("PCD")
      _RLIST = .Item("RLIST")
      _BENAMT = .Item("BENAMT")
      _PRF = .Item("PRF")
      _CHDATE = .Item("CHDATE")
      _CHTIME = .Item("CHTIME")
      _LETT = .Item("LETT")
      _PFLAG = .Item("PFLAG")
      _PCOBEF = .Item("PCOBEF")
      _PCOAFT = .Item("PCOAFT")

    End With
  End Sub

#End Region


#Region "Properties: Fields"

  Dim mLISTNo  as integer 
Public Property _LISTNo  as integer   
    Get
        Return mLISTNo
    End Get
    set(byval value as integer)
        mLISTNo = value
    End Set
End Property

Dim mDEVLT as string 
Public Property _DEVLT as string   
    Get
        Return mDEVLT
    End Get
    set(byval value as string)
        mDEVLT = value
    End Set
End Property

Dim mCONAM as string 
Public Property _CONAM as string   
    Get
        Return mCONAM
    End Get
    set(byval value as string)
        mCONAM = value
    End Set
End Property

Dim mCONAM2 as string 
Public Property _CONAM2 as string   
    Get
        Return mCONAM2
    End Get
    set(byval value as string)
        mCONAM2 = value
    End Set
End Property

Dim mAMT as decimal
Public Property _AMT as decimal
    Get
        Return mAMT
    End Get
    Set(ByVal value As Decimal)
      mAMT = value
    End Set
  End Property

  Dim mDATE As Integer
  Public Property _DATE As Integer
    Get
      Return mDATE
    End Get
    Set(ByVal value As Integer)
      mDATE = value
    End Set
  End Property

  Dim mDAYS As Integer
  Public Property _DAYS As Integer
    Get
      Return mDAYS
    End Get
    Set(ByVal value As Integer)
      mDAYS = value
    End Set
  End Property

  Dim mPCT As Decimal
  Public Property _PCT As Decimal
    Get
      Return mPCT
    End Get
    Set(ByVal value As Decimal)
      mPCT = value
    End Set
  End Property

  Dim mPINC As Decimal
  Public Property _PINC As Decimal
    Get
      Return mPINC
    End Get
    Set(ByVal value As Decimal)
      mPINC = value
    End Set
  End Property

  Dim mCOADD1 As String
  Public Property _COADD1 As String
    Get
      Return mCOADD1
    End Get
    Set(ByVal value As String)
      mCOADD1 = value
    End Set
  End Property

  Dim mCOADD2 As String
  Public Property _COADD2 As String
    Get
      Return mCOADD2
    End Get
    Set(ByVal value As String)
      mCOADD2 = value
    End Set
  End Property

  Dim mCOCITY As String
  Public Property _COCITY As String
    Get
      Return mCOCITY
    End Get
    Set(ByVal value As String)
      mCOCITY = value
    End Set
  End Property

  Dim mCOSTE As String
  Public Property _COSTE As String
    Get
      Return mCOSTE
    End Get
    Set(ByVal value As String)
      mCOSTE = value
    End Set
  End Property

  Dim mCOZIP5 As Integer
  Public Property _COZIP5 As Integer
    Get
      Return mCOZIP5
    End Get
    Set(ByVal value As Integer)
      mCOZIP5 = value
    End Set
  End Property

  Dim mCOZIP4 As Integer
  Public Property _COZIP4 As Integer
    Get
      Return mCOZIP4
    End Get
    Set(ByVal value As Integer)
      mCOZIP4 = value
    End Set
  End Property

  Dim mPCD As String
  Public Property _PCD As String
    Get
      Return mPCD
    End Get
    Set(ByVal value As String)
      mPCD = value
    End Set
  End Property

  Dim mRLIST As Integer
  Public Property _RLIST As Integer
    Get
      Return mRLIST
    End Get
    Set(ByVal value As Integer)
      mRLIST = value
    End Set
  End Property

  Dim mBENAMT As Decimal
  Public Property _BENAMT As Decimal
    Get
      Return mBENAMT
    End Get
    Set(ByVal value As Decimal)
      mBENAMT = value
    End Set
  End Property

  Dim mPRF As String
  Public Property _PRF As String
    Get
      Return mPRF
    End Get
    Set(ByVal value As String)
      mPRF = value
    End Set
  End Property

  Dim mCHDATE As Integer
  Public Property _CHDATE As Integer
    Get
      Return mCHDATE
    End Get
    Set(ByVal value As Integer)
      mCHDATE = value
    End Set
  End Property

  Dim mCHTIME As Integer
  Public Property _CHTIME As Integer
    Get
      Return mCHTIME
    End Get
    Set(ByVal value As Integer)
      mCHTIME = value
    End Set
  End Property

  Dim mLETT As String
  Public Property _LETT As String
    Get
      Return mLETT
    End Get
    Set(ByVal value As String)
      mLETT = value
    End Set
  End Property

  Dim mPFLAG As String
  Public Property _PFLAG As String
    Get
      Return mPFLAG
    End Get
    Set(ByVal value As String)
      mPFLAG = value
    End Set
  End Property

  Dim mPCOBEF As Decimal
  Public Property _PCOBEF As Decimal
    Get
      Return mPCOBEF
    End Get
    Set(ByVal value As Decimal)
      mPCOBEF = value
    End Set
  End Property

  Dim mPCOAFT As Decimal
  Public Property _PCOAFT As Decimal
    Get
      Return mPCOAFT
    End Get
    Set(ByVal value As Decimal)
      mPCOAFT = value
    End Set
  End Property

Dim mRecordNotFound As Boolean
Public Property RecordNotFound() As Boolean
  Set(ByVal value as Boolean)
    mRecordNotFound = value
  End Set
  Get
    Return mRecordNotFound
  End Get
End Property
Dim mIsEOF As Boolean
Public Property IsEOF() As Boolean
  Set(ByVal value as Boolean)
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
    Set(ByVal value as String)
        mErrMsg = value
    End Set
End Property
#End Region
End Class


