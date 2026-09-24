<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGL401B_New
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
    Me.Label3 = New System.Windows.Forms.Label()
    Me.DtPckPost = New System.Windows.Forms.DateTimePicker()
    Me.SuspendLayout()
    '
    'BtnCreate
    '
    Me.BtnCreate.Location = New System.Drawing.Point(55, 65)
    Me.BtnCreate.Name = "BtnCreate"
    Me.BtnCreate.Size = New System.Drawing.Size(84, 37)
    Me.BtnCreate.TabIndex = 3
    Me.BtnCreate.Text = "Create Batch"
    Me.BtnCreate.UseVisualStyleBackColor = True
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(16, 32)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(70, 16)
    Me.Label3.TabIndex = 27
    Me.Label3.Text = "Posting Date"
    '
    'DtPckPost
    '
    Me.DtPckPost.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckPost.Location = New System.Drawing.Point(92, 28)
    Me.DtPckPost.Name = "DtPckPost"
    Me.DtPckPost.Size = New System.Drawing.Size(88, 20)
    Me.DtPckPost.TabIndex = 1
    Me.DtPckPost.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
    '
    'FrmGL401B_New
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(203, 124)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.DtPckPost)
    Me.Controls.Add(Me.BtnCreate)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmGL401B_New"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Create New Batch"
    Me.ResumeLayout(false)

End Sub
    Friend WithEvents BtnCreate As System.Windows.Forms.Button
 Friend WithEvents Label3 As System.Windows.Forms.Label
 Friend WithEvents DtPckPost As System.Windows.Forms.DateTimePicker
End Class
