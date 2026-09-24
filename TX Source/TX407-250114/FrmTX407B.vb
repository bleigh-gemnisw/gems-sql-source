Public Class FrmTX407B
Inherits System.Windows.Forms.Form

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
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
Friend WithEvents ChkMass As System.Windows.Forms.CheckBox
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
Friend WithEvents Label9 As System.Windows.Forms.Label
Friend WithEvents Label10 As System.Windows.Forms.Label
Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
Friend WithEvents Label11 As System.Windows.Forms.Label
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
Friend WithEvents Label12 As System.Windows.Forms.Label
Friend WithEvents Label13 As System.Windows.Forms.Label
Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
Friend WithEvents Label14 As System.Windows.Forms.Label
Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
Friend WithEvents Label15 As System.Windows.Forms.Label
Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
Friend WithEvents TpFiles As System.Windows.Forms.TabPage
Friend WithEvents GrpMiss As System.Windows.Forms.GroupBox
Friend WithEvents LnkMissPath As System.Windows.Forms.LinkLabel
Friend WithEvents LblMissPath As System.Windows.Forms.Label
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents GrpDMV As System.Windows.Forms.GroupBox
Friend WithEvents LblFilePath As System.Windows.Forms.Label
Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
Friend WithEvents TpDetail As System.Windows.Forms.TabPage
Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
Friend WithEvents LblProcess As System.Windows.Forms.Label
Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
Friend WithEvents TpPutOns As System.Windows.Forms.TabPage
Friend WithEvents GrpSorting As System.Windows.Forms.GroupBox
Friend WithEvents RbBoth As System.Windows.Forms.RadioButton
Friend WithEvents RbMV As System.Windows.Forms.RadioButton
Friend WithEvents RbSU As System.Windows.Forms.RadioButton
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtGLYearTo As System.Windows.Forms.TextBox
Friend WithEvents TxtGLYearFrom As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TpSinglePutOn As System.Windows.Forms.TabPage
Friend WithEvents LblPutMsg As System.Windows.Forms.Label
Friend WithEvents TxtPutDMVCustID As System.Windows.Forms.TextBox
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents TpTakeOffs As System.Windows.Forms.TabPage
Friend WithEvents TpSingleTakeOff As System.Windows.Forms.TabPage
Friend WithEvents LblTakeMsg As System.Windows.Forms.Label
Friend WithEvents TxtTakeDMVCustID As System.Windows.Forms.TextBox
Friend WithEvents Label16 As System.Windows.Forms.Label
Friend WithEvents TpCustID As System.Windows.Forms.TabPage
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TxtCustYearTo As System.Windows.Forms.TextBox
Friend WithEvents TxtCustYearFrom As System.Windows.Forms.TextBox
Friend WithEvents Label17 As System.Windows.Forms.Label
Friend WithEvents TpSync As System.Windows.Forms.TabPage
Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
Friend WithEvents LnkSyncPath As System.Windows.Forms.LinkLabel
Friend WithEvents LblSyncPath As System.Windows.Forms.Label
Friend WithEvents GrpSuspense As System.Windows.Forms.GroupBox
Friend WithEvents TxtReason10 As System.Windows.Forms.TextBox
Friend WithEvents TxtReason9 As System.Windows.Forms.TextBox
Friend WithEvents LnkReason10 As System.Windows.Forms.LinkLabel
Friend WithEvents LnkReason9 As System.Windows.Forms.LinkLabel
Friend WithEvents TxtReason8 As System.Windows.Forms.TextBox
Friend WithEvents TxtReason7 As System.Windows.Forms.TextBox
Friend WithEvents TxtReason6 As System.Windows.Forms.TextBox
Friend WithEvents TxtReason5 As System.Windows.Forms.TextBox
Friend WithEvents TxtReason4 As System.Windows.Forms.TextBox
Friend WithEvents TxtReason3 As System.Windows.Forms.TextBox
Friend WithEvents LnkReason8 As System.Windows.Forms.LinkLabel
Friend WithEvents LnkReason7 As System.Windows.Forms.LinkLabel
Friend WithEvents LnkReason6 As System.Windows.Forms.LinkLabel
Friend WithEvents LnkReason5 As System.Windows.Forms.LinkLabel
Friend WithEvents LnkReason4 As System.Windows.Forms.LinkLabel
Friend WithEvents LnkReason3 As System.Windows.Forms.LinkLabel
Friend WithEvents LnkReason2 As System.Windows.Forms.LinkLabel
Friend WithEvents TxtReason2 As System.Windows.Forms.TextBox
Friend WithEvents TxtReason1 As System.Windows.Forms.TextBox
Friend WithEvents LnkReason1 As System.Windows.Forms.LinkLabel
Friend WithEvents TxtDaysCredit As System.Windows.Forms.TextBox
Friend WithEvents Label18 As System.Windows.Forms.Label
Friend WithEvents TxtDaysCheck As System.Windows.Forms.TextBox
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbCustBoth As System.Windows.Forms.RadioButton
Friend WithEvents RbCustMV As System.Windows.Forms.RadioButton
Friend WithEvents RbCustSU As System.Windows.Forms.RadioButton
  Friend WithEvents TxtDaysECheck As TextBox
  Friend WithEvents Label19 As Label
  Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTX407B))
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.ChkMass = New System.Windows.Forms.CheckBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RadioButton1 = New System.Windows.Forms.RadioButton()
    Me.RadioButton2 = New System.Windows.Forms.RadioButton()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TextBox3 = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.RadioButton3 = New System.Windows.Forms.RadioButton()
    Me.RadioButton4 = New System.Windows.Forms.RadioButton()
    Me.TextBox4 = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.TextBox5 = New System.Windows.Forms.TextBox()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.RadioButton5 = New System.Windows.Forms.RadioButton()
    Me.RadioButton6 = New System.Windows.Forms.RadioButton()
    Me.TextBox6 = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.TabControl2 = New System.Windows.Forms.TabControl()
    Me.TpFiles = New System.Windows.Forms.TabPage()
    Me.GrpMiss = New System.Windows.Forms.GroupBox()
    Me.LnkMissPath = New System.Windows.Forms.LinkLabel()
    Me.LblMissPath = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GrpDMV = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.TpDetail = New System.Windows.Forms.TabPage()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.LblProcess = New System.Windows.Forms.Label()
    Me.TpSync = New System.Windows.Forms.TabPage()
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.LnkSyncPath = New System.Windows.Forms.LinkLabel()
    Me.LblSyncPath = New System.Windows.Forms.Label()
    Me.TpCustID = New System.Windows.Forms.TabPage()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbCustBoth = New System.Windows.Forms.RadioButton()
    Me.RbCustMV = New System.Windows.Forms.RadioButton()
    Me.RbCustSU = New System.Windows.Forms.RadioButton()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtCustYearTo = New System.Windows.Forms.TextBox()
    Me.TxtCustYearFrom = New System.Windows.Forms.TextBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.TpSingleTakeOff = New System.Windows.Forms.TabPage()
    Me.LblTakeMsg = New System.Windows.Forms.Label()
    Me.TxtTakeDMVCustID = New System.Windows.Forms.TextBox()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.TpTakeOffs = New System.Windows.Forms.TabPage()
    Me.TxtDaysCredit = New System.Windows.Forms.TextBox()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.TxtDaysCheck = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TpSinglePutOn = New System.Windows.Forms.TabPage()
    Me.LblPutMsg = New System.Windows.Forms.Label()
    Me.TxtPutDMVCustID = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TpPutOns = New System.Windows.Forms.TabPage()
    Me.GrpSorting = New System.Windows.Forms.GroupBox()
    Me.RbBoth = New System.Windows.Forms.RadioButton()
    Me.RbMV = New System.Windows.Forms.RadioButton()
    Me.RbSU = New System.Windows.Forms.RadioButton()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtGLYearTo = New System.Windows.Forms.TextBox()
    Me.TxtGLYearFrom = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.GrpSuspense = New System.Windows.Forms.GroupBox()
    Me.TxtReason10 = New System.Windows.Forms.TextBox()
    Me.TxtReason9 = New System.Windows.Forms.TextBox()
    Me.LnkReason10 = New System.Windows.Forms.LinkLabel()
    Me.LnkReason9 = New System.Windows.Forms.LinkLabel()
    Me.TxtReason8 = New System.Windows.Forms.TextBox()
    Me.TxtReason7 = New System.Windows.Forms.TextBox()
    Me.TxtReason6 = New System.Windows.Forms.TextBox()
    Me.TxtReason5 = New System.Windows.Forms.TextBox()
    Me.TxtReason4 = New System.Windows.Forms.TextBox()
    Me.TxtReason3 = New System.Windows.Forms.TextBox()
    Me.LnkReason8 = New System.Windows.Forms.LinkLabel()
    Me.LnkReason7 = New System.Windows.Forms.LinkLabel()
    Me.LnkReason6 = New System.Windows.Forms.LinkLabel()
    Me.LnkReason5 = New System.Windows.Forms.LinkLabel()
    Me.LnkReason4 = New System.Windows.Forms.LinkLabel()
    Me.LnkReason3 = New System.Windows.Forms.LinkLabel()
    Me.LnkReason2 = New System.Windows.Forms.LinkLabel()
    Me.TxtReason2 = New System.Windows.Forms.TextBox()
    Me.TxtReason1 = New System.Windows.Forms.TextBox()
    Me.LnkReason1 = New System.Windows.Forms.LinkLabel()
    Me.TxtDaysECheck = New System.Windows.Forms.TextBox()
    Me.Label19 = New System.Windows.Forms.Label()
    CType(Me.ErrProv,System.ComponentModel.ISupportInitialize).BeginInit
    Me.GroupBox1.SuspendLayout
    Me.GroupBox3.SuspendLayout
    Me.GroupBox4.SuspendLayout
    Me.TabControl2.SuspendLayout
    Me.TpFiles.SuspendLayout
    Me.GrpMiss.SuspendLayout
    Me.GrpDMV.SuspendLayout
    Me.TpDetail.SuspendLayout
    CType(Me.C1DataGrdList,System.ComponentModel.ISupportInitialize).BeginInit
    Me.TpSync.SuspendLayout
    Me.GroupBox6.SuspendLayout
    Me.TpCustID.SuspendLayout
    Me.GroupBox2.SuspendLayout
    Me.TpSingleTakeOff.SuspendLayout
    Me.TpTakeOffs.SuspendLayout
    Me.TpSinglePutOn.SuspendLayout
    Me.TpPutOns.SuspendLayout
    Me.GrpSorting.SuspendLayout
    Me.TabControl1.SuspendLayout
    Me.GrpSuspense.SuspendLayout
    Me.SuspendLayout
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'ChkPost
    '
    Me.ChkPost.AutoSize = true
    Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPost.Location = New System.Drawing.Point(13, 217)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(95, 17)
    Me.ChkPost.TabIndex = 6
    Me.ChkPost.Text = "Post MV Flag?"
    '
    'ChkMass
    '
    Me.ChkMass.AutoSize = true
    Me.ChkMass.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkMass.Location = New System.Drawing.Point(123, 217)
    Me.ChkMass.Name = "ChkMass"
    Me.ChkMass.Size = New System.Drawing.Size(88, 17)
    Me.ChkMass.TabIndex = 7
    Me.ChkMass.Text = "Mass Puton?"
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(22, 83)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(84, 16)
    Me.Label7.TabIndex = 77
    Me.Label7.Text = "<Message>"
    '
    'TextBox1
    '
    Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TextBox1.Location = New System.Drawing.Point(112, 28)
    Me.TextBox1.MaxLength = 6
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(44, 20)
    Me.TextBox1.TabIndex = 0
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(24, 32)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(82, 20)
    Me.Label8.TabIndex = 76
    Me.Label8.Text = "List No"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RadioButton1)
    Me.GroupBox1.Controls.Add(Me.RadioButton2)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(184, 15)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(128, 59)
    Me.GroupBox1.TabIndex = 2
    Me.GroupBox1.TabStop = false
    Me.GroupBox1.Text = "Tax Type"
    '
    'RadioButton1
    '
    Me.RadioButton1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RadioButton1.Checked = true
    Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.RadioButton1.Location = New System.Drawing.Point(12, 16)
    Me.RadioButton1.Name = "RadioButton1"
    Me.RadioButton1.Size = New System.Drawing.Size(108, 20)
    Me.RadioButton1.TabIndex = 0
    Me.RadioButton1.TabStop = true
    Me.RadioButton1.Text = "Motor Vehicle"
    '
    'RadioButton2
    '
    Me.RadioButton2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.RadioButton2.Location = New System.Drawing.Point(12, 36)
    Me.RadioButton2.Name = "RadioButton2"
    Me.RadioButton2.Size = New System.Drawing.Size(108, 20)
    Me.RadioButton2.TabIndex = 1
    Me.RadioButton2.Text = "Suppl. MV"
    '
    'TextBox2
    '
    Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TextBox2.Location = New System.Drawing.Point(112, 54)
    Me.TextBox2.MaxLength = 4
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(32, 20)
    Me.TextBox2.TabIndex = 1
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(24, 58)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(84, 16)
    Me.Label9.TabIndex = 73
    Me.Label9.Text = "Grand List Year"
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(22, 83)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(84, 16)
    Me.Label10.TabIndex = 77
    Me.Label10.Text = "<Message>"
    '
    'TextBox3
    '
    Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TextBox3.Location = New System.Drawing.Point(112, 28)
    Me.TextBox3.MaxLength = 6
    Me.TextBox3.Name = "TextBox3"
    Me.TextBox3.Size = New System.Drawing.Size(44, 20)
    Me.TextBox3.TabIndex = 0
    '
    'Label11
    '
    Me.Label11.Location = New System.Drawing.Point(24, 32)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(82, 20)
    Me.Label11.TabIndex = 76
    Me.Label11.Text = "List No"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.RadioButton3)
    Me.GroupBox3.Controls.Add(Me.RadioButton4)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(184, 15)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(128, 59)
    Me.GroupBox3.TabIndex = 2
    Me.GroupBox3.TabStop = false
    Me.GroupBox3.Text = "Tax Type"
    '
    'RadioButton3
    '
    Me.RadioButton3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RadioButton3.Checked = true
    Me.RadioButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.RadioButton3.Location = New System.Drawing.Point(12, 16)
    Me.RadioButton3.Name = "RadioButton3"
    Me.RadioButton3.Size = New System.Drawing.Size(108, 20)
    Me.RadioButton3.TabIndex = 0
    Me.RadioButton3.TabStop = true
    Me.RadioButton3.Text = "Motor Vehicle"
    '
    'RadioButton4
    '
    Me.RadioButton4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RadioButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.RadioButton4.Location = New System.Drawing.Point(12, 36)
    Me.RadioButton4.Name = "RadioButton4"
    Me.RadioButton4.Size = New System.Drawing.Size(108, 20)
    Me.RadioButton4.TabIndex = 1
    Me.RadioButton4.Text = "Suppl. MV"
    '
    'TextBox4
    '
    Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TextBox4.Location = New System.Drawing.Point(112, 54)
    Me.TextBox4.MaxLength = 4
    Me.TextBox4.Name = "TextBox4"
    Me.TextBox4.Size = New System.Drawing.Size(32, 20)
    Me.TextBox4.TabIndex = 1
    '
    'Label12
    '
    Me.Label12.Location = New System.Drawing.Point(24, 58)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(84, 16)
    Me.Label12.TabIndex = 73
    Me.Label12.Text = "Grand List Year"
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(22, 83)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(84, 16)
    Me.Label13.TabIndex = 77
    Me.Label13.Text = "<Message>"
    '
    'TextBox5
    '
    Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TextBox5.Location = New System.Drawing.Point(112, 28)
    Me.TextBox5.MaxLength = 6
    Me.TextBox5.Name = "TextBox5"
    Me.TextBox5.Size = New System.Drawing.Size(44, 20)
    Me.TextBox5.TabIndex = 0
    '
    'Label14
    '
    Me.Label14.Location = New System.Drawing.Point(24, 32)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(82, 20)
    Me.Label14.TabIndex = 76
    Me.Label14.Text = "List No"
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.RadioButton5)
    Me.GroupBox4.Controls.Add(Me.RadioButton6)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(184, 15)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(128, 59)
    Me.GroupBox4.TabIndex = 2
    Me.GroupBox4.TabStop = false
    Me.GroupBox4.Text = "Tax Type"
    '
    'RadioButton5
    '
    Me.RadioButton5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RadioButton5.Checked = true
    Me.RadioButton5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.RadioButton5.Location = New System.Drawing.Point(12, 16)
    Me.RadioButton5.Name = "RadioButton5"
    Me.RadioButton5.Size = New System.Drawing.Size(108, 20)
    Me.RadioButton5.TabIndex = 0
    Me.RadioButton5.TabStop = true
    Me.RadioButton5.Text = "Motor Vehicle"
    '
    'RadioButton6
    '
    Me.RadioButton6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RadioButton6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.RadioButton6.Location = New System.Drawing.Point(12, 36)
    Me.RadioButton6.Name = "RadioButton6"
    Me.RadioButton6.Size = New System.Drawing.Size(108, 20)
    Me.RadioButton6.TabIndex = 1
    Me.RadioButton6.Text = "Suppl. MV"
    '
    'TextBox6
    '
    Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TextBox6.Location = New System.Drawing.Point(112, 54)
    Me.TextBox6.MaxLength = 4
    Me.TextBox6.Name = "TextBox6"
    Me.TextBox6.Size = New System.Drawing.Size(32, 20)
    Me.TextBox6.TabIndex = 1
    '
    'Label15
    '
    Me.Label15.Location = New System.Drawing.Point(24, 58)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(84, 16)
    Me.Label15.TabIndex = 73
    Me.Label15.Text = "Grand List Year"
    '
    'TabControl2
    '
    Me.TabControl2.Controls.Add(Me.TpFiles)
    Me.TabControl2.Controls.Add(Me.TpDetail)
    Me.TabControl2.Location = New System.Drawing.Point(16, 240)
    Me.TabControl2.Name = "TabControl2"
    Me.TabControl2.SelectedIndex = 0
    Me.TabControl2.Size = New System.Drawing.Size(522, 187)
    Me.TabControl2.TabIndex = 11
    '
    'TpFiles
    '
    Me.TpFiles.Controls.Add(Me.GrpMiss)
    Me.TpFiles.Controls.Add(Me.Label1)
    Me.TpFiles.Controls.Add(Me.GrpDMV)
    Me.TpFiles.Location = New System.Drawing.Point(4, 22)
    Me.TpFiles.Name = "TpFiles"
    Me.TpFiles.Padding = New System.Windows.Forms.Padding(3)
    Me.TpFiles.Size = New System.Drawing.Size(514, 161)
    Me.TpFiles.TabIndex = 0
    Me.TpFiles.Text = "Files"
    Me.TpFiles.UseVisualStyleBackColor = true
    '
    'GrpMiss
    '
    Me.GrpMiss.Controls.Add(Me.LnkMissPath)
    Me.GrpMiss.Controls.Add(Me.LblMissPath)
    Me.GrpMiss.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.GrpMiss.Location = New System.Drawing.Point(8, 95)
    Me.GrpMiss.Name = "GrpMiss"
    Me.GrpMiss.Size = New System.Drawing.Size(408, 56)
    Me.GrpMiss.TabIndex = 13
    Me.GrpMiss.TabStop = false
    Me.GrpMiss.Text = "Missing ID "
    '
    'LnkMissPath
    '
    Me.LnkMissPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.LnkMissPath.Location = New System.Drawing.Point(12, 26)
    Me.LnkMissPath.Name = "LnkMissPath"
    Me.LnkMissPath.Size = New System.Drawing.Size(52, 16)
    Me.LnkMissPath.TabIndex = 68
    Me.LnkMissPath.TabStop = true
    Me.LnkMissPath.Text = "File Path"
    '
    'LblMissPath
    '
    Me.LblMissPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.LblMissPath.Location = New System.Drawing.Point(75, 16)
    Me.LblMissPath.Name = "LblMissPath"
    Me.LblMissPath.Size = New System.Drawing.Size(321, 36)
    Me.LblMissPath.TabIndex = 67
    '
    'Label1
    '
    Me.Label1.AutoSize = true
    Me.Label1.Location = New System.Drawing.Point(13, 65)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(495, 13)
    Me.Label1.TabIndex = 12
    Me.Label1.Text = "*DMV will only accept file named TC###DTyymmdd.txt where ### is town number and y"& _ 
    "ymmdd is date "
    '
    'GrpDMV
    '
    Me.GrpDMV.Controls.Add(Me.LblFilePath)
    Me.GrpDMV.Controls.Add(Me.LnkFilePath)
    Me.GrpDMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.GrpDMV.Location = New System.Drawing.Point(8, 6)
    Me.GrpDMV.Name = "GrpDMV"
    Me.GrpDMV.Size = New System.Drawing.Size(408, 56)
    Me.GrpDMV.TabIndex = 11
    Me.GrpDMV.TabStop = false
    Me.GrpDMV.Text = "DMV File Details*"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePath.Name = "LblFilePath"
    Me.LblFilePath.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePath.TabIndex = 67
    '
    'LnkFilePath
    '
    Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.LnkFilePath.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePath.Name = "LnkFilePath"
    Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath.TabIndex = 65
    Me.LnkFilePath.TabStop = true
    Me.LnkFilePath.Text = "File Path"
    '
    'TpDetail
    '
    Me.TpDetail.Controls.Add(Me.C1DataGrdList)
    Me.TpDetail.Location = New System.Drawing.Point(4, 22)
    Me.TpDetail.Name = "TpDetail"
    Me.TpDetail.Padding = New System.Windows.Forms.Padding(3)
    Me.TpDetail.Size = New System.Drawing.Size(514, 161)
    Me.TpDetail.TabIndex = 1
    Me.TpDetail.Text = "Detail"
    Me.TpDetail.UseVisualStyleBackColor = true
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowArrows = false
    Me.C1DataGrdList.AllowColMove = false
    Me.C1DataGrdList.AllowColSelect = false
    Me.C1DataGrdList.AllowRowSelect = false
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AllowUpdate = false
    Me.C1DataGrdList.AlternatingRows = true
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"),System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(6, 6)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"),System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    Me.C1DataGrdList.RecordSelectors = false
    Me.C1DataGrdList.Size = New System.Drawing.Size(502, 149)
    Me.C1DataGrdList.TabIndex = 199
    '
    'OpenFileDialog1
    '
    Me.OpenFileDialog1.FileName = "OpenFileDialog1"
    '
    'LblProcess
    '
    Me.LblProcess.AutoSize = true
    Me.LblProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.LblProcess.ForeColor = System.Drawing.Color.Blue
    Me.LblProcess.Location = New System.Drawing.Point(13, 5)
    Me.LblProcess.Name = "LblProcess"
    Me.LblProcess.Size = New System.Drawing.Size(80, 13)
    Me.LblProcess.TabIndex = 8
    Me.LblProcess.Text = "<Process type>"
    '
    'TpSync
    '
    Me.TpSync.Controls.Add(Me.GroupBox6)
    Me.TpSync.Location = New System.Drawing.Point(4, 22)
    Me.TpSync.Name = "TpSync"
    Me.TpSync.Size = New System.Drawing.Size(436, 96)
    Me.TpSync.TabIndex = 5
    Me.TpSync.Text = "Sync DT Open"
    Me.TpSync.UseVisualStyleBackColor = true
    '
    'GroupBox6
    '
    Me.GroupBox6.Controls.Add(Me.LnkSyncPath)
    Me.GroupBox6.Controls.Add(Me.LblSyncPath)
    Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.GroupBox6.Location = New System.Drawing.Point(12, 18)
    Me.GroupBox6.Name = "GroupBox6"
    Me.GroupBox6.Size = New System.Drawing.Size(408, 56)
    Me.GroupBox6.TabIndex = 14
    Me.GroupBox6.TabStop = false
    Me.GroupBox6.Text = "DT Open File"
    '
    'LnkSyncPath
    '
    Me.LnkSyncPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.LnkSyncPath.Location = New System.Drawing.Point(12, 26)
    Me.LnkSyncPath.Name = "LnkSyncPath"
    Me.LnkSyncPath.Size = New System.Drawing.Size(52, 16)
    Me.LnkSyncPath.TabIndex = 68
    Me.LnkSyncPath.TabStop = true
    Me.LnkSyncPath.Text = "File Path"
    '
    'LblSyncPath
    '
    Me.LblSyncPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.LblSyncPath.Location = New System.Drawing.Point(75, 16)
    Me.LblSyncPath.Name = "LblSyncPath"
    Me.LblSyncPath.Size = New System.Drawing.Size(321, 36)
    Me.LblSyncPath.TabIndex = 67
    '
    'TpCustID
    '
    Me.TpCustID.Controls.Add(Me.GroupBox2)
    Me.TpCustID.Controls.Add(Me.Label4)
    Me.TpCustID.Controls.Add(Me.TxtCustYearTo)
    Me.TpCustID.Controls.Add(Me.TxtCustYearFrom)
    Me.TpCustID.Controls.Add(Me.Label17)
    Me.TpCustID.Location = New System.Drawing.Point(4, 22)
    Me.TpCustID.Name = "TpCustID"
    Me.TpCustID.Size = New System.Drawing.Size(436, 96)
    Me.TpCustID.TabIndex = 4
    Me.TpCustID.Text = "Assign CustID"
    Me.TpCustID.UseVisualStyleBackColor = true
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbCustBoth)
    Me.GroupBox2.Controls.Add(Me.RbCustMV)
    Me.GroupBox2.Controls.Add(Me.RbCustSU)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(222, 3)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(128, 84)
    Me.GroupBox2.TabIndex = 77
    Me.GroupBox2.TabStop = false
    Me.GroupBox2.Text = "Tax Type"
    '
    'RbCustBoth
    '
    Me.RbCustBoth.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbCustBoth.Checked = true
    Me.RbCustBoth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.RbCustBoth.Location = New System.Drawing.Point(12, 56)
    Me.RbCustBoth.Name = "RbCustBoth"
    Me.RbCustBoth.Size = New System.Drawing.Size(108, 20)
    Me.RbCustBoth.TabIndex = 2
    Me.RbCustBoth.TabStop = true
    Me.RbCustBoth.Text = "Both"
    '
    'RbCustMV
    '
    Me.RbCustMV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbCustMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.RbCustMV.Location = New System.Drawing.Point(12, 16)
    Me.RbCustMV.Name = "RbCustMV"
    Me.RbCustMV.Size = New System.Drawing.Size(108, 20)
    Me.RbCustMV.TabIndex = 0
    Me.RbCustMV.Text = "Motor Vehicle"
    '
    'RbCustSU
    '
    Me.RbCustSU.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbCustSU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.RbCustSU.Location = New System.Drawing.Point(12, 36)
    Me.RbCustSU.Name = "RbCustSU"
    Me.RbCustSU.Size = New System.Drawing.Size(108, 20)
    Me.RbCustSU.TabIndex = 1
    Me.RbCustSU.Text = "Suppl. MV"
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(148, 28)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(19, 16)
    Me.Label4.TabIndex = 76
    Me.Label4.Text = "to"
    '
    'TxtCustYearTo
    '
    Me.TxtCustYearTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TxtCustYearTo.Location = New System.Drawing.Point(173, 25)
    Me.TxtCustYearTo.MaxLength = 4
    Me.TxtCustYearTo.Name = "TxtCustYearTo"
    Me.TxtCustYearTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtCustYearTo.TabIndex = 73
    '
    'TxtCustYearFrom
    '
    Me.TxtCustYearFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TxtCustYearFrom.Location = New System.Drawing.Point(111, 25)
    Me.TxtCustYearFrom.MaxLength = 4
    Me.TxtCustYearFrom.Name = "TxtCustYearFrom"
    Me.TxtCustYearFrom.Size = New System.Drawing.Size(32, 20)
    Me.TxtCustYearFrom.TabIndex = 72
    '
    'Label17
    '
    Me.Label17.Location = New System.Drawing.Point(23, 29)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(84, 16)
    Me.Label17.TabIndex = 75
    Me.Label17.Text = "Grand List Year"
    '
    'TpSingleTakeOff
    '
    Me.TpSingleTakeOff.Controls.Add(Me.LblTakeMsg)
    Me.TpSingleTakeOff.Controls.Add(Me.TxtTakeDMVCustID)
    Me.TpSingleTakeOff.Controls.Add(Me.Label16)
    Me.TpSingleTakeOff.Location = New System.Drawing.Point(4, 22)
    Me.TpSingleTakeOff.Name = "TpSingleTakeOff"
    Me.TpSingleTakeOff.Size = New System.Drawing.Size(436, 96)
    Me.TpSingleTakeOff.TabIndex = 3
    Me.TpSingleTakeOff.Text = "Single TakeOff"
    Me.TpSingleTakeOff.UseVisualStyleBackColor = true
    '
    'LblTakeMsg
    '
    Me.LblTakeMsg.AutoSize = true
    Me.LblTakeMsg.Location = New System.Drawing.Point(15, 46)
    Me.LblTakeMsg.Name = "LblTakeMsg"
    Me.LblTakeMsg.Size = New System.Drawing.Size(62, 13)
    Me.LblTakeMsg.TabIndex = 80
    Me.LblTakeMsg.Text = "<Message>"
    '
    'TxtTakeDMVCustID
    '
    Me.TxtTakeDMVCustID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TxtTakeDMVCustID.Location = New System.Drawing.Point(106, 11)
    Me.TxtTakeDMVCustID.MaxLength = 10
    Me.TxtTakeDMVCustID.Name = "TxtTakeDMVCustID"
    Me.TxtTakeDMVCustID.Size = New System.Drawing.Size(98, 20)
    Me.TxtTakeDMVCustID.TabIndex = 78
    '
    'Label16
    '
    Me.Label16.Location = New System.Drawing.Point(18, 15)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(82, 20)
    Me.Label16.TabIndex = 79
    Me.Label16.Text = "DMV Cust ID"
    '
    'TpTakeOffs
    '
    Me.TpTakeOffs.Controls.Add(Me.TxtDaysECheck)
    Me.TpTakeOffs.Controls.Add(Me.Label19)
    Me.TpTakeOffs.Controls.Add(Me.TxtDaysCredit)
    Me.TpTakeOffs.Controls.Add(Me.Label18)
    Me.TpTakeOffs.Controls.Add(Me.TxtDaysCheck)
    Me.TpTakeOffs.Controls.Add(Me.Label6)
    Me.TpTakeOffs.Location = New System.Drawing.Point(4, 22)
    Me.TpTakeOffs.Name = "TpTakeOffs"
    Me.TpTakeOffs.Size = New System.Drawing.Size(436, 96)
    Me.TpTakeOffs.TabIndex = 2
    Me.TpTakeOffs.Text = "Take Offs"
    Me.TpTakeOffs.UseVisualStyleBackColor = true
    '
    'TxtDaysCredit
    '
    Me.TxtDaysCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TxtDaysCredit.Location = New System.Drawing.Point(216, 60)
    Me.TxtDaysCredit.MaxLength = 4
    Me.TxtDaysCredit.Name = "TxtDaysCredit"
    Me.TxtDaysCredit.Size = New System.Drawing.Size(32, 20)
    Me.TxtDaysCredit.TabIndex = 71
    '
    'Label18
    '
    Me.Label18.AutoSize = true
    Me.Label18.Location = New System.Drawing.Point(97, 63)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(96, 13)
    Me.Label18.TabIndex = 72
    Me.Label18.Text = "Days to hold Credit"
    '
    'TxtDaysCheck
    '
    Me.TxtDaysCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TxtDaysCheck.Location = New System.Drawing.Point(216, 10)
    Me.TxtDaysCheck.MaxLength = 4
    Me.TxtDaysCheck.Name = "TxtDaysCheck"
    Me.TxtDaysCheck.Size = New System.Drawing.Size(32, 20)
    Me.TxtDaysCheck.TabIndex = 69
    '
    'Label6
    '
    Me.Label6.AutoSize = true
    Me.Label6.Location = New System.Drawing.Point(97, 13)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(105, 13)
    Me.Label6.TabIndex = 70
    Me.Label6.Text = "Days to hold Checks"
    '
    'TpSinglePutOn
    '
    Me.TpSinglePutOn.Controls.Add(Me.LblPutMsg)
    Me.TpSinglePutOn.Controls.Add(Me.TxtPutDMVCustID)
    Me.TpSinglePutOn.Controls.Add(Me.Label5)
    Me.TpSinglePutOn.Location = New System.Drawing.Point(4, 22)
    Me.TpSinglePutOn.Name = "TpSinglePutOn"
    Me.TpSinglePutOn.Padding = New System.Windows.Forms.Padding(3)
    Me.TpSinglePutOn.Size = New System.Drawing.Size(436, 96)
    Me.TpSinglePutOn.TabIndex = 1
    Me.TpSinglePutOn.Text = "Single Put On"
    Me.TpSinglePutOn.UseVisualStyleBackColor = true
    '
    'LblPutMsg
    '
    Me.LblPutMsg.AutoSize = true
    Me.LblPutMsg.Location = New System.Drawing.Point(17, 41)
    Me.LblPutMsg.Name = "LblPutMsg"
    Me.LblPutMsg.Size = New System.Drawing.Size(62, 13)
    Me.LblPutMsg.TabIndex = 77
    Me.LblPutMsg.Text = "<Message>"
    '
    'TxtPutDMVCustID
    '
    Me.TxtPutDMVCustID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TxtPutDMVCustID.Location = New System.Drawing.Point(97, 8)
    Me.TxtPutDMVCustID.MaxLength = 10
    Me.TxtPutDMVCustID.Name = "TxtPutDMVCustID"
    Me.TxtPutDMVCustID.Size = New System.Drawing.Size(98, 20)
    Me.TxtPutDMVCustID.TabIndex = 0
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(9, 12)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(82, 20)
    Me.Label5.TabIndex = 76
    Me.Label5.Text = "DMV Cust ID"
    '
    'TpPutOns
    '
    Me.TpPutOns.Controls.Add(Me.GrpSorting)
    Me.TpPutOns.Controls.Add(Me.Label2)
    Me.TpPutOns.Controls.Add(Me.TxtGLYearTo)
    Me.TpPutOns.Controls.Add(Me.TxtGLYearFrom)
    Me.TpPutOns.Controls.Add(Me.Label3)
    Me.TpPutOns.Location = New System.Drawing.Point(4, 22)
    Me.TpPutOns.Name = "TpPutOns"
    Me.TpPutOns.Padding = New System.Windows.Forms.Padding(3)
    Me.TpPutOns.Size = New System.Drawing.Size(436, 96)
    Me.TpPutOns.TabIndex = 0
    Me.TpPutOns.Text = "Put Ons"
    Me.TpPutOns.UseVisualStyleBackColor = true
    '
    'GrpSorting
    '
    Me.GrpSorting.Controls.Add(Me.RbBoth)
    Me.GrpSorting.Controls.Add(Me.RbMV)
    Me.GrpSorting.Controls.Add(Me.RbSU)
    Me.GrpSorting.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.GrpSorting.Location = New System.Drawing.Point(221, 6)
    Me.GrpSorting.Name = "GrpSorting"
    Me.GrpSorting.Size = New System.Drawing.Size(128, 84)
    Me.GrpSorting.TabIndex = 71
    Me.GrpSorting.TabStop = false
    Me.GrpSorting.Text = "Tax Type"
    '
    'RbBoth
    '
    Me.RbBoth.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbBoth.Checked = true
    Me.RbBoth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.RbBoth.Location = New System.Drawing.Point(12, 56)
    Me.RbBoth.Name = "RbBoth"
    Me.RbBoth.Size = New System.Drawing.Size(108, 20)
    Me.RbBoth.TabIndex = 2
    Me.RbBoth.TabStop = true
    Me.RbBoth.Text = "Both"
    '
    'RbMV
    '
    Me.RbMV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.RbMV.Location = New System.Drawing.Point(12, 16)
    Me.RbMV.Name = "RbMV"
    Me.RbMV.Size = New System.Drawing.Size(108, 20)
    Me.RbMV.TabIndex = 0
    Me.RbMV.Text = "Motor Vehicle"
    '
    'RbSU
    '
    Me.RbSU.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.RbSU.Location = New System.Drawing.Point(12, 36)
    Me.RbSU.Name = "RbSU"
    Me.RbSU.Size = New System.Drawing.Size(108, 20)
    Me.RbSU.TabIndex = 1
    Me.RbSU.Text = "Suppl. MV"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(141, 27)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(19, 16)
    Me.Label2.TabIndex = 70
    Me.Label2.Text = "to"
    '
    'TxtGLYearTo
    '
    Me.TxtGLYearTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TxtGLYearTo.Location = New System.Drawing.Point(166, 24)
    Me.TxtGLYearTo.MaxLength = 4
    Me.TxtGLYearTo.Name = "TxtGLYearTo"
    Me.TxtGLYearTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtGLYearTo.TabIndex = 66
    '
    'TxtGLYearFrom
    '
    Me.TxtGLYearFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TxtGLYearFrom.Location = New System.Drawing.Point(104, 24)
    Me.TxtGLYearFrom.MaxLength = 4
    Me.TxtGLYearFrom.Name = "TxtGLYearFrom"
    Me.TxtGLYearFrom.Size = New System.Drawing.Size(32, 20)
    Me.TxtGLYearFrom.TabIndex = 65
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(16, 28)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(84, 16)
    Me.Label3.TabIndex = 68
    Me.Label3.Text = "Grand List Year"
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.TpPutOns)
    Me.TabControl1.Controls.Add(Me.TpSinglePutOn)
    Me.TabControl1.Controls.Add(Me.TpTakeOffs)
    Me.TabControl1.Controls.Add(Me.TpSingleTakeOff)
    Me.TabControl1.Controls.Add(Me.TpCustID)
    Me.TabControl1.Controls.Add(Me.TpSync)
    Me.TabControl1.Location = New System.Drawing.Point(12, 23)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(444, 122)
    Me.TabControl1.TabIndex = 0
    '
    'GrpSuspense
    '
    Me.GrpSuspense.Controls.Add(Me.TxtReason10)
    Me.GrpSuspense.Controls.Add(Me.TxtReason9)
    Me.GrpSuspense.Controls.Add(Me.LnkReason10)
    Me.GrpSuspense.Controls.Add(Me.LnkReason9)
    Me.GrpSuspense.Controls.Add(Me.TxtReason8)
    Me.GrpSuspense.Controls.Add(Me.TxtReason7)
    Me.GrpSuspense.Controls.Add(Me.TxtReason6)
    Me.GrpSuspense.Controls.Add(Me.TxtReason5)
    Me.GrpSuspense.Controls.Add(Me.TxtReason4)
    Me.GrpSuspense.Controls.Add(Me.TxtReason3)
    Me.GrpSuspense.Controls.Add(Me.LnkReason8)
    Me.GrpSuspense.Controls.Add(Me.LnkReason7)
    Me.GrpSuspense.Controls.Add(Me.LnkReason6)
    Me.GrpSuspense.Controls.Add(Me.LnkReason5)
    Me.GrpSuspense.Controls.Add(Me.LnkReason4)
    Me.GrpSuspense.Controls.Add(Me.LnkReason3)
    Me.GrpSuspense.Controls.Add(Me.LnkReason2)
    Me.GrpSuspense.Controls.Add(Me.TxtReason2)
    Me.GrpSuspense.Controls.Add(Me.TxtReason1)
    Me.GrpSuspense.Controls.Add(Me.LnkReason1)
    Me.GrpSuspense.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.GrpSuspense.Location = New System.Drawing.Point(12, 147)
    Me.GrpSuspense.Name = "GrpSuspense"
    Me.GrpSuspense.Size = New System.Drawing.Size(254, 64)
    Me.GrpSuspense.TabIndex = 68
    Me.GrpSuspense.TabStop = false
    Me.GrpSuspense.Text = "Optional - Omit Suspense Reason Codes"
    '
    'TxtReason10
    '
    Me.TxtReason10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtReason10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TxtReason10.Location = New System.Drawing.Point(224, 40)
    Me.TxtReason10.MaxLength = 1
    Me.TxtReason10.Name = "TxtReason10"
    Me.TxtReason10.Size = New System.Drawing.Size(16, 20)
    Me.TxtReason10.TabIndex = 9
    '
    'TxtReason9
    '
    Me.TxtReason9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtReason9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TxtReason9.Location = New System.Drawing.Point(200, 40)
    Me.TxtReason9.MaxLength = 1
    Me.TxtReason9.Name = "TxtReason9"
    Me.TxtReason9.Size = New System.Drawing.Size(16, 20)
    Me.TxtReason9.TabIndex = 8
    '
    'LnkReason10
    '
    Me.LnkReason10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.LnkReason10.Location = New System.Drawing.Point(224, 20)
    Me.LnkReason10.Name = "LnkReason10"
    Me.LnkReason10.Size = New System.Drawing.Size(20, 16)
    Me.LnkReason10.TabIndex = 80
    Me.LnkReason10.TabStop = true
    Me.LnkReason10.Text = "10"
    '
    'LnkReason9
    '
    Me.LnkReason9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.LnkReason9.Location = New System.Drawing.Point(204, 20)
    Me.LnkReason9.Name = "LnkReason9"
    Me.LnkReason9.Size = New System.Drawing.Size(12, 16)
    Me.LnkReason9.TabIndex = 79
    Me.LnkReason9.TabStop = true
    Me.LnkReason9.Text = "9"
    '
    'TxtReason8
    '
    Me.TxtReason8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtReason8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TxtReason8.Location = New System.Drawing.Point(176, 40)
    Me.TxtReason8.MaxLength = 1
    Me.TxtReason8.Name = "TxtReason8"
    Me.TxtReason8.Size = New System.Drawing.Size(16, 20)
    Me.TxtReason8.TabIndex = 7
    '
    'TxtReason7
    '
    Me.TxtReason7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtReason7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TxtReason7.Location = New System.Drawing.Point(152, 40)
    Me.TxtReason7.MaxLength = 1
    Me.TxtReason7.Name = "TxtReason7"
    Me.TxtReason7.Size = New System.Drawing.Size(16, 20)
    Me.TxtReason7.TabIndex = 6
    '
    'TxtReason6
    '
    Me.TxtReason6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtReason6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TxtReason6.Location = New System.Drawing.Point(128, 40)
    Me.TxtReason6.MaxLength = 1
    Me.TxtReason6.Name = "TxtReason6"
    Me.TxtReason6.Size = New System.Drawing.Size(16, 20)
    Me.TxtReason6.TabIndex = 5
    '
    'TxtReason5
    '
    Me.TxtReason5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtReason5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TxtReason5.Location = New System.Drawing.Point(104, 40)
    Me.TxtReason5.MaxLength = 1
    Me.TxtReason5.Name = "TxtReason5"
    Me.TxtReason5.Size = New System.Drawing.Size(16, 20)
    Me.TxtReason5.TabIndex = 4
    '
    'TxtReason4
    '
    Me.TxtReason4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtReason4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TxtReason4.Location = New System.Drawing.Point(80, 40)
    Me.TxtReason4.MaxLength = 1
    Me.TxtReason4.Name = "TxtReason4"
    Me.TxtReason4.Size = New System.Drawing.Size(16, 20)
    Me.TxtReason4.TabIndex = 3
    '
    'TxtReason3
    '
    Me.TxtReason3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtReason3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TxtReason3.Location = New System.Drawing.Point(56, 40)
    Me.TxtReason3.MaxLength = 1
    Me.TxtReason3.Name = "TxtReason3"
    Me.TxtReason3.Size = New System.Drawing.Size(16, 20)
    Me.TxtReason3.TabIndex = 2
    '
    'LnkReason8
    '
    Me.LnkReason8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.LnkReason8.Location = New System.Drawing.Point(180, 20)
    Me.LnkReason8.Name = "LnkReason8"
    Me.LnkReason8.Size = New System.Drawing.Size(12, 16)
    Me.LnkReason8.TabIndex = 72
    Me.LnkReason8.TabStop = true
    Me.LnkReason8.Text = "8"
    '
    'LnkReason7
    '
    Me.LnkReason7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.LnkReason7.Location = New System.Drawing.Point(156, 20)
    Me.LnkReason7.Name = "LnkReason7"
    Me.LnkReason7.Size = New System.Drawing.Size(12, 16)
    Me.LnkReason7.TabIndex = 71
    Me.LnkReason7.TabStop = true
    Me.LnkReason7.Text = "7"
    '
    'LnkReason6
    '
    Me.LnkReason6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.LnkReason6.Location = New System.Drawing.Point(132, 20)
    Me.LnkReason6.Name = "LnkReason6"
    Me.LnkReason6.Size = New System.Drawing.Size(12, 16)
    Me.LnkReason6.TabIndex = 70
    Me.LnkReason6.TabStop = true
    Me.LnkReason6.Text = "6"
    '
    'LnkReason5
    '
    Me.LnkReason5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.LnkReason5.Location = New System.Drawing.Point(108, 20)
    Me.LnkReason5.Name = "LnkReason5"
    Me.LnkReason5.Size = New System.Drawing.Size(12, 16)
    Me.LnkReason5.TabIndex = 69
    Me.LnkReason5.TabStop = true
    Me.LnkReason5.Text = "5"
    '
    'LnkReason4
    '
    Me.LnkReason4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.LnkReason4.Location = New System.Drawing.Point(84, 20)
    Me.LnkReason4.Name = "LnkReason4"
    Me.LnkReason4.Size = New System.Drawing.Size(12, 16)
    Me.LnkReason4.TabIndex = 68
    Me.LnkReason4.TabStop = true
    Me.LnkReason4.Text = "4"
    '
    'LnkReason3
    '
    Me.LnkReason3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.LnkReason3.Location = New System.Drawing.Point(60, 20)
    Me.LnkReason3.Name = "LnkReason3"
    Me.LnkReason3.Size = New System.Drawing.Size(12, 16)
    Me.LnkReason3.TabIndex = 67
    Me.LnkReason3.TabStop = true
    Me.LnkReason3.Text = "3"
    '
    'LnkReason2
    '
    Me.LnkReason2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.LnkReason2.Location = New System.Drawing.Point(36, 20)
    Me.LnkReason2.Name = "LnkReason2"
    Me.LnkReason2.Size = New System.Drawing.Size(12, 16)
    Me.LnkReason2.TabIndex = 66
    Me.LnkReason2.TabStop = true
    Me.LnkReason2.Text = "2"
    '
    'TxtReason2
    '
    Me.TxtReason2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtReason2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TxtReason2.Location = New System.Drawing.Point(32, 40)
    Me.TxtReason2.MaxLength = 1
    Me.TxtReason2.Name = "TxtReason2"
    Me.TxtReason2.Size = New System.Drawing.Size(16, 20)
    Me.TxtReason2.TabIndex = 1
    '
    'TxtReason1
    '
    Me.TxtReason1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtReason1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TxtReason1.Location = New System.Drawing.Point(8, 40)
    Me.TxtReason1.MaxLength = 1
    Me.TxtReason1.Name = "TxtReason1"
    Me.TxtReason1.Size = New System.Drawing.Size(16, 20)
    Me.TxtReason1.TabIndex = 0
    '
    'LnkReason1
    '
    Me.LnkReason1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.LnkReason1.Location = New System.Drawing.Point(8, 20)
    Me.LnkReason1.Name = "LnkReason1"
    Me.LnkReason1.Size = New System.Drawing.Size(12, 16)
    Me.LnkReason1.TabIndex = 65
    Me.LnkReason1.TabStop = true
    Me.LnkReason1.Text = "1"
    '
    'TxtDaysECheck
    '
    Me.TxtDaysECheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.TxtDaysECheck.Location = New System.Drawing.Point(216, 36)
    Me.TxtDaysECheck.MaxLength = 4
    Me.TxtDaysECheck.Name = "TxtDaysECheck"
    Me.TxtDaysECheck.Size = New System.Drawing.Size(32, 20)
    Me.TxtDaysECheck.TabIndex = 70
    '
    'Label19
    '
    Me.Label19.AutoSize = true
    Me.Label19.Location = New System.Drawing.Point(98, 39)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(112, 13)
    Me.Label19.TabIndex = 74
    Me.Label19.Text = "Days to hold EChecks"
    '
    'FrmTX407B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(554, 439)
    Me.ControlBox = false
    Me.Controls.Add(Me.GrpSuspense)
    Me.Controls.Add(Me.TabControl2)
    Me.Controls.Add(Me.ChkMass)
    Me.Controls.Add(Me.LblProcess)
    Me.Controls.Add(Me.TabControl1)
    Me.Controls.Add(Me.ChkPost)
    Me.KeyPreview = true
    Me.MaximizeBox = false
    Me.MinimizeBox = false
    Me.Name = "FrmTX407B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv,System.ComponentModel.ISupportInitialize).EndInit
    Me.GroupBox1.ResumeLayout(false)
    Me.GroupBox3.ResumeLayout(false)
    Me.GroupBox4.ResumeLayout(false)
    Me.TabControl2.ResumeLayout(false)
    Me.TpFiles.ResumeLayout(false)
    Me.TpFiles.PerformLayout
    Me.GrpMiss.ResumeLayout(false)
    Me.GrpDMV.ResumeLayout(false)
    Me.TpDetail.ResumeLayout(false)
    CType(Me.C1DataGrdList,System.ComponentModel.ISupportInitialize).EndInit
    Me.TpSync.ResumeLayout(false)
    Me.GroupBox6.ResumeLayout(false)
    Me.TpCustID.ResumeLayout(false)
    Me.TpCustID.PerformLayout
    Me.GroupBox2.ResumeLayout(false)
    Me.TpSingleTakeOff.ResumeLayout(false)
    Me.TpSingleTakeOff.PerformLayout
    Me.TpTakeOffs.ResumeLayout(false)
    Me.TpTakeOffs.PerformLayout
    Me.TpSinglePutOn.ResumeLayout(false)
    Me.TpSinglePutOn.PerformLayout
    Me.TpPutOns.ResumeLayout(false)
    Me.TpPutOns.PerformLayout
    Me.GrpSorting.ResumeLayout(false)
    Me.TabControl1.ResumeLayout(false)
    Me.GrpSuspense.ResumeLayout(false)
    Me.GrpSuspense.PerformLayout
    Me.ResumeLayout(false)
    Me.PerformLayout

