Imports System.io
Imports System.Text
Module PrintReportRE

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXREAL As TXReal.myData
  Dim myTXREALQ As TXREALQ.myData
  Dim myTXNCAM As TXNCAM.MyData
  Dim myTXTRANS As TXTRANS.MyData
  Dim myTXPHIN As TXPHIN.MyData
  Dim myTXPHCNTL As TXPHCNTL.MyData
  Dim myDBUTILS As DBUtils.Utils

  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim ds3 As DataSet = New DataSet
  Dim ds4 As DataSet = New DataSet
  Dim dsTotMC As DataSet = New DataSet
  Dim dsErr As DataSet = New DataSet
  Dim dr As DataRow
  Dim drErr As DataRow
  Dim dsTXREAL As DataSet = New DataSet

  'Screen fields
  Dim WrkBackup As Boolean
  Dim WrkCAMA As String
  Dim WrkNameRecord As Boolean
  Dim WrkUpFile As Boolean
  Dim WrkUpName As Boolean
  Dim WrkUpAssessment As Boolean
  Dim WrkUpAcreage As Boolean
  Dim WrkUpOther As Boolean
  Dim WrkUpExemption As Boolean
  Dim WrkUpCat As Boolean
  Dim WrkUpPurchase As Boolean
  Dim WrkUpPrtDist As Boolean
  Dim WrkAddMissing As Boolean
  Dim WrkSortBy As String
  'Work fields
  Dim WrkStop As Boolean
  Dim WrkCurrYear As Integer
  Dim WrkTotalYears As Integer
  Dim WrkGLYear As Integer
  Dim WrkListNo As Integer
  Dim WrkCat As String
  Dim WrkExempt As String
  Dim WrkName As String
  Dim WrkSName As String
  Dim WrkCO As Boolean
  Dim WrkAdd1 As String
  Dim WrkAdd2 As String
  Dim WrkCity As String
  Dim WrkState As String
  Dim WrkZip5 As Integer
  Dim WrkZip4 As Integer
  Dim WrkLocNo As String
  Dim WrkLoc As String
  Dim WrkMap As String
  Dim WrkVol As String
  Dim WrkPge As String
  Dim WrkPrtDist As Integer
  Dim WrkCode(11) As Integer
  Dim WrkAssmnt(11) As Integer
  Dim WrkUnits(11) As Decimal
  Dim WrkAcres(11) As Decimal
  Dim WrkExam(7) As Integer
  Dim WrkExcd(7) As String
  Dim WrkFullAssmnt(11) As Integer 'Full Phase In
  Dim WrkNewTXREAL As Boolean
  Dim WrkOldCode(6) As Integer
  Dim WrkOldAssmnt(6) As Integer
  Dim WrkOrigCode(6) As Integer
  Dim WrkOrigAmt(6) As Integer
  Dim WrkBuilding As Integer
  Dim WrkLand As Integer
  Dim WrkTotGross As Integer
  Dim WrkTotNet As Integer
  Dim WrkTotExam As Integer
  Dim WrkPurPrice As Long
  Dim WrkPurDt As Integer
  Dim strBuffer As String

  'Expected File lengths
  Dim cVisionLen As Integer = 2353
  Dim cVisionCOLen As Integer = 2393
  Dim cCLTLen As Integer = 338
  Dim cCLTAltLen As Integer = 643
  Public Sub PrtReportRE()

    myTXREAL = New TXReal.mydata(MyDBConnect)
    myTXREALQ = New TXREALQ.mydata(MyDBConnect)
    myTXNCAM = New TXNCAM.mydata(MyDBConnect)
    myTXTRANS = New TXTRANS.MyData(myDBConnect)
    myTXPHIN = New TXPHIN.MyData(myDBConnect)
    myTXPHCNTL = New TXPHCNTL.MyData(myDBConnect)
    myDBUTILS = New DBUtils.Utils(myDBConnect)

    WrkStop = False
    WrkBackup = False
    WrkUpFile = False
    WrkUpAssessment = False
    WrkUpAcreage = False
    WrkUpOther = False
    WrkUpExemption = False
    WrkUpCat = False
    WrkAddMissing = False
    WrkUpPurchase = False
    WrkUpPrtDist = False

    With MyFrmTAC01B
      If .ChkBackup.Checked = True Then WrkBackup = True
      If .ChkPost.Checked = True Then WrkUpFile = True
      If .ChkName.Checked = True Then WrkUpName = True
      If .ChkAssmnt.Checked = True Then WrkUpAssessment = True
      If .ChkAcreage.Checked = True Then WrkUpAcreage = True
      If .ChkOther.Checked = True Then WrkUpOther = True
      If .ChkExemption.Checked = True Then WrkUpExemption = True
      If .ChkCat.Checked = True Then WrkUpCat = True
      If .ChkPurchase.Checked = True Then WrkUpPurchase = True
      If .ChkPrtDist.Checked = True Then WrkUpPrtDist = True
      If .ChkAddList.Checked = True Then WrkAddMissing = True
      If .RbVision.Checked Then
        WrkCAMA = "Vision"
      End If
      If .RbProVal.Checked Then
        WrkCAMA = "ProVal"
      End If
      If .RbCLT.Checked Then
        WrkCAMA = "CLT"
      End If
      If .RbCLT2.Checked Then
        WrkCAMA = "CLT2"
      End If
      If .RbAdmins.Checked Then
        WrkCAMA = "Admins"
      End If
      If .RbOwnerofRecord.Checked Then
        WrkNameRecord = True
      Else
        WrkNameRecord = False
      End If
      If .RbSortName.Checked Then WrkSortBy = "NAME"
      If .RbSortList.Checked Then WrkSortBy = "LIST#"
    End With

    If ds.Tables.Count = 0 Then
      BuildDs(ds)
      BuildDs2(ds2)
      BuildDs3(ds3)
      ds4 = ds3.Clone
      BuildDSTotMC(dsTotMC)
      BuildDsErr(dsErr)
    Else
      ds.Clear()
      ds2.Clear()
      ds3.Clear()
      ds4.Clear()
      dsTotMC.Clear()
      dsErr.Clear()
    End If

    If MyPhaseIn Then
      With myTXPHCNTL
        .GetOneRecordP("")
        If Not .RecordNotFound Then
          WrkCurrYear = ._CURRYEAR
          WrkTotalYears = ._TOTALYEARS
          WrkGLYear = ._STARTYEAR + ._CURRYEAR - 1
        End If
      End With
    End If

    BufferCodes("R")
    BufferExemptCodes()
    WrkStop = False
    dsTXREAL = myTXREALQ.GetQry("", "", 0)
    GetDetail()
    If WrkStop Then Exit Sub
    GetMissingCAMA()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds1 = ds
      .Wrkds2 = ds2
      .Wrkds3 = ds3
      .Wrkds4 = ds4
      .WrkdsTotMC = dsTotMC
      .WrkdsErr = dsErr
      .Show()
    End With

  End Sub
  Private Sub GetDetail()
    Dim WrkStream As FileStream = New FileStream(MyFrmTAC01B.LblFilePath.Text, FileMode.Open,
   FileAccess.Read, FileShare.Read, 5000, FileOptions.SequentialScan)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim WrkOrigName As String
    Dim I As Integer
    Dim J As Integer
    Dim K As Integer
    Dim Counter As Integer
    Dim WrkLen As Integer
    Dim WrkErrorMsg As String

    ReDim WrkTMCCode(100)
    ReDim WrkTMCCount(100)
    ReDim WrkTMCGross(100)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    ' If Posting  Save the existing file 1st...
    If WrkUpFile = True Then
      myFrmProgress.Text = "Saving Current Real Estate Assessor Data"
      myFrmProgress.ProgBar1.Visible = False
      myFrmProgress.LblMsg.Text = "Saving Real Estate Assesor Data"
      myFrmProgress.Refresh()
      Application.DoEvents()

      If WrkBackup Then
        myDBUTILS.DeleteAllRecs("CAMREAL")
        myDBUTILS.CopyData("TXREAL", "CAMREAL")
      End If
    End If

    myFrmProgress.Text = "CAMA Real Estate Bridge "
    myFrmProgress.ProgBar1.Visible = True
    myFrmProgress.LblMsg.Text = ""
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    Counter = 0
    Select Case WrkCAMA
      Case Is = "Admins"
        sr.ReadLine()
      Case Else
    End Select

