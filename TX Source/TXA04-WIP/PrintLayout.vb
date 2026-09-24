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

    If MyFrmTXA04B.ChkYear4.Checked Then
      AddDetail("List", "List Number", "N", 1, WrkLen, 0)
      AddDetail("Year", "Grand List Year", "N", WrkLen + 1, 4, 0)
      AddDetail("Type", "Tax Type", "A", WrkLen + 5, 1, 0)
      AddDetail("Paid", "Amount Paid", "N", WrkLen + 6, 11, 2)
      AddDetail("Filler", "Filler", "A", WrkLen + 17, 6, 0)
      AddDetail("BankCD", "Bank Code", "A", WrkLen + 23, 2, 0)
    Else
      AddDetail("List", "List Number", "N", 1, WrkLen, 0)
      AddDetail("Year", "Grand List Year", "N", WrkLen + 1, 2, 0)
      AddDetail("Type", "Tax Type", "A", WrkLen + 3, 1, 0)
      AddDetail("Paid", "Amount Paid", "N", WrkLen + 4, 11, 2)
      AddDetail("Filler", "Filler", "A", WrkLen + 15, 6, 0)
      AddDetail("BankCD", "Bank Code", "A", WrkLen + 21, 2, 0)
    End If
Done:
    MyPrtLayout = New FrmPrtLayout
    With MyPrtLayout
      .wrkds = ds
      .WrkDesc = "Bank Services"
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






