Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Const cFileName As String = "POMAST"
#Region "Constructors"

  Public Sub New()
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
  objCommand = Nothing
End Sub
Public Sub SumPaidQry(ByVal WrkGroup As String, ByVal WrkSort As String, ByVal WrkQry As String)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand

  StrSQL = "Select vndnr, sum(amtpd) as amtpd from " & cFileName
  If WrkQry <> String.Empty Then
    StrSQL = StrSQL & " where " & WrkQry
  End If
  If WrkGroup <> String.Empty Then
    StrSQL = StrSQL & " Group by " & WrkGroup
  End If
  If WrkSort <> String.Empty Then
    StrSQL = StrSQL & " Order by " & WrkSort
  End If
  Conn = MyDBConn.Open
  objCommand = New SqlCommand(StrSQL, Conn)
  objReader = objCommand.ExecuteReader()
  objCommand = Nothing
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
    _PONBR = .Item("PONBR")
    _POSUF = .Item("POSUF")
    _POSEQ = .Item("POSEQ")
    _RSQDG = .Item("RSQDG")
    _LLOCN = .Item("LLOCN")
    _BCHNO = .Item("BCHNO")
    _RQNBR = .Item("RQNBR")
    _VNDNR = .Item("VNDNR")
    _VENNM = .Item("VENNM")
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
    _RENTD = .Item("RENTD")
    _RENTC = .Item("RENTC")
    _RACTD = .Item("RACTD")
    _AMTGR = .Item("AMTGR")
    _AMTNT = .Item("AMTNT")
    _VNNAM = .Item("VNNAM")
    _ORDSP = .Item("ORDSP")
    _DSCDL = .Item("DSCDL")
    _ORSHP = .Item("ORSHP")
    _SHPDL = .Item("SHPDL")
    _RQQTY = .Item("RQQTY")
    _ITNBR = .Item("ITNBR")
    _FDNBR = .Item("FDNBR")
    _SFUND = .Item("SFUND")
    _DPNBR = .Item("DPNBR")
    _OBNBR = .Item("OBNBR")
    _FNPGM = .Item("FNPGM")
    _SUBFN = .Item("SUBFN")
    _UNITP = .Item("UNITP")
    _ITDSC = .Item("ITDSC")
    _UNMSR = .Item("UNMSR")
    _EXVAL = .Item("EXVAL")
    _TOTVL = .Item("TOTVL")
    _FSCYR = .Item("FSCYR")
    _FDNBD = .Item("FDNBD")
    _SFUDD = .Item("SFUDD")
    _DPNBD = .Item("DPNBD")
    _OBNBD = .Item("OBNBD")
    _FNPGD = .Item("FNPGD")
    _SUBFD = .Item("SUBFD")
    _FDNBS = .Item("FDNBS")
    _SFUNS = .Item("SFUNS")
    _DPNBS = .Item("DPNBS")
    _OBNBS = .Item("OBNBS")
    _FNPGS = .Item("FNPGS")
    _SUBFS = .Item("SUBFS")
    _QTRCP = .Item("QTRCP")
    _QTRCU = .Item("QTRCU")
    _CMPCD = .Item("CMPCD")
    _INUSE = .Item("INUSE")
    _MNAYN = .Item("MNAYN")
    _PODYN = .Item("PODYN")
    _SZIP = .Item("SZIP")
    _SZIPE = .Item("SZIPE")
    _RZIP = .Item("RZIP")
    _RZIPE = .Item("RZIPE")
    _PRTFG = .Item("PRTFG")
    _POUSE = .Item("POUSE")
    _POPEN = .Item("POPEN")
    _POFXR = .Item("POFXR")
    _POFAQ = .Item("POFAQ")
    _LNE = .Item("LNE")
    _PRJ = .Item("PRJ")
    _POPST = .Item("POPST")
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
Dim mPONBR As Integer
Public Property _PONBR As Integer
    Get
        Return mPONBR
    End Get
    Set(ByVal value As Integer)
        mPONBR = value
    End Set
