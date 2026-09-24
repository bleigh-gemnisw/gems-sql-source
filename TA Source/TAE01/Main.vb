
Module Main
  Public MyFrmCalcIncr As FrmCalcIncr
  Public MyFrmTAE01 As FrmTAE01
  Public MyFrmTAE01B As FrmTAE01B
  Public MyFrmTAE01C As FrmTAE01C
  Public MyFrmListReal As FrmListReal
  Public MyCrViewer As FrmCrViewer
  Public MillRateYear As Integer
  Public MyReportLandscape As Boolean
  Public MyAppSettings As AppSettings
  Public MyIncrRound As Boolean
  Sub Main()
    StartUp()
    GetSecurity()
    GetAppSettings()
    If GetGNET("PXRND") = "Y" Then
      MyIncrRound = True
    Else
      MyIncrRound = False
    End If

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTAE01 = New FrmTAE01
    Application.Run(MyFrmTAE01)
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
  Public Sub GetAppSettings()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sr As IO.StreamReader
    Dim WrkXMLPath As String
    Dim WrkProgName As String

    WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
    WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & " " & MyUtils.GetComputerName() & ".xml"
    If MyUtils.CheckFileExists(WrkXMLPath) Then
      sr = New IO.StreamReader(WrkXMLPath)
      MyAppSettings = New AppSettings
      MyAppSettings = CType(xs.Deserialize(sr), AppSettings)
      sr.Close()
    Else
      MyAppSettings = New AppSettings
    End If
  End Sub
  Public Sub SaveAppSettings()
  Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
  Dim sw As IO.StreamWriter
  Dim WrkProgName As String
  Dim WrkXMLPath As String

  WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
  WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & " " & MyUtils.GetComputerName() & ".xml"
  sw = New IO.StreamWriter(WrkXMLPath)
  xs.Serialize(sw, MyAppSettings)
  sw.Close()
End Sub

