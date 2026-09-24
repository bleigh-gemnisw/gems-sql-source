Public Class FrmGL403D

  Inherits System.Windows.Forms.Form
  Dim myBCHHDR As BCHHDR.MyData
  Dim myGLRBCH As GLRBCH.MyData
  Dim myGLRBCHL1 As GLRBCHL1.MyData
  Dim myGLACCT As GLACCT.MyData
  Dim ds As DataSet = New DataSet
  Friend WithEvents LblDebit As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents LblCredit As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WrkBatchNo As Integer
  Friend WrkBatchDate As Integer
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents LblTran As System.Windows.Forms.Label
  Friend WithEvents GrpType As System.Windows.Forms.GroupBox
  Friend WithEvents RbOrig As System.Windows.Forms.RadioButton
  Friend WithEvents RbTransfer As System.Windows.Forms.RadioButton
  Friend WithEvents RbEncumb As System.Windows.Forms.RadioButton
  Friend WithEvents RbBudget As System.Windows.Forms.RadioButton
  Friend WithEvents RbAdjust As System.Windows.Forms.RadioButton
  Friend WithEvents TxtPrj As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents LnkGLAcct As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtSfcn As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents RbDebit As System.Windows.Forms.RadioButton
  Friend WithEvents RbCredit As System.Windows.Forms.RadioButton
  Friend WithEvents TxtFcn As System.Windows.Forms.TextBox
  Friend WithEvents TxtRef As System.Windows.Forms.TextBox
  Friend WithEvents TxtObj As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TxtDept As System.Windows.Forms.TextBox
  Friend WithEvents TxtSFund As System.Windows.Forms.TextBox
  Friend WithEvents TxtFund As System.Windows.Forms.TextBox
  Friend WithEvents TxtDescr As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents TxtAmount As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents LblTrnType As System.Windows.Forms.Label
  Friend WithEvents LblSeq As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents BtnRemDtl As System.Windows.Forms.Button
  Friend WithEvents BtnAddDtl As System.Windows.Forms.Button
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WrkTran As Integer
  Friend WithEvents LblEnter As System.Windows.Forms.Label
  Friend WithEvents LblDtEnter As Label
  Dim WrkTrnType As String

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
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGL403D))
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LblDebit = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.LblCredit = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.LblTran = New System.Windows.Forms.Label()
    Me.GrpType = New System.Windows.Forms.GroupBox()
    Me.RbOrig = New System.Windows.Forms.RadioButton()
    Me.RbTransfer = New System.Windows.Forms.RadioButton()
    Me.RbEncumb = New System.Windows.Forms.RadioButton()
    Me.RbBudget = New System.Windows.Forms.RadioButton()
    Me.RbAdjust = New System.Windows.Forms.RadioButton()
    Me.TxtPrj = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.LnkGLAcct = New System.Windows.Forms.LinkLabel()
    Me.TxtSfcn = New System.Windows.Forms.TextBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbDebit = New System.Windows.Forms.RadioButton()
    Me.RbCredit = New System.Windows.Forms.RadioButton()
    Me.TxtFcn = New System.Windows.Forms.TextBox()
    Me.TxtRef = New System.Windows.Forms.TextBox()
    Me.TxtObj = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtDept = New System.Windows.Forms.TextBox()
    Me.TxtSFund = New System.Windows.Forms.TextBox()
    Me.TxtFund = New System.Windows.Forms.TextBox()
    Me.TxtDescr = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtAmount = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.LblTrnType = New System.Windows.Forms.Label()
    Me.LblSeq = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.BtnRemDtl = New System.Windows.Forms.Button()
    Me.BtnAddDtl = New System.Windows.Forms.Button()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.LblEnter = New System.Windows.Forms.Label()
    Me.LblDtEnter = New System.Windows.Forms.Label()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpType.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColMove = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AllowUpdate = False
    Me.C1DataGrdList.AlternatingRows = True
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(12, 56)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    Me.C1DataGrdList.RowHeight = 16
    Me.C1DataGrdList.Size = New System.Drawing.Size(564, 169)
    Me.C1DataGrdList.TabIndex = 8
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    '
    'LblDebit
    '
    Me.LblDebit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblDebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDebit.Location = New System.Drawing.Point(493, 9)
    Me.LblDebit.Name = "LblDebit"
    Me.LblDebit.Size = New System.Drawing.Size(79, 18)
    Me.LblDebit.TabIndex = 223
    Me.LblDebit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(417, 9)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(70, 16)
    Me.Label6.TabIndex = 224
    Me.Label6.Text = "Total Debit"
    '
    'LblCredit
    '
    Me.LblCredit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCredit.Location = New System.Drawing.Point(493, 27)
    Me.LblCredit.Name = "LblCredit"
    Me.LblCredit.Size = New System.Drawing.Size(79, 18)
    Me.LblCredit.TabIndex = 221
    Me.LblCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(417, 27)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(70, 15)
    Me.Label3.TabIndex = 222
    Me.Label3.Text = "Total Credit"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(12, 6)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(29, 13)
    Me.Label2.TabIndex = 225
    Me.Label2.Text = "Tran"
    '
    'LblTran
    '
    Me.LblTran.AutoSize = True
    Me.LblTran.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTran.Location = New System.Drawing.Point(47, 6)
    Me.LblTran.Name = "LblTran"
    Me.LblTran.Size = New System.Drawing.Size(41, 13)
    Me.LblTran.TabIndex = 226
    Me.LblTran.Text = "<Tran>"
    '
    'GrpType
    '
    Me.GrpType.Controls.Add(Me.RbOrig)
    Me.GrpType.Controls.Add(Me.RbTransfer)
    Me.GrpType.Controls.Add(Me.RbEncumb)
    Me.GrpType.Controls.Add(Me.RbBudget)
    Me.GrpType.Controls.Add(Me.RbAdjust)
    Me.GrpType.Location = New System.Drawing.Point(422, 231)
    Me.GrpType.Name = "GrpType"
    Me.GrpType.Size = New System.Drawing.Size(156, 136)
    Me.GrpType.TabIndex = 254
    Me.GrpType.TabStop = False
    '
    'RbOrig
    '
    Me.RbOrig.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbOrig.Location = New System.Drawing.Point(6, 107)
    Me.RbOrig.Name = "RbOrig"
    Me.RbOrig.Size = New System.Drawing.Size(144, 22)
    Me.RbOrig.TabIndex = 250
    Me.RbOrig.Text = "Z = Original Budget"
    Me.RbOrig.UseVisualStyleBackColor = True
    '
    'RbTransfer
    '
    Me.RbTransfer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbTransfer.Location = New System.Drawing.Point(6, 83)
    Me.RbTransfer.Name = "RbTransfer"
    Me.RbTransfer.Size = New System.Drawing.Size(144, 22)
    Me.RbTransfer.TabIndex = 249
    Me.RbTransfer.Text = "T = Transfer of Budget"
    Me.RbTransfer.UseVisualStyleBackColor = True
    '
    'RbEncumb
    '
    Me.RbEncumb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbEncumb.Location = New System.Drawing.Point(6, 59)
    Me.RbEncumb.Name = "RbEncumb"
    Me.RbEncumb.Size = New System.Drawing.Size(144, 22)
    Me.RbEncumb.TabIndex = 248
    Me.RbEncumb.Text = "E = Encumbrance"
    Me.RbEncumb.UseVisualStyleBackColor = True
    '
    'RbBudget
    '
    Me.RbBudget.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbBudget.Location = New System.Drawing.Point(6, 35)
    Me.RbBudget.Name = "RbBudget"
    Me.RbBudget.Size = New System.Drawing.Size(144, 22)
    Me.RbBudget.TabIndex = 247
    Me.RbBudget.Text = "B = Budget Adjustment"
    Me.RbBudget.UseVisualStyleBackColor = True
    '
    'RbAdjust
    '
    Me.RbAdjust.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbAdjust.Checked = True
    Me.RbAdjust.Location = New System.Drawing.Point(6, 11)
    Me.RbAdjust.Name = "RbAdjust"
    Me.RbAdjust.Size = New System.Drawing.Size(144, 22)
    Me.RbAdjust.TabIndex = 246
    Me.RbAdjust.TabStop = True
    Me.RbAdjust.Text = "X = Adjustment"
    Me.RbAdjust.UseVisualStyleBackColor = True
    '
    'TxtPrj
    '
    Me.TxtPrj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPrj.Location = New System.Drawing.Point(212, 301)
    Me.TxtPrj.MaxLength = 10
    Me.TxtPrj.Name = "TxtPrj"
    Me.TxtPrj.Size = New System.Drawing.Size(76, 20)
    Me.TxtPrj.TabIndex = 252
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(167, 305)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(40, 13)
    Me.Label4.TabIndex = 257
    Me.Label4.Text = "Project"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LnkGLAcct
    '
    Me.LnkGLAcct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcct.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcct.Location = New System.Drawing.Point(12, 248)
    Me.LnkGLAcct.Name = "LnkGLAcct"
    Me.LnkGLAcct.Size = New System.Drawing.Size(36, 18)
    Me.LnkGLAcct.TabIndex = 249
    Me.LnkGLAcct.TabStop = True
    Me.LnkGLAcct.Text = "Acct"
    '
    'TxtSfcn
    '
    Me.TxtSfcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfcn.Location = New System.Drawing.Point(273, 244)
    Me.TxtSfcn.MaxLength = 4
    Me.TxtSfcn.Name = "TxtSfcn"
    Me.TxtSfcn.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfcn.TabIndex = 246
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbDebit)
    Me.GroupBox2.Controls.Add(Me.RbCredit)
    Me.GroupBox2.Location = New System.Drawing.Point(16, 324)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(178, 37)
    Me.GroupBox2.TabIndex = 253
    Me.GroupBox2.TabStop = False
    '
    'RbDebit
    '
    Me.RbDebit.AutoSize = True
    Me.RbDebit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbDebit.Checked = True
    Me.RbDebit.Location = New System.Drawing.Point(8, 14)
    Me.RbDebit.Name = "RbDebit"
    Me.RbDebit.Size = New System.Drawing.Size(50, 17)
    Me.RbDebit.TabIndex = 2
    Me.RbDebit.TabStop = True
    Me.RbDebit.Text = "Debit"
    Me.RbDebit.UseVisualStyleBackColor = True
    '
    'RbCredit
    '
    Me.RbCredit.AutoSize = True
    Me.RbCredit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbCredit.Location = New System.Drawing.Point(105, 14)
    Me.RbCredit.Name = "RbCredit"
    Me.RbCredit.Size = New System.Drawing.Size(52, 17)
    Me.RbCredit.TabIndex = 3
    Me.RbCredit.Text = "Credit"
    Me.RbCredit.UseVisualStyleBackColor = True
    '
    'TxtFcn
    '
    Me.TxtFcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFcn.Location = New System.Drawing.Point(222, 244)
    Me.TxtFcn.MaxLength = 4
    Me.TxtFcn.Name = "TxtFcn"
    Me.TxtFcn.Size = New System.Drawing.Size(45, 22)
    Me.TxtFcn.TabIndex = 245
    '
    'TxtRef
    '
    Me.TxtRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRef.Location = New System.Drawing.Point(93, 301)
    Me.TxtRef.MaxLength = 7
    Me.TxtRef.Name = "TxtRef"
    Me.TxtRef.Size = New System.Drawing.Size(56, 20)
    Me.TxtRef.TabIndex = 251
    '
    'TxtObj
    '
    Me.TxtObj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObj.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObj.Location = New System.Drawing.Point(186, 244)
    Me.TxtObj.MaxLength = 3
    Me.TxtObj.Name = "TxtObj"
    Me.TxtObj.Size = New System.Drawing.Size(32, 22)
    Me.TxtObj.TabIndex = 244
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(17, 305)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(57, 13)
    Me.Label5.TabIndex = 256
    Me.Label5.Text = "Reference"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtDept
    '
    Me.TxtDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDept.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDept.Location = New System.Drawing.Point(135, 244)
    Me.TxtDept.MaxLength = 4
    Me.TxtDept.Name = "TxtDept"
    Me.TxtDept.Size = New System.Drawing.Size(45, 22)
    Me.TxtDept.TabIndex = 243
    '
    'TxtSFund
    '
    Me.TxtSFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSFund.Location = New System.Drawing.Point(97, 244)
    Me.TxtSFund.MaxLength = 3
    Me.TxtSFund.Name = "TxtSFund"
    Me.TxtSFund.Size = New System.Drawing.Size(32, 22)
    Me.TxtSFund.TabIndex = 242
    '
    'TxtFund
    '
    Me.TxtFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFund.Location = New System.Drawing.Point(59, 244)
    Me.TxtFund.MaxLength = 3
    Me.TxtFund.Name = "TxtFund"
    Me.TxtFund.Size = New System.Drawing.Size(32, 22)
    Me.TxtFund.TabIndex = 241
    '
    'TxtDescr
    '
    Me.TxtDescr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDescr.Location = New System.Drawing.Point(225, 274)
    Me.TxtDescr.MaxLength = 30
    Me.TxtDescr.Name = "TxtDescr"
    Me.TxtDescr.Size = New System.Drawing.Size(191, 20)
    Me.TxtDescr.TabIndex = 248
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(158, 275)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(60, 13)
    Me.Label7.TabIndex = 255
    Me.Label7.Text = "Description"
    Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtAmount
    '
    Me.TxtAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAmount.Location = New System.Drawing.Point(69, 272)
    Me.TxtAmount.MaxLength = 10
    Me.TxtAmount.Name = "TxtAmount"
    Me.TxtAmount.Size = New System.Drawing.Size(80, 20)
    Me.TxtAmount.TabIndex = 247
    Me.TxtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(17, 278)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(43, 13)
    Me.Label8.TabIndex = 250
    Me.Label8.Text = "Amount"
    Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblTrnType
    '
    Me.LblTrnType.AutoSize = True
    Me.LblTrnType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTrnType.Location = New System.Drawing.Point(17, 32)
    Me.LblTrnType.Name = "LblTrnType"
    Me.LblTrnType.Size = New System.Drawing.Size(68, 13)
    Me.LblTrnType.TabIndex = 258
    Me.LblTrnType.Text = "<TrnType>"
    Me.LblTrnType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblSeq
    '
    Me.LblSeq.AutoSize = True
    Me.LblSeq.Location = New System.Drawing.Point(241, 338)
    Me.LblSeq.Name = "LblSeq"
    Me.LblSeq.Size = New System.Drawing.Size(38, 13)
    Me.LblSeq.TabIndex = 260
    Me.LblSeq.Text = "<Seq>"
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(209, 338)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(32, 14)
    Me.Label10.TabIndex = 259
    Me.Label10.Text = "Seq"
    '
    'BtnRemDtl
    '
    Me.BtnRemDtl.Location = New System.Drawing.Point(319, 358)
    Me.BtnRemDtl.Name = "BtnRemDtl"
    Me.BtnRemDtl.Size = New System.Drawing.Size(81, 22)
    Me.BtnRemDtl.TabIndex = 455
    Me.BtnRemDtl.TabStop = False
    Me.BtnRemDtl.Text = "Remove Item"
    Me.BtnRemDtl.UseVisualStyleBackColor = True
    '
    'BtnAddDtl
    '
    Me.BtnAddDtl.Location = New System.Drawing.Point(232, 358)
    Me.BtnAddDtl.Name = "BtnAddDtl"
    Me.BtnAddDtl.Size = New System.Drawing.Size(81, 22)
    Me.BtnAddDtl.TabIndex = 454
    Me.BtnAddDtl.TabStop = False
    Me.BtnAddDtl.Text = "Add Item"
    Me.BtnAddDtl.UseVisualStyleBackColor = True
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblEnter
    '
    Me.LblEnter.AutoSize = True
    Me.LblEnter.Location = New System.Drawing.Point(294, 305)
    Me.LblEnter.Name = "LblEnter"
    Me.LblEnter.Size = New System.Drawing.Size(30, 13)
    Me.LblEnter.TabIndex = 457
    Me.LblEnter.Text = "Date"
    Me.LblEnter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblDtEnter
    '
    Me.LblDtEnter.AutoSize = True
    Me.LblDtEnter.Location = New System.Drawing.Point(330, 305)
    Me.LblDtEnter.Name = "LblDtEnter"
    Me.LblDtEnter.Size = New System.Drawing.Size(42, 13)
    Me.LblDtEnter.TabIndex = 458
    Me.LblDtEnter.Text = "<Date>"
    Me.LblDtEnter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'FrmGL403D
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(586, 392)
    Me.Controls.Add(Me.LblDtEnter)
    Me.Controls.Add(Me.LblEnter)
    Me.Controls.Add(Me.BtnRemDtl)
    Me.Controls.Add(Me.BtnAddDtl)
    Me.Controls.Add(Me.LblSeq)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.LblTrnType)
    Me.Controls.Add(Me.GrpType)
    Me.Controls.Add(Me.TxtPrj)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.LnkGLAcct)
    Me.Controls.Add(Me.TxtSfcn)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.TxtFcn)
    Me.Controls.Add(Me.TxtRef)
    Me.Controls.Add(Me.TxtObj)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtDept)
    Me.Controls.Add(Me.TxtSFund)
    Me.Controls.Add(Me.TxtFund)
    Me.Controls.Add(Me.TxtDescr)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtAmount)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.LblTran)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.LblDebit)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.LblCredit)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL403D"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Batch"
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpType.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmGL403B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myGLRBCH = New GLRBCH.MyData()
    myGLRBCH.MyDBConn = myDBConnect
    myGLRBCHL1 = New GLRBCHL1.MyData()
    myGLRBCHL1.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    With MyFrmGL403
      .TBarNew.Enabled = False
      .TBarDelete.Enabled = False
      .TBarDelete.Text = "Delete"
      .TBarPrtEdits.Enabled = False
      .TBarPost.Enabled = False
    End With
    BtnRemDtl.Enabled = False

    Me.Text = Me.Text & " " & WrkBatchNo
    If WrkTran > 0 Then
      LblTran.Text = WrkTran
    Else
      LblTran.Text = ""
    End If
    LblTrnType.Text = ""
    LblSeq.Text = ""
    LblDtEnter.Text = ""
    Call FormatGrid()
    If C1DataGrdList.VisibleRows > 0 Then
      GrpType.Visible = False
    End If
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    FormatGrid()
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()
    With C1DataGrdList
      .Rebind(True)
      .Splits(0).DisplayColumns(0).Visible = False
      .Columns(1).Caption = "Seq #"
      .Splits(0).DisplayColumns(1).Width = 40
      .Columns(2).Caption = "Fund"
      .Splits(0).DisplayColumns(2).Width = 40
      .Columns(3).Caption = "SFund"
      .Splits(0).DisplayColumns(3).Width = 40
      .Columns(4).Caption = "Dept"
      .Splits(0).DisplayColumns(4).Width = 40
      .Columns(5).Caption = "Obj"
      .Splits(0).DisplayColumns(5).Width = 40
      .Columns(6).Caption = "Func"
      .Splits(0).DisplayColumns(6).Width = 40
      .Columns(7).Caption = "Subfn"
      .Splits(0).DisplayColumns(7).Width = 40
      .Columns(8).Caption = "Amount"
      .Splits(0).DisplayColumns(8).Width = 60
      .Columns(9).Caption = "Type"
      .Columns(9).ValueItems.Values.Clear()
      .Columns(9).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("B", "Budget"))
      .Columns(9).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("E", "Encumbrance"))
      .Columns(9).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("T", "Transfer"))
      .Columns(9).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("X", "Adjustment"))
      .Columns(9).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("Z", "Orig Bud"))
      .Columns(9).ValueItems.Translate = True
      .Splits(0).DisplayColumns(9).Width = 60
      .Columns(10).Caption = ""
      .Columns(10).ValueItems.Values.Clear()
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("C", "Credit"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("D", "Debit"))
      .Columns(10).ValueItems.Translate = True
      .Splits(0).DisplayColumns(10).Width = 50
      .Splits(0).DisplayColumns(11).Visible = False 'Date
    End With
  End Sub
  Public Sub ShowGrid()
    Dim WrkCredit As Decimal
    Dim WrkDebit As Decimal
    Dim I As Integer
    ds = myGLRBCHL1.GetViewbyBatch(WrkBatchNo, WrkTran, 9999)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

    For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
      If C1DataGrdList.Item(I, 10) = "C" Then
        WrkCredit = WrkCredit + C1DataGrdList.Item(I, 8)
      Else
        WrkDebit = WrkDebit + C1DataGrdList.Item(I, 8)
      End If
    Next
    LblCredit.Text = Format(WrkCredit, "fixed")
    LblDebit.Text = Format(WrkDebit, "fixed")
  End Sub
  Private Sub FrmGL403D_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGL403.SbpScreen.Text = "GL403D"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub C1DataGrdList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    If C1DataGrdList.Item(C1DataGrdList.Row, 1) > 0 Then
      LblSeq.Text = C1DataGrdList.Item(C1DataGrdList.Row, 1)
      TxtFund.Text = C1DataGrdList.Item(C1DataGrdList.Row, 2)
      TxtSFund.Text = C1DataGrdList.Item(C1DataGrdList.Row, 3)
      TxtDept.Text = C1DataGrdList.Item(C1DataGrdList.Row, 4)
      TxtObj.Text = C1DataGrdList.Item(C1DataGrdList.Row, 5)
      TxtFcn.Text = C1DataGrdList.Item(C1DataGrdList.Row, 6)
      TxtSfcn.Text = C1DataGrdList.Item(C1DataGrdList.Row, 7)
      TxtAmount.Text = C1DataGrdList.Item(C1DataGrdList.Row, 8)
      LblDtEnter.Text = Format(MyUtils.GetDBDateMDY(WrkBatchDate), "M/d/yyyy")
      If C1DataGrdList.Item(C1DataGrdList.Row, 10) = "D" Then
        RbDebit.Checked = True
      Else
        RbCredit.Checked = True
      End If
      With myGLRBCH
        .GetOneRecordP(WrkBatchNo, WrkTran, C1DataGrdList.Item(C1DataGrdList.Row, 1))
        TxtDescr.Text = Trim(._DESCR)
        If ._PRJ > 0 Then
          TxtPrj.Text = ._PRJ
        End If
        If ._REFNO > 0 Then
          TxtRef.Text = ._REFNO
        End If
      End With
      BtnAddDtl.Text = "Update Item"
      BtnRemDtl.Enabled = True
    End If
  End Sub
  Private Sub FrmGL403D_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    With MyFrmGL403
      .TBarNew.Text = "New"
      .TBarNew.Enabled = True
      .TBarDelete.Text = "Delete"
      .TBarDelete.Enabled = True
      .TBarPrtEdits.Enabled = False
      .TBarPost.Enabled = False
    End With
    MyFrmGL403C.FormatGrid()
    MyFrmGL403C.Show()

  End Sub
  Private Sub CalcTotals(ByRef WrkCredit As Decimal, ByRef WrkDebit As Decimal)
    Dim Ds As DataSet = New DataSet
    Dim I As Integer

    Ds = myGLRBCHL1.GetViewbyBatch(WrkBatchNo, WrkTran, 9999)
    For I = 0 To Ds.Tables(0).Rows.Count - 1
      If Ds.Tables(0).Rows(I).Item("amttyp") = "C" Then
        WrkCredit = WrkCredit + Ds.Tables(0).Rows(I).Item("amt")
      Else
        WrkDebit = WrkDebit + Ds.Tables(0).Rows(I).Item("amt")
      End If
    Next
  End Sub
  Public Sub SaveDtl()
    Dim WrkSeq As Integer
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    If WrkTran = 0 Then
      WrkTran = myGLRBCH.AutoGenTran(WrkBatchNo)
    End If
    WrkSeq = MyUtils.CnvSng(LblSeq.Text)
    If WrkSeq = 0 Then
      WrkSeq = myGLRBCH.AutoGenSeq(WrkBatchNo, WrkTran)
    End If
    myGLRBCH.GetOneRecordP(WrkBatchNo, WrkTran, WrkSeq)
    myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFund.Text), MyUtils.CnvSng(TxtSFund.Text), MyUtils.CnvSng(TxtDept.Text),
    MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFcn.Text), MyUtils.CnvSng(TxtSfcn.Text))
    If Not myGLRBCH.RecordNotFound Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myGLRBCH.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      With myGLRBCH
        ._BCHNO = WrkBatchNo
        ._TRNBR = WrkTran
        ._JRNSEQ = WrkSeq
        ._TRNTYP = WrkTrnType
      End With
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myGLRBCH.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    TxtFund.Text = ""
    TxtSFund.Text = ""
    TxtDept.Text = ""
    TxtObj.Text = ""
    TxtFcn.Text = ""
    TxtSfcn.Text = ""
    TxtAmount.Text = ""
    TxtPrj.Text = ""
    TxtRef.Text = ""
    LblSeq.Text = ""
    FormatGrid()
    BtnAddDtl.Text = "Add Item"
    BtnRemDtl.Enabled = False
    GrpType.Visible = False
  End Sub
  Private Sub MovetoFile()
    With myGLRBCH
      ._AMT = MyUtils.CnvSng(TxtAmount.Text)
      ._FDNBR = MyUtils.CnvSng(TxtFund.Text)
      ._SFUND = MyUtils.CnvSng(TxtSFund.Text)
      ._DPNBR = MyUtils.CnvSng(TxtDept.Text)
      ._OBNBR = MyUtils.CnvSng(TxtObj.Text)
      ._FNPGM = MyUtils.CnvSng(TxtFcn.Text)
      ._SUBFN = MyUtils.CnvSng(TxtSfcn.Text)
      ._DESCR = TxtDescr.Text
      ._JACT8 = MyUtils.SetDBDate(MyUtils.GetDBDateMDY(WrkBatchDate))
      ._JENT8 = MyUtils.SetDBDate(MyUtils.GetDBDateMDY(WrkBatchDate))
      If GrpType.Visible Then
        If RbAdjust.Checked Then ._TRNTYP = "X"
        If RbBudget.Checked Then ._TRNTYP = "B"
        If RbEncumb.Checked Then ._TRNTYP = "E"
        If RbOrig.Checked Then ._TRNTYP = "Z"
        If RbTransfer.Checked Then ._TRNTYP = "T"
      Else
        ._TRNTYP = C1DataGrdList.Item(0, 9)
      End If
      ._GLTYP = myGLACCT._GLTYP
      ._REFNO = MyUtils.CnvSng(TxtRef.Text)
      ._PRJ = MyUtils.CnvSng(TxtPrj.Text)
      If RbCredit.Checked Then
        ._AMTTYP = "C"
        ._TOTCR = MyUtils.CnvSng(TxtAmount.Text)
        ._TOTDR = 0
      End If
      If RbDebit.Checked Then
        ._AMTTYP = "D"
        ._TOTDR = MyUtils.CnvSng(TxtAmount.Text)
        ._TOTCR = 0
      End If
    End With
  End Sub

  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFund, "")
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "acct"
          ErrProv.SetError(TxtFund, ErrorMsg(I))
        Case "desc"
          ErrProv.SetError(TxtDescr, ErrorMsg(I))
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

    myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFund.Text), MyUtils.CnvSng(TxtSFund.Text), MyUtils.CnvSng(TxtDept.Text),
      MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFcn.Text), MyUtils.CnvSng(TxtSfcn.Text))
    If myGLACCT.RecordNotFound Then
      ErrorField(I) = "acct"
      ErrorMsg(I) = "Acct is invalid"
      I = I + 1
    Else
      If Trim(myGLACCT._ACREC) = "I" Then
        ErrorField(I) = "acct"
        ErrorMsg(I) = "Acct is inactive"
        I = I + 1
      End If
      If Trim(myGLACCT._GLTYP) = "H" Then
        ErrorField(I) = "acct"
        ErrorMsg(I) = "Acct is header"
        I = I + 1
      End If
    End If
    If InStr(TxtDescr.Text, "'") Then
      ErrorField(I) = "desc"
      ErrorMsg(I) = "Cannot have a Quote in Description"
      I = I + 1
    End If
  End Sub
  Public Sub DeleteDtl()
    Dim WrkSeq As Integer
    Dim Answer As Integer
    WrkSeq = MyUtils.CnvSng(LblSeq.Text)
    If MyUtils.CnvSng(TxtFund.Text) = 0 Then Exit Sub

    Answer = MsgBox("Remove item " & WrkSeq & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Remove")
    If Answer = vbNo Then
      Exit Sub
    End If

    myGLRBCH.GetOneRecordP(WrkBatchNo, WrkTran, WrkSeq)
    myGLRBCH.DeleteOneRecordP()
    TxtFund.Text = ""
    TxtSFund.Text = ""
    TxtDept.Text = ""
    TxtObj.Text = ""
    TxtFcn.Text = ""
    TxtSfcn.Text = ""
    TxtAmount.Text = ""
    TxtDescr.Text = ""
    TxtPrj.Text = ""
    TxtRef.Text = ""
    FormatGrid()
    BtnAddDtl.Text = "Add Item"
    BtnRemDtl.Enabled = False
    If C1DataGrdList.VisibleRows = 0 Then
      GrpType.Visible = True
    End If
  End Sub
  Private Sub TxtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAmount.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtRef_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtRef.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtPrj_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPrj.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub LnkGLAcct_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkGLAcct.LinkClicked
    Dim WrkAcct As String

    WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFund.Text), MyUtils.CnvSng(TxtSFund.Text), MyUtils.CnvSng(TxtDept.Text),
    MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFcn.Text), MyUtils.CnvSng(TxtSfcn.Text))
    MyFrmListGLAcct = New FrmListGLAcct
    MyFrmListGLAcct.MdiParent = Me.ParentForm
    MyFrmListGLAcct.WrkCode = WrkAcct
    MyFrmListGLAcct.Show()
    Me.Hide()
  End Sub

  Private Sub BtnRemDtl_Click(sender As Object, e As EventArgs) Handles BtnRemDtl.Click
    DeleteDtl()
  End Sub
  Private Sub BtnAddDtl_Click(sender As Object, e As EventArgs) Handles BtnAddDtl.Click
    SaveDtl()
  End Sub
End Class
