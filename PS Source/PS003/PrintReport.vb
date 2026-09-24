Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myMFPRKHQ As MFPRKHQ.myData

Dim ds1 As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim DsMFPRKH As DataSet = New DataSet
Dim dr As Data.DataRow
Dim dr2 As Data.DataRow
Dim ds As DataSet = New DataSet
Dim WrkSortby As String
Dim WrkType As String
Dim WrkFromGLYear As Integer
Dim WrkToGLYear As Integer
Dim WrkFrom As Integer
Dim WrkTo As Integer
Dim WrkSelection As String

Dim WrkAnd As String
Dim WrkOr As String

Dim WrkTCount As Integer
Dim WrkTFee As Decimal

Public Sub PrtReport()

  myMFPRKHQ = New MFPRKHQ.mydata(MyDBConnect)


  With MyFrmPS003B
    If .RbDateName.Checked Then WrkSortby = "DateName"
    If .RbNameDate.Checked Then WrkSortby = "NameDate"
    If .Rbperno.Checked Then WrkSortby = "Permit"
    WrkFromGLYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
    WrkToGLYear = MyUtils.CnvSng(.TxtToGLYear.Text)
    WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
    
  End With

  If ds1.Tables.Count = 0 Then
    BuildDS(ds1)
    BuildDS2(ds2)
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

  Private Sub BuildDS(ByRef ds1 As DataSet)
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
'mftdat/mfttim/mfyear/mfcatg/mfnam.mfadd1/mfperno/mflfee
      .TableName = "mytable"
      .Columns.Add("Sortby", Type.GetType("System.String"))
      '.Columns.Add("Mftdat", Type.GetType("System.Datetime"))
      .Columns.Add("Mftdat", Type.GetType("System.DateTime"))
      .Columns.Add("Mfttim", Type.GetType("System.String"))
      .Columns.Add("Mfyear", Type.GetType("System.Int32"))
      .Columns.Add("mfcatg", Type.GetType("System.String"))
      .Columns.Add("Mfnam", Type.GetType("System.String"))
      .Columns.Add("Mfadd1", Type.GetType("System.String"))
      .Columns.Add("Mfperno", Type.GetType("System.Int32"))
      .Columns.Add("Mflfee", Type.GetType("System.Double"))


    End With
    ds1.Tables.Add(myTable)

    

  End Sub
Private Sub BuildDS2(ByRef ds2 As DataSet)
    Dim myTable2 As New DataTable

   With myTable2
      .TableName = "mytable2"
      .Columns.Add("TCount", Type.GetType("System.Int32"))
      .Columns.Add("TFee", Type.GetType("System.Double"))

    End With
    ds2.Tables.Add(myTable2)

  End Sub
Private Sub ClearTotals()
  WrkTCount = 0
  WrkTFee = 0
  
End Sub
Private Sub GetDetail()
Dim sb As StringBuilder
Dim WrkSort As String
Dim WrkQry As String

Dim Counter As Integer
Dim SaveSortData As String
If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

WrkQry = "MFTDAT >= " & WrkFrom & WrkAnd & "MFTDAT <=" & WrkTo

If WrkFromGLYear > 0 Then
  WrkQry = WrkQry & WrkAnd & "MFYEAR >= " & WrkFromGLYear _
  & WrkAnd & "MFYEAR <= " & WrkToGLYear
End If
WrkSort = "MFTDAT, MFTTIM"

Select Case WrkSortby
   Case "DateName"
      WrkSort = "MFTDAT, MFNAM"
    Case "NameDate"
      WrkSort = "MFNAM, MFTDAT"
    Case "Permit"
      WrkSort = "MFPER#, MFTDAT"
 End Select


myMFPRKHQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()


SaveSortData = ""
ReadNext:
  myMFPRKHQ.ReadQry()
  If Not myMFPRKHQ.IsEOF Then
    Counter = Counter + 1
    With myMFPRKHQ


    dr = ds1.Tables(0).NewRow

    dr.Item("mftdat") = MyUtils.GetDBDate(._MFTDAT)
    dr.Item("mfttim") = ._MFTTIM
    dr.Item("mfyear") = ._MFYEAR
    dr.Item("mfcatg") = ._MFCATG
    dr.Item("mfnam") = ._MFNAM
    dr.Item("mfadd1") = ._MFADD1
    dr.Item("mfperno") = ._MFPERNo
    dr.Item("mflfee") = ._MFLFEE
    
    sb = New StringBuilder
    Select Case WrkSortby

    Case "DateName"
      sb.Append(._MFTDAT)
      sb.Append(._MFTTIM)
      sb.Append(._MFNAM)
    Case "NameDate"
      sb.Append(._MFNAM)
      sb.Append(._MFTDAT)
      sb.Append(._MFTTIM)
    Case "Permit"
      sb.Append(._MFPERNo)
      sb.Append(._MFTDAT)
      sb.Append(._MFTTIM)
    End Select
    dr.Item("sortby") = sb.ToString
    sb = Nothing
    WrkTFee = WrkTFee + ._MFLFEE

  End With

  WrkTCount = WrkTCount + 1
  ds1.Tables(0).Rows.Add(dr)
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

dr = ds2.Tables(0).NewRow
dr.Item("tcount") = WrkTCount
dr.Item("tfee") = WrkTFee

ds2.Tables(0).Rows.Add(dr)

myFrmProgress.Close()

myMFPRKHQ.CloseFile()



End Sub
Private Sub WriteTotals()
  If WrkTCount = 0 Then Exit Sub

  dr2 = ds2.Tables(0).NewRow
  dr2.Item("tcount") = WrkTCount
  dr2.Item("tfee") = WrkTFee
  
  ds2.Tables(0).Rows.Add(dr2)
End Sub
  
  

End Module






