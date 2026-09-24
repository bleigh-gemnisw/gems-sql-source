Imports System.io
Imports System.Text
Module PrintRoutes

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myUTCUSTQ As UTCUSTQ.MyData
  Dim myUTCUSTMT As UTCUSTMT.MyData
  Dim myUTMETER As UTMETER.MyData

  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim DsUTCUST As DataSet = New DataSet
  Dim DsUTCUSTMT As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkDist As Integer
  Dim WrkUBType As String
  Dim WrkBillType As String
  Dim WrkReadDate As Date
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtRoutes()

    myUTCUSTQ = New UTCUSTQ.MyData(myDBConnect)
    myUTCUSTMT = New UTCUSTMT.MyData(myDBConnect)
    myUTMETER = New UTMETER.MyData(myDBConnect)

    With MyFrmUB305B
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkUBType = .TxtUBType.Text
      If .ChkBillType.Checked Then
        WrkBillType = WrkUBType
      Else
        WrkBillType = String.Empty
      End If
      WrkReadDate = .DtPckRead.Value
    End With

    If ds.Tables.Count = 0 Then
      BuildDs(ds, ds2)
    Else
      ds.Clear()
      ds2.Clear()
    End If

    If myTOWN._TOWNBR = 220 Then
      GetLegacy()
    Else
      GetFileV1_4()
    End If

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .wrkds2 = ds2
      .WrkDist = WrkDist
      .WrkRoutes = True
      .WrkPost = False
      .Show()
    End With

  End Sub
  Private Sub GetLegacy()
    Dim sb As StringBuilder
    Dim sw As StreamWriter = New StreamWriter(MyFrmUB305B.LblFilePath.Text)
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim WrkList As Integer
    Dim WrkStr As String
    Dim WrkMeterSize As String
    Dim WrkReadingMult As Integer
    Dim WrkReadingPrev As Integer
    Dim WrkSeq As Integer
    Dim SavePage As String

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    'MK 7/17/25 Begin
    'WrkQry = ""
    WrkQry = "RCODE<>'I'"
    'MK 7/17/25 End
    If WrkDist > 0 Then
      'MK 7/17/25 Begin
      'WrkQry = "CUDST=" & WrkDist
      WrkQry = WrkQry & WrkAnd & "CUDST=" & WrkDist
      'MK 7/17/25 End
    End If
    WrkSort = "CUROUT, CUPAGE"

    myUTCUSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    SavePage = ""
