Public Class FrmGL402B
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
Friend WithEvents RbFileHist As System.Windows.Forms.RadioButton
Friend WithEvents RbFileCurr As System.Windows.Forms.RadioButton
Friend WithEvents LnkFundTo As System.Windows.Forms.LinkLabel
Friend WithEvents TxtSfuncTo As System.Windows.Forms.TextBox
Friend WithEvents TxtSfuncFrom As System.Windows.Forms.TextBox
Friend WithEvents Label10 As System.Windows.Forms.Label
Friend WithEvents Label11 As System.Windows.Forms.Label
Friend WithEvents LnkFuncFrom As System.Windows.Forms.LinkLabel
Friend WithEvents TxtFuncTo As System.Windows.Forms.TextBox
Friend WithEvents TxtFuncFrom As System.Windows.Forms.TextBox
Friend WithEvents Label9 As System.Windows.Forms.Label
Friend WithEvents LnkObjFrom As System.Windows.Forms.LinkLabel
Friend WithEvents TxtObjTo As System.Windows.Forms.TextBox
Friend WithEvents TxtObjFrom As System.Windows.Forms.TextBox
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents TxtDeptTo As System.Windows.Forms.TextBox
Friend WithEvents TxtDeptFrom As System.Windows.Forms.TextBox
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents TxtSfundTo As System.Windows.Forms.TextBox
Friend WithEvents TxtSfundFrom As System.Windows.Forms.TextBox
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents LnkFundFrom As System.Windows.Forms.LinkLabel
Friend WithEvents TxtFundTo As System.Windows.Forms.TextBox
Friend WithEvents TxtFundFrom As System.Windows.Forms.TextBox
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbTypeTransfer As System.Windows.Forms.RadioButton
Friend WithEvents RbTypeEncum As System.Windows.Forms.RadioButton
Friend WithEvents RbTypeBudget As System.Windows.Forms.RadioButton
Friend WithEvents RbTypeAdjust As System.Windows.Forms.RadioButton
Friend WithEvents RbTypeAll As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents TxtBatchTo As System.Windows.Forms.TextBox
Friend WithEvents TxtBatchFrom As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Label12 As System.Windows.Forms.Label
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.RbFileHist = New System.Windows.Forms.RadioButton()
    Me.RbFileCurr = New System.Windows.Forms.RadioButton()
    Me.LnkFundTo = New System.Windows.Forms.LinkLabel()
    Me.TxtSfuncTo = New System.Windows.Forms.TextBox()
    Me.TxtSfuncFrom = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.LnkFuncFrom = New System.Windows.Forms.LinkLabel()
    Me.TxtFuncTo = New System.Windows.Forms.TextBox()
    Me.TxtFuncFrom = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.LnkObjFrom = New System.Windows.Forms.LinkLabel()
    Me.TxtObjTo = New System.Windows.Forms.TextBox()
    Me.TxtObjFrom = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtDeptTo = New System.Windows.Forms.TextBox()
    Me.TxtDeptFrom = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtSfundTo = New System.Windows.Forms.TextBox()
    Me.TxtSfundFrom = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.LnkFundFrom = New System.Windows.Forms.LinkLabel()
    Me.TxtFundTo = New System.Windows.Forms.TextBox()
    Me.TxtFundFrom = New System.Windows.Forms.TextBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbTypeTransfer = New System.Windows.Forms.RadioButton()
    Me.RbTypeEncum = New System.Windows.Forms.RadioButton()
    Me.RbTypeBudget = New System.Windows.Forms.RadioButton()
    Me.RbTypeAdjust = New System.Windows.Forms.RadioButton()
    Me.RbTypeAll = New System.Windows.Forms.RadioButton()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.TxtBatchTo = New System.Windows.Forms.TextBox()
    Me.TxtBatchFrom = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'RbFileHist
    '
    Me.RbFileHist.AutoSize = True
    Me.RbFileHist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFileHist.Location = New System.Drawing.Point(106, 22)
    Me.RbFileHist.Name = "RbFileHist"
    Me.RbFileHist.Size = New System.Drawing.Size(57, 17)
    Me.RbFileHist.TabIndex = 1
    Me.RbFileHist.Text = "History"
    Me.RbFileHist.UseVisualStyleBackColor = True
    '
    'RbFileCurr
    '
    Me.RbFileCurr.AutoSize = True
    Me.RbFileCurr.Checked = True
    Me.RbFileCurr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFileCurr.Location = New System.Drawing.Point(26, 22)
    Me.RbFileCurr.Name = "RbFileCurr"
    Me.RbFileCurr.Size = New System.Drawing.Size(59, 17)
    Me.RbFileCurr.TabIndex = 0
    Me.RbFileCurr.TabStop = True
    Me.RbFileCurr.Text = "Current"
    Me.RbFileCurr.UseVisualStyleBackColor = True
    '
    'LnkFundTo
    '
    Me.LnkFundTo.AutoSize = True
    Me.LnkFundTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFundTo.Location = New System.Drawing.Point(113, 158)
    Me.LnkFundTo.Name = "LnkFundTo"
    Me.LnkFundTo.Size = New System.Drawing.Size(16, 13)
    Me.LnkFundTo.TabIndex = 5
    Me.LnkFundTo.TabStop = True
    Me.LnkFundTo.Text = "to"
    '
    'TxtSfuncTo
    '
    Me.TxtSfuncTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfuncTo.Location = New System.Drawing.Point(135, 282)
    Me.TxtSfuncTo.MaxLength = 4
    Me.TxtSfuncTo.Name = "TxtSfuncTo"
    Me.TxtSfuncTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtSfuncTo.TabIndex = 19
    '
    'TxtSfuncFrom
    '
    Me.TxtSfuncFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfuncFrom.Location = New System.Drawing.Point(73, 282)
    Me.TxtSfuncFrom.MaxLength = 4
    Me.TxtSfuncFrom.Name = "TxtSfuncFrom"
    Me.TxtSfuncFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtSfuncFrom.TabIndex = 18
    '
    'Label10
    '
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(113, 285)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(16, 16)
    Me.Label10.TabIndex = 368
    Me.Label10.Text = "to"
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.Location = New System.Drawing.Point(6, 285)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(64, 13)
    Me.Label11.TabIndex = 367
    Me.Label11.Text = "Subfunction"
    '
    'LnkFuncFrom
    '
    Me.LnkFuncFrom.AutoSize = True
    Me.LnkFuncFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFuncFrom.Location = New System.Drawing.Point(8, 260)
    Me.LnkFuncFrom.Name = "LnkFuncFrom"
    Me.LnkFuncFrom.Size = New System.Drawing.Size(48, 13)
    Me.LnkFuncFrom.TabIndex = 15
    Me.LnkFuncFrom.TabStop = True
    Me.LnkFuncFrom.Text = "Function"
    '
    'TxtFuncTo
    '
    Me.TxtFuncTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFuncTo.Location = New System.Drawing.Point(135, 256)
    Me.TxtFuncTo.MaxLength = 4
    Me.TxtFuncTo.Name = "TxtFuncTo"
    Me.TxtFuncTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtFuncTo.TabIndex = 17
    '
    'TxtFuncFrom
    '
    Me.TxtFuncFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFuncFrom.Location = New System.Drawing.Point(73, 256)
    Me.TxtFuncFrom.MaxLength = 4
    Me.TxtFuncFrom.Name = "TxtFuncFrom"
    Me.TxtFuncFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtFuncFrom.TabIndex = 16
    '
    'Label9
    '
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(113, 259)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(16, 16)
    Me.Label9.TabIndex = 365
    Me.Label9.Text = "to"
    '
    'LnkObjFrom
    '
    Me.LnkObjFrom.AutoSize = True
    Me.LnkObjFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkObjFrom.Location = New System.Drawing.Point(8, 235)
    Me.LnkObjFrom.Name = "LnkObjFrom"
    Me.LnkObjFrom.Size = New System.Drawing.Size(38, 13)
    Me.LnkObjFrom.TabIndex = 12
    Me.LnkObjFrom.TabStop = True
    Me.LnkObjFrom.Text = "Object"
    '
    'TxtObjTo
    '
    Me.TxtObjTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObjTo.Location = New System.Drawing.Point(135, 231)
    Me.TxtObjTo.MaxLength = 3
    Me.TxtObjTo.Name = "TxtObjTo"
    Me.TxtObjTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtObjTo.TabIndex = 14
    '
    'TxtObjFrom
    '
    Me.TxtObjFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObjFrom.Location = New System.Drawing.Point(73, 231)
    Me.TxtObjFrom.MaxLength = 3
    Me.TxtObjFrom.Name = "TxtObjFrom"
    Me.TxtObjFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtObjFrom.TabIndex = 13
    '
    'Label8
    '
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(113, 234)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(16, 16)
    Me.Label8.TabIndex = 363
    Me.Label8.Text = "to"
    '
    'TxtDeptTo
    '
    Me.TxtDeptTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDeptTo.Location = New System.Drawing.Point(135, 207)
    Me.TxtDeptTo.MaxLength = 4
    Me.TxtDeptTo.Name = "TxtDeptTo"
    Me.TxtDeptTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtDeptTo.TabIndex = 11
    '
    'TxtDeptFrom
    '
    Me.TxtDeptFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDeptFrom.Location = New System.Drawing.Point(73, 207)
    Me.TxtDeptFrom.MaxLength = 4
    Me.TxtDeptFrom.Name = "TxtDeptFrom"
    Me.TxtDeptFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtDeptFrom.TabIndex = 10
    '
    'Label6
    '
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(113, 210)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(16, 16)
    Me.Label6.TabIndex = 362
    Me.Label6.Text = "to"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(6, 210)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(62, 13)
    Me.Label7.TabIndex = 361
    Me.Label7.Text = "Department"
    '
    'TxtSfundTo
    '
    Me.TxtSfundTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfundTo.Location = New System.Drawing.Point(135, 181)
    Me.TxtSfundTo.MaxLength = 3
    Me.TxtSfundTo.Name = "TxtSfundTo"
    Me.TxtSfundTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtSfundTo.TabIndex = 9
    '
    'TxtSfundFrom
    '
    Me.TxtSfundFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfundFrom.Location = New System.Drawing.Point(73, 181)
    Me.TxtSfundFrom.MaxLength = 3
    Me.TxtSfundFrom.Name = "TxtSfundFrom"
    Me.TxtSfundFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtSfundFrom.TabIndex = 8
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(113, 184)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(16, 16)
    Me.Label5.TabIndex = 360
    Me.Label5.Text = "to"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(6, 184)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(53, 13)
    Me.Label4.TabIndex = 359
    Me.Label4.Text = "Sub Fund"
    '
    'LnkFundFrom
    '
    Me.LnkFundFrom.AutoSize = True
    Me.LnkFundFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFundFrom.Location = New System.Drawing.Point(8, 159)
    Me.LnkFundFrom.Name = "LnkFundFrom"
    Me.LnkFundFrom.Size = New System.Drawing.Size(31, 13)
    Me.LnkFundFrom.TabIndex = 4
    Me.LnkFundFrom.TabStop = True
    Me.LnkFundFrom.Text = "Fund"
    '
    'TxtFundTo
    '
    Me.TxtFundTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFundTo.Location = New System.Drawing.Point(135, 155)
    Me.TxtFundTo.MaxLength = 3
    Me.TxtFundTo.Name = "TxtFundTo"
    Me.TxtFundTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtFundTo.TabIndex = 7
    '
    'TxtFundFrom
    '
    Me.TxtFundFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFundFrom.Location = New System.Drawing.Point(73, 155)
    Me.TxtFundFrom.MaxLength = 3
    Me.TxtFundFrom.Name = "TxtFundFrom"
    Me.TxtFundFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtFundFrom.TabIndex = 6
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbTypeTransfer)
    Me.GroupBox2.Controls.Add(Me.RbTypeEncum)
    Me.GroupBox2.Controls.Add(Me.RbTypeBudget)
    Me.GroupBox2.Controls.Add(Me.RbTypeAdjust)
    Me.GroupBox2.Controls.Add(Me.RbTypeAll)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(11, 45)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(351, 39)
    Me.GroupBox2.TabIndex = 2
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Entry Type"
    '
    'RbTypeTransfer
    '
    Me.RbTypeTransfer.AutoSize = True
    Me.RbTypeTransfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbTypeTransfer.Location = New System.Drawing.Point(282, 19)
    Me.RbTypeTransfer.Name = "RbTypeTransfer"
    Me.RbTypeTransfer.Size = New System.Drawing.Size(64, 17)
    Me.RbTypeTransfer.TabIndex = 5
    Me.RbTypeTransfer.TabStop = True
    Me.RbTypeTransfer.Text = "Transfer"
    Me.RbTypeTransfer.UseVisualStyleBackColor = True
    '
    'RbTypeEncum
    '
    Me.RbTypeEncum.AutoSize = True
    Me.RbTypeEncum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbTypeEncum.Location = New System.Drawing.Point(218, 19)
    Me.RbTypeEncum.Name = "RbTypeEncum"
    Me.RbTypeEncum.Size = New System.Drawing.Size(58, 17)
    Me.RbTypeEncum.TabIndex = 4
    Me.RbTypeEncum.Text = "Encum"
    Me.RbTypeEncum.UseVisualStyleBackColor = True
    '
    'RbTypeBudget
    '
    Me.RbTypeBudget.AutoSize = True
    Me.RbTypeBudget.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbTypeBudget.Location = New System.Drawing.Point(145, 19)
    Me.RbTypeBudget.Name = "RbTypeBudget"
    Me.RbTypeBudget.Size = New System.Drawing.Size(59, 17)
    Me.RbTypeBudget.TabIndex = 3
    Me.RbTypeBudget.Text = "Budget"
    Me.RbTypeBudget.UseVisualStyleBackColor = True
    '
    'RbTypeAdjust
    '
    Me.RbTypeAdjust.AutoSize = True
    Me.RbTypeAdjust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbTypeAdjust.Location = New System.Drawing.Point(62, 19)
    Me.RbTypeAdjust.Name = "RbTypeAdjust"
    Me.RbTypeAdjust.Size = New System.Drawing.Size(77, 17)
    Me.RbTypeAdjust.TabIndex = 1
    Me.RbTypeAdjust.Text = "Adjustment"
    Me.RbTypeAdjust.UseVisualStyleBackColor = True
    '
    'RbTypeAll
    '
    Me.RbTypeAll.AutoSize = True
    Me.RbTypeAll.Checked = True
    Me.RbTypeAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbTypeAll.Location = New System.Drawing.Point(15, 19)
    Me.RbTypeAll.Name = "RbTypeAll"
    Me.RbTypeAll.Size = New System.Drawing.Size(36, 17)
    Me.RbTypeAll.TabIndex = 0
    Me.RbTypeAll.TabStop = True
    Me.RbTypeAll.Text = "All"
    Me.RbTypeAll.UseVisualStyleBackColor = True
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.DtPckTo)
    Me.GroupBox3.Controls.Add(Me.Label2)
    Me.GroupBox3.Controls.Add(Me.DtPckFrom)
    Me.GroupBox3.Controls.Add(Me.Label1)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(11, 90)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(286, 52)
    Me.GroupBox3.TabIndex = 3
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Date Range"
    '
    'DtPckTo
    '
    Me.DtPckTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(185, 20)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
    Me.DtPckTo.TabIndex = 1
    Me.DtPckTo.Value = New Date(2005, 10, 6, 9, 11, 0, 906)
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(151, 24)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(28, 16)
    Me.Label2.TabIndex = 9
    Me.Label2.Text = "To "
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(52, 20)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
    Me.DtPckFrom.TabIndex = 0
    Me.DtPckFrom.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(12, 20)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(36, 16)
    Me.Label1.TabIndex = 7
    Me.Label1.Text = "From"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.TxtBatchTo)
    Me.GroupBox1.Controls.Add(Me.TxtBatchFrom)
    Me.GroupBox1.Controls.Add(Me.Label3)
    Me.GroupBox1.Controls.Add(Me.Label12)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(9, 312)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(181, 39)
    Me.GroupBox1.TabIndex = 20
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Optional: "
    '
    'TxtBatchTo
    '
    Me.TxtBatchTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBatchTo.Location = New System.Drawing.Point(137, 13)
    Me.TxtBatchTo.MaxLength = 3
    Me.TxtBatchTo.Name = "TxtBatchTo"
    Me.TxtBatchTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtBatchTo.TabIndex = 362
    '
    'TxtBatchFrom
    '
    Me.TxtBatchFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBatchFrom.Location = New System.Drawing.Point(75, 13)
    Me.TxtBatchFrom.MaxLength = 3
    Me.TxtBatchFrom.Name = "TxtBatchFrom"
    Me.TxtBatchFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtBatchFrom.TabIndex = 361
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(115, 16)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(16, 16)
    Me.Label3.TabIndex = 364
    Me.Label3.Text = "to"
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(8, 16)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(61, 13)
    Me.Label12.TabIndex = 363
    Me.Label12.Text = "Batch From"
    '
    'FrmGL402B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(419, 363)
    Me.ControlBox = False
    Me.Controls.Add(Me.RbFileHist)
    Me.Controls.Add(Me.RbFileCurr)
    Me.Controls.Add(Me.LnkFundTo)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TxtSfuncTo)
    Me.Controls.Add(Me.TxtSfuncFrom)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.LnkFuncFrom)
    Me.Controls.Add(Me.TxtFuncTo)
    Me.Controls.Add(Me.TxtFuncFrom)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.LnkObjFrom)
    Me.Controls.Add(Me.TxtObjTo)
    Me.Controls.Add(Me.TxtObjFrom)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.TxtDeptTo)
    Me.Controls.Add(Me.TxtDeptFrom)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtSfundTo)
    Me.Controls.Add(Me.TxtSfundFrom)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.LnkFundFrom)
    Me.Controls.Add(Me.TxtFundTo)
    Me.Controls.Add(Me.TxtFundFrom)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL402B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmGL402B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGL402.SbpScreen.Text = "GL402"
