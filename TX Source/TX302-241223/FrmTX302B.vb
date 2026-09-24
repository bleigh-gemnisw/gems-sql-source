Public Class FrmTX302B
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
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents DtPckInt As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents DtPckCompliance As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
  Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents RbSortZip As System.Windows.Forms.RadioButton
  Friend WithEvents RbSortList As System.Windows.Forms.RadioButton
  Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
  Friend WithEvents RbPrtList As System.Windows.Forms.RadioButton
  Friend WithEvents RbPrtWarrants As System.Windows.Forms.RadioButton
  Friend WithEvents RbPrtDemand As System.Windows.Forms.RadioButton
  Friend WithEvents RbPrtStatement As System.Windows.Forms.RadioButton
  Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
  Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtDist As System.Windows.Forms.TextBox
  Friend WithEvents TxtInvCode As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents ChkOmitSuspense As System.Windows.Forms.CheckBox
  Friend WithEvents RbPrtListAddr As System.Windows.Forms.RadioButton
  Friend WithEvents ChkPageNos As System.Windows.Forms.CheckBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtMsg As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents TxtOmitBelow As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents ChkDouble As System.Windows.Forms.CheckBox
  Friend WithEvents RbSortLoc As System.Windows.Forms.RadioButton
  Friend WithEvents RbSortSname As System.Windows.Forms.RadioButton
  Friend WithEvents ChkPostStatus As System.Windows.Forms.CheckBox
  Friend WithEvents TxtPostStatus As System.Windows.Forms.TextBox
  Friend WithEvents LnkPostStatus As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtStatus As System.Windows.Forms.TextBox
  Friend WithEvents LnkOmitStatus As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtBankCode As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents ChkInGracePeriod As System.Windows.Forms.CheckBox
  Friend WithEvents TxtPhase As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents LnkDistrict As System.Windows.Forms.LinkLabel
  Friend WithEvents RbPrtListStatus As System.Windows.Forms.RadioButton
  Friend WithEvents TxtOmitStatus As System.Windows.Forms.TextBox
  Friend WithEvents LnkStatus As System.Windows.Forms.LinkLabel
  Friend WithEvents RbPrtListLoc As System.Windows.Forms.RadioButton
  Friend WithEvents TxtOmitAbove As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents LnkAltID As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtAltFormID As System.Windows.Forms.TextBox
  Friend WithEvents RbSortDOB As System.Windows.Forms.RadioButton
  Friend WithEvents ChkOmitBanks As System.Windows.Forms.CheckBox
  Friend WithEvents BtnSaveMsg As Button
    Friend WithEvents RbPrtBalDueUB As RadioButton
    Friend WithEvents GrpWins As GroupBox
    Friend WithEvents Label7 As Label
  Friend WithEvents TxtOmitTotalBelow As TextBox
  Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTX302B))
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbPrtBalDueUB = New System.Windows.Forms.RadioButton()
    Me.LnkAltID = New System.Windows.Forms.LinkLabel()
    Me.TxtAltFormID = New System.Windows.Forms.TextBox()
    Me.RbPrtListLoc = New System.Windows.Forms.RadioButton()
    Me.RbPrtListStatus = New System.Windows.Forms.RadioButton()
    Me.ChkDouble = New System.Windows.Forms.CheckBox()
    Me.ChkPageNos = New System.Windows.Forms.CheckBox()
    Me.RbPrtListAddr = New System.Windows.Forms.RadioButton()
    Me.RbPrtList = New System.Windows.Forms.RadioButton()
    Me.RbPrtWarrants = New System.Windows.Forms.RadioButton()
    Me.RbPrtDemand = New System.Windows.Forms.RadioButton()
    Me.RbPrtStatement = New System.Windows.Forms.RadioButton()
    Me.TxtTypes = New System.Windows.Forms.TextBox()
    Me.TxtFromGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LnkTypes = New System.Windows.Forms.LinkLabel()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.DtPckInt = New System.Windows.Forms.DateTimePicker()
    Me.TxtToGLYear = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.DtPckCompliance = New System.Windows.Forms.DateTimePicker()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbSortDOB = New System.Windows.Forms.RadioButton()
    Me.RbSortSname = New System.Windows.Forms.RadioButton()
    Me.RbSortLoc = New System.Windows.Forms.RadioButton()
    Me.RbSortZip = New System.Windows.Forms.RadioButton()
    Me.RbSortList = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.ChkOmitBanks = New System.Windows.Forms.CheckBox()
    Me.TxtOmitAbove = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LnkDistrict = New System.Windows.Forms.LinkLabel()
    Me.TxtPhase = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.ChkInGracePeriod = New System.Windows.Forms.CheckBox()
    Me.TxtBankCode = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TxtOmitBelow = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.ChkOmitSuspense = New System.Windows.Forms.CheckBox()
    Me.TxtInvCode = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.TxtMsg = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.ChkPostStatus = New System.Windows.Forms.CheckBox()
    Me.TxtPostStatus = New System.Windows.Forms.TextBox()
    Me.LnkPostStatus = New System.Windows.Forms.LinkLabel()
    Me.TxtStatus = New System.Windows.Forms.TextBox()
    Me.LnkOmitStatus = New System.Windows.Forms.LinkLabel()
    Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
    Me.TxtOmitStatus = New System.Windows.Forms.TextBox()
    Me.LnkStatus = New System.Windows.Forms.LinkLabel()
    Me.BtnSaveMsg = New System.Windows.Forms.Button()
    Me.GrpWins = New System.Windows.Forms.GroupBox()
    Me.TxtOmitTotalBelow = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.GroupBox1.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GrpWins.SuspendLayout()
    Me.SuspendLayout()
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbPrtBalDueUB)
    Me.GroupBox1.Controls.Add(Me.LnkAltID)
    Me.GroupBox1.Controls.Add(Me.TxtAltFormID)
    Me.GroupBox1.Controls.Add(Me.RbPrtListLoc)
    Me.GroupBox1.Controls.Add(Me.RbPrtListStatus)
    Me.GroupBox1.Controls.Add(Me.ChkDouble)
    Me.GroupBox1.Controls.Add(Me.ChkPageNos)
    Me.GroupBox1.Controls.Add(Me.RbPrtListAddr)
    Me.GroupBox1.Controls.Add(Me.RbPrtList)
    Me.GroupBox1.Controls.Add(Me.RbPrtWarrants)
    Me.GroupBox1.Controls.Add(Me.RbPrtDemand)
    Me.GroupBox1.Controls.Add(Me.RbPrtStatement)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(12, 4)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(348, 139)
    Me.GroupBox1.TabIndex = 99
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Print Options"
    '
    'RbPrtBalDueUB
    '
    Me.RbPrtBalDueUB.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPrtBalDueUB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPrtBalDueUB.Location = New System.Drawing.Point(12, 93)
    Me.RbPrtBalDueUB.Name = "RbPrtBalDueUB"
    Me.RbPrtBalDueUB.Size = New System.Drawing.Size(153, 20)
    Me.RbPrtBalDueUB.TabIndex = 100
    Me.RbPrtBalDueUB.Text = "Balance Due UB"
    '
    'LnkAltID
    '
    Me.LnkAltID.AutoSize = True
    Me.LnkAltID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkAltID.Location = New System.Drawing.Point(211, 95)
    Me.LnkAltID.Name = "LnkAltID"
    Me.LnkAltID.Size = New System.Drawing.Size(97, 13)
    Me.LnkAltID.TabIndex = 99
    Me.LnkAltID.TabStop = True
    Me.LnkAltID.Text = "Alternative Form ID"
    '
    'TxtAltFormID
    '
    Me.TxtAltFormID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAltFormID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAltFormID.Location = New System.Drawing.Point(314, 92)
    Me.TxtAltFormID.MaxLength = 1
    Me.TxtAltFormID.Name = "TxtAltFormID"
    Me.TxtAltFormID.Size = New System.Drawing.Size(20, 20)
    Me.TxtAltFormID.TabIndex = 10
    Me.TxtAltFormID.TabStop = False
    '
    'RbPrtListLoc
    '
    Me.RbPrtListLoc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPrtListLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPrtListLoc.Location = New System.Drawing.Point(12, 73)
    Me.RbPrtListLoc.Name = "RbPrtListLoc"
    Me.RbPrtListLoc.Size = New System.Drawing.Size(153, 20)
    Me.RbPrtListLoc.TabIndex = 3
    Me.RbPrtListLoc.Text = "Delinquent List (Location)"
    '
    'RbPrtListStatus
    '
    Me.RbPrtListStatus.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPrtListStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPrtListStatus.Location = New System.Drawing.Point(12, 36)
    Me.RbPrtListStatus.Name = "RbPrtListStatus"
    Me.RbPrtListStatus.Size = New System.Drawing.Size(153, 20)
    Me.RbPrtListStatus.TabIndex = 1
    Me.RbPrtListStatus.Text = "Delinquent List (Status)"
    '
    'ChkDouble
    '
    Me.ChkDouble.AutoSize = True
    Me.ChkDouble.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkDouble.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkDouble.Location = New System.Drawing.Point(18, 119)
    Me.ChkDouble.Name = "ChkDouble"
    Me.ChkDouble.Size = New System.Drawing.Size(106, 17)
    Me.ChkDouble.TabIndex = 4
    Me.ChkDouble.TabStop = False
    Me.ChkDouble.Text = "Double Spaced?"
    '
    'ChkPageNos
    '
    Me.ChkPageNos.AutoSize = True
    Me.ChkPageNos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPageNos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkPageNos.Location = New System.Drawing.Point(207, 114)
    Me.ChkPageNos.Name = "ChkPageNos"
    Me.ChkPageNos.Size = New System.Drawing.Size(130, 17)
    Me.ChkPageNos.TabIndex = 8
    Me.ChkPageNos.TabStop = False
    Me.ChkPageNos.Text = "Show Page numbers?"
    '
    'RbPrtListAddr
    '
    Me.RbPrtListAddr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPrtListAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPrtListAddr.Location = New System.Drawing.Point(12, 56)
    Me.RbPrtListAddr.Name = "RbPrtListAddr"
    Me.RbPrtListAddr.Size = New System.Drawing.Size(153, 20)
    Me.RbPrtListAddr.TabIndex = 2
    Me.RbPrtListAddr.Text = "Delinquent List (Addr)"
    '
    'RbPrtList
    '
    Me.RbPrtList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPrtList.Checked = True
    Me.RbPrtList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPrtList.Location = New System.Drawing.Point(12, 16)
    Me.RbPrtList.Name = "RbPrtList"
    Me.RbPrtList.Size = New System.Drawing.Size(153, 20)
    Me.RbPrtList.TabIndex = 0
    Me.RbPrtList.TabStop = True
    Me.RbPrtList.Text = "Delinquent List (Name)"
    '
    'RbPrtWarrants
    '
    Me.RbPrtWarrants.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPrtWarrants.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPrtWarrants.Location = New System.Drawing.Point(202, 56)
    Me.RbPrtWarrants.Name = "RbPrtWarrants"
    Me.RbPrtWarrants.Size = New System.Drawing.Size(140, 20)
    Me.RbPrtWarrants.TabIndex = 7
    Me.RbPrtWarrants.Text = "Warrants"
    '
    'RbPrtDemand
    '
    Me.RbPrtDemand.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPrtDemand.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPrtDemand.Location = New System.Drawing.Point(202, 36)
    Me.RbPrtDemand.Name = "RbPrtDemand"
    Me.RbPrtDemand.Size = New System.Drawing.Size(140, 20)
    Me.RbPrtDemand.TabIndex = 6
    Me.RbPrtDemand.Text = "Demand Notices"
    '
    'RbPrtStatement
    '
    Me.RbPrtStatement.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPrtStatement.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPrtStatement.Location = New System.Drawing.Point(202, 16)
    Me.RbPrtStatement.Name = "RbPrtStatement"
    Me.RbPrtStatement.Size = New System.Drawing.Size(140, 20)
    Me.RbPrtStatement.TabIndex = 5
    Me.RbPrtStatement.Text = "Delinquent Statements"
    '
    'TxtTypes
    '
    Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTypes.Location = New System.Drawing.Point(316, 153)
    Me.TxtTypes.MaxLength = 20
    Me.TxtTypes.Name = "TxtTypes"
    Me.TxtTypes.Size = New System.Drawing.Size(116, 20)
    Me.TxtTypes.TabIndex = 5
    '
    'TxtFromGLYear
    '
    Me.TxtFromGLYear.Location = New System.Drawing.Point(105, 149)
    Me.TxtFromGLYear.MaxLength = 4
    Me.TxtFromGLYear.Name = "TxtFromGLYear"
    Me.TxtFromGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtFromGLYear.TabIndex = 0
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(9, 149)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(84, 16)
    Me.Label4.TabIndex = 11
    Me.Label4.Text = "Grand List Year"
    '
    'LnkTypes
    '
    Me.LnkTypes.Location = New System.Drawing.Point(238, 153)
    Me.LnkTypes.Name = "LnkTypes"
    Me.LnkTypes.Size = New System.Drawing.Size(72, 16)
    Me.LnkTypes.TabIndex = 4
    Me.LnkTypes.TabStop = True
    Me.LnkTypes.Text = "Select Types"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'DtPckInt
    '
    Me.DtPckInt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckInt.Location = New System.Drawing.Point(105, 173)
    Me.DtPckInt.Name = "DtPckInt"
    Me.DtPckInt.Size = New System.Drawing.Size(88, 20)
    Me.DtPckInt.TabIndex = 2
    Me.DtPckInt.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
    '
    'TxtToGLYear
    '
    Me.TxtToGLYear.Location = New System.Drawing.Point(169, 149)
    Me.TxtToGLYear.MaxLength = 4
    Me.TxtToGLYear.Name = "TxtToGLYear"
    Me.TxtToGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtToGLYear.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(141, 153)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(20, 16)
    Me.Label2.TabIndex = 20
    Me.Label2.Text = "To "
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(9, 177)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(84, 16)
    Me.Label3.TabIndex = 21
    Me.Label3.Text = "Interest Date"
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(9, 201)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(92, 16)
    Me.Label5.TabIndex = 23
    Me.Label5.Text = "Compliance Date"
    '
    'DtPckCompliance
    '
    Me.DtPckCompliance.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckCompliance.Location = New System.Drawing.Point(105, 197)
    Me.DtPckCompliance.Name = "DtPckCompliance"
    Me.DtPckCompliance.Size = New System.Drawing.Size(88, 20)
    Me.DtPckCompliance.TabIndex = 3
    Me.DtPckCompliance.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbSortDOB)
    Me.GroupBox2.Controls.Add(Me.RbSortSname)
    Me.GroupBox2.Controls.Add(Me.RbSortLoc)
    Me.GroupBox2.Controls.Add(Me.RbSortZip)
    Me.GroupBox2.Controls.Add(Me.RbSortList)
    Me.GroupBox2.Controls.Add(Me.RbSortName)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(366, 4)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(127, 136)
    Me.GroupBox2.TabIndex = 99
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Sort Options"
    '
    'RbSortDOB
    '
    Me.RbSortDOB.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortDOB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortDOB.Location = New System.Drawing.Point(6, 73)
    Me.RbSortDOB.Name = "RbSortDOB"
    Me.RbSortDOB.Size = New System.Drawing.Size(115, 20)
    Me.RbSortDOB.TabIndex = 5
    Me.RbSortDOB.Text = "Name/Addr1/DOB"
    '
    'RbSortSname
    '
    Me.RbSortSname.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortSname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortSname.Location = New System.Drawing.Point(6, 54)
    Me.RbSortSname.Name = "RbSortSname"
    Me.RbSortSname.Size = New System.Drawing.Size(115, 20)
    Me.RbSortSname.TabIndex = 2
    Me.RbSortSname.Text = "Name/2nd/Addr1"
    '
    'RbSortLoc
    '
    Me.RbSortLoc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortLoc.Location = New System.Drawing.Point(6, 114)
    Me.RbSortLoc.Name = "RbSortLoc"
    Me.RbSortLoc.Size = New System.Drawing.Size(115, 20)
    Me.RbSortLoc.TabIndex = 4
    Me.RbSortLoc.Text = "Prop. Location"
    '
    'RbSortZip
    '
    Me.RbSortZip.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortZip.Checked = True
    Me.RbSortZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortZip.Location = New System.Drawing.Point(6, 16)
    Me.RbSortZip.Name = "RbSortZip"
    Me.RbSortZip.Size = New System.Drawing.Size(115, 20)
    Me.RbSortZip.TabIndex = 0
    Me.RbSortZip.TabStop = True
    Me.RbSortZip.Text = "Zip/Name"
    '
    'RbSortList
    '
    Me.RbSortList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortList.Location = New System.Drawing.Point(6, 94)
    Me.RbSortList.Name = "RbSortList"
    Me.RbSortList.Size = New System.Drawing.Size(115, 20)
    Me.RbSortList.TabIndex = 3
    Me.RbSortList.Text = "List #"
    '
    'RbSortName
    '
    Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortName.Location = New System.Drawing.Point(6, 36)
    Me.RbSortName.Name = "RbSortName"
    Me.RbSortName.Size = New System.Drawing.Size(115, 20)
    Me.RbSortName.TabIndex = 1
    Me.RbSortName.Text = "Name"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.ChkOmitBanks)
    Me.GroupBox3.Controls.Add(Me.TxtOmitAbove)
    Me.GroupBox3.Controls.Add(Me.Label1)
    Me.GroupBox3.Controls.Add(Me.LnkDistrict)
    Me.GroupBox3.Controls.Add(Me.TxtPhase)
    Me.GroupBox3.Controls.Add(Me.Label12)
    Me.GroupBox3.Controls.Add(Me.ChkInGracePeriod)
    Me.GroupBox3.Controls.Add(Me.TxtBankCode)
    Me.GroupBox3.Controls.Add(Me.Label11)
    Me.GroupBox3.Controls.Add(Me.TxtOmitBelow)
    Me.GroupBox3.Controls.Add(Me.Label10)
    Me.GroupBox3.Controls.Add(Me.ChkOmitSuspense)
    Me.GroupBox3.Controls.Add(Me.TxtInvCode)
    Me.GroupBox3.Controls.Add(Me.Label6)
    Me.GroupBox3.Controls.Add(Me.TxtDist)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(499, 6)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(181, 216)
    Me.GroupBox3.TabIndex = 12
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Optional Selections"
    '
    'ChkOmitBanks
    '
    Me.ChkOmitBanks.AutoSize = True
    Me.ChkOmitBanks.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkOmitBanks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkOmitBanks.Location = New System.Drawing.Point(11, 95)
    Me.ChkOmitBanks.Name = "ChkOmitBanks"
    Me.ChkOmitBanks.Size = New System.Drawing.Size(115, 17)
    Me.ChkOmitBanks.TabIndex = 301
    Me.ChkOmitBanks.Text = "Omit Bank Coded?"
    '
    'TxtOmitAbove
    '
    Me.TxtOmitAbove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOmitAbove.Location = New System.Drawing.Point(100, 165)
    Me.TxtOmitAbove.MaxLength = 6
    Me.TxtOmitAbove.Name = "TxtOmitAbove"
    Me.TxtOmitAbove.Size = New System.Drawing.Size(39, 20)
    Me.TxtOmitAbove.TabIndex = 5
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(11, 168)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(86, 21)
    Me.Label1.TabIndex = 300
    Me.Label1.Text = "Omit Bills above"
    '
    'LnkDistrict
    '
    Me.LnkDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkDistrict.Location = New System.Drawing.Point(6, 22)
    Me.LnkDistrict.Name = "LnkDistrict"
    Me.LnkDistrict.Size = New System.Drawing.Size(40, 16)
    Me.LnkDistrict.TabIndex = 298
    Me.LnkDistrict.TabStop = True
    Me.LnkDistrict.Text = "District"
    '
    'TxtPhase
    '
    Me.TxtPhase.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhase.Location = New System.Drawing.Point(136, 17)
    Me.TxtPhase.MaxLength = 1
    Me.TxtPhase.Name = "TxtPhase"
    Me.TxtPhase.Size = New System.Drawing.Size(16, 22)
    Me.TxtPhase.TabIndex = 1
    '
    'Label12
    '
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(86, 22)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(44, 14)
    Me.Label12.TabIndex = 66
    Me.Label12.Text = "Phase"
    '
    'ChkInGracePeriod
    '
    Me.ChkInGracePeriod.AutoSize = True
    Me.ChkInGracePeriod.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkInGracePeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkInGracePeriod.Location = New System.Drawing.Point(14, 112)
    Me.ChkInGracePeriod.Name = "ChkInGracePeriod"
    Me.ChkInGracePeriod.Size = New System.Drawing.Size(106, 17)
    Me.ChkInGracePeriod.TabIndex = 5
    Me.ChkInGracePeriod.Text = "In Grace Period?"
    '
    'TxtBankCode
    '
    Me.TxtBankCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBankCode.Location = New System.Drawing.Point(100, 191)
    Me.TxtBankCode.MaxLength = 2
    Me.TxtBankCode.Name = "TxtBankCode"
    Me.TxtBankCode.Size = New System.Drawing.Size(24, 20)
    Me.TxtBankCode.TabIndex = 6
    '
    'Label11
    '
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.Location = New System.Drawing.Point(11, 195)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(72, 15)
    Me.Label11.TabIndex = 36
    Me.Label11.Text = "Bank Code"
    '
    'TxtOmitBelow
    '
    Me.TxtOmitBelow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOmitBelow.Location = New System.Drawing.Point(100, 139)
    Me.TxtOmitBelow.MaxLength = 6
    Me.TxtOmitBelow.Name = "TxtOmitBelow"
    Me.TxtOmitBelow.Size = New System.Drawing.Size(39, 20)
    Me.TxtOmitBelow.TabIndex = 4
    '
    'Label10
    '
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(11, 142)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(86, 21)
    Me.Label10.TabIndex = 34
    Me.Label10.Text = "Omit Bills below"
    '
    'ChkOmitSuspense
    '
    Me.ChkOmitSuspense.AutoSize = True
    Me.ChkOmitSuspense.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkOmitSuspense.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkOmitSuspense.Location = New System.Drawing.Point(11, 78)
    Me.ChkOmitSuspense.Name = "ChkOmitSuspense"
    Me.ChkOmitSuspense.Size = New System.Drawing.Size(103, 17)
    Me.ChkOmitSuspense.TabIndex = 3
    Me.ChkOmitSuspense.Text = "Omit Suspense?"
    '
    'TxtInvCode
    '
    Me.TxtInvCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtInvCode.Location = New System.Drawing.Point(113, 52)
    Me.TxtInvCode.MaxLength = 1
    Me.TxtInvCode.Name = "TxtInvCode"
    Me.TxtInvCode.Size = New System.Drawing.Size(20, 20)
    Me.TxtInvCode.TabIndex = 2
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(11, 54)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(94, 13)
    Me.Label6.TabIndex = 2
    Me.Label6.Text = "Omit Invoice Code"
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(52, 19)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(28, 20)
    Me.TxtDist.TabIndex = 0
    '
    'TxtMsg
    '
    Me.TxtMsg.Location = New System.Drawing.Point(9, 268)
    Me.TxtMsg.MaxLength = 1000
    Me.TxtMsg.Multiline = True
    Me.TxtMsg.Name = "TxtMsg"
    Me.TxtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
    Me.TxtMsg.Size = New System.Drawing.Size(518, 154)
    Me.TxtMsg.TabIndex = 10
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(6, 252)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(94, 13)
    Me.Label8.TabIndex = 73
    Me.Label8.Text = "Optional message "
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(106, 252)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(257, 13)
    Me.Label9.TabIndex = 74
    Me.Label9.Text = "Additional page will print when page overflow occurs."
    '
    'ChkPostStatus
    '
    Me.ChkPostStatus.AutoSize = True
    Me.ChkPostStatus.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPostStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkPostStatus.Location = New System.Drawing.Point(9, 428)
    Me.ChkPostStatus.Name = "ChkPostStatus"
    Me.ChkPostStatus.Size = New System.Drawing.Size(182, 17)
    Me.ChkPostStatus.TabIndex = 16
    Me.ChkPostStatus.Text = "Flag accounts with Status Code?"
    '
    'TxtPostStatus
    '
    Me.TxtPostStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPostStatus.Enabled = False
    Me.TxtPostStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPostStatus.Location = New System.Drawing.Point(241, 427)
    Me.TxtPostStatus.MaxLength = 20
    Me.TxtPostStatus.Name = "TxtPostStatus"
    Me.TxtPostStatus.Size = New System.Drawing.Size(20, 20)
    Me.TxtPostStatus.TabIndex = 18
    '
    'LnkPostStatus
    '
    Me.LnkPostStatus.AutoSize = True
    Me.LnkPostStatus.Enabled = False
    Me.LnkPostStatus.Location = New System.Drawing.Point(204, 430)
    Me.LnkPostStatus.Name = "LnkPostStatus"
    Me.LnkPostStatus.Size = New System.Drawing.Size(32, 13)
    Me.LnkPostStatus.TabIndex = 17
    Me.LnkPostStatus.TabStop = True
    Me.LnkPostStatus.Text = "Code"
    '
    'TxtStatus
    '
    Me.TxtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtStatus.Location = New System.Drawing.Point(316, 175)
    Me.TxtStatus.MaxLength = 20
    Me.TxtStatus.Name = "TxtStatus"
    Me.TxtStatus.Size = New System.Drawing.Size(129, 20)
    Me.TxtStatus.TabIndex = 7
    '
    'LnkOmitStatus
    '
    Me.LnkOmitStatus.AutoSize = True
    Me.LnkOmitStatus.Location = New System.Drawing.Point(216, 200)
    Me.LnkOmitStatus.Name = "LnkOmitStatus"
    Me.LnkOmitStatus.Size = New System.Drawing.Size(94, 13)
    Me.LnkOmitStatus.TabIndex = 8
    Me.LnkOmitStatus.TabStop = True
    Me.LnkOmitStatus.Text = "Omit Status Codes"
    '
    'TxtOmitStatus
    '
    Me.TxtOmitStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOmitStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOmitStatus.Location = New System.Drawing.Point(316, 197)
    Me.TxtOmitStatus.MaxLength = 20
    Me.TxtOmitStatus.Name = "TxtOmitStatus"
    Me.TxtOmitStatus.Size = New System.Drawing.Size(129, 20)
    Me.TxtOmitStatus.TabIndex = 9
    '
    'LnkStatus
    '
    Me.LnkStatus.AutoSize = True
    Me.LnkStatus.Location = New System.Drawing.Point(238, 179)
    Me.LnkStatus.Name = "LnkStatus"
    Me.LnkStatus.Size = New System.Drawing.Size(70, 13)
    Me.LnkStatus.TabIndex = 6
    Me.LnkStatus.TabStop = True
    Me.LnkStatus.Text = "Status Codes"
    '
    'BtnSaveMsg
    '
    Me.BtnSaveMsg.Location = New System.Drawing.Point(537, 317)
    Me.BtnSaveMsg.Name = "BtnSaveMsg"
    Me.BtnSaveMsg.Size = New System.Drawing.Size(58, 47)
    Me.BtnSaveMsg.TabIndex = 100
    Me.BtnSaveMsg.Text = "Save Message"
    Me.BtnSaveMsg.UseVisualStyleBackColor = True
    '
    'GrpWins
    '
    Me.GrpWins.Controls.Add(Me.TxtOmitTotalBelow)
    Me.GrpWins.Controls.Add(Me.Label7)
    Me.GrpWins.Location = New System.Drawing.Point(499, 223)
    Me.GrpWins.Name = "GrpWins"
    Me.GrpWins.Size = New System.Drawing.Size(180, 39)
    Me.GrpWins.TabIndex = 101
    Me.GrpWins.TabStop = False
    Me.GrpWins.Visible = False
    '
    'TxtOmitTotalBelow
    '
    Me.TxtOmitTotalBelow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOmitTotalBelow.Location = New System.Drawing.Point(126, 13)
    Me.TxtOmitTotalBelow.MaxLength = 6
    Me.TxtOmitTotalBelow.Name = "TxtOmitTotalBelow"
    Me.TxtOmitTotalBelow.Size = New System.Drawing.Size(48, 20)
    Me.TxtOmitTotalBelow.TabIndex = 7
    '
    'Label7
    '
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(6, 16)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(116, 16)
    Me.Label7.TabIndex = 301
    Me.Label7.Text = "Omit Total Bills Below"
    '
    'FrmTX302B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(692, 460)
    Me.ControlBox = False
    Me.Controls.Add(Me.GrpWins)
    Me.Controls.Add(Me.BtnSaveMsg)
    Me.Controls.Add(Me.TxtOmitStatus)
    Me.Controls.Add(Me.LnkStatus)
    Me.Controls.Add(Me.TxtStatus)
    Me.Controls.Add(Me.LnkOmitStatus)
    Me.Controls.Add(Me.ChkPostStatus)
    Me.Controls.Add(Me.TxtPostStatus)
    Me.Controls.Add(Me.LnkPostStatus)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.TxtMsg)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.DtPckCompliance)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtToGLYear)
    Me.Controls.Add(Me.DtPckInt)
    Me.Controls.Add(Me.LnkTypes)
    Me.Controls.Add(Me.TxtFromGLYear)
    Me.Controls.Add(Me.TxtTypes)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.GroupBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX302B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GrpWins.ResumeLayout(False)
    Me.GrpWins.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

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
    Private Sub FrmTX302B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtAltFormID.Text = MyAltFormID
        DtPckInt.Value = Date.Today
        DtPckCompliance.Value = Date.Today
        TxtMsg.Enabled = False
        ChkPageNos.Enabled = False
        LnkAltID.Enabled = False
        TxtAltFormID.Enabled = False
        'TxtMsg.Text = MyAppSettings.Message
    End Sub
    Private Sub FrmTX302B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        MyFrmTX302.SbpScreen.Text = "TX302B"
    End Sub

    Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
        MyTypes = TxtTypes.Text
        MyFrmSelTypes = New FrmSelTypes
        MyFrmSelTypes.MdiParent = Me.ParentForm
        MyFrmSelTypes.Show()

    End Sub
    Private Sub FrmTX302B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        Me.Refresh()
    End Sub
    Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
        Dim I As Integer
        ErrProv.SetError(TxtFromGLYear, "")
        ErrProv.SetError(TxtToGLYear, "")

        For I = 0 To ErrorField.GetUpperBound(0)
            Select Case ErrorField(I)
                Case "fromglyear"
                    ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
                Case "fromglyear"
                    ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
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

        If MyUtils.CnvSng(TxtFromGLYear.Text) = 0 Then
            ErrorField(I) = "fromglyear"
            ErrorMsg(I) = "Invalid From GL Year"
            I = I + 1
        End If

        If MyUtils.CnvSng(TxtToGLYear.Text) = 0 Then
            ErrorField(I) = "toglyear"
            ErrorMsg(I) = "Invalid To GL Year"
            I = I + 1
        End If

    End Sub
    Private Sub TxtFromGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
        e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
    End Sub
    Private Sub TxtToGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToGLYear.KeyPress
        e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
    End Sub
  Private Sub TxtOmitBelow_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOmitBelow.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtOmitTotalBelow_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOmitTotalBelow.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtOmitAbove_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOmitAbove.KeyPress
        e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
    End Sub
    Private Sub RbPrtList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPrtList.Click
        TxtMsg.Enabled = False
        ChkDouble.Enabled = True
        ChkPageNos.Enabled = False
        ChkPageNos.Checked = False
        LnkAltID.Enabled = False
        TxtAltFormID.Enabled = False
        RbSortDOB.Enabled = True
        RbSortLoc.Enabled = True
        RbSortName.Enabled = True
        RbSortSname.Enabled = True
    RbSortZip.Enabled = True
    HideGrpWins()
  End Sub
    Private Sub RbPrtBalDueUB_CheckedChanged(sender As Object, e As EventArgs) Handles RbPrtBalDueUB.CheckedChanged
        TxtMsg.Enabled = False
        ChkDouble.Enabled = True
        ChkPageNos.Enabled = False
        ChkPageNos.Checked = False
        LnkAltID.Enabled = False
        TxtAltFormID.Enabled = False
        RbSortDOB.Enabled = False
        RbSortLoc.Enabled = False
        RbSortName.Enabled = False
        RbSortSname.Enabled = False
        RbSortZip.Enabled = False
        RbSortList.Checked = True
    HideGrpWins()


  End Sub
    Private Sub RbPrtListAddr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPrtListAddr.Click
        TxtMsg.Enabled = False
        ChkDouble.Enabled = False
        ChkDouble.Checked = False
        ChkPageNos.Enabled = False
        ChkPageNos.Checked = False
        LnkAltID.Enabled = False
        TxtAltFormID.Enabled = False
        RbSortDOB.Enabled = True
        RbSortLoc.Enabled = True
        RbSortName.Enabled = True
        RbSortSname.Enabled = True
    RbSortZip.Enabled = True
    HideGrpWins()
  End Sub
    Private Sub RbPrtListStatus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPrtListStatus.Click
        TxtMsg.Enabled = False
        ChkDouble.Enabled = True
        ChkPageNos.Enabled = False
        ChkPageNos.Checked = False
        LnkAltID.Enabled = False
        TxtAltFormID.Enabled = False
        RbSortDOB.Enabled = True
        RbSortLoc.Enabled = True
        RbSortName.Enabled = True
        RbSortSname.Enabled = True
    RbSortZip.Enabled = True
    HideGrpWins()
  End Sub
    Private Sub RbPrtListLoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPrtListLoc.Click
        TxtMsg.Enabled = False
        ChkDouble.Enabled = False
        ChkDouble.Checked = False
        ChkPageNos.Enabled = False
        ChkPageNos.Checked = False
        LnkAltID.Enabled = False
        TxtAltFormID.Enabled = False
        RbSortDOB.Enabled = True
        RbSortLoc.Enabled = True
        RbSortName.Enabled = True
        RbSortSname.Enabled = True
    RbSortZip.Enabled = True
    HideGrpWins()
  End Sub
    Private Sub RbPrtStatement_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPrtStatement.Click
        TxtMsg.Enabled = True
        ChkDouble.Enabled = False
        ChkDouble.Checked = False
        ChkPageNos.Enabled = True
        LnkAltID.Enabled = True
        TxtAltFormID.Enabled = True
        RbSortDOB.Enabled = True
        RbSortLoc.Enabled = True
        RbSortName.Enabled = True
        RbSortSname.Enabled = True
    RbSortZip.Enabled = True
    HideGrpWins()
  End Sub
    Private Sub RbPrtDemand_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPrtDemand.Click
        TxtMsg.Enabled = True
        ChkDouble.Enabled = False
        ChkDouble.Checked = False
        ChkPageNos.Enabled = True
        LnkAltID.Enabled = True
        TxtAltFormID.Enabled = True
        RbSortDOB.Enabled = True
        RbSortLoc.Enabled = True
        RbSortName.Enabled = True
        RbSortSname.Enabled = True
    RbSortZip.Enabled = True
    HideGrpWins()
  End Sub
    Private Sub RbPrtWarrants_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPrtWarrants.Click
        TxtMsg.Enabled = True
        ChkDouble.Enabled = False
        ChkDouble.Checked = False
        ChkPageNos.Enabled = True
        LnkAltID.Enabled = True
        TxtAltFormID.Enabled = True
        RbSortDOB.Enabled = True
        RbSortLoc.Enabled = True
        RbSortName.Enabled = True
        RbSortSname.Enabled = True
    RbSortZip.Enabled = True
    HideGrpWins()
  End Sub
    Private Sub LnkStatus_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkStatus.LinkClicked
        MyFrmSelStatus = New FrmSelStatus
        MyFrmSelStatus.MdiParent = Me.ParentForm
        MyFrmSelStatus.WrkField = "Select"
        MyFrmSelStatus.Show()
    End Sub
    Private Sub LnkOmitStatus_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkOmitStatus.LinkClicked
        MyFrmSelStatus = New FrmSelStatus
        MyFrmSelStatus.MdiParent = Me.ParentForm
        MyFrmSelStatus.WrkField = "Omit"
        MyFrmSelStatus.Show()
    End Sub
    Private Sub ChkPostStatus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkPostStatus.Click
        LnkPostStatus.Enabled = Not LnkPostStatus.Enabled
        TxtPostStatus.Enabled = Not TxtPostStatus.Enabled
        If Not TxtPostStatus.Enabled Then
            TxtPostStatus.Text = String.Empty
        End If
    End Sub
    Private Sub LnkPostStatus_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkPostStatus.LinkClicked
        MyFrmListSts = New FrmListSts
        MyFrmListSts.MdiParent = Me.ParentForm
        MyFrmListSts.WrkCode = TxtPostStatus.Text
        MyFrmListSts.Show()
    End Sub

    Private Sub LnkDistrict_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDistrict.LinkClicked
        MyFrmListDist = New FrmListDist
        MyFrmListDist.MdiParent = Me.ParentForm
        MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
        MyFrmListDist.Show()
        Me.Hide()
    End Sub

    Private Sub LnkAltID_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkAltID.LinkClicked
        MyFrmListAltID = New FrmListAltID
        MyFrmListAltID.MdiParent = Me.ParentForm
        MyFrmListAltID.Show()
    End Sub

    Private Sub RbPrtList_CheckedChanged(sender As Object, e As EventArgs) Handles RbPrtList.CheckedChanged

    End Sub

    Private Sub RbPrtListStatus_CheckedChanged(sender As Object, e As EventArgs) Handles RbPrtListStatus.CheckedChanged

    End Sub

  Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

  End Sub
  Private Sub HideGrpWins()

    If RbPrtDemand.Checked = True And myTOWN._TOWNBR = 162 Then
      GrpWins.Visible = True
    Else
      GrpWins.Visible = False
    End If
  End Sub
End Class






