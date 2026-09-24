Imports System.Data
Imports System.Data.SqlClient
Public Class TXHST
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Dim Conn As SqlConnection
  Const MyFileName As String = "TXHST"
#Region "Constructors"

  Public Sub New(ByVal WrkConn As SqlConnection)
    Conn = WrkConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Function AutoGenKey(ByVal WrkBchno As Integer, ByVal WrkSeqno As Integer) As Integer
    Dim NextKey As Integer
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select top 1 * from " & MyFileName & " order by recid desc"
    Try
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, MyFileName)
      If ds.Tables(0).Rows.Count = 0 Then
        NextKey = 1
      Else
        NextKey = ds.Tables(0).Rows(0).Item("recid") + 1
      End If
      If NextKey > 999999999 Then
        NextKey = 1
      End If
      objCommand = Nothing
      ds.Clear()
      ds = Nothing
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try
    Return NextKey
  End Function
  Public Sub GetOneRecordP(ByVal Wrkrecid As Integer)
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & MyFileName & " where recid = " & Wrkrecid
    Try
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, MyFileName)
      If ds.Tables(0).Rows.Count = 0 Then
        RecordNotFound = True
      Else
        GetFields(ds)
      End If
      objCommand = Nothing
      ds.Clear()
      ds = Nothing
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
    da.Fill(ds, MyFileName)
    dr = ds.Tables(0).NewRow
    ds.Tables(0).Rows.Add(dr)
    PutFields(ds)
    da.Update(ds, MyFileName)
    ds = Nothing
  End Sub
  Public Sub DeleteOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet

    da.DeleteCommand = CmdBldr.GetDeleteCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, MyFileName)
    ds.Tables(0).Rows(0).Delete()
    da.Update(ds, MyFileName)
    ds = Nothing
  End Sub
  Public Sub InsertOneRecordP()
    Dim objCommand As SqlCommand
    Const caa As String = "','" 'Alpha Before/Alpha After
    Const can As String = "'," 'Alpha Before/Numeric After
    Const cna As String = ",'" 'Numeric Before/Alpha After
    Const cnn As String = "," 'Numeric Before/Numeric After

    StrSQL = "Insert into " & MyFileName & " values(" &
           _RECID & cna & _RCODE & can & _LISTNO & cnn & _YEAR & cna & _TYPE & can & _PAMT & cnn &
           _IAMT & cnn & _LAMT & cnn & _PCAMT & cna & _PENCD & can & _CASH & cnn & _CHECK & cnn &
           _CREDIT & cna & _CORC & can & _DIST & cna & _REF & caa & _COMM & caa & _ADJCD & can &
           _BATCHN & cnn & _BATCHS & cna & _BATCHA & can & _PDATE & cnn & _CDATE & cna & _SUSCD & caa &
           _THAJCD & caa & _THINPD & can & _INTOR & cna & _PRF & can & _CHDATE & cnn & _CHTIME & ")"
    Try
      objCommand = New SqlCommand(StrSQL, Conn)
      da = New SqlDataAdapter
      da.InsertCommand = objCommand
      da.InsertCommand.ExecuteNonQuery()
      objCommand = Nothing
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try
  End Sub
  Public Sub UpdateOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet
    da.UpdateCommand = CmdBldr.GetUpdateCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, MyFileName)
    PutFields(ds)
    da.Update(ds, MyFileName)
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
      _RECID = .Item("RECID")
      _RCODE = .Item("RCODE")
      _LISTNO = .Item("LIST#")
      _YEAR = .Item("YEAR")
      _TYPE = .Item("TYPE")
      _PAMT = .Item("PAMT")
      _IAMT = .Item("IAMT")
      _LAMT = .Item("LAMT")
      _PCAMT = .Item("PCAMT")
      _PENCD = .Item("PENCD")
      _CASH = .Item("CASH")
      _CHECK = .Item("CHECK")
      _CREDIT = .Item("CREDIT")
      _CORC = .Item("CORC")
      _DIST = .Item("DIST")
      _REF = .Item("REF")
      _COMM = .Item("COMM")
      _ADJCD = .Item("ADJCD")
      _BATCHN = .Item("BATCHN")
      _BATCHS = .Item("BATCHS")
      _BATCHA = .Item("BATCHA")
      _PDATE = .Item("PDATE")
      _CDATE = .Item("CDATE")
      _SUSCD = .Item("SUSCD")
      _THAJCD = .Item("THAJCD")
      _THINPD = .Item("THINPD")
      _INTOR = .Item("INTOR")
      _PRF = .Item("PRF")
      _CHDATE = .Item("CHDATE")
      _CHTIME = .Item("CHTIME")

    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("RECID") = _RECID
      .Item("RCODE") = _RCODE
      .Item("LIST#") = _LISTNO
      .Item("YEAR") = _YEAR
      .Item("TYPE") = _TYPE
      .Item("PAMT") = _PAMT
      .Item("IAMT") = _IAMT
      .Item("LAMT") = _LAMT
      .Item("PCAMT") = _PCAMT
      .Item("PENCD") = _PENCD
      .Item("CASH") = _CASH
      .Item("CHECK") = _CHECK
      .Item("CREDIT") = _CREDIT
      .Item("CORC") = _CORC
      .Item("DIST") = _DIST
      .Item("REF") = _REF
      .Item("COMM") = _COMM
      .Item("ADJCD") = _ADJCD
      .Item("BATCHN") = _BATCHN
      .Item("BATCHS") = _BATCHS
      .Item("BATCHA") = _BATCHA
      .Item("PDATE") = _PDATE
      .Item("CDATE") = _CDATE
      .Item("SUSCD") = _SUSCD
      .Item("THAJCD") = _THAJCD
      .Item("THINPD") = _THINPD
      .Item("INTOR") = _INTOR
      .Item("PRF") = _PRF
      .Item("CHDATE") = _CHDATE
      .Item("CHTIME") = _CHTIME

    End With
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


