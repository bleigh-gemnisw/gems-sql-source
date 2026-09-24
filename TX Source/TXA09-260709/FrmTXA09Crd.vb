Public Class FrmTXA09Crd
	Inherits System.Windows.Forms.Form
	Dim myTXINV As TXINV.myData
  Dim myTXCOEA As TXCOEA.myData
  Dim WrkCredit As Boolean
	Friend WrkListNo As Integer
	Friend WrkYear As Integer
	Friend WrkType As String
	Friend WithEvents LblName As System.Windows.Forms.Label
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents LblType As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents LblYear As System.Windows.Forms.Label
	Friend WithEvents LblList As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
 Friend WithEvents LblCRProperty2 As System.Windows.Forms.Label
 Friend WithEvents LblCRProperty As System.Windows.Forms.Label
 Friend WithEvents LblCrHead As System.Windows.Forms.Label
 Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
 Friend WithEvents Label4 As System.Windows.Forms.Label
 Friend WithEvents Label1 As System.Windows.Forms.Label
 Friend WithEvents Label6 As System.Windows.Forms.Label
 Friend WithEvents Label2 As System.Windows.Forms.Label
 Friend WithEvents LblNet As System.Windows.Forms.Label
 Friend WithEvents LblExempt As System.Windows.Forms.Label
 Friend WithEvents LblGross As System.Windows.Forms.Label
 Friend WithEvents LblCrGross As System.Windows.Forms.Label
 Friend WithEvents LblProGross As System.Windows.Forms.Label
 Friend WithEvents LblProCredit As System.Windows.Forms.Label
 Friend WithEvents LblCRPct As System.Windows.Forms.Label
 Friend WithEvents LblPct As System.Windows.Forms.Label
 Friend WithEvents LblCrAss As System.Windows.Forms.Label
 Friend WithEvents LblAss As System.Windows.Forms.Label
 Friend WithEvents LblProperty2 As System.Windows.Forms.Label
 Friend WithEvents LblProperty As System.Windows.Forms.Label
 Friend WithEvents label37 As System.Windows.Forms.Label
 Friend WithEvents LblMonth As System.Windows.Forms.Label
 Friend WithEvents LblCRMonth As System.Windows.Forms.Label
 Friend WithEvents LblSaleMonth As System.Windows.Forms.Label
 Friend WithEvents LblProSale As System.Windows.Forms.Label
 Friend WithEvents LblSalePct As System.Windows.Forms.Label
 Friend WithEvents LblSaleAss As System.Windows.Forms.Label
 Friend WithEvents LblSaleGross As System.Windows.Forms.Label
 Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label


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
    Me.LblName = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.LblType = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.LblList = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.LblCRProperty2 = New System.Windows.Forms.Label()
    Me.LblCRProperty = New System.Windows.Forms.Label()
    Me.LblCrHead = New System.Windows.Forms.Label()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.LblCRMonth = New System.Windows.Forms.Label()
    Me.LblMonth = New System.Windows.Forms.Label()
    Me.LblProGross = New System.Windows.Forms.Label()
    Me.LblProCredit = New System.Windows.Forms.Label()
    Me.LblCRPct = New System.Windows.Forms.Label()
    Me.LblPct = New System.Windows.Forms.Label()
    Me.LblCrAss = New System.Windows.Forms.Label()
    Me.LblAss = New System.Windows.Forms.Label()
    Me.LblNet = New System.Windows.Forms.Label()
    Me.LblExempt = New System.Windows.Forms.Label()
    Me.LblGross = New System.Windows.Forms.Label()
    Me.LblCrGross = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.LblProperty2 = New System.Windows.Forms.Label()
    Me.LblProperty = New System.Windows.Forms.Label()
    Me.label37 = New System.Windows.Forms.Label()
    Me.LblSaleMonth = New System.Windows.Forms.Label()
    Me.LblProSale = New System.Windows.Forms.Label()
    Me.LblSalePct = New System.Windows.Forms.Label()
    Me.LblSaleAss = New System.Windows.Forms.Label()
    Me.LblSaleGross = New System.Windows.Forms.Label()
    Me.Label14 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox3.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblName
    '
    Me.LblName.BackColor = System.Drawing.SystemColors.Control
    Me.LblName.Location = New System.Drawing.Point(104, 23)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(216, 16)
    Me.LblName.TabIndex = 170
    '
    'Label7
    '
    Me.Label7.BackColor = System.Drawing.SystemColors.Control
    Me.Label7.Location = New System.Drawing.Point(120, 3)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(32, 13)
    Me.Label7.TabIndex = 169
    Me.Label7.Text = "Type"
    '
    'LblType
    '
    Me.LblType.BackColor = System.Drawing.SystemColors.Control
    Me.LblType.Location = New System.Drawing.Point(156, 3)
    Me.LblType.Name = "LblType"
    Me.LblType.Size = New System.Drawing.Size(16, 16)
    Me.LblType.TabIndex = 168
    '
    'Label3
    '
    Me.Label3.BackColor = System.Drawing.SystemColors.Control
    Me.Label3.Location = New System.Drawing.Point(180, 3)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(32, 12)
    Me.Label3.TabIndex = 167
    Me.Label3.Text = "Year"
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.SystemColors.Control
    Me.LblYear.Location = New System.Drawing.Point(212, 3)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(48, 16)
    Me.LblYear.TabIndex = 166
    '
    'LblList
    '
    Me.LblList.BackColor = System.Drawing.SystemColors.Control
    Me.LblList.Location = New System.Drawing.Point(57, 3)
    Me.LblList.Name = "LblList"
    Me.LblList.Size = New System.Drawing.Size(48, 16)
    Me.LblList.TabIndex = 165
    '
    'Label5
    '
    Me.Label5.BackColor = System.Drawing.SystemColors.Control
    Me.Label5.Location = New System.Drawing.Point(12, 23)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(84, 12)
    Me.Label5.TabIndex = 164
    Me.Label5.Text = "Name of Owner"
    '
    'Label8
    '
    Me.Label8.BackColor = System.Drawing.SystemColors.Control
    Me.Label8.Location = New System.Drawing.Point(12, 3)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(36, 12)
    Me.Label8.TabIndex = 163
    Me.Label8.Text = "List #"
    '
    'LblCRProperty2
    '
    Me.LblCRProperty2.BackColor = System.Drawing.SystemColors.Control
    Me.LblCRProperty2.Location = New System.Drawing.Point(68, 118)
    Me.LblCRProperty2.Name = "LblCRProperty2"
    Me.LblCRProperty2.Size = New System.Drawing.Size(232, 16)
    Me.LblCRProperty2.TabIndex = 173
    '
    'LblCRProperty
    '
    Me.LblCRProperty.BackColor = System.Drawing.SystemColors.Control
    Me.LblCRProperty.Location = New System.Drawing.Point(68, 102)
    Me.LblCRProperty.Name = "LblCRProperty"
    Me.LblCRProperty.Size = New System.Drawing.Size(256, 16)
    Me.LblCRProperty.TabIndex = 172
    '
    'LblCrHead
    '
    Me.LblCrHead.BackColor = System.Drawing.SystemColors.Control
    Me.LblCrHead.Location = New System.Drawing.Point(12, 102)
    Me.LblCrHead.Name = "LblCrHead"
    Me.LblCrHead.Size = New System.Drawing.Size(50, 16)
    Me.LblCrHead.TabIndex = 171
    Me.LblCrHead.Text = "Credit"
    '
    'GroupBox3
    '
    Me.GroupBox3.BackColor = System.Drawing.SystemColors.Control
    Me.GroupBox3.Controls.Add(Me.LblSaleMonth)
    Me.GroupBox3.Controls.Add(Me.LblProSale)
    Me.GroupBox3.Controls.Add(Me.LblSalePct)
    Me.GroupBox3.Controls.Add(Me.LblSaleAss)
    Me.GroupBox3.Controls.Add(Me.LblSaleGross)
    Me.GroupBox3.Controls.Add(Me.Label14)
    Me.GroupBox3.Controls.Add(Me.LblCRMonth)
    Me.GroupBox3.Controls.Add(Me.LblMonth)
    Me.GroupBox3.Controls.Add(Me.LblProGross)
    Me.GroupBox3.Controls.Add(Me.LblProCredit)
    Me.GroupBox3.Controls.Add(Me.LblCRPct)
    Me.GroupBox3.Controls.Add(Me.LblPct)
    Me.GroupBox3.Controls.Add(Me.LblCrAss)
    Me.GroupBox3.Controls.Add(Me.LblAss)
    Me.GroupBox3.Controls.Add(Me.LblNet)
    Me.GroupBox3.Controls.Add(Me.LblExempt)
    Me.GroupBox3.Controls.Add(Me.LblGross)
    Me.GroupBox3.Controls.Add(Me.LblCrGross)
    Me.GroupBox3.Controls.Add(Me.Label2)
    Me.GroupBox3.Controls.Add(Me.Label4)
    Me.GroupBox3.Controls.Add(Me.Label1)
    Me.GroupBox3.Controls.Add(Me.Label6)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(26, 141)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(317, 133)
    Me.GroupBox3.TabIndex = 174
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Property Values"
    '
    'LblCRMonth
    '
    Me.LblCRMonth.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCRMonth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblCRMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCRMonth.Location = New System.Drawing.Point(158, 59)
    Me.LblCRMonth.Name = "LblCRMonth"
    Me.LblCRMonth.Size = New System.Drawing.Size(35, 20)
    Me.LblCRMonth.TabIndex = 176
    Me.LblCRMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LblMonth
    '
    Me.LblMonth.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblMonth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMonth.Location = New System.Drawing.Point(158, 19)
    Me.LblMonth.Name = "LblMonth"
    Me.LblMonth.Size = New System.Drawing.Size(35, 20)
    Me.LblMonth.TabIndex = 175
    Me.LblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LblProGross
    '
    Me.LblProGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblProGross.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblProGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblProGross.Location = New System.Drawing.Point(238, 19)
    Me.LblProGross.Name = "LblProGross"
    Me.LblProGross.Size = New System.Drawing.Size(72, 20)
    Me.LblProGross.TabIndex = 173
    Me.LblProGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblProCredit
    '
    Me.LblProCredit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblProCredit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblProCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblProCredit.Location = New System.Drawing.Point(238, 59)
    Me.LblProCredit.Name = "LblProCredit"
    Me.LblProCredit.Size = New System.Drawing.Size(72, 20)
    Me.LblProCredit.TabIndex = 174
    Me.LblProCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCRPct
    '
    Me.LblCRPct.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCRPct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblCRPct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCRPct.Location = New System.Drawing.Point(199, 59)
    Me.LblCRPct.Name = "LblCRPct"
    Me.LblCRPct.Size = New System.Drawing.Size(35, 20)
    Me.LblCRPct.TabIndex = 172
    Me.LblCRPct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblPct
    '
    Me.LblPct.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblPct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPct.Location = New System.Drawing.Point(199, 19)
    Me.LblPct.Name = "LblPct"
    Me.LblPct.Size = New System.Drawing.Size(35, 20)
    Me.LblPct.TabIndex = 171
    Me.LblPct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCrAss
    '
    Me.LblCrAss.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCrAss.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblCrAss.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCrAss.Location = New System.Drawing.Point(140, 59)
    Me.LblCrAss.Name = "LblCrAss"
    Me.LblCrAss.Size = New System.Drawing.Size(15, 20)
    Me.LblCrAss.TabIndex = 170
    Me.LblCrAss.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblAss
    '
    Me.LblAss.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAss.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblAss.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAss.Location = New System.Drawing.Point(140, 19)
    Me.LblAss.Name = "LblAss"
    Me.LblAss.Size = New System.Drawing.Size(15, 20)
    Me.LblAss.TabIndex = 169
    Me.LblAss.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblNet
    '
    Me.LblNet.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblNet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNet.Location = New System.Drawing.Point(238, 103)
    Me.LblNet.Name = "LblNet"
    Me.LblNet.Size = New System.Drawing.Size(72, 20)
    Me.LblNet.TabIndex = 168
    Me.LblNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExempt
    '
    Me.LblExempt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExempt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExempt.Location = New System.Drawing.Point(238, 83)
    Me.LblExempt.Name = "LblExempt"
    Me.LblExempt.Size = New System.Drawing.Size(72, 20)
    Me.LblExempt.TabIndex = 167
    Me.LblExempt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblGross
    '
    Me.LblGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblGross.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblGross.Location = New System.Drawing.Point(62, 19)
    Me.LblGross.Name = "LblGross"
    Me.LblGross.Size = New System.Drawing.Size(72, 20)
    Me.LblGross.TabIndex = 165
    Me.LblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCrGross
    '
    Me.LblCrGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCrGross.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblCrGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCrGross.Location = New System.Drawing.Point(62, 59)
    Me.LblCrGross.Name = "LblCrGross"
    Me.LblCrGross.Size = New System.Drawing.Size(72, 20)
    Me.LblCrGross.TabIndex = 166
    Me.LblCrGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label2
    '
    Me.Label2.BackColor = System.Drawing.SystemColors.Control
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(8, 63)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(48, 16)
    Me.Label2.TabIndex = 132
    Me.Label2.Text = "Credit"
    '
    'Label4
    '
    Me.Label4.BackColor = System.Drawing.SystemColors.Control
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(186, 107)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(48, 16)
    Me.Label4.TabIndex = 5
    Me.Label4.Text = "Net"
    '
    'Label1
    '
    Me.Label1.BackColor = System.Drawing.SystemColors.Control
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(184, 87)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(48, 16)
    Me.Label1.TabIndex = 3
    Me.Label1.Text = "Exempt"
    '
    'Label6
    '
    Me.Label6.BackColor = System.Drawing.SystemColors.Control
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(8, 23)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(48, 16)
    Me.Label6.TabIndex = 0
    Me.Label6.Text = "Gross"
    '
    'LblProperty2
    '
    Me.LblProperty2.BackColor = System.Drawing.SystemColors.Control
    Me.LblProperty2.Location = New System.Drawing.Point(66, 79)
    Me.LblProperty2.Name = "LblProperty2"
    Me.LblProperty2.Size = New System.Drawing.Size(232, 16)
    Me.LblProperty2.TabIndex = 177
    '
    'LblProperty
    '
    Me.LblProperty.BackColor = System.Drawing.SystemColors.Control
    Me.LblProperty.Location = New System.Drawing.Point(68, 63)
    Me.LblProperty.Name = "LblProperty"
    Me.LblProperty.Size = New System.Drawing.Size(256, 16)
    Me.LblProperty.TabIndex = 176
    '
    'label37
    '
    Me.label37.BackColor = System.Drawing.SystemColors.Control
    Me.label37.Location = New System.Drawing.Point(12, 63)
    Me.label37.Name = "label37"
    Me.label37.Size = New System.Drawing.Size(64, 16)
    Me.label37.TabIndex = 175
    Me.label37.Text = "Suppl MV"
    '
    'LblSaleMonth
    '
    Me.LblSaleMonth.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblSaleMonth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblSaleMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblSaleMonth.Location = New System.Drawing.Point(158, 39)
    Me.LblSaleMonth.Name = "LblSaleMonth"
    Me.LblSaleMonth.Size = New System.Drawing.Size(35, 20)
    Me.LblSaleMonth.TabIndex = 182
    Me.LblSaleMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LblProSale
    '
    Me.LblProSale.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblProSale.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblProSale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblProSale.Location = New System.Drawing.Point(238, 39)
    Me.LblProSale.Name = "LblProSale"
    Me.LblProSale.Size = New System.Drawing.Size(72, 20)
    Me.LblProSale.TabIndex = 181
    Me.LblProSale.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblSalePct
    '
    Me.LblSalePct.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblSalePct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblSalePct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblSalePct.Location = New System.Drawing.Point(199, 39)
    Me.LblSalePct.Name = "LblSalePct"
    Me.LblSalePct.Size = New System.Drawing.Size(35, 20)
    Me.LblSalePct.TabIndex = 180
    Me.LblSalePct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblSaleAss
    '
    Me.LblSaleAss.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblSaleAss.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblSaleAss.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblSaleAss.Location = New System.Drawing.Point(140, 39)
    Me.LblSaleAss.Name = "LblSaleAss"
    Me.LblSaleAss.Size = New System.Drawing.Size(15, 20)
    Me.LblSaleAss.TabIndex = 179
    Me.LblSaleAss.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblSaleGross
    '
    Me.LblSaleGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblSaleGross.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblSaleGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblSaleGross.Location = New System.Drawing.Point(62, 39)
    Me.LblSaleGross.Name = "LblSaleGross"
    Me.LblSaleGross.Size = New System.Drawing.Size(72, 20)
    Me.LblSaleGross.TabIndex = 178
    Me.LblSaleGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label14
    '
    Me.Label14.BackColor = System.Drawing.SystemColors.Control
    Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label14.Location = New System.Drawing.Point(8, 43)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(48, 16)
    Me.Label14.TabIndex = 177
    Me.Label14.Text = "Sale"
    '
    'FrmTXA09Crd
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(368, 286)
    Me.Controls.Add(Me.LblProperty2)
    Me.Controls.Add(Me.LblProperty)
    Me.Controls.Add(Me.label37)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.LblCRProperty2)
    Me.Controls.Add(Me.LblCRProperty)
    Me.Controls.Add(Me.LblCrHead)
    Me.Controls.Add(Me.LblName)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.LblType)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.LblList)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label8)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA09Crd"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Vehicle Prorated Net Calculation"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox3.ResumeLayout(False)
    Me.ResumeLayout(False)

