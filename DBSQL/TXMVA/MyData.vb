Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "TXMVA"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_CAT = string.empty
_LISTNo = 0
_TXYEAR = 0
_NAME = string.empty
_SNAME = string.empty
_ADD1 = string.empty
_ADD2 = string.empty
_CITY = string.empty
_STATE = string.empty
_ZIP5 = 0
_ZIP4 = 0
_DIST = 0
_PDST = 0
_XDATE = 0
_CLASS = 0
_REGNO = string.empty
_MAKE = string.empty
_YEAR = 0
_MODEL = string.empty
_BODY = string.empty
_VINNO = string.empty
_CYLAX = 0
_PCLR = string.empty
_SCLR = string.empty
_SEAT = 0
_LWT = 0
_GWT = 0
_VALUE = 0
_ASS = string.empty
_CYCLE = 0
_RCODE = 0
_OCODE = 0
_RATE = 0
_PCCOD = 0
_PREG = string.empty
_SCAP = 0
_TDATE = 0
_EXCD1 = string.empty
_EXCD2 = string.empty
_EXCD3 = string.empty
_EXCD4 = string.empty
_EXCD5 = string.empty
_EXAM1 = 0
_EXAM2 = 0
_EXAM3 = 0
_EXAM4 = 0
_EXAM5 = 0
_CCNO = 0
_CCGRS = 0
_CCEX = 0
_CCRS = string.empty
_CDATE = 0
_CCCD1 = string.empty
_CCCD2 = string.empty
_CCCD3 = string.empty
_CCCD4 = string.empty
_CCCD5 = string.empty
_CEXA1 = 0
_CEXA2 = 0
_CEXA3 = 0
_CEXA4 = 0
_CEXA5 = 0
_OCLS = 0
_OMAKE = string.empty
_OYEAR = 0
_OMOD = string.empty
_OBODY = string.empty
_OREGNo = string.empty
_OVIN = string.empty
_OASS = string.empty
_OVAL = 0
_OPVAL = 0
_PNET = 0
_OLIST = 0
_BTR = 0
_DNBTR = string.empty
_DTBTR = 0
_DOB = 0
_SSNo = 0
_SS2 = 0
_OID = string.empty
_BTC = string.empty
_LEASE = string.empty
_ORIG = 0
_TRVAL = 0
_LNVAL = 0
_MSRP = 0
_NADA = string.empty
_LETT = string.empty
_TYPE = string.empty
_TIN = string.empty
_RAD1 = string.empty
_RAD2 = string.empty
_RCTY = string.empty
_RST = string.empty
_RZ5 = 0
_RZ4 = 0
_LOCNO = string.empty
_LOC = string.empty
_PRF = string.empty
_CHDATE = 0
_CHTIME = 0

