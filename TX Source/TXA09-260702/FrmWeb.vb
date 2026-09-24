Imports System.Text
Public Class FrmWeb
  Friend WrkEmail As String
  Friend WrkAcct() As String
  Friend WrkAmount() As String
  Dim myTXPAYCR As TXPAYCR.myData
  Dim myTXPAYID As TXPAYID.myData

  Private Sub FrmWeb_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    MyFrmTXA09.SbpScreen.Text = "Web"
    'MK 10/2/25 Begin
    'Call MyUtils.CenterForm(Me.ParentForm, Me)
    'MK 10/2/25 End
  End Sub

  Private Sub FrmWeb_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    MyFrmTXA09.TBarContinue.Visible = False
    MyFrmTXA094.Show()
  End Sub

  Private Sub FrmWeb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim sb As StringBuilder
    Dim cQuote As Char = Chr(34)
    Dim WrkUrl As String
    Dim WrkType As String
    Dim WrkProdID As Integer
    Dim I As Integer

    myTXPAYCR = New TXPAYCR.mydata(MyDBConnect)
    myTXPAYID = New TXPAYID.mydata(MyDBConnect)
    With myTXPAYCR
      .GetOneRecordP("PP")
      If .RecordNotFound Then
        MsgBox("Missing Pay Credit ID's (TXPAYCR). Please contact hotline.", MsgBoxStyle.Exclamation, "Setup is not completed")
        Exit Sub
      End If
      WrkUrl = Trim(._URL)
    End With

    Me.Text = "Cash Register - Batch " & Str$(MyBatchNo)
    sb = New StringBuilder
    'Compatibility header
    'sb.AppendLine("<head><meta http-equiv=""X-UA-Compatible"" content=""IE=9"" ></head>")
    sb.AppendLine("<form action=" & cQuote & WrkUrl & cQuote & " method=" &
    cQuote & "post" & cQuote & ">")
    sb.AppendLine("<p>Next screen will be an external Website<p>")
    sb.AppendLine("<input type=" & cQuote & "hidden" & cQuote & " name=" & cQuote & "PartnerCD" &
    cQuote & " value=" & cQuote & Trim(myTXPAYCR._PARTNR) & cQuote & ">")
    sb.AppendLine("<input type=" & cQuote & "hidden" & cQuote & " name=" & cQuote & "ReturnURL" &
    cQuote & " value=" & cQuote & cQuote & ">")
    sb.AppendLine("<input type=" & cQuote & "hidden" & cQuote & " name=" & cQuote & "CancelURL" &
    cQuote & " value=" & cQuote & cQuote & ">")
    sb.AppendLine("<textarea name=" & cQuote & "paramXML" & cQuote & " style=" & cQuote &
    "display:none;" & cQuote & ">")
    If WrkEmail <> "" Then
      sb.AppendLine("<params ")
      sb.AppendLine("Email=" & cQuote & Trim(WrkEmail) & cQuote & ">")
    Else
      sb.AppendLine("<params>")
    End If
    For I = 0 To 24
      If WrkAcct(I) & "" = "" Then
        Exit For
      End If
      WrkType = Mid(WrkAcct(I), 3, 1)
      WrkProdID = 0
      myTXPAYID.GetOneRecordP(WrkType)
      If myTXPAYID.RecordNotFound Then
        myTXPAYID.GetOneRecordP("")
        WrkProdID = myTXPAYID._PRODID
      Else
        WrkProdID = myTXPAYID._PRODID
      End If
      sb.AppendLine("<Product ID=" & cQuote & WrkProdID & cQuote & " AccountID=" &
      cQuote & WrkAcct(I) & cQuote & " TaxType=" & cQuote & GetTXTypeDesc(WrkType) &
      cQuote & " Amount=" & cQuote & Format(WrkAmount(I), "fixed") & cQuote & "/>")
    Next
    sb.AppendLine("</params>")
    sb.AppendLine("</textarea>")
    sb.AppendLine("<input type=" & cQuote & "submit" & cQuote & " id=submit" &
    " value=" & cQuote & "Submit" & cQuote & ">")
    sb.AppendLine("</form>")
    Web.DocumentText = sb.ToString
    Web.Document.Write(sb.ToString)
    Web.Refresh()
  End Sub
End Class