End Sub

#End Region

  Private Sub FrmTXA09Crd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkTxSupCd As String()
    Dim WrkTXMVPCT As String()
    Dim WrkGross As Decimal
    Dim WrkCreditGross As Decimal
    Dim WrkSaleGross As Decimal
    Dim WrkExam As Decimal
    Dim WrkNet As Decimal
    myTXINV = New TXINV.mydata(MyDBConnect)
    myTXCOEA = New TXCOEA.mydata(MyDBConnect)

    LblList.Text = WrkListNo
    LblYear.Text = WrkYear
    LblType.Text = WrkType
    LblName.Text = MyFrmTXA09B.LblName.Text
    LblProperty.Text = MyFrmTXA09B.LblProperty.Text
    LblProperty2.Text = MyFrmTXA09B.LblProperty2.Text

    myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
    With myTXINV
      If ._CCNO = 0 Then
        WrkGross = ._GROSS
        WrkSaleGross = 0
        WrkCreditGross = ._ICVGRS
        WrkExam = ._EXAM1 + ._EXAM2 + +._EXAM3 + +._EXAM4 + ._EXAM5 + ._EXAM6 + ._EXAM7
        WrkNet = ._NETASS
        LblAss.Text = ._ASS
        LblSaleAss.Text = ""
        LblSalePct.Text = ""
        LblSaleMonth.Text = ""
        LblCrAss.Text = ._ICVACD
      Else
        myTXCOEA.GetOneRecordP(._CCNO)
        WrkGross = ._CGRS
        WrkCreditGross = myTXCOEA._NEWMVC
        WrkExam = ._CEXA1 + ._CEXA2 + +._CEXA3 + +._CEXA4 + ._CEXA5 + ._CEXA6 + ._CEXA7
        WrkNet = myTXCOEA._CNETAS
        LblAss.Text = myTXCOEA._C1MPCD
        If Trim(myTXCOEA._C1MSCD) <> "" Then
          WrkSaleGross = myTXCOEA._CGRS
          LblSaleAss.Text = myTXCOEA._C1MSCD
          WrkTXMVPCT = GetTXMVPCT("S", LblSaleAss.Text)
          LblSalePct.Text = WrkTXMVPCT(0)
          WrkTxSupCd = GetTXSupCd(LblSaleAss.Text)
          LblSaleMonth.Text = WrkTxSupCd(1)
          LblProSale.Text = Format(WrkSaleGross * MyUtils.CnvSng(LblSalePct.Text), "###,###,###")
        End If
        LblCrAss.Text = myTXCOEA._C1CSCD
      End If
      LblGross.Text = Format(WrkGross, "###,###,###")
      LblSaleGross.Text = Format(WrkSaleGross, "###,###,###")
      LblCrGross.Text = Format(WrkCreditGross, "###,###,###")
      LblExempt.Text = Format(WrkExam, "###,###,###")
      If Trim(._ASS) <> "" Then
        WrkTxSupCd = GetTXSupCd(._ASS)
      Else
        WrkTxSupCd = GetTXSupCd(LblAss.Text)
      End If
      LblPct.Text = WrkTxSupCd(0)
      LblMonth.Text = WrkTxSupCd(1)
      LblProGross.Text = Format(WrkGross * MyUtils.CnvSng(LblPct.Text), "###,###,###")
      If WrkTxSupCd(2) = "Y" Then
        WrkCredit = True
      Else
        WrkCredit = False
        LblCrHead.Visible = False
      End If
      LblNet.Text = Format(WrkNet, "###,###,###")
      If Not WrkCredit Then Exit Sub

      If ._CCNO = 0 Or Trim(myTXCOEA._C1CSCD) <> "" Then
        WrkTxSupCd = GetTXSupCd(LblCrAss.Text)
        LblCRPct.Text = WrkTxSupCd(0)
        LblCRMonth.Text = WrkTxSupCd(1)
        LblProCredit.Text = Format(WrkCreditGross * MyUtils.CnvSng(LblCRPct.Text), "###,###,###")
      End If
      If MyPublicUser Then
        LblCRProperty.Text = String.Empty
      Else
        LblCRProperty.Text = Trim(._ICVREG) & " - " & ._ICVIDNo
      End If
        LblCRProperty2.Text = Trim(._ICVMKE) & " - " & Trim(._ICVMOD) & _
         " - " & ._ICVYR & " - " & Format(._ICVCLS, "00")
    End With
 End Sub
	Private Sub FrmTXA09Crd_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		myTXINV.CloseFile()
		MyFrmTXA09B.Show()

	End Sub
	Private Sub FrmTXA09Crd_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
		MyFrmTXA09.SbpScreen.Text = "TXA09Crd"
    MyUtils.CenterForm(Me.ParentForm, Me)
	End Sub
	 Public Function CalcProRate(ByVal Gross As Single, ByVal Pct As Single) As Single
		CalcProRate = Gross * Pct
		Return CalcProRate
	End Function
End Class






