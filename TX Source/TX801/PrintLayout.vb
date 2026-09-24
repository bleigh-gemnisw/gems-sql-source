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

  AddDetail("LIST#", "LIST NO", "N", 1, 6, 0)
  AddDetail("YR2", "", "N", 7, 2, 0)
  AddDetail("TYPE", "", "A", 9, 1, 0)
  AddDetail("BKCD", "BANK CODE", "A", 10, 2, 0)
  AddDetail("TOWNBR", "", "N", 12, 3, 0)
  AddDetail("NAME", "NAME", "A", 15, 35, 0)
  AddDetail("LOC", "LOCATION NAME", "A", 50, 25, 0)
  AddDetail("LOC#", "LOCATION #", "A", 75, 7, 0)
  AddDetail("MAP", "MAP/LOT", "A", 82, 17, 0)
  AddDetail("VOL", "VOLUME", "A", 99, 5, 0)
  AddDetail("PGE", "PAGE", "A", 104, 5, 0)
  AddDetail("GROSS", "GROSS ASSESSMENT", "N", 109, 9, 0)
  AddDetail("NET", "NET ASSESSMENT", "N", 114, 9, 0)

Done:
  MyPrtLayout = New FrmPrtLayout
  With MyPrtLayout
    .wrkds = ds
    .WrkDesc = "Bank Service (RELEGAL)"
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






