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

    AddDetail("BlBack", "Back Tax?", "A", 1, 1, 0)
    AddDetail("BlAct#", "Account #", "N", 2, 6, 0)
    AddDetail("BlYr", "Year", "N", 8, 4, 0)
    AddDetail("BlType", "Type", "A", 12, 1, 0)
    AddDetail("BlYear", "Assmnt Year #", "N", 13, 4, 0)
    AddDetail("BlSawa", "Sewer/Water", "A", 17, 5, 0)
    AddDetail("BlAdr1", "Address Line 1", "A", 22, 35, 0)
    AddDetail("BlAdr2", "Address Line 2", "A", 57, 35, 0)
    AddDetail("BlAdr3", "Address Line 3", "A", 92, 35, 0)
    AddDetail("BlAdr4", "Address Line 4", "A", 127, 35, 0)
    AddDetail("BlAdr5", "Address Line 5", "A", 162, 35, 0)
    AddDetail("BlVol", "Volume", "A", 197, 5, 0)
    AddDetail("BlPage", "Page", "A", 202, 5, 0)
    AddDetail("BlMap", "Map/Block/Lot", "A", 207, 17, 0)
    AddDetail("BlLoca", "Location", "A", 224, 36, 0)
    AddDetail("BlStdt", "From Service Date", "N", 260, 8, 0)
    AddDetail("BlEndt", "To Service Date", "N", 268, 8, 0)
    AddDetail("BlBil", "Bill Amount", "N", 276, 9, 2)
    AddDetail("BlTbnd", "Bond Interest", "N", 285, 9, 2)
    AddDetail("BlCbal", "Delq Principal", "N", 294, 9, 2)
    AddDetail("BlBilt", "Original Assessment", "N", 303, 9, 2)
    AddDetail("BlPlft", "Assmnt Principal Left", "N", 312, 9, 2)
    AddDetail("BlIamt", "Interest Amount", "N", 321, 11, 2)
    AddDetail("BlLamt", "Lien Amount", "N", 332, 9, 2)
    AddDetail("BlInt", "Monthly Interest Perc", "N", 341, 4, 4)
    AddDetail("BlMin", "Minimum Interest Charge", "N", 345, 4, 2)
    AddDetail("BlMcur", "Meter Curr Reading", "N", 349, 9, 0)
    AddDetail("BlMpre", "Meter Prev Reading", "N", 358, 9, 0)
    AddDetail("BlTotu", "Meter Total Use", "N", 367, 9, 0)
    AddDetail("BlBil1", "Tax 1st Payment", "N", 376, 9, 2)
    AddDetail("BlBil2", "Tax 2nd Payment", "N", 385, 9, 2)
    AddDetail("BlBil3", "Tax 3rd Payment", "N", 394, 9, 2)
    AddDetail("BlBil4", "Tax 4th Payment", "N", 403, 9, 2)
    AddDetail("BlUnit", "Units", "N", 412, 5, 2)
    AddDetail("BlApno", "Assmnt Installment #", "N", 417, 3, 0)
    AddDetail("BlDue1", "1st Due Date", "N", 420, 8, 0)
    AddDetail("BlDue2", "2nd Due Date", "N", 428, 8, 0)
    AddDetail("BlDue3", "3rd Due Date", "N", 436, 8, 0)
    AddDetail("BlDue4", "4th Due Date", "N", 444, 8, 0)
    AddDetail("BlChgd", "Charge Description", "A", 452, 25, 0)
    AddDetail("BlUsrt", "Usage Rate", "N", 477, 11, 2)
    AddDetail("BlOas", "Assmnt Adjustment", "N", 488, 11, 2)
    AddDetail("Brk1a", "Break 1 Amount", "N", 499, 9, 2)
    AddDetail("Brk1d", "Break 1 Description", "A", 508, 25, 0)
    AddDetail("Brk2a", "Break 2 Amount", "N", 533, 9, 2)
    AddDetail("Brk2d", "Break 2 Description", "A", 542, 25, 0)
    AddDetail("Brk3a", "Break 3 Amount", "N", 567, 9, 2)
    AddDetail("Brk3d", "Break 3 Description", "A", 576, 25, 0)
    AddDetail("BMtdsc", "Meter Size", "A", 601, 15, 0)
    AddDetail("BlScan", "Scan Line (Default)", "A", 616, 50, 0)
    AddDetail("BlScan", "Scan Line (Webster)", "A", 616, 70, 0)
    AddDetail("--CSV Only --", "", "A", 0, 0, 0)
    AddDetail("BTAmt", "Back Tax Amount", "A", 0, 9, 2)
    AddDetail("Name", "Name", "A", 0, 35, 0)
    AddDetail("Name2", "Second Name", "A", 0, 35, 0)
    AddDetail("Addr1", "Address Line 1", "A", 0, 35, 0)
    AddDetail("Addr2", "Address Line 2", "A", 0, 35, 0)
    AddDetail("Zip", "Zip Code", "A", 0, 10, 0)
    AddDetail("TotAmt", "Total Amount Due", "A", 0, 9, 2)
    AddDetail("BaseChg", "Base Charge", "N", 0, 9, 2)
    AddDetail("EDUChg", "EDU Charge", "N", 0, 9, 2)
    AddDetail("RateCd", "Rate Code", "A", 0, 3, 0)
    If MyUBBNK Then
      AddDetail("BankCd", "RE Bank Code", "A", 0, 2, 0)
    End If
    AddDetail("AcctID", "Account ID", "A", 0, 10, 0)
    AddDetail("Fixtures", "Fixtures", "N", 0, 4, 0)
    AddDetail("Fund", "Fund", "N", 0, 3, 0)
Done:
    MyPrtLayout = New FrmPrtLayout
    With MyPrtLayout
      .wrkds = ds
      .WrkDesc = "UTBill"
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






