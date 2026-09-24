
Module Main
  Public MyFrmTXE08 As FrmTXE08
  Public MyFrmTXE08B As FrmTXE08B
  Public MyFrmListDist As FrmListDist
  Public myFrmSelTypes As FrmSelTypes
  Public MyCrViewer As FrmCrViewer
  Public MyTypes As String
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTXE08 = New FrmTXE08
    Application.Run(MyFrmTXE08)

   End Sub
  Public Function GetTXTypeFamily(ByVal Code As String) As String
    Dim MyTXTYPE As TXTYPE.MyData

    MyTXTYPE = New TXTYPE.MyData(myDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    MyTXTYPE.GetOneRecordP(Code)
    If Not MyTXTYPE.RecordNotFound Then
      GetTXTypeFamily = MyTXTYPE._TXFAM
    Else
      GetTXTypeFamily = ""
    End If
    MyTXTYPE.CloseFile() 'asna added
    Return GetTXTypeFamily

  End Function
End Module
