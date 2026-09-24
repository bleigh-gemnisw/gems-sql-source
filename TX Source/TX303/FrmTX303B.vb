Public Class FrmTX303B
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
  Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents DtPckInt As System.Windows.Forms.DateTimePicker
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbSortZip As System.Windows.Forms.RadioButton
Friend WithEvents RbSortList As System.Windows.Forms.RadioButton
Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
Friend WithEvents TxtType As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
  Friend WithEvents LblFilePath As System.Windows.Forms.Label
  Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
  Friend WithEvents ChkBills As System.Windows.Forms.CheckBox
  Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
  Friend WithEvents ChkHeadings As System.Windows.Forms.CheckBox
  Friend WithEvents RbCSV As System.Windows.Forms.RadioButton
  Friend WithEvents RbFixed As System.Windows.Forms.RadioButton
  Friend WithEvents TxtStatus As System.Windows.Forms.TextBox
  Friend WithEvents LinkStatus As System.Windows.Forms.LinkLabel
  Friend WithEvents GroupBox4 As GroupBox
  Friend WithEvents TxtLease As TextBox
  Friend WithEvents Label5 As Label
  Friend WithEvents ChkOmitBanks As CheckBox
  Friend WithEvents TxtOmitAbove As TextBox
  Friend WithEvents Label7 As Label
  Friend WithEvents LnkDistrict As LinkLabel
  Friend WithEvents TxtPhase As TextBox
  Friend WithEvents Label12 As Label
  Friend WithEvents ChkInGracePeriod As CheckBox
  Friend WithEvents TxtBankCode As TextBox
  Friend WithEvents Label11 As Label
  Friend WithEvents TxtOmitBelow As TextBox
  Friend WithEvents Label10 As Label
  Friend WithEvents ChkOmitSuspense As CheckBox
  Friend WithEvents TxtInvCode As TextBox
  Friend WithEvents Label8 As Label
  Friend WithEvents TxtDist As TextBox
  Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtFromGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.DtPckInt = New System.Windows.Forms.DateTimePicker()
    Me.TxtToGLYear = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbSortZip = New System.Windows.Forms.RadioButton()
    Me.RbSortList = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.LnkType = New System.Windows.Forms.LinkLabel()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.ChkHeadings = New System.Windows.Forms.CheckBox()
    Me.RbCSV = New System.Windows.Forms.RadioButton()
    Me.RbFixed = New System.Windows.Forms.RadioButton()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.ChkBills = New System.Windows.Forms.CheckBox()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.TxtStatus = New System.Windows.Forms.TextBox()
    Me.LinkStatus = New System.Windows.Forms.LinkLabel()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.ChkOmitBanks = New System.Windows.Forms.CheckBox()
    Me.TxtOmitAbove = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.LnkDistrict = New System.Windows.Forms.LinkLabel()
    Me.TxtPhase = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.ChkInGracePeriod = New System.Windows.Forms.CheckBox()
    Me.TxtBankCode = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TxtOmitBelow = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.ChkOmitSuspense = New System.Windows.Forms.CheckBox()
    Me.TxtInvCode = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.TxtLease = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox6.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.SuspendLayout()
    '
    'TxtFromGLYear
    '
    Me.TxtFromGLYear.Location = New System.Drawing.Point(113, 74)
    Me.TxtFromGLYear.MaxLength = 4
    Me.TxtFromGLYear.Name = "TxtFromGLYear"
    Me.TxtFromGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtFromGLYear.TabIndex = 2
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(17, 78)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(80, 13)
    Me.Label4.TabIndex = 11
    Me.Label4.Text = "Grand List Year"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'DtPckInt
    '
    Me.DtPckInt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckInt.Location = New System.Drawing.Point(113, 98)
    Me.DtPckInt.Name = "DtPckInt"
    Me.DtPckInt.Size = New System.Drawing.Size(88, 20)
    Me.DtPckInt.TabIndex = 4
    Me.DtPckInt.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
    '
    'TxtToGLYear
    '
    Me.TxtToGLYear.Location = New System.Drawing.Point(177, 74)
    Me.TxtToGLYear.MaxLength = 4
    Me.TxtToGLYear.Name = "TxtToGLYear"
    Me.TxtToGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtToGLYear.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(149, 78)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(20, 16)
    Me.Label2.TabIndex = 20
    Me.Label2.Text = "To "
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(17, 102)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(68, 13)
    Me.Label3.TabIndex = 21
    Me.Label3.Text = "Interest Date"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbSortZip)
    Me.GroupBox2.Controls.Add(Me.RbSortList)
    Me.GroupBox2.Controls.Add(Me.RbSortName)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(272, 12)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(116, 80)
    Me.GroupBox2.TabIndex = 7
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Sort Options"
    '
    'RbSortZip
    '
    Me.RbSortZip.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortZip.Checked = True
    Me.RbSortZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortZip.Location = New System.Drawing.Point(12, 16)
    Me.RbSortZip.Name = "RbSortZip"
    Me.RbSortZip.Size = New System.Drawing.Size(92, 20)
    Me.RbSortZip.TabIndex = 0
    Me.RbSortZip.TabStop = True
    Me.RbSortZip.Text = "Zip/Name"
    '
    'RbSortList
    '
    Me.RbSortList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortList.Location = New System.Drawing.Point(12, 56)
    Me.RbSortList.Name = "RbSortList"
    Me.RbSortList.Size = New System.Drawing.Size(92, 20)
    Me.RbSortList.TabIndex = 2
    Me.RbSortList.Text = "List #"
    '
    'RbSortName
    '
    Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortName.Location = New System.Drawing.Point(12, 36)
    Me.RbSortName.Name = "RbSortName"
    Me.RbSortName.Size = New System.Drawing.Size(92, 20)
    Me.RbSortName.TabIndex = 1
    Me.RbSortName.Text = "Name"
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Location = New System.Drawing.Point(113, 24)
    Me.TxtType.MaxLength = 1
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(16, 20)
    Me.TxtType.TabIndex = 0
    '
    'LnkType
    '
    Me.LnkType.Location = New System.Drawing.Point(23, 28)
    Me.LnkType.Name = "LnkType"
    Me.LnkType.Size = New System.Drawing.Size(80, 16)
    Me.LnkType.TabIndex = 62
    Me.LnkType.TabStop = True
    Me.LnkType.Text = "Type to print"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.GroupBox6)
    Me.GroupBox1.Controls.Add(Me.ChkBills)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox1.Location = New System.Drawing.Point(11, 128)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(377, 132)
    Me.GroupBox1.TabIndex = 6
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Bills"
    '
    'GroupBox6
    '
    Me.GroupBox6.Controls.Add(Me.ChkHeadings)
    Me.GroupBox6.Controls.Add(Me.RbCSV)
    Me.GroupBox6.Controls.Add(Me.RbFixed)
    Me.GroupBox6.Controls.Add(Me.LblFilePath)
    Me.GroupBox6.Controls.Add(Me.LnkFilePath)
    Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox6.ForeColor = System.Drawing.Color.Black
    Me.GroupBox6.Location = New System.Drawing.Point(7, 37)
    Me.GroupBox6.Name = "GroupBox6"
    Me.GroupBox6.Size = New System.Drawing.Size(361, 89)
    Me.GroupBox6.TabIndex = 308
    Me.GroupBox6.TabStop = False
    Me.GroupBox6.Text = "Download to PC: DELQBILL File Details (optional)"
    '
    'ChkHeadings
    '
    Me.ChkHeadings.AutoSize = True
    Me.ChkHeadings.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkHeadings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkHeadings.Location = New System.Drawing.Point(200, 65)
    Me.ChkHeadings.Name = "ChkHeadings"
    Me.ChkHeadings.Size = New System.Drawing.Size(140, 17)
    Me.ChkHeadings.TabIndex = 70
    Me.ChkHeadings.Text = "Include Field Headings?"
    Me.ChkHeadings.UseVisualStyleBackColor = True
    '
    'RbCSV
    '
    Me.RbCSV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbCSV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCSV.Location = New System.Drawing.Point(183, 49)
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
    Me.RbFixed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFixed.Location = New System.Drawing.Point(8, 49)
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
    Me.LblFilePath.Size = New System.Drawing.Size(284, 30)
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
    'ChkBills
    '
    Me.ChkBills.AutoSize = True
    Me.ChkBills.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkBills.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkBills.ForeColor = System.Drawing.Color.Black
    Me.ChkBills.Location = New System.Drawing.Point(6, 15)
    Me.ChkBills.Name = "ChkBills"
    Me.ChkBills.Size = New System.Drawing.Size(74, 17)
    Me.ChkBills.TabIndex = 0
    Me.ChkBills.Text = "Print Bills?"
    '
    'TxtStatus
    '
    Me.TxtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtStatus.Location = New System.Drawing.Point(113, 49)
    Me.TxtStatus.MaxLength = 20
    Me.TxtStatus.Name = "TxtStatus"
    Me.TxtStatus.Size = New System.Drawing.Size(129, 20)
    Me.TxtStatus.TabIndex = 1
    '
    'LinkStatus
    '
    Me.LinkStatus.AutoSize = True
    Me.LinkStatus.Location = New System.Drawing.Point(17, 51)
    Me.LinkStatus.Name = "LinkStatus"
    Me.LinkStatus.Size = New System.Drawing.Size(94, 13)
    Me.LinkStatus.TabIndex = 71
    Me.LinkStatus.TabStop = True
    Me.LinkStatus.Text = "Omit Status Codes"
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.TxtLease)
    Me.GroupBox4.Controls.Add(Me.Label5)
    Me.GroupBox4.Controls.Add(Me.ChkOmitBanks)
    Me.GroupBox4.Controls.Add(Me.TxtOmitAbove)
    Me.GroupBox4.Controls.Add(Me.Label7)
    Me.GroupBox4.Controls.Add(Me.LnkDistrict)
    Me.GroupBox4.Controls.Add(Me.TxtPhase)
    Me.GroupBox4.Controls.Add(Me.Label12)
    Me.GroupBox4.Controls.Add(Me.ChkInGracePeriod)
    Me.GroupBox4.Controls.Add(Me.TxtBankCode)
    Me.GroupBox4.Controls.Add(Me.Label11)
    Me.GroupBox4.Controls.Add(Me.TxtOmitBelow)
    Me.GroupBox4.Controls.Add(Me.Label10)
    Me.GroupBox4.Controls.Add(Me.ChkOmitSuspense)
    Me.GroupBox4.Controls.Add(Me.TxtInvCode)
    Me.GroupBox4.Controls.Add(Me.Label8)
    Me.GroupBox4.Controls.Add(Me.TxtDist)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(394, 12)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(160, 248)
    Me.GroupBox4.TabIndex = 72
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Optional Selections"
    '
    'ChkOmitBanks
    '
    Me.ChkOmitBanks.AutoSize = True
    Me.ChkOmitBanks.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkOmitBanks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkOmitBanks.Location = New System.Drawing.Point(11, 95)
    Me.ChkOmitBanks.Name = "ChkOmitBanks"
    Me.ChkOmitBanks.Size = New System.Drawing.Size(115, 17)
    Me.ChkOmitBanks.TabIndex = 301
    Me.ChkOmitBanks.Text = "Omit Bank Coded?"
    '
    'TxtOmitAbove
    '
    Me.TxtOmitAbove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOmitAbove.Location = New System.Drawing.Point(100, 165)
    Me.TxtOmitAbove.MaxLength = 6
    Me.TxtOmitAbove.Name = "TxtOmitAbove"
    Me.TxtOmitAbove.Size = New System.Drawing.Size(39, 20)
    Me.TxtOmitAbove.TabIndex = 5
    '
    'Label7
    '
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(11, 168)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(86, 21)
    Me.Label7.TabIndex = 300
    Me.Label7.Text = "Omit Bills above"
    '
    'LnkDistrict
    '
    Me.LnkDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkDistrict.Location = New System.Drawing.Point(6, 22)
    Me.LnkDistrict.Name = "LnkDistrict"
    Me.LnkDistrict.Size = New System.Drawing.Size(40, 16)
    Me.LnkDistrict.TabIndex = 298
    Me.LnkDistrict.TabStop = True
    Me.LnkDistrict.Text = "District"
    '
    'TxtPhase
    '
    Me.TxtPhase.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhase.Location = New System.Drawing.Point(136, 17)
    Me.TxtPhase.MaxLength = 1
    Me.TxtPhase.Name = "TxtPhase"
    Me.TxtPhase.Size = New System.Drawing.Size(16, 22)
    Me.TxtPhase.TabIndex = 1
    '
    'Label12
    '
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(86, 22)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(44, 14)
    Me.Label12.TabIndex = 66
    Me.Label12.Text = "Phase"
    '
    'ChkInGracePeriod
    '
    Me.ChkInGracePeriod.AutoSize = True
    Me.ChkInGracePeriod.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkInGracePeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkInGracePeriod.Location = New System.Drawing.Point(14, 112)
    Me.ChkInGracePeriod.Name = "ChkInGracePeriod"
    Me.ChkInGracePeriod.Size = New System.Drawing.Size(106, 17)
    Me.ChkInGracePeriod.TabIndex = 5
    Me.ChkInGracePeriod.Text = "In Grace Period?"
    '
    'TxtBankCode
    '
    Me.TxtBankCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBankCode.Location = New System.Drawing.Point(100, 191)
    Me.TxtBankCode.MaxLength = 2
    Me.TxtBankCode.Name = "TxtBankCode"
    Me.TxtBankCode.Size = New System.Drawing.Size(24, 20)
    Me.TxtBankCode.TabIndex = 6
    '
    'Label11
    '
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.Location = New System.Drawing.Point(11, 195)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(72, 15)
    Me.Label11.TabIndex = 36
    Me.Label11.Text = "Bank Code"
    '
    'TxtOmitBelow
    '
    Me.TxtOmitBelow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOmitBelow.Location = New System.Drawing.Point(100, 139)
    Me.TxtOmitBelow.MaxLength = 6
    Me.TxtOmitBelow.Name = "TxtOmitBelow"
    Me.TxtOmitBelow.Size = New System.Drawing.Size(39, 20)
    Me.TxtOmitBelow.TabIndex = 4
    '
    'Label10
    '
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(11, 142)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(86, 21)
    Me.Label10.TabIndex = 34
    Me.Label10.Text = "Omit Bills below"
    '
    'ChkOmitSuspense
    '
    Me.ChkOmitSuspense.AutoSize = True
    Me.ChkOmitSuspense.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkOmitSuspense.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkOmitSuspense.Location = New System.Drawing.Point(11, 78)
    Me.ChkOmitSuspense.Name = "ChkOmitSuspense"
    Me.ChkOmitSuspense.Size = New System.Drawing.Size(103, 17)
    Me.ChkOmitSuspense.TabIndex = 3
    Me.ChkOmitSuspense.Text = "Omit Suspense?"
    '
    'TxtInvCode
    '
    Me.TxtInvCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtInvCode.Location = New System.Drawing.Point(113, 52)
    Me.TxtInvCode.MaxLength = 1
    Me.TxtInvCode.Name = "TxtInvCode"
    Me.TxtInvCode.Size = New System.Drawing.Size(20, 20)
    Me.TxtInvCode.TabIndex = 2
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(11, 54)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(94, 13)
    Me.Label8.TabIndex = 2
    Me.Label8.Text = "Omit Invoice Code"
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(52, 19)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(28, 20)
    Me.TxtDist.TabIndex = 0
    '
    'TxtLease
    '
    Me.TxtLease.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLease.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLease.Location = New System.Drawing.Point(100, 218)
    Me.TxtLease.MaxLength = 2
    Me.TxtLease.Name = "TxtLease"
    Me.TxtLease.Size = New System.Drawing.Size(25, 20)
    Me.TxtLease.TabIndex = 303
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(11, 221)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(64, 13)
    Me.Label5.TabIndex = 302
    Me.Label5.Text = "Lease Code"
    '
    'FrmTX303B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(564, 271)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.TxtStatus)
    Me.Controls.Add(Me.LinkStatus)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TxtType)
    Me.Controls.Add(Me.LnkType)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtToGLYear)
    Me.Controls.Add(Me.DtPckInt)
    Me.Controls.Add(Me.TxtFromGLYear)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX303B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox6.ResumeLayout(False)
    Me.GroupBox6.PerformLayout()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
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

		Me.Refresh()
		Windows.Forms.Cursor.Current = Cursors.WaitCursor
		PrtReport()
		Windows.Forms.Cursor.Current = Cursors.Default

	End Sub
