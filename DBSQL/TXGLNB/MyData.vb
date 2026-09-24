Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim ConnRdr As SqlConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objreader As SqlDataReader
  Const cFileName As String = "TXGLNB"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _TXYR = 0
    _TRTY = String.Empty
    _CODE = String.Empty
    _DESCR = String.Empty
    _ACCTCR = String.Empty
    _ACCTDB = String.Empty
    _ACCTCR2 = String.Empty
    _ACCTDB2 = String.Empty
  End Sub
  Public Sub GetOneRecordP(ByVal Txyr As Integer, ByVal Tran As String, ByVal Code As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where TXYR=" & Txyr & " and TRTY='" & Tran &
  "' and CODE='" & Code & "'"
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
  Public Function PosData(ByVal Txyr As Integer, ByVal Tran As String, ByVal Code As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where TXYR=" & Txyr & " and TRTY='" & Tran &
  "' and CODE>='" & Code & "' or " &
  "TXYR=" & Txyr & " and TRTY>'" & Tran & "' or " &
  "TXYR>" & Txyr & " order by txyr, trty, code"
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
  Public Sub SetRange(ByVal WrkYear As Integer)
    Dim objCommand As SqlCommand

    RecordNotFound = False
    IsEOF = False
    StrSQL = "Select * from " & cFileName & " where txyr=" & WrkYear
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
  Public Sub CloseRange()
    IsEOF = True
    objreader.Close()
    ConnRdr.Close()
  End Sub
#End Region

#Region "Properties: Set Fields"
  Private Sub GetFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      _TXYR = .Item("TXYR")
      _TRTY = .Item("TRTY")
      _CODE = .Item("CODE")
      _DESCR = .Item("DESCR")
      _ACCTCR = .Item("ACCTCR")
      _ACCTDB = .Item("ACCTDB")
      _ACCTCR2 = .Item("ACCTCR2")
      _ACCTDB2 = .Item("ACCTDB2")
    End With
  End Sub
  Public Sub GetFieldsRdr()
    With objreader
      _TXYR = .Item("TXYR")
      _TRTY = .Item("TRTY")
      _CODE = .Item("CODE")
      _DESCR = .Item("DESCR")
      _ACCTCR = .Item("ACCTCR")
      _ACCTDB = .Item("ACCTDB")
      _ACCTCR2 = .Item("ACCTCR2")
      _ACCTDB2 = .Item("ACCTDB2")
    End With
  End Sub
  Private Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("TXYR") = _TXYR
      .Item("TRTY") = _TRTY
      .Item("CODE") = _CODE
      .Item("DESCR") = _DESCR
      .Item("ACCTCR") = _ACCTCR
      .Item("ACCTDB") = _ACCTDB
      .Item("ACCTCR2") = _ACCTCR2
      .Item("ACCTDB2") = _ACCTDB2
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
  Dim mTXYR As Integer
  Public Property _TXYR As Integer
    Get
      Return mTXYR
    End Get
    Set(ByVal value As Integer)
      mTXYR = value
    End Set
  End Property
  Dim mTRTY As String
  Public Property _TRTY As String
    Get
      Return mTRTY
    End Get
    Set(ByVal value As String)
      mTRTY = value
    End Set
  End Property
  Dim mCODE As String
  Public Property _CODE As String
    Get
      Return mCODE
    End Get
    Set(ByVal value As String)
      mCODE = value
    End Set
  End Property
  Dim mDESCR As String
  Public Property _DESCR As String
    Get
      Return mDESCR
    End Get
    Set(ByVal value As String)
      mDESCR = value
    End Set
  End Property
  Dim mACCTCR As String
  Public Property _ACCTCR As String
    Get
      Return mACCTCR
    End Get
    Set(ByVal value As String)
      mACCTCR = value
    End Set
  End Property
  Dim mACCTDB As String
  Public Property _ACCTDB As String
    Get
      Return mACCTDB
    End Get
    Set(ByVal value As String)
      mACCTDB = value
    End Set
  End Property
  Dim mACCTCR2 As String
  Public Property _ACCTCR2 As String
    Get
      Return mACCTCR2
    End Get
    Set(ByVal value As String)
      mACCTCR2 = value
    End Set
  End Property
  Dim mACCTDB2 As String
  Public Property _ACCTDB2 As String
    Get
      Return mACCTDB2
    End Get
    Set(ByVal value As String)
      mACCTDB2 = value
    End Set
  End Property
#End Region
End Class

