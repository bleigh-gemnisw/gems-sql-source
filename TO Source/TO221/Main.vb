
Module Main
  Public MyFrmTO221 As FrmTO221
  Public MyFrmTO221B As FrmTO221B
  Public MyFrmTO221C As FrmTO221C
  Public MyFrmListRealC As FrmListRealC
  Public MyCrViewer As FrmCrViewer
  Public MyM35HIncome As Boolean
  Sub Main()
    StartUp()
    GetSecurity()
    If GetGNET("M59IN") = "Y" Then MyM35HIncome = True

#If Not DEBUG Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTO221 = New FrmTO221
    Application.Run(MyFrmTO221)
   End Sub
Private Function GetGNET(ByVal Key As String) As String
  Dim myGNET As GNET.myData

  myGNET = New GNET.MyData()
    myGNET.MyDBConn = myDBConnect
  myGNET.GetOneRecordP(Key)
  With myGNET
    If .RecordNotFound Then Return String.Empty
    Return ._VALUE
  End With

End Function
End Module


