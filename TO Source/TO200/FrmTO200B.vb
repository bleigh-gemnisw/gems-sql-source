Public Class FrmTO200B
  Inherits System.Windows.Forms.Form
	Dim MyTXOPM As TXOPM.myData
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpAssr As System.Windows.Forms.TabPage
  Friend WithEvents TxtAssrCert As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtAssrFax As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtAssrPhoneExt As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssrZip4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssrEmail As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtAssrPhone As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents TxtAssrZip As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssrCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssrAddr1 As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TpColl As System.Windows.Forms.TabPage
  Friend WithEvents TxtCollCert As System.Windows.Forms.TextBox
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents TxtCollFax As System.Windows.Forms.TextBox
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents TxtCollPhoneExt As System.Windows.Forms.TextBox
  Friend WithEvents TxtCollZip4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtCollEmail As System.Windows.Forms.TextBox
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents TxtCollPhone As System.Windows.Forms.TextBox
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents TxtCollZip As System.Windows.Forms.TextBox
  Friend WithEvents TxtCollCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtCollAddr1 As System.Windows.Forms.TextBox
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents TxtAssrState As System.Windows.Forms.TextBox
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents TxtCollState As System.Windows.Forms.TextBox
  Friend WithEvents Label24 As System.Windows.Forms.Label
  Dim ds As DataSet = New DataSet
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
    Friend WithEvents label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.label3 = New System.Windows.Forms.Label()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TpAssr = New System.Windows.Forms.TabPage()
    Me.TxtAssrState = New System.Windows.Forms.TextBox()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.TxtAssrCert = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtAssrFax = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtAssrPhoneExt = New System.Windows.Forms.TextBox()
    Me.TxtAssrZip4 = New System.Windows.Forms.TextBox()
    Me.TxtAssrEmail = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtAssrPhone = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtAssrZip = New System.Windows.Forms.TextBox()
    Me.TxtAssrCity = New System.Windows.Forms.TextBox()
    Me.TxtAssrAddr1 = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TpColl = New System.Windows.Forms.TabPage()
    Me.TxtCollState = New System.Windows.Forms.TextBox()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.TxtCollCert = New System.Windows.Forms.TextBox()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.TxtCollFax = New System.Windows.Forms.TextBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.TxtCollPhoneExt = New System.Windows.Forms.TextBox()
    Me.TxtCollZip4 = New System.Windows.Forms.TextBox()
    Me.TxtCollEmail = New System.Windows.Forms.TextBox()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.TxtCollPhone = New System.Windows.Forms.TextBox()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.TxtCollZip = New System.Windows.Forms.TextBox()
    Me.TxtCollCity = New System.Windows.Forms.TextBox()
    Me.TxtCollAddr1 = New System.Windows.Forms.TextBox()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.Label22 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TextBox3 = New System.Windows.Forms.TextBox()
    Me.TextBox4 = New System.Windows.Forms.TextBox()
    Me.TextBox5 = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TextBox6 = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TextBox7 = New System.Windows.Forms.TextBox()
    Me.TextBox8 = New System.Windows.Forms.TextBox()
    Me.TextBox9 = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.Label15 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TabControl1.SuspendLayout()
    Me.TpAssr.SuspendLayout()
    Me.TpColl.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'label3
    '
    Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label3.Location = New System.Drawing.Point(-100, 74)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(100, 23)
    Me.label3.TabIndex = 6
    Me.label3.Text = "New file name"
    Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.TpAssr)
    Me.TabControl1.Controls.Add(Me.TpColl)
    Me.TabControl1.Location = New System.Drawing.Point(12, 3)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(522, 206)
    Me.TabControl1.TabIndex = 1
    '
    'TpAssr
    '
    Me.TpAssr.Controls.Add(Me.TxtAssrState)
    Me.TpAssr.Controls.Add(Me.Label23)
    Me.TpAssr.Controls.Add(Me.TxtAssrCert)
    Me.TpAssr.Controls.Add(Me.Label4)
    Me.TpAssr.Controls.Add(Me.TxtAssrFax)
    Me.TpAssr.Controls.Add(Me.Label1)
    Me.TpAssr.Controls.Add(Me.TxtAssrPhoneExt)
    Me.TpAssr.Controls.Add(Me.TxtAssrZip4)
    Me.TpAssr.Controls.Add(Me.TxtAssrEmail)
    Me.TpAssr.Controls.Add(Me.Label8)
    Me.TpAssr.Controls.Add(Me.TxtAssrPhone)
    Me.TpAssr.Controls.Add(Me.Label7)
    Me.TpAssr.Controls.Add(Me.TxtAssrZip)
    Me.TpAssr.Controls.Add(Me.TxtAssrCity)
    Me.TpAssr.Controls.Add(Me.TxtAssrAddr1)
    Me.TpAssr.Controls.Add(Me.Label6)
    Me.TpAssr.Controls.Add(Me.Label5)
    Me.TpAssr.Controls.Add(Me.Label2)
    Me.TpAssr.Location = New System.Drawing.Point(4, 22)
    Me.TpAssr.Name = "TpAssr"
    Me.TpAssr.Padding = New System.Windows.Forms.Padding(3)
    Me.TpAssr.Size = New System.Drawing.Size(514, 180)
    Me.TpAssr.TabIndex = 0
    Me.TpAssr.Text = "Assessor"
    Me.TpAssr.UseVisualStyleBackColor = True
    '
    'TxtAssrState
    '
    Me.TxtAssrState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssrState.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtAssrState.Location = New System.Drawing.Point(348, 42)
    Me.TxtAssrState.MaxLength = 2
    Me.TxtAssrState.Name = "TxtAssrState"
    Me.TxtAssrState.Size = New System.Drawing.Size(22, 22)
    Me.TxtAssrState.TabIndex = 2
    '
    'Label23
    '
    Me.Label23.Location = New System.Drawing.Point(320, 46)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(22, 16)
    Me.Label23.TabIndex = 44
    Me.Label23.Text = "ST"
    '
    'TxtAssrCert
    '
    Me.TxtAssrCert.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssrCert.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtAssrCert.Location = New System.Drawing.Point(110, 147)
    Me.TxtAssrCert.MaxLength = 10
    Me.TxtAssrCert.Name = "TxtAssrCert"
    Me.TxtAssrCert.Size = New System.Drawing.Size(80, 22)
    Me.TxtAssrCert.TabIndex = 9
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(6, 151)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(100, 16)
    Me.Label4.TabIndex = 43
    Me.Label4.Text = "Certification No"
    '
    'TxtAssrFax
    '
    Me.TxtAssrFax.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssrFax.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtAssrFax.Location = New System.Drawing.Point(110, 89)
    Me.TxtAssrFax.MaxLength = 10
    Me.TxtAssrFax.Name = "TxtAssrFax"
    Me.TxtAssrFax.Size = New System.Drawing.Size(91, 22)
    Me.TxtAssrFax.TabIndex = 7
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(6, 93)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(100, 16)
    Me.Label1.TabIndex = 41
    Me.Label1.Text = "Fax"
    '
    'TxtAssrPhoneExt
    '
    Me.TxtAssrPhoneExt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssrPhoneExt.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtAssrPhoneExt.Location = New System.Drawing.Point(207, 64)
    Me.TxtAssrPhoneExt.MaxLength = 4
    Me.TxtAssrPhoneExt.Name = "TxtAssrPhoneExt"
    Me.TxtAssrPhoneExt.Size = New System.Drawing.Size(43, 22)
    Me.TxtAssrPhoneExt.TabIndex = 6
    '
    'TxtAssrZip4
    '
    Me.TxtAssrZip4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssrZip4.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtAssrZip4.Location = New System.Drawing.Point(466, 42)
    Me.TxtAssrZip4.MaxLength = 4
    Me.TxtAssrZip4.Name = "TxtAssrZip4"
    Me.TxtAssrZip4.Size = New System.Drawing.Size(38, 22)
    Me.TxtAssrZip4.TabIndex = 4
    '
    'TxtAssrEmail
    '
    Me.TxtAssrEmail.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssrEmail.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtAssrEmail.Location = New System.Drawing.Point(110, 117)
    Me.TxtAssrEmail.MaxLength = 40
    Me.TxtAssrEmail.Name = "TxtAssrEmail"
    Me.TxtAssrEmail.Size = New System.Drawing.Size(364, 22)
    Me.TxtAssrEmail.TabIndex = 8
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(6, 121)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(100, 16)
    Me.Label8.TabIndex = 37
    Me.Label8.Text = "Email Address"
    '
    'TxtAssrPhone
    '
    Me.TxtAssrPhone.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssrPhone.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtAssrPhone.Location = New System.Drawing.Point(110, 64)
    Me.TxtAssrPhone.MaxLength = 10
    Me.TxtAssrPhone.Name = "TxtAssrPhone"
    Me.TxtAssrPhone.Size = New System.Drawing.Size(91, 22)
    Me.TxtAssrPhone.TabIndex = 5
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(6, 68)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(100, 16)
    Me.Label7.TabIndex = 35
    Me.Label7.Text = "Phone"
    '
    'TxtAssrZip
    '
    Me.TxtAssrZip.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssrZip.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtAssrZip.Location = New System.Drawing.Point(415, 42)
    Me.TxtAssrZip.MaxLength = 5
    Me.TxtAssrZip.Name = "TxtAssrZip"
    Me.TxtAssrZip.Size = New System.Drawing.Size(48, 22)
    Me.TxtAssrZip.TabIndex = 3
    '
    'TxtAssrCity
    '
    Me.TxtAssrCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssrCity.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtAssrCity.Location = New System.Drawing.Point(110, 40)
    Me.TxtAssrCity.MaxLength = 25
    Me.TxtAssrCity.Name = "TxtAssrCity"
    Me.TxtAssrCity.Size = New System.Drawing.Size(204, 22)
    Me.TxtAssrCity.TabIndex = 1
    '
    'TxtAssrAddr1
    '
    Me.TxtAssrAddr1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssrAddr1.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtAssrAddr1.Location = New System.Drawing.Point(110, 12)
    Me.TxtAssrAddr1.MaxLength = 30
    Me.TxtAssrAddr1.Name = "TxtAssrAddr1"
    Me.TxtAssrAddr1.Size = New System.Drawing.Size(248, 22)
    Me.TxtAssrAddr1.TabIndex = 0
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(387, 48)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(22, 16)
    Me.Label6.TabIndex = 32
    Me.Label6.Text = "Zip"
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(6, 44)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(100, 16)
    Me.Label5.TabIndex = 31
    Me.Label5.Text = "City"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(6, 17)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(100, 16)
    Me.Label2.TabIndex = 29
    Me.Label2.Text = "Address"
    '
    'TpColl
    '
    Me.TpColl.Controls.Add(Me.TxtCollState)
    Me.TpColl.Controls.Add(Me.Label24)
    Me.TpColl.Controls.Add(Me.TxtCollCert)
    Me.TpColl.Controls.Add(Me.Label16)
    Me.TpColl.Controls.Add(Me.TxtCollFax)
    Me.TpColl.Controls.Add(Me.Label17)
    Me.TpColl.Controls.Add(Me.TxtCollPhoneExt)
    Me.TpColl.Controls.Add(Me.TxtCollZip4)
    Me.TpColl.Controls.Add(Me.TxtCollEmail)
    Me.TpColl.Controls.Add(Me.Label18)
    Me.TpColl.Controls.Add(Me.TxtCollPhone)
    Me.TpColl.Controls.Add(Me.Label19)
    Me.TpColl.Controls.Add(Me.TxtCollZip)
    Me.TpColl.Controls.Add(Me.TxtCollCity)
    Me.TpColl.Controls.Add(Me.TxtCollAddr1)
    Me.TpColl.Controls.Add(Me.Label20)
    Me.TpColl.Controls.Add(Me.Label21)
    Me.TpColl.Controls.Add(Me.Label22)
    Me.TpColl.Location = New System.Drawing.Point(4, 22)
    Me.TpColl.Name = "TpColl"
    Me.TpColl.Padding = New System.Windows.Forms.Padding(3)
    Me.TpColl.Size = New System.Drawing.Size(514, 180)
    Me.TpColl.TabIndex = 1
    Me.TpColl.Text = "Collector"
    Me.TpColl.UseVisualStyleBackColor = True
    '
    'TxtCollState
    '
    Me.TxtCollState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCollState.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtCollState.Location = New System.Drawing.Point(352, 42)
    Me.TxtCollState.MaxLength = 2
    Me.TxtCollState.Name = "TxtCollState"
    Me.TxtCollState.Size = New System.Drawing.Size(22, 22)
    Me.TxtCollState.TabIndex = 2
    '
    'Label24
    '
    Me.Label24.Location = New System.Drawing.Point(324, 46)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(22, 16)
    Me.Label24.TabIndex = 60
    Me.Label24.Text = "ST"
    '
    'TxtCollCert
    '
    Me.TxtCollCert.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCollCert.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtCollCert.Location = New System.Drawing.Point(110, 147)
    Me.TxtCollCert.MaxLength = 10
    Me.TxtCollCert.Name = "TxtCollCert"
    Me.TxtCollCert.Size = New System.Drawing.Size(80, 22)
    Me.TxtCollCert.TabIndex = 9
    '
    'Label16
    '
    Me.Label16.Location = New System.Drawing.Point(6, 151)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(100, 16)
    Me.Label16.TabIndex = 59
    Me.Label16.Text = "Certification No"
    '
    'TxtCollFax
    '
    Me.TxtCollFax.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCollFax.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtCollFax.Location = New System.Drawing.Point(110, 89)
    Me.TxtCollFax.MaxLength = 10
    Me.TxtCollFax.Name = "TxtCollFax"
    Me.TxtCollFax.Size = New System.Drawing.Size(89, 22)
    Me.TxtCollFax.TabIndex = 7
    '
    'Label17
    '
    Me.Label17.Location = New System.Drawing.Point(6, 93)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(100, 16)
    Me.Label17.TabIndex = 57
    Me.Label17.Text = "Fax"
    '
    'TxtCollPhoneExt
    '
    Me.TxtCollPhoneExt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCollPhoneExt.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtCollPhoneExt.Location = New System.Drawing.Point(205, 64)
    Me.TxtCollPhoneExt.MaxLength = 4
    Me.TxtCollPhoneExt.Name = "TxtCollPhoneExt"
    Me.TxtCollPhoneExt.Size = New System.Drawing.Size(43, 22)
    Me.TxtCollPhoneExt.TabIndex = 6
    '
    'TxtCollZip4
    '
    Me.TxtCollZip4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCollZip4.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtCollZip4.Location = New System.Drawing.Point(468, 42)
    Me.TxtCollZip4.MaxLength = 4
    Me.TxtCollZip4.Name = "TxtCollZip4"
    Me.TxtCollZip4.Size = New System.Drawing.Size(38, 22)
    Me.TxtCollZip4.TabIndex = 4
    '
    'TxtCollEmail
    '
    Me.TxtCollEmail.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCollEmail.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtCollEmail.Location = New System.Drawing.Point(110, 117)
    Me.TxtCollEmail.MaxLength = 40
    Me.TxtCollEmail.Name = "TxtCollEmail"
    Me.TxtCollEmail.Size = New System.Drawing.Size(364, 22)
    Me.TxtCollEmail.TabIndex = 8
    '
    'Label18
    '
    Me.Label18.Location = New System.Drawing.Point(6, 121)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(100, 16)
    Me.Label18.TabIndex = 53
    Me.Label18.Text = "Email Address"
    '
    'TxtCollPhone
    '
    Me.TxtCollPhone.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCollPhone.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtCollPhone.Location = New System.Drawing.Point(110, 64)
    Me.TxtCollPhone.MaxLength = 10
    Me.TxtCollPhone.Name = "TxtCollPhone"
    Me.TxtCollPhone.Size = New System.Drawing.Size(89, 22)
    Me.TxtCollPhone.TabIndex = 5
    '
    'Label19
    '
    Me.Label19.Location = New System.Drawing.Point(6, 68)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(100, 16)
    Me.Label19.TabIndex = 51
    Me.Label19.Text = "Phone"
    '
    'TxtCollZip
    '
    Me.TxtCollZip.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCollZip.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtCollZip.Location = New System.Drawing.Point(414, 42)
    Me.TxtCollZip.MaxLength = 5
    Me.TxtCollZip.Name = "TxtCollZip"
    Me.TxtCollZip.Size = New System.Drawing.Size(48, 22)
    Me.TxtCollZip.TabIndex = 3
    '
    'TxtCollCity
    '
    Me.TxtCollCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCollCity.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtCollCity.Location = New System.Drawing.Point(110, 40)
    Me.TxtCollCity.MaxLength = 25
    Me.TxtCollCity.Name = "TxtCollCity"
    Me.TxtCollCity.Size = New System.Drawing.Size(204, 22)
    Me.TxtCollCity.TabIndex = 1
    '
    'TxtCollAddr1
    '
    Me.TxtCollAddr1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCollAddr1.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TxtCollAddr1.Location = New System.Drawing.Point(110, 12)
    Me.TxtCollAddr1.MaxLength = 30
    Me.TxtCollAddr1.Name = "TxtCollAddr1"
    Me.TxtCollAddr1.Size = New System.Drawing.Size(248, 22)
    Me.TxtCollAddr1.TabIndex = 0
    '
    'Label20
    '
    Me.Label20.Location = New System.Drawing.Point(386, 48)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(22, 16)
    Me.Label20.TabIndex = 48
    Me.Label20.Text = "Zip"
    '
    'Label21
    '
    Me.Label21.Location = New System.Drawing.Point(6, 44)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(100, 16)
    Me.Label21.TabIndex = 47
    Me.Label21.Text = "City"
    '
    'Label22
    '
    Me.Label22.Location = New System.Drawing.Point(6, 17)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(100, 16)
    Me.Label22.TabIndex = 45
    Me.Label22.Text = "Address"
    '
    'TextBox1
    '
    Me.TextBox1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TextBox1.Location = New System.Drawing.Point(110, 147)
    Me.TextBox1.MaxLength = 9
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(80, 22)
    Me.TextBox1.TabIndex = 42
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(6, 151)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(100, 16)
    Me.Label9.TabIndex = 43
    Me.Label9.Text = "Certification No"
    '
    'TextBox2
    '
    Me.TextBox2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TextBox2.Location = New System.Drawing.Point(110, 89)
    Me.TextBox2.MaxLength = 9
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(80, 22)
    Me.TextBox2.TabIndex = 40
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(6, 93)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(100, 16)
    Me.Label10.TabIndex = 41
    Me.Label10.Text = "Fax"
    '
    'TextBox3
    '
    Me.TextBox3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TextBox3.Location = New System.Drawing.Point(196, 64)
    Me.TextBox3.MaxLength = 9
    Me.TextBox3.Name = "TextBox3"
    Me.TextBox3.Size = New System.Drawing.Size(37, 22)
    Me.TextBox3.TabIndex = 39
    '
    'TextBox4
    '
    Me.TextBox4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox4.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TextBox4.Location = New System.Drawing.Point(401, 40)
    Me.TextBox4.MaxLength = 5
    Me.TextBox4.Name = "TextBox4"
    Me.TextBox4.Size = New System.Drawing.Size(38, 22)
    Me.TextBox4.TabIndex = 38
    '
    'TextBox5
    '
    Me.TextBox5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox5.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TextBox5.Location = New System.Drawing.Point(110, 117)
    Me.TextBox5.MaxLength = 30
    Me.TextBox5.Name = "TextBox5"
    Me.TextBox5.Size = New System.Drawing.Size(248, 22)
    Me.TextBox5.TabIndex = 36
    '
    'Label11
    '
    Me.Label11.Location = New System.Drawing.Point(6, 121)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(100, 16)
    Me.Label11.TabIndex = 37
    Me.Label11.Text = "Email Address"
    '
    'TextBox6
    '
    Me.TextBox6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox6.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TextBox6.Location = New System.Drawing.Point(110, 64)
    Me.TextBox6.MaxLength = 9
    Me.TextBox6.Name = "TextBox6"
    Me.TextBox6.Size = New System.Drawing.Size(80, 22)
    Me.TextBox6.TabIndex = 34
    '
    'Label12
    '
    Me.Label12.Location = New System.Drawing.Point(6, 68)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(100, 16)
    Me.Label12.TabIndex = 35
    Me.Label12.Text = "Phone"
    '
    'TextBox7
    '
    Me.TextBox7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox7.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TextBox7.Location = New System.Drawing.Point(350, 40)
    Me.TextBox7.MaxLength = 5
    Me.TextBox7.Name = "TextBox7"
    Me.TextBox7.Size = New System.Drawing.Size(48, 22)
    Me.TextBox7.TabIndex = 33
    '
    'TextBox8
    '
    Me.TextBox8.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox8.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TextBox8.Location = New System.Drawing.Point(110, 40)
    Me.TextBox8.MaxLength = 25
    Me.TextBox8.Name = "TextBox8"
    Me.TextBox8.Size = New System.Drawing.Size(204, 22)
    Me.TextBox8.TabIndex = 30
    '
    'TextBox9
    '
    Me.TextBox9.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox9.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.TextBox9.Location = New System.Drawing.Point(110, 12)
    Me.TextBox9.MaxLength = 30
    Me.TextBox9.Name = "TextBox9"
    Me.TextBox9.Size = New System.Drawing.Size(248, 22)
    Me.TextBox9.TabIndex = 28
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(322, 44)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(22, 16)
    Me.Label13.TabIndex = 32
    Me.Label13.Text = "Zip"
    '
    'Label14
    '
    Me.Label14.Location = New System.Drawing.Point(6, 44)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(100, 16)
    Me.Label14.TabIndex = 31
    Me.Label14.Text = "City"
    '
    'Label15
    '
    Me.Label15.Location = New System.Drawing.Point(6, 17)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(100, 16)
    Me.Label15.TabIndex = 29
    Me.Label15.Text = "Address"
    '
    'FrmTO200B
    '
    Me.AllowDrop = True
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(545, 223)
    Me.ControlBox = False
    Me.Controls.Add(Me.TabControl1)
    Me.Controls.Add(Me.label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTO200B"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TabControl1.ResumeLayout(False)
    Me.TpAssr.ResumeLayout(False)
    Me.TpAssr.PerformLayout()
    Me.TpColl.ResumeLayout(False)
    Me.TpColl.PerformLayout()
    Me.ResumeLayout(False)

End Sub

#End Region

Private Sub TO200B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	MyTXOPM = New TXOPM.mydata(MyDBConnect)

  MyFrmTO200.TBarNew.Visible = False
  MyFrmTO200.TBarSave.Visible = True
  MyFrmTO200.TBarPrint.Visible = False
  MyFrmTO200.TBarDelete.Visible = False

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTO200.TBarSave.Visible = False
  End If

  MyTXOPM.GetOneRecordP("A")
  If Not MyTXOPM.RecordNotFound Then
    With MyTXOPM
      TxtAssrAddr1.Text = Trim(._ADDR1)
      TxtAssrCity.Text = Trim(._CITY)
      TxtAssrState.Text = Trim(._STATE)
      If ._ZIP > 0 Then
        TxtAssrZip.Text = Format(._ZIP, "00000")
      End If
      If ._ZIP4 > 0 Then
        TxtAssrZip4.Text = Format(._ZIP4, "0000")
      End If
      If ._PHONE > 0 Then
        TxtAssrPhone.Text = ._PHONE
      End If
      If ._PHONEX > 0 Then
        TxtAssrPhoneExt.Text = ._PHONEX
      End If
      If ._FAX > 0 Then
        TxtAssrFax.Text = ._FAX
      End If
      TxtAssrEmail.Text = Trim(._EMAIL)
      TxtAssrCert.Text = Trim(._CERT)
    End With
  End If

  MyTXOPM.GetOneRecordP("C")
  If Not MyTXOPM.RecordNotFound Then
    With MyTXOPM
      TxtCollAddr1.Text = Trim(._ADDR1)
      TxtCollCity.Text = Trim(._CITY)
      TxtCollState.Text = Trim(._STATE)
      If ._ZIP > 0 Then
        TxtCollZip.Text = Format(._ZIP, "00000")
      End If
      If ._ZIP4 > 0 Then
        TxtCollZip4.Text = Format(._ZIP4, "0000")
      End If
      If ._PHONE > 0 Then
        TxtCollPhone.Text = ._PHONE
      End If
      If ._PHONEX > 0 Then
        TxtCollPhoneExt.Text = ._PHONEX
      End If
      If ._FAX > 0 Then
        TxtCollFax.Text = ._FAX
      End If
      TxtCollEmail.Text = Trim(._EMAIL)
      TxtCollCert.Text = Trim(._CERT)
    End With
  End If
End Sub
Private Sub TO200B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTO200.SbpScreen.Text = "TO200B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String

  MyTXOPM.GetOneRecordP("A")
  MovetoFileAssr()
  If MyTXOPM.RecordNotFound Then
    MyTXOPM.AddOneRecordP()
  Else
    MyTXOPM.UpdateOneRecordP()
  End If

  MyTXOPM.GetOneRecordP("C")
  MovetoFilecoll()
  If MyTXOPM.RecordNotFound Then
    MyTXOPM.AddOneRecordP()
  Else
    MyTXOPM.UpdateOneRecordP()
  End If
  End Sub
Private Sub MovetoFileAssr()
  With MyTXOPM
    ._RECTYP = "A"
    ._ADDR1 = TxtAssrAddr1.Text
    ._CITY = TxtAssrCity.Text
    ._STATE = TxtAssrState.Text
    ._ZIP = MyUtils.CnvSng(TxtAssrZip.Text)
    ._ZIP4 = MyUtils.CnvSng(TxtAssrZip4.Text)
    ._PHONE = MyUtils.CnvSng(TxtAssrPhone.Text)
    ._PHONEX = MyUtils.CnvSng(TxtAssrPhoneExt.Text)
    ._FAX = MyUtils.CnvSng(TxtAssrFax.Text)
    ._EMAIL = TxtAssrEmail.Text
    ._CERT = TxtAssrCert.Text
  End With
End Sub
Private Sub MovetoFileColl()
  With MyTXOPM
    ._RECTYP = "C"
    ._ADDR1 = TxtCollAddr1.Text
    ._CITY = TxtCollCity.Text
    ._STATE = TxtCollState.Text
    ._ZIP = MyUtils.CnvSng(TxtCollZip.Text)
    ._ZIP4 = MyUtils.CnvSng(TxtCollZip4.Text)
    ._PHONE = MyUtils.CnvSng(TxtCollPhone.Text)
    ._PHONEX = MyUtils.CnvSng(TxtCollPhoneExt.Text)
    ._FAX = MyUtils.CnvSng(TxtCollFax.Text)
    ._EMAIL = TxtCollEmail.Text
    ._CERT = TxtCollCert.Text
  End With
End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  For I = 0 To ErrorField.GetUpperBound(0)
     Select Case ErrorField(I)
       Case Nothing
         Exit Sub
     End Select
     Next I
End Sub

Private Sub TpAssr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpAssr.Click

End Sub
End Class






