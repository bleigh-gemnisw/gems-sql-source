Imports System.Text
Imports System.Collections.Generic

Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXPROF As TXPROF.MyData
  Dim myCASHINT As CASHINT.MyData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim dsGrouped As DataSet = New DataSet   ' clone of ds 

  'General
  Dim WrkAnd As String
  Dim WrkOr As String
  Dim WrkPaid As Boolean
  Dim WrkSuspense As Boolean
  Dim WrkPeriodDesc As String
  Dim WrkUnposted As Boolean
  Dim WrkIntDate As Date
  'Tax Types
  Dim WrkCode(50) As String
  Dim WrkDesc(50) As String
  Dim WrkFamily(50) As String
  Dim WrkMin As Decimal        '12/7/25 added Ken
  Dim WrkMinYrs As Integer        '12/7/25 added Ken
  Public Sub PrtReport()
    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXPROF = New TXPROF.MyData(myDBConnect)
    myCASHINT = New CASHINT.MyData(myDBConnect)

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    BufferType()
    GetDetail()

    ' Build Grouped clone and apply filter
    CloneMainDSToGrouped()
    ApplyGroupedFilter()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = dsGrouped
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
      .Columns.Add("Prin", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Fee", Type.GetType("System.Decimal"))
      .Columns.Add("Lien", Type.GetType("System.Decimal"))
      .Columns.Add("AmtDue", Type.GetType("System.Decimal"))
      .Columns.Add("Paid", Type.GetType("System.Decimal"))
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
    Dim WrkInterest As Decimal
    Dim WrkTax As Decimal
    Dim WrkBond As Decimal
    Dim WrkFee As Decimal
    Dim WrkLien As Decimal
    Dim WrkDue As Decimal
    'Dim WrkPaidAmt As Decimal
    Dim sb As StringBuilder

    With MyFrmTXE58B
      WrkType = .TxtTypes.Text
      WrkFromYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
      WrkToYear = MyUtils.CnvSng(.TxtToGLYear.Text)
      WrkUnposted = .ChkUnPosted.Checked
      WrkSuspense = .ChkSuspense.Checked
      MyTypes = .TxtTypes.Text
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkDistAll = False
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkBank = .TxtBankCd.Text
      WrkIntDate = MyFrmTXE58B.DtPckDue.Value
      WrkMin = MyUtils.CnvSng(.TxtMin.Text)
      WrkMinYrs = MyUtils.CnvSng(.TxtMinYrs.Text)
    End With

    WrkAnd = " and "
    WrkOr = " or "

    Counter = 0
    WrkSort = "LIST#, YEAR desc"

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

    MyTypes = MyFrmTXE58B.TxtTypes.Text
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
        CalcInterest(._LISTNo, ._TYPE, ._YEAR, WrkInterest, WrkFee, WrkLien, WrkBond, WrkTax, WrkDue, False, 0, 0, 0, 0)
        'Filter - Omit below amount due 
        If WrkDue <= 0 Then
          GoTo NextRec
        End If
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
        'If WrkUnposted Then
        '  WrkPaidAmt = ._PAYREC + ._NEWPAY
        'Else
        '  WrkPaidAmt = ._PAYREC
        'End If
        dr.Item("prin") = WrkTax
        dr.Item("interest") = WrkInterest
        dr.Item("fee") = WrkFee
        dr.Item("lien") = WrkLien
        dr.Item("amtdue") = WrkDue
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
        GoTo ReadNext
      End With
    End If

    myFrmProgress.Close()
    myTXINVQ.CloseFile()

  End Sub
  '-------------------------------------------------
  ' 12/7/25  added new subroutines    Ken
  '-------------------------------------------------
  Private Sub CloneMainDSToGrouped()

    ' Make sure we start clean
    If dsGrouped IsNot Nothing Then
      dsGrouped.Clear()
      dsGrouped.Tables.Clear()
    End If

    dsGrouped = ds.Copy()

    '' Copy all rows from main dataset into lien-sale dataset
    'If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
    '  For Each row As DataRow In ds.Tables(0).Rows
    '    dsGrouped.Tables(0).ImportRow(row)
    '  Next
    'End If
  End Sub

  Private Sub ApplyGroupedFilter()
    ' ============================================================
    ' Lien sale filter:
    '   Keep only list numbers where:
    '     - Total AmtDue (all years) >= MinTotalDue (WrkMin)
    '     - At least MinDelinquentYears (WrkMinYrs) distinct GL years
    ' ============================================================

    Dim MinTotalDue As Decimal = WrkMin
    Dim MinDelinquentYears As Integer = WrkMinYrs

    ' Safety: if not properly supplied, skip
    If MinTotalDue <= 0D OrElse MinDelinquentYears <= 0 Then
      Exit Sub
    End If

    ' Work on the lien-sale dataset (clone of ds)
    If dsGrouped Is Nothing OrElse dsGrouped.Tables.Count = 0 OrElse dsGrouped.Tables(0).Rows.Count = 0 Then
      Exit Sub
    End If

    Dim listTotals As New Dictionary(Of Integer, Decimal)
    Dim listYears As New Dictionary(Of Integer, HashSet(Of Integer))

    ' Build totals and distinct delinquent years per list
    For Each row As DataRow In dsGrouped.Tables(0).Rows
      Dim listNo As Integer = CInt(row("listno"))
      Dim year As Integer = CInt(row("year"))
      Dim amtDue As Decimal = CDec(row("amtdue"))

      If amtDue > 0D Then
        ' Sum total due per list
        If Not listTotals.ContainsKey(listNo) Then
          listTotals(listNo) = 0D
        End If
        listTotals(listNo) += amtDue

        ' Track distinct years with a balance per list
        If Not listYears.ContainsKey(listNo) Then
          listYears(listNo) = New HashSet(Of Integer)()
        End If
        listYears(listNo).Add(year)
      End If
    Next

    ' Determine which list numbers to keep
    Dim keepLists As New HashSet(Of Integer)()
    For Each kvp As KeyValuePair(Of Integer, Decimal) In listTotals
      Dim listNo As Integer = kvp.Key
      Dim totalDue As Decimal = kvp.Value

      Dim yearCount As Integer = 0
      If listYears.ContainsKey(listNo) Then
        yearCount = listYears(listNo).Count
      End If

      If totalDue >= MinTotalDue AndAlso yearCount >= MinDelinquentYears Then
        keepLists.Add(listNo)
      End If
    Next

    ' If nothing qualifies, clear the lien-sale dataset
    If keepLists.Count = 0 Then
      dsGrouped.Tables(0).Rows.Clear()
      Exit Sub
    End If

    ' Remove rows that don't meet the criteria (walk backwards)
    Dim i As Integer = dsGrouped.Tables(0).Rows.Count - 1
    While i >= 0
      Dim row As DataRow = dsGrouped.Tables(0).Rows(i)
      Dim listNo As Integer = CInt(row("listno"))
      If Not keepLists.Contains(listNo) Then
        dsGrouped.Tables(0).Rows.RemoveAt(i)
      End If
      i -= 1
    End While

  End Sub


  ' end add new subroutines  Ken  12/7/25

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
  Public Sub CalcInterest(ByVal InListNo As Integer, ByVal InType As String,
    ByVal InYear As Integer, ByRef OutInterest As Decimal, ByRef OutFee As Decimal,
    ByRef OutLien As Decimal, ByRef OutBond As Decimal, ByRef OutTax As Decimal,
    ByRef OutDue As Decimal, ByRef OutGracePeriod As Boolean, ByRef OutInt1 As Decimal,
    ByRef OutInt2 As Decimal, ByRef OutInt3 As Decimal, ByRef OutInt4 As Decimal)
    With myCASHINT
      .In_IntDate = WrkIntDate
      .In_ListNo = InListNo
      .In_Type = InType
      .In_Year = InYear
      .CalcInterest()
      OutInterest = Format(.Out_Int(), "standard")
      OutInt1 = Format(.Out_Int1(), "standard")
      OutInt2 = Format(.Out_Int2(), "standard")
      OutInt3 = Format(.Out_Int3(), "standard")
      OutInt4 = Format(.Out_Int4(), "standard")
      OutFee = Format(.Out_Fee(), "standard")
      OutLien = Format(.Out_Lien(), "standard")
      OutBond = Format(.Out_Bond(), "standard")
      OutTax = Format(.Out_Prin(), "standard")
      OutDue = Format(.Out_Tot(), "standard")
      OutGracePeriod = .Out_GracePeriod
    End With
  End Sub
End Module
