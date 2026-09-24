
Module Main
  Public MyFrmTA506 As FrmTA506
  Public MyFrmTA506B As FrmTA506B
	Public MyFrmListCodes As FrmListCodes
  Public MyCrViewer As FrmCrViewer
  Public MyBookPct As Decimal
  Public MyMinValue As Integer
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA506 = New FrmTA506
    Application.Run(MyFrmTA506)

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






