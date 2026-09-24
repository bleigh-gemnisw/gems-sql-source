
Module Main
  Public myFrmSelTypes As FrmSelTypes
  Public MyFrmTXE05 As FrmTXE05
  Public MyFrmTXE05B As FrmTXE05B
  Public MyCrViewer As FrmCrViewer
  Public MyTypes As String
  Public MyUBTypes As Boolean
  Sub Main()
    StartUp()
    GetSecurity()
    MyUBTypes = GetGNET("UBTYP")

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTXE05 = New FrmTXE05
    Application.Run(MyFrmTXE05)

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
  Public Function GetGNET(ByVal Code As String) As Boolean
    Dim myGNET As GNET.myData

    myGNET = New GNET.MyData()
    myGNET.MyDBConn = myDBConnect
    If IsNothing(Code) Or Code = "" Then
      Return False
    End If

    myGNET.GetOneRecordP(Code)
    If Not myGNET.RecordNotFound Then
      If myGNET._VALUE = "Y" Then
        GetGNET = True
      End If
    Else
      GetGNET = False
    End If
    myGNET.CloseFile()
    myGNET = Nothing
    Return GetGNET

  End Function

End Module






