Public Class FrmTXA01D
  Inherits System.Windows.Forms.Form
	Dim myBCHHDR As BCHHDR.myData
  Dim myTCRBCH As TCRBCH.myData
  Dim myTXINV As TXINV.myData
	Dim MyTXPEN As TXPEN.myData
	Friend WrkBatchNo As Integer
  Friend WrkSeq As Integer
  Friend WrkReceiptDate As Date
  Friend WithEvents LblName As System.Windows.Forms.Label
	Friend WithEvents Label9 As System.Windows.Forms.Label
	Friend WithEvents TxtRef As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
 Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
 Friend WithEvents RbPayCheck As System.Windows.Forms.RadioButton
 Friend WithEvents RbPayCredit As System.Windows.Forms.RadioButton
 Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
 Friend WithEvents LblDtInt As System.Windows.Forms.Label
 Friend WithEvents DtPckInt As System.Windows.Forms.DateTimePicker
 Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
 Friend WithEvents RbTranPayment As System.Windows.Forms.RadioButton
 Friend WithEvents RbTranAdjust As System.Windows.Forms.RadioButton
 Friend WithEvents LblMsg As System.Windows.Forms.Label
 Friend WithEvents RbTranRefund As System.Windows.Forms.RadioButton
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
 Friend WithEvents TxtFeeCd6 As System.Windows.Forms.TextBox
 Friend WithEvents LnkFeeCd6 As System.Windows.Forms.LinkLabel
 Friend WithEvents TxtFee6 As System.Windows.Forms.TextBox
 Friend WithEvents TxtFeeCd7 As System.Windows.Forms.TextBox
 Friend WithEvents LnkFeeCd7 As System.Windows.Forms.LinkLabel
 Friend WithEvents TxtFee7 As System.Windows.Forms.TextBox
 Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
 Friend WithEvents RadioButton8 As System.Windows.Forms.RadioButton
 Friend WithEvents RadioButton9 As System.Windows.Forms.RadioButton
 Friend WithEvents RadioButton10 As System.Windows.Forms.RadioButton
 Friend WithEvents Label15 As System.Windows.Forms.Label
 Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
 Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
 Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
 Friend WithEvents RadioButton7 As System.Windows.Forms.RadioButton
 Friend WithEvents TextBox18 As System.Windows.Forms.TextBox
 Friend WithEvents Label14 As System.Windows.Forms.Label
 Friend WithEvents Label13 As System.Windows.Forms.Label
 Friend WithEvents Label11 As System.Windows.Forms.Label
 Friend WithEvents Label6 As System.Windows.Forms.Label
 Friend WithEvents LblTotal As System.Windows.Forms.Label
 Friend WithEvents Label19 As System.Windows.Forms.Label
 Dim AddMode As Boolean

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
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TxtType As System.Windows.Forms.TextBox
Friend WithEvents TxtYear As System.Windows.Forms.TextBox
Friend WithEvents TxtList As System.Windows.Forms.TextBox
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents TxtPrincipal As System.Windows.Forms.TextBox
Friend WithEvents TxtInterest As System.Windows.Forms.TextBox
Friend WithEvents TxtLien As System.Windows.Forms.TextBox
Friend WithEvents TxtComment As System.Windows.Forms.TextBox
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents LblBatch As System.Windows.Forms.Label
Friend WithEvents Label10 As System.Windows.Forms.Label
Friend WithEvents LblSeq As System.Windows.Forms.Label
Friend WithEvents LnkInv As System.Windows.Forms.LinkLabel
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtPrincipal = New System.Windows.Forms.TextBox()
    Me.TxtInterest = New System.Windows.Forms.TextBox()
    Me.TxtLien = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.TxtList = New System.Windows.Forms.TextBox()
    Me.TxtComment = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.LblBatch = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.LblSeq = New System.Windows.Forms.Label()
    Me.LnkInv = New System.Windows.Forms.LinkLabel()
    Me.LblName = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtRef = New System.Windows.Forms.TextBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbPayCheck = New System.Windows.Forms.RadioButton()
    Me.RbPayCredit = New System.Windows.Forms.RadioButton()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LblDtInt = New System.Windows.Forms.Label()
    Me.DtPckInt = New System.Windows.Forms.DateTimePicker()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbTranRefund = New System.Windows.Forms.RadioButton()
    Me.RbTranPayment = New System.Windows.Forms.RadioButton()
    Me.RbTranAdjust = New System.Windows.Forms.RadioButton()
    Me.LblMsg = New System.Windows.Forms.Label()
    Me.GrpFees = New System.Windows.Forms.GroupBox()
    Me.TxtFeeCd7 = New System.Windows.Forms.TextBox()
    Me.GroupBox7 = New System.Windows.Forms.GroupBox()
    Me.RadioButton8 = New System.Windows.Forms.RadioButton()
    Me.RadioButton9 = New System.Windows.Forms.RadioButton()
    Me.RadioButton10 = New System.Windows.Forms.RadioButton()
    Me.LnkFeeCd7 = New System.Windows.Forms.LinkLabel()
    Me.TxtFee7 = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.TxtFeeCd6 = New System.Windows.Forms.TextBox()
    Me.LnkFeeCd6 = New System.Windows.Forms.LinkLabel()
    Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
    Me.TxtFee6 = New System.Windows.Forms.TextBox()
    Me.TxtFeeCd5 = New System.Windows.Forms.TextBox()
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.RadioButton6 = New System.Windows.Forms.RadioButton()
    Me.RadioButton7 = New System.Windows.Forms.RadioButton()
    Me.LnkFeeCd5 = New System.Windows.Forms.LinkLabel()
    Me.TxtFee5 = New System.Windows.Forms.TextBox()
    Me.TextBox18 = New System.Windows.Forms.TextBox()
    Me.TxtFeeCd4 = New System.Windows.Forms.TextBox()
    Me.LnkFeeCd4 = New System.Windows.Forms.LinkLabel()
    Me.Label14 = New System.Windows.Forms.Label()
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
    Me.Label13 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.LblTotal = New System.Windows.Forms.Label()
    Me.Label19 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.GrpFees.SuspendLayout()
    Me.GroupBox7.SuspendLayout()
    Me.GroupBox6.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(232, 32)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(48, 24)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "District"
    '
    'TxtDist
    '
    Me.TxtDist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDist.Location = New System.Drawing.Point(288, 32)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(28, 20)
    Me.TxtDist.TabIndex = 3
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(16, 100)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(72, 16)
    Me.Label5.TabIndex = 8
    Me.Label5.Text = "Principal"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtPrincipal
    '
    Me.TxtPrincipal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPrincipal.Location = New System.Drawing.Point(92, 96)
    Me.TxtPrincipal.MaxLength = 9
    Me.TxtPrincipal.Name = "TxtPrincipal"
    Me.TxtPrincipal.Size = New System.Drawing.Size(80, 20)
    Me.TxtPrincipal.TabIndex = 4
    Me.TxtPrincipal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtInterest
    '
    Me.TxtInterest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtInterest.Location = New System.Drawing.Point(92, 120)
    Me.TxtInterest.MaxLength = 9
    Me.TxtInterest.Name = "TxtInterest"
    Me.TxtInterest.Size = New System.Drawing.Size(80, 20)
    Me.TxtInterest.TabIndex = 5
    Me.TxtInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtLien
    '
    Me.TxtLien.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLien.Location = New System.Drawing.Point(92, 144)
    Me.TxtLien.MaxLength = 9
    Me.TxtLien.Name = "TxtLien"
    Me.TxtLien.Size = New System.Drawing.Size(80, 20)
    Me.TxtLien.TabIndex = 6
    Me.TxtLien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(16, 124)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(72, 16)
    Me.Label3.TabIndex = 15
    Me.Label3.Text = "Interest"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(16, 148)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(72, 16)
    Me.Label4.TabIndex = 16
    Me.Label4.Text = "Lien"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtType.Location = New System.Drawing.Point(156, 32)
    Me.TxtType.MaxLength = 1
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(16, 20)
    Me.TxtType.TabIndex = 1
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(172, 32)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtYear.TabIndex = 2
    '
    'TxtList
    '
    Me.TxtList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtList.Location = New System.Drawing.Point(100, 32)
    Me.TxtList.MaxLength = 12
    Me.TxtList.Name = "TxtList"
    Me.TxtList.Size = New System.Drawing.Size(56, 20)
    Me.TxtList.TabIndex = 0
    '
    'TxtComment
    '
    Me.TxtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtComment.Location = New System.Drawing.Point(92, 277)
    Me.TxtComment.MaxLength = 20
    Me.TxtComment.Name = "TxtComment"
    Me.TxtComment.Size = New System.Drawing.Size(164, 20)
    Me.TxtComment.TabIndex = 10
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(16, 281)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(68, 16)
    Me.Label7.TabIndex = 23
    Me.Label7.Text = "Comment"
    Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(12, 8)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(36, 14)
    Me.Label8.TabIndex = 24
    Me.Label8.Text = "Batch"
    '
    'LblBatch
    '
    Me.LblBatch.Location = New System.Drawing.Point(56, 8)
    Me.LblBatch.Name = "LblBatch"
    Me.LblBatch.Size = New System.Drawing.Size(48, 12)
    Me.LblBatch.TabIndex = 25
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(116, 8)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(32, 14)
    Me.Label10.TabIndex = 26
    Me.Label10.Text = "Seq"
    '
    'LblSeq
    '
    Me.LblSeq.Location = New System.Drawing.Point(148, 8)
    Me.LblSeq.Name = "LblSeq"
    Me.LblSeq.Size = New System.Drawing.Size(32, 12)
    Me.LblSeq.TabIndex = 27
    '
    'LnkInv
    '
    Me.LnkInv.Location = New System.Drawing.Point(16, 36)
    Me.LnkInv.Name = "LnkInv"
    Me.LnkInv.Size = New System.Drawing.Size(80, 16)
    Me.LnkInv.TabIndex = 235
    Me.LnkInv.TabStop = True
    Me.LnkInv.Text = "List/Type/Year"
    '
    'LblName
    '
    Me.LblName.Location = New System.Drawing.Point(58, 64)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(238, 14)
    Me.LblName.TabIndex = 237
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(16, 64)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(36, 14)
    Me.Label9.TabIndex = 236
    Me.Label9.Text = "Name"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(16, 307)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(68, 16)
    Me.Label1.TabIndex = 238
    Me.Label1.Text = "Reference"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtRef
    '
    Me.TxtRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRef.Location = New System.Drawing.Point(92, 303)
    Me.TxtRef.MaxLength = 10
    Me.TxtRef.Name = "TxtRef"
    Me.TxtRef.Size = New System.Drawing.Size(80, 20)
    Me.TxtRef.TabIndex = 11
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbPayCheck)
    Me.GroupBox2.Controls.Add(Me.RbPayCredit)
    Me.GroupBox2.Location = New System.Drawing.Point(15, 368)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(178, 45)
    Me.GroupBox2.TabIndex = 13
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Payment Type"
    '
    'RbPayCheck
    '
    Me.RbPayCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPayCheck.Checked = True
    Me.RbPayCheck.Location = New System.Drawing.Point(10, 16)
    Me.RbPayCheck.Name = "RbPayCheck"
    Me.RbPayCheck.Size = New System.Drawing.Size(59, 25)
    Me.RbPayCheck.TabIndex = 2
    Me.RbPayCheck.TabStop = True
    Me.RbPayCheck.Text = "Check"
    Me.RbPayCheck.UseVisualStyleBackColor = True
    '
    'RbPayCredit
    '
    Me.RbPayCredit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPayCredit.Location = New System.Drawing.Point(104, 13)
    Me.RbPayCredit.Name = "RbPayCredit"
    Me.RbPayCredit.Size = New System.Drawing.Size(57, 28)
    Me.RbPayCredit.TabIndex = 3
    Me.RbPayCredit.Text = "Credit"
    Me.RbPayCredit.UseVisualStyleBackColor = True
    '
    'LblDtInt
    '
    Me.LblDtInt.Location = New System.Drawing.Point(16, 337)
    Me.LblDtInt.Name = "LblDtInt"
    Me.LblDtInt.Size = New System.Drawing.Size(72, 16)
    Me.LblDtInt.TabIndex = 244
    Me.LblDtInt.Text = "Receipt Date"
    '
    'DtPckInt
    '
    Me.DtPckInt.Checked = False
    Me.DtPckInt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckInt.Location = New System.Drawing.Point(92, 333)
    Me.DtPckInt.Name = "DtPckInt"
    Me.DtPckInt.ShowCheckBox = True
    Me.DtPckInt.Size = New System.Drawing.Size(96, 20)
    Me.DtPckInt.TabIndex = 12
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbTranRefund)
    Me.GroupBox1.Controls.Add(Me.RbTranPayment)
    Me.GroupBox1.Controls.Add(Me.RbTranAdjust)
    Me.GroupBox1.Location = New System.Drawing.Point(201, 337)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(268, 45)
    Me.GroupBox1.TabIndex = 14
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Transaction Type"
    '
    'RbTranRefund
    '
    Me.RbTranRefund.AutoSize = True
    Me.RbTranRefund.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbTranRefund.Location = New System.Drawing.Point(199, 20)
    Me.RbTranRefund.Name = "RbTranRefund"
    Me.RbTranRefund.Size = New System.Drawing.Size(60, 17)
    Me.RbTranRefund.TabIndex = 4
    Me.RbTranRefund.Text = "Refund"
    Me.RbTranRefund.UseVisualStyleBackColor = True
    '
    'RbTranPayment
    '
    Me.RbTranPayment.AutoSize = True
    Me.RbTranPayment.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbTranPayment.Checked = True
    Me.RbTranPayment.Location = New System.Drawing.Point(6, 20)
    Me.RbTranPayment.Name = "RbTranPayment"
    Me.RbTranPayment.Size = New System.Drawing.Size(66, 17)
    Me.RbTranPayment.TabIndex = 2
    Me.RbTranPayment.TabStop = True
    Me.RbTranPayment.Text = "Payment"
    Me.RbTranPayment.UseVisualStyleBackColor = True
    '
    'RbTranAdjust
    '
    Me.RbTranAdjust.AutoSize = True
    Me.RbTranAdjust.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbTranAdjust.Location = New System.Drawing.Point(99, 20)
    Me.RbTranAdjust.Name = "RbTranAdjust"
    Me.RbTranAdjust.Size = New System.Drawing.Size(77, 17)
    Me.RbTranAdjust.TabIndex = 3
    Me.RbTranAdjust.Text = "Adjustment"
    Me.RbTranAdjust.UseVisualStyleBackColor = True
    '
    'LblMsg
    '
    Me.LblMsg.BackColor = System.Drawing.SystemColors.Control
    Me.LblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMsg.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblMsg.Location = New System.Drawing.Point(313, 4)
    Me.LblMsg.Name = "LblMsg"
    Me.LblMsg.Size = New System.Drawing.Size(77, 16)
    Me.LblMsg.TabIndex = 246
    Me.LblMsg.Text = "<Message>"
    Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'GrpFees
    '
    Me.GrpFees.Controls.Add(Me.TxtFeeCd7)
    Me.GrpFees.Controls.Add(Me.GroupBox7)
    Me.GrpFees.Controls.Add(Me.LnkFeeCd7)
    Me.GrpFees.Controls.Add(Me.TxtFee7)
    Me.GrpFees.Controls.Add(Me.Label15)
    Me.GrpFees.Controls.Add(Me.TxtFeeCd6)
    Me.GrpFees.Controls.Add(Me.LnkFeeCd6)
    Me.GrpFees.Controls.Add(Me.DateTimePicker2)
    Me.GrpFees.Controls.Add(Me.TxtFee6)
    Me.GrpFees.Controls.Add(Me.TxtFeeCd5)
    Me.GrpFees.Controls.Add(Me.GroupBox6)
    Me.GrpFees.Controls.Add(Me.LnkFeeCd5)
    Me.GrpFees.Controls.Add(Me.TxtFee5)
    Me.GrpFees.Controls.Add(Me.TextBox18)
    Me.GrpFees.Controls.Add(Me.TxtFeeCd4)
    Me.GrpFees.Controls.Add(Me.LnkFeeCd4)
    Me.GrpFees.Controls.Add(Me.Label14)
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
    Me.GrpFees.Controls.Add(Me.Label13)
    Me.GrpFees.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpFees.Location = New System.Drawing.Point(201, 81)
    Me.GrpFees.Name = "GrpFees"
    Me.GrpFees.Size = New System.Drawing.Size(166, 176)
    Me.GrpFees.TabIndex = 7
    Me.GrpFees.TabStop = False
    Me.GrpFees.Text = "Fees"
    '
    'TxtFeeCd7
    '
    Me.TxtFeeCd7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFeeCd7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFeeCd7.Location = New System.Drawing.Point(130, 153)
    Me.TxtFeeCd7.MaxLength = 2
    Me.TxtFeeCd7.Name = "TxtFeeCd7"
    Me.TxtFeeCd7.Size = New System.Drawing.Size(24, 20)
    Me.TxtFeeCd7.TabIndex = 186
    '
    'GroupBox7
    '
    Me.GroupBox7.Controls.Add(Me.RadioButton8)
    Me.GroupBox7.Controls.Add(Me.RadioButton9)
    Me.GroupBox7.Controls.Add(Me.RadioButton10)
    Me.GroupBox7.Location = New System.Drawing.Point(6, 247)
    Me.GroupBox7.Name = "GroupBox7"
    Me.GroupBox7.Size = New System.Drawing.Size(268, 45)
    Me.GroupBox7.TabIndex = 14
    Me.GroupBox7.TabStop = False
    Me.GroupBox7.Text = "Transaction Type"
    '
    'RadioButton8
    '
    Me.RadioButton8.AutoSize = True
    Me.RadioButton8.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RadioButton8.Location = New System.Drawing.Point(199, 20)
    Me.RadioButton8.Name = "RadioButton8"
    Me.RadioButton8.Size = New System.Drawing.Size(66, 17)
    Me.RadioButton8.TabIndex = 4
    Me.RadioButton8.Text = "Refund"
    Me.RadioButton8.UseVisualStyleBackColor = True
    '
    'RadioButton9
    '
    Me.RadioButton9.AutoSize = True
    Me.RadioButton9.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RadioButton9.Checked = True
    Me.RadioButton9.Location = New System.Drawing.Point(6, 20)
    Me.RadioButton9.Name = "RadioButton9"
    Me.RadioButton9.Size = New System.Drawing.Size(73, 17)
    Me.RadioButton9.TabIndex = 2
    Me.RadioButton9.TabStop = True
    Me.RadioButton9.Text = "Payment"
    Me.RadioButton9.UseVisualStyleBackColor = True
    '
    'RadioButton10
    '
    Me.RadioButton10.AutoSize = True
    Me.RadioButton10.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RadioButton10.Location = New System.Drawing.Point(99, 20)
    Me.RadioButton10.Name = "RadioButton10"
    Me.RadioButton10.Size = New System.Drawing.Size(87, 17)
    Me.RadioButton10.TabIndex = 3
    Me.RadioButton10.Text = "Adjustment"
    Me.RadioButton10.UseVisualStyleBackColor = True
    '
    'LnkFeeCd7
    '
    Me.LnkFeeCd7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFeeCd7.Location = New System.Drawing.Point(92, 156)
    Me.LnkFeeCd7.Name = "LnkFeeCd7"
    Me.LnkFeeCd7.Size = New System.Drawing.Size(34, 17)
    Me.LnkFeeCd7.TabIndex = 185
    Me.LnkFeeCd7.TabStop = True
    Me.LnkFeeCd7.Text = "Code"
    '
    'TxtFee7
    '
    Me.TxtFee7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFee7.Location = New System.Drawing.Point(6, 153)
    Me.TxtFee7.MaxLength = 10
    Me.TxtFee7.Name = "TxtFee7"
    Me.TxtFee7.Size = New System.Drawing.Size(80, 20)
    Me.TxtFee7.TabIndex = 184
    Me.TxtFee7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label15
    '
    Me.Label15.Location = New System.Drawing.Point(-179, 216)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(72, 16)
    Me.Label15.TabIndex = 244
    Me.Label15.Text = "Receipt Date"
    '
    'TxtFeeCd6
    '
    Me.TxtFeeCd6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFeeCd6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFeeCd6.Location = New System.Drawing.Point(130, 130)
    Me.TxtFeeCd6.MaxLength = 2
    Me.TxtFeeCd6.Name = "TxtFeeCd6"
    Me.TxtFeeCd6.Size = New System.Drawing.Size(24, 20)
    Me.TxtFeeCd6.TabIndex = 183
    '
    'LnkFeeCd6
    '
    Me.LnkFeeCd6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFeeCd6.Location = New System.Drawing.Point(93, 133)
    Me.LnkFeeCd6.Name = "LnkFeeCd6"
    Me.LnkFeeCd6.Size = New System.Drawing.Size(34, 17)
    Me.LnkFeeCd6.TabIndex = 182
    Me.LnkFeeCd6.TabStop = True
    Me.LnkFeeCd6.Text = "Code"
    '
    'DateTimePicker2
    '
    Me.DateTimePicker2.Checked = False
    Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DateTimePicker2.Location = New System.Drawing.Point(-103, 212)
    Me.DateTimePicker2.Name = "DateTimePicker2"
    Me.DateTimePicker2.ShowCheckBox = True
    Me.DateTimePicker2.Size = New System.Drawing.Size(96, 20)
    Me.DateTimePicker2.TabIndex = 12
    '
    'TxtFee6
    '
    Me.TxtFee6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFee6.Location = New System.Drawing.Point(6, 130)
    Me.TxtFee6.MaxLength = 10
    Me.TxtFee6.Name = "TxtFee6"
    Me.TxtFee6.Size = New System.Drawing.Size(80, 20)
    Me.TxtFee6.TabIndex = 181
    Me.TxtFee6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
    'GroupBox6
    '
    Me.GroupBox6.Controls.Add(Me.RadioButton6)
    Me.GroupBox6.Controls.Add(Me.RadioButton7)
    Me.GroupBox6.Location = New System.Drawing.Point(-180, 247)
    Me.GroupBox6.Name = "GroupBox6"
    Me.GroupBox6.Size = New System.Drawing.Size(178, 45)
    Me.GroupBox6.TabIndex = 13
    Me.GroupBox6.TabStop = False
    Me.GroupBox6.Text = "Payment Type"
    '
    'RadioButton6
    '
    Me.RadioButton6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RadioButton6.Checked = True
    Me.RadioButton6.Location = New System.Drawing.Point(10, 16)
    Me.RadioButton6.Name = "RadioButton6"
    Me.RadioButton6.Size = New System.Drawing.Size(59, 25)
    Me.RadioButton6.TabIndex = 2
    Me.RadioButton6.TabStop = True
    Me.RadioButton6.Text = "Check"
    Me.RadioButton6.UseVisualStyleBackColor = True
    '
    'RadioButton7
    '
    Me.RadioButton7.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RadioButton7.Location = New System.Drawing.Point(104, 13)
    Me.RadioButton7.Name = "RadioButton7"
    Me.RadioButton7.Size = New System.Drawing.Size(57, 28)
    Me.RadioButton7.TabIndex = 3
    Me.RadioButton7.Text = "Credit"
    Me.RadioButton7.UseVisualStyleBackColor = True
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
    'TextBox18
    '
    Me.TextBox18.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TextBox18.Location = New System.Drawing.Point(-103, 182)
    Me.TextBox18.MaxLength = 10
    Me.TextBox18.Name = "TextBox18"
    Me.TextBox18.Size = New System.Drawing.Size(80, 20)
    Me.TextBox18.TabIndex = 11
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
    'Label14
    '
    Me.Label14.Location = New System.Drawing.Point(-179, 186)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(68, 16)
    Me.Label14.TabIndex = 238
    Me.Label14.Text = "Reference"
    Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(-179, 160)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(68, 16)
    Me.Label13.TabIndex = 23
    Me.Label13.Text = "Comment"
    Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(16, 281)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(68, 16)
    Me.Label6.TabIndex = 23
    Me.Label6.Text = "Comment"
    Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label11
    '
    Me.Label11.Location = New System.Drawing.Point(16, 307)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(68, 16)
    Me.Label11.TabIndex = 238
    Me.Label11.Text = "Reference"
    Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblTotal
    '
    Me.LblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotal.Location = New System.Drawing.Point(389, 32)
    Me.LblTotal.Name = "LblTotal"
    Me.LblTotal.Size = New System.Drawing.Size(80, 20)
    Me.LblTotal.TabIndex = 248
    Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label19
    '
    Me.Label19.BackColor = System.Drawing.SystemColors.Control
    Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label19.Location = New System.Drawing.Point(347, 35)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(36, 12)
    Me.Label19.TabIndex = 247
    Me.Label19.Text = "Total"
    '
    'FrmTXA01D
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(476, 434)
    Me.Controls.Add(Me.LblTotal)
    Me.Controls.Add(Me.Label19)
    Me.Controls.Add(Me.GrpFees)
    Me.Controls.Add(Me.LblMsg)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.LblDtInt)
    Me.Controls.Add(Me.DtPckInt)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.TxtRef)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LblName)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.LnkInv)
    Me.Controls.Add(Me.LblSeq)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.LblBatch)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtComment)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtType)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.TxtList)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtLien)
    Me.Controls.Add(Me.TxtInterest)
    Me.Controls.Add(Me.TxtPrincipal)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.Label2)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA01D"
    Me.Text = "Electronic Receipts"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GrpFees.ResumeLayout(False)
    Me.GrpFees.PerformLayout()
    Me.GroupBox7.ResumeLayout(False)
    Me.GroupBox7.PerformLayout()
    Me.GroupBox6.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTXA01D_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myTCRBCH = New TCRBCH.MyData(myDBConnect)
    myTXINV = New TXINV.mydata(MyDBConnect)
    MyTXPEN = New TXPEN.mydata(MyDBConnect)

    MyFrmTXA01.TBarNew.Enabled = False
    MyFrmTXA01.TBarSave.Enabled = True
    LblBatch.Text = WrkBatchNo
    LblMsg.Text = ""

    If WrkSeq > 0 Then
      MyFrmTXA01.TBarDelete.Enabled = True
      AddMode = False
    Else
      AddMode = True
      WrkSeq = myTCRBCH.AutoGenKey(WrkBatchNo)
    End If
    LblSeq.Text = WrkSeq
    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      WrkReceiptDate = MyUtils.GetDBDate(._PSDT)
    End With

    myTCRBCH.GetOneRecordP(WrkBatchNo, WrkSeq)
    If myTCRBCH.RecordNotFound Then
      DtPckInt.Value = WrkReceiptDate
      DtPckInt.Checked = False
      Exit Sub
    End If

    With myTCRBCH
      TxtList.Text = ._LISTNo
      TxtType.Text = ._TYPE
      TxtYear.Text = ._YEAR
      TxtDist.Text = ._DIST
      TxtPrincipal.Text = Math.Abs(._PAMT)
      TxtInterest.Text = Math.Abs(._IAMT)
      TxtLien.Text = Math.Abs(._LAMT)
      TxtFee1.Text = Math.Abs(._PCAMT1)
      TxtFee2.Text = Math.Abs(._PCAMT2)
      TxtFee3.Text = Math.Abs(._PCAMT3)
      TxtFee4.Text = Math.Abs(._PCAMT4)
      TxtFee5.Text = Math.Abs(._PCAMT5)
      TxtFee6.Text = Math.Abs(._PCAMT6)
      TxtFee7.Text = Math.Abs(._PCAMT7)
      TxtFeeCd1.Text = Trim(._PENCD1)
      TxtFeeCd2.Text = Trim(._PENCD2)
      TxtFeeCd3.Text = Trim(._PENCD3)
      TxtFeeCd4.Text = Trim(._PENCD4)
      TxtFeeCd5.Text = Trim(._PENCD5)
      TxtFeeCd6.Text = Trim(._PENCD6)
      TxtFeeCd7.Text = Trim(._PENCD7)
      TxtComment.Text = Trim(._COMM)
      LblName.Text = Trim(._NAME)
      TxtRef.Text = Trim(._REF)
      If ._RDTE <> MyUtils.SetDBDate(WrkReceiptDate) And ._RDTE > 0 Then
        DtPckInt.Value = MyUtils.GetDBDate(._RDTE)
        DtPckInt.Checked = True
      Else
        DtPckInt.Value = WrkReceiptDate
        DtPckInt.Checked = False
      End If
      If myBCHHDR._SUBST <> "W" Then
        LblDtInt.Visible = False
        DtPckInt.Visible = False
      End If
      Select Case Trim(._PMETH)
        Case "2"
          RbPayCheck.Checked = True
        Case "3"
          RbPayCredit.Checked = True
      End Select
      Select Case ._ADJ
        Case Is = "A"
          RbTranAdjust.Checked = True
          LblMsg.Text = "Adjustment"
        Case Is = "R"
          RbTranRefund.Checked = True
          LblMsg.Text = "Refund"
        Case Else
          RbTranPayment.Checked = True
      End Select
    End With
    CalcTotal()
  End Sub

  Private Sub FrmTXA01D_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXA01.SbpScreen.Text = "TXA01D"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub FrmTXA01D_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTXA01.TBarNew.Enabled = True
  MyFrmTXA01.TBarDelete.Enabled = False
  MyFrmTXA01.TBarSave.Enabled = False
  MyFrmTXA01C.FormatGrid()
  MyFrmTXA01C.Show()
  'Memory Cleanup
  myTCRBCH = Nothing
  MyFrmTXA01D = Nothing
