
Module Main
  Public MyFrmGL651 As FrmGL651
  Public MyFrmGL651B As FrmGL651B
  Public MyCrViewer As FrmCrViewer
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmGL651 = New FrmGL651
    Application.Run(MyFrmGL651)

   End Sub
  Public Function GetGLOBJTDesc(ByVal PObject As Integer) As String
     Dim myGLOBJT As GLOBJT.myData

     myGLOBJT = New GLOBJT.MyData()
     myGLOBJT.MyDBConn = myDBConnect
     If PObject = 0 Then
       Return ""
     End If

     myGLOBJT.GetOneRecordP(PObject)
     If Not myGLOBJT.RecordNotFound Then
       GetGLOBJTDesc = Trim(myGLOBJT._OBDSC)
     Else
       GetGLOBJTDesc = "*** Unknown ***"
     End If
     Return GetGLOBJTDesc

  End Function
End Module
