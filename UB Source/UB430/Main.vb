Module Main
    Public MyFrmUB430 As FrmUB430
    Public MyFrmUB430B As FrmUB430B
    Public MyFrmListUBType As FrmListUBType
    Public MyTypes As String
   Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmUB430 = New FrmUB430
    Application.Run(MyFrmUB430)
   End Sub
  Public Function GetUTTYPETaxType(ByVal Code As String) As String
     Dim myUTTYPE As UTTYPE.myData

     myUTTYPE = New UTTYPE.mydata(MyDBConnect)
     If IsNothing(Code) Or Code = "" Then
       Return ""
     End If

     myUTTYPE.GetOneRecordP(Code)
     If Not myUTTYPE.RecordNotFound Then
       GetUTTYPETaxType = Trim(myUTTYPE._TYTXTP)
     Else
       GetUTTYPETaxType = ""
     End If
     Return GetUTTYPETaxType

  End Function
  Public Function GetUTTYPEFamily(ByVal Code As String) As String
     Dim myUTTYPE As UTTYPE.myData

     myUTTYPE = New UTTYPE.mydata(MyDBConnect)
     If IsNothing(Code) Or Code = "" Then
       Return ""
     End If

     myUTTYPE.GetOneRecordP(Code)
     If Not myUTTYPE.RecordNotFound Then
       GetUTTYPEFamily = Trim(myUTTYPE._TYUTTP)
     Else
       GetUTTYPEFamily = ""
     End If
     Return GetUTTYPEFamily

  End Function
End Module






