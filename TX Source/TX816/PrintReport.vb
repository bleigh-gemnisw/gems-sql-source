Imports System.io
Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXHSTQ As TXHSTQ.myData
Dim myTXINV As TXINV.MyData

Dim ds As DataSet = New DataSet
Dim dsTot As DataSet = New DataSet
Dim DsTXHST As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkType As String
Dim WrkStsOmit As String
Dim WrkFromGLYear As Integer
Dim WrkToGLYear As Integer
Dim WrkFrom As Integer
Dim WrkTo As Integer
Dim WrkMVRegNo As Boolean
Dim WrkAnd As String
Dim WrkOr As String
'Type
Dim WrkCode(50) As String
Dim WrkDesc(50) As String
Dim WrkFamily(50) As String
'Totals
Dim WrkTCount As Integer

  Public Sub PrtReport()

	myTXHSTQ = New TXHSTQ.mydata(MyDBConnect)
	myTXINV = New TXINV.mydata(MyDBConnect)
  WrkMVRegNo = False

  With MyFrmTX816B
    WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
    WrkFromGLYear = MyUtils.CnvSng(.TxtGLFromYear.Text)
    WrkToGLYear = MyUtils.CnvSng(.TxtGLToYear.Text)
    If .ChkMVRegNo.Checked Then WrkMVRegNo = True
    WrkStsOmit = .TxtOmit.Text
  End With

  If dsTot.Tables.Count = 0 Then
    BuildDS(ds)
    BuildDSTot()
  Else
    dsTot.Clear()
    ClearTotals()
  End If

  BufferType()
  GetDetail()

Done:
  MyCRViewer = New FrmCrViewer
  With MyCRViewer
    .wrkdsTot = dsTot
    .Show()
  End With

  End Sub
Private Sub ClearTotals()
  WrkTCount = 0
End Sub
  Private Sub GetDetail()
    Dim sb As StringBuilder
    Dim sw As StreamWriter = New StreamWriter(MyFrmTX816B.LblFilePath.Text)
    Dim WrkQry As String
    Dim WrkSort As String
    Dim SaveYear As Integer
    Dim SaveType As String

    Dim WrkList As Integer
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkTypes As String
    Dim WrkTotAmt As Decimal
    Dim WrkPropDesc As String
    Dim WrkFamily As String
    Dim WrkTXType As String()
    Dim WrkStr As String
    Dim Counter As Integer
    Dim Pos As Integer
    'Dim wrkinteger As Integer
    'Dim wrkstring As String

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkQry = "RCODE <> 'I'" & WrkAnd & "RCODE <>'V'" & WrkAnd &
  "PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo
    'Filter Grand List Years
    If WrkFromGLYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "year>=" & WrkFromGLYear
    End If
    If WrkToGLYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "year<=" & WrkToGLYear
    End If

    MyTypes = MyFrmTX816B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    WrkSort = "YEAR, TYPE"
    Counter = 0
    myTXHSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    SaveType = ""
