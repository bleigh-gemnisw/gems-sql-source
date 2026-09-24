Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim ConnRdr As SqlConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objreader As SqlDataReader
  Const cFileName As String = "TSPBCH"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Function GetViewbyBatch(ByVal WrkBchno As Integer, ByVal NumRecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim WrkTop As String
  WrkTop = String.Empty

  RecordNotFound = False
  If NumRecs > 0 Then
    WrkTop = "TOP " & NumRecs & " "
  End If
  StrSQL = "Select " & WrkTop & "*" & _
   " from " & cFileName & " where bchno=" & WrkBchno & " order by list#, year, type"
  Try
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    objCommand = Nothing
    Conn.Close()
    Return ds
  Catch ex As Exception
    ErrMsg = ex.ToString()
    Return Nothing
  End Try
End Function
  Public Sub SetRange(ByVal WrkBatch As Integer)
  Dim objCommand As SqlCommand

  RecordNotFound = False
  IsEOF = False
  StrSQL = "Select * from " & cFileName & " where bchno=" & WrkBatch
  ConnRdr = MyDBConn.Open
  objCommand = New SqlCommand(StrSQL, ConnRdr)
  objreader = objCommand.ExecuteReader()
  objCommand = Nothing
End Sub
Public Sub ReadFileE()
  Dim Good As Boolean

  Good = objreader.Read()
  If Good Then
    GetFieldsRdr()
  Else
    CloseRange()
  End If
End Sub
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
  End Sub
  Public Sub CloseRange()
    IsEOF = True
    objreader.Close()
    ConnRdr.Close()
  End Sub
#End Region

#Region "Properties: Get/Put"
Public Sub GetFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    _BCHNO = .Item("BCHNO")
    _LISTNo = .Item("LIST#")
    _YEAR = .Item("YEAR")
    _TYPE = .Item("TYPE")
    _SCD = .Item("SCD")
    _COMM = .Item("COMM")
    _NAME = .Item("NAME")
    _TAXT = .Item("TAXT")
    _PDATE = .Item("PDATE")
    _DIST = .Item("DIST")
  End With
End Sub
Public Sub GetFieldsRdr()
  With objreader
    _BCHNO = .Item("BCHNO")
    _LISTNo = .Item("LIST#")
    _YEAR = .Item("YEAR")
    _TYPE = .Item("TYPE")
    _SCD = .Item("SCD")
    _COMM = .Item("COMM")
    _NAME = .Item("NAME")
    _TAXT = .Item("TAXT")
    _PDATE = .Item("PDATE")
    _DIST = .Item("DIST")
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
Dim mBCHNO As Integer
Public Property _BCHNO As Integer
    Get
        Return mBCHNO
    End Get
    Set(ByVal value As Integer)
        mBCHNO = value
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
Dim mSCD As String
Public Property _SCD As String
    Get
        Return mSCD
    End Get
    Set(ByVal value As String)
        mSCD = value
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
Dim mNAME As String
Public Property _NAME As String
    Get
        Return mNAME
    End Get
    Set(ByVal value As String)
        mNAME = value
    End Set
End Property
Dim mTAXT As Decimal
Public Property _TAXT As Decimal
    Get
        Return mTAXT
    End Get
    Set(ByVal value As Decimal)
        mTAXT = value
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
Dim mDIST As Integer
Public Property _DIST As Integer
    Get
        Return mDIST
    End Get
    Set(ByVal value As Integer)
        mDIST = value
    End Set
End Property
#End Region
End Class

