Module ProcessRE
  Dim myTXREALQ As TXREALQ.MyData
  Dim myTXREAL As TXREAL.MyData
  Dim myTXREALC As TXREALC.MyData
  Dim myTXBTR As TXBTR.MyData
  Dim myTXBAA As TXBAA.MyData

  Dim WrkYear As Integer
  'Totals
  Dim WrkBAss(9) As Integer
  Dim WrkTotBTR As Integer
  Const WrkType As String = "R"

  Public Sub ProcRE()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkExempt As Integer
    Dim Counter As Integer
    Dim WrkPct As Integer
    Dim SavePct As Integer

    myTXREALQ = New TXREALQ.MyData(myDBConnect)
    myTXREAL = New TXREAL.MyData(myDBConnect)
    myTXBTR = New TXBTR.MyData(myDBConnect)
    myTXBAA = New TXBAA.MyData(myDBConnect)

    With MyFrmTAD03B
      WrkYear = MyUtils.CnvSng(.TxtYear.Text)
    End With

    MyFrmProgress = New FrmProgress
    MyFrmProgress.LblMsg.Text = "Real Estate"
    MyFrmProgress.Show()
    MyFrmProgress.Refresh()
    Application.DoEvents()

    WrkQry = ""
    WrkSort = ""

    myTXREALQ.OpenQry(WrkSort, WrkQry)

ReadNext:
    myTXREALQ.ReadQry()
    If Not myTXREALQ.IsEOF Then
      Counter = Counter + 1
      With myTXREAL
        .GetOneRecordP(myTXREALQ._LISTNO)
        ._BKCD = String.Empty
        ._BKSV = String.Empty
        If ._BTR <> 0 Or ._DTBTR > 0 Then
          WriteTXBAA(._LISTNO, WrkYear)
          UpdateFrozen()
          WrkExempt = ._GROSS - ._NET
          ._GROSS = ._GROSS + WrkTotBTR
          ._NET = ._NET + WrkTotBTR
          ._ASS1 = ._ASS1 + WrkBAss(0)
          ._ASS2 = ._ASS2 + WrkBAss(1)
          ._ASS3 = ._ASS3 + WrkBAss(2)
          ._ASS4 = ._ASS4 + WrkBAss(3)
          ._ASS5 = ._ASS5 + WrkBAss(4)
          ._ASS6 = ._ASS6 + WrkBAss(5)
          ._ASS7 = ._ASS7 + WrkBAss(6)
          ._BTR = 0
          ._DTBTR = 0
          ._DNBTR = ""
          .UpdateOneRecordP()
        End If
        Counter = Counter + 1
      End With

      With MyFrmProgress
        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .LblMsg.Text = "Real Estate: Records processed: " & Counter
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
      GoTo ReadNext
    End If

    MyFrmProgress.Close()
    myTXREALQ = Nothing
  End Sub
  Private Sub UpdateFrozen()
    myTXREALC = New TXREALC.MyData(myDBConnect)

    myTXREALC.GetOneRecordP(myTXREAL._LISTNO)
    With myTXREALC
      ._BTR = myTXREAL._BTR
      ._DTBTR = myTXREAL._DTBTR
      ._DNBTR = myTXREAL._DNBTR
      .UpdateOneRecordP()
    End With
  End Sub
  Private Sub WriteTXBAA(ByVal ListNo As Integer, ByVal Year As Integer)
    Dim I As Integer

    Array.Clear(WrkBAss, 0, 10)
    WrkTotBTR = 0
    myTXBTR.GetOneRecordP(ListNo, WrkType)
    If myTXBTR.RecordNotFound Then Exit Sub

    With myTXBTR
      WrkBAss(0) = ._BASS1
      WrkBAss(1) = ._BASS2
      WrkBAss(2) = ._BASS3
      WrkBAss(3) = ._BASS4
      WrkBAss(4) = ._BASS5
      WrkBAss(5) = ._BASS6
      WrkBAss(6) = ._BASS7
      WrkBAss(7) = ._BASS8
      WrkBAss(8) = ._BASS9
      WrkBAss(9) = ._BASSA
      For I = 0 To 9
        WrkTotBTR = WrkTotBTR + WrkBAss(I)
      Next
    End With
    myTXBAA.GetOneRecordP(ListNo, WrkType, Year)
    With myTXBAA
      ._ASS1 = myTXREAL._ASS1
      ._ASS2 = myTXREAL._ASS2
      ._ASS3 = myTXREAL._ASS3
      ._ASS4 = myTXREAL._ASS4
      ._ASS5 = myTXREAL._ASS5
      ._ASS6 = myTXREAL._ASS6
      ._ASS7 = myTXREAL._ASS7
      ._ASS8 = 0
      ._ASS9 = 0
      ._ASS10 = 0
      ._CODE1 = myTXREAL._CODE1
      ._CODE2 = myTXREAL._CODE2
      ._CODE3 = myTXREAL._CODE3
      ._CODE4 = myTXREAL._CODE4
      ._CODE5 = myTXREAL._CODE5
      ._CODE6 = myTXREAL._CODE6
      ._CODE7 = myTXREAL._CODE7
      ._CODE8 = 0
      ._CODE9 = 0
      ._CODEA = 0
      ._BASS1 = WrkBAss(0)
      ._BASS2 = WrkBAss(1)
      ._BASS3 = WrkBAss(2)
      ._BASS4 = WrkBAss(3)
      ._BASS5 = WrkBAss(4)
      ._BASS6 = WrkBAss(5)
      ._BASS7 = WrkBAss(6)
      ._BASS8 = WrkBAss(7)
      ._BASS9 = WrkBAss(8)
      ._BASSA = WrkBAss(9)
      ._DNBTR = myTXREAL._DNBTR
      ._DTBTR = myTXREAL._DTBTR
      If Not myTXBAA.RecordNotFound Then
        myTXBAA.UpdateOneRecordP()
      Else
        ._LISTNO = ListNo
        ._YEAR = Year
        ._TYPE = WrkType
        myTXBAA.AddOneRecordP()
      End If
    End With

  End Sub
End Module






