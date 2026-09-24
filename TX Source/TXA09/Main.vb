'TXINV: Update BALD: BONDP: BONT: FEC1: FED1: FEC2: FED2: FEC3: FED3:
'TXINV: Update FEC4: FED4: FEC5: FED5: ICODE: INTPD: LIEN: LNPD: 
'TXINV: Update MVFLAG: NEWPAY: PAYREC: PRINT: PRLIN: RPD: TXIDT:
'TXHST: Add
Imports Splash

Module Main
  Public MyFrmInvDetail As FrmInvDetail
  Public MyFrmCr_PrtEdits As FrmCr_PrtEdits
  Public MyFrmCr_Online As FrmCr_Online
  Public MyFrmListAltID As FrmListAltID
  Public MyFrmListPenCd As FrmListPenCd
  Public MyFrmTXA09 As FrmTXA09
  Public MyFrmTXA091 As FrmTXA091
  Public MyFrmTXA09View As FrmTXA09View
  Public MyFrmTXA09Void As FrmTXA09Void
  Public MyFrmTXA092 As FrmTXA092
  Public MyFrmTXA09Open As FrmTXA09Open
  Public MyFrmTXA09Close As FrmTXA09Close
  Public MyFrmTXA094 As FrmTXA094
  Public MyFrmTXA094B As FrmTXA094B
  Public MyFrmTXA094C As FrmTXA094C
  Public MyFrmTXA099 As FrmTXA099
  Public MyFrmTXA09B As FrmTXA09B
  Public MyFrmTXA09Ben As FrmTXA09Ben
  Public MyFrmTXA09Crd As FrmTXA09Crd
  Public MyFrmTXA09Defer As FrmTXA09Defer
  Public MyFrmTXA09DMV As FrmTXA09DMV
  Public MyFrmTXA09Hist As FrmTXA09Hist
  Public MyFrmTXA09Adj As FrmTXA09Adj
  Public MyFrmTXA09Fees As FrmTXA09Fees
  Public MyFrmTXA09H As FrmTXA09H
  Public MyFrmTXA09CC As FrmTXA09CC
  Public MyFrmTXA09CCUB As FrmTXA09CCUB
  Public MyFrmTXA09Total As FrmTXA09Total
  Public MyFrmTXA09Stat As FrmTXA09Stat
  Public MyFrmTXA09UBA As FrmTXA09UBA
  Public MyFrmSelTypes As FrmSelTypes
  Public MyFrmSelYear As FrmSelYear
  Public MyFrmSettings As FrmSettings
  Public MyFrmWeb As FrmWeb
  Public MyFrmWebView As FrmWebView
  Public Const MyBatch As String = "P"
  Public MyBatchNo As Long
  Public MyInterestDate As Date
  Public MyInterestOverrideDate As Date
  Public MyInquiryMode As Boolean
  Public MyInquiryAssr As Boolean
  Public MyPublicUser As Boolean
  Public MyReceiptDate As Date
  Public MyValidation As Boolean
  Public MyEndorseMe As Boolean
  Public MyDupBillCombinedRU As Boolean 'Duplicate Bills - Combined R & U types
  Public MyAllowChange As Boolean 'Allow change back on checks
  Public MyPrinterLandscape As Boolean
  Public MyReceiptPrinted As Boolean
  Public MyRefundBatch As Boolean
  Public MyLastCheckNo As String
  Public MyLastComment As String
  Public MyLastCommentRefund As String
  Public MyEndorseType As String
  Public MyCheckAmount As Decimal
  Public MyCheckSort As String
  Public MyFrmComments As FrmComments
  Public MySelTypes As String
  Public MySelFromYear As Integer
  Public MySelToYear As Integer
  Public MyCustomDir As String
  Public MyTXGL As Boolean
  Public MyPayCredit As Boolean
  Public MyBalTotal As Boolean
  Public MydsPayCredit As DataSet
  Public MydsGroupItems As DataSet
  Public MyWarrantFee As Decimal
  Public MyMVFee As Decimal
  Public MyFastPathBal As Boolean
  Public MyInvDetail As Boolean
  Public MyScanOnly As Boolean
  Public MyAppConfig As AppConfig
  Public MyAppSettings As AppSettings
  Public MyWebBrowser As Boolean
  Public cLightBlue As Color = Color.FromArgb(212, 242, 246)
  Sub Main()
    Dim TestCmd() As String
    StartUp()
    'Parms: 
    '1 - database name
    '2 - user id
    '3 - "Inquiry" if inquiry mode or blank for normal register  
    TestCmd = GetCommandLineArgs()
    If UBound(TestCmd) > 1 Then
      If LCase(Trim(TestCmd(2))) = "inquiry" Then
        MyInquiryMode = True
      End If
    End If

    MySelTypes = ""
    MySelFromYear = 0
    MySelToYear = 0
    MyInquiryAssr = False
    If MyInquiryMode Then
      GetSecurity("TXA10", False) 'Collector
      If Not s_sec Then
        GetSecurity("TAA01") 'Assessor
        MyInquiryAssr = True
      End If
    Else
      GetSecurity()
    End If
    If InStr(s_rights, "PB:") > 0 Then MyPublicUser = True
    GetTXMVFee()
    MyServer = UCase(myDBConnect.ServerName)
    MyDupBillCombinedRU = GetGNET("BILRU")
    MyAllowChange = GetGNET("CHGBK")
    MyCustomDir = GetGNETValue("RPTSD")
    MyTXGL = GetGNET("TXGL")
    MyPayCredit = GetGNET("PAYCR")
    MyWarrantFee = 6
    MyBalTotal = GetGNET("BALTL")
    MyFastPathBal = GetGNET("FPBAL")
    MyInvDetail = GetGNET("INVDL")
    GetAppConfig()
    GetAppSettings()

