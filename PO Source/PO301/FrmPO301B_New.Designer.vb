<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPO301B_New
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
    Me.BtnCreate = New System.Windows.Forms.Button()
    Me.DtPckPost = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'BtnCreate
    '
    Me.BtnCreate.Location = New System.Drawing.Point(105, 59)
    Me.BtnCreate.Name = "BtnCreate"
    Me.BtnCreate.Size = New System.Drawing.Size(84, 37)
    Me.BtnCreate.TabIndex = 3
    Me.BtnCreate.Text = "Create Batch"
    Me.BtnCreate.UseVisualStyleBackColor = True
    '
    'DtPckPost
    '
    Me.DtPckPost.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckPost.Location = New System.Drawing.Point(135, 23)
    Me.DtPckPost.Name = "DtPckPost"
    Me.DtPckPost.Size = New System.Drawing.Size(84, 20)
    Me.DtPckPost.TabIndex = 4
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(61, 25)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(68, 13)
    Me.Label1.TabIndex = 5
    Me.Label1.Text = "Posting Date"
    '
    'FrmPO301B_New
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(291, 125)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.DtPckPost)
    Me.Controls.Add(Me.BtnCreate)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmPO301B_New"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Create New Batch"
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub
    Friend WithEvents BtnCreate As System.Windows.Forms.Button
    Friend WithEvents DtPckPost As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
