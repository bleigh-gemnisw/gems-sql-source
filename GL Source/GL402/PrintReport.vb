Imports System.Text
Imports System.IO
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myLEDGERQ As LEDGERQ.myData
Dim myLEDHSTQ As LEDHSTQ.myData

Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkFundFrom As Integer
Dim WrkFundTo As Integer
Dim WrkSfundFrom As Integer
Dim WrkSfundTo As Integer
Dim WrkDeptFrom As Integer
Dim WrkDeptTo As Integer
Dim WrkObjFrom As Integer
Dim WrkObjTo As Integer
Dim WrkFuncFrom As Integer
Dim WrkFuncTo As Integer
Dim WrkTrtyp As String
Dim WrkBatchFrom As Integer
Dim WrkBatchTo As Integer
Dim WrkDateFrom As Integer
Dim WrkDateTo As Integer
Dim WrkAnd As String
Dim WrkOr As String
  Public Sub PrtReport()

  With MyFrmGL402B
    WrkDateFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    WrkDateTo = MyUtils.SetDBDate(.DtPckTo.Value)
    WrkFundFrom = MyUtils.CnvSng(.TxtFundFrom.Text)
    WrkFundTo = MyUtils.CnvSng(.TxtFundTo.Text)
    WrkSfundFrom = MyUtils.CnvSng(.TxtSfundFrom.Text)
    WrkSfundTo = MyUtils.CnvSng(.TxtSfundTo.Text)
    WrkDeptFrom = MyUtils.CnvSng(.TxtDeptFrom.Text)
    WrkDeptTo = MyUtils.CnvSng(.TxtDeptTo.Text)
    WrkObjFrom = MyUtils.CnvSng(.TxtObjFrom.Text)
    WrkObjTo = MyUtils.CnvSng(.TxtObjTo.Text)
    WrkFuncFrom = MyUtils.CnvSng(.TxtFuncFrom.Text)
    WrkFuncTo = MyUtils.CnvSng(.TxtFuncTo.Text)
    WrkBatchFrom = MyUtils.CnvSng(.TxtBatchFrom.Text)
    WrkBatchTo = MyUtils.CnvSng(.TxtBatchTo.Text)
    If .RbTypeAll.Checked Then WrkTrtyp = ""
    If .RbTypeAdjust.Checked Then WrkTrtyp = "X"
    If .RbTypeBudget.Checked Then WrkTrtyp = "B"
    If .RbTypeEncum.Checked Then WrkTrtyp = "E"
    If .RbTypeTransfer.Checked Then WrkTrtyp = "F"
  End With

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If
  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.ds = ds
  MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Acct", Type.GetType("System.String"))
      .Columns.Add("Bchno", Type.GetType("System.Int32"))
      .Columns.Add("Gltyp", Type.GetType("System.String"))
      .Columns.Add("Trtyp", Type.GetType("System.String"))
      .Columns.Add("Debit", Type.GetType("System.Decimal"))
      .Columns.Add("Credit", Type.GetType("System.Decimal"))
      .Columns.Add("Dated", Type.GetType("System.DateTime"))
      .Columns.Add("Tdesc", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Private Sub GetDetail()
Dim WrkQry As String
Dim WrkSort As String
Dim Counter As Integer

WrkAnd = " and "
WrkOr = " or "

myLEDGERQ = New LEDGERQ.MyData()
myLEDGERQ.MyDBConn = myDBConnect

Counter = 0
WrkQry = "PSTDT >= " & WrkDateFrom & WrkAnd & "PSTDT <= " & WrkDateTo & WrkAnd & "SRCDE = 2"
If WrkTrtyp <> "" And WrkTrtyp <> "F" Then
  WrkQry = WrkQry & WrkAnd & "TRTYP = " & MyUtils.Quo(WrkTrtyp)
End If
If WrkTrtyp = "F" Then
  WrkQry = WrkQry & WrkAnd & "TRTYP = 'B' and TRFTO IN('F','T')"
End If
If WrkFundFrom > 0 Then
  WrkQry = WrkQry & WrkAnd & "FDNBR >= " & WrkFundFrom
End If
If WrkFundTo > 0 Then
  WrkQry = WrkQry & WrkAnd & "FDNBR <= " & WrkFundTo
End If
If WrkSfundFrom > 0 Then
  WrkQry = WrkQry & WrkAnd & "SFUND >= " & WrkSfundFrom
End If
If WrkSfundTo > 0 Then
  WrkQry = WrkQry & WrkAnd & "SFUND <= " & WrkSfundTo
End If
If WrkDeptFrom > 0 Then
  WrkQry = WrkQry & WrkAnd & "DPNBR >= " & WrkDeptFrom
End If
If WrkDeptTo > 0 Then
  WrkQry = WrkQry & WrkAnd & "DPNBR <= " & WrkDeptTo
End If
If WrkObjFrom > 0 Then
  WrkQry = WrkQry & WrkAnd & "OBNBR >= " & WrkObjFrom
End If
If WrkObjTo > 0 Then
  WrkQry = WrkQry & WrkAnd & "OBNBR <= " & WrkObjTo
End If
If WrkFuncFrom > 0 Then
  WrkQry = WrkQry & WrkAnd & "FNPGM >= " & WrkFuncFrom
End If
If WrkFuncTo > 0 Then
  WrkQry = WrkQry & WrkAnd & "FNPGM <= " & WrkFuncTo
End If
If WrkBatchFrom > 0 Then
  WrkQry = WrkQry & WrkAnd & "BCHNO >= " & WrkBatchFrom
End If
If WrkBatchTo > 0 Then
  WrkQry = WrkQry & WrkAnd & "BCHNO <= " & WrkBatchTo
End If
WrkSort = "FDNBR, SFUND, BCHNO, PSTDT"
'WrkSort = "FDNBR, SFUND, TRNBR, PSTDT"
myLEDGERQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myLEDGERQ.ReadQry()
  If Not myLEDGERQ.IsEOF Then
  With myLEDGERQ
    Counter = Counter + 1
    dr = ds.Tables(0).NewRow
    dr.Item("acct") = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
    dr.Item("bchno") = ._BCHNO
'    dr.Item("bchno") = ._TRNBR
    dr.Item("gltyp") = ._GLTYP
    dr.Item("trtyp") = ._TRTYP
    If ._AMTYP = "D" Then
      dr.Item("debit") = ._TRAMT
    Else
      dr.Item("credit") = ._TRAMT
    End If
    dr.Item("tdesc") = Trim(._TDESC)
    dr.Item("dated") = MyUtils.GetDBDate(._PSTDT)
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
    End With
    GoTo ReadNext
  End If

myFrmProgress.Close()
myLEDGERQ.CloseFile()
End Sub
Private Sub GetDetailHst()
Dim WrkQry As String
Dim WrkSort As String
Dim Counter As Integer

WrkAnd = " and "
WrkOr = " or "

myLEDHSTQ = New LEDHSTQ.MyData()
myLEDHSTQ.MyDBConn = myDBConnect

Counter = 0
WrkQry = "PSTDT >= " & WrkDateFrom & WrkAnd & "PSTDT <= " & WrkDateTo & WrkAnd & "SRCDE = 2"
If WrkTrtyp <> "" And WrkTrtyp <> "F" Then
  WrkQry = WrkQry & WrkAnd & "TRTYP = " & MyUtils.Quo(WrkTrtyp)
End If
If WrkTrtyp = "F" Then
  WrkQry = WrkQry & WrkAnd & "TRTYP = 'B' and TRFTO='F'"
End If
If WrkFundFrom > 0 Then
  WrkQry = WrkQry & WrkAnd & "FDNBR >= " & WrkFundFrom
End If
If WrkFundTo > 0 Then
  WrkQry = WrkQry & WrkAnd & "FDNBR <= " & WrkFundTo
End If
If WrkSfundFrom > 0 Then
  WrkQry = WrkQry & WrkAnd & "SFUND >= " & WrkSfundFrom
End If
If WrkSfundTo > 0 Then
  WrkQry = WrkQry & WrkAnd & "SFUND <= " & WrkSfundTo
End If
If WrkDeptFrom > 0 Then
  WrkQry = WrkQry & WrkAnd & "DPNBR >= " & WrkDeptFrom
End If
If WrkDeptTo > 0 Then
  WrkQry = WrkQry & WrkAnd & "DPNBR <= " & WrkDeptTo
End If
If WrkObjFrom > 0 Then
  WrkQry = WrkQry & WrkAnd & "OBNBR >= " & WrkObjFrom
End If
If WrkObjTo > 0 Then
  WrkQry = WrkQry & WrkAnd & "OBNBR <= " & WrkObjTo
End If
WrkSort = "FDNBR, SFUND, BCHNO, PSTDT"
myLEDHSTQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()


ReadNext:
  myLEDHSTQ.ReadQry()
  If Not myLEDHSTQ.IsEOF Then
  With myLEDHSTQ
    Counter = Counter + 1
    dr = ds.Tables(0).NewRow
    dr.Item("acct") = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
    dr.Item("bchno") = ._BCHNO
    dr.Item("gltyp") = ._GLTYP
    dr.Item("trtyp") = ._TRTYP
    If ._AMTYP = "D" Then
      dr.Item("debit") = ._TRAMT
    Else
      dr.Item("credit") = ._TRAMT
    End If
    dr.Item("tdesc") = Trim(._TDESC)
    dr.Item("dated") = MyUtils.GetDBDate(._PSTDT)
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
    End With
    GoTo ReadNext
  End If

myFrmProgress.Close()
myLEDHSTQ.CloseFile()
End Sub
End Module
