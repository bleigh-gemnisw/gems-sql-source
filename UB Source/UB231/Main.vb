Module Main
    Public MyFrmUB231 As FrmUB231
    Public MyFrmUB231B As FrmUB231B
    Public MyFrmListDist As FrmListDist
    Public MyFrmListUBType As FrmListUBType
    Public MyCrViewer As FrmCrViewer
    Public MyTypes As String
    Public DataPath As String
   Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmUB231 = New FrmUB231
    Application.Run(MyFrmUB231)
   End Sub
  Public Function GetUTTypeDesc(ByVal Code As String) As String
     Dim myUTTYPE As UTTYPE.myData

     myUTTYPE = New UTTYPE.mydata(MyDBConnect)
     If IsNothing(Code) Or Code = "" Then
       Return ""
     End If

     myUTTYPE.GetOneRecordP(Code)
     If Not myUTTYPE.RecordNotFound Then
       GetUTTypeDesc = Trim(myUTTYPE._TYDESC)
     Else
       GetUTTypeDesc = "*** Unknown ***"
     End If
     Return GetUTTypeDesc

  End Function
	Public Function GetUTTYPEFamily(ByVal Code As String) As String
		 Dim myUTTYPE As UTTYPE.myData

		 myUTTYPE = New UTTYPE.mydata(MyDBConnect)
		 If IsNothing(Code) Or Code = "" Then
			 Return ""
		 End If

		 myUTTYPE.GetOneRecordP(Code)
		 If Not myUTTYPE.RecordNotFound Then
			 GetUTTYPEFamily = Trim(myUTTYPE._TYUTTP)
		 Else
			 GetUTTYPEFamily = ""
		 End If
		 Return GetUTTYPEFamily

	End Function
		Public Function GetUTTYPETaxType(ByVal Code As String) As String
		 Dim myUTTYPE As UTTYPE.myData

		 myUTTYPE = New UTTYPE.mydata(MyDBConnect)
		 If IsNothing(Code) Or Code = "" Then
			 Return ""
		 End If

		 myUTTYPE.GetOneRecordP(Code)
		 If Not myUTTYPE.RecordNotFound Then
			 GetUTTYPETaxType = Trim(myUTTYPE._TYTXTP)
		 Else
			 GetUTTYPETaxType = ""
		 End If
		 Return GetUTTYPETaxType

	End Function
End Module






