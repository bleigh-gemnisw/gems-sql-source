Imports System.Data
Imports System.Data.SqlClient
Public Class TXVEH
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Dim Conn As SqlConnection
  Const MyFileName As String = "TXVEH"
#Region "Constructors"

  Public Sub New(ByVal WrkConn As SqlConnection)
    Conn = WrkConn
  End Sub
#End Region

#Region "Methods: File Access Routines"
  Public Sub GetOneRecordP(ByVal Wrkvehid As Integer)
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & MyFileName & " where vehid = " & Wrkvehid
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
      _REGID = .Item("REGID")
      _VEHID = .Item("VEHID")
      _PCUST = .Item("PCUST")
      _SCUST = .Item("SCUST")
      _VMAKE = .Item("VMAKE")
      _YEAR = .Item("YEAR")
      _VMODEL = .Item("VMODEL")
      _BODY = .Item("BODY")
      _CLASS = .Item("CLASS")
      _CLASSD = .Item("CLASSD")
      _REGNO = .Item("REGNO")
      _VINNO = .Item("VINNO")
      _CYLAX = .Item("CYLAX")
      _VPCLR = .Item("VPCLR")
      _VSCLR = .Item("VSCLR")
      _SEAT = .Item("SEAT")
      _LWT = .Item("LWT")
      _GWT = .Item("GWT")
      _ORIG = .Item("ORIG")
      _TRVAL = .Item("TRVAL")
      _LNVAL = .Item("LNVAL")
      _MSRP = .Item("MSRP")
      _NADA = .Item("NADA")
      _STRDT = .Item("STRDT")
      _ENDDT = .Item("ENDDT")
      _DADD1 = .Item("DADD1")
      _DADD2 = .Item("DADD2")
      _DCITY = .Item("DCITY")
      _DSTATE = .Item("DSTATE")
      _DZIPA = .Item("DZIPA")
      _LEASE = .Item("LEASE")
      _LCUST = .Item("LCUST")
      _LNAME = .Item("LNAME")
      _LBUS = .Item("LBUS")
      _LADD1 = .Item("LADD1")
      _LADD2 = .Item("LADD2")
      _LCITY = .Item("LCITY")
      _LSTATE = .Item("LSTATE")
      _LZIPA = .Item("LZIPA")
      _RGLATE = .Item("RGLATE")
      _CHDATE = .Item("CHDATE")

    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("REGID") = _REGID
      .Item("VEHID") = _VEHID
      .Item("PCUST") = _PCUST
      .Item("SCUST") = _SCUST
      .Item("VMAKE") = _VMAKE
      .Item("YEAR") = _YEAR
      .Item("VMODEL") = _VMODEL
      .Item("BODY") = _BODY
      .Item("CLASS") = _CLASS
      .Item("CLASSD") = _CLASSD
      .Item("REGNO") = _REGNO
      .Item("VINNO") = _VINNO
      .Item("CYLAX") = _CYLAX
      .Item("VPCLR") = _VPCLR
      .Item("VSCLR") = _VSCLR
      .Item("SEAT") = _SEAT
      .Item("LWT") = _LWT
      .Item("GWT") = _GWT
      .Item("ORIG") = _ORIG
      .Item("TRVAL") = _TRVAL
      .Item("LNVAL") = _LNVAL
      .Item("MSRP") = _MSRP
      .Item("NADA") = _NADA
      .Item("STRDT") = _STRDT
      .Item("ENDDT") = _ENDDT
      .Item("DADD1") = _DADD1
      .Item("DADD2") = _DADD2
      .Item("DCITY") = _DCITY
      .Item("DSTATE") = _DSTATE
      .Item("DZIPA") = _DZIPA
      .Item("LEASE") = _LEASE
      .Item("LCUST") = _LCUST
      .Item("LNAME") = _LNAME
      .Item("LBUS") = _LBUS
      .Item("LADD1") = _LADD1
      .Item("LADD2") = _LADD2
      .Item("LCITY") = _LCITY
      .Item("LSTATE") = _LSTATE
      .Item("LZIPA") = _LZIPA
      .Item("RGLATE") = _RGLATE
      .Item("CHDATE") = _CHDATE

    End With
  End Sub
