
Module Main
  Public MyFrmTO201 As FrmTO201
  Public MyFrmTO201B As FrmTO201B
  Public MyFrmTO201C As FrmTO201C
  Public MyFrmTO201D As FrmTO201D
  Public MyFrmListHome As FrmListHome
  Public MyFrmListRealC As FrmListRealC
  Public MyCrViewer As FrmCrViewer
  Public MillRateYear As Integer
  Public MyWarnProf As Boolean
  Public MyLocEld As String
  Sub Main()
    StartUp()
    GetSecurity()
    MyLocEld = ""
    If GetGNET("LECOV") = "Y" Then 'Coventry
      MyLocEld = "032"
    End If
    If GetGNET("LEDAR") = "Y" Then 'Darien
      MyLocEld = "035"
    End If
    If GetGNET("LEEL") = "Y" Then 'East Lyme
      MyLocEld = "045"
    End If
    If GetGNET("LEFRM") = "Y" Then 'Milford
      MyLocEld = "084"
    End If
    If GetGNET("LEWIN") = "Y" Then 'Winchester
      MyLocEld = "162"
    End If

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTO201 = New FrmTO201
    Application.Run(MyFrmTO201)
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
Public Function GetTXCDAGCode(ByVal Seq As Integer) As Integer
     Dim myTXCDAG As TXCDAG.myData

     myTXCDAG = New TXCDAG.mydata(MyDBConnect)
     If Seq = 0 Then
       Return 0
     End If

     myTXCDAG.GetOneRecordP(Seq)
     If Not myTXCDAG.RecordNotFound Then
       GetTXCDAGCode = myTXCDAG._TCCODE
     Else
       GetTXCDAGCode = 0
     End If
     Return GetTXCDAGCode

  End Function
End Module






