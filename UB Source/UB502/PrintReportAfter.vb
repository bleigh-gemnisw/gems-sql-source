Imports System.Text
Module PrintReportAfter

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myUTCOEAQ As UTCOEAQ.MyData
Dim myUTCUST As UTCUST.myData
Dim myUTCUSTRT As UTCUSTRT.myData
Dim myUTCUSTAS As UTCUSTAS.myData
Dim myTXINV As TXINV.myData
Dim myUBCalcBillA As UBCalcBill.BillAssessment
Dim ds As DataSet = New DataSet
Dim dstot As DataSet = New DataSet
Dim dr As Data.DataRow
Dim drtot As Data.DataRow

Dim WrkType As String
Dim WrkFromYear As Integer
Dim WrkToYear As Integer
Dim WrkFrom As Integer
Dim WrkTo As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkFromReason As String
Dim WrkToReason As String
Dim WrkOrigAssmnt As Decimal
Dim WrkAssmntLeft As Decimal

Dim WrkTCount As Integer
Dim WrkTBondIncr As Decimal
Dim WrkTBondDecr As Decimal
Dim WrkTBondDiff As Decimal
Dim WrkTDueIncr As Decimal
Dim WrkTDueDecr As Decimal
Dim WrkTDueDiff As Decimal
Dim WrkTOrigAsmt As Decimal
Public Sub PrtReportAfter()
  myUTCOEAQ = New UTCOEAQ.mydata(MyDBConnect)
  myUTCUST = New UTCUST.mydata(MyDBConnect)
  myUTCUSTRT = New UTCUSTRT.mydata(MyDBConnect)
  myUTCUSTAS = New UTCUSTAS.mydata(MyDBConnect)
  myTXINV = New TXINV.mydata(MyDBConnect)
    myUBCalcBillA = New UBCalcBill.BillAssessment(myDBConnect)

    With MyFrmUB502B
    WrkType = .TxtType.Text
    WrkFromYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
    WrkToYear = MyUtils.CnvSng(.TxtToGLYear.Text)
    WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    WrkDistAll = False
    If .TxtDist.Text = "" Then
      WrkDistAll = True
    End If
    WrkFromReason = .TxtFromReason.Text
    WrkToReason = .TxtToReason.Text
  End With

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
    dstot.Clear()
    ClearTotals()
  End If

  GetDetail()

Done:

  MyCrViewer = New FrmCrViewer
  MyCrViewer.Wrkds = ds
  MyCrViewer.Wrkdstot = dstot
  MyCrViewer.Show()

