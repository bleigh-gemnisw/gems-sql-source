Imports System.Text
Imports System.IO
Module PrintReport
Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALQ As TXREALQ.myData
Dim myTXREALCQ As TXREALCQ.myData
Dim DsTXREAL As DataSet = New DataSet
Dim ds As DataSet = New DataSet
Dim dsFarm As DataSet = New DataSet
Dim dsForest As DataSet = New DataSet
Dim dsOpen As DataSet = New DataSet
Dim dsTot As DataSet = New DataSet
Dim dr As Data.DataRow
Dim sw As StreamWriter

Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkFrozenFile As Boolean

Dim WrkGross(6) As Integer
Dim WrkCode(6) As Integer
Dim WrkAcre(6) As Decimal
Dim WrkCount(6) As Decimal
Dim WrkFile As String

'Totals
Dim WrkTCodes(3) As Integer
Dim WrkTCodesDesc(3) As String
Dim WrkTCodesAcres(3) As Decimal
Dim WrkTCodesGross(3) As Decimal
Dim WrkTCodesCount(3) As Integer

  Public Sub PrtReport()

  myTXREALQ = New TXREALQ.mydata(MyDBConnect)
  myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)

  With MyFrmTA219B
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    If .TxtDist.Text = "" Then
      WrkDistAll = True
    End If
    WrkFrozenFile = False
    If .ChkFrozenFile.Checked Then
      WrkFrozenFile = True
    End If
    WrkFile = .LblFilePath.Text
  End With

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
    dsFarm.Clear()
    dsForest.Clear()
    dsOpen.Clear()
    dsTot.Clear()
  End If

  If WrkFile <> String.Empty Then
    sw = New StreamWriter(MyFrmTA219B.LblFilePath.Text)
  End If
  GetDetail()

  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .wrkds = ds
    .wrkdsFarm = dsFarm
    .wrkdsForest = dsForest
    .wrkdsOpen = dsOpen
    .wrkdsTot = dsTot
    .Show()
  End With
  End Sub
Friend Sub BuildDS()
  Dim myTable As New DataTable
  Dim myTableTot As New DataTable

  With myTable
    .TableName = "mytable"
    .Columns.Add("listno", Type.GetType("System.Int64"))
    .Columns.Add("addr1", Type.GetType("System.String"))
    .Columns.Add("addr2", Type.GetType("System.String"))
    .Columns.Add("addr3", Type.GetType("System.String"))
    .Columns.Add("addr4", Type.GetType("System.String"))
    .Columns.Add("addr5", Type.GetType("System.String"))
    .Columns.Add("proploc", Type.GetType("System.String"))
    .Columns.Add("map", Type.GetType("System.String"))
    .Columns.Add("volpage", Type.GetType("System.String"))
    .Columns.Add("acqdate", Type.GetType("System.String"))
    .Columns.Add("purdate", Type.GetType("System.String"))
    .Columns.Add("expdate", Type.GetType("System.String"))
    .Columns.Add("gross1", Type.GetType("System.Int64"))
    .Columns.Add("gross2", Type.GetType("System.Int64"))
    .Columns.Add("gross3", Type.GetType("System.Int64"))
    .Columns.Add("descr1", Type.GetType("System.String"))
    .Columns.Add("descr2", Type.GetType("System.String"))
    .Columns.Add("descr3", Type.GetType("System.String"))
    .Columns.Add("acres", Type.GetType("System.Decimal"))
    .Columns.Add("acres1", Type.GetType("System.Decimal"))
    .Columns.Add("acres2", Type.GetType("System.Decimal"))
    .Columns.Add("acres3", Type.GetType("System.Decimal"))
    .Columns.Add("aacre", Type.GetType("System.Int32"))
  End With
  ds.Tables.Add(myTable)
  dsFarm = ds.Clone
  dsForest = ds.Clone
  dsOpen = ds.Clone

  With myTableTot
    .TableName = "mytabletot"
    .Columns.Add("tcode", Type.GetType("System.Int16"))
    .Columns.Add("tdesc", Type.GetType("System.String"))
    .Columns.Add("tacres", Type.GetType("System.Decimal"))
    .Columns.Add("tgross", Type.GetType("System.Int64"))
    .Columns.Add("tcount", Type.GetType("System.Int64"))
  End With
  dsTot.Tables.Add(myTableTot)
