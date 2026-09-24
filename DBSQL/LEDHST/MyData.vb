Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "LEDHST"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
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
  Public Sub InsertOneRecordP()
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Const caa As String = "','" 'Alpha Before/Alpha After
  Const can As String = "'," 'Alpha Before/Numeric After
  Const cna As String = ",'" 'Numeric Before/Alpha After
  Const cnn As String = "," 'Numeric Before/Numeric After

    StrSQL = "Insert into " & cFileName & "(AMTYP, AUTOG, BALFC, BCHNO,  CBLCD, " &
   "CHKN, CNTRL, DATED, DPNBR, FDNBR, FIL10, FIL045, FNPGM, " &
   "FSCYR, GLPST, GLTYP, INVNR, JRNSQ, OBNBR, " &
   "ORIG, PONBR, PRF, PSTDT, RECLS, REFNO, " &
   "ROCR, SFUND, SRCDE, SUBFN, TDATE, TDESC, " &
   "TRAMT, TRFTO, TRNBR, TRTYP)" &
   " values('" & _AMTYP & caa & _AUTOG & caa & _BALFC & can & _BCHNO & cna & _CBLCD & can &
   _CHKN & cnn & _CNTRL & cnn & _DATED & cnn & _DPNBR & cnn & _FDNBR & cnn & _FIL10 & cna & _FIL045 & can & _FNPGM & cnn &
   _FSCYR & cna & _GLPST & caa & _GLTYP & caa & _INVNR & can & _JRNSQ & cnn & _OBNBR & cnn &
   _ORIG & cnn & _PONBR & cna & _PRF & can & _PSTDT & cna & _RECLS & can & _REFNO & cna &
   _ROCR & can & _SFUND & cnn & _SRCDE & cnn & _SUBFN & cnn & _TDATE & cna & _TDESC & can &
   _TRAMT & cna & _TRFTO & can & _TRNBR & cna & _TRTYP & "')"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      da = New SqlDataAdapter
      da.InsertCommand = objCommand
      da.InsertCommand.ExecuteNonQuery()
      objCommand = Nothing
      Conn.Close()
    Catch ex As Exception
      ErrMsg = ex.ToString()
  End Try
