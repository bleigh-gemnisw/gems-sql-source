Public Class FrmTX702B
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
Friend WithEvents RbSortZip As System.Windows.Forms.RadioButton
Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
Friend WithEvents GrpSorting As System.Windows.Forms.GroupBox
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents DtPckProDue2 As System.Windows.Forms.DateTimePicker
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents DtPckProDue1 As System.Windows.Forms.DateTimePicker
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents Label9 As System.Windows.Forms.Label
Friend WithEvents TxtCCFrom As System.Windows.Forms.TextBox
Friend WithEvents Label10 As System.Windows.Forms.Label
Friend WithEvents TxtCCTo As System.Windows.Forms.TextBox
Friend WithEvents TxtType As System.Windows.Forms.TextBox
Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
Friend WithEvents Label11 As System.Windows.Forms.Label
Friend WithEvents TxtToReason As System.Windows.Forms.TextBox
Friend WithEvents TxtFromReason As System.Windows.Forms.TextBox
Friend WithEvents LnkToReason As System.Windows.Forms.LinkLabel
Friend WithEvents LnkFrmReason As System.Windows.Forms.LinkLabel
Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbBalances As System.Windows.Forms.RadioButton
Friend WithEvents RbBillAmount As System.Windows.Forms.RadioButton
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents DtPckProGrace1 As System.Windows.Forms.DateTimePicker
Friend WithEvents Label13 As System.Windows.Forms.Label
Friend WithEvents Label12 As System.Windows.Forms.Label
Friend WithEvents DtPckProGrace2 As System.Windows.Forms.DateTimePicker
Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.GrpSorting = New System.Windows.Forms.GroupBox
Me.CheckBox2 = New System.Windows.Forms.CheckBox
Me.RbSortZip = New System.Windows.Forms.RadioButton
Me.RbSortName = New System.Windows.Forms.RadioButton
Me.Label4 = New System.Windows.Forms.Label
Me.TextBox3 = New System.Windows.Forms.TextBox
Me.TxtGLYear = New System.Windows.Forms.TextBox
Me.Label7 = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.Label6 = New System.Windows.Forms.Label
Me.DtPckProDue2 = New System.Windows.Forms.DateTimePicker
Me.Label5 = New System.Windows.Forms.Label
Me.DtPckProDue1 = New System.Windows.Forms.DateTimePicker
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.Label11 = New System.Windows.Forms.Label
Me.TxtToReason = New System.Windows.Forms.TextBox
Me.TxtFromReason = New System.Windows.Forms.TextBox
Me.LnkToReason = New System.Windows.Forms.LinkLabel
Me.LnkFrmReason = New System.Windows.Forms.LinkLabel
Me.TxtCCTo = New System.Windows.Forms.TextBox
Me.Label10 = New System.Windows.Forms.Label
Me.TxtCCFrom = New System.Windows.Forms.TextBox
Me.Label9 = New System.Windows.Forms.Label
Me.Label8 = New System.Windows.Forms.Label
Me.DtPckTo = New System.Windows.Forms.DateTimePicker
Me.DtPckFrom = New System.Windows.Forms.DateTimePicker
Me.Label1 = New System.Windows.Forms.Label
Me.TxtType = New System.Windows.Forms.TextBox
Me.LnkType = New System.Windows.Forms.LinkLabel
Me.TextBox2 = New System.Windows.Forms.TextBox
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.RbBalances = New System.Windows.Forms.RadioButton
Me.RbBillAmount = New System.Windows.Forms.RadioButton
Me.Label2 = New System.Windows.Forms.Label
Me.DtPckProGrace1 = New System.Windows.Forms.DateTimePicker
Me.Label12 = New System.Windows.Forms.Label
Me.DtPckProGrace2 = New System.Windows.Forms.DateTimePicker
Me.Label13 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GrpSorting.SuspendLayout()
Me.GroupBox1.SuspendLayout()
Me.GroupBox2.SuspendLayout()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'GrpSorting
'
Me.GrpSorting.Controls.Add(Me.CheckBox2)
Me.GrpSorting.Controls.Add(Me.RbSortZip)
Me.GrpSorting.Controls.Add(Me.RbSortName)
Me.GrpSorting.Controls.Add(Me.Label4)
Me.GrpSorting.Controls.Add(Me.TextBox3)
Me.GrpSorting.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GrpSorting.Location = New System.Drawing.Point(404, 77)
Me.GrpSorting.Name = "GrpSorting"
Me.GrpSorting.Size = New System.Drawing.Size(128, 60)
Me.GrpSorting.TabIndex = 9
Me.GrpSorting.TabStop = False
Me.GrpSorting.Text = "Sorting"
'
'CheckBox2
'
Me.CheckBox2.AutoSize = True
Me.CheckBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.CheckBox2.Location = New System.Drawing.Point(-168, 43)
Me.CheckBox2.Name = "CheckBox2"
Me.CheckBox2.Size = New System.Drawing.Size(142, 17)
Me.CheckBox2.TabIndex = 67
Me.CheckBox2.Text = "Print with Balances?"
Me.CheckBox2.UseVisualStyleBackColor = True
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
'Label4
'
Me.Label4.Location = New System.Drawing.Point(-171, 70)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(180, 16)
Me.Label4.TabIndex = 52
Me.Label4.Text = "Miscellaneous Comment On Bill"
'
'TextBox3
'
Me.TextBox3.Location = New System.Drawing.Point(13, 66)
Me.TextBox3.MaxLength = 25
Me.TextBox3.Name = "TextBox3"
Me.TextBox3.Size = New System.Drawing.Size(168, 20)
Me.TextBox3.TabIndex = 5
'
'TxtGLYear
'
Me.TxtGLYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtGLYear.Location = New System.Drawing.Point(103, 49)
Me.TxtGLYear.MaxLength = 4
Me.TxtGLYear.Name = "TxtGLYear"
Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
Me.TxtGLYear.TabIndex = 1
'
'Label7
'
Me.Label7.Location = New System.Drawing.Point(8, 175)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(167, 17)
Me.Label7.TabIndex = 52
Me.Label7.Text = "Miscellaneous Comment On Bill"
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(8, 53)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(84, 16)
Me.Label3.TabIndex = 48
Me.Label3.Text = "Grand List Year"
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(5, 134)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(64, 16)
Me.Label6.TabIndex = 57
Me.Label6.Text = "Due Date 2"
'
'DtPckProDue2
'
Me.DtPckProDue2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckProDue2.Location = New System.Drawing.Point(100, 134)
Me.DtPckProDue2.Name = "DtPckProDue2"
Me.DtPckProDue2.Size = New System.Drawing.Size(88, 20)
Me.DtPckProDue2.TabIndex = 4
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(5, 110)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(64, 16)
Me.Label5.TabIndex = 55
Me.Label5.Text = "Due Date 1"
'
'DtPckProDue1
'
Me.DtPckProDue1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckProDue1.Location = New System.Drawing.Point(100, 110)
Me.DtPckProDue1.Name = "DtPckProDue1"
Me.DtPckProDue1.Size = New System.Drawing.Size(88, 20)
Me.DtPckProDue1.TabIndex = 2
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.Label11)
Me.GroupBox1.Controls.Add(Me.TxtToReason)
Me.GroupBox1.Controls.Add(Me.TxtFromReason)
Me.GroupBox1.Controls.Add(Me.LnkToReason)
Me.GroupBox1.Controls.Add(Me.LnkFrmReason)
Me.GroupBox1.Controls.Add(Me.TxtCCTo)
Me.GroupBox1.Controls.Add(Me.Label10)
Me.GroupBox1.Controls.Add(Me.TxtCCFrom)
Me.GroupBox1.Controls.Add(Me.Label9)
Me.GroupBox1.Controls.Add(Me.Label8)
Me.GroupBox1.Controls.Add(Me.DtPckTo)
Me.GroupBox1.Controls.Add(Me.DtPckFrom)
Me.GroupBox1.Controls.Add(Me.Label1)
Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox1.Location = New System.Drawing.Point(11, 202)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(332, 96)
Me.GroupBox1.TabIndex = 7
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Optional Selections"
'
'Label11
'
Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label11.Location = New System.Drawing.Point(168, 72)
Me.Label11.Name = "Label11"
Me.Label11.Size = New System.Drawing.Size(56, 16)
Me.Label11.TabIndex = 5
Me.Label11.Text = "(Optional)"
'
'TxtToReason
'
Me.TxtToReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtToReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtToReason.Location = New System.Drawing.Point(144, 68)
Me.TxtToReason.MaxLength = 20
Me.TxtToReason.Name = "TxtToReason"
Me.TxtToReason.Size = New System.Drawing.Size(16, 20)
Me.TxtToReason.TabIndex = 63
'
'TxtFromReason
'
Me.TxtFromReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtFromReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFromReason.Location = New System.Drawing.Point(92, 68)
Me.TxtFromReason.MaxLength = 20
Me.TxtFromReason.Name = "TxtFromReason"
Me.TxtFromReason.Size = New System.Drawing.Size(16, 20)
Me.TxtFromReason.TabIndex = 4
'
'LnkToReason
'
Me.LnkToReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkToReason.Location = New System.Drawing.Point(120, 72)
Me.LnkToReason.Name = "LnkToReason"
Me.LnkToReason.Size = New System.Drawing.Size(20, 16)
Me.LnkToReason.TabIndex = 65
Me.LnkToReason.TabStop = True
Me.LnkToReason.Text = "to"
'
'LnkFrmReason
'
Me.LnkFrmReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkFrmReason.Location = New System.Drawing.Point(8, 72)
Me.LnkFrmReason.Name = "LnkFrmReason"
Me.LnkFrmReason.Size = New System.Drawing.Size(80, 16)
Me.LnkFrmReason.TabIndex = 64
Me.LnkFrmReason.TabStop = True
Me.LnkFrmReason.Text = "Reason Code"
'
'TxtCCTo
'
Me.TxtCCTo.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtCCTo.Location = New System.Drawing.Point(144, 40)
Me.TxtCCTo.MaxLength = 5
Me.TxtCCTo.Name = "TxtCCTo"
Me.TxtCCTo.Size = New System.Drawing.Size(44, 21)
Me.TxtCCTo.TabIndex = 3
'
'Label10
'
Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label10.Location = New System.Drawing.Point(116, 44)
Me.Label10.Name = "Label10"
Me.Label10.Size = New System.Drawing.Size(18, 16)
Me.Label10.TabIndex = 60
Me.Label10.Text = "to"
'
'TxtCCFrom
'
Me.TxtCCFrom.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtCCFrom.Location = New System.Drawing.Point(68, 40)
Me.TxtCCFrom.MaxLength = 5
Me.TxtCCFrom.Name = "TxtCCFrom"
Me.TxtCCFrom.Size = New System.Drawing.Size(44, 21)
Me.TxtCCFrom.TabIndex = 2
'
'Label9
'
Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label9.Location = New System.Drawing.Point(8, 44)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(52, 16)
Me.Label9.TabIndex = 58
Me.Label9.Text = "C/C #'s"
'
'Label8
'
Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label8.Location = New System.Drawing.Point(172, 20)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(18, 16)
Me.Label8.TabIndex = 57
Me.Label8.Text = "to"
'
'DtPckTo
'
Me.DtPckTo.Checked = False
Me.DtPckTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckTo.Location = New System.Drawing.Point(200, 16)
Me.DtPckTo.Name = "DtPckTo"
Me.DtPckTo.ShowCheckBox = True
Me.DtPckTo.Size = New System.Drawing.Size(100, 20)
Me.DtPckTo.TabIndex = 1
'
'DtPckFrom
'
Me.DtPckFrom.Checked = False
Me.DtPckFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckFrom.Location = New System.Drawing.Point(68, 16)
Me.DtPckFrom.Name = "DtPckFrom"
Me.DtPckFrom.ShowCheckBox = True
Me.DtPckFrom.Size = New System.Drawing.Size(100, 20)
Me.DtPckFrom.TabIndex = 0
'
'Label1
'
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.Location = New System.Drawing.Point(8, 20)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(64, 16)
Me.Label1.TabIndex = 49
Me.Label1.Text = "C/C Dates"
'
'TxtType
'
Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtType.Location = New System.Drawing.Point(103, 25)
Me.TxtType.MaxLength = 20
Me.TxtType.Name = "TxtType"
Me.TxtType.Size = New System.Drawing.Size(16, 20)
Me.TxtType.TabIndex = 0
'
'LnkType
'
Me.LnkType.Location = New System.Drawing.Point(12, 29)
Me.LnkType.Name = "LnkType"
Me.LnkType.Size = New System.Drawing.Size(80, 16)
Me.LnkType.TabIndex = 60
Me.LnkType.TabStop = True
Me.LnkType.Text = "Type to print"
'
'TextBox2
'
Me.TextBox2.Location = New System.Drawing.Point(182, 172)
Me.TextBox2.MaxLength = 25
Me.TextBox2.Name = "TextBox2"
Me.TextBox2.Size = New System.Drawing.Size(168, 20)
Me.TextBox2.TabIndex = 6
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.RbBalances)
Me.GroupBox2.Controls.Add(Me.RbBillAmount)
Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox2.Location = New System.Drawing.Point(404, 9)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(127, 63)
Me.GroupBox2.TabIndex = 8
Me.GroupBox2.TabStop = False
Me.GroupBox2.Text = "Tax Amount is ..."
'
'RbBalances
'
Me.RbBalances.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbBalances.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbBalances.Location = New System.Drawing.Point(13, 40)
Me.RbBalances.Name = "RbBalances"
Me.RbBalances.Size = New System.Drawing.Size(107, 17)
Me.RbBalances.TabIndex = 63
Me.RbBalances.Text = "Balance Only"
Me.RbBalances.UseVisualStyleBackColor = True
'
'RbBillAmount
'
Me.RbBillAmount.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbBillAmount.Checked = True
Me.RbBillAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbBillAmount.Location = New System.Drawing.Point(12, 19)
Me.RbBillAmount.Name = "RbBillAmount"
Me.RbBillAmount.Size = New System.Drawing.Size(108, 15)
Me.RbBillAmount.TabIndex = 62
Me.RbBillAmount.TabStop = True
Me.RbBillAmount.Text = "Bill Amount"
Me.RbBillAmount.UseVisualStyleBackColor = True
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(208, 114)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(73, 16)
Me.Label2.TabIndex = 65
Me.Label2.Text = "Grace Date 1"
'
'DtPckProGrace1
'
Me.DtPckProGrace1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckProGrace1.Location = New System.Drawing.Point(287, 110)
Me.DtPckProGrace1.Name = "DtPckProGrace1"
Me.DtPckProGrace1.Size = New System.Drawing.Size(88, 20)
Me.DtPckProGrace1.TabIndex = 3
'
'Label12
'
Me.Label12.Location = New System.Drawing.Point(208, 138)
Me.Label12.Name = "Label12"
Me.Label12.Size = New System.Drawing.Size(73, 16)
Me.Label12.TabIndex = 67
Me.Label12.Text = "Grace Date 2"
'
'DtPckProGrace2
'
Me.DtPckProGrace2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckProGrace2.Location = New System.Drawing.Point(287, 134)
Me.DtPckProGrace2.Name = "DtPckProGrace2"
Me.DtPckProGrace2.Size = New System.Drawing.Size(88, 20)
Me.DtPckProGrace2.TabIndex = 5
'
'Label13
'
Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label13.Location = New System.Drawing.Point(8, 93)
Me.Label13.Name = "Label13"
Me.Label13.Size = New System.Drawing.Size(367, 16)
Me.Label13.TabIndex = 68
Me.Label13.Text = "Dates to print on bills. NOTE that they are NOT saved."
Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'FrmTX702B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(544, 317)
Me.ControlBox = False
Me.Controls.Add(Me.Label13)
Me.Controls.Add(Me.Label12)
Me.Controls.Add(Me.DtPckProGrace2)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.DtPckProGrace1)
Me.Controls.Add(Me.GroupBox2)
Me.Controls.Add(Me.TxtType)
Me.Controls.Add(Me.LnkType)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.DtPckProDue2)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.DtPckProDue1)
Me.Controls.Add(Me.TxtGLYear)
Me.Controls.Add(Me.TextBox2)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.GrpSorting)
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX702B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GrpSorting.ResumeLayout(False)
Me.GrpSorting.PerformLayout()
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox1.PerformLayout()
Me.GroupBox2.ResumeLayout(False)
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
Private Sub FrmTX702B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Dim WrkYear As Integer
		MyFrmTX702.SbpPgmID.Text = "TX702B"
		MyFrmTX702.SbpEnvironment.Text = myDBConnect.PgmDB

		WrkYear = Date.Now.Year
		If Date.Now.Month < 10 Then
			WrkYear = WrkYear - 1
		End If
		TxtGLYear.Text = WrkYear

