Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TSPBCH"

#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region
#Region "Methods: File Access Routines"
Public Sub ClearFields
_BCHNO = 0
_LISTNo = 0
_YEAR = 0
_TYPE = string.empty
_SCD = string.empty
_COMM = string.empty
_NAME = string.empty
_TAXT = 0
_PDATE = 0
_DIST = 0

End Sub
  Public Sub GetOneRecordP(ByVal WrkBchno As Integer, ByVal WrkListNo As Integer, _
 ByVal WrkYear As Integer, ByVal WrkType As String)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where bchno=" & WrkBchno & _
   " and list#=" & WrkListNo & " and year=" & WrkYear & " and type='" & WrkType & "'"
  Try
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    If ds.Tables(0).Rows.Count = 0 Then
      RecordNotFound = True
 ClearFields 
    Else
      GetFields(ds)
    End If
    objCommand = Nothing
    ds.Clear()
    ds = Nothing
    Conn.Close()
  Catch ex As Exception
    ErrMsg = ex.ToString()
  End Try
End Sub
  Public Sub AddOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet
    Dim dr As DataRow

    da.InsertCommand = CmdBldr.GetInsertCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, cFileName)
    dr = ds.Tables(0).NewRow
    ds.Tables(0).Rows.Add(dr)
    PutFields(ds)
    da.Update(ds, cFileName)
    ds = Nothing
  End Sub
  Public Sub DeleteOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet

    da.DeleteCommand = CmdBldr.GetDeleteCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, cFileName)
    ds.Tables(0).Rows(0).Delete()
    da.Update(ds, cFileName)
    ds = Nothing
  End Sub
  Public Sub DeleteBatch(ByVal WrkBchno As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim Result As Integer

  RecordNotFound = False
  IsEOF = False
  StrSQL = "Delete from " & cFileName & " where bchno=" & WrkBchno
  Conn = MyDBConn.Open
  objCommand = New SqlCommand(StrSQL, Conn)
  Result = objCommand.ExecuteNonQuery()
  objCommand = Nothing
End Sub
  Public Sub UpdateOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet
    da.UpdateCommand = CmdBldr.GetUpdateCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, cFileName)
    PutFields(ds)
    da.Update(ds, cFileName)
    ds = Nothing
  End Sub
  Public Sub OpenFile()
  End Sub
	Public Sub CloseFile()
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
Public Sub PutFields(ByVal ds As DataSet)
	With ds.Tables(0).Rows(0)
    .Item("BCHNO") = _BCHNO
    .Item("LIST#") = _LISTNo
    .Item("YEAR") = _YEAR
    .Item("TYPE") = _TYPE
    .Item("SCD") = _SCD
    .Item("COMM") = _COMM
    .Item("NAME") = _NAME
    .Item("TAXT") = _TAXT
    .Item("PDATE") = _PDATE
    .Item("DIST") = _DIST
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