Public Sub GetAddr(ByVal ListNo As Integer, ByVal Frozen As Boolean)
     Dim myTXREAL As TXReal.MyData
    'Dim myTXREALC As TXREALC.myData

    If ListNo = 0 Then Exit Sub

    'If Frozen Then
    'myTXREALC = New TXREALC.mydata(MyDBConnect)
    '   myTXREALC.GetOneRecordP(ListNo)
    '   If Not myTXREALC.RecordNotFound Then
    '     With MyFrmTAE01C
    '      If MyUtils.CnvSng(.TxtReListNo.Text) = 0 Then
    '        .TxtReListNo.Text = .TxtListNo.Text
    '      End If
    '      .TxtName.Text = Trim(myTXREALC._NAME)
    '      .TxtSname.Text = Trim(myTXREALC._SNAME)
    '      .TxtAdd1.Text = Trim(myTXREALC._ADD1)
    '      .TxtAdd2.Text = Trim(myTXREALC._ADD2)
    '      .TxtCity.Text = Trim(myTXREALC._CITY)
    '      .TxtState.Text = Trim(myTXREALC._STATE)
    '      .TxtZip5.Text = Format(myTXREALC._ZIP5, "00000")
    '      If myTXREALC._ZIP4 > 0 Then
    '        .TxtZip4.Text = Format(myTXREALC._ZIP4, "0000")
    '      End If
    '     End With
    '   End If
    ' Else
    myTXREAL = New TXReal.mydata(MyDBConnect)
       myTXREAL.GetOneRecordP(ListNo)
       If Not myTXREAL.RecordNotFound Then
         With MyFrmTAE01C
          If MyUtils.CnvSng(.TxtReListNo.Text) = 0 Then
            .TxtReListNo.Text = .TxtListNo.Text
          End If
          .TxtName.Text = Trim(myTXREAL._NAME)
          .TxtSname.Text = Trim(myTXREAL._SNAME)
          .TxtAdd1.Text = Trim(myTXREAL._ADD1)
          .TxtAdd2.Text = Trim(myTXREAL._ADD2)
          .TxtCity.Text = Trim(myTXREAL._CITY)
          .TxtState.Text = Trim(myTXREAL._STATE)
          .TxtZip5.Text = Format(myTXREAL._ZIP5, "00000")
          If myTXREAL._ZIP4 > 0 Then
            .TxtZip4.Text = Format(myTXREAL._ZIP4, "0000")
          End If
         End With
       End If
    'End If
  End Sub
	Public Sub GetREAddr(ByVal ListNo As Integer, ByVal Frozen As Boolean)
    Dim myTXREAL As TXREAL.MyData
    Dim myTXREALC As TXREALC.myData

		 If ListNo = 0 Then Exit Sub

    If Frozen Then
      myTXREALC = New TXREALC.mydata(MyDBConnect)
      myTXREALC.GetOneRecordP(ListNo)
      If Not myTXREALC.RecordNotFound Then
        With MyFrmTAE01C
          .LblREName.Text = Trim(myTXREALC._NAME)
          .LblRESname.Text = Trim(myTXREALC._SNAME)
          .LblREAdd1.Text = Trim(myTXREALC._ADD1)
          .LblREAdd2.Text = Trim(myTXREALC._ADD2)
          .LblRECity.Text = Trim(myTXREALC._CITY)
          .LblREState.Text = Trim(myTXREALC._STATE)
          .LblReZip5.Text = Format(myTXREALC._ZIP5, "00000")
          If myTXREALC._ZIP4 > 0 Then
            .LblREZip4.Text = Format(myTXREALC._ZIP4, "0000")
          End If
          .LblDist.Text = myTXREALC._DIST
          .LblLoc.Text = Trim(myTXREALC._LOCNO) & " " & Trim(myTXREALC._LOC)
          .LblUnit.Text = Trim(myTXREALC._UNITNO)
          .LblMap.Text = Trim(myTXREALC._MAP)
          .LblSMap.Text = Trim(myTXREALC._SMAP)
        End With
      End If
    Else
      myTXREAL = New TXReal.mydata(MyDBConnect)
      myTXREAL.GetOneRecordP(ListNo)
      If Not myTXREAL.RecordNotFound Then
        With MyFrmTAE01C
          .LblREName.Text = Trim(myTXREAL._NAME)
          .LblRESname.Text = Trim(myTXREAL._SNAME)
          .LblREAdd1.Text = Trim(myTXREAL._ADD1)
          .LblREAdd2.Text = Trim(myTXREAL._ADD2)
          .LblRECity.Text = Trim(myTXREAL._CITY)
          .LblREState.Text = Trim(myTXREAL._STATE)
          .LblReZip5.Text = Format(myTXREAL._ZIP5, "00000")
          If myTXREAL._ZIP4 > 0 Then
            .LblREZip4.Text = Format(myTXREAL._ZIP4, "0000")
          End If
          .LblDist.Text = myTXREAL._DIST
          .LblLoc.Text = Trim(myTXREAL._LOCNO) & " " & Trim(myTXREAL._LOC)
          .LblUnit.Text = Trim(myTXREAL._UNITNO)
          .LblMap.Text = Trim(myTXREAL._MAP)
          .LblSMap.Text = Trim(myTXREAL._SMAP)
        End With
      End If
    End If
  End Sub
Public Function GetMRateLast(ByVal Dist As Integer) As Decimal
	Dim mytxmrat1 As TXMRATL1.myData
	Dim ds As DataSet = New DataSet

	mytxmrat1 = New TXMRATL1.mydata(MyDBConnect)
  ds = mytxmrat1.PosHighYear(Dist, "R")
  If ds.Tables(0).Rows.Count = 0 Then
    ds = mytxmrat1.PosHighYear(Dist, "")
  End If

  If ds.Tables(0).Rows.Count > 0 Then
    GetMRateLast = ds.Tables(0).Rows(0).Item("mrrate")
    MillRateYear = ds.Tables(0).Rows(0).Item("year")
  Else
    GetMRateLast = 0
    MillRateYear = 0
  End If
End Function
Public Function GetTXPROETB(ByVal PMonth As Integer) As Decimal
  Dim myTXPROETB As TXPROETB.myData

  myTXPROETB = New TXPROETB.mydata(MyDBConnect)
  myTXPROETB.GetOneRecordP(PMonth)

  GetTXPROETB = 0
  If Not myTXPROETB.RecordNotFound Then
    GetTXPROETB = Math.Round(myTXPROETB._PRPCT, 3)
  End If
End Function
End Module






