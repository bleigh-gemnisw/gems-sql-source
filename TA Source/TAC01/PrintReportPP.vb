Imports System.io
Imports System.Text
Module PrintReportPP

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXPPRP As TXPPRP.MyData
  Dim myTXPPRPQ As TXPPRPQ.MyData
  Dim myDBUTILS As DBUtils.Utils

  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim ds3 As DataSet = New DataSet
  Dim ds4 As DataSet = New DataSet
  Dim dsTotMC As DataSet = New DataSet
  Dim dsErr As DataSet = New DataSet
  Dim dr As DataRow

  'Screen fields
  Dim WrkCAMA As String
  Dim WrkBackup As Boolean
  Dim WrkUpFile As Boolean
  Dim WrkUpName As Boolean
  Dim WrkUpAssessment As Boolean
  Dim WrkUpOther As Boolean
  Dim WrkAddMissing As Boolean
  Dim WrkSortBy As String
  'Work fields
  Dim WrkListNo As Integer
  Dim WrkCat As String
  Dim WrkDist As Integer
  Dim WrkName As String
  Dim WrkSName As String
  Dim WrkAdd1 As String
  Dim WrkAdd2 As String
  Dim WrkCity As String
  Dim WrkState As String
  Dim WrkZip5 As Integer
  Dim WrkZip4 As Integer
  Dim WrkLocNo As String
  Dim WrkLoc As String
  Dim WrkCode(9) As String
  Dim WrkAssmnt(9) As Integer
  Dim WrkUnits(9) As Decimal
  Dim WrkExam(4) As Integer
  Dim WrkExcd(4) As String
  Dim WrkTotGross As Integer
  Dim WrkTotNet As Integer
  Dim WrkTotExam As Integer

  Dim strBuffer As String

  Public Sub PrtReportPP()

    myTXPPRP = New TXPPRP.MyData(myDBConnect)
    myTXPPRPQ = New TXPPRPQ.MyData(myDBConnect)
    myDBUTILS = New DBUtils.Utils(myDBConnect)

    WrkBackup = False
    WrkUpFile = False
    WrkUpAssessment = False
    WrkUpOther = False
    WrkAddMissing = False

    With MyFrmTAC01B
      If .ChkBackup.Checked = True Then WrkBackup = True
      If .ChkPost.Checked = True Then WrkUpFile = True
      If .ChkName.Checked = True Then WrkUpName = True
      If .ChkAssmnt.Checked = True Then WrkUpAssessment = True
      If .ChkOther.Checked = True Then WrkUpOther = True
      If .ChkAddList.Checked = True Then WrkAddMissing = True
      If .RbVision.Checked Then
        WrkCAMA = "Vision"
      End If
      If .RbProVal.Checked Then
        WrkCAMA = "ProVal"
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

    BufferCodes("P")
    GetDetail()
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
    Dim WrkErrorMsg As String
    Dim I As Integer
    Dim J As Integer
    Dim K As Integer

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    ' If Posting  Save the existing file 1st...
    If WrkUpFile = True Then
      myFrmProgress.Text = "Saving Current Personal Property Assessor Data"
      myFrmProgress.ProgBar1.Visible = False
      myFrmProgress.LblMsg.Text = "Saving Personal Property Assesor Data"
      myFrmProgress.Refresh()
      Application.DoEvents()
      If WrkBackup Then
        myDBUTILS.DeleteAllRecs("CAMPPRP")
        myDBUTILS.CopyData("TXPPRP", "CAMPPRP")
      End If
    End If

    myFrmProgress.Text = "CAMA Personal Property Bridge "
    myFrmProgress.ProgBar1.Visible = True
    myFrmProgress.LblMsg.Text = ""
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length

