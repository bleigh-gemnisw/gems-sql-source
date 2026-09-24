Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "LOCATN"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub GetOneRecordP(ByVal Llocn As String)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where LLOCN='" & Llocn & "'"
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
Public Function PosData(ByVal Llocn As String) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  StrSQL = "Select * from " & cFileName & " where LLOCN>='" & Llocn & "' order by llocn"
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

#Region "Properties: Set Fields"
Private Sub GetFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    _LLOCN = .Item("LLOCN")
    _LDESC = .Item("LDESC")
    _SNAME = .Item("SNAME")
    _SADR1 = .Item("SADR1")
    _SADR2 = .Item("SADR2")
    _SADR3 = .Item("SADR3")
    _SADR4 = .Item("SADR4")
    _RNAME = .Item("RNAME")
    _RADR1 = .Item("RADR1")
    _RADR2 = .Item("RADR2")
    _RADR3 = .Item("RADR3")
    _RADR4 = .Item("RADR4")
    _NXTRQ = .Item("NXTRQ")
    _SZIP = .Item("SZIP")
    _SZIPE = .Item("SZIPE")
    _RZIP = .Item("RZIP")
    _RZIPE = .Item("RZIPE")
    _EXERR = .Item("EXERR")
  End With
End Sub
Private Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("LLOCN") = _LLOCN
    .Item("LDESC") = _LDESC
    .Item("SNAME") = _SNAME
    .Item("SADR1") = _SADR1
    .Item("SADR2") = _SADR2
    .Item("SADR3") = _SADR3
    .Item("SADR4") = _SADR4
    .Item("RNAME") = _RNAME
    .Item("RADR1") = _RADR1
    .Item("RADR2") = _RADR2
    .Item("RADR3") = _RADR3
    .Item("RADR4") = _RADR4
    .Item("NXTRQ") = _NXTRQ
    .Item("SZIP") = _SZIP
    .Item("SZIPE") = _SZIPE
    .Item("RZIP") = _RZIP
    .Item("RZIPE") = _RZIPE
    .Item("EXERR") = _EXERR
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
Dim mLLOCN As String
Public Property _LLOCN As String
    Get
        Return mLLOCN
    End Get
    Set(ByVal value As String)
        mLLOCN = value
    End Set
End Property

Dim mLDESC As String
Public Property _LDESC As String
    Get
        Return mLDESC
    End Get
    Set(ByVal value As String)
        mLDESC = value
    End Set
End Property

Dim mSNAME As String
Public Property _SNAME As String
    Get
        Return mSNAME
    End Get
    Set(ByVal value As String)
        mSNAME = value
    End Set
End Property

Dim mSADR1 As String
Public Property _SADR1 As String
    Get
        Return mSADR1
    End Get
    Set(ByVal value As String)
        mSADR1 = value
    End Set
End Property

Dim mSADR2 As String
Public Property _SADR2 As String
    Get
        Return mSADR2
    End Get
    Set(ByVal value As String)
        mSADR2 = value
    End Set
End Property

Dim mSADR3 As String
Public Property _SADR3 As String
    Get
        Return mSADR3
    End Get
    Set(ByVal value As String)
        mSADR3 = value
    End Set
End Property

Dim mSADR4 As String
Public Property _SADR4 As String
    Get
        Return mSADR4
    End Get
    Set(ByVal value As String)
        mSADR4 = value
    End Set
End Property

Dim mRNAME As String
Public Property _RNAME As String
    Get
        Return mRNAME
    End Get
    Set(ByVal value As String)
        mRNAME = value
    End Set
End Property

Dim mRADR1 As String
Public Property _RADR1 As String
    Get
        Return mRADR1
    End Get
    Set(ByVal value As String)
        mRADR1 = value
    End Set
End Property

Dim mRADR2 As String
Public Property _RADR2 As String
    Get
        Return mRADR2
    End Get
    Set(ByVal value As String)
        mRADR2 = value
    End Set
End Property

Dim mRADR3 As String
Public Property _RADR3 As String
    Get
        Return mRADR3
    End Get
    Set(ByVal value As String)
        mRADR3 = value
    End Set
End Property

Dim mRADR4 As String
Public Property _RADR4 As String
    Get
        Return mRADR4
    End Get
    Set(ByVal value As String)
        mRADR4 = value
    End Set
End Property

Dim mNXTRQ As Integer
Public Property _NXTRQ As Integer
    Get
        Return mNXTRQ
    End Get
    Set(ByVal value As Integer)
        mNXTRQ = value
    End Set
End Property

Dim mSZIP As String
Public Property _SZIP As String
    Get
        Return mSZIP
    End Get
    Set(ByVal value As String)
        mSZIP = value
    End Set
End Property

Dim mSZIPE As String
Public Property _SZIPE As String
    Get
        Return mSZIPE
    End Get
    Set(ByVal value As String)
        mSZIPE = value
    End Set
End Property

Dim mRZIP As String
Public Property _RZIP As String
    Get
        Return mRZIP
    End Get
    Set(ByVal value As String)
        mRZIP = value
    End Set
End Property

Dim mRZIPE As String
Public Property _RZIPE As String
    Get
        Return mRZIPE
    End Get
    Set(ByVal value As String)
        mRZIPE = value
    End Set
End Property

Dim mEXERR As String
Public Property _EXERR As String
    Get
        Return mEXERR
    End Get
    Set(ByVal value As String)
        mEXERR = value
    End Set
End Property
#End Region
End Class

