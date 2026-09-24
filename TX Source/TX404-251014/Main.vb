'TXINV: Update ADD1: ADD2: CCM: CITY: CHDATE: CHTIME: FEC1: FED1: FEC2:
'TXINV: Update FED2: FEC3: FED3: FEC4: FED4: FEC5: FED5: NAME: SNAME:
'TXINV: Update STATE: STCD1: STCD2: STCD3: STCD4: STCD5: ZIP4: ZIP5:
'TXHST: Add
Module Main
  Public MyFrmTX404 As FrmTX404
  Public MyFrmTX4041 As FrmTX4041
  Public MyFrmTX4041B As FrmTX4041B
  Public MyFrmTX4042 As FrmTX4042
  Public MyFrmTX4042B As FrmTX4042B
  Public MyFrmTX4042C As FrmTX4042C
  Public MyFrmTX4042D As FrmTX4042D
  Public MyFrmListPenCd As FrmListPenCd
  Public MyFrmListSts As FrmListSts
  Public MyFrmSelTypes As FrmSelTypes
  Public MyFrmSelYear As FrmSelYear
  Public MyFrmSetPrinter As FrmSetPrinter
  Public MyFrmSettings As FrmSettings
  Public MyCrViewer As FrmCrViewer
  Public myds As DataSet = New DataSet
  Public mydsVerify As DataSet = New DataSet
  Public MySelBal As String
  Public MySelTypes As String
  Public MySelFromYear As Integer
  Public MySelToYear As Integer
  Public MyQrySelect As String
  Public MyBlocking As Boolean
  Public MyAltFormID As String
  Public MyStatusHistory As Boolean
  Public MyGridMax As Integer
  Public MyCustomDir As String
  Public MyMVFee As Decimal
  Public MyWarrantFee As Decimal
  Public MyPreview As Boolean
  Public MyPrinter As String
  Public MyReportTitle As String
  Public MyReportText As String
  Public MyReportName As String
  'Buffer TXTYPE
  Public WrkCode(50) As String
  Public WrkDesc(50) As String
  Public WrkFamily(50) As String
  Public MyAppSettings As AppSettings
  Sub Main()
    StartUp()
    BufferType()
    GetAppSettings()
    If GetGNETValue("STHST") = "Y" Then MyStatusHistory = True
    MyGridMax = MyAppSettings.GridMax
    If MyGridMax = 0 Then MyGridMax = 100
    MyCustomDir = GetGNETValue("RPTSD")
    GetTXMVFee()
    MyWarrantFee = 6

#If Not DEBUG Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX404 = New FrmTX404
    Application.Run(MyFrmTX404)
  End Sub
  Public Function GetGNETValue(ByVal Code As String) As String
    Dim myGNET As GNET.MyData

    myGNET = New GNET.MyData()
    myGNET.MyDBConn = myDBConnect
    If IsNothing(Code) Or Code = "" Then
      Return String.Empty
    End If

    GetGNETValue = String.Empty
    myGNET.GetOneRecordP(Code)
    If Not myGNET.RecordNotFound Then
      GetGNETValue = myGNET._VALUE
    End If
    Return GetGNETValue

  End Function
  Private Sub GetTXMVFee()
    Dim myTXMVFEE As TXMVFEE.MyData
    myTXMVFEE = New TXMVFEE.MyData(myDBConnect)
    myTXMVFEE.GetOneRecordP(1)
    If Not myTXMVFEE.RecordNotFound Then
      MyMVFee = myTXMVFEE._MVFEE
    End If
    myTXMVFEE.CloseFile()
    myTXMVFEE = Nothing
  End Sub
  Private Sub BufferType()
    Dim I As Integer

    Dim myTXTYPE As TXTYPE.MyData
    Dim dsTXType As DataSet = New DataSet

    myTXTYPE = New TXTYPE.MyData(myDBConnect)

    dsTXType = myTXTYPE.GetAllData
    For I = 0 To dsTXType.Tables(0).Rows.Count - 1
      With dsTXType.Tables(0).Rows(I)
        WrkCode(I) = .Item("tycode")
        WrkDesc(I) = .Item("tydesc")
        WrkFamily(I) = .Item("txfam")
      End With
    Next

  End Sub
  Public Function LookupType(ByVal Type As String) As String()
    Dim I As Integer
    Dim WrkResult(1) As String

    WrkResult(0) = ""
    WrkResult(1) = ""

    For I = 0 To WrkCode.GetUpperBound(0)
      If WrkCode(I) = "" Then
        Return WrkResult
      End If
      If Type = WrkCode(I) Then
        WrkResult(0) = WrkDesc(I)
        WrkResult(1) = WrkFamily(I)
        Return WrkResult
      End If
    Next

    Return WrkResult
  End Function
  Public Function GetTXStsDesc(ByVal Code As String) As String
    Dim myTXSTS As TXSTS.MyData

    myTXSTS = New TXSTS.MyData(myDBConnect)
    If IsNothing(Code) Then
      Return ""
    End If

    GetTXStsDesc = ""
    myTXSTS.GetOneRecordP(Code)
    If Not myTXSTS.RecordNotFound Then
      GetTXStsDesc = Trim(myTXSTS._STDESC)
    Else
      GetTXStsDesc = "*** Unknown ***"
    End If
    Return GetTXStsDesc

  End Function
  Public Function GetTXPenDesc(ByVal Code As String) As String
    Dim myTXPEN As TXPEN.MyData

    myTXPEN = New TXPEN.MyData(myDBConnect)
    If IsNothing(Code) Then
      Return ""
    End If

    GetTXPenDesc = ""
    myTXPEN.GetOneRecordP(Code)
    If Not myTXPEN.RecordNotFound Then
      GetTXPenDesc = Trim(myTXPEN._PNDESC)
    Else
      GetTXPenDesc = "*** Unknown ***"
    End If
    Return GetTXPenDesc

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
End Module






