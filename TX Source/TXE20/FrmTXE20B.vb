Public Class FrmTXE20B
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
  Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents ChkRefunds As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents RbPayCheck As System.Windows.Forms.RadioButton
  Friend WithEvents RbPayCredit As System.Windows.Forms.RadioButton
  Friend WithEvents RbPayCash As System.Windows.Forms.RadioButton
  Friend WithEvents RbPayAll As System.Windows.Forms.RadioButton
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
  Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label6 As Label
  Friend WithEvents CboBatch As ComboBox
  Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtTypes = New System.Windows.Forms.TextBox()
    Me.LnkTypes = New System.Windows.Forms.LinkLabel()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.ChkRefunds = New System.Windows.Forms.CheckBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbPayCheck = New System.Windows.Forms.RadioButton()
    Me.RbPayCredit = New System.Windows.Forms.RadioButton()
    Me.RbPayCash = New System.Windows.Forms.RadioButton()
    Me.RbPayAll = New System.Windows.Forms.RadioButton()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtToGLYear = New System.Windows.Forms.TextBox()
    Me.TxtFromGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.CboBatch = New System.Windows.Forms.ComboBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(32, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(60, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "From Date"
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(92, 8)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
    Me.DtPckFrom.TabIndex = 0
    '
    'DtPckTo
    '
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(252, 8)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
    Me.DtPckTo.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(200, 12)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(52, 16)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "To Date"
    '
    'TxtTypes
    '
    Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTypes.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTypes.Location = New System.Drawing.Point(122, 201)
    Me.TxtTypes.MaxLength = 20
    Me.TxtTypes.Name = "TxtTypes"
    Me.TxtTypes.Size = New System.Drawing.Size(148, 20)
    Me.TxtTypes.TabIndex = 5
    '
    'LnkTypes
    '
    Me.LnkTypes.Location = New System.Drawing.Point(36, 204)
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
    'ChkRefunds
    '
    Me.ChkRefunds.AutoSize = True
    Me.ChkRefunds.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkRefunds.Location = New System.Drawing.Point(35, 178)
    Me.ChkRefunds.Name = "ChkRefunds"
    Me.ChkRefunds.Size = New System.Drawing.Size(110, 17)
    Me.ChkRefunds.TabIndex = 4
    Me.ChkRefunds.Text = "Include Refunds?"
    Me.ChkRefunds.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbPayCheck)
    Me.GroupBox2.Controls.Add(Me.RbPayCredit)
    Me.GroupBox2.Controls.Add(Me.RbPayCash)
    Me.GroupBox2.Controls.Add(Me.RbPayAll)
    Me.GroupBox2.Location = New System.Drawing.Point(35, 82)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(305, 83)
    Me.GroupBox2.TabIndex = 3
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Include Payment Type(s)"
    '
    'RbPayCheck
    '
    Me.RbPayCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPayCheck.Location = New System.Drawing.Point(185, 20)
    Me.RbPayCheck.Name = "RbPayCheck"
    Me.RbPayCheck.Size = New System.Drawing.Size(90, 25)
    Me.RbPayCheck.TabIndex = 2
    Me.RbPayCheck.Text = "Check"
    Me.RbPayCheck.UseVisualStyleBackColor = True
    '
    'RbPayCredit
    '
    Me.RbPayCredit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPayCredit.Location = New System.Drawing.Point(185, 45)
    Me.RbPayCredit.Name = "RbPayCredit"
    Me.RbPayCredit.Size = New System.Drawing.Size(90, 28)
    Me.RbPayCredit.TabIndex = 3
    Me.RbPayCredit.Text = "Credit"
    Me.RbPayCredit.UseVisualStyleBackColor = True
    '
    'RbPayCash
    '
    Me.RbPayCash.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPayCash.Location = New System.Drawing.Point(7, 45)
    Me.RbPayCash.Name = "RbPayCash"
    Me.RbPayCash.Size = New System.Drawing.Size(90, 25)
    Me.RbPayCash.TabIndex = 1
    Me.RbPayCash.Text = "Cash"
    Me.RbPayCash.UseVisualStyleBackColor = True
    '
    'RbPayAll
    '
    Me.RbPayAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPayAll.Checked = True
    Me.RbPayAll.Location = New System.Drawing.Point(7, 19)
    Me.RbPayAll.Name = "RbPayAll"
    Me.RbPayAll.Size = New System.Drawing.Size(90, 26)
    Me.RbPayAll.TabIndex = 0
    Me.RbPayAll.TabStop = True
    Me.RbPayAll.Text = "All"
    Me.RbPayAll.UseVisualStyleBackColor = True
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(158, 229)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(20, 16)
    Me.Label3.TabIndex = 40
    Me.Label3.Text = "To "
    '
    'TxtToGLYear
    '
    Me.TxtToGLYear.Location = New System.Drawing.Point(186, 225)
    Me.TxtToGLYear.MaxLength = 4
    Me.TxtToGLYear.Name = "TxtToGLYear"
    Me.TxtToGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtToGLYear.TabIndex = 7
    '
    'TxtFromGLYear
    '
    Me.TxtFromGLYear.Location = New System.Drawing.Point(122, 225)
    Me.TxtFromGLYear.MaxLength = 4
    Me.TxtFromGLYear.Name = "TxtFromGLYear"
    Me.TxtFromGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtFromGLYear.TabIndex = 6
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(26, 225)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(84, 16)
    Me.Label4.TabIndex = 39
    Me.Label4.Text = "Grand List Year"
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(226, 228)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(62, 20)
    Me.Label5.TabIndex = 41
    Me.Label5.Text = "(Optional)"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(32, 45)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(62, 13)
    Me.Label6.TabIndex = 256
    Me.Label6.Text = "Batch Type"
    '
    'CboBatch
    '
    Me.CboBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.CboBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CboBatch.FormattingEnabled = True
    Me.CboBatch.Location = New System.Drawing.Point(100, 42)
    Me.CboBatch.Name = "CboBatch"
    Me.CboBatch.Size = New System.Drawing.Size(117, 21)
    Me.CboBatch.TabIndex = 2
    '
    'FrmTXE20B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(364, 260)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.CboBatch)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtToGLYear)
    Me.Controls.Add(Me.TxtFromGLYear)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.ChkRefunds)
    Me.Controls.Add(Me.TxtTypes)
    Me.Controls.Add(Me.LnkTypes)
    Me.Controls.Add(Me.DtPckTo)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.DtPckFrom)
    Me.Controls.Add(Me.Label1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXE20B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTXE20B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXE20.SbpScreen.Text = "TXE20"
  End Sub
  Private Sub FrmTXE20B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(DtPckFrom, "")
    ErrProv.SetError(DtPckTo, "")
    ErrProv.SetError(TxtTypes, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "from"
          ErrProv.SetError(DtPckFrom, ErrorMsg(I))
        Case "to"
          ErrProv.SetError(DtPckTo, ErrorMsg(I))
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

    If DtPckFrom.Value.Date > DtPckTo.Value.Date Then
      ErrorField(I) = "from"
      ErrorMsg(I) = "Invalid Date Range"
      I = I + 1
      ErrorField(I) = "to"
      ErrorMsg(I) = "Invalid Date Range"
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
  Private Sub FrmTXE20B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
  Private Sub TxtFromGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtToGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
End Class






