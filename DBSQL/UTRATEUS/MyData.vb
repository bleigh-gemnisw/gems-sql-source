Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "UTRATEUS"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_RUTYPE = string.empty
_RUCODE = string.empty
_RUDESC = string.empty
_RUBASE = 0
_RUUNIT = 0
_RUEDU = 0
_RUFIXT = 0
_RUXTRA = 0
_RUPCT = 0

End Sub
  Public Sub GetOneRecordP(ByVal Wrkrutype As string, ByVal Wrkrucode As string)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where rutype = " & "'" & Wrkrutype & "'" & " and rucode = " & "'" & Wrkrucode & "'"
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
    ds = PosData("", "")
    Return ds
  End Function
  Public Function GetAllType(ByVal WrkType As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where rutype='" & WrkType & "'"
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
  Public Function PosData(ByVal Wrkrutype As String, ByVal Wrkrucode As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where rutype = " & "'" & Wrkrutype & "'" & " And rucode >= " & "'" & Wrkrucode & "'" & " Or rutype > " & "'" & Wrkrutype & "'" & " Order by rutype, rucode"
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
  _RUTYPE   = .Item("RUTYPE")
  _RUCODE   = .Item("RUCODE")
  _RUDESC   = .Item("RUDESC")
  _RUBASE   = .Item("RUBASE")
  _RUUNIT   = .Item("RUUNIT")
  _RUEDU    = .Item("RUEDU")
  _RUFIXT   = .Item("RUFIXT")
  _RUXTRA   = .Item("RUXTRA")
  _RUPCT    = .Item("RUPCT")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("RUTYPE") =   _RUTYPE  
.Item("RUCODE") =   _RUCODE  
.Item("RUDESC") =   _RUDESC  
.Item("RUBASE") =   _RUBASE  
.Item("RUUNIT") =   _RUUNIT  
.Item("RUEDU") =   _RUEDU   
.Item("RUFIXT") =   _RUFIXT  
.Item("RUXTRA") =   _RUXTRA  
.Item("RUPCT") =   _RUPCT   

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mRUTYPE as string 
Public Property _RUTYPE as string   
    Get
        Return mRUTYPE
    End Get
    set(byval value as string)
        mRUTYPE = value
    End Set
End Property

Dim mRUCODE as string 
Public Property _RUCODE as string   
    Get
        Return mRUCODE
    End Get
    set(byval value as string)
        mRUCODE = value
    End Set
End Property

Dim mRUDESC as string 
Public Property _RUDESC as string   
    Get
        Return mRUDESC
    End Get
    set(byval value as string)
        mRUDESC = value
    End Set
End Property

  Dim mRUBASE As Decimal
  Public Property _RUBASE As Decimal
    Get
      Return mRUBASE
    End Get
    Set(ByVal value As Decimal)
      mRUBASE = value
    End Set
  End Property

  Dim mRUUNIT As Decimal
  Public Property _RUUNIT As Decimal
    Get
      Return mRUUNIT
    End Get
    Set(ByVal value As Decimal)
      mRUUNIT = value
    End Set
  End Property

  Dim mRUEDU As Decimal
  Public Property _RUEDU As Decimal
    Get
      Return mRUEDU
    End Get
    Set(ByVal value As Decimal)
      mRUEDU = value
    End Set
  End Property

  Dim mRUFIXT As Decimal
  Public Property _RUFIXT As Decimal
    Get
      Return mRUFIXT
    End Get
    Set(ByVal value As Decimal)
      mRUFIXT = value
    End Set
  End Property

  Dim mRUXTRA As Decimal
  Public Property _RUXTRA As Decimal
    Get
      Return mRUXTRA
    End Get
    Set(ByVal value As Decimal)
      mRUXTRA = value
    End Set
  End Property

  Dim mRUPCT As Decimal
  Public Property _RUPCT As Decimal
    Get
      Return mRUPCT
    End Get
    Set(ByVal value As Decimal)
      mRUPCT = value
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