End Sub
Public Sub DeleteData(ByRef Cancel As Boolean)
  Dim Answer As Integer
  Cancel = False
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Cancel = True
    Exit Sub
  End If

  myTCRBCH.DeleteOneRecordP()
End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myTCRBCH.GetOneRecordP(WrkBatchNo, WrkSeq)
    If Not AddMode Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTCRBCH.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      With myTCRBCH
        ._BCHNO = WrkBatchNo
        ._TRNBR = WrkSeq
      End With
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTCRBCH.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    MyFrmTXA01C.TxtTran.Text = WrkSeq
    Me.Close()
End Sub
Private Sub MovetoFile()
  With myTCRBCH
    ._LISTNo = MyUtils.CnvSng(TxtList.Text)
    ._TYPE = TxtType.Text
    ._YEAR = MyUtils.CnvSng(TxtYear.Text)
    ._NAME = LblName.Text
    ._RDTE = MyUtils.SetDBDate(WrkReceiptDate)
    ._DIST = MyUtils.CnvSng(TxtDist.Text)
    If RbTranPayment.Checked Then
      ._PAMT = MyUtils.CnvSng(TxtPrincipal.Text)
      ._IAMT = MyUtils.CnvSng(TxtInterest.Text)
      ._LAMT = MyUtils.CnvSng(TxtLien.Text)
      ._PCAMT1 = MyUtils.CnvSng(TxtFee1.Text)
      ._PCAMT2 = MyUtils.CnvSng(TxtFee2.Text)
      ._PCAMT3 = MyUtils.CnvSng(TxtFee3.Text)
      ._PCAMT4 = MyUtils.CnvSng(TxtFee4.Text)
      ._PCAMT5 = MyUtils.CnvSng(TxtFee5.Text)
      ._PCAMT6 = MyUtils.CnvSng(TxtFee6.Text)
      ._PCAMT7 = MyUtils.CnvSng(TxtFee7.Text)
    Else
      ._PAMT = MyUtils.CnvSng(TxtPrincipal.Text) * -1
      ._IAMT = MyUtils.CnvSng(TxtInterest.Text) * -1
      ._LAMT = MyUtils.CnvSng(TxtLien.Text) * -1
      ._PCAMT1 = MyUtils.CnvSng(TxtFee1.Text) * -1
      ._PCAMT2 = MyUtils.CnvSng(TxtFee2.Text) * -1
      ._PCAMT3 = MyUtils.CnvSng(TxtFee3.Text) * -1
      ._PCAMT4 = MyUtils.CnvSng(TxtFee4.Text) * -1
      ._PCAMT5 = MyUtils.CnvSng(TxtFee5.Text) * -1
      ._PCAMT6 = MyUtils.CnvSng(TxtFee6.Text) * -1
      ._PCAMT7 = MyUtils.CnvSng(TxtFee7.Text) * -1
    End If
    ._PCAMT = ._PCAMT1 + ._PCAMT2 + ._PCAMT3 + ._PCAMT4 + ._PCAMT5 + ._PCAMT6 + ._PCAMT7
    ._PENCD1 = TxtFeeCd1.Text
    ._PENCD2 = TxtFeeCd2.Text
    ._PENCD3 = TxtFeeCd3.Text
    ._PENCD4 = TxtFeeCd4.Text
    ._PENCD5 = TxtFeeCd5.Text
    ._PENCD6 = TxtFeeCd6.Text
    ._PENCD7 = TxtFeeCd7.Text
    ._COMM = TxtComment.Text
    ._REF = TxtRef.Text
    If myBCHHDR._SUBST = "W" And DtPckInt.Checked Then
      ._RDTE = MyUtils.SetDBDate(DtPckInt.Value)
    Else
      ._RDTE = MyUtils.SetDBDate(WrkReceiptDate)
    End If
    If RbPayCheck.Checked Then ._PMETH = "2"
    If RbPayCredit.Checked Then ._PMETH = "3"
    If RbTranPayment.Checked Then ._ADJ = ""
    If RbTranAdjust.Checked Then ._ADJ = "A"
    If RbTranRefund.Checked Then ._ADJ = "R"
 End With
 End Sub

 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtYear, "")
  ErrProv.SetError(TxtFeeCd1, "")
  ErrProv.SetError(TxtFeeCd2, "")
  ErrProv.SetError(TxtFeeCd3, "")
  ErrProv.SetError(TxtFeeCd4, "")
  ErrProv.SetError(TxtFeeCd5, "")
  ErrProv.SetError(TxtFeeCd6, "")
  ErrProv.SetError(TxtFeeCd7, "")
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
    Case "acct"
      ErrProv.SetError(TxtYear, ErrorMsg(I))
    Case "feecd1"
      ErrProv.SetError(TxtFeeCd1, ErrorMsg(I))
    Case "feecd2"
      ErrProv.SetError(TxtFeeCd2, ErrorMsg(I))
    Case "feecd3"
      ErrProv.SetError(TxtFeeCd3, ErrorMsg(I))
    Case "feecd4"
      ErrProv.SetError(TxtFeeCd4, ErrorMsg(I))
    Case "feecd5"
      ErrProv.SetError(TxtFeeCd5, ErrorMsg(I))
    Case "feecd6"
      ErrProv.SetError(TxtFeeCd6, ErrorMsg(I))
    Case "feecd7"
      ErrProv.SetError(TxtFeeCd7, ErrorMsg(I))
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

    myTXINV.GetOneRecordP(MyUtils.CnvSng(TxtList.Text), MyUtils.CnvSng(TxtYear.Text), _
      TxtType.Text)
    If myTXINV.RecordNotFound Then
      ErrorField(I) = "acct"
      ErrorMsg(I) = "Invalid List/Year/Type"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtFee1.Text) > 0 Then
      MyTXPEN.GetOneRecordP(TxtFeeCd1.Text)
      If MyTXPEN.RecordNotFound Then
        ErrorField(I) = "feecd1"
        ErrorMsg(I) = "Invalid Penalty Code"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtFee2.Text) > 0 Then
      MyTXPEN.GetOneRecordP(TxtFeeCd2.Text)
      If MyTXPEN.RecordNotFound Then
        ErrorField(I) = "feecd2"
        ErrorMsg(I) = "Invalid Penalty Code"
        I = I + 1
      End If
    End If
    If MyUtils.CnvSng(TxtFee3.Text) > 0 Then
      MyTXPEN.GetOneRecordP(TxtFeeCd3.Text)
      If MyTXPEN.RecordNotFound Then
        ErrorField(I) = "feecd3"
        ErrorMsg(I) = "Invalid Penalty Code"
        I = I + 1
      End If
    End If
    If MyUtils.CnvSng(TxtFee4.Text) > 0 Then
      MyTXPEN.GetOneRecordP(TxtFeeCd4.Text)
      If MyTXPEN.RecordNotFound Then
        ErrorField(I) = "feecd4"
        ErrorMsg(I) = "Invalid Penalty Code"
        I = I + 1
      End If
    End If
    If MyUtils.CnvSng(TxtFee5.Text) > 0 Then
      MyTXPEN.GetOneRecordP(TxtFeeCd5.Text)
      If MyTXPEN.RecordNotFound Then
        ErrorField(I) = "feecd5"
        ErrorMsg(I) = "Invalid Penalty Code"
        I = I + 1
      End If
    End If
    If MyUtils.CnvSng(TxtFee6.Text) > 0 Then
      MyTXPEN.GetOneRecordP(TxtFeeCd6.Text)
      If MyTXPEN.RecordNotFound Then
        ErrorField(I) = "feecd6"
        ErrorMsg(I) = "Invalid Penalty Code"
        I = I + 1
      End If
    End If
    If MyUtils.CnvSng(TxtFee7.Text) > 0 Then
      MyTXPEN.GetOneRecordP(TxtFeeCd7.Text)
      If MyTXPEN.RecordNotFound Then
        ErrorField(I) = "feecd7"
        ErrorMsg(I) = "Invalid Penalty Code"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtFee1.Text) = 0 And Trim(TxtFeeCd1.Text) <> "" Then
      ErrorField(I) = "feecd1"
      ErrorMsg(I) = "Missing amount for Penalty Code"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtFee2.Text) = 0 And Trim(TxtFeeCd2.Text) <> "" Then
      ErrorField(I) = "feecd2"
      ErrorMsg(I) = "Missing amount for Penalty Code"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtFee3.Text) = 0 And Trim(TxtFeeCd3.Text) <> "" Then
      ErrorField(I) = "feecd3"
      ErrorMsg(I) = "Missing amount for Penalty Code"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtFee4.Text) = 0 And Trim(TxtFeeCd4.Text) <> "" Then
      ErrorField(I) = "feecd4"
      ErrorMsg(I) = "Missing amount for Penalty Code"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtFee5.Text) = 0 And Trim(TxtFeeCd5.Text) <> "" Then
      ErrorField(I) = "feecd5"
      ErrorMsg(I) = "Missing amount for Penalty Code"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtFee6.Text) = 0 And Trim(TxtFeeCd6.Text) <> "" Then
      ErrorField(I) = "feecd6"
      ErrorMsg(I) = "Missing amount for Penalty Code"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtFee7.Text) = 0 And Trim(TxtFeeCd7.Text) <> "" Then
      ErrorField(I) = "feecd7"
      ErrorMsg(I) = "Missing amount for Penalty Code"
      I = I + 1
    End If
  End Sub
