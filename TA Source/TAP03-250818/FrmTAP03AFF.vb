Public Class FrmTAP03AFF
  Inherits System.Windows.Forms.Form
  Dim MyTXDVAFF As TXDVAFF.myData
  Dim MyTXDVPP As TXDVPP.myData
  Dim LoadScrn As Boolean
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer

  Friend WithEvents LblYear As System.Windows.Forms.Label
  Friend WithEvents LblListNo As System.Windows.Forms.Label
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtSigned As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents TxtAddr As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents RbTranMoved As System.Windows.Forms.RadioButton
  Friend WithEvents RbTranSold As System.Windows.Forms.RadioButton
  Friend WithEvents DtPckTran As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtZip4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtZip5 As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents LblAddr As System.Windows.Forms.Label
  Friend WithEvents LblName As System.Windows.Forms.Label
  Friend WithEvents LblZip4 As System.Windows.Forms.Label
  Friend WithEvents LblZip5 As System.Windows.Forms.Label
  Friend WithEvents LblState As System.Windows.Forms.Label
  Friend WithEvents LblCity As System.Windows.Forms.Label
  Friend WithEvents Label29 As System.Windows.Forms.Label



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
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LblYear = New System.Windows.Forms.Label()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblZip4 = New System.Windows.Forms.Label()
    Me.LblZip5 = New System.Windows.Forms.Label()
    Me.LblState = New System.Windows.Forms.Label()
    Me.LblCity = New System.Windows.Forms.Label()
    Me.LblAddr = New System.Windows.Forms.Label()
    Me.LblName = New System.Windows.Forms.Label()
    Me.TxtSigned = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TxtAddr = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.RbTranMoved = New System.Windows.Forms.RadioButton()
    Me.RbTranSold = New System.Windows.Forms.RadioButton()
    Me.DtPckTran = New System.Windows.Forms.DateTimePicker()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtZip4 = New System.Windows.Forms.TextBox()
    Me.TxtZip5 = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.TxtState = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblYear.Location = New System.Drawing.Point(187, 8)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(33, 18)
    Me.LblYear.TabIndex = 213
    Me.LblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblListNo
    '
    Me.LblListNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblListNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblListNo.Location = New System.Drawing.Point(65, 8)
    Me.LblListNo.Name = "LblListNo"
    Me.LblListNo.Size = New System.Drawing.Size(64, 18)
    Me.LblListNo.TabIndex = 212
    Me.LblListNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label30
    '
    Me.Label30.Location = New System.Drawing.Point(8, 9)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(51, 17)
    Me.Label30.TabIndex = 215
    Me.Label30.Text = "List No"
    '
    'Label29
    '
    Me.Label29.Location = New System.Drawing.Point(150, 9)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(35, 17)
    Me.Label29.TabIndex = 214
    Me.Label29.Text = "Year"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LblZip4)
    Me.GroupBox1.Controls.Add(Me.LblZip5)
    Me.GroupBox1.Controls.Add(Me.LblState)
    Me.GroupBox1.Controls.Add(Me.LblCity)
    Me.GroupBox1.Controls.Add(Me.LblAddr)
    Me.GroupBox1.Controls.Add(Me.LblName)
    Me.GroupBox1.Controls.Add(Me.TxtSigned)
    Me.GroupBox1.Controls.Add(Me.Label13)
    Me.GroupBox1.Controls.Add(Me.Label12)
    Me.GroupBox1.Controls.Add(Me.TxtAddr)
    Me.GroupBox1.Controls.Add(Me.Label5)
    Me.GroupBox1.Controls.Add(Me.RbTranMoved)
    Me.GroupBox1.Controls.Add(Me.RbTranSold)
    Me.GroupBox1.Controls.Add(Me.DtPckTran)
    Me.GroupBox1.Controls.Add(Me.Label9)
    Me.GroupBox1.Controls.Add(Me.Label6)
    Me.GroupBox1.Controls.Add(Me.Label3)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Controls.Add(Me.Label1)
    Me.GroupBox1.Controls.Add(Me.TxtName)
    Me.GroupBox1.Controls.Add(Me.Label14)
    Me.GroupBox1.Controls.Add(Me.Label8)
    Me.GroupBox1.Controls.Add(Me.TxtZip4)
    Me.GroupBox1.Controls.Add(Me.TxtZip5)
    Me.GroupBox1.Controls.Add(Me.Label4)
    Me.GroupBox1.Controls.Add(Me.TxtCity)
    Me.GroupBox1.Controls.Add(Me.TxtState)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(12, 41)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(858, 327)
    Me.GroupBox1.TabIndex = 216
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "AFFIDAVIT OF SALE OF PERSONAL PROPERTY"
    '
    'LblZip4
    '
    Me.LblZip4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblZip4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblZip4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblZip4.Location = New System.Drawing.Point(819, 29)
    Me.LblZip4.Name = "LblZip4"
    Me.LblZip4.Size = New System.Drawing.Size(32, 18)
    Me.LblZip4.TabIndex = 241
    Me.LblZip4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblZip5
    '
    Me.LblZip5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblZip5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblZip5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblZip5.Location = New System.Drawing.Point(773, 29)
    Me.LblZip5.Name = "LblZip5"
    Me.LblZip5.Size = New System.Drawing.Size(40, 18)
    Me.LblZip5.TabIndex = 240
    Me.LblZip5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblState
    '
    Me.LblState.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblState.Location = New System.Drawing.Point(741, 29)
    Me.LblState.Name = "LblState"
    Me.LblState.Size = New System.Drawing.Size(26, 18)
    Me.LblState.TabIndex = 239
    Me.LblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblCity
    '
    Me.LblCity.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCity.Location = New System.Drawing.Point(509, 29)
    Me.LblCity.Name = "LblCity"
    Me.LblCity.Size = New System.Drawing.Size(226, 18)
    Me.LblCity.TabIndex = 238
    Me.LblCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblAddr
    '
    Me.LblAddr.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAddr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAddr.Location = New System.Drawing.Point(277, 29)
    Me.LblAddr.Name = "LblAddr"
    Me.LblAddr.Size = New System.Drawing.Size(226, 18)
    Me.LblAddr.TabIndex = 237
    Me.LblAddr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblName
    '
    Me.LblName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblName.Location = New System.Drawing.Point(23, 29)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(226, 18)
    Me.LblName.TabIndex = 236
    Me.LblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtSigned
    '
    Me.TxtSigned.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSigned.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSigned.Location = New System.Drawing.Point(9, 272)
    Me.TxtSigned.MaxLength = 35
    Me.TxtSigned.Name = "TxtSigned"
    Me.TxtSigned.Size = New System.Drawing.Size(280, 20)
    Me.TxtSigned.TabIndex = 11
    '
    'Label13
    '
    Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label13.Location = New System.Drawing.Point(8, 294)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(183, 20)
    Me.Label13.TabIndex = 231
    Me.Label13.Text = "Print Name"
    '
    'Label12
    '
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(6, 251)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(660, 18)
    Me.Label12.TabIndex = 229
    Me.Label12.Text = "The signer is made aware that the penalty for making a false affidavit is a $500." &
    "00 fine or imprisonment for one year or both."
    '
    'TxtAddr
    '
    Me.TxtAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAddr.Location = New System.Drawing.Point(208, 166)
    Me.TxtAddr.MaxLength = 35
    Me.TxtAddr.Name = "TxtAddr"
    Me.TxtAddr.Size = New System.Drawing.Size(280, 20)
    Me.TxtAddr.TabIndex = 6
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(118, 172)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(80, 16)
    Me.Label5.TabIndex = 227
    Me.Label5.Text = "Address"
    '
    'RbTranMoved
    '
    Me.RbTranMoved.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbTranMoved.Location = New System.Drawing.Point(16, 182)
    Me.RbTranMoved.Name = "RbTranMoved"
    Me.RbTranMoved.Size = New System.Drawing.Size(78, 18)
    Me.RbTranMoved.TabIndex = 224
    Me.RbTranMoved.Text = "Moved To:"
    '
    'RbTranSold
    '
    Me.RbTranSold.Checked = True
    Me.RbTranSold.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbTranSold.Location = New System.Drawing.Point(16, 155)
    Me.RbTranSold.Name = "RbTranSold"
    Me.RbTranSold.Size = New System.Drawing.Size(67, 18)
    Me.RbTranSold.TabIndex = 223
    Me.RbTranSold.TabStop = True
    Me.RbTranSold.Text = "Sold To:"
    '
    'DtPckTran
    '
    Me.DtPckTran.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckTran.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTran.Location = New System.Drawing.Point(335, 90)
    Me.DtPckTran.Name = "DtPckTran"
    Me.DtPckTran.Size = New System.Drawing.Size(93, 22)
    Me.DtPckTran.TabIndex = 4
    '
    'Label9
    '
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(20, 90)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(309, 18)
    Me.Label9.TabIndex = 219
    Me.Label9.Text = "With regards to said business or property I do so certify that on "
    '
    'Label6
    '
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(506, 49)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(183, 20)
    Me.Label6.TabIndex = 218
    Me.Label6.Text = "City, State and Zip"
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(274, 47)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(183, 20)
    Me.Label3.TabIndex = 215
    Me.Label3.Text = "Mailing Address"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(255, 29)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(16, 13)
    Me.Label2.TabIndex = 214
    Me.Label2.Text = "of"
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(20, 47)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(183, 20)
    Me.Label1.TabIndex = 212
    Me.Label1.Text = "Owners name"
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(208, 140)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(280, 20)
    Me.TxtName.TabIndex = 5
    '
    'Label14
    '
    Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label14.Location = New System.Drawing.Point(118, 146)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(80, 16)
    Me.Label14.TabIndex = 205
    Me.Label14.Text = "Name"
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(7, 29)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(10, 13)
    Me.Label8.TabIndex = 192
    Me.Label8.Text = "I"
    '
    'TxtZip4
    '
    Me.TxtZip4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip4.Location = New System.Drawing.Point(531, 196)
    Me.TxtZip4.MaxLength = 4
    Me.TxtZip4.Name = "TxtZip4"
    Me.TxtZip4.Size = New System.Drawing.Size(32, 20)
    Me.TxtZip4.TabIndex = 10
    '
    'TxtZip5
    '
    Me.TxtZip5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip5.Location = New System.Drawing.Point(483, 196)
    Me.TxtZip5.MaxLength = 5
    Me.TxtZip5.Name = "TxtZip5"
    Me.TxtZip5.Size = New System.Drawing.Size(40, 20)
    Me.TxtZip5.TabIndex = 9
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(118, 200)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(80, 16)
    Me.Label4.TabIndex = 191
    Me.Label4.Text = "City/State/Zip"
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(208, 196)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(232, 20)
    Me.TxtCity.TabIndex = 7
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(451, 196)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 20)
    Me.TxtState.TabIndex = 8
    '
    'FrmTAP03AFF
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(879, 382)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.LblListNo)
    Me.Controls.Add(Me.Label30)
    Me.Controls.Add(Me.Label29)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAP03AFF"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Move/Sale Affidavit"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub

