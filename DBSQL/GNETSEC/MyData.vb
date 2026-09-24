Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim ConnRdr As SqlConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objreader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Const cFileName As String = "GNETSEC"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub GetOneRecordP(ByVal WrkGroup As String, ByVal WrkPgmID As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where grpid='" & WrkGroup & "'" &
   " and pgmid='" & WrkPgmID & "'"
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
  Public Sub SetRange(ByVal WrkGroup As String, ByVal WrkPgmID As String)
    Dim objCommand As SqlCommand

    RecordNotFound = False
    IsEOF = False
    StrSQL = "Select * from " & cFileName & " where grpid='" & WrkGroup & "'" &
    " and pgmid>='" & WrkPgmID & "' order by pgmid"
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
  Public Function PosData(ByVal WrkGroup As String, ByVal WrkPgmID As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where grpid='" & WrkGroup & "'" &
    " and pgmid>='" & WrkPgmID & "' or grpid>'" & WrkGroup & "' order by pgmid"
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
  Public Sub DeleteRange(ByVal WrkGroup As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    RecordNotFound = False
    IsEOF = False
    StrSQL = "Delete from " & cFileName & " where grpid='" & WrkGroup & "'"
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
  Public Sub CloseRange()
    IsEOF = True
    objreader.Close()
    ConnRdr.Close()
  End Sub
#End Region

#Region "Properties: Get/Put"
  Public Sub GetFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      _GRPID = .Item("GRPID")
      _PGMID = .Item("PGMID")
      _PGMTYP = .Item("PGMTYP")
      _RIGHTS = .Item("RIGHTS")
    End With
  End Sub
  Public Sub GetFieldsRdr()
    With objreader
      _GRPID = .Item("GRPID")
      _PGMID = .Item("PGMID")
      _PGMTYP = .Item("PGMTYP")
      _RIGHTS = .Item("RIGHTS")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("GRPID") = _GRPID
      .Item("PGMID") = _PGMID
      .Item("PGMTYP") = _PGMTYP
      .Item("RIGHTS") = _RIGHTS
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
  Dim mGRPID As String
  Public Property _GRPID As String
    Get
      Return mGRPID
    End Get
    Set(ByVal value As String)
      mGRPID = value
    End Set
  End Property
  Dim mPGMID As String
  Public Property _PGMID As String
    Get
      Return mPGMID
    End Get
    Set(ByVal value As String)
      mPGMID = value
    End Set
  End Property
  Dim mPGMTYP As String
  Public Property _PGMTYP As String
    Get
      Return mPGMTYP
    End Get
    Set(ByVal value As String)
      mPGMTYP = value
    End Set
  End Property
  Dim mRIGHTS As String
  Public Property _RIGHTS As String
    Get
      Return mRIGHTS
    End Get
    Set(ByVal value As String)
      mRIGHTS = value
    End Set
  End Property
#End Region
End Class