End Sub

#End Region

  Public Sub RunReport()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    Dim WrkAnswer As String

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    If MyFrmTX407B.TabControl1.SelectedTab.Name = "TpPutOns" Then
      If MyUtils.CnvSng(MyFrmTX407B.TxtGLYearFrom.Text) = 0 And MyFrmTX407B.ChkPost.Checked Then
        WrkAnswer = MsgBox("This will reset ALL MV Flags. Continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Processing mass put on")
        If WrkAnswer = vbNo Then Exit Sub
      End If
    End If

    Me.Refresh()

    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    Select Case MyFrmTX407B.TabControl1.SelectedTab.Name
    Case "TpPutOns"
      PrtPutons()
      MyFrmTX407.TBarProcess.Enabled = True
    Case "TpSinglePutOn"
      PrtSinglePuton()
      MyFrmTX407.TBarProcess.Enabled = True
    Case "TpTakeOffs"
      PrtTakeOffs()
    Case "TpSingleTakeOff"
      PrtSingleTakeOff()
      MyFrmTX407.TBarProcess.Enabled = True
    Case "TpCustID"
      PrtCustID()
      MyFrmTX407.TBarProcess.Enabled = True
    Case "TpSync"
      PrtSync()
      MyFrmTX407.TBarProcess.Enabled = True
    End Select
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmTX407B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkStr As String

    MyFrmTX407.SbpPgmID.Text = "TX407B"
    MyFrmTX407.SbpEnvironment.Text = myDBConnect.PgmDB
    LblProcess.Text = "Put Ons"
    WrkStr = Mid(MyUtils.SetDBDate(Date.Today), 3, 6)
    LblFilePath.Text = MyUtils.GetDataPath() & "TC" & Format(myTOWN._TOWNBR, "000") & "DT" & WrkStr & ".txt"
    LblMissPath.Text = MyUtils.GetDataPath() & "MissingIDs_" & Format(myTOWN._TOWNBR, "000") & ".txt"
    LblPutMsg.Text = ""
    LblTakeMsg.Text = ""
    TxtDaysCheck.Text = MyAppSettings.DaysCheck
    TxtDaysECheck.Text = MyAppSettings.DaysECheck
    TxtDaysCredit.Text = MyAppSettings.DaysCredit
    ChkMass.Visible = False
    TabControl2.TabPages.Remove(TpDetail)
    MyFrmTX407.TBarPrint.Enabled = False
  End Sub
  Private Sub FrmTX407B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX407.SbpScreen.Text = "TX407B"
