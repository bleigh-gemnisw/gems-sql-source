Imports System.IO
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXHSTQ As TXHSTQ.MyData
  Dim myMUNMIL As MUNMIL.MyData
  Dim myMUNMILD As MUNMILD.MyData
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXHST As TXHSTL1.MyData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim sw As StreamWriter

  Dim WrkFrom As Integer
  Dim WrkTo As Integer
  Dim WrkBatchNo As Integer
  Dim WrkGLYear As Integer
  Dim WrkGLYearSU As Integer
  Dim WrkSuppSame As Boolean
  Dim WrkAnd As String
  Dim WrkOr As String
  Dim ArrCode(50) As String
  Dim ArrAmt(50) As Decimal
  Dim DsYear(20) As Integer
  Dim DsAmt(20) As Decimal
  Dim WrkRefunds As Decimal
  Public Sub PrtReport()

    myTXHSTQ = New TXHSTQ.MyData(myDBConnect)
    myMUNMIL = New MUNMIL.MyData()
    myMUNMIL.MyDBConn = myDBConnect
    myMUNMILD = New MUNMILD.MyData()
    myMUNMILD.MyDBConn = myDBConnect
    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXHST = New TXHSTL1.MyData(myDBConnect)

    With MyFrmGLA45B
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
      WrkBatchNo = MyUtils.CnvSng(.TxtBatch.Text)
      WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
      WrkSuppSame = .ChkSuppSame.Checked
    End With
    If WrkSuppSame Then
      WrkGLYearSU = WrkGLYear
    Else
      WrkGLYearSU = WrkGLYear - 1
    End If

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
    Else
      ds.Clear()
      Array.Clear(ArrCode, 0, 50)
      Array.Clear(ArrAmt, 0, 50)
      Array.Clear(DsYear, 0, 20)
      Array.Clear(DsAmt, 0, 20)
      WrkRefunds = 0
    End If
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.WrkRefunds = WrkRefunds
    MyCrViewer.Show()

  End Sub
  Public Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Acct", Type.GetType("System.String"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("Debit", Type.GetType("System.Decimal"))
      .Columns.Add("Credit", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkFilePath As String
    Dim WrkDsAdv As Decimal
    Dim WrkDsCurr As Decimal
    Dim WrkDsPrior As Decimal
    Dim WrkPPAudit As Decimal
    Dim WrkCode As String
    Dim Counter As Integer
    Dim I As Integer
    Dim K As Integer

    If MyServerName = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    Counter = 0
    WrkQry = "PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo
    WrkQry = WrkQry & WrkAnd & "RCODE <> 'I'" & WrkAnd & "RCODE <> 'V'"
    If WrkBatchNo > 0 Then
      WrkQry = WrkQry & WrkAnd & "BATCHN= " & WrkBatchNo
    End If

    WrkSort = "PDATE,BATCHN"
    myTXHSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    WrkFilePath = MyAppSettings.FilePath & "/gems-" & WrkFrom & "-" & WrkTo & ".txt"
    sw = New StreamWriter(WrkFilePath)

ReadNext:
    myTXHSTQ.ReadQry()
    If Not myTXHSTQ.IsEOF Then
      With myTXHSTQ
        Counter = Counter + 1
        WriteFile()
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

CloseFiles:
    myTXHSTQ.CloseFile()
    myMUNMIL.CloseFile()

    WrkPPAudit = GetPPAudit()

    WrkDsAdv = 0
    WrkDsCurr = 0
    WrkDsPrior = 0
    'Debt Service
    For I = 0 To 20
      If IsNothing(DsYear(I)) Then Exit For
      dr = ds.Tables(0).NewRow
      myMUNMILD.GetOneRecordP(DsYear(I))
      If DsYear(I) > WrkGLYear Then
        WrkDsAdv = DsAmt(I) * myMUNMILD._DSPCT
      End If
      If DsYear(I) = WrkGLYear Then
        WrkDsCurr = DsAmt(I) * myMUNMILD._DSPCT
      End If
      If DsYear(I) < WrkGLYear Then
        WrkDsPrior = WrkDsPrior + (DsAmt(I) * myMUNMILD._DSPCT)
      End If
    Next I
    If WrkDsAdv <> 0 Then
      WrkCode = "ADDB"
      K = LookupCode(WrkCode)
      ArrCode(K) = WrkCode
      ArrAmt(K) = WrkDsAdv
    End If
    If WrkDsCurr <> 0 Or WrkDsPrior <> 0 Then
      WrkCode = "DBSRV"
      K = LookupCode(WrkCode)
      ArrCode(K) = WrkCode
      ArrAmt(K) = WrkDsCurr + WrkDsPrior
    End If

    For I = 0 To 50
      If IsNothing(ArrCode(I)) Then Exit For
      dr = ds.Tables(0).NewRow
      'Reduce Usage by Debt Service Amount 
      If ArrCode(I) = "ADSWR" Then
        ArrAmt(I) = ArrAmt(I) - WrkDsAdv
      End If
      If ArrCode(I) = "SWRUS" Then
        ArrAmt(I) = ArrAmt(I) - WrkDsCurr
      End If
      If ArrCode(I) = "PRSWR" Then
        ArrAmt(I) = ArrAmt(I) - WrkDsPrior
      End If
      'Reduce Prior by PP Audit Amount 
      If ArrCode(I) = "PRIOR" Then
        ArrAmt(I) = ArrAmt(I) - WrkPPAudit
      End If
      myMUNMIL.GetOneRecordP(ArrCode(I))
      dr.Item("acct") = Trim(myMUNMIL._ORIG) & "-" & Trim(myMUNMIL._OBJ)
      dr.Item("desc") = Trim(myMUNMIL._DESC)
      If myMUNMIL._DBCR = "D" Then
        If ArrAmt(I) > 0 Then
          dr.Item("debit") = ArrAmt(I)
          dr.Item("credit") = 0
        Else
          dr.Item("debit") = 0
          dr.Item("credit") = Math.Abs(ArrAmt(I))
        End If
      Else
        If ArrAmt(I) > 0 Then
          dr.Item("debit") = 0
          dr.Item("credit") = ArrAmt(I)
        Else
          dr.Item("debit") = Math.Abs(ArrAmt(I))
          dr.Item("credit") = 0
        End If
      End If
      ds.Tables(0).Rows.Add(dr)
      If ArrAmt(I) <> 0 Then
        WriteMUNJE(ArrCode(I), dr.Item("debit"), dr.Item("credit"))
      End If
    Next I
    sw.Close()

  End Sub
  Private Sub WriteFile()
    Dim WrkCode As String
    Dim WrkAmt As Decimal
    Dim K As Integer

    With myTXHSTQ
      'Debit
      WrkAmt = ._PAMT + ._IAMT + ._LAMT + ._PCAMT
      If Trim(._ADJCD) <> "R" Then
        Select Case ._BATCHA
          Case "B"
            WrkCode = "CSHLB"
          Case Else
            WrkCode = "CSH"
        End Select
        K = LookupCode(WrkCode)
        ArrCode(K) = WrkCode
        ArrAmt(K) = ArrAmt(K) + WrkAmt
        'Lock Box interest is seperate
        'Select Case ._BATCHA
        'Case "B"
        '  If ._IAMT <> 0 Then
        '    WrkCode = "CSHLI"
        '    K = LookupCode(WrkCode)
        '    ArrCode(K) = WrkCode
        '    ArrAmt(K) = ArrAmt(K) + WrkAmt
        '  End If
        'End Select
      Else
        WrkRefunds = WrkRefunds + Math.Abs(WrkAmt)
      End If
      'Credit
      If Trim(._ADJCD) <> "R" Then 'Omit Refunds
        Select Case ._TYPE
          Case "A", "L"
            DRSewer()
          Case "B"
            DRWater()
          Case "E"
            DRCPace()
          Case "F"
            DRFlood()
          Case "U"
            DRUsage()
          Case Else
            DRTax()
        End Select
      End If
    End With
  End Sub
  Private Sub DRSewer()
    Dim WrkCode As String
    Dim WrkAmt As Decimal
    Dim K As Integer

    With myTXHSTQ
      'Principal 
      WrkCode = String.Empty
      WrkAmt = ._PAMT + ._IAMT + ._LAMT + ._PCAMT
      If WrkAmt <> 0 Then
        WrkCode = "SWRAS"
        K = LookupCode(WrkCode)
        ArrCode(K) = WrkCode
        ArrAmt(K) = ArrAmt(K) + WrkAmt
      End If
    End With
  End Sub
  Private Sub DRWater()
    Dim WrkCode As String
    Dim WrkAmt As Decimal
    Dim K As Integer

    With myTXHSTQ
      'Principal 
      WrkCode = String.Empty
      WrkAmt = ._PAMT + ._IAMT + ._LAMT + ._PCAMT
      If WrkAmt <> 0 Then
        WrkCode = "WTRAS"
        K = LookupCode(WrkCode)
        ArrCode(K) = WrkCode
        ArrAmt(K) = ArrAmt(K) + WrkAmt
      End If
    End With
  End Sub
  Private Sub DRFlood()
    Dim WrkCode As String
    Dim WrkAmt As Decimal
    Dim K As Integer

    With myTXHSTQ
      'Principal 
      WrkCode = String.Empty
      WrkAmt = ._PAMT + ._IAMT + ._LAMT + ._PCAMT
      If WrkAmt <> 0 Then
        WrkCode = "FLOOD"
        K = LookupCode(WrkCode)
        ArrCode(K) = WrkCode
        ArrAmt(K) = ArrAmt(K) + WrkAmt
      End If
    End With
  End Sub
  Private Sub DRCPace()
    Dim WrkCode As String
    Dim WrkAmt As Decimal
    Dim K As Integer

    With myTXHSTQ
      'Principal 
      WrkCode = String.Empty
      WrkAmt = ._PAMT + ._IAMT + ._LAMT + ._PCAMT
      If WrkAmt <> 0 Then
        WrkCode = "CPACE"
        K = LookupCode(WrkCode)
        ArrCode(K) = WrkCode
        ArrAmt(K) = ArrAmt(K) + WrkAmt
      End If
    End With
  End Sub
  Private Sub DRUsage()
    Dim WrkCode As String
    Dim WrkAmt As Decimal
    Dim K As Integer

    With myTXHSTQ
      'Principal 
      WrkCode = String.Empty
      WrkAmt = ._PAMT
      If ._YEAR > WrkGLYear Then
        WrkCode = "ADSWR"
      End If
      If ._YEAR = WrkGLYear Then
        WrkCode = "SWRUS"
      End If
      If ._YEAR < WrkGLYear Then
        WrkCode = "PRSWR"
      End If
      If WrkAmt <> 0 Then
        K = LookupCode(WrkCode)
        ArrCode(K) = WrkCode
        ArrAmt(K) = ArrAmt(K) + WrkAmt
        K = LookupYear(._YEAR)
        DsYear(K) = ._YEAR
        DsAmt(K) = DsAmt(K) + WrkAmt
      End If
      'Interest, Liens & Fees
      WrkCode = String.Empty
      WrkAmt = ._IAMT + ._LAMT + ._PCAMT
      If WrkAmt <> 0 Then
        WrkCode = "INTSW"
        K = LookupCode(WrkCode)
        ArrCode(K) = WrkCode
        ArrAmt(K) = ArrAmt(K) + WrkAmt
      End If
    End With
  End Sub
  Private Sub DRTax()
    Dim WrkCode As String
    Dim WrkAmt As Decimal
    Dim K As Integer

    With myTXHSTQ
      WrkCode = String.Empty
      If ._PAMT <> 0 Then
        If ._RCODE = "S" Then
          WrkCode = "SUSP"
        Else
          If (._TYPE <> "S" And ._YEAR > WrkGLYear) Or (._TYPE = "S" And ._YEAR > WrkGLYearSU) Then
            WrkCode = "ADVAN"
          End If
          If (._TYPE <> "S" And ._YEAR = WrkGLYear) Or (._TYPE = "S" And ._YEAR = WrkGLYearSU) Then
            WrkCode = "CURR"
          End If
          If (._TYPE <> "S" And ._YEAR < WrkGLYear) Or (._TYPE = "S" And ._YEAR < WrkGLYearSU) Then
            WrkCode = "PRIOR"
          End If
        End If
        K = LookupCode(WrkCode)
        ArrCode(K) = WrkCode
        ArrAmt(K) = ArrAmt(K) + ._PAMT
      End If
      'Interest/Liens
      WrkCode = String.Empty
      WrkAmt = ._IAMT + ._LAMT
      If WrkAmt <> 0 Then
        WrkCode = "INTLN"
        K = LookupCode(WrkCode)
        ArrCode(K) = WrkCode
        ArrAmt(K) = ArrAmt(K) + WrkAmt
      End If
      'Fees
      WrkCode = String.Empty
      WrkAmt = ._PCAMT
      If WrkAmt <> 0 Then
        WrkCode = "FEES"
        K = LookupCode(WrkCode)
        ArrCode(K) = WrkCode
        ArrAmt(K) = ArrAmt(K) + WrkAmt
      End If
    End With
  End Sub
  Private Function GetPPAudit() As Decimal
    Dim DsTXHST As DataSet = New DataSet
    Dim SaveQry As String
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAmt As Decimal
    Dim WrkPDate As Integer
    Dim WrkCode As String
    Dim Counter As Integer
    Dim J As Integer
    Dim K As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    SaveQry = "icode<>'I'"
    WrkQry = SaveQry & WrkAnd & "STCD1='Y'"
    WrkQry = WrkQry & WrkOr & SaveQry & WrkAnd & "STCD2='Y'"
    WrkQry = WrkQry & WrkOr & SaveQry & WrkAnd & "STCD3='Y'"
    WrkQry = WrkQry & WrkOr & SaveQry & WrkAnd & "STCD4='Y'"
    WrkQry = WrkQry & WrkOr & SaveQry & WrkAnd & "STCD5='Y'"
    WrkSort = "YEAR, TYPE"
    myTXINVQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkAmt = 0
ReadNext:
    myTXINVQ.ReadQry()
    If Not myTXINVQ.IsEOF Then
      With myTXINVQ
        Counter = Counter + 1
        DsTXHST = myTXHST.GetbyList(._LISTNo, ._YEAR, ._TYPE, 9999)
      End With

      If DsTXHST.Tables(0).Rows.Count = 0 Then GoTo NextRec
      For J = 0 To DsTXHST.Tables(0).Rows.Count - 1
        With DsTXHST.Tables(0).Rows(J)
          WrkPDate = .Item("pdate")
          If WrkPDate >= WrkFrom Then
            If WrkPDate <= WrkTo Then
              If .Item("rcode") = "I" Then Continue For
              If .Item("rcode") = "V" Then Continue For
              WrkAmt = WrkAmt + .Item("pamt")
              'WrkInterest = .Item("iamt")
              'WrkLien = .Item("lamt")
              'WrkPenalty = .Item("pcamt")
            End If
          End If
        End With
      Next

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

    WrkCode = "PPAUD"
    K = LookupCode(WrkCode)
    ArrCode(K) = WrkCode
    ArrAmt(K) = ArrAmt(K) + WrkAmt

    myFrmProgress.Close()
    myTXINVQ.CloseFile()
    Return WrkAmt
  End Function

  Private Sub WriteMUNJE(ByVal WrkCode As String, ByVal WrkDebit As Decimal, ByVal WrkCredit As Decimal)

    Dim sb As StringBuilder
    Dim wrknum As Decimal

    'Create Journal Entry
    sb = New StringBuilder
    sb.Append(MyUtils.JustifyLeft(myMUNMIL._ORIG, 8)) 'Organization
    sb.Append(MyUtils.JustifyLeft(myMUNMIL._OBJ, 6)) 'Object
    sb.Append(MyUtils.JustifyLeft("", 5)) 'Project
    sb.Append(MyUtils.JustifyLeft("", 35)) 'Full Account
    sb.Append(MyUtils.JustifyLeft("", 30)) 'Comment
    sb.Append(MyUtils.JustifyLeft("", 10))
    sb.Append(MyUtils.JustifyLeft("", 12))
    If WrkCredit > 0 Then
      sb.Append("C") 'Credit
      wrknum = WrkCredit
    Else
      sb.Append("D") 'Debit
      wrknum = WrkDebit
    End If
    sb.Append(Format(wrknum, "0000000000.00")) 'Amount
    sb.Append(" ") 'Encumb 
    sb.Append(Format(0, "0000000000000"))
    sb.Append(Space(5)) 'Allocation Code
    sb.Append("A") 'Transaction Type
    sb.Append(" ") 'Project Type
    sb.Append(Space(43)) 'Project String
    sw.WriteLine(sb.ToString)
    sb = Nothing

  End Sub
  Private Function LookupCode(ByVal Code As String) As Integer
    Dim I As Integer

    For I = 0 To ArrCode.GetUpperBound(0)
      If ArrCode(I) = "" Then
        Return I
      End If
      If Code = ArrCode(I) Then
        Return I
      End If
    Next
    Return -1

  End Function
  Private Function LookupYear(ByVal Year As Integer) As Integer
    Dim I As Integer

    For I = 0 To DsYear.GetUpperBound(0)
      If DsYear(I) = 0 Then
        Return I
      End If
      If Year = DsYear(I) Then
        Return I
      End If
    Next
    Return -1

  End Function
End Module
