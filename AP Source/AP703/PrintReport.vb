Module PrintReport
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myAP1099PQ As AP1099PQ.MyData
  Dim myVENDOR As VENDOR.MyData
  Dim ds As DataSet = New DataSet
  Dim dsMisc As DataSet = New DataSet
  Dim dsNec As DataSet = New DataSet
  Dim WrkCopyB As Boolean
  Public Sub PrtReport()

    myAP1099PQ = New AP1099PQ.MyData()
    myAP1099PQ.MyDBConn = myDBConnect
    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect

    With MyFrmAP703B
      WrkCopyB = .RbCopyB.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
      dsMisc = ds.Clone
      dsNec = ds.Clone
    Else
      ds.Clear()
      dsNec.Clear()
      dsMisc.Clear()
    End If

    If WrkCopyB Then
      GetDetail()
    End If

    ds.Merge(dsNec)
    ds.Merge(dsMisc)

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .wrkdsNec = dsNec
      .wrkdsMisc = dsMisc
      .WrkCopyB = WrkCopyB
      .Show()
    End With
  End Sub
  Friend Sub BuildDS()
    Dim myTable As New DataTable

    With myTable
      .TableName = "AP1099P"
      .Columns.Add("afedid", Type.GetType("System.String"))
      .Columns.Add("amisam", Type.GetType("System.Decimal"))
      .Columns.Add("arents", Type.GetType("System.Decimal"))
      .Columns.Add("aother", Type.GetType("System.Decimal"))
      .Columns.Add("apadr1", Type.GetType("System.String"))
      .Columns.Add("apadr2", Type.GetType("System.String"))
      .Columns.Add("apadr3", Type.GetType("System.String"))
      .Columns.Add("apname", Type.GetType("System.String"))
      .Columns.Add("apphon", Type.GetType("System.String"))
      .Columns.Add("aracct", Type.GetType("System.String"))
      .Columns.Add("aradr1", Type.GetType("System.String"))
      .Columns.Add("aradr2", Type.GetType("System.String"))
      .Columns.Add("aradr3", Type.GetType("System.String"))
      .Columns.Add("aradr4", Type.GetType("System.String"))
      .Columns.Add("arname", Type.GetType("System.String"))
      .Columns.Add("astcde", Type.GetType("System.String"))
      .Columns.Add("asteid", Type.GetType("System.String"))
      .Columns.Add("ataxid", Type.GetType("System.String"))
      .Columns.Add("ayear", Type.GetType("System.Int16"))
      .Columns.Add("aform", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim Counter As Integer
    Dim WrkMisc As Boolean

    If myDBConnect.ServerAS400 Then
      WrkOr = " *or "
      WrkAnd = " *and "
    Else
      WrkOr = " or "
      WrkAnd = " and "
    End If

    WrkSort = "ARNAME"
    WrkQry = ""
    Counter = 0

    myAP1099PQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myAP1099PQ.ReadQry()
    Dim dr As Data.DataRow
    If Not myAP1099PQ.IsEOF Then
      With myAP1099PQ
        myVENDOR.GetOneRecordP(Trim(._ARACCT))
        If Not myVENDOR.RecordNotFound Then
          If myVENDOR._FEMCD = "Y" Or myVENDOR._MINCD = "Y" Then
            dr = dsMisc.Tables(0).NewRow
          Else
            dr = dsNec.Tables(0).NewRow
          End If
        Else
          dr = ds.Tables(0).NewRow
        End If
        Counter = Counter + 1
        WrkMisc = False
        dr.Item("AFEDID") = ._AFEDID
        dr.Item("AMISAM") = 0
        dr.Item("ARENTS") = 0
        If Not myVENDOR.RecordNotFound Then
          If myVENDOR._FEMCD = "Y" Then
            dr.Item("ARENTS") = ._AMISAM
            WrkMisc = True
          End If
          If myVENDOR._MINCD = "Y" Then
            dr.Item("AOTHER") = ._AMISAM
            WrkMisc = True
          End If
        End If
        If Not WrkMisc Then
          dr.Item("AMISAM") = ._AMISAM
        End If
        dr.Item("APADR1") = ._APADR1
        dr.Item("APADR2") = ._APADR2
        dr.Item("APADR3") = ._APADR3
        dr.Item("APNAME") = ._APNAME
        dr.Item("APPHON") = ._APPHON
        dr.Item("ARACCT") = ._ARACCT
        dr.Item("ARADR1") = ._ARADR1
        dr.Item("ARADR2") = ._ARADR2
        dr.Item("ARADR3") = ._ARADR3
        dr.Item("ARADR4") = ._ARADR4
        dr.Item("ARNAME") = ._ARNAME
        dr.Item("ASTCDE") = ._ASTCDE
        dr.Item("ASTEID") = ._ASTEID
        dr.Item("ATAXID") = ._ATAXID
        dr.Item("AYEAR") = ._AYEAR
        If Not myVENDOR.RecordNotFound Then
          If WrkMisc Then
            dr.Item("AFORM") = "MISC"
            dsMisc.Tables(0).Rows.Add(dr)
          Else
            dr.Item("AFORM") = "NEC"
            dsNec.Tables(0).Rows.Add(dr)
          End If
        Else
          dr.Item("AFORM") = "*ERR*"
          ds.Tables(0).Rows.Add(dr)
        End If
        dr = Nothing
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
    myAP1099PQ.CloseFile()

  End Sub
End Module
