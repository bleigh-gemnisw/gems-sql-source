Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim ConnRdr As SqlConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objreader As SqlDataReader
  Const cFileName As String = "TAXBCH"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Function GetViewbySeq(ByVal WrkBchno As Integer, ByVal WrkSeq As Integer, _
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
  StrSQL = "Select " & WrkTop & "jrnseq,trnbr,fdnbr,sfund,dpnbr,obnbr,fnpgm,subfn," & _
   "amt,gltyp,amttyp,jent8 from " & cFileName & _
   " where bchno=" & WrkBchno & " and jrnseq>=" & WrkSeq & " order by bchno, jrnseq"
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
Public Function GetViewbyBatch(ByVal WrkBchno As Integer, ByVal NumRecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim WrkTop As String
  WrkTop = String.Empty

  RecordNotFound = False
  If NumRecs > 0 Then
    WrkTop = "TOP " & NumRecs & " "
  End If
  StrSQL = "Select " & WrkTop & "trnbr,jrnseq,fdnbr,sfund,dpnbr,obnbr,fnpgm,subfn,amt,gltyp,amttyp," & _
   "jent8 from " & cFileName & " where bchno=" & WrkBchno & " and jrnseq>0"
  Try
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    ds2 = ReplaceDS(ds)
    ds = Nothing
    objCommand = Nothing
    Conn.Close()
    Return ds2
  Catch ex As Exception
    ErrMsg = ex.ToString()
    Return Nothing
  End Try
End Function
Public Function GetViewbyBatchTot(ByVal WrkBchno As Integer, ByVal NumRecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim WrkTop As String
  WrkTop = String.Empty

  RecordNotFound = False
  If NumRecs > 0 Then
    WrkTop = "TOP " & NumRecs & " "
  End If
  StrSQL = "Select " & WrkTop & "jrnseq,trnbr,descr,totdr,totcr,gltyp from " & cFileName & _
   " where bchno=" & WrkBchno & " and jrnseq=0"
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
Public Function GetViewbyDist(ByVal WrkRefno As Integer, ByVal WrkDist As Integer, _
 ByVal NumRecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim WrkTop As String
  WrkTop = String.Empty

  RecordNotFound = False
  If NumRecs > 0 Then
    WrkTop = "TOP " & NumRecs & " "
  End If
  StrSQL = "Select " & WrkTop & "bchno,trnbr,jrnseq,fdnbr,sfund,dpnbr,obnbr,fnpgm,subfn,amt," & _
   "gltyp,amttyp,jent8 from " & cFileName & _
   " where refno=" & WrkRefno & " and dist=" & WrkDist
  Try
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    ds2 = ReplaceDS(ds)
    ds = Nothing
    objCommand = Nothing
    Conn.Close()
    Return ds2
  Catch ex As Exception
    ErrMsg = ex.ToString()
    Return Nothing
  End Try
End Function
Public Function ReplaceDS(ByVal ds As DataSet) As DataSet
    Dim ds2 As DataSet = New DataSet
    Dim dr As DataRow
    Dim myTable As New DataTable
    Dim I As Integer
    With myTable
      .TableName = "mytable" 'ds.Tables(0).TableName
      .Columns.Add("trnbr", Type.GetType("System.Int16"))
      .Columns.Add("jrnseq", Type.GetType("System.Int16"))
      .Columns.Add("fdnbr", Type.GetType("System.Int16"))
      .Columns.Add("sfund", Type.GetType("System.Int16"))
      .Columns.Add("dpnbr", Type.GetType("System.Int16"))
      .Columns.Add("obnbr", Type.GetType("System.Int16"))
      .Columns.Add("fnpgm", Type.GetType("System.Int16"))
      .Columns.Add("subfn", Type.GetType("System.Int16"))
      .Columns.Add("amt", Type.GetType("System.Decimal"))
      .Columns.Add("gltyp", Type.GetType("System.String"))
      .Columns.Add("amttyp", Type.GetType("System.String"))
      .Columns.Add("entdt", Type.GetType("System.Int32"))
    End With
    ds2.Tables.Add(myTable)

  For I = 0 To ds.Tables(0).Rows.Count - 1
    With ds.Tables(0).Rows(I)
      dr = ds2.Tables(0).NewRow
      dr.Item(0) = .Item("trnbr")
      dr.Item(1) = .Item("jrnseq")
      dr.Item(2) = .Item("fdnbr")
      dr.Item(3) = .Item("sfund")
      dr.Item(4) = .Item("dpnbr")
      dr.Item(5) = .Item("obnbr")
      dr.Item(6) = .Item("fnpgm")
      dr.Item(7) = .Item("subfn")
      dr.Item(8) = .Item("amt")
      dr.Item(9) = .Item("gltyp")
      dr.Item(10) = .Item("amttyp")
      dr.Item(11) = GetDBDateInt(.Item("jent8"))
      ds2.Tables(0).Rows.Add(dr)
    End With
  Next

  Return ds2
End Function
Public Function GetDBDateInt(ByVal DateIn As Integer) As Integer
  Dim WrkDate As Integer
  Dim StrDate As String

  If DateIn > 0 Then
    StrDate = Trim$(Str(DateIn))
    Try
      WrkDate = Right$(StrDate, 4) & Left$(StrDate, 4)
    Catch
    End Try
  End If
  Return WrkDate
End Function
  Public Sub SetRange(ByVal WrkBatch As Integer)
  Dim objCommand As SqlCommand

  RecordNotFound = False
  IsEOF = False
  StrSQL = "Select * from " & cFileName & " where bchno=" & WrkBatch
  ConnRdr = MyDBConn.Open
  objCommand = New SqlCommand(StrSQL, ConnRdr)
  objreader = objCommand.ExecuteReader()
  objCommand = Nothing
End Sub
Public Sub ReadFileE()
  Dim Good As Boolean

  Good = objreader.Read()
  If Good Then
    GetFieldsRdr()
  Else
    CloseRange()
  End If
End Sub
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
  End Sub
  Public Sub CloseRange()
    IsEOF = True
    objreader.Close()
    ConnRdr.Close()
  End Sub
#End Region

#Region "Properties: Get/Put"
Public Sub GetFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
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
Public Sub GetFieldsRdr()
  With objreader
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

