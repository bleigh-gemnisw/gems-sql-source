Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myUTCUSTQ As UTCUSTQ.MyData
  Dim myUTCUSTAS As UTCUSTAS.MyData
  Dim myUTCUSTRT As UTCUSTRT.MyData
  Dim myTXINVLK As TXINVLK.MyData
  Dim myTXPROF As TXPROF.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXHST As TXHST.MyData
  Dim myCashInt As CASHINT.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As DataRow

  'Screen fields
  Dim WrkYear As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkPhase As Integer
  Dim WrkPhaseA As String
  Dim WrkSortBy As String
  Dim WrkLienDate As Date
  Dim WrkRptFmt As String
  Dim WrkOrig As Boolean
  Dim WrkPost As Boolean
  Dim ProfTxDate As Date
  Dim ProfLien As Decimal
  'Common Work fields
  Dim WrkListNo As Integer
  Dim WrkTaxType As String
  Dim WrkUBType As String
  Dim WrkBillDesc As String
  Dim WrkFamily As String
  Dim WrkCode As String
  Dim WrkTotal As Double
  Dim WrkTaxTotal As Double
  'Assessment Work Fields
  Dim WrkOrigAssmnt As Decimal
  Dim WrkBillAmt As Decimal
  Dim WrkBond As Decimal
  Dim WrkYearsLeft As Integer
  Dim WrkYearNo As Integer
  Dim WrkAssmntLeft As Decimal
  Dim WrkAssmntAdjust As Decimal
  'Deliquent work fields
  Dim WrkDelqInterest As Decimal
  Dim WrkDelqFee As Decimal
  Dim WrkDelqLien As Decimal
  Dim WrkDelqBond As Decimal
  Dim WrkDelqPrincipal As Decimal
  Public Sub PrtReport()
    myUTCUSTQ = New UTCUSTQ.MyData(myDBConnect)
    myUTCUSTAS = New UTCUSTAS.MyData(myDBConnect)
    myUTCUSTRT = New UTCUSTRT.MyData(myDBConnect)
    myTXINVLK = New TXINVLK.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXHST = New TXHST.MyData(myDBConnect)
    myTXPROF = New TXPROF.MyData(myDBConnect)
    myCashInt = New CASHINT.MyData(myDBConnect)

    With MyFrmUB211B
      WrkYear = MyUtils.CnvSng(.TxtYear.Text)
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
      WrkUBType = .TxtUBType.Text
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkLienDate = MyUtils.StripTime(.DtPckLien.Value)
      If .RbSortList.Checked Then
        WrkSortBy = "List"
      End If
      If .RbSortName.Checked Then
        WrkSortBy = "Name"
      End If
      If .RbSortLocation.Checked Then
        WrkSortBy = "Location"
      End If
      WrkListNo = MyUtils.CnvSng(.TxtListNo.Text)
      If .RbRptEdit.Checked Then WrkRptFmt = "Edit"
      If .RbRptNotice.Checked Then WrkRptFmt = "Notice"
      If .RbRptClerk.Checked Then WrkRptFmt = "Clerk"
      If .RbRptBlanket.Checked Then WrkRptFmt = "Blanket"
      WrkOrig = .RbOrig.Checked
      WrkPost = False
      If .ChkPost.Checked Then
        WrkPost = True
      End If
    End With

    If WrkPhase = 0 Then
      WrkPhaseA = ""
    Else
      WrkPhaseA = WrkPhase
    End If
    myTXPROF.GetOneRecordP(WrkUBType, WrkYear, WrkPhaseA, WrkDist)
    If Not myTXPROF.RecordNotFound Then
      With myTXPROF
        ProfTxDate = MyUtils.GetDBDateMDY(._PRDUE1)
        ProfLien = ._PRLIEN
      End With
    Else
      MsgBox("Type: " & WrkUBType & vbCrLf & "Year: " & WrkYear, MsgBoxStyle.Critical, "Tax Profile missing")
      Exit Sub
    End If

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .WrkUBType = WrkUBType
      .WrkDueDate = ProfTxDate
      .WrkNoYears = WrkYearNo + WrkYearsLeft
      .WrkRptFmt = WrkRptFmt
      .WrkLienFee = ProfLien
      .Show()
    End With

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("BillType", Type.GetType("System.String"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("PropDesc2", Type.GetType("System.String"))
      .Columns.Add("Vol", Type.GetType("System.String"))
      .Columns.Add("Page", Type.GetType("System.String"))
      .Columns.Add("Assmnt", Type.GetType("System.Decimal"))
      .Columns.Add("Bill", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Liens", Type.GetType("System.Decimal"))
      .Columns.Add("Fees", Type.GetType("System.Decimal"))
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
      .Columns.Add("Years", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim AddrLine() As String
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim WrkAnd As String

    WrkBillDesc = GetUTTypeDesc(WrkUBType)
    WrkTaxType = GetUTTYPETaxType(WrkUBType)
    WrkFamily = GetUTTYPEFamily(WrkUBType)

    If MyServer = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = ""
    If Not WrkDistAll Then
      WrkQry = "cudst=" & WrkDist
    End If

    If WrkListNo > 0 Then
      If WrkQry = "" Then
        WrkQry = "cuacct=" & WrkListNo
      Else
        WrkQry = WrkQry & WrkAnd & "cuacct=" & WrkListNo
      End If
    End If
    WrkSort = ""
    Select Case WrkSortBy
      Case "List"
        WrkSort = "CUACCT"
      Case "Name"
        WrkSort = "CUNAM1"
      Case "Location"
        WrkSort = "CULOC, CULOC#"
    End Select

    myUTCUSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myUTCUSTQ.ReadQry()
    If Not myUTCUSTQ.IsEOF Then
      With myUTCUSTQ
        Counter = Counter + 1
        WrkListNo = ._CUACCT
        WrkCode = GetRateCode(WrkUBType)
        If WrkCode = "" Then GoTo NextRec

        CalcInterestListNo()
        CalcAssmnt()
        WrkTotal = WrkDelqPrincipal + WrkDelqInterest + WrkDelqFee + WrkDelqBond +
      WrkDelqLien + WrkAssmntLeft
        If Trim(._CUMAD1) <> "" Then
          AddrLine = MyUtils.SetAddrLine(._CUNAM1, ._CUNAM2, ._CUMAD1, ._CUMAD2,
        ._CUMCTY, ._CUMST, 0, 0, ._CUMZIP)
        Else
          AddrLine = MyUtils.SetAddrLine(._CUNAM1, ._CUNAM2, ._CUADD1, ._CUADD2,
        ._CUCITY, ._CUST, 0, 0, ._CUZIP)
        End If
        If WrkAssmntLeft + WrkDelqPrincipal <= 0 Then GoTo NextRec

Report:
        'Billing Report
        dr = ds.Tables(0).NewRow
        dr.Item("listno") = WrkListNo
        dr.Item("year") = WrkYear
        dr.Item("BillType") = WrkBillDesc
        Select Case WrkRptFmt
          Case "Edit", "Notice", "Clerk"
            dr.Item("addr1") = AddrLine(0)
            dr.Item("addr2") = AddrLine(1)
            dr.Item("addr3") = AddrLine(2)
            dr.Item("addr4") = AddrLine(3)
            dr.Item("addr5") = AddrLine(4)
          Case "Blanket"
            dr.Item("addr1") = Trim(._CUNAM1)
            dr.Item("addr2") = Trim(._CUNAM2)
        End Select
        dr.Item("vol") = ._CUVOLM
        dr.Item("page") = ._CUPAGE
        dr.Item("propdesc") = Trim(._CULOCNO) & " " & Trim(._CULOC)
        dr.Item("propdesc2") = Trim(._CUMAP)
        If WrkOrig Then
          dr.Item("assmnt") = WrkOrigAssmnt
          dr.Item("bill") = WrkBillAmt
        Else
          dr.Item("assmnt") = WrkAssmntLeft + WrkDelqPrincipal
          dr.Item("bill") = WrkDelqPrincipal
        End If
        dr.Item("interest") = WrkDelqInterest
        dr.Item("liens") = WrkDelqLien
        dr.Item("fees") = WrkDelqFee
        dr.Item("bond") = WrkDelqBond
        dr.Item("total") = WrkTotal
        dr.Item("years") = WrkYearNo + WrkYearsLeft
        ds.Tables(0).Rows.Add(dr)

        If WrkPost Then
          UpdateTXINV(WrkListNo, WrkYear, WrkUBType)
          WriteTXHST(WrkListNo, WrkYear, WrkUBType, WrkAssmntLeft + WrkDelqPrincipal)
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
      GoTo ReadNext
    End If

    myFrmProgress.Close()
    myUTCUSTQ.CloseFile()

  End Sub
  Private Sub CalcAssmnt()
    Dim MyUBCalcBill As UBCalcBill.BillAssessment
    Dim MyUBCalcBill2 As UBCalcBill.Amort

    MyUBCalcBill = New UBCalcBill.BillAssessment(myDBConnect)
    MyUBCalcBill2 = New UBCalcBill.Amort(myDBConnect)

    WrkOrigAssmnt = 0
    WrkAssmntLeft = 0
    WrkBillAmt = 0
    WrkBond = 0
    WrkTaxTotal = 0
    WrkYearsLeft = 0

    myUTCUSTAS.GetOneRecordP(WrkListNo, WrkUBType)
    If myUTCUSTAS.RecordNotFound Then Exit Sub

    With MyUBCalcBill
      .In_RateType = WrkUBType
      .In_RateCode = WrkCode
      .In_DwellUnits = myUTCUSTQ._CUAUNT
      .In_PropVal = myUTCUSTQ._CUPVAL
      .In_Footage = myUTCUSTQ._CUFOOT
      .In_Acreage = myUTCUSTQ._CUACRE
      .In_LateralFee = myUTCUSTAS._CALAT
      .In_UniformFee = myUTCUSTAS._CAUNIF
      .In_AssmntAdjust = myUTCUSTAS._CAADJ
      .In_DeferredAmt = myUTCUSTAS._CADEF
      .In_PrevBilled = myUTCUSTAS._CAAMT
      .CalcAssessment()
      WrkOrigAssmnt = MyUtils.Round(.Out_OrigBill, 2)
      WrkAssmntLeft = MyUtils.Round(.Out_AmtLeft, 2)
    End With

    WrkYearNo = myUTCUSTAS._CAPNO
    With MyUBCalcBill2
      .In_OrigBill = MyUBCalcBill.Out_OrigBill
      .In_AmtLeft = MyUBCalcBill.Out_AmtLeft
      If WrkOrig Then
        .In_Balance = 0
      Else
        .In_Balance = WrkDelqPrincipal
      End If
      .In_RateType = WrkUBType
      .In_RateCode = WrkCode
      .In_NumBills = myUTCUSTAS._CAPNO
      .In_OverrideBill = myUTCUSTAS._CAOVR
      .In_PctDeferred = myUTCUSTAS._CADEP
      .CalcAmort()
      WrkBillAmt = MyUtils.Round(.Out_Bill, 2)
      WrkBond = MyUtils.Round(.Out_Bond, 2)
      WrkYearsLeft = .Out_BillsLeft
      WrkTaxTotal = MyUtils.Round(.Out_Bill + .Out_Bond, 2)
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
  Private Sub CalcInterestListNo()
    Dim ds2 As DataSet = New DataSet
    Dim I As Integer

    WrkDelqInterest = 0
    WrkDelqFee = 0
    WrkDelqLien = 0
    WrkDelqBond = 0
    WrkDelqPrincipal = 0

    ds2 = myTXINVLK.GetViewbyList(WrkListNo, WrkTaxType, 999)
    If ds2.Tables(0).Rows.Count = 0 Then Exit Sub

    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With myCashInt
        If ds2.Tables(0).Rows(I).Item("wbal") > 0 Then
          .In_IntDate = WrkLienDate
          .In_ListNo = WrkListNo
          .In_Type = WrkTaxType
          .In_Year = ds2.Tables(0).Rows(I).Item("year")
          .CalcInterest()
          WrkDelqInterest = WrkDelqInterest + .Out_Int
          WrkDelqFee = WrkDelqFee + .Out_Fee
          WrkDelqLien = WrkDelqLien + .Out_Lien
          WrkDelqBond = WrkDelqBond + .Out_Bond
          WrkDelqPrincipal = WrkDelqPrincipal + .Out_Prin
        Else
          WrkDelqPrincipal = WrkDelqPrincipal + ds2.Tables(0).Rows(I).Item("wbal")
        End If
      End With
    Next
  End Sub
  Private Sub UpdateTXINV(ByVal List As Integer, ByVal Year As Integer, ByVal Type As String)

    myTXINV.GetOneRecordP(List, Year, Type)
    If Not myTXINV.RecordNotFound Then
      With myTXINV
        ._LIEN = "L"
        .UpdateOneRecordP()
      End With
    End If
  End Sub
  Private Sub WriteTXHST(ByVal ListNo As Integer, ByVal Year As Integer, ByVal Type As String,
  ByVal Amount As Decimal)
    Dim WrkRecID As Integer

    With myTXHST
      WrkRecID = .AutoGenKey
      .GetOneRecordP(WrkRecID)
      ._RECID = WrkRecID
      ._RCODE = "I"
      ._LISTNO = ListNo
      ._YEAR = Year
      ._TYPE = Type
      ._PAMT = Amount
      ._IAMT = 0
      ._LAMT = 0
      ._PCAMT = 0
      ._DIST = 0
      ._COMM = "LIENED" 'BchComm
      ._CORC = ""
      ._BATCHN = 0
      ._BATCHA = "L"
      ._PDATE = MyUtils.SetDBDate(MyFrmUB211B.DtPckLien.Value)
      ._CDATE = MyUtils.SetDBDate(Date.Now.Date)
      ._THINPD = ""
      ._PRF = Mid(MyUserID, 1, 10)
      ._CHDATE = MyUtils.SetDBDate(Date.Now.Date)
      ._CHTIME = MyUtils.SetDBTime(Date.Now)
      .AddOneRecordP()
    End With
  End Sub
End Module






