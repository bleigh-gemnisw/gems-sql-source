Imports System.Data
Imports System.Data.SqlClient
Public Class LOGUT
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Dim Conn As SqlConnection
  Const cFileName As String = "LOGUT"
#Region "Constructors"

  Public Sub New(ByVal WrkConn As SqlConnection)
    Conn = WrkConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _CUACCT = 0
    _CUNAM1 = String.Empty
    _CUNAM2 = String.Empty
    _CUADD1 = String.Empty
    _CUADD2 = String.Empty
    _CUCITY = String.Empty
    _CUST = String.Empty
    _CUZIP = String.Empty
    _CUMAD1 = String.Empty
    _CUMAD2 = String.Empty
    _CUMCTY = String.Empty
    _CUMST = String.Empty
    _CUMZIP = String.Empty
    _CUTELNO = String.Empty
    _CUDST = 0
    _CUPHAS = 0
    _CUADDX = String.Empty
    _CUTIE = 0
    _CUMAP = String.Empty
    _CUVOLM = String.Empty
    _CUPAGE = String.Empty
    _CUZONE = String.Empty
    _CUPCAT = String.Empty
    _CUXREF = String.Empty
    _CUMSIZ = String.Empty
    _CYC = String.Empty
    _OID = String.Empty
    _CUSERN = String.Empty
    _CUROUT = String.Empty
    _CUMETN = String.Empty
    _CUMETP = String.Empty
    _CUREGN = String.Empty
    _CULOCNO = String.Empty
    _CULOC = String.Empty
    _CUCNTNO = String.Empty
    _CUAPLNO = String.Empty
    _CUFUND = 0
    _CUSECT = String.Empty
    _CUSDES = String.Empty
    _LOGCMT = String.Empty
    _LOGDTE = 0
    _LOGTIM = 0

  End Sub
  Public Sub GetOneRecordP(ByVal WrkListNo As Integer, WrkLogdte As Integer, WrkLogTim As Integer)
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where cuacct=" & WrkListNo &
   " and logdte=" & WrkLogdte & " and logtim=" & WrkLogTim
    Try
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
  Public Function SetDBDate(ByVal DateIn As Date) As Integer
    Dim WrkDate As Integer
    Dim StrDate As String

    StrDate = Year(DateIn) & Format(Month(DateIn), "00") &
    Format(DatePart(DateInterval.Day, DateIn), "00")
    WrkDate = CDbl(StrDate)
    Return WrkDate
  End Function
  Public Function PosData(ByVal WrkListNo As Integer, ByVal WrkLogdte As Integer, ByVal WrkLogTim As Integer,
   ByVal NumRecs As Long) As DataSet
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
   " or cuacct=" & WrkListNo & "and logdte>" & WrkLogdte
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
      _CUNAM1 = .Item("CUNAM1")
      _CUNAM2 = .Item("CUNAM2")
      _CUADD1 = .Item("CUADD1")
      _CUADD2 = .Item("CUADD2")
      _CUCITY = .Item("CUCITY")
      _CUST = .Item("CUST")
      _CUZIP = .Item("CUZIP")
      _CUMAD1 = .Item("CUMAD1")
      _CUMAD2 = .Item("CUMAD2")
      _CUMCTY = .Item("CUMCTY")
      _CUMST = .Item("CUMST")
      _CUMZIP = .Item("CUMZIP")
      _CUTELNO = .Item("CUTEL#")
      _CUDST = .Item("CUDST")
      _CUPHAS = .Item("CUPHAS")
      _CUADDX = .Item("CUADDX")
      _CUTIE = .Item("CUTIE")
      _CUMAP = .Item("CUMAP")
      _CUVOLM = .Item("CUVOLM")
      _CUPAGE = .Item("CUPAGE")
      _CUZONE = .Item("CUZONE")
      _CUPCAT = .Item("CUPCAT")
      _CUXREF = .Item("CUXREF")
      _CUMSIZ = .Item("CUMSIZ")
      _CYC = .Item("CYC")
      _OID = .Item("OID")
      _CUSERN = .Item("CUSERN")
      _CUROUT = .Item("CUROUT")
      _CUMETN = .Item("CUMETN")
      _CUMETP = .Item("CUMETP")
      _CUREGN = .Item("CUREGN")
      _CULOCNO = .Item("CULOC#")
      _CULOC = .Item("CULOC")
      _CUCNTNO = .Item("CUCNT#")
      _CUAPLNO = .Item("CUAPL#")
      _CUFUND = .Item("CUFUND")
      _CUSECT = .Item("CUSECT")
      _CUSDES = .Item("CUSDES")
      _LOGCMT = .Item("LOGCMT")
      _LOGDTE = .Item("LOGDTE")
      _LOGTIM = .Item("LOGTIM")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("CUACCT") = _CUACCT
      .Item("CUNAM1") = _CUNAM1
      .Item("CUNAM2") = _CUNAM2
      .Item("CUADD1") = _CUADD1
      .Item("CUADD2") = _CUADD2
      .Item("CUCITY") = _CUCITY
      .Item("CUST") = _CUST
      .Item("CUZIP") = _CUZIP
      .Item("CUMAD1") = _CUMAD1
      .Item("CUMAD2") = _CUMAD2
      .Item("CUMCTY") = _CUMCTY
      .Item("CUMST") = _CUMST
      .Item("CUMZIP") = _CUMZIP
      .Item("CUTEL#") = _CUTELNO
      .Item("CUDST") = _CUDST
      .Item("CUPHAS") = _CUPHAS
      .Item("CUADDX") = _CUADDX
      .Item("CUTIE") = _CUTIE
      .Item("CUMAP") = _CUMAP
      .Item("CUVOLM") = _CUVOLM
      .Item("CUPAGE") = _CUPAGE
      .Item("CUZONE") = _CUZONE
      .Item("CUPCAT") = _CUPCAT
      .Item("CUXREF") = _CUXREF
      .Item("CUMSIZ") = _CUMSIZ
      .Item("CYC") = _CYC
      .Item("OID") = _OID
      .Item("CUSERN") = _CUSERN
      .Item("CUROUT") = _CUROUT
      .Item("CUMETN") = _CUMETN
      .Item("CUMETP") = _CUMETP
      .Item("CUREGN") = _CUREGN
      .Item("CULOC#") = _CULOCNO
      .Item("CULOC") = _CULOC
      .Item("CUCNT#") = _CUCNTNO
      .Item("CUAPL#") = _CUAPLNO
      .Item("CUFUND") = _CUFUND
      .Item("CUSECT") = _CUSECT
      .Item("CUSDES") = _CUSDES
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

  Dim mCUNAM1 As String
  Public Property _CUNAM1 As String
    Get
      Return mCUNAM1
    End Get
    Set(ByVal value As String)
      mCUNAM1 = value
    End Set
  End Property

  Dim mCUNAM2 As String
  Public Property _CUNAM2 As String
    Get
      Return mCUNAM2
    End Get
    Set(ByVal value As String)
      mCUNAM2 = value
    End Set
  End Property

  Dim mCUADD1 As String
  Public Property _CUADD1 As String
    Get
      Return mCUADD1
    End Get
    Set(ByVal value As String)
      mCUADD1 = value
    End Set
  End Property

  Dim mCUADD2 As String
  Public Property _CUADD2 As String
    Get
      Return mCUADD2
    End Get
    Set(ByVal value As String)
      mCUADD2 = value
    End Set
  End Property

  Dim mCUCITY As String
  Public Property _CUCITY As String
    Get
      Return mCUCITY
    End Get
    Set(ByVal value As String)
      mCUCITY = value
    End Set
  End Property

  Dim mCUST As String
  Public Property _CUST As String
    Get
      Return mCUST
    End Get
    Set(ByVal value As String)
      mCUST = value
    End Set
  End Property

  Dim mCUZIP As String
  Public Property _CUZIP As String
    Get
      Return mCUZIP
    End Get
    Set(ByVal value As String)
      mCUZIP = value
    End Set
  End Property

  Dim mCUMAD1 As String
  Public Property _CUMAD1 As String
    Get
      Return mCUMAD1
    End Get
    Set(ByVal value As String)
      mCUMAD1 = value
    End Set
  End Property

  Dim mCUMAD2 As String
  Public Property _CUMAD2 As String
    Get
      Return mCUMAD2
    End Get
    Set(ByVal value As String)
      mCUMAD2 = value
    End Set
  End Property

  Dim mCUMCTY As String
  Public Property _CUMCTY As String
    Get
      Return mCUMCTY
    End Get
    Set(ByVal value As String)
      mCUMCTY = value
    End Set
  End Property

  Dim mCUMST As String
  Public Property _CUMST As String
    Get
      Return mCUMST
    End Get
    Set(ByVal value As String)
      mCUMST = value
    End Set
  End Property

  Dim mCUMZIP As String
  Public Property _CUMZIP As String
    Get
      Return mCUMZIP
    End Get
    Set(ByVal value As String)
      mCUMZIP = value
    End Set
  End Property

  Dim mCUTELNO As String
  Public Property _CUTELNO As String
    Get
      Return mCUTELNO
    End Get
    Set(ByVal value As String)
      mCUTELNO = value
    End Set
  End Property

  Dim mCUDST As Integer
  Public Property _CUDST As Integer
    Get
      Return mCUDST
    End Get
    Set(ByVal value As Integer)
      mCUDST = value
    End Set
  End Property

  Dim mCUPHAS As Integer
  Public Property _CUPHAS As Integer
    Get
      Return mCUPHAS
    End Get
    Set(ByVal value As Integer)
      mCUPHAS = value
    End Set
  End Property

  Dim mCUADDX As String
  Public Property _CUADDX As String
    Get
      Return mCUADDX
    End Get
    Set(ByVal value As String)
      mCUADDX = value
    End Set
  End Property

  Dim mCUTIE As Integer
  Public Property _CUTIE As Integer
    Get
      Return mCUTIE
    End Get
    Set(ByVal value As Integer)
      mCUTIE = value
    End Set
  End Property

  Dim mCUMAP As String
  Public Property _CUMAP As String
    Get
      Return mCUMAP
    End Get
    Set(ByVal value As String)
      mCUMAP = value
    End Set
  End Property

  Dim mCUVOLM As String
  Public Property _CUVOLM As String
    Get
      Return mCUVOLM
    End Get
    Set(ByVal value As String)
      mCUVOLM = value
    End Set
  End Property

  Dim mCUPAGE As String
  Public Property _CUPAGE As String
    Get
      Return mCUPAGE
    End Get
    Set(ByVal value As String)
      mCUPAGE = value
    End Set
  End Property

  Dim mCUZONE As String
  Public Property _CUZONE As String
    Get
      Return mCUZONE
    End Get
    Set(ByVal value As String)
      mCUZONE = value
    End Set
  End Property

  Dim mCUPCAT As String
  Public Property _CUPCAT As String
    Get
      Return mCUPCAT
    End Get
    Set(ByVal value As String)
      mCUPCAT = value
    End Set
  End Property

  Dim mCUXREF As String
  Public Property _CUXREF As String
    Get
      Return mCUXREF
    End Get
    Set(ByVal value As String)
      mCUXREF = value
    End Set
  End Property

  Dim mCUMSIZ As String
  Public Property _CUMSIZ As String
    Get
      Return mCUMSIZ
    End Get
    Set(ByVal value As String)
      mCUMSIZ = value
    End Set
  End Property

  Dim mCYC As String
  Public Property _CYC As String
    Get
      Return mCYC
    End Get
    Set(ByVal value As String)
      mCYC = value
    End Set
  End Property

  Dim mOID As String
  Public Property _OID As String
    Get
      Return mOID
    End Get
    Set(ByVal value As String)
      mOID = value
    End Set
  End Property

  Dim mCUSERN As String
  Public Property _CUSERN As String
    Get
      Return mCUSERN
    End Get
    Set(ByVal value As String)
      mCUSERN = value
    End Set
  End Property

  Dim mCUROUT As String
  Public Property _CUROUT As String
    Get
      Return mCUROUT
    End Get
    Set(ByVal value As String)
      mCUROUT = value
    End Set
  End Property

  Dim mCUMETN As String
  Public Property _CUMETN As String
    Get
      Return mCUMETN
    End Get
    Set(ByVal value As String)
      mCUMETN = value
    End Set
  End Property

  Dim mCUMETP As String
  Public Property _CUMETP As String
    Get
      Return mCUMETP
    End Get
    Set(ByVal value As String)
      mCUMETP = value
    End Set
  End Property

  Dim mCUREGN As String
  Public Property _CUREGN As String
    Get
      Return mCUREGN
    End Get
    Set(ByVal value As String)
      mCUREGN = value
    End Set
  End Property

  Dim mCULOCNO As String
  Public Property _CULOCNO As String
    Get
      Return mCULOCNO
    End Get
    Set(ByVal value As String)
      mCULOCNO = value
    End Set
  End Property

  Dim mCULOC As String
  Public Property _CULOC As String
    Get
      Return mCULOC
    End Get
    Set(ByVal value As String)
      mCULOC = value
    End Set
  End Property

  Dim mCUCNTNO As String
  Public Property _CUCNTNO As String
    Get
      Return mCUCNTNO
    End Get
    Set(ByVal value As String)
      mCUCNTNO = value
    End Set
  End Property

  Dim mCUAPLNO As String
  Public Property _CUAPLNO As String
    Get
      Return mCUAPLNO
    End Get
    Set(ByVal value As String)
      mCUAPLNO = value
    End Set
  End Property

  Dim mCUFUND As Integer
  Public Property _CUFUND As Integer
    Get
      Return mCUFUND
    End Get
    Set(ByVal value As Integer)
      mCUFUND = value
    End Set
  End Property

  Dim mCUSECT As String
  Public Property _CUSECT As String
    Get
      Return mCUSECT
    End Get
    Set(ByVal value As String)
      mCUSECT = value
    End Set
  End Property

  Dim mCUSDES As String
  Public Property _CUSDES As String
    Get
      Return mCUSDES
    End Get
    Set(ByVal value As String)
      mCUSDES = value
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

