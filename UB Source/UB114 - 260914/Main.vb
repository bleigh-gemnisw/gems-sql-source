Module Main
  Public MyFrmUB114 As FrmUB114
  Public MyFrmUB114B As FrmUB114B
  Public MyFrmUB114C As FrmUB114C
  Public MyFrmListMResn As FrmListMResn
  Sub Main()
    StartUp()
    GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmUB114 = New FrmUB114
    Application.Run(MyFrmUB114)
  End Sub
Public Function RecalcDedDiff(ByVal WrkListNo As Integer, ByVal WrkMeterNo As String, ByVal WrkDate As Integer, _
  ByVal WrkReading As Integer) As Integer
  Dim myUTDEDDIFF As UTDEDDIFF.MyData
  Dim dsUTDEDDIFF As DataSet = New DataSet
  Dim WrkDiff As Integer

  myUTDEDDIFF = New UTDEDDIFF.MyData(MyDBConnect)
  dsUTDEDDIFF = myUTDEDDIFF.GetLastbyDate(WrkListNo, WrkMeterNo, WrkDate - 1)
  If dsUTDEDDIFF Is Nothing OrElse dsUTDEDDIFF.Tables(0).Rows.Count = 0 Then Return 0

  WrkDiff = WrkReading - dsUTDEDDIFF.Tables(0).Rows(0).Item("ddread")
  If WrkDiff < 0 Then WrkDiff = 0
  Return WrkDiff
End Function
  Public Function GetUTMRESNDesc(ByVal Code As String) As String
     Dim myUTMRESN As UTMRESN.myData

     myUTMRESN = New UTMRESN.mydata(MyDBConnect)
     If IsNothing(Code) Or Code = "" Then
       Return ""
     End If

     myUTMRESN.GetOneRecordP(Code)
     If Not myUTMRESN.RecordNotFound Then
       GetUTMRESNDesc = Trim(myUTMRESN._MRDESC)
     Else
       GetUTMRESNDesc = "*** Unknown ***"
     End If
     Return GetUTMRESNDesc

  End Function
End Module






