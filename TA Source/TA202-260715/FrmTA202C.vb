Public Class FrmTA202C
  Inherits System.Windows.Forms.Form
	Dim myTXREALC As TXREALC.myData
	Dim myTXREAL As TXReal.myData
	Dim myTXLOCFRZ As TXLOCFRZ.myData
	Dim myTXHOME As TXHOME.myData
	Friend WrkListNo As Integer
  Dim AddMode As Boolean
  Dim LoadScrn As Boolean
  'Adjusted Gross Ommited Codes 
  Dim cExcludeCode1 As Integer
  Dim cExcludeCode2 As Integer
  Dim cExcludeCode3 As Integer
  Dim cExcludeCode4 As Integer
  Dim WrkMillRate As Decimal

  Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtLocRef As System.Windows.Forms.TextBox
  Friend WithEvents TxtLocPerc As System.Windows.Forms.TextBox
  Friend WithEvents Label72 As System.Windows.Forms.Label
  Friend WithEvents Label73 As System.Windows.Forms.Label
  Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
  Friend WithEvents Label60 As System.Windows.Forms.Label
  Friend WithEvents Label99 As System.Windows.Forms.Label
  Friend WithEvents Label58 As System.Windows.Forms.Label
  Friend WithEvents Label57 As System.Windows.Forms.Label
  Friend WithEvents Label55 As System.Windows.Forms.Label
  Friend WithEvents LblListNo As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents LblAdjTax As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents LblBenefit As System.Windows.Forms.Label
  Friend WithEvents LblMillRate As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents LblAdjGrossTxt As System.Windows.Forms.Label
  Friend WithEvents LblTax As System.Windows.Forms.Label
  Friend WithEvents LblNet As System.Windows.Forms.Label
  Friend WithEvents Label34 As System.Windows.Forms.Label
  Friend WithEvents LblExempt As System.Windows.Forms.Label
  Friend WithEvents LblGross As System.Windows.Forms.Label
  Friend WithEvents LblAdjGross As System.Windows.Forms.Label
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents LblLocAmt As System.Windows.Forms.Label
  Friend WithEvents LblAdjLocTax As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents BtnLocal As System.Windows.Forms.Button
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
  Friend WithEvents BtnRecalc As System.Windows.Forms.Button
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents LblTaxTxt As System.Windows.Forms.Label
  Friend WithEvents LblBaseTax As System.Windows.Forms.Label
  Friend WithEvents TxtLocFrzTax As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents LblEldPgm As System.Windows.Forms.Label
  Friend WithEvents LblEldAdj As System.Windows.Forms.Label
  Friend WithEvents LblEldTax As System.Windows.Forms.Label
  Friend WithEvents LblEldMin As System.Windows.Forms.Label
  Friend WithEvents LblEldMax As System.Windows.Forms.Label
  Friend WithEvents LblEldPerc As System.Windows.Forms.Label
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents BtnRemoveEld As System.Windows.Forms.Button
  Friend WithEvents TxtEldYear As System.Windows.Forms.TextBox
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
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents LblRECity As System.Windows.Forms.Label
  Friend WithEvents LblREAdd2 As System.Windows.Forms.Label
  Friend WithEvents LblREAdd1 As System.Windows.Forms.Label
  Friend WithEvents LblRESname As System.Windows.Forms.Label
  Friend WithEvents LblREName As System.Windows.Forms.Label
  Friend WithEvents LblUnit As System.Windows.Forms.Label
  Friend WithEvents Label32 As System.Windows.Forms.Label
  Friend WithEvents LblSMap As System.Windows.Forms.Label
  Friend WithEvents Label28 As System.Windows.Forms.Label
  Friend WithEvents LblMap As System.Windows.Forms.Label
  Friend WithEvents Label26 As System.Windows.Forms.Label
  Friend WithEvents LblDist As System.Windows.Forms.Label
  Friend WithEvents Label24 As System.Windows.Forms.Label
  Friend WithEvents LblLoc As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents LblREState As System.Windows.Forms.Label
  Friend WithEvents LblReZip5 As System.Windows.Forms.Label
  Friend WithEvents LblREZip4 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LblAdjGrossTxt = New System.Windows.Forms.Label()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LblREZip4 = New System.Windows.Forms.Label()
    Me.LblReZip5 = New System.Windows.Forms.Label()
    Me.LblREState = New System.Windows.Forms.Label()
    Me.LblUnit = New System.Windows.Forms.Label()
    Me.Label32 = New System.Windows.Forms.Label()
    Me.LblSMap = New System.Windows.Forms.Label()
    Me.Label28 = New System.Windows.Forms.Label()
    Me.LblMap = New System.Windows.Forms.Label()
    Me.Label26 = New System.Windows.Forms.Label()
    Me.LblDist = New System.Windows.Forms.Label()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.LblLoc = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.LblRECity = New System.Windows.Forms.Label()
    Me.LblREAdd2 = New System.Windows.Forms.Label()
    Me.LblREAdd1 = New System.Windows.Forms.Label()
    Me.LblRESname = New System.Windows.Forms.Label()
    Me.LblREName = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.GroupBox7 = New System.Windows.Forms.GroupBox()
    Me.TxtLocFrzTax = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtLocRef = New System.Windows.Forms.TextBox()
    Me.TxtLocPerc = New System.Windows.Forms.TextBox()
    Me.Label72 = New System.Windows.Forms.Label()
    Me.Label73 = New System.Windows.Forms.Label()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.TxtEldYear = New System.Windows.Forms.TextBox()
    Me.BtnRemoveEld = New System.Windows.Forms.Button()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.LblEldPgm = New System.Windows.Forms.Label()
    Me.LblEldAdj = New System.Windows.Forms.Label()
    Me.LblEldTax = New System.Windows.Forms.Label()
    Me.LblEldMin = New System.Windows.Forms.Label()
    Me.LblEldMax = New System.Windows.Forms.Label()
    Me.LblEldPerc = New System.Windows.Forms.Label()
    Me.Label60 = New System.Windows.Forms.Label()
    Me.Label99 = New System.Windows.Forms.Label()
    Me.Label58 = New System.Windows.Forms.Label()
    Me.Label57 = New System.Windows.Forms.Label()
    Me.Label55 = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.LblAdjGross = New System.Windows.Forms.Label()
    Me.LblGross = New System.Windows.Forms.Label()
    Me.LblExempt = New System.Windows.Forms.Label()
    Me.Label34 = New System.Windows.Forms.Label()
    Me.LblNet = New System.Windows.Forms.Label()
    Me.LblTax = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.LblTaxTxt = New System.Windows.Forms.Label()
    Me.LblBaseTax = New System.Windows.Forms.Label()
    Me.LblAdjLocTax = New System.Windows.Forms.Label()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.LblLocAmt = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.LblAdjTax = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.LblBenefit = New System.Windows.Forms.Label()
    Me.LblMillRate = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.BtnLocal = New System.Windows.Forms.Button()
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.BtnRecalc = New System.Windows.Forms.Button()
    Me.Label15 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox4.SuspendLayout()
    Me.GroupBox7.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblAdjGrossTxt
    '
    Me.LblAdjGrossTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAdjGrossTxt.ForeColor = System.Drawing.Color.Black
    Me.LblAdjGrossTxt.Location = New System.Drawing.Point(8, 64)
    Me.LblAdjGrossTxt.Name = "LblAdjGrossTxt"
    Me.LblAdjGrossTxt.Size = New System.Drawing.Size(59, 16)
    Me.LblAdjGrossTxt.TabIndex = 24
    Me.LblAdjGrossTxt.Text = "Adj Gross"
    Me.Ttp1.SetToolTip(Me.LblAdjGrossTxt, "Omits 12,61,62,63 Codes")
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.LblListNo)
    Me.GroupBox4.Controls.Add(Me.Label1)
    Me.GroupBox4.Controls.Add(Me.LblREZip4)
    Me.GroupBox4.Controls.Add(Me.LblReZip5)
    Me.GroupBox4.Controls.Add(Me.LblREState)
    Me.GroupBox4.Controls.Add(Me.LblUnit)
    Me.GroupBox4.Controls.Add(Me.Label32)
    Me.GroupBox4.Controls.Add(Me.LblSMap)
    Me.GroupBox4.Controls.Add(Me.Label28)
    Me.GroupBox4.Controls.Add(Me.LblMap)
    Me.GroupBox4.Controls.Add(Me.Label26)
    Me.GroupBox4.Controls.Add(Me.LblDist)
    Me.GroupBox4.Controls.Add(Me.Label24)
    Me.GroupBox4.Controls.Add(Me.LblLoc)
    Me.GroupBox4.Controls.Add(Me.Label7)
    Me.GroupBox4.Controls.Add(Me.LblRECity)
    Me.GroupBox4.Controls.Add(Me.LblREAdd2)
    Me.GroupBox4.Controls.Add(Me.LblREAdd1)
    Me.GroupBox4.Controls.Add(Me.LblRESname)
    Me.GroupBox4.Controls.Add(Me.LblREName)
    Me.GroupBox4.Controls.Add(Me.Label8)
    Me.GroupBox4.Controls.Add(Me.Label9)
    Me.GroupBox4.Controls.Add(Me.Label10)
    Me.GroupBox4.Controls.Add(Me.Label11)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(12, 12)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(384, 212)
    Me.GroupBox4.TabIndex = 70
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Real Estate Name and Address "
    '
    'LblListNo
    '
    Me.LblListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblListNo.Location = New System.Drawing.Point(96, 16)
    Me.LblListNo.Name = "LblListNo"
    Me.LblListNo.Size = New System.Drawing.Size(55, 16)
    Me.LblListNo.TabIndex = 142
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(8, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 16)
    Me.Label1.TabIndex = 141
    Me.Label1.Text = "List No"
    '
    'LblREZip4
    '
    Me.LblREZip4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblREZip4.Location = New System.Drawing.Point(344, 129)
    Me.LblREZip4.Name = "LblREZip4"
    Me.LblREZip4.Size = New System.Drawing.Size(32, 16)
    Me.LblREZip4.TabIndex = 82
    '
    'LblReZip5
    '
    Me.LblReZip5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblReZip5.Location = New System.Drawing.Point(296, 129)
    Me.LblReZip5.Name = "LblReZip5"
    Me.LblReZip5.Size = New System.Drawing.Size(40, 16)
    Me.LblReZip5.TabIndex = 81
    '
    'LblREState
    '
    Me.LblREState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblREState.Location = New System.Drawing.Point(264, 129)
    Me.LblREState.Name = "LblREState"
    Me.LblREState.Size = New System.Drawing.Size(24, 16)
    Me.LblREState.TabIndex = 80
    '
    'LblUnit
    '
    Me.LblUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblUnit.Location = New System.Drawing.Point(344, 177)
    Me.LblUnit.Name = "LblUnit"
    Me.LblUnit.Size = New System.Drawing.Size(32, 16)
    Me.LblUnit.TabIndex = 79
    '
    'Label32
    '
    Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label32.Location = New System.Drawing.Point(304, 177)
    Me.Label32.Name = "Label32"
    Me.Label32.Size = New System.Drawing.Size(32, 16)
    Me.Label32.TabIndex = 78
    Me.Label32.Text = "Unit"
    '
    'LblSMap
    '
    Me.LblSMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblSMap.Location = New System.Drawing.Point(280, 193)
    Me.LblSMap.Name = "LblSMap"
    Me.LblSMap.Size = New System.Drawing.Size(88, 16)
    Me.LblSMap.TabIndex = 77
    '
    'Label28
    '
    Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label28.Location = New System.Drawing.Point(224, 193)
    Me.Label28.Name = "Label28"
    Me.Label28.Size = New System.Drawing.Size(48, 16)
    Me.Label28.TabIndex = 76
    Me.Label28.Text = "S. Map"
    '
    'LblMap
    '
    Me.LblMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMap.Location = New System.Drawing.Point(104, 193)
    Me.LblMap.Name = "LblMap"
    Me.LblMap.Size = New System.Drawing.Size(112, 16)
    Me.LblMap.TabIndex = 75
    '
    'Label26
    '
    Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label26.Location = New System.Drawing.Point(8, 193)
    Me.Label26.Name = "Label26"
    Me.Label26.Size = New System.Drawing.Size(88, 16)
    Me.Label26.TabIndex = 74
    Me.Label26.Text = "Map"
    '
    'LblDist
    '
    Me.LblDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDist.Location = New System.Drawing.Point(104, 161)
    Me.LblDist.Name = "LblDist"
    Me.LblDist.Size = New System.Drawing.Size(32, 16)
    Me.LblDist.TabIndex = 73
    '
    'Label24
    '
    Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label24.Location = New System.Drawing.Point(8, 161)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(56, 16)
    Me.Label24.TabIndex = 72
    Me.Label24.Text = "District"
    '
    'LblLoc
    '
    Me.LblLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLoc.Location = New System.Drawing.Point(104, 177)
    Me.LblLoc.Name = "LblLoc"
    Me.LblLoc.Size = New System.Drawing.Size(192, 16)
    Me.LblLoc.TabIndex = 71
    '
    'Label7
    '
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(8, 177)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(88, 16)
    Me.Label7.TabIndex = 70
    Me.Label7.Text = "Location#/Name"
    '
    'LblRECity
    '
    Me.LblRECity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblRECity.Location = New System.Drawing.Point(96, 129)
    Me.LblRECity.Name = "LblRECity"
    Me.LblRECity.Size = New System.Drawing.Size(168, 16)
    Me.LblRECity.TabIndex = 63
    '
    'LblREAdd2
    '
    Me.LblREAdd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblREAdd2.Location = New System.Drawing.Point(96, 105)
    Me.LblREAdd2.Name = "LblREAdd2"
    Me.LblREAdd2.Size = New System.Drawing.Size(272, 16)
    Me.LblREAdd2.TabIndex = 62
    '
    'LblREAdd1
    '
    Me.LblREAdd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblREAdd1.Location = New System.Drawing.Point(96, 81)
    Me.LblREAdd1.Name = "LblREAdd1"
    Me.LblREAdd1.Size = New System.Drawing.Size(272, 16)
    Me.LblREAdd1.TabIndex = 61
    '
    'LblRESname
    '
    Me.LblRESname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblRESname.Location = New System.Drawing.Point(96, 57)
    Me.LblRESname.Name = "LblRESname"
    Me.LblRESname.Size = New System.Drawing.Size(272, 16)
    Me.LblRESname.TabIndex = 60
    Me.LblRESname.UseMnemonic = False
    '
    'LblREName
    '
    Me.LblREName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblREName.Location = New System.Drawing.Point(96, 33)
    Me.LblREName.Name = "LblREName"
    Me.LblREName.Size = New System.Drawing.Size(272, 16)
    Me.LblREName.TabIndex = 59
    Me.LblREName.UseMnemonic = False
    '
    'Label8
    '
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(8, 129)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(80, 16)
    Me.Label8.TabIndex = 58
    Me.Label8.Text = "City/State/Zip"
    '
    'Label9
    '
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(8, 81)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(80, 16)
    Me.Label9.TabIndex = 57
    Me.Label9.Text = "Street Address"
    '
    'Label10
    '
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(8, 57)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(80, 16)
    Me.Label10.TabIndex = 56
    Me.Label10.Text = "Second Name"
    '
    'Label11
    '
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.Location = New System.Drawing.Point(8, 33)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(48, 16)
    Me.Label11.TabIndex = 55
    Me.Label11.Text = "Name"
    '
    'GroupBox7
    '
    Me.GroupBox7.Controls.Add(Me.TxtLocFrzTax)
    Me.GroupBox7.Controls.Add(Me.Label2)
    Me.GroupBox7.Controls.Add(Me.TxtLocRef)
    Me.GroupBox7.Controls.Add(Me.TxtLocPerc)
    Me.GroupBox7.Controls.Add(Me.Label72)
    Me.GroupBox7.Controls.Add(Me.Label73)
    Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox7.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox7.Location = New System.Drawing.Point(402, 209)
    Me.GroupBox7.Name = "GroupBox7"
    Me.GroupBox7.Size = New System.Drawing.Size(192, 103)
    Me.GroupBox7.TabIndex = 143
    Me.GroupBox7.TabStop = False
    Me.GroupBox7.Text = "Local Benefit"
    '
    'TxtLocFrzTax
    '
    Me.TxtLocFrzTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocFrzTax.Location = New System.Drawing.Point(99, 69)
    Me.TxtLocFrzTax.MaxLength = 8
    Me.TxtLocFrzTax.Name = "TxtLocFrzTax"
    Me.TxtLocFrzTax.Size = New System.Drawing.Size(72, 20)
    Me.TxtLocFrzTax.TabIndex = 76
    Me.TxtLocFrzTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.ForeColor = System.Drawing.Color.Black
    Me.Label2.Location = New System.Drawing.Point(11, 70)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(64, 16)
    Me.Label2.TabIndex = 75
    Me.Label2.Text = "Frozen Tax"
    '
    'TxtLocRef
    '
    Me.TxtLocRef.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocRef.Location = New System.Drawing.Point(99, 45)
    Me.TxtLocRef.MaxLength = 7
    Me.TxtLocRef.Name = "TxtLocRef"
    Me.TxtLocRef.Size = New System.Drawing.Size(72, 20)
    Me.TxtLocRef.TabIndex = 72
    Me.TxtLocRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtLocPerc
    '
    Me.TxtLocPerc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocPerc.Location = New System.Drawing.Point(99, 21)
    Me.TxtLocPerc.MaxLength = 6
    Me.TxtLocPerc.Name = "TxtLocPerc"
    Me.TxtLocPerc.Size = New System.Drawing.Size(48, 20)
    Me.TxtLocPerc.TabIndex = 71
    Me.TxtLocPerc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label72
    '
    Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label72.ForeColor = System.Drawing.Color.Black
    Me.Label72.Location = New System.Drawing.Point(11, 45)
    Me.Label72.Name = "Label72"
    Me.Label72.Size = New System.Drawing.Size(88, 16)
    Me.Label72.TabIndex = 4
    Me.Label72.Text = "Reference List#"
    '
    'Label73
    '
    Me.Label73.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label73.ForeColor = System.Drawing.Color.Black
    Me.Label73.Location = New System.Drawing.Point(11, 21)
    Me.Label73.Name = "Label73"
    Me.Label73.Size = New System.Drawing.Size(64, 16)
    Me.Label73.TabIndex = 3
    Me.Label73.Text = "Percentage"
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.TxtEldYear)
    Me.GroupBox5.Controls.Add(Me.BtnRemoveEld)
    Me.GroupBox5.Controls.Add(Me.Label17)
    Me.GroupBox5.Controls.Add(Me.LblEldPgm)
    Me.GroupBox5.Controls.Add(Me.LblEldAdj)
    Me.GroupBox5.Controls.Add(Me.LblEldTax)
    Me.GroupBox5.Controls.Add(Me.LblEldMin)
    Me.GroupBox5.Controls.Add(Me.LblEldMax)
    Me.GroupBox5.Controls.Add(Me.LblEldPerc)
    Me.GroupBox5.Controls.Add(Me.Label60)
    Me.GroupBox5.Controls.Add(Me.Label99)
    Me.GroupBox5.Controls.Add(Me.Label58)
    Me.GroupBox5.Controls.Add(Me.Label57)
    Me.GroupBox5.Controls.Add(Me.Label55)
    Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox5.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox5.Location = New System.Drawing.Point(402, 12)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(192, 191)
    Me.GroupBox5.TabIndex = 142
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "Heart/Frozen Program"
    '
    'TxtEldYear
    '
    Me.TxtEldYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtEldYear.Location = New System.Drawing.Point(90, 36)
    Me.TxtEldYear.MaxLength = 4
    Me.TxtEldYear.Name = "TxtEldYear"
    Me.TxtEldYear.Size = New System.Drawing.Size(42, 22)
    Me.TxtEldYear.TabIndex = 193
    '
    'BtnRemoveEld
    '
    Me.BtnRemoveEld.ForeColor = System.Drawing.Color.Black
    Me.BtnRemoveEld.Location = New System.Drawing.Point(128, 10)
    Me.BtnRemoveEld.Name = "BtnRemoveEld"
    Me.BtnRemoveEld.Size = New System.Drawing.Size(58, 22)
    Me.BtnRemoveEld.TabIndex = 192
    Me.BtnRemoveEld.Text = "Remove"
    Me.BtnRemoveEld.UseVisualStyleBackColor = True
    '
    'Label17
    '
    Me.Label17.AutoSize = True
    Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label17.ForeColor = System.Drawing.Color.Black
    Me.Label17.Location = New System.Drawing.Point(19, 64)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(62, 13)
    Me.Label17.TabIndex = 191
    Me.Label17.Text = "Percentage"
    '
    'LblEldPgm
    '
    Me.LblEldPgm.AutoSize = True
    Me.LblEldPgm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblEldPgm.ForeColor = System.Drawing.Color.Black
    Me.LblEldPgm.Location = New System.Drawing.Point(19, 18)
    Me.LblEldPgm.Name = "LblEldPgm"
    Me.LblEldPgm.Size = New System.Drawing.Size(92, 13)
    Me.LblEldPgm.TabIndex = 190
    Me.LblEldPgm.Text = "<Elderly Program>"
    '
    'LblEldAdj
    '
    Me.LblEldAdj.BackColor = System.Drawing.Color.Aqua
    Me.LblEldAdj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblEldAdj.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblEldAdj.ForeColor = System.Drawing.Color.Black
    Me.LblEldAdj.Location = New System.Drawing.Point(90, 158)
    Me.LblEldAdj.Name = "LblEldAdj"
    Me.LblEldAdj.Size = New System.Drawing.Size(60, 16)
    Me.LblEldAdj.TabIndex = 189
    Me.LblEldAdj.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblEldTax
    '
    Me.LblEldTax.BackColor = System.Drawing.Color.Aqua
    Me.LblEldTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblEldTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblEldTax.ForeColor = System.Drawing.Color.Black
    Me.LblEldTax.Location = New System.Drawing.Point(90, 133)
    Me.LblEldTax.Name = "LblEldTax"
    Me.LblEldTax.Size = New System.Drawing.Size(60, 16)
    Me.LblEldTax.TabIndex = 188
    Me.LblEldTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblEldMin
    '
    Me.LblEldMin.BackColor = System.Drawing.Color.Aqua
    Me.LblEldMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblEldMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblEldMin.ForeColor = System.Drawing.Color.Black
    Me.LblEldMin.Location = New System.Drawing.Point(90, 110)
    Me.LblEldMin.Name = "LblEldMin"
    Me.LblEldMin.Size = New System.Drawing.Size(60, 16)
    Me.LblEldMin.TabIndex = 187
    Me.LblEldMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblEldMax
    '
    Me.LblEldMax.BackColor = System.Drawing.Color.Aqua
    Me.LblEldMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblEldMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblEldMax.ForeColor = System.Drawing.Color.Black
    Me.LblEldMax.Location = New System.Drawing.Point(90, 88)
    Me.LblEldMax.Name = "LblEldMax"
    Me.LblEldMax.Size = New System.Drawing.Size(60, 16)
    Me.LblEldMax.TabIndex = 186
    Me.LblEldMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblEldPerc
    '
    Me.LblEldPerc.BackColor = System.Drawing.Color.Aqua
    Me.LblEldPerc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblEldPerc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblEldPerc.ForeColor = System.Drawing.Color.Black
    Me.LblEldPerc.Location = New System.Drawing.Point(90, 66)
    Me.LblEldPerc.Name = "LblEldPerc"
    Me.LblEldPerc.Size = New System.Drawing.Size(35, 16)
    Me.LblEldPerc.TabIndex = 185
    Me.LblEldPerc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label60
    '
    Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label60.ForeColor = System.Drawing.Color.Black
    Me.Label60.Location = New System.Drawing.Point(16, 160)
    Me.Label60.Name = "Label60"
    Me.Label60.Size = New System.Drawing.Size(64, 16)
    Me.Label60.TabIndex = 7
    Me.Label60.Text = "Adjustment"
    '
    'Label99
    '
    Me.Label99.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label99.ForeColor = System.Drawing.Color.Black
    Me.Label99.Location = New System.Drawing.Point(16, 136)
    Me.Label99.Name = "Label99"
    Me.Label99.Size = New System.Drawing.Size(64, 16)
    Me.Label99.TabIndex = 6
    Me.Label99.Text = "Frozen Tax"
    '
    'Label58
    '
    Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label58.ForeColor = System.Drawing.Color.Black
    Me.Label58.Location = New System.Drawing.Point(16, 112)
    Me.Label58.Name = "Label58"
    Me.Label58.Size = New System.Drawing.Size(56, 16)
    Me.Label58.TabIndex = 5
    Me.Label58.Text = "Minimum"
    '
    'Label57
    '
    Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label57.ForeColor = System.Drawing.Color.Black
    Me.Label57.Location = New System.Drawing.Point(16, 88)
    Me.Label57.Name = "Label57"
    Me.Label57.Size = New System.Drawing.Size(56, 16)
    Me.Label57.TabIndex = 4
    Me.Label57.Text = "Maximum"
    '
    'Label55
    '
    Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label55.ForeColor = System.Drawing.Color.Black
    Me.Label55.Location = New System.Drawing.Point(16, 40)
    Me.Label55.Name = "Label55"
    Me.Label55.Size = New System.Drawing.Size(56, 16)
    Me.Label55.TabIndex = 2
    Me.Label55.Text = "Year"
    '
    'Label29
    '
    Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label29.Location = New System.Drawing.Point(8, 16)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(40, 16)
    Me.Label29.TabIndex = 15
    Me.Label29.Text = "Gross"
    '
    'Label30
    '
    Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label30.Location = New System.Drawing.Point(8, 32)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(48, 16)
    Me.Label30.TabIndex = 16
    Me.Label30.Text = "Exempt"
    '
    'LblAdjGross
    '
    Me.LblAdjGross.BackColor = System.Drawing.Color.Thistle
    Me.LblAdjGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAdjGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAdjGross.Location = New System.Drawing.Point(68, 64)
    Me.LblAdjGross.Name = "LblAdjGross"
    Me.LblAdjGross.Size = New System.Drawing.Size(64, 16)
    Me.LblAdjGross.TabIndex = 17
    Me.LblAdjGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblGross
    '
    Me.LblGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblGross.Location = New System.Drawing.Point(68, 16)
    Me.LblGross.Name = "LblGross"
    Me.LblGross.Size = New System.Drawing.Size(64, 16)
    Me.LblGross.TabIndex = 18
    Me.LblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExempt
    '
    Me.LblExempt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExempt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExempt.Location = New System.Drawing.Point(68, 32)
    Me.LblExempt.Name = "LblExempt"
    Me.LblExempt.Size = New System.Drawing.Size(64, 16)
    Me.LblExempt.TabIndex = 19
    Me.LblExempt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label34
    '
    Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label34.Location = New System.Drawing.Point(8, 48)
    Me.Label34.Name = "Label34"
    Me.Label34.Size = New System.Drawing.Size(48, 16)
    Me.Label34.TabIndex = 20
    Me.Label34.Text = "Net"
    '
    'LblNet
    '
    Me.LblNet.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNet.Location = New System.Drawing.Point(68, 48)
    Me.LblNet.Name = "LblNet"
    Me.LblNet.Size = New System.Drawing.Size(64, 16)
    Me.LblNet.TabIndex = 21
    Me.LblNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTax
    '
    Me.LblTax.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTax.Location = New System.Drawing.Point(68, 143)
    Me.LblTax.Name = "LblTax"
    Me.LblTax.Size = New System.Drawing.Size(64, 16)
    Me.LblTax.TabIndex = 23
    Me.LblTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(8, 142)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(59, 16)
    Me.Label3.TabIndex = 25
    Me.Label3.Text = "Tax"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.LblTaxTxt)
    Me.GroupBox2.Controls.Add(Me.LblBaseTax)
    Me.GroupBox2.Controls.Add(Me.LblAdjLocTax)
    Me.GroupBox2.Controls.Add(Me.Label14)
    Me.GroupBox2.Controls.Add(Me.Label12)
    Me.GroupBox2.Controls.Add(Me.LblLocAmt)
    Me.GroupBox2.Controls.Add(Me.Label13)
    Me.GroupBox2.Controls.Add(Me.LblAdjTax)
    Me.GroupBox2.Controls.Add(Me.Label6)
    Me.GroupBox2.Controls.Add(Me.LblBenefit)
    Me.GroupBox2.Controls.Add(Me.LblMillRate)
    Me.GroupBox2.Controls.Add(Me.Label5)
    Me.GroupBox2.Controls.Add(Me.Label3)
    Me.GroupBox2.Controls.Add(Me.LblAdjGrossTxt)
    Me.GroupBox2.Controls.Add(Me.LblTax)
    Me.GroupBox2.Controls.Add(Me.LblNet)
    Me.GroupBox2.Controls.Add(Me.Label34)
    Me.GroupBox2.Controls.Add(Me.LblExempt)
    Me.GroupBox2.Controls.Add(Me.LblGross)
    Me.GroupBox2.Controls.Add(Me.LblAdjGross)
    Me.GroupBox2.Controls.Add(Me.Label30)
    Me.GroupBox2.Controls.Add(Me.Label29)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(600, 12)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(142, 268)
    Me.GroupBox2.TabIndex = 144
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Totals "
    '
    'LblTaxTxt
    '
    Me.LblTaxTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTaxTxt.Location = New System.Drawing.Point(6, 116)
    Me.LblTaxTxt.Name = "LblTaxTxt"
    Me.LblTaxTxt.Size = New System.Drawing.Size(59, 16)
    Me.LblTaxTxt.TabIndex = 158
    Me.LblTaxTxt.Text = "Base Tax"
    Me.LblTaxTxt.Visible = False
    '
    'LblBaseTax
    '
    Me.LblBaseTax.BackColor = System.Drawing.Color.Thistle
    Me.LblBaseTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblBaseTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBaseTax.Location = New System.Drawing.Point(68, 117)
    Me.LblBaseTax.Name = "LblBaseTax"
    Me.LblBaseTax.Size = New System.Drawing.Size(64, 16)
    Me.LblBaseTax.TabIndex = 157
    Me.LblBaseTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblAdjLocTax
    '
    Me.LblAdjLocTax.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAdjLocTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAdjLocTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAdjLocTax.Location = New System.Drawing.Point(68, 216)
    Me.LblAdjLocTax.Name = "LblAdjLocTax"
    Me.LblAdjLocTax.Size = New System.Drawing.Size(64, 16)
    Me.LblAdjLocTax.TabIndex = 156
    Me.LblAdjLocTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label14
    '
    Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label14.Location = New System.Drawing.Point(8, 217)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(59, 16)
    Me.Label14.TabIndex = 155
    Me.Label14.Text = "Adjust Tax"
    '
    'Label12
    '
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(8, 200)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(59, 17)
    Me.Label12.TabIndex = 154
    Me.Label12.Text = "Local Ben"
    '
    'LblLocAmt
    '
    Me.LblLocAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocAmt.Location = New System.Drawing.Point(68, 200)
    Me.LblLocAmt.Name = "LblLocAmt"
    Me.LblLocAmt.Size = New System.Drawing.Size(64, 16)
    Me.LblLocAmt.TabIndex = 153
    Me.LblLocAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label13
    '
    Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label13.Location = New System.Drawing.Point(8, 174)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(59, 16)
    Me.Label13.TabIndex = 152
    Me.Label13.Text = "Adjust Tax"
    '
    'LblAdjTax
    '
    Me.LblAdjTax.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAdjTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAdjTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAdjTax.Location = New System.Drawing.Point(68, 175)
    Me.LblAdjTax.Name = "LblAdjTax"
    Me.LblAdjTax.Size = New System.Drawing.Size(64, 16)
    Me.LblAdjTax.TabIndex = 151
    Me.LblAdjTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label6
    '
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(8, 158)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(59, 16)
    Me.Label6.TabIndex = 150
    Me.Label6.Text = "Benefit"
    '
    'LblBenefit
    '
    Me.LblBenefit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblBenefit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblBenefit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBenefit.Location = New System.Drawing.Point(68, 159)
    Me.LblBenefit.Name = "LblBenefit"
    Me.LblBenefit.Size = New System.Drawing.Size(64, 16)
    Me.LblBenefit.TabIndex = 149
    Me.LblBenefit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblMillRate
    '
    Me.LblMillRate.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblMillRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblMillRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMillRate.Location = New System.Drawing.Point(68, 92)
    Me.LblMillRate.Name = "LblMillRate"
    Me.LblMillRate.Size = New System.Drawing.Size(64, 16)
    Me.LblMillRate.TabIndex = 148
    Me.LblMillRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(8, 92)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(54, 16)
    Me.Label5.TabIndex = 147
    Me.Label5.Text = "Mill Rate"
    '
    'BtnLocal
    '
    Me.BtnLocal.Location = New System.Drawing.Point(600, 283)
    Me.BtnLocal.Name = "BtnLocal"
    Me.BtnLocal.Size = New System.Drawing.Size(142, 29)
    Me.BtnLocal.TabIndex = 145
    Me.BtnLocal.Text = "Maintain Local Benefits"
    Me.BtnLocal.UseVisualStyleBackColor = True
    '
    'TxtGLYear
    '
    Me.TxtGLYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGLYear.Location = New System.Drawing.Point(75, 275)
    Me.TxtGLYear.MaxLength = 4
    Me.TxtGLYear.Name = "TxtGLYear"
    Me.TxtGLYear.Size = New System.Drawing.Size(40, 20)
    Me.TxtGLYear.TabIndex = 203
    Me.TxtGLYear.TabStop = False
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.ForeColor = System.Drawing.Color.Black
    Me.Label4.Location = New System.Drawing.Point(13, 278)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(56, 17)
    Me.Label4.TabIndex = 204
    Me.Label4.Text = "G/L Year*"
    '
    'BtnRecalc
    '
    Me.BtnRecalc.Location = New System.Drawing.Point(130, 271)
    Me.BtnRecalc.Name = "BtnRecalc"
    Me.BtnRecalc.Size = New System.Drawing.Size(49, 26)
    Me.BtnRecalc.TabIndex = 205
    Me.BtnRecalc.Text = "Recalc"
    Me.BtnRecalc.UseVisualStyleBackColor = True
    '
    'Label15
    '
    Me.Label15.AutoSize = True
    Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label15.Location = New System.Drawing.Point(16, 299)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(290, 13)
    Me.Label15.TabIndex = 206
    Me.Label15.Text = "* G/L Year is for estimating Tax Amounts and is NOT saved."
    '
    'FrmTA202C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(747, 324)
    Me.Controls.Add(Me.Label15)
    Me.Controls.Add(Me.BtnRecalc)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtGLYear)
    Me.Controls.Add(Me.BtnLocal)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox7)
    Me.Controls.Add(Me.GroupBox5)
    Me.Controls.Add(Me.GroupBox4)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA202C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox7.ResumeLayout(False)
    Me.GroupBox7.PerformLayout()
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTA202C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Dim WrkAssCode(6) As Integer
    Dim WrkGross(6) As Integer
    Dim WrkFrozenCode As String
    Dim WrkAdjGross As Integer
    Dim WrkTax As Decimal
    Dim J As Integer

    myTXREALC = New TXREALC.mydata(MyDBConnect)
    myTXREAL = New TXReal.mydata(MyDBConnect)
    myTXLOCFRZ = New TXLOCFRZ.mydata(MyDBConnect)
    myTXHOME = New TXHOME.mydata(MyDBConnect)

    LoadScrn = True
    MyFrmTA202.TBarSave.Enabled = True

    AddMode = False
    If WrkListNo > 0 Then
      Me.Text = "Maintain " & Me.Text
      LblListNo.Text = WrkListNo
      myTXREALC.GetOneRecordP(WrkListNo)
      If myTXREALC.RecordNotFound Then
         MyFrmTA202.TBarSave.Enabled = False
         Me.ErrProv.SetError(LblListNo, "Record not found")
         Exit Sub
      End If

     cExcludeCode1 = GetTXCDAGCode(1)
     cExcludeCode2 = GetTXCDAGCode(2)
     cExcludeCode3 = GetTXCDAGCode(3)
     cExcludeCode4 = GetTXCDAGCode(4)
     If cExcludeCode1 = 0 Then cExcludeCode1 = 12
     If cExcludeCode2 = 0 Then cExcludeCode2 = 61
     If cExcludeCode3 = 0 Then cExcludeCode3 = 62
     If cExcludeCode4 = 0 Then cExcludeCode4 = 63

      With myTXREALC
        WrkAssCode(0) = ._CODE1
        WrkAssCode(1) = ._CODE2
        WrkAssCode(2) = ._CODE3
        WrkAssCode(3) = ._CODE4
        WrkAssCode(4) = ._CODE5
        WrkAssCode(5) = ._CODE6
        WrkAssCode(6) = ._CODE7
        WrkGross(0) = ._ASS1
        WrkGross(1) = ._ASS2
        WrkGross(2) = ._ASS3
        WrkGross(3) = ._ASS4
        WrkGross(4) = ._ASS5
        WrkGross(5) = ._ASS6
        WrkGross(6) = ._ASS7
        LblREName.Text = Trim(._NAME)
        LblRESname.Text = Trim(._SNAME)
        LblREAdd1.Text = Trim(._ADD1)
        LblREAdd2.Text = Trim(._ADD2)
        LblRECity.Text = Trim(._CITY)
        LblREState.Text = Trim(._STATE)
        LblReZip5.Text = Format(._ZIP5, "00000")
        LblREZip4.Text = Format(._ZIP4, "0000")
        LblLoc.Text = Trim(._LOCNO) & " " & Trim(._LOC)
        LblDist.Text = ._DIST
        LblMap.Text = Trim(._MAP)
        LblSMap.Text = Trim(._SMAP)
        'Elderly
        TxtEldYear.Text = ._FCYR
        LblEldPerc.Text = ._CPERC
        LblEldMax.Text = ._CMAX
        LblEldMin.Text = ._CMIN
        LblEldTax.Text = ._FTAX
        LblEldAdj.Text = ._CIRAD
        LblLocAmt.Text = MyUtils.FmtCurrency(._TWNBN)
        TxtLocPerc.Text = ._PERC
        TxtLocRef.Text = ._RLST
        WrkFrozenCode = Trim(._FCCOD)
        Select Case WrkFrozenCode
        Case Is = "F"
          LblEldPgm.Text = "Frozen"
          BtnRemoveEld.Visible = True
        Case Is = "C"
          LblEldPgm.Text = "Heart"
          BtnRemoveEld.Visible = True
        Case Else
          LblEldPgm.Text = "N/A"
          BtnRemoveEld.Visible = False
        End Select
        'Totals
        If ._CCNO > 0 Then
          LblGross.Text = ._CCGRS
          LblExempt.Text = ._CCEX
          LblNet.Text = ._CCGRS - ._CCEX
        Else
          LblGross.Text = ._GROSS + ._BTR
          LblExempt.Text = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 _
            + ._EXAM5 + ._EXAM6 + ._EXAM7
          LblNet.Text = ._NET + ._BTR
        End If
        'Add Gross to Land or Building total
        WrkAdjGross = 0
        For J = 0 To 6
          If WrkAssCode(J) <> cExcludeCode1 And WrkAssCode(J) <> cExcludeCode2 _
            And WrkAssCode(J) <> cExcludeCode3 And WrkAssCode(J) <> cExcludeCode4 Then
            WrkAdjGross = WrkAdjGross + WrkGross(J)
          End If
        Next J
        LblAdjGross.Text = WrkAdjGross + ._BTR
        WrkMillRate = GetMRateLast(MyUtils.CnvSng(LblDist.Text))
        LblMillRate.Text = WrkMillRate
        WrkTax = MyUtils.Round((MyUtils.CnvSng(LblGross.Text) - MyUtils.CnvSng(LblExempt.Text)) * WrkMillRate, 2)
        LblTax.Text = MyUtils.FmtCurrency(WrkTax)
        WrkTax = MyUtils.Round((WrkAdjGross - MyUtils.CnvSng(LblExempt.Text)) * WrkMillRate, 2)
        LblBaseTax.Text = MyUtils.FmtCurrency(WrkTax)
        myTXLOCFRZ.GetOneRecordP(WrkListNo)
        If Not myTXLOCFRZ.RecordNotFound Then
          TxtLocFrzTax.Text = myTXLOCFRZ._FRZTAX
        End If
        CalcLocal()
      End With
    Else
      Me.Text = "Add " & Me.Text
      AddMode = True
    End If

    If GLYear = 0 Then
      TxtGLYear.Text = MillRateYear
      GLYear = MillRateYear
    Else
      TxtGLYear.Text = GLYear
    End If

    If MyUtils.CnvSng(LblGross.Text) = MyUtils.CnvSng(LblAdjGross.Text) Then
      LblAdjGross.Visible = False
      LblAdjGrossTxt.Visible = False
      LblBaseTax.Visible = False
      LblTaxTxt.Visible = False
    End If
    LoadScrn = False
 End Sub

  Private Sub FrmTA202C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTA202.TBarSave.Enabled = False
    MyFrmTA202B.FormatGrid()
    MyFrmTA202B.Show()

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    myTXREALC.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    myTXREALC.GetOneRecordP(WrkListNo)

    MoveToFile()
    If IsNothing(ErrorMsg(0)) Then
      myTXREALC.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If

    UpdateTXREAL()

    myTXLOCFRZ.GetOneRecordP(WrkListNo)
    With myTXLOCFRZ
      If MyUtils.CnvSng(TxtLocFrzTax.Text) = 0 Then
        If Not .RecordNotFound Then
          .DeleteOneRecordP()
        End If
      Else
        If .RecordNotFound Then
          ._LISTNo = WrkListNo
          ._FRZTAX = MyUtils.CnvSng(TxtLocFrzTax.Text)
          .AddOneRecordP()
        Else
          ._FRZTAX = MyUtils.CnvSng(TxtLocFrzTax.Text)
          .UpdateOneRecordP()
        End If
      End If
    End With

    Me.Close()

  End Sub
   Private Sub MoveToFile()
      With myTXREALC
        If LblEldPgm.Text = "N/A" Then
          ._FCCOD = ""
          ._FTAX = 0
          ._CMIN = 0
          ._CMAX = 0
          ._CPERC = 0
        End If
        ._FCYR = MyUtils.CnvSng(TxtEldYear.Text)
        ._TWNBN = MyUtils.CnvSng(LblLocAmt.Text)
        ._PERC = MyUtils.CnvSng(TxtLocPerc.Text)
        ._RLST = MyUtils.CnvSng(TxtLocRef.Text)
      End With
   End Sub
  Private Sub UpdateTXREAL()
      myTXREAL.GetOneRecordP(WrkListNo)
      With myTXREAL
        If LblEldPgm.Text = "N/A" Then
          ._FCCOD = ""
          ._FTAX = 0
          ._CMIN = 0
          ._CMAX = 0
          ._CPERC = 0
        End If
        ._FCYR = MyUtils.CnvSng(TxtEldYear.Text)
        ._TWNBN = MyUtils.CnvSng(LblLocAmt.Text)
        ._PERC = MyUtils.CnvSng(TxtLocPerc.Text)
        ._RLST = MyUtils.CnvSng(TxtLocRef.Text)
        myTXREAL.UpdateOneRecordP()
      End With
   End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case ""
        Exit Sub
      End Select
    Next I
  End Sub
  Private Sub FrmTA202C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA202.SbpScreen.Text = "TA202C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
