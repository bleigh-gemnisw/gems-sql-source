Module Main
  Public MyFrmUB203 As FrmUB203
	Public MyFrmUB203B As FrmUB203B
	Public MyFrmListDist As FrmListDist
	Public MyFrmListUBType As FrmListUBType
  Public MyCrViewer As FrmCrViewer
  Public MyEDU1 As Boolean

Sub Main()
  StartUp()
  GetSecurity()  '#sec
	GetTown()
  MyEDU1 = GetGNET("EDU1")

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmUB203 = New FrmUB203
	Application.Run(MyFrmUB203)
End Sub
Public Function GetUTTypeDesc(ByVal Code As String) As String
     Dim myUTTYPE As UTTYPE.myData

     myUTTYPE = New UTTYPE.mydata(MyDBConnect)
     If IsNothing(Code) Or Code = "" Then
       Return ""
     End If

     myUTTYPE.GetOneRecordP(Code)
     If Not myUTTYPE.RecordNotFound Then
       GetUTTypeDesc = myUTTYPE._TYDESC
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
			 GetUTTYPEFamily = myUTTYPE._TYUTTP
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
			 GetUTTYPETaxType = myUTTYPE._TYTXTP
		 Else
			 GetUTTYPETaxType = ""
		 End If
		 Return GetUTTYPETaxType

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