ReadNext:
    myUTCUSTQ.ReadQry()
    If Not myUTCUSTQ.IsEOF Then
      With myUTCUSTQ
        Counter = Counter + 1
        WrkList = ._CUACCT
        'Skip route 0
        If MyUtils.CnvSng(._CUROUT) = 0 Then GoTo NextRec
        'Skip route 99
        If MyUtils.CnvSng(._CUROUT) = 99 Then GoTo NextRec
        'Skip page 0
        If MyUtils.CnvSng(._CUPAGE) = 0 Then GoTo NextRec
        'Handle duplicate page numbers by increasing sequence
        If SavePage = Mid(._CUPAGE, 1, 4) Then
          WrkSeq = WrkSeq + 1
        Else
          WrkSeq = 0
        End If
        If MyUtils.CnvSng(._CUSERN) = 0 And MyUtils.CnvSng(._CUMETN) = 0 Then
          dr = ds2.Tables(0).NewRow
          dr.Item("sortdata") = Format(._CUACCT, "000000")
          dr.Item("listno") = ._CUACCT
          dr.Item("name") = Trim(._CUNAM1)
          dr.Item("route") = Trim(._CUROUT)
          dr.Item("section") = Trim(._CUSECT)
          dr.Item("location") = Trim(._CULOCNO & " " & ._CULOC)
          dr.Item("errmsg") = "Invalid meter number"
          ds2.Tables(0).Rows.Add(dr)
          GoTo NextRec
        End If
        SavePage = Mid(._CUPAGE, 1, 4)

        dr = ds.Tables(0).NewRow
        dr.Item("listno") = ._CUACCT
        dr.Item("name") = Trim(._CUNAM1)
        dr.Item("route") = Trim(._CUROUT)
        dr.Item("section") = Trim(._CUSECT)
        dr.Item("mult") = 0
        dr.Item("location") = Trim(._CULOCNO & " " & ._CULOC)
        dr.Item("errmsg") = String.Empty
        ds.Tables(0).Rows.Add(dr)

        sb = New StringBuilder
        '1: Route (10)
        WrkStr = Format(MyUtils.CnvSng(._CUROUT), "0000000000")
        sb.Append(WrkStr)
        '11: Reading Sequence (4)
        WrkStr = MyUtils.JustifyLeft("", 4)
        sb.Append(WrkStr)
        '15: Reading Sequence (4)
        WrkStr = Mid(._CUPAGE, 1, 4)
        WrkStr = Format(MyUtils.CnvSng(WrkStr), "0000")
        sb.Append(WrkStr)
        '19: Reading Sequence (2) 
        WrkStr = WrkSeq Mod 100
        sb.Append(Format(MyUtils.CnvSng(WrkStr), "00"))
        '21: Filler (6)
        WrkStr = MyUtils.JustifyLeft("", 6)
        sb.Append(WrkStr)
        '27: Text 
        WrkStr = " "
        sb.Append(WrkStr)
        '28: # of dials 
        WrkStr = Mid(._CYC, 1)
        sb.Append(WrkStr)
        '29: Meter ID (13)
        If Trim(._CUSERN) <> String.Empty Then
          WrkStr = MyUtils.JustifyLeft(._CUSERN, 13)
        Else
          WrkStr = MyUtils.JustifyLeft(._CUMETN, 13)
        End If
        sb.Append(WrkStr)
        '42: Filler (26)
        WrkStr = MyUtils.JustifyLeft("", 26)
        sb.Append(WrkStr)
        '68: Current Reading (10)
        WrkStr = "0         "
        sb.Append(WrkStr)
        '78: Filler (11)
        WrkStr = MyUtils.JustifyLeft("", 11)
        sb.Append(WrkStr)
        '89: High Reading Limit (10)
        WrkStr = "9999999999"
        sb.Append(WrkStr)
        '99: Low Reading Limit (10)
        WrkStr = "0000000000"
        sb.Append(WrkStr)
        '109: Filler (24)
        WrkStr = MyUtils.JustifyLeft("", 24)
        sb.Append(WrkStr)
        '133: Text
        WrkStr = "  "
        sb.Append(WrkStr)
        '135: Record Status (1)
        WrkStr = MyUtils.JustifyLeft(._CUSECT, 1)
        sb.Append(WrkStr)
        '136: Month/Day/Year (2/2/2)
        WrkStr = "      "
        sb.Append(WrkStr)
        '142: Hour/Minute/Second (2/2/2)
        WrkStr = "      "
        sb.Append(WrkStr)
        '148: Type of Reading (1)
        WrkStr = " "
        sb.Append(WrkStr)
        '149: Filler (11)
        WrkStr = MyUtils.JustifyLeft("", 11)
        sb.Append(WrkStr)
        '160: Text (3)
        WrkStr = MyUtils.JustifyLeft("A  ", 3)
        sb.Append(WrkStr)
        WrkReadingMult = 1
        WrkMeterSize = Trim(._CUMSIZ)
        myUTMETER.GetOneRecordP(WrkUBType, WrkMeterSize)
        If Not myUTMETER.RecordNotFound Then
          WrkReadingMult = myUTMETER._MTMULT
        End If
        DsUTCUSTMT = myUTCUSTMT.GetLastbyDate(._CUACCT, WrkBillType, MyUtils.SetDBDate(WrkReadDate) - 1)
        If DsUTCUSTMT.Tables(0).Rows.Count > 0 Then
          WrkReadingPrev = DsUTCUSTMT.Tables(0).Rows(0).Item("cmread") / WrkReadingMult
        Else
          WrkReadingPrev = 0
        End If
        '163: Previous Reading
        WrkStr = Format(WrkReadingPrev, "0000000000")
        sb.Append(WrkStr)
        '173: Filler (6)
        WrkStr = MyUtils.JustifyLeft("", 6)
        sb.Append(WrkStr)
        '179: 1st line: Location (24)
        WrkStr = Trim(._CULOCNO) & " " & Trim(._CULOC)
        WrkStr = MyUtils.JustifyLeft(WrkStr, 24)
        sb.Append(WrkStr)
        '203: 2nd line: Notes part 1 (24)
        WrkStr = Mid(._CUSDES, 1, 24)
        WrkStr = MyUtils.JustifyLeft(WrkStr, 24)
        sb.Append(WrkStr)
        '227: 3rd line: Notes part 2 (24)
        WrkStr = Mid(._CUSDES, 25, 24)
        WrkStr = MyUtils.JustifyLeft(WrkStr, 24)
        sb.Append(WrkStr)
        '251: Filler (24)
        WrkStr = Mid(._CUNAM1, 1, 24)
        sb.Append(MyUtils.JustifyLeft(WrkStr, 24))
        '275: Name (24)
        WrkStr = MyUtils.JustifyLeft("", 24)
        sb.Append(WrkStr)
        '299: Free form lines 1-8: Filler (169)
        WrkStr = MyUtils.JustifyLeft("", 169)
        sb.Append(WrkStr)
        '468: Op code (3)
        WrkStr = "   "
        sb.Append(WrkStr)
        '470: Filler (6)
        WrkStr = MyUtils.JustifyLeft("", 6)
        sb.Append(WrkStr)
        '476: Filler (9)
        WrkStr = MyUtils.JustifyLeft("", 9)
        sb.Append(WrkStr)
        '485: Text (2)
        WrkStr = MyUtils.JustifyLeft("", 2)
        sb.Append(WrkStr)
        '487: Filler (9)
        WrkStr = MyUtils.JustifyLeft("", 9)
        sb.Append(WrkStr)
        '496: List # (11)
        WrkStr = MyUtils.JustifyRight(Format(._CUACCT, "000000"), 11)
        sb.Append(WrkStr)
        sw.WriteLine(sb.ToString)
      End With

