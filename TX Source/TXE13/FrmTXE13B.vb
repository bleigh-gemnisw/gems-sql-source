Public Class FrmTXE13B
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
Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents ChkAddress As System.Windows.Forms.CheckBox
Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
Friend WithEvents GrpSorting As System.Windows.Forms.GroupBox
Friend WithEvents RbSortDistrict As System.Windows.Forms.RadioButton
Friend WithEvents RbSortYear As System.Windows.Forms.RadioButton
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents TxtText As System.Windows.Forms.TextBox
Friend WithEvents TxtTitle As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents DtPckAsof As System.Windows.Forms.DateTimePicker
Friend WithEvents LblAsof As System.Windows.Forms.Label
Friend WithEvents TxtMin As System.Windows.Forms.TextBox
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents LnkDistrict As System.Windows.Forms.LinkLabel
Friend WithEvents TxtPhase As System.Windows.Forms.TextBox
Friend WithEvents Label12 As System.Windows.Forms.Label
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbBalance As System.Windows.Forms.RadioButton
Friend WithEvents RbAll As System.Windows.Forms.RadioButton
Friend WithEvents DtPckStart As System.Windows.Forms.DateTimePicker
Friend WithEvents LblStart As System.Windows.Forms.Label
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents RbSortBank As System.Windows.Forms.RadioButton
  Friend WithEvents TxtOmitStatus As TextBox
  Friend WithEvents LnkOmitStatus As LinkLabel
  Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtTypes = New System.Windows.Forms.TextBox()
    Me.TxtFromGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.LnkTypes = New System.Windows.Forms.LinkLabel()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtToGLYear = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.ChkAddress = New System.Windows.Forms.CheckBox()
    Me.GrpSorting = New System.Windows.Forms.GroupBox()
    Me.RbSortBank = New System.Windows.Forms.RadioButton()
    Me.RbSortDistrict = New System.Windows.Forms.RadioButton()
    Me.RbSortYear = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.TxtText = New System.Windows.Forms.TextBox()
    Me.TxtTitle = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.DtPckAsof = New System.Windows.Forms.DateTimePicker()
    Me.LblAsof = New System.Windows.Forms.Label()
    Me.TxtMin = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.LnkDistrict = New System.Windows.Forms.LinkLabel()
    Me.TxtPhase = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbBalance = New System.Windows.Forms.RadioButton()
    Me.RbAll = New System.Windows.Forms.RadioButton()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.DtPckStart = New System.Windows.Forms.DateTimePicker()
    Me.LblStart = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtOmitStatus = New System.Windows.Forms.TextBox()
    Me.LnkOmitStatus = New System.Windows.Forms.LinkLabel()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpSorting.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'TxtTypes
    '
    Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTypes.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTypes.Location = New System.Drawing.Point(118, 16)
    Me.TxtTypes.MaxLength = 20
    Me.TxtTypes.Name = "TxtTypes"
    Me.TxtTypes.Size = New System.Drawing.Size(148, 20)
    Me.TxtTypes.TabIndex = 0
    '
    'TxtFromGLYear
    '
    Me.TxtFromGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFromGLYear.Location = New System.Drawing.Point(126, 48)
    Me.TxtFromGLYear.MaxLength = 4
    Me.TxtFromGLYear.Name = "TxtFromGLYear"
    Me.TxtFromGLYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtFromGLYear.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(34, 52)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(84, 16)
    Me.Label4.TabIndex = 11
    Me.Label4.Text = "Grand List Year"
    '
    'LnkTypes
    '
    Me.LnkTypes.Location = New System.Drawing.Point(34, 20)
    Me.LnkTypes.Name = "LnkTypes"
    Me.LnkTypes.Size = New System.Drawing.Size(80, 16)
    Me.LnkTypes.TabIndex = 17
    Me.LnkTypes.TabStop = True
    Me.LnkTypes.Text = "Types to print"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtToGLYear
    '
    Me.TxtToGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtToGLYear.Location = New System.Drawing.Point(190, 48)
    Me.TxtToGLYear.MaxLength = 4
    Me.TxtToGLYear.Name = "TxtToGLYear"
    Me.TxtToGLYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtToGLYear.TabIndex = 2
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(166, 52)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(16, 16)
    Me.Label3.TabIndex = 19
    Me.Label3.Text = "to"
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(234, 52)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(56, 16)
    Me.Label6.TabIndex = 28
    Me.Label6.Text = "(Optional)"
    '
    'ChkAddress
    '
    Me.ChkAddress.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAddress.Location = New System.Drawing.Point(224, 162)
    Me.ChkAddress.Name = "ChkAddress"
    Me.ChkAddress.Size = New System.Drawing.Size(104, 16)
    Me.ChkAddress.TabIndex = 8
    Me.ChkAddress.Text = "Print Address?"
    '
    'GrpSorting
    '
    Me.GrpSorting.Controls.Add(Me.RbSortBank)
    Me.GrpSorting.Controls.Add(Me.RbSortDistrict)
    Me.GrpSorting.Controls.Add(Me.RbSortYear)
    Me.GrpSorting.Controls.Add(Me.RbSortName)
    Me.GrpSorting.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpSorting.ForeColor = System.Drawing.Color.Maroon
    Me.GrpSorting.Location = New System.Drawing.Point(474, 77)
    Me.GrpSorting.Name = "GrpSorting"
    Me.GrpSorting.Size = New System.Drawing.Size(132, 114)
    Me.GrpSorting.TabIndex = 11
    Me.GrpSorting.TabStop = False
    Me.GrpSorting.Text = "Sort Order"
    '
    'RbSortBank
    '
    Me.RbSortBank.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortBank.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortBank.Location = New System.Drawing.Point(8, 88)
    Me.RbSortBank.Name = "RbSortBank"
    Me.RbSortBank.Size = New System.Drawing.Size(120, 20)
    Me.RbSortBank.TabIndex = 3
    Me.RbSortBank.Text = "Bank/Name"
    '
    'RbSortDistrict
    '
    Me.RbSortDistrict.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortDistrict.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortDistrict.Location = New System.Drawing.Point(8, 64)
    Me.RbSortDistrict.Name = "RbSortDistrict"
    Me.RbSortDistrict.Size = New System.Drawing.Size(120, 20)
    Me.RbSortDistrict.TabIndex = 2
    Me.RbSortDistrict.Text = "District/Year/Type"
    '
    'RbSortYear
    '
    Me.RbSortYear.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortYear.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortYear.Location = New System.Drawing.Point(8, 40)
    Me.RbSortYear.Name = "RbSortYear"
    Me.RbSortYear.Size = New System.Drawing.Size(120, 20)
    Me.RbSortYear.TabIndex = 0
    Me.RbSortYear.Text = "Year/Type"
    '
    'RbSortName
    '
    Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortName.Checked = True
    Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortName.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbSortName.Location = New System.Drawing.Point(8, 16)
    Me.RbSortName.Name = "RbSortName"
    Me.RbSortName.Size = New System.Drawing.Size(120, 20)
    Me.RbSortName.TabIndex = 1
    Me.RbSortName.TabStop = True
    Me.RbSortName.Text = "Name"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(-64, 191)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(63, 13)
    Me.Label2.TabIndex = 34
    Me.Label2.Text = "Report Text"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.TxtText)
    Me.GroupBox1.Controls.Add(Me.TxtTitle)
    Me.GroupBox1.Controls.Add(Me.Label1)
    Me.GroupBox1.Location = New System.Drawing.Point(11, 196)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(594, 189)
    Me.GroupBox1.TabIndex = 9
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Optional: Letter Title and Verbiage"
    '
    'TxtText
    '
    Me.TxtText.Location = New System.Drawing.Point(9, 48)
    Me.TxtText.Multiline = True
    Me.TxtText.Name = "TxtText"
    Me.TxtText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.TxtText.Size = New System.Drawing.Size(579, 136)
    Me.TxtText.TabIndex = 1
    '
    'TxtTitle
    '
    Me.TxtTitle.Location = New System.Drawing.Point(39, 22)
    Me.TxtTitle.Name = "TxtTitle"
    Me.TxtTitle.Size = New System.Drawing.Size(190, 20)
    Me.TxtTitle.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(6, 22)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(27, 13)
    Me.Label1.TabIndex = 39
    Me.Label1.Text = "Title"
    '
    'DtPckAsof
    '
    Me.DtPckAsof.Checked = False
    Me.DtPckAsof.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckAsof.Location = New System.Drawing.Point(118, 130)
    Me.DtPckAsof.Name = "DtPckAsof"
    Me.DtPckAsof.ShowCheckBox = True
    Me.DtPckAsof.Size = New System.Drawing.Size(98, 20)
    Me.DtPckAsof.TabIndex = 6
    Me.DtPckAsof.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
    '
    'LblAsof
    '
    Me.LblAsof.AutoSize = True
    Me.LblAsof.Location = New System.Drawing.Point(34, 130)
    Me.LblAsof.Name = "LblAsof"
    Me.LblAsof.Size = New System.Drawing.Size(65, 13)
    Me.LblAsof.TabIndex = 39
    Me.LblAsof.Text = "As of Date**"
    '
    'TxtMin
    '
    Me.TxtMin.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMin.Location = New System.Drawing.Point(147, 158)
    Me.TxtMin.MaxLength = 8
    Me.TxtMin.Name = "TxtMin"
    Me.TxtMin.Size = New System.Drawing.Size(58, 20)
    Me.TxtMin.TabIndex = 7
    Me.TxtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(35, 161)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(104, 17)
    Me.Label5.TabIndex = 42
    Me.Label5.Text = "Minimum Amount"
    '
    'LnkDistrict
    '
    Me.LnkDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkDistrict.Location = New System.Drawing.Point(298, 20)
    Me.LnkDistrict.Name = "LnkDistrict"
    Me.LnkDistrict.Size = New System.Drawing.Size(40, 16)
    Me.LnkDistrict.TabIndex = 302
    Me.LnkDistrict.TabStop = True
    Me.LnkDistrict.Text = "District"
    '
    'TxtPhase
    '
    Me.TxtPhase.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhase.Location = New System.Drawing.Point(416, 15)
    Me.TxtPhase.MaxLength = 1
    Me.TxtPhase.Name = "TxtPhase"
    Me.TxtPhase.Size = New System.Drawing.Size(16, 22)
    Me.TxtPhase.TabIndex = 4
    '
    'Label12
    '
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(378, 20)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(44, 14)
    Me.Label12.TabIndex = 301
    Me.Label12.Text = "Phase"
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(344, 17)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(28, 20)
    Me.TxtDist.TabIndex = 3
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbBalance)
    Me.GroupBox2.Controls.Add(Me.RbAll)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox2.Location = New System.Drawing.Point(478, 4)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(128, 67)
    Me.GroupBox2.TabIndex = 10
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Report Type"
    '
    'RbBalance
    '
    Me.RbBalance.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbBalance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbBalance.Location = New System.Drawing.Point(8, 40)
    Me.RbBalance.Name = "RbBalance"
    Me.RbBalance.Size = New System.Drawing.Size(107, 20)
    Me.RbBalance.TabIndex = 0
    Me.RbBalance.Text = "Balance Sheet*"
    '
    'RbAll
    '
    Me.RbAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbAll.Checked = True
    Me.RbAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbAll.ForeColor = System.Drawing.SystemColors.ControlText
    Me.RbAll.Location = New System.Drawing.Point(8, 16)
    Me.RbAll.Name = "RbAll"
    Me.RbAll.Size = New System.Drawing.Size(107, 20)
    Me.RbAll.TabIndex = 1
    Me.RbAll.TabStop = True
    Me.RbAll.Text = "All Overpaid"
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(15, 388)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(161, 13)
    Me.Label8.TabIndex = 304
    Me.Label8.Text = "* = Only newly overpaid in period"
    '
    'DtPckStart
    '
    Me.DtPckStart.Checked = False
    Me.DtPckStart.Enabled = False
    Me.DtPckStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckStart.Location = New System.Drawing.Point(119, 110)
    Me.DtPckStart.Name = "DtPckStart"
    Me.DtPckStart.ShowCheckBox = True
    Me.DtPckStart.Size = New System.Drawing.Size(98, 20)
    Me.DtPckStart.TabIndex = 5
    Me.DtPckStart.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
    '
    'LblStart
    '
    Me.LblStart.AutoSize = True
    Me.LblStart.Enabled = False
    Me.LblStart.Location = New System.Drawing.Point(35, 110)
    Me.LblStart.Name = "LblStart"
    Me.LblStart.Size = New System.Drawing.Size(73, 13)
    Me.LblStart.TabIndex = 306
    Me.LblStart.Text = "Starting Date*"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(357, 390)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(249, 13)
    Me.Label7.TabIndex = 307
    Me.Label7.Text = "** = As of date processing takes much longer to run"
    '
    'TxtOmitStatus
    '
    Me.TxtOmitStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOmitStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOmitStatus.Location = New System.Drawing.Point(124, 74)
    Me.TxtOmitStatus.MaxLength = 20
    Me.TxtOmitStatus.Name = "TxtOmitStatus"
    Me.TxtOmitStatus.Size = New System.Drawing.Size(129, 20)
    Me.TxtOmitStatus.TabIndex = 309
    '
    'LnkOmitStatus
    '
    Me.LnkOmitStatus.AutoSize = True
    Me.LnkOmitStatus.Location = New System.Drawing.Point(24, 77)
    Me.LnkOmitStatus.Name = "LnkOmitStatus"
    Me.LnkOmitStatus.Size = New System.Drawing.Size(94, 13)
    Me.LnkOmitStatus.TabIndex = 308
    Me.LnkOmitStatus.TabStop = True
    Me.LnkOmitStatus.Text = "Omit Status Codes"
    '
    'FrmTXE13B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(618, 417)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtOmitStatus)
    Me.Controls.Add(Me.LnkOmitStatus)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.DtPckStart)
    Me.Controls.Add(Me.LblStart)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.LnkDistrict)
    Me.Controls.Add(Me.TxtPhase)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.TxtMin)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.DtPckAsof)
    Me.Controls.Add(Me.LblAsof)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.GrpSorting)
    Me.Controls.Add(Me.ChkAddress)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtToGLYear)
    Me.Controls.Add(Me.TxtFromGLYear)
    Me.Controls.Add(Me.TxtTypes)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.LnkTypes)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXE13B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpSorting.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTXE13B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXE13.SbpScreen.Text = "TXE13"
  End Sub

  Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
    MyTypes = TxtTypes.Text
    MyFrmSelTypes = New FrmSelTypes
    MyFrmSelTypes.MdiParent = Me.ParentForm
    MyFrmSelTypes.Show()
    Me.Hide()
  End Sub
  Private Sub FrmTXE13B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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

  Private Sub FrmTXE13B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTypes = ""
    DtPckStart.Value = Date.Today
    DtPckStart.Checked = False
    DtPckAsof.Value = Date.Today
    DtPckAsof.Checked = False
  End Sub
  Private Sub TxtFromGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtToGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtMin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMin.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub

  Private Sub LnkDistrict_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDistrict.LinkClicked
    MyFrmListDist = New FrmListDist
    MyFrmListDist.MdiParent = Me.ParentForm
    MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
    MyFrmListDist.Show()
    Me.Hide()
  End Sub

  Private Sub RbAll_CheckedChanged(sender As Object, e As EventArgs) Handles RbAll.CheckedChanged

  End Sub

  Private Sub RbAll_Click(sender As Object, e As EventArgs) Handles RbAll.Click
    LblAsof.Text = "As of Date"
    LblStart.Enabled = False
    DtPckStart.Enabled = False
    DtPckStart.Checked = False
  End Sub
  Private Sub RbBalance_Click(sender As Object, e As EventArgs) Handles RbBalance.Click
    LblAsof.Text = "Ending Date"
    LblStart.Enabled = True
    DtPckStart.Enabled = True
    DtPckStart.Checked = True
  End Sub

  Private Sub LnkOmitStatus_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkOmitStatus.LinkClicked
    MyFrmSelStatus = New FrmSelStatus
    MyFrmSelStatus.MdiParent = Me.ParentForm
    MyFrmSelStatus.WrkField = "Omit"
    MyFrmSelStatus.Show()
  End Sub
End Class






