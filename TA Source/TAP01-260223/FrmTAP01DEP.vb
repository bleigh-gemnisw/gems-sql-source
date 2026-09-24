Public Class FrmTAP01DEP
  Dim MyTXDCCD As TXDCCD.myData
  Dim MyTXDCDEP As TXDCDEP.myData
  Dim MyTXDCDTL As TXDCDTL.myData
  Dim MyTXDCSUM As TXDCSUM.myData
  Dim WrkTotCost As Integer
  Dim WrkTotProrated As Integer
  Dim WrkTotValue As Integer
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Private Sub FrmTAP01DEP_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP01
      .TBarDecl.Enabled = False
      .TBarDepr.Enabled = True
      .TBarDelete.Enabled = True
      .TBarSave.Enabled = True
    End With
End Sub
Private Sub FrmTAP01DEP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDCCD = New TXDCCD.mydata(MyDBConnect)
    MyTXDCDEP = New TXDCDEP.mydata(MyDBConnect)
    MyTXDCDTL = New TXDCDTL.mydata(MyDBConnect)
    MyTXDCSUM = New TXDCSUM.mydata(MyDBConnect)

    With MyFrmTAP01
      .TBarDecl.Enabled = True
      .TBarDepr.Enabled = False
      .TBarDelete.Enabled = False
      .TBarSave.Enabled = False
    End With

    LblListNo.Text = WrkListNo
    LblYear.Text = WrkYear
    C1DataGrdList.Visible = False
    BuildDS(ds)

End Sub
  Private Sub FrmTAP01DEP_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "TAP01DEP"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub

  Private Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("YearEnd", Type.GetType("System.String"))
      .Columns.Add("DeYear", Type.GetType("System.Int16"))
      .Columns.Add("Cost", Type.GetType("System.Int32"))
      .Columns.Add("ProPct", Type.GetType("System.Int32"))
      .Columns.Add("Prorated", Type.GetType("System.Int32"))
      .Columns.Add("Pct", Type.GetType("System.Int32"))
      .Columns.Add("Value", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
  End Sub

Private Sub LnkCode1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
		MyFrmListCodes.WrkYear = WrkYear
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode.Text)
    MyFrmListCodes.WrkLtr = TxtLtr.Text
    MyFrmListCodes.WrkScreen = "DEP"
    MyFrmListCodes.Show()
    C1DataGrdList.Visible = False
End Sub
Public Sub BuildGrid()
    Dim myDr As Data.DataRow
    Dim I As Integer

    ds.Clear()
    WrkTotCost = 0
    WrkTotProrated = 0
    WrkTotValue = 0
    For I = 0 To 15
      AddOneRecord(TxtCode.Text, TxtLtr.Text, WrkYear - I, I + 1)
      If MyTXDCDEP._PRIOR = "Y" Then Exit For
    Next

    myDr = ds.Tables(0).NewRow
    myDr("YearEnd") = "Total"
    myDr("DeYear") = 0
    myDr("Cost") = WrkTotCost
    myDr("ProPct") = 0
    myDr("Prorated") = WrkTotProrated
    myDr("Pct") = 0
    myDr("Value") = WrkTotValue
    ds.Tables(0).Rows.Add(myDr)

    ShowGrid()
    MyTXDCSUM.GetOneRecordP(WrkListNo, WrkYear, TxtCode.Text)
    If MyTXDCSUM._STATUS = "K" Or WrkTotValue <> MyTXDCSUM._VALUE Then
      LblTxtSummary.Visible = True
      LblSummary.Visible = True
      LblSummary.Text = MyTXDCSUM._VALUE
      MsgBox("WARNING: Summary Value has been overridden. Verify summary after changes then manually override as needed.", MsgBoxStyle.Exclamation, "Manual Entry")
    End If
