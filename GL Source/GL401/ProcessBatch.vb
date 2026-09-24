Imports System.io
Imports System.Text
Module ProcessBatch

  Public MyImportFile As ImportFile
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myBCHHDR As BCHHDR.MyData
  Dim myGLEBCH As GLEBCH.MyData
  Dim myGLACCT As GLACCT.MyData
  Public Sub ProcBatch()
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myGLEBCH = New GLEBCH.MyData()
    myGLEBCH.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect

    GetImport()
  End Sub
  Private Sub GetImport()
    Dim WrkStream As FileStream = New FileStream(MyFrmGL401B_Import.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim WrkNextBatch As Integer
    Dim WrkBatchType As String
    Dim Counter As Integer

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Creating Batch"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0
    WrkBatchType = ""
    If MyFrmGL401B_Import.RbJE.Checked Then
      WrkBatchType = "GL"
    End If
    If MyFrmGL401B_Import.RbPRJE.Checked Then
      WrkBatchType = "PR"
    End If
    If MyFrmGL401B_Import.RbPRPaycor.Checked Then
      WrkBatchType = "Paycor"
    End If
    If MyFrmGL401B_Import.RbBudget.Checked Then
      WrkBatchType = "Budget"
    End If

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
        ._NBRRC = 0
        ._FREEA = WrkBatchType
        ._PSDT = MyUtils.SetDBDate(Date.Today)
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

    If myTOWN._TOWNBR = 37 Then 'Derby Header record
      strBuffer = sr.ReadLine
    End If
    MyImportFile = New ImportFile

ReadNext:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo End_of_file
    End If

    MyImportFile.StrBuffer = strBuffer
    Select Case WrkBatchType
      Case "Budget", "GL"
        MyImportFile.ReadJournal(WrkBatchType)
      Case "PR"
        If myTOWN._TOWNBR = 108 Or myTOWN._TOWNBR = 162 Then 'Oxford/Winchester
          MyImportFile.ReadJournal("GL")
          MyImportFile.CheckGlMap()
        Else
          MyImportFile.ReadPayroll()
        End If
      Case "Paycor"
        MyImportFile.ReadPayrollPaycor()
    End Select

    If MyImportFile.Amt > 0 Then
      myGLACCT.GetOneRecordP(MyImportFile.Fdnbr, MyImportFile.Sfund, MyImportFile.Dpnbr, MyImportFile.Obnbr, MyImportFile.Fnpgm, MyImportFile.Subfn)
      With myGLEBCH
        Counter = Counter + 1
        .GetOneRecordP(WrkNextBatch, WrkNextBatch, 0)
        ._AMT = MyImportFile.Amt
        ._AMTTYP = MyImportFile.Amttyp
        ._BCHNO = WrkNextBatch
        ._DESCR = MyImportFile.Descr & ""
        ._DPNBR = MyImportFile.Dpnbr
        ._FDNBR = MyImportFile.Fdnbr
        ._FNPGM = MyImportFile.Fnpgm
        ._GLTYP = myGLACCT._GLTYP
        ._JACT8 = MyImportFile.Jact8
        ._JENT8 = MyImportFile.Jent8
        If MyImportFile.Jrnseq > 0 Then
          ._JRNSEQ = MyImportFile.Jrnseq
        Else
          If MyImportFile.Mapped Then
            ._JRNSEQ = (Counter * 5) + 1
          Else
            ._JRNSEQ = (Counter * 5)
          End If
        End If
        ._OBNBR = MyImportFile.Obnbr
        ._REFNO = MyImportFile.Refno
        ._SFUND = MyImportFile.Sfund
        ._SUBFN = MyImportFile.Subfn
        ._TOTCR = MyImportFile.TotCR
        ._TOTDR = MyImportFile.TotDR
        ._TRNBR = MyImportFile.Fdnbr
        ._TRNTYP = MyImportFile.Trntyp
        .AddOneRecordP()
      End With
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

    If Counter > 0 Then
      myBCHHDR.GetOneRecordP(MyBatch, WrkNextBatch)
      If Not myBCHHDR.RecordNotFound Then
        With myBCHHDR
          ._NBRRC = Counter
          ._PSDT = MyImportFile.Jact8
          .UpdateOneRecordP()
        End With
      End If
    End If

    MsgBox("Batch " & WrkNextBatch & " has been created", MsgBoxStyle.Information, "New Batch")
    sr.Close()
    myFrmProgress.Close()
    myGLEBCH.CloseFile()
  End Sub
End Module
