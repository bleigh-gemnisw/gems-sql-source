Imports System.io
Imports System.Text
Module UtilsFile
Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Public Sub ExportFile(ByVal ds As DataSet, ByVal FileName As String, ByVal ShowProgress As Boolean)
  'Export file to CSV format. 
  ' NOTE: No commas (",") are allowed in any fields
  Dim sb As StringBuilder
  Dim sw As StreamWriter
  Dim WrkTable As DataTable
  Dim WrkColumn As DataColumn
  Dim MaxCol As Integer
  Dim I As Integer

  If ShowProgress Then
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
  End If

  sw = New StreamWriter(FileName)
  WrkTable = ds.Tables(0)

  'Write field names
  MaxCol = WrkTable.Columns.Count - 1
  sb = New StringBuilder
  For Each WrkColumn In WrkTable.Columns
    sb.Append(QuoDbl(WrkColumn.ColumnName))
    If WrkColumn.Ordinal <> MaxCol Then
      sb.Append(",")
    End If
  Next
  sw.WriteLine(sb.ToString)

  For I = 0 To ds.Tables(0).Rows.Count - 1
    sb = New StringBuilder
    For Each WrkColumn In WrkTable.Columns
      If WrkColumn.DataType Is Type.GetType("System.String") Then
        sb.Append(QuoDbl(ds.Tables(0).Rows(I).Item(WrkColumn.ColumnName) & ""))
      Else
        sb.Append(ds.Tables(0).Rows(I).Item(WrkColumn.ColumnName))
      End If
      If WrkColumn.Ordinal <> MaxCol Then
        sb.Append(",")
      End If
    Next
    sw.WriteLine(sb.ToString)

    If ShowProgress Then
      With myFrmProgress
        WrkPct = ((I + 1) / ds.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
       End If
      End With
    End If
  Next

  sw.Close()
  myFrmProgress.Close()
End Sub
Public Function ExportRecord(ByVal FieldNames As Boolean, ByVal ds As DataSet) As String
  'Returns one record in CSV format
  'Usage (field names): ExportRecord(True,ds)
  '      (field data): ExportRecord(False,ds)
  ' NOTE: No commas (",") are allowed in any fields
  Dim sb As StringBuilder
  Dim WrkTable As DataTable
  Dim WrkColumn As DataColumn
  Dim MaxCol As Integer
  Dim WrkResult As String

  WrkResult = ""
  WrkTable = ds.Tables(0)
  'Write field names
  MaxCol = WrkTable.Columns.Count - 1
  If FieldNames Then
    sb = New StringBuilder
    For Each WrkColumn In WrkTable.Columns
      sb.Append(QuoDbl(WrkColumn.ColumnName))
      If WrkColumn.Ordinal <> MaxCol Then
        sb.Append(",")
      End If
    Next
    WrkResult = sb.ToString
  Else
    sb = New StringBuilder
    For Each WrkColumn In WrkTable.Columns
      If WrkColumn.DataType Is Type.GetType("System.String") Then
        sb.Append(QuoDbl(ds.Tables(0).Rows(0).Item(WrkColumn.ColumnName)))
      Else
        sb.Append(ds.Tables(0).Rows(0).Item(WrkColumn.ColumnName))
      End If
      If WrkColumn.Ordinal <> MaxCol Then
        sb.Append(",")
      End If
    Next
    WrkResult = sb.ToString
  End If

  Return WrkResult
End Function

Public Function QuoDbl(ByVal WrkString As String) As String
  'Put quotes around strings for Query Select
  QuoDbl = Chr(34) & WrkString & Chr(34)
End Function
End Module
