Imports System.Text
Public Class FrmPK120C
  Inherits System.Windows.Forms.Form
  Dim myPKTICK As PKTICK.myData
  Dim myPKCNTL As PKCNTL.myData
  Dim myPKVIOL As PKVIOL.myData
  Friend WrkTickNo As Integer
  Friend AddMode As Boolean
  Friend WithEvents TxtOffcno As System.Windows.Forms.TextBox
  Friend WithEvents LblViAmt As System.Windows.Forms.Label
  Friend WithEvents TxtRegST As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtVehty As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents LblStatus As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtVtime As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents LblAppl As System.Windows.Forms.Label
  Friend WithEvents TxtViol5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtViol4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtViol3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtViol2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtViol1 As System.Windows.Forms.TextBox
  Friend WithEvents LblViolDesc5 As System.Windows.Forms.Label
  Friend WithEvents LblViolDesc4 As System.Windows.Forms.Label
  Friend WithEvents LblViolDesc3 As System.Windows.Forms.Label
  Friend WithEvents LblViolDesc2 As System.Windows.Forms.Label
  Friend WithEvents LblViolDesc1 As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtAmpm As System.Windows.Forms.TextBox
  Friend WithEvents TxtVdate As System.Windows.Forms.TextBox
  Friend WithEvents LblDatePd As System.Windows.Forms.Label
  Friend WithEvents DtPckDatepd As System.Windows.Forms.DateTimePicker
  Friend WithEvents LblAmt1 As System.Windows.Forms.Label
  Friend WithEvents LblDate1 As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents LblAmt3 As System.Windows.Forms.Label
  Friend WithEvents LblDate3 As System.Windows.Forms.Label
  Friend WithEvents LblAmt2 As System.Windows.Forms.Label
  Friend WithEvents LblDate2 As System.Windows.Forms.Label
  Friend WithEvents RbOverLate As System.Windows.Forms.RadioButton
  Friend WithEvents RbVoid As System.Windows.Forms.RadioButton
  Friend WithEvents RbNormal As System.Windows.Forms.RadioButton
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents LblCurAmt As System.Windows.Forms.Label
  Friend WithEvents RbOriginal As System.Windows.Forms.RadioButton
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
    Me.TxtRegST = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtVehty = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.LblStatus = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtVtime = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.LblAppl = New System.Windows.Forms.Label()
    Me.TxtViol1 = New System.Windows.Forms.TextBox()
    Me.TxtViol2 = New System.Windows.Forms.TextBox()
    Me.TxtViol3 = New System.Windows.Forms.TextBox()
    Me.TxtViol4 = New System.Windows.Forms.TextBox()
    Me.TxtViol5 = New System.Windows.Forms.TextBox()
    Me.LblViolDesc1 = New System.Windows.Forms.Label()
    Me.LblViolDesc2 = New System.Windows.Forms.Label()
    Me.LblViolDesc3 = New System.Windows.Forms.Label()
    Me.LblViolDesc4 = New System.Windows.Forms.Label()
    Me.LblViolDesc5 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TxtVdate = New System.Windows.Forms.TextBox()
    Me.TxtAmpm = New System.Windows.Forms.TextBox()
    Me.LblDatePd = New System.Windows.Forms.Label()
    Me.DtPckDatepd = New System.Windows.Forms.DateTimePicker()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.LblDate1 = New System.Windows.Forms.Label()
    Me.LblAmt1 = New System.Windows.Forms.Label()
    Me.LblAmt2 = New System.Windows.Forms.Label()
    Me.LblDate2 = New System.Windows.Forms.Label()
    Me.LblAmt3 = New System.Windows.Forms.Label()
    Me.LblDate3 = New System.Windows.Forms.Label()
    Me.RbVoid = New System.Windows.Forms.RadioButton()
    Me.RbOverLate = New System.Windows.Forms.RadioButton()
    Me.RbNormal = New System.Windows.Forms.RadioButton()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.LblCurAmt = New System.Windows.Forms.Label()
    Me.RbOriginal = New System.Windows.Forms.RadioButton()
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
    Me.TxtRegNo.TabIndex = 2
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
    Me.TxtOffcno.TabIndex = 1
    '
    'TxtRegST
    '
    Me.TxtRegST.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRegST.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRegST.Location = New System.Drawing.Point(285, 59)
    Me.TxtRegST.MaxLength = 2
    Me.TxtRegST.Name = "TxtRegST"
    Me.TxtRegST.Size = New System.Drawing.Size(24, 22)
    Me.TxtRegST.TabIndex = 3
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
    Me.TxtVehty.MaxLength = 12
    Me.TxtVehty.Name = "TxtVehty"
    Me.TxtVehty.Size = New System.Drawing.Size(243, 22)
    Me.TxtVehty.TabIndex = 4
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
    'LblStatus
    '
    Me.LblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblStatus.Location = New System.Drawing.Point(347, 8)
    Me.LblStatus.Name = "LblStatus"
    Me.LblStatus.Size = New System.Drawing.Size(121, 22)
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
    'TxtVtime
    '
    Me.TxtVtime.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVtime.Location = New System.Drawing.Point(231, 113)
    Me.TxtVtime.MaxLength = 4
    Me.TxtVtime.Name = "TxtVtime"
    Me.TxtVtime.Size = New System.Drawing.Size(47, 22)
    Me.TxtVtime.TabIndex = 6
    Me.TxtVtime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(195, 117)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(30, 13)
    Me.Label11.TabIndex = 344
    Me.Label11.Text = "Time"
    '
    'LblAppl
    '
    Me.LblAppl.AutoSize = True
    Me.LblAppl.Location = New System.Drawing.Point(17, 117)
    Me.LblAppl.Name = "LblAppl"
    Me.LblAppl.Size = New System.Drawing.Size(73, 13)
    Me.LblAppl.TabIndex = 421
    Me.LblAppl.Text = "Violation Date"
    '
    'TxtViol1
    '
    Me.TxtViol1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtViol1.Location = New System.Drawing.Point(103, 140)
    Me.TxtViol1.MaxLength = 2
    Me.TxtViol1.Name = "TxtViol1"
    Me.TxtViol1.Size = New System.Drawing.Size(24, 22)
    Me.TxtViol1.TabIndex = 7
    Me.TxtViol1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtViol2
    '
    Me.TxtViol2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtViol2.Location = New System.Drawing.Point(103, 166)
    Me.TxtViol2.MaxLength = 2
    Me.TxtViol2.Name = "TxtViol2"
    Me.TxtViol2.Size = New System.Drawing.Size(24, 22)
    Me.TxtViol2.TabIndex = 8
    Me.TxtViol2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtViol3
    '
    Me.TxtViol3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtViol3.Location = New System.Drawing.Point(103, 191)
    Me.TxtViol3.MaxLength = 2
    Me.TxtViol3.Name = "TxtViol3"
    Me.TxtViol3.Size = New System.Drawing.Size(24, 22)
    Me.TxtViol3.TabIndex = 9
    Me.TxtViol3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtViol4
    '
    Me.TxtViol4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtViol4.Location = New System.Drawing.Point(103, 217)
    Me.TxtViol4.MaxLength = 2
    Me.TxtViol4.Name = "TxtViol4"
    Me.TxtViol4.Size = New System.Drawing.Size(24, 22)
    Me.TxtViol4.TabIndex = 10
    Me.TxtViol4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtViol5
    '
    Me.TxtViol5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtViol5.Location = New System.Drawing.Point(103, 243)
    Me.TxtViol5.MaxLength = 2
    Me.TxtViol5.Name = "TxtViol5"
    Me.TxtViol5.Size = New System.Drawing.Size(24, 22)
    Me.TxtViol5.TabIndex = 11
    Me.TxtViol5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblViolDesc1
    '
    Me.LblViolDesc1.AutoSize = True
    Me.LblViolDesc1.Location = New System.Drawing.Point(133, 144)
    Me.LblViolDesc1.Name = "LblViolDesc1"
    Me.LblViolDesc1.Size = New System.Drawing.Size(72, 13)
    Me.LblViolDesc1.TabIndex = 432
    Me.LblViolDesc1.Text = "<Description>"
    '
    'LblViolDesc2
    '
    Me.LblViolDesc2.AutoSize = True
    Me.LblViolDesc2.Location = New System.Drawing.Point(135, 170)
    Me.LblViolDesc2.Name = "LblViolDesc2"
    Me.LblViolDesc2.Size = New System.Drawing.Size(72, 13)
    Me.LblViolDesc2.TabIndex = 433
    Me.LblViolDesc2.Text = "<Description>"
    '
    'LblViolDesc3
    '
    Me.LblViolDesc3.AutoSize = True
    Me.LblViolDesc3.Location = New System.Drawing.Point(135, 195)
    Me.LblViolDesc3.Name = "LblViolDesc3"
    Me.LblViolDesc3.Size = New System.Drawing.Size(72, 13)
    Me.LblViolDesc3.TabIndex = 434
    Me.LblViolDesc3.Text = "<Description>"
    '
    'LblViolDesc4
    '
    Me.LblViolDesc4.AutoSize = True
    Me.LblViolDesc4.Location = New System.Drawing.Point(135, 221)
    Me.LblViolDesc4.Name = "LblViolDesc4"
    Me.LblViolDesc4.Size = New System.Drawing.Size(72, 13)
    Me.LblViolDesc4.TabIndex = 435
    Me.LblViolDesc4.Text = "<Description>"
    '
    'LblViolDesc5
    '
    Me.LblViolDesc5.AutoSize = True
    Me.LblViolDesc5.Location = New System.Drawing.Point(135, 248)
    Me.LblViolDesc5.Name = "LblViolDesc5"
    Me.LblViolDesc5.Size = New System.Drawing.Size(72, 13)
    Me.LblViolDesc5.TabIndex = 436
    Me.LblViolDesc5.Text = "<Description>"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(17, 37)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(78, 13)
    Me.Label4.TabIndex = 437
    Me.Label4.Text = "Officer Number"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(17, 144)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(56, 13)
    Me.Label6.TabIndex = 438
    Me.Label6.Text = "Violation 1"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(17, 170)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(56, 13)
    Me.Label7.TabIndex = 439
    Me.Label7.Text = "Violation 2"
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(17, 195)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(56, 13)
    Me.Label9.TabIndex = 440
    Me.Label9.Text = "Violation 3"
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(17, 221)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(56, 13)
    Me.Label10.TabIndex = 441
    Me.Label10.Text = "Violation 4"
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(17, 248)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(56, 13)
    Me.Label12.TabIndex = 442
    Me.Label12.Text = "Violation 5"
    '
    'TxtVdate
    '
    Me.TxtVdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVdate.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVdate.Location = New System.Drawing.Point(104, 112)
    Me.TxtVdate.MaxLength = 12
    Me.TxtVdate.Name = "TxtVdate"
    Me.TxtVdate.Size = New System.Drawing.Size(85, 22)
    Me.TxtVdate.TabIndex = 5
    '
    'TxtAmpm
    '
    Me.TxtAmpm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAmpm.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAmpm.Location = New System.Drawing.Point(284, 113)
    Me.TxtAmpm.MaxLength = 12
    Me.TxtAmpm.Name = "TxtAmpm"
    Me.TxtAmpm.Size = New System.Drawing.Size(21, 22)
    Me.TxtAmpm.TabIndex = 448
    '
    'LblDatePd
    '
    Me.LblDatePd.AutoSize = True
    Me.LblDatePd.Location = New System.Drawing.Point(19, 285)
    Me.LblDatePd.Name = "LblDatePd"
    Me.LblDatePd.Size = New System.Drawing.Size(54, 13)
    Me.LblDatePd.TabIndex = 450
    Me.LblDatePd.Text = "Date Paid"
    '
    'DtPckDatepd
    '
    Me.DtPckDatepd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckDatepd.Location = New System.Drawing.Point(103, 279)
    Me.DtPckDatepd.Name = "DtPckDatepd"
    Me.DtPckDatepd.Size = New System.Drawing.Size(84, 20)
    Me.DtPckDatepd.TabIndex = 12
    '
    'Label14
    '
    Me.Label14.AutoSize = True
    Me.Label14.Location = New System.Drawing.Point(245, 272)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(167, 13)
    Me.Label14.TabIndex = 451
    Me.Label14.Text = "- - - - - - - Payment History - - - - - - -"
    '
    'LblDate1
    '
    Me.LblDate1.AutoSize = True
    Me.LblDate1.Location = New System.Drawing.Point(235, 285)
    Me.LblDate1.Name = "LblDate1"
    Me.LblDate1.Size = New System.Drawing.Size(51, 13)
    Me.LblDate1.TabIndex = 452
    Me.LblDate1.Text = "<Date 1>"
    '
    'LblAmt1
    '
    Me.LblAmt1.AutoSize = True
    Me.LblAmt1.Location = New System.Drawing.Point(235, 298)
    Me.LblAmt1.Name = "LblAmt1"
    Me.LblAmt1.Size = New System.Drawing.Size(46, 13)
    Me.LblAmt1.TabIndex = 453
    Me.LblAmt1.Text = "<Amt 1>"
    '
    'LblAmt2
    '
    Me.LblAmt2.AutoSize = True
    Me.LblAmt2.Location = New System.Drawing.Point(300, 298)
    Me.LblAmt2.Name = "LblAmt2"
    Me.LblAmt2.Size = New System.Drawing.Size(46, 13)
    Me.LblAmt2.TabIndex = 455
    Me.LblAmt2.Text = "<Amt 2>"
    '
    'LblDate2
    '
    Me.LblDate2.AutoSize = True
    Me.LblDate2.Location = New System.Drawing.Point(300, 285)
    Me.LblDate2.Name = "LblDate2"
    Me.LblDate2.Size = New System.Drawing.Size(51, 13)
    Me.LblDate2.TabIndex = 454
    Me.LblDate2.Text = "<Date 2>"
    '
    'LblAmt3
    '
    Me.LblAmt3.AutoSize = True
    Me.LblAmt3.Location = New System.Drawing.Point(370, 298)
    Me.LblAmt3.Name = "LblAmt3"
    Me.LblAmt3.Size = New System.Drawing.Size(46, 13)
    Me.LblAmt3.TabIndex = 457
    Me.LblAmt3.Text = "<Amt 3>"
    '
    'LblDate3
    '
    Me.LblDate3.AutoSize = True
    Me.LblDate3.Location = New System.Drawing.Point(370, 285)
    Me.LblDate3.Name = "LblDate3"
    Me.LblDate3.Size = New System.Drawing.Size(51, 13)
    Me.LblDate3.TabIndex = 456
    Me.LblDate3.Text = "<Date 3>"
    '
    'RbVoid
    '
    Me.RbVoid.AutoSize = True
    Me.RbVoid.Location = New System.Drawing.Point(147, 321)
    Me.RbVoid.Name = "RbVoid"
    Me.RbVoid.Size = New System.Drawing.Size(46, 17)
    Me.RbVoid.TabIndex = 16
    Me.RbVoid.Text = "Void"
    Me.RbVoid.UseVisualStyleBackColor = True
    '
    'RbOverLate
    '
    Me.RbOverLate.AutoSize = True
    Me.RbOverLate.Location = New System.Drawing.Point(208, 321)
    Me.RbOverLate.Name = "RbOverLate"
    Me.RbOverLate.Size = New System.Drawing.Size(92, 17)
    Me.RbOverLate.TabIndex = 17
    Me.RbOverLate.Text = "Override Late "
    Me.RbOverLate.UseVisualStyleBackColor = True
    '
    'RbNormal
    '
    Me.RbNormal.AutoSize = True
    Me.RbNormal.Checked = True
    Me.RbNormal.Location = New System.Drawing.Point(15, 321)
    Me.RbNormal.Name = "RbNormal"
    Me.RbNormal.Size = New System.Drawing.Size(58, 17)
    Me.RbNormal.TabIndex = 14
    Me.RbNormal.TabStop = True
    Me.RbNormal.Text = "Normal"
    Me.RbNormal.UseVisualStyleBackColor = True
    '
    'Label15
    '
    Me.Label15.AutoSize = True
    Me.Label15.Location = New System.Drawing.Point(369, 51)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(41, 13)
    Me.Label15.TabIndex = 462
    Me.Label15.Text = "Current"
    '
    'LblCurAmt
    '
    Me.LblCurAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCurAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCurAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCurAmt.ForeColor = System.Drawing.Color.Black
    Me.LblCurAmt.Location = New System.Drawing.Point(414, 49)
    Me.LblCurAmt.Name = "LblCurAmt"
    Me.LblCurAmt.Size = New System.Drawing.Size(54, 16)
    Me.LblCurAmt.TabIndex = 461
    Me.LblCurAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'RbOriginal
    '
    Me.RbOriginal.AutoSize = True
    Me.RbOriginal.Location = New System.Drawing.Point(81, 321)
    Me.RbOriginal.Name = "RbOriginal"
    Me.RbOriginal.Size = New System.Drawing.Size(60, 17)
    Me.RbOriginal.TabIndex = 15
    Me.RbOriginal.Text = "Original"
    Me.RbOriginal.UseVisualStyleBackColor = True
    '
    'FrmPK120C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(479, 349)
    Me.Controls.Add(Me.RbOriginal)
    Me.Controls.Add(Me.Label15)
    Me.Controls.Add(Me.LblCurAmt)
    Me.Controls.Add(Me.RbNormal)
    Me.Controls.Add(Me.RbOverLate)
    Me.Controls.Add(Me.RbVoid)
    Me.Controls.Add(Me.LblAmt3)
    Me.Controls.Add(Me.LblDate3)
    Me.Controls.Add(Me.LblAmt2)
    Me.Controls.Add(Me.LblDate2)
    Me.Controls.Add(Me.LblAmt1)
    Me.Controls.Add(Me.LblDate1)
    Me.Controls.Add(Me.Label14)
    Me.Controls.Add(Me.LblDatePd)
    Me.Controls.Add(Me.DtPckDatepd)
    Me.Controls.Add(Me.TxtAmpm)
    Me.Controls.Add(Me.TxtVdate)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.LblViolDesc5)
    Me.Controls.Add(Me.LblViolDesc4)
    Me.Controls.Add(Me.LblViolDesc3)
    Me.Controls.Add(Me.LblViolDesc2)
    Me.Controls.Add(Me.LblViolDesc1)
    Me.Controls.Add(Me.TxtViol5)
    Me.Controls.Add(Me.TxtViol4)
    Me.Controls.Add(Me.TxtViol3)
    Me.Controls.Add(Me.TxtViol2)
    Me.Controls.Add(Me.TxtViol1)
    Me.Controls.Add(Me.LblAppl)
    Me.Controls.Add(Me.TxtVtime)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.LblStatus)
    Me.Controls.Add(Me.TxtVehty)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtRegST)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtOffcno)
    Me.Controls.Add(Me.LblViAmt)
    Me.Controls.Add(Me.TxtRegNo)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtTickNo)
    Me.Controls.Add(Me.Label1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPK120C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Parking Receipt"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

  Private Sub FrmPK120C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myPKTICK = New PKTICK.MyData(myDBConnect)
    myPKCNTL = New PKCNTL.MyData(myDBConnect)
    myPKVIOL = New PKVIOL.MyData(myDBConnect)

    LoadScrn = True
    TxtTickNo.Text = WrkTickNo
    MyUtils.SetTxtReadOnly(TxtTickNo)
    MyUtils.SetTxtReadOnly(TxtOffcno)
    MyUtils.SetTxtReadOnly(TxtRegNo)
    MyUtils.SetTxtReadOnly(TxtRegST)
    MyUtils.SetTxtReadOnly(TxtVehty)
    MyUtils.SetTxtReadOnly(TxtVdate)
    MyUtils.SetTxtReadOnly(TxtVtime)
    MyUtils.SetTxtReadOnly(TxtAmpm)
    MyUtils.SetTxtReadOnly(TxtViol1)
    MyUtils.SetTxtReadOnly(TxtViol2)
    MyUtils.SetTxtReadOnly(TxtViol3)
    MyUtils.SetTxtReadOnly(TxtViol4)
    MyUtils.SetTxtReadOnly(TxtViol5)

    If s_chg = False And s_full = False Then  '#sec
      MyFrmPK120.TBarSave.Visible = False  '#sec
    End If  '#sec

    'Fill the dataset with the data
    Me.Text = "Maintain " & Me.Text
    myPKTICK.GetOneRecordP(WrkTickNo)
    myPKCNTL.GetOneRecordP("")

    If myPKTICK.RecordNotFound Then
      MyFrmPK120.TBarSave.Enabled = False
      Me.ErrProv.SetError(TxtTickNo, "Record not found")
      Exit Sub
    End If

    With myPKTICK
      Select Case Trim(._STATUS)
        Case "L"
          LblStatus.Text = "Override Late"
          MyFrmPK120.TBarSave.Enabled = False
          DtPckDatepd.Visible = False
          LblDatePd.Visible = False
          RbNormal.Visible = False
          RbOriginal.Visible = False
          RbOverLate.Visible = False
          RbVoid.Visible = False
        Case "O"
          LblStatus.Text = "Original Paid"
          MyFrmPK120.TBarSave.Enabled = False
          RbOriginal.Visible = False
          RbOverLate.Visible = False
          RbVoid.Visible = False
          MyFrmPK120.TBarSave.Enabled = True
        Case "P"
          LblStatus.Text = "Paid"
          MyFrmPK120.TBarSave.Enabled = False
          DtPckDatepd.Visible = False
          LblDatePd.Visible = False
          RbNormal.Visible = False
          RbOriginal.Visible = False
          RbOverLate.Visible = False
          RbVoid.Visible = False
        Case "V"
          LblStatus.Text = "Void"
          MyFrmPK120.TBarSave.Enabled = False
          DtPckDatepd.Visible = False
          LblDatePd.Visible = False
          RbNormal.Visible = False
          RbOriginal.Visible = False
          RbOverLate.Visible = False
          RbVoid.Visible = False
        Case Else
          LblStatus.Text = ""
          MyFrmPK120.TBarSave.Enabled = True
      End Select
      TxtOffcno.Text = Trim(._OFFCNO)
      TxtRegNo.Text = Trim(._REGNO)
      TxtRegST.Text = Trim(._REGST)
      If ._VDATE > 0 Then
        TxtVdate.Text = MyUtils.GetDBDate(._VDATE)
      End If
      TxtVtime.Text = ._VTIME
      TxtAmpm.Text = ._AMPM
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
      DtPckDatepd.Value = Date.Today
      If ._AMT1 > 0 Then
        LblDate1.Text = MyUtils.GetDBDate(._DATE1)
        LblAmt1.Text = Format(._AMT1, "fixed")
        MyFrmPK120.TBarRemove.Enabled = True
      Else
        LblDate1.Text = ""
        LblAmt1.Text = ""
        MyFrmPK120.TBarRemove.Enabled = False
      End If
      If ._AMT2 > 0 Then
        LblDate2.Text = MyUtils.GetDBDate(._DATE2)
        LblAmt2.Text = Format(._AMT2, "fixed")
      Else
        LblDate2.Text = ""
        LblAmt2.Text = ""
      End If
      If ._AMT3 > 0 Then
        LblDate3.Text = MyUtils.GetDBDate(._DATE3)
        LblAmt3.Text = Format(._AMT3, "fixed")
      Else
        LblDate3.Text = ""
        LblAmt3.Text = ""
      End If
      LblViAmt.Text = Format(._VIAMT, "Fixed")
      If Trim(._STATUS) = "" Or Trim(._STATUS) = "O" Then
        LblCurAmt.Text = Format(CalcVIAmt(), "Fixed")
      Else
        LblCurAmt.Text = Format(._AMT1 + ._AMT2 + ._AMT3, "Fixed")
      End If
    End With

    LoadScrn = False
  End Sub

  Private Sub FrmPK120C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmPK120.TBarSave.Enabled = False
    MyFrmPK120.TBarSave.Visible = True   '#sec
    MyFrmPK120B.FormatGrid(True)
    MyFrmPK120B.Show()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String

    WrkTickNo = MyUtils.CnvSng(TxtTickNo.Text)
    myPKTICK.GetOneRecordP(WrkTickNo)
    If Not AddMode Then
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myPKTICK.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()

  End Sub
  Public Sub RemovePayment()
    Dim Answer As Integer

    Answer = MsgBox("Click OK to continue or Cancel to abort", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Confirm Remove Payment")
    If Answer = MsgBoxResult.Cancel Then Exit Sub

    WrkTickNo = MyUtils.CnvSng(TxtTickNo.Text)
    With myPKTICK
      .GetOneRecordP(WrkTickNo)
      ._STATUS = ""
      ._DATE1 = 0
      ._DATE2 = 0
      ._DATE3 = 0
      ._AMT1 = 0
      ._AMT2 = 0
      ._AMT3 = 0
      .UpdateOneRecordP()
    End With
    Me.Close()

  End Sub
Private Sub MoveToFile()
  Dim WrkAmount As Decimal
  With myPKTICK
    If RbNormal.Checked Then ._STATUS = "P"
    If RbOriginal.Checked Then ._STATUS = "O"
    If RbVoid.Checked Then ._STATUS = "V"
    If RbOverLate.Checked Then ._STATUS = "L"

    If RbOriginal.Checked Then
      WrkAmount = MyUtils.CnvSng(LblViAmt.Text)
    Else
      WrkAmount = MyUtils.CnvSng(LblCurAmt.Text) - ._AMT1
    End If
    If Not RbVoid.Checked Then
      If ._DATE1 = 0 Then
        ._DATE1 = MyUtils.SetDBDate(DtPckDatepd.Value)
        ._AMT1 = WrkAmount
       Exit Sub
      End If
      If ._DATE2 = 0 Then
        ._DATE2 = MyUtils.SetDBDate(DtPckDatepd.Value)
        ._AMT2 = WrkAmount
       Exit Sub
      End If
      If ._DATE3 = 0 Then
        ._DATE3 = MyUtils.SetDBDate(DtPckDatepd.Value)
        ._AMT3 = WrkAmount
      End If
    End If
  End With
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
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

  End Sub
  Private Sub FrmPK120C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    MyFrmPK120.SbpScreen.Text = "PK120C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
Private Function CalcVIAmt() As Decimal
  Dim WrkAmt As Decimal
  Dim WrkDays As Integer

  If RbNormal.Checked Then
    WrkAmt = myPKTICK._VIAMT
    WrkDays = DateDiff(DateInterval.Day, MyUtils.GetDBDate(myPKTICK._VDATE), DtPckDatepd.Value)
    If WrkDays >= myPKCNTL._DAYDBL Then
      WrkAmt = WrkAmt * 2
    End If
  End If
  If RbVoid.Checked Then
    WrkAmt = 0
  End If
  If RbOriginal.Checked Or RbOverLate.Checked Then
    WrkAmt = myPKTICK._VIAMT
  End If
  Return WrkAmt
End Function

Private Sub DtPckDatepd_ValueChanged(sender As Object, e As EventArgs) Handles DtPckDatepd.ValueChanged
  LblCurAmt.Text = Format(CalcVIAmt(), "Fixed")
End Sub
Private Sub RbNormal_Click(sender As Object, e As EventArgs) Handles RbNormal.Click
  LblCurAmt.Text = Format(CalcVIAmt(), "Fixed")
End Sub
Private Sub RbOriginal_Click(sender As Object, e As EventArgs) Handles RbOriginal.Click
  LblCurAmt.Text = Format(CalcVIAmt(), "Fixed")
End Sub
Private Sub RbVoid_Click(sender As Object, e As EventArgs) Handles RbVoid.Click
  LblCurAmt.Text = Format(CalcVIAmt(), "Fixed")
End Sub
Private Sub RbOverLate_Click(sender As Object, e As EventArgs) Handles RbOverLate.Click
  LblCurAmt.Text = Format(CalcVIAmt(), "Fixed")
End Sub
End Class
