Module PrintReport
Public Sub PrtReport()
    'Note: Exemption totals are shared but Major Category totals are not
    Dim dr As Data.DataRow
    Dim I As Integer
    Dim K As Integer

    If dsTotMC.Tables.Count = 0 Then
      BuildDS()
    Else
      dsTotMC.Clear()
      dsTotEx.Clear()
      dsTot.Clear()
      ClearSharedTotals()
    End If

    BufferExem(MyFrmTO101B.ChkLocal.Checked)
    PrtReportRE()
    PrtReportMV()
    PrtReportPP()

    'Write Exemption Totals
    For I = 0 To 200
      If IsNothing(WrkTExCode(I)) Then Exit For
      dr = dsTotEx.Tables(0).NewRow
      dr.Item("texcode") = WrkTExCode(I)
      K = LookupExem(WrkTExCode(I))
      If K >= 0 Then
        dr.Item("texdesc") = WrkExDesc(K)
      Else
        dr.Item("texdesc") = "*** Invalid OPM Group ***"
      End If
      dr.Item("texrecount") = WrkTExRECount(I)
      dr.Item("texre") = WrkTExRE(I)
      dr.Item("texmvcount") = WrkTExMVCount(I)
      dr.Item("texmv") = WrkTExMV(I)
      dr.Item("texppcount") = WrkTExPPCount(I)
      dr.Item("texpp") = WrkTExPP(I)
      dr.Item("textotcount") = WrkTExRECount(I) + WrkTExMVCount(I) + WrkTExPPCount(I)
      dr.Item("textot") = WrkTExRE(I) + WrkTExMV(I) + WrkTExPP(I)
      dsTotEx.Tables(0).Rows.Add(dr)
    Next I

    dr = dsTot.Tables(0).NewRow
    dr.Item("totre") = WrkTotalRE
    dr.Item("totmv") = WrkTotalMV
    dr.Item("totpp") = WrkTotalPP
		dr.Item("tot") = WrkTotalRE + WrkTotalMV + WrkTotalPP
    dr.Item("totexre") = WrkTotExRE
    dr.Item("totexmv") = WrkTotExMV
    dr.Item("totexpp") = WrkTotExPP
    dr.Item("totex") = WrkTotExRE + WrkTotExMV + WrkTotExPP
    dr.Item("totgrand") = dr.Item("tot") - dr.Item("totex")
    dsTot.Tables(0).Rows.Add(dr)

    GetOPMAssr()

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .WrkdsTotMC = dsTotMC
      .WrkdsTotEx = dsTotEx
      .WrkdsTot = dsTot
      .WrkBTR = MyFrmTO101B.ChkBAA.Checked
      .Show()
    End With
End Sub

End Module






