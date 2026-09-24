Module Attach
  Dim Myattach As Attachit.FrmAttachit
  Public Sub ShowAttachit(Program As String, Keystring As String)
    Myattach = New Attachit.FrmAttachit
    With Myattach
      .DBConn = myDBConnect
      .Program = Program
      .KeyString = Keystring
      .LoadForm()
    End With
    Myattach = Nothing
  End Sub
  Public Function GetAttachcount(Program As String, Keystring As String) As Integer
    Myattach = New Attachit.FrmAttachit
    With Myattach
      .DBConn = myDBConnect
      .Program = Program
      .KeyString = Keystring
      GetAttachcount = .getcount()
    End With
    Myattach = Nothing
  End Function
End Module
