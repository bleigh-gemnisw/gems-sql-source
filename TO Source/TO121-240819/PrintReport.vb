Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Text
Module PrintReport
  Dim myTXREALQ As TXREALQ.MyData
  Dim myTXREALCQ As TXREALCQ.MyData
  Dim myTXPPRPQ As TXPPRPQ.MyData
  Dim myTXPPRPCQ As TXPPRPCQ.MyData
  Dim myTXOPM As TXOPM.MyData
  Dim DsFile As DataSet = New DataSet
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  'Mill Rate
  Public MrateMillrt As Decimal

  Dim WrkType As String
  Dim WrkYear As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkFrozenFile As Boolean
  Dim WrkPrintDist As Boolean
  Dim WrkTown As String
  Dim WrkExcd(6) As String
  Dim WrkExam(6) As Integer
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim cSelCode1 As String = "GAB"
  Dim cSelCode2 As String = "GEB"
  'Globals
  Public WrkCert As String
  Public WrkAccts As Integer
  Public WrkNumExem As Decimal
  Public WrkRELoss As Decimal
  Public WrkPPLoss As Decimal
  Public Sub PrtReport()

    myTXREALQ = New TXREALQ.MyData(myDBConnect)
    myTXREALCQ = New TXREALCQ.MyData(myDBConnect)
    myTXPPRPQ = New TXPPRPQ.MyData(myDBConnect)
    myTXPPRPCQ = New TXPPRPCQ.MyData(myDBConnect)
    myTXOPM = New TXOPM.MyData(myDBConnect)

    With MyFrmTO121B
      WrkYear = MyUtils.CnvSng(.TxtGLYear.Text)
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

    WrkAccts = 0
    WrkNumExem = 0
    WrkRELoss = 0
    WrkPPLoss = 0
    GetOPMAssr()
    GetMillRate(WrkYear, "R", WrkDist)
    GetDetailRE()
    GetDetailPP()

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .WrkMillRt = MrateMillrt * 1000
      .Show()
    End With
  End Sub
  Friend Sub BuildDS()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("listno", Type.GetType("System.Int32"))
      .Columns.Add("typedesc", Type.GetType("System.String"))
      .Columns.Add("addr1", Type.GetType("System.String"))
      .Columns.Add("addr2", Type.GetType("System.String"))
      .Columns.Add("addr3", Type.GetType("System.String"))
      .Columns.Add("addr4", Type.GetType("System.String"))
      .Columns.Add("addr5", Type.GetType("System.String"))
      .Columns.Add("excd", Type.GetType("System.String"))
      .Columns.Add("exam", Type.GetType("System.Int32"))
      .Columns.Add("revloss", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetailRE()
    Dim AddrLine() As String
    Dim WrkCode As String
    Dim WrkCodeExam As Integer
    Dim WrkGross As Integer
    Dim WrkSort As String
    Dim WrkQry As String
    Dim I As Integer
    Dim WrkAnd As String
    Dim WrkOr As String

    WrkOr = " or "
    WrkAnd = " and "
    WrkSort = "NAME, LIST#"
    WrkQry = "CAT='1'"
    If Not WrkDistAll Then
      WrkQry = "dist=" & WrkDist
    End If
    If Not WrkFrozenFile Then
      DsFile = myTXREALQ.GetQry(WrkSort, WrkQry, 0)
    Else
      DsFile = myTXREALCQ.GetQry(WrkSort, WrkQry, 0)
    End If

    If DsFile.Tables(0).Rows.Count = 0 Then Exit Sub

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsFile.Tables(0).Rows.Count - 1)
      With DsFile.Tables(0).Rows(I)
        If .Item("ccno") > 0 Then
          WrkGross = .Item("ccgrs")
          WrkExcd(0) = .Item("cccd1")
          WrkExcd(1) = .Item("cccd2")
          WrkExcd(2) = .Item("cccd3")
          WrkExcd(3) = .Item("cccd4")
          WrkExcd(4) = .Item("cccd5")
          WrkExcd(5) = .Item("cccd6")
          WrkExcd(6) = .Item("cccd7")
          WrkExam(0) = .Item("cexa1")
          WrkExam(1) = .Item("cexa2")
          WrkExam(2) = .Item("cexa3")
          WrkExam(3) = .Item("cexa4")
          WrkExam(4) = .Item("cexa5")
          WrkExam(5) = .Item("cexa6")
          WrkExam(6) = .Item("cexa7")
        Else
          WrkGross = .Item("gross") + .Item("btr")
          WrkExcd(0) = .Item("excd1")
          WrkExcd(1) = .Item("excd2")
          WrkExcd(2) = .Item("excd3")
          WrkExcd(3) = .Item("excd4")
          WrkExcd(4) = .Item("excd5")
          WrkExcd(5) = .Item("excd6")
          WrkExcd(6) = .Item("excd7")
          WrkExam(0) = .Item("exam1")
          WrkExam(1) = .Item("exam2")
          WrkExam(2) = .Item("exam3")
          WrkExam(3) = .Item("exam4")
          WrkExam(4) = .Item("exam5")
          WrkExam(5) = .Item("exam6")
          WrkExam(6) = .Item("exam7")
        End If

        WrkCode = ""
        FindExemptions(WrkCode, WrkCodeExam)
        If WrkCode = "" Then GoTo NextRec

        dr = ds.Tables(0).NewRow
        dr.Item("listno") = .Item("list#")
        dr.Item("typedesc") = ""
        AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"),
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
        dr.Item("addr1") = AddrLine(0)
        dr.Item("addr2") = AddrLine(1)
        dr.Item("addr3") = AddrLine(2)
        dr.Item("addr4") = AddrLine(3)
        dr.Item("addr5") = AddrLine(4)
        dr.Item("excd") = WrkCode
        dr.Item("exam") = WrkCodeExam
        dr.Item("revloss") = MyUtils.Round(WrkCodeExam * MrateMillrt, 2)
        ds.Tables(0).Rows.Add(dr)
        WrkAccts = WrkAccts + 1
        ' WrkRELoss = WrkRELoss + WrkCodeExam
        WrkRELoss = WrkRELoss + MyUtils.Round(WrkCodeExam * MrateMillrt, 2) 'per kim it this then 1/2 of it
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsFile.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next
    WrkRELoss = WrkRELoss / 2 ' per kim it is half the revloss
    myFrmProgress.Close()
    Application.DoEvents()
    myTXREALQ.CloseFile()
    myTXREALCQ.CloseFile()

  End Sub
  Private Sub GetDetailPP()
    Dim AddrLine() As String
    Dim WrkCode As String
    Dim WrkCodeExam As Integer
    Dim WrkGross As Integer
    Dim WrkSort As String
    Dim WrkQry As String
    Dim I As Integer
    Dim WrkAnd As String
    Dim WrkOr As String

    WrkOr = " or "
    WrkAnd = " and "
    WrkSort = "NAME, LIST#"
    WrkQry = "CAT='5'"
    If Not WrkDistAll Then
      WrkQry = "dist=" & WrkDist
    End If
    If Not WrkFrozenFile Then
      DsFile = myTXPPRPQ.GetQry(WrkSort, WrkQry, 0)
    Else
      DsFile = myTXPPRPCQ.GetQry(WrkSort, WrkQry, 0)
    End If

    If DsFile.Tables(0).Rows.Count = 0 Then Exit Sub

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsFile.Tables(0).Rows.Count - 1)
      With DsFile.Tables(0).Rows(I)
        If .Item("ccno") > 0 Then
          WrkGross = .Item("ccgrs")
          WrkExcd(0) = .Item("cccd1")
          WrkExcd(1) = .Item("cccd2")
          WrkExcd(2) = .Item("cccd3")
          WrkExcd(3) = .Item("cccd4")
          WrkExcd(4) = .Item("cccd5")
          WrkExam(0) = .Item("cexa1")
          WrkExam(1) = .Item("cexa2")
          WrkExam(2) = .Item("cexa3")
          WrkExam(3) = .Item("cexa4")
          WrkExam(4) = .Item("cexa5")
        Else
          WrkGross = .Item("gross") + .Item("btr")
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
        End If

        WrkCode = ""
        FindExemptions(WrkCode, WrkCodeExam)
        If WrkCode = "" Then GoTo NextRec

        dr = ds.Tables(0).NewRow
        dr.Item("listno") = .Item("list#")
        dr.Item("typedesc") = ""
        AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"),
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
        dr.Item("addr1") = AddrLine(0)
        dr.Item("addr2") = AddrLine(1)
        dr.Item("addr3") = AddrLine(2)
        dr.Item("addr4") = AddrLine(3)
        dr.Item("addr5") = AddrLine(4)
        dr.Item("excd") = WrkCode
        dr.Item("exam") = WrkCodeExam
        dr.Item("revloss") = MyUtils.Round(WrkCodeExam * MrateMillrt, 2)
        ds.Tables(0).Rows.Add(dr)
        WrkAccts = WrkAccts + 1
        ' WrkPPLoss = WrkPPLoss + WrkCodeExam   ' per kim it is 1/2 rev loss
        WrkPPLoss = WrkPPLoss + MyUtils.Round(WrkCodeExam * MrateMillrt, 2)
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsFile.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next
    WrkPPLoss = WrkPPLoss / 2    ' per kim it is 1/2 the revloss
    myFrmProgress.Close()
    Application.DoEvents()
    myTXPPRPQ.CloseFile()
    myTXPPRPCQ.CloseFile()

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
      If WrkExcd(I) = cSelCode1 Or WrkExcd(I) = cSelCode2 Then
        If WrkCode = String.Empty Then
          WrkCode = WrkExcd(I)
          WrkCodeExam = WrkExam(I)
        Else
          WrkCodeExam = WrkCodeExam + WrkExam(I)
        End If
        WrkNumExem = WrkNumExem + 1
      End If
    Next
  End Sub
  Public Sub GetOPMAssr()
    Dim sb As StringBuilder = New StringBuilder

    WrkTown = ""
    myTXOPM.GetOneRecordP("A")
    If myTXOPM.RecordNotFound Then Exit Sub

    sb.Append(Trim(myTOWN._TOWN))
    WrkTown = sb.ToString
    WrkCert = myTXOPM._CERT
    sb = Nothing
  End Sub
End Module






