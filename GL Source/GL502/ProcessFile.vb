Imports System.Text
Module ProcessFile

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myLEDGERQ As LEDGERQ.MyData
Dim myGLBUDGET As GLBUDGET.MyData

Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow
'Screen  
Dim WrkSelFund As Integer
Dim WrkSelsfund As Integer
'General
Dim SaveGltyp As String
Public Sub ProcFile()
  Dim WrkDateFrom As Integer
  Dim WrkDateTo As Integer
  myLEDGERQ = New LEDGERQ.MyData()
  myLEDGERQ.MyDBConn = myDBConnect
  myGLBUDGET = New GLBUDGET.MyData()
  myGLBUDGET.MyDBConn = myDBConnect

  With MyFrmGL502B
    WrkSelFund = MyUtils.CnvSng(.TxtFund.Text)
    WrkSelsfund = MyUtils.CnvSng(.TxtSfund.Text)
    WrkDateFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    WrkDateTo = MyUtils.SetDBDate(.DtPckTo.Value)
  End With

  GetCurrYear(WrkDateFrom, WrkDateTo)
  MsgBox("", MsgBoxStyle.Information, "Budget File Updated")
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
    WrkQry = WrkQry & WrkAnd & "GLTYP in ('R','X')"
    WrkQry = WrkQry & WrkOr & SaveQry
    WrkQry = WrkQry & WrkAnd & "TRTYP = 'X'"
    WrkQry = WrkQry & WrkAnd & "GLTYP in ('R','X')"
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
          With myGLBUDGET
            .GetOneRecordP(SaveFund, SaveSfund, SaveDept, SaveObj, SaveFnpgm, SaveSubfn)
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
      With myGLBUDGET
        .GetOneRecordP(SaveFund, SaveSfund, SaveDept, SaveObj, SaveFnpgm, SaveSubfn)
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
