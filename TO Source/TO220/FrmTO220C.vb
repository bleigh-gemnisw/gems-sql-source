Public Class FrmTO220C
  Inherits System.Windows.Forms.Form
  Dim MyTXDEFER As TXDEFER.MyData
  Dim MyTXREALC As TXREALC.MyData
  Dim MyTXREAA As TXREAA.MyData
  Dim MyTXMRATE As TXMRATE.MyData
  Dim MyTPAYMNT As TPAYMNT.MyData
  Dim MyTXM35H As TXM35H.MyData
  Friend WrkListNo As Integer
  Friend WrkType As String
  Friend WrkYear As Integer
  Dim AddMode As Boolean
  Dim LoadScrn As Boolean
  Dim WrkFoundArchive As Boolean
  Dim WrkExcludeGross As Integer
  'Adjusted Gross - excluded codes
  Dim cExcludeCode1 As Integer = 12

  Friend WithEvents Tab1 As System.Windows.Forms.TabControl
  Friend WithEvents TpApplicant As System.Windows.Forms.TabPage
  Friend WithEvents TxtSLName As System.Windows.Forms.TextBox
  Friend WithEvents TxtALName As System.Windows.Forms.TextBox
  Friend WithEvents TxtMZip As System.Windows.Forms.TextBox
  Friend WithEvents TxtMState As System.Windows.Forms.TextBox
  Friend WithEvents TxtMCity As System.Windows.Forms.TextBox
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtSFName As System.Windows.Forms.TextBox
  Friend WithEvents TxtSInit As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtAFName As System.Windows.Forms.TextBox
  Friend WithEvents TxtAInit As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents TxtOther As System.Windows.Forms.TextBox
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents TxtSSA As System.Windows.Forms.TextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents TxtIncome As System.Windows.Forms.TextBox
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents LnkListNo As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
  Friend WithEvents TpAssessor As System.Windows.Forms.TabPage
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents Label27 As System.Windows.Forms.Label
  Friend WithEvents Label28 As System.Windows.Forms.Label
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
  Friend WithEvents RbDisallowed As System.Windows.Forms.RadioButton
  Friend WithEvents RbAllowed As System.Windows.Forms.RadioButton
  Friend WithEvents LblTotal As System.Windows.Forms.Label
  Friend WithEvents LblYear As System.Windows.Forms.Label
  Friend WithEvents LblListNo As System.Windows.Forms.Label
  Friend WithEvents LblAInit As System.Windows.Forms.Label
  Friend WithEvents LblAFName As System.Windows.Forms.Label
  Friend WithEvents LblALName As System.Windows.Forms.Label
  Friend WithEvents TxtDisallowReason As System.Windows.Forms.TextBox
  Friend WithEvents DtPckAssr As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label54 As System.Windows.Forms.Label
  Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtSName As System.Windows.Forms.TextBox
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents Label55 As System.Windows.Forms.Label
  Friend WithEvents Label48 As System.Windows.Forms.Label
  Friend WithEvents GrpType As System.Windows.Forms.GroupBox
  Friend WithEvents RbRE As System.Windows.Forms.RadioButton
  Friend WithEvents LblTypeDesc As System.Windows.Forms.Label
  Friend WithEvents Label26 As System.Windows.Forms.Label
  Friend WithEvents Label34 As System.Windows.Forms.Label
  Friend WithEvents Label36 As System.Windows.Forms.Label
  Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
  Friend WithEvents Label38 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label39 As System.Windows.Forms.Label
  Friend WithEvents Label40 As System.Windows.Forms.Label
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents Label41 As System.Windows.Forms.Label
  Friend WithEvents Label42 As System.Windows.Forms.Label
  Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label43 As System.Windows.Forms.Label
  Friend WithEvents Label44 As System.Windows.Forms.Label
  Friend WithEvents Label45 As System.Windows.Forms.Label
  Friend WithEvents Label46 As System.Windows.Forms.Label
  Friend WithEvents Label47 As System.Windows.Forms.Label
  Friend WithEvents Label49 As System.Windows.Forms.Label
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
  Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
  Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
  Friend WithEvents Label50 As System.Windows.Forms.Label
  Friend WithEvents Label52 As System.Windows.Forms.Label
  Friend WithEvents Label53 As System.Windows.Forms.Label
  Friend WithEvents Label56 As System.Windows.Forms.Label
  Friend WithEvents Label57 As System.Windows.Forms.Label
  Friend WithEvents Label59 As System.Windows.Forms.Label
  Friend WithEvents Label35 As System.Windows.Forms.Label
  Friend WithEvents Label25 As System.Windows.Forms.Label
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents TxtZip As System.Windows.Forms.TextBox
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents TxtCity As System.Windows.Forms.TextBox
  Friend WithEvents Label63 As System.Windows.Forms.Label
  Friend WithEvents Label64 As System.Windows.Forms.Label
  Friend WithEvents Label65 As System.Windows.Forms.Label
  Friend WithEvents Label66 As System.Windows.Forms.Label
  Friend WithEvents TxtMAddr As System.Windows.Forms.TextBox
  Friend WithEvents TxtLoc As System.Windows.Forms.TextBox
  Friend WithEvents TxtLocNo As System.Windows.Forms.TextBox
  Friend WithEvents MskTxtSSSN As System.Windows.Forms.MaskedTextBox
  Friend WithEvents MskTxtASSN As System.Windows.Forms.MaskedTextBox
  Friend WithEvents LblGross As Label
  Friend WithEvents Label9 As Label
  Friend WithEvents LblAppGross As Label
  Friend WithEvents Label18 As Label
  Friend WithEvents LblMillRate As Label
  Friend WithEvents Label8 As Label
  Friend WithEvents MskTxtPhone As MaskedTextBox
  Friend WithEvents Label23 As Label
  Friend WithEvents TxtRelate As TextBox
  Friend WithEvents Label31 As Label
  Friend WithEvents Label24 As Label
  Friend WithEvents DtPckSigned As DateTimePicker
  Friend WithEvents LblDeferred As Label
  Friend WithEvents Label51 As Label
  Friend WithEvents LblStBenefit As Label
  Friend WithEvents Label32 As Label
  Friend WithEvents LblTaxDue As Label
  Friend WithEvents Label61 As Label
  Friend WithEvents Label60 As Label
  Friend WithEvents LblTotTax As Label
  Friend WithEvents Label3 As Label
  Friend WithEvents LblPropTax As Label
  Friend WithEvents Label33 As Label
  Friend WithEvents TxtPropPct As TextBox
  Friend WithEvents Label37 As Label
  Friend WithEvents Label58 As Label
  Friend WithEvents Label62 As Label
  Friend WithEvents LblAddlTax As Label
  Friend WithEvents Label68 As Label
    Friend WithEvents Label70 As Label
    Friend WithEvents LblXVet As Label
    Friend WithEvents Label72 As Label
    Friend WithEvents LblNet As Label
  Friend WithEvents BtnRecalc As Button
  Friend WithEvents Label69 As Label
  Friend WithEvents LblLocal As Label
  Friend WithEvents Label73 As Label
  Friend WithEvents Label67 As Label


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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTO220C))
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.Tab1 = New System.Windows.Forms.TabControl()
    Me.TpApplicant = New System.Windows.Forms.TabPage()
    Me.MskTxtPhone = New System.Windows.Forms.MaskedTextBox()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.TxtRelate = New System.Windows.Forms.TextBox()
    Me.Label31 = New System.Windows.Forms.Label()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.DtPckSigned = New System.Windows.Forms.DateTimePicker()
    Me.MskTxtSSSN = New System.Windows.Forms.MaskedTextBox()
    Me.MskTxtASSN = New System.Windows.Forms.MaskedTextBox()
    Me.TxtLoc = New System.Windows.Forms.TextBox()
    Me.TxtLocNo = New System.Windows.Forms.TextBox()
    Me.TxtZip = New System.Windows.Forms.TextBox()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.Label63 = New System.Windows.Forms.Label()
    Me.Label64 = New System.Windows.Forms.Label()
    Me.Label65 = New System.Windows.Forms.Label()
    Me.Label66 = New System.Windows.Forms.Label()
    Me.GrpType = New System.Windows.Forms.GroupBox()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.TxtSName = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.TxtSLName = New System.Windows.Forms.TextBox()
    Me.TxtALName = New System.Windows.Forms.TextBox()
    Me.TxtMZip = New System.Windows.Forms.TextBox()
    Me.TxtMState = New System.Windows.Forms.TextBox()
    Me.TxtMAddr = New System.Windows.Forms.TextBox()
    Me.TxtMCity = New System.Windows.Forms.TextBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtSFName = New System.Windows.Forms.TextBox()
    Me.TxtSInit = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtAFName = New System.Windows.Forms.TextBox()
    Me.TxtAInit = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.Label59 = New System.Windows.Forms.Label()
    Me.Label35 = New System.Windows.Forms.Label()
    Me.Label25 = New System.Windows.Forms.Label()
    Me.Label55 = New System.Windows.Forms.Label()
    Me.Label48 = New System.Windows.Forms.Label()
    Me.LblTotal = New System.Windows.Forms.Label()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.TxtOther = New System.Windows.Forms.TextBox()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.TxtSSA = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.TxtIncome = New System.Windows.Forms.TextBox()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.LnkListNo = New System.Windows.Forms.LinkLabel()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.TpAssessor = New System.Windows.Forms.TabPage()
    Me.BtnRecalc = New System.Windows.Forms.Button()
    Me.Label72 = New System.Windows.Forms.Label()
    Me.LblNet = New System.Windows.Forms.Label()
    Me.Label70 = New System.Windows.Forms.Label()
    Me.LblXVet = New System.Windows.Forms.Label()
    Me.Label68 = New System.Windows.Forms.Label()
    Me.Label67 = New System.Windows.Forms.Label()
    Me.Label58 = New System.Windows.Forms.Label()
    Me.Label62 = New System.Windows.Forms.Label()
    Me.LblAddlTax = New System.Windows.Forms.Label()
    Me.Label33 = New System.Windows.Forms.Label()
    Me.TxtPropPct = New System.Windows.Forms.TextBox()
    Me.Label37 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.LblPropTax = New System.Windows.Forms.Label()
    Me.LblTaxDue = New System.Windows.Forms.Label()
    Me.Label61 = New System.Windows.Forms.Label()
    Me.Label60 = New System.Windows.Forms.Label()
    Me.LblTotTax = New System.Windows.Forms.Label()
    Me.LblDeferred = New System.Windows.Forms.Label()
    Me.Label51 = New System.Windows.Forms.Label()
    Me.LblStBenefit = New System.Windows.Forms.Label()
    Me.Label32 = New System.Windows.Forms.Label()
    Me.LblGross = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.LblAppGross = New System.Windows.Forms.Label()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.LblMillRate = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.LblTypeDesc = New System.Windows.Forms.Label()
    Me.Label26 = New System.Windows.Forms.Label()
    Me.DtPckAssr = New System.Windows.Forms.DateTimePicker()
    Me.Label54 = New System.Windows.Forms.Label()
    Me.LblAInit = New System.Windows.Forms.Label()
    Me.LblAFName = New System.Windows.Forms.Label()
    Me.LblALName = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.TxtDisallowReason = New System.Windows.Forms.TextBox()
    Me.RbDisallowed = New System.Windows.Forms.RadioButton()
    Me.RbAllowed = New System.Windows.Forms.RadioButton()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.Label22 = New System.Windows.Forms.Label()
    Me.Label27 = New System.Windows.Forms.Label()
    Me.Label28 = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.Label34 = New System.Windows.Forms.Label()
    Me.Label36 = New System.Windows.Forms.Label()
    Me.CheckBox2 = New System.Windows.Forms.CheckBox()
    Me.Label38 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label39 = New System.Windows.Forms.Label()
    Me.Label40 = New System.Windows.Forms.Label()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.Label41 = New System.Windows.Forms.Label()
    Me.Label42 = New System.Windows.Forms.Label()
    Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
    Me.Label43 = New System.Windows.Forms.Label()
    Me.Label44 = New System.Windows.Forms.Label()
    Me.Label45 = New System.Windows.Forms.Label()
    Me.Label46 = New System.Windows.Forms.Label()
    Me.Label47 = New System.Windows.Forms.Label()
    Me.Label49 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.TextBox3 = New System.Windows.Forms.TextBox()
    Me.RadioButton1 = New System.Windows.Forms.RadioButton()
    Me.RadioButton2 = New System.Windows.Forms.RadioButton()
    Me.Label50 = New System.Windows.Forms.Label()
    Me.Label52 = New System.Windows.Forms.Label()
    Me.Label53 = New System.Windows.Forms.Label()
    Me.Label56 = New System.Windows.Forms.Label()
    Me.Label57 = New System.Windows.Forms.Label()
    Me.Label69 = New System.Windows.Forms.Label()
    Me.LblLocal = New System.Windows.Forms.Label()
    Me.Label73 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Tab1.SuspendLayout()
    Me.TpApplicant.SuspendLayout()
    Me.GrpType.SuspendLayout()
    Me.GroupBox6.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.TpAssessor.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Tab1
    '
    Me.Tab1.Controls.Add(Me.TpApplicant)
    Me.Tab1.Controls.Add(Me.TpAssessor)
    Me.Tab1.ImageList = Me.ImageList1
    Me.Tab1.Location = New System.Drawing.Point(1, 2)
    Me.Tab1.Name = "Tab1"
    Me.Tab1.SelectedIndex = 0
    Me.Tab1.Size = New System.Drawing.Size(771, 623)
    Me.Tab1.TabIndex = 0
    '
    'TpApplicant
    '
    Me.TpApplicant.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.TpApplicant.Controls.Add(Me.MskTxtPhone)
    Me.TpApplicant.Controls.Add(Me.Label23)
    Me.TpApplicant.Controls.Add(Me.TxtRelate)
    Me.TpApplicant.Controls.Add(Me.Label31)
    Me.TpApplicant.Controls.Add(Me.Label24)
    Me.TpApplicant.Controls.Add(Me.DtPckSigned)
    Me.TpApplicant.Controls.Add(Me.MskTxtSSSN)
    Me.TpApplicant.Controls.Add(Me.MskTxtASSN)
    Me.TpApplicant.Controls.Add(Me.TxtLoc)
    Me.TpApplicant.Controls.Add(Me.TxtLocNo)
    Me.TpApplicant.Controls.Add(Me.TxtZip)
    Me.TpApplicant.Controls.Add(Me.TxtState)
    Me.TpApplicant.Controls.Add(Me.TxtCity)
    Me.TpApplicant.Controls.Add(Me.Label63)
    Me.TpApplicant.Controls.Add(Me.Label64)
    Me.TpApplicant.Controls.Add(Me.Label65)
    Me.TpApplicant.Controls.Add(Me.Label66)
    Me.TpApplicant.Controls.Add(Me.GrpType)
    Me.TpApplicant.Controls.Add(Me.GroupBox6)
    Me.TpApplicant.Controls.Add(Me.TxtSLName)
    Me.TpApplicant.Controls.Add(Me.TxtALName)
    Me.TpApplicant.Controls.Add(Me.TxtMZip)
    Me.TpApplicant.Controls.Add(Me.TxtMState)
    Me.TpApplicant.Controls.Add(Me.TxtMAddr)
    Me.TpApplicant.Controls.Add(Me.TxtMCity)
    Me.TpApplicant.Controls.Add(Me.Label17)
    Me.TpApplicant.Controls.Add(Me.Label16)
    Me.TpApplicant.Controls.Add(Me.Label14)
    Me.TpApplicant.Controls.Add(Me.Label12)
    Me.TpApplicant.Controls.Add(Me.Label11)
    Me.TpApplicant.Controls.Add(Me.Label10)
    Me.TpApplicant.Controls.Add(Me.Label5)
    Me.TpApplicant.Controls.Add(Me.Label6)
    Me.TpApplicant.Controls.Add(Me.TxtSFName)
    Me.TpApplicant.Controls.Add(Me.TxtSInit)
    Me.TpApplicant.Controls.Add(Me.Label7)
    Me.TpApplicant.Controls.Add(Me.Label4)
    Me.TpApplicant.Controls.Add(Me.Label2)
    Me.TpApplicant.Controls.Add(Me.TxtAFName)
    Me.TpApplicant.Controls.Add(Me.TxtAInit)
    Me.TpApplicant.Controls.Add(Me.Label1)
    Me.TpApplicant.Controls.Add(Me.GroupBox1)
    Me.TpApplicant.Controls.Add(Me.LnkListNo)
    Me.TpApplicant.Controls.Add(Me.TxtYear)
    Me.TpApplicant.Controls.Add(Me.Label13)
    Me.TpApplicant.Controls.Add(Me.TxtListNo)
    Me.TpApplicant.ImageIndex = 0
    Me.TpApplicant.Location = New System.Drawing.Point(4, 23)
    Me.TpApplicant.Name = "TpApplicant"
    Me.TpApplicant.Padding = New System.Windows.Forms.Padding(3)
    Me.TpApplicant.Size = New System.Drawing.Size(763, 596)
    Me.TpApplicant.TabIndex = 0
    Me.TpApplicant.Text = "Applicant Information"
    Me.TpApplicant.UseVisualStyleBackColor = True
    '
    'MskTxtPhone
    '
    Me.MskTxtPhone.Location = New System.Drawing.Point(132, 439)
    Me.MskTxtPhone.Mask = "(999) 000-0000"
    Me.MskTxtPhone.Name = "MskTxtPhone"
    Me.MskTxtPhone.Size = New System.Drawing.Size(81, 20)
    Me.MskTxtPhone.TabIndex = 183
    Me.MskTxtPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'Label23
    '
    Me.Label23.Location = New System.Drawing.Point(234, 420)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(101, 15)
    Me.Label23.TabIndex = 187
    Me.Label23.Text = "Agent Relationship"
    Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'TxtRelate
    '
    Me.TxtRelate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRelate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRelate.Location = New System.Drawing.Point(237, 438)
    Me.TxtRelate.MaxLength = 20
    Me.TxtRelate.Name = "TxtRelate"
    Me.TxtRelate.Size = New System.Drawing.Size(151, 20)
    Me.TxtRelate.TabIndex = 186
    '
    'Label31
    '
    Me.Label31.Location = New System.Drawing.Point(129, 420)
    Me.Label31.Name = "Label31"
    Me.Label31.Size = New System.Drawing.Size(74, 16)
    Me.Label31.TabIndex = 185
    Me.Label31.Text = "Phone No"
    Me.Label31.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label24
    '
    Me.Label24.Location = New System.Drawing.Point(16, 420)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(80, 16)
    Me.Label24.TabIndex = 184
    Me.Label24.Text = "Date Signed"
    Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'DtPckSigned
    '
    Me.DtPckSigned.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckSigned.Location = New System.Drawing.Point(19, 438)
    Me.DtPckSigned.Name = "DtPckSigned"
    Me.DtPckSigned.Size = New System.Drawing.Size(88, 20)
    Me.DtPckSigned.TabIndex = 182
    '
    'MskTxtSSSN
    '
    Me.MskTxtSSSN.Location = New System.Drawing.Point(415, 132)
    Me.MskTxtSSSN.Mask = "000-00-0000"
    Me.MskTxtSSSN.Name = "MskTxtSSSN"
    Me.MskTxtSSSN.Size = New System.Drawing.Size(71, 20)
    Me.MskTxtSSSN.TabIndex = 11
    Me.MskTxtSSSN.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'MskTxtASSN
    '
    Me.MskTxtASSN.Location = New System.Drawing.Point(415, 86)
    Me.MskTxtASSN.Mask = "000-00-0000"
    Me.MskTxtASSN.Name = "MskTxtASSN"
    Me.MskTxtASSN.Size = New System.Drawing.Size(71, 20)
    Me.MskTxtASSN.TabIndex = 6
    Me.MskTxtASSN.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'TxtLoc
    '
    Me.TxtLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
    Me.TxtLoc.Location = New System.Drawing.Point(75, 166)
    Me.TxtLoc.MaxLength = 25
    Me.TxtLoc.Name = "TxtLoc"
    Me.TxtLoc.Size = New System.Drawing.Size(209, 20)
    Me.TxtLoc.TabIndex = 14
    '
    'TxtLocNo
    '
    Me.TxtLocNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocNo.Location = New System.Drawing.Point(11, 167)
    Me.TxtLocNo.MaxLength = 7
    Me.TxtLocNo.Name = "TxtLocNo"
    Me.TxtLocNo.Size = New System.Drawing.Size(62, 20)
    Me.TxtLocNo.TabIndex = 13
    Me.TxtLocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtZip
    '
    Me.TxtZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip.Location = New System.Drawing.Point(572, 168)
    Me.TxtZip.MaxLength = 5
    Me.TxtZip.Name = "TxtZip"
    Me.TxtZip.Size = New System.Drawing.Size(40, 20)
    Me.TxtZip.TabIndex = 17
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(542, 168)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 20)
    Me.TxtState.TabIndex = 16
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(342, 168)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(191, 20)
    Me.TxtCity.TabIndex = 15
    '
    'Label63
    '
    Me.Label63.AutoSize = True
    Me.Label63.Location = New System.Drawing.Point(577, 191)
    Me.Label63.Name = "Label63"
    Me.Label63.Size = New System.Drawing.Size(25, 13)
    Me.Label63.TabIndex = 180
    Me.Label63.Text = "Zip "
    '
    'Label64
    '
    Me.Label64.AutoSize = True
    Me.Label64.Location = New System.Drawing.Point(539, 191)
    Me.Label64.Name = "Label64"
    Me.Label64.Size = New System.Drawing.Size(32, 13)
    Me.Label64.TabIndex = 179
    Me.Label64.Text = "State"
    '
    'Label65
    '
    Me.Label65.AutoSize = True
    Me.Label65.Location = New System.Drawing.Point(339, 191)
    Me.Label65.Name = "Label65"
    Me.Label65.Size = New System.Drawing.Size(66, 13)
    Me.Label65.TabIndex = 178
    Me.Label65.Text = "City or Town"
    '
    'Label66
    '
    Me.Label66.AutoSize = True
    Me.Label66.Location = New System.Drawing.Point(8, 191)
    Me.Label66.Name = "Label66"
    Me.Label66.Size = New System.Drawing.Size(193, 13)
    Me.Label66.TabIndex = 177
    Me.Label66.Text = "Mailing Address (If different from above)"
    '
    'GrpType
    '
    Me.GrpType.Controls.Add(Me.RbRE)
    Me.GrpType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpType.Location = New System.Drawing.Point(15, 3)
    Me.GrpType.Name = "GrpType"
    Me.GrpType.Size = New System.Drawing.Size(125, 38)
    Me.GrpType.TabIndex = 0
    Me.GrpType.TabStop = False
    Me.GrpType.Text = "Bill Type"
    '
    'RbRE
    '
    Me.RbRE.AutoSize = True
    Me.RbRE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbRE.Checked = True
    Me.RbRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbRE.Location = New System.Drawing.Point(12, 16)
    Me.RbRE.Name = "RbRE"
    Me.RbRE.Size = New System.Drawing.Size(80, 17)
    Me.RbRE.TabIndex = 0
    Me.RbRE.TabStop = True
    Me.RbRE.Text = "Real Estate"
    '
    'GroupBox6
    '
    Me.GroupBox6.Controls.Add(Me.TxtSName)
    Me.GroupBox6.Controls.Add(Me.TxtName)
    Me.GroupBox6.Location = New System.Drawing.Point(518, 12)
    Me.GroupBox6.Name = "GroupBox6"
    Me.GroupBox6.Size = New System.Drawing.Size(241, 47)
    Me.GroupBox6.TabIndex = 171
    Me.GroupBox6.TabStop = False
    Me.GroupBox6.Text = "Copy && Paste as needed"
    '
    'TxtSName
    '
    Me.TxtSName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TxtSName.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TxtSName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSName.ForeColor = System.Drawing.Color.Navy
    Me.TxtSName.Location = New System.Drawing.Point(6, 30)
    Me.TxtSName.MaxLength = 20
    Me.TxtSName.Name = "TxtSName"
    Me.TxtSName.ReadOnly = True
    Me.TxtSName.Size = New System.Drawing.Size(228, 13)
    Me.TxtSName.TabIndex = 172
    Me.TxtSName.TabStop = False
    '
    'TxtName
    '
    Me.TxtName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TxtName.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.ForeColor = System.Drawing.Color.Navy
    Me.TxtName.Location = New System.Drawing.Point(6, 16)
    Me.TxtName.MaxLength = 20
    Me.TxtName.Name = "TxtName"
    Me.TxtName.ReadOnly = True
    Me.TxtName.Size = New System.Drawing.Size(228, 13)
    Me.TxtName.TabIndex = 171
    Me.TxtName.TabStop = False
    '
    'TxtSLName
    '
    Me.TxtSLName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSLName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSLName.Location = New System.Drawing.Point(11, 129)
    Me.TxtSLName.MaxLength = 20
    Me.TxtSLName.Name = "TxtSLName"
    Me.TxtSLName.Size = New System.Drawing.Size(228, 20)
    Me.TxtSLName.TabIndex = 8
    '
    'TxtALName
    '
    Me.TxtALName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtALName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtALName.Location = New System.Drawing.Point(11, 86)
    Me.TxtALName.MaxLength = 20
    Me.TxtALName.Name = "TxtALName"
    Me.TxtALName.Size = New System.Drawing.Size(228, 20)
    Me.TxtALName.TabIndex = 3
    '
    'TxtMZip
    '
    Me.TxtMZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMZip.Location = New System.Drawing.Point(572, 207)
    Me.TxtMZip.MaxLength = 5
    Me.TxtMZip.Name = "TxtMZip"
    Me.TxtMZip.Size = New System.Drawing.Size(40, 20)
    Me.TxtMZip.TabIndex = 21
    '
    'TxtMState
    '
    Me.TxtMState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMState.Location = New System.Drawing.Point(542, 207)
    Me.TxtMState.MaxLength = 2
    Me.TxtMState.Name = "TxtMState"
    Me.TxtMState.Size = New System.Drawing.Size(24, 20)
    Me.TxtMState.TabIndex = 20
    '
    'TxtMAddr
    '
    Me.TxtMAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMAddr.Location = New System.Drawing.Point(11, 207)
    Me.TxtMAddr.MaxLength = 40
    Me.TxtMAddr.Name = "TxtMAddr"
    Me.TxtMAddr.Size = New System.Drawing.Size(325, 20)
    Me.TxtMAddr.TabIndex = 18
    '
    'TxtMCity
    '
    Me.TxtMCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMCity.Location = New System.Drawing.Point(342, 207)
    Me.TxtMCity.MaxLength = 25
    Me.TxtMCity.Name = "TxtMCity"
    Me.TxtMCity.Size = New System.Drawing.Size(191, 20)
    Me.TxtMCity.TabIndex = 19
    '
    'Label17
    '
    Me.Label17.AutoSize = True
    Me.Label17.Location = New System.Drawing.Point(577, 152)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(25, 13)
    Me.Label17.TabIndex = 155
    Me.Label17.Text = "Zip "
    '
    'Label16
    '
    Me.Label16.AutoSize = True
    Me.Label16.Location = New System.Drawing.Point(539, 152)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(32, 13)
    Me.Label16.TabIndex = 154
    Me.Label16.Text = "State"
    '
    'Label14
    '
    Me.Label14.AutoSize = True
    Me.Label14.Location = New System.Drawing.Point(339, 152)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(66, 13)
    Me.Label14.TabIndex = 153
    Me.Label14.Text = "City or Town"
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(8, 152)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(102, 13)
    Me.Label12.TabIndex = 152
    Me.Label12.Text = "3. Property Location"
    '
    'Label11
    '
    Me.Label11.Location = New System.Drawing.Point(403, 113)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(101, 16)
    Me.Label11.TabIndex = 151
    Me.Label11.Text = "Social Security No"
    Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(403, 70)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(101, 13)
    Me.Label10.TabIndex = 150
    Me.Label10.Text = "Social Security No"
    Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(349, 110)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(44, 13)
    Me.Label5.TabIndex = 147
    Me.Label5.Text = "(Middle)"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(244, 110)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(32, 13)
    Me.Label6.TabIndex = 146
    Me.Label6.Text = "(First)"
    '
    'TxtSFName
    '
    Me.TxtSFName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSFName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSFName.Location = New System.Drawing.Point(245, 129)
    Me.TxtSFName.MaxLength = 10
    Me.TxtSFName.Name = "TxtSFName"
    Me.TxtSFName.Size = New System.Drawing.Size(114, 20)
    Me.TxtSFName.TabIndex = 9
    '
    'TxtSInit
    '
    Me.TxtSInit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSInit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSInit.Location = New System.Drawing.Point(365, 129)
    Me.TxtSInit.MaxLength = 35
    Me.TxtSInit.Name = "TxtSInit"
    Me.TxtSInit.Size = New System.Drawing.Size(17, 20)
    Me.TxtSInit.TabIndex = 10
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(8, 113)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(122, 13)
    Me.Label7.TabIndex = 145
    Me.Label7.Text = "2. Spouse's Name (Last)"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(349, 69)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(44, 13)
    Me.Label4.TabIndex = 144
    Me.Label4.Text = "(Middle)"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(244, 50)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(32, 13)
    Me.Label2.TabIndex = 143
    Me.Label2.Text = "(First)"
    '
    'TxtAFName
    '
    Me.TxtAFName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAFName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAFName.Location = New System.Drawing.Point(245, 86)
    Me.TxtAFName.MaxLength = 10
    Me.TxtAFName.Name = "TxtAFName"
    Me.TxtAFName.Size = New System.Drawing.Size(114, 20)
    Me.TxtAFName.TabIndex = 4
    '
    'TxtAInit
    '
    Me.TxtAInit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAInit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAInit.Location = New System.Drawing.Point(365, 86)
    Me.TxtAInit.MaxLength = 35
    Me.TxtAInit.Name = "TxtAInit"
    Me.TxtAInit.Size = New System.Drawing.Size(17, 20)
    Me.TxtAInit.TabIndex = 5
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(8, 70)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(76, 13)
    Me.Label1.TabIndex = 142
    Me.Label1.Text = "1. Name (Last)"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.Label59)
    Me.GroupBox1.Controls.Add(Me.Label35)
    Me.GroupBox1.Controls.Add(Me.Label25)
    Me.GroupBox1.Controls.Add(Me.Label55)
    Me.GroupBox1.Controls.Add(Me.Label48)
    Me.GroupBox1.Controls.Add(Me.LblTotal)
    Me.GroupBox1.Controls.Add(Me.Label21)
    Me.GroupBox1.Controls.Add(Me.TxtOther)
    Me.GroupBox1.Controls.Add(Me.Label20)
    Me.GroupBox1.Controls.Add(Me.TxtSSA)
    Me.GroupBox1.Controls.Add(Me.Label15)
    Me.GroupBox1.Controls.Add(Me.TxtIncome)
    Me.GroupBox1.Controls.Add(Me.Label19)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(9, 242)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(752, 167)
    Me.GroupBox1.TabIndex = 23
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Qualifying Income (Income from All Sources for Last Calendar Year)"
    '
    'Label59
    '
    Me.Label59.AutoSize = True
    Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label59.Location = New System.Drawing.Point(18, 60)
    Me.Label59.Name = "Label59"
    Me.Label59.Size = New System.Drawing.Size(399, 13)
    Me.Label59.TabIndex = 60
    Me.Label59.Text = "Adjusted Gross Income plus any other income and attach a copy to this application" &
    "."
    '
    'Label35
    '
    Me.Label35.AutoSize = True
    Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label35.Location = New System.Drawing.Point(18, 47)
    Me.Label35.Name = "Label35"
    Me.Label35.Size = New System.Drawing.Size(533, 13)
    Me.Label35.TabIndex = 59
    Me.Label35.Text = "Rent or proceeds from sales of property, etc. If you are required to file a Feder" &
    "al Tax Return, enter the amount of"
    '
    'Label25
    '
    Me.Label25.AutoSize = True
    Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label25.Location = New System.Drawing.Point(18, 34)
    Me.Label25.Name = "Label25"
    Me.Label25.Size = New System.Drawing.Size(667, 13)
    Me.Label25.TabIndex = 58
    Me.Label25.Text = "(Excluding travel allowance), Lottery winnings, Taxable portion of Annunities and" &
    " Pensions, Taxable portion of IRA's, Interest, Dividends, Net"
    '
    'Label55
    '
    Me.Label55.AutoSize = True
    Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label55.Location = New System.Drawing.Point(17, 138)
    Me.Label55.Name = "Label55"
    Me.Label55.Size = New System.Drawing.Size(85, 13)
    Me.Label55.TabIndex = 54
    Me.Label55.Text = "not listed above."
    '
    'Label48
    '
    Me.Label48.AutoSize = True
    Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label48.Location = New System.Drawing.Point(17, 124)
    Me.Label48.Name = "Label48"
    Me.Label48.Size = New System.Drawing.Size(441, 13)
    Me.Label48.TabIndex = 53
    Me.Label48.Text = "State of Connecticut public assistance payments, General Assistance, and any othe" &
    "r income"
    '
    'LblTotal
    '
    Me.LblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotal.Location = New System.Drawing.Point(672, 138)
    Me.LblTotal.Name = "LblTotal"
    Me.LblTotal.Size = New System.Drawing.Size(64, 18)
    Me.LblTotal.TabIndex = 52
    Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label21
    '
    Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label21.Location = New System.Drawing.Point(585, 138)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(81, 13)
    Me.Label21.TabIndex = 50
    Me.Label21.Text = "TOTAL "
    Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'TxtOther
    '
    Me.TxtOther.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOther.Location = New System.Drawing.Point(672, 108)
    Me.TxtOther.MaxLength = 11
    Me.TxtOther.Name = "TxtOther"
    Me.TxtOther.Size = New System.Drawing.Size(66, 20)
    Me.TxtOther.TabIndex = 48
    Me.TxtOther.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label20
    '
    Me.Label20.AutoSize = True
    Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label20.Location = New System.Drawing.Point(6, 108)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(501, 13)
    Me.Label20.TabIndex = 49
    Me.Label20.Text = "C: ANY INCOME NOT REFLECTED IN THE ABOVE - Examples: Federal Supplemental Securit" &
    "y Income,"
    '
    'TxtSSA
    '
    Me.TxtSSA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSSA.Location = New System.Drawing.Point(672, 82)
    Me.TxtSSA.MaxLength = 11
    Me.TxtSSA.Name = "TxtSSA"
    Me.TxtSSA.Size = New System.Drawing.Size(66, 20)
    Me.TxtSSA.TabIndex = 46
    Me.TxtSSA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label15
    '
    Me.Label15.AutoSize = True
    Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label15.Location = New System.Drawing.Point(7, 79)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(193, 13)
    Me.Label15.TabIndex = 47
    Me.Label15.Text = "B: SOCIAL SECURITY  (Gross Amount)"
    '
    'TxtIncome
    '
    Me.TxtIncome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtIncome.Location = New System.Drawing.Point(672, 56)
    Me.TxtIncome.MaxLength = 11
    Me.TxtIncome.Name = "TxtIncome"
    Me.TxtIncome.Size = New System.Drawing.Size(66, 20)
    Me.TxtIncome.TabIndex = 0
    Me.TxtIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label19
    '
    Me.Label19.AutoSize = True
    Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label19.Location = New System.Drawing.Point(7, 21)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(496, 13)
    Me.Label19.TabIndex = 43
    Me.Label19.Text = "A. GROSS INCOME - Examples: Wages, Bonuses, Commissions, Fees, Gratuties, Payment" &
    " for Jury Duty"
    '
    'LnkListNo
    '
    Me.LnkListNo.Location = New System.Drawing.Point(315, 32)
    Me.LnkListNo.Name = "LnkListNo"
    Me.LnkListNo.Size = New System.Drawing.Size(44, 13)
    Me.LnkListNo.TabIndex = 141
    Me.LnkListNo.TabStop = True
    Me.LnkListNo.Text = "List No"
    '
    'TxtYear
    '
    Me.TxtYear.Location = New System.Drawing.Point(472, 28)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtYear.TabIndex = 2
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(431, 28)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(35, 17)
    Me.Label13.TabIndex = 140
    Me.Label13.Text = "Year"
    '
    'TxtListNo
    '
    Me.TxtListNo.Location = New System.Drawing.Point(369, 28)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(62, 20)
    Me.TxtListNo.TabIndex = 1
    '
    'TpAssessor
    '
    Me.TpAssessor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.TpAssessor.Controls.Add(Me.Label69)
    Me.TpAssessor.Controls.Add(Me.LblLocal)
    Me.TpAssessor.Controls.Add(Me.Label73)
    Me.TpAssessor.Controls.Add(Me.BtnRecalc)
    Me.TpAssessor.Controls.Add(Me.Label72)
    Me.TpAssessor.Controls.Add(Me.LblNet)
    Me.TpAssessor.Controls.Add(Me.Label70)
    Me.TpAssessor.Controls.Add(Me.LblXVet)
    Me.TpAssessor.Controls.Add(Me.Label68)
    Me.TpAssessor.Controls.Add(Me.Label67)
    Me.TpAssessor.Controls.Add(Me.Label58)
    Me.TpAssessor.Controls.Add(Me.Label62)
    Me.TpAssessor.Controls.Add(Me.LblAddlTax)
    Me.TpAssessor.Controls.Add(Me.Label33)
    Me.TpAssessor.Controls.Add(Me.TxtPropPct)
    Me.TpAssessor.Controls.Add(Me.Label37)
    Me.TpAssessor.Controls.Add(Me.Label3)
    Me.TpAssessor.Controls.Add(Me.LblPropTax)
    Me.TpAssessor.Controls.Add(Me.LblTaxDue)
    Me.TpAssessor.Controls.Add(Me.Label61)
    Me.TpAssessor.Controls.Add(Me.Label60)
    Me.TpAssessor.Controls.Add(Me.LblTotTax)
    Me.TpAssessor.Controls.Add(Me.LblDeferred)
    Me.TpAssessor.Controls.Add(Me.Label51)
    Me.TpAssessor.Controls.Add(Me.LblStBenefit)
    Me.TpAssessor.Controls.Add(Me.Label32)
    Me.TpAssessor.Controls.Add(Me.LblGross)
    Me.TpAssessor.Controls.Add(Me.Label9)
    Me.TpAssessor.Controls.Add(Me.LblAppGross)
    Me.TpAssessor.Controls.Add(Me.Label18)
    Me.TpAssessor.Controls.Add(Me.LblMillRate)
    Me.TpAssessor.Controls.Add(Me.Label8)
    Me.TpAssessor.Controls.Add(Me.LblTypeDesc)
    Me.TpAssessor.Controls.Add(Me.Label26)
    Me.TpAssessor.Controls.Add(Me.DtPckAssr)
    Me.TpAssessor.Controls.Add(Me.Label54)
    Me.TpAssessor.Controls.Add(Me.LblAInit)
    Me.TpAssessor.Controls.Add(Me.LblAFName)
    Me.TpAssessor.Controls.Add(Me.LblALName)
    Me.TpAssessor.Controls.Add(Me.LblYear)
    Me.TpAssessor.Controls.Add(Me.LblListNo)
    Me.TpAssessor.Controls.Add(Me.GroupBox5)
    Me.TpAssessor.Controls.Add(Me.Label30)
    Me.TpAssessor.Controls.Add(Me.Label22)
    Me.TpAssessor.Controls.Add(Me.Label27)
    Me.TpAssessor.Controls.Add(Me.Label28)
    Me.TpAssessor.Controls.Add(Me.Label29)
    Me.TpAssessor.ImageIndex = 0
    Me.TpAssessor.Location = New System.Drawing.Point(4, 23)
    Me.TpAssessor.Name = "TpAssessor"
    Me.TpAssessor.Padding = New System.Windows.Forms.Padding(3)
    Me.TpAssessor.Size = New System.Drawing.Size(763, 596)
    Me.TpAssessor.TabIndex = 1
    Me.TpAssessor.Text = "Assessor"
    Me.TpAssessor.UseVisualStyleBackColor = True
    '
    'BtnRecalc
    '
    Me.BtnRecalc.Location = New System.Drawing.Point(462, 25)
    Me.BtnRecalc.Name = "BtnRecalc"
    Me.BtnRecalc.Size = New System.Drawing.Size(54, 23)
    Me.BtnRecalc.TabIndex = 228
    Me.BtnRecalc.Text = "Recalc"
    Me.BtnRecalc.UseVisualStyleBackColor = True
    '
    'Label72
    '
    Me.Label72.AutoSize = True
    Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label72.Location = New System.Drawing.Point(522, 79)
    Me.Label72.Name = "Label72"
    Me.Label72.Size = New System.Drawing.Size(71, 13)
    Me.Label72.TabIndex = 227
    Me.Label72.Text = "Applicant Net"
    '
    'LblNet
    '
    Me.LblNet.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNet.Location = New System.Drawing.Point(675, 76)
    Me.LblNet.Name = "LblNet"
    Me.LblNet.Size = New System.Drawing.Size(66, 18)
    Me.LblNet.TabIndex = 226
    Me.LblNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label70
    '
    Me.Label70.AutoSize = True
    Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label70.Location = New System.Drawing.Point(522, 55)
    Me.Label70.Name = "Label70"
    Me.Label70.Size = New System.Drawing.Size(106, 13)
    Me.Label70.TabIndex = 225
    Me.Label70.Text = "Veterans Exemptions"
    '
    'LblXVet
    '
    Me.LblXVet.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblXVet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblXVet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblXVet.Location = New System.Drawing.Point(675, 52)
    Me.LblXVet.Name = "LblXVet"
    Me.LblXVet.Size = New System.Drawing.Size(66, 18)
    Me.LblXVet.TabIndex = 224
    Me.LblXVet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label68
    '
    Me.Label68.AutoSize = True
    Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label68.Location = New System.Drawing.Point(659, 246)
    Me.Label68.Name = "Label68"
    Me.Label68.Size = New System.Drawing.Size(16, 17)
    Me.Label68.TabIndex = 223
    Me.Label68.Text = "="
    '
    'Label67
    '
    Me.Label67.AutoSize = True
    Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label67.Location = New System.Drawing.Point(659, 209)
    Me.Label67.Name = "Label67"
    Me.Label67.Size = New System.Drawing.Size(16, 17)
    Me.Label67.TabIndex = 222
    Me.Label67.Text = "+"
    '
    'Label58
    '
    Me.Label58.AutoSize = True
    Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label58.Location = New System.Drawing.Point(659, 191)
    Me.Label58.Name = "Label58"
    Me.Label58.Size = New System.Drawing.Size(13, 17)
    Me.Label58.TabIndex = 221
    Me.Label58.Text = "-"
    '
    'Label62
    '
    Me.Label62.AutoSize = True
    Me.Label62.Location = New System.Drawing.Point(522, 209)
    Me.Label62.Name = "Label62"
    Me.Label62.Size = New System.Drawing.Size(74, 13)
    Me.Label62.TabIndex = 220
    Me.Label62.Text = "Additional Tax"
    '
    'LblAddlTax
    '
    Me.LblAddlTax.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAddlTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAddlTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAddlTax.Location = New System.Drawing.Point(675, 206)
    Me.LblAddlTax.Name = "LblAddlTax"
    Me.LblAddlTax.Size = New System.Drawing.Size(66, 18)
    Me.LblAddlTax.TabIndex = 219
    Me.LblAddlTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label33
    '
    Me.Label33.Location = New System.Drawing.Point(304, 100)
    Me.Label33.Name = "Label33"
    Me.Label33.Size = New System.Drawing.Size(23, 20)
    Me.Label33.TabIndex = 218
    Me.Label33.Text = "%"
    '
    'TxtPropPct
    '
    Me.TxtPropPct.Location = New System.Drawing.Point(256, 97)
    Me.TxtPropPct.MaxLength = 6
    Me.TxtPropPct.Name = "TxtPropPct"
    Me.TxtPropPct.Size = New System.Drawing.Size(47, 20)
    Me.TxtPropPct.TabIndex = 216
    Me.TxtPropPct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label37
    '
    Me.Label37.AutoSize = True
    Me.Label37.Location = New System.Drawing.Point(13, 100)
    Me.Label37.Name = "Label37"
    Me.Label37.Size = New System.Drawing.Size(237, 13)
    Me.Label37.TabIndex = 217
    Me.Label37.Text = "Total Percentage of property owned by applicant"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(522, 117)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(67, 13)
    Me.Label3.TabIndex = 215
    Me.Label3.Text = "Property Tax"
    '
    'LblPropTax
    '
    Me.LblPropTax.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPropTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPropTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPropTax.Location = New System.Drawing.Point(675, 112)
    Me.LblPropTax.Name = "LblPropTax"
    Me.LblPropTax.Size = New System.Drawing.Size(66, 18)
    Me.LblPropTax.TabIndex = 214
    Me.LblPropTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTaxDue
    '
    Me.LblTaxDue.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTaxDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTaxDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTaxDue.Location = New System.Drawing.Point(675, 243)
    Me.LblTaxDue.Name = "LblTaxDue"
    Me.LblTaxDue.Size = New System.Drawing.Size(66, 18)
    Me.LblTaxDue.TabIndex = 213
    Me.LblTaxDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label61
    '
    Me.Label61.AutoSize = True
    Me.Label61.Location = New System.Drawing.Point(522, 248)
    Me.Label61.Name = "Label61"
    Me.Label61.Size = New System.Drawing.Size(48, 13)
    Me.Label61.TabIndex = 212
    Me.Label61.Text = "Tax Due"
    '
    'Label60
    '
    Me.Label60.AutoSize = True
    Me.Label60.Location = New System.Drawing.Point(522, 175)
    Me.Label60.Name = "Label60"
    Me.Label60.Size = New System.Drawing.Size(52, 13)
    Me.Label60.TabIndex = 211
    Me.Label60.Text = "Total Tax"
    '
    'LblTotTax
    '
    Me.LblTotTax.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTotTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotTax.Location = New System.Drawing.Point(675, 170)
    Me.LblTotTax.Name = "LblTotTax"
    Me.LblTotTax.Size = New System.Drawing.Size(66, 18)
    Me.LblTotTax.TabIndex = 210
    Me.LblTotTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblDeferred
    '
    Me.LblDeferred.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblDeferred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblDeferred.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDeferred.Location = New System.Drawing.Point(675, 188)
    Me.LblDeferred.Name = "LblDeferred"
    Me.LblDeferred.Size = New System.Drawing.Size(66, 18)
    Me.LblDeferred.TabIndex = 209
    Me.LblDeferred.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label51
    '
    Me.Label51.AutoSize = True
    Me.Label51.Location = New System.Drawing.Point(522, 193)
    Me.Label51.Name = "Label51"
    Me.Label51.Size = New System.Drawing.Size(87, 13)
    Me.Label51.TabIndex = 208
    Me.Label51.Text = "Deferred Amount"
    '
    'LblStBenefit
    '
    Me.LblStBenefit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblStBenefit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblStBenefit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblStBenefit.Location = New System.Drawing.Point(675, 140)
    Me.LblStBenefit.Name = "LblStBenefit"
    Me.LblStBenefit.Size = New System.Drawing.Size(66, 18)
    Me.LblStBenefit.TabIndex = 207
    Me.LblStBenefit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label32
    '
    Me.Label32.AutoSize = True
    Me.Label32.Location = New System.Drawing.Point(522, 145)
    Me.Label32.Name = "Label32"
    Me.Label32.Size = New System.Drawing.Size(68, 13)
    Me.Label32.TabIndex = 206
    Me.Label32.Text = "State Benefit"
    '
    'LblGross
    '
    Me.LblGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblGross.Location = New System.Drawing.Point(675, 18)
    Me.LblGross.Name = "LblGross"
    Me.LblGross.Size = New System.Drawing.Size(66, 18)
    Me.LblGross.TabIndex = 204
    Me.LblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(522, 23)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(93, 13)
    Me.Label9.TabIndex = 203
    Me.Label9.Text = "Gross Assessment"
    '
    'LblAppGross
    '
    Me.LblAppGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAppGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAppGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAppGross.Location = New System.Drawing.Point(675, 36)
    Me.LblAppGross.Name = "LblAppGross"
    Me.LblAppGross.Size = New System.Drawing.Size(66, 18)
    Me.LblAppGross.TabIndex = 202
    Me.LblAppGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label18
    '
    Me.Label18.AutoSize = True
    Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label18.Location = New System.Drawing.Point(522, 39)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(140, 13)
    Me.Label18.TabIndex = 201
    Me.Label18.Text = "Applicant Gross Assessment"
    '
    'LblMillRate
    '
    Me.LblMillRate.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblMillRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblMillRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMillRate.Location = New System.Drawing.Point(675, 94)
    Me.LblMillRate.Name = "LblMillRate"
    Me.LblMillRate.Size = New System.Drawing.Size(66, 18)
    Me.LblMillRate.TabIndex = 199
    Me.LblMillRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(522, 97)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(48, 13)
    Me.Label8.TabIndex = 197
    Me.Label8.Text = "Mill Rate"
    '
    'LblTypeDesc
    '
    Me.LblTypeDesc.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTypeDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTypeDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTypeDesc.Location = New System.Drawing.Point(50, 22)
    Me.LblTypeDesc.Name = "LblTypeDesc"
    Me.LblTypeDesc.Size = New System.Drawing.Size(134, 18)
    Me.LblTypeDesc.TabIndex = 195
    Me.LblTypeDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label26
    '
    Me.Label26.AutoSize = True
    Me.Label26.Location = New System.Drawing.Point(13, 23)
    Me.Label26.Name = "Label26"
    Me.Label26.Size = New System.Drawing.Size(31, 13)
    Me.Label26.TabIndex = 196
    Me.Label26.Text = "Type"
    '
    'DtPckAssr
    '
    Me.DtPckAssr.Checked = False
    Me.DtPckAssr.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckAssr.Location = New System.Drawing.Point(149, 269)
    Me.DtPckAssr.Name = "DtPckAssr"
    Me.DtPckAssr.ShowCheckBox = True
    Me.DtPckAssr.Size = New System.Drawing.Size(100, 20)
    Me.DtPckAssr.TabIndex = 5
    '
    'Label54
    '
    Me.Label54.Location = New System.Drawing.Point(19, 273)
    Me.Label54.Name = "Label54"
    Me.Label54.Size = New System.Drawing.Size(124, 16)
    Me.Label54.TabIndex = 180
    Me.Label54.Text = "Date Assessor Signed"
    '
    'LblAInit
    '
    Me.LblAInit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAInit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAInit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAInit.Location = New System.Drawing.Point(368, 67)
    Me.LblAInit.Name = "LblAInit"
    Me.LblAInit.Size = New System.Drawing.Size(15, 18)
    Me.LblAInit.TabIndex = 174
    Me.LblAInit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblAFName
    '
    Me.LblAFName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAFName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAFName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAFName.Location = New System.Drawing.Point(248, 67)
    Me.LblAFName.Name = "LblAFName"
    Me.LblAFName.Size = New System.Drawing.Size(114, 18)
    Me.LblAFName.TabIndex = 173
    Me.LblAFName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblALName
    '
    Me.LblALName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblALName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblALName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblALName.Location = New System.Drawing.Point(14, 67)
    Me.LblALName.Name = "LblALName"
    Me.LblALName.Size = New System.Drawing.Size(228, 18)
    Me.LblALName.TabIndex = 2
    Me.LblALName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblYear.Location = New System.Drawing.Point(352, 23)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(33, 18)
    Me.LblYear.TabIndex = 1
    Me.LblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblListNo
    '
    Me.LblListNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblListNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblListNo.Location = New System.Drawing.Point(247, 22)
    Me.LblListNo.Name = "LblListNo"
    Me.LblListNo.Size = New System.Drawing.Size(56, 18)
    Me.LblListNo.TabIndex = 0
    Me.LblListNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.TxtDisallowReason)
    Me.GroupBox5.Controls.Add(Me.RbDisallowed)
    Me.GroupBox5.Controls.Add(Me.RbAllowed)
    Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox5.Location = New System.Drawing.Point(14, 195)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(479, 66)
    Me.GroupBox5.TabIndex = 4
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "Assessor Affidavit"
    '
    'TxtDisallowReason
    '
    Me.TxtDisallowReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDisallowReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDisallowReason.Location = New System.Drawing.Point(270, 40)
    Me.TxtDisallowReason.MaxLength = 30
    Me.TxtDisallowReason.Name = "TxtDisallowReason"
    Me.TxtDisallowReason.Size = New System.Drawing.Size(180, 20)
    Me.TxtDisallowReason.TabIndex = 0
    '
    'RbDisallowed
    '
    Me.RbDisallowed.AutoSize = True
    Me.RbDisallowed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbDisallowed.Location = New System.Drawing.Point(8, 40)
    Me.RbDisallowed.Name = "RbDisallowed"
    Me.RbDisallowed.Size = New System.Drawing.Size(246, 17)
    Me.RbDisallowed.TabIndex = 2
    Me.RbDisallowed.Text = "This claim is disallowed for the following reason"
    '
    'RbAllowed
    '
    Me.RbAllowed.AutoSize = True
    Me.RbAllowed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbAllowed.Location = New System.Drawing.Point(8, 16)
    Me.RbAllowed.Name = "RbAllowed"
    Me.RbAllowed.Size = New System.Drawing.Size(442, 17)
    Me.RbAllowed.TabIndex = 0
    Me.RbAllowed.Text = "I am satified that the above name applicant meet all the necessary statutory requ" &
    "irements"
    '
    'Label30
    '
    Me.Label30.AutoSize = True
    Me.Label30.Location = New System.Drawing.Point(201, 25)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(40, 13)
    Me.Label30.TabIndex = 155
    Me.Label30.Text = "List No"
    '
    'Label22
    '
    Me.Label22.AutoSize = True
    Me.Label22.Location = New System.Drawing.Point(349, 54)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(44, 13)
    Me.Label22.TabIndex = 154
    Me.Label22.Text = "(Middle)"
    '
    'Label27
    '
    Me.Label27.AutoSize = True
    Me.Label27.Location = New System.Drawing.Point(244, 54)
    Me.Label27.Name = "Label27"
    Me.Label27.Size = New System.Drawing.Size(32, 13)
    Me.Label27.TabIndex = 153
    Me.Label27.Text = "(First)"
    '
    'Label28
    '
    Me.Label28.AutoSize = True
    Me.Label28.Location = New System.Drawing.Point(11, 54)
    Me.Label28.Name = "Label28"
    Me.Label28.Size = New System.Drawing.Size(64, 13)
    Me.Label28.TabIndex = 152
    Me.Label28.Text = "Name (Last)"
    '
    'Label29
    '
    Me.Label29.AutoSize = True
    Me.Label29.Location = New System.Drawing.Point(315, 24)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(29, 13)
    Me.Label29.TabIndex = 150
    Me.Label29.Text = "Year"
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "scroll.ico")
    '
    'Label34
    '
    Me.Label34.AutoSize = True
    Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label34.Location = New System.Drawing.Point(19, 123)
    Me.Label34.Name = "Label34"
    Me.Label34.Size = New System.Drawing.Size(163, 13)
    Me.Label34.TabIndex = 206
    Me.Label34.Text = "11. Additional Exemption Allowed"
    '
    'Label36
    '
    Me.Label36.AutoSize = True
    Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label36.Location = New System.Drawing.Point(19, 101)
    Me.Label36.Name = "Label36"
    Me.Label36.Size = New System.Drawing.Size(107, 13)
    Me.Label36.TabIndex = 205
    Me.Label36.Text = "10. Qualfying Income"
    '
    'CheckBox2
    '
    Me.CheckBox2.AutoSize = True
    Me.CheckBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.CheckBox2.Location = New System.Drawing.Point(19, 81)
    Me.CheckBox2.Name = "CheckBox2"
    Me.CheckBox2.Size = New System.Drawing.Size(263, 17)
    Me.CheckBox2.TabIndex = 204
    Me.CheckBox2.Text = "9. Indicate Income Level: Disabled Income Level?"
    Me.CheckBox2.UseVisualStyleBackColor = True
    '
    'Label38
    '
    Me.Label38.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label38.Location = New System.Drawing.Point(325, 101)
    Me.Label38.Name = "Label38"
    Me.Label38.Size = New System.Drawing.Size(66, 18)
    Me.Label38.TabIndex = 202
    Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TextBox1
    '
    Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox1.Location = New System.Drawing.Point(325, 123)
    Me.TextBox1.MaxLength = 8
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(66, 20)
    Me.TextBox1.TabIndex = 200
    Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label39
    '
    Me.Label39.AutoSize = True
    Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label39.Location = New System.Drawing.Point(19, 65)
    Me.Label39.Name = "Label39"
    Me.Label39.Size = New System.Drawing.Size(300, 13)
    Me.Label39.TabIndex = 199
    Me.Label39.Text = "8. The Applicant is receiving the following veteran's exemption"
    '
    'Label40
    '
    Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label40.Location = New System.Drawing.Point(15, 175)
    Me.Label40.Name = "Label40"
    Me.Label40.Size = New System.Drawing.Size(141, 20)
    Me.Label40.TabIndex = 198
    Me.Label40.Text = "11. Net Assessment"
    Me.Label40.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'TextBox2
    '
    Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox2.Location = New System.Drawing.Point(325, 62)
    Me.TextBox2.MaxLength = 8
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(66, 20)
    Me.TextBox2.TabIndex = 197
    Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label41
    '
    Me.Label41.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label41.Location = New System.Drawing.Point(50, 22)
    Me.Label41.Name = "Label41"
    Me.Label41.Size = New System.Drawing.Size(134, 18)
    Me.Label41.TabIndex = 195
    Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label42
    '
    Me.Label42.AutoSize = True
    Me.Label42.Location = New System.Drawing.Point(13, 23)
    Me.Label42.Name = "Label42"
    Me.Label42.Size = New System.Drawing.Size(31, 13)
    Me.Label42.TabIndex = 196
    Me.Label42.Text = "Type"
    '
    'DateTimePicker1
    '
    Me.DateTimePicker1.Checked = False
    Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DateTimePicker1.Location = New System.Drawing.Point(154, 460)
    Me.DateTimePicker1.Name = "DateTimePicker1"
    Me.DateTimePicker1.ShowCheckBox = True
    Me.DateTimePicker1.Size = New System.Drawing.Size(100, 20)
    Me.DateTimePicker1.TabIndex = 181
    '
    'Label43
    '
    Me.Label43.Location = New System.Drawing.Point(24, 464)
    Me.Label43.Name = "Label43"
    Me.Label43.Size = New System.Drawing.Size(124, 16)
    Me.Label43.TabIndex = 180
    Me.Label43.Text = "Date Assessor Signed"
    '
    'Label44
    '
    Me.Label44.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label44.Location = New System.Drawing.Point(772, 23)
    Me.Label44.Name = "Label44"
    Me.Label44.Size = New System.Drawing.Size(15, 18)
    Me.Label44.TabIndex = 174
    Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label45
    '
    Me.Label45.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label45.Location = New System.Drawing.Point(652, 23)
    Me.Label45.Name = "Label45"
    Me.Label45.Size = New System.Drawing.Size(114, 18)
    Me.Label45.TabIndex = 173
    Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label46
    '
    Me.Label46.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label46.Location = New System.Drawing.Point(418, 23)
    Me.Label46.Name = "Label46"
    Me.Label46.Size = New System.Drawing.Size(228, 18)
    Me.Label46.TabIndex = 2
    Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label47
    '
    Me.Label47.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label47.Location = New System.Drawing.Point(352, 23)
    Me.Label47.Name = "Label47"
    Me.Label47.Size = New System.Drawing.Size(33, 18)
    Me.Label47.TabIndex = 1
    Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label49
    '
    Me.Label49.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label49.Location = New System.Drawing.Point(247, 22)
    Me.Label49.Name = "Label49"
    Me.Label49.Size = New System.Drawing.Size(56, 18)
    Me.Label49.TabIndex = 0
    Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.TextBox3)
    Me.GroupBox2.Controls.Add(Me.RadioButton1)
    Me.GroupBox2.Controls.Add(Me.RadioButton2)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(19, 386)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(479, 66)
    Me.GroupBox2.TabIndex = 8
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Assessor Affidavit"
    '
    'TextBox3
    '
    Me.TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox3.Location = New System.Drawing.Point(270, 40)
    Me.TextBox3.MaxLength = 30
    Me.TextBox3.Name = "TextBox3"
    Me.TextBox3.Size = New System.Drawing.Size(180, 20)
    Me.TextBox3.TabIndex = 167
    '
    'RadioButton1
    '
    Me.RadioButton1.AutoSize = True
    Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RadioButton1.Location = New System.Drawing.Point(8, 40)
    Me.RadioButton1.Name = "RadioButton1"
    Me.RadioButton1.Size = New System.Drawing.Size(246, 17)
    Me.RadioButton1.TabIndex = 2
    Me.RadioButton1.Text = "This claim is disallowed for the following reason"
    '
    'RadioButton2
    '
    Me.RadioButton2.AutoSize = True
    Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RadioButton2.Location = New System.Drawing.Point(8, 16)
    Me.RadioButton2.Name = "RadioButton2"
    Me.RadioButton2.Size = New System.Drawing.Size(442, 17)
    Me.RadioButton2.TabIndex = 0
    Me.RadioButton2.Text = "I am satified that the above name applicant meet all the necessary statutory requ" &
    "irements"
    '
    'Label50
    '
    Me.Label50.AutoSize = True
    Me.Label50.Location = New System.Drawing.Point(201, 25)
    Me.Label50.Name = "Label50"
    Me.Label50.Size = New System.Drawing.Size(40, 13)
    Me.Label50.TabIndex = 155
    Me.Label50.Text = "List No"
    '
    'Label52
    '
    Me.Label52.AutoSize = True
    Me.Label52.Location = New System.Drawing.Point(756, -1)
    Me.Label52.Name = "Label52"
    Me.Label52.Size = New System.Drawing.Size(44, 13)
    Me.Label52.TabIndex = 154
    Me.Label52.Text = "(Middle)"
    '
    'Label53
    '
    Me.Label53.AutoSize = True
    Me.Label53.Location = New System.Drawing.Point(651, -1)
    Me.Label53.Name = "Label53"
    Me.Label53.Size = New System.Drawing.Size(32, 13)
    Me.Label53.TabIndex = 153
    Me.Label53.Text = "(First)"
    '
    'Label56
    '
    Me.Label56.AutoSize = True
    Me.Label56.Location = New System.Drawing.Point(415, 2)
    Me.Label56.Name = "Label56"
    Me.Label56.Size = New System.Drawing.Size(64, 13)
    Me.Label56.TabIndex = 152
    Me.Label56.Text = "Name (Last)"
    '
    'Label57
    '
    Me.Label57.AutoSize = True
    Me.Label57.Location = New System.Drawing.Point(315, 24)
    Me.Label57.Name = "Label57"
    Me.Label57.Size = New System.Drawing.Size(29, 13)
    Me.Label57.TabIndex = 150
    Me.Label57.Text = "Year"
    '
    'Label69
    '
    Me.Label69.AutoSize = True
    Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label69.Location = New System.Drawing.Point(659, 227)
    Me.Label69.Name = "Label69"
    Me.Label69.Size = New System.Drawing.Size(13, 17)
    Me.Label69.TabIndex = 231
    Me.Label69.Text = "-"
    '
    'LblLocal
    '
    Me.LblLocal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocal.Location = New System.Drawing.Point(675, 224)
    Me.LblLocal.Name = "LblLocal"
    Me.LblLocal.Size = New System.Drawing.Size(66, 18)
    Me.LblLocal.TabIndex = 230
    Me.LblLocal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label73
    '
    Me.Label73.AutoSize = True
    Me.Label73.Location = New System.Drawing.Point(522, 229)
    Me.Label73.Name = "Label73"
    Me.Label73.Size = New System.Drawing.Size(69, 13)
    Me.Label73.TabIndex = 229
    Me.Label73.Text = "Local Benefit"
    '
    'FrmTO220C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(770, 495)
    Me.Controls.Add(Me.Tab1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTO220C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Tab1.ResumeLayout(False)
    Me.TpApplicant.ResumeLayout(False)
    Me.TpApplicant.PerformLayout()
    Me.GrpType.ResumeLayout(False)
    Me.GrpType.PerformLayout()
    Me.GroupBox6.ResumeLayout(False)
    Me.GroupBox6.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.TpAssessor.ResumeLayout(False)
    Me.TpAssessor.PerformLayout()
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmTO220C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDEFER = New TXDEFER.MyData(myDBConnect)
    MyTXREALC = New TXREALC.MyData(myDBConnect)
    MyTXREAA = New TXREAA.MyData(myDBConnect)
    MyTXMRATE = New TXMRATE.MyData(myDBConnect)
    MyTPAYMNT = New TPAYMNT.MyData(myDBConnect)
    MyTXM35H = New TXM35H.MyData(myDBConnect)

    LoadScrn = True
    TxtListNo.Focus()
    MyFrmTO220.TBarNew.Enabled = False

    AddMode = False
    MyFrmTO220.TBarPrint.Enabled = True
    If WrkListNo > 0 Then
      Me.Text = "Maintain " & Me.Text
      If Trim(TxtALName.Text) = "" Then
        MyFrmTO220.TBarSave.Enabled = True
        MyFrmTO220.TBarDelete.Enabled = True
      End If
      TxtListNo.Text = WrkListNo
      LnkListNo.Enabled = False
      TxtListNo.ReadOnly = True
      TxtYear.ReadOnly = True
      DtPckSigned.Value = Date.Today
      DtPckAssr.Value = Date.Today
      MyTXDEFER.GetOneRecordP(WrkListNo, WrkType, WrkYear)
      If MyTXDEFER.RecordNotFound Then
        MyFrmTO220.TBarNew.Enabled = False
        MyFrmTO220.TBarSave.Enabled = False
        MyFrmTO220.TBarDelete.Enabled = False
        MyFrmTO220.TBarPrint.Enabled = False
        Me.ErrProv.SetError(TxtListNo, "Record not found")
        Exit Sub
      End If

      With MyTXDEFER
        'Applicant
        TxtListNo.Text = ._LISTNO
        'Txttype.Text = ._TYPE
        TxtYear.Text = ._YEAR
        TxtALName.Text = Trim(._ALNAME)
        TxtAFName.Text = Trim(._AFNAME)
        TxtAInit.Text = Trim(._AINIT)
        If ._ASSN > 0 Then
          MskTxtASSN.Text = Format(._ASSN, "000000000")
        End If
        TxtSLName.Text = Trim(._SLNAME)
        TxtSFName.Text = Trim(._SFNAME)
        TxtSInit.Text = Trim(._SINIT)
        If ._SSSN > 0 Then
          MskTxtSSSN.Text = Format(._SSSN, "000000000")
        End If
        TxtLocNo.Text = Trim(._LOCNO)
        TxtLoc.Text = Trim(._LOC)
        TxtCity.Text = Trim(._CITY)
        TxtState.Text = Trim(._STATE)
        If ._ZIP > 0 Then
          TxtZip.Text = Format(._ZIP, "00000")
        End If
        TxtMAddr.Text = Trim(._MADDR)
        TxtMCity.Text = Trim(._MCITY)
        TxtMState.Text = Trim(._MSTATE)
        If ._MZIP > 0 Then
          TxtMZip.Text = Format(._MZIP, "00000")
        End If
        DtPckSigned.Value = MyUtils.GetDBDate(._DTSIGN)
        If ._PHONE > 0 Then
          MskTxtPhone.Text = ._PHONE
        End If
        TxtPropPct.Text = ._PROPCT
        TxtIncome.Text = Format(._INCOME, "Fixed")
        TxtSSA.Text = Format(._SSA, "Fixed")
        TxtOther.Text = Format(._OTHER, "Fixed")
        DtPckSigned.Value = MyUtils.GetDBDate(._DTSIGN)
        If ._PHONE > 0 Then
          MskTxtPhone.Text = ._PHONE
        End If
        TxtRelate.Text = Trim(._RELATE)
        'Assessor
        LblListNo.Text = ._LISTNO
        LblYear.Text = ._YEAR
        LblALName.Text = Trim(._ALNAME)
        LblAFName.Text = Trim(._AFNAME)
        LblAInit.Text = Trim(._AINIT)
        TxtPropPct.Text = ._PROPCT
        LblGross.Text = ._PGROSS
        LblAppGross.Text = ._GROSS
        LblNet.Text = ._NET
        LblXVet.Text = ._GROSS - ._NET
        LblTotTax.Text = Format(._TAX, "fixed")
        LblDeferred.Text = Format(._DEFERRED, "fixed")
        If Trim(._ALLOW) = "Y" Then
          RbAllowed.Checked = True
        End If
        If Trim(._ALLOW) = "N" Then
          RbDisallowed.Checked = True
        End If
        TxtDisallowReason.Text = Trim(._DISRSN)
        If ._DTASSR > 0 Then
          DtPckAssr.Value = MyUtils.GetDBDate(._DTASSR)
          DtPckAssr.Checked = True
        End If
      End With
      CalcTotal()
      MyTXREALC.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text))
      If Not MyTXREALC.RecordNotFound Then
        If Math.Abs(WrkYear - MyTXREALC._FCYR) <= 1 Then
          GetTXREALC(False)
        Else
          GetTXREAA()
        End If
      Else
        GetTXREAA()
      End If
      GetMillRate(WrkYear)
      CalcDefer()
    Else
      Me.Text = "Add " & Me.Text
      AddMode = True
      TxtPropPct.Text = "100"
      MyFrmTO220.TBarDelete.Enabled = False
      MyFrmTO220.TBarSave.Enabled = True
    End If

    LoadScrn = False
  End Sub

  Private Sub FrmTO220C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTO220.TBarNew.Enabled = True
    MyFrmTO220.TBarSave.Enabled = False
    MyFrmTO220.TBarDelete.Enabled = False
    MyFrmTO220.TBarPrint.Enabled = False
    MyFrmTO220B.FormatGrid()
    MyFrmTO220B.Show()

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    MyTXDEFER.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim WrkDevlt As String
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    WrkDevlt = ""
    MyTXDEFER.GetOneRecordP(WrkListNo, WrkType, MyUtils.CnvSng(TxtYear.Text))
    If AddMode Then
      If Not MyTXDEFER.RecordNotFound Then
        Me.ErrProv.SetError(TxtListNo, "Record already exists")
        Exit Sub
      End If
    End If

    If Not AddMode Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXDEFER.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXDEFER.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()
  End Sub
  Private Sub MoveToFile()
    With MyTXDEFER
      'Applicant
      ._LISTNO = MyUtils.CnvSng(TxtListNo.Text)
      ._TYPE = "R"
      ._YEAR = MyUtils.CnvSng(TxtYear.Text)
      ._ALNAME = TxtALName.Text
      ._AFNAME = TxtAFName.Text
      ._AINIT = TxtAInit.Text
      ._ASSN = Format(MyUtils.CnvSng(MskTxtASSN.Text), "000000000")
      ._SLNAME = TxtSLName.Text
      ._SFNAME = TxtSFName.Text
      ._SINIT = TxtSInit.Text
      ._SSSN = Format(MyUtils.CnvSng(MskTxtSSSN.Text), "000000000")
      ._LOCNO = MyUtils.JustifyRight(TxtLocNo.Text, 7)
      ._LOC = TxtLoc.Text
      ._CITY = TxtCity.Text
      ._STATE = TxtState.Text
      ._ZIP = MyUtils.CnvSng(TxtZip.Text)
      ._MADDR = TxtMAddr.Text
      ._MCITY = TxtMCity.Text
      ._MSTATE = TxtMState.Text
      ._MZIP = MyUtils.CnvSng(TxtMZip.Text)
      ._DTSIGN = MyUtils.SetDBDate(DtPckSigned.Value)
      ._PHONE = MyUtils.CnvSng(MskTxtPhone.Text)
      ._RELATE = Trim(TxtRelate.Text)
      ._INCOME = MyUtils.CnvSng(TxtIncome.Text)
      ._SSA = MyUtils.CnvSng(TxtSSA.Text)
      ._OTHER = MyUtils.CnvSng(TxtOther.Text)
      ._FILING = ""
      'Assessor
      ._ALLOW = String.Empty
      ._PROPCT = MyUtils.CnvSng(TxtPropPct.Text)
      ._PGROSS = MyUtils.CnvSng(LblGross.Text)
      ._GROSS = MyUtils.CnvSng(LblAppGross.Text)
      ._NET = MyUtils.CnvSng(LblNet.Text)
      ._TAX = MyUtils.CnvSng(LblTotTax.Text)
      ._DEFERRED = MyUtils.CnvSng(LblDeferred.Text)
      If RbAllowed.Checked Then
        ._ALLOW = "Y"
      End If
      If RbDisallowed.Checked Then
        ._ALLOW = "N"
      End If
      ._DISRSN = TxtDisallowReason.Text
      If DtPckAssr.Checked Then
        ._DTASSR = MyUtils.SetDBDate(DtPckAssr.Value)
      Else
        ._DTASSR = 0
      End If
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

    If MyUtils.CnvSng(TxtYear.Text) = 0 Then
      ErrorField(I) = "year"
      ErrorMsg(I) = "Year is required"
      I = I + 1
    End If

    If TxtALName.Text = String.Empty Then
      ErrorField(I) = "alname"
      ErrorMsg(I) = "Last Name is required"
      I = I + 1
    End If

    If TxtAFName.Text = String.Empty Then
      ErrorField(I) = "afname"
      ErrorMsg(I) = "First Name is required"
      I = I + 1
    End If

    If MskTxtASSN.Text = String.Empty Then
      ErrorField(I) = "assn"
      ErrorMsg(I) = "SSN is required"
      I = I + 1
    End If

    If TxtSLName.Text <> "" And MskTxtSSSN.Text = String.Empty Then
      ErrorField(I) = "sssn"
      ErrorMsg(I) = "SSN is required"
      I = I + 1
    End If

    If TxtLoc.Text = String.Empty Then
      ErrorField(I) = "loc"
      ErrorMsg(I) = "Location is required"
      I = I + 1
    End If

    If TxtCity.Text = String.Empty Then
      ErrorField(I) = "city"
      ErrorMsg(I) = "City is required"
      I = I + 1
    End If

    If TxtState.Text = String.Empty Then
      ErrorField(I) = "state"
      ErrorMsg(I) = "State is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtZip.Text) = 0 Then
      ErrorField(I) = "zip"
      ErrorMsg(I) = "Zip is required"
      I = I + 1
    End If

    If DtPckAssr.Checked Then
      If Not RbAllowed.Checked And Not RbDisallowed.Checked Then
        ErrorField(I) = "assr"
        ErrorMsg(I) = "Allowed or disallowed must be checked"
        I = I + 1
      End If
    End If

    If Not DtPckAssr.Checked Then
      If RbAllowed.Checked Or RbDisallowed.Checked Then
        ErrorField(I) = "assr"
        ErrorMsg(I) = "Assessor signed date is required"
        I = I + 1
      End If
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtListNo, "")
    ErrProv.SetError(TxtYear, "")
    ErrProv.SetError(TxtALName, "")
    ErrProv.SetError(TxtAFName, "")
    ErrProv.SetError(MskTxtASSN, "")
    ErrProv.SetError(TxtSLName, "")
    ErrProv.SetError(TxtSFName, "")
    ErrProv.SetError(MskTxtSSSN, "")
    ErrProv.SetError(TxtLocNo, "")
    ErrProv.SetError(TxtLoc, "")
    ErrProv.SetError(TxtCity, "")
    ErrProv.SetError(TxtState, "")
    ErrProv.SetError(TxtZip, "")
    ErrProv.SetError(DtPckAssr, "")
    ErrProv.SetError(DtPckAssr, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "listno"
          ErrProv.SetError(TxtListNo, ErrorMsg(I))
        Case "year"
          ErrProv.SetError(TxtYear, ErrorMsg(I))
        Case "alname"
          ErrProv.SetError(TxtALName, ErrorMsg(I))
        Case "afname"
          ErrProv.SetError(TxtAFName, ErrorMsg(I))
        Case "assn"
          ErrProv.SetError(MskTxtASSN, ErrorMsg(I))
        Case "sssn"
          ErrProv.SetError(MskTxtSSSN, ErrorMsg(I))
        Case "loc"
          ErrProv.SetError(TxtLoc, ErrorMsg(I))
          ErrProv.SetError(TxtLocNo, ErrorMsg(I))
        Case "city"
          ErrProv.SetError(TxtCity, ErrorMsg(I))
        Case "state"
          ErrProv.SetError(TxtState, ErrorMsg(I))
        Case "zip"
          ErrProv.SetError(TxtZip, ErrorMsg(I))
        Case "assr"
          ErrProv.SetError(DtPckAssr, ErrorMsg(I))
        Case ""
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub FrmTO220C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTO220.SbpScreen.Text = "TO220C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub LnkListNo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkListNo.LinkClicked
    MyFrmListRealC = New FrmListRealC
    MyFrmListRealC.MdiParent = Me.ParentForm
    MyFrmListRealC.WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    MyFrmListRealC.Show()
  End Sub
  Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSSRR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSSA.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtOther_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOther.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtIncome_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIncome.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtPropPct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPropPct.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtListNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtListNo.LostFocus
    If TxtListNo.ReadOnly Then Exit Sub

    GetListNo()
  End Sub
  Private Sub TxtYear_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtYear.LostFocus
    If TxtListNo.ReadOnly Then Exit Sub

    GetMillRate(MyUtils.CnvSng(TxtYear.Text))
    GetTXDEFER()
    GetTXM35H()
    CalcDefer()
  End Sub
  Private Sub TxtPropPct_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPropPct.LostFocus
    CalcDefer()
  End Sub
  Public Sub GetListNo()
    GetTXREALC(True)
  End Sub
  Private Sub TxtIncome_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIncome.TextChanged
    CalcTotal()
  End Sub
  Private Sub TxtSSA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSSA.TextChanged
    CalcTotal()
  End Sub
  Private Sub TxtOther_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOther.TextChanged
    CalcTotal()
  End Sub
  Public Sub GetTXREALC(WrkNames As Boolean)
    Dim WrkLoc As String
    Dim Pos As Integer
    Dim Pos2 As Integer
    Dim WrkAssCode(6) As Integer
    Dim WrkGross(6) As Integer
    Dim J As Integer

    MyTXREALC.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text))
    If MyTXREALC.RecordNotFound Then Exit Sub

    With MyTXREALC
      'Populate First & Last Name
      If WrkNames Then
        TxtName.Text = Trim(._NAME)
        TxtSName.Text = Trim(._SNAME)
        Pos = InStr(TxtName.Text, " ")
        Pos2 = InStr(Pos + 1, TxtName.Text, " ")
        If Pos > 0 Then
          TxtALName.Text = Mid(TxtName.Text, 1, Pos - 1)
          If Pos2 > 0 Then
            TxtAFName.Text = Mid(TxtName.Text, Pos + 1, Pos2 - Pos)
            If Mid(TxtName.Text, Pos2 + 1, 1) <> "&" Then
              TxtAInit.Text = Mid(TxtName.Text, Pos2 + 1, 1)
            End If
          Else
            TxtAFName.Text = Mid(TxtName.Text, Pos + 1, 30)
          End If
        End If
        LblALName.Text = Mid(TxtALName.Text, 1, 20)
        LblAFName.Text = Mid(TxtAFName.Text, 1, 10)
        TxtALName.Text = Mid(TxtALName.Text, 1, 20)
        TxtAFName.Text = Mid(TxtAFName.Text, 1, 10)
        'Populate Property & Mailing Address
        WrkLoc = Trim(._LOCNO) & " " & Trim(._LOC)
        TxtLoc.Text = Trim(._LOC)
        TxtLocNo.Text = Trim(._LOCNO)
        If Trim(._ADD1) = WrkLoc Then
          TxtCity.Text = Trim(._CITY)
          TxtState.Text = Trim(._STATE)
          TxtZip.Text = Format(._ZIP5, "00000")
        Else
          TxtMAddr.Text = Trim(._ADD1)
          TxtMCity.Text = Trim(._CITY)
          TxtMState.Text = Trim(._STATE)
          TxtMZip.Text = Format(._ZIP5, "00000")
        End If
      End If

      If ._CCNO > 0 Then
        LblGross.Text = MyUtils.Round(._CCGRS * (MyUtils.CnvSng(TxtPropPct.Text) / 100), 0)
      Else
        LblGross.Text = MyUtils.Round(._GROSS * (MyUtils.CnvSng(TxtPropPct.Text) / 100), 0)
      End If
      'Add Gross to Land or Building total
      WrkAssCode(0) = Trim(._CODE1)
      WrkAssCode(1) = Trim(._CODE2)
      WrkAssCode(2) = Trim(._CODE3)
      WrkAssCode(3) = Trim(._CODE4)
      WrkAssCode(4) = Trim(._CODE5)
      WrkAssCode(5) = Trim(._CODE6)
      WrkAssCode(6) = Trim(._CODE7)
      If ._CCNO > 0 Then
        WrkGross(0) = ._CASS1
        WrkGross(1) = ._CASS2
        WrkGross(2) = ._CASS3
        WrkGross(3) = ._CASS4
        WrkGross(4) = ._CASS5
        WrkGross(5) = ._CASS6
        WrkGross(6) = ._CASS7
      Else
        WrkGross(0) = ._ASS1
        WrkGross(1) = ._ASS2
        WrkGross(2) = ._ASS3
        WrkGross(3) = ._ASS4
        WrkGross(4) = ._ASS5
        WrkGross(5) = ._ASS6
        WrkGross(6) = ._ASS7
      End If
      WrkExcludeGross = 0
      For J = 0 To 6
        If WrkAssCode(J) = cExcludeCode1 Then
          WrkExcludeGross = WrkExcludeGross + WrkGross(J)
        End If
      Next J
      If ._CCNO > 0 Then
        LblAppGross.Text = MyUtils.Round((._CCGRS - WrkExcludeGross) * (MyUtils.CnvSng(TxtPropPct.Text) / 100), 0)
      Else
        LblAppGross.Text = MyUtils.Round((._GROSS - WrkExcludeGross) * (MyUtils.CnvSng(TxtPropPct.Text) / 100), 0)
      End If
      If ._FCCOD = "C" Then
        LblStBenefit.Text = Format(._FTAX, "fixed")
      End If
      LblLocal.Text = Format(._TWNBN, "fixed")
    End With
  End Sub
  Public Sub GetTXREAA()
    Dim WrkAssCode(6) As Integer
    Dim WrkGross(6) As Integer
    Dim J As Integer
    WrkFoundArchive = False
    MyTXREAA.GetOneRecordP(WrkListNo, WrkYear)
    If MyTXREAA.RecordNotFound Then Exit Sub

    WrkFoundArchive = True
    With MyTXREAA
      If ._CCNO > 0 Then
        LblGross.Text = MyUtils.Round(._CCGRS * (MyUtils.CnvSng(TxtPropPct.Text) / 100), 0)
      Else
        LblGross.Text = MyUtils.Round(._GROSS * (MyUtils.CnvSng(TxtPropPct.Text) / 100), 0)
      End If
      'Add Gross to Land or Building total
      WrkAssCode(0) = Trim(._CODE1)
      WrkAssCode(1) = Trim(._CODE2)
      WrkAssCode(2) = Trim(._CODE3)
      WrkAssCode(3) = Trim(._CODE4)
      WrkAssCode(4) = Trim(._CODE5)
      WrkAssCode(5) = Trim(._CODE6)
      WrkAssCode(6) = Trim(._CODE7)
      If ._CCNO > 0 Then
        WrkGross(0) = ._CASS1
        WrkGross(1) = ._CASS2
        WrkGross(2) = ._CASS3
        WrkGross(3) = ._CASS4
        WrkGross(4) = ._CASS5
        WrkGross(5) = ._CASS6
        WrkGross(6) = ._CASS7
      Else
        WrkGross(0) = ._ASS1
        WrkGross(1) = ._ASS2
        WrkGross(2) = ._ASS3
        WrkGross(3) = ._ASS4
        WrkGross(4) = ._ASS5
        WrkGross(5) = ._ASS6
        WrkGross(6) = ._ASS7
      End If
      WrkExcludeGross = 0
      For J = 0 To 6
        If WrkAssCode(J) = cExcludeCode1 Then
          WrkExcludeGross = WrkExcludeGross + WrkGross(J)
        End If
      Next J
      If ._CCNO > 0 Then
        LblAppGross.Text = MyUtils.Round((._CCGRS - WrkExcludeGross) * (MyUtils.CnvSng(TxtPropPct.Text) / 100), 0)
      Else
        LblAppGross.Text = MyUtils.Round((._GROSS - WrkExcludeGross) * (MyUtils.CnvSng(TxtPropPct.Text) / 100), 0)
      End If
      If ._FCCOD = "C" Then
        LblStBenefit.Text = Format(._FTAX, "fixed")
      End If
      LblLocal.Text = Format(._TWNBN, "fixed")
    End With
  End Sub
  Private Sub CalcTotal()
    Dim WrkTotal As Decimal

    WrkTotal = MyUtils.CnvSng(TxtIncome.Text) + MyUtils.CnvSng(TxtSSA.Text) + MyUtils.CnvSng(TxtOther.Text)
    LblTotal.Text = Format(WrkTotal, "fixed")
  End Sub
  Private Sub GetTXDEFER()
    Dim pListNo As Integer
    pListNo = MyUtils.CnvSng(TxtListNo.Text)
    WrkYear = MyUtils.CnvSng(TxtYear.Text)
    MyTXDEFER.GetOneRecordP(pListNo, WrkType, WrkYear - 1)
    If MyTXDEFER.RecordNotFound Then
      MyTXDEFER.GetOneRecordP(pListNo, WrkType, WrkYear - 2)
      If MyTXDEFER.RecordNotFound Then
        MyFrmTO220.TBarDelete.Enabled = False
        LoadScrn = False
        Exit Sub
      End If
    End If
    'Get data from previous year
    With MyTXDEFER
      TxtALName.Text = Trim(._ALNAME)
      TxtAFName.Text = Trim(._AFNAME)
      TxtAInit.Text = Trim(._AINIT)
      If ._ASSN > 0 Then
        MskTxtASSN.Text = Format(._ASSN, "000000000")
      End If
      TxtSLName.Text = Trim(._SLNAME)
      TxtSFName.Text = Trim(._SFNAME)
      TxtSInit.Text = Trim(._SINIT)
      If ._SSSN > 0 Then
        MskTxtSSSN.Text = Format(._SSSN, "000000000")
      End If
      If Trim(._LOC) <> "" Then
        TxtLoc.Text = Trim(._LOC)
        TxtLocNo.Text = Trim(._LOCNO)
      End If
      TxtCity.Text = Trim(._CITY)
      TxtState.Text = Trim(._STATE)
      If ._ZIP > 0 Then
        TxtZip.Text = Format(._ZIP, "00000")
      End If
      If ._PHONE > 0 Then
        MskTxtPhone.Text = ._PHONE
      End If
      TxtRelate.Text = Trim(._RELATE)
    End With
  End Sub
  Private Sub GetTXM35H()
    Dim pListNo As Integer
    pListNo = MyUtils.CnvSng(TxtListNo.Text)
    WrkYear = MyUtils.CnvSng(TxtYear.Text)
    With MyTXM35H
      .GetOneRecordP(pListNo, WrkYear, 0)
      If .RecordNotFound Then
        .GetOneRecordP(pListNo, WrkYear - 1, 0)
      End If
      If Not .RecordNotFound Then
        TxtAFName.Text = Trim(._AFNAME)
        TxtALName.Text = Trim(._ALNAME)
        TxtAInit.Text = Trim(._AINIT)
        If ._ASSN > 0 Then
          MskTxtASSN.Text = Format(._ASSN, "000000000")
        End If
        TxtSFName.Text = Trim(._SFNAME)
        TxtSLName.Text = Trim(._SLNAME)
        TxtSInit.Text = Trim(._SINIT)
        If ._SSSN > 0 Then
          MskTxtSSSN.Text = Format(._SSSN, "000000000")
        End If
        If TxtCity.Text = "" Then
          TxtCity.Text = Trim(._PCITY)
        End If
        If TxtZip.Text = "" Then
          TxtZip.Text = Format(._PZIP, "00000")
        End If
        If Trim(._MADDR) <> "" Then
          TxtMAddr.Text = Trim(._MADDR)
          TxtMCity.Text = Trim(._MCITY)
          TxtState.Text = Trim(._MSTATE)
          TxtMZip.Text = Format(._MZIP, "00000")
        End If
        TxtIncome.Text = Format(._INCOME, "Fixed")
        TxtSSA.Text = Format(._SSRR, "Fixed")
        TxtOther.Text = Format(._OTHER, "Fixed")
      End If
      LblXVet.Text = ._XVET + ._XADDL + ._XLOCAL
      LblNet.Text = MyUtils.CnvSng(LblAppGross.Text) - MyUtils.CnvSng(LblXVet.Text)
    End With
  End Sub
  Private Sub GetMillRate(ByVal WrkYear As Integer)
    With MyTXMRATE
      .GetOneRecordP(WrkYear, "R", 0)
      If .RecordNotFound Then
        .GetOneRecordP(WrkYear, "", 0)
      End If
      LblMillRate.Text = Format(._MRRATE * 1000, "###.000")
    End With
  End Sub
  Private Sub CalcDefer()
    Dim WrkTax As Decimal
    Dim WrkNet As Decimal
    Dim WrkAddlNet As Decimal
    Dim WrkDeferred As Decimal
    Dim WrkAddlTax As Decimal
    Dim WrkTaxDue As Decimal
    WrkNet = MyUtils.CnvSng(LblNet.Text) * (MyUtils.CnvSng(TxtPropPct.Text) / 100)
    WrkAddlNet = (MyUtils.CnvSng(LblGross.Text) - MyUtils.CnvSng(LblAppGross.Text)) * (MyUtils.CnvSng(TxtPropPct.Text) / 100)
    WrkTax = WrkNet * MyTXMRATE._MRRATE
    WrkAddlTax = WrkAddlNet * MyTXMRATE._MRRATE
    With MyTPAYMNT
      .In_Year = MyUtils.CnvSng(TxtYear.Text)
      .In_Type = "R"
      .In_Dst = 0
      .In_Phs = ""
      .In_TaxT = WrkTax
      .CalcPaySplit()
      WrkTax = .Out_TaxT
    End With
    LblPropTax.Text = Format(WrkTax, "fixed")
    LblTotTax.Text = Format(WrkTax - MyUtils.CnvSng(LblStBenefit.Text), "fixed")
    WrkDeferred = MyUtils.CnvSng(LblTotTax.Text) * 0.75
    With MyTPAYMNT
      .In_Year = MyUtils.CnvSng(TxtYear.Text)
      .In_Type = "R"
      .In_Dst = 0
      .In_Phs = ""
      .In_TaxT = WrkDeferred
      .CalcPaySplit()
      WrkDeferred = .Out_TaxT
    End With
    LblDeferred.Text = Format(WrkDeferred, "fixed")
    If WrkAddlTax > 0 Then
      With MyTPAYMNT
        .In_Year = MyUtils.CnvSng(TxtYear.Text)
        .In_Type = "R"
        .In_Dst = 0
        .In_Phs = ""
        .In_TaxT = WrkAddlTax
        .CalcPaySplit()
        WrkAddlTax = .Out_TaxT
      End With
      LblAddlTax.Text = Format(WrkAddlTax, "fixed")
    End If
    WrkTaxDue = MyUtils.CnvSng(LblTotTax.Text) - WrkDeferred + WrkAddlTax - MyUtils.CnvSng(LblLocal.Text)
    LblTaxDue.Text = Format(WrkTaxDue, "fixed")
  End Sub

  Private Sub Tab1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tab1.Click
    LblListNo.Text = TxtListNo.Text
    LblTypeDesc.Text = RbRE.Text
    LblYear.Text = TxtYear.Text
  End Sub

  Private Sub BtnRecalc_Click(sender As Object, e As EventArgs) Handles BtnRecalc.Click
    Dim pListNo As Integer
    GetMillRate(WrkYear)
    pListNo = MyUtils.CnvSng(TxtListNo.Text)
    WrkYear = MyUtils.CnvSng(TxtYear.Text)
    With MyTXM35H
      .GetOneRecordP(pListNo, WrkYear, 0)
      If .RecordNotFound Then
        .GetOneRecordP(pListNo, WrkYear - 1, 0)
      End If
      If Not .RecordNotFound Then
        LblXVet.Text = ._XVET + ._XADDL + ._XLOCAL
        LblNet.Text = MyUtils.CnvSng(LblAppGross.Text) - MyUtils.CnvSng(LblXVet.Text)
      End If
    End With
    CalcDefer()
  End Sub

  Private Sub Label71_Click(sender As Object, e As EventArgs) Handles LblLocal.Click

  End Sub

  Private Sub Label69_Click(sender As Object, e As EventArgs) Handles Label69.Click

  End Sub

  Private Sub Label73_Click(sender As Object, e As EventArgs) Handles Label73.Click

  End Sub

  Private Sub TpAssessor_Click(sender As Object, e As EventArgs) Handles TpAssessor.Click

  End Sub
End Class