End Sub
Private Sub GetDetail()
Dim AddrLine() As String
Dim WrkSort As String
Dim WrkQry As String
Dim I As Integer
Dim J As Integer
Dim K As Integer
Dim WrkAnd As String
Dim WrkOr As String
Dim WrkAcres As Decimal
Dim WrkRptAcres1 As Decimal
Dim WrkRptAcres2 As Decimal
Dim WrkRptAcres3 As Decimal
Dim WrkRptGross1 As Integer
Dim WrkRptGross2 As Integer
Dim WrkRptGross3 As Integer
Dim WrkRptDescr1 As String
Dim WrkRptDescr2 As String
Dim WrkRptDescr3 As String
Dim WrkFarmAcres As Decimal
Dim WrkFarmGross As Integer
Dim WrkForestAcres As Decimal
Dim WrkForestGross As Integer
Dim WrkOpenAcres As Decimal
Dim WrkOpenGross As Integer
Dim Good As Boolean

If myDBConnect.ServerAS400 Then
  WrkOr = " *or "
  WrkAnd = " *and "
Else
  WrkOr = " or "
  WrkAnd = " and "
 End If

WrkSort = "NAME, LIST#"
WrkQry = ""
If Not WrkDistAll Then
  WrkQry = "dist=" & WrkDist
End If

If Not WrkFrozenFile Then
  DsTXREAL = myTXREALQ.GetQry(WrkSort, WrkQry, 0)
Else
  DsTXREAL = myTXREALCQ.GetQry(WrkSort, WrkQry, 0)
End If

If DsTXREAL.Tables(0).Rows.Count = 0 Then
  myTXREALQ.CloseFile()
  myTXREALCQ.CloseFile()
  Exit Sub
End If

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

WrkTCodes(0) = GetTXCDSFCode("ALL")
If WrkTCodes(0) = 0 Then WrkTCodes(0) = 60
WrkTCodesDesc(0) = GetTXCodeDesc(WrkTCodes(0), "R")

WrkTCodes(1) = GetTXCDSFCode("FARM")
If WrkTCodes(1) = 0 Then WrkTCodes(1) = 61
WrkTCodesDesc(1) = GetTXCodeDesc(WrkTCodes(1), "R")

WrkTCodes(2) = GetTXCDSFCode("FORE")
If WrkTCodes(2) = 0 Then WrkTCodes(2) = 62
WrkTCodesDesc(2) = GetTXCodeDesc(WrkTCodes(2), "R")

WrkTCodes(3) = GetTXCDSFCode("OPEN")
If WrkTCodes(3) = 0 Then WrkTCodes(3) = 63
WrkTCodesDesc(3) = GetTXCodeDesc(WrkTCodes(3), "R")

Array.Clear(WrkTCodesAcres, 0, 4)
Array.Clear(WrkTCodesGross, 0, 4)
Array.Clear(WrkTCodesCount, 0, 4)

If WrkFile <> String.Empty Then
  sw.WriteLine(BuildHeadings)
End If

