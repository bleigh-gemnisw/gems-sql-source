Imports System.IO
Imports System.Net
Module WebScript
  Dim instance As WebRequest
  Public Function RunScript(ByVal WrkSite As String) As String
    Dim WrkURL As String
    Dim WrkMsg As String
    Dim Pos As Integer
    ' Create a request for the URL. 		 
    'ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12 _
    '  Or SecurityProtocolType.Tls13
    If MyAutomate Or MyFTPOnly Then
      WrkURL = "https://gemsnt.com/" & MyAppSettings.WebName & "-" & WrkSite & "/vars/importer.php"
    Else
      WrkURL = "https://gemsnt.com/" & MyAppSettings2.WebName & "-" & WrkSite & "/vars/importer.php"
    End If
    Dim request As WebRequest = WebRequest.Create(WrkURL)
    ' If required by the server, set the credentials.
    request.Credentials = CredentialCache.DefaultCredentials
    ' Get the response. 
    Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
    ' Get the stream containing content returned by the server. 
    Dim dataStream As Stream = response.GetResponseStream()
    ' Open the stream using a StreamReader for easy access. 
    Dim reader As New StreamReader(dataStream)
    ' Read the content. 
    Dim responseFromServer As String = reader.ReadToEnd()
    ' Cleanup the streams and the response.
    WrkMsg = response.StatusDescription & vbCrLf & responseFromServer
    Pos = InStr(WrkMsg, "Message successfully sent!")
    If Pos Then
      WrkMsg = WrkMsg & vbCrLf & "Import completed"
    Else
      WrkMsg = WrkMsg & vbCrLf & "Import failed"
    End If
    reader.Close()
    dataStream.Close()
    response.Close()
    Return WrkMsg
  End Function
End Module