End Property
Dim mPOSUF As Integer
Public Property _POSUF As Integer
    Get
        Return mPOSUF
    End Get
    Set(ByVal value As Integer)
        mPOSUF = value
    End Set
End Property
Dim mPOSEQ As Integer
Public Property _POSEQ As Integer
    Get
        Return mPOSEQ
    End Get
    Set(ByVal value As Integer)
        mPOSEQ = value
    End Set
End Property
Dim mRSQDG As Integer
Public Property _RSQDG As Integer
    Get
        Return mRSQDG
    End Get
    Set(ByVal value As Integer)
        mRSQDG = value
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
Dim mBCHNO As Integer
Public Property _BCHNO As Integer
    Get
        Return mBCHNO
    End Get
    Set(ByVal value As Integer)
        mBCHNO = value
    End Set
End Property
Dim mRQNBR As Integer
Public Property _RQNBR As Integer
    Get
        Return mRQNBR
    End Get
    Set(ByVal value As Integer)
        mRQNBR = value
    End Set
End Property
Dim mVNDNR As String
Public Property _VNDNR As String
    Get
        Return mVNDNR
    End Get
    Set(ByVal value As String)
        mVNDNR = value
    End Set
End Property
Dim mVENNM As String
Public Property _VENNM As String
    Get
        Return mVENNM
    End Get
    Set(ByVal value As String)
        mVENNM = value
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
Dim mRENTD As Integer
Public Property _RENTD As Integer
    Get
        Return mRENTD
    End Get
    Set(ByVal value As Integer)
        mRENTD = value
    End Set
End Property
Dim mRENTC As Integer
Public Property _RENTC As Integer
    Get
        Return mRENTC
    End Get
    Set(ByVal value As Integer)
        mRENTC = value
    End Set
End Property
Dim mRACTD As Integer
Public Property _RACTD As Integer
    Get
        Return mRACTD
    End Get
    Set(ByVal value As Integer)
        mRACTD = value
    End Set
End Property
Dim mAMTGR As Decimal
Public Property _AMTGR As Decimal
    Get
        Return mAMTGR
    End Get
    Set(ByVal value As Decimal)
        mAMTGR = value
    End Set
End Property
Dim mAMTNT As Decimal
Public Property _AMTNT As Decimal
    Get
        Return mAMTNT
    End Get
    Set(ByVal value As Decimal)
        mAMTNT = value
    End Set
End Property
Dim mVNNAM As String
Public Property _VNNAM As String
    Get
        Return mVNNAM
    End Get
    Set(ByVal value As String)
        mVNNAM = value
    End Set
End Property
Dim mORDSP As Decimal
Public Property _ORDSP As Decimal
    Get
        Return mORDSP
    End Get
    Set(ByVal value As Decimal)
        mORDSP = value
    End Set
End Property
Dim mDSCDL As Decimal
Public Property _DSCDL As Decimal
    Get
        Return mDSCDL
    End Get
    Set(ByVal value As Decimal)
        mDSCDL = value
    End Set
End Property
Dim mORSHP As Decimal
Public Property _ORSHP As Decimal
    Get
        Return mORSHP
    End Get
    Set(ByVal value As Decimal)
        mORSHP = value
    End Set
End Property
Dim mSHPDL As Decimal
Public Property _SHPDL As Decimal
    Get
        Return mSHPDL
    End Get
    Set(ByVal value As Decimal)
        mSHPDL = value
    End Set
End Property
Dim mRQQTY As Decimal
Public Property _RQQTY As Decimal
    Get
        Return mRQQTY
    End Get
    Set(ByVal value As Decimal)
        mRQQTY = value
    End Set
End Property
Dim mITNBR As String
Public Property _ITNBR As String
    Get
        Return mITNBR
    End Get
    Set(ByVal value As String)
        mITNBR = value
    End Set
