Imports System.io
Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myAPERCNQ As APERCNQ.myData
Dim myAPEBNK As APEBNK.myData
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkFrom As Integer
Dim WrkTo As Integer
Dim WrkBank As String
Dim WrkPrData As String
Dim WrkAnd As String
Dim WrkOr As String

	Public Sub PrtReport()

  myAPERCNQ = New APERCNQ.MyData
  myAPERCNQ.MyDBConn = myDBConnect
  myAPEBNK = New APEBNK.myData(myDBConnect.PgmDB)

  With MyFrmAP501B
  End With

	If ds.Tables.Count = 0 Then
		BuildDs(ds)
	Else
		ds.Clear()
	End If
  With MyFrmAP501B
    GetDetailAP()
  End With

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
			.Columns.Add("Void", Type.GetType("System.String"))
			.Columns.Add("CheckNo", Type.GetType("System.Int32"))
			.Columns.Add("Date", Type.GetType("System.DateTime"))
			.Columns.Add("Amount", Type.GetType("System.Decimal"))
			.Columns.Add("Name", Type.GetType("System.String"))
	End With
	ds.Tables.Add(myTable)
End Sub
Private Sub GetDetailAP()
Dim WrkQry As String
Dim WrkSort As String
Dim WrkAcct As String

Dim Counter As Integer

If MyServer = "DB2" Then
 WrkAnd = " *and "
 WrkOr = " *or "
Else
 WrkAnd = " and "
 WrkOr = " or "
 End If

WrkQry = "PAYBN = " & MyUtils.Quo(WrkBank) & WrkAnd & "PAYP8 >= " & WrkFrom & WrkAnd & "PAYP8 <=" & WrkTo
WrkSort = "PAYCK *ASCEND"
Counter = 0
myAPERCNQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
 myAPERCNQ.ReadQry()
 If Not myAPERCNQ.IsEOF Then
  Counter = Counter + 1
  myAPEBNK.GetOneRecordP(WrkBank)
  With myAPEBNK
   WrkAcct = Trim(._BNKAC)
  End With
  'Create Report
  With myAPERCNQ
   dr = ds.Tables(0).NewRow
   If ._RCCDE = "P" Or ._RCCDE = "V" Then
    dr.Item("void") = "V"
   Else
    dr.Item("void") = String.Empty
   End If
   dr.Item("checkno") = ._PAYCK
   dr.Item("date") = MyUtils.GetDBDate(._PAYP8)
   dr.Item("amount") = ._PAYAM
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
myAPERCNQ.CloseFile()

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
Private Function DoFlipName(ByVal Name As String) As String
 Dim WrkName As String
 Dim Pos As Integer

 WrkName = ""
 Pos = InStr(Name, ",", CompareMethod.Text)
 If Pos > 0 Then
  WrkName = Trim(Mid(Name, Pos + 1, 40)) & " " & Mid(Name, 1, Pos - 1)
 Else
  WrkName = Name
 End If

 Return WrkName
End Function

End Module
