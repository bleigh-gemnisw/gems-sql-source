<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTAP01HOR2
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
    Me.components = New System.ComponentModel.Container()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.TxtBreed = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtReg = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtAge = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtValue = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GrpSex = New System.Windows.Forms.GroupBox()
    Me.RbSexUnknown = New System.Windows.Forms.RadioButton()
    Me.RbSexFemale = New System.Windows.Forms.RadioButton()
    Me.RbSexMale = New System.Windows.Forms.RadioButton()
    Me.GrpQual = New System.Windows.Forms.GroupBox()
    Me.RbQualUnknown = New System.Windows.Forms.RadioButton()
    Me.RbQualRacing = New System.Windows.Forms.RadioButton()
    Me.RbQualPleasure = New System.Windows.Forms.RadioButton()
    Me.RbQualShow = New System.Windows.Forms.RadioButton()
    Me.RbQualBreeding = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpSex.SuspendLayout()
    Me.GrpQual.SuspendLayout()
    Me.SuspendLayout()
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblYear.Location = New System.Drawing.Point(191, 8)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(33, 18)
    Me.LblYear.TabIndex = 211
    Me.LblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblListNo
    '
    Me.LblListNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblListNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblListNo.Location = New System.Drawing.Point(69, 8)
    Me.LblListNo.Name = "LblListNo"
    Me.LblListNo.Size = New System.Drawing.Size(66, 18)
    Me.LblListNo.TabIndex = 210
    Me.LblListNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label30
    '
    Me.Label30.Location = New System.Drawing.Point(12, 9)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(51, 17)
    Me.Label30.TabIndex = 213
    Me.Label30.Text = "List No"
    '
    'Label29
    '
    Me.Label29.Location = New System.Drawing.Point(154, 9)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(35, 17)
    Me.Label29.TabIndex = 212
    Me.Label29.Text = "Year"
    '
    'TxtBreed
    '
    Me.TxtBreed.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBreed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBreed.Location = New System.Drawing.Point(8, 59)
    Me.TxtBreed.MaxLength = 20
    Me.TxtBreed.Name = "TxtBreed"
    Me.TxtBreed.Size = New System.Drawing.Size(153, 20)
    Me.TxtBreed.TabIndex = 214
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 43)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(35, 13)
    Me.Label1.TabIndex = 215
    Me.Label1.Text = "Breed"
    '
    'TxtReg
    '
    Me.TxtReg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtReg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtReg.Location = New System.Drawing.Point(167, 59)
    Me.TxtReg.MaxLength = 10
    Me.TxtReg.Name = "TxtReg"
    Me.TxtReg.Size = New System.Drawing.Size(86, 20)
    Me.TxtReg.TabIndex = 216
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(166, 43)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(58, 13)
    Me.Label2.TabIndex = 217
    Me.Label2.Text = "Registered"
    '
    'TxtAge
    '
    Me.TxtAge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAge.Location = New System.Drawing.Point(259, 59)
    Me.TxtAge.MaxLength = 2
    Me.TxtAge.Name = "TxtAge"
    Me.TxtAge.Size = New System.Drawing.Size(28, 20)
    Me.TxtAge.TabIndex = 222
    Me.TxtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(256, 43)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(26, 13)
    Me.Label5.TabIndex = 223
    Me.Label5.Text = "Age"
    '
    'TxtValue
    '
    Me.TxtValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtValue.Location = New System.Drawing.Point(517, 59)
    Me.TxtValue.MaxLength = 9
    Me.TxtValue.Name = "TxtValue"
    Me.TxtValue.Size = New System.Drawing.Size(73, 20)
    Me.TxtValue.TabIndex = 230
    Me.TxtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(533, 43)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(34, 13)
    Me.Label9.TabIndex = 231
    Me.Label9.Text = "Value"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GrpSex
    '
    Me.GrpSex.Controls.Add(Me.RbSexUnknown)
    Me.GrpSex.Controls.Add(Me.RbSexFemale)
    Me.GrpSex.Controls.Add(Me.RbSexMale)
    Me.GrpSex.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpSex.Location = New System.Drawing.Point(305, 14)
    Me.GrpSex.Name = "GrpSex"
    Me.GrpSex.Size = New System.Drawing.Size(92, 93)
    Me.GrpSex.TabIndex = 232
    Me.GrpSex.TabStop = False
    Me.GrpSex.Text = "Sex"
    '
    'RbSexUnknown
    '
    Me.RbSexUnknown.AutoSize = True
    Me.RbSexUnknown.Checked = True
    Me.RbSexUnknown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSexUnknown.Location = New System.Drawing.Point(11, 63)
    Me.RbSexUnknown.Name = "RbSexUnknown"
    Me.RbSexUnknown.Size = New System.Drawing.Size(71, 17)
    Me.RbSexUnknown.TabIndex = 2
    Me.RbSexUnknown.TabStop = True
    Me.RbSexUnknown.Text = "Unknown"
    Me.RbSexUnknown.UseVisualStyleBackColor = True
    '
    'RbSexFemale
    '
    Me.RbSexFemale.AutoSize = True
    Me.RbSexFemale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSexFemale.Location = New System.Drawing.Point(11, 40)
    Me.RbSexFemale.Name = "RbSexFemale"
    Me.RbSexFemale.Size = New System.Drawing.Size(59, 17)
    Me.RbSexFemale.TabIndex = 1
    Me.RbSexFemale.Text = "Female"
    Me.RbSexFemale.UseVisualStyleBackColor = True
    '
    'RbSexMale
    '
    Me.RbSexMale.AutoSize = True
    Me.RbSexMale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSexMale.Location = New System.Drawing.Point(11, 17)
    Me.RbSexMale.Name = "RbSexMale"
    Me.RbSexMale.Size = New System.Drawing.Size(48, 17)
    Me.RbSexMale.TabIndex = 0
    Me.RbSexMale.Text = "Male"
    Me.RbSexMale.UseVisualStyleBackColor = True
    '
    'GrpQual
    '
    Me.GrpQual.Controls.Add(Me.RbQualUnknown)
    Me.GrpQual.Controls.Add(Me.RbQualRacing)
    Me.GrpQual.Controls.Add(Me.RbQualPleasure)
    Me.GrpQual.Controls.Add(Me.RbQualShow)
    Me.GrpQual.Controls.Add(Me.RbQualBreeding)
    Me.GrpQual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpQual.Location = New System.Drawing.Point(403, 13)
    Me.GrpQual.Name = "GrpQual"
    Me.GrpQual.Size = New System.Drawing.Size(92, 119)
    Me.GrpQual.TabIndex = 233
    Me.GrpQual.TabStop = False
    Me.GrpQual.Text = "Quality"
    '
    'RbQualUnknown
    '
    Me.RbQualUnknown.AutoSize = True
    Me.RbQualUnknown.Checked = True
    Me.RbQualUnknown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbQualUnknown.Location = New System.Drawing.Point(11, 97)
    Me.RbQualUnknown.Name = "RbQualUnknown"
    Me.RbQualUnknown.Size = New System.Drawing.Size(71, 17)
    Me.RbQualUnknown.TabIndex = 4
    Me.RbQualUnknown.TabStop = True
    Me.RbQualUnknown.Text = "Unknown"
    Me.RbQualUnknown.UseVisualStyleBackColor = True
    '
    'RbQualRacing
    '
    Me.RbQualRacing.AutoSize = True
    Me.RbQualRacing.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbQualRacing.Location = New System.Drawing.Point(11, 77)
    Me.RbQualRacing.Name = "RbQualRacing"
    Me.RbQualRacing.Size = New System.Drawing.Size(59, 17)
    Me.RbQualRacing.TabIndex = 3
    Me.RbQualRacing.Text = "Racing"
    Me.RbQualRacing.UseVisualStyleBackColor = True
    '
    'RbQualPleasure
    '
    Me.RbQualPleasure.AutoSize = True
    Me.RbQualPleasure.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbQualPleasure.Location = New System.Drawing.Point(11, 57)
    Me.RbQualPleasure.Name = "RbQualPleasure"
    Me.RbQualPleasure.Size = New System.Drawing.Size(66, 17)
    Me.RbQualPleasure.TabIndex = 2
    Me.RbQualPleasure.Text = "Pleasure"
    Me.RbQualPleasure.UseVisualStyleBackColor = True
    '
    'RbQualShow
    '
    Me.RbQualShow.AutoSize = True
    Me.RbQualShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbQualShow.Location = New System.Drawing.Point(11, 37)
    Me.RbQualShow.Name = "RbQualShow"
    Me.RbQualShow.Size = New System.Drawing.Size(52, 17)
    Me.RbQualShow.TabIndex = 1
    Me.RbQualShow.Text = "Show"
    Me.RbQualShow.UseVisualStyleBackColor = True
    '
    'RbQualBreeding
    '
    Me.RbQualBreeding.AutoSize = True
    Me.RbQualBreeding.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbQualBreeding.Location = New System.Drawing.Point(11, 17)
    Me.RbQualBreeding.Name = "RbQualBreeding"
    Me.RbQualBreeding.Size = New System.Drawing.Size(67, 17)
    Me.RbQualBreeding.TabIndex = 0
    Me.RbQualBreeding.Text = "Breeding"
    Me.RbQualBreeding.UseVisualStyleBackColor = True
    '
    'FrmTAP01HOR2
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(606, 138)
    Me.ControlBox = False
    Me.Controls.Add(Me.GrpQual)
    Me.Controls.Add(Me.GrpSex)
    Me.Controls.Add(Me.TxtValue)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.TxtAge)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtReg)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtBreed)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.LblListNo)
    Me.Controls.Add(Me.Label30)
    Me.Controls.Add(Me.Label29)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAP01HOR2"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Maintain Horses and Ponies"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpSex.ResumeLayout(False)
    Me.GrpSex.PerformLayout()
    Me.GrpQual.ResumeLayout(False)
    Me.GrpQual.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
    Friend WithEvents LblYear As System.Windows.Forms.Label
    Friend WithEvents LblListNo As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TxtBreed As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtReg As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtAge As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtValue As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents GrpSex As System.Windows.Forms.GroupBox
    Friend WithEvents RbSexUnknown As System.Windows.Forms.RadioButton
    Friend WithEvents RbSexFemale As System.Windows.Forms.RadioButton
    Friend WithEvents RbSexMale As System.Windows.Forms.RadioButton
    Friend WithEvents GrpQual As System.Windows.Forms.GroupBox
    Friend WithEvents RbQualPleasure As System.Windows.Forms.RadioButton
    Friend WithEvents RbQualShow As System.Windows.Forms.RadioButton
    Friend WithEvents RbQualBreeding As System.Windows.Forms.RadioButton
    Friend WithEvents RbQualUnknown As System.Windows.Forms.RadioButton
    Friend WithEvents RbQualRacing As System.Windows.Forms.RadioButton
End Class