End Property
Dim mFDNBR As Integer
Public Property _FDNBR As Integer
    Get
        Return mFDNBR
    End Get
    Set(ByVal value As Integer)
        mFDNBR = value
    End Set
End Property
Dim mSFUND As Integer
Public Property _SFUND As Integer
    Get
        Return mSFUND
    End Get
    Set(ByVal value As Integer)
        mSFUND = value
    End Set
End Property
Dim mDPNBR As Integer
Public Property _DPNBR As Integer
    Get
        Return mDPNBR
    End Get
    Set(ByVal value As Integer)
        mDPNBR = value
    End Set
End Property
Dim mOBNBR As Integer
Public Property _OBNBR As Integer
    Get
        Return mOBNBR
    End Get
    Set(ByVal value As Integer)
        mOBNBR = value
    End Set
End Property
Dim mFNPGM As Integer
Public Property _FNPGM As Integer
    Get
        Return mFNPGM
    End Get
    Set(ByVal value As Integer)
        mFNPGM = value
    End Set
End Property
Dim mSUBFN As Integer
Public Property _SUBFN As Integer
    Get
        Return mSUBFN
    End Get
    Set(ByVal value As Integer)
        mSUBFN = value
    End Set
End Property
Dim mUNITP As Decimal
Public Property _UNITP As Decimal
    Get
        Return mUNITP
    End Get
    Set(ByVal value As Decimal)
        mUNITP = value
    End Set
End Property
Dim mITDSC As String
Public Property _ITDSC As String
    Get
        Return mITDSC
    End Get
    Set(ByVal value As String)
        mITDSC = value
    End Set
End Property
Dim mUNMSR As String
Public Property _UNMSR As String
    Get
        Return mUNMSR
    End Get
    Set(ByVal value As String)
        mUNMSR = value
    End Set
End Property
Dim mEXVAL As Decimal
Public Property _EXVAL As Decimal
    Get
        Return mEXVAL
    End Get
    Set(ByVal value As Decimal)
        mEXVAL = value
    End Set
End Property
Dim mTOTVL As Decimal
Public Property _TOTVL As Decimal
    Get
        Return mTOTVL
    End Get
    Set(ByVal value As Decimal)
        mTOTVL = value
    End Set
End Property
Dim mFSCYR As Integer
Public Property _FSCYR As Integer
    Get
        Return mFSCYR
    End Get
    Set(ByVal value As Integer)
        mFSCYR = value
    End Set
End Property
Dim mFDNBD As Integer
Public Property _FDNBD As Integer
    Get
        Return mFDNBD
    End Get
    Set(ByVal value As Integer)
        mFDNBD = value
    End Set
End Property
Dim mSFUDD As Integer
Public Property _SFUDD As Integer
    Get
        Return mSFUDD
    End Get
    Set(ByVal value As Integer)
        mSFUDD = value
    End Set
End Property
Dim mDPNBD As Integer
Public Property _DPNBD As Integer
    Get
        Return mDPNBD
    End Get
    Set(ByVal value As Integer)
        mDPNBD = value
    End Set
End Property
Dim mOBNBD As Integer
Public Property _OBNBD As Integer
    Get
        Return mOBNBD
    End Get
    Set(ByVal value As Integer)
        mOBNBD = value
    End Set
End Property
Dim mFNPGD As Integer
Public Property _FNPGD As Integer
    Get
        Return mFNPGD
    End Get
    Set(ByVal value As Integer)
        mFNPGD = value
    End Set
End Property
Dim mSUBFD As Integer
Public Property _SUBFD As Integer
    Get
        Return mSUBFD
    End Get
    Set(ByVal value As Integer)
        mSUBFD = value
    End Set
End Property
Dim mFDNBS As Integer
Public Property _FDNBS As Integer
    Get
        Return mFDNBS
    End Get
    Set(ByVal value As Integer)
        mFDNBS = value
    End Set
