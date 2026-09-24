<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTA941B
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
Me.components = New System.ComponentModel.Container
Me.BtnCheck = New System.Windows.Forms.Button
Me.LblMsg2 = New System.Windows.Forms.Label
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.LblFilePath = New System.Windows.Forms.Label
Me.LnkFilePath = New System.Windows.Forms.LinkLabel
Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.LblListNo = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.Label4 = New System.Windows.Forms.Label
Me.LblName = New System.Windows.Forms.Label
Me.Label5 = New System.Windows.Forms.Label
Me.LblValue = New System.Windows.Forms.Label
Me.BtnContinue = New System.Windows.Forms.Button
Me.Label1 = New System.Windows.Forms.Label
Me.GroupBox1.SuspendLayout()
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'BtnCheck
'
Me.BtnCheck.Location = New System.Drawing.Point(172, 112)
Me.BtnCheck.Name = "BtnCheck"
Me.BtnCheck.Size = New System.Drawing.Size(107, 23)
Me.BtnCheck.TabIndex = 9
Me.BtnCheck.Text = "Check File Format"
Me.BtnCheck.UseVisualStyleBackColor = True
'
'LblMsg2
'
Me.LblMsg2.AutoSize = True
Me.LblMsg2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblMsg2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
Me.LblMsg2.Location = New System.Drawing.Point(114, 9)
Me.LblMsg2.Name = "LblMsg2"
Me.LblMsg2.Size = New System.Drawing.Size(209, 13)
Me.LblMsg2.TabIndex = 7
Me.LblMsg2.Text = "In Express Software, Export as CSV"
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.LblFilePath)
Me.GroupBox1.Controls.Add(Me.LnkFilePath)
Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox1.Location = New System.Drawing.Point(15, 34)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(408, 72)
Me.GroupBox1.TabIndex = 8
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "File Details"
'
'LblFilePath
'
Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblFilePath.Location = New System.Drawing.Point(70, 24)
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
Me.LnkFilePath.TabIndex = 8
Me.LnkFilePath.TabStop = True
Me.LnkFilePath.Text = "File Path"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'LblListNo
'
Me.LblListNo.AutoSize = True
Me.LblListNo.Location = New System.Drawing.Point(56, 164)
Me.LblListNo.Name = "LblListNo"
Me.LblListNo.Size = New System.Drawing.Size(52, 13)
Me.LblListNo.TabIndex = 10
Me.LblListNo.Text = "<List No>"
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Location = New System.Drawing.Point(12, 164)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(43, 13)
Me.Label2.TabIndex = 12
Me.Label2.Text = "List No:"
'
'Label4
'
Me.Label4.AutoSize = True
Me.Label4.Location = New System.Drawing.Point(12, 189)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(38, 13)
Me.Label4.TabIndex = 16
Me.Label4.Text = "Name:"
'
'LblName
'
Me.LblName.AutoSize = True
Me.LblName.Location = New System.Drawing.Point(56, 189)
Me.LblName.Name = "LblName"
Me.LblName.Size = New System.Drawing.Size(47, 13)
Me.LblName.TabIndex = 14
Me.LblName.Text = "<Name>"
'
'Label5
'
Me.Label5.AutoSize = True
Me.Label5.Location = New System.Drawing.Point(12, 215)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(37, 13)
Me.Label5.TabIndex = 19
Me.Label5.Text = "Value:"
'
'LblValue
'
Me.LblValue.AutoSize = True
Me.LblValue.Location = New System.Drawing.Point(56, 215)
Me.LblValue.Name = "LblValue"
Me.LblValue.Size = New System.Drawing.Size(46, 13)
Me.LblValue.TabIndex = 17
Me.LblValue.Text = "<Value>"
'
'BtnContinue
'
Me.BtnContinue.Location = New System.Drawing.Point(172, 235)
Me.BtnContinue.Name = "BtnContinue"
Me.BtnContinue.Size = New System.Drawing.Size(107, 23)
Me.BtnContinue.TabIndex = 20
Me.BtnContinue.Text = "Continue"
Me.BtnContinue.UseVisualStyleBackColor = True
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.Location = New System.Drawing.Point(12, 141)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(119, 13)
Me.Label1.TabIndex = 21
Me.Label1.Text = "First Data Record..."
'
'FrmTA941B
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(436, 270)
Me.ControlBox = False
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.BtnContinue)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.LblValue)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.LblName)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.LblListNo)
Me.Controls.Add(Me.BtnCheck)
Me.Controls.Add(Me.LblMsg2)
Me.Controls.Add(Me.GroupBox1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA941B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.GroupBox1.ResumeLayout(False)
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents BtnCheck As System.Windows.Forms.Button
    Friend WithEvents LblMsg2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblFilePath As System.Windows.Forms.Label
    Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblListNo As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblValue As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents BtnContinue As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class






