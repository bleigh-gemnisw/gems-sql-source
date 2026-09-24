Imports System.Collections.Generic
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXPROF As TXPROF.MyData
  Dim myCASHINT As CASHINT.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXHST As TXHST.MyData
  Dim myUTCUST As UTCUST.MyData

  Dim ds As New DataSet
  Dim dr As Data.DataRow
  Dim drinv As Data.DataRow
  Dim dsErr As New DataSet

  Dim WrkFromYear As Integer
  Dim WrkToYear As Integer
  Dim WrkIntDate As Date
  Dim WrkComplianceDate As Date
  Dim WrkMinInt As Decimal
  Dim WrkRptNo As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkPhase As Integer
  Dim WrkStatus As String
  Dim WrkOmitStatus As String
  Dim WrkOmitSuspense As Boolean
  Dim WrkOmitBanks As Boolean
  Dim WrkInGracePeriod As Boolean
  Dim WrkOmitBelow As Decimal
  Dim WrkOmitTotalBelow As Decimal
  Dim WrkOmitTotalIntBelow As Decimal
  Dim WrkOmitAbove As Decimal
  Dim WrkInvCode As String
  Dim WrkBankCode As String
  Dim WrkPostStatus As Boolean
  Dim WrkPostStatusCode As String
  Dim WrkSortBy As String
  Dim WrkCode(50) As String
  Dim WrkDesc(50) As String
  Dim WrkFamily(50) As String
  Dim WrkProfileType As String
  Dim WrkStatusDesc As String
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtReport()
    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXPROF = New TXPROF.MyData(myDBConnect)
    myCASHINT = New CASHINT.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXHST = New TXHST.MyData(myDBConnect)
    myUTCUST = New UTCUST.MyData(myDBConnect)

    WrkDistAll = False
    With MyFrmTX302B
      WrkFromYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
      WrkToYear = MyUtils.CnvSng(.TxtToGLYear.Text)
      WrkIntDate = .DtPckInt.Value
      WrkComplianceDate = .DtPckCompliance.Value
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkDistAll = False
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
      WrkStatus = .TxtStatus.Text
      WrkOmitStatus = .TxtOmitStatus.Text
      WrkOmitBanks = .ChkOmitBanks.Checked
      If .RbPrtList.Checked Then
        WrkRptNo = 1
      End If
      If .RbPrtListStatus.Checked Then
        WrkRptNo = 6
      End If
      If .RbPrtListAddr.Checked Then
        WrkRptNo = 5
      End If
      If .RbPrtListLoc.Checked Then
        WrkRptNo = 7
      End If
      If .RbPrtStatement.Checked Then
        WrkRptNo = 2
      End If
      If .RbPrtDemand.Checked Then
        WrkRptNo = 3
      End If
      If .RbPrtWarrants.Checked Then
        WrkRptNo = 4
      End If
      If .RbPrtBalDueUB.Checked Then
        WrkRptNo = 8
      End If
      If .RbPrtShutOff.Checked Then
        WrkRptNo = 9
      End If
      WrkOmitSuspense = False
      If .ChkOmitSuspense.Checked Then
        WrkOmitSuspense = True
      End If
      WrkInGracePeriod = False
      If .ChkInGracePeriod.Checked Then
        WrkInGracePeriod = True
      End If
      WrkOmitTotalBelow = MyUtils.CnvSng(.TxtOmitTotalBelow.Text)
      WrkOmitTotalIntBelow = MyUtils.CnvSng(.TxtOmitTotalIntBelow.Text)
      WrkOmitBelow = MyUtils.CnvSng(.TxtOmitBelow.Text)
      WrkOmitAbove = MyUtils.CnvSng(.TxtOmitAbove.Text)
      WrkInvCode = .TxtInvCode.Text
      WrkBankCode = .TxtBankCode.Text
      If .RbSortSname.Checked Then
        WrkSortBy = "SName"
      End If
      If .RbSortName.Checked Then
        WrkSortBy = "Name"
      End If
      If .RbSortZip.Checked Then
        WrkSortBy = "Zip"
      End If
      If .RbSortDOB.Checked Then
        WrkSortBy = "DOB"
      End If
      If .RbSortList.Checked Then
        WrkSortBy = "List"
      End If
      If .RbSortNameList.Checked Then
        WrkSortBy = "NameList"
      End If
      If .RbSortLoc.Checked Then
        WrkSortBy = "Location"
      End If
      WrkPostStatus = .ChkPostStatus.Checked
      WrkPostStatusCode = .TxtPostStatus.Text
      WrkStatusDesc = WrkPostStatusCode & "-" & Trim(GetTXStsDesc(WrkPostStatusCode))
    End With

    If ds.Tables.Count = 0 Then
      If WrkRptNo = 9 Then
        BuildDS9()
      Else
        BuildDS()
      End If

      BuildDSErr()
    Else
      ds.Clear()
      dsErr.Clear()
    End If

    BufferType()
    '================================================
    ' ken  6/21/24 - created getdetail8 for report 8 norfolk
    '================================================
    If WrkRptNo = 8 Then
      GetDetail8()
    Else
      '      If WrkRptNo = 2 And myTOWN._TOWNBR = 219 Then 'Kensington
      '     GetCombined()
      '    Else
      GetDetail()
      '   End If
    End If
    '================================================
    ' ken  12/23/24 - report 9 - need to grand total for each account
    '================================================
    If WrkRptNo = 9 Then
      AddGrandTotalToDS()
    End If


