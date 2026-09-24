Public Class FrmTX350B
Inherits System.Windows.Forms.Form
Dim WrkType As String
Friend WithEvents ChkElderly As System.Windows.Forms.CheckBox
Dim WrkFamily As String
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
Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
Friend WithEvents RbPrtNoBill As System.Windows.Forms.RadioButton
Friend WithEvents RbPrtBill As System.Windows.Forms.RadioButton
Friend WithEvents RbSortZip As System.Windows.Forms.RadioButton
Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
Friend WithEvents GrpSorting As System.Windows.Forms.GroupBox
Friend WithEvents ChkUpdate As System.Windows.Forms.CheckBox
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents TxtGLDay As System.Windows.Forms.TextBox
Friend WithEvents TxtGLMonth As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtComment As System.Windows.Forms.TextBox
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
Friend WithEvents TxtType As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents LblTypeDesc As System.Windows.Forms.Label
Friend WithEvents GrpDownload As System.Windows.Forms.GroupBox
Friend WithEvents ChkBarcode As System.Windows.Forms.CheckBox
Friend WithEvents ChkAlternative As System.Windows.Forms.CheckBox
Friend WithEvents ChkHeadings As System.Windows.Forms.CheckBox
Friend WithEvents RbCSV As System.Windows.Forms.RadioButton
Friend WithEvents RbFixed As System.Windows.Forms.RadioButton
Friend WithEvents LblFilePath As System.Windows.Forms.Label
Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
Friend WithEvents GrpRE As System.Windows.Forms.GroupBox
Friend WithEvents TxtBankCd As System.Windows.Forms.TextBox
Friend WithEvents LnkBankCd As System.Windows.Forms.LinkLabel
Friend WithEvents RbSelAll As System.Windows.Forms.RadioButton
Friend WithEvents RbSelNon As System.Windows.Forms.RadioButton
Friend WithEvents RbSelNonBanks As System.Windows.Forms.RadioButton
Friend WithEvents LblMsg As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.GroupBox4 = New System.Windows.Forms.GroupBox
Me.TxtComment = New System.Windows.Forms.TextBox
Me.Label7 = New System.Windows.Forms.Label
Me.RbPrtNoBill = New System.Windows.Forms.RadioButton
Me.RbPrtBill = New System.Windows.Forms.RadioButton
Me.GrpSorting = New System.Windows.Forms.GroupBox
Me.RbSortZip = New System.Windows.Forms.RadioButton
Me.RbSortName = New System.Windows.Forms.RadioButton
Me.ChkUpdate = New System.Windows.Forms.CheckBox
Me.TxtDist = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.TxtGLYear = New System.Windows.Forms.TextBox
Me.TxtGLDay = New System.Windows.Forms.TextBox
Me.TxtGLMonth = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.LblMsg = New System.Windows.Forms.Label
Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
Me.TxtType = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.LblTypeDesc = New System.Windows.Forms.Label
Me.GrpDownload = New System.Windows.Forms.GroupBox
Me.ChkBarcode = New System.Windows.Forms.CheckBox
Me.ChkAlternative = New System.Windows.Forms.CheckBox
Me.ChkHeadings = New System.Windows.Forms.CheckBox
Me.RbCSV = New System.Windows.Forms.RadioButton
Me.RbFixed = New System.Windows.Forms.RadioButton
Me.LblFilePath = New System.Windows.Forms.Label
Me.LnkFilePath = New System.Windows.Forms.LinkLabel
Me.GrpRE = New System.Windows.Forms.GroupBox
Me.ChkElderly = New System.Windows.Forms.CheckBox
Me.TxtBankCd = New System.Windows.Forms.TextBox
Me.LnkBankCd = New System.Windows.Forms.LinkLabel
Me.RbSelAll = New System.Windows.Forms.RadioButton
Me.RbSelNon = New System.Windows.Forms.RadioButton
Me.RbSelNonBanks = New System.Windows.Forms.RadioButton
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox4.SuspendLayout()
Me.GrpSorting.SuspendLayout()
Me.GrpDownload.SuspendLayout()
Me.GrpRE.SuspendLayout()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'GroupBox4
'
Me.GroupBox4.Controls.Add(Me.TxtComment)
Me.GroupBox4.Controls.Add(Me.Label7)
Me.GroupBox4.Controls.Add(Me.RbPrtNoBill)
Me.GroupBox4.Controls.Add(Me.RbPrtBill)
Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox4.Location = New System.Drawing.Point(15, 100)
Me.GroupBox4.Name = "GroupBox4"
Me.GroupBox4.Size = New System.Drawing.Size(365, 68)
Me.GroupBox4.TabIndex = 5
Me.GroupBox4.TabStop = False
Me.GroupBox4.Text = "Bill Printing"
'
'TxtComment
'
Me.TxtComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtComment.Location = New System.Drawing.Point(190, 40)
Me.TxtComment.MaxLength = 25
Me.TxtComment.Name = "TxtComment"
Me.TxtComment.Size = New System.Drawing.Size(168, 20)
Me.TxtComment.TabIndex = 73
'
'Label7
'
Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label7.Location = New System.Drawing.Point(6, 40)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(180, 16)
Me.Label7.TabIndex = 76
Me.Label7.Text = "Miscellaneous Comment On Bill"
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
Me.GrpSorting.Location = New System.Drawing.Point(375, 12)
Me.GrpSorting.Name = "GrpSorting"
Me.GrpSorting.Size = New System.Drawing.Size(122, 60)
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
Me.ChkUpdate.Location = New System.Drawing.Point(13, 411)
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
'LblMsg
'
Me.LblMsg.ForeColor = System.Drawing.Color.Magenta
Me.LblMsg.Location = New System.Drawing.Point(12, 9)
Me.LblMsg.Name = "LblMsg"
Me.LblMsg.Size = New System.Drawing.Size(372, 16)
Me.LblMsg.TabIndex = 82
'
'TxtType
'
Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtType.Location = New System.Drawing.Point(124, 72)
Me.TxtType.MaxLength = 1
Me.TxtType.Name = "TxtType"
Me.TxtType.Size = New System.Drawing.Size(20, 20)
Me.TxtType.TabIndex = 4
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(12, 76)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(84, 16)
Me.Label2.TabIndex = 311
Me.Label2.Text = "Tax Type Code"
'
'LblTypeDesc
'
Me.LblTypeDesc.ForeColor = System.Drawing.Color.Magenta
Me.LblTypeDesc.Location = New System.Drawing.Point(160, 76)
Me.LblTypeDesc.Name = "LblTypeDesc"
Me.LblTypeDesc.Size = New System.Drawing.Size(234, 16)
Me.LblTypeDesc.TabIndex = 312
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
Me.GrpDownload.Location = New System.Drawing.Point(16, 303)
Me.GrpDownload.Name = "GrpDownload"
Me.GrpDownload.Size = New System.Drawing.Size(429, 102)
Me.GrpDownload.TabIndex = 313
Me.GrpDownload.TabStop = False
Me.GrpDownload.Text = "Download to PC"
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
'GrpRE
'
Me.GrpRE.Controls.Add(Me.ChkElderly)
Me.GrpRE.Controls.Add(Me.TxtBankCd)
Me.GrpRE.Controls.Add(Me.LnkBankCd)
Me.GrpRE.Controls.Add(Me.RbSelAll)
Me.GrpRE.Controls.Add(Me.RbSelNon)
Me.GrpRE.Controls.Add(Me.RbSelNonBanks)
Me.GrpRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GrpRE.Location = New System.Drawing.Point(16, 174)
Me.GrpRE.Name = "GrpRE"
Me.GrpRE.Size = New System.Drawing.Size(208, 123)
Me.GrpRE.TabIndex = 314
Me.GrpRE.TabStop = False
Me.GrpRE.Text = "Real Estate"
'
'ChkElderly
'
Me.ChkElderly.AutoSize = True
Me.ChkElderly.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkElderly.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.ChkElderly.Location = New System.Drawing.Point(8, 19)
Me.ChkElderly.Name = "ChkElderly"
Me.ChkElderly.Size = New System.Drawing.Size(149, 17)
Me.ChkElderly.TabIndex = 0
Me.ChkElderly.Text = "Include Elderly Accounts?"
Me.ChkElderly.UseVisualStyleBackColor = True
'
'TxtBankCd
'
Me.TxtBankCd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtBankCd.Enabled = False
Me.TxtBankCd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtBankCd.Location = New System.Drawing.Point(178, 94)
Me.TxtBankCd.MaxLength = 2
Me.TxtBankCd.Name = "TxtBankCd"
Me.TxtBankCd.Size = New System.Drawing.Size(24, 20)
Me.TxtBankCd.TabIndex = 5
'
'LnkBankCd
'
Me.LnkBankCd.Enabled = False
Me.LnkBankCd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkBankCd.Location = New System.Drawing.Point(24, 97)
Me.LnkBankCd.Name = "LnkBankCd"
Me.LnkBankCd.Size = New System.Drawing.Size(148, 18)
Me.LnkBankCd.TabIndex = 4
Me.LnkBankCd.TabStop = True
Me.LnkBankCd.Text = "Escrow Bank only (optional)"
'
'RbSelAll
'
Me.RbSelAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbSelAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbSelAll.Location = New System.Drawing.Point(6, 76)
Me.RbSelAll.Name = "RbSelAll"
Me.RbSelAll.Size = New System.Drawing.Size(196, 18)
Me.RbSelAll.TabIndex = 3
Me.RbSelAll.Text = "All Accounts (or an escrow bank)"
'
'RbSelNon
'
Me.RbSelNon.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbSelNon.Checked = True
Me.RbSelNon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbSelNon.Location = New System.Drawing.Point(6, 36)
Me.RbSelNon.Name = "RbSelNon"
Me.RbSelNon.Size = New System.Drawing.Size(196, 20)
Me.RbSelNon.TabIndex = 1
Me.RbSelNon.TabStop = True
Me.RbSelNon.Text = "Non Escrow Accounts Only "
'
'RbSelNonBanks
'
Me.RbSelNonBanks.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbSelNonBanks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbSelNonBanks.Location = New System.Drawing.Point(6, 56)
Me.RbSelNonBanks.Name = "RbSelNonBanks"
Me.RbSelNonBanks.Size = New System.Drawing.Size(196, 20)
Me.RbSelNonBanks.TabIndex = 2
Me.RbSelNonBanks.Text = "Non Escrow Accounts Plus Banks"
'
'FrmTX350B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(506, 441)
Me.ControlBox = False
Me.Controls.Add(Me.GrpRE)
Me.Controls.Add(Me.GrpDownload)
Me.Controls.Add(Me.LblTypeDesc)
Me.Controls.Add(Me.TxtType)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.LblMsg)
Me.Controls.Add(Me.ChkUpdate)
Me.Controls.Add(Me.TxtDist)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtGLYear)
Me.Controls.Add(Me.TxtGLDay)
Me.Controls.Add(Me.TxtGLMonth)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.GrpSorting)
Me.Controls.Add(Me.GroupBox4)
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX350B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox4.ResumeLayout(False)
Me.GroupBox4.PerformLayout()
Me.GrpSorting.ResumeLayout(False)
Me.GrpDownload.ResumeLayout(False)
Me.GrpDownload.PerformLayout()
Me.GrpRE.ResumeLayout(False)
Me.GrpRE.PerformLayout()
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
  PrtReport()
  If ChkUpdate.Checked Then
   UpdateTXPROF(WrkType, MyUtils.CnvSng(TxtGLYear.Text), MyUtils.CnvSng(TxtDist.Text))
  End If
  Windows.Forms.Cursor.Current = Cursors.Default

 End Sub
