Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "LEDGER"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region
Public Function GetAllAcct(ByVal WrkFdnbr As String, ByVal WrkSfund As Integer, _
 ByVal WrkDpnbr As Integer, ByVal WrkObnbr As Integer, ByVal WrkFnpgm As Integer, _
 ByVal WrkSubfn As Integer, ByVal WrkStrdt As Integer, WrkEnddt As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName _
    & " where fdnbr=" & WrkFdnbr & " and sfund=" & WrkSfund & " and dpnbr=" & WrkDpnbr & _
    " and obnbr=" & WrkObnbr & " and fnpgm=" & WrkFnpgm & " and subfn=" & WrkSubfn & _
    " and pstdt >=" & WrkStrdt & " and pstdt<=" & WrkEnddt & " order by pstdt"
  Try
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    objCommand = Nothing
    Conn.Close()
    Return ds
  Catch ex As Exception
    ErrMsg = ex.ToString()
    Return Nothing
  End Try
End Function
Public Function IsPosted(ByVal WrkBchno As Integer, ByVal WrkTran As Integer, _
 ByVal WrkSeq As Integer, ByVal WrkPstdt As Integer) As Boolean
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim WrkResult As Boolean

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & _
    " where bchno=" & WrkBchno & " and trnbr=" & WrkTran & " and jrnsq=" & WrkSeq & _
    " and pstdt =" & WrkPstdt & " order by pstdt"
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
      WrkResult = False
    Else
      WrkResult = True
    End If
    Return WrkResult
  Catch ex As Exception
    ErrMsg = ex.ToString()
    Return Nothing
  End Try
End Function
Public Function GetRecoveryTran(ByVal WrkBchno As Integer, ByVal WrkPstdt As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select top 1 * from " & cFileName & _
    " where bchno=" & WrkBchno & " and pstdt =" & WrkPstdt & " order by trnbr desc,jrnsq desc"
  Try
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    objCommand = Nothing
    Conn.Close()
    Return ds
  Catch ex As Exception
    ErrMsg = ex.ToString()
    Return Nothing
  End Try
End Function
Public Function GetBudgetTot(ByVal WrkFromDt As Integer, ByVal WrkToDt As Integer, _
 ByVal WrkCredit As Boolean) As Decimal
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim StrSQL1 As String
  Dim WrkAmtyp As String
  Dim WrkAmount As Decimal

  If WrkCredit Then
    WrkAmtyp = "C"
  Else
    WrkAmtyp = "D"
  End If
  RecordNotFound = False
  StrSQL1 = "Select COALESCE(SUM(tramt),0) as totamt from " & cFileName & " where pstdt>=" & WrkFromDt & _
   " and pstdt<=" & WrkToDt & " and trntyp='X' and Amtyp='" & WrkAmtyp & "'"
  StrSQL = StrSQL1 & " and gltyp='R' or " & StrSQL1 & " and gltyp='X'"
  Try
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    WrkAmount = ds.Tables(0).Rows(0).Item(0)
    objCommand = Nothing
    Conn.Close()
    ds = Nothing
    Return WrkAmount
  Catch ex As Exception
    ErrMsg = ex.ToString()
    Return Nothing
  End Try
End Function
#Region "Methods: File Access Routines"
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

