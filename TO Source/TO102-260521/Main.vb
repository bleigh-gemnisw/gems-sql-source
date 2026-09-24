Module Main
    Public MyFrmTO102 As FrmTO102
    Public MyFrmTO102B As FrmTO102B
    Public MyFrmListDist As FrmListDist
    Public MyCrViewer As FrmCrViewer
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTO102 = New FrmTO102
    Application.Run(MyFrmTO102)
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






