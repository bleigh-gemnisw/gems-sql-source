Imports System.IO
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXHSTQ As TXHSTQ.myData
  Dim myTXGLNB As TXGLNB.myData
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
  Dim ArrYear(500) As Integer
  Dim ArrTran(500) As String
  Dim ArrCode(500) As String
  Dim ArrAmt(500) As Decimal
  Dim WrkErrFees As Boolean
  Public Sub PrtReport()

    myTXHSTQ = New TXHSTQ.MyData(myDBConnect)
    myTXGLNB = New TXGLNB.MyData()
    myTXGLNB.MyDBConn = myDBConnect

    With MyFrmGLA48B
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
      Array.Clear(ArrYear, 0, 500)
      Array.Clear(ArrTran, 0, 500)
      Array.Clear(ArrCode, 0, 500)
      Array.Clear(ArrAmt, 0, 500)
    End If
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.Show()

  End Sub
  Public Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Type", Type.GetType("System.String"))
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
    Dim Counter As Integer
    Dim I As Integer
    Dim WrkPlus As Decimal
    Dim WrkMinus As Decimal
    Dim Good As Boolean

    If MyAS400 Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    Counter = 0
    WrkQry = "PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo
    WrkQry = WrkQry & WrkAnd & "RCODE <> 'I'" & WrkAnd & "RCODE <> 'V'"
    'WrkQry = WrkQry & WrkAnd & "BATCHN > 0"
    If WrkBatchNo > 0 Then
      WrkQry = WrkQry & WrkAnd & "BATCHN= " & WrkBatchNo
    End If

    WrkSort = "PDATE, BATCHN"
    myTXHSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    WrkFilePath = MyAppSettings.FilePath & "/gems-" & WrkFrom & "-" & WrkTo & ".csv"
    sw = New StreamWriter(WrkFilePath)

