Imports System.io
Imports System.Text
Module ProcTransfer

  Dim myPRCHK As PRCHK.MyData
  Dim myPRCHKD As PRCHKD.MyData
  Dim myPRSUP As PRSUP.MyData
  Dim myPRSUPD As PRSUPD.MyData
  Dim myW2PRINT As W2PRINT.MyData
  Dim WrkFilePath As String
  Dim WrkHost As String
  Dim WrkUser As String
  Dim WrkPassword As String
  Dim WrkPrchkDte As String
  Dim WrkPrsupDte As String
  Public Sub ProcTrans()
    Dim WrkChkSup As Boolean
    With MyFrmPRFTPB
      WrkHost = .TxtHost.Text
      WrkUser = .TxtUser.Text
      WrkPassword = .TxtPassword.Text
      WrkChkSup = .RbChkSup.Checked
    End With

    If WrkChkSup Then
      GetFile(WrkHost, WrkUser, WrkPassword, MyUtils.GetDataPath & "prchk.txt", "PRCHK", "QS36F")
      GetFile(WrkHost, WrkUser, WrkPassword, MyUtils.GetDataPath & "prchkd.txt", "PRCHKD", "QS36F")
      GetFile(WrkHost, WrkUser, WrkPassword, MyUtils.GetDataPath & "prsup.txt", "PRSUP", "QS36F")
      GetFile(WrkHost, WrkUser, WrkPassword, MyUtils.GetDataPath & "prsupd.txt", "PRSUPD", "QS36F")
      WritePRCHK()
      WritePRCHKD()
      WritePRSUP()
      WritePRSUPD()
      MsgBox("Check Date is " & WrkPrchkDte & vbCrLf & "Support Date is " & WrkPrsupDte, MsgBoxStyle.Information, "Download has completed")
    Else
      GetFile(WrkHost, WrkUser, WrkPassword, MyUtils.GetDataPath & "w2print.txt", "W2PRINT", MyLibraryName)
      WritePRCHK()
    End If
  End Sub
  Public Sub WritePRCHK()
    Dim WrkStream As FileStream = New FileStream(MyUtils.GetDataPath & "prchk.txt", FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim WrkChkNo As Integer
    Dim WrkPct As Integer
    Dim SavePct As Integer
    Dim I As Integer

    myPRCHK = New PRCHK.MyData(myDBConnect)
    myPRCHK.DeleteAllRecords()
    MyFrmProgress = New FrmProgress
    MyFrmProgress.Show()
    MyFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    WrkPrchkDte = ""
NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo Done
    End If

    I = I + strBuffer.Length
    WrkChkNo = MyUtils.CnvSng(Mid(strBuffer, 1, 7))
    myPRCHK.GetOneRecordP(WrkChkNo)
    With myPRCHK
      ._CPCKNO = WrkChkNo
      WrkPrchkDte = Mid(strBuffer, 8, 2) & "/" & Mid(strBuffer, 10, 2) & "/" & Mid(strBuffer, 12, 4)
      ._CPCKDT = MyUtils.CnvSng(Mid(strBuffer, 8, 8))
      ._CPEMP = MyUtils.CnvSng(Mid(strBuffer, 16, 7))
      ._PAYTYP = Trim(Mid(strBuffer, 23, 1))
      ._NAME = Trim(Mid(strBuffer, 24, 40))
      ._ADDR1 = Trim(Mid(strBuffer, 64, 40))
      ._ADDR2 = Trim(Mid(strBuffer, 104, 40))
      ._ADDR3 = Trim(Mid(strBuffer, 144, 40))
      ._CPFND = MyUtils.CnvSng(Mid(strBuffer, 184, 3))
      ._CPDEPT = MyUtils.CnvSng(Mid(strBuffer, 187, 4))
      ._YTDDED = MyUtils.CnvSng(Mid(strBuffer, 191, 9)) / 100
      ._YTDGRS = MyUtils.CnvSng(Mid(strBuffer, 200, 9)) / 100
      ._CURDED = MyUtils.CnvSng(Mid(strBuffer, 209, 9)) / 100
      ._GROSS = MyUtils.CnvSng(Mid(strBuffer, 218, 9)) / 100
      ._NETPAY = MyUtils.CnvSng(Mid(strBuffer, 227, 9)) / 100
      .AddOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        Exit Sub
      End If
    End With

NextRec:
    With MyFrmProgress
      WrkPct = I / WrkFileSize
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo NextLine

Done:
    sr.Close()
    MyFrmProgress.Close()
    myPRCHK.CloseFile()
  End Sub
  Public Sub WritePRCHKD()
    Dim WrkStream As FileStream = New FileStream(MyUtils.GetDataPath & "prchkd.txt", FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim WrkChkNo As Integer
    Dim WrkSeqNo As Integer
    Dim WrkPct As Integer
    Dim SavePct As Integer
    Dim I As Integer

    myPRCHKD = New PRCHKD.MyData(myDBConnect)
    myPRCHKD.DeleteAllRecords()
    MyFrmProgress = New FrmProgress
    MyFrmProgress.Show()
    MyFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo Done
    End If

    I = I + strBuffer.Length
    WrkChkNo = MyUtils.CnvSng(Mid(strBuffer, 1, 7))
    WrkSeqNo = MyUtils.CnvSng(Mid(strBuffer, 8, 2))
    myPRCHKD.GetOneRecordP(WrkChkNo, WrkSeqNo)
    With myPRCHKD
      ._CPCKNO = WrkChkNo
      ._SEQNO = WrkSeqNo
      ._EHOURS = MyUtils.CnvSng(Mid(strBuffer, 10, 5)) / 100
      ._EDESC = Trim(Mid(strBuffer, 15, 14))
      ._EAMT = MyUtils.CnvSng(Mid(strBuffer, 29, 9)) / 100
      ._EYTD = MyUtils.CnvSng(Mid(strBuffer, 38, 9)) / 100
      ._DDESC = Trim(Mid(strBuffer, 47, 14))
      ._DAMT = MyUtils.CnvSng(Mid(strBuffer, 61, 9)) / 100
      ._DYTD = MyUtils.CnvSng(Mid(strBuffer, 70, 9)) / 100
      ._ACODE = Trim(Mid(strBuffer, 79, 1))
      .AddOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        Exit Sub
      End If
    End With

NextRec:
    With MyFrmProgress
      WrkPct = I / WrkFileSize
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo NextLine

Done:
    sr.Close()
    MyFrmProgress.Close()
    myPRCHKD.CloseFile()
  End Sub
  Public Sub WritePRSUP()
    Dim WrkStream As FileStream = New FileStream(MyUtils.GetDataPath & "prsup.txt", FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim WrkChkNo As Integer
    Dim WrkPct As Integer
    Dim SavePct As Integer
    Dim I As Integer

    myPRSUP = New PRSUP.MyData(myDBConnect)
    myPRSUP.DeleteAllRecords()
    MyFrmProgress = New FrmProgress
    MyFrmProgress.Show()
    MyFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    WrkPrsupDte = ""

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo Done
    End If

    I = I + strBuffer.Length
    WrkChkNo = MyUtils.CnvSng(Mid(strBuffer, 1, 7))
    myPRSUP.GetOneRecordP(WrkChkNo)
    With myPRSUP
      ._CPCKNO = WrkChkNo
      WrkPrsupDte = Mid(strBuffer, 8, 2) & "/" & Mid(strBuffer, 10, 2) & "/" & Mid(strBuffer, 12, 4)
      ._CPCKDT = MyUtils.CnvSng(Mid(strBuffer, 8, 8))
      ._CPEMP = MyUtils.CnvSng(Mid(strBuffer, 16, 7))
      ._PAYTYP = Trim(Mid(strBuffer, 23, 1))
      ._NAME = Trim(Mid(strBuffer, 24, 40))
      ._ADDR1 = Trim(Mid(strBuffer, 64, 40))
      ._ADDR2 = Trim(Mid(strBuffer, 104, 40))
      ._ADDR3 = Trim(Mid(strBuffer, 144, 40))
      ._ADDR4 = Trim(Mid(strBuffer, 184, 40))
      ._ZIP = Trim(Mid(strBuffer, 224, 5))
      ._ZIP4 = Trim(Mid(strBuffer, 229, 5))
      ._CPFND = MyUtils.CnvSng(Mid(strBuffer, 233, 3))
      ._CPDEPT = MyUtils.CnvSng(Mid(strBuffer, 236, 4))
      ._YTDDED = MyUtils.CnvSng(Mid(strBuffer, 240, 9)) / 100
      ._YTDGRS = MyUtils.CnvSng(Mid(strBuffer, 249, 9)) / 100
      ._CURDED = MyUtils.CnvSng(Mid(strBuffer, 258, 9)) / 100
      ._GROSS = MyUtils.CnvSng(Mid(strBuffer, 267, 9)) / 100
      ._NETPAY = MyUtils.CnvSng(Mid(strBuffer, 276, 9)) / 100
      .AddOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        Exit Sub
      End If
    End With

NextRec:
    With MyFrmProgress
      WrkPct = I / WrkFileSize
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo NextLine

Done:
    sr.Close()
    MyFrmProgress.Close()
    myPRSUP.CloseFile()
  End Sub
  Public Sub WritePRSUPD()
    Dim WrkStream As FileStream = New FileStream(MyUtils.GetDataPath & "prsupd.txt", FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim WrkChkNo As Integer
    Dim WrkSeqNo As Integer
    Dim WrkPct As Integer
    Dim SavePct As Integer
    Dim I As Integer

    myPRSUPD = New PRSUPD.MyData(myDBConnect)
    myPRSUPD.DeleteAllRecords()
    MyFrmProgress = New FrmProgress
    MyFrmProgress.Show()
    MyFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo Done
    End If

    I = I + strBuffer.Length
    WrkChkNo = MyUtils.CnvSng(Mid(strBuffer, 1, 7))
    WrkSeqNo = MyUtils.CnvSng(Mid(strBuffer, 8, 2))
    myPRSUPD.GetOneRecordP(WrkChkNo, WrkSeqNo)
    With myPRSUPD
      ._CPCKNO = WrkChkNo
      ._SEQNO = WrkSeqNo
      ._EHOURS = MyUtils.CnvSng(Mid(strBuffer, 10, 5)) / 100
      ._EDESC = Trim(Mid(strBuffer, 15, 14))
      ._EAMT = MyUtils.CnvSng(Mid(strBuffer, 29, 9)) / 100
      ._EYTD = MyUtils.CnvSng(Mid(strBuffer, 38, 9)) / 100
      ._DDESC = Trim(Mid(strBuffer, 47, 14))
      ._DAMT = MyUtils.CnvSng(Mid(strBuffer, 61, 9)) / 100
      ._DYTD = MyUtils.CnvSng(Mid(strBuffer, 70, 9)) / 100
      .AddOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        Exit Sub
      End If
    End With

NextRec:
    With MyFrmProgress
      WrkPct = I / WrkFileSize
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo NextLine

Done:
    sr.Close()
    MyFrmProgress.Close()
    myPRSUPD.CloseFile()
  End Sub
  Public Sub WriteW2PRINT()
    Dim WrkStream As FileStream = New FileStream(MyUtils.GetDataPath & "w2print.txt", FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim WrkCntrl As Long
    Dim WrkPct As Integer
    Dim SavePct As Integer
    Dim I As Integer

    myW2PRINT = New W2PRINT.MyData(myDBConnect)
    myW2PRINT.DeleteAllRecords()
    MyFrmProgress = New FrmProgress
    MyFrmProgress.Show()
    MyFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    WrkPrchkDte = ""
NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo Done
    End If

    I = I + strBuffer.Length
    WrkCntrl = MyUtils.CnvSng(Mid(strBuffer, 152, 9))
    myW2PRINT.GetOneRecordP(WrkCntrl)
    With myW2PRINT
      ._W2YEAR = MyUtils.CnvSng(Mid(strBuffer, 1, 4))
      ._WEMPNO = MyUtils.CnvSng(Mid(strBuffer, 5, 7))
      ._WSSN = Trim(Mid(strBuffer, 12, 11))
      ._WFEDID = Trim(Mid(strBuffer, 23, 9))
      ._WERNAM = Trim(Mid(strBuffer, 32, 40))
      ._WERAD1 = Trim(Mid(strBuffer, 72, 40))
      ._WERAD2 = Trim(Mid(strBuffer, 112, 40))
      ._WCNTRL = WrkCntrl
      ._WEMFNM = Trim(Mid(strBuffer, 161, 17))
      ._WEMLNM = Trim(Mid(strBuffer, 178, 20))
      ._WEMSUF = Trim(Mid(strBuffer, 198, 3))
      ._WEMAD1 = Trim(Mid(strBuffer, 201, 40))
      ._WEMAD2 = Trim(Mid(strBuffer, 241, 40))
      ._WEMAD3 = Trim(Mid(strBuffer, 281, 40))
      ._WFITGR = MyUtils.CnvSng(Mid(strBuffer, 321, 9)) / 100
      ._WFITTX = MyUtils.CnvSng(Mid(strBuffer, 330, 9)) / 100
      ._WFICGR = MyUtils.CnvSng(Mid(strBuffer, 339, 9)) / 100
      ._WFICTX = MyUtils.CnvSng(Mid(strBuffer, 348, 9)) / 100
      ._WMEDGR = MyUtils.CnvSng(Mid(strBuffer, 357, 9)) / 100
      ._WMEDTX = MyUtils.CnvSng(Mid(strBuffer, 366, 9)) / 100
      ._WSSTIP = MyUtils.CnvSng(Mid(strBuffer, 375, 9)) / 100
      ._WALTIP = MyUtils.CnvSng(Mid(strBuffer, 384, 9)) / 100
      ._WDEPC = MyUtils.CnvSng(Mid(strBuffer, 393, 9)) / 100
      ._WNONQ = MyUtils.CnvSng(Mid(strBuffer, 402, 9)) / 100
      ._WCD12A = Trim(Mid(strBuffer, 411, 2))
      ._WCD12B = Trim(Mid(strBuffer, 413, 2))
      ._WCD12C = Trim(Mid(strBuffer, 415, 2))
      ._WCD12D = Trim(Mid(strBuffer, 417, 2))
      ._WAM12A = MyUtils.CnvSng(Mid(strBuffer, 419, 9)) / 100
      ._WAM12B = MyUtils.CnvSng(Mid(strBuffer, 428, 9)) / 100
      ._WAM12C = MyUtils.CnvSng(Mid(strBuffer, 437, 9)) / 100
      ._WAM12D = MyUtils.CnvSng(Mid(strBuffer, 446, 9)) / 100
      ._WBX13A = Trim(Mid(strBuffer, 455, 1))
      ._WBX13B = Trim(Mid(strBuffer, 456, 1))
      ._WBX13C = Trim(Mid(strBuffer, 457, 1))
      ._WCD14A = Trim(Mid(strBuffer, 458, 6))
      ._WCD14B = Trim(Mid(strBuffer, 464, 6))
      ._WCD14C = Trim(Mid(strBuffer, 470, 6))
      ._WCD14D = Trim(Mid(strBuffer, 476, 6))
      ._WAM14A = MyUtils.CnvSng(Mid(strBuffer, 482, 9)) / 100
      ._WAM14B = MyUtils.CnvSng(Mid(strBuffer, 491, 9)) / 100
      ._WAM14C = MyUtils.CnvSng(Mid(strBuffer, 500, 9)) / 100
      ._WAM14D = MyUtils.CnvSng(Mid(strBuffer, 509, 9)) / 100
      ._WSTATC = Trim(Mid(strBuffer, 518, 2))
      ._WSTATNo = Trim(Mid(strBuffer, 520, 12))
      ._WSTGRS = MyUtils.CnvSng(Mid(strBuffer, 532, 9)) / 100
      ._WSTTAX = MyUtils.CnvSng(Mid(strBuffer, 541, 9)) / 100
      ._WLOGRS = MyUtils.CnvSng(Mid(strBuffer, 550, 9)) / 100
      ._WLOTAX = MyUtils.CnvSng(Mid(strBuffer, 559, 9)) / 100
      ._WLONAM = Trim(Mid(strBuffer, 568, 15))
      .AddOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        Exit Sub
      End If
    End With

NextRec:
    With MyFrmProgress
      WrkPct = I / WrkFileSize
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo NextLine

Done:
    sr.Close()
    MyFrmProgress.Close()
    myW2PRINT.CloseFile()
  End Sub
End Module
