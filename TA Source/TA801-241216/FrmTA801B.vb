Public Class FrmTA801B
Inherits System.Windows.Forms.Form
  Dim myTXCNTL As TXCNTL.MyData
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
  Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TxtType As System.Windows.Forms.TextBox
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents RbBefore As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents TxtToReason As System.Windows.Forms.TextBox
Friend WithEvents TxtFromReason As System.Windows.Forms.TextBox
Friend WithEvents LnkToReason As System.Windows.Forms.LinkLabel
Friend WithEvents LnkFrmReason As System.Windows.Forms.LinkLabel
Friend WithEvents ChkGross As System.Windows.Forms.CheckBox
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbMultDiff As System.Windows.Forms.RadioButton
Friend WithEvents RbMultOrig As System.Windows.Forms.RadioButton
Friend WithEvents GrpTax As System.Windows.Forms.GroupBox
Friend WithEvents RbTaxBoth As System.Windows.Forms.RadioButton
Friend WithEvents RbTaxExempt As System.Windows.Forms.RadioButton
Friend WithEvents RbTaxable As System.Windows.Forms.RadioButton
Friend WithEvents ChkBAA As System.Windows.Forms.CheckBox
Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
Friend WithEvents RbSortList As System.Windows.Forms.RadioButton
Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
Friend WithEvents TxtUserID As System.Windows.Forms.TextBox
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents ChkShowUser As System.Windows.Forms.CheckBox
Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtBeforeYear As TextBox
  Friend WithEvents RbSortCCNo As RadioButton
  Friend WithEvents RbAfter As System.Windows.Forms.RadioButton
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTA801B))
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.TxtFromGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LnkType = New System.Windows.Forms.LinkLabel()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtToGLYear = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.RbBefore = New System.Windows.Forms.RadioButton()
    Me.RbAfter = New System.Windows.Forms.RadioButton()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.TxtToReason = New System.Windows.Forms.TextBox()
    Me.TxtFromReason = New System.Windows.Forms.TextBox()
    Me.LnkToReason = New System.Windows.Forms.LinkLabel()
    Me.LnkFrmReason = New System.Windows.Forms.LinkLabel()
    Me.ChkGross = New System.Windows.Forms.CheckBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbMultOrig = New System.Windows.Forms.RadioButton()
    Me.RbMultDiff = New System.Windows.Forms.RadioButton()
    Me.GrpTax = New System.Windows.Forms.GroupBox()
    Me.RbTaxBoth = New System.Windows.Forms.RadioButton()
    Me.RbTaxExempt = New System.Windows.Forms.RadioButton()
    Me.RbTaxable = New System.Windows.Forms.RadioButton()
    Me.ChkBAA = New System.Windows.Forms.CheckBox()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.RbSortList = New System.Windows.Forms.RadioButton()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtUserID = New System.Windows.Forms.TextBox()
    Me.ChkShowUser = New System.Windows.Forms.CheckBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtBeforeYear = New System.Windows.Forms.TextBox()
    Me.RbSortCCNo = New System.Windows.Forms.RadioButton()
    Me.GroupBox3.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GrpTax.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.SuspendLayout()
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Location = New System.Drawing.Point(120, 16)
    Me.TxtType.MaxLength = 1
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(16, 20)
    Me.TxtType.TabIndex = 1
    '
    'TxtFromGLYear
    '
    Me.TxtFromGLYear.Location = New System.Drawing.Point(120, 44)
    Me.TxtFromGLYear.MaxLength = 4
    Me.TxtFromGLYear.Name = "TxtFromGLYear"
    Me.TxtFromGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtFromGLYear.TabIndex = 2
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(32, 48)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(84, 16)
    Me.Label4.TabIndex = 11
    Me.Label4.Text = "Grand List Year"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.DtPckTo)
    Me.GroupBox3.Controls.Add(Me.Label2)
    Me.GroupBox3.Controls.Add(Me.DtPckFrom)
    Me.GroupBox3.Controls.Add(Me.Label1)
    Me.GroupBox3.ForeColor = System.Drawing.Color.Black
    Me.GroupBox3.Location = New System.Drawing.Point(24, 80)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(270, 52)
    Me.GroupBox3.TabIndex = 4
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Date Range"
    '
    'DtPckTo
    '
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(171, 20)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
    Me.DtPckTo.TabIndex = 1
    Me.DtPckTo.Value = New Date(2005, 10, 6, 9, 11, 0, 906)
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.ForeColor = System.Drawing.Color.Black
    Me.Label2.Location = New System.Drawing.Point(146, 24)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(23, 13)
    Me.Label2.TabIndex = 9
    Me.Label2.Text = "To "
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(52, 20)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
    Me.DtPckFrom.TabIndex = 0
    Me.DtPckFrom.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
    '
    'Label1
    '
    Me.Label1.ForeColor = System.Drawing.Color.Black
    Me.Label1.Location = New System.Drawing.Point(12, 24)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(36, 16)
    Me.Label1.TabIndex = 7
    Me.Label1.Text = "From"
    '
    'LnkType
    '
    Me.LnkType.Location = New System.Drawing.Point(36, 20)
    Me.LnkType.Name = "LnkType"
    Me.LnkType.Size = New System.Drawing.Size(80, 16)
    Me.LnkType.TabIndex = 0
    Me.LnkType.TabStop = True
    Me.LnkType.Text = "Type to print"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtToGLYear
    '
    Me.TxtToGLYear.Location = New System.Drawing.Point(184, 44)
    Me.TxtToGLYear.MaxLength = 4
    Me.TxtToGLYear.Name = "TxtToGLYear"
    Me.TxtToGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtToGLYear.TabIndex = 3
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(160, 48)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(20, 16)
    Me.Label3.TabIndex = 19
    Me.Label3.Text = "to"
    '
    'RbBefore
    '
    Me.RbBefore.AutoSize = True
    Me.RbBefore.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbBefore.Location = New System.Drawing.Point(318, 12)
    Me.RbBefore.Name = "RbBefore"
    Me.RbBefore.Size = New System.Drawing.Size(77, 17)
    Me.RbBefore.TabIndex = 12
    Me.RbBefore.Text = "Before Bills"
    '
    'RbAfter
    '
    Me.RbAfter.AutoSize = True
    Me.RbAfter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbAfter.Checked = True
    Me.RbAfter.Location = New System.Drawing.Point(327, 32)
    Me.RbAfter.Name = "RbAfter"
    Me.RbAfter.Size = New System.Drawing.Size(68, 17)
    Me.RbAfter.TabIndex = 13
    Me.RbAfter.TabStop = True
    Me.RbAfter.Text = "After Bills"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.TxtToReason)
    Me.GroupBox1.Controls.Add(Me.TxtFromReason)
    Me.GroupBox1.Controls.Add(Me.LnkToReason)
    Me.GroupBox1.Controls.Add(Me.LnkFrmReason)
    Me.GroupBox1.Location = New System.Drawing.Point(24, 138)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(156, 46)
    Me.GroupBox1.TabIndex = 5
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Reason Codes (Optional)"
    '
    'TxtToReason
    '
    Me.TxtToReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtToReason.Location = New System.Drawing.Point(119, 18)
    Me.TxtToReason.MaxLength = 1
    Me.TxtToReason.Name = "TxtToReason"
    Me.TxtToReason.Size = New System.Drawing.Size(16, 20)
    Me.TxtToReason.TabIndex = 26
    '
    'TxtFromReason
    '
    Me.TxtFromReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFromReason.Location = New System.Drawing.Point(59, 18)
    Me.TxtFromReason.MaxLength = 1
    Me.TxtFromReason.Name = "TxtFromReason"
    Me.TxtFromReason.Size = New System.Drawing.Size(16, 20)
    Me.TxtFromReason.TabIndex = 25
    '
    'LnkToReason
    '
    Me.LnkToReason.Location = New System.Drawing.Point(93, 21)
    Me.LnkToReason.Name = "LnkToReason"
    Me.LnkToReason.Size = New System.Drawing.Size(20, 16)
    Me.LnkToReason.TabIndex = 28
    Me.LnkToReason.TabStop = True
    Me.LnkToReason.Text = "To"
    '
    'LnkFrmReason
    '
    Me.LnkFrmReason.Location = New System.Drawing.Point(17, 22)
    Me.LnkFrmReason.Name = "LnkFrmReason"
    Me.LnkFrmReason.Size = New System.Drawing.Size(38, 16)
    Me.LnkFrmReason.TabIndex = 27
    Me.LnkFrmReason.TabStop = True
    Me.LnkFrmReason.Text = "From"
    '
    'ChkGross
    '
    Me.ChkGross.AutoSize = True
    Me.ChkGross.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkGross.Location = New System.Drawing.Point(21, 190)
    Me.ChkGross.Name = "ChkGross"
    Me.ChkGross.Size = New System.Drawing.Size(205, 17)
    Me.ChkGross.TabIndex = 6
    Me.ChkGross.Text = "Show Gross and Exemption amounts?"
    Me.ChkGross.UseVisualStyleBackColor = True
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(142, 20)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(52, 13)
    Me.Label5.TabIndex = 21
    Me.Label5.Text = "(Optional)"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(222, 48)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(52, 13)
    Me.Label6.TabIndex = 22
    Me.Label6.Text = "(Optional)"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbMultOrig)
    Me.GroupBox2.Controls.Add(Me.RbMultDiff)
    Me.GroupBox2.Location = New System.Drawing.Point(21, 274)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(357, 64)
    Me.GroupBox2.TabIndex = 10
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Multiple C/C Reporting Method "
    '
    'RbMultOrig
    '
    Me.RbMultOrig.AutoSize = True
    Me.RbMultOrig.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbMultOrig.Location = New System.Drawing.Point(6, 38)
    Me.RbMultOrig.Name = "RbMultOrig"
    Me.RbMultOrig.Size = New System.Drawing.Size(250, 17)
    Me.RbMultOrig.TabIndex = 6
    Me.RbMultOrig.Text = "Show Original Amounts (IE: 200 Incr/150 Decr) "
    '
    'RbMultDiff
    '
    Me.RbMultDiff.AutoSize = True
    Me.RbMultDiff.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbMultDiff.Checked = True
    Me.RbMultDiff.Location = New System.Drawing.Point(6, 19)
    Me.RbMultDiff.Name = "RbMultDiff"
    Me.RbMultDiff.Size = New System.Drawing.Size(333, 17)
    Me.RbMultDiff.TabIndex = 5
    Me.RbMultDiff.TabStop = True
    Me.RbMultDiff.Text = "Show Difference only (IE: 200 Incr/150 Decr ==> 50 Incr/0 Decr)"
    '
    'GrpTax
    '
    Me.GrpTax.Controls.Add(Me.RbTaxBoth)
    Me.GrpTax.Controls.Add(Me.RbTaxExempt)
    Me.GrpTax.Controls.Add(Me.RbTaxable)
    Me.GrpTax.Location = New System.Drawing.Point(18, 344)
    Me.GrpTax.Name = "GrpTax"
    Me.GrpTax.Size = New System.Drawing.Size(221, 78)
    Me.GrpTax.TabIndex = 11
    Me.GrpTax.TabStop = False
    Me.GrpTax.Text = "Taxable/Tax Exempt Reporting Method "
    '
    'RbTaxBoth
    '
    Me.RbTaxBoth.AutoSize = True
    Me.RbTaxBoth.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbTaxBoth.Location = New System.Drawing.Point(6, 54)
    Me.RbTaxBoth.Name = "RbTaxBoth"
    Me.RbTaxBoth.Size = New System.Drawing.Size(77, 17)
    Me.RbTaxBoth.TabIndex = 7
    Me.RbTaxBoth.Text = "Show Both"
    '
    'RbTaxExempt
    '
    Me.RbTaxExempt.AutoSize = True
    Me.RbTaxExempt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbTaxExempt.Location = New System.Drawing.Point(6, 38)
    Me.RbTaxExempt.Name = "RbTaxExempt"
    Me.RbTaxExempt.Size = New System.Drawing.Size(135, 17)
    Me.RbTaxExempt.TabIndex = 6
    Me.RbTaxExempt.Text = "Show Tax Exempt Only"
    '
    'RbTaxable
    '
    Me.RbTaxable.AutoSize = True
    Me.RbTaxable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbTaxable.Checked = True
    Me.RbTaxable.Location = New System.Drawing.Point(6, 19)
    Me.RbTaxable.Name = "RbTaxable"
    Me.RbTaxable.Size = New System.Drawing.Size(117, 17)
    Me.RbTaxable.TabIndex = 5
    Me.RbTaxable.TabStop = True
    Me.RbTaxable.Text = "Show Taxable Only"
    '
    'ChkBAA
    '
    Me.ChkBAA.AutoSize = True
    Me.ChkBAA.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkBAA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkBAA.Location = New System.Drawing.Point(21, 213)
    Me.ChkBAA.Name = "ChkBAA"
    Me.ChkBAA.Size = New System.Drawing.Size(135, 17)
    Me.ChkBAA.TabIndex = 7
    Me.ChkBAA.Text = "Include BAA Amounts?"
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.RbSortCCNo)
    Me.GroupBox4.Controls.Add(Me.RbSortList)
    Me.GroupBox4.Controls.Add(Me.RbSortName)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(307, 55)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(135, 83)
    Me.GroupBox4.TabIndex = 14
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Sort Options"
    '
    'RbSortList
    '
    Me.RbSortList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortList.Location = New System.Drawing.Point(6, 39)
    Me.RbSortList.Name = "RbSortList"
    Me.RbSortList.Size = New System.Drawing.Size(120, 20)
    Me.RbSortList.TabIndex = 3
    Me.RbSortList.Text = "Type/Year/List #"
    '
    'RbSortName
    '
    Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortName.Checked = True
    Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortName.Location = New System.Drawing.Point(6, 19)
    Me.RbSortName.Name = "RbSortName"
    Me.RbSortName.Size = New System.Drawing.Size(120, 20)
    Me.RbSortName.TabIndex = 1
    Me.RbSortName.TabStop = True
    Me.RbSortName.Text = "Type/Year/Name"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(21, 239)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(43, 13)
    Me.Label7.TabIndex = 24
    Me.Label7.Text = "User ID"
    '
    'TxtUserID
    '
    Me.TxtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUserID.Location = New System.Drawing.Point(70, 236)
    Me.TxtUserID.MaxLength = 10
    Me.TxtUserID.Name = "TxtUserID"
    Me.TxtUserID.Size = New System.Drawing.Size(83, 20)
    Me.TxtUserID.TabIndex = 8
    '
    'ChkShowUser
    '
    Me.ChkShowUser.AutoSize = True
    Me.ChkShowUser.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkShowUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkShowUser.Location = New System.Drawing.Point(217, 239)
    Me.ChkShowUser.Name = "ChkShowUser"
    Me.ChkShowUser.Size = New System.Drawing.Size(95, 17)
    Me.ChkShowUser.TabIndex = 9
    Me.ChkShowUser.Text = "Show UserID?"
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(159, 239)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(52, 13)
    Me.Label8.TabIndex = 27
    Me.Label8.Text = "(Optional)"
    '
    'TxtBeforeYear
    '
    Me.TxtBeforeYear.Location = New System.Drawing.Point(401, 9)
    Me.TxtBeforeYear.MaxLength = 4
    Me.TxtBeforeYear.Name = "TxtBeforeYear"
    Me.TxtBeforeYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtBeforeYear.TabIndex = 28
    '
    'RbSortCCNo
    '
    Me.RbSortCCNo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortCCNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortCCNo.Location = New System.Drawing.Point(6, 59)
    Me.RbSortCCNo.Name = "RbSortCCNo"
    Me.RbSortCCNo.Size = New System.Drawing.Size(120, 20)
    Me.RbSortCCNo.TabIndex = 4
    Me.RbSortCCNo.Text = "Certificate Number"
    '
    'FrmTA801B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(446, 452)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtBeforeYear)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.ChkShowUser)
    Me.Controls.Add(Me.TxtUserID)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.ChkBAA)
    Me.Controls.Add(Me.GrpTax)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.ChkGross)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.RbAfter)
    Me.Controls.Add(Me.TxtToGLYear)
    Me.Controls.Add(Me.TxtFromGLYear)
    Me.Controls.Add(Me.TxtType)
    Me.Controls.Add(Me.RbBefore)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.LnkType)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA801B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GrpTax.ResumeLayout(False)
    Me.GrpTax.PerformLayout()
    Me.GroupBox4.ResumeLayout(False)
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
    If RbAfter.Checked Then
      PrtReportAfter()
    Else
      PrtReportBefore()
    End If
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmTA801B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXCNTL = New TXCNTL.MyData(myDBConnect)
    myTXCNTL.GetOneRecordP("")
    If Not myTXCNTL.RecordNotFound Then
      TxtBeforeYear.Text = myTXCNTL._ASRGL
    End If
    DtPckFrom.Value = Date.Today
    DtPckTo.Value = Date.Today
    GrpTax.Visible = False
    ChkBAA.Visible = False
    Me.Height = 380

