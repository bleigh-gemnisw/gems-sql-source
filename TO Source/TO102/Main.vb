Module Main
  Public MyFrmTO102 As FrmTO102
  Public MyFrmTO102B As FrmTO102B
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

    MyFrmTO102 = New FrmTO102
    Application.Run(MyFrmTO102)
  End Sub
  Public Function GetTXXPROPDesc(ByVal Code As String) As String
    Dim myTXXPROP As TXXPROP.MyData

    myTXXPROP = New TXXPROP.MyData(myDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myTXXPROP.GetOneRecordP(Code)
    If Not myTXXPROP.RecordNotFound Then
      GetTXXPROPDesc = Trim(myTXXPROP._TXDESC)
    Else
      GetTXXPROPDesc = "*** Unknown ***"
    End If
    Return GetTXXPROPDesc

  End Function
  Private Function GetGNET(ByVal Key As String) As String
    Dim myGNET As GNET.MyData

    myGNET = New GNET.MyData()
    myGNET.MyDBConn = myDBConnect
    myGNET.GetOneRecordP(Key)
    With myGNET
      If .RecordNotFound Then Return String.Empty
      Return ._VALUE
    End With

  End Function
End Module






