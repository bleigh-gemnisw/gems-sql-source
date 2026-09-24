Module Main
  Public MyFrmUB107 As FrmUB107
  Public MyFrmUB107B As FrmUB107B
  Public MyFrmUB107C As FrmUB107C
  Public MyFrmListMResn As FrmListMResn
  Sub Main()
    StartUp()
    GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmUB107 = New FrmUB107
    Application.Run(MyFrmUB107)
  End Sub
Public Function RecalcUsage(ByVal WrkListNo As Integer, ByVal WrkType As String, ByVal WrkDate As Integer, _
  ByVal WrkReading As Integer) As Integer
  Dim myUTCUSTMT As UTCUSTMT.myData
  Dim dsUTCUSTMT As DataSet = New DataSet
  Dim WrkUsage As Integer

  myUTCUSTMT = New UTCUSTMT.mydata(MyDBConnect)
  dsUTCUSTMT = myUTCUSTMT.GetLastbyDate(WrkListNo, WrkType, WrkDate - 1)
  If dsUTCUSTMT.Tables(0).Rows.Count = 0 Then Return 0

  WrkUsage = WrkReading - dsUTCUSTMT.Tables(0).Rows(0).Item("cmread")
  If WrkUsage < 0 Then WrkUsage = 0
  Return WrkUsage
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