#End Region


#Region "Properties: Fields"

  Dim mREGID As Long
  Public Property _REGID As Long
    Get
      Return mREGID
    End Get
    Set(ByVal value As Long)
      mREGID = value
    End Set
  End Property

  Dim mVEHID As Long
  Public Property _VEHID As Long
    Get
      Return mVEHID
    End Get
    Set(ByVal value As Long)
      mVEHID = value
    End Set
  End Property

  Dim mPCUST As Long
  Public Property _PCUST As Long
    Get
      Return mPCUST
    End Get
    Set(ByVal value As Long)
      mPCUST = value
    End Set
  End Property

  Dim mSCUST As Long
  Public Property _SCUST As Long
    Get
      Return mSCUST
    End Get
    Set(ByVal value As Long)
      mSCUST = value
    End Set
  End Property

  Dim mVMAKE As String
  Public Property _VMAKE As String
    Get
      Return mVMAKE
    End Get
    Set(ByVal value As String)
      mVMAKE = value
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

  Dim mVMODEL As String
  Public Property _VMODEL As String
    Get
      Return mVMODEL
    End Get
    Set(ByVal value As String)
      mVMODEL = value
    End Set
  End Property

  Dim mBODY As String
  Public Property _BODY As String
    Get
      Return mBODY
    End Get
    Set(ByVal value As String)
      mBODY = value
    End Set
  End Property

  Dim mCLASS As Integer
  Public Property _CLASS As Integer
    Get
      Return mCLASS
    End Get
    Set(ByVal value As Integer)
      mCLASS = value
    End Set
  End Property

  Dim mCLASSD As String
  Public Property _CLASSD As String
    Get
      Return mCLASSD
    End Get
    Set(ByVal value As String)
      mCLASSD = value
    End Set
  End Property

  Dim mREGNO As String
  Public Property _REGNO As String
    Get
      Return mREGNO
    End Get
    Set(ByVal value As String)
      mREGNO = value
    End Set
  End Property

  Dim mVINNO As String
  Public Property _VINNO As String
    Get
      Return mVINNO
    End Get
    Set(ByVal value As String)
      mVINNO = value
    End Set
  End Property

  Dim mCYLAX As Integer
  Public Property _CYLAX As Integer
    Get
      Return mCYLAX
    End Get
    Set(ByVal value As Integer)
      mCYLAX = value
    End Set
  End Property

  Dim mVPCLR As String
  Public Property _VPCLR As String
    Get
      Return mVPCLR
    End Get
    Set(ByVal value As String)
      mVPCLR = value
    End Set
  End Property

  Dim mVSCLR As String
  Public Property _VSCLR As String
    Get
      Return mVSCLR
    End Get
    Set(ByVal value As String)
      mVSCLR = value
    End Set
  End Property

  Dim mSEAT As Integer
  Public Property _SEAT As Integer
    Get
      Return mSEAT
    End Get
    Set(ByVal value As Integer)
      mSEAT = value
    End Set
  End Property

  Dim mLWT As Integer
  Public Property _LWT As Integer
    Get
      Return mLWT
    End Get
    Set(ByVal value As Integer)
      mLWT = value
    End Set
  End Property

  Dim mGWT As Integer
  Public Property _GWT As Integer
    Get
      Return mGWT
    End Get
    Set(ByVal value As Integer)
      mGWT = value
    End Set
  End Property

  Dim mORIG As Integer
  Public Property _ORIG As Integer
    Get
      Return mORIG
    End Get
    Set(ByVal value As Integer)
      mORIG = value
    End Set
  End Property

  Dim mTRVAL As Integer
  Public Property _TRVAL As Integer
    Get
      Return mTRVAL
    End Get
    Set(ByVal value As Integer)
      mTRVAL = value
    End Set
  End Property

  Dim mLNVAL As Integer
  Public Property _LNVAL As Integer
    Get
      Return mLNVAL
    End Get
    Set(ByVal value As Integer)
      mLNVAL = value
    End Set
  End Property

  Dim mMSRP As Integer
  Public Property _MSRP As Integer
    Get
      Return mMSRP
    End Get
    Set(ByVal value As Integer)
      mMSRP = value
    End Set
  End Property

  Dim mNADA As String
  Public Property _NADA As String
    Get
      Return mNADA
    End Get
    Set(ByVal value As String)
      mNADA = value
    End Set
  End Property

  Dim mSTRDT As Integer
  Public Property _STRDT As Integer
    Get
      Return mSTRDT
    End Get
    Set(ByVal value As Integer)
      mSTRDT = value
    End Set
  End Property

  Dim mENDDT As Integer
  Public Property _ENDDT As Integer
    Get
      Return mENDDT
    End Get
    Set(ByVal value As Integer)
      mENDDT = value
    End Set
  End Property

  Dim mDADD1 As String
  Public Property _DADD1 As String
    Get
      Return mDADD1
    End Get
    Set(ByVal value As String)
      mDADD1 = value
    End Set
  End Property

  Dim mDADD2 As String
  Public Property _DADD2 As String
    Get
      Return mDADD2
    End Get
    Set(ByVal value As String)
      mDADD2 = value
    End Set
  End Property

  Dim mDCITY As String
  Public Property _DCITY As String
    Get
      Return mDCITY
    End Get
    Set(ByVal value As String)
      mDCITY = value
    End Set
  End Property

  Dim mDSTATE As String
  Public Property _DSTATE As String
    Get
      Return mDSTATE
    End Get
    Set(ByVal value As String)
      mDSTATE = value
    End Set
  End Property

  Dim mDZIPA As String
  Public Property _DZIPA As String
    Get
      Return mDZIPA
    End Get
    Set(ByVal value As String)
      mDZIPA = value
    End Set
  End Property

  Dim mLEASE As String
  Public Property _LEASE As String
    Get
      Return mLEASE
    End Get
    Set(ByVal value As String)
      mLEASE = value
    End Set
  End Property

  Dim mLCUST As Long
  Public Property _LCUST As Long
    Get
      Return mLCUST
    End Get
    Set(ByVal value As Long)
      mLCUST = value
    End Set
  End Property

  Dim mLNAME As String
  Public Property _LNAME As String
    Get
      Return mLNAME
    End Get
    Set(ByVal value As String)
      mLNAME = value
    End Set
  End Property

  Dim mLBUS As String
  Public Property _LBUS As String
    Get
      Return mLBUS
    End Get
    Set(ByVal value As String)
      mLBUS = value
    End Set
  End Property

  Dim mLADD1 As String
  Public Property _LADD1 As String
    Get
      Return mLADD1
    End Get
    Set(ByVal value As String)
      mLADD1 = value
    End Set
  End Property

  Dim mLADD2 As String
  Public Property _LADD2 As String
    Get
      Return mLADD2
    End Get
    Set(ByVal value As String)
      mLADD2 = value
    End Set
  End Property

  Dim mLCITY As String
  Public Property _LCITY As String
    Get
      Return mLCITY
    End Get
    Set(ByVal value As String)
      mLCITY = value
    End Set
  End Property

  Dim mLSTATE As String
  Public Property _LSTATE As String
    Get
      Return mLSTATE
    End Get
    Set(ByVal value As String)
      mLSTATE = value
    End Set
  End Property

  Dim mLZIPA As String
  Public Property _LZIPA As String
    Get
      Return mLZIPA
    End Get
    Set(ByVal value As String)
      mLZIPA = value
    End Set
  End Property

  Dim mRGLATE As String
  Public Property _RGLATE As String
    Get
      Return mRGLATE
    End Get
    Set(ByVal value As String)
      mRGLATE = value
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
