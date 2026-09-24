Public Class FrmTX301B
Inherits System.Windows.Forms.Form
Dim WrkType As String
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
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbRE As System.Windows.Forms.RadioButton
Friend WithEvents RbMV As System.Windows.Forms.RadioButton
Friend WithEvents RbPP As System.Windows.Forms.RadioButton
Friend WithEvents RbSU As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
Friend WithEvents RbPrtNoBill As System.Windows.Forms.RadioButton
Friend WithEvents RbPrtBill As System.Windows.Forms.RadioButton
Friend WithEvents RbSortZip As System.Windows.Forms.RadioButton
Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
Friend WithEvents RbProrate As System.Windows.Forms.RadioButton
Friend WithEvents GrpSorting As System.Windows.Forms.GroupBox
Friend WithEvents ChkUpdate As System.Windows.Forms.CheckBox
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents TxtGLDay As System.Windows.Forms.TextBox
Friend WithEvents TxtGLMonth As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents GrpRE As System.Windows.Forms.GroupBox
Friend WithEvents RbSelAll As System.Windows.Forms.RadioButton
Friend WithEvents RbSelNon As System.Windows.Forms.RadioButton
Friend WithEvents RbSelNonBanks As System.Windows.Forms.RadioButton
Friend WithEvents GrpProrate As System.Windows.Forms.GroupBox
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents DtPckProDue2 As System.Windows.Forms.DateTimePicker
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents DtPckProDue1 As System.Windows.Forms.DateTimePicker
Friend WithEvents RbRESwr As System.Windows.Forms.RadioButton
Friend WithEvents TxtComment As System.Windows.Forms.TextBox
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents TxtStateMoney As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtStateMillRate As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
Friend WithEvents TxtBankCd As System.Windows.Forms.TextBox
Friend WithEvents LnkBankCd As System.Windows.Forms.LinkLabel
Friend WithEvents GrpDownload As System.Windows.Forms.GroupBox
Friend WithEvents ChkHeadings As System.Windows.Forms.CheckBox
Friend WithEvents RbCSV As System.Windows.Forms.RadioButton
Friend WithEvents RbFixed As System.Windows.Forms.RadioButton
Friend WithEvents LblFilePath As System.Windows.Forms.Label
Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
Friend WithEvents ChkAlternative As System.Windows.Forms.CheckBox
Friend WithEvents ChkBarcode As System.Windows.Forms.CheckBox
Friend WithEvents Label12 As System.Windows.Forms.Label
Friend WithEvents DtPckProGrace2 As System.Windows.Forms.DateTimePicker
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents DtPckProGrace1 As System.Windows.Forms.DateTimePicker
Friend WithEvents ChkUpdateDist As System.Windows.Forms.CheckBox
Friend WithEvents ChkAllBanks As System.Windows.Forms.CheckBox
Friend WithEvents LblMsg As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbRESwr = New System.Windows.Forms.RadioButton()
    Me.RbProrate = New System.Windows.Forms.RadioButton()
    Me.RbSU = New System.Windows.Forms.RadioButton()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.RbMV = New System.Windows.Forms.RadioButton()
    Me.RbPP = New System.Windows.Forms.RadioButton()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.TxtComment = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtStateMoney = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtStateMillRate = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.RbPrtNoBill = New System.Windows.Forms.RadioButton()
    Me.RbPrtBill = New System.Windows.Forms.RadioButton()
    Me.GrpSorting = New System.Windows.Forms.GroupBox()
    Me.RbSortZip = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.ChkUpdate = New System.Windows.Forms.CheckBox()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.TxtGLDay = New System.Windows.Forms.TextBox()
    Me.TxtGLMonth = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.GrpRE = New System.Windows.Forms.GroupBox()
    Me.ChkAllBanks = New System.Windows.Forms.CheckBox()
    Me.TxtBankCd = New System.Windows.Forms.TextBox()
    Me.LnkBankCd = New System.Windows.Forms.LinkLabel()
    Me.RbSelAll = New System.Windows.Forms.RadioButton()
    Me.RbSelNon = New System.Windows.Forms.RadioButton()
    Me.RbSelNonBanks = New System.Windows.Forms.RadioButton()
    Me.GrpProrate = New System.Windows.Forms.GroupBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.DtPckProGrace2 = New System.Windows.Forms.DateTimePicker()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.DtPckProGrace1 = New System.Windows.Forms.DateTimePicker()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.DtPckProDue2 = New System.Windows.Forms.DateTimePicker()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.DtPckProDue1 = New System.Windows.Forms.DateTimePicker()
    Me.LblMsg = New System.Windows.Forms.Label()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.GrpDownload = New System.Windows.Forms.GroupBox()
    Me.ChkBarcode = New System.Windows.Forms.CheckBox()
    Me.ChkAlternative = New System.Windows.Forms.CheckBox()
    Me.ChkHeadings = New System.Windows.Forms.CheckBox()
    Me.RbCSV = New System.Windows.Forms.RadioButton()
    Me.RbFixed = New System.Windows.Forms.RadioButton()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.ChkUpdateDist = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.GrpSorting.SuspendLayout()
    Me.GrpRE.SuspendLayout()
    Me.GrpProrate.SuspendLayout()
    Me.GrpDownload.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbRESwr)
    Me.GroupBox2.Controls.Add(Me.RbProrate)
    Me.GroupBox2.Controls.Add(Me.RbSU)
    Me.GroupBox2.Controls.Add(Me.RbRE)
    Me.GroupBox2.Controls.Add(Me.RbMV)
    Me.GroupBox2.Controls.Add(Me.RbPP)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(12, 72)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(160, 142)
    Me.GroupBox2.TabIndex = 5
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Bill Type"
    '
    'RbRESwr
    '
    Me.RbRESwr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbRESwr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbRESwr.Location = New System.Drawing.Point(12, 116)
    Me.RbRESwr.Name = "RbRESwr"
    Me.RbRESwr.Size = New System.Drawing.Size(140, 20)
    Me.RbRESwr.TabIndex = 5
    Me.RbRESwr.Text = "Real Estate with Sewer"
    '
    'RbProrate
    '
    Me.RbProrate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbProrate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbProrate.Location = New System.Drawing.Point(12, 96)
    Me.RbProrate.Name = "RbProrate"
    Me.RbProrate.Size = New System.Drawing.Size(140, 20)
    Me.RbProrate.TabIndex = 4
    Me.RbProrate.Text = "Pro Rated Real Estate"
    '
    'RbSU
    '
    Me.RbSU.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSU.Location = New System.Drawing.Point(12, 76)
    Me.RbSU.Name = "RbSU"
    Me.RbSU.Size = New System.Drawing.Size(140, 20)
    Me.RbSU.TabIndex = 3
    Me.RbSU.Text = "Supplemental MV"
    '
    'RbRE
    '
    Me.RbRE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbRE.Checked = True
    Me.RbRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbRE.Location = New System.Drawing.Point(12, 16)
    Me.RbRE.Name = "RbRE"
    Me.RbRE.Size = New System.Drawing.Size(140, 20)
    Me.RbRE.TabIndex = 0
    Me.RbRE.TabStop = True
    Me.RbRE.Text = "Real Estate"
    '
    'RbMV
    '
    Me.RbMV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbMV.Location = New System.Drawing.Point(12, 56)
    Me.RbMV.Name = "RbMV"
    Me.RbMV.Size = New System.Drawing.Size(140, 20)
    Me.RbMV.TabIndex = 2
    Me.RbMV.Text = "Motor Vehicle"
    '
    'RbPP
    '
    Me.RbPP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPP.Location = New System.Drawing.Point(12, 36)
    Me.RbPP.Name = "RbPP"
    Me.RbPP.Size = New System.Drawing.Size(140, 20)
    Me.RbPP.TabIndex = 1
    Me.RbPP.Text = "Personal Property"
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.TxtComment)
    Me.GroupBox4.Controls.Add(Me.Label7)
    Me.GroupBox4.Controls.Add(Me.TxtStateMoney)
    Me.GroupBox4.Controls.Add(Me.Label2)
    Me.GroupBox4.Controls.Add(Me.TxtStateMillRate)
    Me.GroupBox4.Controls.Add(Me.Label4)
    Me.GroupBox4.Controls.Add(Me.RbPrtNoBill)
    Me.GroupBox4.Controls.Add(Me.RbPrtBill)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(183, 72)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(365, 120)
    Me.GroupBox4.TabIndex = 6
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Bill Printing"
    '
    'TxtComment
    '
    Me.TxtComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtComment.Location = New System.Drawing.Point(191, 94)
    Me.TxtComment.MaxLength = 45
    Me.TxtComment.Name = "TxtComment"
    Me.TxtComment.Size = New System.Drawing.Size(168, 20)
    Me.TxtComment.TabIndex = 73
    '
    'Label7
    '
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(7, 94)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(180, 16)
    Me.Label7.TabIndex = 76
    Me.Label7.Text = "Miscellaneous Comment On Bill"
    '
    'TxtStateMoney
    '
    Me.TxtStateMoney.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtStateMoney.Location = New System.Drawing.Point(191, 70)
    Me.TxtStateMoney.MaxLength = 12
    Me.TxtStateMoney.Name = "TxtStateMoney"
    Me.TxtStateMoney.Size = New System.Drawing.Size(96, 20)
    Me.TxtStateMoney.TabIndex = 72
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(7, 70)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(180, 16)
    Me.Label2.TabIndex = 75
    Me.Label2.Text = "Dollars Town Will Receive"
    '
    'TxtStateMillRate
    '
    Me.TxtStateMillRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtStateMillRate.Location = New System.Drawing.Point(191, 46)
    Me.TxtStateMillRate.MaxLength = 10
    Me.TxtStateMillRate.Name = "TxtStateMillRate"
    Me.TxtStateMillRate.Size = New System.Drawing.Size(68, 20)
    Me.TxtStateMillRate.TabIndex = 71
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(7, 46)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(180, 16)
    Me.Label4.TabIndex = 74
    Me.Label4.Text = "Mill Rate Without State Assistance"
    '
    'RbPrtNoBill
    '
    Me.RbPrtNoBill.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPrtNoBill.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPrtNoBill.Location = New System.Drawing.Point(12, 16)
    Me.RbPrtNoBill.Name = "RbPrtNoBill"
    Me.RbPrtNoBill.Size = New System.Drawing.Size(69, 20)
    Me.RbPrtNoBill.TabIndex = 0
    Me.RbPrtNoBill.Text = "No Bills"
    '
    'RbPrtBill
    '
    Me.RbPrtBill.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPrtBill.Checked = True
    Me.RbPrtBill.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPrtBill.Location = New System.Drawing.Point(109, 16)
    Me.RbPrtBill.Name = "RbPrtBill"
    Me.RbPrtBill.Size = New System.Drawing.Size(69, 20)
    Me.RbPrtBill.TabIndex = 1
    Me.RbPrtBill.TabStop = True
    Me.RbPrtBill.Text = "Print Bill"
    '
    'GrpSorting
    '
    Me.GrpSorting.Controls.Add(Me.RbSortZip)
    Me.GrpSorting.Controls.Add(Me.RbSortName)
    Me.GrpSorting.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpSorting.Location = New System.Drawing.Point(443, 6)
    Me.GrpSorting.Name = "GrpSorting"
    Me.GrpSorting.Size = New System.Drawing.Size(128, 60)
    Me.GrpSorting.TabIndex = 4
    Me.GrpSorting.TabStop = False
    Me.GrpSorting.Text = "Sorting"
    '
    'RbSortZip
    '
    Me.RbSortZip.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortZip.Location = New System.Drawing.Point(12, 16)
    Me.RbSortZip.Name = "RbSortZip"
    Me.RbSortZip.Size = New System.Drawing.Size(108, 20)
    Me.RbSortZip.TabIndex = 0
    Me.RbSortZip.Text = "Zip Code, Name"
    '
    'RbSortName
    '
    Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortName.Checked = True
    Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortName.Location = New System.Drawing.Point(12, 36)
    Me.RbSortName.Name = "RbSortName"
    Me.RbSortName.Size = New System.Drawing.Size(108, 20)
    Me.RbSortName.TabIndex = 1
    Me.RbSortName.TabStop = True
    Me.RbSortName.Text = "Name"
    '
    'ChkUpdate
    '
    Me.ChkUpdate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkUpdate.Location = New System.Drawing.Point(15, 487)
    Me.ChkUpdate.Name = "ChkUpdate"
    Me.ChkUpdate.Size = New System.Drawing.Size(200, 19)
    Me.ChkUpdate.TabIndex = 11
    Me.ChkUpdate.Text = "Post bills Tax Invoice File?"
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(124, 49)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(28, 20)
    Me.TxtDist.TabIndex = 3
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(12, 49)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(44, 16)
    Me.Label1.TabIndex = 71
    Me.Label1.Text = "District"
    '
    'TxtGLYear
    '
    Me.TxtGLYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGLYear.Location = New System.Drawing.Point(172, 25)
    Me.TxtGLYear.MaxLength = 4
    Me.TxtGLYear.Name = "TxtGLYear"
    Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtGLYear.TabIndex = 2
    '
    'TxtGLDay
    '
    Me.TxtGLDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGLDay.Location = New System.Drawing.Point(148, 25)
    Me.TxtGLDay.MaxLength = 2
    Me.TxtGLDay.Name = "TxtGLDay"
    Me.TxtGLDay.Size = New System.Drawing.Size(20, 20)
    Me.TxtGLDay.TabIndex = 1
    '
    'TxtGLMonth
    '
    Me.TxtGLMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGLMonth.Location = New System.Drawing.Point(124, 25)
    Me.TxtGLMonth.MaxLength = 2
    Me.TxtGLMonth.Name = "TxtGLMonth"
    Me.TxtGLMonth.Size = New System.Drawing.Size(20, 20)
    Me.TxtGLMonth.TabIndex = 0
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(12, 25)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(84, 16)
    Me.Label3.TabIndex = 68
    Me.Label3.Text = "Grand List Date"
    '
    'GrpRE
    '
    Me.GrpRE.Controls.Add(Me.ChkAllBanks)
    Me.GrpRE.Controls.Add(Me.TxtBankCd)
    Me.GrpRE.Controls.Add(Me.LnkBankCd)
    Me.GrpRE.Controls.Add(Me.RbSelAll)
    Me.GrpRE.Controls.Add(Me.RbSelNon)
    Me.GrpRE.Controls.Add(Me.RbSelNonBanks)
    Me.GrpRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpRE.Location = New System.Drawing.Point(12, 229)
    Me.GrpRE.Name = "GrpRE"
    Me.GrpRE.Size = New System.Drawing.Size(208, 119)
    Me.GrpRE.TabIndex = 7
    Me.GrpRE.TabStop = False
    Me.GrpRE.Text = "Real Estate"
    '
    'ChkAllBanks
    '
    Me.ChkAllBanks.AutoSize = True
    Me.ChkAllBanks.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAllBanks.Enabled = False
    Me.ChkAllBanks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkAllBanks.Location = New System.Drawing.Point(25, 98)
    Me.ChkAllBanks.Name = "ChkAllBanks"
    Me.ChkAllBanks.Size = New System.Drawing.Size(114, 17)
    Me.ChkAllBanks.TabIndex = 167
    Me.ChkAllBanks.Text = "All Escrow Banks?"
    Me.ChkAllBanks.UseVisualStyleBackColor = True
    '
    'TxtBankCd
    '
    Me.TxtBankCd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBankCd.Enabled = False
    Me.TxtBankCd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBankCd.Location = New System.Drawing.Point(176, 74)
    Me.TxtBankCd.MaxLength = 2
    Me.TxtBankCd.Name = "TxtBankCd"
    Me.TxtBankCd.Size = New System.Drawing.Size(24, 20)
    Me.TxtBankCd.TabIndex = 165
    '
    'LnkBankCd
    '
    Me.LnkBankCd.Enabled = False
    Me.LnkBankCd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkBankCd.Location = New System.Drawing.Point(22, 77)
    Me.LnkBankCd.Name = "LnkBankCd"
    Me.LnkBankCd.Size = New System.Drawing.Size(148, 18)
    Me.LnkBankCd.TabIndex = 166
    Me.LnkBankCd.TabStop = True
    Me.LnkBankCd.Text = "Escrow Bank only (optional)"
    '
    'RbSelAll
    '
    Me.RbSelAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSelAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSelAll.Location = New System.Drawing.Point(4, 56)
    Me.RbSelAll.Name = "RbSelAll"
    Me.RbSelAll.Size = New System.Drawing.Size(196, 18)
    Me.RbSelAll.TabIndex = 77
    Me.RbSelAll.Text = "All Accounts (or an escrow bank)"
    '
    'RbSelNon
    '
    Me.RbSelNon.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSelNon.Checked = True
    Me.RbSelNon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSelNon.Location = New System.Drawing.Point(4, 16)
    Me.RbSelNon.Name = "RbSelNon"
    Me.RbSelNon.Size = New System.Drawing.Size(196, 20)
    Me.RbSelNon.TabIndex = 75
    Me.RbSelNon.TabStop = True
    Me.RbSelNon.Text = "Non Escrow Accounts Only "
    '
    'RbSelNonBanks
    '
    Me.RbSelNonBanks.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSelNonBanks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSelNonBanks.Location = New System.Drawing.Point(4, 36)
    Me.RbSelNonBanks.Name = "RbSelNonBanks"
    Me.RbSelNonBanks.Size = New System.Drawing.Size(196, 20)
    Me.RbSelNonBanks.TabIndex = 76
    Me.RbSelNonBanks.Text = "Non Escrow Accounts Plus Banks"
    '
    'GrpProrate
    '
    Me.GrpProrate.Controls.Add(Me.Label12)
    Me.GrpProrate.Controls.Add(Me.DtPckProGrace2)
    Me.GrpProrate.Controls.Add(Me.Label8)
    Me.GrpProrate.Controls.Add(Me.DtPckProGrace1)
    Me.GrpProrate.Controls.Add(Me.Label6)
    Me.GrpProrate.Controls.Add(Me.DtPckProDue2)
    Me.GrpProrate.Controls.Add(Me.Label5)
    Me.GrpProrate.Controls.Add(Me.DtPckProDue1)
    Me.GrpProrate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpProrate.Location = New System.Drawing.Point(232, 229)
    Me.GrpProrate.Name = "GrpProrate"
    Me.GrpProrate.Size = New System.Drawing.Size(352, 84)
    Me.GrpProrate.TabIndex = 8
    Me.GrpProrate.TabStop = False
    Me.GrpProrate.Text = "Prorates (For printing, ONLY Due Date 1 is saved)"
    '
    'Label12
    '
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(174, 56)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(73, 16)
    Me.Label12.TabIndex = 87
    Me.Label12.Text = "Grace Date 2"
    '
    'DtPckProGrace2
    '
    Me.DtPckProGrace2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckProGrace2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckProGrace2.Location = New System.Drawing.Point(253, 52)
    Me.DtPckProGrace2.Name = "DtPckProGrace2"
    Me.DtPckProGrace2.Size = New System.Drawing.Size(88, 20)
    Me.DtPckProGrace2.TabIndex = 85
    '
    'Label8
    '
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(174, 32)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(73, 16)
    Me.Label8.TabIndex = 86
    Me.Label8.Text = "Grace Date 1"
    '
    'DtPckProGrace1
    '
    Me.DtPckProGrace1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckProGrace1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckProGrace1.Location = New System.Drawing.Point(253, 28)
    Me.DtPckProGrace1.Name = "DtPckProGrace1"
    Me.DtPckProGrace1.Size = New System.Drawing.Size(88, 20)
    Me.DtPckProGrace1.TabIndex = 84
    '
    'Label6
    '
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(10, 56)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(64, 16)
    Me.Label6.TabIndex = 83
    Me.Label6.Text = "Due Date 2"
    '
    'DtPckProDue2
    '
    Me.DtPckProDue2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckProDue2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckProDue2.Location = New System.Drawing.Point(80, 52)
    Me.DtPckProDue2.Name = "DtPckProDue2"
    Me.DtPckProDue2.Size = New System.Drawing.Size(88, 20)
    Me.DtPckProDue2.TabIndex = 82
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(10, 34)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(64, 16)
    Me.Label5.TabIndex = 81
    Me.Label5.Text = "Due Date 1"
    '
    'DtPckProDue1
    '
    Me.DtPckProDue1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckProDue1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckProDue1.Location = New System.Drawing.Point(80, 28)
    Me.DtPckProDue1.Name = "DtPckProDue1"
    Me.DtPckProDue1.Size = New System.Drawing.Size(88, 20)
    Me.DtPckProDue1.TabIndex = 80
    '
    'LblMsg
    '
    Me.LblMsg.ForeColor = System.Drawing.Color.Magenta
    Me.LblMsg.Location = New System.Drawing.Point(12, 9)
    Me.LblMsg.Name = "LblMsg"
    Me.LblMsg.Size = New System.Drawing.Size(372, 16)
    Me.LblMsg.TabIndex = 82
    '
    'GrpDownload
    '
    Me.GrpDownload.Controls.Add(Me.ChkBarcode)
    Me.GrpDownload.Controls.Add(Me.ChkAlternative)
    Me.GrpDownload.Controls.Add(Me.ChkHeadings)
    Me.GrpDownload.Controls.Add(Me.RbCSV)
    Me.GrpDownload.Controls.Add(Me.RbFixed)
    Me.GrpDownload.Controls.Add(Me.LblFilePath)
    Me.GrpDownload.Controls.Add(Me.LnkFilePath)
    Me.GrpDownload.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpDownload.ForeColor = System.Drawing.Color.Black
    Me.GrpDownload.Location = New System.Drawing.Point(12, 379)
    Me.GrpDownload.Name = "GrpDownload"
    Me.GrpDownload.Size = New System.Drawing.Size(429, 102)
    Me.GrpDownload.TabIndex = 309
    Me.GrpDownload.TabStop = False
    Me.GrpDownload.Text = "Download to PC: REBILL File Details (optional)"
    '
    'ChkBarcode
    '
    Me.ChkBarcode.AutoSize = True
    Me.ChkBarcode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkBarcode.Enabled = False
    Me.ChkBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkBarcode.Location = New System.Drawing.Point(71, 79)
    Me.ChkBarcode.Name = "ChkBarcode"
    Me.ChkBarcode.Size = New System.Drawing.Size(138, 17)
    Me.ChkBarcode.TabIndex = 72
    Me.ChkBarcode.Text = "Append with Bar Code?"
    Me.ChkBarcode.UseVisualStyleBackColor = True
    '
    'ChkAlternative
    '
    Me.ChkAlternative.AutoSize = True
    Me.ChkAlternative.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAlternative.Enabled = False
    Me.ChkAlternative.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkAlternative.Location = New System.Drawing.Point(71, 57)
    Me.ChkAlternative.Name = "ChkAlternative"
    Me.ChkAlternative.Size = New System.Drawing.Size(135, 17)
    Me.ChkAlternative.TabIndex = 71
    Me.ChkAlternative.Text = "Use alternative format?"
    Me.ChkAlternative.UseVisualStyleBackColor = True
    '
    'ChkHeadings
    '
    Me.ChkHeadings.AutoSize = True
    Me.ChkHeadings.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkHeadings.Checked = True
    Me.ChkHeadings.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkHeadings.Enabled = False
    Me.ChkHeadings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkHeadings.Location = New System.Drawing.Point(264, 57)
    Me.ChkHeadings.Name = "ChkHeadings"
    Me.ChkHeadings.Size = New System.Drawing.Size(140, 17)
    Me.ChkHeadings.TabIndex = 70
    Me.ChkHeadings.Text = "Include Field Headings?"
    Me.ChkHeadings.UseVisualStyleBackColor = True
    '
    'RbCSV
    '
    Me.RbCSV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbCSV.Enabled = False
    Me.RbCSV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCSV.Location = New System.Drawing.Point(247, 34)
    Me.RbCSV.Name = "RbCSV"
    Me.RbCSV.Size = New System.Drawing.Size(157, 17)
    Me.RbCSV.TabIndex = 69
    Me.RbCSV.Text = "Comma Seperated (CSV)"
    Me.RbCSV.UseVisualStyleBackColor = True
    '
    'RbFixed
    '
    Me.RbFixed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbFixed.Checked = True
    Me.RbFixed.Enabled = False
    Me.RbFixed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFixed.Location = New System.Drawing.Point(56, 34)
    Me.RbFixed.Name = "RbFixed"
    Me.RbFixed.Size = New System.Drawing.Size(123, 17)
    Me.RbFixed.TabIndex = 68
    Me.RbFixed.TabStop = True
    Me.RbFixed.Text = "Fixed Length (TXT)"
    Me.RbFixed.UseVisualStyleBackColor = True
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(68, 16)
    Me.LblFilePath.Name = "LblFilePath"
    Me.LblFilePath.Size = New System.Drawing.Size(346, 16)
    Me.LblFilePath.TabIndex = 67
    '
    'LnkFilePath
    '
    Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePath.Location = New System.Drawing.Point(10, 16)
    Me.LnkFilePath.Name = "LnkFilePath"
    Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath.TabIndex = 0
    Me.LnkFilePath.TabStop = True
    Me.LnkFilePath.Text = "File Path"
    '
    'ChkUpdateDist
    '
    Me.ChkUpdateDist.AutoSize = True
    Me.ChkUpdateDist.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkUpdateDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkUpdateDist.ForeColor = System.Drawing.Color.Black
    Me.ChkUpdateDist.Location = New System.Drawing.Point(70, 512)
    Me.ChkUpdateDist.Name = "ChkUpdateDist"
    Me.ChkUpdateDist.Size = New System.Drawing.Size(145, 20)
    Me.ChkUpdateDist.TabIndex = 310
    Me.ChkUpdateDist.Text = "Update with district?"
    '
    'FrmTX301B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(593, 540)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkUpdateDist)
    Me.Controls.Add(Me.GrpDownload)
    Me.Controls.Add(Me.LblMsg)
    Me.Controls.Add(Me.GrpProrate)
    Me.Controls.Add(Me.GrpRE)
    Me.Controls.Add(Me.ChkUpdate)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtGLYear)
    Me.Controls.Add(Me.TxtGLDay)
    Me.Controls.Add(Me.TxtGLMonth)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.GrpSorting)
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.GroupBox2)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX301B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    Me.GrpSorting.ResumeLayout(False)
    Me.GrpRE.ResumeLayout(False)
    Me.GrpRE.PerformLayout()
    Me.GrpProrate.ResumeLayout(False)
    Me.GrpDownload.ResumeLayout(False)
    Me.GrpDownload.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

  Public Sub RunReport()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    CheckProfile()
    If LblMsg.Text <> "" Then Exit Sub

    Me.Refresh()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    If RbMV.Checked Then
      PrtReportMV()
    End If
    If RbRE.Checked Then
      PrtReportRE()
    End If
    If RbPP.Checked Then
      PrtReportPP()
    End If
    If RbProrate.Checked Then
      PrtReportProrate()
    End If
    If RbSU.Checked Then
      PrtReportSU()
    End If
    If RbRESwr.Checked Then
      PrtReportRESwr()
    End If
    If ChkUpdate.Checked Then
      UpdateTXPROF(WrkType, MyUtils.CnvSng(TxtGLYear.Text), MyUtils.CnvSng(TxtDist.Text))
    End If
    ChkHeadings.Enabled = False
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmTX301B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkYear As Integer
    WrkType = "R"
    TxtGLMonth.Text = "10"
    TxtGLDay.Text = "01"

    WrkYear = Date.Now.Year
    If Date.Now.Month < 10 Then
      WrkYear = WrkYear - 1
    End If
    TxtGLYear.Text = WrkYear
    GrpProrate.Visible = False
