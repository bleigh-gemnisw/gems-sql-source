Module Main
    Public MyFrmTX702 As FrmTX702
    Public MyFrmTX702B As FrmTX702B
    Public MyCrViewer As FrmCrViewer
    Public MyFrmListCCReason As FrmListCCReason
    Public MyFrmListTypes As FrmListTypes
    Public MyCustomDir As String
   Sub Main()
    StartUp()
    GetSecurity()
    MyCustomDir = GetGNETValue("RPTSD")

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX702 = New FrmTX702
    Application.Run(MyFrmTX702)
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
		 If Not myTXTYPE.IsEOF Then
			 GetTXTypeFamily = myTXTYPE._TXFAM
		 Else
			 GetTXTypeFamily = ""
		 End If
		 Return GetTXTypeFamily

	End Function
	Public Function GetGNETValue(ByVal Code As String) As String
		 Dim myGNET As GNET.myData

		 myGNET = New GNET.MyData()
    myGNET.MyDBConn = myDBConnect
		 If IsNothing(Code) Or Code = "" Then
			 Return String.Empty
		 End If

		 GetGNETValue = String.Empty
		 myGNET.GetOneRecordP(Code)
		 If Not myGNET.RecordNotFound Then
			 GetGNETValue = myGNET._VALUE
		 End If
		 Return GetGNETValue

	End Function
End Module






