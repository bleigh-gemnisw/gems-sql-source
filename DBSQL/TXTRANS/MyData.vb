Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXTRANS"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_LISTNO  = 0
_CAT  = 0
_NAME = string.empty
_SNAME = string.empty
_ADD1 = string.empty
_ADD2 = string.empty
_CITY = string.empty
_STATE = string.empty
_ZIP5  = 0
_ZIP4  = 0
_VOL = string.empty
_TPAGE = string.empty
_MAP = string.empty
_EXMPT = string.empty
_TDATE  = 0
_PRICE  = 0
_CENBK  = 0
_CENTR  = 0
_ELDCD = string.empty
_EXMPT2 = string.empty
_SSNO  = 0
_PRF = string.empty
_CHDATE  = 0
_CHTIME  = 0
_POSTED = string.empty

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
  _LISTNO   = .Item("LIST#")
  _CAT      = .Item("CAT")
  _NAME     = .Item("NAME")
  _SNAME    = .Item("SNAME")
  _ADD1     = .Item("ADD1")
  _ADD2     = .Item("ADD2")
  _CITY     = .Item("CITY")
  _STATE    = .Item("STATE")
  _ZIP5     = .Item("ZIP5")
  _ZIP4     = .Item("ZIP4")
  _VOL      = .Item("VOL")
  _TPAGE    = .Item("TPAGE")
  _MAP      = .Item("MAP")
  _EXMPT    = .Item("EXMPT")
  _TDATE    = .Item("TDATE")
  _PRICE    = .Item("PRICE")
  _CENBK    = .Item("CENBK")
  _CENTR    = .Item("CENTR")
  _ELDCD    = .Item("ELDCD")
  _EXMPT2   = .Item("EXMPT2")
  _SSNO     = .Item("SS#")
  _PRF      = .Item("PRF")
  _CHDATE   = .Item("CHDATE")
  _CHTIME   = .Item("CHTIME")
  _POSTED   = .Item("POSTED")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("LIST#") =   _LISTNO  
.Item("CAT") =   _CAT     
.Item("NAME") =   _NAME    
.Item("SNAME") =   _SNAME   
.Item("ADD1") =   _ADD1    
.Item("ADD2") =   _ADD2    
.Item("CITY") =   _CITY    
.Item("STATE") =   _STATE   
.Item("ZIP5") =   _ZIP5    
.Item("ZIP4") =   _ZIP4    
.Item("VOL") =   _VOL     
.Item("TPAGE") =   _TPAGE   
.Item("MAP") =   _MAP     
.Item("EXMPT") =   _EXMPT   
.Item("TDATE") =   _TDATE   
.Item("PRICE") =   _PRICE   
.Item("CENBK") =   _CENBK   
.Item("CENTR") =   _CENTR   
.Item("ELDCD") =   _ELDCD   
.Item("EXMPT2") =   _EXMPT2  
.Item("SS#") =   _SSNO    
.Item("PRF") =   _PRF     
.Item("CHDATE") =   _CHDATE  
.Item("CHTIME") =   _CHTIME  
.Item("POSTED") =   _POSTED  

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

Dim mCAT  as integer 
Public Property _CAT  as integer   
    Get
        Return mCAT
    End Get
    set(byval value as integer)
        mCAT = value
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

Dim mVOL as string 
Public Property _VOL as string   
    Get
        Return mVOL
    End Get
    set(byval value as string)
        mVOL = value
    End Set
End Property

Dim mTPAGE as string 
Public Property _TPAGE as string   
    Get
        Return mTPAGE
    End Get
    set(byval value as string)
        mTPAGE = value
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

Dim mEXMPT as string 
Public Property _EXMPT as string   
    Get
        Return mEXMPT
    End Get
    set(byval value as string)
        mEXMPT = value
    End Set
End Property

Dim mTDATE  as integer 
Public Property _TDATE  as integer   
    Get
        Return mTDATE
    End Get
    set(byval value as integer)
        mTDATE = value
    End Set
End Property

Dim mPRICE  as long
Public Property _PRICE  as long  
    Get
        Return mPRICE
    End Get
    set(byval value as long)
        mPRICE = value
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

Dim mELDCD as string 
Public Property _ELDCD as string   
    Get
        Return mELDCD
    End Get
    set(byval value as string)
        mELDCD = value
    End Set
End Property

Dim mEXMPT2 as string 
Public Property _EXMPT2 as string   
    Get
        Return mEXMPT2
    End Get
    set(byval value as string)
        mEXMPT2 = value
    End Set
End Property

Dim mSSNO  as long
Public Property _SSNO  as long  
    Get
        Return mSSNO
    End Get
    set(byval value as long)
        mSSNO = value
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

Dim mPOSTED as string 
Public Property _POSTED as string   
    Get
        Return mPOSTED
    End Get
    set(byval value as string)
        mPOSTED = value
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


