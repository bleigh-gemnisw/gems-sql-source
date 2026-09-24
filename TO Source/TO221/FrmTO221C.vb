Public Class FrmTO221C
  Inherits System.Windows.Forms.Form
  Dim MyTXFREEZE As TXFREEZE.MyData
  Dim MyTXREALC As TXREALC.MyData
  Dim MyTXREAA As TXREAA.MyData
  Dim MyTXMRATE As TXMRATE.MyData
  Dim MyTPAYMNT As TPAYMNT.MyData
  Dim MyTXM35H As TXM35H.MyData
  Dim MyTXM35EX As TXM35EX.MyData
  Dim MyTXLOCAL As TXLOCAL.MyData
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
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents MskTxtSSSN As System.Windows.Forms.MaskedTextBox
  Friend WithEvents MskTxtASSN As System.Windows.Forms.MaskedTextBox
  Friend WithEvents MskTxtPhone As MaskedTextBox
  Friend WithEvents Label23 As Label
  Friend WithEvents TxtRelate As TextBox
  Friend WithEvents Label31 As Label
  Friend WithEvents Label24 As Label
  Friend WithEvents DtPckSigned As DateTimePicker
  Friend WithEvents GroupBox1 As GroupBox
  Friend WithEvents Label55 As Label
  Friend WithEvents Label48 As Label
  Friend WithEvents LblTotal As Label
  Friend WithEvents Label21 As Label
  Friend WithEvents TxtOther As TextBox
  Friend WithEvents Label20 As Label
  Friend WithEvents TxtSSRR As TextBox
  Friend WithEvents Label15 As Label
  Friend WithEvents TxtInterest As TextBox
  Friend WithEvents Label19 As Label
  Friend WithEvents TxtIncome As TextBox
  Friend WithEvents Label25 As Label
  Friend WithEvents GroupBox4 As GroupBox
  Friend WithEvents RbCivil As RadioButton
  Friend WithEvents RbSurviving As RadioButton
  Friend WithEvents RbUnmarried As RadioButton
  Friend WithEvents RbMarried As RadioButton
  Friend WithEvents TxtOwner As TextBox
  Friend WithEvents TxtMZip As TextBox
  Friend WithEvents TxtMState As TextBox
  Friend WithEvents TxtPState As TextBox
  Friend WithEvents TxtPZip As TextBox
  Friend WithEvents TxtPAddr As TextBox
  Friend WithEvents TxtMAddr As TextBox
  Friend WithEvents TxtPCity As TextBox
  Friend WithEvents TxtMCity As TextBox
  Friend WithEvents Label12 As Label
  Friend WithEvents Label14 As Label
  Friend WithEvents Label16 As Label
  Friend WithEvents Label17 As Label
  Friend WithEvents Label35 As Label
  Friend WithEvents Label59 As Label
  Friend WithEvents Label63 As Label
  Friend WithEvents Label64 As Label
  Friend WithEvents Label65 As Label
  Friend WithEvents ChkDisabled As CheckBox
  Friend WithEvents ChkNursingHome As CheckBox
  Friend WithEvents ChkTaxReturn As CheckBox
  Friend WithEvents GroupBox3 As GroupBox
  Friend WithEvents LblGross As Label
  Friend WithEvents Label3 As Label
  Friend WithEvents LblAppGross As Label
  Friend WithEvents LblNet As Label
  Friend WithEvents Label8 As Label
  Friend WithEvents TxtAddlVet As TextBox
  Friend WithEvents Label9 As Label
  Friend WithEvents TxtLocal As TextBox
  Friend WithEvents Label18 As Label
  Friend WithEvents Label32 As Label
  Friend WithEvents Label66 As Label
  Friend WithEvents TxtVet As TextBox
  Friend WithEvents TxtDisabled As TextBox
  Friend WithEvents TxtBlind As TextBox
  Friend WithEvents Label69 As Label
  Friend WithEvents Label71 As Label
  Friend WithEvents TxtFrzTax As TextBox
  Friend WithEvents LblMillRate As Label
  Friend WithEvents Label73 As Label
  Friend WithEvents GroupBox7 As GroupBox
  Friend WithEvents LblExcd7 As Label
  Friend WithEvents LblExam7 As Label
  Friend WithEvents LblExcd6 As Label
  Friend WithEvents LblExam6 As Label
  Friend WithEvents LblExcd5 As Label
  Friend WithEvents LblExam5 As Label
  Friend WithEvents LblExcd4 As Label
  Friend WithEvents LblExam4 As Label
  Friend WithEvents LblExcd3 As Label
  Friend WithEvents LblExam3 As Label
  Friend WithEvents LblExcd2 As Label
  Friend WithEvents LblExam2 As Label
  Friend WithEvents LblExcd1 As Label
  Friend WithEvents LblExam1 As Label
  Friend WithEvents TxtPGross As TextBox
  Friend WithEvents Label51 As Label
  Friend WithEvents DtPckReceived As DateTimePicker
  Friend WithEvents Label33 As Label
  Friend WithEvents TxtPropPct As TextBox
  Friend WithEvents Label37 As Label
  Friend WithEvents Label70 As Label


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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTO221C))
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
    Me.GrpType = New System.Windows.Forms.GroupBox()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.TxtSName = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.TxtSLName = New System.Windows.Forms.TextBox()
    Me.TxtALName = New System.Windows.Forms.TextBox()
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
    Me.LnkListNo = New System.Windows.Forms.LinkLabel()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.TpAssessor = New System.Windows.Forms.TabPage()
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
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.Label55 = New System.Windows.Forms.Label()
    Me.Label48 = New System.Windows.Forms.Label()
    Me.LblTotal = New System.Windows.Forms.Label()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.TxtOther = New System.Windows.Forms.TextBox()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.TxtSSRR = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.TxtInterest = New System.Windows.Forms.TextBox()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.TxtIncome = New System.Windows.Forms.TextBox()
    Me.Label25 = New System.Windows.Forms.Label()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.RbCivil = New System.Windows.Forms.RadioButton()
    Me.RbSurviving = New System.Windows.Forms.RadioButton()
    Me.RbUnmarried = New System.Windows.Forms.RadioButton()
    Me.RbMarried = New System.Windows.Forms.RadioButton()
    Me.TxtOwner = New System.Windows.Forms.TextBox()
    Me.TxtMZip = New System.Windows.Forms.TextBox()
    Me.TxtMState = New System.Windows.Forms.TextBox()
    Me.TxtPState = New System.Windows.Forms.TextBox()
    Me.TxtPZip = New System.Windows.Forms.TextBox()
    Me.TxtPAddr = New System.Windows.Forms.TextBox()
    Me.TxtMAddr = New System.Windows.Forms.TextBox()
    Me.TxtPCity = New System.Windows.Forms.TextBox()
    Me.TxtMCity = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.Label35 = New System.Windows.Forms.Label()
    Me.Label59 = New System.Windows.Forms.Label()
    Me.Label63 = New System.Windows.Forms.Label()
    Me.Label64 = New System.Windows.Forms.Label()
    Me.Label65 = New System.Windows.Forms.Label()
    Me.ChkDisabled = New System.Windows.Forms.CheckBox()
    Me.ChkNursingHome = New System.Windows.Forms.CheckBox()
    Me.ChkTaxReturn = New System.Windows.Forms.CheckBox()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.LblGross = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.LblAppGross = New System.Windows.Forms.Label()
    Me.LblNet = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtAddlVet = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TxtLocal = New System.Windows.Forms.TextBox()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.Label32 = New System.Windows.Forms.Label()
    Me.Label66 = New System.Windows.Forms.Label()
    Me.TxtVet = New System.Windows.Forms.TextBox()
    Me.TxtDisabled = New System.Windows.Forms.TextBox()
    Me.TxtBlind = New System.Windows.Forms.TextBox()
    Me.Label69 = New System.Windows.Forms.Label()
    Me.Label70 = New System.Windows.Forms.Label()
    Me.Label71 = New System.Windows.Forms.Label()
    Me.TxtFrzTax = New System.Windows.Forms.TextBox()
    Me.LblMillRate = New System.Windows.Forms.Label()
    Me.Label73 = New System.Windows.Forms.Label()
    Me.DtPckReceived = New System.Windows.Forms.DateTimePicker()
    Me.Label33 = New System.Windows.Forms.Label()
    Me.TxtPropPct = New System.Windows.Forms.TextBox()
    Me.Label37 = New System.Windows.Forms.Label()
    Me.GroupBox7 = New System.Windows.Forms.GroupBox()
    Me.LblExcd7 = New System.Windows.Forms.Label()
    Me.LblExam7 = New System.Windows.Forms.Label()
    Me.LblExcd6 = New System.Windows.Forms.Label()
    Me.LblExam6 = New System.Windows.Forms.Label()
    Me.LblExcd5 = New System.Windows.Forms.Label()
    Me.LblExam5 = New System.Windows.Forms.Label()
    Me.LblExcd4 = New System.Windows.Forms.Label()
    Me.LblExam4 = New System.Windows.Forms.Label()
    Me.LblExcd3 = New System.Windows.Forms.Label()
    Me.LblExam3 = New System.Windows.Forms.Label()
    Me.LblExcd2 = New System.Windows.Forms.Label()
    Me.LblExam2 = New System.Windows.Forms.Label()
    Me.LblExcd1 = New System.Windows.Forms.Label()
    Me.LblExam1 = New System.Windows.Forms.Label()
    Me.TxtPGross = New System.Windows.Forms.TextBox()
    Me.Label51 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Tab1.SuspendLayout()
    Me.TpApplicant.SuspendLayout()
    Me.GrpType.SuspendLayout()
    Me.GroupBox6.SuspendLayout()
    Me.TpAssessor.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox7.SuspendLayout()
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
    Me.Tab1.Size = New System.Drawing.Size(840, 600)
    Me.Tab1.TabIndex = 0
    '
    'TpApplicant
    '
    Me.TpApplicant.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.TpApplicant.Controls.Add(Me.ChkDisabled)
    Me.TpApplicant.Controls.Add(Me.ChkNursingHome)
    Me.TpApplicant.Controls.Add(Me.ChkTaxReturn)
    Me.TpApplicant.Controls.Add(Me.TxtOwner)
    Me.TpApplicant.Controls.Add(Me.TxtMZip)
    Me.TpApplicant.Controls.Add(Me.TxtMState)
    Me.TpApplicant.Controls.Add(Me.TxtPState)
    Me.TpApplicant.Controls.Add(Me.TxtPZip)
    Me.TpApplicant.Controls.Add(Me.TxtPAddr)
    Me.TpApplicant.Controls.Add(Me.TxtMAddr)
    Me.TpApplicant.Controls.Add(Me.TxtPCity)
    Me.TpApplicant.Controls.Add(Me.TxtMCity)
    Me.TpApplicant.Controls.Add(Me.Label12)
    Me.TpApplicant.Controls.Add(Me.Label14)
    Me.TpApplicant.Controls.Add(Me.Label16)
    Me.TpApplicant.Controls.Add(Me.Label17)
    Me.TpApplicant.Controls.Add(Me.Label35)
    Me.TpApplicant.Controls.Add(Me.Label59)
    Me.TpApplicant.Controls.Add(Me.Label63)
    Me.TpApplicant.Controls.Add(Me.Label64)
    Me.TpApplicant.Controls.Add(Me.Label65)
    Me.TpApplicant.Controls.Add(Me.GroupBox4)
    Me.TpApplicant.Controls.Add(Me.GroupBox1)
    Me.TpApplicant.Controls.Add(Me.MskTxtPhone)
    Me.TpApplicant.Controls.Add(Me.Label23)
    Me.TpApplicant.Controls.Add(Me.TxtRelate)
    Me.TpApplicant.Controls.Add(Me.Label31)
    Me.TpApplicant.Controls.Add(Me.Label24)
    Me.TpApplicant.Controls.Add(Me.DtPckSigned)
    Me.TpApplicant.Controls.Add(Me.MskTxtSSSN)
    Me.TpApplicant.Controls.Add(Me.MskTxtASSN)
    Me.TpApplicant.Controls.Add(Me.GrpType)
    Me.TpApplicant.Controls.Add(Me.GroupBox6)
    Me.TpApplicant.Controls.Add(Me.TxtSLName)
    Me.TpApplicant.Controls.Add(Me.TxtALName)
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
    Me.TpApplicant.Controls.Add(Me.LnkListNo)
    Me.TpApplicant.Controls.Add(Me.TxtYear)
    Me.TpApplicant.Controls.Add(Me.Label13)
    Me.TpApplicant.Controls.Add(Me.TxtListNo)
    Me.TpApplicant.ImageIndex = 0
    Me.TpApplicant.Location = New System.Drawing.Point(4, 23)
    Me.TpApplicant.Name = "TpApplicant"
    Me.TpApplicant.Padding = New System.Windows.Forms.Padding(3)
    Me.TpApplicant.Size = New System.Drawing.Size(832, 573)
    Me.TpApplicant.TabIndex = 0
    Me.TpApplicant.Text = "Applicant Information"
    Me.TpApplicant.UseVisualStyleBackColor = True
    '
    'MskTxtPhone
    '
    Me.MskTxtPhone.Location = New System.Drawing.Point(136, 522)
    Me.MskTxtPhone.Mask = "(999) 000-0000"
    Me.MskTxtPhone.Name = "MskTxtPhone"
    Me.MskTxtPhone.Size = New System.Drawing.Size(81, 20)
    Me.MskTxtPhone.TabIndex = 183
    Me.MskTxtPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'Label23
    '
    Me.Label23.Location = New System.Drawing.Point(238, 503)
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
    Me.TxtRelate.Location = New System.Drawing.Point(241, 521)
    Me.TxtRelate.MaxLength = 20
    Me.TxtRelate.Name = "TxtRelate"
    Me.TxtRelate.Size = New System.Drawing.Size(151, 20)
    Me.TxtRelate.TabIndex = 186
    '
    'Label31
    '
    Me.Label31.Location = New System.Drawing.Point(133, 503)
    Me.Label31.Name = "Label31"
    Me.Label31.Size = New System.Drawing.Size(74, 16)
    Me.Label31.TabIndex = 185
    Me.Label31.Text = "Phone No"
    Me.Label31.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label24
    '
    Me.Label24.Location = New System.Drawing.Point(20, 503)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(80, 16)
    Me.Label24.TabIndex = 184
    Me.Label24.Text = "Date Signed"
    Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'DtPckSigned
    '
    Me.DtPckSigned.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckSigned.Location = New System.Drawing.Point(23, 521)
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
    Me.TpAssessor.Controls.Add(Me.GroupBox7)
    Me.TpAssessor.Controls.Add(Me.TxtPGross)
    Me.TpAssessor.Controls.Add(Me.Label51)
    Me.TpAssessor.Controls.Add(Me.DtPckReceived)
    Me.TpAssessor.Controls.Add(Me.Label33)
    Me.TpAssessor.Controls.Add(Me.TxtPropPct)
    Me.TpAssessor.Controls.Add(Me.Label37)
    Me.TpAssessor.Controls.Add(Me.Label71)
    Me.TpAssessor.Controls.Add(Me.TxtFrzTax)
    Me.TpAssessor.Controls.Add(Me.LblMillRate)
    Me.TpAssessor.Controls.Add(Me.Label73)
    Me.TpAssessor.Controls.Add(Me.GroupBox3)
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
    Me.TpAssessor.Size = New System.Drawing.Size(832, 573)
    Me.TpAssessor.TabIndex = 1
    Me.TpAssessor.Text = "Assessor"
    Me.TpAssessor.UseVisualStyleBackColor = True
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
    Me.DtPckAssr.Location = New System.Drawing.Point(162, 491)
    Me.DtPckAssr.Name = "DtPckAssr"
    Me.DtPckAssr.ShowCheckBox = True
    Me.DtPckAssr.Size = New System.Drawing.Size(100, 20)
    Me.DtPckAssr.TabIndex = 5
    '
    'Label54
    '
    Me.Label54.Location = New System.Drawing.Point(32, 495)
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
    Me.GroupBox5.Location = New System.Drawing.Point(27, 417)
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
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.Label55)
    Me.GroupBox1.Controls.Add(Me.Label48)
    Me.GroupBox1.Controls.Add(Me.LblTotal)
    Me.GroupBox1.Controls.Add(Me.Label21)
    Me.GroupBox1.Controls.Add(Me.TxtOther)
    Me.GroupBox1.Controls.Add(Me.Label20)
    Me.GroupBox1.Controls.Add(Me.TxtSSRR)
    Me.GroupBox1.Controls.Add(Me.Label15)
    Me.GroupBox1.Controls.Add(Me.TxtInterest)
    Me.GroupBox1.Controls.Add(Me.Label19)
    Me.GroupBox1.Controls.Add(Me.TxtIncome)
    Me.GroupBox1.Controls.Add(Me.Label25)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(15, 328)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(750, 151)
    Me.GroupBox1.TabIndex = 188
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "7. Income Received during last calendar year"
    '
    'Label55
    '
    Me.Label55.AutoSize = True
    Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label55.Location = New System.Drawing.Point(17, 123)
    Me.Label55.Name = "Label55"
    Me.Label55.Size = New System.Drawing.Size(286, 13)
    Me.Label55.TabIndex = 54
    Me.Label55.Text = "Disability Payments, and any other income not listed above."
    '
    'Label48
    '
    Me.Label48.AutoSize = True
    Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label48.Location = New System.Drawing.Point(17, 109)
    Me.Label48.Name = "Label48"
    Me.Label48.Size = New System.Drawing.Size(479, 13)
    Me.Label48.TabIndex = 53
    Me.Label48.Text = "State of Connecticut public assistance payments, General Assistance, Veteran's Pe" &
    "nsions, Veteran's"
    '
    'LblTotal
    '
    Me.LblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotal.Location = New System.Drawing.Point(673, 123)
    Me.LblTotal.Name = "LblTotal"
    Me.LblTotal.Size = New System.Drawing.Size(64, 18)
    Me.LblTotal.TabIndex = 52
    Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label21
    '
    Me.Label21.AutoSize = True
    Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label21.Location = New System.Drawing.Point(603, 126)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(58, 13)
    Me.Label21.TabIndex = 50
    Me.Label21.Text = "E: TOTAL "
    Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'TxtOther
    '
    Me.TxtOther.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOther.Location = New System.Drawing.Point(673, 99)
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
    Me.Label20.Location = New System.Drawing.Point(6, 93)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(502, 13)
    Me.Label20.TabIndex = 49
    Me.Label20.Text = "D: ANY INCOME NOT REFLECTED IN THE ABOVE - Examples: Federal Supplemental Securit" &
    "y Income,"
    '
    'TxtSSRR
    '
    Me.TxtSSRR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSSRR.Location = New System.Drawing.Point(673, 73)
    Me.TxtSSRR.MaxLength = 11
    Me.TxtSSRR.Name = "TxtSSRR"
    Me.TxtSSRR.Size = New System.Drawing.Size(66, 20)
    Me.TxtSSRR.TabIndex = 46
    Me.TxtSSRR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label15
    '
    Me.Label15.AutoSize = True
    Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label15.Location = New System.Drawing.Point(7, 70)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(524, 13)
    Me.Label15.TabIndex = 47
    Me.Label15.Text = "C: SOCIAL SECURITY OR RAILROAD RETIREMENT INCOME - Add Medicare premiums (Attach " &
    "SSA 1099)"
    '
    'TxtInterest
    '
    Me.TxtInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtInterest.Location = New System.Drawing.Point(673, 47)
    Me.TxtInterest.MaxLength = 11
    Me.TxtInterest.Name = "TxtInterest"
    Me.TxtInterest.Size = New System.Drawing.Size(66, 20)
    Me.TxtInterest.TabIndex = 44
    Me.TxtInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label19
    '
    Me.Label19.AutoSize = True
    Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label19.Location = New System.Drawing.Point(6, 47)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(418, 13)
    Me.Label19.TabIndex = 45
    Me.Label19.Text = "B: NON-TAXABLE INTEREST - Example: Interest from Tax Exempt Government Bonds"
    '
    'TxtIncome
    '
    Me.TxtIncome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtIncome.Location = New System.Drawing.Point(673, 21)
    Me.TxtIncome.MaxLength = 11
    Me.TxtIncome.Name = "TxtIncome"
    Me.TxtIncome.Size = New System.Drawing.Size(66, 20)
    Me.TxtIncome.TabIndex = 0
    Me.TxtIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label25
    '
    Me.Label25.AutoSize = True
    Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label25.Location = New System.Drawing.Point(7, 21)
    Me.Label25.Name = "Label25"
    Me.Label25.Size = New System.Drawing.Size(654, 13)
    Me.Label25.TabIndex = 43
    Me.Label25.Text = "A. GROSS INCOME Includes Federal Gross Income, wages, lottery winnings, taxable p" &
    "ensions, IRA, interest, dividends and rental income"
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.RbCivil)
    Me.GroupBox4.Controls.Add(Me.RbSurviving)
    Me.GroupBox4.Controls.Add(Me.RbUnmarried)
    Me.GroupBox4.Controls.Add(Me.RbMarried)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(11, 232)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(544, 38)
    Me.GroupBox4.TabIndex = 189
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "5. Filing Status"
    '
    'RbCivil
    '
    Me.RbCivil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCivil.Location = New System.Drawing.Point(170, 16)
    Me.RbCivil.Name = "RbCivil"
    Me.RbCivil.Size = New System.Drawing.Size(91, 18)
    Me.RbCivil.TabIndex = 3
    Me.RbCivil.Text = "Civil Union"
    '
    'RbSurviving
    '
    Me.RbSurviving.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSurviving.Location = New System.Drawing.Point(267, 14)
    Me.RbSurviving.Name = "RbSurviving"
    Me.RbSurviving.Size = New System.Drawing.Size(271, 18)
    Me.RbSurviving.TabIndex = 2
    Me.RbSurviving.Text = "Surviving Spouse (Age 50 to 65) Proof Required"
    '
    'RbUnmarried
    '
    Me.RbUnmarried.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbUnmarried.Location = New System.Drawing.Point(82, 16)
    Me.RbUnmarried.Name = "RbUnmarried"
    Me.RbUnmarried.Size = New System.Drawing.Size(82, 18)
    Me.RbUnmarried.TabIndex = 1
    Me.RbUnmarried.Text = "Unmarried"
    '
    'RbMarried
    '
    Me.RbMarried.Checked = True
    Me.RbMarried.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbMarried.Location = New System.Drawing.Point(8, 16)
    Me.RbMarried.Name = "RbMarried"
    Me.RbMarried.Size = New System.Drawing.Size(68, 18)
    Me.RbMarried.TabIndex = 0
    Me.RbMarried.TabStop = True
    Me.RbMarried.Text = "Married"
    '
    'TxtOwner
    '
    Me.TxtOwner.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOwner.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOwner.Location = New System.Drawing.Point(631, 206)
    Me.TxtOwner.MaxLength = 35
    Me.TxtOwner.Name = "TxtOwner"
    Me.TxtOwner.Size = New System.Drawing.Size(191, 20)
    Me.TxtOwner.TabIndex = 198
    '
    'TxtMZip
    '
    Me.TxtMZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMZip.Location = New System.Drawing.Point(571, 167)
    Me.TxtMZip.MaxLength = 5
    Me.TxtMZip.Name = "TxtMZip"
    Me.TxtMZip.Size = New System.Drawing.Size(40, 20)
    Me.TxtMZip.TabIndex = 193
    '
    'TxtMState
    '
    Me.TxtMState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMState.Location = New System.Drawing.Point(541, 167)
    Me.TxtMState.MaxLength = 2
    Me.TxtMState.Name = "TxtMState"
    Me.TxtMState.Size = New System.Drawing.Size(24, 20)
    Me.TxtMState.TabIndex = 192
    '
    'TxtPState
    '
    Me.TxtPState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPState.Location = New System.Drawing.Point(541, 206)
    Me.TxtPState.MaxLength = 2
    Me.TxtPState.Name = "TxtPState"
    Me.TxtPState.Size = New System.Drawing.Size(24, 20)
    Me.TxtPState.TabIndex = 196
    '
    'TxtPZip
    '
    Me.TxtPZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPZip.Location = New System.Drawing.Point(571, 206)
    Me.TxtPZip.MaxLength = 5
    Me.TxtPZip.Name = "TxtPZip"
    Me.TxtPZip.Size = New System.Drawing.Size(40, 20)
    Me.TxtPZip.TabIndex = 197
    '
    'TxtPAddr
    '
    Me.TxtPAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPAddr.Location = New System.Drawing.Point(10, 206)
    Me.TxtPAddr.MaxLength = 40
    Me.TxtPAddr.Name = "TxtPAddr"
    Me.TxtPAddr.Size = New System.Drawing.Size(325, 20)
    Me.TxtPAddr.TabIndex = 194
    '
    'TxtMAddr
    '
    Me.TxtMAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMAddr.Location = New System.Drawing.Point(10, 167)
    Me.TxtMAddr.MaxLength = 40
    Me.TxtMAddr.Name = "TxtMAddr"
    Me.TxtMAddr.Size = New System.Drawing.Size(325, 20)
    Me.TxtMAddr.TabIndex = 190
    '
    'TxtPCity
    '
    Me.TxtPCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPCity.Location = New System.Drawing.Point(341, 206)
    Me.TxtPCity.MaxLength = 25
    Me.TxtPCity.Name = "TxtPCity"
    Me.TxtPCity.Size = New System.Drawing.Size(191, 20)
    Me.TxtPCity.TabIndex = 195
    '
    'TxtMCity
    '
    Me.TxtMCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMCity.Location = New System.Drawing.Point(341, 167)
    Me.TxtMCity.MaxLength = 25
    Me.TxtMCity.Name = "TxtMCity"
    Me.TxtMCity.Size = New System.Drawing.Size(191, 20)
    Me.TxtMCity.TabIndex = 191
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(628, 190)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(160, 13)
    Me.Label12.TabIndex = 207
    Me.Label12.Text = "Other Name on property (Owner)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
    '
    'Label14
    '
    Me.Label14.AutoSize = True
    Me.Label14.Location = New System.Drawing.Point(576, 190)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(25, 13)
    Me.Label14.TabIndex = 206
    Me.Label14.Text = "Zip "
    '
    'Label16
    '
    Me.Label16.AutoSize = True
    Me.Label16.Location = New System.Drawing.Point(538, 190)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(32, 13)
    Me.Label16.TabIndex = 205
    Me.Label16.Text = "State"
    '
    'Label17
    '
    Me.Label17.AutoSize = True
    Me.Label17.Location = New System.Drawing.Point(338, 190)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(66, 13)
    Me.Label17.TabIndex = 204
    Me.Label17.Text = "City or Town"
    '
    'Label35
    '
    Me.Label35.AutoSize = True
    Me.Label35.Location = New System.Drawing.Point(7, 190)
    Me.Label35.Name = "Label35"
    Me.Label35.Size = New System.Drawing.Size(176, 13)
    Me.Label35.TabIndex = 203
    Me.Label35.Text = "4. Property Address (only if different)"
    '
    'Label59
    '
    Me.Label59.AutoSize = True
    Me.Label59.Location = New System.Drawing.Point(576, 151)
    Me.Label59.Name = "Label59"
    Me.Label59.Size = New System.Drawing.Size(25, 13)
    Me.Label59.TabIndex = 202
    Me.Label59.Text = "Zip "
    '
    'Label63
    '
    Me.Label63.AutoSize = True
    Me.Label63.Location = New System.Drawing.Point(538, 151)
    Me.Label63.Name = "Label63"
    Me.Label63.Size = New System.Drawing.Size(32, 13)
    Me.Label63.TabIndex = 201
    Me.Label63.Text = "State"
    '
    'Label64
    '
    Me.Label64.AutoSize = True
    Me.Label64.Location = New System.Drawing.Point(338, 151)
    Me.Label64.Name = "Label64"
    Me.Label64.Size = New System.Drawing.Size(66, 13)
    Me.Label64.TabIndex = 200
    Me.Label64.Text = "City or Town"
    '
    'Label65
    '
    Me.Label65.AutoSize = True
    Me.Label65.Location = New System.Drawing.Point(7, 151)
    Me.Label65.Name = "Label65"
    Me.Label65.Size = New System.Drawing.Size(93, 13)
    Me.Label65.TabIndex = 199
    Me.Label65.Text = "3. Mailing Address"
    '
    'ChkDisabled
    '
    Me.ChkDisabled.AutoSize = True
    Me.ChkDisabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkDisabled.Location = New System.Drawing.Point(486, 276)
    Me.ChkDisabled.Name = "ChkDisabled"
    Me.ChkDisabled.Size = New System.Drawing.Size(158, 17)
    Me.ChkDisabled.TabIndex = 209
    Me.ChkDisabled.Text = "Is applicant totally disabled?"
    Me.ChkDisabled.UseVisualStyleBackColor = True
    '
    'ChkNursingHome
    '
    Me.ChkNursingHome.AutoSize = True
    Me.ChkNursingHome.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkNursingHome.Location = New System.Drawing.Point(15, 276)
    Me.ChkNursingHome.Name = "ChkNursingHome"
    Me.ChkNursingHome.Size = New System.Drawing.Size(429, 17)
    Me.ChkNursingHome.TabIndex = 208
    Me.ChkNursingHome.Text = "Is spouse a resident of a health care or a nursing home facility in CT and on Tit" &
    "le XIX?"
    Me.ChkNursingHome.UseVisualStyleBackColor = True
    '
    'ChkTaxReturn
    '
    Me.ChkTaxReturn.AutoSize = True
    Me.ChkTaxReturn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkTaxReturn.Location = New System.Drawing.Point(15, 296)
    Me.ChkTaxReturn.Name = "ChkTaxReturn"
    Me.ChkTaxReturn.Size = New System.Drawing.Size(258, 17)
    Me.ChkTaxReturn.TabIndex = 210
    Me.ChkTaxReturn.Text = "6. Filed a Federal Tax Return for Grand List year?"
    Me.ChkTaxReturn.UseVisualStyleBackColor = True
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.LblGross)
    Me.GroupBox3.Controls.Add(Me.Label3)
    Me.GroupBox3.Controls.Add(Me.LblAppGross)
    Me.GroupBox3.Controls.Add(Me.LblNet)
    Me.GroupBox3.Controls.Add(Me.Label8)
    Me.GroupBox3.Controls.Add(Me.TxtAddlVet)
    Me.GroupBox3.Controls.Add(Me.Label9)
    Me.GroupBox3.Controls.Add(Me.TxtLocal)
    Me.GroupBox3.Controls.Add(Me.Label18)
    Me.GroupBox3.Controls.Add(Me.Label32)
    Me.GroupBox3.Controls.Add(Me.Label66)
    Me.GroupBox3.Controls.Add(Me.TxtVet)
    Me.GroupBox3.Controls.Add(Me.TxtDisabled)
    Me.GroupBox3.Controls.Add(Me.TxtBlind)
    Me.GroupBox3.Controls.Add(Me.Label69)
    Me.GroupBox3.Controls.Add(Me.Label70)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(155, 144)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(238, 211)
    Me.GroupBox3.TabIndex = 224
    Me.GroupBox3.TabStop = False
    '
    'LblGross
    '
    Me.LblGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblGross.Location = New System.Drawing.Point(166, 13)
    Me.LblGross.Name = "LblGross"
    Me.LblGross.Size = New System.Drawing.Size(66, 18)
    Me.LblGross.TabIndex = 174
    Me.LblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(10, 18)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(150, 13)
    Me.Label3.TabIndex = 173
    Me.Label3.Text = "Gross Assessment"
    '
    'LblAppGross
    '
    Me.LblAppGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAppGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAppGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAppGross.Location = New System.Drawing.Point(166, 37)
    Me.LblAppGross.Name = "LblAppGross"
    Me.LblAppGross.Size = New System.Drawing.Size(66, 18)
    Me.LblAppGross.TabIndex = 172
    Me.LblAppGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblNet
    '
    Me.LblNet.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNet.Location = New System.Drawing.Point(166, 186)
    Me.LblNet.Name = "LblNet"
    Me.LblNet.Size = New System.Drawing.Size(66, 18)
    Me.LblNet.TabIndex = 171
    Me.LblNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label8
    '
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(10, 162)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(138, 16)
    Me.Label8.TabIndex = 57
    Me.Label8.Text = "Addl Vets Exemption"
    '
    'TxtAddlVet
    '
    Me.TxtAddlVet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAddlVet.Location = New System.Drawing.Point(166, 159)
    Me.TxtAddlVet.MaxLength = 8
    Me.TxtAddlVet.Name = "TxtAddlVet"
    Me.TxtAddlVet.Size = New System.Drawing.Size(66, 20)
    Me.TxtAddlVet.TabIndex = 56
    Me.TxtAddlVet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label9
    '
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(10, 138)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(138, 16)
    Me.Label9.TabIndex = 55
    Me.Label9.Text = "Local  Exemption"
    '
    'TxtLocal
    '
    Me.TxtLocal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocal.Location = New System.Drawing.Point(166, 135)
    Me.TxtLocal.MaxLength = 8
    Me.TxtLocal.Name = "TxtLocal"
    Me.TxtLocal.Size = New System.Drawing.Size(66, 20)
    Me.TxtLocal.TabIndex = 54
    Me.TxtLocal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label18
    '
    Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label18.Location = New System.Drawing.Point(10, 114)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(138, 16)
    Me.Label18.TabIndex = 53
    Me.Label18.Text = "Veterans Exemption"
    '
    'Label32
    '
    Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label32.Location = New System.Drawing.Point(10, 90)
    Me.Label32.Name = "Label32"
    Me.Label32.Size = New System.Drawing.Size(138, 16)
    Me.Label32.TabIndex = 52
    Me.Label32.Text = "Disabled Exemption"
    '
    'Label66
    '
    Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label66.Location = New System.Drawing.Point(6, 188)
    Me.Label66.Name = "Label66"
    Me.Label66.Size = New System.Drawing.Size(141, 20)
    Me.Label66.TabIndex = 50
    Me.Label66.Text = "11. Net Assessment"
    Me.Label66.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'TxtVet
    '
    Me.TxtVet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVet.Location = New System.Drawing.Point(166, 111)
    Me.TxtVet.MaxLength = 8
    Me.TxtVet.Name = "TxtVet"
    Me.TxtVet.Size = New System.Drawing.Size(66, 20)
    Me.TxtVet.TabIndex = 48
    Me.TxtVet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtDisabled
    '
    Me.TxtDisabled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDisabled.Location = New System.Drawing.Point(166, 87)
    Me.TxtDisabled.MaxLength = 8
    Me.TxtDisabled.Name = "TxtDisabled"
    Me.TxtDisabled.Size = New System.Drawing.Size(66, 20)
    Me.TxtDisabled.TabIndex = 46
    Me.TxtDisabled.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtBlind
    '
    Me.TxtBlind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBlind.Location = New System.Drawing.Point(166, 63)
    Me.TxtBlind.MaxLength = 8
    Me.TxtBlind.Name = "TxtBlind"
    Me.TxtBlind.Size = New System.Drawing.Size(66, 20)
    Me.TxtBlind.TabIndex = 44
    Me.TxtBlind.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label69
    '
    Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label69.Location = New System.Drawing.Point(10, 63)
    Me.Label69.Name = "Label69"
    Me.Label69.Size = New System.Drawing.Size(138, 16)
    Me.Label69.TabIndex = 45
    Me.Label69.Text = "Blind Exemption"
    '
    'Label70
    '
    Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label70.Location = New System.Drawing.Point(10, 42)
    Me.Label70.Name = "Label70"
    Me.Label70.Size = New System.Drawing.Size(150, 16)
    Me.Label70.TabIndex = 43
    Me.Label70.Text = "Applicant Gross Assessment"
    '
    'Label71
    '
    Me.Label71.Location = New System.Drawing.Point(124, 365)
    Me.Label71.Name = "Label71"
    Me.Label71.Size = New System.Drawing.Size(94, 17)
    Me.Label71.TabIndex = 230
    Me.Label71.Text = "13. Frozen Tax"
    '
    'TxtFrzTax
    '
    Me.TxtFrzTax.Location = New System.Drawing.Point(127, 387)
    Me.TxtFrzTax.MaxLength = 9
    Me.TxtFrzTax.Name = "TxtFrzTax"
    Me.TxtFrzTax.Size = New System.Drawing.Size(77, 20)
    Me.TxtFrzTax.TabIndex = 225
    Me.TxtFrzTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblMillRate
    '
    Me.LblMillRate.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblMillRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblMillRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMillRate.Location = New System.Drawing.Point(29, 389)
    Me.LblMillRate.Name = "LblMillRate"
    Me.LblMillRate.Size = New System.Drawing.Size(77, 18)
    Me.LblMillRate.TabIndex = 228
    Me.LblMillRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label73
    '
    Me.Label73.Location = New System.Drawing.Point(26, 365)
    Me.Label73.Name = "Label73"
    Me.Label73.Size = New System.Drawing.Size(73, 17)
    Me.Label73.TabIndex = 226
    Me.Label73.Text = "12. Mill Rate"
    '
    'DtPckReceived
    '
    Me.DtPckReceived.Checked = False
    Me.DtPckReceived.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckReceived.Location = New System.Drawing.Point(29, 117)
    Me.DtPckReceived.Name = "DtPckReceived"
    Me.DtPckReceived.ShowCheckBox = True
    Me.DtPckReceived.Size = New System.Drawing.Size(98, 20)
    Me.DtPckReceived.TabIndex = 234
    '
    'Label33
    '
    Me.Label33.Location = New System.Drawing.Point(13, 98)
    Me.Label33.Name = "Label33"
    Me.Label33.Size = New System.Drawing.Size(123, 15)
    Me.Label33.TabIndex = 233
    Me.Label33.Text = "9. Application Received"
    '
    'TxtPropPct
    '
    Me.TxtPropPct.Location = New System.Drawing.Point(246, 118)
    Me.TxtPropPct.MaxLength = 6
    Me.TxtPropPct.Name = "TxtPropPct"
    Me.TxtPropPct.Size = New System.Drawing.Size(47, 20)
    Me.TxtPropPct.TabIndex = 231
    '
    'Label37
    '
    Me.Label37.AutoSize = True
    Me.Label37.Location = New System.Drawing.Point(160, 98)
    Me.Label37.Name = "Label37"
    Me.Label37.Size = New System.Drawing.Size(255, 13)
    Me.Label37.TabIndex = 232
    Me.Label37.Text = "10. Total Percentage of property owned by applicant"
    '
    'GroupBox7
    '
    Me.GroupBox7.Controls.Add(Me.LblExcd7)
    Me.GroupBox7.Controls.Add(Me.LblExam7)
    Me.GroupBox7.Controls.Add(Me.LblExcd6)
    Me.GroupBox7.Controls.Add(Me.LblExam6)
    Me.GroupBox7.Controls.Add(Me.LblExcd5)
    Me.GroupBox7.Controls.Add(Me.LblExam5)
    Me.GroupBox7.Controls.Add(Me.LblExcd4)
    Me.GroupBox7.Controls.Add(Me.LblExam4)
    Me.GroupBox7.Controls.Add(Me.LblExcd3)
    Me.GroupBox7.Controls.Add(Me.LblExam3)
    Me.GroupBox7.Controls.Add(Me.LblExcd2)
    Me.GroupBox7.Controls.Add(Me.LblExam2)
    Me.GroupBox7.Controls.Add(Me.LblExcd1)
    Me.GroupBox7.Controls.Add(Me.LblExam1)
    Me.GroupBox7.Location = New System.Drawing.Point(7, 195)
    Me.GroupBox7.Name = "GroupBox7"
    Me.GroupBox7.Size = New System.Drawing.Size(122, 146)
    Me.GroupBox7.TabIndex = 237
    Me.GroupBox7.TabStop = False
    Me.GroupBox7.Text = "RE Exemption Info"
    '
    'LblExcd7
    '
    Me.LblExcd7.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExcd7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExcd7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExcd7.Location = New System.Drawing.Point(6, 124)
    Me.LblExcd7.Name = "LblExcd7"
    Me.LblExcd7.Size = New System.Drawing.Size(35, 18)
    Me.LblExcd7.TabIndex = 207
    Me.LblExcd7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExam7
    '
    Me.LblExam7.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExam7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExam7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExam7.Location = New System.Drawing.Point(47, 124)
    Me.LblExam7.Name = "LblExam7"
    Me.LblExam7.Size = New System.Drawing.Size(66, 18)
    Me.LblExam7.TabIndex = 206
    Me.LblExam7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExcd6
    '
    Me.LblExcd6.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExcd6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExcd6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExcd6.Location = New System.Drawing.Point(6, 106)
    Me.LblExcd6.Name = "LblExcd6"
    Me.LblExcd6.Size = New System.Drawing.Size(35, 18)
    Me.LblExcd6.TabIndex = 205
    Me.LblExcd6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExam6
    '
    Me.LblExam6.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExam6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExam6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExam6.Location = New System.Drawing.Point(47, 106)
    Me.LblExam6.Name = "LblExam6"
    Me.LblExam6.Size = New System.Drawing.Size(66, 18)
    Me.LblExam6.TabIndex = 204
    Me.LblExam6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExcd5
    '
    Me.LblExcd5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExcd5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExcd5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExcd5.Location = New System.Drawing.Point(6, 88)
    Me.LblExcd5.Name = "LblExcd5"
    Me.LblExcd5.Size = New System.Drawing.Size(35, 18)
    Me.LblExcd5.TabIndex = 203
    Me.LblExcd5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExam5
    '
    Me.LblExam5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExam5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExam5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExam5.Location = New System.Drawing.Point(47, 88)
    Me.LblExam5.Name = "LblExam5"
    Me.LblExam5.Size = New System.Drawing.Size(66, 18)
    Me.LblExam5.TabIndex = 202
    Me.LblExam5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExcd4
    '
    Me.LblExcd4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExcd4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExcd4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExcd4.Location = New System.Drawing.Point(6, 70)
    Me.LblExcd4.Name = "LblExcd4"
    Me.LblExcd4.Size = New System.Drawing.Size(35, 18)
    Me.LblExcd4.TabIndex = 201
    Me.LblExcd4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExam4
    '
    Me.LblExam4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExam4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExam4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExam4.Location = New System.Drawing.Point(47, 70)
    Me.LblExam4.Name = "LblExam4"
    Me.LblExam4.Size = New System.Drawing.Size(66, 18)
    Me.LblExam4.TabIndex = 200
    Me.LblExam4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExcd3
    '
    Me.LblExcd3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExcd3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExcd3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExcd3.Location = New System.Drawing.Point(6, 52)
    Me.LblExcd3.Name = "LblExcd3"
    Me.LblExcd3.Size = New System.Drawing.Size(35, 18)
    Me.LblExcd3.TabIndex = 199
    Me.LblExcd3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExam3
    '
    Me.LblExam3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExam3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExam3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExam3.Location = New System.Drawing.Point(47, 52)
    Me.LblExam3.Name = "LblExam3"
    Me.LblExam3.Size = New System.Drawing.Size(66, 18)
    Me.LblExam3.TabIndex = 198
    Me.LblExam3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExcd2
    '
    Me.LblExcd2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExcd2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExcd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExcd2.Location = New System.Drawing.Point(6, 34)
    Me.LblExcd2.Name = "LblExcd2"
    Me.LblExcd2.Size = New System.Drawing.Size(35, 18)
    Me.LblExcd2.TabIndex = 197
    Me.LblExcd2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExam2
    '
    Me.LblExam2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExam2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExam2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExam2.Location = New System.Drawing.Point(47, 34)
    Me.LblExam2.Name = "LblExam2"
    Me.LblExam2.Size = New System.Drawing.Size(66, 18)
    Me.LblExam2.TabIndex = 196
    Me.LblExam2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExcd1
    '
    Me.LblExcd1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExcd1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExcd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExcd1.Location = New System.Drawing.Point(6, 16)
    Me.LblExcd1.Name = "LblExcd1"
    Me.LblExcd1.Size = New System.Drawing.Size(35, 18)
    Me.LblExcd1.TabIndex = 195
    Me.LblExcd1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExam1
    '
    Me.LblExam1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExam1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExam1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExam1.Location = New System.Drawing.Point(47, 16)
    Me.LblExam1.Name = "LblExam1"
    Me.LblExam1.Size = New System.Drawing.Size(66, 18)
    Me.LblExam1.TabIndex = 194
    Me.LblExam1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtPGross
    '
    Me.TxtPGross.Location = New System.Drawing.Point(29, 164)
    Me.TxtPGross.MaxLength = 9
    Me.TxtPGross.Name = "TxtPGross"
    Me.TxtPGross.Size = New System.Drawing.Size(77, 20)
    Me.TxtPGross.TabIndex = 235
    Me.TxtPGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label51
    '
    Me.Label51.Location = New System.Drawing.Point(13, 146)
    Me.Label51.Name = "Label51"
    Me.Label51.Size = New System.Drawing.Size(123, 15)
    Me.Label51.TabIndex = 236
    Me.Label51.Text = "Property Gross Asmnt"
    '
    'FrmTO221C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(836, 581)
    Me.Controls.Add(Me.Tab1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTO221C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Tab1.ResumeLayout(False)
    Me.TpApplicant.ResumeLayout(False)
    Me.TpApplicant.PerformLayout()
    Me.GrpType.ResumeLayout(False)
    Me.GrpType.PerformLayout()
    Me.GroupBox6.ResumeLayout(False)
    Me.GroupBox6.PerformLayout()
    Me.TpAssessor.ResumeLayout(False)
    Me.TpAssessor.PerformLayout()
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox7.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmTO221C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXFREEZE = New TXFREEZE.MyData(myDBConnect)
    MyTXREALC = New TXREALC.MyData(myDBConnect)
    MyTXREAA = New TXREAA.MyData(myDBConnect)
    MyTXMRATE = New TXMRATE.MyData(myDBConnect)
    MyTPAYMNT = New TPAYMNT.MyData(myDBConnect)
    MyTXM35H = New TXM35H.MyData(myDBConnect)
    MyTXM35EX = New TXM35EX.MyData(myDBConnect)
    MyTXLOCAL = New TXLOCAL.MyData(myDBConnect)

    LoadScrn = True
    TxtListNo.Focus()
    MyFrmTO221.TBarNew.Enabled = False

    AddMode = False
    MyFrmTO221.TBarPrint.Enabled = True
    If WrkListNo > 0 Then
      Me.Text = "Maintain " & Me.Text
      If Trim(TxtALName.Text) = "" Then
        MyFrmTO221.TBarSave.Enabled = True
        MyFrmTO221.TBarDelete.Enabled = True
      End If
      TxtListNo.Text = WrkListNo
      LnkListNo.Enabled = False
      TxtListNo.ReadOnly = True
      TxtYear.ReadOnly = True
      DtPckSigned.Value = Date.Today
      DtPckReceived.Value = Date.Today
      DtPckAssr.Value = Date.Today
      MyTXFREEZE.GetOneRecordP(WrkListNo, WrkType, WrkYear)
      If MyTXFREEZE.RecordNotFound Then
        MyFrmTO221.TBarNew.Enabled = False
        MyFrmTO221.TBarSave.Enabled = False
        MyFrmTO221.TBarDelete.Enabled = False
        MyFrmTO221.TBarPrint.Enabled = False
        Me.ErrProv.SetError(TxtListNo, "Record not found")
        Exit Sub
      End If

      With MyTXFREEZE
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
        TxtMAddr.Text = Trim(._MADDR)
        TxtMCity.Text = Trim(._MCITY)
        TxtMState.Text = Trim(._MSTATE)
        If ._MZIP > 0 Then
          TxtMZip.Text = Format(._MZIP, "00000")
        End If
        TxtPAddr.Text = Trim(._PADDR)
        TxtPCity.Text = Trim(._PCITY)
        TxtPState.Text = Trim(._PSTATE)
        If ._PZIP > 0 Then
          TxtPZip.Text = Format(._PZIP, "00000")
        End If
        Select Case Trim(._FILING)
          Case "C"
            RbCivil.Checked = True
          Case "M"
            RbMarried.Checked = True
          Case "U"
            RbUnmarried.Checked = True
          Case "S"
            RbSurviving.Checked = True
        End Select
        ChkNursingHome.Checked = False
        If Trim(._NRSHOM) = "Y" Then
          ChkNursingHome.Checked = True
        End If
        ChkDisabled.Checked = False
        If Trim(._DISAB) = "Y" Then
          ChkDisabled.Checked = True
        End If
        ChkTaxReturn.Checked = False
        If Trim(._TAXRTN) = "Y" Then
          ChkTaxReturn.Checked = True
        End If
        DtPckSigned.Value = MyUtils.GetDBDate(._DTSIGN)
        If ._PHONE > 0 Then
          MskTxtPhone.Text = ._PHONE
        End If
        TxtPropPct.Text = ._PROPCT
        TxtIncome.Text = Format(._INCOME, "Fixed")
        TxtInterest.Text = Format(._INT, "Fixed")
        TxtSSRR.Text = Format(._SSRR, "Fixed")
        TxtOther.Text = Format(._OTHER, "Fixed")
        DtPckSigned.Value = MyUtils.GetDBDate(._DTSIGN)
        If ._PHONE > 0 Then
          MskTxtPhone.Text = ._PHONE
        End If
        TxtRelate.Text = Trim(._RELATE)
        'Assessor
        If ._DTRECV > 0 Then
          DtPckReceived.Value = MyUtils.GetDBDate(._DTRECV)
          DtPckReceived.Checked = True
        End If
        LblListNo.Text = ._LISTNO
        LblYear.Text = ._YEAR
        LblALName.Text = Trim(._ALNAME)
        LblAFName.Text = Trim(._AFNAME)
        LblAInit.Text = Trim(._AINIT)
        TxtPropPct.Text = ._PROPCT
        TxtPGross.Text = ._PGROSS
        LblGross.Text = MyUtils.Round(._PGROSS * (._PROPCT / 100), 0)
        LblAppGross.Text = ._GROSS
        TxtBlind.Text = ._XBLIND
        TxtDisabled.Text = ._XDISAB
        TxtVet.Text = ._XVET
        TxtLocal.Text = ._XLOCAL
        TxtAddlVet.Text = ._XADDL
        LblNet.Text = ._NET
        TxtFrzTax.Text = Format(._FRZTAX, "Fixed")
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
      GetTXREAA()
      If Not WrkFoundArchive Then
        GetTXREALC(False)
      End If
      GetMillRate(WrkYear)
    Else
      Me.Text = "Add " & Me.Text
      AddMode = True
      TxtPropPct.Text = "100"
      MyFrmTO221.TBarDelete.Enabled = False
      MyFrmTO221.TBarSave.Enabled = True
    End If

    LoadScrn = False
  End Sub

  Private Sub FrmTO221C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTO221.TBarNew.Enabled = True
    MyFrmTO221.TBarSave.Enabled = False
    MyFrmTO221.TBarDelete.Enabled = False
    MyFrmTO221.TBarPrint.Enabled = False
    MyFrmTO221B.FormatGrid()
    MyFrmTO221B.Show()

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    MyTXFREEZE.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim WrkDevlt As String
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    WrkDevlt = ""
    MyTXFREEZE.GetOneRecordP(WrkListNo, WrkType, MyUtils.CnvSng(TxtYear.Text))
    If AddMode Then
      If Not MyTXFREEZE.RecordNotFound Then
        Me.ErrProv.SetError(TxtListNo, "Record already exists")
        Exit Sub
      End If
    End If

    If Not AddMode Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXFREEZE.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXFREEZE.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()
  End Sub
  Private Sub MoveToFile()
    With MyTXFREEZE
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
      ._MADDR = TxtMAddr.Text
      ._MCITY = TxtMCity.Text
      ._MSTATE = TxtMState.Text
      ._MZIP = MyUtils.CnvSng(TxtMZip.Text)
      ._PADDR = TxtPAddr.Text
      ._PCITY = TxtPCity.Text
      ._PSTATE = TxtPState.Text
      ._PZIP = MyUtils.CnvSng(TxtPZip.Text)
      ._OWNER = TxtOwner.Text
      If RbCivil.Checked Then ._FILING = "C"
      If RbMarried.Checked Then ._FILING = "M"
      If RbUnmarried.Checked Then ._FILING = "U"
      If RbSurviving.Checked Then ._FILING = "S"
      If ChkNursingHome.Checked Then
        ._NRSHOM = "Y"
      Else
        ._NRSHOM = "N"
      End If
      If ChkDisabled.Checked Then
        ._DISAB = "Y"
      Else
        ._DISAB = "N"
      End If
      If ChkTaxReturn.Checked Then
        ._TAXRTN = "Y"
      Else
        ._TAXRTN = "N"
      End If
      ._DTSIGN = MyUtils.SetDBDate(DtPckSigned.Value)
      ._PHONE = MyUtils.CnvSng(MskTxtPhone.Text)
      ._RELATE = Trim(TxtRelate.Text)
      ._INCOME = MyUtils.CnvSng(TxtIncome.Text)
      ._INT = MyUtils.CnvSng(TxtInterest.Text)
      ._SSRR = MyUtils.CnvSng(TxtSSRR.Text)
      ._OTHER = MyUtils.CnvSng(TxtOther.Text)
      'Assessor
      ._ALLOW = String.Empty
      If DtPckReceived.Checked Then
        ._DTRECV = MyUtils.SetDBDate(DtPckReceived.Value)
      Else
        ._DTRECV = 0
      End If
      ._PROPCT = MyUtils.CnvSng(TxtPropPct.Text)
      ._PGROSS = MyUtils.CnvSng(LblGross.Text)
      ._GROSS = MyUtils.CnvSng(LblAppGross.Text)
      ._PROPCT = MyUtils.CnvSng(TxtPropPct.Text)
      ._PGROSS = MyUtils.CnvSng(TxtPGross.Text)
      ._GROSS = MyUtils.CnvSng(LblAppGross.Text)
      ._XBLIND = MyUtils.CnvSng(TxtBlind.Text)
      ._XDISAB = MyUtils.CnvSng(TxtDisabled.Text)
      ._XVET = MyUtils.CnvSng(TxtVet.Text)
      ._XLOCAL = MyUtils.CnvSng(TxtLocal.Text)
      ._XADDL = MyUtils.CnvSng(TxtAddlVet.Text)
      ._NET = MyUtils.CnvSng(LblNet.Text)
      ._FRZTAX = MyUtils.CnvSng(TxtFrzTax.Text)
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

    If TxtPCity.Text = String.Empty Then
      ErrorField(I) = "city"
      ErrorMsg(I) = "City is required"
      I = I + 1
    End If

    If TxtPState.Text = String.Empty Then
      ErrorField(I) = "state"
      ErrorMsg(I) = "State is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtPZip.Text) = 0 Then
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
    ErrProv.SetError(TxtPCity, "")
    ErrProv.SetError(TxtPState, "")
    ErrProv.SetError(TxtPZip, "")
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
        Case "city"
          ErrProv.SetError(TxtPCity, ErrorMsg(I))
        Case "state"
          ErrProv.SetError(TxtPState, ErrorMsg(I))
        Case "zip"
          ErrProv.SetError(TxtPZip, ErrorMsg(I))
        Case "assr"
          ErrProv.SetError(DtPckAssr, ErrorMsg(I))
        Case ""
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub FrmTO221C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTO221.SbpScreen.Text = "TO221C"
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
  Private Sub TxtInterest_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIncome.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtSSRR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSSRR.KeyPress
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
  Private Sub TxtGross_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPGross.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBlind_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBlind.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDisabled_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDisabled.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtVet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVet.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtLocal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLocal.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAddlVet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAddlVet.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub TxtIncome_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIncome.TextChanged
    CalcTotal()
  End Sub
  Private Sub TxtInterest_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtInterest.TextChanged
    CalcTotal()
  End Sub
  Private Sub TxtSSRR_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSSRR.TextChanged
    CalcTotal()
  End Sub
  Private Sub TxtOther_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOther.TextChanged
    CalcTotal()
  End Sub
  Private Sub TxtBlind_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBlind.TextChanged
    CalcFreeze()
  End Sub
  Private Sub TxtDisabled_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDisabled.TextChanged
    CalcFreeze()
  End Sub
  Private Sub TxtVet_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVet.TextChanged
    CalcFreeze()
  End Sub
  Private Sub TxtLocal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtLocal.TextChanged
    CalcFreeze()
  End Sub
  Private Sub TxtAddlVet_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAddlVet.TextChanged
    CalcFreeze()
  End Sub
  Private Sub TxtPropPct_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPropPct.TextChanged
    If Not TxtPropPct.Modified Then Exit Sub
    CalcFreeze()
  End Sub
  Private Sub TxtPGross_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPGross.TextChanged
    CalcFreeze()
  End Sub
  Private Sub TxtListNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtListNo.LostFocus
    If TxtListNo.ReadOnly Then Exit Sub

    GetListNo()
  End Sub
  Private Sub TxtYear_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtYear.LostFocus
    If TxtListNo.ReadOnly Then Exit Sub

    GetMillRate(MyUtils.CnvSng(TxtYear.Text))
    GetTXFREEZE()
    GetTXM35H()
    CalcFreeze()
  End Sub
  Public Sub GetListNo()
    GetTXREALC(True)
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
        If Trim(._ADD1) <> WrkLoc Then
          TxtPAddr.Text = WrkLoc
        End If
        TxtMAddr.Text = Trim(._ADD1)
        TxtMCity.Text = Trim(._CITY)
        TxtMState.Text = Trim(._STATE)
        TxtMZip.Text = Format(._ZIP5, "00000")
        If ._CCNO > 0 Then
          TxtPGross.Text = ._CCGRS
          LblGross.Text = MyUtils.Round(._CCGRS * (MyUtils.CnvSng(TxtPropPct.Text) / 100), 0)
        Else
          TxtPGross.Text = ._GROSS
          LblGross.Text = MyUtils.Round(._GROSS * (MyUtils.CnvSng(TxtPropPct.Text) / 100), 0)
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
        'Exemption Information
        LblExcd1.Text = Trim(._CCCD1)
        LblExcd2.Text = Trim(._CCCD2)
        LblExcd3.Text = Trim(._CCCD3)
        LblExcd4.Text = Trim(._CCCD4)
        LblExcd5.Text = Trim(._CCCD5)
        LblExcd6.Text = Trim(._CCCD6)
        LblExcd7.Text = Trim(._CCCD7)
        If ._CEXA1 > 0 Then
          LblExam1.Text = ._CEXA1
          LblExam2.Text = ._CEXA2
          LblExam3.Text = ._CEXA3
          LblExam4.Text = ._CEXA4
          LblExam5.Text = ._CEXA5
          LblExam6.Text = ._CEXA6
          LblExam7.Text = ._CEXA7
        End If
      Else
        LblAppGross.Text = MyUtils.Round((._GROSS - WrkExcludeGross) * (MyUtils.CnvSng(TxtPropPct.Text) / 100), 0)
        'Exemption Information
        LblExcd1.Text = Trim(._EXCD1)
        LblExcd2.Text = Trim(._EXCD2)
        LblExcd3.Text = Trim(._EXCD3)
        LblExcd4.Text = Trim(._EXCD4)
        LblExcd5.Text = Trim(._EXCD5)
        LblExcd6.Text = Trim(._EXCD6)
        LblExcd7.Text = Trim(._EXCD7)
        If ._EXAM1 > 0 Then
          LblExam1.Text = ._EXAM1
          LblExam2.Text = ._EXAM2
          LblExam3.Text = ._EXAM3
          LblExam4.Text = ._EXAM4
          LblExam5.Text = ._EXAM5
          LblExam6.Text = ._EXAM6
          LblExam7.Text = ._EXAM7
        End If
      End If
      TxtBlind.Text = CalcCat("B")
      TxtDisabled.Text = CalcCat("D")
      TxtVet.Text = CalcCat("V")
      TxtLocal.Text = CalcCat("L") + CalcLocal()
      TxtAddlVet.Text = CalcCat("A")
    End With
  End Sub
  Private Function CalcLocal() As Integer
    Dim ds As DataSet = New DataSet
    Dim Total As Integer
    Dim I As Integer

    Total = 0
    ds = MyTXM35EX.GetAllCat("L", String.Empty)
    For I = 0 To ds.Tables(0).Rows.Count - 1
      MyTXLOCAL.GetOneRecordP(WrkListNo, WrkYear, "R", ds.Tables(0).Rows(I).Item("excd"))
      If Not MyTXLOCAL.RecordNotFound Then
        Total = Total + MyTXLOCAL._BENAMT
      End If
    Next

    Return Total
  End Function
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
    End With
  End Sub
  Private Sub CalcTotal()
    Dim WrkTotal As Decimal

    WrkTotal = MyUtils.CnvSng(TxtIncome.Text) + MyUtils.CnvSng(TxtInterest.Text) +
     MyUtils.CnvSng(TxtSSRR.Text) + MyUtils.CnvSng(TxtOther.Text)
    LblTotal.Text = Format(WrkTotal, "fixed")
  End Sub
  Private Function CalcCat(ByVal Cat As String) As Integer
    Dim Total As Integer
    Total = 0

    If Trim(MyTXREALC._EXCD1) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, MyTXREALC._EXCD1)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + MyTXREALC._EXAM1
      End If
    End If

    If Trim(MyTXREALC._EXCD2) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, MyTXREALC._EXCD2)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + MyTXREALC._EXAM2
      End If
    End If

    If Trim(MyTXREALC._EXCD3) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, MyTXREALC._EXCD3)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + MyTXREALC._EXAM3
      End If
    End If

    If Trim(MyTXREALC._EXCD4) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, MyTXREALC._EXCD4)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + MyTXREALC._EXAM4
      End If
    End If

    If Trim(MyTXREALC._EXCD5) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, MyTXREALC._EXCD5)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + MyTXREALC._EXAM5
      End If
    End If

    If Trim(MyTXREALC._EXCD6) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, MyTXREALC._EXCD6)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + MyTXREALC._EXAM6
      End If
    End If

    If Trim(MyTXREALC._EXCD7) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, MyTXREALC._EXCD7)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + MyTXREALC._EXAM7
      End If
    End If

    Return Total
  End Function
  Private Sub GetTXFREEZE()
    Dim pListNo As Integer
    pListNo = MyUtils.CnvSng(TxtListNo.Text)
    WrkYear = MyUtils.CnvSng(TxtYear.Text)
    MyTXFREEZE.GetOneRecordP(pListNo, WrkType, WrkYear - 1)
    If MyTXFREEZE.RecordNotFound Then
      MyTXFREEZE.GetOneRecordP(pListNo, WrkType, WrkYear - 2)
      If MyTXFREEZE.RecordNotFound Then
        MyFrmTO221.TBarDelete.Enabled = False
        LoadScrn = False
        Exit Sub
      End If
    End If
    'Get data from previous year
    With MyTXFREEZE
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
      TxtPAddr.Text = Trim(._PADDR)
      TxtPCity.Text = Trim(._PCITY)
      TxtPState.Text = Trim(._PSTATE)
      If ._PZIP > 0 Then
        TxtPZip.Text = Format(._PZIP, "00000")
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
        If TxtPCity.Text = "" Then
          TxtPCity.Text = Trim(._PCITY)
        End If
        If TxtPState.Text = "" Then
          TxtPState.Text = Trim(._PSTATE)
        End If
        If TxtPZip.Text = "" Then
          TxtPZip.Text = Format(._PZIP, "00000")
        End If
        If Trim(._MADDR) <> "" Then
          TxtMAddr.Text = Trim(._MADDR)
          TxtMCity.Text = Trim(._MCITY)
          TxtMState.Text = Trim(._MSTATE)
          TxtMZip.Text = Format(._MZIP, "00000")
        End If
        TxtIncome.Text = Format(._INCOME, "Fixed")
        TxtInterest.Text = Format(._INT, "Fixed")
        TxtSSRR.Text = Format(._SSRR, "Fixed")
        TxtOther.Text = Format(._OTHER, "Fixed")
      End If
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
  Private Sub CalcFreeze()
    Dim WrkAdjGross As Integer
    Dim WrkPropPct As Decimal
    Dim WrkTax As Decimal
    Dim WrkNet As Decimal
    WrkPropPct = MyUtils.CnvSng(TxtPropPct.Text) / 100
    LblGross.Text = MyUtils.Round(MyUtils.CnvSng(TxtPGross.Text) * WrkPropPct, 0)
    WrkAdjGross = MyUtils.CnvSng(LblGross.Text) - (WrkExcludeGross * WrkPropPct)
    LblAppGross.Text = MyUtils.Round(WrkAdjGross, 0)
    WrkNet = MyUtils.CnvSng(LblAppGross.Text) - MyUtils.CnvSng(TxtBlind.Text) - MyUtils.CnvSng(TxtDisabled.Text) -
    MyUtils.CnvSng(TxtVet.Text) - MyUtils.CnvSng(TxtLocal.Text) - MyUtils.CnvSng(TxtAddlVet.Text)
    LblNet.Text = WrkNet
    WrkNet = WrkNet * (MyUtils.CnvSng(TxtPropPct.Text) / 100)
    WrkTax = WrkNet * MyTXMRATE._MRRATE
    With MyTPAYMNT
      .In_Year = MyUtils.CnvSng(TxtYear.Text)
      .In_Type = "R"
      .In_Dst = 0
      .In_Phs = ""
      .In_TaxT = WrkTax
      .CalcPaySplit()
      WrkTax = .Out_TaxT
    End With
    TxtFrzTax.Text = Format(WrkTax, "fixed")
  End Sub

  Private Sub Tab1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tab1.Click
    LblListNo.Text = TxtListNo.Text
    LblTypeDesc.Text = RbRE.Text
    LblYear.Text = TxtYear.Text
  End Sub

  Private Sub TpApplicant_Click(sender As Object, e As EventArgs) Handles TpApplicant.Click

  End Sub
End Class


