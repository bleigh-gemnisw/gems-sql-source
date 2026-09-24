Imports System.Data
Imports System.Data.SqlClient

Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Private da As SqlDataAdapter

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

  ' Receives already-parsed data from VB and uploads it to WebPayImport_Staging
  Public Function UploadToStaging(dt As DataTable) As Boolean
    Try
      ' Clear staging table
      Using conn As SqlConnection = CType(MyDBConn.Open(), SqlConnection)
        Dim clearCmd As New SqlCommand("TRUNCATE TABLE WebPayImport_Staging", conn)
        clearCmd.ExecuteNonQuery()
      End Using

      ' Bulk insert
      Using conn As SqlConnection = CType(MyDBConn.Open(), SqlConnection)
        Using bulk As New SqlBulkCopy(conn)
          bulk.DestinationTableName = "WebPayImport_Staging"
          bulk.WriteToServer(dt)
        End Using
      End Using

      Return True
    Catch ex As Exception
      Throw New ApplicationException("Error in UploadToStaging: " & ex.Message)
    End Try
  End Function

  ' Returns joined TXINV + WebPayImport_Staging records
  Public Function GetMatchedTXINV() As DataTable
    Dim dt As New DataTable()
    Try
      Using conn As SqlConnection = CType(MyDBConn.Open(), SqlConnection)
        Using cmd As New SqlCommand("usp_GetBulkTXA08Records", conn)
          cmd.CommandType = CommandType.StoredProcedure
          da = New SqlDataAdapter(cmd)
          da.Fill(dt)
        End Using
      End Using
    Catch ex As Exception
      Throw New ApplicationException("Error in GetMatchedTXINV: " & ex.Message)
    End Try
    Return dt
  End Function
End Class
