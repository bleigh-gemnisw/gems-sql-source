Module Main
  Public MyFrmTA234 As FrmTA234
	Public MyFrmTA234B As FrmTA234B
	Public MyCrViewer As FrmCrViewer

	Sub Main()
    StartUp()
    GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

		MyFrmTA234 = New FrmTA234
		Application.Run(MyFrmTA234)
	End Sub
  Public Function GetTXTypeDesc(ByVal Code As String) As String
     Dim myTXTYPE As TXTYPE.myData

     myTXTYPE = New TXTYPE.mydata(MyDBConnect)
     If IsNothing(Code) Or Code = "" Then
       Return ""
     End If

     myTXTYPE.GetOneRecordP(Code)
     If Not myTXTYPE.RecordNotFound Then
       GetTXTypeDesc = Trim(myTXTYPE._TYDESC)
     Else
       GetTXTypeDesc = "*** Unknown ***"
     End If
     Return GetTXTypeDesc

  End Function
End Module






