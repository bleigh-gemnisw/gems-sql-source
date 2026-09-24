Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXDCLOR"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_LISTNO  = 0
_YEAR  = 0
_SEQNO  = 0
_NAME = string.empty
_ADDR = string.empty
_PHYLOC = string.empty
_DESC = string.empty
_MFG = string.empty
_ACQDT  = 0
_PRICE  = 0
_PURCH = string.empty
_PURFRM = string.empty
_PURDT  = 0
_TRAN = string.empty
_LESTYP = string.empty
_TERM = string.empty
_RENT  = 0
_COSTS  = 0
_NEWMFG = string.empty
_NEWTYP = string.empty

End Sub
  Public Sub GetOneRecordP(ByVal Wrklistno As integer, ByVal Wrkyear As integer, ByVal Wrkseqno As integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " and year = " & Wrkyear & " and seqno = " & Wrkseqno
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
  Public Function PosData(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer, ByVal Wrkseqno As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " And year = " & Wrkyear & " And seqno >= " & Wrkseqno & " Or list# = " & Wrklistno & " And year > " & Wrkyear & " Or list# > " & Wrklistno & " Order by list#, year, seqno"
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
  Public Function AutoGenKey(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer) As Integer
    Dim NextKey As Integer
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    RecordNotFound = False

    StrSQL = "Select top 1 * from " & cFileName & " where list# = " & Wrklistno & " and year = " & Wrkyear & " order by seqno desc"
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
  Public Function GetByList(ByVal Wrklistno As Integer, wrkyear As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet


    RecordNotFound = False

    StrSQL = "Select  * FROM " & cFileName _
    & " where list# =" & Wrklistno & " AND YEAR = " & wrkyear & " order by list#"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      objCommand = Nothing
      Conn.Close()
      Return ds
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Sub DeleteListNo(ByVal wrklistno As Integer, ByVal Wrkyear As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    StrSQL = "Delete from " & cFileName & " WHERE list# = " & wrklistno & " And year = " & Wrkyear

    RecordNotFound = False
    IsEOF = False
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    Result = objCommand.ExecuteNonQuery()
    objCommand = Nothing
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
  _LISTNO   = .Item("LIST#")
  _YEAR     = .Item("YEAR")
  _SEQNO    = .Item("SEQNO")
  _NAME     = .Item("NAME")
  _ADDR     = .Item("ADDR")
  _PHYLOC   = .Item("PHYLOC")
  _DESC     = .Item("DESC")
  _MFG      = .Item("MFG")
  _ACQDT    = .Item("ACQDT")
  _PRICE    = .Item("PRICE")
  _PURCH    = .Item("PURCH")
  _PURFRM   = .Item("PURFRM")
  _PURDT    = .Item("PURDT")
  _TRAN     = .Item("TRAN")
  _LESTYP   = .Item("LESTYP")
  _TERM     = .Item("TERM")
  _RENT     = .Item("RENT")
  _COSTS    = .Item("COSTS")
  _NEWMFG   = .Item("NEWMFG")
  _NEWTYP   = .Item("NEWTYP")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("LIST#") =   _LISTNO  
.Item("YEAR") =   _YEAR    
.Item("SEQNO") =   _SEQNO   
.Item("NAME") =   _NAME    
.Item("ADDR") =   _ADDR    
.Item("PHYLOC") =   _PHYLOC  
.Item("DESC") =   _DESC    
.Item("MFG") =   _MFG     
.Item("ACQDT") =   _ACQDT   
.Item("PRICE") =   _PRICE   
.Item("PURCH") =   _PURCH   
.Item("PURFRM") =   _PURFRM  
.Item("PURDT") =   _PURDT   
.Item("TRAN") =   _TRAN    
.Item("LESTYP") =   _LESTYP  
.Item("TERM") =   _TERM    
.Item("RENT") =   _RENT    
.Item("COSTS") =   _COSTS   
.Item("NEWMFG") =   _NEWMFG  
.Item("NEWTYP") =   _NEWTYP  

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

Dim mSEQNO  as integer 
Public Property _SEQNO  as integer   
    Get
        Return mSEQNO
    End Get
    set(byval value as integer)
        mSEQNO = value
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

Dim mPHYLOC as string 
Public Property _PHYLOC as string   
    Get
        Return mPHYLOC
    End Get
    set(byval value as string)
        mPHYLOC = value
    End Set
End Property

Dim mDESC as string 
Public Property _DESC as string   
    Get
        Return mDESC
    End Get
    set(byval value as string)
        mDESC = value
    End Set
End Property

Dim mMFG as string 
Public Property _MFG as string   
    Get
        Return mMFG
    End Get
    set(byval value as string)
        mMFG = value
    End Set
End Property

Dim mACQDT  as integer 
Public Property _ACQDT  as integer   
    Get
        Return mACQDT
    End Get
    set(byval value as integer)
        mACQDT = value
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

Dim mPURCH as string 
Public Property _PURCH as string   
    Get
        Return mPURCH
    End Get
    set(byval value as string)
        mPURCH = value
    End Set
End Property

Dim mPURFRM as string 
Public Property _PURFRM as string   
    Get
        Return mPURFRM
    End Get
    set(byval value as string)
        mPURFRM = value
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

Dim mTRAN as string 
Public Property _TRAN as string   
    Get
        Return mTRAN
    End Get
    set(byval value as string)
        mTRAN = value
    End Set
End Property

Dim mLESTYP as string 
Public Property _LESTYP as string   
    Get
        Return mLESTYP
    End Get
    set(byval value as string)
        mLESTYP = value
    End Set
End Property

Dim mTERM as string 
Public Property _TERM as string   
    Get
        Return mTERM
    End Get
    set(byval value as string)
        mTERM = value
    End Set
End Property

Dim mRENT  as long
Public Property _RENT  as long  
    Get
        Return mRENT
    End Get
    set(byval value as long)
        mRENT = value
    End Set
End Property

Dim mCOSTS  as long
Public Property _COSTS  as long  
    Get
        Return mCOSTS
    End Get
    set(byval value as long)
        mCOSTS = value
    End Set
End Property

Dim mNEWMFG as string 
Public Property _NEWMFG as string   
    Get
        Return mNEWMFG
    End Get
    set(byval value as string)
        mNEWMFG = value
    End Set
End Property

Dim mNEWTYP as string 
Public Property _NEWTYP as string   
    Get
        Return mNEWTYP
    End Get
    set(byval value as string)
        mNEWTYP = value
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


