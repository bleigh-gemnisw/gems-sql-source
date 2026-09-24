Public Class FrmTX4042
  Inherits System.Windows.Forms.Form
  Dim MyTXINV As TXINV.MyData
  Dim ds As DataSet = New DataSet
  Dim WrkTotAmtDue As Decimal
  Dim WrkTotInterest As Decimal
  Dim WrkTotLien As Decimal
  Dim WrkTotFee As Decimal
  Dim WrkTotBond As Decimal
  Dim WrkAsofDt As Date
  Friend WithEvents RbNoName1 As System.Windows.Forms.RadioButton
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbBalTotDue As System.Windows.Forms.RadioButton
  Friend WithEvents RbBalAmtDue As System.Windows.Forms.RadioButton
  Friend WithEvents TBarFeeCD As System.Windows.Forms.ToolBarButton
  Dim WrkTotBalance As Decimal
  Friend WithEvents DtPckAsof As DateTimePicker
  Friend WithEvents lblasof As Label
  Friend WithEvents ChkUseasof As CheckBox
  Dim SaveSearch As String

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
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents DtPckComp As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents DtPckInt As System.Windows.Forms.DateTimePicker
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents TbMain As System.Windows.Forms.ToolBar
  Friend WithEvents TBarFind As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarRemove As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarClear As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarUpdate As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarSep1 As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarRecalc As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarStatusCD As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarSep2 As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarComment As System.Windows.Forms.ToolBarButton
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents LblTotAmtDue As System.Windows.Forms.Label
  Friend WithEvents LblTotInterest As System.Windows.Forms.Label
  Friend WithEvents LblTotBond As System.Windows.Forms.Label
  Friend WithEvents LBlTotLien As System.Windows.Forms.Label
  Friend WithEvents LblTotFee As System.Windows.Forms.Label
  Friend WithEvents LblTotBalance As System.Windows.Forms.Label
  Friend WithEvents TxtZip5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents TxtAdd2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtAdd1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtSname As System.Windows.Forms.TextBox
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents ChkEdit As System.Windows.Forms.CheckBox
  Friend WithEvents GrpAddr As System.Windows.Forms.GroupBox
  Friend WithEvents TxtZip4 As System.Windows.Forms.TextBox
  Friend WithEvents TBarSep3 As System.Windows.Forms.ToolBarButton
  Friend WithEvents GrpEdit As System.Windows.Forms.GroupBox
  Friend WithEvents RbNoNames As System.Windows.Forms.RadioButton
  Friend WithEvents RbAll As System.Windows.Forms.RadioButton
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTX4042))
    Me.label1 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.DtPckComp = New System.Windows.Forms.DateTimePicker()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.DtPckInt = New System.Windows.Forms.DateTimePicker()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarFind = New System.Windows.Forms.ToolBarButton()
    Me.TBarRemove = New System.Windows.Forms.ToolBarButton()
    Me.TBarClear = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep1 = New System.Windows.Forms.ToolBarButton()
    Me.TBarRecalc = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep2 = New System.Windows.Forms.ToolBarButton()
    Me.TBarStatusCD = New System.Windows.Forms.ToolBarButton()
    Me.TBarFeeCD = New System.Windows.Forms.ToolBarButton()
    Me.TBarComment = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep3 = New System.Windows.Forms.ToolBarButton()
    Me.TBarUpdate = New System.Windows.Forms.ToolBarButton()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.LblTotAmtDue = New System.Windows.Forms.Label()
    Me.LblTotInterest = New System.Windows.Forms.Label()
    Me.LblTotBond = New System.Windows.Forms.Label()
    Me.LBlTotLien = New System.Windows.Forms.Label()
    Me.LblTotFee = New System.Windows.Forms.Label()
    Me.LblTotBalance = New System.Windows.Forms.Label()
    Me.GrpAddr = New System.Windows.Forms.GroupBox()
    Me.TxtZip4 = New System.Windows.Forms.TextBox()
    Me.TxtZip5 = New System.Windows.Forms.TextBox()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtAdd2 = New System.Windows.Forms.TextBox()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.TxtAdd1 = New System.Windows.Forms.TextBox()
    Me.TxtSname = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.ChkEdit = New System.Windows.Forms.CheckBox()
    Me.GrpEdit = New System.Windows.Forms.GroupBox()
    Me.RbNoName1 = New System.Windows.Forms.RadioButton()
    Me.RbNoNames = New System.Windows.Forms.RadioButton()
    Me.RbAll = New System.Windows.Forms.RadioButton()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbBalTotDue = New System.Windows.Forms.RadioButton()
    Me.RbBalAmtDue = New System.Windows.Forms.RadioButton()
    Me.DtPckAsof = New System.Windows.Forms.DateTimePicker()
    Me.lblasof = New System.Windows.Forms.Label()
    Me.ChkUseasof = New System.Windows.Forms.CheckBox()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpAddr.SuspendLayout()
    Me.GrpEdit.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'label1
    '
    Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label1.Location = New System.Drawing.Point(8, 16)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(48, 16)
    Me.label1.TabIndex = 5
    Me.label1.Text = "Name"
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(8, 56)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(48, 16)
    Me.Label3.TabIndex = 7
    Me.Label3.Text = "Address"
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColMove = False
    Me.C1DataGrdList.AllowColSelect = False
    Me.C1DataGrdList.AllowDrag = True
    Me.C1DataGrdList.AllowFilter = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AllowSort = False
    Me.C1DataGrdList.AllowUpdate = False
    Me.C1DataGrdList.AlternatingRows = True
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(0, 120)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.Size = New System.Drawing.Size(776, 176)
    Me.C1DataGrdList.TabIndex = 176
    Me.C1DataGrdList.Text = "C1TrueDBGrid1"
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    '
    'Label6
    '
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(583, 28)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(92, 16)
    Me.Label6.TabIndex = 185
    Me.Label6.Text = "Compliance Date"
    '
    'DtPckComp
    '
    Me.DtPckComp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckComp.Location = New System.Drawing.Point(679, 26)
    Me.DtPckComp.Name = "DtPckComp"
    Me.DtPckComp.Size = New System.Drawing.Size(88, 20)
    Me.DtPckComp.TabIndex = 184
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(583, 8)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(72, 16)
    Me.Label5.TabIndex = 183
    Me.Label5.Text = "Interest Date"
    '
    'DtPckInt
    '
    Me.DtPckInt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckInt.Location = New System.Drawing.Point(679, 6)
    Me.DtPckInt.Name = "DtPckInt"
    Me.DtPckInt.Size = New System.Drawing.Size(88, 20)
    Me.DtPckInt.TabIndex = 182
    Me.DtPckInt.Value = New Date(2023, 8, 30, 15, 47, 9, 0)
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.White
    Me.ImageList1.Images.SetKeyName(0, "")
    Me.ImageList1.Images.SetKeyName(1, "")
    Me.ImageList1.Images.SetKeyName(2, "")
    Me.ImageList1.Images.SetKeyName(3, "")
    Me.ImageList1.Images.SetKeyName(4, "")
    Me.ImageList1.Images.SetKeyName(5, "")
    Me.ImageList1.Images.SetKeyName(6, "")
    Me.ImageList1.Images.SetKeyName(7, "")
    '
    'TbMain
    '
    Me.TbMain.Anchor = System.Windows.Forms.AnchorStyles.Bottom
    Me.TbMain.AutoSize = False
    Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarFind, Me.TBarRemove, Me.TBarClear, Me.TBarSep1, Me.TBarRecalc, Me.TBarSep2, Me.TBarStatusCD, Me.TBarFeeCD, Me.TBarComment, Me.TBarSep3, Me.TBarUpdate})
    Me.TbMain.Dock = System.Windows.Forms.DockStyle.None
    Me.TbMain.DropDownArrows = True
    Me.TbMain.ImageList = Me.ImageList1
    Me.TbMain.Location = New System.Drawing.Point(0, 316)
    Me.TbMain.Name = "TbMain"
    Me.TbMain.ShowToolTips = True
    Me.TbMain.Size = New System.Drawing.Size(537, 57)
    Me.TbMain.TabIndex = 190
    '
    'TBarFind
    '
    Me.TBarFind.ImageIndex = 3
    Me.TBarFind.Name = "TBarFind"
    Me.TBarFind.Text = "&Find Accts"
    '
    'TBarRemove
    '
    Me.TBarRemove.ImageIndex = 4
    Me.TBarRemove.Name = "TBarRemove"
    Me.TBarRemove.Text = "&Remove"
    '
    'TBarClear
    '
    Me.TBarClear.ImageIndex = 1
    Me.TBarClear.Name = "TBarClear"
    Me.TBarClear.Text = "&Clear All"
    '
    'TBarSep1
    '
    Me.TBarSep1.Name = "TBarSep1"
    Me.TBarSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
    '
    'TBarRecalc
    '
    Me.TBarRecalc.ImageIndex = 2
    Me.TBarRecalc.Name = "TBarRecalc"
    Me.TBarRecalc.Text = "Reca&lc"
    '
    'TBarSep2
    '
    Me.TBarSep2.Name = "TBarSep2"
    Me.TBarSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
    '
    'TBarStatusCD
    '
    Me.TBarStatusCD.ImageIndex = 7
    Me.TBarStatusCD.Name = "TBarStatusCD"
    Me.TBarStatusCD.Text = "&Status Cd"
    '
    'TBarFeeCD
    '
    Me.TBarFeeCD.ImageIndex = 7
    Me.TBarFeeCD.Name = "TBarFeeCD"
    Me.TBarFeeCD.Text = "Fee Cd"
    '
    'TBarComment
    '
    Me.TBarComment.ImageIndex = 5
    Me.TBarComment.Name = "TBarComment"
    Me.TBarComment.Text = "Co&mment"
    '
    'TBarSep3
    '
    Me.TBarSep3.Name = "TBarSep3"
    Me.TBarSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
    '
    'TBarUpdate
    '
    Me.TBarUpdate.ImageIndex = 0
    Me.TBarUpdate.Name = "TBarUpdate"
    Me.TBarUpdate.Text = "Update &Addr"
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(303, 297)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(40, 16)
    Me.Label2.TabIndex = 192
    Me.Label2.Text = "Totals"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'LblTotAmtDue
    '
    Me.LblTotAmtDue.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotAmtDue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblTotAmtDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotAmtDue.Location = New System.Drawing.Point(351, 297)
    Me.LblTotAmtDue.Name = "LblTotAmtDue"
    Me.LblTotAmtDue.Size = New System.Drawing.Size(80, 20)
    Me.LblTotAmtDue.TabIndex = 198
    Me.LblTotAmtDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotInterest
    '
    Me.LblTotInterest.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotInterest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblTotInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotInterest.Location = New System.Drawing.Point(431, 297)
    Me.LblTotInterest.Name = "LblTotInterest"
    Me.LblTotInterest.Size = New System.Drawing.Size(56, 20)
    Me.LblTotInterest.TabIndex = 199
    Me.LblTotInterest.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotBond
    '
    Me.LblTotBond.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotBond.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblTotBond.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotBond.Location = New System.Drawing.Point(583, 297)
    Me.LblTotBond.Name = "LblTotBond"
    Me.LblTotBond.Size = New System.Drawing.Size(72, 20)
    Me.LblTotBond.TabIndex = 200
    Me.LblTotBond.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LBlTotLien
    '
    Me.LBlTotLien.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LBlTotLien.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LBlTotLien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LBlTotLien.Location = New System.Drawing.Point(534, 297)
    Me.LBlTotLien.Name = "LBlTotLien"
    Me.LBlTotLien.Size = New System.Drawing.Size(48, 20)
    Me.LBlTotLien.TabIndex = 201
    Me.LBlTotLien.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotFee
    '
    Me.LblTotFee.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotFee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblTotFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotFee.Location = New System.Drawing.Point(486, 297)
    Me.LblTotFee.Name = "LblTotFee"
    Me.LblTotFee.Size = New System.Drawing.Size(48, 20)
    Me.LblTotFee.TabIndex = 202
    Me.LblTotFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotBalance
    '
    Me.LblTotBalance.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotBalance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblTotBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotBalance.Location = New System.Drawing.Point(655, 297)
    Me.LblTotBalance.Name = "LblTotBalance"
    Me.LblTotBalance.Size = New System.Drawing.Size(80, 20)
    Me.LblTotBalance.TabIndex = 203
    Me.LblTotBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
    Me.GrpAddr.Location = New System.Drawing.Point(62, -5)
    Me.GrpAddr.Name = "GrpAddr"
    Me.GrpAddr.Size = New System.Drawing.Size(273, 120)
    Me.GrpAddr.TabIndex = 0
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
    'ChkEdit
    '
    Me.ChkEdit.Location = New System.Drawing.Point(343, 3)
    Me.ChkEdit.Name = "ChkEdit"
    Me.ChkEdit.Size = New System.Drawing.Size(48, 16)
    Me.ChkEdit.TabIndex = 212
    Me.ChkEdit.Text = "&Edit"
    '
    'GrpEdit
    '
    Me.GrpEdit.Controls.Add(Me.RbNoName1)
    Me.GrpEdit.Controls.Add(Me.RbNoNames)
    Me.GrpEdit.Controls.Add(Me.RbAll)
    Me.GrpEdit.Location = New System.Drawing.Point(343, 27)
    Me.GrpEdit.Name = "GrpEdit"
    Me.GrpEdit.Size = New System.Drawing.Size(96, 72)
    Me.GrpEdit.TabIndex = 215
    Me.GrpEdit.TabStop = False
    Me.GrpEdit.Text = "Edit What?"
    Me.GrpEdit.Visible = False
    '
    'RbNoName1
    '
    Me.RbNoName1.Location = New System.Drawing.Point(8, 48)
    Me.RbNoName1.Name = "RbNoName1"
    Me.RbNoName1.Size = New System.Drawing.Size(80, 16)
    Me.RbNoName1.TabIndex = 217
    Me.RbNoName1.Text = "No Name 1"
    '
    'RbNoNames
    '
    Me.RbNoNames.Checked = True
    Me.RbNoNames.Location = New System.Drawing.Point(8, 32)
    Me.RbNoNames.Name = "RbNoNames"
    Me.RbNoNames.Size = New System.Drawing.Size(80, 16)
    Me.RbNoNames.TabIndex = 216
    Me.RbNoNames.TabStop = True
    Me.RbNoNames.Text = "No Names"
    '
    'RbAll
    '
    Me.RbAll.Location = New System.Drawing.Point(8, 16)
    Me.RbAll.Name = "RbAll"
    Me.RbAll.Size = New System.Drawing.Size(72, 16)
    Me.RbAll.TabIndex = 215
    Me.RbAll.Text = "All Lines"
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(8, 99)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(48, 16)
    Me.Label4.TabIndex = 216
    Me.Label4.Text = "City/ST"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbBalTotDue)
    Me.GroupBox1.Controls.Add(Me.RbBalAmtDue)
    Me.GroupBox1.Location = New System.Drawing.Point(479, 73)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(288, 38)
    Me.GroupBox1.TabIndex = 217
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Amount Due/Balance "
    '
    'RbBalTotDue
    '
    Me.RbBalTotDue.Location = New System.Drawing.Point(149, 14)
    Me.RbBalTotDue.Name = "RbBalTotDue"
    Me.RbBalTotDue.Size = New System.Drawing.Size(141, 20)
    Me.RbBalTotDue.TabIndex = 216
    Me.RbBalTotDue.Text = "Based on Total Due"
    '
    'RbBalAmtDue
    '
    Me.RbBalAmtDue.Checked = True
    Me.RbBalAmtDue.Location = New System.Drawing.Point(8, 14)
    Me.RbBalAmtDue.Name = "RbBalAmtDue"
    Me.RbBalAmtDue.Size = New System.Drawing.Size(141, 17)
    Me.RbBalAmtDue.TabIndex = 215
    Me.RbBalAmtDue.TabStop = True
    Me.RbBalAmtDue.Text = "Based on Interest Date"
    '
    'DtPckAsof
    '
    Me.DtPckAsof.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckAsof.Location = New System.Drawing.Point(679, 48)
    Me.DtPckAsof.Name = "DtPckAsof"
    Me.DtPckAsof.Size = New System.Drawing.Size(88, 20)
    Me.DtPckAsof.TabIndex = 218
    Me.DtPckAsof.Value = New Date(2023, 8, 31, 0, 0, 0, 0)
    '
    'lblasof
    '
    Me.lblasof.Location = New System.Drawing.Point(583, 50)
    Me.lblasof.Name = "lblasof"
    Me.lblasof.Size = New System.Drawing.Size(60, 16)
    Me.lblasof.TabIndex = 219
    Me.lblasof.Text = "As of Date"
    '
    'ChkUseasof
    '
    Me.ChkUseasof.Location = New System.Drawing.Point(479, 48)
    Me.ChkUseasof.Name = "ChkUseasof"
    Me.ChkUseasof.Size = New System.Drawing.Size(98, 16)
    Me.ChkUseasof.TabIndex = 220
    Me.ChkUseasof.Text = "Use as of date"
    '
    'FrmTX4042
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(786, 374)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkUseasof)
    Me.Controls.Add(Me.DtPckAsof)
    Me.Controls.Add(Me.lblasof)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.GrpEdit)
    Me.Controls.Add(Me.ChkEdit)
    Me.Controls.Add(Me.GrpAddr)
    Me.Controls.Add(Me.LblTotBalance)
    Me.Controls.Add(Me.LblTotFee)
    Me.Controls.Add(Me.LBlTotLien)
    Me.Controls.Add(Me.LblTotBond)
    Me.Controls.Add(Me.LblTotInterest)
    Me.Controls.Add(Me.LblTotAmtDue)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TbMain)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.DtPckComp)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.DtPckInt)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX4042"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Online Statements"
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpAddr.ResumeLayout(False)
    Me.GrpAddr.PerformLayout()
    Me.GrpEdit.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmTX4042_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXINV = New TXINV.MyData(myDBConnect)

    MyFrmTX404.TBarPrint.Enabled = False
    TBarUpdate.Enabled = False
    TBarRecalc.Enabled = False
    TBarStatusCD.Enabled = False
    TBarFeeCD.Enabled = False
    TBarComment.Enabled = False
    ChkEdit.Enabled = False
    SaveSearch = String.Empty

    lblasof.Visible = False
    DtPckAsof.Visible = False

    DtPckComp.Value = Date.Now
    DtPckInt.Value = Date.Now
    Call BuildDS()

  End Sub
  Public Sub ShowGrid()
    Dim I As Integer
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    RefreshDS()

    With C1DataGrdList
      .DataSource = myds.Tables(0)
      .Refresh()
      .Splits(0).DisplayColumns(0).Visible = False
      .Columns(1).Caption = "List#"
      .Splits(0).DisplayColumns(1).Width = 45
      .Splits(0).DisplayColumns(2).Width = 30
      .Splits(0).DisplayColumns(3).Visible = False
      .Splits(0).DisplayColumns(4).Width = 30
      .Splits(0).DisplayColumns(5).Width = 150
      .Splits(0).DisplayColumns(6).Visible = False
      .Splits(0).DisplayColumns(7).Width = 75
      .Splits(0).DisplayColumns(8).Width = 75
      .Splits(0).DisplayColumns(9).Width = 60
      .Splits(0).DisplayColumns(10).Width = 40
      .Splits(0).DisplayColumns(11).Width = 35
      .Splits(0).DisplayColumns(12).Width = 60
      .Splits(0).DisplayColumns(13).Width = 75
      For I = 14 To 22
        .Splits(0).DisplayColumns(I).Visible = False
      Next
      'Status codes
      .Splits(0).DisplayColumns(23).Visible = False
      .Splits(0).DisplayColumns(24).Visible = False
      .Splits(0).DisplayColumns(25).Visible = False
      .Splits(0).DisplayColumns(26).Visible = False
      .Splits(0).DisplayColumns(27).Visible = False
      .Splits(0).DisplayColumns(28).Width = 50
      'Comment
      .Splits(0).DisplayColumns(29).Visible = False
      'Fee Codes
      For I = 30 To 40
        .Splits(0).DisplayColumns(I).Visible = False
      Next
    End With

    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmTX4042_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX404.SbpScreen.Text = "TX4042"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  End Sub

  Private Sub FrmTX4042_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    End
  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Accept", Type.GetType("System.Boolean"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("PropDesc2", Type.GetType("System.String"))
      .Columns.Add("TotDue", Type.GetType("System.Decimal"))
      .Columns.Add("AmtDue", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Fees", Type.GetType("System.Decimal"))
      .Columns.Add("Liens", Type.GetType("System.Decimal"))
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
      .Columns.Add("Balance", Type.GetType("System.Decimal"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Sname", Type.GetType("System.String"))
      .Columns.Add("Add1", Type.GetType("System.String"))
      .Columns.Add("Add2", Type.GetType("System.String"))
      .Columns.Add("City", Type.GetType("System.String"))
      .Columns.Add("State", Type.GetType("System.String"))
      .Columns.Add("Zip5", Type.GetType("System.Int32"))
      .Columns.Add("Zip4", Type.GetType("System.Int32"))
      .Columns.Add("VolPage", Type.GetType("System.String"))
      .Columns.Add("StCd1", Type.GetType("System.String"))
      .Columns.Add("StCd2", Type.GetType("System.String"))
      .Columns.Add("StCd3", Type.GetType("System.String"))
      .Columns.Add("StCd4", Type.GetType("System.String"))
      .Columns.Add("StCd5", Type.GetType("System.String"))
      .Columns.Add("Status", Type.GetType("System.String"))
      .Columns.Add("ccm", Type.GetType("System.String"))
      .Columns.Add("Fec1", Type.GetType("System.String"))
      .Columns.Add("Fec2", Type.GetType("System.String"))
      .Columns.Add("Fec3", Type.GetType("System.String"))
      .Columns.Add("Fec4", Type.GetType("System.String"))
      .Columns.Add("Fec5", Type.GetType("System.String"))
      .Columns.Add("Fed1", Type.GetType("System.Decimal"))
      .Columns.Add("Fed2", Type.GetType("System.Decimal"))
      .Columns.Add("Fed3", Type.GetType("System.Decimal"))
      .Columns.Add("Fed4", Type.GetType("System.Decimal"))
      .Columns.Add("Fed5", Type.GetType("System.Decimal"))
      .Columns.Add("MVFee", Type.GetType("System.Decimal"))
    End With
    myds.Tables.Add(myTable)

    mydsVerify = myds.Clone
  End Sub
  Private Sub RefreshDS()
    Dim dstxbatch As DataSet = New DataSet
    Dim WrkTXType() As String
    Dim ListNo As Integer
    Dim Year As Integer
    Dim Type As String
    Dim WrkFamily As String
    Dim I As Integer
    Dim WrkInterest As Decimal
    Dim WrkBond As Decimal
    Dim WrkLien As Decimal
    Dim WrkFees As Decimal
    Dim WrkDue As Decimal
    Dim WrkTax As Decimal

    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    WrkTotAmtDue = 0
    WrkTotInterest = 0
    WrkTotLien = 0
    WrkTotFee = 0
    WrkTotBond = 0
    WrkTotBalance = 0

    For I = 0 To (myds.Tables(0).Rows.Count - 1)
      ListNo = myds.Tables(0).Rows(I).Item("ListNo")
      Year = myds.Tables(0).Rows(I).Item("Year")
      Type = myds.Tables(0).Rows(I).Item("Type")
      WrkTXType = LookupType(Type)
      WrkFamily = WrkTXType(1)
      MyTXINV.GetOneRecordP(ListNo, Year, Type)
      With myds.Tables(0).Rows(I)
        If TxtName.Text = "" Then
          TxtName.Text = Trim(MyTXINV._NAME)
          TxtSname.Text = Trim(MyTXINV._SNAME)
          TxtAdd1.Text = Trim(MyTXINV._ADD1)
          TxtAdd2.Text = Trim(MyTXINV._ADD2)
          TxtCity.Text = Trim(MyTXINV._CITY)
          TxtState.Text = Trim(MyTXINV._STATE)
          TxtZip5.Text = Format(MyTXINV._ZIP5, "00000")
          TxtZip4.Text = Format(MyTXINV._ZIP4, "0000")
        End If
        Select Case WrkFamily
          Case "M", "S"
            .Item("propdesc") = Trim(MyTXINV._MAKE) & " " & MyTXINV._MVYR & " " & Trim(MyTXINV._IMVREG)
            .Item("propdesc2") = Trim(MyTXINV._IMVIDNo)
          Case Else
            .Item("propdesc") = Trim(MyTXINV._LOCNo) & " " & Trim(MyTXINV._LOC)
            .Item("propdesc2") = ""
        End Select
        .Item("volpage") = Trim(MyTXINV._VOL) & " " & Trim(MyTXINV._IPAGE)
        If ChkUseasof.Checked Then
          CalcInterestasof(MyTXINV._LISTNo, MyTXINV._TYPE, MyTXINV._YEAR, WrkInterest, WrkFees, WrkLien, WrkBond, WrkTax, WrkDue)
        Else
          CalcInterest(MyTXINV._LISTNo, MyTXINV._TYPE, MyTXINV._YEAR, WrkInterest, WrkFees, WrkLien, WrkBond, WrkTax, WrkDue)
        End If
        .Item("amtdue") = Format(WrkDue - WrkBond - WrkFees - WrkLien - WrkInterest, "fixed")
        If RbBalTotDue.Checked Then
          .Item("amtdue") = .Item("amtdue") + .Item("totdue") - WrkTax
        End If
        If .Item("totdue") < 0 And .Item("amtdue") = 0 Then
          .Item("amtdue") = .Item("totdue")
        End If
        If .Item("totdue") = 0 Then
          .Item("totdue") = .Item("amtdue")
        End If
        .Item("Interest") = Format(WrkInterest, "fixed")
        .Item("fees") = WrkFees
        .Item("liens") = Format(WrkLien, "fixed")
        .Item("bond") = Format(WrkBond, "fixed")
        .Item("Balance") = Format(WrkDue, "fixed")
        If RbBalTotDue.Checked Then
          .Item("balance") = .Item("balance") + .Item("totdue") - WrkTax
        Else
          If .Item("totdue") < 0 And .Item("balance") = 0 Then
            .Item("balance") = .Item("totdue")
          End If
        End If
        WrkTotAmtDue = WrkTotAmtDue + .Item("amtdue")
        WrkTotInterest = WrkTotInterest + .Item("interest")
        WrkTotLien = WrkTotLien + .Item("liens")
        WrkTotFee = WrkTotFee + WrkFees
        WrkTotBond = WrkTotBond + .Item("bond")
        WrkTotBalance = WrkTotBalance + .Item("balance")
      End With
    Next

    ShowTotals()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub UpdateDS()
    Dim ListNo As Integer
    Dim Year As Integer
    Dim Type As String
    Dim WrkWhere As String
    Dim WrkSet As String
    Dim I As Integer

    For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
      ListNo = myds.Tables(0).Rows(I).Item("ListNo")
      Year = myds.Tables(0).Rows(I).Item("Year")
      Type = myds.Tables(0).Rows(I).Item("Type")
      MyTXINV.GetOneRecordP(ListNo, Year, Type)
      With myds.Tables(0).Rows(I)
        WrkWhere = " where list#=" & ListNo & " and year=" & Year & " and type='" & Type & "'"
        WrkSet = ""
        If RbAll.Checked Then
          MyTXINV._NAME = Replace(TxtName.Text, "'", "''")
          MyTXINV._SNAME = Replace(TxtSname.Text, "'", "''")
          WrkSet = "name='" & MyTXINV._NAME & "'"
          WrkSet = WrkSet & ",sname='" & MyTXINV._SNAME & "'"
        End If
        If RbNoName1.Checked Then
          MyTXINV._SNAME = Replace(TxtSname.Text, "'", "''")
          WrkSet = "sname='" & MyTXINV._SNAME & "'"
        End If
        MyTXINV._ADD1 = Replace(TxtAdd1.Text, "'", "''")
        If WrkSet = "" Then
          WrkSet = "add1='" & MyTXINV._ADD1 & "'"
        Else
          WrkSet = WrkSet & ",add1='" & MyTXINV._ADD1 & "'"
        End If
        MyTXINV._ADD2 = Replace(TxtAdd2.Text, "'", "''")
        WrkSet = WrkSet & ",add2='" & MyTXINV._ADD2 & "'"
        MyTXINV._CITY = TxtCity.Text
        WrkSet = WrkSet & ",city='" & MyTXINV._CITY & "'"
        MyTXINV._STATE = TxtState.Text
        WrkSet = WrkSet & ",state='" & MyTXINV._STATE & "'"
        MyTXINV._ZIP5 = MyUtils.CnvSng(TxtZip5.Text)
        WrkSet = WrkSet & ",zip5=" & MyTXINV._ZIP5
        MyTXINV._ZIP4 = MyUtils.CnvSng(TxtZip4.Text)
        WrkSet = WrkSet & ",zip4=" & MyTXINV._ZIP4
        MyTXINV._CHDATE = MyUtils.SetDBDate(DateTime.Today)
        WrkSet = WrkSet & ",chdate=" & MyTXINV._CHDATE
        MyTXINV._CHTIME = Format(DateTime.Now, "HHmmss")
        WrkSet = WrkSet & ",chtime=" & MyTXINV._CHTIME
      End With
      'MyTXINV.UpdateOneRecordP()
      WrkSet = " set " & WrkSet
      MyTXINV.RunUpdateQuery(WrkSet, WrkWhere)
    Next

    ChkEdit.Checked = False
  End Sub
  Public Sub CalcTotals()
    Dim I As Integer
    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    WrkTotAmtDue = 0
    WrkTotInterest = 0
    WrkTotLien = 0
    WrkTotFee = 0
    WrkTotBond = 0
    WrkTotBalance = 0

    For I = 0 To (myds.Tables(0).Rows.Count - 1)
      With myds.Tables(0).Rows(I)
        WrkTotAmtDue = WrkTotAmtDue + .Item("amtdue")
        WrkTotInterest = WrkTotInterest + .Item("interest")
        WrkTotLien = WrkTotLien + .Item("liens")
        WrkTotFee = WrkTotFee + .Item("fees")
        WrkTotBond = WrkTotBond + .Item("bond")
        WrkTotBalance = WrkTotBalance + .Item("balance")
      End With
    Next

    ShowTotals()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Public Sub CalcInterest(ByVal In_ListNo As Integer, ByVal In_Type As String, ByVal In_Year As Integer,
    ByRef OutInterest As Decimal, ByRef OutFee As Decimal, ByRef OutLien As Decimal, ByRef OutBond As Decimal,
    ByRef OutTax As Decimal, ByRef OutDue As Decimal)
    Dim mycashint As CASHINT.MyData

    mycashint = New CASHINT.MyData(myDBConnect)
    With mycashint
      .In_IntDate = DtPckInt.Value
      .In_ListNo = In_ListNo
      .In_Type = In_Type
      .In_Year = In_Year
      .CalcInterest()
      OutInterest = Format(.Out_Int(), "standard")
      OutFee = Format(.Out_Fee(), "standard")
      OutLien = Format(.Out_Lien(), "standard")
      OutBond = Format(.Out_Bond(), "standard")
      OutTax = Format(.Out_Prin(), "standard")
      OutDue = Format(.Out_Tot(), "standard")
    End With
  End Sub
  Public Sub CalcInterestasof(ByVal In_ListNo As Integer, ByVal In_Type As String, ByVal In_Year As Integer,
    ByRef OutInterest As Decimal, ByRef OutFee As Decimal, ByRef OutLien As Decimal, ByRef OutBond As Decimal,
    ByRef OutTax As Decimal, ByRef OutDue As Decimal)
    Dim MyCashAsof As CASHASOF.MyData
    WrkAsofDt = DtPckAsof.Value
    MyCashAsof = New CASHASOF.MyData(myDBConnect)
    With MyCashAsof
      .In_AsofDate = WrkAsofDt
      .In_ListNo = In_ListNo
      .In_Type = In_Type
      .In_Year = In_Year
      .CalcAsof()
      OutTax = Format(.Out_Prin(), "standard")
      OutInterest = Format(.Out_Int(), "standard")
      OutFee = Format(.Out_Fee(), "standard")
      OutBond = Format(.Out_Bond(), "standard")
      OutDue = Format(.Out_Tot(), "standard")
      OutLien = Format(.Out_Lien(), "standard")
      ' WrkGracePeriod = .Out_GracePeriod
    End With


  End Sub
  Private Sub ClearAll()
    TBarUpdate.Enabled = False
    TBarRecalc.Enabled = False
    TBarStatusCD.Enabled = False
    TBarFeeCD.Enabled = False
    TBarComment.Enabled = False
    ChkEdit.Enabled = False
    ChkEdit.Checked = False

    SaveSearch = TxtName.Text
    TxtName.Text = ""
    TxtSname.Text = ""
    TxtAdd1.Text = ""
    TxtAdd2.Text = ""
    TxtCity.Text = ""
    TxtState.Text = ""
    TxtZip5.Text = ""
    TxtZip4.Text = ""
    myds.Clear()

    WrkTotAmtDue = 0
    WrkTotInterest = 0
    WrkTotFee = 0
    WrkTotLien = 0
    WrkTotBond = 0
    WrkTotBalance = 0
    ShowTotals()
    SetEditColors()

  End Sub
  Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
    If e.Button Is TBarFind Then
      DoBtnFind()
      Exit Sub
    End If

    If e.Button Is TBarRemove Then
      DoBtnRemove()
      Exit Sub
    End If

    If e.Button Is TBarClear Then
      ClearAll()
      Exit Sub
    End If

    If e.Button Is TBarUpdate Then
      UpdateDS()
      Exit Sub
    End If

    If e.Button Is TBarRecalc Then
      RefreshDS()
      Exit Sub
    End If

    If e.Button Is TBarStatusCD Then
      MyFrmTX4042B = New FrmTX4042B
      MyFrmTX4042B.ShowDialog()
      Exit Sub
    End If

    If e.Button Is TBarFeeCD Then
      MyFrmTX4042D = New FrmTX4042D
      MyFrmTX4042D.ShowDialog()
      Exit Sub
    End If

    If e.Button Is TBarComment Then
      MyFrmTX4042C = New FrmTX4042C
      MyFrmTX4042C.ShowDialog()
      Exit Sub
    End If

  End Sub
  Private Sub ShowTotals()
    If WrkTotAmtDue <> 0 Or WrkTotInterest <> 0 Then
      LblTotAmtDue.Text = Format(WrkTotAmtDue, "Fixed")
      LblTotInterest.Text = Format(WrkTotInterest, "Fixed")
      LBlTotLien.Text = Format(WrkTotLien, "Fixed")
      LblTotFee.Text = Format(WrkTotFee, "Fixed")
      LblTotBond.Text = Format(WrkTotBond, "Fixed")
      LblTotBalance.Text = Format(WrkTotBalance, "Fixed")
    Else
      LblTotAmtDue.Text = ""
      LblTotInterest.Text = ""
      LBlTotLien.Text = ""
      LblTotFee.Text = ""
      LblTotBond.Text = ""
      LblTotBalance.Text = ""
    End If
  End Sub

  Private Sub C1DataGrdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.Click

  End Sub

  Private Sub ChkEdit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkEdit.CheckedChanged

    TxtName.ReadOnly = Not ChkEdit.Checked
    TxtSname.ReadOnly = Not ChkEdit.Checked
    TxtAdd1.ReadOnly = Not ChkEdit.Checked
    TxtAdd2.ReadOnly = Not ChkEdit.Checked
    TxtCity.ReadOnly = Not ChkEdit.Checked
    TxtState.ReadOnly = Not ChkEdit.Checked
    TxtZip5.ReadOnly = Not ChkEdit.Checked
    TxtZip4.ReadOnly = Not ChkEdit.Checked
    GrpEdit.Visible = ChkEdit.Checked
    SetEditColors()

  End Sub
  Private Sub DoBtnFind()
    MyFrmTX4041 = New FrmTX4041
    MyFrmTX4041.MdiParent = Me.ParentForm
    If TxtName.Text = String.Empty Then
      MyFrmTX4041.WrkName = SaveSearch
    Else
      MyFrmTX4041.WrkName = TxtName.Text
    End If
    MyFrmTX4041.WrkSname = TxtSname.Text
    MyFrmTX4041.WrkAdd1 = TxtAdd1.Text
    MyFrmTX4041.WrkAdd2 = TxtAdd2.Text
    MyFrmTX4041.WrkCity = TxtCity.Text
    MyFrmTX4041.Show()
    Me.Hide()
  End Sub
  Private Sub DoBtnRemove()
    Dim row As Integer
    If C1DataGrdList.SelectedRows.Count > 0 Then
      For Each row In C1DataGrdList.SelectedRows
        With myds.Tables(0).Rows(row)
          WrkTotAmtDue = WrkTotAmtDue - .Item("amtdue")
          WrkTotInterest = WrkTotInterest - .Item("interest")
          WrkTotLien = WrkTotLien - .Item("liens")
          WrkTotFee = WrkTotFee - .Item("fees")
          WrkTotBond = WrkTotBond - .Item("bond")
          WrkTotBalance = WrkTotBalance - .Item("balance")
        End With
        ShowTotals()
        myds.Tables(0).Rows(row).Delete()
        If C1DataGrdList.Splits(0).Rows.Count = 0 Then
          ClearAll()
        End If
        Exit For
      Next
    End If
    C1DataGrdList.SelectedRows.Clear()
  End Sub

  Private Sub FrmTX4042_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub

    If e.KeyCode = Keys.A Then
      UpdateDS()
    End If

    If e.KeyCode = Keys.C Then
      ClearAll()
    End If

    If e.KeyCode = Keys.F Then
      DoBtnFind()
    End If

    If e.KeyCode = Keys.L Then
      RefreshDS()
    End If

    If e.KeyCode = Keys.M Then
      MyFrmTX4042C = New FrmTX4042C
      MyFrmTX4042C.ShowDialog()
    End If

    If e.KeyCode = Keys.R Then
      DoBtnRemove()
    End If

    If e.KeyCode = Keys.S Then
      MyFrmTX4042B = New FrmTX4042B
      MyFrmTX4042B.ShowDialog()
    End If

  End Sub

  Private Sub RbAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbAll.Click
    SetEditColors()
  End Sub
  Private Sub SetEditColors()
    If ChkEdit.Checked Then
      TxtName.BackColor = Color.White
      TxtSname.BackColor = Color.White
      TxtAdd1.BackColor = Color.White
      TxtAdd2.BackColor = Color.White
      TxtCity.BackColor = Color.White
      TxtState.BackColor = Color.White
      TxtZip5.BackColor = Color.White
      TxtZip4.BackColor = Color.White
      If RbNoNames.Checked And ChkEdit.Enabled = True Then
        TxtName.BackColor = Color.Aqua
        TxtSname.BackColor = Color.Aqua
      End If
      If RbNoName1.Checked And ChkEdit.Enabled = True Then
        TxtName.BackColor = Color.Aqua
      End If
    Else
      TxtName.BackColor = Control.DefaultBackColor
      TxtSname.BackColor = Control.DefaultBackColor
      TxtAdd1.BackColor = Control.DefaultBackColor
      TxtAdd2.BackColor = Control.DefaultBackColor
      TxtCity.BackColor = Control.DefaultBackColor
      TxtState.BackColor = Control.DefaultBackColor
      TxtZip5.BackColor = Control.DefaultBackColor
      TxtZip4.BackColor = Control.DefaultBackColor
    End If
  End Sub
  Private Sub RbNoNames_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbNoNames.Click
    SetEditColors()
  End Sub
  Private Sub RbNoName1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbNoName1.Click
    SetEditColors()
  End Sub
  Private Sub RbBalAmtDue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbBalAmtDue.Click
    RefreshDS()
  End Sub
  Private Sub RbBalTotDue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbBalTotDue.Click
    RefreshDS()
  End Sub

  Private Sub ChkUseasof_CheckedChanged(sender As Object, e As EventArgs) Handles ChkUseasof.CheckedChanged
    If ChkUseasof.Checked Then
      lblasof.Visible = True
      DtPckAsof.Value = Date.Now
      DtPckAsof.Visible = True
      RefreshDS()
    Else
      lblasof.Visible = False
      DtPckAsof.Visible = False
      RefreshDS()
    End If


  End Sub

  Private Sub DtPckAsof_ValueChanged(sender As Object, e As EventArgs) Handles DtPckAsof.ValueChanged
    If ChkUseasof.Checked Then
      RefreshDS()
    End If
  End Sub
End Class








