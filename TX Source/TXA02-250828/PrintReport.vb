Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myBCHHDR As BCHHDR.myData
  Dim myTCRBCH As TCRBCH.myData
  Dim myTCRBCHL1 As TCRBCHL1.myData
  Dim myTXINV As TXINV.myData
  Dim MyCASHINT As CASHINT.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As DataRow

  Dim WrkFormat As String
  Dim WrkReceiptDate As Date
  Dim WrkInterestDate As Date
  Dim WrkBatchNo As Integer
  Dim strBuffer As String
  Dim WrkListNo As Integer
  Dim WrkYear As Integer
  Dim WrkType As String
  Dim WrkDist As Integer
  Dim WrkRef As String
  Dim WrkComm As String
  Dim WrkPaid As Decimal
  Public Sub PrtReport()

    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myTCRBCH = New TCRBCH.MyData(myDBConnect)
    myTCRBCHL1 = New TCRBCHL1.mydata(MyDBConnect)
    myTXINV = New TXINV.mydata(MyDBConnect)
    MyCASHINT = New CASHINT.mydata(MyDBConnect)

    With MyFrmTXA02B
      WrkReceiptDate = .DtPckReceipt.Value
      WrkInterestDate = .DtPckInterest.Value
      WrkFormat = ""
      If .RbNon.Checked Then
        WrkFormat = "NON"
      End If
      If .RbChase.Checked Then
        WrkFormat = "CHASE"
      End If
      If .RbAmerica.Checked Then
        WrkFormat = "AMERICA"
      End If
      If .RbWebster.Checked Then
        WrkFormat = "WEBSTER"
      End If
      If .RbTaxServ.Checked Then
        WrkFormat = "TAXSERV"
      End If
      WrkComm = .TxtComm.Text
    End With

    If ds.Tables.Count = 0 Then
      BuildDs(ds)
    Else
      ds.Clear()
    End If

    GetDetail()

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
      .Columns.Add("Pcamt", Type.GetType("System.Decimal"))
      .Columns.Add("Lamt", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
    End With
    Ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkStream As FileStream = New FileStream(MyFrmTXA02B.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim WrkSeqNo As Integer
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

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    WrkBatchNo = myBCHHDR.AutoGenKey(CBatchType)
    myBCHHDR.GetOneRecordP(CBatchType, WrkBatchNo)
    With myBCHHDR
      ._APPID = CBatchType
      ._BCHNO = WrkBatchNo
      ._ORGUS = "NET-TXA02"
      ._STATS = "I"
      ._STRDT = MyUtils.SetDBDate(WrkInterestDate)
      If MyFrmTXA02B.RbTaxServ.Checked Then
        ._SUBST = "K"
      Else
        ._SUBST = "B"
      End If
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
        ._PSDT = 0
        ._ORGUS = ""
        ._STATS = ""
        ._STRDT = 0
        ._SUBST = ""
        .AddOneRecordP()
      End With
    End If

    WrkSeqNo = 0
    TotCount = 0
    TotPaid = 0
    TotInt = 0
    TotLien = 0
    TotFee = 0

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo WriteBatch
      Exit Sub
    End If

    I = I + strBuffer.Length
    With myTCRBCH
      Select Case WrkFormat
        Case "", "TAXSERV"
          ReadNormal()
          myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
        Case "NON"
          ReadNon()
          If WrkDist = 0 Then
            myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
            If Not myTXINV.RecordNotFound Then
              WrkDist = myTXINV._DIST
            End If
          End If
        Case "CHASE"
          ReadChase()
          If WrkDist = 0 Then
            myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
            If Not myTXINV.RecordNotFound Then
              WrkDist = myTXINV._DIST
            End If
          End If
        Case "AMERICA"
          ReadAmerica(False)
          If WrkListNo = 0 Then GoTo NextRec
          myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
          If Not myTXINV.RecordNotFound Then
            If WrkPaid <> myTXINV._TAX1 And WrkPaid <> myTXINV._TAX2 _
          And WrkPaid <> myTXINV._TX3RD And WrkPaid <> myTXINV._TX4TH And WrkPaid <> myTXINV._TAXT Then
              'Check Addl. Tax Type
              ReadAmerica(True)
              myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
            End If
          End If
          If WrkDist = 0 Then
            If Not myTXINV.RecordNotFound Then
              WrkDist = myTXINV._DIST
            End If
          End If
        Case "WEBSTER"
          ReadWebster()
          If WrkListNo = 0 Then GoTo NextRec
          If WrkDist = 0 Then
            myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
            If Not myTXINV.RecordNotFound Then
              WrkDist = myTXINV._DIST
            End If
          End If
      End Select
      WrkSeqNo = WrkSeqNo + 1
      .GetOneRecordP(WrkBatchNo, WrkSeqNo)
      ._BCHNO = WrkBatchNo
      ._TRNBR = WrkSeqNo
      ._RDTE = MyUtils.SetDBDate(WrkReceiptDate)
      ._LISTNo = WrkListNo
      ._YEAR = WrkYear
      ._TYPE = WrkType
      If Not myTXINV.RecordNotFound Then
        ._NAME = Trim(myTXINV._NAME)
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
      ._DIST = WrkDist
      ._PAMT = WrkPaid
      ._IAMT = WrkInterest
      ._LAMT = WrkLien
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
      ._ADJ = String.Empty
      If WrkRef <> "0" Then
        ._REF = WrkRef
      Else
        ._REF = String.Empty
      End If
      ._COMM = WrkComm
      ._PMETH = "2"
      ._SRC = 4
    End With
    myTCRBCH.AddOneRecordP()
    If myTCRBCH.ErrMsg <> "" Then
      WriteErrorLog(myTCRBCH.ErrMsg)
      Exit Sub
    End If
    TotCount = TotCount + 1
    TotPaid = TotPaid + WrkPaid
    TotFee = TotFee + myTCRBCH._PCAMT
    TotInt = TotInt + WrkInterest
    TotLien = TotLien + WrkLien
    TotBond = TotBond + WrkBond

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
      .GetOneRecordP(CBatchType, WrkBatchNo)
      ._STATS = "S"
      .UpdateOneRecordP()
    End With

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
  Private Sub ReadNormal()
    Dim WrkTownNo As Integer
    WrkTownNo = myTOWN._TOWNBR
    WrkListNo = Mid(strBuffer, 1, 7)
    WrkYear = MyUtils.CnvSng("20" & Mid(strBuffer, 8, 2))
    Select Case WrkTownNo
      Case 99 'North Branford
        WrkType = GetTypeNoWebster(MyUtils.CnvSng(Mid(strBuffer, 10, 1)))
      Case 84 'Milford
        WrkType = Mid(strBuffer, 10, 1)
      Case Else
        WrkType = GetTypeNo(MyUtils.CnvSng(Mid(strBuffer, 10, 1)))
    End Select
    If WrkFormat = "TAXSERV" Then
      WrkType = Mid(strBuffer, 10, 1)
    End If
    WrkDist = 0
    WrkPaid = MyUtils.CnvSng(Mid(strBuffer, 11, 11)) / 100
    WrkPaid = WrkPaid + MyUtils.CnvSng(Mid(strBuffer, 22, 9)) / 100 'Interest
    WrkPaid = WrkPaid + MyUtils.CnvSng(Mid(strBuffer, 31, 5)) / 100 'Liens
    If Mid(strBuffer, 61, 1) = String.Empty Then
      WrkRef = MyUtils.CnvSng(Mid(strBuffer, 50, 11))
    Else
      WrkRef = MyUtils.CnvSng(Mid(strBuffer, 50, 12))
    End If
    WrkRef = Mid(WrkRef, 1, 10)
  End Sub
  Private Sub ReadNon()
    Dim WrkTownNo As Integer
    WrkTownNo = myTOWN._TOWNBR
    WrkYear = MyUtils.CnvSng("20" & Mid(strBuffer, 1, 2))
    WrkType = GetTypeNo(MyUtils.CnvSng(Mid(strBuffer, 3, 1)))
    WrkListNo = Mid(strBuffer, 4, 6)
    WrkDist = Mid(strBuffer, 10, 3)
    WrkPaid = MyUtils.CnvSng(Mid(strBuffer, 18, 9)) / 100
    WrkPaid = WrkPaid + MyUtils.CnvSng(Mid(strBuffer, 27, 9)) / 100 'Interest
    WrkRef = ""
  End Sub
  Private Sub ReadChase()
    WrkListNo = MyUtils.CnvSng(Mid(strBuffer, 4, 6))
    WrkYear = MyUtils.CnvSng("20" & Mid(strBuffer, 1, 2))
    WrkType = Mid(strBuffer, 3, 1)
    WrkDist = Mid(strBuffer, 10, 3)
    WrkPaid = MyUtils.CnvSng(Mid(strBuffer, 18, 18)) / 100
    WrkRef = Mid(strBuffer, 13, 4)
  End Sub
  Private Sub ReadAmerica(ByVal CheckAddl As Boolean)
    WrkListNo = 0
    If Mid(strBuffer, 1, 1) = "H" Then
      WrkListNo = MyUtils.CnvSng(Mid(strBuffer, 6, 6))
      WrkYear = MyUtils.CnvSng(MyFrmTXA02B.TxtGLYear.Text)
      If CheckAddl Then
        WrkType = GetTypeNoAmericaAddl(MyUtils.CnvSng(Mid(strBuffer, 2, 1)))
      Else
        WrkType = GetTypeNoAmerica(MyUtils.CnvSng(Mid(strBuffer, 2, 1)))
      End If
      WrkDist = 0
      WrkPaid = MyUtils.CnvSng(Mid(strBuffer, 18, 8)) / 100
      WrkRef = String.Empty
    End If
  End Sub
  Private Sub ReadWebster()
    WrkListNo = 0
    If Mid(strBuffer, 1, 1) = "P" Then
      WrkYear = MyUtils.CnvSng(Mid(strBuffer, 6, 4))
      If myTOWN._TOWNBR = 35 Or myTOWN._TOWNBR = 45 Then 'Darien/East Lyme
        WrkType = GetTypeNo(MyUtils.CnvSng(Mid(strBuffer, 10, 1)))
      Else
        WrkType = GetTypeNoWebster(MyUtils.CnvSng(Mid(strBuffer, 10, 1)))
      End If
      If Len(strBuffer) = 29 Or myTOWN._TOWNBR = 32 Or myTOWN._TOWNBR = 162 Then 'Avon, Coventry or Winchester
        WrkListNo = MyUtils.CnvSng(Mid(strBuffer, 11, 7))
        WrkPaid = MyUtils.CnvSng(Mid(strBuffer, 18, 12)) / 100
      Else
        WrkListNo = MyUtils.CnvSng(Mid(strBuffer, 11, 6))
        WrkPaid = MyUtils.CnvSng(Mid(strBuffer, 17, 12)) / 100
      End If
      WrkDist = 0
      WrkRef = String.Empty
    End If
    'WrkYear = MyUtils.CnvSng(Mid(strBuffer, 6, 4))
    'WrkType = GetTypeNoWebster(MyUtils.CnvSng(Mid(strBuffer, 10, 1)))
  End Sub
  Public Function GetTypeNo(ByVal Type As Integer) As String
    '1 FOR SUPPLEMENT MOTOR VEHICLE
    '2 FOR MOTOR VEHICLE  
    '3 FOR PERSONAL PROPERTY 
    '4 FOR REAL ESTATE       
    Select Case Type
      Case 1
        Return "S"
      Case 2
        Return "M"
      Case 3
        Return "P"
      Case 4
        Return "R"
      Case 6
        Return "C"
      Case 7
        Return "D"
      Case 8
        Return "W"
      Case 9
        Return "U"
      Case Else
        Return Type
    End Select
  End Function
  Public Function GetTypeNoAmerica(ByVal Type As Integer) As String
    '1 FOR REAL ESTATE       
    '2 FOR PERSONAL PROPERTY 
    '3 FOR MOTOR VEHICLE  
    '4 FOR SUPPLEMENT MOTOR VEHICLE
    '6 FOR SEWER METERED 
    '7 FOR WATER METERED
    '8 FOR WATER USAGE
    '9 FOR SEWER USAGE 
    Select Case Type
      Case 1
        Return "R"
      Case 2
        Return "P"
      Case 3
        Return "M"
      Case 4
        Return "S"
      Case 6
        Return "C"
      Case 7
        Return "D"
      Case 8
        Return "W"
      Case 9
        Return "U"
      Case Else
        Return Type
    End Select
  End Function
  Public Function GetTypeNoAmericaAddl(ByVal Type As Integer) As String
    '1 FOR ADDL. REAL ESTATE       
    '2 FOR ADDL. PERSONAL PROPERTY 
    '3 FOR ADDL. MOTOR VEHICLE  
    '4 FOR ADDL. MOTOR VEHICLE
    Select Case Type
      Case 1
        Return "Y"
      Case 2
        Return "Z"
      Case 3
        Return "N"
      Case 4
        Return "T"
      Case Else
        Return Type
    End Select
  End Function
  Public Function GetTypeNoWebster(ByVal Type As Integer) As String
    '1 FOR REAL ESTATE       
    '2 FOR PERSONAL PROPERTY 
    '3 FOR MOTOR VEHICLE  
    '4 FOR SUPPLEMENT MOTOR VEHICLE
    '5 FOR TRASH
    '6 FOR SEWER METERED 
    '7 FOR WATER METERED
    '8 FOR WATER USAGE
    '9 FOR SEWER USAGE 
    Select Case Type
      Case 1
        Return "R"
      Case 2
        Return "P"
      Case 3
        Return "M"
      Case 4
        Return "S"
      Case 5
        Return "T"
      Case 6
        Return "C"
      Case 7
        Return "D"
      Case 8
        Return "W"
      Case 9
        Return "U"
      Case Else
        If myTOWN._TOWNBR = 96 And Type = 0 Then
          Return "S"
        End If
        Return Type
    End Select
  End Function
  Public Sub CalcInterest(ByVal InListNo As Integer, ByVal InType As String,
  ByVal InYear As Integer, ByVal InDate As Integer, ByRef OutInterest As Decimal, ByRef OutInterestPaid As Decimal,
  ByRef OutFee As Decimal, ByRef OutCAFee As Decimal, ByRef OutLien As Decimal, ByRef OutBond As Decimal,
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






