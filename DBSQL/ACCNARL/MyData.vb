Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "ACCNARL"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub GetOneRecordP(ByVal Fund As Integer, ByVal Sfund As Integer, ByVal Dept As Integer, _
 ByVal Obj As Integer, ByVal Func As Integer, ByVal Sfunc As Integer, ByVal Seq As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where fund=" & Fund & " and sfund=" & Sfund & _
     " and dept=" & Dept & " and obj=" & Obj & " and func=" & Func & " and sfunc=" & Sfunc & _
     " and seq=" & Seq
  Try
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    If ds.Tables(0).Rows.Count = 0 Then
      RecordNotFound = True
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
Public Sub GetViewAcct(ByVal Fund As Integer, ByVal Sfund As Integer, ByVal Dept As Integer, _
 ByVal Obj As Integer, ByVal Func As Integer, ByVal Sfunc As Integer, ByVal NumRecs As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

    RecordNotFound = False
    If NumRecs > 0 Then
      StrSQL = "Select top " & NumRecs
    Else
      StrSQL = "Select "
    End If
    StrSQL = StrSQL & " * from " & cFileName & " where fund=" & Fund & " and sfund=" & Sfund & _
     " and dept=" & Dept & " and obj=" & Obj & " and func=" & Func & " and sfunc=" & Sfunc
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)

    If ds.Tables(0).Rows.Count = 0 Then
      RecordNotFound = True
    End If

    GetFields(ds)
    objCommand = Nothing
    ds.Clear()
    ds = Nothing
    Conn.Close()
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

#Region "Properties: Set Fields"

Private Sub GetFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    _FUND = .Item("FUND")
    _SFUND = .Item("SFUND")
    _DEPT = .Item("DEPT")
    _OBJ = .Item("OBJ")
    _FUNC = .Item("FUNC")
    _SFUNC = .Item("SFUNC")
    _SEQ4 = .Item("SEQ4")
    _NARR = .Item("NARR")
  End With
End Sub

Private Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("FUND") = _FUND
    .Item("SFUND") = _SFUND
    .Item("DEPT") = _DEPT
    .Item("OBJ") = _OBJ
    .Item("FUNC") = _FUNC
    .Item("SFUNC") = _SFUNC
    .Item("SEQ4") = _SEQ4
    .Item("NARR") = _NARR
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
Public Property IsEOF As Boolean
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
Dim mFUND As Integer
Public Property _FUND As Integer
    Get
        Return mFUND
    End Get
    Set(ByVal value As Integer)
        mFUND = value
    End Set
End Property
Dim mSFUND As Integer
Public Property _SFUND As Integer
    Get
        Return mSFUND
    End Get
    Set(ByVal value As Integer)
        mSFUND = value
    End Set
End Property
Dim mDEPT As Integer
Public Property _DEPT As Integer
    Get
        Return mDEPT
    End Get
    Set(ByVal value As Integer)
        mDEPT = value
    End Set
End Property
Dim mOBJ As Integer
Public Property _OBJ As Integer
    Get
        Return mOBJ
    End Get
    Set(ByVal value As Integer)
        mOBJ = value
    End Set
End Property
Dim mFUNC As Integer
Public Property _FUNC As Integer
    Get
        Return mFUNC
    End Get
    Set(ByVal value As Integer)
        mFUNC = value
    End Set
End Property
Dim mSFUNC As Integer
Public Property _SFUNC As Integer
    Get
        Return mSFUNC
    End Get
    Set(ByVal value As Integer)
        mSFUNC = value
    End Set
End Property
Dim mSEQ4 As Integer
Public Property _SEQ4 As Integer
    Get
        Return mSEQ4
    End Get
    Set(ByVal value As Integer)
        mSEQ4 = value
    End Set
End Property
Dim mNARR As String
Public Property _NARR As String
    Get
        Return mNARR
    End Get
    Set(ByVal value As String)
        mNARR = value
    End Set
End Property
#End Region
End Class

