Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "POMBCH"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Function AutoGenKey(ByVal WrkBchno As Integer) As Integer
  Dim NextKey As Integer
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where bchno=" & WrkBchno & " order by ponbr desc"
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
      NextKey = ds.Tables(0).Rows(0).Item("seqno") + 1
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
Public Sub GetOneRecordP(ByVal WrkBchno As Integer, ByVal WrkPonbr As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where bchno=" & WrkBchno & " and ponbr=" & WrkPonbr
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
  Public Sub DeleteBatch(ByVal WrkBchno As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim Result As Integer

  RecordNotFound = False
  IsEOF = False
  StrSQL = "Delete from " & cFileName & " where bchno=" & WrkBchno
  Conn = MyDBConn.Open
  objCommand = New SqlCommand(StrSQL, Conn)
  Result = objCommand.ExecuteNonQuery()
  objCommand = Nothing
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
    _LLOCN = .Item("LLOCN")
    _BCHNO = .Item("BCHNO")
    _PONBR = .Item("PONBR")
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
    _CMPCD = .Item("CMPCD")
    _SZIP = .Item("SZIP")
    _SZIPE = .Item("SZIPE")
    _RZIP = .Item("RZIP")
    _RZIPE = .Item("RZIPE")
    _POFXR = .Item("POFXR")
    _LNE = .Item("LNE")
    _PRJ = .Item("PRJ")
    _POPST = .Item("POPST")
  End With
End Sub
Public Sub PutFields(ByVal ds As DataSet)
	With ds.Tables(0).Rows(0)
    .Item("LLOCN") = _LLOCN
    .Item("BCHNO") = _BCHNO
    .Item("PONBR") = _PONBR
    .Item("RQNBR") = _RQNBR
    .Item("VNDNR") = _VNDNR
    .Item("VENNM") = _VENNM
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
    .Item("RENTD") = _RENTD
    .Item("RENTC") = _RENTC
    .Item("RACTD") = _RACTD
    .Item("AMTGR") = _AMTGR
    .Item("AMTNT") = _AMTNT
    .Item("VNNAM") = _VNNAM
    .Item("ORDSP") = _ORDSP
    .Item("DSCDL") = _DSCDL
    .Item("ORSHP") = _ORSHP
    .Item("SHPDL") = _SHPDL
    .Item("FSCYR") = _FSCYR
    .Item("FDNBD") = _FDNBD
    .Item("SFUDD") = _SFUDD
    .Item("DPNBD") = _DPNBD
    .Item("OBNBD") = _OBNBD
    .Item("FNPGD") = _FNPGD
    .Item("SUBFD") = _SUBFD
    .Item("FDNBS") = _FDNBS
    .Item("SFUNS") = _SFUNS
    .Item("DPNBS") = _DPNBS
    .Item("OBNBS") = _OBNBS
    .Item("FNPGS") = _FNPGS
    .Item("SUBFS") = _SUBFS
    .Item("CMPCD") = _CMPCD
    .Item("SZIP") = _SZIP
    .Item("SZIPE") = _SZIPE
    .Item("RZIP") = _RZIP
    .Item("RZIPE") = _RZIPE
    .Item("POFXR") = _POFXR
    .Item("LNE") = _LNE
    .Item("PRJ") = _PRJ
    .Item("POPST") = _POPST
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
Dim mPOSUFX As Integer
Public Property _POSUFX As Integer
    Get
        Return mPOSUFX
    End Get
    Set(ByVal value As Integer)
        mPOSUFX = value
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
Dim mCMPCD As String
Public Property _CMPCD As String
    Get
        Return mCMPCD
    End Get
    Set(ByVal value As String)
        mCMPCD = value
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
Dim mPOFXR As String
Public Property _POFXR As String
    Get
        Return mPOFXR
    End Get
    Set(ByVal value As String)
        mPOFXR = value
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

