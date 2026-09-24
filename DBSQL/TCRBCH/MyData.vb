Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Private _ErrMsg As String = ""  'added 6/12/25
  Const cFileName As String = "TCRBCH"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _BCHNO = 0
    _TRNBR = 0
    _RDTE = 0
    _IDTE = 0
    _PAMT = 0
    _IAMT = 0
    _LAMT = 0
    _PCAMT = 0
    _PCAMT1 = 0
    _PENCD1 = String.Empty
    _PCAMT2 = 0
    _PENCD2 = String.Empty
    _PCAMT3 = 0
    _PENCD3 = String.Empty
    _PCAMT4 = 0
    _PENCD4 = String.Empty
    _PCAMT5 = 0
    _PENCD5 = String.Empty
    _PCAMT6 = 0
    _PENCD6 = String.Empty
    _PCAMT7 = 0
    _PENCD7 = String.Empty
    _PMETH = String.Empty
    _REF = String.Empty
    _CHAMT = 0
    _REFN = String.Empty
    _ADJ = String.Empty
    _COMM = String.Empty
    _LISTNo = 0
    _YEAR = 0
    _TYPE = String.Empty
    _SRC = 0
    _NAME = String.Empty
    _BKSR = String.Empty
    _BKCD = String.Empty
    _DIST = 0
    _BKBC = 0
    _BKNA = String.Empty

  End Sub
  Public Function AutoGenKey(ByVal WrkBchno As Integer) As Integer
    Dim NextKey As Integer
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where bchno=" & WrkBchno & " order by trnbr desc"
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
        NextKey = ds.Tables(0).Rows(0).Item("trnbr") + 1
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
  Public Sub GetOneRecordP(ByVal WrkBchno As Integer, ByVal WrkTrnbr As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where bchno=" & WrkBchno & " and trnbr=" & WrkTrnbr
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      If ds.Tables(0).Rows.Count = 0 Then
        RecordNotFound = True
        ClearFields()
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
  Public Function PosData(ByVal WrkBchno As Integer, ByVal WrkTrnbr As Integer, ByVal NumRecs As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    Dim WrkTop As String
    WrkTop = String.Empty

    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & "* from " & cFileName & " where bchno=" & WrkBchno &
   " and trnbr>=" & WrkTrnbr & " order by trnbr"
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    objCommand = Nothing
    Conn.Close()
    Return ds
  End Function
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
  '---------------
  ' added 6/12/25  add for txa08
  ' --------------
  Public Sub AddOneRecordFast()
    Try
      Dim sql As String = "
      INSERT INTO TCRBCH (
        BCHNO, TRNBR, RDTE, PAMT, IAMT, LAMT, PCAMT, PCAMT1, PENCD1, PCAMT2, PENCD2, PCAMT3, PENCD3,
        PCAMT4, PENCD4, PCAMT5, PENCD5, PCAMT6, PENCD6, PCAMT7, PENCD7, PMETH, REF, CHAMT, REFN, ADJ,
        COMM, [LIST#], YEAR, TYPE, SRC, NAME, BKSR, BKCD, DIST, BKBC, BKNA
      )
      VALUES (
        @BCHNO, @TRNBR, @RDTE, @PAMT, @IAMT, @LAMT, @PCAMT, @PCAMT1, @PENCD1, @PCAMT2, @PENCD2, @PCAMT3, @PENCD3,
        @PCAMT4, @PENCD4, @PCAMT5, @PENCD5, @PCAMT6, @PENCD6, @PCAMT7, @PENCD7, @PMETH, @REF, @CHAMT, @REFN, @ADJ,
        @COMM, @LISTNO, @YEAR, @TYPE, @SRC, @NAME, @BKSR, @BKCD, @DIST, @BKBC, @BKNA
      )"

      Using conn As SqlConnection = MyDBConn.Open()
        Using cmd As New SqlCommand(sql, conn)
          cmd.Parameters.AddWithValue("@BCHNO", _BCHNO)
          cmd.Parameters.AddWithValue("@TRNBR", _TRNBR)
          cmd.Parameters.AddWithValue("@RDTE", _RDTE)
          cmd.Parameters.AddWithValue("@PAMT", _PAMT)
          cmd.Parameters.AddWithValue("@IAMT", _IAMT)
          cmd.Parameters.AddWithValue("@LAMT", _LAMT)
          cmd.Parameters.AddWithValue("@PCAMT", _PCAMT)
          cmd.Parameters.AddWithValue("@PCAMT1", _PCAMT1)
          cmd.Parameters.AddWithValue("@PENCD1", _PENCD1)
          cmd.Parameters.AddWithValue("@PCAMT2", _PCAMT2)
          cmd.Parameters.AddWithValue("@PENCD2", _PENCD2)
          cmd.Parameters.AddWithValue("@PCAMT3", _PCAMT3)
          cmd.Parameters.AddWithValue("@PENCD3", _PENCD3)
          cmd.Parameters.AddWithValue("@PCAMT4", _PCAMT4)
          cmd.Parameters.AddWithValue("@PENCD4", _PENCD4)
          cmd.Parameters.AddWithValue("@PCAMT5", _PCAMT5)
          cmd.Parameters.AddWithValue("@PENCD5", _PENCD5)
          cmd.Parameters.AddWithValue("@PCAMT6", _PCAMT6)
          cmd.Parameters.AddWithValue("@PENCD6", _PENCD6)
          cmd.Parameters.AddWithValue("@PCAMT7", _PCAMT7)
          cmd.Parameters.AddWithValue("@PENCD7", _PENCD7)
          cmd.Parameters.AddWithValue("@PMETH", _PMETH)
          cmd.Parameters.AddWithValue("@REF", _REF)
          cmd.Parameters.AddWithValue("@CHAMT", _CHAMT)
          cmd.Parameters.AddWithValue("@REFN", _REFN)
          cmd.Parameters.AddWithValue("@ADJ", _ADJ)
          cmd.Parameters.AddWithValue("@COMM", _COMM)
          cmd.Parameters.AddWithValue("@LISTNO", _LISTNo)
          cmd.Parameters.AddWithValue("@YEAR", _YEAR)
          cmd.Parameters.AddWithValue("@TYPE", _TYPE)
          cmd.Parameters.AddWithValue("@SRC", _SRC)
          cmd.Parameters.AddWithValue("@NAME", _NAME)
          cmd.Parameters.AddWithValue("@BKSR", _BKSR)
          cmd.Parameters.AddWithValue("@BKCD", _BKCD)
          cmd.Parameters.AddWithValue("@DIST", _DIST)
          cmd.Parameters.AddWithValue("@BKBC", _BKBC)
          cmd.Parameters.AddWithValue("@BKNA", _BKNA)

          cmd.ExecuteNonQuery()
        End Using
      End Using

      _ErrMsg = ""

    Catch ex As Exception
      _ErrMsg = ex.Message
    End Try
  End Sub


  '--------------------------------------
  ' end add 6/12/25
  '--------------------------------------
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
      _RDTE = .Item("RDTE")
      _PAMT = .Item("PAMT")
      _IAMT = .Item("IAMT")
      _LAMT = .Item("LAMT")
      _PCAMT = .Item("PCAMT")
      _PCAMT1 = .Item("PCAMT1")
      _PENCD1 = .Item("PENCD1")
      _PCAMT2 = .Item("PCAMT2")
      _PENCD2 = .Item("PENCD2")
      _PCAMT3 = .Item("PCAMT3")
      _PENCD3 = .Item("PENCD3")
      _PCAMT4 = .Item("PCAMT4")
      _PENCD4 = .Item("PENCD4")
      _PCAMT5 = .Item("PCAMT5")
      _PENCD5 = .Item("PENCD5")
      _PCAMT6 = .Item("PCAMT6")
      _PENCD6 = .Item("PENCD6")
      _PCAMT7 = .Item("PCAMT7")
      _PENCD7 = .Item("PENCD7")
      _PMETH = .Item("PMETH")
      _REF = .Item("REF")
      _CHAMT = .Item("CHAMT")
      _REFN = .Item("REFN")
      _ADJ = .Item("ADJ")
      _COMM = .Item("COMM")
      _LISTNo = .Item("LIST#")
      _YEAR = .Item("YEAR")
      _TYPE = .Item("TYPE")
      _SRC = .Item("SRC")
      _NAME = .Item("NAME")
      _BKSR = .Item("BKSR")
      _BKCD = .Item("BKCD")
      _DIST = .Item("DIST")
      _BKBC = .Item("BKBC")
      _BKNA = .Item("BKNA")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("BCHNO") = _BCHNO
      .Item("TRNBR") = _TRNBR
      .Item("RDTE") = _RDTE
      .Item("PAMT") = _PAMT
      .Item("IAMT") = _IAMT
      .Item("LAMT") = _LAMT
      .Item("PCAMT") = _PCAMT
      .Item("PCAMT1") = _PCAMT1
      .Item("PENCD1") = _PENCD1
      .Item("PCAMT2") = _PCAMT2
      .Item("PENCD2") = _PENCD2
      .Item("PCAMT3") = _PCAMT3
      .Item("PENCD3") = _PENCD3
      .Item("PCAMT4") = _PCAMT4
      .Item("PENCD4") = _PENCD4
      .Item("PCAMT5") = _PCAMT5
      .Item("PENCD5") = _PENCD5
      .Item("PCAMT6") = _PCAMT6
      .Item("PENCD6") = _PENCD6
      .Item("PCAMT7") = _PCAMT7
      .Item("PENCD7") = _PENCD7
      .Item("PMETH") = _PMETH
      .Item("REF") = _REF
      .Item("CHAMT") = _CHAMT
      .Item("REFN") = _REFN
      .Item("ADJ") = _ADJ
      .Item("COMM") = _COMM
      .Item("LIST#") = _LISTNo
      .Item("YEAR") = _YEAR
      .Item("TYPE") = _TYPE
      .Item("SRC") = _SRC
      .Item("NAME") = _NAME
      .Item("BKSR") = _BKSR
      .Item("BKCD") = _BKCD
      .Item("DIST") = _DIST
      .Item("BKBC") = _BKBC
      .Item("BKNA") = _BKNA
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

  Dim mRDTE As Integer
  Public Property _RDTE As Integer
    Get
      Return mRDTE
    End Get
    Set(ByVal value As Integer)
      mRDTE = value
    End Set
  End Property

  Dim mIDTE As Integer
  Public Property _IDTE As Integer
    Get
      Return mIDTE
    End Get
    Set(ByVal value As Integer)
      mRDTE = value
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

  Dim mPCAMT1 As Decimal
  Public Property _PCAMT1 As Decimal
    Get
      Return mPCAMT1
    End Get
    Set(ByVal value As Decimal)
      mPCAMT1 = value
    End Set
  End Property

  Dim mPENCD1 As String
  Public Property _PENCD1 As String
    Get
      Return mPENCD1
    End Get
    Set(ByVal value As String)
      mPENCD1 = value
    End Set
  End Property

  Dim mPCAMT2 As Decimal
  Public Property _PCAMT2 As Decimal
    Get
      Return mPCAMT2
    End Get
    Set(ByVal value As Decimal)
      mPCAMT2 = value
    End Set
  End Property

  Dim mPENCD2 As String
  Public Property _PENCD2 As String
    Get
      Return mPENCD2
    End Get
    Set(ByVal value As String)
      mPENCD2 = value
    End Set
  End Property

  Dim mPCAMT3 As Decimal
  Public Property _PCAMT3 As Decimal
    Get
      Return mPCAMT3
    End Get
    Set(ByVal value As Decimal)
      mPCAMT3 = value
    End Set
  End Property

  Dim mPENCD3 As String
  Public Property _PENCD3 As String
    Get
      Return mPENCD3
    End Get
    Set(ByVal value As String)
      mPENCD3 = value
    End Set
  End Property

  Dim mPCAMT4 As Decimal
  Public Property _PCAMT4 As Decimal
    Get
      Return mPCAMT4
    End Get
    Set(ByVal value As Decimal)
      mPCAMT4 = value
    End Set
  End Property

  Dim mPENCD4 As String
  Public Property _PENCD4 As String
    Get
      Return mPENCD4
    End Get
    Set(ByVal value As String)
      mPENCD4 = value
    End Set
  End Property

  Dim mPCAMT5 As Decimal
  Public Property _PCAMT5 As Decimal
    Get
      Return mPCAMT5
    End Get
    Set(ByVal value As Decimal)
      mPCAMT5 = value
    End Set
  End Property

  Dim mPENCD5 As String
  Public Property _PENCD5 As String
    Get
      Return mPENCD5
    End Get
    Set(ByVal value As String)
      mPENCD5 = value
    End Set
  End Property

  Dim mPCAMT6 As Decimal
  Public Property _PCAMT6 As Decimal
    Get
      Return mPCAMT6
    End Get
    Set(ByVal value As Decimal)
      mPCAMT6 = value
    End Set
  End Property

  Dim mPENCD6 As String
  Public Property _PENCD6 As String
    Get
      Return mPENCD6
    End Get
    Set(ByVal value As String)
      mPENCD6 = value
    End Set
  End Property

  Dim mPCAMT7 As Decimal
  Public Property _PCAMT7 As Decimal
    Get
      Return mPCAMT7
    End Get
    Set(ByVal value As Decimal)
      mPCAMT7 = value
    End Set
  End Property

  Dim mPENCD7 As String
  Public Property _PENCD7 As String
    Get
      Return mPENCD7
    End Get
    Set(ByVal value As String)
      mPENCD7 = value
    End Set
  End Property

  Dim mPMETH As String
  Public Property _PMETH As String
    Get
      Return mPMETH
    End Get
    Set(ByVal value As String)
      mPMETH = value
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

  Dim mCHAMT As Decimal
  Public Property _CHAMT As Decimal
    Get
      Return mCHAMT
    End Get
    Set(ByVal value As Decimal)
      mCHAMT = value
    End Set
  End Property

  Dim mREFN As String
  Public Property _REFN As String
    Get
      Return mREFN
    End Get
    Set(ByVal value As String)
      mREFN = value
    End Set
  End Property

  Dim mADJ As String
  Public Property _ADJ As String
    Get
      Return mADJ
    End Get
    Set(ByVal value As String)
      mADJ = value
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

  Dim mLISTNo As Integer
  Public Property _LISTNo As Integer
    Get
      Return mLISTNo
    End Get
    Set(ByVal value As Integer)
      mLISTNo = value
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

  Dim mSRC As Integer
  Public Property _SRC As Integer
    Get
      Return mSRC
    End Get
    Set(ByVal value As Integer)
      mSRC = value
    End Set
  End Property

  Dim mNAME As String
  Public Property _NAME As String
    Get
      Return mNAME
    End Get
    Set(ByVal value As String)
      mNAME = value
    End Set
  End Property

  Dim mBKSR As String
  Public Property _BKSR As String
    Get
      Return mBKSR
    End Get
    Set(ByVal value As String)
      mBKSR = value
    End Set
  End Property

  Dim mBKCD As String
  Public Property _BKCD As String
    Get
      Return mBKCD
    End Get
    Set(ByVal value As String)
      mBKCD = value
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

  Dim mBKBC As Integer
  Public Property _BKBC As Integer
    Get
      Return mBKBC
    End Get
    Set(ByVal value As Integer)
      mBKBC = value
    End Set
  End Property

  Dim mBKNA As String
  Public Property _BKNA As String
    Get
      Return mBKNA
    End Get
    Set(ByVal value As String)
      mBKNA = value
    End Set
  End Property
#End Region
End Class

