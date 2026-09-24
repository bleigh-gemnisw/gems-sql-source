Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "LOGUTRT"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_CRACCT = 0
_CRTYPE = string.empty
_CRCODE = string.empty
_LOGCMT = string.empty
_LOGDTE = 0
_LOGTIM = 0

End Sub
  Public Sub GetOneRecordP(ByVal WrkListNo As Integer, WrkLogdte As Integer, WrkLogTim As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where list#=" & WrkListNo & _
   " and logdte=" & WrkLogdte & " and logtim=" & WrkLogTim
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
  Public Function GetAllList(ByVal WrkListNo As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where list#=" & WrkListNo
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
  Public Function PosData(ByVal WrkListNo As Integer, ByVal WrkLogdte As Integer, ByVal WrkLogTim As Integer,
   ByVal NumRecs As Long) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    RecordNotFound = False
    StrSQL = "Select " & WrkTop & " * from " & cFileName & " where cuacct=" & WrkListNo &
   " and logdte=" & WrkLogdte & " and logtim>=" & WrkLogTim &
   " or cuacct=" & WrkListNo & "and logdte>" & WrkLogdte &
   " or cuacct>" & WrkListNo
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

#Region "Properties: Get/Put"
Public Sub GetFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    _CRACCT = .Item("CRACCT")
    _CRTYPE = .Item("CRTYPE")
    _CRCODE = .Item("CRCODE")
    _LOGCMT = .Item("LOGCMT")
    _LOGDTE = .Item("LOGDTE")
    _LOGTIM = .Item("LOGTIM")
  End With
End Sub
Public Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("CRACCT") = _CRACCT
    .Item("CRTYPE") = _CRTYPE
    .Item("CRCODE") = _CRCODE
    .Item("LOGCMT") = _LOGCMT
    .Item("LOGDTE") = _LOGDTE
    .Item("LOGTIM") = _LOGTIM
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
Dim mCRACCT As Integer
Public Property _CRACCT As Integer
    Get
        Return mCRACCT
    End Get
    Set(ByVal value As Integer)
        mCRACCT = value
    End Set
End Property

Dim mCRTYPE As String
Public Property _CRTYPE As String
    Get
        Return mCRTYPE
    End Get
    Set(ByVal value As String)
        mCRTYPE = value
    End Set
End Property

Dim mCRCODE As String
Public Property _CRCODE As String
    Get
        Return mCRCODE
    End Get
    Set(ByVal value As String)
        mCRCODE = value
    End Set
End Property
Dim mLOGCMT As String
Public Property _LOGCMT As String
    Get
        Return mLOGCMT
    End Get
    Set(ByVal value As String)
        mLOGCMT = value
    End Set
End Property
Dim mLOGDTE As Integer
Public Property _LOGDTE As Integer
    Get
        Return mLOGDTE
    End Get
    Set(ByVal value As Integer)
        mLOGDTE = value
    End Set
End Property
Dim mLOGTIM As Integer
Public Property _LOGTIM As Integer
    Get
        Return mLOGTIM
    End Get
    Set(ByVal value As Integer)
        mLOGTIM = value
    End Set
End Property
#End Region
End Class