ReadNext:
    myTXHSTQ.ReadQry()
    If Not myTXHSTQ.IsEOF Then
      With myTXHSTQ
        Counter = Counter + 1
        DRTax(._TYPE)
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
    myTXGLNB.CloseFile()

    'WrkPlus are normal transactions, WrkMinus are refunds and negative adjustments. 
    For I = 0 To 500
      If IsNothing(ArrCode(I)) Then Exit For
      Good = False
      dr = ds.Tables(0).NewRow
      If ArrAmt(I) > 0 Then
        WrkPlus = ArrAmt(I)
        WrkMinus = 0
      Else
        WrkPlus = 0
        WrkMinus = Math.Abs(ArrAmt(I))
      End If
      myTXGLNB.GetOneRecordP(ArrYear(I), ArrTran(I), ArrCode(I))
      'Debit
      If Not myTXGLNB.RecordNotFound Then
        dr.Item("acct") = Trim(myTXGLNB._ACCTDB)
        dr.Item("desc") = Trim(myTXGLNB._DESCR)
        Good = True
      Else
        dr.Item("acct") = ""
        dr.Item("desc") = "Missing: " & ArrYear(I) & "/" & ArrTran(I) & "/" & ArrCode(I)
      End If
      dr.Item("debit") = WrkPlus
      dr.Item("credit") = WrkMinus
      ds.Tables(0).Rows.Add(dr)
      WriteGLFile(ArrYear(I), ArrTran(I), ArrCode(I), dr.Item("acct"), WrkPlus, WrkMinus)
      If Not Good Then Continue For

      'Credit
      dr = ds.Tables(0).NewRow
      dr.Item("acct") = Trim(myTXGLNB._ACCTCR)
      dr.Item("desc") = Trim(myTXGLNB._DESCR)
      dr.Item("debit") = WrkMinus
      dr.Item("credit") = WrkPlus
      ds.Tables(0).Rows.Add(dr)
      WriteGLFile(ArrYear(I), ArrTran(I), ArrCode(I), dr.Item("acct"), WrkMinus, WrkPlus)

      If Trim(myTXGLNB._ACCTDB2) <> "" Then
        'Debit
        dr = ds.Tables(0).NewRow
        dr.Item("acct") = Trim(myTXGLNB._ACCTDB2)
        dr.Item("desc") = Trim(myTXGLNB._DESCR)
        dr.Item("debit") = WrkPlus
        dr.Item("credit") = WrkMinus
        ds.Tables(0).Rows.Add(dr)
        WriteGLFile(ArrYear(I), ArrTran(I), ArrCode(I), dr.Item("acct"), WrkPlus, WrkMinus)

        'Credit
        dr = ds.Tables(0).NewRow
        dr.Item("acct") = Trim(myTXGLNB._ACCTCR2)
        dr.Item("desc") = Trim(myTXGLNB._DESCR)
        dr.Item("debit") = WrkMinus
        dr.Item("credit") = WrkPlus
        ds.Tables(0).Rows.Add(dr)
        WriteGLFile(ArrYear(I), ArrTran(I), ArrCode(I), dr.Item("acct"), WrkMinus, WrkPlus)
      End If
    Next I
    sw.Close()
  End Sub
  Private Sub DRTax(ByVal WrkTran As String)
    Dim WrkCurr As Boolean
    Dim WrkYear As Integer
    Dim WrkCode As String
    Dim WrkAmt As Decimal
    Dim K As Integer

    WrkCurr = False
    With myTXHSTQ
      WrkYear = ._YEAR
      Select Case ._TYPE
        Case "A"
          If WrkYear = WrkGLYear + 1 Then
            WrkCurr = True
            WrkTran = ._DIST
          End If
        Case "S"
          If WrkYear = WrkGLYearSU Then
            WrkCurr = True
          End If
        Case Else
          If WrkYear = WrkGLYear Then
            WrkCurr = True
          End If
      End Select
      'Suspense 
      If ._RCODE = "S" Then
        If ._PAMT <> 0 Then
          WrkCode = "SUSP"
          K = LookupCode(0, WrkTran, WrkCode)
          ArrYear(K) = 0
          ArrCode(K) = WrkCode
          ArrTran(K) = WrkTran
          ArrAmt(K) = ArrAmt(K) + Math.Abs(._PAMT)
        End If
      Else
        'Principal 
        If ._PAMT <> 0 Then
          WrkCode = "PRIN"
          K = LookupCode(WrkYear, WrkTran, WrkCode)
          ArrYear(K) = WrkYear
          ArrCode(K) = WrkCode
          ArrTran(K) = WrkTran
          ArrAmt(K) = ArrAmt(K) + ._PAMT
        End If
      End If
      'Interest
      WrkCode = String.Empty
      WrkAmt = ._IAMT
      If WrkAmt <> 0 Then
        If WrkCurr Then
          WrkCode = "INCUR"
        Else
          WrkCode = "INPRV"
        End If
        K = LookupCode(0, WrkTran, WrkCode)
        ArrYear(K) = 0
        ArrCode(K) = WrkCode
        ArrTran(K) = WrkTran
        ArrAmt(K) = ArrAmt(K) + WrkAmt
      End If
      'Lien
      WrkCode = String.Empty
      WrkAmt = ._LAMT
      If WrkAmt <> 0 Then
        WrkCode = "LIEN"
        K = LookupCode(0, WrkTran, WrkCode)
        ArrYear(K) = 0
        ArrCode(K) = WrkCode
        ArrTran(K) = WrkTran
        ArrAmt(K) = ArrAmt(K) + WrkAmt
      End If
      'Fees
      WrkCode = String.Empty
      WrkAmt = ._PCAMT
      If WrkAmt <> 0 Then
        Select Case ._PENCD
          Case = "WA", "NF"
            WrkCode = "FE-" & Trim(._PENCD)
          Case = "BI"
            If WrkCurr Then
              WrkCode = "BOND"
            Else
              WrkCode = "BONDP"
            End If
          Case Else
            WrkCode = "FEES"
        End Select
        K = LookupCode(0, WrkTran, WrkCode)
        ArrYear(K) = 0
        ArrCode(K) = WrkCode
        ArrTran(K) = WrkTran
        ArrAmt(K) = ArrAmt(K) + WrkAmt
      End If
    End With
  End Sub
  Private Sub WriteGLFile(ByVal WrkYear As Integer, ByVal WrkTran As String, ByVal WrkCode As String,
   ByVal WrkAcct As String, ByVal WrkDebit As Decimal, ByVal WrkCredit As Decimal)

    Dim sb As StringBuilder
    'Create Journal Entry
    sb = New StringBuilder
    myTXGLNB.GetOneRecordP(WrkYear, WrkTran, WrkCode)
    If Trim(WrkAcct) = "" Then
      Exit Sub
    End If
    sb.Append(WrkAcct)
    sb.Append(",")
    sb.Append("") 'Project
    sb.Append(",")
    sb.Append("") 'Full Acct
    sb.Append(",")
    sb.Append("") 'PA Type
    sb.Append(",")
    sb.Append("") 'PA String
    sb.Append(",")
    sb.Append(Trim(myTXGLNB._DESCR))
    sb.Append(",")
    sb.Append("A")
    sb.Append(",")
    If WrkCredit > 0 Then
      sb.Append("C") 'Credit
      sb.Append(",")
      sb.Append(WrkCredit)
    Else
      sb.Append("D") 'Debit
      sb.Append(",")
      sb.Append(WrkDebit)
    End If
    sw.WriteLine(sb.ToString)
    sb = Nothing
  End Sub

  Private Function LookupCode(ByVal WrkYear As Integer, ByVal WrkTran As String, ByVal WrkCode As String) As Integer
    Dim I As Integer

    For I = 0 To ArrCode.GetUpperBound(0)
      If ArrCode(I) = "" Then
        Return I
      End If
      If WrkYear = ArrYear(I) And WrkTran = ArrTran(I) And WrkCode = ArrCode(I) Then
        Return I
      End If
    Next

    Return 0
  End Function
End Module
