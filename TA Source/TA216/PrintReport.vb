Module PrintReport
Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALQ As TXREALQ.myData
Dim myTXREALCQ As TXREALCQ.myData
Dim myTXCDSF As TXCDSF.myData
Dim DsTXREAL As DataSet = New DataSet
Dim ds As DataSet = New DataSet
Dim dsTot As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkFrozenFile As Boolean

Dim WrkCode(6) As Integer
Dim WrkAcre(6) As Decimal
Dim WrkTAcres As Decimal

  Public Sub PrtReport()

	myTXREALQ = New TXREALQ.mydata(MyDBConnect)
	myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)
  myTXCDSF = New TXCDSF.mydata(MyDBConnect)

  With MyFrmTA216B
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    If .TxtDist.Text = "" Then
      WrkDistAll = True
    End If
    WrkFrozenFile = False
    If .ChkFrozenFile.Checked Then
      WrkFrozenFile = True
    End If
  End With

  If ds.Tables.Count = 0 Then
    BuildDS()
    BuildDSTot()
  Else
    ds.Clear()
    dsTot.Clear()
  End If

  GetDetail()

  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .wrkds = ds
    .wrkdstot = dsTot
    .WrkTAcres = WrkTAcres
    .Show()
  End With
  End Sub
Friend Sub BuildDS()
  Dim myTable As New DataTable

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
    .Columns.Add("acres", Type.GetType("System.Decimal"))
    .Columns.Add("forest", Type.GetType("System.Decimal"))
  End With
  ds.Tables.Add(myTable)
End Sub
Friend Sub BuildDSTot()
  Dim myTable As New DataTable

  With myTable
    .TableName = "mytable"
    .Columns.Add("code", Type.GetType("System.Int32"))
    .Columns.Add("descr", Type.GetType("System.String"))
    .Columns.Add("count", Type.GetType("System.Int32"))
    .Columns.Add("acres", Type.GetType("System.Decimal"))
    .Columns.Add("forest", Type.GetType("System.Decimal"))
  End With
  dstot.Tables.Add(myTable)
End Sub
Private Sub GetDetail()
Dim AddrLine() As String
Dim WrkSort As String
Dim WrkQry As String
Dim I As Integer
Dim J As Integer
Dim WrkAnd As String
Dim WrkOr As String
Dim WrkFarm As Integer
Dim WrkForest As Integer
Dim WrkOpen As Integer
Dim Wrk10Mil As Integer
Dim WrkAcres As Decimal
Dim WrkAcresFarm As Decimal
Dim WrkAcresForest As Decimal
Dim WrkAcresOpen As Decimal
Dim WrkAcres10Mil As Decimal
Dim WrkCodeFarm As Integer
Dim WrkCodeForest As Integer
Dim WrkCodeOpen As Integer
Dim WrkCode10Mil As Integer
Dim WrkTFarm As Integer
Dim WrkTForest As Integer
Dim WrkTOpen As Integer
Dim WrkT10Mil As Integer
Dim WrkTAcresFarm As Decimal
Dim WrkTAcresForest As Decimal
Dim WrkTAcresOpen As Decimal
Dim WrkTAcres10Mil As Decimal
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

myTXCDSF.GetOneRecordP("FARM")
With myTXCDSF
  WrkCodeFarm = ._TCCODE
End With
If WrkCodeFarm = 0 Then
  WrkCodeFarm = 61
End If

myTXCDSF.GetOneRecordP("FORE")
With myTXCDSF
  WrkCodeForest = ._TCCODE
End With
If WrkCodeForest = 0 Then
  WrkCodeForest = 62
End If

myTXCDSF.GetOneRecordP("OPEN")
With myTXCDSF
  WrkCodeOpen = ._TCCODE
End With
If WrkCodeOpen = 0 Then
  WrkCodeOpen = 63
End If

myTXCDSF.GetOneRecordP("10ML")
With myTXCDSF
  WrkCode10Mil = ._TCCODE
End With
If WrkCode10Mil = 0 Then
  WrkCode10Mil = 71
End If

