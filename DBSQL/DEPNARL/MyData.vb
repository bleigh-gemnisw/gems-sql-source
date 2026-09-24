Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "DEPNARL"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub GetOneRecordP(ByVal Dept As Integer, ByVal Seq4 As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where DEPT=" & Dept & " and SEQ4=" & Seq4
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
Public Function GetViewbyDept(ByVal Dept As Integer, ByVal NumRecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim WrkTop As String
  WrkTop = String.Empty

  If NumRecs > 0 Then
    WrkTop = "TOP " & NumRecs & " "
  End If
  StrSQL = "Select " & WrkTop & "* from " & cFileName & _
  " where DEPT=" & Dept & " order by SEQ4"
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
Public Function PosData(ByVal Dept As Integer, ByVal Seq4 As Integer, ByVal Numrecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  Dim WrkTop As String
  WrkTop = String.Empty

  If Numrecs > 0 Then
    WrkTop = "TOP " & Numrecs & " "
  End If
  StrSQL = "Select * from " & cFileName & " where DEPT=" & Dept & " and seq4>=" & Seq4 & _
   " or DEPT>=" & Dept & _
   " order by dept, seq4"
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
  Public Sub DeleteDept(ByVal WrkDept As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim Result As Integer

  RecordNotFound = False
  IsEOF = False
  StrSQL = "Delete from " & cFileName & " where dept=" & WrkDept
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
    _DEPT = .Item("DEPT")
    _SEQ4 = .Item("SEQ4")
    _NARR = .Item("NARR")
  End With
End Sub
Private Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("DEPT") = _DEPT
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
Dim mDEPT As Integer
Public Property _DEPT As Integer
    Get
        Return mDEPT
    End Get
    Set(ByVal value As Integer)
        mDEPT = value
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

