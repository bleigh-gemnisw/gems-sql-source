Imports System.Collections.Generic
Imports System.Diagnostics.Eventing.Reader
Imports System.Text
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

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim dsErr As DataSet = New DataSet

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
      WrkOmitSuspense = False
      If .ChkOmitSuspense.Checked Then
        WrkOmitSuspense = True
      End If
      WrkInGracePeriod = False
      If .ChkInGracePeriod.Checked Then
        WrkInGracePeriod = True
      End If
      WrkOmitTotalBelow = MyUtils.CnvSng(.TxtOmitTotalBelow.Text)
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
      If .RbSortLoc.Checked Then
        WrkSortBy = "Location"
      End If
      WrkPostStatus = .ChkPostStatus.Checked
      WrkPostStatusCode = .TxtPostStatus.Text
      WrkStatusDesc = WrkPostStatusCode & "-" & Trim(GetTXStsDesc(WrkPostStatusCode))
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
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
      GetDetail()
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
      .Columns.Add("BillDate", Type.GetType("System.String"))    'added ken

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
    Dim WrkName As String
    Dim WrkName2 As String
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
        dr = ds.Tables(0).NewRow
        Select Case WrkSortBy
          Case "Zip"
            dr.Item("sortdata") = Format(._ZIP5, "00000") & " " & WrkName
          Case "Name"
            dr.Item("sortdata") = WrkName
          Case "SName"
            dr.Item("sortdata") = WrkName & " " & WrkName2 & " " & Trim(._ADD1)
          Case "DOB"
            dr.Item("sortdata") = WrkName & " " & Trim(._ADD1) & " " & ._DOB
          Case "List"
            dr.Item("sortdata") = Format(._LISTNo, "000000")
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
        CalcInterest(._LISTNo, ._TYPE, ._YEAR, WrkInterest, WrkFee, WrkLien, WrkBond, WrkTax, WrkDue, WrkGracePeriod)
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

      End With

      ' if winsted 162 and demand and omittotal > 0 then we want to not post this as we will need to post at the end 

      If myTOWN._TOWNBR = 162 And WrkRptNo = 3 And WrkOmitTotalBelow > 0 Then GoTo skipfornow

      If WrkPostStatus Then
        PostStatus()
      End If
skipfornow:

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







    myFrmProgress.Close()

    myTXINVQ.CloseFile()
    myTXPROF.CloseFile()

  End Sub
  Private Sub GetDetail8()
    Dim dsinv As DataSet = New DataSet
    Dim AddrLine() As String
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkName As String
    Dim WrkName2 As String
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

    WrkSort = "TYPE, YEAR , DIST"

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

        If InStr(._SNAME, "N/O ") > 0 Then
          WrkName = Replace(Trim(._SNAME), "N/O ", "")
          WrkName2 = ""
        Else
          WrkName = Trim(._NAME)
          WrkName2 = Trim(._SNAME)
        End If
        dr = ds.Tables(0).NewRow

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
        CalcInterest(._LISTNo, ._TYPE, ._YEAR, WrkInterest, WrkFee, WrkLien, WrkBond, WrkTax, WrkDue, WrkGracePeriod)
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
        'ken - for rpt 8 want to output different

        If WrkRptNo = 8 Then
          dr.Item("LastPaid") = Format(MyUtils.GetDBDate(._TXIDT), "short date").ToString
          If dr.Item("LastPaid") = "1/1/0001" Then
            dr.Item("LastPaid") = ""
          End If

          '1st bill



          '=================
          dr.Item("amtdue") = myCASHINT.Out_Prin1
          dr.Item("Interest") = Format(myCASHINT.Out_Int1, "fixed")
          dr.Item("fees") = myCASHINT.Out_Fee1
          dr.Item("liens") = myCASHINT.Out_Lien1
          dr.Item("bond") = 0
          dr.Item("total") = Format(myCASHINT.Out_Due1, "fixed")
          dr.Item("BillDate") = Format(myCASHINT.Out_profDate1, "short date").ToString
          ds.Tables(0).Rows.Add(dr)
          '==================
          '2nd bill
          dr = ds.Tables(0).NewRow

          '==================
          ' repeat from above
          '==================
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


          '=================

          dr.Item("amtdue") = myCASHINT.Out_Prin2
          dr.Item("Interest") = Format(myCASHINT.Out_Int2, "fixed")
          dr.Item("fees") = myCASHINT.Out_Fee2
          dr.Item("liens") = myCASHINT.Out_Lien2
          dr.Item("bond") = 0
          dr.Item("total") = Format(myCASHINT.Out_Due2, "fixed")
          dr.Item("BillDate") = Format(myCASHINT.Out_profDate2, "short date").ToString
          dr.Item("LastPaid") = ""
          ds.Tables(0).Rows.Add(dr)
        Else ' normal report

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
        End If
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

    myFrmProgress.Close()

    myTXINVQ.CloseFile()
    myTXPROF.CloseFile()

  End Sub
  Public Sub CalcInterest(ByVal InListNo As Integer, ByVal InType As String,
  ByVal InYear As Integer, ByRef OutInterest As Decimal, ByRef OutFee As Decimal,
  ByRef OutLien As Decimal, ByRef OutBond As Decimal, ByRef OutTax As Decimal, ByRef OutDue As Decimal,
    ByRef OutGracePeriod As Boolean)
    With myCASHINT
      .In_IntDate = WrkIntDate
      .In_ListNo = InListNo
      .In_Type = InType
      .In_Year = InYear
      .CalcInterest()
      OutInterest = Format(.Out_Int(), "standard")
      OutFee = Format(.Out_Fee(), "standard")
      OutLien = Format(.Out_Lien(), "standard")
      OutBond = Format(.Out_Bond(), "standard")
      OutTax = Format(.Out_Prin(), "standard")
      OutDue = Format(.Out_Tot(), "standard")
      OutGracePeriod = .Out_GracePeriod
    End With
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



End Module
