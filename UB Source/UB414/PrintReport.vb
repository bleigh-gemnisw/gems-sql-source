Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myUTCUSTQ As UTCUSTQ.MyData
  Dim myUTCUSTRT As UTCUSTRT.MyData
  Dim myUTCUSTMT As UTCUSTMT.MyData
  Dim myUTCUSTMTD As UTCUSTMTD.MyData
  Dim ds As DataSet = New DataSet
  Dim DsUTCUST As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkType As String
  Dim WrkRoute As String
  Dim WrkBaseDate As Integer
  Dim WrkUsageDate As Integer
  Dim WrkPostDate As Integer
  Dim WrkRemoveDate As Integer
  Dim WrkEstimate As Boolean
  Dim WrkUsageSame As Boolean
  Dim WrkPost As Boolean
  Dim WrkUBType As String

  Public Sub PrtReport()
    Dim WrkTypeDesc As String

    myUTCUSTQ = New UTCUSTQ.MyData(myDBConnect)
    myUTCUSTRT = New UTCUSTRT.MyData(myDBConnect)
    myUTCUSTMT = New UTCUSTMT.MyData(myDBConnect)
    myUTCUSTMTD = New UTCUSTMTD.MyData(myDBConnect)

    With MyFrmUB414B
      WrkType = .TxtType.Text
      WrkRoute = .TxtRoute.Text
      WrkEstimate = .RbEstimate.Checked
      WrkBaseDate = MyUtils.SetDBDate(.DtPckBase.Value)
      WrkUsageDate = MyUtils.SetDBDate(.DtPckUsage.Value)
      WrkPostDate = MyUtils.SetDBDate(.DtPckPost.Value)
      WrkRemoveDate = MyUtils.SetDBDate(.DtPckRemove.Value)
      WrkUsageSame = .ChkUsageSame.Checked
      WrkPost = .ChkPost.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    GetDetail()

Done:
    WrkTypeDesc = GetUTTypeDesc(WrkType)

    MyCrViewer = New FrmCrViewer
    MyCrViewer.Wrkds = ds
    MyCrViewer.WrkTypeDesc = WrkTypeDesc
    MyCrViewer.Show()

  End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Base", Type.GetType("System.Int32"))
      .Columns.Add("Usage", Type.GetType("System.Int32"))
      .Columns.Add("Estimate", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub GetDetail()

    Dim WrkListNo As Integer
    Dim WrkBaseRead As Long
    Dim WrkUsage As Long
    Dim WrkEstimateRead As Integer
    Dim WrkFlds As String
    Dim WrkQry As String
    Dim I As Integer
    Dim WrkAnd As String

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = ""
    If WrkRoute <> String.Empty Then
      WrkQry = "curout=" & MyUtils.Quo(WrkRoute)
    End If
    WrkFlds = "CUNAM1, CUACCT"

    DsUTCUST = myUTCUSTQ.GetQry(WrkFlds, WrkQry, 0)
    If DsUTCUST.Tables(0).Rows.Count = 0 Then GoTo CloseFiles
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkUBType = GetUTTypeUBType(WrkType)

    For I = 0 To (DsUTCUST.Tables(0).Rows.Count - 1)
      With DsUTCUST.Tables(0).Rows(I)
        WrkListNo = .Item("cuacct")
        WrkBaseRead = 0
        WrkUsage = 0
        WrkEstimateRead = 0
        If WrkEstimate Then
          myUTCUSTMT.GetOneRecordP(WrkListNo, WrkType, WrkBaseDate)
          If Not myUTCUSTMT.RecordNotFound Then
            WrkBaseRead = myUTCUSTMT._CMREAD
          End If
          myUTCUSTMT.GetOneRecordP(WrkListNo, WrkType, WrkUsageDate)
          If Not myUTCUSTMT.RecordNotFound Then
            WrkUsage = myUTCUSTMT._CMUSE
          End If
        Else
          myUTCUSTMT.GetOneRecordP(WrkListNo, WrkType, WrkRemoveDate)
          If Not myUTCUSTMT.RecordNotFound Then
            WrkBaseRead = myUTCUSTMT._CMREAD
          End If
        End If
        If myUTCUSTMT.RecordNotFound Then GoTo NextRec

          dr = ds.Tables(0).NewRow
        dr.Item("listno") = WrkListNo
        dr.Item("name") = .Item("cunam1")
        dr.Item("base") = WrkBaseRead
        dr.Item("usage") = WrkUsage
        If WrkUsageSame Then
          WrkEstimateRead = WrkUsage
        Else
          If WrkEstimate Then
            WrkEstimateRead = WrkBaseRead + WrkUsage
          Else
            WrkEstimateRead = WrkBaseRead
          End If
        End If
        dr.Item("estimate") = WrkEstimateRead
      End With
      If WrkPost Then
        If WrkEstimate Then
          With myUTCUSTMT
            .GetOneRecordP(WrkListNo, WrkType, WrkPostDate)
            If Not myUTCUSTMT.RecordNotFound Then
              MsgBox("Records have already been posted to " & MyFrmUB414B.DtPckPost.Value, MsgBoxStyle.Critical, "Aborting program")
              GoTo Closeit
            End If
            ._CMACCT = WrkListNo
            ._CMTYPE = WrkType
            ._CMDATE = WrkPostDate
            ._CMREAD = WrkEstimateRead
            ._CMUSE = WrkUsage
            .AddOneRecordP()
          End With
        Else
          With myUTCUSTMT
            .GetOneRecordP(WrkListNo, WrkType, WrkRemoveDate)
            If Not .RecordNotFound Then
              .DeleteOneRecordP()
            End If
          End With
          With myUTCUSTMTD
            .DeleteListNoDate(WrkListNo, WrkRemoveDate)
          End With
        End If
      End If
      ds.Tables(0).Rows.Add(dr)

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsUTCUST.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

Closeit:
    myFrmProgress.Close()

CloseFiles:
    myUTCUSTQ.CloseFile()

  End Sub

End Module






