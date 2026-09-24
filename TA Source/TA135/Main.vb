
Module Main
  Public MyFrmTA135 As FrmTA135
  Public MyFrmTA135B As FrmTA135B
  Public MyLocEld As String

Sub Main()
  StartUp()
  GetSecurity() '#sec
  If GetGNET("LEEL") = "Y" Then MyLocEld = "045"
  If GetGNET("LEFRM") = "Y" Then MyLocEld = "084"

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTA135 = New FrmTA135
  Application.Run(MyFrmTA135)
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
End Module






