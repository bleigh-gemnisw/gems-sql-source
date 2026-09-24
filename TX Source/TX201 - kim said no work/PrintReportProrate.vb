Imports System.Text
Module PrintReportProrate

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXPROMSQ As TXPROMSQ.MyData
  Dim myTPaymnt As TPAYMNT.MyData

  Dim ds As DataSet = New DataSet
  Dim dsTot As DataSet = New DataSet
  Dim dsErr As DataSet = New DataSet
  Dim DsTXPROMS As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim drTot As Data.DataRow
  Dim drErr As Data.DataRow

  Dim WrkGLYear As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkPhase As String
  Dim WrkSortBy As String
  Dim WrkBillType As String
  Dim WrkList As Integer
  Dim WrkType As String
  Dim WrkGross As Integer
  Dim WrkExempt As Integer
  Dim WrkNet As Integer
  Dim WrkBTR As Integer
  Dim WrkTaxAmount As Decimal
  Dim WrkTax As Decimal
  Dim WrkTax1st As Decimal
  Dim WrkTax2nd As Decimal
  Dim WrkTax3rd As Decimal
  Dim WrkTax4th As Decimal
  Dim WrkRounding As Decimal
  'Total Page
  Dim WrkTAccts As Integer
  Dim WrkTBills As Integer
  Dim WrkTGross As Long
  Dim WrkTExempt As Long
  Dim WrkTNet As Long
  Dim WrkTTax As Decimal
  Dim WrkTTax1 As Decimal
  Dim WrkTTax2 As Decimal
  Dim WrkTRounding As Decimal
  Dim WrkTWaiveredAccts As Integer
  Dim WrkTWaiveredGross As Integer
  Dim WrkTWaivered As Decimal

  Public Sub PrtReportProrate()
    myTXPROMSQ = New TXPROMSQ.MyData(myDBConnect)
    myTPaymnt = New TPAYMNT.MyData(myDBConnect)

    WrkType = "X"
    'Clear Totals
    ClearTotals()

    With MyFrmTX201B
      WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
    End With

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
      BuildDSTot(dsTot)
      dsErr = ds.Clone
    Else
      ds.Clear()
      dsTot.Clear()
      dsErr.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .WrkdsTot = dsTot
      .WrkdsErr = dsErr
      .WrkType = WrkType
      .WrkTypeDesc = WrkBillType
      .Show()
    End With

  End Sub
  Private Sub ClearTotals()
    WrkTGross = 0
    WrkTExempt = 0
    WrkTNet = 0
    WrkTTax = 0
    WrkTTax1 = 0
    WrkTTax2 = 0
    WrkTRounding = 0
    WrkTAccts = 0
    WrkTBills = 0
    WrkTWaiveredAccts = 0
    WrkTWaiveredGross = 0
    WrkTWaivered = 0
  End Sub
  Private Sub GetDetail()
    Dim AddrLine() As String
    Dim WrkQry As String
    Dim WrkSort As String
    Dim I As Integer
    Dim WrkAnd As String
    Dim WrkFamily As String
    Dim WrkCoType As String
    Dim SaveExLetter As String

    WrkPhase = ""
    WrkBillType = GetTXTypeDesc(WrkType)
    WrkFamily = GetTXTypeFamily(WrkType)

    If MyServer = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = ""
    If Not WrkDistAll Then
      WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
    End If

    WrkSort = "NAME, SNAME, ADD1"

    DsTXPROMS = myTXPROMSQ.GetQry(WrkSort, WrkQry, 0)
    If DsTXPROMS.Tables(0).Rows.Count = 0 Then Exit Sub
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    SaveExLetter = ""
    GetTaxProfile(WrkType, WrkGLYear, WrkPhase, WrkDist)
    GetMillRate(WrkGLYear, "X", WrkDist)

    For I = 0 To (DsTXPROMS.Tables(0).Rows.Count - 1)
      With DsTXPROMS.Tables(0).Rows(I)
        WrkList = .Item("list#")
        WrkGross = .Item("gross")
        WrkExempt = .Item("tex")
        WrkNet = .Item("net")
        If WrkNet < 0 Then WrkNet = 0
        WrkTaxAmount = WrkNet * MrateMillrt
        WrkTax = WrkTaxAmount
        With myTPaymnt
          .In_ListNo = WrkList
          .In_Type = WrkType
          .In_Year = WrkGLYear
          .In_Dst = WrkDist
          .In_Phs = WrkPhase
          .In_TaxT = WrkTax
          .CalcPaySplit()
          WrkTax = .Out_TaxT
          WrkTax1st = .Out_Tax1
          WrkTax2nd = .Out_Tax2
          WrkRounding = .In_TaxT - .Out_TaxT
          If .Out_Waivered > 0 Then
            WrkTWaiveredAccts = WrkTWaiveredAccts + 1
            WrkTWaivered = WrkTWaivered + .Out_Waivered
            WrkTWaiveredGross = WrkTWaiveredGross + WrkGross
            WrkRounding = .In_TaxT - .Out_Waivered
          End If
        End With

        'Create Rate Book
        dr = ds.Tables(0).NewRow
        dr.Item("letter") = .Item("lett")
        dr.Item("TypeDesc") = WrkBillType
        dr.Item("listno") = WrkList
        dr.Item("year") = WrkGLYear
        AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"),
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
        dr.Item("addr1") = AddrLine(0)
        dr.Item("addr2") = AddrLine(1)
        dr.Item("addr3") = AddrLine(2)
        dr.Item("addr4") = AddrLine(3)
        dr.Item("addr5") = AddrLine(4)
        dr.Item("reflistno") = .Item("rlist")
        WrkCoType = .Item("cotype")
        Select Case WrkCoType
          Case "E"
            dr.Item("proratedesc") = "Elderly"
          Case "N"
            dr.Item("proratedesc") = "New Construction"
          Case "V"
            dr.Item("proratedesc") = "Veterans"
        End Select
        dr.Item("bank") = .Item("bkcd")
        dr.Item("gross") = WrkGross
        dr.Item("exemption") = WrkExempt
        dr.Item("net") = WrkNet
        dr.Item("taxtot") = WrkTax
        dr.Item("tax1st") = WrkTax1st
        dr.Item("tax2nd") = WrkTax2nd
        dr.Item("ccno") = 0
        dr.Item("propdesc") = .Item("loc#") & " " & .Item("loc")
        dr.Item("propdesc2") = .Item("vol") & .Item("xpage") & ", " & .Item("map")
        'Add to Report Totals
        WrkTGross = WrkTGross + WrkGross
        WrkTExempt = WrkTExempt + WrkExempt
        WrkTNet = WrkTNet + WrkNet
        WrkTTax = WrkTTax + WrkTax
        WrkTTax1 = WrkTTax1 + WrkTax1st
        WrkTTax2 = WrkTTax2 + WrkTax2nd
        WrkTRounding = WrkTRounding + WrkRounding
        WrkTAccts = WrkTAccts + 1
        If WrkTax > 0 Then
          WrkTBills = WrkTBills + 1
        End If
        ds.Tables(0).Rows.Add(dr)
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsTXPROMS.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    'Totals
    drTot = dsTot.Tables(0).NewRow
    drTot.Item("taccts") = WrkTAccts
    drTot.Item("tgross") = WrkTGross
    drTot.Item("texempt") = WrkTExempt
    drTot.Item("tnet") = WrkTNet
    drTot.Item("ttax") = WrkTTax
    drTot.Item("ttax1") = WrkTTax1
    drTot.Item("ttax2") = WrkTTax2
    drTot.Item("ttaxmill") = WrkTNet * MrateMillrt
    drTot.Item("tvariance") = drTot.Item("ttaxmill") - WrkTTax
    drTot.Item("ttaxheart") = 0
    drTot.Item("ttaxstbenefit") = 0
    drTot.Item("ttaxtownbenefit") = 0
    drTot.Item("ttaxfrzloss") = 0
    drTot.Item("ttax10mlloss") = 0
    drTot.Item("twaiveredaccts") = WrkTWaiveredAccts
    drTot.Item("twaivered") = WrkTWaivered
    drTot.Item("trounding") = WrkTRounding
    drTot.Item("ttaxvariance") = WrkTWaivered + WrkTRounding
    drTot.Item("taccts") = WrkTAccts
    drTot.Item("tbills") = WrkTBills
    dsTot.Tables(0).Rows.Add(drTot)

    myFrmProgress.Close()
    myTXPROMSQ.CloseFile()

  End Sub
End Module







