Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXTRANSQ As TXTRANSQ.myData
Dim myTXREAL As TXReal.myData

Dim ds As DataSet = New DataSet
Dim DsTXTRANS As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkFrom As Integer
Dim WrkTo As Integer

  Public Sub PrtReport()

	myTXTRANSQ = New TXTRANSQ.mydata(MyDBConnect)
	myTXREAL = New TXReal.mydata(MyDBConnect)

  With MyFrmTA209B
    WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
  End With

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds
  MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Cat", Type.GetType("System.String"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("Vol", Type.GetType("System.String"))
      .Columns.Add("Pge", Type.GetType("System.String"))
      .Columns.Add("Map", Type.GetType("System.String"))
      .Columns.Add("PurDate", Type.GetType("System.DateTime"))
      .Columns.Add("Price", Type.GetType("System.Int32"))
      .Columns.Add("Exmpt", Type.GetType("System.String"))
      .Columns.Add("TCat", Type.GetType("System.String"))
      .Columns.Add("TAddr1", Type.GetType("System.String"))
      .Columns.Add("TAddr2", Type.GetType("System.String"))
      .Columns.Add("TAddr3", Type.GetType("System.String"))
      .Columns.Add("TAddr4", Type.GetType("System.String"))
      .Columns.Add("TAddr5", Type.GetType("System.String"))
      .Columns.Add("TVol", Type.GetType("System.String"))
      .Columns.Add("TPge", Type.GetType("System.String"))
      .Columns.Add("TPurDate", Type.GetType("System.DateTime"))
      .Columns.Add("TPrice", Type.GetType("System.Int32"))
      .Columns.Add("TExmpt", Type.GetType("System.String"))
      .Columns.Add("TCentr", Type.GetType("System.String"))
      .Columns.Add("TEldcd", Type.GetType("System.String"))
      .Columns.Add("TExmpt2", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()
Dim AddrLine() As String
Dim TAddrLine() As String
Dim WrkQry As String
Dim WrkSort As String
Dim I As Integer
Dim WrkAnd As String
Dim WrkCat As String

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

WrkSort = ""
WrkQry = "TDATE >= " & WrkFrom & WrkAnd & "TDATE <= " & WrkTo

DsTXTRANS = myTXTRANSQ.GetQry(WrkSort, WrkQry, 0)
If DsTXTRANS.Tables(0).Rows.Count = 0 Then GoTo CloseFiles
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

For I = 0 To (DsTXTRANS.Tables(0).Rows.Count - 1)
  If MyReportCancel Then GoTo CloseFiles
  dr = ds.Tables(0).NewRow
  With DsTXTRANS.Tables(0).Rows(I)
    dr.Item("listno") = .Item("list#")
    WrkCat = .Item("cat")
    Select Case WrkCat
    Case "1"
      dr.Item("tcat") = "Non-Exmpt"
    Case "3"
      dr.Item("tcat") = "Exmpt"
    End Select
    TAddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"), _
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
    dr.Item("taddr1") = TAddrLine(0)
    dr.Item("taddr2") = TAddrLine(1)
    dr.Item("taddr3") = TAddrLine(2)
    dr.Item("taddr4") = TAddrLine(3)
    dr.Item("taddr5") = TAddrLine(4)
    dr.Item("tvol") = .Item("vol")
    dr.Item("tpge") = .Item("tpage")
    dr.Item("tpurdate") = MyUtils.GetDBDate(.Item("tdate"))
    dr.Item("tprice") = .Item("price")
    dr.Item("texmpt") = .Item("exmpt")
    dr.Item("tcentr") = .Item("centr")
    dr.Item("teldcd") = .Item("eldcd")
    dr.Item("texmpt2") = .Item("exmpt2")
  End With

	myTXREAL.GetOneRecordP(DsTXTRANS.Tables(0).Rows(I).Item("list#"))
	With myTXREAL
		WrkCat = Trim(._CAT)
		Select Case WrkCat
		Case "1"
			dr.Item("cat") = "Non-Exmpt"
		Case "3"
			dr.Item("cat") = "Exmpt"
		End Select
    AddrLine = MyUtils.SetAddrLine(._NAME, ._SNAME, ._ADD1, ._ADD2, _
      ._CITY, ._STATE, ._ZIP5, ._ZIP4)
		dr.Item("addr1") = AddrLine(0)
		dr.Item("addr2") = AddrLine(1)
		dr.Item("addr3") = AddrLine(2)
		dr.Item("addr4") = AddrLine(3)
		dr.Item("addr5") = AddrLine(4)
		dr.Item("map") = Trim(._MAP)
		dr.Item("vol") = Trim(._VOL)
		dr.Item("pge") = Trim(._PGE)
    dr.Item("purdate") = MyUtils.GetDBDate(._PURDT)
		dr.Item("price") = ._PURPR
		dr.Item("exmpt") = Trim(._EXMPT)
		ds.Tables(0).Rows.Add(dr)
	End With
NextRec:
With myFrmProgress
  If DsTXTRANS.Tables(0).Rows.Count > 1 Then
    WrkPct = ((I + 1) / DsTXTRANS.Tables(0).Rows.Count) * 100
    If SavePct <> WrkPct Then
      .ProgBar1.Value = WrkPct
      .Refresh()
      SavePct = WrkPct
      Application.DoEvents()
    End If
  End If
End With
Next

myFrmProgress.Close()

CloseFiles:
myTXTRANSQ.CloseFile()
myTXREAL.CloseFile()

End Sub
End Module