End Sub
Private Sub FrmTA801B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA801.SbpScreen.Text = "TA801B"
End Sub

Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
  MyFrmListTypes = New FrmListTypes
  MyFrmListTypes.MdiParent = Me.ParentForm
  MyFrmListTypes.WrkType = TxtType.Text
  MyFrmListTypes.Show()

End Sub
Private Sub FrmTA801B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFromGLYear, "")
    ErrProv.SetError(TxtToGLYear, "")
    ErrProv.SetError(DtPckFrom, "")
    ErrProv.SetError(DtPckTo, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "fromglyear"
        ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
      Case "toglyear"
        ErrProv.SetError(TxtToGLYear, ErrorMsg(I))
      Case "from"
        ErrProv.SetError(DtPckFrom, ErrorMsg(I))
      Case "to"
        ErrProv.SetError(DtPckTo, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtFromGLYear.Text) > 0 Then
      If MyUtils.CnvSng(TxtFromGLYear.Text) > MyUtils.CnvSng(TxtToGLYear.Text) Then
        ErrorField(I) = "fromglyear"
        ErrorMsg(I) = "Invalid Year Range"
        I = I + 1
        ErrorField(I) = "toglyear"
        ErrorMsg(I) = "Invalid Year Range"
        I = I + 1
      End If
    End If

    If MyUtils.SetDBDate(DtPckFrom.Value) > MyUtils.SetDBDate(DtPckTo.Value) Then
      ErrorField(I) = "to"
      ErrorMsg(I) = "Invalid date Range"
      I = I + 1
    End If
  End Sub

Private Sub LnkFrmReason_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFrmReason.LinkClicked
  MyFrmListCCReason = New FrmListCCReason
  MyFrmListCCReason.MdiParent = Me.ParentForm
  MyFrmListCCReason.WrkCode = TxtFromReason.Text
  MyFrmListCCReason.WrkField = "From"
  MyFrmListCCReason.Show()
End Sub
Private Sub LnkToReason_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkToReason.LinkClicked
  MyFrmListCCReason = New FrmListCCReason
  MyFrmListCCReason.MdiParent = Me.ParentForm
  MyFrmListCCReason.WrkCode = TxtToReason.Text
  MyFrmListCCReason.WrkField = "To"
  MyFrmListCCReason.Show()
End Sub
Private Sub TxtFromGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub RbAfter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbAfter.Click
  GrpTax.Visible = False
  ChkBAA.Visible = False
  Me.Height = 380
End Sub

Private Sub RbBefore_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbBefore.Click
  GrpTax.Visible = True
  ChkBAA.Visible = True
  Me.Height = 470
End Sub
End Class






