Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXBATCH"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"

  Public Function GetByList(ByVal Wrklistno As Integer, ByVal wrkyear As Integer, ByVal wrktype As String, ByVal NumRecs As Integer) As DataSet
    Dim ds As New DataSet()
    Dim WrkTop As String = String.Empty

    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If

    Dim StrSQL As String = "SELECT " & WrkTop & " * FROM " & cFileName &
                           " WHERE list# = @listno AND YEAR = @year AND TYPE = @type ORDER BY list#"

    Try
      Using Conn As SqlConnection = MyDBConn.Open()
        Using objCommand As New SqlCommand(StrSQL, Conn)
          objCommand.Parameters.AddWithValue("@listno", Wrklistno)
          objCommand.Parameters.AddWithValue("@year", wrkyear)
          objCommand.Parameters.AddWithValue("@type", wrktype)

          Using da As New SqlDataAdapter(objCommand)
            da.Fill(ds, cFileName)
          End Using
        End Using
      End Using

      Return ds
    Catch ex As Exception
      ' Log error or assign it to a class/global variable if needed
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function GetViewbyList(ByVal wrklistno As Integer, ByVal wrkyear As Integer,
                              ByVal wrktype As String, ByVal NumRecs As Integer) As DataSet
    Dim ds As New DataSet()
    Dim WrkTop As String = String.Empty

    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If

    Dim StrSQL As String = "SELECT " & WrkTop & "jstat, list#, year, type, pamt, iamt, tcamt, lamt, adjcd, cpencd, jseqno, jbatch " &
                           "FROM " & cFileName & " " &
                           "WHERE list# = @listno AND year = @year AND type = @type " &
                           "ORDER BY list#, year, type"

    Try
      Using Conn As SqlConnection = MyDBConn.Open()
        Using objCommand As New SqlCommand(StrSQL, Conn)
          objCommand.Parameters.AddWithValue("@listno", wrklistno)
          objCommand.Parameters.AddWithValue("@year", wrkyear)
          objCommand.Parameters.AddWithValue("@type", wrktype)

          Using da As New SqlDataAdapter(objCommand)
            da.Fill(ds, cFileName)
          End Using
        End Using
      End Using
      Return ds
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function GetViewByBatch(ByVal WrkBatchCd As String, ByVal WrkBchno As Integer, ByVal NumRecs As Integer) As DataSet
    Dim ds As New DataSet()
    Dim WrkTop As String = ""
    Dim StrSQL As String

    RecordNotFound = False
    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If

    StrSQL = "SELECT " & WrkTop & " * FROM " & cFileName _
           & " WHERE jbtchc = @BatchCode AND jbatch = @BatchNo ORDER BY jseqno"

    Try
      Using Conn As SqlConnection = MyDBConn.Open()
        Using objCommand As New SqlCommand(StrSQL, Conn)
          objCommand.Parameters.AddWithValue("@BatchCode", WrkBatchCd)
          objCommand.Parameters.AddWithValue("@BatchNo", WrkBchno)

          Using da As New SqlDataAdapter(objCommand)
            da.Fill(ds, cFileName)
          End Using
        End Using
      End Using

      Return ds
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function CalcListFee(ByVal Wrklistno As Integer, ByVal wrkyear As Integer, ByVal wrktype As String, ByVal WrkPencd As String) As Decimal
    Dim WrkFee As Decimal = 0
    Dim query As String = "SELECT SUM(tcamt) AS amount FROM " & cFileName & " WHERE list# = @listno AND YEAR = @year AND TYPE = @type AND cpencd = @cpencd"

    Try
      Using Conn As SqlConnection = MyDBConn.Open()
        Using cmd As New SqlCommand(query, Conn)
          cmd.Parameters.AddWithValue("@listno", Wrklistno)
          cmd.Parameters.AddWithValue("@year", wrkyear)
          cmd.Parameters.AddWithValue("@type", wrktype)
          cmd.Parameters.AddWithValue("@cpencd", WrkPencd)

          Dim result = cmd.ExecuteScalar()
          If Not IsDBNull(result) Then
            WrkFee = Convert.ToDecimal(result)
          End If
        End Using
      End Using
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try

    Return WrkFee
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


