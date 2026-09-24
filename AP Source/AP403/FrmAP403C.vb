Public Class FrmAP403C
Dim MyVENDOR As VENDOR.myData
Dim WrkTot As Decimal
Dim myds As DataSet = New DataSet
Private Sub FrmPRPRTCHKC_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
	MyFrmAP403.SbpScreen.Text = "AP403C"
End Sub
Private Sub FrmPRPRTCHKC_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
	MyCheckType = "R"
  MyFrmAP403.TBarManual.Enabled = True
	MyFrmAP403B.Show()
End Sub
Private Sub FrmPRPRTCHKC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MyVENDOR = New VENDOR.MyData()
  MyVENDOR.MyDBConn = myDBConnect
  MyCheckType = "M"
	DtPckChk.Value = Date.Today
	DtPckInvoice.Value = Date.Today
	ClearForm()
End Sub
Private Sub ClearForm()
	If myds.Tables.Count = 0 Then
		BuildDs()
	Else
		myds.Clear()
	End If

	TxtVendor.Text = ""
	TxtCheckNo.Text = ""
	TxtName.Text = ""
	TxtAddr1.Text = ""
	TxtAddr2.Text = ""
	TxtAddr3.Text = ""
	TxtAddr4.Text = ""
	TxtPoNo.Text = ""
	TxtInvoiceNo.Text = ""
	LblTot.Text = ""

	WrkTot = 0
End Sub
Private Sub BuildDs()
	Dim myTable As New DataTable

	With myTable
		.TableName = "mytable"
		.Columns.Add("PoNo", Type.GetType("System.String"))
		.Columns.Add("InvoiceDate", Type.GetType("System.String"))
		.Columns.Add("Amt", Type.GetType("System.Decimal"))
		.Columns.Add("InvoiceNo", Type.GetType("System.String"))
		.Columns.Add("Desc", Type.GetType("System.String"))
	End With
	myds.Tables.Add(myTable)
End Sub
Public Sub FormatGrid()
 Call ShowGrid()

 With DataGrdView
   .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
   .RowHeadersWidth = 25
   .Columns(0).HeaderText = "PO No"
   .Columns(0).Width = 100
   .Columns(1).HeaderText = "Inv Date"
   .Columns(1).Width = 80
   .Columns(2).HeaderText = "Amount"
   .Columns(2).DefaultCellStyle.Format = "N2" 'Fixed 2 decimal
   .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
   .Columns(2).Width = 70
   .Columns(3).HeaderText = "Inv No"
   .Columns(3).Width = 140
   .Columns(4).HeaderText = "Description"
   .Columns(4).Width = 150
 End With

End Sub
Public Sub ShowGrid()
	Windows.Forms.Cursor.Current = Cursors.WaitCursor
  DataGrdView.DataSource = myds.Tables(0)
  DataGrdView.Refresh()
	Windows.Forms.Cursor.Current = Cursors.Default
End Sub
Sub AddOneInvoice()
	Dim myDr As Data.DataRow

	myDr = myds.Tables(0).NewRow
  myDr("PONo") = MyUtils.CnvSng(TxtPoNo.Text)
  myDr("InvoiceDate") = Format(DtPckInvoice.Value, "M/dd/yyyy")
  myDr("Amt") = MyUtils.CnvSng(TxtAmt.Text)
  myDr("InvoiceNo") = TxtInvoiceNo.Text
  myDr("Desc") = TxtDesc.Text
  myds.Tables(0).Rows.Add(myDr)

  WrkTot = WrkTot + MyUtils.CnvSng(TxtAmt.Text)
  LblTot.Text = Format(WrkTot, "fixed")

  TxtPoNo.Text = ""
  TxtAmt.Text = ""
  TxtInvoiceNo.Text = ""
  TxtDesc.Text = ""
  FormatGrid()
  TxtPoNo.Focus()
End Sub
Public Sub RemoveOneInvoice()
  If DataGrdView.SelectedRows.Count > 0 Then
    WrkTot = WrkTot - DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value
    LblTot.Text = Format(WrkTot, "fixed")
    myds.Tables(0).Rows(DataGrdView.CurrentRow.Index).Delete()
  End If
End Sub
Private Sub TxtPoNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPoNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtChkNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCheckNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub TxtAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAmt.KeyPress
  If Asc(e.KeyChar) = Keys.Return Then
    AddOneInvoice()
    Exit Sub
  End If

  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)

End Sub
Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
  RemoveOneInvoice()
End Sub
Private Sub RbClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbClear.Click
  ClearForm()
End Sub
Private Sub LnkVendor_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkVendor.LinkClicked
  MyFrmListVendor = New FrmListVendor
  MyFrmListVendor.MdiParent = Me.ParentForm
  MyFrmListVendor.WrkCode = TxtVendor.Text
  MyFrmListVendor.Show()
End Sub
  Private Sub TxtDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDesc.KeyPress
    ErrProv.SetError(TxtCheckNo, "")

    If MyUtils.CnvSng(TxtCheckNo.Text) = 0 Then
      ErrProv.SetError(TxtCheckNo, "Check number is required")
      Exit Sub
    End If

    If Asc(e.KeyChar) = Keys.Return Then
      AddOneInvoice()
      Exit Sub
    End If
  End Sub

Private Sub TxtDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDesc.TextChanged

End Sub
  Public Sub RunReport()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    Me.Refresh()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtCheckNo, "")
    ErrProv.SetError(TxtBank, "")
    ErrProv.SetError(TxtName, "")
    ErrProv.SetError(LblTot, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "check"
        ErrProv.SetError(TxtCheckNo, ErrorMsg(I))
      Case "bank"
        ErrProv.SetError(TxtBank, ErrorMsg(I))
      Case "name"
        ErrProv.SetError(TxtName, ErrorMsg(I))
      Case "total"
        ErrProv.SetError(LblTot, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim WrkBankName As String
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtCheckNo.Text) = 0 Then
      ErrorField(I) = "check"
      ErrorMsg(I) = "Check number is required"
      I = I + 1
    End If

    WrkBankName = GetAPEBNKName(TxtBank.Text)
    If WrkBankName = "" Or Mid(WrkBankName, 1, 3) = "***" Then
      ErrorField(I) = "bank"
      ErrorMsg(I) = "Invalid Bank code"
      I = I + 1
    End If

    If TxtName.Text = "" Then
      ErrorField(I) = "name"
      ErrorMsg(I) = "Name is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(LblTot.Text) = 0 Then
      ErrorField(I) = "total"
      ErrorMsg(I) = "Check total cannot be 0"
      I = I + 1
    End If

  End Sub

	Private Sub TxtVendor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVendor.Leave
		Dim AddrLine(3) As String
		If TxtVendor.Text = String.Empty Then Exit Sub

		MyVENDOR.GetOneRecordP(TxtVendor.Text)
		With MyVENDOR
			If .RecordNotFound Then Exit Sub
			TxtName.Text = Trim(._VENNM)
			AddrLine = SetVndrAddrLine(._VADD1, ._VADD2, ._VADD3, _
			 ._VADD4, ._VZIP, ._VZIPE)
			TxtAddr1.Text = AddrLine(0)
			TxtAddr2.Text = AddrLine(1)
			TxtAddr3.Text = AddrLine(2)
			TxtAddr4.Text = AddrLine(3)
		End With

	End Sub
End Class