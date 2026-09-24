Imports System.Data
Imports System.Data.SqlClient
Public Class TXTYPE
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Dim Conn As SqlConnection
  Const cFilename As String = "TXTYPE"
#Region "Constructors"

  Public Sub New(ByVal WrkConn As SqlConnection)
    Conn = WrkConn
  End Sub
#End Region
#Region "Methods: File Access Routines"
  Public Sub GetOneRecordP(ByVal WrkType As String)
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFilename & " where tycode='" & WrkType & "'"
    Try
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFilename)
      If ds.Tables(0).Rows.Count = 0 Then
        RecordNotFound = True
      Else
        GetFields(ds)
      End If
      objCommand = Nothing
      ds.Clear()
      ds = Nothing
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
    da.Fill(ds, cFilename)
    dr = ds.Tables(0).NewRow
    ds.Tables(0).Rows.Add(dr)
    PutFields(ds)
    da.Update(ds, cFilename)
    ds = Nothing
  End Sub
  Public Sub DeleteOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet

    da.DeleteCommand = CmdBldr.GetDeleteCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, cFilename)
    ds.Tables(0).Rows(0).Delete()
    da.Update(ds, cFilename)
    ds = Nothing
  End Sub
  Public Sub UpdateOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet
    da.UpdateCommand = CmdBldr.GetUpdateCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, cFilename)
    PutFields(ds)
    da.Update(ds, cFilename)
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
      _TYCODE = .Item("TYCODE")
      _TYDESC = .Item("TYDESC")
      _TXREV = .Item("TXREV")
      _TXFAM = .Item("TXFAM")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("TYCODE") = _TYCODE
      .Item("TYDESC") = _TYDESC
      .Item("TXREV") = _TXREV
      .Item("TXFAM") = _TXFAM
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
  Dim mTYCODE As String
  Public Property _TYCODE As String
    Get
      Return mTYCODE
    End Get
    Set(ByVal value As String)
      mTYCODE = value
    End Set
  End Property
  Dim mTYDESC As String
  Public Property _TYDESC As String
    Get
      Return mTYDESC
    End Get
    Set(ByVal value As String)
      mTYDESC = value
    End Set
  End Property
  Dim mTXREV As String
  Public Property _TXREV As String
    Get
      Return mTXREV
    End Get
    Set(ByVal value As String)
      mTXREV = value
    End Set
  End Property
  Dim mTXFAM As String
  Public Property _TXFAM As String
    Get
      Return mTXFAM
    End Get
    Set(ByVal value As String)
      mTXFAM = value
    End Set
  End Property
#End Region

End Class
