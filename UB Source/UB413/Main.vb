
Module Main
  Public MyFrmUB413 As FrmUB413
  Public MyFrmUB413B As FrmUB413B
  Public MyFrmListDist As FrmListDist
  Public MyFrmListUBType As FrmListUBType
  Public MyCrViewer As FrmCrViewer
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmUB413 = New FrmUB413
    Application.Run(MyFrmUB413)

   End Sub
  Public Function GetUTTypeDesc(ByVal Code As String) As String
     Dim myUTTYPE As UTTYPE.myData

     myUTTYPE = New UTTYPE.mydata(MyDBConnect)
     If IsNothing(Code) Or Code = "" Then
       Return ""
     End If

    myUTTYPE.GetOneRecordP(Code)
     If Not myUTTYPE.RecordNotFound Then
       GetUTTypeDesc = Trim(myUTTYPE._TYDESC)
     Else
       GetUTTypeDesc = "*** Unknown ***"
     End If
     Return GetUTTypeDesc

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






