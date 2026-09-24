Module Main
  Public MyFrmComments As FrmComments
	Public MyFrmTAP02 As FrmTAP02
	Public MyFrmTAP02B As FrmTAP02B
	Public MyFrmTAP02C As FrmTAP02C
	Public MyFrmTAP02LST As FrmTAP02LST
	Public MyFrmTAP02LST2 As FrmTAP02LST2
	Public MyFrmTAP02SUM As FrmTAP02SUM
	Public MyFrmListLease As FrmListLease
	Public MyFrmListPPRP As FrmListPPRP
	Public MyCrViewer As FrmCrViewer
	Public MyBlocking As Boolean
	Public MyLastYearNo As Integer
  Public MyDeclRound As Boolean
  Public cCode As Integer = 13
	Public CLtr As String = ""
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

		MyFrmTAP02 = New FrmTAP02
		Application.Run(MyFrmTAP02)
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
 Public Sub WriteTXDMSUM(ByVal ListNo As Integer, ByVal Year As Integer, ByVal DeYear As Integer, _
  ByVal DeCost As Integer, ByVal Qty As Integer)
 Dim MyTXDMSUM As TXDMSUM.myData
 Dim MyTXDMCD As TXDMCD.myData
 Dim MyTXDMDEP As TXDMDEP.myData

 MyTXDMSUM = New TXDMSUM.mydata(MyDBConnect)
 MyTXDMCD = New TXDMCD.mydata(MyDBConnect)
 MyTXDMDEP = New TXDMDEP.mydata(MyDBConnect)

 MyTXDMCD.GetOneRecordP(Year, cCode, "")
 If DeYear > MyLastYearNo Then
  MyTXDMDEP.GetOneRecordP(Year, MyLastYearNo)
 Else
  MyTXDMDEP.GetOneRecordP(Year, DeYear)
 End If
 MyTXDMSUM.GetOneRecordP(ListNo, Year, DeYear)
 If Not MyTXDMSUM.RecordNotFound Then
  With MyTXDMSUM
   ._QTY = ._QTY + Qty
   ._DECOST = ._DECOST + DeCost
   ._DENET = MyUtils.Round(._DECOST * (MyTXDMDEP._PCT / 100), 0)
   ._ASCOST = MyUtils.Round(._DECOST * (MyTXDMCD._ASPCT / 100), 0)
   ._ASNET = MyUtils.Round(._DENET * (MyTXDMCD._ASPCT / 100), 0)
  End With
  MyTXDMSUM.UpdateOneRecordP()
 Else
  With MyTXDMSUM
   ._LISTNO = ListNo
   ._YEAR = Year
   ._DEYEAR = DeYear
   ._QTY = Qty
   ._DECOST = DeCost
   ._DENET = MyUtils.Round(._DECOST * (MyTXDMDEP._PCT / 100), 0)
   ._ASCOST = MyUtils.Round(._DECOST * (MyTXDMCD._ASPCT / 100), 0)
   ._ASNET = MyUtils.Round(._DENET * (MyTXDMCD._ASPCT / 100), 0)
  End With
  MyTXDMSUM.AddOneRecordP()
 End If

 End Sub
  Public Sub WriteTXDCSUM(ByVal ListNo As Integer, ByVal Year As Integer, ByVal DeYear As Integer, _
   ByVal Value As Integer)
  Dim MyTXDCSUM As TXDCSUM.myData
  Dim MyTXDMCD As TXDMCD.myData
  Dim MyTXDMDEP As TXDMDEP.myData
  Dim WrkNet As Integer

  MyTXDCSUM = New TXDCSUM.mydata(MyDBConnect)
  MyTXDMCD = New TXDMCD.mydata(MyDBConnect)
  MyTXDMDEP = New TXDMDEP.mydata(MyDBConnect)

  MyTXDMCD.GetOneRecordP(Year, cCode, CLtr)
  If DeYear > MyLastYearNo Then
    MyTXDMDEP.GetOneRecordP(Year, MyLastYearNo)
  Else
    MyTXDMDEP.GetOneRecordP(Year, DeYear)
  End If
  MyTXDCSUM.GetOneRecordP(ListNo, Year, cCode)
  If Not MyTXDCSUM.RecordNotFound Then
    With MyTXDCSUM
      ._VALUE = ._VALUE + MyUtils.Round(Value * (MyTXDMDEP._PCT / 100), 0)
      WrkNet = MyUtils.Round(._VALUE * (MyTXDMCD._ASPCT / 100), 0)
      If MyDeclRound Then
        WrkNet = RoundNumber(WrkNet, "Normal")
      End If
      ._NET = WrkNet
    End With
    MyTXDCSUM.UpdateOneRecordP()
  Else
    With MyTXDCSUM
      ._LISTNO = ListNo
      ._YEAR = Year
      ._CODE = cCode
      ._VALUE = MyUtils.Round(Value * (MyTXDMDEP._PCT / 100), 0)
      WrkNet = MyUtils.Round(._VALUE * (MyTXDMCD._ASPCT / 100), 0)
      If MyDeclRound Then
        WrkNet = RoundNumber(WrkNet, "Normal")
      End If
      ._NET = WrkNet
    End With
    MyTXDCSUM.AddOneRecordP()
  End If

  End Sub
Public Function GetTXDMLESName(ByVal Code As String) As String
		 Dim myTXDMLES As TXDMLES.myData

		 myTXDMLES = New TXDMLES.mydata(MyDBConnect)
		 If IsNothing(Code) Or Code = "" Then
			 Return ""
		 End If

		myTXDMLES.GetOneRecordP(Code)
		 If Not myTXDMLES.RecordNotFound Then
			 GetTXDMLESName = myTXDMLES._NAME
		 Else
			 GetTXDMLESName = "*** Unknown ***"
		 End If
		 Return GetTXDMLESName

	End Function
Public Function GetLastYearNo(ByVal Year As Integer) As Integer
	Dim myTXDMDEP As TXDMDEP.myData
	Dim ds2 As DataSet = New DataSet
	Dim MaxRow As Integer

	myTXDMDEP = New TXDMDEP.mydata(MyDBConnect)
	ds2 = myTXDMDEP.GetAllYear(Year)
	If ds2.Tables(0).Rows.Count > 0 Then
		MaxRow = ds2.Tables(0).Rows.Count - 1
		Return ds2.Tables(0).Rows(MaxRow).Item("YearNo")
	Else
		Return 0
	End If
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






