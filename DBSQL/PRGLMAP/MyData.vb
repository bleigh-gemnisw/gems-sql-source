Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "PRGLMAP"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _PFUND = 0
    _PSFUND = 0
    _PDEPT = 0
    _POBJ = 0
    _PFUNC = 0
    _PSFUNC = 0
    _PDESC = ""
    _CFUND = 0
    _CSFUND = 0
    _CDEPT = 0
    _COBJ = 0
    _CFUNC = 0
    _CSFUNC = 0
    _DFUND = 0
    _DSFUND = 0
    _DDEPT = 0
    _DOBJ = 0
    _DFUNC = 0
    _DSFUNC = 0
  End Sub
  Public Sub GetOneRecordP(ByVal Fund As Integer, ByVal Sfund As Integer, ByVal Dept As Integer,
 ByVal Obj As Integer, ByVal Func As Integer, ByVal Sfunc As Integer, ByVal PDesc As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkDesc As String

    RecordNotFound = False
    If Trim(PDesc) = "" Then
      WrkDesc = ""
    Else
      WrkDesc = " and PDESC='" & PDesc & "'"
    End If
    StrSQL = "Select * from " & cFileName & " where PFUND=" & Fund & " and PSFUND=" & Sfund &
   " and PDEPT=" & Dept & " and POBJ=" & Obj & " and PFUNC=" & Func & " and PSFUNC=" & Sfunc & WrkDesc
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
  Public Function GetAcctAll(ByVal Fund As Integer, ByVal Sfund As Integer, ByVal Dept As Integer,
 ByVal Obj As Integer, ByVal Func As Integer, ByVal Sfunc As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName &
  " where PFUND=" & Fund & " and PSFUND=" & Sfund & " and PDEPT=" & Dept & " and POBJ=" & Obj & " and PFUNC=" & Func
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
  Public Function PosData(ByVal Fund As Integer, ByVal Sfund As Integer, ByVal Dept As Integer,
 ByVal Obj As Integer, ByVal Func As Integer, ByVal Sfunc As Integer, ByVal NumRecs As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & "* from " & cFileName &
  " where PFUND=" & Fund & " and PSFUND=" & Sfund & " and PDEPT=" & Dept & " and POBJ=" & Obj &
  " and PFUNC=" & Func & " and PSFUNC>=" & Sfunc &
  " or PFUND=" & Fund & " and PSFUND=" & Sfund & " and PDEPT=" & Dept & " and POBJ=" & Obj & " and PFUNC>" & Func &
  " or PFUND=" & Fund & " and PSFUND=" & Sfund & " and PDEPT=" & Dept & " and POBJ>" & Obj &
  " or PFUND=" & Fund & " and PSFUND=" & Sfund & " and PDEPT>" & Dept &
  " or PFUND=" & Fund & " and PSFUND>" & Sfund &
  " or PFUND>" & Fund & " order by PFUND,PSFUND,PDEPT,POBJ,PFUNC,PSFUNC"
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
      _PFUND = .Item("PFUND")
      _PSFUND = .Item("PSFUND")
      _PDEPT = .Item("PDEPT")
      _POBJ = .Item("POBJ")
      _PFUNC = .Item("PFUNC")
      _PSFUNC = .Item("PSFUNC")
      _PDESC = .Item("PDESC")
      _CFUND = .Item("CFUND")
      _CSFUND = .Item("CSFUND")
      _CDEPT = .Item("CDEPT")
      _COBJ = .Item("COBJ")
      _CFUNC = .Item("CFUNC")
      _CSFUNC = .Item("CSFUNC")
      _DFUND = .Item("DFUND")
      _DSFUND = .Item("DSFUND")
      _DDEPT = .Item("DDEPT")
      _DOBJ = .Item("DOBJ")
      _DFUNC = .Item("DFUNC")
      _DSFUNC = .Item("DSFUNC")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("PFUND") = _PFUND
      .Item("PSFUND") = _PSFUND
      .Item("PDEPT") = _PDEPT
      .Item("POBJ") = _POBJ
      .Item("PFUNC") = _PFUNC
      .Item("PSFUNC") = _PSFUNC
      .Item("PDESC") = _PDESC
      .Item("CFUND") = _CFUND
      .Item("CSFUND") = _CSFUND
      .Item("CDEPT") = _CDEPT
      .Item("COBJ") = _COBJ
      .Item("CFUNC") = _CFUNC
      .Item("CSFUNC") = _CSFUNC
      .Item("DFUND") = _DFUND
      .Item("DSFUND") = _DSFUND
      .Item("DDEPT") = _DDEPT
      .Item("DOBJ") = _DOBJ
      .Item("DFUNC") = _DFUNC
      .Item("DSFUNC") = _DSFUNC
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
  Dim mPFUND As Integer
  Public Property _PFUND As Integer
    Get
      Return mPFUND
    End Get
    Set(ByVal value As Integer)
      mPFUND = value
    End Set
  End Property

  Dim mPSFUND As Integer
  Public Property _PSFUND As Integer
    Get
      Return mPSFUND
    End Get
    Set(ByVal value As Integer)
      mPSFUND = value
    End Set
  End Property

  Dim mPDEPT As Integer
  Public Property _PDEPT As Integer
    Get
      Return mPDEPT
    End Get
    Set(ByVal value As Integer)
      mPDEPT = value
    End Set
  End Property

  Dim mPOBJ As Integer
  Public Property _POBJ As Integer
    Get
      Return mPOBJ
    End Get
    Set(ByVal value As Integer)
      mPOBJ = value
    End Set
  End Property

  Dim mPFUNC As Integer
  Public Property _PFUNC As Integer
    Get
      Return mPFUNC
    End Get
    Set(ByVal value As Integer)
      mPFUNC = value
    End Set
  End Property

  Dim mPSFUNC As Integer
  Public Property _PSFUNC As Integer
    Get
      Return mPSFUNC
    End Get
    Set(ByVal value As Integer)
      mPSFUNC = value
    End Set
  End Property

  Dim mPDESC As String
  Public Property _PDESC As String
    Get
      Return mPDESC
    End Get
    Set(ByVal value As String)
      mPDESC = value
    End Set
  End Property

  Dim mCFUND As Integer
  Public Property _CFUND As Integer
    Get
      Return mCFUND
    End Get
    Set(ByVal value As Integer)
      mCFUND = value
    End Set
  End Property

  Dim mCSFUND As Integer
  Public Property _CSFUND As Integer
    Get
      Return mCSFUND
    End Get
    Set(ByVal value As Integer)
      mCSFUND = value
    End Set
  End Property

  Dim mCDEPT As Integer
  Public Property _CDEPT As Integer
    Get
      Return mCDEPT
    End Get
    Set(ByVal value As Integer)
      mCDEPT = value
    End Set
  End Property

  Dim mCOBJ As Integer
  Public Property _COBJ As Integer
    Get
      Return mCOBJ
    End Get
    Set(ByVal value As Integer)
      mCOBJ = value
    End Set
  End Property

  Dim mCFUNC As Integer
  Public Property _CFUNC As Integer
    Get
      Return mCFUNC
    End Get
    Set(ByVal value As Integer)
      mCFUNC = value
    End Set
  End Property

  Dim mCSFUNC As Integer
  Public Property _CSFUNC As Integer
    Get
      Return mCSFUNC
    End Get
    Set(ByVal value As Integer)
      mCSFUNC = value
    End Set
  End Property

  Dim mDFUND As Integer
  Public Property _DFUND As Integer
    Get
      Return mDFUND
    End Get
    Set(ByVal value As Integer)
      mDFUND = value
    End Set
  End Property

  Dim mDSFUND As Integer
  Public Property _DSFUND As Integer
    Get
      Return mDSFUND
    End Get
    Set(ByVal value As Integer)
      mDSFUND = value
    End Set
  End Property

  Dim mDDEPT As Integer
  Public Property _DDEPT As Integer
    Get
      Return mDDEPT
    End Get
    Set(ByVal value As Integer)
      mDDEPT = value
    End Set
  End Property

  Dim mDOBJ As Integer
  Public Property _DOBJ As Integer
    Get
      Return mDOBJ
    End Get
    Set(ByVal value As Integer)
      mDOBJ = value
    End Set
  End Property

  Dim mDFUNC As Integer
  Public Property _DFUNC As Integer
    Get
      Return mDFUNC
    End Get
    Set(ByVal value As Integer)
      mDFUNC = value
    End Set
  End Property

  Dim mDSFUNC As Integer
  Public Property _DSFUNC As Integer
    Get
      Return mDSFUNC
    End Get
    Set(ByVal value As Integer)
      mDSFUNC = value
    End Set
  End Property
#End Region
End Class


