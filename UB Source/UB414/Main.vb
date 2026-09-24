Module Main
    Public MyFrmUB414 As FrmUB414
    Public MyFrmUB414B As FrmUB414B
    Public MyFrmListUBType_Tax As FrmListUBType_Tax
    Public MyCrViewer As FrmCrViewer
    Public DataPath As String
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmUB414 = New FrmUB414
    Application.Run(MyFrmUB414)
   End Sub
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
       GetUTTypeUBType = myUTType._TYUTTP
     Else
       GetUTTypeUBType = "*** Unknown ***"
     End If
     Return GetUTTypeUBType

  End Function


End Module






