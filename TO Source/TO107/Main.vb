Module Main
    Public MyFrmTO107 As FrmTO107
    Public MyFrmTO107B As FrmTO107B
    Public MyFrmListDist As FrmListDist
    Public MyCrViewer As FrmCrViewer
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTO107 = New FrmTO107
    Application.Run(MyFrmTO107)
   End Sub
  Public Function GetTXXPROPDesc(ByVal Code As String) As String
     Dim myTXXPROP As TXXprop.myData

     myTXXPROP = New TXXprop.mydata(MyDBConnect)
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
  End Module






