Imports System.Text
Module ImportData

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXPPRPQ As TXPPRPQ.MyData
  Dim myTXDCPPQ As TXDCPPQ.MyData
  Dim myTXDCPP As TXDCPP.MyData
  Dim myTXDCSUM As TXDCSUM.MyData
  Dim myTXDCEXM As TXDCEXM.MyData
  Dim myTXPPRP As TXPPRP.MyData
  Dim myTXDCCD As TXDCCD.MyData
  Dim myTXDCCOM As TXDCCOM.MyData
  Dim myTAXCOM As TAXCOM.MyData
  Dim myTXDVPP As TXDVPP.MyData
  Dim myDBUTILS As DBUtils.Utils

  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim ds3 As DataSet = New DataSet
  Dim dsTot As DataSet = New DataSet
  Dim dsErr As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkBackup As Boolean
  Dim WrkYear As Integer
  Dim WrkName As Boolean
  Dim WrkMailAddr As Boolean
  Dim WrkLoc As Boolean
  Dim WrkPropCode As Boolean
  Dim WrkExemptCode As Boolean
  Dim WrkMVRound As String
  Dim WrkOtherRound As String
  Dim WrkMVAddr As Boolean
  Dim WrkMVLoc As Boolean
  Dim WrkComments As Boolean
  Dim WrkPost As Boolean
  Dim WrkMissing As Boolean
  Dim WrkZero As Boolean
  Dim WrkSortBy As String
  'Globals
  Dim WrkCode(99) As Integer
  Dim WrkAsCode(99) As Integer
  Dim NCode(9) As Integer
  Dim NAss(9) As Integer
  Dim NExcd(4) As String
  Dim NExam(4) As Integer
  'Totals
  Dim TGross(1) As Integer
  Dim TExam(1) As Integer
  Dim TNet(1) As Integer
  Public Sub Impdata()
    myTXPPRPQ = New TXPPRPQ.MyData(myDBConnect)
    myTXDCPPQ = New TXDCPPQ.MyData(myDBConnect)
    myTXDCPP = New TXDCPP.MyData(myDBConnect)
    myTXDCSUM = New TXDCSUM.MyData(myDBConnect)
    myTXDCEXM = New TXDCEXM.MyData(myDBConnect)
    myTXPPRP = New TXPPRP.MyData(myDBConnect)
    myTXDCCD = New TXDCCD.MyData(myDBConnect)
    myTXDCCOM = New TXDCCOM.MyData(myDBConnect)
    myTAXCOM = New TAXCOM.MyData(myDBConnect)
    myTXDVPP = New TXDVPP.MyData(myDBConnect)
    myDBUTILS = New DBUtils.Utils(myDBConnect)

    With MyFrmTAP20B
      WrkBackup = False
      If .ChkBackup.Checked Then WrkBackup = True
      WrkYear = MyUtils.CnvSng(.TxtYear.Text)
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
      WrkMVAddr = False
      If .ChkMVAddr.Checked Then WrkMVAddr = True
      WrkMVLoc = False
      If .ChkMVLoc.Checked Then WrkMVLoc = True
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
      ds3 = ds.Clone
      BuildDsTot(dsTot)
      BuildDsErr(dsErr)
    Else
      ds.Clear()
      ds2.Clear()
      ds3.Clear()
      dsTot.Clear()
      dsErr.Clear()
    End If
    BufferCode()
    GetDetail()
    FindMissingPPRP()
    WriteTotals()

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .Wrkds2 = ds2
      .Wrkds3 = ds3
      .WrkdsTot = dsTot
      .WrkdsErr = dsErr
      .Show()
    End With

  End Sub
  Private Sub GetDetail()
    Dim DsTXDCSUM As DataSet = New DataSet
    Dim DsTXDCEXM As DataSet = New DataSet
    Dim WrkQry As String
    Dim WrkSort As String
    Dim J As Integer
    Dim K As Integer
    Dim WrkListNo As Integer
    Dim WrkNAssTot As Integer
    Dim WrkNExTot As Integer
    Dim WrkNet As Integer
    Dim Counter As Integer

    WrkSort = ""
    WrkQry = ""
    Counter = 0
    Array.Clear(TGross, 0, 1)
    Array.Clear(TExam, 0, 1)
    Array.Clear(TNet, 0, 1)

    'WrkQry = "list#=40284" 'Testing
    myTXPPRPQ.OpenQry(WrkSort, WrkQry)
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    If WrkBackup Then
      myDBUTILS.DeleteAllRecs("CAMPPRP")
      myDBUTILS.CopyData("TXPPRP", "CAMPPRP")
    End If

