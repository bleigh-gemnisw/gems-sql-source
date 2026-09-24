Imports System.io
Imports System.Text
Module PrintReadings

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer

Dim myUTCUST As UTCUST.myData
Dim myUTCUSTMT As UTCUSTMT.myData
Dim myUTMETER As UTMETER.myData

Dim ds As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim DsUTCUSTMT As DataSet = New DataSet
Dim DsUTMETER As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkDist As Integer
Dim WrkUBType As String
Dim WrkBillType As String
Dim WrkReadDate As Date
Dim WrkPost As Boolean
Dim WrkAnd As String
Dim WrkOr As String
  Public Sub PrtReadings()

  myUTCUST = New UTCUST.mydata(MyDBConnect)
  myUTCUSTMT = New UTCUSTMT.mydata(MyDBConnect)
  myUTMETER = New UTMETER.mydata(MyDBConnect)

  With MyFrmUB305B
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    WrkUBType = .TxtUBType.Text
    If .ChkBillType.Checked Then
      WrkBillType = WrkUBType
    Else
      WrkBillType = String.Empty
    End If
    WrkReadDate = .DtPckRead.Value
    WrkPost = .ChkPost.Checked
  End With

  If ds.Tables.Count = 0 Then
    BuildDs(ds, ds2)
  Else
    ds.Clear()
    ds2.Clear()
  End If

    If myTOWN._TOWNBR = 220 Then
      GetLegacy() 'Old file layout
    Else
      GetFileV1_4()
    End If

