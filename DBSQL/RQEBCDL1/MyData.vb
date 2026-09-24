Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "RQEBCD"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Function GetViewbyBatch(ByVal WrkLlocn As String, WrkBchno As Integer, _
 ByVal NumRecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim WrkTop As String
  WrkTop = String.Empty

  RecordNotFound = False
  If NumRecs > 0 Then
    WrkTop = "TOP " & NumRecs & " "
  End If
  StrSQL = "Select " & WrkTop & "* from " & cFileName _
    & " where llocn='" & WrkLlocn & "' and bchno=" & WrkBchno & " order by rqnbr"
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
Public Function GetViewbyRqnbr(ByVal WrkLlocn As String, ByVal WrkBchno As Integer, _
 ByVal WrkRqnbr As Integer, ByVal NumRecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim WrkTop As String
  WrkTop = String.Empty

  RecordNotFound = False
  If NumRecs > 0 Then
    WrkTop = "TOP " & NumRecs & " "
  End If
  StrSQL = "Select " & WrkTop & "llocn,bchno,rqnbr,rqseq,itnbr,itdsc,exval,rqqty,unitp," _
    & "unmsr,fdnbr,sfund,dpnbr,obnbr,fnpgm,subfn from " & cFileName _
    & " where llocn='" & WrkLlocn & "' and bchno=" & WrkBchno & " and rqnbr=" & WrkRqnbr _
    & " order by rqseq"
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
Public Function GetViewbyAcct(ByVal Fdnbr As Integer, ByVal Sfund As Integer, ByVal Dpnbr As Integer, _
 ByVal Obnbr As Integer, ByVal Fnpgm As Integer, ByVal Subfn As Integer)

  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim WrkTop As String
  WrkTop = String.Empty

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where FDNBR=" & Fdnbr & " and SFUND=" & Sfund & _
   " and DPNBR=" & Dpnbr & " and OBNBR=" & Obnbr & " and FNPGM=" & Fnpgm & " and SUBFN=" & Subfn
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
    _RQNBR = .Item("RQNBR")
    _RQSEQ = .Item("RQSEQ")
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
  End With
End Sub
Public Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("LLOCN") = _LLOCN
    .Item("BCHNO") = _BCHNO
    .Item("RQNBR") = _RQNBR
    .Item("RQSEQ") = _RQSEQ
    .Item("RQQTY") = _RQQTY
    .Item("ITNBR") = _ITNBR
    .Item("FDNBR") = _FDNBR
    .Item("SFUND") = _SFUND
    .Item("DPNBR") = _DPNBR
    .Item("OBNBR") = _OBNBR
    .Item("FNPGM") = _FNPGM
    .Item("SUBFN") = _SUBFN
    .Item("UNITP") = _UNITP
    .Item("ITDSC") = _ITDSC
    .Item("UNMSR") = _UNMSR
    .Item("EXVAL") = _EXVAL
    .Item("TOTVL") = _TOTVL
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
Dim mRQSEQ As Integer
Public Property _RQSEQ As Integer
    Get
        Return mRQSEQ
    End Get
    Set(ByVal value As Integer)
        mRQSEQ = value
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
#End Region


End Class

