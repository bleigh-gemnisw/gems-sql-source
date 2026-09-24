Imports System.Text
Module PrintReportAfter

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXCOEAQ As TXCOEAQ.MyData
  Dim myTXINV As TXINV.MyData
  Dim DsTXCOEA As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim dr2 As Data.DataRow

  Dim WrkSortBy As String
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

  Dim WrkGrossIncr As Integer
  Dim WrkGrossDecr As Integer
  Dim WrkGrossDiff As Integer
  Dim WrkExIncr As Integer
  Dim WrkExDecr As Integer
  Dim WrkExDiff As Integer
  Dim WrkNetIncr As Integer
  Dim WrkNetDecr As Integer
  Dim WrkNetDiff As Integer
  Dim WrkDueIncr As Decimal
  Dim WrkDueDecr As Decimal
  Dim WrkDueDiff As Decimal
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
  Dim WrkTDueIncr As Decimal
  Dim WrkTDueDecr As Decimal
  Dim WrkTDueDiff As Decimal

  Public Sub PrtReportAfter()
    Dim WrkTypeDesc As String

    myTXCOEAQ = New TXCOEAQ.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)

    With MyFrmTA801B
      If .RbSortName.Checked Then
        WrkSortBy = "Name"
      End If
      If .RbSortList.Checked Then
        WrkSortBy = "List"
      End If
      If .RbSortCCNo.Checked Then
        WrkSortBy = "CCNo"
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
    End With

    If ds1.Tables.Count = 0 Then
      BuildDS()
    Else
      ds1.Clear()
      ds2.Clear()
      ClearTotals()
    End If

    BufferCCReason()
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
    MyCrViewer.WrkReportType = "A" 'After
    If WrkMultDiff Then
      MyCrViewer.WrkMultMethod = "Difference"
    Else
      MyCrViewer.WrkMultMethod = "Original"
    End If
    MyCrViewer.WrkTaxMethod = String.Empty
    MyCrViewer.Show()

  End Sub
  Private Sub ClearWrk()
    WrkGrossIncr = 0
    WrkGrossDecr = 0
    WrkExIncr = 0
    WrkExDecr = 0
    WrkNetIncr = 0
    WrkNetDecr = 0
    WrkDueIncr = 0
    WrkDueDecr = 0
  End Sub
  Private Sub ClearTotals()
    WrkTCount = 0
    WrkTGrossIncr = 0
    WrkTGrossDecr = 0
    WrkTExIncr = 0
    WrkTExDecr = 0
    WrkTNetIncr = 0
    WrkTNetDecr = 0
    WrkTDueIncr = 0
    WrkTDueDecr = 0
  End Sub
  Private Sub GetDetail()
    Dim WrkType As String
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkAnd As String
    Dim SaveYear As Integer
    Dim SaveType As String
    Dim SaveListNo As Integer

    Dim Found As Boolean
    Dim WrkExam As Integer
    Dim WrkGross As Integer
    Dim WrkEx As Integer
    Dim WrkNet As Integer
    Dim WrkDue As Double
    Dim Counter As Integer
    Dim K As Integer

    If myDBConnect.ServerName = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If
    Counter = 0

    WrkQry = "CDATE >= " & WrkFrom & WrkAnd & "CDATE <= " & WrkTo
    If WrkFromYear > 0 Or WrkToYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromYear & WrkAnd & "YEAR <= " & WrkToYear
    End If
    If WrkSelType <> String.Empty Then
      WrkQry = WrkQry & WrkAnd & "TYPE=" & MyUtils.Quo(WrkSelType)
    End If
    If WrkFromReason <> "" Then
      WrkQry = WrkQry & WrkAnd & "RSNCD >= '" & WrkFromReason & "'"
    End If
    If WrkToReason <> "" Then
      WrkQry = WrkQry & WrkAnd & "RSNCD <= '" & WrkToReason & "'"
    End If
    If WrkUserID <> "" Then
      WrkQry = WrkQry & WrkAnd & "PRF='" & WrkUserID & "'"
    End If
    'WrkQry = WrkQry & WrkAnd & "List#=30078"

    WrkSort = String.Empty
    Select Case WrkSortBy
      Case "Name"
        WrkSort = "TYPE, YEAR, NAME, LIST#"
      Case "List"
        WrkSort = "TYPE, YEAR, LIST#"
      Case "CCNo"
        WrkSort = "CCNO"
    End Select

    myTXCOEAQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    SaveType = String.Empty
    SaveListNo = 0
    SaveType = String.Empty
    ClearWrk()
    ClearTotals()

