Imports System.io
Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myBCHHDR As BCHHDR.myData
Dim myTCRBCH As TCRBCH.myData
Dim myTXINV As TXINV.MyData
Dim MyCASHINT As CASHINT.MyData

Dim ds As DataSet = New DataSet
Dim dr As DataRow

Dim WrkSelType As String
Dim WrkSelYear As Integer
  Dim WrkReceiptDate As Date
  Dim WrkInterestDate As Date
  Dim WrkCheckNo As String
Dim WrkBatchNo As Integer
Dim WrkBankcd As String
Dim WrkPay As Integer
  Public Sub PrtReport()

    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myTCRBCH = New TCRBCH.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    MyCASHINT = New CASHINT.MyData(myDBConnect)

    With MyFrmTXA03B
      WrkSelType = .TxtType.Text
      WrkSelYear = MyUtils.CnvSng(.TxtGLYear.Text)
      WrkInterestDate = .DtPckInterest.Value
      WrkReceiptDate = .DtPckReceipt.Value
      WrkCheckNo = .TxtCheckNo.Text
      WrkBankcd = .TxtBankCd.Text
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
      If .RbPayWhole.Checked Then
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

    If MyFrmTXA03B.LblFilePath.Text = "" Then
      CreateBatch()
    Else
      GetDetail()
    End If

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .WrkBatchNo = WrkBatchNo
      .WrkInterestDate = WrkInterestDate
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
      .Columns.Add("Pcamt", Type.GetType("System.Decimal"))
      .Columns.Add("Lamt", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
  End With
  Ds.Tables.Add(myTable)
End Sub
  Private Sub GetDetail()
    Dim WrkStream As FileStream = New FileStream(MyFrmTXA03B.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim WrkTrnbr As Integer
    Dim WrkListNo As Integer
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkTax As Decimal
    Dim WrkPaid As Decimal
    Dim WrkInterest As Decimal
    Dim WrkInterestPaid As Decimal
    Dim WrkFeeDue As Decimal
    Dim WrkFee(7) As Decimal
    Dim WrkFeecd(7) As String
    Dim WrkCAFee As Decimal
    Dim WrkCAProrated As Decimal
    Dim WrkOtherFee As Decimal
    Dim WrkBond As Decimal
    Dim WrkLien As Decimal
    Dim WrkDue As Decimal
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
    With myTCRBCH
      WrkListNo = MyUtils.CnvSng(Mid(strBuffer, 13, 7))
      WrkYear = MyUtils.CnvSng("20" & Mid(strBuffer, 21, 2))
      WrkType = Mid(strBuffer, 29, 1)
      WrkPaid = MyUtils.CnvSng(Mid(strBuffer, 38, 10)) / 100
      WrkTrnbr = myTCRBCH.AutoGenKey(WrkBatchNo)
      .GetOneRecordP(WrkBatchNo, WrkTrnbr)
      ._BCHNO = WrkBatchNo
      ._TRNBR = WrkTrnbr
      ._RDTE = MyUtils.SetDBDate(WrkReceiptDate)
      ._LISTNo = WrkListNo
      ._YEAR = WrkYear
      ._TYPE = WrkType
      myTXINV.GetOneRecordP(._LISTNo, ._YEAR, ._TYPE)
      If Not myTXINV.RecordNotFound Then
        ._NAME = Trim(myTXINV._NAME)
      Else
        ._NAME = String.Empty
      End If
      ' old  changed setdbdate to use itnereset date
      'CalcInterest(WrkListNo, WrkType, WrkYear, MyUtils.SetDBDate(WrkReceiptDate), WrkInterest, WrkInterestPaid, WrkFeeDue,
      'WrkCAFee, WrkLien, WrkBond, WrkTax, WrkDue)
      CalcInterest(WrkListNo, WrkType, WrkYear, MyUtils.SetDBDate(WrkInterestDate), WrkInterest, WrkInterestPaid, WrkFeeDue,
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
      ._PAMT = WrkPaid
      ._IAMT = WrkInterest
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
      ._LAMT = WrkLien
      ._BKCD = WrkBankcd
      ._REF = WrkCheckNo
      ._COMM = GetTXBanksDesc(WrkBankcd)
      ._PMETH = "2"
      ._SRC = 3
      myTCRBCH.AddOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        Exit Sub
      End If
    End With
    TotCount = TotCount + 1
    TotPaid = TotPaid + WrkPaid
    TotInt = TotInt + WrkInterest
    TotFee = TotFee + myTCRBCH._PCAMT
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
      ._ORGUS = "NET-TXA03"
      ._STATS = "S"
      ._STRDT = MyUtils.SetDBDate(WrkInterestDate)
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
    dr.Item("pcamt") = TotFee
    dr.Item("total") = TotPaid + TotInt + TotLien + TotFee
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
    Dim Counter As Integer
    Dim WrkTrnbr As Integer
    Dim WrkListNo As Integer
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkInterestPaid As Decimal
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
    Dim WrkPaid As Decimal
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

    Counter = 0
    WrkQry = "icode<>'I'" & WrkAnd & "BKCD = " & MyUtils.Quo(WrkBankcd) & WrkAnd & " year = " & WrkSelYear
    If WrkSelType <> "" Then
      WrkQry = WrkQry & WrkAnd & "type = " & MyUtils.Quo(WrkSelType)
    End If
    WrkSort = ""

    myTXINVQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXINVQ.ReadQry()
    If Not myTXINVQ.IsEOF Then
      Counter = Counter + 1
      With myTCRBCH
        WrkPaid = 0
        If myTXINVQ._CCNO = 0 Then
          Select Case WrkPay
            Case 0
              WrkPaid = myTXINVQ._TAXT
            Case 1
              WrkPaid = myTXINVQ._TAX1
            Case 2
              WrkPaid = myTXINVQ._TAX2
            Case 3
              WrkPaid = myTXINVQ._TX3RD
            Case 4
              WrkPaid = myTXINVQ._TX4TH
            Case 5
              WrkPaid = myTXINVQ._BALD
          End Select
        Else
          Select Case WrkPay
            Case 0
              WrkPaid = myTXINVQ._CCETAX
            Case 1
              WrkPaid = myTXINVQ._CCTX1
            Case 2
              WrkPaid = myTXINVQ._CCTX2
            Case 3
              WrkPaid = myTXINVQ._CCTX3
            Case 4
              WrkPaid = myTXINVQ._CCTX4
            Case 5
              WrkPaid = myTXINVQ._BALD
          End Select
        End If
        If myTXINVQ._BALD = 0 Then GoTo NextRec

        WrkListNo = myTXINVQ._LISTNo
        WrkYear = myTXINVQ._YEAR
        WrkType = myTXINVQ._TYPE
        CalcInterest(WrkListNo, WrkType, WrkYear, MyUtils.SetDBDate(WrkInterestDate), WrkInterest, WrkInterestPaid, WrkFeeDue,
      WrkCAFee, WrkLien, WrkBond, WrkTax, WrkDue)
        WrkPaid = WrkPaid + WrkInterest + WrkFeeDue + WrkLien
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
        WrkTrnbr = myTCRBCH.AutoGenKey(WrkBatchNo)
        .GetOneRecordP(WrkBatchNo, WrkTrnbr)
        ._ADJ = ""
        ._BCHNO = WrkBatchNo
        ._BKBC = 0
        ._BKCD = WrkBankcd
        ._BKNA = ""
        ._BKSR = ""
        ._CHAMT = 0
        ._COMM = Mid(GetTXBanksDesc(WrkBankcd), 1, 20)
        ._DIST = 0
        ._IAMT = WrkInterest
        ._IDTE = 0
        ._LAMT = WrkLien
        ._LISTNo = WrkListNo
        ._NAME = myTXINVQ._NAME
        ._PAMT = WrkPaid
        ._PCAMT = WrkFee(0) + WrkFee(1) + WrkFee(2) + WrkFee(3) + WrkFee(4) + WrkFee(5) + WrkFee(6)
        ._PCAMT1 = WrkFee(0)
        ._PCAMT2 = WrkFee(1)
        ._PCAMT3 = WrkFee(2)
        ._PCAMT4 = WrkFee(3)
        ._PCAMT5 = WrkFee(4)
        ._PCAMT6 = WrkFee(5)
        ._PCAMT7 = WrkFee(6)
        ._PENCD1 = WrkFeecd(0) & ""
        ._PENCD2 = WrkFeecd(1) & ""
        ._PENCD3 = WrkFeecd(2) & ""
        ._PENCD4 = WrkFeecd(3) & ""
        ._PENCD5 = WrkFeecd(4) & ""
        ._PENCD6 = WrkFeecd(5) & ""
        ._PENCD7 = WrkFeecd(6) & ""
        ._PMETH = "2"
        ._RDTE = MyUtils.SetDBDate(WrkReceiptDate)
        ._REF = WrkCheckNo
        ._REFN = ""
        ._SRC = 3
        ._TRNBR = WrkTrnbr
        ._TYPE = WrkType
        ._YEAR = WrkYear
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

WriteBatch:
    With myBCHHDR
      ._APPID = CBatchType
      ._BCHNO = WrkBatchNo
      ._ORGUS = "NET-TXA03"
      ._STATS = "S"
      ._SUBST = "E"
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
    dr.Item("lamt") = TotLien
    dr.Item("pcamt") = TotFee
    dr.Item("total") = TotPaid + TotInt + TotLien + TotFee
    ds.Tables(0).Rows.Add(dr)

    myFrmProgress.Close()
    myTCRBCH.CloseFile()

  End Sub
  Public Sub CalcInterest(ByVal InListNo As Integer, ByVal InType As String, _
  ByVal InYear As Integer, ByVal InDate As Integer, ByRef OutInterest As Decimal, ByRef OutInterestPaid As Decimal, _
  ByRef OutFee As Decimal, ByRef OutCAFee As Decimal, ByRef OutLien As Decimal, ByRef OutBond As Decimal, _
  ByRef OutTax As Decimal, ByRef OutDue As Decimal)
  With MyCASHINT
   If InDate > 0 Then
     .In_IntDate = MyUtils.GetDBDate(InDate)
   Else
     .In_IntDate = WrkReceiptDate
   End If
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






