Public Class FrmGL205B
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
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbTypeExpense As System.Windows.Forms.RadioButton
  Friend WithEvents RbTypeRevenue As System.Windows.Forms.RadioButton
  Friend WithEvents RbTypeEquity As System.Windows.Forms.RadioButton
  Friend WithEvents RbTypeAsset As System.Windows.Forms.RadioButton
  Friend WithEvents RbTypeLiability As System.Windows.Forms.RadioButton
  Friend WithEvents RbTypeAll As System.Windows.Forms.RadioButton
  Friend WithEvents TxtSfuncTo As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfuncFrom As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents LnkFuncFrom As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtFuncTo As System.Windows.Forms.TextBox
  Friend WithEvents TxtFuncFrom As System.Windows.Forms.TextBox
  Friend WithEvents LnkObjFrom As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtObjTo As System.Windows.Forms.TextBox
  Friend WithEvents TxtObjFrom As System.Windows.Forms.TextBox
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
  Friend WithEvents LnkFundTo As System.Windows.Forms.LinkLabel
  Friend WithEvents RbFileHist As System.Windows.Forms.RadioButton
  Friend WithEvents RbFileCurr As System.Windows.Forms.RadioButton
  Friend WithEvents ChkPageDept As System.Windows.Forms.CheckBox
  Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
  Friend WithEvents GrpDownload As System.Windows.Forms.GroupBox
  Friend WithEvents RbExpState As System.Windows.Forms.RadioButton
  Friend WithEvents RbExpAll As System.Windows.Forms.RadioButton
  Friend WithEvents LblFilePath As System.Windows.Forms.Label
  Friend WithEvents GroupBox2 As GroupBox
  Friend WithEvents RbSourceTax As RadioButton
  Friend WithEvents RbSourcePR As RadioButton
  Friend WithEvents RbSourceEncum As RadioButton
  Friend WithEvents RbSourceCash As RadioButton
  Friend WithEvents RbSourceAP As RadioButton
  Friend WithEvents RbSourceJE As RadioButton
  Friend WithEvents RbSourceAll As RadioButton
  Friend WithEvents LnkFuncTo As LinkLabel
  Friend WithEvents LnkObjTo As LinkLabel
  Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.LnkFundFrom = New System.Windows.Forms.LinkLabel()
    Me.TxtFundTo = New System.Windows.Forms.TextBox()
    Me.TxtFundFrom = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtSfundTo = New System.Windows.Forms.TextBox()
    Me.TxtSfundFrom = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtDeptTo = New System.Windows.Forms.TextBox()
    Me.TxtDeptFrom = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.LnkObjFrom = New System.Windows.Forms.LinkLabel()
    Me.TxtObjTo = New System.Windows.Forms.TextBox()
    Me.TxtObjFrom = New System.Windows.Forms.TextBox()
    Me.LnkFuncFrom = New System.Windows.Forms.LinkLabel()
    Me.TxtFuncTo = New System.Windows.Forms.TextBox()
    Me.TxtFuncFrom = New System.Windows.Forms.TextBox()
    Me.TxtSfuncTo = New System.Windows.Forms.TextBox()
    Me.TxtSfuncFrom = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbTypeExpense = New System.Windows.Forms.RadioButton()
    Me.RbTypeRevenue = New System.Windows.Forms.RadioButton()
    Me.RbTypeEquity = New System.Windows.Forms.RadioButton()
    Me.RbTypeAsset = New System.Windows.Forms.RadioButton()
    Me.RbTypeLiability = New System.Windows.Forms.RadioButton()
    Me.RbTypeAll = New System.Windows.Forms.RadioButton()
    Me.LnkFundTo = New System.Windows.Forms.LinkLabel()
    Me.RbFileCurr = New System.Windows.Forms.RadioButton()
    Me.RbFileHist = New System.Windows.Forms.RadioButton()
    Me.ChkPageDept = New System.Windows.Forms.CheckBox()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.GrpDownload = New System.Windows.Forms.GroupBox()
    Me.RbExpState = New System.Windows.Forms.RadioButton()
    Me.RbExpAll = New System.Windows.Forms.RadioButton()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbSourceTax = New System.Windows.Forms.RadioButton()
    Me.RbSourcePR = New System.Windows.Forms.RadioButton()
    Me.RbSourceEncum = New System.Windows.Forms.RadioButton()
    Me.RbSourceCash = New System.Windows.Forms.RadioButton()
    Me.RbSourceAP = New System.Windows.Forms.RadioButton()
    Me.RbSourceJE = New System.Windows.Forms.RadioButton()
    Me.RbSourceAll = New System.Windows.Forms.RadioButton()
    Me.LnkFuncTo = New System.Windows.Forms.LinkLabel()
    Me.LnkObjTo = New System.Windows.Forms.LinkLabel()
    Me.GroupBox3.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GrpDownload.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.DtPckTo)
    Me.GroupBox3.Controls.Add(Me.Label2)
    Me.GroupBox3.Controls.Add(Me.DtPckFrom)
    Me.GroupBox3.Controls.Add(Me.Label1)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(24, 80)
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
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LnkFundFrom
    '
    Me.LnkFundFrom.AutoSize = True
    Me.LnkFundFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFundFrom.Location = New System.Drawing.Point(21, 149)
    Me.LnkFundFrom.Name = "LnkFundFrom"
    Me.LnkFundFrom.Size = New System.Drawing.Size(31, 13)
    Me.LnkFundFrom.TabIndex = 318
    Me.LnkFundFrom.TabStop = True
    Me.LnkFundFrom.Text = "Fund"
    '
    'TxtFundTo
    '
    Me.TxtFundTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFundTo.Location = New System.Drawing.Point(148, 145)
    Me.TxtFundTo.MaxLength = 3
    Me.TxtFundTo.Name = "TxtFundTo"
    Me.TxtFundTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtFundTo.TabIndex = 5
    '
    'TxtFundFrom
    '
    Me.TxtFundFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFundFrom.Location = New System.Drawing.Point(86, 145)
    Me.TxtFundFrom.MaxLength = 3
    Me.TxtFundFrom.Name = "TxtFundFrom"
    Me.TxtFundFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtFundFrom.TabIndex = 4
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(19, 174)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(53, 13)
    Me.Label4.TabIndex = 319
    Me.Label4.Text = "Sub Fund"
    '
    'TxtSfundTo
    '
    Me.TxtSfundTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfundTo.Location = New System.Drawing.Point(148, 171)
    Me.TxtSfundTo.MaxLength = 3
    Me.TxtSfundTo.Name = "TxtSfundTo"
    Me.TxtSfundTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtSfundTo.TabIndex = 7
    '
    'TxtSfundFrom
    '
    Me.TxtSfundFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfundFrom.Location = New System.Drawing.Point(86, 171)
    Me.TxtSfundFrom.MaxLength = 3
    Me.TxtSfundFrom.Name = "TxtSfundFrom"
    Me.TxtSfundFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtSfundFrom.TabIndex = 6
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(126, 174)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(16, 16)
    Me.Label5.TabIndex = 322
    Me.Label5.Text = "to"
    '
    'TxtDeptTo
    '
    Me.TxtDeptTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDeptTo.Location = New System.Drawing.Point(148, 197)
    Me.TxtDeptTo.MaxLength = 4
    Me.TxtDeptTo.Name = "TxtDeptTo"
    Me.TxtDeptTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtDeptTo.TabIndex = 9
    '
    'TxtDeptFrom
    '
    Me.TxtDeptFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDeptFrom.Location = New System.Drawing.Point(86, 197)
    Me.TxtDeptFrom.MaxLength = 4
    Me.TxtDeptFrom.Name = "TxtDeptFrom"
    Me.TxtDeptFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtDeptFrom.TabIndex = 8
    '
    'Label6
    '
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(126, 200)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(16, 16)
    Me.Label6.TabIndex = 326
    Me.Label6.Text = "to"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(19, 200)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(62, 13)
    Me.Label7.TabIndex = 323
    Me.Label7.Text = "Department"
    '
    'LnkObjFrom
    '
    Me.LnkObjFrom.AutoSize = True
    Me.LnkObjFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkObjFrom.Location = New System.Drawing.Point(21, 225)
    Me.LnkObjFrom.Name = "LnkObjFrom"
    Me.LnkObjFrom.Size = New System.Drawing.Size(38, 13)
    Me.LnkObjFrom.TabIndex = 330
    Me.LnkObjFrom.TabStop = True
    Me.LnkObjFrom.Text = "Object"
    '
    'TxtObjTo
    '
    Me.TxtObjTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObjTo.Location = New System.Drawing.Point(148, 221)
    Me.TxtObjTo.MaxLength = 3
    Me.TxtObjTo.Name = "TxtObjTo"
    Me.TxtObjTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtObjTo.TabIndex = 11
    '
    'TxtObjFrom
    '
    Me.TxtObjFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObjFrom.Location = New System.Drawing.Point(86, 221)
    Me.TxtObjFrom.MaxLength = 3
    Me.TxtObjFrom.Name = "TxtObjFrom"
    Me.TxtObjFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtObjFrom.TabIndex = 10
    '
    'LnkFuncFrom
    '
    Me.LnkFuncFrom.AutoSize = True
    Me.LnkFuncFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFuncFrom.Location = New System.Drawing.Point(21, 250)
    Me.LnkFuncFrom.Name = "LnkFuncFrom"
    Me.LnkFuncFrom.Size = New System.Drawing.Size(48, 13)
    Me.LnkFuncFrom.TabIndex = 334
    Me.LnkFuncFrom.TabStop = True
    Me.LnkFuncFrom.Text = "Function"
    '
    'TxtFuncTo
    '
    Me.TxtFuncTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFuncTo.Location = New System.Drawing.Point(148, 246)
    Me.TxtFuncTo.MaxLength = 4
    Me.TxtFuncTo.Name = "TxtFuncTo"
    Me.TxtFuncTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtFuncTo.TabIndex = 13
    '
    'TxtFuncFrom
    '
    Me.TxtFuncFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFuncFrom.Location = New System.Drawing.Point(86, 246)
    Me.TxtFuncFrom.MaxLength = 4
    Me.TxtFuncFrom.Name = "TxtFuncFrom"
    Me.TxtFuncFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtFuncFrom.TabIndex = 12
    '
    'TxtSfuncTo
    '
    Me.TxtSfuncTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfuncTo.Location = New System.Drawing.Point(148, 272)
    Me.TxtSfuncTo.MaxLength = 4
    Me.TxtSfuncTo.Name = "TxtSfuncTo"
    Me.TxtSfuncTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtSfuncTo.TabIndex = 15
    '
    'TxtSfuncFrom
    '
    Me.TxtSfuncFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfuncFrom.Location = New System.Drawing.Point(86, 272)
    Me.TxtSfuncFrom.MaxLength = 4
    Me.TxtSfuncFrom.Name = "TxtSfuncFrom"
    Me.TxtSfuncFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtSfuncFrom.TabIndex = 14
    '
    'Label10
    '
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(126, 275)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(16, 16)
    Me.Label10.TabIndex = 338
    Me.Label10.Text = "to"
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.Location = New System.Drawing.Point(19, 275)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(64, 13)
    Me.Label11.TabIndex = 335
    Me.Label11.Text = "Subfunction"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbTypeExpense)
    Me.GroupBox1.Controls.Add(Me.RbTypeRevenue)
    Me.GroupBox1.Controls.Add(Me.RbTypeEquity)
    Me.GroupBox1.Controls.Add(Me.RbTypeAsset)
    Me.GroupBox1.Controls.Add(Me.RbTypeLiability)
    Me.GroupBox1.Controls.Add(Me.RbTypeAll)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(22, 298)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(396, 39)
    Me.GroupBox1.TabIndex = 16
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Entry Type"
    '
    'RbTypeExpense
    '
    Me.RbTypeExpense.AutoSize = True
    Me.RbTypeExpense.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbTypeExpense.Location = New System.Drawing.Point(319, 19)
    Me.RbTypeExpense.Name = "RbTypeExpense"
    Me.RbTypeExpense.Size = New System.Drawing.Size(66, 17)
    Me.RbTypeExpense.TabIndex = 5
    Me.RbTypeExpense.TabStop = True
    Me.RbTypeExpense.Text = "Expense"
    Me.RbTypeExpense.UseVisualStyleBackColor = True
    '
    'RbTypeRevenue
    '
    Me.RbTypeRevenue.AutoSize = True
    Me.RbTypeRevenue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbTypeRevenue.Location = New System.Drawing.Point(244, 19)
    Me.RbTypeRevenue.Name = "RbTypeRevenue"
    Me.RbTypeRevenue.Size = New System.Drawing.Size(69, 17)
    Me.RbTypeRevenue.TabIndex = 4
    Me.RbTypeRevenue.Text = "Revenue"
    Me.RbTypeRevenue.UseVisualStyleBackColor = True
    '
    'RbTypeEquity
    '
    Me.RbTypeEquity.AutoSize = True
    Me.RbTypeEquity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbTypeEquity.Location = New System.Drawing.Point(184, 19)
    Me.RbTypeEquity.Name = "RbTypeEquity"
    Me.RbTypeEquity.Size = New System.Drawing.Size(54, 17)
    Me.RbTypeEquity.TabIndex = 3
    Me.RbTypeEquity.Text = "Equity"
    Me.RbTypeEquity.UseVisualStyleBackColor = True
    '
    'RbTypeAsset
    '
    Me.RbTypeAsset.AutoSize = True
    Me.RbTypeAsset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbTypeAsset.Location = New System.Drawing.Point(62, 19)
    Me.RbTypeAsset.Name = "RbTypeAsset"
    Me.RbTypeAsset.Size = New System.Drawing.Size(51, 17)
    Me.RbTypeAsset.TabIndex = 1
    Me.RbTypeAsset.Text = "Asset"
    Me.RbTypeAsset.UseVisualStyleBackColor = True
    '
    'RbTypeLiability
    '
    Me.RbTypeLiability.AutoSize = True
    Me.RbTypeLiability.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbTypeLiability.Location = New System.Drawing.Point(119, 19)
    Me.RbTypeLiability.Name = "RbTypeLiability"
    Me.RbTypeLiability.Size = New System.Drawing.Size(59, 17)
    Me.RbTypeLiability.TabIndex = 2
    Me.RbTypeLiability.Text = "Liability"
    Me.RbTypeLiability.UseVisualStyleBackColor = True
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
    'LnkFundTo
    '
    Me.LnkFundTo.AutoSize = True
    Me.LnkFundTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFundTo.Location = New System.Drawing.Point(126, 148)
    Me.LnkFundTo.Name = "LnkFundTo"
    Me.LnkFundTo.Size = New System.Drawing.Size(16, 13)
    Me.LnkFundTo.TabIndex = 340
    Me.LnkFundTo.TabStop = True
    Me.LnkFundTo.Text = "to"
    '
    'RbFileCurr
    '
    Me.RbFileCurr.AutoSize = True
    Me.RbFileCurr.Checked = True
    Me.RbFileCurr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFileCurr.Location = New System.Drawing.Point(39, 12)
    Me.RbFileCurr.Name = "RbFileCurr"
    Me.RbFileCurr.Size = New System.Drawing.Size(59, 17)
    Me.RbFileCurr.TabIndex = 0
    Me.RbFileCurr.TabStop = True
    Me.RbFileCurr.Text = "Current"
    Me.RbFileCurr.UseVisualStyleBackColor = True
    '
    'RbFileHist
    '
    Me.RbFileHist.AutoSize = True
    Me.RbFileHist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFileHist.Location = New System.Drawing.Point(119, 12)
    Me.RbFileHist.Name = "RbFileHist"
    Me.RbFileHist.Size = New System.Drawing.Size(57, 17)
    Me.RbFileHist.TabIndex = 1
    Me.RbFileHist.Text = "History"
    Me.RbFileHist.UseVisualStyleBackColor = True
    '
    'ChkPageDept
    '
    Me.ChkPageDept.AutoSize = True
    Me.ChkPageDept.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPageDept.Location = New System.Drawing.Point(22, 343)
    Me.ChkPageDept.Name = "ChkPageDept"
    Me.ChkPageDept.Size = New System.Drawing.Size(208, 17)
    Me.ChkPageDept.TabIndex = 17
    Me.ChkPageDept.Text = "Summary: Page break by Department?"
    Me.ChkPageDept.UseVisualStyleBackColor = True
    Me.ChkPageDept.Visible = False
    '
    'GrpDownload
    '
    Me.GrpDownload.Controls.Add(Me.RbExpState)
    Me.GrpDownload.Controls.Add(Me.RbExpAll)
    Me.GrpDownload.Controls.Add(Me.LblFilePath)
    Me.GrpDownload.Controls.Add(Me.LnkFilePath)
    Me.GrpDownload.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpDownload.ForeColor = System.Drawing.Color.Black
    Me.GrpDownload.Location = New System.Drawing.Point(12, 366)
    Me.GrpDownload.Name = "GrpDownload"
    Me.GrpDownload.Size = New System.Drawing.Size(420, 52)
    Me.GrpDownload.TabIndex = 342
    Me.GrpDownload.TabStop = False
    Me.GrpDownload.Text = "Optional Export to CSV File:"
    '
    'RbExpState
    '
    Me.RbExpState.AutoSize = True
    Me.RbExpState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbExpState.Location = New System.Drawing.Point(194, 13)
    Me.RbExpState.Name = "RbExpState"
    Me.RbExpState.Size = New System.Drawing.Size(158, 17)
    Me.RbExpState.TabIndex = 69
    Me.RbExpState.Text = "State (Acct/Descr/Balance)"
    Me.RbExpState.UseVisualStyleBackColor = True
    '
    'RbExpAll
    '
    Me.RbExpAll.AutoSize = True
    Me.RbExpAll.Checked = True
    Me.RbExpAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbExpAll.Location = New System.Drawing.Point(102, 13)
    Me.RbExpAll.Name = "RbExpAll"
    Me.RbExpAll.Size = New System.Drawing.Size(62, 17)
    Me.RbExpAll.TabIndex = 68
    Me.RbExpAll.TabStop = True
    Me.RbExpAll.Text = "All Data"
    Me.RbExpAll.UseVisualStyleBackColor = True
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(66, 33)
    Me.LblFilePath.Name = "LblFilePath"
    Me.LblFilePath.Size = New System.Drawing.Size(346, 16)
    Me.LblFilePath.TabIndex = 67
    '
    'LnkFilePath
    '
    Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePath.Location = New System.Drawing.Point(8, 33)
    Me.LnkFilePath.Name = "LnkFilePath"
    Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath.TabIndex = 0
    Me.LnkFilePath.TabStop = True
    Me.LnkFilePath.Text = "File Path"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbSourceTax)
    Me.GroupBox2.Controls.Add(Me.RbSourcePR)
    Me.GroupBox2.Controls.Add(Me.RbSourceEncum)
    Me.GroupBox2.Controls.Add(Me.RbSourceCash)
    Me.GroupBox2.Controls.Add(Me.RbSourceAP)
    Me.GroupBox2.Controls.Add(Me.RbSourceJE)
    Me.GroupBox2.Controls.Add(Me.RbSourceAll)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(24, 35)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(383, 39)
    Me.GroupBox2.TabIndex = 2
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Entry Source"
    '
    'RbSourceTax
    '
    Me.RbSourceTax.AutoSize = True
    Me.RbSourceTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSourceTax.Location = New System.Drawing.Point(333, 19)
    Me.RbSourceTax.Name = "RbSourceTax"
    Me.RbSourceTax.Size = New System.Drawing.Size(43, 17)
    Me.RbSourceTax.TabIndex = 6
    Me.RbSourceTax.TabStop = True
    Me.RbSourceTax.Text = "Tax"
    Me.RbSourceTax.UseVisualStyleBackColor = True
    '
    'RbSourcePR
    '
    Me.RbSourcePR.AutoSize = True
    Me.RbSourcePR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSourcePR.Location = New System.Drawing.Point(282, 19)
    Me.RbSourcePR.Name = "RbSourcePR"
    Me.RbSourcePR.Size = New System.Drawing.Size(45, 17)
    Me.RbSourcePR.TabIndex = 5
    Me.RbSourcePR.TabStop = True
    Me.RbSourcePR.Text = "P/R"
    Me.RbSourcePR.UseVisualStyleBackColor = True
    '
    'RbSourceEncum
    '
    Me.RbSourceEncum.AutoSize = True
    Me.RbSourceEncum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSourceEncum.Location = New System.Drawing.Point(218, 19)
    Me.RbSourceEncum.Name = "RbSourceEncum"
    Me.RbSourceEncum.Size = New System.Drawing.Size(58, 17)
    Me.RbSourceEncum.TabIndex = 4
    Me.RbSourceEncum.Text = "Encum"
    Me.RbSourceEncum.UseVisualStyleBackColor = True
    '
    'RbSourceCash
    '
    Me.RbSourceCash.AutoSize = True
    Me.RbSourceCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSourceCash.Location = New System.Drawing.Point(163, 19)
    Me.RbSourceCash.Name = "RbSourceCash"
    Me.RbSourceCash.Size = New System.Drawing.Size(49, 17)
    Me.RbSourceCash.TabIndex = 3
    Me.RbSourceCash.Text = "Cash"
    Me.RbSourceCash.UseVisualStyleBackColor = True
    '
    'RbSourceAP
    '
    Me.RbSourceAP.AutoSize = True
    Me.RbSourceAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSourceAP.Location = New System.Drawing.Point(62, 19)
    Me.RbSourceAP.Name = "RbSourceAP"
    Me.RbSourceAP.Size = New System.Drawing.Size(44, 17)
    Me.RbSourceAP.TabIndex = 1
    Me.RbSourceAP.Text = "A/P"
    Me.RbSourceAP.UseVisualStyleBackColor = True
    '
    'RbSourceJE
    '
    Me.RbSourceJE.AutoSize = True
    Me.RbSourceJE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSourceJE.Location = New System.Drawing.Point(112, 19)
    Me.RbSourceJE.Name = "RbSourceJE"
    Me.RbSourceJE.Size = New System.Drawing.Size(42, 17)
    Me.RbSourceJE.TabIndex = 2
    Me.RbSourceJE.Text = "J/E"
    Me.RbSourceJE.UseVisualStyleBackColor = True
    '
    'RbSourceAll
    '
    Me.RbSourceAll.AutoSize = True
    Me.RbSourceAll.Checked = True
    Me.RbSourceAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSourceAll.Location = New System.Drawing.Point(15, 19)
    Me.RbSourceAll.Name = "RbSourceAll"
    Me.RbSourceAll.Size = New System.Drawing.Size(36, 17)
    Me.RbSourceAll.TabIndex = 0
    Me.RbSourceAll.TabStop = True
    Me.RbSourceAll.Text = "All"
    Me.RbSourceAll.UseVisualStyleBackColor = True
    '
    'LnkFuncTo
    '
    Me.LnkFuncTo.AutoSize = True
    Me.LnkFuncTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFuncTo.Location = New System.Drawing.Point(126, 250)
    Me.LnkFuncTo.Name = "LnkFuncTo"
    Me.LnkFuncTo.Size = New System.Drawing.Size(16, 13)
    Me.LnkFuncTo.TabIndex = 346
    Me.LnkFuncTo.TabStop = True
    Me.LnkFuncTo.Text = "to"
    '
    'LnkObjTo
    '
    Me.LnkObjTo.AutoSize = True
    Me.LnkObjTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkObjTo.Location = New System.Drawing.Point(126, 225)
    Me.LnkObjTo.Name = "LnkObjTo"
    Me.LnkObjTo.Size = New System.Drawing.Size(16, 13)
    Me.LnkObjTo.TabIndex = 345
    Me.LnkObjTo.TabStop = True
    Me.LnkObjTo.Text = "to"
    '
    'FrmGL205B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(443, 424)
    Me.ControlBox = False
    Me.Controls.Add(Me.LnkFuncTo)
    Me.Controls.Add(Me.LnkObjTo)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GrpDownload)
    Me.Controls.Add(Me.ChkPageDept)
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
    Me.Controls.Add(Me.LnkObjFrom)
    Me.Controls.Add(Me.TxtObjTo)
    Me.Controls.Add(Me.TxtObjFrom)
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
    Me.Controls.Add(Me.GroupBox3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL205B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.GroupBox3.ResumeLayout(False)
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GrpDownload.ResumeLayout(False)
    Me.GrpDownload.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmGL205B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGL205.SbpScreen.Text = "GL205"
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
  Private Sub LnkObjFrom_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkObjFrom.LinkClicked
    MyFrmListObj = New FrmListObj
    MyFrmListObj.MdiParent = Me.ParentForm
    MyFrmListObj.WrkObj = MyUtils.CnvSng(TxtObjFrom.Text)
    MyFrmListObj.WrkID = "From"
    MyFrmListObj.Show()
    Me.Hide()
  End Sub
  Private Sub LnkObjTo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkObjTo.LinkClicked
    MyFrmListObj = New FrmListObj
    MyFrmListObj.MdiParent = Me.ParentForm
    MyFrmListObj.WrkObj = MyUtils.CnvSng(TxtObjTo.Text)
    MyFrmListObj.WrkID = "To"
    MyFrmListObj.Show()
    Me.Hide()
  End Sub
  Private Sub LnkFuncFrom_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFuncFrom.LinkClicked
    MyFrmListProg = New FrmListProg
    MyFrmListProg.MdiParent = Me.ParentForm
    MyFrmListProg.WrkProg = MyUtils.CnvSng(TxtFuncFrom.Text)
    MyFrmListProg.WrkID = "From"
    MyFrmListProg.Show()
    Me.Hide()
  End Sub
  Private Sub LnkFuncTo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFuncTo.LinkClicked
    MyFrmListProg = New FrmListProg
    MyFrmListProg.MdiParent = Me.ParentForm
    MyFrmListProg.WrkProg = MyUtils.CnvSng(TxtFuncTo.Text)
    MyFrmListProg.WrkID = "To"
    MyFrmListProg.Show()
    Me.Hide()
  End Sub
  Private Sub FrmGL205B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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

Private Sub FrmGL205B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  InitFiles()
  If Now.Date.Month >= 7 Then
    DtPckFrom.Value = "#7/1/" & Now.Date.Year & "#"
  Else
    DtPckFrom.Value = "#7/1/" & Now.Date.Year - 1 & "#"
  End If
  DtPckTo.Value = Now.Date
End Sub

Private Sub LnkFilePath_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
  With SaveFileDialog1
    .ShowDialog()
    LblFilePath.Text = .FileName
  End With
End Sub
End Class
