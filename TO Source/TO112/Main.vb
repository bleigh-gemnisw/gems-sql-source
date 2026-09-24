
Module Main
  Public MyFrmTO112 As FrmTO112
  Public MyFrmTO112B As FrmTO112B
  Public MyFrmListCodes As FrmListCodes
  Public MyFrmListDist As FrmListDist
  Public MyCrViewer As FrmCrViewer
  Public MyReportCancel As Boolean
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTO112 = New FrmTO112
    Application.Run(MyFrmTO112)

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






