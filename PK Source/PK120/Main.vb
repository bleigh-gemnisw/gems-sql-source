Module Main
  Public MyFrmPK120 As FrmPK120
  Public MyFrmPK120B As FrmPK120B
  Public MyFrmPK120C As FrmPK120C
Sub Main()
  StartUp()
  GetSecurity()  '#sec
  GetTown()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmPK120 = New FrmPK120
  Application.Run(MyFrmPK120)
End Sub
  Public Function GetViolDesc(ByVal Code As Integer) As String
     Dim myPKVIOL As PKVIOL.MyData

    myPKVIOL = New PKVIOL.MyData(myDBConnect)
    If IsNothing(Code) Or Code = 0 Then
       Return ""
     End If

     myPKVIOL.GetOneRecordP(Code)
     If Not myPKVIOL.RecordNotFound Then
       GetViolDesc = Trim(myPKVIOL._DESCR)
     Else
       GetViolDesc = "*** Unknown ***"
     End If
     Return GetViolDesc

  End Function
End Module
