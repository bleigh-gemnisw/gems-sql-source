Imports System.io
Imports System.Text
Module PrintLayout

Dim ds As DataSet = New DataSet
Dim dr As DataRow

  Public Sub PrntLayout(ByVal pFormat As String)

  If ds.Tables.Count = 0 Then
    BuildDs(ds)
  Else
    ds.Clear()
  End If

  Select Case pFormat
  Case "Original", "Extended"
    AddDetail("#LISTA", "LIST#", "A", 1, 6, 0)
    AddDetail("YEAR", "TAX YEAR", "N", 7, 4, 0)
    AddDetail("TYPE", "TYPE", "A", 11, 1, 0)
    AddDetail("NAME", "NAME", "A", 12, 35, 0)
    AddDetail("SNAME", "SECOND NAME", "A", 47, 35, 0)
    AddDetail("ADD1", "ADDRESS 1", "A", 82, 35, 0)
    AddDetail("ADD2", "ADDRESS 2", "A", 117, 35, 0)
    AddDetail("CITY", "CITY", "A", 152, 25, 0)
    AddDetail("STATE", "STATE", "A", 177, 2, 0)
    AddDetail("ZIP5A", "ZIP CODE 5", "A", 179, 5, 0)
    AddDetail("ZIP4A", "ZIP CODE 4", "A", 184, 4, 0)
    AddDetail("@BALD", "BALANCE DUE", "N", 188, 9, 2)
    AddDetail("#TAX", "TAX TOTAL", "N", 197, 11, 2)
    AddDetail("#PAID", "PAYMENTS RECEIVED", "N", 208, 11, 2)
    AddDetail("#RTAX", "REMAINING TAX BASE", "N", 219, 11, 2)
    AddDetail("#RTAX1", "REMAINING 1ST PAYMENT", "N", 230, 11, 2)
    AddDetail("#RTAX2", "REMAINING 2ND PAYMENT", "N", 241, 11, 2)
    AddDetail("#RTAX3", "REMAINING 3RD PAYMENT", "N", 252, 11, 2)
    AddDetail("#RTAX4", "REMAINING 4TH PAYMENT", "N", 263, 11, 2)
    AddDetail("#INT", "INTEREST", "N", 274, 11, 2)
    AddDetail("#LIN", "LIEN", "N", 285, 5, 2)
    AddDetail("#PENDU", "BOND INTEREST DUE", "N", 290, 11, 2)
    AddDetail("TXIDT", "PAYMENT DATE", "N", 301, 8, 0)
    AddDetail("VOL", "VOLUME", "A", 309, 5, 0)
    AddDetail("IPAGE", "PAGE", "A", 314, 5, 0)
    AddDetail("LOC#", "LOCATION #", "A", 319, 7, 0)
    AddDetail("LOC", "LOCATION NAME", "A", 326, 25, 0)
    AddDetail("MAP", "MAP/LOT", "A", 351, 17, 0)
    AddDetail("DIST", "DISTRICT", "N", 368, 3, 0)
    AddDetail("#GROSS", "GROSS", "N", 371, 9, 0)
    AddDetail("#TOTEX", "TOTAL EXEMPTIONS", "N", 380, 9, 0)
    AddDetail("#NETA", "NET", "N", 389, 9, 0)
    AddDetail("LIEN", "LIEN CODE", "A", 398, 1, 0)
    AddDetail("SUSCD", "REASON CODE", "A", 399, 1, 0)
    AddDetail("SUSDT", "SUSPENSE DATE", "N", 400, 8, 0)
    AddDetail("CCNO", "C OF C NO", "N", 408, 5, 0)
    AddDetail("#CGRS", "C OF E GROSS", "N", 413, 9, 0)
    AddDetail("#CCEXP", "C OF E EXEMPTIONS", "N", 422, 9, 0)
    AddDetail("CDATE", "C OF C DATE", "N", 431, 8, 0)
    AddDetail("CCRSN", "REASON CODE", "A", 439, 1, 0)
    AddDetail("BKSR", "BANK SERVICE CODE", "A", 440, 1, 0)
    AddDetail("BKCD", "BANK CODE", "A", 441, 2, 0)
    AddDetail("IPPCD1", "PROPERTY CODE 1", "N", 443, 3, 0)
    AddDetail("IPPCD2", "PROPERTY CODE 2", "N", 446, 3, 0)
    AddDetail("IPPCD3", "PROPERTY CODE 3", "N", 449, 3, 0)
    AddDetail("IPPCD4", "PROPERTY CODE 4", "N", 452, 3, 0)
    AddDetail("IPPCD5", "PROPERTY CODE 5", "N", 455, 3, 0)
    AddDetail("IPPCD6", "PROPERTY CODE 6", "N", 458, 3, 0)
    AddDetail("IPPCD7", "PROPERTY CODE 7", "N", 461, 3, 0)
    AddDetail("IPPCD8", "PROPERTY CODE 8", "N", 464, 3, 0)
    AddDetail("IPPCD9", "PROPERTY CODE 9", "N", 467, 3, 0)
    AddDetail("IPPCDA", "PROPERTY CODE 10", "N", 470, 3, 0)
    AddDetail("DOB", "DOB", "N", 473, 8, 0)
    AddDetail("#OAS1", "ASSESSMENT AMT 1", "N", 481, 9, 0)
    AddDetail("#OAS2", "ASSESSMENT AMT 2", "N", 490, 9, 0)
    AddDetail("#OAS3", "ASSESSMENT AMT 3", "N", 499, 9, 0)
    AddDetail("#OAS4", "ASSESSMENT AMT 4", "N", 508, 9, 0)
    AddDetail("#OAS5", "ASSESSMENT AMT 5", "N", 517, 9, 0)
    AddDetail("#OAS6", "ASSESSMENT AMT 6", "N", 526, 9, 0)
    AddDetail("#OAS7", "ASSESSMENT AMT 7", "N", 535, 9, 0)
    AddDetail("#OAS8", "ASSESSMENT AMT 8", "N", 544, 9, 0)
    AddDetail("#OAS9", "ASSESSMENT AMT 9", "N", 553, 9, 0)
    AddDetail("#OAS10", "ASSESSMENT AMT 10", "N", 562, 9, 0)
    AddDetail("#CASS1", "C OF E ASS AMT 1", "N", 571, 9, 0)
    AddDetail("#CASS2", "C OF E ASS AMT 2", "N", 580, 9, 0)
    AddDetail("#CASS3", "C OF E ASS AMT 3", "N", 589, 9, 0)
    AddDetail("#CASS4", "C OF E ASS AMT 4", "N", 598, 9, 0)
    AddDetail("#CASS5", "C OF E ASS AMT 5", "N", 607, 9, 0)
    AddDetail("#CASS6", "C OF E ASS AMT 6", "N", 616, 9, 0)
    AddDetail("#CASS7", "C OF E ASS AMT 7", "N", 625, 9, 0)
    AddDetail("#CASS8", "C OF E ASS AMT 8", "N", 634, 9, 0)
    AddDetail("#CASS9", "C OF E ASS AMT 9", "N", 643, 9, 0)
    AddDetail("#CASSA", "C OF E ASS AMT 10", "N", 652, 9, 0)
    AddDetail("#UNIT1", "UNIT 1", "N", 661, 3, 0)
    AddDetail("#UNIT2", "UNIT 2", "N", 664, 3, 0)
    AddDetail("#UNIT3", "UNIT 3", "N", 667, 3, 0)
    AddDetail("#UNIT4", "UNIT 4", "N", 670, 3, 0)
    AddDetail("#UNIT5", "UNIT 5", "N", 673, 3, 0)
    AddDetail("#UNIT6", "UNIT 6", "N", 676, 3, 0)
    AddDetail("#UNIT7", "UNIT 7", "N", 679, 3, 0)
    AddDetail("#UNIT8", "UNIT 8", "N", 682, 3, 0)
    AddDetail("#UNIT9", "UNIT 9", "N", 685, 3, 0)
    AddDetail("#UNITA", "UNIT 10", "N", 688, 3, 0)
    AddDetail("EXCD1", "EXEMPTION CODE1", "A", 691, 3, 0)
    AddDetail("EXCD2", "EXEMPTION CODE2", "A", 694, 3, 0)
    AddDetail("EXCD3", "EXEMPTION CODE3", "A", 697, 3, 0)
    AddDetail("EXCD4", "EXEMPTION CODE4", "A", 700, 3, 0)
    AddDetail("EXCD5", "EXEMPTION CODE5", "A", 703, 3, 0)
    AddDetail("EXCD6", "EXEMPTION CODE6", "A", 706, 3, 0)
    AddDetail("EXCD7", "EXEMPTION CODE7", "A", 709, 3, 0)
    AddDetail("#EXAM1", "EXEMPTION AMT 1", "N", 712, 7, 0)
    AddDetail("#EXAM2", "EXEMPTION AMT 2", "N", 719, 7, 0)
    AddDetail("#EXAM3", "EXEMPTION AMT 3", "N", 726, 7, 0)
    AddDetail("#EXAM4", "EXEMPTION AMT 4", "N", 733, 7, 0)
    AddDetail("#EXAM5", "EXEMPTION AMT 5", "N", 740, 7, 0)
    AddDetail("#EXAM6", "EXEMPTION AMT 6", "N", 747, 7, 0)
    AddDetail("#EXAM7", "EXEMPTION AMT 7", "N", 754, 7, 0)
    AddDetail("CCCD1", "C OF C EXEMPTION CODE1", "A", 761, 3, 0)
    AddDetail("CCCD2", "C OF C EXEMPTION CODE2", "A", 764, 3, 0)
    AddDetail("CCCD3", "C OF C EXEMPTION CODE3", "A", 767, 3, 0)
    AddDetail("CCCD4", "C OF C EXEMPTION CODE4", "A", 770, 3, 0)
    AddDetail("CCCD5", "C OF C EXEMPTION CODE5", "A", 773, 3, 0)
    AddDetail("CCCD6", "C OF C EXEMPTION CODE6", "A", 776, 3, 0)
    AddDetail("CCCD7", "C OF C EXEMPTION CODE7", "A", 779, 3, 0)
    AddDetail("#CEXA1", "C-E EXMPT AMT 1", "N", 782, 7, 0)
    AddDetail("#CEXA2", "C-E EXMPT AMT 2", "N", 789, 7, 0)
    AddDetail("#CEXA3", "C-E EXMPT AMT 3", "N", 796, 7, 0)
    AddDetail("#CEXA4", "C-E EXMPT AMT 4", "N", 803, 7, 0)
    AddDetail("#CEXA5", "C-E EXMPT AMT 5", "N", 810, 7, 0)
    AddDetail("#CEXA6", "C-E EXMPT AMT 6", "N", 817, 7, 0)
    AddDetail("#CEXA7", "C-E EXMPT AMT 7", "N", 824, 7, 0)
    AddDetail("ASS", "ASSESSMENT CODE", "A", 831, 1, 0)
    AddDetail("#INTP", "TOTAL INTEREST PAID", "N", 832, 7, 2)
    AddDetail("#PINTP", "PARTIAL INTEREST PAID", "N", 839, 7, 2)
    AddDetail("#LIENP", "LIEN PAID", "N", 846, 5, 2)
    AddDetail("#BONDP", "BOND PAID", "N", 851, 9, 2)
    AddDetail("STCD1", "STATUS CODE1", "A", 860, 1, 0)
    AddDetail("STCD2", "STATUS CODE2", "A", 861, 1, 0)
    AddDetail("STCD3", "STATUS CODE3", "A", 862, 1, 0)
    AddDetail("STCD4", "STATUS CODE4", "A", 863, 1, 0)
    AddDetail("STCD5", "STATUS CODE5", "A", 864, 1, 0)
  Case "MailSol"
    AddDetail("NAME", "NAME", "A", 1, 35, 0)
    AddDetail("SNAME", "SECOND NAME", "A", 36, 35, 0)
    AddDetail("ADDR1", "ADDRESS 1", "A", 71, 35, 0)
    AddDetail("CITY", "CITY", "A", 106, 25, 0)
    AddDetail("STATE", "STATE", "A", 131, 3, 0)
    AddDetail("ZIP", "ZIP CODE 5", "A", 134, 6, 0)
    AddDetail("YEAR", "TAX YEAR", "N", 140, 4, 0)
    AddDetail("BILLTY", "TYPE", "A", 144, 2, 0)
    AddDetail("LIST", "LIST#", "A", 146, 8, 0)
    AddDetail("----", "--MV--", "N", 154, 0, 0)
    AddDetail("MAKE", "MAKE", "N", 154, 6, 0)
    AddDetail("MODEL", "MODEL", "N", 160, 9, 0)
    AddDetail("MVYR", "MV YEAR", "N", 169, 4, 0)
    AddDetail("CLASS", "CLASS", "N", 173, 2, 0)
    AddDetail("REGNO", "REGNO", "N", 175, 8, 0)
    AddDetail("VINNO", "VIN NO", "N", 183, 17, 0)
    AddDetail("----", "--ALT--", "N", 154, 0, 0)
    AddDetail("LOC", "PROP LOC", "A", 154, 30, 0)
    AddDetail("FILL", "FILLER", "A", 184, 16, 0)
    AddDetail("TAX", "TAX", "N", 200, 11, 2)
    AddDetail("INT", "INTEREST", "N", 211, 11, 2)
    AddDetail("LIEN", "LIEN/FEES", "N", 222, 11, 2)
    AddDetail("TOTAL", "TOTAL DUE", "N", 233, 13, 2)
    AddDetail("VALUE", "LIST VALUE", "N", 246, 10, 2)
  End Select

  If pFormat = "Extended" Then
    AddDetail("FEES", "FEES", "N", 865, 9, 2)
    AddDetail("REGNO", "REGNO", "N", 874, 8, 0)
    AddDetail("MAKE", "MAKE", "N", 882, 5, 0)
    AddDetail("MODEL", "MODEL", "N", 887, 8, 0)
    AddDetail("MVYR", "MV YEAR", "N", 895, 4, 0)
    AddDetail("CLASS", "CLASS", "N", 899, 2, 0)
    AddDetail("VINNO", "VIN NO", "N", 901, 17, 0)
  End If

Done:
  MyPrtLayout = New FrmPrtLayout
  With MyPrtLayout
    .wrkds = ds
  .WrkDesc = "DQBILL"
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






