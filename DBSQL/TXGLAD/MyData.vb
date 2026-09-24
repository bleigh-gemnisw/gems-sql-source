Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim ConnRdr As SqlConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objreader As SqlDataReader
  Const cFileName As String = "TXGLAD"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _TXYR = 0
    _TXTYP = String.Empty
    _TXCD = String.Empty
    _ADYR = 0
    _ADCD = String.Empty

  End Sub
  Public Sub GetOneRecordP(ByVal Year As Integer, ByVal Type As String, ByVal Code As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where TXYR=" & Year & " and TXTYP='" & Type &
  "' and TXCD='" & Code & "'"
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
  Public Function PosData(ByVal Year As Integer, ByVal Type As String, ByVal Code As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where TXYR=" & Year & " and TXTYP='" & Type &
  "' and TXCD='" & Code & "' or " &
  "TXYR=" & Year & " and TXTYP='" & Type & "' and TXCD>='" & Code & "' or " &
  "TXYR=" & Year & " and TXTYP>='" & Type & "' or " &
  "TXYR>=" & Year & " order by txyr,txtyp,txcd"
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
      _TXTYP = .Item("TXTYP")
      _TXCD = .Item("TXCD")
      _ADYR = .Item("ADYR")
      _ADCD = .Item("ADCD")
    End With
  End Sub
  Public Sub GetFieldsRdr()
    With objreader
      _TXYR = .Item("TXYR")
      _TXTYP = .Item("TXTYP")
      _TXCD = .Item("TXCD")
      _ADYR = .Item("ADYR")
      _ADCD = .Item("ADCD")
    End With
  End Sub
  Private Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("TXYR") = _TXYR
      .Item("TXTYP") = _TXTYP
      .Item("TXCD") = _TXCD
      .Item("ADYR") = _ADYR
      .Item("ADCD") = _ADCD
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
  Dim mTXTYP As String
  Public Property _TXTYP As String
    Get
      Return mTXTYP
    End Get
    Set(ByVal value As String)
      mTXTYP = value
    End Set
  End Property
  Dim mTXCD As String
  Public Property _TXCD As String
    Get
      Return mTXCD
    End Get
    Set(ByVal value As String)
      mTXCD = value
    End Set
  End Property
  Dim mADYR As Integer
  Public Property _ADYR As Integer
    Get
      Return mADYR
    End Get
    Set(ByVal value As Integer)
      mADYR = value
    End Set
  End Property
  Dim mADCD As String
  Public Property _ADCD As String
    Get
      Return mADCD
    End Get
    Set(ByVal value As String)
      mADCD = value
    End Set
  End Property
#End Region
End Class

