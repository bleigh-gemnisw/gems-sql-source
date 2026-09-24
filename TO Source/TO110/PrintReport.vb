Imports System.IO
Imports System.Text
Module PrintReport
  Dim myTXOPM As TXOPM.myData
  Public WrkTown As String
  Public WrkAssrPhone As String
  Public WrkCollPhone As String
  Public WrkAssrEmail As String
  Public WrkCollEmail As String
Public Sub PrtReport()

    myTXOPM = New TXOPM.mydata(MyDBConnect)
    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
      dsCatB.Clear()
      dsCatC.Clear()
      dsErr.Clear()
    End If

    MyCurAccts = 0
    MyPrvAccts = 0
    MyMVAccts = 0
    MyCurAmt = 0
    MyPrvAmt = 0
    MyMVAmt = 0
    MyCurRevLoss = 0
    MyMVRevLoss = 0
    MyPrvRevLoss = 0

    BufferExem()
    PrtReportRE()
    PrtReportMV()
    PrtReportSU()
    PrtReportPP()
    GetOPMAssr()
    GetOPMColl()

    'Combine to create All Categories
    ds.Merge(dsCatB)
    ds.Merge(dsCatC)

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .WrkdsCatB = dsCatB
      .WrkdsCatC = dsCatC
      .WrkdsErr = dsErr
      .WrkCurMillRt = CurMillrt * 1000
      .WrkMVMillRt = MVMillrt * 1000
      .WrkPrvMillRt = PrvMillrt * 1000
      .Show()
    End With
End Sub
Public Sub GetOPMAssr()

  Dim sb As StringBuilder = New StringBuilder

  WrkAssrPhone = ""
  WrkAssrEmail = ""
  WrkTown = ""
  myTXOPM.GetOneRecordP("A")
  If myTXOPM.RecordNotFound Then Exit Sub

  WrkAssrPhone = Format(myTXOPM._PHONE, "###-###-####")
  If myTXOPM._PHONEX > 0 Then
    WrkAssrPhone = WrkAssrPhone & " ext " & myTXOPM._PHONEX
  End If

  sb.Append(Trim(myTOWN._TOWN))
  sb.Append(",")
  sb.Append(Trim(myTXOPM._ADDR1))
  sb.Append(",")
  sb.Append(Trim(myTXOPM._CITY))
  sb.Append(",")
  sb.Append(Trim(myTXOPM._STATE))
  sb.Append(" ")
  sb.Append(Format(myTXOPM._ZIP, "00000"))
  If myTXOPM._ZIP4 > 0 Then
    sb.Append("-")
    sb.Append(Format(myTXOPM._ZIP4, "0000"))
  End If
  WrkAssrEmail = Trim(myTXOPM._EMAIL)
  WrkTown = sb.ToString
  sb = Nothing

End Sub
Public Sub GetOPMColl()

  Dim sb As StringBuilder = New StringBuilder

  WrkCollPhone = ""
  WrkCollEmail = ""
  myTXOPM.GetOneRecordP("C")
  If myTXOPM.RecordNotFound Then Exit Sub

  WrkCollPhone = Format(myTXOPM._PHONE, "###-###-####")
  If myTXOPM._PHONEX > 0 Then
    WrkCollPhone = WrkAssrPhone & " ext " & myTXOPM._PHONEX
  End If
  WrkCollEmail = Trim(myTXOPM._EMAIL)
End Sub
End Module






