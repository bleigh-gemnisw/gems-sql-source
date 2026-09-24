Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myUTCUSTQ As UTCUSTQ.myData
Dim myUTCUSTMT As UTCUSTMT.myData
Dim myUTCUSTRT As UTCUSTRT.myData

Dim ds As DataSet = New DataSet
Dim DsUTCUST As DataSet = New DataSet
Dim dr As Data.DataRow

'Screen fields
Dim WrkYear As Integer
Dim WrkDist As Integer
Dim WrkPhase As Integer
Dim WrkRoute As String
Dim WrkSortBy As String
Dim WrkFromDate As Date
Dim WrkToDate As Date

'Common Work fields
Dim WrkListNo As Integer
Dim WrkTaxType As String
Dim WrkUBType As String
Dim WrkBillDesc As String
Dim WrkFamily As String
Dim WrkRateCode As String
Dim WrkCode As String
Dim WrkSize As String
Dim WrkReason As String

Public Sub PrtReport()
myUTCUSTQ = New UTCUSTQ.mydata(MyDBConnect)
myUTCUSTMT = New UTCUSTMT.mydata(MyDBConnect)
myUTCUSTRT = New UTCUSTRT.mydata(MyDBConnect)

With MyFrmUB213B
  WrkDist = MyUtils.CnvSng(.TxtDist.Text)
  WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
  WrkUBType = .TxtType.Text
  WrkFromDate = .DtPckFrom.Value
  WrkToDate = .DtPckTo.Value
  WrkRoute = .TxtRoute.Text
  If .RbSortList.Checked Then
    WrkSortBy = "List"
  End If
  If .RbSortName.Checked Then
    WrkSortBy = "Name"
  End If
  If .RbSortLocation.Checked Then
    WrkSortBy = "Location"
  End If
  WrkListNo = MyUtils.CnvSng(.TxtListNo.Text)
  WrkReason = .TxtReason.Text
  WrkCode = .TxtCode.Text
  WrkSize = .TxtMeterSize.Text
End With

If ds.Tables.Count = 0 Then
  BuildDS()
Else
  ds.Clear()
End If

GetDetail()

Done:
MyCrViewer = New FrmCrViewer
With MyCrViewer
  .wrkds = ds
  .WrkUBType = WrkUBType
  Select Case WrkSortBy
  Case "List"
    .Wrksort = "By Account"
  Case "Name"
    .Wrksort = "By Name"
  Case "Location"
    .Wrksort = "By Location"
  End Select
  .Wrkdistphase = "District / Phase " + WrkDist.ToString + " / " + WrkPhase.ToString
  .Show()
End With
End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("SortData", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Location", Type.GetType("System.String"))
      .Columns.Add("DateRead", Type.GetType("System.DateTime"))
      .Columns.Add("MeterUse", Type.GetType("System.Int64"))
      .Columns.Add("MeterRead", Type.GetType("System.Int64"))
      .Columns.Add("Reason", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub

Private Sub GetDetail()
Dim ds2 As DataSet = New DataSet
Dim WrkQry As String
Dim WrkSort As String
Dim Counter As Integer
Dim J As Integer
Dim WrkAnd As String

WrkFamily = GetUTTYPEFamily(WrkUBType)

If MyServer = "DB2" Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

WrkQry = ""
WrkSort = ""
Counter = 0
If WrkDist > 0 Then
  WrkQry = "cudst=" & WrkDist & WrkAnd & "cuphas=" & WrkPhase
End If
If WrkListNo > 0 Then
  If WrkQry = "" Then
    WrkQry = "cuacct=" & WrkListNo
  Else
    WrkQry = WrkQry & WrkAnd & "cuacct=" & WrkListNo
  End If
End If
If WrkRoute <> String.Empty Then
  If WrkQry = String.Empty Then
    WrkQry = "curout=" & MyUtils.Quo(WrkRoute)
  Else
    WrkQry = WrkQry & WrkAnd & "curout=" & MyUtils.Quo(WrkRoute)
  End If
End If

myUTCUSTQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myUTCUSTQ.ReadQry()
  If Not myUTCUSTQ.IsEOF Then
  With myUTCUSTQ
    Counter = Counter + 1
    WrkListNo = ._CUACCT
    WrkRateCode = GetRateCode(WrkUBType)
    If WrkRateCode = "" Then GoTo NextRec

    If WrkSize <> String.Empty Then
      If WrkSize <> Trim(._CUMSIZ) Then
        GoTo NextRec
      End If
    End If
    If WrkCode <> String.Empty Then
      If WrkCode <> WrkRateCode Then
        GoTo NextRec
      End If
    End If

    Select Case WrkFamily
    Case "M"
    Case Else
      GoTo NextRec
    End Select

    ds2 = myUTCUSTMT.GetLastbyDate(WrkListNo, WrkUBType, MyUtils.SetDBDate(WrkToDate))
    If ds2.Tables(0).Rows.Count = 0 Then
      ds2 = myUTCUSTMT.GetLastbyDate(WrkListNo, "", MyUtils.SetDBDate(WrkToDate))
    End If
    For J = 0 To (ds2.Tables(0).Rows.Count - 1)
      If MyUtils.GetDBDate(ds2.Tables(0).Rows(J).Item("cmdate")) < WrkFromDate Then Exit For
      If WrkReason <> String.Empty Then
        If WrkReason <> ds2.Tables(0).Rows(J).Item("cmresn") Then
          Continue For
        End If
      End If
     'Report
      dr = ds.Tables(0).NewRow
      Select Case WrkSortBy
      Case "List"
        dr.Item("sortdata") = Format(WrkListNo, "000000")
      Case "Name"
        dr.Item("sortdata") = Trim(._CUNAM1)
      Case "Location"
        dr.Item("sortdata") = Trim(._CULOC) & " " & ._CULOCNO
      End Select
      dr.Item("listno") = WrkListNo
      dr.Item("name") = Trim(._CUNAM1)
      dr.Item("location") = Trim(._CULOCNO) & " " & Trim(._CULOC)
      dr.Item("dateread") = MyUtils.GetDBDate(ds2.Tables(0).Rows(J).Item("cmdate"))
      dr.Item("meteruse") = ds2.Tables(0).Rows(J).Item("cmuse")
      dr.Item("meterread") = ds2.Tables(0).Rows(J).Item("cmread")
      dr.Item("reason") = ds2.Tables(0).Rows(J).Item("cmresn")
      ds.Tables(0).Rows.Add(dr)
    Next
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
myUTCUSTQ.CloseFile()
End Sub
Private Function GetRateCode(ByVal WrkUBType As String) As String
  GetRateCode = ""
  myUTCUSTRT.GetOneRecordP(WrkListNo, WrkUBType)
  If myUTCUSTRT.RecordNotFound Then Exit Function

  With myUTCUSTRT
    GetRateCode = ._CRCODE
  End With
End Function

End Module






