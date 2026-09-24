Module Main
    Public MyFrmTA235 As FrmTA235
    Public MyFrmTA235B As FrmTA235B
    Public MyFrmListDist As FrmListDist
    Public MyCrViewer As FrmCrViewer
    Public MyPhaseIn As Boolean
Sub main()
    StartUp()
    GetSecurity()
    If GetGNET("PHASE") = "Y" Then MyPhaseIn = True

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA235 = New FrmTA235
    Application.Run(MyFrmTA235)
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






