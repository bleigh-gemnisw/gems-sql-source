
Module Main
  Public MyFrmTA236 As FrmTA236
  Public MyFrmTA236B As FrmTA236B
  Public MyFrmListLocalCodes As FrmListLocalCodes
  Public MyCrViewer As FrmCrViewer
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA236 = New FrmTA236
    Application.Run(MyFrmTA236)

   End Sub
  Public Function GetTXLocCdDesc(ByVal Code As String) As String
    Dim myTXLOCCD As TXLOCCD.myData

    myTXLOCCD = New TXLOCCD.mydata(MyDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myTXLOCCD.GetOneRecordP(Code)
    If Not myTXLOCCD.RecordNotFound Then
      GetTXLocCdDesc = Trim(myTXLOCCD._BNDSC)
    Else
      GetTXLocCdDesc = "*** Unknown ***"
    End If
    Return GetTXLocCdDesc

  End Function
End Module






