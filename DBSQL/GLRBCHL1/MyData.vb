Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "GLRBCH"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
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
  StrSQL = "Select " & WrkTop & "trnbr,sum(totdr) as sumdr,sum(totcr) as sumcr,trntyp from " & cFileName _
    & " where bchno=" & WrkBchno & " group by bchno, trnbr, trntyp order by bchno, trnbr"
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
Public Function GetViewbyBatch(ByVal WrkBchno As Integer, ByVal WrkTrnbr As Integer, _
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
  StrSQL = "Select " & WrkTop & "trnbr,jrnseq,fdnbr,sfund,dpnbr,obnbr,fnpgm,subfn,amt,trntyp,amttyp,jent8 from " & cFileName _
    & " where bchno=" & WrkBchno & " and trnbr=" & WrkTrnbr
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
      .Columns.Add("trnbr", Type.GetType("System.Int32"))
      .Columns.Add("jrnseq", Type.GetType("System.Int32"))
      .Columns.Add("fdnbr", Type.GetType("System.Int32"))
      .Columns.Add("sfund", Type.GetType("System.Int32"))
      .Columns.Add("dpnbr", Type.GetType("System.Int32"))
      .Columns.Add("obnbr", Type.GetType("System.Int32"))
      .Columns.Add("fnpgm", Type.GetType("System.Int32"))
      .Columns.Add("subfn", Type.GetType("System.Int32"))
      .Columns.Add("amt", Type.GetType("System.Decimal"))
      .Columns.Add("trntyp", Type.GetType("System.String"))
      .Columns.Add("amttyp", Type.GetType("System.String"))
      .Columns.Add("enddt", Type.GetType("System.Int32"))
    End With
    ds2.Tables.Add(myTable)

  For I = 0 To ds.Tables(0).Rows.Count - 1
    With ds.Tables(0).Rows(I)
      dr = ds2.Tables(0).NewRow
      dr.Item("trnbr") = .Item("trnbr")
      dr.Item("jrnseq") = .Item("jrnseq")
      dr.Item("fdnbr") = .Item("fdnbr")
      dr.Item("sfund") = .Item("sfund")
      dr.Item("dpnbr") = .Item("dpnbr")
      dr.Item("obnbr") = .Item("obnbr")
      dr.Item("fnpgm") = .Item("fnpgm")
      dr.Item("subfn") = .Item("subfn")
      dr.Item("amt") = .Item("amt")
      dr.Item("trntyp") = .Item("trntyp")
      dr.Item("amttyp") = .Item("amttyp")
      dr.Item("enddt") = GetDBDateInt(.Item("jent8"))
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
Public Function GetBatchCount(ByVal WrkBchno As Integer) As Integer
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim WrkCount As Integer

  RecordNotFound = False
  StrSQL = "Select count(jrnseq) from " & cFileName & " where bchno=" & WrkBchno & " and jrnseq>0"
  Try
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    WrkCount = ds.Tables(0).Rows(0).Item(0)
    objCommand = Nothing
    ds = Nothing
    Return WrkCount
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
    _BCHNO = .Item("BCHNO")
    _SEQNO = .Item("SEQNO")
    _VNDNR = .Item("VNDNR")
    _VENNM = .Item("VENNM")
    _INVNO = .Item("INVNO")
    _AMTGR = .Item("AMTGR")
    _AMTDS = .Item("AMTDS")
    _AMTSH = .Item("AMTSH")
    _AMTNT = .Item("AMTNT")
    _DSCTX = .Item("DSCTX")
    _PONBR = .Item("PONBR")
    _F1099 = .Item("F1099")
    _PPCKN = .Item("PPCKN")
    _PPAMT = .Item("PPAMT")
    _LEOPN = .Item("LEOPN")
    _BNKCD = .Item("BNKCD")
    _CSHYN = .Item("CSHYN")
    _FSCYR = .Item("FSCYR")
    _HINV = .Item("HINV")
    _INVD8 = .Item("INVD8")
    _DUED8 = .Item("DUED8")
    _PPDT8 = .Item("PPDT8")
    _PRJ = .Item("PRJ")
    _APPST = .Item("APPST")
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
Dim mSEQNO As Integer
Public Property _SEQNO As Integer
    Get
        Return mSEQNO
    End Get
    Set(ByVal value As Integer)
        mSEQNO = value
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
Dim mINVNO As String
Public Property _INVNO As String
    Get
        Return mINVNO
    End Get
    Set(ByVal value As String)
        mINVNO = value
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
Dim mAMTDS As Decimal
Public Property _AMTDS As Decimal
    Get
        Return mAMTDS
    End Get
    Set(ByVal value As Decimal)
        mAMTDS = value
    End Set
End Property
Dim mAMTSH As Decimal
Public Property _AMTSH As Decimal
    Get
        Return mAMTSH
    End Get
    Set(ByVal value As Decimal)
        mAMTSH = value
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
Dim mDSCTX As String
Public Property _DSCTX As String
    Get
        Return mDSCTX
    End Get
    Set(ByVal value As String)
        mDSCTX = value
    End Set
End Property
Dim mPONBR As Integer
Public Property _PONBR As Long
    Get
        Return mPONBR
    End Get
    Set(ByVal value As Long)
        mPONBR = value
    End Set
End Property
Dim mF1099 As String
Public Property _F1099 As String
    Get
        Return mF1099
    End Get
    Set(ByVal value As String)
        mF1099 = value
    End Set
End Property
Dim mPPCKN As Long
Public Property _PPCKN As Long
    Get
        Return mPPCKN
    End Get
    Set(ByVal value As Long)
        mPPCKN = value
    End Set
End Property
Dim mPPAMT As Decimal
Public Property _PPAMT As Decimal
    Get
        Return mPPAMT
    End Get
    Set(ByVal value As Decimal)
        mPPAMT = value
    End Set
End Property
Dim mLEOPN As String
Public Property _LEOPN As String
    Get
        Return mLEOPN
    End Get
    Set(ByVal value As String)
        mLEOPN = value
    End Set
End Property
Dim mBNKCD As String
Public Property _BNKCD As String
    Get
        Return mBNKCD
    End Get
    Set(ByVal value As String)
        mBNKCD = value
    End Set
End Property
Dim mCSHYN As String
Public Property _CSHYN As String
    Get
        Return mCSHYN
    End Get
    Set(ByVal value As String)
        mCSHYN = value
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
Dim mHINV As String
Public Property _HINV As String
    Get
        Return mHINV
    End Get
    Set(ByVal value As String)
        mHINV = value
    End Set
End Property
Dim mINVD8 As Integer
Public Property _INVD8 As Integer
    Get
        Return mINVD8
    End Get
    Set(ByVal value As Integer)
        mINVD8 = value
    End Set
End Property
Dim mDUED8 As Integer
Public Property _DUED8 As Integer
    Get
        Return mDUED8
    End Get
    Set(ByVal value As Integer)
        mDUED8 = value
    End Set
End Property
Dim mPPDT8 As Integer
Public Property _PPDT8 As Integer
    Get
        Return mPPDT8
    End Get
    Set(ByVal value As Integer)
        mPPDT8 = value
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
Dim mAPPST As Integer
Public Property _APPST As Integer
    Get
        Return mAPPST
    End Get
    Set(ByVal value As Integer)
        mAPPST = value
    End Set
End Property
#End Region
End Class

