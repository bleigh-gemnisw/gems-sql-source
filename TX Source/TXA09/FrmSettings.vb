Public Class FrmSettings
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
  Friend WithEvents PrtDialog As System.Windows.Forms.PrintDialog
  Friend WithEvents imageList1 As System.Windows.Forms.ImageList
  Friend WithEvents TbMain As System.Windows.Forms.ToolBar
  Friend WithEvents TBarSave As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarReturn As System.Windows.Forms.ToolBarButton
  Friend WithEvents TabCtl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPgBatch As System.Windows.Forms.TabPage
  Friend WithEvents TabPgPrinter As System.Windows.Forms.TabPage
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbOrientLandscape As System.Windows.Forms.RadioButton
  Friend WithEvents RbOrientPortrait As System.Windows.Forms.RadioButton
  Friend WithEvents TabPgColors As System.Windows.Forms.TabPage
  Friend WithEvents ChkForeclosureColor As System.Windows.Forms.CheckBox
  Friend WithEvents ChkStatusColor As System.Windows.Forms.CheckBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents RbCheckName As System.Windows.Forms.RadioButton
  Friend WithEvents RbCheckSeq As System.Windows.Forms.RadioButton
  Friend WithEvents RbCheckNo As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents RBValidateModelTMU675 As System.Windows.Forms.RadioButton
  Friend WithEvents RBValidateModelTMU325 As System.Windows.Forms.RadioButton
  Friend WithEvents ChkValidateTotal As System.Windows.Forms.CheckBox
  Friend WithEvents LblValidatePrinter As System.Windows.Forms.Label
  Friend WithEvents BtnShowValidate As System.Windows.Forms.Button
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
  Friend WithEvents ChkReceipt As System.Windows.Forms.CheckBox
  Friend WithEvents LblReceiptPrinter As System.Windows.Forms.Label
  Friend WithEvents label6 As System.Windows.Forms.Label
  Friend WithEvents BtnShowReceipt As System.Windows.Forms.Button
  Friend WithEvents LblDupBillPrinter As System.Windows.Forms.Label
  Friend WithEvents BntShowDupBill As System.Windows.Forms.Button
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TabPgDupBill As System.Windows.Forms.TabPage
  Friend WithEvents ChkDupBillPublicUser As System.Windows.Forms.CheckBox
  Friend WithEvents ChkDupBillPublicData As System.Windows.Forms.CheckBox
  Friend WithEvents ChkAdvDriver As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
  Friend WithEvents RbFontCourier As System.Windows.Forms.RadioButton
  Friend WithEvents RbFontArial As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
  Friend WithEvents LblPDFBillPrinter As System.Windows.Forms.Label
  Friend WithEvents BntShowPDFBill As System.Windows.Forms.Button
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents BtnPDFRemove As System.Windows.Forms.Button
  Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSettings))
    Me.PrtDialog = New System.Windows.Forms.PrintDialog()
    Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarReturn = New System.Windows.Forms.ToolBarButton()
    Me.TBarSave = New System.Windows.Forms.ToolBarButton()
    Me.TabCtl1 = New System.Windows.Forms.TabControl()
    Me.TabPgBatch = New System.Windows.Forms.TabPage()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.RbCheckName = New System.Windows.Forms.RadioButton()
    Me.RbCheckSeq = New System.Windows.Forms.RadioButton()
    Me.RbCheckNo = New System.Windows.Forms.RadioButton()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbOrientLandscape = New System.Windows.Forms.RadioButton()
    Me.RbOrientPortrait = New System.Windows.Forms.RadioButton()
    Me.TabPgPrinter = New System.Windows.Forms.TabPage()
    Me.GroupBox8 = New System.Windows.Forms.GroupBox()
    Me.BtnPDFRemove = New System.Windows.Forms.Button()
    Me.LblPDFBillPrinter = New System.Windows.Forms.Label()
    Me.BntShowPDFBill = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.ChkReceipt = New System.Windows.Forms.CheckBox()
    Me.LblReceiptPrinter = New System.Windows.Forms.Label()
    Me.label6 = New System.Windows.Forms.Label()
    Me.BtnShowReceipt = New System.Windows.Forms.Button()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.LblDupBillPrinter = New System.Windows.Forms.Label()
    Me.BntShowDupBill = New System.Windows.Forms.Button()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.GroupBox7 = New System.Windows.Forms.GroupBox()
    Me.RbFontCourier = New System.Windows.Forms.RadioButton()
    Me.RbFontArial = New System.Windows.Forms.RadioButton()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.ChkAdvDriver = New System.Windows.Forms.CheckBox()
    Me.RBValidateModelTMU675 = New System.Windows.Forms.RadioButton()
    Me.RBValidateModelTMU325 = New System.Windows.Forms.RadioButton()
    Me.ChkValidateTotal = New System.Windows.Forms.CheckBox()
    Me.LblValidatePrinter = New System.Windows.Forms.Label()
    Me.BtnShowValidate = New System.Windows.Forms.Button()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TabPgColors = New System.Windows.Forms.TabPage()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.ChkForeclosureColor = New System.Windows.Forms.CheckBox()
    Me.ChkStatusColor = New System.Windows.Forms.CheckBox()
    Me.TabPgDupBill = New System.Windows.Forms.TabPage()
    Me.ChkDupBillPublicUser = New System.Windows.Forms.CheckBox()
    Me.ChkDupBillPublicData = New System.Windows.Forms.CheckBox()
    Me.TabCtl1.SuspendLayout()
    Me.TabPgBatch.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.TabPgPrinter.SuspendLayout()
    Me.GroupBox8.SuspendLayout()
    Me.GroupBox6.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.GroupBox7.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.TabPgColors.SuspendLayout()
    Me.TabPgDupBill.SuspendLayout()
    Me.SuspendLayout()
    '
    'imageList1
    '
    Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.imageList1.Images.SetKeyName(0, "")
    Me.imageList1.Images.SetKeyName(1, "")
    '
    'TbMain
    '
    Me.TbMain.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarReturn, Me.TBarSave})
    Me.TbMain.Dock = System.Windows.Forms.DockStyle.None
    Me.TbMain.DropDownArrows = True
    Me.TbMain.ImageList = Me.imageList1
    Me.TbMain.Location = New System.Drawing.Point(8, 427)
    Me.TbMain.Name = "TbMain"
    Me.TbMain.ShowToolTips = True
    Me.TbMain.Size = New System.Drawing.Size(88, 50)
    Me.TbMain.TabIndex = 190
    '
    'TBarReturn
    '
    Me.TBarReturn.ImageIndex = 0
    Me.TBarReturn.Name = "TBarReturn"
    Me.TBarReturn.Text = "Return"
    '
    'TBarSave
    '
    Me.TBarSave.ImageIndex = 1
    Me.TBarSave.Name = "TBarSave"
    Me.TBarSave.Text = "Save"
    '
    'TabCtl1
    '
    Me.TabCtl1.Controls.Add(Me.TabPgBatch)
    Me.TabCtl1.Controls.Add(Me.TabPgPrinter)
    Me.TabCtl1.Controls.Add(Me.TabPgColors)
    Me.TabCtl1.Controls.Add(Me.TabPgDupBill)
    Me.TabCtl1.Location = New System.Drawing.Point(8, 8)
    Me.TabCtl1.Name = "TabCtl1"
    Me.TabCtl1.SelectedIndex = 0
    Me.TabCtl1.Size = New System.Drawing.Size(499, 413)
    Me.TabCtl1.TabIndex = 196
    '
    'TabPgBatch
    '
    Me.TabPgBatch.Controls.Add(Me.GroupBox3)
    Me.TabPgBatch.Controls.Add(Me.GroupBox1)
    Me.TabPgBatch.Location = New System.Drawing.Point(4, 22)
    Me.TabPgBatch.Name = "TabPgBatch"
    Me.TabPgBatch.Size = New System.Drawing.Size(491, 387)
    Me.TabPgBatch.TabIndex = 0
    Me.TabPgBatch.Text = "Batch reports"
    Me.TabPgBatch.UseVisualStyleBackColor = True
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.RbCheckName)
    Me.GroupBox3.Controls.Add(Me.RbCheckSeq)
    Me.GroupBox3.Controls.Add(Me.RbCheckNo)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(8, 70)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(198, 77)
    Me.GroupBox3.TabIndex = 197
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Check Details sorting method"
    '
    'RbCheckName
    '
    Me.RbCheckName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCheckName.Location = New System.Drawing.Point(8, 52)
    Me.RbCheckName.Name = "RbCheckName"
    Me.RbCheckName.Size = New System.Drawing.Size(146, 18)
    Me.RbCheckName.TabIndex = 2
    Me.RbCheckName.Text = "By Name"
    '
    'RbCheckSeq
    '
    Me.RbCheckSeq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCheckSeq.Location = New System.Drawing.Point(8, 33)
    Me.RbCheckSeq.Name = "RbCheckSeq"
    Me.RbCheckSeq.Size = New System.Drawing.Size(146, 18)
    Me.RbCheckSeq.TabIndex = 1
    Me.RbCheckSeq.Text = "By Sequence Number"
    '
    'RbCheckNo
    '
    Me.RbCheckNo.Checked = True
    Me.RbCheckNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCheckNo.Location = New System.Drawing.Point(8, 16)
    Me.RbCheckNo.Name = "RbCheckNo"
    Me.RbCheckNo.Size = New System.Drawing.Size(119, 16)
    Me.RbCheckNo.TabIndex = 0
    Me.RbCheckNo.TabStop = True
    Me.RbCheckNo.Text = "By Check Number"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbOrientLandscape)
    Me.GroupBox1.Controls.Add(Me.RbOrientPortrait)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(96, 56)
    Me.GroupBox1.TabIndex = 196
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Orientation"
    '
    'RbOrientLandscape
    '
    Me.RbOrientLandscape.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbOrientLandscape.Location = New System.Drawing.Point(8, 32)
    Me.RbOrientLandscape.Name = "RbOrientLandscape"
    Me.RbOrientLandscape.Size = New System.Drawing.Size(80, 16)
    Me.RbOrientLandscape.TabIndex = 1
    Me.RbOrientLandscape.Text = "Landscape"
    '
    'RbOrientPortrait
    '
    Me.RbOrientPortrait.Checked = True
    Me.RbOrientPortrait.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbOrientPortrait.Location = New System.Drawing.Point(8, 16)
    Me.RbOrientPortrait.Name = "RbOrientPortrait"
    Me.RbOrientPortrait.Size = New System.Drawing.Size(64, 16)
    Me.RbOrientPortrait.TabIndex = 0
    Me.RbOrientPortrait.TabStop = True
    Me.RbOrientPortrait.Text = "Portrait"
    '
    'TabPgPrinter
    '
    Me.TabPgPrinter.Controls.Add(Me.GroupBox8)
    Me.TabPgPrinter.Controls.Add(Me.GroupBox6)
    Me.TabPgPrinter.Controls.Add(Me.GroupBox5)
    Me.TabPgPrinter.Controls.Add(Me.GroupBox4)
    Me.TabPgPrinter.Location = New System.Drawing.Point(4, 22)
    Me.TabPgPrinter.Name = "TabPgPrinter"
    Me.TabPgPrinter.Size = New System.Drawing.Size(491, 387)
    Me.TabPgPrinter.TabIndex = 1
    Me.TabPgPrinter.Text = "Printer Setup"
    Me.TabPgPrinter.UseVisualStyleBackColor = True
    '
    'GroupBox8
    '
    Me.GroupBox8.Controls.Add(Me.BtnPDFRemove)
    Me.GroupBox8.Controls.Add(Me.LblPDFBillPrinter)
    Me.GroupBox8.Controls.Add(Me.BntShowPDFBill)
    Me.GroupBox8.Controls.Add(Me.Label2)
    Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox8.Location = New System.Drawing.Point(13, 230)
    Me.GroupBox8.Name = "GroupBox8"
    Me.GroupBox8.Size = New System.Drawing.Size(463, 74)
    Me.GroupBox8.TabIndex = 201
    Me.GroupBox8.TabStop = False
    Me.GroupBox8.Text = "PDF Bills "
    '
    'BtnPDFRemove
    '
    Me.BtnPDFRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnPDFRemove.Location = New System.Drawing.Point(6, 22)
    Me.BtnPDFRemove.Name = "BtnPDFRemove"
    Me.BtnPDFRemove.Size = New System.Drawing.Size(65, 25)
    Me.BtnPDFRemove.TabIndex = 203
    Me.BtnPDFRemove.Text = "Remove"
    '
    'LblPDFBillPrinter
    '
    Me.LblPDFBillPrinter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPDFBillPrinter.Location = New System.Drawing.Point(94, 54)
    Me.LblPDFBillPrinter.Name = "LblPDFBillPrinter"
    Me.LblPDFBillPrinter.Size = New System.Drawing.Size(363, 16)
    Me.LblPDFBillPrinter.TabIndex = 202
    '
    'BntShowPDFBill
    '
    Me.BntShowPDFBill.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BntShowPDFBill.Location = New System.Drawing.Point(94, 22)
    Me.BntShowPDFBill.Name = "BntShowPDFBill"
    Me.BntShowPDFBill.Size = New System.Drawing.Size(96, 25)
    Me.BntShowPDFBill.TabIndex = 201
    Me.BntShowPDFBill.Text = "Show Printers"
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(6, 54)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(88, 11)
    Me.Label2.TabIndex = 200
    Me.Label2.Text = "PDF Writer"
    '
    'GroupBox6
    '
    Me.GroupBox6.Controls.Add(Me.ChkReceipt)
    Me.GroupBox6.Controls.Add(Me.LblReceiptPrinter)
    Me.GroupBox6.Controls.Add(Me.label6)
    Me.GroupBox6.Controls.Add(Me.BtnShowReceipt)
    Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox6.Location = New System.Drawing.Point(13, 310)
    Me.GroupBox6.Name = "GroupBox6"
    Me.GroupBox6.Size = New System.Drawing.Size(463, 74)
    Me.GroupBox6.TabIndex = 200
    Me.GroupBox6.TabStop = False
    Me.GroupBox6.Text = "Customer Receipt"
    '
    'ChkReceipt
    '
    Me.ChkReceipt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkReceipt.Location = New System.Drawing.Point(208, 19)
    Me.ChkReceipt.Name = "ChkReceipt"
    Me.ChkReceipt.Size = New System.Drawing.Size(200, 24)
    Me.ChkReceipt.TabIndex = 8
    Me.ChkReceipt.Text = "Check to Activate Receipt Printing"
    '
    'LblReceiptPrinter
    '
    Me.LblReceiptPrinter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblReceiptPrinter.Location = New System.Drawing.Point(94, 55)
    Me.LblReceiptPrinter.Name = "LblReceiptPrinter"
    Me.LblReceiptPrinter.Size = New System.Drawing.Size(357, 16)
    Me.LblReceiptPrinter.TabIndex = 7
    '
    'label6
    '
    Me.label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label6.Location = New System.Drawing.Point(6, 55)
    Me.label6.Name = "label6"
    Me.label6.Size = New System.Drawing.Size(82, 16)
    Me.label6.TabIndex = 6
    Me.label6.Text = "Printer Name"
    '
    'BtnShowReceipt
    '
    Me.BtnShowReceipt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnShowReceipt.Location = New System.Drawing.Point(97, 19)
    Me.BtnShowReceipt.Name = "BtnShowReceipt"
    Me.BtnShowReceipt.Size = New System.Drawing.Size(96, 24)
    Me.BtnShowReceipt.TabIndex = 5
    Me.BtnShowReceipt.Text = "Show Printers"
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.LblDupBillPrinter)
    Me.GroupBox5.Controls.Add(Me.BntShowDupBill)
    Me.GroupBox5.Controls.Add(Me.Label4)
    Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox5.Location = New System.Drawing.Point(13, 150)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(463, 74)
    Me.GroupBox5.TabIndex = 199
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "Duplicate Bills, Lien Release, MV Clearance"
    '
    'LblDupBillPrinter
    '
    Me.LblDupBillPrinter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDupBillPrinter.Location = New System.Drawing.Point(94, 54)
    Me.LblDupBillPrinter.Name = "LblDupBillPrinter"
    Me.LblDupBillPrinter.Size = New System.Drawing.Size(357, 16)
    Me.LblDupBillPrinter.TabIndex = 202
    '
    'BntShowDupBill
    '
    Me.BntShowDupBill.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BntShowDupBill.Location = New System.Drawing.Point(94, 22)
    Me.BntShowDupBill.Name = "BntShowDupBill"
    Me.BntShowDupBill.Size = New System.Drawing.Size(96, 25)
    Me.BntShowDupBill.TabIndex = 201
    Me.BntShowDupBill.Text = "Show Printers"
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(6, 54)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(88, 11)
    Me.Label4.TabIndex = 200
    Me.Label4.Text = "Printer Name"
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.GroupBox7)
    Me.GroupBox4.Controls.Add(Me.GroupBox2)
    Me.GroupBox4.Controls.Add(Me.ChkValidateTotal)
    Me.GroupBox4.Controls.Add(Me.LblValidatePrinter)
    Me.GroupBox4.Controls.Add(Me.BtnShowValidate)
    Me.GroupBox4.Controls.Add(Me.Label5)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(13, 14)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(463, 116)
    Me.GroupBox4.TabIndex = 198
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Bill Validation, Check Endorsement"
    '
    'GroupBox7
    '
    Me.GroupBox7.Controls.Add(Me.RbFontCourier)
    Me.GroupBox7.Controls.Add(Me.RbFontArial)
    Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox7.Location = New System.Drawing.Point(215, 11)
    Me.GroupBox7.Name = "GroupBox7"
    Me.GroupBox7.Size = New System.Drawing.Size(121, 59)
    Me.GroupBox7.TabIndex = 204
    Me.GroupBox7.TabStop = False
    Me.GroupBox7.Text = "Adv Driver Font "
    '
    'RbFontCourier
    '
    Me.RbFontCourier.Checked = True
    Me.RbFontCourier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFontCourier.Location = New System.Drawing.Point(6, 19)
    Me.RbFontCourier.Name = "RbFontCourier"
    Me.RbFontCourier.Size = New System.Drawing.Size(109, 16)
    Me.RbFontCourier.TabIndex = 1
    Me.RbFontCourier.TabStop = True
    Me.RbFontCourier.Text = "Courier New 8/9"
    '
    'RbFontArial
    '
    Me.RbFontArial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFontArial.Location = New System.Drawing.Point(6, 37)
    Me.RbFontArial.Name = "RbFontArial"
    Me.RbFontArial.Size = New System.Drawing.Size(109, 16)
    Me.RbFontArial.TabIndex = 0
    Me.RbFontArial.Text = "Arial 10 "
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.ChkAdvDriver)
    Me.GroupBox2.Controls.Add(Me.RBValidateModelTMU675)
    Me.GroupBox2.Controls.Add(Me.RBValidateModelTMU325)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(342, 11)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(115, 75)
    Me.GroupBox2.TabIndex = 203
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Validator Model"
    '
    'ChkAdvDriver
    '
    Me.ChkAdvDriver.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAdvDriver.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkAdvDriver.Location = New System.Drawing.Point(20, 50)
    Me.ChkAdvDriver.Name = "ChkAdvDriver"
    Me.ChkAdvDriver.Size = New System.Drawing.Size(89, 20)
    Me.ChkAdvDriver.TabIndex = 204
    Me.ChkAdvDriver.Text = "Adv. Driver?"
    '
    'RBValidateModelTMU675
    '
    Me.RBValidateModelTMU675.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RBValidateModelTMU675.Location = New System.Drawing.Point(8, 34)
    Me.RBValidateModelTMU675.Name = "RBValidateModelTMU675"
    Me.RBValidateModelTMU675.Size = New System.Drawing.Size(80, 16)
    Me.RBValidateModelTMU675.TabIndex = 1
    Me.RBValidateModelTMU675.Text = "TM-U675"
    '
    'RBValidateModelTMU325
    '
    Me.RBValidateModelTMU325.Checked = True
    Me.RBValidateModelTMU325.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RBValidateModelTMU325.Location = New System.Drawing.Point(8, 16)
    Me.RBValidateModelTMU325.Name = "RBValidateModelTMU325"
    Me.RBValidateModelTMU325.Size = New System.Drawing.Size(80, 19)
    Me.RBValidateModelTMU325.TabIndex = 0
    Me.RBValidateModelTMU325.TabStop = True
    Me.RBValidateModelTMU325.Text = "TM-U325"
    '
    'ChkValidateTotal
    '
    Me.ChkValidateTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkValidateTotal.Location = New System.Drawing.Point(9, 19)
    Me.ChkValidateTotal.Name = "ChkValidateTotal"
    Me.ChkValidateTotal.Size = New System.Drawing.Size(200, 16)
    Me.ChkValidateTotal.TabIndex = 202
    Me.ChkValidateTotal.Text = "Check to Print Validation Totals"
    '
    'LblValidatePrinter
    '
    Me.LblValidatePrinter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblValidatePrinter.Location = New System.Drawing.Point(85, 93)
    Me.LblValidatePrinter.Name = "LblValidatePrinter"
    Me.LblValidatePrinter.Size = New System.Drawing.Size(366, 20)
    Me.LblValidatePrinter.TabIndex = 201
    '
    'BtnShowValidate
    '
    Me.BtnShowValidate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnShowValidate.Location = New System.Drawing.Point(93, 46)
    Me.BtnShowValidate.Name = "BtnShowValidate"
    Me.BtnShowValidate.Size = New System.Drawing.Size(96, 24)
    Me.BtnShowValidate.TabIndex = 199
    Me.BtnShowValidate.Text = "Show Printers"
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(0, 93)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(88, 11)
    Me.Label5.TabIndex = 198
    Me.Label5.Text = "Printer Name"
    '
    'TabPgColors
    '
    Me.TabPgColors.Controls.Add(Me.Label7)
    Me.TabPgColors.Controls.Add(Me.ChkForeclosureColor)
    Me.TabPgColors.Controls.Add(Me.ChkStatusColor)
    Me.TabPgColors.Location = New System.Drawing.Point(4, 22)
    Me.TabPgColors.Name = "TabPgColors"
    Me.TabPgColors.Size = New System.Drawing.Size(491, 387)
    Me.TabPgColors.TabIndex = 4
    Me.TabPgColors.Text = "Colors"
    Me.TabPgColors.UseVisualStyleBackColor = True
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(20, 14)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(367, 13)
    Me.Label7.TabIndex = 8
    Me.Label7.Text = "Collection - Select  (search screen). Unchecked color is white. "
    '
    'ChkForeclosureColor
    '
    Me.ChkForeclosureColor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkForeclosureColor.Location = New System.Drawing.Point(13, 63)
    Me.ChkForeclosureColor.Name = "ChkForeclosureColor"
    Me.ChkForeclosureColor.Size = New System.Drawing.Size(177, 19)
    Me.ChkForeclosureColor.TabIndex = 7
    Me.ChkForeclosureColor.Text = "Use Foreclosure Color (Pink)?"
    '
    'ChkStatusColor
    '
    Me.ChkStatusColor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkStatusColor.Location = New System.Drawing.Point(13, 41)
    Me.ChkStatusColor.Name = "ChkStatusColor"
    Me.ChkStatusColor.Size = New System.Drawing.Size(177, 16)
    Me.ChkStatusColor.TabIndex = 6
    Me.ChkStatusColor.Text = "Use Status Color (Yellow)?"
    '
    'TabPgDupBill
    '
    Me.TabPgDupBill.Controls.Add(Me.ChkDupBillPublicUser)
    Me.TabPgDupBill.Controls.Add(Me.ChkDupBillPublicData)
    Me.TabPgDupBill.Location = New System.Drawing.Point(4, 22)
    Me.TabPgDupBill.Name = "TabPgDupBill"
    Me.TabPgDupBill.Size = New System.Drawing.Size(491, 387)
    Me.TabPgDupBill.TabIndex = 5
    Me.TabPgDupBill.Text = "Duplicate Bill"
    Me.TabPgDupBill.UseVisualStyleBackColor = True
    '
    'ChkDupBillPublicUser
    '
    Me.ChkDupBillPublicUser.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkDupBillPublicUser.Location = New System.Drawing.Point(13, 42)
    Me.ChkDupBillPublicUser.Name = "ChkDupBillPublicUser"
    Me.ChkDupBillPublicUser.Size = New System.Drawing.Size(159, 18)
    Me.ChkDupBillPublicUser.TabIndex = 8
    Me.ChkDupBillPublicUser.Text = "Allowed for Public User?"
    '
    'ChkDupBillPublicData
    '
    Me.ChkDupBillPublicData.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkDupBillPublicData.Location = New System.Drawing.Point(13, 18)
    Me.ChkDupBillPublicData.Name = "ChkDupBillPublicData"
    Me.ChkDupBillPublicData.Size = New System.Drawing.Size(159, 18)
    Me.ChkDupBillPublicData.TabIndex = 7
    Me.ChkDupBillPublicData.Text = "Include Public data?"
    '
    'FrmSettings
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(519, 475)
    Me.Controls.Add(Me.TabCtl1)
    Me.Controls.Add(Me.TbMain)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmSettings"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Program and Printer settings"
    Me.TabCtl1.ResumeLayout(False)
    Me.TabPgBatch.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.TabPgPrinter.ResumeLayout(False)
    Me.GroupBox8.ResumeLayout(False)
    Me.GroupBox6.ResumeLayout(False)
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox7.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.TabPgColors.ResumeLayout(False)
    Me.TabPgColors.PerformLayout()
    Me.TabPgDupBill.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region
  Private Sub FrmSettings_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    Me.Dispose()
  End Sub

  Private Sub FrmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If MyInquiryMode Then
      TabCtl1.TabPages.Remove(TabPgBatch)
      TabCtl1.TabPages.Remove(TabPgPrinter)
      TabCtl1.TabPages.Remove(TabPgColors)
    End If

    LblValidatePrinter.Text = MyAppSettings.ValidatePrinter
    LblReceiptPrinter.Text = MyAppSettings.ReceiptPrinter
    LblDupBillPrinter.Text = MyAppSettings.DupBillPrinter
    LblPDFBillPrinter.Text = MyAppSettings.PDFBillPrinter
    Select Case MyAppSettings.ValidateModel
      Case "TM-U325", ""
        RBValidateModelTMU325.Checked = True
      Case "TM-U675"
        RBValidateModelTMU675.Checked = True
    End Select
    Select Case MyAppSettings.ValidateFont
      Case "Arial-10"
        RbFontArial.Checked = True
      Case "Courier New-9", ""
        RbFontCourier.Checked = True
    End Select
    If MyAppSettings.AdvDriver Then
      ChkAdvDriver.Checked = True
    End If
    If MyPrinterLandscape Then
      RbOrientLandscape.Checked = True
    End If

    Select Case MyCheckSort
      Case "Check Number"
        RbCheckNo.Checked = True
      Case "Sequence"
        RbCheckSeq.Checked = True
      Case "Name"
        RbCheckName.Checked = True
    End Select

    If MyAppSettings.ValidateTotal Then
      ChkValidateTotal.Checked = True
    End If
    If MyAppSettings.Receipt Then
      ChkReceipt.Checked = True
    End If
    If MyAppSettings.StatusColor Then
      ChkStatusColor.Checked = True
    End If
    If MyAppSettings.ForeclosureColor Then
      ChkForeclosureColor.Checked = True
    End If
    If MyAppSettings.DupBillPublicData Then
      ChkDupBillPublicData.Checked = True
    End If
    If MyAppSettings.DupBillPublicUser Then
      ChkDupBillPublicUser.Checked = True
    End If

    With MyFrmTXA09
      .TBarBack.Enabled = False
      .TBarNew.Enabled = False
      .TBarView.Enabled = False
      .TBarSettings.Enabled = False
    End With
  End Sub
  Public Sub SaveData()
    Dim WrkValidateModel As String
    Dim WrkValidateFont As String
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sw As IO.StreamWriter
    Dim WrkProgName As String
    Dim WrkXMLPath As String

    With MyAppSettings
      If Not MyInquiryMode Then
        WrkValidateModel = ""
        If RBValidateModelTMU325.Checked Then
          WrkValidateModel = "TM-U325"
        End If
        If RBValidateModelTMU675.Checked Then
          WrkValidateModel = "TM-U675"
        End If
        WrkValidateFont = ""
        If RbFontArial.Checked Then
          WrkValidateFont = "Arial-10"
        End If
        If RbFontCourier.Checked Then
          WrkValidateFont = "Courier New-9"
        End If
        .ValidatePrinter = LblValidatePrinter.Text
        .ValidateModel = WrkValidateModel
        .ValidateFont = WrkValidateFont
        .ReceiptPrinter = LblReceiptPrinter.Text
        If ChkAdvDriver.Checked Then
          .AdvDriver = True
        Else
          .AdvDriver = False
        End If
        .DupBillPrinter = LblDupBillPrinter.Text
        .PDFBillPrinter = LblPDFBillPrinter.Text
        If ChkReceipt.Checked Then
          .Receipt = True
        Else
          .Receipt = False
        End If
        .ReceiptPrinter = LblReceiptPrinter.Text

        If RbOrientLandscape.Checked Then
          .PrinterOrient = "L"
          MyPrinterLandscape = True
        Else
          .PrinterOrient = "P"
          MyPrinterLandscape = False
        End If

        If RbCheckNo.Checked Then
          MyCheckSort = "Check Number"
        End If
        If RbCheckSeq.Checked Then
          MyCheckSort = "Sequence"
        End If
        If RbCheckName.Checked Then
          MyCheckSort = "Name"
        End If
        .CheckSort = MyCheckSort

        If ChkValidateTotal.Checked Then
          .ValidateTotal = True
        Else
          .ValidateTotal = False
        End If

        If ChkStatusColor.Checked Then
          .StatusColor = True
        Else
          .StatusColor = False
        End If
        If ChkForeclosureColor.Checked Then
          .ForeclosureColor = True
        Else
          .ForeclosureColor = False
        End If
      End If

      If ChkDupBillPublicData.Checked Then
        .DupBillPublicData = True
      Else
        .DupBillPublicData = False
      End If

      If ChkDupBillPublicUser.Checked Then
        .DupBillPublicUser = True
      Else
        .DupBillPublicUser = False
      End If
    End With

    WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
    If MyWebBrowser Then
      WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & " " & Environment.UserName & ".xml"
    Else
      WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & " " & MyUtils.GetComputerName() & ".xml"
    End If
    sw = New IO.StreamWriter(WrkXMLPath)
    xs.Serialize(sw, MyAppSettings)
    sw.Close()
    Me.Close()
  End Sub

  Private Sub FrmSettings_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    With MyFrmTXA09
      .TBarBack.Enabled = True
      .TBarNew.Enabled = True
      .TBarView.Enabled = True
      .TBarSettings.Enabled = True
    End With

  End Sub

  Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
    If e.Button Is TBarReturn Then
      Me.Close()
    End If

    If e.Button Is TBarSave Then
      SaveData()
    End If

  End Sub
  Private Sub BtnShowValidate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShowValidate.Click
    PrtDialog.PrinterSettings = New Printing.PrinterSettings

    PrtDialog.UseEXDialog = True
    Dim result As DialogResult = PrtDialog.ShowDialog()

    If (result = Windows.Forms.DialogResult.OK) Then
      LblValidatePrinter.Text = PrtDialog.PrinterSettings.PrinterName()
    End If
  End Sub

  Private Sub BntShowDupBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BntShowDupBill.Click
    PrtDialog.PrinterSettings = New Printing.PrinterSettings
    PrtDialog.UseEXDialog = True
    Dim result As DialogResult = PrtDialog.ShowDialog()

    If (result = Windows.Forms.DialogResult.OK) Then
      LblDupBillPrinter.Text = PrtDialog.PrinterSettings.PrinterName()
    End If

  End Sub
  Private Sub BntShowPDFBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BntShowPDFBill.Click
    PrtDialog.PrinterSettings = New Printing.PrinterSettings
    PrtDialog.UseEXDialog = True
    Dim result As DialogResult = PrtDialog.ShowDialog()

    If (result = Windows.Forms.DialogResult.OK) Then
      LblPDFBillPrinter.Text = PrtDialog.PrinterSettings.PrinterName()
    End If

  End Sub
  Private Sub BtnShowReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShowReceipt.Click
    PrtDialog.PrinterSettings = New Printing.PrinterSettings
    PrtDialog.UseEXDialog = True

    Dim result As DialogResult = PrtDialog.ShowDialog()

    If (result = Windows.Forms.DialogResult.OK) Then
      LblReceiptPrinter.Text = PrtDialog.PrinterSettings.PrinterName()
    End If

  End Sub
  Private Sub BtnPDFRemove_Click(sender As Object, e As EventArgs) Handles BtnPDFRemove.Click
    LblPDFBillPrinter.Text = ""
  End Sub
End Class
