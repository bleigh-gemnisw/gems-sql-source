Imports System.Text
Imports System.IO
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXHSTL1 As TXHSTL1.MyData
  Dim myTXCOEA As TXCOEAL1.MyData
  Dim myUTCOEA As UTCOEAL1.MyData
  Dim myTXE08RV As TXE08RV.MyData

  Dim ds As DataSet = New DataSet
  Dim dsCR As DataSet = New DataSet
  Dim dsSusp As DataSet = New DataSet
  Dim dsAudit As DataSet = New DataSet
  Dim dsTot As DataSet = New DataSet
  Dim dsTotCR As DataSet = New DataSet
  Dim dsTotSusp As DataSet = New DataSet
  Dim dsTotSum As DataSet = New DataSet
  Dim dr As Data.DataRow
  'General
  Dim SaveYear As Integer
  Dim SaveType As String
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkPhase As Integer
  Dim WrkAnd As String
  Dim WrkOr As String
  Dim WrkBlocking As Boolean
  Dim WrkTotals As String
  Dim WrkDetail As String
  Dim WrkFromYear As Integer
  Dim WrkToYear As Integer
  Dim WrkFrom As Integer
  Dim WrkTo As Integer
  Dim WrkTypes As String
  Dim WrkAuditRefund As Boolean
  'Totals
  Dim WrkTOrigBal(2) As Decimal
  Dim WrkTBegBal(2) As Decimal
  Dim WrkTXferSusp(2) As Decimal
  Dim WrkTCCAdd(2) As Decimal
  Dim WrkTCCRed(2) As Decimal
  Dim WrkTPaid(2) As Decimal
  Dim WrkTInt(2) As Decimal
  Dim WrkTLien(2) As Decimal
  Dim WrkTFee(2) As Decimal
  Dim WrkTEndBal(2) As Decimal
  Dim WrkTEndBalCR(2) As Decimal
  Dim WrkTRefunds(2) As Decimal
  Dim WrkOverCredit As Decimal
  Dim WrkOverSusp As Decimal
  Dim WrkRecovery As Boolean
  Public Sub PrtReport()

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXHSTL1 = New TXHSTL1.MyData(myDBConnect)
    myTXCOEA = New TXCOEAL1.MyData(myDBConnect)
    myUTCOEA = New UTCOEAL1.MyData(myDBConnect)
    myTXE08RV = New TXE08RV.MyData(myDBConnect)

    If MyServer = "SQL" Then
      WrkBlocking = False
    Else
      WrkBlocking = True
    End If

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    With MyFrmTXE08B
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
      WrkFromYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
      WrkToYear = MyUtils.CnvSng(.TxtToGLYear.Text)
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkDistAll = False
      If Trim(.TxtDist.Text) = "" Then
        WrkDistAll = True
      End If
      WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
      If .RbTotCombine.Checked Then WrkTotals = "Combine"
      If .RbTotSplit.Checked Then WrkTotals = "Split"
      If .RbDetCombine.Checked Then WrkDetail = "Combine"
      If .RbDetSplit.Checked Then WrkDetail = "Split"
      If .RbDetNoprint.Checked Then WrkDetail = ""
      WrkAuditRefund = False
      If .RbAuditRefund.Checked Then
        WrkAuditRefund = True
      End If
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
      BuildDSTot()
      BuildDSAudit()
    Else
      ds.Clear()
      dsCR.Clear()
      dsSusp.Clear()
      dsAudit.Clear()
      dsTot.Clear()
      dsTotCR.Clear()
      dsTotSusp.Clear()
      dsTotSum.Clear()
    End If

    BufferType()
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.wrkdsCR = dsCR
    MyCrViewer.wrkdsSusp = dsSusp
    MyCrViewer.wrkdsAudit = dsAudit
    MyCrViewer.wrkdsTot = dsTot
    MyCrViewer.wrkdsTotCR = dsTotCR
    MyCrViewer.wrkdsTotSusp = dsTotSusp
    MyCrViewer.wrkdsTotSum = dsTotSum
    MyCrViewer.wrkRecovery = WrkRecovery
    MyCrViewer.wrkAuditRefund = WrkAuditRefund
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("RptID", Type.GetType("System.String"))
      .Columns.Add("List", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("OrigBal", Type.GetType("System.Decimal"))
      .Columns.Add("BegBal", Type.GetType("System.Decimal"))
      .Columns.Add("NewBill", Type.GetType("System.Decimal"))
      .Columns.Add("XferSusp", Type.GetType("System.Decimal"))
      .Columns.Add("CCAdd", Type.GetType("System.Decimal"))
      .Columns.Add("CCRed", Type.GetType("System.Decimal"))
      .Columns.Add("Payments", Type.GetType("System.Decimal"))
      .Columns.Add("Refunds", Type.GetType("System.Decimal"))
      .Columns.Add("EndBal", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Fees", Type.GetType("System.Decimal"))
      .Columns.Add("Liens", Type.GetType("System.Decimal"))
      .Columns.Add("Errors", Type.GetType("System.Decimal"))
      .Columns.Add("ErrorsDiff", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
    dsCR = ds.Clone
    dsSusp = ds.Clone

  End Sub
  Private Sub BuildDSTot()
    Dim myTableTot As New DataTable
    With myTableTot
      .TableName = "mytabletot"
      .Columns.Add("RptID", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("TOrigBal", Type.GetType("System.Decimal"))
      .Columns.Add("TBegBal", Type.GetType("System.Decimal"))
      .Columns.Add("TXferSusp", Type.GetType("System.Decimal"))
      .Columns.Add("TCCAdd", Type.GetType("System.Decimal"))
      .Columns.Add("TCCRed", Type.GetType("System.Decimal"))
      .Columns.Add("TPayments", Type.GetType("System.Decimal"))
      .Columns.Add("TRefunds", Type.GetType("System.Decimal"))
      .Columns.Add("TEndBal", Type.GetType("System.Decimal"))
      .Columns.Add("TEndBalCR", Type.GetType("System.Decimal"))
      .Columns.Add("TInterest", Type.GetType("System.Decimal"))
      .Columns.Add("TFees", Type.GetType("System.Decimal"))
      .Columns.Add("TLiens", Type.GetType("System.Decimal"))
      .Columns.Add("TOverpaid", Type.GetType("System.Decimal"))
      .Columns.Add("TErrors", Type.GetType("System.Decimal"))
      .Columns.Add("TErrorsDiff", Type.GetType("System.Decimal"))
    End With
    dsTot.Tables.Add(myTableTot)
    dsTotCR = dsTot.Clone
    dsTotSusp = dsTot.Clone
    dsTotSum = dsTot.Clone

  End Sub
  Private Sub BuildDSAudit()
    Dim myTableTot As New DataTable
    With myTableTot
      .TableName = "mytabletot"
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("TBegBal", Type.GetType("System.Decimal"))
      .Columns.Add("TRecovery", Type.GetType("System.Decimal"))
      .Columns.Add("TCCAdd", Type.GetType("System.Decimal"))
      .Columns.Add("TCCRed", Type.GetType("System.Decimal"))
      .Columns.Add("TAdjBal", Type.GetType("System.Decimal"))
      .Columns.Add("TPayments", Type.GetType("System.Decimal"))
      .Columns.Add("TRefunds", Type.GetType("System.Decimal"))
      .Columns.Add("TOverpaid", Type.GetType("System.Decimal"))
      .Columns.Add("TInterest", Type.GetType("System.Decimal"))
      .Columns.Add("TFees", Type.GetType("System.Decimal"))
      .Columns.Add("TLiens", Type.GetType("System.Decimal"))
      .Columns.Add("CredCC", Type.GetType("System.Decimal"))
      .Columns.Add("CredPay", Type.GetType("System.Decimal"))
      .Columns.Add("SusPayments", Type.GetType("System.Decimal"))
      .Columns.Add("SusInterest", Type.GetType("System.Decimal"))
      .Columns.Add("TXferSusp", Type.GetType("System.Decimal"))
      .Columns.Add("TCollect", Type.GetType("System.Decimal"))
      .Columns.Add("TEndBal", Type.GetType("System.Decimal"))
    End With
    dsAudit.Tables.Add(myTableTot)
  End Sub
  Private Sub GetDetail()
    Dim sw As StreamWriter
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkFields As String
    Dim K As Integer
    Dim WrkTotal As Decimal
    Dim WrkTaxt As Decimal
    Dim WrkCC As Boolean
    Dim WrkPrevCC As Boolean
    Dim WrkSuspCC As Boolean
    Dim WrkCCTaxt As Decimal
    Dim WrkPrevCCTaxt As Decimal
    Dim WrkSuspCCTaxt As Decimal
    Dim WrkDiff As Decimal
    Dim WrkBegBal As Decimal
    Dim WrkPrevSusp As Boolean
    Dim WrkXferSusp As Decimal
    Dim WrkCCAdd As Decimal
    Dim WrkCCRed As Decimal
    Dim WrkSuspCCAdd As Decimal
    Dim WrkSuspCCRed As Decimal
    Dim WrkEndBal As Decimal
    Dim WrkFamily As String
    Dim WrkHistSusp As Decimal
    Dim WrkPaidBeforeSusp As Decimal
    Dim WrkTXType As String()
    Dim WrkRptID As String
    Dim WrkPrevPaid As Decimal
    Dim WrkPaid As Decimal
    Dim WrkRefunds As Decimal
    Dim WrkInt As Decimal
    Dim WrkLien As Decimal
    Dim WrkFee As Decimal
    Dim WrkPrevPaidSusp As Decimal
    Dim WrkSuspPaid As Decimal
    Dim WrkSuspInt As Decimal
    Dim WrkSuspLien As Decimal
    Dim WrkSuspFee As Decimal
    Dim WrkSuspRefunds As Decimal
    Dim Counter As Integer
    Dim Good As Boolean

    Counter = 0
    SaveYear = 0
    SaveType = ""
    WrkFields = "icode,list#,year,type,name,dist,phase,taxt,pdat,ccno,cdate,ccetax,suscd,susdt"
    WrkRecovery = False
    ClearTotals()

    WrkQry = "ICODE <> 'I'" & WrkAnd & "YEAR >= " & WrkFromYear & WrkAnd & "YEAR <= " & WrkToYear
    If Not WrkDistAll Then
      WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
    End If
    If WrkPhase > 0 Then
      WrkQry = WrkQry & WrkAnd & "PHASE = " & WrkPhase
    End If
    'MyTypes = MyFrmTXE08B.TxtTypes.Text
    'If MyTypes <> "" Then
    '  WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    'End If
    MyTypes = MyFrmTXE08B.TxtTypes.Text.Trim.ToUpper()

    If MyTypes <> "" Then
      ' WrkTypes = BuildWrkTypes(MyTypes)
      WrkTypes = Trim(MyTypes)
      ' Still build WrkQry for other logic that might use it
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    Else
      WrkTypes = ""
    End If


    If MyFrmTXE08B.LblFilePath.Text <> String.Empty Then
      sw = New StreamWriter(MyFrmTXE08B.LblFilePath.Text)
      sw.WriteLine(HeadingsCSV)
    End If

    WrkSort = "Year, Type, Name"
    'WrkQry = WrkQry & WrkAnd & "list#=20707"
    ' ken  rplace trying to optimize  6-1-25
    'myTXINVQ.OpenQry(WrkSort, WrkQry, WrkFields)
    myTXINVQ.OpenComboQry(WrkFromYear, WrkToYear, WrkDist, WrkPhase, WrkTypes)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()

ReadNext:
    ' ken 6-1-25 trying to optimize
    ' myTXINVQ.ReadQry(WrkFields)
    myTXINVQ.ReadComboQry()
    If Not myTXINVQ.IsEOF Then
      With myTXINVQ
        Counter = Counter + 1
        'ken 6-1-25 optimize approach   commented out 
        '  myTXHSTL1.SetRangeLite(._LISTNo, ._YEAR, ._TYPE, 0, False)
        If SaveYear > 0 Then
          If SaveYear <> ._YEAR Or SaveType <> ._TYPE Then
            If WrkTotals = "Combine" Then
              WriteSummaryTotals()
            Else
              WriteAudit()
              WriteTotals()
              WriteSummary()
            End If
            ClearTotals()
          End If
        End If
        SaveYear = ._YEAR
        SaveType = ._TYPE
        WrkCC = False
        WrkCCTaxt = 0
        WrkPrevCC = False
        WrkSuspCC = False
        WrkPrevCCTaxt = 0
        WrkSuspCCTaxt = 0
        WrkPrevPaid = 0
        WrkPaid = 0
        WrkRefunds = 0
        WrkInt = 0
        WrkLien = 0
        WrkFee = 0
        WrkSuspPaid = 0
        WrkSuspInt = 0
        WrkSuspLien = 0
        WrkSuspFee = 0
        WrkSuspRefunds = 0
        WrkPrevPaidSusp = 0
        WrkCCAdd = 0
        WrkCCRed = 0
        WrkSuspCCAdd = 0
        WrkSuspCCRed = 0
        WrkPrevSusp = False
        WrkXferSusp = 0
        If ._TYPE = "X" Then
          If ._PDAT > WrkTo Then
            WrkTaxt = 0
          Else
            WrkTaxt = ._TAXT
          End If
        Else
          WrkTaxt = ._TAXT
        End If
        WrkHistSusp = 0
        WrkPaidBeforeSusp = 0

        If ._CCNO > 0 Then
          WrkTXType = LookupType(._TYPE)
          WrkFamily = WrkTXType(1)
          If WrkFamily <> "U" And WrkFamily <> "A" Then
            myTXCOEA.SetRangeLite(._LISTNo, ._YEAR, ._TYPE, 999999999, 999999, True)
            Do While Not myTXCOEA.IsEOF
              myTXCOEA.ReadFileELite()
              If myTXCOEA.IsEOF Then Exit Do
              With myTXCOEA
                If Trim(myTXINVQ._SUSCD) <> "" Then
                  If Not WrkSuspCC Then
                    If ._CDATE > myTXINVQ._SUSDT Then
                      WrkSuspCCTaxt = ._CETAX
                      WrkSuspCC = True
                    End If
                  End If
                End If
                If ._CDATE >= WrkFrom And ._CDATE <= WrkTo Then
                  If Not WrkCC Then
                    WrkCCTaxt = ._CETAX
                    WrkCC = True
                  End If
                End If
                If ._CDATE < WrkFrom Then
                  WrkPrevCCTaxt = ._CETAX
                  WrkPrevCC = True
                  myTXCOEA.CloseRange()
                  Exit Do
                End If
              End With
            Loop
            'Missing C/C records use invoice info
            If Not WrkCC And Not WrkSuspCC And Not WrkPrevCC Then
              If ._CDATE >= WrkFrom And ._CDATE <= WrkTo Then
                If Trim(myTXINVQ._SUSCD) <> "" Then
                  If Not WrkSuspCC Then
                    If ._CDATE > myTXINVQ._SUSDT Then
                      WrkSuspCCTaxt = ._CCETAX
                      WrkSuspCC = True
                    End If
                  End If
                End If
                If Not WrkCC Then
                  WrkCCTaxt = ._CCETAX
                  WrkCC = True
                End If
              End If
              If ._CDATE > 0 And ._CDATE < WrkFrom Then
                WrkPrevCCTaxt = ._CCETAX
                WrkPrevCC = True
              End If
            End If
          Else
            myUTCOEA.SetRangeLite(._LISTNo, ._YEAR, ._TYPE, 999999999, 999999, True)
            Do While Not myUTCOEA.IsEOF
              myUTCOEA.ReadFileELite()
              If myUTCOEA.IsEOF Then Exit Do
              With myUTCOEA
                If ._CDATE >= WrkFrom And ._CDATE <= WrkTo Then
                  If Trim(myTXINVQ._SUSCD) <> "" Then
                    If Not WrkSuspCC Then
                      If ._CDATE > myTXINVQ._SUSDT Then
                        WrkSuspCCTaxt = ._CETAX
                        WrkSuspCC = True
                      End If
                    End If
                  End If
                  If Not WrkCC Then
                    WrkCCTaxt = ._CETAX
                    WrkCC = True
                  End If
                End If
                If ._CDATE < WrkFrom Then
                  WrkPrevCCTaxt = ._CETAX
                  WrkPrevCC = True
                  myUTCOEA.CloseRange()
                  Exit Do
                End If
              End With
            Loop
            'Missing C/C records use invoice info
            If Not WrkCC And Not WrkSuspCC And Not WrkPrevCC Then
              If ._CDATE >= WrkFrom And ._CDATE <= WrkTo Then
                If Trim(myTXINVQ._SUSCD) <> "" Then
                  If Not WrkSuspCC Then
                    If ._CDATE > myTXINVQ._SUSDT Then
                      WrkSuspCCTaxt = ._CCETAX
                      WrkSuspCC = True
                    End If
                  End If
                End If
                If Not WrkCC Then
                  WrkCCTaxt = ._CCETAX
                  WrkCC = True
                End If
              End If
            End If
            If ._CDATE < WrkFrom Then
              WrkPrevCCTaxt = ._CCETAX
              WrkPrevCC = True
            End If
          End If
        End If
        ' ken replacing the DO loop  with what follows after all comment out lines
        'Do While Not myTXHSTL1.IsEOF
        '  myTXHSTL1.ReadFileELite()
        '  If myTXHSTL1.IsEOF Then Exit Do
        '  With myTXHSTL1
        '    If ._RCODE = "I" Then
        '      If ._BATCHA = "S" Then
        '        WrkHistSusp = ._PCAMT
        '        If WrkHistSusp = 0 Then
        '          If Not WrkPrevCC Then
        '            WrkHistSusp = WrkTaxt - WrkPaidBeforeSusp
        '          Else
        '            WrkHistSusp = WrkPrevCCTaxt - WrkPaidBeforeSusp
        '          End If
        '        End If
        '      End If
        '      Continue Do
        '    End If
        '    If ._RCODE = "V" Then Continue Do
        '    If ._RCODE = "I" Then Continue Do

        '    If myTXINVQ._SUSDT > 0 Then
        '      If ._PDATE < myTXINVQ._SUSDT Then
        '        WrkPaidBeforeSusp = WrkPaidBeforeSusp + ._PAMT
        '      Else
        '        If ._PDATE >= WrkFrom And ._PDATE <= WrkTo Then
        '          If ._ADJCD = "R" Then
        '            WrkSuspRefunds = WrkSuspRefunds + ._PAMT
        '          Else
        '            WrkSuspPaid = WrkSuspPaid + ._PAMT
        '          End If
        '          WrkSuspInt = WrkSuspInt + ._IAMT
        '          WrkSuspLien = WrkSuspLien + ._LAMT
        '          WrkSuspFee = WrkSuspFee + ._PCAMT
        '        End If
        '      End If
        '    End If
        '    If ._PDATE < WrkFrom Then
        '      WrkPrevPaid = WrkPrevPaid + ._PAMT
        '    End If
        '    If ._PDATE >= WrkFrom And ._PDATE <= WrkTo Then
        '      If ._ADJCD = "R" Then
        '        WrkRefunds = WrkRefunds + ._PAMT
        '      Else
        '        WrkPaid = WrkPaid + ._PAMT
        '      End If
        '      WrkInt = WrkInt + ._IAMT
        '      WrkLien = WrkLien + ._LAMT
        '      WrkFee = WrkFee + ._PCAMT
        '    End If
        '  End With
        'Loop
        '-----------replacement -----
        Dim hstRows() As DataRow = myTXINVQ.GetTXHSTRowsForCurrentRecord()

        For Each hstRow As DataRow In hstRows
          Dim rcode As String = hstRow("RCODE").ToString()
          Dim batcha As String = hstRow("BATCHA").ToString()
          Dim padjcd As String = hstRow("ADJCD").ToString()
          Dim pdate As Integer = hstRow("PDATE")
          Dim pamt As Decimal = SafeDecimal(hstRow("PAMT"))
          Dim iamt As Decimal = SafeDecimal(hstRow("IAMT"))
          Dim lamt As Decimal = SafeDecimal(hstRow("LAMT"))
          Dim pcamt As Decimal = SafeDecimal(hstRow("PCAMT"))

          If rcode = "I" Then
            If batcha = "S" Then
              WrkHistSusp = pcamt
              If WrkHistSusp = 0 Then
                If Not WrkPrevCC Then
                  WrkHistSusp = WrkTaxt - WrkPaidBeforeSusp
                Else
                  WrkHistSusp = WrkPrevCCTaxt - WrkPaidBeforeSusp
                End If
              End If
            End If
            Continue For
          End If

          If rcode = "V" Then Continue For
          If rcode = "I" Then Continue For

          If myTXINVQ._SUSDT > 0 Then
            If pdate < myTXINVQ._SUSDT Then
              WrkPaidBeforeSusp += pamt
            ElseIf pdate >= WrkFrom AndAlso pdate <= WrkTo Then
              If padjcd = "R" Then
                WrkSuspRefunds += pamt
              Else
                WrkSuspPaid += pamt
              End If
              WrkSuspInt += iamt
              WrkSuspLien += lamt
              WrkSuspFee += pcamt
            End If
          End If

          If pdate < WrkFrom Then
            WrkPrevPaid += pamt
          End If

          If pdate >= WrkFrom AndAlso pdate <= WrkTo Then
            If padjcd = "R" Then
              WrkRefunds += pamt
            Else
              WrkPaid += pamt
            End If
            WrkInt += iamt
            WrkLien += lamt
            WrkFee += pcamt
          End If
        Next

        '------------------------

        WrkTotal = WrkPaid + WrkInt + WrkLien + WrkFee
        WrkDiff = 0
        If WrkCC Then
          If Not WrkPrevCC Then
            WrkDiff = WrkCCTaxt - WrkTaxt
          Else
            WrkDiff = WrkCCTaxt - WrkPrevCCTaxt
          End If
          If WrkDiff > 0 Then
            WrkCCAdd = WrkDiff
          Else
            WrkCCRed = Math.Abs(WrkDiff)
          End If
          'suspense
          WrkDiff = 0
          If WrkSuspCC Then
            If Not WrkPrevCC Then
              WrkDiff = WrkSuspCCTaxt - WrkTaxt
            Else
              WrkDiff = WrkSuspCCTaxt - WrkPrevCCTaxt
            End If
          End If
          If WrkDiff > 0 Then
            WrkSuspCCAdd = WrkDiff
          Else
            WrkSuspCCRed = Math.Abs(WrkDiff)
          End If
        End If
        If Not WrkPrevCC Then
          WrkBegBal = WrkTaxt - WrkPrevPaid
        Else
          WrkBegBal = WrkPrevCCTaxt - WrkPrevPaid
        End If
        If Trim(._SUSCD) <> "" Then
          If ._SUSDT >= WrkFrom And ._SUSDT <= WrkTo Then
            WrkEndBal = 0
            WrkXferSusp = WrkHistSusp
          End If
          If ._SUSDT > 0 And ._SUSDT < WrkFrom Then
            WrkPrevSusp = True
            WrkXferSusp = 0
          End If
        End If
        WrkEndBal = WrkBegBal + WrkCCAdd - WrkCCRed - WrkPaid - WrkRefunds

        Good = False
        If WrkTotal > 0 Or WrkBegBal <> 0 Or WrkEndBal <> 0 Or WrkInt <> 0 Or WrkLien <> 0 Or WrkRefunds <> 0 Or WrkCC Then
          Good = True
          K = 0
          WrkRptID = String.Empty
          If WrkBegBal < 0 Then
            K = 1
            WrkRptID = "CREDIT"
          End If
          If WrkPrevSusp Then
            K = 2
            WrkRptID = "SUSPENSE"
          End If
          If WrkXferSusp > 0 Then
            K = 2
            WrkRptID = "TRANSFER"
          End If
          If WrkDetail = "" Then GoTo DoTotals
          If WrkDetail = "Combine" Then
            dr = ds.Tables(0).NewRow
          Else
            Select Case WrkRptID
              Case String.Empty
                dr = ds.Tables(0).NewRow
              Case "CREDIT"
                dr = dsCR.Tables(0).NewRow
              Case "SUSPENSE", "TRANSFER"
                dr = dsSusp.Tables(0).NewRow
            End Select
          End If
          dr.Item("list") = ._LISTNo
          dr.Item("type") = ._TYPE
          dr.Item("year") = ._YEAR
          dr.Item("name") = ._NAME
          dr.Item("origbal") = WrkTaxt
          dr.Item("begbal") = WrkBegBal
          dr.Item("payments") = WrkPaid
          dr.Item("interest") = WrkInt
          dr.Item("fees") = WrkFee
          dr.Item("liens") = WrkLien
          dr.Item("XferSusp") = WrkXferSusp
          dr.Item("endbal") = WrkEndBal
          dr.Item("ccadd") = WrkCCAdd
          dr.Item("ccred") = WrkCCRed
          dr.Item("refunds") = WrkRefunds
          '.Columns.Add("Errors", Type.GetType("System.Decimal"))
          '.Columns.Add("ErrorsDiff", Type.GetType("System.Decimal"))
          dr.Item("rptid") = WrkRptID
          If WrkDetail = "Combine" Then
            ds.Tables(0).Rows.Add(dr)
          Else
            Select Case WrkRptID
              Case String.Empty
                ds.Tables(0).Rows.Add(dr)
              Case "CREDIT"
                dsCR.Tables(0).Rows.Add(dr)
              Case "SUSPENSE", "TRANSFER"
                dsSusp.Tables(0).Rows.Add(dr)
            End Select
          End If
          If MyFrmTXE08B.LblFilePath.Text <> String.Empty Then
            sw.WriteLine(DownloadCSV(WrkTaxt, WrkBegBal, WrkXferSusp, WrkCCAdd, WrkCCRed, WrkPaid, WrkRefunds, WrkEndBal,
              WrkInt, WrkFee, WrkLien, WrkRptID))
          End If
        End If
      End With

DoTotals:
      'Add to totals
      WrkTOrigBal(0) = WrkTOrigBal(0) + WrkTaxt
      WrkTOrigBal(1) = WrkTOrigBal(1) + WrkTaxt
      WrkTOrigBal(2) = WrkTOrigBal(2) + WrkTaxt
      If Good Then
        If K <> 2 Then
          WrkTBegBal(K) = WrkTBegBal(K) + WrkBegBal
        Else
          If WrkPrevSusp Then
            WrkTBegBal(2) = WrkTBegBal(2) + WrkBegBal
          End If
          If WrkXferSusp > 0 Then
            WrkTBegBal(0) = WrkTBegBal(0) + WrkBegBal
          End If
        End If
        WrkTXferSusp(K) = WrkTXferSusp(K) + WrkXferSusp
        If K <> 2 Then
          WrkTCCAdd(K) = WrkTCCAdd(K) + WrkCCAdd
          WrkTCCRed(K) = WrkTCCRed(K) + WrkCCRed
          WrkTPaid(K) = WrkTPaid(K) + WrkPaid
          WrkTInt(K) = WrkTInt(K) + WrkInt
          WrkTFee(K) = WrkTFee(K) + WrkFee
          WrkTLien(K) = WrkTLien(K) + WrkLien
          WrkTRefunds(K) = WrkTRefunds(K) + WrkRefunds
        Else
          WrkTCCAdd(0) = WrkTCCAdd(0) + WrkCCAdd - WrkSuspCCAdd
          WrkTCCRed(0) = WrkTCCRed(0) + WrkCCRed - WrkSuspCCRed
          WrkTPaid(0) = WrkTPaid(0) + WrkPaid - WrkSuspPaid
          WrkTInt(0) = WrkTInt(0) + WrkInt - WrkSuspInt
          WrkTLien(0) = WrkTLien(0) + WrkLien - WrkSuspLien '+ WrkFee - WrkSuspFee
          WrkTCCAdd(2) = WrkTCCAdd(2) + WrkSuspCCAdd
          WrkTCCRed(2) = WrkTCCRed(2) + WrkSuspCCRed
          WrkTPaid(2) = WrkTPaid(2) + WrkSuspPaid
          WrkTInt(2) = WrkTInt(2) + WrkSuspInt
          WrkTFee(2) = WrkTFee(2) + WrkSuspFee
          WrkTLien(2) = WrkTLien(2) + WrkSuspLien
          WrkTRefunds(2) = WrkTRefunds(2) + WrkSuspRefunds
        End If
        If WrkEndBal >= 0 Then
          WrkTEndBal(K) = WrkTEndBal(K) + WrkEndBal
        Else
          WrkTEndBalCR(K) = WrkTEndBalCR(K) + WrkEndBal
        End If
        'Add to suspense totals
        If WrkXferSusp > 0 Then
          WrkTXferSusp(0) = WrkTXferSusp(0) + WrkXferSusp
        End If
        'Add to Overpaid credits
        If K = 1 And WrkBegBal < 0 And WrkEndBal < WrkBegBal Then
          WrkOverCredit = WrkOverCredit + Math.Abs(WrkEndBal - WrkBegBal)
        End If
        'Add to Overpaid suspense
        If K = 2 Then
          If WrkBegBal < 0 Then
            If WrkEndBal < WrkBegBal Then
              WrkOverSusp = WrkOverSusp + Math.Abs(WrkEndBal - WrkBegBal)
            End If
          Else
            If WrkBegBal >= 0 And WrkEndBal < 0 Then
              WrkOverSusp = WrkOverSusp + Math.Abs(WrkEndBal)
            End If
          End If
        End If
      End If

      With myFrmProgress
        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .LblMsg.Text = "Records processed: " & Counter
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
        GoTo ReadNext
      End With
    End If

    If WrkTotals = "Combine" Then
      WriteSummaryTotals()
    Else
      WriteAudit()
      WriteTotals()
      WriteSummary()
    End If

    If MyFrmTXE08B.LblFilePath.Text <> String.Empty Then
      sw.Flush()
      sw.Close()
    End If
    myFrmProgress.Close()
    myTXINVQ.CloseFile()
    myTXHSTL1.CloseFile() 'asna added
    myTXCOEA.CloseFile()  'asna added 
    myUTCOEA.CloseFile()  'asna added 

  End Sub
  Private Sub WriteTotals()
    Dim K As Integer

    For K = 0 To 2
      Select Case K
        Case 0
          dr = dsTot.Tables(0).NewRow
        Case 1
          dr = dsTotCR.Tables(0).NewRow
        Case 2
          dr = dsTotSusp.Tables(0).NewRow
      End Select

      If WrkTBegBal(K) <> 0 Or WrkTXferSusp(K) <> 0 Or WrkTPaid(K) <> 0 Or WrkTEndBal(K) <> 0 _
      Or WrkTCCAdd(K) <> 0 Or WrkTCCRed(K) <> 0 Or WrkTInt(K) <> 0 Or WrkTRefunds(K) <> 0 _
      Or K = 0 Then
        dr.Item("type") = SaveType
        dr.Item("year") = SaveYear
        dr.Item("torigbal") = WrkTOrigBal(K)
        dr.Item("tbegbal") = WrkTBegBal(K)
        dr.Item("txfersusp") = WrkTXferSusp(K)
        dr.Item("tccadd") = WrkTCCAdd(K)
        dr.Item("tccred") = WrkTCCRed(K)
        dr.Item("tpayments") = WrkTPaid(K)
        dr.Item("tinterest") = WrkTInt(K)
        dr.Item("tfees") = WrkTFee(K)
        dr.Item("tliens") = WrkTLien(K)
        dr.Item("trefunds") = WrkTRefunds(K)
        dr.Item("tendbal") = WrkTEndBal(K)
        dr.Item("tendbalcr") = WrkTEndBalCR(K)
        If K = 1 Then
          dr.Item("toverpaid") = WrkOverCredit
        Else
          dr.Item("toverpaid") = 0
        End If
        dr.Item("terrors") = 0
        dr.Item("terrorsdiff") = 0
        Select Case K
          Case 0
            dsTot.Tables(0).Rows.Add(dr)
          Case 1
            dsTotCR.Tables(0).Rows.Add(dr)
          Case 2
            dsTotSusp.Tables(0).Rows.Add(dr)
        End Select
      End If

    Next
  End Sub
  Private Sub WriteAudit()
    Dim WrkAdjBal As Decimal
    Dim WrkInterest As Decimal
    Dim WrkFees As Decimal
    Dim WrkLiens As Decimal
    Dim WrkCollect As Decimal

    dr = dsAudit.Tables(0).NewRow
    dr.Item("type") = SaveType
    dr.Item("year") = SaveYear
    dr.Item("tbegbal") = WrkTBegBal(0)
    If myTOWN._TOWNBR = 45 Then 'East Lyme
      myTXE08RV.GetOneRecordP(SaveYear, SaveType, WrkFrom)
      If Not myTXE08RV.RecordNotFound Then
        dr.Item("tbegbal") = dr.Item("tbegbal") - myTXE08RV._RCVBAL
        dr.Item("trecovery") = myTXE08RV._RCVBAL
        If Not WrkRecovery Then WrkRecovery = True
      Else
        dr.Item("trecovery") = 0
      End If
    End If
    dr.Item("tccadd") = WrkTCCAdd(0)
    dr.Item("tccred") = WrkTCCRed(0)
    If WrkRecovery Then
      WrkAdjBal = WrkTBegBal(0) + WrkTCCAdd(0) - WrkTCCRed(0) + dr.Item("trecovery")
    Else
      WrkAdjBal = WrkTBegBal(0) + WrkTCCAdd(0) - WrkTCCRed(0)
    End If
    dr.Item("tadjbal") = WrkAdjBal
    dr.Item("tpayments") = WrkTPaid(0)
    WrkInterest = WrkTInt(0) + WrkTInt(1)
    dr.Item("tinterest") = WrkInterest
    WrkFees = WrkTFee(0) + WrkTFee(1)
    dr.Item("tfees") = WrkFees
    WrkLiens = WrkTLien(0) + WrkTLien(1)
    dr.Item("tliens") = WrkLiens
    'MK 11/26/25 Begin
    'dr.Item("toverpaid") = Math.Abs(WrkTEndBalCR(0)) + Math.Abs(WrkTCCRed(1)) + WrkOverCredit
    dr.Item("toverpaid") = Math.Abs(WrkTEndBalCR(0)) + WrkOverCredit + WrkOverSusp
    'MK 11/26/25 End 
    dr.Item("trefunds") = Math.Abs(WrkTRefunds(0)) + Math.Abs(WrkTRefunds(1)) + +Math.Abs(WrkTRefunds(2))
    dr.Item("suspayments") = WrkTPaid(2)
    dr.Item("susinterest") = WrkTInt(2)
    dr.Item("credcc") = WrkTCCAdd(1) - WrkTCCRed(1) + WrkTCCAdd(2) - WrkTCCRed(2)
    dr.Item("credpay") = WrkTPaid(1)
    dr.Item("txfersusp") = WrkTXferSusp(0)
    WrkCollect = WrkTPaid(0) + WrkTPaid(1) + WrkInterest + WrkFees + WrkLiens
    dr.Item("tcollect") = WrkCollect
    dr.Item("tendbal") = WrkTEndBal(0)
    dsAudit.Tables(0).Rows.Add(dr)
  End Sub
  Private Sub WriteSummaryTotals()
    Dim K As Integer

    For K = 0 To 2
      dr = dsTot.Tables(0).NewRow
      Select Case K
        Case 0
          dr.Item("rptid") = ""
        Case 1
          dr.Item("rptid") = "CR"
        Case 2
          dr.Item("rptid") = "Susp"
      End Select

      If WrkTBegBal(K) <> 0 Or WrkTXferSusp(K) <> 0 Or WrkTPaid(K) <> 0 Or WrkTEndBal(K) <> 0 _
      Or WrkTCCAdd(K) <> 0 Or WrkTCCRed(K) <> 0 Or WrkTInt(K) <> 0 Or WrkTRefunds(K) <> 0 _
      Or K = 0 Then
        dr.Item("type") = SaveType
        dr.Item("year") = SaveYear
        If K = 0 Then
          dr.Item("torigbal") = WrkTOrigBal(K)
        Else
          dr.Item("torigbal") = 0
        End If
        dr.Item("tbegbal") = WrkTBegBal(K)
        dr.Item("txfersusp") = WrkTXferSusp(K)
        dr.Item("tccadd") = WrkTCCAdd(K)
        dr.Item("tccred") = WrkTCCRed(K)
        dr.Item("tpayments") = WrkTPaid(K)
        dr.Item("tinterest") = WrkTInt(K)
        dr.Item("tfees") = WrkTFee(K)
        dr.Item("tliens") = WrkTLien(K)
        dr.Item("trefunds") = WrkTRefunds(K)
        dr.Item("tendbal") = WrkTEndBal(K)
        dr.Item("tendbalcr") = WrkTEndBalCR(K)
        dr.Item("terrors") = 0
        dr.Item("terrorsdiff") = 0
        dsTot.Tables(0).Rows.Add(dr)
      End If
    Next
  End Sub
  Private Sub WriteSummary()
    Dim WrkSumOrigBal As Decimal
    Dim WrkSumBegBal As Decimal
    Dim WrkSumPaid As Decimal
    Dim WrkSumCCAdd As Decimal
    Dim WrkSumCCRed As Decimal
    Dim WrkSumInt As Decimal
    Dim WrkSumFee As Decimal
    Dim WrkSumLien As Decimal
    Dim WrkSumRefunds As Decimal
    Dim WrkSumEndBal As Decimal

    WrkSumOrigBal = WrkTOrigBal(0)
    WrkSumBegBal = WrkTBegBal(0) + WrkTBegBal(1) + WrkTBegBal(2)
    WrkSumCCAdd = WrkTCCAdd(0) + WrkTCCAdd(1) + WrkTCCAdd(2)
    WrkSumCCRed = WrkTCCRed(0) + WrkTCCRed(1) + WrkTCCRed(2)
    WrkSumPaid = WrkTPaid(0) + WrkTPaid(1) + WrkTPaid(2)
    WrkSumInt = WrkTInt(0) + WrkTInt(1) + WrkTInt(2)
    WrkSumRefunds = WrkTRefunds(0) + WrkTRefunds(1) + WrkTRefunds(2)
    WrkSumFee = WrkTFee(0) + WrkTFee(1) + WrkTFee(2)
    WrkSumLien = WrkTLien(0) + WrkTLien(1) + WrkTLien(2)
    WrkSumEndBal = WrkTEndBal(0) + WrkTEndBal(1) + WrkTEndBal(2) _
      + WrkTEndBalCR(0) + WrkTEndBalCR(1) + WrkTEndBalCR(2)
    If WrkSumOrigBal <> 0 Or WrkSumPaid <> 0 Or WrkSumEndBal <> 0 _
      Or WrkSumCCAdd <> 0 Or WrkSumCCRed <> 0 Or WrkSumInt <> 0 Or WrkSumRefunds <> 0 Then
      dr = dsTotSum.Tables(0).NewRow
      dr.Item("rptid") = "Total"
      dr.Item("type") = SaveType
      dr.Item("year") = SaveYear
      dr.Item("torigbal") = WrkSumOrigBal
      dr.Item("tbegbal") = WrkSumBegBal
      dr.Item("tccadd") = WrkSumCCAdd
      dr.Item("tccred") = WrkSumCCRed
      dr.Item("tpayments") = WrkSumPaid
      dr.Item("tinterest") = WrkSumInt
      dr.Item("tfees") = WrkSumFee
      dr.Item("tliens") = WrkSumLien
      dr.Item("trefunds") = WrkSumRefunds
      dr.Item("tendbal") = WrkSumEndBal
      dr.Item("terrors") = 0
      dr.Item("terrorsdiff") = 0
      dsTotSum.Tables(0).Rows.Add(dr)
    End If

  End Sub
  Private Sub ClearTotals()
    WrkOverCredit = 0
    WrkOverSusp = 0
    ReDim WrkTOrigBal(2)
    ReDim WrkTBegBal(2)
    ReDim WrkTXferSusp(2)
    ReDim WrkTCCAdd(2)
    ReDim WrkTCCRed(2)
    ReDim WrkTPaid(2)
    ReDim WrkTInt(2)
    ReDim WrkTLien(2)
    ReDim WrkTFee(2)
    ReDim WrkTEndBal(2)
    ReDim WrkTEndBalCR(2)
    ReDim WrkTRefunds(2)
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
  Private Function BuildWrkTypes(ByVal WrkSelTypes As String) As String
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
    WrkStrOut = sbSelect.ToString

    sbSelect = Nothing
    Return WrkStrOut
  End Function
  Private Function DownloadCSV(ByVal WrkTaxt As Decimal, ByVal WrkBegBal As Decimal, ByVal WrkXferSusp As Decimal,
    ByVal WrkCCAdd As Decimal, ByVal WrkCCRed As Decimal, ByVal WrkPaid As Decimal, ByVal WrkRefunds As Decimal,
     ByVal WrkEndBal As Decimal, ByVal WrkInt As Decimal, ByVal WrkFee As Decimal, ByVal WrkLien As Decimal,
     ByVal WrkRptID As String) As String
    Dim sb As StringBuilder
    Const CComma As String = ","
    Const CQuote As String = Chr(34)

    With myTXINVQ
      sb = New StringBuilder
      sb.Append(._LISTNo)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(._TYPE)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(._YEAR)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._NAME))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(WrkTaxt)
      sb.Append(CComma)
      sb.Append(WrkBegBal)
      sb.Append(CComma)
      sb.Append(WrkXferSusp)
      sb.Append(CComma)
      sb.Append(WrkCCAdd)
      sb.Append(CComma)
      sb.Append(WrkCCRed)
      sb.Append(CComma)
      sb.Append(WrkPaid)
      sb.Append(CComma)
      sb.Append(WrkRefunds)
      sb.Append(CComma)
      sb.Append(WrkEndBal)
      sb.Append(CComma)
      sb.Append(WrkInt)
      sb.Append(CComma)
      sb.Append(WrkFee)
      sb.Append(CComma)
      sb.Append(WrkLien)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(WrkRptID)
      sb.Append(CQuote)
    End With
    Return sb.ToString
  End Function
  Private Function HeadingsCSV() As String
    Dim sb As StringBuilder
    Dim CComma As String = ","

    sb = New StringBuilder
    sb.Append("List No")
    sb.Append(CComma)
    sb.Append("Type")
    sb.Append(CComma)
    sb.Append("Year")
    sb.Append(CComma)
    sb.Append("Name")
    sb.Append(CComma)
    sb.Append("Original Tax")
    sb.Append(CComma)
    sb.Append("Starting Balance")
    sb.Append(CComma)
    sb.Append("Transfer to Suspense")
    sb.Append(CComma)
    sb.Append("C/C Additions")
    sb.Append(CComma)
    sb.Append("C/C Reductions")
    sb.Append(CComma)
    sb.Append("Payments")
    sb.Append(CComma)
    sb.Append("Reductions")
    sb.Append(CComma)
    sb.Append("Ending Balance")
    sb.Append(CComma)
    sb.Append("Interest")
    sb.Append(CComma)
    sb.Append("Fees")
    sb.Append(CComma)
    sb.Append("Liens")
    sb.Append(CComma)
    sb.Append("Report")
    Return sb.ToString
  End Function
  Private Function SafeDecimal(obj As Object) As Decimal
    If IsDBNull(obj) Then Return 0D
    Return Convert.ToDecimal(obj)
  End Function

End Module
