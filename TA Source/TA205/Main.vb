
Module Main
  Public MyFrmTA205 As FrmTA205
  Public MyFrmTA205B As FrmTA205B
  Public MyCrViewer As FrmCrViewer
  Public MyTypes As String
  Public MyNoCAMA As Boolean
Sub Main()
    StartUp()
    GetSecurity()
    If GetGNET("NOCAM") = "Y" Then MyNoCAMA = True

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA205 = New FrmTA205
    Application.Run(MyFrmTA205)

   End Sub
  Private Function GetGNET(ByVal Key As String) As String
  Dim myGNET As GNET.myData

  myGNET = New GNET.MyData()
    myGNET.MyDBConn = myDBConnect
  myGNET.GetOneRecordP(Key)
  With myGNET
    If .RecordNotFound Then Return String.Empty
    Return ._VALUE
  End With

End Function
Public Function GetTXTypeDesc(ByVal Code As String) As String
     Dim myTXTYPE As TXTYPE.myData

     myTXTYPE = New TXTYPE.mydata(MyDBConnect)
     If IsNothing(Code) Or Code = "" Then
       Return ""
     End If

     myTXTYPE.GetOneRecordP(Code)
     If Not myTXTYPE.RecordNotFound Then
       GetTXTypeDesc = Trim(myTXTYPE._TYDESC)
     Else
       GetTXTypeDesc = "*** Unknown ***"
     End If
     Return GetTXTypeDesc

  End Function

End Module