End Sub
Sub AddOneRecord(ByVal WrkCode As Integer, ByVal WrkLtr As String, ByVal WrkDeprYear As Integer, _
    ByVal WrkYearNo As Integer)
    Dim myDr As Data.DataRow
    Dim WrkProrated As Integer
    Dim WrkValue As Integer

    MyTXDCDTL.GetOneRecordP(WrkListNo, WrkYear, WrkCode, WrkLtr, WrkDeprYear)
    MyTXDCCD.GetOneRecordP(WrkYear, WrkCode, WrkLtr)
    MyTXDCDEP.GetOneRecordP(WrkYear, MyTXDCCD._DECODE, WrkYearNo)
    With MyTXDCDTL
      If MyTXDCDEP._PCT = 0 Then Exit Sub
      myDr = ds.Tables(0).NewRow
      If MyTXDCDEP._PRIOR = "Y" Then
        myDr("YearEnd") = "Prior Yrs"
      Else
        myDr("YearEnd") = "10-1-" & Mid(WrkDeprYear, 3, 2)
      End If
      If .RecordNotFound Then
        myDr("DeYear") = WrkDeprYear
        myDr("Cost") = 0
        myDr("ProPct") = MyTXDCDEP._PROPCT
        myDr("Prorated") = 0
        myDr("Pct") = MyTXDCDEP._PCT
        myDr("Value") = 0
      Else
        myDr("DeYear") = ._DEYEAR
        myDr("Cost") = ._DECOST
        myDr("ProPct") = MyTXDCDEP._PROPCT
        If MyTXDCDEP._PROPCT > 0 Then
          WrkProrated = MyUtils.Round(._DECOST * (MyTXDCDEP._PROPCT / 100), 0)
        Else
          WrkProrated = ._DECOST
        End If
        myDr("prorated") = WrkProrated
        myDr("Pct") = MyTXDCDEP._PCT
        WrkValue = MyUtils.Round(WrkProrated * (MyTXDCDEP._PCT / 100), 0)
        myDr("Value") = WrkValue
        WrkTotCost = WrkTotCost + ._DECOST
        WrkTotProrated = WrkTotProrated + WrkProrated
        WrkTotValue = WrkTotValue + WrkValue
      End If
      ds.Tables(0).Rows.Add(myDr)
    End With
