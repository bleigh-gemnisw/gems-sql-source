
Module Main
  Public MyFrmTA523 As FrmTA523
  Public MyFrmTA523B As FrmTA523B
  Public MyCrViewer As FrmCrViewer
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA523 = New FrmTA523
    Application.Run(MyFrmTA523)

   End Sub
  Public Function GetTXSupCd(ByVal Code As String) As String()
    Dim Wrkstr(1) As String
    Dim myTXSUPCD As TXSUPCD.myData

    myTXSUPCD = New TXSUPCD.mydata(MyDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Wrkstr(0) = ""
      Wrkstr(1) = ""
      Return Wrkstr
    End If

    myTXSUPCD.GetOneRecordP(Code)
    If Not myTXSUPCD.RecordNotFound Then
      Wrkstr(0) = Format(myTXSUPCD._SPCT, ".###")
      Wrkstr(1) = Trim(myTXSUPCD._SMON)
    Else
      Wrkstr(1) = "*** Unknown ***"
    End If
    Return Wrkstr

  End Function
End Module






