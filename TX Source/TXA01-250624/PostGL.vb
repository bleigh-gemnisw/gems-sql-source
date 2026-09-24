Module PostGL
  Dim myTCRBCHL1 As TCRBCHL1.MyData
  Dim myNETGLBCH As NETGLBCH.MyData
  Dim myFrmProgress As FrmProgress

  Dim ds As DataSet = New DataSet
  Public Sub PstGL(ByVal BatchNo As Integer, ByVal WrkBatchA As String)
    Dim Counter As Integer
    Dim WrkPct As Integer
    Dim SavePct As Integer

    myTCRBCHL1 = New TCRBCHL1.MyData(myDBConnect)
    myNETGLBCH = New NETGLBCH.MyData()
    myNETGLBCH.MyDBConn = myDBConnect

    Counter = 0
    myFrmProgress = New FrmProgress
    myFrmProgress.Text = "Creating G/L Batch"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    myTCRBCHL1.SetRange(BatchNo)
    Do While Not myTCRBCHL1.IsEOF
      With myTCRBCHL1
        Counter = Counter + 1
        myTCRBCHL1.ReadFileE()
        If .IsEOF Then Exit Do
        myNETGLBCH.GetOneRecordP(BatchNo, Counter)
        If WrkBatchA = "W" Then
          myNETGLBCH._STAT = "W"
        Else
          myNETGLBCH._STAT = "L"
        End If
        myNETGLBCH._BATCH = BatchNo
        myNETGLBCH._SEQNO = Counter
        myNETGLBCH._LIST = ._LISTNo
        myNETGLBCH._YEAR = ._YEAR
        myNETGLBCH._TYPE = ._TYPE
        myNETGLBCH._PAMT = ._PAMT
        myNETGLBCH._IAMT = ._IAMT
        myNETGLBCH._LAMT = ._LAMT
        myNETGLBCH._PCAMT = ._PCAMT1
        myNETGLBCH._DIST = ._DIST
        myNETGLBCH._ADJCD = ._ADJ
        myNETGLBCH._PENCD = Trim(._PENCD1)
        myNETGLBCH._PSTDT = MyUtils.SetDBDate(Date.Now.Date)
        myNETGLBCH._PAYDT = ._RDTE
        myNETGLBCH.AddOneRecordP()

        If ._PCAMT2 <> 0 Then
          Counter = Counter + 1
          WriteNETGLBCH(BatchNo, Counter, WrkBatchA, ._PCAMT2, ._PENCD2)
        End If

        If ._PCAMT3 <> 0 Then
          Counter = Counter + 1
          WriteNETGLBCH(BatchNo, Counter, WrkBatchA, ._PCAMT3, ._PENCD3)
        End If

        If ._PCAMT4 <> 0 Then
          Counter = Counter + 1
          WriteNETGLBCH(BatchNo, Counter, WrkBatchA, ._PCAMT4, ._PENCD4)
        End If

        If ._PCAMT5 <> 0 Then
          Counter = Counter + 1
          WriteNETGLBCH(BatchNo, Counter, WrkBatchA, ._PCAMT5, ._PENCD5)
        End If

        If ._PCAMT6 <> 0 Then
          Counter = Counter + 1
          WriteNETGLBCH(BatchNo, Counter, WrkBatchA, ._PCAMT6, ._PENCD6)
        End If

        If ._PCAMT7 <> 0 Then
          Counter = Counter + 1
          WriteNETGLBCH(BatchNo, Counter, WrkBatchA, ._PCAMT7, ._PENCD7)
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
    Loop

    'Memory Cleanup
    myFrmProgress.Close()
    Application.DoEvents()
    myTCRBCHL1 = Nothing
    myNETGLBCH.CloseFile()
    myNETGLBCH = Nothing
  End Sub
  Public Sub WriteNETGLBCH(BatchNo As Integer, Seqno As Integer, WrkBatchA As String,
  Fee As Decimal, Pencd As String)
    myNETGLBCH.GetOneRecordP(BatchNo, Seqno)
    If WrkBatchA = "W" Then
      myNETGLBCH._STAT = "W"
    Else
      myNETGLBCH._STAT = "L"
    End If
    With myTCRBCHL1
      myNETGLBCH._BATCH = BatchNo
      myNETGLBCH._SEQNO = Seqno
      myNETGLBCH._LIST = ._LISTNo
      myNETGLBCH._YEAR = ._YEAR
      myNETGLBCH._TYPE = ._TYPE
      myNETGLBCH._PAMT = 0
      myNETGLBCH._IAMT = 0
      myNETGLBCH._LAMT = 0
      myNETGLBCH._PCAMT = Fee
      myNETGLBCH._DIST = ._DIST
      myNETGLBCH._ADJCD = ._ADJ
      myNETGLBCH._PENCD = Trim(Pencd)
      myNETGLBCH._PSTDT = MyUtils.SetDBDate(Date.Now.Date)
      myNETGLBCH._PAYDT = ._RDTE
      myNETGLBCH.AddOneRecordP()
      If myNETGLBCH.ErrMsg <> "" Then
        WriteErrorLog(myNETGLBCH.ErrMsg)
        Exit Sub
      End If
    End With

  End Sub

End Module