NextLine:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo Cleanup
      Exit Sub
    End If

    I = I + strBuffer.Length

    If strBuffer.Substring(0, 1) = "~" Then
      GoTo NextRec
      Exit Sub
    End If

    Select Case WrkCAMA
      Case Is = "ProVal"
        ReadProVal()
      Case Is = "Vision"
        ReadVision()
    End Select

    myTXPPRP.GetOneRecordP(WrkListNo)
    If Not myTXPPRP.RecordNotFound Then
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
    dr("cname") = WrkName
    dr("cloc") = WrkLoc
    dr("clocno") = WrkLocNo
    dr("cadd1") = WrkAdd1
    dr("cadd2") = WrkAdd2
    If Not myTXPPRP.RecordNotFound Then
      With myTXPPRP
        If WrkSortBy = "NAME" Then
          dr("sortdata") = ._NAME
        End If
        dr("name") = ._NAME
        dr("loc") = ._LOC
        dr("locno") = Trim(._LOCNO)
        dr("gross") = ._GROSS
        dr("net") = ._NET
        dr("exam") = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5
      End With
    End If
    dr("cgross") = WrkTotGross
    dr("cnet") = WrkTotNet
    dr("cexam") = WrkTotExam

    WrkErrorMsg = CheckError(WrkListNo)
    If WrkErrorMsg <> String.Empty Then
      dr = dsErr.Tables(0).NewRow
      Select Case WrkSortBy
        Case "LIST#"
          dr("sortdata") = Format(WrkListNo, "000000")
        Case "NAME"
          dr("sortdata") = WrkName
      End Select
      dr("listno") = WrkListNo
      dr("name") = WrkName
      dr("loc") = WrkLoc
      dr("locno") = WrkLocNo
      dr("errmsg") = WrkErrorMsg
      dsErr.Tables(0).Rows.Add(dr)
      GoTo NextRec
    End If

    If Not myTXPPRP.RecordNotFound Then
      ds.Tables(0).Rows.Add(dr)
    Else
      ds2.Tables(0).Rows.Add(dr)
    End If

    'CAMA Totals
    For J = 0 To 9
      If Not IsNothing(WrkCode(J)) Then
        WrkCode(J) = StripDash(WrkCode(J))
        K = LookupWrkTMCCode(WrkCode(J))
        If WrkAssmnt(J) > 0 Then
          WrkTMCCode(K) = WrkCode(J)
          WrkTMCCount(K) = WrkTMCCount(K) + 1
          WrkTMCGross(K) = WrkTMCGross(K) + WrkAssmnt(J)
        End If
      End If
    Next J

    If WrkUpFile Then
      UpdateTXPPRP()
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
      dr.Item("tmcdesc") = GetTXCodeDesc(WrkTMCCode(I), "P")
      dr.Item("tmccount") = WrkTMCCount(I)
      dr.Item("tmcgross") = WrkTMCGross(I)
      dsTotMC.Tables(0).Rows.Add(dr)
    Next I

    sr.Close()
    myFrmProgress.Close()
    myTXPPRP.CloseFile()

  End Sub
  Public Sub ReadVision()
    Dim J As Integer
    Dim K As Integer

    WrkListNo = MyUtils.CnvSng(strBuffer.Substring(0, 6))
    WrkCat = "5"
    WrkLoc = strBuffer.Substring(20, 25)
    WrkLocNo = Trim(strBuffer.Substring(15, 5))
    WrkName = strBuffer.Substring(75, 30)
    WrkSName = strBuffer.Substring(45, 30)
    WrkAdd1 = strBuffer.Substring(105, 30)
    WrkAdd2 = strBuffer.Substring(135, 30)
    WrkCity = strBuffer.Substring(165, 18)
    WrkState = strBuffer.Substring(183, 2)
    WrkZip5 = MyUtils.CnvSng(strBuffer.Substring(185, 5))
    WrkZip4 = MyUtils.CnvSng(strBuffer.Substring(191, 4))
    WrkDist = MyUtils.CnvSng(strBuffer.Substring(194, 3))
    WrkTotGross = 0
    WrkTotNet = 0
    WrkTotExam = 0
    Array.Clear(WrkExcd, 0, 4)
    Array.Clear(WrkExam, 0, 4)
    K = 0
    For J = 0 To 9
      WrkAssmnt(J) = 0
      WrkCode(J) = String.Empty
      ReadVisionAssmnt(J, K)
      WrkTotGross = WrkTotGross + WrkAssmnt(J)
    Next
    For J = 0 To 4
      WrkTotExam = WrkTotExam + WrkExam(J)
    Next
    WrkTotNet = WrkTotGross - WrkTotExam
  End Sub
  Private Sub ReadVisionAssmnt(ByVal I As Integer, ByRef K As Integer)
    Dim PosAss As Integer
    Dim PosCode As Integer

    PosAss = 232 + (I * 40)
    PosCode = 201 + (I * 40)

    If MyUtils.CnvSng(strBuffer.Substring(PosAss, 9)) = 0 Then Exit Sub
    If IsNumeric(strBuffer.Substring(PosCode, 5)) Then
      WrkCode(I) = MyUtils.CnvSng(strBuffer.Substring(PosCode, 5)) * 10
      If WrkCode(I) > 0 Then
        WrkUnits(I) = 1
      End If
      WrkAssmnt(I) = MyUtils.CnvSng(strBuffer.Substring(PosAss, 9))
    Else
      WrkExcd(K) = Trim(strBuffer.Substring(PosCode, 5))
      WrkExam(K) = MyUtils.CnvSng(strBuffer.Substring(PosAss, 9))
      K = K + 1
    End If
  End Sub
  Public Sub ReadProVal()
    WrkListNo = MyUtils.CnvSng(strBuffer.Substring(1, 6))
    WrkCat = "5"
    WrkName = strBuffer.Substring(7, 35)
    WrkLoc = ""
    WrkLocNo = ""
    WrkSName = strBuffer.Substring(42, 35)
    WrkAdd1 = strBuffer.Substring(77, 35)
    WrkAdd2 = ""
    WrkCity = strBuffer.Substring(112, 25)
    WrkState = strBuffer.Substring(137, 2)
    WrkZip5 = MyUtils.CnvSng(strBuffer.Substring(139, 5))
    WrkZip4 = MyUtils.CnvSng(strBuffer.Substring(144, 4))
    WrkTotGross = 0
    WrkTotNet = 0
    WrkTotExam = 0
    WrkCode(0) = strBuffer.Substring(148, 3)
    WrkUnits(0) = MyUtils.CnvSng(strBuffer.Substring(151, 3))
    WrkAssmnt(0) = MyUtils.CnvSng(strBuffer.Substring(154, 10))
    WrkTotGross = WrkTotGross + WrkAssmnt(0)
    WrkTotNet = WrkTotGross - WrkTotExam
  End Sub
  Private Sub GetMissingCAMA()

    Dim dsTXPPRP As DataSet = New DataSet
    Dim WrkFlds As String
    Dim WrkQry As String
    Dim I As Integer
    Dim WrkAnd As String
    Dim WrkSelect As String
    Dim drTXPPRP() As DataRow

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkFlds = "LIST#"
    WrkQry = ""
    SavePct = 0

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Reading Personal Property File"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    dsTXPPRP = myTXPPRPQ.GetQry(WrkFlds, WrkQry, 0)
    If dsTXPPRP.Tables(0).Rows.Count = 0 Then GoTo CloseFiles

    For I = 0 To (dsTXPPRP.Tables(0).Rows.Count - 1)
      With dsTXPPRP.Tables(0).Rows(I)
        WrkSelect = "LISTNO=" & Str(.Item("list#"))
        drTXPPRP = ds.Tables(0).Select(WrkSelect)
        If drTXPPRP.GetUpperBound(0) = -1 Then
          drTXPPRP = ds2.Tables(0).Select(WrkSelect)
        End If
        If drTXPPRP.GetUpperBound(0) = -1 Then
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
          dr.Item("locno") = Trim(.Item("loc#"))
          dr.Item("gross") = .Item("gross")
          dr.Item("net") = .Item("net")
          dr.Item("exam") = .Item("exam1") + .Item("exam2") + .Item("exam3") + .Item("exam4") +
        .Item("exam5")
          ds3.Tables(0).Rows.Add(dr)
        End If
      End With
NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / dsTXPPRP.Tables(0).Rows.Count) * 100
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
    myTXPPRPQ.CloseFile()

  End Sub
  Private Sub UpdateTXPPRP()

    With myTXPPRP
      If myTXPPRP.RecordNotFound Then
        If Not WrkAddMissing Then Exit Sub
        ._LISTNO = WrkListNo
      End If
      If WrkUpName Then
        ._DIST = WrkDist
        ._NAME = WrkName
        ._LETT = Mid(WrkName, 1, 1)
        ._SNAME = WrkSName
        ._ADD1 = WrkAdd1
        ._ADD2 = WrkAdd2
        ._CITY = WrkCity
        ._STATE = WrkState
        ._ZIP5 = WrkZip5
        ._ZIP4 = WrkZip4
      End If
      If WrkUpAssessment Then
        ._GROSS = WrkTotGross
        ._EXAM1 = WrkExam(0)
        ._EXAM2 = WrkExam(1)
        ._EXAM3 = WrkExam(2)
        ._EXAM4 = WrkExam(3)
        ._EXAM5 = WrkExam(4)
        ._EXCD1 = WrkExcd(0)
        ._EXCD2 = WrkExcd(1)
        ._EXCD3 = WrkExcd(2)
        ._EXCD4 = WrkExcd(3)
        ._EXCD5 = WrkExcd(4)
        ._NET = WrkTotNet
        ._CODE1 = WrkCode(0)
        ._CODE2 = WrkCode(1)
        ._CODE3 = WrkCode(2)
        ._CODE4 = WrkCode(3)
        ._CODE5 = WrkCode(4)
        ._CODE6 = WrkCode(5)
        ._CODE7 = WrkCode(6)
        ._CODE8 = WrkCode(7)
        ._CODE9 = WrkCode(8)
        ._CODEA = WrkCode(9)
        ._UNIT1 = WrkUnits(0)
        ._UNIT2 = WrkUnits(1)
        ._UNIT3 = WrkUnits(2)
        ._UNIT4 = WrkUnits(3)
        ._UNIT5 = WrkUnits(4)
        ._UNIT6 = WrkUnits(5)
        ._UNIT7 = WrkUnits(6)
        ._UNIT8 = WrkUnits(7)
        ._UNIT9 = WrkUnits(8)
        ._UNITA = WrkUnits(9)
        ._ASS1 = WrkAssmnt(0)
        ._ASS2 = WrkAssmnt(1)
        ._ASS3 = WrkAssmnt(2)
        ._ASS4 = WrkAssmnt(3)
        ._ASS5 = WrkAssmnt(4)
        ._ASS6 = WrkAssmnt(5)
        ._ASS7 = WrkAssmnt(6)
        ._ASS8 = WrkAssmnt(7)
        ._ASS9 = WrkAssmnt(8)
        ._ASS10 = WrkAssmnt(9)
      End If
      If WrkUpOther Then
        ._LOCNO = MyUtils.JustifyRight(WrkLocNo, 7)
        ._LOC = WrkLoc
      End If
      ._TYPE = "P"
      If Not myTXPPRP.RecordNotFound Then
        myTXPPRP.UpdateOneRecordP()
        If .ErrMsg <> "" Then
          WriteErrorLog(.ErrMsg)
          Exit Sub
        End If
      Else
        myTXPPRP.AddOneRecordP()
        If .ErrMsg <> "" Then
          WriteErrorLog(.ErrMsg)
          Exit Sub
        End If
      End If
    End With

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

    Return WrkError
  End Function

End Module







