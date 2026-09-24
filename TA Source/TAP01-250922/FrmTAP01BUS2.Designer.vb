<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTAP01BUS2
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
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label15 = New System.Windows.Forms.Label()
    Me.TxtZip4 = New System.Windows.Forms.TextBox()
    Me.TxtZip5 = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtAddr = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.LblOwname = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblYear.Location = New System.Drawing.Point(171, 6)
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
    Me.LblListNo.Location = New System.Drawing.Point(58, 6)
    Me.LblListNo.Name = "LblListNo"
    Me.LblListNo.Size = New System.Drawing.Size(58, 18)
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
    Me.Label29.Location = New System.Drawing.Point(134, 7)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(35, 17)
    Me.Label29.TabIndex = 212
    Me.Label29.Text = "Year"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label15
    '
    Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label15.Location = New System.Drawing.Point(12, 74)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(80, 16)
    Me.Label15.TabIndex = 222
    Me.Label15.Text = "Address"
    '
    'TxtZip4
    '
    Me.TxtZip4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip4.Location = New System.Drawing.Point(425, 94)
    Me.TxtZip4.MaxLength = 4
    Me.TxtZip4.Name = "TxtZip4"
    Me.TxtZip4.Size = New System.Drawing.Size(32, 20)
    Me.TxtZip4.TabIndex = 219
    '
    'TxtZip5
    '
    Me.TxtZip5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip5.Location = New System.Drawing.Point(377, 94)
    Me.TxtZip5.MaxLength = 5
    Me.TxtZip5.Name = "TxtZip5"
    Me.TxtZip5.Size = New System.Drawing.Size(40, 20)
    Me.TxtZip5.TabIndex = 218
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(12, 98)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(80, 16)
    Me.Label4.TabIndex = 221
    Me.Label4.Text = "City/State/Zip"
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(12, 49)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(80, 16)
    Me.Label3.TabIndex = 220
    Me.Label3.Text = "Name"
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(102, 94)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(232, 20)
    Me.TxtCity.TabIndex = 216
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(345, 94)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 20)
    Me.TxtState.TabIndex = 217
    '
    'TxtAddr
    '
    Me.TxtAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAddr.Location = New System.Drawing.Point(102, 70)
    Me.TxtAddr.MaxLength = 35
    Me.TxtAddr.Name = "TxtAddr"
    Me.TxtAddr.Size = New System.Drawing.Size(280, 20)
    Me.TxtAddr.TabIndex = 215
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(102, 46)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(280, 20)
    Me.TxtName.TabIndex = 214
    '
    'LblOwname
    '
    Me.LblOwname.AutoSize = True
    Me.LblOwname.Location = New System.Drawing.Point(210, 9)
    Me.LblOwname.Name = "LblOwname"
    Me.LblOwname.Size = New System.Drawing.Size(81, 13)
    Me.LblOwname.TabIndex = 225
    Me.LblOwname.Text = "<Owner Name>"
    '
    'FrmTAP01BUS2
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(471, 129)
    Me.ControlBox = False
    Me.Controls.Add(Me.LblOwname)
    Me.Controls.Add(Me.Label15)
    Me.Controls.Add(Me.TxtZip4)
    Me.Controls.Add(Me.TxtZip5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtCity)
    Me.Controls.Add(Me.TxtState)
    Me.Controls.Add(Me.TxtAddr)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.LblListNo)
    Me.Controls.Add(Me.Label30)
    Me.Controls.Add(Me.Label29)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAP01BUS2"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Maintain Other Business Operations"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents LblYear As System.Windows.Forms.Label
    Friend WithEvents LblListNo As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtZip4 As System.Windows.Forms.TextBox
    Friend WithEvents TxtZip5 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCity As System.Windows.Forms.TextBox
    Friend WithEvents TxtState As System.Windows.Forms.TextBox
    Friend WithEvents TxtAddr As System.Windows.Forms.TextBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents LblOwname As Label
End Class