ReadNext:
    myTXHSTQ.ReadQry()
    If Not myTXHSTQ.IsEOF Then
      With myTXHSTQ
        Counter = Counter + 1
        If SaveType <> "" And SaveType <> ._TYPE Then
          WriteTotals(SaveYear, SaveType)
          ClearTotals()
          SaveYear = ._YEAR
          SaveType = ._TYPE
        End If
        If SaveYear > 0 And SaveYear <> ._YEAR Then
          WriteTotals(SaveYear, SaveType)
          ClearTotals()
        End If

        SaveYear = ._YEAR
        SaveType = ._TYPE
        WrkList = ._LISTNo
        WrkType = ._TYPE
        WrkYear = ._YEAR
      End With

      'Write to CSV file
      dr = ds.Tables(0).NewRow
      dr.Item("townbr") = myTOWN._TOWNBR
      dr.Item("listno") = WrkList
      dr.Item("year") = WrkYear
      WrkTXType = LookupType(WrkType)
      dr.Item("typedesc") = WrkTXType(0)
      myTXINV.GetOneRecordP(WrkList, WrkYear, WrkType)
      With myTXINV
        If Trim(WrkStsOmit) > "" Then   ' omit status codes
          Pos = 0
          If Trim(._STCD1) <> "" Then
            Pos = InStr(1, WrkStsOmit, Trim(._STCD1), 1)
          End If
          If Pos = 0 And Trim(._STCD2) <> "" Then
            Pos = InStr(1, WrkStsOmit, Trim(._STCD2), 1)
          End If
          If Pos = 0 And Trim(._STCD3) <> "" Then
            Pos = InStr(1, WrkStsOmit, Trim(._STCD3), 1)
          End If
          If Pos = 0 And Trim(._STCD4) <> "" Then
            Pos = InStr(1, WrkStsOmit, Trim(._STCD4), 1)
          End If
          If Pos = 0 And Trim(._STCD5) <> "" Then
            Pos = InStr(1, WrkStsOmit, Trim(._STCD5), 1)
          End If
          If Pos > 0 Then
            GoTo NextRec
          End If
        End If
        WrkStr = Replace(Trim(._NAME), "'", "")
        WrkStr = Replace(WrkStr, ",", "")
        dr.Item("name") = WrkStr & ""
        WrkStr = Replace(Trim(._SNAME), "'", "")
        WrkStr = Replace(WrkStr, ",", "")
        dr.Item("sname") = WrkStr & ""
        dr.Item("add1") = Trim(._ADD1) & ""
        dr.Item("add2") = Trim(._ADD2) & ""
        dr.Item("city") = Trim(._CITY) & ""
        dr.Item("state") = Trim(._STATE) & ""
        dr.Item("zip5") = Format(._ZIP5, "00000")
        dr.Item("zip4") = Format(._ZIP4, "0000")
        dr.Item("locno") = Trim(._LOCNo) & ""
        dr.Item("loc") = Trim(._LOC) & ""
        If WrkMVRegNo Then
          dr.Item("imvreg") = Trim(._IMVREG) & ""
        Else
          dr.Item("imvreg") = String.Empty
        End If
        WrkFamily = WrkTXType(1)
        WrkPropDesc = ""
        Select Case WrkFamily
          Case "M", "S"
            If WrkMVRegNo Then
              WrkPropDesc = Trim(._IMVREG) & " "
            End If
            WrkPropDesc = WrkPropDesc & Trim(._MAKE) & " " & Trim(._MODEL) & " " & ._MVYR
          Case Else
            WrkPropDesc = Trim(._LOCNo) & " " & Trim(._LOC)
        End Select
        dr.Item("propdesc") = WrkPropDesc & ""
      End With
      With myTXHSTQ
        dr.Item("pamt") = Format(._PAMT, "fixed")
        dr.Item("iamt") = Format(._IAMT, "fixed")
        dr.Item("lamt") = Format(._LAMT, "fixed")
        dr.Item("pcamt") = Format(._PCAMT, "fixed")
        WrkTotAmt = ._PAMT + ._IAMT + ._LAMT + ._PCAMT
        dr.Item("totamt") = Format(WrkTotAmt, "fixed")
        dr.Item("corc") = Trim(._CORC) & ""
        dr.Item("ref") = Trim(._REF) & ""
        WrkStr = Trim(._COMM) & ""
        WrkStr = Replace(WrkStr, "'", "")
        WrkStr = Replace(WrkStr, ",", "")
        WrkStr = Replace(WrkStr, Chr(34), "") 'Remove double quotes
        dr.Item("comm") = WrkStr & ""
        dr.Item("adjcd") = Trim(._ADJCD) & ""
        dr.Item("pdate") = Format(MyUtils.GetDBDate(._PDATE), "M/dd/yyyy")
        dr.Item("recid") = 0
        ds.Tables(0).Rows.Add(dr)
        sb = New StringBuilder
        sb.Append(ExportRecord(False, ds))
        sw.WriteLine(sb.ToString)
        ds.Clear()
      End With
      WrkTCount = WrkTCount + 1

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

    WriteTotals(SaveYear, SaveType)
    sw.Close()
    myFrmProgress.Close()
    myTXHSTQ.CloseFile()

  End Sub
  Private Sub BuildDSTot()
    Dim myTableTot As New DataTable

    With myTableTot
      .TableName = "mytabletot"
      .Columns.Add("TCount", Type.GetType("System.Int32"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
    End With
    dsTot.Tables.Add(myTableTot)
  End Sub
Private Sub WriteTotals(ByVal SaveYear As Integer, ByVal SaveType As String)
  Dim WrkTXType As String()
  If WrkTCount = 0 Then Exit Sub

  dr = dsTot.Tables(0).NewRow
  dr.Item("tcount") = WrkTCount
  dr.Item("year") = SaveYear
  WrkTXType = LookupType(SaveType)
  dr.Item("typedesc") = WrkTXType(0)
  dsTot.Tables(0).Rows.Add(dr)
  dr = Nothing
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
Public Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Townbr", Type.GetType("System.Int32"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("SName", Type.GetType("System.String"))
      .Columns.Add("Add1", Type.GetType("System.String"))
      .Columns.Add("Add2", Type.GetType("System.String"))
      .Columns.Add("City", Type.GetType("System.String"))
      .Columns.Add("State", Type.GetType("System.String"))
      .Columns.Add("Zip5", Type.GetType("System.String"))
      .Columns.Add("Zip4", Type.GetType("System.String"))
      .Columns.Add("LocNo", Type.GetType("System.String"))
      .Columns.Add("Loc", Type.GetType("System.String"))
      .Columns.Add("ImvReg", Type.GetType("System.String"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("PAmt", Type.GetType("System.String"))
      .Columns.Add("IAmt", Type.GetType("System.String"))
      .Columns.Add("LAmt", Type.GetType("System.String"))
      .Columns.Add("PCAmt", Type.GetType("System.String"))
      .Columns.Add("TotAmt", Type.GetType("System.String"))
      .Columns.Add("CORC", Type.GetType("System.String"))
      .Columns.Add("Ref", Type.GetType("System.String"))
      .Columns.Add("Comm", Type.GetType("System.String"))
      .Columns.Add("AdjCd", Type.GetType("System.String"))
      .Columns.Add("PDate", Type.GetType("System.String"))
      .Columns.Add("RecID", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
End Sub
End Module






