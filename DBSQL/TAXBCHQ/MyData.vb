Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Const cFileName As String = "TAXBCH"
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
    _BCHNO = .Item("BCHNO")
    _TRNBR = .Item("TRNBR")
    _JRNSEQ = .Item("JRNSEQ")
    _DIST = .Item("DIST")
    _TRNTYP = .Item("TRNTYP")
    _AMTTYP = .Item("AMTTYP")
    _JENT8 = .Item("JENT8")
    _JACT8 = .Item("JACT8")
    _AMT = .Item("AMT")
    _TOTCR = .Item("TOTCR")
    _TOTDR = .Item("TOTDR")
    _FDNBR = .Item("FDNBR")
    _SFUND = .Item("SFUND")
    _DPNBR = .Item("DPNBR")
    _OBNBR = .Item("OBNBR")
    _FNPGM = .Item("FNPGM")
    _SUBFN = .Item("SUBFN")
    _DESCR = .Item("DESCR")
    _GLTYP = .Item("GLTYP")
    _REFNO = .Item("REFNO")
    _SRCDE = .Item("SRCDE")
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
Dim mJRNSEQ As Integer
Public Property _JRNSEQ As Integer
    Get
        Return mJRNSEQ
    End Get
    Set(ByVal value As Integer)
        mJRNSEQ = value
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
Dim mTRNTYP As String
Public Property _TRNTYP As String
    Get
        Return mTRNTYP
    End Get
    Set(ByVal value As String)
        mTRNTYP = value
    End Set
End Property
Dim mAMTTYP As String
Public Property _AMTTYP As String
    Get
        Return mAMTTYP
    End Get
    Set(ByVal value As String)
        mAMTTYP = value
    End Set
End Property
Dim mJENT8 As Integer
Public Property _JENT8 As Integer
    Get
        Return mJENT8
    End Get
    Set(ByVal value As Integer)
        mJENT8 = value
    End Set
End Property
Dim mJACT8 As Integer
Public Property _JACT8 As Integer
    Get
        Return mJACT8
    End Get
    Set(ByVal value As Integer)
        mJACT8 = value
    End Set
End Property
Dim mAMT As Decimal
Public Property _AMT As Decimal
    Get
        Return mAMT
    End Get
    Set(ByVal value As Decimal)
        mAMT = value
    End Set
End Property
Dim mTOTCR As Decimal
Public Property _TOTCR As Decimal
    Get
        Return mTOTCR
    End Get
    Set(ByVal value As Decimal)
        mTOTCR = value
    End Set
End Property
Dim mTOTDR As Decimal
Public Property _TOTDR As Decimal
    Get
        Return mTOTDR
    End Get
    Set(ByVal value As Decimal)
        mTOTDR = value
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
Dim mDESCR As String
Public Property _DESCR As String
    Get
        Return mDESCR
    End Get
    Set(ByVal value As String)
        mDESCR = value
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
Dim mREFNO As Integer
Public Property _REFNO As Integer
    Get
        Return mREFNO
    End Get
    Set(ByVal value As Integer)
        mREFNO = value
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
#End Region

End Class

