
Module Main
  Public myFrmSelTypes As FrmSelTypes
  Public MyFrmTXE56 As FrmTXE56
  Public MyFrmTXE56B As FrmTXE56B
  Public MyCrViewer As FrmCrViewer
  Public MyTypes As String
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTXE56 = New FrmTXE56
    Application.Run(MyFrmTXE56)

   End Sub
  Public Function GetTXTypeDesc(ByVal Code As String) As String
     Dim MyTXTYPE As TXTYPE.myData

     MyTXTYPE = New TXTYPE.mydata(MyDBConnect)
     If IsNothing(Code) Or Code = "" Then
       Return ""
     End If

     MyTXTYPE.GetOneRecordP(Code)
     If Not MyTXTYPE.RecordNotFound Then
       GetTXTypeDesc = Trim(MyTXTYPE._TYDESC)
     Else
       GetTXTypeDesc = "*** Unknown ***"
     End If
     Return GetTXTypeDesc

  End Function
  Public Function GetTXTypeFamily(ByVal Code As String) As String
    Dim mytxtype As TXTYPE.MyData

    mytxtype = New TXTYPE.MyData(myDBConnect)
    If IsNothing(Code) Then
      Return ""
    End If

    GetTXTypeFamily = ""
    mytxtype.GetOneRecordP(Code)
    If Not mytxtype.RecordNotFound Then
      GetTXTypeFamily = Trim(mytxtype._TXFAM)
    Else
      GetTXTypeFamily = ""
    End If
    Return GetTXTypeFamily

  End Function

End Module






