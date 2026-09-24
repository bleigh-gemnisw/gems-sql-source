
Module Main
  Public MyFrmTO220 As FrmTO220
  Public MyFrmTO220B As FrmTO220B
  Public MyFrmTO220C As FrmTO220C
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

    MyFrmTO220 = New FrmTO220
    Application.Run(MyFrmTO220)
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

