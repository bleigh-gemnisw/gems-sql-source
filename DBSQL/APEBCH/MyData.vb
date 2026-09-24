Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "APEBCH"
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
  StrSQL = "Select * from " & cFileName & " where bchno=" & WrkBchno & " order by seqno desc"
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
      NextKey = ds.Tables(0).Rows(0).Item("seqno") + 1
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
Public Sub GetOneRecordP(ByVal WrkBchno As Integer, ByVal WrkSeqno As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where bchno=" & WrkBchno & " and seqno=" & WrkSeqno
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
      _POLIQ = .Item("POLIQ")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("BCHNO") = _BCHNO
      .Item("SEQNO") = _SEQNO
      .Item("VNDNR") = _VNDNR
      .Item("VENNM") = _VENNM
      .Item("INVNO") = _INVNO
      .Item("AMTGR") = _AMTGR
      .Item("AMTDS") = _AMTDS
      .Item("AMTSH") = _AMTSH
      .Item("AMTNT") = _AMTNT
      .Item("DSCTX") = _DSCTX
      .Item("PONBR") = _PONBR
      .Item("F1099") = _F1099
      .Item("PPCKN") = _PPCKN
      .Item("PPAMT") = _PPAMT
      .Item("LEOPN") = _LEOPN
      .Item("BNKCD") = _BNKCD
      .Item("CSHYN") = _CSHYN
      .Item("FSCYR") = _FSCYR
      .Item("HINV") = _HINV
      .Item("INVD8") = _INVD8
      .Item("DUED8") = _DUED8
      .Item("PPDT8") = _PPDT8
      .Item("PRJ") = _PRJ
      .Item("APPST") = _APPST
      .Item("POLIQ") = _POLIQ
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
  Dim mPOLIQ As String
  Public Property _POLIQ As String
    Get
      Return mPOLIQ
    End Get
    Set(ByVal value As String)
      mPOLIQ = value
    End Set
  End Property
#End Region
End Class

