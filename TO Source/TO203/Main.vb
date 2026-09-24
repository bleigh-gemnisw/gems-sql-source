Module Main
  Public MyFrmCrViewer As FrmCrViewer
	Public MyFrmTO203 As FrmTO203
	Public MyFrmTO203B As FrmTO203B
	Public MyFrmTO203C As FrmTO203C
	Public MyFrmListExemption As FrmListExemption
	Public MyFrmListLocalCodes As FrmListLocalCodes

Sub Main()
  StartUp()
  GetSecurity()  '#sec
	
#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmTO203 = New FrmTO203
	Application.Run(MyFrmTO203)
End Sub
Public Function GetCategory(ByVal Cat As String) As String
  Dim Category As String

  Category = ""
  Select Case Cat
  Case "B"
    Category = "Blind"
  Case "D"
    Category = "Disabled"
  Case "V"
    Category = "Veterans"
  Case "L"
    Category = "Local Option"
  Case "A"
    Category = "Addl Vets"
  End Select

  Return Category
End Function
	Public Function GetTXExem(ByVal Code As String) As String()
		Dim Wrkstr(1) As String
		Dim myTXExem As TXEXEM.myData

		myTXExem = New TXEXEM.mydata(MyDBConnect)
		If IsNothing(Code) Or Code = "" Then
			Wrkstr(0) = ""
			Wrkstr(1) = ""
			Return Wrkstr
		End If

    myTXExem.GetOneRecordP(Code)
		If Not myTXExem.RecordNotFound Then
      Wrkstr(0) = myTXExem._TFIXAM
      Wrkstr(1) = myTXExem._TDESC
		Else
			Wrkstr(1) = "*** Unknown ***"
		End If
		Return Wrkstr

	End Function

End Module






