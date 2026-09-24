Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "PURCTL"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub GetOneRecordP(ByVal Fscyr As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where FSCYR=" & Fscyr
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
Public Function PosData(ByVal Fscyr As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  StrSQL = "Select * from " & cFileName & " where FSCYR>=" & Fscyr & " order by fscyr"
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
  Public Function GetViewbyYear(ByVal WrkFscyr As Integer, ByVal NumRecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim WrkTop As String
  WrkTop = String.Empty

  RecordNotFound = False
  If NumRecs > 0 Then
    WrkTop = "TOP " & NumRecs & " "
  End If
  StrSQL = "Select " & WrkTop & "* from " & cFileName _
    & " where fscyr>=" & WrkFscyr & " order by fscyr"
  Try
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    ds2 = ReplaceDS(ds)
    ds = Nothing
    objCommand = Nothing
    Return ds2
  Catch ex As Exception
    ErrMsg = ex.ToString()
    Return Nothing
  End Try
End Function
Public Function ReplaceDS(ByVal ds As DataSet) As DataSet
    Dim ds2 As DataSet = New DataSet
    Dim dr As DataRow
    Dim myTable As New DataTable
    Dim I As Integer
    With myTable
      .TableName = "mytable" 'ds.Tables(0).TableName
      .Columns.Add("fscyr", Type.GetType("System.Int16"))
      .Columns.Add("strdt", Type.GetType("System.Int32"))
      .Columns.Add("enddt", Type.GetType("System.Int32"))
      .Columns.Add("nxtpo", Type.GetType("System.Int32"))
      .Columns.Add("dyord", Type.GetType("System.Int16"))
    End With
    ds2.Tables.Add(myTable)

  For I = 0 To ds.Tables(0).Rows.Count - 1
    With ds.Tables(0).Rows(I)
      dr = ds2.Tables(0).NewRow
      dr.Item("fscyr") = .Item("fscyr")
      dr.Item("strdt") = GetDBDateInt(.Item("fscs8"))
      dr.Item("enddt") = GetDBDateInt(.Item("fsce8"))
      dr.Item("nxtpo") = .Item("nxtpo")
      dr.Item("dyord") = .Item("dyord")
      ds2.Tables(0).Rows.Add(dr)
    End With
  Next

    Return ds2
End Function
Public Function GetDBDateInt(ByVal DateIn As Integer) As Integer
  Dim WrkDate As Integer
  Dim StrDate As String

  If DateIn > 0 Then
    StrDate = Trim$(Str(DateIn))
    Try
      WrkDate = Right$(StrDate, 4) & Left$(StrDate, 4)
    Catch
    End Try
  End If
  Return WrkDate
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
    _FSCSD = .Item("FSCSD")
    _FSCED = .Item("FSCED")
    _FSCYR = .Item("FSCYR")
    _NXTPO = .Item("NXTPO")
    _DYORD = .Item("DYORD")
    _FSCS8 = .Item("FSCS8")
    _FSCE8 = .Item("FSCE8")
    End With
End Sub
Private Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("FSCSD") = _FSCSD
    .Item("FSCED") = _FSCED
    .Item("FSCYR") = _FSCYR
    .Item("NXTPO") = _NXTPO
    .Item("DYORD") = _DYORD
    .Item("FSCS8") = _FSCS8
    .Item("FSCE8") = _FSCE8
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
Dim mFSCSD As Integer
Public Property _FSCSD As Integer
    Get
        Return mFSCSD
    End Get
    Set(ByVal value As Integer)
        mFSCSD = value
    End Set
End Property

Dim mFSCED As Integer
Public Property _FSCED As Integer
    Get
        Return mFSCED
    End Get
    Set(ByVal value As Integer)
        mFSCED = value
    End Set
End Property

Dim mFSCYR As Integer
Public Property _FSCYR As Integer
    Get
        Return mFSCYR
    End Get
    Set(ByVal value As Integer)
        mFSCYR = value
    End Set
End Property

Dim mNXTPO As Integer
Public Property _NXTPO As Integer
    Get
        Return mNXTPO
    End Get
    Set(ByVal value As Integer)
        mNXTPO = value
    End Set
End Property

Dim mDYORD As Integer
Public Property _DYORD As Integer
    Get
        Return mDYORD
    End Get
    Set(ByVal value As Integer)
        mDYORD = value
    End Set
End Property

Dim mFSCS8 As Integer
Public Property _FSCS8 As Integer
    Get
        Return mFSCS8
    End Get
    Set(ByVal value As Integer)
        mFSCS8 = value
    End Set
End Property

Dim mFSCE8 As Integer
Public Property _FSCE8 As Integer
    Get
        Return mFSCE8
    End Get
    Set(ByVal value As Integer)
        mFSCE8 = value
    End Set
End Property

#End Region
End Class

