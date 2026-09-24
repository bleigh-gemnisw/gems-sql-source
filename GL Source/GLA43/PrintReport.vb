Imports System.IO
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXHSTQ As TXHSTQ.MyData
  Dim myTXGLDA As TXGLDA.MyData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim sw As StreamWriter

  Dim WrkRevenue As Boolean
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
    myTXGLDA = New TXGLDA.MyData()
    myTXGLDA.MyDBConn = myDBConnect

    With MyFrmGLA43B
      WrkRevenue = .RbRevenue.Checked
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
        BuildFile()
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
    myTXGLDA.CloseFile()

    For I = 0 To 500
      If IsNothing(ArrCode(I)) Then Exit For
      dr = ds.Tables(0).NewRow
      myTXGLDA.GetOneRecordP(ArrYear(I), ArrTran(I), ArrCode(I))
      If Not myTXGLDA.RecordNotFound Then
        If WrkRevenue Then
          dr.Item("acct") = Trim(myTXGLDA._ACCTDB)
        Else
          dr.Item("acct") = Trim(myTXGLDA._ACARDB)
        End If
        dr.Item("desc") = Trim(myTXGLDA._DESC)
      Else
        dr.Item("acct") = ""
        dr.Item("desc") = "Missing: " & ArrYear(I) & "/" & ArrTran(I) & "/" & ArrCode(I)
      End If
      dr.Item("debit") = ArrAmt(I)
      dr.Item("credit") = 0
      ds.Tables(0).Rows.Add(dr)
      WriteGLFile(ArrYear(I), ArrTran(I), ArrCode(I), ArrAmt(I), 0)

      dr = ds.Tables(0).NewRow
      If Not myTXGLDA.RecordNotFound Then
        If WrkRevenue Then
          dr.Item("acct") = Trim(myTXGLDA._ACCTCR)
        Else
          dr.Item("acct") = Trim(myTXGLDA._ACARCR)
        End If
        dr.Item("desc") = Trim(myTXGLDA._DESC)
      Else
        dr.Item("acct") = ""
        dr.Item("desc") = "Missing: " & ArrYear(I) & "/" & ArrTran(I) & "/" & ArrCode(I)
      End If
      dr.Item("debit") = 0
      dr.Item("credit") = ArrAmt(I)
      ds.Tables(0).Rows.Add(dr)
      WriteGLFile(ArrYear(I), ArrTran(I), ArrCode(I), 0, ArrAmt(I))
    Next I
    sw.Close()

  End Sub
  Private Sub BuildFile()
    With myTXHSTQ
      Select Case ._TYPE
        Case "A"
          DRTax("ASM")
        Case "C"
          DRTax("SWR")
        Case "X"
          DRTax("PRO")
        Case Else
          DRTax("TAX")
      End Select
    End With
  End Sub
  Private Sub DRTax(ByVal WrkTran As String)
    Dim WrkYear As Integer
    Dim WrkCode As String
    Dim WrkAmt As Decimal
    Dim K As Integer

    With myTXHSTQ
      WrkYear = ._YEAR
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
          If Trim(._ADJCD) = "R" Then
            WrkCode = "REF"
          End If
          If Trim(._ADJCD) = "A" Then
            WrkCode = "ADJ"
          End If
          K = LookupCode(WrkYear, WrkTran, WrkCode)
          ArrYear(K) = WrkYear
          ArrCode(K) = WrkCode
          ArrTran(K) = WrkTran
          ArrAmt(K) = ArrAmt(K) + Math.Abs(._PAMT)
        End If
      End If
      'Interest/Liens
      WrkCode = String.Empty
      WrkAmt = ._IAMT + ._LAMT
      If WrkAmt <> 0 Then
        WrkCode = "INTLN"
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
        If WrkTran = "TAX" Then
          WrkCode = "FE-" & Trim(._PENCD)
        Else
          WrkCode = "FEES"
        End If
        K = LookupCode(0, WrkTran, WrkCode)
        ArrYear(K) = 0
        ArrCode(K) = WrkCode
        ArrTran(K) = WrkTran
        ArrAmt(K) = ArrAmt(K) + WrkAmt
      End If
    End With
  End Sub
  Private Sub WriteGLFile(ByVal WrkYear As Integer, ByVal WrkTran As String, ByVal WrkCode As String, ByVal WrkDebit As Decimal, ByVal WrkCredit As Decimal)

    Dim sb As StringBuilder
    Dim WrkAcct As String
    Dim Pos As Integer

    'Create Journal Entry
    sb = New StringBuilder
    myTXGLDA.GetOneRecordP(WrkYear, WrkTran, WrkCode)
    If WrkRevenue Then
      If Trim(myTXGLDA._ACCTCR) = "" Or Trim(myTXGLDA._ACCTDB) = "" Then
        Exit Sub
      End If
      If WrkCredit > 0 Then
        WrkAcct = Trim(myTXGLDA._ACCTCR)
      Else
        WrkAcct = Trim(myTXGLDA._ACCTDB)
      End If
      Pos = InStr(WrkAcct, "-")
      sb.Append(Mid(WrkAcct, 1, Pos - 1))
      sb.Append(",")
      sb.Append(Mid(WrkAcct, Pos + 1, 20))
      sb.Append(",")
    Else
      If Trim(myTXGLDA._ACARCR) = "" Or Trim(myTXGLDA._ACARDB) = "" Then
        Exit Sub
      End If
      If WrkCredit > 0 Then
        WrkAcct = Trim(myTXGLDA._ACARCR)
      Else
        WrkAcct = Trim(myTXGLDA._ACARDB)
      End If
      Pos = InStr(WrkAcct, "-")
      sb.Append(Mid(WrkAcct, 1, Pos - 1))
      sb.Append(",")
      sb.Append(Mid(WrkAcct, Pos + 1, 20))
      sb.Append(",")
    End If
    sb.Append("") 'Project
    sb.Append(",")
    sb.Append("") 'Full Acct
    sb.Append(",")
    sb.Append("") 'PA Type
    sb.Append(",")
    sb.Append("") 'PA String
    sb.Append(",")
    sb.Append(Trim(myTXGLDA._DESC))
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
