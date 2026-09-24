Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "BUDNAR"
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
  StrSQL = "Select * from " & cFileName & " where FUND=" & Fund & " and SFUND=" & Sfund & _
   " and DEPT=" & Dept & " and OBJ=" & Obj & " and FUNC=" & Func & " and SFUNC=" & Sfunc & _
   " and SEQ=" & Seq
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
Public Function GetViewbyAcct(ByVal Fund As Integer, ByVal Sfund As Integer, ByVal Dept As Integer, _
 ByVal Obj As Integer, ByVal Func As Integer, ByVal Sfunc As Integer, ByVal NumRecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim WrkTop As String
  WrkTop = String.Empty

  If NumRecs > 0 Then
    WrkTop = "TOP " & NumRecs & " "
  End If
  StrSQL = "Select " & WrkTop & "* from " & cFileName & _
  " where FUND=" & Fund & " and SFUND=" & Sfund & " and DEPT=" & Dept & " and OBJ=" & Obj & _
  " and FUNC=" & Func & " and SFUNC=" & Sfunc & _
  " order by SEQ"
  Conn = MyDBConn.Open
  objCommand = New SqlCommand(StrSQL, Conn)

  'Fill the dataset with the data
  da = New SqlDataAdapter
  da.SelectCommand = objCommand
  da.Fill(ds, cFileName)
  objCommand = Nothing
  Conn.Close()
  Return ds
End Function
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
  Public Sub DeleteAcct(ByVal Fund As Integer, ByVal Sfund As Integer, ByVal Dept As Integer, _
 ByVal Obj As Integer, ByVal Func As Integer, ByVal Sfunc As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim Result As Integer

  RecordNotFound = False
  IsEOF = False
  StrSQL = "Delete from " & cFileName & " where FUND=" & Fund & " and SFUND=" & Sfund & _
   " and DEPT=" & Dept & " and OBJ=" & Obj & " and FUNC=" & Func & " and SFUNC=" & Sfunc
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

#Region "Properties: Set Fields"
Private Sub GetFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    _FUND = .Item("FUND")
    _SFUND = .Item("SFUND")
    _DEPT = .Item("DEPT")
    _OBJ = .Item("OBJ")
    _FUNC = .Item("FUNC")
    _SFUNC = .Item("SFUNC")
    _SEQ = .Item("SEQ")
    _NAR1 = .Item("NAR1")
    _NAR2 = .Item("NAR2")
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
    .Item("SEQ") = _SEQ
    .Item("NAR1") = _NAR1
    .Item("NAR2") = _NAR2
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
Dim mSEQ As Integer
Public Property _SEQ As Integer
    Get
        Return mSEQ
    End Get
    Set(ByVal value As Integer)
        mSEQ = value
    End Set
End Property
Dim mNAR1 As String
Public Property _NAR1 As String
    Get
        Return mNAR1
    End Get
    Set(ByVal value As String)
        mNAR1 = value
    End Set
End Property
Dim mNAR2 As String
Public Property _NAR2 As String
    Get
        Return mNAR2
    End Get
    Set(ByVal value As String)
        mNAR2 = value
    End Set
End Property
#End Region

End Class

