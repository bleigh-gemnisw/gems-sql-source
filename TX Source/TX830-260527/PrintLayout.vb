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

	AddDetail("", "--- HEADER FILE ---", "", 0, 0, 0)
  AddDetail("TOWNBR", "TOWN NUMBER (0=Non Public)", "N", 1, 3, 0)
	AddDetail("LISTNO", "LIST NO", "N", 4, 6, 0)
  AddDetail("YEAR", "TAX YEAR", "N", 10, 4, 0)
	AddDetail("TYPE", "TAX TYPE", "N", 14, 1, 0)
	AddDetail("TYPEDS", "TYPE DESCRIPTION", "A", 15, 25, 0)
	AddDetail("NAME", "NAME", "A", 40, 35, 0)
	AddDetail("SNAME", "SECOND NAME", "A", 75, 35, 0)
	AddDetail("ADD1", "ADDRESS 1", "A", 110, 35, 0)
	AddDetail("ADD2", "ADDRESS 2", "A", 145, 35, 0)
	AddDetail("CITY", "CITY", "A", 180, 25, 0)
	AddDetail("STATE", "STATE", "A", 205, 2, 0)
	AddDetail("ZIP5", "ZIP CODE", "N", 207, 5, 0)
	AddDetail("ZIP4", "ZIP PLUS4", "N", 212, 4, 0)
	AddDetail("LOCNO", "LOCATION #", "A", 216, 7, 0)
	AddDetail("LOC", "LOCATION NAME", "A", 223, 25, 0)
	AddDetail("IMVREG", "REG NO", "A", 248, 8, 0)
	AddDetail("DESCR", "PROPERTY DESC", "A", 256, 30, 0)
	AddDetail("PAMTD", "PRINCIPAL DUE", "N", 286, 11, 2)
	AddDetail("IAMTD", "INTEREST DUE", "N", 297, 7, 2)
	AddDetail("FEESD", "FEES DUE", "N", 304, 9, 2)
	AddDetail("LAMTD", "LIEN DUE", "N", 313, 5, 2)
	AddDetail("PCAMTD", "PENALTY DUE", "N", 318, 9, 2)
	AddDetail("AMTD", "AMOUNT DUE", "N", 327, 11, 2)
	AddDetail("TOTPAY", "TOTAL PAID", "N", 338, 11, 2)
	AddDetail("BALANCE", "BALANCE", "N", 349, 11, 2)
	AddDetail("TOTDUE", "TOTAL DUE", "N", 360, 11, 2)
	AddDetail("1STDUE", "1ST DUE", "N", 371, 11, 2)
	AddDetail("2NDDUE", "2ND DUE", "N", 382, 11, 2)
	AddDetail("3RDDUE", "3RD DUE", "N", 393, 11, 2)
	AddDetail("4THDUE", "4TH DUE", "N", 404, 11, 2)
	AddDetail("1STDATE", "1ST DUE DATE", "A", 415, 10, 0)
	AddDetail("2NDDATE", "2ND DUE DATE", "A", 425, 10, 0)
	AddDetail("3RDDATE", "3RD DUE DATE", "A", 435, 10, 0)
	AddDetail("4THDATE", "4TH DUE DATE", "A", 445, 10, 0)
	AddDetail("ACCTID", "ACCT ID", "A", 456, 15, 0)
	AddDetail("ACCTCD", "ACCT CODE", "A", 471, 1, 0)
	AddDetail("UNQID", "UNIQUE ID", "N", 472, 7, 0)
	AddDetail("", "--- DETAIL FILE ---", "", 0, 0, 0)
	AddDetail("LISTNO", "LIST NO", "N", 1, 6, 0)
	AddDetail("YEAR", "TAX YEAR", "N", 7, 4, 0)
	AddDetail("TYPE", "TAX YEAR", "N", 11, 1, 0)
	AddDetail("PAMT", "PRINCIPAL PAID", "N", 12, 11, 2)
	AddDetail("IAMT", "INTEREST PAID", "N", 23, 7, 2)
	AddDetail("LAMT", "LIEN PAID", "N", 30, 5, 2)
	AddDetail("PCAMT", "PENALTY AMOUNT", "N", 35, 9, 2)
	AddDetail("TOTAMT", "TOTAL PAID", "N", 44, 11, 2)
	AddDetail("CORC", "1 - CASH 2 - CHECK 3 - CREDIT", "A", 55, 1, 0)
	AddDetail("ADJCD", "ADJUSTMENT CODE", "A", 56, 1, 0)
	AddDetail("PDATE", "PAYMENT DATE", "N", 57, 8, 0)
	AddDetail("PDATEA", "PAYMENT DATE", "A", 65, 10, 0)
	AddDetail("UNQID", "UNIQUE ID", "N", 75, 7, 0)
Done:
  MyPrtLayout = New FrmPrtLayout
  With MyPrtLayout
    .wrkds = ds
    .WrkDesc = "WEBTAX (Header/Detail)"
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






