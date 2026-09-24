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
  AddDetail("ZIP5X", "ZIP CODE", "A", 175, 5, 0)
  AddDetail("ZIP4X", "ZIP 4", "A", 180, 4, 0)
  AddDetail("LOC", "LOCATION NAME", "A", 184, 25, 0)
  AddDetail("LOC#", "LOCATION #", "A", 209, 7, 0)
  AddDetail("VOL", "VOLUME", "A", 216, 5, 0)
  AddDetail("PGE", "PAGE", "A", 221, 5, 0)
  AddDetail("MAP", "MAP/LOT", "A", 226, 17, 0)
  AddDetail("UNIT#", "UNIT NO", "A", 243, 7, 0)
  AddDetail("GROSS", "GROSS ASSESSMENT", "N", 250, 9, 0)
	AddDetail("ASS1", "ASSESSMENT 1", "N", 259, 9, 0)
	AddDetail("ASS2", "ASSESSMENT 2", "N", 268, 9, 0)
	AddDetail("ASS3", "ASSESSMENT 3", "N", 277, 9, 0)
	AddDetail("ASS4", "ASSESSMENT 4", "N", 286, 9, 0)
	AddDetail("ASS5", "ASSESSMENT 5", "N", 295, 9, 0)
	AddDetail("ASS6", "ASSESSMENT 6", "N", 304, 9, 0)
	AddDetail("ASS7", "ASSESSMENT 7", "N", 313, 9, 0)
  AddDetail("NET", "NET ASSESSMENT", "N", 322, 9, 0)
  AddDetail("DIST", "DISTRICT", "N", 331, 3, 0)
	AddDetail("PYEAR", "(Not Used)", "N", 334, 2, 0)
  AddDetail("CENTR", "CENSUS TRACT", "N", 336, 7, 0)
  AddDetail("PURPR", "PURCHASE PRICE", "N", 343, 9, 0)
  AddDetail("CODE1", "PROPERTY CODE 1", "N", 352, 3, 0)
  AddDetail("CODE2", "PROPERTY CODE 2", "N", 355, 3, 0)
  AddDetail("CODE3", "PROPERTY CODE 3", "N", 358, 3, 0)
  AddDetail("CODE4", "PROPERTY CODE 4", "N", 361, 3, 0)
  AddDetail("CODE5", "PROPERTY CODE 5", "N", 364, 3, 0)
  AddDetail("CODE6", "PROPERTY CODE 6", "N", 367, 3, 0)
  AddDetail("PURDT", "PURCHASE DATE", "N", 370, 8, 0)
	AddDetail("UNIT1", "UNIT 1", "N", 378, 3, 0)
	AddDetail("UNIT2", "UNIT 2", "N", 381, 3, 0)
	AddDetail("UNIT3", "UNIT 3", "N", 384, 3, 0)
	AddDetail("UNIT4", "UNIT 4", "N", 387, 3, 0)
	AddDetail("UNIT5", "UNIT 5", "N", 390, 3, 0)
	AddDetail("UNIT6", "UNIT 6", "N", 393, 3, 0)
	AddDetail("UNIT7", "UNIT 7", "N", 396, 3, 0)
  AddDetail("FCCOD", "ELDERLY CODE F/C", "A", 399, 1, 0)
  AddDetail("FYEAR", "FREEZE YEAR", "N", 400, 2, 0)
  AddDetail("CPERC", "CIRCUIT PERC", "N", 402, 3, 2)
  AddDetail("FTAX", "FROZEN TAX", "N", 405, 7, 2)
  AddDetail("HRTMIN", "CIRCUIT MIN", "N", 412, 5, 2)
	AddDetail("EXCD1", "EXEMPTION CODE 1", "A", 417, 3, 0)
	AddDetail("EXCD2", "EXEMPTION CODE 2", "A", 420, 3, 0)
	AddDetail("EXCD3", "EXEMPTION CODE 3", "A", 423, 3, 0)
	AddDetail("EXCD4", "EXEMPTION CODE 4", "A", 426, 3, 0)
	AddDetail("EXCD5", "EXEMPTION CODE 5", "A", 429, 3, 0)
	AddDetail("EXCD6", "EXEMPTION CODE 6", "A", 432, 3, 0)
	AddDetail("EXCD7", "EXEMPTION CODE 7", "A", 435, 3, 0)
	AddDetail("EXAMT1", "EXEMPTION AMOUNT 1", "N", 438, 7, 0)
	AddDetail("EXAMT2", "EXEMPTION AMOUNT 2", "N", 445, 7, 0)
	AddDetail("EXAMT3", "EXEMPTION AMOUNT 3", "N", 452, 7, 0)
	AddDetail("EXAMT4", "EXEMPTION AMOUNT 4", "N", 459, 7, 0)
	AddDetail("EXAMT5", "EXEMPTION AMOUNT 5", "N", 466, 7, 0)
	AddDetail("EXAMT6", "EXEMPTION AMOUNT 6", "N", 473, 7, 0)
	AddDetail("EXAMT7", "EXEMPTION AMOUNT 7", "N", 480, 7, 0)
  AddDetail("EXMPT1", "EXEMPT CODE", "A", 487, 4, 0)
  AddDetail("ACR#1", "ACREAGE 1", "N", 491, 7, 2)
  AddDetail("ACR#2", "ACREAGE 2", "N", 498, 7, 2)
  AddDetail("ACR#3", "ACREAGE 3", "N", 505, 7, 2)
  AddDetail("ACR#4", "ACREAGE 4", "N", 511, 7, 2)
  AddDetail("ACR#5", "ACREAGE 5", "N", 519, 7, 2)
  AddDetail("ACR#6", "ACREAGE 6", "N", 526, 7, 2)
  AddDetail("ACR#7", "ACREAGE 7", "N", 532, 7, 2)

Done:
  MyPrtLayout = New FrmPrtLayout
  With MyPrtLayout
    .wrkds = ds
    .WrkDesc = "RE Export Fixed Format"
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