NextRec:
      With myFrmProgress
        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .LblMsg.Text = "Records processed: " & Counter
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
      GoTo ReadNext
    End If

    sw.Close()
    myFrmProgress.Close()
    myUTCUSTQ.CloseFile()
  End Sub
  Private Sub GetFileV1_4()
    Dim sb As StringBuilder
    Dim sw As StreamWriter = New StreamWriter(MyFrmUB305B.LblFilePath.Text)
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim WrkList As Integer
    Dim WrkStr As String
    Dim WrkMeterSize As String
    Dim WrkMeterSizeDesc As String
    Dim WrkReadingMult As Integer
    Dim WrkReadingPrev As Integer
    Dim WrkRoute As Integer
    Dim SaveRoute As Integer
    Dim SavePage As String

    WrkAnd = " and "
    WrkOr = " or "
    WrkQry = "CUROUT<>''"
    If WrkDist > 0 Then
      WrkQry = WrkQry & " and CUDST=" & WrkDist
    End If
    WrkSort = "CUROUT"
    WrkRoute = 0
    SaveRoute = 0

    myUTCUSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    SavePage = ""
    'COMHD: Company Header
    sb = New StringBuilder
    sb.Append("COMHD")
    '6: Company Code (4)
    WrkStr = MyUtils.JustifyLeft("BL", 4)
    sb.Append(WrkStr)
    '10: Create Date (8)
    WrkStr = MyUtils.SetDBDate(Date.Today)
    sb.Append(WrkStr)
    '18: Description (40)
    WrkStr = MyUtils.JustifyLeft("", 40)
    sb.Append(WrkStr)
    '58: File Version (1)
    sb.Append("4")
    '59: Service Orders (1)
    sb.Append("N")
    sw.WriteLine(sb.ToString)
    sb.Clear()

