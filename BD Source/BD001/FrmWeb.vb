Imports System.Text
Public Class FrmWeb
Friend WrkEmail As String
Friend WrkAcct As String
Friend WrkAmount As String
Dim myBDPAYCR As BDPAYCR.myData

Private Sub FrmWeb_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
  MyFrmBD001.SbpScreen.Text = "Web"
  Call MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
  Private Sub FrmWeb_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
  End Sub

Private Sub FrmWeb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Dim sb As StringBuilder
  Dim cQuote As Char = Chr(34)
  Dim WrkUrl As String

  myBDPAYCR = New BDPAYCR.mydata(MyDBConnect)
  With myBDPAYCR
    .GetOneRecordP("PP")
    If .RecordNotFound Then
      MsgBox("Missing Pay Credit ID's (BDPAYCR). Please contact hotline.", MsgBoxStyle.Exclamation, "Setup is not completed")
      Exit Sub
    End If
    WrkUrl = Trim(._URL)
  End With

  Me.Text = "Credit Card"
  sb = New StringBuilder
  sb.AppendLine("<form action=" & cQuote & WrkUrl & cQuote & " method=" & _
    cQuote & "post" & cQuote & ">")
  sb.AppendLine("<p>Next screen will be an external Website<p>")
  sb.AppendLine("<input type=" & cQuote & "hidden" & cQuote & " name=" & cQuote & "PartnerCD" & _
    cQuote & " value=" & cQuote & Trim(myBDPAYCR._PARTNR) & cQuote & ">")
  sb.AppendLine("<input type=" & cQuote & "hidden" & cQuote & " name=" & cQuote & "ReturnURL" & _
    cQuote & " value=" & cQuote & cQuote & ">")
  sb.AppendLine("<input type=" & cQuote & "hidden" & cQuote & " name=" & cQuote & "CancelURL" & _
    cQuote & " value=" & cQuote & cQuote & ">")
  sb.AppendLine("<textarea name=" & cQuote & "paramXML" & cQuote & " style=" & cQuote & _
    "display:none;" & cQuote & ">")
  If WrkEmail <> "" Then
    sb.AppendLine("<params ")
    sb.AppendLine("Email=" & cQuote & Trim(WrkEmail) & cQuote & ">")
  Else
    sb.AppendLine("<params>")
  End If
  sb.AppendLine("<Product ID=" & cQuote & Trim(myBDPAYCR._PROD) & cQuote & " AccountID=" & _
    cQuote & WrkAcct & cQuote & " Amount=" & cQuote & Format(WrkAmount, "fixed") & cQuote & "/>")
  sb.AppendLine("</params>")
  sb.AppendLine("</textarea>")
  sb.AppendLine("<input type=" & cQuote & "submit" & cQuote & " id=submit" & _
    " value=" & cQuote & "Submit" & cQuote & ">")
  sb.AppendLine("</form>")
  Web.DocumentText = sb.ToString
  Web.Document.Write(sb.ToString)
  Web.Refresh()
 End Sub
End Class