Private Sub TxtList_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtList.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub Txtdist_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
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
Private Sub TxtFee6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFee6.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtFee7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFee7.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub LnkInv_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkInv.LinkClicked
  If TxtType.Text = "" Then
    MsgBox("Type is required for searching", MsgBoxStyle.Information, "Type missing")
    Exit Sub
  End If

  MyFrmListInv = New FrmListInv
  MyFrmListInv.MdiParent = Me.ParentForm
  MyFrmListInv.WrkType = TxtType.Text
  MyFrmListInv.WrkName = LblName.Text
  MyFrmListInv.Show()
End Sub

Private Sub TxtYear_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtYear.Leave
    myTXINV.GetOneRecordP(MyUtils.CnvSng(TxtList.Text), MyUtils.CnvSng(TxtYear.Text), _
      TxtType.Text)
    If Not myTXINV.RecordNotFound Then
      LblName.Text = Trim(myTXINV._NAME)
    Else
      LblName.Text = "*** Invalid account ***"
    End If
End Sub

Private Sub TxtYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtYear.TextChanged

End Sub

Private Sub LnkFeeCd1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFeeCd1.LinkClicked
  MyFrmListPenCd = New FrmListPenCd
  MyFrmListPenCd.MdiParent = Me.ParentForm
  MyFrmListPenCd.WrkCode = TxtFeeCd1.Text
  MyFrmListPenCd.WrkField = "1"
  MyFrmListPenCd.Show()
  Me.Hide()
