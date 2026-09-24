Module Main
  Public MyFrmUB213 As FrmUB213
	Public MyFrmUB213B As FrmUB213B
	Public MyFrmListDist As FrmListDist
  Public MyFrmListMResn As FrmListMResn
  Public MyFrmListMeterSize As FrmListMeterSize
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

	MyFrmUB213 = New FrmUB213
	Application.Run(MyFrmUB213)
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
  Public Function GetUTMRESNDesc(ByVal Code As String) As String
     Dim myUTMRESN As UTMRESN.myData

     myUTMRESN = New UTMRESN.mydata(MyDBConnect)
     If IsNothing(Code) Or Code = "" Then
       Return ""
     End If

     myUTMRESN.GetOneRecordP(Code)
     If Not myUTMRESN.RecordNotFound Then
       GetUTMRESNDesc = Trim(myUTMRESN._MRDESC)
     Else
       GetUTMRESNDesc = "*** Unknown ***"
     End If
     Return GetUTMRESNDesc

  End Function
End Module






