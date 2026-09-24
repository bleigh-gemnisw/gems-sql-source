Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXREAL As TXREAL.MyData
  Dim myUTCUST As UTCUST.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  'General
  Dim WrkPost As Boolean
  Dim WrkGLYear As Integer
  Dim WrkType As String
  Dim WrkAnd As String
  Dim WrkOr As String
  Dim WrkSortBy As String
  Public Sub PrtReport()

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXREAL = New TXREAL.MyData(myDBConnect)
    myUTCUST = New UTCUST.MyData(myDBConnect)
    With MyFrmTXE46B
      WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
      WrkType = .TxtType.Text
      WrkPost = .Chkupdatebacktax.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.Wrkds = ds
    MyCrViewer.WrkPost = WrkPost
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("OldDesc", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim dsinv As DataSet = New DataSet
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkFamily As String
    Dim Counter As Integer
    Dim I As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If
    If MyServer = "SQL" Then
      MyBlocking = False
    Else
      MyBlocking = True
    End If


    WrkFamily = GetTXTypeFamily(WrkType)
    'Milford use Real Estate for type U
    If myTOWN._TOWNBR = 84 Then
      If WrkType = "U" Then
        WrkFamily = "R"
      End If
    End If


    WrkSort = "LIST#, YEAR"
    ' WrkQry = "icode<>'I'" & WrkAnd & "TYPE = 'R'" & WrkAnd & "YEAR > " & (WrkGLYear - 15) & WrkAnd & "YEAR <= " & (WrkGLYear)
    WrkQry = "icode<>'I'" & WrkAnd & "TYPE=" & MyUtils.Quo(WrkType) & WrkAnd & "YEAR > " & (WrkGLYear - 15) & WrkAnd & "YEAR <= " & (WrkGLYear)

    dsinv = myTXINVQ.GetQry(WrkSort, WrkQry, 0)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    For I = 0 To dsinv.Tables(0).Rows.Count - 1
      dr = dsinv.Tables(0).Rows(I)
      Counter = Counter + 1
      With myTXINVQ
        .GetFieldsDr(dr)
        Select Case WrkFamily
          Case "R"

            myTXREAL.GetOneRecordP(._LISTNo)
            If myTXREAL.RecordNotFound Then GoTo NextRec
            If Trim(myTXREAL._LOC) = Trim(._LOC) And myTXREAL._LOCNO = ._LOCNo Then
              GoTo NextRec
            End If
            WriteDs(myTXREAL._LOCNO, myTXREAL._LOC)
            If WrkPost Then
              myTXINV.GetOneRecordP(._LISTNo, ._YEAR, ._TYPE)
              myTXINV._LOCNo = myTXREAL._LOCNO
              myTXINV._LOC = myTXREAL._LOC
              myTXINV.UpdateOneRecordP()
            End If
          Case "A", "U"
            myUTCUST.GetOneRecordP(._LISTNo)
            If myUTCUST.RecordNotFound Then GoTo NextRec
            If Trim(myUTCUST._CULOC) = Trim(._LOC) And myUTCUST._CULOCNO = ._LOCNo Then
              GoTo NextRec
            End If
            WriteDs(myUTCUST._CULOC, myUTCUST._CULOC)
            If WrkPost Then
              myTXINV.GetOneRecordP(._LISTNo, ._YEAR, ._TYPE)
              myTXINV._LOCNo = myUTCUST._CULOCNO
              myTXINV._LOC = myUTCUST._CULOC
              myTXINV.UpdateOneRecordP()
            End If
          Case Else
        End Select
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
    Next

    myFrmProgress.Close()
    myTXINVQ.CloseFile()

  End Sub
  Private Sub WriteDs(ByVal Wrklocno As String, Wrkloc As String)

    With myTXINVQ
      dr = ds.Tables(0).NewRow
      dr.Item("listno") = ._LISTNo
      dr.Item("year") = ._YEAR
      dr.Item("name") = Trim(._NAME)
      dr.Item("PropDesc") = Trim(Wrklocno) + " " + Trim(Wrkloc)
      dr.Item("OldDesc") = Trim(._LOCNo) + " " + Trim(._LOC)
    End With
    ds.Tables(0).Rows.Add(dr)
  End Sub
End Module
