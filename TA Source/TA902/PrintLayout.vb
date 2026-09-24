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

  AddDetail("CAT", "CATEGORY", "A", 1, 1, 0)
  AddDetail("LIST#", "LIST NO", "N", 2, 6, 0)
  AddDetail("NAME", "NAME", "A", 8, 35, 0)
  AddDetail("SNAME", "SECOND NAME", "A", 43, 35, 0)
  AddDetail("ADD1", "ADDRESS 1", "A", 78, 35, 0)
  AddDetail("ADD2", "ADDRESS 2", "A", 113, 35, 0)
  AddDetail("CITY", "CITY", "A", 148, 25, 0)
  AddDetail("STATE", "STATE", "A", 173, 2, 0)
  AddDetail("ZIP5", "ZIP CODE", "N", 175, 5, 0)
  AddDetail("ZIP4", "ZIP PLUS4", "N", 180, 4, 0)
  AddDetail("LOC#", "LOCATION #", "A", 184, 7, 0)
  AddDetail("LOC", "LOCATION NAME", "A", 191, 25, 0)
	AddDetail("GROSS", "GROSS ASSESSMENT", "N", 216, 9, 0)
	AddDetail("NETASS", "NET ASSESSMENT", "N", 225, 9, 0)
	AddDetail("ASS1", "ASSESSMENT 1", "N", 234, 9, 0)
	AddDetail("ASS2", "ASSESSMENT 2", "N", 243, 9, 0)
	AddDetail("ASS3", "ASSESSMENT 3", "N", 252, 9, 0)
	AddDetail("ASS4", "ASSESSMENT 4", "N", 261, 9, 0)
	AddDetail("ASS5", "ASSESSMENT 5", "N", 270, 9, 0)
	AddDetail("ASS6", "ASSESSMENT 6", "N", 279, 9, 0)
	AddDetail("ASS7", "ASSESSMENT 7", "N", 288, 9, 0)
	AddDetail("ASS8", "ASSESSMENT 8", "N", 297, 9, 0)
	AddDetail("ASS9", "ASSESSMENT 9", "N", 306, 9, 0)
	AddDetail("ASS10", "ASSESSMENT 10", "N", 315, 9, 0)
  AddDetail("CODE1", "PROPERTY CODE 1", "N", 324, 3, 0)
  AddDetail("CODE2", "PROPERTY CODE 2", "N", 327, 3, 0)
  AddDetail("CODE3", "PROPERTY CODE 3", "N", 330, 3, 0)
  AddDetail("CODE4", "PROPERTY CODE 4", "N", 333, 3, 0)
  AddDetail("CODE5", "PROPERTY CODE 5", "N", 336, 3, 0)
  AddDetail("CODE6", "PROPERTY CODE 6", "N", 339, 3, 0)
  AddDetail("CODE7", "PROPERTY CODE 7", "N", 342, 3, 0)
  AddDetail("CODE8", "PROPERTY CODE 8", "N", 345, 3, 0)
  AddDetail("CODE9", "PROPERTY CODE 9", "N", 348, 3, 0)
  AddDetail("CODEA", "PROPERTY CODE 10", "N", 351, 3, 0)
	AddDetail("UNIT1", "UNIT 1", "N", 354, 3, 0)
	AddDetail("UNIT2", "UNIT 2", "N", 357, 3, 0)
	AddDetail("UNIT3", "UNIT 3", "N", 360, 3, 0)
	AddDetail("UNIT4", "UNIT 4", "N", 363, 3, 0)
	AddDetail("UNIT5", "UNIT 5", "N", 366, 3, 0)
	AddDetail("UNIT6", "UNIT 6", "N", 369, 3, 0)
	AddDetail("UNIT7", "UNIT 7", "N", 372, 3, 0)
	AddDetail("UNIT8", "UNIT 8", "N", 375, 3, 0)
	AddDetail("UNIT9", "UNIT 9", "N", 378, 3, 0)
	AddDetail("UNITA", "UNIT 10", "N", 381, 3, 0)
  AddDetail("DIST", "DISTRICT", "N", 384, 3, 0)
	AddDetail("EX1", "EXEMPTION CODE 1", "A", 387, 3, 0)
	AddDetail("EX2", "EXEMPTION CODE 2", "A", 390, 3, 0)
	AddDetail("EX3", "EXEMPTION CODE 3", "A", 393, 3, 0)
	AddDetail("EX4", "EXEMPTION CODE 4", "A", 396, 3, 0)
	AddDetail("EX5", "EXEMPTION CODE 5", "A", 399, 3, 0)
	AddDetail("EX#1", "EXEMPTION AMOUNT 1", "N", 402, 7, 0)
	AddDetail("EX#2", "EXEMPTION AMOUNT 2", "N", 409, 7, 0)
	AddDetail("EX#3", "EXEMPTION AMOUNT 3", "N", 416, 7, 0)
	AddDetail("EX#4", "EXEMPTION AMOUNT 4", "N", 423, 7, 0)
	AddDetail("EX#5", "EXEMPTION AMOUNT 5", "N", 430, 7, 0)
  AddDetail("BUSTY", "BUSINESS TYPE CODE", "A", 437, 4, 0)
	AddDetail("SQFT", "SQUARE FEET", "N", 441, 9, 2)
	AddDetail("", "*** CSV ONLY ***", "N", 0, 0, 0)
  AddDetail("ADYR", "AUDIT YEAR", "N", 0, 4, 0)
  AddDetail("DEYEAR", "DECLARATION YEAR", "N", 0, 4, 0)
  AddDetail("DEFIL", "DECLARATION FILING STATUS", "A", 0, 1, 0)
  AddDetail("DESTAT", "DECLARATION APPL STATUS", "A", 0, 1, 0)
  AddDetail("DEEMAIL", "DECLARATION EMAIL", "A", 0, 20, 0)
  AddDetail("DEPHONE", "DECLARATION PHONE", "A", 0, 30, 0)
  AddDetail("DERECVDT", "DECLARATION DATE RECIEVED", "N", 0, 8, 0)
  AddDetail("DESTRDT", "DECLARATION DATE BUSINESS STARTED", "N", 0, 8, 0)
  AddDetail("DESQFEET", "DECLARATION SQ FEET", "A", 0, 7, 0)
  AddDetail("DENOEMPS", "DECLARATION NO. EMPLOYEES", "A", 0, 6, 0)

Done:
  MyPrtLayout = New FrmPrtLayout
  With MyPrtLayout
    .wrkds = ds
    .WrkDesc = "PP Export Fixed Format"
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






