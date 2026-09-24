Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXREALCQ As TXREALCQ.MyData
  Dim myTXLOCAL As TXLOCAL.MyData
  Dim myTXLOCCD As TXLOCCD.MyData

  Dim ds As DataSet = New DataSet
  Dim dsErr As DataSet = New DataSet
  Dim dsDet As DataSet = New DataSet
  Dim dsDetErr As DataSet = New DataSet
  Dim dsTXREAL As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim drDet As Data.DataRow

  'Screen fields
  Dim WrkGLYear As Integer

  'Common Work fields
  Dim WrkListNo As Integer
  Dim WrkType As String
  Dim WrkError As Boolean

  Public Sub PrtReport()
    Dim ds2 As DataSet = New DataSet

    myTXREALCQ = New TXREALCQ.MyData(myDBConnect)
    myTXLOCAL = New TXLOCAL.MyData(myDBConnect)
    myTXLOCCD = New TXLOCCD.MyData(myDBConnect)

    With MyFrmTA207B
      WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
    End With

    WrkType = "R"

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
      dsDet.Clear()
      dsErr.Clear()
      dsDetErr.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .wrkdsErr = dsErr
      .WrkGLYear = WrkGLYear
      .Show()
    End With

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Gross", Type.GetType("System.Int32"))
      .Columns.Add("Location", Type.GetType("System.String"))
      .Columns.Add("Benefit", Type.GetType("System.Decimal"))
      .Columns.Add("EldCode", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

    With myTable2
      .TableName = "mytable2"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("BenCode", Type.GetType("System.String"))
      .Columns.Add("BenDesc", Type.GetType("System.String"))
      .Columns.Add("BenAmount", Type.GetType("System.Decimal"))
    End With
    dsDet.Tables.Add(myTable2)
    dsErr = ds.Clone
    dsDetErr = dsDet.Clone
  End Sub

  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim I As Integer
    Dim WrkAnd As String

    If MyServer = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = "TWNBN <> 0"
    WrkSort = "NAME, LIST#"

    dsTXREAL = myTXREALCQ.GetQry(WrkSort, WrkQry, 0)
    If dsTXREAL.Tables(0).Rows.Count = 0 Then
      myTXREALCQ.CloseFile()
      Exit Sub
    End If

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (dsTXREAL.Tables(0).Rows.Count - 1)
      With dsTXREAL.Tables(0).Rows(I)
        WrkError = False
        WrkListNo = .Item("list#")

        WriteLocal()
        'Report
        If Not WrkError Then
          dr = ds.Tables(0).NewRow
        Else
          dr = dsErr.Tables(0).NewRow
        End If
        dr.Item("listno") = WrkListNo
        dr.Item("name") = .Item("name")
        If .Item("ccno") > 0 Then
          dr.Item("gross") = .Item("ccgrs")
        Else
          dr.Item("gross") = .Item("gross")
        End If
        dr.Item("location") = Trim(.Item("loc#")) & " " & .Item("loc")
        dr.Item("benefit") = .Item("twnbn")
        dr.Item("eldcode") = .Item("fccod")
        If Not WrkError Then
          ds.Tables(0).Rows.Add(dr)
        Else
          dsErr.Tables(0).Rows.Add(dr)
        End If
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / dsTXREAL.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    ds.Merge(dsDet)
    dsErr.Merge(dsDetErr)
    myFrmProgress.Close()
    myTXREALCQ.CloseFile()

  End Sub
  Private Sub WriteLocal()
    Dim dsTXLOCAL As DataSet = New DataSet
    Dim dsTXLOCAL2 As DataSet = New DataSet
    Dim I As Integer

    dsTXLOCAL = myTXLOCAL.GetViewbyList(WrkListNo, WrkGLYear, WrkType, 999)
    If dsTXLOCAL.Tables(0).Rows.Count = 0 Then
      dsTXLOCAL2 = myTXLOCAL.GetViewbyList(WrkListNo, WrkGLYear - 1, WrkType, 999)
      dsTXLOCAL.Merge(dsTXLOCAL2)
    End If
    If dsTXLOCAL.Tables(0).Rows.Count = 0 Then
      dsTXLOCAL = myTXLOCAL.GetAllList(WrkListNo, WrkType, 999)
      WrkError = True
    End If

    For I = 0 To dsTXLOCAL.Tables(0).Rows.Count - 1
      With dsTXLOCAL.Tables(0).Rows(I)
        If Not WrkError Then
          drDet = dsDet.Tables(0).NewRow
        Else
          drDet = dsDetErr.Tables(0).NewRow
        End If
        drDet.Item("listno") = WrkListNo
        drDet.Item("year") = .Item("year")
        drDet.Item("bencode") = .Item("bencde")
        drDet.Item("benamount") = .Item("benamt")
        myTXLOCCD.GetOneRecordP(.Item("bencde"))
      End With
      With myTXLOCCD
        drDet.Item("bendesc") = Trim(._BNDSC)
      End With
      If Not WrkError Then
        dsDet.Tables(0).Rows.Add(drDet)
      Else
        dsDetErr.Tables(0).Rows.Add(drDet)
      End If
    Next I
    dsTXLOCAL.Clear()
    dsTXLOCAL2.Clear()
  End Sub
End Module