Private Sub FrmTX303B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    DtPckInt.Value = Date.Today
End Sub
Private Sub FrmTX303B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmTX303.SbpScreen.Text = "TX303B"
End Sub
Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
	MyFrmListTypes = New FrmListTypes
	MyFrmListTypes.MdiParent = Me.ParentForm
	MyFrmListTypes.WrkType = TxtType.Text
	MyFrmListTypes.Show()
End Sub
Private Sub FrmTX303B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
	Me.Refresh()
End Sub
	Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer
		ErrProv.SetError(LblFilePath, "")
		ErrProv.SetError(TxtType, "")
		ErrProv.SetError(TxtFromGLYear, "")
		ErrProv.SetError(TxtToGLYear, "")
		ErrProv.SetError(ChkHeadings, "")

		For I = 0 To ErrorField.GetUpperBound(0)
			Select Case ErrorField(I)
			Case "path"
				ErrProv.SetError(LblFilePath, ErrorMsg(I))
			Case "type"
				ErrProv.SetError(TxtType, ErrorMsg(I))
			Case "fromglyear"
				ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
			Case "toglyear"
				ErrProv.SetError(TxtToGLYear, ErrorMsg(I))
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

		If TxtType.Text = "" Then
			ErrorField(I) = "type"
			ErrorMsg(I) = "Type is required"
			I = I + 1
		End If

    If MyUtils.CnvSng(TxtFromGLYear.Text) > 0 Then
      If MyUtils.CnvSng(TxtFromGLYear.Text) > MyUtils.CnvSng(TxtToGLYear.Text) Then
        ErrorField(I) = "fromglyear"
        ErrorMsg(I) = "Invalid GL Year range"
        I = I + 1
        ErrorField(I) = "toglyear"
        ErrorMsg(I) = "Invalid GL Year range"
        I = I + 1
      End If
    End If

		If Not RbCSV.Checked And ChkHeadings.Checked Then
			ErrorField(I) = "headings"
			ErrorMsg(I) = "Headings are only valid for CSV files"
			I = I + 1
		End If

		If LblFilePath.Text = String.Empty And ChkHeadings.Checked Then
			ErrorField(I) = "path"
			ErrorMsg(I) = "File path is required"
			I = I + 1
		End If
	End Sub

Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
	With SaveFileDialog1
		.ShowDialog()
		LblFilePath.Text = .FileName
	End With
End Sub

Private Sub LinkStatus_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkStatus.LinkClicked
	MyFrmSelStatus = New FrmSelStatus
	MyFrmSelStatus.MdiParent = Me.ParentForm
	MyFrmSelStatus.Show()
End Sub
End Class






