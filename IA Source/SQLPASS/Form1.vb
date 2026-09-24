Imports System.Text
Public Class Form1
Private Sub BtnProcess_Click(sender As Object, e As EventArgs) Handles BtnProcess.Click
  TxtResult.Text = SetPassword(TxtPass.Text)
End Sub
Public Function SetPassword(ByVal Password As String) As String
  Dim Sb As StringBuilder
  Dim WrkNumber As Integer
  Dim WrkLetter As String
  Dim I As Integer

  Sb = New StringBuilder
  For I = 1 To Len(Password)
    WrkLetter = Mid(Password, I, 1)
    WrkNumber = Asc(WrkLetter)
    Select Case (I Mod 3)
    Case 1
      WrkNumber = WrkNumber + 7
    Case 2
      WrkNumber = WrkNumber + 3
    Case 0
      WrkNumber = WrkNumber + 1
    End Select
    Sb.Append(Format(WrkNumber, "000"))
  Next I

  Return Sb.ToString

End Function

Private Sub Label1_Click(sender As Object, e As EventArgs)
    TxtPass.PasswordChar = ""
End Sub
End Class
