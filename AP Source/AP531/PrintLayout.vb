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

    AddDetail("Empno", "Employee Number", "A", 1, 7, 0)
    AddDetail("PORV", "", "N", 2, 1, 0)
    AddDetail("EmpName", "Employee Name", "A", 3, 40, 0)
    AddDetail("CkNum", "Check Number", "N", 4, 7, 0)
    AddDetail("CkDate", "Ckeck Date (MMDDYY)", "N", 5, 6, 0)
    AddDetail("CkAmt", "Check Amount", "N", 6, 9, 2)
    AddDetail("CkCode", "Check Code", "A", 7, 1, 0)
    AddDetail("Ckdate", "Check Date (MMDDYYYY)", "N", 8, 8, 0)

Done:
    MyPrtLayout = New FrmPrtLayout
    With MyPrtLayout
      .wrkds = ds
      .WrkDesc = "Check History"
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