End Sub
  Public Sub InsertFromLEDGER(ByVal FromDate As Integer, ByVal ToDate As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    StrSQL = "INSERT INTO LEDHST SELECT * FROM LEDGER WHERE PSTDT>=" & FromDate & " and PSTDT<=" & ToDate

    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    Result = objCommand.ExecuteNonQuery()
    objCommand = Nothing
  End Sub
  Public Sub DeleteRecords(ByVal WrkWhere As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    RecordNotFound = False
    IsEOF = False
    StrSQL = "Delete from " & cFileName & " where " & WrkWhere
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    Result = objCommand.ExecuteNonQuery()
    objCommand = Nothing
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
    _BALFC = .Item("BALFC")
    _TRTYP = .Item("TRTYP")
    _CBLCD = .Item("CBLCD")
    _GLTYP = .Item("GLTYP")
    _TRFTO = .Item("TRFTO")
    _FDNBR = .Item("FDNBR")
    _DPNBR = .Item("DPNBR")
    _OBNBR = .Item("OBNBR")
    _FNPGM = .Item("FNPGM")
    _DATED = .Item("DATED")
    _FIL10 = .Item("FIL10")
    _SRCDE = .Item("SRCDE")
    _TRAMT = .Item("TRAMT")
    _TDESC = .Item("TDESC")
    _REFNO = .Item("REFNO")
    _ORIG = .Item("ORIG")
    _SUBFN = .Item("SUBFN")
    _AUTOG = .Item("AUTOG")
    _FIL045 = .Item("FIL045")
    _BCHNO = .Item("BCHNO")
    _TRNBR = .Item("TRNBR")
    _JRNSQ = .Item("JRNSQ")
    _GLPST = .Item("GLPST")
    _AMTYP = .Item("AMTYP")
    _INVNR = .Item("INVNR")
    _SFUND = .Item("SFUND")
    _PRF = .Item("PRF")
    _ROCR = .Item("ROCR")
    _PSTDT = .Item("PSTDT")
    _TDATE = .Item("TDATE")
    _PONBR = .Item("PONBR")
    _CHKN = .Item("CHKN")
    _FSCYR = .Item("FSCYR")
    _CNTRL = .Item("CNTRL")
    _RECLS = .Item("RECLS")
  End With
End Sub
Public Sub PutFields(ByVal ds As DataSet)
	With ds.Tables(0).Rows(0)
    .Item("BALFC") = _BALFC
    .Item("TRTYP") = _TRTYP
    .Item("CBLCD") = _CBLCD
    .Item("GLTYP") = _GLTYP
    .Item("TRFTO") = _TRFTO
    .Item("FDNBR") = _FDNBR
    .Item("DPNBR") = _DPNBR
    .Item("OBNBR") = _OBNBR
    .Item("FNPGM") = _FNPGM
    .Item("DATED") = _DATED
    .Item("FIL10") = _FIL10
    .Item("SRCDE") = _SRCDE
    .Item("TRAMT") = _TRAMT
    .Item("TDESC") = _TDESC
    .Item("REFNO") = _REFNO
    .Item("ORIG") = _ORIG
    .Item("SUBFN") = _SUBFN
    .Item("AUTOG") = _AUTOG
    .Item("FIL045") = _FIL045
    .Item("BCHNO") = _BCHNO
    .Item("TRNBR") = _TRNBR
    .Item("JRNSQ") = _JRNSQ
    .Item("GLPST") = _GLPST
    .Item("AMTYP") = _AMTYP
    .Item("INVNR") = _INVNR
    .Item("SFUND") = _SFUND
    .Item("PRF") = _PRF
    .Item("ROCR") = _ROCR
    .Item("PSTDT") = _PSTDT
    .Item("TDATE") = _TDATE
    .Item("PONBR") = _PONBR
    .Item("CHKN") = _CHKN
    .Item("FSCYR") = _FSCYR
    .Item("CNTRL") = _CNTRL
    .Item("RECLS") = _RECLS
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
Dim mBALFC As String
Public Property _BALFC As String
    Get
        Return mBALFC
    End Get
    Set(ByVal value As String)
        mBALFC = value
    End Set
End Property
Dim mTRTYP As String
Public Property _TRTYP As String
    Get
        Return mTRTYP
    End Get
    Set(ByVal value As String)
        mTRTYP = value
    End Set
End Property
Dim mCBLCD As String
Public Property _CBLCD As String
    Get
        Return mCBLCD
    End Get
    Set(ByVal value As String)
        mCBLCD = value
    End Set
End Property
Dim mGLTYP As String
Public Property _GLTYP As String
    Get
        Return mGLTYP
    End Get
    Set(ByVal value As String)
        mGLTYP = value
    End Set
End Property
Dim mTRFTO As String
Public Property _TRFTO As String
    Get
        Return mTRFTO
    End Get
    Set(ByVal value As String)
        mTRFTO = value
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
Dim mDATED As Integer
Public Property _DATED As Integer
    Get
        Return mDATED
    End Get
    Set(ByVal value As Integer)
        mDATED = value
    End Set
End Property
Dim mFIL10 As Long
Public Property _FIL10 As Long
    Get
        Return mFIL10
    End Get
    Set(ByVal value As Long)
        mFIL10 = value
    End Set
End Property
Dim mSRCDE As Integer
Public Property _SRCDE As Integer
    Get
        Return mSRCDE
    End Get
    Set(ByVal value As Integer)
        mSRCDE = value
    End Set
End Property
Dim mTRAMT As Decimal
Public Property _TRAMT As Decimal
    Get
        Return mTRAMT
    End Get
    Set(ByVal value As Decimal)
        mTRAMT = value
    End Set
End Property
Dim mTDESC As String
Public Property _TDESC As String
    Get
        Return mTDESC
    End Get
    Set(ByVal value As String)
        mTDESC = value
    End Set
End Property
Dim mREFNO As Integer
Public Property _REFNO As Integer
    Get
        Return mREFNO
    End Get
    Set(ByVal value As Integer)
        mREFNO = value
    End Set
End Property
Dim mORIG As Decimal
Public Property _ORIG As Decimal
    Get
        Return mORIG
    End Get
    Set(ByVal value As Decimal)
        mORIG = value
    End Set
End Property
Dim mAUTOG As String
Public Property _AUTOG As String
    Get
        Return mAUTOG
    End Get
    Set(ByVal value As String)
        mAUTOG = value
    End Set
End Property
Dim mFIL045 As String
Public Property _FIL045 As String
    Get
        Return mFIL045
    End Get
    Set(ByVal value As String)
        mFIL045 = value
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
Dim mTRNBR As Integer
Public Property _TRNBR As Integer
    Get
        Return mTRNBR
    End Get
    Set(ByVal value As Integer)
        mTRNBR = value
    End Set
End Property
Dim mJRNSQ As Integer
Public Property _JRNSQ As Integer
    Get
        Return mJRNSQ
    End Get
    Set(ByVal value As Integer)
        mJRNSQ = value
    End Set
End Property
Dim mGLPST As String
Public Property _GLPST As String
    Get
        Return mGLPST
    End Get
    Set(ByVal value As String)
        mGLPST = value
    End Set
End Property
Dim mAMTYP As String
Public Property _AMTYP As String
    Get
        Return mAMTYP
    End Get
    Set(ByVal value As String)
        mAMTYP = value
    End Set
End Property
Dim mINVNR As String
Public Property _INVNR As String
    Get
        Return mINVNR
    End Get
    Set(ByVal value As String)
        mINVNR = value
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
Dim mROCR As String
Public Property _ROCR As String
    Get
        Return mROCR
    End Get
    Set(ByVal value As String)
        mROCR = value
    End Set
End Property
Dim mPSTDT As Long
Public Property _PSTDT As Long
    Get
        Return mPSTDT
    End Get
    Set(ByVal value As Long)
        mPSTDT = value
    End Set
End Property
Dim mTDATE As Long
Public Property _TDATE As Long
    Get
        Return mTDATE
    End Get
    Set(ByVal value As Long)
        mTDATE = value
    End Set
End Property
Dim mPONBR As Long
Public Property _PONBR As Long
    Get
        Return mPONBR
    End Get
    Set(ByVal value As Long)
        mPONBR = value
    End Set
End Property
Dim mCHKN As Long
Public Property _CHKN As Long
    Get
        Return mCHKN
    End Get
    Set(ByVal value As Long)
        mCHKN = value
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
Dim mCNTRL As Integer
Public Property _CNTRL As Integer
    Get
        Return mCNTRL
    End Get
    Set(ByVal value As Integer)
        mCNTRL = value
    End Set
End Property
Dim mRECLS As String
Public Property _RECLS As String
    Get
        Return mRECLS
    End Get
    Set(ByVal value As String)
        mRECLS = value
    End Set
End Property
#End Region
End Class

