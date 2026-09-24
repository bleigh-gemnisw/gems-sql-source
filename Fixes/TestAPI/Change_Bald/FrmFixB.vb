Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Security.AccessControl
Imports System.Security.Cryptography

Public Class FrmFixB
  Inherits System.Windows.Forms.Form

  Dim myTXINV As TXINV.MyData
  Dim myTXHST As TXHST.MyData
  Dim myTXTYPE As TXTYPE.MyData

  Dim WrkList As Integer
  Dim WrkYear As Integer
  Dim WrkType As String
  Dim Good As Boolean
  Friend WithEvents LblProperty2 As Label
  Friend WithEvents LblProperty As Label
  Friend WithEvents LblZip4 As Label
  Friend WithEvents LblZip5 As Label
  Friend WithEvents LblState As Label
  Friend WithEvents LblCity As Label
  Friend WithEvents LblAdd2 As Label
  Friend WithEvents LblAdd1 As Label
  Friend WithEvents LblSname As Label
  Friend WithEvents LblName As Label
  Friend WithEvents label37 As Label
  Friend WithEvents label10 As Label
  Friend WithEvents label9 As Label
  Friend WithEvents label8 As Label
  Friend WithEvents Label6 As Label
  Friend WithEvents Label13 As Label
  Friend WithEvents GroupBox1 As GroupBox
  Friend WithEvents LblPaid As Label
  Friend WithEvents Label12 As Label
  Friend WithEvents TxtInterest As TextBox
  Friend WithEvents Label15 As Label
  Friend WithEvents TxtPrincipal As TextBox
  Friend WithEvents Label16 As Label
  Friend WithEvents Label17 As Label
  Friend WithEvents DtPckInt As DateTimePicker
  Friend WithEvents Label7 As Label
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
  '    Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtDBName As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtType As System.Windows.Forms.TextBox
  Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
  Friend WithEvents Label5 As Label
  Friend WithEvents TxtList As TextBox
  Friend WithEvents GroupBox2 As GroupBox
  Friend WithEvents Label20 As Label
  Friend WithEvents LblChgTax As Label
  Friend WithEvents Label34 As Label
  Friend WithEvents LblOrigTax As Label
  Friend WithEvents Label30 As Label
  Friend WithEvents LblOrig As Label
  Friend WithEvents TxtBald As TextBox
  Friend WithEvents LblBond As Label
  Friend WithEvents LblChgBald As Label
  Friend WithEvents LblOrigBald As Label
  Friend WithEvents LblTax As Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtDBName = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtList = New System.Windows.Forms.TextBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.LblTax = New System.Windows.Forms.Label()
    Me.TxtBald = New System.Windows.Forms.TextBox()
    Me.LblBond = New System.Windows.Forms.Label()
    Me.LblChgBald = New System.Windows.Forms.Label()
    Me.LblOrigBald = New System.Windows.Forms.Label()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.LblChgTax = New System.Windows.Forms.Label()
    Me.Label34 = New System.Windows.Forms.Label()
    Me.LblOrigTax = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.LblOrig = New System.Windows.Forms.Label()
    Me.LblProperty2 = New System.Windows.Forms.Label()
    Me.LblProperty = New System.Windows.Forms.Label()
    Me.LblZip4 = New System.Windows.Forms.Label()
    Me.LblZip5 = New System.Windows.Forms.Label()
    Me.LblState = New System.Windows.Forms.Label()
    Me.LblCity = New System.Windows.Forms.Label()
    Me.LblAdd2 = New System.Windows.Forms.Label()
    Me.LblAdd1 = New System.Windows.Forms.Label()
    Me.LblSname = New System.Windows.Forms.Label()
    Me.LblName = New System.Windows.Forms.Label()
    Me.label37 = New System.Windows.Forms.Label()
    Me.label10 = New System.Windows.Forms.Label()
    Me.label9 = New System.Windows.Forms.Label()
    Me.label8 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.DtPckInt = New System.Windows.Forms.DateTimePicker()
    Me.LblPaid = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TxtInterest = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.TxtPrincipal = New System.Windows.Forms.TextBox()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(12, 299)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(262, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Change Total, Balance Due , Installment"
    '
    'TxtDBName
    '
    Me.TxtDBName.Location = New System.Drawing.Point(100, 23)
    Me.TxtDBName.Name = "TxtDBName"
    Me.TxtDBName.Size = New System.Drawing.Size(126, 20)
    Me.TxtDBName.TabIndex = 0
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 26)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(82, 13)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "Database name"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(43, 113)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(51, 13)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "G/L Year"
    '
    'TxtYear
    '
    Me.TxtYear.Location = New System.Drawing.Point(100, 110)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(39, 20)
    Me.TxtYear.TabIndex = 3
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(63, 87)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(31, 13)
    Me.Label4.TabIndex = 6
    Me.Label4.Text = "Type"
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Location = New System.Drawing.Point(100, 84)
    Me.TxtType.MaxLength = 1
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(22, 20)
    Me.TxtType.TabIndex = 2
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(63, 57)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(30, 13)
    Me.Label5.TabIndex = 8
    Me.Label5.Text = "List#"
    '
    'TxtList
    '
    Me.TxtList.Location = New System.Drawing.Point(99, 54)
    Me.TxtList.MaxLength = 7
    Me.TxtList.Name = "TxtList"
    Me.TxtList.Size = New System.Drawing.Size(61, 20)
    Me.TxtList.TabIndex = 1
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.LblTax)
    Me.GroupBox2.Controls.Add(Me.TxtBald)
    Me.GroupBox2.Controls.Add(Me.LblBond)
    Me.GroupBox2.Controls.Add(Me.LblChgBald)
    Me.GroupBox2.Controls.Add(Me.LblOrigBald)
    Me.GroupBox2.Controls.Add(Me.Label20)
    Me.GroupBox2.Controls.Add(Me.LblChgTax)
    Me.GroupBox2.Controls.Add(Me.Label34)
    Me.GroupBox2.Controls.Add(Me.LblOrigTax)
    Me.GroupBox2.Controls.Add(Me.Label30)
    Me.GroupBox2.Controls.Add(Me.LblOrig)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(15, 175)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(245, 108)
    Me.GroupBox2.TabIndex = 171
    Me.GroupBox2.TabStop = False
    '
    'LblTax
    '
    Me.LblTax.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTax.Location = New System.Drawing.Point(151, 64)
    Me.LblTax.Name = "LblTax"
    Me.LblTax.Size = New System.Drawing.Size(80, 16)
    Me.LblTax.TabIndex = 194
    Me.LblTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtBald
    '
    Me.TxtBald.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBald.Location = New System.Drawing.Point(64, 60)
    Me.TxtBald.MaxLength = 9
    Me.TxtBald.Name = "TxtBald"
    Me.TxtBald.Size = New System.Drawing.Size(80, 20)
    Me.TxtBald.TabIndex = 0
    Me.TxtBald.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblBond
    '
    Me.LblBond.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBond.ForeColor = System.Drawing.Color.Black
    Me.LblBond.Location = New System.Drawing.Point(64, 16)
    Me.LblBond.Name = "LblBond"
    Me.LblBond.Size = New System.Drawing.Size(84, 16)
    Me.LblBond.TabIndex = 192
    Me.LblBond.Text = "Balance Due"
    '
    'LblChgBald
    '
    Me.LblChgBald.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgBald.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgBald.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgBald.Location = New System.Drawing.Point(64, 88)
    Me.LblChgBald.Name = "LblChgBald"
    Me.LblChgBald.Size = New System.Drawing.Size(80, 16)
    Me.LblChgBald.TabIndex = 191
    Me.LblChgBald.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblOrigBald
    '
    Me.LblOrigBald.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigBald.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigBald.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigBald.Location = New System.Drawing.Point(64, 40)
    Me.LblOrigBald.Name = "LblOrigBald"
    Me.LblOrigBald.Size = New System.Drawing.Size(80, 16)
    Me.LblOrigBald.TabIndex = 190
    Me.LblOrigBald.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label20
    '
    Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label20.ForeColor = System.Drawing.Color.Black
    Me.Label20.Location = New System.Drawing.Point(161, 16)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(66, 16)
    Me.Label20.TabIndex = 188
    Me.Label20.Text = "Total Tax"
    '
    'LblChgTax
    '
    Me.LblChgTax.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgTax.Location = New System.Drawing.Point(151, 88)
    Me.LblChgTax.Name = "LblChgTax"
    Me.LblChgTax.Size = New System.Drawing.Size(80, 16)
    Me.LblChgTax.TabIndex = 21
    Me.LblChgTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label34
    '
    Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label34.Location = New System.Drawing.Point(10, 87)
    Me.Label34.Name = "Label34"
    Me.Label34.Size = New System.Drawing.Size(48, 16)
    Me.Label34.TabIndex = 20
    Me.Label34.Text = "Change"
    '
    'LblOrigTax
    '
    Me.LblOrigTax.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigTax.Location = New System.Drawing.Point(151, 40)
    Me.LblOrigTax.Name = "LblOrigTax"
    Me.LblOrigTax.Size = New System.Drawing.Size(80, 16)
    Me.LblOrigTax.TabIndex = 18
    Me.LblOrigTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label30
    '
    Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label30.Location = New System.Drawing.Point(10, 63)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(48, 16)
    Me.Label30.TabIndex = 16
    Me.Label30.Text = "New"
    '
    'LblOrig
    '
    Me.LblOrig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrig.Location = New System.Drawing.Point(10, 39)
    Me.LblOrig.Name = "LblOrig"
    Me.LblOrig.Size = New System.Drawing.Size(64, 16)
    Me.LblOrig.TabIndex = 15
    Me.LblOrig.Text = "Original"
    '
    'LblProperty2
    '
    Me.LblProperty2.BackColor = System.Drawing.SystemColors.Control
    Me.LblProperty2.Location = New System.Drawing.Point(365, 143)
    Me.LblProperty2.Name = "LblProperty2"
    Me.LblProperty2.Size = New System.Drawing.Size(229, 25)
    Me.LblProperty2.TabIndex = 243
    '
    'LblProperty
    '
    Me.LblProperty.BackColor = System.Drawing.SystemColors.Control
    Me.LblProperty.Location = New System.Drawing.Point(365, 127)
    Me.LblProperty.Name = "LblProperty"
    Me.LblProperty.Size = New System.Drawing.Size(229, 16)
    Me.LblProperty.TabIndex = 242
    '
    'LblZip4
    '
    Me.LblZip4.BackColor = System.Drawing.SystemColors.Control
    Me.LblZip4.Location = New System.Drawing.Point(557, 103)
    Me.LblZip4.Name = "LblZip4"
    Me.LblZip4.Size = New System.Drawing.Size(36, 16)
    Me.LblZip4.TabIndex = 241
    '
    'LblZip5
    '
    Me.LblZip5.BackColor = System.Drawing.SystemColors.Control
    Me.LblZip5.Location = New System.Drawing.Point(517, 103)
    Me.LblZip5.Name = "LblZip5"
    Me.LblZip5.Size = New System.Drawing.Size(36, 16)
    Me.LblZip5.TabIndex = 240
    '
    'LblState
    '
    Me.LblState.BackColor = System.Drawing.SystemColors.Control
    Me.LblState.Location = New System.Drawing.Point(489, 103)
    Me.LblState.Name = "LblState"
    Me.LblState.Size = New System.Drawing.Size(24, 16)
    Me.LblState.TabIndex = 239
    '
    'LblCity
    '
    Me.LblCity.BackColor = System.Drawing.SystemColors.Control
    Me.LblCity.Location = New System.Drawing.Point(365, 103)
    Me.LblCity.Name = "LblCity"
    Me.LblCity.Size = New System.Drawing.Size(146, 16)
    Me.LblCity.TabIndex = 238
    '
    'LblAdd2
    '
    Me.LblAdd2.BackColor = System.Drawing.SystemColors.Control
    Me.LblAdd2.Location = New System.Drawing.Point(365, 87)
    Me.LblAdd2.Name = "LblAdd2"
    Me.LblAdd2.Size = New System.Drawing.Size(256, 16)
    Me.LblAdd2.TabIndex = 237
    '
    'LblAdd1
    '
    Me.LblAdd1.BackColor = System.Drawing.SystemColors.Control
    Me.LblAdd1.Location = New System.Drawing.Point(365, 63)
    Me.LblAdd1.Name = "LblAdd1"
    Me.LblAdd1.Size = New System.Drawing.Size(256, 20)
    Me.LblAdd1.TabIndex = 236
    Me.LblAdd1.UseMnemonic = False
    '
    'LblSname
    '
    Me.LblSname.BackColor = System.Drawing.SystemColors.Control
    Me.LblSname.Location = New System.Drawing.Point(365, 47)
    Me.LblSname.Name = "LblSname"
    Me.LblSname.Size = New System.Drawing.Size(256, 16)
    Me.LblSname.TabIndex = 235
    Me.LblSname.UseMnemonic = False
    '
    'LblName
    '
    Me.LblName.BackColor = System.Drawing.SystemColors.Control
    Me.LblName.Location = New System.Drawing.Point(365, 23)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(256, 16)
    Me.LblName.TabIndex = 234
    Me.LblName.UseMnemonic = False
    '
    'label37
    '
    Me.label37.BackColor = System.Drawing.SystemColors.Control
    Me.label37.Location = New System.Drawing.Point(273, 127)
    Me.label37.Name = "label37"
    Me.label37.Size = New System.Drawing.Size(64, 16)
    Me.label37.TabIndex = 233
    Me.label37.Text = "Property"
    '
    'label10
    '
    Me.label10.BackColor = System.Drawing.SystemColors.Control
    Me.label10.Location = New System.Drawing.Point(273, 103)
    Me.label10.Name = "label10"
    Me.label10.Size = New System.Drawing.Size(84, 12)
    Me.label10.TabIndex = 232
    Me.label10.Text = "City/State/Zip"
    '
    'label9
    '
    Me.label9.BackColor = System.Drawing.SystemColors.Control
    Me.label9.Location = New System.Drawing.Point(273, 63)
    Me.label9.Name = "label9"
    Me.label9.Size = New System.Drawing.Size(84, 12)
    Me.label9.TabIndex = 231
    Me.label9.Text = "Mail Address"
    '
    'label8
    '
    Me.label8.BackColor = System.Drawing.SystemColors.Control
    Me.label8.Location = New System.Drawing.Point(273, 47)
    Me.label8.Name = "label8"
    Me.label8.Size = New System.Drawing.Size(84, 12)
    Me.label8.TabIndex = 230
    Me.label8.Text = "Second Name"
    '
    'Label6
    '
    Me.Label6.BackColor = System.Drawing.SystemColors.Control
    Me.Label6.Location = New System.Drawing.Point(273, 23)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(84, 12)
    Me.Label6.TabIndex = 229
    Me.Label6.Text = "Name of Owner"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(145, 113)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(67, 13)
    Me.Label7.TabIndex = 244
    Me.Label7.Text = "(Press Enter)"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.Label17)
    Me.GroupBox1.Controls.Add(Me.DtPckInt)
    Me.GroupBox1.Controls.Add(Me.LblPaid)
    Me.GroupBox1.Controls.Add(Me.Label12)
    Me.GroupBox1.Controls.Add(Me.TxtInterest)
    Me.GroupBox1.Controls.Add(Me.Label15)
    Me.GroupBox1.Controls.Add(Me.TxtPrincipal)
    Me.GroupBox1.Controls.Add(Me.Label16)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(307, 182)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(261, 96)
    Me.GroupBox1.TabIndex = 245
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Payment"
    '
    'Label17
    '
    Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label17.Location = New System.Drawing.Point(169, 20)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(72, 16)
    Me.Label17.TabIndex = 167
    Me.Label17.Text = "Date Paid"
    '
    'DtPckInt
    '
    Me.DtPckInt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckInt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckInt.Location = New System.Drawing.Point(158, 39)
    Me.DtPckInt.Name = "DtPckInt"
    Me.DtPckInt.Size = New System.Drawing.Size(96, 20)
    Me.DtPckInt.TabIndex = 166
    '
    'LblPaid
    '
    Me.LblPaid.BackColor = System.Drawing.SystemColors.Control
    Me.LblPaid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPaid.Location = New System.Drawing.Point(70, 72)
    Me.LblPaid.Name = "LblPaid"
    Me.LblPaid.Size = New System.Drawing.Size(80, 12)
    Me.LblPaid.TabIndex = 4
    Me.LblPaid.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label12
    '
    Me.Label12.BackColor = System.Drawing.SystemColors.Control
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(8, 67)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(56, 12)
    Me.Label12.TabIndex = 163
    Me.Label12.Text = "Total"
    '
    'TxtInterest
    '
    Me.TxtInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtInterest.Location = New System.Drawing.Point(70, 40)
    Me.TxtInterest.MaxLength = 8
    Me.TxtInterest.Name = "TxtInterest"
    Me.TxtInterest.Size = New System.Drawing.Size(80, 20)
    Me.TxtInterest.TabIndex = 7
    Me.TxtInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label15
    '
    Me.Label15.BackColor = System.Drawing.SystemColors.Control
    Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label15.Location = New System.Drawing.Point(6, 40)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(48, 12)
    Me.Label15.TabIndex = 157
    Me.Label15.Text = "Interest"
    '
    'TxtPrincipal
    '
    Me.TxtPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPrincipal.Location = New System.Drawing.Point(70, 16)
    Me.TxtPrincipal.MaxLength = 12
    Me.TxtPrincipal.Name = "TxtPrincipal"
    Me.TxtPrincipal.Size = New System.Drawing.Size(80, 20)
    Me.TxtPrincipal.TabIndex = 6
    Me.TxtPrincipal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label16
    '
    Me.Label16.BackColor = System.Drawing.SystemColors.Control
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.Location = New System.Drawing.Point(6, 16)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(48, 12)
    Me.Label16.TabIndex = 155
    Me.Label16.Text = "Principal"
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.BackColor = System.Drawing.SystemColors.Control
    Me.Label13.Location = New System.Drawing.Point(266, 231)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(35, 13)
    Me.Label13.TabIndex = 246
    Me.Label13.Text = "- OR -"
    '
    'FrmFixB
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(648, 331)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.LblProperty2)
    Me.Controls.Add(Me.LblProperty)
    Me.Controls.Add(Me.LblZip4)
    Me.Controls.Add(Me.LblZip5)
    Me.Controls.Add(Me.LblState)
    Me.Controls.Add(Me.LblCity)
    Me.Controls.Add(Me.LblAdd2)
    Me.Controls.Add(Me.LblAdd1)
    Me.Controls.Add(Me.LblSname)
    Me.Controls.Add(Me.LblName)
    Me.Controls.Add(Me.label37)
    Me.Controls.Add(Me.label10)
    Me.Controls.Add(Me.label9)
    Me.Controls.Add(Me.label8)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtList)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtType)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtDBName)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.MaximizeBox = False
    Me.Name = "FrmFixB"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmFixB_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmFix.SbpScreen.Text = "FixB"
    CenterForm(Me.ParentForm, Me)
  End Sub

  Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      ValidateData()
    End If
  End Sub
  Public Function Connect() As Boolean
    Dim Good As Boolean

    myDBConnect = New SQLConnect.DBConnection(MyDBName)
    myDBConnect.Open()
    Good = myDBConnect.IsConnected
    If Not Good Then
      MsgBox("Invalid database name", MsgBoxStyle.Critical, "Check database name")
    End If
    Return Good
  End Function
  Public Sub ValidateData()
    Dim WrkFamily As String

    MyDBName = MyFrmFixB.TxtDBName.Text
    Good = Connect()
    If Not Good Then Exit Sub

    myTXINV = New TXINV.MyData(myDBConnect)
    myTXHST = New TXHST.MyData(myDBConnect)
    myTXTYPE = New TXTYPE.MyData(myDBConnect)

    WrkList = CnvSng(TxtList.Text)
    WrkType = TxtType.Text
    WrkYear = CnvSng(TxtYear.Text)
    With myTXINV
      myTXINV.GetOneRecordP(WrkList, WrkYear, WrkType)
      LblOrigTax.Text = FormatNumber(._TAXT, 2)
      LblOrigBald.Text = FormatNumber(._BALD, 2)
      LblName.Text = Trim(._NAME)
      LblSname.Text = String.Empty
      If Not IsDBNull(._SNAME) Then
        LblSname.Text = Trim(._SNAME)
      End If
      LblAdd1.Text = Trim(._ADD1)
      LblAdd2.Text = String.Empty
      If Not IsDBNull(._ADD2) Then
        LblAdd2.Text = Trim(._ADD2)
      End If
      LblCity.Text = Trim(._CITY)
      LblState.Text = Trim(._STATE)
      LblZip5.Text = Format(._ZIP5, "00000")
      LblZip4.Text = Format(._ZIP4, "0000")
      LblProperty.Text = String.Empty
      LblProperty2.Text = String.Empty

      WrkFamily = GetTXTypeFamily(WrkType)
      Select Case WrkFamily
        Case "M", "S"
          LblProperty.Text = Trim(._IMVREG) & " - " & Trim(._IMVIDNo) 'Used by print
          LblProperty2.Text = Trim(._MAKE) & " - " & Trim(._MODEL) &
         " - " & ._MVYR & " - " & Format(._CLASS, "00")
        Case "P"
          If Not IsDBNull(._LOC) Then
            LblProperty.Text = Trim(._LOCNo) & " " & ._LOC
          End If
        Case "R"
          If Not IsDBNull(._LOC) Then
            LblProperty.Text = Trim(._LOCNo) & " " & ._LOC
          End If
          If Not IsDBNull(._MAP) Then
            LblProperty2.Text = Trim(._MAP)
          End If
        Case "A"
          If Not IsDBNull(._LOC) Then
            LblProperty.Text = Trim(._LOCNo) & " " & ._LOC
          End If
        Case "U"
          If Not IsDBNull(._LOC) Then
            LblProperty.Text = Trim(._LOCNo) & " " & ._LOC
          End If
      End Select
    End With
  End Sub
  Public Sub UpdateFile()
    Dim WrkRecID As Integer
    Dim WrkChgBalance As Boolean
    Dim WrkDate As Integer
    Dim WrkAdjTax As Decimal

    If CnvSng(LblChgTax.Text) = 0 And CnvSng(LblPaid.Text) <= 0 Then
      Exit Sub
    End If

    If Not Good Then
      MyDBName = MyFrmFixB.TxtDBName.Text
      Good = Connect()
    End If
    If Not Good Then Exit Sub

    myTXINV = New TXINV.MyData(myDBConnect)
    myTXHST = New TXHST.MyData(myDBConnect)
    myTXTYPE = New TXTYPE.MyData(myDBConnect)

    WrkChgBalance = False
    With myTXINV
      .GetOneRecordP(WrkList, WrkYear, WrkType)
      If .RecordNotFound Then
        Exit Sub
      End If
      If CnvSng(LblChgTax.Text) <> 0 Then
        'Change Balance
        WrkChgBalance = True
        WrkDate = SetDBDate(Date.Today)
        ._BALD = CnvSng(TxtBald.Text)
        ._TAXT = CnvSng(LblTax.Text)
        If ._TX4TH > 0 Then
          ._TX4TH = ._TX4TH + CnvSng(LblChgTax.Text)
        Else
          If ._TX3RD > 0 Then
            ._TX3RD = ._TX3RD + CnvSng(LblChgTax.Text)
          Else
            If ._TAX2 > 0 Then
              ._TAX2 = ._TAX2 + CnvSng(LblChgTax.Text)
            Else
              ._TAX1 = ._TAX1 + CnvSng(LblChgTax.Text)
            End If
          End If
        End If
        .UpdateOneRecordP()
      Else
        If CnvSng(LblPaid.Text) > 0 Then
          'Add Payment
          WrkDate = SetDBDate(DtPckInt.Value)
          If WrkDate > ._TXIDT Then
            ._TXIDT = WrkDate
          End If
          If ._CCNO > 0 Then
            If ._ICODE = "E" Then
              WrkAdjTax = ._CCETAX + ._DEFERT
            Else
              WrkAdjTax = ._CCETAX
            End If
          Else
            If ._ICODE = "D" Then
              WrkAdjTax = ._TAXT - ._DEFERT
            Else
              WrkAdjTax = ._TAXT
            End If
          End If
          ._PAYREC = ._PAYREC + CnvSng(TxtPrincipal.Text)
          ._BALD = WrkAdjTax - ._PAYREC
          ._INTPD = ._INTPD + CnvSng(TxtInterest.Text)
          .UpdateOneRecordP()
        End If
      End If
    End With

    With myTXHST
      WrkRecID = .AutoGenKey
      If WrkChgBalance Then
        ._PAMT = CnvSng(LblChgTax.Text)
        ._RCODE = "I"
        ._IAMT = 0
        ._COMM = "Change Balance Due"
      Else
        ._PAMT = CnvSng(TxtPrincipal.Text)
        ._RCODE = ""
        ._IAMT = CnvSng(TxtInterest.Text)
        ._COMM = "Add History Record"
      End If
      ._BATCHA = ""
      ._BATCHN = 0
      ._BATCHS = 0
      ._CASH = 0
      ._CDATE = WrkDate
      ._CHDATE = SetDBDate(Date.Today)
      ._CHECK = 0
      ._CHTIME = SetDBTime(DateTime.Now)
      ._CORC = ""
      ._CREDIT = 0
      ._DIST = myTXINV._DIST
      ._INTOR = 0
      ._LAMT = 0
      ._LISTNO = WrkList
      ._PDATE = WrkDate
      ._PCAMT = 0
      ._PENCD = ""
      ._RECID = WrkRecID
      ._REF = ""
      ._SUSCD = ""
      ._THAJCD = ""
      ._THINPD = ""
      ._TYPE = WrkType
      ._YEAR = WrkYear
      ._PRF = "ChgBald"
      .InsertOneRecordP()
    End With

    ClearScreen()
  End Sub
  Public Sub ClearScreen()
    LblOrigTax.Text = String.Empty
    LblOrigBald.Text = String.Empty
    LblName.Text = String.Empty
    LblSname.Text = String.Empty
    LblAdd1.Text = String.Empty
    LblAdd2.Text = String.Empty
    LblCity.Text = String.Empty
    LblState.Text = String.Empty
    LblZip5.Text = String.Empty
    LblZip4.Text = String.Empty
    LblProperty.Text = String.Empty
    LblProperty2.Text = String.Empty
    TxtBald.Text = String.Empty
    LblOrigBald.Text = String.Empty
    LblOrigTax.Text = String.Empty
    LblTax.Text = String.Empty
    LblChgBald.Text = String.Empty
    LblChgTax.Text = String.Empty
    TxtPrincipal.Text = String.Empty
    TxtInterest.Text = String.Empty
    LblPaid.Text = String.Empty
  End Sub

  Public Function GetTXTypeFamily(ByVal Code As String) As String
    Dim myTXTYPE As TXTYPE.MyData

    myTXTYPE = New TXTYPE.MyData(myDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myTXTYPE.GetOneRecordP(Code)
    If Not myTXTYPE.RecordNotFound Then
      GetTXTypeFamily = Trim(myTXTYPE._TXFAM)
    Else
      GetTXTypeFamily = "*** Unknown ***"
    End If
    myTXTYPE.CloseFile()
    myTXTYPE = Nothing
    Return GetTXTypeFamily

  End Function

  Private Sub TxtBald_TextChanged(sender As Object, e As EventArgs) Handles TxtBald.TextChanged
    If Not TxtBald.Modified Then Exit Sub
    CalcChg()
  End Sub
  Private Sub CalcChg()
    LblChgBald.Text = FormatNumber(CnvSng(TxtBald.Text) - CnvSng(LblOrigBald.Text), 2)
    LblTax.Text = FormatNumber(CnvSng(LblOrigTax.Text) + CnvSng(LblChgBald.Text), 2)
    LblChgTax.Text = FormatNumber(CnvSng(LblTax.Text) - CnvSng(LblOrigTax.Text), 2)
  End Sub
  Private Sub TxtPrincipal_TextChanged(sender As Object, e As EventArgs) Handles TxtPrincipal.TextChanged
    If Not TxtPrincipal.Modified Then Exit Sub
    CalcPaid()
  End Sub
  Private Sub TxtInterest_TextChanged(sender As Object, e As EventArgs) Handles TxtInterest.TextChanged
    If Not TxtInterest.Modified Then Exit Sub
    CalcPaid()
  End Sub
  Private Sub CalcPaid()
    LblPaid.Text = FormatNumber(CnvSng(TxtPrincipal.Text) + CnvSng(TxtInterest.Text), 2)
  End Sub

  Private Sub FrmFixB_Load(sender As Object, e As EventArgs) Handles MyBase.Load

  End Sub
End Class
