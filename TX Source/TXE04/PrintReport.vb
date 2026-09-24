Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINVQ As TXINVQ.myData
Dim myTXHST As TXHSTL4.myData
Dim myTXPROF As TXPROF.myData
Dim myTXCOEA As TXCOEAL1.myData
Dim myUTCOEA As UTCOEAL1.myData
Dim ds1 As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim dr As Data.DataRow
Dim dr2 As Data.DataRow

'General
Dim WrkAnd As String
Dim WrkOr As String

'Screen
Dim WrkType As String
Dim WrkFromGLYear As Integer
Dim WrkToGLYear As Integer
Dim WrkAsofDt As Date
Dim WrkSuspense As Boolean
Dim WrkLetter As Boolean
Dim WrkDist As Integer
Dim WrkDistAll As Boolean

Dim WrkTCount As Integer
Dim WrkTTax As Decimal
Dim WrkTPaid As Decimal
Dim WrkTDue As Decimal
Public Sub PrtReport()
  myTXINVQ = New TXINVQ.mydata(MyDBConnect)
  myTXHST = New TXHSTL4.mydata(MyDBConnect)
  myTXPROF = New TXPROF.mydata(MyDBConnect)
  myTXCOEA = New TXCOEAL1.mydata(MyDBConnect)
  myUTCOEA = New UTCOEAL1.mydata(MyDBConnect)

  With MyFrmTXE04B
    WrkFromGLYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
    WrkToGLYear = MyUtils.CnvSng(.TxtToGLYear.Text)
    WrkAsofDt = .DtPckAsof.Value
    WrkSuspense = False
    If .ChkSuspense.Checked Then
      WrkSuspense = True
    End If
    WrkLetter = False
    If .ChkLetter.Checked Then
      WrkLetter = True
    End If
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    WrkDistAll = False
    If .TxtDist.Text = "" Then
      WrkDistAll = True
    End If
  End With

  If ds1.Tables.Count = 0 Then
    BuildDS()
  Else
    ds1.Clear()
    ds2.Clear()
    ClearTotals()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds1
  MyCrViewer.wrkds2 = ds2
  MyCrViewer.Show()

End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Letter", Type.GetType("System.String"))
      .Columns.Add("Tax", Type.GetType("System.Double"))
      .Columns.Add("Paid", Type.GetType("System.Double"))
      .Columns.Add("Due", Type.GetType("System.Double"))
    End With
    ds1.Tables.Add(myTable)

    With myTable2
      .TableName = "mytable2"
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Letter", Type.GetType("System.String"))
      .Columns.Add("TCount", Type.GetType("System.Int32"))
      .Columns.Add("TTax", Type.GetType("System.Double"))
      .Columns.Add("TPaid", Type.GetType("System.Double"))
      .Columns.Add("TDue", Type.GetType("System.Double"))
    End With
    ds2.Tables.Add(myTable2)

  End Sub
Private Sub ClearTotals()
  WrkTCount = 0
  WrkTTax = 0
  WrkTPaid = 0
  WrkTDue = 0
End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim J As Integer
Dim K As Integer
Dim WrkLetter As String
Dim WrkFamily As String
Dim SaveYear As Integer
Dim SaveType As String
Dim SaveLetter As String

'TXPROF
Dim ProfDuedt As Date

'TXHST
Dim HstPamt(200) As Decimal
Dim HstPdate(200) As Date
Dim HstAdj(200) As Boolean

Dim WrkDue As Double
Dim WrkPaid As Double
Dim WrkPaidDt As Date
Dim WrkAdjust As Boolean
Dim WrkAdjustPaid As Double
Dim WrkAdjustPaidDt As Date
Dim WrkTaxt As Double
Dim WrkTypes As String
Dim WrkHistFound As Boolean
Dim Counter As Integer

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

WrkQry = "icode<>'I'" & WrkAnd & "Icode<>'D'"

If WrkFromGLYear > 0 Then
  WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromGLYear _
  & WrkAnd & "YEAR <= " & WrkToGLYear
