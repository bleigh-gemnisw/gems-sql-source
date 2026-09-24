Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXLEASE"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_CODE = string.empty
_NAME = string.empty
_ADDR1 = string.empty
_ADDR2 = string.empty
_CITY = string.empty
_STATE = string.empty
_ZIPA = string.empty
_CONTACT = string.empty
_PHONE = string.empty

End Sub
  Public Sub GetOneRecordP(ByVal Wrkcode As string)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where code = " & "'" & Wrkcode & "'"
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
Public Function PosData(ByVal Wrkcode As string) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where code >= " & "'" & Wrkcode & "'" & " Order by code"
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
  _CODE      = .Item("CODE")
  _NAME      = .Item("NAME")
  _ADDR1     = .Item("ADDR1")
  _ADDR2     = .Item("ADDR2")
  _CITY      = .Item("CITY")
  _STATE     = .Item("STATE")
  _ZIPA      = .Item("ZIPA")
  _CONTACT   = .Item("CONTACT")
  _PHONE     = .Item("PHONE")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("CODE") =   _CODE     
.Item("NAME") =   _NAME     
.Item("ADDR1") =   _ADDR1    
.Item("ADDR2") =   _ADDR2    
.Item("CITY") =   _CITY     
.Item("STATE") =   _STATE    
.Item("ZIPA") =   _ZIPA     
.Item("CONTACT") =   _CONTACT  
.Item("PHONE") =   _PHONE    

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mCODE as string 
Public Property _CODE as string   
    Get
        Return mCODE
    End Get
    set(byval value as string)
        mCODE = value
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

Dim mADDR1 as string 
Public Property _ADDR1 as string   
    Get
        Return mADDR1
    End Get
    set(byval value as string)
        mADDR1 = value
    End Set
End Property

Dim mADDR2 as string 
Public Property _ADDR2 as string   
    Get
        Return mADDR2
    End Get
    set(byval value as string)
        mADDR2 = value
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

Dim mCONTACT as string 
Public Property _CONTACT as string   
    Get
        Return mCONTACT
    End Get
    set(byval value as string)
        mCONTACT = value
    End Set
End Property

Dim mPHONE as string 
Public Property _PHONE as string   
    Get
        Return mPHONE
    End Get
    set(byval value as string)
        mPHONE = value
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