Done:
  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .wrkds = ds
    .wrkds2 = ds2
    .WrkDist = 0
    .WrkRoutes = False
    .WrkPost = WrkPost
    .Show()
  End With

  End Sub
  Private Sub GetLegacy()
    Dim WrkStream As FileStream = New FileStream(MyFrmUB305B.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim WrkAcct As Integer
    Dim WrkErrCode As Integer
    Dim WrkMeterSize As String
    Dim WrkReadingMult As Integer
    Dim WrkReadingCurr As Integer
    Dim WrkReadingPrev As Integer
    Dim WrkMsg As String
    Dim WrkUse As Integer

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length

NextLine:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo Cleanup
    End If

    I = I + strBuffer.Length
    WrkMsg = String.Empty
    If Trim(Mid(strBuffer, 502, 6)) = String.Empty Then
      WrkAcct = 0
      WrkMsg = "* Missing Account # *"
    Else
      WrkAcct = Mid(strBuffer, 502, 6)
    End If
    WrkReadingMult = 1
    myUTCUST.GetOneRecordP(WrkAcct)
    If Not myUTCUST.RecordNotFound Then
      WrkMeterSize = Trim(myUTCUST._CUMSIZ)
      myUTMETER.GetOneRecordP(WrkUBType, WrkMeterSize)
      If Not myUTMETER.RecordNotFound Then
        WrkReadingMult = myUTMETER._MTMULT
      End If
    End If

    WrkErrCode = MyUtils.CnvSng(Mid(strBuffer, 121, 2))
    WrkReadingCurr = MyUtils.CnvSng(Mid(strBuffer, 68, 11)) * WrkReadingMult
    DsUTCUSTMT = myUTCUSTMT.GetLastbyDate(WrkAcct, WrkBillType, MyUtils.SetDBDate(WrkReadDate) - 1)
    If DsUTCUSTMT.Tables(0).Rows.Count > 0 Then
      WrkReadingPrev = DsUTCUSTMT.Tables(0).Rows(0).Item("cmread")
    Else
      WrkReadingPrev = 0
    End If

    If WrkReadingCurr >= WrkReadingPrev Then
      WrkUse = WrkReadingCurr - WrkReadingPrev
    Else
      WrkUse = 0
      WrkMsg = "* Current is lower: " & WrkReadingCurr & " *"
      WrkReadingCurr = WrkReadingPrev
    End If
    If WrkUse >= 0 And WrkErrCode = 0 Then
      dr = ds.Tables(0).NewRow
    Else
      dr = ds2.Tables(0).NewRow
    End If
    dr.Item("sortdata") = Format(999999999 - WrkUse, "000000000")
    dr.Item("listno") = WrkAcct
    dr.Item("name") = Mid(strBuffer, 251, 24)
    dr.Item("route") = MyUtils.CnvSng(Mid(strBuffer, 1, 10))
    dr.Item("location") = Mid(strBuffer, 179, 24)
    dr.Item("section") = Trim(myUTCUST._CUSECT)
    dr.Item("mult") = WrkReadingMult
    dr.Item("prev") = WrkReadingPrev
    dr.Item("curr") = WrkReadingCurr
    dr.Item("use") = WrkUse
    If WrkMsg = "" And WrkUse = 0 Then
      If WrkErrCode = 0 Then
        dr.Item("errmsg") = "* Same Reading *"
      Else
        dr.Item("errmsg") = "* No Reading *"
      End If
    Else
      dr.Item("errmsg") = WrkMsg
    End If
    If WrkUse >= 0 And WrkErrCode = 0 Then
      ds.Tables(0).Rows.Add(dr)
    Else
      ds2.Tables(0).Rows.Add(dr)
    End If
    dr = Nothing

    If WrkUse >= 0 And WrkErrCode = 0 And WrkPost Then
      myUTCUSTMT.GetOneRecordP(WrkAcct, WrkBillType, MyUtils.SetDBDate(WrkReadDate))
      With myUTCUSTMT
        ._CMACCT = WrkAcct
        ._CMTYPE = WrkBillType
        ._CMDATE = MyUtils.SetDBDate(WrkReadDate)
        ._CMREAD = WrkReadingCurr
        ._CMUSE = WrkUse
      End With
      If Not myUTCUSTMT.RecordNotFound Then
        myUTCUSTMT.UpdateOneRecordP()
      Else
        myUTCUSTMT.AddOneRecordP()
      End If
    End If

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

  End Sub
  Private Sub GetFileV1_4()
    Dim WrkStream As FileStream = New FileStream(MyFrmUB305B.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim WrkAcct As Integer
    Dim WrkRoute As String
    Dim WrkName As String
    Dim WrkLoc As String
    Dim WrkErrCode As Integer
    Dim WrkMeterSize As String
    Dim WrkReadingMult As Integer
    Dim WrkReadingCurr As Integer
    Dim WrkReadingPrev As Integer
    Dim WrkMsg As String
    Dim WrkUse As Integer

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    WrkName = ""
    WrkRoute = ""
    WrkLoc = ""

NextLine:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo Cleanup
    End If

    I = I + strBuffer.Length
    Select Case (Mid(strBuffer, 1, 5))
      Case "RTEHD"
        WrkRoute = MyUtils.CnvSng(Mid(strBuffer, 14, 10))
        GoTo NextRec
      Case "PRMDT"
        WrkAcct = MyUtils.CnvSng(Mid(strBuffer, 84, 7))
        WrkName = Trim(Mid(strBuffer, 58, 26))
        WrkLoc = Trim(Mid(strBuffer, 6, 26))
        If WrkLoc = "" Then
          WrkLoc = Trim(Mid(strBuffer, 32, 26))
        End If
        GoTo NextRec
      Case "MTRDT"
        GoTo NextRec
      Case "RDGDT"
        WrkReadingMult = 1
        myUTCUST.GetOneRecordP(WrkAcct)
        If Not myUTCUST.RecordNotFound Then
          WrkMeterSize = Trim(myUTCUST._CUMSIZ)
          myUTMETER.GetOneRecordP(WrkUBType, WrkMeterSize)
          If Not myUTMETER.RecordNotFound Then
            WrkReadingMult = myUTMETER._MTMULT
          End If
        End If
        WrkReadingCurr = MyUtils.CnvSng(Mid(strBuffer, 89, 10)) * WrkReadingMult
      Case Else
        GoTo NextRec
    End Select
    WrkMsg = String.Empty

    If WrkAcct = 0 Then
      WrkMsg = "* Missing Account # *"
    End If

    WrkErrCode = 0
    DsUTCUSTMT = myUTCUSTMT.GetLastbyDate(WrkAcct, WrkBillType, MyUtils.SetDBDate(WrkReadDate) - 1)
    If DsUTCUSTMT.Tables(0).Rows.Count > 0 Then
      WrkReadingPrev = DsUTCUSTMT.Tables(0).Rows(0).Item("cmread")
    Else
      WrkReadingPrev = 0
    End If

    If WrkReadingCurr >= WrkReadingPrev Then
      WrkUse = WrkReadingCurr - WrkReadingPrev
    Else
      WrkUse = 0
      WrkMsg = "* Current is lower: " & WrkReadingCurr & " *"
      WrkReadingCurr = WrkReadingPrev
    End If
    If WrkUse >= 0 And WrkErrCode = 0 Then
      dr = ds.Tables(0).NewRow
    Else
      dr = ds2.Tables(0).NewRow
    End If
    dr.Item("sortdata") = Format(999999999 - WrkUse, "000000000")
    dr.Item("listno") = WrkAcct
    dr.Item("name") = WrkName
    dr.Item("route") = WrkRoute
    dr.Item("location") = WrkLoc
    dr.Item("section") = ""
    dr.Item("mult") = WrkReadingMult
    dr.Item("prev") = WrkReadingPrev
    dr.Item("curr") = WrkReadingCurr
    dr.Item("use") = WrkUse
    If WrkMsg = "" And WrkUse = 0 Then
      If WrkErrCode = 0 Then
        dr.Item("errmsg") = "* Same Reading *"
      Else
        dr.Item("errmsg") = "* No Reading *"
      End If
    Else
      dr.Item("errmsg") = WrkMsg
    End If
    If WrkUse >= 0 And WrkErrCode = 0 Then
      ds.Tables(0).Rows.Add(dr)
    Else
      ds2.Tables(0).Rows.Add(dr)
    End If
    dr = Nothing

    If WrkUse >= 0 And WrkErrCode = 0 And WrkPost Then
      myUTCUSTMT.GetOneRecordP(WrkAcct, WrkBillType, MyUtils.SetDBDate(WrkReadDate))
      With myUTCUSTMT
        ._CMACCT = WrkAcct
        ._CMTYPE = WrkBillType
        ._CMDATE = MyUtils.SetDBDate(WrkReadDate)
        ._CMREAD = WrkReadingCurr
        ._CMUSE = WrkUse
      End With
      If Not myUTCUSTMT.RecordNotFound Then
        myUTCUSTMT.UpdateOneRecordP()
      Else
        myUTCUSTMT.AddOneRecordP()
      End If
    End If

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

  End Sub
End Module