End Sub
  Public Sub GetOneRecordP(ByVal Wrklistno As Integer, ByVal Wrktxyear As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " and txyear = " & Wrktxyear
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
  Public Function GetIsPosted(ByVal WrkYear As Integer) As Integer
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkResult As Integer

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where txyear = " & WrkYear
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      objCommand = Nothing
      Conn.Close()
      If ds.Tables(0).Rows.Count = 0 Then
        WrkResult = 0
      Else
        WrkResult = 1
      End If
      Return WrkResult
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function PosData(ByVal Wrklistno As Integer, ByVal Wrktxyear As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where list# >= " & Wrklistno & " And txyear = " & Wrktxyear & " Order by list#"
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
      _CAT = .Item("CAT")
      _LISTNo = .Item("LIST#")
      _TXYEAR = .Item("TXYEAR")
      _NAME = .Item("NAME")
      _SNAME = .Item("SNAME")
      _ADD1 = .Item("ADD1")
      _ADD2 = .Item("ADD2")
      _CITY = .Item("CITY")
      _STATE = .Item("STATE")
      _ZIP5 = .Item("ZIP5")
      _ZIP4 = .Item("ZIP4")
      _DIST = .Item("DIST")
      _PDST = .Item("PDST")
      _XDATE = .Item("XDATE")
      _CLASS = .Item("CLASS")
      _REGNO = .Item("REGNO")
      _MAKE = .Item("MAKE")
      _YEAR = .Item("YEAR")
      _MODEL = .Item("MODEL")
      _BODY = .Item("BODY")
      _VINNO = .Item("VINNO")
      _CYLAX = .Item("CYLAX")
      _PCLR = .Item("PCLR")
      _SCLR = .Item("SCLR")
      _SEAT = .Item("SEAT")
      _LWT = .Item("LWT")
      _GWT = .Item("GWT")
      _VALUE = .Item("VALUE")
      _ASS = .Item("ASS")
      _CYCLE = .Item("CYCLE")
      _RCODE = .Item("RCODE")
      _OCODE = .Item("OCODE")
      _RATE = .Item("RATE")
      _PCCOD = .Item("PCCOD")
      _PREG = .Item("PREG")
      _SCAP = .Item("SCAP")
      _TDATE = .Item("TDATE")
      _EXCD1 = .Item("EXCD1")
      _EXCD2 = .Item("EXCD2")
      _EXCD3 = .Item("EXCD3")
      _EXCD4 = .Item("EXCD4")
      _EXCD5 = .Item("EXCD5")
      _EXAM1 = .Item("EXAM1")
      _EXAM2 = .Item("EXAM2")
      _EXAM3 = .Item("EXAM3")
      _EXAM4 = .Item("EXAM4")
      _EXAM5 = .Item("EXAM5")
      _CCNO = .Item("CCNO")
      _CCGRS = .Item("CCGRS")
      _CCEX = .Item("CCEX")
      _CCRS = .Item("CCRS")
      _CDATE = .Item("CDATE")
      _CCCD1 = .Item("CCCD1")
      _CCCD2 = .Item("CCCD2")
      _CCCD3 = .Item("CCCD3")
      _CCCD4 = .Item("CCCD4")
      _CCCD5 = .Item("CCCD5")
      _CEXA1 = .Item("CEXA1")
      _CEXA2 = .Item("CEXA2")
      _CEXA3 = .Item("CEXA3")
      _CEXA4 = .Item("CEXA4")
      _CEXA5 = .Item("CEXA5")
      _OCLS = .Item("OCLS")
      _OMAKE = .Item("OMAKE")
      _OYEAR = .Item("OYEAR")
      _OMOD = .Item("OMOD")
      _OBODY = .Item("OBODY")
      _OREGNo = .Item("OREG#")
      _OVIN = .Item("OVIN")
      _OASS = .Item("OASS")
      _OVAL = .Item("OVAL")
      _OPVAL = .Item("OPVAL")
      _PNET = .Item("PNET")
      _OLIST = .Item("OLIST")
      _BTR = .Item("BTR")
      _DNBTR = .Item("DNBTR")
      _DTBTR = .Item("DTBTR")
      _DOB = .Item("DOB")
      _SSNo = .Item("SS#")
      _SS2 = .Item("SS2")
      _OID = .Item("OID")
      _BTC = .Item("BTC")
      _LEASE = .Item("LEASE")
      _ORIG = .Item("ORIG")
      _TRVAL = .Item("TRVAL")
      _LNVAL = .Item("LNVAL")
      _MSRP = .Item("MSRP")
      _NADA = .Item("NADA")
      _LETT = .Item("LETT")
      _TYPE = .Item("TYPE")
      _TIN = .Item("TIN")
      _RAD1 = .Item("RAD1")
      _RAD2 = .Item("RAD2")
      _RCTY = .Item("RCTY")
      _RST = .Item("RST")
      _RZ5 = .Item("RZ5")
      _RZ4 = .Item("RZ4")
      _LOCNO = .Item("LOC#")
      _LOC = .Item("LOC")
      _PRF = .Item("PRF")
      _CHDATE = .Item("CHDATE")
      _CHTIME = .Item("CHTIME")

    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("CAT") = _CAT
      .Item("LIST#") = _LISTNo
      .Item("TXYEAR") = _TXYEAR
      .Item("NAME") = _NAME
      .Item("SNAME") = _SNAME
      .Item("ADD1") = _ADD1
      .Item("ADD2") = _ADD2
      .Item("CITY") = _CITY
      .Item("STATE") = _STATE
      .Item("ZIP5") = _ZIP5
      .Item("ZIP4") = _ZIP4
      .Item("DIST") = _DIST
      .Item("PDST") = _PDST
      .Item("XDATE") = _XDATE
      .Item("CLASS") = _CLASS
      .Item("REGNO") = _REGNO
      .Item("MAKE") = _MAKE
      .Item("YEAR") = _YEAR
      .Item("MODEL") = _MODEL
      .Item("BODY") = _BODY
      .Item("VINNO") = _VINNO
      .Item("CYLAX") = _CYLAX
      .Item("PCLR") = _PCLR
      .Item("SCLR") = _SCLR
      .Item("SEAT") = _SEAT
      .Item("LWT") = _LWT
      .Item("GWT") = _GWT
      .Item("VALUE") = _VALUE
      .Item("ASS") = _ASS
      .Item("CYCLE") = _CYCLE
      .Item("RCODE") = _RCODE
      .Item("OCODE") = _OCODE
      .Item("RATE") = _RATE
      .Item("PCCOD") = _PCCOD
      .Item("PREG") = _PREG
      .Item("SCAP") = _SCAP
      .Item("TDATE") = _TDATE
      .Item("EXCD1") = _EXCD1
      .Item("EXCD2") = _EXCD2
      .Item("EXCD3") = _EXCD3
      .Item("EXCD4") = _EXCD4
      .Item("EXCD5") = _EXCD5
      .Item("EXAM1") = _EXAM1
      .Item("EXAM2") = _EXAM2
      .Item("EXAM3") = _EXAM3
      .Item("EXAM4") = _EXAM4
      .Item("EXAM5") = _EXAM5
      .Item("CCNO") = _CCNO
      .Item("CCGRS") = _CCGRS
      .Item("CCEX") = _CCEX
      .Item("CCRS") = _CCRS
      .Item("CDATE") = _CDATE
      .Item("CCCD1") = _CCCD1
      .Item("CCCD2") = _CCCD2
      .Item("CCCD3") = _CCCD3
      .Item("CCCD4") = _CCCD4
      .Item("CCCD5") = _CCCD5
      .Item("CEXA1") = _CEXA1
      .Item("CEXA2") = _CEXA2
      .Item("CEXA3") = _CEXA3
      .Item("CEXA4") = _CEXA4
      .Item("CEXA5") = _CEXA5
      .Item("OCLS") = _OCLS
      .Item("OMAKE") = _OMAKE
      .Item("OYEAR") = _OYEAR
      .Item("OMOD") = _OMOD
      .Item("OBODY") = _OBODY
      .Item("OREG#") = _OREGNo
      .Item("OVIN") = _OVIN
      .Item("OASS") = _OASS
      .Item("OVAL") = _OVAL
      .Item("OPVAL") = _OPVAL
      .Item("PNET") = _PNET
      .Item("OLIST") = _OLIST
      .Item("BTR") = _BTR
      .Item("DNBTR") = _DNBTR
      .Item("DTBTR") = _DTBTR
      .Item("DOB") = _DOB
      .Item("SS#") = _SSNo
      .Item("SS2") = _SS2
      .Item("OID") = _OID
      .Item("BTC") = _BTC
      .Item("LEASE") = _LEASE
      .Item("ORIG") = _ORIG
      .Item("TRVAL") = _TRVAL
      .Item("LNVAL") = _LNVAL
      .Item("MSRP") = _MSRP
      .Item("NADA") = _NADA
      .Item("LETT") = _LETT
      .Item("TYPE") = _TYPE
      .Item("TIN") = _TIN
      .Item("RAD1") = _RAD1
      .Item("RAD2") = _RAD2
      .Item("RCTY") = _RCTY
      .Item("RST") = _RST
      .Item("RZ5") = _RZ5
      .Item("RZ4") = _RZ4
      .Item("LOC#") = _LOCNO
      .Item("LOC") = _LOC
      .Item("PRF") = _PRF
      .Item("CHDATE") = _CHDATE
      .Item("CHTIME") = _CHTIME

    End With
  End Sub
#End Region


#Region "Properties: Fields"

  Dim mCAT As String
  Public Property _CAT As String
    Get
      Return mCAT
    End Get
    Set(ByVal value As String)
      mCAT = value
    End Set
  End Property

  Dim mLISTNo As Integer
  Public Property _LISTNo As Integer
    Get
      Return mLISTNo
    End Get
    Set(ByVal value As Integer)
      mLISTNo = value
    End Set
  End Property

  Dim mTXYEAR As Integer
  Public Property _TXYEAR As Integer
    Get
      Return mTXYEAR
    End Get
    Set(ByVal value As Integer)
      mTXYEAR = value
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

  Dim mSNAME As String
  Public Property _SNAME As String
    Get
      Return mSNAME
    End Get
    Set(ByVal value As String)
      mSNAME = value
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

  Dim mADD2 As String
  Public Property _ADD2 As String
    Get
      Return mADD2
    End Get
    Set(ByVal value As String)
      mADD2 = value
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

  Dim mZIP5 As Integer
  Public Property _ZIP5 As Integer
    Get
      Return mZIP5
    End Get
    Set(ByVal value As Integer)
      mZIP5 = value
    End Set
  End Property

  Dim mZIP4 As Integer
  Public Property _ZIP4 As Integer
    Get
      Return mZIP4
    End Get
    Set(ByVal value As Integer)
      mZIP4 = value
    End Set
  End Property

  Dim mDIST As Integer
  Public Property _DIST As Integer
    Get
      Return mDIST
    End Get
    Set(ByVal value As Integer)
      mDIST = value
    End Set
  End Property

  Dim mPDST As Integer
  Public Property _PDST As Integer
    Get
      Return mPDST
    End Get
    Set(ByVal value As Integer)
      mPDST = value
    End Set
  End Property

  Dim mXDATE As Integer
  Public Property _XDATE As Integer
    Get
      Return mXDATE
    End Get
    Set(ByVal value As Integer)
      mXDATE = value
    End Set
  End Property

  Dim mCLASS As Integer
  Public Property _CLASS As Integer
    Get
      Return mCLASS
    End Get
    Set(ByVal value As Integer)
      mCLASS = value
    End Set
  End Property

  Dim mREGNO As String
  Public Property _REGNO As String
    Get
      Return mREGNO
    End Get
    Set(ByVal value As String)
      mREGNO = value
    End Set
  End Property

  Dim mMAKE As String
  Public Property _MAKE As String
    Get
      Return mMAKE
    End Get
    Set(ByVal value As String)
      mMAKE = value
    End Set
  End Property

  Dim mYEAR As Integer
  Public Property _YEAR As Integer
    Get
      Return mYEAR
    End Get
    Set(ByVal value As Integer)
      mYEAR = value
    End Set
  End Property

  Dim mMODEL As String
  Public Property _MODEL As String
    Get
      Return mMODEL
    End Get
    Set(ByVal value As String)
      mMODEL = value
    End Set
  End Property

  Dim mBODY As String
  Public Property _BODY As String
    Get
      Return mBODY
    End Get
    Set(ByVal value As String)
      mBODY = value
    End Set
  End Property

  Dim mVINNO As String
  Public Property _VINNO As String
    Get
      Return mVINNO
    End Get
    Set(ByVal value As String)
      mVINNO = value
    End Set
  End Property

  Dim mCYLAX As Integer
  Public Property _CYLAX As Integer
    Get
      Return mCYLAX
    End Get
    Set(ByVal value As Integer)
      mCYLAX = value
    End Set
  End Property

  Dim mPCLR As String
  Public Property _PCLR As String
    Get
      Return mPCLR
    End Get
    Set(ByVal value As String)
      mPCLR = value
    End Set
  End Property

  Dim mSCLR As String
  Public Property _SCLR As String
    Get
      Return mSCLR
    End Get
    Set(ByVal value As String)
      mSCLR = value
    End Set
  End Property

  Dim mSEAT As Integer
  Public Property _SEAT As Integer
    Get
      Return mSEAT
    End Get
    Set(ByVal value As Integer)
      mSEAT = value
    End Set
  End Property

  Dim mLWT As Integer
  Public Property _LWT As Integer
    Get
      Return mLWT
    End Get
    Set(ByVal value As Integer)
      mLWT = value
    End Set
  End Property

  Dim mGWT As Integer
  Public Property _GWT As Integer
    Get
      Return mGWT
    End Get
    Set(ByVal value As Integer)
      mGWT = value
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

  Dim mASS As String
  Public Property _ASS As String
    Get
      Return mASS
    End Get
    Set(ByVal value As String)
      mASS = value
    End Set
  End Property

  Dim mCYCLE As Integer
  Public Property _CYCLE As Integer
    Get
      Return mCYCLE
    End Get
    Set(ByVal value As Integer)
      mCYCLE = value
    End Set
  End Property

  Dim mRCODE As Integer
  Public Property _RCODE As Integer
    Get
      Return mRCODE
    End Get
    Set(ByVal value As Integer)
      mRCODE = value
    End Set
  End Property

  Dim mOCODE As Integer
  Public Property _OCODE As Integer
    Get
      Return mOCODE
    End Get
    Set(ByVal value As Integer)
      mOCODE = value
    End Set
  End Property

  Dim mRATE As Integer
  Public Property _RATE As Integer
    Get
      Return mRATE
    End Get
    Set(ByVal value As Integer)
      mRATE = value
    End Set
  End Property

  Dim mPCCOD As Integer
  Public Property _PCCOD As Integer
    Get
      Return mPCCOD
    End Get
    Set(ByVal value As Integer)
      mPCCOD = value
    End Set
  End Property

  Dim mPREG As String
  Public Property _PREG As String
    Get
      Return mPREG
    End Get
    Set(ByVal value As String)
      mPREG = value
    End Set
  End Property

  Dim mSCAP As Integer
  Public Property _SCAP As Integer
    Get
      Return mSCAP
    End Get
    Set(ByVal value As Integer)
      mSCAP = value
    End Set
  End Property

  Dim mTDATE As Integer
  Public Property _TDATE As Integer
    Get
      Return mTDATE
    End Get
    Set(ByVal value As Integer)
      mTDATE = value
    End Set
  End Property

  Dim mEXCD1 As String
  Public Property _EXCD1 As String
    Get
      Return mEXCD1
    End Get
    Set(ByVal value As String)
      mEXCD1 = value
    End Set
  End Property

  Dim mEXCD2 As String
  Public Property _EXCD2 As String
    Get
      Return mEXCD2
    End Get
    Set(ByVal value As String)
      mEXCD2 = value
    End Set
  End Property

  Dim mEXCD3 As String
  Public Property _EXCD3 As String
    Get
      Return mEXCD3
    End Get
    Set(ByVal value As String)
      mEXCD3 = value
    End Set
  End Property

  Dim mEXCD4 As String
  Public Property _EXCD4 As String
    Get
      Return mEXCD4
    End Get
    Set(ByVal value As String)
      mEXCD4 = value
    End Set
  End Property

  Dim mEXCD5 As String
  Public Property _EXCD5 As String
    Get
      Return mEXCD5
    End Get
    Set(ByVal value As String)
      mEXCD5 = value
    End Set
  End Property

  Dim mEXAM1 As Integer
  Public Property _EXAM1 As Integer
    Get
      Return mEXAM1
    End Get
    Set(ByVal value As Integer)
      mEXAM1 = value
    End Set
  End Property

  Dim mEXAM2 As Integer
  Public Property _EXAM2 As Integer
    Get
      Return mEXAM2
    End Get
    Set(ByVal value As Integer)
      mEXAM2 = value
    End Set
  End Property

  Dim mEXAM3 As Integer
  Public Property _EXAM3 As Integer
    Get
      Return mEXAM3
    End Get
    Set(ByVal value As Integer)
      mEXAM3 = value
    End Set
  End Property

  Dim mEXAM4 As Integer
  Public Property _EXAM4 As Integer
    Get
      Return mEXAM4
    End Get
    Set(ByVal value As Integer)
      mEXAM4 = value
    End Set
  End Property

  Dim mEXAM5 As Integer
  Public Property _EXAM5 As Integer
    Get
      Return mEXAM5
    End Get
    Set(ByVal value As Integer)
      mEXAM5 = value
    End Set
  End Property

  Dim mCCNO As Integer
  Public Property _CCNO As Integer
    Get
      Return mCCNO
    End Get
    Set(ByVal value As Integer)
      mCCNO = value
    End Set
  End Property

  Dim mCCGRS As Long
  Public Property _CCGRS As Long
    Get
      Return mCCGRS
    End Get
    Set(ByVal value As Long)
      mCCGRS = value
    End Set
  End Property

  Dim mCCEX As Long
  Public Property _CCEX As Long
    Get
      Return mCCEX
    End Get
    Set(ByVal value As Long)
      mCCEX = value
    End Set
  End Property

  Dim mCCRS As String
  Public Property _CCRS As String
    Get
      Return mCCRS
    End Get
    Set(ByVal value As String)
      mCCRS = value
    End Set
  End Property

  Dim mCDATE As Integer
  Public Property _CDATE As Integer
    Get
      Return mCDATE
    End Get
    Set(ByVal value As Integer)
      mCDATE = value
    End Set
  End Property

  Dim mCCCD1 As String
  Public Property _CCCD1 As String
    Get
      Return mCCCD1
    End Get
    Set(ByVal value As String)
      mCCCD1 = value
    End Set
  End Property

  Dim mCCCD2 As String
  Public Property _CCCD2 As String
    Get
      Return mCCCD2
    End Get
    Set(ByVal value As String)
      mCCCD2 = value
    End Set
  End Property

  Dim mCCCD3 As String
  Public Property _CCCD3 As String
    Get
      Return mCCCD3
    End Get
    Set(ByVal value As String)
      mCCCD3 = value
    End Set
  End Property

  Dim mCCCD4 As String
  Public Property _CCCD4 As String
    Get
      Return mCCCD4
    End Get
    Set(ByVal value As String)
      mCCCD4 = value
    End Set
  End Property

  Dim mCCCD5 As String
  Public Property _CCCD5 As String
    Get
      Return mCCCD5
    End Get
    Set(ByVal value As String)
      mCCCD5 = value
    End Set
  End Property

  Dim mCEXA1 As Integer
  Public Property _CEXA1 As Integer
    Get
      Return mCEXA1
    End Get
    Set(ByVal value As Integer)
      mCEXA1 = value
    End Set
  End Property

  Dim mCEXA2 As Integer
  Public Property _CEXA2 As Integer
    Get
      Return mCEXA2
    End Get
    Set(ByVal value As Integer)
      mCEXA2 = value
    End Set
  End Property

  Dim mCEXA3 As Integer
  Public Property _CEXA3 As Integer
    Get
      Return mCEXA3
    End Get
    Set(ByVal value As Integer)
      mCEXA3 = value
    End Set
  End Property

  Dim mCEXA4 As Integer
  Public Property _CEXA4 As Integer
    Get
      Return mCEXA4
    End Get
    Set(ByVal value As Integer)
      mCEXA4 = value
    End Set
  End Property

  Dim mCEXA5 As Integer
  Public Property _CEXA5 As Integer
    Get
      Return mCEXA5
    End Get
    Set(ByVal value As Integer)
      mCEXA5 = value
    End Set
  End Property

  Dim mOCLS As Integer
  Public Property _OCLS As Integer
    Get
      Return mOCLS
    End Get
    Set(ByVal value As Integer)
      mOCLS = value
    End Set
  End Property

  Dim mOMAKE As String
  Public Property _OMAKE As String
    Get
      Return mOMAKE
    End Get
    Set(ByVal value As String)
      mOMAKE = value
    End Set
  End Property

  Dim mOYEAR As Integer
  Public Property _OYEAR As Integer
    Get
      Return mOYEAR
    End Get
    Set(ByVal value As Integer)
      mOYEAR = value
    End Set
  End Property

  Dim mOMOD As String
  Public Property _OMOD As String
    Get
      Return mOMOD
    End Get
    Set(ByVal value As String)
      mOMOD = value
    End Set
  End Property

  Dim mOBODY As String
  Public Property _OBODY As String
    Get
      Return mOBODY
    End Get
    Set(ByVal value As String)
      mOBODY = value
    End Set
  End Property

  Dim mOREGNo As String
  Public Property _OREGNo As String
    Get
      Return mOREGNo
    End Get
    Set(ByVal value As String)
      mOREGNo = value
    End Set
  End Property

  Dim mOVIN As String
  Public Property _OVIN As String
    Get
      Return mOVIN
    End Get
    Set(ByVal value As String)
      mOVIN = value
    End Set
  End Property

  Dim mOASS As String
  Public Property _OASS As String
    Get
      Return mOASS
    End Get
    Set(ByVal value As String)
      mOASS = value
    End Set
  End Property

  Dim mOVAL As Long
  Public Property _OVAL As Long
    Get
      Return mOVAL
    End Get
    Set(ByVal value As Long)
      mOVAL = value
    End Set
  End Property

  Dim mOPVAL As Long
  Public Property _OPVAL As Long
    Get
      Return mOPVAL
    End Get
    Set(ByVal value As Long)
      mOPVAL = value
    End Set
  End Property

  Dim mPNET As Long
  Public Property _PNET As Long
    Get
      Return mPNET
    End Get
    Set(ByVal value As Long)
      mPNET = value
    End Set
  End Property

  Dim mOLIST As Integer
  Public Property _OLIST As Integer
    Get
      Return mOLIST
    End Get
    Set(ByVal value As Integer)
      mOLIST = value
    End Set
  End Property

  Dim mBTR As Long
  Public Property _BTR As Long
    Get
      Return mBTR
    End Get
    Set(ByVal value As Long)
      mBTR = value
    End Set
  End Property

  Dim mDNBTR As String
  Public Property _DNBTR As String
    Get
      Return mDNBTR
    End Get
    Set(ByVal value As String)
      mDNBTR = value
    End Set
  End Property

  Dim mDTBTR As Integer
  Public Property _DTBTR As Integer
    Get
      Return mDTBTR
    End Get
    Set(ByVal value As Integer)
      mDTBTR = value
    End Set
  End Property

  Dim mDOB As Integer
  Public Property _DOB As Integer
    Get
      Return mDOB
    End Get
    Set(ByVal value As Integer)
      mDOB = value
    End Set
  End Property

  Dim mSSNo As Long
  Public Property _SSNo As Long
    Get
      Return mSSNo
    End Get
    Set(ByVal value As Long)
      mSSNo = value
    End Set
  End Property

  Dim mSS2 As Long
  Public Property _SS2 As Long
    Get
      Return mSS2
    End Get
    Set(ByVal value As Long)
      mSS2 = value
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

  Dim mBTC As String
  Public Property _BTC As String
    Get
      Return mBTC
    End Get
    Set(ByVal value As String)
      mBTC = value
    End Set
  End Property

  Dim mLEASE As String
  Public Property _LEASE As String
    Get
      Return mLEASE
    End Get
    Set(ByVal value As String)
      mLEASE = value
    End Set
  End Property

  Dim mORIG As Long
  Public Property _ORIG As Long
    Get
      Return mORIG
    End Get
    Set(ByVal value As Long)
      mORIG = value
    End Set
  End Property

  Dim mTRVAL As Long
  Public Property _TRVAL As Long
    Get
      Return mTRVAL
    End Get
    Set(ByVal value As Long)
      mTRVAL = value
    End Set
  End Property

  Dim mLNVAL As Long
  Public Property _LNVAL As Long
    Get
      Return mLNVAL
    End Get
    Set(ByVal value As Long)
      mLNVAL = value
    End Set
  End Property

  Dim mMSRP As Long
  Public Property _MSRP As Long
    Get
      Return mMSRP
    End Get
    Set(ByVal value As Long)
      mMSRP = value
    End Set
  End Property

  Dim mNADA As String
  Public Property _NADA As String
    Get
      Return mNADA
    End Get
    Set(ByVal value As String)
      mNADA = value
    End Set
  End Property

  Dim mLETT As String
  Public Property _LETT As String
    Get
      Return mLETT
    End Get
    Set(ByVal value As String)
      mLETT = value
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

  Dim mTIN As String
  Public Property _TIN As String
    Get
      Return mTIN
    End Get
    Set(ByVal value As String)
      mTIN = value
    End Set
  End Property

  Dim mRAD1 As String
  Public Property _RAD1 As String
    Get
      Return mRAD1
    End Get
    Set(ByVal value As String)
      mRAD1 = value
    End Set
  End Property

  Dim mRAD2 As String
  Public Property _RAD2 As String
    Get
      Return mRAD2
    End Get
    Set(ByVal value As String)
      mRAD2 = value
    End Set
  End Property

  Dim mRCTY As String
  Public Property _RCTY As String
    Get
      Return mRCTY
    End Get
    Set(ByVal value As String)
      mRCTY = value
    End Set
  End Property

  Dim mRST As String
  Public Property _RST As String
    Get
      Return mRST
    End Get
    Set(ByVal value As String)
      mRST = value
    End Set
  End Property

  Dim mRZ5 As Integer
  Public Property _RZ5 As Integer
    Get
      Return mRZ5
    End Get
    Set(ByVal value As Integer)
      mRZ5 = value
    End Set
  End Property

  Dim mRZ4 As Integer
  Public Property _RZ4 As Integer
    Get
      Return mRZ4
    End Get
    Set(ByVal value As Integer)
      mRZ4 = value
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

  Dim mPRF As String
  Public Property _PRF As String
    Get
      Return mPRF
    End Get
    Set(ByVal value As String)
      mPRF = value
    End Set
  End Property

  Dim mCHDATE As Integer
  Public Property _CHDATE As Integer
    Get
      Return mCHDATE
    End Get
    Set(ByVal value As Integer)
      mCHDATE = value
    End Set
  End Property

  Dim mCHTIME As Integer
  Public Property _CHTIME As Integer
    Get
      Return mCHTIME
    End Get
    Set(ByVal value As Integer)
      mCHTIME = value
    End Set
  End Property

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
#End Region
End Class