Done:
    If ds.Tables(0).Rows.Count > 0 Then
      With ds.Tables(0).Rows(0)
        GetTXPROF(WrkProfileType, .Item("Year"), "", 0)
        WrkMinInt = myTXPROF._PRMINI
      End With
    End If

    MyCrViewer = New FrmCrViewer
    MyCrViewer.Wrkds = ds
    MyCrViewer.WrkdsErr = dsErr
    MyCrViewer.WrkRptNo = WrkRptNo
    MyCrViewer.WrkMinInt = WrkMinInt
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("SortData", Type.GetType("System.String"))
      .Columns.Add("BackTax", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("PropDesc2", Type.GetType("System.String"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
      .Columns.Add("AmtDue", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Fees", Type.GetType("System.Decimal"))
      .Columns.Add("Liens", Type.GetType("System.Decimal"))
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
      .Columns.Add("Balance", Type.GetType("System.Decimal"))
      .Columns.Add("VolPage", Type.GetType("System.String"))
      .Columns.Add("AcctID", Type.GetType("System.String"))
      .Columns.Add("Status", Type.GetType("System.String"))
      .Columns.Add("LastPaid", Type.GetType("System.String"))  'added ken
      .Columns.Add("BillNo", Type.GetType("System.Int16"))
      .Columns.Add("BillDate", Type.GetType("System.String"))    'added ken
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub BuildDS9()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("SortData", Type.GetType("System.String"))
      .Columns.Add("BackTax", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("PropDesc2", Type.GetType("System.String"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
      .Columns.Add("AmtDue", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Fees", Type.GetType("System.Decimal"))
      .Columns.Add("Liens", Type.GetType("System.Decimal"))
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
      .Columns.Add("Balance", Type.GetType("System.Decimal"))
      .Columns.Add("VolPage", Type.GetType("System.String"))
      .Columns.Add("AcctID", Type.GetType("System.String"))
      .Columns.Add("Status", Type.GetType("System.String"))
      .Columns.Add("LastPaid", Type.GetType("System.String"))  'added ken
      .Columns.Add("BillDate", Type.GetType("System.String"))    'added ken
      .Columns.Add("BillNo", Type.GetType("System.Int16"))
      .Columns.Add("Meter", Type.GetType("System.String"))
      .Columns.Add("Route", Type.GetType("System.String"))

    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub BuildDSErr()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Status", Type.GetType("System.String"))
    End With
    dsErr.Tables.Add(myTable)

  End Sub
  Private Sub GetDetail()
    Dim dsinv As DataSet = New DataSet
    Dim AddrLine() As String
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkListNo As Integer
    Dim WrkName As String
    Dim WrkName2 As String
    Dim SaveListNo As Integer
    Dim WrkInterest As Decimal
    Dim WrkBond As Decimal
    Dim WrkFee As Decimal
    Dim WrkLien As Decimal
    Dim WrkDue As Decimal
    Dim WrkTax As Decimal
    Dim WrkTXType As String()
    Dim WrkTotal As Decimal
    Dim WrkGracePeriod As Boolean
    Dim Counter As Integer
    Dim I As Integer
    Dim SaveSortData As String
    Dim Pos As Integer
    Dim Good As Boolean

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    Counter = 0
    SaveListNo = 0

    WrkQry = "icode<>'I'" & WrkAnd & "YEAR >= " & WrkFromYear & WrkAnd & "YEAR <= " & WrkToYear &
    WrkAnd & "BALD > " & WrkOmitBelow
    If Not WrkDistAll Then
      WrkQry = WrkQry & WrkAnd & "DIST=" & WrkDist
    End If
    If WrkPhase > 0 Then
      If WrkQry = String.Empty Then
        WrkQry = "PHASE = " & WrkPhase
      Else
        WrkQry = WrkQry & WrkAnd & "PHASE = " & WrkPhase
      End If
    End If

    If WrkOmitSuspense Then
      WrkQry = WrkQry & WrkAnd & "ICODE<>'S'"
    End If

    If WrkInvCode <> "" Then
      WrkQry = WrkQry & WrkAnd & "ICODE<>" & MyUtils.Quo(WrkInvCode)
    End If

    If WrkBankCode <> "" Then
      WrkQry = WrkQry & WrkAnd & "BKCD=" & MyUtils.Quo(WrkBankCode)
    End If

    MyTypes = MyFrmTX302B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    WrkSort = "TYPE, YEAR desc, DIST"
    If WrkSortBy = "NameList" Then
      WrkSort = "LIST#, TYPE, YEAR desc, DIST"
    End If

    dsinv = myTXINVQ.GetQry(WrkSort, WrkQry, 0)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    WrkProfileType = ""
    SaveSortData = ""

ReadNext:
    For I = 0 To dsinv.Tables(0).Rows.Count - 1
      dr = dsinv.Tables(0).Rows(I)
      Counter = Counter + 1
      With myTXINVQ
        .GetFieldsDr(dr)
        'Filter - Omit Unposted Zero Balances 
        If (._BALD - ._NEWPAY) < WrkOmitBelow Then
          GoTo NextRec
        End If
        'Filter - Omit Bank Coded
        If WrkOmitBanks Then
          If Trim(._BKCD) <> "" Then GoTo NextRec
        End If

        If Trim(WrkStatus) > "" Then
          Good = False
          'Filter - Include Status Codes
          If WrkStatus = String.Empty Then
            Good = True
          End If
          If Not Good And Trim(._STCD1) <> String.Empty Then
            If InStr(WrkStatus, Trim(._STCD1)) > 0 Then
              Good = True
            End If
          End If
          If Not Good And Trim(._STCD2) <> String.Empty Then
            If InStr(WrkStatus, Trim(._STCD2)) > 0 Then
              Good = True
            End If
          End If
          If Not Good And Trim(._STCD3) <> String.Empty Then
            If InStr(WrkStatus, Trim(._STCD3)) > 0 Then
              Good = True
            End If
          End If
          If Not Good And Trim(._STCD4) <> String.Empty Then
            If InStr(WrkStatus, Trim(._STCD4)) > 0 Then
              Good = True
            End If
          End If
          If Not Good And Trim(._STCD5) <> String.Empty Then
            If InStr(WrkStatus, Trim(._STCD5)) > 0 Then
              Good = True
            End If
          End If
          If Not Good Then GoTo NextRec
        End If
        'Filter - Omit Status Codes
        If Trim(WrkOmitStatus) > "" Then
          Pos = 0
          If Trim(._STCD1) <> "" Then
            Pos = InStr(1, WrkOmitStatus, Trim(._STCD1), 1)
          End If
          If Pos = 0 And Trim(._STCD2) <> "" Then
            Pos = InStr(1, WrkOmitStatus, Trim(._STCD2), 1)
          End If
          If Pos = 0 And Trim(._STCD3) <> "" Then
            Pos = InStr(1, WrkOmitStatus, Trim(._STCD3), 1)
          End If
          If Pos = 0 And Trim(._STCD4) <> "" Then
            Pos = InStr(1, WrkOmitStatus, Trim(._STCD4), 1)
          End If
          If Pos = 0 And Trim(._STCD5) <> "" Then
            Pos = InStr(1, WrkOmitStatus, Trim(._STCD5), 1)
          End If
          If Pos > 0 Then GoTo NextRec
        End If

        WrkListNo = ._LISTNo
        If WrkSortBy = "NameList" And SaveListNo <> WrkListNo Or WrkSortBy <> "NameList" Then
          WrkName = Trim(._NAME)
          WrkName2 = Trim(._SNAME)
          If InStr(._SNAME, "N/O ") > 0 Then
            WrkName = Replace(Trim(._SNAME), "N/O ", "")
            WrkName2 = ""
          End If
          If InStr(._SNAME, " N/O") > 0 Then
            WrkName = Replace(Trim(._SNAME), " N/O", "")
            WrkName2 = ""
          End If
          SaveListNo = WrkListNo
        End If
        dr = ds.Tables(0).NewRow
        'comment out 2/4/25: ken 12/26/24 add listno to sort zip And name
        Select Case WrkSortBy
          Case "Zip"
            dr.Item("sortdata") = Format(._ZIP5, "00000") & " " & WrkName '& Format(._LISTNo, "000000")
          Case "Name"
            dr.Item("sortdata") = WrkName '& Format(._LISTNo, "000000")
          Case "SName"
            dr.Item("sortdata") = WrkName & " " & WrkName2 & " " & Trim(._ADD1)
          Case "DOB"
            dr.Item("sortdata") = WrkName & " " & Trim(._ADD1) & " " & ._DOB
          Case "List"
            dr.Item("sortdata") = Format(._LISTNo, "000000")
          Case "NameList"
            dr.Item("sortdata") = WrkName & Format(._LISTNo, "000000")
          Case "Location"
            dr.Item("sortdata") = ._LOC & ._LOCNo
        End Select
        If ._ICODE = "B" Then
          dr.Item("backtax") = "B"
        Else
          dr.Item("backtax") = String.Empty
        End If
        dr.Item("listno") = ._LISTNo
        If WrkProfileType = "" Then
          WrkProfileType = ._TYPE
        End If
        dr.Item("year") = ._YEAR
        WrkTXType = LookupType(._TYPE)
        dr.Item("type") = ._TYPE
        dr.Item("typedesc") = WrkTXType(0)
        If SaveSortData <> dr.Item("sortdata") Then
          AddrLine = MyUtils.SetAddrLine(WrkName, WrkName2, ._ADD1, ._ADD2,
        ._CITY, ._STATE, ._ZIP5, ._ZIP4)
        End If
        SaveSortData = dr.Item("sortdata")
        dr.Item("addr1") = AddrLine(0)
        dr.Item("addr2") = AddrLine(1)
        dr.Item("addr3") = AddrLine(2)
        dr.Item("addr4") = AddrLine(3)
        dr.Item("addr5") = AddrLine(4)

        Select Case WrkTXType(1) 'Family
          Case "M", "S"
            dr.Item("propdesc") = Trim(._MAKE) & " " & Trim(._MVYR) & " " & ._IMVREG
            dr.Item("propdesc2") = ._IMVIDNo
          Case Else
            dr.Item("propdesc") = Trim(._LOCNo) & " " & ._LOC
            dr.Item("propdesc2") = ""
        End Select
        'If myTOWN._TOWNBR = 219 And {"S", "W"}.Contains(._TYPE) Then
        If myTOWN._TOWNBR = 219 AndAlso (._TYPE = "S" OrElse ._TYPE = "W") Then
          CalcInterest_219SW(._LISTNo, ._TYPE, ._YEAR, WrkInterest, WrkFee, WrkLien, WrkBond, WrkTax, WrkDue, WrkGracePeriod, 0, 0, 0, 0)
        Else
          CalcInterest(._LISTNo, ._TYPE, ._YEAR, WrkInterest, WrkFee, WrkLien, WrkBond, WrkTax, WrkDue, WrkGracePeriod, 0, 0, 0, 0)
        End If
        'Filter - Omit below amount due 
        If WrkDue < WrkOmitBelow Or WrkDue = 0 Then
          GoTo NextRec
        End If
        'Filter - Omit above amount due 
        If WrkOmitAbove > 0 And WrkDue > WrkOmitAbove Then
          GoTo NextRec
        End If
        'Filter - Omit In Grace Period unless selected
        If Not WrkInGracePeriod And WrkGracePeriod Then
          GoTo NextRec
        End If

        dr.Item("amtdue") = WrkTax
        dr.Item("Interest") = Format(WrkInterest, "fixed")
        dr.Item("fees") = WrkFee
        dr.Item("liens") = Format(WrkLien, "fixed")
        dr.Item("bond") = Format(WrkBond, "fixed")
        WrkTotal = WrkTax + WrkInterest + WrkFee + WrkLien + WrkBond
        dr.Item("total") = Format(WrkTotal, "fixed")
        dr.Item("Balance") = Format(WrkDue, "fixed")
        dr.Item("volpage") = Trim(._VOL) & " " & Trim(._IPAGE)
        dr.Item("AcctId") = Mid(._YEAR, 3, 2) & ._TYPE & ._LISTNo
        dr.Item("Status") = ._STCD1 & " " & ._STCD2 & " " & ._STCD3 & " " & ._STCD4 & " " & ._STCD5
        ds.Tables(0).Rows.Add(dr)

        If WrkRptNo = 9 Then
          myUTCUST.GetOneRecordP(._LISTNo)
          If myUTCUST.RecordNotFound = False Then
            dr.Item("Meter") = myUTCUST._CUMETN
            dr.Item("Route") = myUTCUST._CUROUT
          Else
            dr.Item("Meter") = ""
            dr.Item("Route") = ""
          End If
        End If
      End With

      ' if winsted 162 and demand and omittotal > 0 then we want to not post this as we will need to post at the end 
      If myTOWN._TOWNBR = 162 And WrkRptNo = 3 And WrkOmitTotalBelow > 0 Then GoTo NextRec
      If WrkPostStatus Then
        PostStatus()
      End If

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
    Next

    ' Winsted - if demand notice  and they enter an omit total amount we want to remove the records from the dataset and also if postint status post after removed
    If WrkRptNo = 3 And myTOWN._TOWNBR = 162 And WrkOmitTotalBelow > 0 Then
      ds = FilterDatasetByBalance(ds, WrkOmitTotalBelow)
      If WrkPostStatus Then
        PostStatusFiltered(ds)
      End If
    End If
    ' Kensington if they enter an omit total amount we want to remove the records from the dataset
    If myTOWN._TOWNBR = 219 And WrkOmitTotalIntBelow > 0 Then
      ds = FilterDatasetByInterest(ds, WrkOmitTotalIntBelow)
    End If

    myFrmProgress.Close()
    myTXINVQ.CloseFile()
    myTXPROF.CloseFile()
    myUTCUST.CloseFile()
  End Sub
  Private Sub AddGrandTotalToDS()
    ' Access the DataTable from the globally defined DataSet
    Dim myTable As DataTable = ds.Tables("mytable")

    ' Ensure the GrandTotal column exists
    If Not myTable.Columns.Contains("GrandTotal") Then
      myTable.Columns.Add("GrandTotal", GetType(Decimal))
    End If

    ' Reset the GrandTotal column
    For Each row As DataRow In myTable.Rows
      row("GrandTotal") = 0
    Next

    ' Create a dictionary to store totals by SortData
    Dim groupTotals As New Dictionary(Of String, Decimal)

    ' First Pass: Calculate totals for each SortData
    For Each row As DataRow In myTable.Rows
      '      Dim listno As String = If(IsDBNull(row("listno")), "", row("listno").ToString().Trim())
      Dim sortdata As String = If(IsDBNull(row("sortdata")), "", row("sortdata"))
      Dim total As Decimal = If(IsDBNull(row("Total")), 0D, Convert.ToDecimal(row("Total")))

      If groupTotals.ContainsKey(sortdata) Then
        groupTotals(sortdata) += total
      Else
        groupTotals(sortdata) = total
      End If
    Next

    ' Second Pass: Assign group totals to the GrandTotal column for each row
    For Each row As DataRow In myTable.Rows
      '      Dim listno As String = If(IsDBNull(row("listno")), "", row("listno").ToString().Trim())
      Dim sortdata As String = If(IsDBNull(row("sortdata")), "", row("sortdata"))

      If groupTotals.ContainsKey(sortdata) Then
        row("GrandTotal") = groupTotals(sortdata)
      End If
    Next
  End Sub
  Private Sub GetDetail8()
    Dim dsinv As DataSet = New DataSet
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkInterest As Decimal
    Dim WrkBond As Decimal
    Dim WrkFee As Decimal
    Dim WrkLien As Decimal
    Dim WrkDue As Decimal
    Dim WrkTax As Decimal
    Dim WrkGracePeriod As Boolean
    Dim WrkTax1 As Decimal
    Dim WrkInt1 As Decimal
    Dim WrkIntCalc1 As Decimal
    Dim WrkFee1 As Decimal
    Dim WrkLien1 As Decimal
    Dim WrkBond1 As Decimal
    Dim WrkTotal1 As Decimal
    Dim WrkBillDate1 As String
    Dim WrkTax2 As Decimal
    Dim WrkInt2 As Decimal
    Dim WrkIntCalc2 As Decimal
    Dim WrkFee2 As Decimal
    Dim WrkLien2 As Decimal
    Dim WrkBond2 As Decimal
    Dim WrkTotal2 As Decimal
    Dim WrkBillDate2 As String
    Dim WrkTax3 As Decimal
    Dim WrkInt3 As Decimal
    Dim WrkIntCalc3 As Decimal
    Dim WrkFee3 As Decimal
    Dim WrkLien3 As Decimal
    Dim WrkBond3 As Decimal
    Dim WrkTotal3 As Decimal
    Dim WrkBillDate3 As String
    Dim WrkTax4 As Decimal
    Dim WrkInt4 As Decimal
    Dim WrkIntCalc4 As Decimal
    Dim WrkFee4 As Decimal
    Dim WrkLien4 As Decimal
    Dim WrkBond4 As Decimal
    Dim WrkTotal4 As Decimal
    Dim WrkBillDate4 As String
    Dim Counter As Integer
    Dim I As Integer
    Dim SaveSortData As String
    Dim SaveList As Integer
    Dim SaveYear As Integer
    Dim Pos As Integer
    Dim Good As Boolean

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    Counter = 0

    WrkQry = "icode<>'I'" & WrkAnd & "YEAR >= " & WrkFromYear & WrkAnd & "YEAR <= " & WrkToYear &
  WrkAnd & "BALD > " & WrkOmitBelow

    If Not WrkDistAll Then
      WrkQry = WrkQry & WrkAnd & "DIST=" & WrkDist
    End If
    If WrkPhase > 0 Then
      If WrkQry = String.Empty Then
        WrkQry = "PHASE = " & WrkPhase
      Else
        WrkQry = WrkQry & WrkAnd & "PHASE = " & WrkPhase
      End If
    End If

    If WrkOmitSuspense Then
      WrkQry = WrkQry & WrkAnd & "ICODE<>'S'"
    End If

    If WrkInvCode <> "" Then
      WrkQry = WrkQry & WrkAnd & "ICODE<>" & MyUtils.Quo(WrkInvCode)
    End If

    If WrkBankCode <> "" Then
      WrkQry = WrkQry & WrkAnd & "BKCD=" & MyUtils.Quo(WrkBankCode)
    End If

    MyTypes = MyFrmTX302B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    'WrkQry = WrkQry & WrkAnd & " list#=800613" 'Testing
    WrkSort = "LIST#, YEAR, TYPE , DIST"

    dsinv = myTXINVQ.GetQry(WrkSort, WrkQry, 0)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    WrkProfileType = ""
    SaveSortData = ""
    WrkBillDate1 = ""
    WrkBillDate2 = ""
    WrkBillDate3 = ""
    WrkBillDate4 = ""

ReadNext:
    For I = 0 To dsinv.Tables(0).Rows.Count - 1
      drinv = dsinv.Tables(0).Rows(I)
      Counter = Counter + 1
      With myTXINVQ
        If SaveList > 0 Then
          If SaveList <> drinv.Item("list#") Or SaveYear <> drinv.Item("year") Then
            'MK 7/30/25 Begin 
            WrkTotal1 = WrkTax1 + WrkInt1 + WrkFee1 + WrkLien1 + WrkBond1
            If WrkTotal1 > 0 Then
              'MK 7/30/25 End 
              '1st bill
              dr = ds.Tables(0).NewRow
              WriteDrBase()
              dr.Item("LastPaid") = Format(MyUtils.GetDBDate(._TXIDT), "short date").ToString
              If dr.Item("LastPaid") = "1/1/0001" Then
                dr.Item("LastPaid") = ""
              End If
              dr.Item("amtdue") = WrkTax1
              dr.Item("Interest") = Format(WrkInt1, "fixed")
              'MK 7/30/25 Begin 
              'WrkTotal1 = WrkTax1 + WrkInt1 + WrkFee1 + WrkLien1 + WrkBond1
              'MK 7/30/25 End 
              dr.Item("fees") = WrkFee1
              dr.Item("liens") = WrkLien1
              dr.Item("bond") = WrkBond1
              dr.Item("total") = Format(WrkTotal1, "fixed")
              dr.Item("BillNo") = 1
              dr.Item("BillDate") = WrkBillDate1
              ds.Tables(0).Rows.Add(dr)
              'MK 7/30/25 Begin 
            End If
            WrkTotal2 = WrkTax2 + WrkInt2 + WrkFee2 + WrkLien2 + WrkBond2
            If WrkTotal2 > 0 Then
              'MK 7/30/25 End 
              '2nd bill
              dr = ds.Tables(0).NewRow
              WriteDrBase()
              dr.Item("LastPaid") = ""
              dr.Item("amtdue") = WrkTax2
              dr.Item("Interest") = Format(WrkInt2, "fixed")
              'MK 7/30/25 Begin 
              'WrkTotal2 = WrkTax2 + WrkInt2 + WrkFee2 + WrkLien2 + WrkBond2
              'MK 7/30/25 End 
              dr.Item("fees") = WrkFee2
              dr.Item("liens") = WrkLien2
              dr.Item("bond") = WrkBond2
              dr.Item("total") = Format(WrkTotal2, "fixed")
              dr.Item("BillNo") = 2
              dr.Item("BillDate") = WrkBillDate2
              ds.Tables(0).Rows.Add(dr)
              '3rd bill
              'MK 7/30/25 Begin 
            End If
            WrkTotal3 = WrkTax3 + WrkInt3 + WrkFee3 + WrkLien3 + WrkBond3
            If WrkTotal3 > 0 Then
              'If WrkBillDate3 <> "" Then
              'MK 7/30/25 End 
              dr = ds.Tables(0).NewRow
              WriteDrBase()
              dr.Item("LastPaid") = ""
              dr.Item("amtdue") = WrkTax3
              dr.Item("Interest") = Format(WrkInt3, "fixed")
              'MK 7/30/25 Begin 
              'WrkTotal3 = WrkTax3 + WrkInt3 + WrkFee3 + WrkLien3 + WrkBond3
              'MK 7/30/25 End 
              dr.Item("fees") = WrkFee3
              dr.Item("liens") = WrkLien3
              dr.Item("bond") = WrkBond3
              dr.Item("total") = Format(WrkTotal3, "fixed")
              dr.Item("BillNo") = 3
              dr.Item("BillDate") = WrkBillDate3
              ds.Tables(0).Rows.Add(dr)
            End If
            '4th bill
            'MK 7/30/25 Begin 
            WrkTotal4 = WrkTax4 + WrkInt4 + WrkFee4 + WrkLien4 + WrkBond4
            If WrkTotal4 > 0 Then
              '  If WrkBillDate4 <> "" Then
              'MK 7/30/25 End 
              dr = ds.Tables(0).NewRow
              WriteDrBase()
              dr.Item("LastPaid") = ""
              dr.Item("amtdue") = WrkTax4
              dr.Item("Interest") = Format(WrkInt4, "fixed")
              'MK 7/30/25 Begin 
              'WrkTotal4 = WrkTax4 + WrkInt4 + WrkFee4 + WrkLien4 + WrkBond4
              'MK 7/30/25 End 
              dr.Item("fees") = WrkFee4
              dr.Item("liens") = WrkLien4
              dr.Item("bond") = WrkBond4
              dr.Item("total") = Format(WrkTotal4, "fixed")
              dr.Item("BillNo") = 4
              dr.Item("BillDate") = WrkBillDate4
              ds.Tables(0).Rows.Add(dr)
            End If
            WrkTax1 = 0
              WrkInt1 = 0
              WrkFee1 = 0
              WrkLien1 = 0
              WrkBond1 = 0
              WrkTax2 = 0
              WrkInt2 = 0
              WrkFee2 = 0
              WrkLien2 = 0
              WrkBond2 = 0
              WrkTax3 = 0
              WrkInt3 = 0
              WrkFee3 = 0
              WrkLien3 = 0
              WrkBond3 = 0
              WrkTax4 = 0
              WrkInt4 = 0
              WrkFee4 = 0
              WrkLien4 = 0
              WrkBond4 = 0
            End If
          End If

        .GetFieldsDr(drinv)
        SaveList = ._LISTNo
        SaveYear = ._YEAR
        'Filter - Omit Unposted Zero Balances 
        If (._BALD - ._NEWPAY) < WrkOmitBelow Then
          GoTo NextRec
        End If
        'Filter - Omit Bank Coded
        If WrkOmitBanks Then
          If Trim(._BKCD) <> "" Then GoTo NextRec
        End If

        If Trim(WrkStatus) > "" Then
          Good = False
          'Filter - Include Status Codes
          If WrkStatus = String.Empty Then
            Good = True
          End If
          If Not Good And Trim(._STCD1) <> String.Empty Then
            If InStr(WrkStatus, Trim(._STCD1)) > 0 Then
              Good = True
            End If
          End If
          If Not Good And Trim(._STCD2) <> String.Empty Then
            If InStr(WrkStatus, Trim(._STCD2)) > 0 Then
              Good = True
            End If
          End If
          If Not Good And Trim(._STCD3) <> String.Empty Then
            If InStr(WrkStatus, Trim(._STCD3)) > 0 Then
              Good = True
            End If
          End If
          If Not Good And Trim(._STCD4) <> String.Empty Then
            If InStr(WrkStatus, Trim(._STCD4)) > 0 Then
              Good = True
            End If
          End If
          If Not Good And Trim(._STCD5) <> String.Empty Then
            If InStr(WrkStatus, Trim(._STCD5)) > 0 Then
              Good = True
            End If
          End If
          If Not Good Then GoTo NextRec
        End If
        'Filter - Omit Status Codes
        If Trim(WrkOmitStatus) > "" Then
          Pos = 0
          If Trim(._STCD1) <> "" Then
            Pos = InStr(1, WrkOmitStatus, Trim(._STCD1), 1)
          End If
          If Pos = 0 And Trim(._STCD2) <> "" Then
            Pos = InStr(1, WrkOmitStatus, Trim(._STCD2), 1)
          End If
          If Pos = 0 And Trim(._STCD3) <> "" Then
            Pos = InStr(1, WrkOmitStatus, Trim(._STCD3), 1)
          End If
          If Pos = 0 And Trim(._STCD4) <> "" Then
            Pos = InStr(1, WrkOmitStatus, Trim(._STCD4), 1)
          End If
          If Pos = 0 And Trim(._STCD5) <> "" Then
            Pos = InStr(1, WrkOmitStatus, Trim(._STCD5), 1)
          End If
          If Pos > 0 Then GoTo NextRec
        End If

        'If myTOWN._TOWNBR = 219 And {"S", "W"}.Contains(._TYPE) Then
        If myTOWN._TOWNBR = 219 AndAlso (._TYPE = "S" OrElse ._TYPE = "W") Then
          CalcInterest_219SW(._LISTNo, ._TYPE, ._YEAR, WrkInterest, WrkFee, WrkLien, WrkBond, WrkTax, WrkDue,
           WrkGracePeriod, WrkIntCalc1, WrkIntCalc2, WrkIntCalc3, WrkIntCalc4)
        Else
            CalcInterest(._LISTNo, ._TYPE, ._YEAR, WrkInterest, WrkFee, WrkLien, WrkBond, WrkTax, WrkDue,
           WrkGracePeriod, WrkIntCalc1, WrkIntCalc2, WrkIntCalc3, WrkIntCalc4)
        End If
        'Filter - Omit below amount due 
        If WrkDue < WrkOmitBelow Or WrkDue = 0 Then
          GoTo NextRec
        End If
        'Filter - Omit above amount due 
        If WrkOmitAbove > 0 And WrkDue > WrkOmitAbove Then
          GoTo NextRec
        End If
        'Filter - Omit In Grace Period unless selected
        If Not WrkInGracePeriod And WrkGracePeriod Then
          GoTo NextRec
        End If
        WrkMinInt = myCASHINT.Out_ProfMinInt
        '1st bill
        WrkTax1 = WrkTax1 + myCASHINT.Out_Prin1
        WrkInt1 = WrkInt1 + WrkIntCalc1
        WrkFee1 = WrkFee1 + myCASHINT.Out_Fee1
        WrkLien1 = WrkLien1 + myCASHINT.Out_Lien1
        WrkBond1 = WrkBond1 + 0
        WrkBillDate1 = Format(myCASHINT.Out_profDate1, "M/d/yyyy").ToString
        '2nd bill
        WrkTax2 = WrkTax2 + myCASHINT.Out_Prin2
        WrkInt2 = WrkInt2 + WrkIntCalc2
        WrkFee2 = WrkFee2 + myCASHINT.Out_Fee2
        WrkLien2 = WrkLien2 + myCASHINT.Out_Lien2
        WrkBond2 = WrkBond2 + 0
        WrkBillDate2 = Format(myCASHINT.Out_profDate2, "M/d/yyyy").ToString
        ' 3rd bill
        WrkTax3 = WrkTax3 + myCASHINT.Out_Prin3
        WrkInt3 = WrkInt3 + WrkIntCalc3
        WrkFee3 = WrkFee3 + myCASHINT.Out_Fee3
        WrkLien3 = WrkLien3 + myCASHINT.Out_Lien3
        WrkBond3 = WrkBond3 + 0D ' No bond amount added
        WrkBillDate3 = Format(myCASHINT.Out_profDate3, "M/d/yyyy").ToString()
        ' 4th bill
        WrkTax4 = WrkTax4 + myCASHINT.Out_Prin4
        WrkInt4 = WrkInt4 + WrkIntCalc4
        WrkFee4 = WrkFee4 + myCASHINT.Out_Fee4
        WrkLien4 = WrkLien4 + myCASHINT.Out_Lien4
        WrkBond4 = WrkBond4 + 0D ' No bond amount added
        WrkBillDate4 = Format(myCASHINT.Out_profDate4, "M/d/yyyy").ToString()
      End With

      If WrkPostStatus Then
        PostStatus()
      End If

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
    Next

    If SaveList > 0 Then
      'MK 9/25/25 Begin
      WrkTotal1 = WrkTax1 + WrkInt1 + WrkFee1 + WrkLien1 + WrkBond1
      If WrkTotal1 > 0 Then
        'MK 9/25/25 End
        '1st bill
        dr = ds.Tables(0).NewRow
        WriteDrBase()
        dr.Item("amtdue") = WrkTax1
        dr.Item("Interest") = Format(WrkInt1, "fixed")
        WrkTotal1 = WrkTax1 + WrkInt1 + WrkFee1 + WrkLien1 + WrkBond1
        dr.Item("fees") = WrkFee1
        dr.Item("liens") = WrkLien1
        dr.Item("bond") = WrkBond1
        dr.Item("total") = Format(WrkTotal1, "fixed")
        dr.Item("BillNo") = 1
        dr.Item("BillDate") = WrkBillDate1
        ds.Tables(0).Rows.Add(dr)
        'MK 9/25/25 Begin
      End If
      'MK 9/25/25 End

      '2nd bill
      WrkTotal2 = WrkTax2 + WrkInt2 + WrkFee2 + WrkLien2 + WrkBond2
        If WrkTotal2 > 0 Then
          dr = ds.Tables(0).NewRow
          WriteDrBase()
        dr.Item("LastPaid") = ""
        dr.Item("amtdue") = WrkTax2
        dr.Item("Interest") = Format(WrkInt2, "fixed")
        WrkTotal2 = WrkTax2 + WrkInt2 + WrkFee2 + WrkLien2 + WrkBond2
        dr.Item("fees") = WrkFee2
        dr.Item("liens") = WrkLien2
        dr.Item("bond") = WrkBond2
        dr.Item("total") = Format(WrkTotal2, "fixed")
        dr.Item("BillNo") = 2
        dr.Item("BillDate") = WrkBillDate2
        ds.Tables(0).Rows.Add(dr)
        'MK 9/25/25 Begin
      End If
      'MK 9/25/25 End

      '3rd bill
      'MK 9/25/25 Begin
      WrkTotal3 = WrkTax3 + WrkInt3 + WrkFee3 + WrkLien3 + WrkBond3
      If WrkTotal3 > 0 Then
        '  If WrkBillDate3 <> "" Then
        'MK 9/25/25 End
        dr = ds.Tables(0).NewRow
        WriteDrBase()
        dr.Item("LastPaid") = ""
        dr.Item("amtdue") = WrkTax3
        dr.Item("Interest") = Format(WrkInt3, "fixed")
        WrkTotal3 = WrkTax3 + WrkInt3 + WrkFee3 + WrkLien3 + WrkBond3
        dr.Item("fees") = WrkFee3
        dr.Item("liens") = WrkLien3
        dr.Item("bond") = WrkBond3
        dr.Item("total") = Format(WrkTotal3, "fixed")
        dr.Item("BillNo") = 3
        dr.Item("BillDate") = WrkBillDate3
        ds.Tables(0).Rows.Add(dr)
      End If
      'MK 9/25/25 Begin
    End If
    'MK 9/25/25 End

    '4th bill
    'MK 9/25/25 Begin
    WrkTotal4 = WrkTax4 + WrkInt4 + WrkFee4 + WrkLien4 + WrkBond4
    If WrkTotal4 > 0 Then
      'If WrkBillDate4 <> "" Then
      'MK 9/25/25 End
      dr = ds.Tables(0).NewRow
      WriteDrBase()
      dr.Item("LastPaid") = ""
      dr.Item("amtdue") = WrkTax4
      dr.Item("Interest") = Format(WrkInt4, "fixed")
      WrkTotal4 = WrkTax4 + WrkInt4 + WrkFee4 + WrkLien4 + WrkBond4
      dr.Item("fees") = WrkFee4
      dr.Item("liens") = WrkLien4
      dr.Item("bond") = WrkBond4
      dr.Item("total") = Format(WrkTotal4, "fixed")
      dr.Item("BillNo") = 4
      dr.Item("BillDate") = WrkBillDate4
      ds.Tables(0).Rows.Add(dr)
      'MK 9/25/25 Begin
    End If
    'MK 9/25/25 End
    myFrmProgress.Close()

    myTXINVQ.CloseFile()
    myTXPROF.CloseFile()
    myUTCUST.CloseFile()
  End Sub
  '  Private Sub GetCombined()
  '    Dim dsinv As DataSet = New DataSet
  '    Dim WrkQry As String
  '    Dim WrkSort As String
  '    Dim WrkInt As Decimal
  '    Dim WrkBond As Decimal
  '    Dim WrkFee As Decimal
  '    Dim WrkLien As Decimal
  '    Dim WrkDue As Decimal
  '    Dim WrkTax As Decimal
  '    Dim WrkTInt As Decimal
  '    Dim WrkTIntOrig As Decimal
  '    Dim WrkTBond As Decimal
  '    Dim WrkTFee As Decimal
  '    Dim WrkTLien As Decimal
  '    Dim WrkTTax As Decimal
  '    Dim WrkTotal As Decimal
  '    Dim WrkGracePeriod As Boolean
  '    Dim Counter As Integer
  '    Dim I As Integer
  '    Dim SaveSortData As String
  '    Dim SaveList As Integer
  '    Dim SaveYear As Integer
  '    Dim Pos As Integer
  '    Dim Good As Boolean

  '    If MyServer = "DB2" Then
  '      WrkAnd = " *and "
  '      WrkOr = " *or "
  '    Else
  '      WrkAnd = " and "
  '      WrkOr = " or "
  '    End If

  '    Counter = 0

  '    WrkQry = "icode<>'I'" & WrkAnd & "YEAR >= " & WrkFromYear & WrkAnd & "YEAR <= " & WrkToYear &
  '  WrkAnd & "BALD > " & WrkOmitBelow

  '    If Not WrkDistAll Then
  '      WrkQry = WrkQry & WrkAnd & "DIST=" & WrkDist
  '    End If
  '    If WrkPhase > 0 Then
  '      If WrkQry = String.Empty Then
  '        WrkQry = "PHASE = " & WrkPhase
  '      Else
  '        WrkQry = WrkQry & WrkAnd & "PHASE = " & WrkPhase
  '      End If
  '    End If

  '    If WrkOmitSuspense Then
  '      WrkQry = WrkQry & WrkAnd & "ICODE<>'S'"
  '    End If

  '    If WrkInvCode <> "" Then
  '      WrkQry = WrkQry & WrkAnd & "ICODE<>" & MyUtils.Quo(WrkInvCode)
  '    End If

  '    If WrkBankCode <> "" Then
  '      WrkQry = WrkQry & WrkAnd & "BKCD=" & MyUtils.Quo(WrkBankCode)
  '    End If

  '    MyTypes = MyFrmTX302B.TxtTypes.Text
  '    If MyTypes <> "" Then
  '      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
  '    End If

  '    WrkSort = "LIST#, YEAR, TYPE , DIST"
  '    dsinv = myTXINVQ.GetQry(WrkSort, WrkQry, 0)

  '    myFrmProgress = New FrmProgress
  '    myFrmProgress.Show()
  '    myFrmProgress.Refresh()
  '    Application.DoEvents()
  '    WrkProfileType = ""
  '    SaveSortData = ""

  'ReadNext:
  '    For I = 0 To dsinv.Tables(0).Rows.Count - 1
  '      drinv = dsinv.Tables(0).Rows(I)
  '      Counter = Counter + 1
  '      With myTXINVQ
  '        If SaveList > 0 Then
  '          If SaveList <> drinv.Item("list#") Or SaveYear <> drinv.Item("year") Then
  '            dr = ds.Tables(0).NewRow
  '            WriteDrBase()
  '            dr.Item("LastPaid") = Format(MyUtils.GetDBDate(._TXIDT), "short date").ToString
  '            If dr.Item("LastPaid") = "1/1/0001" Then
  '              dr.Item("LastPaid") = ""
  '            End If
  '            dr.Item("amtdue") = WrkTTax
  '            If WrkTInt <> WrkTIntOrig And WrkTIntOrig < WrkMinInt Then
  '              dr.Item("Interest") = Format(WrkMinInt, "fixed")
  '              WrkTotal = WrkTTax + WrkMinInt + WrkTFee + WrkTLien + WrkTBond
  '            Else
  '              dr.Item("Interest") = Format(WrkTIntOrig, "fixed")
  '              WrkTotal = WrkTTax + WrkTIntOrig + WrkTFee + WrkTLien + WrkTBond
  '            End If
  '            dr.Item("fees") = WrkTFee
  '            dr.Item("liens") = WrkTLien
  '            dr.Item("bond") = WrkTBond
  '            dr.Item("total") = Format(WrkTotal, "fixed")
  '            ds.Tables(0).Rows.Add(dr)
  '            WrkTTax = 0
  '            WrkTInt = 0
  '            WrkTIntOrig = 0
  '            WrkTFee = 0
  '            WrkTLien = 0
  '            WrkTBond = 0
  '          End If
  '        End If

  '        .GetFieldsDr(drinv)
  '        SaveList = ._LISTNo
  '        SaveYear = ._YEAR
  '        'Filter - Omit Unposted Zero Balances 
  '        If (._BALD - ._NEWPAY) < WrkOmitBelow Then
  '          GoTo NextRec
  '        End If
  '        'Filter - Omit Bank Coded
  '        If WrkOmitBanks Then
  '          If Trim(._BKCD) <> "" Then GoTo NextRec
  '        End If

  '        If Trim(WrkStatus) > "" Then
  '          Good = False
  '          'Filter - Include Status Codes
  '          If WrkStatus = String.Empty Then
  '            Good = True
  '          End If
  '          If Not Good And Trim(._STCD1) <> String.Empty Then
  '            If InStr(WrkStatus, Trim(._STCD1)) > 0 Then
  '              Good = True
  '            End If
  '          End If
  '          If Not Good And Trim(._STCD2) <> String.Empty Then
  '            If InStr(WrkStatus, Trim(._STCD2)) > 0 Then
  '              Good = True
  '            End If
  '          End If
  '          If Not Good And Trim(._STCD3) <> String.Empty Then
  '            If InStr(WrkStatus, Trim(._STCD3)) > 0 Then
  '              Good = True
  '            End If
  '          End If
  '          If Not Good And Trim(._STCD4) <> String.Empty Then
  '            If InStr(WrkStatus, Trim(._STCD4)) > 0 Then
  '              Good = True
  '            End If
  '          End If
  '          If Not Good And Trim(._STCD5) <> String.Empty Then
  '            If InStr(WrkStatus, Trim(._STCD5)) > 0 Then
  '              Good = True
  '            End If
  '          End If
  '          If Not Good Then GoTo NextRec
  '        End If
  '        'Filter - Omit Status Codes
  '        If Trim(WrkOmitStatus) > "" Then
  '          Pos = 0
  '          If Trim(._STCD1) <> "" Then
  '            Pos = InStr(1, WrkOmitStatus, Trim(._STCD1), 1)
  '          End If
  '          If Pos = 0 And Trim(._STCD2) <> "" Then
  '            Pos = InStr(1, WrkOmitStatus, Trim(._STCD2), 1)
  '          End If
  '          If Pos = 0 And Trim(._STCD3) <> "" Then
  '            Pos = InStr(1, WrkOmitStatus, Trim(._STCD3), 1)
  '          End If
  '          If Pos = 0 And Trim(._STCD4) <> "" Then
  '            Pos = InStr(1, WrkOmitStatus, Trim(._STCD4), 1)
  '          End If
  '          If Pos = 0 And Trim(._STCD5) <> "" Then
  '            Pos = InStr(1, WrkOmitStatus, Trim(._STCD5), 1)
  '          End If
  '          If Pos > 0 Then GoTo NextRec
  '        End If

  '        CalcInterest(._LISTNo, ._TYPE, ._YEAR, WrkInt, WrkFee, WrkLien, WrkBond, WrkTax, WrkDue, WrkGracePeriod)
  '        'Filter - Omit below amount due 
  '        If WrkDue < WrkOmitBelow Or WrkDue = 0 Then
  '          GoTo NextRec
  '        End If
  '        'Filter - Omit above amount due 
  '        If WrkOmitAbove > 0 And WrkDue > WrkOmitAbove Then
  '          GoTo NextRec
  '        End If
  '        'Filter - Omit In Grace Period unless selected
  '        If Not WrkInGracePeriod And WrkGracePeriod Then
  '          GoTo NextRec
  '        End If
  '        WrkMinInt = myCASHINT.Out_ProfMinInt
  '        WrkTTax = WrkTTax + WrkTax
  '        WrkTInt = WrkTInt + WrkInt
  '        WrkTIntOrig = WrkTIntOrig + myCASHINT.Out_IntOrig
  '        WrkTFee = WrkTFee + WrkFee
  '        WrkTLien = WrkTLien + WrkLien
  '        WrkTBond = WrkTBond + 0
  '      End With

  '      If WrkPostStatus Then
  '        PostStatus()
  '      End If

  'NextRec:
  '      With myFrmProgress
  '        WrkPct = (Counter / 10) Mod 100
  '        If SavePct <> WrkPct Then
  '          .ProgBar1.Value = WrkPct
  '          .LblMsg.Text = "Records processed: " & Counter
  '          .Refresh()
  '          SavePct = WrkPct
  '          Application.DoEvents()
  '        End If
  '      End With
  '    Next

  '    If SaveList > 0 Then
  '      dr = ds.Tables(0).NewRow
  '      WriteDrBase()
  '      dr.Item("amtdue") = WrkTTax
  '      If WrkTInt <> WrkTIntOrig And WrkTIntOrig < WrkMinInt Then
  '        dr.Item("Interest") = Format(WrkMinInt, "fixed")
  '        WrkTotal = WrkTTax + WrkMinInt + WrkTFee + WrkTLien + WrkTBond
  '      Else
  '        dr.Item("Interest") = Format(WrkTIntOrig, "fixed")
  '        WrkTotal = WrkTTax + WrkTIntOrig + WrkTFee + WrkTLien + WrkTBond
  '      End If
  '      dr.Item("fees") = WrkTFee
  '      dr.Item("liens") = WrkTLien
  '      dr.Item("bond") = WrkTBond
  '      dr.Item("total") = Format(WrkTotal, "fixed")
  '      ds.Tables(0).Rows.Add(dr)
  '    End If
  '    myFrmProgress.Close()

  '    myTXINVQ.CloseFile()
  '    myTXPROF.CloseFile()
  '    myUTCUST.CloseFile()
  '  End Sub
  Public Sub CalcInterest(ByVal InListNo As Integer, ByVal InType As String,
    ByVal InYear As Integer, ByRef OutInterest As Decimal, ByRef OutFee As Decimal,
    ByRef OutLien As Decimal, ByRef OutBond As Decimal, ByRef OutTax As Decimal,
    ByRef OutDue As Decimal, ByRef OutGracePeriod As Boolean, ByRef OutInt1 As Decimal,
    ByRef OutInt2 As Decimal, ByRef OutInt3 As Decimal, ByRef OutInt4 As Decimal)
    With myCASHINT
      .In_IntDate = WrkIntDate
      .In_ListNo = InListNo
      .In_Type = InType
      .In_Year = InYear
      .CalcInterest()
      OutInterest = Format(.Out_Int(), "standard")
      OutInt1 = Format(.Out_Int1(), "standard")
      OutInt2 = Format(.Out_Int2(), "standard")
      OutInt3 = Format(.Out_Int3(), "standard")
      OutInt4 = Format(.Out_Int4(), "standard")
      OutFee = Format(.Out_Fee(), "standard")
      OutLien = Format(.Out_Lien(), "standard")
      OutBond = Format(.Out_Bond(), "standard")
      OutTax = Format(.Out_Prin(), "standard")
      OutDue = Format(.Out_Tot(), "standard")
      OutGracePeriod = .Out_GracePeriod
    End With
  End Sub
  'Public Sub CalcInterest_219SW(ByVal InListNo As Integer, ByVal InType As String,
  '  ByVal InYear As Integer, ByRef OutInterest As Decimal, ByRef OutFee As Decimal,
  '  ByRef OutLien As Decimal, ByRef OutBond As Decimal, ByRef OutTax As Decimal,
  '  ByRef OutDue As Decimal, ByRef OutGracePeriod As Boolean, ByRef OutInt1 As Decimal,
  '  ByRef OutInt2 As Decimal, ByRef OutInt3 As Decimal, ByRef OutInt4 As Decimal)
  '  Dim mycashint2 As CASHINT.MyData
  '  Dim WrkType2 As String
  '  Dim WrkInterest As Decimal
  '  Dim WrkInterestOrig As Decimal
  '  Dim WrkInt1 As Decimal
  '  Dim WrkIntOrig1 As Decimal
  '  Dim WrkInt2 As Decimal
  '  Dim WrkIntOrig2 As Decimal
  '  Dim WrkInt3 As Decimal
  '  Dim WrkIntOrig3 As Decimal
  '  Dim WrkInt4 As Decimal
  '  Dim WrkIntOrig4 As Decimal
  '  Dim WrkDiff As Decimal

  '  mycashint2 = New CASHINT.MyData(myDBConnect)

  '  If InType = "S" Then
  '    WrkType2 = "W"
  '  Else
  '    WrkType2 = "S"
  '  End If

  '  With mycashint
  '    .In_IntDate = WrkIntDate
  '    .In_ListNo = InListNo
  '    .In_Type = InType
  '    .In_Year = InYear
  '    .CalcInterest()
  '    WrkInterest = Format(.Out_Int(), "standard")
  '    WrkInterestOrig = Format(.Out_IntOrig(), "standard")
  '    WrkInt1 = Format(.Out_Int1(), "standard")
  '    WrkIntOrig1 = Format(.Out_IntOrig1(), "standard")
  '    WrkInt2 = Format(.Out_Int2(), "standard")
  '    WrkIntOrig2 = Format(.Out_IntOrig2(), "standard")
  '    WrkInt3 = Format(.Out_Int3(), "standard")
  '    WrkIntOrig3 = Format(.Out_IntOrig3(), "standard")
  '    WrkInt4 = Format(.Out_Int4(), "standard")
  '    WrkIntOrig4 = Format(.Out_IntOrig4(), "standard")
  '    OutFee = Format(.Out_Fee(), "standard")
  '    OutLien = Format(.Out_Lien(), "standard")
  '    OutBond = Format(.Out_Bond(), "standard")
  '    OutTax = Format(.Out_Prin(), "standard")
  '    OutDue = Format(.Out_Tot(), "standard")
  '    OutGracePeriod = .Out_GracePeriod
  '  End With

  '  If WrkInterestOrig > 0 And WrkInterest <> WrkInterestOrig Then
  '    With mycashint2
  '      .In_IntDate = WrkIntDate
  '      .In_ListNo = InListNo
  '      .In_Type = WrkType2
  '      .In_Year = InYear
  '      .CalcInterest()
  '      If .Out_IntOrig > 0 And .Out_ProfMinInt > WrkInterestOrig + .Out_IntOrig Then
  '        WrkDiff = .Out_ProfMinInt * (WrkInterestOrig / (WrkInterestOrig + .Out_IntOrig))
  '        OutDue = Format(OutDue - WrkInterestOrig + WrkDiff, "standard")
  '        WrkInterestOrig = WrkDiff
  '      End If
  '      If .Out_IntOrig1 > 0 And .Out_ProfMinInt > WrkIntOrig1 + .Out_IntOrig1 Then
  '        WrkDiff = .Out_ProfMinInt * (WrkIntOrig1 / (WrkIntOrig1 + .Out_IntOrig1))
  '        WrkIntOrig1 = WrkDiff
  '      End If
  '      If .Out_IntOrig2 > 0 And .Out_ProfMinInt > WrkIntOrig2 + .Out_IntOrig2 Then
  '        WrkDiff = .Out_ProfMinInt * (WrkIntOrig2 / (WrkIntOrig2 + .Out_IntOrig2))
  '        WrkIntOrig2 = WrkDiff
  '      End If
  '      If .Out_IntOrig3 > 0 And .Out_ProfMinInt > WrkIntOrig3 + .Out_IntOrig3 Then
  '        WrkDiff = .Out_ProfMinInt * (WrkIntOrig3 / (WrkIntOrig3 + .Out_IntOrig3))
  '        WrkIntOrig3 = WrkDiff
  '      End If
  '      If .Out_IntOrig4 > 0 And .Out_ProfMinInt > WrkIntOrig4 + .Out_IntOrig4 Then
  '        WrkDiff = .Out_ProfMinInt * (WrkIntOrig4 / (WrkIntOrig4 + .Out_IntOrig4))
  '        WrkIntOrig4 = WrkDiff
  '      End If
  '    End With
  '  End If
  '  OutInterest = WrkInterestOrig
  '  OutInt1 = WrkIntOrig1
  '  OutInt2 = WrkIntOrig2
  '  OutInt3 = WrkIntOrig3
  '  OutInt4 = WrkIntOrig4
  '  mycashint2 = Nothing
  'End Sub
  Public Sub CalcInterest_219SW(ByVal InListNo As Integer, ByVal InType As String,
    ByVal InYear As Integer, ByRef OutInterest As Decimal, ByRef OutFee As Decimal,
    ByRef OutLien As Decimal, ByRef OutBond As Decimal, ByRef OutTax As Decimal,
    ByRef OutDue As Decimal, ByRef OutGracePeriod As Boolean, ByRef OutInt1 As Decimal,
    ByRef OutInt2 As Decimal, ByRef OutInt3 As Decimal, ByRef OutInt4 As Decimal)
    Dim WrkInterest As Decimal
    Dim WrkInt1 As Decimal
    Dim WrkInt2 As Decimal
    Dim WrkInt3 As Decimal
    Dim WrkInt4 As Decimal

    With myCASHINT
      .In_IntDate = WrkIntDate
      .In_ListNo = InListNo
      .In_Type = InType
      .In_Year = InYear
      .CalcInterest_219SW()
      WrkInterest = Format(.Out_Int(), "standard")
      WrkInt1 = Format(.Out_Int1(), "standard")
      WrkInt2 = Format(.Out_Int2(), "standard")
      WrkInt3 = Format(.Out_Int3(), "standard")
      WrkInt4 = Format(.Out_Int4(), "standard")
      OutFee = Format(.Out_Fee(), "standard")
      OutLien = Format(.Out_Lien(), "standard")
      OutBond = Format(.Out_Bond(), "standard")
      OutTax = Format(.Out_Prin(), "standard")
      OutDue = Format(.Out_Tot(), "standard")
      OutGracePeriod = .Out_GracePeriod
    End With

    OutInterest = WrkInterest
    OutInt1 = WrkInt1
    OutInt2 = WrkInt2
    OutInt3 = WrkInt3
    OutInt4 = WrkInt4
  End Sub
  Private Function BuildSelectTypes() As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim StrLen As Integer
    Dim I As Integer

    If MyTypes = "" Then
      Return ""
    End If

    sbSelect = New System.Text.StringBuilder
    sbSelect.Append("TYPE=%Values(")
    StrLen = Len(MyTypes)

    For I = 1 To StrLen
      WrkType = Mid(MyTypes, I, 1)
      sbSelect.Append(Chr(34) & WrkType & Chr(34) & " ")
    Next

    sbSelect.Append(")")
    Return sbSelect.ToString
  End Function
  Private Sub BufferType()
    Dim I As Integer

    Dim myTXTYPE As TXTYPE.MyData
    Dim dsTXType As DataSet = New DataSet

    myTXTYPE = New TXTYPE.MyData(myDBConnect)

    dsTXType = myTXTYPE.GetAllData
    For I = 0 To dsTXType.Tables(0).Rows.Count - 1
      With dsTXType.Tables(0).Rows(I)
        WrkCode(I) = .Item("tycode")
        WrkDesc(I) = .Item("tydesc")
        WrkFamily(I) = .Item("txfam")
      End With
    Next

  End Sub
  Private Function BuildSelectQryPC(ByVal WrkStrIn As String, ByVal WrkSelTypes As String) As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim WrkStrOut As String
    Dim StrLen As Integer
    Dim I As Integer

    WrkStrOut = ""
    If WrkSelTypes = "" Then
      Return ""
    End If

    StrLen = Len(WrkSelTypes)
    sbSelect = New System.Text.StringBuilder
    For I = 1 To StrLen
      If I > 1 Then
        sbSelect.Append(",")
      End If
      WrkType = Mid(WrkSelTypes, I, 1)
      sbSelect.Append(MyUtils.Quo(WrkType))
    Next
    If WrkStrIn = "" Then
      WrkStrOut = "TYPE IN(" & sbSelect.ToString & ")"
    Else
      WrkStrOut = WrkStrIn & WrkAnd & "TYPE IN(" & sbSelect.ToString & ")"
    End If
    sbSelect = Nothing
    Return WrkStrOut
  End Function
  Private Function LookupType(ByVal Type As String) As String()
    Dim I As Integer
    Dim WrkResult(1) As String

    WrkResult(0) = ""
    WrkResult(1) = ""

    For I = 0 To WrkCode.GetUpperBound(0)
      If Trim(WrkCode(I)) = "" Then
        Return WrkResult
      End If
      If Trim(Type) = Trim(WrkCode(I)) Then
        WrkResult(0) = WrkDesc(I)
        WrkResult(1) = WrkFamily(I)
        Return WrkResult
      End If
    Next

    Return WrkResult
  End Function
  Private Sub GetTXPROF(ByVal Type As String, ByVal Year As Integer,
    ByVal Phase As String, ByVal District As Integer)

    myTXPROF.GetOneRecordP(Type, Year, Phase, District)
  End Sub
  Private Sub WriteDrBase()
    Dim WrkName As String
    Dim WrkName2 As String
    Dim AddrLine() As String
    Dim WrkTXType As String()
    With myTXINVQ
      dr.Item("sortdata") = Format(._LISTNo, "000000")
      If ._ICODE = "B" Then
        dr.Item("backtax") = "B"
      Else
        dr.Item("backtax") = String.Empty
      End If
      dr.Item("listno") = ._LISTNo
      If WrkProfileType = "" Then
        WrkProfileType = ._TYPE
      End If
      dr.Item("year") = ._YEAR
      WrkTXType = LookupType(._TYPE)
      dr.Item("type") = ._TYPE
      dr.Item("typedesc") = WrkTXType(0)
      If InStr(._SNAME, "N/O ") > 0 Then
        WrkName = Replace(Trim(._SNAME), "N/O ", "")
        WrkName2 = ""
      Else
        WrkName = Trim(._NAME)
        WrkName2 = Trim(._SNAME)
      End If
      AddrLine = MyUtils.SetAddrLine(WrkName, WrkName2, ._ADD1, ._ADD2,
        ._CITY, ._STATE, ._ZIP5, ._ZIP4)
      dr.Item("addr1") = AddrLine(0)
      dr.Item("addr2") = AddrLine(1)
      dr.Item("addr3") = AddrLine(2)
      dr.Item("addr4") = AddrLine(3)
      dr.Item("addr5") = AddrLine(4)
      Select Case WrkTXType(1) 'Family
        Case "M", "S"
          dr.Item("propdesc") = Trim(._MAKE) & " " & Trim(._MVYR) & " " & ._IMVREG
          dr.Item("propdesc2") = ._IMVIDNo
        Case Else
          dr.Item("propdesc") = Trim(._LOCNo) & " " & ._LOC
          dr.Item("propdesc2") = ""
      End Select
      dr.Item("LastPaid") = Format(MyUtils.GetDBDate(._TXIDT), "short date").ToString
      If dr.Item("LastPaid") = "1/1/0001" Then
        dr.Item("LastPaid") = ""
      End If
    End With
  End Sub
  Private Sub PostStatus()
    Dim WrkStcd(4) As String
    Dim Good As Boolean

    With myTXINVQ
      myTXINV.GetOneRecordP(._LISTNo, ._YEAR, ._TYPE)
      WrkStcd(0) = Trim(._STCD1)
      WrkStcd(1) = Trim(._STCD2)
      WrkStcd(2) = Trim(._STCD3)
      WrkStcd(3) = Trim(._STCD4)
      WrkStcd(4) = Trim(._STCD5)
      Good = UpdateStatusCD(WrkStcd)
      If Good Then
        myTXINV._STCD1 = WrkStcd(0)
        myTXINV._STCD2 = WrkStcd(1)
        myTXINV._STCD3 = WrkStcd(2)
        myTXINV._STCD4 = WrkStcd(3)
        myTXINV._STCD5 = WrkStcd(4)
        myTXINV.UpdateOneRecordP()
        WriteHistory(._LISTNo, ._YEAR, ._TYPE)
      Else
        dr = dsErr.Tables(0).NewRow
        dr.Item("listno") = ._LISTNo
        dr.Item("year") = ._YEAR
        dr.Item("type") = ._TYPE
        dr.Item("status") = WrkStcd(0) & WrkStcd(1) & WrkStcd(2) & WrkStcd(3) & WrkStcd(4)
        dsErr.Tables(0).Rows.Add(dr)
      End If
    End With
  End Sub
  Private Sub PostStatusFiltered(ByVal ds As DataSet)
    Dim WrkStcd(4) As String
    Dim Good As Boolean

    ' Define the variables for ListNo, Year, and Type
    Dim wrkflistno As Integer
    Dim wrkfyear As Integer
    Dim wrkftype As String

    ' Ensure the dataset and table exist
    If ds Is Nothing OrElse Not ds.Tables.Contains("mytable") Then
      GoTo skipit
    End If

    ' Loop through the rows in the dataset
    For Each row As DataRow In ds.Tables("mytable").Rows
      ' Assign values from the dataset row to variables
      wrkflistno = row.Field(Of Integer)("ListNo")
      wrkfyear = row.Field(Of Integer)("Year")
      wrkftype = row.Field(Of String)("Type")

      With myTXINVQ
        ' Replace hardcoded values with dataset fields
        myTXINV.GetOneRecordP(wrkflistno, wrkfyear, wrkftype)

        ' Process status codes
        WrkStcd(0) = Trim(._STCD1)
        WrkStcd(1) = Trim(._STCD2)
        WrkStcd(2) = Trim(._STCD3)
        WrkStcd(3) = Trim(._STCD4)
        WrkStcd(4) = Trim(._STCD5)
        Good = UpdateStatusCD(WrkStcd)

        If Good Then
          myTXINV._STCD1 = WrkStcd(0)
          myTXINV._STCD2 = WrkStcd(1)
          myTXINV._STCD3 = WrkStcd(2)
          myTXINV._STCD4 = WrkStcd(3)
          myTXINV._STCD5 = WrkStcd(4)
          myTXINV.UpdateOneRecordP()

          ' Write history with current values
          WriteHistory(wrkflistno, wrkfyear, wrkftype)
        Else
          ' Add error record to dsErr
          Dim dr As DataRow = dsErr.Tables(0).NewRow
          dr.Item("listno") = wrkflistno
          dr.Item("year") = wrkfyear
          dr.Item("type") = wrkftype
          dr.Item("status") = WrkStcd(0) & WrkStcd(1) & WrkStcd(2) & WrkStcd(3) & WrkStcd(4)
          dsErr.Tables(0).Rows.Add(dr)
        End If
      End With
    Next
skipit:
  End Sub

  Private Function UpdateStatusCD(ByRef WrkStCd() As String) As Boolean

    Dim J As Integer
    Dim Good As Boolean

    Good = False

    For J = 0 To 4
      If WrkStCd(J) = WrkPostStatusCode Then Return Good 'Already there 
      If WrkStCd(J) = "" Then
        WrkStCd(J) = WrkPostStatusCode
        Good = True
        Exit For
      End If
    Next

    Return Good
  End Function
  Private Sub WriteHistory(ByVal ListNo As Integer, ByVal Year As Integer, ByVal Type As String)
    Dim WrkRecId As Integer

    If Not MyStatusHistory Then Exit Sub

    With myTXHST
      WrkRecId = .AutoGenKey()
      .GetOneRecordP(WrkRecId)
      ._RECID = WrkRecId
      ._RCODE = "I"
      ._LISTNO = ListNo
      ._YEAR = Year
      ._TYPE = Type
      ._CDATE = MyUtils.SetDBDate(Date.Today)
      ._PDATE = MyUtils.SetDBDate(Date.Today)
      ._REF = MyUtils.JustifyLeft(WrkStatusDesc, 10)
      ._CORC = "A"
      ._COMM = "TX302"
      ._PRF = Mid(MyUserID, 1, 10)
      ._CHDATE = MyUtils.SetDBDate(Date.Now.Date)
      ._CHTIME = MyUtils.SetDBTime(Date.Now)
      .AddOneRecordP()
    End With

  End Sub

  Public Function FilterDatasetByBalance(ByVal inputDataset As DataSet, ByVal thresholdAmount As Decimal) As DataSet
    ' Ensure the dataset and the required table exist
    If inputDataset Is Nothing OrElse Not inputDataset.Tables.Contains("mytable") Then
      Throw New ArgumentException("The dataset does not contain the required table 'mytable'.")
    End If

    ' Get the DataTable
    Dim myTable As DataTable = inputDataset.Tables("mytable")

    ' Create a dictionary to store the sum of Balance for each SortData
    Dim balanceSums As New Dictionary(Of String, Decimal)

    ' Calculate the total Balance for each SortData
    For Each row As DataRow In myTable.Rows
      Dim sortData As String = row.Field(Of String)("SortData")
      Dim balance As Decimal = row.Field(Of Decimal)("Balance")

      If balanceSums.ContainsKey(sortData) Then
        balanceSums(sortData) += balance
      Else
        balanceSums.Add(sortData, balance)
      End If
    Next

    ' Identify SortData values with a total Balance less than the threshold
    Dim toRemoveSortData As New List(Of String)
    For Each kvp As KeyValuePair(Of String, Decimal) In balanceSums
      If kvp.Value < thresholdAmount Then
        toRemoveSortData.Add(kvp.Key)
      End If
    Next

    ' Remove rows from the DataTable where SortData matches any in the removal list
    For Each row As DataRow In myTable.Select()
      Dim sortData As String = row.Field(Of String)("SortData")
      If toRemoveSortData.Contains(sortData) Then
        row.Delete()
      End If
    Next

    ' Finalize deletions
    myTable.AcceptChanges()

    ' Return the updated dataset
    Return inputDataset
  End Function
  Public Function FilterDatasetByInterest(ByVal inputDataset As DataSet, ByVal thresholdAmount As Decimal) As DataSet
    ' Get the DataTable
    Dim myTable As DataTable = inputDataset.Tables("mytable")

    ' Create a dictionary to store the sum of Interest for each SortData
    Dim InterestSums As New Dictionary(Of String, Decimal)

    ' Calculate the total Interest for each SortData
    For Each row As DataRow In myTable.Rows
      Dim sortData As String = row.Field(Of String)("SortData")
      Dim Interest As Decimal = row.Field(Of Decimal)("Interest")

      If InterestSums.ContainsKey(sortData) Then
        InterestSums(sortData) += Interest
      Else
        InterestSums.Add(sortData, Interest)
      End If
    Next

    ' Identify SortData values with a total Balance less than the threshold
    Dim toRemoveSortData As New List(Of String)
    For Each kvp As KeyValuePair(Of String, Decimal) In InterestSums
      If kvp.Value < thresholdAmount Then
        toRemoveSortData.Add(kvp.Key)
      End If
    Next

    ' Remove rows from the DataTable where SortData matches any in the removal list
    For Each row As DataRow In myTable.Select()
      Dim sortData As String = row.Field(Of String)("SortData")
      If toRemoveSortData.Contains(sortData) Then
        row.Delete()
      End If
    Next

    ' Finalize deletions
    myTable.AcceptChanges()

    ' Return the updated dataset
    Return inputDataset
  End Function
End Module
