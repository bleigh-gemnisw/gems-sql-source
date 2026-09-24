Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Module Common
Public Sub DropTable(ByVal WrkTable As String)

  Dim WrkCmd As SqlCommand
  Dim WrkSql As String
  WrkSql = "IF OBJECT_ID('dbo." & WrkTable & "', 'U') IS NOT NULL DROP TABLE " & WrkTable
'  WrkSql = "DROP TABLE " & WrkTable
  WrkCmd = New SqlCommand(WrkSql, MyConn.MyConn)
  Try
    WrkCmd.ExecuteNonQuery()
  Catch ex As Exception
    MsgBox(ex.ToString)
  End Try
  WrkCmd = Nothing
End Sub
Public Sub CrtTable(ByVal WrkTable As String)

  Dim WrkCmd As SqlCommand
  Dim WrkSql As String
  Dim sb As StringBuilder
  WrkSql = "CREATE TABLE " & WrkTable & " (" & _
    "RecID INTEGER NOT NULL, Type varchar(1) default NULL," & _
    "Group1 varchar(60) default NULL, Group2 varchar(30) default NULL, IsCompany varchar(30) default null," & _
    "PostBarCode varchar(100) default NULL, PostEndorse varchar(65) default NULL," & _
    "PostSort integer, GroupID varchar(25) default NULL, PostID integer," & _
    "PageNo integer, FirstName varchar(30) default NULL, LastName varchar(30) default NULL," & _
    "Suffix varchar(10) default NULL, CompanyName varchar(50) default NULL," & _
    "Name varchar(35) default NULL, Name2 varchar(35) default NULL," & _
    "Addr varchar(35) default NULL, Addr2 varchar(35) default NULL," & _
    "Town varchar(25) default NULL, State varchar(2) default NULL," & _
    "Zip varchar(5) default NULL, Zip4 varchar(4) default NULL," & _
    "Bkcd varchar(2) default NULL," & _
    "CONSTRAINT [PK_" & WrkTable & "] PRIMARY KEY CLUSTERED (RecID ASC, Type ASC))"

  WrkCmd = New SqlCommand(WrkSql, MyConn.MyConn)
  Try
'    Console.WriteLine(WrkSql)
    WrkCmd.ExecuteNonQuery()
  Catch ex As Exception
    MsgBox(ex.ToString)
  End Try
  WrkCmd = Nothing
  sb = Nothing
End Sub
Public Sub InsertRow(ByVal Counter As Integer, ByVal WrkTable As String, ByVal WrkType As String, ByVal RecArray() As String)

  Dim WrkCmd As SqlCommand
  Dim WrkSql As String
  Dim sb As StringBuilder
  Dim I As Integer
  Dim HdrArray(8) As String

  HdrArray(0) = "Name"
  HdrArray(1) = "Name2"
  HdrArray(2) = "Addr"
  HdrArray(3) = "Addr2"
  HdrArray(4) = "Town"
  HdrArray(5) = "State"
  HdrArray(6) = "Zip"
  HdrArray(7) = "Zip4"
  HdrArray(8) = "Bkcd"
  WrkSql = "INSERT INTO " & WrkTable & " (RecID, Type, Group1, Group2, IsCompany, " & _
    "PostBarCode, PostEndorse, PostSort, GroupID, PostID, PageNo," & _
    "FirstName, LastName, Suffix, CompanyName, " & vbCrLf

  sb = New StringBuilder
  For I = 0 To HdrArray.GetUpperBound(0)
    sb.Append(HdrArray(I))
    If I <> HdrArray.GetUpperBound(0) Then
      sb.Append("," & vbCrLf)
    Else
      sb.Append(") values (")
    End If
  Next

  sb.Append("@RecID, @Type, @Group1, @Group2, @IsCompany,")
  sb.Append("@PostBarCode, @PostEndorse, @PostSort, @GroupID, @PostID, @PageNo,")
  sb.Append("@FirstName, @LastName, @Suffix, @CompanyName,")
  For I = 0 To HdrArray.GetUpperBound(0)
    sb.Append("@" & HdrArray(I))
    If I <> HdrArray.GetUpperBound(0) Then
      sb.Append("," & vbCrLf)
    Else
      sb.Append(")")
    End If
  Next
  WrkSql = WrkSql & sb.ToString
  sb = Nothing

  WrkCmd = New SqlCommand(WrkSql, MyConn.MyConn)
  WrkCmd.Parameters.AddWithValue("@RecID", Counter)
  WrkCmd.Parameters.AddWithValue("@Type", WrkType)
  WrkCmd.Parameters.AddWithValue("@Group1", String.Empty)
  WrkCmd.Parameters.AddWithValue("@Group2", String.Empty)
  WrkCmd.Parameters.AddWithValue("@IsCompany", String.Empty)
  WrkCmd.Parameters.AddWithValue("@PostBarCode", String.Empty)
  WrkCmd.Parameters.AddWithValue("@PostEndorse", String.Empty)
  WrkCmd.Parameters.AddWithValue("@PostSort", 0)
  WrkCmd.Parameters.AddWithValue("@GroupID", String.Empty)
  WrkCmd.Parameters.AddWithValue("@PostID", 0)
  WrkCmd.Parameters.AddWithValue("@PageNo", 0)
  WrkCmd.Parameters.AddWithValue("@FirstName", String.Empty)
  WrkCmd.Parameters.AddWithValue("@LastName", String.Empty)
  WrkCmd.Parameters.AddWithValue("@Suffix", String.Empty)
  WrkCmd.Parameters.AddWithValue("@CompanyName", String.Empty)
  For I = 0 To RecArray.GetUpperBound(0)
    WrkCmd.Parameters.AddWithValue("@" & HdrArray(I), RecArray(I))
  Next

  Try
    Console.WriteLine(WrkSql)
    WrkCmd.ExecuteNonQuery()
  Catch ex As Exception
      MsgBox("Counter: " & Counter & " " & WrkType & vbCrLf & vbCrLf & ex.ToString)
    End Try
  WrkCmd = Nothing
  sb = Nothing
End Sub

End Module
