Imports System.Data
Imports System.Data.SqlClient
Public Class TXPPRP
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Dim Conn As SqlConnection
  Dim cFileName As String = "TXPPRP"
#Region "Constructors"

  Public Sub New(ByVal WrkConn As SqlConnection)
    Conn = WrkConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub GetOneRecordP(ByVal ListNo As Integer)
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where list#=" & ListNo
    Try
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
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
  End Sub
#End Region

#Region "Properties: Get/Put"
  Public Sub GetFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      _CAT = .Item("CAT")
      _LISTNO = .Item("LIST#")
      _NAME = .Item("NAME")
      _SNAME = .Item("SNAME")
      _ADD1 = .Item("ADD1")
      _ADD2 = .Item("ADD2")
      _CITY = .Item("CITY")
      _STATE = .Item("STATE")
      _ZIP5 = .Item("ZIP5")
      _ZIP4 = .Item("ZIP4")
      _LOCNO = .Item("LOC#")
      _LOC = .Item("LOC")
      _DIST = .Item("DIST")
      _GROSS = .Item("GROSS")
      _NET = .Item("NET")
      _ASS1 = .Item("ASS1")
      _ASS2 = .Item("ASS2")
      _ASS3 = .Item("ASS3")
      _ASS4 = .Item("ASS4")
      _ASS5 = .Item("ASS5")
      _ASS6 = .Item("ASS6")
      _ASS7 = .Item("ASS7")
      _ASS8 = .Item("ASS8")
      _ASS9 = .Item("ASS9")
      _ASS10 = .Item("ASS10")
      _CODE1 = .Item("CODE1")
      _CODE2 = .Item("CODE2")
      _CODE3 = .Item("CODE3")
      _CODE4 = .Item("CODE4")
      _CODE5 = .Item("CODE5")
      _CODE6 = .Item("CODE6")
      _CODE7 = .Item("CODE7")
      _CODE8 = .Item("CODE8")
      _CODE9 = .Item("CODE9")
      _CODEA = .Item("CODEA")
      _UNIT1 = .Item("UNIT1")
      _UNIT2 = .Item("UNIT2")
      _UNIT3 = .Item("UNIT3")
      _UNIT4 = .Item("UNIT4")
      _UNIT5 = .Item("UNIT5")
      _UNIT6 = .Item("UNIT6")
      _UNIT7 = .Item("UNIT7")
      _UNIT8 = .Item("UNIT8")
      _UNIT9 = .Item("UNIT9")
      _UNITA = .Item("UNITA")
      _EXCD1 = .Item("EXCD1")
      _EXCD2 = .Item("EXCD2")
      _EXCD3 = .Item("EXCD3")
      _EXCD4 = .Item("EXCD4")
      _EXCD5 = .Item("EXCD5")
      _EXAM1 = .Item("EXAM1")
      _EXAM2 = .Item("EXAM2")
      _EXAM3 = .Item("EXAM3")
      _EXAM4 = .Item("EXAM4")
      _EXAM5 = .Item("EXAM5")
      _CCNO = .Item("CCNO")
      _CCGRS = .Item("CCGRS")
      _CCEX = .Item("CCEX")
      _CCRS = .Item("CCRS")
      _CDATE = .Item("CDATE")
      _CASS1 = .Item("CASS1")
      _CASS2 = .Item("CASS2")
      _CASS3 = .Item("CASS3")
      _CASS4 = .Item("CASS4")
      _CASS5 = .Item("CASS5")
      _CASS6 = .Item("CASS6")
      _CASS7 = .Item("CASS7")
      _CASS8 = .Item("CASS8")
      _CASS9 = .Item("CASS9")
      _CASSA = .Item("CASSA")
      _CCCD1 = .Item("CCCD1")
      _CCCD2 = .Item("CCCD2")
      _CCCD3 = .Item("CCCD3")
      _CCCD4 = .Item("CCCD4")
      _CCCD5 = .Item("CCCD5")
      _CEXA1 = .Item("CEXA1")
      _CEXA2 = .Item("CEXA2")
      _CEXA3 = .Item("CEXA3")
      _CEXA4 = .Item("CEXA4")
      _CEXA5 = .Item("CEXA5")
      _BTR = .Item("BTR")
      _BTC = .Item("BTC")
      _SSNO = .Item("SS#")
      _BUSTY = .Item("BUSTY")
      _SQFT = .Item("SQFT")
      _BUS = .Item("BUS")
      _RDATE = .Item("RDATE")
      _PRF = .Item("PRF")
      _CHDATE = .Item("CHDATE")
      _CHTIME = .Item("CHTIME")
      _LETT = .Item("LETT")
      _TYPE = .Item("TYPE")
      _DNBTR = .Item("DNBTR")
      _DTBTR = .Item("DTBTR")
      _ADYR = .Item("ADYR")
      _PDST = .Item("PDST")
      _OID = .Item("OID")
      _SS2 = .Item("SS2")
      _TIN = .Item("TIN")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("CAT") = _CAT
      .Item("LIST#") = _LISTNO
      .Item("NAME") = _NAME
      .Item("SNAME") = _SNAME
      .Item("ADD1") = _ADD1
      .Item("ADD2") = _ADD2
      .Item("CITY") = _CITY
      .Item("STATE") = _STATE
      .Item("ZIP5") = _ZIP5
      .Item("ZIP4") = _ZIP4
      .Item("LOC#") = _LOCNO
      .Item("LOC") = _LOC
      .Item("DIST") = _DIST
      .Item("GROSS") = _GROSS
      .Item("NET") = _NET
      .Item("ASS1") = _ASS1
      .Item("ASS2") = _ASS2
      .Item("ASS3") = _ASS3
      .Item("ASS4") = _ASS4
      .Item("ASS5") = _ASS5
      .Item("ASS6") = _ASS6
      .Item("ASS7") = _ASS7
      .Item("ASS8") = _ASS8
      .Item("ASS9") = _ASS9
      .Item("ASS10") = _ASS10
      .Item("CODE1") = _CODE1
      .Item("CODE2") = _CODE2
      .Item("CODE3") = _CODE3
      .Item("CODE4") = _CODE4
      .Item("CODE5") = _CODE5
      .Item("CODE6") = _CODE6
      .Item("CODE7") = _CODE7
      .Item("CODE8") = _CODE8
      .Item("CODE9") = _CODE9
      .Item("CODEA") = _CODEA
      .Item("UNIT1") = _UNIT1
      .Item("UNIT2") = _UNIT2
      .Item("UNIT3") = _UNIT3
      .Item("UNIT4") = _UNIT4
      .Item("UNIT5") = _UNIT5
      .Item("UNIT6") = _UNIT6
      .Item("UNIT7") = _UNIT7
      .Item("UNIT8") = _UNIT8
      .Item("UNIT9") = _UNIT9
      .Item("UNITA") = _UNITA
      .Item("EXCD1") = _EXCD1
      .Item("EXCD2") = _EXCD2
      .Item("EXCD3") = _EXCD3
      .Item("EXCD4") = _EXCD4
      .Item("EXCD5") = _EXCD5
      .Item("EXAM1") = _EXAM1
      .Item("EXAM2") = _EXAM2
      .Item("EXAM3") = _EXAM3
      .Item("EXAM4") = _EXAM4
      .Item("EXAM5") = _EXAM5
      .Item("CCNO") = _CCNO
      .Item("CCGRS") = _CCGRS
      .Item("CCEX") = _CCEX
      .Item("CCRS") = _CCRS
      .Item("CDATE") = _CDATE
      .Item("CASS1") = _CASS1
      .Item("CASS2") = _CASS2
      .Item("CASS3") = _CASS3
      .Item("CASS4") = _CASS4
      .Item("CASS5") = _CASS5
      .Item("CASS6") = _CASS6
      .Item("CASS7") = _CASS7
      .Item("CASS8") = _CASS8
      .Item("CASS9") = _CASS9
      .Item("CASSA") = _CASSA
      .Item("CCCD1") = _CCCD1
      .Item("CCCD2") = _CCCD2
      .Item("CCCD3") = _CCCD3
      .Item("CCCD4") = _CCCD4
      .Item("CCCD5") = _CCCD5
      .Item("CEXA1") = _CEXA1
      .Item("CEXA2") = _CEXA2
      .Item("CEXA3") = _CEXA3
      .Item("CEXA4") = _CEXA4
      .Item("CEXA5") = _CEXA5
      .Item("BTR") = _BTR
      .Item("BTC") = _BTC
      .Item("SS#") = _SSNO
      .Item("BUSTY") = _BUSTY
      .Item("SQFT") = _SQFT
      .Item("BUS") = _BUS
      .Item("RDATE") = _RDATE
      .Item("PRF") = _PRF
      .Item("CHDATE") = _CHDATE
      .Item("CHTIME") = _CHTIME
      .Item("LETT") = _LETT
      .Item("TYPE") = _TYPE
      .Item("DNBTR") = _DNBTR
      .Item("DTBTR") = _DTBTR
      .Item("ADYR") = _ADYR
      .Item("PDST") = _PDST
      .Item("OID") = _OID
      .Item("SS2") = _SS2
      .Item("TIN") = _TIN
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
  Dim mCAT As String
  Public Property _CAT As String
    Get
      Return mCAT
    End Get
    Set(ByVal value As String)
      mCAT = value
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

  Dim mNAME As String
  Public Property _NAME As String
    Get
      Return mNAME
    End Get
    Set(ByVal value As String)
      mNAME = value
    End Set
  End Property

  Dim mSNAME As String
  Public Property _SNAME As String
    Get
      Return mSNAME
    End Get
    Set(ByVal value As String)
      mSNAME = value
    End Set
  End Property

  Dim mADD1 As String
  Public Property _ADD1 As String
    Get
      Return mADD1
    End Get
    Set(ByVal value As String)
      mADD1 = value
    End Set
  End Property

  Dim mADD2 As String
  Public Property _ADD2 As String
    Get
      Return mADD2
    End Get
    Set(ByVal value As String)
      mADD2 = value
    End Set
  End Property

  Dim mCITY As String
  Public Property _CITY As String
    Get
      Return mCITY
    End Get
    Set(ByVal value As String)
      mCITY = value
    End Set
  End Property

  Dim mSTATE As String
  Public Property _STATE As String
    Get
      Return mSTATE
    End Get
    Set(ByVal value As String)
      mSTATE = value
    End Set
  End Property

  Dim mZIP5 As Integer
  Public Property _ZIP5 As Integer
    Get
      Return mZIP5
    End Get
    Set(ByVal value As Integer)
      mZIP5 = value
    End Set
  End Property

  Dim mZIP4 As Integer
  Public Property _ZIP4 As Integer
    Get
      Return mZIP4
    End Get
    Set(ByVal value As Integer)
      mZIP4 = value
    End Set
  End Property

  Dim mLOCNO As String
  Public Property _LOCNO As String
    Get
      Return mLOCNO
    End Get
    Set(ByVal value As String)
      mLOCNO = value
    End Set
  End Property

  Dim mLOC As String
  Public Property _LOC As String
    Get
      Return mLOC
    End Get
    Set(ByVal value As String)
      mLOC = value
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

  Dim mGROSS As Long
  Public Property _GROSS As Long
    Get
      Return mGROSS
    End Get
    Set(ByVal value As Long)
      mGROSS = value
    End Set
  End Property

  Dim mNET As Long
  Public Property _NET As Long
    Get
      Return mNET
    End Get
    Set(ByVal value As Long)
      mNET = value
    End Set
  End Property

  Dim mASS1 As Long
  Public Property _ASS1 As Long
    Get
      Return mASS1
    End Get
    Set(ByVal value As Long)
      mASS1 = value
    End Set
  End Property

  Dim mASS2 As Long
  Public Property _ASS2 As Long
    Get
      Return mASS2
    End Get
    Set(ByVal value As Long)
      mASS2 = value
    End Set
  End Property

  Dim mASS3 As Long
  Public Property _ASS3 As Long
    Get
      Return mASS3
    End Get
    Set(ByVal value As Long)
      mASS3 = value
    End Set
  End Property

  Dim mASS4 As Long
  Public Property _ASS4 As Long
    Get
      Return mASS4
    End Get
    Set(ByVal value As Long)
      mASS4 = value
    End Set
  End Property

  Dim mASS5 As Long
  Public Property _ASS5 As Long
    Get
      Return mASS5
    End Get
    Set(ByVal value As Long)
      mASS5 = value
    End Set
  End Property

  Dim mASS6 As Long
  Public Property _ASS6 As Long
    Get
      Return mASS6
    End Get
    Set(ByVal value As Long)
      mASS6 = value
    End Set
  End Property

  Dim mASS7 As Long
  Public Property _ASS7 As Long
    Get
      Return mASS7
    End Get
    Set(ByVal value As Long)
      mASS7 = value
    End Set
  End Property

  Dim mASS8 As Long
  Public Property _ASS8 As Long
    Get
      Return mASS8
    End Get
    Set(ByVal value As Long)
      mASS8 = value
    End Set
  End Property

  Dim mASS9 As Long
  Public Property _ASS9 As Long
    Get
      Return mASS9
    End Get
    Set(ByVal value As Long)
      mASS9 = value
    End Set
  End Property

  Dim mASS10 As Long
  Public Property _ASS10 As Long
    Get
      Return mASS10
    End Get
    Set(ByVal value As Long)
      mASS10 = value
    End Set
  End Property

  Dim mCODE1 As Integer
  Public Property _CODE1 As Integer
    Get
      Return mCODE1
    End Get
    Set(ByVal value As Integer)
      mCODE1 = value
    End Set
  End Property

  Dim mCODE2 As Integer
  Public Property _CODE2 As Integer
    Get
      Return mCODE2
    End Get
    Set(ByVal value As Integer)
      mCODE2 = value
    End Set
  End Property

  Dim mCODE3 As Integer
  Public Property _CODE3 As Integer
    Get
      Return mCODE3
    End Get
    Set(ByVal value As Integer)
      mCODE3 = value
    End Set
  End Property

  Dim mCODE4 As Integer
  Public Property _CODE4 As Integer
    Get
      Return mCODE4
    End Get
    Set(ByVal value As Integer)
      mCODE4 = value
    End Set
  End Property

  Dim mCODE5 As Integer
  Public Property _CODE5 As Integer
    Get
      Return mCODE5
    End Get
    Set(ByVal value As Integer)
      mCODE5 = value
    End Set
  End Property

  Dim mCODE6 As Integer
  Public Property _CODE6 As Integer
    Get
      Return mCODE6
    End Get
    Set(ByVal value As Integer)
      mCODE6 = value
    End Set
  End Property

  Dim mCODE7 As Integer
  Public Property _CODE7 As Integer
    Get
      Return mCODE7
    End Get
    Set(ByVal value As Integer)
      mCODE7 = value
    End Set
  End Property

  Dim mCODE8 As Integer
  Public Property _CODE8 As Integer
    Get
      Return mCODE8
    End Get
    Set(ByVal value As Integer)
      mCODE8 = value
    End Set
  End Property

  Dim mCODE9 As Integer
  Public Property _CODE9 As Integer
    Get
      Return mCODE9
    End Get
    Set(ByVal value As Integer)
      mCODE9 = value
    End Set
  End Property

  Dim mCODEA As Integer
  Public Property _CODEA As Integer
    Get
      Return mCODEA
    End Get
    Set(ByVal value As Integer)
      mCODEA = value
    End Set
  End Property

  Dim mUNIT1 As Integer
  Public Property _UNIT1 As Integer
    Get
      Return mUNIT1
    End Get
    Set(ByVal value As Integer)
      mUNIT1 = value
    End Set
  End Property

  Dim mUNIT2 As Integer
  Public Property _UNIT2 As Integer
    Get
      Return mUNIT2
    End Get
    Set(ByVal value As Integer)
      mUNIT2 = value
    End Set
  End Property

  Dim mUNIT3 As Integer
  Public Property _UNIT3 As Integer
    Get
      Return mUNIT3
    End Get
    Set(ByVal value As Integer)
      mUNIT3 = value
    End Set
  End Property

  Dim mUNIT4 As Integer
  Public Property _UNIT4 As Integer
    Get
      Return mUNIT4
    End Get
    Set(ByVal value As Integer)
      mUNIT4 = value
    End Set
  End Property

  Dim mUNIT5 As Integer
  Public Property _UNIT5 As Integer
    Get
      Return mUNIT5
    End Get
    Set(ByVal value As Integer)
      mUNIT5 = value
    End Set
  End Property

  Dim mUNIT6 As Integer
  Public Property _UNIT6 As Integer
    Get
      Return mUNIT6
    End Get
    Set(ByVal value As Integer)
      mUNIT6 = value
    End Set
  End Property

  Dim mUNIT7 As Integer
  Public Property _UNIT7 As Integer
    Get
      Return mUNIT7
    End Get
    Set(ByVal value As Integer)
      mUNIT7 = value
    End Set
  End Property

  Dim mUNIT8 As Integer
  Public Property _UNIT8 As Integer
    Get
      Return mUNIT8
    End Get
    Set(ByVal value As Integer)
      mUNIT8 = value
    End Set
  End Property

  Dim mUNIT9 As Integer
  Public Property _UNIT9 As Integer
    Get
      Return mUNIT9
    End Get
    Set(ByVal value As Integer)
      mUNIT9 = value
    End Set
  End Property

  Dim mUNITA As Integer
  Public Property _UNITA As Integer
    Get
      Return mUNITA
    End Get
    Set(ByVal value As Integer)
      mUNITA = value
    End Set
  End Property

  Dim mEXCD1 As String
  Public Property _EXCD1 As String
    Get
      Return mEXCD1
    End Get
    Set(ByVal value As String)
      mEXCD1 = value
    End Set
  End Property

  Dim mEXCD2 As String
  Public Property _EXCD2 As String
    Get
      Return mEXCD2
    End Get
    Set(ByVal value As String)
      mEXCD2 = value
    End Set
  End Property

  Dim mEXCD3 As String
  Public Property _EXCD3 As String
    Get
      Return mEXCD3
    End Get
    Set(ByVal value As String)
      mEXCD3 = value
    End Set
  End Property

  Dim mEXCD4 As String
  Public Property _EXCD4 As String
    Get
      Return mEXCD4
    End Get
    Set(ByVal value As String)
      mEXCD4 = value
    End Set
  End Property

  Dim mEXCD5 As String
  Public Property _EXCD5 As String
    Get
      Return mEXCD5
    End Get
    Set(ByVal value As String)
      mEXCD5 = value
    End Set
  End Property

  Dim mEXAM1 As Integer
  Public Property _EXAM1 As Integer
    Get
      Return mEXAM1
    End Get
    Set(ByVal value As Integer)
      mEXAM1 = value
    End Set
  End Property

  Dim mEXAM2 As Integer
  Public Property _EXAM2 As Integer
    Get
      Return mEXAM2
    End Get
    Set(ByVal value As Integer)
      mEXAM2 = value
    End Set
  End Property

  Dim mEXAM3 As Integer
  Public Property _EXAM3 As Integer
    Get
      Return mEXAM3
    End Get
    Set(ByVal value As Integer)
      mEXAM3 = value
    End Set
  End Property

  Dim mEXAM4 As Integer
  Public Property _EXAM4 As Integer
    Get
      Return mEXAM4
    End Get
    Set(ByVal value As Integer)
      mEXAM4 = value
    End Set
  End Property

  Dim mEXAM5 As Integer
  Public Property _EXAM5 As Integer
    Get
      Return mEXAM5
    End Get
    Set(ByVal value As Integer)
      mEXAM5 = value
    End Set
  End Property

  Dim mCCNO As Integer
  Public Property _CCNO As Integer
    Get
      Return mCCNO
    End Get
    Set(ByVal value As Integer)
      mCCNO = value
    End Set
  End Property

  Dim mCCGRS As Long
  Public Property _CCGRS As Long
    Get
      Return mCCGRS
    End Get
    Set(ByVal value As Long)
      mCCGRS = value
    End Set
  End Property

  Dim mCCEX As Long
  Public Property _CCEX As Long
    Get
      Return mCCEX
    End Get
    Set(ByVal value As Long)
      mCCEX = value
    End Set
  End Property

  Dim mCCRS As String
  Public Property _CCRS As String
    Get
      Return mCCRS
    End Get
    Set(ByVal value As String)
      mCCRS = value
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

  Dim mCASS1 As Long
  Public Property _CASS1 As Long
    Get
      Return mCASS1
    End Get
    Set(ByVal value As Long)
      mCASS1 = value
    End Set
  End Property

  Dim mCASS2 As Long
  Public Property _CASS2 As Long
    Get
      Return mCASS2
    End Get
    Set(ByVal value As Long)
      mCASS2 = value
    End Set
  End Property

  Dim mCASS3 As Long
  Public Property _CASS3 As Long
    Get
      Return mCASS3
    End Get
    Set(ByVal value As Long)
      mCASS3 = value
    End Set
  End Property

  Dim mCASS4 As Long
  Public Property _CASS4 As Long
    Get
      Return mCASS4
    End Get
    Set(ByVal value As Long)
      mCASS4 = value
    End Set
  End Property

  Dim mCASS5 As Long
  Public Property _CASS5 As Long
    Get
      Return mCASS5
    End Get
    Set(ByVal value As Long)
      mCASS5 = value
    End Set
  End Property

  Dim mCASS6 As Long
  Public Property _CASS6 As Long
    Get
      Return mCASS6
    End Get
    Set(ByVal value As Long)
      mCASS6 = value
    End Set
  End Property

  Dim mCASS7 As Long
  Public Property _CASS7 As Long
    Get
      Return mCASS7
    End Get
    Set(ByVal value As Long)
      mCASS7 = value
    End Set
  End Property

  Dim mCASS8 As Long
  Public Property _CASS8 As Long
    Get
      Return mCASS8
    End Get
    Set(ByVal value As Long)
      mCASS8 = value
    End Set
  End Property

  Dim mCASS9 As Long
  Public Property _CASS9 As Long
    Get
      Return mCASS9
    End Get
    Set(ByVal value As Long)
      mCASS9 = value
    End Set
  End Property

  Dim mCASSA As Long
  Public Property _CASSA As Long
    Get
      Return mCASSA
    End Get
    Set(ByVal value As Long)
      mCASSA = value
    End Set
  End Property

  Dim mCCCD1 As String
  Public Property _CCCD1 As String
    Get
      Return mCCCD1
    End Get
    Set(ByVal value As String)
      mCCCD1 = value
    End Set
  End Property

  Dim mCCCD2 As String
  Public Property _CCCD2 As String
    Get
      Return mCCCD2
    End Get
    Set(ByVal value As String)
      mCCCD2 = value
    End Set
  End Property

  Dim mCCCD3 As String
  Public Property _CCCD3 As String
    Get
      Return mCCCD3
    End Get
    Set(ByVal value As String)
      mCCCD3 = value
    End Set
  End Property

  Dim mCCCD4 As String
  Public Property _CCCD4 As String
    Get
      Return mCCCD4
    End Get
    Set(ByVal value As String)
      mCCCD4 = value
    End Set
  End Property

  Dim mCCCD5 As String
  Public Property _CCCD5 As String
    Get
      Return mCCCD5
    End Get
    Set(ByVal value As String)
      mCCCD5 = value
    End Set
  End Property

  Dim mCEXA1 As Integer
  Public Property _CEXA1 As Integer
    Get
      Return mCEXA1
    End Get
    Set(ByVal value As Integer)
      mCEXA1 = value
    End Set
  End Property

  Dim mCEXA2 As Integer
  Public Property _CEXA2 As Integer
    Get
      Return mCEXA2
    End Get
    Set(ByVal value As Integer)
      mCEXA2 = value
    End Set
  End Property

  Dim mCEXA3 As Integer
  Public Property _CEXA3 As Integer
    Get
      Return mCEXA3
    End Get
    Set(ByVal value As Integer)
      mCEXA3 = value
    End Set
  End Property

  Dim mCEXA4 As Integer
  Public Property _CEXA4 As Integer
    Get
      Return mCEXA4
    End Get
    Set(ByVal value As Integer)
      mCEXA4 = value
    End Set
  End Property

  Dim mCEXA5 As Integer
  Public Property _CEXA5 As Integer
    Get
      Return mCEXA5
    End Get
    Set(ByVal value As Integer)
      mCEXA5 = value
    End Set
  End Property

  Dim mBTR As Long
  Public Property _BTR As Long
    Get
      Return mBTR
    End Get
    Set(ByVal value As Long)
      mBTR = value
    End Set
  End Property

  Dim mBTC As String
  Public Property _BTC As String
    Get
      Return mBTC
    End Get
    Set(ByVal value As String)
      mBTC = value
    End Set
  End Property

  Dim mSSNO As Long
  Public Property _SSNO As Long
    Get
      Return mSSNO
    End Get
    Set(ByVal value As Long)
      mSSNO = value
    End Set
  End Property

  Dim mBUSTY As String
  Public Property _BUSTY As String
    Get
      Return mBUSTY
    End Get
    Set(ByVal value As String)
      mBUSTY = value
    End Set
  End Property

  Dim mSQFT As Decimal
  Public Property _SQFT As Decimal
    Get
      Return mSQFT
    End Get
    Set(ByVal value As Decimal)
      mSQFT = value
    End Set
  End Property

  Dim mBUS As String
  Public Property _BUS As String
    Get
      Return mBUS
    End Get
    Set(ByVal value As String)
      mBUS = value
    End Set
  End Property

  Dim mRDATE As String
  Public Property _RDATE As String
    Get
      Return mRDATE
    End Get
    Set(ByVal value As String)
      mRDATE = value
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

  Dim mLETT As String
  Public Property _LETT As String
    Get
      Return mLETT
    End Get
    Set(ByVal value As String)
      mLETT = value
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

  Dim mDNBTR As String
  Public Property _DNBTR As String
    Get
      Return mDNBTR
    End Get
    Set(ByVal value As String)
      mDNBTR = value
    End Set
  End Property

  Dim mDTBTR As Integer
  Public Property _DTBTR As Integer
    Get
      Return mDTBTR
    End Get
    Set(ByVal value As Integer)
      mDTBTR = value
    End Set
  End Property

  Dim mADYR As Integer
  Public Property _ADYR As Integer
    Get
      Return mADYR
    End Get
    Set(ByVal value As Integer)
      mADYR = value
    End Set
  End Property

  Dim mPDST As Integer
  Public Property _PDST As Integer
    Get
      Return mPDST
    End Get
    Set(ByVal value As Integer)
      mPDST = value
    End Set
  End Property

  Dim mOID As String
  Public Property _OID As String
    Get
      Return mOID
    End Get
    Set(ByVal value As String)
      mOID = value
    End Set
  End Property

  Dim mSS2 As Long
  Public Property _SS2 As Long
    Get
      Return mSS2
    End Get
    Set(ByVal value As Long)
      mSS2 = value
    End Set
  End Property

  Dim mTIN As String
  Public Property _TIN As String
    Get
      Return mTIN
    End Get
    Set(ByVal value As String)
      mTIN = value
    End Set
  End Property
#End Region

End Class

