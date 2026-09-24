Module Main
    Public MyFrmUB502 As FrmUB502
    Public MyFrmUB502B As FrmUB502B
    Public MyFrmListCResn As FrmListCResn
		Public MyFrmListDist As FrmListDist
		Public MyFrmListUBType_Tax As FrmListUBType_Tax
    Public MyCrViewer As FrmCrViewer
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmUB502 = New FrmUB502
    Application.Run(MyFrmUB502)
   End Sub
  Public Function GetUTCRESNDesc(ByVal Code As String) As String
     Dim myUTCRESN As UTCRESN.myData

     myUTCRESN = New UTCRESN.mydata(MyDBConnect)
     If IsNothing(Code) Or Code = "" Then
       Return ""
     End If

     myUTCRESN.GetOneRecordP(Code)
     If Not myUTCRESN.RecordNotFound Then
       GetUTCRESNDesc = Trim(myUTCRESN._CRDESC)
     Else
       GetUTCRESNDesc = "*** Unknown ***"
     End If
     Return GetUTCRESNDesc

  End Function
Public Function GetUTTypeDescL2(ByVal Type As String) As String
    Dim myUTTYPE As UTTYPE.MyData

    myUTTYPE = New UTTYPE.MyData(myDBConnect)
    If IsNothing(Type) Or Type = "" Then
			 Return ""
		 End If

		 myUTTYPE.GetOneRecordP(Type)
		 If Not myUTTYPE.RecordNotFound Then
			 GetUTTypeDescL2 = Trim(myUTTYPE._TYDESC)
		 Else
			 GetUTTypeDescL2 = "*** Unknown ***"
		 End If
		 Return GetUTTypeDescL2

	End Function
End Module






