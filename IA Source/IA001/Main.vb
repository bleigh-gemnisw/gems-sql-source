
Module Main
  Public MyPasswordMode As Boolean
  Public MyFrmIA001 As FrmIA001
  Public MyFrmIA001B As FrmIA001B
  Public MyFrmIA001C As FrmIA001C
  Public MyFrmIA001D As FrmIA001D
  Public MyfrmListgroup As FrmListgroup
   Sub Main()
    Dim TestCmd() As String

    StartUp()
    TestCmd = GetCommandLineArgs()
    If UBound(TestCmd) > 1 Then
      If LCase(Trim(TestCmd(2))) = "password" Then
        MyPasswordMode = True
      End If
    End If

    If Not MyPasswordMode Then
      GetSecurity()
    End If

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmIA001 = New FrmIA001
    Application.Run(MyFrmIA001)
   End Sub
End Module
