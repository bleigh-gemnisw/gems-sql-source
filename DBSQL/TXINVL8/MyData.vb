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
  Public Function GetViewbyName(ByVal WrkName As String, ByVal WrkList As Integer,
 ByVal WrkYear As Integer, ByVal WrkType As String, WrkQrySelect As String, ByVal NumRecs As Integer, SetBlocking As Boolean) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkTop As String
    Dim WrkWhere As String
    WrkTop = String.Empty

    RecordNotFound = False
    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If

    WrkWhere = ""
    If WrkQrySelect <> "" Then
      WrkWhere = "and " & WrkQrySelect
    End If

    'StrSQL = "Select " & WrkTop & "name,sname,list#,type,year,ccno,taxt,ccetax,payrec,newpay,bald,icode from " & cFileName _
    '& " where name ='" & WrkName & "' and list# =" & WrkList & " and year =" & WrkYear & " and type >'" & WrkType & "' " & WrkWhere _
    '& " or name ='" & WrkName & "' and list# =" & WrkList & " and year >" & WrkYear & WrkWhere _
    '& " or name ='" & WrkName & "' and list# >" & WrkList & WrkWhere _
    '& " or name >'" & WrkName & "' " & WrkWhere & " order by name,list#,year,type"
    StrSQL = "SELECT " & WrkTop & "name, sname, list#, type, year, ccno, taxt, ccetax, payrec, newpay, bald, icode FROM TXINV WHERE name = '' AND list# = 0 AND year = 0 AND type > '' " &
         "UNION ALL SELECT " & WrkTop & "name, sname, list#, type, year, ccno, taxt, ccetax, payrec, newpay, bald, icode FROM TXINV WHERE name = '' AND list# = 0 AND year > 0 " &
         "UNION ALL SELECT " & WrkTop & "name, sname, list#, type, year, ccno, taxt, ccetax, payrec, newpay, bald, icode FROM TXINV WHERE name = '' AND list# > 0 " &
         "UNION ALL SELECT " & WrkTop & "name, sname, list#, type, year, ccno, taxt, ccetax, payrec, newpay, bald, icode FROM TXINV WHERE name > '' " &
         "ORDER BY name, list#, year, type"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      objCommand.CommandTimeout = 300
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
  Public Function GetViewbyNameScan(ByVal WrkName As String, ByVal WrkList As Integer,
 ByVal WrkYear As Integer, ByVal WrkType As String, WrkQrySelect As String, ByVal NumRecs As Integer, SetBlocking As Boolean) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkTop As String
    Dim WrkWhere As String
    WrkTop = String.Empty

    RecordNotFound = False
    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If

    WrkWhere = ""
    If WrkQrySelect <> "" Then
      WrkWhere = "and " & WrkQrySelect
    End If

    StrSQL = "Select " & WrkTop & "name,sname,list#,type,year,ccno,taxt,ccetax,payrec,newpay,bald,icode from " & cFileName _
    & " where name like '%" & WrkName & "%' and list# =" & WrkList & " and year =" & WrkYear & " and type >'" & WrkType & "' " & WrkWhere _
    & " or name like '%" & WrkName & "%' and list# =" & WrkList & " and year >" & WrkYear & WrkWhere _
    & " or name like '%" & WrkName & "%' and list# >" & WrkList & WrkWhere _
    & " order by name,list#,year,type"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      objCommand.CommandTimeout = 300
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

  Public Function GetViewbyNamesScan(ByVal WrkName As String, ByVal WrkList As Integer,
 ByVal WrkYear As Integer, ByVal WrkType As String, WrkQrySelect As String, ByVal NumRecs As Integer, SetBlocking As Boolean) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkTop As String
    Dim WrkWhere As String
    WrkTop = String.Empty

    RecordNotFound = False
    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If

    WrkWhere = ""
    If WrkQrySelect <> "" Then
      WrkWhere = "and " & WrkQrySelect
    End If

    StrSQL = "Select " & WrkTop & "name,sname,list#,type,year,ccno,taxt,ccetax,payrec,newpay,bald,icode from " & cFileName _
    & " where name like '%" & WrkName & "%' and list# =" & WrkList & " and year =" & WrkYear & " and type >'" & WrkType & "' " & WrkWhere _
    & " or name like '%" & WrkName & "%' and list# =" & WrkList & " and year >" & WrkYear & WrkWhere _
    & " or name like '%" & WrkName & "%' and list# >" & WrkList & WrkWhere _
    & " or sname like '%" & WrkName & "%' and list# =" & WrkList & " and year =" & WrkYear & " and type >'" & WrkType & "' " & WrkWhere _
    & " or sname like '%" & WrkName & "%' and list# =" & WrkList & " and year >" & WrkYear & WrkWhere _
    & " or sname like '%" & WrkName & "%' and list# >" & WrkList & WrkWhere _
    & " order by name,list#,year,type"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      objCommand.CommandTimeout = 300
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
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Sname", Type.GetType("System.String"))
      .Columns.Add("List#", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Wamtd", Type.GetType("System.Decimal"))
      .Columns.Add("Wamtp", Type.GetType("System.Decimal"))
      .Columns.Add("Wbal", Type.GetType("System.Decimal"))
      .Columns.Add("Wupost", Type.GetType("System.String"))
      .Columns.Add("Icode", Type.GetType("System.String"))
    End With
    ds2.Tables.Add(myTable)

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        dr = ds2.Tables(0).NewRow
        dr.Item("wsel") = 0
        dr.Item("name") = .Item("name")
        dr.Item("sname") = .Item("sname")
        dr.Item("list#") = .Item("list#")
        dr.Item("type") = .Item("type")
        dr.Item("year") = .Item("year")
        If .Item("ccno") > 0 Then
          dr.Item("wamtd") = .Item("ccetax")
        Else
          dr.Item("wamtd") = .Item("taxt")
        End If
        dr.Item("wamtp") = .Item("payrec") + .Item("newpay")
        dr.Item("wbal") = .Item("bald") - .Item("newpay")
        If .Item("newpay") > 0 Then
          dr.Item("wupost") = "*"
        Else
          dr.Item("wupost") = ""
        End If
        dr.Item("icode") = .Item("icode")
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


