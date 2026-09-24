Imports System.io
Imports System.Text
Imports System.Threading.Tasks
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myBCHHDR As BCHHDR.MyData
  Dim myTCRBCH As TCRBCH.MyData
  Dim myTCRBCHL1 As TCRBCHL1.MyData
  Dim myTXINV As TXINV.MyData
  Dim MyCASHINT As CASHINT.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As DataRow

  Dim WrkFormat As String
  Dim WrkReceiptDate As Date
  Dim WrkInterestDate As Date
  Dim WrkBatchNo As Integer
  Dim WrkCheck As Boolean
  Dim strBuffer As String
  Dim WrkListNo As Integer
  Dim WrkYear As Integer
  Dim WrkType As String
  Dim WrkPaid As Decimal
  Dim WrkDBDatePaid As Integer
  Dim WrkRef As String
  Dim WrkMsg As String
  Public Async Sub PrtReport()

    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myTCRBCH = New TCRBCH.MyData(myDBConnect)
    myTCRBCHL1 = New TCRBCHL1.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    MyCASHINT = New CASHINT.MyData(myDBConnect)

    With MyFrmTXA08B
      WrkInterestDate = .DtPckInterest.Value
      WrkReceiptDate = .DtPckReceipt.Value
      WrkCheck = .RbCheck.Checked
      WrkFormat = ""
      If .RbWebster.Checked Then
        WrkFormat = "WEBSTER"
      End If
    End With

    If ds.Tables.Count = 0 Then
      BuildDs(ds)
    Else
      ds.Clear()
    End If

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()

    Await Task.Run(Sub()
                     GetDetail()
                   End Sub)

    myFrmProgress.Close()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .WrkBatchNo = WrkBatchNo
      .WrkInterestDate = WrkInterestDate
      .WrkReceiptDate = WrkReceiptDate
      .WrkMsg = WrkMsg
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
      .Columns.Add("PCamt", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
    End With
    Ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkStream As FileStream = New FileStream(MyFrmTXA08B.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Long
    Dim I As Long
    Dim J As Integer
    Dim WrkTrnbr As Integer
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
    Dim WrkPrevTaxPaid As Decimal
    Dim WrkPrevIntPaid As Decimal
    Dim WrkPrevLienPaid As Decimal
    Dim WrkPrevFeePaid As Decimal
    Dim TotCount As Integer
    Dim TotPaid As Decimal
    Dim TotInt As Decimal
    Dim TotFee As Decimal
    Dim TotLien As Decimal
    Dim TotBond As Decimal
    Const CBatchType As String = "PTC"

    'myFrmProgress = New FrmProgress
    'myFrmProgress.Show()
    'myFrmProgress.Refresh()
    'Application.DoEvents()

    WrkMsg = ""
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
    '    myTCRBCH.GetOneRecordP(WrkBatchNo, WrkTrnbr)
    With myTCRBCH
      .ClearFields()
      Select Case WrkFormat
        Case ""
          ReadNormal()
        Case "WEBSTER"
          If myTOWN._TOWNBR = 4 Then
            ReadAvon()
          Else
            ReadWebster()
          End If
      End Select
      If WrkListNo = 0 Then GoTo NextRec
      ._LISTNo = WrkListNo
      ._TYPE = WrkType
      ._YEAR = WrkYear
      ._BCHNO = WrkBatchNo
      ._TRNBR = WrkTrnbr
      ._RDTE = MyUtils.SetDBDate(WrkReceiptDate)
      myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
      If Not myTXINV.RecordNotFound Then
        ._NAME = Trim(myTXINV._NAME)
        ._DIST = myTXINV._DIST
      Else
        ._NAME = String.Empty
      End If
      CalcInterest(WrkListNo, WrkType, WrkYear, MyUtils.SetDBDate(WrkInterestDate), WrkInterest, WrkInterestPaid, WrkFeeDue,
      WrkCAFee, WrkLien, WrkBond, WrkTax, WrkDue)
      WrkPrevTaxPaid = 0
      WrkPrevIntPaid = 0
      WrkPrevLienPaid = 0
      WrkPrevFeePaid = 0
      If CheckForDup(WrkBatchNo, ._LISTNo, ._TYPE, ._YEAR) Then
        PrevTrans(WrkBatchNo, ._LISTNo, ._TYPE, ._YEAR, ._TRNBR,
        WrkPrevTaxPaid, WrkPrevIntPaid, WrkPrevLienPaid, WrkPrevFeePaid)
        WrkDue = WrkDue - WrkPrevTaxPaid
        WrkInterest = WrkInterest - WrkPrevIntPaid
        WrkLien = WrkLien - WrkPrevLienPaid
      End If
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
      WrkFeeDue = WrkFeeDue - WrkPrevFeePaid
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
      ._LAMT = WrkLien
      ._ADJ = String.Empty
      ._RDTE = MyUtils.SetDBDate(WrkReceiptDate)
      If WrkFormat = "" Then
        If WrkDBDatePaid <> MyUtils.SetDBDate(WrkReceiptDate) Then
          WrkMsg = "Receipt date is different than date in file"
        End If
      End If
      'Determine What Fees to pay
      With myTXINV
        WrkFee(0) = ._FED1
        WrkFee(1) = ._FED2
        WrkFee(2) = ._FED3
        WrkFee(3) = ._FED4
        WrkFee(4) = ._FED5
        WrkFeecd(0) = ._FEC1
        WrkFeecd(1) = ._FEC2
        WrkFeecd(2) = ._FEC3
        WrkFeecd(3) = ._FEC4
        WrkFeecd(4) = ._FEC5
        WrkFee(5) = 0
        WrkFeecd(5) = ""
        If ._MVFLAG = "Y" And WrkFeeDue > 0 Or ._MVFLAG = "M" And WrkFeeDue > 0 Then
          WrkFee(5) = MyMVFee
          WrkFeecd(5) = "MV"
          WrkFeeDue = WrkFeeDue - WrkFee(5)
        End If
        If WrkBond > 0 Then
          WrkFee(5) = WrkBond
          WrkFeecd(5) = "BI"
        End If
        If WrkPrevFeePaid > 0 Then
          PrevPaidFee(WrkBatchNo, WrkListNo, WrkType, WrkYear, myTCRBCH._TRNBR, WrkFee, WrkFeecd)
        End If
      End With
      For J = 0 To 4
        If WrkFee(J) > 0 And WrkFeeDue > 0 Then
          If WrkFeeDue < WrkFee(J) Then
            WrkFee(J) = WrkFeeDue
          End If
          WrkFeeDue = WrkFeeDue - WrkFee(J)
        Else
          WrkFee(J) = 0
          WrkFeecd(J) = ""
        End If
      Next
      ._PCAMT = WrkFee.Sum ' (0) + WrkFee(1) + WrkFee(2) + WrkFee(3) + WrkFee(4) + WrkFee(5) + WrkFee(6)
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
      ._REF = WrkRef
      ._COMM = "WEB PAYMENT"
      If WrkCheck Then
        ._PMETH = "2"
      Else
        ._PMETH = "3"
      End If
      ._SRC = 5
      '.AddOneRecordP()
      .AddOneRecordFast()
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
    TotBond = TotBond + WrkBond

NextRec:
    '    With myFrmProgress
    WrkPct = (I / WrkFileSize) * 100
    If SavePct <> WrkPct Then
        If myFrmProgress.InvokeRequired Then
          myFrmProgress.Invoke(Sub()
                                 myFrmProgress.ProgBar1.Value = WrkPct
                                 myFrmProgress.Refresh()
                               End Sub)
        Else
          myFrmProgress.ProgBar1.Value = WrkPct
          myFrmProgress.Refresh()
        End If
        '.ProgBar1.Value = WrkPct
        '.Refresh()
        'Application.DoEvents()
      End If
    '   End With
    SavePct = WrkPct
    GoTo NextLine

WriteBatch:
    With myBCHHDR
      ._APPID = CBatchType
      ._BCHNO = WrkBatchNo
      ._ORGUS = "GEMSNET"
      ._STATS = "S"
      ._STRDT = MyUtils.SetDBDate(WrkInterestDate)
      ._SUBST = "W"
      ._PSDT = MyUtils.SetDBDate(WrkReceiptDate)
      .AddOneRecordP()
    End With

    myBCHHDR.GetOneRecordP(CBatchType, 0)
    If Not myBCHHDR.RecordNotFound Then
      With myBCHHDR
        ._LSBCH = WrkBatchNo
        .UpdateOneRecordP()
      End With
    Else
      With myBCHHDR
        ._APPID = CBatchType
        ._BCHNO = 0
        ._LSBCH = WrkBatchNo
        .AddOneRecordP()
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
    'myFrmProgress.Close()
    myTCRBCH.CloseFile()

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
  Private Sub ReadNormal()
    Dim ChkType As String
    Dim WrkStr As String

    WrkListNo = 0
    ChkType = Trim(Mid(strBuffer, 10, 1))
    If IsNumeric(ChkType) Or ChkType = String.Empty Then
      If myTOWN._TOWNBR = 4 Or myTOWN._TOWNBR = 131 Then 'Avon/Southingotn
        WrkListNo = MyUtils.CnvSng(Mid(strBuffer, 4, 7))
        WrkYear = MyUtils.CnvSng("20" & Mid(strBuffer, 1, 2))
        WrkType = Mid(strBuffer, 3, 1)
      Else
        WrkListNo = MyUtils.CnvSng(Mid(strBuffer, 5, 6))
        WrkYear = MyUtils.CnvSng("20" & Mid(strBuffer, 2, 2))
        WrkType = Mid(strBuffer, 4, 1)
      End If
    Else
      WrkListNo = MyUtils.CnvSng(Mid(strBuffer, 2, 6))
      WrkYear = MyUtils.CnvSng("20" & Mid(strBuffer, 8, 2))
      WrkType = Mid(strBuffer, 10, 1)
    End If
    If WrkYear >= 2070 Then WrkYear = WrkYear - 100
    WrkPaid = MyUtils.CnvSng(Mid(strBuffer, 11, 11)) / 100
    WrkStr = Mid(strBuffer, 36, 10)
    WrkStr = Replace(WrkStr, "/", "")
    WrkStr = Mid(WrkStr, 5, 4) & Mid(WrkStr, 1, 4)
    WrkDBDatePaid = MyUtils.CnvSng(WrkStr)
    WrkRef = Trim(Mid(strBuffer, 50, 10))

  End Sub
  Private Sub ReadWebster()
    WrkListNo = 0
    If Mid(strBuffer, 1, 1) = "P" Then
      WrkYear = MyUtils.CnvSng(Mid(strBuffer, 6, 4))
      WrkType = GetTypeNoWebster(MyUtils.CnvSng(Mid(strBuffer, 10, 1)))
      If Trim(Mid(strBuffer, 29, 1)) <> String.Empty Then
        WrkListNo = MyUtils.CnvSng(Mid(strBuffer, 11, 7))
        WrkPaid = MyUtils.CnvSng(Mid(strBuffer, 18, 12)) / 100
      Else
        WrkListNo = MyUtils.CnvSng(Mid(strBuffer, 11, 6))
        WrkPaid = MyUtils.CnvSng(Mid(strBuffer, 17, 12)) / 100
      End If
    End If
    WrkRef = String.Empty
  End Sub
  Private Sub ReadAvon()
    WrkListNo = MyUtils.CnvSng(Mid(strBuffer, 3, 7))
    WrkPaid = MyUtils.CnvSng(Mid(strBuffer, 10, 10))
    WrkYear = "20" & MyUtils.CnvSng(Mid(strBuffer, 1, 2))
    WrkType = ""
    myTXINV.GetOneRecordP(WrkListNo, WrkYear, "R")
    If Not myTXINV.RecordNotFound Then
      If myTXINV._TAX1 = WrkPaid Or myTXINV._TAXT = WrkPaid Then
        WrkType = "R"
      End If
    End If
    If WrkType = "" Then
      myTXINV.GetOneRecordP(WrkListNo, WrkYear, "M")
      If Not myTXINV.RecordNotFound Then
        If myTXINV._TAX1 = WrkPaid Or myTXINV._TAXT = WrkPaid Then
          WrkType = "M"
        End If
      End If
    End If
    If WrkType = "" Then
      myTXINV.GetOneRecordP(WrkListNo, WrkYear, "P")
      If Not myTXINV.RecordNotFound Then
        If myTXINV._TAX1 = WrkPaid Or myTXINV._TAXT = WrkPaid Then
          WrkType = "P"
        End If
      End If
    End If
    WrkRef = String.Empty
  End Sub
  Public Function GetTypeNoWebster(ByVal Type As Integer) As String
    '1 FOR REAL ESTATE       
    '2 FOR PERSONAL PROPERTY 
    '3 FOR MOTOR VEHICLE  
    '4 FOR SUPPLEMENT MOTOR VEHICLE
    Select Case Type
      Case 1
        Return "R"
      Case 2
        Return "P"
      Case 3
        Return "M"
      Case 4
        Return "S"
      Case Else
        If myTOWN._TOWNBR = 96 And Type = 0 Then
          Return "S"
        End If
        Return Type
    End Select
  End Function
  Private Function CheckForDup(ByVal BatchNo As Integer, ByVal List As Integer,
  ByVal Type As String, ByVal Year As Integer) As Boolean

    Dim ds2 As DataSet = New DataSet
    Dim WrkDup As Boolean


    WrkDup = False
    ds2 = myTCRBCHL1.GetViewbyList(BatchNo, List, Year, Type, 1)
    If ds2.Tables(0).Rows.Count > 0 Then
      WrkDup = True
    End If

    Return WrkDup
  End Function
  Private Sub PrevTrans(ByVal BatchNo As Integer, ByVal List As Integer,
  ByVal Type As String, ByVal Year As Integer, ByVal WrkTrnbr As Integer,
  ByRef OutPamt As Decimal, ByRef OutIamt As Decimal, ByRef OutLamt As Decimal, ByRef OutPCamt As Decimal)

    Dim ds2 As DataSet = New DataSet
    Dim I As Integer
    OutPamt = 0
    OutIamt = 0
    OutLamt = 0
    OutPCamt = 0
    ds2 = myTCRBCHL1.GetViewbyList(BatchNo, List, Year, Type, 999)
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        If .Item("trnbr") < WrkTrnbr Then
          OutPamt = OutPamt + .Item("pamt")
          OutIamt = OutIamt + .Item("iamt")
          OutLamt = OutLamt + .Item("lamt")
          If .Item("pencd7") <> "CA" Then
            OutPCamt = OutPCamt + .Item("pcamt")
          Else
            OutPCamt = OutPCamt + .Item("pcamt1") + .Item("pcamt2") + .Item("pcamt3") +
            .Item("pcamt4") + .Item("pcamt5") + .Item("pcamt6")
          End If
        End If
      End With
    Next
  End Sub
  Private Sub PrevPaidFee(ByVal BatchNo As Integer, ByVal List As Integer,
  ByVal Type As String, ByVal Year As Integer, ByVal WrkTrnbr As Integer,
  ByRef WrkFee() As Decimal, ByRef WrkFeeCd() As String)

    Dim ds2 As DataSet = New DataSet
    Dim I As Integer
    Dim J As Integer
    ds2 = myTCRBCHL1.GetViewbyList(BatchNo, List, Year, Type, 999)
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        If .Item("trnbr") < WrkTrnbr Then
          For J = 0 To 5
            If .Item("pcamt1") > 0 And .Item("pencd1") = WrkFeeCd(J) Then
              If WrkFee(J) <= .Item("pcamt1") Then
                WrkFee(J) = 0
                WrkFeeCd(J) = ""
              Else
                WrkFee(J) = WrkFee(J) - .Item("pcamt1")
              End If
            End If
            If .Item("pcamt2") > 0 And .Item("pencd2") = WrkFeeCd(J) Then
              If WrkFee(J) <= .Item("pcamt2") Then
                WrkFee(J) = 0
                WrkFeeCd(J) = ""
              Else
                WrkFee(J) = WrkFee(J) - .Item("pcamt2")
              End If
            End If
            If .Item("pcamt3") > 0 And .Item("pencd3") = WrkFeeCd(J) Then
              If WrkFee(J) <= .Item("pcamt3") Then
                WrkFee(J) = 0
                WrkFeeCd(J) = ""
              Else
                WrkFee(J) = WrkFee(J) - .Item("pcamt3")
              End If
            End If
            If .Item("pcamt4") > 0 And .Item("pencd4") = WrkFeeCd(J) Then
              If WrkFee(J) <= .Item("pcamt4") Then
                WrkFee(J) = 0
                WrkFeeCd(J) = ""
              Else
                WrkFee(J) = WrkFee(J) - .Item("pcamt4")
              End If
            End If
            If .Item("pcamt5") > 0 And .Item("pencd5") = WrkFeeCd(J) Then
              If WrkFee(J) <= .Item("pcamt5") Then
                WrkFee(J) = 0
                WrkFeeCd(J) = ""
              Else
                WrkFee(J) = WrkFee(J) - .Item("pcamt5")
              End If
            End If
            If .Item("pcamt6") > 0 And .Item("pencd6") = WrkFeeCd(J) Then
              If WrkFee(J) <= .Item("pcamt6") Then
                WrkFee(J) = 0
                WrkFeeCd(J) = ""
              Else
                WrkFee(J) = WrkFee(J) - .Item("pcamt6")
              End If
            End If
          Next
        End If
      End With
    Next
  End Sub
End Module