End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("CCNo", Type.GetType("System.Int32"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("ReasonDesc", Type.GetType("System.String"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("CDate", Type.GetType("System.DateTime"))
      .Columns.Add("OrigBond", Type.GetType("System.Decimal"))
      .Columns.Add("NewBond", Type.GetType("System.Decimal"))
      .Columns.Add("ChgBond", Type.GetType("System.Decimal"))
      .Columns.Add("OrigDue", Type.GetType("System.Decimal"))
      .Columns.Add("NewDue", Type.GetType("System.Decimal"))
      .Columns.Add("ChgDue", Type.GetType("System.Decimal"))
      .Columns.Add("OrigAsmt", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)

    With myTable2
      .TableName = "mytable2"
      .Columns.Add("tcount", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("year", Type.GetType("System.Int32"))
      .Columns.Add("tbondincr", Type.GetType("System.Decimal"))
      .Columns.Add("tbonddecr", Type.GetType("System.Decimal"))
      .Columns.Add("tbonddiff", Type.GetType("System.Decimal"))
      .Columns.Add("tdueincr", Type.GetType("System.Decimal"))
      .Columns.Add("tduedecr", Type.GetType("System.Decimal"))
      .Columns.Add("tduediff", Type.GetType("System.Decimal"))
      .Columns.Add("tOrigAsmt", Type.GetType("System.Decimal"))
    End With
    dstot.Tables.Add(myTable2)

  End Sub
Private Sub ClearTotals()
  WrkTCount = 0
  WrkTBondIncr = 0
  WrkTBondDecr = 0
  WrkTDueIncr = 0
  WrkTDueDecr = 0
  WrkTOrigAsmt = 0
End Sub
Private Sub GetDetail()
Dim WrkQry As String
Dim WrkSort As String
Dim Counter As Integer
Dim WrkAnd As String
Dim SaveType As String
Dim SaveYear As Integer
Dim SaveList As Integer

Dim Found As Boolean
Dim WrkDue As Double

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

Counter = 0
SaveYear = 0
SaveType = ""
SaveList = 0

WrkQry = "CDATE >= " & WrkFrom _
& WrkAnd & "CDATE <= " & WrkTo

If WrkType <> "" Then
  WrkQry = WrkQry & WrkAnd & "TYPE=" & MyUtils.Quo(WrkType)
End If

If WrkFromYear > 0 Then
  WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromYear _
  & WrkAnd & "YEAR <= " & WrkToYear
End If

If Not WrkDistAll Then
  WrkQry = WrkQry & WrkAnd & "DIST = " & WrkDist
End If

If WrkFromReason <> "" Then
  WrkQry = WrkQry & WrkAnd & "RSNCD >= '" & WrkFromReason & "'"
End If
If WrkToReason <> "" Then
  WrkQry = WrkQry & WrkAnd & "RSNCD <= '" & WrkToReason & "'"
End If

WrkSort = "TYPE, YEAR, NAME, LIST#"
myUTCOEAQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myUTCOEAQ.ReadQry()
  If Not myUTCOEAQ.IsEOF Then
  With myUTCOEAQ
    Counter = Counter + 1
    dr = ds.Tables(0).NewRow
    If SaveType <> "" And SaveType <> ._TYPE Or SaveYear > 0 And SaveYear <> ._YEAR Then
      WriteTotals(SaveType, SaveYear)
      ClearTotals()
      SaveList = 0
    End If
    SaveType = ._TYPE
    SaveYear = ._YEAR
    WrkTCount = WrkTCount + 1
    dr.Item("ccno") = ._CCNO
    dr.Item("listno") = ._LISTNO
    dr.Item("year") = ._YEAR
    dr.Item("type") = ._TYPE
    dr.Item("name") = Trim(._NAME)
    dr.Item("desc") = Trim(._CDESC)
    dr.Item("reasondesc") = GetUTCRESNDesc(._RSNCD)
    dr.Item("cdate") = MyUtils.GetDBDate(._CDATE)
    dr.Item("newBond") = ._CNBOND
    dr.Item("newdue") = ._CETAX
    GetPrevCC(Found, WrkDue)
    dr.Item("origBond") = ._COBOND
    dr.Item("origdue") = 0
    If Found Then
      dr.Item("origdue") = WrkDue
    Else
      myTXINV.GetOneRecordP(._LISTNO, ._YEAR, ._TYPE)
      If Not myTXINV.RecordNotFound Then
        With myTXINV
          dr.Item("origdue") = ._TAXT
        End With
      End If
    End If
    If Not myTXINV.RecordNotFound Or Found Then
      dr.Item("chgBond") = dr.Item("newBond") - dr.Item("origBond")
    Else
      dr.Item("chgbond") = 0
    End If
    dr.Item("chgdue") = dr.Item("newdue") - dr.Item("origdue")
    If dr.Item("chgdue") > 0 Then
      WrkTDueIncr = WrkTDueIncr + dr.Item("chgdue")
    Else
      WrkTDueDecr = WrkTDueDecr + dr.Item("chgdue")
    End If
    If dr.Item("chgBond") > 0 Then
      WrkTBondIncr = WrkTBondIncr + dr.Item("chgBond")
    Else
      WrkTBondDecr = WrkTBondDecr + dr.Item("chgBond")
    End If
    WrkOrigAssmnt = 0
    If SaveList <> ._LISTNO Then
      CalcAssmnt()
    End If
    dr.Item("origasmt") = WrkOrigAssmnt
    SaveList = ._LISTNO
  End With
  ds.Tables(0).Rows.Add(dr)
  WrkTOrigAsmt = WrkTOrigAsmt + WrkOrigAssmnt

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

WriteTotals(SaveType, SaveYear)
myFrmProgress.Close()

CloseFiles:
myUTCOEAQ.CloseFile()
myTXINV.CloseFile()

End Sub
  Public Sub GetPrevCC(ByRef Found As Boolean, ByRef Out_Due As Decimal)
    Dim myUTCOEAL1 As UTCOEAL1.myData
    Dim dsUTCOEAL1 As DataSet = New DataSet

    myUTCOEAL1 = New UTCOEAL1.mydata(MyDBConnect)

    Out_Due = 0
    Found = False
    With myUTCOEAQ
      dsUTCOEAL1 = myUTCOEAL1.GetViewDescList(._LISTNO, ._YEAR, ._TYPE, _
      ._CHDATE, ._CHTIME, 2)
    End With
    If dsUTCOEAL1.Tables(0).Rows.Count > 1 Then
      With dsUTCOEAL1.Tables(0).Rows(1)
        Found = True
        Out_Due = .Item("cetax")
      End With
    End If
  End Sub
Private Sub WriteTotals(ByVal SaveType As String, ByVal SaveYear As Integer)
  drtot = dstot.Tables(0).NewRow
  drtot.Item("tcount") = WrkTCount
  drtot.Item("type") = SaveType
  drtot.Item("year") = SaveYear
  drtot.Item("tbondincr") = WrkTBondIncr
  drtot.Item("tbonddecr") = WrkTBondDecr
  drtot.Item("tdueincr") = WrkTDueIncr
  drtot.Item("tduedecr") = WrkTDueDecr
  drtot.Item("tbonddiff") = WrkTBondIncr + WrkTBondDecr
  drtot.Item("tduediff") = WrkTDueIncr + WrkTDueDecr
  drtot.Item("torigasmt") = WrkTOrigAsmt
  dstot.Tables(0).Rows.Add(drtot)
End Sub
Private Sub CalcAssmnt()
'  WrkOrigAssmnt = 0
  WrkAssmntLeft = 0
  myUTCUSTAS.GetOneRecordP(myUTCOEAQ._LISTNO, WrkType)
  If myUTCUSTAS.RecordNotFound Then Exit Sub
  myUTCUST.GetOneRecordP(myUTCOEAQ._LISTNO)

  With myUBCalcBillA
    .In_RateType = WrkType
    .In_RateCode = GetRateCode(WrkType)
    .In_DwellUnits = myUTCUST._CUAUNT
    .In_PropVal = myUTCUST._CUPVAL
    .In_Footage = myUTCUST._CUFOOT
    .In_Acreage = myUTCUST._CUACRE
    .In_LateralFee = myUTCUSTAS._CALAT
    .In_UniformFee = myUTCUSTAS._CAUNIF
    .In_AssmntAdjust = myUTCUSTAS._CAADJ
    .In_DeferredAmt = myUTCUSTAS._CADEF
    .In_PrevBilled = myUTCUSTAS._CAAMT
    .CalcAssessment()
    WrkOrigAssmnt = MyUtils.FmtCurrency(.Out_OrigBill)
    WrkAssmntLeft = MyUtils.FmtCurrency(.Out_AmtLeft)
  End With
End Sub
Private Function GetRateCode(ByVal WrkUBType As String) As String
  GetRateCode = ""
  myUTCUSTRT.GetOneRecordP(myUTCOEAQ._LISTNO, WrkUBType)
  If myUTCUSTRT.RecordNotFound Then Exit Function

  With myUTCUSTRT
    GetRateCode = ._CRCODE
  End With
End Function
End Module






