Module Main
    Public MyFrmTO109 As FrmTO109
    Public MyFrmTO109B As FrmTO109B
    Public MyFrmListDist As FrmListDist
    Public MyCrViewer As FrmCrViewer
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTO109 = New FrmTO109
    Application.Run(MyFrmTO109)
   End Sub
  Public Function GetTXTypeDesc(ByVal Code As String) As String
     Dim myTXTYPE As TXTYPE.myData

     myTXTYPE = New TXTYPE.mydata(MyDBConnect)
     If IsNothing(Code) Then
       Return ""
     End If

     GetTXTypeDesc = ""
     myTXTYPE.GetOneRecordP(Code)
     If Not myTXTYPE.IsEOF Then
       GetTXTypeDesc = myTXTYPE._TYDESC
     Else
       GetTXTypeDesc = "*** Unknown ***"
     End If
     Return GetTXTypeDesc

  End Function
	End Module






