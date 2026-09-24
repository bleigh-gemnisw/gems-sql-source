Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXSUPCD"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_SCOD = string.empty
_FILL1 = string.empty
_SPCT = 0
_FILL3 = string.empty
_SMON = string.empty
_SCRD = string.empty

End Sub
  Public Sub GetOneRecordP(ByVal Wrkscod As string)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where scod = " & "'" & Wrkscod & "'"
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
  Public Function PosData(ByVal Wrkscod As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where scod >= " & "'" & Wrkscod & "'" & " Order by scod"
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
  _SCOD    = .Item("SCOD")
  _FILL1   = .Item("FILL1")
  _SPCT    = .Item("SPCT")
  _FILL3   = .Item("FILL3")
  _SMON    = .Item("SMON")
  _SCRD    = .Item("SCRD")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("SCOD") =   _SCOD   
.Item("FILL1") =   _FILL1  
.Item("SPCT") =   _SPCT   
.Item("FILL3") =   _FILL3  
.Item("SMON") =   _SMON   
.Item("SCRD") =   _SCRD   

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mSCOD as string 
Public Property _SCOD as string   
    Get
        Return mSCOD
    End Get
    set(byval value as string)
        mSCOD = value
    End Set
End Property

Dim mFILL1 as string 
Public Property _FILL1 as string   
    Get
        Return mFILL1
    End Get
    set(byval value as string)
        mFILL1 = value
    End Set
End Property

Dim mSPCT as decimal
Public Property _SPCT as decimal
    Get
        Return mSPCT
    End Get
    Set(ByVal value As Decimal)
      mSPCT = value
    End Set
  End Property

Dim mFILL3 as string 
Public Property _FILL3 as string   
    Get
        Return mFILL3
    End Get
    set(byval value as string)
        mFILL3 = value
    End Set
End Property

Dim mSMON as string 
Public Property _SMON as string   
    Get
        Return mSMON
    End Get
    set(byval value as string)
        mSMON = value
    End Set
End Property

Dim mSCRD as string 
Public Property _SCRD as string   
    Get
        Return mSCRD
    End Get
    set(byval value as string)
        mSCRD = value
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


