Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXPROMS"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_CAT = string.empty
_LISTNo  = 0
_NAME = string.empty
_SNAME = string.empty
_ADD1 = string.empty
_ADD2 = string.empty
_CITY = string.empty
_STATE = string.empty
_ZIP5  = 0
_ZIP4  = 0
_LOCNo = string.empty
_LOC = string.empty
_VOL = string.empty
_XPAGE = string.empty
_MAP = string.empty
_SURV = string.empty
_DIST  = 0
_GROSS  = 0
_TEX  = 0
_NET  = 0
_BTC = string.empty
_BKCD = string.empty
_MLTPR = string.empty
_PAYNo  = 0
_COTYPE = string.empty
_RLIST  = 0
_CONUM  = 0
_POST = string.empty
_SSNo  = 0
_PRF = string.empty
_CHDATE  = 0
_CHTIME  = 0
_LETT = string.empty

End Sub
  Public Sub GetOneRecordP(ByVal Wrklistno As integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno
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
Public Function PosData(ByVal Wrklistno As integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where list# >= " & Wrklistno & " Order by list#"
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
  _NAME     = .Item("NAME")
  _SNAME    = .Item("SNAME")
  _ADD1     = .Item("ADD1")
  _ADD2     = .Item("ADD2")
  _CITY     = .Item("CITY")
  _STATE    = .Item("STATE")
  _ZIP5     = .Item("ZIP5")
  _ZIP4     = .Item("ZIP4")
  _LOCNo    = .Item("LOC#")
  _LOC      = .Item("LOC")
  _VOL      = .Item("VOL")
  _XPAGE    = .Item("XPAGE")
  _MAP      = .Item("MAP")
  _SURV     = .Item("SURV")
  _DIST     = .Item("DIST")
  _GROSS    = .Item("GROSS")
  _TEX      = .Item("TEX")
  _NET      = .Item("NET")
  _BTC      = .Item("BTC")
  _BKCD     = .Item("BKCD")
  _MLTPR    = .Item("MLTPR")
  _PAYNo    = .Item("PAY#")
  _COTYPE   = .Item("COTYPE")
  _RLIST    = .Item("RLIST")
  _CONUM    = .Item("CONUM")
  _POST     = .Item("POST")
  _SSNo     = .Item("SS#")
  _PRF      = .Item("PRF")
  _CHDATE   = .Item("CHDATE")
  _CHTIME   = .Item("CHTIME")
  _LETT     = .Item("LETT")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("CAT") =   _CAT     
.Item("LIST#") =   _LISTNo  
.Item("NAME") =   _NAME    
.Item("SNAME") =   _SNAME   
.Item("ADD1") =   _ADD1    
.Item("ADD2") =   _ADD2    
.Item("CITY") =   _CITY    
.Item("STATE") =   _STATE   
.Item("ZIP5") =   _ZIP5    
.Item("ZIP4") =   _ZIP4    
.Item("LOC#") =   _LOCNo   
.Item("LOC") =   _LOC     
.Item("VOL") =   _VOL     
.Item("XPAGE") =   _XPAGE   
.Item("MAP") =   _MAP     
.Item("SURV") =   _SURV    
.Item("DIST") =   _DIST    
.Item("GROSS") =   _GROSS   
.Item("TEX") =   _TEX     
.Item("NET") =   _NET     
.Item("BTC") =   _BTC     
.Item("BKCD") =   _BKCD    
.Item("MLTPR") =   _MLTPR   
.Item("PAY#") =   _PAYNo   
.Item("COTYPE") =   _COTYPE  
.Item("RLIST") =   _RLIST   
.Item("CONUM") =   _CONUM   
.Item("POST") =   _POST    
.Item("SS#") =   _SSNo    
.Item("PRF") =   _PRF     
.Item("CHDATE") =   _CHDATE  
.Item("CHTIME") =   _CHTIME  
.Item("LETT") =   _LETT    

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

Dim mVOL as string 
Public Property _VOL as string   
    Get
        Return mVOL
    End Get
    set(byval value as string)
        mVOL = value
    End Set
End Property

Dim mXPAGE as string 
Public Property _XPAGE as string   
    Get
        Return mXPAGE
    End Get
    set(byval value as string)
        mXPAGE = value
    End Set
End Property

Dim mMAP as string 
Public Property _MAP as string   
    Get
        Return mMAP
    End Get
    set(byval value as string)
        mMAP = value
    End Set
End Property

Dim mSURV as string 
Public Property _SURV as string   
    Get
        Return mSURV
    End Get
    set(byval value as string)
        mSURV = value
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

Dim mGROSS  as long
Public Property _GROSS  as long  
    Get
        Return mGROSS
    End Get
    set(byval value as long)
        mGROSS = value
    End Set
End Property

Dim mTEX  as long
Public Property _TEX  as long  
    Get
        Return mTEX
    End Get
    set(byval value as long)
        mTEX = value
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

Dim mBTC as string 
Public Property _BTC as string   
    Get
        Return mBTC
    End Get
    set(byval value as string)
        mBTC = value
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

Dim mMLTPR as string 
Public Property _MLTPR as string   
    Get
        Return mMLTPR
    End Get
    set(byval value as string)
        mMLTPR = value
    End Set
End Property

Dim mPAYNo  as integer 
Public Property _PAYNo  as integer   
    Get
        Return mPAYNo
    End Get
    set(byval value as integer)
        mPAYNo = value
    End Set
End Property

Dim mCOTYPE as string 
Public Property _COTYPE as string   
    Get
        Return mCOTYPE
    End Get
    set(byval value as string)
        mCOTYPE = value
    End Set
End Property

Dim mRLIST  as integer 
Public Property _RLIST  as integer   
    Get
        Return mRLIST
    End Get
    set(byval value as integer)
        mRLIST = value
    End Set
End Property

Dim mCONUM  as integer 
Public Property _CONUM  as integer   
    Get
        Return mCONUM
    End Get
    set(byval value as integer)
        mCONUM = value
    End Set
End Property

Dim mPOST as string 
Public Property _POST as string   
    Get
        Return mPOST
    End Get
    set(byval value as string)
        mPOST = value
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

Dim mLETT as string 
Public Property _LETT as string   
    Get
        Return mLETT
    End Get
    set(byval value as string)
        mLETT = value
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


