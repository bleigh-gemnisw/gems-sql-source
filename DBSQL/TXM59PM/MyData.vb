Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXM59PM"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_LISTNO  = 0
_TYPE = string.empty
_YEAR  = 0
_LOCPM = string.empty
_ALLOW = string.empty
_DISRSN = string.empty
_DTASSR  = 0

End Sub
  Public Sub GetOneRecordP(ByVal Wrklistno As Integer, ByVal Wrktype As String, ByVal Wrkyear As Integer, ByVal Wrklocpm As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " and type = " & "'" & Wrktype & "'" & " and year = " & Wrkyear & " and locpm = " & "'" & Wrklocpm & "'" & " and list# = " & Wrklistno & " and type = " & "'" & Wrktype & "'" & " and year = " & Wrkyear
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
  Public Function PosData(ByVal Wrklistno As Integer, ByVal Wrktype As String, ByVal Wrkyear As Integer, ByVal Wrklocpm As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " And type = " & "'" & Wrktype & "'" &
     " And year = " & Wrkyear & " And locpm >= " & "'" & Wrklocpm & "'" &
     " or list# = " & Wrklistno & " And type = " & "'" & Wrktype & "'" & " And year > " & Wrkyear &
     " or list# = " & Wrklistno & " And type = " & "'" & Wrktype & "'" &
     " or list# > " & Wrklistno & " Order by list#, type, year, locpm"
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
  Public Function GetbyList(ByVal Wrklistno As Integer, wrktype As String, wrkyear As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String


    RecordNotFound = False


    StrSQL = "Select  list#,type,year,locpm,allow,disrsn,dtassr From " & cFileName _
    & " where list# =" & Wrklistno & " AND type = '" & wrktype & "' AND YEAR =" & wrkyear & " order by list#,type,year"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      objCommand = Nothing
      Conn.Close()
      Return ds
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
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
  _LISTNO   = .Item("LIST#")
  _TYPE     = .Item("TYPE")
  _YEAR     = .Item("YEAR")
  _LOCPM    = .Item("LOCPM")
  _ALLOW    = .Item("ALLOW")
  _DISRSN   = .Item("DISRSN")
  _DTASSR   = .Item("DTASSR")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("LIST#") =   _LISTNO  
.Item("TYPE") =   _TYPE    
.Item("YEAR") =   _YEAR    
.Item("LOCPM") =   _LOCPM   
.Item("ALLOW") =   _ALLOW   
.Item("DISRSN") =   _DISRSN  
.Item("DTASSR") =   _DTASSR  

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

Dim mYEAR  as integer 
Public Property _YEAR  as integer   
    Get
        Return mYEAR
    End Get
    set(byval value as integer)
        mYEAR = value
    End Set
End Property

Dim mLOCPM as string 
Public Property _LOCPM as string   
    Get
        Return mLOCPM
    End Get
    set(byval value as string)
        mLOCPM = value
    End Set
End Property

Dim mALLOW as string 
Public Property _ALLOW as string   
    Get
        Return mALLOW
    End Get
    set(byval value as string)
        mALLOW = value
    End Set
End Property

Dim mDISRSN as string 
Public Property _DISRSN as string   
    Get
        Return mDISRSN
    End Get
    set(byval value as string)
        mDISRSN = value
    End Set
End Property

Dim mDTASSR  as integer 
Public Property _DTASSR  as integer   
    Get
        Return mDTASSR
    End Get
    set(byval value as integer)
        mDTASSR = value
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


