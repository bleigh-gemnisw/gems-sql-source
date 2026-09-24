Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXPROF As TXPROF.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  'General
  Dim WrkAnd As String
  Dim WrkOr As String
  Dim WrkPaid As Boolean
  Dim WrkSuspense As Boolean
  Dim WrkPeriodDesc As String
  Dim WrkUnposted As Boolean
  Dim WrkDueDt As Date
  'Tax Types
  Dim WrkCode(50) As String
  Dim WrkDesc(50) As String
  Dim WrkFamily(50) As String

  Public Sub PrtReport()

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXPROF = New TXPROF.MyData(myDBConnect)

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    BufferType()
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
      .Columns.Add("Sname", Type.GetType("System.String"))
      .Columns.Add("Address", Type.GetType("System.String"))
      .Columns.Add("CityST", Type.GetType("System.String"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("Taxt", Type.GetType("System.Decimal"))
      .Columns.Add("Paid", Type.GetType("System.Decimal"))
      .Columns.Add("AmtDue", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub GetDetail()
    Dim WrkType As String
    Dim WrkFromYear As Integer
    Dim WrkToYear As Integer
    Dim WrkDist As Integer
    Dim WrkDistAll As Boolean
    Dim WrkBank As String
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim WrkTXType As String()
    Dim WrkFamily As String
    Dim WrkPaidAmt As Decimal
    Dim WrkAmtDue As Decimal
    Dim sb As StringBuilder

    With MyFrmTXE03B
      WrkType = .TxtTypes.Text
      WrkFromYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
      WrkToYear = MyUtils.CnvSng(.TxtToGLYear.Text)
      WrkPaid = .ChkPaid.Checked
      WrkUnposted = .ChkUnPosted.Checked
      WrkSuspense = .ChkSuspense.Checked
      MyTypes = .TxtTypes.Text
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkDistAll = False
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkBank = .TxtBankCd.Text
      WrkDueDt = MyFrmTXE03B.DtPckDue.Value
    End With

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    Counter = 0
    WrkSort = "NAME, ADD1, YEAR desc"

    WrkQry = "icode<>'I'" & WrkAnd & "ICODE<>'D'"
    If Not WrkSuspense Then
      WrkQry = WrkQry & WrkAnd & "ICODE<>'S'"
    End If
    If WrkFromYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromYear
    End If
    If WrkToYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "YEAR <= " & WrkToYear
    End If
    If Not WrkDistAll Then
      WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
    End If
    If WrkBank <> "" Then
      WrkQry = WrkQry & WrkAnd & "bkcd=" & MyUtils.Quo(WrkBank)
    End If

    MyTypes = MyFrmTXE03B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    myTXINVQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()

ReadNext:
    myTXINVQ.ReadQry()
    If Not myTXINVQ.IsEOF Then
      With myTXINVQ
        Counter = Counter + 1
        dr = ds.Tables(0).NewRow
        dr.Item("listno") = ._LISTNo
        dr.Item("year") = ._YEAR
        dr.Item("type") = ._TYPE
        dr.Item("name") = Trim(._NAME)
        dr.Item("sname") = Trim(._SNAME)
        dr.Item("address") = Trim(._ADD1)
        sb = New StringBuilder
        sb.Append(Trim(._CITY))
        sb.Append(",")
        sb.Append(._STATE)
        sb.Append(" ")
        sb.Append(Format(._ZIP5, "00000"))
        If ._ZIP4 > 0 Then
          sb.Append("-")
          sb.Append(Format(._ZIP4, "0000"))
        End If
        dr.Item("cityst") = sb.ToString
        sb = Nothing
        WrkTXType = LookupType(._TYPE)
        WrkFamily = WrkTXType(1)
        Select Case WrkFamily
          Case "M", "S"
            sb = New StringBuilder
            sb.Append(MyUtils.JustifyLeft(._MAKE, 5))
            sb.Append("")
            sb.Append(MyUtils.JustifyLeft(._MODEL, 8))
            sb.Append("")
            sb.Append(._MVYR)
            sb.Append("")
            sb.Append(MyUtils.JustifyLeft(._IMVREG, 8))
            sb.Append("")
            sb.Append(._IMVIDNo)
            dr.Item("desc") = sb.ToString
            sb = Nothing
          Case Else
            dr.Item("desc") = MyUtils.JustifyRight(Trim(._LOCNo), 7) & " " & ._LOC
        End Select
        If WrkUnposted Then
          WrkPaidAmt = ._PAYREC + ._NEWPAY
        Else
          WrkPaidAmt = ._PAYREC
        End If
        If ._PHASE = 0 Then
          myTXPROF.GetOneRecordP(._TYPE, ._YEAR, "", ._DIST)
        Else
          myTXPROF.GetOneRecordP(._TYPE, ._YEAR, ._PHASE, ._DIST)
        End If
        If ._CCNO > 0 Then
          dr.Item("taxt") = ._CCETAX
          If WrkDueDt >= MyUtils.GetDBDateMDY(myTXPROF._PRDUE1) Then
            WrkAmtDue = ._CCTX1
          End If
          If WrkDueDt >= MyUtils.GetDBDateMDY(myTXPROF._PRDUE2) Then
            WrkAmtDue = WrkAmtDue + ._CCTX2
          End If
          If WrkDueDt >= MyUtils.GetDBDateMDY(myTXPROF._PRDUE3) Then
            WrkAmtDue = WrkAmtDue + ._CCTX3
          End If
          If WrkDueDt >= MyUtils.GetDBDateMDY(myTXPROF._PRDUE4) Then
            WrkAmtDue = WrkAmtDue + ._CCTX4
          End If
          dr.Item("amtdue") = WrkAmtDue - WrkPaidAmt
        Else
          dr.Item("taxt") = ._TAXT
          If WrkDueDt >= MyUtils.GetDBDateMDY(myTXPROF._PRDUE1) Then
            WrkAmtDue = ._TAX1
          End If
          If WrkDueDt >= MyUtils.GetDBDateMDY(myTXPROF._PRDUE2) Then
            WrkAmtDue = WrkAmtDue + ._TAX2
          End If
          If WrkDueDt >= MyUtils.GetDBDateMDY(myTXPROF._PRDUE3) Then
            WrkAmtDue = WrkAmtDue + ._TX3RD
          End If
          If WrkDueDt >= MyUtils.GetDBDateMDY(myTXPROF._PRDUE4) Then
            WrkAmtDue = WrkAmtDue + ._TX4TH
          End If
          dr.Item("amtdue") = WrkAmtDue - WrkPaidAmt
        End If
        dr.Item("paid") = WrkPaidAmt
      End With
      If WrkPaid Then
        ds.Tables(0).Rows.Add(dr)
      Else
        If dr.Item("amtdue") > 0 Then
          ds.Tables(0).Rows.Add(dr)
        End If
      End If

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
        GoTo ReadNext
      End With
    End If

    myFrmProgress.Close()
    myTXINVQ.CloseFile()

  End Sub
  Private Function BuildSelectTypes() As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim StrLen As Integer
    Dim I As Integer

    If MyTypes = "" Then
      Return ""
    End If

    sbSelect = New System.Text.StringBuilder
    sbSelect.Append("TYPE=%Values(")
    StrLen = Len(MyTypes)

    For I = 1 To StrLen
      WrkType = Mid(MyTypes, I, 1)
      sbSelect.Append(Chr(34) & WrkType & Chr(34) & " ")
    Next

    sbSelect.Append(")")
    Return sbSelect.ToString
  End Function
  Private Function BuildSelectQryPC(ByVal WrkStrIn As String, ByVal WrkSelTypes As String) As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim WrkStrOut As String
    Dim StrLen As Integer
    Dim I As Integer

    WrkStrOut = ""
    If WrkSelTypes = "" Then
      Return ""
    End If

    StrLen = Len(WrkSelTypes)
    sbSelect = New System.Text.StringBuilder
    For I = 1 To StrLen
      If I > 1 Then
        sbSelect.Append(",")
      End If
      WrkType = Mid(WrkSelTypes, I, 1)
      sbSelect.Append(MyUtils.Quo(WrkType))
    Next
    If WrkStrIn = "" Then
      WrkStrOut = "TYPE IN(" & sbSelect.ToString & ")"
    Else
      WrkStrOut = WrkStrIn & WrkAnd & "TYPE IN(" & sbSelect.ToString & ")"
    End If
    sbSelect = Nothing
    Return WrkStrOut
  End Function
  Private Sub BufferType()
    Dim I As Integer

    Dim myTXTYPE As TXTYPE.MyData
    Dim dsTXType As DataSet = New DataSet

    myTXTYPE = New TXTYPE.MyData(myDBConnect)

    dsTXType = myTXTYPE.GetAllData
    For I = 0 To dsTXType.Tables(0).Rows.Count - 1
      With dsTXType.Tables(0).Rows(I)
        WrkCode(I) = .Item("tycode")
        WrkDesc(I) = .Item("tydesc")
        WrkFamily(I) = .Item("txfam")
      End With
    Next

  End Sub
  Private Function LookupType(ByVal Type As String) As String()
    Dim I As Integer
    Dim WrkResult(1) As String

    WrkResult(0) = ""
    WrkResult(1) = ""

    For I = 0 To WrkCode.GetUpperBound(0)
      If WrkCode(I) = "" Then
        Return WrkResult
      End If
      If Type = WrkCode(I) Then
        WrkResult(0) = WrkDesc(I)
        WrkResult(1) = WrkFamily(I)
        Return WrkResult
      End If
    Next

    Return WrkResult
  End Function

End Module






