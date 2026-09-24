Imports System.io
Imports System.Text
Module PrintLayout

Dim ds As DataSet = New DataSet
Dim dr As DataRow

  Public Sub PrntLayout()
    Dim WrkDesc As String

    If ds.Tables.Count = 0 Then
      BuildDs(ds)
    Else
      ds.Clear()
    End If

    WrkDesc = ""
    If MyFrmGL401B_Import.RbJE.Checked Then
      WrkDesc = "Journal Entries (CSV)"
      AddDetail("Acct", "Account Number", "A", 1, 26, 0)
      AddDetail("Descr", "Acct Description", "A", 2, 20, 0)
      AddDetail("Debit", "Debit Amount", "N", 3, 11, 2)
      AddDetail("Credit", "Credit Amount", "N", 4, 11, 2)
      AddDetail("Date", "Date (MM/DD/YYYY)", "D", 5, 8, 0)
    End If

    If MyFrmGL401B_Import.RbBudget.Checked Then
      WrkDesc = "Budget Entries (CSV)"
      AddDetail("Acct", "Account Number", "A", 1, 26, 0)
      AddDetail("Descr", "Acct Description", "A", 2, 20, 0)
      AddDetail("Debit", "Debit Amount", "N", 3, 11, 2)
      AddDetail("Credit", "Credit Amount", "N", 4, 11, 2)
      AddDetail("Date", "Date (MM/DD/YYYY)", "D", 5, 8, 0)
    End If

    If MyFrmGL401B_Import.RbPRPaycor.Checked Then
      WrkDesc = "Paycor (CSV)"
      AddDetail("Acct", "Account Number", "A", 1, 26, 0)
      AddDetail("Descr", "Acct Description", "A", 2, 20, 0)
      AddDetail("Debit", "Debit Amount", "N", 3, 11, 2)
      AddDetail("Credit", "Credit Amount", "N", 4, 11, 2)
      AddDetail("Date", "Date (MM/DD/YYYY)", "D", 5, 8, 0)
    End If

    If MyFrmGL401B_Import.RbPRJE.Checked Then
      WrkDesc = "Payroll (CSV)"
      AddDetail("Seqno", "Seqence", "N", 1, 4, 0)
      AddDetail("Date", "Date (MM/DD/YY)", "N", 2, 6, 0)
      AddDetail("Fund", "Fund", "N", 3, 3, 0)
      AddDetail("Dept", "Fund", "N", 4, 4, 0)
      AddDetail("Object", "Object", "N", 5, 3, 0)
      AddDetail("Fnpgm", "Function", "N", 6, 4, 0)
      AddDetail("Subfn", "Subfunction", "N", 7, 4, 0)
      AddDetail("Debit", "Debit Amount", "N", 8, 11, 2)
      AddDetail("Credit", "Credit Amount", "N", 9, 11, 2)
      AddDetail("Refno", "Reference", "N", 10, 7, 0)
      AddDetail("Descr", "Acct Description", "A", 11, 20, 0)
    End If

Done:
    MyPrtLayout = New FrmPrtLayout
    With MyPrtLayout
      .wrkds = ds
      .WrkDesc = WrkDesc
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
      Case "D"
        dr.Item("fieldtype") = "Date"
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
