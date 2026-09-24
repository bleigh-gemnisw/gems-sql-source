Imports System.io
Imports System.Text
Module ProcessBatch

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myBCHHDR As BCHHDR.myData
Dim myGLACCT As GLACCT.myData
Dim myRQEBCH As RQEBCH.myData
Const cBatchType As String = "PMS"

Public Sub ProcBatch()
 myBCHHDR = New BCHHDR.MyData()
 myBCHHDR.MyDBConn = myDBConnect
 myRQEBCH = New RQEBCH.MyData()
 myRQEBCH.MyDBConn = myDBConnect
 myGLACCT = New GLACCT.MyData()
 myGLACCT.MyDBConn = myDBConnect

 GetDetail()

End Sub
  Private Sub GetDetail()
    Dim WrkStream As FileStream = New FileStream(MyFrmPO201C_New.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim WrkBatchNo As Integer
    Dim WrkFund As Integer
    Dim WrkSFund As Integer
    Dim WrkDpnbr As Integer
    Dim WrkObnbr As Integer
    Dim WrkFnpgm As Integer
    Dim WrkSubfn As Integer
    Dim strBuffer As String
    Dim sArray() As String
    Dim WrkTotalCR As Decimal
    Dim WrkTotalDR As Decimal
    Dim WrkDbDate As Integer
    Dim I As Integer
    Dim Counter As Integer

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0
    WrkTotalCR = 0
    WrkTotalDR = 0
    WrkFileSize = WrkStream.Length
NextBatchNo:
    WrkBatchNo = myBCHHDR.AutoGenKey(cBatchType)

    myBCHHDR.GetOneRecordP(cBatchType, 0)
    If Not myBCHHDR.RecordNotFound Then
      With myBCHHDR
        ._LSBCH = WrkBatchNo
        .UpdateOneRecordP()
      End With
    Else
      With myBCHHDR
        ._APPID = cBatchType
        ._BCHNO = 0
        ._LSBCH = WrkBatchNo
        .AddOneRecordP()
      End With
    End If

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo WriteBatchTot
      Exit Sub
    End If

    Counter = Counter + 1
    sArray = Parse(strBuffer, ",")
    I = I + strBuffer.Length

    If MyUtils.CnvSng(sArray(2)) = 0 Then GoTo NextRec
    BreakAcct(sArray(0), WrkFund, WrkSFund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
    With myRQEBCH
      .GetOneRecordP(WrkBatchNo, WrkBatchNo, Counter * 5)
      ._BCHNO = WrkBatchNo
      ._TRNBR = WrkBatchNo
      ._FDNBR = WrkFund
      ._SFUND = WrkSFund
      ._DPNBR = WrkDpnbr
      ._OBNBR = WrkObnbr
      ._FNPGM = WrkFnpgm
      ._SUBFN = WrkSubfn
      ._DESCR = Mid(sArray(1), 1, 20)
      ._AMT = MyUtils.CnvSng(sArray(2))
      ._AMTTYP = sArray(3)
      WrkDbDate = MyUtils.SetDBDate(sArray(4))
      myGLACCT.GetOneRecordP(WrkFund, WrkSFund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
      If myGLACCT.RecordNotFound Then
        ._GLTYP = ""
      Else
        ._GLTYP = myGLACCT._GLTYP
      End If
      ._JACT8 = WrkDbDate
      ._JENT8 = WrkDbDate
      ._JRNSEQ = Counter * 5
      ._REFNO = 0
      ._SRCDE = 5
      ._TOTCR = 0
      ._TOTDR = 0
      ._TRNTYP = "X"
      .AddOneRecordP()
      If sArray(3) = "C" Then
        WrkTotalCR = WrkTotalCR + ._AMT
      Else
        WrkTotalDR = WrkTotalDR + ._AMT
      End If
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

WriteBatchTot:
    With myRQEBCH
      .GetOneRecordP(WrkBatchNo, WrkBatchNo, 0)
      ._BCHNO = WrkBatchNo
      ._TRNBR = WrkBatchNo
      ._FDNBR = 0
      ._SFUND = 0
      ._DPNBR = 0
      ._OBNBR = 0
      ._FNPGM = 0
      ._SUBFN = 0
      ._DESCR = ""
      ._AMT = 0
      ._AMTTYP = ""
      ._GLTYP = ""
      ._JACT8 = WrkDbDate
      ._JENT8 = WrkDbDate
      ._JRNSEQ = 0
      ._REFNO = 0
      ._SRCDE = 5
      ._TOTCR = WrkTotalCR
      ._TOTDR = WrkTotalDR
      ._TRNTYP = "X"
      .AddOneRecordP()
    End With

    With myBCHHDR
      .GetOneRecordP(cBatchType, WrkBatchNo)
      If Not .RecordNotFound Then GoTo NextBatchNo
      ._APPID = cBatchType
      ._BCHNO = WrkBatchNo
      ._ORGUS = "GEMSNET"
      ._STATS = "S"
      ._SUBST = ""
      ._PSDT = WrkDbDate
      ._NBRRC = Counter
      .AddOneRecordP()
    End With

    MsgBox("Batch " & WrkBatchNo & " has been created", MsgBoxStyle.Information, "New Batch")
    sr.Close()
    myFrmProgress.Close()
    myRQEBCH.CloseFile()

  End Sub
  Private Sub BreakAcct(ByVal In_Acct As String, ByRef Out_Fund As Integer, ByRef Out_SFund As Integer, ByRef Out_Dept As Integer, _
 ByRef Out_Obj As Integer, ByRef Out_Func As Integer, ByRef Out_Subfn As Integer)
 Dim sb As StringBuilder = New StringBuilder

 If Len(In_Acct) = 26 Then
   Out_Fund = Mid(In_Acct, 1, 3)
   Out_SFund = Mid(In_Acct, 5, 3)
   Out_Dept = Mid(In_Acct, 9, 4)
   Out_Obj = Mid(In_Acct, 14, 3)
   Out_Func = Mid(In_Acct, 18, 4)
   Out_Subfn = Mid(In_Acct, 23, 4)
 Else
   Out_Fund = 0
   Out_SFund = 0
   Out_Dept = 0
   Out_Obj = 0
   Out_Func = 0
   Out_Subfn = 0
 End If
End Sub
End Module
