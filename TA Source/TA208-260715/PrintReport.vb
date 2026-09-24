Module PrintReport
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXREALCQ As TXREALCQ.MyData
  Dim DsTXREAL As DataSet = New DataSet
  Dim myTPAYMNT As TPAYMNT.MyData
  Dim myTXM35H As TXM35H.MyData
  Dim myTXLOCCD As TXLOCCD.MyData
  Dim myTXLOCAL As TXLOCAL.MyData
  Dim ds As DataSet = New DataSet
  Dim dsState As DataSet = New DataSet 'State Only
  Dim dsLocal As DataSet = New DataSet 'Local Only
  Dim dsSplit As DataSet = New DataSet 'Splits
  Dim dsElderly As DataSet = New DataSet 'Elderly (Ratebook) totals
  Dim dsErrors As DataSet = New DataSet
  Dim dr As Data.DataRow

  'Adjusted Gross Ommited Codes 
  Dim cExcludeCode1 As Integer
  Dim cExcludeCode2 As Integer
  Dim cExcludeCode3 As Integer
  Dim cExcludeCode4 As Integer

  'Mill Rate
  Public MrateMillrt As Decimal

  Dim WrkType As String
  Dim WrkGLYear As Integer
  Dim WrkDist As Integer
  Dim WrkPrev As Boolean

  Dim WrkTax As Decimal
  Dim WrkFrzTax As Decimal
  Dim WrkCreditMax As Decimal
  Dim WrkLesser As Decimal
  Dim WrkCredit As Decimal
  Dim WrkLocalCd1 As String
  Dim WrkLocalCd2 As String
  Dim WrkLocalCd3 As String
  Dim WrkLocalCd4 As String
  Dim WrkLocalCd5 As String
  Public Sub PrtReport()

    myTXREALCQ = New TXREALCQ.MyData(myDBConnect)
    myTPAYMNT = New TPAYMNT.MyData(myDBConnect)
    myTXM35H = New TXM35H.MyData(myDBConnect)
    myTXLOCCD = New TXLOCCD.MyData(myDBConnect)
    myTXLOCAL = New TXLOCAL.MyData(myDBConnect)

    With MyFrmTA208B
      WrkGLYear = .TxtGLYear.Text
      WrkPrev = .RbPrev.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
      dsState = ds.Clone
      dsLocal = ds.Clone
      dsSplit = ds.Clone
      dsElderly = ds.Clone
      dsErrors = ds.Clone
    Else
      ds.Clear()
      dsState.Clear()
      dsLocal.Clear()
      dsSplit.Clear()
      dsElderly.Clear()
      dsErrors.Clear()
    End If

    GetMillRate(WrkGLYear, WrkDist)
    cExcludeCode1 = GetTXCDAGCode(1)
    cExcludeCode2 = GetTXCDAGCode(2)
    cExcludeCode3 = GetTXCDAGCode(3)
    cExcludeCode4 = GetTXCDAGCode(4)
    If cExcludeCode1 = 0 Then cExcludeCode1 = 12
    If cExcludeCode2 = 0 Then cExcludeCode2 = 61
    If cExcludeCode3 = 0 Then cExcludeCode3 = 62
    If cExcludeCode4 = 0 Then cExcludeCode4 = 63
    GetDetail()

    ds.Merge(dsState)
    ds.Merge(dsLocal)
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .WrkdsState = dsState
      .WrkdsLocal = dsLocal
      .WrkdsSplit = dsSplit
      .WrkdsElderly = dsElderly
      .WrkdsErrors = dsErrors
      .WrkLocalCd1 = WrkLocalCd1
      .WrkLocalCd2 = WrkLocalCd2
      .WrkLocalCd3 = WrkLocalCd3
      .WrkLocalCd4 = WrkLocalCd4
      .WrkLocalCd5 = WrkLocalCd5
      .Show()
    End With
  End Sub
  Friend Sub BuildDS()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("listno", Type.GetType("System.Int64"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("proploc", Type.GetType("System.String"))
      .Columns.Add("year", Type.GetType("System.Int64"))
      .Columns.Add("code", Type.GetType("System.String"))
      .Columns.Add("netass", Type.GetType("System.Int64"))
      .Columns.Add("tax", Type.GetType("System.Decimal"))
      .Columns.Add("statecredit", Type.GetType("System.Decimal"))
      .Columns.Add("localcredit", Type.GetType("System.Decimal"))
      .Columns.Add("adjtax", Type.GetType("System.Decimal"))
      .Columns.Add("cperc", Type.GetType("System.Decimal"))
      .Columns.Add("cmax", Type.GetType("System.Int64"))
      .Columns.Add("cmin", Type.GetType("System.Int64"))
      .Columns.Add("acctadjtax", Type.GetType("System.Decimal"))
      .Columns.Add("local1", Type.GetType("System.Decimal"))
      .Columns.Add("local2", Type.GetType("System.Decimal"))
      .Columns.Add("local3", Type.GetType("System.Decimal"))
      .Columns.Add("local4", Type.GetType("System.Decimal"))
      .Columns.Add("local5", Type.GetType("System.Decimal"))
      .Columns.Add("line1", Type.GetType("System.String"))   ' added 8/28/23
      .Columns.Add("line2", Type.GetType("System.String"))   ' added 8/28/23
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim dstemp As DataSet = New DataSet
    Dim WrkAssCode(6) As Integer
    Dim WrkGross(6) As Integer
    Dim WrkAdjGross As Integer
    Dim WrkExcludeGross As Integer
    Dim WrkExam As Integer
    Dim WrkNet As Integer
    Dim WrkBenefit As Decimal
    Dim WrkAdjTax As Decimal
    Dim WrkLocal As Decimal
    Dim WrkLocal1 As Decimal
    Dim WrkLocal2 As Decimal
    Dim WrkLocal3 As Decimal
    Dim WrkLocal4 As Decimal
    Dim WrkLocal5 As Decimal
    Dim WrkYear1 As Integer
    Dim WrkSort As String
    Dim WrkQry As String
    Dim Good As Boolean
    Dim I As Integer
    Dim J As Integer
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim WrkSname As String
    If myDBConnect.ServerAS400 Then
      WrkOr = " *or "
      WrkAnd = " *and "
    Else
      WrkOr = " or "
      WrkAnd = " and "
    End If

    WrkSort = "NAME, LIST#"
    WrkQry = "FCCOD='C'" & WrkOr & "TWNBN <> 0"

    WrkYear1 = WrkGLYear - 1

    WrkLocalCd1 = ""
    WrkLocalCd2 = ""
    WrkLocalCd3 = ""
    WrkLocalCd4 = ""
    WrkLocalCd5 = ""
    dstemp = myTXLOCCD.GetAllData
    If dstemp.Tables(0).Rows.Count > 0 Then
      WrkLocalCd1 = dstemp.Tables(0).Rows(0).Item("bncode")
    End If
    If dstemp.Tables(0).Rows.Count > 1 Then
      WrkLocalCd2 = dstemp.Tables(0).Rows(1).Item("bncode")
    End If
    If dstemp.Tables(0).Rows.Count > 2 Then
      WrkLocalCd3 = dstemp.Tables(0).Rows(2).Item("bncode")
    End If
    If dstemp.Tables(0).Rows.Count > 3 Then
      WrkLocalCd4 = dstemp.Tables(0).Rows(3).Item("bncode")
    End If
    If dstemp.Tables(0).Rows.Count > 4 Then
      WrkLocalCd5 = dstemp.Tables(0).Rows(4).Item("bncode")
    End If

    DsTXREAL = myTXREALCQ.GetQry(WrkSort, WrkQry, 0)
    If DsTXREAL.Tables(0).Rows.Count = 0 Then
      myTXREALCQ.CloseFile()
      Exit Sub
    End If

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsTXREAL.Tables(0).Rows.Count - 1)
      With DsTXREAL.Tables(0).Rows(I)
        Good = False
        If .Item("twnbn") <> 0 And .Item("fcyr") = 0 Then
          Good = True
        End If
        If .Item("fcyr") = WrkGLYear Or WrkPrev And .Item("fcyr") = WrkYear1 Then
          Good = True
        End If
        If Good Then
          WrkAssCode(0) = .Item("code1")
          WrkAssCode(1) = .Item("code2")
          WrkAssCode(2) = .Item("code3")
          WrkAssCode(3) = .Item("code4")
          WrkAssCode(4) = .Item("code5")
          WrkAssCode(5) = .Item("code6")
          WrkAssCode(6) = .Item("code7")
          If .Item("ccno") > 0 Then
            WrkGross(0) = .Item("cass1")
            WrkGross(1) = .Item("cass2")
            WrkGross(2) = .Item("cass3")
            WrkGross(3) = .Item("cass4")
            WrkGross(4) = .Item("cass5")
            WrkGross(5) = .Item("cass6")
            WrkGross(6) = .Item("cass7")
            WrkExam = .Item("cexa1") + .Item("cexa2") + .Item("cexa3") + .Item("cexa4") _
            + .Item("cexa5") + .Item("cexa6") + .Item("cexa7")
          Else
            WrkGross(0) = .Item("ass1")
            WrkGross(1) = .Item("ass2")
            WrkGross(2) = .Item("ass3")
            WrkGross(3) = .Item("ass4")
            WrkGross(4) = .Item("ass5")
            WrkGross(5) = .Item("ass6")
            WrkGross(6) = .Item("ass7")
            WrkExam = .Item("exam1") + .Item("exam2") + .Item("exam3") + .Item("exam4") _
            + .Item("exam5") + .Item("exam6") + .Item("exam7")
          End If

          'Add Gross to Land or Building total
          WrkAdjGross = 0
          WrkExcludeGross = 0
          For J = 0 To 6
            If WrkAssCode(J) <> cExcludeCode1 And WrkAssCode(J) <> cExcludeCode2 _
          And WrkAssCode(J) <> cExcludeCode3 And WrkAssCode(J) <> cExcludeCode4 Then
              WrkAdjGross = WrkAdjGross + WrkGross(J)
            Else
              WrkExcludeGross = WrkExcludeGross + WrkGross(J)
            End If
          Next J
          WrkNet = WrkAdjGross - WrkExam

          If .Item("ftax") > 0 Then
            dr = dsState.Tables(0).NewRow
          Else
            dr = dsLocal.Tables(0).NewRow
          End If
          dr.Item("listno") = .Item("list#")
          dr.Item("name") = .Item("name")
          ' added 8/28/23
          WrkSname = Trim(.Item("sname"))

          If MyFrmTA208B.ChkSname.Checked = True And WrkSname > " " Then
            dr.Item("line1") = .Item("sname")
            dr.Item("line2") = .Item("loc#") & " " & .Item("loc")
          Else
            dr.Item("line1") = .Item("loc#") & " " & .Item("loc")
            dr.Item("line2") = ""
          End If

          dr.Item("proploc") = .Item("loc#") & " " & .Item("loc")
            dr.Item("year") = .Item("fcyr")
            'Check for Even or Odd year
            If .Item("fcyr") Mod 2 = 0 Then
              dr.Item("code") = "E"
            Else
              dr.Item("code") = "O"
            End If
            dr.Item("netass") = WrkNet
            WrkTax = MyUtils.Round(WrkNet * MrateMillrt, 2)
            With myTPAYMNT
              .In_Year = WrkGLYear
              .In_Type = "R"
              .In_Dst = WrkDist
              .In_Phs = ""
              .In_TaxT = WrkTax
              .CalcPaySplit()
              WrkTax = .Out_TaxT
            End With
            dr.Item("tax") = WrkTax
            If .Item("fccod") = "F" Then
              WrkAdjTax = .Item("ftax")
              WrkBenefit = WrkTax - WrkAdjTax
            Else
              WrkBenefit = .Item("ftax")
              WrkAdjTax = WrkTax - WrkBenefit
            End If
            WrkLocal = .Item("twnbn")
            If WrkLocal > 0 Then
              SplitLocal(.Item("list#"), WrkLocal1, WrkLocal2, WrkLocal3, WrkLocal4, WrkLocal5)
              dr.Item("local1") = WrkLocal1
              dr.Item("local2") = WrkLocal2
              dr.Item("local3") = WrkLocal3
              dr.Item("local4") = WrkLocal4
              dr.Item("local5") = WrkLocal5
            End If
            dr.Item("cperc") = .Item("cperc")
            dr.Item("cmax") = .Item("cmax")
            dr.Item("cmin") = .Item("cmin")
            dr.Item("statecredit") = WrkBenefit
            dr.Item("localcredit") = WrkLocal
            dr.Item("adjtax") = WrkAdjTax - WrkLocal
            If .Item("ftax") > 0 Then
              dsState.Tables(0).Rows.Add(dr)
            Else
              dsLocal.Tables(0).Rows.Add(dr)
            End If
            dstemp = myTXM35H.GetbyList(.Item("list#"), .Item("fcyr"))
          Else
            dr = dsErrors.Tables(0).NewRow
          dr.Item("listno") = .Item("list#")
          dr.Item("name") = .Item("name")
          dr.Item("proploc") = .Item("loc#") & " " & .Item("loc")
          dr.Item("year") = .Item("fcyr")
          WrkLocal = .Item("twnbn")
          dr.Item("localcredit") = WrkLocal
          dsErrors.Tables(0).Rows.Add(dr)
        End If
      End With

      If Good Then
        If dstemp.Tables(0).Rows.Count > 1 Then
          For J = 0 To dstemp.Tables(0).Rows.Count - 1
            With dstemp.Tables(0).Rows(J)
              dr = dsSplit.Tables(0).NewRow
              dr.Item("listno") = .Item("list#")
              dr.Item("name") = Trim(.Item("alname")) & " " & Trim(.Item("afname"))
              If .Item("propct") <> 100 Then
                dr.Item("name") = dr.Item("name") & " (" & Format(.Item("propct") / 100, "##%") & ")"
              End If
              dr.Item("proploc") = DsTXREAL.Tables(0).Rows(I).Item("loc#") & " " & DsTXREAL.Tables(0).Rows(I).Item("loc")
              dr.Item("year") = DsTXREAL.Tables(0).Rows(I).Item("fcyr")
              'Check for Even or Odd year
              If DsTXREAL.Tables(0).Rows(I).Item("fcyr") Mod 2 = 0 Then
                dr.Item("code") = "E"
              Else
                dr.Item("code") = "O"
              End If
              GetCredit(.Item("list#"), .Item("seq"))
              If WrkFrzTax > 0 Then
                dr.Item("tax") = WrkFrzTax
              Else
                dr.Item("tax") = WrkTax
              End If
              dr.Item("cperc") = .Item("pct")
              dr.Item("cmax") = .Item("max")
              dr.Item("cmin") = .Item("min")
              dr.Item("statecredit") = WrkCredit
              dr.Item("adjtax") = WrkTax - WrkCredit
              If .Item("seq") = 0 Then
                dr.Item("acctadjtax") = WrkAdjTax
              Else
                dr.Item("acctadjtax") = 0
              End If
              If .Item("year") = WrkGLYear Or WrkPrev And .Item("year") = WrkYear1 Then
                dsSplit.Tables(0).Rows.Add(dr)
              End If
            End With
          Next
        End If
      End If

      'Elderly 
      If DsTXREAL.Tables(0).Rows(I).Item("fccod") = "C" Then
        dr = dsElderly.Tables(0).NewRow
        WrkNet = WrkNet + WrkExcludeGross
        dr.Item("listno") = DsTXREAL.Tables(0).Rows(I).Item("list#")
        dr.Item("netass") = WrkNet
        dr.Item("statecredit") = WrkBenefit
        dr.Item("localcredit") = WrkLocal
        WrkTax = MyUtils.Round(WrkNet * MrateMillrt, 2)
        With myTPAYMNT
          .In_Year = WrkGLYear
          .In_Type = "R"
          .In_Dst = WrkDist
          .In_Phs = ""
          .In_TaxT = WrkTax
          .CalcPaySplit()
          WrkTax = .Out_TaxT
        End With
        WrkAdjTax = WrkTax - WrkBenefit - WrkLocal
        dr.Item("tax") = WrkTax
        dr.Item("adjtax") = WrkAdjTax
        dsElderly.Tables(0).Rows.Add(dr)
      End If

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsTXREAL.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    myFrmProgress.Close()
    Application.DoEvents()
    myTXREALCQ.CloseFile()

  End Sub
  Public Sub GetMillRate(ByVal WrkGLYear As Integer, ByVal WrkDist As Integer)
    Dim myTXMRATE As TXMRATE.MyData

    myTXMRATE = New TXMRATE.MyData(myDBConnect)
    myTXMRATE.GetOneRecordP(WrkGLYear, "R", WrkDist)
    If myTXMRATE.RecordNotFound Then
      myTXMRATE.GetOneRecordP(WrkGLYear, "", WrkDist)
    End If
    If Not myTXMRATE.RecordNotFound Then
      With myTXMRATE
        MrateMillrt = ._MRRATE
      End With
    End If
    myTXMRATE.CloseFile()
  End Sub
  Public Function GetTXCDAGCode(ByVal Seq As Integer) As Integer
    Dim myTXCDAG As TXCDAG.MyData

    myTXCDAG = New TXCDAG.MyData(myDBConnect)
    If Seq = 0 Then
      Return 0
    End If

    myTXCDAG.GetOneRecordP(Seq)
    If Not myTXCDAG.RecordNotFound Then
      GetTXCDAGCode = myTXCDAG._TCCODE
    Else
      GetTXCDAGCode = 0
    End If
    Return GetTXCDAGCode

  End Function
  Private Sub GetCredit(WrkListNo As Integer, WrkSeq As Integer)
    Dim WrkAmount As Decimal

    With myTXM35H
      .GetOneRecordP(WrkListNo, WrkGLYear, WrkSeq)
      If ._FRZTAX > 0 Then
        WrkFrzTax = ._FRZTAX
        WrkTax = ._TAX
        WrkAmount = ._FRZTAX
      Else
        WrkFrzTax = 0
        WrkTax = ._TAX
        WrkAmount = ._TAX
      End If
      With myTPAYMNT
        .In_Year = WrkGLYear
        .In_Type = "R"
        .In_Dst = 0
        .In_Phs = ""
        .In_TaxT = WrkAmount
        .CalcPaySplit()
        WrkAmount = .Out_TaxT
      End With
      WrkCreditMax = MyUtils.Round(WrkAmount * (._PCT / 100), 2)
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
  Private Sub SplitLocal(ByVal WrkList As Integer, ByRef WrkLocal1 As Decimal, ByRef WrkLocal2 As Decimal,
 ByRef WrkLocal3 As Decimal, ByRef WrkLocal4 As Decimal, ByRef WrkLocal5 As Decimal)
    Dim dstemp As DataSet = New DataSet
    Dim I As Integer

    WrkLocal1 = 0
    WrkLocal2 = 0
    WrkLocal3 = 0
    WrkLocal4 = 0
    WrkLocal5 = 0
    dstemp = myTXLOCAL.GetViewbyList(WrkList, "R", 50)
    For I = 0 To dstemp.Tables(0).Rows.Count - 1
      If dstemp.Tables(0).Rows(I).Item("bencde") = WrkLocalCd1 Then
        WrkLocal1 = dstemp.Tables(0).Rows(I).Item("benamt")
      End If
      If dstemp.Tables(0).Rows(I).Item("bencde") = WrkLocalCd2 Then
        WrkLocal2 = dstemp.Tables(0).Rows(I).Item("benamt")
      End If
      If dstemp.Tables(0).Rows(I).Item("bencde") = WrkLocalCd3 Then
        WrkLocal3 = dstemp.Tables(0).Rows(I).Item("benamt")
      End If
      If dstemp.Tables(0).Rows(I).Item("bencde") = WrkLocalCd4 Then
        WrkLocal4 = dstemp.Tables(0).Rows(I).Item("benamt")
      End If
      If dstemp.Tables(0).Rows(I).Item("bencde") = WrkLocalCd5 Then
        WrkLocal5 = dstemp.Tables(0).Rows(I).Item("benamt")
      End If
    Next
  End Sub
End Module






