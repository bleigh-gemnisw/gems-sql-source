
Module Main
  Public MyFrmTA231 As FrmTA231
  Public MyFrmTA231B As FrmTA231B
	Public MyCrViewer As FrmCrViewer
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

		MyFrmTA231 = New FrmTA231
		Application.Run(MyFrmTA231)

	 End Sub
Public Function GetTXCDAGCode(ByVal Seq As Integer) As Integer
     Dim myTXCDAG As TXCDAG.myData

     myTXCDAG = New TXCDAG.mydata(MyDBConnect)
     If Seq = 0 Then
       Return 0
     End If

     myTXCDAG.GetOneRecordP(Seq)
     If Not myTXCDAG.RecordNotFound Then
       GetTXCDAGCode = myTXCDAG._TCCODE
     Else
       GetTXCDAGCode = 0
     End If
     Return GetTXCDAGCode

  End Function
End Module






