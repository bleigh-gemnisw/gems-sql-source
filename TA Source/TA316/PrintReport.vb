Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXPPRPQ As TXPPRPQ.MyData
Dim ds1 As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim DsTXPPRP As DataSet = New DataSet
Dim dr As Data.DataRow
Dim dr2 As Data.DataRow

'General
Dim WrkAnd As String
Dim WrkOr As String

Dim WrkBusty As String

Dim WrkTCount As Integer
Dim WrkTGross As Integer
Dim WrkTTex As Integer
Dim WrkTNet As Integer
Dim WrkTSqFeet As Decimal
Public Sub PrtReport()
	myTXPPRPQ = New TXPPRPQ.mydata(MyDBConnect)

  With MyFrmTA316B
    WrkBusty = .TxtBusty.Text
  End With

  If ds1.Tables.Count = 0 Then
    BuildDS()
  Else
    ds1.Clear()
    ds2.Clear()
    ClearTotals()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds1
  MyCrViewer.wrkds2 = ds2
  MyCrViewer.Show()

End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("PropLoc", Type.GetType("System.String"))
      .Columns.Add("Busty", Type.GetType("System.String"))
      .Columns.Add("BusDesc", Type.GetType("System.String"))
      .Columns.Add("Gross", Type.GetType("System.Int32"))
      .Columns.Add("Tex", Type.GetType("System.Int32"))
      .Columns.Add("Net", Type.GetType("System.Int32"))
      .Columns.Add("SqFeet", Type.GetType("System.Decimal"))
    End With
    ds1.Tables.Add(myTable)

    With myTable2
      .TableName = "mytable2"
      .Columns.Add("Busty", Type.GetType("System.String"))
      .Columns.Add("BusDesc", Type.GetType("System.String"))
      .Columns.Add("TCount", Type.GetType("System.Int32"))
      .Columns.Add("TGross", Type.GetType("System.Int32"))
      .Columns.Add("TTex", Type.GetType("System.Int32"))
      .Columns.Add("TNet", Type.GetType("System.Int32"))
      .Columns.Add("TSqFeet", Type.GetType("System.Decimal"))
    End With
    ds2.Tables.Add(myTable2)

  End Sub
Private Sub ClearTotals()
  WrkTCount = 0
  WrkTNet = 0
  WrkTTex = 0
  WrkTGross = 0
  WrkTSqFeet = 0
End Sub
Private Sub GetDetail()
Dim AddrLine() As String
Dim WrkSort As String
Dim WrkQry As String
Dim I As Integer
Dim SaveBusty As String
Dim SaveBusDesc As String

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

WrkQry = "CAT='5'"
If WrkBusty <> String.Empty Then
  WrkQry = WrkQry & WrkAnd & "BUSTY=" & MyUtils.Quo(WrkBusty)
End If

WrkSort = "BUSTY, NAME"
DsTXPPRP = myTXPPRPQ.GetQry(WrkSort, WrkQry, 0)
If DsTXPPRP.Tables(0).Rows.Count = 0 Then GoTo CloseFiles

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

SaveBusty = ""
SaveBusDesc = ""
For I = 0 To (DsTXPPRP.Tables(0).Rows.Count - 1)
  With DsTXPPRP.Tables(0).Rows(I)
    dr = ds1.Tables(0).NewRow
    If SaveBusty <> "" And SaveBusty <> .Item("busty") Then
      WriteTotals(SaveBusty, SaveBusDesc)
      ClearTotals()
      SaveBusDesc = ""
    End If

    SaveBusty = .Item("busty")
    If SaveBusDesc = "" Then
      SaveBusDesc = GetTXBustyDesc(.Item("busty"))
    End If

    WrkTCount = WrkTCount + 1
    dr.Item("listno") = .Item("list#")
    AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"), _
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
    dr.Item("addr1") = AddrLine(0)
    dr.Item("addr2") = AddrLine(1)
    dr.Item("addr3") = AddrLine(2)
    dr.Item("addr4") = AddrLine(3)
    dr.Item("addr5") = AddrLine(4)
    dr.Item("proploc") = Trim(.Item("loc#") & " " & .Item("loc"))
    dr.Item("busty") = SaveBusty
    dr.Item("busdesc") = SaveBusDesc
    dr.Item("gross") = .Item("gross")
    dr.Item("tex") = .Item("gross") - .Item("net")
    dr.Item("net") = .Item("net")
    dr.Item("sqfeet") = .Item("sqft")
    WrkTGross = WrkTGross + .Item("gross")
    WrkTNet = WrkTNet + .Item("net")
    WrkTSqFeet = WrkTSqFeet + .Item("sqft")
  End With
  ds1.Tables(0).Rows.Add(dr)
NextRec:
With myFrmProgress
  WrkPct = ((I + 1) / DsTXPPRP.Tables(0).Rows.Count) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
  End If
End With
Next

WrkTTex = WrkTGross - WrkTNet
WriteTotals(SaveBusty, SaveBusDesc)
myFrmProgress.Close()

CloseFiles:
myTXPPRPQ.CloseFile()

End Sub
Private Sub WriteTotals(ByVal SaveBusty As String, ByVal SaveBusDesc As String)
  If WrkTCount = 0 Then Exit Sub

  dr2 = ds2.Tables(0).NewRow
  dr2.Item("busty") = SaveBusty
  dr2.Item("busdesc") = SaveBusDesc
  dr2.Item("tcount") = WrkTCount
  dr2.Item("tgross") = WrkTGross
  dr2.Item("ttex") = WrkTTex
  dr2.Item("tnet") = WrkTNet
  dr2.Item("tsqfeet") = WrkTSqFeet
  ds2.Tables(0).Rows.Add(dr2)
End Sub
End Module






