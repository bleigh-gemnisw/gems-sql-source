Imports System.IO
Imports System.Text
Module ImportData

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXPPRP As TXPPRP.MyData
  Dim myTAXCOM As TAXCOM.MyData
  Dim myDBUTILS As DBUtils.Utils

  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim ds3 As DataSet = New DataSet
  Dim dsTot As DataSet = New DataSet
  Dim dsErr As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkBackup As Boolean
  Dim WrkName As Boolean
  Dim WrkMailAddr As Boolean
  Dim WrkLoc As Boolean
  Dim WrkPropCode As Boolean
  Dim WrkExemptCode As Boolean
  Dim WrkMVRound As String
  Dim WrkOtherRound As String
  Dim WrkComments As Boolean
  Dim WrkPost As Boolean
  Dim WrkMissing As Boolean
  Dim WrkZero As Boolean
  Dim WrkSortBy As String
  'Import File fields
  Dim ImpListNo As Integer
  Dim ImpName As String
  Dim ImpSname As String
  Dim ImpAddr As String
  Dim ImpCity As String
  Dim ImpState As String
  Dim ImpZip5 As Integer
  Dim ImpZip4 As Integer
  Dim ImpLocNo As String
  Dim ImpLoc As String
  'Globals
  Dim SArray As String()
  Dim NCode(9) As Integer
  Dim NAss(9) As Integer
  Dim NExcd(4) As String
  Dim NExam(4) As Integer
  'Totals
  Dim TGross(1) As Integer
  Dim TExam(1) As Integer
  Dim TNet(1) As Integer
  Public Sub Impdata()
    myTXPPRP = New TXPPRP.MyData(myDBConnect)
    myTAXCOM = New TAXCOM.MyData(myDBConnect)
    myDBUTILS = New DBUtils.Utils(myDBConnect)

    With MyFrmTAP30B
      WrkBackup = False
      If .ChkBackup.Checked Then WrkBackup = True
      WrkName = False
      If .ChkName.Checked Then WrkName = True
      WrkMailAddr = False
      If .ChkMailAddr.Checked Then WrkMailAddr = True
      WrkLoc = False
      If .ChkLoc.Checked Then WrkLoc = True
      WrkPropCode = False
      If .ChkPropCode.Checked Then WrkPropCode = True
      WrkExemptCode = False
      If .ChkExemptCode.Checked Then WrkExemptCode = True
      WrkComments = False
      If .ChkComments.Checked Then WrkComments = True
      WrkPost = False
      If .ChkPost.Checked Then WrkPost = True
      WrkMissing = False
      If .ChkMissing.Checked Then WrkMissing = True
      WrkZero = False
      If .ChkZero.Checked Then WrkZero = True
      If .RbSortName.Checked Then WrkSortBy = "NAME"
      If .RbSortList.Checked Then WrkSortBy = "LIST#"
      WrkMVRound = String.Empty
      If .RbMVNormal.Checked Then WrkMVRound = "Normal"
      If .RbMVDown.Checked Then WrkMVRound = "Down"
      WrkOtherRound = String.Empty
      If .RbOtherNormal.Checked Then WrkOtherRound = "Normal"
      If .RbOtherDown.Checked Then WrkOtherRound = "Down"
    End With

    If ds.Tables.Count = 0 Then
      BuildDs(ds)
      ds2 = ds.Clone
      BuildDsTot(dsTot)
      BuildDsErr(dsErr)
    Else
      ds.Clear()
      ds2.Clear()
      dsTot.Clear()
      dsErr.Clear()
    End If
    GetDetail()
    WriteTotals()

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .Wrkds2 = ds2
      .WrkdsTot = dsTot
      .WrkdsErr = dsErr
      .Show()
    End With

  End Sub
  Private Sub GetDetail()
    Dim WrkStream As FileStream
    Dim sr As StreamReader
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim K As Integer
    Dim WrkNAssTot As Integer
    Dim WrkNExTot As Integer
    Dim WrkValue As Integer
    Dim WrkAddZero As String
    Dim Counter As Integer

    Counter = 0
    Array.Clear(TNet, 0, 1)
    Array.Clear(TGross, 0, 1)
    Array.Clear(TExam, 0, 1)
    Array.Clear(TNet, 0, 1)

    Try
      WrkStream = New FileStream(MyFrmTAP30B.LblFilePath.Text, FileMode.Open, FileAccess.Read, FileShare.Read)
    Catch ex As Exception
      MsgBox(ex.Message, MsgBoxStyle.Critical, "Cannot process file")
      Exit Sub
    End Try
    SR = New StreamReader(WrkStream)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    If WrkBackup Then
      myDBUTILS.DeleteAllRecs("CAMPPRP")
      myDBUTILS.CopyData("TXPPRP", "CAMPPRP")
    End If

    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Headers

