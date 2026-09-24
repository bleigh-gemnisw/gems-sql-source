Public Class FrmTXA30B
  Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call

  End Sub

  'Form overrides dispose to clean up the component list.
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents TxtBatch As System.Windows.Forms.TextBox
  Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
  Friend WithEvents DtPckBatch As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtBatchTotal As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents DTPckNew As System.Windows.Forms.DateTimePicker
  Friend WithEvents LblDtNew As System.Windows.Forms.Label
  Friend WithEvents RbChangeDate As System.Windows.Forms.RadioButton
  Friend WithEvents RbVoid As System.Windows.Forms.RadioButton
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label6 As Label
  Friend WithEvents CboBatch As ComboBox
  Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtBatch = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.DtPckBatch = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtBatchTotal = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.RbVoid = New System.Windows.Forms.RadioButton()
    Me.RbChangeDate = New System.Windows.Forms.RadioButton()
    Me.DTPckNew = New System.Windows.Forms.DateTimePicker()
    Me.LblDtNew = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.CboBatch = New System.Windows.Forms.ComboBox()
    Me.Label6 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtBatch
    '
    Me.TxtBatch.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBatch.Location = New System.Drawing.Point(125, 41)
    Me.TxtBatch.MaxLength = 5
    Me.TxtBatch.Name = "TxtBatch"
    Me.TxtBatch.Size = New System.Drawing.Size(43, 20)
    Me.TxtBatch.TabIndex = 0
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(18, 41)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(101, 16)
    Me.Label4.TabIndex = 11
    Me.Label4.Text = "Batch Number"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'ChkPost
    '
    Me.ChkPost.AutoSize = True
    Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkPost.Location = New System.Drawing.Point(15, 136)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(116, 20)
    Me.ChkPost.TabIndex = 3
    Me.ChkPost.Text = "Update Batch?"
    '
    'DtPckBatch
    '
    Me.DtPckBatch.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckBatch.Location = New System.Drawing.Point(92, 110)
    Me.DtPckBatch.Name = "DtPckBatch"
    Me.DtPckBatch.Size = New System.Drawing.Size(88, 20)
    Me.DtPckBatch.TabIndex = 2
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(18, 114)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(71, 16)
    Me.Label1.TabIndex = 13
    Me.Label1.Text = "Batch Date"
    '
    'TxtBatchTotal
    '
    Me.TxtBatchTotal.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBatchTotal.Location = New System.Drawing.Point(159, 168)
    Me.TxtBatchTotal.MaxLength = 13
    Me.TxtBatchTotal.Name = "TxtBatchTotal"
    Me.TxtBatchTotal.Size = New System.Drawing.Size(125, 20)
    Me.TxtBatchTotal.TabIndex = 14
    Me.TxtBatchTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(19, 169)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(134, 23)
    Me.Label2.TabIndex = 15
    Me.Label2.Text = "Verify: Batch Total is"
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(15, 203)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(341, 29)
    Me.Label3.TabIndex = 16
    Me.Label3.Text = "WARNING: Accounts with transactions after the batch post date will need to be rev" &
    "iewed"
    '
    'RbVoid
    '
    Me.RbVoid.AutoSize = True
    Me.RbVoid.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbVoid.Checked = True
    Me.RbVoid.Location = New System.Drawing.Point(75, 12)
    Me.RbVoid.Name = "RbVoid"
    Me.RbVoid.Size = New System.Drawing.Size(77, 17)
    Me.RbVoid.TabIndex = 17
    Me.RbVoid.TabStop = True
    Me.RbVoid.Text = "Void Batch"
    Me.RbVoid.UseVisualStyleBackColor = True
    '
    'RbChangeDate
    '
    Me.RbChangeDate.AutoSize = True
    Me.RbChangeDate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbChangeDate.Location = New System.Drawing.Point(191, 12)
    Me.RbChangeDate.Name = "RbChangeDate"
    Me.RbChangeDate.Size = New System.Drawing.Size(119, 17)
    Me.RbChangeDate.TabIndex = 18
    Me.RbChangeDate.Text = "Change Batch Date"
    Me.RbChangeDate.UseVisualStyleBackColor = True
    '
    'DTPckNew
    '
    Me.DTPckNew.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DTPckNew.Location = New System.Drawing.Point(266, 110)
    Me.DTPckNew.Name = "DTPckNew"
    Me.DTPckNew.Size = New System.Drawing.Size(88, 20)
    Me.DTPckNew.TabIndex = 19
    '
    'LblDtNew
    '
    Me.LblDtNew.Location = New System.Drawing.Point(197, 114)
    Me.LblDtNew.Name = "LblDtNew"
    Me.LblDtNew.Size = New System.Drawing.Size(63, 16)
    Me.LblDtNew.TabIndex = 20
    Me.LblDtNew.Text = "New Date"
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(15, 243)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(341, 18)
    Me.Label5.TabIndex = 21
    Me.Label5.Text = "WARNING: Amounts are not adjusted (Change Date)"
    '
    'CboBatch
    '
    Me.CboBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.CboBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CboBatch.FormattingEnabled = True
    Me.CboBatch.Location = New System.Drawing.Point(94, 76)
    Me.CboBatch.Name = "CboBatch"
    Me.CboBatch.Size = New System.Drawing.Size(117, 21)
    Me.CboBatch.TabIndex = 251
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(26, 79)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(62, 13)
    Me.Label6.TabIndex = 252
    Me.Label6.Text = "Batch Type"
    '
    'FrmTXA30B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(365, 275)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.CboBatch)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.DTPckNew)
    Me.Controls.Add(Me.LblDtNew)
    Me.Controls.Add(Me.RbChangeDate)
    Me.Controls.Add(Me.RbVoid)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtBatchTotal)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.DtPckBatch)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.ChkPost)
    Me.Controls.Add(Me.TxtBatch)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA30B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTXA30B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA30.SbpScreen.Text = "TXA30"
  End Sub


  Private Sub FrmTXA30B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtBatch, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "batch"
          ErrProv.SetError(TxtBatch, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtBatch.Text) = 0 Then
      ErrorField(I) = "batch"
      ErrorMsg(I) = "Batch No is required"
      I = I + 1
    End If

    If CboBatch.SelectedItem.ToString = "" Then
      ErrorField(I) = "type"
      ErrorMsg(I) = "Batch Type is required"
      I = I + 1
    End If
  End Sub

  Public Sub RunReport()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    Dim Good As Boolean
    Dim Answer As Integer

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
    If ChkPost.Checked Then
      Good = CheckBatchTotal()
      If Not Good Then
        MsgBox("Batch Total doesn't match", MsgBoxStyle.Information, "Verify failed - Update cancelled")
        Exit Sub
      End If

      Answer = MsgBox("Reports cannot be rerun. Do you want to continue?", MsgBoxStyle.YesNo, "Report print confirmation")
      If Answer = vbNo Then
        MsgBox("Rerun batch", MsgBoxStyle.Exclamation, "Update has been aborted")
        Exit Sub
      End If
      PstBatch()
      If RbVoid.Checked Then
        MsgBox("Batch has been voided", MsgBoxStyle.Information, "Process Completed")
      Else
        MsgBox("Batch has been changed", MsgBoxStyle.Information, "Process Completed")
      End If
      TxtBatch.Text = String.Empty
      ChkPost.Checked = False
      DtPckBatch.Value = Today.Date
      TxtBatchTotal.Text = String.Empty
    End If
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBatch.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBatchTotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBatchTotal.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, True)
  End Sub
  Private Sub FrmTXA30B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    CboBatch.Items.Add("Bank Service")
    CboBatch.Items.Add("Escrow")
    CboBatch.Items.Add("Leasing")
    CboBatch.Items.Add("Lock Box")
    CboBatch.Items.Add("Misc/Penny Batch")
    CboBatch.Items.Add("PC")
    CboBatch.Items.Add("Web Payment")
    CboBatch.SelectedItem = "PC"
    DTPckNew.Visible = False
    LblDtNew.Visible = False
    DtPckBatch.Value = Today.Date
    DTPckNew.Value = Today.Date
  End Sub
  Private Function CheckBatchTotal() As Boolean

    Dim Good As Boolean
    Good = False
    If MyUtils.CnvSng(TxtBatchTotal.Text) = MyBatchTotal Then
      Good = True
    End If

    Return Good
  End Function
  Private Sub RbVoid_Click(sender As Object, e As EventArgs) Handles RbVoid.Click
    DTPckNew.Visible = False
    LblDtNew.Visible = False
  End Sub
  Private Sub RbChangeDate_Click(sender As Object, e As EventArgs) Handles RbChangeDate.Click
    DTPckNew.Visible = True
    LblDtNew.Visible = True
  End Sub

  Private Sub TxtBatchTotal_TextChanged(sender As Object, e As EventArgs) Handles TxtBatchTotal.TextChanged

  End Sub
End Class






