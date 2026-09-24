Module Main
  Public MyFrmUB212 As FrmUB212
	Public MyFrmUB212B As FrmUB212B
	Public MyFrmListDist As FrmListDist
	Public MyFrmListUBType As FrmListUBType
  Public MyCrViewer As FrmCrViewer
  Public MyEDU1 As Boolean

Sub Main()
  StartUp()
  GetSecurity()  '#sec
  MyEDU1 = GetGNET("EDU1")

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmUB212 = New FrmUB212
	Application.Run(MyFrmUB212)
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
  Public Function GetGNET(ByVal Code As String) As Boolean
     Dim myGNET As GNET.myData

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