Private Sub FrmTX350B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Dim WrkYear As Integer
  WrkType = ""
  TxtGLMonth.Text = "10"
  TxtGLDay.Text = "01"

  WrkYear = Date.Now.Year
  If Date.Now.Month < 10 Then
   WrkYear = WrkYear - 1
  End If
  TxtGLYear.Text = WrkYear
  GrpRE.Enabled = False
End Sub
Private Sub FrmTX350B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
 MyFrmTX350.SbpScreen.Text = "TX350B"
End Sub
Private Sub FrmTX350B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
 Me.Refresh()
End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtGLYear, "")
  ErrProv.SetError(TxtType, "")
  ErrProv.SetError(ChkAlternative, "")
  ErrProv.SetError(ChkHeadings, "")

  For I = 0 To ErrorField.GetUpperBound(0)
   Select Case ErrorField(I)
   Case "glyear"
    ErrProv.SetError(TxtGLYear, ErrorMsg(I))
   Case "type"
    ErrProv.SetError(TxtType, ErrorMsg(I))
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

  If WrkType = WrkFamily Then
   ErrorField(I) = "type"
   ErrorMsg(I) = "Invalid Type"
   I = I + 1
  End If

  If WrkFamily <> "R" And WrkFamily <> "P" And WrkFamily <> "M" And WrkFamily <> "S" Then
   ErrorField(I) = "type"
   ErrorMsg(I) = "Invalid Type"
   I = I + 1
  End If

  If Not RbFixed.Checked And ChkAlternative.Checked Then
   ErrorField(I) = "decimal"
   ErrorMsg(I) = "Decimal is only valid for Fixed files"
   I = I + 1
  End If

  If Not RbCSV.Checked And ChkHeadings.Checked Then
   ErrorField(I) = "headings"
   ErrorMsg(I) = "Headings are only valid for CSV files"
   I = I + 1
  End If
 End Sub