ReadNext:
    myTXPPRPQ.ReadQry()
    If Not myTXPPRPQ.IsEOF Then
      With myTXPPRPQ
        Counter = Counter + 1
        WrkListNo = ._LISTNO
        myTXDCPP.GetOneRecordP(WrkListNo, WrkYear)
        If WrkMVAddr Or WrkMVLoc Then
          myTXDVPP.GetOneRecordP(WrkListNo, WrkYear)
        End If
        WrkNAssTot = 0
        WrkNExTot = 0
        Array.Clear(NCode, 0, 10)
        Array.Clear(NAss, 0, 10)
        Array.Clear(NExcd, 0, 5)
        Array.Clear(NExam, 0, 5)
        'Property Codes
        K = -1
        DsTXDCSUM = myTXDCSUM.GetByList(WrkListNo, WrkYear)
        For J = 0 To DsTXDCSUM.Tables(0).Rows.Count - 1
          With DsTXDCSUM.Tables(0).Rows(J)
            Select Case .Item("code")
              Case 9, 24
                WrkNet = RoundNumber(.Item("net"), WrkMVRound)
              Case 25
                WrkNet = .Item("net")
              Case Else
                WrkNet = RoundNumber(.Item("net"), WrkOtherRound)
            End Select
            If WrkNet > 0 Then
              K = K + 1
              NCode(K) = LookupCode(.Item("code"))
              NAss(K) = WrkNet
              WrkNAssTot = WrkNAssTot + NAss(K)
            End If
          End With
        Next
        'Exemptions
        If WrkExemptCode Then
          DsTXDCEXM = myTXDCEXM.GetByList(._LISTNO, WrkYear)
          For J = 0 To DsTXDCEXM.Tables(0).Rows.Count - 1
            With DsTXDCEXM.Tables(0).Rows(J)
              NExcd(J) = .Item("code")
              NExam(J) = .Item("value")
              WrkNExTot = WrkNExTot + NExam(J)
              CheckExam(J)
            End With
          Next
          For J = DsTXDCEXM.Tables(0).Rows.Count To NExcd.GetUpperBound(0)
            NExcd(J) = ""
            NExam(J) = 0
          Next
        Else
            If WrkNAssTot > 0 Then
            WrkNExTot = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5
          End If
        End If

        If myTXDCPP._STATUS <> "I" Then
          If WrkMissing Or (WrkZero And Trim(myTXDCPP._STATUS) = "") Or (WrkZero And myTXDCPP._STATUS = "C") _
       Or (Not WrkMissing And DsTXDCSUM.Tables(0).Rows.Count > 0) Then
            If ._CAT = "5" Then
              TGross(0) = TGross(0) + WrkNAssTot
              TExam(0) = TExam(0) + WrkNExTot
              TNet(0) = TNet(0) + WrkNAssTot - WrkNExTot
            Else
              TGross(1) = TGross(1) + WrkNAssTot
              TExam(1) = TExam(1) + WrkNExTot
              TNet(1) = TNet(1) + WrkNAssTot - WrkNExTot
            End If
          Else
            If ._CAT = "5" Then
              TGross(0) = TGross(0) + ._GROSS
              TExam(0) = TExam(0) + ._GROSS - ._NET
              TNet(0) = TNet(0) + ._NET
            Else
              TGross(1) = TGross(1) + ._GROSS
              TExam(1) = TExam(1) + ._GROSS - ._NET
              TNet(1) = TNet(1) + ._NET
            End If
          End If
        End If
      End With

      If myTXDCPP._STATUS <> "I" Then
        EditChecks(WrkNAssTot, WrkNExTot)
      End If
      AddToReport(WrkNAssTot, WrkNExTot)
      If myTXDCPP._STATUS = "I" Then
        GoTo NextRec
      End If
      If WrkPost Then
        If WrkMissing Or (WrkZero And Trim(myTXDCPP._STATUS) = "") Or (WrkZero And myTXDCPP._STATUS = "C") _
         Or (Not WrkMissing And DsTXDCSUM.Tables(0).Rows.Count > 0) Then
          UpdateTXPPRP(WrkListNo, WrkNAssTot, WrkNExTot)
          If WrkComments Then
            UpdateTAXCOM(WrkListNo)
          End If
        End If
      End If

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

    myFrmProgress.Close()

  End Sub
  Private Sub UpdateTXPPRP(ByVal WrkListNo As Integer, ByVal Gross As Integer, ByVal ExamTot As Integer)
    Dim WrkUnit As Integer

    With myTXPPRP
      .GetOneRecordP(myTXPPRPQ._LISTNO)
      If WrkName Then
        If Trim(myTXDCPP._OWNAME) <> String.Empty Then
          ._NAME = myTXDCPP._OWNAME
          ._SNAME = myTXDCPP._DBA
        End If
      End If
      If WrkMailAddr Then
        If Trim(myTXDCPP._DADDR) <> String.Empty Then
          ._ADD1 = myTXDCPP._DADDR
          ._ADD2 = myTXDCPP._DADDR2
          ._CITY = myTXDCPP._DCITY
          ._STATE = myTXDCPP._DSTATE
          ._ZIP5 = myTXDCPP._DZIP5
          ._ZIP4 = myTXDCPP._DZIP4
        End If
      End If
      If WrkLoc Then
        If Trim(myTXDCPP._LOC) <> String.Empty Then
          ._LOC = myTXDCPP._LOC
          ._LOCNO = MyUtils.JustifyRight(Trim(myTXDCPP._LOCNO), 7)
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
      If WrkMVAddr Then
        If Trim(myTXDVPP._NAME) <> String.Empty Then
          ._ADD1 = myTXDVPP._ADDR
          ._ADD2 = myTXDVPP._ADDR2
          ._CITY = myTXDVPP._CITY
          ._STATE = myTXDVPP._STATE
          ._ZIP5 = myTXDVPP._ZIP5
          ._ZIP4 = myTXDVPP._ZIP4
        Else
          If Trim(myTXDCPP._DADDR) <> String.Empty Then
            ._ADD1 = myTXDCPP._DADDR
            ._ADD2 = myTXDCPP._DADDR2
            ._CITY = myTXDCPP._DCITY
            ._STATE = myTXDCPP._DSTATE
            ._ZIP5 = myTXDCPP._DZIP5
            ._ZIP4 = myTXDCPP._DZIP4
          End If
        End If
      End If
      If WrkMVLoc Then
        If Trim(myTXDVPP._LOC) <> String.Empty Then
          ._LOC = myTXDVPP._LOC
          ._LOCNO = MyUtils.JustifyRight(Trim(myTXDVPP._LOCNO), 7)
        Else
          ._LOC = myTXDCPP._LOC
          ._LOCNO = MyUtils.JustifyRight(Trim(myTXDCPP._LOCNO), 7)
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
  Private Sub UpdateTAXCOM(ByVal WrkListNo As Integer)
    Dim dsCom As DataSet = New DataSet
    Dim I As Integer
    Dim WrkStr As String
    Dim WrkLen As Integer
    Dim WrkRecs As Integer
    Dim WrkPos As Integer

    myTAXCOM.DeleteKeyComment(WrkListNo, "P", 0)
    dsCom = myTXDCCOM.Getcomments(WrkListNo, WrkYear)
    WrkStr = String.Empty
    For I = 0 To dsCom.Tables(0).Rows.Count - 1
      If I = dsCom.Tables(0).Rows.Count - 1 Then
        WrkStr = WrkStr & Trim(dsCom.Tables(0).Rows(I).Item("cmnt"))
      Else
        WrkStr = WrkStr & dsCom.Tables(0).Rows(I).Item("cmnt")
      End If
    Next
    WrkLen = Len(WrkStr)
    WrkRecs = Math.Ceiling(WrkLen / 60)
    For I = 0 To WrkRecs - 1
      WrkPos = (I * 60) + 1
      With myTAXCOM
        .GetOneRecordP(WrkListNo, "P", 0, I + 1)
        ._CMNT = Mid(WrkStr, WrkPos, 60)
        ._CSEQ = I + 1
        ._LISTNO = WrkListNo
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

  Private Sub FindMissingPPRP()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkListNo As Integer
    Dim Counter As Integer

    WrkSort = ""
    WrkQry = "YEAR = " & WrkYear
    Counter = 0

    myTXDCPPQ.OpenQry(WrkSort, WrkQry)
    myFrmProgress = New FrmProgress
    myFrmProgress.Text = "Looking for missing records..."
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXDCPPQ.ReadQry()
    If Not myTXDCPPQ.IsEOF Then
      With myTXDCPPQ
        Counter = Counter + 1
        If ._STATUS = "I" Then
          GoTo NextRec
        End If
        WrkListNo = ._LISTNO
        myTXPPRP.GetOneRecordP(WrkListNo)
        If myTXPPRP.RecordNotFound Then
          dr = dsErr.Tables(0).NewRow
          Select Case WrkSortBy
            Case "LIST#"
              dr("sortdata") = Format(._LISTNO, "000000")
            Case "NAME"
              dr("sortdata") = Trim(._OWNAME)
          End Select
          dr.Item("listno") = ._LISTNO
          dr.Item("name") = Trim(._OWNAME)
          dr.Item("excd") = String.Empty
          dr.Item("exam") = 0
          dr.Item("errmsg") = "Record not found in PP master"
          dsErr.Tables(0).Rows.Add(dr)
        End If
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

    myFrmProgress.Close()
    myTXDCPPQ.CloseFile()

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

    If myTXDCPP._STATUS = "I" Then
      dr = ds3.Tables(0).NewRow
    Else
      If WrkNassTot > 0 Then
        dr = ds.Tables(0).NewRow
      Else
        dr = ds2.Tables(0).NewRow
      End If
    End If
    With myTXPPRPQ
      Select Case WrkSortBy
        Case "LIST#"
          dr("sortdata") = Format(._LISTNO, "000000")
        Case "NAME"
          dr("sortdata") = ._NAME
      End Select
      dr.Item("listno") = ._LISTNO
      dr.Item("name") = Trim(._NAME)
      dr.Item("sname") = Trim(._SNAME)
      If WrkMVAddr And Trim(myTXDVPP._NAME) <> String.Empty Or WrkMailAddr Then
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
      'If NCode(0) = 0 Then
      If Trim(myTXDCPP._OWNAME) = "" Then
        dr.Item("msg") = "* Decl Not Found *"
      Else
        If WrkName Then
          dr.Item("nname") = Trim(myTXDCPP._OWNAME)
          dr.Item("nsname") = Trim(myTXDCPP._DBA)
        End If
        If WrkMailAddr Then
          dr.Item("naddr1") = Trim(myTXDCPP._DADDR)
          dr.Item("ncity") = Trim(myTXDCPP._DCITY)
          dr.Item("nstate") = Trim(myTXDCPP._DSTATE)
          If myTXDCPP._DZIP4 = 0 Then
            dr.Item("nzip") = Format(myTXDCPP._DZIP5, "00000")
          Else
            dr.Item("nzip") = Format(myTXDCPP._DZIP5, "00000") & "-" & Format(myTXDCPP._DZIP4, "0000")
          End If
        End If
        If WrkMVAddr And Trim(myTXDVPP._NAME) <> String.Empty Then
          'dr.Item("nname") = Trim(myTXDVPP._NAME)
          'dr.Item("nsname") = Trim(._SNAME)
          dr.Item("naddr1") = Trim(myTXDVPP._ADDR)
          dr.Item("ncity") = Trim(myTXDVPP._CITY)
          dr.Item("nstate") = Trim(myTXDVPP._STATE)
          If myTXDVPP._ZIP4 = 0 Then
            dr.Item("nzip") = Format(myTXDVPP._ZIP5, "00000")
          Else
            dr.Item("nzip") = Format(myTXDVPP._ZIP5, "00000") & "-" & Format(myTXDVPP._ZIP4, "0000")
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
    If myTXDCPP._STATUS = "I" Then
      ds3.Tables(0).Rows.Add(dr)
    Else
      If WrkNassTot > 0 Then
        ds.Tables(0).Rows.Add(dr)
      Else
        ds2.Tables(0).Rows.Add(dr)
      End If
    End If
  End Sub
  Public Sub CheckExam(ByVal I As Integer)

    If NExam(I) >= 10000000 Or I > 4 Then
      dr = dsErr.Tables(0).NewRow
      With myTXPPRPQ
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
      With myTXPPRPQ
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
  Private Sub BufferCode()
    Dim I As Integer

    Dim myTXDCCD As TXDCCD.MyData
    Dim dsFile As DataSet = New DataSet

    myTXDCCD = New TXDCCD.MyData(myDBConnect)

    dsFile = myTXDCCD.GetAllYear(MyUtils.CnvSng(MyFrmTAP20B.TxtYear.Text))
    For I = 0 To dsFile.Tables(0).Rows.Count - 1
      With dsFile.Tables(0).Rows(I)
        WrkCode(I) = .Item("code")
        WrkAsCode(I) = .Item("ascode")
      End With
    Next

  End Sub
  Private Function LookupCode(ByVal Code As String) As Integer
    Dim I As Integer

    For I = 0 To WrkCode.GetUpperBound(0)
      If Trim(WrkCode(I)) = "" Then
        Return -1
      End If
      If Trim(Code) = Trim(WrkCode(I)) Then
        Return WrkAsCode(I)
      End If
    Next

    Return -1
  End Function
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
End Module






