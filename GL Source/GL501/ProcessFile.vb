Imports System.Text
Module ProcessFile

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myLEDGERQ As LEDGERQ.MyData
  Dim myLEDHSTQ As LEDHSTQ.MyData
  Dim myGLACCTQ As GLACCTQ.MyData
  Dim myGLBUDGET As GLBUDGET.MyData
  Dim WrkHist1 As Boolean
  Dim WrkHist2 As Boolean
  Dim WrkHist3 As Boolean
  Dim WrkHist4 As Boolean
  Dim WrkHist5 As Boolean

  'Screen  
  Dim WrkSelFund As Integer
  Dim WrkSelsfund As Integer
  'General
  Dim SaveGltyp As String
  Public Sub ProcFile()
    Dim WrkDateFrom As Integer
    Dim WrkDateTo As Integer
    Dim WrkDateFrom1Yr As Integer
    Dim WrkDateTo1Yr As Integer
    Dim WrkDateFrom2Yr As Integer
    Dim WrkDateTo2Yr As Integer
    Dim WrkDateFrom3Yr As Integer
    Dim WrkDateTo3Yr As Integer
    Dim WrkDateFrom4Yr As Integer
    Dim WrkDateTo4Yr As Integer
    Dim WrkDateFrom5Yr As Integer
    Dim WrkDateTo5Yr As Integer
    Dim WrkMsg As String
    myLEDGERQ = New LEDGERQ.MyData()
    myLEDGERQ.MyDBConn = myDBConnect
    myLEDHSTQ = New LEDHSTQ.MyData()
    myLEDHSTQ.MyDBConn = myDBConnect
    myGLACCTQ = New GLACCTQ.MyData()
    myGLACCTQ.MyDBConn = myDBConnect
    myGLBUDGET = New GLBUDGET.MyData()
    myGLBUDGET.MyDBConn = myDBConnect

    With MyFrmGL501B
      WrkSelFund = MyUtils.CnvSng(.TxtFund.Text)
      WrkSelsfund = MyUtils.CnvSng(.TxtSfund.Text)
      WrkDateFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkDateTo = MyUtils.SetDBDate(.DtPckTo.Value)
      WrkDateFrom1Yr = MyUtils.SetDBDate(DateAdd(DateInterval.Year, -1, .DtPckFrom.Value))
      WrkDateTo1Yr = MyUtils.SetDBDate(DateAdd(DateInterval.Year, -1, .DtPckTo.Value))
      WrkDateFrom2Yr = MyUtils.SetDBDate(DateAdd(DateInterval.Year, -2, .DtPckFrom.Value))
      WrkDateTo2Yr = MyUtils.SetDBDate(DateAdd(DateInterval.Year, -2, .DtPckTo.Value))
      WrkDateFrom3Yr = MyUtils.SetDBDate(DateAdd(DateInterval.Year, -3, .DtPckFrom.Value))
      WrkDateTo3Yr = MyUtils.SetDBDate(DateAdd(DateInterval.Year, -3, .DtPckTo.Value))
      WrkDateFrom4Yr = MyUtils.SetDBDate(DateAdd(DateInterval.Year, -4, .DtPckFrom.Value))
      WrkDateTo4Yr = MyUtils.SetDBDate(DateAdd(DateInterval.Year, -4, .DtPckTo.Value))
      WrkDateFrom5Yr = MyUtils.SetDBDate(DateAdd(DateInterval.Year, -5, .DtPckFrom.Value))
      WrkDateTo5Yr = MyUtils.SetDBDate(DateAdd(DateInterval.Year, -5, .DtPckTo.Value))
    End With

    WrkHist1 = False
    WrkHist2 = False
    WrkHist3 = False
    WrkHist4 = False
    WrkHist5 = False
    myGLBUDGET.DeleteFund(WrkSelFund)
    AddAccts(WrkSelFund)
    HistYearsAgo(5, WrkDateFrom5Yr, WrkDateTo5Yr)
    HistYearsAgo(4, WrkDateFrom4Yr, WrkDateTo4Yr)
    HistYearsAgo(3, WrkDateFrom3Yr, WrkDateTo3Yr)
    HistYearsAgo(2, WrkDateFrom2Yr, WrkDateTo2Yr)
    HistYearsAgo(1, WrkDateFrom1Yr, WrkDateTo1Yr)
    myLEDHSTQ = Nothing

    If Not WrkHist5 Then GetYearsAgo(5, WrkDateFrom5Yr, WrkDateTo5Yr)
    If Not WrkHist4 Then GetYearsAgo(4, WrkDateFrom4Yr, WrkDateTo4Yr)
    If Not WrkHist3 Then GetYearsAgo(3, WrkDateFrom3Yr, WrkDateTo3Yr)
    If Not WrkHist2 Then GetYearsAgo(2, WrkDateFrom2Yr, WrkDateTo2Yr)
    If Not WrkHist1 Then GetYearsAgo(1, WrkDateFrom1Yr, WrkDateTo1Yr)
    GetCurrYear(WrkDateFrom, WrkDateTo)

    WrkMsg = "Accounts added to budget" & vbCrLf
    If WrkHist5 Then
      WrkMsg = WrkMsg & "5 Years ago: History" & vbCrLf
    Else
      WrkMsg = WrkMsg & "5 Years ago: Ledger" & vbCrLf
    End If
    If WrkHist4 Then
      WrkMsg = WrkMsg & "4 Years ago: History" & vbCrLf
    Else
      WrkMsg = WrkMsg & "4 Years ago: Ledger" & vbCrLf
    End If
    If WrkHist3 Then
      WrkMsg = WrkMsg & "3 Years ago: History" & vbCrLf
    Else
      WrkMsg = WrkMsg & "3 Years ago: Ledger" & vbCrLf
    End If
    If WrkHist2 Then
      WrkMsg = WrkMsg & "2 Years ago: History" & vbCrLf
    Else
      WrkMsg = WrkMsg & "2 Years ago: Ledger" & vbCrLf
    End If
    If WrkHist1 Then
      WrkMsg = WrkMsg & "1 Year ago: History" & vbCrLf
    Else
      WrkMsg = WrkMsg & "1 Year ago: Ledger" & vbCrLf
    End If
    WrkMsg = WrkMsg & "Current: Ledger"
    MsgBox(WrkMsg, MsgBoxStyle.Information, "Budget File Created")
  End Sub
  Private Sub AddAccts(ByVal WrkFund As Integer)
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim WrkAnd As String
    Dim WrkOr As String

    WrkAnd = " and "
    WrkOr = " or "
    WrkQry = "ACREC=''" & WrkAnd & "GLTYP in ('R','X')"
    If WrkFund > 0 Then
      WrkQry = WrkQry & WrkAnd & "FDNBR=" & WrkFund
    End If
    WrkSort = ""
    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Add new accounts"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    myGLACCTQ.OpenQry(WrkSort, WrkQry)

