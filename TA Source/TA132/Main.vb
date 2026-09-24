
Module Main
  Public MyFrmTA132 As FrmTA132
  Public MyFrmTA132B As FrmTA132B
  Public MyFrmListCodes As FrmListCodes

Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTA132 = New FrmTA132
  Application.Run(MyFrmTA132)
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






