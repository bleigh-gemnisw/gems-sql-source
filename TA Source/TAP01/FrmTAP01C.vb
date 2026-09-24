Public Class FrmTAP01C
  Inherits System.Windows.Forms.Form
  Dim MyTXDCPP As TXDCPP.MyData
  Dim MyTXDCCD As TXDCCD.MyData
  Dim MyTXDCDEP As TXDCDEP.MyData
  Dim MyTXDCDTL As TXDCDTL.MyData
  Dim MyTXPPRP As TXPPRP.MyData
  Dim MyTXDCCOM As TXDCCOM.MyData
  Dim AddMode As Boolean
  Dim WrkTotCost As Integer
  Dim WrkTotValue As Integer
  Dim LoadScrn As Boolean
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer

  Friend WithEvents TabCtl2 As System.Windows.Forms.TabControl
  Friend WithEvents Tp1to6 As System.Windows.Forms.TabPage
  Friend WithEvents RbLease As System.Windows.Forms.RadioButton
  Friend WithEvents RbOwn As System.Windows.Forms.RadioButton
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents TxtSqfeet As System.Windows.Forms.TextBox
  Friend WithEvents DtPckStrDt As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents TxtNoEmps As System.Windows.Forms.TextBox
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents TxtBusDes As System.Windows.Forms.TextBox
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents TxtLFax As System.Windows.Forms.TextBox
  Friend WithEvents TxtLPhone As System.Windows.Forms.TextBox
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents TxtDFax As System.Windows.Forms.TextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents TxtDEmail As System.Windows.Forms.TextBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents TxtLZip4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtLZip5 As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TxtLCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtLState As System.Windows.Forms.TextBox
  Friend WithEvents TxtLAddr As System.Windows.Forms.TextBox
  Friend WithEvents TxtLName As System.Windows.Forms.TextBox
  Friend WithEvents TxtLEmail As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtDZip4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtDZip5 As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtDCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtDState As System.Windows.Forms.TextBox
  Friend WithEvents TxtDAddr As System.Windows.Forms.TextBox
  Friend WithEvents TxtDName As System.Windows.Forms.TextBox
  Friend WithEvents TxtDPhone As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Tp7to12 As System.Windows.Forms.TabPage
  Friend WithEvents ChkLessee As System.Windows.Forms.CheckBox
  Friend WithEvents ChkLessor As System.Windows.Forms.CheckBox
  Friend WithEvents ChkOthBus As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents RbBusLes As System.Windows.Forms.RadioButton
  Friend WithEvents RbBusTrade As System.Windows.Forms.RadioButton
  Friend WithEvents RbBusRet As System.Windows.Forms.RadioButton
  Friend WithEvents TxtBusOth As System.Windows.Forms.TextBox
  Friend WithEvents RbBusProf As System.Windows.Forms.RadioButton
  Friend WithEvents RbBusServ As System.Windows.Forms.RadioButton
  Friend WithEvents RbBusWhole As System.Windows.Forms.RadioButton
  Friend WithEvents RbBusOther As System.Windows.Forms.RadioButton
  Friend WithEvents RbBusManuf As System.Windows.Forms.RadioButton
  Friend WithEvents ChkPropCT As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtOwnOth As System.Windows.Forms.TextBox
  Friend WithEvents RbOwnSole As System.Windows.Forms.RadioButton
  Friend WithEvents RbOwnLLC As System.Windows.Forms.RadioButton
  Friend WithEvents RbOwnPartner As System.Windows.Forms.RadioButton
  Friend WithEvents RbOwnOther As System.Windows.Forms.RadioButton
  Friend WithEvents RbOwnCorp As System.Windows.Forms.RadioButton
  Friend WithEvents TxtLoc As System.Windows.Forms.TextBox
  Friend WithEvents TxtLocNo As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label51 As System.Windows.Forms.Label
  Friend WithEvents DtPckRecvDt As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtOwname As System.Windows.Forms.TextBox
  Friend WithEvents TxtDBA As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents LnkListNo As System.Windows.Forms.LinkLabel
  Friend WithEvents TpAff As System.Windows.Forms.TabPage
  Friend WithEvents Label24 As System.Windows.Forms.Label
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents RbBComm As System.Windows.Forms.RadioButton
  Friend WithEvents RbBNotary As System.Windows.Forms.RadioButton
  Friend WithEvents RbBJustice As System.Windows.Forms.RadioButton
  Friend WithEvents RbBTown As System.Windows.Forms.RadioButton
  Friend WithEvents RbBAssessor As System.Windows.Forms.RadioButton
  Friend WithEvents Label25 As System.Windows.Forms.Label
  Friend WithEvents DtPckBWit As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtBWit As System.Windows.Forms.TextBox
  Friend WithEvents Label26 As System.Windows.Forms.Label
  Friend WithEvents Label27 As System.Windows.Forms.Label
  Friend WithEvents DtPckB As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label28 As System.Windows.Forms.Label
  Friend WithEvents TxtBName As System.Windows.Forms.TextBox
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents TxtBTitle As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
  Friend WithEvents Label31 As System.Windows.Forms.Label
  Friend WithEvents DtPckA As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label32 As System.Windows.Forms.Label
  Friend WithEvents TxtAName As System.Windows.Forms.TextBox
  Friend WithEvents Label33 As System.Windows.Forms.Label
  Friend WithEvents Label34 As System.Windows.Forms.Label
  Friend WithEvents TxtATitle As System.Windows.Forms.TextBox
  Friend WithEvents RbAMember As System.Windows.Forms.RadioButton
  Friend WithEvents RbAPartner As System.Windows.Forms.RadioButton
  Friend WithEvents RbACorporate As System.Windows.Forms.RadioButton
  Friend WithEvents RbAOwner As System.Windows.Forms.RadioButton
  Friend WithEvents Label37 As System.Windows.Forms.Label
  Friend WithEvents Label36 As System.Windows.Forms.Label
  Friend WithEvents Label35 As System.Windows.Forms.Label
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents LblYear As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents Label38 As System.Windows.Forms.Label
  Friend WithEvents LblAuditYear As System.Windows.Forms.Label
  Friend WithEvents Label39 As System.Windows.Forms.Label
  Friend WithEvents LblBusType As System.Windows.Forms.Label
  Friend WithEvents LblBusDesc As System.Windows.Forms.Label
  Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
  Friend WithEvents RbFileNon As System.Windows.Forms.RadioButton
  Friend WithEvents RbFileLate As System.Windows.Forms.RadioButton
  Friend WithEvents RbFileExt As System.Windows.Forms.RadioButton
  Friend WithEvents RbFileOntime As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
  Friend WithEvents RbStatInact As System.Windows.Forms.RadioButton
  Friend WithEvents RbStatPend As System.Windows.Forms.RadioButton
  Friend WithEvents RbStatActive As System.Windows.Forms.RadioButton
  Friend WithEvents RbStatIncr As System.Windows.Forms.RadioButton
  Friend WithEvents TxtLAddr2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtDAddr2 As System.Windows.Forms.TextBox
  Friend WithEvents ChkPrtcom As System.Windows.Forms.CheckBox
    Friend WithEvents Label40 As Label
    Friend WithEvents TxtIrsbus As TextBox
    Friend WithEvents TxtListNo As System.Windows.Forms.TextBox



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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTAP01C))
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TabCtl2 = New System.Windows.Forms.TabControl()
    Me.Tp1to6 = New System.Windows.Forms.TabPage()
    Me.RbLease = New System.Windows.Forms.RadioButton()
    Me.RbOwn = New System.Windows.Forms.RadioButton()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.TxtSqfeet = New System.Windows.Forms.TextBox()
    Me.DtPckStrDt = New System.Windows.Forms.DateTimePicker()
    Me.Label22 = New System.Windows.Forms.Label()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.TxtNoEmps = New System.Windows.Forms.TextBox()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.TxtBusDes = New System.Windows.Forms.TextBox()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.TxtLAddr2 = New System.Windows.Forms.TextBox()
    Me.TxtDAddr2 = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtLFax = New System.Windows.Forms.TextBox()
    Me.TxtLPhone = New System.Windows.Forms.TextBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.TxtDFax = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.TxtDEmail = New System.Windows.Forms.TextBox()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TxtLZip4 = New System.Windows.Forms.TextBox()
    Me.TxtLZip5 = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtLCity = New System.Windows.Forms.TextBox()
    Me.TxtLState = New System.Windows.Forms.TextBox()
    Me.TxtLAddr = New System.Windows.Forms.TextBox()
    Me.TxtLName = New System.Windows.Forms.TextBox()
    Me.TxtLEmail = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtDZip4 = New System.Windows.Forms.TextBox()
    Me.TxtDZip5 = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtDCity = New System.Windows.Forms.TextBox()
    Me.TxtDState = New System.Windows.Forms.TextBox()
    Me.TxtDAddr = New System.Windows.Forms.TextBox()
    Me.TxtDName = New System.Windows.Forms.TextBox()
    Me.TxtDPhone = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Tp7to12 = New System.Windows.Forms.TabPage()
    Me.Label37 = New System.Windows.Forms.Label()
    Me.Label36 = New System.Windows.Forms.Label()
    Me.Label35 = New System.Windows.Forms.Label()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.ChkLessee = New System.Windows.Forms.CheckBox()
    Me.ChkLessor = New System.Windows.Forms.CheckBox()
    Me.ChkOthBus = New System.Windows.Forms.CheckBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.TxtIrsbus = New System.Windows.Forms.TextBox()
    Me.Label40 = New System.Windows.Forms.Label()
    Me.RbBusLes = New System.Windows.Forms.RadioButton()
    Me.RbBusTrade = New System.Windows.Forms.RadioButton()
    Me.RbBusRet = New System.Windows.Forms.RadioButton()
    Me.TxtBusOth = New System.Windows.Forms.TextBox()
    Me.RbBusProf = New System.Windows.Forms.RadioButton()
    Me.RbBusServ = New System.Windows.Forms.RadioButton()
    Me.RbBusWhole = New System.Windows.Forms.RadioButton()
    Me.RbBusOther = New System.Windows.Forms.RadioButton()
    Me.RbBusManuf = New System.Windows.Forms.RadioButton()
    Me.ChkPropCT = New System.Windows.Forms.CheckBox()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.TxtOwnOth = New System.Windows.Forms.TextBox()
    Me.RbOwnSole = New System.Windows.Forms.RadioButton()
    Me.RbOwnLLC = New System.Windows.Forms.RadioButton()
    Me.RbOwnPartner = New System.Windows.Forms.RadioButton()
    Me.RbOwnOther = New System.Windows.Forms.RadioButton()
    Me.RbOwnCorp = New System.Windows.Forms.RadioButton()
    Me.TpAff = New System.Windows.Forms.TabPage()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.RbBComm = New System.Windows.Forms.RadioButton()
    Me.RbBNotary = New System.Windows.Forms.RadioButton()
    Me.RbBJustice = New System.Windows.Forms.RadioButton()
    Me.RbBTown = New System.Windows.Forms.RadioButton()
    Me.RbBAssessor = New System.Windows.Forms.RadioButton()
    Me.Label25 = New System.Windows.Forms.Label()
    Me.DtPckBWit = New System.Windows.Forms.DateTimePicker()
    Me.TxtBWit = New System.Windows.Forms.TextBox()
    Me.Label26 = New System.Windows.Forms.Label()
    Me.Label27 = New System.Windows.Forms.Label()
    Me.DtPckB = New System.Windows.Forms.DateTimePicker()
    Me.Label28 = New System.Windows.Forms.Label()
    Me.TxtBName = New System.Windows.Forms.TextBox()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.TxtBTitle = New System.Windows.Forms.TextBox()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.Label31 = New System.Windows.Forms.Label()
    Me.DtPckA = New System.Windows.Forms.DateTimePicker()
    Me.Label32 = New System.Windows.Forms.Label()
    Me.TxtAName = New System.Windows.Forms.TextBox()
    Me.Label33 = New System.Windows.Forms.Label()
    Me.Label34 = New System.Windows.Forms.Label()
    Me.TxtATitle = New System.Windows.Forms.TextBox()
    Me.RbAMember = New System.Windows.Forms.RadioButton()
    Me.RbAPartner = New System.Windows.Forms.RadioButton()
    Me.RbACorporate = New System.Windows.Forms.RadioButton()
    Me.RbAOwner = New System.Windows.Forms.RadioButton()
    Me.TxtLoc = New System.Windows.Forms.TextBox()
    Me.TxtLocNo = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label51 = New System.Windows.Forms.Label()
    Me.DtPckRecvDt = New System.Windows.Forms.DateTimePicker()
    Me.TxtOwname = New System.Windows.Forms.TextBox()
    Me.TxtDBA = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LnkListNo = New System.Windows.Forms.LinkLabel()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.LblAuditYear = New System.Windows.Forms.Label()
    Me.Label39 = New System.Windows.Forms.Label()
    Me.Label38 = New System.Windows.Forms.Label()
    Me.LblBusType = New System.Windows.Forms.Label()
    Me.LblBusDesc = New System.Windows.Forms.Label()
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.RbFileNon = New System.Windows.Forms.RadioButton()
    Me.RbFileLate = New System.Windows.Forms.RadioButton()
    Me.RbFileExt = New System.Windows.Forms.RadioButton()
    Me.RbFileOntime = New System.Windows.Forms.RadioButton()
    Me.GroupBox7 = New System.Windows.Forms.GroupBox()
    Me.RbStatIncr = New System.Windows.Forms.RadioButton()
    Me.RbStatInact = New System.Windows.Forms.RadioButton()
    Me.RbStatPend = New System.Windows.Forms.RadioButton()
    Me.RbStatActive = New System.Windows.Forms.RadioButton()
    Me.ChkPrtcom = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TabCtl2.SuspendLayout()
    Me.Tp1to6.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.Tp7to12.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.TpAff.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.GroupBox6.SuspendLayout()
    Me.GroupBox7.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TabCtl2
    '
    Me.TabCtl2.Controls.Add(Me.Tp1to6)
    Me.TabCtl2.Controls.Add(Me.Tp7to12)
    Me.TabCtl2.Controls.Add(Me.TpAff)
    Me.TabCtl2.Location = New System.Drawing.Point(0, 117)
    Me.TabCtl2.Name = "TabCtl2"
    Me.TabCtl2.SelectedIndex = 0
    Me.TabCtl2.Size = New System.Drawing.Size(961, 417)
    Me.TabCtl2.TabIndex = 211
    '
    'Tp1to6
    '
    Me.Tp1to6.Controls.Add(Me.RbLease)
    Me.Tp1to6.Controls.Add(Me.RbOwn)
    Me.Tp1to6.Controls.Add(Me.Label23)
    Me.Tp1to6.Controls.Add(Me.TxtSqfeet)
    Me.Tp1to6.Controls.Add(Me.DtPckStrDt)
    Me.Tp1to6.Controls.Add(Me.Label22)
    Me.Tp1to6.Controls.Add(Me.Label21)
    Me.Tp1to6.Controls.Add(Me.TxtNoEmps)
    Me.Tp1to6.Controls.Add(Me.Label20)
    Me.Tp1to6.Controls.Add(Me.TxtBusDes)
    Me.Tp1to6.Controls.Add(Me.Label19)
    Me.Tp1to6.Controls.Add(Me.GroupBox1)
    Me.Tp1to6.Location = New System.Drawing.Point(4, 22)
    Me.Tp1to6.Name = "Tp1to6"
    Me.Tp1to6.Padding = New System.Windows.Forms.Padding(3)
    Me.Tp1to6.Size = New System.Drawing.Size(953, 391)
    Me.Tp1to6.TabIndex = 0
    Me.Tp1to6.Text = "Questions 1 to 6"
    Me.Tp1to6.UseVisualStyleBackColor = True
    '
    'RbLease
    '
    Me.RbLease.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbLease.Location = New System.Drawing.Point(625, 320)
    Me.RbLease.Name = "RbLease"
    Me.RbLease.Size = New System.Drawing.Size(55, 18)
    Me.RbLease.TabIndex = 6
    Me.RbLease.Text = "Lease"
    '
    'RbOwn
    '
    Me.RbOwn.Checked = True
    Me.RbOwn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbOwn.Location = New System.Drawing.Point(561, 320)
    Me.RbOwn.Name = "RbOwn"
    Me.RbOwn.Size = New System.Drawing.Size(49, 18)
    Me.RbOwn.TabIndex = 5
    Me.RbOwn.TabStop = True
    Me.RbOwn.Text = "Own"
    '
    'Label23
    '
    Me.Label23.AutoSize = True
    Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label23.Location = New System.Drawing.Point(469, 325)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(35, 13)
    Me.Label23.TabIndex = 205
    Me.Label23.Text = "Sq. ft."
    '
    'TxtSqfeet
    '
    Me.TxtSqfeet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSqfeet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSqfeet.Location = New System.Drawing.Point(397, 322)
    Me.TxtSqfeet.MaxLength = 7
    Me.TxtSqfeet.Name = "TxtSqfeet"
    Me.TxtSqfeet.Size = New System.Drawing.Size(66, 20)
    Me.TxtSqfeet.TabIndex = 4
    '
    'DtPckStrDt
    '
    Me.DtPckStrDt.Checked = False
    Me.DtPckStrDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckStrDt.Location = New System.Drawing.Point(227, 296)
    Me.DtPckStrDt.Name = "DtPckStrDt"
    Me.DtPckStrDt.ShowCheckBox = True
    Me.DtPckStrDt.Size = New System.Drawing.Size(97, 20)
    Me.DtPckStrDt.TabIndex = 3
    '
    'Label22
    '
    Me.Label22.AutoSize = True
    Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label22.Location = New System.Drawing.Point(10, 325)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(381, 13)
    Me.Label22.TabIndex = 202
    Me.Label22.Text = "6. How many Square feet does your firm occupy at your location(s) in this town?"
    '
    'Label21
    '
    Me.Label21.AutoSize = True
    Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label21.Location = New System.Drawing.Point(10, 296)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(204, 13)
    Me.Label21.TabIndex = 201
    Me.Label21.Text = "5. Date your business began in this town?"
    '
    'TxtNoEmps
    '
    Me.TxtNoEmps.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtNoEmps.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtNoEmps.Location = New System.Drawing.Point(330, 269)
    Me.TxtNoEmps.MaxLength = 6
    Me.TxtNoEmps.Name = "TxtNoEmps"
    Me.TxtNoEmps.Size = New System.Drawing.Size(58, 20)
    Me.TxtNoEmps.TabIndex = 2
    '
    'Label20
    '
    Me.Label20.AutoSize = True
    Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label20.Location = New System.Drawing.Point(10, 271)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(306, 13)
    Me.Label20.TabIndex = 199
    Me.Label20.Text = "4. How many employees work in your facilities in this town only?"
    '
    'TxtBusDes
    '
    Me.TxtBusDes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBusDes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBusDes.Location = New System.Drawing.Point(145, 243)
    Me.TxtBusDes.MaxLength = 50
    Me.TxtBusDes.Name = "TxtBusDes"
    Me.TxtBusDes.Size = New System.Drawing.Size(409, 20)
    Me.TxtBusDes.TabIndex = 1
    '
    'Label19
    '
    Me.Label19.AutoSize = True
    Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label19.Location = New System.Drawing.Point(10, 246)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(129, 13)
    Me.Label19.TabIndex = 197
    Me.Label19.Text = "3. Description of Business"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.TxtLAddr2)
    Me.GroupBox1.Controls.Add(Me.TxtDAddr2)
    Me.GroupBox1.Controls.Add(Me.Label7)
    Me.GroupBox1.Controls.Add(Me.TxtLFax)
    Me.GroupBox1.Controls.Add(Me.TxtLPhone)
    Me.GroupBox1.Controls.Add(Me.Label17)
    Me.GroupBox1.Controls.Add(Me.Label11)
    Me.GroupBox1.Controls.Add(Me.Label16)
    Me.GroupBox1.Controls.Add(Me.TxtDFax)
    Me.GroupBox1.Controls.Add(Me.Label15)
    Me.GroupBox1.Controls.Add(Me.TxtDEmail)
    Me.GroupBox1.Controls.Add(Me.Label14)
    Me.GroupBox1.Controls.Add(Me.Label9)
    Me.GroupBox1.Controls.Add(Me.TxtLZip4)
    Me.GroupBox1.Controls.Add(Me.TxtLZip5)
    Me.GroupBox1.Controls.Add(Me.Label10)
    Me.GroupBox1.Controls.Add(Me.TxtLCity)
    Me.GroupBox1.Controls.Add(Me.TxtLState)
    Me.GroupBox1.Controls.Add(Me.TxtLAddr)
    Me.GroupBox1.Controls.Add(Me.TxtLName)
    Me.GroupBox1.Controls.Add(Me.TxtLEmail)
    Me.GroupBox1.Controls.Add(Me.Label12)
    Me.GroupBox1.Controls.Add(Me.Label8)
    Me.GroupBox1.Controls.Add(Me.TxtDZip4)
    Me.GroupBox1.Controls.Add(Me.TxtDZip5)
    Me.GroupBox1.Controls.Add(Me.Label4)
    Me.GroupBox1.Controls.Add(Me.Label3)
    Me.GroupBox1.Controls.Add(Me.TxtDCity)
    Me.GroupBox1.Controls.Add(Me.TxtDState)
    Me.GroupBox1.Controls.Add(Me.TxtDAddr)
    Me.GroupBox1.Controls.Add(Me.TxtDName)
    Me.GroupBox1.Controls.Add(Me.TxtDPhone)
    Me.GroupBox1.Controls.Add(Me.Label5)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(7, 6)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(938, 219)
    Me.GroupBox1.TabIndex = 0
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Business Data"
    '
    'TxtLAddr2
    '
    Me.TxtLAddr2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLAddr2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLAddr2.Location = New System.Drawing.Point(574, 114)
    Me.TxtLAddr2.MaxLength = 35
    Me.TxtLAddr2.Name = "TxtLAddr2"
    Me.TxtLAddr2.Size = New System.Drawing.Size(280, 20)
    Me.TxtLAddr2.TabIndex = 12
    '
    'TxtDAddr2
    '
    Me.TxtDAddr2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDAddr2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDAddr2.Location = New System.Drawing.Point(97, 114)
    Me.TxtDAddr2.MaxLength = 35
    Me.TxtDAddr2.Name = "TxtDAddr2"
    Me.TxtDAddr2.Size = New System.Drawing.Size(280, 20)
    Me.TxtDAddr2.TabIndex = 2
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(30, 18)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(278, 13)
    Me.Label7.TabIndex = 213
    Me.Label7.Text = "For businesses, occupations, professions, farmers, lessors"
    '
    'TxtLFax
    '
    Me.TxtLFax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLFax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLFax.Location = New System.Drawing.Point(724, 164)
    Me.TxtLFax.MaxLength = 20
    Me.TxtLFax.Name = "TxtLFax"
    Me.TxtLFax.Size = New System.Drawing.Size(144, 20)
    Me.TxtLFax.TabIndex = 18
    '
    'TxtLPhone
    '
    Me.TxtLPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLPhone.Location = New System.Drawing.Point(574, 164)
    Me.TxtLPhone.MaxLength = 20
    Me.TxtLPhone.Name = "TxtLPhone"
    Me.TxtLPhone.Size = New System.Drawing.Size(144, 20)
    Me.TxtLPhone.TabIndex = 17
    '
    'Label17
    '
    Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label17.Location = New System.Drawing.Point(486, 164)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(80, 16)
    Me.Label17.TabIndex = 211
    Me.Label17.Text = "Phone/Fax"
    '
    'Label11
    '
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.Location = New System.Drawing.Point(488, 94)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(80, 16)
    Me.Label11.TabIndex = 209
    Me.Label11.Text = "Address"
    '
    'Label16
    '
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.Location = New System.Drawing.Point(489, 66)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(80, 16)
    Me.Label16.TabIndex = 208
    Me.Label16.Text = "Name"
    '
    'TxtDFax
    '
    Me.TxtDFax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDFax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDFax.Location = New System.Drawing.Point(246, 164)
    Me.TxtDFax.MaxLength = 20
    Me.TxtDFax.Name = "TxtDFax"
    Me.TxtDFax.Size = New System.Drawing.Size(144, 20)
    Me.TxtDFax.TabIndex = 8
    '
    'Label15
    '
    Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label15.Location = New System.Drawing.Point(7, 94)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(80, 16)
    Me.Label15.TabIndex = 206
    Me.Label15.Text = "Address"
    '
    'TxtDEmail
    '
    Me.TxtDEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDEmail.Location = New System.Drawing.Point(96, 189)
    Me.TxtDEmail.MaxLength = 30
    Me.TxtDEmail.Name = "TxtDEmail"
    Me.TxtDEmail.Size = New System.Drawing.Size(280, 20)
    Me.TxtDEmail.TabIndex = 9
    '
    'Label14
    '
    Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label14.Location = New System.Drawing.Point(6, 193)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(80, 16)
    Me.Label14.TabIndex = 205
    Me.Label14.Text = "Email"
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(571, 43)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(172, 13)
    Me.Label9.TabIndex = 203
    Me.Label9.Text = "2. Location of accounting records -"
    '
    'TxtLZip4
    '
    Me.TxtLZip4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLZip4.Location = New System.Drawing.Point(894, 137)
    Me.TxtLZip4.MaxLength = 4
    Me.TxtLZip4.Name = "TxtLZip4"
    Me.TxtLZip4.Size = New System.Drawing.Size(32, 20)
    Me.TxtLZip4.TabIndex = 16
    '
    'TxtLZip5
    '
    Me.TxtLZip5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLZip5.Location = New System.Drawing.Point(846, 137)
    Me.TxtLZip5.MaxLength = 5
    Me.TxtLZip5.Name = "TxtLZip5"
    Me.TxtLZip5.Size = New System.Drawing.Size(40, 20)
    Me.TxtLZip5.TabIndex = 15
    '
    'Label10
    '
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(486, 141)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(80, 16)
    Me.Label10.TabIndex = 202
    Me.Label10.Text = "City/State/Zip"
    '
    'TxtLCity
    '
    Me.TxtLCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLCity.Location = New System.Drawing.Point(574, 137)
    Me.TxtLCity.MaxLength = 25
    Me.TxtLCity.Name = "TxtLCity"
    Me.TxtLCity.Size = New System.Drawing.Size(232, 20)
    Me.TxtLCity.TabIndex = 13
    '
    'TxtLState
    '
    Me.TxtLState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLState.Location = New System.Drawing.Point(814, 137)
    Me.TxtLState.MaxLength = 2
    Me.TxtLState.Name = "TxtLState"
    Me.TxtLState.Size = New System.Drawing.Size(24, 20)
    Me.TxtLState.TabIndex = 14
    '
    'TxtLAddr
    '
    Me.TxtLAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLAddr.Location = New System.Drawing.Point(574, 90)
    Me.TxtLAddr.MaxLength = 35
    Me.TxtLAddr.Name = "TxtLAddr"
    Me.TxtLAddr.Size = New System.Drawing.Size(280, 20)
    Me.TxtLAddr.TabIndex = 11
    '
    'TxtLName
    '
    Me.TxtLName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLName.Location = New System.Drawing.Point(574, 66)
    Me.TxtLName.MaxLength = 35
    Me.TxtLName.Name = "TxtLName"
    Me.TxtLName.Size = New System.Drawing.Size(280, 20)
    Me.TxtLName.TabIndex = 10
    '
    'TxtLEmail
    '
    Me.TxtLEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLEmail.Location = New System.Drawing.Point(574, 189)
    Me.TxtLEmail.MaxLength = 30
    Me.TxtLEmail.Name = "TxtLEmail"
    Me.TxtLEmail.Size = New System.Drawing.Size(280, 20)
    Me.TxtLEmail.TabIndex = 19
    '
    'Label12
    '
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(489, 191)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(80, 16)
    Me.Label12.TabIndex = 200
    Me.Label12.Text = "Email"
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(97, 43)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(199, 13)
    Me.Label8.TabIndex = 192
    Me.Label8.Text = "1. Direct questions concerning return to -"
    '
    'TxtDZip4
    '
    Me.TxtDZip4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDZip4.Location = New System.Drawing.Point(419, 137)
    Me.TxtDZip4.MaxLength = 4
    Me.TxtDZip4.Name = "TxtDZip4"
    Me.TxtDZip4.Size = New System.Drawing.Size(32, 20)
    Me.TxtDZip4.TabIndex = 6
    '
    'TxtDZip5
    '
    Me.TxtDZip5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDZip5.Location = New System.Drawing.Point(371, 137)
    Me.TxtDZip5.MaxLength = 5
    Me.TxtDZip5.Name = "TxtDZip5"
    Me.TxtDZip5.Size = New System.Drawing.Size(40, 20)
    Me.TxtDZip5.TabIndex = 5
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(6, 141)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(80, 16)
    Me.Label4.TabIndex = 191
    Me.Label4.Text = "City/State/Zip"
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(7, 69)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(80, 16)
    Me.Label3.TabIndex = 190
    Me.Label3.Text = "Name"
    '
    'TxtDCity
    '
    Me.TxtDCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDCity.Location = New System.Drawing.Point(96, 137)
    Me.TxtDCity.MaxLength = 25
    Me.TxtDCity.Name = "TxtDCity"
    Me.TxtDCity.Size = New System.Drawing.Size(232, 20)
    Me.TxtDCity.TabIndex = 3
    '
    'TxtDState
    '
    Me.TxtDState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDState.Location = New System.Drawing.Point(339, 137)
    Me.TxtDState.MaxLength = 2
    Me.TxtDState.Name = "TxtDState"
    Me.TxtDState.Size = New System.Drawing.Size(24, 20)
    Me.TxtDState.TabIndex = 4
    '
    'TxtDAddr
    '
    Me.TxtDAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDAddr.Location = New System.Drawing.Point(97, 90)
    Me.TxtDAddr.MaxLength = 35
    Me.TxtDAddr.Name = "TxtDAddr"
    Me.TxtDAddr.Size = New System.Drawing.Size(280, 20)
    Me.TxtDAddr.TabIndex = 1
    '
    'TxtDName
    '
    Me.TxtDName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDName.Location = New System.Drawing.Point(97, 66)
    Me.TxtDName.MaxLength = 35
    Me.TxtDName.Name = "TxtDName"
    Me.TxtDName.Size = New System.Drawing.Size(280, 20)
    Me.TxtDName.TabIndex = 0
    '
    'TxtDPhone
    '
    Me.TxtDPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDPhone.Location = New System.Drawing.Point(96, 164)
    Me.TxtDPhone.MaxLength = 20
    Me.TxtDPhone.Name = "TxtDPhone"
    Me.TxtDPhone.Size = New System.Drawing.Size(144, 20)
    Me.TxtDPhone.TabIndex = 7
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(6, 167)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(80, 16)
    Me.Label5.TabIndex = 189
    Me.Label5.Text = "Phone/Fax"
    '
    'Tp7to12
    '
    Me.Tp7to12.Controls.Add(Me.Label37)
    Me.Tp7to12.Controls.Add(Me.Label36)
    Me.Tp7to12.Controls.Add(Me.Label35)
    Me.Tp7to12.Controls.Add(Me.Label18)
    Me.Tp7to12.Controls.Add(Me.ChkLessee)
    Me.Tp7to12.Controls.Add(Me.ChkLessor)
    Me.Tp7to12.Controls.Add(Me.ChkOthBus)
    Me.Tp7to12.Controls.Add(Me.GroupBox2)
    Me.Tp7to12.Controls.Add(Me.ChkPropCT)
    Me.Tp7to12.Controls.Add(Me.GroupBox4)
    Me.Tp7to12.Location = New System.Drawing.Point(4, 22)
    Me.Tp7to12.Name = "Tp7to12"
    Me.Tp7to12.Padding = New System.Windows.Forms.Padding(3)
    Me.Tp7to12.Size = New System.Drawing.Size(953, 391)
    Me.Tp7to12.TabIndex = 1
    Me.Tp7to12.Text = "Questions 7 to 12"
    Me.Tp7to12.UseVisualStyleBackColor = True
    '
    'Label37
    '
    Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label37.Location = New System.Drawing.Point(580, 149)
    Me.Label37.Name = "Label37"
    Me.Label37.Size = New System.Drawing.Size(80, 16)
    Me.Label37.TabIndex = 194
    Me.Label37.Text = "(Towns Tab)"
    '
    'Label36
    '
    Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label36.Location = New System.Drawing.Point(580, 198)
    Me.Label36.Name = "Label36"
    Me.Label36.Size = New System.Drawing.Size(80, 16)
    Me.Label36.TabIndex = 193
    Me.Label36.Text = "(Business Tab)"
    '
    'Label35
    '
    Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label35.Location = New System.Drawing.Point(580, 247)
    Me.Label35.Name = "Label35"
    Me.Label35.Size = New System.Drawing.Size(80, 16)
    Me.Label35.TabIndex = 192
    Me.Label35.Text = "(Lessor Tab)"
    '
    'Label18
    '
    Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label18.Location = New System.Drawing.Point(580, 297)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(80, 16)
    Me.Label18.TabIndex = 191
    Me.Label18.Text = "(Lessee Tab)"
    '
    'ChkLessee
    '
    Me.ChkLessee.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkLessee.Enabled = False
    Me.ChkLessee.Location = New System.Drawing.Point(17, 287)
    Me.ChkLessee.Name = "ChkLessee"
    Me.ChkLessee.Size = New System.Drawing.Size(528, 34)
    Me.ChkLessee.TabIndex = 4
    Me.ChkLessee.Text = "12. Did you have in your possession on October 1st any borrowed, consigned, store" &
    "d or rented property?    If yes, complete Lessee's Listing Report"
    Me.ChkLessee.UseVisualStyleBackColor = True
    '
    'ChkLessor
    '
    Me.ChkLessor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkLessor.Enabled = False
    Me.ChkLessor.Location = New System.Drawing.Point(17, 237)
    Me.ChkLessor.Name = "ChkLessor"
    Me.ChkLessor.Size = New System.Drawing.Size(528, 34)
    Me.ChkLessor.TabIndex = 3
    Me.ChkLessor.Text = "11. Do you own tangible personal property that is leased or consigned to others i" &
    "n this town?                       If yes, complete Lessor's Listing Report "
    Me.ChkLessor.UseVisualStyleBackColor = True
    '
    'ChkOthBus
    '
    Me.ChkOthBus.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkOthBus.Location = New System.Drawing.Point(17, 188)
    Me.ChkOthBus.Name = "ChkOthBus"
    Me.ChkOthBus.Size = New System.Drawing.Size(528, 34)
    Me.ChkOthBus.TabIndex = 2
    Me.ChkOthBus.Text = "10. Are there any other business operations that are operating from your address " &
    "here in this town?              If yes give name and mailing address."
    Me.ChkOthBus.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.TxtIrsbus)
    Me.GroupBox2.Controls.Add(Me.Label40)
    Me.GroupBox2.Controls.Add(Me.RbBusLes)
    Me.GroupBox2.Controls.Add(Me.RbBusTrade)
    Me.GroupBox2.Controls.Add(Me.RbBusRet)
    Me.GroupBox2.Controls.Add(Me.TxtBusOth)
    Me.GroupBox2.Controls.Add(Me.RbBusProf)
    Me.GroupBox2.Controls.Add(Me.RbBusServ)
    Me.GroupBox2.Controls.Add(Me.RbBusWhole)
    Me.GroupBox2.Controls.Add(Me.RbBusOther)
    Me.GroupBox2.Controls.Add(Me.RbBusManuf)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(11, 75)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(692, 63)
    Me.GroupBox2.TabIndex = 0
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "8. Type of business"
    '
    'TxtIrsbus
    '
    Me.TxtIrsbus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtIrsbus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtIrsbus.Location = New System.Drawing.Point(612, 39)
    Me.TxtIrsbus.MaxLength = 6
    Me.TxtIrsbus.Name = "TxtIrsbus"
    Me.TxtIrsbus.Size = New System.Drawing.Size(53, 20)
    Me.TxtIrsbus.TabIndex = 9
    '
    'Label40
    '
    Me.Label40.AutoSize = True
    Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label40.Location = New System.Drawing.Point(471, 42)
    Me.Label40.Name = "Label40"
    Me.Label40.Size = New System.Drawing.Size(135, 13)
    Me.Label40.TabIndex = 211
    Me.Label40.Text = "IRS Business Activity Code"
    '
    'RbBusLes
    '
    Me.RbBusLes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbBusLes.Location = New System.Drawing.Point(610, 19)
    Me.RbBusLes.Name = "RbBusLes"
    Me.RbBusLes.Size = New System.Drawing.Size(66, 18)
    Me.RbBusLes.TabIndex = 6
    Me.RbBusLes.Text = "Lessor"
    '
    'RbBusTrade
    '
    Me.RbBusTrade.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbBusTrade.Location = New System.Drawing.Point(512, 19)
    Me.RbBusTrade.Name = "RbBusTrade"
    Me.RbBusTrade.Size = New System.Drawing.Size(89, 18)
    Me.RbBusTrade.TabIndex = 5
    Me.RbBusTrade.Text = "Tradesman"
    '
    'RbBusRet
    '
    Me.RbBusRet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbBusRet.Location = New System.Drawing.Point(386, 19)
    Me.RbBusRet.Name = "RbBusRet"
    Me.RbBusRet.Size = New System.Drawing.Size(111, 18)
    Me.RbBusRet.TabIndex = 4
    Me.RbBusRet.Text = "Retail/Mercantile"
    '
    'TxtBusOth
    '
    Me.TxtBusOth.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBusOth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBusOth.Location = New System.Drawing.Point(89, 37)
    Me.TxtBusOth.MaxLength = 40
    Me.TxtBusOth.Name = "TxtBusOth"
    Me.TxtBusOth.Size = New System.Drawing.Size(280, 20)
    Me.TxtBusOth.TabIndex = 8
    '
    'RbBusProf
    '
    Me.RbBusProf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbBusProf.Location = New System.Drawing.Point(291, 19)
    Me.RbBusProf.Name = "RbBusProf"
    Me.RbBusProf.Size = New System.Drawing.Size(89, 18)
    Me.RbBusProf.TabIndex = 3
    Me.RbBusProf.Text = "Profession"
    '
    'RbBusServ
    '
    Me.RbBusServ.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbBusServ.Location = New System.Drawing.Point(207, 19)
    Me.RbBusServ.Name = "RbBusServ"
    Me.RbBusServ.Size = New System.Drawing.Size(65, 18)
    Me.RbBusServ.TabIndex = 2
    Me.RbBusServ.Text = "Service"
    '
    'RbBusWhole
    '
    Me.RbBusWhole.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbBusWhole.Location = New System.Drawing.Point(113, 19)
    Me.RbBusWhole.Name = "RbBusWhole"
    Me.RbBusWhole.Size = New System.Drawing.Size(91, 18)
    Me.RbBusWhole.TabIndex = 1
    Me.RbBusWhole.Text = "Wholesale"
    '
    'RbBusOther
    '
    Me.RbBusOther.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbBusOther.Location = New System.Drawing.Point(6, 39)
    Me.RbBusOther.Name = "RbBusOther"
    Me.RbBusOther.Size = New System.Drawing.Size(54, 18)
    Me.RbBusOther.TabIndex = 7
    Me.RbBusOther.Text = "Other"
    '
    'RbBusManuf
    '
    Me.RbBusManuf.Checked = True
    Me.RbBusManuf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbBusManuf.Location = New System.Drawing.Point(6, 19)
    Me.RbBusManuf.Name = "RbBusManuf"
    Me.RbBusManuf.Size = New System.Drawing.Size(101, 18)
    Me.RbBusManuf.TabIndex = 0
    Me.RbBusManuf.TabStop = True
    Me.RbBusManuf.Text = "Manufacturer"
    '
    'ChkPropCT
    '
    Me.ChkPropCT.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPropCT.Location = New System.Drawing.Point(15, 139)
    Me.ChkPropCT.Name = "ChkPropCT"
    Me.ChkPropCT.Size = New System.Drawing.Size(528, 34)
    Me.ChkPropCT.TabIndex = 1
    Me.ChkPropCT.Text = " 9. In the last 12 months was any property included in this declaration located i" &
    "n another Connecticut town for at least 3 months? If yes, identify by specific m" &
    "onths, code, cost and location(s)."
    Me.ChkPropCT.UseVisualStyleBackColor = True
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.TxtOwnOth)
    Me.GroupBox4.Controls.Add(Me.RbOwnSole)
    Me.GroupBox4.Controls.Add(Me.RbOwnLLC)
    Me.GroupBox4.Controls.Add(Me.RbOwnPartner)
    Me.GroupBox4.Controls.Add(Me.RbOwnOther)
    Me.GroupBox4.Controls.Add(Me.RbOwnCorp)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(9, 6)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(382, 63)
    Me.GroupBox4.TabIndex = 0
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "7. Type of ownership"
    '
    'TxtOwnOth
    '
    Me.TxtOwnOth.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOwnOth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOwnOth.Location = New System.Drawing.Point(89, 37)
    Me.TxtOwnOth.MaxLength = 40
    Me.TxtOwnOth.Name = "TxtOwnOth"
    Me.TxtOwnOth.Size = New System.Drawing.Size(280, 20)
    Me.TxtOwnOth.TabIndex = 5
    '
    'RbOwnSole
    '
    Me.RbOwnSole.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbOwnSole.Location = New System.Drawing.Point(278, 19)
    Me.RbOwnSole.Name = "RbOwnSole"
    Me.RbOwnSole.Size = New System.Drawing.Size(98, 18)
    Me.RbOwnSole.TabIndex = 3
    Me.RbOwnSole.Text = "Sole Proprietor"
    '
    'RbOwnLLC
    '
    Me.RbOwnLLC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbOwnLLC.Location = New System.Drawing.Point(207, 19)
    Me.RbOwnLLC.Name = "RbOwnLLC"
    Me.RbOwnLLC.Size = New System.Drawing.Size(54, 18)
    Me.RbOwnLLC.TabIndex = 2
    Me.RbOwnLLC.Text = "LLC"
    '
    'RbOwnPartner
    '
    Me.RbOwnPartner.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbOwnPartner.Location = New System.Drawing.Point(113, 19)
    Me.RbOwnPartner.Name = "RbOwnPartner"
    Me.RbOwnPartner.Size = New System.Drawing.Size(91, 18)
    Me.RbOwnPartner.TabIndex = 1
    Me.RbOwnPartner.Text = "Partnership"
    '
    'RbOwnOther
    '
    Me.RbOwnOther.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbOwnOther.Location = New System.Drawing.Point(6, 39)
    Me.RbOwnOther.Name = "RbOwnOther"
    Me.RbOwnOther.Size = New System.Drawing.Size(54, 18)
    Me.RbOwnOther.TabIndex = 4
    Me.RbOwnOther.Text = "Other"
    '
    'RbOwnCorp
    '
    Me.RbOwnCorp.Checked = True
    Me.RbOwnCorp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbOwnCorp.Location = New System.Drawing.Point(6, 19)
    Me.RbOwnCorp.Name = "RbOwnCorp"
    Me.RbOwnCorp.Size = New System.Drawing.Size(85, 18)
    Me.RbOwnCorp.TabIndex = 0
    Me.RbOwnCorp.TabStop = True
    Me.RbOwnCorp.Text = "Corporation"
    '
    'TpAff
    '
    Me.TpAff.Controls.Add(Me.Label24)
    Me.TpAff.Controls.Add(Me.GroupBox3)
    Me.TpAff.Controls.Add(Me.GroupBox5)
    Me.TpAff.Location = New System.Drawing.Point(4, 22)
    Me.TpAff.Name = "TpAff"
    Me.TpAff.Size = New System.Drawing.Size(953, 391)
    Me.TpAff.TabIndex = 2
    Me.TpAff.Text = "Affidavit"
    Me.TpAff.UseVisualStyleBackColor = True
    '
    'Label24
    '
    Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label24.Location = New System.Drawing.Point(229, 5)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(338, 18)
    Me.Label24.TabIndex = 223
    Me.Label24.Text = "DECLARATION OF PERSONAL PROPERTY AFFIDAVIT"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.RbBComm)
    Me.GroupBox3.Controls.Add(Me.RbBNotary)
    Me.GroupBox3.Controls.Add(Me.RbBJustice)
    Me.GroupBox3.Controls.Add(Me.RbBTown)
    Me.GroupBox3.Controls.Add(Me.RbBAssessor)
    Me.GroupBox3.Controls.Add(Me.Label25)
    Me.GroupBox3.Controls.Add(Me.DtPckBWit)
    Me.GroupBox3.Controls.Add(Me.TxtBWit)
    Me.GroupBox3.Controls.Add(Me.Label26)
    Me.GroupBox3.Controls.Add(Me.Label27)
    Me.GroupBox3.Controls.Add(Me.DtPckB)
    Me.GroupBox3.Controls.Add(Me.Label28)
    Me.GroupBox3.Controls.Add(Me.TxtBName)
    Me.GroupBox3.Controls.Add(Me.Label29)
    Me.GroupBox3.Controls.Add(Me.Label30)
    Me.GroupBox3.Controls.Add(Me.TxtBTitle)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(7, 184)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(934, 187)
    Me.GroupBox3.TabIndex = 222
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Section B"
    '
    'RbBComm
    '
    Me.RbBComm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbBComm.Location = New System.Drawing.Point(565, 163)
    Me.RbBComm.Name = "RbBComm"
    Me.RbBComm.Size = New System.Drawing.Size(178, 18)
    Me.RbBComm.TabIndex = 239
    Me.RbBComm.Text = "Commissioner of Superior Court"
    '
    'RbBNotary
    '
    Me.RbBNotary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbBNotary.Location = New System.Drawing.Point(487, 163)
    Me.RbBNotary.Name = "RbBNotary"
    Me.RbBNotary.Size = New System.Drawing.Size(60, 18)
    Me.RbBNotary.TabIndex = 238
    Me.RbBNotary.Text = "Notary"
    '
    'RbBJustice
    '
    Me.RbBJustice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbBJustice.Location = New System.Drawing.Point(343, 164)
    Me.RbBJustice.Name = "RbBJustice"
    Me.RbBJustice.Size = New System.Drawing.Size(124, 18)
    Me.RbBJustice.TabIndex = 237
    Me.RbBJustice.Text = "Justice of the Peace"
    '
    'RbBTown
    '
    Me.RbBTown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbBTown.Location = New System.Drawing.Point(243, 165)
    Me.RbBTown.Name = "RbBTown"
    Me.RbBTown.Size = New System.Drawing.Size(84, 18)
    Me.RbBTown.TabIndex = 236
    Me.RbBTown.Text = "Town Clerk"
    '
    'RbBAssessor
    '
    Me.RbBAssessor.Checked = True
    Me.RbBAssessor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbBAssessor.Location = New System.Drawing.Point(129, 165)
    Me.RbBAssessor.Name = "RbBAssessor"
    Me.RbBAssessor.Size = New System.Drawing.Size(95, 18)
    Me.RbBAssessor.TabIndex = 235
    Me.RbBAssessor.TabStop = True
    Me.RbBAssessor.Text = "Assessor/Staff"
    '
    'Label25
    '
    Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label25.Location = New System.Drawing.Point(426, 139)
    Me.Label25.Name = "Label25"
    Me.Label25.Size = New System.Drawing.Size(43, 22)
    Me.Label25.TabIndex = 234
    Me.Label25.Text = "Dated"
    '
    'DtPckBWit
    '
    Me.DtPckBWit.Checked = False
    Me.DtPckBWit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckBWit.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckBWit.Location = New System.Drawing.Point(475, 135)
    Me.DtPckBWit.Name = "DtPckBWit"
    Me.DtPckBWit.ShowCheckBox = True
    Me.DtPckBWit.Size = New System.Drawing.Size(108, 22)
    Me.DtPckBWit.TabIndex = 233
    '
    'TxtBWit
    '
    Me.TxtBWit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBWit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBWit.Location = New System.Drawing.Point(129, 139)
    Me.TxtBWit.MaxLength = 35
    Me.TxtBWit.Name = "TxtBWit"
    Me.TxtBWit.Size = New System.Drawing.Size(280, 20)
    Me.TxtBWit.TabIndex = 232
    '
    'Label26
    '
    Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label26.Location = New System.Drawing.Point(11, 137)
    Me.Label26.Name = "Label26"
    Me.Label26.Size = New System.Drawing.Size(73, 22)
    Me.Label26.TabIndex = 231
    Me.Label26.Text = "Witness"
    '
    'Label27
    '
    Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label27.Location = New System.Drawing.Point(423, 98)
    Me.Label27.Name = "Label27"
    Me.Label27.Size = New System.Drawing.Size(43, 22)
    Me.Label27.TabIndex = 230
    Me.Label27.Text = "Dated"
    '
    'DtPckB
    '
    Me.DtPckB.Checked = False
    Me.DtPckB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckB.Location = New System.Drawing.Point(472, 94)
    Me.DtPckB.Name = "DtPckB"
    Me.DtPckB.ShowCheckBox = True
    Me.DtPckB.Size = New System.Drawing.Size(111, 22)
    Me.DtPckB.TabIndex = 229
    '
    'Label28
    '
    Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label28.Location = New System.Drawing.Point(9, 70)
    Me.Label28.Name = "Label28"
    Me.Label28.Size = New System.Drawing.Size(73, 22)
    Me.Label28.TabIndex = 228
    Me.Label28.Text = "Title"
    '
    'TxtBName
    '
    Me.TxtBName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBName.Location = New System.Drawing.Point(129, 98)
    Me.TxtBName.MaxLength = 35
    Me.TxtBName.Name = "TxtBName"
    Me.TxtBName.Size = New System.Drawing.Size(280, 20)
    Me.TxtBName.TabIndex = 227
    '
    'Label29
    '
    Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label29.Location = New System.Drawing.Point(11, 96)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(73, 22)
    Me.Label29.TabIndex = 226
    Me.Label29.Text = "Print Name"
    '
    'Label30
    '
    Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label30.Location = New System.Drawing.Point(11, 16)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(755, 32)
    Me.Label30.TabIndex = 225
    Me.Label30.Text = resources.GetString("Label30.Text")
    '
    'TxtBTitle
    '
    Me.TxtBTitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBTitle.Location = New System.Drawing.Point(129, 70)
    Me.TxtBTitle.MaxLength = 25
    Me.TxtBTitle.Name = "TxtBTitle"
    Me.TxtBTitle.Size = New System.Drawing.Size(200, 20)
    Me.TxtBTitle.TabIndex = 224
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.Label31)
    Me.GroupBox5.Controls.Add(Me.DtPckA)
    Me.GroupBox5.Controls.Add(Me.Label32)
    Me.GroupBox5.Controls.Add(Me.TxtAName)
    Me.GroupBox5.Controls.Add(Me.Label33)
    Me.GroupBox5.Controls.Add(Me.Label34)
    Me.GroupBox5.Controls.Add(Me.TxtATitle)
    Me.GroupBox5.Controls.Add(Me.RbAMember)
    Me.GroupBox5.Controls.Add(Me.RbAPartner)
    Me.GroupBox5.Controls.Add(Me.RbACorporate)
    Me.GroupBox5.Controls.Add(Me.RbAOwner)
    Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox5.Location = New System.Drawing.Point(7, 17)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(934, 161)
    Me.GroupBox5.TabIndex = 221
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "Section A"
    '
    'Label31
    '
    Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label31.Location = New System.Drawing.Point(423, 133)
    Me.Label31.Name = "Label31"
    Me.Label31.Size = New System.Drawing.Size(43, 20)
    Me.Label31.TabIndex = 223
    Me.Label31.Text = "Dated"
    '
    'DtPckA
    '
    Me.DtPckA.Checked = False
    Me.DtPckA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckA.Location = New System.Drawing.Point(472, 129)
    Me.DtPckA.Name = "DtPckA"
    Me.DtPckA.ShowCheckBox = True
    Me.DtPckA.Size = New System.Drawing.Size(111, 22)
    Me.DtPckA.TabIndex = 222
    '
    'Label32
    '
    Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label32.Location = New System.Drawing.Point(6, 106)
    Me.Label32.Name = "Label32"
    Me.Label32.Size = New System.Drawing.Size(73, 22)
    Me.Label32.TabIndex = 13
    Me.Label32.Text = "Title"
    '
    'TxtAName
    '
    Me.TxtAName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAName.Location = New System.Drawing.Point(126, 131)
    Me.TxtAName.MaxLength = 35
    Me.TxtAName.Name = "TxtAName"
    Me.TxtAName.Size = New System.Drawing.Size(280, 20)
    Me.TxtAName.TabIndex = 12
    '
    'Label33
    '
    Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label33.Location = New System.Drawing.Point(5, 131)
    Me.Label33.Name = "Label33"
    Me.Label33.Size = New System.Drawing.Size(73, 22)
    Me.Label33.TabIndex = 11
    Me.Label33.Text = "Print Name"
    '
    'Label34
    '
    Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label34.Location = New System.Drawing.Point(8, 16)
    Me.Label34.Name = "Label34"
    Me.Label34.Size = New System.Drawing.Size(920, 41)
    Me.Label34.TabIndex = 6
    Me.Label34.Text = resources.GetString("Label34.Text")
    '
    'TxtATitle
    '
    Me.TxtATitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtATitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtATitle.Location = New System.Drawing.Point(126, 108)
    Me.TxtATitle.MaxLength = 25
    Me.TxtATitle.Name = "TxtATitle"
    Me.TxtATitle.Size = New System.Drawing.Size(201, 20)
    Me.TxtATitle.TabIndex = 5
    '
    'RbAMember
    '
    Me.RbAMember.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbAMember.Location = New System.Drawing.Point(295, 84)
    Me.RbAMember.Name = "RbAMember"
    Me.RbAMember.Size = New System.Drawing.Size(76, 18)
    Me.RbAMember.TabIndex = 3
    Me.RbAMember.Text = "Member"
    '
    'RbAPartner
    '
    Me.RbAPartner.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbAPartner.Location = New System.Drawing.Point(295, 60)
    Me.RbAPartner.Name = "RbAPartner"
    Me.RbAPartner.Size = New System.Drawing.Size(76, 18)
    Me.RbAPartner.TabIndex = 2
    Me.RbAPartner.Text = "Partner"
    '
    'RbACorporate
    '
    Me.RbACorporate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbACorporate.Location = New System.Drawing.Point(157, 84)
    Me.RbACorporate.Name = "RbACorporate"
    Me.RbACorporate.Size = New System.Drawing.Size(111, 18)
    Me.RbACorporate.TabIndex = 1
    Me.RbACorporate.Text = "Corporate Officer"
    '
    'RbAOwner
    '
    Me.RbAOwner.Checked = True
    Me.RbAOwner.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbAOwner.Location = New System.Drawing.Point(157, 60)
    Me.RbAOwner.Name = "RbAOwner"
    Me.RbAOwner.Size = New System.Drawing.Size(63, 18)
    Me.RbAOwner.TabIndex = 0
    Me.RbAOwner.TabStop = True
    Me.RbAOwner.Text = "Owner"
    '
    'TxtLoc
    '
    Me.TxtLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLoc.Location = New System.Drawing.Point(156, 91)
    Me.TxtLoc.MaxLength = 25
    Me.TxtLoc.Name = "TxtLoc"
    Me.TxtLoc.Size = New System.Drawing.Size(200, 20)
    Me.TxtLoc.TabIndex = 8
    '
    'TxtLocNo
    '
    Me.TxtLocNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLocNo.Location = New System.Drawing.Point(101, 91)
    Me.TxtLocNo.MaxLength = 7
    Me.TxtLocNo.Name = "TxtLocNo"
    Me.TxtLocNo.Size = New System.Drawing.Size(49, 20)
    Me.TxtLocNo.TabIndex = 7
    Me.TxtLocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(10, 91)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(88, 16)
    Me.Label6.TabIndex = 210
    Me.Label6.Text = "Location#/Name"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(8, 68)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(87, 13)
    Me.Label2.TabIndex = 209
    Me.Label2.Text = "DBA (2nd Name)"
    '
    'Label51
    '
    Me.Label51.Location = New System.Drawing.Point(400, 14)
    Me.Label51.Name = "Label51"
    Me.Label51.Size = New System.Drawing.Size(80, 16)
    Me.Label51.TabIndex = 208
    Me.Label51.Text = "Date Received"
    Me.Label51.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'DtPckRecvDt
    '
    Me.DtPckRecvDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckRecvDt.Location = New System.Drawing.Point(489, 10)
    Me.DtPckRecvDt.Name = "DtPckRecvDt"
    Me.DtPckRecvDt.Size = New System.Drawing.Size(88, 20)
    Me.DtPckRecvDt.TabIndex = 4
    '
    'TxtOwname
    '
    Me.TxtOwname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOwname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOwname.Location = New System.Drawing.Point(100, 39)
    Me.TxtOwname.MaxLength = 35
    Me.TxtOwname.Name = "TxtOwname"
    Me.TxtOwname.Size = New System.Drawing.Size(228, 20)
    Me.TxtOwname.TabIndex = 5
    '
    'TxtDBA
    '
    Me.TxtDBA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDBA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDBA.Location = New System.Drawing.Point(100, 65)
    Me.TxtDBA.MaxLength = 35
    Me.TxtDBA.Name = "TxtDBA"
    Me.TxtDBA.Size = New System.Drawing.Size(228, 20)
    Me.TxtDBA.TabIndex = 6
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(8, 42)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(76, 13)
    Me.Label1.TabIndex = 207
    Me.Label1.Text = "Owner's Name"
    '
    'LnkListNo
    '
    Me.LnkListNo.Location = New System.Drawing.Point(12, 9)
    Me.LnkListNo.Name = "LnkListNo"
    Me.LnkListNo.Size = New System.Drawing.Size(48, 16)
    Me.LnkListNo.TabIndex = 99
    Me.LnkListNo.TabStop = True
    Me.LnkListNo.Text = "List No"
    '
    'TxtListNo
    '
    Me.TxtListNo.Location = New System.Drawing.Point(100, 9)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(62, 20)
    Me.TxtListNo.TabIndex = 0
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblYear.Location = New System.Drawing.Point(205, 11)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(33, 18)
    Me.LblYear.TabIndex = 2
    Me.LblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(168, 12)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(35, 17)
    Me.Label13.TabIndex = 213
    Me.Label13.Text = "Year"
    '
    'LblAuditYear
    '
    Me.LblAuditYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAuditYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAuditYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAuditYear.Location = New System.Drawing.Point(334, 11)
    Me.LblAuditYear.Name = "LblAuditYear"
    Me.LblAuditYear.Size = New System.Drawing.Size(31, 18)
    Me.LblAuditYear.TabIndex = 3
    Me.LblAuditYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label39
    '
    Me.Label39.Location = New System.Drawing.Point(268, 13)
    Me.Label39.Name = "Label39"
    Me.Label39.Size = New System.Drawing.Size(60, 16)
    Me.Label39.TabIndex = 215
    Me.Label39.Text = "Audit Year"
    '
    'Label38
    '
    Me.Label38.Location = New System.Drawing.Point(559, 109)
    Me.Label38.Name = "Label38"
    Me.Label38.Size = New System.Drawing.Size(78, 17)
    Me.Label38.TabIndex = 216
    Me.Label38.Text = "Business Type"
    '
    'LblBusType
    '
    Me.LblBusType.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblBusType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblBusType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBusType.Location = New System.Drawing.Point(644, 106)
    Me.LblBusType.Name = "LblBusType"
    Me.LblBusType.Size = New System.Drawing.Size(40, 18)
    Me.LblBusType.TabIndex = 217
    Me.LblBusType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblBusDesc
    '
    Me.LblBusDesc.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblBusDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblBusDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBusDesc.Location = New System.Drawing.Point(690, 106)
    Me.LblBusDesc.Name = "LblBusDesc"
    Me.LblBusDesc.Size = New System.Drawing.Size(264, 18)
    Me.LblBusDesc.TabIndex = 218
    Me.LblBusDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'GroupBox6
    '
    Me.GroupBox6.Controls.Add(Me.RbFileNon)
    Me.GroupBox6.Controls.Add(Me.RbFileLate)
    Me.GroupBox6.Controls.Add(Me.RbFileExt)
    Me.GroupBox6.Controls.Add(Me.RbFileOntime)
    Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox6.Location = New System.Drawing.Point(607, 6)
    Me.GroupBox6.Name = "GroupBox6"
    Me.GroupBox6.Size = New System.Drawing.Size(354, 36)
    Me.GroupBox6.TabIndex = 219
    Me.GroupBox6.TabStop = False
    '
    'RbFileNon
    '
    Me.RbFileNon.AutoSize = True
    Me.RbFileNon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFileNon.Location = New System.Drawing.Point(267, 10)
    Me.RbFileNon.Name = "RbFileNon"
    Me.RbFileNon.Size = New System.Drawing.Size(67, 17)
    Me.RbFileNon.TabIndex = 3
    Me.RbFileNon.Text = "Non-Filer"
    '
    'RbFileLate
    '
    Me.RbFileLate.AutoSize = True
    Me.RbFileLate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFileLate.Location = New System.Drawing.Point(195, 10)
    Me.RbFileLate.Name = "RbFileLate"
    Me.RbFileLate.Size = New System.Drawing.Size(46, 17)
    Me.RbFileLate.TabIndex = 2
    Me.RbFileLate.Text = "Late"
    '
    'RbFileExt
    '
    Me.RbFileExt.AutoSize = True
    Me.RbFileExt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFileExt.Location = New System.Drawing.Point(97, 10)
    Me.RbFileExt.Name = "RbFileExt"
    Me.RbFileExt.Size = New System.Drawing.Size(71, 17)
    Me.RbFileExt.TabIndex = 1
    Me.RbFileExt.Text = "Extension"
    '
    'RbFileOntime
    '
    Me.RbFileOntime.AutoSize = True
    Me.RbFileOntime.Checked = True
    Me.RbFileOntime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFileOntime.Location = New System.Drawing.Point(6, 10)
    Me.RbFileOntime.Name = "RbFileOntime"
    Me.RbFileOntime.Size = New System.Drawing.Size(65, 17)
    Me.RbFileOntime.TabIndex = 0
    Me.RbFileOntime.TabStop = True
    Me.RbFileOntime.Text = "On Time"
    '
    'GroupBox7
    '
    Me.GroupBox7.Controls.Add(Me.RbStatIncr)
    Me.GroupBox7.Controls.Add(Me.RbStatInact)
    Me.GroupBox7.Controls.Add(Me.RbStatPend)
    Me.GroupBox7.Controls.Add(Me.RbStatActive)
    Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox7.Location = New System.Drawing.Point(607, 49)
    Me.GroupBox7.Name = "GroupBox7"
    Me.GroupBox7.Size = New System.Drawing.Size(354, 36)
    Me.GroupBox7.TabIndex = 220
    Me.GroupBox7.TabStop = False
    '
    'RbStatIncr
    '
    Me.RbStatIncr.AutoSize = True
    Me.RbStatIncr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbStatIncr.Location = New System.Drawing.Point(83, 10)
    Me.RbStatIncr.Name = "RbStatIncr"
    Me.RbStatIncr.Size = New System.Drawing.Size(66, 17)
    Me.RbStatIncr.TabIndex = 1
    Me.RbStatIncr.Text = "Increase"
    '
    'RbStatInact
    '
    Me.RbStatInact.AutoSize = True
    Me.RbStatInact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbStatInact.Location = New System.Drawing.Point(274, 10)
    Me.RbStatInact.Name = "RbStatInact"
    Me.RbStatInact.Size = New System.Drawing.Size(63, 17)
    Me.RbStatInact.TabIndex = 3
    Me.RbStatInact.Text = "Inactive"
    '
    'RbStatPend
    '
    Me.RbStatPend.AutoSize = True
    Me.RbStatPend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbStatPend.Location = New System.Drawing.Point(177, 10)
    Me.RbStatPend.Name = "RbStatPend"
    Me.RbStatPend.Size = New System.Drawing.Size(64, 17)
    Me.RbStatPend.TabIndex = 2
    Me.RbStatPend.Text = "Pending"
    '
    'RbStatActive
    '
    Me.RbStatActive.AutoSize = True
    Me.RbStatActive.Checked = True
    Me.RbStatActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbStatActive.Location = New System.Drawing.Point(6, 10)
    Me.RbStatActive.Name = "RbStatActive"
    Me.RbStatActive.Size = New System.Drawing.Size(55, 17)
    Me.RbStatActive.TabIndex = 0
    Me.RbStatActive.TabStop = True
    Me.RbStatActive.Text = "Active"
    '
    'ChkPrtcom
    '
    Me.ChkPrtcom.AutoSize = True
    Me.ChkPrtcom.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPrtcom.Location = New System.Drawing.Point(401, 38)
    Me.ChkPrtcom.Name = "ChkPrtcom"
    Me.ChkPrtcom.Size = New System.Drawing.Size(176, 17)
    Me.ChkPrtcom.TabIndex = 221
    Me.ChkPrtcom.Text = "Summary prints with comments?"
    Me.ChkPrtcom.UseVisualStyleBackColor = True
    '
    'FrmTAP01C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(969, 546)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkPrtcom)
    Me.Controls.Add(Me.GroupBox7)
    Me.Controls.Add(Me.GroupBox6)
    Me.Controls.Add(Me.LblBusDesc)
    Me.Controls.Add(Me.LblBusType)
    Me.Controls.Add(Me.Label38)
    Me.Controls.Add(Me.LblAuditYear)
    Me.Controls.Add(Me.Label39)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.TabCtl2)
    Me.Controls.Add(Me.TxtLoc)
    Me.Controls.Add(Me.TxtLocNo)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label51)
    Me.Controls.Add(Me.DtPckRecvDt)
    Me.Controls.Add(Me.TxtOwname)
    Me.Controls.Add(Me.TxtDBA)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LnkListNo)
    Me.Controls.Add(Me.TxtListNo)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAP01C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Personal Property Declaration"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TabCtl2.ResumeLayout(False)
    Me.Tp1to6.ResumeLayout(False)
    Me.Tp1to6.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.Tp7to12.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    Me.TpAff.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
    Me.GroupBox6.ResumeLayout(False)
    Me.GroupBox6.PerformLayout()
    Me.GroupBox7.ResumeLayout(False)
    Me.GroupBox7.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTAP01C_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP01
      .TbForms.Visible = False
      .TBarDecl.Enabled = True
      .TBarComments.Enabled = False
    End With
  End Sub

  Private Sub FrmTAP01C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkAttachCount As Integer
    Dim dsTXDCCOM As DataSet = New DataSet
    MyTXDCCD = New TXDCCD.MyData(myDBConnect)
    MyTXDCDEP = New TXDCDEP.MyData(myDBConnect)
    MyTXDCDTL = New TXDCDTL.MyData(myDBConnect)
    MyTXDCPP = New TXDCPP.MyData(myDBConnect)
    MyTXPPRP = New TXPPRP.MyData(myDBConnect)
    MyTXDCCOM = New TXDCCOM.MyData(myDBConnect)

    LoadScrn = True
    TxtListNo.Focus()
    With MyFrmTAP01
      .TBarNew.Enabled = False
      .TBarSave.Enabled = True
      .TbForms.Visible = True
      .TBarDecl.Enabled = False
      .TBarComments.Enabled = True
    End With

    AddMode = False

    'Fill the dataset with the data
    If WrkListNo > 0 Then
      Me.Text = "Maintain " & Me.Text
      MyFrmTAP01.TBarDelete.Enabled = True
      MyFrmTAP01.TBarPrint.Enabled = False
      TxtListNo.Text = WrkListNo
      LnkListNo.Enabled = False
      TxtListNo.ReadOnly = True
      DtPckRecvDt.Value = Date.Today
      MyTXDCPP.GetOneRecordP(WrkListNo, WrkYear)
      If MyTXDCPP.RecordNotFound Then
        MyFrmTAP01.TBarNew.Enabled = False
        MyFrmTAP01.TBarSave.Enabled = False
        MyFrmTAP01.TBarDelete.Enabled = False
        Me.ErrProv.SetError(TxtListNo, "Record not found")
        Exit Sub
      End If

      MyFrmTAP01.TBarAttach.Enabled = True
      WrkAttachCount = GetAttachcount(“PPDECL”, WrkListNo)
      MyFrmTAP01.TBarAttach.Text = WrkAttachCount & " Attachment(s)"

      With MyTXDCPP
        TxtListNo.Text = ._LISTNO
        LblYear.Text = ._YEAR
        If ._RECVDT > 0 Then
          DtPckRecvDt.Value = MyUtils.GetDBDate(._RECVDT)
        Else
          DtPckRecvDt.Value = Date.Today
        End If
        Select Case Trim(._FILSTS)
          Case ""
            RbFileOntime.Checked = True
          Case "E"
            RbFileExt.Checked = True
          Case "L"
            RbFileLate.Checked = True
          Case "N"
            RbFileNon.Checked = True
        End Select
        Select Case Trim(._STATUS)
          Case ""
            RbStatActive.Checked = True
          Case "C"
            RbStatIncr.Checked = True
          Case "P"
            RbStatPend.Checked = True
          Case "I"
            RbStatInact.Checked = True
        End Select
        If ._PRTCOM = "Y" Then
          ChkPrtcom.Checked = True
        Else
          ChkPrtcom.Checked = False
        End If
        TxtOwname.Text = Trim(._OWNAME)
        TxtDBA.Text = Trim(._DBA)
        TxtLocNo.Text = Trim(._LOCNO)
        TxtLoc.Text = Trim(._LOC)
        TxtDName.Text = Trim(._DNAME)
        TxtDAddr.Text = Trim(._DADDR)
        TxtDAddr2.Text = Trim(._DADDR2)
        TxtDCity.Text = Trim(._DCITY)
        TxtDState.Text = Trim(._DSTATE)
        If ._DZIP5 > 0 Then
          TxtDZip5.Text = Format(._DZIP5, "00000")
        End If
        If ._DZIP4 > 0 Then
          TxtDZip4.Text = Format(._DZIP4, "0000")
        End If
        TxtDPhone.Text = Trim(._DPHONE)
        TxtDFax.Text = Trim(._DFAX)
        TxtDEmail.Text = Trim(._DEMAIL)
        TxtLName.Text = Trim(._LNAME)
        TxtLAddr.Text = Trim(._LADDR)
        TxtLAddr2.Text = Trim(._LADDR2)
        TxtLCity.Text = Trim(._LCITY)
        TxtLState.Text = Trim(._LSTATE)
        If ._LZIP5 > 0 Then
          TxtLZip5.Text = Format(._LZIP5, "00000")
        End If
        If ._LZIP4 > 0 Then
          TxtLZip4.Text = Format(._LZIP4, "0000")
        End If
        TxtLPhone.Text = Trim(._LPHONE)
        TxtLFax.Text = Trim(._LFAX)
        TxtLEmail.Text = Trim(._LEMAIL)
        TxtBusDes.Text = Trim(._BUSDES)
        If ._NOEMPS > 0 Then
          TxtNoEmps.Text = ._NOEMPS
        End If
        If ._STRDT > 0 Then
          DtPckStrDt.Value = MyUtils.GetDBDate(._STRDT)
          DtPckStrDt.Checked = True
        Else
          DtPckStrDt.Value = Date.Today
          DtPckStrDt.Checked = False
        End If
        If ._SQFEET > 0 Then
          TxtSqfeet.Text = ._SQFEET
        End If
        If ._OWN = "Y" Then
          RbOwn.Checked = True
        Else
          RbLease.Checked = True
        End If
        TxtOwnOth.Enabled = False
        Select Case Trim(._OWNTYP)
          Case "C"
            RbOwnCorp.Checked = True
          Case "P"
            RbOwnPartner.Checked = True
          Case "L"
            RbOwnLLC.Checked = True
          Case "S"
            RbOwnSole.Checked = True
          Case Else
            RbOwnOther.Checked = True
            TxtOwnOth.Enabled = True
            TxtOwnOth.Text = Trim(._OWNOTH)
        End Select
        TxtBusOth.Enabled = False
        Select Case Trim(._BUSCAT)
          Case "M"
            RbBusManuf.Checked = True
          Case "W"
            RbBusWhole.Checked = True
          Case "S"
            RbBusServ.Checked = True
          Case "P"
            RbBusProf.Checked = True
          Case "R"
            RbBusRet.Checked = True
          Case "T"
            RbBusTrade.Checked = True
          Case "L"
            RbBusLes.Checked = True
          Case Else
            RbBusOther.Checked = True
            TxtBusOth.Enabled = True
            TxtBusOth.Text = Trim(._BUSOTH)
        End Select
        TxtIrsbus.Text = ._IRSBUS
        ChkPropCT.Checked = False
        If Trim(._PROPCT) = "Y" Then
          ChkPropCT.Checked = True
        End If
        ChkOthBus.Checked = False
        If Trim(._OTHBUS) = "Y" Then
          ChkOthBus.Checked = True
        End If
        'Affidavit - Sections A & B
        Select Case Trim(._ASECCD)
          Case "O"
            RbAOwner.Checked = True
          Case "C"
            RbACorporate.Checked = True
          Case "P"
            RbAPartner.Checked = True
          Case "M"
            RbAMember.Checked = True
        End Select
        TxtATitle.Text = Trim(._ATITLE)
        If ._ADATE > 0 Then
          DtPckA.Value = MyUtils.GetDBDate(._ADATE)
          DtPckA.Checked = True
        Else
          DtPckA.Value = Date.Today
          DtPckA.Checked = False
        End If
        TxtAName.Text = Trim(._ANAME)
        TxtBTitle.Text = Trim(._BTITLE)
        If ._BDATE > 0 Then
          DtPckB.Value = MyUtils.GetDBDate(._BDATE)
          DtPckB.Checked = True
        Else
          DtPckB.Value = Date.Today
          DtPckB.Checked = False
        End If
        TxtBName.Text = Trim(._BNAME)
        If ._BWITDT > 0 Then
          DtPckBWit.Value = MyUtils.GetDBDate(._BWITDT)
          DtPckBWit.Checked = True
        Else
          DtPckBWit.Value = Date.Today
          DtPckBWit.Checked = False
        End If
        TxtBWit.Text = Trim(._BWIT)
        Select Case Trim(._BWITCD)
          Case "A"
            RbBAssessor.Checked = True
          Case "T"
            RbBTown.Checked = True
          Case "J"
            RbBJustice.Checked = True
          Case "N"
            RbBNotary.Checked = True
          Case "C"
            RbBComm.Checked = True
        End Select
      End With
      MyTXPPRP.GetOneRecordP(WrkListNo)
      If Not MyTXPPRP.RecordNotFound Then
        LblAuditYear.Text = MyTXPPRP._ADYR
        LblBusType.Text = MyTXPPRP._BUSTY
        LblBusDesc.Text = GetTXBustyDesc(MyTXPPRP._BUSTY)
      End If
    Else
      Me.Text = "Add " & Me.Text
      LblYear.Text = MyUtils.CnvSng(MyFrmTAP01B.TxtYear.Text)
      AddMode = True
      MyFrmTAP01.TBarDelete.Enabled = False
      MyFrmTAP01.TBarComments.Enabled = False
      MyFrmTAP01.TbForms.Visible = False
      If MyPrtComm Then
        ChkPrtcom.Checked = True
      End If
    End If

    dsTXDCCOM = MyTXDCCOM.Getcomments(WrkListNo, MyUtils.CnvSng(MyFrmTAP01B.TxtYear.Text))
    MyFrmTAP01.TBarComments.ImageKey = ""
    If dsTXDCCOM.Tables(0).Rows.Count > 0 Then
      MyFrmTAP01.TBarComments.ImageKey = "comment_24.png"
    End If

    LoadScrn = False
  End Sub

  Private Sub FrmTAP01C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTAP01.TBarNew.Enabled = True
    MyFrmTAP01.TBarSave.Enabled = False
    MyFrmTAP01.TBarDelete.Enabled = False
    MyFrmTAP01.TBarAttach.Enabled = False
    MyFrmTAP01.TBarAttach.Text = "Attachments"
    MyFrmTAP01.TBarPrint.Enabled = False
    MyFrmTAP01B.FormatGrid(True, False, False)
    MyFrmTAP01B.Show()
  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim MyTXDMPP As TXDMPP.MyData
    Dim MyTXDVPP As TXDVPP.MyData
    Dim Answer As Integer

    MyTXDMPP = New TXDMPP.MyData(myDBConnect)
    MyTXDVPP = New TXDVPP.MyData(myDBConnect)
    Cancel = True
    Answer = MsgBox("Delete record and all related declaration information for this list no/year?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    DeleteListNo()

    With MyTXDCPP
      .GetOneRecordP(WrkListNo, WrkYear)
      If Not .RecordNotFound Then
        .DeleteOneRecordP()
      End If
    End With

    With MyTXDMPP
      .GetOneRecordP(WrkListNo, WrkYear)
      If Not .RecordNotFound Then
        .DeleteOneRecordP()
      End If
    End With

    With MyTXDVPP
      .GetOneRecordP(WrkListNo, WrkYear)
      If Not .RecordNotFound Then
        .DeleteOneRecordP()
      End If
    End With
  End Sub
  Private Sub DeleteListNo()

    Dim MyTXDCAFF As TXDCAFF.MyData
    Dim MyTXDCASS As TXDCASS.MyData
    Dim MyTXDCBUS As TXDCBUS.MyData
    Dim MyTXDCCOM As TXDCCOM.MyData
    Dim MyTXDCDSP As TXDCDSP.MyData
    Dim MyTXDCDTL As TXDCDTL.MyData
    Dim MyTXDCEXM As TXDCEXM.MyData
    Dim MyTXDCHOR As TXDCHOR.MyData
    Dim MyTXDCLEE As TXDCLEE.MyData
    Dim MyTXDCLOR As TXDCLOR.MyData
    Dim MyTXDCMOB As TXDCMOB.MyData
    Dim MyTXDCMV As TXDCMV.MyData
    Dim MyTXDCSUM As TXDCSUM.MyData
    Dim MyTXDCTWN As TXDCTWN.MyData
    Dim MyTXDMLST As TXDMLST.MyData
    Dim MyTXDMSUM As TXDMSUM.MyData
    Dim MyTXDVPI As TXDVPI.MyData
    Dim MyTXDVPN As TXDVPN.MyData

    MyTXDCAFF = New TXDCAFF.MyData(myDBConnect)
    MyTXDCASS = New TXDCASS.MyData(myDBConnect)
    MyTXDCBUS = New TXDCBUS.MyData(myDBConnect)
    MyTXDCCOM = New TXDCCOM.MyData(myDBConnect)
    MyTXDCDSP = New TXDCDSP.MyData(myDBConnect)
    MyTXDCDTL = New TXDCDTL.MyData(myDBConnect)
    MyTXDCEXM = New TXDCEXM.MyData(myDBConnect)
    MyTXDCHOR = New TXDCHOR.MyData(myDBConnect)
    MyTXDCLEE = New TXDCLEE.MyData(myDBConnect)
    MyTXDCLOR = New TXDCLOR.MyData(myDBConnect)
    MyTXDCMOB = New TXDCMOB.MyData(myDBConnect)
    MyTXDCMV = New TXDCMV.MyData(myDBConnect)
    MyTXDCSUM = New TXDCSUM.MyData(myDBConnect)
    MyTXDCTWN = New TXDCTWN.MyData(myDBConnect)
    MyTXDMLST = New TXDMLST.MyData(myDBConnect)
    MyTXDMSUM = New TXDMSUM.MyData(myDBConnect)
    MyTXDVPI = New TXDVPI.MyData(myDBConnect)
    MyTXDVPN = New TXDVPN.MyData(myDBConnect)

    With MyTXDCAFF
      .GetOneRecordP(WrkListNo, WrkYear)
      If Not .RecordNotFound Then
        .DeleteOneRecordP()
      End If
    End With

    With MyTXDCASS
      .DeleteListNo(WrkListNo, WrkYear)
    End With

    With MyTXDCBUS
      .DeleteListNo(WrkListNo, WrkYear)
    End With

    With MyTXDCCOM
      .DeleteKEYcomment(WrkListNo, WrkYear)
    End With

    With MyTXDCDSP
      .DeleteListNo(WrkListNo, WrkYear)
    End With

    With MyTXDCDTL
      .DeleteListNo(WrkListNo, WrkYear)
    End With

    With MyTXDCEXM
      .DeleteListNo(WrkListNo, WrkYear)
    End With

    With MyTXDCHOR
      .DeleteListNo(WrkListNo, WrkYear)
    End With

    With MyTXDCLEE
      .DeleteListNo(WrkListNo, WrkYear)
    End With

    With MyTXDCLOR
      .DeleteListNo(WrkListNo, WrkYear)
    End With

    With MyTXDCMOB
      .DeleteListNo(WrkListNo, WrkYear)
    End With

    With MyTXDCMV
      .DeleteListNo(WrkListNo, WrkYear)
    End With

    With MyTXDCSUM
      .DeleteListNo(WrkListNo, WrkYear)
    End With

    With MyTXDCTWN
      .DeleteListNo(WrkListNo, WrkYear)
    End With

    With MyTXDMLST
      .DeleteListNo(WrkListNo, WrkYear)
    End With

    With MyTXDMSUM
      .DeleteListNo(WrkListNo, WrkYear)
    End With

    With MyTXDVPI
      .DeleteListNo(WrkListNo, WrkYear)
    End With

    With MyTXDVPN
      .DeleteListNo(WrkListNo, WrkYear)
    End With
  End Sub


  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    MyTXDCPP.GetOneRecordP(WrkListNo, WrkYear)
    If AddMode Then
      If Not MyTXDCPP.RecordNotFound Then
        Me.ErrProv.SetError(TxtListNo, "Record already exists")
        Exit Sub
      End If
    End If

    If Not AddMode Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXDCPP.UpdateOneRecordP()
        Me.Close()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXDCPP.AddOneRecordP()
        MyFrmTAP01.TBarComments.Enabled = True
        MyFrmTAP01.TbForms.Visible = True
        AddMode = False
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

  End Sub
  Private Sub MoveToFile()
    With MyTXDCPP
      ._LISTNO = MyUtils.CnvSng(TxtListNo.Text)
      ._YEAR = MyUtils.CnvSng(LblYear.Text)
      ._RECVDT = MyUtils.SetDBDate(DtPckRecvDt.Value)
      If RbFileOntime.Checked Then ._FILSTS = ""
      If RbFileExt.Checked Then ._FILSTS = "E"
      If RbFileLate.Checked Then ._FILSTS = "L"
      If RbFileNon.Checked Then ._FILSTS = "N"
      If RbStatActive.Checked Then ._STATUS = ""
      If RbStatIncr.Checked Then ._STATUS = "C"
      If RbStatPend.Checked Then ._STATUS = "P"
      If RbStatInact.Checked Then ._STATUS = "I"
      If ChkPrtcom.Checked Then
        ._PRTCOM = "Y"
      Else
        ._PRTCOM = "N"
      End If
      ._OWNAME = TxtOwname.Text
      ._DBA = TxtDBA.Text
      ._LOCNO = MyUtils.JustifyRight(Trim(TxtLocNo.Text), 7)
      ._LOC = TxtLoc.Text
      ._DNAME = TxtDName.Text
      ._DADDR = TxtDAddr.Text
      ._DADDR2 = TxtDAddr2.Text
      ._DCITY = TxtDCity.Text
      ._DSTATE = TxtDState.Text
      ._DZIP5 = MyUtils.CnvSng(TxtDZip5.Text)
      ._DZIP4 = MyUtils.CnvSng(TxtDZip4.Text)
      ._DPHONE = TxtDPhone.Text
      ._DFAX = TxtDFax.Text
      ._DEMAIL = TxtDEmail.Text
      ._LNAME = TxtLName.Text
      ._LADDR = TxtLAddr.Text
      ._LADDR2 = TxtLAddr2.Text
      ._LCITY = TxtLCity.Text
      ._LSTATE = TxtLState.Text
      ._LZIP5 = MyUtils.CnvSng(TxtLZip5.Text)
      ._LZIP4 = MyUtils.CnvSng(TxtLZip4.Text)
      ._LPHONE = TxtLPhone.Text
      ._LFAX = TxtLFax.Text
      ._LEMAIL = TxtLEmail.Text
      ._BUSDES = TxtBusDes.Text
      ._NOEMPS = MyUtils.CnvSng(TxtNoEmps.Text)
      If DtPckStrDt.Checked Then
        ._STRDT = MyUtils.SetDBDate(DtPckStrDt.Value)
      Else
        ._STRDT = 0
      End If
      ._SQFEET = MyUtils.CnvSng(TxtSqfeet.Text)
      If RbOwn.Checked Then
        ._OWN = "Y"
      Else
        ._OWN = "N"
      End If
      If RbOwnCorp.Checked Then ._OWNTYP = "C"
      If RbOwnPartner.Checked Then ._OWNTYP = "P"
      If RbOwnLLC.Checked Then ._OWNTYP = "L"
      If RbOwnSole.Checked Then ._OWNTYP = "S"
      If RbOwnOther.Checked Then ._OWNTYP = String.Empty
      ._OWNOTH = TxtOwnOth.Text
      If RbBusManuf.Checked Then ._BUSCAT = "M"
      If RbBusWhole.Checked Then ._BUSCAT = "W"
      If RbBusServ.Checked Then ._BUSCAT = "S"
      If RbBusProf.Checked Then ._BUSCAT = "P"
      If RbBusRet.Checked Then ._BUSCAT = "R"
      If RbBusTrade.Checked Then ._BUSCAT = "T"
      If RbBusLes.Checked Then ._BUSCAT = "L"
      If RbBusOther.Checked Then ._BUSCAT = String.Empty
      ._BUSOTH = TxtBusOth.Text
      If ChkPropCT.Checked Then
        ._PROPCT = "Y"
      Else
        ._PROPCT = "N"
      End If
      If ChkOthBus.Checked Then
        ._OTHBUS = "Y"
      Else
        ._OTHBUS = "N"
      End If
      ._IRSBUS = MyUtils.CnvSng(TxtIrsbus.Text)
      'Affidavit - Sections A & B
      If RbAOwner.Checked Then ._ASECCD = "O"
      If RbACorporate.Checked Then ._ASECCD = "C"
      If RbAPartner.Checked Then ._ASECCD = "P"
      If RbAMember.Checked Then ._ASECCD = "M"
      ._ATITLE = TxtATitle.Text
      If DtPckA.Checked Then
        ._ADATE = MyUtils.SetDBDate(DtPckA.Value)
      Else
        ._ADATE = 0
      End If
      ._ANAME = TxtAName.Text
      ._BTITLE = TxtBTitle.Text
      If DtPckB.Checked Then
        ._BDATE = MyUtils.SetDBDate(DtPckB.Value)
      Else
        ._BDATE = 0
      End If
      ._BNAME = TxtBName.Text
      If DtPckBWit.Checked Then
        ._BWITDT = MyUtils.SetDBDate(DtPckBWit.Value)
      Else
        ._BWITDT = 0
      End If
      ._BWIT = TxtBWit.Text
      If RbBAssessor.Checked Then ._BWITCD = "A"
      If RbBTown.Checked Then ._BWITCD = "T"
      If RbBJustice.Checked Then ._BWITCD = "J"
      If RbBNotary.Checked Then ._BWITCD = "N"
      If RbBComm.Checked Then ._BWITCD = "C"
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtListNo.Text) = 0 Then
      ErrorField(I) = "listno"
      ErrorMsg(I) = "List Number is required"
      I = I + 1
    End If

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtListNo, "")
    ErrProv.SetError(TxtDBA, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "listno"
          ErrProv.SetError(TxtListNo, ErrorMsg(I))
        Case ""
          Exit Sub
      End Select
    Next I
  End Sub
  Public Sub GetTXPPRP()

    MyTXPPRP.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text))
    If MyTXPPRP.RecordNotFound Then Exit Sub

    With MyTXPPRP
      TxtOwname.Text = Trim(._NAME)
      TxtDBA.Text = Trim(._SNAME)
      TxtLocNo.Text = Trim(._LOCNO)
      TxtLoc.Text = Trim(._LOC)
      TxtDName.Text = Trim(._NAME)
      TxtDAddr.Text = Trim(._ADD1)
      TxtDAddr2.Text = Trim(._ADD2)
      TxtDCity.Text = Trim(._CITY)
      TxtDState.Text = Trim(._STATE)
      TxtDZip5.Text = Format(._ZIP5, "00000")
      If ._ZIP4 > 0 Then
        TxtDZip4.Text = Format(._ZIP4, "0000")
      End If
      LblAuditYear.Text = ._ADYR
      LblBusType.Text = Trim(._BUSTY)
      LblBusDesc.Text = GetTXBustyDesc(MyTXPPRP._BUSTY)
    End With

  End Sub
  Public Sub GetLastYear()

    Dim ds2 As DataSet = New DataSet
    Dim WrkLastYear As Integer
    Dim WrkAnswer As Integer

    MyTXDCPP.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text), WrkYear)
    If Not MyTXDCPP.RecordNotFound Then
      MsgBox("Record already exists and will not be saved", MsgBoxStyle.Exclamation, "Add record not allowed")
      Exit Sub
    End If

    WrkLastYear = WrkYear - 1
    MyTXDCPP.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text), WrkLastYear)
    If MyTXDCPP.RecordNotFound Then Exit Sub
    WrkAnswer = MsgBox("Click OK to use last year's information or Cancel to not use it", MsgBoxStyle.OkCancel, "Previous year information found. Depreciation will be adjusted")
    If WrkAnswer = vbCancel Then Exit Sub

    With MyTXDCPP
      TxtOwname.Text = Trim(._OWNAME)
      TxtDBA.Text = Trim(._DBA)
      TxtLocNo.Text = Trim(._LOCNO)
      TxtLoc.Text = Trim(._LOC)
      TxtDName.Text = Trim(._DNAME)
      TxtDAddr.Text = Trim(._DADDR)
      TxtDAddr2.Text = Trim(._DADDR2)
      TxtDCity.Text = Trim(._DCITY)
      TxtDState.Text = Trim(._DSTATE)
      TxtDZip5.Text = Format(._DZIP5, "00000")
      If ._DZIP4 > 0 Then
        TxtDZip4.Text = Format(._DZIP4, "0000")
      End If
      TxtDPhone.Text = Trim(._DPHONE)
      TxtDFax.Text = Trim(._DFAX)
      TxtDEmail.Text = Trim(._DEMAIL)
      TxtLName.Text = Trim(._LNAME)
      TxtLAddr.Text = Trim(._LADDR)
      TxtLAddr2.Text = Trim(._LADDR2)
      TxtLCity.Text = Trim(._LCITY)
      TxtLState.Text = Trim(._LSTATE)
      If ._LZIP5 > 0 Then
        TxtLZip5.Text = Format(._LZIP5, "00000")
      End If
      If ._LZIP4 > 0 Then
        TxtLZip4.Text = Format(._LZIP4, "0000")
      End If
      TxtLPhone.Text = ._LPHONE
      TxtLFax.Text = ._LFAX
      TxtLEmail.Text = Trim(._LEMAIL)
      TxtBusDes.Text = Trim(._BUSDES)
      TxtIrsbus.Text = ._IRSBUS
      If ._PRTCOM = "Y" Then ChkPrtcom.Checked = True
      If ._NOEMPS > 0 Then
        TxtNoEmps.Text = ._NOEMPS
      End If
      If ._STRDT > 0 Then
        DtPckStrDt.Value = MyUtils.GetDBDate(._STRDT)
        DtPckStrDt.Checked = True
      Else
        DtPckStrDt.Value = Date.Today
        DtPckStrDt.Checked = False
      End If
      If ._SQFEET > 0 Then
        TxtSqfeet.Text = ._SQFEET
      End If
      If ._OWN = "Y" Then
        RbOwn.Checked = True
      Else
        RbLease.Checked = True
      End If
      TxtOwnOth.Enabled = False
      Select Case Trim(._OWNTYP)
        Case "C"
          RbOwnCorp.Checked = True
        Case "P"
          RbOwnPartner.Checked = True
        Case "L"
          RbOwnLLC.Checked = True
        Case "S"
          RbOwnSole.Checked = True
        Case Else
          RbOwnOther.Checked = True
          TxtOwnOth.Enabled = True
          TxtOwnOth.Text = Trim(._OWNOTH)
      End Select
      TxtBusOth.Enabled = False
      Select Case Trim(._BUSCAT)
        Case "M"
          RbBusManuf.Checked = True
        Case "W"
          RbBusWhole.Checked = True
        Case "S"
          RbBusServ.Checked = True
        Case "P"
          RbBusProf.Checked = True
        Case "R"
          RbBusRet.Checked = True
        Case "T"
          RbBusTrade.Checked = True
        Case "L"
          RbBusLes.Checked = True
        Case Else
          RbBusOther.Checked = True
          TxtBusOth.Enabled = True
          TxtBusOth.Text = Trim(._BUSOTH)
      End Select
      ChkPropCT.Checked = False
      If Trim(._PROPCT) = "Y" Then
        ChkPropCT.Checked = True
      End If
      ChkOthBus.Checked = False
      If Trim(._OTHBUS) = "Y" Then
        ChkOthBus.Checked = True
      End If
    End With
    MyTXPPRP.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text))
    If Not MyTXPPRP.RecordNotFound Then
      LblAuditYear.Text = MyTXPPRP._ADYR
      LblBusType.Text = MyTXPPRP._BUSTY
      LblBusDesc.Text = GetTXBustyDesc(MyTXPPRP._BUSTY)
    End If

    CopyRecords(MyUtils.CnvSng(TxtListNo.Text), WrkYear)
    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    MyFrmTAP01.TBarComments.Enabled = True
    MyFrmTAP01.TbForms.Visible = True
    AddMode = False
  End Sub
  Private Sub FrmTAP01C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "TAP01C"
    MyUtils.CenterForm(Me.ParentForm, Me)
    If Not AddMode Then
      MyFrmTAP01.TBarComments.Enabled = True
    End If
    With MyTXDCPP
      If ._STRDT > 0 Then
        DtPckStrDt.Checked = True
      End If
    End With

  End Sub
  Private Sub LnkListNo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkListNo.LinkClicked
    MyFrmListPPRP = New FrmListPPRP
    MyFrmListPPRP.MdiParent = Me.ParentForm
    MyFrmListPPRP.WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    MyFrmListPPRP.Show()
  End Sub
  Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtListNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtListNo.LostFocus
    If TxtListNo.Modified Then
      ErrProv.SetError(TxtListNo, "")
      If TxtOwname.Text = String.Empty Then
        GetLastYear()
      End If
      If TxtOwname.Text = String.Empty Then
        GetTXPPRP()
      End If
    End If
  End Sub
  Private Sub TxtDZip5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDZip5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDZip4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDZip4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtLZip5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLZip5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtLZip4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLZip4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtNoEmps_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoEmps.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSqfeet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSqfeet.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub RbOwnCorp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbOwnCorp.Click
    TxtOwnOth.Enabled = False
  End Sub
  Private Sub RbOwnPartner_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbOwnPartner.Click
    TxtOwnOth.Enabled = False
  End Sub
  Private Sub RbOwnLLC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbOwnLLC.Click
    TxtOwnOth.Enabled = False
  End Sub
  Private Sub RbOwnSole_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbOwnSole.Click
    TxtOwnOth.Enabled = False
  End Sub
  Private Sub RbOwnOther_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbOwnOther.Click
    TxtOwnOth.Enabled = True
  End Sub
  Private Sub RbBusManuf_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbBusManuf.Click
    TxtBusOth.Enabled = False
  End Sub
  Private Sub RbBusWhole_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbBusWhole.Click
    TxtBusOth.Enabled = False
  End Sub
  Private Sub RbBusServ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbBusServ.Click
    TxtBusOth.Enabled = False
  End Sub
  Private Sub RbBusProf_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbBusProf.Click
    TxtBusOth.Enabled = False
  End Sub
  Private Sub RbBusRet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbBusRet.Click
    TxtBusOth.Enabled = False
  End Sub
  Private Sub RbBusTrade_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbBusTrade.Click
    TxtBusOth.Enabled = False
  End Sub
  Private Sub RbBusLes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbBusLes.Click
    TxtBusOth.Enabled = False
  End Sub
  Private Sub RbBusOther_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbBusOther.Click
    TxtBusOth.Enabled = True
  End Sub
  Private Sub TxtIrsbus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIrsbus.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub TxtListNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtListNo.TextChanged

  End Sub

  Private Sub TxtDPhone_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDPhone.TextChanged

  End Sub

  Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

  End Sub

  Private Sub Label40_Click(sender As Object, e As EventArgs) Handles Label40.Click

  End Sub
End Class






