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

    If MyFrmAP530B.RbAP.Checked Then
      AddDetail("ChkNo", "Check Number", "N", 1, 10, 0)
      AddDetail("Amount", "Amount", "N", 11, 11, 2)
      AddDetail("DtIssue", "Issue Date (YYMMDD)", "N", 22, 6, 0)
      AddDetail("DtPaid", "Paid Date (YYMMDD)", "N", 28, 6, 0)
      AddDetail("Acct", "Acct Number", "N", 34, 12, 0)
      AddDetail("Recon", "Reconcile=R", "N", 46, 1, 0)
      AddDetail("Name", "Vendor Name", "A", 47, 50, 0)
    End If
    If MyFrmAP530B.RbWebster.Checked Then
      AddDetail("ChkNo", "Check Number", "N", 22, 10, 0)
      AddDetail("Amount", "Amount", "N", 51, 10, 2)
      AddDetail("DtIssue", "Issue Date (MMDDYY)", "N", 32, 6, 0)
      AddDetail("DtPaid", "Paid Date (MMDDYY)", "N", 38, 6, 0)
    End If

Done:
  MyPrtLayout = New FrmPrtLayout
  With MyPrtLayout
    .wrkds = ds
    .WrkDesc = "Reconcile Checks From Bank"
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