#End Region

Private Sub FrmTAP03AFF_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP03
      .TbForms.Visible = True
      .TBarAff.Enabled = True
    End With
    MyFrmTAP03C.Show()
End Sub

  Private Sub FrmTAP03AFF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    MyTXDVAFF = New TXDVAFF.mydata(MyDBConnect)
    MyTXDVPP = New TXDVPP.mydata(MyDBConnect)

    LoadScrn = True
    With MyFrmTAP03
      .TbForms.Visible = False
      .TBarAff.Enabled = False
    End With

    LblListNo.Text = WrkListNo
    LblYear.Text = WrkYear
    MyTXDVPP.GetOneRecordP(WrkListNo, WrkYear)
    With MyTXDVPP
      LblName.Text = Trim(._NAME)
      LblAddr.Text = Trim(._ADDR)
      lblCity.Text = Trim(._CITY)
      lblState.Text = Trim(._STATE)
      If ._ZIP5 > 0 Then
        lblZip5.Text = Format(._ZIP5, "00000")
      End If
      If ._ZIP4 > 0 Then
        lblZip4.Text = Format(._ZIP4, "0000")
      End If
    End With

    MyTXDVAFF.GetOneRecordP(WrkListNo, WrkYear)
    If MyTXDVAFF.RecordNotFound Then
      Me.Text = "Add " & Me.Text
      MyFrmTAP03.TBarDelete.Enabled = False
      Exit Sub
    End If

    'Fill the dataset with the data
     With MyTXDVAFF
        TxtName.Text = Trim(._NAME)
        TxtAddr.Text = Trim(._ADDR)
        TxtCity.Text = Trim(._CITY)
        TxtState.Text = Trim(._STATE)
        If ._ZIP5 > 0 Then
          TxtZip5.Text = Format(._ZIP5, "00000")
        End If
        If ._ZIP4 > 0 Then
          TxtZip4.Text = Format(._ZIP4, "0000")
        End If
        DtPckTran.Value = MyUtils.GetDBDate(._TRANDT)
        Select Case Trim(._TRANTY)
        Case "S"
          RbTranSold.Checked = True
        Case "M"
          RbTranMoved.Checked = True
        End Select
        TxtSigned.Text = Trim(._SIGNED)
       End With
 End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete affidavit information?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    MyTXDVAFF.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    MyTXDVAFF.GetOneRecordP(WrkListNo, WrkYear)
    If Not MyTXDVAFF.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXDVAFF.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXDVAFF.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    Me.Close()
  End Sub
   Private Sub MoveToFile()
      With MyTXDVAFF
        ._LISTNO = WrkListNo
        ._YEAR = WrkYear
        ._NAME = TxtName.Text
        ._ADDR = TxtAddr.Text
        ._CITY = TxtCity.Text
        ._STATE = TxtState.Text
        ._ZIP5 = MyUtils.CnvSng(TxtZip5.Text)
        ._ZIP4 = MyUtils.CnvSng(TxtZip4.Text)
        ._TRANDT = MyUtils.SetDBDate(DtPckTran.Value)
        If RbTranSold.Checked Then ._TRANTY = "S"
        If RbTranMoved.Checked Then ._TRANTY = "M"
        ._SIGNED = TxtSigned.Text
      End With
   End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    'ErrProv.SetError(TxtListNo, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      'Case "listno"
        'ErrProv.SetError(TxtListNo, ErrorMsg(I))
      Case ""
        Exit Sub
      End Select
    Next I
  End Sub
  Private Sub FrmTAP03AFF_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP03.SbpScreen.Text = "TAP03AFF"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
End Class