End Sub
Private Sub LnkFundFrom_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFundFrom.LinkClicked
  MyFrmListFund = New FrmListFund
  MyFrmListFund.MdiParent = Me.ParentForm
  MyFrmListFund.WrkFund = MyUtils.CnvSng(TxtFundFrom.Text)
  MyFrmListFund.WrkID = "From"
  MyFrmListFund.Show()
  Me.Hide()
End Sub
Private Sub LnkFundTo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFundTo.LinkClicked
  MyFrmListFund = New FrmListFund
  MyFrmListFund.MdiParent = Me.ParentForm
  MyFrmListFund.WrkFund = MyUtils.CnvSng(TxtFundTo.Text)
  MyFrmListFund.WrkID = "To"
  MyFrmListFund.Show()
  Me.Hide()
End Sub
Private Sub FrmGL402B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFundFrom, "")
    ErrProv.SetError(TxtFundTo, "")
    ErrProv.SetError(TxtSfundFrom, "")
    ErrProv.SetError(TxtSfundTo, "")
    ErrProv.SetError(TxtDeptFrom, "")
    ErrProv.SetError(TxtDeptTo, "")
    ErrProv.SetError(TxtObjFrom, "")
    ErrProv.SetError(TxtObjTo, "")
    ErrProv.SetError(DtPckFrom, "")
    ErrProv.SetError(DtPckTo, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "fundfrom"
        ErrProv.SetError(TxtFundFrom, ErrorMsg(I))
      Case "fundto"
        ErrProv.SetError(TxtFundTo, ErrorMsg(I))
      Case "sfundfrom"
        ErrProv.SetError(TxtSfundFrom, ErrorMsg(I))
      Case "sfundto"
        ErrProv.SetError(TxtSfundTo, ErrorMsg(I))
      Case "deptfrom"
        ErrProv.SetError(TxtDeptFrom, ErrorMsg(I))
      Case "deptto"
        ErrProv.SetError(TxtDeptTo, ErrorMsg(I))
      Case "objfrom"
        ErrProv.SetError(TxtObjFrom, ErrorMsg(I))
      Case "objto"
        ErrProv.SetError(TxtObjTo, ErrorMsg(I))
      Case "date"
        ErrProv.SetError(DtPckFrom, ErrorMsg(I))
      Case "date"
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

    If MyUtils.CnvSng(TxtFundFrom.Text) > MyUtils.CnvSng(TxtFundTo.Text) Then
      ErrorField(I) = "fundfrom"
      ErrorMsg(I) = "Invalid Fund Range"
      I = I + 1
      ErrorField(I) = "fundto"
      ErrorMsg(I) = "Invalid Fund Range"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtSfundFrom.Text) > MyUtils.CnvSng(TxtSfundTo.Text) Then
      ErrorField(I) = "sfundfrom"
      ErrorMsg(I) = "Invalid Sfund Range"
      I = I + 1
      ErrorField(I) = "sfundto"
      ErrorMsg(I) = "Invalid Sfund Range"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtDeptFrom.Text) > MyUtils.CnvSng(TxtDeptTo.Text) Then
      ErrorField(I) = "deptfrom"
      ErrorMsg(I) = "Invalid Dept Range"
      I = I + 1
      ErrorField(I) = "deptto"
      ErrorMsg(I) = "Invalid Dept Range"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtObjFrom.Text) > MyUtils.CnvSng(TxtObjTo.Text) Then
      ErrorField(I) = "objfrom"
      ErrorMsg(I) = "Invalid Obj Range"
      I = I + 1
      ErrorField(I) = "objto"
      ErrorMsg(I) = "Invalid Obj Range"
      I = I + 1
    End If

    If MyUtils.SetDBDate(DtPckFrom.Value) > MyUtils.SetDBDate(DtPckTo.Value) Then
      ErrorField(I) = "date"
      ErrorMsg(I) = "Invalid date Range"
      I = I + 1
    End If

  End Sub

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

Private Sub FrmGL402B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  InitFiles()
  If Now.Date.Month >= 7 Then
    DtPckFrom.Value = "#7/1/" & Now.Date.Year & "#"
  Else
    DtPckFrom.Value = "#7/1/" & Now.Date.Year - 1 & "#"
  End If
  DtPckTo.Value = Now.Date
End Sub
Private Sub TxtFundFrom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFundFrom.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtSfundFrom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfundFrom.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDeptFrom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDeptFrom.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtObjFrom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtObjFrom.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtFuncFrom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFuncFrom.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtSfuncFrom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfuncFrom.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtFundTo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFundTo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtSfundTo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfundTo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDeptTo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDeptTo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtObjTo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtObjTo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtFuncTo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFuncTo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtSfuncTo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfuncTo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class
