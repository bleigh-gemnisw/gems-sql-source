Module PrintReport
Public Sub PrtReport()
    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
      ClearSharedTotals()
    End If

    PrtReportRE()
    PrtReportMV()
    PrtReportPP()

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .WrkBTR = MyFrmTA235B.ChkBAA.Checked
      .Show()
    End With
End Sub

End Module






