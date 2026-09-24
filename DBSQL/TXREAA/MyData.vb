Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXREAA"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_CAT = string.empty
_LISTNo  = 0
_TXYEAR  = 0
_NAME = string.empty
_SNAME = string.empty
_ADD1 = string.empty
_ADD2 = string.empty
_CITY = string.empty
_STATE = string.empty
_ZIP5  = 0
_ZIP4  = 0
_UNITNo = string.empty
_LOCNo = string.empty
_LOC = string.empty
_DIST  = 0
_PDST  = 0
_GROSS  = 0
_NET  = 0
_ASS1  = 0
_ASS2  = 0
_ASS3  = 0
_ASS4  = 0
_ASS5  = 0
_ASS6  = 0
_ASS7  = 0
_CODE1  = 0
_CODE2  = 0
_CODE3  = 0
_CODE4  = 0
_CODE5  = 0
_CODE6  = 0
_CODE7  = 0
_UNIT1  = 0
_UNIT2  = 0
_UNIT3  = 0
_UNIT4  = 0
_UNIT5  = 0
_UNIT6  = 0
_UNIT7  = 0
_ACRE1 = 0
_ACRE2 = 0
_ACRE3 = 0
_ACRE4 = 0
_ACRE5 = 0
_ACRE6 = 0
_ACRE7 = 0
_VOL = string.empty
_PGE = string.empty
_MAP = string.empty
_SMAP = string.empty
_EXMPT = string.empty
_SEWER = string.empty
_PERC = 0
_FCCOD = string.empty
_FCYR = 0
_CPERC = 0
_CMAX = 0
_CMIN = 0
_CIRAD = 0
_FTAX = 0
_FASS = 0
_TWNBN = 0
_VTYR  = 0
_EXCD1 = string.empty
_EXCD2 = string.empty
_EXCD3 = string.empty
_EXCD4 = string.empty
_EXCD5 = string.empty
_EXCD6 = string.empty
_EXCD7 = string.empty
_EXAM1  = 0
_EXAM2  = 0
_EXAM3  = 0
_EXAM4  = 0
_EXAM5  = 0
_EXAM6  = 0
_EXAM7  = 0
_CCNO  = 0
_CCGRS  = 0
_CCEX  = 0
_CCRS = string.empty
_CDATE  = 0
_CASS1  = 0
_CASS2  = 0
_CASS3  = 0
_CASS4  = 0
_CASS5  = 0
_CASS6  = 0
_CASS7  = 0
_CCCD1 = string.empty
_CCCD2 = string.empty
_CCCD3 = string.empty
_CCCD4 = string.empty
_CCCD5 = string.empty
_CCCD6 = string.empty
_CCCD7 = string.empty
_CEXA1  = 0
_CEXA2  = 0
_CEXA3  = 0
_CEXA4  = 0
_CEXA5  = 0
_CEXA6  = 0
_CEXA7  = 0
_BTR  = 0
_DNBTR = string.empty
_DTBTR  = 0
_BTC = string.empty
_BKSV = string.empty
_BKCD = string.empty
_PURDT  = 0
_PURPR  = 0
_CENBK  = 0
_CENTR  = 0
_CARD = string.empty
_SSNo  = 0
_SS2  = 0
_OID = string.empty
_LETT = string.empty
_TYPE = string.empty
_AIDTE  = 0
_AEDATE  = 0
_AACRE  = 0
_ACCTN = string.empty
_WMAIL = string.empty
_RLST  = 0
_TIN = string.empty
_PRF = string.empty
_CHDATE  = 0
_CHTIME  = 0

