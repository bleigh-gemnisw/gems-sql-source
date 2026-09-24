Imports System.Text
Module PrintReportBefore

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXCOEBQ As TXCOEBQ.MyData
  Dim myTXCOEBL4 As TXCOEBL4.MyData
  Dim myTXMVDC As TXMVDC.MyData
  Dim myTXPPRPC As TXPPRPC.MyData
  Dim myTXREALC As TXREALC.MyData
  Dim myTXMVA As TXMVA.MyData
  Dim myTXPPRA As TXPPRA.MyData
  Dim myTXREAA As TXREAA.MyData
  Dim DsTXCOEB As DataSet = New DataSet
  Dim dsTXCOEBL4 As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim dr2 As Data.DataRow

  Dim WrkSortby As String
  Dim WrkSelType As String
  Dim WrkFromYear As Integer
  Dim WrkToYear As Integer
  Dim WrkFrom As Integer
  Dim WrkTo As Integer
  Dim WrkFromReason As String
  Dim WrkToReason As String
  Dim WrkUserID As String
  Dim WrkShowUser As Boolean
  Dim WrkMultDiff As Boolean
  Dim WrkShowTax As String
  Dim WrkBTR As Boolean

  Dim WrkCurrGLYear As Integer
  Dim WrkGrossIncr As Integer
  Dim WrkGrossDecr As Integer
  Dim WrkGrossDiff As Integer
  Dim WrkExIncr As Integer
  Dim WrkExDecr As Integer
  Dim WrkExDiff As Integer
  Dim WrkNetIncr As Integer
  Dim WrkNetDecr As Integer
  Dim WrkNetDiff As Integer
  Dim WrkTCount As Integer
  Dim WrkTGrossIncr As Integer
  Dim WrkTGrossDecr As Integer
  Dim WrkTGrossDiff As Integer
  Dim WrkTExIncr As Integer
  Dim WrkTExDecr As Integer
  Dim WrkTExDiff As Integer
  Dim WrkTNetIncr As Integer
  Dim WrkTNetDecr As Integer
  Dim WrkTNetDiff As Integer
  Public Sub PrtReportBefore()
    Dim WrkTypeDesc As String

    myTXCOEBQ = New TXCOEBQ.MyData(myDBConnect)
    myTXCOEBL4 = New TXCOEBL4.MyData(myDBConnect)
    myTXMVDC = New TXMVDC.MyData(myDBConnect)
    myTXPPRPC = New TXPPRPC.MyData(myDBConnect)
    myTXREALC = New TXREALC.MyData(myDBConnect)
    myTXMVA = New TXMVA.MyData(myDBConnect)
    myTXPPRA = New TXPPRA.MyData(myDBConnect)
    myTXREAA = New TXREAA.MyData(myDBConnect)

    With MyFrmTA801B
      If .RbSortName.Checked Then
        WrkSortby = "Name"
      End If
      If .RbSortList.Checked Then
        WrkSortby = "List"
      End If
      If .RbSortCCNo.Checked Then
        WrkSortby = "CCNo"
      End If
      WrkSelType = .TxtType.Text
      WrkFromYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
      WrkToYear = MyUtils.CnvSng(.TxtToGLYear.Text)
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
      WrkFromReason = .TxtFromReason.Text
      WrkToReason = .TxtToReason.Text
      WrkUserID = .TxtUserID.Text
      WrkShowUser = .ChkShowUser.Checked
      WrkMultDiff = .RbMultDiff.Checked
      WrkShowTax = String.Empty
      WrkBTR = False
      If .ChkBAA.Checked Then
        WrkBTR = True
      End If
      If .RbTaxable.Checked Then WrkShowTax = "Taxable"
      If .RbTaxExempt.Checked Then WrkShowTax = "Tax Exempt"
    End With

    WrkCurrGLYear = MyUtils.CnvSng(MyFrmTA801B.TxtBeforeYear.Text)

    If ds1.Tables.Count = 0 Then
      BuildDS()
    Else
      ds1.Clear()
      ds2.Clear()
      ClearTotals()
    End If

    GetDetail()

