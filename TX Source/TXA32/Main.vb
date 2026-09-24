'TAXCOM: Update STCD1, STCD2, STCD3, STCD4, STCD5
'TXHST: Add
Module Main
  Public MyCrViewer As FrmCrViewer
  Public MyFrmTXA32 As FrmTXA32
  Public MyFrmTXA32B As FrmTXA32B
  Public MyFrmListTypes As FrmListTypes
  Sub Main()
    StartUp()
    GetSecurity()

#If Not DEBUG Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTXA32 = New FrmTXA32
    Application.Run(MyFrmTXA32)
  End Sub
  Public Function GetTXTypeDesc(ByVal Code As String) As String
    Dim myTXTYPE As TXTYPE.myData

    myTXTYPE = New TXTYPE.mydata(MyDBConnect)
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
End Module