End Property
Dim mSFUNS As Integer
Public Property _SFUNS As Integer
    Get
        Return mSFUNS
    End Get
    Set(ByVal value As Integer)
        mSFUNS = value
    End Set
End Property
Dim mDPNBS As Integer
Public Property _DPNBS As Integer
    Get
        Return mDPNBS
    End Get
    Set(ByVal value As Integer)
        mDPNBS = value
    End Set
End Property
Dim mOBNBS As Integer
Public Property _OBNBS As Integer
    Get
        Return mOBNBS
    End Get
    Set(ByVal value As Integer)
        mOBNBS = value
    End Set
End Property
Dim mFNPGS As Integer
Public Property _FNPGS As Integer
    Get
        Return mFNPGS
    End Get
    Set(ByVal value As Integer)
        mFNPGS = value
    End Set
End Property
Dim mSUBFS As Integer
Public Property _SUBFS As Integer
    Get
        Return mSUBFS
    End Get
    Set(ByVal value As Integer)
        mSUBFS = value
    End Set
End Property
Dim mQTRCP As Decimal
Public Property _QTRCP As Decimal
    Get
        Return mQTRCP
    End Get
    Set(ByVal value As Decimal)
        mQTRCP = value
    End Set
End Property
Dim mQTRCU As Decimal
Public Property _QTRCU As Decimal
    Get
        Return mQTRCU
    End Get
    Set(ByVal value As Decimal)
        mQTRCU = value
    End Set
End Property
Dim mCMPCD As String
Public Property _CMPCD As String
    Get
        Return mCMPCD
    End Get
    Set(ByVal value As String)
        mCMPCD = value
    End Set
End Property
Dim mINUSE As String
Public Property _INUSE As String
    Get
        Return mINUSE
    End Get
    Set(ByVal value As String)
        mINUSE = value
    End Set
End Property
Dim mMNAYN As String
Public Property _MNAYN As String
    Get
        Return mMNAYN
    End Get
    Set(ByVal value As String)
        mMNAYN = value
    End Set
End Property
Dim mPODYN As String
Public Property _PODYN As String
    Get
        Return mPODYN
    End Get
    Set(ByVal value As String)
        mPODYN = value
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
Dim mPRTFG As String
Public Property _PRTFG As String
    Get
        Return mPRTFG
    End Get
    Set(ByVal value As String)
        mPRTFG = value
    End Set
End Property
Dim mPOUSE As String
Public Property _POUSE As String
    Get
        Return mPOUSE
    End Get
    Set(ByVal value As String)
        mPOUSE = value
    End Set
End Property
Dim mPOPEN As Decimal
Public Property _POPEN As Decimal
    Get
        Return mPOPEN
    End Get
    Set(ByVal value As Decimal)
        mPOPEN = value
    End Set
End Property
Dim mPOFXR As String
Public Property _POFXR As String
    Get
        Return mPOFXR
    End Get
    Set(ByVal value As String)
        mPOFXR = value
    End Set
End Property
Dim mPOFAQ As Integer
Public Property _POFAQ As Integer
    Get
        Return mPOFAQ
    End Get
    Set(ByVal value As Integer)
        mPOFAQ = value
    End Set
End Property
Dim mLNE As Integer
Public Property _LNE As Integer
    Get
        Return mLNE
    End Get
    Set(ByVal value As Integer)
        mLNE = value
    End Set
End Property
Dim mPRJ As Long
Public Property _PRJ As Long
    Get
        Return mPRJ
    End Get
    Set(ByVal value As Long)
        mPRJ = value
    End Set
End Property
Dim mPOPST As Integer
Public Property _POPST As Integer
    Get
        Return mPOPST
    End Get
    Set(ByVal value As Integer)
        mPOPST = value
    End Set
End Property
#End Region

End Class

