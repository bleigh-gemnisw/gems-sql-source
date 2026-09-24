Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "MSCBCH"
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
  StrSQL = "Select * from " & cFileName & " where bchno=" & WrkBchno & " order by jrnseq desc"
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
      NextKey = ds.Tables(0).Rows(0).Item("jrnseq") + 1
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
Public Sub GetOneRecordP(ByVal WrkBchno As Integer, ByVal WrkTrnbr As Integer, ByVal WrkJrnseq As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where bchno=" & WrkBchno & " and trnbr=" & WrkTrnbr & _
  " and jrnseq=" & WrkJrnseq
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
    _BCHNO = .Item("BCHNO")
    _TRNBR = .Item("TRNBR")
    _JRNSEQ = .Item("JRNSEQ")
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
Public Sub PutFields(ByVal ds As DataSet)
	With ds.Tables(0).Rows(0)
    .Item("BCHNO") = _BCHNO
    .Item("TRNBR") = _TRNBR
    .Item("JRNSEQ") = _JRNSEQ
    .Item("TRNTYP") = _TRNTYP
    .Item("AMTTYP") = _AMTTYP
    .Item("JENT8") = _JENT8
    .Item("JACT8") = _JACT8
    .Item("AMT") = _AMT
    .Item("TOTCR") = _TOTCR
    .Item("TOTDR") = _TOTDR
    .Item("FDNBR") = _FDNBR
    .Item("SFUND") = _SFUND
    .Item("DPNBR") = _DPNBR
    .Item("OBNBR") = _OBNBR
    .Item("FNPGM") = _FNPGM
    .Item("SUBFN") = _SUBFN
    .Item("DESCR") = _DESCR
    .Item("GLTYP") = _GLTYP
    .Item("REFNO") = _REFNO
    .Item("SRCDE") = _SRCDE
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

