Module PrintReport
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXSUPPQ As TXSUPPQ.MyData
  Dim myTXINV As TXINV.MyData
  Dim DsTXSUPP As DataSet = New DataSet
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkYear As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean

  Public Sub PrtReport()

    myTXSUPPQ = New TXSUPPQ.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)

    With MyFrmTA521B
      WrkYear = MyUtils.CnvSng(.TxtGLYear.Text)
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    GetDetail()

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .Show()
    End With
  End Sub
  Friend Sub BuildDS()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("listno", Type.GetType("System.Int64"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("class", Type.GetType("System.Int32"))
      .Columns.Add("regno", Type.GetType("System.String"))
      .Columns.Add("olist", Type.GetType("System.Int64"))
      .Columns.Add("gross", Type.GetType("System.Int64"))
      .Columns.Add("ccno", Type.GetType("System.Int64"))
      .Columns.Add("ccdate", Type.GetType("System.DateTime"))
      .Columns.Add("ccgross", Type.GetType("System.Int64"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkSort As String
    Dim WrkQry As String
    Dim I As Integer
    Dim WrkAnd As String
    Dim WrkOr As String

    If myDBConnect.ServerAS400 Then
      WrkOr = " *or "
      WrkAnd = " *and "
    Else
      WrkOr = " or "
      WrkAnd = " and "
    End If

    WrkSort = "LIST#"
    WrkQry = "OLIST > 0"
    If Not WrkDistAll Then
      WrkQry = "dist=" & WrkDist
    End If
    DsTXSUPP = myTXSUPPQ.GetQry(WrkSort, WrkQry, 0)

    If DsTXSUPP.Tables(0).Rows.Count = 0 Then Exit Sub

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsTXSUPP.Tables(0).Rows.Count - 1)
      With DsTXSUPP.Tables(0).Rows(I)
        myTXINV.GetOneRecordP(.Item("olist"), WrkYear, "M")
        If Not myTXINV.RecordNotFound Then
          If Trim(myTXINV._IMVREG) = Trim(.Item("oreg#")) And myTXINV._CCNO > 0 Then
            dr = ds.Tables(0).NewRow
            dr.Item("listno") = .Item("list#")
            dr.Item("name") = .Item("name")
            dr.Item("class") = .Item("class")
            dr.Item("regno") = .Item("oreg#")
            dr.Item("gross") = .Item("value")
            dr.Item("olist") = .Item("olist")
            dr.Item("ccno") = myTXINV._CCNO
            dr.Item("ccdate") = MyUtils.GetDBDate(myTXINV._CDATE)
            dr.Item("ccgross") = myTXINV._CGRS
            ds.Tables(0).Rows.Add(dr)
          End If
        End If
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsTXSUPP.Tables(0).Rows.Count) * 100
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
    myTXSUPPQ.CloseFile()

  End Sub
End Module






