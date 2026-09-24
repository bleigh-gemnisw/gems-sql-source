Imports System.IO
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myBCHHDR As BCHHDR.MyData
  Dim myTCRBCH As TCRBCH.MyData
  Dim myTXINV As TXINV.MyData
  Dim MyCASHINT As CASHINT.MyData

  Dim DsTXINV As DataSet = New DataSet
  Dim ds As DataSet = New DataSet
  Dim dr As DataRow

  Dim WrkListNo As Integer
  Dim WrkType As String
  Dim WrkYear As Integer
  Dim WrkReceiptDate As Date
  Dim WrkInterestDate As Date
  Dim WrkCheckNo As String
  Dim WrkBatchNo As Integer
  Dim WrkLease As String
  Dim WrkPay As Integer
  Dim WrkPaid As Decimal
  Dim WrkTax As Decimal
  Dim WrkInterest As Decimal
  Dim WrkFeeDue As Decimal
  Dim WrkFee(7) As Decimal
  Dim WrkFeecd(7) As String
  Dim WrkCAFee As Decimal
  Dim WrkCAProrated As Decimal
  Dim WrkOtherFee As Decimal
  Dim WrkBond As Decimal
  Dim WrkLien As Decimal
  Dim WrkDue As Decimal

  Public Sub PrtReport()

    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myTCRBCH = New TCRBCH.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    MyCASHINT = New CASHINT.MyData(myDBConnect)

    With MyFrmTXA06B
      WrkType = .TxtType.Text
      WrkYear = MyUtils.CnvSng(.TxtGLYear.Text)
      WrkInterestDate = .DtPckInterest.Value
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
      DsTXINV.Clear()
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
      .WrkInterestDate = WrkInterestDate
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
      .Columns.Add("PCamt", Type.GetType("System.Decimal"))
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
    Dim TotCount As Integer
    Dim TotPaid As Decimal
    Dim TotInt As Decimal
    Dim TotFee As Decimal
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
      WrkListNo = MyUtils.CnvSng(Mid(strBuffer, 13, 7))
      ._LISTNo = WrkListNo
      ._YEAR = MyUtils.CnvSng("20" & Mid(strBuffer, 21, 2))
      ._TYPE = Mid(strBuffer, 29, 1)
      WrkPaid = MyUtils.CnvSng(Mid(strBuffer, 38, 10)) / 100
      myTXINV.GetOneRecordP(._LISTNo, ._YEAR, ._TYPE)
      If Not myTXINV.RecordNotFound Then
        ._NAME = Trim(myTXINV._NAME)
      Else
        ._NAME = String.Empty
      End If
      SplitPayment(I)
      ._PAMT = WrkPaid
      ._IAMT = WrkInterest
      ._LAMT = WrkLien
      ._PCAMT = WrkFee(0) + WrkFee(1) + WrkFee(2) + WrkFee(3) + WrkFee(4) + WrkFee(5) + WrkFee(6)
      ._PCAMT1 = WrkFee(0)
      ._PCAMT2 = WrkFee(1)
      ._PCAMT3 = WrkFee(2)
      ._PCAMT4 = WrkFee(3)
      ._PCAMT5 = WrkFee(4)
      ._PCAMT6 = WrkFee(5)
      ._PCAMT7 = WrkFee(6)
      ._PENCD1 = WrkFeecd(0)
      ._PENCD2 = WrkFeecd(1)
      ._PENCD3 = WrkFeecd(2)
      ._PENCD4 = WrkFeecd(3)
      ._PENCD5 = WrkFeecd(4)
      ._PENCD6 = WrkFeecd(5)
      ._PENCD7 = WrkFeecd(6)
      ._BKCD = ""
      ._REF = WrkCheckNo
      ._COMM = "Leasing Company"
      ._PMETH = "2"
      ._SRC = 3
      myTCRBCH.AddOneRecordP()
    End With
    TotCount = TotCount + 1
    TotPaid = TotPaid + WrkPaid
    TotFee = TotFee + myTCRBCH._PCAMT
    TotInt = TotInt + WrkInterest
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
      ._STRDT = MyUtils.SetDBDate(WrkInterestDate)
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
    dr.Item("pcamt") = TotFee
    dr.Item("lamt") = TotLien
    dr.Item("total") = TotPaid + TotInt + TotFee + TotLien
    ds.Tables(0).Rows.Add(dr)

    sr.Close()
    myFrmProgress.Close()
    myTCRBCH.CloseFile()

  End Sub
  Private Sub CreateBatch()
    Dim myTXINVQ As TXINVQ.MyData
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAnd As String
    Dim I As Integer
    Dim WrkTrnbr As Integer
    Dim TotCount As Integer
    Dim TotPaid As Decimal
    Dim TotInt As Decimal
    Dim TotFee As Decimal
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
        WrkListNo = DsTXINV.Tables(0).Rows(I).Item("list#")
        ._LISTNo = WrkListNo
        ._YEAR = DsTXINV.Tables(0).Rows(I).Item("year")
        ._TYPE = DsTXINV.Tables(0).Rows(I).Item("type")
        ._NAME = DsTXINV.Tables(0).Rows(I).Item("name")
        SplitPayment(I)
        ._PAMT = WrkPaid
        ._IAMT = WrkInterest
        ._LAMT = WrkLien
        ._PCAMT = WrkFee(0) + WrkFee(1) + WrkFee(2) + WrkFee(3) + WrkFee(4) + WrkFee(5) + WrkFee(6)
        ._PCAMT1 = WrkFee(0)
        ._PCAMT2 = WrkFee(1)
        ._PCAMT3 = WrkFee(2)
        ._PCAMT4 = WrkFee(3)
        ._PCAMT5 = WrkFee(4)
        ._PCAMT6 = WrkFee(5)
        ._PCAMT7 = WrkFee(6)
        ._PENCD1 = WrkFeecd(0)
        ._PENCD2 = WrkFeecd(1)
        ._PENCD3 = WrkFeecd(2)
        ._PENCD4 = WrkFeecd(3)
        ._PENCD5 = WrkFeecd(4)
        ._PENCD6 = WrkFeecd(5)
        ._PENCD7 = WrkFeecd(6)
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
      TotFee = TotFee + myTCRBCH._PCAMT
      TotInt = TotInt + WrkInterest
      TotLien = TotLien + WrkLien
      If TotCount = 1 Then
        With myBCHHDR
          ._APPID = CBatchType
          ._BCHNO = WrkBatchNo
          ._ORGUS = "NET-TXA06"
          ._STATS = "S"
          ._SUBST = "G"
          ._PSDT = MyUtils.SetDBDate(WrkReceiptDate)
          ._STRDT = MyUtils.SetDBDate(WrkInterestDate)
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
    dr.Item("pcamt") = TotFee
    dr.Item("lamt") = TotLien
    dr.Item("total") = TotPaid + TotInt + TotFee + TotLien
    ds.Tables(0).Rows.Add(dr)

    myFrmProgress.Close()
    myTCRBCH.CloseFile()

  End Sub
  Private Sub SplitPayment(ByVal I As Integer)
    'CalcInterest(WrkListNo, WrkType, WrkYear, MyUtils.SetDBDate(WrkReceiptDate), WrkInterest, 0, WrkFeeDue,
    '  WrkCAFee, WrkLien, WrkBond, WrkTax, WrkDue)
    CalcInterest(WrkListNo, WrkType, WrkYear, MyUtils.SetDBDate(WrkInterestDate), WrkInterest, 0, WrkFeeDue,
      WrkCAFee, WrkLien, WrkBond, WrkTax, WrkDue)
    WrkFee(6) = 0
    WrkFeecd(6) = ""
    If WrkCAFee > 0 Then
      'Partial Payment
      If WrkPaid < WrkDue Then
        WrkOtherFee = WrkFeeDue - WrkCAFee
        WrkCAProrated = MyUtils.Round(WrkPaid * 0.15, 2)
        WrkFee(6) = WrkCAProrated
        WrkFeecd(6) = "CA"
        WrkFeeDue = WrkOtherFee + WrkCAProrated
      Else
        WrkFee(6) = WrkCAFee
        WrkFeecd(6) = "CA"
      End If
    End If
    If WrkFeeDue >= WrkPaid Then
      WrkFeeDue = WrkPaid
      WrkPaid = 0
    Else
      WrkPaid = WrkPaid - WrkFeeDue
    End If
    If WrkInterest >= WrkPaid Then
      WrkInterest = WrkPaid
      WrkPaid = 0
    Else
      WrkPaid = WrkPaid - WrkInterest
    End If
    If WrkBond >= WrkPaid Then
      WrkBond = WrkPaid
      WrkPaid = 0
    Else
      WrkPaid = WrkPaid - WrkBond
    End If
    If WrkPaid >= (WrkTax + WrkLien) And WrkLien > 0 Then
      WrkPaid = WrkPaid - WrkLien
    Else
      WrkLien = 0
    End If
    'Determine What Fees to pay
    With myTXINV
      WrkFee(0) = DsTXINV.Tables(0).Rows(I).Item("fed1")
      WrkFee(1) = DsTXINV.Tables(0).Rows(I).Item("fed2")
      WrkFee(2) = DsTXINV.Tables(0).Rows(I).Item("fed3")
      WrkFee(3) = DsTXINV.Tables(0).Rows(I).Item("fed4")
      WrkFee(4) = DsTXINV.Tables(0).Rows(I).Item("fed5")
      WrkFeecd(0) = DsTXINV.Tables(0).Rows(I).Item("fec1")
      WrkFeecd(1) = DsTXINV.Tables(0).Rows(I).Item("fec2")
      WrkFeecd(2) = DsTXINV.Tables(0).Rows(I).Item("fec3")
      WrkFeecd(3) = DsTXINV.Tables(0).Rows(I).Item("fec4")
      WrkFeecd(4) = DsTXINV.Tables(0).Rows(I).Item("fec5")
      WrkFee(5) = 0
      WrkFeecd(5) = ""
      If DsTXINV.Tables(0).Rows(I).Item("mvflag") = "Y" And WrkFeeDue > 0 Or DsTXINV.Tables(0).Rows(I).Item("mvflag") = "M" And WrkFeeDue > 0 Then
        WrkFee(5) = MyMVFee
        WrkFeecd(5) = "MV"
        WrkFeeDue = WrkFeeDue - WrkFee(5)
      End If
      If WrkBond > 0 Then
        WrkFee(5) = WrkBond
        WrkFeecd(5) = "BI"
      End If
    End With
    For I = 0 To 4
      If WrkFee(I) > 0 And WrkFeeDue > 0 Then
        If WrkFeeDue < WrkFee(I) Then
          WrkFee(I) = WrkFeeDue
        End If
        WrkFeeDue = WrkFeeDue - WrkFee(I)
      Else
        WrkFee(I) = 0
        WrkFeecd(I) = ""
      End If
    Next
  End Sub
  Public Sub CalcInterest(ByVal InListNo As Integer, ByVal InType As String,
  ByVal InYear As Integer, ByVal InDate As Integer, ByRef OutInterest As Decimal, ByRef OutInterestPaid As Decimal,
  ByRef OutFee As Decimal, ByRef OutCAFee As Decimal, ByRef OutLien As Decimal, ByRef OutBond As Decimal,
  ByRef OutTax As Decimal, ByRef OutDue As Decimal)
    With MyCASHINT
      .In_IntDate = MyUtils.GetDBDate(InDate)
      .In_ListNo = InListNo
      .In_Type = InType
      .In_Year = InYear
      .CalcInterest()
      OutInterest = Format(.Out_Int(), "standard")
      OutInterestPaid = Format(.Out_IntPaid(), "standard")
      OutLien = Format(.Out_Lien(), "standard")
      OutFee = Format(.Out_Fee(), "standard")
      OutCAFee = Format(.Out_CAFee(), "standard")
      OutBond = Format(.Out_Bond(), "standard")
      OutTax = Format(.Out_Prin(), "standard")
      OutDue = Format(.Out_Tot(), "standard")
    End With
  End Sub
End Module