NextLine:
    For J = 0 To 11
      WrkCode(J) = 0
    Next
    Array.Clear(WrkAssmnt, 0, 11)
    Array.Clear(WrkFullAssmnt, 0, WrkFullAssmnt.Length)
    Array.Clear(WrkUnits, 0, 11)
    Array.Clear(WrkAcres, 0, 11)
    Array.Clear(WrkExam, 0, 7)
    For J = 0 To 7
      WrkExcd(J) = ""
    Next
    WrkBuilding = 0
    WrkLand = 0
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo Cleanup
    End If

    I = I + strBuffer.Length
    Counter = Counter + 1

    If strBuffer.Substring(0, 1) = "~" Then
      GoTo NextRec
    End If

    WrkLen = Len(strBuffer)
    Select Case WrkCAMA
      Case Is = "Admins"
        ReadAdmins()
      Case Is = "CLT"
        If WrkLen <> cCLTLen Then
          MsgBox("Manually check file. Record length  " & WrkLen & " is not correct. Record number is " & Counter, MsgBoxStyle.Critical,
        "CAMA import processing cannot continue")
          WrkStop = True
          GoTo Cleanup
        End If
        ReadCLT()
      Case Is = "CLT2"
        If WrkLen <> cCLTAltLen Then
          MsgBox("Manually check file. Record length  " & WrkLen & " is not correct. Record number is " & Counter, MsgBoxStyle.Critical,
        "CAMA import processing cannot continue")
          WrkStop = True
          GoTo Cleanup
        End If
        ReadCLT2()
      Case Is = "ProVal"
        ReadProVal()
      Case Is = "Vision"
        If WrkLen <> cVisionLen And WrkLen <> cVisionCOLen Then
          MsgBox("Manually check file. Record length " & WrkLen & " is not correct. Record number is " & Counter, MsgBoxStyle.Critical,
        "CAMA import processing cannot continue")
          WrkStop = True
          GoTo Cleanup
        End If
        ReadVision(WrkLen)
    End Select

    If WrkListNo <> 649 Then
      GoTo NextRec
    End If
    myTXREAL.GetOneRecordP(WrkListNo)

    WrkNewTXREAL = myTXREAL.RecordNotFound
    Array.Clear(WrkOldCode, 0, WrkOldCode.Length)
    Array.Clear(WrkOldAssmnt, 0, WrkOldAssmnt.Length)

    If Not WrkNewTXREAL Then
      WrkOldCode(0) = myTXREAL._CODE1
      WrkOldCode(1) = myTXREAL._CODE2
      WrkOldCode(2) = myTXREAL._CODE3
      WrkOldCode(3) = myTXREAL._CODE4
      WrkOldCode(4) = myTXREAL._CODE5
      WrkOldCode(5) = myTXREAL._CODE6
      WrkOldCode(6) = myTXREAL._CODE7

      WrkOldAssmnt(0) = myTXREAL._ASS1
      WrkOldAssmnt(1) = myTXREAL._ASS2
      WrkOldAssmnt(2) = myTXREAL._ASS3
      WrkOldAssmnt(3) = myTXREAL._ASS4
      WrkOldAssmnt(4) = myTXREAL._ASS5
      WrkOldAssmnt(5) = myTXREAL._ASS6
      WrkOldAssmnt(6) = myTXREAL._ASS7
    End If

    ' Calculate the current phase-in year assessment before
    ' building the comparison rows or updating TXREAL.
    If MyPhaseIn AndAlso WrkCAMA = "Vision" Then
      CalcPhaseInAssessment(WrkListNo)
    End If

    myTXNCAM.GetOneRecordP(WrkListNo)
    If Not myTXNCAM.RecordNotFound Or WrkAddMissing And myTXREAL.RecordNotFound And WrkExempt <> "" And Not WrkUpCat Then
      dr = ds4.Tables(0).NewRow
      Select Case WrkSortBy
        Case "LIST#"
          dr.Item("sortdata") = Format(WrkListNo, "000000")
        Case "NAME"
          dr.Item("sortdata") = WrkName
      End Select
      dr.Item("listno") = WrkListNo
      dr.Item("cat") = WrkCat
      dr.Item("name") = WrkName
      dr.Item("loc") = WrkLoc
      dr.Item("locno") = WrkLocNo
      dr.Item("map") = WrkMap
      dr.Item("cgross") = WrkTotGross
      If Not myTXREAL.RecordNotFound Then
        dr.Item("gross") = myTXREAL._GROSS
      Else
        dr.Item("gross") = 0
      End If
      ds4.Tables(0).Rows.Add(dr)
      GoTo NextRec
    End If

    '  WrkErrorMsg = CheckError(WrkListNo) 'temp

    WrkOrigName = ""
    If Not myTXREAL.RecordNotFound Then
      WrkOrigName = Trim(myTXREAL._NAME)
      dr = ds.Tables(0).NewRow
    Else
      dr = ds2.Tables(0).NewRow
    End If
    Select Case WrkSortBy
      Case "LIST#"
        dr("sortdata") = Format(WrkListNo, "000000")
      Case "NAME"
        dr("sortdata") = WrkName
    End Select
    dr("listno") = WrkListNo
    dr("ccat") = WrkCat
    dr("cname") = WrkName
    If WrkNameRecord Then
      dr("csname") = WrkSName
    Else
      If WrkOrigName = Trim(WrkName) Then
        dr("csname") = WrkSName
      Else
        dr("csname") = ""
      End If
    End If
    If WrkCO Then
      dr("co") = "*C/O"
    End If
    dr("cloc") = WrkLoc
    dr("clocno") = MyUtils.JustifyRight(WrkLocNo, 7)
    dr("cadd1") = WrkAdd1
    dr("cadd2") = WrkAdd2
    dr("cmap") = WrkMap
    If Not myTXREAL.RecordNotFound Then
      With myTXREAL
        If WrkSortBy = "NAME" Then
          dr("sortdata") = Trim(._NAME)
        End If
        dr("cat") = ._CAT
        dr("name") = Trim(._NAME)
        dr("sname") = Trim(._SNAME)
        dr("loc") = Trim(._LOC)
        dr("locno") = ._LOCNO
        dr("map") = Trim(._MAP)
        dr("gross") = ._GROSS
        dr("net") = ._NET
        dr("exam") = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5 + ._EXAM6 + ._EXAM7
        'If no exemptions are updated then get from Real Estate File instead
        If Not WrkUpExemption Then
          WrkTotExam = dr("exam")
        End If
      End With
    Else
      If Not WrkUpExemption Then
        WrkTotExam = 0
      End If
    End If
    If Not myTXREAL.RecordNotFound Then
      If WrkUpCat And dr("ccat") <> "" And dr("cat") <> dr("ccat") Then
        drErr = dsErr.Tables(0).NewRow
        Select Case WrkSortBy
          Case "LIST#"
            drErr("sortdata") = Format(WrkListNo, "000000")
          Case "NAME"
            drErr("sortdata") = WrkName
        End Select
        drErr("listno") = WrkListNo
        drErr("name") = WrkName
        drErr("loc") = WrkLoc
        drErr("locno") = WrkLocNo
        drErr("errmsg") = "Alert: Tax Category Change"
        dsErr.Tables(0).Rows.Add(drErr)
      End If
    End If
    WrkTotNet = WrkTotGross - WrkTotExam
    dr("cgross") = WrkTotGross
    dr("cnet") = WrkTotNet
    dr("cexam") = WrkTotExam

    WrkErrorMsg = CheckError(WrkListNo)
    If WrkErrorMsg <> String.Empty Then
      drErr = dsErr.Tables(0).NewRow
      Select Case WrkSortBy
        Case "LIST#"
          drErr("sortdata") = Format(WrkListNo, "000000")
        Case "NAME"
          drErr("sortdata") = WrkName
      End Select
      drErr("listno") = WrkListNo
      drErr("name") = WrkName
      drErr("loc") = WrkLoc
      drErr("locno") = WrkLocNo
      drErr("errmsg") = WrkErrorMsg
      dsErr.Tables(0).Rows.Add(drErr)
      GoTo NextRec
    End If

    If Not myTXREAL.RecordNotFound Then
      ds.Tables(0).Rows.Add(dr)
    Else
      ds2.Tables(0).Rows.Add(dr)
    End If

    'Split Exempt into Building and Land 
    Select Case WrkCAMA
      Case Is = "CLT" 'Derby
        If myTXREAL._CAT = "3" And WrkLand > 0 Then
          If WrkBuilding > 0 Then
            WrkCode(0) = 200
            WrkAssmnt(0) = WrkBuilding
            WrkCode(1) = 201
            WrkAssmnt(1) = WrkLand
          Else
            WrkCode(0) = 201
            WrkAssmnt(0) = WrkLand
          End If
        End If
      Case Is = "CLT2"
        If myTOWN._TOWNBR = 35 Then 'Darien
          If myTXREAL._CAT = "3" And WrkLand > 0 Then
            If WrkBuilding > 0 Then
              WrkCode(0) = 300
              WrkAssmnt(0) = WrkBuilding
              WrkCode(1) = 310
              WrkAssmnt(1) = WrkLand
            Else
              WrkCode(0) = 310
              WrkAssmnt(0) = WrkLand
            End If
          End If
        End If
      Case Is = "Vision"
        If myTXREAL._CAT = "3" And WrkLand > 0 Then
          If WrkBuilding > 0 Then
            WrkCode(0) = 200
            WrkAssmnt(0) = WrkBuilding
            WrkCode(1) = 201
            WrkAssmnt(1) = WrkLand
          Else
            WrkCode(0) = 201
            WrkAssmnt(0) = WrkLand
          End If
        End If
      Case Else
    End Select

    'CAMA Totals
    For J = 0 To 11
      If Not IsNothing(WrkCode(J)) Then
        WrkCode(J) = StripDash(WrkCode(J))
        K = LookupWrkTMCCode(WrkCode(J))
        If WrkAssmnt(J) > 0 Then
          WrkTMCCode(K) = WrkCode(J)
          WrkTMCCount(K) = WrkTMCCount(K) + 1
          WrkTMCGross(K) = WrkTMCGross(K) + WrkAssmnt(J)
        Else
          If WrkAssmnt(J) < 0 Then
            drErr = dsErr.Tables(0).NewRow
            Select Case WrkSortBy
              Case "LIST#"
                drErr("sortdata") = Format(WrkListNo, "000000")
              Case "NAME"
                drErr("sortdata") = WrkName
            End Select
            drErr("listno") = WrkListNo
            drErr("name") = WrkName
            drErr("loc") = WrkLoc
            drErr("locno") = WrkLocNo
            drErr("errmsg") = "Negative assessment amount"
            dsErr.Tables(0).Rows.Add(drErr)
            GoTo NextRec
          End If
        End If
      End If
    Next J

    If WrkUpFile Then
      If MyPhaseIn Then
        UpdateTXPHIN(WrkListNo, 0)
      End If
      UpdateTXREAL()
      If myTXREAL.ErrMsg <> "" Then
        MsgBox(WrkListNo & " " & myTXREAL.ErrMsg, MsgBoxStyle.Exclamation, "Data issue found in CAMA file. Processing will stop.")
        GoTo Cleanup
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
    For I = 0 To 100
      If IsNothing(WrkTMCCode(I)) Then Exit For
      dr = dsTotMC.Tables(0).NewRow
      dr.Item("tmccode") = WrkTMCCode(I)
      dr.Item("tmcdesc") = GetTXCodeDesc(WrkTMCCode(I), "R")
      dr.Item("tmccount") = WrkTMCCount(I)
      dr.Item("tmcgross") = WrkTMCGross(I)
      dsTotMC.Tables(0).Rows.Add(dr)
    Next I

    sr.Close()
    myFrmProgress.Close()
  End Sub
  Public Sub ReadVision(ByVal WrkLen As Integer)
    Dim Sb As StringBuilder
    Dim WrkStr As String
    Dim J As Integer
    Dim Pos As Integer

    If myTOWN._TOWNBR = 32 Then 'Coventry
      WrkListNo = MyUtils.CnvSng(strBuffer.Substring(72, 5))
    Else
      WrkListNo = MyUtils.CnvSng(strBuffer.Substring(71, 6))
    End If
    If WrkNameRecord Then
      WrkName = Replace(strBuffer.Substring(93, 35), ",", "")
    Else
      WrkName = Replace(strBuffer.Substring(651, 35), ",", "")
    End If
    WrkLoc = strBuffer.Substring(36, 25)
    WrkLocNo = Trim(strBuffer.Substring(61, 7))
    WrkMap = String.Empty
    'Use long Map/Block/Lot if it's there
    If Trim(strBuffer.Substring(2047, 7)) <> String.Empty Then
      Sb = New StringBuilder
      Sb.Append(Trim(strBuffer.Substring(2047, 7)))
      Sb.Append(" ")
      If myTOWN._TOWNBR = 84 Then  'Milford
        If Trim(strBuffer.Substring(2054, 3)) <> String.Empty Then
          Sb.Append(Trim(strBuffer.Substring(2054, 3)))
          Sb.Append(" ")
        End If
      End If
      If Trim(strBuffer.Substring(2057, 7)) <> String.Empty Then
        Sb.Append(Trim(strBuffer.Substring(2057, 7)))
        Sb.Append(" ")
      End If
      If myTOWN._TOWNBR = 84 Then  'Milford
        If Trim(strBuffer.Substring(2064, 3)) <> String.Empty Then
          Sb.Append(Trim(strBuffer.Substring(2064, 3)))
          Sb.Append(" ")
        End If
      End If
      If Trim(strBuffer.Substring(2067, 7)) <> String.Empty Then
        Sb.Append(Trim(strBuffer.Substring(2067, 7)))
        Sb.Append(" ")
      End If
      If myTOWN._TOWNBR = 84 Then  'Milford
        If Trim(strBuffer.Substring(2074, 3)) <> String.Empty Then
          Sb.Append(Trim(strBuffer.Substring(2074, 3)))
          Sb.Append(" ")
        End If
      End If
      Sb.Append(Trim(strBuffer.Substring(2077, 7)))
      If myTOWN._TOWNBR = 84 Then  'Milford
        If Trim(strBuffer.Substring(2084, 3)) <> String.Empty Then
          Sb.Append(Trim(strBuffer.Substring(2084, 3)))
          Sb.Append("")
        End If
      End If
      WrkMap = Trim(Sb.ToString)
      Sb = Nothing
    End If
    'Use alternate parcel ID if it's there
    If WrkMap = String.Empty Then
      If Trim(strBuffer.Substring(15, 21)) <> String.Empty Then
        Sb = New StringBuilder
        Sb.Append(Trim(strBuffer.Substring(15, 21)))
        WrkMap = Trim(Sb.ToString)
        Sb = Nothing
      End If
    End If
    If WrkMap = String.Empty Then
      Sb = New StringBuilder
      Sb.Append(Trim(strBuffer.Substring(0, 4)))
      Sb.Append(" ")
      If Trim(strBuffer.Substring(5, 4)) <> String.Empty Then
        Sb.Append(Trim(strBuffer.Substring(5, 4)))
        Sb.Append(" ")
      End If
      Sb.Append(Trim(strBuffer.Substring(10, 4)))
      WrkMap = Trim(Sb.ToString)
      Sb = Nothing
    End If
    WrkCO = False
    WrkSName = Replace(strBuffer.Substring(133, 35), ",", "")
    If Trim(WrkSName) = "" Then
      If WrkLen = cVisionCOLen Then
        'WrkSName = Replace(strBuffer.Substring(2193, 35), ",", "")
        'If Trim(WrkSName) <> "" Then
        '  WrkCO = True
        'End If
      End If
    End If
    WrkAdd1 = strBuffer.Substring(173, 30)
    WrkAdd2 = strBuffer.Substring(203, 30)
    WrkCity = strBuffer.Substring(273, 20)
    WrkState = strBuffer.Substring(293, 2)
    WrkZip5 = MyUtils.CnvSng(strBuffer.Substring(295, 5))
    WrkZip4 = MyUtils.CnvSng(strBuffer.Substring(301, 4))
    If WrkUpPrtDist Then
      WrkPrtDist = MyUtils.CnvSng(strBuffer.Substring(513, 3))
    End If
    If myTOWN._TOWNBR = 32 Then 'Coventry 
      WrkStr = Trim(strBuffer.Substring(633, 10))
      Pos = InStr(WrkStr, " ")
      If Pos > 0 Then
        WrkVol = Mid(WrkStr, 1, Pos - 1)
        WrkPge = Mid(WrkStr, Pos + 1, 5)
      Else
        WrkVol = ""
        WrkPge = ""
      End If
    Else
      WrkVol = Replace(strBuffer.Substring(633, 5), "/", "")
      WrkPge = Replace(strBuffer.Substring(639, 4), "/", "")
    End If
    WrkExempt = ""
    WrkTotGross = 0
    WrkTotNet = 0
    WrkTotExam = 0
    For J = 0 To 11
      ReadVisionAssmnt(J)
      If WrkCode(J) = 0 Then Exit For
      If MyPhaseIn Then
        WrkFullAssmnt(J) = WrkAssmnt(J)
      End If
      WrkTotGross = WrkTotGross + WrkAssmnt(J)
    Next
    For J = 0 To 7
      ReadVisionExemption(J)
      If Trim(WrkExcd(J)) = "" Then Exit For
      WrkTotExam = WrkTotExam + WrkExam(J)
    Next
    If WrkExempt = "" Then
      WrkCat = "1"
    Else
      WrkCat = "3"
    End If
    'If myTOWN._TOWNBR = 45 Then 'East Lyme
    '  If WrkCode(0) = 11 Or WrkCode(0) = 12 Or WrkCode(0) = 13 Or _
    '   WrkCode(0) = 14 Or WrkCode(0) = 21 Or WrkCode(0) = 22 Or _
    '   WrkCode(0) = 25 Then
    '    WrkCat = "3"
    '  End If
    'End If
    WrkPurPrice = MyUtils.CnvSng(strBuffer.Substring(695, 9))
    If MyUtils.CnvSng(strBuffer.Substring(643, 8)) > 0 Then
      WrkPurDt = MyUtils.SetDBDate(MyUtils.GetDBDateMDY(strBuffer.Substring(643, 8)))
    Else
      WrkPurDt = 0
    End If
  End Sub
  Private Sub ReadVisionAssmnt(ByVal I As Integer)
    Dim Pos As Integer
    Dim WrkNumber As Decimal
    Dim WrkAreaType As String

    Select Case I
      Case 0
        Pos = 1351
      Case 1
        Pos = 1409
      Case 2
        Pos = 1467
      Case 3
        Pos = 1525
      Case 4
        Pos = 1583
      Case 5
        Pos = 1641
      Case 6
        Pos = 1699
      Case 7
        Pos = 1757
      Case 8
        Pos = 1815
      Case 9
        Pos = 1873
      Case 10
        Pos = 1931
      Case 11
        Pos = 1989
    End Select

    ' Always get the assessment code directly from the current Vision record.
    ' Do not depend on TXREAL, TXPHIN, or a value left in WrkCode from another record.
    If strBuffer.Substring(Pos + 3, 1) = "E" Then
      WrkCode(I) = Val(strBuffer.Substring(Pos, 3))
    Else
      WrkCode(I) = StripDash(strBuffer.Substring(Pos, 4))
    End If

    ' A blank Vision assessment slot returns code 0.
    If WrkCode(I) = 0 Then
      WrkAssmnt(I) = 0
      WrkFullAssmnt(I) = 0
      WrkAcres(I) = 0
      Exit Sub
    End If
    'WrkUnits(I) = strBuffer.Substring(Pos + 4, 1)
    WrkNumber = MyUtils.CnvSng(strBuffer.Substring(Pos + 13, 9))
    WrkNumber = WrkNumber * 0.01
    WrkAreaType = strBuffer.Substring(Pos + 4, 1)
    If WrkAreaType = "S" Then
      WrkNumber = WrkNumber / 43823.5
      WrkNumber = MyUtils.Round(WrkNumber, 2)
    End If
    WrkAcres(I) = WrkNumber
    If WrkAssmnt(I) = 0 Then
      WrkAssmnt(I) = MyUtils.CnvSng(strBuffer.Substring(Pos + 49, 9))
    End If
    If myTOWN._TOWNBR = 32 Then 'Coventry
      If WrkListNo >= 30000 And I = 0 And WrkAssmnt(0) > 0 Then
        WrkExempt = WrkCode(0)
        If MyUtils.CnvSng(strBuffer.Substring(Pos + 31, 9)) > 0 Then
          WrkCode(0) = 200 'Building
          WrkAssmnt(0) = MyUtils.CnvSng(strBuffer.Substring(Pos + 31, 9))
          WrkCode(1) = 201 'Land
          WrkAssmnt(1) = MyUtils.CnvSng(strBuffer.Substring(Pos + 22, 9))
        Else
          WrkCode(0) = 201 'Land
          WrkAssmnt(0) = MyUtils.CnvSng(strBuffer.Substring(Pos + 22, 9))
        End If
      End If
    Else
      If WrkCode(0) = 200 And I = 0 Then 'Hold for exempt property split 
        WrkBuilding = MyUtils.CnvSng(strBuffer.Substring(Pos + 31, 9))
        WrkLand = MyUtils.CnvSng(strBuffer.Substring(Pos + 22, 9))
      End If
    End If
  End Sub
  Private Sub ReadVisionExemption(ByVal I As Integer)
    Dim Pos As Integer

    Select Case I
      Case 0
        Pos = 1063
      Case 1
        Pos = 1082
      Case 2
        Pos = 1101
      Case 3
        Pos = 1120
      Case 4
        Pos = 1139
      Case 5
        Pos = 1158
      Case 6
        Pos = 1177
      Case 7
        Pos = 1196
    End Select

    WrkExcd(I) = strBuffer.Substring(Pos, 3)
    WrkExam(I) = MyUtils.CnvSng(strBuffer.Substring(Pos + 4, 11)) / 100
    'If exemption is 4 chars then it's an exempt property
    If WrkExempt = "" And Trim(strBuffer.Substring(Pos + 3, 1)) <> "" Then
      WrkExempt = strBuffer.Substring(Pos, 4)
      WrkExcd(I) = ""
      WrkExam(I) = 0
    End If
  End Sub
  Public Sub ReadProVal()
    Dim Sb As StringBuilder
    Dim WrkCityST As String
    Dim J As Integer
    Dim Pos As Integer

    WrkExempt = Trim(strBuffer.Substring(503, 30))
    If WrkExempt = "" Then
      WrkCat = "1"
    Else
      WrkCat = "3"
    End If
    WrkListNo = MyUtils.CnvSng(strBuffer.Substring(1, 6))
    WrkName = strBuffer.Substring(319, 35)
    WrkLoc = strBuffer.Substring(351, 20)
    WrkLocNo = Trim(strBuffer.Substring(478, 20))
    Sb = New StringBuilder
    Sb.Append(Trim(strBuffer.Substring(424, 4)))
    Sb.Append(" ")
    Sb.Append(Trim(strBuffer.Substring(428, 4)))
    Sb.Append(" ")
    Sb.Append(Trim(strBuffer.Substring(432, 4)))
    WrkMap = Trim(Sb.ToString)
    Sb = Nothing
    WrkSName = strBuffer.Substring(446, 32)
    WrkAdd1 = strBuffer.Substring(371, 30)
    WrkAdd2 = ""
    WrkCityST = strBuffer.Substring(391, 20)
    Pos = InStrRev(WrkCityST, " ")
    WrkCity = Mid(WrkCityST, 1, Pos)
    WrkState = Mid(WrkCityST, Pos + 1)
    WrkZip5 = MyUtils.CnvSng(strBuffer.Substring(529, 5))
    WrkZip4 = MyUtils.CnvSng(strBuffer.Substring(534, 4))
    WrkVol = strBuffer.Substring(416, 4)
    WrkPge = strBuffer.Substring(420, 4)
    WrkTotGross = 0
    WrkTotExam = 0
    For J = 0 To 5
      ReadProValAssmnt(J)
      If WrkCode(J) = 0 Then Exit For
      WrkTotGross = WrkTotGross + WrkAssmnt(J)
    Next
    WrkPurPrice = 0 'strBuffer.Substring(695, 9)
    WrkPurDt = 0 'strBuffer.Substring(643, 8)
  End Sub
  Private Sub ReadProValAssmnt(ByVal I As Integer)
    Dim PosAss As Integer
    Dim PosAcre As Integer
    Dim PosUnit As Integer
    Dim PosCode As Integer

    PosAss = 171 + (I * 9)
    PosAcre = 216 + (I * 6)
    PosUnit = 246 + (I * 4)
    PosCode = 300 + (I * 3)

    WrkCode(I) = MyUtils.CnvSng(strBuffer.Substring(PosCode))
    WrkUnits(I) = MyUtils.CnvSng(strBuffer.Substring(PosUnit))
    WrkAcres(I) = MyUtils.CnvSng(strBuffer.Substring(PosAcre)) / 100
    WrkAssmnt(I) = MyUtils.CnvSng(strBuffer.Substring(PosAss))

  End Sub
  Public Sub ReadCLT()
    Dim WrkAcre As Decimal

    WrkExempt = ""
    WrkCat = "1"
    WrkListNo = MyUtils.CnvSng(strBuffer.Substring(0, 6))
    WrkName = strBuffer.Substring(20, 35)
    WrkLoc = strBuffer.Substring(225, 25)
    WrkLocNo = Trim(strBuffer.Substring(220, 5))
    WrkMap = Trim(strBuffer.Substring(290, 17))
    WrkSName = strBuffer.Substring(60, 35)
    WrkAdd1 = strBuffer.Substring(100, 35)
    WrkAdd2 = strBuffer.Substring(140, 35)
    WrkCity = strBuffer.Substring(180, 25)
    WrkState = strBuffer.Substring(205, 2)
    WrkZip5 = MyUtils.CnvSng(strBuffer.Substring(210, 5))
    WrkZip4 = MyUtils.CnvSng(strBuffer.Substring(216, 4))
    WrkVol = Trim(strBuffer.Substring(255, 5))
    WrkPge = Trim(strBuffer.Substring(263, 5))
    WrkCode(0) = MyUtils.CnvSng(strBuffer.Substring(315, 4))
    WrkAcre = MyUtils.CnvSng(strBuffer.Substring(330, 8)) / 1000
    WrkAcres(0) = MyUtils.Round(WrkAcre, 2)
    If WrkAcres(0) = 0 Then
      WrkUnits(0) = 1
    Else
      WrkUnits(0) = 0
    End If
    WrkAssmnt(0) = MyUtils.CnvSng(strBuffer.Substring(319, 11))
    WrkTotGross = WrkAssmnt(0)
    WrkTotExam = 0
    WrkPurPrice = MyUtils.CnvSng(strBuffer.Substring(279, 11))
    WrkPurDt = MyUtils.CnvSng(strBuffer.Substring(271, 8))
  End Sub
  Public Sub ReadCLT2()
    WrkExempt = ""
    WrkCat = "1"
    WrkListNo = MyUtils.CnvSng(strBuffer.Substring(303, 5))
    WrkName = strBuffer.Substring(30, 35)
    WrkLoc = strBuffer.Substring(403, 25)
    WrkLocNo = MyUtils.CnvSng(strBuffer.Substring(383, 10))
    If Trim(strBuffer.Substring(393, 10)) <> String.Empty Then
      WrkLocNo = WrkLocNo & "-" & Trim(strBuffer.Substring(393, 10))
    End If
    WrkMap = Trim(strBuffer.Substring(0, 17))
    WrkSName = strBuffer.Substring(70, 35)
    WrkAdd1 = strBuffer.Substring(110, 35)
    WrkAdd2 = strBuffer.Substring(503, 35)
    WrkCity = strBuffer.Substring(190, 25)
    WrkState = strBuffer.Substring(230, 2)
    WrkZip5 = MyUtils.CnvSng(strBuffer.Substring(232, 5))
    WrkZip4 = MyUtils.CnvSng(strBuffer.Substring(238, 4))
    WrkVol = Trim(strBuffer.Substring(242, 5))
    WrkPge = Trim(strBuffer.Substring(250, 5))
    WrkCode(0) = MyUtils.CnvSng(strBuffer.Substring(443, 3))
    WrkAcres(0) = MyUtils.CnvSng(strBuffer.Substring(490, 14))
    If WrkAcres(0) = 0 Then
      WrkUnits(0) = 1
    Else
      WrkUnits(0) = 0
    End If
    WrkAssmnt(0) = MyUtils.CnvSng(strBuffer.Substring(477, 13))
    WrkTotGross = WrkAssmnt(0)
    WrkTotExam = 0
    'Hold for exempt property split 
    WrkBuilding = MyUtils.CnvSng(strBuffer.Substring(464, 13))
    WrkLand = MyUtils.CnvSng(strBuffer.Substring(451, 13))
  End Sub
  Public Sub ReadAdmins()
    Dim RecArray As String()
    Dim J As Integer
    RecArray = Parse(strBuffer, ",")
    'Assessments
    J = -1
    If MyUtils.CnvSng(RecArray(35)) > 0 Then
      J = J + 1
      WrkAssmnt(J) = RecArray(35)
      WrkCode(J) = MyUtils.CnvSng(RecArray(34))
      WrkUnits(J) = MyUtils.CnvSng(RecArray(33))
    End If
    If MyUtils.CnvSng(RecArray(38)) > 0 Then
      J = J + 1
      WrkAssmnt(J) = RecArray(38)
      WrkCode(J) = MyUtils.CnvSng(RecArray(37))
      WrkUnits(J) = MyUtils.CnvSng(RecArray(36))
    End If
    If MyUtils.CnvSng(RecArray(41)) > 0 Then
      J = J + 1
      WrkAssmnt(J) = RecArray(41)
      WrkCode(J) = MyUtils.CnvSng(RecArray(40))
      WrkUnits(J) = MyUtils.CnvSng(RecArray(39))
    End If
    If MyUtils.CnvSng(RecArray(44)) > 0 Then
      J = J + 1
      WrkAssmnt(J) = RecArray(44)
      WrkCode(J) = MyUtils.CnvSng(RecArray(43))
      WrkUnits(J) = MyUtils.CnvSng(RecArray(42))
    End If
    If MyUtils.CnvSng(RecArray(47)) > 0 Then
      J = J + 1
      WrkAssmnt(J) = RecArray(47)
      WrkCode(J) = MyUtils.CnvSng(RecArray(46))
      WrkUnits(J) = MyUtils.CnvSng(RecArray(45))
    End If
    'Exemptions
    J = -1
    If MyUtils.CnvSng(RecArray(61)) > 0 Then
      J = J + 1
      WrkExcd(J) = RecArray(61)
      WrkExam(J) = MyUtils.CnvSng(RecArray(62))
    End If
    If MyUtils.CnvSng(RecArray(63)) > 0 Then
      J = J + 1
      WrkExcd(J) = RecArray(63)
      WrkExam(J) = MyUtils.CnvSng(RecArray(64))
    End If
    If MyUtils.CnvSng(RecArray(65)) > 0 Then
      J = J + 1
      WrkExcd(J) = RecArray(65)
      WrkExam(J) = MyUtils.CnvSng(RecArray(66))
    End If
    If MyUtils.CnvSng(RecArray(67)) > 0 Then
      J = J + 1
      WrkExcd(J) = RecArray(67)
      WrkExam(J) = MyUtils.CnvSng(RecArray(68))
    End If
    If MyUtils.CnvSng(RecArray(69)) > 0 Then
      J = J + 1
      WrkExcd(J) = RecArray(69)
      WrkExam(J) = MyUtils.CnvSng(RecArray(70))
    End If
    If Trim(RecArray(2)) = "" Then
      WrkExempt = ""
      WrkCat = "1"
    Else
      WrkExempt = RecArray(2)
      WrkCat = "3"
    End If
    WrkListNo = RecArray(0)
    WrkName = Replace(RecArray(27), "  ", " ")
    WrkName = Trim(Mid(WrkName, 1, 35))
    WrkLoc = Trim(Mid(RecArray(11), 1, 25))
    WrkLocNo = MyUtils.JustifyRight(RecArray(10), 7)
    WrkMap = Trim(MyUtils.CnvSng(RecArray(15)))
    WrkSName = Replace(RecArray(28), "  ", " ")
    WrkSName = Trim(Mid(WrkSName, 1, 35))
    WrkAdd1 = Trim(Mid(RecArray(29), 1, 35))
    WrkAdd2 = ""
    SplitCityST(Trim(RecArray(30))) 'WrkCity/WrkState
    WrkZip5 = MyUtils.CnvSng(RecArray(31))
    WrkZip4 = MyUtils.CnvSng(RecArray(32))
    WrkVol = Trim(RecArray(19))
    WrkPge = Trim(RecArray(20))
    WrkTotGross = MyUtils.CnvSng(RecArray(80))
    WrkTotExam = MyUtils.CnvSng(RecArray(79))
    WrkPurPrice = MyUtils.CnvSng(RecArray(5))
    If Trim(RecArray(4)) <> "" Then
      WrkPurDt = MyUtils.SetDBDate(RecArray(4))
    Else
      WrkPurDt = 0
    End If
  End Sub
  Private Sub GetMissingCAMA()

    Dim WrkFlds As String
    Dim WrkQry As String
    Dim I As Integer
    Dim WrkAnd As String
    Dim WrkSelect As String
    Dim drTXREAL() As DataRow

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkFlds = ""
    WrkQry = ""
    SavePct = 0

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Reading Real Estate File"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    If dsTXREAL.Tables(0).Rows.Count = 0 Then GoTo CloseFiles

    For I = 0 To (dsTXREAL.Tables(0).Rows.Count - 1)
      With dsTXREAL.Tables(0).Rows(I)
        WrkSelect = "LISTNO=" & Str(.Item("list#"))
        drTXREAL = ds.Tables(0).Select(WrkSelect)
        If drTXREAL.GetUpperBound(0) = -1 Then
          dr = ds3.Tables(0).NewRow
          Select Case WrkSortBy
            Case "LIST#"
              dr("sortdata") = Format(.Item("list#"), "000000")
            Case "NAME"
              dr("sortdata") = .Item("name")
          End Select
          dr.Item("listno") = .Item("list#")
          dr.Item("name") = .Item("name")
          dr.Item("loc") = .Item("loc")
          dr.Item("locno") = MyUtils.JustifyRight(.Item("loc#"), 7)
          dr.Item("map") = .Item("map")
          dr.Item("gross") = .Item("gross")
          dr.Item("net") = .Item("net")
          dr.Item("exam") = .Item("exam1") + .Item("exam2") + .Item("exam3") + .Item("exam4") +
        .Item("exam5") + .Item("exam6") + .Item("exam7")
          ds3.Tables(0).Rows.Add(dr)
        End If
      End With
NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / dsTXREAL.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

CloseFiles:
    myFrmProgress.Close()

  End Sub
  Private Sub CalcPhaseInAssessment(ByVal WrkList As Integer)

    Dim I As Integer
    Dim J As Integer

    Dim WrkOrigNew(6) As Integer
    Dim VisionMatched(6) As Boolean
    Dim OrigMatched(6) As Boolean
    Dim WrkOrigAssmnt As Integer
    Dim WrkIncrease As Integer
    Dim UnmatchedOrigTotal As Integer
    Dim UnmatchedVisionTotal As Integer

    myTXPHIN.GetOneRecordP(WrkList, WrkGLYear)
    If myTXPHIN.RecordNotFound Then Exit Sub

    With myTXPHIN
      WrkOrigCode(0) = ._ORIC1 : WrkOrigAmt(0) = ._ORIA1
      WrkOrigCode(1) = ._ORIC2 : WrkOrigAmt(1) = ._ORIA2
      WrkOrigCode(2) = ._ORIC3 : WrkOrigAmt(2) = ._ORIA3
      WrkOrigCode(3) = ._ORIC4 : WrkOrigAmt(3) = ._ORIA4
      WrkOrigCode(4) = ._ORIC5 : WrkOrigAmt(4) = ._ORIA5
      WrkOrigCode(5) = ._ORIC6 : WrkOrigAmt(5) = ._ORIA6
      WrkOrigCode(6) = ._ORIC7 : WrkOrigAmt(6) = ._ORIA7
    End With

    ' First pass:
    ' Determine which Vision and Original buckets match.
    For I = 0 To 6
      If WrkCode(I) <> 0 Then
        For J = 0 To 6
          If WrkOrigCode(J) <> 0 AndAlso WrkOrigCode(J) = WrkCode(I) Then
            VisionMatched(I) = True
            OrigMatched(J) = True
            Exit For
          End If
        Next
      End If
    Next

    ' Total all unmatched ORIGINAL buckets.
    UnmatchedOrigTotal = 0

    For J = 0 To 6
      If WrkOrigCode(J) <> 0 AndAlso Not OrigMatched(J) Then
        UnmatchedOrigTotal += WrkOrigAmt(J)
      End If
    Next

    ' Total all unmatched VISION buckets.
    UnmatchedVisionTotal = 0

    For I = 0 To 6
      If WrkCode(I) <> 0 AndAlso Not VisionMatched(I) Then
        UnmatchedVisionTotal += WrkFullAssmnt(I)
      End If
    Next
    ' Calculate current assessment.
    WrkTotGross = 0
    For I = 0 To 6
      If WrkCode(I) = 0 Then
        WrkAssmnt(I) = 0
      ElseIf VisionMatched(I) Then
        ' Exact code match.
        ' Original comes directly from ORIA.
        WrkOrigAssmnt = 0
        For J = 0 To 6
          If WrkOrigCode(J) = WrkCode(I) Then
            WrkOrigAssmnt = WrkOrigAmt(J)
            Exit For
          End If
        Next
        ' FUL = Vision - Original
        WrkIncrease = WrkFullAssmnt(I) - WrkOrigAssmnt
        WrkAssmnt(I) = WrkOrigAssmnt + Math.Round((WrkIncrease * WrkCurrYear) / WrkTotalYears, 0, MidpointRounding.AwayFromZero)
        WrkFullAssmnt(I) = WrkIncrease
        WrkOrigNew(I) = WrkOrigAssmnt
      Else
        ' No exact code match.
        ' Redistribute ALL unmatched original assessment
        ' according to this Vision bucket's percentage
        ' of the unmatched Vision total.
        If UnmatchedVisionTotal <> 0 Then
          WrkOrigAssmnt = Math.Round(UnmatchedOrigTotal * (WrkFullAssmnt(I) / UnmatchedVisionTotal), 0, MidpointRounding.AwayFromZero)
        Else
          WrkOrigAssmnt = 0
        End If
        ' FUL = Vision - recalculated original
        WrkIncrease = WrkFullAssmnt(I) - WrkOrigAssmnt
        WrkAssmnt(I) = WrkOrigAssmnt + Math.Round((WrkIncrease * WrkCurrYear) / WrkTotalYears, 0, MidpointRounding.AwayFromZero)
        WrkFullAssmnt(I) = WrkIncrease
        WrkOrigNew(I) = WrkOrigAssmnt
      End If
      WrkTotGross += WrkAssmnt(I)
    Next

    'Replace Original
    For I = 0 To 6
      WrkOrigAmt(I) = WrkOrigNew(I)
      WrkOrigCode(I) = WrkCode(I)
    Next
    WrkTotNet = WrkTotGross - WrkTotExam
  End Sub
  Private Sub UpdateTXREAL()
    Dim WrkAdd As Boolean

    With myTXREAL
      WrkAdd = False
      If myTXREAL.RecordNotFound Then
        If Not WrkAddMissing Then Exit Sub
        ._LISTNO = WrkListNo
        WrkAdd = True
      End If
      If WrkUpName Or WrkAdd Then
        ._NAME = Mid(WrkName, 1, 35)
        ._LETT = Mid(WrkName, 1, 1)
        ._SNAME = Mid(WrkSName, 1, 35)
        ._ADD1 = Mid(WrkAdd1, 1, 35)
        ._ADD2 = Mid(WrkAdd2, 1, 35)
        ._CITY = Mid(WrkCity, 1, 25)
        ._STATE = WrkState
        ._ZIP5 = WrkZip5
        ._ZIP4 = WrkZip4
      End If
      If WrkUpAssessment Then
        ._GROSS = WrkTotGross
        ._NET = WrkTotNet
        ._CODE1 = MyUtils.CnvSng(WrkCode(0))
        ._CODE2 = MyUtils.CnvSng(WrkCode(1))
        ._CODE3 = MyUtils.CnvSng(WrkCode(2))
        ._CODE4 = MyUtils.CnvSng(WrkCode(3))
        ._CODE5 = MyUtils.CnvSng(WrkCode(4))
        ._CODE6 = MyUtils.CnvSng(WrkCode(5))
        ._CODE7 = MyUtils.CnvSng(WrkCode(6))
        ._UNIT1 = WrkUnits(0)
        ._UNIT2 = WrkUnits(1)
        ._UNIT3 = WrkUnits(2)
        ._UNIT4 = WrkUnits(3)
        ._UNIT5 = WrkUnits(4)
        ._UNIT6 = WrkUnits(5)
        ._UNIT7 = WrkUnits(6)
        ._ASS1 = WrkAssmnt(0)
        ._ASS2 = WrkAssmnt(1)
        ._ASS3 = WrkAssmnt(2)
        ._ASS4 = WrkAssmnt(3)
        ._ASS5 = WrkAssmnt(4)
        ._ASS6 = WrkAssmnt(5)
        ._ASS7 = WrkAssmnt(6)
      End If
      If WrkUpAcreage Then
        ._ACRE1 = WrkAcres(0)
        ._ACRE2 = WrkAcres(1)
        ._ACRE3 = WrkAcres(2)
        ._ACRE4 = WrkAcres(3)
        ._ACRE5 = WrkAcres(4)
        ._ACRE6 = WrkAcres(5)
        ._ACRE7 = WrkAcres(6)
      End If
      If WrkUpExemption Then
        ._EXCD1 = WrkExcd(0)
        ._EXAM1 = WrkExam(0)
        ._EXCD2 = WrkExcd(1)
        ._EXAM2 = WrkExam(1)
        ._EXCD3 = WrkExcd(2)
        ._EXAM3 = WrkExam(2)
        ._EXCD4 = WrkExcd(3)
        ._EXAM4 = WrkExam(3)
        ._EXCD5 = WrkExcd(4)
        ._EXAM5 = WrkExam(4)
        ._EXCD6 = WrkExcd(5)
        ._EXAM6 = WrkExam(5)
        ._EXCD7 = WrkExcd(6)
        ._EXAM7 = WrkExam(6)
      End If
      If WrkUpOther Then
        ._MAP = MyUtils.JustifyLeft(WrkMap, 17)
        ._LOCNO = MyUtils.JustifyRight(WrkLocNo, 7)
        ._LOC = Mid(WrkLoc, 1, 25)
        ._VOL = Mid(WrkVol, 1, 5)
        ._PGE = Mid(WrkPge, 1, 5)
      End If
      If WrkUpPurchase Then
        ._PURPR = WrkPurPrice
        ._PURDT = WrkPurDt
      End If
      If WrkUpPrtDist Then
        ._PDST = WrkPrtDist
      End If
      If WrkUpCat Or WrkAdd Then
        ._CAT = WrkCat
        ._EXMPT = WrkExempt
        If myTOWN._TOWNBR = 45 Then 'East Lyme
          ._CAT = WrkCat
          If WrkCat = "1" Then
            ._EXMPT = ""
          End If
        End If
      End If
      ._TYPE = "R"
      If Not myTXREAL.RecordNotFound Then
        myTXREAL.UpdateOneRecordP()
        If .ErrMsg <> "" Then
          WriteErrorLog(.ErrMsg)
          Exit Sub
        End If
      Else
        If Trim(._CAT) = "" Then
          ._CAT = "1"
          ._EXMPT = ""
        End If
        myTXREAL.AddOneRecordP()
        If .ErrMsg <> "" Then
          WriteErrorLog(.ErrMsg)
          Exit Sub
        End If
      End If
    End With

  End Sub
  Private Sub UpdateTXPHIN(ByVal WrkList As Integer, ByVal WrkBTR As Integer)
    Dim WrkYearsLeft As Integer
    Dim WrkCapAmt(6) As Integer
    Dim I As Integer

    With myTXPHIN
      .GetOneRecordP(WrkList, WrkGLYear)

      ' TXPHIN is a tracking file.  Do not manufacture a phase-in row
      ' for an existing TXREAL parcel that has no tracking record.
      If .RecordNotFound Then
        If Not WrkNewTXREAL Then Exit Sub
        ._LISTNo = WrkList
        ._TXYEAR = WrkGLYear
        ._ORIGRS = 0
        ._ORIA1 = 0 : ._ORIA2 = 0 : ._ORIA3 = 0 : ._ORIA4 = 0
        ._ORIA5 = 0 : ._ORIA6 = 0 : ._ORIA7 = 0
        ._ORIC1 = 0 : ._ORIC2 = 0 : ._ORIC3 = 0 : ._ORIC4 = 0
        ._ORIC5 = 0 : ._ORIC6 = 0 : ._ORIC7 = 0
      End If

      If ._ORIGRS = 0 Then
        WrkYearsLeft = WrkTotalYears - WrkCurrYear + 1
      Else
        WrkYearsLeft = WrkTotalYears
      End If
      For I = 0 To 6
        ' CAPA is the annual phase-in amount using years left.
        WrkCapAmt(I) = Math.Round(WrkFullAssmnt(I) / WrkYearsLeft, 0, MidpointRounding.AwayFromZero)
      Next

      ._ORIA1 = WrkOrigAmt(0) : ._ORIA2 = WrkOrigAmt(1) : ._ORIA3 = WrkOrigAmt(2)
      ._ORIA4 = WrkOrigAmt(3) : ._ORIA5 = WrkOrigAmt(4) : ._ORIA6 = WrkOrigAmt(5) : ._ORIA7 = WrkOrigAmt(6)
      ._ORIC1 = WrkCode(0) : ._ORIC2 = WrkCode(1) : ._ORIC3 = WrkCode(2)
      ._ORIC4 = WrkCode(3) : ._ORIC5 = WrkCode(4) : ._ORIC6 = WrkCode(5) : ._ORIC7 = WrkCode(6)
      ._ORIGRS = WrkOrigAmt(0) + WrkOrigAmt(1) + WrkOrigAmt(2) + WrkOrigAmt(3) + WrkOrigAmt(4) + WrkOrigAmt(5) + WrkOrigAmt(6)

      ._FULA1 = WrkFullAssmnt(0) : ._FULA2 = WrkFullAssmnt(1) : ._FULA3 = WrkFullAssmnt(2)
      ._FULA4 = WrkFullAssmnt(3) : ._FULA5 = WrkFullAssmnt(4) : ._FULA6 = WrkFullAssmnt(5)
      ._FULA7 = WrkFullAssmnt(6)
      ._FULC1 = WrkCode(0) : ._FULC2 = WrkCode(1) : ._FULC3 = WrkCode(2)
      ._FULC4 = WrkCode(3) : ._FULC5 = WrkCode(4) : ._FULC6 = WrkCode(5) : ._FULC7 = WrkCode(6)
      ._FULGRS = WrkFullAssmnt(0) + WrkFullAssmnt(1) + WrkFullAssmnt(2) + WrkFullAssmnt(3) + WrkFullAssmnt(4) + WrkFullAssmnt(5) + WrkFullAssmnt(6)

      ._CAPA1 = WrkCapAmt(0) : ._CAPA2 = WrkCapAmt(1) : ._CAPA3 = WrkCapAmt(2)
      ._CAPA4 = WrkCapAmt(3) : ._CAPA5 = WrkCapAmt(4) : ._CAPA6 = WrkCapAmt(5)
      ._CAPA7 = WrkCapAmt(6)
      ._CAPC1 = WrkCode(0) : ._CAPC2 = WrkCode(1) : ._CAPC3 = WrkCode(2)
      ._CAPC4 = WrkCode(3) : ._CAPC5 = WrkCode(4) : ._CAPC6 = WrkCode(5) : ._CAPC7 = WrkCode(6)
      ._CAPGRS = WrkCapAmt(0) + WrkCapAmt(1) + WrkCapAmt(2) + WrkCapAmt(3) + WrkCapAmt(4) + WrkCapAmt(5) + WrkCapAmt(6)
      If .RecordNotFound Then
        .AddOneRecordP()
      Else
        .UpdateOneRecordP()
      End If
    End With
  End Sub

  Private Sub SplitCityST(ByVal WrkCityST As String)
    Dim Pos As Integer
    WrkCity = ""
    WrkState = ""
    WrkCityST = Replace(WrkCityST, "  ", " ")
    Pos = InStrRev(WrkCityST, " ")
    If Len(WrkCityST) = Pos + 2 Then
      WrkCity = Mid(WrkCityST, 1, Pos - 1)
      WrkCity = Mid(WrkCity, 1, 25)
      WrkState = Mid(WrkCityST, Pos + 1, 2)
    Else
      WrkCity = WrkCityST
      WrkState = ""
    End If
  End Sub
  Private Function CheckError(ByVal WrkListNo As Integer) As String
    Dim I As Integer
    Dim WrkInt As Integer
    Dim WrkStr As String
    Dim WrkError As String

    WrkError = String.Empty
    For I = 0 To 6
      WrkInt = StripDash(WrkCode(I))
      If WrkInt > 0 Then
        WrkStr = LookupOPMCode(WrkInt)
        If WrkStr = String.Empty Then
          WrkError = "Invalid Assessment Code"
          Return WrkError
        End If
      End If
    Next

    If WrkZip5 < 0 Then
      WrkError = "Invalid Zip Code"
      Return WrkError
    End If
    If WrkZip4 < 0 Then
      WrkError = "Invalid Zip Plus 4 Code"
      Return WrkError
    End If

    If WrkPurDt > 0 Then
      If Not CheckDate(MyUtils.GetDBDate(WrkPurDt)) Then
        WrkError = "Invalid Purchase Date"
        Return WrkError
      End If
    End If

    If MyUtils.CnvSng(WrkCode(7)) > 0 Then
      WrkError = "More than 7 assessment codes"
      Return WrkError
    End If

    If MyUtils.CnvSng(WrkCode(7)) > 0 Then
      WrkError = "More than 7 exemption codes"
      Return WrkError
    End If

    Return WrkError
  End Function

End Module