End Sub
    Public Sub ShowGrid()
     Dim I As Integer
     Windows.Forms.Cursor.Current = Cursors.WaitCursor

     With C1DataGrdList
      .DataSource = ds.Tables(0)
      .Refresh()
      .Columns(0).Caption = "Year Ending"
      .Splits(0).DisplayColumns(0).Width = 70
      .Splits(0).DisplayColumns(0).Locked = True
      .Splits(0).DisplayColumns(0).Style.BackColor = cLightBlue
      .Splits(0).DisplayColumns(1).Visible = False
      .Columns(2).Caption = "Cost"
      .Splits(0).DisplayColumns(2).Width = 50
      If .Columns(3).Value > 0 Then
        .Columns(3).Caption = "% Value"
        .Splits(0).DisplayColumns(3).Width = 50
        .Columns(3).NumberFormat = "##"
        .Columns(4).Caption = "Prorated"
        .Splits(0).DisplayColumns(4).Width = 50
        .Splits(0).DisplayColumns(3).Visible = True
        .Splits(0).DisplayColumns(4).Visible = True
      Else
        .Splits(0).DisplayColumns(3).Visible = False
        .Splits(0).DisplayColumns(4).Visible = False
      End If
      .Columns(5).Caption = "% Good"
      .Splits(0).DisplayColumns(5).Width = 50
      .Columns(5).NumberFormat = "##"
      .Columns(6).Caption = "Depr Value"
      .Splits(0).DisplayColumns(6).Width = 50
      For I = 3 To 6
        .Splits(0).DisplayColumns(I).Locked = True
        .Splits(0).DisplayColumns(I).Style.BackColor = cLightBlue
      Next
     End With
     Windows.Forms.Cursor.Current = Cursors.Default

    End Sub
  Private Sub C1DataGrdList_FetchRowStyle(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles C1DataGrdList.FetchRowStyle
     If C1DataGrdList.Columns("yearend").CellValue(e.Row) = "Total" Then
       e.CellStyle.BackColor = System.Drawing.Color.Pink
       e.CellStyle.Locked = True
     End If
  End Sub

Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
  ErrProv.SetError(TxtCode, "")

  MyTXDCCD.GetOneRecordP(WrkYear, MyUtils.CnvSng(TxtCode.Text), TxtLtr.Text)
  If MyTXDCCD.RecordNotFound Then
    ErrProv.SetError(TxtCode, "Invalid Code")
    Exit Sub
  End If

  If Trim(MyTXDCCD._DECODE) = String.Empty Then
    ErrProv.SetError(TxtCode, "Code is not a depreciated code")
    Exit Sub
  End If

  C1DataGrdList.Visible = True
  MyFrmTAP01.TBarSave.Enabled = True
  BuildGrid()
End Sub
Private Sub TxtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode.KeyPress
  C1DataGrdList.Visible = False
End Sub
Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  SaveData()
End Sub
Public Sub SaveData()
    Dim WrkCode As Integer
    Dim WrkLtr As String
    Dim WrkDeYear As Integer
    Dim WrkDeCost As Integer
    Dim WrkProPct As Integer
    Dim WrkPct As Integer
    Dim WrkDiffCost As Integer
    Dim WrkDiffValue As Integer
    Dim WrkTotCost As Integer
    Dim WrkTotValue As Integer
    Dim WrkAddMode As Boolean
    Dim WrkAmount As Integer
    Dim I As Integer
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    WrkCode = MyUtils.CnvSng(TxtCode.Text)
    WrkLtr = TxtLtr.Text
    C1DataGrdList.UpdateData()
    WrkTotCost = 0
    WrkTotValue = 0

    For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 2)
      WrkDeYear = MyUtils.CnvSng(C1DataGrdList.Item(I, 1))
      If C1DataGrdList.Item(I, 2) & "" = String.Empty Then
        WrkDeCost = 0
      Else
        WrkDeCost = MyUtils.CnvSng(C1DataGrdList.Item(I, 2))
      End If
      WrkProPct = C1DataGrdList.Item(I, 3)
      WrkPct = C1DataGrdList.Item(I, 5)
      MyTXDCDTL.GetOneRecordP(WrkListNo, WrkYear, WrkCode, WrkLtr, WrkDeYear)
      WrkAddMode = False

      If Not MyTXDCDTL.RecordNotFound Then
  '      EditChecks(ErrorField, ErrorMsg)
        If IsNothing(ErrorMsg(0)) Then
          WrkDiffCost = WrkDeCost - MyTXDCDTL._DECOST
          WrkTotCost = WrkTotCost + WrkDiffCost
          If WrkProPct > 0 Then
            WrkAmount = MyUtils.Round((MyTXDCDTL._DECOST * WrkProPct / 100) * (WrkPct / 100), 0)
          Else
            WrkAmount = MyUtils.Round(MyTXDCDTL._DECOST * WrkPct / 100, 0)
          End If
          WrkDiffValue = MyUtils.CnvSng(C1DataGrdList.Item(I, 6)) - WrkAmount
          WrkTotValue = WrkTotValue + WrkDiffValue
          If WrkDiffCost <> 0 Then
            If WrkDeCost = 0 Then
              MyTXDCDTL.DeleteOneRecordP()
            Else
              MoveToFile(WrkCode, WrkLtr, WrkDeYear, WrkDeCost)
              MyTXDCDTL.UpdateOneRecordP()
            End If
          End If
        Else
  '        ShowError(ErrorField, ErrorMsg)
          Exit Sub
        End If
      Else
  '      EditChecks(ErrorField, ErrorMsg)
        If IsNothing(ErrorMsg(0)) Then
          WrkDiffCost = WrkDeCost
          WrkTotCost = WrkTotCost + WrkDiffCost
          WrkDiffValue = MyUtils.CnvSng(C1DataGrdList.Item(I, 6))
          WrkTotValue = WrkTotValue + WrkDiffValue
          If WrkDiffCost > 0 Then
            MoveToFile(WrkCode, WrkLtr, WrkDeYear, WrkDeCost)
            MyTXDCDTL.AddOneRecordP()
          End If
        Else
  '        ShowError(ErrorField, ErrorMsg)
          Exit Sub
        End If
      End If

    Next

  If WrkTotValue <> 0 Then
    WriteTXDCSUM(WrkListNo, WrkYear, WrkCode, WrkLtr, WrkTotValue, 0)
  End If
  C1DataGrdList.Visible = False
  MyFrmTAP01.TBarSave.Enabled = False
