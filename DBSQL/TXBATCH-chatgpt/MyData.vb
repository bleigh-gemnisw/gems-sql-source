Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "TXBATCH"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _JSTAT = String.Empty
    _LISTNo = 0
    _YEAR = 0
    _TYPE = String.Empty
    _PAMT = 0
    _IAMT = 0
    _LAMT = 0
    _TCAMT = 0
    _CORC = String.Empty
    _DIST = 0
    _REFE = String.Empty
    _COMM = String.Empty
    _ADJCD = String.Empty
    _JSEQNO = 0
    _JBATCH = 0
    _JBTCHC = String.Empty
    _JBTCHT = String.Empty
    _JTCODE = String.Empty
    _JUCODE = String.Empty
    _NAME = String.Empty
    _CASH = 0
    _CHECK = 0
    _CREDIT = 0
    _ASOFD = 0
    _CPENCD = String.Empty
    _CINTPD = String.Empty
    _JIY = 0
    _JIM = 0
    _JID = 0
    _JRY = 0
    _JRM = 0
    _JRD = 0
    _SIMT = 0
    _TMSP = 0
    _TBL = 0
    _ARC = 0
    _MR = String.Empty
    _AD1 = String.Empty
    _AD2 = String.Empty
    _CY = String.Empty
    _SAT = String.Empty
    _ZI5 = 0
    _ZI4 = 0

  End Sub
  Public Function AutoGenKey(ByVal WrkBatchCd As String, ByVal WrkBchno As Integer) As Integer
    Dim NextKey As Integer = 1
    Dim query As String = "SELECT TOP 1 jseqno FROM " & cFileName & " WHERE jbtchc = @BatchCd AND jbatch = @BatchNo ORDER BY jseqno DESC"

    Try
      Using Conn As SqlConnection = MyDBConn.Open()
        Using cmd As New SqlCommand(query, Conn)
          cmd.Parameters.AddWithValue("@BatchCd", WrkBatchCd)
          cmd.Parameters.AddWithValue("@BatchNo", WrkBchno)

          Dim result = cmd.ExecuteScalar()
          If result IsNot Nothing AndAlso Not IsDBNull(result) Then
            NextKey = Convert.ToInt32(result) + 1
          End If
        End Using
      End Using
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try

    Return NextKey
  End Function
  Public Function CalcBatchSubTotals(ByVal WrkBatchCd As String, ByVal WrkBchno As Integer) As Decimal()
    Dim WrkAmount(2) As Decimal
    Dim ds As New DataSet
    Dim StrSQL As String = "SELECT cash, [check], credit, tbl FROM " & cFileName &
                           " WHERE jbatch = @Bchno AND jstat <> 'V' ORDER BY jseqno DESC"

    Try
      Using Conn As SqlConnection = MyDBConn.Open()
        Using objCommand As New SqlCommand(StrSQL, Conn)
          objCommand.Parameters.AddWithValue("@Bchno", WrkBchno)

          Using da As New SqlDataAdapter(objCommand)
            da.Fill(ds, cFileName)

            For Each row As DataRow In ds.Tables(0).Rows
              If Convert.ToDecimal(row("tbl")) <> 0 Then Exit For
              WrkAmount(0) += Convert.ToDecimal(row("cash"))
              WrkAmount(1) += Convert.ToDecimal(row("check"))
              WrkAmount(2) += Convert.ToDecimal(row("credit"))
            Next
          End Using
        End Using
      End Using

      Return WrkAmount

    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Sub GetOneRecordP(ByVal WrkBatchCd As String, WrkBchno As Integer, ByVal WrkSeqno As Integer)
    RecordNotFound = False

    Dim StrSQL As String = "SELECT * FROM " & cFileName & " WHERE jbtchc=@WrkBatchCd AND jbatch=@WrkBchno AND jseqno=@WrkSeqno"

    Try
      Using Conn As SqlConnection = MyDBConn.Open()
        Using objCommand As New SqlCommand(StrSQL, Conn)
          objCommand.Parameters.AddWithValue("@WrkBatchCd", WrkBatchCd)
          objCommand.Parameters.AddWithValue("@WrkBchno", WrkBchno)
          objCommand.Parameters.AddWithValue("@WrkSeqno", WrkSeqno)

          Dim da As New SqlDataAdapter(objCommand)
          Dim ds As New DataSet()
          da.Fill(ds, cFileName)

          If ds.Tables(0).Rows.Count = 0 Then
            RecordNotFound = True
            ClearFields()
          Else
            GetFields(ds)
          End If
        End Using
      End Using
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try
  End Sub
  Public Function PosData(ByVal WrkBatchCd As String, ByVal WrkBchno As Integer, ByVal WrkSeqno As Integer,
                        ByVal NumRecs As Integer) As DataSet
    Dim ds As New DataSet()
    Dim WrkTop As String = If(NumRecs > 0, "TOP " & NumRecs.ToString() & " ", "")
    Dim query As String = $"SELECT {WrkTop}* FROM {cFileName} WHERE jbtchc = @batchCd AND jbatch = @batchNo AND jseqno >= @seqNo ORDER BY jseqno"

    Using Conn As SqlConnection = MyDBConn.Open()
      Using objCommand As New SqlCommand(query, Conn)
        objCommand.Parameters.AddWithValue("@batchCd", WrkBatchCd)
        objCommand.Parameters.AddWithValue("@batchNo", WrkBchno)
        objCommand.Parameters.AddWithValue("@seqNo", WrkSeqno)

        Using da As New SqlDataAdapter(objCommand)
          da.Fill(ds, cFileName)
        End Using
      End Using
    End Using

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
  Public Sub DeleteBatch(ByVal WrkBatchCd As String, WrkBchno As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    RecordNotFound = False
    IsEOF = False
    StrSQL = "Delete from " & cFileName & " where jbtchc='" & WrkBatchCd & "' and jbatch=" & WrkBchno
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
      _JSTAT = .Item("JSTAT")
      _LISTNo = .Item("LIST#")
      _YEAR = .Item("YEAR")
      _TYPE = .Item("TYPE")
      _PAMT = .Item("PAMT")
      _IAMT = .Item("IAMT")
      _LAMT = .Item("LAMT")
      _TCAMT = .Item("TCAMT")
      _CORC = .Item("CORC")
      _DIST = .Item("DIST")
      _REFE = .Item("REFE")
      _COMM = .Item("COMM")
      _ADJCD = .Item("ADJCD")
      _JSEQNO = .Item("JSEQNO")
      _JBATCH = .Item("JBATCH")
      _JBTCHC = .Item("JBTCHC")
      _JBTCHT = .Item("JBTCHT")
      _JTCODE = .Item("JTCODE")
      _JUCODE = .Item("JUCODE")
      _NAME = .Item("NAME")
      _CASH = .Item("CASH")
      _CHECK = .Item("CHECK")
      _CREDIT = .Item("CREDIT")
      _ASOFD = .Item("ASOFD")
      _CPENCD = .Item("CPENCD")
      _CINTPD = .Item("CINTPD")
      _JIY = .Item("JIY")
      _JIM = .Item("JIM")
      _JID = .Item("JID")
      _JRY = .Item("JRY")
      _JRM = .Item("JRM")
      _JRD = .Item("JRD")
      _SIMT = .Item("SIMT")
      _TMSP = .Item("TMSP")
      _TBL = .Item("TBL")
      _ARC = .Item("ARC")
      _MR = .Item("MR")
      _AD1 = .Item("AD1")
      _AD2 = .Item("AD2")
      _CY = .Item("CY")
      _SAT = .Item("SAT")
      _ZI5 = .Item("ZI5")
      _ZI4 = .Item("ZI4")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("JSTAT") = _JSTAT
      .Item("LIST#") = _LISTNo
      .Item("YEAR") = _YEAR
      .Item("TYPE") = _TYPE
      .Item("PAMT") = _PAMT
      .Item("IAMT") = _IAMT
      .Item("LAMT") = _LAMT
      .Item("TCAMT") = _TCAMT
      .Item("CORC") = _CORC
      .Item("DIST") = _DIST
      .Item("REFE") = _REFE
      .Item("COMM") = _COMM
      .Item("ADJCD") = _ADJCD
      .Item("JSEQNO") = _JSEQNO
      .Item("JBATCH") = _JBATCH
      .Item("JBTCHC") = _JBTCHC
      .Item("JBTCHT") = _JBTCHT
      .Item("JTCODE") = _JTCODE
      .Item("JUCODE") = _JUCODE
      .Item("NAME") = _NAME
      .Item("CASH") = _CASH
      .Item("CHECK") = _CHECK
      .Item("CREDIT") = _CREDIT
      .Item("ASOFD") = _ASOFD
      .Item("CPENCD") = _CPENCD
      .Item("CINTPD") = _CINTPD
      .Item("JIY") = _JIY
      .Item("JIM") = _JIM
      .Item("JID") = _JID
      .Item("JRY") = _JRY
      .Item("JRM") = _JRM
      .Item("JRD") = _JRD
      .Item("SIMT") = _SIMT
      .Item("TMSP") = _TMSP
      .Item("TBL") = _TBL
      .Item("ARC") = _ARC
      .Item("MR") = _MR
      .Item("AD1") = _AD1
      .Item("AD2") = _AD2
      .Item("CY") = _CY
      .Item("SAT") = _SAT
      .Item("ZI5") = _ZI5
      .Item("ZI4") = _ZI4
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
  Dim mJSTAT As String
  Public Property _JSTAT As String
    Get
      Return mJSTAT
    End Get
    Set(ByVal value As String)
      mJSTAT = value
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

  Dim mTCAMT As Decimal
  Public Property _TCAMT As Decimal
    Get
      Return mTCAMT
    End Get
    Set(ByVal value As Decimal)
      mTCAMT = value
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

  Dim mREFE As String
  Public Property _REFE As String
    Get
      Return mREFE
    End Get
    Set(ByVal value As String)
      mREFE = value
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

  Dim mJSEQNO As Integer
  Public Property _JSEQNO As Integer
    Get
      Return mJSEQNO
    End Get
    Set(ByVal value As Integer)
      mJSEQNO = value
    End Set
  End Property

  Dim mJBATCH As Integer
  Public Property _JBATCH As Integer
    Get
      Return mJBATCH
    End Get
    Set(ByVal value As Integer)
      mJBATCH = value
    End Set
  End Property

  Dim mJBTCHC As String
  Public Property _JBTCHC As String
    Get
      Return mJBTCHC
    End Get
    Set(ByVal value As String)
      mJBTCHC = value
    End Set
  End Property

  Dim mJBTCHT As String
  Public Property _JBTCHT As String
    Get
      Return mJBTCHT
    End Get
    Set(ByVal value As String)
      mJBTCHT = value
    End Set
  End Property

  Dim mJTCODE As String
  Public Property _JTCODE As String
    Get
      Return mJTCODE
    End Get
    Set(ByVal value As String)
      mJTCODE = value
    End Set
  End Property

  Dim mJUCODE As String
  Public Property _JUCODE As String
    Get
      Return mJUCODE
    End Get
    Set(ByVal value As String)
      mJUCODE = value
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

  Dim mASOFD As Integer
  Public Property _ASOFD As Integer
    Get
      Return mASOFD
    End Get
    Set(ByVal value As Integer)
      mASOFD = value
    End Set
  End Property

  Dim mCPENCD As String
  Public Property _CPENCD As String
    Get
      Return mCPENCD
    End Get
    Set(ByVal value As String)
      mCPENCD = value
    End Set
  End Property

  Dim mCINTPD As String
  Public Property _CINTPD As String
    Get
      Return mCINTPD
    End Get
    Set(ByVal value As String)
      mCINTPD = value
    End Set
  End Property

  Dim mJIY As Integer
  Public Property _JIY As Integer
    Get
      Return mJIY
    End Get
    Set(ByVal value As Integer)
      mJIY = value
    End Set
  End Property

  Dim mJIM As Integer
  Public Property _JIM As Integer
    Get
      Return mJIM
    End Get
    Set(ByVal value As Integer)
      mJIM = value
    End Set
  End Property

  Dim mJID As Integer
  Public Property _JID As Integer
    Get
      Return mJID
    End Get
    Set(ByVal value As Integer)
      mJID = value
    End Set
  End Property

  Dim mJRY As Integer
  Public Property _JRY As Integer
    Get
      Return mJRY
    End Get
    Set(ByVal value As Integer)
      mJRY = value
    End Set
  End Property

  Dim mJRM As Integer
  Public Property _JRM As Integer
    Get
      Return mJRM
    End Get
    Set(ByVal value As Integer)
      mJRM = value
    End Set
  End Property

  Dim mJRD As Integer
  Public Property _JRD As Integer
    Get
      Return mJRD
    End Get
    Set(ByVal value As Integer)
      mJRD = value
    End Set
  End Property

  Dim mSIMT As Decimal
  Public Property _SIMT As Decimal
    Get
      Return mSIMT
    End Get
    Set(ByVal value As Decimal)
      mSIMT = value
    End Set
  End Property

  Dim mTMSP As Integer
  Public Property _TMSP As Integer
    Get
      Return mTMSP
    End Get
    Set(ByVal value As Integer)
      mTMSP = value
    End Set
  End Property

  Dim mTBL As Decimal
  Public Property _TBL As Decimal
    Get
      Return mTBL
    End Get
    Set(ByVal value As Decimal)
      mTBL = value
    End Set
  End Property
  Dim mARC As Decimal
  Public Property _ARC As Decimal
    Get
      Return mARC
    End Get
    Set(ByVal value As Decimal)
      mARC = value
    End Set
  End Property

  Dim mMR As String
  Public Property _MR As String
    Get
      Return mMR
    End Get
    Set(ByVal value As String)
      mMR = value
    End Set
  End Property

  Dim mAD1 As String
  Public Property _AD1 As String
    Get
      Return mAD1
    End Get
    Set(ByVal value As String)
      mAD1 = value
    End Set
  End Property

  Dim mAD2 As String
  Public Property _AD2 As String
    Get
      Return mAD2
    End Get
    Set(ByVal value As String)
      mAD2 = value
    End Set
  End Property

  Dim mCY As String
  Public Property _CY As String
    Get
      Return mCY
    End Get
    Set(ByVal value As String)
      mCY = value
    End Set
  End Property

  Dim mSAT As String
  Public Property _SAT As String
    Get
      Return mSAT
    End Get
    Set(ByVal value As String)
      mSAT = value
    End Set
  End Property

  Dim mZI5 As Integer
  Public Property _ZI5 As Integer
    Get
      Return mZI5
    End Get
    Set(ByVal value As Integer)
      mZI5 = value
    End Set
  End Property

  Dim mZI4 As Integer
  Public Property _ZI4 As Integer
    Get
      Return mZI4
    End Get
    Set(ByVal value As Integer)
      mZI4 = value
    End Set
  End Property
#End Region
End Class

