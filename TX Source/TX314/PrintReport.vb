Imports System.io
Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINVQ As TXINVQ.myData
Dim myTXHST As TXHSTL1.myData

Dim ds As DataSet = New DataSet
Dim dsTot As DataSet = New DataSet
Dim DsTXHST As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkFromYear As Integer
Dim WrkToYear As Integer
Dim WrkCode As String
Dim WrkFrom As Integer
Dim WrkTo As Integer
Dim WrkAnd As String
Dim WrkSortBy As String
Dim WrkOr As String
'Type
Dim WrkCodes(50) As String
Dim WrkDesc(50) As String
Dim WrkFamily(50) As String
'Totals
Dim WrkTCount As Integer
Dim WrkTPaid As Decimal
Dim WrkTInterest As Decimal
Dim WrkTLien As Decimal
Dim WrkTPenalty As Decimal
'Files
Dim sw As StreamWriter
  Public Sub PrtReport()

	myTXINVQ = New TXINVQ.mydata(MyDBConnect)
	myTXHST = New TXHSTL1.mydata(MyDBConnect)

  With MyFrmTX314B
    WrkFromYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
    WrkToYear = MyUtils.CnvSng(.TxtToGLYear.Text)
    WrkCode = .TxtCode.Text
    WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
		If .RbSortList.Checked Then
			WrkSortBy = "List"
		End If
		If .RbSortName.Checked Then
			WrkSortBy = "Name"
		End If
	End With

    If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
    dsTot.Clear()
    ClearTotals()
  End If

  sw = New StreamWriter(MyFrmTX314B.LblFile.Text)

  BufferType()
  GetDetail()

Done:
  MyCRViewer = New FrmCrViewer
  With MyCRViewer
    .wrkds = ds
    .wrkdsTot = dsTot
    .WrkCode = WrkCode
    .Show()
  End With

  End Sub
Private Sub ClearTotals()
  WrkTCount = 0
  WrkTPaid = 0
  WrkTInterest = 0
  WrkTLien = 0
  WrkTPenalty = 0
End Sub
Private Sub GetDetail()
Dim sb As StringBuilder
Dim SaveQry As String
Dim WrkQry As String
Dim WrkSort As String
Dim Counter As Integer
Dim J As Integer
Dim SaveYear As Integer
Dim SaveType As String

Dim WrkList As Integer
Dim WrkType As String
Dim WrkYear As Integer
Dim WrkTXType As String()

Dim WrkName As String
Dim WrkSName As String
Dim WrkPaid As Decimal
Dim WrkInterest As Decimal
Dim WrkLien As Decimal
Dim WrkPenalty As Decimal
Dim WrkPDate As Integer
Dim WrkIntOver As Decimal

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
 End If

SaveQry = "icode<>'I'" & WrkAnd & "YEAR >= " & WrkFromYear & WrkAnd & "YEAR <= " & WrkToYear
WrkQry = SaveQry & WrkAnd & "STCD1= " & MyUtils.Quo(WrkCode)
WrkQry = WrkQry & WrkOr & SaveQry & WrkAnd & "STCD2= " & MyUtils.Quo(WrkCode)
WrkQry = WrkQry & WrkOr & SaveQry & WrkAnd & "STCD3= " & MyUtils.Quo(WrkCode)
WrkQry = WrkQry & WrkOr & SaveQry & WrkAnd & "STCD4= " & MyUtils.Quo(WrkCode)
WrkQry = WrkQry & WrkOr & SaveQry & WrkAnd & "STCD5= " & MyUtils.Quo(WrkCode)

WrkSort = "YEAR, TYPE"
SaveType = ""

myTXINVQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
	myTXINVQ.ReadQry()
	If Not myTXINVQ.IsEOF Then
	With myTXINVQ
		Counter = Counter + 1
		If SaveType <> "" And SaveType <> Trim(._TYPE) Or _
			SaveYear > 0 And SaveYear <> ._YEAR Then
			WriteTotals(SaveYear, SaveType)
			ClearTotals()
		End If

		SaveYear = ._YEAR
		SaveType = Trim(._TYPE)
		WrkList = ._LISTNo
		WrkType = Trim(._TYPE)
		WrkYear = ._YEAR
    WrkName = MyUtils.JustifyLeft(._NAME, 35)
    WrkSName = MyUtils.JustifyLeft(._SNAME, 35)
  End With

  DsTXHST = myTXHST.GetbyList(WrkList, WrkYear, WrkType, 9999)
  If DsTXHST.Tables(0).Rows.Count = 0 Then GoTo NextRec
  For J = 0 To DsTXHST.Tables(0).Rows.Count - 1
    With DsTXHST.Tables(0).Rows(J)
      WrkPDate = .Item("pdate")
      If WrkPDate >= WrkFrom Then
        If WrkPDate <= WrkTo Then
          If .Item("rcode") = "I" Then Continue For
          If .Item("rcode") = "V" Then Continue For
          WrkPaid = .Item("pamt")
          WrkInterest = .Item("iamt")
          WrkLien = .Item("lamt")
          WrkPenalty = .Item("pcamt")
          WrkIntOver = .Item("intor")
          If WrkPaid = 0 And WrkInterest = 0 And WrkLien = 0 And WrkPenalty = 0 Then Continue For
          dr = ds.Tables(0).NewRow
          Select Case WrkSortBy
          Case "Name"
            dr.Item("sortdata") = Trim(myTXINVQ._NAME)
          Case "List"
            dr.Item("sortdata") = Format(myTXINVQ._LISTNo, "000000")
          End Select
          dr.Item("listno") = WrkList
          dr.Item("year") = WrkYear
          WrkTXType = LookupType(WrkType)
          dr.Item("typedesc") = WrkTXType(0)
          dr.Item("name") = WrkName
          dr.Item("paid") = WrkPaid
          dr.Item("interest") = WrkInterest
          dr.Item("lien") = WrkLien
          dr.Item("penalty") = WrkPenalty
          dr.Item("pdate") = MyUtils.GetDBDate(WrkPDate)
          ds.Tables(0).Rows.Add(dr)

          WrkTCount = WrkTCount + 1
          WrkTPaid = WrkTPaid + WrkPaid
          WrkTInterest = WrkTInterest + WrkInterest
          WrkTLien = WrkTLien + WrkLien
          WrkTPenalty = WrkTPenalty + WrkPenalty

          sb = New StringBuilder
          sb.Append(Format(WrkList, "000000"))
          sb.Append(Format(WrkYear, "0000"))
          sb.Append(WrkType)
          sb.Append(Format(WrkPaid * 100, "00000000000"))
          sb.Append(Format(WrkInterest * 100, "0000000"))
          sb.Append(Format(WrkLien * 100, "00000"))
          sb.Append(MyUtils.JustifyLeft(.Item("corc"), 1))
          sb.Append(MyUtils.JustifyLeft(.Item("ref"), 10))
          sb.Append(MyUtils.JustifyLeft(.Item("comm"), 20))
          sb.Append(MyUtils.JustifyLeft(.Item("adjcd"), 1))
          sb.Append(Format(.Item("batchn"), "00000"))
          sb.Append(MyUtils.JustifyLeft(.Item("batcha"), 1))
          sb.Append(Format(.Item("pdate"), "00000000"))
          sb.Append(Format(.Item("cdate"), "00000000"))
          sb.Append(Format(WrkPenalty * 100, "000000000"))
          sb.Append(MyUtils.JustifyLeft(.Item("thajcd"), 1))
          sb.Append(MyUtils.JustifyLeft(.Item("thinpd"), 1))
          sb.Append(MyUtils.JustifyLeft(.Item("pencd"), 2))
          sb.Append(Format(WrkIntOver * 100, "0000000"))
          sb.Append(WrkName)
          sb.Append(WrkSName)
          sw.WriteLine(sb.ToString)
        End If
      End If
    End With
  Next

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
myTXINVQ.CloseFile()

End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTableTot As New DataTable
    With myTable
      .TableName = "mytable"
			.Columns.Add("SortData", Type.GetType("System.String"))
			.Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Paid", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Lien", Type.GetType("System.Decimal"))
      .Columns.Add("Penalty", Type.GetType("System.Decimal"))
      .Columns.Add("PDate", Type.GetType("System.DateTime"))
    End With
    ds.Tables.Add(myTable)

    With myTableTot
      .TableName = "mytabletot"
      .Columns.Add("TCount", Type.GetType("System.Int32"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("TPaid", Type.GetType("System.Decimal"))
      .Columns.Add("TInterest", Type.GetType("System.Decimal"))
      .Columns.Add("TLien", Type.GetType("System.Decimal"))
      .Columns.Add("TPenalty", Type.GetType("System.Decimal"))
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
  dr.Item("tpaid") = WrkTPaid
  dr.Item("tinterest") = WrkTInterest
  dr.Item("tlien") = WrkTLien
  dr.Item("tpenalty") = WrkTPenalty
  dsTot.Tables(0).Rows.Add(dr)
End Sub
Private Sub BufferType()
     Dim I As Integer

		 Dim myTXTYPE As TXTYPE.myData
     Dim dsTXType As DataSet = New DataSet

		 myTXTYPE = New TXTYPE.mydata(MyDBConnect)

     dsTXType = myTXTYPE.GetAllData
     For I = 0 To dsTXType.Tables(0).Rows.Count - 1
      With dsTXType.Tables(0).Rows(I)
        WrkCodes(I) = .Item("tycode")
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

     For I = 0 To WrkCodes.GetUpperBound(0)
       If WrkCodes(I) = "" Then
         Return WrkResult
       End If
       If Type = WrkCodes(I) Then
         WrkResult(0) = WrkDesc(I)
         WrkResult(1) = WrkFamily(I)
         Return WrkResult
       End If
    Next

    Return WrkResult
End Function

End Module