End If
If Not WrkDistAll Then
  WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
End If

MyTypes = MyFrmTXE04B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    Counter = 0
SaveType = ""
SaveLetter = ""

WrkSort = "YEAR, TYPE, NAME"
'WrkQry = WrkQry & WrkAnd & "list#=508138"
myTXINVQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()

ReadNext:
  myTXINVQ.ReadQry()
  If Not myTXINVQ.IsEOF Then
  With myTXINVQ
    Counter = Counter + 1

    'Filter suspense
    If Not WrkSuspense Then
			If ._ICODE = "S" And ._SUSDT = 0 Then
				GoTo NextRec
			End If
      If ._SUSDT > 0 And ._SUSDT <= MyUtils.SetDBDate(WrkAsofDt) Then
        GoTo NextRec
      End If
    End If

    dr = ds1.Tables(0).NewRow
    WrkLetter = Left$(._NAME, 1)
    If SaveType <> ._TYPE Or SaveYear <> ._YEAR Then
      myTXPROF.GetOneRecordP(._TYPE, ._YEAR, "", 0)
      If Not myTXPROF.RecordNotFound Then
        With myTXPROF
          ProfDuedt = MyUtils.GetDBDateMDY(._PRDUE1)
        End With
      End If
    End If
    If SaveLetter <> "" And SaveLetter <> WrkLetter Then
      WriteTotals(SaveYear, SaveType, SaveLetter)
      ClearTotals()
      SaveYear = ._YEAR
      SaveType = ._TYPE
      SaveLetter = WrkLetter
    End If
    If SaveType <> "" And SaveType <> ._TYPE Then
      WriteTotals(SaveYear, SaveType, SaveLetter)
      ClearTotals()
      SaveYear = ._YEAR
      SaveType = ._TYPE
      SaveLetter = WrkLetter
    End If
    If SaveYear > 0 And SaveYear <> ._YEAR Then
      WriteTotals(SaveYear, SaveType, SaveLetter)
      ClearTotals()
    End If

    SaveYear = ._YEAR
    SaveType = ._TYPE
    SaveLetter = WrkLetter

    WrkTaxt = 0
    WrkPaid = 0
    WrkDue = 0
    WrkAdjustPaid = 0

    'Filter - Due date after as of date
    If ProfDuedt > WrkAsofDt Then
      GoTo NextRec
    End If
    'Filter - Prorate due date is after as of date
    If ._TYPE = "X" Then
      If MyUtils.GetDBDate(._PDAT) > WrkAsofDt Then
        GoTo NextRec
      End If
    End If

    'If Last paid date is before Asof date then use it
    If MyUtils.GetDBDate(._TXIDT) <= WrkAsofDt Then
      WrkPaid = ._PAYREC
      WrkPaidDt = MyUtils.GetDBDate(._TXIDT)
      GoTo CheckCC
    End If

    WrkHistFound = False
    Array.Clear(HstPamt, 0, 201)
    Array.Clear(HstPdate, 0, 201)
    Array.Clear(HstAdj, 0, 201)
    K = 0

    myTXHST.SetRange(._LISTNo, ._YEAR, ._TYPE, 0, False)
    Do While Not myTXHST.IsEOF
      myTXHST.ReadFileE()
      If myTXHST.IsEOF Then Exit Do
      With myTXHST
        WrkHistFound = True
        If ._RCODE <> "D" And ._RCODE <> "I" And ._RCODE <> "V" Then
          HstPdate(K) = MyUtils.GetDBDate(._PDATE)
          HstPamt(K) = ._PAMT
          If ._ADJCD = "A" Then
            HstAdj(K) = True
          End If
          K = K + 1
        End If
      End With
    Loop

    WrkAdjust = False
    If WrkHistFound Then
      For J = 0 To (K - 1)
        If HstPdate(J) > WrkAsofDt Then Exit For
        WrkPaid = WrkPaid + HstPamt(J)
        If HstPamt(J) > 0 Then
          WrkPaidDt = HstPdate(J)
        End If
        If HstAdj(J) Then
          WrkAdjust = True
        End If
      Next
    End If

