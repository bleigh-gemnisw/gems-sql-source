Imports System.Data.SqlClient
Imports System.IO

Public Class MyData

  Dim MyDBConn As SQLConnect.DBConnection

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

  Public Function UploadBankFile(filePath As String, tableName As String, isList7 As Boolean, isYear4Digit As Boolean) As Boolean
    Try
      Dim dt As New DataTable
      dt.Columns.Add("LISTNO", GetType(Integer))
      dt.Columns.Add("YEAR", GetType(Integer))
      dt.Columns.Add("TYPE", GetType(String))
      dt.Columns.Add("PAIDAMOUNT", GetType(Decimal))
      dt.Columns.Add("BANKCD", GetType(String))

      Dim lines() As String = File.ReadAllLines(filePath)
      For Each line As String In lines
        If String.IsNullOrWhiteSpace(line) Then Continue For

        'MK 7/28/25 Begin
        'line = line.Trim()
        'MK 7/28/25 End
        Dim listNoLen As Integer = If(isList7, 7, 6)

        Dim listNo As Integer = CInt(line.Substring(0, listNoLen).Trim())
        Dim year As Integer
        Dim taxType As String
        Dim paid As Decimal
        Dim bank As String

        If isYear4Digit Then
          year = CInt(line.Substring(listNoLen, 4).Trim())
          taxType = line.Substring(listNoLen + 4, 1).Trim()
          paid = Decimal.Parse(line.Substring(listNoLen + 5, 11).Trim()) / 100
          bank = line.Substring(listNoLen + 16, 2).Trim()
        Else
          year = 2000 + CInt(line.Substring(listNoLen, 2).Trim())
          taxType = line.Substring(listNoLen + 2, 1).Trim()
          paid = Decimal.Parse(line.Substring(listNoLen + 3, 11).Trim()) / 100
          bank = line.Substring(listNoLen + 14, 2).Trim()

          If String.IsNullOrWhiteSpace(bank) Then
            bank = line.Substring(listNoLen + 20, 2).Trim()
          End If
        End If

        dt.Rows.Add(listNo, year, taxType, paid, bank)
      Next

      Dim Conn As SqlConnection = MyDBConn.Open

      Dim delCmd As New SqlCommand("DELETE FROM " & tableName, Conn)
      delCmd.ExecuteNonQuery()

      Using bulkCopy As New SqlBulkCopy(Conn)
        bulkCopy.DestinationTableName = tableName
        bulkCopy.ColumnMappings.Add("LISTNO", "ListNo")
        bulkCopy.ColumnMappings.Add("YEAR", "Year")
        bulkCopy.ColumnMappings.Add("TYPE", "Type")
        bulkCopy.ColumnMappings.Add("PAIDAMOUNT", "PaidAmount")
        bulkCopy.ColumnMappings.Add("BANKCD", "BankCd")
        bulkCopy.WriteToServer(dt)
      End Using

      Conn.Close()
      Return True

    Catch ex As Exception
      Throw New ApplicationException("Error in UploadBankFile: " & ex.Message)
    End Try
  End Function

  Public Function GetMatchedTXINV(useList7 As Boolean) As DataTable
    Dim dt As New DataTable
    Try
      Dim Conn As SqlConnection = MyDBConn.Open
      Dim cmd As New SqlCommand("usp_GetBulkTXA04Records", Conn)
      cmd.CommandType = CommandType.StoredProcedure
      cmd.Parameters.AddWithValue("@UseList7", If(useList7, 1, 0))

      Dim da As New SqlDataAdapter(cmd)
      da.Fill(dt)
      Conn.Close()
    Catch ex As Exception
      Throw New ApplicationException("Error in GetMatchedTXINV: " & ex.Message)
    End Try
    Return dt
  End Function

End Class
