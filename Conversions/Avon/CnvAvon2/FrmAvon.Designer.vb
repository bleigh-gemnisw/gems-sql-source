<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAvon
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()>
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
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.BtnConvert = New System.Windows.Forms.Button()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtDBName = New System.Windows.Forms.TextBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'BtnConvert
    '
    Me.BtnConvert.Location = New System.Drawing.Point(228, 175)
    Me.BtnConvert.Name = "BtnConvert"
    Me.BtnConvert.Size = New System.Drawing.Size(67, 22)
    Me.BtnConvert.TabIndex = 4
    Me.BtnConvert.Text = "Convert"
    Me.BtnConvert.UseVisualStyleBackColor = True
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(12, 41)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(31, 13)
    Me.Label4.TabIndex = 29
    Me.Label4.Text = "Type"
    '
    'TxtType
    '
    Me.TxtType.Location = New System.Drawing.Point(100, 38)
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(22, 20)
    Me.TxtType.TabIndex = 25
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 67)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(51, 13)
    Me.Label3.TabIndex = 28
    Me.Label3.Text = "G/L Year"
    '
    'TxtYear
    '
    Me.TxtYear.Location = New System.Drawing.Point(100, 64)
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(39, 20)
    Me.TxtYear.TabIndex = 26
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 15)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(82, 13)
    Me.Label2.TabIndex = 27
    Me.Label2.Text = "Database name"
    '
    'TxtDBName
    '
    Me.TxtDBName.Location = New System.Drawing.Point(100, 12)
    Me.TxtDBName.Name = "TxtDBName"
    Me.TxtDBName.Size = New System.Drawing.Size(126, 20)
    Me.TxtDBName.TabIndex = 24
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LblFilePath)
    Me.GroupBox1.Controls.Add(Me.LnkFilePath)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(12, 101)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(472, 56)
    Me.GroupBox1.TabIndex = 30
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "File Details"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePath.Name = "LblFilePath"
    Me.LblFilePath.Size = New System.Drawing.Size(392, 36)
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
    'FrmAvon
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(529, 209)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtType)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtDBName)
    Me.Controls.Add(Me.BtnConvert)
    Me.Name = "FrmAvon"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Convert Assessment Payments"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents BtnConvert As System.Windows.Forms.Button
  Friend WithEvents ErrProv As ErrorProvider
  Friend WithEvents OpenFileDialog1 As OpenFileDialog
  Friend WithEvents Label4 As Label
  Friend WithEvents TxtType As TextBox
  Friend WithEvents Label3 As Label
  Friend WithEvents TxtYear As TextBox
  Friend WithEvents Label2 As Label
  Friend WithEvents TxtDBName As TextBox
  Friend WithEvents GroupBox1 As GroupBox
  Friend WithEvents LblFilePath As Label
  Friend WithEvents LnkFilePath As LinkLabel
End Class