NextLine:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo End_of_file
      Exit Sub
    End If


    SArray = Parse(strBuffer, ",")
    I = I + strBuffer.Length
    With myTXPPRP
      ImpListNo = MyUtils.CnvSng(SArray(1))
      ImpName = UCase(ConvertString("Name", SArray(2), 35))
      ImpSname = UCase(ConvertString("Second Name", SArray(3), 35))
      ImpAddr = UCase(ConvertString("Address", SArray(4), 35))
      ImpCity = UCase(ConvertString("City", SArray(5), 35))
      ImpState = UCase(ConvertString("State", SArray(6), 25))
      ImpZip5 = MyUtils.CnvSng(SArray(7))
      ImpZip4 = MyUtils.CnvSng(SArray(8))
      ImpLocNo = UCase(MyUtils.JustifyRight(ConvertString("Loc No", SArray(9), 7), 7))
      ImpLoc = UCase(ConvertString("Loc", SArray(10), 25))
      WrkAddZero = ""
      If myTOWN._TOWNBR = 45 Or myTOWN._TOWNBR = 84 Then
        WrkAddZero = "0"
      End If
      .GetOneRecordP(ImpListNo)
      If .RecordNotFound Then
        dr = dsErr.Tables(0).NewRow
        Select Case WrkSortBy
          Case "LIST#"
            dr("sortdata") = Format(ImpListNo, "000000")
          Case "NAME"
            dr("sortdata") = ImpName
        End Select
        dr.Item("listno") = ImpListNo
        dr.Item("name") = ImpName
        dr.Item("excd") = String.Empty
        dr.Item("exam") = 0
        dr.Item("errmsg") = "Record not found in PP master"
        dsErr.Tables(0).Rows.Add(dr)
        GoTo NextRec
      End If
      WrkNAssTot = 0
      WrkNExTot = 0
      Array.Clear(NCode, 0, 10)
      Array.Clear(NAss, 0, 10)
      For I = 0 To 4
        NExcd(I) = ""
      Next
      Array.Clear(NExam, 0, 5)
      'Property Codes 9 to 24 are in array buckets 12 to 27
      K = -1
      For I = 12 To 27
        WrkValue = RoundNet(I - 3, SArray(I))
        If WrkValue > 0 Then
          K = K + 1
          NCode(K) = (I - 3) & WrkAddZero '2 or 3 digit code
          NAss(K) = WrkValue
          WrkNAssTot = WrkNAssTot + WrkValue
        End If
      Next

      K = -1
      'Exemptions
      If WrkExemptCode Then
        WrkValue = MyUtils.CnvSng(SArray(29))
        If WrkValue > 0 Then
          K = K + 1
          NExcd(K) = "IEA"
          NExam(K) = WrkValue
          WrkNExTot = WrkNExTot + WrkValue
        End If

        WrkValue = MyUtils.CnvSng(SArray(30))
        If WrkValue > 0 Then
          K = K + 1
          NExcd(K) = "IGA"
          NExam(K) = WrkValue
          WrkNExTot = WrkNExTot + WrkValue
        End If

        WrkValue = MyUtils.CnvSng(SArray(31))
        If WrkValue > 0 Then
          K = K + 1
          NExcd(K) = "JAA"
          NExam(K) = WrkValue
          WrkNExTot = WrkNExTot + WrkValue
        End If

        WrkValue = MyUtils.CnvSng(SArray(32))
        If WrkValue > 0 Then
          K = K + 1
          NExcd(K) = "KDP"
          NExam(K) = WrkValue
          WrkNExTot = WrkNExTot + WrkValue
        End If

        WrkValue = MyUtils.CnvSng(SArray(33))
        If WrkValue > 0 Then
          K = K + 1
          NExcd(K) = "M"
          NExam(K) = WrkValue
          WrkNExTot = WrkNExTot + WrkValue
        End If

        WrkValue = MyUtils.CnvSng(SArray(34))
        If WrkValue > 0 Then
          K = K + 1
          NExcd(K) = "GH"
          NExam(K) = WrkValue
          WrkNExTot = WrkNExTot + WrkValue
        End If

        WrkValue = MyUtils.CnvSng(SArray(35))
        If WrkValue > 0 Then
          K = K + 1
          NExcd(K) = "IEA"
          NExam(K) = WrkValue
          WrkNExTot = WrkNExTot + WrkValue
        End If

        WrkValue = MyUtils.CnvSng(SArray(36))
        If WrkValue > 0 Then
          K = K + 1
          NExcd(K) = "J"
          NExam(K) = WrkValue
          WrkNExTot = WrkNExTot + WrkValue
        End If

        WrkValue = MyUtils.CnvSng(SArray(37))
        If WrkValue > 0 Then
          K = K + 1
          NExcd(K) = "HEA"
          NExam(K) = WrkValue
          WrkNExTot = WrkNExTot + WrkValue
        End If

        WrkValue = MyUtils.CnvSng(SArray(38))
        If WrkValue > 0 Then
          K = K + 1
          NExcd(K) = "U"
          NExam(K) = WrkValue
          WrkNExTot = WrkNExTot + WrkValue
        End If
      End If

      If ._CAT = "5" Then
        TGross(0) = TGross(0) + WrkNAssTot
        TExam(0) = TExam(0) + WrkNExTot
        TNet(0) = TNet(0) + WrkNAssTot - WrkNExTot
      Else
        TGross(1) = TGross(1) + WrkNAssTot
        TExam(1) = TExam(1) + WrkNExTot
        TNet(1) = TNet(1) + WrkNAssTot - WrkNExTot
      End If
      EditChecks(WrkNAssTot, WrkNExTot)
      AddToReport(WrkNAssTot, WrkNExTot)
      If WrkPost Then
        If WrkMissing Or (Not WrkMissing And Not myTXPPRP.RecordNotFound) Then
          UpdateTXPPRP(ImpListNo, WrkNAssTot, WrkNExTot)
          If WrkComments Then
            UpdateTAXCOM(ImpListNo)
          End If
        End If
      End If
    End With

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