End Sub
Private Sub LnkFeeCd2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFeeCd2.LinkClicked
  MyFrmListPenCd = New FrmListPenCd
  MyFrmListPenCd.MdiParent = Me.ParentForm
  MyFrmListPenCd.WrkCode = TxtFeeCd2.Text
  MyFrmListPenCd.WrkField = "2"
  MyFrmListPenCd.Show()
  Me.Hide()
End Sub
Private Sub LnkFeeCd3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFeeCd3.LinkClicked
  MyFrmListPenCd = New FrmListPenCd
  MyFrmListPenCd.MdiParent = Me.ParentForm
  MyFrmListPenCd.WrkCode = TxtFeeCd3.Text
  MyFrmListPenCd.WrkField = "3"
  MyFrmListPenCd.Show()
  Me.Hide()
End Sub
Private Sub LnkFeeCd4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFeeCd4.LinkClicked
  MyFrmListPenCd = New FrmListPenCd
  MyFrmListPenCd.MdiParent = Me.ParentForm
  MyFrmListPenCd.WrkCode = TxtFeeCd4.Text
  MyFrmListPenCd.WrkField = "4"
  MyFrmListPenCd.Show()
  Me.Hide()
End Sub
Private Sub LnkFeeCd5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFeeCd5.LinkClicked
  MyFrmListPenCd = New FrmListPenCd
  MyFrmListPenCd.MdiParent = Me.ParentForm
  MyFrmListPenCd.WrkCode = TxtFeeCd5.Text
  MyFrmListPenCd.WrkField = "5"
  MyFrmListPenCd.Show()
  Me.Hide()
