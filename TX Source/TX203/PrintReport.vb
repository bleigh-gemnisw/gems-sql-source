Module PrintReport

Dim WrkYear As Integer

  Public Sub PrtReport()

  With MyFrmTX203B
    WrkYear = .TxtGLYear.Text
  End With

  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .WrkYear = WrkYear
    .Show()
  End With
  End Sub
End Module






