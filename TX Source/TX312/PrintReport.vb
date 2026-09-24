Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXINV As TXINV.MyData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  'General
  Dim WrkAnd As String
  Dim WrkOr As String
  Dim WrkSortBy As String
  Dim WrkType As String
  Public Sub PrtReport()

    myTXINVQ = New TXINVQ.mydata(MyDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("Mlistno", Type.GetType("System.Int32"))

    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim dsinv As DataSet = New DataSet
    Dim WrkFromYear As Integer
    Dim WrkToYear As Integer
    Dim WrkQry As String
    Dim SaveQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim WrkCode As String
    Dim WrkBalance As Boolean
    Dim WrkPost As Boolean
    Dim Good As Boolean
    Dim I As Integer

    With MyFrmTX312B
      If .ChkUpdate.Checked Then WrkPost = True
      WrkFromYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
      WrkToYear = MyUtils.CnvSng(.TxtToGLYear.Text)
      WrkCode = .TxtCode.Text
      WrkType = .TxtType.Text
      WrkBalance = .ChkBalance.Checked
    End With

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    Counter = 0
    WrkSort = ""
    If WrkToYear = 0 Then WrkToYear = 9999
    WrkQry = "icode<>'I'" & WrkAnd & "YEAR >= " & WrkFromYear & WrkAnd & "YEAR <= " & WrkToYear
    If WrkType <> String.Empty Then
      WrkQry = WrkQry & WrkAnd & "TYPE=" & MyUtils.Quo(WrkType)
    End If
    If WrkBalance Then
      WrkQry = WrkQry & WrkAnd & "BALD = 0"
    End If

    SaveQry = WrkQry
    WrkQry = WrkQry & WrkAnd & "STCD1=" & MyUtils.Quo(WrkCode)
    WrkQry = WrkQry & WrkOr & SaveQry & WrkAnd & "STCD2=" & MyUtils.Quo(WrkCode)
    WrkQry = WrkQry & WrkOr & SaveQry & WrkAnd & "STCD3=" & MyUtils.Quo(WrkCode)
    WrkQry = WrkQry & WrkOr & SaveQry & WrkAnd & "STCD4=" & MyUtils.Quo(WrkCode)
    WrkQry = WrkQry & WrkOr & SaveQry & WrkAnd & "STCD5=" & MyUtils.Quo(WrkCode)

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
        Good = False
        WriteDs()
        If WrkPost Then
          UpdateTXINV(WrkCode)
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
    Next

    myFrmProgress.Close()
    myTXINVQ.CloseFile()

  End Sub

  Private Sub WriteDs()

    With myTXINVQ
      dr = ds.Tables(0).NewRow
      dr.Item("listno") = ._LISTNo
      dr.Item("year") = ._YEAR
      dr.Item("type") = ._TYPE
      dr.Item("name") = Trim(._NAME)
    End With
    ds.Tables(0).Rows.Add(dr)
  End Sub
  Private Sub UpdateTXINV(ByVal WrkCode As String)
    With myTXINV
      .GetOneRecordP(myTXINVQ._LISTNo, myTXINVQ._YEAR, myTXINVQ._TYPE)
      If ._STCD1 = WrkCode Then
        ._STCD1 = ""
      End If
      If ._STCD2 = WrkCode Then
        ._STCD2 = ""
      End If
      If ._STCD3 = WrkCode Then
        ._STCD3 = ""
      End If
      If ._STCD4 = WrkCode Then
        ._STCD4 = ""
      End If
      If ._STCD5 = WrkCode Then
        ._STCD5 = ""
      End If
      .UpdateOneRecordP()
    End With
  End Sub
End Module






