Public Class FrmTX101C
  Inherits System.Windows.Forms.Form
  Dim ds As DataSet = New DataSet
  Friend Wrkprtype As String
  Friend Wrkpryear As Single
  Friend Wrkphs As String
  Friend WithEvents LblIntPct As System.Windows.Forms.Label
  Friend Wrkdist As Single
  Friend WithEvents TxtPosted As System.Windows.Forms.TextBox
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents RbPayCalcED As RadioButton
  Friend WrkCopyMode As Boolean

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
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Txtprtype As System.Windows.Forms.TextBox
  Friend WithEvents txtpryear As System.Windows.Forms.TextBox
  Friend WithEvents TxTphs As System.Windows.Forms.TextBox
  Friend WithEvents Txtdist As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Txtprint As System.Windows.Forms.TextBox
  Friend WithEvents Txtprpeni As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Txtprsbil As System.Windows.Forms.TextBox
  Friend WithEvents Txtprwav As System.Windows.Forms.TextBox
  Friend WithEvents Txtprlien As System.Windows.Forms.TextBox
  Friend WithEvents Txtprmini As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbBillPer1 As System.Windows.Forms.RadioButton
  Friend WithEvents RbBillPer2 As System.Windows.Forms.RadioButton
  Friend WithEvents RbBillPer3 As System.Windows.Forms.RadioButton
  Friend WithEvents RbBillPer4 As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents RbPayCalcUE As System.Windows.Forms.RadioButton
  Friend WithEvents RbPayCalcDE As System.Windows.Forms.RadioButton
  Friend WithEvents RbPayCalcAC As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents DtPckDue1 As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents DtPckGrace1 As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents DtPckGrace2 As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckDue2 As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckGrace3 As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckDue3 As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckGrace4 As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckDue4 As System.Windows.Forms.DateTimePicker
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents BtnFill As System.Windows.Forms.Button
  Friend WithEvents DtPckFill As System.Windows.Forms.DateTimePicker
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Txtprtype = New System.Windows.Forms.TextBox()
    Me.txtpryear = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxTphs = New System.Windows.Forms.TextBox()
    Me.Txtdist = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Txtprint = New System.Windows.Forms.TextBox()
    Me.Txtprmini = New System.Windows.Forms.TextBox()
    Me.Txtprpeni = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Txtprsbil = New System.Windows.Forms.TextBox()
    Me.Txtprwav = New System.Windows.Forms.TextBox()
    Me.Txtprlien = New System.Windows.Forms.TextBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbBillPer4 = New System.Windows.Forms.RadioButton()
    Me.RbBillPer3 = New System.Windows.Forms.RadioButton()
    Me.RbBillPer2 = New System.Windows.Forms.RadioButton()
    Me.RbBillPer1 = New System.Windows.Forms.RadioButton()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbPayCalcUE = New System.Windows.Forms.RadioButton()
    Me.RbPayCalcDE = New System.Windows.Forms.RadioButton()
    Me.RbPayCalcAC = New System.Windows.Forms.RadioButton()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.DtPckGrace4 = New System.Windows.Forms.DateTimePicker()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.DtPckDue4 = New System.Windows.Forms.DateTimePicker()
    Me.DtPckGrace3 = New System.Windows.Forms.DateTimePicker()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.DtPckDue3 = New System.Windows.Forms.DateTimePicker()
    Me.DtPckGrace2 = New System.Windows.Forms.DateTimePicker()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.DtPckDue2 = New System.Windows.Forms.DateTimePicker()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.DtPckGrace1 = New System.Windows.Forms.DateTimePicker()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.DtPckDue1 = New System.Windows.Forms.DateTimePicker()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.BtnFill = New System.Windows.Forms.Button()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.DtPckFill = New System.Windows.Forms.DateTimePicker()
    Me.LblIntPct = New System.Windows.Forms.Label()
    Me.TxtPosted = New System.Windows.Forms.TextBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.RbPayCalcED = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(116, 24)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Property Type && Year"
    '
    'Txtprtype
    '
    Me.Txtprtype.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txtprtype.Location = New System.Drawing.Point(132, 12)
    Me.Txtprtype.MaxLength = 1
    Me.Txtprtype.Name = "Txtprtype"
    Me.Txtprtype.Size = New System.Drawing.Size(16, 20)
    Me.Txtprtype.TabIndex = 0
    '
    'txtpryear
    '
    Me.txtpryear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtpryear.Location = New System.Drawing.Point(156, 12)
    Me.txtpryear.MaxLength = 4
    Me.txtpryear.Name = "txtpryear"
    Me.txtpryear.Size = New System.Drawing.Size(40, 20)
    Me.txtpryear.TabIndex = 1
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(232, 12)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(40, 24)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Phase"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(316, 12)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(48, 24)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "District"
    '
    'TxTphs
    '
    Me.TxTphs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxTphs.Location = New System.Drawing.Point(280, 12)
    Me.TxTphs.MaxLength = 1
    Me.TxTphs.Name = "TxTphs"
    Me.TxTphs.Size = New System.Drawing.Size(20, 20)
    Me.TxTphs.TabIndex = 2
    '
    'Txtdist
    '
    Me.Txtdist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txtdist.Location = New System.Drawing.Point(372, 12)
    Me.Txtdist.MaxLength = 3
    Me.Txtdist.Name = "Txtdist"
    Me.Txtdist.Size = New System.Drawing.Size(28, 20)
    Me.Txtdist.TabIndex = 3
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(32, 88)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(92, 24)
    Me.Label5.TabIndex = 8
    Me.Label5.Text = "Monthly Interest"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(32, 112)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(92, 24)
    Me.Label6.TabIndex = 9
    Me.Label6.Text = "Minimum Interest"
    Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(32, 136)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(92, 24)
    Me.Label7.TabIndex = 10
    Me.Label7.Text = "Penalty Interest"
    Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Txtprint
    '
    Me.Txtprint.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txtprint.Location = New System.Drawing.Point(132, 88)
    Me.Txtprint.MaxLength = 6
    Me.Txtprint.Name = "Txtprint"
    Me.Txtprint.Size = New System.Drawing.Size(56, 20)
    Me.Txtprint.TabIndex = 4
    '
    'Txtprmini
    '
    Me.Txtprmini.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txtprmini.Location = New System.Drawing.Point(132, 112)
    Me.Txtprmini.MaxLength = 5
    Me.Txtprmini.Name = "Txtprmini"
    Me.Txtprmini.Size = New System.Drawing.Size(56, 20)
    Me.Txtprmini.TabIndex = 5
    '
    'Txtprpeni
    '
    Me.Txtprpeni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txtprpeni.Location = New System.Drawing.Point(132, 136)
    Me.Txtprpeni.MaxLength = 5
    Me.Txtprpeni.Name = "Txtprpeni"
    Me.Txtprpeni.Size = New System.Drawing.Size(56, 20)
    Me.Txtprpeni.TabIndex = 6
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(252, 88)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(112, 24)
    Me.Label8.TabIndex = 12
    Me.Label8.Text = "Minimum Single Bill"
    Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(252, 112)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(112, 24)
    Me.Label9.TabIndex = 13
    Me.Label9.Text = "Waiver Amount"
    Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(252, 136)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(112, 24)
    Me.Label10.TabIndex = 14
    Me.Label10.Text = "Lien Amount"
    Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Txtprsbil
    '
    Me.Txtprsbil.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txtprsbil.Location = New System.Drawing.Point(372, 88)
    Me.Txtprsbil.MaxLength = 6
    Me.Txtprsbil.Name = "Txtprsbil"
    Me.Txtprsbil.Size = New System.Drawing.Size(56, 20)
    Me.Txtprsbil.TabIndex = 7
    '
    'Txtprwav
    '
    Me.Txtprwav.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txtprwav.Location = New System.Drawing.Point(372, 112)
    Me.Txtprwav.MaxLength = 6
    Me.Txtprwav.Name = "Txtprwav"
    Me.Txtprwav.Size = New System.Drawing.Size(56, 20)
    Me.Txtprwav.TabIndex = 8
    '
    'Txtprlien
    '
    Me.Txtprlien.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txtprlien.Location = New System.Drawing.Point(372, 136)
    Me.Txtprlien.MaxLength = 6
    Me.Txtprlien.Name = "Txtprlien"
    Me.Txtprlien.Size = New System.Drawing.Size(56, 20)
    Me.Txtprlien.TabIndex = 9
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbBillPer4)
    Me.GroupBox1.Controls.Add(Me.RbBillPer3)
    Me.GroupBox1.Controls.Add(Me.RbBillPer2)
    Me.GroupBox1.Controls.Add(Me.RbBillPer1)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(32, 40)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(180, 40)
    Me.GroupBox1.TabIndex = 3
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Billing Periods"
    '
    'RbBillPer4
    '
    Me.RbBillPer4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbBillPer4.Location = New System.Drawing.Point(144, 16)
    Me.RbBillPer4.Name = "RbBillPer4"
    Me.RbBillPer4.Size = New System.Drawing.Size(32, 16)
    Me.RbBillPer4.TabIndex = 3
    Me.RbBillPer4.Text = "4"
    '
    'RbBillPer3
    '
    Me.RbBillPer3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbBillPer3.Location = New System.Drawing.Point(100, 16)
    Me.RbBillPer3.Name = "RbBillPer3"
    Me.RbBillPer3.Size = New System.Drawing.Size(32, 16)
    Me.RbBillPer3.TabIndex = 2
    Me.RbBillPer3.Text = "3"
    '
    'RbBillPer2
    '
    Me.RbBillPer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbBillPer2.Location = New System.Drawing.Point(56, 16)
    Me.RbBillPer2.Name = "RbBillPer2"
    Me.RbBillPer2.Size = New System.Drawing.Size(32, 16)
    Me.RbBillPer2.TabIndex = 1
    Me.RbBillPer2.Text = "2"
    '
    'RbBillPer1
    '
    Me.RbBillPer1.Checked = True
    Me.RbBillPer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbBillPer1.Location = New System.Drawing.Point(12, 16)
    Me.RbBillPer1.Name = "RbBillPer1"
    Me.RbBillPer1.Size = New System.Drawing.Size(32, 16)
    Me.RbBillPer1.TabIndex = 0
    Me.RbBillPer1.TabStop = True
    Me.RbBillPer1.Text = "1"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbPayCalcED)
    Me.GroupBox2.Controls.Add(Me.RbPayCalcUE)
    Me.GroupBox2.Controls.Add(Me.RbPayCalcDE)
    Me.GroupBox2.Controls.Add(Me.RbPayCalcAC)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(48, 184)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(140, 80)
    Me.GroupBox2.TabIndex = 10
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Payment Calculation"
    '
    'RbPayCalcUE
    '
    Me.RbPayCalcUE.Checked = True
    Me.RbPayCalcUE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPayCalcUE.Location = New System.Drawing.Point(12, 12)
    Me.RbPayCalcUE.Name = "RbPayCalcUE"
    Me.RbPayCalcUE.Size = New System.Drawing.Size(104, 16)
    Me.RbPayCalcUE.TabIndex = 2
    Me.RbPayCalcUE.TabStop = True
    Me.RbPayCalcUE.Text = "Up && Equal"
    '
    'RbPayCalcDE
    '
    Me.RbPayCalcDE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPayCalcDE.Location = New System.Drawing.Point(12, 28)
    Me.RbPayCalcDE.Name = "RbPayCalcDE"
    Me.RbPayCalcDE.Size = New System.Drawing.Size(104, 16)
    Me.RbPayCalcDE.TabIndex = 1
    Me.RbPayCalcDE.Text = "Down && Equal"
    '
    'RbPayCalcAC
    '
    Me.RbPayCalcAC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPayCalcAC.Location = New System.Drawing.Point(12, 44)
    Me.RbPayCalcAC.Name = "RbPayCalcAC"
    Me.RbPayCalcAC.Size = New System.Drawing.Size(108, 16)
    Me.RbPayCalcAC.TabIndex = 0
    Me.RbPayCalcAC.Text = "Actual"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.DtPckGrace4)
    Me.GroupBox3.Controls.Add(Me.Label16)
    Me.GroupBox3.Controls.Add(Me.DtPckDue4)
    Me.GroupBox3.Controls.Add(Me.DtPckGrace3)
    Me.GroupBox3.Controls.Add(Me.Label15)
    Me.GroupBox3.Controls.Add(Me.DtPckDue3)
    Me.GroupBox3.Controls.Add(Me.DtPckGrace2)
    Me.GroupBox3.Controls.Add(Me.Label14)
    Me.GroupBox3.Controls.Add(Me.DtPckDue2)
    Me.GroupBox3.Controls.Add(Me.Label13)
    Me.GroupBox3.Controls.Add(Me.DtPckGrace1)
    Me.GroupBox3.Controls.Add(Me.Label11)
    Me.GroupBox3.Controls.Add(Me.Label4)
    Me.GroupBox3.Controls.Add(Me.DtPckDue1)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(216, 164)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(212, 120)
    Me.GroupBox3.TabIndex = 11
    Me.GroupBox3.TabStop = False
    '
    'DtPckGrace4
    '
    Me.DtPckGrace4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckGrace4.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckGrace4.Location = New System.Drawing.Point(124, 96)
    Me.DtPckGrace4.Name = "DtPckGrace4"
    Me.DtPckGrace4.Size = New System.Drawing.Size(84, 20)
    Me.DtPckGrace4.TabIndex = 13
    '
    'Label16
    '
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.Location = New System.Drawing.Point(4, 100)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(24, 12)
    Me.Label16.TabIndex = 12
    Me.Label16.Text = "4th"
    '
    'DtPckDue4
    '
    Me.DtPckDue4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckDue4.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckDue4.Location = New System.Drawing.Point(32, 96)
    Me.DtPckDue4.Name = "DtPckDue4"
    Me.DtPckDue4.Size = New System.Drawing.Size(84, 20)
    Me.DtPckDue4.TabIndex = 11
    '
    'DtPckGrace3
    '
    Me.DtPckGrace3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckGrace3.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckGrace3.Location = New System.Drawing.Point(124, 72)
    Me.DtPckGrace3.Name = "DtPckGrace3"
    Me.DtPckGrace3.Size = New System.Drawing.Size(84, 20)
    Me.DtPckGrace3.TabIndex = 10
    '
    'Label15
    '
    Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label15.Location = New System.Drawing.Point(4, 76)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(24, 12)
    Me.Label15.TabIndex = 9
    Me.Label15.Text = "3rd"
    '
    'DtPckDue3
    '
    Me.DtPckDue3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckDue3.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckDue3.Location = New System.Drawing.Point(32, 72)
    Me.DtPckDue3.Name = "DtPckDue3"
    Me.DtPckDue3.Size = New System.Drawing.Size(84, 20)
    Me.DtPckDue3.TabIndex = 8
    '
    'DtPckGrace2
    '
    Me.DtPckGrace2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckGrace2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckGrace2.Location = New System.Drawing.Point(124, 48)
    Me.DtPckGrace2.Name = "DtPckGrace2"
    Me.DtPckGrace2.Size = New System.Drawing.Size(84, 20)
    Me.DtPckGrace2.TabIndex = 7
    '
    'Label14
    '
    Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label14.Location = New System.Drawing.Point(4, 52)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(25, 12)
    Me.Label14.TabIndex = 6
    Me.Label14.Text = "2nd"
    '
    'DtPckDue2
    '
    Me.DtPckDue2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckDue2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckDue2.Location = New System.Drawing.Point(32, 48)
    Me.DtPckDue2.Name = "DtPckDue2"
    Me.DtPckDue2.Size = New System.Drawing.Size(84, 20)
    Me.DtPckDue2.TabIndex = 5
    '
    'Label13
    '
    Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label13.Location = New System.Drawing.Point(128, 8)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(72, 16)
    Me.Label13.TabIndex = 4
    Me.Label13.Text = "Grace Dates"
    '
    'DtPckGrace1
    '
    Me.DtPckGrace1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckGrace1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckGrace1.Location = New System.Drawing.Point(124, 24)
    Me.DtPckGrace1.Name = "DtPckGrace1"
    Me.DtPckGrace1.Size = New System.Drawing.Size(84, 20)
    Me.DtPckGrace1.TabIndex = 3
    '
    'Label11
    '
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.Location = New System.Drawing.Point(40, 8)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(60, 16)
    Me.Label11.TabIndex = 2
    Me.Label11.Text = "Due Dates"
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(4, 28)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(24, 12)
    Me.Label4.TabIndex = 1
    Me.Label4.Text = "1st"
    '
    'DtPckDue1
    '
    Me.DtPckDue1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckDue1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckDue1.Location = New System.Drawing.Point(32, 24)
    Me.DtPckDue1.Name = "DtPckDue1"
    Me.DtPckDue1.Size = New System.Drawing.Size(84, 20)
    Me.DtPckDue1.TabIndex = 0
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.BtnFill)
    Me.GroupBox4.Controls.Add(Me.Label12)
    Me.GroupBox4.Controls.Add(Me.DtPckFill)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(216, 284)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(212, 48)
    Me.GroupBox4.TabIndex = 15
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Autofill Due && Grace Dates"
    '
    'BtnFill
    '
    Me.BtnFill.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFill.Location = New System.Drawing.Point(176, 16)
    Me.BtnFill.Name = "BtnFill"
    Me.BtnFill.Size = New System.Drawing.Size(28, 24)
    Me.BtnFill.TabIndex = 3
    Me.BtnFill.Text = "Fill"
    '
    'Label12
    '
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(4, 24)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(72, 12)
    Me.Label12.TabIndex = 2
    Me.Label12.Text = "1st Due Date"
    '
    'DtPckFill
    '
    Me.DtPckFill.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckFill.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFill.Location = New System.Drawing.Point(84, 20)
    Me.DtPckFill.Name = "DtPckFill"
    Me.DtPckFill.Size = New System.Drawing.Size(84, 20)
    Me.DtPckFill.TabIndex = 1
    '
    'LblIntPct
    '
    Me.LblIntPct.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblIntPct.Location = New System.Drawing.Point(194, 91)
    Me.LblIntPct.Name = "LblIntPct"
    Me.LblIntPct.Size = New System.Drawing.Size(61, 17)
    Me.LblIntPct.TabIndex = 16
    '
    'TxtPosted
    '
    Me.TxtPosted.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPosted.Location = New System.Drawing.Point(112, 308)
    Me.TxtPosted.MaxLength = 1
    Me.TxtPosted.Name = "TxtPosted"
    Me.TxtPosted.Size = New System.Drawing.Size(22, 20)
    Me.TxtPosted.TabIndex = 17
    Me.TxtPosted.TabStop = False
    '
    'Label17
    '
    Me.Label17.Location = New System.Drawing.Point(12, 308)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(92, 16)
    Me.Label17.TabIndex = 18
    Me.Label17.Text = "Posted Status"
    Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'RbPayCalcED
    '
    Me.RbPayCalcED.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPayCalcED.Location = New System.Drawing.Point(12, 60)
    Me.RbPayCalcED.Name = "RbPayCalcED"
    Me.RbPayCalcED.Size = New System.Drawing.Size(108, 16)
    Me.RbPayCalcED.TabIndex = 3
    Me.RbPayCalcED.Text = "UB EDU 1st Half"
    '
    'FrmTX101C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(442, 340)
    Me.Controls.Add(Me.TxtPosted)
    Me.Controls.Add(Me.Label17)
    Me.Controls.Add(Me.LblIntPct)
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Txtprlien)
    Me.Controls.Add(Me.Txtprwav)
    Me.Controls.Add(Me.Txtprsbil)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.Txtprpeni)
    Me.Controls.Add(Me.Txtprmini)
    Me.Controls.Add(Me.Txtprint)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Txtdist)
    Me.Controls.Add(Me.TxTphs)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.txtpryear)
    Me.Controls.Add(Me.Txtprtype)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX101C"
    Me.Text = "Maintain Billing Information"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox4.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region


  Private Sub FrmTX101C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkProfCalc As String
    Dim WrkProfPerd As Integer

    InitFiles()
    MyFrmTX101.TBarNew.Enabled = False
    MyFrmTX101.TBarSave.Enabled = True
    MyFrmTX101.TBarCopy.Enabled = False
    If WrkCopyMode Then
      MyFrmTX101.TBarDelete.Enabled = False
    End If
    If Wrkprtype <> String.Empty Then
      MyFrmTX101.TBarDelete.Enabled = True
      MyUtils.SetTxtReadOnly(Txtprtype)
      MyUtils.SetTxtReadOnly(txtpryear)
      MyUtils.SetTxtReadOnly(TxTphs)
      MyUtils.SetTxtReadOnly(Txtdist)
    Else
      DtPckDue1.Value = Date.Today
      DtPckDue2.Value = Date.Today
      DtPckDue3.Value = Date.Today
      DtPckDue4.Value = Date.Today
      DtPckGrace1.Value = Date.Today
      DtPckGrace2.Value = Date.Today
      DtPckGrace3.Value = Date.Today
      DtPckGrace4.Value = Date.Today
    End If
    DtPckFill.Value = Date.Today
    MyFrmTX101.TBarPrint.Enabled = False
    myTXPROF.GetOneRecordP(Wrkprtype, Wrkpryear, Wrkphs, Wrkdist)

    Txtprtype.Text = Wrkprtype
    txtpryear.Text = MyUtils.CnvSng(Wrkpryear)
    TxTphs.Text = Wrkphs
    Txtdist.Text = Wrkdist

    If WrkCopyMode Then
      'Copy mode - Use last year's data
      Wrkpryear = Wrkpryear - 1
      myTXPROF.GetOneRecordP(Wrkprtype, Wrkpryear, Wrkphs, Wrkdist)
    Else
      If myTXPROF.RecordNotFound Then
        Exit Sub
      End If
    End If

    With myTXPROF
      WrkProfCalc = ._PRPAYC
      Select Case WrkProfCalc
        Case "AC"
          RbPayCalcAC.Checked = True
        Case "DE"
          RbPayCalcDE.Checked = True
        Case "ED"
          RbPayCalcED.Checked = True
        Case "UE"
          RbPayCalcUE.Checked = True
      End Select
      Txtprint.Text = ._PRINT
      Txtprmini.Text = ._PRMINI
      Txtprpeni.Text = ._PRPENI
      Txtprsbil.Text = ._PRSBIL
      Txtprwav.Text = ._PRWAV
      Txtprlien.Text = ._PRLIEN
      WrkProfPerd = ._PRPERD
      Select Case WrkProfPerd
        Case 1
          RbBillPer1.Checked = True
        Case 2
          RbBillPer2.Checked = True
        Case 3
          RbBillPer3.Checked = True
        Case 4
          RbBillPer4.Checked = True
      End Select
      If ._PRDUE1 > 0 Then
        DtPckDue1.Value = MyUtils.GetDBDateMDY(._PRDUE1)
      End If
      If ._PRDUE2 > 0 Then
        DtPckDue2.Value = MyUtils.GetDBDateMDY(._PRDUE2)
      End If
      If ._PRDUE3 > 0 Then
        DtPckDue3.Value = MyUtils.GetDBDateMDY(._PRDUE3)
      End If
      If ._PRDUE4 > 0 Then
        DtPckDue4.Value = MyUtils.GetDBDateMDY(._PRDUE4)
      End If
      If ._PRGRD1 > 0 Then
        DtPckGrace1.Value = MyUtils.GetDBDateMDY(._PRGRD1)
      End If
      If ._PRGRD2 > 0 Then
        DtPckGrace2.Value = MyUtils.GetDBDateMDY(._PRGRD2)
      End If
      If ._PRGRD3 > 0 Then
        DtPckGrace3.Value = MyUtils.GetDBDateMDY(._PRGRD3)
      End If
      If ._PRGRD4 > 0 Then
        DtPckGrace4.Value = MyUtils.GetDBDateMDY(._PRGRD4)
      End If
      If Not WrkCopyMode Then
        TxtPosted.Text = Trim(._POSTED)
      End If
    End With

    'Copy Mode - Add one year to all dates
    If WrkCopyMode And Not myTXPROF.RecordNotFound Then
      DtPckDue1.Value = DateAdd(DateInterval.Year, 1, DtPckDue1.Value)
      DtPckDue2.Value = DateAdd(DateInterval.Year, 1, DtPckDue2.Value)
      DtPckDue3.Value = DateAdd(DateInterval.Year, 1, DtPckDue3.Value)
      DtPckDue4.Value = DateAdd(DateInterval.Year, 1, DtPckDue4.Value)
      DtPckGrace1.Value = DateAdd(DateInterval.Year, 1, DtPckGrace1.Value)
      DtPckGrace2.Value = DateAdd(DateInterval.Year, 1, DtPckGrace2.Value)
      DtPckGrace3.Value = DateAdd(DateInterval.Year, 1, DtPckGrace3.Value)
      DtPckGrace4.Value = DateAdd(DateInterval.Year, 1, DtPckGrace4.Value)
      Wrkprtype = String.Empty
    End If

    ShowIntPct()
    ShowVisibleDates()
  End Sub

  Private Sub FrmTX101C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX101.SbpScreen.Text = "TX101C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub

  Private Sub FrmTX101C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTX101.TBarNew.Enabled = True
    MyFrmTX101.TBarDelete.Enabled = False
    MyFrmTX101.TBarSave.Enabled = False
    MyFrmTX101.TBarCopy.Enabled = True
    MyFrmTX101.TBarNew.Enabled = True
    MyFrmTX101.TBarPrint.Enabled = False
    MyFrmTX101B.FormatGrid()
    MyFrmTX101B.Show()
    'Memory Cleanup
    myTXPROF.CloseFile()
    myTXPROF = Nothing
    MyFrmTX101C = Nothing
  End Sub
  Private Sub ShowVisibleDates()
    DtPckDue2.Visible = False
    DtPckDue3.Visible = False
    DtPckDue4.Visible = False
    DtPckGrace2.Visible = False
    DtPckGrace3.Visible = False
    DtPckGrace4.Visible = False
    If RbBillPer1.Checked Then Exit Sub

    DtPckDue2.Visible = True
    DtPckGrace2.Visible = True
    If RbBillPer2.Checked Then Exit Sub

    DtPckDue3.Visible = True
    DtPckGrace3.Visible = True
    If RbBillPer3.Checked Then Exit Sub

    DtPckDue4.Visible = True
    DtPckGrace4.Visible = True

  End Sub

  Public Sub DeleteData()
    Dim Answer As Integer
    Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
    If Answer = vbNo Then
      Exit Sub
    End If

    myTXPROF.GetOneRecordP(Txtprtype.Text, txtpryear.Text, TxTphs.Text, Txtdist.Text)
    myTXPROF.DeleteOneRecordP()
    Me.Close()
  End Sub

  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    myTXPROF.GetOneRecordP(Txtprtype.Text, txtpryear.Text, TxTphs.Text, Txtdist.Text)
    If Wrkprtype = String.Empty Then
      If Not myTXPROF.RecordNotFound Then
        Me.ErrProv.SetError(Txtprtype, "Record already exists")
        Exit Sub
      End If
    End If
    If Not myTXPROF.RecordNotFound Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXPROF.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXPROF.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    Me.Close()
  End Sub
  Private Sub MovetoFile()
    With myTXPROF
      ._PRYEAR = MyUtils.CnvSng(txtpryear.Text)
      ._PRTYPE = Txtprtype.Text
      ._PHS = TxTphs.Text
      ._DIST = MyUtils.CnvSng(Txtdist.Text)
      If RbPayCalcAC.Checked Then
        ._PRPAYC = "AC"
      End If
      If RbPayCalcDE.Checked Then
        ._PRPAYC = "DE"
      End If
      If RbPayCalcED.Checked Then
        ._PRPAYC = "ED"
      End If
      If RbPayCalcUE.Checked Then
        ._PRPAYC = "UE"
      End If
      ._PRINT = MyUtils.CnvSng(Txtprint.Text)
      ._PRMINI = MyUtils.CnvSng(Txtprmini.Text)
      ._PRPENI = MyUtils.CnvSng(Txtprpeni.Text)
      ._PRSBIL = MyUtils.CnvSng(Txtprsbil.Text)
      ._PRWAV = MyUtils.CnvSng(Txtprwav.Text)
      ._PRLIEN = MyUtils.CnvSng(Txtprlien.Text)
      If RbBillPer1.Checked Then
        ._PRPERD = 1
      End If
      If RbBillPer2.Checked Then
        ._PRPERD = 2
      End If
      If RbBillPer3.Checked Then
        ._PRPERD = 3
      End If
      If RbBillPer4.Checked Then
        ._PRPERD = 4
      End If
      ._PRDUE1 = MyUtils.SetDBDateMDY(DtPckDue1.Value)
      If Not DtPckDue2.Visible Then
        ._PRDUE2 = 0
      Else
        ._PRDUE2 = MyUtils.SetDBDateMDY(DtPckDue2.Value)
      End If
      If Not DtPckDue3.Visible Then
        ._PRDUE3 = 0
      Else
        ._PRDUE3 = MyUtils.SetDBDateMDY(DtPckDue3.Value)
      End If
      If Not DtPckDue4.Visible Then
        ._PRDUE4 = 0
      Else
        ._PRDUE4 = MyUtils.SetDBDateMDY(DtPckDue4.Value)
      End If
      ._PRGRD1 = MyUtils.SetDBDateMDY(DtPckGrace1.Value)
      If Not DtPckGrace2.Visible Then
        ._PRGRD2 = 0
      Else
        ._PRGRD2 = MyUtils.SetDBDateMDY(DtPckGrace2.Value)
      End If
      If Not DtPckGrace3.Visible Then
        ._PRGRD3 = 0
      Else
        ._PRGRD3 = MyUtils.SetDBDateMDY(DtPckGrace3.Value)
      End If
      If Not DtPckGrace4.Visible Then
        ._PRGRD4 = 0
      Else
        ._PRGRD4 = MyUtils.SetDBDateMDY(DtPckGrace4.Value)
      End If
      ._POSTED = TxtPosted.Text
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(txtpryear.Text) = 0 Then
      ErrorField(I) = "prtype"
      ErrorMsg(I) = "Type is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(txtpryear.Text) = 0 Then
      ErrorField(I) = "pryear"
      ErrorMsg(I) = "Year is required"
      I = I + 1
    End If

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(Txtprtype, String.Empty)
    ErrProv.SetError(txtpryear, String.Empty)
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "prtype"
          ErrProv.SetError(Txtprtype, ErrorMsg(I))
        Case "pryear"
          ErrProv.SetError(txtpryear, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub

  Private Sub Txtprint_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtprint.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub

  Private Sub Txtprmini_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtprmini.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub

  Private Sub Txtprpeni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtprpeni.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub

  Private Sub Txtprsbil_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtprsbil.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub

  Private Sub Txtprwav_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtprwav.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub

  Private Sub Txtprlien_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtprlien.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub

  Private Sub txtpryear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpryear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub Txtdist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtdist.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub RbBillPer1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbBillPer1.CheckedChanged
    ShowVisibleDates()
  End Sub
  Private Sub RbBillPer2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbBillPer2.CheckedChanged
    ShowVisibleDates()
  End Sub
  Private Sub RbBillPer3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbBillPer3.CheckedChanged
    ShowVisibleDates()
  End Sub
  Private Sub RbBillPer4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbBillPer4.CheckedChanged
    ShowVisibleDates()
  End Sub
  Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFill.Click

    DtPckDue1.Value = DtPckFill.Value
    DtPckGrace1.Value = DateAdd(DateInterval.Month, 1, DtPckFill.Value)
    If RbBillPer1.Checked Then Exit Sub

    If RbBillPer2.Checked Then
      DtPckDue2.Value = DateAdd(DateInterval.Month, 6, DtPckFill.Value)
      DtPckGrace2.Value = DateAdd(DateInterval.Month, 7, DtPckFill.Value)
    End If

    If RbBillPer3.Checked Then
      DtPckDue2.Value = DateAdd(DateInterval.Month, 4, DtPckFill.Value)
      DtPckGrace2.Value = DateAdd(DateInterval.Month, 5, DtPckFill.Value)
      DtPckDue3.Value = DateAdd(DateInterval.Month, 8, DtPckFill.Value)
      DtPckGrace3.Value = DateAdd(DateInterval.Month, 9, DtPckFill.Value)
    End If

    If RbBillPer4.Checked Then
      DtPckDue2.Value = DateAdd(DateInterval.Month, 3, DtPckFill.Value)
      DtPckGrace2.Value = DateAdd(DateInterval.Month, 4, DtPckFill.Value)
      DtPckDue3.Value = DateAdd(DateInterval.Month, 6, DtPckFill.Value)
      DtPckGrace3.Value = DateAdd(DateInterval.Month, 7, DtPckFill.Value)
      DtPckDue4.Value = DateAdd(DateInterval.Month, 9, DtPckFill.Value)
      DtPckGrace4.Value = DateAdd(DateInterval.Month, 10, DtPckFill.Value)
    End If
  End Sub

  Private Sub Txtprint_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtprint.TextChanged
    ShowIntPct()
  End Sub
  Private Sub ShowIntPct()
    Dim WrkIntPct As Decimal
    WrkIntPct = MyUtils.CnvSng(Txtprint.Text) * 100
    LblIntPct.Text = Format(WrkIntPct, "##.##") & "%"
  End Sub
End Class






