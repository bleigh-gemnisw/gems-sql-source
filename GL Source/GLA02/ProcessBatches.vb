Imports System.io
Imports System.Text
Module ProcessBatches

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myNETGLBCHQ As NETGLBCHQ.MyData
  Dim myBCHHDR As BCHHDR.MyData
  Dim myTAXBCH As TAXBCH.MyData
  Dim myTAXBCHL1 As TAXBCHL1.MyData
  Dim myTXGL As TXGL.MyData
  Dim myTXGLWB As TXGLWB.MyData
  Dim myGLACCT As GLACCT.MyData
  Dim myUTBLHS As UTBLHS.MyData

  Dim WrkPost As Boolean
  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim dsErr As DataSet = New DataSet
  Dim dr As DataRow
  Dim ArrAcct(100) As String
  Dim ArrAmount(100) As Decimal
  Dim ArrCRDB(100) As String
  Dim WrkTotal As Decimal
  Const CBatchType As String = "PTX"

  Public Sub ProcBatches(ByVal Import As Boolean)
    Dim Errors As Boolean

    myNETGLBCHQ = New NETGLBCHQ.MyData()
    myNETGLBCHQ.MyDBConn = myDBConnect
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myTAXBCH = New TAXBCH.MyData()
    myTAXBCH.MyDBConn = myDBConnect
    myTAXBCHL1 = New TAXBCHL1.MyData()
    myTAXBCHL1.MyDBConn = myDBConnect
    myTXGL = New TXGL.MyData()
    myTXGL.MyDBConn = myDBConnect
    myTXGLWB = New TXGLWB.MyData()
    myTXGLWB.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    myUTBLHS = New UTBLHS.MyData(myDBConnect)

    With MyFrmGLA02B
      '   WrkPost = .ChkPost.Checked
    End With
    WrkPost = True

    myTXGLWB.GetOneRecordP(1)
    If ds.Tables.Count = 0 Then
      BuildDs(ds)
      BuildDsErr(dsErr)
    Else
      ds.Clear()
      dsErr.Clear()
    End If

    If Import Then
      Errors = EditImport()
    Else
      Errors = EditCheck()
    End If
    If Not Errors Then
      If Import Then
        GetImport()
      Else
        GetDetail()
      End If
    Else
      MsgBox("Create missing Tax Interface records and reprocess", MsgBoxStyle.Exclamation, "Errors found - Batches not created")
    End If

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .wrkdsErr = dsErr
      .Show()
    End With

  End Sub
  Private Function EditCheck() As Boolean
    Dim Counter As Integer
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkCode As String
    Dim SaveBatch As Integer
    Dim SaveDist As Integer

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Checking for errors"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0
    SaveBatch = 0
    SaveDist = 0
    WrkSort = "BATCH, DIST"
    WrkQry = String.Empty
    myNETGLBCHQ.OpenQry(WrkSort, WrkQry)

