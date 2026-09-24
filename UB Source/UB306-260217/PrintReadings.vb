Imports System.io
Imports System.Text
Module PrintReadings

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer

  Dim myUTCUST As UTCUST.MyData
  Dim myUTCUSTL3 As UTCUSTL3.MyData
  Dim myUTCUSTMT As UTCUSTMT.MyData
  Dim myUTCUSTMTD As UTCUSTMTD.MyData
  Dim myUTXREFL1 As UTXREFL1.MyData
  Dim myUTCUSTQ As UTCUSTQ.MyData

  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim DsUTXREFL1 As DataSet = New DataSet
  Dim DsUTCUSTL3 As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim drSel() As Data.DataRow

  Dim WrkUBType As String
  Dim WrkReadDateQ1 As Date
  Dim WrkCompany As String
  Dim WrkPost As Boolean
  Dim WrkEDU As Boolean
  Dim WrkReadDate1 As Date
  Dim WrkReadDate2 As Date
  Dim WrkReadDate3 As Date
  Dim WrkReadDate4 As Date
  Dim WrkAnd As String
  Dim WrkOr As String

  Public Sub PrtReadings()

    myUTCUST = New UTCUST.MyData(myDBConnect)
    myUTCUSTL3 = New UTCUSTL3.MyData(myDBConnect)
    myUTCUSTMT = New UTCUSTMT.MyData(myDBConnect)
    myUTCUSTMTD = New UTCUSTMTD.MyData(myDBConnect)
    myUTCUSTQ = New UTCUSTQ.MyData(myDBConnect)
    myUTXREFL1 = New UTXREFL1.MyData(myDBConnect)

    With MyFrmUB306B
      WrkUBType = .TxtUBType.Text
      WrkReadDateQ1 = .DtPckRead.Value
      If .RbAquarion.Checked Then WrkCompany = "Aquarion"
      If .RbRegional.Checked Then WrkCompany = "Regional"
      If .RbCTWater.Checked Then WrkCompany = "CTWater"
      If .RbOther.Checked Then WrkCompany = "Other"
      WrkPost = .ChkPost.Checked
      WrkEDU = .ChkEDU.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDs(ds, ds2)
    Else
      ds.Clear()
      ds2.Clear()
    End If

    If WrkCompany <> "Other" Then
      WrkReadDate1 = WrkReadDateQ1
      WrkReadDate2 = DateAdd(DateInterval.Month, 3, WrkReadDate1)
      WrkReadDate3 = DateAdd(DateInterval.Month, 3, WrkReadDate2)
      WrkReadDate4 = DateAdd(DateInterval.Month, 3, WrkReadDate3)
    End If
    If MyFrmUB306B.LblFilePath1.Text <> String.Empty Then
      GetDetail(MyFrmUB306B.LblFilePath1.Text, WrkReadDate1, 1)
    End If
    If MyFrmUB306B.LblFilePath2.Text <> String.Empty Then
      GetDetail(MyFrmUB306B.LblFilePath2.Text, WrkReadDate2, 2)
    End If
    If MyFrmUB306B.LblFilePath3.Text <> String.Empty Then
      GetDetail(MyFrmUB306B.LblFilePath3.Text, WrkReadDate3, 3)
    End If
    If MyFrmUB306B.LblFilePath4.Text <> String.Empty Then
      GetDetail(MyFrmUB306B.LblFilePath4.Text, WrkReadDate4, 4)
    End If
    If WrkEDU And WrkCompany = "CTWater" Then
      WriteEdu()
    End If

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .wrkds2 = ds2
      .WrkCompany = WrkCompany
      .WrkReadDate1 = WrkReadDate1
      .WrkReadDate2 = WrkReadDate2
      .WrkReadDate3 = WrkReadDate3
      .WrkReadDate4 = WrkReadDate4
      .WrkPost = WrkPost
      .Show()
    End With

  End Sub
  Private Sub GetDetail(ByVal WrkFile As String, ByVal WrkReadDate As Date, ByVal WrkQtr As Integer)
    Dim WrkStream As FileStream = New FileStream(WrkFile, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim sArray() As String
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim WrkXref As String
    Dim WrkAcct As Integer
    Dim WrkName As String
    Dim WrkLocation As String
    Dim WrkReading As Integer
    Dim WrkReading2 As Integer
    Dim WrkReading3 As Integer
    Dim WrkReading4 As Integer
    Dim WrkGals As Integer
    Dim SaveXref As String

    myFrmProgress = New FrmProgress
    If WrkQtr = 1 Then
      myFrmProgress.Text = "Creating Report...Annual or Quarter " & WrkQtr
    Else
      myFrmProgress.Text = "Creating Report...Quarter " & WrkQtr
    End If
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    SavePct = 0

    WrkFileSize = WrkStream.Length
    WrkXref = ""
    WrkName = ""
    WrkLocation = ""
    SaveXref = ""
    If WrkCompany = "Other" Then 'Skip Heading
      strBuffer = sr.ReadLine
    End If

NextLine:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo Cleanup
    End If
    I = I + strBuffer.Length

    WrkAcct = 0

    Select Case WrkCompany
      Case "Regional"
        WrkName = Trim(Mid(strBuffer, 109, 30)) & " " & Trim(Mid(strBuffer, 189, 30))
        WrkLocation = Mid(strBuffer, 29, 30)
        WrkXref = MyUtils.CnvSng(Mid(strBuffer, 1, 8))
        WrkReading = MyUtils.CnvSng(Mid(strBuffer, 407, 10))
        ProcAcct(WrkXref, WrkQtr, WrkReadDate, WrkReading, WrkName, WrkLocation)
      Case "Aquarion"
        sArray = Parse(strBuffer, ",")
        WrkXref = MyUtils.CnvSng(sArray(5))
        If SaveXref <> "" And WrkXref <> SaveXref Then
          ProcAcct(SaveXref, WrkQtr, WrkReadDate, WrkReading, WrkName, WrkLocation)
          WrkReading = 0
        End If
        SaveXref = WrkXref
        WrkName = sArray(1)
        WrkLocation = sArray(6) & " " & sArray(7)
        If Trim(sArray(27)) <> "A" And Trim(sArray(27)) <> "F" Then
          WrkGals = MyUtils.Round(MyUtils.CnvSng(sArray(21) * 100) * 7.4805, 0)
          WrkReading = WrkReading + WrkGals
        End If
      Case "CTWater"
        WrkName = Trim(Mid(strBuffer, 21, 30))
        WrkLocation = Mid(strBuffer, 111, 22)
        WrkXref = MyUtils.CnvSng(Mid(strBuffer, 133, 8))
        WrkReading = MyUtils.CnvSng(Mid(strBuffer, 174, 6))
        WrkReading2 = MyUtils.CnvSng(Mid(strBuffer, 180, 6))
        WrkReading3 = MyUtils.CnvSng(Mid(strBuffer, 186, 6))
        WrkReading4 = MyUtils.CnvSng(Mid(strBuffer, 192, 6))
        If Not WrkEDU Then
          ProcAnnual(WrkXref, WrkReading, WrkReading2, WrkReading3, WrkReading4, WrkName, WrkLocation)
        End If
      Case "Other"
        Select Case myTOWN._TOWNBR
          Case = 280 'Norfolk
            strBuffer = Replace(strBuffer, " 001", "")
            sArray = Parse(strBuffer, ",")
            WrkXref = sArray(0) 'Water Customer Number
            WrkName = sArray(1)
            WrkLocation = sArray(2)
            DsUTXREFL1 = myUTXREFL1.GetXRef(WrkXref)
            If DsUTXREFL1.Tables(0).Rows.Count = 0 Then 'If no xref found, use meter number instead
              WrkXref = sArray(3)
              If WrkXref = "MULTIPLE" Then
                WrkXref = sArray(6)
              End If
              If WrkXref = "MULTIPLE" Then
                WrkXref = sArray(9)
              End If
              If WrkXref = "MULTIPLE" Then
                WrkXref = sArray(12)
              End If
            End If
            WrkXref = MyUtils.CnvSng(WrkXref)
            WrkReading = MyUtils.CnvSng(sArray(4))
            WrkReading2 = MyUtils.CnvSng(sArray(7))
            WrkReading3 = MyUtils.CnvSng(sArray(10))
            WrkReading4 = MyUtils.CnvSng(sArray(13))
            If WrkReading > 0 Then
              WrkReadDate1 = sArray(5)
            End If
            If WrkReading2 > 0 Then
              WrkReadDate2 = sArray(8)
            End If
            If WrkReading3 > 0 Then
              WrkReadDate3 = sArray(11)
            End If
            If WrkReading4 > 0 Then
              WrkReadDate4 = sArray(14)
            End If
            ProcAnnual(WrkXref, WrkReading, WrkReading2, WrkReading3, WrkReading4, WrkName, WrkLocation)
          Case Else
        End Select
    End Select

NextRec:
    With myFrmProgress
      WrkPct = (I / WrkFileSize) * 100
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo NextLine

Cleanup:
    sr.Close()
    myFrmProgress.Close()
    If WrkCompany = "Aquarion" Then
      ProcAcct(WrkXref, WrkQtr, WrkReadDate, WrkReading, WrkName, WrkLocation)
    End If
    If WrkPost And WrkCompany = "CTWater" Then
      WriteEdu()
    End If
  End Sub
  Private Sub ProcAcct(ByVal SaveXref As String, ByVal WrkQtr As Integer, ByVal WrkReadDate As Date,
  ByVal WrkReading As Integer, ByVal WrkName As String, ByVal WrkLocation As String)
    Dim WrkAcct As Integer
    Dim Found As Boolean
    DsUTXREFL1 = myUTXREFL1.GetXRef(SaveXref)
    If DsUTXREFL1.Tables(0).Rows.Count > 0 Then
      WrkAcct = DsUTXREFL1.Tables(0).Rows(0).Item("cxacct")
    Else
      DsUTCUSTL3 = myUTCUSTL3.GetViewbyMeterNo(SaveXref)
      If DsUTCUSTL3.Tables(0).Rows.Count > 0 Then
        WrkAcct = DsUTCUSTL3.Tables(0).Rows(0).Item("cuacct")
      End If
    End If

    If WrkAcct = 0 Then
      If WrkQtr > 1 Then
        drSel = ds2.Tables(0).Select("xref = " & SaveXref)
        If drSel.Length > 0 Then
          Select Case WrkQtr
            Case 2
              drSel(0)("reading3") = WrkReading
              Exit Sub
            Case 3
              drSel(0)("reading6") = WrkReading
              Exit Sub
            Case 4
              drSel(0)("reading9") = WrkReading
              Exit Sub
          End Select
        End If
      End If

      dr = ds2.Tables(0).NewRow
      dr.Item("xref") = SaveXref
      dr.Item("listno") = 0
      dr.Item("name") = WrkName
      dr.Item("location") = WrkLocation
      Select Case WrkQtr
        Case 1
          dr.Item("reading") = WrkReading
          dr.Item("reading3") = 0
          dr.Item("reading6") = 0
          dr.Item("reading9") = 0
        Case 2
          dr.Item("reading") = 0
          dr.Item("reading3") = WrkReading
          dr.Item("reading6") = 0
          dr.Item("reading9") = 0
        Case 3
          dr.Item("reading") = 0
          dr.Item("reading3") = 0
          dr.Item("reading6") = WrkReading
          dr.Item("reading9") = 0
        Case 4
          dr.Item("reading") = 0
          dr.Item("reading3") = 0
          dr.Item("reading6") = 0
          dr.Item("reading9") = WrkReading
      End Select
      ds2.Tables(0).Rows.Add(dr)
      dr = Nothing
      Exit Sub
    End If

    Found = False
    If WrkQtr > 1 Then
      drSel = ds.Tables(0).Select("xref = " & SaveXref)
      If drSel.Length > 0 Then
        Select Case WrkQtr
          Case 2
            drSel(0)("reading3") = WrkReading
            Found = True
          Case 3
            drSel(0)("reading6") = WrkReading
            Found = True
          Case 4
            drSel(0)("reading9") = WrkReading
            Found = True
        End Select
      End If
    End If

    If Not Found Then
      myUTCUST.GetOneRecordP(WrkAcct)
      'MK 7/17/25 Begin
      If myUTCUST._RCODE = "I" Then
        Exit Sub
      End If
      'MK 7/17/25 End
      dr = ds.Tables(0).NewRow
      dr.Item("xref") = SaveXref
      dr.Item("listno") = WrkAcct
      dr.Item("name") = WrkName
      dr.Item("location") = WrkLocation
      dr.Item("propcat") = myUTCUST._CUPCAT
      Select Case WrkQtr
        Case 1
          dr.Item("reading") = WrkReading
          dr.Item("reading3") = 0
          dr.Item("reading6") = 0
          dr.Item("reading9") = 0
        Case 2
          dr.Item("reading") = 0
          dr.Item("reading3") = WrkReading
          dr.Item("reading6") = 0
          dr.Item("reading9") = 0
        Case 3
          dr.Item("reading") = 0
          dr.Item("reading3") = 0
          dr.Item("reading6") = WrkReading
          dr.Item("reading9") = 0
        Case 4
          dr.Item("reading") = 0
          dr.Item("reading3") = 0
          dr.Item("reading6") = 0
          dr.Item("reading9") = WrkReading
      End Select
      ds.Tables(0).Rows.Add(dr)
      dr = Nothing
    End If

    WriteReading(WrkAcct, "", WrkReadDate, WrkReading, WrkPost)
  End Sub
  Private Sub ProcAnnual(ByVal SaveXref As String, ByVal WrkReading1 As Integer, ByVal WrkReading2 As Integer,
   ByVal WrkReading3 As Integer, ByVal WrkReading4 As Integer, ByVal WrkName As String, ByVal WrkLocation As String)
    Dim WrkAcct As Integer
    Dim WrkUse As String
    WrkUse = ""
    DsUTXREFL1 = myUTXREFL1.GetXRef(SaveXref)
    If DsUTXREFL1.Tables(0).Rows.Count > 0 Then
      WrkAcct = DsUTXREFL1.Tables(0).Rows(0).Item("cxacct")
      WrkUse = Trim(DsUTXREFL1.Tables(0).Rows(0).Item("cxuse"))
    Else
      DsUTCUSTL3 = myUTCUSTL3.GetViewbyMeterNo(SaveXref)
      If DsUTCUSTL3.Tables(0).Rows.Count > 0 Then
        WrkAcct = DsUTCUSTL3.Tables(0).Rows(0).Item("cuacct")
      End If
    End If

    If WrkAcct = 0 Then
      If SaveXref = "0" Then
        dr = ds2.Tables(0).NewRow
        dr.Item("xref") = SaveXref
        dr.Item("listno") = 0
        dr.Item("name") = WrkName
        dr.Item("location") = WrkLocation
        dr.Item("propcat") = ""
        dr.Item("reading") = 0
        dr.Item("reading3") = 0
        dr.Item("reading6") = 0
        dr.Item("reading9") = 0
        ds2.Tables(0).Rows.Add(dr)
      End If
      Exit Sub
    Else
      myUTCUST.GetOneRecordP(WrkAcct)
      'MK 7/17/25 Begin
      If myUTCUST._RCODE = "I" Then
        Exit Sub
      End If
      'MK 7/17/25 End
      dr = ds.Tables(0).NewRow
      dr.Item("xref") = SaveXref
      dr.Item("listno") = WrkAcct
      dr.Item("name") = WrkName
      dr.Item("location") = WrkLocation
      dr.Item("propcat") = myUTCUST._CUPCAT
      dr.Item("reading") = WrkReading1
      dr.Item("reading3") = WrkReading2
      dr.Item("reading6") = WrkReading3
      dr.Item("reading9") = WrkReading4
      ds.Tables(0).Rows.Add(dr)
    End If

    WriteReading(WrkAcct, WrkUse, WrkReadDate1, WrkReading1, WrkPost)
    WriteReading(WrkAcct, WrkUse, WrkReadDate2, WrkReading2, WrkPost)
    WriteReading(WrkAcct, WrkUse, WrkReadDate3, WrkReading3, WrkPost)
    WriteReading(WrkAcct, WrkUse, WrkReadDate4, WrkReading4, WrkPost)
    If Trim(myUTCUST._CUPCAT) = "COM" Then
      WriteReadingDtl(WrkAcct, SaveXref, WrkUse, WrkReadDate1, WrkReading1, WrkName, WrkLocation, WrkPost)
      WriteReadingDtl(WrkAcct, SaveXref, WrkUse, WrkReadDate2, WrkReading2, WrkName, WrkLocation, WrkPost)
      WriteReadingDtl(WrkAcct, SaveXref, WrkUse, WrkReadDate3, WrkReading3, WrkName, WrkLocation, WrkPost)
      WriteReadingDtl(WrkAcct, SaveXref, WrkUse, WrkReadDate4, WrkReading4, WrkName, WrkLocation, WrkPost)
    End If
  End Sub



  Private Sub WriteReading(ByVal WrkAcct As Integer, ByVal WrkUse As String, ByVal WrkReadDate As Date,
  ByVal WrkReading As Integer, ByVal WrkPost As Boolean)
    Dim UBType As String

    UBType = ""
    If Not WrkPost Then Exit Sub
    myUTCUSTMT.GetOneRecordP(WrkAcct, UBType, MyUtils.SetDBDate(WrkReadDate))
    With myUTCUSTMT
      If Not .RecordNotFound Then
        Select Case WrkUse
          Case "D"
            ._CMREAD = ._CMREAD - WrkReading
            ._CMUSE = ._CMUSE - WrkReading
          Case "N"
            ._CMREAD = ._CMREAD + WrkReading
          Case Else
            ._CMREAD = ._CMREAD + WrkReading
            ._CMUSE = ._CMUSE + WrkReading
        End Select
        .UpdateOneRecordP()
      Else
        ._CMACCT = WrkAcct
        ._CMTYPE = UBType
        ._CMDATE = MyUtils.SetDBDate(WrkReadDate)
        ._CMREAD = WrkReading
        Select Case WrkUse
          Case "D"
            ._CMUSE = WrkReading * -1
          Case "N"
            ._CMUSE = 0
          Case Else
            ._CMUSE = WrkReading
        End Select
        .AddOneRecordP()
      End If
    End With
  End Sub
  Private Sub WriteReadingDtl(ByVal WrkAcct As Integer, ByVal WrkXref As Integer, ByVal WrkUse As String,
  ByVal WrkReadDate As Date, ByVal WrkReading As Integer, ByVal WrkName As String, ByVal WrkLocation As String,
  ByVal WrkPost As Boolean)
    Dim UBType As String

    UBType = ""
    myUTCUSTMTD.GetOneRecordP(WrkAcct, WrkXref, UBType, MyUtils.SetDBDate(WrkReadDate))
    With myUTCUSTMTD
      If Not .RecordNotFound Then
        If Not WrkPost Then Exit Sub
        Select Case WrkUse
          Case "D"
            ._CMREAD = ._CMREAD - WrkReading
            ._CMUSE = ._CMUSE - WrkReading
          Case "N"
          Case Else
            ._CMREAD = ._CMREAD + WrkReading
            ._CMUSE = ._CMUSE + WrkReading
        End Select
        .UpdateOneRecordP()
      Else
        If Not WrkPost Then Exit Sub
        ._CMACCT = WrkAcct
        ._CMXREF = WrkXref
        ._CMTYPE = UBType
        ._CMDATE = MyUtils.SetDBDate(WrkReadDate)
        ._CMREAD = WrkReading
        Select Case WrkUse
          Case "D"
            ._CMUSE = WrkReading * -1
          Case "N"
            ._CMUSE = 0
          Case Else
            ._CMUSE = WrkReading
        End Select
        ._CMDESC1 = Trim(WrkName)
        ._CMDESC2 = Trim(WrkLocation)
        .AddOneRecordP()
      End If
    End With
  End Sub
  Private Sub WriteEdu()
    Dim ds3 As DataSet = New DataSet
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkGals As Integer
    Dim WrkEdu As Decimal
    Dim Counter As Integer
    Dim I As Integer

    WrkSort = ""
    'MK 7/17/25 Begin
    'WrkQry = "CUPCAT='COM'"
    WrkQry = "CUPCAT='COM' and RCODE<>'I'"
    'MK 7/17/25 End
    myUTCUSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myUTCUSTQ.ReadQry()
    If Not myUTCUSTQ.IsEOF Then
      Counter = Counter + 1
      With myUTCUSTQ
        WrkGals = 0
        ds3 = myUTCUSTMT.GetAllListNo(._CUACCT, "", MyUtils.SetDBDate(WrkReadDate1), MyUtils.SetDBDate(WrkReadDate4))
        For I = 0 To ds3.Tables(0).Rows.Count - 1
          WrkGals = WrkGals + ds3.Tables(0).Rows(I).Item("cmuse")
        Next
        '        'Always round up to next penny
        '        If (WrkGals / 76.65) - Math.Round(WrkGals / 76.65, 2) > 0 Then
        '        WrkEdu = Math.Round(WrkGals / 76.65, 2) + 0.01
        '        Else
        WrkEdu = Math.Round(WrkGals / 76.65, 2)
        '        End If
        If WrkGals > 0 And WrkEdu < 1 Then
          WrkEdu = 1
        End If
      End With
      With myUTCUST
        .GetOneRecordP(myUTCUSTQ._CUACCT)
        ._CUEDU = WrkEdu
        .UpdateOneRecordP()
      End With
NextRec:
      With myFrmProgress
        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          '.LblMsg.Text = "Records processed: " & Counter
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
      GoTo ReadNext
    End If

    myFrmProgress.Close()
    myUTCUSTQ.CloseFile()
  End Sub
End Module
