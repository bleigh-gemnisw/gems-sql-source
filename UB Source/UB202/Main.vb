Module Main
  Public MyFrmUB202 As FrmUB202
	Public MyFrmUB202B As FrmUB202B
	Public MyFrmListDist As FrmListDist
  Public MyFrmListRates As FrmListRates
  Public MyFrmListUBType As FrmListUBType
	Public MyCrViewer As FrmCrViewer

Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmUB202 = New FrmUB202
	Application.Run(MyFrmUB202)
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
End Module