For I = 0 To (DsTXREAL.Tables(0).Rows.Count - 1)
  With DsTXREAL.Tables(0).Rows(I)
    WrkGross(0) = .Item("ass1")
    WrkGross(1) = .Item("ass2")
    WrkGross(2) = .Item("ass3")
    WrkGross(3) = .Item("ass4")
    WrkGross(4) = .Item("ass5")
    WrkGross(5) = .Item("ass6")
    WrkGross(6) = .Item("ass7")
    WrkCode(0) = .Item("code1")
    WrkCode(1) = .Item("code2")
    WrkCode(2) = .Item("code3")
    WrkCode(3) = .Item("code4")
    WrkCode(4) = .Item("code5")
    WrkCode(5) = .Item("code6")
    WrkCode(6) = .Item("code7")
    WrkAcre(0) = .Item("acre1")
    WrkAcre(1) = .Item("acre2")
    WrkAcre(2) = .Item("acre3")
    WrkAcre(3) = .Item("acre4")
    WrkAcre(4) = .Item("acre5")
    WrkAcre(5) = .Item("acre6")
    WrkAcre(6) = .Item("acre7")

    WrkAcres = 0
    WrkRptAcres1 = 0
    WrkRptAcres2 = 0
    WrkRptAcres3 = 0
    WrkRptGross1 = 0
    WrkRptGross2 = 0
    WrkRptGross3 = 0
    WrkFarmAcres = 0
    WrkFarmGross = 0
    WrkForestAcres = 0
    WrkForestGross = 0
    WrkOpenAcres = 0
    WrkOpenGross = 0
    WrkRptDescr1 = String.Empty
    WrkRptDescr2 = String.Empty
    WrkRptDescr3 = String.Empty
    Good = False
    For J = 0 To 6
      If WrkCode(J) = 0 Then Continue For
      WrkAcres = WrkAcres + WrkAcre(J)
      K = LookupTCodes(WrkCode(J))
      If K >= 0 Then
        WrkTCodesAcres(K) = WrkTCodesAcres(K) + WrkAcre(J)
        WrkTCodesGross(K) = WrkTCodesGross(K) + WrkGross(J)
        WrkTCodesCount(K) = WrkTCodesCount(K) + 1
        'Determine which bucket (1,2 or 3) to put acres & gross in
        If WrkRptGross1 = 0 Then
          WrkRptGross1 = WrkGross(J)
          WrkRptAcres1 = WrkAcre(J)
          WrkRptDescr1 = GetTXCodeDesc(WrkCode(J), "R")
        Else
          If WrkRptGross2 = 0 Then
            WrkRptGross2 = WrkGross(J)
            WrkRptAcres2 = WrkAcre(J)
            WrkRptDescr2 = GetTXCodeDesc(WrkCode(J), "R")
          Else
            If WrkRptGross3 = 0 Then
              WrkRptGross3 = WrkGross(J)
              WrkRptAcres3 = WrkAcre(J)
              WrkRptDescr3 = GetTXCodeDesc(WrkCode(J), "R")
            End If
          End If
        End If
        Good = True
      End If
      'Farm
      If WrkCode(J) = WrkTCodes(1) Then
        WrkFarmAcres = WrkAcre(J)
        WrkFarmGross = WrkGross(J)
      End If
      'Forest
      If WrkCode(J) = WrkTCodes(2) Then
        WrkForestAcres = WrkAcre(J)
        WrkForestGross = WrkGross(J)
      End If
      'Open
      If WrkCode(J) = WrkTCodes(3) Then
        WrkOpenAcres = WrkAcre(J)
        WrkOpenGross = WrkGross(J)
      End If
    Next J

    If Not Good Then GoTo NextRec

    dr = ds.Tables(0).NewRow
    dr.Item("listno") = .Item("list#")
    AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"), _
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
    dr.Item("addr1") = AddrLine(0)
    dr.Item("addr2") = AddrLine(1)
    dr.Item("addr3") = AddrLine(2)
    dr.Item("addr4") = AddrLine(3)
    dr.Item("addr5") = AddrLine(4)
    dr.Item("proploc") = .Item("loc#") & " " & .Item("loc")
    dr.Item("map") = .Item("map")
    dr.Item("volpage") = .Item("vol") & "/" & .Item("pge")
    If .Item("aidte") > 0 Then
      dr.Item("acqdate") = Format(MyUtils.GetDBDateMDY(.Item("aidte")), "M/dd/yyyy")
    End If
    If .Item("aedate") > 0 Then
      dr.Item("expdate") = Format(MyUtils.GetDBDateMDY(.Item("aedate")), "M/dd/yyyy")
    End If
    If .Item("purdt") > 0 Then
      dr.Item("purdate") = Format(MyUtils.GetDBDate(.Item("purdt")), "M/dd/yyyy")
    End If
    dr.Item("acres") = WrkAcres
    dr.Item("acres1") = WrkRptAcres1
    dr.Item("acres2") = WrkRptAcres2
    dr.Item("acres3") = WrkRptAcres3
    dr.Item("aacre") = .Item("aacre")
    dr.Item("gross1") = WrkRptGross1
    dr.Item("gross2") = WrkRptGross2
    dr.Item("gross3") = WrkRptGross3
    dr.Item("descr1") = WrkRptDescr1
    dr.Item("descr2") = WrkRptDescr2
    dr.Item("descr3") = WrkRptDescr3
    ds.Tables(0).Rows.Add(dr)
    If WrkFile <> String.Empty Then
      sw.WriteLine(BuildCSV(I))
    End If

    'Farm Only
    If WrkFarmGross > 0 Then
      dr = dsFarm.Tables(0).NewRow
      dr.Item("listno") = .Item("list#")
      dr.Item("addr1") = AddrLine(0)
      dr.Item("addr2") = AddrLine(1)
      dr.Item("addr3") = AddrLine(2)
      dr.Item("addr4") = AddrLine(3)
      dr.Item("addr5") = AddrLine(4)
      dr.Item("proploc") = .Item("loc#") & " " & .Item("loc")
      dr.Item("map") = .Item("map")
      dr.Item("volpage") = .Item("vol") & "/" & .Item("pge")
      If .Item("aidte") > 0 Then
        dr.Item("acqdate") = Format(MyUtils.GetDBDateMDY(.Item("aidte")), "M/dd/yyyy")
      End If
      If .Item("aedate") > 0 Then
        dr.Item("expdate") = Format(MyUtils.GetDBDateMDY(.Item("aedate")), "M/dd/yyyy")
      End If
      If .Item("purdt") > 0 Then
        dr.Item("purdate") = Format(MyUtils.GetDBDate(.Item("purdt")), "M/dd/yyyy")
      End If
      dr.Item("acres") = WrkAcres
      dr.Item("acres1") = WrkFarmAcres
      dr.Item("acres2") = 0
      dr.Item("acres3") = 0
      dr.Item("aacre") = .Item("aacre")
      dr.Item("gross1") = WrkFarmGross
      dr.Item("gross2") = 0
      dr.Item("gross3") = 0
      dr.Item("descr1") = String.Empty
      dr.Item("descr2") = String.Empty
      dr.Item("descr3") = String.Empty
      dsFarm.Tables(0).Rows.Add(dr)
    End If

    'Forest Only
    If WrkForestGross > 0 Then
      dr = dsForest.Tables(0).NewRow
      dr.Item("listno") = .Item("list#")
      dr.Item("addr1") = AddrLine(0)
      dr.Item("addr2") = AddrLine(1)
      dr.Item("addr3") = AddrLine(2)
      dr.Item("addr4") = AddrLine(3)
      dr.Item("addr5") = AddrLine(4)
      dr.Item("proploc") = .Item("loc#") & " " & .Item("loc")
      dr.Item("map") = .Item("map")
      dr.Item("volpage") = .Item("vol") & "/" & .Item("pge")
      If .Item("aidte") > 0 Then
        dr.Item("acqdate") = Format(MyUtils.GetDBDateMDY(.Item("aidte")), "M/dd/yyyy")
      End If
      If .Item("aedate") > 0 Then
        dr.Item("expdate") = Format(MyUtils.GetDBDateMDY(.Item("aedate")), "M/dd/yyyy")
      End If
      If .Item("purdt") > 0 Then
        dr.Item("purdate") = Format(MyUtils.GetDBDate(.Item("purdt")), "M/dd/yyyy")
      End If
      dr.Item("acres") = WrkAcres
      dr.Item("acres1") = WrkForestAcres
      dr.Item("acres2") = 0
      dr.Item("acres3") = 0
      dr.Item("aacre") = .Item("aacre")
      dr.Item("gross1") = WrkForestGross
      dr.Item("gross2") = 0
      dr.Item("gross3") = 0
      dr.Item("descr1") = String.Empty
      dr.Item("descr2") = String.Empty
      dr.Item("descr3") = String.Empty
      dsForest.Tables(0).Rows.Add(dr)
    End If

    'Open Only
    If WrkOpenGross > 0 Then
      dr = dsOpen.Tables(0).NewRow
      dr.Item("listno") = .Item("list#")
      dr.Item("addr1") = AddrLine(0)
      dr.Item("addr2") = AddrLine(1)
      dr.Item("addr3") = AddrLine(2)
      dr.Item("addr4") = AddrLine(3)
      dr.Item("addr5") = AddrLine(4)
      dr.Item("proploc") = .Item("loc#") & " " & .Item("loc")
      dr.Item("map") = .Item("map")
      dr.Item("volpage") = .Item("vol") & "/" & .Item("pge")
      If .Item("aidte") > 0 Then
        dr.Item("acqdate") = Format(MyUtils.GetDBDateMDY(.Item("aidte")), "M/dd/yyyy")
      End If
      If .Item("aedate") > 0 Then
        dr.Item("expdate") = Format(MyUtils.GetDBDateMDY(.Item("aedate")), "M/dd/yyyy")
      End If
      If .Item("purdt") > 0 Then
        dr.Item("purdate") = Format(MyUtils.GetDBDate(.Item("purdt")), "M/dd/yyyy")
      End If
      dr.Item("acres") = WrkAcres
      dr.Item("acres1") = WrkOpenAcres
      dr.Item("acres2") = 0
      dr.Item("acres3") = 0
      dr.Item("aacre") = .Item("aacre")
      dr.Item("gross1") = WrkOpenGross
      dr.Item("gross2") = 0
      dr.Item("gross3") = 0
      dr.Item("descr1") = String.Empty
      dr.Item("descr2") = String.Empty
      dr.Item("descr3") = String.Empty
      dsOpen.Tables(0).Rows.Add(dr)
    End If
  End With

