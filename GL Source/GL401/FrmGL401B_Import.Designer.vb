<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGL401B_Import
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
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.GrpFile = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.BtnCreate = New System.Windows.Forms.Button()
    Me.RbPRJE = New System.Windows.Forms.RadioButton()
    Me.RbJE = New System.Windows.Forms.RadioButton()
    Me.RbBudget = New System.Windows.Forms.RadioButton()
    Me.RbPRPaycor = New System.Windows.Forms.RadioButton()
    Me.GrpFile.SuspendLayout()
    Me.SuspendLayout()
    '
    'GrpFile
    '
    Me.GrpFile.Controls.Add(Me.LblFilePath)
    Me.GrpFile.Controls.Add(Me.LnkFilePath)
    Me.GrpFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpFile.Location = New System.Drawing.Point(12, 52)
    Me.GrpFile.Name = "GrpFile"
    Me.GrpFile.Size = New System.Drawing.Size(408, 56)
    Me.GrpFile.TabIndex = 3
    Me.GrpFile.TabStop = False
    Me.GrpFile.Text = "File Details"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePath.Name = "LblFilePath"
    Me.LblFilePath.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePath.TabIndex = 67
    '
    'LnkFilePath
    '
    Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePath.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePath.Name = "LnkFilePath"
    Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath.TabIndex = 65
    Me.LnkFilePath.TabStop = True
    Me.LnkFilePath.Text = "File Path"
    '
    'BtnCreate
    '
    Me.BtnCreate.Location = New System.Drawing.Point(148, 114)
    Me.BtnCreate.Name = "BtnCreate"
    Me.BtnCreate.Size = New System.Drawing.Size(110, 37)
    Me.BtnCreate.TabIndex = 4
    Me.BtnCreate.Text = "Create Batch"
    Me.BtnCreate.UseVisualStyleBackColor = True
    '
    'RbPRJE
    '
    Me.RbPRJE.AutoSize = True
    Me.RbPRJE.Location = New System.Drawing.Point(303, 12)
    Me.RbPRJE.Name = "RbPRJE"
    Me.RbPRJE.Size = New System.Drawing.Size(117, 17)
    Me.RbPRJE.TabIndex = 2
    Me.RbPRJE.Text = "P/R Journal Entries"
    Me.RbPRJE.UseVisualStyleBackColor = True
    '
    'RbJE
    '
    Me.RbJE.AutoSize = True
    Me.RbJE.Checked = True
    Me.RbJE.Location = New System.Drawing.Point(27, 12)
    Me.RbJE.Name = "RbJE"
    Me.RbJE.Size = New System.Drawing.Size(116, 17)
    Me.RbJE.TabIndex = 0
    Me.RbJE.TabStop = True
    Me.RbJE.Text = "G/L Journal Entries"
    Me.RbJE.UseVisualStyleBackColor = True
    '
    'RbBudget
    '
    Me.RbBudget.AutoSize = True
    Me.RbBudget.Location = New System.Drawing.Point(165, 12)
    Me.RbBudget.Name = "RbBudget"
    Me.RbBudget.Size = New System.Drawing.Size(116, 17)
    Me.RbBudget.TabIndex = 1
    Me.RbBudget.Text = "G/L Budget Entries"
    Me.RbBudget.UseVisualStyleBackColor = True
    '
    'RbPRPaycor
    '
    Me.RbPRPaycor.AutoSize = True
    Me.RbPRPaycor.Location = New System.Drawing.Point(441, 12)
    Me.RbPRPaycor.Name = "RbPRPaycor"
    Me.RbPRPaycor.Size = New System.Drawing.Size(81, 17)
    Me.RbPRPaycor.TabIndex = 5
    Me.RbPRPaycor.Text = "P/R Paycor"
    Me.RbPRPaycor.UseVisualStyleBackColor = True
    '
    'FrmGL401B_Import
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(531, 163)
    Me.ControlBox = False
    Me.Controls.Add(Me.RbPRPaycor)
    Me.Controls.Add(Me.RbBudget)
    Me.Controls.Add(Me.RbJE)
    Me.Controls.Add(Me.RbPRJE)
    Me.Controls.Add(Me.BtnCreate)
    Me.Controls.Add(Me.GrpFile)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL401B_Import"
    Me.Text = "Import File"
    Me.GrpFile.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GrpFile As System.Windows.Forms.GroupBox
    Friend WithEvents LblFilePath As System.Windows.Forms.Label
    Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
    Friend WithEvents BtnCreate As System.Windows.Forms.Button
    Friend WithEvents RbPRJE As System.Windows.Forms.RadioButton
  Friend WithEvents RbJE As RadioButton
  Friend WithEvents RbBudget As RadioButton
  Friend WithEvents RbPRPaycor As RadioButton
End Class
