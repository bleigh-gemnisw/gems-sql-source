Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXENDRS"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_TYPE = string.empty
_EL1 = string.empty
_EL2 = string.empty
_EL3 = string.empty
_EL4 = string.empty
_EL5 = string.empty
_EL6 = string.empty
_EL7 = string.empty
_EL8 = string.empty

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
  _TYPE   = .Item("TYPE")
  _EL1    = .Item("EL1")
  _EL2    = .Item("EL2")
  _EL3    = .Item("EL3")
  _EL4    = .Item("EL4")
  _EL5    = .Item("EL5")
  _EL6    = .Item("EL6")
  _EL7    = .Item("EL7")
  _EL8    = .Item("EL8")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("TYPE") =   _TYPE  
.Item("EL1") =   _EL1   
.Item("EL2") =   _EL2   
.Item("EL3") =   _EL3   
.Item("EL4") =   _EL4   
.Item("EL5") =   _EL5   
.Item("EL6") =   _EL6   
.Item("EL7") =   _EL7   
.Item("EL8") =   _EL8   

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

Dim mEL1 as string 
Public Property _EL1 as string   
    Get
        Return mEL1
    End Get
    set(byval value as string)
        mEL1 = value
    End Set
End Property

Dim mEL2 as string 
Public Property _EL2 as string   
    Get
        Return mEL2
    End Get
    set(byval value as string)
        mEL2 = value
    End Set
End Property

Dim mEL3 as string 
Public Property _EL3 as string   
    Get
        Return mEL3
    End Get
    set(byval value as string)
        mEL3 = value
    End Set
End Property

Dim mEL4 as string 
Public Property _EL4 as string   
    Get
        Return mEL4
    End Get
    set(byval value as string)
        mEL4 = value
    End Set
End Property

Dim mEL5 as string 
Public Property _EL5 as string   
    Get
        Return mEL5
    End Get
    set(byval value as string)
        mEL5 = value
    End Set
End Property

Dim mEL6 as string 
Public Property _EL6 as string   
    Get
        Return mEL6
    End Get
    set(byval value as string)
        mEL6 = value
    End Set
End Property

Dim mEL7 as string 
Public Property _EL7 as string   
    Get
        Return mEL7
    End Get
    set(byval value as string)
        mEL7 = value
    End Set
End Property

Dim mEL8 as string 
Public Property _EL8 as string   
    Get
        Return mEL8
    End Get
    set(byval value as string)
        mEL8 = value
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


