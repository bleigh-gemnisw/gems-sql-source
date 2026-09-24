Imports System.Data
Imports System.Data.SqlClient
Imports System.text
Public Class DBConnection
  Dim MyConnName As String
  Public MyConn2 As SqlConnection
  Dim da As SqlDataAdapter
  Dim ConnStr As String
  Dim StrSQL As String
  Dim RecordNotFound As Boolean
  Dim WrkErrorMsg As String
  Public Function IsConnected() As Boolean
    Dim WrkResult As Boolean

    WrkResult = False
    If MyConn2.State = System.Data.ConnectionState.Open Then
      WrkResult = True
    End If

    Return WrkResult
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
  Public Sub DeleteRecords2(ByVal FileName As String, Optional ByVal WrkWhere As String = "")
    Dim objCommand As SqlCommand
    Dim Result As Integer

    RecordNotFound = False
    If WrkWhere <> "" Then
      StrSQL = "Delete from " & FileName & " Where " & WrkWhere
    Else
      StrSQL = "Delete from " & FileName
    End If
    objCommand = New SqlCommand(StrSQL, MyConn2)
    Result = objCommand.ExecuteNonQuery()
    objCommand = Nothing
  End Sub
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
      Return MyAppSettings.DatabaseName2
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