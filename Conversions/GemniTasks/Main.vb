Module Main

  Public MyFrmGemniTask As FrmGemniTask
  Public MyFrmGemniTaskB As FrmGemniTaskB
  Public MyServer As String
  Sub Main()
    StartUp()
    'GetSecurity()

#If Not DEBUG Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmGemniTask = New FrmGemniTask
  Application.Run(MyFrmGemniTask)
End Sub
End Module