Private Sub TxtEldYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEldYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtLocRef_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLocRef.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtLocFrzTax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLocFrzTax.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Public Sub CalcLocal()
    Dim WrkLocal As Decimal
    Dim WrkAdjLocTax As Decimal
    Dim WrkBaseTax As Decimal
    Dim WrkTax As Decimal
    Dim WrkEldTax As Decimal
    Dim WrkBenefit As Decimal
    Dim WrkAdjTax As Decimal

    WrkBenefit = 0
    WrkAdjTax = 0
    WrkEldTax = MyUtils.CnvSng(LblEldTax.Text)
    WrkBaseTax = MyUtils.CnvSng(LblBaseTax.Text)
    WrkTax = MyUtils.CnvSng(LblTax.Text)

    'Use Amount in file if it's available
    If WrkEldTax > 0 Then
      If LblEldPgm.Text = "Frozen" Then
        WrkAdjTax = WrkEldTax
        WrkBenefit = WrkTax - WrkAdjTax
      Else
        WrkBenefit = WrkEldTax
        WrkAdjTax = WrkTax - WrkBenefit
      End If
      GoTo ShowBenefit
    End If

    WrkBenefit = MyUtils.CnvSng(LblEldTax.Text)
    WrkAdjTax = MyUtils.Round(WrkTax - WrkBenefit, 2)

