Module PostBatch

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXHSTQ As TXHSTQ.MyData
  Dim myTXHST As TXHST.MyData
  Dim myTXINV As TXINV.MyData

  'General
  Dim WrkBatch As Integer
  Dim WrkBatchType As String
  Dim WrkBatchDate As Integer
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PstBatch()

    myTXHSTQ = New TXHSTQ.MyData(myDBConnect)
    myTXHST = New TXHST.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)

    With MyFrmTXA30B
      WrkBatch = MyUtils.CnvSng(.TxtBatch.Text)
      WrkBatchDate = MyUtils.SetDBDate(.DtPckBatch.Value)
      Select Case .CboBatch.SelectedItem.ToString
        Case "Bank Service"
          WrkBatchType = "K"
        Case "Escrow"
          WrkBatchType = "E"
        Case "Leasing"
          WrkBatchType = "G"
        Case "Lock Box"
          WrkBatchType = "B"
        Case "Misc/Penny Batch"
          WrkBatchType = "M"
        Case "PC"
          WrkBatchType = "P"
        Case "Web Payment"
          WrkBatchType = "W"
      End Select
    End With

    GetDetail()
  End Sub
  Private Sub GetDetail()
    Dim ds As DataSet = New DataSet
    Dim dr As Data.DataRow
    Dim WrkQry As String
    Dim WrkSort As String
    Dim I As Integer
    Dim Counter As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If
    If MyServer = "SQL" Then
      MyBlocking = False
    Else
      MyBlocking = True
    End If

    WrkQry = "BATCHN=" & WrkBatch & WrkAnd & "BATCHA=" & MyUtils.Quo(WrkBatchType) & WrkAnd & "PDATE=" & WrkBatchDate
    WrkSort = ""
    ds = myTXHSTQ.GetQry(WrkSort, WrkQry, 0)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To ds.Tables(0).Rows.Count - 1
      dr = ds.Tables(0).Rows(I)
      Counter = Counter + 1
      If Not myTXHSTQ.IsEOF Then
        With myTXHSTQ
          .GetFieldsDr(dr)
          Counter = Counter + 1
          UpdateTXINV(._LISTNo, ._TYPE, ._YEAR, ._PAMT, ._IAMT, ._PCAMT, ._PENCD)
          UpdateTXHST(._LISTNo, ._TYPE, ._YEAR, ._PDATE, ._BATCHN)
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
      End If
    Next

    myFrmProgress.Close()
    myTXHSTQ.CloseFile()
    ds.Clear()
  End Sub
  Private Sub UpdateTXINV(ByVal ListNo As Integer, ByVal Type As String, ByVal Year As Integer, ByVal Amount As Decimal,
  ByVal Interest As Decimal, ByVal Bond As Decimal, ByVal PenCd As String)

    With myTXINV
      .GetOneRecordP(ListNo, Year, Type)
      If MyFrmTXA30B.RbVoid.Checked Then
        ._PAYREC = ._PAYREC - Amount
        ._BALD = ._BALD + Amount
        ._INTPD = ._INTPD - Interest
        If ._BOND > 0 And PenCd = "BI" Then
          ._BONDP = ._BONDP - Bond
        End If
      Else
        ._TXIDT = MyUtils.SetDBDate(MyFrmTXA30B.DTPckNew.Value)
      End If
      .UpdateOneRecordP()

    End With

  End Sub
  Private Sub UpdateTXHST(ByVal ListNo As Integer, ByVal Type As String, ByVal Year As Integer,
  ByVal pDate As Integer, ByVal BatchN As Integer)
    Dim NewDate As Integer

    NewDate = MyUtils.SetDBDate(MyFrmTXA30B.DTPckNew.Value)
    If MyFrmTXA30B.RbVoid.Checked Then
      myTXHST.VoidListNoBatch(ListNo, Year, Type, pDate, BatchN)
    Else
      myTXHST.ChangeListNoBatchDate(ListNo, Year, Type, pDate, BatchN, NewDate)
    End If
  End Sub

End Module






