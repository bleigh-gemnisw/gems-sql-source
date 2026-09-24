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

  AddDetail("TOWNBR", "", "N", 1, 3, 0)
  AddDetail("LIST#", "LIST NO", "N", 4, 6, 0)
  AddDetail("YEAR", "TAX YEAR", "N", 10, 4, 0)
  AddDetail("TYPEDS", "TYPE DESCRIPTION", "A", 14, 25, 0)
  AddDetail("NAME", "NAME", "A", 39, 35, 0)
  AddDetail("SNAME", "SECOND NAME", "A", 74, 35, 0)
  AddDetail("ADD1", "ADDRESS 1", "A", 109, 35, 0)
  AddDetail("ADD2", "ADDRESS 2", "A", 144, 35, 0)
  AddDetail("CITY", "CITY", "A", 179, 25, 0)
  AddDetail("STATE", "STATE", "A", 204, 2, 0)
  AddDetail("ZIP5", "ZIP CODE", "N", 206, 5, 0)
  AddDetail("ZIP4", "ZIP PLUS4", "N", 211, 4, 0)
  AddDetail("LOC#", "LOCATION #", "A", 215, 7, 0)
  AddDetail("LOC", "LOCATION NAME", "A", 222, 25, 0)
  AddDetail("IMVREG", "REG NO", "A", 247, 8, 0)
  AddDetail("DESC", "PROPERTY DESC", "A", 255, 30, 0)
  AddDetail("PAMT", "PRINCIPAL PAID", "N", 285, 11, 2)
  AddDetail("IAMT", "INTEREST PAID", "N", 291, 7, 2)
  AddDetail("LAMT", "LIEN PAID", "N", 295, 5, 2)
  AddDetail("PCAMT", "PENALTY AMOUNT", "N", 298, 9, 2)
  AddDetail("TOTAMT", "TOTAL PAID", "N", 303, 11, 2)
  AddDetail("CORC", "1 - CASH 2 - CHECK 3 - CREDIT", "A", 309, 1, 0)
  AddDetail("REF", "REFER CHECK NO", "A", 310, 10, 0)
  AddDetail("COMM", "COMMENT", "A", 320, 20, 0)
  AddDetail("ADJCD", "R - REFUND Z - ABATEMENT A - A", "A", 340, 1, 0)
  AddDetail("PDATE", "PAYMENT DATE", "A", 341, 12, 0)

Done:
  MyPrtLayout = New FrmPrtLayout
  With MyPrtLayout
    .wrkds = ds
    .WrkDesc = "WEBHIST"
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






