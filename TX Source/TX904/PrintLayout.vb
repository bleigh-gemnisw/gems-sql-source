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

  AddDetail("Year", "Grand List Year", "N", 1, 4, 0)
  AddDetail("Type", "Tax Type", "A", 5, 1, 0)
  AddDetail("List", "List Number", "N", 6, 6, 0)
  AddDetail("DueDt", "Due Date", "N", 12, 8, 0)
  AddDetail("Name", "Name", "A", 20, 35, 0)
  AddDetail("SName", "Second Name", "A", 55, 35, 0)
  AddDetail("Addr", "Address", "A", 90, 35, 0)
  AddDetail("City", "City", "A", 125, 25, 0)
  AddDetail("State", "State", "A", 150, 2, 0)
  AddDetail("Zip", "Zip Code", "N", 152, 5, 0)
  AddDetail("Zip4", "Zip +4", "N", 157, 4, 0)
  AddDetail("Make", "MV Make", "A", 161, 5, 0)
  AddDetail("MVYear", "MV Year", "N", 166, 4, 0)
  AddDetail("Regno", "MV Reg No", "A", 170, 8, 0)
  AddDetail("VIN", "MV VIN", "A", 178, 17, 0)
  AddDetail("Loc", "Property Location", "A", 195, 25, 0)
  AddDetail("Tax", "Tax Due", "N", 220, 11, 2)
  AddDetail("Int", "Interest Due", "N", 231, 11, 2)
  AddDetail("Lien", "Lien Due", "N", 242, 11, 2)
  AddDetail("Pen", "Penalty Due", "N", 253, 11, 2)
  AddDetail("Total", "Total Due", "N", 264, 11, 2)
  AddDetail("DOB", "Date of Birth (Optional)", "N", 275, 8, 0)
  AddDetail("Model", "Model (Optional)", "A", 283, 8, 0)

Done:
  MyPrtLayout = New FrmPrtLayout
  With MyPrtLayout
    .wrkds = ds
    .WrkDesc = "Collection Agency (Colldata)"
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
Private Sub AddDetail(ByVal Name As String, ByVal Desc As String, ByVal FieldType As String, _
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






