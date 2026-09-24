Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myUTCUSTQ As UTCUSTQ.MyData
  Dim myUTCUSTMTD As UTCUSTMTD.myData
  Dim myUTCUSTRT As UTCUSTRT.MyData
  Dim myUTXREF As UTXREF.MyData

  Dim ds As DataSet = New DataSet
  Dim DsUTCUST As DataSet = New DataSet
  Dim dr As Data.DataRow

  'Screen fields
  Dim WrkYear As Integer
  Dim WrkDist As Integer
  Dim WrkPhase As Integer
  Dim WrkRoute As String
  Dim WrkSortBy As String
  Dim WrkFromDate As Date
  Dim WrkToDate As Date

  'Common Work fields
  Dim WrkListNo As Integer
  Dim WrkTaxType As String
  Dim WrkUBType As String
  Dim WrkBillDesc As String
  Dim WrkFamily As String
  Dim WrkRateCode As String
  Dim WrkCode As String
  Dim WrkSize As String
  Dim WrkReason As String

  Public Sub PrtReport()
    myUTCUSTQ = New UTCUSTQ.MyData(myDBConnect)
    myUTCUSTMTD = New UTCUSTMTD.MyData(myDBConnect)
    myUTCUSTRT = New UTCUSTRT.MyData(myDBConnect)
    myUTXREF = New UTXREF.MyData(myDBConnect)

    With MyFrmUB236B
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
      WrkUBType = .TxtType.Text
      WrkFromDate = .DtPckFrom.Value
      WrkToDate = .DtPckTo.Value
      If .RbSortList.Checked Then
        WrkSortBy = "List"
      End If
      If .RbSortName.Checked Then
        WrkSortBy = "Name"
      End If
      If .RbSortLocation.Checked Then
        WrkSortBy = "Location"
      End If
      WrkListNo = MyUtils.CnvSng(.TxtListNo.Text)
      WrkCode = .TxtCode.Text
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .WrkUBType = WrkUBType
      Select Case WrkSortBy
        Case "List"
          .Wrksort = "By Account"
        Case "Name"
          .Wrksort = "By Name"
        Case "Location"
          .Wrksort = "By Location"
      End Select
      .Wrkdistphase = "District / Phase " + WrkDist.ToString + " / " + WrkPhase.ToString
      .Show()
    End With
  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("SortData", Type.GetType("System.String"))
      .Columns.Add("RptID", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("MeterUse", Type.GetType("System.Int64"))
      .Columns.Add("MeterRead", Type.GetType("System.Int64"))
      .Columns.Add("EDU", Type.GetType("System.Decimal"))
      .Columns.Add("CmXref", Type.GetType("System.String"))
      .Columns.Add("Cmdesc1", Type.GetType("System.String"))
      .Columns.Add("Cmdesc2", Type.GetType("System.String"))
      .Columns.Add("CmUse", Type.GetType("System.Int64"))
      .Columns.Add("CmRead", Type.GetType("System.Int64"))
      .Columns.Add("XrefEDU", Type.GetType("System.Decimal"))
      .Columns.Add("XrefPct", Type.GetType("System.Decimal"))
      .Columns.Add("UseDesc", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub

  Private Sub GetDetail()
    Dim ds2 As DataSet = New DataSet
    Dim WrkQry As String
    Dim WrkSort As String
    Dim SaveListNo As Integer
    Dim SaveType As String
    Dim SaveXREF As String
    Dim SaveUse As String
    Dim SaveEDU As Decimal
    Dim SaveDesc1 As String
    Dim SaveDesc2 As String
    Dim WrkListCMUse As Integer
    Dim WrkListCMRead As Integer
    Dim WrkXrefEDU As Decimal
    Dim WrkCMUse As Integer
    Dim WrkCMRead As Integer
    Dim Addrline() As String
    Dim Counter As Integer
    Dim J As Integer
    Dim WrkAnd As String

    WrkFamily = GetUTTYPEFamily(WrkUBType)

    If MyServer = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = ""
    WrkSort = ""
    SaveListNo = 0
    SaveUse = ""
    SaveEDU = 0
    SaveType = ""
    SaveXREF = ""
    SaveDesc1 = ""
    SaveDesc2 = ""
    Counter = 0
    If WrkDist > 0 Then
      WrkQry = "cudst=" & WrkDist & WrkAnd & "cuphas=" & WrkPhase
    End If
    If WrkListNo > 0 Then
      If WrkQry = "" Then
        WrkQry = "cuacct=" & WrkListNo
      Else
        WrkQry = WrkQry & WrkAnd & "cuacct=" & WrkListNo
      End If
    End If
    myUTCUSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myUTCUSTQ.ReadQry()
    If Not myUTCUSTQ.IsEOF Then
      With myUTCUSTQ
        Counter = Counter + 1
        WrkListNo = ._CUACCT
        WrkRateCode = GetRateCode(WrkUBType)
        If WrkRateCode = "" Then GoTo NextRec

        If WrkCode <> String.Empty Then
          If WrkCode <> WrkRateCode Then
            GoTo NextRec
          End If
        End If

        Select Case WrkFamily
          Case "M"
          Case Else
            GoTo NextRec
        End Select

        ds2 = myUTCUSTMTD.GetAllListNo(WrkListNo, WrkUBType, "", MyUtils.SetDBDate(WrkFromDate), MyUtils.SetDBDate(WrkToDate))
        If ds2.Tables(0).Rows.Count = 0 Then
          ds2 = myUTCUSTMTD.GetAllListNo(WrkListNo, "", "", MyUtils.SetDBDate(WrkFromDate), MyUtils.SetDBDate(WrkToDate))
        End If
        For J = 0 To (ds2.Tables(0).Rows.Count - 1)
          '          If MyUtils.GetDBDate(ds2.Tables(0).Rows(J).Item("cmdate")) < WrkFromDate Then Continue For
          If SaveXREF <> "" And SaveXREF <> Trim(ds2.Tables(0).Rows(J).Item("cmxref")) Then
            'Report
            dr = ds.Tables(0).NewRow
            Select Case WrkSortBy
              Case "List"
                dr.Item("sortdata") = Format(SaveListNo, "000000")
              Case "Name"
                dr.Item("sortdata") = Addrline(0)
            End Select
            dr.Item("rptid") = "B"
            dr.Item("listno") = SaveListNo
            dr.Item("addr1") = Addrline(0)
            dr.Item("addr2") = Addrline(1)
            dr.Item("addr3") = Addrline(2)
            dr.Item("addr4") = Addrline(3)
            dr.Item("addr5") = Addrline(4)
            dr.Item("meteruse") = 0
            dr.Item("meterread") = 0
            dr.Item("EDU") = 0
            dr.Item("cmxref") = SaveXREF
            dr.Item("cmdesc1") = SaveDesc1
            dr.Item("cmdesc2") = SaveDesc2
            dr.Item("cmread") = WrkCMRead
            dr.Item("cmuse") = WrkCMUse
            WrkXrefEDU = Math.Round(WrkCMUse / 76.65, 2)
            dr.Item("XrefEDU") = WrkXrefEDU
            dr.Item("XrefPct") = 0
            myUTXREF.GetOneRecordP(WrkListNo, SaveType, SaveXREF)
            dr.Item("usedesc") = Trim(myUTXREF._CXUSE)
            ds.Tables(0).Rows.Add(dr)
            WrkCMUse = 0
            WrkCMRead = 0
          End If
          If SaveListNo > 0 And SaveListNo <> WrkListNo Then
            dr = ds.Tables(0).NewRow
            Select Case WrkSortBy
              Case "List"
                dr.Item("sortdata") = Format(SaveListNo, "000000")
              Case "Name"
                dr.Item("sortdata") = Trim(._CUNAM1)
            End Select
            dr.Item("rptid") = "A"
            dr.Item("listno") = SaveListNo
            dr.Item("addr1") = Addrline(0)
            dr.Item("addr2") = Addrline(1)
            dr.Item("addr3") = Addrline(2)
            dr.Item("addr4") = Addrline(3)
            dr.Item("addr5") = Addrline(4)
            dr.Item("meteruse") = WrkListCMUse
            dr.Item("meterread") = WrkListCMRead
            dr.Item("EDU") = SaveEDU
            dr.Item("cmxref") = ""
            dr.Item("cmdesc1") = ""
            dr.Item("cmdesc2") = ""
            dr.Item("cmuse") = 0
            dr.Item("cmread") = 0
            dr.Item("XrefEDU") = 0
            dr.Item("XrefPct") = 0
            dr.Item("usedesc") = ""
            ds.Tables(0).Rows.Add(dr)
            WrkListCMUse = 0
            WrkListCMRead = 0
          End If
          If Trim(._CUMAD1) <> "" Then
            Addrline = MyUtils.SetAddrLine(._CUNAM1, ._CUNAM2, ._CUMAD1, ._CUMAD2, ._CUMCTY, ._CUMST, 0, 0, ._CUMZIP)
          Else
            Addrline = MyUtils.SetAddrLine(._CUNAM1, ._CUNAM2, ._CUADD1, ._CUADD2, ._CUCITY, ._CUST, 0, 0, ._CUZIP)
          End If
          SaveListNo = WrkListNo
          SaveType = Trim(ds2.Tables(0).Rows(J).Item("cmtype"))
          SaveXREF = Trim(ds2.Tables(0).Rows(J).Item("cmxref"))
          SaveEDU = ._CUEDU
          SaveUse = Trim(ds2.Tables(0).Rows(J).Item("cmresn"))
          SaveDesc1 = Trim(ds2.Tables(0).Rows(J).Item("cmdesc1"))
          SaveDesc2 = Trim(ds2.Tables(0).Rows(J).Item("cmdesc2"))
          WrkCMUse = WrkCMUse + ds2.Tables(0).Rows(J).Item("cmuse")
          WrkCMRead = WrkCMRead + ds2.Tables(0).Rows(J).Item("cmread")
          WrkListCMUse = WrkListCMUse + ds2.Tables(0).Rows(J).Item("cmuse")
          WrkListCMRead = WrkListCMRead + ds2.Tables(0).Rows(J).Item("cmread")
        Next
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

    'Write last xref and account
    With myUTCUSTQ
      If Trim(._CUMAD1) <> "" Then
        Addrline = MyUtils.SetAddrLine(._CUNAM1, ._CUNAM2, ._CUMAD1, ._CUMAD2, ._CUMCTY, ._CUMST, 0, 0, ._CUMZIP)
      Else
        Addrline = MyUtils.SetAddrLine(._CUNAM1, ._CUNAM2, ._CUADD1, ._CUADD2, ._CUCITY, ._CUST, 0, 0, ._CUZIP)
      End If
      dr = ds.Tables(0).NewRow
      Select Case WrkSortBy
        Case "List"
          dr.Item("sortdata") = Format(SaveListNo, "000000")
        Case "Name"
          dr.Item("sortdata") = Addrline(0)
      End Select

      dr.Item("rptid") = "B"
      dr.Item("listno") = SaveListNo
      dr.Item("addr1") = Addrline(0)
      dr.Item("addr2") = Addrline(1)
      dr.Item("addr3") = Addrline(2)
      dr.Item("addr4") = Addrline(3)
      dr.Item("addr5") = Addrline(4)
      dr.Item("meteruse") = 0
      dr.Item("meterread") = 0
      dr.Item("EDU") = 0
      dr.Item("cmxref") = SaveXREF
      dr.Item("cmdesc1") = SaveDesc1
      dr.Item("cmdesc2") = SaveDesc2
      dr.Item("cmuse") = WrkCMUse
      dr.Item("cmread") = WrkCMRead
      WrkXrefEDU = Math.Round(WrkCMUse / 76.65, 2)
      dr.Item("XrefEDU") = WrkXrefEDU
      dr.Item("XrefPct") = 0
      myUTXREF.GetOneRecordP(SaveListNo, SaveType, SaveXREF)
      dr.Item("usedesc") = Trim(myUTXREF._CXUSE)
      ds.Tables(0).Rows.Add(dr)

      dr = ds.Tables(0).NewRow
      Select Case WrkSortBy
        Case "List"
          dr.Item("sortdata") = Format(SaveListNo, "000000")
        Case "Name"
          dr.Item("sortdata") = Trim(._CUNAM1)
      End Select
      dr.Item("rptid") = "A"
      dr.Item("listno") = SaveListNo
      dr.Item("addr1") = Addrline(0)
      dr.Item("addr2") = Addrline(1)
      dr.Item("addr3") = Addrline(2)
      dr.Item("addr4") = Addrline(3)
      dr.Item("addr5") = Addrline(4)
      dr.Item("meteruse") = WrkListCMUse
      dr.Item("meterread") = WrkListCMRead
      dr.Item("EDU") = SaveEDU
      dr.Item("cmxref") = ""
      dr.Item("cmdesc1") = ""
      dr.Item("cmdesc2") = ""
      dr.Item("cmuse") = 0
      dr.Item("cmread") = 0
      dr.Item("XrefEDU") = 0
      dr.Item("XrefPct") = 0
      dr.Item("usedesc") = ""
      ds.Tables(0).Rows.Add(dr)
    End With

    myFrmProgress.Close()
    myUTCUSTQ.CloseFile()
  End Sub
  Private Function GetRateCode(ByVal WrkUBType As String) As String
    GetRateCode = ""
    myUTCUSTRT.GetOneRecordP(WrkListNo, WrkUBType)
    If myUTCUSTRT.RecordNotFound Then Exit Function

    With myUTCUSTRT
      GetRateCode = ._CRCODE
    End With
  End Function

End Module
