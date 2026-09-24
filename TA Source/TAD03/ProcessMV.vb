Module ProcessMV
  Dim myTXMVDQ As TXMVDQ.MyData
  Dim myTXMVD As TXMVD.MyData
  Dim myTXMVDC As TXMVDC.MyData
  Dim myTXBTR As TXBTR.MyData
  Dim myTXBAA As TXBAA.MyData

  Dim WrkYear As Integer
  'Totals
  Dim WrkBAss(9) As Integer
  Dim WrkTotBTR As Integer
  Const WrkType As String = "M"
  Public Sub ProcMV()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim WrkPct As Integer
    Dim SavePct As Integer

    myTXMVDQ = New TXMVDQ.MyData(myDBConnect)
    myTXMVD = New TXMVD.MyData(myDBConnect)
    myTXMVDC = New TXMVDC.MyData(myDBConnect)
    myTXBTR = New TXBTR.MyData(myDBConnect)
    myTXBAA = New TXBAA.MyData(myDBConnect)

    With MyFrmTAD03B
      WrkYear = MyUtils.CnvSng(.TxtYear.Text)
    End With

    MyFrmProgress = New FrmProgress
    MyFrmProgress.LblMsg.Text = "Motor Vehicle"
    MyFrmProgress.Show()
    MyFrmProgress.Refresh()
    Application.DoEvents()

    WrkQry = ""
    WrkSort = ""

    myTXMVDQ.OpenQry(WrkSort, WrkQry)

ReadNext:
    myTXMVDQ.ReadQry()
    If Not myTXMVDQ.IsEOF Then
      Counter = Counter + 1
      With myTXMVD
        .GetOneRecordP(myTXMVDQ._LISTNo)
        If ._BTR <> 0 Or ._DTBTR > 0 Then
          UpdateFrozen()
          WriteTXBAA(._LISTNO, WrkYear)
          ._VALUE = ._VALUE + WrkTotBTR
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
          .LblMsg.Text = "Motor Vehicle: Records processed: " & Counter
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
      GoTo ReadNext
    End If

    MyFrmProgress.Close()
    myTXMVDQ = Nothing
  End Sub
  Private Sub UpdateFrozen()
    myTXMVDC = New TXMVDC.MyData(myDBConnect)

    myTXMVDC.GetOneRecordP(myTXMVD._LISTNO)
    With myTXMVDC
      ._BTR = myTXMVD._BTR
      ._DTBTR = myTXMVD._DTBTR
      ._DNBTR = myTXMVD._DNBTR
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
      WrkBAss(1) = 0
      WrkBAss(2) = 0
      WrkBAss(3) = 0
      WrkBAss(4) = 0
      WrkBAss(5) = 0
      WrkBAss(6) = 0
      WrkBAss(7) = 0
      WrkBAss(8) = 0
      WrkBAss(9) = 0
    End With

    For I = 0 To 9
      WrkTotBTR = WrkTotBTR + WrkBAss(I)
    Next
    myTXBAA.GetOneRecordP(ListNo, WrkType, Year)
    With myTXBAA
      ._ASS1 = myTXMVD._VALUE
      ._ASS2 = 0
      ._ASS3 = 0
      ._ASS4 = 0
      ._ASS5 = 0
      ._ASS6 = 0
      ._ASS7 = 0
      ._ASS8 = 0
      ._ASS9 = 0
      ._ASS10 = 0
      ._CODE1 = 0
      ._CODE2 = 0
      ._CODE3 = 0
      ._CODE4 = 0
      ._CODE5 = 0
      ._CODE6 = 0
      ._CODE7 = 0
      ._CODE8 = 0
      ._CODE9 = 0
      ._CODEA = 0
      ._BASS1 = WrkBAss(0)
      ._BASS2 = 0
      ._BASS3 = 0
      ._BASS4 = 0
      ._BASS5 = 0
      ._BASS6 = 0
      ._BASS7 = 0
      ._BASS8 = 0
      ._BASS9 = 0
      ._BASSA = 0
      ._DNBTR = myTXMVD._DNBTR
      ._DTBTR = myTXMVD._DTBTR
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






