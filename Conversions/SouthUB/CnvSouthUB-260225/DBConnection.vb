Imports System.Data
Imports System.Data.SqlClient
Imports System.text
Public Class DBConnection
  Dim MyConnName As String
  Public MyConn As SqlConnection
  Public MyConn2 As SqlConnection
  Public objReader As SqlDataReader
  Dim da As SqlDataAdapter
  Dim ConnStr As String
  Dim StrSQL As String
  Dim RecordNotFound As Boolean
  Dim WrkErrorMsg As String
  Public Function IsConnected() As Boolean
    Dim WrkResult As Boolean

    WrkResult = False
    If MyConn.State = System.Data.ConnectionState.Open Then
      WrkResult = True
    End If

    Return WrkResult
  End Function
  Public Function Open() As SqlConnection
    Dim WrkPassword As String
    WrkErrorMsg = String.Empty
    WrkPassword = GetPassword(MyAppSettings.Password)
    ConnStr = "Data Source=" & MyAppSettings.ServerIP & ";Initial Catalog=" & MyAppSettings.DatabaseName &
      ";Integrated Security=false" & ";User ID=" & MyAppSettings.UserID & ";password=" & WrkPassword
    Try
      MyConn = New SqlConnection(ConnStr)
      MyConn.Open()
      Return MyConn
    Catch ex As Exception
      WrkErrorMsg = ex.InnerException.ToString
    End Try
    Return Nothing
  End Function
  Public Function Open2() As SqlConnection
    Dim WrkPassword As String
    WrkErrorMsg = String.Empty
    WrkPassword = GetPassword(MyAppSettings.Password2)
    ConnStr = "Data Source=" & MyAppSettings.ServerIP & ";Initial Catalog=" & MyAppSettings.DatabaseName2 &
      ";Integrated Security=false" & ";User ID=" & MyAppSettings.UserID2 & ";password=" & WrkPassword
    Try
      MyConn2 = New SqlConnection(ConnStr)
      MyConn2.Open()
      Return MyConn2
    Catch ex As Exception
      WrkErrorMsg = ex.InnerException.ToString
    End Try
    Return Nothing
  End Function
  Public Function RunQuery(ByVal WrkFile As String, ByVal wrkWhere As String, Optional ByVal WrkFields As String = "") As DataSet
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    If WrkFields = "" Then
      StrSQL = "Select * from " & WrkFile & " " & wrkWhere
    Else
      StrSQL = "Select " & WrkFields & " from " & WrkFile & " " & wrkWhere
    End If
    Try
        objCommand = New SqlCommand(StrSQL, MyConn)
        'Fill the dataset with the data
        da = New SqlDataAdapter
        da.SelectCommand = objCommand
        da.Fill(ds, WrkFile)
        objCommand = Nothing
        Return ds
      Catch ex As Exception
        WrkErrorMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function RunQuery2(ByVal WrkFile As String, ByVal wrkWhere As String, Optional ByVal WrkFields As String = "") As DataSet
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    If WrkFields = "" Then
      StrSQL = "Select * from " & WrkFile & " " & wrkWhere
    Else
      StrSQL = "Select " & WrkFields & " from " & WrkFile & " " & wrkWhere
    End If
    Try
      objCommand = New SqlCommand(StrSQL, MyConn2)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, WrkFile)
      objCommand = Nothing
      Return ds
    Catch ex As Exception
      WrkErrorMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Sub OpenQry(ByVal WrkFile As String, ByVal wrkWhere As String)
    Dim objCommand As SqlCommand

    StrSQL = "Select * from " & WrkFile & " " & wrkWhere
    objCommand = New SqlCommand(StrSQL, MyConn)
    objReader = objCommand.ExecuteReader()
  End Sub
  Public Sub ReadQry()
    Dim Good As Boolean

    IsEOF = False
    Good = objReader.Read
    If Not Good Then
      IsEOF = True
      objReader.Close()
    End If
  End Sub
  Public Sub DeleteRecords2(ByVal FileName As String, Optional ByVal wrkWhere As String = "")
    Dim objCommand As SqlCommand
    Dim Result As Integer

    RecordNotFound = False
    StrSQL = "Delete from " & FileName & " " & wrkWhere
    objCommand = New SqlCommand(StrSQL, MyConn2)
    objCommand.CommandTimeout = 300
    Result = objCommand.ExecuteNonQuery()
    objCommand = Nothing
  End Sub
  Public Function CheckSQLFileExists(ByVal FileName As String) As Boolean
    Dim Conn As SqlConnection
    Dim StrSQL As String
    Dim objCommand As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet = New DataSet

    Dim RecordFound As Boolean

    RecordFound = False
    StrSQL = "SELECT * FROM sys.tables WHERE name = '" & FileName & "' AND type = 'U'"
    Try
      Conn = Open()
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, FileName)
      If ds.Tables(0).Rows.Count > 0 Then
        RecordFound = True
      End If
      objCommand = Nothing
      ds.Clear()
      ds = Nothing
    Catch ex As Exception
    End Try
    Return RecordFound
  End Function
  Private Function CnvSng(ByVal WrkNum As String) As Decimal
    'Convert string to decimal
    Dim WrkDbl As Decimal

    If WrkNum = "" Then
      WrkDbl = 0
      Return WrkDbl
    End If

    If Not IsNumeric(WrkNum) Then
      WrkDbl = 0
      Return WrkDbl
    End If

    WrkDbl = CDbl(WrkNum)
    Return WrkDbl
  End Function
  Public Property ErrorMsg() As String
        Get
          Return WrkErrorMsg
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property PgmDB() As String
        Get
      If MyConnName = MyAppSettings.ConnName2 Then
        Return MyAppSettings.DatabaseName2
      Else
        Return MyAppSettings.DatabaseName
      End If
    End Get
    Set(ByVal value As String)
        End Set
    End Property
  Dim mIsEOF As Boolean
  Public Property IsEOF() As Boolean
    Set(ByVal value As Boolean)
      mIsEOF = value
    End Set
    Get
      Return mIsEOF
    End Get
  End Property
  Public Property ServerName() As String
    Get
      Return "SQL"
    End Get
    Set(ByVal value As String)
    End Set
  End Property
  Public Property ServerAS400() As Boolean
        Get
          Return False
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property
Public Function GetPassword(ByVal Phrase As String) As String
  Dim Sb As StringBuilder
  Dim WrkNumber As Integer
  Dim I As Integer
  Dim J As Integer

  Sb = New StringBuilder
  For I = 1 To Len(Phrase)
    J = (I * 3) - 2
    WrkNumber = CnvSng(Mid(Phrase, J, 3))
    Select Case (I Mod 3)
    Case 1
      WrkNumber = WrkNumber - 7
    Case 2
      WrkNumber = WrkNumber - 3
    Case 0
      WrkNumber = WrkNumber - 1
    End Select
    If WrkNumber > 0 Then
      Sb.Append(Chr(WrkNumber))
    End If
  Next I

  Return Sb.ToString

End Function
Public Function SetPassword(ByVal Password As String) As String
  Dim Sb As StringBuilder
  Dim WrkNumber As Integer
  Dim WrkLetter As String
  Dim I As Integer

  Sb = New StringBuilder
  For I = 1 To Len(Password)
    WrkLetter = Mid(Password, I, 1)
    WrkNumber = Asc(WrkLetter)
    Select Case (I Mod 3)
    Case 1
      WrkNumber = WrkNumber + 7
    Case 2
      WrkNumber = WrkNumber + 3
    Case 0
      WrkNumber = WrkNumber + 1
    End Select
    Sb.Append(Format(WrkNumber, "000"))
  Next I

  Return Sb.ToString

End Function
End Class