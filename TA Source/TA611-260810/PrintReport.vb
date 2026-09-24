Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim MyDbUtils As DBUtils.Utils
  Dim myTXCOEAQ As TXCOEAQ.MyData
  Dim myTXREAL As TXREAL.MyData
  Dim myTXPHCNTL As TXPHCNTL.MyData
  Dim myTXPHIN As TXPHIN.MyData

  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim ds3 As DataSet = New DataSet
  Dim DsTXREAL As DataSet = New DataSet
  Dim dr As Data.DataRow
  'Screen fields
  Dim WrkGLYear As Integer
  Dim WrkPost As Boolean
  'File
  Dim WrkStartYear As Integer
  Dim WrkTotalYears As Integer
  Dim WrkGross As Integer
  Dim WrkAss(6) As Integer
  Dim WrkCode(6) As Integer
  Dim WrkOGross As Integer

  Public Sub PrtReport()

    myTXCOEAQ = New TXCOEAQ.MyData(myDBConnect)
    myTXREAL = New TXREAL.MyData(myDBConnect)
    myTXPHIN = New TXPHIN.MyData(myDBConnect)
    myTXPHCNTL = New TXPHCNTL.MyData(myDBConnect)

    With MyFrmTA611B
      WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
      If .ChkPost.Checked Then WrkPost = True
    End With

    With myTXPHCNTL
      WrkTotalYears = ._TOTALYEARS
      WrkStartYear = ._STARTYEAR
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
      ds2 = ds.Clone
    Else
      ds.Clear()
      ds2.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.WrkGLYear = WrkGLYear
    MyCrViewer.wrkds = ds
    MyCrViewer.wrkds2 = ds2
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
  Private Sub GetDetail()
    Dim dsfile As DataSet = New DataSet
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkOLdFul As Integer
    Dim WrkNewFul As Integer
    Dim Counter As Integer

    WrkSort = "NAME"
    WrkQry = "year=" & WrkGLYear & " and type='R'"

    myTXCOEAQ.OpenQry(WrkSort, WrkQry)
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXCOEAQ.ReadQry()
    If Not myTXCOEAQ.IsEOF Then
      With myTXCOEAQ
        Counter = Counter + 1
        myTXREAL.GetOneRecordP(._LISTNo)
        WrkOGross = ._CGRS + ._GRCHG
        WrkGross = 0
        WrkOLdFul = 0
        WrkNewFul = 0
        With myTXPHIN
          .GetOneRecordP(myTXCOEAQ._LISTNo, WrkGLYear)
          If Not .RecordNotFound And ._FULGRS > 0 Then
            WrkGross = WrkOGross + ._AFTGRS
            WrkOLdFul = ._FULGRS
          Else
            GoTo NextRec
          End If
        End With

        With myTXPHIN
          .GetOneRecordP(myTXCOEAQ._LISTNo, WrkGLYear + 1)
          If Not .RecordNotFound And ._FULGRS > 0 Then
            WrkNewFul = ._FULGRS
          Else
            GoTo NextRec
          End If
        End With

        If WrkOLdFul = WrkNewFul Then
          GoTo NextRec
        End If

        If myTXREAL._CAT <> "3" Then
          dr = ds.Tables(0).NewRow
        Else
          dr = ds2.Tables(0).NewRow
        End If
        dr.Item("listno") = ._LISTNo
        dr.Item("name") = ._NAME
        dr.Item("proploc") = Trim(myTXREAL._LOCNO) & " " & myTXREAL._LOC
        dr.Item("ogross") = WrkOGross
        dr.Item("gross") = WrkGross
        dr.Item("phasein") = WrkGross - WrkOGross
        If myTXREAL._CAT <> "3" Then
          ds.Tables(0).Rows.Add(dr)
        Else
          ds2.Tables(0).Rows.Add(dr)
        End If

        If WrkPost Then
          UpdateTXPHIN(._LISTNo)
          AdjustTXREAL(._LISTNo)
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
    myTXCOEAQ.CloseFile()
    myTXREAL.CloseFile()

  End Sub
  Private Sub UpdateTXPHIN(ByVal WrkList As Integer)
    Dim WrkCapGrs As Integer
    Dim WrkFulGrs As Integer

    With myTXPHIN
      .GetOneRecordP(WrkList, WrkGLYear)
      WrkAss(0) = ._CAPA1 + ._ADJA1 + ._AFTA1
      WrkAss(1) = ._CAPA2 + ._ADJA2 + ._AFTA2
      WrkAss(2) = ._CAPA3 + ._ADJA3 + ._AFTA3
      WrkAss(3) = ._CAPA4 + ._ADJA4 + ._AFTA4
      WrkAss(4) = ._CAPA5 + ._ADJA5 + ._AFTA5
      WrkAss(5) = ._CAPA6 + ._ADJA6 + ._AFTA6
      WrkAss(6) = ._CAPA7 + ._ADJA7 + ._AFTA7
      WrkCapGrs = ._CAPGRS + ._ADJGRS + ._AFTGRS
      WrkCode(0) = ._AFTC1
      WrkCode(1) = ._AFTC2
      WrkCode(2) = ._AFTC3
      WrkCode(3) = ._AFTC4
      WrkCode(4) = ._AFTC5
      WrkCode(5) = ._AFTC6
      WrkCode(6) = ._AFTC7
      WrkFulGrs = ._FULGRS
    End With

    With myTXPHIN
      .GetOneRecordP(WrkList, WrkGLYear + 1)
      ._CAPA1 = WrkAss(0)
      ._CAPA2 = WrkAss(1)
      ._CAPA3 = WrkAss(2)
      ._CAPA4 = WrkAss(3)
      ._CAPA5 = WrkAss(4)
      ._CAPA6 = WrkAss(5)
      ._CAPA7 = WrkAss(6)
      ._CAPGRS = WrkCapGrs
      ._CAPC1 = WrkCode(0)
      ._CAPC2 = WrkCode(1)
      ._CAPC3 = WrkCode(2)
      ._CAPC4 = WrkCode(3)
      ._CAPC5 = WrkCode(4)
      ._CAPC6 = WrkCode(5)
      ._CAPC7 = WrkCode(6)
      ._FULGRS = WrkFulGrs
      If Not .RecordNotFound Then
        .UpdateOneRecordP()
      End If
    End With
  End Sub
  Private Sub AdjustTXREAL(ByVal WrkList As Integer)
    Dim WrkAft(6) As Decimal
    Dim Total As Decimal = 0
    Dim I As Integer

    myTXREAL.GetOneRecordP(WrkList)
    If Not myTXREAL.RecordNotFound Then
      With myTXREAL
        myTXPHIN.GetOneRecordP(WrkList, WrkGLYear)
        If myTXPHIN.RecordNotFound Then Exit Sub
        myTXREAL.GetOneRecordP(WrkList)
        WrkAss(0) = ._ASS1
        WrkAss(1) = ._ASS2
        WrkAss(2) = ._ASS3
        WrkAss(3) = ._ASS4
        WrkAss(4) = ._ASS5
        WrkAss(5) = ._ASS6
        WrkAss(6) = ._ASS7
        WrkAft(0) = myTXPHIN._AFTA1
        WrkAft(1) = myTXPHIN._AFTA2
        WrkAft(2) = myTXPHIN._AFTA3
        WrkAft(3) = myTXPHIN._AFTA4
        WrkAft(4) = myTXPHIN._AFTA5
        WrkAft(5) = myTXPHIN._AFTA6
        WrkAft(6) = myTXPHIN._AFTA7

        'Calculate ASS values
        For I = 0 To 6
          WrkAss(I) = WrkAss(I) + WrkAft(I)
          Total += WrkAss(I)
        Next

        ._ASS1 = WrkAss(0)
        ._ASS2 = WrkAss(1)
        ._ASS3 = WrkAss(2)
        ._ASS4 = WrkAss(3)
        ._ASS5 = WrkAss(4)
        ._ASS6 = WrkAss(5)
        ._ASS7 = WrkAss(6)
        ._CODE1 = Trim(myTXPHIN._AFTC1)
        ._CODE2 = Trim(myTXPHIN._AFTC2)
        ._CODE3 = Trim(myTXPHIN._AFTC3)
        ._CODE4 = Trim(myTXPHIN._AFTC4)
        ._CODE5 = Trim(myTXPHIN._AFTC5)
        ._CODE6 = Trim(myTXPHIN._AFTC6)
        ._CODE7 = Trim(myTXPHIN._AFTC7)
        ._GROSS = Total
        ._NET = ._GROSS - ._EXAM1 - ._EXAM2 - ._EXAM3 - ._EXAM4 - ._EXAM5 - ._EXAM6 - ._EXAM7
        .UpdateOneRecordP()
      End With
    End If
  End Sub
End Module

