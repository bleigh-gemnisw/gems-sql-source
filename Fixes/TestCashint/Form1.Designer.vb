<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.BtnCheck = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtList = New System.Windows.Forms.TextBox()
        Me.TxtType = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtYear = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtDBName = New System.Windows.Forms.TextBox()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblBond = New System.Windows.Forms.Label()
        Me.LblDue = New System.Windows.Forms.Label()
        Me.LblLien = New System.Windows.Forms.Label()
        Me.LblInterest = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.label27 = New System.Windows.Forms.Label()
        Me.label26 = New System.Windows.Forms.Label()
        Me.label25 = New System.Windows.Forms.Label()
        Me.label24 = New System.Windows.Forms.Label()
        Me.LblTax = New System.Windows.Forms.Label()
        Me.LblFee = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.DtPckInt = New System.Windows.Forms.DateTimePicker()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnCheck
        '
        Me.BtnCheck.Location = New System.Drawing.Point(163, 58)
        Me.BtnCheck.Name = "BtnCheck"
        Me.BtnCheck.Size = New System.Drawing.Size(50, 20)
        Me.BtnCheck.TabIndex = 0
        Me.BtnCheck.Text = "Check"
        Me.BtnCheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCheck.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(69, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "List#"
        '
        'TxtList
        '
        Me.TxtList.Location = New System.Drawing.Point(100, 59)
        Me.TxtList.MaxLength = 17
        Me.TxtList.Name = "TxtList"
        Me.TxtList.Size = New System.Drawing.Size(57, 20)
        Me.TxtList.TabIndex = 2
        '
        'TxtType
        '
        Me.TxtType.Location = New System.Drawing.Point(100, 82)
        Me.TxtType.MaxLength = 17
        Me.TxtType.Name = "TxtType"
        Me.TxtType.Size = New System.Drawing.Size(23, 20)
        Me.TxtType.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(69, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Type"
        '
        'TxtYear
        '
        Me.TxtYear.Location = New System.Drawing.Point(100, 105)
        Me.TxtYear.MaxLength = 17
        Me.TxtYear.Name = "TxtYear"
        Me.TxtYear.Size = New System.Drawing.Size(37, 20)
        Me.TxtYear.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(69, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Year"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Database name"
        '
        'TxtDBName
        '
        Me.TxtDBName.Location = New System.Drawing.Point(100, 17)
        Me.TxtDBName.Name = "TxtDBName"
        Me.TxtDBName.Size = New System.Drawing.Size(126, 20)
        Me.TxtDBName.TabIndex = 7
        '
        'groupBox2
        '
        Me.groupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.groupBox2.Controls.Add(Me.Label11)
        Me.groupBox2.Controls.Add(Me.LblBond)
        Me.groupBox2.Controls.Add(Me.LblDue)
        Me.groupBox2.Controls.Add(Me.LblLien)
        Me.groupBox2.Controls.Add(Me.LblInterest)
        Me.groupBox2.Controls.Add(Me.Label21)
        Me.groupBox2.Controls.Add(Me.label27)
        Me.groupBox2.Controls.Add(Me.label26)
        Me.groupBox2.Controls.Add(Me.label25)
        Me.groupBox2.Controls.Add(Me.label24)
        Me.groupBox2.Controls.Add(Me.LblTax)
        Me.groupBox2.Controls.Add(Me.LblFee)
        Me.groupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox2.Location = New System.Drawing.Point(248, 12)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(160, 141)
        Me.groupBox2.TabIndex = 138
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Amt Due as of Int Date"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 97)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 166
        Me.Label11.Text = "Bond Int"
        '
        'LblBond
        '
        Me.LblBond.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblBond.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblBond.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBond.Location = New System.Drawing.Point(64, 96)
        Me.LblBond.Name = "LblBond"
        Me.LblBond.Size = New System.Drawing.Size(72, 20)
        Me.LblBond.TabIndex = 167
        Me.LblBond.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblDue
        '
        Me.LblDue.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblDue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDue.Location = New System.Drawing.Point(64, 116)
        Me.LblDue.Name = "LblDue"
        Me.LblDue.Size = New System.Drawing.Size(72, 20)
        Me.LblDue.TabIndex = 165
        Me.LblDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblLien
        '
        Me.LblLien.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblLien.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblLien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLien.Location = New System.Drawing.Point(64, 76)
        Me.LblLien.Name = "LblLien"
        Me.LblLien.Size = New System.Drawing.Size(72, 20)
        Me.LblLien.TabIndex = 164
        Me.LblLien.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblInterest
        '
        Me.LblInterest.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblInterest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInterest.Location = New System.Drawing.Point(64, 36)
        Me.LblInterest.Name = "LblInterest"
        Me.LblInterest.Size = New System.Drawing.Size(72, 20)
        Me.LblInterest.TabIndex = 163
        Me.LblInterest.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.SystemColors.Control
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(8, 117)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 16)
        Me.Label21.TabIndex = 9
        Me.Label21.Text = "Due"
        '
        'label27
        '
        Me.label27.BackColor = System.Drawing.SystemColors.Control
        Me.label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label27.Location = New System.Drawing.Point(8, 80)
        Me.label27.Name = "label27"
        Me.label27.Size = New System.Drawing.Size(48, 16)
        Me.label27.TabIndex = 7
        Me.label27.Text = "Lien"
        '
        'label26
        '
        Me.label26.BackColor = System.Drawing.SystemColors.Control
        Me.label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label26.Location = New System.Drawing.Point(8, 60)
        Me.label26.Name = "label26"
        Me.label26.Size = New System.Drawing.Size(56, 16)
        Me.label26.TabIndex = 5
        Me.label26.Text = "Fee"
        '
        'label25
        '
        Me.label25.BackColor = System.Drawing.SystemColors.Control
        Me.label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label25.Location = New System.Drawing.Point(8, 40)
        Me.label25.Name = "label25"
        Me.label25.Size = New System.Drawing.Size(48, 16)
        Me.label25.TabIndex = 3
        Me.label25.Text = "Interest"
        '
        'label24
        '
        Me.label24.BackColor = System.Drawing.SystemColors.Control
        Me.label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label24.Location = New System.Drawing.Point(8, 20)
        Me.label24.Name = "label24"
        Me.label24.Size = New System.Drawing.Size(48, 16)
        Me.label24.TabIndex = 0
        Me.label24.Text = "Tax"
        '
        'LblTax
        '
        Me.LblTax.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblTax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTax.Location = New System.Drawing.Point(64, 16)
        Me.LblTax.Name = "LblTax"
        Me.LblTax.Size = New System.Drawing.Size(72, 20)
        Me.LblTax.TabIndex = 162
        Me.LblTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblFee
        '
        Me.LblFee.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblFee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFee.Location = New System.Drawing.Point(64, 56)
        Me.LblFee.Name = "LblFee"
        Me.LblFee.Size = New System.Drawing.Size(72, 20)
        Me.LblFee.TabIndex = 163
        Me.LblFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(26, 132)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(72, 16)
        Me.Label34.TabIndex = 165
        Me.Label34.Text = "Interest Date"
        '
        'DtPckInt
        '
        Me.DtPckInt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckInt.Location = New System.Drawing.Point(98, 132)
        Me.DtPckInt.Name = "DtPckInt"
        Me.DtPckInt.ShowCheckBox = True
        Me.DtPckInt.Size = New System.Drawing.Size(96, 20)
        Me.DtPckInt.TabIndex = 164
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 172)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.DtPckInt)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtDBName)
        Me.Controls.Add(Me.TxtYear)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtList)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnCheck)
        Me.Name = "Form1"
        Me.Text = "Test Cashint"
        Me.groupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnCheck As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtList As TextBox
    Friend WithEvents TxtType As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtYear As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtDBName As TextBox
    Friend WithEvents groupBox2 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents LblBond As Label
    Friend WithEvents LblDue As Label
    Friend WithEvents LblLien As Label
    Friend WithEvents LblInterest As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents label27 As Label
    Friend WithEvents label26 As Label
    Friend WithEvents label25 As Label
    Friend WithEvents label24 As Label
    Friend WithEvents LblTax As Label
    Friend WithEvents LblFee As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents DtPckInt As DateTimePicker
End Class
