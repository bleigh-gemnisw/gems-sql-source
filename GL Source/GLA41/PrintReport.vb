Imports System.IO
Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXHSTQ As TXHSTQ.myData
Dim myTXGLEL As TXGLEL.myData
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow
Dim sw As StreamWriter

Dim WrkGLYear As Integer
Dim WrkGLYearSU As Integer
Dim WrkSuppSame As Boolean
Dim WrkPostDate As String
Dim WrkBatchNo As Integer
Dim WrkBatchDt As Integer
Dim WrkAnd As String
Dim WrkOr As String
Dim ArrTran(50) As String
Dim ArrCode(50) As String
Dim ArrAmt(50) As Decimal
Dim WrkErrFees As Boolean
  Public Sub PrtReport()

    myTXHSTQ = New TXHSTQ.MyData(myDBConnect)
    myTXGLEL = New TXGLEL.MyData()
    myTXGLEL.MyDBConn = myDBConnect

    With MyFrmGLA41B
      WrkPostDate = Format(.DtPckPost.Value, "MM/dd/yyyy")
      WrkBatchNo = MyUtils.CnvSng(.TxtBatch.Text)
      WrkBatchDt = MyUtils.SetDBDate(.DtPckBatch.Value)
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
      Array.Clear(ArrTran, 0, 50)
      Array.Clear(ArrCode, 0, 50)
      Array.Clear(ArrAmt, 0, 50)
    End If
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.WrkErrFees = WrkErrFees
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
Dim WrkDesc As String
Dim WrkBatchTran As String

If MyAS400 Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

Counter = 0
WrkQry = "BATCHN= " & WrkBatchNo & WrkAnd & "PDATE = " & WrkBatchDt & WrkAnd & "RCODE <> 'I'" & _
 WrkAnd & "RCODE <> 'V'"

WrkSort = ""
myTXHSTQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

WrkErrFees = False
WrkFilePath = ""
WrkBatchTran = ""

ReadNext:
  myTXHSTQ.ReadQry()
  If Not myTXHSTQ.IsEOF Then
  With myTXHSTQ
    If WrkBatchTran = "" Then
      Select Case Trim(._BATCHA)
      Case Is = "W"
        WrkBatchTran = "ACH"
      Case Is = "B"
        WrkBatchTran = "LBX"
      Case Is = "M"
        WrkBatchTran = "CM"
      Case Else
        WrkBatchTran = "B"
      End Select
    End If
    If ._ADJCD = "R" Then
      WrkBatchTran = "REF"
    End If
    If WrkFilePath = "" Then
      If WrkBatchTran = "REF" Then
        WrkFilePath = MyAppSettings.FilePath & "/glimport.csv"
        sw = New StreamWriter(WrkFilePath)
      Else
        WrkFilePath = MyAppSettings.FilePath & "/rvimport.csv"
        sw = New StreamWriter(WrkFilePath)
      End If
    End If
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
myTXHSTQ.CloseFile()

For I = 0 To 50
  If IsNothing(ArrCode(I)) Then Exit For
  myTXGLEL.GetOneRecordP(ArrTran(I), ArrCode(I))
  WrkDesc = WrkBatchTran & myTXHSTQ._BATCHN & " " & Trim(myTXGLEL._DESC)
  If WrkBatchTran <> "REF" Then
    dr = ds.Tables(0).NewRow
    'If Not myTXGLEL.RecordNotFound Then
    '  dr.Item("acct") = Trim(myTXGLEL._ACCTDB)
    '  dr.Item("desc") = WrkBatchTran & "Cash"
    'Else
    '  dr.Item("acct") = ArrCode(I)
    '  dr.Item("desc") = "*** Missing fee mapping ***"
    '  WrkErrFees = True
    'End If
    'dr.Item("debit") = ArrAmt(I)
    'dr.Item("credit") = 0
    'ds.Tables(0).Rows.Add(dr)
    'WriteCash(False, ArrAmt(I), WrkBatchTran & "Cash")

    dr = ds.Tables(0).NewRow
    If Not myTXGLEL.RecordNotFound Then
      dr.Item("acct") = Trim(myTXGLEL._ACCTCR)
      dr.Item("desc") = WrkDesc
    Else
      dr.Item("acct") = ArrCode(I)
      dr.Item("desc") = "*** Missing fee mapping ***"
      WrkErrFees = True
    End If
    dr.Item("debit") = 0
    dr.Item("credit") = ArrAmt(I)
    ds.Tables(0).Rows.Add(dr)
    WriteCash(True, ArrAmt(I), WrkDesc)
  Else
    dr = ds.Tables(0).NewRow
    If Not myTXGLEL.RecordNotFound Then
      dr.Item("acct") = Trim(myTXGLEL._ACCTDB)
      dr.Item("desc") = WrkDesc
    Else
      dr.Item("acct") = ArrCode(I)
      dr.Item("desc") = "*** Missing fee mapping ***"
      WrkErrFees = True
    End If
    dr.Item("debit") = ArrAmt(I)
    dr.Item("credit") = 0
    ds.Tables(0).Rows.Add(dr)
    WriteGL(False, ArrAmt(I), WrkDesc)

    dr = ds.Tables(0).NewRow
    If Not myTXGLEL.RecordNotFound Then
      dr.Item("acct") = Trim(myTXGLEL._ACCTCR)
      dr.Item("desc") = WrkDesc
    Else
      dr.Item("acct") = ArrCode(I)
      dr.Item("desc") = "*** Missing fee mapping ***"
      WrkErrFees = True
    End If
    dr.Item("debit") = 0
    dr.Item("credit") = ArrAmt(I)
    ds.Tables(0).Rows.Add(dr)
    WriteGL(True, ArrAmt(I), WrkDesc)
  End If
