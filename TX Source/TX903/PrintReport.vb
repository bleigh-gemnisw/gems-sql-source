Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINVQ As TXINVQ.myData
Dim myTXHST As TXHSTL4.myData
Dim ds1 As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim DsTXINV As DataSet = New DataSet
Dim DsTXHST As DataSet = New DataSet
Dim dr As Data.DataRow
Dim dr2 As Data.DataRow

Dim WrkType As String
Dim WrkFromGLYear As Integer
Dim WrkToGLYear As Integer
Dim WrkFrom As Integer
Dim WrkTo As Integer
Dim WrkSuspCd As String
Dim WrkAnd As String
Dim WrkOr As String

Dim WrkTCount As Integer
Dim WrkTTaxAmt As Decimal
Dim WrkTSuspAmt As Decimal
Public Sub PrtReport()

	myTXINVQ = New TXINVQ.mydata(MyDBConnect)
	myTXHST = New TXHSTL4.mydata(MyDBConnect)

  With MyFrmTX903B
    WrkFromGLYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
    WrkToGLYear = MyUtils.CnvSng(.TxtToGLYear.Text)
    WrkFrom = 0
    If .DtPckFrom.Checked Then
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    End If
    WrkTo = 0
    If .DtPckTo.Checked Then
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
    End If
    WrkSuspCd = .TxtSusp.Text
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
      .Columns.Add("TaxAmt", Type.GetType("System.Decimal"))
      .Columns.Add("SuspAmt", Type.GetType("System.Decimal"))
      .Columns.Add("SuspDt", Type.GetType("System.String"))
      .Columns.Add("SuspCd", Type.GetType("System.String"))
    End With
    ds1.Tables.Add(myTable)

    With myTable2
      .TableName = "mytable2"
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("TCount", Type.GetType("System.Int32"))
      .Columns.Add("TTaxAmt", Type.GetType("System.Decimal"))
      .Columns.Add("TSuspAmt", Type.GetType("System.Decimal"))
    End With
    ds2.Tables.Add(myTable2)

  End Sub
Private Sub ClearTotals()
  WrkTCount = 0
  WrkTTaxAmt = 0
  WrkTSuspAmt = 0
End Sub
  Private Sub GetDetail()
    Dim WrkSort As String
    Dim WrkQry As String
    Dim I As Integer
    Dim J As Integer
    Dim SaveYear As Integer
    Dim SaveType As String
    Dim WrkTaxAmt As Decimal
    Dim WrkSuspAmt As Decimal
    Dim WrkSuspdate As Date
    Dim ChkDate As Date

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkQry = "ICODE ='S'"
    If WrkFromGLYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromGLYear _
  & WrkAnd & "YEAR <= " & WrkToGLYear
    End If
    If WrkFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "SUSDT >= " & WrkFrom
    End If
    If WrkTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "SUSDT <= " & WrkTo
    End If
    If WrkSuspCd <> "" Then
      WrkQry = WrkQry & WrkAnd & "SUSCD = " & MyUtils.Quo(WrkSuspCd)
    End If

    MyTypes = MyFrmTX903B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    WrkSort = "YEAR, TYPE"
    DsTXINV = myTXINVQ.GetQry(WrkSort, WrkQry, 0)
    If DsTXINV.Tables(0).Rows.Count = 0 Then GoTo CloseFiles
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    SaveType = ""
    For I = 0 To (DsTXINV.Tables(0).Rows.Count - 1)
      With DsTXINV.Tables(0).Rows(I)
        dr = ds1.Tables(0).NewRow
        If SaveType <> "" And SaveType <> .Item("type") Then
          WriteTotals(SaveYear, SaveType)
          ClearTotals()
        End If
        If SaveYear > 0 And SaveYear <> .Item("year") Then
          WriteTotals(SaveYear, SaveType)
          ClearTotals()
        End If
        SaveYear = .Item("year")
        SaveType = .Item("type")

        WrkTaxAmt = 0
        WrkSuspAmt = 0
        WrkTCount = WrkTCount + 1
        dr.Item("listno") = .Item("list#")
        dr.Item("year") = .Item("year")
        dr.Item("type") = .Item("type")
        dr.Item("name") = .Item("name")
        DsTXHST = myTXHST.GetViewbyList(.Item("list#"), .Item("year"), .Item("type"), 0, 999)
        For J = 0 To DsTXHST.Tables(0).Rows.Count - 1
          With DsTXHST.Tables(0).Rows(J)
            If .Item("rcode") = "I" And .Item("batcha") = "S" Then
              WrkSuspAmt = .Item("pcamt")
              WrkSuspdate = MyUtils.GetDBDate(.Item("pdate"))
            End If
          End With
        Next
        If .Item("ccno") > 0 Then
          WrkTaxAmt = .Item("ccetax")
        Else
          WrkTaxAmt = .Item("taxt")
        End If
        dr.Item("taxamt") = WrkTaxAmt
        dr.Item("suspamt") = WrkSuspAmt
        If .Item("susdt") > 0 Then
          dr.Item("suspdt") = Format(MyUtils.GetDBDate(.Item("susdt")), "M/dd/yyyy")
        Else
          If WrkSuspdate <> ChkDate Then
            dr.Item("suspdt") = Format(WrkSuspdate, "M/dd/yyyy")
          End If
        End If
        dr.Item("suspcd") = .Item("suscd")

        WrkTTaxAmt = WrkTTaxAmt + WrkTaxAmt
        WrkTSuspAmt = WrkTSuspAmt + WrkSuspAmt
      End With
      ds1.Tables(0).Rows.Add(dr)
NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsTXINV.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    WriteTotals(SaveYear, SaveType)
    myFrmProgress.Close()

CloseFiles:
    myTXINVQ.CloseFile()
  End Sub
  Private Sub WriteTotals(ByVal SaveYear As Integer, ByVal SaveType As String)
  If WrkTCount = 0 Then Exit Sub

  dr2 = ds2.Tables(0).NewRow
  dr2.Item("tcount") = WrkTCount
  dr2.Item("year") = SaveYear
  dr2.Item("type") = SaveType
  dr2.Item("ttaxamt") = WrkTTaxAmt
  dr2.Item("tsuspamt") = WrkTSuspAmt
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






