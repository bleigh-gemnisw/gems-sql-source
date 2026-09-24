Public Class FrmTAP01AFF
  Inherits System.Windows.Forms.Form
  Dim MyTXDCAFF As TXDCAFF.myData
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
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TxtAddr As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents RbTranClosing As System.Windows.Forms.RadioButton
  Friend WithEvents RbTranMoved As System.Windows.Forms.RadioButton
  Friend WithEvents RbTranSold As System.Windows.Forms.RadioButton
  Friend WithEvents DtPckTran As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents TxtBuname As System.Windows.Forms.TextBox
  Friend WithEvents TxtOwname As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
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
  Friend WithEvents TxtLoc As System.Windows.Forms.TextBox
  Friend WithEvents TxtLocNo As System.Windows.Forms.TextBox
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
    Me.TxtLoc = New System.Windows.Forms.TextBox()
    Me.TxtLocNo = New System.Windows.Forms.TextBox()
    Me.TxtSigned = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtAddr = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.RbTranClosing = New System.Windows.Forms.RadioButton()
    Me.RbTranMoved = New System.Windows.Forms.RadioButton()
    Me.RbTranSold = New System.Windows.Forms.RadioButton()
    Me.DtPckTran = New System.Windows.Forms.DateTimePicker()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TxtBuname = New System.Windows.Forms.TextBox()
    Me.TxtOwname = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
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
    Me.LblListNo.Size = New System.Drawing.Size(69, 18)
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
    Me.GroupBox1.Controls.Add(Me.TxtLoc)
    Me.GroupBox1.Controls.Add(Me.TxtLocNo)
    Me.GroupBox1.Controls.Add(Me.TxtSigned)
    Me.GroupBox1.Controls.Add(Me.Label13)
    Me.GroupBox1.Controls.Add(Me.Label12)
    Me.GroupBox1.Controls.Add(Me.Label10)
    Me.GroupBox1.Controls.Add(Me.TxtAddr)
    Me.GroupBox1.Controls.Add(Me.Label5)
    Me.GroupBox1.Controls.Add(Me.RbTranClosing)
    Me.GroupBox1.Controls.Add(Me.RbTranMoved)
    Me.GroupBox1.Controls.Add(Me.RbTranSold)
    Me.GroupBox1.Controls.Add(Me.DtPckTran)
    Me.GroupBox1.Controls.Add(Me.Label9)
    Me.GroupBox1.Controls.Add(Me.TxtBuname)
    Me.GroupBox1.Controls.Add(Me.TxtOwname)
    Me.GroupBox1.Controls.Add(Me.Label6)
    Me.GroupBox1.Controls.Add(Me.Label7)
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
    Me.GroupBox1.Size = New System.Drawing.Size(795, 384)
    Me.GroupBox1.TabIndex = 216
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "AFFIDAVIT OF BUSINESS CLOSING OR MOVE OR SALE OF BUSINESS OR PROPERTY"
    '
    'TxtLoc
    '
    Me.TxtLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLoc.Location = New System.Drawing.Point(586, 26)
    Me.TxtLoc.MaxLength = 25
    Me.TxtLoc.Name = "TxtLoc"
    Me.TxtLoc.Size = New System.Drawing.Size(200, 22)
    Me.TxtLoc.TabIndex = 3
    '
    'TxtLocNo
    '
    Me.TxtLocNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocNo.Location = New System.Drawing.Point(531, 26)
    Me.TxtLocNo.MaxLength = 7
    Me.TxtLocNo.Name = "TxtLocNo"
    Me.TxtLocNo.Size = New System.Drawing.Size(49, 22)
    Me.TxtLocNo.TabIndex = 2
    Me.TxtLocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtSigned
    '
    Me.TxtSigned.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSigned.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSigned.Location = New System.Drawing.Point(10, 330)
    Me.TxtSigned.MaxLength = 35
    Me.TxtSigned.Name = "TxtSigned"
    Me.TxtSigned.Size = New System.Drawing.Size(280, 20)
    Me.TxtSigned.TabIndex = 11
    '
    'Label13
    '
    Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label13.Location = New System.Drawing.Point(9, 352)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(183, 20)
    Me.Label13.TabIndex = 231
    Me.Label13.Text = "Print Name"
    '
    'Label12
    '
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(7, 309)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(660, 18)
    Me.Label12.TabIndex = 229
    Me.Label12.Text = "The signer is made aware that the penalty for making a false affidavit is a $500." &
    "00 fine or imprisonment for one year or both."
    '
    'Label10
    '
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(107, 256)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(589, 18)
    Me.Label10.TabIndex = 228
    Me.Label10.Text = "Attach Bill of Sale or Letter of dissoultion to this form and return it with this" &
    " affadavit to the Assessor's office"
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
    'RbTranClosing
    '
    Me.RbTranClosing.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbTranClosing.Location = New System.Drawing.Point(14, 253)
    Me.RbTranClosing.Name = "RbTranClosing"
    Me.RbTranClosing.Size = New System.Drawing.Size(87, 18)
    Me.RbTranClosing.TabIndex = 225
    Me.RbTranClosing.Text = "Terminated:"
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
    'TxtBuname
    '
    Me.TxtBuname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBuname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBuname.Location = New System.Drawing.Point(277, 26)
    Me.TxtBuname.MaxLength = 35
    Me.TxtBuname.Name = "TxtBuname"
    Me.TxtBuname.Size = New System.Drawing.Size(226, 20)
    Me.TxtBuname.TabIndex = 1
    '
    'TxtOwname
    '
    Me.TxtOwname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOwname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOwname.Location = New System.Drawing.Point(23, 26)
    Me.TxtOwname.MaxLength = 35
    Me.TxtOwname.Name = "TxtOwname"
    Me.TxtOwname.Size = New System.Drawing.Size(226, 20)
    Me.TxtOwname.TabIndex = 0
    '
    'Label6
    '
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(528, 47)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(183, 20)
    Me.Label6.TabIndex = 218
    Me.Label6.Text = "Street location in Town"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(509, 29)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(16, 13)
    Me.Label7.TabIndex = 217
    Me.Label7.Text = "at"
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(274, 47)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(183, 20)
    Me.Label3.TabIndex = 215
    Me.Label3.Text = "Business Name (if applicable)"
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
    Me.Label1.Text = "Business or property owners name"
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
    'FrmTAP01AFF
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(819, 437)
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
    Me.Name = "FrmTAP01AFF"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Closing/Move/Sale Affidavit"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub

