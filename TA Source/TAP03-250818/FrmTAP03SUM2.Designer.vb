<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTAP03SUM2
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
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtDeprValue = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.LblAssrNet = New System.Windows.Forms.Label()
    Me.LblCode = New System.Windows.Forms.Label()
    Me.LblDesc = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.LblListNo.Size = New System.Drawing.Size(61, 18)
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
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(5, 43)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(32, 13)
    Me.Label1.TabIndex = 215
    Me.Label1.Text = "Code"
    '
    'TxtDeprValue
    '
    Me.TxtDeprValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDeprValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDeprValue.Location = New System.Drawing.Point(249, 59)
    Me.TxtDeprValue.MaxLength = 9
    Me.TxtDeprValue.Name = "TxtDeprValue"
    Me.TxtDeprValue.Size = New System.Drawing.Size(85, 20)
    Me.TxtDeprValue.TabIndex = 222
    Me.TxtDeprValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(259, 43)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(60, 13)
    Me.Label5.TabIndex = 223
    Me.Label5.Text = "Depr Value"
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(350, 43)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(47, 13)
    Me.Label9.TabIndex = 231
    Me.Label9.Text = "Assr Net"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblAssrNet
    '
    Me.LblAssrNet.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAssrNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAssrNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAssrNet.Location = New System.Drawing.Point(340, 61)
    Me.LblAssrNet.Name = "LblAssrNet"
    Me.LblAssrNet.Size = New System.Drawing.Size(88, 18)
    Me.LblAssrNet.TabIndex = 233
    Me.LblAssrNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCode
    '
    Me.LblCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCode.Location = New System.Drawing.Point(8, 61)
    Me.LblCode.Name = "LblCode"
    Me.LblCode.Size = New System.Drawing.Size(29, 18)
    Me.LblCode.TabIndex = 234
    Me.LblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblDesc
    '
    Me.LblDesc.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDesc.Location = New System.Drawing.Point(43, 61)
    Me.LblDesc.Name = "LblDesc"
    Me.LblDesc.Size = New System.Drawing.Size(200, 18)
    Me.LblDesc.TabIndex = 236
    Me.LblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(43, 43)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(60, 13)
    Me.Label3.TabIndex = 235
    Me.Label3.Text = "Description"
    '
    'FrmTAP03SUM2
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(437, 87)
    Me.ControlBox = False
    Me.Controls.Add(Me.LblDesc)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.LblCode)
    Me.Controls.Add(Me.LblAssrNet)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.TxtDeprValue)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.LblListNo)
    Me.Controls.Add(Me.Label30)
    Me.Controls.Add(Me.Label29)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAP03SUM2"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Maintain Summary Information"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
    Friend WithEvents LblYear As System.Windows.Forms.Label
    Friend WithEvents LblListNo As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtDeprValue As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents LblAssrNet As System.Windows.Forms.Label
    Friend WithEvents LblCode As System.Windows.Forms.Label
    Friend WithEvents LblDesc As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class






