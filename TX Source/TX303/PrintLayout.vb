Imports System.io
Imports System.Text
Module PrintLayout

Dim ds As DataSet = New DataSet
Dim dr As DataRow

  Public Sub PrntLayout()

    If ds.Tables.Count = 0 Then
      BuildDsLay(ds)
    Else
      ds.Clear()
    End If

    AddDetail("BLNAM", "NAME", "A", 1, 35, 0)
    AddDetail("BLNAMS", "SECOND NAME", "A", 36, 35, 0)
    AddDetail("BLADD1", "ADDRESS 1", "A", 71, 35, 0)
    AddDetail("BLADD2", "ADDRESS 2", "A", 106, 35, 0)
    AddDetail("BLCITY", "CITY", "A", 141, 25, 0)
    AddDetail("BLST", "STATE", "A", 166, 2, 0)
    AddDetail("BLZIP5", "ZIP CODE", "N", 168, 5, 0)
    AddDetail("BLZIP4", "ZIP PLUS4", "N", 173, 4, 0)
    AddDetail("BLLIST", "LIST NO", "N", 177, 6, 0)
    AddDetail("BLYEAR", "TAX YEAR", "N", 183, 4, 0)
    AddDetail("BLTYPE", "TYPE", "A", 187, 1, 0)
    AddDetail("BLDESC", "BILL DESCRIPTION", "A", 188, 17, 0)
    AddDetail("BLAMTD", "BALANCE DUE", "N", 205, 9, 2)
    AddDetail("BLINTZ", "INTEREST", "N", 214, 11, 2)
    AddDetail("BLLIN", "LIEN CODE", "A", 225, 1, 0)
    AddDetail("BLBALD", "BALANCE DUE", "N", 226, 9, 2)
    AddDetail("BLCAL", "CALC (Not used)", "A", 235, 1, 0)
    AddDetail("BLTOTD", "BALANCE DUE", "N", 236, 9, 2)
    AddDetail("BLDETL", "DETL (Not Used)", "A", 245, 1, 0)
    AddDetail("BLMOI", "INTEREST MONTH", "A", 246, 2, 0)
    AddDetail("BLDAI", "INTEREST DAY", "A", 248, 2, 0)
    AddDetail("BLYRI", "INTEREST YEAR", "A", 250, 4, 0)
    AddDetail("BLVOL", "VOLUME", "A", 254, 5, 0)
    AddDetail("BLPAGE", "PAGE", "A", 259, 5, 0)
    AddDetail("BLMAP", "MAP/LOT", "A", 264, 17, 0)
    AddDetail("BLCODE", "B = BACK TAX", "A", 281, 1, 0)
    AddDetail("BLMOC", "COMP MONTH", "A", 282, 2, 0)
    AddDetail("BLDAC", "COMP DAY", "A", 284, 2, 0)
    AddDetail("BLYRC", "COMP YEAR", "A", 286, 4, 0)
    AddDetail("BLLIA", "LIEN AMT", "N", 290, 9, 2)
    AddDetail("BLDUE1", "DUE DATE1", "N", 299, 8, 0)
    AddDetail("BLMMM", "MONTH", "A", 307, 3, 0)
    AddDetail("BLDIS", "DISTRICT", "N", 310, 3, 0)
    AddDetail("BLBCD", "BANK CODE", "A", 313, 2, 0)
    AddDetail("BLGRS", "GROSS ASSMNT", "N", 315, 9, 0)
    AddDetail("BLEXE", "EXEMPTION", "N", 324, 9, 0)
    AddDetail("BLNAS", "NET ASSMNT", "N", 333, 9, 0)
    AddDetail("BLPYR", "PAYMENTS RECEIVED", "N", 342, 11, 2)
    AddDetail("BLUPO", "UNPOSTED PAYMENTS", "N", 353, 11, 2)
    AddDetail("BLMRT", "Mill Rate", "N", 364, 6, 6)
    AddDetail("BLFRT", "Fire Mill Rate", "N", 370, 6, 6)
    AddDetail("BLTOT1", "ORIG BILL", "N", 376, 11, 2)
    AddDetail("BLDSC", "PROPERTY DESCRIPTION", "A", 387, 20, 0)
    AddDetail("CITYMR", "CITY MILL RT", "N", 407, 6, 3)
    AddDetail("FIREMR", "FIRE MILL RT", "N", 413, 6, 3)
    AddDetail("TAXA", "CITY TAX DUE", "N", 419, 9, 2)
    AddDetail("TAXB", "FIRE TAX DUE", "N", 428, 9, 2)
    AddDetail("AZIP5", "ZIP 5 ALPH", "A", 437, 5, 0)
    AddDetail("AZIP4", "ZIP 4 ALPH", "A", 442, 4, 0)
    AddDetail("ADUE8", "DUE DATE", "A", 446, 8, 0)
    AddDetail("**", "CSV Only", "A", 0, 0, 0)
    AddDetail("STCD1", "Status Code 1", "A", 0, 1, 0)
    AddDetail("STCD2", "Status Code 2", "A", 0, 1, 0)
    AddDetail("STCD3", "Status Code 3", "A", 0, 1, 0)
    AddDetail("STCD4", "Status Code 4", "A", 0, 1, 0)
    AddDetail("STCD5", "Status Code 5", "A", 0, 1, 0)
    AddDetail("FEES", "Fees", "A", 0, 9, 2)

Done:
    MyPrtLayout = New FrmPrtLayout
    With MyPrtLayout
      .wrkds = ds
      .WrkDesc = "DelqBill (Fixed Length)"
      .Show()
    End With

  End Sub
  Private Sub BuildDsLay(ByRef Ds As DataSet)
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






