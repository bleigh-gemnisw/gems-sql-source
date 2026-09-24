Module Main
  Public MyFrmUB305 As FrmUB305
  Public MyFrmUB305B As FrmUB305B
  Public MyCrViewer As FrmCrViewer
  Public MyFrmListDist As FrmListDist
  Public MyFrmListUBType As FrmListUBType
  Public MyDials As Boolean
  Sub Main()
    StartUp()
    GetSecurity()
    MyDials = GetGNET("DIALS")

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmUB305 = New FrmUB305
    Application.Run(MyFrmUB305)
  End Sub
  Public Function GetGNET(ByVal Code As String) As Boolean
    Dim myGNET As GNET.MyData

    myGNET = New GNET.MyData()
    myGNET.MyDBConn = myDBConnect
    If IsNothing(Code) Or Code = "" Then
      Return False
    End If

    myGNET.GetOneRecordP(Code)
    If Not myGNET.RecordNotFound Then
      If myGNET._VALUE = "Y" Then
        GetGNET = True
      End If
    Else
      GetGNET = False
    End If
    myGNET.CloseFile()
    myGNET = Nothing
    Return GetGNET

  End Function
End Module






