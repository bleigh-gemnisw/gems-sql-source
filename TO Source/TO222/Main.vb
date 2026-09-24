
Module Main
  Public MyFrmTO222 As FrmTO222
  Public MyFrmTO222B As FrmTO222B
  Public MyFrmTO222C As FrmTO222C
  Public MyFrmListMVD As FrmListMVD
  Public MyFrmListRealC As FrmListRealC
  Public MyFrmListSupp As FrmListSupp
  Public MyCrViewer As FrmCrViewer
  Public MyLocEld As String
  Public MyM35HIncome As Boolean
  Sub Main()
    StartUp()
    GetSecurity()
    ' If GetGNET("LEEL") = "Y" Then MyLocEld = "045"
    ' If GetGNET("LEFRM") = "Y" Then MyLocEld = "084"
    ' If GetGNET("LEWIN") = "Y" Then MyLocEld = "162"
    ' If GetGNET("M59IN") = "Y" Then MyM35HIncome = True

#If Not DEBUG Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTO222 = New FrmTO222
    Application.Run(MyFrmTO222)
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






