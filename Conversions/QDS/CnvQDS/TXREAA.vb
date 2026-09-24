Imports System.Data
Imports System.Data.SqlClient
Public Class TXREAA
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Dim Conn As SqlConnection
  Dim MyFileName As String

  Public Sub New(ByVal WrkConn As SqlConnection, ByVal WrkFileName As String)
    Conn = WrkConn
    MyFileName = WrkFileName
  End Sub

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _CAT = String.Empty
    _LISTNo = 0
    _TXYEAR = 0
    _NAME = String.Empty
    _SNAME = String.Empty
    _ADD1 = String.Empty
    _ADD2 = String.Empty
    _CITY = String.Empty
    _STATE = String.Empty
    _ZIP5 = 0
    _ZIP4 = 0
    _UNITNo = String.Empty
    _LOCNo = String.Empty
    _LOC = String.Empty
    _DIST = 0
    _PDST = 0
    _GROSS = 0
    _NET = 0
    _ASS1 = 0
    _ASS2 = 0
    _ASS3 = 0
    _ASS4 = 0
    _ASS5 = 0
    _ASS6 = 0
    _ASS7 = 0
    _CODE1 = 0
    _CODE2 = 0
    _CODE3 = 0
    _CODE4 = 0
    _CODE5 = 0
    _CODE6 = 0
    _CODE7 = 0
    _UNIT1 = 0
    _UNIT2 = 0
    _UNIT3 = 0
    _UNIT4 = 0
    _UNIT5 = 0
    _UNIT6 = 0
    _UNIT7 = 0
    _ACRE1 = 0
    _ACRE2 = 0
    _ACRE3 = 0
    _ACRE4 = 0
    _ACRE5 = 0
    _ACRE6 = 0
    _ACRE7 = 0
    _VOL = String.Empty
    _PGE = String.Empty
    _MAP = String.Empty
    _SMAP = String.Empty
    _EXMPT = String.Empty
    _SEWER = String.Empty
    _PERC = 0
    _FCCOD = String.Empty
    _FCYR = 0
    _CPERC = 0
    _CMAX = 0
    _CMIN = 0
    _CIRAD = 0
    _FTAX = 0
    _FASS = 0
    _TWNBN = 0
    _VTYR = 0
    _EXCD1 = String.Empty
    _EXCD2 = String.Empty
    _EXCD3 = String.Empty
    _EXCD4 = String.Empty
    _EXCD5 = String.Empty
    _EXCD6 = String.Empty
    _EXCD7 = String.Empty
    _EXAM1 = 0
    _EXAM2 = 0
    _EXAM3 = 0
    _EXAM4 = 0
    _EXAM5 = 0
    _EXAM6 = 0
    _EXAM7 = 0
    _CCNO = 0
    _CCGRS = 0
    _CCEX = 0
    _CCRS = String.Empty
    _CDATE = 0
    _CASS1 = 0
    _CASS2 = 0
    _CASS3 = 0
    _CASS4 = 0
    _CASS5 = 0
    _CASS6 = 0
    _CASS7 = 0
    _CCCD1 = String.Empty
    _CCCD2 = String.Empty
    _CCCD3 = String.Empty
    _CCCD4 = String.Empty
    _CCCD5 = String.Empty
    _CCCD6 = String.Empty
    _CCCD7 = String.Empty
    _CEXA1 = 0
    _CEXA2 = 0
    _CEXA3 = 0
    _CEXA4 = 0
    _CEXA5 = 0
    _CEXA6 = 0
    _CEXA7 = 0
    _BTR = 0
    _DNBTR = String.Empty
    _DTBTR = 0
    _BTC = String.Empty
    _BKSV = String.Empty
    _BKCD = String.Empty
    _PURDT = 0
    _PURPR = 0
    _CENBK = 0
    _CENTR = 0
    _CARD = String.Empty
    _SSNo = 0
    _SS2 = 0
    _OID = String.Empty
    _LETT = String.Empty
    _TYPE = String.Empty
    _AIDTE = 0
    _AEDATE = 0
    _AACRE = 0
    _ACCTN = String.Empty
    _WMAIL = String.Empty
    _RLST = 0
    _TIN = String.Empty
    _PRF = String.Empty
    _CHDATE = 0
    _CHTIME = 0

  End Sub
  Public Sub GetOneRecordP(ByVal ListNo As Integer, ByVal WrkYear As Integer)
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & MyFileName & " where list#=" & ListNo & " and txyear=" & WrkYear
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
  Public Function GetIsPosted(ByVal WrkYear As Integer) As Integer
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkResult As Integer

    RecordNotFound = False
    StrSQL = "Select * from " & MyFileName & " where txyear = " & WrkYear
    Try
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, MyFileName)
      objCommand = Nothing
      Conn.Close()
      If ds.Tables(0).Rows.Count = 0 Then
        WrkResult = 0
      Else
        WrkResult = 1
      End If
      Return WrkResult
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function PosData(ByVal Wrklistno As Integer, ByVal Wrktxyear As Integer) As DataSet
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & MyFileName & " where list# >= " & Wrklistno & " And txyear >= " & Wrktxyear & " Order by list#, txyear"
    objCommand = New SqlCommand(StrSQL, Conn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, MyFileName)
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
    da.Fill(ds, MyFileName)
    dr = ds.Tables(0).NewRow
    ds.Tables(0).Rows.Add(dr)
    PutFields(ds)
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
  Public Sub RunUpdateQuery(ByVal Wrkset As String, ByVal wrkwhere As String)
    Dim objCommand As SqlCommand
    Dim Result As Integer

    StrSQL = "Update " & MyFileName & " " & Wrkset & " " & wrkwhere

    RecordNotFound = False
    IsEOF = False
    objCommand = New SqlCommand(StrSQL, Conn)
    Result = objCommand.ExecuteNonQuery()
    objCommand = Nothing
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
      _LISTNo = .Item("LIST#")
      _TXYEAR = .Item("TXYEAR")
      _NAME = .Item("NAME")
      _SNAME = .Item("SNAME")
      _ADD1 = .Item("ADD1")
      _ADD2 = .Item("ADD2")
      _CITY = .Item("CITY")
      _STATE = .Item("STATE")
      _ZIP5 = .Item("ZIP5")
      _ZIP4 = .Item("ZIP4")
      _UNITNo = .Item("UNIT#")
      _LOCNo = .Item("LOC#")
      _LOC = .Item("LOC")
      _DIST = .Item("DIST")
      _PDST = .Item("PDST")
      _GROSS = .Item("GROSS")
      _NET = .Item("NET")
      _ASS1 = .Item("ASS1")
      _ASS2 = .Item("ASS2")
      _ASS3 = .Item("ASS3")
      _ASS4 = .Item("ASS4")
      _ASS5 = .Item("ASS5")
      _ASS6 = .Item("ASS6")
      _ASS7 = .Item("ASS7")
      _CODE1 = .Item("CODE1")
      _CODE2 = .Item("CODE2")
      _CODE3 = .Item("CODE3")
      _CODE4 = .Item("CODE4")
      _CODE5 = .Item("CODE5")
      _CODE6 = .Item("CODE6")
      _CODE7 = .Item("CODE7")
      _UNIT1 = .Item("UNIT1")
      _UNIT2 = .Item("UNIT2")
      _UNIT3 = .Item("UNIT3")
      _UNIT4 = .Item("UNIT4")
      _UNIT5 = .Item("UNIT5")
      _UNIT6 = .Item("UNIT6")
      _UNIT7 = .Item("UNIT7")
      _ACRE1 = .Item("ACRE1")
      _ACRE2 = .Item("ACRE2")
      _ACRE3 = .Item("ACRE3")
      _ACRE4 = .Item("ACRE4")
      _ACRE5 = .Item("ACRE5")
      _ACRE6 = .Item("ACRE6")
      _ACRE7 = .Item("ACRE7")
      _VOL = .Item("VOL")
      _PGE = .Item("PGE")
      _MAP = .Item("MAP")
      _SMAP = .Item("SMAP")
      _EXMPT = .Item("EXMPT")
      _SEWER = .Item("SEWER")
      _PERC = .Item("PERC")
      _FCCOD = .Item("FCCOD")
      _FCYR = .Item("FCYR")
      _CPERC = .Item("CPERC")
      _CMAX = .Item("CMAX")
      _CMIN = .Item("CMIN")
      _CIRAD = .Item("CIRAD")
      _FTAX = .Item("FTAX")
      _FASS = .Item("FASS")
      _TWNBN = .Item("TWNBN")
      _VTYR = .Item("VTYR")
      _EXCD1 = .Item("EXCD1")
      _EXCD2 = .Item("EXCD2")
      _EXCD3 = .Item("EXCD3")
      _EXCD4 = .Item("EXCD4")
      _EXCD5 = .Item("EXCD5")
      _EXCD6 = .Item("EXCD6")
      _EXCD7 = .Item("EXCD7")
      _EXAM1 = .Item("EXAM1")
      _EXAM2 = .Item("EXAM2")
      _EXAM3 = .Item("EXAM3")
      _EXAM4 = .Item("EXAM4")
      _EXAM5 = .Item("EXAM5")
      _EXAM6 = .Item("EXAM6")
      _EXAM7 = .Item("EXAM7")
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
      _CCCD1 = .Item("CCCD1")
      _CCCD2 = .Item("CCCD2")
      _CCCD3 = .Item("CCCD3")
      _CCCD4 = .Item("CCCD4")
      _CCCD5 = .Item("CCCD5")
      _CCCD6 = .Item("CCCD6")
      _CCCD7 = .Item("CCCD7")
      _CEXA1 = .Item("CEXA1")
      _CEXA2 = .Item("CEXA2")
      _CEXA3 = .Item("CEXA3")
      _CEXA4 = .Item("CEXA4")
      _CEXA5 = .Item("CEXA5")
      _CEXA6 = .Item("CEXA6")
      _CEXA7 = .Item("CEXA7")
      _BTR = .Item("BTR")
      _DNBTR = .Item("DNBTR")
      _DTBTR = .Item("DTBTR")
      _BTC = .Item("BTC")
      _BKSV = .Item("BKSV")
      _BKCD = .Item("BKCD")
      _PURDT = .Item("PURDT")
      _PURPR = .Item("PURPR")
      _CENBK = .Item("CENBK")
      _CENTR = .Item("CENTR")
      _CARD = .Item("CARD")
      _SSNo = .Item("SS#")
      _SS2 = .Item("SS2")
      _OID = .Item("OID")
      _LETT = .Item("LETT")
      _TYPE = .Item("TYPE")
      _AIDTE = .Item("AIDTE")
      _AEDATE = .Item("AEDATE")
      _AACRE = .Item("AACRE")
      _ACCTN = .Item("ACCTN")
      _WMAIL = .Item("WMAIL")
      _RLST = .Item("RLST")
      _TIN = .Item("TIN")
      _PRF = .Item("PRF")
      _CHDATE = .Item("CHDATE")
      _CHTIME = .Item("CHTIME")

    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("CAT") = _CAT
      .Item("LIST#") = _LISTNo
      .Item("TXYEAR") = _TXYEAR
      .Item("NAME") = _NAME
      .Item("SNAME") = _SNAME
      .Item("ADD1") = _ADD1
      .Item("ADD2") = _ADD2
      .Item("CITY") = _CITY
      .Item("STATE") = _STATE
      .Item("ZIP5") = _ZIP5
      .Item("ZIP4") = _ZIP4
      .Item("UNIT#") = _UNITNo
      .Item("LOC#") = _LOCNo
      .Item("LOC") = _LOC
      .Item("DIST") = _DIST
      .Item("PDST") = _PDST
      .Item("GROSS") = _GROSS
      .Item("NET") = _NET
      .Item("ASS1") = _ASS1
      .Item("ASS2") = _ASS2
      .Item("ASS3") = _ASS3
      .Item("ASS4") = _ASS4
      .Item("ASS5") = _ASS5
      .Item("ASS6") = _ASS6
      .Item("ASS7") = _ASS7
      .Item("CODE1") = _CODE1
      .Item("CODE2") = _CODE2
      .Item("CODE3") = _CODE3
      .Item("CODE4") = _CODE4
      .Item("CODE5") = _CODE5
      .Item("CODE6") = _CODE6
      .Item("CODE7") = _CODE7
      .Item("UNIT1") = _UNIT1
      .Item("UNIT2") = _UNIT2
      .Item("UNIT3") = _UNIT3
      .Item("UNIT4") = _UNIT4
      .Item("UNIT5") = _UNIT5
      .Item("UNIT6") = _UNIT6
      .Item("UNIT7") = _UNIT7
      .Item("ACRE1") = _ACRE1
      .Item("ACRE2") = _ACRE2
      .Item("ACRE3") = _ACRE3
      .Item("ACRE4") = _ACRE4
      .Item("ACRE5") = _ACRE5
      .Item("ACRE6") = _ACRE6
      .Item("ACRE7") = _ACRE7
      .Item("VOL") = _VOL
      .Item("PGE") = _PGE
      .Item("MAP") = _MAP
      .Item("SMAP") = _SMAP
      .Item("EXMPT") = _EXMPT
      .Item("SEWER") = _SEWER
      .Item("PERC") = _PERC
      .Item("FCCOD") = _FCCOD
      .Item("FCYR") = _FCYR
      .Item("CPERC") = _CPERC
      .Item("CMAX") = _CMAX
      .Item("CMIN") = _CMIN
      .Item("CIRAD") = _CIRAD
      .Item("FTAX") = _FTAX
      .Item("FASS") = _FASS
      .Item("TWNBN") = _TWNBN
      .Item("VTYR") = _VTYR
      .Item("EXCD1") = _EXCD1
      .Item("EXCD2") = _EXCD2
      .Item("EXCD3") = _EXCD3
      .Item("EXCD4") = _EXCD4
      .Item("EXCD5") = _EXCD5
      .Item("EXCD6") = _EXCD6
      .Item("EXCD7") = _EXCD7
      .Item("EXAM1") = _EXAM1
      .Item("EXAM2") = _EXAM2
      .Item("EXAM3") = _EXAM3
      .Item("EXAM4") = _EXAM4
      .Item("EXAM5") = _EXAM5
      .Item("EXAM6") = _EXAM6
      .Item("EXAM7") = _EXAM7
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
      .Item("CCCD1") = _CCCD1
      .Item("CCCD2") = _CCCD2
      .Item("CCCD3") = _CCCD3
      .Item("CCCD4") = _CCCD4
      .Item("CCCD5") = _CCCD5
      .Item("CCCD6") = _CCCD6
      .Item("CCCD7") = _CCCD7
      .Item("CEXA1") = _CEXA1
      .Item("CEXA2") = _CEXA2
      .Item("CEXA3") = _CEXA3
      .Item("CEXA4") = _CEXA4
      .Item("CEXA5") = _CEXA5
      .Item("CEXA6") = _CEXA6
      .Item("CEXA7") = _CEXA7
      .Item("BTR") = _BTR
      .Item("DNBTR") = _DNBTR
      .Item("DTBTR") = _DTBTR
      .Item("BTC") = _BTC
      .Item("BKSV") = _BKSV
      .Item("BKCD") = _BKCD
      .Item("PURDT") = _PURDT
      .Item("PURPR") = _PURPR
      .Item("CENBK") = _CENBK
      .Item("CENTR") = _CENTR
      .Item("CARD") = _CARD
      .Item("SS#") = _SSNo
      .Item("SS2") = _SS2
      .Item("OID") = _OID
      .Item("LETT") = _LETT
      .Item("TYPE") = _TYPE
      .Item("AIDTE") = _AIDTE
      .Item("AEDATE") = _AEDATE
      .Item("AACRE") = _AACRE
      .Item("ACCTN") = _ACCTN
      .Item("WMAIL") = _WMAIL
      .Item("RLST") = _RLST
      .Item("TIN") = _TIN
      .Item("PRF") = _PRF
      .Item("CHDATE") = _CHDATE
      .Item("CHTIME") = _CHTIME

    End With
  End Sub
