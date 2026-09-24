Module PrintReport
Public Sub PrtReport(ByVal WrkPost As Boolean)

  MyFrmCrViewer = New FrmCrViewer
  MyFrmCrViewer.Wrkds = myds
  MyFrmCrViewer.WrkPost = WrkPost
  MyFrmCrViewer.Show()
  End Sub
End Module






