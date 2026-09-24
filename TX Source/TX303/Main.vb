Module Main
    Public MyFrmTX303 As FrmTX303
    Public MyFrmTX303B As FrmTX303B
    Public MyFrmListTypes As FrmListTypes
		Public MyFrmSelStatus As FrmSelStatus
		Public MyCrViewer As FrmCrViewer
    Public MyPrtLayout As FrmPrtLayout
    Public MyTypes As String
		Public MySts As String
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX303 = New FrmTX303
    Application.Run(MyFrmTX303)
   End Sub
  Public Function GetTXTypeDesc(ByVal Code As String) As String
     Dim myTXTYPE As TXTYPE.myData

     myTXTYPE = New TXTYPE.mydata(MyDBConnect)
     If IsNothing(Code) Then
       Return ""
     End If

     GetTXTypeDesc = ""
     myTXTYPE.GetOneRecordP(Code)
     If Not myTXTYPE.RecordNotFound Then
       GetTXTypeDesc = Trim(myTXTYPE._TYDESC)
     Else
       GetTXTypeDesc = "*** Unknown ***"
     End If
     Return GetTXTypeDesc

  End Function
  Public Function GetTXTypeFamily(ByVal Code As String) As String
     Dim myTXTYPE As TXTYPE.myData

     myTXTYPE = New TXTYPE.mydata(MyDBConnect)
     If IsNothing(Code) Then
       Return ""
     End If

     GetTXTypeFamily = ""
     myTXTYPE.GetOneRecordP(Code)
     If Not myTXTYPE.RecordNotFound Then
       GetTXTypeFamily = Trim(myTXTYPE._TXFAM)
     Else
       GetTXTypeFamily = ""
     End If
     Return GetTXTypeFamily
  End Function

End Module






