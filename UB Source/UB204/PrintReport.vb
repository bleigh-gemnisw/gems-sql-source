Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myUTCUSTQ As UTCUSTQ.MyData
  Dim myUTCUSTAS As UTCUSTAS.MyData
  Dim myUTCUSTRT As UTCUSTRT.MyData
  Dim myUTRATEAS As UTRATEAS.MyData
  Dim myUTTYPE As UTTYPE.MyData
  Dim myUTCNTL As UTCNTL.MyData

  Dim MyUBCalcBillA As UBCalcBill.BillAssessment
  Dim MyUBCalcBillAmort As UBCalcBill.Amort

  Dim ds As DataSet = New DataSet
  Dim dsDet As DataSet = New DataSet
  Dim dsTot As DataSet = New DataSet
  Dim DsUTCUST As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim drDet As Data.DataRow
  Dim drTot As Data.DataRow

  'Screen fields

  Dim WrkSelListNo As Integer
  Dim WrkSortBy As String

  'Common Work fields
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkListNo As Integer
  Dim WrkTaxType As String
  Dim WrkUBType As String
  Dim WrkBillDesc As String
  Dim WrkFamily As String
  Dim WrkCode As String

  'Assessment Work Fields
  Dim WrkOrigAssmnt As Decimal
  Dim WrkBillAmt As Decimal
  Dim WrkBillNo As Integer
  Dim WrkBond As Decimal
  Dim WrkBillsLeft As Integer
  Dim WrkYearNo As Integer
  Dim WrkAssmntLeft As Decimal
  Dim WrkAssmntDue As Decimal
  Dim WrkAssmntAdjust As Decimal
  Dim WrkAmortCurr As Boolean
  Dim WrkDeferred As Decimal
  Dim SaveAssmntLeft As Decimal
  'work fields
  Dim WrkBalance As Decimal
  Dim WrkTotal As Decimal
  Dim WrkDelqInterest As Decimal
  Dim WrkDelqLien As Decimal
  Dim WrkDelqBond As Decimal
  Dim WrkDelqPrincipal As Decimal
  Dim WrkCaveat As Decimal
  Dim WrkAmortPrincipal As Decimal
  Dim WrkAmortBond As Decimal
  Public Sub PrtReport()

    myUTCUSTQ = New UTCUSTQ.MyData(myDBConnect)
    myUTCUSTAS = New UTCUSTAS.MyData(myDBConnect)
    myUTCUSTRT = New UTCUSTRT.MyData(myDBConnect)
    myUTRATEAS = New UTRATEAS.MyData(myDBConnect)
    myUTTYPE = New UTTYPE.MyData(myDBConnect)
    myUTCNTL = New UTCNTL.MyData(myDBConnect)
    MyUBCalcBillA = New UBCalcBill.BillAssessment(myDBConnect)
    MyUBCalcBillAmort = New UBCalcBill.Amort(myDBConnect)

    With MyFrmUB204B
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkDistAll = False
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkUBType = .TxtType.Text
      WrkSelListNo = MyUtils.CnvSng(.TxtListNo.Text)
      If .RbSortList.Checked Then
        WrkSortBy = "List"
      End If
      If .RbSortName.Checked Then
        WrkSortBy = "Name"
      End If
      If .RbSortLocation.Checked Then
        WrkSortBy = "Location"
      End If
      WrkAmortCurr = False
      If .RbAmortCurr.Checked Then
        WrkAmortCurr = True
      End If
    End With

    myUTTYPE.GetOneRecordP(WrkUBType)
    If myUTTYPE.RecordNotFound Then Exit Sub

    WrkTaxType = myUTTYPE._TYTXTP

    WrkCaveat = 0
    myUTCNTL.GetOneRecordP(1)
    If Not myUTCNTL.RecordNotFound Then
      WrkCaveat = myUTCNTL._UBCAV
    End If

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
      dsDet.Clear()
      dsTot.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .wrkdsTot = dsTot
      .Wrksort = WrkSortBy
      .WrkUBType = WrkUBType
      .WrkCaveat = WrkCaveat
      .Show()
    End With


  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable
    Dim myTableTot As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("SortData", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("BillType", Type.GetType("System.String"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("Location", Type.GetType("System.String"))
      .Columns.Add("Units", Type.GetType("System.Decimal"))
      .Columns.Add("OrigAssmnt", Type.GetType("System.Decimal"))
      .Columns.Add("AssmntLeft", Type.GetType("System.Decimal"))
      .Columns.Add("Deferred", Type.GetType("System.Decimal"))
      .Columns.Add("BondPct", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)

    With myTable2
      .TableName = "mytable2"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("PaymentNo", Type.GetType("System.Int16"))
      .Columns.Add("BillAmt", Type.GetType("System.Decimal"))
      .Columns.Add("Principal", Type.GetType("System.Decimal"))
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
      .Columns.Add("Balance", Type.GetType("System.Decimal"))
    End With
    dsDet.Tables.Add(myTable2)

    With myTableTot
      .TableName = "mytabletot"
      .Columns.Add("Count", Type.GetType("System.Int16"))
      .Columns.Add("OrigAssmnt", Type.GetType("System.Decimal"))
      .Columns.Add("Deferred", Type.GetType("System.Decimal"))
      .Columns.Add("AssmntDue", Type.GetType("System.Decimal"))
      .Columns.Add("AmortPrincipal", Type.GetType("System.Decimal"))
      .Columns.Add("AmortBond", Type.GetType("System.Decimal"))
      .Columns.Add("AmortTotal", Type.GetType("System.Decimal"))
    End With
    dsTot.Tables.Add(myTableTot)
  End Sub

  Private Sub GetDetail()
    Dim AddrLine() As String
    Dim WrkQry As String
    Dim WrkSort As String
    Dim I As Integer
    Dim WrkAnd As String
    Dim WrkCount As Integer
    Dim WrkTotOrigAssmnt As Decimal
    Dim WrkTotDeferred As Decimal
    Dim WrkTotAssmntDue As Decimal
    Dim WrkTotAmortPrincipal As Decimal
    Dim WrkTotAmortBond As Decimal

    WrkFamily = GetUTTYPEFamily(WrkUBType)

    If MyServer = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = ""
    WrkSort = ""
    WrkCount = 0
    WrkTotOrigAssmnt = 0
    WrkTotDeferred = 0
    WrkTotAssmntDue = 0
    WrkTotAmortPrincipal = 0
    WrkTotAmortBond = 0

    If Not WrkDistAll Then
      WrkQry = "cudst=" & WrkDist
    End If
    If WrkSelListNo > 0 Then
      If WrkQry = String.Empty Then
        WrkQry = "CUACCT = " & WrkSelListNo
      Else
        WrkQry = WrkQry & WrkAnd & "CUACCT = " & WrkSelListNo
      End If
    End If

    Select Case WrkSortBy
      Case "List"
        WrkSort = "CUACCT"
      Case "Name"
        WrkSort = "CUNAM1"
      Case "Location"
        WrkSort = "CULOC, CULOC#"
    End Select

    DsUTCUST = myUTCUSTQ.GetQry(WrkSort, WrkQry, 0)

    If DsUTCUST.Tables(0).Rows.Count = 0 Then Exit Sub
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsUTCUST.Tables(0).Rows.Count - 1)
      With DsUTCUST.Tables(0).Rows(I)

        WrkListNo = .Item("cuacct")
        WrkCode = GetRateCode(WrkUBType)

        If Trim(WrkCode) = "" Then GoTo NextRec

        AddrLine = MyUtils.SetAddrLine(.Item("cunam1"), .Item("cunam2"), .Item("cuadd1"),
      .Item("cuadd2"), .Item("cucity"), .Item("cust"), 0, 0, .Item("cuzip"))
      End With

      'Report
      dr = ds.Tables(0).NewRow
      Select Case WrkSortBy
        Case "List"
          dr.Item("sortdata") = Format(WrkListNo, "000000")
        Case "Name"
          dr.Item("sortdata") = DsUTCUST.Tables(0).Rows(I).Item("cunam1")
        Case "Location"
          dr.Item("sortdata") = Trim(DsUTCUST.Tables(0).Rows(I).Item("culoc")) & " " & DsUTCUST.Tables(0).Rows(I).Item("culoc#")
      End Select
      dr.Item("listno") = WrkListNo
      dr.Item("BillType") = WrkBillDesc
      dr.Item("addr1") = AddrLine(0)
      dr.Item("addr2") = AddrLine(1)
      dr.Item("addr3") = AddrLine(2)
      dr.Item("addr4") = AddrLine(3)
      dr.Item("addr5") = AddrLine(4)
      dr.Item("location") = Trim(DsUTCUST.Tables(0).Rows(I).Item("culoc#")) & " " & DsUTCUST.Tables(0).Rows(I).Item("culoc")
      Select Case WrkFamily
        Case "A"
          dr.Item("units") = DsUTCUST.Tables(0).Rows(I).Item("cuaunt")
        Case "U"
          dr.Item("units") = DsUTCUST.Tables(0).Rows(I).Item("cuunit")
      End Select
      GetAmortization(I)
      'Filter - Omit Zero Bills 
      If WrkBillAmt = 0 And WrkAssmntLeft = 0 Then
        GoTo NextRec
      End If

      WrkCount = WrkCount + 1
      dr.Item("Origassmnt") = WrkOrigAssmnt + WrkDeferred
      dr.Item("assmntleft") = SaveAssmntLeft
      dr.Item("deferred") = WrkDeferred
      myUTRATEAS.GetOneRecordP(WrkUBType, WrkCode)
      dr.Item("bondpct") = myUTRATEAS._RAPCT * 100
      ds.Tables(0).Rows.Add(dr)

      WrkTotOrigAssmnt = WrkTotOrigAssmnt + WrkOrigAssmnt + WrkDeferred
      WrkTotAssmntDue = WrkTotAssmntDue + SaveAssmntLeft
      WrkTotDeferred = WrkTotDeferred + WrkDeferred
      WrkTotAmortPrincipal = WrkTotAmortPrincipal + WrkAmortPrincipal
      WrkTotAmortBond = WrkTotAmortBond + WrkAmortBond

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsUTCUST.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    ds.Merge(dsDet)

    drTot = dsTot.Tables(0).NewRow
    drTot.Item("count") = WrkCount
    drTot.Item("Origassmnt") = WrkTotOrigAssmnt
    drTot.Item("deferred") = WrkTotDeferred
    drTot.Item("assmntdue") = WrkTotAssmntDue
    drTot.Item("amortprincipal") = WrkTotAmortPrincipal
    drTot.Item("amortbond") = WrkTotAmortBond
    drTot.Item("amorttotal") = WrkTotAmortPrincipal + WrkTotAmortBond
    dsTot.Tables(0).Rows.Add(drTot)

    myFrmProgress.Close()
    myUTCUSTQ.CloseFile()

  End Sub
  Private Sub CalcAmort(ByVal I As Integer)
    WrkBillAmt = 0
    WrkBond = 0
    If WrkOrigAssmnt = 0 Then Exit Sub

    With MyUBCalcBillAmort
      .In_OrigBill = WrkOrigAssmnt ' - WrkDeferred
      .In_AmtLeft = WrkAssmntDue
      .In_Balance = 0
      .In_RateType = WrkUBType
      .In_RateCode = WrkCode
      .In_NumBills = WrkBillNo
      .In_OverrideBill = myUTCUSTAS._CAOVR
      .In_PctDeferred = myUTCUSTAS._CADEP
      .CalcAmort()
      WrkBillAmt = MyUtils.FmtCurrency(.Out_Bill)
      WrkBond = MyUtils.FmtCurrency(.Out_Bond)
      WrkBillsLeft = .Out_BillsLeft
    End With
  End Sub
  Private Sub CalcAssmnt(ByVal I As Integer)
    With MyUBCalcBillA
      .In_RateType = WrkUBType
      .In_RateCode = WrkCode
      .In_DwellUnits = DsUTCUST.Tables(0).Rows(I).Item("cuaunt")
      .In_PropVal = DsUTCUST.Tables(0).Rows(I).Item("cupval")
      .In_Footage = DsUTCUST.Tables(0).Rows(I).Item("cufoot")
      .In_Acreage = DsUTCUST.Tables(0).Rows(I).Item("cuacre")
      .In_LateralFee = myUTCUSTAS._CALAT
      .In_UniformFee = myUTCUSTAS._CAUNIF
      .In_AssmntAdjust = myUTCUSTAS._CAADJ
      .In_DeferredAmt = myUTCUSTAS._CADEF
      If WrkAmortCurr Then
        .In_PrevBilled = myUTCUSTAS._CAAMT
      Else
        .In_PrevBilled = 0
      End If
      .CalcAssessment()
      WrkOrigAssmnt = MyUtils.FmtCurrency(.Out_OrigBill)
      WrkAssmntLeft = MyUtils.FmtCurrency(.Out_AmtLeft)
      WrkDeferred = myUTCUSTAS._CADEF
    End With
  End Sub


  Private Function GetRateCode(ByVal WrkUBType As String) As String
    GetRateCode = ""
    myUTCUSTRT.GetOneRecordP(WrkListNo, WrkUBType)
    If myUTCUSTRT.RecordNotFound Then Exit Function

    With myUTCUSTRT
      GetRateCode = ._CRCODE
    End With
  End Function
  Private Sub GetAmortization(ByVal I As Integer)
    Dim dsinv As DataSet = New DataSet
    Dim WrkYear As Integer

    WrkOrigAssmnt = 0
    WrkAssmntLeft = 0
    WrkBillNo = 0
    WrkBillsLeft = 0
    WrkBalance = 0
    WrkAssmntDue = 0
    WrkAmortPrincipal = 0
    WrkAmortBond = 0

    myUTCUSTAS.GetOneRecordP(WrkListNo, WrkUBType)
    If myUTCUSTAS.RecordNotFound Then Exit Sub

    CalcAssmnt(I)
    SaveAssmntLeft = WrkAssmntLeft
    If WrkAssmntLeft = 0 Then Exit Sub

    WrkAssmntDue = WrkAssmntLeft + WrkBalance '- WrkDeferred
    If WrkAmortCurr Then
      WrkBillNo = myUTCUSTAS._CAPNO
    Else
      WrkBillNo = 0
    End If

NextYear:
    Do While WrkAssmntDue > 1
      CalcAmort(I)
      WrkYear = WrkYear + 1
      WrkBillNo = WrkBillNo + 1
      WrkAssmntDue = WrkAssmntDue - WrkBillAmt
      dsDet.Tables(0).NewRow()
      drDet = dsDet.Tables(0).NewRow
      drDet("listno") = WrkListNo
      drDet("paymentno") = WrkBillNo
      drDet("Principal") = WrkBillAmt
      drDet("Bond") = WrkBond
      WrkTotal = WrkBillAmt + WrkBond
      drDet("BillAmt") = WrkTotal
      drDet("Balance") = WrkAssmntDue
      dsDet.Tables(0).Rows.Add(drDet)
      WrkAmortPrincipal = WrkAmortPrincipal + WrkBillAmt
      WrkAmortBond = WrkAmortBond + WrkBond
      If WrkBillAmt = 0 Then Exit Do
    Loop

    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
End Module






