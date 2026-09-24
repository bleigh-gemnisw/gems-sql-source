'TXINV: Update STCD1, STCD2, STCD3, STCD4, STCD5
'TXHST: Add
Module Main
  Public MyCrViewer As FrmCrViewer
  Public MyFrmTXA31 As FrmTXA31
  Public MyFrmTXA31B As FrmTXA31B
  Public MyFrmListSts As FrmListSts
  Public MyFrmListTypes As FrmListTypes
  Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTXA31 = New FrmTXA31
    Application.Run(MyFrmTXA31)
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






