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
  Dim ds2 As DataSet = New DataSet
  Dim ds3 As DataSet = New DataSet
  Dim DsTXREAL As DataSet = New DataSet
  Dim dr As Data.DataRow
  'Screen fields
  Dim WrkFirstYear As Boolean
  Dim WrkCurrYear As Integer
  Dim WrkTotalYears As Integer
  Dim WrkPost As Boolean
  'File
  Dim WrkGross As Integer
  Dim WrkAss(6) As Integer
  Dim WrkCode(6) As Integer
  Dim WrkOGross As Integer

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
      ds2 = ds.Clone
      ds3 = ds.Clone
    Else
      ds.Clear()
      ds2.Clear()
      ds3.Clear()
    End If

    GetDetail()

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
    Dim WrkPct As Decimal
    Dim WrkNass1 As Integer
    Dim WrkNass2 As Integer
    Dim WrkNass3 As Integer
    Dim WrkNass4 As Integer
    Dim WrkNass5 As Integer
    Dim WrkNass6 As Integer
    Dim WrkNass7 As Integer

    With myTXPHIN
      .GetOneRecordP(WrkList)
      If WrkFirstYear Then
        ._LISTNo = WrkList
        ._FULGRS = WrkGross - WrkOGross
        If ._FULGRS < 0 Then
          Exit Sub
        End If
        ._ORIGRS = WrkOGross
        WrkPct = WrkAss(0) / WrkGross
        WrkNass1 = (._FULGRS * WrkPct / WrkTotalYears)
        WrkPct = WrkAss(1) / WrkGross
        WrkNass2 = (._FULGRS * WrkPct / WrkTotalYears)
        WrkPct = WrkAss(2) / WrkGross
        WrkNass3 = (._FULGRS * WrkPct / WrkTotalYears)
        WrkPct = WrkAss(3) / WrkGross
        WrkNass4 = (._FULGRS * WrkPct / WrkTotalYears)
        WrkPct = WrkAss(4) / WrkGross
        WrkNass5 = (._FULGRS * WrkPct / WrkTotalYears)
        WrkPct = WrkAss(5) / WrkGross
        WrkNass6 = (._FULGRS * WrkPct / WrkTotalYears)
        WrkPct = WrkAss(6) / WrkGross
        WrkNass7 = (._FULGRS * WrkPct / WrkTotalYears)
        ._CAPA1 = WrkNass1
        ._CAPA2 = WrkNass2
        ._CAPA3 = WrkNass3
        ._CAPA4 = WrkNass4
        ._CAPA5 = WrkNass5
        ._CAPA6 = WrkNass6
        ._CAPA7 = WrkNass7
        ._CAPGRS = WrkNass1 + WrkNass2 + WrkNass3 + WrkNass4 + WrkNass5 + WrkNass6 + WrkNass7
        ._CAPC1 = WrkCode(0)
        ._CAPC2 = WrkCode(1)
        ._CAPC3 = WrkCode(2)
        ._CAPC4 = WrkCode(3)
        ._CAPC5 = WrkCode(4)
        ._CAPC6 = WrkCode(5)
        ._CAPC7 = WrkCode(6)
        If myTXPHIN.RecordNotFound Then
          .AddOneRecordP()
        End If
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
End Module

