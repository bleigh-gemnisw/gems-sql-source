Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXBTRC"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_LISTNO  = 0
_TYPE = string.empty
_BASS1  = 0
_BASS2  = 0
_BASS3  = 0
_BASS4  = 0
_BASS5  = 0
_BASS6  = 0
_BASS7  = 0
_BASS8  = 0
_BASS9  = 0
_BASSA  = 0

End Sub
  Public Sub GetOneRecordP(ByVal Wrklistno As integer, ByVal Wrktype As string)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " and type = " & "'" & Wrktype & "'"
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
Public Function PosData(ByVal Wrklistno As integer, ByVal Wrktype As string) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " And type >= " & "'" & Wrktype & "'" & " Or list# > " & Wrklistno & " Order by list#, type"
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
  _LISTNO  = .Item("LIST#")
  _TYPE    = .Item("TYPE")
  _BASS1   = .Item("BASS1")
  _BASS2   = .Item("BASS2")
  _BASS3   = .Item("BASS3")
  _BASS4   = .Item("BASS4")
  _BASS5   = .Item("BASS5")
  _BASS6   = .Item("BASS6")
  _BASS7   = .Item("BASS7")
  _BASS8   = .Item("BASS8")
  _BASS9   = .Item("BASS9")
  _BASSA   = .Item("BASSA")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("LIST#") =   _LISTNO 
.Item("TYPE") =   _TYPE   
.Item("BASS1") =   _BASS1  
.Item("BASS2") =   _BASS2  
.Item("BASS3") =   _BASS3  
.Item("BASS4") =   _BASS4  
.Item("BASS5") =   _BASS5  
.Item("BASS6") =   _BASS6  
.Item("BASS7") =   _BASS7  
.Item("BASS8") =   _BASS8  
.Item("BASS9") =   _BASS9  
.Item("BASSA") =   _BASSA  

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

Dim mTYPE as string 
Public Property _TYPE as string   
    Get
        Return mTYPE
    End Get
    set(byval value as string)
        mTYPE = value
    End Set
End Property

Dim mBASS1  as long
Public Property _BASS1  as long  
    Get
        Return mBASS1
    End Get
    set(byval value as long)
        mBASS1 = value
    End Set
End Property

Dim mBASS2  as long
Public Property _BASS2  as long  
    Get
        Return mBASS2
    End Get
    set(byval value as long)
        mBASS2 = value
    End Set
End Property

Dim mBASS3  as long
Public Property _BASS3  as long  
    Get
        Return mBASS3
    End Get
    set(byval value as long)
        mBASS3 = value
    End Set
End Property

Dim mBASS4  as long
Public Property _BASS4  as long  
    Get
        Return mBASS4
    End Get
    set(byval value as long)
        mBASS4 = value
    End Set
End Property

Dim mBASS5  as long
Public Property _BASS5  as long  
    Get
        Return mBASS5
    End Get
    set(byval value as long)
        mBASS5 = value
    End Set
End Property

Dim mBASS6  as long
Public Property _BASS6  as long  
    Get
        Return mBASS6
    End Get
    set(byval value as long)
        mBASS6 = value
    End Set
End Property

Dim mBASS7  as long
Public Property _BASS7  as long  
    Get
        Return mBASS7
    End Get
    set(byval value as long)
        mBASS7 = value
    End Set
End Property

Dim mBASS8  as long
Public Property _BASS8  as long  
    Get
        Return mBASS8
    End Get
    set(byval value as long)
        mBASS8 = value
    End Set
End Property

Dim mBASS9  as long
Public Property _BASS9  as long  
    Get
        Return mBASS9
    End Get
    set(byval value as long)
        mBASS9 = value
    End Set
End Property

Dim mBASSA  as long
Public Property _BASSA  as long  
    Get
        Return mBASSA
    End Get
    set(byval value as long)
        mBASSA = value
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


