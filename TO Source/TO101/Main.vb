Module Main
  Public MyFrmTO101 As FrmTO101
  Public MyFrmTO101B As FrmTO101B
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

    MyFrmTO101 = New FrmTO101
    Application.Run(MyFrmTO101)
  End Sub
  Public Function GetTXCodeDesc(ByVal Code As Integer, ByVal Type As String) As String
    Dim myTXCODE As TXCODE.MyData

    myTXCODE = New TXCODE.MyData(myDBConnect)
    If IsNothing(Code) Or Code = 0 Then
      Return ""
    End If

    myTXCODE.GetOneRecordP(Code, Type)
    If Not myTXCODE.RecordNotFound Then
      GetTXCodeDesc = Trim(myTXCODE._TCDESC)
    Else
      GetTXCodeDesc = "*** Unknown ***"
    End If
    Return GetTXCodeDesc

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






