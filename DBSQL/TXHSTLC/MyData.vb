Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "TXHST"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Function GetViewbyRef(ByVal WrkRef As String, ByVal WrkAsof As Integer, ByVal WrkCutoff As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select ref,list#,year,type,pdate,pamt,iamt,lamt,pcamt,pencd,adjcd,batcha,batchn,corc,comm from " & cFileName _
    & " where ref ='" & WrkRef & "' and pdate<=" & WrkAsof & " and pdate>=" & WrkCutoff _
    & " order by pdate desc"
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
      .Columns.Add("ref", Type.GetType("System.String"))
      .Columns.Add("list#", Type.GetType("System.Int32"))
      .Columns.Add("type", Type.GetType("System.String"))
      .Columns.Add("year", Type.GetType("System.Int16"))
      .Columns.Add("wkdate", Type.GetType("System.Int32"))
      .Columns.Add("pdate", Type.GetType("System.Int32"))
      .Columns.Add("pamt", Type.GetType("System.Decimal"))
      .Columns.Add("iamt", Type.GetType("System.Decimal"))
      .Columns.Add("pcamt", Type.GetType("System.Decimal"))
      .Columns.Add("lamt", Type.GetType("System.Decimal"))
      .Columns.Add("wktot", Type.GetType("System.Decimal"))
      .Columns.Add("adjcd", Type.GetType("System.String"))
      .Columns.Add("pencd", Type.GetType("System.String"))
      .Columns.Add("batcha", Type.GetType("System.String"))
      .Columns.Add("batchn", Type.GetType("System.Int32"))
      .Columns.Add("comm", Type.GetType("System.String"))
    End With
    ds2.Tables.Add(myTable)

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        dr = ds2.Tables(0).NewRow
        dr.Item("ref") = .Item("ref")
        dr.Item("list#") = .Item("list#")
        dr.Item("type") = .Item("type")
        dr.Item("year") = .Item("year")
        dr.Item("wkdate") = GetDBDateInt(.Item("pdate"))
        dr.Item("pdate") = .Item("pdate")
        dr.Item("pamt") = .Item("pamt")
        dr.Item("iamt") = .Item("iamt")
        dr.Item("pcamt") = .Item("pcamt")
        dr.Item("lamt") = .Item("lamt")
        dr.Item("wktot") = .Item("pamt") + .Item("iamt") + .Item("lamt") + .Item("pcamt")
        dr.Item("adjcd") = .Item("adjcd")
        dr.Item("pencd") = .Item("pencd")
        dr.Item("batcha") = .Item("batcha")
        dr.Item("batchn") = .Item("batchn")
        dr.Item("comm") = .Item("comm")
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
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
  End Sub
#End Region

#Region "Properties: Fields"
  Dim mRECID As Long
  Public Property _RECID As Long
    Get
      Return mRECID
    End Get
    Set(ByVal value As Long)
      mRECID = value
    End Set
  End Property

  Dim mRCODE As String
  Public Property _RCODE As String
    Get
      Return mRCODE
    End Get
    Set(ByVal value As String)
      mRCODE = value
    End Set
  End Property

  Dim mLISTNO As Integer
  Public Property _LISTNO As Integer
    Get
      Return mLISTNO
    End Get
    Set(ByVal value As Integer)
      mLISTNO = value
    End Set
  End Property

  Dim mYEAR As Integer
  Public Property _YEAR As Integer
    Get
      Return mYEAR
    End Get
    Set(ByVal value As Integer)
      mYEAR = value
    End Set
  End Property

  Dim mTYPE As String
  Public Property _TYPE As String
    Get
      Return mTYPE
    End Get
    Set(ByVal value As String)
      mTYPE = value
    End Set
  End Property

  Dim mPAMT As Decimal
  Public Property _PAMT As Decimal
    Get
      Return mPAMT
    End Get
    Set(ByVal value As Decimal)
      mPAMT = value
    End Set
  End Property

  Dim mIAMT As Decimal
  Public Property _IAMT As Decimal
    Get
      Return mIAMT
    End Get
    Set(ByVal value As Decimal)
      mIAMT = value
    End Set
  End Property

  Dim mLAMT As Decimal
  Public Property _LAMT As Decimal
    Get
      Return mLAMT
    End Get
    Set(ByVal value As Decimal)
      mLAMT = value
    End Set
  End Property

  Dim mPCAMT As Decimal
  Public Property _PCAMT As Decimal
    Get
      Return mPCAMT
    End Get
    Set(ByVal value As Decimal)
      mPCAMT = value
    End Set
  End Property

  Dim mPENCD As String
  Public Property _PENCD As String
    Get
      Return mPENCD
    End Get
    Set(ByVal value As String)
      mPENCD = value
    End Set
  End Property

  Dim mCASH As Decimal
  Public Property _CASH As Decimal
    Get
      Return mCASH
    End Get
    Set(ByVal value As Decimal)
      mCASH = value
    End Set
  End Property

  Dim mCHECK As Decimal
  Public Property _CHECK As Decimal
    Get
      Return mCHECK
    End Get
    Set(ByVal value As Decimal)
      mCHECK = value
    End Set
  End Property

  Dim mCREDIT As Decimal
  Public Property _CREDIT As Decimal
    Get
      Return mCREDIT
    End Get
    Set(ByVal value As Decimal)
      mCREDIT = value
    End Set
  End Property

  Dim mCORC As String
  Public Property _CORC As String
    Get
      Return mCORC
    End Get
    Set(ByVal value As String)
      mCORC = value
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

  Dim mREF As String
  Public Property _REF As String
    Get
      Return mREF
    End Get
    Set(ByVal value As String)
      mREF = value
    End Set
  End Property

  Dim mCOMM As String
  Public Property _COMM As String
    Get
      Return mCOMM
    End Get
    Set(ByVal value As String)
      mCOMM = value
    End Set
  End Property

  Dim mADJCD As String
  Public Property _ADJCD As String
    Get
      Return mADJCD
    End Get
    Set(ByVal value As String)
      mADJCD = value
    End Set
  End Property

  Dim mBATCHN As Integer
  Public Property _BATCHN As Integer
    Get
      Return mBATCHN
    End Get
    Set(ByVal value As Integer)
      mBATCHN = value
    End Set
  End Property

  Dim mBATCHS As Integer
  Public Property _BATCHS As Integer
    Get
      Return mBATCHS
    End Get
    Set(ByVal value As Integer)
      mBATCHS = value
    End Set
  End Property

  Dim mBATCHA As String
  Public Property _BATCHA As String
    Get
      Return mBATCHA
    End Get
    Set(ByVal value As String)
      mBATCHA = value
    End Set
  End Property

  Dim mPDATE As Integer
  Public Property _PDATE As Integer
    Get
      Return mPDATE
    End Get
    Set(ByVal value As Integer)
      mPDATE = value
    End Set
  End Property

  Dim mCDATE As Integer
  Public Property _CDATE As Integer
    Get
      Return mCDATE
    End Get
    Set(ByVal value As Integer)
      mCDATE = value
    End Set
  End Property

  Dim mSUSCD As String
  Public Property _SUSCD As String
    Get
      Return mSUSCD
    End Get
    Set(ByVal value As String)
      mSUSCD = value
    End Set
  End Property

  Dim mTHAJCD As String
  Public Property _THAJCD As String
    Get
      Return mTHAJCD
    End Get
    Set(ByVal value As String)
      mTHAJCD = value
    End Set
  End Property

  Dim mTHINPD As String
  Public Property _THINPD As String
    Get
      Return mTHINPD
    End Get
    Set(ByVal value As String)
      mTHINPD = value
    End Set
  End Property

  Dim mINTOR As Decimal
  Public Property _INTOR As Decimal
    Get
      Return mINTOR
    End Get
    Set(ByVal value As Decimal)
      mINTOR = value
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

  Dim mCHDATE As Integer
  Public Property _CHDATE As Integer
    Get
      Return mCHDATE
    End Get
    Set(ByVal value As Integer)
      mCHDATE = value
    End Set
  End Property

  Dim mCHTIME As Integer
  Public Property _CHTIME As Integer
    Get
      Return mCHTIME
    End Get
    Set(ByVal value As Integer)
      mCHTIME = value
    End Set
  End Property

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
#End Region
End Class


