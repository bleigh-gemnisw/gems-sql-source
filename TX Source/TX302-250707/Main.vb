'TXINV: Update STCD1: STCD2: STCD3: STCD4: STCD5:
'TXHST: Add
Module Main
  Public MyFrmTX302 As FrmTX302
  Public MyFrmTX302B As FrmTX302B
  Public MyFrmListAltID As FrmListAltID
  Public MyFrmListDist As FrmListDist
  Public MyFrmListSts As FrmListSts
  Public MyFrmSelTypes As FrmSelTypes
  Public MyFrmSelStatus As FrmSelStatus
  Public MyCrViewer As FrmCrViewer
  Public MyTypes As String
  Public MyAltFormID As String
  Public MyCustomDir As String
  Public MyWarrantFee As Decimal
  Public MyStatusHistory As Boolean
  Sub main()
    StartUp()
    GetSecurity()

    MyCustomDir = GetGNETValue("RPTSD")
    If GetGNETValue("STHST") = "Y" Then MyStatusHistory = True
    MyWarrantFee = 6

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX302 = New FrmTX302
    Application.Run(MyFrmTX302)
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
  Public Function GetTXStsDesc(ByVal Code As String) As String
    Dim myTXSTS As TXSTS.MyData

    myTXSTS = New TXSTS.MyData(myDBConnect)
    If IsNothing(Code) Then
      Return ""
    End If

    GetTXStsDesc = ""
    myTXSTS.GetOneRecordP(Code)
    If Not myTXSTS.RecordNotFound Then
      GetTXStsDesc = Trim(myTXSTS._STDESC)
    Else
      GetTXStsDesc = "*** Unknown ***"
    End If
    Return GetTXStsDesc

  End Function
End Module