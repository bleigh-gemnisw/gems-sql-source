Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "LEDGERJE"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Function GetTran(ByVal WrkPstdt As Integer, ByVal WrkBchno As Integer,
 ByVal WrkTran As Integer, ByVal NumRecs As Integer) As DataSet
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
    StrSQL = "Select " & WrkTop & "fdnbr,sfund,dpnbr,obnbr,fnpgm,subfn,amtyp,tramt," &
   "tdesc,bchno,prf from " & cFileName &
   " where pstdt=" & WrkPstdt & " and bchno=" & WrkBchno & " and trnbr=" & WrkTran
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
    Dim WrkAcct As String
    Dim I As Integer
    With myTable
      .TableName = "mytable" 'ds.Tables(0).TableName
      .Columns.Add("fdnbr", Type.GetType("System.Int16"))
      .Columns.Add("sfund", Type.GetType("System.Int16"))
      .Columns.Add("dpnbr", Type.GetType("System.Int16"))
      .Columns.Add("obnbr", Type.GetType("System.Int16"))
      .Columns.Add("fnpgm", Type.GetType("System.Int16"))
      .Columns.Add("subfn", Type.GetType("System.Int16"))
      .Columns.Add("acct", Type.GetType("System.String"))
      .Columns.Add("debit", Type.GetType("System.Decimal"))
      .Columns.Add("credit", Type.GetType("System.Decimal"))
      .Columns.Add("descr", Type.GetType("System.String"))
      .Columns.Add("tdesc", Type.GetType("System.String"))
      .Columns.Add("bchno", Type.GetType("System.Int16"))
      .Columns.Add("prf", Type.GetType("System.String"))
    End With
    ds2.Tables.Add(myTable)

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        dr = ds2.Tables(0).NewRow
        dr.Item(0) = .Item("fdnbr")
        dr.Item(1) = .Item("sfund")
        dr.Item(2) = .Item("dpnbr")
        dr.Item(3) = .Item("obnbr")
        dr.Item(4) = .Item("fnpgm")
        dr.Item(5) = .Item("subfn")
        WrkAcct = BuildAcct(.Item("fdnbr"), .Item("sfund"), .Item("dpnbr"), .Item("obnbr"), .Item("fnpgm"), .Item("subfn"))
        dr.Item(6) = WrkAcct
        If .Item("amtyp") = "D" Then
          dr.Item(7) = .Item("tramt")
          dr.Item(8) = 0
        Else
          dr.Item(7) = 0
          dr.Item(8) = .Item("tramt")
        End If
        dr.Item(9) = ""
        dr.Item(10) = .Item("tdesc")
        dr.Item(11) = .Item("bchno")
        dr.Item(12) = .Item("prf")
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
  Public Function BuildAcct(ByVal Fund As Integer, ByVal SFund As Integer, ByVal Dept As Integer, ByVal Obj As Integer,
 ByVal Func As Integer, ByVal Subfn As Integer) As String
    Dim sb As StringBuilder = New StringBuilder

    sb.Append(Format(Fund, "000"))
    sb.Append("-")
    sb.Append(Format(SFund, "000"))
    sb.Append("-")
    sb.Append(Format(Dept, "0000"))
    sb.Append("-")
    sb.Append(Format(Obj, "000"))
    sb.Append("-")
    sb.Append(Format(Func, "0000"))
    sb.Append("-")
    sb.Append(Format(Subfn, "0000"))
    Return sb.ToString
  End Function
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