End Sub
Private Sub FrmTX702B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmTX702.SbpScreen.Text = "TX702B"
End Sub
Private Sub FrmTX702B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
	Me.Refresh()
End Sub
	Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer
		ErrProv.SetError(TxtType, "")
		ErrProv.SetError(TxtGLYear, "")
		ErrProv.SetError(DtPckTo, "")

		For I = 0 To ErrorField.GetUpperBound(0)
			Select Case ErrorField(I)
			Case "glyear"
				ErrProv.SetError(TxtGLYear, ErrorMsg(I))
			Case "type"
				ErrProv.SetError(TxtType, ErrorMsg(I))
			Case "to"
				ErrProv.SetError(DtPckTo, ErrorMsg(I))
			Case Nothing
				Exit Sub
			End Select
		Next I
	End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer
		Dim WrkFamily As String

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

    If TxtType.Text = "" Then
      ErrorField(I) = "type"
      ErrorMsg(I) = "Type is required"
      I = I + 1
    End If

    If TxtType.Text <> "" Then
      WrkFamily = GetTXTypeFamily(TxtType.Text)
      If WrkFamily <> "R" And WrkFamily <> "P" And WrkFamily <> "M" And WrkFamily <> "S" Then
        ErrorField(I) = "type"
        ErrorMsg(I) = "Tax Type/Family is not allowed in this program"
        I = I + 1
      End If
    End If

    If MyUtils.SetDBDate(DtPckFrom.Value) > MyUtils.SetDBDate(DtPckTo.Value) Then
      ErrorField(I) = "to"
      ErrorMsg(I) = "Invalid date Range"
      I = I + 1
    End If

  End Sub
