Imports System.IO
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXHSTQ As TXHSTQ.MyData
  Dim myMUNLED As MUNLED.MyData
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
  Dim WrkRefunds As Decimal
  Public Sub PrtReport()

    myTXHSTQ = New TXHSTQ.MyData(myDBConnect)
    myMUNLED = New MUNLED.MyData()
    myMUNLED.MyDBConn = myDBConnect

    With MyFrmGLA37B
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
    WrkFilePath = MyAppSettings.FilePath & "/gems-" & WrkFrom & "-" & WrkTo & ".txt"
    sw = New StreamWriter(WrkFilePath)

ReadNext:
    myTXHSTQ.ReadQry()
    If Not myTXHSTQ.IsEOF Then
      With myTXHSTQ
        Counter = Counter + 1
        Select Case myTOWN._TOWNBR
          Case 45, 72
            WriteFileEL()
          Case 131
            WriteFileSouth()
          Case Else
            WriteFile()
        End Select
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
    myMUNLED.CloseFile()

    For I = 0 To 50
      If IsNothing(ArrCode(I)) Then Exit For
      dr = ds.Tables(0).NewRow
      myMUNLED.GetOneRecordP(ArrCode(I))
      dr.Item("acct") = Trim(myMUNLED._ORIG) & "-" & Trim(myMUNLED._OBJ)
      dr.Item("desc") = Trim(myMUNLED._DESC)
      If myMUNLED._DBCR = "D" Then
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
      WriteMUNJE(ArrCode(I), dr.Item("debit"), dr.Item("credit"))
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
          Case "W", "B"
            WrkCode = "WEB" 'Webster
          Case "O"
            WrkCode = "MISC"
          Case Else
            WrkCode = "DAILY"
        End Select
        K = LookupCode(WrkCode)
        ArrCode(K) = WrkCode
        ArrAmt(K) = ArrAmt(K) + WrkAmt
      Else
        WrkRefunds = WrkRefunds + Math.Abs(WrkAmt)
      End If
      'Credit
      Select Case ._TYPE
        Case "A"
          DRSewer()
        Case "B"
          DRWater()
        Case Else
          DRTax()
      End Select
    End With
  End Sub
  'MK 9/11/25 Begin
  Private Sub WriteFileEL()
    Dim WrkCode As String
    Dim WrkAmt As Decimal
    Dim K As Integer

    With myTXHSTQ
      'Debit
      WrkAmt = ._PAMT + ._IAMT + ._LAMT + ._PCAMT
      If ._TYPE = "A" Then
        WrkCode = "SADBT"
      Else
        WrkCode = "DAILY"
      End If
      K = LookupCode(WrkCode)
      ArrCode(K) = WrkCode
      ArrAmt(K) = ArrAmt(K) + WrkAmt
      'Credit
      Select Case ._TYPE
        Case "A"
          DRSewer()
        Case Else
          DRTaxEL()
      End Select
    End With
  End Sub
  'MK 9/11/25 End
  Private Sub WriteFileSouth()
    Dim WrkCode As String
    Dim WrkAmt As Decimal
    Dim K As Integer

    With myTXHSTQ
      'Debit
      WrkAmt = ._PAMT + ._IAMT + ._LAMT + ._PCAMT
      'Principal 
      WrkCode = ._YEAR
      If WrkAmt <> 0 Then
        K = LookupCode(WrkCode)
        ArrCode(K) = WrkCode
        ArrAmt(K) = ArrAmt(K) + WrkAmt
      End If
      'Credit
      DRTaxSouth()
    End With
  End Sub
  Private Sub DRSewer()
    Dim WrkCode As String
    Dim WrkAmt As Decimal
    Dim K As Integer

    With myTXHSTQ
      'Principal 
      WrkCode = String.Empty
      If ._PAMT <> 0 Then
        'MK 9/11/25 Begin
        'WrkCode = "A-1"
        If myTOWN._TOWNBR = 45 Or myTOWN._TOWNBR = 72 Or myTOWN._TOWNBR = 131 Then 'East Lyme/Ledyard/Southington
          WrkCode = "SA"
        Else
          WrkCode = "A-1"
        End If
        'MK 9/11/25 End
        K = LookupCode(WrkCode)
        ArrCode(K) = WrkCode
        ArrAmt(K) = ArrAmt(K) + ._PAMT
      End If
      'Bond Interest & Fees
      WrkCode = String.Empty
      WrkAmt = ._IAMT + ._LAMT + ._PCAMT
      If WrkAmt <> 0 Then
        'MK 9/11/25 Begin
        'WrkCode = "SWRBI"
        If myTOWN._TOWNBR = 45 Or myTOWN._TOWNBR = 72 Or myTOWN._TOWNBR = 131 Then 'East Lyme/Ledyard/Southington
          WrkCode = "SAINT"
        Else
          WrkCode = "SWRBI"
        End If
        'MK 9/11/25 End
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
      If ._PAMT <> 0 Then
        Select Case ._DIST
          Case 1
            WrkCode = "B-1"
          Case 2
            WrkCode = "B-2"
          Case 4
            WrkCode = "B-4"
          Case Else
        End Select
        K = LookupCode(WrkCode)
        ArrCode(K) = WrkCode
        ArrAmt(K) = ArrAmt(K) + ._PAMT
      End If
      'Bond Interest & Fees
      WrkCode = String.Empty
      WrkAmt = ._IAMT + ._LAMT + ._PCAMT
      If WrkAmt <> 0 Then
        WrkCode = "WTRBI"
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
      'Principal (Omit refunds)
      If Trim(._ADJCD) = "R" Then
        Exit Sub
      End If
      WrkCode = String.Empty
      If ._PAMT <> 0 Then
        If (._TYPE <> "S" And ._YEAR = WrkGLYear) Or (._TYPE = "S" And ._YEAR = WrkGLYearSU) Then
          WrkCode = "CURR"
        Else
          If ._RCODE = "S" Then
            WrkCode = "SUSP"
          Else
            WrkCode = "PRIOR"
          End If
        End If
        K = LookupCode(WrkCode)
        ArrCode(K) = WrkCode
        ArrAmt(K) = ArrAmt(K) + ._PAMT
      End If
      'Interest
      WrkCode = String.Empty
      WrkAmt = ._IAMT
      If WrkAmt <> 0 Then
        WrkCode = "INT"
        K = LookupCode(WrkCode)
        ArrCode(K) = WrkCode
        ArrAmt(K) = ArrAmt(K) + WrkAmt
      End If
      'Liens/Fees
      WrkCode = String.Empty
      WrkAmt = ._LAMT + ._PCAMT
      If WrkAmt <> 0 Then
        WrkCode = "FEES"
        K = LookupCode(WrkCode)
        ArrCode(K) = WrkCode
        ArrAmt(K) = ArrAmt(K) + WrkAmt
      End If
    End With
  End Sub
  'MK 9/11/25 Begin
  Private Sub DRTaxEL()
    Dim WrkCode As String
    Dim WrkAmt As Decimal
    Dim WrkIsCurrent As Boolean
    Dim K As Integer

    WrkIsCurrent = False
    With myTXHSTQ
      'Principal 
      WrkCode = String.Empty
      If ._TYPE = "S" Then
        If ._YEAR = WrkGLYearSU Then
          WrkIsCurrent = True
        End If
      Else
        If ._YEAR = WrkGLYear Then
          WrkIsCurrent = True
        End If
      End If
      If ._PAMT <> 0 Then
        If ._TYPE = "S" Then
          If WrkIsCurrent Then
            WrkCode = "CURR" '"SUPP"
          Else
            WrkCode = "PRIOR" '"PRSUP"
          End If
          K = LookupCode(WrkCode)
          ArrCode(K) = WrkCode
          ArrAmt(K) = ArrAmt(K) + ._PAMT
        Else
          If WrkIsCurrent Then
            WrkCode = "CURR" '"SUPP"
          Else
            WrkCode = "PRIOR" '"PRSUP"
          End If
          K = LookupCode(WrkCode)
          ArrCode(K) = WrkCode
          ArrAmt(K) = ArrAmt(K) + ._PAMT
        End If
      End If

      Select Case ._PENCD
        Case "AF", "IS", "TS", "SW"
          WrkCode = String.Empty
          WrkAmt = ._PCAMT
          If WrkAmt <> 0 Then
            WrkCode = "FEE" & ._PENCD
            K = LookupCode(WrkCode)
            ArrCode(K) = WrkCode
            ArrAmt(K) = ArrAmt(K) + WrkAmt
          End If
          WrkAmt = ._IAMT + ._LAMT
          If WrkAmt <> 0 Then
            If WrkIsCurrent Then
              WrkCode = "INT"
            Else
              WrkCode = "INTPR"
            End If
            K = LookupCode(WrkCode)
            ArrCode(K) = WrkCode
            ArrAmt(K) = ArrAmt(K) + WrkAmt
          End If
        Case Else
          WrkCode = String.Empty
          WrkAmt = ._IAMT + ._LAMT + ._PCAMT
          If WrkAmt <> 0 Then
            If WrkIsCurrent Then
              WrkCode = "INT"
            Else
              WrkCode = "INTPR"
            End If
            K = LookupCode(WrkCode)
            ArrCode(K) = WrkCode
            ArrAmt(K) = ArrAmt(K) + WrkAmt
          End If
      End Select
    End With
  End Sub
  'MK 9/11/25 End
  Private Sub DRTaxSouth()
    Dim WrkCode As String
    Dim WrkAmt As Decimal
    Dim WrkIsCurrent As Boolean
    Dim K As Integer

    WrkIsCurrent = False
    With myTXHSTQ
      'Principal 
      WrkCode = String.Empty
      If ._TYPE = "S" Then
        If ._YEAR = WrkGLYearSU Then
          WrkIsCurrent = True
        End If
      Else
        If ._YEAR = WrkGLYear Then
          WrkIsCurrent = True
        End If
      End If
      If ._PAMT <> 0 Then
        If ._RCODE = "S" Then
          WrkCode = "SUSP"
        Else
          If WrkIsCurrent Then
            WrkCode = "CURR"
          Else
            WrkCode = "PRIOR"
          End If
        End If
        K = LookupCode(WrkCode)
        ArrCode(K) = WrkCode
        ArrAmt(K) = ArrAmt(K) + ._PAMT
      End If

      'Interest
      WrkCode = String.Empty
      WrkAmt = ._IAMT
      If WrkAmt <> 0 Then
        WrkCode = "INT"
        K = LookupCode(WrkCode)
        ArrCode(K) = WrkCode
        ArrAmt(K) = ArrAmt(K) + WrkAmt
      End If

      'Liens
      WrkCode = String.Empty
      WrkAmt = ._LAMT
      If WrkAmt <> 0 Then
        WrkCode = "LIENS"
        K = LookupCode(WrkCode)
        ArrCode(K) = WrkCode
        ArrAmt(K) = ArrAmt(K) + WrkAmt
      End If

      Select Case ._PENCD
        Case "AF", "IS", "TS", "SW", "SI"
          WrkCode = String.Empty
          WrkAmt = ._PCAMT
          If WrkAmt <> 0 Then
            WrkCode = "FEE" & ._PENCD
            K = LookupCode(WrkCode)
            ArrCode(K) = WrkCode
            ArrAmt(K) = ArrAmt(K) + WrkAmt
          End If
      End Select
    End With
  End Sub
  Private Sub WriteMUNJE(ByVal WrkCode As String, ByVal WrkDebit As Decimal, ByVal WrkCredit As Decimal)

    Dim sb As StringBuilder
    Dim wrklong As Long

    'Create Journal Entry
    sb = New StringBuilder
    myMUNLED.GetOneRecordP(WrkCode)
    sb.Append(MyUtils.JustifyLeft(myMUNLED._ORIG, 8)) 'Organization
    sb.Append(MyUtils.JustifyLeft(myMUNLED._OBJ, 6)) 'Object
    sb.Append(MyUtils.JustifyLeft("", 5)) 'Project
    sb.Append(MyUtils.JustifyLeft("", 35)) 'Full Account
    sb.Append(MyUtils.JustifyLeft("", 30)) 'Comment
    sb.Append(MyUtils.JustifyLeft("", 10))
    sb.Append(MyUtils.JustifyLeft("", 12))
    If WrkCredit > 0 Then
      sb.Append("C") 'Credit
      wrklong = WrkCredit * 100
    Else
      sb.Append("D") 'Debit
      wrklong = WrkDebit * 100
    End If
    sb.Append(Format(wrklong, "0000000000000")) 'Amount
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

  End Function
End Module
