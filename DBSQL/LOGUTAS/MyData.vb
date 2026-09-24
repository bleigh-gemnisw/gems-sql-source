Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "LOGUTAS"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub


#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_CAACCT = 0
_CATYPE = string.empty
_CAADJ = 0
_CADEF = 0
_CADEP = 0
_CAAMT = 0
_CAPNO = 0
_CAOVR = 0
_CALAT = 0
_CAUNIF = 0
_CUAPMT = string.empty
_CUAUNT = 0
_CUPVAL = 0
_CUFOOT = 0
_CUACRE = 0
_LOGCMT = string.empty
_LOGDTE = 0
_LOGTIM = 0

End Sub
  Public Sub GetOneRecordP(ByVal WrkListNo As Integer, ByVal WrkType As String, ByVal WrkLogdte As Integer, ByVal WrkLogTim As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where caacct=" & WrkListNo & " and catype='" & WrkType & "'" &
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

    StrSQL = "Select * from " & cFileName & " where caacct=" & WrkListNo & " and catype='" & WrkType & "'"
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
    _CAACCT = .Item("CAACCT")
    _CATYPE = .Item("CATYPE")
    _CAADJ = .Item("CAADJ")
    _CADEF = .Item("CADEF")
    _CADEP = .Item("CADEP")
    _CAAMT = .Item("CAAMT")
    _CAPNO = .Item("CAPNO")
    _CAOVR = .Item("CAOVR")
    _CALAT = .Item("CALAT")
    _CAUNIF = .Item("CAUNIF")
    _CUAPMT = .Item("CUAPMT")
    _CUAUNT = .Item("CUAUNT")
    _CUPVAL = .Item("CUPVAL")
    _CUFOOT = .Item("CUFOOT")
    _CUACRE = .Item("CUACRE")
    _LOGCMT = .Item("LOGCMT")
    _LOGDTE = .Item("LOGDTE")
    _LOGTIM = .Item("LOGTIM")
  End With
End Sub
Public Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("CAACCT") = _CAACCT
    .Item("CATYPE") = _CATYPE
    .Item("CAADJ") = _CAADJ
    .Item("CADEF") = _CADEF
    .Item("CADEP") = _CADEP
    .Item("CAAMT") = _CAAMT
    .Item("CAPNO") = _CAPNO
    .Item("CAOVR") = _CAOVR
    .Item("CALAT") = _CALAT
    .Item("CAUNIF") = _CAUNIF
    .Item("CUAPMT") = _CUAPMT
    .Item("CUAUNT") = _CUAUNT
    .Item("CUPVAL") = _CUPVAL
    .Item("CUFOOT") = _CUFOOT
    .Item("CUACRE") = _CUACRE
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
Dim mCAACCT As Integer
Public Property _CAACCT As Integer
    Get
        Return mCAACCT
    End Get
    Set(ByVal value As Integer)
        mCAACCT = value
    End Set
End Property

Dim mCATYPE As String
Public Property _CATYPE As String
    Get
        Return mCATYPE
    End Get
    Set(ByVal value As String)
        mCATYPE = value
    End Set
End Property

Dim mCAADJ As Decimal
Public Property _CAADJ As Decimal
    Get
        Return mCAADJ
    End Get
    Set(ByVal value As Decimal)
        mCAADJ = value
    End Set
End Property

Dim mCADEF As Decimal
Public Property _CADEF As Decimal
    Get
        Return mCADEF
    End Get
    Set(ByVal value As Decimal)
        mCADEF = value
    End Set
End Property

Dim mCADEP As Integer
Public Property _CADEP As Integer
    Get
        Return mCADEP
    End Get
    Set(ByVal value As Integer)
        mCADEP = value
    End Set
End Property
Dim mCAAMT As Decimal
Public Property _CAAMT As Decimal
    Get
        Return mCAAMT
    End Get
    Set(ByVal value As Decimal)
        mCAAMT = value
    End Set
End Property

Dim mCAPNO As Integer
Public Property _CAPNO As Integer
    Get
        Return mCAPNO
    End Get
    Set(ByVal value As Integer)
        mCAPNO = value
    End Set
End Property

Dim mCAOVR As Decimal
Public Property _CAOVR As Decimal
    Get
        Return mCAOVR
    End Get
    Set(ByVal value As Decimal)
        mCAOVR = value
    End Set
End Property

Dim mCALAT As Integer
Public Property _CALAT As Integer
    Get
        Return mCALAT
    End Get
    Set(ByVal value As Integer)
        mCALAT = value
    End Set
End Property

Dim mCAUNIF As Integer
Public Property _CAUNIF As Integer
    Get
        Return mCAUNIF
    End Get
    Set(ByVal value As Integer)
        mCAUNIF = value
    End Set
End Property

Dim mCUAPMT As String
Public Property _CUAPMT As String
    Get
        Return mCUAPMT
    End Get
    Set(ByVal value As String)
        mCUAPMT = value
    End Set
End Property
Dim mCUAUNT As Decimal
Public Property _CUAUNT As Decimal
    Get
        Return mCUAUNT
    End Get
    Set(ByVal value As Decimal)
        mCUAUNT = value
    End Set
End Property

Dim mCUPVAL As Long
Public Property _CUPVAL As Long
    Get
        Return mCUPVAL
    End Get
    Set(ByVal value As Long)
        mCUPVAL = value
    End Set
End Property
Dim mCUFOOT As Decimal
Public Property _CUFOOT As Decimal
    Get
        Return mCUFOOT
    End Get
    Set(ByVal value As Decimal)
        mCUFOOT = value
    End Set
End Property
Dim mCUACRE As Decimal
Public Property _CUACRE As Decimal
    Get
        Return mCUACRE
    End Get
    Set(ByVal value As Decimal)
        mCUACRE = value
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

