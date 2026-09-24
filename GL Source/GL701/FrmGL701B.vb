Public Class FrmGL701B
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
Friend WithEvents LnkFundTo As System.Windows.Forms.LinkLabel
Friend WithEvents ChkNoActivity As System.Windows.Forms.CheckBox
Friend WithEvents GrpDownload As System.Windows.Forms.GroupBox
Friend WithEvents LblFilePath As System.Windows.Forms.Label
Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
Friend WithEvents ChkInactiveRpt As System.Windows.Forms.CheckBox
  Friend WithEvents ChkFundBal As CheckBox
  Friend WithEvents ChkAcct As System.Windows.Forms.CheckBox
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
    Me.Label8 = New System.Windows.Forms.Label()
    Me.LnkFuncFrom = New System.Windows.Forms.LinkLabel()
    Me.TxtFuncTo = New System.Windows.Forms.TextBox()
    Me.TxtFuncFrom = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TxtSfuncTo = New System.Windows.Forms.TextBox()
    Me.TxtSfuncFrom = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.LnkFundTo = New System.Windows.Forms.LinkLabel()
    Me.ChkAcct = New System.Windows.Forms.CheckBox()
    Me.ChkNoActivity = New System.Windows.Forms.CheckBox()
    Me.GrpDownload = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.ChkInactiveRpt = New System.Windows.Forms.CheckBox()
    Me.ChkFundBal = New System.Windows.Forms.CheckBox()
    Me.GroupBox3.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpDownload.SuspendLayout()
    Me.SuspendLayout()
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.DtPckTo)
    Me.GroupBox3.Controls.Add(Me.Label2)
    Me.GroupBox3.Controls.Add(Me.DtPckFrom)
    Me.GroupBox3.Controls.Add(Me.Label1)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(22, 22)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(286, 52)
    Me.GroupBox3.TabIndex = 0
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
    Me.LnkFundFrom.Location = New System.Drawing.Point(19, 91)
    Me.LnkFundFrom.Name = "LnkFundFrom"
    Me.LnkFundFrom.Size = New System.Drawing.Size(31, 13)
    Me.LnkFundFrom.TabIndex = 318
    Me.LnkFundFrom.TabStop = True
    Me.LnkFundFrom.Text = "Fund"
    '
    'TxtFundTo
    '
    Me.TxtFundTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFundTo.Location = New System.Drawing.Point(146, 87)
    Me.TxtFundTo.MaxLength = 3
    Me.TxtFundTo.Name = "TxtFundTo"
    Me.TxtFundTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtFundTo.TabIndex = 316
    '
    'TxtFundFrom
    '
    Me.TxtFundFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFundFrom.Location = New System.Drawing.Point(84, 87)
    Me.TxtFundFrom.MaxLength = 3
    Me.TxtFundFrom.Name = "TxtFundFrom"
    Me.TxtFundFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtFundFrom.TabIndex = 315
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(17, 116)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(53, 13)
    Me.Label4.TabIndex = 319
    Me.Label4.Text = "Sub Fund"
    '
    'TxtSfundTo
    '
    Me.TxtSfundTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfundTo.Location = New System.Drawing.Point(146, 113)
    Me.TxtSfundTo.MaxLength = 3
    Me.TxtSfundTo.Name = "TxtSfundTo"
    Me.TxtSfundTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtSfundTo.TabIndex = 321
    '
    'TxtSfundFrom
    '
    Me.TxtSfundFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfundFrom.Location = New System.Drawing.Point(84, 113)
    Me.TxtSfundFrom.MaxLength = 3
    Me.TxtSfundFrom.Name = "TxtSfundFrom"
    Me.TxtSfundFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtSfundFrom.TabIndex = 320
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(124, 116)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(16, 16)
    Me.Label5.TabIndex = 322
    Me.Label5.Text = "to"
    '
    'TxtDeptTo
    '
    Me.TxtDeptTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDeptTo.Location = New System.Drawing.Point(146, 139)
    Me.TxtDeptTo.MaxLength = 4
    Me.TxtDeptTo.Name = "TxtDeptTo"
    Me.TxtDeptTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtDeptTo.TabIndex = 325
    '
    'TxtDeptFrom
    '
    Me.TxtDeptFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDeptFrom.Location = New System.Drawing.Point(84, 139)
    Me.TxtDeptFrom.MaxLength = 4
    Me.TxtDeptFrom.Name = "TxtDeptFrom"
    Me.TxtDeptFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtDeptFrom.TabIndex = 324
    '
    'Label6
    '
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(124, 142)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(16, 16)
    Me.Label6.TabIndex = 326
    Me.Label6.Text = "to"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(17, 142)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(62, 13)
    Me.Label7.TabIndex = 323
    Me.Label7.Text = "Department"
    '
    'LnkObjFrom
    '
    Me.LnkObjFrom.AutoSize = True
    Me.LnkObjFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkObjFrom.Location = New System.Drawing.Point(19, 167)
    Me.LnkObjFrom.Name = "LnkObjFrom"
    Me.LnkObjFrom.Size = New System.Drawing.Size(38, 13)
    Me.LnkObjFrom.TabIndex = 330
    Me.LnkObjFrom.TabStop = True
    Me.LnkObjFrom.Text = "Object"
    '
    'TxtObjTo
    '
    Me.TxtObjTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObjTo.Location = New System.Drawing.Point(146, 163)
    Me.TxtObjTo.MaxLength = 3
    Me.TxtObjTo.Name = "TxtObjTo"
    Me.TxtObjTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtObjTo.TabIndex = 328
    '
    'TxtObjFrom
    '
    Me.TxtObjFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObjFrom.Location = New System.Drawing.Point(84, 163)
    Me.TxtObjFrom.MaxLength = 3
    Me.TxtObjFrom.Name = "TxtObjFrom"
    Me.TxtObjFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtObjFrom.TabIndex = 327
    '
    'Label8
    '
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(124, 166)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(16, 16)
    Me.Label8.TabIndex = 329
    Me.Label8.Text = "to"
    '
    'LnkFuncFrom
    '
    Me.LnkFuncFrom.AutoSize = True
    Me.LnkFuncFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFuncFrom.Location = New System.Drawing.Point(19, 192)
    Me.LnkFuncFrom.Name = "LnkFuncFrom"
    Me.LnkFuncFrom.Size = New System.Drawing.Size(48, 13)
    Me.LnkFuncFrom.TabIndex = 334
    Me.LnkFuncFrom.TabStop = True
    Me.LnkFuncFrom.Text = "Function"
    '
    'TxtFuncTo
    '
    Me.TxtFuncTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFuncTo.Location = New System.Drawing.Point(146, 188)
    Me.TxtFuncTo.MaxLength = 4
    Me.TxtFuncTo.Name = "TxtFuncTo"
    Me.TxtFuncTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtFuncTo.TabIndex = 332
    '
    'TxtFuncFrom
    '
    Me.TxtFuncFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFuncFrom.Location = New System.Drawing.Point(84, 188)
    Me.TxtFuncFrom.MaxLength = 4
    Me.TxtFuncFrom.Name = "TxtFuncFrom"
    Me.TxtFuncFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtFuncFrom.TabIndex = 331
    '
    'Label9
    '
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(124, 191)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(16, 16)
    Me.Label9.TabIndex = 333
    Me.Label9.Text = "to"
    '
    'TxtSfuncTo
    '
    Me.TxtSfuncTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfuncTo.Location = New System.Drawing.Point(146, 214)
    Me.TxtSfuncTo.MaxLength = 4
    Me.TxtSfuncTo.Name = "TxtSfuncTo"
    Me.TxtSfuncTo.Size = New System.Drawing.Size(32, 20)
    Me.TxtSfuncTo.TabIndex = 337
    '
    'TxtSfuncFrom
    '
    Me.TxtSfuncFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfuncFrom.Location = New System.Drawing.Point(84, 214)
    Me.TxtSfuncFrom.MaxLength = 4
    Me.TxtSfuncFrom.Name = "TxtSfuncFrom"
    Me.TxtSfuncFrom.Size = New System.Drawing.Size(34, 20)
    Me.TxtSfuncFrom.TabIndex = 336
    '
    'Label10
    '
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(124, 217)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(16, 16)
    Me.Label10.TabIndex = 338
    Me.Label10.Text = "to"
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.Location = New System.Drawing.Point(17, 217)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(64, 13)
    Me.Label11.TabIndex = 335
    Me.Label11.Text = "Subfunction"
    '
    'LnkFundTo
    '
    Me.LnkFundTo.AutoSize = True
    Me.LnkFundTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFundTo.Location = New System.Drawing.Point(124, 90)
    Me.LnkFundTo.Name = "LnkFundTo"
    Me.LnkFundTo.Size = New System.Drawing.Size(16, 13)
    Me.LnkFundTo.TabIndex = 340
    Me.LnkFundTo.TabStop = True
    Me.LnkFundTo.Text = "to"
    '
    'ChkAcct
    '
    Me.ChkAcct.AutoSize = True
    Me.ChkAcct.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAcct.Checked = True
    Me.ChkAcct.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkAcct.Location = New System.Drawing.Point(25, 252)
    Me.ChkAcct.Name = "ChkAcct"
    Me.ChkAcct.Size = New System.Drawing.Size(136, 17)
    Me.ChkAcct.TabIndex = 341
    Me.ChkAcct.Text = "Print Account Number?"
    Me.ChkAcct.UseVisualStyleBackColor = True
    '
    'ChkNoActivity
    '
    Me.ChkNoActivity.AutoSize = True
    Me.ChkNoActivity.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkNoActivity.Checked = True
    Me.ChkNoActivity.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkNoActivity.Location = New System.Drawing.Point(22, 275)
    Me.ChkNoActivity.Name = "ChkNoActivity"
    Me.ChkNoActivity.Size = New System.Drawing.Size(187, 17)
    Me.ChkNoActivity.TabIndex = 342
    Me.ChkNoActivity.Text = "Include accounts with no activity?"
    Me.ChkNoActivity.UseVisualStyleBackColor = True
    '
    'GrpDownload
    '
    Me.GrpDownload.Controls.Add(Me.LblFilePath)
    Me.GrpDownload.Controls.Add(Me.LnkFilePath)
    Me.GrpDownload.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpDownload.ForeColor = System.Drawing.Color.Black
    Me.GrpDownload.Location = New System.Drawing.Point(12, 353)
    Me.GrpDownload.Name = "GrpDownload"
    Me.GrpDownload.Size = New System.Drawing.Size(420, 35)
    Me.GrpDownload.TabIndex = 350
    Me.GrpDownload.TabStop = False
    Me.GrpDownload.Text = "Optional: CSV file Account/Description/Amount"
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
    'ChkInactiveRpt
    '
    Me.ChkInactiveRpt.AutoSize = True
    Me.ChkInactiveRpt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkInactiveRpt.Location = New System.Drawing.Point(22, 298)
    Me.ChkInactiveRpt.Name = "ChkInactiveRpt"
    Me.ChkInactiveRpt.Size = New System.Drawing.Size(181, 17)
    Me.ChkInactiveRpt.TabIndex = 345
    Me.ChkInactiveRpt.Text = "Include fund inactive on reports?"
    Me.ChkInactiveRpt.UseVisualStyleBackColor = True
    '
    'ChkFundBal
    '
    Me.ChkFundBal.AutoSize = True
    Me.ChkFundBal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkFundBal.Checked = True
    Me.ChkFundBal.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkFundBal.Location = New System.Drawing.Point(22, 321)
    Me.ChkFundBal.Name = "ChkFundBal"
    Me.ChkFundBal.Size = New System.Drawing.Size(182, 17)
    Me.ChkFundBal.TabIndex = 346
    Me.ChkFundBal.Text = "Include unclosed Fund Balance?"
    Me.ChkFundBal.UseVisualStyleBackColor = True
    '
    'FrmGL701B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(438, 400)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkFundBal)
    Me.Controls.Add(Me.ChkInactiveRpt)
    Me.Controls.Add(Me.GrpDownload)
    Me.Controls.Add(Me.ChkNoActivity)
    Me.Controls.Add(Me.ChkAcct)
    Me.Controls.Add(Me.LnkFundTo)
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
    Me.Controls.Add(Me.GroupBox3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL701B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.GroupBox3.ResumeLayout(False)
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpDownload.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmGL701B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGL701.SbpScreen.Text = "GL701"
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
Private Sub FrmGL701B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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

Private Sub FrmGL701B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
