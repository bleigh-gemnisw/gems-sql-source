Module Main
    Public MyFrmUB402 As FrmUB402
    Public MyFrmUB402B As FrmUB402B
    Public MyFrmListUBType_Tax As FrmListUBType_Tax
    Public MyCrViewer As FrmCrViewer
   Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmUB402 = New FrmUB402
    Application.Run(MyFrmUB402)
   End Sub
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
	Public Function GetUTTypeUBType(ByVal TaxType As String) As String
    Dim myUTTYPE As UTTYPE.myData

    myUTTYPE = New UTTYPE.mydata(myDBConnect)
    If IsNothing(TaxType) Or TaxType = "" Then
			 Return ""
		 End If

		 myUTTYPE.GetOneRecordP(TaxType)
		 If Not myUTTYPE.RecordNotFound Then
			 GetUTTypeUBType = Trim(myUTTYPE._TYUTTP)
		 Else
			 GetUTTypeUBType = "*** Unknown ***"
		 End If
		 Return GetUTTypeUBType

	End Function


End Module






