
Module Main
  Public MyFrmTA131 As FrmTA131
  Public MyFrmTA131B As FrmTA131B
  Public MyFrmListCodes As FrmListCodes

Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTA131 = New FrmTA131
  Application.Run(MyFrmTA131)
  End Sub
  Public Function GetTXCodeDesc(ByVal Code As Integer, ByVal Type As String) As String
    Dim myTXCode As TXCode.myData

    myTXCode = New TXCode.mydata(MyDBConnect)
    If IsNothing(Code) Or Code = 0 Then
      Return ""
    End If

    myTXCode.GetOneRecordP(Code, Type)
    If Not myTXCode.RecordNotFound Then
      GetTXCodeDesc = Trim(myTXCode._TCDESC)
    Else
      GetTXCodeDesc = "*** Unknown ***"
    End If
    Return GetTXCodeDesc

  End Function
End Module






