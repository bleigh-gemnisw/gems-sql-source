Module Main
  Public MyFrmTA102 As FrmTA102
  Public MyFrmTA102B As FrmTA102B
  Public MyFrmTA102C As FrmTA102C
  Public MyCrViewer As FrmCrViewer
  Public MyLocEldDarien As Boolean
Sub Main()
  StartUp()
  GetSecurity()  '#sec
  If GetGNET("LEDAR") = "Y" Then MyLocEldDarien = True

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If


  MyFrmTA102 = New FrmTA102
  Application.Run(MyFrmTA102)

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






