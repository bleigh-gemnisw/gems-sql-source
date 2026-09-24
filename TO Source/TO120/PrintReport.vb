Imports System.io
Module PrintReport
Public sw As StreamWriter
Public Sub PrtReport()
    'Note: Exemption totals are shared 
    Dim dr As Data.DataRow
    Dim I As Integer
    Dim K As Integer

    sw = New StreamWriter(MyFrmTO120B.LblFile.Text)
    WriteDVAHeader()

    If dsTotEx.Tables.Count = 0 Then
      BuildDS()
      BuildDS2()
      ds3 = dsTotEx.Clone
    Else
      dsTotEx.Clear()
      ds2.Clear()
      ds3.Clear()
      ClearSharedTotals()
    End If

    PrtReportRE()
    PrtReportMV()
    PrtReportPP()

    For I = 0 To 100
      If IsNothing(WrkTExCode(I)) Then Exit For
      'Write Exemption Totals
      dr = dsTotEx.Tables(0).NewRow
      dr.Item("texcode") = WrkTExCode(I)
      K = LookupExem(WrkTExCode(I))
      dr.Item("texdesc") = WrkExDesc(K)
      dr.Item("texrecount") = WrkTExRECount(I)
      dr.Item("texre") = WrkTExRE(I)
      dr.Item("texmvcount") = WrkTExMVCount(I)
      dr.Item("texmv") = WrkTExMV(I)
      dr.Item("texppcount") = WrkTExPPCount(I)
      dr.Item("texpp") = WrkTExPP(I)
      dr.Item("textotcount") = WrkTExRECount(I) + WrkTExMVCount(I) + WrkTExPPCount(I)
      dr.Item("textot") = WrkTExRE(I) + WrkTExMV(I) + WrkTExPP(I)
      dsTotEx.Tables(0).Rows.Add(dr)
      'Write Account Totals
      dr = ds3.Tables(0).NewRow
      dr.Item("texcode") = WrkTExCode(I)
      K = LookupExem(WrkTExCode(I))
      dr.Item("texdesc") = WrkExDesc(K)
      dr.Item("texrecount") = WrkTExREAccts(I)
      dr.Item("texre") = WrkTExRE(I)
      dr.Item("texmvcount") = WrkTExMVAccts(I)
      dr.Item("texmv") = WrkTExMV(I)
      dr.Item("texppcount") = WrkTExPPAccts(I)
      dr.Item("texpp") = WrkTExPP(I)
      dr.Item("textotcount") = WrkTExREAccts(I) + WrkTExMVAccts(I) + WrkTExPPAccts(I)
      dr.Item("textot") = WrkTExRE(I) + WrkTExMV(I) + WrkTExPP(I)
      ds3.Tables(0).Rows.Add(dr)
    Next I

    sw.Close()

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .WrkdsTotEx = dsTotEx
      .Wrkds2 = ds2
      .Wrkds3 = ds3
      .Show()
    End With
End Sub

End Module






