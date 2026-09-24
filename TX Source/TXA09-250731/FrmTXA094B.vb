Public Class FrmTXA094B
  Inherits System.Windows.Forms.Form
  Dim ds2 As DataSet = New DataSet
  Dim dr As DataRow
  Friend WithEvents TxtMsg As System.Windows.Forms.TextBox
  Friend WithEvents TxtAltFormID As System.Windows.Forms.TextBox
  Friend WithEvents RbDupBill As System.Windows.Forms.RadioButton
  Friend WithEvents LnkAltID As System.Windows.Forms.LinkLabel
  Friend WithEvents GroupBox1 As GroupBox
  Friend WithEvents RbPrint As RadioButton
  Friend WithEvents RbProcess As RadioButton
  Friend WithEvents BtnProcess As Button
  Dim myTXINV As TXINV.myData
  Dim SaveGridTop As Integer
  Friend WithEvents Label2 As Label
  Dim SaveGridHeight As Integer

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
  Friend WithEvents LblPckInt As System.Windows.Forms.Label
  Friend WithEvents DtPckInt As System.Windows.Forms.DateTimePicker
  Friend WithEvents RbDemand As System.Windows.Forms.RadioButton
  Friend WithEvents RbWarrants As System.Windows.Forms.RadioButton
  Friend WithEvents RbStatement As System.Windows.Forms.RadioButton
  Friend WithEvents BtnPrint As System.Windows.Forms.Button
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents GrpAddr As System.Windows.Forms.GroupBox
  Friend WithEvents TxtZip4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtZip5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents TxtAdd2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtAdd1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtSname As System.Windows.Forms.TextBox
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents LblPckComp As System.Windows.Forms.Label
  Friend WithEvents DtPckComp As System.Windows.Forms.DateTimePicker
  Friend WithEvents LblMsg2 As System.Windows.Forms.Label
  Friend WithEvents LblMsg1 As System.Windows.Forms.Label
  Friend WithEvents ChkBalance As System.Windows.Forms.CheckBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTXA094B))
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.ChkBalance = New System.Windows.Forms.CheckBox()
    Me.LblPckInt = New System.Windows.Forms.Label()
    Me.DtPckInt = New System.Windows.Forms.DateTimePicker()
    Me.RbDemand = New System.Windows.Forms.RadioButton()
    Me.RbWarrants = New System.Windows.Forms.RadioButton()
    Me.RbStatement = New System.Windows.Forms.RadioButton()
    Me.BtnPrint = New System.Windows.Forms.Button()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.GrpAddr = New System.Windows.Forms.GroupBox()
    Me.TxtZip4 = New System.Windows.Forms.TextBox()
    Me.TxtZip5 = New System.Windows.Forms.TextBox()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtAdd2 = New System.Windows.Forms.TextBox()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.TxtAdd1 = New System.Windows.Forms.TextBox()
    Me.TxtSname = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.label1 = New System.Windows.Forms.Label()
    Me.LblPckComp = New System.Windows.Forms.Label()
    Me.DtPckComp = New System.Windows.Forms.DateTimePicker()
    Me.LblMsg2 = New System.Windows.Forms.Label()
    Me.LblMsg1 = New System.Windows.Forms.Label()
    Me.TxtMsg = New System.Windows.Forms.TextBox()
    Me.TxtAltFormID = New System.Windows.Forms.TextBox()
    Me.RbDupBill = New System.Windows.Forms.RadioButton()
    Me.LnkAltID = New System.Windows.Forms.LinkLabel()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbPrint = New System.Windows.Forms.RadioButton()
    Me.RbProcess = New System.Windows.Forms.RadioButton()
    Me.BtnProcess = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpAddr.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColMove = False
    Me.C1DataGrdList.AllowColSelect = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AllowUpdate = False
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(8, 232)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.Size = New System.Drawing.Size(771, 182)
    Me.C1DataGrdList.TabIndex = 6
    Me.C1DataGrdList.Text = "C1TrueDBGrid1"
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    '
    'ChkBalance
    '
    Me.ChkBalance.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkBalance.Location = New System.Drawing.Point(12, 107)
    Me.ChkBalance.Name = "ChkBalance"
    Me.ChkBalance.Size = New System.Drawing.Size(167, 16)
    Me.ChkBalance.TabIndex = 7
    Me.ChkBalance.Text = "Show Balance/Hide Status?"
    '
    'LblPckInt
    '
    Me.LblPckInt.Location = New System.Drawing.Point(9, 58)
    Me.LblPckInt.Name = "LblPckInt"
    Me.LblPckInt.Size = New System.Drawing.Size(72, 16)
    Me.LblPckInt.TabIndex = 165
    Me.LblPckInt.Text = "Interest Date"
    '
    'DtPckInt
    '
    Me.DtPckInt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckInt.Location = New System.Drawing.Point(100, 54)
    Me.DtPckInt.Name = "DtPckInt"
    Me.DtPckInt.ShowCheckBox = True
    Me.DtPckInt.Size = New System.Drawing.Size(96, 20)
    Me.DtPckInt.TabIndex = 164
    '
    'RbDemand
    '
    Me.RbDemand.AutoSize = True
    Me.RbDemand.Location = New System.Drawing.Point(550, 78)
    Me.RbDemand.Name = "RbDemand"
    Me.RbDemand.Size = New System.Drawing.Size(99, 17)
    Me.RbDemand.TabIndex = 168
    Me.RbDemand.Tag = "2"
    Me.RbDemand.Text = "Demand Notice"
    '
    'RbWarrants
    '
    Me.RbWarrants.AutoSize = True
    Me.RbWarrants.Location = New System.Drawing.Point(693, 58)
    Me.RbWarrants.Name = "RbWarrants"
    Me.RbWarrants.Size = New System.Drawing.Size(63, 17)
    Me.RbWarrants.TabIndex = 167
    Me.RbWarrants.Tag = "3"
    Me.RbWarrants.Text = "Warrant"
    '
    'RbStatement
    '
    Me.RbStatement.AutoSize = True
    Me.RbStatement.Checked = True
    Me.RbStatement.Location = New System.Drawing.Point(550, 58)
    Me.RbStatement.Name = "RbStatement"
    Me.RbStatement.Size = New System.Drawing.Size(127, 17)
    Me.RbStatement.TabIndex = 166
    Me.RbStatement.TabStop = True
    Me.RbStatement.Tag = "1"
    Me.RbStatement.Text = "Delinquent Statement"
    '
    'BtnPrint
    '
    Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
    Me.BtnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.BtnPrint.Location = New System.Drawing.Point(655, 6)
    Me.BtnPrint.Name = "BtnPrint"
    Me.BtnPrint.Size = New System.Drawing.Size(88, 49)
    Me.BtnPrint.TabIndex = 169
    Me.BtnPrint.Text = "Print "
    Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnPrint.UseVisualStyleBackColor = True
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(217, 107)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(48, 16)
    Me.Label4.TabIndex = 220
    Me.Label4.Text = "City/ST"
    '
    'GrpAddr
    '
    Me.GrpAddr.Controls.Add(Me.TxtZip4)
    Me.GrpAddr.Controls.Add(Me.TxtZip5)
    Me.GrpAddr.Controls.Add(Me.TxtState)
    Me.GrpAddr.Controls.Add(Me.TxtAdd2)
    Me.GrpAddr.Controls.Add(Me.TxtCity)
    Me.GrpAddr.Controls.Add(Me.TxtAdd1)
    Me.GrpAddr.Controls.Add(Me.TxtSname)
    Me.GrpAddr.Controls.Add(Me.TxtName)
    Me.GrpAddr.Location = New System.Drawing.Point(271, 3)
    Me.GrpAddr.Name = "GrpAddr"
    Me.GrpAddr.Size = New System.Drawing.Size(254, 120)
    Me.GrpAddr.TabIndex = 217
    Me.GrpAddr.TabStop = False
    '
    'TxtZip4
    '
    Me.TxtZip4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtZip4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip4.Location = New System.Drawing.Point(216, 96)
    Me.TxtZip4.MaxLength = 4
    Me.TxtZip4.Name = "TxtZip4"
    Me.TxtZip4.ReadOnly = True
    Me.TxtZip4.Size = New System.Drawing.Size(32, 20)
    Me.TxtZip4.TabIndex = 7
    '
    'TxtZip5
    '
    Me.TxtZip5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtZip5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip5.Location = New System.Drawing.Point(168, 96)
    Me.TxtZip5.MaxLength = 5
    Me.TxtZip5.Name = "TxtZip5"
    Me.TxtZip5.ReadOnly = True
    Me.TxtZip5.Size = New System.Drawing.Size(44, 20)
    Me.TxtZip5.TabIndex = 6
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(144, 96)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.ReadOnly = True
    Me.TxtState.Size = New System.Drawing.Size(24, 20)
    Me.TxtState.TabIndex = 5
    '
    'TxtAdd2
    '
    Me.TxtAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd2.Location = New System.Drawing.Point(8, 76)
    Me.TxtAdd2.MaxLength = 35
    Me.TxtAdd2.Name = "TxtAdd2"
    Me.TxtAdd2.ReadOnly = True
    Me.TxtAdd2.Size = New System.Drawing.Size(216, 20)
    Me.TxtAdd2.TabIndex = 3
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(8, 96)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.ReadOnly = True
    Me.TxtCity.Size = New System.Drawing.Size(136, 20)
    Me.TxtCity.TabIndex = 4
    '
    'TxtAdd1
    '
    Me.TxtAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd1.Location = New System.Drawing.Point(8, 56)
    Me.TxtAdd1.MaxLength = 35
    Me.TxtAdd1.Name = "TxtAdd1"
    Me.TxtAdd1.ReadOnly = True
    Me.TxtAdd1.Size = New System.Drawing.Size(216, 20)
    Me.TxtAdd1.TabIndex = 2
    '
    'TxtSname
    '
    Me.TxtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSname.Location = New System.Drawing.Point(8, 36)
    Me.TxtSname.MaxLength = 35
    Me.TxtSname.Name = "TxtSname"
    Me.TxtSname.ReadOnly = True
    Me.TxtSname.Size = New System.Drawing.Size(216, 20)
    Me.TxtSname.TabIndex = 1
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(8, 16)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.ReadOnly = True
    Me.TxtName.Size = New System.Drawing.Size(216, 20)
    Me.TxtName.TabIndex = 0
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(217, 64)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(48, 16)
    Me.Label3.TabIndex = 219
    Me.Label3.Text = "Address"
    '
    'label1
    '
    Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label1.Location = New System.Drawing.Point(217, 24)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(48, 16)
    Me.label1.TabIndex = 218
    Me.label1.Text = "Name"
    '
    'LblPckComp
    '
    Me.LblPckComp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPckComp.Location = New System.Drawing.Point(10, 82)
    Me.LblPckComp.Name = "LblPckComp"
    Me.LblPckComp.Size = New System.Drawing.Size(92, 16)
    Me.LblPckComp.TabIndex = 222
    Me.LblPckComp.Text = "Compliance Date"
    '
    'DtPckComp
    '
    Me.DtPckComp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckComp.Location = New System.Drawing.Point(108, 80)
    Me.DtPckComp.Name = "DtPckComp"
    Me.DtPckComp.Size = New System.Drawing.Size(88, 20)
    Me.DtPckComp.TabIndex = 221
    '
    'LblMsg2
    '
    Me.LblMsg2.AutoSize = True
    Me.LblMsg2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMsg2.Location = New System.Drawing.Point(18, 174)
    Me.LblMsg2.Name = "LblMsg2"
    Me.LblMsg2.Size = New System.Drawing.Size(85, 13)
    Me.LblMsg2.TabIndex = 225
    Me.LblMsg2.Text = "1000 chars max."
    '
    'LblMsg1
    '
    Me.LblMsg1.AutoSize = True
    Me.LblMsg1.Location = New System.Drawing.Point(12, 161)
    Me.LblMsg1.Name = "LblMsg1"
    Me.LblMsg1.Size = New System.Drawing.Size(96, 13)
    Me.LblMsg1.TabIndex = 224
    Me.LblMsg1.Text = "Message (optional)"
    '
    'TxtMsg
    '
    Me.TxtMsg.Location = New System.Drawing.Point(109, 132)
    Me.TxtMsg.MaxLength = 1000
    Me.TxtMsg.Multiline = True
    Me.TxtMsg.Name = "TxtMsg"
    Me.TxtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.TxtMsg.Size = New System.Drawing.Size(579, 94)
    Me.TxtMsg.TabIndex = 226
    '
    'TxtAltFormID
    '
    Me.TxtAltFormID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAltFormID.Location = New System.Drawing.Point(655, 99)
    Me.TxtAltFormID.MaxLength = 1
    Me.TxtAltFormID.Name = "TxtAltFormID"
    Me.TxtAltFormID.Size = New System.Drawing.Size(20, 20)
    Me.TxtAltFormID.TabIndex = 227
    '
    'RbDupBill
    '
    Me.RbDupBill.AutoSize = True
    Me.RbDupBill.Location = New System.Drawing.Point(693, 78)
    Me.RbDupBill.Name = "RbDupBill"
    Me.RbDupBill.Size = New System.Drawing.Size(86, 17)
    Me.RbDupBill.TabIndex = 229
    Me.RbDupBill.Tag = "3"
    Me.RbDupBill.Text = "Duplicate Bill"
    '
    'LnkAltID
    '
    Me.LnkAltID.AutoSize = True
    Me.LnkAltID.Location = New System.Drawing.Point(552, 102)
    Me.LnkAltID.Name = "LnkAltID"
    Me.LnkAltID.Size = New System.Drawing.Size(97, 13)
    Me.LnkAltID.TabIndex = 230
    Me.LnkAltID.TabStop = True
    Me.LnkAltID.Text = "Alternative Form ID"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbPrint)
    Me.GroupBox1.Controls.Add(Me.RbProcess)
    Me.GroupBox1.Location = New System.Drawing.Point(15, 2)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(154, 34)
    Me.GroupBox1.TabIndex = 231
    Me.GroupBox1.TabStop = False
    '
    'RbPrint
    '
    Me.RbPrint.AutoSize = True
    Me.RbPrint.Location = New System.Drawing.Point(85, 10)
    Me.RbPrint.Name = "RbPrint"
    Me.RbPrint.Size = New System.Drawing.Size(46, 17)
    Me.RbPrint.TabIndex = 168
    Me.RbPrint.Tag = "1"
    Me.RbPrint.Text = "Print"
    '
    'RbProcess
    '
    Me.RbProcess.AutoSize = True
    Me.RbProcess.Checked = True
    Me.RbProcess.Location = New System.Drawing.Point(7, 10)
    Me.RbProcess.Name = "RbProcess"
    Me.RbProcess.Size = New System.Drawing.Size(63, 17)
    Me.RbProcess.TabIndex = 167
    Me.RbProcess.TabStop = True
    Me.RbProcess.Tag = "1"
    Me.RbProcess.Text = "Process"
    '
    'BtnProcess
    '
    Me.BtnProcess.Image = CType(resources.GetObject("BtnProcess.Image"), System.Drawing.Image)
    Me.BtnProcess.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.BtnProcess.Location = New System.Drawing.Point(555, 6)
    Me.BtnProcess.Name = "BtnProcess"
    Me.BtnProcess.Size = New System.Drawing.Size(88, 49)
    Me.BtnProcess.TabIndex = 232
    Me.BtnProcess.Text = "Process"
    Me.BtnProcess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnProcess.UseVisualStyleBackColor = True
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(9, 417)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(260, 13)
    Me.Label2.TabIndex = 233
    Me.Label2.Text = "Click Continue or Close Screen to Add more accounts"
    '
    'FrmTXA094B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(793, 438)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.BtnProcess)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.LnkAltID)
    Me.Controls.Add(Me.RbDupBill)
    Me.Controls.Add(Me.TxtAltFormID)
    Me.Controls.Add(Me.TxtMsg)
    Me.Controls.Add(Me.LblMsg2)
    Me.Controls.Add(Me.LblMsg1)
    Me.Controls.Add(Me.LblPckComp)
    Me.Controls.Add(Me.DtPckComp)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.GrpAddr)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.label1)
    Me.Controls.Add(Me.BtnPrint)
    Me.Controls.Add(Me.RbDemand)
    Me.Controls.Add(Me.RbWarrants)
    Me.Controls.Add(Me.RbStatement)
    Me.Controls.Add(Me.LblPckInt)
    Me.Controls.Add(Me.DtPckInt)
    Me.Controls.Add(Me.ChkBalance)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA094B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Print/Process Selected Items"
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpAddr.ResumeLayout(False)
    Me.GrpAddr.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTXA094B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Windows.Forms.Cursor.Current = Cursors.Default

    myTXINV = New TXINV.mydata(MyDBConnect)

    With MyFrmTXA09
      .TBarView.Enabled = False
      .TBarContinue.Visible = True
    End With

    SaveGridTop = C1DataGrdList.Top
    SaveGridHeight = C1DataGrdList.Height
    If MyInquiryMode Then
      RbProcess.Visible = False
      RbPrint.Checked = True
      SetupScreen(False)
    Else
      SetupScreen(True)
    End If
    BuildDS2()
    RemapDS()
    DtPckInt.Value = MyInterestDate
    DtPckInt.Checked = False
    DtPckComp.Value = MyInterestDate

    PopulateStatus()
    Call FormatGrid()

  End Sub
  Public Sub SetupScreen(ByVal IsProcess As Boolean)
    If IsProcess Then
      BtnProcess.Visible = True
      BtnPrint.Visible = False
      LblMsg1.Visible = False
      LblMsg2.Visible = False
      TxtMsg.Visible = False
      LblPckInt.Visible = False
      DtPckInt.Visible = False
      LblPckComp.Visible = False
      DtPckComp.Visible = False
      RbDemand.Visible = False
      RbDupBill.Visible = False
      RbStatement.Visible = False
      RbWarrants.Visible = False
      LnkAltID.Visible = False
      TxtAltFormID.Visible = False
      C1DataGrdList.Top = C1DataGrdList.Top - 100
      C1DataGrdList.Height = C1DataGrdList.Height + 100
    Else
      BtnProcess.Visible = False
      BtnPrint.Visible = True
      C1DataGrdList.Top = SaveGridTop
      C1DataGrdList.Height = SaveGridHeight
      LblMsg1.Visible = True
      LblMsg2.Visible = True
      TxtMsg.Visible = True
      LblPckInt.Visible = True
      DtPckInt.Visible = True
      LblPckComp.Visible = True
      DtPckComp.Visible = True
      RbDemand.Visible = True
      RbDupBill.Visible = True
      RbStatement.Visible = True
      RbWarrants.Visible = True
      LnkAltID.Visible = True
      TxtAltFormID.Visible = True
    End If
  End Sub
  Private Sub BuildDS2()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Tax", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Fee", Type.GetType("System.Decimal"))
      .Columns.Add("Lien", Type.GetType("System.Decimal"))
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
      .Columns.Add("Balance", Type.GetType("System.Decimal"))
      .Columns.Add("Status", Type.GetType("System.String"))
    End With
    ds2.Tables.Add(myTable)
  End Sub
  Public Sub FormatGrid()

    With C1DataGrdList
      .Rebind(True)
      .DataSource = ds2.Tables(0)
    End With

    Call ShowGrid()
  End Sub
  Public Sub ShowGrid()
    With C1DataGrdList
      .Rebind(True)
      .FetchRowStyles = True
      .Columns(0).Caption = "Description"
      .Splits(0).DisplayColumns(0).Width = 190
      .Columns(1).Caption = "List #"
      .Splits(0).DisplayColumns(1).Width = 50
      .Columns(2).Caption = "Type"
      .Splits(0).DisplayColumns(2).Width = 35
      .Columns(3).Caption = "Year"
      .Splits(0).DisplayColumns(3).Width = 35
      .Columns(4).Caption = "Tax"
      .Splits(0).DisplayColumns(4).Width = 70
      .Columns(5).Caption = "Interest"
      .Splits(0).DisplayColumns(5).Width = 70
      .Columns(6).Caption = "Fee"
      .Splits(0).DisplayColumns(6).Width = 40
      .Columns(7).Caption = "Lien"
      .Splits(0).DisplayColumns(7).Width = 40
      .Columns(8).Caption = "Bond"
      .Splits(0).DisplayColumns(8).Width = 70
      .Columns(9).Caption = "Total"
      .Splits(0).DisplayColumns(9).Width = 70
      If ChkBalance.Checked Then
        .Columns(10).Caption = "Balance"
        .Splits(0).DisplayColumns(10).Width = 70
        .Splits(0).DisplayColumns(10).Visible = True
        .Splits(0).DisplayColumns(11).Visible = False
      Else
        .Splits(0).DisplayColumns(10).Visible = False
        .Columns(11).Caption = "Status"
        .Splits(0).DisplayColumns(11).Width = 60
        .Splits(0).DisplayColumns(11).Visible = True
      End If
    End With
  End Sub
  Private Sub FrmTXA094B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA09.SbpScreen.Text = "TXA094B"
    With MyFrmTXA09
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub C1DataGrdList_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles C1DataGrdList.FetchRowStyle
    If C1DataGrdList.Columns("Description").CellValue(e.Row) = "* TOTALS *" Then
      e.CellStyle.BackColor = System.Drawing.Color.Aqua
    End If

  End Sub
  Private Sub FrmTXA094B_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTXA09
      .TBarView.Enabled = False
      .TBarContinue.Visible = False
    End With

    MyFrmTXA094.Show()
    'Memory Cleanup
    myTXINV.CloseFile()
    myTXINV = Nothing
    MyFrmTXA094B = Nothing
  End Sub
  Private Sub SelGridItems()

    Dim I As Integer
    Dim J As Integer


    Array.Clear(SelListNo, 0, 25)
    Array.Clear(SelYear, 0, 25)
    Array.Clear(SelType, 0, 25)
    Array.Clear(SelProcessed, 0, 25)

    J = 0
    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 2)
      SelProcessed(J) = False
      SelListNo(J) = C1DataGrdList.Item(I, 1)
      SelType(J) = C1DataGrdList.Item(I, 2)
      SelYear(J) = C1DataGrdList.Item(I, 3)
      J = J + 1
      C1DataGrdList.Item(I, 0) = 0
    Next

    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub

  Public Sub ProcessGridItems(ByRef Complete As Boolean, ByVal WrkNext As Boolean, Optional ByRef I As Integer = -1)
    Dim Found As Boolean

    Complete = False
    Found = False
    For I = 0 To SelListNo.GetUpperBound(0)
      If SelListNo(I) > 0 And Not SelProcessed(I) Then
        If Not WrkNext Then
          MyFrmTXA09B = New FrmTXA09B
          With MyFrmTXA09B
            .WrkListNo = SelListNo(I)
            .WrkType = SelType(I)
            .WrkYear = SelYear(I)
            .MdiParent = Me.ParentForm
            .Show()
          End With
          Me.Hide()
        End If
        SelProcessed(I) = True
        Found = True
        Exit For
      End If
    Next

    If Not Found Then
      Complete = True
    End If

    MydsGroupItems.Clear()
  End Sub
  Private Sub ChkBalance_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkBalance.Click
    ShowGrid()
  End Sub
  Private Sub RemapDS()
    Dim WrkBalance As Decimal
    Dim WrkTax As Decimal
    Dim WrkInterest As Decimal
    Dim WrkFee As Decimal
    Dim WrkLien As Decimal
    Dim WrkBond As Decimal
    Dim WrkTotal As Decimal

    Dim I As Integer
    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    ds2.Clear()
    For I = 0 To (MydsGroupItems.Tables(0).Rows.Count - 1)
      With MydsGroupItems.Tables(0).Rows(I)
        dr = ds2.Tables(0).NewRow
        dr("desc") = .Item("desc")
        dr("listno") = .Item("listno")
        dr("type") = .Item("type")
        dr("year") = .Item("year")
        dr("tax") = .Item("tax")
        dr("interest") = .Item("interest")
        dr("fee") = .Item("fee")
        dr("lien") = .Item("lien")
        dr("bond") = .Item("bond")
        dr("total") = .Item("total")
        dr("balance") = .Item("balance")
        dr("status") = .Item("status")
        ds2.Tables(0).Rows.Add(dr)
        WrkTax = WrkTax + dr("Tax")
        WrkInterest = WrkInterest + dr("Interest")
        WrkFee = WrkFee + dr("Fee")
        WrkLien = WrkLien + dr("Lien")
        WrkBond = WrkBond + dr("Bond")
        WrkTotal = WrkTotal + dr("Total")
        WrkBalance = WrkBalance + dr("Balance")
      End With
    Next

    'Total Line
    If MydsGroupItems.Tables(0).Rows.Count > 0 Then
      dr = ds2.Tables(0).NewRow
      dr("Desc") = "* TOTALS *"
      dr("Tax") = WrkTax
      dr("Interest") = WrkInterest
      dr("Lien") = WrkLien
      dr("Fee") = WrkFee
      dr("Bond") = WrkBond
      dr("Total") = WrkTotal
      dr("Balance") = WrkBalance
      ds2.Tables(0).Rows.Add(dr)
    End If
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub PopulateStatus()
    Dim ListNo As Integer
    Dim Year As Integer
    Dim Type As String
    Dim I As Integer
    Dim WrkHighYear As Integer

    If ds2.Tables(0).Rows.Count = 0 Then Exit Sub
    WrkHighYear = 0

    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    For I = 0 To (ds2.Tables(0).Rows.Count - 1)
      With ds2.Tables(0).Rows(I)
        If Mid(.Item("desc"), 1, 5) = "* TOT" Then Exit For
        ListNo = .Item("listno")
        Type = .Item("type")
        Year = .Item("year")
        myTXINV.GetOneRecordP(ListNo, Year, Type)
        If WrkHighYear < Year Then
          TxtName.Text = Trim(myTXINV._NAME)
          TxtSname.Text = Trim(myTXINV._SNAME)
          TxtAdd1.Text = Trim(myTXINV._ADD1)
          TxtAdd2.Text = Trim(myTXINV._ADD2)
          TxtCity.Text = Trim(myTXINV._CITY)
          TxtState.Text = Trim(myTXINV._STATE)
          TxtZip5.Text = Format(myTXINV._ZIP5, "00000")
          TxtZip4.Text = Format(myTXINV._ZIP4, "0000")
          WrkHighYear = Year
        End If
        .Item("status") = Trim(myTXINV._STCD1) & Trim(myTXINV._STCD2) &
      Trim(myTXINV._STCD3) & Trim(myTXINV._STCD4) & Trim(myTXINV._STCD5)
      End With
    Next

    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub RefreshDS()
    Dim ListNo As Integer
    Dim Year As Integer
    Dim Type As String
    Dim I As Integer
    Dim WrkPrin As Decimal
    Dim WrkPrinDiff As Decimal
    Dim WrkPrinDiffTot As Decimal
    Dim WrkInterest As Decimal
    Dim WrkIntDiff As Decimal
    Dim WrkIntDiffTot As Decimal
    Dim WrkTotal As Decimal

    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    WrkPrinDiffTot = 0
    WrkIntDiffTot = 0

    For I = 0 To (ds2.Tables(0).Rows.Count - 1)
      With ds2.Tables(0).Rows(I)
        If Mid(.Item("desc"), 1, 5) <> "* TOT" Then
          ListNo = .Item("listno")
          Type = .Item("type")
          Year = .Item("year")
          If .Item("Balance") > 0 Then
            If myTOWN._TOWNBR = 219 And {"S", "W"}.Contains(Type) Then
              CalcInterest_219SW(ListNo, Type, Year, WrkPrin, WrkInterest)
            Else
              CalcInterest(ListNo, Type, Year, WrkPrin, WrkInterest)
            End If
            WrkPrinDiff = WrkPrin - .Item("tax")
            WrkPrinDiffTot = WrkPrinDiffTot + WrkPrinDiff
            WrkIntDiff = WrkInterest - .Item("interest")
            WrkIntDiffTot = WrkIntDiffTot + WrkIntDiff
            WrkTotal = .Item("total") + WrkPrinDiff + WrkIntDiff
            .Item("Tax") = Format(WrkPrin, "fixed")
            .Item("Interest") = Format(WrkInterest, "fixed")
            .Item("total") = Format(WrkTotal, "fixed")
          End If
        Else
          .Item("Tax") = Format(.Item("tax") + WrkPrinDiffTot, "fixed")
          .Item("Interest") = Format(.Item("interest") + WrkIntDiffTot, "fixed")
          .Item("total") = Format(.Item("total") + WrkPrinDiffTot + WrkIntDiffTot, "fixed")
        End If
      End With
    Next

    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Public Sub CalcInterest(ByVal Listno As Integer, ByVal Type As String, ByVal Year As Integer,
  ByRef OutPrin As Decimal, ByRef OutInterest As Decimal)
    Dim mycashint As CASHINT.MyData

    mycashint = New CASHINT.mydata(MyDBConnect)
    With mycashint
      .In_IntDate = DtPckInt.Value
      .In_ListNo = Listno
      .In_Type = Type
      .In_Year = Year
      .CalcInterest()
      OutPrin = Format(.Out_Prin(), "standard")
      OutInterest = Format(.Out_Int(), "standard")
    End With
    mycashint.CloseFiles()
    mycashint = Nothing
  End Sub
  Public Sub CalcInterest_219SW(ByVal Listno As Integer, ByVal Type As String, ByVal Year As Integer,
  ByRef OutPrin As Decimal, ByRef OutInterest As Decimal)
    Dim mycashint As CASHINT.MyData
    Dim WrkType2 As String
    Dim WrkInterest As Decimal
    Dim WrkOrigInterest As Decimal
    Dim WrkDiff As Decimal
    'MK 7/16/25 Begin
    Dim WrkNoType2 As Boolean
    'MK 7/16/25 End

    If Type = "S" Then
      WrkType2 = "W"
    Else
      WrkType2 = "S"
    End If
    'MK 7/16/25 Begin
    WrkNoType2 = False
    'MK 7/16/25 End

    mycashint = New CASHINT.MyData(myDBConnect)
    With mycashint
      .In_IntDate = DtPckInt.Value
      .In_ListNo = Listno
      .In_Type = Type
      .In_Year = Year
      .CalcInterest()
      OutPrin = Format(.Out_Prin(), "standard")
      WrkInterest = Format(.Out_Int(), "standard")
      WrkOrigInterest = Format(.Out_IntOrig(), "standard")
    End With

    If WrkOrigInterest > 0 And WrkInterest <> WrkOrigInterest Then
      mycashint = New CASHINT.MyData(myDBConnect)
      With mycashint
        .In_IntDate = DtPckInt.Value
        .In_ListNo = Listno
        .In_Type = WrkType2
        .In_Year = Year
        .CalcInterest()
        If .Out_IntOrig > 0 And .Out_ProfMinInt > WrkOrigInterest + .Out_IntOrig Then
          WrkDiff = .Out_ProfMinInt * (WrkOrigInterest / (WrkOrigInterest + .Out_IntOrig))
          WrkOrigInterest = WrkDiff
        End If
        'MK 7/16/25 Begin
        'MK 7/23/25 Begin
        'If .Out_Tot = 0 Then
        If .Out_Tot = 0 And .Out_ProfMinInt = 0 Then
          'MK 7/23/25 End
          WrkNoType2 = True
        End If
        'MK 7/16/25 End
      End With
    End If
    OutInterest = WrkOrigInterest
    'MK 7/16/25 Begin
    If WrkNoType2 Then
      OutInterest = WrkInterest
    End If
    'MK 7/16/25 End
    mycashint.CloseFiles()
    mycashint = Nothing
  End Sub
  Private Sub DtPckInt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtPckInt.ValueChanged
    RefreshDS()
  End Sub

  Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
    PrtOnline(ds2)
  End Sub
  Private Sub RbStatement_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbStatement.Click
    TxtMsg.Enabled = True
  End Sub
  Private Sub RbDemand_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbDemand.Click
    TxtMsg.Enabled = True
  End Sub
  Private Sub RbWarrants_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbWarrants.Click
    TxtMsg.Enabled = True
  End Sub
  Private Sub RbDupBill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbDupBill.Click
    TxtMsg.Enabled = False
  End Sub
  Private Sub LnkAltID_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkAltID.LinkClicked
    MyFrmListAltID = New FrmListAltID
    MyFrmListAltID.MdiParent = Me.ParentForm
    MyFrmListAltID.Show()
  End Sub


  Private Sub RbProcess_Click(sender As Object, e As EventArgs) Handles RbProcess.Click
    SetupScreen(True)
  End Sub
  Private Sub RbPrint_Click(sender As Object, e As EventArgs) Handles RbPrint.Click
    SetupScreen(False)
  End Sub
  Private Sub BtnProcess_Click(sender As Object, e As EventArgs) Handles BtnProcess.Click
    MyFrmTXA09.TBarContinue.Visible = False
    SelGridItems()
    ProcessGridItems(False, False, 0)
    'ds2.Clear()
  End Sub
End Class






