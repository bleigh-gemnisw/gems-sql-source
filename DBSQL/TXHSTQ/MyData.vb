Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Const cFileName As String = "TXHST"
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
    objCommand.CommandTimeout = 300

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
    objCommand.CommandTimeout = 300
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
      _RCODE = .Item("RCODE")
      _LISTNo = .Item("LIST#")
      _YEAR = .Item("YEAR")
      _TYPE = .Item("TYPE")
      _PAMT = .Item("PAMT")
      _IAMT = .Item("IAMT")
      _LAMT = .Item("LAMT")
      _CASH = .Item("CASH")
      _CHECK = .Item("CHECK")
      _CREDIT = .Item("CREDIT")
      _CORC = .Item("CORC")
      _DIST = .Item("DIST")
      _REF = .Item("REF")
      _COMM = .Item("COMM")
      _ADJCD = .Item("ADJCD")
      _BATCHN = .Item("BATCHN")
      _BATCHS = .Item("BATCHS")
      _BATCHA = .Item("BATCHA")
      _PDATE = .Item("PDATE")
      _CDATE = .Item("CDATE")
      _PCAMT = .Item("PCAMT")
      _SUSCD = .Item("SUSCD")
      _THAJCD = .Item("THAJCD")
      _THINPD = .Item("THINPD")
      _PENCD = .Item("PENCD")
      _INTOR = .Item("INTOR")
      _PRF = .Item("PRF")
      _CHDATE = .Item("CHDATE")
      _CHTIME = .Item("CHTIME")
    End With
  End Sub
  Public Sub GetFieldsDr(ByVal Dr As DataRow)
    With Dr
      _RCODE = .Item("RCODE")
      _LISTNo = .Item("LIST#")
      _YEAR = .Item("YEAR")
      _TYPE = .Item("TYPE")
      _PAMT = .Item("PAMT")
      _IAMT = .Item("IAMT")
      _LAMT = .Item("LAMT")
      _CASH = .Item("CASH")
      _CHECK = .Item("CHECK")
      _CREDIT = .Item("CREDIT")
      _CORC = .Item("CORC")
      _DIST = .Item("DIST")
      _REF = .Item("REF")
      _COMM = .Item("COMM")
      _ADJCD = .Item("ADJCD")
      _BATCHN = .Item("BATCHN")
      _BATCHS = .Item("BATCHS")
      _BATCHA = .Item("BATCHA")
      _PDATE = .Item("PDATE")
      _CDATE = .Item("CDATE")
      _PCAMT = .Item("PCAMT")
      _SUSCD = .Item("SUSCD")
      _THAJCD = .Item("THAJCD")
      _THINPD = .Item("THINPD")
      _PENCD = .Item("PENCD")
      _INTOR = .Item("INTOR")
      _PRF = .Item("PRF")
      _CHDATE = .Item("CHDATE")
      _CHTIME = .Item("CHTIME")
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
  Dim mRCODE As String
  Public Property _RCODE As String
    Get
      Return mRCODE
    End Get
    Set(ByVal value As String)
      mRCODE = value
    End Set
  End Property
  Dim mLISTNo As Integer
  Public Property _LISTNo As Integer
    Get
      Return mLISTNo
    End Get
    Set(ByVal value As Integer)
      mLISTNo = value
    End Set
  End Property
  Dim mYEAR As Integer
  Public Property _YEAR As Integer
    Get
      Return mYEAR
    End Get
    Set(ByVal value As Integer)
      mYEAR = value
    End Set
  End Property
  Dim mTYPE As String
  Public Property _TYPE As String
    Get
      Return mTYPE
    End Get
    Set(ByVal value As String)
      mTYPE = value
    End Set
  End Property
  Dim mPAMT As Decimal
  Public Property _PAMT As Decimal
    Get
      Return mPAMT
    End Get
    Set(ByVal value As Decimal)
      mPAMT = value
    End Set
  End Property
  Dim mIAMT As Decimal
  Public Property _IAMT As Decimal
    Get
      Return mIAMT
    End Get
    Set(ByVal value As Decimal)
      mIAMT = value
    End Set
  End Property
  Dim mLAMT As Decimal
  Public Property _LAMT As Decimal
    Get
      Return mLAMT
    End Get
    Set(ByVal value As Decimal)
      mLAMT = value
    End Set
  End Property
  Dim mCASH As Decimal
  Public Property _CASH As Decimal
    Get
      Return mCASH
    End Get
    Set(ByVal value As Decimal)
      mCASH = value
    End Set
  End Property
  Dim mCHECK As Decimal
  Public Property _CHECK As Decimal
    Get
      Return mCHECK
    End Get
    Set(ByVal value As Decimal)
      mCHECK = value
    End Set
  End Property
  Dim mCREDIT As Decimal
  Public Property _CREDIT As Decimal
    Get
      Return mCREDIT
    End Get
    Set(ByVal value As Decimal)
      mCREDIT = value
    End Set
  End Property
  Dim mCORC As String
  Public Property _CORC As String
    Get
      Return mCORC
    End Get
    Set(ByVal value As String)
      mCORC = value
    End Set
  End Property
  Dim mDIST As Integer
  Public Property _DIST As Integer
    Get
      Return mDIST
    End Get
    Set(ByVal value As Integer)
      mDIST = value
    End Set
  End Property
  Dim mREF As String
  Public Property _REF As String
    Get
      Return mREF
    End Get
    Set(ByVal value As String)
      mREF = value
    End Set
  End Property
  Dim mCOMM As String
  Public Property _COMM As String
    Get
      Return mCOMM
    End Get
    Set(ByVal value As String)
      mCOMM = value
    End Set
  End Property
  Dim mADJCD As String
  Public Property _ADJCD As String
    Get
      Return mADJCD
    End Get
    Set(ByVal value As String)
      mADJCD = value
    End Set
  End Property
  Dim mBATCHN As Integer
  Public Property _BATCHN As Integer
    Get
      Return mBATCHN
    End Get
    Set(ByVal value As Integer)
      mBATCHN = value
    End Set
  End Property
  Dim mBATCHS As Integer
  Public Property _BATCHS As Integer
    Get
      Return mBATCHS
    End Get
    Set(ByVal value As Integer)
      mBATCHS = value
    End Set
  End Property
  Dim mBATCHA As String
  Public Property _BATCHA As String
    Get
      Return mBATCHA
    End Get
    Set(ByVal value As String)
      mBATCHA = value
    End Set
  End Property
  Dim mPDATE As Integer
  Public Property _PDATE As Integer
    Get
      Return mPDATE
    End Get
    Set(ByVal value As Integer)
      mPDATE = value
    End Set
  End Property
  Dim mCDATE As Integer
  Public Property _CDATE As Integer
    Get
      Return mCDATE
    End Get
    Set(ByVal value As Integer)
      mCDATE = value
    End Set
  End Property
  Dim mPCAMT As Decimal
  Public Property _PCAMT As Decimal
    Get
      Return mPCAMT
    End Get
    Set(ByVal value As Decimal)
      mPCAMT = value
    End Set
  End Property
  Dim mSUSCD As String
  Public Property _SUSCD As String
    Get
      Return mSUSCD
    End Get
    Set(ByVal value As String)
      mSUSCD = value
    End Set
  End Property
  Dim mTHAJCD As String
  Public Property _THAJCD As String
    Get
      Return mTHAJCD
    End Get
    Set(ByVal value As String)
      mTHAJCD = value
    End Set
  End Property
  Dim mTHINPD As String
  Public Property _THINPD As String
    Get
      Return mTHINPD
    End Get
    Set(ByVal value As String)
      mTHINPD = value
    End Set
  End Property
  Dim mPENCD As String
  Public Property _PENCD As String
    Get
      Return mPENCD
    End Get
    Set(ByVal value As String)
      mPENCD = value
    End Set
  End Property
  Dim mINTOR As Decimal
  Public Property _INTOR As Decimal
    Get
      Return mINTOR
    End Get
    Set(ByVal value As Decimal)
      mINTOR = value
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
#End Region

End Class

