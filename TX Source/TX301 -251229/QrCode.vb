Imports System.Text
Imports System.Xml

Module QrCode

  ' Base URL for the QR endpoint, built from WebName and WebScript
  Public ReadOnly Property QrBaseUrl As String
    Get
      Dim prefix As String = Trim(MyAppSettings.WebPrefix)
      Dim town As String = Trim(MyAppSettings.WebName)
      Dim suffix As String = Trim(MyAppSettings.WebSuffix)
      Dim script As String = Trim(MyAppSettings.WebScript)

      'Check that QR Codes are active
      If suffix = "" Then
        Return ""
      End If

      ' Default script name if XML doesn't specify one
      If String.IsNullOrWhiteSpace(script) Then
        script = "qr_add.php"
      End If

      ' CASE 1: WebName is already a full URL (starts with http or https)
      ' In this case we ignore prefix/suffix and just append the script.
      If town.StartsWith("http://", StringComparison.OrdinalIgnoreCase) OrElse
           town.StartsWith("https://", StringComparison.OrdinalIgnoreCase) Then

        Return town.TrimEnd("/"c) & "/" & script.TrimStart("/"c)
      End If

      ' Normalize prefix: if not blank and no trailing slash, add one.
      If prefix <> "" AndAlso Not prefix.EndsWith("/") Then
        prefix &= "/"
      End If

      ' Build the town path part (e.g. "southington-webpay")
      Dim townPath As String = town & suffix

      ' If there is no prefix, just return "southington-webpay/qr_add.php"
      If prefix = "" Then
        Return townPath & "/" & script.TrimStart("/"c)
      End If

      ' Normal case: "https://gemsnt.com/" + "southington-webpay" + "/qr_add.php"
      Return prefix & townPath & "/" & script.TrimStart("/"c)
    End Get
  End Property
  Private Function UrlEncode(value As String) As String
    If value Is Nothing Then value = ""
    Return Uri.EscapeDataString(value)
  End Function

  ' Build full finished QR URL with query string
  Public Function BuildQrUrl(acctId As String,
                             productId As String,
                             price As Decimal,
                             txName As String,
                             txType As String,
                             txDesc As String) As String

    Dim sb As New StringBuilder()

    If QrBaseUrl <> "" Then
      sb.Append(QrBaseUrl)
      sb.Append("?action=add")
      sb.Append("&acctID=").Append(UrlEncode(acctId))
      sb.Append("&ProductID=").Append(UrlEncode(productId))
      sb.Append("&price=").Append(UrlEncode(Format(price, "0.00")))
      sb.Append("&txName=").Append(UrlEncode(If(txName, "").Trim()))
      sb.Append("&txType=").Append(UrlEncode(If(txType, "").Trim()))
      sb.Append("&txDesc=").Append(UrlEncode(If(txDesc, "").Trim()))
      Return sb.ToString()
    Else
      Return ""
    End If
  End Function
End Module
