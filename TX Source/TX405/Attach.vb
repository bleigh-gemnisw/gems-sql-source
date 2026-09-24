Module Attach
  Dim Myattach As Attachit.FrmAttachit
  Public Sub ShowAttachit(Keystring As String)
    Myattach = New Attachit.FrmAttachit
    With Myattach
      .DBConn = myDBConnect
      .Program = "CASHREG"
      .KeyString = Keystring
      .LoadForm()
    End With
    Myattach = Nothing
  End Sub
  Public Function GetAttachcount(Keystring As String) As Integer
    Myattach = New Attachit.FrmAttachit
    With Myattach
      .DBConn = myDBConnect
      .Program = "CASHREG"
      .KeyString = Keystring
      GetAttachcount = .getcount()
    End With
    Myattach = Nothing
  End Function
End Module
