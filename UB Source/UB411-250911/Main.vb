Module Main
    Public MyFrmUB411 As FrmUB411
    Public MyFrmUB411B As FrmUB411B
    Public MyFrmListDist As FrmListDist
    Public MyFrmListUBType As FrmListUBType
    Public MyCrViewer As FrmCrViewer
    Public MyPrtLayout As FrmPrtLayout
    Public MyTypes As String
    Public MyEDU1 As Boolean
    Public MyUBBNK As Boolean
   Sub Main()
    StartUp()
    GetSecurity()
    MyEDU1 = GetGNET("EDU1")
    MyUBBNK = GetGNET("UBBNK")

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmUB411 = New FrmUB411
    Application.Run(MyFrmUB411)
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
Public Function GetTypeNo(ByVal Type As String) As Integer
   '5 FOR TRASH
   '6 FOR SEWER METERED 
	 '7 FOR WATER METERED
	 '8 FOR WATER USAGE
	 '9 FOR SEWER USAGE 
Select Case Type
  Case "T"
    Return 5
  Case "C"
    Return 6
	Case "D"
		Return 7
	Case "W"
		Return 8
	Case "U"
		Return 9
	Case Else
		Return 0
	End Select
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






