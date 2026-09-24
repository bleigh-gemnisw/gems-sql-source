Public Class FrmUB409B
Inherits System.Windows.Forms.Form
Dim MyUTTYPE As UTTYPE.myData

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
Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
Friend WithEvents GrpSorting As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtYear As System.Windows.Forms.TextBox
    Friend WithEvents DtPckInterest As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtUBTypes As System.Windows.Forms.TextBox
    Friend WithEvents LinkUBType As System.Windows.Forms.LinkLabel
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbPerApr As System.Windows.Forms.RadioButton
Friend WithEvents RbPerMar As System.Windows.Forms.RadioButton
Friend WithEvents RbPerFeb As System.Windows.Forms.RadioButton
Friend WithEvents RbPerJan As System.Windows.Forms.RadioButton
    Friend WithEvents RbSortLocation As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkBills As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtComment2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtComment1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtPckServiceTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtPckServiceFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkUpdateDist As System.Windows.Forms.CheckBox
    Friend WithEvents ChkUpdate As System.Windows.Forms.CheckBox
    Friend WithEvents ChkReport As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAddress As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents LblFilePath As System.Windows.Forms.Label
    Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtAddlBillDesc As System.Windows.Forms.TextBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DtPckRead As System.Windows.Forms.DateTimePicker
  Friend WithEvents RbPerDec As RadioButton
  Friend WithEvents RbPerNov As RadioButton
  Friend WithEvents RbPerOct As RadioButton
  Friend WithEvents RbPerSep As RadioButton
  Friend WithEvents RbPerAug As RadioButton
  Friend WithEvents RbPerJul As RadioButton
  Friend WithEvents RbPerJun As RadioButton
  Friend WithEvents RbPerMay As RadioButton
  Friend WithEvents RbSortList As System.Windows.Forms.RadioButton
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GrpSorting = New System.Windows.Forms.GroupBox()
    Me.RbSortLocation = New System.Windows.Forms.RadioButton()
    Me.RbSortList = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
        Me.TxtYear = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtUBTypes = New System.Windows.Forms.TextBox()
        Me.LinkUBType = New System.Windows.Forms.LinkLabel()
        Me.DtPckInterest = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RbPerDec = New System.Windows.Forms.RadioButton()
        Me.RbPerNov = New System.Windows.Forms.RadioButton()
        Me.RbPerOct = New System.Windows.Forms.RadioButton()
        Me.RbPerSep = New System.Windows.Forms.RadioButton()
        Me.RbPerAug = New System.Windows.Forms.RadioButton()
        Me.RbPerJul = New System.Windows.Forms.RadioButton()
        Me.RbPerJun = New System.Windows.Forms.RadioButton()
        Me.RbPerMay = New System.Windows.Forms.RadioButton()
        Me.RbPerApr = New System.Windows.Forms.RadioButton()
        Me.RbPerMar = New System.Windows.Forms.RadioButton()
        Me.RbPerFeb = New System.Windows.Forms.RadioButton()
        Me.RbPerJan = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TxtAddlBillDesc = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.LblFilePath = New System.Windows.Forms.Label()
        Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
        Me.TxtComment2 = New System.Windows.Forms.TextBox()
        Me.TxtComment1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DtPckServiceTo = New System.Windows.Forms.DateTimePicker()
        Me.DtPckServiceFrom = New System.Windows.Forms.DateTimePicker()
        Me.ChkBills = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ChkReport = New System.Windows.Forms.CheckBox()
        Me.ChkAddress = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ChkUpdateDist = New System.Windows.Forms.CheckBox()
        Me.ChkUpdate = New System.Windows.Forms.CheckBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DtPckRead = New System.Windows.Forms.DateTimePicker()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpSorting.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'GrpSorting
        '
        Me.GrpSorting.Controls.Add(Me.RbSortLocation)
        Me.GrpSorting.Controls.Add(Me.RbSortList)
        Me.GrpSorting.Controls.Add(Me.RbSortName)
        Me.GrpSorting.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpSorting.ForeColor = System.Drawing.Color.Maroon
        Me.GrpSorting.Location = New System.Drawing.Point(316, 12)
        Me.GrpSorting.Name = "GrpSorting"
        Me.GrpSorting.Size = New System.Drawing.Size(128, 98)
        Me.GrpSorting.TabIndex = 5
        Me.GrpSorting.TabStop = False
        Me.GrpSorting.Text = "Sort Order"
        '
        'RbSortLocation
        '
        Me.RbSortLocation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbSortLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSortLocation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RbSortLocation.Location = New System.Drawing.Point(8, 64)
        Me.RbSortLocation.Name = "RbSortLocation"
        Me.RbSortLocation.Size = New System.Drawing.Size(108, 20)
        Me.RbSortLocation.TabIndex = 2
        Me.RbSortLocation.Text = "Location"
        '
        'RbSortList
        '
        Me.RbSortList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbSortList.Checked = True
        Me.RbSortList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSortList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RbSortList.Location = New System.Drawing.Point(8, 16)
        Me.RbSortList.Name = "RbSortList"
        Me.RbSortList.Size = New System.Drawing.Size(108, 20)
        Me.RbSortList.TabIndex = 0
        Me.RbSortList.TabStop = True
        Me.RbSortList.Text = "List #"
        '
        'RbSortName
        '
        Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSortName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RbSortName.Location = New System.Drawing.Point(8, 40)
        Me.RbSortName.Name = "RbSortName"
        Me.RbSortName.Size = New System.Drawing.Size(108, 20)
        Me.RbSortName.TabIndex = 1
        Me.RbSortName.Text = "Name"
        '
        'TxtYear
        '
        Me.TxtYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtYear.Location = New System.Drawing.Point(120, 16)
        Me.TxtYear.MaxLength = 4
        Me.TxtYear.Name = "TxtYear"
        Me.TxtYear.Size = New System.Drawing.Size(40, 22)
        Me.TxtYear.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Billing Year"
        '
        'TxtUBTypes
        '
        Me.TxtUBTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtUBTypes.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUBTypes.Location = New System.Drawing.Point(120, 47)
        Me.TxtUBTypes.MaxLength = 2
        Me.TxtUBTypes.Name = "TxtUBTypes"
        Me.TxtUBTypes.Size = New System.Drawing.Size(32, 22)
        Me.TxtUBTypes.TabIndex = 3
        '
        'LinkUBType
        '
        Me.LinkUBType.Location = New System.Drawing.Point(12, 51)
        Me.LinkUBType.Name = "LinkUBType"
        Me.LinkUBType.Size = New System.Drawing.Size(68, 16)
        Me.LinkUBType.TabIndex = 71
        Me.LinkUBType.TabStop = True
        Me.LinkUBType.Text = "Bill Types"
        '
        'DtPckInterest
        '
        Me.DtPckInterest.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckInterest.Location = New System.Drawing.Point(120, 74)
        Me.DtPckInterest.Name = "DtPckInterest"
        Me.DtPckInterest.Size = New System.Drawing.Size(88, 20)
        Me.DtPckInterest.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Interest Date"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RbPerDec)
        Me.GroupBox2.Controls.Add(Me.RbPerNov)
        Me.GroupBox2.Controls.Add(Me.RbPerOct)
        Me.GroupBox2.Controls.Add(Me.RbPerSep)
        Me.GroupBox2.Controls.Add(Me.RbPerAug)
        Me.GroupBox2.Controls.Add(Me.RbPerJul)
        Me.GroupBox2.Controls.Add(Me.RbPerJun)
        Me.GroupBox2.Controls.Add(Me.RbPerMay)
        Me.GroupBox2.Controls.Add(Me.RbPerApr)
        Me.GroupBox2.Controls.Add(Me.RbPerMar)
        Me.GroupBox2.Controls.Add(Me.RbPerFeb)
        Me.GroupBox2.Controls.Add(Me.RbPerJan)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox2.Location = New System.Drawing.Point(450, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(138, 285)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Billing Period"
        '
        'RbPerDec
        '
        Me.RbPerDec.AutoSize = True
        Me.RbPerDec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbPerDec.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RbPerDec.Location = New System.Drawing.Point(18, 238)
        Me.RbPerDec.Name = "RbPerDec"
        Me.RbPerDec.Size = New System.Drawing.Size(74, 17)
        Me.RbPerDec.TabIndex = 315
        Me.RbPerDec.Text = "December"
        '
        'RbPerNov
        '
        Me.RbPerNov.AutoSize = True
        Me.RbPerNov.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbPerNov.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RbPerNov.Location = New System.Drawing.Point(18, 218)
        Me.RbPerNov.Name = "RbPerNov"
        Me.RbPerNov.Size = New System.Drawing.Size(74, 17)
        Me.RbPerNov.TabIndex = 314
        Me.RbPerNov.Text = "November"
        '
        'RbPerOct
        '
        Me.RbPerOct.AutoSize = True
        Me.RbPerOct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbPerOct.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RbPerOct.Location = New System.Drawing.Point(18, 198)
        Me.RbPerOct.Name = "RbPerOct"
        Me.RbPerOct.Size = New System.Drawing.Size(63, 17)
        Me.RbPerOct.TabIndex = 313
        Me.RbPerOct.Text = "October"
        '
        'RbPerSep
        '
        Me.RbPerSep.AutoSize = True
        Me.RbPerSep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbPerSep.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RbPerSep.Location = New System.Drawing.Point(18, 178)
        Me.RbPerSep.Name = "RbPerSep"
        Me.RbPerSep.Size = New System.Drawing.Size(76, 17)
        Me.RbPerSep.TabIndex = 312
        Me.RbPerSep.Text = "September"
        '
        'RbPerAug
        '
        Me.RbPerAug.AutoSize = True
        Me.RbPerAug.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbPerAug.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RbPerAug.Location = New System.Drawing.Point(15, 158)
        Me.RbPerAug.Name = "RbPerAug"
        Me.RbPerAug.Size = New System.Drawing.Size(58, 17)
        Me.RbPerAug.TabIndex = 311
        Me.RbPerAug.Text = "August"
        '
        'RbPerJul
        '
        Me.RbPerJul.AutoSize = True
        Me.RbPerJul.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbPerJul.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RbPerJul.Location = New System.Drawing.Point(15, 138)
        Me.RbPerJul.Name = "RbPerJul"
        Me.RbPerJul.Size = New System.Drawing.Size(43, 17)
        Me.RbPerJul.TabIndex = 310
        Me.RbPerJul.Text = "July"
        '
        'RbPerJun
        '
        Me.RbPerJun.AutoSize = True
        Me.RbPerJun.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbPerJun.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RbPerJun.Location = New System.Drawing.Point(15, 118)
        Me.RbPerJun.Name = "RbPerJun"
        Me.RbPerJun.Size = New System.Drawing.Size(48, 17)
        Me.RbPerJun.TabIndex = 309
        Me.RbPerJun.Text = "June"
        '
        'RbPerMay
        '
        Me.RbPerMay.AutoSize = True
        Me.RbPerMay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbPerMay.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RbPerMay.Location = New System.Drawing.Point(15, 98)
        Me.RbPerMay.Name = "RbPerMay"
        Me.RbPerMay.Size = New System.Drawing.Size(45, 17)
        Me.RbPerMay.TabIndex = 308
        Me.RbPerMay.Text = "May"
        '
        'RbPerApr
        '
        Me.RbPerApr.AutoSize = True
        Me.RbPerApr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbPerApr.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RbPerApr.Location = New System.Drawing.Point(15, 78)
        Me.RbPerApr.Name = "RbPerApr"
        Me.RbPerApr.Size = New System.Drawing.Size(45, 17)
        Me.RbPerApr.TabIndex = 307
        Me.RbPerApr.Text = "April"
        '
        'RbPerMar
        '
        Me.RbPerMar.AutoSize = True
        Me.RbPerMar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbPerMar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RbPerMar.Location = New System.Drawing.Point(15, 58)
        Me.RbPerMar.Name = "RbPerMar"
        Me.RbPerMar.Size = New System.Drawing.Size(55, 17)
        Me.RbPerMar.TabIndex = 306
        Me.RbPerMar.Text = "March"
        '
        'RbPerFeb
        '
        Me.RbPerFeb.AutoSize = True
        Me.RbPerFeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbPerFeb.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RbPerFeb.Location = New System.Drawing.Point(15, 38)
        Me.RbPerFeb.Name = "RbPerFeb"
        Me.RbPerFeb.Size = New System.Drawing.Size(66, 17)
        Me.RbPerFeb.TabIndex = 305
        Me.RbPerFeb.Text = "February"
        '
        'RbPerJan
        '
        Me.RbPerJan.AutoSize = True
        Me.RbPerJan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbPerJan.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RbPerJan.Location = New System.Drawing.Point(15, 18)
        Me.RbPerJan.Name = "RbPerJan"
        Me.RbPerJan.Size = New System.Drawing.Size(62, 17)
        Me.RbPerJan.TabIndex = 304
        Me.RbPerJan.Text = "January"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TxtAddlBillDesc)
        Me.GroupBox3.Controls.Add(Me.GroupBox6)
        Me.GroupBox3.Controls.Add(Me.TxtComment2)
        Me.GroupBox3.Controls.Add(Me.TxtComment1)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Controls.Add(Me.ChkBills)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox3.Location = New System.Drawing.Point(11, 130)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(433, 272)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Bills"
        '
        'TxtAddlBillDesc
        '
        Me.TxtAddlBillDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAddlBillDesc.Location = New System.Drawing.Point(7, 176)
        Me.TxtAddlBillDesc.MaxLength = 30
        Me.TxtAddlBillDesc.Name = "TxtAddlBillDesc"
        Me.TxtAddlBillDesc.Size = New System.Drawing.Size(249, 20)
        Me.TxtAddlBillDesc.TabIndex = 4
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.LblFilePath)
        Me.GroupBox6.Controls.Add(Me.LnkFilePath)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(7, 37)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(420, 42)
        Me.GroupBox6.TabIndex = 308
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Download to PC: UTBILL File Details (optional csv)"
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
        'TxtComment2
        '
        Me.TxtComment2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtComment2.Location = New System.Drawing.Point(3, 244)
        Me.TxtComment2.MaxLength = 75
        Me.TxtComment2.Name = "TxtComment2"
        Me.TxtComment2.Size = New System.Drawing.Size(424, 22)
        Me.TxtComment2.TabIndex = 6
        '
        'TxtComment1
        '
        Me.TxtComment1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtComment1.Location = New System.Drawing.Point(3, 224)
        Me.TxtComment1.MaxLength = 75
        Me.TxtComment1.Name = "TxtComment1"
        Me.TxtComment1.Size = New System.Drawing.Size(424, 22)
        Me.TxtComment1.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(3, 208)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(196, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Miscellaneous Comments On Bill"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(4, 157)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Additional Bill Description on bill "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DtPckServiceTo)
        Me.GroupBox1.Controls.Add(Me.DtPckServiceFrom)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(7, 101)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(264, 52)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Service Dates (optional)"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(120, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "TO"
        '
        'DtPckServiceTo
        '
        Me.DtPckServiceTo.Checked = False
        Me.DtPckServiceTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPckServiceTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckServiceTo.Location = New System.Drawing.Point(152, 24)
        Me.DtPckServiceTo.Name = "DtPckServiceTo"
        Me.DtPckServiceTo.ShowCheckBox = True
        Me.DtPckServiceTo.Size = New System.Drawing.Size(104, 20)
        Me.DtPckServiceTo.TabIndex = 2
        '
        'DtPckServiceFrom
        '
        Me.DtPckServiceFrom.Checked = False
        Me.DtPckServiceFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPckServiceFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckServiceFrom.Location = New System.Drawing.Point(8, 24)
        Me.DtPckServiceFrom.Name = "DtPckServiceFrom"
        Me.DtPckServiceFrom.ShowCheckBox = True
        Me.DtPckServiceFrom.Size = New System.Drawing.Size(104, 20)
        Me.DtPckServiceFrom.TabIndex = 0
        '
        'ChkBills
        '
        Me.ChkBills.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkBills.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkBills.ForeColor = System.Drawing.Color.Black
        Me.ChkBills.Location = New System.Drawing.Point(6, 15)
        Me.ChkBills.Name = "ChkBills"
        Me.ChkBills.Size = New System.Drawing.Size(83, 16)
        Me.ChkBills.TabIndex = 0
        Me.ChkBills.Text = "Print Bills?"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ChkReport)
        Me.GroupBox4.Controls.Add(Me.ChkAddress)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(15, 410)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(162, 58)
        Me.GroupBox4.TabIndex = 301
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Report"
        '
        'ChkReport
        '
        Me.ChkReport.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkReport.Checked = True
        Me.ChkReport.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkReport.ForeColor = System.Drawing.Color.Black
        Me.ChkReport.Location = New System.Drawing.Point(6, 19)
        Me.ChkReport.Name = "ChkReport"
        Me.ChkReport.Size = New System.Drawing.Size(139, 18)
        Me.ChkReport.TabIndex = 0
        Me.ChkReport.Text = "Print Report?"
        '
        'ChkAddress
        '
        Me.ChkAddress.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAddress.ForeColor = System.Drawing.Color.Black
        Me.ChkAddress.Location = New System.Drawing.Point(17, 36)
        Me.ChkAddress.Name = "ChkAddress"
        Me.ChkAddress.Size = New System.Drawing.Size(128, 16)
        Me.ChkAddress.TabIndex = 1
        Me.ChkAddress.Text = "Include Address?"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ChkUpdateDist)
        Me.GroupBox5.Controls.Add(Me.ChkUpdate)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox5.Location = New System.Drawing.Point(298, 410)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(146, 58)
        Me.GroupBox5.TabIndex = 302
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Posting"
        '
        'ChkUpdateDist
        '
        Me.ChkUpdateDist.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkUpdateDist.Checked = True
        Me.ChkUpdateDist.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkUpdateDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkUpdateDist.ForeColor = System.Drawing.Color.Black
        Me.ChkUpdateDist.Location = New System.Drawing.Point(6, 34)
        Me.ChkUpdateDist.Name = "ChkUpdateDist"
        Me.ChkUpdateDist.Size = New System.Drawing.Size(128, 20)
        Me.ChkUpdateDist.TabIndex = 1
        Me.ChkUpdateDist.Text = "Update with district?"
        Me.ChkUpdateDist.Visible = False
        '
        'ChkUpdate
        '
        Me.ChkUpdate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkUpdate.ForeColor = System.Drawing.Color.Black
        Me.ChkUpdate.Location = New System.Drawing.Point(6, 18)
        Me.ChkUpdate.Name = "ChkUpdate"
        Me.ChkUpdate.Size = New System.Drawing.Size(128, 20)
        Me.ChkUpdate.TabIndex = 0
        Me.ChkUpdate.Text = "Update Tax Invoice?"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 20)
        Me.Label5.TabIndex = 352
        Me.Label5.Text = "Meter Reading Date"
        '
        'DtPckRead
        '
        Me.DtPckRead.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckRead.Location = New System.Drawing.Point(120, 100)
        Me.DtPckRead.Name = "DtPckRead"
        Me.DtPckRead.Size = New System.Drawing.Size(88, 20)
        Me.DtPckRead.TabIndex = 5
        '
        'FrmUB409B
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(629, 500)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DtPckRead)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DtPckInterest)
        Me.Controls.Add(Me.LinkUBType)
        Me.Controls.Add(Me.TxtUBTypes)
        Me.Controls.Add(Me.TxtYear)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GrpSorting)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUB409B"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpSorting.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Sub RunReport()
        Dim ErrorField(25) As String
        Dim ErrorMsg(25) As String

        MyUTTYPE = New UTTYPE.MyData(myDBConnect)

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
    Private Sub FrmUB409B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtYear.Text = Date.Now.Year
        DtPckInterest.Value = Date.Today
        DtPckRead.Value = Date.Today
    End Sub
    Private Sub FrmUB409B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        MyFrmUB409.SbpScreen.Text = "UB409B"
    End Sub
    Private Sub FrmUB409B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        Me.Refresh()
    End Sub
    Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
        Dim I As Integer
        ErrProv.SetError(TxtUBTypes, "")
        ErrProv.SetError(TxtYear, "")

        For I = 0 To ErrorField.GetUpperBound(0)
            Select Case ErrorField(I)
                Case "ubtype"
                    ErrProv.SetError(TxtUBTypes, ErrorMsg(I))
                Case "year"
                    ErrProv.SetError(TxtYear, ErrorMsg(I))
                Case Nothing
                    Exit Sub
            End Select
        Next I
    End Sub
    Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
        Dim ds As DataSet = New DataSet
        Dim I As Integer

        For I = 0 To ErrorField.GetUpperBound(0)
            If IsNothing(ErrorField(I)) Then
                Exit For
            End If
        Next

        If MyUtils.CnvSng(TxtYear.Text) = 0 Then
            ErrorField(I) = "year"
            ErrorMsg(I) = "Invalid Year"
            I = I + 1
        End If

        MyUTTYPE.GetOneRecordP(Mid(TxtUBTypes.Text, 1, 1))
        If MyUTTYPE.RecordNotFound Then
            ErrorField(I) = "ubtype"
            ErrorMsg(I) = "Invalid Bill Type"
            I = I + 1
        End If

    End Sub
    Private Sub TxtYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
        e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
    End Sub
    Private Sub TxtDist_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
    End Sub
    Private Sub TxtPhase_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
    End Sub
    Private Sub LnkDistrict_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    'MyFrmListDist = New FrmListDist
    'MyFrmListDist.MdiParent = Me.ParentForm
    'MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
    'MyFrmListDist.WrkPhase = MyUtils.CnvSng(TxtPhase.Text)
    'MyFrmListDist.Show()
    'Me.Hide()
  End Sub
    Private Sub LinkUBType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkUBType.LinkClicked
    MyFrmListUBType = New FrmListUBType
    MyFrmListUBType.MdiParent = Me.ParentForm
    MyFrmListUBType.WrkType = TxtUBTypes.Text
    MyFrmListUBType.Show()
    Me.Hide()
  End Sub

  Private Sub ChkUpdateDist_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

  End Sub

  Private Sub TxtAddlBillDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

  End Sub

  Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
    With SaveFileDialog1
      .ShowDialog()
      LblFilePath.Text = .FileName
    End With
  End Sub

  Private Sub RbPerFeb_CheckedChanged(sender As Object, e As EventArgs) Handles RbPerFeb.CheckedChanged

  End Sub
End Class






