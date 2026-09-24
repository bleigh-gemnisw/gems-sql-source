Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim ConnRdr As SqlConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objreader As SqlDataReader
  Const cFileName As String = "BDCOM"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _RECID = 0
    _SEQNO = 0
    _CMNT = String.Empty
  End Sub
  Public Function Getcomments(ByVal WrkRecid As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim ds As DataSet = New DataSet
    Dim objCommand As SqlCommand

    StrSQL = "Select * from " & cFileName & " where recid=" & WrkRecid
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
  Public Sub GetOneRecordP(ByVal WrkRecid As Integer, ByVal Seqno As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where recid=" & WrkRecid & " and seqno=" & Seqno
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      If ds.Tables(0).Rows.Count = 0 Then
        RecordNotFound = True
        ClearFields()
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
  Public Sub DeleteKeyComment(ByVal WrkRecid As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    StrSQL = "Delete From " & cFileName & " where recid=" & WrkRecid
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    objCommand.ExecuteNonQuery()
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
  Public Sub RunUpdateQuery(ByVal Wrkset As String, ByVal wrkwhere As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    StrSQL = "Update " & cFileName & " " & Wrkset & " " & wrkwhere

    RecordNotFound = False
    IsEOF = False
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    Result = objCommand.ExecuteNonQuery()
    objCommand = Nothing
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

#Region "Properties: Set Fields"
  Private Sub GetFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      _RECID = .Item("RECID")
      _SEQNO = .Item("SEQNO")
      _CMNT = .Item("CMNT")
    End With
  End Sub
  Private Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("RECID") = _RECID
      .Item("SEQNO") = _SEQNO
      .Item("CMNT") = _CMNT
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
  Dim mRECID As Integer
  Public Property _RECID As Integer
    Get
      Return mRECID
    End Get
    Set(ByVal value As Integer)
      mRECID = value
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

  Dim mCMNT As String
  Public Property _CMNT As String
    Get
      Return mCMNT
    End Get
    Set(ByVal value As String)
      mCMNT = value
    End Set
  End Property
#End Region
End Class

