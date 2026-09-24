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

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  'Screen  
  Dim WrkSelFund As Integer
  Dim WrkSelsfund As Integer
  'General
  Dim SaveGltyp As String
  Dim WrkHist As Boolean
  Public Sub ProcFile()
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
    Dim WrkAct1 As Boolean
    Dim WrkAct2 As Boolean
    Dim WrkAct3 As Boolean
    Dim WrkAct4 As Boolean
    Dim WrkAct5 As Boolean
    Dim WrkMsg As String
    myLEDGERQ = New LEDGERQ.MyData()
    myLEDGERQ.MyDBConn = myDBConnect
    myLEDHSTQ = New LEDHSTQ.MyData()
    myLEDHSTQ.MyDBConn = myDBConnect
    myGLACCTQ = New GLACCTQ.MyData()
    myGLACCTQ.MyDBConn = myDBConnect
    myGLBUDGET = New GLBUDGET.MyData()
    myGLBUDGET.MyDBConn = myDBConnect

    With MyFrmGL520B
      WrkSelFund = MyUtils.CnvSng(.TxtFund.Text)
      WrkSelsfund = MyUtils.CnvSng(.TxtSfund.Text)
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
      WrkAct1 = .ChkAct1.Checked
      WrkAct2 = .ChkAct2.Checked
      WrkAct3 = .ChkAct3.Checked
      WrkAct4 = .ChkAct4.Checked
      WrkAct5 = .ChkAct5.Checked
    End With

    WrkMsg = ""
    If WrkAct1 Then
      GetYearsAgo(1, WrkDateFrom1Yr, WrkDateTo1Yr)
      WrkMsg = "1 year Ago"
    End If
    If WrkAct2 Then
      HistYearsAgo(2, WrkDateFrom2Yr, WrkDateTo2Yr)
      If Not WrkHist Then
        GetYearsAgo(2, WrkDateFrom2Yr, WrkDateTo2Yr)
      End If
      WrkMsg = WrkMsg & " " & "2 years Ago"
      End If
    If WrkAct3 Then
      HistYearsAgo(3, WrkDateFrom3Yr, WrkDateTo3Yr)
      If Not WrkHist Then
        GetYearsAgo(3, WrkDateFrom3Yr, WrkDateTo3Yr)
      End If
      WrkMsg = WrkMsg & " " & "3 years Ago"
    End If
      If WrkAct4 Then
      HistYearsAgo(4, WrkDateFrom4Yr, WrkDateTo4Yr)
      If Not WrkHist Then
        GetYearsAgo(4, WrkDateFrom4Yr, WrkDateTo4Yr)
      End If
      WrkMsg = WrkMsg & " " & "4 years Ago"
    End If
    If WrkAct5 Then
      HistYearsAgo(5, WrkDateFrom5Yr, WrkDateTo5Yr)
      If Not WrkHist Then
        GetYearsAgo(5, WrkDateFrom5Yr, WrkDateTo5Yr)
      End If
      WrkMsg = WrkMsg & " " & "5 years Ago"
    End If
    If WrkMsg <> "" Then
      MsgBox(WrkMsg, MsgBoxStyle.Information, "Budget File Actual Amounts updated")
    End If
  End Sub
  Private Sub GetYearsAgo(ByVal WrkYears As Integer, WrkDateFrom As Integer, WrkDateTo As Integer)
    Dim WrkMult As Integer
    Dim WrkAmount As Integer
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
    WrkHist = False

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
      WrkHist = True
    End If
  End Sub
End Module