#End Region

Private Sub FrmTAP01AFF_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP01
      .TbForms.Visible = True
      .TBarAff.Enabled = True
    End With
    MyFrmTAP01C.Show()
End Sub

  Private Sub FrmTAP01AFF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    MyTXDCAFF = New TXDCAFF.mydata(MyDBConnect)

    LoadScrn = True
    With MyFrmTAP01
      .TbForms.Visible = False
      .TBarAff.Enabled = False
    End With

    LblListNo.Text = WrkListNo
    LblYear.Text = WrkYear
    MyTXDCAFF.GetOneRecordP(WrkListNo, WrkYear)
    If MyTXDCAFF.RecordNotFound Then
      Me.Text = "Add " & Me.Text
      MyFrmTAP01.TBarDelete.Enabled = False
      Exit Sub
    End If

    'Fill the dataset with the data
     With MyTXDCAFF
        TxtOwname.Text = Trim(._OWNAME)
        TxtBuname.Text = Trim(._BUNAME)
        TxtLocNo.Text = Trim(._LOCNO)
        TxtLoc.Text = Trim(._LOC)
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
        Case "C"
          RbTranClosing.Checked = True
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
    MyTXDCAFF.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    MyTXDCAFF.GetOneRecordP(WrkListNo, WrkYear)
    If Not MyTXDCAFF.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXDCAFF.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXDCAFF.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    Me.Close()
  End Sub
   Private Sub MoveToFile()
      With MyTXDCAFF
        ._LISTNO = WrkListNo
        ._YEAR = WrkYear
        ._OWNAME = TxtOwname.Text
        ._BUNAME = TxtBuname.Text
        ._LOCNO = TxtLocNo.Text
        ._LOC = TxtLoc.Text
        ._NAME = TxtName.Text
        ._ADDR = TxtAddr.Text
        ._CITY = TxtCity.Text
        ._STATE = TxtState.Text
        ._ZIP5 = MyUtils.CnvSng(TxtZip5.Text)
        ._ZIP4 = MyUtils.CnvSng(TxtZip4.Text)
        ._TRANDT = MyUtils.SetDBDate(DtPckTran.Value)
        If RbTranSold.Checked Then ._TRANTY = "S"
        If RbTranMoved.Checked Then ._TRANTY = "M"
        If RbTranClosing.Checked Then ._TRANTY = "C"
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
  Private Sub FrmTAP01AFF_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "TAP01AFF"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
End Class






