Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXINV"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Function GetViewbyList(ByVal WrkList As Integer, ByVal WrkType As String, ByVal NumRecs As Integer) As DataSet
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

    StrSQL = "Select " & WrkTop & "list#,year,type,name,add1,bald from " & cFileName _
    & " where list# =" & WrkList & " and type ='" & WrkType & "' and icode<>'I' and bald<>0" _
    & " order by list#,type,year"
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
      .Columns.Add("wsel", Type.GetType("System.Int32"))
      .Columns.Add("list#", Type.GetType("System.Int32"))
      .Columns.Add("type", Type.GetType("System.String"))
      .Columns.Add("year", Type.GetType("System.Int32"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("add1", Type.GetType("System.String"))
      .Columns.Add("wbal", Type.GetType("System.Decimal"))
    End With
    ds2.Tables.Add(myTable)

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        dr = ds2.Tables(0).NewRow
        dr.Item("wsel") = 0
        dr.Item("list#") = .Item("list#")
        dr.Item("type") = .Item("type")
        dr.Item("year") = .Item("year")
        dr.Item("name") = .Item("name")
        dr.Item("add1") = .Item("add1")
        dr.Item("wbal") = .Item("bald")
        ds2.Tables(0).Rows.Add(dr)
      End With
    Next

    Return ds2
  End Function
  Public Function GetViewbyList2(ByVal WrkList As Integer, ByVal WrkType As String, ByVal NumRecs As Integer) As DataSet
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

    StrSQL = "Select " & WrkTop & "list#,year,type,name,loc#,loc,ccno,ccetax,taxt,bondp,bald from " & cFileName _
    & " where list# =" & WrkList & " And type ='" & WrkType & "' and icode<>'I'" _
    & " order by list#,type"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      ds2 = ReplaceDS2(ds)
      ds = Nothing
      objCommand = Nothing
      Conn.Close()
      Return ds2
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function

  Public Function ReplaceDS2(ByVal ds As DataSet) As DataSet
    Dim ds2 As DataSet = New DataSet
    Dim dr As DataRow
    Dim myTable As New DataTable
    Dim I As Integer
    With myTable
      .TableName = "mytable" 'ds.Tables(0).TableName
      .Columns.Add("list#", Type.GetType("System.Int32"))
      .Columns.Add("type", Type.GetType("System.String"))
      .Columns.Add("year", Type.GetType("System.Int32"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("location", Type.GetType("System.String"))
      .Columns.Add("tax", Type.GetType("System.Decimal"))
      .Columns.Add("bondp", Type.GetType("System.Decimal"))
      .Columns.Add("bald", Type.GetType("System.Decimal"))
    End With
    ds2.Tables.Add(myTable)

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        dr = ds2.Tables(0).NewRow
        dr.Item("wsel") = 0
        dr.Item("list#") = .Item("list#")
        dr.Item("type") = .Item("type")
        dr.Item("year") = .Item("year")
        dr.Item("name") = .Item("name")
        dr.Item("location") = Trim(.Item("loc#")) & " " & .Item("loc")
        If .Item("ccno") > 0 Then
          dr.Item("tax") = .Item("ccetax")
        Else
          dr.Item("tax") = .Item("taxt")
        End If
        dr.Item("bondp") = .Item("bondp")
        dr.Item("bald") = .Item("bald")
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


