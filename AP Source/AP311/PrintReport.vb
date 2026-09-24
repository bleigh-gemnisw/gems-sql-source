Imports System.io
Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myVENDORQ As VENDORQ.MyData
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkAnd As String
Dim WrkOr As String

  Public Sub PrtReport()

  myVENDORQ = New VENDORQ.MyData()
  myVENDORQ.MyDBConn = myDBConnect

  With MyFrmAP311B
  End With

  If ds.Tables.Count = 0 Then
    BuildDs(ds)
  Else
    ds.Clear()
  End If
  GetDetail()

Done:
 MyCRViewer = New FrmCrViewer
 With MyCRViewer
  .wrkds = ds
  .Show()
 End With
 End Sub
Private Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("RptID", Type.GetType("System.String"))
      .Columns.Add("vadd", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Vendor", Type.GetType("System.String"))
      .Columns.Add("VendName", Type.GetType("System.String"))
      
  End With
  ds.Tables.Add(myTable)
End Sub
Private Sub GetDetail()
Dim WrkQry As String
Dim WrkSort As String
Dim WrkName As String
Dim WrkAcct As String
Dim WrkAcctDesc As String

Dim Counter As Integer

WrkAnd = " and "
WrkOr = " or "
'One Time Vendor = * in 1st position of field VNDNR
WrkQry = "VNDNR like ('*%')"
WrkSort = "VENNM"

Counter = 0
myVENDORQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
 myVENDORQ.ReadQry()
 If Not myVENDORQ.IsEOF Then
  With myVENDORQ
   Counter = Counter + 1
   WrkName = ""
   WrkAcct = ""
   WrkAcctDesc = ""
     dr = ds.Tables(0).NewRow
     dr.Item("rptid") = "D"
     dr.Item("vadd") = Trim(._VADD1) + " " + Trim(._VADD2) + " " + Trim(._VADD3)
     dr.Item("vendor") = Trim(._VNDNR)
     dr.Item("vendname") = Trim(._VENNM)
     ds.Tables(0).Rows.Add(dr)
  End With

NextRec:
  With myFrmProgress
   WrkPct = (Counter / 10) Mod 100
   If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .LblMsg.Text = "Records processed: " & Counter
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
   End If
  End With
  GoTo ReadNext
 End If

  myFrmProgress.Close()
  myVENDORQ.CloseFile()

End Sub
Public Function SetVndrAddrLine(ByVal Add1 As String, ByVal Add2 As String, _
   ByVal Add3 As String, ByVal Add4 As String, ByVal Zip5 As String, _
   ByVal Zip4 As String) As String()
   'Returns Address as string array. Blank lines are stripped out. 
  Dim AddrLine(3) As String
   Dim sb As StringBuilder
   Dim I As Integer

  Add1 = Trim(Add1)
  Add2 = Trim(Add2)
  Add3 = Trim(Add3)
  Add4 = Trim(Add4)
  Zip5 = Trim(Zip5)
  Zip4 = Trim(Zip4)

  AddrLine(I) = Add1
  If Add2 <> "" Then
   I = I + 1
   AddrLine(I) = Add2
  End If
   If Add3 <> "" Then
   I = I + 1
   AddrLine(I) = Add3
  End If
   If Add4 <> "" Then
   I = I + 1
   AddrLine(I) = Add4
  End If
  If Zip5 <> "" Then
   sb = New StringBuilder
   sb.Append(Zip5)
   If Zip4 <> "" Then
    sb.Append("-")
    sb.Append(Zip4)
   End If
   AddrLine(I) = AddrLine(I) & " " & sb.ToString
  End If
  For I = 2 To 3
   If AddrLine(I) Is Nothing Then
    AddrLine(I) = ""
   End If
  Next
  Return AddrLine

End Function
End Module
