Module Main
  Public MyFrmCrViewer As FrmCrViewer
  Public MyFrmUB501 As FrmUB501
  Public MyFrmUB501B As FrmUB501B
  Public MyFrmUB501C As FrmUB501C
  Public MyFrmUB501_NEW As FrmUB501_NEW
  Public MyFrmListAdjHist As FrmListAdjHist
  Public MyFrmListCResn As FrmListCResn
  Public MyFrmListInv As FrmListInv
  Public MyFrmListUBType_Tax As FrmListUBType_Tax
  Public MyFrmPrinters As FrmPrinters
  Public MyAppSettings As AppSettings
  Sub Main()
    StartUp()
    GetSecurity()  '#sec
    GetAppSettings()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmUB501 = New FrmUB501
    Application.Run(MyFrmUB501)
  End Sub
  Public Function GetUTCRESNDesc(ByVal Code As String) As String
     Dim myUTCRESN As UTCRESN.myData

     myUTCRESN = New UTCRESN.mydata(MyDBConnect)
     If IsNothing(Code) Or Code = "" Then
       Return ""
     End If

     myUTCRESN.GetOneRecordP(Code)
     If Not myUTCRESN.RecordNotFound Then
       GetUTCRESNDesc = Trim(myUTCRESN._CRDESC)
     Else
       GetUTCRESNDesc = "*** Unknown ***"
     End If
     Return GetUTCRESNDesc

  End Function
  Public Function CheckCCDate(ByVal pDate As Date, ByVal WrkType As String, _
    ByVal WrkYear As Integer, ByVal WrkPhs As String, ByVal WrkDist As Integer) As Date
		 Dim myTXPROF As TXPROF.myData
		 Dim WrkDate As Date
     Dim WrkDueDate1 As Date

		 myTXPROF = New TXPROF.mydata(MyDBConnect)
     If IsNothing(pDate) Then
       Return pDate
     End If

		 myTXPROF.GetOneRecordP(WrkType, WrkYear, WrkPhs, WrkDist)
		 If myTXPROF.RecordNotFound Then
			 Return WrkDate	'default date variable
		 End If

     WrkDate = pDate
		 With myTXPROF
       WrkDueDate1 = MyUtils.GetDBDateMDY(._PRDUE1)
       If WrkDate < MyUtils.GetDBDateMDY(._PRDUE1) Then
         WrkDate = WrkDueDate1
       End If
		 End With

     Return WrkDate
  End Function
  Public Function GetUTTypeDesc(ByVal TaxType As String) As String
    Dim myUTType As UTTYPE.MyData

    myUTType = New UTTYPE.MyData(myDBConnect)
    If IsNothing(TaxType) Or TaxType = "" Then
      Return ""
    End If

    myUTType.GetOneRecordP(TaxType)
    If Not myUTType.RecordNotFound Then
      GetUTTypeDesc = Trim(myUTType._TYDESC)
    Else
      GetUTTypeDesc = "*** Unknown ***"
    End If
    Return GetUTTypeDesc

  End Function
  Public Function GetUTTypeUBType(ByVal TaxType As String) As String
    Dim myUTType As UTTYPE.MyData

    myUTType = New UTTYPE.MyData(myDBConnect)
    If IsNothing(TaxType) Or TaxType = "" Then
      Return ""
    End If

    myUTType.GetOneRecordP(TaxType)
    If Not myUTType.RecordNotFound Then
      GetUTTypeUBType = Trim(myUTType._TYUTTP)
    Else
      GetUTTypeUBType = "*** Unknown ***"
    End If
    Return GetUTTypeUBType

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