ReadNext:
    myTXCOEAQ.ReadQry()
    If Not myTXCOEAQ.IsEOF Then
      With myTXCOEAQ
        Counter = Counter + 1
        dr = ds1.Tables(0).NewRow
        If SaveListNo > 0 Then
          If SaveListNo <> ._LISTNo Or SaveYear <> ._YEAR Or SaveType <> ._TYPE Then
            If WrkMultDiff Then
              AddDiffTotals()
            Else
              AddOrigTotals()
            End If
            ClearWrk()
          End If
        End If
        SaveListNo = ._LISTNo
        If SaveYear > 0 And SaveYear <> ._YEAR Or
      SaveType <> String.Empty And SaveType <> ._TYPE Then
          WriteTotals(SaveYear, SaveType)
          ClearTotals()
        End If
        SaveYear = ._YEAR
        SaveType = ._TYPE
        WrkTCount = WrkTCount + 1
        dr.Item("ccno") = ._CCNO
        dr.Item("listno") = ._LISTNo
        dr.Item("year") = ._YEAR
        WrkType = ._TYPE
        dr.Item("type") = WrkType
        dr.Item("name") = ._NAME
        dr.Item("desc") = ._CDESC
        K = LookupCCReason(._RSNCD)
        If K >= 0 Then
          dr.Item("reasondesc") = WrkCCRsnDesc(K)
        Else
          dr.Item("reasondesc") = "*** Unknown ***"
        End If
        dr.Item("cdate") = MyUtils.GetDBDate(._CDATE)
        If WrkShowUser Then
          dr.Item("userid") = ._PRF
        Else
          dr.Item("userid") = ""
        End If
        dr.Item("newgross") = ._CGRS
        WrkExam = ._EX1 + ._EX2 + ._EX3 + ._EX4 + ._EX5 + ._EX6 + ._EX7
        dr.Item("newex") = WrkExam
        dr.Item("newnet") = ._CNETAS
        dr.Item("newdue") = ._CETAX
        GetPrevCC(Found, WrkGross, WrkEx, WrkNet, WrkDue)
        dr.Item("origgross") = 0
        dr.Item("origex") = 0
        dr.Item("orignet") = 0
        dr.Item("origdue") = 0
        If Found Then
          dr.Item("origgross") = WrkGross
          dr.Item("origex") = WrkEx
          dr.Item("orignet") = WrkNet
          dr.Item("origdue") = WrkDue
        Else
          myTXINV.GetOneRecordP(._LISTNo, ._YEAR, ._TYPE)
          If Not myTXINV.RecordNotFound Then
            With myTXINV
              WrkExam = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5
              dr.Item("origgross") = ._GROSS
              dr.Item("origex") = WrkExam
              dr.Item("orignet") = ._NETASS
              dr.Item("origdue") = ._TAXT
            End With
          Else
            dr.Item("newgross") = ._GRCHG
            dr.Item("newex") = ._EXCHG
            dr.Item("newnet") = ._GRCHG - ._EXCHG
            dr.Item("chggross") = ._GRCHG
            dr.Item("chgex") = ._EXCHG
            dr.Item("chgnet") = ._GRCHG - ._EXCHG
          End If
        End If
        If Not myTXINV.RecordNotFound Or Found Then
          dr.Item("chggross") = dr.Item("newgross") - dr.Item("origgross")
          dr.Item("chgex") = dr.Item("newex") - dr.Item("origex")
          dr.Item("chgnet") = dr.Item("newnet") - dr.Item("orignet")
        End If
        dr.Item("chgdue") = dr.Item("newdue") - dr.Item("origdue")
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
        If dr.Item("chgdue") > 0 Then
          WrkDueIncr = WrkDueIncr + dr.Item("chgdue")
        Else
          WrkDueDecr = WrkDueDecr + dr.Item("chgdue")
        End If
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

    myTXCOEAQ.CloseFile()
    myTXINV.CloseFile()

  End Sub
  Public Sub GetPrevCC(ByRef Found As Boolean,
    ByRef Out_Gross As Integer, ByRef Out_Ex As Integer, ByRef Out_Net As Integer,
    ByRef Out_Due As Decimal)
    Dim MyTXCOEAL1 As TXCOEAL1.MyData
    Dim dsTXCOEAL1 As DataSet = New DataSet
    Dim WrkType As String
    Dim WrkProrate As Integer
    Dim WrkPurchNet As Integer
    Dim WrkSaleNet As Integer
    Dim WrkCRSaleNet As Integer
    Dim WrkPct As Single
    Dim WrkMonth As Integer

    MyTXCOEAL1 = New TXCOEAL1.MyData(myDBConnect)

    Out_Net = 0
    Out_Due = 0
    Found = False
    With myTXCOEAQ
      dsTXCOEAL1 = MyTXCOEAL1.GetDescList(._LISTNo, ._YEAR, ._TYPE,
      ._CHDATE, ._CHTIME, 2)
    End With
    If dsTXCOEAL1.Tables(0).Rows.Count > 1 Then
      With dsTXCOEAL1.Tables(0).Rows(1)
        Found = True
        Out_Gross = .Item("cgrs")
        Out_Ex = .Item("ex1") + .Item("ex2") + .Item("ex3") + .Item("ex4") + .Item("ex5") + .Item("ex6") + .Item("ex7")
        WrkType = .Item("type")
        Select Case WrkType
          Case "R", "P"
            Out_Net = Out_Gross - Out_Ex
          Case "M"
            CalcProrateCode("M", .Item("C1MPCD"), .Item("CGRS"), WrkProrate, WrkPurchNet, WrkPct, WrkMonth)
            Out_Net = FormatNumber(WrkPurchNet, 0)
          Case "S"
            CalcProrateCode("P", .Item("C1MPCD"), .Item("CGRS"), WrkProrate, WrkPurchNet, WrkPct, WrkMonth)
            CalcProrateCode("S", .Item("C1MSCD"), .Item("CGRS"), WrkProrate, WrkSaleNet, WrkPct, WrkMonth)
            'Check for Credit Vehicle Gross
            If .Item("C1CSCD") <> "" Then
              CalcProrateCode("C", .Item("C1CSCD"), .Item("NEWMVC"), WrkProrate, WrkCRSaleNet, WrkPct, WrkMonth)
            End If
            Out_Net = FormatNumber(WrkPurchNet - WrkSaleNet - WrkCRSaleNet, 0)
        End Select
        Out_Due = .Item("cetax")
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
    WrkTDueIncr = WrkTDueIncr + WrkDueIncr
    WrkTDueDecr = WrkTDueDecr + WrkDueDecr
  End Sub
  Private Sub AddDiffTotals()
    If WrkGrossIncr >= Math.Abs(WrkGrossDecr) Then
      WrkTGrossIncr = WrkTGrossIncr + WrkGrossIncr
    Else
      WrkTGrossDecr = WrkTGrossDecr + WrkGrossDecr
    End If
    If WrkExIncr >= Math.Abs(WrkExDecr) Then
      WrkTExIncr = WrkTExIncr + WrkExIncr
    Else
      WrkTExDecr = WrkTExDecr + WrkExDecr
    End If
    If WrkNetIncr >= Math.Abs(WrkNetDecr) Then
      WrkTNetIncr = WrkTNetIncr + WrkNetIncr
    Else
      WrkTNetDecr = WrkTNetDecr + WrkNetDecr
    End If
    If WrkDueIncr >= Math.Abs(WrkDueDecr) Then
      WrkTDueIncr = WrkTDueIncr + WrkDueIncr + WrkDueDecr
    Else
      WrkTDueDecr = WrkTDueDecr + WrkDueDecr + WrkDueIncr
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
    dr2.Item("tdueincr") = WrkTDueIncr
    dr2.Item("tduedecr") = WrkTDueDecr
    dr2.Item("tnetdiff") = WrkTNetIncr + WrkTNetDecr
    dr2.Item("tduediff") = WrkTDueIncr + WrkTDueDecr
    ds2.Tables(0).Rows.Add(dr2)
  End Sub

End Module
