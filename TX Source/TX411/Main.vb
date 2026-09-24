Module Main
  Public MyFrmTX411 As FrmTX411
	Public MyFrmTX411B As FrmTX411B
  Public My2NDNO As Boolean

Sub Main()
  StartUp()
  GetSecurity()  '#sec
  My2NDNO = False
  If GetGNETValue("2NDNO") = "Y" Then
    My2NDNO = True
  End If

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmTX411 = New FrmTX411
	Application.Run(MyFrmTX411)
End Sub
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






