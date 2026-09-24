Public Class FrmTO206B
Inherits System.Windows.Forms.Form
Dim MyTXDIST As TXDIST.myData
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
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents ChkFrozenFile As System.Windows.Forms.CheckBox
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents TxtMillRateDay As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents TxtMillRateMonth As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents TxtMillRateAuthority As System.Windows.Forms.TextBox
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents ChkDetail As System.Windows.Forms.CheckBox
Friend WithEvents Label9 As System.Windows.Forms.Label
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbMunCity As System.Windows.Forms.RadioButton
Friend WithEvents RbMunBur As System.Windows.Forms.RadioButton
Friend WithEvents RbMunTown As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents RbCollElect As System.Windows.Forms.RadioButton
Friend WithEvents RbCollApp As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
Friend WithEvents Label10 As System.Windows.Forms.Label
Friend WithEvents ChkCreditCard As System.Windows.Forms.CheckBox
Friend WithEvents TxtCollected As System.Windows.Forms.TextBox
Friend WithEvents ChkCreditAll As System.Windows.Forms.CheckBox
Friend WithEvents ChkLiens As System.Windows.Forms.CheckBox
Friend WithEvents LnkDist As System.Windows.Forms.LinkLabel
Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
Friend WithEvents RbDistLighting As System.Windows.Forms.RadioButton
Friend WithEvents RbDistSewer As System.Windows.Forms.RadioButton
Friend WithEvents RbDistFire As System.Windows.Forms.RadioButton
Friend WithEvents RbDistImprovement As System.Windows.Forms.RadioButton
Friend WithEvents RbDistVillage As System.Windows.Forms.RadioButton
Friend WithEvents RbDistBeach As System.Windows.Forms.RadioButton
Friend WithEvents TxtDistOther As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents Label11 As System.Windows.Forms.Label
Friend WithEvents TxtCreditRestrict As System.Windows.Forms.TextBox
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTO206B))
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.ChkFrozenFile = New System.Windows.Forms.CheckBox()
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtMillRateAuthority = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtMillRateMonth = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtMillRateDay = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.ChkDetail = New System.Windows.Forms.CheckBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbMunCity = New System.Windows.Forms.RadioButton()
    Me.RbMunBur = New System.Windows.Forms.RadioButton()
    Me.RbMunTown = New System.Windows.Forms.RadioButton()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.RbCollElect = New System.Windows.Forms.RadioButton()
    Me.RbCollApp = New System.Windows.Forms.RadioButton()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.ChkLiens = New System.Windows.Forms.CheckBox()
    Me.ChkCreditAll = New System.Windows.Forms.CheckBox()
    Me.TxtCollected = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.ChkCreditCard = New System.Windows.Forms.CheckBox()
    Me.LnkDist = New System.Windows.Forms.LinkLabel()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.RbDistLighting = New System.Windows.Forms.RadioButton()
    Me.RbDistSewer = New System.Windows.Forms.RadioButton()
    Me.RbDistFire = New System.Windows.Forms.RadioButton()
    Me.RbDistBeach = New System.Windows.Forms.RadioButton()
    Me.RbDistVillage = New System.Windows.Forms.RadioButton()
    Me.RbDistImprovement = New System.Windows.Forms.RadioButton()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtDistOther = New System.Windows.Forms.TextBox()
    Me.TxtCreditRestrict = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.SuspendLayout()
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(113, 43)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(28, 20)
    Me.TxtDist.TabIndex = 51
    '
    'ChkFrozenFile
    '
    Me.ChkFrozenFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkFrozenFile.Checked = True
    Me.ChkFrozenFile.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkFrozenFile.Location = New System.Drawing.Point(28, 69)
    Me.ChkFrozenFile.Name = "ChkFrozenFile"
    Me.ChkFrozenFile.Size = New System.Drawing.Size(117, 16)
    Me.ChkFrozenFile.TabIndex = 55
    Me.ChkFrozenFile.Text = "Use Frozen List?"
    '
    'TxtGLYear
    '
    Me.TxtGLYear.Location = New System.Drawing.Point(113, 19)
    Me.TxtGLYear.MaxLength = 4
    Me.TxtGLYear.Name = "TxtGLYear"
    Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtGLYear.TabIndex = 50
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(25, 19)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(84, 16)
    Me.Label4.TabIndex = 56
    Me.Label4.Text = "Grand List Year"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.Label8)
    Me.GroupBox1.Controls.Add(Me.TxtMillRateAuthority)
    Me.GroupBox1.Controls.Add(Me.Label7)
    Me.GroupBox1.Controls.Add(Me.Label6)
    Me.GroupBox1.Controls.Add(Me.Label5)
    Me.GroupBox1.Controls.Add(Me.TxtMillRateMonth)
    Me.GroupBox1.Controls.Add(Me.Label3)
    Me.GroupBox1.Controls.Add(Me.TxtMillRateDay)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Location = New System.Drawing.Point(12, 226)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(443, 83)
    Me.GroupBox1.TabIndex = 58
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Part II - Mill Rates (s)"
    '
    'Label8
    '
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(322, 59)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(117, 20)
    Me.Label8.TabIndex = 66
    Me.Label8.Text = "(IE: Board of Finance)"
    '
    'TxtMillRateAuthority
    '
    Me.TxtMillRateAuthority.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMillRateAuthority.Location = New System.Drawing.Point(147, 59)
    Me.TxtMillRateAuthority.MaxLength = 20
    Me.TxtMillRateAuthority.Name = "TxtMillRateAuthority"
    Me.TxtMillRateAuthority.Size = New System.Drawing.Size(175, 20)
    Me.TxtMillRateAuthority.TabIndex = 65
    '
    'Label7
    '
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(6, 64)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(123, 16)
    Me.Label7.TabIndex = 64
    Me.Label7.Text = "Name of Authority"
    '
    'Label6
    '
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(230, 39)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(55, 17)
    Me.Label6.TabIndex = 63
    Me.Label6.Text = "(IE: May)"
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(194, 13)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(55, 11)
    Me.Label5.TabIndex = 62
    Me.Label5.Text = "(IE: 13th)"
    '
    'TxtMillRateMonth
    '
    Me.TxtMillRateMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMillRateMonth.Location = New System.Drawing.Point(147, 36)
    Me.TxtMillRateMonth.MaxLength = 10
    Me.TxtMillRateMonth.Name = "TxtMillRateMonth"
    Me.TxtMillRateMonth.Size = New System.Drawing.Size(77, 20)
    Me.TxtMillRateMonth.TabIndex = 61
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(6, 39)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(135, 17)
    Me.Label3.TabIndex = 60
    Me.Label3.Text = "Month Mill Rate was set"
    '
    'TxtMillRateDay
    '
    Me.TxtMillRateDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMillRateDay.Location = New System.Drawing.Point(147, 10)
    Me.TxtMillRateDay.MaxLength = 4
    Me.TxtMillRateDay.Name = "TxtMillRateDay"
    Me.TxtMillRateDay.Size = New System.Drawing.Size(41, 20)
    Me.TxtMillRateDay.TabIndex = 58
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(6, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(123, 14)
    Me.Label2.TabIndex = 59
    Me.Label2.Text = "Day Mill Rate was set"
    '
    'ChkDetail
    '
    Me.ChkDetail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkDetail.Location = New System.Drawing.Point(28, 91)
    Me.ChkDetail.Name = "ChkDetail"
    Me.ChkDetail.Size = New System.Drawing.Size(117, 16)
    Me.ChkDetail.TabIndex = 59
    Me.ChkDetail.Text = "Print Detail list?"
    '
    'Label9
    '
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(156, 92)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(118, 15)
    Me.Label9.TabIndex = 60
    Me.Label9.Text = "(Not needed by OPM)"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbMunCity)
    Me.GroupBox2.Controls.Add(Me.RbMunBur)
    Me.GroupBox2.Controls.Add(Me.RbMunTown)
    Me.GroupBox2.Location = New System.Drawing.Point(12, 113)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(233, 41)
    Me.GroupBox2.TabIndex = 61
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Type of Muncipality"
    '
    'RbMunCity
    '
    Me.RbMunCity.AutoSize = True
    Me.RbMunCity.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbMunCity.Location = New System.Drawing.Point(177, 18)
    Me.RbMunCity.Name = "RbMunCity"
    Me.RbMunCity.Size = New System.Drawing.Size(42, 17)
    Me.RbMunCity.TabIndex = 69
    Me.RbMunCity.TabStop = True
    Me.RbMunCity.Text = "City"
    Me.RbMunCity.UseVisualStyleBackColor = True
    '
    'RbMunBur
    '
    Me.RbMunBur.AutoSize = True
    Me.RbMunBur.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbMunBur.Location = New System.Drawing.Point(91, 18)
    Me.RbMunBur.Name = "RbMunBur"
    Me.RbMunBur.Size = New System.Drawing.Size(65, 17)
    Me.RbMunBur.TabIndex = 68
    Me.RbMunBur.TabStop = True
    Me.RbMunBur.Text = "Burough"
    Me.RbMunBur.UseVisualStyleBackColor = True
    '
    'RbMunTown
    '
    Me.RbMunTown.AutoSize = True
    Me.RbMunTown.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbMunTown.Location = New System.Drawing.Point(16, 18)
    Me.RbMunTown.Name = "RbMunTown"
    Me.RbMunTown.Size = New System.Drawing.Size(52, 17)
    Me.RbMunTown.TabIndex = 67
    Me.RbMunTown.TabStop = True
    Me.RbMunTown.Text = "Town"
    Me.RbMunTown.UseVisualStyleBackColor = True
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.RbCollElect)
    Me.GroupBox3.Controls.Add(Me.RbCollApp)
    Me.GroupBox3.Location = New System.Drawing.Point(251, 113)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(204, 41)
    Me.GroupBox3.TabIndex = 70
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Collector"
    '
    'RbCollElect
    '
    Me.RbCollElect.AutoSize = True
    Me.RbCollElect.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbCollElect.Location = New System.Drawing.Point(118, 19)
    Me.RbCollElect.Name = "RbCollElect"
    Me.RbCollElect.Size = New System.Drawing.Size(61, 17)
    Me.RbCollElect.TabIndex = 68
    Me.RbCollElect.TabStop = True
    Me.RbCollElect.Text = "Elected"
    Me.RbCollElect.UseVisualStyleBackColor = True
    '
    'RbCollApp
    '
    Me.RbCollApp.AutoSize = True
    Me.RbCollApp.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbCollApp.Location = New System.Drawing.Point(10, 19)
    Me.RbCollApp.Name = "RbCollApp"
    Me.RbCollApp.Size = New System.Drawing.Size(73, 17)
    Me.RbCollApp.TabIndex = 67
    Me.RbCollApp.TabStop = True
    Me.RbCollApp.Text = "Appointed"
    Me.RbCollApp.UseVisualStyleBackColor = True
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.Label11)
    Me.GroupBox4.Controls.Add(Me.TxtCreditRestrict)
    Me.GroupBox4.Controls.Add(Me.ChkLiens)
    Me.GroupBox4.Controls.Add(Me.ChkCreditAll)
    Me.GroupBox4.Controls.Add(Me.TxtCollected)
    Me.GroupBox4.Controls.Add(Me.Label10)
    Me.GroupBox4.Controls.Add(Me.ChkCreditCard)
    Me.GroupBox4.Location = New System.Drawing.Point(12, 315)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(443, 160)
    Me.GroupBox4.TabIndex = 72
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Part IV - Collection Statistics"
    '
    'ChkLiens
    '
    Me.ChkLiens.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkLiens.Location = New System.Drawing.Point(16, 110)
    Me.ChkLiens.Name = "ChkLiens"
    Me.ChkLiens.Size = New System.Drawing.Size(269, 33)
    Me.ChkLiens.TabIndex = 76
    Me.ChkLiens.Text = "5. Did the municipality provide for the assignment of tax liens in accordance wit" & _
    "h §12-195h C.G.S.?"
    Me.ChkLiens.UseVisualStyleBackColor = True
    '
    'ChkCreditAll
    '
    Me.ChkCreditAll.AutoSize = True
    Me.ChkCreditAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkCreditAll.Location = New System.Drawing.Point(16, 69)
    Me.ChkCreditAll.Name = "ChkCreditAll"
    Me.ChkCreditAll.Size = New System.Drawing.Size(223, 17)
    Me.ChkCreditAll.TabIndex = 75
    Me.ChkCreditAll.Text = "3. May a credit card be used for all taxes?"
    Me.ChkCreditAll.UseVisualStyleBackColor = True
    '
    'TxtCollected
    '
    Me.TxtCollected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCollected.Location = New System.Drawing.Point(291, 45)
    Me.TxtCollected.MaxLength = 10
    Me.TxtCollected.Name = "TxtCollected"
    Me.TxtCollected.Size = New System.Drawing.Size(94, 20)
    Me.TxtCollected.TabIndex = 74
    '
    'Label10
    '
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(19, 48)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(285, 18)
    Me.Label10.TabIndex = 73
    Me.Label10.Text = "2. If yes, please enter the Fiscal Year Amount Collected"
    '
    'ChkCreditCard
    '
    Me.ChkCreditCard.AutoSize = True
    Me.ChkCreditCard.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkCreditCard.Location = New System.Drawing.Point(16, 19)
    Me.ChkCreditCard.Name = "ChkCreditCard"
    Me.ChkCreditCard.Size = New System.Drawing.Size(311, 17)
    Me.ChkCreditCard.TabIndex = 72
    Me.ChkCreditCard.Text = "1. Does your municipality provide for credit card collections? "
    Me.ChkCreditCard.UseVisualStyleBackColor = True
    '
    'LnkDist
    '
    Me.LnkDist.Location = New System.Drawing.Point(27, 46)
    Me.LnkDist.Name = "LnkDist"
    Me.LnkDist.Size = New System.Drawing.Size(80, 16)
    Me.LnkDist.TabIndex = 73
    Me.LnkDist.TabStop = True
    Me.LnkDist.Text = "District"
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.TxtDistOther)
    Me.GroupBox5.Controls.Add(Me.Label1)
    Me.GroupBox5.Controls.Add(Me.RbDistImprovement)
    Me.GroupBox5.Controls.Add(Me.RbDistVillage)
    Me.GroupBox5.Controls.Add(Me.RbDistBeach)
    Me.GroupBox5.Controls.Add(Me.RbDistLighting)
    Me.GroupBox5.Controls.Add(Me.RbDistSewer)
    Me.GroupBox5.Controls.Add(Me.RbDistFire)
    Me.GroupBox5.Location = New System.Drawing.Point(12, 160)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(443, 60)
    Me.GroupBox5.TabIndex = 74
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "Type of District"
    '
    'RbDistLighting
    '
    Me.RbDistLighting.AutoSize = True
    Me.RbDistLighting.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbDistLighting.Location = New System.Drawing.Point(177, 18)
    Me.RbDistLighting.Name = "RbDistLighting"
    Me.RbDistLighting.Size = New System.Drawing.Size(62, 17)
    Me.RbDistLighting.TabIndex = 69
    Me.RbDistLighting.TabStop = True
    Me.RbDistLighting.Text = "Lighting"
    Me.RbDistLighting.UseVisualStyleBackColor = True
    '
    'RbDistSewer
    '
    Me.RbDistSewer.AutoSize = True
    Me.RbDistSewer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbDistSewer.Location = New System.Drawing.Point(91, 18)
    Me.RbDistSewer.Name = "RbDistSewer"
    Me.RbDistSewer.Size = New System.Drawing.Size(55, 17)
    Me.RbDistSewer.TabIndex = 68
    Me.RbDistSewer.TabStop = True
    Me.RbDistSewer.Text = "Sewer"
    Me.RbDistSewer.UseVisualStyleBackColor = True
    '
    'RbDistFire
    '
    Me.RbDistFire.AutoSize = True
    Me.RbDistFire.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbDistFire.Location = New System.Drawing.Point(16, 18)
    Me.RbDistFire.Name = "RbDistFire"
    Me.RbDistFire.Size = New System.Drawing.Size(42, 17)
    Me.RbDistFire.TabIndex = 67
    Me.RbDistFire.TabStop = True
    Me.RbDistFire.Text = "Fire"
    Me.RbDistFire.UseVisualStyleBackColor = True
    '
    'RbDistBeach
    '
    Me.RbDistBeach.AutoSize = True
    Me.RbDistBeach.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbDistBeach.Location = New System.Drawing.Point(16, 37)
    Me.RbDistBeach.Name = "RbDistBeach"
    Me.RbDistBeach.Size = New System.Drawing.Size(56, 17)
    Me.RbDistBeach.TabIndex = 70
    Me.RbDistBeach.TabStop = True
    Me.RbDistBeach.Text = "Beach"
    Me.RbDistBeach.UseVisualStyleBackColor = True
    '
    'RbDistVillage
    '
    Me.RbDistVillage.AutoSize = True
    Me.RbDistVillage.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbDistVillage.Location = New System.Drawing.Point(262, 18)
    Me.RbDistVillage.Name = "RbDistVillage"
    Me.RbDistVillage.Size = New System.Drawing.Size(56, 17)
    Me.RbDistVillage.TabIndex = 71
    Me.RbDistVillage.TabStop = True
    Me.RbDistVillage.Text = "Village"
    Me.RbDistVillage.UseVisualStyleBackColor = True
    '
    'RbDistImprovement
    '
    Me.RbDistImprovement.AutoSize = True
    Me.RbDistImprovement.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbDistImprovement.Location = New System.Drawing.Point(91, 37)
    Me.RbDistImprovement.Name = "RbDistImprovement"
    Me.RbDistImprovement.Size = New System.Drawing.Size(86, 17)
    Me.RbDistImprovement.TabIndex = 72
    Me.RbDistImprovement.TabStop = True
    Me.RbDistImprovement.Text = "Improvement"
    Me.RbDistImprovement.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(201, 39)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(38, 17)
    Me.Label1.TabIndex = 76
    Me.Label1.Text = "Other:"
    '
    'TxtDistOther
    '
    Me.TxtDistOther.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDistOther.Location = New System.Drawing.Point(239, 36)
    Me.TxtDistOther.MaxLength = 4
    Me.TxtDistOther.Name = "TxtDistOther"
    Me.TxtDistOther.Size = New System.Drawing.Size(95, 20)
    Me.TxtDistOther.TabIndex = 77
    '
    'TxtCreditRestrict
    '
    Me.TxtCreditRestrict.Location = New System.Drawing.Point(186, 88)
    Me.TxtCreditRestrict.Name = "TxtCreditRestrict"
    Me.TxtCreditRestrict.Size = New System.Drawing.Size(251, 20)
    Me.TxtCreditRestrict.TabIndex = 77
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(16, 91)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(164, 13)
    Me.Label11.TabIndex = 78
    Me.Label11.Text = "4. If no, what are the restrictions?"
    '
    'FrmTO206B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(466, 487)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox5)
    Me.Controls.Add(Me.LnkDist)
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.ChkDetail)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.ChkFrozenFile)
    Me.Controls.Add(Me.TxtGLYear)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTO206B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

  Public Sub RunReport()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    MyTXDIST = New TXDIST.mydata(MyDBConnect)

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmTO206B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  SetGLYear()
End Sub
Private Sub FrmTO206B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTO206.SbpScreen.Text = "TO206B"
End Sub
Private Sub FrmTO206B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLYear, "")
    ErrProv.SetError(TxtDist, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "glyear"
        ErrProv.SetError(TxtGLYear, ErrorMsg(I))
      Case "dist"
        ErrProv.SetError(TxtDist, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtGLYear.Text) = 0 Then
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "Grand List Year is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtDist.Text) <> 0 Then
      MyTXDIST.GetOneRecordP(MyUtils.CnvSng(TxtDist.Text))
      If MyTXDIST.RecordNotFound Then
        ErrorField(I) = "dist"
        ErrorMsg(I) = "Invalid District"
        I = I + 1
      End If
    End If


  End Sub
Private Sub LnkDistrict_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
  MyFrmListDist = New FrmListDist
  MyFrmListDist.MdiParent = Me.ParentForm
  MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
  MyFrmListDist.Show()
  Me.Hide()
End Sub
Private Sub LnkDist_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkDist.LinkClicked
  MyFrmListDist = New FrmListDist
  MyFrmListDist.MdiParent = Me.ParentForm
  MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
  MyFrmListDist.Show()
  Me.Hide()
End Sub
Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub SetGLYear()
    Dim WrkYear As Integer

    WrkYear = Date.Now.Year
    If Date.Now.Month < 10 Then
      WrkYear = WrkYear - 1
    End If
    TxtGLYear.Text = WrkYear
End Sub
End Class






