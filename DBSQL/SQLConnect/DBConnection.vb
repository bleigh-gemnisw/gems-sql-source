Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Public Class DBConnection
  Public MyAppSettings As AppSettings
  Dim MyConnName As String
  Dim MyConn As SqlConnection
  Dim ConnStr As String
  Dim WrkErrorMsg As String
  Public Sub New(ByVal WrkDBName As String)
    MyConnName = WrkDBName
    GetAppSettings()
  End Sub
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

    For I As Integer = 2 To 10
      ' Check if current connection matches this numbered ConnName
      If MyConnName = CallByName(MyAppSettings, "ConnName" & I, CallType.Get) Then
        ' Get the password
        WrkPassword = GetPassword(CallByName(MyAppSettings, "Password" & I, CallType.Get))
        ' Build connection string dynamically
        ConnStr = "Data Source=" & MyAppSettings.ServerIP &
                  ";Initial Catalog=" & CallByName(MyAppSettings, "DatabaseName" & I, CallType.Get) &
                  ";Integrated Security=false" &
                  ";Connection Timeout=60" &
                  ";User ID=" & CallByName(MyAppSettings, "UserID" & I, CallType.Get) &
                  ";password=" & WrkPassword
        Exit For ' Exit loop once we found the match
      End If
    Next
    If Trim(ConnStr) = "" Then
      WrkPassword = GetPassword(MyAppSettings.Password)
      ConnStr = "Data Source=" & MyAppSettings.ServerIP & ";Initial Catalog=" & MyAppSettings.DatabaseName &
      ";Integrated Security=false" & ";Connection Timeout=60" & ";User ID=" & MyAppSettings.UserID & ";password=" & WrkPassword
    End If
    Try
      MyConn = New SqlConnection(ConnStr)
      MyConn.Open()
      Return MyConn
    Catch ex As Exception
      WrkErrorMsg = ex.InnerException.ToString & ""
    End Try
    Return Nothing
  End Function
  Public Function Open(ByVal OpenIt As Boolean) As SqlConnection
    Dim WrkPassword As String
    WrkErrorMsg = String.Empty
    For I As Integer = 2 To 10
      ' Check if current connection matches this numbered ConnName
      If MyConnName = CallByName(MyAppSettings, "ConnName" & I, CallType.Get) Then
        ' Get the password
        WrkPassword = GetPassword(CallByName(MyAppSettings, "Password" & I, CallType.Get))
        ' Build connection string dynamically
        ConnStr = "Data Source=" & MyAppSettings.ServerIP &
                  ";Initial Catalog=" & CallByName(MyAppSettings, "DatabaseName" & I, CallType.Get) &
                  ";Integrated Security=false" &
                  ";Connection Timeout=60" &
                  ";User ID=" & CallByName(MyAppSettings, "UserID" & I, CallType.Get) &
                  ";password=" & WrkPassword
        Exit For ' Exit loop once we found the match
      End If
    Next
    If Trim(ConnStr) = "" Then
      WrkPassword = GetPassword(MyAppSettings.Password)
      ConnStr = "Data Source=" & MyAppSettings.ServerIP & ";Initial Catalog=" & MyAppSettings.DatabaseName &
      ";Integrated Security=false" & ";Connection Timeout=60" & ";User ID=" & MyAppSettings.UserID & ";password=" & WrkPassword
    End If
    Try
      MyConn = New SqlConnection(ConnStr)
      If OpenIt Then
        MyConn.Open()
      End If
      Return MyConn
    Catch ex As Exception
      WrkErrorMsg = ex.InnerException.ToString & ""
    End Try
    Return Nothing
  End Function
  Public Sub Close()
    MyConn.Close()
  End Sub
  Public Sub GetAppSettings()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sr As IO.StreamReader
    Dim WrkXMLPath As String
    Dim WrkFileExists As Boolean

    WrkXMLPath = GetDataPath() & "Settings\SQLConnect.xml"
    WrkFileExists = CheckFileExists(WrkXMLPath)
    If Not WrkFileExists Then
      'Need double slashes for network path 
      WrkXMLPath = Replace(WrkXMLPath, "\", "\\")
      'Remove extra slashes if network path 
      WrkXMLPath = Replace(WrkXMLPath, "\\\\", "\\")
    End If

    If WrkFileExists Then
      sr = New IO.StreamReader(WrkXMLPath)
      MyAppSettings = New AppSettings
      Try
        MyAppSettings = CType(xs.Deserialize(sr), AppSettings)
      Catch
      End Try
      sr.Close()
    Else
      MyAppSettings = New AppSettings
    End If
  End Sub
  Private Function CheckFileExists(ByVal FileName As String) As Boolean

    Dim Results As String

    CheckFileExists = False
    Results = Dir(FileName)

    If Results <> "" Then
      CheckFileExists = True
    End If

    Return CheckFileExists

  End Function
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
      Conn.Close()
    Catch ex As Exception
    End Try
    Return RecordFound
  End Function
  Private Function GetDataPath() As String

    Dim WrkFileName As String
    Dim WrkPgmName As String

    WrkFileName = System.Reflection.Assembly.GetExecutingAssembly.Location
    Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(WrkFileName)

    With myFileVersionInfo
      WrkPgmName = .InternalName
    End With

    'Remove program name from path
    WrkFileName = Replace(WrkFileName, WrkPgmName, "", , , CompareMethod.Text)

    Return WrkFileName
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
      For I As Integer = 2 To 10
        ' Check if current connection matches this numbered ConnName
        If MyConnName = CallByName(MyAppSettings, "ConnName" & I, CallType.Get) Then
          ' Build connection string dynamically
          Return CallByName(MyAppSettings, "DatabaseName" & I, CallType.Get)
        End If
      Next

      Return MyAppSettings.DatabaseName
    End Get
    Set(ByVal value As String)
    End Set
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