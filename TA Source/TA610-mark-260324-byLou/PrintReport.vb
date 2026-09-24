Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim MyDbUtils As DBUtils.Utils
  Dim myTXREALQ As TXREALQ.MyData
  Dim myTXREAL As TXREAL.MyData
  Dim myTXREALC As TXREALC.MyData
  Dim myTXPHCNTL As TXPHCNTL.MyData
  Dim myTXPHIN As TXPHIN.MyData

  Dim ds As DataSet = New DataSet
  Dim DsTXREAL As DataSet = New DataSet
  Dim dr As Data.DataRow
  'Screen fields
  Dim WrkFirstYear As Boolean
  Dim WrkCurrYear As Integer
  Dim WrkTotalYears As Integer
  Dim WrkPost As Boolean
  'File
  Dim WrkAss(6) As Integer
  Dim WrkCode(6) As Integer
  Dim WrkOAss(6) As Integer

  Public Sub PrtReport()

    myTXREALQ = New TXREALQ.MyData(myDBConnect)
    myTXREAL = New TXREAL.MyData(myDBConnect)
    myTXREALC = New TXREALC.MyData(myDBConnect)
    myTXPHIN = New TXPHIN.MyData(myDBConnect)
    myTXPHCNTL = New TXPHCNTL.MyData(myDBConnect)

    With MyFrmTA610B
      WrkFirstYear = .RbFirstYear.Checked
      WrkCurrYear = MyUtils.CnvSng(.TxtCurrYear.Text)
      WrkTotalYears = MyUtils.CnvSng(.TxtTotalYears.Text)
      If .ChkPost.Checked Then WrkPost = True
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.WrkPost = WrkPost
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
    myDBUtils = New DBUtils.Utils(myDBConnect)
    myDBUtils.DeleteAllRecs("TXPHIN")
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
          WrkCode(0) = ._CODE1
          WrkCode(1) = ._CODE2
          WrkCode(2) = ._CODE3
          WrkCode(3) = ._CODE4
          WrkCode(4) = ._CODE5
          WrkCode(5) = ._CODE6
          WrkCode(6) = ._CODE7
          Array.Clear(WrkOAss, 0, 6)
          With myTXREALC
            .GetOneRecordP(myTXREALQ._LISTNO)
            WrkOAss(0) = ._ASS1
            WrkOAss(1) = ._ASS2
            WrkOAss(2) = ._ASS3
            WrkOAss(3) = ._ASS4
            WrkOAss(4) = ._ASS5
            WrkOAss(5) = ._ASS6
            WrkOAss(6) = ._ASS7
            If ._GROSS >= myTXREALQ._GROSS Then
              GoTo NextRec
            End If
          End With
        Else
        End If

        dr = ds.Tables(0).NewRow
        dr.Item("listno") = ._LISTNO
        dr.Item("name") = ._NAME
        dr.Item("proploc") = Trim(._LOCNO) & " " & ._LOC
        dr.Item("ogross") = WrkOAss(0) + WrkOAss(1) + WrkOAss(2) + WrkOAss(3) + WrkOAss(4) + WrkOAss(5) + WrkOAss(6)
        dr.Item("gross") = WrkAss(0) + WrkAss(1) + WrkAss(2) + WrkAss(3) + WrkAss(4) + WrkAss(5) + WrkAss(6)
        dr.Item("phasein") = (dr.Item("gross") - dr.Item("ogross")) / WrkTotalYears
        ds.Tables(0).Rows.Add(dr)

        If WrkPost Then
          UpdateTXPHIN(._LISTNO)
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
  Private Sub UpdateTXPHIN(ByVal WrkList As Integer)
    With myTXPHIN
      .GetOneRecordP(WrkList)
      If WrkFirstYear Then
        ._FULC1 = WrkAss(0)
        ._FULA2 = WrkAss(1)
        ._FULA3 = WrkAss(2)
        ._FULA4 = WrkAss(3)
        ._FULA5 = WrkAss(4)
        ._FULA6 = WrkAss(5)
        ._FULA7 = WrkAss(6)
        ._FULGRS = WrkAss(0) + WrkAss(1) + WrkAss(2) + WrkAss(3) + WrkAss(4) + WrkAss(5) + WrkAss(6)
        ._CAPC1 = (WrkAss(0) - WrkOAss(0)) / WrkTotalYears
        ._CAPA2 = (WrkAss(1) - WrkOAss(1)) / WrkTotalYears
        ._CAPA3 = (WrkAss(2) - WrkOAss(2)) / WrkTotalYears
        ._CAPA4 = (WrkAss(3) - WrkOAss(3)) / WrkTotalYears
        ._CAPA5 = (WrkAss(4) - WrkOAss(4)) / WrkTotalYears
        ._CAPA6 = (WrkAss(5) - WrkOAss(5)) / WrkTotalYears
        ._CAPA7 = (WrkAss(6) - WrkOAss(6)) / WrkTotalYears
        ._CAPGRS = ._CAPC1 + ._CAPC2 + ._CAPC3 + ._CAPC4 + ._CAPC5 + ._CAPC6 + ._CAPC7
        If ._CAPGRS < 0 Then
          Exit Sub
        End If
        If myTXPHIN.RecordNotFound Then
          .AddOneRecordP()
        End If
      End If
    End With
  End Sub
  Private Sub UpdateTXREAL(ByVal WrkList As Integer)
    Dim WrkDiffYears As Integer

    myTXREAL.GetOneRecordP(WrkList)
    If Not myTXREAL.RecordNotFound Then
      With myTXREAL
        myTXPHIN.GetOneRecordP(WrkList)
        If .RecordNotFound Then
          Exit Sub
        End If
        WrkDiffYears = WrkTotalYears - WrkCurrYear
        ._ASS1 = myTXPHIN._FULA1 - (myTXPHIN._CAPA1 * WrkDiffyears)
        ._ASS2 = myTXPHIN._FULA2 - (myTXPHIN._CAPA2 * WrkDiffYears)
        ._ASS3 = myTXPHIN._FULA3 - (myTXPHIN._CAPA3 * WrkDiffYears)
        ._ASS4 = myTXPHIN._FULA4 - (myTXPHIN._CAPA4 * WrkDiffYears)
        ._ASS5 = myTXPHIN._FULA5 - (myTXPHIN._CAPA5 * WrkDiffYears)
        ._ASS6 = myTXPHIN._FULA6 - (myTXPHIN._CAPA6 * WrkDiffYears)
        ._ASS7 = myTXPHIN._FULA7 - (myTXPHIN._CAPA7 * WrkDiffYears)
        ._GROSS = ._ASS1 + ._ASS2 + ._ASS3 + ._ASS4 + ._ASS5 + ._ASS6 + ._ASS7
        ._NET = ._GROSS - ._EXAM1 - ._EXAM2 - ._EXAM3 - ._EXAM4 - ._EXAM5 - ._EXAM6 - ._EXAM7
        .UpdateOneRecordP()
      End With
    End If
  End Sub
End Module