Done:
    If WrkSelType <> String.Empty Then
      WrkTypeDesc = GetTXTypeDesc(WrkSelType)
    Else
      WrkTypeDesc = "All Types"
    End If

    MyCrViewer = New FrmCrViewer
    MyCrViewer.Wrkds1 = ds1
    MyCrViewer.Wrkds2 = ds2
    MyCrViewer.WrkTypeDesc = WrkTypeDesc
    MyCrViewer.WrkReportType = "B" 'Before
    If WrkMultDiff Then
      MyCrViewer.WrkMultMethod = "Difference"
    Else
      MyCrViewer.WrkMultMethod = "Original"
    End If
    MyCrViewer.WrkTaxMethod = WrkShowTax
    MyCrViewer.Show()

  End Sub
  Private Sub ClearWrk()
    WrkGrossIncr = 0
    WrkGrossDecr = 0
    WrkExIncr = 0
    WrkExDecr = 0
    WrkNetIncr = 0
    WrkNetDecr = 0
  End Sub
  Private Sub ClearTotals()
    WrkTCount = 0
    WrkTGrossIncr = 0
    WrkTGrossDecr = 0
    WrkTExIncr = 0
    WrkTExDecr = 0
    WrkTNetIncr = 0
    WrkTNetDecr = 0
  End Sub
  Private Sub GetDetail()
    Dim WrkType As String
    Dim WrkCat As String
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkProrate As Integer
    Dim WrkAdjNet As Integer
    Dim WrkBTRAmt As Integer
    Dim WrkPct As Double
    Dim WrkSaleMonth As Integer
    Dim WrkExam As Integer
    Dim WrkAnd As String
    Dim SaveYear As Integer
    Dim SaveType As String
    Dim SaveListNo As Integer

    Dim Found As Boolean
    Dim FoundOrig As Boolean
    Dim WrkGross As Integer
    Dim WrkEx As Integer
    Dim WrkNet As Integer
    Dim Counter As Integer

    If myDBConnect.ServerName = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = "CDATE >= " & WrkFrom & WrkAnd & "CDATE <= " & WrkTo
    If WrkFromYear > 0 Or WrkToYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "CYEAR >= " & WrkFromYear & WrkAnd & "CYEAR <= " & WrkToYear
    End If
    If WrkSelType <> String.Empty Then
      WrkQry = WrkQry & WrkAnd & "CTYPE=" & MyUtils.Quo(WrkSelType)
    End If
    If WrkFromReason <> String.Empty Then
      WrkQry = WrkQry & WrkAnd & "RSNCD >= '" & WrkFromReason & "'"
    End If
    If WrkToReason <> String.Empty Then
      WrkQry = WrkQry & WrkAnd & "RSNCD <= '" & WrkToReason & "'"
    End If
    If WrkUserID <> "" Then
      WrkQry = WrkQry & WrkAnd & "PRF='" & WrkUserID & "'"
    End If

    WrkSort = String.Empty
    Select Case WrkSortby
      Case "Name"
        WrkSort = "CTYPE, CYEAR, NAME, LIST#"
      Case "List"
        WrkSort = "CTYPE, CYEAR, LIST#"
      Case "CCNo"
        WrkSort = "CCNO"
    End Select

    myTXCOEBQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    SaveListNo = 0
    SaveType = String.Empty
    ClearWrk()
    ClearTotals()

