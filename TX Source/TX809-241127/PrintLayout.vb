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

    AddDetail("#LIST#", "LIST NO", "N", 1, 7, 0)
    AddDetail("YEAR", "TAX YEAR", "N", 2, 4, 0)
    AddDetail("TYPE", "TYPE", "A", 3, 1, 0)
    AddDetail("NAME", "NAME", "A", 4, 35, 0)
    AddDetail("REGNO", "REG NO", "A", 5, 8, 0)
    AddDetail("VIN", "VEHICLE ID", "A", 6, 17, 0)
    AddDetail("MAKE", "MAKE", "A", 7, 8, 0)
    AddDetail("MODEL", "MODEL", "A", 8, 6, 0)
    AddDetail("MVYR", "MV YEAR", "N", 9, 4, 0)
    AddDetail("AMTDUE", "AMOUNT DUE", "N", 10, 11, 2)
    AddDetail("NETASS", "NET ASSESSMENT", "N", 11, 9, 0)
    AddDetail("ASSCD", "ASSESSMENT CODE", "A", 12, 1, 0)

Done:
    MyPrtLayout = New FrmPrtLayout
    With MyPrtLayout
      .wrkds = ds
      .WrkDesc = "Leasing Company"
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






