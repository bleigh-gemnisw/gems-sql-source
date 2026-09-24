Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "UTRATEMT"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_RMTYPE = string.empty
_RMCODE = string.empty
_RMTIER  = 0
_RMDESC = string.empty
_RMRATE = 0

End Sub
  Public Sub GetOneRecordP(ByVal Wrkrmtype As string, ByVal Wrkrmcode As string, ByVal Wrkrmtier As integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where rmtype = " & "'" & Wrkrmtype & "'" & " and rmcode = " & "'" & Wrkrmcode & "'" & " and rmtier = " & Wrkrmtier
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
    ds = PosData("", "", 0)
    Return ds
  End Function
  Public Function GetAllCode(ByVal WrkType As String, ByVal WrkCode As String, ByVal NumRecs As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & " * from " & cFileName & " where rmtype='" & WrkType & "' and rmcode = '" & WrkCode & "'"
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
  Public Function GetAllType(ByVal WrkType As String, ByVal NumRecs As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    RecordNotFound = False
    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & "* from " & cFileName & " where rmtype='" & WrkType & "'"
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
  Public Function PosData(ByVal Wrkrmtype As String, ByVal Wrkrmcode As String, ByVal Wrkrmtier As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where rmtype = " & "'" & Wrkrmtype & "'" & " And rmcode = " & "'" & Wrkrmcode & "'" & " And rmtier >= " & Wrkrmtier & " Or rmtype = " & "'" & Wrkrmtype & "'" & " And rmcode > " & "'" & Wrkrmcode & "'" & " Or rmtype > " & "'" & Wrkrmtype & "'" & " Order by rmtype, rmcode, rmtier"
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
  _RMTYPE   = .Item("RMTYPE")
  _RMCODE   = .Item("RMCODE")
  _RMTIER   = .Item("RMTIER")
  _RMDESC   = .Item("RMDESC")
  _RMRATE   = .Item("RMRATE")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("RMTYPE") =   _RMTYPE  
.Item("RMCODE") =   _RMCODE  
.Item("RMTIER") =   _RMTIER  
.Item("RMDESC") =   _RMDESC  
.Item("RMRATE") =   _RMRATE  

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mRMTYPE as string 
Public Property _RMTYPE as string   
    Get
        Return mRMTYPE
    End Get
    set(byval value as string)
        mRMTYPE = value
    End Set
End Property

Dim mRMCODE as string 
Public Property _RMCODE as string   
    Get
        Return mRMCODE
    End Get
    set(byval value as string)
        mRMCODE = value
    End Set
End Property

Dim mRMTIER  as long
Public Property _RMTIER  as long  
    Get
        Return mRMTIER
    End Get
    set(byval value as long)
        mRMTIER = value
    End Set
End Property

Dim mRMDESC as string 
Public Property _RMDESC as string   
    Get
        Return mRMDESC
    End Get
    set(byval value as string)
        mRMDESC = value
    End Set
End Property

  Dim mRMRATE As Decimal
  Public Property _RMRATE As Decimal
    Get
      Return mRMRATE
    End Get
    Set(ByVal value As Decimal)
      mRMRATE = value
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


