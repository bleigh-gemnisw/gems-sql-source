Module PrintReport
Public Sub PrtReport()

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    BufferExem()
    PrtReportRE()

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .WrkMillRt = MrateMillrt * 1000
      .Show()
    End With
End Sub

End Module