End Sub
Private Sub FrmTX407B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLYearFrom, "")
    ErrProv.SetError(LblSyncPath, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "glyear"
        ErrProv.SetError(TxtGLYearFrom, ErrorMsg(I))
      Case "syncpath"
        ErrProv.SetError(LblSyncPath, ErrorMsg(I))
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

    Select Case MyFrmTX407B.TabControl1.SelectedTab.Name
    Case "TpSync"
      If LblSyncPath.Text = String.Empty Then
        ErrorField(I) = "syncpath"
        ErrorMsg(I) = "File path cannot be blank"
        I = I + 1
      End If
    End Select
  End Sub
Private Sub FrmTX407B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub

   If e.KeyCode = Keys.F12 Then
     MyUtils.PrtScreen(Form.ActiveForm)
   End If
End Sub
Private Sub TxtGLYearFrom_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYearFrom.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtGLYearTo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYearTo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtPutDMVCustID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPutDMVCustID.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  LblPutMsg.Text = ""
End Sub
  Private Sub TxtTakeDMVCustID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTakeDMVCustID.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
    LblTakeMsg.Text = ""
  End Sub
Private Sub LnkReason1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkReason1.LinkClicked
  MyFrmListSuspReason = New FrmListSuspReason
  MyFrmListSuspReason.MdiParent = Me.ParentForm
  MyFrmListSuspReason.WrkField = 1
  MyFrmListSuspReason.WrkCode = TxtReason1.Text
  MyFrmListSuspReason.Show()
End Sub
Private Sub LnkReason2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkReason2.LinkClicked
  MyFrmListSuspReason = New FrmListSuspReason
  MyFrmListSuspReason.MdiParent = Me.ParentForm
  MyFrmListSuspReason.WrkField = 2
  MyFrmListSuspReason.WrkCode = TxtReason2.Text
  MyFrmListSuspReason.Show()
End Sub
Private Sub LnkReason3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkReason3.LinkClicked
  MyFrmListSuspReason = New FrmListSuspReason
  MyFrmListSuspReason.MdiParent = Me.ParentForm
  MyFrmListSuspReason.WrkField = 3
  MyFrmListSuspReason.WrkCode = TxtReason3.Text
  MyFrmListSuspReason.Show()
End Sub
Private Sub LnkReason4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkReason4.LinkClicked
  MyFrmListSuspReason = New FrmListSuspReason
  MyFrmListSuspReason.MdiParent = Me.ParentForm
  MyFrmListSuspReason.WrkField = 4
  MyFrmListSuspReason.WrkCode = TxtReason4.Text
  MyFrmListSuspReason.Show()
End Sub
Private Sub LnkReason5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkReason5.LinkClicked
  MyFrmListSuspReason = New FrmListSuspReason
  MyFrmListSuspReason.MdiParent = Me.ParentForm
  MyFrmListSuspReason.WrkField = 5
  MyFrmListSuspReason.WrkCode = TxtReason5.Text
  MyFrmListSuspReason.Show()
End Sub
Private Sub LnkReason6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkReason6.LinkClicked
  MyFrmListSuspReason = New FrmListSuspReason
  MyFrmListSuspReason.MdiParent = Me.ParentForm
  MyFrmListSuspReason.WrkField = 6
  MyFrmListSuspReason.WrkCode = TxtReason6.Text
  MyFrmListSuspReason.Show()
End Sub
Private Sub LnkReason7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkReason7.LinkClicked
  MyFrmListSuspReason = New FrmListSuspReason
  MyFrmListSuspReason.MdiParent = Me.ParentForm
  MyFrmListSuspReason.WrkField = 7
  MyFrmListSuspReason.WrkCode = TxtReason7.Text
  MyFrmListSuspReason.Show()
End Sub
Private Sub LnkReason8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkReason8.LinkClicked
  MyFrmListSuspReason = New FrmListSuspReason
  MyFrmListSuspReason.MdiParent = Me.ParentForm
  MyFrmListSuspReason.WrkField = 8
  MyFrmListSuspReason.WrkCode = TxtReason8.Text
  MyFrmListSuspReason.Show()
End Sub
Private Sub LnkReason9_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkReason9.LinkClicked
  MyFrmListSuspReason = New FrmListSuspReason
  MyFrmListSuspReason.MdiParent = Me.ParentForm
  MyFrmListSuspReason.WrkField = 9
  MyFrmListSuspReason.WrkCode = TxtReason9.Text
  MyFrmListSuspReason.Show()
End Sub
Private Sub LnkReason10_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkReason10.LinkClicked
  MyFrmListSuspReason = New FrmListSuspReason
  MyFrmListSuspReason.MdiParent = Me.ParentForm
  MyFrmListSuspReason.WrkField = 10
  MyFrmListSuspReason.WrkCode = TxtReason10.Text
  MyFrmListSuspReason.Show()
End Sub
Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
  Dim WrkStr As String

  WrkStr = Mid(MyUtils.SetDBDate(Date.Today), 3, 6)
  With SaveFileDialog1
    .FileName = "TC" & Format(myTOWN._TOWNBR, "000") & "DT" & WrkStr & ".txt"
    .ShowDialog()
    If .FileName <> String.Empty Then
      LblFilePath.Text = .FileName
    End If
  End With
End Sub
Private Sub TabControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.Click
  TabControl2.TabPages.Remove(TpFiles)
  TabControl2.TabPages.Remove(TpDetail)
  Select Case TabControl1.SelectedTab.Name
  Case "TpPutOns"
    LblProcess.Text = "Put Ons"
    ChkPost.Visible = True
    ChkPost.Text = "Post MV Flag?"
    ChkPost.Enabled = True
    ChkMass.Enabled = True
    GrpDMV.Enabled = True
    GrpMiss.Enabled = True
    GrpSuspense.Visible = True
    TabControl2.TabPages.Add(TpFiles)
  Case "TpSinglePutOn"
    LblProcess.Text = "Single Put On"
    ChkMass.Enabled = False
    ChkPost.Visible = True
    ChkPost.Text = "Post MV Flag?"
    ChkPost.Enabled = True
    GrpDMV.Enabled = False
    GrpMiss.Enabled = False
    GrpSuspense.Visible = False
    TabControl2.TabPages.Add(TpDetail)
  Case "TpTakeOffs"
    LblProcess.Text = "Take Offs"
    ChkMass.Enabled = False
    ChkPost.Visible = False
    GrpDMV.Enabled = True
    GrpMiss.Enabled = False
    GrpSuspense.Visible = False
    TabControl2.TabPages.Add(TpFiles)
  Case "TpSingleTakeOff"
    LblProcess.Text = "Single Take Offs"
    ChkMass.Enabled = False
    ChkPost.Visible = True
    ChkPost.Text = "Remove MV Flag?"
    ChkPost.Enabled = True
    GrpDMV.Enabled = False
    GrpSuspense.Visible = False
    GrpMiss.Enabled = False
    TabControl2.TabPages.Add(TpDetail)
  Case "TpCustID"
    LblProcess.Text = "CustID"
    ChkPost.Visible = True
    ChkPost.Text = "Post?"
    ChkPost.Enabled = True
    ChkMass.Enabled = False
    GrpDMV.Enabled = False
    GrpSuspense.Visible = True
    GrpMiss.Enabled = False
  Case "TpSync"
    LblProcess.Text = "Sync"
    ChkPost.Visible = True
    ChkPost.Enabled = True
    ChkMass.Enabled = False
    GrpDMV.Enabled = True
    GrpMiss.Enabled = False
    GrpSuspense.Visible = True
    TabControl2.TabPages.Add(TpFiles)
End Select
End Sub
Private Sub LnkMissPath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkMissPath.LinkClicked
  With SaveFileDialog1
    .FileName = "MissingIDs_" & Format(myTOWN._TOWNBR, "000") & ".txt"
    .ShowDialog()
    If .FileName <> String.Empty Then
      LblMissPath.Text = .FileName
    End If
  End With
End Sub
Private Sub LnkSyncPath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkSyncPath.LinkClicked
  With OpenFileDialog1
    .ReadOnlyChecked = True
    .FileName = ""
    .ShowDialog()
    LblSyncPath.Text = .FileName
  End With
End Sub
Private Sub TxtDaysCheck_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDaysCheck.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDaysECheck_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDaysECheck.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDaysCredit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDaysCredit.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






