<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPRPRTCHKC
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPRPRTCHKC))
Me.TxtName = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.TxtDept = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.TxtEmpNo = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.TxtChkNo = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.DtPckChk = New System.Windows.Forms.DateTimePicker
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.BtnErnRemove = New System.Windows.Forms.Button
Me.TxtErnAmt = New System.Windows.Forms.TextBox
Me.TxtErnDesc = New System.Windows.Forms.TextBox
Me.TxtErnHrs = New System.Windows.Forms.TextBox
Me.LblErnTot = New System.Windows.Forms.Label
Me.Label8 = New System.Windows.Forms.Label
Me.Label7 = New System.Windows.Forms.Label
Me.Label6 = New System.Windows.Forms.Label
Me.C1DataGrdErn = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
Me.Label13 = New System.Windows.Forms.Label
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.BtnDedRemove = New System.Windows.Forms.Button
Me.Label15 = New System.Windows.Forms.Label
Me.TxtDedAmt = New System.Windows.Forms.TextBox
Me.TxtDedDesc = New System.Windows.Forms.TextBox
Me.LblDedTot = New System.Windows.Forms.Label
Me.C1DataGrdDed = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
Me.Label9 = New System.Windows.Forms.Label
Me.Label10 = New System.Windows.Forms.Label
Me.Label12 = New System.Windows.Forms.Label
Me.LblNetPay = New System.Windows.Forms.Label
Me.RbClear = New System.Windows.Forms.Button
Me.GroupBox1.SuspendLayout()
CType(Me.C1DataGrdErn, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox2.SuspendLayout()
CType(Me.C1DataGrdDed, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'TxtName
'
Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtName.Location = New System.Drawing.Point(53, 25)
Me.TxtName.Name = "TxtName"
Me.TxtName.Size = New System.Drawing.Size(165, 20)
Me.TxtName.TabIndex = 0
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(50, 9)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(84, 13)
Me.Label1.TabIndex = 1
Me.Label1.Text = "Employee Name"
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Location = New System.Drawing.Point(230, 9)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(30, 13)
Me.Label2.TabIndex = 3
Me.Label2.Text = "Dept"
'
'TxtDept
'
Me.TxtDept.Location = New System.Drawing.Point(225, 25)
Me.TxtDept.Name = "TxtDept"
Me.TxtDept.Size = New System.Drawing.Size(35, 20)
Me.TxtDept.TabIndex = 1
'
'Label3
'
Me.Label3.AutoSize = True
Me.Label3.Location = New System.Drawing.Point(266, 9)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(73, 13)
Me.Label3.TabIndex = 5
Me.Label3.Text = "Employee No."
'
'TxtEmpNo
'
Me.TxtEmpNo.Location = New System.Drawing.Point(278, 25)
Me.TxtEmpNo.Name = "TxtEmpNo"
Me.TxtEmpNo.Size = New System.Drawing.Size(47, 20)
Me.TxtEmpNo.TabIndex = 2
'
'Label4
'
Me.Label4.AutoSize = True
Me.Label4.Location = New System.Drawing.Point(443, 9)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(78, 13)
Me.Label4.TabIndex = 7
Me.Label4.Text = "Check Number"
'
'TxtChkNo
'
Me.TxtChkNo.Location = New System.Drawing.Point(446, 25)
Me.TxtChkNo.Name = "TxtChkNo"
Me.TxtChkNo.Size = New System.Drawing.Size(75, 20)
Me.TxtChkNo.TabIndex = 4
'
'Label5
'
Me.Label5.AutoSize = True
Me.Label5.Location = New System.Drawing.Point(345, 9)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(64, 13)
Me.Label5.TabIndex = 9
Me.Label5.Text = "Check Date"
'
'DtPckChk
'
Me.DtPckChk.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckChk.Location = New System.Drawing.Point(343, 25)
Me.DtPckChk.Name = "DtPckChk"
Me.DtPckChk.Size = New System.Drawing.Size(91, 20)
Me.DtPckChk.TabIndex = 3
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.BtnErnRemove)
Me.GroupBox1.Controls.Add(Me.TxtErnAmt)
Me.GroupBox1.Controls.Add(Me.TxtErnDesc)
Me.GroupBox1.Controls.Add(Me.TxtErnHrs)
Me.GroupBox1.Controls.Add(Me.LblErnTot)
Me.GroupBox1.Controls.Add(Me.Label8)
Me.GroupBox1.Controls.Add(Me.Label7)
Me.GroupBox1.Controls.Add(Me.Label6)
Me.GroupBox1.Controls.Add(Me.C1DataGrdErn)
Me.GroupBox1.Controls.Add(Me.Label13)
Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
Me.GroupBox1.Location = New System.Drawing.Point(15, 61)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(284, 243)
Me.GroupBox1.TabIndex = 5
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Earnings"
'
'BtnErnRemove
'
Me.BtnErnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.BtnErnRemove.ForeColor = System.Drawing.Color.Black
Me.BtnErnRemove.Location = New System.Drawing.Point(6, 218)
Me.BtnErnRemove.Name = "BtnErnRemove"
Me.BtnErnRemove.Size = New System.Drawing.Size(79, 19)
Me.BtnErnRemove.TabIndex = 318
Me.BtnErnRemove.Text = "Remove Item" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
Me.BtnErnRemove.UseVisualStyleBackColor = True
'
'TxtErnAmt
'
Me.TxtErnAmt.Location = New System.Drawing.Point(189, 33)
Me.TxtErnAmt.Name = "TxtErnAmt"
Me.TxtErnAmt.Size = New System.Drawing.Size(71, 21)
Me.TxtErnAmt.TabIndex = 314
'
'TxtErnDesc
'
Me.TxtErnDesc.Location = New System.Drawing.Point(47, 33)
Me.TxtErnDesc.Name = "TxtErnDesc"
Me.TxtErnDesc.Size = New System.Drawing.Size(136, 21)
Me.TxtErnDesc.TabIndex = 312
'
'TxtErnHrs
'
Me.TxtErnHrs.Location = New System.Drawing.Point(6, 33)
Me.TxtErnHrs.Name = "TxtErnHrs"
Me.TxtErnHrs.Size = New System.Drawing.Size(34, 21)
Me.TxtErnHrs.TabIndex = 310
'
'LblErnTot
'
Me.LblErnTot.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblErnTot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LblErnTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblErnTot.ForeColor = System.Drawing.Color.Black
Me.LblErnTot.Location = New System.Drawing.Point(187, 221)
Me.LblErnTot.Name = "LblErnTot"
Me.LblErnTot.Size = New System.Drawing.Size(72, 20)
Me.LblErnTot.TabIndex = 317
Me.LblErnTot.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label8
'
Me.Label8.AutoSize = True
Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label8.ForeColor = System.Drawing.Color.Black
Me.Label8.Location = New System.Drawing.Point(204, 17)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(43, 13)
Me.Label8.TabIndex = 315
Me.Label8.Text = "Amount"
'
'Label7
'
Me.Label7.AutoSize = True
Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label7.ForeColor = System.Drawing.Color.Black
Me.Label7.Location = New System.Drawing.Point(44, 17)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(60, 13)
Me.Label7.TabIndex = 313
Me.Label7.Text = "Description"
'
'Label6
'
Me.Label6.AutoSize = True
Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label6.ForeColor = System.Drawing.Color.Black
Me.Label6.Location = New System.Drawing.Point(3, 17)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(35, 13)
Me.Label6.TabIndex = 311
Me.Label6.Text = "Hours"
'
'C1DataGrdErn
'
Me.C1DataGrdErn.AllowColMove = False
Me.C1DataGrdErn.AllowColSelect = False
Me.C1DataGrdErn.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
Me.C1DataGrdErn.AllowSort = False
Me.C1DataGrdErn.AllowUpdate = False
Me.C1DataGrdErn.AlternatingRows = True
Me.C1DataGrdErn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.C1DataGrdErn.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
Me.C1DataGrdErn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.C1DataGrdErn.GroupByCaption = "Drag a column header here to group by that column"
Me.C1DataGrdErn.Images.Add(CType(resources.GetObject("C1DataGrdErn.Images"), System.Drawing.Image))
Me.C1DataGrdErn.Location = New System.Drawing.Point(6, 60)
Me.C1DataGrdErn.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
Me.C1DataGrdErn.Name = "C1DataGrdErn"
Me.C1DataGrdErn.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdErn.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdErn.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdErn.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdErn.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.C1DataGrdErn.Size = New System.Drawing.Size(272, 162)
Me.C1DataGrdErn.TabIndex = 305
Me.C1DataGrdErn.PropBag = resources.GetString("C1DataGrdErn.PropBag")
'
'Label13
'
Me.Label13.AutoSize = True
Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label13.ForeColor = System.Drawing.Color.Black
Me.Label13.Location = New System.Drawing.Point(148, 224)
Me.Label13.Name = "Label13"
Me.Label13.Size = New System.Drawing.Size(31, 13)
Me.Label13.TabIndex = 316
Me.Label13.Text = "Total"
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.BtnDedRemove)
Me.GroupBox2.Controls.Add(Me.Label15)
Me.GroupBox2.Controls.Add(Me.TxtDedAmt)
Me.GroupBox2.Controls.Add(Me.TxtDedDesc)
Me.GroupBox2.Controls.Add(Me.LblDedTot)
Me.GroupBox2.Controls.Add(Me.C1DataGrdDed)
Me.GroupBox2.Controls.Add(Me.Label9)
Me.GroupBox2.Controls.Add(Me.Label10)
Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox2.ForeColor = System.Drawing.Color.Blue
Me.GroupBox2.Location = New System.Drawing.Point(322, 61)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(248, 243)
Me.GroupBox2.TabIndex = 6
Me.GroupBox2.TabStop = False
Me.GroupBox2.Text = "Deductions"
'
'BtnDedRemove
'
Me.BtnDedRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.BtnDedRemove.ForeColor = System.Drawing.Color.Black
Me.BtnDedRemove.Location = New System.Drawing.Point(5, 221)
Me.BtnDedRemove.Name = "BtnDedRemove"
Me.BtnDedRemove.Size = New System.Drawing.Size(79, 19)
Me.BtnDedRemove.TabIndex = 320
Me.BtnDedRemove.Text = "Remove Item" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
Me.BtnDedRemove.UseVisualStyleBackColor = True
'
'Label15
'
Me.Label15.AutoSize = True
Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label15.ForeColor = System.Drawing.Color.Black
Me.Label15.Location = New System.Drawing.Point(113, 224)
Me.Label15.Name = "Label15"
Me.Label15.Size = New System.Drawing.Size(31, 13)
Me.Label15.TabIndex = 318
Me.Label15.Text = "Total"
'
'TxtDedAmt
'
Me.TxtDedAmt.Location = New System.Drawing.Point(150, 33)
Me.TxtDedAmt.Name = "TxtDedAmt"
Me.TxtDedAmt.Size = New System.Drawing.Size(71, 21)
Me.TxtDedAmt.TabIndex = 308
'
'TxtDedDesc
'
Me.TxtDedDesc.Location = New System.Drawing.Point(8, 33)
Me.TxtDedDesc.Name = "TxtDedDesc"
Me.TxtDedDesc.Size = New System.Drawing.Size(136, 21)
Me.TxtDedDesc.TabIndex = 306
'
'LblDedTot
'
Me.LblDedTot.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblDedTot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LblDedTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblDedTot.ForeColor = System.Drawing.Color.Black
Me.LblDedTot.Location = New System.Drawing.Point(150, 221)
Me.LblDedTot.Name = "LblDedTot"
Me.LblDedTot.Size = New System.Drawing.Size(72, 20)
Me.LblDedTot.TabIndex = 319
Me.LblDedTot.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'C1DataGrdDed
'
Me.C1DataGrdDed.AllowColMove = False
Me.C1DataGrdDed.AllowColSelect = False
Me.C1DataGrdDed.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
Me.C1DataGrdDed.AllowSort = False
Me.C1DataGrdDed.AllowUpdate = False
Me.C1DataGrdDed.AlternatingRows = True
Me.C1DataGrdDed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.C1DataGrdDed.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
Me.C1DataGrdDed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.C1DataGrdDed.GroupByCaption = "Drag a column header here to group by that column"
Me.C1DataGrdDed.Images.Add(CType(resources.GetObject("C1DataGrdDed.Images"), System.Drawing.Image))
Me.C1DataGrdDed.Location = New System.Drawing.Point(5, 60)
Me.C1DataGrdDed.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
Me.C1DataGrdDed.Name = "C1DataGrdDed"
Me.C1DataGrdDed.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdDed.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdDed.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdDed.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdDed.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.C1DataGrdDed.Size = New System.Drawing.Size(237, 162)
Me.C1DataGrdDed.TabIndex = 310
Me.C1DataGrdDed.PropBag = resources.GetString("C1DataGrdDed.PropBag")
'
'Label9
'
Me.Label9.AutoSize = True
Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label9.ForeColor = System.Drawing.Color.Black
Me.Label9.Location = New System.Drawing.Point(165, 17)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(43, 13)
Me.Label9.TabIndex = 309
Me.Label9.Text = "Amount"
'
'Label10
'
Me.Label10.AutoSize = True
Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label10.ForeColor = System.Drawing.Color.Black
Me.Label10.Location = New System.Drawing.Point(5, 17)
Me.Label10.Name = "Label10"
Me.Label10.Size = New System.Drawing.Size(60, 13)
Me.Label10.TabIndex = 307
Me.Label10.Text = "Description"
'
'Label12
'
Me.Label12.AutoSize = True
Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label12.ForeColor = System.Drawing.Color.Blue
Me.Label12.Location = New System.Drawing.Point(199, 329)
Me.Label12.Name = "Label12"
Me.Label12.Size = New System.Drawing.Size(63, 16)
Me.Label12.TabIndex = 15
Me.Label12.Text = "Net Pay"
'
'LblNetPay
'
Me.LblNetPay.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblNetPay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LblNetPay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblNetPay.Location = New System.Drawing.Point(268, 325)
Me.LblNetPay.Name = "LblNetPay"
Me.LblNetPay.Size = New System.Drawing.Size(72, 20)
Me.LblNetPay.TabIndex = 318
Me.LblNetPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'RbClear
'
Me.RbClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbClear.ForeColor = System.Drawing.Color.Black
Me.RbClear.Location = New System.Drawing.Point(15, 310)
Me.RbClear.Name = "RbClear"
Me.RbClear.Size = New System.Drawing.Size(79, 34)
Me.RbClear.TabIndex = 319
Me.RbClear.Text = "Clear Form"
Me.RbClear.UseVisualStyleBackColor = True
'
'FrmPRPRTCHKC
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(585, 354)
Me.Controls.Add(Me.RbClear)
Me.Controls.Add(Me.DtPckChk)
Me.Controls.Add(Me.TxtChkNo)
Me.Controls.Add(Me.TxtEmpNo)
Me.Controls.Add(Me.TxtDept)
Me.Controls.Add(Me.TxtName)
Me.Controls.Add(Me.LblNetPay)
Me.Controls.Add(Me.Label12)
Me.Controls.Add(Me.GroupBox2)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmPRPRTCHKC"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Manual Check Entry (Data will NOT be saved)"
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox1.PerformLayout()
CType(Me.C1DataGrdErn, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox2.ResumeLayout(False)
Me.GroupBox2.PerformLayout()
CType(Me.C1DataGrdDed, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDept As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtEmpNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtChkNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DtPckChk As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents C1DataGrdErn As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtDedAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtDedDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents LblErnTot As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtErnAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtErnDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtErnHrs As System.Windows.Forms.TextBox
    Friend WithEvents LblDedTot As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents C1DataGrdDed As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents LblNetPay As System.Windows.Forms.Label
    Friend WithEvents BtnErnRemove As System.Windows.Forms.Button
    Friend WithEvents BtnDedRemove As System.Windows.Forms.Button
    Friend WithEvents RbClear As System.Windows.Forms.Button
End Class