ShowBenefit:
    LblBenefit.Text = MyUtils.FmtCurrency(WrkBenefit)
    LblAdjTax.Text = MyUtils.FmtCurrency(WrkAdjTax)

    If MyUtils.CnvSng(TxtLocFrzTax.Text) = 0 Then
      WrkLocal = MyUtils.CnvSng(LblLocAmt.Text)
      WrkAdjLocTax = MyUtils.CnvSng(LblAdjTax.Text) - WrkLocal
    Else
      WrkLocal = MyUtils.CnvSng(LblAdjTax.Text) - MyUtils.CnvSng(TxtLocFrzTax.Text)
      LblLocAmt.Text = MyUtils.FmtCurrency(WrkLocal)
      WrkAdjLocTax = MyUtils.CnvSng(TxtLocFrzTax.Text)
    End If
    LblAdjLocTax.Text = MyUtils.FmtCurrency(WrkAdjLocTax)
End Sub
Private Sub BtnLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLocal.Click
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    MyFrmTA202D = New FrmTA202D
    MyFrmTA202D.MdiParent = Me.ParentForm
    MyFrmTA202D.WrkListNo = MyUtils.CnvSng(LblListNo.Text)
    MyFrmTA202D.WrkName = LblREName.Text
    MyFrmTA202D.WrkType = "R"
    MyFrmTA202D.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default
