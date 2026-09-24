Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXDMPP"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_LISTNO  = 0
_YEAR  = 0
_NAME = string.empty
_ADDR = string.empty
_CITY = string.empty
_STATE = string.empty
_ZIP5  = 0
_ZIP4  = 0
_RNAME = string.empty
_RADDR = string.empty
_RCITY = string.empty
_RSTATE = string.empty
_RZIP5  = 0
_RZIP4  = 0
_CTID = string.empty
_FEDID = string.empty
_CNAME = string.empty
_CTITLE = string.empty
_CPHONE  = 0
_CFAX  = 0
_LOCNO = string.empty
_LOC = string.empty
_LCITY = string.empty
_LSTATE = string.empty
_LZIP5  = 0
_LZIP4  = 0
_RCVBEN = string.empty
_EXEMPT = string.empty
_BNAME = string.empty
_BADDR = string.empty
_BCITY = string.empty
_BSTATE = string.empty
_BZIP5  = 0
_BZIP4  = 0
_G1MFG = string.empty
_G2RES = string.empty
_G3MACH = string.empty
_G4PROD = string.empty
_G5MEAS = string.empty
_G6MET = string.empty
_G7MOV = string.empty
_G8BIO = string.empty
_G9REC = string.empty
_BUSACT = string.empty
_RECVDT  = 0
_SIGNED = string.empty
_SIGNDT  = 0

