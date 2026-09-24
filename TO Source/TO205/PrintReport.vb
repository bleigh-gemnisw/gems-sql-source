Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXM35HQ As TXM35HQ.myData
  Dim myTXREAL As TXReal.myData
  Dim myTXREALC As TXREALC.myData
  Dim myTXM35H As TXM35H.myData
  Dim MyTXM35EX As TXM35EX.myData
  Dim myTXM35PM As TXM35PM.myData
  Dim MyTXLOCAL As TXLOCAL.myData
  Dim MyTXLOCIN As TXLOCIN.myData
  Dim MyTXLOCHB As TXLOCHB.myData
  Dim MyTXHOIN As TXHOIN.myData
  Dim myTXMRATE As TXMRATE.myData
  Dim myTXPROF As TXPROF.myData
  Dim MyTXHOME As TXHOME.myData
  Dim myTPAYMNT As TPAYMNT.MyData

  Dim ds As DataSet = New DataSet 'State Form
  Dim ds2 As DataSet = New DataSet 'Disallowed
  Dim ds3 As DataSet = New DataSet 'Undecided
  Dim ds4 As DataSet = New DataSet 'Allowed
  Dim ds5 As DataSet = New DataSet 'Local
  Dim ds6 As DataSet = New DataSet 'Local Form
  Dim dr As Data.DataRow

  Dim WrkGLYear As Integer
  Dim WrkMillYear As Integer
  Dim WrkTablePct As Decimal
  Dim WrkPGross As Integer
  Dim WrkAdjGross As Integer
  Dim WrkExam As Integer
  Dim WrkNet As Integer
  Dim WrkTax As Decimal
  Dim WrkFrzTax As Decimal
  Dim WrkCreditMax As Decimal
  Dim WrkLesser As Decimal
  Dim WrkCredit As Decimal
  Dim WrkLocal As Decimal
  Dim WrkOverwrite As Boolean
  Dim WrkForms As Boolean
  Dim WrkPrtAllow As Boolean
  Dim WrkElderlyCode As Boolean
  Dim WrkUpdate As Boolean

  Dim WrkLocPgm As String
  Dim WrkHeader1 As String
  Dim WrkHeader2 As String
  Dim WrkHeader3 As String
  Dim WrkLimitSingle As Decimal
  Dim WrkLimitMarried As Decimal
  Dim WrkStateMarried As Decimal
  Dim WrkStateSingle As Decimal
  Dim WrkLocalSingle As Decimal
  Dim WrkLocalMarried As Decimal
  'Adjusted Gross - Hard Coded excluded codes:
  Const cExcludeCode1 As Integer = 12
  Const cExcludeCode2 As Integer = 61
  Const cExcludeCode3 As Integer = 62
  Const cExcludeCode4 As Integer = 63
  Public Sub PrtReport()

    myTXM35HQ = New TXM35HQ.mydata(MyDBConnect)
    myTXM35H = New TXM35H.mydata(MyDBConnect)
    MyTXM35EX = New TXM35EX.mydata(MyDBConnect)
    myTXM35PM = New TXM35PM.mydata(MyDBConnect)
    MyTXLOCAL = New TXLOCAL.mydata(MyDBConnect)
    MyTXLOCIN = New TXLOCIN.mydata(MyDBConnect)
    MyTXLOCHB = New TXLOCHB.mydata(MyDBConnect)
    MyTXHOIN = New TXHOIN.mydata(MyDBConnect)
    myTXREAL = New TXReal.mydata(MyDBConnect)
    myTXREALC = New TXREALC.mydata(MyDBConnect)
    myTXMRATE = New TXMRATE.mydata(MyDBConnect)
    myTXPROF = New TXPROF.mydata(MyDBConnect)
    MyTXHOME = New TXHOME.mydata(MyDBConnect)
    myTPAYMNT = New TPAYMNT.mydata(MyDBConnect)

    With MyFrmTO205B
      WrkGLYear = MyUtils.CnvSng(.TxtEldLYear.Text)
      WrkMillYear = MyUtils.CnvSng(.TxtMillYear.Text)
      WrkOverwrite = .ChkOverwrite.Checked
      WrkForms = .ChkForms.Checked
      WrkPrtAllow = .ChkPrtAllow.Checked
      WrkElderlyCode = .ChkEldCode.Checked
      WrkUpdate = .ChkUpdate.Checked
    End With

    If WrkMillYear = 0 Then WrkMillYear = WrkGLYear

    If ds.Tables.Count = 0 Then
      BuildDS()
      BuildDS2()
      ds3 = ds2.Clone
      ds4 = ds2.Clone
      ds5 = ds2.Clone
      ds6 = ds.Clone
    Else
      ds.Clear()
      ds2.Clear()
      ds3.Clear()
      ds4.Clear()
      ds5.Clear()
      ds6.Clear()
    End If

    If myTXMRATE.RecordNotFound Then
      MsgBox("NO Mill rate for year " & WrkMillYear, MsgBoxStyle.Exclamation, "Mill Rate not found")
      Exit Sub
    End If
    myTXMRATE.GetOneRecordP(WrkMillYear, "R", 0)
    If myTXMRATE.RecordNotFound Then
      myTXMRATE.GetOneRecordP(WrkMillYear, "", 0)
    End If
    myTXPROF.GetOneRecordP("R", WrkMillYear, "", 0)
    If myTXPROF.RecordNotFound Then
      MsgBox("NO Tax Profile for Type 'R', Year " & WrkMillYear, MsgBoxStyle.Exclamation, "Tax Profile is missing")
      Exit Sub
    End If
    GetDetail()

    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.wrkds2 = ds2
    MyCrViewer.wrkds3 = ds3
    MyCrViewer.wrkds4 = ds4
    MyCrViewer.wrkds5 = ds5
    MyCrViewer.wrkds6 = ds6
    MyCrViewer.WrkUpdate = WrkUpdate
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("ALName", Type.GetType("System.String"))
      .Columns.Add("AFName", Type.GetType("System.String"))
      .Columns.Add("AInit", Type.GetType("System.String"))
      .Columns.Add("ADOB", Type.GetType("System.String"))
      .Columns.Add("ASSN", Type.GetType("System.String"))
      .Columns.Add("SLName", Type.GetType("System.String"))
      .Columns.Add("SFName", Type.GetType("System.String"))
      .Columns.Add("SInit", Type.GetType("System.String"))
      .Columns.Add("SDOB", Type.GetType("System.String"))
      .Columns.Add("SSSN", Type.GetType("System.String"))
      .Columns.Add("MADDR", Type.GetType("System.String"))
      .Columns.Add("MCITY", Type.GetType("System.String"))
      .Columns.Add("MSTATE", Type.GetType("System.String"))
      .Columns.Add("MZIP", Type.GetType("System.String"))
      .Columns.Add("PADDR", Type.GetType("System.String"))
      .Columns.Add("PCITY", Type.GetType("System.String"))
      .Columns.Add("PSTATE", Type.GetType("System.String"))
      .Columns.Add("PZIP", Type.GetType("System.String"))
      .Columns.Add("OWNER", Type.GetType("System.String"))
      .Columns.Add("MARRIED", Type.GetType("System.String"))
      .Columns.Add("UNMARRIED", Type.GetType("System.String"))
      .Columns.Add("SURVIVING", Type.GetType("System.String"))
      .Columns.Add("NURSINGHOME", Type.GetType("System.String"))
      .Columns.Add("DISABLED", Type.GetType("System.String"))
      .Columns.Add("TAXRETURNYES", Type.GetType("System.String"))
      .Columns.Add("TAXRETURNNO", Type.GetType("System.String"))
      .Columns.Add("INCOME", Type.GetType("System.Decimal"))
      .Columns.Add("INTEREST", Type.GetType("System.Decimal"))
      .Columns.Add("SSRR", Type.GetType("System.Decimal"))
      .Columns.Add("OTHER", Type.GetType("System.Decimal"))
      .Columns.Add("TOTAL", Type.GetType("System.Decimal"))
      .Columns.Add("SIGNEDMO", Type.GetType("System.String"))
      .Columns.Add("SIGNEDDAY", Type.GetType("System.String"))
      .Columns.Add("SIGNEDYEAR", Type.GetType("System.String"))
      .Columns.Add("PHONE", Type.GetType("System.String"))
      .Columns.Add("RELATE", Type.GetType("System.String"))
      .Columns.Add("RECEIVEDMO", Type.GetType("System.String"))
      .Columns.Add("RECEIVEDDAY", Type.GetType("System.String"))
      .Columns.Add("RECEIVEDYEAR", Type.GetType("System.String"))
      .Columns.Add("PROPCT", Type.GetType("System.Decimal"))
      .Columns.Add("PGROSS", Type.GetType("System.Int32"))
      .Columns.Add("GROSS", Type.GetType("System.Int32"))
      .Columns.Add("XBLIND", Type.GetType("System.Int32"))
      .Columns.Add("XDISAB", Type.GetType("System.Int32"))
      .Columns.Add("XVET", Type.GetType("System.Int32"))
      .Columns.Add("XLOCAL", Type.GetType("System.Int32"))
      .Columns.Add("XADDL", Type.GetType("System.Int32"))
      .Columns.Add("NET", Type.GetType("System.Int32"))
      .Columns.Add("MILLRATE", Type.GetType("System.Decimal"))
      .Columns.Add("TAX", Type.GetType("System.Decimal"))
      .Columns.Add("FRZTAX", Type.GetType("System.Decimal"))
      .Columns.Add("TABLEPCT", Type.GetType("System.Int16"))
      .Columns.Add("CREDITMAX", Type.GetType("System.Decimal"))
      .Columns.Add("CEILING", Type.GetType("System.Decimal"))
      .Columns.Add("LESSER", Type.GetType("System.Decimal"))
      .Columns.Add("MINGRANT", Type.GetType("System.Decimal"))
      .Columns.Add("CREDIT", Type.GetType("System.Decimal"))
      .Columns.Add("LOCTRF", Type.GetType("System.Decimal"))
      .Columns.Add("LOCBENEFIT", Type.GetType("System.Decimal"))
      .Columns.Add("LOCDEFERPLAN", Type.GetType("System.String"))
      .Columns.Add("LOCDEFERRAL", Type.GetType("System.Decimal"))
      .Columns.Add("ALLOWED", Type.GetType("System.String"))
      .Columns.Add("DISALLOWED", Type.GetType("System.String"))
      .Columns.Add("DISRSN", Type.GetType("System.String"))
      .Columns.Add("ASSRMO", Type.GetType("System.String"))
      .Columns.Add("ASSRDAY", Type.GetType("System.String"))
      .Columns.Add("ASSRYEAR", Type.GetType("System.String"))
      .Columns.Add("LOCPGM", Type.GetType("System.String"))
      .Columns.Add("LOCHEADER1", Type.GetType("System.String"))
      .Columns.Add("LOCHEADER2", Type.GetType("System.String"))
      .Columns.Add("LOCHEADER3", Type.GetType("System.String"))
      .Columns.Add("LIMITSING", Type.GetType("System.Decimal"))
      .Columns.Add("LIMITMARR", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub BuildDS2()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable2"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("ALName", Type.GetType("System.String"))
      .Columns.Add("AFName", Type.GetType("System.String"))
      .Columns.Add("AInit", Type.GetType("System.String"))
      .Columns.Add("TOTAL", Type.GetType("System.Decimal"))
      .Columns.Add("Filing", Type.GetType("System.String"))
      .Columns.Add("Reason", Type.GetType("System.String"))
      .Columns.Add("Credit", Type.GetType("System.Decimal"))
      .Columns.Add("LocBenefit", Type.GetType("System.Decimal"))
    End With
    ds2.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAnd As String
    Dim WrkTotal As Decimal
    Dim WrkTotMin As Decimal
    Dim WrkTotMax As Decimal
    Dim WrkTotCredit As Decimal
    Dim WrkMsg As String
    Dim SaveList As Integer
    Dim SaveEldPct As Integer
    Dim Counter As Integer

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    Counter = 0
    WrkSort = "LIST#"
    WrkQry = "YEAR = " & WrkGLYear
    'WrkQry = WrkQry & WrkAnd & "LIST# =163575"
    SaveList = 0
    SaveEldPct = 0
    WrkTotMin = 0
    WrkTotMax = 0
    WrkTotCredit = 0
    myTXM35HQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXM35HQ.ReadQry()
    If Not myTXM35HQ.IsEOF Then
      With myTXM35HQ
        Counter = Counter + 1
        If Trim(._ALLOW) <> String.Empty Then
          myTXREALC.GetOneRecordP(._LISTNO)
          CalcCredit()
          If WrkUpdate And Trim(._ALLOW) = "Y" Then
            UpdateTXM35H(._LISTNO, WrkGLYear, ._SEQ, ._MIN, ._MAX, WrkTax)
          End If
          If SaveList <> ._LISTNO And SaveList > 0 Then
            If WrkUpdate Then
              UpdateRE(SaveList, WrkGLYear, SaveEldPct, WrkTotMin, WrkTotMax, WrkTotCredit)
            End If
            SaveEldPct = 0
            WrkTotMin = 0
            WrkTotMax = 0
            WrkTotCredit = 0
          End If
          If WrkUpdate And Trim(._ALLOW) = "Y" Then
            WrkTotCredit = WrkTotCredit + WrkCredit
            WrkTotMin = WrkTotMin + ._MIN
            WrkTotMax = WrkTotMax + ._MAX
          End If
          SaveList = ._LISTNO
          If SaveEldPct < ._PCT Then
            SaveEldPct = ._PCT
          End If
        End If
        If WrkPrtAllow Then
          If Trim(._ALLOW) = "Y" Then
            Writeds("State")
          End If
        Else
          If Trim(._ALLOW) <> String.Empty Then
            Writeds("State")
          End If
        End If
        If Trim(._ALLOW) = "N" Then
          Writeds2()
        End If
        If Trim(._ALLOW) = String.Empty Then
          Writeds3()
        End If
        If Trim(._ALLOW) = "Y" Then
          myTXREAL.GetOneRecordP(._LISTNO)
          Writeds4(WrkCredit, "C", WrkGLYear)
        End If
        If MyLocEld <> "" Then
          WrkTotal = ._INCOME + ._INT + ._SSRR + ._OTHER
          WrkLocal = CalcLocEld(._LISTNO, ._SEQ, WrkTotal, WrkCredit)
          Writeds5()
          If WrkPrtAllow Then
            If Trim(._ALLOW) = "Y" Then
              Writeds(WrkLocPgm)
            End If
          Else
            If Trim(._ALLOW) <> String.Empty Then
              Writeds(WrkLocPgm)
            End If
          End If
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

    If WrkUpdate And WrkTotCredit > 0 Then
      UpdateRE(SaveList, WrkGLYear, SaveEldPct, WrkTotMin, WrkTotMax, WrkTotCredit)
    End If

    myFrmProgress.Close()
    myTXM35HQ.CloseFile()
    myTXREALC.CloseFile()

    If WrkUpdate Then
      WrkMsg = "Benefit Amounts recalculated"
      If WrkOverwrite Then
        WrkMsg = WrkMsg & " and Assessment values updated."
      End If
      MsgBox(WrkMsg, MsgBoxStyle.Information, "Update has finished")
    End If
    MyFrmTO205B.TxtEldLYear.Text = ""
  End Sub
  Private Sub CalcCredit()
    Dim WrkExcludeGross As Integer
    Dim WrkAssCode(6) As Integer
    Dim WrkGross(6) As Integer
    Dim J As Integer

    WrkExam = 0
    WrkPGross = 0
    WrkAdjGross = 0
    WrkNet = 0
    With myTXM35HQ
      If WrkOverwrite And ._ALLOW = "Y" Then
        If myTXREALC._CCNO > 0 Then
          WrkPGross = CalcPGross(myTXREALC._CCGRS, ._PROPCT)
          WrkExam = myTXREALC._CCEX
        Else
          WrkPGross = CalcPGross(myTXREALC._GROSS, ._PROPCT)
          WrkExam = CalcCat("B") + CalcCat("D") + CalcCat("V") + CalcCat("L") + CalcLocal(._LISTNO) + CalcCat("A")
        End If

        'Add Gross to Land or Building total
        With myTXREALC
          WrkAssCode(0) = Trim(._CODE1)
          WrkAssCode(1) = Trim(._CODE2)
          WrkAssCode(2) = Trim(._CODE3)
          WrkAssCode(3) = Trim(._CODE4)
          WrkAssCode(4) = Trim(._CODE5)
          WrkAssCode(5) = Trim(._CODE6)
          WrkAssCode(6) = Trim(._CODE7)
          If ._CCNO > 0 Then
            WrkGross(0) = ._CASS1
            WrkGross(1) = ._CASS2
            WrkGross(2) = ._CASS3
            WrkGross(3) = ._CASS4
            WrkGross(4) = ._CASS5
            WrkGross(5) = ._CASS6
            WrkGross(6) = ._CASS7
          Else
            WrkGross(0) = ._ASS1
            WrkGross(1) = ._ASS2
            WrkGross(2) = ._ASS3
            WrkGross(3) = ._ASS4
            WrkGross(4) = ._ASS5
            WrkGross(5) = ._ASS6
            WrkGross(6) = ._ASS7
          End If
          WrkExcludeGross = 0
          For J = 0 To 6
            If WrkAssCode(J) = cExcludeCode1 Or WrkAssCode(J) = cExcludeCode2 _
          Or WrkAssCode(J) = cExcludeCode3 Or WrkAssCode(J) = cExcludeCode4 Then
              WrkExcludeGross = WrkExcludeGross + WrkGross(J)
            End If
          Next J
        End With
        WrkAdjGross = CalcGross(WrkPGross - WrkExcludeGross, ._PROPCT)
        WrkNet = WrkAdjGross - WrkExam
        WrkTax = WrkNet * myTXMRATE._MRRATE
      Else
        WrkPGross = ._PGROSS
        WrkAdjGross = ._GROSS
        WrkTax = ._NET * myTXMRATE._MRRATE
      End If
      If ._FRZTAX = 0 Then
        With myTPAYMNT
          .In_Year = WrkGLYear
          .In_Type = "R"
          .In_Dst = 0
          .In_Phs = ""
          .In_TaxT = WrkTax
          .CalcPaySplit()
          WrkTax = .Out_TaxT
        End With
      Else
        WrkTax = 0
      End If
      WrkFrzTax = ._FRZTAX

      If WrkFrzTax > 0 Then
        WrkCreditMax = MyUtils.Round(WrkFrzTax * (._PCT / 100), 2)
      Else
        WrkCreditMax = MyUtils.Round(WrkTax * (._PCT / 100), 2)
      End If
      With myTPAYMNT
        .In_Year = WrkGLYear
        .In_Type = "R"
        .In_Dst = 0
        .In_Phs = ""
        .In_TaxT = WrkCreditMax
        .CalcPaySplit()
        WrkCreditMax = .Out_TaxT
      End With
      If WrkCreditMax > ._MAX Then
        WrkLesser = ._MAX
      Else
        WrkLesser = WrkCreditMax
      End If
      If WrkLesser < ._MIN Then
        WrkCredit = ._MIN
      Else
        WrkCredit = WrkLesser
      End If
    End With

  End Sub
  Private Sub GetCredit()

    With myTXM35HQ
      If WrkFrzTax > 0 Then
        WrkCreditMax = MyUtils.Round(._FRZTAX * (._PCT / 100), 2)
      Else
        WrkCreditMax = MyUtils.Round(._TAX * (._PCT / 100), 2)
      End If
      With myTPAYMNT
        .In_Year = WrkGLYear
        .In_Type = "R"
        .In_Dst = 0
        .In_Phs = ""
        .In_TaxT = WrkCreditMax
        .CalcPaySplit()
        WrkCreditMax = .Out_TaxT
      End With
      If WrkCreditMax > ._MAX Then
        WrkLesser = ._MAX
      Else
        WrkLesser = WrkCreditMax
      End If
      If WrkLesser < ._MIN Then
        WrkCredit = ._MIN
      Else
        WrkCredit = WrkLesser
      End If
    End With

    With myTPAYMNT
      .In_Year = WrkGLYear
      .In_Type = "R"
      .In_Dst = 0
      .In_Phs = ""
      .In_TaxT = WrkCredit
      .CalcPaySplit()
      WrkCredit = .Out_TaxT
    End With

  End Sub
  Private Sub UpdateTXM35H(ByVal List As Integer, ByVal Year As Integer, ByVal Seq As Integer,
 ByVal WrkMin As Decimal, ByVal WrkMax As Decimal, ByVal WrkTax As Decimal)

    With myTXM35H
      .GetOneRecordP(List, Year, Seq)
      If WrkOverwrite And ._ALLOW = "Y" Then
        ._PGROSS = WrkPGross
        ._GROSS = WrkAdjGross
        ._NET = WrkNet
      End If
      ._MIN = WrkMin
      ._MAX = WrkMax
      ._TAX = WrkTax
      .UpdateOneRecordP()
    End With

  End Sub
  Private Sub UpdateRE(ByVal List As Integer, ByVal Year As Integer,
 ByVal WrkPct As Decimal, ByVal WrkMin As Decimal, ByVal WrkMax As Decimal, ByVal WrkCredit As Decimal)

    myTXREAL.GetOneRecordP(List)
    If Not WrkElderlyCode And Trim(myTXREAL._FCCOD) = String.Empty Then Exit Sub

    With myTXREAL
      If Not .RecordNotFound Then
        If WrkCredit > 0 Then
          If Trim(._FCCOD) = String.Empty Then
            ._FCCOD = "C"
            ._FCYR = MyUtils.CnvSng(MyFrmTO205B.TxtEldLYear.Text)
          End If
          ._FTAX = WrkCredit
          ._CPERC = WrkPct / 100
          ._CMAX = WrkMax
          ._CMIN = WrkMin
          .UpdateOneRecordP()
        Else
          ._FCCOD = ""
          ._FCYR = 0
          ._FTAX = 0
          ._CPERC = 0
          ._CMAX = 0
          ._CMIN = 0
          .UpdateOneRecordP()
        End If
      End If
    End With

    myTXREALC.GetOneRecordP(List)
    With myTXREALC
      If Not .RecordNotFound Then
        If WrkCredit > 0 Then
          If Trim(._FCCOD) = String.Empty Then
            ._FCCOD = "C"
            ._FCYR = MyUtils.CnvSng(MyFrmTO205B.TxtEldLYear.Text)
          End If
          ._FTAX = WrkCredit
          ._CPERC = WrkPct / 100
          ._CMAX = WrkMax
          ._CMIN = WrkMin
          .UpdateOneRecordP()
        Else
          ._FCCOD = ""
          ._FCYR = 0
          ._FTAX = 0
          ._CPERC = 0
          ._CMAX = 0
          ._CMIN = 0
          .UpdateOneRecordP()
        End If
      End If
    End With
  End Sub
  Private Sub Writeds(ByVal WrkPgm As String)
    Dim DsLocal As DataSet = New DataSet
    Dim sb As New StringBuilder
    Dim WrkDeferral As Decimal
    Dim WrkDate As Date
    Dim WrkStr As String

    With myTXM35HQ
      If WrkPgm = "State" Then
        dr = ds.Tables(0).NewRow
      Else
        dr = ds6.Tables(0).NewRow
      End If
      dr.Item("listno") = ._LISTNO
      dr.Item("year") = ._YEAR
      dr.Item("alname") = ._ALNAME
      dr.Item("afname") = ._AFNAME
      dr.Item("ainit") = ._AINIT
      sb = New StringBuilder
      WrkDate = MyUtils.GetDBDate(._ADOB)
      sb.Append(Format(WrkDate.Month, "00"))
      sb.Append("  /  ")
      sb.Append(Format(WrkDate.Day, "00"))
      sb.Append("  /  ")
      sb.Append(WrkDate.Year)
      dr.Item("adob") = sb.ToString
      sb = Nothing
      sb = New StringBuilder
      WrkStr = MyUtils.JustifyRight(Trim(._ASSN), 9)
      sb.Append(Format(MyUtils.CnvSng(Mid(WrkStr, 1, 3)), "000"))
      sb.Append("  -  ")
      sb.Append(Format(MyUtils.CnvSng(Mid(WrkStr, 4, 2)), "00"))
      sb.Append("  -  ")
      sb.Append(Format(MyUtils.CnvSng(Mid(WrkStr, 6, 4)), "0000"))
      dr.Item("assn") = sb.ToString
      sb = Nothing
      dr.Item("slname") = ._SLNAME
      dr.Item("sfname") = ._SFNAME
      dr.Item("sinit") = ._SINIT
      If Trim(._SLNAME) <> "" Then
        WrkDate = MyUtils.GetDBDate(._SDOB)
        sb = New StringBuilder
        sb.Append(Format(WrkDate.Month, "00"))
        sb.Append("  /  ")
        sb.Append(Format(WrkDate.Day, "00"))
        sb.Append("  /  ")
        sb.Append(WrkDate.Year)
        dr.Item("sdob") = sb.ToString
        sb = Nothing
        sb = New StringBuilder
        WrkStr = MyUtils.JustifyRight(Trim(._SSSN), 9)
        sb.Append(Format(MyUtils.CnvSng(Mid(WrkStr, 1, 3)), "000"))
        sb.Append("  -  ")
        sb.Append(Format(MyUtils.CnvSng(Mid(WrkStr, 4, 2)), "00"))
        sb.Append("  -  ")
        sb.Append(Format(MyUtils.CnvSng(Mid(WrkStr, 6, 4)), "0000"))
        dr.Item("sssn") = sb.ToString
        sb = Nothing
      End If
      dr.Item("maddr") = ._MADDR
      dr.Item("mcity") = ._MCITY
      dr.Item("mstate") = ._MSTATE
      dr.Item("mzip") = Format(._MZIP, "00000")
      dr.Item("paddr") = ._PADDR
      dr.Item("pcity") = ._PCITY
      dr.Item("pstate") = ._PSTATE
      If ._PZIP > 0 Then
        dr.Item("pzip") = Format(._PZIP, "00000")
      End If
      dr.Item("owner") = ._OWNER
      Select Case Trim(._FILING)
        Case "M"
          dr.Item("married") = "X"
        Case "U"
          dr.Item("unmarried") = "X"
        Case "S"
          dr.Item("surviving") = "X"
      End Select
      If Trim(._NRSHOM) = "Y" Then
        dr.Item("nursinghome") = "X"
      End If
      If Trim(._DISAB) = "Y" Then
        dr.Item("disabled") = "X"
      End If
      If Trim(._TAXRTN) = "Y" Then
        dr.Item("taxreturnyes") = "X"
      Else
        dr.Item("taxreturnno") = "X"
      End If
      dr.Item("income") = ._INCOME
      dr.Item("interest") = ._INT
      dr.Item("ssrr") = ._SSRR
      dr.Item("other") = ._OTHER
      dr.Item("total") = ._INCOME + ._INT + ._SSRR + ._OTHER
      WrkDate = MyUtils.GetDBDate(._DTSIGN)
      dr.Item("signedmo") = Format(WrkDate.Month, "00")
      dr.Item("signedday") = Format(WrkDate.Day, "00")
      dr.Item("signedyear") = WrkDate.Year
      If ._PHONE > 0 Then
        dr.Item("phone") = Format(._PHONE, "(###) ###-0000")
      End If
      dr.Item("relate") = ._RELATE
      If ._DTRECV > 0 Then
        WrkDate = MyUtils.GetDBDate(._DTRECV)
        dr.Item("receivedmo") = Format(WrkDate.Month, "00")
        dr.Item("receivedday") = Format(WrkDate.Day, "00")
        dr.Item("receivedyear") = WrkDate.Year
      End If
      dr.Item("propct") = ._PROPCT
      If WrkOverwrite And ._ALLOW = "Y" Then
        dr.Item("pgross") = WrkPGross
        dr.Item("gross") = WrkAdjGross
      Else
        dr.Item("pgross") = ._PGROSS
        dr.Item("gross") = ._GROSS
      End If
      dr.Item("xblind") = ._XBLIND
      dr.Item("xdisab") = ._XDISAB
      dr.Item("xvet") = ._XVET
      dr.Item("xlocal") = ._XLOCAL
      dr.Item("xaddl") = ._XADDL
      If WrkOverwrite And ._ALLOW = "Y" Then
        dr.Item("net") = WrkNet
      Else
        dr.Item("net") = ._NET
      End If
      dr.Item("millrate") = myTXMRATE._MRRATE * 1000
      If WrkFrzTax > 0 Then
        dr.Item("tax") = 0
        dr.Item("frztax") = WrkFrzTax
      Else
        dr.Item("tax") = WrkTax
        dr.Item("frztax") = 0
      End If
      dr.Item("tablepct") = ._PCT
      If WrkForms Then
        GetCredit()
      End If
      dr.Item("creditmax") = WrkCreditMax
      dr.Item("ceiling") = ._MAX
      dr.Item("lesser") = WrkLesser
      dr.Item("mingrant") = ._MIN
      dr.Item("credit") = WrkCredit
      Select Case WrkPgm
        Case "State"
          If ._ALLOW = "Y" Then
            dr.Item("allowed") = "X"
          Else
            dr.Item("disallowed") = "X"
          End If
          dr.Item("disrsn") = ._DISRSN
          If ._DTASSR > 0 Then
            WrkDate = MyUtils.GetDBDate(._DTASSR)
            dr.Item("assrmo") = Format(WrkDate.Month, "00")
            dr.Item("assrday") = Format(WrkDate.Day, "00")
            dr.Item("assryear") = WrkDate.Year
          End If
        Case Else
          With myTXM35PM
            DsLocal = .GetbyList(myTXM35HQ._LISTNO, myTXM35HQ._YEAR, myTXM35HQ._SEQ)
            If DsLocal.Tables(0).Rows.Count > 0 Then
              .GetOneRecordP(myTXM35HQ._LISTNO, myTXM35HQ._YEAR, myTXM35HQ._SEQ, DsLocal.Tables(0).Rows(0).Item("locpm"))
              dr.Item("locpgm") = DsLocal.Tables(0).Rows(0).Item("locpm")
              dr.Item("locbenefit") = WrkLocal
              dr.Item("loctrf") = DsLocal.Tables(0).Rows(0).Item("trf")
              If Trim(DsLocal.Tables(0).Rows(0).Item("defer")) <> "" Then
                WrkDeferral = WrkTax - WrkCredit - WrkLocal
                WrkDeferral = WrkDeferral - Math.Round(WrkTax * (1 - DsLocal.Tables(0).Rows(0).Item("defpct")), 2)
              Else
                WrkDeferral = 0
              End If
              dr.Item("locdeferral") = WrkDeferral
              If ._ALLOW = "Y" Then
                dr.Item("allowed") = "X"
              Else
                dr.Item("disallowed") = "X"
              End If
              dr.Item("disrsn") = ._DISRSN
              If ._DTASSR > 0 Then
                WrkDate = MyUtils.GetDBDate(._DTASSR)
                dr.Item("assrmo") = Format(WrkDate.Month, "00")
                dr.Item("assrday") = Format(WrkDate.Day, "00")
                dr.Item("assryear") = WrkDate.Year
              End If
            End If
            GetHeadings(WrkPgm)
            dr.Item("locheader1") = WrkHeader1
            dr.Item("locheader2") = WrkHeader2
            dr.Item("locheader3") = WrkHeader3
            dr.Item("limitsing") = WrkLimitSingle
            dr.Item("limitmarr") = WrkLimitMarried
          End With
      End Select
      If WrkPgm = "State" Then
        ds.Tables(0).Rows.Add(dr)
      Else
        If DsLocal.Tables(0).Rows.Count > 0 Then
          If WrkPrtAllow Then
            If myTXM35PM._ALLOW = "Y" Then
              ds6.Tables(0).Rows.Add(dr)
            End If
          Else
            ds6.Tables(0).Rows.Add(dr)
          End If
        End If
      End If
    End With

  End Sub
  Private Sub Writeds2()
    With myTXM35HQ
      dr = ds2.Tables(0).NewRow
      dr.Item("listno") = ._LISTNO
      dr.Item("year") = ._YEAR
      dr.Item("alname") = ._ALNAME
      dr.Item("afname") = ._AFNAME
      dr.Item("ainit") = ._AINIT
      dr.Item("total") = ._INCOME + ._INT + ._SSRR + ._OTHER
      Select Case Trim(._FILING)
        Case "M"
          dr.Item("filing") = "MARR"
        Case "U"
          dr.Item("filing") = "UMAR"
        Case "S"
          dr.Item("filing") = "SURV"
      End Select
      dr.Item("reason") = ._DISRSN
      ds2.Tables(0).Rows.Add(dr)
    End With
  End Sub
  Private Sub Writeds3()
    With myTXM35HQ
      dr = ds3.Tables(0).NewRow
      dr.Item("listno") = ._LISTNO
      dr.Item("year") = ._YEAR
      dr.Item("alname") = ._ALNAME
      dr.Item("afname") = ._AFNAME
      dr.Item("ainit") = ._AINIT
      dr.Item("total") = ._INCOME + ._INT + ._SSRR + ._OTHER
      Select Case Trim(._FILING)
        Case "M"
          dr.Item("filing") = "MARR"
        Case "U"
          dr.Item("filing") = "UMAR"
        Case "S"
          dr.Item("filing") = "SURV"
      End Select
      dr.Item("reason") = String.Empty
      ds3.Tables(0).Rows.Add(dr)
    End With

  End Sub
  Private Sub Writeds4(ByVal WrkCredit As Decimal, ByVal WrkFCCod As String, ByVal WrkFrzYear As Integer)
    With myTXM35HQ
      dr = ds4.Tables(0).NewRow
      dr.Item("listno") = ._LISTNO
      dr.Item("year") = ._YEAR
      dr.Item("alname") = ._ALNAME
      dr.Item("afname") = ._AFNAME
      dr.Item("ainit") = ._AINIT
      dr.Item("total") = 0
      If WrkFCCod = "C" Then
        If WrkFrzYear = ._YEAR Then
          dr.Item("reason") = ""
          dr.Item("credit") = WrkCredit
        Else
          dr.Item("reason") = WrkFrzYear & " Yr " & WrkCredit
          dr.Item("credit") = 0
        End If
      Else
        dr.Item("reason") = "Non Eld " & WrkCredit
        dr.Item("credit") = 0
      End If
      ds4.Tables(0).Rows.Add(dr)
    End With

  End Sub
  Private Sub Writeds5()
    With myTXM35HQ
      dr = ds5.Tables(0).NewRow
      dr.Item("listno") = ._LISTNO
      dr.Item("year") = ._YEAR
      dr.Item("alname") = ._ALNAME
      dr.Item("afname") = ._AFNAME
      dr.Item("ainit") = ._AINIT
      dr.Item("total") = 0
      dr.Item("credit") = WrkCredit
      dr.Item("locbenefit") = WrkLocal
      dr.Item("reason") = String.Empty
      ds5.Tables(0).Rows.Add(dr)
    End With

  End Sub
  Private Function CalcCat(ByVal Cat As String) As Integer
    Dim Total As Integer
    Total = 0

    If Trim(myTXREALC._EXCD1) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, myTXREALC._EXCD1)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + myTXREALC._EXAM1
      End If
    End If

    If Trim(myTXREALC._EXCD2) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, myTXREALC._EXCD2)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + myTXREALC._EXAM2
      End If
    End If

    If Trim(myTXREALC._EXCD3) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, myTXREALC._EXCD3)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + myTXREALC._EXAM3
      End If
    End If

    If Trim(myTXREALC._EXCD4) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, myTXREALC._EXCD4)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + myTXREALC._EXAM4
      End If
    End If

    If Trim(myTXREALC._EXCD5) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, myTXREALC._EXCD5)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + myTXREALC._EXAM5
      End If
    End If

    If Trim(myTXREALC._EXCD6) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, myTXREALC._EXCD6)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + myTXREALC._EXAM6
      End If
    End If

    If Trim(myTXREALC._EXCD7) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, myTXREALC._EXCD7)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + myTXREALC._EXAM7
      End If
    End If

    Return Total
  End Function
  Private Function CalcLocEld(ByVal WrkListno As Integer, ByVal WrkSeq As Integer, ByVal WrkTotal As Decimal, ByVal WrkCredit As Decimal) As Decimal
    Dim DsLocal As DataSet = New DataSet
    Dim WrkLocalLimit As Decimal
    Dim WrkPropPct As Decimal
    Dim WrkAmount As Decimal
    Dim I As Integer

    WrkAmount = 0
    With MyTXHOIN
      .GetOneRecordP(WrkGLYear, 5)
      WrkStateMarried = ._LIMIT
      .GetOneRecordP(WrkGLYear, 4)
      WrkStateSingle = ._LIMIT
    End With

    If MyLocEld = "032" Then
      With myTXM35PM
        DsLocal = .GetbyList(WrkListno, WrkGLYear, WrkSeq)
        For I = 0 To DsLocal.Tables(0).Rows.Count - 1
          WrkLocPgm = DsLocal.Tables(0).Rows(I).Item("locpm")
          If DsLocal.Tables(0).Rows(I).Item("locpm") = "212" Then
            WrkAmount = MyUtils.CnvSng(WrkCredit)
          Else
            WrkAmount = Math.Round(WrkCredit * 0.5, 0)
          End If
        Next
        Return WrkAmount
      End With
    End If

    If MyLocEld = "035" Then
      With myTXM35PM
        DsLocal = .GetbyList(WrkListno, WrkGLYear, WrkSeq)
        For I = 0 To DsLocal.Tables(0).Rows.Count - 1
          WrkLocPgm = DsLocal.Tables(0).Rows(I).Item("locpm")
          If DsLocal.Tables(0).Rows(I).Item("locpm") = "LOC" Then
            WrkAmount = DsLocal.Tables(0).Rows(I).Item("benamt")
          End If
        Next
        Return WrkAmount
      End With
    End If

    If MyLocEld = "045" Then
      With myTXM35PM
        .GetOneRecordP(WrkListno, WrkGLYear, WrkSeq, "LOC")
        If Not .RecordNotFound Then
          WrkLocPgm = ._LOCPM
          'Local
          If Trim(._ALLOW) = "Y" Then
            WrkAmount = CalcLocHB(WrkTotal)
            WrkPropPct = MyUtils.CnvSng(myTXM35HQ._PROPCT) / 100
            WrkAmount = Math.Round(WrkAmount * WrkPropPct, 2)
            Return WrkAmount
          End If
        End If
      End With
    End If

    If MyLocEld = "084" Then
      With myTXM35PM
        DsLocal = .GetbyList(WrkListno, WrkGLYear, WrkSeq)
      End With
      If DsLocal.Tables(0).Rows.Count > 0 Then
        WrkLocPgm = DsLocal.Tables(0).Rows(0).Item("locpm")
        With MyTXLOCIN
          .GetOneRecordP(WrkGLYear, DsLocal.Tables(0).Rows(0).Item("locpm"))
          WrkLocalMarried = ._MRYINC + WrkStateMarried
          WrkLocalSingle = ._SNGINC + WrkStateSingle
          If myTXM35HQ._FILING = "M" Then
            WrkLocalLimit = ._MRYINC + WrkStateMarried
          Else
            WrkLocalLimit = ._SNGINC + WrkStateSingle
          End If
          WrkPropPct = MyUtils.CnvSng(myTXM35HQ._PROPCT) / 100
          If WrkTotal <= WrkLocalLimit Then
            WrkAmount = Math.Round(._AMOUNT * WrkPropPct, 0)
          End If
        End With
      End If
      Return WrkAmount
    End If
  End Function
  Private Function CalcLocHB(ByVal WrkTotal As Decimal) As Decimal
    Dim WrkBenefit As Decimal
    Dim I As Integer
    WrkBenefit = 0
    For I = 1 To 5
      With MyTXLOCHB
        .GetOneRecordP(WrkGLYear, I)
        If .RecordNotFound Then Return 0
        If ._LIMIT >= WrkTotal Then
          WrkBenefit = ._BENAMT
          Return WrkBenefit
        End If
      End With
    Next
    Return 0
  End Function
  Private Function CalcLocal(ByVal WrkListNo As Integer) As Integer
    Dim ds As DataSet = New DataSet
    Dim Total As Integer
    Dim I As Integer

    Total = 0
    ds = MyTXM35EX.GetAllCat("L", String.Empty)
    For I = 0 To ds.Tables(0).Rows.Count - 1
      MyTXLOCAL.GetOneRecordP(WrkListNo, WrkGLYear, "R", ds.Tables(0).Rows(I).Item("excd"))
      If Not MyTXLOCAL.RecordNotFound Then
        Total = Total + MyTXLOCAL._BENAMT
      End If
    Next

    Return Total
  End Function
  Private Function CalcCatCC(ByVal Cat As String) As Integer
    Dim Total As Integer
    Total = 0

    If Trim(myTXREALC._CCCD1) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, myTXREALC._CCCD1)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + myTXREALC._CEXA1
      End If
    End If

    If Trim(myTXREALC._CCCD2) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, myTXREALC._CCCD2)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + myTXREALC._CEXA2
      End If
    End If

    If Trim(myTXREALC._CCCD3) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, myTXREALC._CCCD3)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + myTXREALC._CEXA3
      End If
    End If

    If Trim(myTXREALC._CCCD4) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, myTXREALC._CCCD4)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + myTXREALC._CEXA4
      End If
    End If

    If Trim(myTXREALC._CCCD5) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, myTXREALC._CCCD5)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + myTXREALC._CEXA5
      End If
    End If

    If Trim(myTXREALC._CCCD6) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, myTXREALC._CCCD6)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + myTXREALC._CEXA6
      End If
    End If

    If Trim(myTXREALC._CCCD7) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, myTXREALC._CCCD7)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + myTXREALC._CEXA7
      End If
    End If

    Return Total
  End Function
  Private Function CalcPGross(ByVal WrkGross As Integer, ByVal WrkPropct As Decimal) As Integer

    Dim WrkPGross As Decimal
    'If WrkPropct = 0 Then WrkPropct = 100
    'WrkPGross = Math.Round(WrkGross * (1 / (WrkPropct / 100)), 0)
    WrkPGross = WrkGross
    Return WrkPGross
  End Function
  Private Function CalcGross(ByVal WrkPGross As Integer, ByVal WrkPropct As Decimal) As Integer

    Dim WrkGross As Decimal
    If WrkPropct = 0 Then WrkPropct = 100
    WrkGross = Math.Round(WrkPGross * (WrkPropct / 100), 0)
    Return WrkGross
  End Function
  Private Sub GetHeadings(ByVal WrkPgm As String)
    WrkLimitSingle = 0
    WrkLimitMarried = 0
    Select Case Trim(WrkPgm)
      Case "212"
        WrkHeader1 = "APPLICATION FOR TAX CREDITS"
        WrkHeader2 = "ORDINANCE 212"
        WrkHeader3 = "TAX DEFERRAL PROGRAM FOR ELDERLY AND/OR TOTALY DISABLED RESIDENTS"
      Case "250"
        WrkHeader1 = "APPLICATION FOR TAX CREDITS"
        WrkHeader2 = "ORDINANCE 250"
        WrkHeader3 = "TAX DEFERRAL PROGRAM FOR ELDERLY AND/OR TOTALY DISABLED RESIDENTS"
      Case "LOC"
        WrkHeader1 = "APPLICATION FOR LOCAL OPTION HOMEOWNER TAX CREDIT"
        WrkHeader2 = "FILE BIENNIALLY"
        WrkHeader3 = "FILING PERIOD FEB 1 - MAY 15"
      Case "LL", "LH"
        WrkHeader1 = "LOCAL TAX CREDIT BENEFIT"
        WrkHeader2 = "PROVIDED BY LOCAL ORDINANCE"
        WrkHeader3 = "Milford Ordinance 20.5-6 as authorized by Section 12-129n CGS"
        WrkLimitSingle = WrkLocalSingle
        WrkLimitMarried = WrkLocalMarried
      Case "EBC"
        WrkHeader1 = "APPLICATION FOR TOTALLY DISABLED EXEMPTION"
        WrkHeader2 = "Public Act 85-294"
        WrkHeader3 = ""
        WrkLimitSingle = WrkStateSingle
        WrkLimitMarried = WrkStateMarried
      Case "FBC"
        WrkHeader1 = "APPLICATION FOR BLIND EXEMPTION"
        WrkHeader2 = "Public Act 85-294"
        WrkHeader3 = ""
        WrkLimitSingle = WrkStateSingle
        WrkLimitMarried = WrkStateMarried
      Case Else
        WrkHeader1 = ""
        WrkHeader2 = ""
        WrkHeader3 = ""
    End Select
  End Sub
End Module






