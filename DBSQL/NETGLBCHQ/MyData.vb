Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Const cFileName As String = "NETGLBCH"
#Region "Constructors"

  Public Sub New()
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
    _STAT = .Item("STAT")
    _BATCH = .Item("BATCH")
    _SEQNO = .Item("SEQNO")
    _LIST = .Item("LIST")
    _YEAR = .Item("YEAR")
    _TYPE = .Item("TYPE")
    _PAMT = .Item("PAMT")
    _IAMT = .Item("IAMT")
    _LAMT = .Item("LAMT")
    _PCAMT = .Item("PCAMT")
    _DIST = .Item("DIST")
    _ADJCD = .Item("ADJCD")
    _PENCD = .Item("PENCD")
    _PSTDT = .Item("PSTDT")
    _PAYDT = .Item("PAYDT")
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
Dim mSTAT As String
Public Property _STAT As String
    Get
        Return mSTAT
    End Get
    Set(ByVal value As String)
        mSTAT = value
    End Set
End Property
Dim mBATCH As Integer
Public Property _BATCH As Integer
    Get
        Return mBATCH
    End Get
    Set(ByVal value As Integer)
        mBATCH = value
    End Set
End Property
Dim mSEQNO As Integer
Public Property _SEQNO As Integer
    Get
        Return mSEQNO
    End Get
    Set(ByVal value As Integer)
        mSEQNO = value
    End Set
End Property
Dim mLIST As Integer
Public Property _LIST As Integer
    Get
        Return mLIST
    End Get
    Set(ByVal value As Integer)
        mLIST = value
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
Dim mPCAMT As Decimal
Public Property _PCAMT As Decimal
    Get
        Return mPCAMT
    End Get
    Set(ByVal value As Decimal)
        mPCAMT = value
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
Dim mADJCD As String
Public Property _ADJCD As String
    Get
        Return mADJCD
    End Get
    Set(ByVal value As String)
        mADJCD = value
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
Dim mPSTDT As Integer
Public Property _PSTDT As Integer
    Get
        Return mPSTDT
    End Get
    Set(ByVal value As Integer)
        mPSTDT = value
    End Set
End Property
Dim mPAYDT As Integer
Public Property _PAYDT As Integer
    Get
        Return mPAYDT
    End Get
    Set(ByVal value As Integer)
        mPAYDT = value
    End Set
End Property
#End Region

End Class