NextRec:
With myFrmProgress
  WrkPct = ((I + 1) / DsTXREAL.Tables(0).Rows.Count) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
  End If
End With
Next
    '@@@   11/16/2023 - if code is 60 or 600 and all zeros then do not print it
    For I = 0 To 3
  dr = dsTot.Tables(0).NewRow
  dr.Item("tcode") = WrkTCodes(I)
  dr.Item("tdesc") = WrkTCodesDesc(I)
  dr.Item("tacres") = WrkTCodesAcres(I)
  dr.Item("tgross") = WrkTCodesGross(I)
      dr.Item("tcount") = WrkTCodesCount(I)
      If WrkTCodes(I) = 60 Or WrkTCodes(I) = 600 Then
        If WrkTCodesAcres(I) = 0 And WrkTCodesAcres(I) = 0 And WrkTCodesGross(I) = 0 Then GoTo skipzero60
      End If
      dsTot.Tables(0).Rows.Add(dr)
skipzero60:
    Next I

If WrkFile <> String.Empty Then
  sw.Flush()
  sw.Close()
End If

myFrmProgress.Close()
Application.DoEvents()
myTXREALQ.CloseFile()
myTXREALCQ.CloseFile()

End Sub
Private Function LookupTCodes(ByVal Code As Integer) As Integer
     Dim I As Integer

     For I = 0 To WrkTCodes.GetUpperBound(0)
       If WrkTCodes(I) = 0 Then
         Return -1
       End If
       If Code = WrkTCodes(I) Then
         Return I
       End If
    Next

    Return -1
