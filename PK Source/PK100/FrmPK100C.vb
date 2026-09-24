Imports System.Text
Public Class FrmPK100C
  Inherits System.Windows.Forms.Form
  Dim myPKTICK As PKTICK.MyData
  Dim myPKCNTL As PKCNTL.MyData
  Dim myPKOFCR As PKOFCR.MyData
  Dim myPKVIOL As PKVIOL.MyData
  Friend WrkTickNo As Integer
  Friend AddMode As Boolean
  Friend WithEvents TxtOffcno As System.Windows.Forms.TextBox
  Friend WithEvents LnkOffcno As System.Windows.Forms.LinkLabel
  Friend WithEvents LblViAmt As System.Windows.Forms.Label
  Friend WithEvents TxtRegST As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtVehty As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtCity As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents TxtAddr As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents LblStatus As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtZip As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents TxtVtime As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents RbPM As System.Windows.Forms.RadioButton
  Friend WithEvents RbMI As System.Windows.Forms.RadioButton
  Friend WithEvents RbAM As System.Windows.Forms.RadioButton
  Friend WithEvents TxtStreet As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents TxtMeterNo As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents LblAppl As System.Windows.Forms.Label
  Friend WithEvents DtPckVdate As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtViol5 As System.Windows.Forms.TextBox
  Friend WithEvents LnkViol5 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtViol4 As System.Windows.Forms.TextBox
  Friend WithEvents LnkViol4 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtViol3 As System.Windows.Forms.TextBox
  Friend WithEvents LnkViol3 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtViol2 As System.Windows.Forms.TextBox
  Friend WithEvents LnkViol2 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtViol1 As System.Windows.Forms.TextBox
  Friend WithEvents LnkViol1 As System.Windows.Forms.LinkLabel
  Friend WithEvents LblViolDesc5 As System.Windows.Forms.Label
  Friend WithEvents LblViolDesc4 As System.Windows.Forms.Label
  Friend WithEvents LblViolDesc3 As System.Windows.Forms.Label
  Friend WithEvents LblViolDesc2 As System.Windows.Forms.Label
  Friend WithEvents LblViolDesc1 As System.Windows.Forms.Label
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
  Friend WithEvents TxtTickNo As System.Windows.Forms.TextBox
  Friend WithEvents TxtRegNo As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TxtTickNo = New System.Windows.Forms.TextBox()
    Me.TxtRegNo = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.LblViAmt = New System.Windows.Forms.Label()
    Me.TxtOffcno = New System.Windows.Forms.TextBox()
    Me.LnkOffcno = New System.Windows.Forms.LinkLabel()
    Me.TxtRegST = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtVehty = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtAddr = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.LblStatus = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TxtZip = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtVtime = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.RbAM = New System.Windows.Forms.RadioButton()
    Me.RbMI = New System.Windows.Forms.RadioButton()
    Me.RbPM = New System.Windows.Forms.RadioButton()
    Me.TxtMeterNo = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TxtStreet = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.LblAppl = New System.Windows.Forms.Label()
    Me.DtPckVdate = New System.Windows.Forms.DateTimePicker()
    Me.TxtViol1 = New System.Windows.Forms.TextBox()
    Me.LnkViol1 = New System.Windows.Forms.LinkLabel()
    Me.TxtViol2 = New System.Windows.Forms.TextBox()
    Me.LnkViol2 = New System.Windows.Forms.LinkLabel()
    Me.TxtViol3 = New System.Windows.Forms.TextBox()
    Me.LnkViol3 = New System.Windows.Forms.LinkLabel()
    Me.TxtViol4 = New System.Windows.Forms.TextBox()
    Me.LnkViol4 = New System.Windows.Forms.LinkLabel()
    Me.TxtViol5 = New System.Windows.Forms.TextBox()
    Me.LnkViol5 = New System.Windows.Forms.LinkLabel()
    Me.LblViolDesc1 = New System.Windows.Forms.Label()
    Me.LblViolDesc2 = New System.Windows.Forms.Label()
    Me.LblViolDesc3 = New System.Windows.Forms.Label()
    Me.LblViolDesc4 = New System.Windows.Forms.Label()
    Me.LblViolDesc5 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(17, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(47, 13)
    Me.Label1.TabIndex = 13
    Me.Label1.Text = "Ticket #"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtTickNo
    '
    Me.TxtTickNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTickNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTickNo.Location = New System.Drawing.Point(104, 8)
    Me.TxtTickNo.MaxLength = 6
    Me.TxtTickNo.Name = "TxtTickNo"
    Me.TxtTickNo.Size = New System.Drawing.Size(60, 22)
    Me.TxtTickNo.TabIndex = 0
    Me.TxtTickNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtRegNo
    '
    Me.TxtRegNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRegNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRegNo.Location = New System.Drawing.Point(103, 59)
    Me.TxtRegNo.MaxLength = 12
    Me.TxtRegNo.Name = "TxtRegNo"
    Me.TxtRegNo.Size = New System.Drawing.Size(104, 22)
    Me.TxtRegNo.TabIndex = 3
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(15, 63)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(80, 13)
    Me.Label5.TabIndex = 301
    Me.Label5.Text = "Registration No"
    '
    'LblViAmt
    '
    Me.LblViAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblViAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblViAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblViAmt.ForeColor = System.Drawing.Color.Black
    Me.LblViAmt.Location = New System.Drawing.Point(414, 33)
    Me.LblViAmt.Name = "LblViAmt"
    Me.LblViAmt.Size = New System.Drawing.Size(54, 16)
    Me.LblViAmt.TabIndex = 308
    Me.LblViAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtOffcno
    '
    Me.TxtOffcno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOffcno.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOffcno.Location = New System.Drawing.Point(103, 33)
    Me.TxtOffcno.MaxLength = 4
    Me.TxtOffcno.Name = "TxtOffcno"
    Me.TxtOffcno.Size = New System.Drawing.Size(42, 22)
    Me.TxtOffcno.TabIndex = 2
    '
    'LnkOffcno
    '
    Me.LnkOffcno.AutoSize = True
    Me.LnkOffcno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkOffcno.ForeColor = System.Drawing.Color.Maroon
    Me.LnkOffcno.Location = New System.Drawing.Point(17, 37)
    Me.LnkOffcno.Name = "LnkOffcno"
    Me.LnkOffcno.Size = New System.Drawing.Size(78, 13)
    Me.LnkOffcno.TabIndex = 1
    Me.LnkOffcno.TabStop = True
    Me.LnkOffcno.Text = "Officer Number"
    '
    'TxtRegST
    '
    Me.TxtRegST.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRegST.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRegST.Location = New System.Drawing.Point(285, 59)
    Me.TxtRegST.MaxLength = 2
    Me.TxtRegST.Name = "TxtRegST"
    Me.TxtRegST.Size = New System.Drawing.Size(24, 22)
    Me.TxtRegST.TabIndex = 4
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(224, 63)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(55, 13)
    Me.Label2.TabIndex = 328
    Me.Label2.Text = "Reg State"
    '
    'TxtVehty
    '
    Me.TxtVehty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVehty.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVehty.Location = New System.Drawing.Point(103, 85)
    Me.TxtVehty.MaxLength = 30
    Me.TxtVehty.Name = "TxtVehty"
    Me.TxtVehty.Size = New System.Drawing.Size(244, 22)
    Me.TxtVehty.TabIndex = 5
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(15, 89)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(69, 13)
    Me.Label3.TabIndex = 330
    Me.Label3.Text = "Vehicle Type"
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(103, 112)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(285, 22)
    Me.TxtName.TabIndex = 6
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(15, 116)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(35, 13)
    Me.Label4.TabIndex = 332
    Me.Label4.Text = "Name"
    '
    'TxtAddr
    '
    Me.TxtAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAddr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAddr.Location = New System.Drawing.Point(103, 139)
    Me.TxtAddr.MaxLength = 35
    Me.TxtAddr.Name = "TxtAddr"
    Me.TxtAddr.Size = New System.Drawing.Size(285, 22)
    Me.TxtAddr.TabIndex = 7
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(15, 143)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(45, 13)
    Me.Label6.TabIndex = 334
    Me.Label6.Text = "Address"
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(103, 165)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(206, 22)
    Me.TxtCity.TabIndex = 8
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(15, 169)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(34, 13)
    Me.Label7.TabIndex = 336
    Me.Label7.Text = "Town"
    '
    'LblStatus
    '
    Me.LblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblStatus.Location = New System.Drawing.Point(331, 8)
    Me.LblStatus.Name = "LblStatus"
    Me.LblStatus.Size = New System.Drawing.Size(137, 22)
    Me.LblStatus.TabIndex = 337
    Me.LblStatus.Text = "<Status>"
    Me.LblStatus.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(369, 35)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(42, 13)
    Me.Label8.TabIndex = 338
    Me.Label8.Text = "Original"
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(353, 165)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 22)
    Me.TxtState.TabIndex = 9
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(315, 169)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(32, 13)
    Me.Label9.TabIndex = 340
    Me.Label9.Text = "State"
    '
    'TxtZip
    '
    Me.TxtZip.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip.Location = New System.Drawing.Point(424, 165)
    Me.TxtZip.MaxLength = 5
    Me.TxtZip.Name = "TxtZip"
    Me.TxtZip.Size = New System.Drawing.Size(48, 22)
    Me.TxtZip.TabIndex = 10
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(396, 169)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(22, 13)
    Me.Label10.TabIndex = 342
    Me.Label10.Text = "Zip"
    '
    'TxtVtime
    '
    Me.TxtVtime.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVtime.Location = New System.Drawing.Point(231, 194)
    Me.TxtVtime.MaxLength = 4
    Me.TxtVtime.Name = "TxtVtime"
    Me.TxtVtime.Size = New System.Drawing.Size(47, 22)
    Me.TxtVtime.TabIndex = 12
    Me.TxtVtime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(195, 198)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(30, 13)
    Me.Label11.TabIndex = 344
    Me.Label11.Text = "Time"
    '
    'RbAM
    '
    Me.RbAM.AutoSize = True
    Me.RbAM.Location = New System.Drawing.Point(331, 196)
    Me.RbAM.Name = "RbAM"
    Me.RbAM.Size = New System.Drawing.Size(41, 17)
    Me.RbAM.TabIndex = 14
    Me.RbAM.Text = "AM"
    Me.RbAM.UseVisualStyleBackColor = True
    '
    'RbMI
    '
    Me.RbMI.AutoSize = True
    Me.RbMI.Checked = True
    Me.RbMI.Location = New System.Drawing.Point(284, 196)
    Me.RbMI.Name = "RbMI"
    Me.RbMI.Size = New System.Drawing.Size(37, 17)
    Me.RbMI.TabIndex = 13
    Me.RbMI.TabStop = True
    Me.RbMI.Text = "MI"
    Me.RbMI.UseVisualStyleBackColor = True
    '
    'RbPM
    '
    Me.RbPM.AutoSize = True
    Me.RbPM.Location = New System.Drawing.Point(378, 196)
    Me.RbPM.Name = "RbPM"
    Me.RbPM.Size = New System.Drawing.Size(41, 17)
    Me.RbPM.TabIndex = 15
    Me.RbPM.Text = "PM"
    Me.RbPM.UseVisualStyleBackColor = True
    '
    'TxtMeterNo
    '
    Me.TxtMeterNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMeterNo.Location = New System.Drawing.Point(103, 226)
    Me.TxtMeterNo.MaxLength = 8
    Me.TxtMeterNo.Name = "TxtMeterNo"
    Me.TxtMeterNo.Size = New System.Drawing.Size(71, 22)
    Me.TxtMeterNo.TabIndex = 16
    Me.TxtMeterNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(15, 230)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(74, 13)
    Me.Label12.TabIndex = 349
    Me.Label12.Text = "Meter Number"
    '
    'TxtStreet
    '
    Me.TxtStreet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtStreet.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtStreet.Location = New System.Drawing.Point(103, 252)
    Me.TxtStreet.MaxLength = 30
    Me.TxtStreet.Name = "TxtStreet"
    Me.TxtStreet.Size = New System.Drawing.Size(276, 22)
    Me.TxtStreet.TabIndex = 17
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.Location = New System.Drawing.Point(15, 256)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(35, 13)
    Me.Label13.TabIndex = 351
    Me.Label13.Text = "Street"
    '
    'LblAppl
    '
    Me.LblAppl.AutoSize = True
    Me.LblAppl.Location = New System.Drawing.Point(17, 198)
    Me.LblAppl.Name = "LblAppl"
    Me.LblAppl.Size = New System.Drawing.Size(73, 13)
    Me.LblAppl.TabIndex = 421
    Me.LblAppl.Text = "Violation Date"
    '
    'DtPckVdate
    '
    Me.DtPckVdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckVdate.Location = New System.Drawing.Point(105, 194)
    Me.DtPckVdate.Name = "DtPckVdate"
    Me.DtPckVdate.Size = New System.Drawing.Size(84, 20)
    Me.DtPckVdate.TabIndex = 11
    '
    'TxtViol1
    '
    Me.TxtViol1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtViol1.Location = New System.Drawing.Point(103, 280)
    Me.TxtViol1.MaxLength = 2
    Me.TxtViol1.Name = "TxtViol1"
    Me.TxtViol1.Size = New System.Drawing.Size(24, 22)
    Me.TxtViol1.TabIndex = 19
    Me.TxtViol1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LnkViol1
    '
    Me.LnkViol1.AutoSize = True
    Me.LnkViol1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkViol1.ForeColor = System.Drawing.Color.Maroon
    Me.LnkViol1.Location = New System.Drawing.Point(17, 284)
    Me.LnkViol1.Name = "LnkViol1"
    Me.LnkViol1.Size = New System.Drawing.Size(56, 13)
    Me.LnkViol1.TabIndex = 18
    Me.LnkViol1.TabStop = True
    Me.LnkViol1.Text = "Violation 1"
    '
    'TxtViol2
    '
    Me.TxtViol2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtViol2.Location = New System.Drawing.Point(103, 306)
    Me.TxtViol2.MaxLength = 2
    Me.TxtViol2.Name = "TxtViol2"
    Me.TxtViol2.Size = New System.Drawing.Size(24, 22)
    Me.TxtViol2.TabIndex = 21
    Me.TxtViol2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LnkViol2
    '
    Me.LnkViol2.AutoSize = True
    Me.LnkViol2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkViol2.ForeColor = System.Drawing.Color.Maroon
    Me.LnkViol2.Location = New System.Drawing.Point(17, 310)
    Me.LnkViol2.Name = "LnkViol2"
    Me.LnkViol2.Size = New System.Drawing.Size(56, 13)
    Me.LnkViol2.TabIndex = 20
    Me.LnkViol2.TabStop = True
    Me.LnkViol2.Text = "Violation 2"
    '
    'TxtViol3
    '
    Me.TxtViol3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtViol3.Location = New System.Drawing.Point(103, 331)
    Me.TxtViol3.MaxLength = 2
    Me.TxtViol3.Name = "TxtViol3"
    Me.TxtViol3.Size = New System.Drawing.Size(24, 22)
    Me.TxtViol3.TabIndex = 23
    Me.TxtViol3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LnkViol3
    '
    Me.LnkViol3.AutoSize = True
    Me.LnkViol3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkViol3.ForeColor = System.Drawing.Color.Maroon
    Me.LnkViol3.Location = New System.Drawing.Point(17, 335)
    Me.LnkViol3.Name = "LnkViol3"
    Me.LnkViol3.Size = New System.Drawing.Size(56, 13)
    Me.LnkViol3.TabIndex = 22
    Me.LnkViol3.TabStop = True
    Me.LnkViol3.Text = "Violation 3"
    '
    'TxtViol4
    '
    Me.TxtViol4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtViol4.Location = New System.Drawing.Point(103, 357)
    Me.TxtViol4.MaxLength = 2
    Me.TxtViol4.Name = "TxtViol4"
    Me.TxtViol4.Size = New System.Drawing.Size(24, 22)
    Me.TxtViol4.TabIndex = 25
    Me.TxtViol4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LnkViol4
    '
    Me.LnkViol4.AutoSize = True
    Me.LnkViol4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkViol4.ForeColor = System.Drawing.Color.Maroon
    Me.LnkViol4.Location = New System.Drawing.Point(17, 361)
    Me.LnkViol4.Name = "LnkViol4"
    Me.LnkViol4.Size = New System.Drawing.Size(56, 13)
    Me.LnkViol4.TabIndex = 24
    Me.LnkViol4.TabStop = True
    Me.LnkViol4.Text = "Violation 4"
    '
    'TxtViol5
    '
    Me.TxtViol5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtViol5.Location = New System.Drawing.Point(103, 383)
    Me.TxtViol5.MaxLength = 2
    Me.TxtViol5.Name = "TxtViol5"
    Me.TxtViol5.Size = New System.Drawing.Size(24, 22)
    Me.TxtViol5.TabIndex = 27
    Me.TxtViol5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LnkViol5
    '
    Me.LnkViol5.AutoSize = True
    Me.LnkViol5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkViol5.ForeColor = System.Drawing.Color.Maroon
    Me.LnkViol5.Location = New System.Drawing.Point(17, 387)
    Me.LnkViol5.Name = "LnkViol5"
    Me.LnkViol5.Size = New System.Drawing.Size(56, 13)
    Me.LnkViol5.TabIndex = 26
    Me.LnkViol5.TabStop = True
    Me.LnkViol5.Text = "Violation 5"
    '
    'LblViolDesc1
    '
    Me.LblViolDesc1.AutoSize = True
    Me.LblViolDesc1.Location = New System.Drawing.Point(133, 284)
    Me.LblViolDesc1.Name = "LblViolDesc1"
    Me.LblViolDesc1.Size = New System.Drawing.Size(72, 13)
    Me.LblViolDesc1.TabIndex = 432
    Me.LblViolDesc1.Text = "<Description>"
    '
    'LblViolDesc2
    '
    Me.LblViolDesc2.AutoSize = True
    Me.LblViolDesc2.Location = New System.Drawing.Point(135, 310)
    Me.LblViolDesc2.Name = "LblViolDesc2"
    Me.LblViolDesc2.Size = New System.Drawing.Size(72, 13)
    Me.LblViolDesc2.TabIndex = 433
    Me.LblViolDesc2.Text = "<Description>"
    '
    'LblViolDesc3
    '
    Me.LblViolDesc3.AutoSize = True
    Me.LblViolDesc3.Location = New System.Drawing.Point(135, 335)
    Me.LblViolDesc3.Name = "LblViolDesc3"
    Me.LblViolDesc3.Size = New System.Drawing.Size(72, 13)
    Me.LblViolDesc3.TabIndex = 434
    Me.LblViolDesc3.Text = "<Description>"
    '
    'LblViolDesc4
    '
    Me.LblViolDesc4.AutoSize = True
    Me.LblViolDesc4.Location = New System.Drawing.Point(135, 361)
    Me.LblViolDesc4.Name = "LblViolDesc4"
    Me.LblViolDesc4.Size = New System.Drawing.Size(72, 13)
    Me.LblViolDesc4.TabIndex = 435
    Me.LblViolDesc4.Text = "<Description>"
    '
    'LblViolDesc5
    '
    Me.LblViolDesc5.AutoSize = True
    Me.LblViolDesc5.Location = New System.Drawing.Point(135, 388)
    Me.LblViolDesc5.Name = "LblViolDesc5"
    Me.LblViolDesc5.Size = New System.Drawing.Size(72, 13)
    Me.LblViolDesc5.TabIndex = 436
    Me.LblViolDesc5.Text = "<Description>"
    '
    'FrmPK100C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(479, 410)
    Me.Controls.Add(Me.LblViolDesc5)
    Me.Controls.Add(Me.LblViolDesc4)
    Me.Controls.Add(Me.LblViolDesc3)
    Me.Controls.Add(Me.LblViolDesc2)
    Me.Controls.Add(Me.LblViolDesc1)
    Me.Controls.Add(Me.TxtViol5)
    Me.Controls.Add(Me.LnkViol5)
    Me.Controls.Add(Me.TxtViol4)
    Me.Controls.Add(Me.LnkViol4)
    Me.Controls.Add(Me.TxtViol3)
    Me.Controls.Add(Me.LnkViol3)
    Me.Controls.Add(Me.TxtViol2)
    Me.Controls.Add(Me.LnkViol2)
    Me.Controls.Add(Me.TxtViol1)
    Me.Controls.Add(Me.LnkViol1)
    Me.Controls.Add(Me.LblAppl)
    Me.Controls.Add(Me.DtPckVdate)
    Me.Controls.Add(Me.TxtStreet)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.TxtMeterNo)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.RbPM)
    Me.Controls.Add(Me.RbMI)
    Me.Controls.Add(Me.RbAM)
    Me.Controls.Add(Me.TxtVtime)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.TxtZip)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.TxtState)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.LblStatus)
    Me.Controls.Add(Me.TxtCity)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtAddr)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtVehty)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtRegST)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtOffcno)
    Me.Controls.Add(Me.LnkOffcno)
    Me.Controls.Add(Me.LblViAmt)
    Me.Controls.Add(Me.TxtRegNo)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtTickNo)
    Me.Controls.Add(Me.Label1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPK100C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Parking Ticket"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmPK100C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myPKTICK = New PKTICK.MyData(myDBConnect)
    myPKCNTL = New PKCNTL.MyData(myDBConnect)
    myPKOFCR = New PKOFCR.MyData(myDBConnect)
    myPKVIOL = New PKVIOL.MyData(myDBConnect)

    LoadScrn = True
    myPKCNTL.GetOneRecordP("")
    MyFrmPK100.TBarNew.Enabled = False
    MyFrmPK100.TBarSave.Enabled = True

    'New record
    If AddMode Then
      Me.Text = "Add " & Me.Text
      MyFrmPK100.TBarDelete.Enabled = False
      DtPckVdate.Value = Date.Today
      LblStatus.Text = ""
      LblViolDesc1.Text = ""
      LblViolDesc2.Text = ""
      LblViolDesc3.Text = ""
      LblViolDesc4.Text = ""
      LblViolDesc5.Text = ""
      LoadScrn = False
      Exit Sub
    End If

    TxtTickNo.Text = WrkTickNo
    TxtTickNo.ReadOnly = True
    TxtTickNo.TabStop = False
    TxtTickNo.BackColor = Color.Aqua

    If s_chg = False And s_full = False Then  '#sec
      MyFrmPK100.TBarSave.Visible = False  '#sec
    End If  '#sec

    'Fill the dataset with the data
    Me.Text = "Maintain " & Me.Text
    MyFrmPK100.TBarDelete.Enabled = True
    myPKTICK.GetOneRecordP(WrkTickNo)

    If myPKTICK.RecordNotFound Then
      MyFrmPK100.TBarNew.Enabled = False
      MyFrmPK100.TBarSave.Enabled = False
      MyFrmPK100.TBarDelete.Enabled = False
      Me.ErrProv.SetError(TxtTickNo, "Record not found")
      Exit Sub
    End If

    With myPKTICK
      Select Case Trim(._STATUS)
        Case "L"
          LblStatus.Text = "Override Late"
        Case "P"
          LblStatus.Text = "Paid"
        Case "V"
          LblStatus.Text = "Void"
        Case Else
          LblStatus.Text = ""
      End Select
      LblViAmt.Text = Format(._VIAMT, "Fixed")
      TxtOffcno.Text = Trim(._OFFCNO)
      TxtRegNo.Text = Trim(._REGNO)
      TxtRegST.Text = Trim(._REGST)
      TxtName.Text = Trim(._NAME)
      TxtAddr.Text = Trim(._ADDR)
      TxtCity.Text = Trim(._CITY)
      TxtState.Text = Trim(._STATE)
      If MyUtils.CnvSng(._ZIP) > 0 Then
        TxtZip.Text = ._ZIP
      End If
      If ._VDATE > 0 Then
        DtPckVdate.Value = MyUtils.GetDBDate(._VDATE)
      End If
      TxtVtime.Text = ._VTIME
      Select Case ._AMPM
        Case "MI"
          RbMI.Checked = True
        Case "AM"
          RbAM.Checked = True
        Case "PM"
          RbPM.Checked = True
      End Select
      TxtViol1.Text = ._VIOL1
      LblViolDesc1.Text = GetViolDesc(._VIOL1)
      If ._VIOL2 > 0 Then
        TxtViol2.Text = ._VIOL2
        LblViolDesc2.Text = GetViolDesc(._VIOL2)
      Else
        LblViolDesc2.Text = ""
      End If
      If ._VIOL3 > 0 Then
        TxtViol3.Text = ._VIOL3
        LblViolDesc3.Text = GetViolDesc(._VIOL3)
      Else
        LblViolDesc3.Text = ""
      End If
      If ._VIOL4 > 0 Then
        TxtViol4.Text = ._VIOL4
        LblViolDesc4.Text = GetViolDesc(._VIOL4)
      Else
        LblViolDesc4.Text = ""
      End If
      If ._VIOL5 > 0 Then
        TxtViol5.Text = ._VIOL5
        LblViolDesc5.Text = GetViolDesc(._VIOL5)
      Else
        LblViolDesc5.Text = ""
      End If
    End With

    SetOffcnoTip()
    LoadScrn = False
  End Sub

  Private Sub FrmPK100C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmPK100.TBarNew.Enabled = True
    MyFrmPK100.TBarSave.Enabled = False
    MyFrmPK100.TBarDelete.Enabled = False
    MyFrmPK100.TBarSave.Visible = True   '#sec
    MyFrmPK100B.FormatGrid(True)
    MyFrmPK100B.Show()

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    myPKTICK.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim WrkNextKey As Integer
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String

    If TxtTickNo.Text = "" Then
      WrkNextKey = myPKTICK.AutoGenKey
      MsgBox("Ticket No was left blank and assigned the next available number. Click Save again if OK", MsgBoxStyle.Exclamation, "Auto Generated Key")
      TxtTickNo.Text = WrkNextKey
      Exit Sub
    End If

    WrkTickNo = MyUtils.CnvSng(TxtTickNo.Text)

    myPKTICK.GetOneRecordP(WrkTickNo)
    If AddMode Then
      If Not myPKTICK.RecordNotFound Then
        Me.ErrProv.SetError(TxtTickNo, "Record already exists")
        Exit Sub
      End If
    End If

    SetOffcnoTip()

    If Not AddMode Then
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myPKTICK.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myPKTICK.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    Me.Close()

  End Sub
  Private Sub MoveToFile()
    With myPKTICK
      If AddMode Then
        ._STATUS = ""
        ._TICKNO = MyUtils.CnvSng(TxtTickNo.Text)
        ._VIAMT = CalcViolAmt()
      End If
      ._OFFCNO = TxtOffcno.Text
      ._REGNO = TxtRegNo.Text
      ._REGST = TxtRegST.Text
      ._NAME = TxtName.Text
      ._ADDR = TxtAddr.Text
      ._CITY = TxtCity.Text
      ._STATE = TxtState.Text
      ._ZIP = TxtZip.Text
      ._VDATE = MyUtils.SetDBDate(DtPckVdate.Value)
      ._VTIME = MyUtils.CnvSng(TxtVtime.Text)
      If RbMI.Checked Then ._AMPM = "MI"
      If RbAM.Checked Then ._AMPM = "AM"
      If RbPM.Checked Then ._AMPM = "PM"
      ._VIOL1 = MyUtils.CnvSng(TxtViol1.Text)
      ._VIOL2 = MyUtils.CnvSng(TxtViol2.Text)
      ._VIOL3 = MyUtils.CnvSng(TxtViol3.Text)
      ._VIOL4 = MyUtils.CnvSng(TxtViol4.Text)
      ._VIOL4 = MyUtils.CnvSng(TxtViol5.Text)
    End With

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtOffcno, "")
    ErrProv.SetError(TxtRegNo, "")
    ErrProv.SetError(TxtTickNo, "")
    ErrProv.SetError(TxtVtime, "")
    ErrProv.SetError(TxtViol1, "")
    ErrProv.SetError(TxtViol2, "")
    ErrProv.SetError(TxtViol3, "")
    ErrProv.SetError(TxtViol4, "")
    ErrProv.SetError(TxtViol5, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
        Case "offcno"
          ErrProv.SetError(TxtOffcno, ErrorMsg(I))
        Case "regno"
          ErrProv.SetError(TxtRegNo, ErrorMsg(I))
        Case "tickno"
          ErrProv.SetError(TxtTickNo, ErrorMsg(I))
        Case "vtime"
          ErrProv.SetError(TxtVtime, ErrorMsg(I))
        Case "viol1"
          ErrProv.SetError(TxtViol1, ErrorMsg(I))
        Case "viol2"
          ErrProv.SetError(TxtViol2, ErrorMsg(I))
        Case "viol3"
          ErrProv.SetError(TxtViol3, ErrorMsg(I))
        Case "viol4"
          ErrProv.SetError(TxtViol4, ErrorMsg(I))
        Case "viol5"
          ErrProv.SetError(TxtViol5, ErrorMsg(I))
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

    If TxtTickNo.Text = String.Empty Then
      ErrorField(I) = "tickno"
      ErrorMsg(I) = "Invalid Ticket No"
      I = I + 1
    End If

    WrkTip = Ttp1.GetToolTip(TxtOffcno)
    If Mid(WrkTip, 1, 1) = "*" Then
      ErrorField(I) = "offcno"
      ErrorMsg(I) = "Invalid Officer"
      I = I + 1
    End If

    If TxtRegNo.Text = String.Empty Then
      ErrorField(I) = "regno"
      ErrorMsg(I) = "Invalid Reg No"
      I = I + 1
    End If

    If TxtVtime.Text = "" Then
      ErrorField(I) = "vtime"
      ErrorMsg(I) = "Invalid Violation"
      I = I + 1
    End If

    If LblViolDesc1.Text = "" Then
      ErrorField(I) = "viol1"
      ErrorMsg(I) = "Invalid Violation"
      I = I + 1
    End If

    If TxtViol2.Text <> String.Empty And LblViolDesc2.Text = "" Then
      ErrorField(I) = "viol2"
      ErrorMsg(I) = "Invalid Violation"
      I = I + 1
    End If

    If TxtViol3.Text <> String.Empty And LblViolDesc3.Text = "" Then
      ErrorField(I) = "viol3"
      ErrorMsg(I) = "Invalid Violation"
      I = I + 1
    End If

    If TxtViol4.Text <> String.Empty And LblViolDesc4.Text = "" Then
      ErrorField(I) = "viol4"
      ErrorMsg(I) = "Invalid Violation"
      I = I + 1
    End If

    If TxtViol5.Text <> String.Empty And LblViolDesc5.Text = "" Then
      ErrorField(I) = "viol5"
      ErrorMsg(I) = "Invalid Violation"
      I = I + 1
    End If
  End Sub
  Private Sub FrmPK100C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    MyFrmPK100.SbpScreen.Text = "PK100C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub LnkOffcno_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkOffcno.LinkClicked
    MyFrmListOfcr = New FrmListOfcr
    MyFrmListOfcr.MdiParent = Me.ParentForm
    MyFrmListOfcr.WrkCode = TxtOffcno.Text
    MyFrmListOfcr.Show()
  End Sub
  Private Sub LnkViol1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkViol1.LinkClicked
    MyFrmListViol = New FrmListViol
    MyFrmListViol.MdiParent = Me.ParentForm
    MyFrmListViol.WrkNo = 1
    MyFrmListViol.WrkCode = MyUtils.CnvSng(TxtViol1.Text)
    MyFrmListViol.Show()
  End Sub
  Private Sub LnkViol2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkViol2.LinkClicked
    MyFrmListViol = New FrmListViol
    MyFrmListViol.MdiParent = Me.ParentForm
    MyFrmListViol.WrkNo = 2
    MyFrmListViol.WrkCode = MyUtils.CnvSng(TxtViol2.Text)
    MyFrmListViol.Show()
  End Sub
  Private Sub LnkViol3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkViol3.LinkClicked
    MyFrmListViol = New FrmListViol
    MyFrmListViol.MdiParent = Me.ParentForm
    MyFrmListViol.WrkNo = 3
    MyFrmListViol.WrkCode = MyUtils.CnvSng(TxtViol3.Text)
    MyFrmListViol.Show()
  End Sub
  Private Sub LnkViol4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkViol4.LinkClicked
    MyFrmListViol = New FrmListViol
    MyFrmListViol.MdiParent = Me.ParentForm
    MyFrmListViol.WrkNo = 4
    MyFrmListViol.WrkCode = MyUtils.CnvSng(TxtViol4.Text)
    MyFrmListViol.Show()
  End Sub
  Private Sub LnkViol5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkViol5.LinkClicked
    MyFrmListViol = New FrmListViol
    MyFrmListViol.MdiParent = Me.ParentForm
    MyFrmListViol.WrkNo = 5
    MyFrmListViol.WrkCode = MyUtils.CnvSng(TxtViol5.Text)
    MyFrmListViol.Show()
  End Sub
  Private Sub SetOffcnoTip()
    Dim WrkDesc As String
    If LoadScrn Then Exit Sub

    WrkDesc = GetOffcName(TxtOffcno.Text)
    Ttp1.SetToolTip(TxtOffcno, WrkDesc)
  End Sub
  Private Sub TxtOffcno_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOffcno.Leave
    SetOffcnoTip()
  End Sub
  Private Sub TxtTickcno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTickNo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtOffcno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOffcno.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtMeterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMeterNo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtVtime_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVtime.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtViol1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtViol1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtViol2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtViol2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtViol3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtViol3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtViol4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtViol4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtViol5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtViol5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Function CalcViolAmt() As Decimal
    Dim WrkAmt As Decimal
    WrkAmt = GetViolAmt(MyUtils.CnvSng(TxtViol1.Text))
    WrkAmt = WrkAmt + GetViolAmt(MyUtils.CnvSng(TxtViol2.Text))
    WrkAmt = WrkAmt + GetViolAmt(MyUtils.CnvSng(TxtViol3.Text))
    WrkAmt = WrkAmt + GetViolAmt(MyUtils.CnvSng(TxtViol4.Text))
    WrkAmt = WrkAmt + GetViolAmt(MyUtils.CnvSng(TxtViol5.Text))
    Return WrkAmt
  End Function
  Private Sub TxtViol1_TextChanged(sender As Object, e As EventArgs) Handles TxtViol1.TextChanged
    If Not LoadScrn Then
      LblViAmt.Text = CalcViolAmt()
      LblViolDesc1.Text = GetViolDesc(MyUtils.CnvSng(TxtViol1.Text))
    End If
  End Sub
  Private Sub TxtViol2_TextChanged(sender As Object, e As EventArgs) Handles TxtViol2.TextChanged
    If Not LoadScrn Then
      LblViAmt.Text = CalcViolAmt()
      LblViolDesc2.Text = GetViolDesc(MyUtils.CnvSng(TxtViol2.Text))
    End If
  End Sub
  Private Sub TxtViol3_TextChanged(sender As Object, e As EventArgs) Handles TxtViol3.TextChanged
    If Not LoadScrn Then
      LblViAmt.Text = CalcViolAmt()
      LblViolDesc3.Text = GetViolDesc(MyUtils.CnvSng(TxtViol3.Text))
    End If
  End Sub
  Private Sub TxtViol4_TextChanged(sender As Object, e As EventArgs) Handles TxtViol4.TextChanged
    If Not LoadScrn Then
      LblViAmt.Text = CalcViolAmt()
      LblViolDesc4.Text = GetViolDesc(MyUtils.CnvSng(TxtViol4.Text))
    End If
  End Sub
  Private Sub TxtViol5_TextChanged(sender As Object, e As EventArgs) Handles TxtViol5.TextChanged
    If Not LoadScrn Then
      LblViAmt.Text = CalcViolAmt()
      LblViolDesc5.Text = GetViolDesc(MyUtils.CnvSng(TxtViol5.Text))
    End If
  End Sub
End Class
