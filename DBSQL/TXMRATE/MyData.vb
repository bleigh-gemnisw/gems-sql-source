Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXMRATE"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_YEAR  = 0
_TYPE = string.empty
_DIST  = 0
_MRDESC = string.empty
_MRRATE = 0
_MRFIRE = 0

End Sub
  Public Sub GetOneRecordP(ByVal Wrkyear As integer, ByVal Wrktype As string, ByVal Wrkdist As integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where year = " & Wrkyear & " and type = " & "'" & Wrktype & "'" & " and dist = " & Wrkdist
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
Public Function PosData(ByVal Wrkyear As integer, ByVal Wrktype As string, ByVal Wrkdist As integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where year = " & Wrkyear & " And type = " & "'" & Wrktype & "'" & " And dist >= " & Wrkdist & " Or year = " & Wrkyear & " And type > " & "'" & Wrktype & "'" & " Or year > " & Wrkyear & " Order by year, type, dist"
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
  _YEAR     = .Item("YEAR")
  _DIST     = .Item("DIST")
  _TYPE     = .Item("TYPE")
  _MRDESC   = .Item("MRDESC")
  _MRRATE   = .Item("MRRATE")
  _MRFIRE   = .Item("MRFIRE")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("YEAR") =   _YEAR    
.Item("DIST") =   _DIST    
.Item("TYPE") =   _TYPE    
.Item("MRDESC") =   _MRDESC  
.Item("MRRATE") =   _MRRATE  
.Item("MRFIRE") =   _MRFIRE  

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mYEAR  as integer 
Public Property _YEAR  as integer   
    Get
        Return mYEAR
    End Get
    set(byval value as integer)
        mYEAR = value
    End Set
End Property

Dim mTYPE as string 
Public Property _TYPE as string   
    Get
        Return mTYPE
    End Get
    set(byval value as string)
        mTYPE = value
    End Set
End Property

Dim mDIST  as integer 
Public Property _DIST  as integer   
    Get
        Return mDIST
    End Get
    set(byval value as integer)
        mDIST = value
    End Set
End Property

Dim mMRDESC as string 
Public Property _MRDESC as string   
    Get
        Return mMRDESC
    End Get
    set(byval value as string)
        mMRDESC = value
    End Set
End Property

Dim mMRRATE as decimal
Public Property _MRRATE as decimal
    Get
        Return mMRRATE
    End Get
    Set(ByVal value As Decimal)
      mMRRATE = value
    End Set
  End Property

  Dim mMRFIRE As Decimal
  Public Property _MRFIRE As Decimal
    Get
      Return mMRFIRE
    End Get
    Set(ByVal value As Decimal)
      mMRFIRE = value
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


