Imports System.IO
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXHSTQ As TXHSTQ.MyData
  Dim myTXGLAD As TXGLAD.MyData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim sw As StreamWriter

  Dim WrkFrom As Integer
  Dim WrkTo As Integer
  Dim WrkBatchNo As Integer
  Dim WrkAnd As String
  Dim WrkOr As String
  Dim WrkCode(50) As String
  Dim WrkPayType(50) As String
  Dim WrkAmountCash(50) As Decimal
  Dim WrkAmountCheckCR(50) As Decimal
  Public Sub PrtReport()

    myTXHSTQ = New TXHSTQ.MyData(myDBConnect)
    myTXGLAD = New TXGLAD.MyData(myDBConnect)

    With MyFrmGLA33B
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
      WrkBatchNo = MyUtils.CnvSng(.TxtBatch.Text)
    End With

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
    Else
      ds.Clear()
    End If
    If myTOWN._TOWNBR = 4 Then 'Avon
      GetCombined()
    Else
      GetDetail()
    End If

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.Show()

  End Sub
  Public Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("BatchNo", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Code", Type.GetType("System.String"))
      .Columns.Add("Amount", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkFilePath As String
    Dim SaveBatch As Integer
    Dim SaveBatchDate As Integer
    Dim WrkBchCnt As Integer
    Dim Counter As Integer

    If MyAS400 Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkQry = "PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo
    WrkQry = WrkQry & WrkAnd & "RCODE <> 'I'" & WrkAnd & "RCODE <> 'V'"
    WrkQry = WrkQry & WrkAnd & "BATCHN > 0"

    If WrkBatchNo > 0 Then
      WrkQry = WrkQry & WrkAnd & "BATCHN= " & WrkBatchNo
    End If

    WrkBchCnt = 0
    WrkSort = "PDATE, BATCHA ,BATCHN"
    myTXHSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXHSTQ.ReadQry()
    If Not myTXHSTQ.IsEOF Then
      With myTXHSTQ
        Counter = Counter + 1
        If myTOWN._TOWNBR = 32 Then 'Coventry
          If SaveBatch <> ._BATCHN Then
            If SaveBatch > 0 Then sw.Close()
            WrkBchCnt = WrkBchCnt + 1
            WrkFilePath = MyAppSettings.FilePath & "gems-" & ._BATCHN & "-" & ._PDATE & ".csv"
            sw = New StreamWriter(WrkFilePath)
            WriteHeader()
          End If
          WriteFile()
        Else
          'Avon
          If SaveBatch > 0 And SaveBatch <> ._BATCHN Then
            WrkBchCnt = WrkBchCnt + 1
            WrkFilePath = MyAppSettings.FilePath & "gems-" & SaveBatch & "-" & SaveBatchDate & ".csv"
            sw = New StreamWriter(WrkFilePath)
            WriteHeader()
            WriteBatch(SaveBatch, SaveBatchDate)
            sw.Close()
            Array.Clear(WrkCode, 0, 50)
            Array.Clear(WrkPayType, 0, 50)
            Array.Clear(WrkAmountCash, 0, 50)
            Array.Clear(WrkAmountCheckCR, 0, 50)
          End If
          BuildFile()
        End If
        SaveBatch = ._BATCHN
        SaveBatchDate = ._PDATE
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

    If SaveBatch > 0 Then
      If myTOWN._TOWNBR = 4 Then 'Avon
        WrkBchCnt = WrkBchCnt + 1
        WrkFilePath = MyAppSettings.FilePath & "gems-" & SaveBatch & "-" & SaveBatchDate & ".csv"
        sw = New StreamWriter(WrkFilePath)
        WriteHeader()
        WriteBatch(SaveBatch, SaveBatchDate)
      End If
      sw.Close()
    End If
    myFrmProgress.Close()

CloseFiles:
    myTXHSTQ.CloseFile()
    myTXGLAD.CloseFile()
    MsgBox(WrkBchCnt & " files have been created", MsgBoxStyle.Information, "Process completed")

  End Sub
  Private Sub GetCombined()
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkFilePath As String
    Dim SaveBatch As Integer
    Dim SaveBatchDate As Integer
    Dim WrkBchCnt As Integer
    Dim Counter As Integer

    WrkAnd = " and "
    WrkOr = " or "
    WrkQry = "PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo
    WrkQry = WrkQry & WrkAnd & "RCODE <> 'I'" & WrkAnd & "RCODE <> 'V'"
    WrkQry = WrkQry & WrkAnd & "BATCHN > 0"

    If WrkBatchNo > 0 Then
      WrkQry = WrkQry & WrkAnd & "BATCHN= " & WrkBatchNo
    End If

    WrkBchCnt = 0
    WrkSort = "PDATE, BATCHA ,BATCHN"
    myTXHSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFilePath = MyAppSettings.FilePath & "gems-" & WrkFrom & "-" & WrkTo & ".csv"
    sw = New StreamWriter(WrkFilePath)
    WriteHeader()

ReadNext:
    myTXHSTQ.ReadQry()
    If Not myTXHSTQ.IsEOF Then
      With myTXHSTQ
        Counter = Counter + 1
        If SaveBatch > 0 And SaveBatch <> ._BATCHN Then
          WriteBatch(SaveBatch, SaveBatchDate)
          Array.Clear(WrkCode, 0, 50)
          Array.Clear(WrkPayType, 0, 50)
          Array.Clear(WrkAmountCash, 0, 50)
          Array.Clear(WrkAmountCheckCR, 0, 50)
        End If
        BuildFile()
        SaveBatch = ._BATCHN
        SaveBatchDate = ._PDATE
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

CloseFiles:
    myFrmProgress.Close()
    If SaveBatch > 0 Then
      WriteBatch(SaveBatch, SaveBatchDate)
    End If
    sw.Flush()
    sw.Close()
    myTXHSTQ.CloseFile()
    myTXGLAD.CloseFile()
    MsgBox("File has been created", MsgBoxStyle.Information, "Process completed")

  End Sub
  Private Sub WriteFile()
    Dim WrkPAmtCash As Decimal
    Dim WrkPAmtCheckCR As Decimal
    Dim WrkIAmtCash As Decimal
    Dim WrkIAmtCheckCR As Decimal
    Dim WrkPCAmtCash As Decimal
    Dim WrkPCAmtCheckCR As Decimal
    Dim WrkLAmtCash As Decimal
    Dim WrkLAmtCheckCR As Decimal
    Dim WrkCash As Decimal
    Dim WrkPayCode As String
    Dim WrkStr As String

    With myTXHSTQ
      If ._BATCHA = "W" Or ._BATCHA = "B" Then 'Web/Lockbox 
        If myTOWN._TOWNBR = 32 Then 'Coventry
          If ._CORC = 3 Then 'Credit
            WrkPayCode = "CK" 'United Bank
          Else
            WrkPayCode = "ON" 'Webster Bank
          End If
        Else
          WrkPayCode = "CK"
        End If
        WrkPAmtCash = 0
        WrkPAmtCheckCR = ._PAMT
        WrkIAmtCash = 0
        WrkIAmtCheckCR = ._IAMT
        WrkPCAmtCash = 0
        WrkPCAmtCheckCR = ._PCAMT
        WrkLAmtCash = 0
        WrkLAmtCheckCR = ._LAMT
      Else
        WrkPayCode = "CK"
        WrkCash = ._CASH
        If WrkCash >= 0 Then
          If ._PAMT >= WrkCash Then
            WrkPAmtCash = WrkCash
            WrkPAmtCheckCR = ._PAMT - WrkPAmtCash
            WrkCash = 0
          Else
            WrkPAmtCash = ._PAMT
            WrkPAmtCheckCR = 0
            WrkCash = WrkCash - ._PAMT
          End If
          If ._IAMT >= WrkCash Then
            WrkIAmtCash = WrkCash
            WrkIAmtCheckCR = ._IAMT - WrkIAmtCash
            WrkCash = 0
          Else
            WrkIAmtCash = ._IAMT
            WrkIAmtCheckCR = 0
            WrkCash = WrkCash - ._IAMT
          End If
          If ._PCAMT >= WrkCash Then
            WrkPCAmtCash = WrkCash
            WrkPCAmtCheckCR = ._PCAMT - WrkPCAmtCash
            WrkCash = 0
          Else
            WrkPCAmtCash = ._PCAMT
            WrkPCAmtCheckCR = 0
            WrkCash = WrkCash - ._PCAMT
          End If
          If ._LAMT >= WrkCash Then
            WrkLAmtCash = WrkCash
            WrkLAmtCheckCR = ._LAMT - WrkLAmtCash
            WrkCash = 0
          Else
            WrkLAmtCash = ._LAMT
            WrkLAmtCheckCR = 0
            WrkCash = WrkCash - ._LAMT
          End If
        Else
          If ._PAMT < WrkCash Then
            WrkPAmtCash = WrkCash
            WrkPAmtCheckCR = ._PAMT - WrkPAmtCash
            WrkCash = 0
          Else
            WrkPAmtCash = ._PAMT
            WrkPAmtCheckCR = 0
            WrkCash = WrkCash - ._PAMT
          End If
          If ._IAMT < WrkCash Then
            WrkIAmtCash = WrkCash
            WrkIAmtCheckCR = ._IAMT - WrkIAmtCash
            WrkCash = 0
          Else
            WrkIAmtCash = ._IAMT
            WrkIAmtCheckCR = 0
            WrkCash = WrkCash - ._IAMT
          End If
          If ._PCAMT < WrkCash Then
            WrkPCAmtCash = WrkCash
            WrkPCAmtCheckCR = ._PCAMT - WrkPCAmtCash
            WrkCash = 0
          Else
            WrkPCAmtCash = ._PCAMT
            WrkPCAmtCheckCR = 0
            WrkCash = WrkCash - ._PCAMT
          End If
          If ._LAMT < WrkCash Then
            WrkLAmtCash = WrkCash
            WrkLAmtCheckCR = ._LAMT - WrkLAmtCash
            WrkCash = 0
          Else
            WrkLAmtCash = ._LAMT
            WrkLAmtCheckCR = 0
            WrkCash = WrkCash - ._LAMT
          End If
        End If
      End If

      If WrkPAmtCash <> 0 Then
        WrkStr = WriteRecord("", WrkPAmtCash, "CA")
        sw.WriteLine(WrkStr)
      End If
      If WrkPAmtCheckCR <> 0 Then
        WrkStr = WriteRecord("", WrkPAmtCheckCR, WrkPayCode)
        sw.WriteLine(WrkStr)
      End If
      If WrkIAmtCash <> 0 Then
        WrkStr = WriteRecord("IN", WrkIAmtCash, "CA")
        sw.WriteLine(WrkStr)
      End If
      If WrkIAmtCheckCR <> 0 Then
        WrkStr = WriteRecord("IN", WrkIAmtCheckCR, WrkPayCode)
        sw.WriteLine(WrkStr)
      End If
      If WrkPCAmtCash <> 0 Then
        If ._PENCD = "BI" Then
          WrkStr = WriteRecord("", WrkPCAmtCash, "CA")
        Else
          WrkStr = WriteRecord("FE", WrkPCAmtCash, "CA")
        End If
        sw.WriteLine(WrkStr)
      End If
      If WrkPCAmtCheckCR <> 0 Then
        If ._PENCD = "BI" Then
          WrkStr = WriteRecord("", WrkPCAmtCheckCR, WrkPayCode)
        Else
          WrkStr = WriteRecord("FE", WrkPCAmtCheckCR, WrkPayCode)
        End If
        sw.WriteLine(WrkStr)
      End If
      If WrkLAmtCash <> 0 Then
        WrkStr = WriteRecord("LN", WrkLAmtCash, "CA")
        sw.WriteLine(WrkStr)
      End If
      If WrkLAmtCheckCR <> 0 Then
        WrkStr = WriteRecord("LN", WrkLAmtCheckCR, WrkPayCode)
        sw.WriteLine(WrkStr)
      End If
    End With
  End Sub
  Private Sub WriteHeader()
    Dim sb As StringBuilder
    sb = New StringBuilder
    sb.Append("Date")
    sb.Append(",")
    sb.Append("Code")
    sb.Append(",")
    sb.Append("Description")
    sb.Append(",")
    sb.Append("Qty")
    sb.Append(",")
    sb.Append("Amount")
    sb.Append(",")
    sb.Append("PayType")
    sw.WriteLine(sb.ToString)
  End Sub
  Private Function WriteRecord(ByVal WrkRWACode As String, ByVal WrkAmount As Decimal,
  ByVal WrkPayType As String) As String
    Dim sb As StringBuilder
    Dim WrkAdminsCode As String
    Dim WrkNote As String
    Dim WrkQty As Integer
    With myTXHSTQ
      sb = New StringBuilder
      sb.Append(Format(MyUtils.GetDBDate(._PDATE), "M/d/yyyy"))
      sb.Append(",")
      myTXGLAD.GetOneRecordP(._YEAR, ._TYPE, WrkRWACode)
      If Not myTXGLAD.RecordNotFound Then
        If myTOWN._TOWNBR = 32 Then 'Coventry
          WrkAdminsCode = myTXGLAD._ADYR & ._TYPE & myTXGLAD._ADCD
        Else
          WrkAdminsCode = myTXGLAD._ADCD
        End If
      Else
        WrkAdminsCode = "*** Error ***"
      End If
      sb.Append(WrkAdminsCode)
      sb.Append(",")
      If Not myTXGLAD.RecordNotFound Then
        WrkNote = "Batch " & ._BATCHN
      Else
        WrkNote = "YR " & ._YEAR & "/TY " & ._TYPE & "/CD " & WrkRWACode
      End If
      sb.Append(WrkNote)
      sb.Append(",")
      WrkQty = 1
      sb.Append(WrkQty)
      sb.Append(",")
      sb.Append(Format(WrkAmount, "fixed"))
      sb.Append(",")
      sb.Append(WrkPayType)

      If myTXGLAD.RecordNotFound Then
        'Create Report
        dr = ds.Tables(0).NewRow
        dr.Item("batchno") = ._BATCHN
        dr.Item("year") = ._YEAR
        dr.Item("type") = ._TYPE
        dr.Item("code") = WrkRWACode
        dr.Item("amount") = WrkAmount
        ds.Tables(0).Rows.Add(dr)
      End If
    End With

    Return sb.ToString
  End Function
  Private Sub BuildFile()
    Dim WrkPAmtCash As Decimal
    Dim WrkPAmtCheckCR As Decimal
    Dim WrkIAmtCash As Decimal
    Dim WrkIAmtCheckCR As Decimal
    Dim WrkPCAmtCash As Decimal
    Dim WrkPCAmtCheckCR As Decimal
    Dim WrkLAmtCash As Decimal
    Dim WrkLAmtCheckCR As Decimal
    Dim WrkCash As Decimal
    Dim WrkPayCode As String
    Dim K As Integer

    With myTXHSTQ
      If ._BATCHA = "W" Then 'Web 
        WrkPayCode = "CC"
        WrkPAmtCash = 0
        WrkPAmtCheckCR = ._PAMT
        WrkIAmtCash = 0
        WrkIAmtCheckCR = ._IAMT
        WrkPCAmtCash = 0
        WrkPCAmtCheckCR = ._PCAMT
        WrkLAmtCash = 0
        WrkLAmtCheckCR = ._LAMT
      Else
        WrkPayCode = "CK"
        WrkCash = ._CASH
        If WrkCash >= 0 Then
          If ._PAMT >= WrkCash Then
            WrkPAmtCash = WrkCash
            WrkPAmtCheckCR = ._PAMT - WrkPAmtCash
            WrkCash = 0
          Else
            WrkPAmtCash = ._PAMT
            WrkPAmtCheckCR = 0
            WrkCash = WrkCash - ._PAMT
          End If
          If ._IAMT >= WrkCash Then
            WrkIAmtCash = WrkCash
            WrkIAmtCheckCR = ._IAMT - WrkIAmtCash
            WrkCash = 0
          Else
            WrkIAmtCash = ._IAMT
            WrkIAmtCheckCR = 0
            WrkCash = WrkCash - ._IAMT
          End If
          If ._PCAMT >= WrkCash Then
            WrkPCAmtCash = WrkCash
            WrkPCAmtCheckCR = ._PCAMT - WrkPCAmtCash
            WrkCash = 0
          Else
            WrkPCAmtCash = ._PCAMT
            WrkPCAmtCheckCR = 0
            WrkCash = WrkCash - ._PCAMT
          End If
          If ._LAMT >= WrkCash Then
            WrkLAmtCash = WrkCash
            WrkLAmtCheckCR = ._LAMT - WrkLAmtCash
            WrkCash = 0
          Else
            WrkLAmtCash = ._LAMT
            WrkLAmtCheckCR = 0
            WrkCash = WrkCash - ._LAMT
          End If
        Else
          If ._PAMT < WrkCash Then
            WrkPAmtCash = WrkCash
            WrkPAmtCheckCR = ._PAMT - WrkPAmtCash
            WrkCash = 0
          Else
            WrkPAmtCash = ._PAMT
            WrkPAmtCheckCR = 0
            WrkCash = WrkCash - ._PAMT
          End If
          If ._IAMT < WrkCash Then
            WrkIAmtCash = WrkCash
            WrkIAmtCheckCR = ._IAMT - WrkIAmtCash
            WrkCash = 0
          Else
            WrkIAmtCash = ._IAMT
            WrkIAmtCheckCR = 0
            WrkCash = WrkCash - ._IAMT
          End If
          If ._PCAMT < WrkCash Then
            WrkPCAmtCash = WrkCash
            WrkPCAmtCheckCR = ._PCAMT - WrkPCAmtCash
            WrkCash = 0
          Else
            WrkPCAmtCash = ._PCAMT
            WrkPCAmtCheckCR = 0
            WrkCash = WrkCash - ._PCAMT
          End If
          If ._LAMT < WrkCash Then
            WrkLAmtCash = WrkCash
            WrkLAmtCheckCR = ._LAMT - WrkLAmtCash
            WrkCash = 0
          Else
            WrkLAmtCash = ._LAMT
            WrkLAmtCheckCR = 0
            WrkCash = WrkCash - ._LAMT
          End If
        End If
      End If

      'Principal
      myTXGLAD.GetOneRecordP(._YEAR, ._TYPE, "")
      If Not myTXGLAD.RecordNotFound Then
        If WrkPAmtCash <> 0 Then
          K = LookupCode(Trim(myTXGLAD._ADCD), "CA")
          WrkCode(K) = Trim(myTXGLAD._ADCD)
          WrkPayType(K) = "CA"
          WrkAmountCash(K) = WrkAmountCash(K) + WrkPAmtCash
        End If
        If WrkPAmtCheckCR <> 0 Then
          K = LookupCode(Trim(myTXGLAD._ADCD), WrkPayCode)
          WrkCode(K) = Trim(myTXGLAD._ADCD)
          WrkPayType(K) = WrkPayCode
          WrkAmountCheckCR(K) = WrkAmountCheckCR(K) + WrkPAmtCheckCR
        End If
      Else
        K = LookupCode("YR " & ._YEAR & "/TY " & ._TYPE & "/CD   ", "")
        WrkCode(K) = "YR " & ._YEAR & "/TY " & ._TYPE & "/CD   "
      End If
      'Interest 
      myTXGLAD.GetOneRecordP(._YEAR, ._TYPE, "IN")
      If Not myTXGLAD.RecordNotFound Then
        If WrkIAmtCash <> 0 Then
          K = LookupCode(Trim(myTXGLAD._ADCD), "CA")
          WrkCode(K) = Trim(myTXGLAD._ADCD)
          WrkPayType(K) = "CA"
          WrkAmountCash(K) = WrkAmountCash(K) + WrkIAmtCash
        End If
        If WrkIAmtCheckCR <> 0 Then
          K = LookupCode(Trim(myTXGLAD._ADCD), WrkPayCode)
          WrkCode(K) = Trim(myTXGLAD._ADCD)
          WrkPayType(K) = WrkPayCode
          WrkAmountCheckCR(K) = WrkAmountCheckCR(K) + WrkIAmtCheckCR
        End If
      Else
        K = LookupCode("YR " & ._YEAR & "/TY " & ._TYPE & "/CD IN", WrkPayCode)
        WrkCode(K) = "YR " & ._YEAR & "/TY " & ._TYPE & "/CD IN"
      End If
      'Fees 
      If ._PENCD = "BI" Then
        myTXGLAD.GetOneRecordP(._YEAR, ._TYPE, "IN")
        If Not myTXGLAD.RecordNotFound Then
          If WrkPCAmtCash <> 0 Then
            K = LookupCode(Trim(myTXGLAD._ADCD), "CA")
            WrkCode(K) = Trim(myTXGLAD._ADCD)
            WrkPayType(K) = "CA"
            WrkAmountCash(K) = WrkAmountCash(K) + WrkPCAmtCash
          End If
          If WrkPCAmtCheckCR <> 0 Then
            K = LookupCode(Trim(myTXGLAD._ADCD), WrkPayCode)
            WrkCode(K) = Trim(myTXGLAD._ADCD)
            WrkPayType(K) = WrkPayCode
            WrkAmountCheckCR(K) = WrkAmountCheckCR(K) + WrkPCAmtCheckCR
          End If
        Else
          K = LookupCode("YR " & ._YEAR & "/TY " & ._TYPE & "/CD IN", WrkPayCode)
          WrkCode(K) = "YR " & ._YEAR & "/TY " & ._TYPE & "/CD IN"
        End If
      Else
        If Trim(._PENCD) <> "" Then
          myTXGLAD.GetOneRecordP(._YEAR, ._TYPE, "FE")
          If Not myTXGLAD.RecordNotFound Then
            If WrkPCAmtCash <> 0 Then
              K = LookupCode(Trim(myTXGLAD._ADCD), "CA")
              WrkCode(K) = Trim(myTXGLAD._ADCD)
              WrkPayType(K) = "CA"
              WrkAmountCash(K) = WrkAmountCash(K) + WrkPCAmtCash
            End If
            If WrkPCAmtCheckCR <> 0 Then
              K = LookupCode(Trim(myTXGLAD._ADCD), WrkPayCode)
              WrkCode(K) = Trim(myTXGLAD._ADCD)
              WrkPayType(K) = WrkPayCode
              WrkAmountCheckCR(K) = WrkAmountCheckCR(K) + WrkPCAmtCheckCR
            End If
          Else
            K = LookupCode("YR " & ._YEAR & "/TY " & ._TYPE & "/CD FE", WrkPayCode)
            WrkCode(K) = "YR " & ._YEAR & "/TY " & ._TYPE & "/CD FE"
          End If
        End If
      End If
      'Liens
      myTXGLAD.GetOneRecordP(._YEAR, ._TYPE, "LN")
      If Not myTXGLAD.RecordNotFound Then
        If WrkLAmtCash <> 0 Then
          K = LookupCode(Trim(myTXGLAD._ADCD), "CA")
          WrkCode(K) = Trim(myTXGLAD._ADCD)
          WrkPayType(K) = "CA"
          WrkAmountCash(K) = WrkAmountCash(K) + WrkLAmtCash
        End If
        If WrkLAmtCheckCR <> 0 Then
          K = LookupCode(Trim(myTXGLAD._ADCD), WrkPayCode)
          WrkCode(K) = Trim(myTXGLAD._ADCD)
          WrkPayType(K) = WrkPayCode
          WrkAmountCheckCR(K) = WrkAmountCheckCR(K) + WrkLAmtCheckCR
        End If
      Else
        K = LookupCode("YR " & ._YEAR & "/TY " & ._TYPE & "/CD LN", WrkPayCode)
        WrkCode(K) = "YR " & ._YEAR & "/TY " & ._TYPE & "/CD LN"
      End If
    End With
  End Sub
  Private Sub WriteBatch(ByVal WrkBatch As Integer, WrkBatchDate As Integer)
    Dim sb As StringBuilder
    Dim WrkNote As String
    Dim WrkQty As Integer
    Dim I As Integer

    For I = 0 To WrkCode.GetUpperBound(0) - 1
      If WrkAmountCash(I) <> 0 Then
        sb = New StringBuilder
        sb.Append(Format(MyUtils.GetDBDate(WrkBatchDate), "M/d/yyyy"))
        sb.Append(",")
        If Mid(WrkCode(I), 1, 2) = "YR" Then
          sb.Append("")
          sb.Append(",")
          sb.Append(WrkCode(I))
          'Create Report
          dr = ds.Tables(0).NewRow
          dr.Item("batchno") = WrkBatch
          dr.Item("year") = Mid(WrkCode(I), 4, 4)
          dr.Item("type") = Mid(WrkCode(I), 12, 1)
          dr.Item("code") = Right(WrkCode(I), 2)
          dr.Item("amount") = WrkAmountCash(I)
          ds.Tables(0).Rows.Add(dr)
        Else
          sb.Append(WrkCode(I))
          sb.Append(",")
          WrkNote = "Batch " & WrkBatch
          sb.Append(WrkNote)
        End If
        sb.Append(",")
        WrkQty = 1
        sb.Append(WrkQty)
        sb.Append(",")
        sb.Append(Format(WrkAmountCash(I), "fixed"))
        sb.Append(",")
        sb.Append(WrkPayType(I))
        sw.WriteLine(sb.ToString)
      End If

      If WrkAmountCheckCR(I) <> 0 Then
        sb = New StringBuilder
        sb.Append(Format(MyUtils.GetDBDate(WrkBatchDate), "M/d/yyyy"))
        sb.Append(",")
        If Mid(WrkCode(I), 1, 2) = "YR" Then
          sb.Append("")
          sb.Append(",")
          sb.Append(WrkCode(I))
          'Create Report
          dr = ds.Tables(0).NewRow
          dr.Item("batchno") = WrkBatch
          dr.Item("year") = Mid(WrkCode(I), 4, 4)
          dr.Item("type") = Mid(WrkCode(I), 12, 1)
          dr.Item("code") = Right(WrkCode(I), 2)
          dr.Item("amount") = WrkAmountCheckCR(I)
          ds.Tables(0).Rows.Add(dr)
        Else
          sb.Append(WrkCode(I))
          sb.Append(",")
          WrkNote = "Batch " & WrkBatch
          sb.Append(WrkNote)
        End If
        sb.Append(",")
        WrkQty = 1
        sb.Append(WrkQty)
        sb.Append(",")
        sb.Append(Format(WrkAmountCheckCR(I), "fixed"))
        sb.Append(",")
        sb.Append(WrkPayType(I))
        sw.WriteLine(sb.ToString)
      End If
    Next
  End Sub
  Private Function LookupCode(ByVal Code As String, ByVal PayType As String) As Integer
    Dim I As Integer

    For I = 0 To WrkCode.GetUpperBound(0)
      If WrkCode(I) & "" = "" Then
        Return I
      End If
      If Code = WrkCode(I) And PayType = WrkPayType(I) Then
        Return I
      End If
    Next
  End Function
End Module
