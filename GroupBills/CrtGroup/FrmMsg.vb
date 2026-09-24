Public Class FrmMsg
Friend WrkMsg As String
Friend WrkMsg2 As String
Private Sub FrmMsg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  TxtMsg.Text = WrkMsg
  TxtMsg2.Text = WrkMsg2
End Sub
End Class