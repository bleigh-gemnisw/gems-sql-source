Module PrintReport
Public Sub PrtReport()

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    MVMillrtUsed = False
    BufferExem()
    GetOPMAssr()
    GetOPMColl()
    WrkCurREAccts = 0
    WrkCurREExAmt = 0
    WrkCurRERevLoss = 0
    WrkCurMVAccts = 0
    WrkCurMVExAmt = 0
    WrkCurMVRevLoss = 0
    WrkPrvAccts = 0
    WrkPrvExAmt = 0
    WrkPrvRevLoss = 0
    PrtReportRE()
    PrtReportMV()
    PrtReportSU()
    'PrtReportPP()

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .WrkCurREMillRt = CurMillrt * 1000
      .WrkMVMillRt = MVMillrt * 1000
      .WrkPrvMillRt = PrvMillrt * 1000
      .Show()
    End With
End Sub

End Module






