<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGL403B_New
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
        Me.LabelHeading = New System.Windows.Forms.Label()
        Me.TxtHeading = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'BtnCreate
        '
        Me.BtnCreate.Location = New System.Drawing.Point(148, 94)
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
        'LabelHeading
        '
        Me.LabelHeading.Location = New System.Drawing.Point(16, 62)
        Me.LabelHeading.Name = "LabelHeading"
        Me.LabelHeading.Size = New System.Drawing.Size(70, 16)
        Me.LabelHeading.TabIndex = 28
        Me.LabelHeading.Text = "Description"
        '
        'TxtHeading
        '
        Me.TxtHeading.Location = New System.Drawing.Point(92, 58)
        Me.TxtHeading.MaxLength = 32
        Me.TxtHeading.Name = "TxtHeading"
        Me.TxtHeading.Size = New System.Drawing.Size(250, 20)
        Me.TxtHeading.TabIndex = 2
        '
        'FrmGL403B_New
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(362, 151)
        Me.ControlBox = False
        Me.Controls.Add(Me.TxtHeading)
        Me.Controls.Add(Me.LabelHeading)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DtPckPost)
        Me.Controls.Add(Me.BtnCreate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmGL403B_New"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Create New Batch"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnCreate As System.Windows.Forms.Button
 Friend WithEvents Label3 As System.Windows.Forms.Label
 Friend WithEvents DtPckPost As System.Windows.Forms.DateTimePicker
 Friend WithEvents LabelHeading As System.Windows.Forms.Label
 Friend WithEvents TxtHeading As System.Windows.Forms.TextBox
End Class
