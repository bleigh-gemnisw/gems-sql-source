Imports System.Threading.Tasks

Public Class FrmTXA09Adj
  Inherits System.Windows.Forms.Form
  Dim myTBATCH As TBATCH.MyData
  Dim myTXBATCH As TXBATCH.MyData
  Dim myTXINV As TXINV.MyData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkType As String
  Friend WrkICode As String
  Friend WithEvents ChkValidate As System.Windows.Forms.CheckBox
  Friend WithEvents LblProperty2 As System.Windows.Forms.Label
  Friend WithEvents LblProperty As System.Windows.Forms.Label
  Friend WithEvents label37 As System.Windows.Forms.Label
  Friend WithEvents LblName As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents LblType As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents LblYear As System.Windows.Forms.Label
  Friend WithEvents LblList As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents RbAdjust As System.Windows.Forms.RadioButton
  Friend WithEvents RbRefund As System.Windows.Forms.RadioButton
  Friend WithEvents LblDefault As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents LblCurBond As System.Windows.Forms.Label
  Friend WithEvents TxtBond As System.Windows.Forms.TextBox
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents Label24 As System.Windows.Forms.Label
  Friend WithEvents LblNewBond As System.Windows.Forms.Label
  Friend WithEvents LblSname As System.Windows.Forms.Label
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Dim NextSeqNo As Integer

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
  Friend WithEvents TxtComment As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TxtFee As System.Windows.Forms.TextBox
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents TxtFeeCode As System.Windows.Forms.TextBox
  Friend WithEvents TxtLien As System.Windows.Forms.TextBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents TxtInterest As System.Windows.Forms.TextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents TxtPrincipal As System.Windows.Forms.TextBox
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbPayCash As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents Label25 As System.Windows.Forms.Label
  Friend WithEvents Label27 As System.Windows.Forms.Label
  Friend WithEvents Label28 As System.Windows.Forms.Label
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents LblNewBal As System.Windows.Forms.Label
  Friend WithEvents LblNewFee As System.Windows.Forms.Label
  Friend WithEvents LblNewLien As System.Windows.Forms.Label
  Friend WithEvents LblNewInterest As System.Windows.Forms.Label
  Friend WithEvents LblNewPrincipal As System.Windows.Forms.Label
  Friend WithEvents LblNewTot As System.Windows.Forms.Label
  Friend WithEvents RbPayCredit As System.Windows.Forms.RadioButton
  Friend WithEvents RbPayCheck As System.Windows.Forms.RadioButton
  Friend WithEvents LblTot As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TbMain As System.Windows.Forms.ToolBar
  Friend WithEvents TBarSave As System.Windows.Forms.ToolBarButton
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents LblCurTot As System.Windows.Forms.Label
  Friend WithEvents LblCurBal As System.Windows.Forms.Label
  Friend WithEvents LblCurFee As System.Windows.Forms.Label
  Friend WithEvents LblCurLien As System.Windows.Forms.Label
  Friend WithEvents LblCurInterest As System.Windows.Forms.Label
  Friend WithEvents LblCurPrincipal As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTXA09Adj))
    Me.TxtComment = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtFee = New System.Windows.Forms.TextBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.TxtFeeCode = New System.Windows.Forms.TextBox()
    Me.TxtLien = New System.Windows.Forms.TextBox()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.TxtInterest = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.TxtPrincipal = New System.Windows.Forms.TextBox()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbPayCredit = New System.Windows.Forms.RadioButton()
    Me.RbPayCash = New System.Windows.Forms.RadioButton()
    Me.RbPayCheck = New System.Windows.Forms.RadioButton()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.LblNewBond = New System.Windows.Forms.Label()
    Me.LblNewTot = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.LblNewBal = New System.Windows.Forms.Label()
    Me.LblNewFee = New System.Windows.Forms.Label()
    Me.LblNewLien = New System.Windows.Forms.Label()
    Me.LblNewInterest = New System.Windows.Forms.Label()
    Me.LblNewPrincipal = New System.Windows.Forms.Label()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.Label25 = New System.Windows.Forms.Label()
    Me.Label27 = New System.Windows.Forms.Label()
    Me.Label28 = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.LblTot = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarSave = New System.Windows.Forms.ToolBarButton()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.LblCurBond = New System.Windows.Forms.Label()
    Me.LblCurTot = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.LblCurBal = New System.Windows.Forms.Label()
    Me.LblCurFee = New System.Windows.Forms.Label()
    Me.LblCurLien = New System.Windows.Forms.Label()
    Me.LblCurInterest = New System.Windows.Forms.Label()
    Me.LblCurPrincipal = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.ChkValidate = New System.Windows.Forms.CheckBox()
    Me.LblProperty2 = New System.Windows.Forms.Label()
    Me.LblProperty = New System.Windows.Forms.Label()
    Me.label37 = New System.Windows.Forms.Label()
    Me.LblName = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.LblType = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.LblList = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.RbAdjust = New System.Windows.Forms.RadioButton()
    Me.RbRefund = New System.Windows.Forms.RadioButton()
    Me.LblDefault = New System.Windows.Forms.Label()
    Me.TxtBond = New System.Windows.Forms.TextBox()
    Me.Label22 = New System.Windows.Forms.Label()
    Me.LblSname = New System.Windows.Forms.Label()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'TxtComment
    '
    Me.TxtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtComment.Location = New System.Drawing.Point(228, 363)
    Me.TxtComment.MaxLength = 20
    Me.TxtComment.Name = "TxtComment"
    Me.TxtComment.Size = New System.Drawing.Size(132, 20)
    Me.TxtComment.TabIndex = 9
    '
    'Label10
    '
    Me.Label10.BackColor = System.Drawing.SystemColors.Control
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(164, 363)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(56, 12)
    Me.Label10.TabIndex = 181
    Me.Label10.Text = "Comment"
    '
    'TxtFee
    '
    Me.TxtFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFee.Location = New System.Drawing.Point(248, 161)
    Me.TxtFee.MaxLength = 15
    Me.TxtFee.Name = "TxtFee"
    Me.TxtFee.Size = New System.Drawing.Size(80, 20)
    Me.TxtFee.TabIndex = 4
    Me.TxtFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label17
    '
    Me.Label17.BackColor = System.Drawing.SystemColors.Control
    Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label17.Location = New System.Drawing.Point(184, 165)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(36, 12)
    Me.Label17.TabIndex = 179
    Me.Label17.Text = "Fee"
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.BackColor = System.Drawing.SystemColors.Control
    Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label13.Location = New System.Drawing.Point(187, 262)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(53, 13)
    Me.Label13.TabIndex = 178
    Me.Label13.Text = "Fee Code"
    '
    'TxtFeeCode
    '
    Me.TxtFeeCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFeeCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFeeCode.Location = New System.Drawing.Point(246, 259)
    Me.TxtFeeCode.MaxLength = 2
    Me.TxtFeeCode.Name = "TxtFeeCode"
    Me.TxtFeeCode.Size = New System.Drawing.Size(25, 20)
    Me.TxtFeeCode.TabIndex = 7
    '
    'TxtLien
    '
    Me.TxtLien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLien.Location = New System.Drawing.Point(248, 181)
    Me.TxtLien.MaxLength = 15
    Me.TxtLien.Name = "TxtLien"
    Me.TxtLien.Size = New System.Drawing.Size(80, 20)
    Me.TxtLien.TabIndex = 5
    Me.TxtLien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label14
    '
    Me.Label14.BackColor = System.Drawing.SystemColors.Control
    Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label14.Location = New System.Drawing.Point(185, 185)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(36, 12)
    Me.Label14.TabIndex = 175
    Me.Label14.Text = "Lien"
    '
    'TxtInterest
    '
    Me.TxtInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtInterest.Location = New System.Drawing.Point(248, 141)
    Me.TxtInterest.MaxLength = 15
    Me.TxtInterest.Name = "TxtInterest"
    Me.TxtInterest.Size = New System.Drawing.Size(80, 20)
    Me.TxtInterest.TabIndex = 3
    Me.TxtInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label15
    '
    Me.Label15.BackColor = System.Drawing.SystemColors.Control
    Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label15.Location = New System.Drawing.Point(184, 145)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(48, 12)
    Me.Label15.TabIndex = 173
    Me.Label15.Text = "Interest"
    '
    'TxtPrincipal
    '
    Me.TxtPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPrincipal.Location = New System.Drawing.Point(248, 121)
    Me.TxtPrincipal.MaxLength = 15
    Me.TxtPrincipal.Name = "TxtPrincipal"
    Me.TxtPrincipal.Size = New System.Drawing.Size(80, 20)
    Me.TxtPrincipal.TabIndex = 2
    Me.TxtPrincipal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label16
    '
    Me.Label16.BackColor = System.Drawing.SystemColors.Control
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.Location = New System.Drawing.Point(184, 121)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(48, 12)
    Me.Label16.TabIndex = 171
    Me.Label16.Text = "Principal"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbPayCredit)
    Me.GroupBox1.Controls.Add(Me.RbPayCash)
    Me.GroupBox1.Controls.Add(Me.RbPayCheck)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(140, 302)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(248, 48)
    Me.GroupBox1.TabIndex = 8
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Payment Method"
    '
    'RbPayCredit
    '
    Me.RbPayCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPayCredit.Location = New System.Drawing.Point(184, 24)
    Me.RbPayCredit.Name = "RbPayCredit"
    Me.RbPayCredit.Size = New System.Drawing.Size(56, 16)
    Me.RbPayCredit.TabIndex = 187
    Me.RbPayCredit.Text = "Credit"
    '
    'RbPayCash
    '
    Me.RbPayCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPayCash.Location = New System.Drawing.Point(8, 24)
    Me.RbPayCash.Name = "RbPayCash"
    Me.RbPayCash.Size = New System.Drawing.Size(56, 16)
    Me.RbPayCash.TabIndex = 184
    Me.RbPayCash.Text = "Cash"
    '
    'RbPayCheck
    '
    Me.RbPayCheck.Checked = True
    Me.RbPayCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPayCheck.Location = New System.Drawing.Point(88, 24)
    Me.RbPayCheck.Name = "RbPayCheck"
    Me.RbPayCheck.Size = New System.Drawing.Size(64, 16)
    Me.RbPayCheck.TabIndex = 186
    Me.RbPayCheck.TabStop = True
    Me.RbPayCheck.Text = "Check"
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.Label24)
    Me.GroupBox4.Controls.Add(Me.LblNewBond)
    Me.GroupBox4.Controls.Add(Me.LblNewTot)
    Me.GroupBox4.Controls.Add(Me.Label2)
    Me.GroupBox4.Controls.Add(Me.LblNewBal)
    Me.GroupBox4.Controls.Add(Me.LblNewFee)
    Me.GroupBox4.Controls.Add(Me.LblNewLien)
    Me.GroupBox4.Controls.Add(Me.LblNewInterest)
    Me.GroupBox4.Controls.Add(Me.LblNewPrincipal)
    Me.GroupBox4.Controls.Add(Me.Label20)
    Me.GroupBox4.Controls.Add(Me.Label25)
    Me.GroupBox4.Controls.Add(Me.Label27)
    Me.GroupBox4.Controls.Add(Me.Label28)
    Me.GroupBox4.Controls.Add(Me.Label29)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(336, 105)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(160, 174)
    Me.GroupBox4.TabIndex = 186
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Adjusted Amounts"
    '
    'Label24
    '
    Me.Label24.BackColor = System.Drawing.SystemColors.Control
    Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label24.Location = New System.Drawing.Point(6, 100)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(36, 12)
    Me.Label24.TabIndex = 175
    Me.Label24.Text = "Bond"
    '
    'LblNewBond
    '
    Me.LblNewBond.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblNewBond.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblNewBond.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNewBond.Location = New System.Drawing.Point(72, 96)
    Me.LblNewBond.Name = "LblNewBond"
    Me.LblNewBond.Size = New System.Drawing.Size(80, 20)
    Me.LblNewBond.TabIndex = 174
    Me.LblNewBond.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblNewTot
    '
    Me.LblNewTot.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblNewTot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblNewTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNewTot.Location = New System.Drawing.Point(72, 124)
    Me.LblNewTot.Name = "LblNewTot"
    Me.LblNewTot.Size = New System.Drawing.Size(80, 20)
    Me.LblNewTot.TabIndex = 173
    Me.LblNewTot.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label2
    '
    Me.Label2.BackColor = System.Drawing.SystemColors.Control
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(6, 128)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(56, 12)
    Me.Label2.TabIndex = 172
    Me.Label2.Text = "Total"
    '
    'LblNewBal
    '
    Me.LblNewBal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblNewBal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblNewBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNewBal.Location = New System.Drawing.Point(72, 148)
    Me.LblNewBal.Name = "LblNewBal"
    Me.LblNewBal.Size = New System.Drawing.Size(80, 20)
    Me.LblNewBal.TabIndex = 171
    Me.LblNewBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblNewFee
    '
    Me.LblNewFee.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblNewFee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblNewFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNewFee.Location = New System.Drawing.Point(72, 56)
    Me.LblNewFee.Name = "LblNewFee"
    Me.LblNewFee.Size = New System.Drawing.Size(80, 20)
    Me.LblNewFee.TabIndex = 170
    Me.LblNewFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblNewLien
    '
    Me.LblNewLien.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblNewLien.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblNewLien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNewLien.Location = New System.Drawing.Point(72, 76)
    Me.LblNewLien.Name = "LblNewLien"
    Me.LblNewLien.Size = New System.Drawing.Size(80, 20)
    Me.LblNewLien.TabIndex = 169
    Me.LblNewLien.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblNewInterest
    '
    Me.LblNewInterest.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblNewInterest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblNewInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNewInterest.Location = New System.Drawing.Point(72, 36)
    Me.LblNewInterest.Name = "LblNewInterest"
    Me.LblNewInterest.Size = New System.Drawing.Size(80, 20)
    Me.LblNewInterest.TabIndex = 168
    Me.LblNewInterest.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblNewPrincipal
    '
    Me.LblNewPrincipal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblNewPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblNewPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNewPrincipal.Location = New System.Drawing.Point(72, 16)
    Me.LblNewPrincipal.Name = "LblNewPrincipal"
    Me.LblNewPrincipal.Size = New System.Drawing.Size(80, 20)
    Me.LblNewPrincipal.TabIndex = 167
    Me.LblNewPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label20
    '
    Me.Label20.BackColor = System.Drawing.SystemColors.Control
    Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label20.Location = New System.Drawing.Point(8, 59)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(36, 12)
    Me.Label20.TabIndex = 165
    Me.Label20.Text = "Fee"
    '
    'Label25
    '
    Me.Label25.BackColor = System.Drawing.SystemColors.Control
    Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label25.Location = New System.Drawing.Point(8, 154)
    Me.Label25.Name = "Label25"
    Me.Label25.Size = New System.Drawing.Size(56, 12)
    Me.Label25.TabIndex = 163
    Me.Label25.Text = "Balance"
    '
    'Label27
    '
    Me.Label27.BackColor = System.Drawing.SystemColors.Control
    Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label27.Location = New System.Drawing.Point(8, 79)
    Me.Label27.Name = "Label27"
    Me.Label27.Size = New System.Drawing.Size(36, 12)
    Me.Label27.TabIndex = 159
    Me.Label27.Text = "Lien"
    '
    'Label28
    '
    Me.Label28.BackColor = System.Drawing.SystemColors.Control
    Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label28.Location = New System.Drawing.Point(8, 40)
    Me.Label28.Name = "Label28"
    Me.Label28.Size = New System.Drawing.Size(48, 12)
    Me.Label28.TabIndex = 157
    Me.Label28.Text = "Interest"
    '
    'Label29
    '
    Me.Label29.BackColor = System.Drawing.SystemColors.Control
    Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label29.Location = New System.Drawing.Point(8, 16)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(48, 12)
    Me.Label29.TabIndex = 155
    Me.Label29.Text = "Principal"
    '
    'LblTot
    '
    Me.LblTot.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTot.Location = New System.Drawing.Point(248, 229)
    Me.LblTot.Name = "LblTot"
    Me.LblTot.Size = New System.Drawing.Size(80, 20)
    Me.LblTot.TabIndex = 6
    Me.LblTot.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label3
    '
    Me.Label3.BackColor = System.Drawing.SystemColors.Control
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(187, 233)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(56, 12)
    Me.Label3.TabIndex = 187
    Me.Label3.Text = "Total"
    '
    'TbMain
    '
    Me.TbMain.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarSave})
    Me.TbMain.Dock = System.Windows.Forms.DockStyle.None
    Me.TbMain.DropDownArrows = True
    Me.TbMain.ImageList = Me.ImageList1
    Me.TbMain.Location = New System.Drawing.Point(0, 409)
    Me.TbMain.Name = "TbMain"
    Me.TbMain.ShowToolTips = True
    Me.TbMain.Size = New System.Drawing.Size(80, 42)
    Me.TbMain.TabIndex = 10
    '
    'TBarSave
    '
    Me.TBarSave.Name = "TBarSave"
    Me.TBarSave.Text = "&Save/Apply"
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.Label9)
    Me.GroupBox2.Controls.Add(Me.LblCurBond)
    Me.GroupBox2.Controls.Add(Me.LblCurTot)
    Me.GroupBox2.Controls.Add(Me.Label4)
    Me.GroupBox2.Controls.Add(Me.LblCurBal)
    Me.GroupBox2.Controls.Add(Me.LblCurFee)
    Me.GroupBox2.Controls.Add(Me.LblCurLien)
    Me.GroupBox2.Controls.Add(Me.LblCurInterest)
    Me.GroupBox2.Controls.Add(Me.LblCurPrincipal)
    Me.GroupBox2.Controls.Add(Me.Label11)
    Me.GroupBox2.Controls.Add(Me.Label12)
    Me.GroupBox2.Controls.Add(Me.Label18)
    Me.GroupBox2.Controls.Add(Me.Label19)
    Me.GroupBox2.Controls.Add(Me.Label21)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(16, 105)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(160, 182)
    Me.GroupBox2.TabIndex = 190
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Current Amounts"
    '
    'Label9
    '
    Me.Label9.BackColor = System.Drawing.SystemColors.Control
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(10, 100)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(36, 12)
    Me.Label9.TabIndex = 175
    Me.Label9.Text = "Bond"
    '
    'LblCurBond
    '
    Me.LblCurBond.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCurBond.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblCurBond.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCurBond.Location = New System.Drawing.Point(72, 96)
    Me.LblCurBond.Name = "LblCurBond"
    Me.LblCurBond.Size = New System.Drawing.Size(80, 20)
    Me.LblCurBond.TabIndex = 174
    Me.LblCurBond.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCurTot
    '
    Me.LblCurTot.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCurTot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblCurTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCurTot.Location = New System.Drawing.Point(72, 128)
    Me.LblCurTot.Name = "LblCurTot"
    Me.LblCurTot.Size = New System.Drawing.Size(80, 20)
    Me.LblCurTot.TabIndex = 173
    Me.LblCurTot.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label4
    '
    Me.Label4.BackColor = System.Drawing.SystemColors.Control
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(10, 132)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(56, 12)
    Me.Label4.TabIndex = 172
    Me.Label4.Text = "Total"
    '
    'LblCurBal
    '
    Me.LblCurBal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCurBal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblCurBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCurBal.Location = New System.Drawing.Point(72, 154)
    Me.LblCurBal.Name = "LblCurBal"
    Me.LblCurBal.Size = New System.Drawing.Size(80, 20)
    Me.LblCurBal.TabIndex = 171
    Me.LblCurBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCurFee
    '
    Me.LblCurFee.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCurFee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblCurFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCurFee.Location = New System.Drawing.Point(72, 56)
    Me.LblCurFee.Name = "LblCurFee"
    Me.LblCurFee.Size = New System.Drawing.Size(80, 20)
    Me.LblCurFee.TabIndex = 170
    Me.LblCurFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCurLien
    '
    Me.LblCurLien.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCurLien.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblCurLien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCurLien.Location = New System.Drawing.Point(72, 76)
    Me.LblCurLien.Name = "LblCurLien"
    Me.LblCurLien.Size = New System.Drawing.Size(80, 20)
    Me.LblCurLien.TabIndex = 169
    Me.LblCurLien.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCurInterest
    '
    Me.LblCurInterest.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCurInterest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblCurInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCurInterest.Location = New System.Drawing.Point(72, 36)
    Me.LblCurInterest.Name = "LblCurInterest"
    Me.LblCurInterest.Size = New System.Drawing.Size(80, 20)
    Me.LblCurInterest.TabIndex = 168
    Me.LblCurInterest.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCurPrincipal
    '
    Me.LblCurPrincipal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCurPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblCurPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCurPrincipal.Location = New System.Drawing.Point(72, 16)
    Me.LblCurPrincipal.Name = "LblCurPrincipal"
    Me.LblCurPrincipal.Size = New System.Drawing.Size(80, 20)
    Me.LblCurPrincipal.TabIndex = 167
    Me.LblCurPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label11
    '
    Me.Label11.BackColor = System.Drawing.SystemColors.Control
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.Location = New System.Drawing.Point(10, 59)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(36, 12)
    Me.Label11.TabIndex = 165
    Me.Label11.Text = "Fee"
    '
    'Label12
    '
    Me.Label12.BackColor = System.Drawing.SystemColors.Control
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(10, 157)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(56, 12)
    Me.Label12.TabIndex = 163
    Me.Label12.Text = "Balance"
    '
    'Label18
    '
    Me.Label18.BackColor = System.Drawing.SystemColors.Control
    Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label18.Location = New System.Drawing.Point(10, 80)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(36, 12)
    Me.Label18.TabIndex = 159
    Me.Label18.Text = "Lien"
    '
    'Label19
    '
    Me.Label19.BackColor = System.Drawing.SystemColors.Control
    Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label19.Location = New System.Drawing.Point(10, 40)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(48, 12)
    Me.Label19.TabIndex = 157
    Me.Label19.Text = "Interest"
    '
    'Label21
    '
    Me.Label21.BackColor = System.Drawing.SystemColors.Control
    Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label21.Location = New System.Drawing.Point(10, 16)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(48, 12)
    Me.Label21.TabIndex = 155
    Me.Label21.Text = "Principal"
    '
    'ChkValidate
    '
    Me.ChkValidate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkValidate.Location = New System.Drawing.Point(12, 326)
    Me.ChkValidate.Name = "ChkValidate"
    Me.ChkValidate.Size = New System.Drawing.Size(96, 16)
    Me.ChkValidate.TabIndex = 8
    Me.ChkValidate.Text = "Validate Bill?"
    '
    'LblProperty2
    '
    Me.LblProperty2.BackColor = System.Drawing.SystemColors.Control
    Me.LblProperty2.Location = New System.Drawing.Point(108, 71)
    Me.LblProperty2.Name = "LblProperty2"
    Me.LblProperty2.Size = New System.Drawing.Size(232, 16)
    Me.LblProperty2.TabIndex = 203
    '
    'LblProperty
    '
    Me.LblProperty.AutoSize = True
    Me.LblProperty.BackColor = System.Drawing.SystemColors.Control
    Me.LblProperty.Location = New System.Drawing.Point(108, 55)
    Me.LblProperty.Name = "LblProperty"
    Me.LblProperty.Size = New System.Drawing.Size(58, 13)
    Me.LblProperty.TabIndex = 202
    Me.LblProperty.Text = "<Property>"
    '
    'label37
    '
    Me.label37.BackColor = System.Drawing.SystemColors.Control
    Me.label37.Location = New System.Drawing.Point(16, 55)
    Me.label37.Name = "label37"
    Me.label37.Size = New System.Drawing.Size(64, 16)
    Me.label37.TabIndex = 201
    Me.label37.Text = "Property"
    '
    'LblName
    '
    Me.LblName.BackColor = System.Drawing.SystemColors.Control
    Me.LblName.Location = New System.Drawing.Point(108, 25)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(280, 16)
    Me.LblName.TabIndex = 199
    Me.LblName.UseMnemonic = False
    '
    'Label7
    '
    Me.Label7.BackColor = System.Drawing.SystemColors.Control
    Me.Label7.Location = New System.Drawing.Point(164, 9)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(32, 16)
    Me.Label7.TabIndex = 198
    Me.Label7.Text = "Type"
    '
    'LblType
    '
    Me.LblType.BackColor = System.Drawing.SystemColors.Control
    Me.LblType.Location = New System.Drawing.Point(204, 9)
    Me.LblType.Name = "LblType"
    Me.LblType.Size = New System.Drawing.Size(16, 16)
    Me.LblType.TabIndex = 197
    '
    'Label1
    '
    Me.Label1.BackColor = System.Drawing.SystemColors.Control
    Me.Label1.Location = New System.Drawing.Point(228, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(32, 12)
    Me.Label1.TabIndex = 196
    Me.Label1.Text = "Year"
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.SystemColors.Control
    Me.LblYear.Location = New System.Drawing.Point(260, 9)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(48, 16)
    Me.LblYear.TabIndex = 195
    '
    'LblList
    '
    Me.LblList.BackColor = System.Drawing.SystemColors.Control
    Me.LblList.Location = New System.Drawing.Point(108, 9)
    Me.LblList.Name = "LblList"
    Me.LblList.Size = New System.Drawing.Size(48, 16)
    Me.LblList.TabIndex = 194
    '
    'Label5
    '
    Me.Label5.BackColor = System.Drawing.SystemColors.Control
    Me.Label5.Location = New System.Drawing.Point(12, 25)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(84, 12)
    Me.Label5.TabIndex = 193
    Me.Label5.Text = "Name of Owner"
    '
    'Label6
    '
    Me.Label6.BackColor = System.Drawing.SystemColors.Control
    Me.Label6.Location = New System.Drawing.Point(12, 9)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(36, 12)
    Me.Label6.TabIndex = 192
    Me.Label6.Text = "List #"
    '
    'RbAdjust
    '
    Me.RbAdjust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbAdjust.Location = New System.Drawing.Point(184, 97)
    Me.RbAdjust.Name = "RbAdjust"
    Me.RbAdjust.Size = New System.Drawing.Size(80, 16)
    Me.RbAdjust.TabIndex = 0
    Me.RbAdjust.Text = "Adjustment"
    '
    'RbRefund
    '
    Me.RbRefund.Checked = True
    Me.RbRefund.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbRefund.Location = New System.Drawing.Point(264, 97)
    Me.RbRefund.Name = "RbRefund"
    Me.RbRefund.Size = New System.Drawing.Size(64, 16)
    Me.RbRefund.TabIndex = 1
    Me.RbRefund.TabStop = True
    Me.RbRefund.Text = "Refund"
    '
    'LblDefault
    '
    Me.LblDefault.BackColor = System.Drawing.SystemColors.Control
    Me.LblDefault.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDefault.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblDefault.Location = New System.Drawing.Point(352, 9)
    Me.LblDefault.Name = "LblDefault"
    Me.LblDefault.Size = New System.Drawing.Size(132, 16)
    Me.LblDefault.TabIndex = 204
    Me.LblDefault.Text = "Default: Refund"
    Me.LblDefault.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'TxtBond
    '
    Me.TxtBond.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBond.Location = New System.Drawing.Point(248, 201)
    Me.TxtBond.MaxLength = 15
    Me.TxtBond.Name = "TxtBond"
    Me.TxtBond.Size = New System.Drawing.Size(80, 20)
    Me.TxtBond.TabIndex = 6
    Me.TxtBond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label22
    '
    Me.Label22.BackColor = System.Drawing.SystemColors.Control
    Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label22.Location = New System.Drawing.Point(185, 205)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(39, 12)
    Me.Label22.TabIndex = 206
    Me.Label22.Text = "Bond"
    '
    'LblSname
    '
    Me.LblSname.BackColor = System.Drawing.SystemColors.Control
    Me.LblSname.Location = New System.Drawing.Point(108, 41)
    Me.LblSname.Name = "LblSname"
    Me.LblSname.Size = New System.Drawing.Size(280, 16)
    Me.LblSname.TabIndex = 207
    Me.LblSname.UseMnemonic = False
    '
    'Label23
    '
    Me.Label23.BackColor = System.Drawing.SystemColors.Control
    Me.Label23.Location = New System.Drawing.Point(13, 43)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(84, 12)
    Me.Label23.TabIndex = 208
    Me.Label23.Text = "Second Name"
    '
    'FrmTXA09Adj
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(506, 449)
    Me.Controls.Add(Me.Label23)
    Me.Controls.Add(Me.LblSname)
    Me.Controls.Add(Me.Label22)
    Me.Controls.Add(Me.TxtBond)
    Me.Controls.Add(Me.LblDefault)
    Me.Controls.Add(Me.LblProperty2)
    Me.Controls.Add(Me.LblProperty)
    Me.Controls.Add(Me.label37)
    Me.Controls.Add(Me.LblName)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.LblType)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.LblList)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.ChkValidate)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.LblTot)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.RbRefund)
    Me.Controls.Add(Me.RbAdjust)
    Me.Controls.Add(Me.TxtComment)
    Me.Controls.Add(Me.TxtFee)
    Me.Controls.Add(Me.TxtFeeCode)
    Me.Controls.Add(Me.TxtLien)
    Me.Controls.Add(Me.TxtInterest)
    Me.Controls.Add(Me.TxtPrincipal)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.Label17)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.Label14)
    Me.Controls.Add(Me.Label15)
    Me.Controls.Add(Me.Label16)
    Me.Controls.Add(Me.TbMain)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA09Adj"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Adjust/Refund"
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region
  Private Sub FrmTXA09Adj_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    Me.Dispose()
  End Sub

  Private Sub FrmTXA09Adj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkPrincipal As Decimal
    Dim WrkInterest As Decimal
    Dim WrkFee As Decimal
    Dim WrkLien As Decimal
    Dim WrkBond As Decimal
    Dim WrkBal As Decimal
    Dim WrkFamily As String

    MyFrmTXA09.TBarBack.Enabled = False

    myTBATCH = New TBATCH.MyData(myDBConnect)
    myTXBATCH = New TXBATCH.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)

    With MyFrmTXA09B
      LblList.Text = WrkListNo
      LblYear.Text = WrkYear
      LblType.Text = WrkType
      WrkFamily = GetTXTypeFamily(LblType.Text)
      If WrkFamily = "A" Then
        MyUtils.SetTxtReadOnly(TxtFee)
        MyUtils.SetTxtReadOnly(TxtFeeCode)
      Else
        MyUtils.SetTxtReadOnly(TxtBond)
      End If
      LblName.Text = MyFrmTXA09B.LblName.Text
      LblSname.Text = MyFrmTXA09B.LblSname.Text
      LblProperty.Text = MyFrmTXA09B.LblProperty.Text
      LblProperty2.Text = MyFrmTXA09B.LblProperty2.Text
      WrkPrincipal = MyUtils.CnvSng(.LblTotpay.Text)
      WrkInterest = MyUtils.CnvSng(.LblIntPaid.Text)
      WrkFee = MyUtils.CnvSng(.LblFee.Text)
      WrkLien = MyUtils.CnvSng(.LblLien.Text)
      WrkBond = MyUtils.CnvSng(.LblBondPaid.Text)
      WrkBal = MyUtils.CnvSng(.LblRemain.Text)
      LblCurPrincipal.Text = Format(WrkPrincipal, "fixed")
      LblCurInterest.Text = Format(WrkInterest, "fixed")
      LblCurFee.Text = Format(WrkFee, "fixed")
      LblCurLien.Text = Format(WrkLien, "fixed")
      LblCurBond.Text = Format(WrkBond, "fixed")
      LblCurTot.Text = Format(WrkPrincipal + WrkInterest + WrkFee + WrkLien + WrkBond, "fixed")
      LblCurBal.Text = Format(WrkBal, "fixed")
    End With

    If MyValidation Then
      ChkValidate.Checked = True
    End If

    ChkValidate.Enabled = False

    If MyRefundBatch Then
      LblDefault.Text = "Default: Refund"
    Else
      RbAdjust.Checked = True
      LblDefault.Text = "Default: Adjustment"
    End If
    If RbRefund.Checked And MyLastCommentRefund <> String.Empty Then
      TxtComment.Text = MyLastCommentRefund
    End If

  End Sub

  Private Sub FrmTXA099_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA09.SbpScreen.Text = "TXA09Adj"
    With MyFrmTXA09
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Sub CalcDue()
    Dim WrkPrincipal As Decimal
    Dim WrkInterest As Decimal
    Dim WrkFee As Decimal
    Dim WrkLien As Decimal
    Dim WrkBond As Decimal

    WrkPrincipal = MyUtils.CnvSng(TxtPrincipal.Text)
    WrkInterest = MyUtils.CnvSng(TxtInterest.Text)
    WrkFee = MyUtils.CnvSng(TxtFee.Text)
    WrkLien = MyUtils.CnvSng(TxtLien.Text)
    WrkBond = MyUtils.CnvSng(TxtBond.Text)
    LblTot.Text = Format(WrkPrincipal + WrkInterest + WrkFee + WrkLien + WrkBond, "fixed")
  End Sub
  Sub CalcNewDue()
    Dim WrkPrincipal As Decimal
    Dim WrkInterest As Decimal
    Dim WrkFee As Decimal
    Dim WrkLien As Decimal
    Dim WrkBond As Decimal

    WrkPrincipal = MyUtils.CnvSng(LblCurPrincipal.Text) - MyUtils.CnvSng(TxtPrincipal.Text)
    LblNewPrincipal.Text = Format(WrkPrincipal, "fixed")
    WrkInterest = MyUtils.CnvSng(LblCurInterest.Text) - MyUtils.CnvSng(TxtInterest.Text)
    LblNewInterest.Text = Format(WrkInterest, "fixed")
    WrkFee = MyUtils.CnvSng(LblCurFee.Text) - MyUtils.CnvSng(TxtFee.Text)
    LblNewFee.Text = Format(WrkFee, "fixed")
    WrkLien = MyUtils.CnvSng(LblCurLien.Text) - MyUtils.CnvSng(TxtLien.Text)
    LblNewLien.Text = Format(WrkLien, "fixed")
    WrkBond = MyUtils.CnvSng(LblCurBond.Text) - MyUtils.CnvSng(TxtBond.Text)
    LblNewBond.Text = Format(WrkBond, "fixed")
    LblNewTot.Text = Format(WrkPrincipal + WrkInterest + WrkFee + WrkLien + WrkBond, "fixed")
    If MyUtils.CnvSng(MyFrmTXA09B.LblRemain.Text) >= 0 Then
      LblNewBal.Text = Format(MyFrmTXA09B.LblRemain.Text + MyUtils.CnvSng(TxtPrincipal.Text), "fixed")
    Else
      LblNewBal.Text = Format(MyFrmTXA09B.LblRemain.Text - MyUtils.CnvSng(TxtPrincipal.Text), "fixed")
    End If
  End Sub
  'Public Async Sub RunSaveData()
  '  Await Task.Run(Sub()
  '                   SaveData()
  '                 End Sub)
  'End Sub
  Public Sub SaveData()

    NextSeqNo = myTXBATCH.AutoGenKey(MyBatch, MyBatchNo)
    myTXBATCH.GetOneRecordP(MyBatch, MyBatchNo, NextSeqNo)

    MoveToFile()
    myTXBATCH.AddOneRecordP()
    If RbRefund.Checked Then
      MyLastCommentRefund = TxtComment.Text
    End If

    If ChkValidate.Enabled And ChkValidate.Checked Then
      BuildDS()
      AddOneRecord()
      If MyAppSettings.AdvDriver Then
        PrtReceiptDirect(ds, MyValidation, MyAppSettings.Receipt)
      Else
        PrtReceipt(ds, MyValidation, MyAppSettings.Receipt)
      End If
      ds.Clear()
      ds = Nothing
    End If

    MoveToTXINV()
    MoveToTBATCH()

    With MyFrmTXA09B
      '      If .InvokeRequired Then
      '     .Invoke(Sub()
      .LblUnposted.Text = Format(MyUtils.CnvSng(.LblUnposted.Text) - MyUtils.CnvSng(TxtPrincipal.Text), "fixed")
      .LblUnpostedInt.Text = Format(MyUtils.CnvSng(.LblUnpostedInt.Text) - MyUtils.CnvSng(TxtInterest.Text), "fixed")
      .LblUnpostedLien.Text = Format(MyUtils.CnvSng(.LblUnpostedLien.Text) - MyUtils.CnvSng(TxtLien.Text), "fixed")
      Me.Close()
      '              End Sub)
      '   End If
    End With
    myTXBATCH.CloseFile()
  End Sub
  Private Sub MoveToFile()
    With myTXBATCH
      ._JBTCHC = MyBatch
      ._JBATCH = MyBatchNo
      ._JSEQNO = NextSeqNo
      ._JSTAT = WrkICode
      ._LISTNo = WrkListNo
      ._YEAR = WrkYear
      ._TYPE = WrkType
      ._PAMT = MyUtils.CnvSng(TxtPrincipal.Text) * -1
      ._IAMT = MyUtils.CnvSng(TxtInterest.Text) * -1
      If MyUtils.CnvSng(TxtFee.Text) <> 0 Then
        ._TCAMT = MyUtils.CnvSng(TxtFee.Text) * -1
        ._CPENCD = TxtFeeCode.Text
      Else
        If MyUtils.CnvSng(TxtBond.Text) <> 0 Then
          ._TCAMT = MyUtils.CnvSng(TxtBond.Text) * -1
          ._CPENCD = "BI"
        Else
          ._TCAMT = 0
          ._CPENCD = ""
        End If
      End If
      ._LAMT = MyUtils.CnvSng(TxtLien.Text) * -1
      ._CASH = 0
      ._CHECK = 0
      ._CREDIT = 0
      If RbPayCash.Checked Then
        ._CORC = "1"
        ._CASH = MyUtils.CnvSng(LblTot.Text) * -1
      End If
      If RbPayCheck.Checked Then
        ._CORC = "2"
        ._CHECK = MyUtils.CnvSng(LblTot.Text) * -1
      End If
      If RbPayCredit.Checked Then
        ._CORC = "3"
        ._CREDIT = MyUtils.CnvSng(LblTot.Text) * -1
      End If
      ._DIST = MyUtils.CnvSng(MyFrmTXA09B.LblDist.Text)
      ._REFE = String.Empty
      ._COMM = TxtComment.Text
      If RbAdjust.Checked Then
        ._ADJCD = "A"
      Else
        ._ADJCD = "R"
      End If
      ._JBTCHT = "01"
      ._JTCODE = String.Empty
      ._JUCODE = String.Empty
      ._NAME = MyFrmTXA09B.LblName.Text
      ._ASOFD = 0
      ._CINTPD = 0
      ._JIY = Year(MyInterestDate)
      ._JIM = Month(MyInterestDate)
      ._JID = Microsoft.VisualBasic.DateAndTime.Day(MyInterestDate)
      ._JRY = Year(MyReceiptDate)
      ._JRM = Month(MyReceiptDate)
      ._JRD = Microsoft.VisualBasic.DateAndTime.Day(MyReceiptDate)
      ._SIMT = 0
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

    WrkFamily = GetTXTypeFamily(LblType.Text)

    myTXINV.GetOneRecordP(WrkListNo, WrkYear, LblType.Text)
    With myTXINV
      ._NEWPAY = ._NEWPAY + (MyUtils.CnvSng(TxtPrincipal.Text) * -1)
      If WrkFamily = "A" Then
        If MyUtils.CnvSng(TxtBond.Text) <> 0 Then
          ._BONT = ._BONT + (MyUtils.CnvSng(TxtBond.Text) * -1)
        End If
      End If
      .UpdateOneRecordP()
      .CloseFile()
    End With
  End Sub
  Private Sub MoveToTBATCH()
    myTBATCH.GetOneRecordP(MyBatch, MyBatchNo)
    With myTBATCH
      ._KBEND = ._KBEND + (MyUtils.CnvSng(LblTot.Text) * -1)
      .UpdateOneRecordP()
      .CloseFile()
    End With
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  End Sub
  Private Sub TxtPrincipal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrincipal.TextChanged
    CalcDue()
    CalcNewDue()
  End Sub
  Private Sub TxtInterest_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtInterest.TextChanged
    CalcDue()
    CalcNewDue()
  End Sub
  Private Sub TxtLien_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLien.TextChanged
    CalcDue()
    CalcNewDue()
  End Sub
  Private Sub TxtFee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFee.TextChanged
    CalcDue()
    CalcNewDue()
  End Sub
  Private Sub TxtBond_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBond.TextChanged
    CalcDue()
    CalcNewDue()
  End Sub
  Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
    If e.Button Is TBarSave Then
      'RunSaveData()
      SaveData()
    End If
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
  Private Sub TxtFee_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFee.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtBond_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBond.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub FrmTXA09Adj_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub

    If e.KeyCode = Keys.S Then
      'RunSaveData()
      SaveData()
    End If
  End Sub
  Private Sub FrmTXA09Adj_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
    MyUtils.KeyEnter_isTab(Me, e)
  End Sub
  Private Sub FrmTXA09Adj_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTXA09.SbpScreen.Text = "TXA09B"
    MyFrmTXA09.TBarBack.Enabled = True
    If MyScanOnly Then
      MyFrmTXA094.FormatGrid(False, False, True)
    Else
      MyFrmTXA094.FormatGrid(True, True, False)
    End If
    'Memory Cleanup
    myTBATCH.CloseFile()
    myTXBATCH.CloseFile()
    myTXINV.CloseFile()
    myTBATCH = Nothing
    myTXBATCH = Nothing
    myTXINV = Nothing
    MyFrmTXA09Adj = Nothing
  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    ds = New DataSet
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Sname", Type.GetType("System.String"))
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
    myDr("Sname") = LblSname.Text
    myDr("PropDesc") = LblProperty.Text
    myDr("PropDesc2") = LblProperty2.Text
    myDr("Principal") = MyUtils.CnvSng(TxtPrincipal.Text) * -1
    myDr("Interest") = MyUtils.CnvSng(TxtInterest.Text) * -1
    myDr("Liens") = MyUtils.CnvSng(TxtLien.Text) * -1
    myDr("Fees") = MyUtils.CnvSng(TxtFee.Text) * -1
    myDr("Bond") = 0
    myDr("Total") = MyUtils.CnvSng(LblTot.Text)
    myDr("Cash") = MyUtils.CnvSng(LblTot.Text)
    If RbPayCash.Checked Then
      myDr("Cash") = MyUtils.CnvSng(LblTot.Text)
    Else
      myDr("Cash") = 0
    End If
    If RbPayCheck.Checked Then
      myDr("Check") = MyUtils.CnvSng(LblTot.Text)
    Else
      myDr("Check") = 0
    End If
    If RbPayCash.Checked Then
      myDr("Credit") = MyUtils.CnvSng(LblTot.Text)
    Else
      myDr("Credit") = 0
    End If
    myDr("batch") = MyBatch
    myDr("batchno") = MyBatchNo
    myDr("recdt") = MyReceiptDate
    myDr("refe") = ""
    ds.Tables(0).Rows.Add(myDr)

  End Sub
  Private Sub RbRefund_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbRefund.Click
    ChkValidate.Enabled = False
  End Sub
  Private Sub RbAdjust_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbAdjust.Click
    ChkValidate.Enabled = True
  End Sub
End Class






