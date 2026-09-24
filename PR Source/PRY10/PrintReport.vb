Module PrintReport
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myW2PRINTQ As W2PRINTQ.MyData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  Public Sub PrtReport()

    myW2PRINTQ = New W2PRINTQ.MyData(myDBConnect)

    With MyFrmPRY10B
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    GetDetail()

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .Show()
    End With
  End Sub
  Friend Sub BuildDS()
    Dim myTable As New DataTable

    With myTable
      .TableName = "w2print"
      .Columns.Add("w2year", Type.GetType("System.Int32"))
      .Columns.Add("wempno", Type.GetType("System.Int32"))
      .Columns.Add("wssn", Type.GetType("System.String"))
      .Columns.Add("wfedid", Type.GetType("System.String"))
      .Columns.Add("wernam", Type.GetType("System.String"))
      .Columns.Add("wemsuf", Type.GetType("System.String"))
      .Columns.Add("werad1", Type.GetType("System.String"))
      .Columns.Add("werad2", Type.GetType("System.String"))
      .Columns.Add("wcntrl", Type.GetType("System.String"))
      .Columns.Add("wemfnm", Type.GetType("System.String"))
      .Columns.Add("wemlnm", Type.GetType("System.String"))
      .Columns.Add("wemad1", Type.GetType("System.String"))
      .Columns.Add("wemad2", Type.GetType("System.String"))
      .Columns.Add("wemad3", Type.GetType("System.String"))
      .Columns.Add("wficgr", Type.GetType("System.Decimal"))
      .Columns.Add("wfictx", Type.GetType("System.Decimal"))
      .Columns.Add("wfitgr", Type.GetType("System.Decimal"))
      .Columns.Add("wfittx", Type.GetType("System.Decimal"))
      .Columns.Add("wmedgr", Type.GetType("System.Decimal"))
      .Columns.Add("wmedtx", Type.GetType("System.Decimal"))
      .Columns.Add("wsstip", Type.GetType("System.Decimal"))
      .Columns.Add("waltip", Type.GetType("System.Decimal"))
      .Columns.Add("wdepc", Type.GetType("System.Decimal"))
      .Columns.Add("wnonq", Type.GetType("System.Int32"))
      .Columns.Add("wcd12a", Type.GetType("System.String"))
      .Columns.Add("wcd12b", Type.GetType("System.String"))
      .Columns.Add("wcd12c", Type.GetType("System.String"))
      .Columns.Add("wcd12d", Type.GetType("System.String"))
      .Columns.Add("wam12a", Type.GetType("System.Decimal"))
      .Columns.Add("wam12b", Type.GetType("System.Decimal"))
      .Columns.Add("wam12c", Type.GetType("System.Decimal"))
      .Columns.Add("wam12d", Type.GetType("System.Decimal"))
      .Columns.Add("wbx13a", Type.GetType("System.String"))
      .Columns.Add("wbx13b", Type.GetType("System.String"))
      .Columns.Add("wbx13c", Type.GetType("System.String"))
      .Columns.Add("wcd14a", Type.GetType("System.String"))
      .Columns.Add("wcd14b", Type.GetType("System.String"))
      .Columns.Add("wcd14c", Type.GetType("System.String"))
      .Columns.Add("wcd14d", Type.GetType("System.String"))
      .Columns.Add("wam14a", Type.GetType("System.Decimal"))
      .Columns.Add("wam14b", Type.GetType("System.Decimal"))
      .Columns.Add("wam14c", Type.GetType("System.Decimal"))
      .Columns.Add("wam14d", Type.GetType("System.Decimal"))
      .Columns.Add("wstatc", Type.GetType("System.String"))
      .Columns.Add("wstatn", Type.GetType("System.String"))
      .Columns.Add("wsttax", Type.GetType("System.Decimal"))
      .Columns.Add("wlogrs", Type.GetType("System.Decimal"))
      .Columns.Add("wstgrs", Type.GetType("System.Decimal"))
      .Columns.Add("wlotax", Type.GetType("System.Decimal"))
      .Columns.Add("wlonam", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim Counter As Integer

    If myDBConnect.ServerAS400 Then
      WrkOr = " *or "
      WrkAnd = " *and "
    Else
      WrkOr = " or "
      WrkAnd = " and "
    End If

    WrkSort = ""
    WrkQry = ""
    Counter = 0

    myW2PRINTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myW2PRINTQ.ReadQry()
    If Not myW2PRINTQ.IsEOF Then
      With myW2PRINTQ
        Counter = Counter + 1
        dr = ds.Tables(0).NewRow
        dr.Item("W2YEAR") = ._W2YEAR
        dr.Item("WALTIP") = ._WALTIP
        dr.Item("WAM12A") = ._WAM12A
        dr.Item("WAM12B") = ._WAM12B
        dr.Item("WAM12C") = ._WAM12C
        dr.Item("WAM12D") = ._WAM12D
        dr.Item("WAM14A") = ._WAM14A
        dr.Item("WAM14B") = ._WAM14B
        dr.Item("WAM14C") = ._WAM14C
        dr.Item("WAM14D") = ._WAM14D
        dr.Item("WBX13A") = ._WBX13A
        dr.Item("WBX13B") = ._WBX13B
        dr.Item("WBX13C") = ._WBX13C
        dr.Item("WCD12A") = ._WCD12A
        dr.Item("WCD12B") = ._WCD12B
        dr.Item("WCD12C") = ._WCD12C
        dr.Item("WCD12D") = ._WCD12D
        dr.Item("WCD14A") = Cnv14(._WCD14A)
        dr.Item("WCD14B") = Cnv14(._WCD14B)
        dr.Item("WCD14C") = Cnv14(._WCD14C)
        dr.Item("WCD14D") = Cnv14(._WCD14D)
        dr.Item("WCNTRL") = ._WCNTRL
        dr.Item("WDEPC") = ._WDEPC
        dr.Item("WEMAD1") = ._WEMAD1
        dr.Item("WEMAD2") = ._WEMAD2
        dr.Item("WEMAD3") = ._WEMAD3
        dr.Item("WEMFNM") = ._WEMFNM
        dr.Item("WEMLNM") = ._WEMLNM
        dr.Item("WEMPNO") = ._WEMPNO
        dr.Item("WEMSUF") = ._WEMSUF
        dr.Item("WERAD1") = ._WERAD1
        dr.Item("WERAD2") = ._WERAD2
        dr.Item("WERNAM") = ._WERNAM
        dr.Item("WFEDID") = ._WFEDID
        dr.Item("WFICGR") = ._WFICGR
        dr.Item("WFICTX") = ._WFICTX
        dr.Item("WFITGR") = ._WFITGR
        dr.Item("WFITTX") = ._WFITTX
        dr.Item("WLOGRS") = ._WLOGRS
        dr.Item("WLONAM") = ._WLONAM
        dr.Item("WLOTAX") = ._WLOTAX
        dr.Item("WMEDGR") = ._WMEDGR
        dr.Item("WMEDTX") = ._WMEDTX
        dr.Item("WNONQ") = ._WNONQ
        dr.Item("WSSN") = ._WSSN
        dr.Item("WSSTIP") = ._WSSTIP
        dr.Item("WSTATC") = ._WSTATC
        dr.Item("WSTATN") = ._WSTATNo
        dr.Item("WSTGRS") = ._WSTGRS
        dr.Item("WSTTAX") = ._WSTTAX
        ds.Tables(0).Rows.Add(dr)
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
    myW2PRINTQ.CloseFile()

  End Sub
  Private Function Cnv14(ByVal Code As String)

    Dim NewCode As String
    Select Case Trim(Code)
      Case "41"
        NewCode = "414H"
      Case Else
        NewCode = Code
    End Select

    Return NewCode

  End Function
End Module
