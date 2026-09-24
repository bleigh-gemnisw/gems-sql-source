Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXDCLEE"
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
_LESNO = string.empty
_DESC = string.empty
_SERIAL = string.empty
_YRMFG  = 0
_CAPLES = string.empty
_TERM = string.empty
_RENT  = 0
_COST  = 0
_YRINC  = 0
_DSPITM = string.empty
_ACQITM = string.empty

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
  _LESNO    = .Item("LESNO")
  _DESC     = .Item("DESC")
  _SERIAL   = .Item("SERIAL")
  _YRMFG    = .Item("YRMFG")
  _CAPLES   = .Item("CAPLES")
  _TERM     = .Item("TERM")
  _RENT     = .Item("RENT")
  _COST     = .Item("COST")
  _YRINC    = .Item("YRINC")
  _DSPITM   = .Item("DSPITM")
  _ACQITM   = .Item("ACQITM")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("LIST#") =   _LISTNO  
.Item("YEAR") =   _YEAR    
.Item("SEQNO") =   _SEQNO   
.Item("NAME") =   _NAME    
.Item("ADDR") =   _ADDR    
.Item("LESNO") =   _LESNO   
.Item("DESC") =   _DESC    
.Item("SERIAL") =   _SERIAL  
.Item("YRMFG") =   _YRMFG   
.Item("CAPLES") =   _CAPLES  
.Item("TERM") =   _TERM    
.Item("RENT") =   _RENT    
.Item("COST") =   _COST    
.Item("YRINC") =   _YRINC   
.Item("DSPITM") =   _DSPITM  
.Item("ACQITM") =   _ACQITM  

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

Dim mLESNO as string 
Public Property _LESNO as string   
    Get
        Return mLESNO
    End Get
    set(byval value as string)
        mLESNO = value
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

Dim mSERIAL as string 
Public Property _SERIAL as string   
    Get
        Return mSERIAL
    End Get
    set(byval value as string)
        mSERIAL = value
    End Set
End Property

Dim mYRMFG  as integer 
Public Property _YRMFG  as integer   
    Get
        Return mYRMFG
    End Get
    set(byval value as integer)
        mYRMFG = value
    End Set
End Property

Dim mCAPLES as string 
Public Property _CAPLES as string   
    Get
        Return mCAPLES
    End Get
    set(byval value as string)
        mCAPLES = value
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

Dim mCOST  as long
Public Property _COST  as long  
    Get
        Return mCOST
    End Get
    set(byval value as long)
        mCOST = value
    End Set
End Property

Dim mYRINC  as integer 
Public Property _YRINC  as integer   
    Get
        Return mYRINC
    End Get
    set(byval value as integer)
        mYRINC = value
    End Set
End Property

Dim mDSPITM as string 
Public Property _DSPITM as string   
    Get
        Return mDSPITM
    End Get
    set(byval value as string)
        mDSPITM = value
    End Set
End Property

Dim mACQITM as string 
Public Property _ACQITM as string   
    Get
        Return mACQITM
    End Get
    set(byval value as string)
        mACQITM = value
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