Private Sub CalcProrateDates()
  Dim MyTXPROF As TXPROF.myData
  'TXPROF
  Dim ProfPrPerd As Integer
  Dim ProfTxDt(3) As Date
  Dim WrkDate As Date
  Dim WrkToday As Date

  MyTXPROF = New TXPROF.mydata(MyDBConnect)
  MyTXPROF.GetOneRecordP(TxtType.Text, MyUtils.CnvSng(TxtGLYear.Text), "", 0)
  WrkToday = Date.Today
  If MyTXPROF.RecordNotFound Then
    MsgBox("Add year using program TX101 (Bill Type info) " & TxtGLYear.Text, MsgBoxStyle.Critical, "Tax Profile missing")
    Exit Sub
  End If

  With MyTXPROF
    ProfPrPerd = ._PRPERD
    DtPckProDue1.Value = MyUtils.GetDBDateMDY(._PRDUE1)
    DtPckProGrace1.Value = MyUtils.GetDBDateMDY(._PRGRD1)
    If ProfPrPerd > 1 Then
      DtPckProDue2.Value = MyUtils.GetDBDateMDY(._PRDUE2)
      DtPckProGrace2.Value = MyUtils.GetDBDateMDY(._PRGRD2)
    Else
      DtPckProDue2.Enabled = False
      DtPckProGrace2.Enabled = False
    End If
  End With

  WrkDate = WrkToday
  If ProfPrPerd >= 2 Then
    If WrkDate <= ProfTxDt(1) Then
      WrkDate = ProfTxDt(1)
    End If
  End If

End Sub
Private Sub FrmTX702B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
	If Not e.Alt Then Exit Sub

	 If e.KeyCode = Keys.F12 Then
     MyUtils.PrtScreen(Form.ActiveForm)
	 End If
End Sub
Private Sub TxtGLYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
	MyFrmListTypes = New FrmListTypes
	MyFrmListTypes.MdiParent = Me.ParentForm
	MyFrmListTypes.WrkType = TxtType.Text
	MyFrmListTypes.Show()
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
Private Sub TxtGLYear_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtGLYear.Leave
	CalcProrateDates()
End Sub

Private Sub TxtGLYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtGLYear.TextChanged

End Sub

Private Sub DtPckProDue1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtPckProDue1.ValueChanged

End Sub
End Class






