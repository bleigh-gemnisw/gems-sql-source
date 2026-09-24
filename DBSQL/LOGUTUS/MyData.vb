Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "LOGUTUS"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_CUACCT = 0
_CUTYPE = string.empty
_CUUPMT = string.empty
_CUUNIT = 0
_CUEDU = 0
_CUSFIX = 0
_CUXTRA = 0
_CUWFIX = 0
_CUSCHR = 0
_LOGCMT = string.empty
_LOGDTE = 0
_LOGTIM = 0

End Sub
  Public Sub GetOneRecordP(ByVal WrkListNo As Integer, ByVal WrkType As String, ByVal WrkLogdte As Integer, ByVal WrkLogTim As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where cuacct=" & WrkListNo & " and cutype='" & WrkType & "'" &
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
  Public Function GetAllList(ByVal WrkListNo As Integer, ByVal WrkType As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where cuacct=" & WrkListNo & " and cutype='" & WrkType & "'"
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
    _CUACCT = .Item("CUACCT")
    _CUTYPE = .Item("CUTYPE")
    _CUUPMT = .Item("CUUPMT")
    _CUUNIT = .Item("CUUNIT")
    _CUEDU = .Item("CUEDU")
    _CUSFIX = .Item("CUSFIX")
    _CUXTRA = .Item("CUXTRA")
    _CUWFIX = .Item("CUWFIX")
    _CUSCHR = .Item("CUSCHR")
    _LOGCMT = .Item("LOGCMT")
    _LOGDTE = .Item("LOGDTE")
    _LOGTIM = .Item("LOGTIM")
  End With
End Sub
Public Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("CUACCT") = _CUACCT
    .Item("CUTYPE") = _CUTYPE
    .Item("CUUPMT") = _CUUPMT
    .Item("CUUNIT") = _CUUNIT
    .Item("CUEDU") = _CUEDU
    .Item("CUSFIX") = _CUSFIX
    .Item("CUXTRA") = _CUXTRA
    .Item("CUWFIX") = _CUWFIX
    .Item("CUSCHR") = _CUSCHR
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
Dim mCUACCT As Integer
Public Property _CUACCT As Integer
    Get
        Return mCUACCT
    End Get
    Set(ByVal value As Integer)
        mCUACCT = value
    End Set
End Property

Dim mCUTYPE As String
Public Property _CUTYPE As String
    Get
        Return mCUTYPE
    End Get
    Set(ByVal value As String)
        mCUTYPE = value
    End Set
End Property

Dim mCUUPMT As String
Public Property _CUUPMT As String
    Get
        Return mCUUPMT
    End Get
    Set(ByVal value As String)
        mCUUPMT = value
    End Set
End Property

Dim mCUUNIT As Decimal
Public Property _CUUNIT As Decimal
    Get
        Return mCUUNIT
    End Get
    Set(ByVal value As Decimal)
        mCUUNIT = value
    End Set
End Property

Dim mCUEDU As Integer
Public Property _CUEDU As Integer
    Get
        Return mCUEDU
    End Get
    Set(ByVal value As Integer)
        mCUEDU = value
    End Set
End Property

Dim mCUSFIX As Integer
Public Property _CUSFIX As Integer
    Get
        Return mCUSFIX
    End Get
    Set(ByVal value As Integer)
        mCUSFIX = value
    End Set
End Property

Dim mCUXTRA As Integer
Public Property _CUXTRA As Integer
    Get
        Return mCUXTRA
    End Get
    Set(ByVal value As Integer)
        mCUXTRA = value
    End Set
End Property

Dim mCUWFIX As Integer
Public Property _CUWFIX As Integer
    Get
        Return mCUWFIX
    End Get
    Set(ByVal value As Integer)
        mCUWFIX = value
    End Set
End Property

Dim mCUSCHR As Decimal
Public Property _CUSCHR As Decimal
    Get
        Return mCUSCHR
    End Get
    Set(ByVal value As Decimal)
        mCUSCHR = value
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