ReadNext:
    myGLACCTQ.ReadQry()
    If Not myGLACCTQ.IsEOF Then
      With myGLACCTQ
        Counter = Counter + 1
        myGLBUDGET.GetOneRecordP(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
        If myGLBUDGET.RecordNotFound Then
          myGLBUDGET._DEPT = ._DPNBR
          myGLBUDGET._DESCD = ._GLDSC
          myGLBUDGET._FUNC = ._FNPGM
          myGLBUDGET._FUND = ._FDNBR
          myGLBUDGET._GLTYP = ._GLTYP
          myGLBUDGET._OBJ = ._OBNBR
          myGLBUDGET._SFUNC = ._SUBFN
          myGLBUDGET._SFUND = ._SFUND
          myGLBUDGET._DCODE = ""
          myGLBUDGET._REV = ""
          myGLBUDGET.AddOneRecordP()
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
    myGLACCTQ.CloseFile()
    myGLACCTQ = Nothing 'GLACCT Reader interfering with LEDGERQ Reader
  End Sub
  Private Sub HistYearsAgo(ByVal WrkYears As Integer, WrkDateFrom As Integer, WrkDateTo As Integer)
    Dim WrkMult As Integer
    Dim WrkAmount As Decimal
    Dim WrkAcct As String
    Dim SaveAcct As String
    Dim SaveFund As Integer
    Dim SaveSfund As Integer
    Dim SaveDept As Integer
    Dim SaveObj As Integer
    Dim SaveFnpgm As Integer
    Dim SaveSubfn As Integer
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim FoundHist As Boolean
    Dim WrkAnd As String
    Dim WrkOr As String

    WrkAnd = " and "
    WrkOr = " or "
    WrkQry = "FDNBR=" & WrkSelFund & WrkAnd & "SFUND=" & WrkSelsfund
    WrkQry = WrkQry & WrkAnd & "PSTDT >= " & WrkDateFrom & WrkAnd & "PSTDT <= " & WrkDateTo
    WrkQry = WrkQry & WrkAnd & "TRTYP = 'X'" & WrkAnd & "GLTYP IN ('R','X')"
    WrkSort = "FDNBR, SFUND, DPNBR, OBNBR, FNPGM, SUBFN"
    myLEDHSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Previous Years " & WrkYears
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkAcct = ""
    SaveAcct = ""
    WrkAmount = 0
    Counter = 0
    FoundHist = False

ReadNext:
    myLEDHSTQ.ReadQry()
    If Not myLEDHSTQ.IsEOF Then
      With myLEDHSTQ
        Counter = Counter + 1
        WrkAcct = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
        If WrkAcct <> SaveAcct And SaveAcct <> "" Then
          With myGLBUDGET
            .GetOneRecordP(SaveFund, SaveSfund, SaveDept, SaveObj, SaveFnpgm, SaveSubfn)
            If Not .RecordNotFound Then
              FoundHist = True
              Select Case WrkYears
                Case 1
                  ._ACT1 = Math.Round(WrkAmount, 0)
                Case 2
                  ._ACT2 = Math.Round(WrkAmount, 0)
                Case 3
                  ._ACT3 = Math.Round(WrkAmount, 0)
                Case 4
                  ._ACT4 = Math.Round(WrkAmount, 0)
                Case 5
                  ._ACT5 = Math.Round(WrkAmount, 0)
              End Select
              myGLBUDGET.UpdateOneRecordP()
            End If
          End With 'myglbudget
          WrkAmount = 0
        End If
        If ._GLTYP = "R" Then
          WrkMult = -1
        Else
          WrkMult = 1
        End If
        If ._AMTYP = "D" Then
          WrkAmount = WrkAmount + (._TRAMT * WrkMult)
        Else
          WrkAmount = WrkAmount - (._TRAMT * WrkMult)
        End If
        SaveAcct = WrkAcct
        SaveFund = ._FDNBR
        SaveSfund = ._SFUND
        SaveDept = ._DPNBR
        SaveObj = ._OBNBR
        SaveFnpgm = ._FNPGM
        SaveSubfn = ._SUBFN
      End With 'myLEDGERQ

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

    If SaveAcct <> "" Then
      myGLBUDGET.GetOneRecordP(SaveFund, SaveSfund, SaveDept, SaveObj, SaveFnpgm, SaveSubfn)
      With myGLBUDGET
        If Not .RecordNotFound Then
          Select Case WrkYears
            Case 1
              ._ACT1 = Math.Round(WrkAmount, 0)
            Case 2
              ._ACT2 = Math.Round(WrkAmount, 0)
            Case 3
              ._ACT3 = Math.Round(WrkAmount, 0)
            Case 4
              ._ACT4 = Math.Round(WrkAmount, 0)
            Case 5
              ._ACT5 = Math.Round(WrkAmount, 0)
          End Select
          myGLBUDGET.UpdateOneRecordP()
        End If
      End With 'myglbudget
    End If

    myFrmProgress.Close()
    myLEDHSTQ.CloseFile()
    If FoundHist Then
      Select Case WrkYears
        Case 5
          WrkHist5 = True
        Case 4
          WrkHist4 = True
        Case 3
          WrkHist3 = True
        Case 2
          WrkHist2 = True
        Case 1
          WrkHist1 = True
      End Select
    End If

  End Sub
  Private Sub GetYearsAgo(ByVal WrkYears As Integer, WrkDateFrom As Integer, WrkDateTo As Integer)
    Dim WrkMult As Integer
    Dim WrkAmount As Decimal
    Dim WrkAcct As String
    Dim SaveAcct As String
    Dim SaveFund As Integer
    Dim SaveSfund As Integer
    Dim SaveDept As Integer
    Dim SaveObj As Integer
    Dim SaveFnpgm As Integer
    Dim SaveSubfn As Integer
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim WrkAnd As String
    Dim WrkOr As String

    WrkAnd = " and "
    WrkOr = " or "
    WrkQry = "FDNBR=" & WrkSelFund & WrkAnd & "SFUND=" & WrkSelsfund
    WrkQry = WrkQry & WrkAnd & "PSTDT >= " & WrkDateFrom & WrkAnd & "PSTDT <= " & WrkDateTo
    WrkQry = WrkQry & WrkAnd & "TRTYP = 'X'" & WrkAnd & "GLTYP IN ('R','X')"
    WrkSort = "FDNBR, SFUND, DPNBR, OBNBR, FNPGM, SUBFN"
    myLEDGERQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Previous Years " & WrkYears
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkAcct = ""
    SaveAcct = ""
    WrkAmount = 0

ReadNext:
    myLEDGERQ.ReadQry()
    If Not myLEDGERQ.IsEOF Then
      With myLEDGERQ
        Counter = Counter + 1
        WrkAcct = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
        If WrkAcct <> SaveAcct And SaveAcct <> "" Then
          With myGLBUDGET
            .GetOneRecordP(SaveFund, SaveSfund, SaveDept, SaveObj, SaveFnpgm, SaveSubfn)
            If Not .RecordNotFound Then
              Select Case WrkYears
                Case 1
                  ._ACT1 = Math.Round(WrkAmount, 0)
                Case 2
                  ._ACT2 = Math.Round(WrkAmount, 0)
                Case 3
                  ._ACT3 = Math.Round(WrkAmount, 0)
                Case 4
                  ._ACT4 = Math.Round(WrkAmount, 0)
                Case 5
                  ._ACT5 = Math.Round(WrkAmount, 0)
              End Select
              myGLBUDGET.UpdateOneRecordP()
            End If
          End With 'myglbudget
          WrkAmount = 0
        End If
        If ._GLTYP = "R" Then
          WrkMult = -1
        Else
          WrkMult = 1
        End If
        If ._AMTYP = "D" Then
          WrkAmount = WrkAmount + (._TRAMT * WrkMult)
        Else
          WrkAmount = WrkAmount - (._TRAMT * WrkMult)
        End If
        SaveAcct = WrkAcct
        SaveFund = ._FDNBR
        SaveSfund = ._SFUND
        SaveDept = ._DPNBR
        SaveObj = ._OBNBR
        SaveFnpgm = ._FNPGM
        SaveSubfn = ._SUBFN
      End With 'myLEDGERQ

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

    If SaveAcct <> "" Then
      myGLBUDGET.GetOneRecordP(SaveFund, SaveSfund, SaveDept, SaveObj, SaveFnpgm, SaveSubfn)
      With myGLBUDGET
        If Not .RecordNotFound Then
          Select Case WrkYears
            Case 1
              ._ACT1 = WrkAmount
            Case 2
              ._ACT2 = WrkAmount
            Case 3
              ._ACT3 = WrkAmount
            Case 4
              ._ACT4 = WrkAmount
            Case 5
              ._ACT5 = WrkAmount
          End Select
          myGLBUDGET.UpdateOneRecordP()
        End If
      End With 'myglbudget
    End If

    myFrmProgress.Close()
    myLEDGERQ.CloseFile()
  End Sub
  Private Sub GetCurrYear(WrkDateFrom As Integer, WrkDateTo As Integer)
    Dim WrkCurr As Decimal
    Dim WrkOrig As Decimal
    Dim WrkExp As Decimal
    Dim WrkAcct As String
    Dim SaveAcct As String
    Dim SaveFund As Integer
    Dim SaveSfund As Integer
    Dim SaveDept As Integer
    Dim SaveObj As Integer
    Dim SaveFnpgm As Integer
    Dim SaveSubfn As Integer
    Dim WrkQry As String
    Dim WrkSort As String
    Dim SaveQry As String
    Dim Counter As Integer
    Dim WrkAnd As String
    Dim WrkOr As String

    WrkAnd = " and "
    WrkOr = " or "
    WrkQry = "FDNBR=" & WrkSelFund & WrkAnd & "SFUND=" & WrkSelsfund
    WrkQry = WrkQry & WrkAnd & "PSTDT >= " & WrkDateFrom & WrkAnd & "PSTDT <= " & WrkDateTo
    SaveQry = WrkQry
    WrkQry = WrkQry & WrkAnd & "TRTYP = 'B'"
    WrkQry = WrkQry & WrkAnd & "GLTYP IN ('R','X')"
    WrkQry = WrkQry & WrkOr & SaveQry
    WrkQry = WrkQry & WrkAnd & "TRTYP = 'X'"
    WrkQry = WrkQry & WrkAnd & "GLTYP IN ('R','X')"
    WrkSort = "FDNBR, SFUND, DPNBR, OBNBR, FNPGM, SUBFN"
    myLEDGERQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Current Year"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkAcct = ""
    SaveAcct = ""
    WrkCurr = 0
    WrkOrig = 0
    WrkExp = 0

ReadNext:
    myLEDGERQ.ReadQry()
    If Not myLEDGERQ.IsEOF Then
      With myLEDGERQ
        Counter = Counter + 1
        WrkAcct = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
        If WrkAcct <> SaveAcct And SaveAcct <> "" Then
          myGLBUDGET.GetOneRecordP(SaveFund, SaveSfund, SaveDept, SaveObj, SaveFnpgm, SaveSubfn)
          With myGLBUDGET
            If Not .RecordNotFound Then
              ._CURR = Math.Round(WrkCurr, 0)
              ._ORIG = Math.Round(WrkOrig, 0)
              ._EXP = Math.Round(WrkExp, 0)
              .UpdateOneRecordP()
            End If
          End With 'myglbudget
          WrkCurr = 0
          WrkOrig = 0
          WrkExp = 0
        End If
        Select Case ._TRTYP
          Case "B"
            If ._AMTYP = "D" And ._GLTYP = "X" Or ._AMTYP = "C" And ._GLTYP = "R" Then
              WrkCurr = WrkCurr + ._TRAMT
              WrkOrig = WrkOrig + ._ORIG
            Else
              WrkCurr = WrkCurr - ._TRAMT
              WrkOrig = WrkOrig - ._ORIG
            End If
          Case "X"
            If ._AMTYP = "D" And ._GLTYP = "X" Or ._AMTYP = "C" And ._GLTYP = "R" Then
              WrkExp = WrkExp + ._TRAMT
            Else
              WrkExp = WrkExp - ._TRAMT
            End If
        End Select
        SaveAcct = WrkAcct
        SaveFund = ._FDNBR
        SaveSfund = ._SFUND
        SaveDept = ._DPNBR
        SaveObj = ._OBNBR
        SaveFnpgm = ._FNPGM
        SaveSubfn = ._SUBFN
      End With 'myLEDGERQ

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

    If SaveAcct <> "" Then
      myGLBUDGET.GetOneRecordP(SaveFund, SaveSfund, SaveDept, SaveObj, SaveFnpgm, SaveSubfn)
      With myGLBUDGET
        If Not .RecordNotFound Then
          ._CURR = Math.Round(WrkCurr, 0)
          ._ORIG = Math.Round(WrkOrig, 0)
          ._EXP = Math.Round(WrkExp, 0)
          .UpdateOneRecordP()
        End If
      End With 'myglbudget
    End If

    myFrmProgress.Close()
    myLEDGERQ.CloseFile()
  End Sub
End Module
