Module Main
  Public MyFrmUB207 As FrmUB207
	Public MyFrmUB207B As FrmUB207B
	Public MyFrmListDist As FrmListDist
	Public MyFrmListUBType As FrmListUBType
	Public MyCrViewer As FrmCrViewer

Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmUB207 = New FrmUB207
	Application.Run(MyFrmUB207)
End Sub
Public Function GetUTDistDesc(ByVal Dist As Integer, ByVal Phase As Integer) As String
     Dim myUTDIST As UTDIST.myData

     myUTDIST = New UTDIST.mydata(MyDBConnect)
     If IsNothing(Dist) Or Dist = 0 Or IsNothing(Phase) Then
       Return ""
     End If

     myUTDIST.GetOneRecordP(Dist, Phase)
     If Not myUTDIST.RecordNotFound Then
       GetUTDistDesc = Trim(myUTDIST._DIDESC)
     Else
       GetUTDistDesc = ""
     End If
     Return GetUTDistDesc

  End Function
End Module






