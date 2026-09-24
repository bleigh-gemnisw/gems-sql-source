Public Class FrmWeb

Private Sub FrmWeb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Dim WrkURL As String

  WrkURL = "http://gemsnt.com/" & MyAppSettings.WebName & "-webtax/vars/importer.php"

  If WrkURL <> String.Empty Then
    WbPage.Navigate(WrkURL)
  End If
End Sub
End Class





