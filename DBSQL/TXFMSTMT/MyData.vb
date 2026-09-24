Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXFMSTMT"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_TYPE = string.empty
_PAYTO = string.empty
_LINE1 = string.empty
_LINE2 = string.empty
_LINE3 = string.empty
_LINE4 = string.empty
_LINE5 = string.empty
_TITLE = string.empty
_SIGNED = string.empty
_CLERK = string.empty
_TWNAME = string.empty
_STATE = string.empty

End Sub
  Public Sub GetOneRecordP(ByVal Wrktype As string)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where type = " & "'" & Wrktype & "'"
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
  Public Function PosData(ByVal Wrktype As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where type >= " & "'" & Wrktype & "'" & " Order by type"
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
  _TYPE     = .Item("TYPE")
  _PAYTO    = .Item("PAYTO")
  _LINE1    = .Item("LINE1")
  _LINE2    = .Item("LINE2")
  _LINE3    = .Item("LINE3")
  _LINE4    = .Item("LINE4")
  _LINE5    = .Item("LINE5")
  _TITLE    = .Item("TITLE")
  _SIGNED   = .Item("SIGNED")
  _CLERK    = .Item("CLERK")
  _TWNAME   = .Item("TWNAME")
  _STATE    = .Item("STATE")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("TYPE") =   _TYPE    
.Item("PAYTO") =   _PAYTO   
.Item("LINE1") =   _LINE1   
.Item("LINE2") =   _LINE2   
.Item("LINE3") =   _LINE3   
.Item("LINE4") =   _LINE4   
.Item("LINE5") =   _LINE5   
.Item("TITLE") =   _TITLE   
.Item("SIGNED") =   _SIGNED  
.Item("CLERK") =   _CLERK   
.Item("TWNAME") =   _TWNAME  
.Item("STATE") =   _STATE   

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mTYPE as string 
Public Property _TYPE as string   
    Get
        Return mTYPE
    End Get
    set(byval value as string)
        mTYPE = value
    End Set
End Property

Dim mPAYTO as string 
Public Property _PAYTO as string   
    Get
        Return mPAYTO
    End Get
    set(byval value as string)
        mPAYTO = value
    End Set
End Property

Dim mLINE1 as string 
Public Property _LINE1 as string   
    Get
        Return mLINE1
    End Get
    set(byval value as string)
        mLINE1 = value
    End Set
End Property

Dim mLINE2 as string 
Public Property _LINE2 as string   
    Get
        Return mLINE2
    End Get
    set(byval value as string)
        mLINE2 = value
    End Set
End Property

Dim mLINE3 as string 
Public Property _LINE3 as string   
    Get
        Return mLINE3
    End Get
    set(byval value as string)
        mLINE3 = value
    End Set
End Property

Dim mLINE4 as string 
Public Property _LINE4 as string   
    Get
        Return mLINE4
    End Get
    set(byval value as string)
        mLINE4 = value
    End Set
End Property

Dim mLINE5 as string 
Public Property _LINE5 as string   
    Get
        Return mLINE5
    End Get
    set(byval value as string)
        mLINE5 = value
    End Set
End Property

Dim mTITLE as string 
Public Property _TITLE as string   
    Get
        Return mTITLE
    End Get
    set(byval value as string)
        mTITLE = value
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

Dim mCLERK as string 
Public Property _CLERK as string   
    Get
        Return mCLERK
    End Get
    set(byval value as string)
        mCLERK = value
    End Set
End Property

Dim mTWNAME as string 
Public Property _TWNAME as string   
    Get
        Return mTWNAME
    End Get
    set(byval value as string)
        mTWNAME = value
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


