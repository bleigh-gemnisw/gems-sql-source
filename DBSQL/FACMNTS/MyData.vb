Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "FACMNTS"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Function Getcomments(ByVal TagNo As String) As DataSet
  Dim Conn As SqlConnection
  Dim ds As DataSet = New DataSet
  Dim objCommand As SqlCommand

  StrSQL = "Select * from " & cFileName & " where fatag='" & TagNo & "'"
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
  Public Sub GetOneRecordP(ByVal TagNo As String, ByVal Seqno As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where fatag='" & TagNo & "' and seqno=" & Seqno
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
  Public Sub DeleteKeyComment(ByVal TagNo As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    StrSQL = "Delete From " & cFileName & " where fatag=@TagNo"
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    objCommand.Parameters.Add(New SqlParameter("@TagNo", TagNo))
    objCommand.ExecuteNonQuery()
  End Sub
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
	End Sub
  Private Sub GetFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      _FATAG = .Item("FATAG")
      _SEQNO = .Item("SEQNO")
      _LINE = .Item("LINE")
    End With
  End Sub
  Private Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("FATAG") = _FATAG
      .Item("SEQNO") = _SEQNO
      .Item("LINE") = _LINE
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
  Dim mFATAG As String
  Public Property _FATAG As String
    Get
      Return mFATAG
    End Get
    Set(ByVal value As String)
      mFATAG = value
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
  Dim mLINE As String
  Public Property _LINE As String
    Get
      Return mLINE
    End Get
    Set(ByVal value As String)
      mLINE = value
    End Set
  End Property
#End Region
End Class

