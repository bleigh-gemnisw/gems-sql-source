Imports System.io
Imports System.Text
Module PrintLayout

  Dim ds As DataSet = New DataSet
  Dim dr As DataRow

  Public Sub PrntLayout()
    Dim WrkLen As Integer
    If ds.Tables.Count = 0 Then
      BuildDs(ds)
    Else
      ds.Clear()
    End If

    If MyList7 Then
      WrkLen = 7
    Else
      WrkLen = 6
    End If
    AddDetail("#LIST#", "LIST NO", "N", 1, WrkLen, 0)
    AddDetail("#YEAR", "TAX YEAR", "N", WrkLen + 1, 4, 0)
    AddDetail("#TYPE", "TYPE", "A", WrkLen + 5, 1, 0)
    AddDetail("#BKCD", "BANK CODE", "A", WrkLen + 6, 2, 0)
    AddDetail("#TOWN#", "TOWN ID", "N", WrkLen + 8, 3, 0)
    AddDetail("#NAME", "NAME", "A", WrkLen + 11, 35, 0)
    AddDetail("#LOC", "LOCATION NAME", "A", WrkLen + 46, 25, 0)
    AddDetail("#LOC#", "LOCATION #", "A", WrkLen + 71, 7, 0)
    AddDetail("#MAP", "MAP/LOT", "A", WrkLen + 78, 17, 0)
    AddDetail("#ICODE", "RECORD CODE", "A", WrkLen + 95, 1, 0)
    AddDetail("#CEST", "C OF C Y/N", "A", WrkLen + 96, 1, 0)
    AddDetail("#TAXT", "TOTAL TAX", "N", WrkLen + 97, 11, 2)
    AddDetail("#TAX1", "TAX 1ST HALF", "N", WrkLen + 108, 11, 2)
    AddDetail("#TAX2", "TAX 2ND HALF", "N", WrkLen + 119, 11, 2)
    AddDetail("#TAX3", "TAX 3RD QTR", "N", WrkLen + 130, 11, 2)
    AddDetail("#TAX4", "TAX 4TH QTR", "N", WrkLen + 141, 11, 2)
    AddDetail("#BALD", "BALANCE DUE", "N", WrkLen + 152, 9, 2)
    AddDetail("#GROSS", "GROSS ASSESSMENT", "N", WrkLen + 161, 9, 0)
    AddDetail("#TEXMP", "TOTAL EXEMPTION", "N", WrkLen + 170, 9, 0)
    AddDetail("#NET", "NET ASSESSMENT", "N", WrkLen + 179, 9, 0)
    AddDetail("#VOL", "VOLUME", "A", WrkLen + 188, 5, 0)
    AddDetail("#IPAGE", "PAGE", "A", WrkLen + 193, 5, 0)
    AddDetail("#FRCD", "ELDERLY CODE F/C", "A", WrkLen + 198, 1, 0)
    AddDetail("INSTAL", "INSTALLMENT", "A", WrkLen + 199, 1, 0)

Done:
    MyPrtLayout = New FrmPrtLayout
    With MyPrtLayout
      .wrkds = ds
      .WrkDesc = "Bank Service (Bankbill)"
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






