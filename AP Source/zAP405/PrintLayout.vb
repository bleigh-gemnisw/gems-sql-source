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

  WrkDesc = String.Empty
  If MyFrmAP405B.RbAP.Checked Then
  End If

  If MyFrmAP405B.RbAPTD.Checked Then
    WrkDesc = "A/P TD Bank"
    AddDetail("BANKID", "0004", "N", 1, 4, 0)
    AddDetail("ACCTID", "02", "N", 5, 2, 0)
    AddDetail("ACCT", "ACCT NO", "N", 7, 16, 0)
    AddDetail("DEPOSIT", "60", "N", 23, 2, 0)
    AddDetail("PAYCK", "CHECK NO", "N", 25, 10, 0)
    AddDetail("PAYAM", "AMOUNT", "N", 35, 11, 0)
    AddDetail("VENDOR", "VENDOR", "A", 46, 30, 0)
    AddDetail("PAYP8", "YEAR", "N", 76, 4, 0)
    AddDetail("DAY", "DAY OF YEAR", "N", 80, 3, 0)
    AddDetail("CODE", "10=ISSUE, 11=VOID", "N", 83, 2, 0)
  End If

  If MyFrmAP405B.RbAPBOA.Checked Then
    WrkDesc = "A/P BOA"
    AddDetail("PAYCK", "CHECK NO", "N", 1, 10, 0)
    AddDetail("PAYAM", "AMOUNT", "N", 11, 11, 0)
    AddDetail("PAYP8", "DATE (YYMMDD)", "N", 22, 6, 0)
    AddDetail("FILL1", "FILLER", "A", 28, 6, 0)
    AddDetail("ACCT", "ACCT NO", "A", 34, 12, 0)
    AddDetail("VENDOR", "VENDOR", "A", 46, 35, 0)
  End If

  If MyFrmAP405B.RbAPWebster.Checked Then
    WrkDesc = "A/P Webster"
    AddDetail("ACCT", "ACCT NO", "A", 1, 10, 0)
    AddDetail("PAYCK", "CHECK NO", "N", 11, 10, 0)
    AddDetail("CODE", " =ISSUE", "N", 21, 1, 0)
    AddDetail("PAYAM", "AMOUNT", "N", 22, 12, 0)
    AddDetail("PAYP8", "DATE (MMDDYY)", "N", 34, 6, 0)
    AddDetail("PAYEE1", "PAYEE LINE 1", "A", 40, 50, 0)
    AddDetail("PAYEE2", "PAYEE LINE 2", "A", 90, 50, 0)
    AddDetail("PAYEE3", "PAYEE LINE 3", "A", 140, 50, 0)
  End If

  If MyFrmAP405B.RbPRBOA.Checked Then
    WrkDesc = "P/R BOA"
    AddDetail("PAYCK", "CHECK NO", "N", 1, 10, 0)
    AddDetail("PAYAM", "AMOUNT", "N", 11, 11, 0)
    AddDetail("PAYP8", "DATE (YYMMDD)", "N", 22, 6, 0)
    AddDetail("FILL1", "FILLER", "A", 28, 6, 0)
    AddDetail("ACCT", "ACCT NO", "A", 34, 10, 0)
    AddDetail("CODE", "O=ISSUE, V=VOID", "N", 44, 1, 0)
  End If


  If MyFrmAP405B.RbPRBOAShort.Checked Then
    WrkDesc = "P/R BOA"
    AddDetail("PAYCK", "CHECK NO", "N", 1, 10, 0)
    AddDetail("PAYAM", "AMOUNT", "N", 11, 11, 0)
    AddDetail("PAYP8", "DATE (YYMMDD)", "N", 22, 6, 0)
    AddDetail("FILL1", "FILLER", "A", 28, 6, 0)
    AddDetail("ACCT", "ACCT NO", "A", 34, 12, 0)
    AddDetail("CODE", "O=ISSUE, V=VOID", "N", 46, 1, 0)
    AddDetail("EMPNAM", "EMPLOYEE NAME", "A", 34, 20, 0)
  End If

  If MyFrmAP405B.RbAPWebster.Checked Then
    WrkDesc = "P/R Webster"
    AddDetail("ACCT", "ACCT NO", "A", 1, 10, 0)
    AddDetail("PAYCK", "CHECK NO", "N", 11, 10, 0)
    AddDetail("CODE", " =ISSUE", "N", 21, 1, 0)
    AddDetail("PAYAM", "AMOUNT", "N", 22, 12, 0)
    AddDetail("PAYP8", "DATE (MMDDYY)", "N", 34, 6, 0)
    AddDetail("PAYEE1", "PAYEE LINE 1", "A", 40, 50, 0)
    AddDetail("PAYEE2", "PAYEE LINE 2", "A", 90, 50, 0)
    AddDetail("PAYEE3", "PAYEE LINE 3", "A", 140, 50, 0)
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
