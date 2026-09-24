Module PrintReport
Public Sub PrtReport()
    'Note: Exemption totals are shared but Major Category totals are not
    Dim dr As Data.DataRow
    Dim I As Integer
    Dim K As Integer

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
      dsEld.Clear()
      ClearSharedTotals()
    End If

    PrtReportRE()
    PrtReportMV()
    PrtReportPP()

    dr = ds.Tables(0).NewRow
    dr.Item("group") = "1"
    dr.Item("code") = ""
    dr.Item("desc") = "ACCOUNTS"
    dr.Item("re") = WrkTotalRE
    dr.Item("mv") = WrkTotalMV
    dr.Item("pp") = WrkTotalPP
    dr.Item("tot") = WrkTotalRE + WrkTotalMV + WrkTotalPP
    ds.Tables(0).Rows.Add(dr)

    dr = ds.Tables(0).NewRow
    dr.Item("group") = "2"
    dr.Item("code") = ""
    dr.Item("desc") = "GROSS"
    dr.Item("re") = WrkTotalREGross
    dr.Item("mv") = WrkTotalMVGross
    dr.Item("pp") = WrkTotalPPGross
    dr.Item("tot") = WrkTotalREGross + WrkTotalMVGross + WrkTotalPPGross
    ds.Tables(0).Rows.Add(dr)

    dr = ds.Tables(0).NewRow
    dr.Item("group") = "3"
    dr.Item("code") = ""
    dr.Item("desc") = "EXEMPTIONS:"
    dr.Item("re") = 0
    dr.Item("mv") = 0
    dr.Item("pp") = 0
    dr.Item("tot") = 0
    ds.Tables(0).Rows.Add(dr)

    'Write Totals
    For I = 0 To 200
      If IsNothing(WrkTExCode(I)) Then Exit For
      dr = ds.Tables(0).NewRow
      dr.Item("group") = "4"
      dr.Item("code") = WrkTExCode(I)
      K = LookupExem(WrkTExCode(I))
      dr.Item("desc") = WrkExDesc(K)
      dr.Item("re") = WrkTExRE(I)
      dr.Item("mv") = WrkTExMV(I)
      dr.Item("pp") = WrkTExPP(I)
      dr.Item("tot") = WrkTExRE(I) + WrkTExMV(I) + WrkTExPP(I)
      ds.Tables(0).Rows.Add(dr)
      WrkTotalREEx = WrkTotalREEx + WrkTExRE(I)
      WrkTotalMVEx = WrkTotalMVEx + WrkTExMV(I)
      WrkTotalPPEx = WrkTotalPPEx + WrkTExPP(I)
    Next I

    dr = ds.Tables(0).NewRow
    dr.Item("group") = "5"
    dr.Item("code") = ""
    dr.Item("desc") = "TOTAL EXEMPTIONS"
    dr.Item("re") = WrkTotalREEx
    dr.Item("mv") = WrkTotalMVEx
    dr.Item("pp") = WrkTotalPPEx
    dr.Item("tot") = WrkTotalREEx + WrkTotalMVEx + WrkTotalPPEx
    ds.Tables(0).Rows.Add(dr)

    dr = ds.Tables(0).NewRow
    dr.Item("group") = "6"
    dr.Item("code") = ""
    dr.Item("desc") = "NET"
    dr.Item("re") = WrkTotalRENet
    dr.Item("mv") = WrkTotalMVNet
    dr.Item("pp") = WrkTotalPPNet
    dr.Item("tot") = WrkTotalRENet + WrkTotalMVNet + WrkTotalPPNet
    ds.Tables(0).Rows.Add(dr)

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .WrkdsEld = dsEld
      .WrkCC = MyFrmTAB01B.ChkCC.Checked
      .WrkBTR = MyFrmTAB01B.ChkBAA.Checked
      .WrkFrozen = MyFrmTAB01B.ChkFrozenFile.Checked
      .Show()
    End With
End Sub

End Module