End Sub
Private Sub LnkFeeCd6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFeeCd6.LinkClicked
  MyFrmListPenCd = New FrmListPenCd
  MyFrmListPenCd.MdiParent = Me.ParentForm
  MyFrmListPenCd.WrkCode = TxtFeeCd6.Text
  MyFrmListPenCd.WrkField = "6"
  MyFrmListPenCd.Show()
  Me.Hide()
End Sub
Private Sub LnkFeeCd7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFeeCd7.LinkClicked
  MyFrmListPenCd = New FrmListPenCd
  MyFrmListPenCd.MdiParent = Me.ParentForm
  MyFrmListPenCd.WrkCode = TxtFeeCd7.Text
  MyFrmListPenCd.WrkField = "7"
  MyFrmListPenCd.Show()
  Me.Hide()
End Sub
  Private Sub RbTranPayment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbTranPayment.Click
    LblMsg.Text = ""
  End Sub
  Private Sub RbTranAdjust_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbTranAdjust.Click, RadioButton10.Click
    LblMsg.Text = "Adjustment"
  End Sub
  Private Sub RbTranRefund_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbTranRefund.Click
    LblMsg.Text = "Refund"
  End Sub
Private Sub TxtPrincipal_TextChanged(sender As Object, e As EventArgs) Handles TxtPrincipal.TextChanged
  CalcTotal()
