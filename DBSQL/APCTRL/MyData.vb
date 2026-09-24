Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "APCTRL"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub GetOneRecordP(ByVal RecNum As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName
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
      _TNBR = .Item("TNBR")
      _FEDID = .Item("FEDID")
      _STEID = .Item("STEID")
      _FNAME = .Item("FNAME")
      _FADD1 = .Item("FADD1")
      _FADD2 = .Item("FADD2")
      _FCITY = .Item("FCITY")
      _FSTATE = .Item("FSTATE")
      _FZIP = .Item("FZIP")
      _YLIM = .Item("YLIM")
      _CPST = .Item("CPST")
      _FILL = .Item("FILL")
      _TCC = .Item("TCC")
      _LSTFIL = .Item("LSTFIL")
      _TSTIND = .Item("TSTIND")
      _GLDIST = .Item("GLDIST")
      _VNDNX = .Item("VNDNX")
      _CNAME = .Item("CNAME")
      _CTEL = .Item("CTEL")
      _PTEL = .Item("PTEL")
      _PCNAM = .Item("PCNAM")
    End With
  End Sub

  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("TNBR") = _TNBR
      .Item("FEDID") = _FEDID
      .Item("STEID") = _STEID
      .Item("FNAME") = _FNAME
      .Item("FADD1") = _FADD1
      .Item("FADD2") = _FADD2
      .Item("FCITY") = _FCITY
      .Item("FSTATE") = _FSTATE
      .Item("FZIP") = _FZIP
      .Item("YLIM") = _YLIM
      .Item("CPST") = _CPST
      .Item("FILL") = _FILL
      .Item("TCC") = _TCC
      .Item("LSTFIL") = _LSTFIL
      .Item("TSTIND") = _TSTIND
      .Item("GLDIST") = _GLDIST
      .Item("VNDNX") = _VNDNX
      .Item("CNAME") = _CNAME
      .Item("CTEL") = _CTEL
      .Item("PTEL") = _PTEL
      .Item("PCNAM") = _PCNAM
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
  Dim mTNBR As Integer
  Public Property _TNBR As Integer
    Get
      Return mTNBR
    End Get
    Set(ByVal value As Integer)
      mTNBR = value
    End Set
  End Property
  Dim mFEDID As Long
  Public Property _FEDID As Long
    Get
      Return mFEDID
    End Get
    Set(ByVal value As Long)
      mFEDID = value
    End Set
  End Property
  Dim mSTEID As Long
  Public Property _STEID As Long
    Get
      Return mSTEID
    End Get
    Set(ByVal value As Long)
      mSTEID = value
    End Set
  End Property
  Dim mFNAME As String
  Public Property _FNAME As String
    Get
      Return mFNAME
    End Get
    Set(ByVal value As String)
      mFNAME = value
    End Set
  End Property
  Dim mFADD1 As String
  Public Property _FADD1 As String
    Get
      Return mFADD1
    End Get
    Set(ByVal value As String)
      mFADD1 = value
    End Set
  End Property
  Dim mFADD2 As String
  Public Property _FADD2 As String
    Get
      Return mFADD2
    End Get
    Set(ByVal value As String)
      mFADD2 = value
    End Set
  End Property
  Dim mFCITY As String
  Public Property _FCITY As String
    Get
      Return mFCITY
    End Get
    Set(ByVal value As String)
      mFCITY = value
    End Set
  End Property
  Dim mFSTATE As String
  Public Property _FSTATE As String
    Get
      Return mFSTATE
    End Get
    Set(ByVal value As String)
      mFSTATE = value
    End Set
  End Property
  Dim mFZIP As Long
  Public Property _FZIP As Long
    Get
      Return mFZIP
    End Get
    Set(ByVal value As Long)
      mFZIP = value
    End Set
  End Property
  Dim mYLIM As Decimal
  Public Property _YLIM As Decimal
    Get
      Return mYLIM
    End Get
    Set(ByVal value As Decimal)
      mYLIM = value
    End Set
  End Property
  Dim mCPST As String
  Public Property _CPST As String
    Get
      Return mCPST
    End Get
    Set(ByVal value As String)
      mCPST = value
    End Set
  End Property
  Dim mFILL As String
  Public Property _FILL As String
    Get
      Return mFILL
    End Get
    Set(ByVal value As String)
      mFILL = value
    End Set
  End Property
  Dim mTCC As String
  Public Property _TCC As String
    Get
      Return mTCC
    End Get
    Set(ByVal value As String)
      mTCC = value
    End Set
  End Property
  Dim mLSTFIL As String
  Public Property _LSTFIL As String
    Get
      Return mLSTFIL
    End Get
    Set(ByVal value As String)
      mLSTFIL = value
    End Set
  End Property
  Dim mTSTIND As String
  Public Property _TSTIND As String
    Get
      Return mTSTIND
    End Get
    Set(ByVal value As String)
      mTSTIND = value
    End Set
  End Property
  Dim mGLDIST As String
  Public Property _GLDIST As String
    Get
      Return mGLDIST
    End Get
    Set(ByVal value As String)
      mGLDIST = value
    End Set
  End Property
  Dim mVNDNX As String
  Public Property _VNDNX As String
    Get
      Return mVNDNX
    End Get
    Set(ByVal value As String)
      mVNDNX = value
    End Set
  End Property
  Dim mCNAME As String
  Public Property _CNAME As String
    Get
      Return mCNAME
    End Get
    Set(ByVal value As String)
      mCNAME = value
    End Set
  End Property
  Dim mCTEL As String
  Public Property _CTEL As String
    Get
      Return mCTEL
    End Get
    Set(ByVal value As String)
      mCTEL = value
    End Set
  End Property
  Dim mPTEL As String
  Public Property _PTEL As String
    Get
      Return mPTEL
    End Get
    Set(ByVal value As String)
      mPTEL = value
    End Set
  End Property
  Dim mPCNAM As String
  Public Property _PCNAM As String
    Get
      Return mPCNAM
    End Get
    Set(ByVal value As String)
      mPCNAM = value
    End Set
  End Property
#End Region
End Class

