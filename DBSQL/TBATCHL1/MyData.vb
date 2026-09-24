Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TBATCH"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"

  Public Function GetAllData_MDY(ByVal WrkUser As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkTop As String
    Dim WrkWhere As String
    WrkTop = String.Empty

    RecordNotFound = False
    If WrkUser = "" Then
      WrkWhere = ""
    Else
      WrkWhere = " where kuser ='" & WrkUser & "'"
    End If

    StrSQL = "Select kbtchc,kbtch#,kbtcht,krmm,krdd,kryy,kimm,kidd,kiyy,kprint,kvalid,kendorse,kuser,kucode,kbstat,kbend from " & cFileName _
    & WrkWhere & " order by kbtchc,kbtch#"
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
      .Columns.Add("kbtchc", Type.GetType("System.String"))
      .Columns.Add("kbtch#", Type.GetType("System.Int16"))
      .Columns.Add("kbtcht", Type.GetType("System.String"))
      .Columns.Add("krmdy", Type.GetType("System.String"))
      .Columns.Add("kimdy", Type.GetType("System.String"))
      .Columns.Add("kprint", Type.GetType("System.String"))
      .Columns.Add("kvalid", Type.GetType("System.String"))
      .Columns.Add("kendorse", Type.GetType("System.String"))
      .Columns.Add("kuser", Type.GetType("System.String"))
      .Columns.Add("kucode", Type.GetType("System.Int16"))
      .Columns.Add("kbstat", Type.GetType("System.String"))
      .Columns.Add("kbend", Type.GetType("System.Decimal"))

    End With
    ds2.Tables.Add(myTable)

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        dr = ds2.Tables(0).NewRow
        dr.Item("kbtchc") = .Item("kbtchc")
        dr.Item("kbtch#") = .Item("kbtch#")
        dr.Item("kbtcht") = .Item("kbtcht")
        dr.Item("krmdy") = .Item("Krmm") & "/" & .Item("Krdd") & "/" & .Item("Kryy")
        dr.Item("kimdy") = .Item("Kimm") & "/" & .Item("Kidd") & "/" & .Item("Kiyy")
        dr.Item("kprint") = .Item("kprint")
        dr.Item("kvalid") = .Item("kvalid")
        dr.Item("kendorse") = .Item("kendorse")
        dr.Item("kuser") = .Item("kuser")
        dr.Item("kucode") = .Item("kucode")
        dr.Item("kbstat") = .Item("kbstat")
        dr.Item("kbend") = .Item("kbend")

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


