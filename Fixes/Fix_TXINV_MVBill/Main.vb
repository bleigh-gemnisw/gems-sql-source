Module Main
  Public MyFrmFix As FrmFix
  Public MyFrmFixB As FrmFixB
  Public MyFrmListTypes As FrmListTypes
  Public MyMVFee As Decimal
  Sub Main()
    StartUp()

#If Not DEBUG Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmFix = New FrmFix
    Application.Run(MyFrmFix)
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
End Module






