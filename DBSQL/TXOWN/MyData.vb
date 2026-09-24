Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXOWN"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_OID = string.empty
_NAME = string.empty
_SNAME = string.empty
_ADD1 = string.empty
_ADD2 = string.empty
_CITY = string.empty
_STATE = string.empty
_ZIP5  = 0
_ZIP4  = 0
_SSNo  = 0
_SS2  = 0
_TIN = string.empty
_TEL  = 0
_DOB  = 0
_COMT = string.empty

End Sub
  Public Sub GetOneRecordP(ByVal Wrkoid As string)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where oid = " & "'" & Wrkoid & "'"
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
  Public Function GetAllData() As DataSet
    Dim ds As DataSet = New DataSet
    ds = PosData("")
    Return ds
  End Function
  Public Function PosData(ByVal Wrkoid As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where oid >= " & "'" & Wrkoid & "'" & " Order by oid"
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
  _OID     = .Item("OID")
  _NAME    = .Item("NAME")
  _SNAME   = .Item("SNAME")
  _ADD1    = .Item("ADD1")
  _ADD2    = .Item("ADD2")
  _CITY    = .Item("CITY")
  _STATE   = .Item("STATE")
  _ZIP5    = .Item("ZIP5")
  _ZIP4    = .Item("ZIP4")
  _SSNo    = .Item("SS#")
  _SS2     = .Item("SS2")
  _TIN     = .Item("TIN")
  _TEL     = .Item("TEL")
  _DOB     = .Item("DOB")
  _COMT    = .Item("COMT")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("OID") =   _OID    
.Item("NAME") =   _NAME   
.Item("SNAME") =   _SNAME  
.Item("ADD1") =   _ADD1   
.Item("ADD2") =   _ADD2   
.Item("CITY") =   _CITY   
.Item("STATE") =   _STATE  
.Item("ZIP5") =   _ZIP5   
.Item("ZIP4") =   _ZIP4   
.Item("SS#") =   _SSNo   
.Item("SS2") =   _SS2    
.Item("TIN") =   _TIN    
.Item("TEL") =   _TEL    
.Item("DOB") =   _DOB    
.Item("COMT") =   _COMT   

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mOID as string 
Public Property _OID as string   
    Get
        Return mOID
    End Get
    set(byval value as string)
        mOID = value
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

Dim mTIN as string 
Public Property _TIN as string   
    Get
        Return mTIN
    End Get
    set(byval value as string)
        mTIN = value
    End Set
End Property

Dim mTEL  as integer
Public Property _TEL  as integer
    Get
        Return mTEL
    End Get
    set(byval value as integer)
        mTEL = value
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

Dim mCOMT as string 
Public Property _COMT as string   
    Get
        Return mCOMT
    End Get
    set(byval value as string)
        mCOMT = value
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