End Sub
Private Sub FrmTX301B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX301.SbpScreen.Text = "TX301B"
End Sub
Private Sub FrmTX301B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLYear, "")
    ErrProv.SetError(ChkAlternative, "")
    ErrProv.SetError(ChkHeadings, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "glyear"
        ErrProv.SetError(TxtGLYear, ErrorMsg(I))
      Case "decimal"
        ErrProv.SetError(ChkAlternative, ErrorMsg(I))
      Case "headings"
        ErrProv.SetError(ChkHeadings, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtGLYear.Text) = 0 Then
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "Invalid GL Year"
      I = I + 1
      End If

    If Not RbFixed.Checked And ChkAlternative.Checked Then
      ErrorField(I) = "decimal"
      ErrorMsg(I) = "Decimal is only valid for Fixed files"
      I = I + 1
    End If

    If LblFilePath.Text <> "" And Not RbCSV.Checked And ChkHeadings.Checked Then
      ErrorField(I) = "headings"
      ErrorMsg(I) = "Headings are only valid for CSV files"
      I = I + 1
    End If
End Sub
Private Sub RbMV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbMV.Click
  WrkType = "M"
  GrpRE.Visible = False
  GrpProrate.Visible = False
  TxtStateMoney.Enabled = True
  TxtStateMillRate.Enabled = True
  GrpDownload.Text = "Download to PC: MVBILL File Details (optional)"
  CheckProfile()
End Sub
Private Sub RbPP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPP.Click
  WrkType = "P"
  GrpRE.Visible = False
  GrpProrate.Visible = False
  TxtStateMoney.Enabled = True
  TxtStateMillRate.Enabled = True
  GrpDownload.Text = "Download to PC: PPBILL File Details (optional)"
  CheckProfile()
End Sub
Private Sub RbRE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbRE.Click
  WrkType = "R"
  GrpRE.Visible = True
  GrpProrate.Visible = False
  TxtStateMoney.Enabled = True
  TxtStateMillRate.Enabled = True
  GrpDownload.Text = "Download to PC: REBILL File Details (optional)"
  CheckProfile()
End Sub
Private Sub RbProrate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbProrate.Click
  WrkType = "X"
  GrpRE.Visible = False
  GrpProrate.Visible = True
  GrpProrate.Left = GrpRE.Left
  TxtStateMoney.Enabled = False
  TxtStateMillRate.Enabled = False
  GrpDownload.Text = "Download to PC: RPBILL File Details (optional)"
  CalcProrateDates()
  CheckProfile()
End Sub
Private Sub RbSU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSU.Click
  WrkType = "S"
  GrpRE.Visible = False
  GrpProrate.Visible = False
  TxtStateMoney.Enabled = True
  TxtStateMillRate.Enabled = True
  GrpDownload.Text = "Download to PC: MSBILL File Details (optional)"
  CheckProfile()
End Sub
Private Sub RbRESwr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbRESwr.Click
  WrkType = "R"
  GrpRE.Visible = True
  GrpProrate.Visible = False
  TxtStateMoney.Enabled = True
  TxtStateMillRate.Enabled = True
  GrpDownload.Text = "Download to PC: REBILL File Details (optional)"
  CheckProfile()
End Sub
Private Sub CalcProrateDates()
  Dim MyTXPROF As TXPROF.myData
  'TXPROF
  Dim ProfPrPerd As Integer
  Dim ProfTxDt(3) As Date
  Dim ProfGrDt(3) As Date
  Dim WrkDueDate As Date
  Dim WrkGraceDate As Date
  Dim WrkToday As Date

  LblMsg.Text = ""
  MyFrmTX301.TBarPrint.Enabled = False
  MyTXPROF = New TXPROF.myData(myDBConnect)
  MyTXPROF.GetOneRecordP("X", MyUtils.CnvSng(TxtGLYear.Text), "", 0)
  WrkToday = Date.Today
  If MyTXPROF.RecordNotFound Then
    LblMsg.Text = "Print disabled. Add via Bill Type Info program - " & WrkType & " " & TxtGLYear.Text
    Exit Sub
  End If

  MyFrmTX301.TBarPrint.Enabled = True
  With MyTXPROF
    ProfPrPerd = ._PRPERD
    ProfTxDt(0) = MyUtils.GetDBDateMDY(._PRDUE1)
    ProfTxDt(1) = MyUtils.GetDBDateMDY(._PRDUE2)
    ProfTxDt(2) = MyUtils.GetDBDateMDY(._PRDUE3)
    ProfTxDt(3) = MyUtils.GetDBDateMDY(._PRDUE4)
    ProfGrDt(0) = MyUtils.GetDBDateMDY(._PRGRD1)
    ProfGrDt(1) = MyUtils.GetDBDateMDY(._PRGRD2)
    ProfGrDt(2) = MyUtils.GetDBDateMDY(._PRGRD3)
    ProfGrDt(3) = MyUtils.GetDBDateMDY(._PRGRD4)
  End With

  WrkDueDate = WrkToday
  WrkGraceDate = DateAdd(DateInterval.Day, 30, WrkToday)
  If ProfPrPerd >= 2 Then
    If WrkDueDate <= ProfTxDt(1) Then
      WrkDueDate = ProfTxDt(1)
      WrkGraceDate = ProfGrDt(1)
    End If
  End If
  DtPckProDue1.Value = WrkToday
  DtPckProGrace1.Value = DateAdd(DateInterval.Day, 30, WrkToday)
  DtPckProDue2.Value = WrkDueDate
  DtPckProGrace2.Value = WrkGraceDate

End Sub
Private Sub CheckProfile()
  Dim MyTXPROF As TXPROF.myData
  Dim Answer As Integer

  LblMsg.Text = ""
  MyFrmTX301.TBarPrint.Enabled = False
  MyTXPROF = New TXPROF.myData(myDBConnect)
  MyTXPROF.GetOneRecordP(WrkType, MyUtils.CnvSng(TxtGLYear.Text), "", MyUtils.CnvSng(TxtDist.Text))
  If MyTXPROF.RecordNotFound Then
    LblMsg.Text = "Print disabled. Add via Bill Type Info program - " & WrkType & " " & TxtGLYear.Text
    Exit Sub
  Else
    If MyTXPROF._POSTED = "Y" And ChkUpdate.Checked Then
      Answer = MsgBox("Click OK to continue or Cancel to abort", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Bills have already been Posted")
      If Answer = MsgBoxResult.Cancel Then Exit Sub
    End If
  End If

  MyFrmTX301.TBarPrint.Enabled = True

End Sub
Private Sub FrmTX301B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub

   If e.KeyCode = Keys.F12 Then
     MyUtils.PrtScreen(Form.ActiveForm)
   End If
End Sub
Private Sub TxtGLMonth_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLMonth.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtGLDay_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLDay.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtGLYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtGLYear_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtGLYear.TextChanged
  CheckProfile()
End Sub
Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
  With SaveFileDialog1
    .ShowDialog()
    LblFilePath.Text = .FileName
  End With
  If LblFilePath.Text <> String.Empty Then
    RbFixed.Enabled = True
    RbFixed.Checked = True
    RbCSV.Enabled = True
    SetFileOptions(True)
  End If

End Sub
Private Sub RbSelNon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSelNon.Click
  LnkBankCd.Enabled = False
  TxtBankCd.Text = String.Empty
  TxtBankCd.Enabled = False
  ChkAllBanks.Enabled = False
End Sub
Private Sub RbSelNonBanks_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSelNonBanks.Click
  LnkBankCd.Enabled = False
  TxtBankCd.Text = String.Empty
  TxtBankCd.Enabled = False
  ChkAllBanks.Enabled = False
End Sub
Private Sub RbSelAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSelAll.Click
  LnkBankCd.Enabled = True
  TxtBankCd.Enabled = True
  ChkAllBanks.Enabled = True
End Sub
Private Sub LnkBankCd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBankCd.LinkClicked
  MyFrmListBanks = New FrmListBanks
  MyFrmListBanks.MdiParent = Me.ParentForm
  MyFrmListBanks.WrkCode = TxtBankCd.Text
  MyFrmListBanks.Show()
End Sub
  Private Sub UpdateTXPROF(ByVal Type As String, ByVal Year As Integer, ByVal Dist As Integer)
    Dim MyTXPROF As TXPROF.myData
    MyTXPROF = New TXPROF.myData(myDBConnect)
    MyTXPROF.GetOneRecordP(Type, Year, "", Dist)
    With MyTXPROF
      ._POSTED = "Y"
      .UpdateOneRecordP()
    End With
End Sub
  Private Sub RbFixed_Click(sender As Object, e As EventArgs) Handles RbFixed.Click
    SetFileOptions(True)
  End Sub
  Private Sub RbCSV_Click(sender As Object, e As EventArgs) Handles RbCSV.Click
    SetFileOptions(False)
  End Sub
Private Sub SetFileOptions(ByVal IsTxt As Boolean)
  ChkAlternative.Enabled = IsTxt
  ChkBarcode.Enabled = IsTxt
  ChkHeadings.Enabled = Not IsTxt
End Sub
End Class
