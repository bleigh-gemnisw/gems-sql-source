Imports System.Text
Module Main
  'To automate, use /auto in place of userid
  'To ftp, use /ftp in place of userid
 Public MyFrmTXE48 As FrmTXE48
 Public MyFrmTXE48B As FrmTXE48B
 Public MyAutomate As Boolean
 Public MyFTP As Boolean
 Public MyAppSettings As AppSettings

Sub Main()
 StartUp()
 Select Case UCase(MyUserID)
 Case "/AUTO"
  MyAutomate = True
 Case "/FTP"
  MyFTP = True
 Case Else
  GetSecurity() '#sec
 End Select
 GetAppSettings()

#If Not Debug Then
  AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
  AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

 MyFrmTXE48 = New FrmTXE48
 Application.Run(MyFrmTXE48)
 Exit Sub

 End Sub
  Public Sub GetAppSettings()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sr As IO.StreamReader
    Dim WrkXMLPath As String
    Dim WrkProgName As String

    WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
    WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & ".xml"
    If MyUtils.CheckFileExists(WrkXMLPath) Then
      sr = New IO.StreamReader(WrkXMLPath)
      MyAppSettings = New AppSettings
      MyAppSettings = CType(xs.Deserialize(sr), AppSettings)
      sr.Close()
    Else
      MyAppSettings = New AppSettings
    End If
  End Sub
Public Sub SaveAppSettings()
  Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
  Dim sw As IO.StreamWriter
  Dim WrkProgName As String
  Dim WrkXMLPath As String

  WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
  WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & ".xml"
  sw = New IO.StreamWriter(WrkXMLPath)
  xs.Serialize(sw, MyAppSettings)
  sw.Close()
End Sub
Public Function GetPassword(ByVal Phrase As String) As String
  Dim Sb As StringBuilder
  Dim WrkNumber As Integer
  Dim I As Integer
  Dim J As Integer

  Sb = New StringBuilder
  For I = 1 To Len(Phrase)
    J = (I * 3) - 2
    WrkNumber = MyUtils.CnvSng(Mid(Phrase, J, 3))
    Select Case (I Mod 3)
    Case 1
      WrkNumber = WrkNumber - 7
    Case 2
      WrkNumber = WrkNumber - 3
    Case 0
      WrkNumber = WrkNumber - 1
    End Select
    If WrkNumber > 0 Then
      Sb.Append(Chr(WrkNumber))
    End If
  Next I

  Return Sb.ToString

End Function
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
End Module






