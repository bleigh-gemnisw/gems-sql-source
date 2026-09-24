<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTAP01ASS2
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
    Me.TxtDesc = New System.Windows.Forms.TextBox()
    Me.TxtAcqCst = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.LnkCode = New System.Windows.Forms.LinkLabel()
    Me.TxtCode = New System.Windows.Forms.TextBox()
    Me.TxtLtr = New System.Windows.Forms.TextBox()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.DtPckAcq = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LblOwname = New System.Windows.Forms.Label()
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
    Me.LblListNo.Size = New System.Drawing.Size(71, 18)
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
    'TxtDesc
    '
    Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDesc.Location = New System.Drawing.Point(80, 56)
    Me.TxtDesc.MaxLength = 40
    Me.TxtDesc.Name = "TxtDesc"
    Me.TxtDesc.Size = New System.Drawing.Size(294, 20)
    Me.TxtDesc.TabIndex = 3
    '
    'TxtAcqCst
    '
    Me.TxtAcqCst.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAcqCst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAcqCst.Location = New System.Drawing.Point(484, 54)
    Me.TxtAcqCst.MaxLength = 9
    Me.TxtAcqCst.Name = "TxtAcqCst"
    Me.TxtAcqCst.Size = New System.Drawing.Size(73, 20)
    Me.TxtAcqCst.TabIndex = 5
    Me.TxtAcqCst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(481, 38)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(80, 13)
    Me.Label9.TabIndex = 231
    Me.Label9.Text = "Acquistion Cost"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LnkCode
    '
    Me.LnkCode.Location = New System.Drawing.Point(12, 40)
    Me.LnkCode.Name = "LnkCode"
    Me.LnkCode.Size = New System.Drawing.Size(37, 16)
    Me.LnkCode.TabIndex = 236
    Me.LnkCode.TabStop = True
    Me.LnkCode.Text = "Code"
    '
    'TxtCode
    '
    Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode.Location = New System.Drawing.Point(14, 56)
    Me.TxtCode.MaxLength = 3
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(32, 20)
    Me.TxtCode.TabIndex = 1
    '
    'TxtLtr
    '
    Me.TxtLtr.Location = New System.Drawing.Point(52, 56)
    Me.TxtLtr.MaxLength = 1
    Me.TxtLtr.Name = "TxtLtr"
    Me.TxtLtr.Size = New System.Drawing.Size(22, 20)
    Me.TxtLtr.TabIndex = 2
    '
    'Label24
    '
    Me.Label24.AutoSize = True
    Me.Label24.Location = New System.Drawing.Point(55, 42)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(19, 13)
    Me.Label24.TabIndex = 237
    Me.Label24.Text = "Ltr"
    '
    'DtPckAcq
    '
    Me.DtPckAcq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckAcq.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckAcq.Location = New System.Drawing.Point(381, 54)
    Me.DtPckAcq.Name = "DtPckAcq"
    Me.DtPckAcq.Size = New System.Drawing.Size(97, 22)
    Me.DtPckAcq.TabIndex = 4
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(381, 40)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(75, 13)
    Me.Label2.TabIndex = 239
    Me.Label2.Text = "Date Acquired"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(80, 42)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(60, 13)
    Me.Label3.TabIndex = 241
    Me.Label3.Text = "Description"
    '
    'LblOwname
    '
    Me.LblOwname.AutoSize = True
    Me.LblOwname.Location = New System.Drawing.Point(241, 11)
    Me.LblOwname.Name = "LblOwname"
    Me.LblOwname.Size = New System.Drawing.Size(81, 13)
    Me.LblOwname.TabIndex = 242
    Me.LblOwname.Text = "<Owner Name>"
    '
    'FrmTAP01ASS2
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(573, 92)
    Me.ControlBox = False
    Me.Controls.Add(Me.LblOwname)
    Me.Controls.Add(Me.TxtDesc)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.DtPckAcq)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtLtr)
    Me.Controls.Add(Me.Label24)
    Me.Controls.Add(Me.LnkCode)
    Me.Controls.Add(Me.TxtCode)
    Me.Controls.Add(Me.TxtAcqCst)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.LblListNo)
    Me.Controls.Add(Me.Label30)
    Me.Controls.Add(Me.Label29)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAP01ASS2"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Maintain Asset"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents LblYear As System.Windows.Forms.Label
    Friend WithEvents LblListNo As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
    Friend WithEvents TxtAcqCst As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents LnkCode As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtCode As System.Windows.Forms.TextBox
    Friend WithEvents DtPckAcq As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtLtr As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents LblOwname As Label
End Class