#If Not DEBUG Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTXA09 = New FrmTXA09
    Application.Run(MyFrmTXA09)
  End Sub
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
  Public Sub GetAppConfig()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppConfig))
    Dim sr As IO.StreamReader
    Dim WrkXMLPath As String
    Dim WrkProgName As String
    Dim WrkFileExists As Boolean

    MyWebBrowser = False
    WrkProgName = "A_Config"
    WrkXMLPath = IO.Path.Combine(MyUtils.GetDataPath(), "Settings\" & WrkProgName & ".xml")
    WrkFileExists = MyUtils.CheckFileExists(WrkXMLPath)
    If WrkFileExists Then
      sr = New IO.StreamReader(WrkXMLPath)
      MyAppConfig = New AppConfig
      MyAppConfig = CType(xs.Deserialize(sr), AppConfig)
      sr.Close()
    Else
      MyAppConfig = New AppConfig
    End If
    If MyAppConfig.WebName = MyUtils.GetComputerName.ToUpper Then
      MyWebBrowser = True
    End If
  End Sub
  Public Sub GetAppSettings()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sr As IO.StreamReader
    Dim WrkXMLPath As String
    Dim WrkProgName As String
    Dim WrkFileExists As Boolean

    WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
    If MyWebBrowser Then
      WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & " " & Environment.UserName & ".xml"
    Else
      WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & " " & MyUtils.GetComputerName() & ".xml"
    End If
    WrkFileExists = MyUtils.CheckFileExists(WrkXMLPath)

    If WrkFileExists Then
      sr = New IO.StreamReader(WrkXMLPath)
      MyAppSettings = New AppSettings
      Try
        MyAppSettings = CType(xs.Deserialize(sr), AppSettings)
      Catch
        MsgBox("Check file or delete it to reset - " & WrkXMLPath, MsgBoxStyle.Information, "Error Reading Settings")
      End Try
      sr.Close()
    Else
      MyAppSettings = New AppSettings
    End If
  End Sub
  Public Function GetTXCodeDesc(ByVal Code As Integer, ByVal Type As String) As String
    Dim myTXCODE As TXCODE.MyData

    myTXCODE = New TXCODE.MyData(myDBConnect)
    If IsNothing(Code) Or Code = 0 Then
      Return ""
    End If

    myTXCODE.GetOneRecordP(Code, Type)
    If Not myTXCODE.RecordNotFound Then
      GetTXCodeDesc = Trim(myTXCODE._TCDESC)
    Else
      GetTXCodeDesc = "*** Unknown ***"
    End If
    myTXCODE.CloseFile()
    myTXCODE = Nothing
    Return GetTXCodeDesc

  End Function
  Public Function GetTXTypeDesc(ByVal Code As String) As String
    Dim myTXTYPE As TXTYPE.MyData

    myTXTYPE = New TXTYPE.MyData(myDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myTXTYPE.GetOneRecordP(Code)
    If Not myTXTYPE.RecordNotFound Then
      GetTXTypeDesc = Trim(myTXTYPE._TYDESC)
    Else
      GetTXTypeDesc = "*** Unknown ***"
    End If
    myTXTYPE.CloseFile()
    myTXTYPE = Nothing
    Return GetTXTypeDesc

  End Function
  Public Function GetTXTypeFamily(ByVal Code As String) As String
    Dim myTXTYPE As TXTYPE.MyData

    myTXTYPE = New TXTYPE.MyData(myDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myTXTYPE.GetOneRecordP(Code)
    If Not myTXTYPE.RecordNotFound Then
      GetTXTypeFamily = Trim(myTXTYPE._TXFAM)
    Else
      GetTXTypeFamily = "*** Unknown ***"
    End If
    myTXTYPE.CloseFile()
    myTXTYPE = Nothing
    Return GetTXTypeFamily

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
    myGNET.CloseFile()
    myGNET = Nothing
    Return GetGNETValue

  End Function
  Public Function GetTXMVPCT(ByVal Type As String, ByVal Code As String) As String()
    Dim Wrkstr(1) As String
    Dim myTXMVPCT As TXMVPCT.MyData

    myTXMVPCT = New TXMVPCT.MyData(myDBConnect)
    If IsNothing(Code) Then
      Return Wrkstr
    End If

    myTXMVPCT.GetOneRecordP(Type, Code)
    If Not myTXMVPCT.RecordNotFound Then
      With myTXMVPCT
        Wrkstr(0) = Format(._PCT, ".000")
        Wrkstr(1) = ._MONTH
      End With
    Else
      Wrkstr(1) = "*** Unknown ***"
    End If
    Return Wrkstr

  End Function
  Public Function GetTXSupCd(ByVal Code As String) As String()
    Dim Wrkstr(2) As String
    Dim myTXSUPCD As TXSUPCD.MyData

    myTXSUPCD = New TXSUPCD.MyData(myDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Wrkstr(0) = ""
      Wrkstr(1) = ""
      Wrkstr(2) = ""
      Return Wrkstr
    End If

    myTXSUPCD.GetOneRecordP(Code)
    If Not myTXSUPCD.RecordNotFound Then
      Wrkstr(0) = Format(myTXSUPCD._SPCT, ".000")
      Wrkstr(1) = Trim(myTXSUPCD._SMON)
      Wrkstr(2) = Trim(myTXSUPCD._SCRD)
    Else
      Wrkstr(1) = "*** Unknown ***"
    End If
    Return Wrkstr

  End Function
End Module