End Function
Public Function BuildHeadings()
  Dim sb As StringBuilder
  Dim WrkStr As String
  sb = New StringBuilder
  sb.Append("List#")
  sb.Append(",")
  sb.Append("Name")
  sb.Append(",")
  sb.Append("Name 2")
  sb.Append(",")
  sb.Append("Address 1")
  sb.Append(",")
  sb.Append("Address 2")
  sb.Append(",")
  sb.Append("City")
  sb.Append(",")
  sb.Append("State")
  sb.Append(",")
  sb.Append("Zip")
  sb.Append(",")
  sb.Append("Location")
  sb.Append(",")
  sb.Append("Map")
  sb.Append(",")
  sb.Append("Vol/Page")
  sb.Append(",")
  sb.Append("Acquired Date")
  sb.Append(",")
  sb.Append("Total Acres")
  sb.Append(",")
  sb.Append("Acres 1")
  sb.Append(",")
  sb.Append("Gross 1")
  sb.Append(",")
  sb.Append("Descr 1")
  sb.Append(",")
  sb.Append("Acres 2")
  sb.Append(",")
  sb.Append("Gross 2")
  sb.Append(",")
  sb.Append("Descr 2")
  sb.Append(",")
  sb.Append("Acres 3")
  sb.Append(",")
  sb.Append("Gross 3")
  sb.Append(",")
  sb.Append("Descr 3")
  WrkStr = sb.ToString
  sb = Nothing
  Return WrkStr
