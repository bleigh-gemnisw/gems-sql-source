Imports System.IO
Imports System.Text
Module ImportData

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINV As TXINV.MyData
  Dim myTXHST As TXHST.MyData
  Dim WrkYear As Integer
  Dim WrkType As String
  Dim ds As DataSet = New DataSet
  Dim sw As StreamWriter
  Public Sub Impdata()
    Dim Good As Boolean

    MyDBName = MyFrmFix.TxtDBName.Text
    Good = Connect()

    If Not Good Then Exit Sub

    myTXINV = New TXINV.MyData(myDBConnect)
    myTXHST = New TXHST.MyData(myDBConnect)

    With MyFrmFix
      WrkType = .TxtType.Text
      WrkYear = CnvSng(.TxtYear.Text)
    End With
    GetDetail()
    MsgBox("Done", MsgBoxStyle.Information, "Conversion")
  End Sub
  Public Function Connect() As Boolean
    Dim Good As Boolean

    myDBConnect = New SQLConnect.DBConnection(MyDBName)
    myDBConnect.Open()
    Good = myDBConnect.IsConnected
    If Not Good Then
      MsgBox("Invalid database name", MsgBoxStyle.Critical, "Check database name")
    End If
    Return Good
  End Function
  Private Sub GetDetail()
    Dim sw As StreamWriter
    Dim WrkStream As FileStream
    Dim sr As StreamReader
    Const cMaxInt As Decimal = 99999.99
    Dim StrBuffer As String
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim WrkList As Integer
    Dim WrkRecID As Integer
    Const cYear As Integer = 2000
    Const cUType As String = "B"
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Long
    Dim I As Integer

    sw = New StreamWriter(GetDataPath() & "CnvAvon2.csv")
    WrkStream = New FileStream(MyFrmFix.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    sr = New StreamReader(WrkStream)
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header
    WrkRecID = myTXHST.AutoGenKey - 1
    Counter = 0
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      sw.Flush()
      sw.Close()
      myFrmProgress.Close()
      Exit Sub
    End If

    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    WrkList = CnvSng(RecArray(0))
    If WrkList = 0 Then
      GoTo NextRec
    End If
    myTXINV.GetOneRecordP(WrkList, cYear, cUType)
    If myTXINV.RecordNotFound Then
      sw.WriteLine(WrkList & " not found")
      GoTo NextRec
    End If

    With myTXHST
      Counter = Counter + 1
      WrkRecID = WrkRecID + 1
      ._BATCHA = ""
      ._BATCHN = CnvSng(RecArray(19))
      ._BATCHS = CnvSng(RecArray(20))
      ._CASH = 0
      If Trim(RecArray(3)) <> "" Then
        ._CDATE = SetDBDate(RecArray(3))
        ._CHDATE = SetDBDate(RecArray(3))
        ._PDATE = SetDBDate(RecArray(3))
      Else
        ._CDATE = 0
        ._CHDATE = 0
        ._PDATE = 0
      End If
      ._CHECK = 0
      ._CHTIME = 0
      ._COMM = Mid(RecArray(14), 1, 20)
      ._CORC = ""
      ._CREDIT = 0
      ._DIST = 0
      If CnvSng(RecArray(6)) + CnvSng(RecArray(8)) <= cMaxInt Then
        ._IAMT = CnvSng(RecArray(6)) + CnvSng(RecArray(8))
      Else
        ._IAMT = cMaxInt
        sw.WriteLine(WrkList & " max interest")
      End If
      ._INTOR = 0
      ._LAMT = CnvSng(RecArray(9))
      ._LISTNO = WrkList
      ._PAMT = CnvSng(RecArray(5)) + CnvSng(RecArray(7))
      ._PCAMT = CnvSng(RecArray(11))
      If ._PAMT < 0 Or ._IAMT < 0 Or ._PCAMT < 0 Or ._IAMT < 0 Then
        ._ADJCD = "A"
      Else
        ._ADJCD = ""
      End If
      If ._PCAMT <> 0 Then
        ._PENCD = "UK"
      Else
        ._PENCD = ""
      End If
      ._PRF = ""
      ._RCODE = ""
      ._RECID = WrkRecID
      ._REF = ""
      ._SUSCD = ""
      ._THAJCD = ""
      ._THINPD = 0
      ._TYPE = cUType
      ._YEAR = cYear
      .InsertOneRecordP()
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
    GoTo NextLine

  End Sub
  '  Private Sub WriteUTAS2()
  '    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileUTAS2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
  '    Dim sr As StreamReader = New StreamReader(WrkStream)
  '    Dim WrkFileSize As Integer
  '    Dim RecArray As String()
  '    Dim WrkNoUB As Boolean
  '    Dim WrkIsName As Boolean
  '    Dim WrkStr As String
  '    Dim WrkPct As Decimal
  '    Dim SavePct As Decimal
  '    Dim Counter As Decimal
  '    Dim I As Integer
  '    Dim Pos As Integer

  '    WrkFile = "UTAS"
  '    myDBConnect2.DeleteRecords2("UTCUSTRT", "CRTYPE='B'")
  '    myDBConnect2.DeleteRecords2("TXINV", "YEAR=2000 and TYPE='B'")
  '    WrkFileSize = WrkStream.Length
  '    strBuffer = sr.ReadLine 'Skip Header
  'NextLine:
  '    strBuffer = sr.ReadLine
  '    If Trim(strBuffer) = String.Empty Then
  '      Exit Sub
  '    End If

  '    I = I + strBuffer.Length
  '    RecArray = Parse(strBuffer, ",")
  '    If Trim(RecArray(17)) = "" Then
  '      GoTo NextLine
  '    End If
  '    SplitLoc(Trim(RecArray(18)))
  '    WrkNoUB = False
  '    With MyUTCUST
  '      .GetOneRecordPLoc(WrkLoc, WrkLocNo)
  '      If Trim(._CULOC) <> WrkLoc Or ._CULOCNO <> WrkLocNo Then
  '        With MyTXREAL
  '          WrkNoUB = True
  '          .GetOneRecordPLoc(WrkLoc, WrkLocNo)
  '          If Trim(._LOC) <> WrkLoc Or ._LOCNO <> WrkLocNo Then
  '            sw.WriteLine("UTAS No Loc " & RecArray(0) & " " & Trim(RecArray(18)))
  '            GoTo NextLine
  '          End If
  '          WrkListNo = ._LISTNO
  '          If Trim(._SEWER) <> "Y" Then
  '            ._SEWER = "Y"
  '            .UpdateOneRecordP()
  '          End If
  '        End With
  '      End If
  '      If Not WrkNoUB Then
  '        WrkListNo = ._CUACCT
  '      End If
  '    End With

  '    With MyUTCUSTAS
  '      Counter = Counter + 1
  '      .GetOneRecordP(WrkListNo, "B")
  '      If .RecordNotFound Then
  '        ._CAACCT = WrkListNo
  '        ._CAADJ = CnvSng(RecArray(2))
  '        ._CAAMT = CnvSng(RecArray(12))
  '        ._CADEF = 0
  '        ._CADEP = 0
  '        ._CALAT = 0
  '        ._CAOVR = CnvSng(RecArray(3))
  '        If ._CAADJ - ._CAAMT > 0 Then
  '          ._CAPNO = CnvSng(RecArray(1))
  '        Else
  '          ._CAPNO = 1
  '        End If
  '        ._CATYPE = "B"
  '        ._CAUNIF = 0
  '        Try
  '          .AddOneRecordP()
  '        Catch
  '          If .ErrMsg <> "" Then
  '            sw.WriteLine("UTAS " & RecArray(0) & " AddRecord " & .ErrMsg)
  '            GoTo NextLine
  '          End If
  '        End Try
  '      Else
  '        sw.WriteLine("UTAS " & RecArray(0) & " " & WrkListNo & " DupRecord")
  '        GoTo NextLine
  '      End If
  '    End With

  '    With MyUTCUSTRT
  '      Counter = Counter + 1
  '      .GetOneRecordP(WrkListNo, "B")
  '      ._CRACCT = WrkListNo
  '      ._CRCODE = "1"
  '      ._CRTYPE = "B"
  '      Try
  '        .AddOneRecordP()
  '      Catch
  '        If .ErrMsg <> "" Then
  '          sw.WriteLine("UTRT " & RecArray(0) & " " & .ErrMsg)
  '        End If
  '      End Try
  '    End With

  '    SplitCityST(Trim(RecArray(21)))
  '    With MyTXINV
  '      .ClearFields()
  '      WrkIsName = False
  '      Pos = 1
  '      ._ICODE = "I"
  '      WrkStr = Replace(RecArray(19), "'", "")
  '      WrkStr = Trim(WrkStr)
  '      If Mid(WrkStr, 1, 1) = "/" Or Mid(WrkStr, 1, 1) = "%" Then
  '        WrkIsName = True
  '        Pos = 2
  '      End If
  '      If Strings.Right(Trim(RecArray(17)), 1) = "&" Or Strings.Right(Trim(RecArray(17)), 3) = "AND" Then
  '        WrkIsName = True
  '      End If
  '      If WrkIsName Then
  '        ._SNAME = ConvertString("Sname", Mid(WrkStr, Pos, 50), 35)
  '      Else
  '        ._ADD1 = ConvertString("Add1", WrkStr, 35)
  '      End If
  '      WrkStr = Trim(Replace(RecArray(20), "'", ""))
  '      If Trim(._ADD1) = "" Then
  '        ._ADD1 = ConvertString("Add2", WrkStr, 35)
  '        ._ADD2 = ""
  '      Else
  '        ._ADD2 = ConvertString("Add2", WrkStr, 35)
  '      End If
  '      ._CDATE = 0
  '      ._CITY = ConvertString("City", WrkCity, 25)
  '      If Trim(RecArray(10)) = "D" Then
  '        ._CCM = "Deferred"
  '      Else
  '        ._CCM = ""
  '      End If
  '      ._INTPD = 0
  '      ._LETT = Mid(RecArray(17), 1, 1)
  '      ._LISTNo = WrkListNo
  '      ._LNPD = CnvSng(RecArray(23))
  '      ._LOC = WrkLoc
  '      ._LOCNo = WrkLocNo
  '      WrkStr = Replace(RecArray(17), "'", "")
  '      WrkStr = Replace(WrkStr, ",", " ")
  '      ._NAME = ConvertString("Name", WrkStr, 35)
  '      ._RLST = 0
  '      ._STATE = WrkState
  '      If Trim(RecArray(14)) <> "" Then
  '        ._TXIDT = ConvertDate(RecArray(14))
  '      Else
  '        ._TXIDT = 0
  '      End If
  '      ._TYPE = "B"
  '      ._VOL = Trim(RecArray(4))
  '      ._IPAGE = Trim(RecArray(5))
  '      ._YEAR = 2000
  '      ._ZIP4 = 0
  '      ._ZIP5 = CnvSng(RecArray(22))
  '      ._TAX1 = CnvSng(RecArray(2))
  '      ._TAX2 = 0
  '      ._TAXT = ._TAX1 + ._TAX2
  '      ._PAYREC = CnvSng(RecArray(12))
  '      ._BOND = CnvSng(RecArray(13))
  '      ._BONDP = CnvSng(RecArray(13))
  '      ._BALD = ._TAXT - ._PAYREC
  '      .InsertOneRecordP()
  '      If .ErrMsg <> "" Then
  '        sw.WriteLine("UTAS-INV " & RecArray(0) & " " & .ErrMsg)
  '      End If
  '    End With

  '    WrkPct = (Counter / 10) Mod 100
  '    If SavePct <> WrkPct Then
  '      ProgBar1.Value = WrkPct
  '      LblMsg.Text = "Records processed: " & Counter
  '      SavePct = WrkPct
  '      Application.DoEvents()
  '    End If
  '    GoTo NextLine
  '  End Sub
End Module
