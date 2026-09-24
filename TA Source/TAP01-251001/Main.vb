
Module Main
  Public MyFrmTAP01 As FrmTAP01
  Public MyFrmTAP01AFF As FrmTAP01AFF
  Public MyFrmTAP01ASS As FrmTAP01ASS
  Public MyFrmTAP01ASS2 As FrmTAP01ASS2
  Public MyFrmTAP01B As FrmTAP01B
  Public MyFrmTAP01BUS As FrmTAP01BUS
  Public MyFrmTAP01BUS2 As FrmTAP01BUS2
  Public MyFrmTAP01C As FrmTAP01C
  Public MyFrmTAP01DEP As FrmTAP01DEP
	Public MyFrmTAP01DSP As FrmTAP01DSP
  Public MyFrmTAP01DSP2 As FrmTAP01DSP2
  Public MyFrmTAP01HOR As FrmTAP01HOR
  Public MyFrmTAP01HOR2 As FrmTAP01HOR2
  Public MyFrmTAP01LEE As FrmTAP01LEE
  Public MyFrmTAP01LEE2 As FrmTAP01LEE2
  Public MyFrmTAP01LOR As FrmTAP01LOR
  Public MyFrmTAP01LOR2 As FrmTAP01LOR2
  Public MyFrmTAP01MOB As FrmTAP01MOB
  Public MyFrmTAP01MOB2 As FrmTAP01MOB2
  Public MyFrmTAP01MV As FrmTAP01MV
  Public MyFrmTAP01MV2 As FrmTAP01MV2
  Public MyFrmTAP01SUM As FrmTAP01SUM
  Public MyFrmTAP01TWN As FrmTAP01TWN
  Public MyFrmTAP01TWN2 As FrmTAP01TWN2
  Public MyFrmListCodes As FrmListCodes
  Public MyFrmListPPRP As FrmListPPRP
  Public MyFrmComments As FrmComments
  Public MyCrViewer As FrmCrViewer
  Public MyBlocking As Boolean
  Public MyDeclRound As Boolean 'Round to nearest 10
  Public MyPrtComm As Boolean 'Print Comments on Summary page
  Public cLightBlue As Color = Color.FromArgb(212, 242, 246)
  Public MyBookPct As Decimal
  Public MyMinValue As Integer
  Sub Main()
    StartUp()
    GetSecurity()
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
    If GetGNET("DCCMT") = "Y" Then
      MyPrtComm = True
    Else
      MyPrtComm = False
    End If
    MyServer = UCase(myDBConnect.ServerName)

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTAP01 = New FrmTAP01
    Application.Run(MyFrmTAP01)
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
 Public Function GetTXBustyDesc(ByVal Code As String) As String
  Dim myTXBUSTY As TXBUSTY.myData

  myTXBUSTY = New TXBUSTY.mydata(MyDBConnect)
  If IsNothing(Code) Or Code = "" Then
   Return ""
  End If

  myTXBUSTY.GetOneRecordP(Code)
  If Not myTXBUSTY.RecordNotFound Then
   GetTXBustyDesc = Trim(myTXBUSTY._BTDESC)
  Else
   GetTXBustyDesc = "*** Unknown ***"
  End If
  Return GetTXBustyDesc

 End Function
	Public Sub WriteTXDCSUM(ByVal ListNo As Integer, ByVal Year As Integer, ByVal Code As Integer, _
		ByVal Letter As String, ByVal Value As Integer, Optional ByVal Net As Integer = 0)
	Dim MyTXDCSUM As TXDCSUM.myData
	Dim MyTXDCCD As TXDCCD.myData
	Dim WrkNet As Integer

  If MyDeclRound And Code <> 25 Then
    Net = RoundNumber(Net, "Normal")
  End If

	MyTXDCSUM = New TXDCSUM.mydata(MyDBConnect)
	MyTXDCCD = New TXDCCD.mydata(MyDBConnect)

	MyTXDCCD.GetOneRecordP(Year, Code, Letter)
	MyTXDCSUM.GetOneRecordP(ListNo, Year, Code)
	If Not MyTXDCSUM.RecordNotFound Then
		With MyTXDCSUM
			._VALUE = ._VALUE + Value
			If Net = 0 Then
        WrkNet = MyUtils.Round(._VALUE * (MyTXDCCD._ASPCT / 100), 0)
        If MyDeclRound And Code <> 25 Then
          WrkNet = RoundNumber(WrkNet, "Normal")
        End If
        ._NET = WrkNet
      Else
        ._NET = ._NET + Net
      End If
    End With
    MyTXDCSUM.UpdateOneRecordP()
  Else
    With MyTXDCSUM
      ._LISTNO = ListNo
      ._YEAR = Year
      ._CODE = Code
      ._VALUE = Value
      If Net = 0 Then
        WrkNet = MyUtils.Round(Value * (MyTXDCCD._ASPCT / 100), 0)
        If MyDeclRound And Code <> 25 Then
          WrkNet = RoundNumber(WrkNet, "Normal")
        End If
        ._NET = WrkNet
      Else
        ._NET = Net
      End If
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
 Public Sub CloseForms()
   'MyFrmTAP01 = Nothing
   'MyFrmTAP01AFF = Nothing
   'MyFrmTAP01ASS = Nothing
   'MyFrmTAP01ASS2 = Nothing
   'MyFrmTAP01B = Nothing
   'MyFrmTAP01BUS = Nothing
   'MyFrmTAP01BUS2 = Nothing
   'MyFrmTAP01C = Nothing
   'MyFrmTAP01DEP = Nothing
   'MyFrmTAP01DSP = Nothing
   'MyFrmTAP01DSP2 = Nothing
   'MyFrmTAP01HOR = Nothing
   'MyFrmTAP01HOR2 = Nothing
   'MyFrmTAP01LEE = Nothing
   'MyFrmTAP01LEE2 = Nothing
   'MyFrmTAP01LOR = Nothing
   'MyFrmTAP01LOR2 = Nothing
   'MyFrmTAP01MOB = Nothing
   'MyFrmTAP01MOB2 = Nothing
   'MyFrmTAP01MV = Nothing
   'MyFrmTAP01MV2 = Nothing
   'MyFrmTAP01SUM = Nothing
   'MyFrmTAP01SUM2 = Nothing
   'MyFrmTAP01SUMEX = Nothing
   'MyFrmTAP01TWN = Nothing
   'MyFrmTAP01TWN2 = Nothing
   'MyFrmListCodes = Nothing
   'MyFrmListPPRP = Nothing
   'MyFrmComments = Nothing
End Sub
End Module






