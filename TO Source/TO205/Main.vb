
Module Main
  Public MyFrmTO205 As FrmTO205
  Public MyFrmTO205B As FrmTO205B
  Public MyCrViewer As FrmCrViewer
  Public MyM35Ov As Boolean
  Public MyLocEld As String
  Sub Main()
    StartUp()
    GetSecurity()
    MyLocEld = ""
    If GetGNET("LECOV") = "Y" Then
      MyLocEld = "032"
    End If
    If GetGNET("LEDAR") = "Y" Then
      MyLocEld = "035"
    End If
    If GetGNET("LEEL") = "Y" Then
      MyLocEld = "045"
    End If
    If GetGNET("LEFRM") = "Y" Then
      MyLocEld = "084"
    End If

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    'Allow overwrite gross option
    If GetGNET("M35OV") = "Y" Then
      MyM35Ov = True
    End If

    MyFrmTO205 = New FrmTO205
    Application.Run(MyFrmTO205)

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