ReadNext:
    myNETGLBCHQ.ReadQry()
    If Not myNETGLBCHQ.IsEOF Then
      With myNETGLBCHQ
        Counter = Counter + 1
        If SaveBatch <> ._BATCH Or SaveDist <> ._DIST Then
          ds2 = myTAXBCHL1.GetViewbyDist(._BATCH, ._DIST, 1)
        End If
        SaveBatch = ._BATCH
        SaveDist = ._DIST
        If ds2.Tables(0).Rows.Count > 0 Then
          GoTo ReadNext
        End If
        If ._PAMT <> 0 Then
          Select Case Trim(._ADJCD)
            Case "A"
              If myTOWN._TOWNBR <> 162 Then
                WrkCode = "AJ"
              Else
                WrkCode = ""
              End If
            Case "R"
              If myTOWN._TOWNBR <> 162 Then
                WrkCode = "RF"
              Else
                WrkCode = ""
              End If
            Case Else
              WrkCode = String.Empty
          End Select
          If myTOWN._TOWNBR = 37 Then 'Derby
            WrkCode = String.Empty
            myUTBLHS.GetOneRecordP(._LIST, ._YEAR, ._TYPE)
            If myUTBLHS.RecordNotFound Then
              GetTXGL(._STAT, ._YEAR, ._TYPE, WrkCode, False, ._DIST)
            Else
              GetTXGL(._STAT, ._YEAR, ._TYPE, "CI", False, ._DIST)
              GetTXGL(._STAT, ._YEAR, ._TYPE, WrkCode, False, ._DIST)
            End If
          Else
            GetTXGL(._STAT, ._YEAR, ._TYPE, WrkCode, False, ._DIST)
          End If
        End If
        If ._IAMT <> 0 Then
          WrkCode = "IN"
          GetTXGL(._STAT, ._YEAR, ._TYPE, WrkCode, False, ._DIST)
        End If
        If ._LAMT <> 0 Then
          WrkCode = "LN"
          GetTXGL(._STAT, ._YEAR, ._TYPE, WrkCode, False, ._DIST)
        End If
        If ._PCAMT <> 0 Then
          WrkCode = ._PENCD
          GetTXGL(._STAT, ._YEAR, ._TYPE, WrkCode, True, ._DIST)
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
    myNETGLBCHQ.CloseFile()
    If dsErr.Tables(0).Rows.Count > 0 Then
      Return True
    Else
      Return False
    End If
  End Function
  Private Sub GetDetail()
    Dim Counter As Integer
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkBatchNo As Integer
    Dim WrkCode As String
    Dim WrkSeqno As Integer
    Dim WrkCIPct As Decimal
    Dim WrkCIAmt As Decimal
    Dim SaveDist As Integer
    Dim SaveTaxBatchNo As Integer
    Dim SavePstDt As Integer
    Dim SavePayDt As Integer

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Creating Batches"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0
    WrkTotal = 0
    WrkSort = "BATCH, DIST"
    WrkQry = String.Empty
    myNETGLBCHQ.OpenQry(WrkSort, WrkQry)

    If WrkPost Then
      WrkBatchNo = myBCHHDR.AutoGenKey(CBatchType) - 1
    End If

ReadNext:
    myNETGLBCHQ.ReadQry()
    If Not myNETGLBCHQ.IsEOF Then
      With myNETGLBCHQ
        If SaveTaxBatchNo <> ._BATCH Or SaveDist <> ._DIST Then
          ds2 = myTAXBCHL1.GetViewbyDist(._BATCH, ._DIST, 1)
          If ArrAmount(0) <> 0 Then
            If WrkPost Then
NextBatchno:
              WrkBatchNo = WrkBatchNo + 1
              If WrkBatchNo > 999 Then
                WrkBatchNo = 1
              End If
              myBCHHDR.GetOneRecordP(CBatchType, WrkBatchNo)
              If Not myBCHHDR.RecordNotFound Then
                GoTo NextBatchno
              End If
            Else
              WrkBatchNo = WrkBatchNo + 1
            End If
          End If
          If SaveTaxBatchNo <> 0 And ArrAmount(0) <> 0 Then
            ProcessAccts(WrkBatchNo, SavePstDt, SavePayDt, SaveTaxBatchNo, SaveDist)
            WriteTotals(WrkBatchNo, SaveTaxBatchNo, SaveDist)
          End If
          WrkSeqno = 0
          WrkTotal = 0
          Array.Clear(ArrAcct, 0, 100)
          Array.Clear(ArrAmount, 0, 100)
          Array.Clear(ArrCRDB, 0, 100)
        End If
        SaveTaxBatchNo = ._BATCH
        SaveDist = ._DIST
        SavePstDt = ._PSTDT
        SavePayDt = ._PAYDT
        Counter = Counter + 1
        If ds2.Tables(0).Rows.Count > 0 Then
          GoTo ReadNext
        End If
        If ._PAMT <> 0 Then
          WrkCode = String.Empty
          If myTOWN._TOWNBR = 37 Then 'Derby
            myUTBLHS.GetOneRecordP(._LIST, ._YEAR, ._TYPE)
            If myUTBLHS.RecordNotFound Then
              If ._ADJCD = "R" Then
                WriteArr(._STAT, ._YEAR, ._TYPE, "RF", ._PAMT, True, False, ._DIST)
              Else
                WriteArr(._STAT, ._YEAR, ._TYPE, WrkCode, ._PAMT, False, False, ._DIST)
              End If
            Else
              WrkCIPct = myUTBLHS._AMT6 / myUTBLHS._BLAMT
              WrkCIAmt = MyUtils.Round(WrkCIPct * ._PAMT, 2)
              WriteArr(._STAT, ._YEAR, ._TYPE, "CI", WrkCIAmt, False, False, ._DIST)
              If ._ADJCD = "R" Then
                WriteArr(._STAT, ._YEAR, ._TYPE, "RF", ._PAMT + WrkCIAmt, True, False, ._DIST)
              Else
                WriteArr(._STAT, ._YEAR, ._TYPE, WrkCode, ._PAMT - WrkCIAmt, False, False, ._DIST)
              End If
            End If
          Else
            If ._ADJCD = "R" Then
              WriteArr(._STAT, ._YEAR, ._TYPE, WrkCode, ._PAMT, True, False, ._DIST)
            Else
              WriteArr(._STAT, ._YEAR, ._TYPE, WrkCode, ._PAMT, False, False, ._DIST)
            End If
          End If
          End If
        If ._IAMT <> 0 Then
          WrkCode = "IN"
          WriteArr(._STAT, ._YEAR, ._TYPE, WrkCode, ._IAMT, False, False, ._DIST)
        End If
        If ._LAMT <> 0 Then
          WrkCode = "LN"
          WriteArr(._STAT, ._YEAR, ._TYPE, WrkCode, ._LAMT, False, False, ._DIST)
        End If
        If ._PCAMT <> 0 Then
          WrkCode = ._PENCD
          WriteArr(._STAT, ._YEAR, ._TYPE, WrkCode, ._PCAMT, False, True, ._DIST)
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


    If WrkBatchNo > 0 And WrkPost Or ArrAmount(0) <> 0 Then
      If ArrAmount(0) <> 0 Then
        If WrkPost Then
