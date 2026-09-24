'TXINV: Add
Module Main
  Public MyFrmTX301 As FrmTX301
  Public MyFrmTX301B As FrmTX301B
  Public MyFrmListBanks As FrmListBanks
  Public MyCrViewer As FrmCrViewer
  Public MyPrtLayout As FrmPrtLayout
  Public MyTypes As String
  Public MyBTCode As String
  Public MyCustomDir As String
  Public MyProRateRound As Boolean
  Sub Main()
    StartUp()
    s_full = True
    If GetGNETValue("BILBT") = "Y" Then
      MyBTCode = " B"
    Else
      MyBTCode = "BT"
    End If
    If GetGNETValue("CCRND") = "Y" Then
      MyProRateRound = True
    Else
      MyProRateRound = False
    End If

    MyCustomDir = GetGNETValue("RPTSD")

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX301 = New FrmTX301
    Application.Run(MyFrmTX301)
  End Sub
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
  Public Function GetTXSupCd(ByVal Code As String) As String()
    Dim Wrkstr(1) As String
    Dim myTXSUPCD As TXSUPCD.MyData

    myTXSUPCD = New TXSUPCD.MyData(myDBConnect)
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
  Public Function GetTXTypeDesc(ByVal Code As String) As String
    Dim myTXTYPE As TXTYPE.MyData

    myTXTYPE = New TXTYPE.MyData(myDBConnect)
    If IsNothing(Code) Then
      Return ""
    End If

    GetTXTypeDesc = ""
    myTXTYPE.GetOneRecordP(Code)
    If Not myTXTYPE.IsEOF Then
      GetTXTypeDesc = Trim(myTXTYPE._TYDESC)
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

End Module
