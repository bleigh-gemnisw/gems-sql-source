Public Class FrmGL107C
  Inherits System.Windows.Forms.Form
  Dim myGLACCT As GLACCT.myData
  Dim myLEDGERL1 As LEDGERL1.MyData
  Dim myLEDHSTL1 As LEDHSTL1.MyData

  Friend WithEvents LblFromDt As System.Windows.Forms.Label
  Friend WithEvents LblToDt As System.Windows.Forms.Label
  Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents GrpTotal As System.Windows.Forms.GroupBox
  Friend WithEvents LblExpend As System.Windows.Forms.Label
  Friend WithEvents LblTotType As System.Windows.Forms.Label
  Friend WithEvents LblUnliqEnc As System.Windows.Forms.Label
  Friend WithEvents LblBudget As System.Windows.Forms.Label
  Friend WithEvents LblUnencumb As System.Windows.Forms.Label
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents Label28 As System.Windows.Forms.Label
  Friend WithEvents TabCtl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpAcct As System.Windows.Forms.TabPage
  Friend WithEvents TpActivity As System.Windows.Forms.TabPage
  Friend WithEvents LblType As System.Windows.Forms.Label
  Friend WithEvents RbEquity As System.Windows.Forms.RadioButton
  Friend WithEvents RbExpense As System.Windows.Forms.RadioButton
  Friend WithEvents RbLiability As System.Windows.Forms.RadioButton
  Friend WithEvents RbHeader As System.Windows.Forms.RadioButton
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents RbAsset As System.Windows.Forms.RadioButton
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtSfund As System.Windows.Forms.TextBox
  Friend WithEvents TxtFdnbr As System.Windows.Forms.TextBox
  Friend WithEvents TxtRlnbr As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents ChkCash As System.Windows.Forms.CheckBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtSubfn As System.Windows.Forms.TextBox
  Friend WithEvents TxtFnpgm As System.Windows.Forms.TextBox
  Friend WithEvents TxtObnbr As System.Windows.Forms.TextBox
  Friend WithEvents TxtDpnbr As System.Windows.Forms.TextBox
  Friend WithEvents TxtGldsc As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents BtnRefresh As System.Windows.Forms.Button
  Friend WithEvents LblAcct As System.Windows.Forms.Label
  Friend WithEvents RbRevenue As System.Windows.Forms.RadioButton

  Friend WrkFdnbr As Integer
  Friend WrkSfund As Integer
  Friend WrkDpnbr As Integer
  Friend WrkObnbr As Integer
  Friend WrkFnpgm As Integer
  Friend WrkSubfn As Integer
  Friend WithEvents LblType2 As System.Windows.Forms.Label
  Friend WithEvents ChkInActive As System.Windows.Forms.CheckBox
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Friend WithEvents RbHistory As RadioButton
  Friend WithEvents RbCurrent As RadioButton
  Friend WrkGLType As String

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
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LblFromDt = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.LblToDt = New System.Windows.Forms.Label()
    Me.GrpTotal = New System.Windows.Forms.GroupBox()
    Me.LblExpend = New System.Windows.Forms.Label()
    Me.LblTotType = New System.Windows.Forms.Label()
    Me.LblUnliqEnc = New System.Windows.Forms.Label()
    Me.LblBudget = New System.Windows.Forms.Label()
    Me.LblUnencumb = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.Label28 = New System.Windows.Forms.Label()
    Me.TabCtl1 = New System.Windows.Forms.TabControl()
    Me.TpActivity = New System.Windows.Forms.TabPage()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.TpAcct = New System.Windows.Forms.TabPage()
    Me.ChkInActive = New System.Windows.Forms.CheckBox()
    Me.RbRevenue = New System.Windows.Forms.RadioButton()
    Me.TxtRlnbr = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.ChkCash = New System.Windows.Forms.CheckBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtSubfn = New System.Windows.Forms.TextBox()
    Me.TxtFnpgm = New System.Windows.Forms.TextBox()
    Me.TxtObnbr = New System.Windows.Forms.TextBox()
    Me.TxtDpnbr = New System.Windows.Forms.TextBox()
    Me.TxtGldsc = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LblType = New System.Windows.Forms.Label()
    Me.RbEquity = New System.Windows.Forms.RadioButton()
    Me.RbExpense = New System.Windows.Forms.RadioButton()
    Me.RbLiability = New System.Windows.Forms.RadioButton()
    Me.RbHeader = New System.Windows.Forms.RadioButton()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.RbAsset = New System.Windows.Forms.RadioButton()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtSfund = New System.Windows.Forms.TextBox()
    Me.TxtFdnbr = New System.Windows.Forms.TextBox()
    Me.BtnRefresh = New System.Windows.Forms.Button()
    Me.LblAcct = New System.Windows.Forms.Label()
    Me.LblType2 = New System.Windows.Forms.Label()
    Me.RbCurrent = New System.Windows.Forms.RadioButton()
    Me.RbHistory = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpTotal.SuspendLayout()
    Me.TabCtl1.SuspendLayout()
    Me.TpActivity.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TpAcct.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblFromDt
    '
    Me.LblFromDt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFromDt.ForeColor = System.Drawing.Color.Black
    Me.LblFromDt.Location = New System.Drawing.Point(18, 28)
    Me.LblFromDt.Name = "LblFromDt"
    Me.LblFromDt.Size = New System.Drawing.Size(46, 18)
    Me.LblFromDt.TabIndex = 169
    Me.LblFromDt.Text = "From"
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(70, 28)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.Size = New System.Drawing.Size(84, 20)
    Me.DtPckFrom.TabIndex = 170
    '
    'DtPckTo
    '
    Me.DtPckTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(70, 55)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.Size = New System.Drawing.Size(84, 20)
    Me.DtPckTo.TabIndex = 171
    '
    'LblToDt
    '
    Me.LblToDt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblToDt.ForeColor = System.Drawing.Color.Black
    Me.LblToDt.Location = New System.Drawing.Point(18, 55)
    Me.LblToDt.Name = "LblToDt"
    Me.LblToDt.Size = New System.Drawing.Size(46, 18)
    Me.LblToDt.TabIndex = 172
    Me.LblToDt.Text = "To"
    '
    'GrpTotal
    '
    Me.GrpTotal.Controls.Add(Me.LblExpend)
    Me.GrpTotal.Controls.Add(Me.LblTotType)
    Me.GrpTotal.Controls.Add(Me.LblUnliqEnc)
    Me.GrpTotal.Controls.Add(Me.LblBudget)
    Me.GrpTotal.Controls.Add(Me.LblUnencumb)
    Me.GrpTotal.Controls.Add(Me.Label30)
    Me.GrpTotal.Controls.Add(Me.Label29)
    Me.GrpTotal.Controls.Add(Me.Label28)
    Me.GrpTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpTotal.Location = New System.Drawing.Point(177, 37)
    Me.GrpTotal.Name = "GrpTotal"
    Me.GrpTotal.Size = New System.Drawing.Size(262, 84)
    Me.GrpTotal.TabIndex = 173
    Me.GrpTotal.TabStop = False
    Me.GrpTotal.Text = "Totals"
    '
    'LblExpend
    '
    Me.LblExpend.BackColor = System.Drawing.Color.Aqua
    Me.LblExpend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExpend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExpend.Location = New System.Drawing.Point(167, 46)
    Me.LblExpend.Name = "LblExpend"
    Me.LblExpend.Size = New System.Drawing.Size(89, 16)
    Me.LblExpend.TabIndex = 21
    Me.LblExpend.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotType
    '
    Me.LblTotType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotType.Location = New System.Drawing.Point(8, 48)
    Me.LblTotType.Name = "LblTotType"
    Me.LblTotType.Size = New System.Drawing.Size(153, 14)
    Me.LblTotType.TabIndex = 20
    Me.LblTotType.Text = "Expenditures"
    '
    'LblUnliqEnc
    '
    Me.LblUnliqEnc.BackColor = System.Drawing.Color.Aqua
    Me.LblUnliqEnc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblUnliqEnc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblUnliqEnc.Location = New System.Drawing.Point(167, 30)
    Me.LblUnliqEnc.Name = "LblUnliqEnc"
    Me.LblUnliqEnc.Size = New System.Drawing.Size(89, 16)
    Me.LblUnliqEnc.TabIndex = 19
    Me.LblUnliqEnc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblBudget
    '
    Me.LblBudget.BackColor = System.Drawing.Color.Aqua
    Me.LblBudget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblBudget.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBudget.Location = New System.Drawing.Point(167, 14)
    Me.LblBudget.Name = "LblBudget"
    Me.LblBudget.Size = New System.Drawing.Size(89, 16)
    Me.LblBudget.TabIndex = 18
    Me.LblBudget.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblUnencumb
    '
    Me.LblUnencumb.BackColor = System.Drawing.Color.Aqua
    Me.LblUnencumb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblUnencumb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblUnencumb.Location = New System.Drawing.Point(167, 62)
    Me.LblUnencumb.Name = "LblUnencumb"
    Me.LblUnencumb.Size = New System.Drawing.Size(89, 16)
    Me.LblUnencumb.TabIndex = 17
    Me.LblUnencumb.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label30
    '
    Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label30.Location = New System.Drawing.Point(8, 32)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(153, 16)
    Me.Label30.TabIndex = 16
    Me.Label30.Text = "Unliquidated Encumbrances"
    '
    'Label29
    '
    Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label29.Location = New System.Drawing.Point(8, 16)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(153, 16)
    Me.Label29.TabIndex = 15
    Me.Label29.Text = "Current Budget"
    '
    'Label28
    '
    Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label28.Location = New System.Drawing.Point(9, 64)
    Me.Label28.Name = "Label28"
    Me.Label28.Size = New System.Drawing.Size(153, 16)
    Me.Label28.TabIndex = 14
    Me.Label28.Text = "Unencumbered Balance"
    '
    'TabCtl1
    '
    Me.TabCtl1.Controls.Add(Me.TpActivity)
    Me.TabCtl1.Controls.Add(Me.TpAcct)
    Me.TabCtl1.Location = New System.Drawing.Point(12, 127)
    Me.TabCtl1.Name = "TabCtl1"
    Me.TabCtl1.SelectedIndex = 0
    Me.TabCtl1.Size = New System.Drawing.Size(748, 367)
    Me.TabCtl1.TabIndex = 174
    '
    'TpActivity
    '
    Me.TpActivity.AutoScroll = True
    Me.TpActivity.Controls.Add(Me.DataGrdView)
    Me.TpActivity.Location = New System.Drawing.Point(4, 22)
    Me.TpActivity.Name = "TpActivity"
    Me.TpActivity.Padding = New System.Windows.Forms.Padding(3)
    Me.TpActivity.Size = New System.Drawing.Size(740, 341)
    Me.TpActivity.TabIndex = 1
    Me.TpActivity.Text = "Activity"
    Me.TpActivity.UseVisualStyleBackColor = True
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGrdView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle2
    Me.DataGrdView.Location = New System.Drawing.Point(6, 12)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGrdView.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(722, 317)
    Me.DataGrdView.TabIndex = 351
    '
    'TpAcct
    '
    Me.TpAcct.Controls.Add(Me.ChkInActive)
    Me.TpAcct.Controls.Add(Me.RbRevenue)
    Me.TpAcct.Controls.Add(Me.TxtRlnbr)
    Me.TpAcct.Controls.Add(Me.Label2)
    Me.TpAcct.Controls.Add(Me.ChkCash)
    Me.TpAcct.Controls.Add(Me.Label11)
    Me.TpAcct.Controls.Add(Me.Label10)
    Me.TpAcct.Controls.Add(Me.Label9)
    Me.TpAcct.Controls.Add(Me.Label8)
    Me.TpAcct.Controls.Add(Me.TxtSubfn)
    Me.TpAcct.Controls.Add(Me.TxtFnpgm)
    Me.TpAcct.Controls.Add(Me.TxtObnbr)
    Me.TpAcct.Controls.Add(Me.TxtDpnbr)
    Me.TpAcct.Controls.Add(Me.TxtGldsc)
    Me.TpAcct.Controls.Add(Me.Label1)
    Me.TpAcct.Controls.Add(Me.LblType)
    Me.TpAcct.Controls.Add(Me.RbEquity)
    Me.TpAcct.Controls.Add(Me.RbExpense)
    Me.TpAcct.Controls.Add(Me.RbLiability)
    Me.TpAcct.Controls.Add(Me.RbHeader)
    Me.TpAcct.Controls.Add(Me.Label7)
    Me.TpAcct.Controls.Add(Me.RbAsset)
    Me.TpAcct.Controls.Add(Me.Label4)
    Me.TpAcct.Controls.Add(Me.TxtSfund)
    Me.TpAcct.Controls.Add(Me.TxtFdnbr)
    Me.TpAcct.Location = New System.Drawing.Point(4, 22)
    Me.TpAcct.Name = "TpAcct"
    Me.TpAcct.Padding = New System.Windows.Forms.Padding(3)
    Me.TpAcct.Size = New System.Drawing.Size(740, 341)
    Me.TpAcct.TabIndex = 0
    Me.TpAcct.Text = "Acct"
    Me.TpAcct.UseVisualStyleBackColor = True
    '
    'ChkInActive
    '
    Me.ChkInActive.AutoSize = True
    Me.ChkInActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkInActive.Location = New System.Drawing.Point(9, 44)
    Me.ChkInActive.Name = "ChkInActive"
    Me.ChkInActive.Size = New System.Drawing.Size(70, 17)
    Me.ChkInActive.TabIndex = 7
    Me.ChkInActive.Text = "Inactive?"
    Me.ChkInActive.UseVisualStyleBackColor = True
    '
    'RbRevenue
    '
    Me.RbRevenue.AutoSize = True
    Me.RbRevenue.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbRevenue.Location = New System.Drawing.Point(491, 15)
    Me.RbRevenue.Name = "RbRevenue"
    Me.RbRevenue.Size = New System.Drawing.Size(69, 17)
    Me.RbRevenue.TabIndex = 6
    Me.RbRevenue.Text = "Revenue"
    Me.RbRevenue.UseVisualStyleBackColor = True
    '
    'TxtRlnbr
    '
    Me.TxtRlnbr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRlnbr.Location = New System.Drawing.Point(106, 267)
    Me.TxtRlnbr.MaxLength = 2
    Me.TxtRlnbr.Name = "TxtRlnbr"
    Me.TxtRlnbr.Size = New System.Drawing.Size(32, 22)
    Me.TxtRlnbr.TabIndex = 16
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.ForeColor = System.Drawing.Color.Black
    Me.Label2.Location = New System.Drawing.Point(6, 273)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(94, 16)
    Me.Label2.TabIndex = 191
    Me.Label2.Text = "Roll Number"
    '
    'ChkCash
    '
    Me.ChkCash.AutoSize = True
    Me.ChkCash.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkCash.Location = New System.Drawing.Point(6, 242)
    Me.ChkCash.Name = "ChkCash"
    Me.ChkCash.Size = New System.Drawing.Size(56, 17)
    Me.ChkCash.TabIndex = 15
    Me.ChkCash.Text = "Cash?"
    Me.ChkCash.UseVisualStyleBackColor = True
    '
    'Label11
    '
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.ForeColor = System.Drawing.Color.Black
    Me.Label11.Location = New System.Drawing.Point(6, 190)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(94, 16)
    Me.Label11.TabIndex = 190
    Me.Label11.Text = "Sub Function"
    '
    'Label10
    '
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.ForeColor = System.Drawing.Color.Black
    Me.Label10.Location = New System.Drawing.Point(6, 162)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(94, 16)
    Me.Label10.TabIndex = 189
    Me.Label10.Text = "Function/Program"
    '
    'Label9
    '
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.ForeColor = System.Drawing.Color.Black
    Me.Label9.Location = New System.Drawing.Point(6, 131)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(82, 16)
    Me.Label9.TabIndex = 188
    Me.Label9.Text = "Object"
    '
    'Label8
    '
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.ForeColor = System.Drawing.Color.Black
    Me.Label8.Location = New System.Drawing.Point(6, 103)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(82, 16)
    Me.Label8.TabIndex = 187
    Me.Label8.Text = "Department"
    '
    'TxtSubfn
    '
    Me.TxtSubfn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSubfn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSubfn.Location = New System.Drawing.Point(106, 184)
    Me.TxtSubfn.MaxLength = 4
    Me.TxtSubfn.Name = "TxtSubfn"
    Me.TxtSubfn.Size = New System.Drawing.Size(45, 22)
    Me.TxtSubfn.TabIndex = 13
    '
    'TxtFnpgm
    '
    Me.TxtFnpgm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFnpgm.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFnpgm.Location = New System.Drawing.Point(106, 156)
    Me.TxtFnpgm.MaxLength = 4
    Me.TxtFnpgm.Name = "TxtFnpgm"
    Me.TxtFnpgm.Size = New System.Drawing.Size(45, 22)
    Me.TxtFnpgm.TabIndex = 12
    '
    'TxtObnbr
    '
    Me.TxtObnbr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObnbr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObnbr.Location = New System.Drawing.Point(106, 127)
    Me.TxtObnbr.MaxLength = 3
    Me.TxtObnbr.Name = "TxtObnbr"
    Me.TxtObnbr.Size = New System.Drawing.Size(32, 22)
    Me.TxtObnbr.TabIndex = 11
    '
    'TxtDpnbr
    '
    Me.TxtDpnbr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDpnbr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDpnbr.Location = New System.Drawing.Point(106, 99)
    Me.TxtDpnbr.MaxLength = 4
    Me.TxtDpnbr.Name = "TxtDpnbr"
    Me.TxtDpnbr.Size = New System.Drawing.Size(45, 22)
    Me.TxtDpnbr.TabIndex = 10
    '
    'TxtGldsc
    '
    Me.TxtGldsc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtGldsc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGldsc.Location = New System.Drawing.Point(106, 216)
    Me.TxtGldsc.MaxLength = 34
    Me.TxtGldsc.Name = "TxtGldsc"
    Me.TxtGldsc.Size = New System.Drawing.Size(250, 20)
    Me.TxtGldsc.TabIndex = 14
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.ForeColor = System.Drawing.Color.Black
    Me.Label1.Location = New System.Drawing.Point(6, 215)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 186
    Me.Label1.Text = "Description"
    '
    'LblType
    '
    Me.LblType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblType.ForeColor = System.Drawing.Color.Black
    Me.LblType.Location = New System.Drawing.Point(411, 45)
    Me.LblType.Name = "LblType"
    Me.LblType.Size = New System.Drawing.Size(82, 16)
    Me.LblType.TabIndex = 178
    Me.LblType.Text = "<Type Desc>"
    '
    'RbEquity
    '
    Me.RbEquity.AutoSize = True
    Me.RbEquity.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbEquity.Location = New System.Drawing.Point(323, 15)
    Me.RbEquity.Name = "RbEquity"
    Me.RbEquity.Size = New System.Drawing.Size(54, 17)
    Me.RbEquity.TabIndex = 4
    Me.RbEquity.Text = "Equity"
    Me.RbEquity.UseVisualStyleBackColor = True
    '
    'RbExpense
    '
    Me.RbExpense.AutoSize = True
    Me.RbExpense.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbExpense.Location = New System.Drawing.Point(398, 15)
    Me.RbExpense.Name = "RbExpense"
    Me.RbExpense.Size = New System.Drawing.Size(66, 17)
    Me.RbExpense.TabIndex = 5
    Me.RbExpense.Text = "Expense"
    Me.RbExpense.UseVisualStyleBackColor = True
    '
    'RbLiability
    '
    Me.RbLiability.AutoSize = True
    Me.RbLiability.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbLiability.Location = New System.Drawing.Point(248, 14)
    Me.RbLiability.Name = "RbLiability"
    Me.RbLiability.Size = New System.Drawing.Size(59, 17)
    Me.RbLiability.TabIndex = 3
    Me.RbLiability.Text = "Liability"
    Me.RbLiability.UseVisualStyleBackColor = True
    '
    'RbHeader
    '
    Me.RbHeader.AutoSize = True
    Me.RbHeader.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbHeader.Location = New System.Drawing.Point(167, 13)
    Me.RbHeader.Name = "RbHeader"
    Me.RbHeader.Size = New System.Drawing.Size(60, 17)
    Me.RbHeader.TabIndex = 2
    Me.RbHeader.Text = "Header"
    Me.RbHeader.UseVisualStyleBackColor = True
    '
    'Label7
    '
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.ForeColor = System.Drawing.Color.Black
    Me.Label7.Location = New System.Drawing.Point(6, 15)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(82, 16)
    Me.Label7.TabIndex = 0
    Me.Label7.Text = "Acct Type"
    '
    'RbAsset
    '
    Me.RbAsset.AutoSize = True
    Me.RbAsset.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbAsset.Checked = True
    Me.RbAsset.Location = New System.Drawing.Point(100, 13)
    Me.RbAsset.Name = "RbAsset"
    Me.RbAsset.Size = New System.Drawing.Size(51, 17)
    Me.RbAsset.TabIndex = 1
    Me.RbAsset.TabStop = True
    Me.RbAsset.Text = "Asset"
    Me.RbAsset.UseVisualStyleBackColor = True
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.ForeColor = System.Drawing.Color.Black
    Me.Label4.Location = New System.Drawing.Point(6, 73)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(82, 16)
    Me.Label4.TabIndex = 176
    Me.Label4.Text = "Fund/Sub Fund"
    '
    'TxtSfund
    '
    Me.TxtSfund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfund.Location = New System.Drawing.Point(144, 71)
    Me.TxtSfund.MaxLength = 3
    Me.TxtSfund.Name = "TxtSfund"
    Me.TxtSfund.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfund.TabIndex = 9
    '
    'TxtFdnbr
    '
    Me.TxtFdnbr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFdnbr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFdnbr.Location = New System.Drawing.Point(106, 71)
    Me.TxtFdnbr.MaxLength = 3
    Me.TxtFdnbr.Name = "TxtFdnbr"
    Me.TxtFdnbr.Size = New System.Drawing.Size(32, 22)
    Me.TxtFdnbr.TabIndex = 8
    '
    'BtnRefresh
    '
    Me.BtnRefresh.Location = New System.Drawing.Point(70, 81)
    Me.BtnRefresh.Name = "BtnRefresh"
    Me.BtnRefresh.Size = New System.Drawing.Size(57, 24)
    Me.BtnRefresh.TabIndex = 175
    Me.BtnRefresh.Text = "Refresh"
    Me.BtnRefresh.UseVisualStyleBackColor = True
    '
    'LblAcct
    '
    Me.LblAcct.AutoSize = True
    Me.LblAcct.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAcct.ForeColor = System.Drawing.Color.Black
    Me.LblAcct.Location = New System.Drawing.Point(174, 9)
    Me.LblAcct.Name = "LblAcct"
    Me.LblAcct.Size = New System.Drawing.Size(128, 17)
    Me.LblAcct.TabIndex = 176
    Me.LblAcct.Text = "< Acct Number >"
    '
    'LblType2
    '
    Me.LblType2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblType2.ForeColor = System.Drawing.Color.Black
    Me.LblType2.Location = New System.Drawing.Point(662, 11)
    Me.LblType2.Name = "LblType2"
    Me.LblType2.Size = New System.Drawing.Size(82, 16)
    Me.LblType2.TabIndex = 180
    Me.LblType2.Text = "<Type Desc>"
    Me.LblType2.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'RbCurrent
    '
    Me.RbCurrent.AutoSize = True
    Me.RbCurrent.Checked = True
    Me.RbCurrent.Location = New System.Drawing.Point(21, 5)
    Me.RbCurrent.Name = "RbCurrent"
    Me.RbCurrent.Size = New System.Drawing.Size(59, 17)
    Me.RbCurrent.TabIndex = 181
    Me.RbCurrent.TabStop = True
    Me.RbCurrent.Text = "Current"
    Me.RbCurrent.UseVisualStyleBackColor = True
    '
    'RbHistory
    '
    Me.RbHistory.AutoSize = True
    Me.RbHistory.Location = New System.Drawing.Point(105, 5)
    Me.RbHistory.Name = "RbHistory"
    Me.RbHistory.Size = New System.Drawing.Size(57, 17)
    Me.RbHistory.TabIndex = 182
    Me.RbHistory.Text = "History"
    Me.RbHistory.UseVisualStyleBackColor = True
    '
    'FrmGL107C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(772, 502)
    Me.Controls.Add(Me.RbHistory)
    Me.Controls.Add(Me.RbCurrent)
    Me.Controls.Add(Me.LblType2)
    Me.Controls.Add(Me.LblAcct)
    Me.Controls.Add(Me.BtnRefresh)
    Me.Controls.Add(Me.TabCtl1)
    Me.Controls.Add(Me.GrpTotal)
    Me.Controls.Add(Me.LblToDt)
    Me.Controls.Add(Me.DtPckTo)
    Me.Controls.Add(Me.DtPckFrom)
    Me.Controls.Add(Me.LblFromDt)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL107C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpTotal.ResumeLayout(False)
    Me.TabCtl1.ResumeLayout(False)
    Me.TpActivity.ResumeLayout(False)
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TpAcct.ResumeLayout(False)
    Me.TpAcct.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmGL107C_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    myFromDate = DtPckFrom.Value
    myToDate = DtPckTo.Value
  End Sub

  Private Sub FrmGL107C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim myCommon2 As New Common2
    Dim Good As Boolean
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    myLEDGERL1 = New LEDGERL1.MyData()
    myLEDGERL1.MyDBConn = myDBConnect
    myLEDHSTL1 = New LEDHSTL1.MyData()
    myLEDHSTL1.MyDBConn = myDBConnect

    MyFrmGL107.TbarNew.Enabled = False
    MyFrmGL107.TBarSave.Enabled = False
    MyFrmGL107.TBarDelete.Enabled = False
    LblType.Visible = False
    LblType2.Text = ""
    If Not MyIsLedger Then
      RbHistory.Checked = True
    End If
    If WrkFdnbr > 0 Then
      MyUtils.SetTxtReadOnly(TxtFdnbr)
      MyUtils.SetTxtReadOnly(TxtSfund)
      MyUtils.SetTxtReadOnly(TxtDpnbr)
      MyUtils.SetTxtReadOnly(TxtObnbr)
      MyUtils.SetTxtReadOnly(TxtFnpgm)
      MyUtils.SetTxtReadOnly(TxtSubfn)
      RbAsset.Visible = False
      RbHeader.Visible = False
      RbLiability.Visible = False
      RbExpense.Visible = False
      RbEquity.Visible = False
      RbRevenue.Visible = False
      LblType.Visible = True
      LblType.Location = RbAsset.Location
    End If

    myGLACCT.GetOneRecordP(WrkFdnbr, WrkSfund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
        If myGLACCT.RecordNotFound Then
            LblAcct.Text = ""
            LblFromDt.Visible = False
            LblToDt.Visible = False
            DtPckFrom.Visible = False
            DtPckTo.Visible = False
            BtnRefresh.Visible = False
            GrpTotal.Visible = False
            TabCtl1.TabPages.Remove(TpActivity)
            TpAcct.Select()
            MyUtils.ShowFocus(TxtFdnbr)
            Exit Sub
        End If

        Good = myCommon2.GetDepSec(0, 0, 0)
        If Not Good Then
            Good = myCommon2.GetDepSec(WrkFdnbr, WrkSfund, 0)
            If Not Good Then
                Good = myCommon2.GetDepSec(WrkFdnbr, WrkSfund, WrkDpnbr)
                If Not Good Then
                    LblAcct.Text = "You don't have permission to this account"
                    LblFromDt.Visible = False
                    LblToDt.Visible = False
                    DtPckFrom.Visible = False
                    DtPckTo.Visible = False
                    BtnRefresh.Visible = False
                    GrpTotal.Visible = False
                    TabCtl1.Visible = False
                    Exit Sub
                End If
            End If
        End If

            TxtFdnbr.Text = WrkFdnbr
    TxtSfund.Text = WrkSfund
    TxtDpnbr.Text = WrkDpnbr
    TxtObnbr.Text = WrkObnbr
    TxtFnpgm.Text = WrkFnpgm
    TxtSubfn.Text = WrkSubfn

    With myGLACCT
      If ._ACREC = "I" Then
        ChkInActive.Checked = True
      Else
        ChkInActive.Checked = False
      End If
      TxtFdnbr.Text = Format(._FDNBR, "000")
      TxtSfund.Text = Format(._SFUND, "000")
      TxtDpnbr.Text = Format(._DPNBR, "0000")
      TxtObnbr.Text = Format(._OBNBR, "000")
      TxtFnpgm.Text = Format(._FNPGM, "0000")
      TxtSubfn.Text = Format(._SUBFN, "0000")
      TxtGldsc.Text = Trim(._GLDSC)
      LblAcct.Text = TxtFdnbr.Text & "-" & TxtSfund.Text & "-" & TxtDpnbr.Text & "-" & TxtObnbr.Text & "-" &
      TxtFnpgm.Text & "-" & TxtSubfn.Text & "  " & TxtGldsc.Text
      Select Case ._GLTYP
        Case "A"
          RbAsset.Checked = True
          LblType.Text = "Asset"
          LblTotType.Text = "Activity"
        Case "H"
          RbHeader.Checked = True
          LblType.Text = "Header"
          LblTotType.Text = "Activity"
        Case "L"
          RbLiability.Checked = True
          LblType.Text = "Liability"
          LblTotType.Text = "Activity"
        Case "Q"
          RbEquity.Checked = True
          LblType.Text = "Equity"
          LblTotType.Text = "Activity"
        Case "R"
          RbRevenue.Checked = True
          LblType.Text = "Revenue"
          LblTotType.Text = "Activity"
        Case "X"
          RbExpense.Checked = True
          LblType.Text = "Expense"
          LblTotType.Text = "Expenditures"
        Case Else
      End Select
      LblType2.Text = LblType.Text
      If ._CSHYN = "Y" Then
        ChkCash.Checked = True
      End If
      If ._RLNBR > 0 Then
        TxtRlnbr.Text = ._RLNBR
      End If
      DtPckFrom.Value = myFromDate
      DtPckTo.Value = myToDate
    End With

    RefreshData()
  End Sub

  Private Sub FrmGL107C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmGL107.TbarNew.Enabled = True
    MyFrmGL107.TBarDelete.Enabled = False
    MyFrmGL107.TBarSave.Enabled = False
    With MyFrmGL107B
      .TxtFdnbr.Text = WrkFdnbr
      .TxtSfund.Text = WrkSfund
      .TxtDpnbr.Text = WrkDpnbr
      .TxtFnpgm.Text = WrkFnpgm
      .TxtObnbr.Text = WrkObnbr
      .TxtSubfn.Text = WrkSubfn
      .FormatGrid()
      .Show()
    End With

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim ds2 As DataSet = New DataSet
    Dim Answer As Integer

    ds2 = myLEDGERL1.GetAllAcct(MyUtils.CnvSng(TxtFdnbr.Text), MyUtils.CnvSng(TxtSfund.Text), MyUtils.CnvSng(TxtDpnbr.Text),
    MyUtils.CnvSng(TxtObnbr.Text), MyUtils.CnvSng(TxtFnpgm.Text), MyUtils.CnvSng(TxtSubfn.Text), 0, 99999999)
    If ds2.Tables(0).Rows.Count > 0 Then
      MsgBox("This account has activity", MsgBoxStyle.Exclamation, "Delete Account is not allowed")
      Exit Sub
    End If

    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    myGLACCT.DeleteOneRecordP()
    Me.Close()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFdnbr.Text), MyUtils.CnvSng(TxtSfund.Text), MyUtils.CnvSng(TxtDpnbr.Text),
    MyUtils.CnvSng(TxtObnbr.Text), MyUtils.CnvSng(TxtFnpgm.Text), MyUtils.CnvSng(TxtSubfn.Text))
    If WrkFdnbr = 0 Then
      If Not myGLACCT.RecordNotFound Then
        Me.ErrProv.SetError(TxtFdnbr, "Record already exists")
        Exit Sub
      End If
    End If

    If WrkFdnbr > 0 Then
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myGLACCT.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      myGLACCT._FDNBR = MyUtils.CnvSng(TxtFdnbr.Text)
      myGLACCT._SFUND = MyUtils.CnvSng(TxtSfund.Text)
      myGLACCT._DPNBR = MyUtils.CnvSng(TxtDpnbr.Text)
      myGLACCT._OBNBR = MyUtils.CnvSng(TxtObnbr.Text)
      myGLACCT._FNPGM = MyUtils.CnvSng(TxtFnpgm.Text)
      myGLACCT._SUBFN = MyUtils.CnvSng(TxtSubfn.Text)
      If RbAsset.Checked Then
        myGLACCT._GLTYP = "A"
      End If
      If RbHeader.Checked Then
        myGLACCT._GLTYP = "H"
      End If
      If RbLiability.Checked Then
        myGLACCT._GLTYP = "L"
      End If
      If RbEquity.Checked Then
        myGLACCT._GLTYP = "Q"
      End If
      If RbRevenue.Checked Then
        myGLACCT._GLTYP = "R"
      End If
      If RbExpense.Checked Then
        myGLACCT._GLTYP = "X"
      End If
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myGLACCT.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()
  End Sub
  Private Sub MoveToFile()
    With myGLACCT
      If ChkInActive.Checked Then
        ._ACREC = "I"
      Else
        ._ACREC = ""
      End If
      ._GLDSC = TxtGldsc.Text
      If ChkCash.Checked Then
        ._CSHYN = "Y"
      Else
        ._CSHYN = "N"
      End If
      ._RLNBR = MyUtils.CnvSng(TxtRlnbr.Text)
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim MyCommon2 As New Common2
    Dim Good As Boolean
    Dim I As Integer
    Dim Pos As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtFdnbr.Text) = 0 Then
      ErrorField(I) = "fdnbr"
      ErrorMsg(I) = "Fund is required"
      I = I + 1
    End If

    If RbAsset.Visible Then
      If RbAsset.Checked = False And RbHeader.Checked = False And RbLiability.Checked = False _
      And RbEquity.Checked = False And RbExpense.Checked = False And RbRevenue.Checked = False Then
        ErrorField(I) = "gltyp"
        ErrorMsg(I) = "Acct Type is required"
        I = I + 1
      End If
    End If

    Good = MyCommon2.GetDepSec(MyUtils.CnvSng(TxtFdnbr.Text), MyUtils.CnvSng(TxtSfund.Text), MyUtils.CnvSng(TxtDpnbr.Text))
    If Not Good Then
      ErrorField(I) = "fdnbr"
      ErrorMsg(I) = "No permission to create this account"
      I = I + 1
    End If

    Pos = InStr(TxtGldsc.Text, "'")
    If Pos > 0 Then
      ErrorField(I) = "gldsc"
      ErrorMsg(I) = "Quotes are not allowed"
      I = I + 1
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFdnbr, "")
    ErrProv.SetError(LblType, "")
    ErrProv.SetError(TxtGldsc, "")
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "fdnbr"
          ErrProv.SetError(TxtFdnbr, ErrorMsg(I))
        Case "gltyp"
          ErrProv.SetError(LblType, ErrorMsg(I))
        Case "gldsc"
          ErrProv.SetError(TxtGldsc, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub FrmGL107C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGL107.SbpScreen.Text = "GL107C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub TxtFdnbr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFdnbr.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfund_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSfund.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDpnbr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDpnbr.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtObnbr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtObnbr.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFnpgm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFnpgm.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSubfn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSubfn.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtRlnbr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRlnbr.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Public Sub FormatGrid(ByVal ds As DataSet)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).DefaultCellStyle.Format = "M/d/yyyy" '"##/##/####"
      .Columns(0).Width = 70
      .Columns(1).HeaderText = "Description"
      .Columns(1).Width = 200
      .Columns(2).HeaderText = "Ref No"
      .Columns(2).DefaultCellStyle.Format = "#######"
      .Columns(2).Width = 100
      .Columns(3).Width = 50
      .Columns(4).Width = 80
      If LblType2.Text = "Expense" Then
        .Columns(5).HeaderText = "Expense"
      Else
        .Columns(5).HeaderText = "Activity"
      End If
      .Columns(5).Width = 80
      .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(6).Width = 80
      .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(7).Visible = False
      .Columns(8).Visible = False
      .Columns(9).Visible = False
    End With
  End Sub
  Private Sub RefreshData()

    Dim ds As DataSet
    Dim myCommon2 As New Common2
    Dim WrkStrdt As Integer
    Dim WrkEnddt As Integer
    WrkStrdt = MyUtils.SetDBDate(DtPckFrom.Value)
    WrkEnddt = MyUtils.SetDBDate(DtPckTo.Value)

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    With myCommon2
      ds = .GetLedger(MyIsLedger, WrkGLType, TxtFdnbr.Text, TxtSfund.Text, TxtDpnbr.Text, TxtObnbr.Text, TxtFnpgm.Text,
      TxtSubfn.Text, WrkStrdt, WrkEnddt)
      LblBudget.Text = Format(.Budget, "###,###,###,##0.00")
      LblUnliqEnc.Text = Format(.UnliqEnc, "###,###,###,##0.00")
      LblExpend.Text = Format(.Expenses, "###,###,###,##0.00")
      LblUnencumb.Text = Format(.Unencumbered, "###,###,###,##0.00")
      FormatGrid(ds)
    End With
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub

  Private Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
    RefreshData()
  End Sub
  Private Sub TabCtl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabCtl1.SelectedIndexChanged
    SetSaveDelete()
  End Sub
  Private Sub SetSaveDelete()
    If MyIsLedger And TabCtl1.SelectedTab Is TpAcct Then
      MyFrmGL107.TBarSave.Enabled = True
      MyFrmGL107.TBarDelete.Enabled = False
      If WrkFdnbr > 0 Then
        MyFrmGL107.TBarDelete.Enabled = True
      End If
      If s_chg = False And s_full = False Then    '#sec
        MyFrmGL107.TBarSave.Visible = False
      End If
    Else
      MyFrmGL107.TBarSave.Enabled = False
      MyFrmGL107.TBarDelete.Enabled = False
    End If
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    Select Case DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value
      Case "A/P"
        MyFrmGL107DAP = New FrmGL107DAP
        MyFrmGL107DAP.MdiParent = Me.ParentForm
        MyFrmGL107DAP.WrkDate = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
        MyFrmGL107DAP.WrkInvoice = DataGrdView.Item(7, DataGrdView.CurrentRow.Index).Value
        MyFrmGL107DAP.WrkBchno = DataGrdView.Item(9, DataGrdView.CurrentRow.Index).Value
        MyFrmGL107DAP.Show()
        Me.Hide()
      Case "J/E"
        MyFrmGL107DJE = New FrmGL107DJE
        MyFrmGL107DJE.MdiParent = Me.ParentForm
        MyFrmGL107DJE.WrkDate = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
        MyFrmGL107DJE.WrkBchno = DataGrdView.Item(9, DataGrdView.CurrentRow.Index).Value
        MyFrmGL107DJE.WrkTran = DataGrdView.Item(7, DataGrdView.CurrentRow.Index).Value
        MyFrmGL107DJE.Show()
        Me.Hide()
      Case "A/R"
        MyFrmGL107DAR = New FrmGL107DAR
        MyFrmGL107DAR.MdiParent = Me.ParentForm
        MyFrmGL107DAR.WrkDate = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
        MyFrmGL107DAR.WrkBchno = DataGrdView.Item(7, DataGrdView.CurrentRow.Index).Value
        MyFrmGL107DAR.WrkTramt = MyUtils.CnvSng(DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value)
        MyFrmGL107DAR.WrkTdesc = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
        MyFrmGL107DAR.WrkRefno = DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value
        MyFrmGL107DAR.WrkPrf = DataGrdView.Item(8, DataGrdView.CurrentRow.Index).Value
        MyFrmGL107DAR.Show()
        Me.Hide()
      Case "P/O"
        MyFrmGL107DPO = New FrmGL107DPO
        MyFrmGL107DPO.MdiParent = Me.ParentForm
        MyFrmGL107DPO.WrkDate = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
        MyFrmGL107DPO.WrkPonbr = DataGrdView.Item(7, DataGrdView.CurrentRow.Index).Value
        MyFrmGL107DPO.Show()
        Me.Hide()
      Case "P/R"
        MyFrmGL107DPR = New FrmGL107DPR
        MyFrmGL107DPR.MdiParent = Me.ParentForm
        MyFrmGL107DPR.WrkDate = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
        MyFrmGL107DPR.WrkBchno = DataGrdView.Item(9, DataGrdView.CurrentRow.Index).Value
        MyFrmGL107DPR.Show()
        Me.Hide()
      Case "Tax"
        MyFrmGL107DTX = New FrmGL107DTX
        MyFrmGL107DTX.MdiParent = Me.ParentForm
        MyFrmGL107DTX.WrkDate = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
        MyFrmGL107DTX.WrkBchno = DataGrdView.Item(9, DataGrdView.CurrentRow.Index).Value
        MyFrmGL107DTX.Show()
        Me.Hide()
    End Select
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub

  Private Sub RbCurrent_Click(sender As Object, e As EventArgs) Handles RbCurrent.Click
    MyIsLedger = True
    SetSaveDelete()
  End Sub
  Private Sub RbHistory_Click(sender As Object, e As EventArgs) Handles RbHistory.Click
    MyIsLedger = False
    SetSaveDelete()
  End Sub

  Private Sub RbCurrent_CheckedChanged(sender As Object, e As EventArgs) Handles RbCurrent.CheckedChanged

  End Sub

  Private Sub RbHistory_CheckedChanged(sender As Object, e As EventArgs) Handles RbHistory.CheckedChanged

  End Sub
End Class
