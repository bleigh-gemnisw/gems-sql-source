Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim found As Boolean
Dim myTXMVDQ As TXMVDQ.myData

Dim ds As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim DsTXMVD As DataSet = New DataSet
Dim dr As Data.DataRow
Dim dr2 As Data.DataRow

Dim WrkZip As String

Dim WrkTCount As Integer
Dim WrkTVal70 As Integer
Dim WrkTLYVal As Integer
Dim WrkTLNVal As Integer
Dim WrkTTIVal As Integer
Dim WrkTMSRPVal As Integer

  Public Sub PrtReport()

	myTXMVDQ = New TXMVDQ.mydata(MyDBConnect)

  With MyFrmTA4077B
    WrkZip = .TxtZip.Text
  End With

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
    ds2.Clear()
    ClearTotals()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds
  MyCrViewer.wrkds2 = ds2
  MyCrViewer.WrkZip = WrkZip
  MyCrViewer.Show()

  End Sub
Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With (myTable)
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("sname", Type.GetType("System.String"))
      .Columns.Add("addr", Type.GetType("System.String"))
      .Columns.Add("city", Type.GetType("System.String"))
      .Columns.Add("state", Type.GetType("System.String"))
      .Columns.Add("zipplus4", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

    With myTable2
      .TableName = "mytable2"
      .Columns.Add("TCount", Type.GetType("System.Int32"))
      .Columns.Add("TVal70", Type.GetType("System.Int32"))
      .Columns.Add("TLYVal", Type.GetType("System.Int32"))
      .Columns.Add("TLNVal", Type.GetType("System.Int32"))
      .Columns.Add("TTIVal", Type.GetType("System.Int32"))
      .Columns.Add("TMSRPVal", Type.GetType("System.Int32"))
    End With
    ds2.Tables.Add(myTable2)

  End Sub
Private Sub ClearTotals()
  WrkTCount = 0
  WrkTVal70 = 0
  WrkTLYVal = 0
  WrkTLNVal = 0
  WrkTTIVal = 0
  WrkTMSRPVal = 0
End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim I As Integer
Dim WrkAnd As String
Dim WrkOr As String

WrkSort = "LIST#, NAME"

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

WrkQry = "ZIP5 = " + WrkZip

DsTXMVD = myTXMVDQ.GetQry(WrkSort, WrkQry, 0)
If DsTXMVD.Tables(0).Rows.Count = 0 Then Exit Sub
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

For I = 0 To (DsTXMVD.Tables(0).Rows.Count - 1)
  If MyReportCancel Then Exit Sub
  With DsTXMVD.Tables(0).Rows(I)
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = .Item("list#")
    dr.Item("name") = .Item("name")
    dr.Item("sname") = .Item("sname")
    dr.Item("addr") = .Item("add1")
    dr.Item("city") = .Item("city")
    dr.Item("state") = .Item("state")
    dr.Item("zipPlus4") = Format(.Item("zip5"), "00000") + "-" + Format(.Item("zip4"), "0000")


    WrkTVal70 = WrkTVal70 + .Item("value")
    WrkTLNVal = WrkTLNVal + .Item("lnval")
    WrkTTIVal = WrkTTIVal + .Item("trval")
    WrkTMSRPVal = WrkTMSRPVal + .Item("msrp")

End With
  ds.Tables(0).Rows.Add(dr)
  WrkTCount = WrkTCount + 1
  WriteTotals()

NextRec:
With myFrmProgress
  WrkPct = ((I + 1) / DsTXMVD.Tables(0).Rows.Count) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
  End If
End With
Next


myFrmProgress.Close()
myTXMVDQ.CloseFile()

End Sub
Private Sub WriteTotals()
  If WrkTCount = 0 Then Exit Sub

  dr2 = ds2.Tables(0).NewRow
  dr2.Item("tcount") = WrkTCount
  dr2.Item("tVal70") = WrkTVal70
  dr2.Item("tLYval") = WrkTLYVal
  dr2.Item("tLNVal") = WrkTLNVal
  dr2.Item("tTIVal") = WrkTTIVal
  dr2.Item("tMSRPVal") = WrkTMSRPVal
  ds2.Tables(0).Rows.Add(dr2)
End Sub
End Module






