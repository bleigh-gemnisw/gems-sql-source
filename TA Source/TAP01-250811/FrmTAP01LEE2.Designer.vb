<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTAP01LEE2
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
        Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.TxtAddr = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtLesNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtDesc = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ChkDspItm = New System.Windows.Forms.CheckBox()
        Me.TxtTerm = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtRent = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtCost = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ChkAcqItm = New System.Windows.Forms.CheckBox()
        Me.TxtSerial = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtYrMfg = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ChkCapLes = New System.Windows.Forms.CheckBox()
        Me.TxtYrInc = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
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
        Me.LblListNo.Size = New System.Drawing.Size(70, 18)
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
        Me.Label1.Location = New System.Drawing.Point(7, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 215
        Me.Label1.Text = "Name of Lessee"
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Location = New System.Drawing.Point(122, 111)
        Me.TxtName.MaxLength = 35
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(228, 20)
        Me.TxtName.TabIndex = 2
        '
        'TxtAddr
        '
        Me.TxtAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAddr.Location = New System.Drawing.Point(122, 137)
        Me.TxtAddr.MaxLength = 35
        Me.TxtAddr.Name = "TxtAddr"
        Me.TxtAddr.Size = New System.Drawing.Size(228, 20)
        Me.TxtAddr.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 235
        Me.Label3.Text = "Lessee Address"
        '
        'TxtLesNo
        '
        Me.TxtLesNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLesNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLesNo.Location = New System.Drawing.Point(122, 163)
        Me.TxtLesNo.MaxLength = 20
        Me.TxtLesNo.Name = "TxtLesNo"
        Me.TxtLesNo.Size = New System.Drawing.Size(132, 20)
        Me.TxtLesNo.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 161)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 237
        Me.Label4.Text = "Lease Number"
        '
        'TxtDesc
        '
        Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDesc.Location = New System.Drawing.Point(122, 189)
        Me.TxtDesc.MaxLength = 50
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.Size = New System.Drawing.Size(359, 20)
        Me.TxtDesc.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 187)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 239
        Me.Label6.Text = "Description"
        '
        'ChkDspItm
        '
        Me.ChkDspItm.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkDspItm.Location = New System.Drawing.Point(12, 40)
        Me.ChkDspItm.Name = "ChkDspItm"
        Me.ChkDspItm.Size = New System.Drawing.Size(232, 24)
        Me.ChkDspItm.TabIndex = 0
        Me.ChkDspItm.Text = "Did you dispose of any leased items?"
        Me.ChkDspItm.UseVisualStyleBackColor = True
        '
        'TxtTerm
        '
        Me.TxtTerm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTerm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTerm.Location = New System.Drawing.Point(120, 294)
        Me.TxtTerm.MaxLength = 35
        Me.TxtTerm.Name = "TxtTerm"
        Me.TxtTerm.Size = New System.Drawing.Size(228, 20)
        Me.TxtTerm.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 294)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 248
        Me.Label8.Text = "Lease Term"
        '
        'TxtRent
        '
        Me.TxtRent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRent.Location = New System.Drawing.Point(119, 317)
        Me.TxtRent.MaxLength = 9
        Me.TxtRent.Name = "TxtRent"
        Me.TxtRent.Size = New System.Drawing.Size(73, 20)
        Me.TxtRent.TabIndex = 10
        Me.TxtRent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(5, 322)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 251
        Me.Label10.Text = "Monthly Rent"
        '
        'TxtCost
        '
        Me.TxtCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCost.Location = New System.Drawing.Point(118, 341)
        Me.TxtCost.MaxLength = 9
        Me.TxtCost.Name = "TxtCost"
        Me.TxtCost.Size = New System.Drawing.Size(73, 20)
        Me.TxtCost.TabIndex = 11
        Me.TxtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(4, 346)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 13)
        Me.Label11.TabIndex = 253
        Me.Label11.Text = "Acquisition Cost"
        '
        'ChkAcqItm
        '
        Me.ChkAcqItm.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkAcqItm.Location = New System.Drawing.Point(12, 70)
        Me.ChkAcqItm.Name = "ChkAcqItm"
        Me.ChkAcqItm.Size = New System.Drawing.Size(232, 24)
        Me.ChkAcqItm.TabIndex = 1
        Me.ChkAcqItm.Text = "Did you acquire any of the leased items?"
        Me.ChkAcqItm.UseVisualStyleBackColor = True
        '
        'TxtSerial
        '
        Me.TxtSerial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSerial.Location = New System.Drawing.Point(122, 215)
        Me.TxtSerial.MaxLength = 20
        Me.TxtSerial.Name = "TxtSerial"
        Me.TxtSerial.Size = New System.Drawing.Size(132, 20)
        Me.TxtSerial.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 213)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 256
        Me.Label2.Text = "Serial Number"
        '
        'TxtYrMfg
        '
        Me.TxtYrMfg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtYrMfg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtYrMfg.Location = New System.Drawing.Point(123, 241)
        Me.TxtYrMfg.MaxLength = 4
        Me.TxtYrMfg.Name = "TxtYrMfg"
        Me.TxtYrMfg.Size = New System.Drawing.Size(34, 20)
        Me.TxtYrMfg.TabIndex = 7
        Me.TxtYrMfg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 244)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 13)
        Me.Label5.TabIndex = 258
        Me.Label5.Text = "Year of manufacture"
        '
        'ChkCapLes
        '
        Me.ChkCapLes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkCapLes.Location = New System.Drawing.Point(10, 267)
        Me.ChkCapLes.Name = "ChkCapLes"
        Me.ChkCapLes.Size = New System.Drawing.Size(129, 24)
        Me.ChkCapLes.TabIndex = 8
        Me.ChkCapLes.Text = "Capital Lease?"
        Me.ChkCapLes.UseVisualStyleBackColor = True
        '
        'TxtYrInc
        '
        Me.TxtYrInc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtYrInc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtYrInc.Location = New System.Drawing.Point(118, 367)
        Me.TxtYrInc.MaxLength = 4
        Me.TxtYrInc.Name = "TxtYrInc"
        Me.TxtYrInc.Size = New System.Drawing.Size(34, 20)
        Me.TxtYrInc.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 368)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 261
        Me.Label7.Text = "Year Included"
        '
        'FrmTAP01LEE2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 398)
        Me.ControlBox = False
        Me.Controls.Add(Me.TxtYrInc)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ChkCapLes)
        Me.Controls.Add(Me.TxtYrMfg)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtSerial)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ChkAcqItm)
        Me.Controls.Add(Me.TxtCost)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtRent)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtTerm)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ChkDspItm)
        Me.Controls.Add(Me.TxtDesc)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtLesNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtAddr)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblYear)
        Me.Controls.Add(Me.LblListNo)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label29)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTAP01LEE2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Maintain Lessee"
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblYear As System.Windows.Forms.Label
    Friend WithEvents LblListNo As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents TxtLesNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtAddr As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ChkDspItm As System.Windows.Forms.CheckBox
    Friend WithEvents TxtCost As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtRent As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtTerm As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ChkAcqItm As System.Windows.Forms.CheckBox
    Friend WithEvents TxtYrMfg As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtSerial As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtYrInc As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ChkCapLes As System.Windows.Forms.CheckBox
End Class






