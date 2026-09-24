Imports System.Threading.Tasks

Public Class FrmTXA099
  Inherits System.Windows.Forms.Form
  Dim myTBATCH As TBATCH.MyData
  Dim myTXBATCH As TXBATCH.MyData
  Dim myTXINV As TXINV.MyData
  Dim MyTXPEN As TXPEN.MyData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkType As String
  Friend WrkFee1 As Decimal
  Friend WrkFee2 As Decimal
  Friend WrkFee3 As Decimal
  Friend WrkFee4 As Decimal
  Friend WrkFee5 As Decimal
  Friend WrkMVFee As Decimal
  Friend WrkCAFee As Decimal
  Friend WrkFeeCd1 As String
  Friend WrkFeeCd2 As String
  Friend WrkFeeCd3 As String
  Friend WrkFeeCd4 As String
  Friend WrkFeeCd5 As String
  Friend WrkICode As String
  Dim WrkPayment As Boolean
  Dim NextSeqNo As Integer
  Dim ScrnLoad As Boolean
  Friend WithEvents LblProperty2 As System.Windows.Forms.Label
  Friend WithEvents LblProperty As System.Windows.Forms.Label
  Friend WithEvents label37 As System.Windows.Forms.Label
  Friend WithEvents GrpFees As System.Windows.Forms.GroupBox
  Friend WithEvents TxtFeeCd5 As System.Windows.Forms.TextBox
  Friend WithEvents LnkFeeCd5 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtFee5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtFeeCd4 As System.Windows.Forms.TextBox
  Friend WithEvents LnkFeeCd4 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtFee4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtFeeCd3 As System.Windows.Forms.TextBox
  Friend WithEvents LnkFeeCd3 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtFee3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtFeeCd2 As System.Windows.Forms.TextBox
  Friend WithEvents LnkFeeCd2 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtFee2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtFeeCd1 As System.Windows.Forms.TextBox
  Friend WithEvents LnkFeeCd1 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtFee1 As System.Windows.Forms.TextBox
  Friend WithEvents LblMVFee As System.Windows.Forms.Label
  Friend WithEvents LblSname As System.Windows.Forms.Label
  Friend WithEvents ChkReceipt As System.Windows.Forms.CheckBox
  Friend WithEvents TxtCAFee As System.Windows.Forms.TextBox
  Friend WithEvents TxtMVFee As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents RbPayBal As RadioButton
  Friend WithEvents RbPayDue As RadioButton
  Dim WrkComplete As Boolean

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
  Friend WithEvents LblName As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents LblType As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents LblYear As System.Windows.Forms.Label
  Friend WithEvents LblList As System.Windows.Forms.Label
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtCash As System.Windows.Forms.TextBox
  Friend WithEvents TxtCheck As System.Windows.Forms.TextBox
  Friend WithEvents TxtCredit As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TxtCheckNo As System.Windows.Forms.TextBox
  Friend WithEvents TxtComment As System.Windows.Forms.TextBox
  Friend WithEvents ChkValidate As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents TxtLien As System.Windows.Forms.TextBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents TxtInterest As System.Windows.Forms.TextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents TxtPrincipal As System.Windows.Forms.TextBox
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents TxtBond As System.Windows.Forms.TextBox
  Friend WithEvents LblBond As System.Windows.Forms.Label
  Friend WithEvents LblDiff As System.Windows.Forms.Label
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents TbMain As System.Windows.Forms.ToolBar
  Friend WithEvents TBarComplete As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarNext As System.Windows.Forms.ToolBarButton
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents TBarSep1 As System.Windows.Forms.ToolBarButton
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents LblAmt As System.Windows.Forms.Label
  Friend WithEvents LblDue As System.Windows.Forms.Label
  Friend WithEvents LblTotCash As System.Windows.Forms.Label
  Friend WithEvents LblTotCheck As System.Windows.Forms.Label
  Friend WithEvents LblTotCredit As System.Windows.Forms.Label
  Friend WithEvents LblTotAmt As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents Label26 As System.Windows.Forms.Label
  Friend WithEvents LblRunPaid As System.Windows.Forms.Label
  Friend WithEvents TxtRunAmount As System.Windows.Forms.TextBox
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents LblRunLeft As System.Windows.Forms.Label
  Friend WithEvents Label25 As System.Windows.Forms.Label
  Friend WithEvents LblCredit As System.Windows.Forms.Label
  Friend WithEvents LblCheck As System.Windows.Forms.Label
  Friend WithEvents LblCash As System.Windows.Forms.Label
  Friend WithEvents LblIntDate As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.LblName = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.LblType = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.LblList = New System.Windows.Forms.Label()
    Me.label2 = New System.Windows.Forms.Label()
    Me.label1 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblAmt = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtCheckNo = New System.Windows.Forms.TextBox()
    Me.TxtCredit = New System.Windows.Forms.TextBox()
    Me.LblCredit = New System.Windows.Forms.Label()
    Me.TxtCheck = New System.Windows.Forms.TextBox()
    Me.LblCheck = New System.Windows.Forms.Label()
    Me.TxtCash = New System.Windows.Forms.TextBox()
    Me.LblCash = New System.Windows.Forms.Label()
    Me.TxtComment = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.ChkValidate = New System.Windows.Forms.CheckBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.TxtBond = New System.Windows.Forms.TextBox()
    Me.LblBond = New System.Windows.Forms.Label()
    Me.LblDue = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TxtLien = New System.Windows.Forms.TextBox()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.TxtInterest = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.TxtPrincipal = New System.Windows.Forms.TextBox()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.LblDiff = New System.Windows.Forms.Label()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarComplete = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep1 = New System.Windows.Forms.ToolBarButton()
    Me.TBarNext = New System.Windows.Forms.ToolBarButton()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.LblTotAmt = New System.Windows.Forms.Label()
    Me.LblTotCredit = New System.Windows.Forms.Label()
    Me.LblTotCheck = New System.Windows.Forms.Label()
    Me.LblTotCash = New System.Windows.Forms.Label()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.Label22 = New System.Windows.Forms.Label()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.LblRunLeft = New System.Windows.Forms.Label()
    Me.Label25 = New System.Windows.Forms.Label()
    Me.TxtRunAmount = New System.Windows.Forms.TextBox()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.LblRunPaid = New System.Windows.Forms.Label()
    Me.Label26 = New System.Windows.Forms.Label()
    Me.LblIntDate = New System.Windows.Forms.Label()
    Me.LblProperty2 = New System.Windows.Forms.Label()
    Me.LblProperty = New System.Windows.Forms.Label()
    Me.label37 = New System.Windows.Forms.Label()
    Me.GrpFees = New System.Windows.Forms.GroupBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtCAFee = New System.Windows.Forms.TextBox()
    Me.LblMVFee = New System.Windows.Forms.Label()
    Me.TxtMVFee = New System.Windows.Forms.TextBox()
    Me.TxtFeeCd5 = New System.Windows.Forms.TextBox()
    Me.LnkFeeCd5 = New System.Windows.Forms.LinkLabel()
    Me.TxtFee5 = New System.Windows.Forms.TextBox()
    Me.TxtFeeCd4 = New System.Windows.Forms.TextBox()
    Me.LnkFeeCd4 = New System.Windows.Forms.LinkLabel()
    Me.TxtFee4 = New System.Windows.Forms.TextBox()
    Me.TxtFeeCd3 = New System.Windows.Forms.TextBox()
    Me.LnkFeeCd3 = New System.Windows.Forms.LinkLabel()
    Me.TxtFee3 = New System.Windows.Forms.TextBox()
    Me.TxtFeeCd2 = New System.Windows.Forms.TextBox()
    Me.LnkFeeCd2 = New System.Windows.Forms.LinkLabel()
    Me.TxtFee2 = New System.Windows.Forms.TextBox()
    Me.TxtFeeCd1 = New System.Windows.Forms.TextBox()
    Me.LnkFeeCd1 = New System.Windows.Forms.LinkLabel()
    Me.TxtFee1 = New System.Windows.Forms.TextBox()
    Me.LblSname = New System.Windows.Forms.Label()
    Me.ChkReceipt = New System.Windows.Forms.CheckBox()
    Me.RbPayBal = New System.Windows.Forms.RadioButton()
    Me.RbPayDue = New System.Windows.Forms.RadioButton()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox4.SuspendLayout()
    Me.GrpFees.SuspendLayout()
    Me.SuspendLayout()
    '
    'LblName
    '
    Me.LblName.BackColor = System.Drawing.SystemColors.Control
    Me.LblName.Location = New System.Drawing.Point(104, 24)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(280, 16)
    Me.LblName.TabIndex = 161
    Me.LblName.UseMnemonic = False
    '
    'Label7
    '
    Me.Label7.BackColor = System.Drawing.SystemColors.Control
    Me.Label7.Location = New System.Drawing.Point(160, 8)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(32, 12)
    Me.Label7.TabIndex = 160
    Me.Label7.Text = "Type"
    '
    'LblType
    '
    Me.LblType.BackColor = System.Drawing.SystemColors.Control
    Me.LblType.Location = New System.Drawing.Point(200, 8)
    Me.LblType.Name = "LblType"
    Me.LblType.Size = New System.Drawing.Size(16, 16)
    Me.LblType.TabIndex = 159
    '
    'Label3
    '
    Me.Label3.BackColor = System.Drawing.SystemColors.Control
    Me.Label3.Location = New System.Drawing.Point(224, 8)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(32, 12)
    Me.Label3.TabIndex = 158
    Me.Label3.Text = "Year"
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.SystemColors.Control
    Me.LblYear.Location = New System.Drawing.Point(256, 8)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(48, 16)
    Me.LblYear.TabIndex = 157
    '
    'LblList
    '
    Me.LblList.BackColor = System.Drawing.SystemColors.Control
    Me.LblList.Location = New System.Drawing.Point(104, 8)
    Me.LblList.Name = "LblList"
    Me.LblList.Size = New System.Drawing.Size(48, 16)
    Me.LblList.TabIndex = 156
    '
    'label2
    '
    Me.label2.BackColor = System.Drawing.SystemColors.Control
    Me.label2.Location = New System.Drawing.Point(8, 24)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(84, 12)
    Me.label2.TabIndex = 155
    Me.label2.Text = "Name of Owner"
    '
    'label1
    '
    Me.label1.BackColor = System.Drawing.SystemColors.Control
    Me.label1.Location = New System.Drawing.Point(8, 8)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(36, 12)
    Me.label1.TabIndex = 154
    Me.label1.Text = "List #"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbPayBal)
    Me.GroupBox1.Controls.Add(Me.RbPayDue)
    Me.GroupBox1.Controls.Add(Me.LblAmt)
    Me.GroupBox1.Controls.Add(Me.Label9)
    Me.GroupBox1.Controls.Add(Me.Label8)
    Me.GroupBox1.Controls.Add(Me.TxtCheckNo)
    Me.GroupBox1.Controls.Add(Me.TxtCredit)
    Me.GroupBox1.Controls.Add(Me.LblCredit)
    Me.GroupBox1.Controls.Add(Me.TxtCheck)
    Me.GroupBox1.Controls.Add(Me.LblCheck)
    Me.GroupBox1.Controls.Add(Me.TxtCash)
    Me.GroupBox1.Controls.Add(Me.LblCash)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(10, 93)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(260, 124)
    Me.GroupBox1.TabIndex = 0
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Amounts"
    '
    'LblAmt
    '
    Me.LblAmt.BackColor = System.Drawing.SystemColors.Control
    Me.LblAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAmt.Location = New System.Drawing.Point(56, 100)
    Me.LblAmt.Name = "LblAmt"
    Me.LblAmt.Size = New System.Drawing.Size(80, 12)
    Me.LblAmt.TabIndex = 4
    Me.LblAmt.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label9
    '
    Me.Label9.BackColor = System.Drawing.SystemColors.Control
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(8, 100)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(36, 12)
    Me.Label9.TabIndex = 163
    Me.Label9.Text = "Total"
    '
    'Label8
    '
    Me.Label8.BackColor = System.Drawing.SystemColors.Control
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(142, 56)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(24, 12)
    Me.Label8.TabIndex = 162
    Me.Label8.Text = "No."
    '
    'TxtCheckNo
    '
    Me.TxtCheckNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCheckNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCheckNo.Location = New System.Drawing.Point(168, 52)
    Me.TxtCheckNo.MaxLength = 10
    Me.TxtCheckNo.Name = "TxtCheckNo"
    Me.TxtCheckNo.Size = New System.Drawing.Size(72, 20)
    Me.TxtCheckNo.TabIndex = 2
    '
    'TxtCredit
    '
    Me.TxtCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCredit.Location = New System.Drawing.Point(56, 76)
    Me.TxtCredit.MaxLength = 15
    Me.TxtCredit.Name = "TxtCredit"
    Me.TxtCredit.Size = New System.Drawing.Size(80, 20)
    Me.TxtCredit.TabIndex = 3
    Me.TxtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblCredit
    '
    Me.LblCredit.BackColor = System.Drawing.SystemColors.Control
    Me.LblCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCredit.Location = New System.Drawing.Point(8, 76)
    Me.LblCredit.Name = "LblCredit"
    Me.LblCredit.Size = New System.Drawing.Size(36, 16)
    Me.LblCredit.TabIndex = 159
    Me.LblCredit.Text = "Credit"
    '
    'TxtCheck
    '
    Me.TxtCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCheck.Location = New System.Drawing.Point(56, 52)
    Me.TxtCheck.MaxLength = 15
    Me.TxtCheck.Name = "TxtCheck"
    Me.TxtCheck.Size = New System.Drawing.Size(80, 20)
    Me.TxtCheck.TabIndex = 1
    Me.TxtCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblCheck
    '
    Me.LblCheck.BackColor = System.Drawing.SystemColors.Control
    Me.LblCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCheck.Location = New System.Drawing.Point(8, 52)
    Me.LblCheck.Name = "LblCheck"
    Me.LblCheck.Size = New System.Drawing.Size(42, 16)
    Me.LblCheck.TabIndex = 157
    Me.LblCheck.Text = "Check"
    '
    'TxtCash
    '
    Me.TxtCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCash.Location = New System.Drawing.Point(56, 28)
    Me.TxtCash.MaxLength = 15
    Me.TxtCash.Name = "TxtCash"
    Me.TxtCash.Size = New System.Drawing.Size(80, 20)
    Me.TxtCash.TabIndex = 0
    Me.TxtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblCash
    '
    Me.LblCash.BackColor = System.Drawing.SystemColors.Control
    Me.LblCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCash.Location = New System.Drawing.Point(8, 28)
    Me.LblCash.Name = "LblCash"
    Me.LblCash.Size = New System.Drawing.Size(36, 16)
    Me.LblCash.TabIndex = 155
    Me.LblCash.Text = "Cash"
    '
    'TxtComment
    '
    Me.TxtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtComment.Location = New System.Drawing.Point(66, 223)
    Me.TxtComment.MaxLength = 20
    Me.TxtComment.Name = "TxtComment"
    Me.TxtComment.Size = New System.Drawing.Size(150, 20)
    Me.TxtComment.TabIndex = 4
    '
    'Label10
    '
    Me.Label10.BackColor = System.Drawing.SystemColors.Control
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(8, 226)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(56, 12)
    Me.Label10.TabIndex = 163
    Me.Label10.Text = "Comment"
    '
    'ChkValidate
    '
    Me.ChkValidate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkValidate.Location = New System.Drawing.Point(307, 135)
    Me.ChkValidate.Name = "ChkValidate"
    Me.ChkValidate.Size = New System.Drawing.Size(96, 16)
    Me.ChkValidate.TabIndex = 5
    Me.ChkValidate.Text = "Validate Bill?"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.TxtBond)
    Me.GroupBox2.Controls.Add(Me.LblBond)
    Me.GroupBox2.Controls.Add(Me.LblDue)
    Me.GroupBox2.Controls.Add(Me.Label12)
    Me.GroupBox2.Controls.Add(Me.TxtLien)
    Me.GroupBox2.Controls.Add(Me.Label14)
    Me.GroupBox2.Controls.Add(Me.TxtInterest)
    Me.GroupBox2.Controls.Add(Me.Label15)
    Me.GroupBox2.Controls.Add(Me.TxtPrincipal)
    Me.GroupBox2.Controls.Add(Me.Label16)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(8, 249)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(168, 140)
    Me.GroupBox2.TabIndex = 166
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Payment"
    '
    'TxtBond
    '
    Me.TxtBond.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBond.Location = New System.Drawing.Point(70, 88)
    Me.TxtBond.MaxLength = 10
    Me.TxtBond.Name = "TxtBond"
    Me.TxtBond.Size = New System.Drawing.Size(80, 20)
    Me.TxtBond.TabIndex = 9
    Me.TxtBond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblBond
    '
    Me.LblBond.BackColor = System.Drawing.SystemColors.Control
    Me.LblBond.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBond.Location = New System.Drawing.Point(6, 88)
    Me.LblBond.Name = "LblBond"
    Me.LblBond.Size = New System.Drawing.Size(56, 12)
    Me.LblBond.TabIndex = 165
    Me.LblBond.Text = "Bond Int"
    '
    'LblDue
    '
    Me.LblDue.BackColor = System.Drawing.SystemColors.Control
    Me.LblDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDue.Location = New System.Drawing.Point(70, 112)
    Me.LblDue.Name = "LblDue"
    Me.LblDue.Size = New System.Drawing.Size(80, 12)
    Me.LblDue.TabIndex = 4
    Me.LblDue.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label12
    '
    Me.Label12.BackColor = System.Drawing.SystemColors.Control
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(6, 112)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(56, 12)
    Me.Label12.TabIndex = 163
    Me.Label12.Text = "Total Due"
    '
    'TxtLien
    '
    Me.TxtLien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLien.Location = New System.Drawing.Point(70, 64)
    Me.TxtLien.MaxLength = 6
    Me.TxtLien.Name = "TxtLien"
    Me.TxtLien.Size = New System.Drawing.Size(80, 20)
    Me.TxtLien.TabIndex = 8
    Me.TxtLien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label14
    '
    Me.Label14.BackColor = System.Drawing.SystemColors.Control
    Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label14.Location = New System.Drawing.Point(6, 64)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(36, 12)
    Me.Label14.TabIndex = 159
    Me.Label14.Text = "Lien"
    '
    'TxtInterest
    '
    Me.TxtInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtInterest.Location = New System.Drawing.Point(70, 40)
    Me.TxtInterest.MaxLength = 8
    Me.TxtInterest.Name = "TxtInterest"
    Me.TxtInterest.Size = New System.Drawing.Size(80, 20)
    Me.TxtInterest.TabIndex = 7
    Me.TxtInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label15
    '
    Me.Label15.BackColor = System.Drawing.SystemColors.Control
    Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label15.Location = New System.Drawing.Point(6, 40)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(48, 12)
    Me.Label15.TabIndex = 157
    Me.Label15.Text = "Interest"
    '
    'TxtPrincipal
    '
    Me.TxtPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPrincipal.Location = New System.Drawing.Point(70, 16)
    Me.TxtPrincipal.MaxLength = 12
    Me.TxtPrincipal.Name = "TxtPrincipal"
    Me.TxtPrincipal.Size = New System.Drawing.Size(80, 20)
    Me.TxtPrincipal.TabIndex = 6
    Me.TxtPrincipal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label16
    '
    Me.Label16.BackColor = System.Drawing.SystemColors.Control
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.Location = New System.Drawing.Point(6, 16)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(48, 12)
    Me.Label16.TabIndex = 155
    Me.Label16.Text = "Principal"
    '
    'LblDiff
    '
    Me.LblDiff.BackColor = System.Drawing.SystemColors.Control
    Me.LblDiff.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDiff.Location = New System.Drawing.Point(82, 398)
    Me.LblDiff.Name = "LblDiff"
    Me.LblDiff.Size = New System.Drawing.Size(80, 12)
    Me.LblDiff.TabIndex = 168
    Me.LblDiff.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label18
    '
    Me.Label18.BackColor = System.Drawing.SystemColors.Control
    Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label18.Location = New System.Drawing.Point(18, 398)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(56, 12)
    Me.Label18.TabIndex = 167
    Me.Label18.Text = "Difference"
    '
    'TbMain
    '
    Me.TbMain.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TbMain.AutoSize = False
    Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarComplete, Me.TBarSep1, Me.TBarNext})
    Me.TbMain.Dock = System.Windows.Forms.DockStyle.None
    Me.TbMain.DropDownArrows = True
    Me.TbMain.Location = New System.Drawing.Point(444, 362)
    Me.TbMain.Name = "TbMain"
    Me.TbMain.ShowToolTips = True
    Me.TbMain.Size = New System.Drawing.Size(146, 45)
    Me.TbMain.TabIndex = 169
    '
    'TBarComplete
    '
    Me.TBarComplete.Name = "TBarComplete"
    Me.TBarComplete.Text = "C&omplete"
    '
    'TBarSep1
    '
    Me.TBarSep1.Name = "TBarSep1"
    Me.TBarSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
    '
    'TBarNext
    '
    Me.TBarNext.Name = "TBarNext"
    Me.TBarNext.Text = "Ne&xt Entry"
    '
    'ImageList1
    '
    Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
    Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.LblTotAmt)
    Me.GroupBox3.Controls.Add(Me.LblTotCredit)
    Me.GroupBox3.Controls.Add(Me.LblTotCheck)
    Me.GroupBox3.Controls.Add(Me.LblTotCash)
    Me.GroupBox3.Controls.Add(Me.Label19)
    Me.GroupBox3.Controls.Add(Me.Label21)
    Me.GroupBox3.Controls.Add(Me.Label22)
    Me.GroupBox3.Controls.Add(Me.Label23)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(450, 77)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(144, 112)
    Me.GroupBox3.TabIndex = 170
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Amounts (Totals)"
    '
    'LblTotAmt
    '
    Me.LblTotAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotAmt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblTotAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotAmt.Location = New System.Drawing.Point(56, 88)
    Me.LblTotAmt.Name = "LblTotAmt"
    Me.LblTotAmt.Size = New System.Drawing.Size(80, 20)
    Me.LblTotAmt.TabIndex = 174
    Me.LblTotAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotCredit
    '
    Me.LblTotCredit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotCredit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblTotCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotCredit.Location = New System.Drawing.Point(56, 64)
    Me.LblTotCredit.Name = "LblTotCredit"
    Me.LblTotCredit.Size = New System.Drawing.Size(80, 20)
    Me.LblTotCredit.TabIndex = 173
    Me.LblTotCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotCheck
    '
    Me.LblTotCheck.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotCheck.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblTotCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotCheck.Location = New System.Drawing.Point(56, 40)
    Me.LblTotCheck.Name = "LblTotCheck"
    Me.LblTotCheck.Size = New System.Drawing.Size(80, 20)
    Me.LblTotCheck.TabIndex = 166
    Me.LblTotCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotCash
    '
    Me.LblTotCash.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotCash.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblTotCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotCash.Location = New System.Drawing.Point(56, 16)
    Me.LblTotCash.Name = "LblTotCash"
    Me.LblTotCash.Size = New System.Drawing.Size(80, 20)
    Me.LblTotCash.TabIndex = 165
    Me.LblTotCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label19
    '
    Me.Label19.BackColor = System.Drawing.SystemColors.Control
    Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label19.Location = New System.Drawing.Point(8, 88)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(36, 12)
    Me.Label19.TabIndex = 163
    Me.Label19.Text = "Total"
    '
    'Label21
    '
    Me.Label21.BackColor = System.Drawing.SystemColors.Control
    Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label21.Location = New System.Drawing.Point(8, 64)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(36, 12)
    Me.Label21.TabIndex = 159
    Me.Label21.Text = "Credit"
    '
    'Label22
    '
    Me.Label22.BackColor = System.Drawing.SystemColors.Control
    Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label22.Location = New System.Drawing.Point(8, 40)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(36, 12)
    Me.Label22.TabIndex = 157
    Me.Label22.Text = "Check"
    '
    'Label23
    '
    Me.Label23.BackColor = System.Drawing.SystemColors.Control
    Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label23.Location = New System.Drawing.Point(8, 16)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(36, 12)
    Me.Label23.TabIndex = 155
    Me.Label23.Text = "Cash"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.LblRunLeft)
    Me.GroupBox4.Controls.Add(Me.Label25)
    Me.GroupBox4.Controls.Add(Me.TxtRunAmount)
    Me.GroupBox4.Controls.Add(Me.Label20)
    Me.GroupBox4.Controls.Add(Me.LblRunPaid)
    Me.GroupBox4.Controls.Add(Me.Label26)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(450, 250)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(144, 88)
    Me.GroupBox4.TabIndex = 171
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Running Check Total"
    '
    'LblRunLeft
    '
    Me.LblRunLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblRunLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblRunLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblRunLeft.Location = New System.Drawing.Point(56, 64)
    Me.LblRunLeft.Name = "LblRunLeft"
    Me.LblRunLeft.Size = New System.Drawing.Size(80, 20)
    Me.LblRunLeft.TabIndex = 178
    Me.LblRunLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label25
    '
    Me.Label25.BackColor = System.Drawing.SystemColors.Control
    Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label25.Location = New System.Drawing.Point(8, 68)
    Me.Label25.Name = "Label25"
    Me.Label25.Size = New System.Drawing.Size(36, 12)
    Me.Label25.TabIndex = 177
    Me.Label25.Text = "Left"
    '
    'TxtRunAmount
    '
    Me.TxtRunAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRunAmount.Location = New System.Drawing.Point(56, 40)
    Me.TxtRunAmount.MaxLength = 15
    Me.TxtRunAmount.Name = "TxtRunAmount"
    Me.TxtRunAmount.Size = New System.Drawing.Size(80, 20)
    Me.TxtRunAmount.TabIndex = 175
    Me.TxtRunAmount.TabStop = False
    Me.TxtRunAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label20
    '
    Me.Label20.BackColor = System.Drawing.SystemColors.Control
    Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label20.Location = New System.Drawing.Point(8, 44)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(44, 12)
    Me.Label20.TabIndex = 176
    Me.Label20.Text = "Amount"
    '
    'LblRunPaid
    '
    Me.LblRunPaid.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblRunPaid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblRunPaid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblRunPaid.Location = New System.Drawing.Point(56, 16)
    Me.LblRunPaid.Name = "LblRunPaid"
    Me.LblRunPaid.Size = New System.Drawing.Size(80, 20)
    Me.LblRunPaid.TabIndex = 174
    Me.LblRunPaid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label26
    '
    Me.Label26.BackColor = System.Drawing.SystemColors.Control
    Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label26.Location = New System.Drawing.Point(8, 20)
    Me.Label26.Name = "Label26"
    Me.Label26.Size = New System.Drawing.Size(36, 12)
    Me.Label26.TabIndex = 163
    Me.Label26.Text = "Paid"
    '
    'LblIntDate
    '
    Me.LblIntDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblIntDate.ForeColor = System.Drawing.Color.Magenta
    Me.LblIntDate.Location = New System.Drawing.Point(304, 8)
    Me.LblIntDate.Name = "LblIntDate"
    Me.LblIntDate.Size = New System.Drawing.Size(120, 16)
    Me.LblIntDate.TabIndex = 174
    Me.LblIntDate.Text = "INT DATE CHANGED"
    '
    'LblProperty2
    '
    Me.LblProperty2.BackColor = System.Drawing.SystemColors.Control
    Me.LblProperty2.Location = New System.Drawing.Point(99, 74)
    Me.LblProperty2.Name = "LblProperty2"
    Me.LblProperty2.Size = New System.Drawing.Size(232, 16)
    Me.LblProperty2.TabIndex = 177
    '
    'LblProperty
    '
    Me.LblProperty.BackColor = System.Drawing.SystemColors.Control
    Me.LblProperty.Location = New System.Drawing.Point(99, 58)
    Me.LblProperty.Name = "LblProperty"
    Me.LblProperty.Size = New System.Drawing.Size(232, 16)
    Me.LblProperty.TabIndex = 176
    '
    'label37
    '
    Me.label37.BackColor = System.Drawing.SystemColors.Control
    Me.label37.Location = New System.Drawing.Point(7, 58)
    Me.label37.Name = "label37"
    Me.label37.Size = New System.Drawing.Size(64, 16)
    Me.label37.TabIndex = 175
    Me.label37.Text = "Property"
    '
    'GrpFees
    '
    Me.GrpFees.Controls.Add(Me.Label4)
    Me.GrpFees.Controls.Add(Me.TxtCAFee)
    Me.GrpFees.Controls.Add(Me.LblMVFee)
    Me.GrpFees.Controls.Add(Me.TxtMVFee)
    Me.GrpFees.Controls.Add(Me.TxtFeeCd5)
    Me.GrpFees.Controls.Add(Me.LnkFeeCd5)
    Me.GrpFees.Controls.Add(Me.TxtFee5)
    Me.GrpFees.Controls.Add(Me.TxtFeeCd4)
    Me.GrpFees.Controls.Add(Me.LnkFeeCd4)
    Me.GrpFees.Controls.Add(Me.TxtFee4)
    Me.GrpFees.Controls.Add(Me.TxtFeeCd3)
    Me.GrpFees.Controls.Add(Me.LnkFeeCd3)
    Me.GrpFees.Controls.Add(Me.TxtFee3)
    Me.GrpFees.Controls.Add(Me.TxtFeeCd2)
    Me.GrpFees.Controls.Add(Me.LnkFeeCd2)
    Me.GrpFees.Controls.Add(Me.TxtFee2)
    Me.GrpFees.Controls.Add(Me.TxtFeeCd1)
    Me.GrpFees.Controls.Add(Me.LnkFeeCd1)
    Me.GrpFees.Controls.Add(Me.TxtFee1)
    Me.GrpFees.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpFees.Location = New System.Drawing.Point(237, 223)
    Me.GrpFees.Name = "GrpFees"
    Me.GrpFees.Size = New System.Drawing.Size(166, 175)
    Me.GrpFees.TabIndex = 178
    Me.GrpFees.TabStop = False
    Me.GrpFees.Text = "Fees"
    '
    'Label4
    '
    Me.Label4.BackColor = System.Drawing.SystemColors.Control
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(92, 154)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(48, 12)
    Me.Label4.TabIndex = 184
    Me.Label4.Text = "CA Fee"
    '
    'TxtCAFee
    '
    Me.TxtCAFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCAFee.Location = New System.Drawing.Point(6, 151)
    Me.TxtCAFee.MaxLength = 10
    Me.TxtCAFee.Name = "TxtCAFee"
    Me.TxtCAFee.Size = New System.Drawing.Size(80, 20)
    Me.TxtCAFee.TabIndex = 183
    Me.TxtCAFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblMVFee
    '
    Me.LblMVFee.BackColor = System.Drawing.SystemColors.Control
    Me.LblMVFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMVFee.Location = New System.Drawing.Point(92, 133)
    Me.LblMVFee.Name = "LblMVFee"
    Me.LblMVFee.Size = New System.Drawing.Size(48, 12)
    Me.LblMVFee.TabIndex = 182
    Me.LblMVFee.Text = "MV Fee"
    '
    'TxtMVFee
    '
    Me.TxtMVFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMVFee.Location = New System.Drawing.Point(6, 130)
    Me.TxtMVFee.MaxLength = 10
    Me.TxtMVFee.Name = "TxtMVFee"
    Me.TxtMVFee.Size = New System.Drawing.Size(80, 20)
    Me.TxtMVFee.TabIndex = 181
    Me.TxtMVFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtFeeCd5
    '
    Me.TxtFeeCd5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFeeCd5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFeeCd5.Location = New System.Drawing.Point(130, 107)
    Me.TxtFeeCd5.MaxLength = 2
    Me.TxtFeeCd5.Name = "TxtFeeCd5"
    Me.TxtFeeCd5.Size = New System.Drawing.Size(24, 20)
    Me.TxtFeeCd5.TabIndex = 180
    '
    'LnkFeeCd5
    '
    Me.LnkFeeCd5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFeeCd5.Location = New System.Drawing.Point(92, 109)
    Me.LnkFeeCd5.Name = "LnkFeeCd5"
    Me.LnkFeeCd5.Size = New System.Drawing.Size(34, 17)
    Me.LnkFeeCd5.TabIndex = 179
    Me.LnkFeeCd5.TabStop = True
    Me.LnkFeeCd5.Text = "Code"
    '
    'TxtFee5
    '
    Me.TxtFee5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFee5.Location = New System.Drawing.Point(6, 107)
    Me.TxtFee5.MaxLength = 10
    Me.TxtFee5.Name = "TxtFee5"
    Me.TxtFee5.Size = New System.Drawing.Size(80, 20)
    Me.TxtFee5.TabIndex = 178
    Me.TxtFee5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtFeeCd4
    '
    Me.TxtFeeCd4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFeeCd4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFeeCd4.Location = New System.Drawing.Point(130, 84)
    Me.TxtFeeCd4.MaxLength = 2
    Me.TxtFeeCd4.Name = "TxtFeeCd4"
    Me.TxtFeeCd4.Size = New System.Drawing.Size(24, 20)
    Me.TxtFeeCd4.TabIndex = 177
    '
    'LnkFeeCd4
    '
    Me.LnkFeeCd4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFeeCd4.Location = New System.Drawing.Point(92, 86)
    Me.LnkFeeCd4.Name = "LnkFeeCd4"
    Me.LnkFeeCd4.Size = New System.Drawing.Size(34, 17)
    Me.LnkFeeCd4.TabIndex = 176
    Me.LnkFeeCd4.TabStop = True
    Me.LnkFeeCd4.Text = "Code"
    '
    'TxtFee4
    '
    Me.TxtFee4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFee4.Location = New System.Drawing.Point(6, 84)
    Me.TxtFee4.MaxLength = 10
    Me.TxtFee4.Name = "TxtFee4"
    Me.TxtFee4.Size = New System.Drawing.Size(80, 20)
    Me.TxtFee4.TabIndex = 175
    Me.TxtFee4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtFeeCd3
    '
    Me.TxtFeeCd3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFeeCd3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFeeCd3.Location = New System.Drawing.Point(130, 61)
    Me.TxtFeeCd3.MaxLength = 2
    Me.TxtFeeCd3.Name = "TxtFeeCd3"
    Me.TxtFeeCd3.Size = New System.Drawing.Size(24, 20)
    Me.TxtFeeCd3.TabIndex = 174
    '
    'LnkFeeCd3
    '
    Me.LnkFeeCd3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFeeCd3.Location = New System.Drawing.Point(92, 63)
    Me.LnkFeeCd3.Name = "LnkFeeCd3"
    Me.LnkFeeCd3.Size = New System.Drawing.Size(34, 17)
    Me.LnkFeeCd3.TabIndex = 173
    Me.LnkFeeCd3.TabStop = True
    Me.LnkFeeCd3.Text = "Code"
    '
    'TxtFee3
    '
    Me.TxtFee3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFee3.Location = New System.Drawing.Point(6, 61)
    Me.TxtFee3.MaxLength = 10
    Me.TxtFee3.Name = "TxtFee3"
    Me.TxtFee3.Size = New System.Drawing.Size(80, 20)
    Me.TxtFee3.TabIndex = 172
    Me.TxtFee3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtFeeCd2
    '
    Me.TxtFeeCd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFeeCd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFeeCd2.Location = New System.Drawing.Point(130, 38)
    Me.TxtFeeCd2.MaxLength = 2
    Me.TxtFeeCd2.Name = "TxtFeeCd2"
    Me.TxtFeeCd2.Size = New System.Drawing.Size(24, 20)
    Me.TxtFeeCd2.TabIndex = 171
    '
    'LnkFeeCd2
    '
    Me.LnkFeeCd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFeeCd2.Location = New System.Drawing.Point(92, 41)
    Me.LnkFeeCd2.Name = "LnkFeeCd2"
    Me.LnkFeeCd2.Size = New System.Drawing.Size(34, 17)
    Me.LnkFeeCd2.TabIndex = 170
    Me.LnkFeeCd2.TabStop = True
    Me.LnkFeeCd2.Text = "Code"
    '
    'TxtFee2
    '
    Me.TxtFee2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFee2.Location = New System.Drawing.Point(6, 38)
    Me.TxtFee2.MaxLength = 10
    Me.TxtFee2.Name = "TxtFee2"
    Me.TxtFee2.Size = New System.Drawing.Size(80, 20)
    Me.TxtFee2.TabIndex = 169
    Me.TxtFee2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtFeeCd1
    '
    Me.TxtFeeCd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFeeCd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFeeCd1.Location = New System.Drawing.Point(130, 15)
    Me.TxtFeeCd1.MaxLength = 2
    Me.TxtFeeCd1.Name = "TxtFeeCd1"
    Me.TxtFeeCd1.Size = New System.Drawing.Size(24, 20)
    Me.TxtFeeCd1.TabIndex = 168
    '
    'LnkFeeCd1
    '
    Me.LnkFeeCd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFeeCd1.Location = New System.Drawing.Point(92, 18)
    Me.LnkFeeCd1.Name = "LnkFeeCd1"
    Me.LnkFeeCd1.Size = New System.Drawing.Size(34, 17)
    Me.LnkFeeCd1.TabIndex = 167
    Me.LnkFeeCd1.TabStop = True
    Me.LnkFeeCd1.Text = "Code"
    '
    'TxtFee1
    '
    Me.TxtFee1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFee1.Location = New System.Drawing.Point(6, 15)
    Me.TxtFee1.MaxLength = 10
    Me.TxtFee1.Name = "TxtFee1"
    Me.TxtFee1.Size = New System.Drawing.Size(80, 20)
    Me.TxtFee1.TabIndex = 10
    Me.TxtFee1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblSname
    '
    Me.LblSname.BackColor = System.Drawing.SystemColors.Control
    Me.LblSname.Location = New System.Drawing.Point(104, 40)
    Me.LblSname.Name = "LblSname"
    Me.LblSname.Size = New System.Drawing.Size(280, 16)
    Me.LblSname.TabIndex = 179
    Me.LblSname.UseMnemonic = False
    '
    'ChkReceipt
    '
    Me.ChkReceipt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkReceipt.Location = New System.Drawing.Point(307, 159)
    Me.ChkReceipt.Name = "ChkReceipt"
    Me.ChkReceipt.Size = New System.Drawing.Size(96, 16)
    Me.ChkReceipt.TabIndex = 180
    Me.ChkReceipt.Text = "Print Receipt?"
    '
    'RbPayBal
    '
    Me.RbPayBal.AutoSize = True
    Me.RbPayBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPayBal.Location = New System.Drawing.Point(132, 7)
    Me.RbPayBal.Name = "RbPayBal"
    Me.RbPayBal.Size = New System.Drawing.Size(64, 17)
    Me.RbPayBal.TabIndex = 185
    Me.RbPayBal.Text = "Balance"
    Me.RbPayBal.UseVisualStyleBackColor = True
    '
    'RbPayDue
    '
    Me.RbPayDue.AutoSize = True
    Me.RbPayDue.Checked = True
    Me.RbPayDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPayDue.Location = New System.Drawing.Point(68, 7)
    Me.RbPayDue.Name = "RbPayDue"
    Me.RbPayDue.Size = New System.Drawing.Size(45, 17)
    Me.RbPayDue.TabIndex = 184
    Me.RbPayDue.TabStop = True
    Me.RbPayDue.Text = "Due"
    Me.RbPayDue.UseVisualStyleBackColor = True
    '
    'FrmTXA099
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(602, 420)
    Me.Controls.Add(Me.TbMain)
    Me.Controls.Add(Me.ChkReceipt)
    Me.Controls.Add(Me.LblSname)
    Me.Controls.Add(Me.GrpFees)
    Me.Controls.Add(Me.LblProperty2)
    Me.Controls.Add(Me.LblProperty)
    Me.Controls.Add(Me.label37)
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.ChkValidate)
    Me.Controls.Add(Me.TxtComment)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.LblName)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.LblType)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.LblList)
    Me.Controls.Add(Me.label2)
    Me.Controls.Add(Me.label1)
    Me.Controls.Add(Me.LblDiff)
    Me.Controls.Add(Me.Label18)
    Me.Controls.Add(Me.LblIntDate)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA099"
    Me.Text = "Apply Payments"
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    Me.GrpFees.ResumeLayout(False)
    Me.GrpFees.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTXA099_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkSubTots(2) As Decimal
    Dim WrkTotAmt As Decimal
    Dim WrkFamily As String

    myTBATCH = New TBATCH.MyData(myDBConnect)
    myTXBATCH = New TXBATCH.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    MyTXPEN = New TXPEN.MyData(myDBConnect)

    ScrnLoad = True
    LblList.Text = WrkListNo
    LblYear.Text = WrkYear
    LblType.Text = WrkType
    LblName.Text = MyFrmTXA09B.LblName.Text
    LblSname.Text = MyFrmTXA09B.LblSname.Text
    LblProperty.Text = MyFrmTXA09B.LblProperty.Text
    LblProperty2.Text = MyFrmTXA09B.LblProperty2.Text
    LblAmt.Text = "0"
    If MyInterestDate <> MyInterestOverrideDate Then
      LblIntDate.Visible = True
    Else
      LblIntDate.Visible = False
    End If
    TxtPrincipal.Text = Format(MyFrmTXA09B.LblTax.Text, "standard")
    TxtInterest.Text = Format(MyFrmTXA09B.LblInterest.Text, "standard")
    TxtLien.Text = MyFrmTXA09B.LblLien.Text
    TxtBond.Text = Format(MyFrmTXA09B.LblBond.Text, "standard")
    TxtFee1.Text = Format(WrkFee1, "standard")
    TxtFee2.Text = Format(WrkFee2, "standard")
    TxtFee3.Text = Format(WrkFee3, "standard")
    TxtFee4.Text = Format(WrkFee4, "standard")
    TxtFee5.Text = Format(WrkFee5, "standard")
    TxtFeeCd1.Text = WrkFeeCd1
    TxtFeeCd2.Text = WrkFeeCd2
    TxtFeeCd3.Text = WrkFeeCd3
    TxtFeeCd4.Text = WrkFeeCd4
    TxtFeeCd5.Text = WrkFeeCd5
    WrkFamily = GetTXTypeFamily(WrkType)
    Select Case WrkFamily
      Case "M", "S"
        If MyUtils.CnvSng(MyFrmTXA09B.LblFee.Text) > 0 Then
          TxtMVFee.Text = Format(WrkMVFee, "standard")
        Else
          TxtMVFee.Text = Format(0, "standard")
        End If
        TxtMVFee.Visible = True
        LblMVFee.Visible = True
      Case "A"
        LblBond.Visible = True
        TxtBond.Visible = True
      Case Else
        LblBond.Visible = False
        TxtBond.Visible = False
        TxtMVFee.Visible = False
        LblMVFee.Visible = False
    End Select
    TxtCAFee.Text = Format(WrkCAFee, "standard")
    If MyUtils.CnvSng(TxtPrincipal.Text) = 0 And MyUtils.CnvSng(MyFrmTXA09B.LblRemain.Text) > 0 Then
      TxtPrincipal.Text = Format(MyUtils.CnvSng(MyFrmTXA09B.LblRemain.Text), "standard")
      LblDue.Text = Format(MyUtils.CnvSng(MyFrmTXA09B.LblRemain.Text) + MyUtils.CnvSng(MyFrmTXA09B.LblFee.Text), "standard")
    Else
      LblDue.Text = Format(MyFrmTXA09B.LblDue.Text, "standard")
    End If
    If MyLastCheckNo <> String.Empty Then
      TxtCheckNo.Text = MyLastCheckNo
    End If
    If MyLastComment <> String.Empty Then
      TxtComment.Text = MyLastComment
    End If
    CalcDiff()
    If MyUtils.CnvSng(MyFrmTXA09B.LblFee.Text) <> WrkFee1 + WrkFee2 + WrkFee3 + WrkFee4 +
      WrkFee5 + WrkCAFee + MyUtils.CnvSng(TxtMVFee.Text) Then
      MsgBox("Please adjust fees...Fee amounts do NOT match Fees Total (Previous screen).",
        MsgBoxStyle.Exclamation, "Cannot determine proper fee breakdown")
    End If
    WrkSubTots = myTXBATCH.CalcBatchSubTotals(MyBatch, MyBatchNo)
    LblTotCash.Text = Format(WrkSubTots(0), "standard")
    LblTotCheck.Text = Format(WrkSubTots(1), "standard")
    LblTotCredit.Text = Format(WrkSubTots(2), "standard")
    WrkTotAmt = WrkSubTots(0) + WrkSubTots(1) + WrkSubTots(2)
    LblTotAmt.Text = Format(WrkTotAmt, "standard")
    If MyCheckAmount > 0 Then
      TxtRunAmount.Text = MyCheckAmount
      LblRunPaid.Text = MyUtils.CnvSng(LblAmt.Text) + MyUtils.CnvSng(LblTotAmt.Text)
      LblRunLeft.Text = MyUtils.Round(MyUtils.CnvSng(TxtRunAmount.Text) - MyUtils.CnvSng(LblRunPaid.Text), 2)
    End If

    If MyValidation Then
      ChkValidate.Checked = True
    End If
    If MyAppSettings.Receipt Then
      ChkReceipt.Checked = True
    End If

    RbPayBal.Enabled = False
    RbPayDue.Enabled = False
    If MyUtils.CnvSng(TxtPrincipal.Text) <> MyUtils.CnvSng(MyFrmTXA09B.LblRemain.Text) And MyUtils.CnvSng(MyFrmTXA09B.LblRemain.Text) > 0 Then
      RbPayBal.Enabled = True
      RbPayDue.Enabled = True
    End If
    myTXBATCH.CloseFile()
    ScrnLoad = False
    MyEndorseType = WrkType
  End Sub

  Private Sub FrmTXA099_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA09.SbpScreen.Text = "TXA099"
    MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmTXA09
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
    TxtCheck.Focus()
  End Sub
  Sub CalcDiff()
    LblDiff.ForeColor = Color.Black
    LblDiff.Text = Format(MyUtils.CnvSng(LblAmt.Text) - MyUtils.CnvSng(LblDue.Text), "standard")
    If LblDiff.Text <> 0 Then
      LblDiff.ForeColor = Color.Red
    End If

  End Sub
  Sub CalcAmt()
    Dim WrkCash As Decimal
    Dim WrkCheck As Decimal
    Dim WrkCredit As Decimal

    If ScrnLoad Then Exit Sub
    WrkCash = MyUtils.CnvSng(TxtCash.Text)
    WrkCheck = MyUtils.CnvSng(TxtCheck.Text)
    WrkCredit = MyUtils.CnvSng(TxtCredit.Text)

    LblAmt.Text = Format(WrkCash + WrkCheck + WrkCredit, "standard")
    If MyUtils.CnvSng(TxtRunAmount.Text) > 0 Then
      LblRunPaid.Text = MyUtils.CnvSng(LblAmt.Text) + MyUtils.CnvSng(LblTotAmt.Text)
      LblRunLeft.Text = MyUtils.CnvSng(TxtRunAmount.Text) - MyUtils.CnvSng(LblRunPaid.Text)
    End If
  End Sub
  Sub CalcDue()
    Dim WrkPrincipal As Decimal
    Dim WrkInterest As Decimal
    Dim WrkLien As Decimal
    Dim WrkBond As Decimal
    Dim WrkFee1 As Decimal
    Dim WrkFee2 As Decimal
    Dim WrkFee3 As Decimal
    Dim WrkFee4 As Decimal
    Dim WrkFee5 As Decimal
    Dim WrkMVFee As Decimal
    Dim WrkCAFee As Decimal
    Dim WrkTotDue As Decimal

    If ScrnLoad Then Exit Sub
    WrkPrincipal = Format(MyUtils.CnvSng(TxtPrincipal.Text), "standard")
    WrkInterest = Format(MyUtils.CnvSng(TxtInterest.Text), "standard")
    WrkLien = MyUtils.CnvSng(TxtLien.Text)
    WrkBond = Format(MyUtils.CnvSng(TxtBond.Text), "standard")
    WrkFee1 = Format(MyUtils.CnvSng(TxtFee1.Text), "standard")
    WrkFee2 = Format(MyUtils.CnvSng(TxtFee2.Text), "standard")
    WrkFee3 = Format(MyUtils.CnvSng(TxtFee3.Text), "standard")
    WrkFee4 = Format(MyUtils.CnvSng(TxtFee4.Text), "standard")
    WrkFee5 = Format(MyUtils.CnvSng(TxtFee5.Text), "standard")
    WrkMVFee = MyUtils.CnvSng(TxtMVFee.Text)
    WrkCAFee = Format(MyUtils.CnvSng(TxtCAFee.Text), "standard")
    WrkTotDue = WrkPrincipal + WrkInterest + WrkLien + WrkBond + WrkFee1 + WrkFee2 _
    + WrkFee3 + WrkFee4 + WrkFee5 + WrkMVFee + WrkCAFee
    LblDue.Text = Format(WrkTotDue, "standard")

  End Sub
  Sub CalcTotAmt()
    Dim WrkCash As Decimal
    Dim WrkCheck As Decimal
    Dim WrkCredit As Decimal
    Dim WrkTotAmt As Decimal

    If ScrnLoad Then Exit Sub
    WrkCash = Format(MyUtils.CnvSng(LblTotCash.Text), "standard")
    WrkCheck = Format(MyUtils.CnvSng(LblTotCheck.Text), "standard")
    WrkCredit = Format(MyUtils.CnvSng(LblTotCredit.Text), "standard")
    WrkTotAmt = WrkCash + WrkCheck + WrkCredit
    LblTotAmt.Text = Format(WrkTotAmt, "standard")
  End Sub
  Public Sub SaveData()
    Dim WrkFees(7) As Decimal
    Dim WrkFeeCds(7) As String
    Dim I As Integer
    Dim J As Integer
    Dim WrkFirstTime As Boolean
    Dim WrkCashLeft As Decimal
    Dim WrkCheckLeft As Decimal
    Dim WrkCreditLeft As Decimal
    Dim WrkCash As Decimal
    Dim WrkCheck As Decimal
    Dim WrkCredit As Decimal
    Dim WrkPaid As Decimal

    WrkFirstTime = True
    If MyUtils.CnvSng(TxtBond.Text) > 0 Then
      WrkFees(I) = MyUtils.CnvSng(TxtBond.Text)
      WrkFeeCds(I) = "BI"
      I = I + 1
    End If
    If MyUtils.CnvSng(TxtFee1.Text) > 0 Then
      WrkFees(I) = MyUtils.CnvSng(TxtFee1.Text)
      WrkFeeCds(I) = TxtFeeCd1.Text
      I = I + 1
    End If
    If MyUtils.CnvSng(TxtFee2.Text) > 0 Then
      WrkFees(I) = MyUtils.CnvSng(TxtFee2.Text)
      WrkFeeCds(I) = TxtFeeCd2.Text
      I = I + 1
    End If
    If MyUtils.CnvSng(TxtFee3.Text) > 0 Then
      WrkFees(I) = MyUtils.CnvSng(TxtFee3.Text)
      WrkFeeCds(I) = TxtFeeCd3.Text
      I = I + 1
    End If
    If MyUtils.CnvSng(TxtFee4.Text) > 0 Then
      WrkFees(I) = MyUtils.CnvSng(TxtFee4.Text)
      WrkFeeCds(I) = TxtFeeCd4.Text
      I = I + 1
    End If
    If MyUtils.CnvSng(TxtFee5.Text) > 0 Then
      WrkFees(I) = MyUtils.CnvSng(TxtFee5.Text)
      WrkFeeCds(I) = TxtFeeCd5.Text
      I = I + 1
    End If
    If MyUtils.CnvSng(TxtMVFee.Text) > 0 Then
      WrkFees(I) = MyUtils.CnvSng(TxtMVFee.Text)
      WrkFeeCds(I) = "MV"
      I = I + 1
    End If
    If MyUtils.CnvSng(TxtCAFee.Text) > 0 Then
      WrkFees(I) = MyUtils.CnvSng(TxtCAFee.Text)
      WrkFeeCds(I) = "CA"
      I = I + 1
    End If

    WrkCashLeft = MyUtils.CnvSng(TxtCash.Text)
    WrkCheckLeft = MyUtils.CnvSng(TxtCheck.Text)
    WrkCreditLeft = MyUtils.CnvSng(TxtCredit.Text)
    For J = 0 To 7
      If Not WrkFirstTime And WrkFees(J) = 0 Then Exit For
      NextSeqNo = myTXBATCH.AutoGenKey(MyBatch, MyBatchNo)
      myTXBATCH.GetOneRecordP(MyBatch, MyBatchNo, NextSeqNo)
      If WrkFirstTime Then
        WrkPaid = MyUtils.CnvSng(TxtPrincipal.Text) + MyUtils.CnvSng(TxtInterest.Text) + MyUtils.CnvSng(TxtLien.Text) + WrkFees(J)
      Else
        WrkPaid = WrkFees(J)
      End If
      WrkCash = 0
      WrkCheck = 0
      WrkCredit = 0
      If WrkCheckLeft > 0 Then
        If WrkCheckLeft >= WrkPaid Then
          WrkCheck = WrkPaid
          WrkCheckLeft = WrkCheckLeft - WrkPaid
          WrkPaid = 0
        Else
          WrkCheck = WrkCheckLeft
          WrkCheckLeft = 0
          WrkPaid = WrkPaid - WrkCheck
        End If
      End If
      If WrkPaid > 0 And WrkCreditLeft > 0 Then
        If WrkCreditLeft >= WrkPaid Then
          WrkCredit = WrkPaid
          WrkCreditLeft = WrkCreditLeft - WrkPaid
          WrkPaid = 0
        Else
          WrkCredit = WrkCreditLeft
          WrkCreditLeft = 0
          WrkPaid = WrkPaid - WrkCredit
        End If
      End If
      If WrkPaid > 0 And WrkCashLeft > 0 Then
        If WrkCashLeft >= WrkPaid Then
          WrkCash = WrkPaid
          WrkCashLeft = WrkCashLeft - WrkPaid
          WrkPaid = 0
        Else
          WrkCash = WrkCashLeft
          WrkCashLeft = 0
          WrkPaid = WrkPaid - WrkCash
        End If
      End If
      MoveToFile(WrkFirstTime, WrkFees(J), WrkFeeCds(J), WrkCash, WrkCheck, WrkCredit)
      If WrkCash > 0 Or WrkCheck > 0 Or WrkCredit > 0 Then
        myTXBATCH.AddOneRecordP()
      End If
      WrkFirstTime = False
    Next

    MoveToTXINV()
    MoveToTBATCH()
    WrkPayment = True
  End Sub
  Private Sub MoveToFile(ByVal WrkFirst As Boolean, ByVal WrkFee As Decimal, ByVal WrkFeeCd As String,
      ByVal WrkCash As Decimal, ByVal WrkCheck As Decimal, ByVal WrkCredit As Decimal)
    With myTXBATCH
      ._JBTCHC = MyBatch
      ._JBATCH = MyBatchNo
      ._JSEQNO = NextSeqNo
      ._JSTAT = Trim(WrkICode)
      ._LISTNo = WrkListNo
      ._YEAR = WrkYear
      ._TYPE = WrkType
      If WrkFirst Then
        ._PAMT = MyUtils.CnvSng(TxtPrincipal.Text)
        ._IAMT = MyUtils.CnvSng(TxtInterest.Text)
        ._LAMT = MyUtils.CnvSng(TxtLien.Text)
      Else
        ._PAMT = 0
        ._IAMT = 0
        ._LAMT = 0
      End If
      ._TCAMT = WrkFee
      If WrkCheck > 0 Then
        ._CORC = "2"
      End If
      If WrkCredit > 0 And Trim(._CORC) = String.Empty Then
        ._CORC = "3"
      End If
      If WrkCash > 0 And Trim(._CORC) = String.Empty Then
        ._CORC = "1"
      End If
      ._DIST = MyUtils.CnvSng(MyFrmTXA09B.LblDist.Text)
      ._REFE = TxtCheckNo.Text
      ._COMM = TxtComment.Text
      ._ADJCD = String.Empty
      ._JBTCHT = "01"
      ._JTCODE = String.Empty
      ._JUCODE = String.Empty
      ._NAME = LblName.Text
      ._CASH = WrkCash
      ._CHECK = WrkCheck
      ._CREDIT = WrkCredit
      ._ASOFD = 0
      ._CPENCD = WrkFeeCd
      ._CINTPD = 0
      ._JIY = Year(MyInterestOverrideDate)
      ._JIM = Month(MyInterestOverrideDate)
      ._JID = Microsoft.VisualBasic.DateAndTime.Day(MyInterestOverrideDate)
      ._JRY = Year(MyReceiptDate)
      ._JRM = Month(MyReceiptDate)
      ._JRD = Microsoft.VisualBasic.DateAndTime.Day(MyReceiptDate)
      If WrkFirst Then
        ._SIMT = MyUtils.CnvSng(MyFrmTXA09B.LblInterest.Text)
      End If
      ._TMSP = 0
      ._TBL = 0  'Total of all bills
      ._ARC = 0
      ._MR = String.Empty
      ._AD1 = String.Empty
      ._AD2 = String.Empty
      ._CY = String.Empty
      ._SAT = String.Empty
      ._ZI5 = 0
      ._ZI4 = 0
    End With
  End Sub
  Private Sub MoveToTXINV()
    Dim WrkFamily As String
    Dim WrkWhere As String
    Dim WrkSet As String

    WrkFamily = GetTXTypeFamily(LblType.Text)

    myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
    With myTXINV
      ._NEWPAY = ._NEWPAY + MyUtils.CnvSng(TxtPrincipal.Text)
      WrkSet = "NEWPAY=" & ._NEWPAY
      If WrkFamily = "A" Then
        If MyUtils.CnvSng(TxtBond.Text) <> 0 Then
          ._BONT = ._BONT + MyUtils.CnvSng(TxtBond.Text)
          WrkSet = ",BONT=" & ._BONT
        End If
      End If
      WrkWhere = "WHERE list# = " & ._LISTNo & " And year = " & ._YEAR & " And type = '" & ._TYPE & "'"
      WrkSet = "SET " & WrkSet
      myTXINV.RunUpdateQuery(WrkSet, WrkWhere)
      '.UpdateOneRecordP()
      '.CloseFile()
    End With
  End Sub
  Private Sub MoveToTBATCH()
    myTBATCH.GetOneRecordP(MyBatch, MyBatchNo)
    With myTBATCH
      ._KBEND = ._KBEND + MyUtils.CnvSng(LblAmt.Text)
      .UpdateOneRecordP()
      .CloseFile()
    End With

  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(LblDiff.Text) <> 0 Then
      ErrorField(I) = "diff"
      ErrorMsg(I) = "Adjust and try again. Cannot continue until balanced"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtCheck.Text) <> 0 And TxtCheckNo.Text = String.Empty Then
      ErrorField(I) = "checkno"
      ErrorMsg(I) = "Check Number is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtInterest.Text) >= 100000 Then
      ErrorField(I) = "interest"
      ErrorMsg(I) = "Interest cannot be over $99,999.99"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtLien.Text) >= 1000 Then
      ErrorField(I) = "lien"
      ErrorMsg(I) = "Lien cannot be over $999.99"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtFee1.Text) > 0 Then
      MyTXPEN.GetOneRecordP(TxtFeeCd1.Text)
      If MyTXPEN.RecordNotFound Then
        ErrorField(I) = "fee1"
        ErrorMsg(I) = "Invalid Fee Code"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtFee2.Text) > 0 Then
      MyTXPEN.GetOneRecordP(TxtFeeCd2.Text)
      If MyTXPEN.RecordNotFound Then
        ErrorField(I) = "fee2"
        ErrorMsg(I) = "Invalid Fee Code"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtFee3.Text) > 0 Then
      MyTXPEN.GetOneRecordP(TxtFeeCd3.Text)
      If MyTXPEN.RecordNotFound Then
        ErrorField(I) = "fee3"
        ErrorMsg(I) = "Invalid Fee Code"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtFee4.Text) > 0 Then
      MyTXPEN.GetOneRecordP(TxtFeeCd4.Text)
      If MyTXPEN.RecordNotFound Then
        ErrorField(I) = "fee4"
        ErrorMsg(I) = "Invalid Fee Code"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtFee5.Text) > 0 Then
      MyTXPEN.GetOneRecordP(TxtFeeCd5.Text)
      If MyTXPEN.RecordNotFound Then
        ErrorField(I) = "fee5"
        ErrorMsg(I) = "Invalid Fee Code"
        I = I + 1
      End If
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(LblDiff, String.Empty)
    ErrProv.SetError(TxtCheckNo, String.Empty)
    ErrProv.SetError(TxtInterest, String.Empty)
    ErrProv.SetError(TxtLien, String.Empty)
    ErrProv.SetError(TxtFeeCd1, String.Empty)
    ErrProv.SetError(TxtFeeCd2, String.Empty)
    ErrProv.SetError(TxtFeeCd3, String.Empty)
    ErrProv.SetError(TxtFeeCd4, String.Empty)
    ErrProv.SetError(TxtFeeCd5, String.Empty)

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "diff"
          ErrProv.SetError(LblDiff, ErrorMsg(I))
        Case "checkno"
          ErrProv.SetError(TxtCheckNo, ErrorMsg(I))
        Case "interest"
          ErrProv.SetError(TxtInterest, ErrorMsg(I))
        Case "lien"
          ErrProv.SetError(TxtLien, ErrorMsg(I))
        Case "fee1"
          ErrProv.SetError(TxtFeeCd1, ErrorMsg(I))
        Case "fee2"
          ErrProv.SetError(TxtFeeCd2, ErrorMsg(I))
        Case "fee3"
          ErrProv.SetError(TxtFeeCd3, ErrorMsg(I))
        Case "fee4"
          ErrProv.SetError(TxtFeeCd4, ErrorMsg(I))
        Case "fee5"
          ErrProv.SetError(TxtFeeCd5, ErrorMsg(I))
      End Select
    Next I
  End Sub
  Private Sub TxtCash_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCash.TextChanged
    CalcAmt()
    CalcDiff()
  End Sub
  Private Sub TxtCheck_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCheck.TextChanged
    CalcAmt()
    CalcDiff()
  End Sub
  Private Sub TxtCredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCredit.TextChanged
    CalcAmt()
    CalcDiff()
  End Sub
  Private Sub TxtPrincipal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrincipal.TextChanged
    CalcDue()
    CalcDiff()
  End Sub
  Private Sub TxtInterest_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtInterest.TextChanged
    CalcDue()
    CalcDiff()
  End Sub
  Private Sub TxtLien_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLien.TextChanged
    CalcDue()
    CalcDiff()
  End Sub
  Private Sub TxtBond_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBond.TextChanged
    CalcDue()
    CalcDiff()
  End Sub
  Private Sub TxtFee1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFee1.TextChanged
    CalcDue()
    CalcDiff()
  End Sub
  Private Sub TxtFee2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFee2.TextChanged
    CalcDue()
    CalcDiff()
  End Sub
  Private Sub TxtFee3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFee3.TextChanged
    CalcDue()
    CalcDiff()
  End Sub
  Private Sub TxtFee4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFee4.TextChanged
    CalcDue()
    CalcDiff()
  End Sub
  Private Sub TxtFee5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFee5.TextChanged
    CalcDue()
    CalcDiff()
  End Sub
  Private Sub TxtMVFee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMVFee.TextChanged
    CalcDue()
    CalcDiff()
  End Sub
  Private Sub TxtCAFee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCAFee.TextChanged
    CalcDue()
    CalcDiff()
  End Sub
  Private Sub FrmTXA099_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    Dim WrkGridComplete As Boolean
    Dim WrkBond As Boolean
    Dim WrkValidation As Boolean
    Dim WrkReceipt As Boolean

    WrkBond = False
    If MyUtils.CnvSng(TxtBond.Text) > 0 Then
      WrkBond = True
    End If
    WrkValidation = ChkValidate.Checked
    WrkReceipt = ChkReceipt.Checked

    If WrkPayment Then
      If WrkValidation Or WrkReceipt Then
        RunPrintForms(WrkValidation, WrkReceipt)
      End If

      If WrkComplete Then
        MyLastCheckNo = String.Empty
        MyLastComment = String.Empty
        MyLastCommentRefund = String.Empty
        MyFrmTXA09B.Close()
        MyFrmTXA09Total = New FrmTXA09Total
        MyFrmTXA09Total.WrkBatchSeqNo = NextSeqNo
        myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
        Select Case MyFrmTXA094.CboSort.SelectedItem.ToString
          Case "Owner's Name"
            MyFrmTXA09Total.WrkPos = LblName.Text
            MyFrmTXA09Total.WrkPosNo = ""
          Case "Second Name"
            MyFrmTXA09Total.WrkPos = Trim(myTXINV._SNAME)
            MyFrmTXA09Total.WrkPosNo = ""
          Case "Location"
            MyFrmTXA09Total.WrkPos = Trim(myTXINV._LOC)
            MyFrmTXA09Total.WrkPosNo = Trim(myTXINV._LOCNo)
          Case "Reg #"
            MyFrmTXA09Total.WrkPos = Trim(myTXINV._IMVREG)
            MyFrmTXA09Total.WrkPosNo = ""
        End Select
        MyFrmTXA09Total.MdiParent = MyFrmTXA091.ParentForm
        MyFrmTXA09Total.Show()
      Else
        MyLastCheckNo = TxtCheckNo.Text
        MyLastComment = TxtComment.Text
        MyFrmTXA09B.Close()
        If Not IsNothing(MyFrmTXA094B) Then
          MyFrmTXA094B.ProcessGridItems(WrkGridComplete, False)
          If WrkGridComplete Then
            MyFrmTXA09.TBarView.Enabled = True
            If MyScanOnly Then
              MyFrmTXA094.FormatGrid(False, False, True)
            Else
              MyFrmTXA094.FormatGrid(True, True, False)
            End If
            MyFrmTXA094.Show()
          End If
        Else
          MyFrmTXA09.TBarView.Enabled = True
          If MyScanOnly Then
            MyFrmTXA094.FormatGrid(False, False, True)
          Else
            MyFrmTXA094.FormatGrid(True, True, False)
          End If
          MyFrmTXA094.Show()
        End If
      End If
    Else
      If Not IsNothing(MyFrmTXA094B) Then
        MyFrmTXA094B.ProcessGridItems(WrkGridComplete, False)
        If WrkGridComplete Then
          MyFrmTXA09B.Show()
        End If
      Else
        MyFrmTXA09B.Show()
      End If
    End If

    'Memory Cleanup
    myTBATCH.CloseFile()
    myTXBATCH.CloseFile()
    myTXINV.CloseFile()
    MyTXPEN.CloseFile()

    myTBATCH = Nothing
    myTXBATCH = Nothing
    myTXINV = Nothing
    MyTXPEN = Nothing
    MyFrmTXA099 = Nothing
  End Sub

  Private Sub RunPrintForms(ByVal WrkValidation As Boolean, ByVal WrkReceipt As Boolean)
    BuildDS()
    AddOneRecord()
    'Await Task.Run(Sub()
    PrintForms(WrkValidation, WrkReceipt)
    '               End Sub)
  End Sub

  Private Sub PrintForms(ByVal WrkValidation As Boolean, ByVal WrkReceipt As Boolean)
    If MyAppSettings.AdvDriver Then
      PrtReceiptDirect(ds, WrkValidation, WrkReceipt)
    Else
      PrtReceipt(ds, WrkValidation, WrkReceipt)
    End If
    If WrkReceipt Then
      MyReceiptPrinted = True
    End If
    ds.Clear()
    ds = Nothing
  End Sub

  Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick

    Dim Good As Boolean
    Good = CheckEditsGood()
    If Not Good Then Exit Sub

    If e.Button Is TBarComplete Then
      DoBtnComplete()
      Exit Sub
    End If

    If e.Button Is TBarNext Then
      DoBtnNext()
      Exit Sub
    End If

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    ds = New DataSet
    With myTable
      .TableName = "mytable"
      .Columns.Add("Sortdata", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("SName", Type.GetType("System.String"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("PropDesc2", Type.GetType("System.String"))
      .Columns.Add("Seq", Type.GetType("System.Int32"))
      .Columns.Add("Principal", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Liens", Type.GetType("System.Decimal"))
      .Columns.Add("Fees", Type.GetType("System.Decimal"))
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
      .Columns.Add("Cash", Type.GetType("System.Decimal"))
      .Columns.Add("Check", Type.GetType("System.Decimal"))
      .Columns.Add("Credit", Type.GetType("System.Decimal"))
      .Columns.Add("Batch", Type.GetType("System.String"))
      .Columns.Add("BatchNo", Type.GetType("System.Int32"))
      .Columns.Add("RecDt", Type.GetType("System.DateTime"))
      .Columns.Add("Refe", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Sub AddOneRecord()
    Dim myDr As Data.DataRow

    myDr = ds.Tables(0).NewRow
    myDr("ListNo") = WrkListNo
    myDr("Type") = WrkType
    myDr("TypeDesc") = GetTXTypeDesc(WrkType)
    myDr("Year") = WrkYear
    myDr("seq") = NextSeqNo
    myDr("Name") = LblName.Text
    myDr("SName") = LblSname.Text
    myDr("PropDesc") = LblProperty.Text
    myDr("PropDesc2") = LblProperty2.Text
    myDr("Principal") = MyUtils.CnvSng(TxtPrincipal.Text)
    myDr("Interest") = MyUtils.CnvSng(TxtInterest.Text)
    myDr("Liens") = MyUtils.CnvSng(TxtLien.Text)
    myDr("Fees") = MyUtils.CnvSng(TxtFee1.Text) + MyUtils.CnvSng(TxtFee2.Text) + MyUtils.CnvSng(TxtFee3.Text) _
    + MyUtils.CnvSng(TxtFee4.Text) + MyUtils.CnvSng(TxtFee5.Text) + MyUtils.CnvSng(TxtMVFee.Text) _
    + MyUtils.CnvSng(TxtCAFee.Text)
    myDr("Bond") = MyUtils.CnvSng(TxtBond.Text)
    myDr("Total") = MyUtils.CnvSng(LblAmt.Text)
    myDr("Cash") = MyUtils.CnvSng(TxtCash.Text)
    myDr("Check") = MyUtils.CnvSng(TxtCheck.Text)
    myDr("Credit") = MyUtils.CnvSng(TxtCredit.Text)
    myDr("batch") = MyBatch
    myDr("batchno") = MyBatchNo
    myDr("recdt") = MyReceiptDate.Date
    myDr("refe") = Trim(TxtCheckNo.Text)
    ds.Tables(0).Rows.Add(myDr)

  End Sub
  Private Sub TxtCash_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCash.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtCheck_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCheck.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtCredit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCredit.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtPrincipal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPrincipal.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtInterest_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtInterest.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtLien_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLien.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtBond_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBond.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtFee1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFee1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtFee2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFee2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtFee3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFee3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtFee4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFee4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtFee5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFee5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtMVFee_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMVFee.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtCAFee_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCAFee.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub FrmTXA099_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
    Dim Good As Boolean

    If Me.ActiveControl.Name = "TxtFeeCode" Then
      If Asc(e.KeyChar) = Keys.Return Then
        Good = CheckEditsGood()
        If Not Good Then Exit Sub
        DoBtnNext()
      End If
    Else
      MyUtils.KeyEnter_isTab(Me, e)
    End If
  End Sub

  Private Sub FrmTXA099_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub

    If e.KeyCode = Keys.O Then
      DoBtnComplete()
    End If

    If e.KeyCode = Keys.X Then
      DoBtnNext()
    End If

  End Sub
  Private Sub DoBtnComplete()
    WrkComplete = True
    SaveData()
    Me.Close()
  End Sub
  Private Sub DoBtnNext()
    WrkComplete = False
    SaveData()
    Me.Close()
  End Sub
  Private Sub TxtRunAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRunAmount.TextChanged
    CalcAmt()
    MyCheckAmount = MyUtils.CnvSng(TxtRunAmount.Text)
  End Sub
  Private Sub LblCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblCash.Click
    TxtCash.Text = Format(MyUtils.CnvSng(LblDue.Text), "standard")
    TxtCheck.Text = String.Empty
    TxtCredit.Text = String.Empty
  End Sub
  Private Sub LblCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblCheck.Click
    TxtCash.Text = String.Empty
    TxtCheck.Text = Format(MyUtils.CnvSng(LblDue.Text), "standard")
    TxtCredit.Text = String.Empty
  End Sub
  Private Sub LblCredit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblCredit.Click
    TxtCash.Text = String.Empty
    TxtCheck.Text = String.Empty
    TxtCredit.Text = Format(MyUtils.CnvSng(LblDue.Text), "standard")
  End Sub
  Private Sub TxtCheck_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCheck.GotFocus
    MyUtils.ShowFocus(Me.ActiveControl)
  End Sub
  Private Function CheckEditsGood() As Boolean

    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      Return True
    Else
      ShowError(ErrorField, ErrorMsg)
      Return False
    End If

  End Function

  Private Sub LnkFeeCd1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFeeCd1.LinkClicked
    MyFrmListPenCd = New FrmListPenCd
    MyFrmListPenCd.MdiParent = Me.ParentForm
    MyFrmListPenCd.WrkCode = TxtFeeCd1.Text
    MyFrmListPenCd.WrkField = "Fee1"
    MyFrmListPenCd.Show()
    Me.Hide()
  End Sub
  Private Sub LnkFeeCd2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFeeCd2.LinkClicked
    MyFrmListPenCd = New FrmListPenCd
    MyFrmListPenCd.MdiParent = Me.ParentForm
    MyFrmListPenCd.WrkCode = TxtFeeCd2.Text
    MyFrmListPenCd.WrkField = "Fee2"
    MyFrmListPenCd.Show()
    Me.Hide()
  End Sub
  Private Sub LnkFeeCd3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFeeCd3.LinkClicked
    MyFrmListPenCd = New FrmListPenCd
    MyFrmListPenCd.MdiParent = Me.ParentForm
    MyFrmListPenCd.WrkCode = TxtFeeCd3.Text
    MyFrmListPenCd.WrkField = "Fee3"
    MyFrmListPenCd.Show()
    Me.Hide()
  End Sub
  Private Sub LnkFeeCd4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFeeCd4.LinkClicked
    MyFrmListPenCd = New FrmListPenCd
    MyFrmListPenCd.MdiParent = Me.ParentForm
    MyFrmListPenCd.WrkCode = TxtFeeCd4.Text
    MyFrmListPenCd.WrkField = "Fee4"
    MyFrmListPenCd.Show()
    Me.Hide()
  End Sub
  Private Sub LnkFeeCd5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFeeCd5.LinkClicked
    MyFrmListPenCd = New FrmListPenCd
    MyFrmListPenCd.MdiParent = Me.ParentForm
    MyFrmListPenCd.WrkCode = TxtFeeCd5.Text
    MyFrmListPenCd.WrkField = "Fee5"
    MyFrmListPenCd.Show()
    Me.Hide()
  End Sub

  Private Sub RbPayDue_Click(sender As Object, e As EventArgs) Handles RbPayDue.Click
    TxtPrincipal.Text = MyFrmTXA09B.LblTax.Text
    If MyUtils.CnvSng(TxtPrincipal.Text) = 0 And MyUtils.CnvSng(MyFrmTXA09B.LblRemain.Text) > 0 Then
      TxtPrincipal.Text = Format(MyUtils.CnvSng(MyFrmTXA09B.LblRemain.Text), "standard")
    End If
    CalcDue()
  End Sub
  Private Sub RbPayBal_Click(sender As Object, e As EventArgs) Handles RbPayBal.Click
    TxtPrincipal.Text = Format(MyUtils.CnvSng(MyFrmTXA09B.LblRemain.Text), "standard")
    CalcDue()
  End Sub
End Class