Private Sub CheckProfile()
 Dim MyTXPROF As TXPROF.myData
 Dim Answer As Integer

 LblMsg.Text = ""
 MyFrmTX350.TBarPrint.Enabled = False
 MyTXPROF = New TXPROF.mydata(MyDBConnect)
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

 MyFrmTX350.TBarPrint.Enabled = True

End Sub
Private Sub FrmTX350B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
Private Sub TxtType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtType.TextChanged
 WrkType = TxtType.Text
 LblTypeDesc.Text = GetTXTypeDesc(WrkType)
 CheckProfile()
 WrkFamily = GetTXTypeFamily(WrkType)
 If WrkFamily = "R" Then
   GrpRE.Enabled = True
 Else
   GrpRE.Enabled = False
 End If

End Sub
Private Sub RbPrtNoBill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPrtNoBill.Click
 TxtComment.Enabled = False
End Sub
Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
 With SaveFileDialog1
  .ShowDialog()
  LblFilePath.Text = .FileName
 End With
 If LblFilePath.Text <> String.Empty Then
  RbFixed.Enabled = True
  ChkAlternative.Enabled = True
  ChkBarcode.Enabled = True
  RbCSV.Enabled = True
  ChkHeadings.Enabled = True
 End If

End Sub
Private Sub RbSelNon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSelNon.Click
 LnkBankCd.Enabled = False
 TxtBankCd.Text = String.Empty
 TxtBankCd.Enabled = False
End Sub
Private Sub RbSelNonBanks_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSelNonBanks.Click
 LnkBankCd.Enabled = False
 TxtBankCd.Text = String.Empty
 TxtBankCd.Enabled = False
End Sub
Private Sub RbSelAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSelAll.Click
 LnkBankCd.Enabled = True
 TxtBankCd.Enabled = True
End Sub
Private Sub LnkBankCd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBankCd.LinkClicked
 MyFrmListBanks = New FrmListBanks
 MyFrmListBanks.MdiParent = Me.ParentForm
 MyFrmListBanks.WrkCode = TxtBankCd.Text
 MyFrmListBanks.Show()
End Sub
 Private Sub UpdateTXPROF(ByVal Type As String, ByVal Year As Integer, ByVal Dist As Integer)
  Dim MyTXPROF As TXPROF.myData
  MyTXPROF = New TXPROF.mydata(MyDBConnect)
  MyTXPROF.GetOneRecordP(Type, Year, "", Dist)
  With MyTXPROF
   ._POSTED = "Y"
   .UpdateOneRecordP()
  End With
End Sub
End Class






