Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "BDMAST"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Function AutoGenKey() As Integer
    Dim NextKey As Integer
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select top 1 * from " & cFileName & " order by recid desc"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      If ds.Tables(0).Rows.Count = 0 Then
        NextKey = 1
      Else
        NextKey = ds.Tables(0).Rows(0).Item("recid") + 1
      End If
      If NextKey > 9999999 Then
        NextKey = 1
      End If
      objCommand = Nothing
      ds.Clear()
      ds = Nothing
      Conn.Close()
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try
    Return NextKey
  End Function
  Public Sub ClearFields()
    _RECID = 0
    _STATUS = String.Empty
    _PERMNO = String.Empty
    _TYPE = String.Empty
    _APDATE = 0
    _TRDATE = 0
    _ANAME = String.Empty
    _AADD1 = String.Empty
    _APCITY = String.Empty
    _ASTATE = String.Empty
    _AZIP = 0
    _APHONE = String.Empty
    _APROP = String.Empty
    _LISTNO = 0
    _NAME = String.Empty
    _ADD1 = String.Empty
    _CITY = String.Empty
    _STATE = String.Empty
    _ZIP = 0
    _LOCNO = String.Empty
    _LOC = String.Empty
    _ZONE = String.Empty
    _MAP = String.Empty
    _PHONE = String.Empty
    _TNNAME = String.Empty
    _HSTDST = 0
    _WETLND = String.Empty
    _ARCLIC = String.Empty
    _ARCEXP = 0
    _CBYDNO = String.Empty
    _ROADOP = String.Empty
    _HNDDIG = String.Empty
    _CONSTY = String.Empty
    _CURUSE = String.Empty
    _PROUSE = String.Empty
    _LEVEL = String.Empty
    _UNIT = String.Empty
    _BLDGAS = String.Empty
    _ELECCD = String.Empty
    _ELECYR = 0
    _ELACCT = String.Empty
    _HEATTY = String.Empty
    _TANK = 0
    _TANKLO = String.Empty
    _SGERE = String.Empty
    _SGSIDE = String.Empty
    _SGDIM = String.Empty
    _SGSQ = 0
    _SGFAST = String.Empty
    _SGELEC = String.Empty
    _DMSTOR = 0
    _DMSIZE = String.Empty
    _DMDATE = 0
    _DMPHON = String.Empty
    _DMGAS = String.Empty
    _DMELEC = String.Empty
    _DMWPCA = String.Empty
    _DMSWR = String.Empty
    _DMSEPT = String.Empty
    _PZSQ = 0
    _PZUSE = 0
    _PZFRNT = String.Empty
    _PZWATR = String.Empty
    _PZAPP = String.Empty
    _SUBUS = String.Empty
    _SUHRS = String.Empty
    _SUEMP = String.Empty
    _SUDESC = String.Empty
    _SUSIGN = String.Empty
    _COID = 0
    _CONAME = String.Empty
    _COPHON = String.Empty
    _COLIC = String.Empty
    _VALUE = 0
    _MISCHG = 0
    _FEE = 0
    _INNAME = String.Empty
    _INDATE = 0
    _PAYTYP = String.Empty
    _PAYREF = String.Empty
    _PRF = String.Empty
  End Sub
  Public Sub GetOneRecordP(ByVal WrkRecid As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where recid=" & WrkRecid
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
  Public Function PosData(ByVal WrkRecid As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where recid>=" & WrkRecid
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
      _RECID = .Item("RECID")
      _STATUS = .Item("STATUS")
      _PERMNO = .Item("PERMNO")
      _TYPE = .Item("TYPE")
      _APDATE = .Item("APDATE")
      _TRDATE = .Item("TRDATE")
      _ANAME = .Item("ANAME")
      _AADD1 = .Item("AADD1")
      _APCITY = .Item("APCITY")
      _ASTATE = .Item("ASTATE")
      _AZIP = .Item("AZIP")
      _APHONE = .Item("APHONE")
      _APROP = .Item("APROP")
      _LISTNO = .Item("LISTNO")
      _NAME = .Item("NAME")
      _ADD1 = .Item("ADD1")
      _CITY = .Item("CITY")
      _STATE = .Item("STATE")
      _ZIP = .Item("ZIP")
      _LOCNO = .Item("LOCNO")
      _LOC = .Item("LOC")
      _ZONE = .Item("ZONE")
      _MAP = .Item("MAP")
      _PHONE = .Item("PHONE")
      _TNNAME = .Item("TNNAME")
      _HSTDST = .Item("HSTDST")
      _WETLND = .Item("WETLND")
      _ARCLIC = .Item("ARCLIC")
      _ARCEXP = .Item("ARCEXP")
      _CBYDNO = .Item("CBYDNO")
      _ROADOP = .Item("ROADOP")
      _HNDDIG = .Item("HNDDIG")
      _CONSTY = .Item("CONSTY")
      _CURUSE = .Item("CURUSE")
      _PROUSE = .Item("PROUSE")
      _LEVEL = .Item("LEVEL")
      _UNIT = .Item("UNIT")
      _BLDGAS = .Item("BLDGAS")
      _ELECCD = .Item("ELECCD")
      _ELECYR = .Item("ELECYR")
      _ELACCT = .Item("ELACCT")
      _HEATTY = .Item("HEATTY")
      _TANK = .Item("TANK")
      _TANKLO = .Item("TANKLO")
      _SGERE = .Item("SGERE")
      _SGSIDE = .Item("SGSIDE")
      _SGDIM = .Item("SGDIM")
      _SGSQ = .Item("SGSQ")
      _SGFAST = .Item("SGFAST")
      _SGELEC = .Item("SGELEC")
      _DMSTOR = .Item("DMSTOR")
      _DMSIZE = .Item("DMSIZE")
      _DMDATE = .Item("DMDATE")
      _DMPHON = .Item("DMPHON")
      _DMGAS = .Item("DMGAS")
      _DMELEC = .Item("DMELEC")
      _DMWPCA = .Item("DMWPCA")
      _DMSWR = .Item("DMSWR")
      _DMSEPT = .Item("DMSEPT")
      _PZSQ = .Item("PZSQ")
      _PZUSE = .Item("PZUSE")
      _PZFRNT = .Item("PZFRNT")
      _PZWATR = .Item("PZWATR")
      _PZAPP = .Item("PZAPP")
      _SUBUS = .Item("SUBUS")
      _SUHRS = .Item("SUHRS")
      _SUEMP = .Item("SUEMP")
      _SUDESC = .Item("SUDESC")
      _SUSIGN = .Item("SUSIGN")
      _COID = .Item("COID")
      _CONAME = .Item("CONAME")
      _COPHON = .Item("COPHON")
      _COLIC = .Item("COLIC")
      _VALUE = .Item("VALUE")
      _MISCHG = .Item("MISCHG")
      _FEE = .Item("FEE")
      _INNAME = .Item("INNAME")
      _INDATE = .Item("INDATE")
      _PAYTYP = .Item("PAYTYP")
      _PAYREF = .Item("PAYREF")
      _PRF = .Item("PRF")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("RECID") = _RECID
      .Item("STATUS") = _STATUS
      .Item("PERMNO") = _PERMNO
      .Item("TYPE") = _TYPE
      .Item("APDATE") = _APDATE
      .Item("TRDATE") = _TRDATE
      .Item("ANAME") = _ANAME
      .Item("AADD1") = _AADD1
      .Item("APCITY") = _APCITY
      .Item("ASTATE") = _ASTATE
      .Item("AZIP") = _AZIP
      .Item("APHONE") = _APHONE
      .Item("APROP") = _APROP
      .Item("LISTNO") = _LISTNO
      .Item("NAME") = _NAME
      .Item("ADD1") = _ADD1
      .Item("CITY") = _CITY
      .Item("STATE") = _STATE
      .Item("ZIP") = _ZIP
      .Item("LOCNO") = _LOCNO
      .Item("LOC") = _LOC
      .Item("ZONE") = _ZONE
      .Item("MAP") = _MAP
      .Item("PHONE") = _PHONE
      .Item("TNNAME") = _TNNAME
      .Item("HSTDST") = _HSTDST
      .Item("WETLND") = _WETLND
      .Item("ARCLIC") = _ARCLIC
      .Item("ARCEXP") = _ARCEXP
      .Item("CBYDNO") = _CBYDNO
      .Item("ROADOP") = _ROADOP
      .Item("HNDDIG") = _HNDDIG
      .Item("CONSTY") = _CONSTY
      .Item("CURUSE") = _CURUSE
      .Item("PROUSE") = _PROUSE
      .Item("LEVEL") = _LEVEL
      .Item("UNIT") = _UNIT
      .Item("BLDGAS") = _BLDGAS
      .Item("ELECCD") = _ELECCD
      .Item("ELECYR") = _ELECYR
      .Item("ELACCT") = _ELACCT
      .Item("HEATTY") = _HEATTY
      .Item("TANK") = _TANK
      .Item("TANKLO") = _TANKLO
      .Item("SGERE") = _SGERE
      .Item("SGSIDE") = _SGSIDE
      .Item("SGDIM") = _SGDIM
      .Item("SGSQ") = _SGSQ
      .Item("SGFAST") = _SGFAST
      .Item("SGELEC") = _SGELEC
      .Item("DMSTOR") = _DMSTOR
      .Item("DMSIZE") = _DMSIZE
      .Item("DMDATE") = _DMDATE
      .Item("DMPHON") = _DMPHON
      .Item("DMGAS") = _DMGAS
      .Item("DMELEC") = _DMELEC
      .Item("DMWPCA") = _DMWPCA
      .Item("DMSWR") = _DMSWR
      .Item("DMSEPT") = _DMSEPT
      .Item("PZSQ") = _PZSQ
      .Item("PZUSE") = _PZUSE
      .Item("PZFRNT") = _PZFRNT
      .Item("PZWATR") = _PZWATR
      .Item("PZAPP") = _PZAPP
      .Item("SUBUS") = _SUBUS
      .Item("SUHRS") = _SUHRS
      .Item("SUEMP") = _SUEMP
      .Item("SUDESC") = _SUDESC
      .Item("SUSIGN") = _SUSIGN
      .Item("COID") = _COID
      .Item("CONAME") = _CONAME
      .Item("COPHON") = _COPHON
      .Item("COLIC") = _COLIC
      .Item("VALUE") = _VALUE
      .Item("MISCHG") = _MISCHG
      .Item("FEE") = _FEE
      .Item("INNAME") = _INNAME
      .Item("INDATE") = _INDATE
      .Item("PAYTYP") = _PAYTYP
      .Item("PAYREF") = _PAYREF
      .Item("PRF") = _PRF
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
  Dim mRECID As String
  Public Property _RECID As String
    Get
      Return mRECID
    End Get
    Set(ByVal value As String)
      mRECID = value
    End Set
  End Property
  Dim mSTATUS As String
  Public Property _STATUS As String
    Get
      Return mSTATUS
    End Get
    Set(ByVal value As String)
      mSTATUS = value
    End Set
  End Property

  Dim mPERMNO As String
  Public Property _PERMNO As String
    Get
      Return mPERMNO
    End Get
    Set(ByVal value As String)
      mPERMNO = value
    End Set
  End Property

  Dim mTYPE As String
  Public Property _TYPE As String
    Get
      Return mTYPE
    End Get
    Set(ByVal value As String)
      mTYPE = value
    End Set
  End Property

  Dim mAPDATE As Integer
  Public Property _APDATE As Integer
    Get
      Return mAPDATE
    End Get
    Set(ByVal value As Integer)
      mAPDATE = value
    End Set
  End Property

  Dim mTRDATE As Integer
  Public Property _TRDATE As Integer
    Get
      Return mTRDATE
    End Get
    Set(ByVal value As Integer)
      mTRDATE = value
    End Set
  End Property

  Dim mANAME As String
  Public Property _ANAME As String
    Get
      Return mANAME
    End Get
    Set(ByVal value As String)
      mANAME = value
    End Set
  End Property

  Dim mAADD1 As String
  Public Property _AADD1 As String
    Get
      Return mAADD1
    End Get
    Set(ByVal value As String)
      mAADD1 = value
    End Set
  End Property

  Dim mAPCITY As String
  Public Property _APCITY As String
    Get
      Return mAPCITY
    End Get
    Set(ByVal value As String)
      mAPCITY = value
    End Set
  End Property

  Dim mASTATE As String
  Public Property _ASTATE As String
    Get
      Return mASTATE
    End Get
    Set(ByVal value As String)
      mASTATE = value
    End Set
  End Property

  Dim mAZIP As Integer
  Public Property _AZIP As Integer
    Get
      Return mAZIP
    End Get
    Set(ByVal value As Integer)
      mAZIP = value
    End Set
  End Property

  Dim mAPHONE As String
  Public Property _APHONE As String
    Get
      Return mAPHONE
    End Get
    Set(ByVal value As String)
      mAPHONE = value
    End Set
  End Property

  Dim mAPROP As String
  Public Property _APROP As String
    Get
      Return mAPROP
    End Get
    Set(ByVal value As String)
      mAPROP = value
    End Set
  End Property

  Dim mLISTNO As Integer
  Public Property _LISTNO As Integer
    Get
      Return mLISTNO
    End Get
    Set(ByVal value As Integer)
      mLISTNO = value
    End Set
  End Property

  Dim mNAME As String
  Public Property _NAME As String
    Get
      Return mNAME
    End Get
    Set(ByVal value As String)
      mNAME = value
    End Set
  End Property

  Dim mADD1 As String
  Public Property _ADD1 As String
    Get
      Return mADD1
    End Get
    Set(ByVal value As String)
      mADD1 = value
    End Set
  End Property

  Dim mCITY As String
  Public Property _CITY As String
    Get
      Return mCITY
    End Get
    Set(ByVal value As String)
      mCITY = value
    End Set
  End Property

  Dim mSTATE As String
  Public Property _STATE As String
    Get
      Return mSTATE
    End Get
    Set(ByVal value As String)
      mSTATE = value
    End Set
  End Property

  Dim mZIP As Integer
  Public Property _ZIP As Integer
    Get
      Return mZIP
    End Get
    Set(ByVal value As Integer)
      mZIP = value
    End Set
  End Property

  Dim mLOCNO As String
  Public Property _LOCNO As String
    Get
      Return mLOCNO
    End Get
    Set(ByVal value As String)
      mLOCNO = value
    End Set
  End Property

  Dim mLOC As String
  Public Property _LOC As String
    Get
      Return mLOC
    End Get
    Set(ByVal value As String)
      mLOC = value
    End Set
  End Property

  Dim mZONE As String
  Public Property _ZONE As String
    Get
      Return mZONE
    End Get
    Set(ByVal value As String)
      mZONE = value
    End Set
  End Property

  Dim mMAP As String
  Public Property _MAP As String
    Get
      Return mMAP
    End Get
    Set(ByVal value As String)
      mMAP = value
    End Set
  End Property

  Dim mPHONE As String
  Public Property _PHONE As String
    Get
      Return mPHONE
    End Get
    Set(ByVal value As String)
      mPHONE = value
    End Set
  End Property

  Dim mTNNAME As String
  Public Property _TNNAME As String
    Get
      Return mTNNAME
    End Get
    Set(ByVal value As String)
      mTNNAME = value
    End Set
  End Property

  Dim mHSTDST As String
  Public Property _HSTDST As String
    Get
      Return mHSTDST
    End Get
    Set(ByVal value As String)
      mHSTDST = value
    End Set
  End Property

  Dim mWETLND As String
  Public Property _WETLND As String
    Get
      Return mWETLND
    End Get
    Set(ByVal value As String)
      mWETLND = value
    End Set
  End Property

  Dim mARCLIC As String
  Public Property _ARCLIC As String
    Get
      Return mARCLIC
    End Get
    Set(ByVal value As String)
      mARCLIC = value
    End Set
  End Property

  Dim mARCEXP As Integer
  Public Property _ARCEXP As Integer
    Get
      Return mARCEXP
    End Get
    Set(ByVal value As Integer)
      mARCEXP = value
    End Set
  End Property

  Dim mCBYDNO As String
  Public Property _CBYDNO As String
    Get
      Return mCBYDNO
    End Get
    Set(ByVal value As String)
      mCBYDNO = value
    End Set
  End Property

  Dim mROADOP As String
  Public Property _ROADOP As String
    Get
      Return mROADOP
    End Get
    Set(ByVal value As String)
      mROADOP = value
    End Set
  End Property

  Dim mHNDDIG As String
  Public Property _HNDDIG As String
    Get
      Return mHNDDIG
    End Get
    Set(ByVal value As String)
      mHNDDIG = value
    End Set
  End Property

  Dim mCONSTY As String
  Public Property _CONSTY As String
    Get
      Return mCONSTY
    End Get
    Set(ByVal value As String)
      mCONSTY = value
    End Set
  End Property

  Dim mCURUSE As String
  Public Property _CURUSE As String
    Get
      Return mCURUSE
    End Get
    Set(ByVal value As String)
      mCURUSE = value
    End Set
  End Property

  Dim mPROUSE As String
  Public Property _PROUSE As String
    Get
      Return mPROUSE
    End Get
    Set(ByVal value As String)
      mPROUSE = value
    End Set
  End Property

  Dim mLEVEL As String
  Public Property _LEVEL As String
    Get
      Return mLEVEL
    End Get
    Set(ByVal value As String)
      mLEVEL = value
    End Set
  End Property

  Dim mUNIT As String
  Public Property _UNIT As String
    Get
      Return mUNIT
    End Get
    Set(ByVal value As String)
      mUNIT = value
    End Set
  End Property

  Dim mBLDGAS As String
  Public Property _BLDGAS As String
    Get
      Return mBLDGAS
    End Get
    Set(ByVal value As String)
      mBLDGAS = value
    End Set
  End Property

  Dim mELECCD As String
  Public Property _ELECCD As String
    Get
      Return mELECCD
    End Get
    Set(ByVal value As String)
      mELECCD = value
    End Set
  End Property

  Dim mELECYR As Integer
  Public Property _ELECYR As Integer
    Get
      Return mELECYR
    End Get
    Set(ByVal value As Integer)
      mELECYR = value
    End Set
  End Property

  Dim mELACCT As String
  Public Property _ELACCT As String
    Get
      Return mELACCT
    End Get
    Set(ByVal value As String)
      mELACCT = value
    End Set
  End Property

  Dim mHEATTY As String
  Public Property _HEATTY As String
    Get
      Return mHEATTY
    End Get
    Set(ByVal value As String)
      mHEATTY = value
    End Set
  End Property

  Dim mTANK As Integer
  Public Property _TANK As Integer
    Get
      Return mTANK
    End Get
    Set(ByVal value As Integer)
      mTANK = value
    End Set
  End Property

  Dim mTANKLO As String
  Public Property _TANKLO As String
    Get
      Return mTANKLO
    End Get
    Set(ByVal value As String)
      mTANKLO = value
    End Set
  End Property

  Dim mSGERE As String
  Public Property _SGERE As String
    Get
      Return mSGERE
    End Get
    Set(ByVal value As String)
      mSGERE = value
    End Set
  End Property

  Dim mSGSIDE As String
  Public Property _SGSIDE As String
    Get
      Return mSGSIDE
    End Get
    Set(ByVal value As String)
      mSGSIDE = value
    End Set
  End Property

  Dim mSGDIM As String
  Public Property _SGDIM As String
    Get
      Return mSGDIM
    End Get
    Set(ByVal value As String)
      mSGDIM = value
    End Set
  End Property

  Dim mSGSQ As Integer
  Public Property _SGSQ As Integer
    Get
      Return mSGSQ
    End Get
    Set(ByVal value As Integer)
      mSGSQ = value
    End Set
  End Property

  Dim mSGFAST As String
  Public Property _SGFAST As String
    Get
      Return mSGFAST
    End Get
    Set(ByVal value As String)
      mSGFAST = value
    End Set
  End Property

  Dim mSGELEC As String
  Public Property _SGELEC As String
    Get
      Return mSGELEC
    End Get
    Set(ByVal value As String)
      mSGELEC = value
    End Set
  End Property

  Dim mDMSTOR As Integer
  Public Property _DMSTOR As Integer
    Get
      Return mDMSTOR
    End Get
    Set(ByVal value As Integer)
      mDMSTOR = value
    End Set
  End Property

  Dim mDMSIZE As String
  Public Property _DMSIZE As String
    Get
      Return mDMSIZE
    End Get
    Set(ByVal value As String)
      mDMSIZE = value
    End Set
  End Property

  Dim mDMDATE As Integer
  Public Property _DMDATE As Integer
    Get
      Return mDMDATE
    End Get
    Set(ByVal value As Integer)
      mDMDATE = value
    End Set
  End Property

  Dim mDMPHON As String
  Public Property _DMPHON As String
    Get
      Return mDMPHON
    End Get
    Set(ByVal value As String)
      mDMPHON = value
    End Set
  End Property

  Dim mDMGAS As String
  Public Property _DMGAS As String
    Get
      Return mDMGAS
    End Get
    Set(ByVal value As String)
      mDMGAS = value
    End Set
  End Property

  Dim mDMELEC As String
  Public Property _DMELEC As String
    Get
      Return mDMELEC
    End Get
    Set(ByVal value As String)
      mDMELEC = value
    End Set
  End Property

  Dim mDMWPCA As String
  Public Property _DMWPCA As String
    Get
      Return mDMWPCA
    End Get
    Set(ByVal value As String)
      mDMWPCA = value
    End Set
  End Property

  Dim mDMSWR As String
  Public Property _DMSWR As String
    Get
      Return mDMSWR
    End Get
    Set(ByVal value As String)
      mDMSWR = value
    End Set
  End Property

  Dim mDMSEPT As String
  Public Property _DMSEPT As String
    Get
      Return mDMSEPT
    End Get
    Set(ByVal value As String)
      mDMSEPT = value
    End Set
  End Property

  Dim mPZSQ As Integer
  Public Property _PZSQ As Integer
    Get
      Return mPZSQ
    End Get
    Set(ByVal value As Integer)
      mPZSQ = value
    End Set
  End Property

  Dim mPZUSE As Integer
  Public Property _PZUSE As Integer
    Get
      Return mPZUSE
    End Get
    Set(ByVal value As Integer)
      mPZUSE = value
    End Set
  End Property

  Dim mPZFRNT As String
  Public Property _PZFRNT As String
    Get
      Return mPZFRNT
    End Get
    Set(ByVal value As String)
      mPZFRNT = value
    End Set
  End Property

  Dim mPZWATR As String
  Public Property _PZWATR As String
    Get
      Return mPZWATR
    End Get
    Set(ByVal value As String)
      mPZWATR = value
    End Set
  End Property

  Dim mPZAPP As String
  Public Property _PZAPP As String
    Get
      Return mPZAPP
    End Get
    Set(ByVal value As String)
      mPZAPP = value
    End Set
  End Property

  Dim mSUBUS As String
  Public Property _SUBUS As String
    Get
      Return mSUBUS
    End Get
    Set(ByVal value As String)
      mSUBUS = value
    End Set
  End Property

  Dim mSUHRS As String
  Public Property _SUHRS As String
    Get
      Return mSUHRS
    End Get
    Set(ByVal value As String)
      mSUHRS = value
    End Set
  End Property

  Dim mSUEMP As Integer
  Public Property _SUEMP As Integer
    Get
      Return mSUEMP
    End Get
    Set(ByVal value As Integer)
      mSUEMP = value
    End Set
  End Property

  Dim mSUDESC As String
  Public Property _SUDESC As String
    Get
      Return mSUDESC
    End Get
    Set(ByVal value As String)
      mSUDESC = value
    End Set
  End Property

  Dim mSUSIGN As String
  Public Property _SUSIGN As String
    Get
      Return mSUSIGN
    End Get
    Set(ByVal value As String)
      mSUSIGN = value
    End Set
  End Property

  Dim mCOID As Integer
  Public Property _COID As Integer
    Get
      Return mCOID
    End Get
    Set(ByVal value As Integer)
      mCOID = value
    End Set
  End Property

  Dim mCONAME As String
  Public Property _CONAME As String
    Get
      Return mCONAME
    End Get
    Set(ByVal value As String)
      mCONAME = value
    End Set
  End Property

  Dim mCOPHON As String
  Public Property _COPHON As String
    Get
      Return mCOPHON
    End Get
    Set(ByVal value As String)
      mCOPHON = value
    End Set
  End Property

  Dim mCOLIC As String
  Public Property _COLIC As String
    Get
      Return mCOLIC
    End Get
    Set(ByVal value As String)
      mCOLIC = value
    End Set
  End Property

  Dim mVALUE As Long
  Public Property _VALUE As Long
    Get
      Return mVALUE
    End Get
    Set(ByVal value As Long)
      mVALUE = value
    End Set
  End Property

  Dim mMISCHG As Decimal
  Public Property _MISCHG As Decimal
    Get
      Return mMISCHG
    End Get
    Set(ByVal value As Decimal)
      mMISCHG = value
    End Set
  End Property

  Dim mFEE As Decimal
  Public Property _FEE As Decimal
    Get
      Return mFEE
    End Get
    Set(ByVal value As Decimal)
      mFEE = value
    End Set
  End Property

  Dim mINNAME As String
  Public Property _INNAME As String
    Get
      Return mINNAME
    End Get
    Set(ByVal value As String)
      mINNAME = value
    End Set
  End Property

  Dim mINDATE As Integer
  Public Property _INDATE As Integer
    Get
      Return mINDATE
    End Get
    Set(ByVal value As Integer)
      mINDATE = value
    End Set
  End Property

  Dim mPAYTYP As String
  Public Property _PAYTYP As String
    Get
      Return mPAYTYP
    End Get
    Set(ByVal value As String)
      mPAYTYP = value
    End Set
  End Property

  Dim mPAYREF As String
  Public Property _PAYREF As String
    Get
      Return mPAYREF
    End Get
    Set(ByVal value As String)
      mPAYREF = value
    End Set
  End Property

  Dim mPRF As String
  Public Property _PRF As String
    Get
      Return mPRF
    End Get
    Set(ByVal value As String)
      mPRF = value
    End Set
  End Property
#End Region
End Class