#End Region


#Region "Properties: Fields"

  Dim mCAT As String
  Public Property _CAT As String
    Get
      Return mCAT
    End Get
    Set(ByVal value As String)
      mCAT = value
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

  Dim mTXYEAR As Integer
  Public Property _TXYEAR As Integer
    Get
      Return mTXYEAR
    End Get
    Set(ByVal value As Integer)
      mTXYEAR = value
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

  Dim mUNITNo As String
  Public Property _UNITNo As String
    Get
      Return mUNITNo
    End Get
    Set(ByVal value As String)
      mUNITNo = value
    End Set
  End Property

  Dim mLOCNo As String
  Public Property _LOCNo As String
    Get
      Return mLOCNo
    End Get
    Set(ByVal value As String)
      mLOCNo = value
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

  Dim mPDST As Integer
  Public Property _PDST As Integer
    Get
      Return mPDST
    End Get
    Set(ByVal value As Integer)
      mPDST = value
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

  Dim mACRE1 As Decimal
  Public Property _ACRE1 As Decimal
    Get
      Return mACRE1
    End Get
    Set(ByVal value As Decimal)
      mACRE1 = value
    End Set
  End Property

  Dim mACRE2 As Decimal
  Public Property _ACRE2 As Decimal
    Get
      Return mACRE2
    End Get
    Set(ByVal value As Decimal)
      mACRE2 = value
    End Set
  End Property

  Dim mACRE3 As Decimal
  Public Property _ACRE3 As Decimal
    Get
      Return mACRE3
    End Get
    Set(ByVal value As Decimal)
      mACRE3 = value
    End Set
  End Property

  Dim mACRE4 As Decimal
  Public Property _ACRE4 As Decimal
    Get
      Return mACRE4
    End Get
    Set(ByVal value As Decimal)
      mACRE4 = value
    End Set
  End Property

  Dim mACRE5 As Decimal
  Public Property _ACRE5 As Decimal
    Get
      Return mACRE5
    End Get
    Set(ByVal value As Decimal)
      mACRE5 = value
    End Set
  End Property

  Dim mACRE6 As Decimal
  Public Property _ACRE6 As Decimal
    Get
      Return mACRE6
    End Get
    Set(ByVal value As Decimal)
      mACRE6 = value
    End Set
  End Property

  Dim mACRE7 As Decimal
  Public Property _ACRE7 As Decimal
    Get
      Return mACRE7
    End Get
    Set(ByVal value As Decimal)
      mACRE7 = value
    End Set
  End Property

  Dim mVOL As String
  Public Property _VOL As String
    Get
      Return mVOL
    End Get
    Set(ByVal value As String)
      mVOL = value
    End Set
  End Property

  Dim mPGE As String
  Public Property _PGE As String
    Get
      Return mPGE
    End Get
    Set(ByVal value As String)
      mPGE = value
    End Set
  End Property

  Dim mMAP As String
  Public Property _MAP As String
    Get
      Return mMAP
    End Get
    Set(ByVal value As String)
      mMAP = value
    End Set
  End Property

  Dim mSMAP As String
  Public Property _SMAP As String
    Get
      Return mSMAP
    End Get
    Set(ByVal value As String)
      mSMAP = value
    End Set
  End Property

  Dim mEXMPT As String
  Public Property _EXMPT As String
    Get
      Return mEXMPT
    End Get
    Set(ByVal value As String)
      mEXMPT = value
    End Set
  End Property

  Dim mSEWER As String
  Public Property _SEWER As String
    Get
      Return mSEWER
    End Get
    Set(ByVal value As String)
      mSEWER = value
    End Set
  End Property

  Dim mPERC As Decimal
  Public Property _PERC As Decimal
    Get
      Return mPERC
    End Get
    Set(ByVal value As Decimal)
      mPERC = value
    End Set
  End Property

  Dim mFCCOD As String
  Public Property _FCCOD As String
    Get
      Return mFCCOD
    End Get
    Set(ByVal value As String)
      mFCCOD = value
    End Set
  End Property

  Dim mFCYR As Integer
  Public Property _FCYR As Integer
    Get
      Return mFCYR
    End Get
    Set(ByVal value As Integer)
      mFCYR = value
    End Set
  End Property

  Dim mCPERC As Decimal
  Public Property _CPERC As Decimal
    Get
      Return mCPERC
    End Get
    Set(ByVal value As Decimal)
      mCPERC = value
    End Set
  End Property

  Dim mCMAX As Integer
  Public Property _CMAX As Integer
    Get
      Return mCMAX
    End Get
    Set(ByVal value As Integer)
      mCMAX = value
    End Set
  End Property

  Dim mCMIN As Integer
  Public Property _CMIN As Integer
    Get
      Return mCMIN
    End Get
    Set(ByVal value As Integer)
      mCMIN = value
    End Set
  End Property

  Dim mCIRAD As Decimal
  Public Property _CIRAD As Decimal
    Get
      Return mCIRAD
    End Get
    Set(ByVal value As Decimal)
      mCIRAD = value
    End Set
  End Property

  Dim mFTAX As Decimal
  Public Property _FTAX As Decimal
    Get
      Return mFTAX
    End Get
    Set(ByVal value As Decimal)
      mFTAX = value
    End Set
  End Property

  Dim mFASS As Decimal
  Public Property _FASS As Decimal
    Get
      Return mFASS
    End Get
    Set(ByVal value As Decimal)
      mFASS = value
    End Set
  End Property

  Dim mTWNBN As Decimal
  Public Property _TWNBN As Decimal
    Get
      Return mTWNBN
    End Get
    Set(ByVal value As Decimal)
      mTWNBN = value
    End Set
  End Property

  Dim mVTYR As Integer
  Public Property _VTYR As Integer
    Get
      Return mVTYR
    End Get
    Set(ByVal value As Integer)
      mVTYR = value
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

  Dim mEXCD6 As String
  Public Property _EXCD6 As String
    Get
      Return mEXCD6
    End Get
    Set(ByVal value As String)
      mEXCD6 = value
    End Set
  End Property

  Dim mEXCD7 As String
  Public Property _EXCD7 As String
    Get
      Return mEXCD7
    End Get
    Set(ByVal value As String)
      mEXCD7 = value
    End Set
  End Property

  Dim mEXAM1 As Long
  Public Property _EXAM1 As Long
    Get
      Return mEXAM1
    End Get
    Set(ByVal value As Long)
      mEXAM1 = value
    End Set
  End Property

  Dim mEXAM2 As Long
  Public Property _EXAM2 As Long
    Get
      Return mEXAM2
    End Get
    Set(ByVal value As Long)
      mEXAM2 = value
    End Set
  End Property

  Dim mEXAM3 As Long
  Public Property _EXAM3 As Long
    Get
      Return mEXAM3
    End Get
    Set(ByVal value As Long)
      mEXAM3 = value
    End Set
  End Property

  Dim mEXAM4 As Long
  Public Property _EXAM4 As Long
    Get
      Return mEXAM4
    End Get
    Set(ByVal value As Long)
      mEXAM4 = value
    End Set
  End Property

  Dim mEXAM5 As Long
  Public Property _EXAM5 As Long
    Get
      Return mEXAM5
    End Get
    Set(ByVal value As Long)
      mEXAM5 = value
    End Set
  End Property

  Dim mEXAM6 As Long
  Public Property _EXAM6 As Long
    Get
      Return mEXAM6
    End Get
    Set(ByVal value As Long)
      mEXAM6 = value
    End Set
  End Property

  Dim mEXAM7 As Long
  Public Property _EXAM7 As Long
    Get
      Return mEXAM7
    End Get
    Set(ByVal value As Long)
      mEXAM7 = value
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

  Dim mCCCD6 As String
  Public Property _CCCD6 As String
    Get
      Return mCCCD6
    End Get
    Set(ByVal value As String)
      mCCCD6 = value
    End Set
  End Property

  Dim mCCCD7 As String
  Public Property _CCCD7 As String
    Get
      Return mCCCD7
    End Get
    Set(ByVal value As String)
      mCCCD7 = value
    End Set
  End Property

  Dim mCEXA1 As Long
  Public Property _CEXA1 As Long
    Get
      Return mCEXA1
    End Get
    Set(ByVal value As Long)
      mCEXA1 = value
    End Set
  End Property

  Dim mCEXA2 As Long
  Public Property _CEXA2 As Long
    Get
      Return mCEXA2
    End Get
    Set(ByVal value As Long)
      mCEXA2 = value
    End Set
  End Property

  Dim mCEXA3 As Long
  Public Property _CEXA3 As Long
    Get
      Return mCEXA3
    End Get
    Set(ByVal value As Long)
      mCEXA3 = value
    End Set
  End Property

  Dim mCEXA4 As Long
  Public Property _CEXA4 As Long
    Get
      Return mCEXA4
    End Get
    Set(ByVal value As Long)
      mCEXA4 = value
    End Set
  End Property

  Dim mCEXA5 As Long
  Public Property _CEXA5 As Long
    Get
      Return mCEXA5
    End Get
    Set(ByVal value As Long)
      mCEXA5 = value
    End Set
  End Property

  Dim mCEXA6 As Long
  Public Property _CEXA6 As Long
    Get
      Return mCEXA6
    End Get
    Set(ByVal value As Long)
      mCEXA6 = value
    End Set
  End Property

  Dim mCEXA7 As Long
  Public Property _CEXA7 As Long
    Get
      Return mCEXA7
    End Get
    Set(ByVal value As Long)
      mCEXA7 = value
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

  Dim mBTC As String
  Public Property _BTC As String
    Get
      Return mBTC
    End Get
    Set(ByVal value As String)
      mBTC = value
    End Set
  End Property

  Dim mBKSV As String
  Public Property _BKSV As String
    Get
      Return mBKSV
    End Get
    Set(ByVal value As String)
      mBKSV = value
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

  Dim mPURDT As Integer
  Public Property _PURDT As Integer
    Get
      Return mPURDT
    End Get
    Set(ByVal value As Integer)
      mPURDT = value
    End Set
  End Property

  Dim mPURPR As Long
  Public Property _PURPR As Long
    Get
      Return mPURPR
    End Get
    Set(ByVal value As Long)
      mPURPR = value
    End Set
  End Property

  Dim mCENBK As Integer
  Public Property _CENBK As Integer
    Get
      Return mCENBK
    End Get
    Set(ByVal value As Integer)
      mCENBK = value
    End Set
  End Property

  Dim mCENTR As Integer
  Public Property _CENTR As Integer
    Get
      Return mCENTR
    End Get
    Set(ByVal value As Integer)
      mCENTR = value
    End Set
  End Property

  Dim mCARD As String
  Public Property _CARD As String
    Get
      Return mCARD
    End Get
    Set(ByVal value As String)
      mCARD = value
    End Set
  End Property

  Dim mSSNo As Long
  Public Property _SSNo As Long
    Get
      Return mSSNo
    End Get
    Set(ByVal value As Long)
      mSSNo = value
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

  Dim mOID As String
  Public Property _OID As String
    Get
      Return mOID
    End Get
    Set(ByVal value As String)
      mOID = value
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

  Dim mAIDTE As Integer
  Public Property _AIDTE As Integer
    Get
      Return mAIDTE
    End Get
    Set(ByVal value As Integer)
      mAIDTE = value
    End Set
  End Property

  Dim mAEDATE As Integer
  Public Property _AEDATE As Integer
    Get
      Return mAEDATE
    End Get
    Set(ByVal value As Integer)
      mAEDATE = value
    End Set
  End Property

  Dim mAACRE As Integer
  Public Property _AACRE As Integer
    Get
      Return mAACRE
    End Get
    Set(ByVal value As Integer)
      mAACRE = value
    End Set
  End Property

  Dim mACCTN As String
  Public Property _ACCTN As String
    Get
      Return mACCTN
    End Get
    Set(ByVal value As String)
      mACCTN = value
    End Set
  End Property

  Dim mWMAIL As String
  Public Property _WMAIL As String
    Get
      Return mWMAIL
    End Get
    Set(ByVal value As String)
      mWMAIL = value
    End Set
  End Property

  Dim mRLST As Integer
  Public Property _RLST As Integer
    Get
      Return mRLST
    End Get
    Set(ByVal value As Integer)
      mRLST = value
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