End Sub
  Public Sub GetOneRecordP(ByVal Wrklistno As integer, ByVal Wrkyear As integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " and year = " & Wrkyear
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
Public Function PosData(ByVal Wrklistno As integer, ByVal Wrkyear As integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " And year >= " & Wrkyear & " Or list# > " & Wrklistno & " Order by list#, year"
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
  _LISTNO   = .Item("LIST#")
  _YEAR     = .Item("YEAR")
  _NAME     = .Item("NAME")
  _ADDR     = .Item("ADDR")
  _CITY     = .Item("CITY")
  _STATE    = .Item("STATE")
  _ZIP5     = .Item("ZIP5")
  _ZIP4     = .Item("ZIP4")
  _RNAME    = .Item("RNAME")
  _RADDR    = .Item("RADDR")
  _RCITY    = .Item("RCITY")
  _RSTATE   = .Item("RSTATE")
  _RZIP5    = .Item("RZIP5")
  _RZIP4    = .Item("RZIP4")
  _CTID     = .Item("CTID")
  _FEDID    = .Item("FEDID")
  _CNAME    = .Item("CNAME")
  _CTITLE   = .Item("CTITLE")
  _CPHONE   = .Item("CPHONE")
  _CFAX     = .Item("CFAX")
  _LOCNO    = .Item("LOC#")
  _LOC      = .Item("LOC")
  _LCITY    = .Item("LCITY")
  _LSTATE   = .Item("LSTATE")
  _LZIP5    = .Item("LZIP5")
  _LZIP4    = .Item("LZIP4")
  _RCVBEN   = .Item("RCVBEN")
  _EXEMPT   = .Item("EXEMPT")
  _BNAME    = .Item("BNAME")
  _BADDR    = .Item("BADDR")
  _BCITY    = .Item("BCITY")
  _BSTATE   = .Item("BSTATE")
  _BZIP5    = .Item("BZIP5")
  _BZIP4    = .Item("BZIP4")
  _G1MFG    = .Item("G1MFG")
  _G2RES    = .Item("G2RES")
  _G3MACH   = .Item("G3MACH")
  _G4PROD   = .Item("G4PROD")
  _G5MEAS   = .Item("G5MEAS")
  _G6MET    = .Item("G6MET")
  _G7MOV    = .Item("G7MOV")
  _G8BIO    = .Item("G8BIO")
  _G9REC    = .Item("G9REC")
  _BUSACT   = .Item("BUSACT")
  _RECVDT   = .Item("RECVDT")
  _SIGNED   = .Item("SIGNED")
  _SIGNDT   = .Item("SIGNDT")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("LIST#") =   _LISTNO  
.Item("YEAR") =   _YEAR    
.Item("NAME") =   _NAME    
.Item("ADDR") =   _ADDR    
.Item("CITY") =   _CITY    
.Item("STATE") =   _STATE   
.Item("ZIP5") =   _ZIP5    
.Item("ZIP4") =   _ZIP4    
.Item("RNAME") =   _RNAME   
.Item("RADDR") =   _RADDR   
.Item("RCITY") =   _RCITY   
.Item("RSTATE") =   _RSTATE  
.Item("RZIP5") =   _RZIP5   
.Item("RZIP4") =   _RZIP4   
.Item("CTID") =   _CTID    
.Item("FEDID") =   _FEDID   
.Item("CNAME") =   _CNAME   
.Item("CTITLE") =   _CTITLE  
.Item("CPHONE") =   _CPHONE  
.Item("CFAX") =   _CFAX    
.Item("LOC#") =   _LOCNO   
.Item("LOC") =   _LOC     
.Item("LCITY") =   _LCITY   
.Item("LSTATE") =   _LSTATE  
.Item("LZIP5") =   _LZIP5   
.Item("LZIP4") =   _LZIP4   
.Item("RCVBEN") =   _RCVBEN  
.Item("EXEMPT") =   _EXEMPT  
.Item("BNAME") =   _BNAME   
.Item("BADDR") =   _BADDR   
.Item("BCITY") =   _BCITY   
.Item("BSTATE") =   _BSTATE  
.Item("BZIP5") =   _BZIP5   
.Item("BZIP4") =   _BZIP4   
.Item("G1MFG") =   _G1MFG   
.Item("G2RES") =   _G2RES   
.Item("G3MACH") =   _G3MACH  
.Item("G4PROD") =   _G4PROD  
.Item("G5MEAS") =   _G5MEAS  
.Item("G6MET") =   _G6MET   
.Item("G7MOV") =   _G7MOV   
.Item("G8BIO") =   _G8BIO   
.Item("G9REC") =   _G9REC   
.Item("BUSACT") =   _BUSACT  
.Item("RECVDT") =   _RECVDT  
.Item("SIGNED") =   _SIGNED  
.Item("SIGNDT") =   _SIGNDT  

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mLISTNO  as integer 
Public Property _LISTNO  as integer   
    Get
        Return mLISTNO
    End Get
    set(byval value as integer)
        mLISTNO = value
    End Set
End Property

Dim mYEAR  as integer 
Public Property _YEAR  as integer   
    Get
        Return mYEAR
    End Get
    set(byval value as integer)
        mYEAR = value
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

Dim mADDR as string 
Public Property _ADDR as string   
    Get
        Return mADDR
    End Get
    set(byval value as string)
        mADDR = value
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

Dim mRNAME as string 
Public Property _RNAME as string   
    Get
        Return mRNAME
    End Get
    set(byval value as string)
        mRNAME = value
    End Set
End Property

Dim mRADDR as string 
Public Property _RADDR as string   
    Get
        Return mRADDR
    End Get
    set(byval value as string)
        mRADDR = value
    End Set
End Property

Dim mRCITY as string 
Public Property _RCITY as string   
    Get
        Return mRCITY
    End Get
    set(byval value as string)
        mRCITY = value
    End Set
End Property

Dim mRSTATE as string 
Public Property _RSTATE as string   
    Get
        Return mRSTATE
    End Get
    set(byval value as string)
        mRSTATE = value
    End Set
End Property

Dim mRZIP5  as integer 
Public Property _RZIP5  as integer   
    Get
        Return mRZIP5
    End Get
    set(byval value as integer)
        mRZIP5 = value
    End Set
End Property

Dim mRZIP4  as integer 
Public Property _RZIP4  as integer   
    Get
        Return mRZIP4
    End Get
    set(byval value as integer)
        mRZIP4 = value
    End Set
End Property

Dim mCTID as string 
Public Property _CTID as string   
    Get
        Return mCTID
    End Get
    set(byval value as string)
        mCTID = value
    End Set
End Property

Dim mFEDID as string 
Public Property _FEDID as string   
    Get
        Return mFEDID
    End Get
    set(byval value as string)
        mFEDID = value
    End Set
End Property

Dim mCNAME as string 
Public Property _CNAME as string   
    Get
        Return mCNAME
    End Get
    set(byval value as string)
        mCNAME = value
    End Set
End Property

Dim mCTITLE as string 
Public Property _CTITLE as string   
    Get
        Return mCTITLE
    End Get
    set(byval value as string)
        mCTITLE = value
    End Set
End Property
  Dim mCPHONE As Long
  Public Property _CPHONE As Long
    Get
      Return mCPHONE
    End Get
    Set(ByVal value As Long)
      mCPHONE = value
    End Set
  End Property
  Dim mCFAX As Long
  Public Property _CFAX As Long
    Get
      Return mCFAX
    End Get
    Set(ByVal value As Long)
      mCFAX = value
    End Set
  End Property

  Dim mLOCNO as string 
Public Property _LOCNO as string   
    Get
        Return mLOCNO
    End Get
    set(byval value as string)
        mLOCNO = value
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

Dim mLCITY as string 
Public Property _LCITY as string   
    Get
        Return mLCITY
    End Get
    set(byval value as string)
        mLCITY = value
    End Set
End Property

Dim mLSTATE as string 
Public Property _LSTATE as string   
    Get
        Return mLSTATE
    End Get
    set(byval value as string)
        mLSTATE = value
    End Set
End Property

Dim mLZIP5  as integer 
Public Property _LZIP5  as integer   
    Get
        Return mLZIP5
    End Get
    set(byval value as integer)
        mLZIP5 = value
    End Set
End Property

Dim mLZIP4  as integer 
Public Property _LZIP4  as integer   
    Get
        Return mLZIP4
    End Get
    set(byval value as integer)
        mLZIP4 = value
    End Set
End Property

Dim mRCVBEN as string 
Public Property _RCVBEN as string   
    Get
        Return mRCVBEN
    End Get
    set(byval value as string)
        mRCVBEN = value
    End Set
End Property

Dim mEXEMPT as string 
Public Property _EXEMPT as string   
    Get
        Return mEXEMPT
    End Get
    set(byval value as string)
        mEXEMPT = value
    End Set
End Property

Dim mBNAME as string 
Public Property _BNAME as string   
    Get
        Return mBNAME
    End Get
    set(byval value as string)
        mBNAME = value
    End Set
End Property

Dim mBADDR as string 
Public Property _BADDR as string   
    Get
        Return mBADDR
    End Get
    set(byval value as string)
        mBADDR = value
    End Set
End Property

Dim mBCITY as string 
Public Property _BCITY as string   
    Get
        Return mBCITY
    End Get
    set(byval value as string)
        mBCITY = value
    End Set
End Property

Dim mBSTATE as string 
Public Property _BSTATE as string   
    Get
        Return mBSTATE
    End Get
    set(byval value as string)
        mBSTATE = value
    End Set
End Property

Dim mBZIP5  as integer 
Public Property _BZIP5  as integer   
    Get
        Return mBZIP5
    End Get
    set(byval value as integer)
        mBZIP5 = value
    End Set
End Property

Dim mBZIP4  as integer 
Public Property _BZIP4  as integer   
    Get
        Return mBZIP4
    End Get
    set(byval value as integer)
        mBZIP4 = value
    End Set
End Property

Dim mG1MFG as string 
Public Property _G1MFG as string   
    Get
        Return mG1MFG
    End Get
    set(byval value as string)
        mG1MFG = value
    End Set
End Property

Dim mG2RES as string 
Public Property _G2RES as string   
    Get
        Return mG2RES
    End Get
    set(byval value as string)
        mG2RES = value
    End Set
End Property

Dim mG3MACH as string 
Public Property _G3MACH as string   
    Get
        Return mG3MACH
    End Get
    set(byval value as string)
        mG3MACH = value
    End Set
End Property

Dim mG4PROD as string 
Public Property _G4PROD as string   
    Get
        Return mG4PROD
    End Get
    set(byval value as string)
        mG4PROD = value
    End Set
End Property

Dim mG5MEAS as string 
Public Property _G5MEAS as string   
    Get
        Return mG5MEAS
    End Get
    set(byval value as string)
        mG5MEAS = value
    End Set
End Property

Dim mG6MET as string 
Public Property _G6MET as string   
    Get
        Return mG6MET
    End Get
    set(byval value as string)
        mG6MET = value
    End Set
End Property

Dim mG7MOV as string 
Public Property _G7MOV as string   
    Get
        Return mG7MOV
    End Get
    set(byval value as string)
        mG7MOV = value
    End Set
End Property

Dim mG8BIO as string 
Public Property _G8BIO as string   
    Get
        Return mG8BIO
    End Get
    set(byval value as string)
        mG8BIO = value
    End Set
End Property

Dim mG9REC as string 
Public Property _G9REC as string   
    Get
        Return mG9REC
    End Get
    set(byval value as string)
        mG9REC = value
    End Set
End Property
  Dim mBUSACT As String
  Public Property _BUSACT As String
    Get
      Return mBUSACT
    End Get
    Set(ByVal value As String)
      mBUSACT = value
    End Set
  End Property

  Dim mRECVDT  as integer 
Public Property _RECVDT  as integer   
    Get
        Return mRECVDT
    End Get
    set(byval value as integer)
        mRECVDT = value
    End Set
End Property

Dim mSIGNED as string 
Public Property _SIGNED as string   
    Get
        Return mSIGNED
    End Get
    set(byval value as string)
        mSIGNED = value
    End Set
End Property

Dim mSIGNDT  as integer 
Public Property _SIGNDT  as integer   
    Get
        Return mSIGNDT
    End Get
    set(byval value as integer)
        mSIGNDT = value
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


