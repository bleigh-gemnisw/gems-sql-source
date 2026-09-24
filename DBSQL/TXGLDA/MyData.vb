Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim ConnRdr As SqlConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objreader As SqlDataReader
  Const cFileName As String = "TXGLDA"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_TXYR = 0
_TRAN = string.empty
_CODE = string.empty
_DESC = string.empty
_ACCTCR = string.empty
_ACCTDB = string.empty
_ACARCR = string.empty
_ACARDB = string.empty

End Sub
Public Sub GetOneRecordP(ByVal Txyr As Integer, ByVal Tran As String, ByVal Code As String)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where TXYR=" & Txyr & " and [TRAN]='" & Tran & _
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
 ClearFields 
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

  StrSQL = "Select * from " & cFileName & " where TXYR=" & Txyr & " and [TRAN]='" & Tran & _
  "' and CODE>='" & Code & "' or " & _
  "TXYR=" & Txyr & " and [TRAN]>'" & Tran & "' or " & _
  "TXYR>" & Txyr & " order by txyr, [tran], code"
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
    _TRAN = .Item("TRAN")
    _CODE = .Item("CODE")
    _DESC = .Item("DESC")
    _ACCTCR = .Item("ACCTCR")
    _ACCTDB = .Item("ACCTDB")
    _ACARCR = .Item("ACARCR")
    _ACARDB = .Item("ACARDB")
  End With
End Sub
Public Sub GetFieldsRdr()
  With objreader
    _TXYR = .Item("TXYR")
    _TRAN = .Item("TRAN")
    _CODE = .Item("CODE")
    _DESC = .Item("DESC")
    _ACCTCR = .Item("ACCTCR")
    _ACCTDB = .Item("ACCTDB")
    _ACARCR = .Item("ACARCR")
    _ACARDB = .Item("ACARDB")
  End With
End Sub
Private Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("TXYR") = _TXYR
    .Item("TRAN") = _TRAN
    .Item("CODE") = _CODE
    .Item("DESC") = _DESC
    .Item("ACCTCR") = _ACCTCR
    .Item("ACCTDB") = _ACCTDB
    .Item("ACARCR") = _ACARCR
    .Item("ACARDB") = _ACARDB
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
Dim mTRAN As String
Public Property _TRAN As String
    Get
        Return mTRAN
    End Get
    Set(ByVal value As String)
        mTRAN = value
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
Dim mDESC As String
Public Property _DESC As String
    Get
        Return mDESC
    End Get
    Set(ByVal value As String)
        mDESC = value
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
Dim mACARCR As String
Public Property _ACARCR As String
    Get
        Return mACARCR
    End Get
    Set(ByVal value As String)
        mACARCR = value
    End Set
End Property
Dim mACARDB As String
Public Property _ACARDB As String
    Get
        Return mACARDB
    End Get
    Set(ByVal value As String)
        mACARDB = value
    End Set
End Property
#End Region
End Class

