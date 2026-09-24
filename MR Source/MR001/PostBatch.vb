Module PostMRBCH

  Dim myMRBCH As MRBCH.MyData
  Dim myMRBCHD As MRBCHD.MyData
  Dim myMRHST As MRHST.MyData
  Dim myFrmProgress As FrmProgress

  Dim ds As DataSet = New DataSet
  Public Sub PstMRBCH(ByVal BatchNo As Integer)

    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    Dim Counter As Integer
    Dim WrkRecovery As Boolean
    Dim WrkRecoveryNormal As Boolean
    Dim WrkPct As Integer
    Dim SavePct As Integer

    myMRBCH = New MRBCH.MyData()
    myMRBCH.MyDBConn = myDBConnect
    myMRBCHD = New MRBCHD.MyData()
    myMRBCHD.MyDBConn = myDBConnect
    myMRHST = New MRHST.MyData()
    myMRHST.MyDBConn = myDBConnect
    myMRBCH.GetOneRecordP(BatchNo)

    Counter = 0
    WrkRecovery = False
    WrkRecoveryNormal = False
    If myMRBCH.RecordNotFound Then Exit Sub

    With myMRBCH
      If Trim(._STATUS) = "P" Then
        MsgBox("This process will automatically determine what needs to be done to finish the batch posting", MsgBoxStyle.Exclamation, "Batch has partially posted. Batch recovery will start.")
        WrkRecovery = True
      Else
        ._STATUS = "P"
        .UpdateOneRecordP()
      End If
    End With

    myFrmProgress = New FrmProgress
    myFrmProgress.Text = "Posting Batch"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0

    myMRBCHD.OpenFile()
    myMRBCHD.SetRange(BatchNo)

    Do While Not myMRBCHD.IsEOF
      Counter = Counter + 1
      myMRBCHD.ReadFileE()
      With myMRBCHD
        If .IsEOF Then Exit Do
        myMRHST.GetOneRecordP(BatchNo, ._CODE)
        myMRHST._BCHNO = BatchNo
        With myMRBCH
          .GetOneRecordP(BatchNo)
          myMRHST._DESCR = ._DESCR
          myMRHST._RECDT = ._RECDT
          myMRHST._STRDT = ._STRDT
          myMRHST._ENDDT = ._ENDDT
          myMRHST._PRF = ._PRF
        End With
        myMRHST._CODE = ._CODE
        myMRHST._CASH = ._CASH
        myMRHST._CHECK = ._CHECK
        myMRHST._CREDIT = ._CREDIT
        myMRHST._TOTAL = ._TOTAL
        myMRHST._CHDATE = MyUtils.SetDBDate(Date.Now.Date)
        myMRHST._CHTIME = MyUtils.SetDBTime(Date.Now)
        myMRHST._STATUS = String.Empty
        If WrkRecovery Then
          If Not myMRHST.RecordNotFound Then
            myMRHST.UpdateOneRecordP()
            GoTo DoneHst
          End If
        End If
        myMRHST.AddOneRecordP()
        If myMRHST.ErrMsg <> "" Then
          WriteErrorLog(myMRHST.ErrMsg)
          Exit Sub
        End If
      End With

DoneHst:
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

    If MyTotalEntry Then
      myMRHST.GetOneRecordP(BatchNo, "")
      myMRHST._BCHNO = BatchNo
      With myMRBCH
        .GetOneRecordP(BatchNo)
        myMRHST._DESCR = ._DESCR
        myMRHST._RECDT = ._RECDT
        myMRHST._STRDT = ._STRDT
        myMRHST._ENDDT = ._ENDDT
        myMRHST._PRF = ._PRF
        myMRHST._CASH = ._TCASH
        myMRHST._CHECK = ._TCHECK
        myMRHST._CREDIT = ._TCREDIT
        myMRHST._TOTAL = 0
      End With
      myMRHST._CODE = ""
      myMRHST._CHDATE = MyUtils.SetDBDate(Date.Now.Date)
      myMRHST._CHTIME = MyUtils.SetDBTime(Date.Now)
      myMRHST._STATUS = String.Empty
      myMRHST.AddOneRecordP()
    End If

    myFrmProgress.Close()
    Application.DoEvents()
    myMRBCHD.DeleteBatch(BatchNo)
    myMRBCH.DeleteOneRecordP()

Cleanup:
    'Memory Cleanup
    myMRBCH = Nothing
    myMRBCHD = Nothing
    myMRHST = Nothing

  End Sub
End Module
