Module ProcessPP
  Dim myTXPPRPQ As TXPPRPQ.MyData
  Dim myTXPPRP As TXPPRP.MyData
  Dim myTXPPRPC As TXPPRPC.MyData
  Dim myTXBTR As TXBTR.MyData
  Dim myTXBAA As TXBAA.MyData

  Dim WrkYear As Integer
  'Totals
  Dim WrkBAss(9) As Integer
  Dim WrkTotBTR As Integer
  Const WrkType As String = "P"
  Public Sub ProcPP()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim WrkExempt As Integer
    Dim WrkPct As Integer
    Dim SavePct As Integer

    myTXPPRPQ = New TXPPRPQ.MyData(myDBConnect)
    myTXPPRP = New TXPPRP.MyData(myDBConnect)
    myTXPPRPC = New TXPPRPC.MyData(myDBConnect)
    myTXBTR = New TXBTR.MyData(myDBConnect)
    myTXBAA = New TXBAA.MyData(myDBConnect)

    With MyFrmTAD03B
      WrkYear = MyUtils.CnvSng(.TxtYear.Text)
    End With

    MyFrmProgress = New FrmProgress
    MyFrmProgress.LblMsg.Text = "Personal Property"
    MyFrmProgress.Show()
    MyFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0
    WrkQry = ""
    WrkSort = ""

    myTXPPRPQ.OpenQry(WrkSort, WrkQry)

ReadNext:
    myTXPPRPQ.ReadQry()
    If Not myTXPPRPQ.IsEOF Then
      Counter = Counter + 1

      With myTXPPRP
        .GetOneRecordP(myTXPPRPQ._LISTNO)
        If ._BTR <> 0 Or ._DTBTR > 0 Then
          WriteTXBAA(._LISTNO, WrkYear)
          WrkExempt = ._GROSS - ._NET
          UpdateFrozen()
          ._GROSS = ._GROSS + WrkTotBTR
          ._NET = ._NET + WrkTotBTR
          ._ASS1 = ._ASS1 + WrkBAss(0)
          ._ASS2 = ._ASS2 + WrkBAss(1)
          ._ASS3 = ._ASS3 + WrkBAss(2)
          ._ASS4 = ._ASS4 + WrkBAss(3)
          ._ASS5 = ._ASS5 + WrkBAss(4)
          ._ASS6 = ._ASS6 + WrkBAss(5)
          ._ASS7 = ._ASS7 + WrkBAss(6)
          ._ASS8 = ._ASS8 + WrkBAss(7)
          ._ASS9 = ._ASS9 + WrkBAss(8)
          ._ASS10 = ._ASS10 + WrkBAss(9)
          ._BTR = 0
          ._DTBTR = 0
          ._DNBTR = ""
          .UpdateOneRecordP()
        End If
      End With

      With MyFrmProgress
          WrkPct = (Counter / 10) Mod 100
          If SavePct <> WrkPct Then
            .ProgBar1.Value = WrkPct
            .LblMsg.Text = "Personal Property: Records processed: " & Counter
            .Refresh()
            SavePct = WrkPct
            Application.DoEvents()
          End If
        End With
      GoTo ReadNext
    End If
    MyFrmProgress.Close()
    myTXPPRPQ = Nothing
  End Sub
  Private Sub UpdateFrozen()
    myTXPPRPC = New TXPPRPC.MyData(myDBConnect)

    myTXPPRPC.GetOneRecordP(myTXPPRP._LISTNO)
    With myTXPPRPC
      ._BTR = myTXPPRP._BTR
      ._DTBTR = myTXPPRP._DTBTR
      ._DNBTR = myTXPPRP._DNBTR
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
      ._ASS1 = myTXPPRP._ASS1
      ._ASS2 = myTXPPRP._ASS2
      ._ASS3 = myTXPPRP._ASS3
      ._ASS4 = myTXPPRP._ASS4
      ._ASS5 = myTXPPRP._ASS5
      ._ASS6 = myTXPPRP._ASS6
      ._ASS7 = myTXPPRP._ASS7
      ._ASS8 = myTXPPRP._ASS8
      ._ASS9 = myTXPPRP._ASS9
      ._ASS10 = myTXPPRP._ASS10
      ._CODE1 = myTXPPRP._CODE1
      ._CODE2 = myTXPPRP._CODE2
      ._CODE3 = myTXPPRP._CODE3
      ._CODE4 = myTXPPRP._CODE4
      ._CODE5 = myTXPPRP._CODE5
      ._CODE6 = myTXPPRP._CODE6
      ._CODE7 = myTXPPRP._CODE7
      ._CODE8 = myTXPPRP._CODE8
      ._CODE9 = myTXPPRP._CODE9
      ._CODEA = myTXPPRP._CODEA
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
      ._DNBTR = myTXPPRP._DNBTR
      ._DTBTR = myTXPPRP._DTBTR
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






