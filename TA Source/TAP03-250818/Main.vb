Module Main
  Public MyFrmTAP03 As FrmTAP03
	Public MyFrmTAP03AFF As FrmTAP03AFF
	Public MyFrmTAP03B As FrmTAP03B
	Public MyFrmTAP03C As FrmTAP03C
	Public MyFrmTAP03SUM As FrmTAP03SUM
	Public MyFrmTAP03SUM2 As FrmTAP03SUM2
	Public MyFrmComments As FrmComments
	Public MyFrmListPPRP As FrmListPPRP
  Public MyDeclRound As Boolean
  Public MyBlocking As Boolean
  Public MyBookPct As Decimal
  Public MyMinValue As Integer
  Sub Main()
    StartUp()
    GetSecurity()  '#sec
    If UCase(myDBConnect.ServerName) = "SQL" Then
      MyBlocking = False
    Else
      MyBlocking = True
    End If
    If GetGNET("DCRND") = "Y" Then
      MyDeclRound = True
    Else
      MyDeclRound = False
    End If

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTAP03 = New FrmTAP03
    Application.Run(MyFrmTAP03)
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
 Public Sub WriteTXDCSUM(ByVal ListNo As Integer, ByVal Year As Integer, ByVal Code As Integer, _
  ByVal Letter As String, ByVal Value As Integer)
 Dim MyTXDCSUM As TXDCSUM.myData
 Dim MyTXDCCD As TXDCCD.myData
 Dim WrkNet As Integer

 MyTXDCSUM = New TXDCSUM.mydata(MyDBConnect)
 MyTXDCCD = New TXDCCD.mydata(MyDBConnect)

 MyTXDCCD.GetOneRecordP(Year, Code, Letter)
 MyTXDCSUM.GetOneRecordP(ListNo, Year, Code)
 If Not MyTXDCSUM.RecordNotFound Then
  With MyTXDCSUM
   ._VALUE = ._VALUE + Value
   WrkNet = MyUtils.Round(._VALUE * (MyTXDCCD._ASPCT / 100), 0)
   If MyDeclRound And Code <> 25 Then
     WrkNet = RoundNumber(WrkNet, "Normal")
   End If
   ._NET = WrkNet
  End With
  MyTXDCSUM.UpdateOneRecordP()
 Else
  With MyTXDCSUM
   ._LISTNO = ListNo
   ._YEAR = Year
   ._CODE = Code
   ._VALUE = Value
   WrkNet = MyUtils.Round(Value * (MyTXDCCD._ASPCT / 100), 0)
   If MyDeclRound And Code <> 25 Then
     WrkNet = RoundNumber(WrkNet, "Normal")
   End If
   ._NET = WrkNet
  End With
  MyTXDCSUM.AddOneRecordP()
 End If

 End Sub
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






