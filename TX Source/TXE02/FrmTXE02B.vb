Public Class FrmTXE02B
  Inherits System.Windows.Forms.Form
  Dim ds As DataSet = New DataSet

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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbAdjustments As System.Windows.Forms.RadioButton
  Friend WithEvents RbLiens As System.Windows.Forms.RadioButton
  Friend WithEvents RbPayments As System.Windows.Forms.RadioButton
  Friend WithEvents RbRefunds As System.Windows.Forms.RadioButton
  Friend WithEvents RbSuspense As System.Windows.Forms.RadioButton
  Friend WithEvents RbSelAll As System.Windows.Forms.RadioButton
  Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents RbVoids As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtDist As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
  Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents TxtBatch As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents RbTransfers As System.Windows.Forms.RadioButton
  Friend WithEvents ChkUser As System.Windows.Forms.CheckBox
  Friend WithEvents LnkStatus As LinkLabel
  Friend WithEvents TxtStatus As TextBox
  Friend WithEvents Label6 As Label
  Friend WithEvents CboBatch As ComboBox
  Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbTransfers = New System.Windows.Forms.RadioButton()
    Me.RbVoids = New System.Windows.Forms.RadioButton()
    Me.RbSelAll = New System.Windows.Forms.RadioButton()
    Me.RbSuspense = New System.Windows.Forms.RadioButton()
    Me.RbRefunds = New System.Windows.Forms.RadioButton()
    Me.RbPayments = New System.Windows.Forms.RadioButton()
    Me.RbLiens = New System.Windows.Forms.RadioButton()
    Me.RbAdjustments = New System.Windows.Forms.RadioButton()
    Me.TxtTypes = New System.Windows.Forms.TextBox()
    Me.LnkTypes = New System.Windows.Forms.LinkLabel()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.ChkUser = New System.Windows.Forms.CheckBox()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtToGLYear = New System.Windows.Forms.TextBox()
    Me.TxtFromGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtBatch = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.LnkStatus = New System.Windows.Forms.LinkLabel()
    Me.TxtStatus = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.CboBatch = New System.Windows.Forms.ComboBox()
    Me.GroupBox1.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(19, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(60, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "From Date"
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(79, 12)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
    Me.DtPckFrom.TabIndex = 0
    '
    'DtPckTo
    '
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(239, 12)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
    Me.DtPckTo.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(187, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(52, 16)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "To Date"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbTransfers)
    Me.GroupBox1.Controls.Add(Me.RbVoids)
    Me.GroupBox1.Controls.Add(Me.RbSelAll)
    Me.GroupBox1.Controls.Add(Me.RbSuspense)
    Me.GroupBox1.Controls.Add(Me.RbRefunds)
    Me.GroupBox1.Controls.Add(Me.RbPayments)
    Me.GroupBox1.Controls.Add(Me.RbLiens)
    Me.GroupBox1.Controls.Add(Me.RbAdjustments)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(20, 44)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(264, 100)
    Me.GroupBox1.TabIndex = 2
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Selection"
    '
    'RbTransfers
    '
    Me.RbTransfers.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbTransfers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbTransfers.Location = New System.Drawing.Point(12, 76)
    Me.RbTransfers.Name = "RbTransfers"
    Me.RbTransfers.Size = New System.Drawing.Size(105, 20)
    Me.RbTransfers.TabIndex = 7
    Me.RbTransfers.Text = "Transfers"
    '
    'RbVoids
    '
    Me.RbVoids.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbVoids.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbVoids.Location = New System.Drawing.Point(165, 76)
    Me.RbVoids.Name = "RbVoids"
    Me.RbVoids.Size = New System.Drawing.Size(88, 20)
    Me.RbVoids.TabIndex = 6
    Me.RbVoids.Text = "Voids"
    '
    'RbSelAll
    '
    Me.RbSelAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSelAll.Checked = True
    Me.RbSelAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSelAll.Location = New System.Drawing.Point(12, 16)
    Me.RbSelAll.Name = "RbSelAll"
    Me.RbSelAll.Size = New System.Drawing.Size(105, 20)
    Me.RbSelAll.TabIndex = 5
    Me.RbSelAll.TabStop = True
    Me.RbSelAll.Text = "All (no Voids)"
    '
    'RbSuspense
    '
    Me.RbSuspense.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSuspense.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSuspense.Location = New System.Drawing.Point(165, 56)
    Me.RbSuspense.Name = "RbSuspense"
    Me.RbSuspense.Size = New System.Drawing.Size(88, 20)
    Me.RbSuspense.TabIndex = 4
    Me.RbSuspense.Text = "Suspense"
    '
    'RbRefunds
    '
    Me.RbRefunds.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbRefunds.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbRefunds.Location = New System.Drawing.Point(165, 36)
    Me.RbRefunds.Name = "RbRefunds"
    Me.RbRefunds.Size = New System.Drawing.Size(88, 20)
    Me.RbRefunds.TabIndex = 3
    Me.RbRefunds.Text = "Refunds"
    '
    'RbPayments
    '
    Me.RbPayments.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPayments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPayments.Location = New System.Drawing.Point(165, 16)
    Me.RbPayments.Name = "RbPayments"
    Me.RbPayments.Size = New System.Drawing.Size(88, 20)
    Me.RbPayments.TabIndex = 2
    Me.RbPayments.Text = "Payments"
    '
    'RbLiens
    '
    Me.RbLiens.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbLiens.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbLiens.Location = New System.Drawing.Point(12, 56)
    Me.RbLiens.Name = "RbLiens"
    Me.RbLiens.Size = New System.Drawing.Size(105, 20)
    Me.RbLiens.TabIndex = 1
    Me.RbLiens.Text = "Liens"
    '
    'RbAdjustments
    '
    Me.RbAdjustments.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbAdjustments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbAdjustments.Location = New System.Drawing.Point(12, 36)
    Me.RbAdjustments.Name = "RbAdjustments"
    Me.RbAdjustments.Size = New System.Drawing.Size(105, 20)
    Me.RbAdjustments.TabIndex = 0
    Me.RbAdjustments.Text = "Adjustments"
    '
    'TxtTypes
    '
    Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTypes.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTypes.Location = New System.Drawing.Point(96, 191)
    Me.TxtTypes.MaxLength = 20
    Me.TxtTypes.Name = "TxtTypes"
    Me.TxtTypes.Size = New System.Drawing.Size(148, 20)
    Me.TxtTypes.TabIndex = 4
    '
    'LnkTypes
    '
    Me.LnkTypes.Location = New System.Drawing.Point(12, 195)
    Me.LnkTypes.Name = "LnkTypes"
    Me.LnkTypes.Size = New System.Drawing.Size(80, 16)
    Me.LnkTypes.TabIndex = 35
    Me.LnkTypes.TabStop = True
    Me.LnkTypes.Text = "Types to print"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.ChkUser)
    Me.GroupBox2.Controls.Add(Me.TxtDist)
    Me.GroupBox2.Controls.Add(Me.Label3)
    Me.GroupBox2.Controls.Add(Me.TxtToGLYear)
    Me.GroupBox2.Controls.Add(Me.TxtFromGLYear)
    Me.GroupBox2.Controls.Add(Me.Label4)
    Me.GroupBox2.Controls.Add(Me.Label7)
    Me.GroupBox2.Controls.Add(Me.TxtBatch)
    Me.GroupBox2.Controls.Add(Me.Label5)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(15, 240)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(206, 118)
    Me.GroupBox2.TabIndex = 6
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Optional Selections"
    '
    'ChkUser
    '
    Me.ChkUser.AutoSize = True
    Me.ChkUser.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkUser.Location = New System.Drawing.Point(8, 94)
    Me.ChkUser.Name = "ChkUser"
    Me.ChkUser.Size = New System.Drawing.Size(170, 17)
    Me.ChkUser.TabIndex = 54
    Me.ChkUser.Text = "Show transaction User Name?"
    Me.ChkUser.UseVisualStyleBackColor = True
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(90, 71)
    Me.TxtDist.MaxLength = 4
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(32, 20)
    Me.TxtDist.TabIndex = 52
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(6, 74)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(70, 17)
    Me.Label3.TabIndex = 53
    Me.Label3.Text = "District"
    '
    'TxtToGLYear
    '
    Me.TxtToGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtToGLYear.Location = New System.Drawing.Point(162, 22)
    Me.TxtToGLYear.MaxLength = 4
    Me.TxtToGLYear.Name = "TxtToGLYear"
    Me.TxtToGLYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtToGLYear.TabIndex = 49
    '
    'TxtFromGLYear
    '
    Me.TxtFromGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFromGLYear.Location = New System.Drawing.Point(90, 22)
    Me.TxtFromGLYear.MaxLength = 4
    Me.TxtFromGLYear.Name = "TxtFromGLYear"
    Me.TxtFromGLYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtFromGLYear.TabIndex = 48
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(138, 26)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(16, 16)
    Me.Label4.TabIndex = 51
    Me.Label4.Text = "to"
    '
    'Label7
    '
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(6, 26)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(84, 16)
    Me.Label7.TabIndex = 50
    Me.Label7.Text = "Grand List Year"
    '
    'TxtBatch
    '
    Me.TxtBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBatch.Location = New System.Drawing.Point(90, 46)
    Me.TxtBatch.MaxLength = 5
    Me.TxtBatch.Name = "TxtBatch"
    Me.TxtBatch.Size = New System.Drawing.Size(40, 20)
    Me.TxtBatch.TabIndex = 47
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(6, 50)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(44, 16)
    Me.Label5.TabIndex = 46
    Me.Label5.Text = "Batch #"
    '
    'LnkStatus
    '
    Me.LnkStatus.AutoSize = True
    Me.LnkStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkStatus.Location = New System.Drawing.Point(14, 217)
    Me.LnkStatus.Name = "LnkStatus"
    Me.LnkStatus.Size = New System.Drawing.Size(70, 13)
    Me.LnkStatus.TabIndex = 57
    Me.LnkStatus.TabStop = True
    Me.LnkStatus.Text = "Status Codes"
    '
    'TxtStatus
    '
    Me.TxtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtStatus.Location = New System.Drawing.Point(96, 214)
    Me.TxtStatus.MaxLength = 20
    Me.TxtStatus.Name = "TxtStatus"
    Me.TxtStatus.Size = New System.Drawing.Size(129, 20)
    Me.TxtStatus.TabIndex = 5
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(29, 163)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(62, 13)
    Me.Label6.TabIndex = 254
    Me.Label6.Text = "Batch Type"
    '
    'CboBatch
    '
    Me.CboBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.CboBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CboBatch.FormattingEnabled = True
    Me.CboBatch.Location = New System.Drawing.Point(97, 160)
    Me.CboBatch.Name = "CboBatch"
    Me.CboBatch.Size = New System.Drawing.Size(117, 21)
    Me.CboBatch.TabIndex = 3
    '
    'FrmTXE02B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(345, 367)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.CboBatch)
    Me.Controls.Add(Me.LnkStatus)
    Me.Controls.Add(Me.TxtStatus)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.TxtTypes)
    Me.Controls.Add(Me.LnkTypes)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.DtPckTo)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.DtPckFrom)
    Me.Controls.Add(Me.Label1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXE02B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.GroupBox1.ResumeLayout(False)
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTXE02B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXE02.SbpScreen.Text = "TXE02"
  End Sub
  Private Sub FrmTXE02B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFromGLYear, "")
    ErrProv.SetError(TxtToGLYear, "")
    ErrProv.SetError(TxtTypes, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "fromglyear"
          ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
        Case "toglyear"
          ErrProv.SetError(TxtToGLYear, ErrorMsg(I))
        Case "type"
          ErrProv.SetError(TxtTypes, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtFromGLYear.Text) > MyUtils.CnvSng(TxtToGLYear.Text) Then
      ErrorField(I) = "fromglyear"
      ErrorMsg(I) = "Invalid Year Range"
      I = I + 1
      ErrorField(I) = "toglyear"
      ErrorMsg(I) = "Invalid Year Range"
      I = I + 1
    End If

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
  Private Sub FrmTXE02B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTypes = ""
    CboBatch.Items.Add("All")
    CboBatch.Items.Add("Bank Service")
    CboBatch.Items.Add("Escrow")
    CboBatch.Items.Add("Leasing")
    CboBatch.Items.Add("Liened")
    CboBatch.Items.Add("Lock Box")
    CboBatch.Items.Add("Misc/Penny Batch")
    CboBatch.Items.Add("PC")
    CboBatch.Items.Add("Suspense")
    CboBatch.Items.Add("Web Payment")
    CboBatch.SelectedItem = "All"
  End Sub
  Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
    MyTypes = TxtTypes.Text
    MyFrmSelTypes = New FrmSelTypes
    MyFrmSelTypes.MdiParent = Me.ParentForm
    MyFrmSelTypes.Show()
    Me.Hide()
  End Sub
  Private Sub LnkStatus_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkStatus.LinkClicked
    MyFrmSelStatus = New FrmSelStatus
    MyFrmSelStatus.MdiParent = Me.ParentForm
    MyFrmSelStatus.WrkField = "Select"
    MyFrmSelStatus.Show()
  End Sub
  Private Sub TxtFromGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtToGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

End Class
