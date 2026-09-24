Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Const cFileName As String = "TXSUPP"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Function GetQry(ByVal WrkSort As String, ByVal WrkQry As String, ByVal NumRecs As Long) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    RecordNotFound = False
    StrSQL = "Select " & WrkTop & " * from " & cFileName
    If WrkQry <> String.Empty Then
      StrSQL = StrSQL & " where " & WrkQry
    End If
    If WrkSort <> String.Empty Then
      StrSQL = StrSQL & " order by " & WrkSort
    End If
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)

    If ds.Tables(0).Rows.Count = 0 Then
      RecordNotFound = True
    End If
    objCommand = Nothing
    Conn.Close()
    Return ds
  End Function
  Public Sub OpenQry(ByVal WrkSort As String, ByVal WrkQry As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand

    StrSQL = "Select * from " & cFileName
    If WrkQry <> String.Empty Then
      StrSQL = StrSQL & " where " & WrkQry
    End If
    If WrkSort <> String.Empty Then
      StrSQL = StrSQL & " order by " & WrkSort
    End If
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    objReader = objCommand.ExecuteReader()
  End Sub
  Public Sub ReadQry()
    Dim Good As Boolean

    IsEOF = False
    Good = objReader.Read
    If Good Then
      GetFields()
    Else
      IsEOF = True
      objReader.Close()
    End If
  End Sub
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
  End Sub
#End Region

#Region "Properties: Get/Put"
  Public Sub GetFields()
    With objReader
      _CAT = .Item("CAT")
      _MAKE = .Item("MAKE")
      _YEAR = .Item("YEAR")
      _MODEL = .Item("MODEL")
      _BODY = .Item("BODY")
      _DIST = .Item("DIST")
      _NAME = .Item("NAME")
      _SNAME = .Item("SNAME")
      _ADD1 = .Item("ADD1")
      _ADD2 = .Item("ADD2")
      _CITY = .Item("CITY")
      _STATE = .Item("STATE")
      _ZIP5 = .Item("ZIP5")
      _ZIP4 = .Item("ZIP4")
      _XDATE = .Item("XDATE")
      _CLASS = .Item("CLASS")
      _REGNO = .Item("REGNO")
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
      _LISTNo = .Item("LIST#")
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
      _OREGNo = .Item("OREG#")
      _OVIN = .Item("OVIN")
      _OASS = .Item("OASS")
      _OVAL = .Item("OVAL")
      _OPVAL = .Item("OPVAL")
      _PVAL = .Item("PVAL")
      _PNET = .Item("PNET")
      _OLIST = .Item("OLIST")
      _BTR = .Item("BTR")
      _DOB = .Item("DOB")
      _SSNo = .Item("SS#")
      _BTC = .Item("BTC")
      _LEASE = .Item("LEASE")
      _ORIG = .Item("ORIG")
      _TRVAL = .Item("TRVAL")
      _LNVAL = .Item("LNVAL")
      _MSRP = .Item("MSRP")
      _NADA = .Item("NADA")
      _PRF = .Item("PRF")
      _CHDATE = .Item("CHDATE")
      _CHTIME = .Item("CHTIME")
      _LETT = .Item("LETT")
      _TYPE = .Item("TYPE")
      _PDST = .Item("PDST")
      _OID = .Item("OID")
      _SS2 = .Item("SS2")
      _TIN = .Item("TIN")
      _RAD1 = .Item("RAD1")
      _RAD2 = .Item("RAD2")
      _RCTY = .Item("RCTY")
      _RST = .Item("RST")
      _RZ5 = .Item("RZ5")
      _RZ4 = .Item("RZ4")
      _LOCNO = .Item("LOC#")
      _LOC = .Item("LOC")
      _DNBTR = .Item("DNBTR")
      _DTBTR = .Item("DTBTR")
    End With
  End Sub

#End Region


#Region "Properties: Fields"

  Dim mCAT as string 
Public Property _CAT as string   
    Get
        Return mCAT
    End Get
    set(byval value as string)
        mCAT = value
    End Set
End Property

Dim mMAKE as string 
Public Property _MAKE as string   
    Get
        Return mMAKE
    End Get
    set(byval value as string)
        mMAKE = value
    End Set
End Property

Dim mYEAR  as integer 
Public Property _YEAR  as integer   
    Get
        Return mYEAR
    End Get
    set(byval value as integer)
        mYEAR = value
    End Set
End Property

Dim mMODEL as string 
Public Property _MODEL as string   
    Get
        Return mMODEL
    End Get
    set(byval value as string)
        mMODEL = value
    End Set
End Property

Dim mBODY as string 
Public Property _BODY as string   
    Get
        Return mBODY
    End Get
    set(byval value as string)
        mBODY = value
    End Set
End Property

Dim mDIST  as integer 
Public Property _DIST  as integer   
    Get
        Return mDIST
    End Get
    set(byval value as integer)
        mDIST = value
    End Set
End Property

Dim mNAME as string 
Public Property _NAME as string   
    Get
        Return mNAME
    End Get
    set(byval value as string)
        mNAME = value
    End Set
End Property

Dim mSNAME as string 
Public Property _SNAME as string   
    Get
        Return mSNAME
    End Get
    set(byval value as string)
        mSNAME = value
    End Set
End Property

Dim mADD1 as string 
Public Property _ADD1 as string   
    Get
        Return mADD1
    End Get
    set(byval value as string)
        mADD1 = value
    End Set
End Property

Dim mADD2 as string 
Public Property _ADD2 as string   
    Get
        Return mADD2
    End Get
    set(byval value as string)
        mADD2 = value
    End Set
End Property

Dim mCITY as string 
Public Property _CITY as string   
    Get
        Return mCITY
    End Get
    set(byval value as string)
        mCITY = value
    End Set
End Property

Dim mSTATE as string 
Public Property _STATE as string   
    Get
        Return mSTATE
    End Get
    set(byval value as string)
        mSTATE = value
    End Set
End Property

Dim mZIP5  as integer 
Public Property _ZIP5  as integer   
    Get
        Return mZIP5
    End Get
    set(byval value as integer)
        mZIP5 = value
    End Set
End Property

Dim mZIP4  as integer 
Public Property _ZIP4  as integer   
    Get
        Return mZIP4
    End Get
    set(byval value as integer)
        mZIP4 = value
    End Set
End Property

Dim mXDATE  as integer 
Public Property _XDATE  as integer   
    Get
        Return mXDATE
    End Get
    set(byval value as integer)
        mXDATE = value
    End Set
End Property

Dim mCLASS  as integer 
Public Property _CLASS  as integer   
    Get
        Return mCLASS
    End Get
    set(byval value as integer)
        mCLASS = value
    End Set
End Property

Dim mREGNO as string 
Public Property _REGNO as string   
    Get
        Return mREGNO
    End Get
    set(byval value as string)
        mREGNO = value
    End Set
End Property

Dim mVINNO as string 
Public Property _VINNO as string   
    Get
        Return mVINNO
    End Get
    set(byval value as string)
        mVINNO = value
    End Set
End Property

Dim mCYLAX  as integer 
Public Property _CYLAX  as integer   
    Get
        Return mCYLAX
    End Get
    set(byval value as integer)
        mCYLAX = value
    End Set
End Property

Dim mPCLR as string 
Public Property _PCLR as string   
    Get
        Return mPCLR
    End Get
    set(byval value as string)
        mPCLR = value
    End Set
End Property

Dim mSCLR as string 
Public Property _SCLR as string   
    Get
        Return mSCLR
    End Get
    set(byval value as string)
        mSCLR = value
    End Set
End Property

Dim mSEAT  as integer 
Public Property _SEAT  as integer   
    Get
        Return mSEAT
    End Get
    set(byval value as integer)
        mSEAT = value
    End Set
End Property

Dim mLWT  as integer 
Public Property _LWT  as integer   
    Get
        Return mLWT
    End Get
    set(byval value as integer)
        mLWT = value
    End Set
End Property

Dim mGWT  as integer 
Public Property _GWT  as integer   
    Get
        Return mGWT
    End Get
    set(byval value as integer)
        mGWT = value
    End Set
End Property

Dim mVALUE  as long
Public Property _VALUE  as long  
    Get
        Return mVALUE
    End Get
    set(byval value as long)
        mVALUE = value
    End Set
End Property

Dim mASS as string 
Public Property _ASS as string   
    Get
        Return mASS
    End Get
    set(byval value as string)
        mASS = value
    End Set
End Property

Dim mCYCLE  as integer 
Public Property _CYCLE  as integer   
    Get
        Return mCYCLE
    End Get
    set(byval value as integer)
        mCYCLE = value
    End Set
End Property

Dim mRCODE  as integer 
Public Property _RCODE  as integer   
    Get
        Return mRCODE
    End Get
    set(byval value as integer)
        mRCODE = value
    End Set
End Property

Dim mOCODE  as integer 
Public Property _OCODE  as integer   
    Get
        Return mOCODE
    End Get
    set(byval value as integer)
        mOCODE = value
    End Set
End Property

Dim mRATE  as integer 
Public Property _RATE  as integer   
    Get
        Return mRATE
    End Get
    set(byval value as integer)
        mRATE = value
    End Set
End Property

Dim mLISTNo  as integer 
Public Property _LISTNo  as integer   
    Get
        Return mLISTNo
    End Get
    set(byval value as integer)
        mLISTNo = value
    End Set
End Property

Dim mPCCOD  as integer 
Public Property _PCCOD  as integer   
    Get
        Return mPCCOD
    End Get
    set(byval value as integer)
        mPCCOD = value
    End Set
End Property

Dim mPREG as string 
Public Property _PREG as string   
    Get
        Return mPREG
    End Get
    set(byval value as string)
        mPREG = value
    End Set
End Property

Dim mSCAP  as integer 
Public Property _SCAP  as integer   
    Get
        Return mSCAP
    End Get
    set(byval value as integer)
        mSCAP = value
    End Set
End Property

Dim mTDATE  as integer 
Public Property _TDATE  as integer   
    Get
        Return mTDATE
    End Get
    set(byval value as integer)
        mTDATE = value
    End Set
End Property

Dim mEXCD1 as string 
Public Property _EXCD1 as string   
    Get
        Return mEXCD1
    End Get
    set(byval value as string)
        mEXCD1 = value
    End Set
End Property

Dim mEXCD2 as string 
Public Property _EXCD2 as string   
    Get
        Return mEXCD2
    End Get
    set(byval value as string)
        mEXCD2 = value
    End Set
End Property

Dim mEXCD3 as string 
Public Property _EXCD3 as string   
    Get
        Return mEXCD3
    End Get
    set(byval value as string)
        mEXCD3 = value
    End Set
End Property

Dim mEXCD4 as string 
Public Property _EXCD4 as string   
    Get
        Return mEXCD4
    End Get
    set(byval value as string)
        mEXCD4 = value
    End Set
End Property

Dim mEXCD5 as string 
Public Property _EXCD5 as string   
    Get
        Return mEXCD5
    End Get
    set(byval value as string)
        mEXCD5 = value
    End Set
End Property

Dim mEXAM1  as integer 
Public Property _EXAM1  as integer   
    Get
        Return mEXAM1
    End Get
    set(byval value as integer)
        mEXAM1 = value
    End Set
End Property

Dim mEXAM2  as integer 
Public Property _EXAM2  as integer   
    Get
        Return mEXAM2
    End Get
    set(byval value as integer)
        mEXAM2 = value
    End Set
End Property

Dim mEXAM3  as integer 
Public Property _EXAM3  as integer   
    Get
        Return mEXAM3
    End Get
    set(byval value as integer)
        mEXAM3 = value
    End Set
End Property

Dim mEXAM4  as integer 
Public Property _EXAM4  as integer   
    Get
        Return mEXAM4
    End Get
    set(byval value as integer)
        mEXAM4 = value
    End Set
End Property

Dim mEXAM5  as integer 
Public Property _EXAM5  as integer   
    Get
        Return mEXAM5
    End Get
    set(byval value as integer)
        mEXAM5 = value
    End Set
End Property

Dim mCCNO  as integer 
Public Property _CCNO  as integer   
    Get
        Return mCCNO
    End Get
    set(byval value as integer)
        mCCNO = value
    End Set
End Property

Dim mCCGRS  as long
Public Property _CCGRS  as long  
    Get
        Return mCCGRS
    End Get
    set(byval value as long)
        mCCGRS = value
    End Set
End Property

Dim mCCEX  as long
Public Property _CCEX  as long  
    Get
        Return mCCEX
    End Get
    set(byval value as long)
        mCCEX = value
    End Set
End Property

Dim mCCRS as string 
Public Property _CCRS as string   
    Get
        Return mCCRS
    End Get
    set(byval value as string)
        mCCRS = value
    End Set
End Property

Dim mCDATE  as integer 
Public Property _CDATE  as integer   
    Get
        Return mCDATE
    End Get
    set(byval value as integer)
        mCDATE = value
    End Set
End Property

Dim mCCCD1 as string 
Public Property _CCCD1 as string   
    Get
        Return mCCCD1
    End Get
    set(byval value as string)
        mCCCD1 = value
    End Set
End Property

Dim mCCCD2 as string 
Public Property _CCCD2 as string   
    Get
        Return mCCCD2
    End Get
    set(byval value as string)
        mCCCD2 = value
    End Set
End Property

Dim mCCCD3 as string 
Public Property _CCCD3 as string   
    Get
        Return mCCCD3
    End Get
    set(byval value as string)
        mCCCD3 = value
    End Set
End Property

Dim mCCCD4 as string 
Public Property _CCCD4 as string   
    Get
        Return mCCCD4
    End Get
    set(byval value as string)
        mCCCD4 = value
    End Set
End Property

Dim mCCCD5 as string 
Public Property _CCCD5 as string   
    Get
        Return mCCCD5
    End Get
    set(byval value as string)
        mCCCD5 = value
    End Set
End Property

Dim mCEXA1  as integer 
Public Property _CEXA1  as integer   
    Get
        Return mCEXA1
    End Get
    set(byval value as integer)
        mCEXA1 = value
    End Set
End Property

Dim mCEXA2  as integer 
Public Property _CEXA2  as integer   
    Get
        Return mCEXA2
    End Get
    set(byval value as integer)
        mCEXA2 = value
    End Set
End Property

Dim mCEXA3  as integer 
Public Property _CEXA3  as integer   
    Get
        Return mCEXA3
    End Get
    set(byval value as integer)
        mCEXA3 = value
    End Set
End Property

Dim mCEXA4  as integer 
Public Property _CEXA4  as integer   
    Get
        Return mCEXA4
    End Get
    set(byval value as integer)
        mCEXA4 = value
    End Set
End Property

Dim mCEXA5  as integer 
Public Property _CEXA5  as integer   
    Get
        Return mCEXA5
    End Get
    set(byval value as integer)
        mCEXA5 = value
    End Set
End Property

Dim mOCLS  as integer 
Public Property _OCLS  as integer   
    Get
        Return mOCLS
    End Get
    set(byval value as integer)
        mOCLS = value
    End Set
End Property

Dim mOMAKE as string 
Public Property _OMAKE as string   
    Get
        Return mOMAKE
    End Get
    set(byval value as string)
        mOMAKE = value
    End Set
End Property

Dim mOYEAR  as integer 
Public Property _OYEAR  as integer   
    Get
        Return mOYEAR
    End Get
    set(byval value as integer)
        mOYEAR = value
    End Set
End Property

Dim mOMOD as string 
Public Property _OMOD as string   
    Get
        Return mOMOD
    End Get
    set(byval value as string)
        mOMOD = value
    End Set
End Property

Dim mOREGNo as string 
Public Property _OREGNo as string   
    Get
        Return mOREGNo
    End Get
    set(byval value as string)
        mOREGNo = value
    End Set
End Property

Dim mOVIN as string 
Public Property _OVIN as string   
    Get
        Return mOVIN
    End Get
    set(byval value as string)
        mOVIN = value
    End Set
End Property

Dim mOASS as string 
Public Property _OASS as string   
    Get
        Return mOASS
    End Get
    set(byval value as string)
        mOASS = value
    End Set
End Property

Dim mOVAL  as long
Public Property _OVAL  as long  
    Get
        Return mOVAL
    End Get
    set(byval value as long)
        mOVAL = value
    End Set
End Property

Dim mOPVAL  as long
Public Property _OPVAL  as long  
    Get
        Return mOPVAL
    End Get
    set(byval value as long)
        mOPVAL = value
    End Set
End Property

Dim mPVAL  as long
Public Property _PVAL  as long  
    Get
        Return mPVAL
    End Get
    set(byval value as long)
        mPVAL = value
    End Set
End Property

Dim mPNET  as long
Public Property _PNET  as long  
    Get
        Return mPNET
    End Get
    set(byval value as long)
        mPNET = value
    End Set
End Property

Dim mOLIST  as integer 
Public Property _OLIST  as integer   
    Get
        Return mOLIST
    End Get
    set(byval value as integer)
        mOLIST = value
    End Set
End Property

Dim mBTR  as long
Public Property _BTR  as long  
    Get
        Return mBTR
    End Get
    set(byval value as long)
        mBTR = value
    End Set
End Property

Dim mDOB  as integer 
Public Property _DOB  as integer   
    Get
        Return mDOB
    End Get
    set(byval value as integer)
        mDOB = value
    End Set
End Property

Dim mSSNo  as long
Public Property _SSNo  as long  
    Get
        Return mSSNo
    End Get
    set(byval value as long)
        mSSNo = value
    End Set
End Property

Dim mBTC as string 
Public Property _BTC as string   
    Get
        Return mBTC
    End Get
    set(byval value as string)
        mBTC = value
    End Set
End Property

Dim mLEASE as string 
Public Property _LEASE as string   
    Get
        Return mLEASE
    End Get
    set(byval value as string)
        mLEASE = value
    End Set
End Property

Dim mORIG  as long
Public Property _ORIG  as long  
    Get
        Return mORIG
    End Get
    set(byval value as long)
        mORIG = value
    End Set
End Property

Dim mTRVAL  as long
Public Property _TRVAL  as long  
    Get
        Return mTRVAL
    End Get
    set(byval value as long)
        mTRVAL = value
    End Set
End Property

Dim mLNVAL  as long
Public Property _LNVAL  as long  
    Get
        Return mLNVAL
    End Get
    set(byval value as long)
        mLNVAL = value
    End Set
End Property

Dim mMSRP  as long
Public Property _MSRP  as long  
    Get
        Return mMSRP
    End Get
    set(byval value as long)
        mMSRP = value
    End Set
End Property

Dim mNADA as string 
Public Property _NADA as string   
    Get
        Return mNADA
    End Get
    set(byval value as string)
        mNADA = value
    End Set
End Property

Dim mPRF as string 
Public Property _PRF as string   
    Get
        Return mPRF
    End Get
    set(byval value as string)
        mPRF = value
    End Set
End Property

Dim mCHDATE  as integer 
Public Property _CHDATE  as integer   
    Get
        Return mCHDATE
    End Get
    set(byval value as integer)
        mCHDATE = value
    End Set
End Property

Dim mCHTIME  as integer 
Public Property _CHTIME  as integer   
    Get
        Return mCHTIME
    End Get
    set(byval value as integer)
        mCHTIME = value
    End Set
End Property

Dim mLETT as string 
Public Property _LETT as string   
    Get
        Return mLETT
    End Get
    set(byval value as string)
        mLETT = value
    End Set
End Property

Dim mTYPE as string 
Public Property _TYPE as string   
    Get
        Return mTYPE
    End Get
    set(byval value as string)
        mTYPE = value
    End Set
End Property

Dim mPDST  as integer 
Public Property _PDST  as integer   
    Get
        Return mPDST
    End Get
    set(byval value as integer)
        mPDST = value
    End Set
End Property

Dim mOID as string 
Public Property _OID as string   
    Get
        Return mOID
    End Get
    set(byval value as string)
        mOID = value
    End Set
End Property

Dim mSS2  as long
Public Property _SS2  as long  
    Get
        Return mSS2
    End Get
    set(byval value as long)
        mSS2 = value
    End Set
End Property

Dim mTIN as String
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

  Dim mRecordNotFound As Boolean
Public Property RecordNotFound() As Boolean
  Set(ByVal value as Boolean)
    mRecordNotFound = value
  End Set
  Get
    Return mRecordNotFound
  End Get
End Property
Dim mIsEOF As Boolean
Public Property IsEOF() As Boolean
  Set(ByVal value as Boolean)
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
    Set(ByVal value as String)
        mErrMsg = value
    End Set
End Property
#End Region
End Class


