Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALCQ As TXREALCQ.myData
Dim myTXREAL As TXREAL.myData
Dim myTXREALC As TXREALC.myData

Dim ds As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim dr As Data.DataRow
Dim WrkEldYear As Integer
Dim WrkPost As Boolean

 Public Sub PrtReport()

 myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)
 myTXREAL = New TXReal.mydata(MyDBConnect)
 myTXREALC = New TXREALC.mydata(MyDBConnect)

 With MyFrmTA231B
    WrkEldYear = MyUtils.CnvSng(.TxtEldYear.Text)
    WrkPost = .ChkPost.Checked
 End With

 If ds.Tables.Count = 0 Then
  BuildDS(ds)
 Else
  ds.Clear()
 End If

 GetDetail()

 MyCrViewer = New FrmCrViewer
 MyCrViewer.wrkds = ds
 MyCrViewer.WrkPost = WrkPost
 MyCrViewer.Show()

 End Sub
Private Sub GetDetail()
Dim WrkQry As String
Dim WrkSort As String
Dim WrkAnd As String
Dim Counter As Integer

If myDBConnect.ServerAS400 Then
 WrkAnd = " *and "
Else
 WrkAnd = " and "
 End If

Counter = 0
WrkSort = "LIST#"
WrkQry = "FCCOD = 'C'" & WrkAnd & "FCYR = " & WrkEldYear

myTXREALCQ.OpenQry(WrkSort, WrkQry)
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
 myTXREALCQ.ReadQry()
 If Not myTXREALCQ.IsEOF Then
 With myTXREALCQ
    Counter = Counter + 1
    If WrkPost Then
     UpdateRE(._LISTNO)
    End If
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = ._LISTNO
    dr.Item("name") = Trim(._NAME)
    dr.Item("benefit") = ._FTAX
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
myTXREALCQ.CloseFile()

If WrkPost Then
 MsgBox("Benefit Amounts have been removed", MsgBoxStyle.Information, "Update has finished")
 MyFrmTA231B.ChkPost.Checked = False
End If
End Sub
Private Sub UpdateRE(ByVal List As Integer)

 With myTXREAL
  .GetOneRecordP(List)
  If Not .RecordNotFound Then
    ._FCCOD = String.Empty
    ._FCYR = 0
    ._CMAX = 0
    ._CMIN = 0
    ._CPERC = 0
    ._FTAX = 0
    .UpdateOneRecordP()
  End If
 End With

 With myTXREALC
   .GetOneRecordP(List)
   If Not .RecordNotFound Then
     ._FCCOD = String.Empty
     ._FCYR = 0
     ._CMAX = 0
     ._CMIN = 0
     ._CPERC = 0
     ._FTAX = 0
     .UpdateOneRecordP()
   End If
 End With
End Sub
End Module






