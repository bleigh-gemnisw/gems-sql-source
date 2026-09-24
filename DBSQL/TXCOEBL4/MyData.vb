
Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXCOEB"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Function GetViewbyList(ByVal ListNo As Integer, ByVal Year As Integer, ByVal Type As String, ByVal NumRecs As Integer) As DataSet
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
    StrSQL = "Select " & WrkTop & " ccno,cyear,list#,ctype,name,cdate,rsncd,cgrs,ntnet from " & cFileName _
    & " where list# = " & ListNo & " AND cyear = " & Year & " AND ctype = '" & Type & "' order by list#,cyear,ctype,chdate,chtime"

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
  Public Function GetViewDescList(ByVal ListNo As Integer, ByVal Year As Integer,
 ByVal Type As String, ByVal pDate As Integer, pTime As Integer, ByVal NumRecs As Integer) As DataSet

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
    StrSQL = "Select " & WrkTop & " ccno,cyear,list#,ctype,name,cdate,rsncd,cgrs,ntnet from " & cFileName _
    & " where list#=" & ListNo & " and ctype='" & Type & "' and cyear=" & Year & " and chdate=" & pDate & " and chtime<=" & pTime _
    & " or list#=" & ListNo & " and ctype='" & Type & "' and cyear=" & Year & " and chdate<" & pDate _
    & " order by chdate desc,chtime desc"

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
  Public Function GetDescList(ByVal ListNo As Integer, ByVal Year As Integer,
 ByVal Type As String, ByVal pDate As Integer, pTime As Integer, ByVal NumRecs As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    RecordNotFound = False
    StrSQL = "Select " & WrkTop & "* from " & cFileName _
    & " where list#=" & ListNo & " and ctype='" & Type & "' and cyear=" & Year & " and chdate=" & pDate & " and chtime<=" & pTime _
    & " or list#=" & ListNo & " and ctype='" & Type & "' and cyear=" & Year & " and chdate<" & pDate _
    & " order by chdate desc,chtime desc"

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
  Public Function GetLastbyDate(ByVal ListNo As Integer, ByVal Year As Integer,
 ByVal Type As String, ByVal PDate As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select top 1 * from " & cFileName _
    & " where list#=" & ListNo & " and ctype='" & Type & "' and cyear=" & Year & " and chdate<=" & PDate &
    " order by chdate desc,chtime desc"
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
  Public Function ReplaceDS(ByVal ds As DataSet) As DataSet
    Dim ds2 As DataSet = New DataSet
    Dim dr As DataRow
    Dim myTable As New DataTable
    Dim I As Integer

    With myTable
      .TableName = "mytable" 'ds.Tables(0).TableName
      .Columns.Add("ccno", Type.GetType("System.Int32"))
      .Columns.Add("cyear", Type.GetType("System.Int32"))
      .Columns.Add("list#", Type.GetType("System.Int32"))
      .Columns.Add("ctype", Type.GetType("System.String"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("cdate", Type.GetType("System.Int32"))
      .Columns.Add("wkdate", Type.GetType("System.Int32"))
      .Columns.Add("rsncd", Type.GetType("System.String"))
      .Columns.Add("cgrs", Type.GetType("System.Int32"))
      .Columns.Add("ntnet", Type.GetType("System.Int32"))

    End With
    ds2.Tables.Add(myTable)

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        dr = ds2.Tables(0).NewRow
        dr.Item("ccno") = .Item("ccno")
        dr.Item("cyear") = .Item("cyear")
        dr.Item("list#") = .Item("list#")
        dr.Item("ctype") = .Item("ctype")
        dr.Item("name") = .Item("name")
        dr.Item("cdate") = .Item("cdate")
        dr.Item("wkdate") = GetDBDateInt(.Item("cdate"))
        dr.Item("rsncd") = .Item("rsncd")
        dr.Item("cgrs") = .Item("cgrs")
        dr.Item("ntnet") = .Item("ntnet")
        ds2.Tables(0).Rows.Add(dr)
      End With
    Next

    Return ds2
  End Function
  Public Function GetDBDateInt(ByVal DateIn As Integer) As Integer
    Dim WrkDate As Integer
    Dim StrDate As String

    If DateIn > 0 Then
      StrDate = Trim$(Str(DateIn))
      Try
        WrkDate = Right$(StrDate, 4) & Left$(StrDate, 4)
      Catch
      End Try
    End If
    Return WrkDate
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

