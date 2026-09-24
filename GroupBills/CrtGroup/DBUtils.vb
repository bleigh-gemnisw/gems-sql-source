Imports System.Data.SqlClient
Public Class DBUtils
Dim StrSQL As String
Dim da As SqlDataAdapter
Public Function GetQry(ByVal WrkFileName As String, ByVal WrkSort As String, _
  ByVal WrkQry As String, ByVal MaxRecs As Long) As DataSet
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & WrkFileName
    If WrkQry <> String.Empty Then
      StrSQL = StrSQL & " where " & WrkQry
    End If
    If WrkSort <> String.Empty Then
      StrSQL = StrSQL & " order by " & WrkSort
    End If
    objCommand = New SqlCommand(StrSQL, MyConn.MyConn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, WrkFileName)

    objCommand = Nothing
    Return ds
End Function
Public Function GetGroupCounts(ByVal WrkFileName As String)
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

    StrSQL = "select groupid,COUNT(GroupID) as count from " & WrkFileName & " group by groupid order by groupid"
    objCommand = New SqlCommand(StrSQL, MyConn.MyConn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, WrkFileName)

    objCommand = Nothing
    Return ds
End Function
  Public Function GetOneRecordP(ByVal WrkFileName As String, ByVal Wrkrecid As Integer, ByVal WrkType As String) As DataSet
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & WrkFileName & " where recid = " & Wrkrecid & " and type='" & WrkType & "'"
    objCommand = New SqlCommand(StrSQL, MyConn.MyConn)
    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, WrkFileName)
    objCommand = Nothing
    Return ds
  End Function
  Public Sub UpdateOneRecordP(ByVal WrkFileName As String, ByRef ds As DataSet)
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)

    da.UpdateCommand = CmdBldr.GetUpdateCommand
    CmdBldr.RefreshSchema()
    da.Update(ds, WrkFileName)

  End Sub
End Class
