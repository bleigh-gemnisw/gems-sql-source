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

    If MyFrmTXA02B.RbNormal.Checked Or MyFrmTXA02B.RbTaxServ.Checked Then
      AddDetail("List", "List Number", "N", 1, 7, 0)
      AddDetail("Year", "Grand List Year", "N", 8, 2, 0)
      AddDetail("Type", "Tax Type", "A", 10, 1, 0)
      AddDetail("Paid", "Amount Paid", "N", 11, 11, 2)
      AddDetail("Interest", "Interest Paid", "N", 22, 9, 2)
      AddDetail("Lien", "Lien Paid", "N", 31, 5, 2)
      AddDetail("Ref", "Reference", "A", 50, 11, 0)
    End If
    If MyFrmTXA02B.RbNon.Checked Then
      AddDetail("Year", "Grand List Year", "N", 1, 2, 0)
      AddDetail("Type", "Tax Type", "A", 3, 1, 0)
      AddDetail("List", "List Number", "N", 4, 6, 0)
      AddDetail("Dist", "District", "N", 10, 3, 0)
      AddDetail("Name", "Partial Name", "A", 13, 4, 0)
      AddDetail("Filler1", "Filler 1", "A", 17, 1, 0)
      AddDetail("Paid", "Amount Paid", "N", 18, 9, 2)
      AddDetail("Paid2", "Amount Paid 2", "N", 27, 9, 2)
      AddDetail("Filler2", "Filler 2", "A", 36, 1, 0)
      AddDetail("Delq", "Delq", "A", 37, 37, 0)
    End If
    If MyFrmTXA02B.RbChase.Checked Then
      AddDetail("Year", "Grand List Year", "N", 1, 2, 0)
      AddDetail("Type", "Tax Type", "A", 3, 1, 0)
      AddDetail("List", "List Number", "N", 4, 6, 0)
      AddDetail("Dist", "District", "N", 10, 3, 0)
      AddDetail("Name", "Partial Name", "A", 13, 4, 0)
      AddDetail("Filler1", "Filler", "A", 17, 1, 0)
      AddDetail("Paid", "Amount Paid", "N", 18, 18, 2)
    End If
    If MyFrmTXA02B.RbAmerica.Checked Then
      AddDetail("RecTyp", "Record Type", "A", 1, 1, 0)
      AddDetail("Type", "Tax Type", "A", 2, 1, 0)
      AddDetail("List", "List Number", "N", 6, 6, 0)
      AddDetail("Filler1", "Filler 1", "A", 12, 6, 0)
      AddDetail("Paid", "Amount Paid", "N", 18, 8, 2)
    End If
    If MyFrmTXA02B.RbWebster.Checked Then
      AddDetail("RecTyp", "Record Type", "A", 1, 1, 0)
      AddDetail("Year", "Grand List Year", "N", 6, 4, 0)
      AddDetail("Type", "Tax Type", "N", 10, 1, 0)
      AddDetail("List", "List Number", "N", 11, 7, 0)
      AddDetail("Paid", "Amount Paid", "N", 18, 12, 2)
    End If

Done:
    MyPrtLayout = New FrmPrtLayout
    With MyPrtLayout
      .wrkds = ds
      .WrkDesc = "Bank Receipts"
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






