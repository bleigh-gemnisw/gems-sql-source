'TXINV: Update LIEN:
'TXHST: Add
Module Main
  Public MyFrmTX304 As FrmTX304
  Public MyFrmTX304B As FrmTX304B
  Public MyFrmListAltID As FrmListAltID
  Public MyFrmSelTypes As FrmSelTypes
  Public MyFrmSelStatus As FrmSelStatus
  Public MyCrViewer As FrmCrViewer
  Public MyTypes As String
  Public MyAltFormID As String
  Public MyCustomDir As String
  Sub main()
    StartUp()
    GetSecurity()
    MyCustomDir = GetGNETValue("RPTSD")

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX304 = New FrmTX304
    Application.Run(MyFrmTX304)
  End Sub
  Public Function GetTXTypeDesc(ByVal Code As String) As String
    Dim myTXTYPE As TXTYPE.MyData

    myTXTYPE = New TXTYPE.MyData(myDBConnect)
    If IsNothing(Code) Then
      Return ""
    End If

    GetTXTypeDesc = ""
    myTXTYPE.GetOneRecordP(Code)
    If Not myTXTYPE.IsEOF Then
      GetTXTypeDesc = myTXTYPE._TYDESC
    Else
      GetTXTypeDesc = "*** Unknown ***"
    End If
    Return GetTXTypeDesc

  End Function
  Public Function GetTXTypeFamily(ByVal Code As String) As String
    Dim myTXTYPE As TXTYPE.MyData

    myTXTYPE = New TXTYPE.MyData(myDBConnect)
    If IsNothing(Code) Then
      Return ""
    End If

    GetTXTypeFamily = ""
    myTXTYPE.GetOneRecordP(Code)
    If Not myTXTYPE.IsEOF Then
      GetTXTypeFamily = myTXTYPE._TXFAM
    Else
      GetTXTypeFamily = ""
    End If
    Return GetTXTypeFamily

  End Function
  Public Function GetGNETValue(ByVal Code As String) As String
    Dim myGNET As GNET.MyData

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






