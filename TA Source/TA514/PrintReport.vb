Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXSUPPQ As TXSUPPQ.MyData
  Dim ds As DataSet = New DataSet
  Dim dsCR As DataSet = New DataSet
  Dim dsVIN As DataSet = New DataSet
  Dim DsTXSUPP As DataSet = New DataSet
  Dim DsTXSUPPCR As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkAnd As String
  Dim WrkOr As String

  Public Sub PrtReport()

    myTXSUPPQ = New TXSUPPQ.MyData(myDBConnect)

    With MyFrmTA514B
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
      dsCR = ds.Clone
      dsVIN = ds.Clone
    Else
      ds.Clear()
      dsCR.Clear()
      dsVIN.Clear()
      ClearTotals()
    End If

    GetDetail()
    GetDetailCR()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.wrkdsCR = dsCR
    MyCrViewer.wrkdsVIN = dsVIN
    MyCrViewer.Show()

  End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Vinno", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Regno", Type.GetType("System.String"))
      .Columns.Add("Ass", Type.GetType("System.String"))
      .Columns.Add("Class", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Make", Type.GetType("System.String"))
      .Columns.Add("Model", Type.GetType("System.String"))
      .Columns.Add("OList", Type.GetType("System.Int32"))
      .Columns.Add("OName", Type.GetType("System.String"))
      .Columns.Add("OReg", Type.GetType("System.String"))
      .Columns.Add("OAss", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub ClearTotals()
  End Sub
  Private Sub GetDetail()
    Dim WrkSort As String
    Dim WrkQry As String
    Dim I As Integer
    Dim NextVIN As String
    Dim Good As Boolean

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkQry = ""

    WrkSort = "VINNO"
    DsTXSUPP = myTXSUPPQ.GetQry(WrkSort, WrkQry, 0)
    If DsTXSUPP.Tables(0).Rows.Count = 0 Then GoTo CloseFiles
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    NextVIN = ""
    For I = 0 To (DsTXSUPP.Tables(0).Rows.Count - 1)
      With DsTXSUPP.Tables(0).Rows(I)
        If I <> (DsTXSUPP.Tables(0).Rows.Count - 1) Then
          NextVIN = Trim(DsTXSUPP.Tables(0).Rows(I + 1).Item("vinno"))
        Else
          NextVIN = ""
        End If
        If Trim(.Item("vinno")) = NextVIN Or Good Then
          Good = False
          dr = ds.Tables(0).NewRow
          dr.Item("listno") = .Item("list#")
          dr.Item("vinno") = .Item("vinno")
          dr.Item("name") = .Item("name")
          dr.Item("regno") = .Item("regno")
          dr.Item("ass") = .Item("ass")
          dr.Item("class") = .Item("class")
          dr.Item("year") = .Item("year")
          dr.Item("make") = .Item("make")
          dr.Item("model") = .Item("model")
          ds.Tables(0).Rows.Add(dr)
          If Trim(.Item("vinno")) = NextVIN Then Good = True
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

CloseFiles:
    myTXSUPPQ.CloseFile()

  End Sub
  Private Sub GetDetailCR()
    Dim WrkSort As String
    Dim WrkQry As String
    Dim I As Integer
    Dim NextVIN As String
    Dim Good As Boolean

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkQry = ""
    WrkSort = "OVIN"
    DsTXSUPPCR = myTXSUPPQ.GetQry(WrkSort, WrkQry, 0)
    If DsTXSUPPCR.Tables(0).Rows.Count = 0 Then GoTo CloseFiles
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    NextVIN = ""
    For I = 0 To (DsTXSUPPCR.Tables(0).Rows.Count - 1)
      With DsTXSUPPCR.Tables(0).Rows(I)
        If Trim(.Item("ovin")) = "" Then GoTo NextRec
        If I <> (DsTXSUPPCR.Tables(0).Rows.Count - 1) Then
          NextVIN = Trim(DsTXSUPPCR.Tables(0).Rows(I + 1).Item("ovin"))
        Else
          NextVIN = ""
        End If
        If Trim(.Item("ovin")) = NextVIN Or Good Then
          Good = False
          dr = dsCR.Tables(0).NewRow
          dr.Item("listno") = .Item("list#")
          dr.Item("vinno") = .Item("ovin")
          dr.Item("name") = .Item("name")
          dr.Item("regno") = .Item("oreg#")
          dr.Item("ass") = .Item("ass")
          dr.Item("class") = .Item("ocls")
          dr.Item("year") = .Item("oyear")
          dr.Item("make") = .Item("omake")
          dr.Item("model") = .Item("omod")
          dsCR.Tables(0).Rows.Add(dr)
          If Trim(.Item("ovin")) = NextVIN Then Good = True
        End If
        CheckVIN(I, Trim(.Item("ovin")))
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

CloseFiles:
    myTXSUPPQ.CloseFile()

  End Sub
  Private Sub CheckVIN(I As Integer, WrkVIN As String)
    Dim WrkSelect As String
    Dim drSel() As DataRow

    WrkSelect = "vinno=" & MyUtils.Quo(WrkVIN)
    drSel = DsTXSUPP.Tables(0).Select(WrkSelect)
    If drSel.GetUpperBound(0) >= 0 Then
      With drSel(0)
        dr = dsVIN.Tables(0).NewRow
        dr.Item("listno") = .Item("list#")
        dr.Item("vinno") = .Item("vinno")
        dr.Item("name") = .Item("name")
        dr.Item("regno") = .Item("regno")
        dr.Item("ass") = .Item("ass")
        dr.Item("class") = .Item("class")
        dr.Item("year") = .Item("year")
        dr.Item("make") = .Item("make")
        dr.Item("model") = .Item("model")
      End With
      With DsTXSUPPCR.Tables(0).Rows(I)
        dr.Item("olist") = .Item("list#")
        dr.Item("oname") = .Item("name")
        dr.Item("oreg") = .Item("oreg#")
        dr.Item("oass") = .Item("oass")
      End With
      dsVIN.Tables(0).Rows.Add(dr)

    End If
  End Sub
End Module






