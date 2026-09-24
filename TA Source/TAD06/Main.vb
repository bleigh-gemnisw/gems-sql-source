
Module Main
  Public MyFrmTAD06 As FrmTAD06
  Public MyFrmTAD06B As FrmTAD06B
  Public MyFrmTAD06C As FrmTAD06C
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

    MyFrmTAD06 = New FrmTAD06
    Application.Run(MyFrmTAD06)
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
  End Sub
  Public Sub GetREAddr(ByVal ListNo As Integer, ByVal TxYear As Integer)
    Dim myTXREAA As TXREAA.MyData

    If ListNo = 0 Then Exit Sub

    myTXREAA = New TXREAA.MyData(myDBConnect)
    myTXREAA.GetOneRecordP(ListNo, TxYear)
    If Not myTXREAA.RecordNotFound Then
      With MyFrmTAD06C
        .LblREName.Text = Trim(myTXREAA._NAME)
        .LblRESname.Text = Trim(myTXREAA._SNAME)
        .LblREAdd1.Text = Trim(myTXREAA._ADD1)
        .LblREAdd2.Text = Trim(myTXREAA._ADD2)
        .LblRECity.Text = Trim(myTXREAA._CITY)
        .LblREState.Text = Trim(myTXREAA._STATE)
        .LblReZip5.Text = Format(myTXREAA._ZIP5, "00000")
        If myTXREAA._ZIP4 > 0 Then
          .LblREZip4.Text = Format(myTXREAA._ZIP4, "0000")
        End If
        .LblDist.Text = myTXREAA._DIST
        .LblLoc.Text = Trim(myTXREAA._LOCNo) & " " & Trim(myTXREAA._LOC)
        .LblUnit.Text = Trim(myTXREAA._UNITNo)
        .LblMap.Text = Trim(myTXREAA._MAP)
        .LblSMap.Text = Trim(myTXREAA._SMAP)
      End With
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






