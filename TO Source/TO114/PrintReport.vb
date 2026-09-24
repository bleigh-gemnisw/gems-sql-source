Module PrintReport
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXMVDQ As TXMVDQ.MyData
  Dim myTXMVDCQ As TXMVDCQ.MyData
  Dim myTXSUPPQ As TXSUPPQ.MyData
  'MK 9/29/25 Begin
  Dim myTXSUPPCQ As TXSUPPCQ.MyData
  'MK 9/29/25 End
  Dim DsTXMVD As DataSet = New DataSet
  Dim DsTXSUPP As DataSet = New DataSet
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  'Mill Rate
  Public MrateMillrt As Double

  Dim WrkType As String
  Dim WrkYear As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkFrozenFile As Boolean
  Dim WrkPrintDist As Boolean
  Dim WrkTotRevLoss As Decimal

  Dim WrkExcd(4) As String
  Dim WrkExam(4) As Integer
  Dim cSelCode1 As String = "N"
  Dim cSelCode2 As String = "NBB"
  Dim cSelCode3 As String = "T"
  Public Sub PrtReport()

    myTXMVDQ = New TXMVDQ.MyData(myDBConnect)
    myTXMVDCQ = New TXMVDCQ.MyData(myDBConnect)
    myTXSUPPQ = New TXSUPPQ.MyData(myDBConnect)
    'MK 9/29/25 Begin
    myTXSUPPCQ = New TXSUPPCQ.MyData(myDBConnect)
    'MK 9/29/25 End

    With MyFrmTO114B
      WrkYear = .TxtGLYear.Text
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkFrozenFile = False
      If .ChkFrozenFile.Checked Then
        WrkFrozenFile = True
      End If
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    GetMillRate(WrkYear, "M", WrkDist)
    GetDetailMV()
    GetMillRate(WrkYear - 1, "S", WrkDist)
    GetDetailSU()

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
      .Columns.Add("typedesc", Type.GetType("System.String"))
      .Columns.Add("listno", Type.GetType("System.Int64"))
      .Columns.Add("addr1", Type.GetType("System.String"))
      .Columns.Add("addr2", Type.GetType("System.String"))
      .Columns.Add("addr3", Type.GetType("System.String"))
      .Columns.Add("addr4", Type.GetType("System.String"))
      .Columns.Add("addr5", Type.GetType("System.String"))
      .Columns.Add("exam", Type.GetType("System.Int64"))
      .Columns.Add("revloss", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetailMV()
    Dim AddrLine() As String
    Dim WrkCode As String
    Dim WrkCodeExam As Integer
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
    WrkQry = String.Empty
    If Not WrkDistAll Then
      WrkQry = "DIST=" & WrkDist
    End If
    If Not WrkFrozenFile Then
      DsTXMVD = myTXMVDQ.GetQry(WrkSort, WrkQry, 0)
    Else
      DsTXMVD = myTXMVDCQ.GetQry(WrkSort, WrkQry, 0)
    End If
    If DsTXMVD.Tables(0).Rows.Count = 0 Then Exit Sub

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "MOTOR VEHICLE"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsTXMVD.Tables(0).Rows.Count - 1)
      With DsTXMVD.Tables(0).Rows(I)
        WrkExcd(0) = .Item("excd1")
        WrkExcd(1) = .Item("excd2")
        WrkExcd(2) = .Item("excd3")
        WrkExcd(3) = .Item("excd4")
        WrkExcd(4) = .Item("excd5")
        WrkExam(0) = .Item("exam1")
        WrkExam(1) = .Item("exam2")
        WrkExam(2) = .Item("exam3")
        WrkExam(3) = .Item("exam4")
        WrkExam(4) = .Item("exam5")

        WrkCode = ""
        FindExemptions(WrkCode, WrkCodeExam)
        If WrkCode = "" Then GoTo NextRec

        dr = ds.Tables(0).NewRow
        dr.Item("typedesc") = WrkYear & " MOTOR VEHICLE"
        dr.Item("listno") = .Item("list#")
        AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"),
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
        dr.Item("addr1") = AddrLine(0)
        dr.Item("addr2") = AddrLine(1)
        dr.Item("addr3") = AddrLine(2)
        dr.Item("addr4") = AddrLine(3)
        dr.Item("addr5") = AddrLine(4)
        dr.Item("exam") = WrkCodeExam
        dr.Item("revloss") = MyUtils.Round(.Item("value") * MrateMillrt, 2)
        ds.Tables(0).Rows.Add(dr)
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsTXMVD.Tables(0).Rows.Count) * 100
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
    myTXMVDQ.CloseFile()
    myTXMVDCQ.CloseFile()

  End Sub
  Private Sub GetDetailSU()
    Dim AddrLine() As String
    Dim WrkCode As String
    Dim WrkCodeExam As Integer
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
    WrkQry = String.Empty
    If Not WrkDistAll Then
      WrkQry = "DIST=" & WrkDist
    End If
    'MK 9/29/25 Begin
    'DsTXSUPP = myTXSUPPQ.GetQry(WrkSort, WrkQry, 0)
    If Not WrkFrozenFile Then
      DsTXSUPP = myTXSUPPQ.GetQry(WrkSort, WrkQry, 0)
    Else
      DsTXSUPP = myTXSUPPCQ.GetQry(WrkSort, WrkQry, 0)
    End If
    'MK 9/29/25 End
    If DsTXSUPP.Tables(0).Rows.Count = 0 Then Exit Sub

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "SUPPL MV"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsTXSUPP.Tables(0).Rows.Count - 1)
      With DsTXSUPP.Tables(0).Rows(I)
        WrkExcd(0) = .Item("excd1")
        WrkExcd(1) = .Item("excd2")
        WrkExcd(2) = .Item("excd3")
        WrkExcd(3) = .Item("excd4")
        WrkExcd(4) = .Item("excd5")
        WrkExam(0) = .Item("exam1")
        WrkExam(1) = .Item("exam2")
        WrkExam(2) = .Item("exam3")
        WrkExam(3) = .Item("exam4")
        WrkExam(4) = .Item("exam5")
        WrkCode = ""
        FindExemptions(WrkCode, WrkCodeExam)
        If WrkCode = "" Then GoTo NextRec

        dr = ds.Tables(0).NewRow
        dr.Item("typedesc") = (WrkYear - 1) & " SUPPLEMENTAL MV"
        dr.Item("listno") = .Item("list#")
        AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"),
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
        dr.Item("addr1") = AddrLine(0)
        dr.Item("addr2") = AddrLine(1)
        dr.Item("addr3") = AddrLine(2)
        dr.Item("addr4") = AddrLine(3)
        dr.Item("addr5") = AddrLine(4)
        dr.Item("exam") = WrkCodeExam
        dr.Item("revloss") = MyUtils.Round(.Item("value") * MrateMillrt, 2)
        ds.Tables(0).Rows.Add(dr)
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
    'myTXSUPPQ.CloseFile()

  End Sub
  Public Sub GetMillRate(ByVal WrkGLYear As Integer, ByVal WrkType As String, ByVal WrkDist As Integer)
    Dim myTXMRATE As TXMRATE.MyData

    myTXMRATE = New TXMRATE.MyData(myDBConnect)
    myTXMRATE.GetOneRecordP(WrkGLYear, WrkType, WrkDist)
    If myTXMRATE.RecordNotFound Then
      myTXMRATE.GetOneRecordP(WrkGLYear, "", WrkDist)
    End If
    If Not myTXMRATE.RecordNotFound Then
      With myTXMRATE
        MrateMillrt = ._MRRATE
      End With
    End If
    myTXMRATE.CloseFile()
  End Sub
  Private Sub FindExemptions(ByRef WrkCode As String, ByRef WrkCodeExam As Integer)
    Dim I As Integer

    WrkCode = ""
    WrkCodeExam = 0

    For I = 0 To WrkExcd.GetUpperBound(0)
      If WrkExcd(I) = cSelCode1 Or WrkExcd(I) = cSelCode2 Or Mid(WrkExcd(I), 1, 1) = cSelCode3 Then
        If WrkCode = String.Empty Then
          WrkCode = WrkExcd(I)
          WrkCodeExam = WrkExam(I)
        Else
          WrkCodeExam = WrkCodeExam + WrkExam(I)
        End If
      End If
    Next

  End Sub
End Module