NextBatchno2:
          WrkBatchNo = WrkBatchNo + 1
          If WrkBatchNo > 999 Then
            WrkBatchNo = 1
          End If
          myBCHHDR.GetOneRecordP(CBatchType, WrkBatchNo)
          If Not myBCHHDR.RecordNotFound Then
            GoTo NextBatchno2
          End If
        Else
          WrkBatchNo = WrkBatchNo + 1
        End If
        ProcessAccts(WrkBatchNo, SavePstDt, SavePayDt, SaveTaxBatchNo, SaveDist)
        WriteTotals(WrkBatchNo, SaveTaxBatchNo, SaveDist)
      End If
      myBCHHDR.GetOneRecordP(CBatchType, 0)
      If Not myBCHHDR.RecordNotFound Then
        With myBCHHDR
          ._LSBCH = WrkBatchNo
          .UpdateOneRecordP()
        End With
      Else
        With myBCHHDR
          ._APPID = CBatchType
          ._BCHNO = 0
          ._LSBCH = WrkBatchNo
          .AddOneRecordP()
        End With
      End If
    End If

    myFrmProgress.Close()
    myTAXBCH.CloseFile()
    myNETGLBCHQ.CloseFile()

  End Sub
  Private Function EditImport() As Boolean
    Dim WrkStream As FileStream = New FileStream(MyFrmGLA02B_Import.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim sArray As String()
    Dim Counter As Integer
    Dim WrkCode As String
    Dim WrkStat As String
    Dim WrkBatch As Integer
    Dim WrkDist As Integer
    Dim WrkList As Integer
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkPamt As Decimal
    Dim WrkIamt As Decimal
    Dim WrkLamt As Decimal
    Dim WrkPcamt As Decimal
    Dim WrkPencd As String
    Dim SaveBatch As Integer
    Dim SaveDist As Integer

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Checking for errors"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0
    SaveBatch = -1
    SaveDist = 0

ReadNext:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo End_of_file
      Exit Function
    End If

    sArray = Parse(strBuffer, ",")
    If Mid(sArray(0), 1, 6) = "STATUS" Then 'Skip Header record
      GoTo NextRec
    End If
    WrkStat = sArray(0)
    WrkBatch = sArray(1)
    WrkList = sArray(3)
    WrkYear = sArray(4)
    WrkType = sArray(5)
    WrkPamt = sArray(6)
    WrkIamt = sArray(7)
    WrkLamt = sArray(8)
    WrkPcamt = sArray(9)
    WrkDist = MyUtils.CnvSng(sArray(10))
    If sArray.GetUpperBound(0) = 13 Then 'QDS
      WrkPencd = sArray(11)
    Else
      WrkPencd = sArray(12)
    End If
    Counter = Counter + 1
    If SaveBatch <> WrkBatch Or SaveDist <> WrkDist Then
      ds2 = myTAXBCHL1.GetViewbyDist(WrkBatch, WrkDist, 1)
    End If
    SaveBatch = WrkBatch
    SaveDist = WrkDist
    If ds2.Tables(0).Rows.Count > 0 Then
      GoTo ReadNext
    End If
    If WrkPamt <> 0 Then
      WrkCode = String.Empty
      If myTOWN._TOWNBR = 37 Then 'Derby
        myUTBLHS.GetOneRecordP(WrkList, WrkYear, WrkType)
        If myUTBLHS.RecordNotFound Then
          GetTXGL(WrkStat, WrkYear, WrkType, WrkCode, False, WrkDist)
        Else
          GetTXGL(WrkStat, WrkYear, WrkType, "CI", False, WrkDist)
          GetTXGL(WrkStat, WrkYear, WrkType, WrkCode, False, WrkDist)
        End If
      Else
        GetTXGL(WrkStat, WrkYear, WrkType, WrkCode, False, WrkDist)
      End If
    End If
    If WrkIamt <> 0 Then
      WrkCode = "IN"
      GetTXGL(WrkStat, WrkYear, WrkType, WrkCode, False, WrkDist)
    End If
    If WrkLamt <> 0 Then
      WrkCode = "LN"
      GetTXGL(WrkStat, WrkYear, WrkType, WrkCode, False, WrkDist)
    End If
    If WrkPcamt <> 0 Then
      WrkCode = WrkPencd
      GetTXGL(WrkStat, WrkYear, WrkType, WrkCode, True, WrkDist)
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
    GoTo ReadNext

End_of_file:
    sr.Close()
    myFrmProgress.Close()
    If dsErr.Tables(0).Rows.Count > 0 Then
      Return True
    Else
      Return False
    End If
  End Function
  Private Sub GetImport()
    Dim WrkStream As FileStream = New FileStream(MyFrmGLA02B_Import.LblFilePath.Text, FileMode.Open)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim sArray As String()
    Dim Counter As Integer
    Dim WrkStat As String
    Dim WrkBatch As Integer
    Dim WrkDist As Integer
    Dim WrkList As Integer
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkPamt As Decimal
    Dim WrkIamt As Decimal
    Dim WrkLamt As Decimal
    Dim WrkPcamt As Decimal
    Dim WrkPencd As String
    Dim WrkPstdt As Integer
    Dim WrkPaydt As Integer
    Dim WrkGLBatch As Integer
    Dim WrkCode As String
    Dim WrkSeqno As Integer
    Dim WrkCIPct As Decimal
    Dim WrkCIAmt As Decimal
    Dim SaveDist As Integer
    Dim SaveTaxBatchNo As Integer
    Dim SavePstDt As Integer
    Dim SavePayDt As Integer

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Creating Batches"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0
    WrkTotal = 0
    If WrkPost Then
      WrkGLBatch = myBCHHDR.AutoGenKey(CBatchType) - 1
    End If

ReadNext:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo End_of_file
    End If

    sArray = Parse(strBuffer, ",")
    If Mid(sArray(0), 1, 6) = "STATUS" Then 'Skip Header record
      GoTo NextRec
    End If
    WrkStat = sArray(0)
    WrkBatch = sArray(1)
    WrkList = sArray(3)
    WrkYear = sArray(4)
    WrkType = sArray(5)
    WrkPamt = sArray(6)
    WrkIamt = sArray(7)
    WrkLamt = sArray(8)
    WrkPcamt = sArray(9)
    WrkDist = MyUtils.CnvSng(sArray(10))
    If sArray.GetUpperBound(0) = 13 Then 'QDS
      WrkPencd = sArray(11)
      WrkPstdt = sArray(12)
      WrkPaydt = sArray(13)
    Else
      WrkPencd = sArray(12)
      WrkPstdt = sArray(13)
      WrkPaydt = sArray(14)
    End If
    If SaveTaxBatchNo <> WrkBatch Or SaveDist <> WrkDist Then
      ds2 = myTAXBCHL1.GetViewbyDist(WrkBatch, WrkDist, 1)
      If ArrAmount(0) <> 0 Then
        If WrkPost Then
NextBatchno:
          WrkGLBatch = WrkGLBatch + 1
          If WrkGLBatch > 999 Then
            WrkGLBatch = 1
          End If
          myBCHHDR.GetOneRecordP(CBatchType, WrkGLBatch)
          If Not myBCHHDR.RecordNotFound Then
            GoTo NextBatchno
          End If
        Else
          WrkGLBatch = WrkGLBatch + 1
        End If
      End If
      If SaveTaxBatchNo <> 0 And ArrAmount(0) <> 0 Then
        ProcessAccts(WrkGLBatch, SavePstDt, SavePayDt, SaveTaxBatchNo, SaveDist)
        WriteTotals(WrkGLBatch, SaveTaxBatchNo, SaveDist)
      End If
      WrkSeqno = 0
      WrkTotal = 0
      Array.Clear(ArrAcct, 0, 100)
      Array.Clear(ArrAmount, 0, 100)
      Array.Clear(ArrCRDB, 0, 100)
    End If
    SaveTaxBatchNo = WrkBatch
    SaveDist = WrkDist
    SavePstDt = WrkPstdt
    SavePayDt = WrkPaydt
    Counter = Counter + 1
    If ds2.Tables(0).Rows.Count > 0 Then
      GoTo ReadNext
    End If
    If WrkPamt <> 0 Then
      WrkCode = String.Empty
      If myTOWN._TOWNBR = 37 Then 'Derby
        myUTBLHS.GetOneRecordP(WrkList, WrkYear, WrkType)
        If myUTBLHS.RecordNotFound Then
          WriteArr(WrkStat, WrkYear, WrkType, WrkCode, WrkPamt, False, False, WrkDist)
        Else
          WrkCIPct = myUTBLHS._AMT6 / myUTBLHS._BLAMT
          WrkCIAmt = MyUtils.Round(WrkCIPct * WrkPamt, 2)
          WriteArr(WrkStat, WrkYear, WrkType, "CI", WrkCIAmt, False, False, WrkDist)
          WriteArr(WrkStat, WrkYear, WrkType, WrkCode, WrkPamt - WrkCIAmt, False, False, WrkDist)
        End If
      Else
        WriteArr(WrkStat, WrkYear, WrkType, WrkCode, WrkPamt, False, False, WrkDist)
      End If
    End If
    If WrkIamt <> 0 Then
      WrkCode = "IN"
      WriteArr(WrkStat, WrkYear, WrkType, WrkCode, WrkIamt, False, False, WrkDist)
    End If
    If WrkLamt <> 0 Then
      WrkCode = "LN"
      WriteArr(WrkStat, WrkYear, WrkType, WrkCode, WrkLamt, False, False, WrkDist)
    End If
    If WrkPcamt <> 0 Then
      WrkCode = WrkPencd
      WriteArr(WrkStat, WrkYear, WrkType, WrkCode, WrkPcamt, False, True, WrkDist)
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
    GoTo ReadNext

End_of_file:
    If WrkPost And ArrAmount(0) <> 0 Then
      If ArrAmount(0) <> 0 Then
NextBatchno2:
        WrkGLBatch = WrkGLBatch + 1
        If WrkGLBatch > 999 Then
          WrkGLBatch = 1
        End If
        myBCHHDR.GetOneRecordP(CBatchType, WrkGLBatch)
        If Not myBCHHDR.RecordNotFound Then
          GoTo NextBatchno2
        End If
        ProcessAccts(WrkGLBatch, SavePstDt, SavePayDt, SaveTaxBatchNo, SaveDist)
        WriteTotals(WrkGLBatch, SaveTaxBatchNo, SaveDist)
      End If
      myBCHHDR.GetOneRecordP(CBatchType, 0)
      If Not myBCHHDR.RecordNotFound Then
        With myBCHHDR
          ._LSBCH = WrkGLBatch
          .UpdateOneRecordP()
        End With
      Else
        With myBCHHDR
          ._APPID = CBatchType
          ._BCHNO = 0
          ._LSBCH = WrkGLBatch
          .AddOneRecordP()
        End With
      End If
    End If

    sr.Close()
    myFrmProgress.Close()
    myTAXBCH.CloseFile()
  End Sub
  Public Sub BuildDs(ByRef Ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("TaxBchno", Type.GetType("System.Int16"))
      .Columns.Add("Fund", Type.GetType("System.Int16"))
      .Columns.Add("GLBchno", Type.GetType("System.Int16"))
      .Columns.Add("TotalDR", Type.GetType("System.Decimal"))
      .Columns.Add("TotalCR", Type.GetType("System.Decimal"))
    End With
    Ds.Tables.Add(myTable)
  End Sub
  Public Sub BuildDsErr(ByRef DsErr As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("SortData", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int16"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Code", Type.GetType("System.String"))
      .Columns.Add("Suspense", Type.GetType("System.String"))
      .Columns.Add("Dist", Type.GetType("System.Int16"))
    End With
    DsErr.Tables.Add(myTable)
  End Sub
  Private Sub GetTXGL(ByVal WrkStat As String, ByVal WrkYear As Integer, ByVal WrkType As String, ByVal WrkCode As String,
 ByVal WrkPenalty As Boolean, ByVal WrkDist As Integer)
    Dim WrkSuspense As String
    Dim WrkError As Boolean
    WrkSuspense = "N"
    WrkError = False
    If WrkStat = "S" Then
      WrkSuspense = "Y"
    End If
    myTXGL.GetOneRecordP(WrkYear, WrkType, WrkCode, WrkSuspense, WrkDist, "")
    'Retry using Phase 0
    If myTXGL.RecordNotFound Then
      myTXGL.GetOneRecordP(WrkYear, WrkType, WrkCode, WrkSuspense, WrkDist, "0")
    End If
    'if Penalty and code not found default to interest
    If WrkPenalty Then
      If myTXGL.RecordNotFound Then
        myTXGL.GetOneRecordP(WrkYear, WrkType, "IN", WrkSuspense, WrkDist, "")
      End If
      If myTXGL.RecordNotFound Then
        myTXGL.GetOneRecordP(WrkYear, WrkType, "IN", WrkSuspense, WrkDist, "0")
      End If
    End If
    If myTXGL.RecordNotFound Then
      dr = dsErr.Tables(0).NewRow
      dr.Item("sortdata") = WrkYear & WrkType & WrkCode & WrkSuspense & WrkDist
      dr.Item("year") = WrkYear
      dr.Item("type") = WrkType
      dr.Item("code") = WrkCode
      dr.Item("suspense") = WrkSuspense
      dr.Item("dist") = WrkDist
      dsErr.Tables(0).Rows.Add(dr)
    End If

  End Sub
  Private Sub WriteArr(ByVal WrkStat As String, ByVal WrkYear As Integer, ByVal WrkType As String, ByVal WrkCode As String,
 ByVal WrkAmount As Decimal, ByVal WrkRefund As Boolean, ByVal WrkPenalty As Boolean, ByVal WrkDist As Integer)
    Dim K As Integer
    Dim WrkAcctRC As String
    Dim WrkAcctRD As String
    Dim WrkAcctLC As String
    Dim WrkAcctLD As String
    Dim WrkSuspense As String

    WrkSuspense = "N"
    If WrkStat = "S" Then
      WrkSuspense = "Y"
    End If

    myTXGL.GetOneRecordP(WrkYear, WrkType, WrkCode, WrkSuspense, WrkDist, "")
    'Retry using Phase 0
    If myTXGL.RecordNotFound Then
      myTXGL.GetOneRecordP(WrkYear, WrkType, WrkCode, WrkSuspense, WrkDist, "0")
    End If
    'if Penalty and code not found default to interest
    If WrkPenalty Then
      If myTXGL.RecordNotFound Then
        myTXGL.GetOneRecordP(WrkYear, WrkType, "IN", WrkSuspense, WrkDist, "")
      End If
      If myTXGL.RecordNotFound Then
        myTXGL.GetOneRecordP(WrkYear, WrkType, "IN", WrkSuspense, WrkDist, "0")
      End If
    End If

    WrkAcctRC = String.Empty
    WrkAcctRD = String.Empty
    WrkAcctLC = String.Empty
    WrkAcctLD = String.Empty
    If Not myTXGL.RecordNotFound Then
      If myTXGL._FDNRC <> 0 Then
        WrkAcctRC = BuildAcct(myTXGL._FDNRC, myTXGL._SFURC, myTXGL._DPNRC, myTXGL._OBNRC,
      myTXGL._FNPRC, myTXGL._SUBRC)
        K = LookupGLAcct(WrkAcctRC)
        ArrAcct(K) = WrkAcctRC
        If WrkRefund Then
          ArrAmount(K) = ArrAmount(K) + WrkAmount
        Else
          ArrAmount(K) = ArrAmount(K) - WrkAmount
        End If
        If ArrAmount(K) >= 0 Then
            ArrCRDB(K) = "D"
          Else
            ArrCRDB(K) = "C"
          End If
        End If
        If myTXGL._FDNRD <> 0 Then
        If Not myTXGLWB.RecordNotFound And WrkStat = "W" Then
          WrkAcctRD = BuildAcct(myTXGLWB._FDNRW, myTXGLWB._SFURW, myTXGLWB._DPNRW, myTXGLWB._OBNRW,
        myTXGLWB._FNPRW, myTXGLWB._SUBRW)
        Else
          WrkAcctRD = BuildAcct(myTXGL._FDNRD, myTXGL._SFURD, myTXGL._DPNRD, myTXGL._OBNRD,
        myTXGL._FNPRD, myTXGL._SUBRD)
        End If
        K = LookupGLAcct(WrkAcctRD)
        ArrAcct(K) = WrkAcctRD
        If WrkRefund Then
          ArrAmount(K) = ArrAmount(K) - WrkAmount
        Else
          ArrAmount(K) = ArrAmount(K) + WrkAmount
        End If
        If ArrAmount(K) >= 0 Then
          ArrCRDB(K) = "D"
        Else
          ArrCRDB(K) = "C"
        End If
      End If
      If myTXGL._FDNLC <> 0 Then
        WrkAcctLC = BuildAcct(myTXGL._FDNLC, myTXGL._SFULC, myTXGL._DPNLC, myTXGL._OBNLC,
      myTXGL._FNPLC, myTXGL._SUBLC)
        K = LookupGLAcct(WrkAcctLC)
        ArrAcct(K) = WrkAcctLC
        If WrkRefund Then
          ArrAmount(K) = ArrAmount(K) + WrkAmount
        Else
          ArrAmount(K) = ArrAmount(K) - WrkAmount
        End If
        If ArrAmount(K) >= 0 Then
          ArrCRDB(K) = "D"
        Else
          ArrCRDB(K) = "C"
        End If
      End If
      If myTXGL._FDNLD <> 0 Then
        WrkAcctLD = BuildAcct(myTXGL._FDNLD, myTXGL._SFULD, myTXGL._DPNLD, myTXGL._OBNLD,
      myTXGL._FNPLD, myTXGL._SUBLD)
        K = LookupGLAcct(WrkAcctLD)
        ArrAcct(K) = WrkAcctLD
        If WrkRefund Then
          ArrAmount(K) = ArrAmount(K) - WrkAmount
        Else
          ArrAmount(K) = ArrAmount(K) + WrkAmount
        End If
        If ArrAmount(K) >= 0 Then
          ArrCRDB(K) = "D"
        Else
          ArrCRDB(K) = "C"
        End If
      End If
    End If
  End Sub

  Private Sub ProcessAccts(ByVal WrkBatchNo As Integer, ByVal WrkPostDt As Integer,
 ByVal WrkPayDt As Integer, ByVal WrkTaxBatchNo As Integer, ByVal WrkDist As Integer)
    Dim I As Integer
    Dim WrkSeqNo As Integer

    If Not WrkPost Then Exit Sub

    For I = 0 To 100
      If ArrAcct(I) = String.Empty Then Exit For
      If ArrCRDB(I) = "D" Then
        WrkTotal = WrkTotal + ArrAmount(I)
      End If
    Next
    WrkTotal = Math.Abs(WrkTotal)

    'write batch totals to seqno 0
    WriteBatch(WrkBatchNo, WrkPostDt, WrkPayDt, WrkTaxBatchNo, WrkDist, 0, -1)

    For I = 0 To 100
      If ArrAcct(I) = String.Empty Then Exit Sub
      WrkSeqNo = WrkSeqNo + 5
      WriteBatch(WrkBatchNo, WrkPostDt, WrkPayDt, WrkTaxBatchNo, WrkDist, WrkSeqNo, I)
    Next
  End Sub
  Private Sub WriteBatch(ByVal WrkBatchNo As Integer, ByVal WrkPostDt As Integer, ByVal WrkPayDt As Integer,
 ByVal WrkTaxBatchNo As Integer, ByVal WrkDist As Integer, ByVal WrkSeqNo As Integer, ByVal I As Integer)

    Dim WrkFund As Integer
    Dim WrkSFund As Integer
    Dim WrkDpnbr As Integer
    Dim WrkObnbr As Integer
    Dim WrkFnpgm As Integer
    Dim WrkSubfn As Integer

    If WrkSeqNo > 0 Then
      BreakAcct(ArrAcct(I), WrkFund, WrkSFund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
    Else
      BreakAcct(ArrAcct(0), WrkFund, 0, 0, 0, 0, 0)
    End If
    With myTAXBCH
      .GetOneRecordP(WrkBatchNo, WrkBatchNo, WrkSeqNo)
      ._BCHNO = WrkBatchNo
      ._TRNBR = WrkBatchNo
      ._DIST = WrkDist
      ._FDNBR = WrkFund
      ._SFUND = WrkSFund
      ._DPNBR = WrkDpnbr
      ._OBNBR = WrkObnbr
      ._FNPGM = WrkFnpgm
      ._SUBFN = WrkSubfn
      ._DESCR = "TAX REC " & WrkPostDt
      If WrkSeqNo > 0 Then
        If ArrAmount(I) < 0 Then
          ._AMT = Math.Abs(ArrAmount(I))
        Else
          ._AMT = ArrAmount(I)
        End If
        ._AMTTYP = ArrCRDB(I)
        myGLACCT.GetOneRecordP(WrkFund, WrkSFund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
        ._GLTYP = myGLACCT._GLTYP
      Else
        ._AMT = 0
        ._AMTTYP = String.Empty
        ._GLTYP = String.Empty
      End If
      ._JACT8 = WrkPayDt
      ._JENT8 = WrkPayDt
      ._JRNSEQ = WrkSeqNo
      ._REFNO = WrkTaxBatchNo
      ._SRCDE = 6
      If WrkSeqNo = 0 Then
        ._TOTCR = WrkTotal
        ._TOTDR = WrkTotal
      Else
        ._TOTCR = 0
        ._TOTDR = 0
      End If
      ._TRNTYP = "X"
      .AddOneRecordP()
    End With
  End Sub
  Private Sub WriteTotals(ByVal WrkBatchNo As Integer, ByVal WrkTaxBatchNo As Integer, ByVal WrkDist As Integer)
    If Not WrkPost Then GoTo Detail

    With myBCHHDR
      ._APPID = CBatchType
      ._BCHNO = WrkBatchNo
      ._ORGUS = "GEMSNET"
      ._STATS = "S"
      ._SUBST = ""
      ._PSDT = MyUtils.SetDBDate(Date.Today)
      .AddOneRecordP()
    End With

    myBCHHDR.GetOneRecordP(CBatchType, 0)
    If Not myBCHHDR.RecordNotFound Then
      With myBCHHDR
        ._LSBCH = WrkBatchNo
        .UpdateOneRecordP()
      End With
    Else
      With myBCHHDR
        ._APPID = CBatchType
        ._BCHNO = 0
        ._LSBCH = WrkBatchNo
        .AddOneRecordP()
      End With
    End If

Detail:
    dr = ds.Tables(0).NewRow
    dr.Item("taxbchno") = WrkTaxBatchNo
    dr.Item("fund") = WrkDist
    dr.Item("glbchno") = WrkBatchNo
    dr.Item("totalcr") = WrkTotal
    dr.Item("totaldr") = WrkTotal
    ds.Tables(0).Rows.Add(dr)
  End Sub
  Private Function LookupGLAcct(ByVal Acct As String) As Integer
    Dim I As Integer

    For I = 0 To ArrAcct.GetUpperBound(0)
      If ArrAcct(I) = String.Empty Then
        Return I
      End If
      If Acct = ArrAcct(I) Then
        Return I
      End If
    Next

  End Function
  Private Function BuildAcct(ByVal Fund As Integer, ByVal SFund As Integer, ByVal Dept As Integer, ByVal Obj As Integer,
 ByVal Func As Integer, ByVal Subfn As Integer) As String
    Dim sb As StringBuilder = New StringBuilder

    sb.Append(Format(Fund, "000"))
    sb.Append("-")
    sb.Append(Format(SFund, "000"))
    sb.Append("-")
    sb.Append(Format(Dept, "0000"))
    sb.Append("-")
    sb.Append(Format(Obj, "000"))
    sb.Append("-")
    sb.Append(Format(Func, "0000"))
    sb.Append("-")
    sb.Append(Format(Subfn, "0000"))
    Return sb.ToString
  End Function
  Private Sub BreakAcct(ByVal In_Acct As String, ByRef Out_Fund As Integer, ByRef Out_SFund As Integer, ByRef Out_Dept As Integer,
 ByRef Out_Obj As Integer, ByRef Out_Func As Integer, ByRef Out_Subfn As Integer)
    Dim sb As StringBuilder = New StringBuilder

    Out_Fund = Mid(In_Acct, 1, 3)
    Out_SFund = Mid(In_Acct, 5, 3)
    Out_Dept = Mid(In_Acct, 9, 4)
    Out_Obj = Mid(In_Acct, 14, 3)
    Out_Func = Mid(In_Acct, 18, 4)
    Out_Subfn = Mid(In_Acct, 23, 4)
  End Sub
End Module
