Module Main
  Public MyFrmCrViewer As FrmCrViewer
  Public MyFrmLOG As FrmLOG
  Public MyFrmUB102 As FrmUB102
	Public MyFrmUB102B As FrmUB102B
	Public MyFrmUB102C As FrmUB102C
	Public MyFrmUB102AS As FrmUB102AS
	Public MyFrmUB102Amort As FrmUB102Amort
	Public MyFrmUB102Payoff As FrmUB102Payoff
  Public MyFrmUB102Payoff2 As FrmUB102Payoff2
  Public MyFrmUB102MT As FrmUB102MT
	Public MyFrmUB102US As FrmUB102US
	Public MyFrmComments As FrmComments
	Public MyFrmListDist As FrmListDist
	Public MyFrmListMeterSize As FrmListMeterSize
	Public MyFrmListRates As FrmListRates
  Public MyEDU1 As Boolean
  Sub Main()
    StartUp()
    GetSecurity()  '#sec
    MyEDU1 = GetGNET("EDU1")

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmUB102 = New FrmUB102
    Application.Run(MyFrmUB102)
  End Sub
  Public Function GetUTRateASDesc(ByVal Type As String, ByVal Code As String) As String
    Dim MyUTRATEAS As UTRATEAS.myData

    MyUTRATEAS = New UTRATEAS.myData(myDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    MyUTRATEAS.GetOneRecordP(Type, Code)
    If Not MyUTRATEAS.RecordNotFound Then
      GetUTRateASDesc = Trim(MyUTRATEAS._RADESC)
    Else
      GetUTRateASDesc = "*** Unknown ***"
    End If
    Return GetUTRateASDesc

  End Function
	Public Function GetUTRateMTDesc(ByVal Type As String, ByVal Code As String) As String
		Dim MyUTRATEMT As UTRATEMT.myData
		Dim dsUTRATEMT As DataSet = New DataSet

		MyUTRATEMT = New UTRATEMT.myData(myDBConnect)
		If IsNothing(Code) Or Code = "" Then
			Return ""
		End If

		dsUTRATEMT = MyUTRATEMT.GetAllCode(Type, Code, 1)
		If dsUTRATEMT.Tables(0).Rows.Count > 0 Then
			GetUTRateMTDesc = dsUTRATEMT.Tables(0).Rows(0).Item("rmdesc")
		Else
			GetUTRateMTDesc = "*** Unknown ***"
		End If
		Return GetUTRateMTDesc

	End Function
	Public Function GetUTRateUSDesc(ByVal Type As String, ByVal Code As String) As String
		Dim MyUTRATEUS As UTRATEUS.myData

		MyUTRATEUS = New UTRATEUS.myData(myDBConnect)
		If IsNothing(Code) Or Code = "" Then
			Return ""
		End If

		MyUTRATEUS.GetOneRecordP(Type, Code)
		If Not MyUTRATEUS.RecordNotFound Then
			GetUTRateUSDesc = Trim(MyUTRATEUS._RUDESC)
		Else
			GetUTRateUSDesc = "*** Unknown ***"
		End If
		Return GetUTRateUSDesc

	End Function
	Public Function GetUTMeterDesc(ByVal Type As String, ByVal Size As String) As String
		Dim MyUTMETER As UTMETER.myData

		MyUTMETER = New UTMETER.myData(myDBConnect)
		If IsNothing(Size) Or Size = "" Then
			Return ""
		End If

		MyUTMETER.GetOneRecordP(Type, Size)
		If Not MyUTMETER.RecordNotFound Then
			GetUTMeterDesc = Trim(MyUTMETER._MTDESC)
		Else
			GetUTMeterDesc = "*** Unknown ***"
		End If
		Return GetUTMeterDesc

	End Function
	Public Function GetUTMeterBlcd(ByVal Type As String, ByVal Size As String) As String
		Dim MyUTMETER As UTMETER.myData

		MyUTMETER = New UTMETER.myData(myDBConnect)
		If IsNothing(Size) Or Size = "" Then
			Return ""
		End If

		MyUTMETER.GetOneRecordP(Type, Size)
		If Not MyUTMETER.RecordNotFound Then
			GetUTMeterBlcd = Trim(MyUTMETER._MTBLCD)
		Else
			GetUTMeterBlcd = ""
		End If
		Return GetUTMeterBlcd

	End Function
Public Function GetUTTypeDesc(ByVal Code As String) As String
		 Dim myUTTYPE As UTTYPE.myData

		 myUTTYPE = New UTTYPE.myData(myDBConnect)
		 If IsNothing(Code) Or Code = "" Then
			 Return ""
		 End If

		myUTTYPE.GetOneRecordP(Code)
		 If Not myUTTYPE.RecordNotFound Then
			 GetUTTypeDesc = Trim(myUTTYPE._TYDESC)
		 Else
			 GetUTTypeDesc = "*** Unknown ***"
		 End If
		 Return GetUTTypeDesc

	End Function
Public Function GetRateCode(ByVal WrkListNo As Integer, ByVal WrkUBType As String) As String
	Dim MyUTCUSTRT As UTCUSTRT.myData

	MyUTCUSTRT = New UTCUSTRT.myData(myDBConnect)

	MyUTCUSTRT.GetOneRecordP(WrkListNo, WrkUBType)
	If Not MyUTCUSTRT.RecordNotFound Then
		With MyUTCUSTRT
			GetRateCode = ._CRCODE
		End With
	Else
		GetRateCode = ""
	End If
	Return GetRateCode
End Function
  Public Function GetGNET(ByVal Code As String) As Boolean
     Dim myGNET As GNET.MyData

    myGNET = New GNET.MyData()
    myGNET.MyDBConn = myDBConnect
    If IsNothing(Code) Or Code = "" Then
       Return False
     End If

     myGNET.GetOneRecordP(Code)
     If Not myGNET.RecordNotFound Then
       If myGNET._VALUE = "Y" Then
         GetGNET = True
       End If
     Else
       GetGNET = False
     End If
     myGNET.CloseFile()
     myGNET = Nothing
     Return GetGNET

  End Function
End Module
