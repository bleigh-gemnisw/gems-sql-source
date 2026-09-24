Module Main
    Public MyFrmTX505 As FrmTX505
    Public MyFrmTX505B As FrmTX505B
    Public MyCrViewer As FrmCrViewer
    Public MyFrmListBanks As FrmListBanks
    Public MyFrmListBser As FrmListBser
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX505 = New FrmTX505
    Application.Run(MyFrmTX505)
   End Sub
  Public Function GetTXBanksDesc(ByVal Code As String) As String
     Dim myTXBANKS As TXBANKS.myData

     myTXBANKS = New TXBANKS.mydata(MyDBConnect)
     If IsNothing(Code) Or Code = "" Then
       Return ""
     End If

     GetTXBanksDesc = ""
     myTXBANKS.GetOneRecordP(Code)
     If Not myTXBANKS.RecordNotFound Then
       GetTXBanksDesc = Trim(myTXBANKS._BKNAME)
     Else
       GetTXBanksDesc = "*** Unknown ***"
     End If
     Return GetTXBanksDesc

  End Function
  Public Function GetTXBanksServ(ByVal Code As String) As String
     Dim myTXBSER As TXBSER.myData

     myTXBSER = New TXBSER.mydata(MyDBConnect)
     If IsNothing(Code) Or Code = "" Then
       Return ""
     End If

     GetTXBanksServ = ""
     myTXBSER.GetOneRecordP(Code)
     If Not myTXBSER.RecordNotFound Then
       GetTXBanksServ = Trim(myTXBSER._BSNAME)
     Else
       GetTXBanksServ = "*** Unknown ***"
     End If
     Return GetTXBanksServ

  End Function
End Module






