Public Class FrmPRPRTCHKC
Dim WrkErnTot As Decimal
Dim WrkDedTot As Decimal
Private Sub FrmPRPRTCHKC_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
  MyFrmPRPRTCHK.SbpScreen.Text = "PRPRTCHKC"
End Sub

Private Sub FrmPRPRTCHKC_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
  MyCheckType = "P"
  MyFrmPRPRTCHKB.RbPayroll.Checked = True
  MyFrmPRPRTCHKB.Show()
End Sub
Private Sub FrmPRPRTCHKC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  DtPckChk.Value = Date.Today
  ClearForm()
End Sub
Private Sub ClearForm()
  If mydsErn.Tables.Count = 0 Then
    BuildDsErn()
    BuildDsDed()
  Else
    mydsErn.Clear()
    mydsDed.Clear()
  End If

  TxtName.Text = ""
  TxtDept.Text = ""
  TxtEmpNo.Text = ""
  TxtChkNo.Text = ""
  LblErnTot.Text = ""
  LblDedTot.Text = ""

  WrkErnTot = 0
  WrkDedTot = 0
  CalcNetPay()
End Sub
Private Sub BuildDsErn()
  Dim myTable As New DataTable

  With myTable
    .TableName = "mytable"
    .Columns.Add("EHours", Type.GetType("System.Decimal"))
    .Columns.Add("EDesc", Type.GetType("System.String"))
    .Columns.Add("EAmt", Type.GetType("System.Decimal"))
  End With
  mydsErn.Tables.Add(myTable)
End Sub
Private Sub BuildDsDed()
  Dim myTable As New DataTable

  With myTable
    .TableName = "mytable"
    .Columns.Add("DDesc", Type.GetType("System.String"))
    .Columns.Add("DAmt", Type.GetType("System.Decimal"))
  End With
  mydsDed.Tables.Add(myTable)
End Sub
Public Sub FormatGrid()
 Call ShowGrid()

 With C1DataGrdErn
   .Rebind(True)
   .Columns(0).Caption = "Hours"
   .Splits(0).DisplayColumns(0).Width = 40
   .Columns(1).Caption = "Description"
   .Splits(0).DisplayColumns(1).Width = 145
   .Columns(2).Caption = "Amount"
   .Columns(2).NumberFormat = "Fixed"
   .Splits(0).DisplayColumns(2).Width = 50
 End With

 With C1DataGrdDed
   .Rebind(True)
   .Columns(0).Caption = "Description"
   .Splits(0).DisplayColumns(0).Width = 145
   .Columns(1).Caption = "Amount"
   .Columns(1).NumberFormat = "Fixed"
   .Splits(0).DisplayColumns(1).Width = 50
 End With

End Sub
Public Sub ShowGrid()
  Windows.Forms.Cursor.Current = Cursors.WaitCursor
  C1DataGrdErn.DataSource = mydsErn.Tables(0)
  C1DataGrdErn.Refresh()
  C1DataGrdDed.DataSource = mydsDed.Tables(0)
  C1DataGrdDed.Refresh()
  Windows.Forms.Cursor.Current = Cursors.Default
End Sub
Sub AddOneErn()
  Dim myDr As Data.DataRow

  myDr = mydsErn.Tables(0).NewRow
  myDr("EHours") = MyUtils.CnvSng(TxtErnHrs.Text)
  myDr("EDesc") = TxtErnDesc.Text
  myDr("EAmt") = MyUtils.CnvSng(TxtErnAmt.Text)
  mydsErn.Tables(0).Rows.Add(myDr)

  WrkErnTot = WrkErnTot + MyUtils.CnvSng(TxtErnAmt.Text)
  LblErnTot.Text = Format(WrkErnTot, "fixed")

  TxtErnHrs.Text = ""
  TxtErnDesc.Text = ""
  TxtErnAmt.Text = ""
  FormatGrid()
  CalcNetPay()
  TxtErnHrs.Focus()
End Sub
Public Sub RemoveOneErn()
  Dim row As Integer

  If C1DataGrdErn.SelectedRows.Count > 0 Then
    For Each row In C1DataGrdErn.SelectedRows
      WrkErnTot = WrkErnTot - C1DataGrdErn.Item(C1DataGrdErn.Row, 2)
      LblErnTot.Text = Format(WrkErnTot, "fixed")
      CalcNetPay()
      mydsErn.Tables(0).Rows(row).Delete()
      Exit For
    Next
  End If

End Sub
Private Sub TxtDept_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDept.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtChkNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtChkNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtErnHrs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtErnHrs.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub

Private Sub TxtErnAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtErnAmt.KeyPress
  If Asc(e.KeyChar) = Keys.Return Then
    AddOneErn()
    Exit Sub
  End If

  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)

End Sub
Private Sub BtnErnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnErnRemove.Click
  RemoveOneErn()
End Sub
Sub AddOneDed()
  Dim myDr As Data.DataRow

  myDr = mydsDed.Tables(0).NewRow
  myDr("DDesc") = TxtDedDesc.Text
  myDr("DAmt") = MyUtils.CnvSng(TxtDedAmt.Text)
  mydsDed.Tables(0).Rows.Add(myDr)

  WrkDedTot = WrkDedTot + MyUtils.CnvSng(TxtDedAmt.Text)
  LblDedTot.Text = Format(WrkDedTot, "fixed")

  TxtDedDesc.Text = ""
  TxtDedAmt.Text = ""
  FormatGrid()
  CalcNetPay()
  TxtDedDesc.Focus()
End Sub
Public Sub RemoveOneDed()
  Dim row As Integer

  If C1DataGrdDed.SelectedRows.Count > 0 Then
    For Each row In C1DataGrdDed.SelectedRows
      WrkDedTot = WrkDedTot - C1DataGrdDed.Item(C1DataGrdDed.Row, 1)
      LblDedTot.Text = Format(WrkDedTot, "fixed")
      CalcNetPay()
      mydsDed.Tables(0).Rows(row).Delete()
      Exit For
    Next
  End If

End Sub
Private Sub TxtDedAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDedAmt.KeyPress
  If Asc(e.KeyChar) = Keys.Return Then
    AddOneDed()
    Exit Sub
  End If

  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)

End Sub
Private Sub CalcNetPay()
  LblNetPay.Text = Format(WrkErnTot - WrkDedTot, "fixed")
End Sub

Private Sub RbClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbClear.Click
  ClearForm()
End Sub

Private Sub BtnDedRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDedRemove.Click
  RemoveOneDed()
End Sub

Private Sub TxtErnHrs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtErnHrs.TextChanged

End Sub

Private Sub TxtEmpNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEmpNo.TextChanged

End Sub
End Class