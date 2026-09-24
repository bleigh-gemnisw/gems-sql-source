Imports System.io
Imports System.Text
Module ProcessFile

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myBCHHDR As BCHHDR.MyData
  Dim myAPEBCH As APEBCH.MyData
  Dim myAPEBCD As APEBCD.MyData
  Dim myGLACCT As GLACCT.MyData
  Dim myVENDOR As VENDOR.MyData
  Const CBatchType As String = "PAP"

  Public Sub ProcFile()

    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myAPEBCH = New APEBCH.MyData()
    myAPEBCH.MyDBConn = myDBConnect
    myAPEBCD = New APEBCD.MyData()
    myAPEBCD.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect

    With MyFrmAP230B
    End With

    GetDetail()
  End Sub
  Private Sub GetDetail()
    Dim WrkStream As FileStream = New FileStream(MyFrmAP230B.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim WrkNumRecs As Integer
    Dim strBuffer As String
    Dim SArray() As String
    Dim I As Integer
    Dim WrkBatchNo As Integer
    Dim WrkSeqNo As Integer
    Dim WrkMbrName As String
    Dim WrkTotSkipped As Integer
    Dim WrkMsg As String

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Creating Batches"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkBatchNo = myBCHHDR.AutoGenKey(CBatchType)
    WrkMbrName = "BCH" & WrkBatchNo
    WrkTotSkipped = 0
    WrkSeqNo = 0

    myBCHHDR.GetOneRecordP(CBatchType, 0)
    If myBCHHDR.RecordNotFound Then
      With myBCHHDR
        ._APPID = CBatchType
        ._BCHNO = 0
        .AddOneRecordP()
      End With
    End If

    WrkBatchNo = myBCHHDR.AutoGenKey(CBatchType)
    myBCHHDR.GetOneRecordP(CBatchType, WrkBatchNo)
    If myBCHHDR.RecordNotFound Then
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
      End If
    End If

    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header record
    WrkNumRecs = 0

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo WriteBatch
      Exit Sub
    End If

    WrkSeqNo = WrkSeqNo + 1
    SArray = Parse(strBuffer, ",")
    If Trim(SArray(14)) = "" Then
      WrkTotSkipped = WrkTotSkipped + 1
      GoTo NextRec
    End If
    I = I + strBuffer.Length
    With myAPEBCH
      .GetOneRecordP(WrkBatchNo, WrkSeqNo)
      ._AMTDS = 0
      ._AMTGR = SArray(12)
      ._AMTNT = SArray(12)
      ._AMTSH = 0
      ._APPST = MyUtils.SetDBDateMDY(SArray(11))
      ._BCHNO = WrkBatchNo
      ._BNKCD = ""
      ._CSHYN = ""
      ._DSCTX = Left(SArray(14), 30)
      ._DUED8 = MyUtils.SetDBDateMDY(SArray(11))
      ._F1099 = ""
      ._HINV = "P"
      ._INVD8 = MyUtils.SetDBDateMDY(SArray(11))
      ._INVNO = SArray(15)
      ._LEOPN = ""
      ._POLIQ = ""
      ._PPAMT = 0
      ._PPCKN = 0
      ._PPDT8 = 0
      ._PRJ = 0
      ._SEQNO = WrkSeqNo
      myVENDOR.GetOneRecordP(SArray(9))
      If Not myVENDOR.RecordNotFound Then
        ._VENNM = myVENDOR._VENNM
      Else
        ._VENNM = ""
      End If
      ._VNDNR = SArray(9)
      .AddOneRecordP()
    End With

    With myAPEBCD
      .GetOneRecordP(WrkBatchNo, WrkSeqNo, 10)
      ._AMTNT = SArray(12)
      ._BCHNO = WrkBatchNo
      ._DPNBR = SArray(3)
      ._FDNBR = SArray(1)
      ._FNPGM = SArray(7)
      ._OBNBR = SArray(5)
      ._RECNO = 10
      ._SEQNO = WrkSeqNo
      ._SFUND = 0
      ._SUBFN = 0
      .AddOneRecordP()
      WrkNumRecs = WrkNumRecs + 1
    End With

NextRec:
    With myFrmProgress
      WrkPct = I / WrkFileSize
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo NextLine

WriteBatch:
    myBCHHDR.GetOneRecordP(CBatchType, WrkBatchNo)
    With myBCHHDR
      ._NBRRC = WrkNumRecs
      .UpdateOneRecordP()
    End With

    WrkMsg = "Records Processed: " & WrkNumRecs & vbCrLf & "Records Skipped: " & WrkTotSkipped
    MsgBox(WrkMsg, MsgBoxStyle.Information, "A/P Batch " & WrkBatchNo & " created")

    sr.Close()
    myFrmProgress.Close()
    myAPEBCH.CloseFile()

  End Sub
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
End Module
