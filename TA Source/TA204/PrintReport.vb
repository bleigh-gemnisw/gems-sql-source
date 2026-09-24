Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALQ As TXREALQ.myData
Dim myTXPPRPQ As TXPPRPQ.myData
Dim myTXMVDQ As TXMVDQ.myData
Dim myTXREALCQ As TXREALCQ.myData
Dim myTXPPRPCQ As TXPPRPCQ.myData
Dim myTXMVDCQ As TXMVDCQ.myData

Dim ds As DataSet = New DataSet
Dim DsFile As DataSet = New DataSet
Dim dr As Data.DataRow
  Public Sub PrtReport()

  myTXREALQ = New TXREALQ.mydata(MyDBConnect)
  myTXPPRPQ = New TXPPRPQ.mydata(MyDBConnect)
  myTXMVDQ = New TXMVDQ.mydata(MyDBConnect)
  myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)
  myTXPPRPCQ = New TXPPRPCQ.mydata(MyDBConnect)
  myTXMVDCQ = New TXMVDCQ.mydata(MyDBConnect)

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
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("Gross", Type.GetType("System.Int32"))
      .Columns.Add("BAA", Type.GetType("System.Int32"))
      .Columns.Add("Net", Type.GetType("System.Int32"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("Map", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()
Dim AddrLine As String()
Dim WrkGLYear As Integer
Dim WrkDenied As Boolean
Dim WrkType As String
Dim WrkExam As Integer
Dim WrkCat As String
Dim WrkFrozenFile As Boolean
Dim WrkSort As String
Dim WrkQry As String
Dim I As Integer
Dim WrkAnd As String

WrkType = ""
WrkCat = ""
With MyFrmTA204B
  WrkGLYear = .TxtGLYear.Text
  WrkDenied = .RbDenied.Checked
  If .RbRE.Checked Then
    WrkType = "R"
    WrkCat = "1"
  End If
  If .RbPP.Checked Then
    WrkType = "P"
    WrkCat = "5"
  End If
  If .RbMV.Checked Then
    WrkType = "M"
    WrkCat = "1"
  End If
  WrkFrozenFile = .ChkFrozenFile.Checked
End With

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
End If

WrkSort = "NAME, LIST#"
If WrkDenied Then
  WrkQry = "CAT = '" & WrkCat & "'" & WrkAnd & "DNBTR='Y'" & WrkAnd & "BTR = 0"
Else
  WrkQry = "CAT = '" & WrkCat & "'" & WrkAnd & "BTR <> 0"
End If

Select Case WrkType
Case "R"
  If Not WrkFrozenFile Then
    DsFile = myTXREALQ.GetQry(WrkSort, WrkQry, 0)
  Else
    DsFile = myTXREALCQ.GetQry(WrkSort, WrkQry, 0)
  End If
Case "P"
  If Not WrkFrozenFile Then
    DsFile = myTXPPRPQ.GetQry(WrkSort, WrkQry, 0)
  Else
    DsFile = myTXPPRPCQ.GetQry(WrkSort, WrkQry, 0)
  End If
Case "M"
  If Not WrkFrozenFile Then
    DsFile = myTXMVDQ.GetQry(WrkSort, WrkQry, 0)
  Else
    DsFile = myTXMVDCQ.GetQry(WrkSort, WrkQry, 0)
  End If
End Select
If DsFile.Tables(0).Rows.Count = 0 Then Exit Sub

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

For I = 0 To (DsFile.Tables(0).Rows.Count - 1)
  If MyReportCancel Then Exit Sub
  With DsFile.Tables(0).Rows(I)
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = .Item("list#")
    AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"), _
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
    dr.Item("addr1") = AddrLine(0)
    dr.Item("addr2") = AddrLine(1)
    dr.Item("addr3") = AddrLine(2)
    dr.Item("addr4") = AddrLine(3)
    dr.Item("addr5") = AddrLine(4)
    If WrkType = "M" Then
      dr.Item("gross") = .Item("value")
      WrkExam = .Item("exam1") + .Item("exam2") + .Item("exam3") + .Item("exam4") + .Item("exam5")
      dr.Item("baa") = .Item("value") + .Item("btr") - WrkExam
      dr.Item("net") = .Item("value") - WrkExam
    Else
      dr.Item("gross") = .Item("gross")
      dr.Item("baa") = .Item("net") + .Item("btr")
      dr.Item("net") = .Item("net")
    End If
    Select Case WrkType
    Case "R"
      dr.Item("propdesc") = .Item("loc#") & " " & .Item("loc")
      dr.Item("map") = .Item("map")
    Case "P"
      dr.Item("propdesc") = .Item("loc#") & " " & .Item("loc")
    Case "M"
      dr.Item("propdesc") = .Item("make") & " " & .Item("year") & " " & .Item("regno")
    End Select
    End With
  ds.Tables(0).Rows.Add(dr)

NextRec:
With myFrmProgress
  WrkPct = ((I + 1) / DsFile.Tables(0).Rows.Count) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
  End If
End With
Next

myFrmProgress.Close()
myTXREALQ.CloseFile()
myTXPPRPQ.CloseFile()
myTXMVDQ.CloseFile()
myTXREALCQ.CloseFile()
myTXPPRPCQ.CloseFile()
myTXMVDCQ.CloseFile()

End Sub
End Module