End Sub
   Private Sub MoveToFile(ByVal WrkCode As Integer, ByVal WrkLtr As String, ByVal WrkDeYear As Integer, ByVal WrkDeCost As Integer)
      With MyTXDCDTL
        ._LISTNO = WrkListNo
        ._YEAR = WrkYear
        ._CODE = WrkCode
        ._LTR = WrkLtr
        ._DEYEAR = WrkDeYear
        ._DECOST = WrkDeCost
      End With

End Sub
Private Sub C1DataGrdList_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles C1DataGrdList.MouseClick
  CalcGridItems()
End Sub
Private Sub C1DataGrdList_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles C1DataGrdList.AfterColEdit
  CalcGridItems()
End Sub
 Private Sub CalcGridItems()
  Dim WrkDeYear As Integer
  Dim WrkDeCost As Integer
  Dim WrkProPct As Integer
  Dim WrkPct As Integer
  Dim WrkProrated As Integer
  Dim WrkValue As Integer
  Dim WrkTotalCost As Integer
  Dim WrkTotalProrated As Integer
  Dim WrkTotalValue As Integer
  Dim I As Integer

  Windows.Forms.Cursor.Current = Cursors.WaitCursor()
  WrkTotalCost = 0
  WrkTotalProrated = 0
  WrkTotalValue = 0
  For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
    If C1DataGrdList(I, 0) <> "Total" Then
      WrkDeYear = MyUtils.CnvSng(C1DataGrdList.Item(I, 1))
      If C1DataGrdList.Item(I, 2) & "" = String.Empty Then
        WrkDeCost = 0
      Else
        WrkDeCost = MyUtils.CnvSng(C1DataGrdList.Item(I, 2))
      End If
      WrkProPct = C1DataGrdList.Item(I, 3)
      WrkPct = C1DataGrdList.Item(I, 5)
      If C1DataGrdList(I, 3) > 0 Then
        WrkProrated = MyUtils.Round(WrkDeCost * (WrkProPct / 100), 0)
      Else
        WrkProrated = WrkDeCost
      End If
      C1DataGrdList.Item(I, 4) = WrkProrated
      WrkTotalProrated = WrkTotalProrated + WrkProrated
      WrkValue = MyUtils.Round(WrkProrated * (WrkPct / 100), 0)
      C1DataGrdList.Item(I, 6) = WrkValue
      WrkTotalCost = WrkTotalCost + WrkDeCost
      WrkTotalValue = WrkTotalValue + WrkValue
    Else
      C1DataGrdList.Item(I, 2) = WrkTotalCost
      C1DataGrdList.Item(I, 4) = WrkTotalProrated
      C1DataGrdList.Item(I, 6) = WrkTotalValue
    End If
  Next
  Windows.Forms.Cursor.Current = Cursors.Default

  End Sub

Private Sub C1DataGrdList_Click(sender As Object, e As EventArgs) Handles C1DataGrdList.Click

End Sub
End Class