End Function
Private Function BuildCSV(ByVal I As Integer) As String
  Dim sb As StringBuilder
  Const cQuote As String = Chr(34)
  Dim WrkStr As String
  WrkStr = ""
  sb = New StringBuilder
  sb.Append(dr.Item("listno"))
  sb.Append(",")
  sb.Append(cQuote)
  sb.Append(DsTXREAL.Tables(0).Rows(I).Item("name"))
  sb.Append(cQuote)
  sb.Append(",")
  sb.Append(cQuote)
  sb.Append(DsTXREAL.Tables(0).Rows(I).Item("sname"))
  sb.Append(cQuote)
  sb.Append(",")
  sb.Append(cQuote)
  sb.Append(DsTXREAL.Tables(0).Rows(I).Item("add1"))
  sb.Append(cQuote)
  sb.Append(",")
  sb.Append(cQuote)
  sb.Append(DsTXREAL.Tables(0).Rows(I).Item("add2"))
  sb.Append(cQuote)
  sb.Append(",")
  sb.Append(cQuote)
  sb.Append(DsTXREAL.Tables(0).Rows(I).Item("city"))
  sb.Append(cQuote)
  sb.Append(",")
  sb.Append(cQuote)
  sb.Append(DsTXREAL.Tables(0).Rows(I).Item("state"))
  sb.Append(cQuote)
  sb.Append(",")
  sb.Append(cQuote)
  sb.Append(Format(DsTXREAL.Tables(0).Rows(I).Item("zip5"), "00000"))
  sb.Append(cQuote)
  sb.Append(",")
  sb.Append(cQuote)
  sb.Append(Trim(DsTXREAL.Tables(0).Rows(I).Item("loc#")))
  sb.Append(" ")
  sb.Append(DsTXREAL.Tables(0).Rows(I).Item("loc"))
  sb.Append(cQuote)
  sb.Append(",")
  sb.Append(cQuote)
  sb.Append(dr.Item("map"))
  sb.Append(cQuote)
  sb.Append(",")
  sb.Append(cQuote)
  sb.Append(dr.Item("volpage"))
  sb.Append(cQuote)
  sb.Append(",")
  sb.Append(dr.Item("acqdate"))
  sb.Append(",")
  sb.Append(dr.Item("acres"))
  sb.Append(",")
  sb.Append(dr.Item("acres1"))
  sb.Append(",")
  sb.Append(dr.Item("gross1"))
  sb.Append(",")
  sb.Append(dr.Item("descr1"))
  sb.Append(",")
  sb.Append(dr.Item("acres2"))
  sb.Append(",")
  sb.Append(dr.Item("gross2"))
  sb.Append(",")
  sb.Append(dr.Item("descr2"))
  sb.Append(",")
  sb.Append(dr.Item("acres3"))
  sb.Append(",")
  sb.Append(dr.Item("gross3"))
  sb.Append(",")
  sb.Append(dr.Item("descr3"))
  WrkStr = sb.ToString
  sb = Nothing
  Return WrkStr
End Function
End Module






