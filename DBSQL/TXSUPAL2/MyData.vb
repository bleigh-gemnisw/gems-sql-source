
Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXSUPA"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Function GetViewbyName(ByVal WrkGLYear As Integer, ByVal WrkName As String, ByVal WrkList As Integer,
   ByVal NumRecs As Integer, SetBlocking As Boolean) As DataSet

    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String

    WrkTop = String.Empty
    RecordNotFound = False
    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & "list#,name,regno,make,year,model from " & cFileName _
    & " where txyear = " & WrkGLYear & " and name ='" & WrkName & "' and list# >" & WrkList _
    & " or txyear = " & WrkGLYear & " and name >'" & WrkName & "' order by name,add1,list#"

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
  Public Function GetViewbyNameScan(ByVal wrkyear As Integer, ByVal Wrkname As String, NumRecs As Integer, ByVal wrksetblocking As Boolean) As DataSet


    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String



    WrkTop = String.Empty

    RecordNotFound = False
    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & "list#,name,regno,make,year,model from " & cFileName _
    & " where txyear = " & wrkyear & " AND name LIKE '%" & Wrkname & "%' order by name,add1,list#"

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
  Public Function GetViewDOB(ByVal wrkyear As Integer, ByVal Wrkdob As Integer) As DataSet


    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet


    RecordNotFound = False

    StrSQL = "Select list#,name,regno,make,year,model from " & cFileName _
    & " where txyear = " & wrkyear & " AND dob = " & Wrkdob & " order by name,add1,list#"

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
  Public Function GetViewgrid(ByVal Wrkname As String, NumRecs As Integer) As DataSet

    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    RecordNotFound = False
    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & " list#,name,make,year,model,sname from " & cFileName _
    & " where name >= '" & Wrkname & "' order by name,list#"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      ds2 = ReplaceDS(ds)
      ds = Nothing
      objCommand = Nothing
      Conn.Close()
      Return ds2
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function

  Public Function ReplaceDS(ByVal ds As DataSet) As DataSet
    Dim ds2 As DataSet = New DataSet
    Dim dr As DataRow
    Dim myTable As New DataTable
    Dim I As Integer
    With myTable
      .TableName = "mytable" 'ds.Tables(0).TableName
      .Columns.Add("WSel", Type.GetType("System.Int32"))
      .Columns.Add("List#", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Make", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Model", Type.GetType("System.String"))
      .Columns.Add("Sname", Type.GetType("System.String"))
    End With
    ds2.Tables.Add(myTable)

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        dr = ds2.Tables(0).NewRow
        dr.Item("WSel") = 0
        dr.Item("list#") = .Item("list#")
        dr.Item("Name") = .Item("Name")
        dr.Item("Make") = .Item("Make")
        dr.Item("Year") = .Item("Year")
        dr.Item("Model") = .Item("Model")
        dr.Item("Sname") = .Item("Sname")
        ds2.Tables(0).Rows.Add(dr)
      End With
    Next

    Return ds2
  End Function
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
	End Sub
#End Region

#Region "Properties: Get/Put"
#End Region

#Region "Properties: Fields"
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