End Sub
Private Sub TxtInterest_TextChanged(sender As Object, e As EventArgs) Handles TxtInterest.TextChanged
  CalcTotal()
End Sub
Private Sub TxtLien_TextChanged(sender As Object, e As EventArgs) Handles TxtLien.TextChanged
  CalcTotal()
End Sub
Private Sub TxtFee1_TextChanged(sender As Object, e As EventArgs) Handles TxtFee1.TextChanged
  CalcTotal()
End Sub
Private Sub TxtFee2_TextChanged(sender As Object, e As EventArgs) Handles TxtFee2.TextChanged
  CalcTotal()
End Sub
Private Sub TxtFee3_TextChanged(sender As Object, e As EventArgs) Handles TxtFee3.TextChanged
  CalcTotal()
End Sub
Private Sub TxtFee4_TextChanged(sender As Object, e As EventArgs) Handles TxtFee4.TextChanged
  CalcTotal()
End Sub
Private Sub TxtFee5_TextChanged(sender As Object, e As EventArgs) Handles TxtFee5.TextChanged
  CalcTotal()
End Sub
Private Sub TxtFee6_TextChanged(sender As Object, e As EventArgs) Handles TxtFee6.TextChanged
  CalcTotal()
End Sub
Private Sub TxtFee7_TextChanged(sender As Object, e As EventArgs) Handles TxtFee7.TextChanged
  CalcTotal()
End Sub
Private Sub CalcTotal()
  Dim WrkTotal As Decimal

  WrkTotal = MyUtils.CnvSng(TxtPrincipal.Text) + MyUtils.CnvSng(TxtInterest.Text) + MyUtils.CnvSng(TxtLien.Text) + _
    MyUtils.CnvSng(TxtFee1.Text) + MyUtils.CnvSng(TxtFee2.Text) + MyUtils.CnvSng(TxtFee3.Text) + _
    MyUtils.CnvSng(TxtFee4.Text) + MyUtils.CnvSng(TxtFee5.Text) + MyUtils.CnvSng(TxtFee6.Text) + _
    MyUtils.CnvSng(TxtFee7.Text)
  LblTotal.Text = Format(WrkTotal, "fixed")
End Sub
End Class






