Module Main
  Public MyFrmTAP21 As FrmTAP21
  Public MyFrmTAP21B As FrmTAP21B
  Public MyFrmProgress As FrmProgress
  Public MyDeclRound As Boolean 'Round to nearest 10
  Public MyReportLandScape As Boolean

	Sub Main()
    StartUp()
    GetSecurity()  '#sec
    If GetGNET("DCRND") = "Y" Then
      MyDeclRound = True
    Else
      MyDeclRound = False
    End If

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

		MyFrmTAP21 = New FrmTAP21
		Application.Run(MyFrmTAP21)
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
Public Function RoundNumber(ByVal WrkNumber As Integer, ByVal RoundMethod As String) As Integer
    Dim RoundDown As Boolean
    Dim J As Integer

    Select Case RoundMethod
    Case "Down"
      RoundDown = True
    Case "Normal"
      RoundDown = False
    Case Else
      Return WrkNumber
    End Select

    J = WrkNumber Mod 10
    If J <> 0 Then
      If RoundDown Then
        WrkNumber = WrkNumber - J
      Else
        If J < 5 Then
          WrkNumber = WrkNumber - J
        Else
          WrkNumber = WrkNumber + (10 - J)
        End If
      End If
    End If

    Return WrkNumber
End Function
End Module






