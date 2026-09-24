Imports System.Text
Public Class FrmFA001C
  Inherits System.Windows.Forms.Form
	Dim myFAMSTR As FAMSTR.myData
	Dim myFACMNTS As FACMNTS.myData
	Dim myFAHIST As FAHIST.myData
	Dim dsFACMNTS As DataSet = New DataSet
  Friend WrkTagNo As String
  Friend AddMode As Boolean
  Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtUser1 As System.Windows.Forms.TextBox
  Friend WithEvents LnkUser1 As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkUser3 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtUser3 As System.Windows.Forms.TextBox
  Friend WithEvents LblUser5 As System.Windows.Forms.Label
  Friend WithEvents TxtUser5 As System.Windows.Forms.TextBox
  Friend WithEvents LblUser4 As System.Windows.Forms.Label
  Friend WithEvents TxtUser4 As System.Windows.Forms.TextBox
  Friend WithEvents LnkUser2 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtUser2 As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
  Friend WithEvents RbDeleted As System.Windows.Forms.RadioButton
  Friend WithEvents RbActive As System.Windows.Forms.RadioButton
  Friend WithEvents TxtClass As System.Windows.Forms.TextBox
  Friend WithEvents LnkClass As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtAstype As System.Windows.Forms.TextBox
  Friend WithEvents LnkAstype As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtGlgp As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfnd As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfc2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtFcn2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtObj2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtDpt2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfn2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfcn As System.Windows.Forms.TextBox
  Friend WithEvents TxtFcn As System.Windows.Forms.TextBox
  Friend WithEvents TxtObj As System.Windows.Forms.TextBox
  Friend WithEvents TxtDpt As System.Windows.Forms.TextBox
  Friend WithEvents LnkGLAcct1 As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkGLAcct2 As System.Windows.Forms.LinkLabel
  Friend WithEvents GrpDevl As System.Windows.Forms.GroupBox
  Friend WithEvents TxtDevl As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents PicboxTag As System.Windows.Forms.PictureBox
  Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Dim LoadScrn As Boolean
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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents TxtTagNo As System.Windows.Forms.TextBox
Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
Friend WithEvents TpDetail As System.Windows.Forms.TabPage
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents LnkEqup As System.Windows.Forms.LinkLabel
Friend WithEvents TxtEqup As System.Windows.Forms.TextBox
Friend WithEvents LnkDept As System.Windows.Forms.LinkLabel
Friend WithEvents TxtDept As System.Windows.Forms.TextBox
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents TxtPhyLocation As System.Windows.Forms.TextBox
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents TxtSubLocation As System.Windows.Forms.TextBox
Friend WithEvents LnkBldg As System.Windows.Forms.LinkLabel
Friend WithEvents TxtBldg As System.Windows.Forms.TextBox
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtInvoice As System.Windows.Forms.TextBox
Friend WithEvents TxtSerialNo As System.Windows.Forms.TextBox
Friend WithEvents TxtQty As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TpDepr As System.Windows.Forms.TabPage
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents Label9 As System.Windows.Forms.Label
Friend WithEvents LnkAqumt As System.Windows.Forms.LinkLabel
Friend WithEvents TxtAqumt As System.Windows.Forms.TextBox
Friend WithEvents DtPckAqDt As System.Windows.Forms.DateTimePicker
Friend WithEvents TxtAqvl As System.Windows.Forms.TextBox
Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
Friend WithEvents DtPckDsdt As System.Windows.Forms.DateTimePicker
Friend WithEvents LnkDspmt As System.Windows.Forms.LinkLabel
Friend WithEvents TxtDspmt As System.Windows.Forms.TextBox
Friend WithEvents TxtDsvl As System.Windows.Forms.TextBox
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents TxtEyr As System.Windows.Forms.TextBox
Friend WithEvents Label10 As System.Windows.Forms.Label
Friend WithEvents Label11 As System.Windows.Forms.Label
Friend WithEvents TxtFnd As System.Windows.Forms.TextBox
Friend WithEvents ChkGovFund As System.Windows.Forms.CheckBox
Friend WithEvents ChkNonDepr As System.Windows.Forms.CheckBox
Friend WithEvents ChkNonReport As System.Windows.Forms.CheckBox
Friend WithEvents TxtVendor As System.Windows.Forms.TextBox
Friend WithEvents LnkVendor As System.Windows.Forms.LinkLabel
Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
Friend WithEvents LblTotalDepr As System.Windows.Forms.Label
Friend WithEvents Label18 As System.Windows.Forms.Label
Friend WithEvents LblAssetThreshold As System.Windows.Forms.Label
Friend WithEvents Label16 As System.Windows.Forms.Label
Friend WithEvents LblAnnualDepr As System.Windows.Forms.Label
Friend WithEvents LblEdt As System.Windows.Forms.Label
Friend WithEvents Label14 As System.Windows.Forms.Label
Friend WithEvents Label13 As System.Windows.Forms.Label
Friend WithEvents TxtFnd2 As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TxtTagNo = New System.Windows.Forms.TextBox()
    Me.TxtDesc = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TpDetail = New System.Windows.Forms.TabPage()
    Me.PicboxTag = New System.Windows.Forms.PictureBox()
    Me.GroupBox7 = New System.Windows.Forms.GroupBox()
    Me.TxtUser1 = New System.Windows.Forms.TextBox()
    Me.LnkUser1 = New System.Windows.Forms.LinkLabel()
    Me.LnkUser3 = New System.Windows.Forms.LinkLabel()
    Me.TxtUser3 = New System.Windows.Forms.TextBox()
    Me.LblUser5 = New System.Windows.Forms.Label()
    Me.TxtUser5 = New System.Windows.Forms.TextBox()
    Me.LblUser4 = New System.Windows.Forms.Label()
    Me.TxtUser4 = New System.Windows.Forms.TextBox()
    Me.LnkUser2 = New System.Windows.Forms.LinkLabel()
    Me.TxtUser2 = New System.Windows.Forms.TextBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.TxtClass = New System.Windows.Forms.TextBox()
    Me.LnkClass = New System.Windows.Forms.LinkLabel()
    Me.LnkEqup = New System.Windows.Forms.LinkLabel()
    Me.TxtEqup = New System.Windows.Forms.TextBox()
    Me.LnkDept = New System.Windows.Forms.LinkLabel()
    Me.TxtDept = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtPhyLocation = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtSubLocation = New System.Windows.Forms.TextBox()
    Me.LnkBldg = New System.Windows.Forms.LinkLabel()
    Me.TxtBldg = New System.Windows.Forms.TextBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.TxtVendor = New System.Windows.Forms.TextBox()
    Me.LnkVendor = New System.Windows.Forms.LinkLabel()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtInvoice = New System.Windows.Forms.TextBox()
    Me.TxtSerialNo = New System.Windows.Forms.TextBox()
    Me.TxtQty = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TpDepr = New System.Windows.Forms.TabPage()
    Me.GrpDevl = New System.Windows.Forms.GroupBox()
    Me.TxtDevl = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.LnkGLAcct2 = New System.Windows.Forms.LinkLabel()
    Me.LnkGLAcct1 = New System.Windows.Forms.LinkLabel()
    Me.TxtSfc2 = New System.Windows.Forms.TextBox()
    Me.TxtFcn2 = New System.Windows.Forms.TextBox()
    Me.TxtObj2 = New System.Windows.Forms.TextBox()
    Me.TxtDpt2 = New System.Windows.Forms.TextBox()
    Me.TxtSfn2 = New System.Windows.Forms.TextBox()
    Me.TxtSfcn = New System.Windows.Forms.TextBox()
    Me.TxtFcn = New System.Windows.Forms.TextBox()
    Me.TxtObj = New System.Windows.Forms.TextBox()
    Me.TxtDpt = New System.Windows.Forms.TextBox()
    Me.TxtSfnd = New System.Windows.Forms.TextBox()
    Me.TxtGlgp = New System.Windows.Forms.TextBox()
    Me.TxtAstype = New System.Windows.Forms.TextBox()
    Me.LnkAstype = New System.Windows.Forms.LinkLabel()
    Me.TxtFnd2 = New System.Windows.Forms.TextBox()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.LblTotalDepr = New System.Windows.Forms.Label()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.LblAssetThreshold = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.LblAnnualDepr = New System.Windows.Forms.Label()
    Me.LblEdt = New System.Windows.Forms.Label()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.ChkNonReport = New System.Windows.Forms.CheckBox()
    Me.ChkNonDepr = New System.Windows.Forms.CheckBox()
    Me.ChkGovFund = New System.Windows.Forms.CheckBox()
    Me.TxtFnd = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TxtEyr = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.DtPckDsdt = New System.Windows.Forms.DateTimePicker()
    Me.LnkDspmt = New System.Windows.Forms.LinkLabel()
    Me.TxtDspmt = New System.Windows.Forms.TextBox()
    Me.TxtDsvl = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.DtPckAqDt = New System.Windows.Forms.DateTimePicker()
    Me.LnkAqumt = New System.Windows.Forms.LinkLabel()
    Me.TxtAqumt = New System.Windows.Forms.TextBox()
    Me.TxtAqvl = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.GroupBox8 = New System.Windows.Forms.GroupBox()
    Me.RbDeleted = New System.Windows.Forms.RadioButton()
    Me.RbActive = New System.Windows.Forms.RadioButton()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TabControl1.SuspendLayout()
    Me.TpDetail.SuspendLayout()
    CType(Me.PicboxTag, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox7.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.TpDepr.SuspendLayout()
    Me.GrpDevl.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.GroupBox6.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox4.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox8.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(56, 16)
    Me.Label1.TabIndex = 13
    Me.Label1.Text = "Tag #"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtTagNo
    '
    Me.TxtTagNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTagNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTagNo.Location = New System.Drawing.Point(104, 8)
    Me.TxtTagNo.MaxLength = 9
    Me.TxtTagNo.Name = "TxtTagNo"
    Me.TxtTagNo.Size = New System.Drawing.Size(82, 22)
    Me.TxtTagNo.TabIndex = 0
    '
    'TxtDesc
    '
    Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDesc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDesc.Location = New System.Drawing.Point(104, 40)
    Me.TxtDesc.MaxLength = 40
    Me.TxtDesc.Name = "TxtDesc"
    Me.TxtDesc.Size = New System.Drawing.Size(327, 22)
    Me.TxtDesc.TabIndex = 1
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(12, 44)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(64, 16)
    Me.Label5.TabIndex = 301
    Me.Label5.Text = "Description"
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.TpDetail)
    Me.TabControl1.Controls.Add(Me.TpDepr)
    Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TabControl1.Location = New System.Drawing.Point(8, 80)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(698, 380)
    Me.TabControl1.TabIndex = 2
    '
    'TpDetail
    '
    Me.TpDetail.Controls.Add(Me.PicboxTag)
    Me.TpDetail.Controls.Add(Me.GroupBox7)
    Me.TpDetail.Controls.Add(Me.GroupBox2)
    Me.TpDetail.Controls.Add(Me.GroupBox1)
    Me.TpDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TpDetail.Location = New System.Drawing.Point(4, 22)
    Me.TpDetail.Name = "TpDetail"
    Me.TpDetail.Size = New System.Drawing.Size(690, 354)
    Me.TpDetail.TabIndex = 0
    Me.TpDetail.Text = "Detail"
    '
    'PicboxTag
    '
    Me.PicboxTag.Location = New System.Drawing.Point(441, 158)
    Me.PicboxTag.Name = "PicboxTag"
    Me.PicboxTag.Size = New System.Drawing.Size(235, 193)
    Me.PicboxTag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.PicboxTag.TabIndex = 3
    Me.PicboxTag.TabStop = False
    '
    'GroupBox7
    '
    Me.GroupBox7.Controls.Add(Me.TxtUser1)
    Me.GroupBox7.Controls.Add(Me.LnkUser1)
    Me.GroupBox7.Controls.Add(Me.LnkUser3)
    Me.GroupBox7.Controls.Add(Me.TxtUser3)
    Me.GroupBox7.Controls.Add(Me.LblUser5)
    Me.GroupBox7.Controls.Add(Me.TxtUser5)
    Me.GroupBox7.Controls.Add(Me.LblUser4)
    Me.GroupBox7.Controls.Add(Me.TxtUser4)
    Me.GroupBox7.Controls.Add(Me.LnkUser2)
    Me.GroupBox7.Controls.Add(Me.TxtUser2)
    Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox7.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox7.Location = New System.Drawing.Point(334, 8)
    Me.GroupBox7.Name = "GroupBox7"
    Me.GroupBox7.Size = New System.Drawing.Size(348, 144)
    Me.GroupBox7.TabIndex = 1
    Me.GroupBox7.TabStop = False
    Me.GroupBox7.Text = "User Defined"
    '
    'TxtUser1
    '
    Me.TxtUser1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUser1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUser1.Location = New System.Drawing.Point(133, 16)
    Me.TxtUser1.MaxLength = 5
    Me.TxtUser1.Name = "TxtUser1"
    Me.TxtUser1.Size = New System.Drawing.Size(48, 22)
    Me.TxtUser1.TabIndex = 0
    '
    'LnkUser1
    '
    Me.LnkUser1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkUser1.ForeColor = System.Drawing.Color.Maroon
    Me.LnkUser1.Location = New System.Drawing.Point(6, 20)
    Me.LnkUser1.Name = "LnkUser1"
    Me.LnkUser1.Size = New System.Drawing.Size(121, 18)
    Me.LnkUser1.TabIndex = 312
    Me.LnkUser1.TabStop = True
    Me.LnkUser1.Text = "UD1"
    '
    'LnkUser3
    '
    Me.LnkUser3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkUser3.Location = New System.Drawing.Point(6, 68)
    Me.LnkUser3.Name = "LnkUser3"
    Me.LnkUser3.Size = New System.Drawing.Size(121, 18)
    Me.LnkUser3.TabIndex = 308
    Me.LnkUser3.TabStop = True
    Me.LnkUser3.Text = "UD3"
    '
    'TxtUser3
    '
    Me.TxtUser3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUser3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUser3.Location = New System.Drawing.Point(133, 64)
    Me.TxtUser3.MaxLength = 5
    Me.TxtUser3.Name = "TxtUser3"
    Me.TxtUser3.Size = New System.Drawing.Size(48, 22)
    Me.TxtUser3.TabIndex = 2
    '
    'LblUser5
    '
    Me.LblUser5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblUser5.ForeColor = System.Drawing.SystemColors.ControlText
    Me.LblUser5.Location = New System.Drawing.Point(6, 120)
    Me.LblUser5.Name = "LblUser5"
    Me.LblUser5.Size = New System.Drawing.Size(121, 18)
    Me.LblUser5.TabIndex = 306
    Me.LblUser5.Text = "UD5"
    '
    'TxtUser5
    '
    Me.TxtUser5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUser5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUser5.Location = New System.Drawing.Point(133, 116)
    Me.TxtUser5.MaxLength = 25
    Me.TxtUser5.Name = "TxtUser5"
    Me.TxtUser5.Size = New System.Drawing.Size(209, 22)
    Me.TxtUser5.TabIndex = 4
    '
    'LblUser4
    '
    Me.LblUser4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblUser4.ForeColor = System.Drawing.SystemColors.ControlText
    Me.LblUser4.Location = New System.Drawing.Point(6, 96)
    Me.LblUser4.Name = "LblUser4"
    Me.LblUser4.Size = New System.Drawing.Size(121, 18)
    Me.LblUser4.TabIndex = 304
    Me.LblUser4.Text = "UD4"
    '
    'TxtUser4
    '
    Me.TxtUser4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUser4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUser4.Location = New System.Drawing.Point(133, 92)
    Me.TxtUser4.MaxLength = 25
    Me.TxtUser4.Name = "TxtUser4"
    Me.TxtUser4.Size = New System.Drawing.Size(209, 22)
    Me.TxtUser4.TabIndex = 3
    '
    'LnkUser2
    '
    Me.LnkUser2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkUser2.Location = New System.Drawing.Point(6, 44)
    Me.LnkUser2.Name = "LnkUser2"
    Me.LnkUser2.Size = New System.Drawing.Size(121, 18)
    Me.LnkUser2.TabIndex = 302
    Me.LnkUser2.TabStop = True
    Me.LnkUser2.Text = "UD2"
    '
    'TxtUser2
    '
    Me.TxtUser2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUser2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUser2.Location = New System.Drawing.Point(133, 40)
    Me.TxtUser2.MaxLength = 5
    Me.TxtUser2.Name = "TxtUser2"
    Me.TxtUser2.Size = New System.Drawing.Size(48, 22)
    Me.TxtUser2.TabIndex = 1
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.TxtClass)
    Me.GroupBox2.Controls.Add(Me.LnkClass)
    Me.GroupBox2.Controls.Add(Me.LnkEqup)
    Me.GroupBox2.Controls.Add(Me.TxtEqup)
    Me.GroupBox2.Controls.Add(Me.LnkDept)
    Me.GroupBox2.Controls.Add(Me.TxtDept)
    Me.GroupBox2.Controls.Add(Me.Label7)
    Me.GroupBox2.Controls.Add(Me.TxtPhyLocation)
    Me.GroupBox2.Controls.Add(Me.Label6)
    Me.GroupBox2.Controls.Add(Me.TxtSubLocation)
    Me.GroupBox2.Controls.Add(Me.LnkBldg)
    Me.GroupBox2.Controls.Add(Me.TxtBldg)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox2.Location = New System.Drawing.Point(4, 158)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(431, 164)
    Me.GroupBox2.TabIndex = 2
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Report Grouping Codes"
    '
    'TxtClass
    '
    Me.TxtClass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtClass.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtClass.Location = New System.Drawing.Point(98, 17)
    Me.TxtClass.MaxLength = 5
    Me.TxtClass.Name = "TxtClass"
    Me.TxtClass.Size = New System.Drawing.Size(48, 22)
    Me.TxtClass.TabIndex = 0
    '
    'LnkClass
    '
    Me.LnkClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkClass.ForeColor = System.Drawing.Color.Maroon
    Me.LnkClass.Location = New System.Drawing.Point(8, 21)
    Me.LnkClass.Name = "LnkClass"
    Me.LnkClass.Size = New System.Drawing.Size(80, 16)
    Me.LnkClass.TabIndex = 312
    Me.LnkClass.TabStop = True
    Me.LnkClass.Text = "Class"
    '
    'LnkEqup
    '
    Me.LnkEqup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkEqup.Location = New System.Drawing.Point(6, 140)
    Me.LnkEqup.Name = "LnkEqup"
    Me.LnkEqup.Size = New System.Drawing.Size(80, 16)
    Me.LnkEqup.TabIndex = 310
    Me.LnkEqup.TabStop = True
    Me.LnkEqup.Text = "Condition"
    '
    'TxtEqup
    '
    Me.TxtEqup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtEqup.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtEqup.Location = New System.Drawing.Point(98, 136)
    Me.TxtEqup.MaxLength = 5
    Me.TxtEqup.Name = "TxtEqup"
    Me.TxtEqup.Size = New System.Drawing.Size(48, 22)
    Me.TxtEqup.TabIndex = 5
    '
    'LnkDept
    '
    Me.LnkDept.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkDept.Location = New System.Drawing.Point(6, 116)
    Me.LnkDept.Name = "LnkDept"
    Me.LnkDept.Size = New System.Drawing.Size(80, 16)
    Me.LnkDept.TabIndex = 308
    Me.LnkDept.TabStop = True
    Me.LnkDept.Text = "Department"
    '
    'TxtDept
    '
    Me.TxtDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDept.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDept.Location = New System.Drawing.Point(98, 112)
    Me.TxtDept.MaxLength = 5
    Me.TxtDept.Name = "TxtDept"
    Me.TxtDept.Size = New System.Drawing.Size(48, 22)
    Me.TxtDept.TabIndex = 4
    '
    'Label7
    '
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label7.Location = New System.Drawing.Point(6, 68)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(92, 16)
    Me.Label7.TabIndex = 306
    Me.Label7.Text = "Physical Location"
    '
    'TxtPhyLocation
    '
    Me.TxtPhyLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPhyLocation.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhyLocation.Location = New System.Drawing.Point(98, 63)
    Me.TxtPhyLocation.MaxLength = 40
    Me.TxtPhyLocation.Name = "TxtPhyLocation"
    Me.TxtPhyLocation.Size = New System.Drawing.Size(328, 22)
    Me.TxtPhyLocation.TabIndex = 2
    '
    'Label6
    '
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label6.Location = New System.Drawing.Point(6, 92)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(80, 16)
    Me.Label6.TabIndex = 304
    Me.Label6.Text = "Sub Location"
    '
    'TxtSubLocation
    '
    Me.TxtSubLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSubLocation.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSubLocation.Location = New System.Drawing.Point(98, 87)
    Me.TxtSubLocation.MaxLength = 35
    Me.TxtSubLocation.Name = "TxtSubLocation"
    Me.TxtSubLocation.Size = New System.Drawing.Size(289, 22)
    Me.TxtSubLocation.TabIndex = 3
    '
    'LnkBldg
    '
    Me.LnkBldg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkBldg.Location = New System.Drawing.Point(6, 44)
    Me.LnkBldg.Name = "LnkBldg"
    Me.LnkBldg.Size = New System.Drawing.Size(80, 16)
    Me.LnkBldg.TabIndex = 302
    Me.LnkBldg.TabStop = True
    Me.LnkBldg.Text = "Location/Bldg"
    '
    'TxtBldg
    '
    Me.TxtBldg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBldg.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBldg.Location = New System.Drawing.Point(98, 40)
    Me.TxtBldg.MaxLength = 5
    Me.TxtBldg.Name = "TxtBldg"
    Me.TxtBldg.Size = New System.Drawing.Size(48, 22)
    Me.TxtBldg.TabIndex = 1
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.TxtVendor)
    Me.GroupBox1.Controls.Add(Me.LnkVendor)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Controls.Add(Me.TxtInvoice)
    Me.GroupBox1.Controls.Add(Me.TxtSerialNo)
    Me.GroupBox1.Controls.Add(Me.TxtQty)
    Me.GroupBox1.Controls.Add(Me.Label4)
    Me.GroupBox1.Controls.Add(Me.Label3)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox1.Location = New System.Drawing.Point(4, 8)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(324, 144)
    Me.GroupBox1.TabIndex = 0
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Source Information"
    '
    'TxtVendor
    '
    Me.TxtVendor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVendor.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVendor.Location = New System.Drawing.Point(66, 87)
    Me.TxtVendor.MaxLength = 5
    Me.TxtVendor.Name = "TxtVendor"
    Me.TxtVendor.Size = New System.Drawing.Size(48, 22)
    Me.TxtVendor.TabIndex = 3
    '
    'LnkVendor
    '
    Me.LnkVendor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkVendor.ForeColor = System.Drawing.Color.Maroon
    Me.LnkVendor.Location = New System.Drawing.Point(8, 92)
    Me.LnkVendor.Name = "LnkVendor"
    Me.LnkVendor.Size = New System.Drawing.Size(52, 17)
    Me.LnkVendor.TabIndex = 314
    Me.LnkVendor.TabStop = True
    Me.LnkVendor.Text = "Vendor #"
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label2.Location = New System.Drawing.Point(8, 64)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(52, 22)
    Me.Label2.TabIndex = 40
    Me.Label2.Text = "Invoice #"
    '
    'TxtInvoice
    '
    Me.TxtInvoice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtInvoice.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtInvoice.Location = New System.Drawing.Point(66, 63)
    Me.TxtInvoice.MaxLength = 30
    Me.TxtInvoice.Name = "TxtInvoice"
    Me.TxtInvoice.Size = New System.Drawing.Size(252, 22)
    Me.TxtInvoice.TabIndex = 2
    '
    'TxtSerialNo
    '
    Me.TxtSerialNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSerialNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSerialNo.Location = New System.Drawing.Point(66, 39)
    Me.TxtSerialNo.MaxLength = 30
    Me.TxtSerialNo.Name = "TxtSerialNo"
    Me.TxtSerialNo.Size = New System.Drawing.Size(252, 22)
    Me.TxtSerialNo.TabIndex = 1
    '
    'TxtQty
    '
    Me.TxtQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtQty.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtQty.Location = New System.Drawing.Point(66, 15)
    Me.TxtQty.MaxLength = 5
    Me.TxtQty.Name = "TxtQty"
    Me.TxtQty.Size = New System.Drawing.Size(48, 22)
    Me.TxtQty.TabIndex = 0
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label4.Location = New System.Drawing.Point(8, 44)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(52, 18)
    Me.Label4.TabIndex = 39
    Me.Label4.Text = "Serial #"
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label3.Location = New System.Drawing.Point(8, 20)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(48, 16)
    Me.Label3.TabIndex = 38
    Me.Label3.Text = "Quantity"
    '
    'TpDepr
    '
    Me.TpDepr.Controls.Add(Me.GrpDevl)
    Me.TpDepr.Controls.Add(Me.LnkGLAcct2)
    Me.TpDepr.Controls.Add(Me.LnkGLAcct1)
    Me.TpDepr.Controls.Add(Me.TxtSfc2)
    Me.TpDepr.Controls.Add(Me.TxtFcn2)
    Me.TpDepr.Controls.Add(Me.TxtObj2)
    Me.TpDepr.Controls.Add(Me.TxtDpt2)
    Me.TpDepr.Controls.Add(Me.TxtSfn2)
    Me.TpDepr.Controls.Add(Me.TxtSfcn)
    Me.TpDepr.Controls.Add(Me.TxtFcn)
    Me.TpDepr.Controls.Add(Me.TxtObj)
    Me.TpDepr.Controls.Add(Me.TxtDpt)
    Me.TpDepr.Controls.Add(Me.TxtSfnd)
    Me.TpDepr.Controls.Add(Me.TxtGlgp)
    Me.TpDepr.Controls.Add(Me.TxtAstype)
    Me.TpDepr.Controls.Add(Me.LnkAstype)
    Me.TpDepr.Controls.Add(Me.TxtFnd2)
    Me.TpDepr.Controls.Add(Me.GroupBox5)
    Me.TpDepr.Controls.Add(Me.GroupBox6)
    Me.TpDepr.Controls.Add(Me.ChkNonReport)
    Me.TpDepr.Controls.Add(Me.ChkNonDepr)
    Me.TpDepr.Controls.Add(Me.ChkGovFund)
    Me.TpDepr.Controls.Add(Me.TxtFnd)
    Me.TpDepr.Controls.Add(Me.Label11)
    Me.TpDepr.Controls.Add(Me.TxtEyr)
    Me.TpDepr.Controls.Add(Me.Label10)
    Me.TpDepr.Controls.Add(Me.GroupBox4)
    Me.TpDepr.Controls.Add(Me.GroupBox3)
    Me.TpDepr.Location = New System.Drawing.Point(4, 22)
    Me.TpDepr.Name = "TpDepr"
    Me.TpDepr.Size = New System.Drawing.Size(690, 354)
    Me.TpDepr.TabIndex = 1
    Me.TpDepr.Text = "Depreciation"
    '
    'GrpDevl
    '
    Me.GrpDevl.Controls.Add(Me.TxtDevl)
    Me.GrpDevl.Controls.Add(Me.Label12)
    Me.GrpDevl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpDevl.ForeColor = System.Drawing.Color.Maroon
    Me.GrpDevl.Location = New System.Drawing.Point(12, 277)
    Me.GrpDevl.Name = "GrpDevl"
    Me.GrpDevl.Size = New System.Drawing.Size(216, 44)
    Me.GrpDevl.TabIndex = 326
    Me.GrpDevl.TabStop = False
    Me.GrpDevl.Text = "Depreciation (Dbl Click to Edit)"
    '
    'TxtDevl
    '
    Me.TxtDevl.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.TxtDevl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDevl.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDevl.Location = New System.Drawing.Point(122, 16)
    Me.TxtDevl.MaxLength = 11
    Me.TxtDevl.Name = "TxtDevl"
    Me.TxtDevl.ReadOnly = True
    Me.TxtDevl.Size = New System.Drawing.Size(88, 22)
    Me.TxtDevl.TabIndex = 326
    Me.TxtDevl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label12
    '
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label12.Location = New System.Drawing.Point(6, 20)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(104, 18)
    Me.Label12.TabIndex = 327
    Me.Label12.Text = "Accumulated Depr"
    '
    'LnkGLAcct2
    '
    Me.LnkGLAcct2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcct2.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcct2.Location = New System.Drawing.Point(246, 134)
    Me.LnkGLAcct2.Name = "LnkGLAcct2"
    Me.LnkGLAcct2.Size = New System.Drawing.Size(60, 18)
    Me.LnkGLAcct2.TabIndex = 324
    Me.LnkGLAcct2.TabStop = True
    Me.LnkGLAcct2.Text = "G/L Acct 2"
    '
    'LnkGLAcct1
    '
    Me.LnkGLAcct1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcct1.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcct1.Location = New System.Drawing.Point(246, 110)
    Me.LnkGLAcct1.Name = "LnkGLAcct1"
    Me.LnkGLAcct1.Size = New System.Drawing.Size(60, 18)
    Me.LnkGLAcct1.TabIndex = 323
    Me.LnkGLAcct1.TabStop = True
    Me.LnkGLAcct1.Text = "G/L Acct 1"
    '
    'TxtSfc2
    '
    Me.TxtSfc2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfc2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfc2.Location = New System.Drawing.Point(522, 130)
    Me.TxtSfc2.MaxLength = 4
    Me.TxtSfc2.Name = "TxtSfc2"
    Me.TxtSfc2.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfc2.TabIndex = 14
    '
    'TxtFcn2
    '
    Me.TxtFcn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFcn2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFcn2.Location = New System.Drawing.Point(471, 130)
    Me.TxtFcn2.MaxLength = 4
    Me.TxtFcn2.Name = "TxtFcn2"
    Me.TxtFcn2.Size = New System.Drawing.Size(45, 22)
    Me.TxtFcn2.TabIndex = 13
    '
    'TxtObj2
    '
    Me.TxtObj2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObj2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObj2.Location = New System.Drawing.Point(435, 130)
    Me.TxtObj2.MaxLength = 3
    Me.TxtObj2.Name = "TxtObj2"
    Me.TxtObj2.Size = New System.Drawing.Size(32, 22)
    Me.TxtObj2.TabIndex = 12
    '
    'TxtDpt2
    '
    Me.TxtDpt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDpt2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDpt2.Location = New System.Drawing.Point(384, 130)
    Me.TxtDpt2.MaxLength = 4
    Me.TxtDpt2.Name = "TxtDpt2"
    Me.TxtDpt2.Size = New System.Drawing.Size(45, 22)
    Me.TxtDpt2.TabIndex = 11
    '
    'TxtSfn2
    '
    Me.TxtSfn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfn2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfn2.Location = New System.Drawing.Point(346, 130)
    Me.TxtSfn2.MaxLength = 3
    Me.TxtSfn2.Name = "TxtSfn2"
    Me.TxtSfn2.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfn2.TabIndex = 10
    '
    'TxtSfcn
    '
    Me.TxtSfcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfcn.Location = New System.Drawing.Point(522, 104)
    Me.TxtSfcn.MaxLength = 4
    Me.TxtSfcn.Name = "TxtSfcn"
    Me.TxtSfcn.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfcn.TabIndex = 8
    '
    'TxtFcn
    '
    Me.TxtFcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFcn.Location = New System.Drawing.Point(471, 104)
    Me.TxtFcn.MaxLength = 4
    Me.TxtFcn.Name = "TxtFcn"
    Me.TxtFcn.Size = New System.Drawing.Size(45, 22)
    Me.TxtFcn.TabIndex = 7
    '
    'TxtObj
    '
    Me.TxtObj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObj.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObj.Location = New System.Drawing.Point(435, 104)
    Me.TxtObj.MaxLength = 3
    Me.TxtObj.Name = "TxtObj"
    Me.TxtObj.Size = New System.Drawing.Size(32, 22)
    Me.TxtObj.TabIndex = 6
    '
    'TxtDpt
    '
    Me.TxtDpt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDpt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDpt.Location = New System.Drawing.Point(384, 104)
    Me.TxtDpt.MaxLength = 4
    Me.TxtDpt.Name = "TxtDpt"
    Me.TxtDpt.Size = New System.Drawing.Size(45, 22)
    Me.TxtDpt.TabIndex = 5
    '
    'TxtSfnd
    '
    Me.TxtSfnd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfnd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfnd.Location = New System.Drawing.Point(346, 104)
    Me.TxtSfnd.MaxLength = 3
    Me.TxtSfnd.Name = "TxtSfnd"
    Me.TxtSfnd.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfnd.TabIndex = 4
    '
    'TxtGlgp
    '
    Me.TxtGlgp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtGlgp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGlgp.Location = New System.Drawing.Point(352, 80)
    Me.TxtGlgp.MaxLength = 20
    Me.TxtGlgp.Name = "TxtGlgp"
    Me.TxtGlgp.Size = New System.Drawing.Size(164, 22)
    Me.TxtGlgp.TabIndex = 2
    '
    'TxtAstype
    '
    Me.TxtAstype.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAstype.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAstype.Location = New System.Drawing.Point(100, 82)
    Me.TxtAstype.MaxLength = 5
    Me.TxtAstype.Name = "TxtAstype"
    Me.TxtAstype.Size = New System.Drawing.Size(48, 22)
    Me.TxtAstype.TabIndex = 0
    '
    'LnkAstype
    '
    Me.LnkAstype.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkAstype.ForeColor = System.Drawing.Color.Maroon
    Me.LnkAstype.Location = New System.Drawing.Point(9, 86)
    Me.LnkAstype.Name = "LnkAstype"
    Me.LnkAstype.Size = New System.Drawing.Size(80, 16)
    Me.LnkAstype.TabIndex = 322
    Me.LnkAstype.TabStop = True
    Me.LnkAstype.Text = "Asset Type"
    '
    'TxtFnd2
    '
    Me.TxtFnd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFnd2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFnd2.Location = New System.Drawing.Point(308, 130)
    Me.TxtFnd2.MaxLength = 3
    Me.TxtFnd2.Name = "TxtFnd2"
    Me.TxtFnd2.Size = New System.Drawing.Size(32, 22)
    Me.TxtFnd2.TabIndex = 9
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.LblTotalDepr)
    Me.GroupBox5.Controls.Add(Me.Label18)
    Me.GroupBox5.Controls.Add(Me.LblAssetThreshold)
    Me.GroupBox5.Controls.Add(Me.Label16)
    Me.GroupBox5.Controls.Add(Me.LblAnnualDepr)
    Me.GroupBox5.Controls.Add(Me.LblEdt)
    Me.GroupBox5.Controls.Add(Me.Label14)
    Me.GroupBox5.Controls.Add(Me.Label13)
    Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox5.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox5.Location = New System.Drawing.Point(11, 183)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(216, 88)
    Me.GroupBox5.TabIndex = 318
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "Informational"
    '
    'LblTotalDepr
    '
    Me.LblTotalDepr.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotalDepr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTotalDepr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotalDepr.ForeColor = System.Drawing.Color.Black
    Me.LblTotalDepr.Location = New System.Drawing.Point(124, 68)
    Me.LblTotalDepr.Name = "LblTotalDepr"
    Me.LblTotalDepr.Size = New System.Drawing.Size(88, 16)
    Me.LblTotalDepr.TabIndex = 312
    Me.LblTotalDepr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label18
    '
    Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label18.Location = New System.Drawing.Point(8, 68)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(100, 16)
    Me.Label18.TabIndex = 311
    Me.Label18.Text = "Total Depr Amount"
    '
    'LblAssetThreshold
    '
    Me.LblAssetThreshold.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAssetThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAssetThreshold.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAssetThreshold.ForeColor = System.Drawing.Color.Black
    Me.LblAssetThreshold.Location = New System.Drawing.Point(124, 52)
    Me.LblAssetThreshold.Name = "LblAssetThreshold"
    Me.LblAssetThreshold.Size = New System.Drawing.Size(88, 16)
    Me.LblAssetThreshold.TabIndex = 310
    Me.LblAssetThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label16
    '
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label16.Location = New System.Drawing.Point(8, 52)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(116, 16)
    Me.Label16.TabIndex = 309
    Me.Label16.Text = "Asset Type Threshold"
    '
    'LblAnnualDepr
    '
    Me.LblAnnualDepr.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAnnualDepr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAnnualDepr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAnnualDepr.ForeColor = System.Drawing.Color.Black
    Me.LblAnnualDepr.Location = New System.Drawing.Point(124, 36)
    Me.LblAnnualDepr.Name = "LblAnnualDepr"
    Me.LblAnnualDepr.Size = New System.Drawing.Size(88, 16)
    Me.LblAnnualDepr.TabIndex = 308
    Me.LblAnnualDepr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblEdt
    '
    Me.LblEdt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblEdt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblEdt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblEdt.ForeColor = System.Drawing.Color.Black
    Me.LblEdt.Location = New System.Drawing.Point(124, 20)
    Me.LblEdt.Name = "LblEdt"
    Me.LblEdt.Size = New System.Drawing.Size(88, 16)
    Me.LblEdt.TabIndex = 307
    Me.LblEdt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label14
    '
    Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label14.Location = New System.Drawing.Point(8, 20)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(84, 16)
    Me.Label14.TabIndex = 306
    Me.Label14.Text = "Expiration Date"
    '
    'Label13
    '
    Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label13.Location = New System.Drawing.Point(8, 36)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(116, 16)
    Me.Label13.TabIndex = 39
    Me.Label13.Text = "Annual Depr Amount"
    '
    'GroupBox6
    '
    Me.GroupBox6.Controls.Add(Me.DataGrdView)
    Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox6.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox6.Location = New System.Drawing.Point(247, 183)
    Me.GroupBox6.Name = "GroupBox6"
    Me.GroupBox6.Size = New System.Drawing.Size(277, 168)
    Me.GroupBox6.TabIndex = 317
    Me.GroupBox6.TabStop = False
    Me.GroupBox6.Text = "History"
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle1
    Me.DataGrdView.Location = New System.Drawing.Point(9, 19)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(262, 141)
    Me.DataGrdView.TabIndex = 40
    '
    'ChkNonReport
    '
    Me.ChkNonReport.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkNonReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkNonReport.Location = New System.Drawing.Point(324, 160)
    Me.ChkNonReport.Name = "ChkNonReport"
    Me.ChkNonReport.Size = New System.Drawing.Size(180, 16)
    Me.ChkNonReport.TabIndex = 17
    Me.ChkNonReport.Text = "Non Reportable (Internal Use)?"
    '
    'ChkNonDepr
    '
    Me.ChkNonDepr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkNonDepr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkNonDepr.Location = New System.Drawing.Point(180, 160)
    Me.ChkNonDepr.Name = "ChkNonDepr"
    Me.ChkNonDepr.Size = New System.Drawing.Size(120, 16)
    Me.ChkNonDepr.TabIndex = 16
    Me.ChkNonDepr.Text = "Non-Depreciable?"
    '
    'ChkGovFund
    '
    Me.ChkGovFund.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkGovFund.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkGovFund.Location = New System.Drawing.Point(12, 160)
    Me.ChkGovFund.Name = "ChkGovFund"
    Me.ChkGovFund.Size = New System.Drawing.Size(136, 16)
    Me.ChkGovFund.TabIndex = 15
    Me.ChkGovFund.Text = "Government Funded?"
    '
    'TxtFnd
    '
    Me.TxtFnd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFnd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFnd.Location = New System.Drawing.Point(308, 104)
    Me.TxtFnd.MaxLength = 3
    Me.TxtFnd.Name = "TxtFnd"
    Me.TxtFnd.Size = New System.Drawing.Size(32, 22)
    Me.TxtFnd.TabIndex = 3
    '
    'Label11
    '
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label11.Location = New System.Drawing.Point(244, 84)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(104, 16)
    Me.Label11.TabIndex = 310
    Me.Label11.Text = "G/L Grouping Code"
    '
    'TxtEyr
    '
    Me.TxtEyr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtEyr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtEyr.Location = New System.Drawing.Point(100, 108)
    Me.TxtEyr.MaxLength = 3
    Me.TxtEyr.Name = "TxtEyr"
    Me.TxtEyr.Size = New System.Drawing.Size(32, 22)
    Me.TxtEyr.TabIndex = 1
    Me.TxtEyr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label10
    '
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label10.Location = New System.Drawing.Point(12, 112)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(80, 16)
    Me.Label10.TabIndex = 308
    Me.Label10.Text = "Life Years"
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.DtPckDsdt)
    Me.GroupBox4.Controls.Add(Me.LnkDspmt)
    Me.GroupBox4.Controls.Add(Me.TxtDspmt)
    Me.GroupBox4.Controls.Add(Me.TxtDsvl)
    Me.GroupBox4.Controls.Add(Me.Label8)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox4.Location = New System.Drawing.Point(256, 8)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(260, 68)
    Me.GroupBox4.TabIndex = 1
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Disposal"
    '
    'DtPckDsdt
    '
    Me.DtPckDsdt.Checked = False
    Me.DtPckDsdt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckDsdt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckDsdt.Location = New System.Drawing.Point(160, 16)
    Me.DtPckDsdt.Name = "DtPckDsdt"
    Me.DtPckDsdt.ShowCheckBox = True
    Me.DtPckDsdt.Size = New System.Drawing.Size(96, 20)
    Me.DtPckDsdt.TabIndex = 1
    '
    'LnkDspmt
    '
    Me.LnkDspmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkDspmt.Location = New System.Drawing.Point(4, 20)
    Me.LnkDspmt.Name = "LnkDspmt"
    Me.LnkDspmt.Size = New System.Drawing.Size(80, 16)
    Me.LnkDspmt.TabIndex = 0
    Me.LnkDspmt.TabStop = True
    Me.LnkDspmt.Text = "Method"
    '
    'TxtDspmt
    '
    Me.TxtDspmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDspmt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDspmt.Location = New System.Drawing.Point(96, 16)
    Me.TxtDspmt.MaxLength = 5
    Me.TxtDspmt.Name = "TxtDspmt"
    Me.TxtDspmt.Size = New System.Drawing.Size(48, 22)
    Me.TxtDspmt.TabIndex = 0
    '
    'TxtDsvl
    '
    Me.TxtDsvl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDsvl.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDsvl.Location = New System.Drawing.Point(96, 40)
    Me.TxtDsvl.MaxLength = 11
    Me.TxtDsvl.Name = "TxtDsvl"
    Me.TxtDsvl.Size = New System.Drawing.Size(100, 22)
    Me.TxtDsvl.TabIndex = 2
    Me.TxtDsvl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label8
    '
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label8.Location = New System.Drawing.Point(8, 44)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(80, 16)
    Me.Label8.TabIndex = 39
    Me.Label8.Text = "Value"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.DtPckAqDt)
    Me.GroupBox3.Controls.Add(Me.LnkAqumt)
    Me.GroupBox3.Controls.Add(Me.TxtAqumt)
    Me.GroupBox3.Controls.Add(Me.TxtAqvl)
    Me.GroupBox3.Controls.Add(Me.Label9)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox3.Location = New System.Drawing.Point(4, 8)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(248, 68)
    Me.GroupBox3.TabIndex = 0
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Acquisition"
    '
    'DtPckAqDt
    '
    Me.DtPckAqDt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckAqDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckAqDt.Location = New System.Drawing.Point(158, 18)
    Me.DtPckAqDt.Name = "DtPckAqDt"
    Me.DtPckAqDt.Size = New System.Drawing.Size(84, 20)
    Me.DtPckAqDt.TabIndex = 1
    Me.DtPckAqDt.Value = New Date(2007, 3, 28, 0, 0, 0, 0)
    '
    'LnkAqumt
    '
    Me.LnkAqumt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkAqumt.Location = New System.Drawing.Point(4, 20)
    Me.LnkAqumt.Name = "LnkAqumt"
    Me.LnkAqumt.Size = New System.Drawing.Size(80, 16)
    Me.LnkAqumt.TabIndex = 304
    Me.LnkAqumt.TabStop = True
    Me.LnkAqumt.Text = "Method"
    '
    'TxtAqumt
    '
    Me.TxtAqumt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAqumt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAqumt.Location = New System.Drawing.Point(96, 16)
    Me.TxtAqumt.MaxLength = 5
    Me.TxtAqumt.Name = "TxtAqumt"
    Me.TxtAqumt.Size = New System.Drawing.Size(48, 22)
    Me.TxtAqumt.TabIndex = 0
    '
    'TxtAqvl
    '
    Me.TxtAqvl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAqvl.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAqvl.Location = New System.Drawing.Point(96, 40)
    Me.TxtAqvl.MaxLength = 11
    Me.TxtAqvl.Name = "TxtAqvl"
    Me.TxtAqvl.Size = New System.Drawing.Size(88, 22)
    Me.TxtAqvl.TabIndex = 2
    Me.TxtAqvl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label9
    '
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label9.Location = New System.Drawing.Point(8, 44)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(80, 16)
    Me.Label9.TabIndex = 39
    Me.Label9.Text = "Value"
    '
    'GroupBox8
    '
    Me.GroupBox8.Controls.Add(Me.RbDeleted)
    Me.GroupBox8.Controls.Add(Me.RbActive)
    Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox8.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox8.Location = New System.Drawing.Point(540, 8)
    Me.GroupBox8.Name = "GroupBox8"
    Me.GroupBox8.Size = New System.Drawing.Size(154, 41)
    Me.GroupBox8.TabIndex = 303
    Me.GroupBox8.TabStop = False
    Me.GroupBox8.Text = "Status"
    '
    'RbDeleted
    '
    Me.RbDeleted.AutoSize = True
    Me.RbDeleted.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbDeleted.ForeColor = System.Drawing.Color.Black
    Me.RbDeleted.Location = New System.Drawing.Point(82, 18)
    Me.RbDeleted.Name = "RbDeleted"
    Me.RbDeleted.Size = New System.Drawing.Size(62, 17)
    Me.RbDeleted.TabIndex = 1
    Me.RbDeleted.TabStop = True
    Me.RbDeleted.Text = "Deleted"
    Me.RbDeleted.UseVisualStyleBackColor = True
    '
    'RbActive
    '
    Me.RbActive.AutoSize = True
    Me.RbActive.Checked = True
    Me.RbActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbActive.ForeColor = System.Drawing.Color.Black
    Me.RbActive.Location = New System.Drawing.Point(6, 19)
    Me.RbActive.Name = "RbActive"
    Me.RbActive.Size = New System.Drawing.Size(55, 17)
    Me.RbActive.TabIndex = 0
    Me.RbActive.TabStop = True
    Me.RbActive.Text = "Active"
    Me.RbActive.UseVisualStyleBackColor = True
    '
    'FrmFA001C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(716, 465)
    Me.Controls.Add(Me.GroupBox8)
    Me.Controls.Add(Me.TabControl1)
    Me.Controls.Add(Me.TxtDesc)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtTagNo)
    Me.Controls.Add(Me.Label1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmFA001C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Asset"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TabControl1.ResumeLayout(False)
    Me.TpDetail.ResumeLayout(False)
    CType(Me.PicboxTag, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox7.ResumeLayout(False)
    Me.GroupBox7.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.TpDepr.ResumeLayout(False)
    Me.TpDepr.PerformLayout()
    Me.GrpDevl.ResumeLayout(False)
    Me.GrpDevl.PerformLayout()
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox6.ResumeLayout(False)
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox8.ResumeLayout(False)
    Me.GroupBox8.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmFA001C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myFAMSTR = New FAMSTR.MyData()
    myFAMSTR.MyDBConn = myDBConnect
    myFACMNTS = New FACMNTS.MyData()
    myFACMNTS.MyDBConn = myDBConnect
    myFAHIST = New FAHIST.MyData()
    myFAHIST.MyDBConn = myDBConnect

    LoadScrn = True
  MyFrmFA001.TBarNew.Enabled = False
  MyFrmFA001.TBarSave.Enabled = True
  MyFrmFA001.TBarComments.Enabled = False
  GetCaptions()

  'New record
  If AddMode Then
    Me.Text = "Add " & Me.Text
    MyFrmFA001.TBarDelete.Enabled = False
    TxtQty.Text = "1"
    DtPckAqDt.Value = Date.Today
    LoadScrn = False
    Exit Sub
  End If

  TxtTagNo.Text = WrkTagNo
  TxtTagNo.ReadOnly = True
  TxtTagNo.TabStop = False
  TxtTagNo.BackColor = Color.Aqua

  If s_chg = False And s_full = False Then  '#sec
    MyFrmFA001.TBarSave.Visible = False  '#sec
  End If  '#sec

  'Fill the dataset with the data
  Me.Text = "Maintain " & Me.Text
  MyFrmFA001.TBarDelete.Enabled = True
  myFAMSTR.GetOneRecordP(WrkTagNo)

  If myFAMSTR.RecordNotFound Then
    MyFrmFA001.TBarNew.Enabled = False
    MyFrmFA001.TBarSave.Enabled = False
    MyFrmFA001.TBarDelete.Enabled = False
    Me.ErrProv.SetError(TxtTagNo, "Record not found")
    Exit Sub
  End If

  MyFrmFA001.TBarComments.Enabled = True
  With myFAMSTR
    If ._FASTAT = "A" Then
      RbActive.Checked = True
    Else
      RbDeleted.Checked = True
    End If
    TxtQty.Text = ._FAQTY
    TxtDesc.Text = Trim(._FADESC)
    TxtSerialNo.Text = Trim(._FASERL)
    TxtInvoice.Text = Trim(._FAINV)
    TxtVendor.Text = Trim(._FAVEND)
    TxtAstype.Text = Trim(._FAASCD)
    TxtBldg.Text = Trim(._FABLCD)
    TxtSubLocation.Text = Trim(._FASUBL)
    TxtPhyLocation.Text = Trim(._FALOC)
    TxtDept.Text = Trim(._FADECD)
    TxtEqup.Text = Trim(._FAEQCD)
    TxtUser1.Text = Trim(._FAU1CD)
    TxtUser2.Text = Trim(._FAU2CD)
    TxtUser3.Text = Trim(._FAU3CD)
    TxtUser4.Text = Trim(._FAU4TX)
    TxtUser5.Text = Trim(._FAU5TX)
    TxtAqumt.Text = Trim(._FAAQCD)
    TxtAqvl.Text = ._FAAQVL
    DtPckAqDt.Value = MyUtils.GetDBDate(._FAAQDT)
    TxtDspmt.Text = Trim(._FADSCD)
    TxtDsvl.Text = ._FADSVL
    DtPckDsdt.Value = Date.Today
    If ._FADSDT > 0 Then
      DtPckDsdt.Value = MyUtils.GetDBDate(._FADSDT)
      DtPckDsdt.Checked = True
    End If
    TxtEyr.Text = ._FAEYR
    TxtGlgp.Text = Trim(._FAGLGP)
    TxtClass.Text = Trim(._FACLCD)
    TxtFnd.Text = ._FAFND
    TxtSfnd.Text = ._FASFND
    TxtDpt.Text = ._FADPT
    TxtObj.Text = ._FAOBJ
    TxtFcn.Text = ._FAFCN
    TxtSfcn.Text = ._FASFCN
    TxtFnd2.Text = ._FAFND2
    TxtSfn2.Text = ._FASFN2
    TxtDpt2.Text = ._FADPT2
    TxtObj2.Text = ._FAOBJ2
    TxtFcn2.Text = ._FAFCN2
    TxtSfc2.Text = ._FASFC2
    ChkGovFund.Checked = False
    If Trim(._FAGOV) = "Y" Then
      ChkGovFund.Checked = True
    End If
    ChkNonDepr.Checked = False
    If Trim(._FANDEP) = "Y" Then
      ChkNonDepr.Checked = True
    End If
    ChkNonReport.Checked = False
    If Trim(._FANREP) = "Y" Then
      ChkNonReport.Checked = True
    End If
    LblEdt.Text = MyUtils.GetDBDate(._FAEDT)
    GetThreshold()
    LblTotalDepr.Text = FormatCurrency(._FADEVL)
    LblAnnualDepr.Text = FormatCurrency(CalcDepr())
    TxtDevl.Text = Format(._FADEVL, "fixed")
 End With

  'Comments
  dsFACMNTS = myFACMNTS.Getcomments(WrkTagNo)
'  MyFrmFA001.TBarComments.Text = "Comments"
  MyFrmFA001.TBarComments.ImageKey = ""
  If dsFACMNTS.Tables(0).Rows.Count > 0 Then
    MyFrmFA001.TBarComments.ImageKey = "comment_24.png"
  End If

  getpicbox()

  SetAqumtTip()
  SetAsTypeTip()
  SetBldgTip()
  SetClassTip()
  SetDeptTip()
  SetDspmtTip()
  SetEqupTip()
  SetGLAcct1Tip()
  SetGLAcct2Tip()
  SetUser1Tip()
  SetUser2Tip()
  SetUser3Tip()
  SetVendorTip()

  FormatGrid()
  LoadScrn = False
  End Sub

  Private Sub FrmFA001C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmFA001.TBarNew.Enabled = True
    MyFrmFA001.TBarSave.Enabled = False
    MyFrmFA001.TBarDelete.Enabled = False
    MyFrmFA001.TBarSave.Visible = True   '#sec
    MyFrmFA001.TBarComments.Enabled = False
    MyFrmFA001B.FormatGrid(True, False)
    MyFrmFA001B.Show()

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    myFACMNTS.DeleteKeyComment(WrkTagNo)
    myFAMSTR.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim WrkNextKey As Integer
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String

    If TxtTagNo.Text = "" Then
      WrkNextKey = myFAMSTR.AutoGenKey
      MsgBox("Tag was left blank and assigned the next available number. Click Save again if OK", MsgBoxStyle.Exclamation, "Auto Generated Key")
      TxtTagNo.Text = WrkNextKey
      Exit Sub
    End If

    WrkTagNo = TxtTagNo.Text

    myFAMSTR.GetOneRecordP(WrkTagNo)
    If AddMode Then
      If Not myFAMSTR.RecordNotFound Then
        Me.ErrProv.SetError(TxtTagNo, "Record already exists")
        Exit Sub
      End If
    End If

    SetAqumtTip()
    SetAsTypeTip()
    SetBldgTip()
    SetClassTip()
    SetDeptTip()
    SetDspmtTip()
    SetEqupTip()
    SetGLAcct1Tip()
    SetGLAcct2Tip()
    SetUser1Tip()
    SetUser2Tip()
    SetUser3Tip()
    SetVendorTip()

    If Not AddMode Then
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myFAMSTR.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myFAMSTR.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    Me.Close()

  End Sub
   Private Sub MoveToFile()
      Dim WrkDiff As Integer
      WrkDiff = 0
      With myFAMSTR
        If AddMode Then
          ._FATAG = TxtTagNo.Text
        End If
        If RbActive.Checked Then
          ._FASTAT = "A"
        Else
          ._FASTAT = "D"
        End If
        ._FAQTY = MyUtils.CnvSng(TxtQty.Text)
        ._FADESC = TxtDesc.Text
        ._FASERL = TxtSerialNo.Text
        ._FACLCD = TxtClass.Text
        ._FABLCD = TxtBldg.Text
        ._FADECD = TxtDept.Text
        ._FAINV = TxtInvoice.Text
        ._FAVEND = TxtVendor.Text
        ._FAASCD = TxtAstype.Text
        ._FASUBL = TxtSubLocation.Text
        ._FALOC = TxtPhyLocation.Text
        ._FAEQCD = TxtEqup.Text
        ._FAU1CD = TxtUser1.Text
        ._FAU2CD = TxtUser2.Text
        ._FAU3CD = TxtUser3.Text
        ._FAU4TX = TxtUser4.Text
        ._FAU5TX = TxtUser5.Text
        ._FAAQCD = TxtAqumt.Text
        ._FAAQVL = MyUtils.CnvSng(TxtAqvl.Text)
        ._FAAQDT = MyUtils.SetDBDate(DtPckAqDt.Value)
        ._FADSCD = TxtDspmt.Text
        ._FADSVL = MyUtils.CnvSng(TxtDsvl.Text)
        ._FAEYR = MyUtils.CnvSng(TxtEyr.Text)
        GetExpireDate()
        ._FAEDT = MyUtils.SetDBDate(LblEdt.Text)
        ._FAGLGP = TxtGlgp.Text
        ._FAFND = MyUtils.CnvSng(TxtFnd.Text)
        ._FASFND = MyUtils.CnvSng(TxtSfnd.Text)
        ._FADPT = MyUtils.CnvSng(TxtDpt.Text)
        ._FAOBJ = MyUtils.CnvSng(TxtObj.Text)
        ._FAFCN = MyUtils.CnvSng(TxtFcn.Text)
        ._FASFCN = MyUtils.CnvSng(TxtSfcn.Text)
        ._FAFND2 = MyUtils.CnvSng(TxtFnd2.Text)
        ._FASFN2 = MyUtils.CnvSng(TxtSfn2.Text)
        ._FADPT2 = MyUtils.CnvSng(TxtDpt2.Text)
        ._FAOBJ2 = MyUtils.CnvSng(TxtObj2.Text)
        ._FAFCN2 = MyUtils.CnvSng(TxtFcn2.Text)
        ._FASFC2 = MyUtils.CnvSng(TxtSfc2.Text)
        ._FADSDT = 0
        If DtPckDsdt.Checked Then
          ._FADSDT = MyUtils.SetDBDate(DtPckDsdt.Value)
        End If
        ._FAGOV = "N"
        If ChkGovFund.Checked Then
          ._FAGOV = "Y"
        End If
        ._FANDEP = "N"
        If ChkNonDepr.Checked Then
          ._FANDEP = "Y"
        End If
        ._FANREP = "N"
        If ChkNonReport.Checked Then
          ._FANREP = "Y"
        End If
        If TxtDevl.ReadOnly = False Then
          WrkDiff = MyUtils.CnvSng(TxtDevl.Text) - ._FADEVL
          ._FADEVL = MyUtils.CnvSng(TxtDevl.Text)
        End If
      End With

      If WrkDiff <> 0 Then
        With myFAHIST
          ._FHADJ = "Y"
          ._FHTAG = TxtTagNo.Text
          ._FHDEVL = WrkDiff
          ._FHFISC = 0
          ._FHDEDT = 0
          If DataGrdView.RowCount > 0 Then
            If DataGrdView.Item(0, 0).Value <> "" Then
              ._FHFISC = DataGrdView.Item(1, 0).Value
              ._FHDEDT = DataGrdView.Item(3, 0).Value
            End If
          End If
          .AddOneRecordP()
        End With
      End If

   End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtAqumt, "")
    ErrProv.SetError(TxtAstype, "")
    ErrProv.SetError(TxtBldg, "")
    ErrProv.SetError(TxtClass, "")
    ErrProv.SetError(TxtDept, "")
    ErrProv.SetError(TxtDesc, "")
    ErrProv.SetError(TxtDevl, "")
    ErrProv.SetError(TxtDspmt, "")
    ErrProv.SetError(TxtEqup, "")
    ErrProv.SetError(TxtFnd, "")
    ErrProv.SetError(TxtFnd2, "")
    ErrProv.SetError(TxtEqup, "")
    ErrProv.SetError(TxtTagNo, "")
    ErrProv.SetError(TxtUser1, "")
    ErrProv.SetError(TxtUser2, "")
    ErrProv.SetError(TxtUser3, "")
    ErrProv.SetError(TxtVendor, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
      Case "faaqumt"
        ErrProv.SetError(TxtAqumt, ErrorMsg(I))
      Case "faascd"
        ErrProv.SetError(TxtAstype, ErrorMsg(I))
      Case "fablcd"
        ErrProv.SetError(TxtBldg, ErrorMsg(I))
      Case "faclcd"
        ErrProv.SetError(TxtClass, ErrorMsg(I))
      Case "fadecd"
        ErrProv.SetError(TxtDept, ErrorMsg(I))
      Case "fadesc"
        ErrProv.SetError(TxtDesc, ErrorMsg(I))
      Case "fadevl"
        ErrProv.SetError(TxtDevl, ErrorMsg(I))
      Case "fadscd"
        ErrProv.SetError(TxtDspmt, ErrorMsg(I))
      Case "faeqcd"
        ErrProv.SetError(TxtEqup, ErrorMsg(I))
      Case "fafnd"
        ErrProv.SetError(TxtFnd, ErrorMsg(I))
      Case "fafnd2"
        ErrProv.SetError(TxtFnd2, ErrorMsg(I))
      Case "fatag"
        ErrProv.SetError(TxtTagNo, ErrorMsg(I))
      Case "fau1cd"
        ErrProv.SetError(TxtUser1, ErrorMsg(I))
      Case "fau2cd"
        ErrProv.SetError(TxtUser2, ErrorMsg(I))
      Case "fau3cd"
        ErrProv.SetError(TxtUser3, ErrorMsg(I))
      Case "favend"
        ErrProv.SetError(TxtVendor, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim WrkTip As String
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtDesc.Text = String.Empty Then
      ErrorField(I) = "fadesc"
      ErrorMsg(I) = "Invalid Description"
      I = I + 1
    End If

    WrkTip = Ttp1.GetToolTip(TxtAqumt)
    If Mid(WrkTip, 1, 1) = "*" Then
      ErrorField(I) = "faaqumt"
      ErrorMsg(I) = "Invalid Acquistion Code"
      I = I + 1
    End If

    WrkTip = Ttp1.GetToolTip(TxtAstype)
    If Mid(WrkTip, 1, 1) = "*" Then
      ErrorField(I) = "faascd"
      ErrorMsg(I) = "Invalid Asset Type Code"
      I = I + 1
    End If

    WrkTip = Ttp1.GetToolTip(TxtBldg)
    If Mid(WrkTip, 1, 1) = "*" Then
      ErrorField(I) = "fablcd"
      ErrorMsg(I) = "Invalid Building Code"
      I = I + 1
    End If

    WrkTip = Ttp1.GetToolTip(TxtClass)
    If Mid(WrkTip, 1, 1) = "*" Then
      ErrorField(I) = "faclcd"
      ErrorMsg(I) = "Invalid Class Code"
      I = I + 1
    End If

    WrkTip = Ttp1.GetToolTip(TxtDept)
    If Mid(WrkTip, 1, 1) = "*" Then
      ErrorField(I) = "fadecd"
      ErrorMsg(I) = "Invalid Department Code"
      I = I + 1
    End If

    If TxtDspmt.Text <> "" Then
      WrkTip = Ttp1.GetToolTip(TxtDspmt)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "fadscd"
        ErrorMsg(I) = "Invalid Disposition Code"
        I = I + 1
      End If
    End If

    If TxtEqup.Text <> "" Then
      WrkTip = Ttp1.GetToolTip(TxtEqup)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "faeqcd"
        ErrorMsg(I) = "Invalid Equipment Condition Code"
        I = I + 1
      End If
    End If

    If TxtFnd.Text <> "" Then
      WrkTip = Ttp1.GetToolTip(TxtFnd)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "fafnd"
        ErrorMsg(I) = "Invalid G/L Acct 1"
        I = I + 1
      End If
    End If

    If TxtFnd2.Text <> "" Then
      WrkTip = Ttp1.GetToolTip(TxtFnd2)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "fafnd2"
        ErrorMsg(I) = "Invalid G/L Acct 2"
        I = I + 1
      End If
    End If

    If TxtUser1.Text <> "" Then
      WrkTip = Ttp1.GetToolTip(TxtUser1)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "fau1cd"
        ErrorMsg(I) = "Invalid User 1 Code"
        I = I + 1
      End If
    End If

    If TxtUser2.Text <> "" Then
      WrkTip = Ttp1.GetToolTip(TxtUser2)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "fau2cd"
        ErrorMsg(I) = "Invalid User 2 Code"
        I = I + 1
      End If
    End If

    If TxtUser3.Text <> "" Then
      WrkTip = Ttp1.GetToolTip(TxtUser3)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "fau3cd"
        ErrorMsg(I) = "Invalid User 3 Code"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtDevl.Text) > MyUtils.CnvSng(TxtAqvl.Text) Then
      ErrorField(I) = "fadevl"
      ErrorMsg(I) = "Accumlated Depr cannot be more than value"
      I = I + 1
    End If
  End Sub
  Private Sub FrmFA001C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    MyFrmFA001.SbpScreen.Text = "FA001C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
Private Sub LnkAqumt_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkAqumt.LinkClicked
  MyFrmListAqumt = New FrmListAqumt
  MyFrmListAqumt.MdiParent = Me.ParentForm
  MyFrmListAqumt.WrkCode = TxtAqumt.Text
  MyFrmListAqumt.Show()
End Sub
Private Sub LnkAstype_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkAstype.LinkClicked
  MyFrmListAstype = New FrmListAsType
  MyFrmListAstype.MdiParent = Me.ParentForm
  MyFrmListAstype.WrkCode = TxtAstype.Text
  MyFrmListAstype.Show()
End Sub
Private Sub LnkBldg_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBldg.LinkClicked
  MyFrmListBldg = New FrmListBldg
  MyFrmListBldg.MdiParent = Me.ParentForm
  MyFrmListBldg.WrkCode = TxtBldg.Text
  MyFrmListBldg.Show()
End Sub
Private Sub LnkClass_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkClass.LinkClicked
  MyFrmListClass = New FrmListClass
  MyFrmListClass.MdiParent = Me.ParentForm
  MyFrmListClass.WrkCode = TxtClass.Text
  MyFrmListClass.Show()
End Sub
Private Sub LnkDept_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDept.LinkClicked
  MyFrmListDept = New FrmListDept
  MyFrmListDept.MdiParent = Me.ParentForm
  MyFrmListDept.WrkCode = TxtDept.Text
  MyFrmListDept.Show()
End Sub
Private Sub LnkDspmt_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDspmt.LinkClicked
  MyFrmListDspmt = New FrmListDspmt
  MyFrmListDspmt.MdiParent = Me.ParentForm
  MyFrmListDspmt.WrkCode = TxtDspmt.Text
  MyFrmListDspmt.Show()
End Sub
Private Sub LnkEqup_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkEqup.LinkClicked
  MyFrmListEqup = New FrmListEqup
  MyFrmListEqup.MdiParent = Me.ParentForm
  MyFrmListEqup.WrkCode = TxtEqup.Text
  MyFrmListEqup.Show()
End Sub
Private Sub LnkGLAcct1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkGLAcct1.LinkClicked
  Dim WrkAcct As String

  WrkAcct = BuildAcct(MyUtils.Cnvsng(TxtFnd.Text), MyUtils.Cnvsng(TxtSfnd.Text), MyUtils.Cnvsng(TxtDpt.Text), _
    MyUtils.Cnvsng(TxtObj.Text), MyUtils.Cnvsng(TxtFcn.Text), MyUtils.Cnvsng(TxtSfcn.Text))
  MyFrmListGLAcct = New FrmListGLAcct
  MyFrmListGLAcct.MdiParent = Me.ParentForm
  MyFrmListGLAcct.WrkField = "1"
  MyFrmListGLAcct.WrkCode = WrkAcct
  MyFrmListGLAcct.Show()
End Sub
Private Sub LnkGLAcct2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkGLAcct2.LinkClicked
  Dim WrkAcct As String

  WrkAcct = BuildAcct(MyUtils.Cnvsng(TxtFnd2.Text), MyUtils.Cnvsng(TxtSfn2.Text), MyUtils.Cnvsng(TxtDpt2.Text), _
    MyUtils.Cnvsng(TxtObj2.Text), MyUtils.Cnvsng(TxtFcn2.Text), MyUtils.Cnvsng(TxtSfc2.Text))
  MyFrmListGLAcct = New FrmListGLAcct
  MyFrmListGLAcct.MdiParent = Me.ParentForm
  MyFrmListGLAcct.WrkField = "2"
  MyFrmListGLAcct.WrkCode = WrkAcct
  MyFrmListGLAcct.Show()
End Sub
Private Sub LnkUser1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkUser1.LinkClicked
   MyFrmListUser1 = New FrmListUser1
   MyFrmListUser1.MdiParent = Me.ParentForm
   MyFrmListUser1.WrkCode = TxtUser1.Text
   MyFrmListUser1.Show()
End Sub
 Private Sub LnkUser2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkUser2.LinkClicked
   MyFrmListUser2 = New FrmListUser2
   MyFrmListUser2.MdiParent = Me.ParentForm
   MyFrmListUser2.WrkCode = TxtUser2.Text
   MyFrmListUser2.Show()
End Sub
 Private Sub LnkUser3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkUser3.LinkClicked
   MyFrmListUser3 = New FrmListUser3
   MyFrmListUser3.MdiParent = Me.ParentForm
   MyFrmListUser3.WrkCode = TxtUser3.Text
   MyFrmListUser3.Show()
End Sub
Private Sub LnkVendor_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkVendor.LinkClicked
  MyFrmListVendor = New FrmListVendor
  MyFrmListVendor.MdiParent = Me.ParentForm
  MyFrmListVendor.WrkCode = TxtVendor.Text
  MyFrmListVendor.Show()
End Sub
Private Sub SetAqumtTip()
  Dim WrkDesc As String

  If LoadScrn Then Exit Sub

  WrkDesc = GetfaAqumtDesc(TxtAqumt.Text)
  Ttp1.SetToolTip(TxtAqumt, WrkDesc)
End Sub
Private Sub SetAsTypeTip()
    Dim WrkDesc As String

    If LoadScrn Then Exit Sub

    WrkDesc = GetFAASTypeDesc(TxtAstype.Text)
    Ttp1.SetToolTip(TxtAstype, WrkDesc)
End Sub
Private Sub SetBldgTip()
    Dim WrkDesc As String

    If Not TxtBldg.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetFABldgDesc(TxtBldg.Text)
    Ttp1.SetToolTip(TxtBldg, WrkDesc)
End Sub
Private Sub SetClassTip()
    Dim WrkDesc As String

    If LoadScrn Then Exit Sub

    WrkDesc = GetFAClassDesc(TxtClass.Text)
    Ttp1.SetToolTip(TxtClass, WrkDesc)
End Sub
Private Sub SetDeptTip()
    Dim WrkDesc As String

    If LoadScrn Then Exit Sub

    WrkDesc = GetFADeptDesc(TxtDept.Text)
    Ttp1.SetToolTip(TxtDept, WrkDesc)
End Sub
Private Sub SetDspmtTip()
    Dim WrkDesc As String

    If Not TxtDspmt.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetfaDspmtDesc(TxtDspmt.Text)
    Ttp1.SetToolTip(TxtDspmt, WrkDesc)
End Sub
Private Sub SetEqupTip()
    Dim WrkDesc As String

    If Not TxtEqup.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetFAEqupDesc(TxtEqup.Text)
    Ttp1.SetToolTip(TxtEqup, WrkDesc)
End Sub
Private Sub SetGLAcct1Tip()
    Dim WrkDesc As String

    If Not TxtFnd.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetGLACCTDesc(MyUtils.Cnvsng(TxtFnd.Text), MyUtils.Cnvsng(TxtSfnd.Text), MyUtils.Cnvsng(TxtDpt.Text), _
      MyUtils.Cnvsng(TxtObj.Text), MyUtils.Cnvsng(TxtFcn.Text), MyUtils.Cnvsng(TxtSfcn.Text))
    Ttp1.SetToolTip(TxtFnd, WrkDesc)
End Sub
Private Sub SetGLAcct2Tip()
    Dim WrkDesc As String

    If Not TxtFnd2.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetGLACCTDesc(MyUtils.Cnvsng(TxtFnd2.Text), MyUtils.Cnvsng(TxtSfn2.Text), MyUtils.Cnvsng(TxtDpt2.Text), _
      MyUtils.Cnvsng(TxtObj2.Text), MyUtils.Cnvsng(TxtFcn2.Text), MyUtils.Cnvsng(TxtSfc2.Text))
    Ttp1.SetToolTip(TxtFnd2, WrkDesc)
End Sub
Private Sub SetUser1Tip()
    Dim WrkDesc As String

    If Not TxtUser1.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetFAUser1Desc(TxtUser1.Text)
    Ttp1.SetToolTip(TxtUser1, WrkDesc)
End Sub
Private Sub SetUser2Tip()
    Dim WrkDesc As String

    If Not TxtUser2.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetFAUser2Desc(TxtUser2.Text)
    Ttp1.SetToolTip(TxtUser2, WrkDesc)
End Sub
Private Sub SetUser3Tip()
    Dim WrkDesc As String

    If Not TxtUser3.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetFAUser3Desc(TxtUser3.Text)
    Ttp1.SetToolTip(TxtUser3, WrkDesc)
End Sub
Private Sub SetVendorTip()
    Dim WrkDesc As String

    If Not TxtVendor.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetVendorName(TxtVendor.Text)
    Ttp1.SetToolTip(TxtVendor, WrkDesc)
End Sub
  Private Sub TxtAqumt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAqumt.Leave
    SetAqumtTip()
  End Sub
  Private Sub TxtAsType_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAstype.Leave
    SetAsTypeTip()
  End Sub
  Private Sub TxtBldg_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBldg.Leave
    SetBldgTip()
  End Sub
  Private Sub TxtClass_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtClass.Leave
    SetClassTip()
  End Sub
  Private Sub TxtDept_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDept.Leave
    SetDeptTip()
  End Sub
  Private Sub TxtDspmt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDspmt.Leave
    SetDspmtTip()
  End Sub
  Private Sub TxtEqup_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEqup.Leave
    SetEqupTip()
  End Sub
  Private Sub TxtUser1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtUser1.Leave
    SetUser1Tip()
  End Sub
  Private Sub TxtUser2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtUser2.Leave
    SetUser2Tip()
  End Sub
  Private Sub TxtUser3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtUser3.Leave
    SetUser3Tip()
  End Sub
  Private Sub TxtVendor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVendor.Leave
    SetVendorTip()
  End Sub
Private Sub TxtAqvl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAqvl.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDsvl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDsvl.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtEyr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEyr.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtQty.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtFnd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFnd.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtSfnd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSfnd.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDpt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDpt.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtObj_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtObj.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtFcn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFcn.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtSfcn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSfcn.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtFnd2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFnd2.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtSfn2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSfn2.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDpt2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDpt2.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtObj2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtObj2.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtFcn2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFcn2.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtSfc2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSfc2.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDevl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDevl.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Function CalcDepr() As Decimal

  Dim WrkAqvl As Decimal
  Dim WrkDsvl As Decimal
  Dim WrkDepr As Decimal
  Dim WrkDeprAnnual As Decimal
  Dim WrkTotDepr As Decimal
  Dim WrkThreshold As Decimal
  Dim WrkEyr As Integer

  WrkAqvl = MyUtils.Cnvsng(TxtAqvl.Text)
  WrkDsvl = MyUtils.Cnvsng(TxtDsvl.Text)
  WrkDepr = WrkAqvl - WrkDsvl
  WrkTotDepr = MyUtils.Cnvsng(LblTotalDepr.Text)
  WrkThreshold = MyUtils.Cnvsng(LblAssetThreshold.Text)
  WrkEyr = MyUtils.Cnvsng(TxtEyr.Text)

  'If Non-Depreciable then skip record
  If ChkNonDepr.Checked Then Return 0

  'If Total Depreciation is less than Threshhold amount then skip record
  If WrkDepr < WrkThreshold Then Return 0

  'If Total Accumulated Depreciation is equal to Total Depreciation then skip record
  If WrkTotDepr = WrkDepr Then Return 0

  'Calculate Next Depreciation
  If MyUtils.Cnvsng(TxtEyr.Text) > 0 Then
    WrkDeprAnnual = WrkDepr / WrkEyr
  End If

  'If Life Expectancy Date is before today's date, then 
  'Depreciation = Total Depreciation - Total Accumulated Depreciation
  If LblEdt.Text < Date.Today Then
    WrkDeprAnnual = WrkDepr - WrkTotDepr
  End If

  'If Disposal date is not blank, then 
  'Depreciation = Total Depreciation - Total Accumulated Depreciation
   'If DtPckDsdt.Checked Then
   '  WrkDeprAnnual = WrkDepr - WrkTotDepr
   'End If

   WrkDeprAnnual = MyUtils.Round(WrkDeprAnnual, 2)
   If WrkDeprAnnual < 0 Then WrkDeprAnnual = 0
   Return WrkDeprAnnual
End Function
Private Sub GetCaptions()
    Dim myFACAPT As FACAPT.MyData

    myFACAPT = New FACAPT.MyData()
    myFACAPT.MyDBConn = myDBConnect
    myFACAPT.GetOneRecordP(1)
    If Not myFACAPT.RecordNotFound Then
      With myFACAPT
        LnkUser1.Text = Trim(._CAP06)
        LnkUser2.Text = Trim(._CAP07)
        LnkUser3.Text = Trim(._CAP08)
        LblUser4.Text = Trim(._CAP09)
        LblUser5.Text = Trim(._CAP10)
      End With
    End If
End Sub
Private Sub GetThreshold()
    Dim myFAASTYPE As FAASTYPE.MyData

    myFAASTYPE = New FAASTYPE.MyData()
    myFAASTYPE.MyDBConn = myDBConnect
    myFAASTYPE.GetOneRecordP(TxtAstype.Text)
    If Not myFAASTYPE.RecordNotFound Then
      If MyUtils.Cnvsng(TxtEyr.Text) = 0 Then
        TxtEyr.Text = myFAASTYPE._ASEYR
      End If
      LblAssetThreshold.Text = myFAASTYPE._ASTHLD
    End If
End Sub
Private Sub GetExpireDate()
  LblEdt.Text = DateAdd(DateInterval.Year, MyUtils.Cnvsng(TxtEyr.Text), DtPckAqDt.Value)
End Sub
Public Sub FormatGrid()
 Dim Style As DataGridViewCellStyle
 Call ShowGrid()

 With DataGrdView
   .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
   .RowHeadersWidth = 25
    Style = DataGrdView.ColumnHeadersDefaultCellStyle
    Style.Font = New Font(DataGrdView.Font, FontStyle.Regular)
    Style = DataGrdView.DefaultCellStyle
    Style.Font = New Font(DataGrdView.Font, FontStyle.Regular)
   .Columns(0).Visible = False
   .Columns(1).HeaderText = "FiscYr"
   .Columns(1).Width = 40
   .Columns(2).HeaderText = "Date"
   .Columns(2).Width = 70
   .Columns(2).DefaultCellStyle.Format = "##/##/####"
   .Columns(3).Visible = False
   .Columns(4).HeaderText = "Value"
   .Columns(4).Width = 50
   .Columns(5).HeaderText = "Adjust"
   .Columns(5).Width = 50
   .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
 End With

End Sub
Public Sub ShowGrid()
  Windows.Forms.Cursor.Current = Cursors.WaitCursor

  Dim ds2 As DataSet = New DataSet

  ds2 = myFAHIST.GetViewDscList(TxtTagNo.Text, 999)
  DataGrdView.DataSource = ds2.Tables(0)
  DataGrdView.Refresh()
  Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Function BuildAcct(ByVal Fund As Integer, ByVal SFund As Integer, _
  ByVal Dept As Integer, ByVal Obj As Integer, ByVal Func As Integer, ByVal SFunc As Integer) As String
  Dim sb As StringBuilder = New StringBuilder

  sb.Append(Format(Fund, "000"))
  sb.Append("-")
  sb.Append(Format(SFund, "000"))
  sb.Append("-")
  sb.Append(Format(Dept, "0000"))
  sb.Append("-")
  sb.Append(Format(Obj, "000"))
  sb.Append("-")
  sb.Append(Format(Func, "0000"))
  sb.Append("-")
  sb.Append(Format(SFunc, "0000"))
  Return sb.ToString
End Function
Private Sub GrpDevl_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrpDevl.DoubleClick
  TxtDevl.ReadOnly = False
  TxtDevl.BackColor = Color.White
End Sub
Private Sub GetPicBox()
  Dim Good As Boolean
  Good = MyUtils.CheckFileExists(MyAppSettings.ImageDir & "\" & WrkTagNo & ".jpg")
  If Good Then
    PicboxTag.ImageLocation = MyAppSettings.ImageDir & "\" & WrkTagNo & ".jpg"
    Exit Sub
  End If

  Good = MyUtils.CheckFileExists(MyAppSettings.ImageDir & "\gemsnet.gif")
  If Good Then
    PicboxTag.ImageLocation = MyAppSettings.ImageDir & "\gemsnet.gif"
  End If
End Sub
Private Sub PicboxTag_Click(sender As Object, e As EventArgs) Handles PicboxTag.Click
  With OpenFileDialog1
    .ReadOnlyChecked = True
    .ShowDialog()
    If .FileName <> "" Then
      PicboxTag.ImageLocation = .FileName
      PicboxTag.Load()
      PicboxTag.Image.Save(MyAppSettings.ImageDir & WrkTagNo & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
      GetPicBox()
    End If
  End With
End Sub
End Class
