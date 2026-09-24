Imports System.Text
Module PrintReportRE

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALQ As TXREALQ.myData

Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow
Const WrkType = "R"

  Public Sub PrtReportRE()

	myTXREALQ = New TXREALQ.mydata(MyDBConnect)

  If ds.Tables.Count = 0 Then
    BuildDS(ds)
  Else
    ds.Clear()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds
  MyCrViewer.WrkType = WrkType
  MyCrViewer.Show()

  End Sub
Private Sub GetDetail()
Dim WrkGLYear As Integer
Dim WrkDnBTR As String
Dim WrkSort As String
Dim WrkQry As String
Dim Counter As Integer
Dim WrkAnd As String
Dim WrkOr As String

Counter = 0
WrkSort = ""
WrkDnBTR = ""
With MyFrmTA206B
  WrkGLYear = .TxtGLYear.Text
  If .RbName.Checked Then
    WrkSort = "NAME, LIST#"
  End If
  If .RbLoc.Checked Then
    WrkSort = "LOC, LOC#"
  End If
  If .RbSelApp.Checked Then WrkDnBTR = "N"
  If .RbSelDen.Checked Then WrkDnBTR = "Y"
End With

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

If WrkDnBTR = String.Empty Then
  WrkQry = "DTBTR > 0 "
Else
  WrkQry = "DTBTR > 0 " & WrkAnd & "DNBTR = " & MyUtils.Quo(WrkDnBTR)
End If

myTXREALQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
 myTXREALQ.ReadQry()
 If Not myTXREALQ.IsEOF Then
 With myTXREALQ
  Counter = Counter + 1
  dr = ds.Tables(0).NewRow
  dr.Item("listno") = ._LISTNO
  dr.Item("name") = Trim(._NAME)
  dr.Item("locno") = Trim(._LOCNO)
  dr.Item("loc") = Trim(._LOC)
  dr.Item("gross") = ._GROSS
  If ._DNBTR = "Y" Then
    dr.Item("btr") = ._GROSS
    dr.Item("adjusted") = 0
  Else
    dr.Item("btr") = ._GROSS + ._BTR
    dr.Item("adjusted") = ._BTR
  End If
  dr.Item("fccod") = Trim(._FCCOD)
  dr.Item("dnbtr") = ._DNBTR
  dr.Item("cat") = ._CAT
 End With
  ds.Tables(0).Rows.Add(dr)

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
myTXREALQ.CloseFile()

End Sub
End Module






