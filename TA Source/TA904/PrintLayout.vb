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

  AddDetail("CAT", "1 OR 3 OR T", "A", 1, 1, 0)
  AddDetail("MAKE", "MAKE", "A", 2, 5, 0)
  AddDetail("YEAR", "VEHICLE YEAR", "N", 7, 4, 0)
  AddDetail("MODEL", "MODEL", "A", 11, 8, 0)
  AddDetail("BODY", "BODY", "A", 19, 6, 0)
  AddDetail("TOWNBR", "TOWN NUMBER", "N", 25, 3, 0)
  AddDetail("NAME", "NAME", "A", 28, 35, 0)
  AddDetail("SNAME", "SECOND NAME", "A", 63, 35, 0)
  AddDetail("ADD1", "ADDRESS 1", "A", 98, 35, 0)
  AddDetail("ADD2", "ADDRESS 2", "A", 133, 35, 0)
  AddDetail("CITY", "CITY", "A", 168, 25, 0)
  AddDetail("STATE", "STATE", "A", 193, 2, 0)
  AddDetail("ZIP5", "ZIP CODE", "N", 195, 5, 0)
  AddDetail("ZIP4", "ZIP PLUS4", "N", 200, 4, 0)
  AddDetail("CLASS", "CLASS", "N", 204, 2, 0)
  AddDetail("REGNO", "REG NO", "A", 206, 8, 0)
  AddDetail("VINNO", "VIN #", "A", 214, 17, 0)
  AddDetail("CYLAX", "CYLINDER AXLE", "N", 231, 1, 0)
  AddDetail("PCLR", "PRIMARY COLOR", "A", 232, 3, 0)
  AddDetail("SCLR", "SECONDARY COLOR", "A", 235, 3, 0)
  AddDetail("SEAT", "SEATING CAPACITY", "N", 238, 2, 0)
  AddDetail("LWT", "LIGHT WEIGHT", "N", 240, 6, 0)
  AddDetail("GWT", "GROSS WEIGHT", "N", 246, 6, 0)
  AddDetail("ASS", "ASSESSMENT", "A", 252, 1, 0)
  AddDetail("CYCLE", "CYCLE CODE", "N", 253, 1, 0)
  AddDetail("RCODE", "ROUNDING CODE", "N", 254, 1, 0)
  AddDetail("OCODE", "OUTPUT CODE", "N", 255, 1, 0)
  AddDetail("RATE", "PERC OF ASSESS", "N", 256, 3, 0)
  AddDetail("LIST#", "LIST NO", "N", 259, 6, 0)
  AddDetail("PCCOD", "PREVIOUS CLASS", "N", 265, 2, 0)
  AddDetail("PREG", "PREVIOUS REGNO", "A", 267, 8, 0)
  AddDetail("SCAP", "STANDING CAPACITY", "N", 275, 2, 0)
  AddDetail("VALUE", "VALUE", "N", 277, 9, 0)
  AddDetail("PVAL", "PREVIOUS VALUE", "N", 286, 9, 0)
  AddDetail("DOB", "DOB", "N", 295, 8, 0)
  AddDetail("EXCD1", "EXEMPTION CODE1", "A", 303, 3, 0)
  AddDetail("EXCD2", "EXEMPTION CODE2", "A", 306, 3, 0)
  AddDetail("EXCD3", "EXEMPTION CODE3", "A", 309, 3, 0)
  AddDetail("EXCD4", "EXEMPTION CODE4", "A", 312, 3, 0)
  AddDetail("EXCD5", "EXEMPTION CODE5", "A", 315, 3, 0)
  AddDetail("EX1AMT", "EXEMPTION AMOUNT1", "N", 318, 7, 0)
  AddDetail("EX2AMT", "EXEMPTION AMOUNT2", "N", 325, 7, 0)
  AddDetail("EX3AMT", "EXEMPTION AMOUNT3", "N", 332, 7, 0)
  AddDetail("EX4AMT", "EXEMPTION AMOUNT4", "N", 339, 7, 0)
  AddDetail("EX5AMT", "EXEMPTION AMOUNT5", "N", 346, 7, 0)
  AddDetail("OLIST", "CREDIT LIST", "N", 353, 6, 0)
  AddDetail("OCLS", "CREDIT CLASS", "N", 359, 2, 0)
  AddDetail("OYEAR", "CREDIT VEHICLE YEAR", "N", 361, 4, 0)
  AddDetail("OMAKE", "CREDIT MAKE", "A", 365, 5, 0)
  AddDetail("OMOD", "CREDIT MODEL", "A", 371, 8, 0)
  AddDetail("OREGNO", "CREDIT REG NO", "A", 379, 8, 0)
  AddDetail("OVIN", "CREDIT VIN #", "A", 387, 17, 0)
  AddDetail("OASS", "CREDIT ASSESSMENT", "A", 404, 1, 0)
  AddDetail("OVAL", "CREDIT VALUE", "N", 405, 9, 0)
  AddDetail("OPVAL", "CREDIT PRORATED VALUE", "N", 414, 9, 0)
  AddDetail("PNET", "CREDIT PRORATED NET", "N", 423, 9, 0)
  AddDetail("LEASE", "LEASE CODE", "A", 432, 2, 0)
  AddDetail("DIST", "DISTRICT", "N", 434, 3, 0)

Done:
  MyPrtLayout = New FrmPrtLayout
  With MyPrtLayout
    .wrkds = ds
    .WrkDesc = "Suppl. MV Export Fixed Format"
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






