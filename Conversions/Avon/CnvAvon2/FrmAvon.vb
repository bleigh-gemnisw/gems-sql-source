Imports System.Text
Imports System.IO
Public Class FrmAvon
  Private Sub FrmAvon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    TxtType.Text = ""
    TxtYear.Text = "2000"
  End Sub

  Private Sub LnkFilePath_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
    With OpenFileDialog1
      .ReadOnlyChecked = True
      .ShowDialog()
      LblFilePath.Text = .FileName
    End With
  End Sub

  Private Sub BtnConvert_Click(sender As Object, e As EventArgs) Handles BtnConvert.Click
    Impdata()
  End Sub
End Class