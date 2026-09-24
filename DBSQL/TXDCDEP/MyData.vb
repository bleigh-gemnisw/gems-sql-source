Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXDCDEP"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_YEAR  = 0
_DECODE = string.empty
_YEARNO  = 0
_PROPCT  = 0
_PCT  = 0
_PRIOR = string.empty

End Sub
  Public Sub GetOneRecordP(ByVal Wrkyear As Integer, ByVal Wrkdecode As String, ByVal Wrkyearno As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where year = " & Wrkyear & " and decode = '" & Wrkdecode & "' and yearno = " & Wrkyearno
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
  Public Function PosData(ByVal Wrkyear As Integer, ByVal Wrkdecode As String, ByVal Wrkyearno As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where year = " & Wrkyear & " And yearno = " & Wrkyearno _
    & " And decode >= '" & Wrkdecode & "' Or year = " & Wrkyear & " And yearno > " & Wrkyearno & " Or year > " & Wrkyear & " Order by year, decode, yearno"
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
  Public Function GetAllYear(ByVal Wrkyear As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where year=" & Wrkyear
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
  _DECODE   = .Item("DECODE")
  _YEARNO   = .Item("YEARNO")
  _PROPCT   = .Item("PROPCT")
  _PCT      = .Item("PCT")
  _PRIOR    = .Item("PRIOR")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("YEAR") =   _YEAR    
.Item("DECODE") =   _DECODE  
.Item("YEARNO") =   _YEARNO  
.Item("PROPCT") =   _PROPCT  
.Item("PCT") =   _PCT     
.Item("PRIOR") =   _PRIOR   

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

Dim mDECODE as string 
Public Property _DECODE as string   
    Get
        Return mDECODE
    End Get
    set(byval value as string)
        mDECODE = value
    End Set
End Property

Dim mYEARNO  as integer 
Public Property _YEARNO  as integer   
    Get
        Return mYEARNO
    End Get
    set(byval value as integer)
        mYEARNO = value
    End Set
End Property

Dim mPROPCT  as integer 
Public Property _PROPCT  as integer   
    Get
        Return mPROPCT
    End Get
    set(byval value as integer)
        mPROPCT = value
    End Set
End Property

Dim mPCT  as integer 
Public Property _PCT  as integer   
    Get
        Return mPCT
    End Get
    set(byval value as integer)
        mPCT = value
    End Set
End Property

Dim mPRIOR as string 
Public Property _PRIOR as string   
    Get
        Return mPRIOR 
    End Get
    set(byval value as string)
        mPRIOR = value
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


