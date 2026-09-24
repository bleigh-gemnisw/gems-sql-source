Imports System.io
Imports System.Text
Module PrintLayout

  Dim ds As DataSet = New DataSet
  Dim dr As DataRow

  Public Sub PrntLayout()

    If ds.Tables.Count = 0 Then
      BuildDs(ds)
    Else
      ds.Clear()
    End If

    AddDetail("List", "List Number", "N", 13, 7, 0)
    AddDetail("Year", "Grand List Year", "N", 21, 2, 0)
    AddDetail("Type", "Tax Type", "A", 29, 1, 0)
    AddDetail("Paid", "Amount Paid", "N", 38, 10, 2)

Done:
    MyPrtLayout = New FrmPrtLayout
    With MyPrtLayout
      .wrkds = ds
      .WrkDesc = "Leasing Company Receipts"
      .Show()
    End With

  End Sub
  Public Sub BuildDs(ByRef Ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mylayout"
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("FieldType", Type.GetType("System.String"))
      .Columns.Add("Begpos", Type.GetType("System.Int16"))
      .Columns.Add("Length", Type.GetType("System.Int16"))
      .Columns.Add("Decpos", Type.GetType("System.Int16"))
    End With
    Ds.Tables.Add(myTable)
  End Sub
  Private Sub AddDetail(ByVal Name As String, ByVal Desc As String, ByVal FieldType As String,
ByVal BegPos As Integer, ByVal Length As Integer, ByVal DecPos As Integer)

    'Field Type:
    'A=Alpha
    'N=Numeric
    dr = ds.Tables(0).NewRow
    dr.Item("name") = Name
    dr.Item("desc") = Desc
    Select Case FieldType
      Case "A"
        dr.Item("fieldtype") = "Alpha"
      Case "N"
        dr.Item("fieldtype") = "Numeric"
      Case Else
        dr.Item("fieldtype") = ""
    End Select
    dr.Item("begpos") = BegPos
    dr.Item("length") = Length
    dr.Item("decpos") = DecPos
    ds.Tables(0).Rows.Add(dr)

  End Sub
End Module