End Sub
 Private Sub TxtLocFrzTax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLocFrzTax.TextChanged
  If LoadScrn Then Exit Sub

  CalcLocal()
 End Sub
 Private Sub BtnRecalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRecalc.Click
  Dim WrkTax As Decimal
  Dim WrkEstTax As Decimal

  GLYear = MyUtils.CnvSng(TxtGLYear.Text)
  WrkMillRate = GetMRate(MyUtils.CnvSng(TxtGLYear.Text), MyUtils.CnvSng(LblDist.Text))
  LblMillRate.Text = WrkMillRate
  WrkTax = MyUtils.Round((MyUtils.CnvSng(LblAdjGross.Text) - MyUtils.CnvSng(LblExempt.Text)) * WrkMillRate, 2)
  LblBaseTax.Text = MyUtils.FmtCurrency(WrkTax)
  WrkEstTax = MyUtils.Round((MyUtils.CnvSng(LblGross.Text) - MyUtils.CnvSng(LblExempt.Text)) * WrkMillRate, 2)
  LblTax.Text = MyUtils.FmtCurrency(WrkEstTax)

  CalcLocal()
End Sub

 Private Sub BtnRemoveEld_Click(sender As Object, e As EventArgs) Handles BtnRemoveEld.Click
    Dim Answer As Integer
    Answer = MsgBox("WARNING: CLEARING elderly data for this account. Note that current or renewal year M35H record(s)" & _
     " should be changed to disallowed.", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirm Elderly removal")
    If Answer = MsgBoxResult.Cancel Then Exit Sub

    LblEldPgm.Text = "N/A"
    TxtEldYear.Text = ""
    LblEldPerc.Text = ""
    LblEldMax.Text = ""
    LblEldMin.Text = ""
    LblEldTax.Text = ""
    LblEldAdj.Text = ""
    UpdateTXREAL()
    CalcLocal()
End Sub
 End Class