End_of_file:
    myFrmProgress.Close()
    'If WrkUpValue Then
    '  WrkMsg = "Completed"
    '  MsgBox(WrkMsg, MsgBoxStyle.Information, "Replace unpriced values")
    'End If
  End Sub
  Private Sub UpdateTXPPRP(ByVal Implistno As Integer, ByVal Gross As Integer, ByVal ExamTot As Integer)
    Dim WrkUnit As Integer

    With myTXPPRP
      .GetOneRecordP(Implistno)
      If WrkName Then
        If ImpName <> String.Empty Then
          ._NAME = ImpName
          ._SNAME = ImpSname
        End If
      End If
      If WrkMailAddr Then
        If ImpAddr <> String.Empty Then
          ._ADD1 = ImpAddr
          ._ADD2 = ""
          ._CITY = ImpCity
          ._STATE = ImpState
          ._ZIP5 = ImpZip5
          ._ZIP4 = ImpZip4
        End If
      End If
      If WrkLoc Then
        If Trim(SArray(10)) <> String.Empty Then
          ._LOC = ImpLoc
          ._LOCNO = ImpLocNo
        End If
      End If
      If WrkPropCode Then
        WrkUnit = CalcUnit(._CODE1, NCode(0))
        If WrkUnit >= 0 Then
          ._UNIT1 = WrkUnit
        End If
        ._CODE1 = NCode(0)
        ._ASS1 = NAss(0)
        WrkUnit = CalcUnit(._CODE2, NCode(1))
        If WrkUnit >= 0 Then
          ._UNIT2 = WrkUnit
        End If
        ._CODE2 = NCode(1)
        ._ASS2 = NAss(1)
        WrkUnit = CalcUnit(._CODE3, NCode(2))
        If WrkUnit >= 0 Then
          ._UNIT3 = WrkUnit
        End If
        ._CODE3 = NCode(2)
        ._ASS3 = NAss(2)
        WrkUnit = CalcUnit(._CODE4, NCode(3))
        If WrkUnit >= 0 Then
          ._UNIT4 = WrkUnit
        End If
        ._CODE4 = NCode(3)
        ._ASS4 = NAss(3)
        WrkUnit = CalcUnit(._CODE5, NCode(4))
        If WrkUnit >= 0 Then
          ._UNIT5 = WrkUnit
        End If
        ._CODE5 = NCode(4)
        ._ASS5 = NAss(4)
        WrkUnit = CalcUnit(._CODE6, NCode(5))
        If WrkUnit >= 0 Then
          ._UNIT6 = WrkUnit
        End If
        ._CODE6 = NCode(5)
        ._ASS6 = NAss(5)
        WrkUnit = CalcUnit(._CODE7, NCode(6))
        If WrkUnit >= 0 Then
          ._UNIT7 = WrkUnit
        End If
        ._CODE7 = NCode(6)
        ._ASS7 = NAss(6)
        WrkUnit = CalcUnit(._CODE8, NCode(7))
        If WrkUnit >= 0 Then
          ._UNIT8 = WrkUnit
        End If
        ._CODE8 = NCode(7)
        ._ASS8 = NAss(7)
        WrkUnit = CalcUnit(._CODE9, NCode(8))
        If WrkUnit >= 0 Then
          ._UNIT9 = WrkUnit
        End If
        ._CODE9 = NCode(8)
        ._ASS9 = NAss(8)
        WrkUnit = CalcUnit(._CODEA, NCode(9))
        If WrkUnit >= 0 Then
          ._UNITA = WrkUnit
        End If
        ._CODEA = NCode(9)
        ._ASS10 = NAss(9)
        ._GROSS = Gross
      End If
      If WrkExemptCode Then
        ._EXCD1 = NExcd(0)
        If NExam(0) < 10000000 Then
          ._EXAM1 = NExam(0)
        Else
          ._EXAM1 = 0
        End If
        ._EXCD2 = NExcd(1)
        If NExam(1) < 10000000 Then
          ._EXAM2 = NExam(1)
        Else
          ._EXAM2 = 0
        End If
        ._EXCD3 = NExcd(2)
        If NExam(2) < 10000000 Then
          ._EXAM3 = NExam(2)
        Else
          ._EXAM3 = 0
        End If
        ._EXCD4 = NExcd(3)
        If NExam(3) < 10000000 Then
          ._EXAM4 = NExam(3)
        Else
          ._EXAM4 = 0
        End If
        ._EXCD5 = NExcd(4)
        If NExam(4) < 10000000 Then
          ._EXAM5 = NExam(4)
        Else
          ._EXAM5 = 0
        End If
      End If
      ._NET = Gross - ExamTot
      .UpdateOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        Exit Sub
      End If
    End With
  End Sub
  Private Sub UpdateTAXCOM(ByVal Implistno As Integer)
    Dim dsCom As DataSet = New DataSet
    Dim I As Integer
    Dim WrkStr As String
    Dim WrkLen As Integer
    Dim WrkRecs As Integer
    Dim WrkPos As Integer

    myTAXCOM.DeleteKeyComment(Implistno, "P", 0)
    WrkStr = Trim(SArray(11))
    WrkLen = Len(WrkStr)
    WrkRecs = Math.Ceiling(WrkLen / 60)
    For I = 0 To WrkRecs - 1
      WrkPos = (I * 60) + 1
      With myTAXCOM
        .GetOneRecordP(Implistno, "P", 0, I + 1)
        ._CMNT = Mid(WrkStr, WrkPos, 60)
        ._CSEQ = I + 1
        ._LISTNO = Implistno
        ._TYPE = "P"
        ._YEAR = 0
        .AddOneRecordP()
        If .ErrMsg <> "" Then
          WriteErrorLog(.ErrMsg)
          Exit Sub
        End If
      End With
    Next
  End Sub

  Public Sub BuildDs(ByRef Ds As DataSet)
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("sortdata", Type.GetType("System.String"))
      .Columns.Add("listno", Type.GetType("System.Int32"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("sname", Type.GetType("System.String"))
      .Columns.Add("addr1", Type.GetType("System.String"))
      .Columns.Add("addr2", Type.GetType("System.String"))
      .Columns.Add("city", Type.GetType("System.String"))
      .Columns.Add("state", Type.GetType("System.String"))
      .Columns.Add("zip", Type.GetType("System.String"))
      .Columns.Add("code1", Type.GetType("System.Int32"))
      .Columns.Add("ass1", Type.GetType("System.Int32"))
      .Columns.Add("code2", Type.GetType("System.Int32"))
      .Columns.Add("ass2", Type.GetType("System.Int32"))
      .Columns.Add("code3", Type.GetType("System.Int32"))
      .Columns.Add("ass3", Type.GetType("System.Int32"))
      .Columns.Add("code4", Type.GetType("System.Int32"))
      .Columns.Add("ass4", Type.GetType("System.Int32"))
      .Columns.Add("code5", Type.GetType("System.Int32"))
      .Columns.Add("ass5", Type.GetType("System.Int32"))
      .Columns.Add("code6", Type.GetType("System.Int32"))
      .Columns.Add("ass6", Type.GetType("System.Int32"))
      .Columns.Add("code7", Type.GetType("System.Int32"))
      .Columns.Add("ass7", Type.GetType("System.Int32"))
      .Columns.Add("code8", Type.GetType("System.Int32"))
      .Columns.Add("ass8", Type.GetType("System.Int32"))
      .Columns.Add("code9", Type.GetType("System.Int32"))
      .Columns.Add("ass9", Type.GetType("System.Int32"))
      .Columns.Add("code10", Type.GetType("System.Int32"))
      .Columns.Add("ass10", Type.GetType("System.Int32"))
      .Columns.Add("asstot", Type.GetType("System.Int32"))
      .Columns.Add("excd1", Type.GetType("System.String"))
      .Columns.Add("exam1", Type.GetType("System.Int32"))
      .Columns.Add("excd2", Type.GetType("System.String"))
      .Columns.Add("exam2", Type.GetType("System.Int32"))
      .Columns.Add("excd3", Type.GetType("System.String"))
      .Columns.Add("exam3", Type.GetType("System.Int32"))
      .Columns.Add("excd4", Type.GetType("System.String"))
      .Columns.Add("exam4", Type.GetType("System.Int32"))
      .Columns.Add("excd5", Type.GetType("System.String"))
      .Columns.Add("exam5", Type.GetType("System.Int32"))
      .Columns.Add("extot", Type.GetType("System.Int32"))
      .Columns.Add("nname", Type.GetType("System.String"))
      .Columns.Add("nsname", Type.GetType("System.String"))
      .Columns.Add("naddr1", Type.GetType("System.String"))
      .Columns.Add("ncity", Type.GetType("System.String"))
      .Columns.Add("nstate", Type.GetType("System.String"))
      .Columns.Add("nzip", Type.GetType("System.String"))
      .Columns.Add("ncode1", Type.GetType("System.Int32"))
      .Columns.Add("nass1", Type.GetType("System.Int32"))
      .Columns.Add("ncode2", Type.GetType("System.Int32"))
      .Columns.Add("nass2", Type.GetType("System.Int32"))
      .Columns.Add("ncode3", Type.GetType("System.Int32"))
      .Columns.Add("nass3", Type.GetType("System.Int32"))
      .Columns.Add("ncode4", Type.GetType("System.Int32"))
      .Columns.Add("nass4", Type.GetType("System.Int32"))
      .Columns.Add("ncode5", Type.GetType("System.Int32"))
      .Columns.Add("nass5", Type.GetType("System.Int32"))
      .Columns.Add("ncode6", Type.GetType("System.Int32"))
      .Columns.Add("nass6", Type.GetType("System.Int32"))
      .Columns.Add("ncode7", Type.GetType("System.Int32"))
      .Columns.Add("nass7", Type.GetType("System.Int32"))
      .Columns.Add("ncode8", Type.GetType("System.Int32"))
      .Columns.Add("nass8", Type.GetType("System.Int32"))
      .Columns.Add("ncode9", Type.GetType("System.Int32"))
      .Columns.Add("nass9", Type.GetType("System.Int32"))
      .Columns.Add("ncode10", Type.GetType("System.Int32"))
      .Columns.Add("nass10", Type.GetType("System.Int32"))
      .Columns.Add("nasstot", Type.GetType("System.Int32"))
      .Columns.Add("nexcd1", Type.GetType("System.String"))
      .Columns.Add("nexam1", Type.GetType("System.Int32"))
      .Columns.Add("nexcd2", Type.GetType("System.String"))
      .Columns.Add("nexam2", Type.GetType("System.Int32"))
      .Columns.Add("nexcd3", Type.GetType("System.String"))
      .Columns.Add("nexam3", Type.GetType("System.Int32"))
      .Columns.Add("nexcd4", Type.GetType("System.String"))
      .Columns.Add("nexam4", Type.GetType("System.Int32"))
      .Columns.Add("nexcd5", Type.GetType("System.String"))
      .Columns.Add("nexam5", Type.GetType("System.Int32"))
      .Columns.Add("nextot", Type.GetType("System.Int32"))
      .Columns.Add("msg", Type.GetType("System.String"))
    End With
    Ds.Tables.Add(myTable)

  End Sub
  Public Sub BuildDsTot(ByRef DsTot As DataSet)
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("RptID", Type.GetType("System.Int16"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("tgross", Type.GetType("System.Int32"))
      .Columns.Add("texam", Type.GetType("System.Int32"))
      .Columns.Add("tnet", Type.GetType("System.Int32"))
    End With
    DsTot.Tables.Add(myTable)

  End Sub
  Public Sub BuildDsErr(ByRef DsErr As DataSet)
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytableerr"
      .Columns.Add("sortdata", Type.GetType("System.String"))
      .Columns.Add("listno", Type.GetType("System.Int32"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("excd", Type.GetType("System.String"))
      .Columns.Add("exam", Type.GetType("System.Int32"))
      .Columns.Add("errmsg", Type.GetType("System.String"))
    End With
    DsErr.Tables.Add(myTable)

  End Sub
  Public Sub AddToReport(ByVal WrkNassTot As Integer, ByVal WrkNExTot As Integer)

    If WrkNassTot > 0 Then
      dr = ds.Tables(0).NewRow
    Else
      dr = ds2.Tables(0).NewRow
    End If
    With myTXPPRP
      Select Case WrkSortBy
        Case "LIST#"
          dr("sortdata") = Format(._LISTNO, "000000")
        Case "NAME"
          dr("sortdata") = ._NAME
      End Select
      dr.Item("listno") = ._LISTNO
      dr.Item("name") = Trim(._NAME)
      dr.Item("sname") = Trim(._SNAME)
      If WrkMailAddr Then
        dr.Item("addr1") = Trim(._ADD1)
        dr.Item("addr2") = Trim(._ADD2)
        dr.Item("city") = Trim(._CITY)
        dr.Item("state") = Trim(._STATE)
        If ._ZIP4 = 0 Then
          dr.Item("zip") = Format(._ZIP5, "00000")
        Else
          dr.Item("zip") = Format(._ZIP5, "00000") & "-" & Format(._ZIP4, "0000")
        End If
      End If
      dr.Item("code1") = ._CODE1
      dr.Item("ass1") = ._ASS1
      dr.Item("code2") = ._CODE2
      dr.Item("ass2") = ._ASS2
      dr.Item("code3") = ._CODE3
      dr.Item("ass3") = ._ASS3
      dr.Item("code4") = ._CODE4
      dr.Item("ass4") = ._ASS4
      dr.Item("code5") = ._CODE5
      dr.Item("ass5") = ._ASS5
      dr.Item("code6") = ._CODE6
      dr.Item("ass6") = ._ASS6
      dr.Item("code7") = ._CODE7
      dr.Item("ass7") = ._ASS7
      dr.Item("code8") = ._CODE8
      dr.Item("ass8") = ._ASS8
      dr.Item("code9") = ._CODE9
      dr.Item("ass9") = ._ASS9
      dr.Item("code10") = ._CODEA
      dr.Item("ass10") = ._ASS10
      dr.Item("asstot") = ._GROSS
      dr.Item("excd1") = Trim(._EXCD1)
      dr.Item("exam1") = ._EXAM1
      dr.Item("excd2") = Trim(._EXCD2)
      dr.Item("exam2") = ._EXAM2
      dr.Item("excd3") = Trim(._EXCD3)
      dr.Item("exam3") = ._EXAM3
      dr.Item("excd4") = Trim(._EXCD4)
      dr.Item("exam4") = ._EXAM4
      dr.Item("excd5") = Trim(._EXCD5)
      dr.Item("exam5") = ._EXAM5
      dr.Item("extot") = ._GROSS - ._NET
      If NCode(0) = 0 Then
        dr.Item("msg") = "* Decl Not Found *"
      Else
        If WrkName Then
          dr.Item("nname") = ImpName
          dr.Item("nsname") = ImpSname
        End If
        If WrkMailAddr Then
          dr.Item("naddr1") = ImpAddr
          dr.Item("ncity") = ImpCity
          dr.Item("nstate") = ImpState
          If MyUtils.CnvSng(SArray(8)) > 0 Then
            dr.Item("nzip") = Format(ImpZip5, "00000") & "-" & Format(ImpZip4, "0000")
          Else
            dr.Item("nzip") = Format(ImpZip5, "00000")
          End If
        End If
        dr.Item("ncode1") = NCode(0)
        dr.Item("nass1") = NAss(0)
        dr.Item("ncode2") = NCode(1)
        dr.Item("nass2") = NAss(1)
        dr.Item("ncode3") = NCode(2)
        dr.Item("nass3") = NAss(2)
        dr.Item("ncode4") = NCode(3)
        dr.Item("nass4") = NAss(3)
        dr.Item("ncode5") = NCode(4)
        dr.Item("nass5") = NAss(4)
        dr.Item("ncode6") = NCode(5)
        dr.Item("nass6") = NAss(5)
        dr.Item("ncode7") = NCode(6)
        dr.Item("nass7") = NAss(6)
        dr.Item("ncode8") = NCode(7)
        dr.Item("nass8") = NAss(7)
        dr.Item("ncode9") = NCode(8)
        dr.Item("nass9") = NAss(8)
        dr.Item("ncode10") = NCode(9)
        dr.Item("nass10") = NAss(9)
        dr.Item("nasstot") = WrkNassTot
        dr.Item("nexcd1") = NExcd(0)
        dr.Item("nexam1") = NExam(0)
        dr.Item("nexcd2") = NExcd(1)
        dr.Item("nexam2") = NExam(1)
        dr.Item("nexcd3") = NExcd(2)
        dr.Item("nexam3") = NExam(2)
        dr.Item("nexcd4") = NExcd(3)
        dr.Item("nexam4") = NExam(3)
        dr.Item("nexcd5") = NExcd(4)
        dr.Item("nexam5") = NExam(4)
        dr.Item("nextot") = WrkNExTot
      End If
    End With
    If WrkNassTot > 0 Then
      ds.Tables(0).Rows.Add(dr)
    Else
      ds2.Tables(0).Rows.Add(dr)
    End If
  End Sub
  Public Sub CheckExam(ByVal I As Integer)

    If NExam(I) >= 10000000 Or I > 4 Then
      dr = dsErr.Tables(0).NewRow
      With myTXPPRP
        Select Case WrkSortBy
          Case "LIST#"
            dr("sortdata") = Format(._LISTNO, "000000")
          Case "NAME"
            dr("sortdata") = Trim(._NAME)
        End Select
        dr.Item("listno") = ._LISTNO
        dr.Item("name") = Trim(._NAME)
        dr.Item("excd") = NExcd(I)
        dr.Item("exam") = NExam(I)
        If NExam(I) >= 10000000 Then
          dr.Item("errmsg") = "Exemption is over $10 million"
        End If
        If I > 4 Then
          dr.Item("errmsg") = "Over 5 exemptions"
        End If
      End With
      dsErr.Tables(0).Rows.Add(dr)
    End If
  End Sub
  Public Sub EditChecks(ByVal WrkNassTot As Integer, ByVal WrkNExTot As Integer)

    If WrkNassTot - WrkNExTot < 0 Then
      dr = dsErr.Tables(0).NewRow
      With myTXPPRP
        Select Case WrkSortBy
          Case "LIST#"
            dr("sortdata") = Format(._LISTNO, "000000")
          Case "NAME"
            dr("sortdata") = Trim(._NAME)
        End Select
        dr.Item("listno") = ._LISTNO
        dr.Item("name") = Trim(._NAME)
        dr.Item("excd") = String.Empty
        dr.Item("exam") = WrkNassTot - WrkNExTot
        dr.Item("errmsg") = "Net is negative"
      End With
      dsErr.Tables(0).Rows.Add(dr)
    End If
  End Sub
  Private Function CalcUnit(ByVal Code As Integer, ByVal NCode As Integer) As Integer
    Dim WrkUnit As Integer

    WrkUnit = 0
    If Code = 0 And NCode > 0 Then 'New Code
      WrkUnit = 1
    End If
    If Code > 0 And NCode > 0 Then 'Don't need to adjust units
      WrkUnit = -1
    End If
    Return WrkUnit
  End Function
  Private Function RoundNumber(ByVal WrkNumber As Integer, ByVal RoundMethod As String) As Integer
    Dim RoundDown As Boolean
    Dim J As Integer

    Select Case RoundMethod
      Case "Down"
        RoundDown = True
      Case "Normal"
        RoundDown = False
      Case Else
        Return WrkNumber
    End Select

    J = WrkNumber Mod 10
    If J <> 0 Then
      If RoundDown Then
        WrkNumber = WrkNumber - J
      Else
        If J < 5 Then
          WrkNumber = WrkNumber - J
        Else
          WrkNumber = WrkNumber + (10 - J)
        End If
      End If
    End If

    Return WrkNumber
  End Function
  Private Sub WriteTotals()
    dr = dsTot.Tables(0).NewRow
    dr.Item("rptid") = 1
    dr.Item("desc") = "Personal Property"
    dr.Item("tgross") = TGross(0)
    dr.Item("texam") = TExam(0)
    dr.Item("tnet") = TNet(0)
    dsTot.Tables(0).Rows.Add(dr)

    dr = dsTot.Tables(0).NewRow
    dr.Item("rptid") = 2
    dr.Item("desc") = "Tax Exempt"
    dr.Item("tgross") = TGross(1)
    dr.Item("texam") = TExam(1)
    dr.Item("tnet") = TNet(1)
    dsTot.Tables(0).Rows.Add(dr)
  End Sub
  Private Function RoundNet(ByVal WrkCode As Integer, ByVal WrkNet As String)
    Dim WrkNum As Integer
    WrkNum = MyUtils.CnvSng(WrkNet)
    Select Case WrkCode
      Case 9, 24
        WrkNet = RoundNumber(WrkNum, WrkMVRound)
      Case 25
        WrkNet = WrkNum
      Case Else
        WrkNet = RoundNumber(WrkNum, WrkOtherRound)
    End Select
    Return WrkNet
  End Function
  Private Function ConvertString(ByVal WrkField As String, ByVal WrkStr As String, ByVal WrkLen As Integer) As String

    Dim ReturnStr As String
    WrkStr = Trim(WrkStr)
    ReturnStr = Mid(WrkStr, 1, WrkLen)
    If Len(WrkStr) > WrkLen Then
      dr = dsErr.Tables(0).NewRow
      Select Case WrkSortBy
        Case "LIST#"
          dr("sortdata") = Format(ImpListNo, "000000")
        Case "NAME"
          dr("sortdata") = ImpName
      End Select
      dr.Item("listno") = ImpListNo
      dr.Item("name") = ImpName
      dr.Item("excd") = String.Empty
      dr.Item("exam") = 0
      dr.Item("errmsg") = WrkField & ": " & WrkStr & " truncated"
      dsErr.Tables(0).Rows.Add(dr)
    End If

    Return Trim(ReturnStr)
  End Function
End Module







