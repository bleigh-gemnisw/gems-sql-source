<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGLA35B_New
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
Me.BtnCreate = New System.Windows.Forms.Button
Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.LblFilePath = New System.Windows.Forms.Label
Me.LnkFilePath = New System.Windows.Forms.LinkLabel
Me.GroupBox1.SuspendLayout()
Me.SuspendLayout()
'
'BtnCreate
'
Me.BtnCreate.Location = New System.Drawing.Point(182, 74)
Me.BtnCreate.Name = "BtnCreate"
Me.BtnCreate.Size = New System.Drawing.Size(84, 37)
Me.BtnCreate.TabIndex = 3
Me.BtnCreate.Text = "Create Batch"
Me.BtnCreate.UseVisualStyleBackColor = True
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.LblFilePath)
Me.GroupBox1.Controls.Add(Me.LnkFilePath)
Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(408, 56)
Me.GroupBox1.TabIndex = 28
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "File Details"
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
'FrmGLA35B_New
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(440, 125)
Me.ControlBox = False
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.BtnCreate)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.Name = "FrmGLA35B_New"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.Text = "Create New Batch"
Me.GroupBox1.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub
    Friend WithEvents BtnCreate As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblFilePath As System.Windows.Forms.Label
    Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
End Class
