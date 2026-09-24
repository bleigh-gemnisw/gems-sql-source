Module PostBCHHDR

	Dim myFrmProgress As FrmProgress
	Dim myBCHHDR As BCHHDR.myData
	Dim myTSPBCH As TSPBCH.MyData
  Dim myTSPBCHL1 As TSPBCHL1.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXHST As TXHST.MyData
  Dim myTXHSTL3 As TXHSTL3.myData

  Dim ds As DataSet = New DataSet
	Dim dsTSPBCH As DataSet = New DataSet
	Dim dsTXHSTL3 As DataSet = New DataSet

  Dim BchStatus As String
  Dim BchListNo As Integer
  Dim BchYear As Integer
  Dim BchType As String
  Dim BchDist As Integer
  Dim BchSuspCd As String
  Dim BchComm As String
  Dim BchName As String
  Dim BchAmount As Decimal
  Public Sub PstBCHHDR(ByVal BatchNo As Integer)

    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    Dim I As Integer
    Dim J As Integer
    Dim WrkRecID As Integer
    Dim WrkRecovery As Boolean
    Dim WrkRecoveryNormal As Boolean
    Dim WrkRecoveryList As Integer
    Dim WrkRecoveryYear As Integer
    Dim WrkRecoveryType As String
    Dim WrkPostDBDate As Integer
    Dim WrkPosted As Boolean
    Dim WrkPct As Integer
    Dim SavePct As Integer

    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myTSPBCH = New TSPBCH.mydata(MyDBConnect)
    myTSPBCHL1 = New TSPBCHL1.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXHST = New TXHST.MyData(myDBConnect)
    myTXHSTL3 = New TXHSTL3.mydata(MyDBConnect)
    myBCHHDR.GetOneRecordP(MyBatch, BatchNo)
    WrkRecovery = False
    WrkRecoveryNormal = False
    WrkRecoveryType = ""

    If myBCHHDR.RecordNotFound Then Exit Sub

    With myBCHHDR
      WrkPostDBDate = ._PSDT
      If ._STATS = "P" Then
        MsgBox("This process will automatically determine what needs to be done to finish the batch posting", MsgBoxStyle.Exclamation, "Batch has partially posted. Batch recovery will start.")
        WrkRecovery = True
      Else
        ._STATS = "P"
      End If
    End With
    myBCHHDR.UpdateOneRecordP()

    myFrmProgress = New FrmProgress
    myFrmProgress.Text = "Posting..."
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    myTSPBCH.OpenFile()
    dsTSPBCH = myTSPBCHL1.GetViewbyBatch(BatchNo, 9999)
    For I = 0 To (dsTSPBCH.Tables(0).Rows.Count - 1)
      With dsTSPBCH.Tables(0).Rows(I)
        BchListNo = .Item("list#")
        BchYear = .Item("year")
        BchType = .Item("type")
        BchDist = .Item("dist")
        BchSuspCd = .Item("scd")
        BchComm = .Item("comm")
        BchName = .Item("name")
      End With

      WrkPosted = False
      If WrkRecovery And Not WrkRecoveryNormal Then
        dsTXHSTL3 = myTXHSTL3.GetViewbyList(BchYear, BchListNo, BchType, WrkPostDBDate, 50)
        For J = 0 To dsTXHSTL3.Tables(0).Rows.Count - 1
          With dsTXHSTL3.Tables(0).Rows(0)
            If .Item("batchn") = BatchNo Then
              WrkPosted = True
              WrkRecoveryList = .Item("list#")
              WrkRecoveryYear = .Item("year")
              WrkRecoveryType = .Item("type")
              Exit For
            End If
          End With
        Next
        'If not posted then rest of batch can be posted normally 
        If Not WrkPosted Then WrkRecoveryNormal = True
      End If

      If WrkPosted Then GoTo SkipHst
      BchAmount = 0
      myTXINV.GetOneRecordP(BchListNo, BchYear, BchType)
      With myTXINV
        If ._SUSDT = 0 And ._BALD > 0 Then
          BchAmount = ._BALD
          ._ICODE = "S"
          ._SUSCD = BchSuspCd
          ._SUSDT = WrkPostDBDate
        End If
      End With

      If IsNothing(ErrorMsg(0)) Then
        myTXINV.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If

SkipInv:
      If BchAmount > 0 Then
        With myTXHST
          WrkRecID = .AutoGenKey()
          .GetOneRecordP(WrkRecID)
          ._RECID = WrkRecID
          ._RCODE = "I"
          ._LISTNO = BchListNo
          ._YEAR = BchYear
          ._TYPE = BchType
          ._PAMT = 0
          ._IAMT = 0
          ._LAMT = 0
          ._PCAMT = BchAmount
          ._CASH = 0
          ._CHECK = 0
          ._CREDIT = 0
          ._DIST = BchDist
          ._COMM = "SUSPENDED"  'BchComm
          ._CORC = ""
          ._BATCHN = BatchNo
          ._BATCHA = "S"
          ._PDATE = WrkPostDBDate
          ._CDATE = WrkPostDBDate
          ._THINPD = ""
          ._PRF = Mid(MyUserID, 1, 10)
          ._CHDATE = MyUtils.SetDBDate(Date.Now.Date)
          ._CHTIME = MyUtils.SetDBTime(Date.Now)
          myTXHST.AddOneRecordP()
        End With
      End If
SkipHst:
        With myFrmProgress
        WrkPct = ((I + 1) / dsTSPBCH.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    myTSPBCH.DeleteBatch(BatchNo)
    myBCHHDR.DeleteOneRecordP()
    myFrmProgress.Close()
    'Memory Cleanup
    myBCHHDR = Nothing
    myTSPBCH = Nothing
    myTXINV = Nothing
    myTXHST = Nothing
    If WrkRecovery Then
      MsgBox("Verify " & WrkRecoveryList & "-" & WrkRecoveryType & "-" & WrkRecoveryYear &
      " and the next record.", MsgBoxStyle.Information, "Batch recovery has finished. Proceed with manual review as instructed below.")
    End If

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  End Sub
End Module






