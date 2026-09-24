Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim MyDbUtils As DBUtils.Utils
  Dim myTXREALQ As TXREALQ.MyData
  Dim myTXREAL As TXREAL.MyData
  Dim myTXREALCQ As TXREALCQ.MyData
  Dim myTXREALC As TXREALC.MyData
  Dim myTXBTRC As TXBTRC.MyData
  Dim myTXPHCNTL As TXPHCNTL.MyData
  Dim myTXPHIN As TXPHIN.MyData

  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim ds3 As DataSet = New DataSet
  Dim DsTXREAL As DataSet = New DataSet
  Dim dr As Data.DataRow
  'Screen fields
  Dim WrkFirstYear As Boolean
  Dim WrkCurrYear As Integer
  Dim WrkTotalYears As Integer
  Dim WrkApplyBTR As Boolean
  Dim WrkPost As Boolean
  'File
  Dim WrkGross As Integer
  Dim WrkAss(6) As Integer
  Dim WrkCode(6) As Integer
  Dim WrkOGross As Integer

  Public Sub PrtReport()

    myTXREALQ = New TXREALQ.MyData(myDBConnect)
    myTXREAL = New TXREAL.MyData(myDBConnect)
    myTXREALCQ = New TXREALCQ.MyData(myDBConnect)
    myTXREALC = New TXREALC.MyData(myDBConnect)
    myTXBTRC = New TXBTRC.MyData(myDBConnect)
    myTXPHIN = New TXPHIN.MyData(myDBConnect)
    myTXPHCNTL = New TXPHCNTL.MyData(myDBConnect)

    With MyFrmTA610B
      WrkCurrYear = MyUtils.CnvSng(.TxtCurrYear.Text)
      WrkTotalYears = MyUtils.CnvSng(.TxtTotalYears.Text)
      If .ChkBTR.Checked Then WrkApplyBTR = True
      If .ChkPost.Checked Then WrkPost = True
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
      ds2 = ds.Clone
      ds3 = ds.Clone
    Else
      ds.Clear()
      ds2.Clear()
      ds3.Clear()
    End If

    If WrkApplyBTR Then
      ApplyBTR()
    Else
      GetDetail()
    End If

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.wrkds2 = ds2
    MyCrViewer.wrkds3 = ds3
    MyCrViewer.WrkPost = WrkPost
    MyCrViewer.WrkCurrYear = WrkCurrYear
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("PropLoc", Type.GetType("System.String"))
      .Columns.Add("ogross", Type.GetType("System.Int32"))
      .Columns.Add("gross", Type.GetType("System.Int32"))
      .Columns.Add("phasein", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub ClearTXPHIN()
    MyDbUtils = New DBUtils.Utils(myDBConnect)
    MyDbUtils.DeleteAllRecs("TXPHIN")
    Application.DoEvents()
  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer

    WrkSort = "NAME"
    WrkQry = ""
    If WrkPost And WrkFirstYear Then
      ClearTXPHIN()
    End If

    myTXREALQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXREALQ.ReadQry()
    If Not myTXREALQ.IsEOF Then
      With myTXREALQ
        Counter = Counter + 1
        If WrkFirstYear Then
          WrkAss(0) = ._ASS1
          WrkAss(1) = ._ASS2
          WrkAss(2) = ._ASS3
          WrkAss(3) = ._ASS4
          WrkAss(4) = ._ASS5
          WrkAss(5) = ._ASS6
          WrkAss(6) = ._ASS7
          WrkGross = ._GROSS
          WrkCode(0) = ._CODE1
          WrkCode(1) = ._CODE2
          WrkCode(2) = ._CODE3
          WrkCode(3) = ._CODE4
          WrkCode(4) = ._CODE5
          WrkCode(5) = ._CODE6
          WrkCode(6) = ._CODE7
          WrkOGross = 0
          With myTXREALC
            .GetOneRecordP(myTXREALQ._LISTNO)
            WrkOGross = ._GROSS
            If WrkOGross >= myTXREALQ._GROSS Then 'Skipped
              dr = ds3.Tables(0).NewRow
              dr.Item("listno") = ._LISTNO
              dr.Item("name") = ._NAME
              dr.Item("proploc") = Trim(._LOCNO) & " " & ._LOC
              dr.Item("ogross") = WrkOGross
              dr.Item("gross") = WrkGross
              dr.Item("phasein") = 0
              ds3.Tables(0).Rows.Add(dr)
              GoTo NextRec
            End If
          End With
        Else
        End If

        If ._CAT <> "3" Then
          dr = ds.Tables(0).NewRow
        Else
          dr = ds2.Tables(0).NewRow
        End If
        dr.Item("listno") = ._LISTNO
        dr.Item("name") = ._NAME
        dr.Item("proploc") = Trim(._LOCNO) & " " & ._LOC
        dr.Item("ogross") = WrkOGross
        dr.Item("gross") = WrkGross
        dr.Item("phasein") = (dr.Item("gross") - dr.Item("ogross")) / WrkTotalYears
        If ._CAT <> "3" Then
          ds.Tables(0).Rows.Add(dr)
        Else
          ds2.Tables(0).Rows.Add(dr)
        End If

        If WrkPost Then
          UpdateTXPHIN(._LISTNO, 0)
          UpdateTXREAL(._LISTNO)
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

    If WrkPost Then
      UpdateTXPHCNTL()
    End If
    myFrmProgress.Close()
    myTXREALQ.CloseFile()
    myTXREAL.CloseFile()

  End Sub
  Private Sub UpdateTXPHCNTL()
    With myTXPHCNTL
      .GetOneRecordP("")
      ._CURRYEAR = WrkCurrYear
      ._TOTALYEARS = WrkTotalYears
      If .RecordNotFound Then
        ._RECID = ""
        .AddOneRecordP()
      Else
        .UpdateOneRecordP()
      End If
    End With
  End Sub
  Private Sub UpdateTXPHIN(ByVal WrkList As Integer, ByVal WrkBTR As Integer)
    Dim WrkPct As Decimal
    Dim WrkTotNass As Integer
    Dim WrkNass(6) As Integer
    Dim WrkTotass As Integer
    Dim WrkDiff As Integer

    With myTXPHIN
      .GetOneRecordP(WrkList)
      ._LISTNo = WrkList
      If WrkCurrYear = 1 Then
        If Not WrkApplyBTR Then
          ._ORIGRS = WrkOGross
          ._FULGRS = WrkGross - WrkOGross
        Else
          ._FULGRS = ._FULGRS + WrkBTR
        End If
      End If
      If ._FULGRS < 0 Then
        If .RecordNotFound Then
          Exit Sub
        Else
          ._FULGRS = 0
        End If
      End If
      WrkTotNass = ._FULGRS / WrkTotalYears
      If Not WrkApplyBTR Then
        WrkPct = WrkAss(0) / WrkGross
        WrkNass(0) = (._FULGRS * WrkPct / WrkTotalYears)
        WrkPct = WrkAss(1) / WrkGross
        WrkNass(1) = (._FULGRS * WrkPct / WrkTotalYears)
        WrkPct = WrkAss(2) / WrkGross
        WrkNass(2) = (._FULGRS * WrkPct / WrkTotalYears)
        WrkPct = WrkAss(3) / WrkGross
        WrkNass(3) = (._FULGRS * WrkPct / WrkTotalYears)
        WrkPct = WrkAss(4) / WrkGross
        WrkNass(4) = (._FULGRS * WrkPct / WrkTotalYears)
        WrkPct = WrkAss(5) / WrkGross
        WrkNass(5) = (._FULGRS * WrkPct / WrkTotalYears)
        WrkPct = WrkAss(6) / WrkGross
        WrkNass(6) = (._FULGRS * WrkPct / WrkTotalYears)
      Else
        WrkTotass = WrkAss(0) + WrkAss(1) + WrkAss(2) + WrkAss(3) + WrkAss(4) + WrkAss(5) + WrkAss(6)
        WrkPct = WrkAss(0) / WrkTotass
        WrkNass(0) = (._FULGRS * WrkPct / WrkTotalYears)
        WrkPct = WrkAss(1) / WrkTotass
        WrkNass(1) = (._FULGRS * WrkPct / WrkTotalYears)
        WrkPct = WrkAss(2) / WrkTotass
        WrkNass(2) = (._FULGRS * WrkPct / WrkTotalYears)
        WrkPct = WrkAss(3) / WrkTotass
        WrkNass(3) = (._FULGRS * WrkPct / WrkTotalYears)
        WrkPct = WrkAss(4) / WrkTotass
        WrkNass(4) = (._FULGRS * WrkPct / WrkTotalYears)
        WrkPct = WrkAss(5) / WrkTotass
        WrkNass(5) = (._FULGRS * WrkPct / WrkTotalYears)
        WrkPct = WrkAss(6) / WrkTotass
        WrkNass(6) = (._FULGRS * WrkPct / WrkTotalYears)
      End If

      ' Adjust for rounding differences
      WrkDiff = WrkTotNass - WrkNass(0) - WrkNass(1) - WrkNass(2) - WrkNass(3) - WrkNass(4) - WrkNass(5) - WrkNass(6)
      ' Apply difference to first non-zero bucket
      If WrkDiff <> 0 Then
        For I = 0 To 6
          If WrkNass(I) <> 0 Then
            WrkNass(I) += WrkDiff
            Exit For
          End If
        Next
      End If

      ._CAPA1 = WrkNass(0)
      ._CAPA2 = WrkNass(1)
      ._CAPA3 = WrkNass(2)
      ._CAPA4 = WrkNass(3)
      ._CAPA5 = WrkNass(4)
      ._CAPA6 = WrkNass(5)
      ._CAPA7 = WrkNass(6)
      ._CAPGRS = WrkNass(0) + WrkNass(1) + WrkNass(2) + WrkNass(3) + WrkNass(4) + WrkNass(5) + WrkNass(6)
      If Not WrkApplyBTR Then
        ._CAPC1 = WrkCode(0)
        ._CAPC2 = WrkCode(1)
        ._CAPC3 = WrkCode(2)
        ._CAPC4 = WrkCode(3)
        ._CAPC5 = WrkCode(4)
        ._CAPC6 = WrkCode(5)
        ._CAPC7 = WrkCode(6)
      End If
      If .RecordNotFound Then
        .AddOneRecordP()
      Else
        .UpdateOneRecordP()
      End If
    End With
  End Sub
  Private Sub UpdateTXREAL(ByVal WrkList As Integer)
    Dim Ass(6) As Decimal
    Dim Capa(6) As Decimal
    Dim WrkPct As Decimal
    Dim Total As Decimal = 0
    Dim I As Integer

    myTXREAL.GetOneRecordP(WrkList)
    If Not myTXREAL.RecordNotFound Then
      With myTXREAL
        myTXPHIN.GetOneRecordP(WrkList)
        If myTXPHIN.RecordNotFound Then Exit Sub
        If WrkGross = 0 Then Exit Sub
        ' Load CAPA values
        Capa(0) = myTXPHIN._CAPA1
        Capa(1) = myTXPHIN._CAPA2
        Capa(2) = myTXPHIN._CAPA3
        Capa(3) = myTXPHIN._CAPA4
        Capa(4) = myTXPHIN._CAPA5
        Capa(5) = myTXPHIN._CAPA6
        Capa(6) = myTXPHIN._CAPA7

        ' Calculate ASS values
        For I = 0 To 6
          WrkPct = WrkAss(I) / WrkGross
          Ass(I) = (myTXPHIN._ORIGRS * WrkPct) + Capa(I)
          Total += Ass(I)
        Next

        ' Adjust for rounding differences
        Dim expectedTotal As Decimal = myTXPHIN._ORIGRS + myTXPHIN._CAPGRS

        If Total <> expectedTotal Then
          Dim diff As Decimal = expectedTotal - Total

          ' Apply difference to first non-zero bucket
          For I = 0 To 6
            If Ass(I) <> 0 Then
              Ass(I) += diff
              Exit For
            End If
          Next
          Total = expectedTotal
        End If

        ' Assign back
        ._ASS1 = Ass(0)
        ._ASS2 = Ass(1)
        ._ASS3 = Ass(2)
        ._ASS4 = Ass(3)
        ._ASS5 = Ass(4)
        ._ASS6 = Ass(5)
        ._ASS7 = Ass(6)
        ._GROSS = Total
        ._NET = ._GROSS - ._EXAM1 - ._EXAM2 - ._EXAM3 - ._EXAM4 - ._EXAM5 - ._EXAM6 - ._EXAM7
        .UpdateOneRecordP()
      End With
    End If
  End Sub
  Private Sub ApplyBTR()
    Dim WrkBTR As Integer
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAmount As Integer
    Dim Counter As Integer

    WrkSort = "NAME"
    WrkQry = " BTR<>0 and dnbtr='N'"
    myTXREALCQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXREALCQ.ReadQry()
    If Not myTXREALCQ.IsEOF Then
      With myTXREALCQ
        Counter = Counter + 1
        myTXBTRC.GetOneRecordP(._LISTNO, "R")
        WrkAss(0) = ._ASS1 + myTXBTRC._BASS1
        WrkAss(1) = ._ASS2 + myTXBTRC._BASS2
        WrkAss(2) = ._ASS3 + myTXBTRC._BASS3
        WrkAss(3) = ._ASS4 + myTXBTRC._BASS4
        WrkAss(4) = ._ASS5 + myTXBTRC._BASS5
        WrkAss(5) = ._ASS6 + myTXBTRC._BASS6
        WrkAss(6) = ._ASS7 + myTXBTRC._BASS7
        myTXPHIN.GetOneRecordP(._LISTNO)
        WrkBTR = ._BTR * 5
        WrkGross = myTXPHIN._ORIGRS + myTXPHIN._FULGRS + WrkBTR
        WrkOGross = myTXPHIN._ORIGRS

        If ._CAT <> "3" Then
          dr = ds.Tables(0).NewRow
        Else
          dr = ds2.Tables(0).NewRow
        End If
        dr.Item("listno") = ._LISTNO
        dr.Item("name") = ._NAME
        dr.Item("proploc") = Trim(._LOCNO) & " " & ._LOC
        dr.Item("ogross") = WrkOGross
        dr.Item("gross") = WrkGross
        WrkAmount = (WrkGross - WrkOGross) / WrkTotalYears
        If WrkAmount < 0 Then WrkAmount = 0
        dr.Item("phasein") = WrkAmount
        If ._CAT <> "3" Then
          ds.Tables(0).Rows.Add(dr)
        Else
          ds2.Tables(0).Rows.Add(dr)
        End If

        If WrkPost Then
          UpdateTXPHIN(._LISTNO, WrkBTR)
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
    myTXREALQ.CloseFile()
  End Sub
End Module