WrkTFarm = 0
WrkTForest = 0
WrkTOpen = 0
WrkT10Mil = 0
WrkTAcres = 0
WrkTAcresFarm = 0
WrkTAcresForest = 0
WrkTAcresOpen = 0
WrkTAcres10Mil = 0

For I = 0 To (DsTXREAL.Tables(0).Rows.Count - 1)
  With DsTXREAL.Tables(0).Rows(I)
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

    Good = False
    WrkFarm = 0
    WrkForest = 0
    WrkOpen = 0
    Wrk10Mil = 0
    WrkAcres = 0
    WrkAcresFarm = 0
    WrkAcresForest = 0
    WrkAcresOpen = 0
    WrkAcres10Mil = 0
    For J = 0 To 6
      WrkAcres = WrkAcres + WrkAcre(J)
      If WrkCode(J) = WrkCodeFarm Then
        Good = True
        WrkAcresFarm = WrkAcresFarm + WrkAcre(J)
      End If
      If WrkCode(J) = WrkCodeForest Then
        Good = True
        WrkAcresForest = WrkAcresForest + WrkAcre(J)
      End If
      If WrkCode(J) = WrkCodeOpen Then
        Good = True
        WrkAcresOpen = WrkAcresOpen + WrkAcre(J)
      End If
      If WrkCode(J) = WrkCode10Mil Then
        Good = True
        WrkAcres10Mil = WrkAcres10Mil + WrkAcre(J)
      End If
    Next J
    WrkTAcres = WrkTAcres + WrkAcres

    If Not Good Then GoTo NextRec

    If WrkAcresFarm > 0 Then
      WrkFarm = WrkFarm + 1
    End If
    If WrkAcresForest > 0 Then
      WrkForest = WrkForest + 1
    End If
    If WrkAcresOpen > 0 Then
      WrkOpen = WrkOpen + 1
    End If
    If WrkAcres10Mil > 0 Then
      Wrk10Mil = Wrk10Mil + 1
    End If

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
    dr.Item("acres") = WrkAcres
    dr.Item("forest") = WrkAcresFarm + WrkAcresForest + WrkAcresOpen + WrkAcres10Mil
    ds.Tables(0).Rows.Add(dr)
    WrkTFarm = WrkTFarm + WrkFarm
    WrkTForest = WrkTForest + WrkForest
    WrkTOpen = WrkTOpen + WrkOpen
    WrkT10Mil = WrkT10Mil + Wrk10Mil
    WrkTAcresFarm = WrkTAcresFarm + WrkAcresFarm
    WrkTAcresForest = WrkTAcresForest + WrkAcresForest
    WrkTAcresOpen = WrkTAcresOpen + WrkAcresOpen
    WrkTAcres10Mil = WrkTAcres10Mil + WrkAcres10Mil
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

'Totals
dr = dsTot.Tables(0).NewRow
dr.Item("code") = WrkCodeFarm
dr.Item("count") = WrkTFarm
dr.Item("descr") = "Farm"
dr.Item("forest") = WrkTAcresFarm
dsTot.Tables(0).Rows.Add(dr)

dr = dsTot.Tables(0).NewRow
dr.Item("code") = WrkCodeForest
dr.Item("count") = WrkTForest
dr.Item("descr") = "Forest"
dr.Item("forest") = WrkTAcresForest
dsTot.Tables(0).Rows.Add(dr)

dr = dsTot.Tables(0).NewRow
dr.Item("code") = WrkCodeOpen
dr.Item("count") = WrkTOpen
dr.Item("descr") = "Open"
dr.Item("forest") = WrkTAcresOpen
dsTot.Tables(0).Rows.Add(dr)

dr = dsTot.Tables(0).NewRow
dr.Item("code") = WrkCode10Mil
dr.Item("count") = WrkT10Mil
dr.Item("descr") = "10 Mil"
dr.Item("forest") = WrkTAcres10Mil
dsTot.Tables(0).Rows.Add(dr)

myFrmProgress.Close()
Application.DoEvents()
myTXREALQ.CloseFile()
myTXREALCQ.CloseFile()

End Sub
End Module






