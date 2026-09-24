'TXINV: Update BALD: BONDP: BONT: FEC1: FED1: FEC2: FED2: FEC3: FED3:
'TXINV: Update FEC4: FED4: FEC5: FED5: ICODE: INTPD: LIEN: LNPD: 
'TXINV: Update MVFLAG: NEWPAY: PAYREC: PRINT: PRLIN: TXIDT:
'TXHST: Add
Module Main
    Public MyFrmCr_PrtEdits As FrmCr_PrtEdits
    Public MyFrmTXA01 As FrmTXA01
    Public MyFrmTXA01B As FrmTXA01B
    Public MyFrmTXA01B_New As FrmTXA01B_New
    Public MyFrmTXA01C As FrmTXA01C
    Public MyFrmTXA01D As FrmTXA01D
    Public MyFrmListInv As FrmListInv
    Public MyFrmListPenCd As FrmListPenCd
    Public MyBatch As String
    Public MyMVFee As Decimal
    Public MyReportLandscape As Boolean
    Public MyAppSettings As AppSettings
   Sub Main()
    StartUp()
    GetSecurity()
    GetTXMVFee()
    GetAppSettings()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTXA01 = New FrmTXA01
    Application.Run(MyFrmTXA01)
   End Sub
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
Public Function GetGNET(ByVal Code As String) As Boolean
   Dim myGNET As GNET.myData

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
    Return GetGNET

End Function
  Public Function GetBatchTypeDesc(ByVal BatchType As String) As String

    GetBatchTypeDesc = String.Empty
    Select Case BatchType
      Case "B"
        GetBatchTypeDesc = "Lock Box"
      Case "E"
        GetBatchTypeDesc = "Escrow"
      Case "G"
        GetBatchTypeDesc = "Leasing"
      Case "K"
        GetBatchTypeDesc = "Bank Service"
      Case "M"
        GetBatchTypeDesc = "Misc/Penny Batch"
      Case "W"
        GetBatchTypeDesc = "Web Payments"
    End Select

    Return GetBatchTypeDesc
  End Function
  Private Sub GetTXMVFee()
  Dim myTXMVFEE As TXMVFEE.myData
  myTXMVFEE = New TXMVFEE.mydata(MyDBConnect)
  myTXMVFEE.GetOneRecordP(1)
  If Not myTXMVFEE.RecordNotFound Then
   MyMVFee = myTXMVFEE._MVFEE
  End If
  myTXMVFEE.CloseFile()
  myTXMVFEE = Nothing
 End Sub
End Module






