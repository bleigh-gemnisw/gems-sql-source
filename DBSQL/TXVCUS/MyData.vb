Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXVCUS"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_CUSTID  = 0
_NAME = string.empty
_BUS = string.empty
_ADD1 = string.empty
_ADD2 = string.empty
_CITY = string.empty
_STATE = string.empty
_ZIPA = string.empty
_DOB  = 0
_SEX = string.empty
_RADD1 = string.empty
_RADD2 = string.empty
_RCITY = string.empty
_RSTATE = string.empty
_RZIPA = string.empty
_CONFID = string.empty
_CHDATE  = 0

End Sub
  Public Sub GetOneRecordP(ByVal Wrkcustid As integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where custid = " & Wrkcustid
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
Public Function PosData(ByVal Wrkcustid As integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where custid >= " & Wrkcustid & " Order by custid"
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
  _CUSTID   = .Item("CUSTID")
  _NAME     = .Item("NAME")
  _BUS      = .Item("BUS")
  _ADD1     = .Item("ADD1")
  _ADD2     = .Item("ADD2")
  _CITY     = .Item("CITY")
  _STATE    = .Item("STATE")
  _ZIPA     = .Item("ZIPA")
  _DOB      = .Item("DOB")
  _SEX      = .Item("SEX")
  _RADD1    = .Item("RADD1")
  _RADD2    = .Item("RADD2")
  _RCITY    = .Item("RCITY")
  _RSTATE   = .Item("RSTATE")
  _RZIPA    = .Item("RZIPA")
  _CONFID   = .Item("CONFID")
  _CHDATE   = .Item("CHDATE")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("CUSTID") =   _CUSTID  
.Item("NAME") =   _NAME    
.Item("BUS") =   _BUS     
.Item("ADD1") =   _ADD1    
.Item("ADD2") =   _ADD2    
.Item("CITY") =   _CITY    
.Item("STATE") =   _STATE   
.Item("ZIPA") =   _ZIPA    
.Item("DOB") =   _DOB     
.Item("SEX") =   _SEX     
.Item("RADD1") =   _RADD1   
.Item("RADD2") =   _RADD2   
.Item("RCITY") =   _RCITY   
.Item("RSTATE") =   _RSTATE  
.Item("RZIPA") =   _RZIPA   
.Item("CONFID") =   _CONFID  
.Item("CHDATE") =   _CHDATE  

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mCUSTID  as long
Public Property _CUSTID  as long  
    Get
        Return mCUSTID
    End Get
    set(byval value as long)
        mCUSTID = value
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

Dim mBUS as string 
Public Property _BUS as string   
    Get
        Return mBUS
    End Get
    set(byval value as string)
        mBUS = value
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

Dim mZIPA as string 
Public Property _ZIPA as string   
    Get
        Return mZIPA
    End Get
    set(byval value as string)
        mZIPA = value
    End Set
End Property

Dim mDOB  as integer 
Public Property _DOB  as integer   
    Get
        Return mDOB
    End Get
    set(byval value as integer)
        mDOB = value
    End Set
End Property

Dim mSEX as string 
Public Property _SEX as string   
    Get
        Return mSEX
    End Get
    set(byval value as string)
        mSEX = value
    End Set
End Property

Dim mRADD1 as string 
Public Property _RADD1 as string   
    Get
        Return mRADD1
    End Get
    set(byval value as string)
        mRADD1 = value
    End Set
End Property

Dim mRADD2 as string 
Public Property _RADD2 as string   
    Get
        Return mRADD2
    End Get
    set(byval value as string)
        mRADD2 = value
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

Dim mRZIPA as string 
Public Property _RZIPA as string   
    Get
        Return mRZIPA
    End Get
    set(byval value as string)
        mRZIPA = value
    End Set
End Property

Dim mCONFID as string 
Public Property _CONFID as string   
    Get
        Return mCONFID
    End Get
    set(byval value as string)
        mCONFID = value
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