ReadNext:
    myUTCUSTQ.ReadQry()
    If Not myUTCUSTQ.IsEOF Then
      With myUTCUSTQ
        WrkList = ._CUACCT
        If myTOWN._TOWNBR = 219 Then 'Kensington 
          WrkRoute = MyUtils.CnvSng(Mid(._CUROUT, 1, 1))
        Else
          WrkRoute = 1
        End If
        If SaveRoute <> WrkRoute Then
          If SaveRoute > 0 Then
            'Router Trailer:
            sb = New StringBuilder
            sb.Append("RTETR")
            '5: Office (4)
            sb.Append("BL  ")
            '9: Cycle (4)
            sb.Append("0001")
            '13: Route (10)
            WrkStr = MyUtils.JustifyLeft(SaveRoute, 10)
            sb.Append(WrkStr)
            '23: No of Premisis (6)
            sb.Append(Space(6))
            '29: No of Meters (6)
            sb.Append(Space(6))
            sw.WriteLine(sb.ToString)
          End If
          'RTEHD: Route Header
          sb = New StringBuilder
            sb.Append("RTEHD")
            '6: Company Code (4)
            WrkStr = MyUtils.JustifyLeft("BL", 4)
            sb.Append(WrkStr)
            '10: Cycle (4)
            sb.Append("0001")
            '14: Route (10)
            WrkStr = MyUtils.JustifyLeft(WrkRoute, 10)
            sb.Append(WrkStr)
            '24: Read Date (8)
            sb.Append(MyUtils.SetDBDate(WrkReadDate))
            '32: Deactivate Date (8)
            sb.Append("00000000")
            '59: Route Message (80)
            WrkStr = MyUtils.JustifyLeft("", 80)
            sb.Append(WrkStr)
            sw.WriteLine(sb.ToString)
            sb.Clear()
          End If
          SaveRoute = WrkRoute
        If MyUtils.CnvSng(._CUSERN) = 0 And MyUtils.CnvSng(._CUMETN) = 0 Then
          dr = ds2.Tables(0).NewRow
          dr.Item("sortdata") = Format(._CUACCT, "000000")
          dr.Item("listno") = ._CUACCT
          dr.Item("name") = Trim(._CUNAM1)
          dr.Item("route") = Trim(._CUROUT)
          dr.Item("section") = Trim(._CUSECT)
          dr.Item("location") = Trim(._CULOCNO & " " & ._CULOC)
          dr.Item("errmsg") = "Invalid meter number"
          ds2.Tables(0).Rows.Add(dr)
          GoTo NextRec
        End If
        SavePage = Mid(._CUPAGE, 1, 4)

        Counter = Counter + 1
        dr = ds.Tables(0).NewRow
        dr.Item("listno") = ._CUACCT
        dr.Item("name") = Trim(._CUNAM1)
        dr.Item("route") = Trim(._CUROUT)
        dr.Item("section") = Trim(._CUSECT)
        dr.Item("mult") = 0
        dr.Item("location") = Trim(._CULOCNO & " " & ._CULOC)
        dr.Item("errmsg") = String.Empty
        ds.Tables(0).Rows.Add(dr)

        WrkReadingMult = 1
        WrkMeterSize = Trim(._CUMSIZ)
        WrkMeterSizeDesc = ""
        myUTMETER.GetOneRecordP(WrkUBType, WrkMeterSize)
        If Not myUTMETER.RecordNotFound Then
          WrkReadingMult = myUTMETER._MTMULT
          WrkMeterSizeDesc = Mid(myUTMETER._MTDESC, 1, 8)
        End If
        DsUTCUSTMT = myUTCUSTMT.GetLastbyDate(._CUACCT, WrkBillType, MyUtils.SetDBDate(WrkReadDate) - 1)
        If DsUTCUSTMT.Tables(0).Rows.Count > 0 Then
          WrkReadingPrev = DsUTCUSTMT.Tables(0).Rows(0).Item("cmread") / WrkReadingMult
        Else
          WrkReadingPrev = 0
        End If
        'PRMDT: Premisis Header (308)
        sb = New StringBuilder()
        sb.Append("PRMDT")
        '6: Address 1 (26)
        WrkStr = Trim(._CULOCNO) & " " & Trim(._CULOC)
        WrkStr = MyUtils.JustifyLeft(WrkStr, 26)
        sb.Append(WrkStr)
        '32: Optional Address 2 (26)
        sb.Append(Space(26))
        '58: Customer Name
        WrkStr = MyUtils.JustifyLeft(._CUNAM1, 26)
        sb.Append(WrkStr)
        '84: Premisis Key (20)
        sb.Append(MyUtils.JustifyLeft(WrkList, 20))
        '104: Account Number or Route (20)
        If myTOWN._TOWNBR = 219 Then 'Kensington
          sb.Append(MyUtils.JustifyLeft(._CUROUT, 20))
        Else
          sb.Append(MyUtils.JustifyLeft(WrkList, 20))
        End If
        '124: Account Status (4)
        sb.Append("ACTI")
        '128: Custom 1 (26)
        sb.Append(Space(26))
        '154: Custom 2 (26)
        sb.Append(Space(26))
        '180: Pass Through (128)
        sb.Append(Space(128))
        sw.WriteLine(sb.ToString)
        sb.Clear()

        'MTRDT: Meter Detail (338)
        sb = New StringBuilder()
        sb.Append("MTRDT")
        '6: Read Sequence (6)
        sb.Append(Format(Counter, "000000"))
        '12: Change Sequence(6)
        sb.Append("000000")
        '18: Meter Key (20)
        WrkStr = MyUtils.JustifyLeft(._CUMETN, 20)
        sb.Append(WrkStr)
        '38: Meter Number (20)
        WrkStr = MyUtils.JustifyLeft(._CUMETN, 20)
        sb.Append(WrkStr)
        '58: Change Meter Number (20)
        sb.Append(Space(20))
        '78: Meter Type (4)
        sb.Append("0002") 'Radio
        '82: Change Meter Type (4)
        sb.Append(Space(4))
        '86: Meter Size (8)
        sb.Append(MyUtils.JustifyLeft(WrkMeterSizeDesc, 8))
        '94: Change Meter Size (8)
        sb.Append(Space(8))
        '102-107: Optional fields (6)
        sb.Append(Space(6))
        '108: Meter UOM (3)
        sb.Append("CF ")
        '111-264: Optional fields (154)
        sb.Append(Space(154))
        '265: Longitute (12)
        sb.Append(MyUtils.JustifyLeft(._CULONG, 12))
        '277: Latitute (12)
        sb.Append(MyUtils.JustifyLeft(._CULAT, 12))
        '289: Future use (48)
        sb.Append(Space(48))
        sw.WriteLine(sb.ToString)
        sb.Clear()

        'RDGDT: Reading Detail
        sb = New StringBuilder()
        sb.Append("RDGDT")
        '6: Read Type (4) 
        sb.Append("WATR")
        '10: Collection ID (13)
        sb.Append(MyUtils.JustifyLeft(._CUMETN, 13))
        '23: Future use (7)
        sb.Append(Space(7))
        '30: Changed Collection ID (20)
        sb.Append(Space(20))
        '50: Dials (2)
        If myTOWN._TOWNBR = 219 Then 'Kensington 
          sb.Append("04")
        Else
          sb.Append("06")
        End If
        '52: Changed Dials (2)
        sb.Append(Space(2))
        '54: Decimals (2)
        sb.Append("00")
        '56: Changed Decimals (2)
        sb.Append(Space(2))
        '58: Read Direction (1)
        sb.Append("L")
        '59: High Limit (10)
        sb.Append("9999999999")
        '69: Low Limit (10)
        sb.Append("0000000000")
        '79: Previous Reading (10)
        sb.Append(Format(WrkReadingPrev, "0000000000"))
        '89: Reading (10)
        sb.Append(Space(10))
        '99: Collector Reading (10)
        sb.Append(Space(10))
        '109: Read Code (2)
        sb.Append(Space(2))
        '111: Reentry Count (2)
        sb.Append(Space(2))
        '113: Optional Fields
        sb.Append(Space(143))
        sw.WriteLine(sb.ToString)
        sb.Clear()
      End With

NextRec:
      With myFrmProgress
        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .LblMsg.Text = "Records processed: " & Counter
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
      GoTo ReadNext
    End If

    'Router Trailer:
    sb = New StringBuilder
    sb.Append("RTETR")
    '5: Office (4)
    sb.Append("BL  ")
    '9: Cycle (4)
    sb.Append("0001")
    '13: Route (10)
    WrkStr = MyUtils.JustifyLeft(WrkRoute, 10)
    sb.Append(WrkStr)
    '23: No of Premisis (6)
    sb.Append(Space(6))
    '29: No of Meters (6)
    sb.Append(Space(6))
    sw.WriteLine(sb.ToString)

    'Company Trailer:
    sb = New StringBuilder
    sb.Append("COMTR")
    '6: Company Code (4)
    WrkStr = MyUtils.JustifyLeft("BL", 4)
    sb.Append(WrkStr)
    '10: No of Routes (6)
    sb.Append(Space(6))
    sw.WriteLine(sb.ToString)

    sw.Close()
    myFrmProgress.Close()
    myUTCUSTQ.CloseFile()
  End Sub
End Module