Next

If WrkBatchTran <> "" Then
  sw.Flush()
  sw.Close()
End If
End Sub
Private Sub BuildFile()
  Dim WrkTran As String
  Dim WrkCode As String
  Dim WrkAmt As Decimal
  Dim K As Integer

  WrkTran = ""
  With myTXHSTQ
    If ._BATCHA = "W" Then WrkTran = "WEB"
    If ._ADJCD = "R" Then WrkTran = "REF"
   WrkCode = String.Empty
   If ._PAMT <> 0 Then
     If (._TYPE <> "S" And ._YEAR = WrkGLYear) Or (._TYPE = "S" And ._YEAR = WrkGLYearSU) Then
       WrkCode = "CURR"
     Else
       WrkCode = "PRIOR"
     End If
     K = LookupCode(WrkTran, WrkCode)
     ArrTran(K) = WrkTran
     ArrCode(K) = WrkCode
     ArrAmt(K) = ArrAmt(K) + ._PAMT
   End If
   'Interest/Liens
   WrkCode = String.Empty
   WrkAmt = ._IAMT + ._LAMT
   If WrkAmt <> 0 Then
     If (._TYPE <> "S" And ._YEAR = WrkGLYear) Or (._TYPE = "S" And ._YEAR = WrkGLYearSU) Then
       WrkCode = "INTCU"
     Else
       WrkCode = "INTPR"
     End If
     K = LookupCode(WrkTran, WrkCode)
     ArrTran(K) = WrkTran
     ArrCode(K) = WrkCode
     ArrAmt(K) = ArrAmt(K) + WrkAmt
   End If
   'Fees
   WrkAmt = ._PCAMT
   If WrkAmt <> 0 Then
     WrkCode = Trim(._PENCD)
     If WrkCode = "BI" Then
       If ._YEAR = WrkGLYear Then
         WrkCode = "INTCU"
       Else
         WrkCode = "INTPR"
       End If
     End If
     K = LookupCode(WrkTran, WrkCode)
     ArrTran(K) = WrkTran
     ArrCode(K) = WrkCode
     ArrAmt(K) = ArrAmt(K) + WrkAmt
   End If
 End With
End Sub
Private Sub WriteCash(ByVal WrkCR As Boolean, ByVal WrkAmt As Decimal, WrkDesc As String)
    'Create Cash Receipt
    Dim sb As StringBuilder
    Dim WrkFiscYear As String
    sb = New StringBuilder
    If MyFrmGLA41B.DtPckPost.Value.Month >= 7 Then
      WrkFiscYear = Right(MyFrmGLA41B.DtPckPost.Value.Year, 1) & "-"
    Else
      WrkFiscYear = Right(MyFrmGLA41B.DtPckPost.Value.Year - 1, 1) & "-"
    End If
    sb.Append(WrkFiscYear)
    If WrkCR Then
      sb.Append(Trim(myTXGLEL._ACCTCR))
    Else
      sb.Append(Trim(myTXGLEL._ACCTDB))
    End If
    sb.Append(",")
    sb.Append(WrkPostDate)
    sb.Append(",")
    If WrkCR Then
      sb.Append(WrkAmt)
    Else
      sb.Append(WrkAmt)
    End If
    sb.Append(",")
    sb.Append(WrkDesc)
    sw.WriteLine(sb.ToString)
    sb = Nothing

End Sub
Private Sub WriteGL(ByVal WrkCR As Boolean, ByVal WrkAmt As Decimal, WrkDesc As String)

    'Create Journal Entry
    Dim sb As StringBuilder
    sb = New StringBuilder
    If WrkCR Then
      sb.Append("G") 'Acct Type
      sb.Append(",")
      sb.Append(Replace(Trim(myTXGLEL._ACCTCR), "-", ""))
    Else
      sb.Append("R") 'Acct Type
      sb.Append(",")
      sb.Append(Replace(Trim(myTXGLEL._ACCTDB), "-", ""))
    End If
    sb.Append(",")
    sb.Append(WrkPostDate)
    sb.Append(",")
    sb.Append(WrkAmt)
    sb.Append(",")
    sb.Append(0)
    sb.Append(",")
    sb.Append(WrkDesc)
    sw.WriteLine(sb.ToString)
    sb = Nothing

End Sub
Private Function LookupCode(ByVal Tran As String, ByVal Code As String) As Integer
     Dim I As Integer

     For I = 0 To ArrCode.GetUpperBound(0)
       If ArrTran(I) = "" And ArrCode(I) = "" Then
         Return I
       End If
       If Tran = ArrTran(I) And Code = ArrCode(I) Then
         Return I
       End If
    Next

    Return -1
End Function
End Module
