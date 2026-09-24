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
Dim WrkReadingDate As Date
Dim WrkPreviousDate As Date
Dim WrkVarPct As Integer

'Common Work fields
Dim WrkListNo As Integer
Dim WrkTaxType As String
Dim WrkUBType As String
Dim WrkBillDesc As String
Dim WrkFamily As String
Dim WrkCode As String


'Metered Work Fields
Dim WrkActualUse As Integer
Dim WrkPreviousUse As Integer

Public Sub PrtReport()
myUTCUSTQ = New UTCUSTQ.mydata(MyDBConnect)
myUTCUSTMT = New UTCUSTMT.mydata(MyDBConnect)
myUTCUSTRT = New UTCUSTRT.mydata(MyDBConnect)

With MyFrmUB214B
  WrkDist = MyUtils.CnvSng(.TxtDist.Text)
  WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
  WrkUBType = .TxtType.Text
  WrkReadingDate = .DtPckReading.Value
  WrkPreviousDate = .DtPckPrevious.Value
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
  WrkVarPct = MyUtils.CnvSng(.TxtPct.Text)
  'If .RbSortusage.Checked Then
  '  WrkSortBy = "Usage"
  'End If
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
  Case "Usage"
    .Wrksort = "By Usage"
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
      .Columns.Add("MeterUse", Type.GetType("System.Int64"))
      .Columns.Add("PreviousUse", Type.GetType("System.Int64"))
      .Columns.Add("Diff", Type.GetType("System.Int32"))
      .Columns.Add("PctDiff", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
  End Sub

Private Sub GetDetail()
Dim WrkQry As String
Dim WrkSort As String
Dim WrkAnd As String
Dim WrkDiff As Integer
Dim WrkDiffPct As Integer
Dim Counter As Integer

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
    Counter = Counter + 1
    With myUTCUSTQ
      WrkListNo = ._CUACCT
      WrkCode = GetRateCode(WrkUBType)

      If Trim(WrkCode) = "" Then GoTo NextRec

      Select Case WrkFamily
      Case "M"
        WrkActualUse = CalcMetered(WrkReadingDate)
        WrkPreviousUse = CalcMetered(WrkPreviousDate)
      Case Else
        GoTo NextRec
      End Select

      If WrkActualUse = 0 Then GoTo NextRec
      WrkDiff = WrkActualUse - WrkPreviousUse
      'Filter if less than Variance percent 
      WrkDiffPct = 0
      If WrkPreviousUse > 0 Then
        WrkDiffPct = ((WrkActualUse - WrkPreviousUse) / WrkPreviousUse) * 100
        If WrkDiffPct < WrkVarPct Or WrkDiffPct < 0 Then
          GoTo NextRec
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
        dr.Item("sortdata") = Trim(._CULOC) & " " & Trim(._CULOCNO)
      Case "Usage"
        dr.Item("sortdata") = Format(WrkActualUse, "0000000000")
      End Select
      dr.Item("listno") = WrkListNo
      dr.Item("name") = Trim(._CUNAM1)
      dr.Item("location") = Trim(Trim(._CULOCNO) & " " & Trim(._CULOC))
      dr.Item("meteruse") = WrkActualUse
      dr.Item("previoususe") = WrkPreviousUse
      dr.Item("diff") = WrkDiff
      dr.Item("pctdiff") = WrkDiffPct
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
myUTCUSTQ.CloseFile()
End Sub

  Private Function CalcMetered(ByVal ReadingDate As Date) As Long
    Dim MyUBCalcReading As UBCalcReading.MyData
    Dim MyUBCalcBill As UBCalcBill.MeteredUse
    Dim MyUBCalcBill2 As UBCalcBill.BillMetered
    Dim WrkReadingCurr As Integer
    Dim WrkReadingPrev As Integer
    Dim WrkReading2 As Integer
    Dim WrkReading3 As Integer

    MyUBCalcReading = New UBCalcReading.mydata(MyDBConnect)
    MyUBCalcBill = New UBCalcBill.MeteredUse(myDBConnect)
    MyUBCalcBill2 = New UBCalcBill.BillMetered(myDBConnect)

    With MyUBCalcReading
      .In_ListNo = WrkListNo
      .In_RateType = WrkUBType
      If MyFrmUB214B.RbPerAnnual.Checked Then
        .In_AnnualBill = True
      Else
        .In_AnnualBill = False
      End If
      .In_BillDate = ReadingDate
      .GetMeterReadings()
      WrkReadingCurr = .Out_MeterReadCurr
      WrkReadingPrev = .Out_MeterReadPrev
      WrkReading2 = .Out_MeterRead2
      WrkReading3 = .Out_MeterRead3
    End With

    With MyUBCalcBill
      .In_RateType = WrkUBType
      .In_MeterSize = myUTCUSTQ._CUMSIZ
      .In_MeterReadCurr = WrkReadingCurr
      .In_MeterReadPrev = WrkReadingPrev
      .In_MeterRead2 = WrkReading2
      .In_MeterRead3 = WrkReading3
      .In_Units = myUTCUSTQ._CUUNIT
      If MyEDU1 Then
        .In_EDUs = 1
      Else
        .In_EDUs = myUTCUSTQ._CUEDU
      End If
      .CalcMeteredUse()
      Return .Out_ActualUse
    End With
  End Function
Private Function GetRateCode(ByVal WrkUBType As String) As String
  GetRateCode = ""
  myUTCUSTRT.GetOneRecordP(WrkListNo, WrkUBType)
  If myUTCUSTRT.RecordNotFound Then Exit Function

  With myUTCUSTRT
    GetRateCode = ._CRCODE
  End With
End Function

End Module