ReadNext:
    myTXCOEBQ.ReadQry()
    If Not myTXCOEBQ.IsEOF Then
      With myTXCOEBQ
        Counter = Counter + 1
        'Filter Taxable/Tax Exempt
        WrkType = ._CTYPE
        WrkCat = ""
        If WrkShowTax <> String.Empty Then
          Select Case WrkShowTax
            Case "Taxable"
              Select Case WrkType
                Case "R", "M"
                  WrkCat = "1"
                Case "P"
                  WrkCat = "5"
              End Select
            Case "Tax Exempt"
              WrkCat = "3"
          End Select
          If WrkCat <> ._CATG Then GoTo NextRec
        End If

        dr = ds1.Tables(0).NewRow
        If SaveListNo > 0 Then
          If SaveListNo <> ._LISTNo Or SaveYear <> ._CYEAR Or SaveType <> ._CTYPE Then
            If WrkMultDiff Then
              AddDiffTotals()
            Else
              AddOrigTotals()
            End If
            ClearWrk()
          End If
        End If
        SaveListNo = ._LISTNo
        If SaveYear > 0 And SaveYear <> ._CYEAR Or
      SaveType <> String.Empty And SaveType <> ._CTYPE Then
          WriteTotals(SaveYear, SaveType)
          ClearTotals()
        End If
        SaveYear = ._CYEAR
        SaveType = ._CTYPE
        WrkTCount = WrkTCount + 1
        dr.Item("ccno") = ._CCNO
        dr.Item("listno") = ._LISTNo
        dr.Item("year") = ._CYEAR
        dr.Item("type") = WrkType
        dr.Item("name") = ._NAME
        dr.Item("desc") = ._CDESC
        dr.Item("reasondesc") = GetTXCResnDesc(._RSNCD)
        dr.Item("cdate") = MyUtils.GetDBDate(._CDATE)
        If WrkShowUser Then
          dr.Item("userid") = ._PRF
        Else
          dr.Item("userid") = ""
        End If
        WrkPct = 0
        If ._CTYPE = "M" Then
          CalcProrateCode("M", ._CT2MC1, ._CGRS, WrkProrate, WrkAdjNet, WrkPct, WrkSaleMonth)
        End If
        If WrkPct > 0 Then
          dr.Item("newgross") = WrkProrate
        Else
          dr.Item("newgross") = ._CGRS
        End If
        WrkExam = ._NTEX1 + ._NTEX2 + ._NTEX3 + ._NTEX4 + ._NTEX5 + ._NTEX6 + ._NTEX7
        dr.Item("newex") = WrkExam
        If ._CTYPE = "M" And MyProRateRound Then
          dr.Item("newnet") = WrkProrate - WrkExam
        Else
          dr.Item("newnet") = ._NTNET
        End If
        dr.Item("newdue") = 0
        GetPrevCC(Found, WrkGross, WrkEx, WrkNet)
        dr.Item("origgross") = 0
        dr.Item("origex") = 0
        dr.Item("orignet") = 0
        dr.Item("origdue") = 0
        WrkBTRAmt = 0
        FoundOrig = False
        If Found Then
          dr.Item("origgross") = WrkGross
          dr.Item("origex") = WrkEx
          dr.Item("orignet") = WrkNet
        Else
          Select Case WrkType
            Case "M"
              If WrkCurrGLYear = ._CYEAR Then
                myTXMVDC.GetOneRecordP(._LISTNo)
                If Not myTXMVDC.RecordNotFound Then
                  With myTXMVDC
                    FoundOrig = True
                    WrkExam = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5
                    dr.Item("origgross") = ._VALUE
                    dr.Item("origex") = WrkExam
                    dr.Item("orignet") = ._VALUE - WrkExam
                    If WrkBTR Then
                      WrkBTRAmt = ._BTR
                    End If
                  End With
                End If
              Else
                myTXMVA.GetOneRecordP(._LISTNo, ._CYEAR)
                If Not myTXMVA.RecordNotFound Then
                  With myTXMVA
                    FoundOrig = True
                    WrkExam = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5
                    dr.Item("origgross") = ._VALUE
                    dr.Item("origex") = WrkExam
                    dr.Item("orignet") = ._VALUE - WrkExam
                    If WrkBTR Then
                      WrkBTRAmt = ._BTR
                    End If
                  End With
                End If
              End If
            Case "P"
              If WrkCurrGLYear = ._CYEAR Then
                myTXPPRPC.GetOneRecordP(._LISTNo)
                If Not myTXPPRPC.RecordNotFound Then
                  With myTXPPRPC
                    FoundOrig = True
                    WrkExam = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5
                    dr.Item("origgross") = ._GROSS
                    dr.Item("origex") = WrkExam
                    dr.Item("orignet") = ._NET
                    If WrkBTR Then
                      WrkBTRAmt = ._BTR
                    End If
                  End With
                End If
              Else
                myTXPPRA.GetOneRecordP(._LISTNo, ._CYEAR)
                If Not myTXPPRA.RecordNotFound Then
                  With myTXPPRA
                    FoundOrig = True
                    WrkExam = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5
                    dr.Item("origgross") = ._GROSS
                    dr.Item("origex") = WrkExam
                    dr.Item("orignet") = ._NET
                    If WrkBTR Then
                      WrkBTRAmt = ._BTR
                    End If
                  End With
                End If
              End If
            Case "R"
              If WrkCurrGLYear = ._CYEAR Then
                myTXREALC.GetOneRecordP(._LISTNo)
                If Not myTXREALC.RecordNotFound Then
                  With myTXREALC
                    FoundOrig = True
                    WrkExam = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5 + ._EXAM6 + ._EXAM7
                    dr.Item("origgross") = ._GROSS
                    dr.Item("origex") = WrkExam
                    dr.Item("orignet") = ._NET
                    If WrkBTR Then
                      WrkBTRAmt = ._BTR
                    End If
                  End With
                End If
              Else
                myTXREAA.GetOneRecordP(._LISTNo, ._CYEAR)
                If Not myTXREAA.RecordNotFound Then
                  With myTXREAA
                    FoundOrig = True
                    WrkExam = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5 + ._EXAM6 + ._EXAM7
                    dr.Item("origgross") = ._GROSS
                    dr.Item("origex") = WrkExam
                    dr.Item("orignet") = ._NET
                    If WrkBTR Then
                      WrkBTRAmt = ._BTR
                    End If
                  End With
                End If
              End If
          End Select
          If Not FoundOrig Then
            dr.Item("newgross") = ._CGRSCH
            dr.Item("newex") = ._EXCHG
            dr.Item("newnet") = ._CGRSCH - ._EXCHG
            dr.Item("chggross") = ._CGRSCH
            dr.Item("chgex") = ._EXCHG
            dr.Item("chgnet") = ._CGRSCH - ._EXCHG
          End If
        End If
        If FoundOrig Or Found Then
          dr.Item("chggross") = dr.Item("newgross") - dr.Item("origgross")
          dr.Item("chgex") = dr.Item("newex") - dr.Item("origex")
          dr.Item("chgnet") = dr.Item("newnet") - dr.Item("orignet")
        End If
        dr.Item("chgdue") = 0
        If WrkBTRAmt <> 0 Then
          dr.Item("origgross") = dr.Item("origgross") + WrkBTRAmt
          dr.Item("orignet") = dr.Item("orignet") + WrkBTRAmt
          dr.Item("newgross") = dr.Item("newgross") '+ WrkBTRAmt
          dr.Item("newnet") = dr.Item("newnet") '+ WrkBTRAmt
          dr.Item("chggross") = dr.Item("newgross") - dr.Item("origgross")
          dr.Item("chgex") = dr.Item("newex") - dr.Item("origex")
          dr.Item("chgnet") = dr.Item("newnet") - dr.Item("orignet")
        End If
        '    If FoundOrig Then
        If dr.Item("chggross") > 0 Then
          WrkGrossIncr = WrkGrossIncr + dr.Item("chggross")
        Else
          WrkGrossDecr = WrkGrossDecr + dr.Item("chggross")
        End If
        If dr.Item("chgex") > 0 Then
          WrkExIncr = WrkExIncr + dr.Item("chgex")
        Else
          WrkExDecr = WrkExDecr + dr.Item("chgex")
        End If
        If dr.Item("chgnet") > 0 Then
          WrkNetIncr = WrkNetIncr + dr.Item("chgnet")
        Else
          WrkNetDecr = WrkNetDecr + dr.Item("chgnet")
        End If
        '    End If
      End With
      ds1.Tables(0).Rows.Add(dr)
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

    If WrkMultDiff Then
      AddDiffTotals()
    Else
      AddOrigTotals()
    End If
    WriteTotals(SaveYear, SaveType)
    myFrmProgress.Close()

    myTXCOEBQ.CloseFile()
    myTXPPRPC.CloseFile()

  End Sub
  Public Sub GetPrevCC(ByRef Found As Boolean,
    ByRef Out_Gross As Integer, ByRef Out_Ex As Integer, ByRef Out_Net As Integer)

    Dim WrkProrate As Integer
    Dim WrkAdjNet As Integer
    Dim WrkPct As Double
    Dim WrkSaleMonth As Integer
    Dim WrkExam As Integer

    Out_Gross = 0
    Out_Ex = 0
    Out_Net = 0
    Found = False
    With myTXCOEBQ
      dsTXCOEBL4 = myTXCOEBL4.GetDescList(._LISTNo, ._CYEAR, ._CTYPE,
        ._CHDATE, ._CHTIME, 2)
    End With
    If dsTXCOEBL4.Tables(0).Rows.Count > 1 Then
      With dsTXCOEBL4.Tables(0).Rows(1)
        Found = True
        If .Item("ctype") = "M" Then
          CalcProrateCode("M", .Item("ct2mc1"), .Item("cgrs"), WrkProrate, WrkAdjNet, WrkPct, WrkSaleMonth)
        End If
        If WrkPct > 0 Then
          Out_Gross = WrkProrate
        Else
          Out_Gross = .Item("cgrs")
        End If
        WrkExam = .Item("ntex1") + .Item("ntex2") + .Item("ntex3") + .Item("ntex4") +
         .Item("ntex5") + .Item("ntex6") + .Item("ntex7")
        Out_Ex = WrkExam
        Out_Net = .Item("ntnet")
      End With
    End If
  End Sub
  Private Sub AddOrigTotals()
    WrkTGrossIncr = WrkTGrossIncr + WrkGrossIncr
    WrkTGrossDecr = WrkTGrossDecr + WrkGrossDecr
    WrkTExIncr = WrkTExIncr + WrkExIncr
    WrkTExDecr = WrkTExDecr + WrkExDecr
    WrkTNetIncr = WrkTNetIncr + WrkNetIncr
    WrkTNetDecr = WrkTNetDecr + WrkNetDecr
  End Sub
  Private Sub AddDiffTotals()
    Dim WrkDiff As Integer

    WrkDiff = WrkGrossIncr + WrkGrossDecr
    If WrkGrossIncr >= Math.Abs(WrkGrossDecr) Then
      WrkTGrossIncr = WrkTGrossIncr + WrkDiff
    Else
      WrkTGrossDecr = WrkTGrossDecr + WrkDiff
    End If
    WrkDiff = WrkExIncr + WrkExDecr
    If WrkExIncr >= Math.Abs(WrkExDecr) Then
      WrkTExIncr = WrkTExIncr + WrkDiff
    Else
      WrkTExDecr = WrkTExDecr + WrkDiff
    End If
    WrkDiff = WrkNetIncr + WrkNetDecr
    If WrkNetIncr >= Math.Abs(WrkNetDecr) Then
      WrkTNetIncr = WrkTNetIncr + WrkDiff
    Else
      WrkTNetDecr = WrkTNetDecr + WrkDiff
    End If
  End Sub
  Private Sub WriteTotals(ByVal SaveYear As Integer, ByVal SaveType As String)
    dr2 = ds2.Tables(0).NewRow
    dr2.Item("tcount") = WrkTCount
    dr2.Item("year") = SaveYear
    dr2.Item("type") = SaveType
    dr2.Item("tgrossincr") = WrkTGrossIncr
    dr2.Item("tgrossdecr") = WrkTGrossDecr
    dr2.Item("tgrossdiff") = WrkTGrossIncr + WrkTGrossDecr
    dr2.Item("texincr") = WrkTExIncr
    dr2.Item("texdecr") = WrkTExDecr
    dr2.Item("texdiff") = WrkTExIncr + WrkTExDecr
    dr2.Item("tnetincr") = WrkTNetIncr
    dr2.Item("tnetdecr") = WrkTNetDecr
    dr2.Item("tnetdiff") = WrkTNetIncr + WrkTNetDecr
    dr2.Item("tdueincr") = 0
    dr2.Item("tduedecr") = 0
    dr2.Item("tduediff") = 0
    ds2.Tables(0).Rows.Add(dr2)
  End Sub

End Module






