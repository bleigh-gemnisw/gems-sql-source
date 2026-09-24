Imports System.io
Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myBCHHDR As BCHHDR.myData
Dim myTCRBCH As TCRBCH.myData
Dim myTXINV As TXINV.MyData

Dim ds As DataSet = New DataSet
Dim dr As DataRow

Dim WrkType As String
Dim WrkYear As Integer
Dim WrkReceiptDate As Date
Dim WrkCheckNo As String
Dim WrkBatchNo As Integer
Dim WrkLease As String
Dim WrkPay As Integer
  Public Sub PrtReport()

    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myTCRBCH = New TCRBCH.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)

    With MyFrmTXA06B
      WrkType = .TxtType.Text
      WrkYear = MyUtils.CnvSng(.TxtGLYear.Text)
      WrkReceiptDate = .DtPckReceipt.Value
      WrkCheckNo = .TxtCheckNo.Text
      WrkLease = Trim(.TxtLease.Text)
      If .RbPay1st.Checked Then
        WrkPay = 1
      End If
      If .RbPay2nd.Checked Then
        WrkPay = 2
      End If
      If .RbPay3rd.Checked Then
        WrkPay = 3
      End If
      If .RbPay4th.Checked Then
        WrkPay = 4
      End If
      If .RbPayOrig.Checked Then
        WrkPay = 0
      End If
      If .RbPayBalance.Checked Then
        WrkPay = 5
      End If
    End With

    If ds.Tables.Count = 0 Then
      BuildDs(ds)
    Else
      ds.Clear()
    End If

    If MyFrmTXA06B.LblFilePath.Text = "" Then
      CreateBatch()
    Else
      GetDetail()
    End If

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .WrkBatchNo = WrkBatchNo
      .WrkReceiptDate = WrkReceiptDate
      .Show()
    End With

  End Sub
  Public Sub BuildDs(ByRef Ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Count", Type.GetType("System.Int32"))
      .Columns.Add("Pamt", Type.GetType("System.Decimal"))
      .Columns.Add("Iamt", Type.GetType("System.Decimal"))
      .Columns.Add("Lamt", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
  End With
  Ds.Tables.Add(myTable)
End Sub
  Private Sub GetDetail()
    Dim WrkStream As FileStream = New FileStream(MyFrmTXA06B.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim WrkTrnbr As Integer
    Dim WrkPaid As Decimal
    Dim WrkInt As Decimal
    Dim WrkLien As Decimal
    Dim TotCount As Integer
    Dim TotPaid As Decimal
    Dim TotInt As Decimal
    Dim TotLien As Decimal
    Const CBatchType As String = "PTC"

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    WrkBatchNo = myBCHHDR.AutoGenKey(CBatchType)
    myBCHHDR.GetOneRecordP(CBatchType, WrkBatchNo)

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo WriteBatch
      Exit Sub
    End If

    I = I + strBuffer.Length
    WrkTrnbr = myTCRBCH.AutoGenKey(WrkBatchNo)
    myTCRBCH.GetOneRecordP(WrkBatchNo, WrkTrnbr)
    With myTCRBCH
      ._BCHNO = WrkBatchNo
      ._TRNBR = WrkTrnbr
      ._RDTE = MyUtils.SetDBDate(WrkReceiptDate)
      ._LISTNo = MyUtils.CnvSng(Mid(strBuffer, 13, 7))
      ._YEAR = MyUtils.CnvSng("20" & Mid(strBuffer, 21, 2))
      ._TYPE = Mid(strBuffer, 29, 1)
      WrkPaid = MyUtils.CnvSng(Mid(strBuffer, 38, 10)) / 100
      myTXINV.GetOneRecordP(._LISTNo, ._YEAR, ._TYPE)
      If Not myTXINV.RecordNotFound Then
        ._NAME = Trim(myTXINV._NAME)
      Else
        ._NAME = String.Empty
      End If
      ._PAMT = WrkPaid
      ._IAMT = 0
      ._LAMT = 0
      ._BKCD = ""
      ._REF = WrkCheckNo
      ._COMM = "Leasing Company"
      ._PMETH = "2"
      ._SRC = 3
      myTCRBCH.AddOneRecordP()
    End With
    TotCount = TotCount + 1
    TotPaid = TotPaid + WrkPaid
    TotInt = TotInt + WrkInt
    TotLien = TotLien + WrkLien

NextRec:
    With myFrmProgress
      WrkPct = (I / WrkFileSize) * 100
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo NextLine

WriteBatch:
    With myBCHHDR
      ._APPID = CBatchType
      ._BCHNO = WrkBatchNo
      ._ORGUS = "NET-TXA06"
      ._STATS = "S"
      ._PSDT = MyUtils.SetDBDate(WrkReceiptDate)
      .AddOneRecordP()
    End With

    myBCHHDR.GetOneRecordP(CBatchType, 0)
    If Not myBCHHDR.RecordNotFound Then
      With myBCHHDR
        ._LSBCH = WrkBatchNo
        .UpdateOneRecordP()
      End With
    End If

    dr = ds.Tables(0).NewRow
    dr.Item("count") = TotCount
    dr.Item("pamt") = TotPaid
    dr.Item("iamt") = TotInt
    dr.Item("lamt") = TotLien
    dr.Item("total") = TotPaid + TotInt + TotLien
    ds.Tables(0).Rows.Add(dr)

    sr.Close()
    myFrmProgress.Close()
    myTCRBCH.CloseFile()

  End Sub
  Private Sub CreateBatch()
    Dim myTXINVQ As TXINVQ.MyData
    Dim DsTXINV As DataSet = New DataSet
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAnd As String
    Dim I As Integer
    Dim WrkTrnbr As Integer
    Dim WrkPaid As Decimal
    Dim TotCount As Integer
    Dim TotPaid As Decimal
    Dim TotInt As Decimal
    Dim TotLien As Decimal
    Const CBatchType As String = "PTC"

    If MyServer = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    myTXINVQ = New TXINVQ.MyData(myDBConnect)

    WrkBatchNo = myBCHHDR.AutoGenKey(CBatchType)
    myBCHHDR.GetOneRecordP(CBatchType, WrkBatchNo)

    WrkQry = "icode<>'I'" & WrkAnd & "ILEASE = " & MyUtils.Quo(WrkLease) & WrkAnd & " year = " & WrkYear
    If WrkType <> "" Then
      WrkQry = WrkQry & WrkAnd & "type = " & MyUtils.Quo(WrkType)
    End If
    WrkSort = ""
    DsTXINV = myTXINVQ.GetQry(WrkSort, WrkQry, 0)
    If DsTXINV.Tables(0).Rows.Count = 0 Then Exit Sub
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsTXINV.Tables(0).Rows.Count - 1)

      With myTCRBCH
        WrkTrnbr = myTCRBCH.AutoGenKey(WrkBatchNo)
        WrkPaid = 0
        'Original Bill always uses taxt
        If DsTXINV.Tables(0).Rows(I).Item("ccno") = 0 Then
          Select Case WrkPay
            Case 0
              WrkPaid = DsTXINV.Tables(0).Rows(I).Item("taxt")
            Case 1
              WrkPaid = DsTXINV.Tables(0).Rows(I).Item("tax1")
            Case 2
              WrkPaid = DsTXINV.Tables(0).Rows(I).Item("tax2")
            Case 3
              WrkPaid = DsTXINV.Tables(0).Rows(I).Item("tx3rd")
            Case 4
              WrkPaid = DsTXINV.Tables(0).Rows(I).Item("tx4th")
            Case 5
              WrkPaid = DsTXINV.Tables(0).Rows(I).Item("bald")
          End Select
        Else
          Select Case WrkPay
            Case 0
              WrkPaid = DsTXINV.Tables(0).Rows(I).Item("taxt")
            Case 1
              WrkPaid = DsTXINV.Tables(0).Rows(I).Item("cctx1")
            Case 2
              WrkPaid = DsTXINV.Tables(0).Rows(I).Item("cctx2")
            Case 3
              WrkPaid = DsTXINV.Tables(0).Rows(I).Item("cctx3")
            Case 4
              WrkPaid = DsTXINV.Tables(0).Rows(I).Item("cctx4")
            Case 5
              WrkPaid = DsTXINV.Tables(0).Rows(I).Item("bald")
          End Select
        End If
        If DsTXINV.Tables(0).Rows(I).Item("bald") = 0 Then GoTo NextRec
        .GetOneRecordP(WrkBatchNo, WrkTrnbr)
        ._BCHNO = WrkBatchNo
        ._TRNBR = WrkTrnbr
        ._RDTE = MyUtils.SetDBDate(WrkReceiptDate)
        ._LISTNo = DsTXINV.Tables(0).Rows(I).Item("list#")
        ._YEAR = DsTXINV.Tables(0).Rows(I).Item("year")
        ._TYPE = DsTXINV.Tables(0).Rows(I).Item("type")
        ._NAME = DsTXINV.Tables(0).Rows(I).Item("name")
        ._PAMT = WrkPaid
        ._IAMT = 0
        ._LAMT = 0
        ._REF = WrkCheckNo
        ._BKCD = ""
        ._COMM = "Leasing Company"
        ._PMETH = "2"
        ._SRC = 3
        .AddOneRecordP()
        If .ErrMsg <> "" Then
          WriteErrorLog(.ErrMsg)
          Exit Sub
        End If
      End With
      TotCount = TotCount + 1
      TotPaid = TotPaid + WrkPaid
      TotInt = TotInt + 0
      TotLien = TotLien + 0
      If TotCount = 1 Then
        With myBCHHDR
          ._APPID = CBatchType
          ._BCHNO = WrkBatchNo
          ._ORGUS = "NET-TXA06"
          ._STATS = "S"
          ._SUBST = "E"
          ._PSDT = MyUtils.SetDBDate(WrkReceiptDate)
          .AddOneRecordP()
        End With
      End If

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsTXINV.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

WriteBatch:
    myBCHHDR.GetOneRecordP(CBatchType, 0)
    If Not myBCHHDR.RecordNotFound Then
      With myBCHHDR
        ._LSBCH = WrkBatchNo
        .UpdateOneRecordP()
      End With
    End If

    dr = ds.Tables(0).NewRow
    dr.Item("count") = TotCount
    dr.Item("pamt") = TotPaid
    dr.Item("iamt") = TotInt
    dr.Item("lamt") = TotLien
    dr.Item("total") = TotPaid + TotInt + TotLien
    ds.Tables(0).Rows.Add(dr)

    myFrmProgress.Close()
    myTCRBCH.CloseFile()

  End Sub
End Module






