<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
    Me.TxtPass = New System.Windows.Forms.TextBox()
    Me.TxtResult = New System.Windows.Forms.TextBox()
    Me.BtnProcess = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'TxtPass
    '
    Me.TxtPass.Location = New System.Drawing.Point(56, 26)
    Me.TxtPass.Name = "TxtPass"
    Me.TxtPass.Size = New System.Drawing.Size(110, 20)
    Me.TxtPass.TabIndex = 0
    '
    'TxtResult
    '
    Me.TxtResult.Location = New System.Drawing.Point(56, 79)
    Me.TxtResult.Name = "TxtResult"
    Me.TxtResult.Size = New System.Drawing.Size(315, 20)
    Me.TxtResult.TabIndex = 1
    '
    'BtnProcess
    '
    Me.BtnProcess.Location = New System.Drawing.Point(134, 50)
    Me.BtnProcess.Name = "BtnProcess"
    Me.BtnProcess.Size = New System.Drawing.Size(32, 23)
    Me.BtnProcess.TabIndex = 2
    Me.BtnProcess.Text = ">>"
    Me.BtnProcess.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(22, 29)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(28, 13)
    Me.Label1.TabIndex = 3
    Me.Label1.Text = "Pwd"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(13, 82)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(37, 13)
    Me.Label2.TabIndex = 4
    Me.Label2.Text = "Result"
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(385, 126)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnProcess)
    Me.Controls.Add(Me.TxtResult)
    Me.Controls.Add(Me.TxtPass)
    Me.Name = "Form1"
    Me.Text = "Gen Pass"
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub
    Friend WithEvents TxtPass As System.Windows.Forms.TextBox
    Friend WithEvents TxtResult As System.Windows.Forms.TextBox
    Friend WithEvents BtnProcess As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
