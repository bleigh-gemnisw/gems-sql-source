Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "FAMSTRL2"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Function GetViewbySerialNo(ByVal SerialNo As String, ByVal NumRecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim WrkTop As String

  WrkTop = String.Empty
  If NumRecs > 0 Then
    WrkTop = " TOP " & NumRecs
  End If
  StrSQL = "Select " & WrkTop & "fatag, fadesc, faserl from " & cFileName & " where faserl>='" & SerialNo & "'" & _
   " order by faserl"
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
Public Function GetNext(ByVal NumRecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim WrkTop As String

  WrkTop = String.Empty
  If NumRecs > 0 Then
    WrkTop = " TOP " & NumRecs
  End If
'  StrSQL = "Select fatag, fadesc, faserl from " & cFileName & " where faserl>='" & SerialNo & "'"
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
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
  End Sub
#End Region
End Class

