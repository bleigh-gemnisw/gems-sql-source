Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "APEBNC"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub GetOneRecordP(ByVal WrkCode As String)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where bnkcd='" & WrkCode & "'"
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
Public Function PosData(ByVal WrkCode As String) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  StrSQL = "Select * from " & cFileName & " where bnkcd>='" & WrkCode & "' order by bnkcd"
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
    _BNKCD = .Item("BNKCD")
    _ACDES1 = .Item("ACDES1")
    _ACDES2 = .Item("ACDES2")
    _ACDES3 = .Item("ACDES3")
    _BNDES1 = .Item("BNDES1")
    _BNDES2 = .Item("BNDES2")
    _BNDES3 = .Item("BNDES3")
    _FRACT1 = .Item("FRACT1")
    _FRACT2 = .Item("FRACT2")
    _ROUT = .Item("ROUT")
    _SIG1 = .Item("SIG1")
    _SIG2 = .Item("SIG2")
    _SIG3 = .Item("SIG3")
    _MICR = .Item("MICR")
  End With
End Sub
Public Sub PutFields(ByVal ds As DataSet)
	With ds.Tables(0).Rows(0)
    .Item("BNKCD") = _BNKCD
    .Item("ACDES1") = _ACDES1
    .Item("ACDES2") = _ACDES2
    .Item("ACDES3") = _ACDES3
    .Item("BNDES1") = _BNDES1
    .Item("BNDES2") = _BNDES2
    .Item("BNDES3") = _BNDES3
    .Item("FRACT1") = _FRACT1
    .Item("FRACT2") = _FRACT2
    .Item("ROUT") = _ROUT
    .Item("SIG1") = _SIG1
    .Item("SIG2") = _SIG2
    .Item("SIG3") = _SIG3
    .Item("MICR") = _MICR
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
Dim mBNKCD As String
Public Property _BNKCD As String
    Get
        Return mBNKCD
    End Get
    Set(ByVal value As String)
        mBNKCD = value
    End Set
End Property
Dim mACDES1 As String
Public Property _ACDES1 As String
    Get
        Return mACDES1
    End Get
    Set(ByVal value As String)
        mACDES1 = value
    End Set
End Property
Dim mACDES2 As String
Public Property _ACDES2 As String
    Get
        Return mACDES2
    End Get
    Set(ByVal value As String)
        mACDES2 = value
    End Set
End Property
Dim mACDES3 As String
Public Property _ACDES3 As String
    Get
        Return mACDES3
    End Get
    Set(ByVal value As String)
        mACDES3 = value
    End Set
End Property
Dim mBNDES1 As String
Public Property _BNDES1 As String
    Get
        Return mBNDES1
    End Get
    Set(ByVal value As String)
        mBNDES1 = value
    End Set
End Property
Dim mBNDES2 As String
Public Property _BNDES2 As String
    Get
        Return mBNDES2
    End Get
    Set(ByVal value As String)
        mBNDES2 = value
    End Set
End Property
Dim mBNDES3 As String
Public Property _BNDES3 As String
    Get
        Return mBNDES3
    End Get
    Set(ByVal value As String)
        mBNDES3 = value
    End Set
End Property
Dim mFRACT1 As String
Public Property _FRACT1 As String
    Get
        Return mFRACT1
    End Get
    Set(ByVal value As String)
        mFRACT1 = value
    End Set
End Property
Dim mFRACT2 As String
Public Property _FRACT2 As String
    Get
        Return mFRACT2
    End Get
    Set(ByVal value As String)
        mFRACT2 = value
    End Set
End Property
Dim mROUT As String
Public Property _ROUT As String
    Get
        Return mROUT
    End Get
    Set(ByVal value As String)
        mROUT = value
    End Set
End Property
Dim mSIG1 As String
Public Property _SIG1 As String
    Get
        Return mSIG1
    End Get
    Set(ByVal value As String)
        mSIG1 = value
    End Set
End Property
Dim mSIG2 As String
Public Property _SIG2 As String
    Get
        Return mSIG2
    End Get
    Set(ByVal value As String)
        mSIG2 = value
    End Set
End Property
Dim mSIG3 As String
Public Property _SIG3 As String
    Get
        Return mSIG3
    End Get
    Set(ByVal value As String)
        mSIG3 = value
    End Set
End Property
Dim mMICR As String
Public Property _MICR As String
    Get
        Return mMICR
    End Get
    Set(ByVal value As String)
        mMICR = value
    End Set
End Property
#End Region
End Class