End Sub
  Public Sub GetOneRecordP(ByVal Wrklistno As integer, ByVal Wrktxyear As integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " and txyear = " & Wrktxyear
    Try
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    If ds.Tables(0).Rows.Count = 0 Then
      RecordNotFound = True
 ClearFields 
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
  Public Function PosData(ByVal Wrklistno As Integer, ByVal Wrktxyear As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where list# >= " & Wrklistno & " And txyear = " & Wrktxyear & " Order by list#"
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
  Public Function GetIsPosted(ByVal WrkYear As Integer) As Integer
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkResult As Integer

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where txyear = " & WrkYear
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
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
  _CAT      = .Item("CAT")
  _LISTNo   = .Item("LIST#")
  _TXYEAR   = .Item("TXYEAR")
  _NAME     = .Item("NAME")
  _SNAME    = .Item("SNAME")
  _ADD1     = .Item("ADD1")
  _ADD2     = .Item("ADD2")
  _CITY     = .Item("CITY")
  _STATE    = .Item("STATE")
  _ZIP5     = .Item("ZIP5")
  _ZIP4     = .Item("ZIP4")
  _UNITNo   = .Item("UNIT#")
  _LOCNo    = .Item("LOC#")
  _LOC      = .Item("LOC")
  _DIST     = .Item("DIST")
  _PDST     = .Item("PDST")
  _GROSS    = .Item("GROSS")
  _NET      = .Item("NET")
  _ASS1     = .Item("ASS1")
  _ASS2     = .Item("ASS2")
  _ASS3     = .Item("ASS3")
  _ASS4     = .Item("ASS4")
  _ASS5     = .Item("ASS5")
  _ASS6     = .Item("ASS6")
  _ASS7     = .Item("ASS7")
  _CODE1    = .Item("CODE1")
  _CODE2    = .Item("CODE2")
  _CODE3    = .Item("CODE3")
  _CODE4    = .Item("CODE4")
  _CODE5    = .Item("CODE5")
  _CODE6    = .Item("CODE6")
  _CODE7    = .Item("CODE7")
  _UNIT1    = .Item("UNIT1")
  _UNIT2    = .Item("UNIT2")
  _UNIT3    = .Item("UNIT3")
  _UNIT4    = .Item("UNIT4")
  _UNIT5    = .Item("UNIT5")
  _UNIT6    = .Item("UNIT6")
  _UNIT7    = .Item("UNIT7")
  _ACRE1    = .Item("ACRE1")
  _ACRE2    = .Item("ACRE2")
  _ACRE3    = .Item("ACRE3")
  _ACRE4    = .Item("ACRE4")
  _ACRE5    = .Item("ACRE5")
  _ACRE6    = .Item("ACRE6")
  _ACRE7    = .Item("ACRE7")
  _VOL      = .Item("VOL")
  _PGE      = .Item("PGE")
  _MAP      = .Item("MAP")
  _SMAP     = .Item("SMAP")
  _EXMPT    = .Item("EXMPT")
  _SEWER    = .Item("SEWER")
  _PERC     = .Item("PERC")
  _FCCOD    = .Item("FCCOD")
  _FCYR     = .Item("FCYR")
  _CPERC    = .Item("CPERC")
  _CMAX     = .Item("CMAX")
  _CMIN     = .Item("CMIN")
  _CIRAD    = .Item("CIRAD")
  _FTAX     = .Item("FTAX")
  _FASS     = .Item("FASS")
  _TWNBN    = .Item("TWNBN")
  _VTYR     = .Item("VTYR")
  _EXCD1    = .Item("EXCD1")
  _EXCD2    = .Item("EXCD2")
  _EXCD3    = .Item("EXCD3")
  _EXCD4    = .Item("EXCD4")
  _EXCD5    = .Item("EXCD5")
  _EXCD6    = .Item("EXCD6")
  _EXCD7    = .Item("EXCD7")
  _EXAM1    = .Item("EXAM1")
  _EXAM2    = .Item("EXAM2")
  _EXAM3    = .Item("EXAM3")
  _EXAM4    = .Item("EXAM4")
  _EXAM5    = .Item("EXAM5")
  _EXAM6    = .Item("EXAM6")
  _EXAM7    = .Item("EXAM7")
  _CCNO     = .Item("CCNO")
  _CCGRS    = .Item("CCGRS")
  _CCEX     = .Item("CCEX")
  _CCRS     = .Item("CCRS")
  _CDATE    = .Item("CDATE")
  _CASS1    = .Item("CASS1")
  _CASS2    = .Item("CASS2")
  _CASS3    = .Item("CASS3")
  _CASS4    = .Item("CASS4")
  _CASS5    = .Item("CASS5")
  _CASS6    = .Item("CASS6")
  _CASS7    = .Item("CASS7")
  _CCCD1    = .Item("CCCD1")
  _CCCD2    = .Item("CCCD2")
  _CCCD3    = .Item("CCCD3")
  _CCCD4    = .Item("CCCD4")
  _CCCD5    = .Item("CCCD5")
  _CCCD6    = .Item("CCCD6")
  _CCCD7    = .Item("CCCD7")
  _CEXA1    = .Item("CEXA1")
  _CEXA2    = .Item("CEXA2")
  _CEXA3    = .Item("CEXA3")
  _CEXA4    = .Item("CEXA4")
  _CEXA5    = .Item("CEXA5")
  _CEXA6    = .Item("CEXA6")
  _CEXA7    = .Item("CEXA7")
  _BTR      = .Item("BTR")
  _DNBTR    = .Item("DNBTR")
  _DTBTR    = .Item("DTBTR")
  _BTC      = .Item("BTC")
  _BKSV     = .Item("BKSV")
  _BKCD     = .Item("BKCD")
  _PURDT    = .Item("PURDT")
  _PURPR    = .Item("PURPR")
  _CENBK    = .Item("CENBK")
  _CENTR    = .Item("CENTR")
  _CARD     = .Item("CARD")
  _SSNo     = .Item("SS#")
  _SS2      = .Item("SS2")
  _OID      = .Item("OID")
  _LETT     = .Item("LETT")
  _TYPE     = .Item("TYPE")
  _AIDTE    = .Item("AIDTE")
  _AEDATE   = .Item("AEDATE")
  _AACRE    = .Item("AACRE")
  _ACCTN    = .Item("ACCTN")
  _WMAIL    = .Item("WMAIL")
  _RLST     = .Item("RLST")
  _TIN      = .Item("TIN")
  _PRF      = .Item("PRF")
  _CHDATE   = .Item("CHDATE")
  _CHTIME   = .Item("CHTIME")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("CAT") =   _CAT     
.Item("LIST#") =   _LISTNo  
.Item("TXYEAR") =   _TXYEAR  
.Item("NAME") =   _NAME    
.Item("SNAME") =   _SNAME   
.Item("ADD1") =   _ADD1    
.Item("ADD2") =   _ADD2    
.Item("CITY") =   _CITY    
.Item("STATE") =   _STATE   
.Item("ZIP5") =   _ZIP5    
.Item("ZIP4") =   _ZIP4    
.Item("UNIT#") =   _UNITNo  
.Item("LOC#") =   _LOCNo   
.Item("LOC") =   _LOC     
.Item("DIST") =   _DIST    
.Item("PDST") =   _PDST    
.Item("GROSS") =   _GROSS   
.Item("NET") =   _NET     
.Item("ASS1") =   _ASS1    
.Item("ASS2") =   _ASS2    
.Item("ASS3") =   _ASS3    
.Item("ASS4") =   _ASS4    
.Item("ASS5") =   _ASS5    
.Item("ASS6") =   _ASS6    
.Item("ASS7") =   _ASS7    
.Item("CODE1") =   _CODE1   
.Item("CODE2") =   _CODE2   
.Item("CODE3") =   _CODE3   
.Item("CODE4") =   _CODE4   
.Item("CODE5") =   _CODE5   
.Item("CODE6") =   _CODE6   
.Item("CODE7") =   _CODE7   
.Item("UNIT1") =   _UNIT1   
.Item("UNIT2") =   _UNIT2   
.Item("UNIT3") =   _UNIT3   
.Item("UNIT4") =   _UNIT4   
.Item("UNIT5") =   _UNIT5   
.Item("UNIT6") =   _UNIT6   
.Item("UNIT7") =   _UNIT7   
.Item("ACRE1") =   _ACRE1   
.Item("ACRE2") =   _ACRE2   
.Item("ACRE3") =   _ACRE3   
.Item("ACRE4") =   _ACRE4   
.Item("ACRE5") =   _ACRE5   
.Item("ACRE6") =   _ACRE6   
.Item("ACRE7") =   _ACRE7   
.Item("VOL") =   _VOL     
.Item("PGE") =   _PGE     
.Item("MAP") =   _MAP     
.Item("SMAP") =   _SMAP    
.Item("EXMPT") =   _EXMPT   
.Item("SEWER") =   _SEWER   
.Item("PERC") =   _PERC    
.Item("FCCOD") =   _FCCOD   
.Item("FCYR") =   _FCYR    
.Item("CPERC") =   _CPERC   
.Item("CMAX") =   _CMAX    
.Item("CMIN") =   _CMIN    
.Item("CIRAD") =   _CIRAD   
.Item("FTAX") =   _FTAX    
.Item("FASS") =   _FASS    
.Item("TWNBN") =   _TWNBN   
.Item("VTYR") =   _VTYR    
.Item("EXCD1") =   _EXCD1   
.Item("EXCD2") =   _EXCD2   
.Item("EXCD3") =   _EXCD3   
.Item("EXCD4") =   _EXCD4   
.Item("EXCD5") =   _EXCD5   
.Item("EXCD6") =   _EXCD6   
.Item("EXCD7") =   _EXCD7   
.Item("EXAM1") =   _EXAM1   
.Item("EXAM2") =   _EXAM2   
.Item("EXAM3") =   _EXAM3   
.Item("EXAM4") =   _EXAM4   
.Item("EXAM5") =   _EXAM5   
.Item("EXAM6") =   _EXAM6   
.Item("EXAM7") =   _EXAM7   
.Item("CCNO") =   _CCNO    
.Item("CCGRS") =   _CCGRS   
.Item("CCEX") =   _CCEX    
.Item("CCRS") =   _CCRS    
.Item("CDATE") =   _CDATE   
.Item("CASS1") =   _CASS1   
.Item("CASS2") =   _CASS2   
.Item("CASS3") =   _CASS3   
.Item("CASS4") =   _CASS4   
.Item("CASS5") =   _CASS5   
.Item("CASS6") =   _CASS6   
.Item("CASS7") =   _CASS7   
.Item("CCCD1") =   _CCCD1   
.Item("CCCD2") =   _CCCD2   
.Item("CCCD3") =   _CCCD3   
.Item("CCCD4") =   _CCCD4   
.Item("CCCD5") =   _CCCD5   
.Item("CCCD6") =   _CCCD6   
.Item("CCCD7") =   _CCCD7   
.Item("CEXA1") =   _CEXA1   
.Item("CEXA2") =   _CEXA2   
.Item("CEXA3") =   _CEXA3   
.Item("CEXA4") =   _CEXA4   
.Item("CEXA5") =   _CEXA5   
.Item("CEXA6") =   _CEXA6   
.Item("CEXA7") =   _CEXA7   
.Item("BTR") =   _BTR     
.Item("DNBTR") =   _DNBTR   
.Item("DTBTR") =   _DTBTR   
.Item("BTC") =   _BTC     
.Item("BKSV") =   _BKSV    
.Item("BKCD") =   _BKCD    
.Item("PURDT") =   _PURDT   
.Item("PURPR") =   _PURPR   
.Item("CENBK") =   _CENBK   
.Item("CENTR") =   _CENTR   
.Item("CARD") =   _CARD    
.Item("SS#") =   _SSNo    
.Item("SS2") =   _SS2     
.Item("OID") =   _OID     
.Item("LETT") =   _LETT    
.Item("TYPE") =   _TYPE    
.Item("AIDTE") =   _AIDTE   
.Item("AEDATE") =   _AEDATE  
.Item("AACRE") =   _AACRE   
.Item("ACCTN") =   _ACCTN   
.Item("WMAIL") =   _WMAIL   
.Item("RLST") =   _RLST    
.Item("TIN") =   _TIN     
.Item("PRF") =   _PRF     
.Item("CHDATE") =   _CHDATE  
.Item("CHTIME") =   _CHTIME  

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mCAT as string 
Public Property _CAT as string   
    Get
        Return mCAT
    End Get
    set(byval value as string)
        mCAT = value
    End Set
End Property

Dim mLISTNo  as integer 
Public Property _LISTNo  as integer   
    Get
        Return mLISTNo
    End Get
    set(byval value as integer)
        mLISTNo = value
    End Set
End Property

Dim mTXYEAR  as integer 
Public Property _TXYEAR  as integer   
    Get
        Return mTXYEAR
    End Get
    set(byval value as integer)
        mTXYEAR = value
    End Set
End Property

Dim mNAME as string 
Public Property _NAME as string   
    Get
        Return mNAME
    End Get
    set(byval value as string)
        mNAME = value
    End Set
End Property

Dim mSNAME as string 
Public Property _SNAME as string   
    Get
        Return mSNAME
    End Get
    set(byval value as string)
        mSNAME = value
    End Set
End Property

Dim mADD1 as string 
Public Property _ADD1 as string   
    Get
        Return mADD1
    End Get
    set(byval value as string)
        mADD1 = value
    End Set
End Property

Dim mADD2 as string 
Public Property _ADD2 as string   
    Get
        Return mADD2
    End Get
    set(byval value as string)
        mADD2 = value
    End Set
End Property

Dim mCITY as string 
Public Property _CITY as string   
    Get
        Return mCITY
    End Get
    set(byval value as string)
        mCITY = value
    End Set
End Property

Dim mSTATE as string 
Public Property _STATE as string   
    Get
        Return mSTATE
    End Get
    set(byval value as string)
        mSTATE = value
    End Set
End Property

Dim mZIP5  as integer 
Public Property _ZIP5  as integer   
    Get
        Return mZIP5
    End Get
    set(byval value as integer)
        mZIP5 = value
    End Set
End Property

Dim mZIP4  as integer 
Public Property _ZIP4  as integer   
    Get
        Return mZIP4
    End Get
    set(byval value as integer)
        mZIP4 = value
    End Set
End Property

Dim mUNITNo as string 
Public Property _UNITNo as string   
    Get
        Return mUNITNo
    End Get
    set(byval value as string)
        mUNITNo = value
    End Set
End Property

Dim mLOCNo as string 
Public Property _LOCNo as string   
    Get
        Return mLOCNo
    End Get
    set(byval value as string)
        mLOCNo = value
    End Set
End Property

Dim mLOC as string 
Public Property _LOC as string   
    Get
        Return mLOC
    End Get
    set(byval value as string)
        mLOC = value
    End Set
End Property

Dim mDIST  as integer 
Public Property _DIST  as integer   
    Get
        Return mDIST
    End Get
    set(byval value as integer)
        mDIST = value
    End Set
End Property

Dim mPDST  as integer 
Public Property _PDST  as integer   
    Get
        Return mPDST
    End Get
    set(byval value as integer)
        mPDST = value
    End Set
End Property

Dim mGROSS  as long
Public Property _GROSS  as long  
    Get
        Return mGROSS
    End Get
    set(byval value as long)
        mGROSS = value
    End Set
End Property

Dim mNET  as long
Public Property _NET  as long  
    Get
        Return mNET
    End Get
    set(byval value as long)
        mNET = value
    End Set
End Property

Dim mASS1  as long
Public Property _ASS1  as long  
    Get
        Return mASS1
    End Get
    set(byval value as long)
        mASS1 = value
    End Set
End Property

Dim mASS2  as long
Public Property _ASS2  as long  
    Get
        Return mASS2
    End Get
    set(byval value as long)
        mASS2 = value
    End Set
End Property

Dim mASS3  as long
Public Property _ASS3  as long  
    Get
        Return mASS3
    End Get
    set(byval value as long)
        mASS3 = value
    End Set
End Property

Dim mASS4  as long
Public Property _ASS4  as long  
    Get
        Return mASS4
    End Get
    set(byval value as long)
        mASS4 = value
    End Set
End Property

Dim mASS5  as long
Public Property _ASS5  as long  
    Get
        Return mASS5
    End Get
    set(byval value as long)
        mASS5 = value
    End Set
End Property

Dim mASS6  as long
Public Property _ASS6  as long  
    Get
        Return mASS6
    End Get
    set(byval value as long)
        mASS6 = value
    End Set
End Property

Dim mASS7  as long
Public Property _ASS7  as long  
    Get
        Return mASS7
    End Get
    set(byval value as long)
        mASS7 = value
    End Set
End Property

Dim mCODE1  as integer 
Public Property _CODE1  as integer   
    Get
        Return mCODE1
    End Get
    set(byval value as integer)
        mCODE1 = value
    End Set
End Property

Dim mCODE2  as integer 
Public Property _CODE2  as integer   
    Get
        Return mCODE2
    End Get
    set(byval value as integer)
        mCODE2 = value
    End Set
End Property

Dim mCODE3  as integer 
Public Property _CODE3  as integer   
    Get
        Return mCODE3
    End Get
    set(byval value as integer)
        mCODE3 = value
    End Set
End Property

Dim mCODE4  as integer 
Public Property _CODE4  as integer   
    Get
        Return mCODE4
    End Get
    set(byval value as integer)
        mCODE4 = value
    End Set
End Property

Dim mCODE5  as integer 
Public Property _CODE5  as integer   
    Get
        Return mCODE5
    End Get
    set(byval value as integer)
        mCODE5 = value
    End Set
End Property

Dim mCODE6  as integer 
Public Property _CODE6  as integer   
    Get
        Return mCODE6
    End Get
    set(byval value as integer)
        mCODE6 = value
    End Set
End Property

Dim mCODE7  as integer 
Public Property _CODE7  as integer   
    Get
        Return mCODE7
    End Get
    set(byval value as integer)
        mCODE7 = value
    End Set
End Property

Dim mUNIT1  as integer 
Public Property _UNIT1  as integer   
    Get
        Return mUNIT1
    End Get
    set(byval value as integer)
        mUNIT1 = value
    End Set
End Property

Dim mUNIT2  as integer 
Public Property _UNIT2  as integer   
    Get
        Return mUNIT2
    End Get
    set(byval value as integer)
        mUNIT2 = value
    End Set
End Property

Dim mUNIT3  as integer 
Public Property _UNIT3  as integer   
    Get
        Return mUNIT3
    End Get
    set(byval value as integer)
        mUNIT3 = value
    End Set
End Property

Dim mUNIT4  as integer 
Public Property _UNIT4  as integer   
    Get
        Return mUNIT4
    End Get
    set(byval value as integer)
        mUNIT4 = value
    End Set
End Property

Dim mUNIT5  as integer 
Public Property _UNIT5  as integer   
    Get
        Return mUNIT5
    End Get
    set(byval value as integer)
        mUNIT5 = value
    End Set
End Property

Dim mUNIT6  as integer 
Public Property _UNIT6  as integer   
    Get
        Return mUNIT6
    End Get
    set(byval value as integer)
        mUNIT6 = value
    End Set
End Property

Dim mUNIT7  as integer 
Public Property _UNIT7  as integer   
    Get
        Return mUNIT7
    End Get
    set(byval value as integer)
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

Dim mVTYR  as integer 
Public Property _VTYR  as integer   
    Get
        Return mVTYR
    End Get
    set(byval value as integer)
        mVTYR = value
    End Set
End Property

Dim mEXCD1 as string 
Public Property _EXCD1 as string   
    Get
        Return mEXCD1
    End Get
    set(byval value as string)
        mEXCD1 = value
    End Set
End Property

Dim mEXCD2 as string 
Public Property _EXCD2 as string   
    Get
        Return mEXCD2
    End Get
    set(byval value as string)
        mEXCD2 = value
    End Set
End Property

Dim mEXCD3 as string 
Public Property _EXCD3 as string   
    Get
        Return mEXCD3
    End Get
    set(byval value as string)
        mEXCD3 = value
    End Set
End Property

Dim mEXCD4 as string 
Public Property _EXCD4 as string   
    Get
        Return mEXCD4
    End Get
    set(byval value as string)
        mEXCD4 = value
    End Set
End Property

Dim mEXCD5 as string 
Public Property _EXCD5 as string   
    Get
        Return mEXCD5
    End Get
    set(byval value as string)
        mEXCD5 = value
    End Set
End Property

Dim mEXCD6 as string 
Public Property _EXCD6 as string   
    Get
        Return mEXCD6
    End Get
    set(byval value as string)
        mEXCD6 = value
    End Set
End Property

Dim mEXCD7 as string 
Public Property _EXCD7 as string   
    Get
        Return mEXCD7
    End Get
    set(byval value as string)
        mEXCD7 = value
    End Set
End Property

Dim mEXAM1  as long
Public Property _EXAM1  as long  
    Get
        Return mEXAM1
    End Get
    set(byval value as long)
        mEXAM1 = value
    End Set
End Property

Dim mEXAM2  as long
Public Property _EXAM2  as long  
    Get
        Return mEXAM2
    End Get
    set(byval value as long)
        mEXAM2 = value
    End Set
End Property

Dim mEXAM3  as long
Public Property _EXAM3  as long  
    Get
        Return mEXAM3
    End Get
    set(byval value as long)
        mEXAM3 = value
    End Set
End Property

Dim mEXAM4  as long
Public Property _EXAM4  as long  
    Get
        Return mEXAM4
    End Get
    set(byval value as long)
        mEXAM4 = value
    End Set
End Property

Dim mEXAM5  as long
Public Property _EXAM5  as long  
    Get
        Return mEXAM5
    End Get
    set(byval value as long)
        mEXAM5 = value
    End Set
End Property

Dim mEXAM6  as long
Public Property _EXAM6  as long  
    Get
        Return mEXAM6
    End Get
    set(byval value as long)
        mEXAM6 = value
    End Set
End Property

Dim mEXAM7  as long
Public Property _EXAM7  as long  
    Get
        Return mEXAM7
    End Get
    set(byval value as long)
        mEXAM7 = value
    End Set
End Property

Dim mCCNO  as integer 
Public Property _CCNO  as integer   
    Get
        Return mCCNO
    End Get
    set(byval value as integer)
        mCCNO = value
    End Set
End Property

Dim mCCGRS  as long
Public Property _CCGRS  as long  
    Get
        Return mCCGRS
    End Get
    set(byval value as long)
        mCCGRS = value
    End Set
End Property

Dim mCCEX  as long
Public Property _CCEX  as long  
    Get
        Return mCCEX
    End Get
    set(byval value as long)
        mCCEX = value
    End Set
End Property

Dim mCCRS as string 
Public Property _CCRS as string   
    Get
        Return mCCRS
    End Get
    set(byval value as string)
        mCCRS = value
    End Set
End Property

Dim mCDATE  as integer 
Public Property _CDATE  as integer   
    Get
        Return mCDATE
    End Get
    set(byval value as integer)
        mCDATE = value
    End Set
End Property

Dim mCASS1  as long
Public Property _CASS1  as long  
    Get
        Return mCASS1
    End Get
    set(byval value as long)
        mCASS1 = value
    End Set
End Property

Dim mCASS2  as long
Public Property _CASS2  as long  
    Get
        Return mCASS2
    End Get
    set(byval value as long)
        mCASS2 = value
    End Set
End Property

Dim mCASS3  as long
Public Property _CASS3  as long  
    Get
        Return mCASS3
    End Get
    set(byval value as long)
        mCASS3 = value
    End Set
End Property

Dim mCASS4  as long
Public Property _CASS4  as long  
    Get
        Return mCASS4
    End Get
    set(byval value as long)
        mCASS4 = value
    End Set
End Property

Dim mCASS5  as long
Public Property _CASS5  as long  
    Get
        Return mCASS5
    End Get
    set(byval value as long)
        mCASS5 = value
    End Set
End Property

Dim mCASS6  as long
Public Property _CASS6  as long  
    Get
        Return mCASS6
    End Get
    set(byval value as long)
        mCASS6 = value
    End Set
End Property

Dim mCASS7  as long
Public Property _CASS7  as long  
    Get
        Return mCASS7
    End Get
    set(byval value as long)
        mCASS7 = value
    End Set
End Property

Dim mCCCD1 as string 
Public Property _CCCD1 as string   
    Get
        Return mCCCD1
    End Get
    set(byval value as string)
        mCCCD1 = value
    End Set
End Property

Dim mCCCD2 as string 
Public Property _CCCD2 as string   
    Get
        Return mCCCD2
    End Get
    set(byval value as string)
        mCCCD2 = value
    End Set
End Property

Dim mCCCD3 as string 
Public Property _CCCD3 as string   
    Get
        Return mCCCD3
    End Get
    set(byval value as string)
        mCCCD3 = value
    End Set
End Property

Dim mCCCD4 as string 
Public Property _CCCD4 as string   
    Get
        Return mCCCD4
    End Get
    set(byval value as string)
        mCCCD4 = value
    End Set
End Property

Dim mCCCD5 as string 
Public Property _CCCD5 as string   
    Get
        Return mCCCD5
    End Get
    set(byval value as string)
        mCCCD5 = value
    End Set
End Property

Dim mCCCD6 as string 
Public Property _CCCD6 as string   
    Get
        Return mCCCD6
    End Get
    set(byval value as string)
        mCCCD6 = value
    End Set
End Property

Dim mCCCD7 as string 
Public Property _CCCD7 as string   
    Get
        Return mCCCD7
    End Get
    set(byval value as string)
        mCCCD7 = value
    End Set
End Property

Dim mCEXA1  as long
Public Property _CEXA1  as long  
    Get
        Return mCEXA1
    End Get
    set(byval value as long)
        mCEXA1 = value
    End Set
End Property

Dim mCEXA2  as long
Public Property _CEXA2  as long  
    Get
        Return mCEXA2
    End Get
    set(byval value as long)
        mCEXA2 = value
    End Set
End Property

Dim mCEXA3  as long
Public Property _CEXA3  as long  
    Get
        Return mCEXA3
    End Get
    set(byval value as long)
        mCEXA3 = value
    End Set
End Property

Dim mCEXA4  as long
Public Property _CEXA4  as long  
    Get
        Return mCEXA4
    End Get
    set(byval value as long)
        mCEXA4 = value
    End Set
End Property

Dim mCEXA5  as long
Public Property _CEXA5  as long  
    Get
        Return mCEXA5
    End Get
    set(byval value as long)
        mCEXA5 = value
    End Set
End Property

Dim mCEXA6  as long
Public Property _CEXA6  as long  
    Get
        Return mCEXA6
    End Get
    set(byval value as long)
        mCEXA6 = value
    End Set
End Property

Dim mCEXA7  as long
Public Property _CEXA7  as long  
    Get
        Return mCEXA7
    End Get
    set(byval value as long)
        mCEXA7 = value
    End Set
End Property

Dim mBTR  as long
Public Property _BTR  as long  
    Get
        Return mBTR
    End Get
    set(byval value as long)
        mBTR = value
    End Set
End Property

Dim mDNBTR as string 
Public Property _DNBTR as string   
    Get
        Return mDNBTR
    End Get
    set(byval value as string)
        mDNBTR = value
    End Set
End Property

Dim mDTBTR  as integer 
Public Property _DTBTR  as integer   
    Get
        Return mDTBTR
    End Get
    set(byval value as integer)
        mDTBTR = value
    End Set
End Property

Dim mBTC as string 
Public Property _BTC as string   
    Get
        Return mBTC
    End Get
    set(byval value as string)
        mBTC = value
    End Set
End Property

Dim mBKSV as string 
Public Property _BKSV as string   
    Get
        Return mBKSV
    End Get
    set(byval value as string)
        mBKSV = value
    End Set
End Property

Dim mBKCD as string 
Public Property _BKCD as string   
    Get
        Return mBKCD
    End Get
    set(byval value as string)
        mBKCD = value
    End Set
End Property

Dim mPURDT  as integer 
Public Property _PURDT  as integer   
    Get
        Return mPURDT
    End Get
    set(byval value as integer)
        mPURDT = value
    End Set
End Property

Dim mPURPR  as long
Public Property _PURPR  as long  
    Get
        Return mPURPR
    End Get
    set(byval value as long)
        mPURPR = value
    End Set
End Property

Dim mCENBK  as integer 
Public Property _CENBK  as integer   
    Get
        Return mCENBK
    End Get
    set(byval value as integer)
        mCENBK = value
    End Set
End Property

Dim mCENTR  as integer 
Public Property _CENTR  as integer   
    Get
        Return mCENTR
    End Get
    set(byval value as integer)
        mCENTR = value
    End Set
End Property

Dim mCARD as string 
Public Property _CARD as string   
    Get
        Return mCARD
    End Get
    set(byval value as string)
        mCARD = value
    End Set
End Property

Dim mSSNo  as long
Public Property _SSNo  as long  
    Get
        Return mSSNo
    End Get
    set(byval value as long)
        mSSNo = value
    End Set
End Property

Dim mSS2  as long
Public Property _SS2  as long  
    Get
        Return mSS2
    End Get
    set(byval value as long)
        mSS2 = value
    End Set
End Property

Dim mOID as string 
Public Property _OID as string   
    Get
        Return mOID
    End Get
    set(byval value as string)
        mOID = value
    End Set
End Property

Dim mLETT as string 
Public Property _LETT as string   
    Get
        Return mLETT
    End Get
    set(byval value as string)
        mLETT = value
    End Set
End Property

Dim mTYPE as string 
Public Property _TYPE as string   
    Get
        Return mTYPE
    End Get
    set(byval value as string)
        mTYPE = value
    End Set
End Property

Dim mAIDTE  as integer 
Public Property _AIDTE  as integer   
    Get
        Return mAIDTE
    End Get
    set(byval value as integer)
        mAIDTE = value
    End Set
End Property

Dim mAEDATE  as integer 
Public Property _AEDATE  as integer   
    Get
        Return mAEDATE
    End Get
    set(byval value as integer)
        mAEDATE = value
    End Set
End Property

Dim mAACRE  as integer 
Public Property _AACRE  as integer   
    Get
        Return mAACRE
    End Get
    set(byval value as integer)
        mAACRE = value
    End Set
End Property

Dim mACCTN as string 
Public Property _ACCTN as string   
    Get
        Return mACCTN
    End Get
    set(byval value as string)
        mACCTN = value
    End Set
End Property

Dim mWMAIL as string 
Public Property _WMAIL as string   
    Get
        Return mWMAIL
    End Get
    set(byval value as string)
        mWMAIL = value
    End Set
End Property

Dim mRLST  as integer 
Public Property _RLST  as integer   
    Get
        Return mRLST
    End Get
    set(byval value as integer)
        mRLST = value
    End Set
End Property

Dim mTIN as string 
Public Property _TIN as string   
    Get
        Return mTIN
    End Get
    set(byval value as string)
        mTIN = value
    End Set
End Property

Dim mPRF as string 
Public Property _PRF as string   
    Get
        Return mPRF
    End Get
    set(byval value as string)
        mPRF = value
    End Set
End Property

Dim mCHDATE  as integer 
Public Property _CHDATE  as integer   
    Get
        Return mCHDATE
    End Get
    set(byval value as integer)
        mCHDATE = value
    End Set
End Property

Dim mCHTIME  as integer 
Public Property _CHTIME  as integer   
    Get
        Return mCHTIME
    End Get
    set(byval value as integer)
        mCHTIME = value
    End Set
End Property

Dim mRecordNotFound As Boolean
Public Property RecordNotFound() As Boolean
  Set(ByVal value as Boolean)
    mRecordNotFound = value
  End Set
  Get
    Return mRecordNotFound
  End Get
End Property
Dim mIsEOF As Boolean
Public Property IsEOF() As Boolean
  Set(ByVal value as Boolean)
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
    Set(ByVal value as String)
        mErrMsg = value
    End Set
End Property
#End Region
End Class


