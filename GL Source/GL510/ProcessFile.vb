Imports System.Text
Module ProcessFile

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myGLBUDGETQ As GLBUDGETQ.MyData
Dim myGLBUDGET As GLBUDGET.MyData
Dim myBCHHDR As BCHHDR.MyData
Dim myGLEBCH As GLEBCH.MyData

Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow
'Screen  
Dim WrkSelFund As Integer
Dim WrkSelsfund As Integer
'General
Dim SaveGltyp As String
Dim WrkNextBatch As Integer
Dim WrkDatePost As Integer
Public Sub ProcFile()
  myGLBUDGETQ = New GLBUDGETQ.MyData()
  myGLBUDGETQ.MyDBConn = myDBConnect
  myGLBUDGET = New GLBUDGET.MyData()
  myGLBUDGET.MyDBConn = myDBConnect
  myBCHHDR = New BCHHDR.MyData()
  myBCHHDR.MyDBConn = myDBConnect
  myGLEBCH = New GLEBCH.MyData()
  myGLEBCH.MyDBConn = myDBConnect

  With MyFrmGL510B
    WrkSelFund = MyUtils.CnvSng(.TxtFund.Text)
    WrkSelsfund = MyUtils.CnvSng(.TxtSfund.Text)
    WrkDatePost = MyUtils.SetDBDate(.DtPckPost.Value)
  End With

  CreateBCHHDR()
  WriteBatch()
  MsgBox("Batch has been created", MsgBoxStyle.Information, "Process completed")
End Sub
Private Sub CreateBCHHDR()
  myBCHHDR = New BCHHDR.MyData()
  myBCHHDR.MyDBConn = myDBConnect
  myGLEBCH = New GLEBCH.MyData()
  myGLEBCH.MyDBConn = myDBConnect
  myBCHHDR.GetOneRecordP(MyBatch, 0)
  If myBCHHDR.RecordNotFound Then
    With myBCHHDR
      ._APPID = MyBatch
      ._BCHNO = 0
      .AddOneRecordP()
    End With
  End If

  WrkNextBatch = myBCHHDR.AutoGenKey(MyBatch)
  myBCHHDR.GetOneRecordP(MyBatch, WrkNextBatch)
  If myBCHHDR.RecordNotFound Then
    With myBCHHDR
      ._APPID = MyBatch
      ._BCHNO = WrkNextBatch
      ._ORGUS = "GEMSNET"
      ._LSTUS = MyUserID
      ._STATS = "S"
      ._SUBST = ""
      ._PSDT = WrkDatePost
      .AddOneRecordP()
    End With

    myBCHHDR.GetOneRecordP(MyBatch, 0)
    If Not myBCHHDR.RecordNotFound Then
      With myBCHHDR
        ._LSBCH = WrkNextBatch
        .UpdateOneRecordP()
      End With
    End If
  End If
End Sub
Private Sub WriteBatch()
  Dim WrkQry As String
  Dim WrkSort As String
  Dim WrkTran As Integer
  Dim WrkSeq As Integer
  Dim Counter As Integer
  Dim WrkAnd As String
  Dim WrkOr As String
  Dim WrkSet As String
  Dim WrkWhere As String

  WrkAnd = " and "
  WrkOr = " or "
  WrkQry = "FUND=" & WrkSelFund & WrkAnd & "SFUND=" & WrkSelsfund
  WrkQry = WrkQry & WrkAnd & "ADOPTD <> 0"
  WrkSort = ""
  myGLBUDGETQ.OpenQry(WrkSort, WrkQry)

  myFrmProgress = New FrmProgress
  myFrmProgress.LblMsg.Text = ""
  myFrmProgress.Show()
  myFrmProgress.Refresh()
  Application.DoEvents()

  WrkTran = myGLEBCH.AutoGenTran(WrkNextBatch)
  Counter = 0

ReadNext:
  myGLBUDGETQ.ReadQry()
  If Not myGLBUDGETQ.IsEOF Then
  With myGLBUDGETQ
    Counter = Counter + 1
    WrkSeq = myGLEBCH.AutoGenSeq(WrkNextBatch, WrkTran)
    myGLEBCH.GetOneRecordP(WrkNextBatch, WrkTran, WrkSeq)
    myGLEBCH._BCHNO = WrkNextBatch
    myGLEBCH._TRNBR = WrkTran
    myGLEBCH._JRNSEQ = WrkSeq
    myGLEBCH._TRNTYP = "Z"
    myGLEBCH._FDNBR = ._FUND
    myGLEBCH._SFUND = ._SFUND
    myGLEBCH._DPNBR = ._DEPT
    myGLEBCH._OBNBR = ._OBJ
    myGLEBCH._FNPGM = ._FUNC
    myGLEBCH._SUBFN = ._SFUNC
    myGLEBCH._DESCR = MyFrmGL510B.TxtDesc.Text
    myGLEBCH._AMT = ._ADOPTD
    myGLEBCH._GLTYP = ._GLTYP
    myGLEBCH._JACT8 = WrkDatePost
    myGLEBCH._JENT8 = WrkDatePost
    myGLEBCH._REFNO = 0
    myGLEBCH._PRJ = 0
    If ._GLTYP = "X" Then
      myGLEBCH._AMTTYP = "D"
      myGLEBCH._TOTDR = ._ADOPTD
      myGLEBCH._TOTCR = 0
    Else
      myGLEBCH._AMTTYP = "C"
      myGLEBCH._TOTCR = ._ADOPTD
      myGLEBCH._TOTDR = 0
    End If
    myGLEBCH.AddOneRecordP()
  End With 'myGLBUDGETQ

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

  If Counter > 0 Then
      WrkSet = "SET ACT5=ACT4,ACT4=ACT3,ACT3=ACT2, ACT2=ACT1, ACT1=EXP"
      WrkWhere = "WHERE FUND=" & WrkSelFund & WrkAnd & "SFUND=" & WrkSelsfund
    With myGLBUDGET
      .RunUpdateQuery(WrkSet, WrkWhere)
    End With
  End If
  myFrmProgress.Close()
  myGLBUDGETQ.CloseFile()
End Sub
End Module