CheckAdj:
    If WrkAdjust And WrkHistFound Then
      For J = (K - 1) To 0 Step -1
        If Not HstAdj(J) Then Exit For
        WrkAdjustPaid = WrkAdjustPaid + HstPamt(J)
        If HstPamt(J) > 0 And HstPdate(J) > WrkAsofDt Then
          WrkAdjustPaidDt = HstPdate(J)
        End If
      Next
    End If

    'No History then use invoice payment and last paid date
    If Not WrkHistFound Then
      WrkPaid = ._PAYREC
      WrkPaidDt = MyUtils.GetDBDate(._TXIDT)
    End If

CheckCC:
    WrkTaxt = ._TAXT
    If ._CCNO > 0 Then
      WrkFamily = GetTXTypeFamily(._TYPE)
      If MyUtils.GetDBDate(._CDATE) <= WrkAsofDt Then
        WrkTaxt = ._CCETAX
      Else
        If WrkFamily <> "U" Then
          myTXCOEA.SetRange(._LISTNo, ._YEAR, ._TYPE, 999999999, 999999, True)
          If Not myTXCOEA.IsEOF Then
            Do While Not myTXCOEA.IsEOF
              myTXCOEA.ReadFilePE()
              If myTXCOEA.IsEOF Then Exit Do
              With myTXCOEA
                If MyUtils.GetDBDate(._CDATE) <= WrkAsofDt Then
                  WrkTaxt = ._CETAX
                  Exit Do
                End If
              End With
            Loop
          End If
        Else
          myUTCOEA.SetRange(._LISTNo, ._YEAR, ._TYPE, 999999999, 999999, True)
          If Not myUTCOEA.IsEOF Then
            Do While Not myUTCOEA.IsEOF
              myUTCOEA.ReadFilePE()
              If myUTCOEA.IsEOF Then Exit Do
              With myUTCOEA
                If MyUtils.GetDBDate(._CDATE) <= WrkAsofDt Then
                  WrkTaxt = ._CETAX
                  Exit Do
                End If
              End With
            Loop
          End If
        End If
      End If
    End If

    WrkDue = WrkTaxt - WrkPaid
    If WrkTaxt = 0 Then GoTo NextRec
    If WrkDue <= 0 Then GoTo NextRec

    WrkTCount = WrkTCount + 1
    dr.Item("listno") = ._LISTNo
    dr.Item("year") = ._YEAR
    dr.Item("type") = ._TYPE
    dr.Item("name") = Trim(._NAME)
    dr.Item("addr1") = Trim(._ADD1)
    dr.Item("letter") = Left(._NAME, 1)
    dr.Item("tax") = WrkTaxt
    dr.Item("paid") = WrkPaid
    dr.Item("due") = WrkDue
    WrkTTax = WrkTTax + WrkTaxt
    WrkTPaid = WrkTPaid + WrkPaid
    WrkTDue = WrkTDue + WrkDue
  End With
  ds1.Tables(0).Rows.Add(dr)
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

WriteTotals(SaveYear, SaveType, SaveLetter)
myFrmProgress.Close()

CloseFiles:
myTXINVQ.CloseFile()
myTXHST.CloseFile()
myTXPROF.CloseFile()
myTXCOEA.CloseFile()
myUTCOEA.CloseFile()

End Sub
Private Sub WriteTotals(ByVal SaveYear As Integer, ByVal SaveType As String, ByVal SaveLetter As String)
  If WrkTCount = 0 Then Exit Sub

  dr2 = ds2.Tables(0).NewRow
  dr2.Item("tcount") = WrkTCount
  dr2.Item("year") = SaveYear
  dr2.Item("type") = SaveType
  dr2.Item("letter") = SaveLetter
  dr2.Item("ttax") = WrkTTax
  dr2.Item("tpaid") = WrkTPaid
  dr2.Item("tdue") = WrkTDue
  ds2.Tables(0).Rows.Add(dr2)
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
End Module






