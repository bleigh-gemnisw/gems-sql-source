<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuBD
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
    Me.tab = New System.Windows.Forms.TabControl()
    Me.tabBD = New System.Windows.Forms.TabPage()
    Me.BtnBD104 = New System.Windows.Forms.Button()
    Me.BtnBD103 = New System.Windows.Forms.Button()
    Me.BtnBD102 = New System.Windows.Forms.Button()
    Me.BtnBD202 = New System.Windows.Forms.Button()
    Me.BtnBD201 = New System.Windows.Forms.Button()
    Me.BtnBD101 = New System.Windows.Forms.Button()
    Me.BtnBD200 = New System.Windows.Forms.Button()
    Me.BtnBD001 = New System.Windows.Forms.Button()
    Me.BtnBD100 = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.tab.SuspendLayout()
    Me.tabBD.SuspendLayout()
    Me.SuspendLayout()
    '
    'tab
    '
    Me.tab.Appearance = System.Windows.Forms.TabAppearance.Buttons
    Me.tab.Controls.Add(Me.tabBD)
    Me.tab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.tab.Location = New System.Drawing.Point(17, 59)
    Me.tab.Multiline = True
    Me.tab.Name = "tab"
    Me.tab.SelectedIndex = 0
    Me.tab.Size = New System.Drawing.Size(486, 324)
    Me.tab.TabIndex = 15
    '
    'tabBD
    '
    Me.tabBD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.tabBD.Controls.Add(Me.BtnBD104)
    Me.tabBD.Controls.Add(Me.BtnBD103)
    Me.tabBD.Controls.Add(Me.BtnBD102)
    Me.tabBD.Controls.Add(Me.BtnBD202)
    Me.tabBD.Controls.Add(Me.BtnBD201)
    Me.tabBD.Controls.Add(Me.BtnBD101)
    Me.tabBD.Controls.Add(Me.BtnBD200)
    Me.tabBD.Controls.Add(Me.BtnBD001)
    Me.tabBD.Controls.Add(Me.BtnBD100)
    Me.tabBD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.tabBD.Location = New System.Drawing.Point(4, 27)
    Me.tabBD.Name = "tabBD"
    Me.tabBD.Size = New System.Drawing.Size(478, 293)
    Me.tabBD.TabIndex = 0
    Me.tabBD.Text = "Building Dept"
    Me.tabBD.UseVisualStyleBackColor = True
    '
    'BtnBD104
    '
    Me.BtnBD104.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnBD104.Location = New System.Drawing.Point(56, 172)
    Me.BtnBD104.Name = "BtnBD104"
    Me.BtnBD104.Size = New System.Drawing.Size(312, 24)
    Me.BtnBD104.TabIndex = 23
    Me.BtnBD104.Text = "Credit Card Provider "
    '
    'BtnBD103
    '
    Me.BtnBD103.Location = New System.Drawing.Point(56, 142)
    Me.BtnBD103.Name = "BtnBD103"
    Me.BtnBD103.Size = New System.Drawing.Size(312, 24)
    Me.BtnBD103.TabIndex = 7
    Me.BtnBD103.Text = "Maintain Contractor File"
    '
    'BtnBD102
    '
    Me.BtnBD102.Location = New System.Drawing.Point(56, 112)
    Me.BtnBD102.Name = "BtnBD102"
    Me.BtnBD102.Size = New System.Drawing.Size(312, 24)
    Me.BtnBD102.TabIndex = 6
    Me.BtnBD102.Text = "Maintain Control File"
    '
    'BtnBD202
    '
    Me.BtnBD202.Location = New System.Drawing.Point(56, 231)
    Me.BtnBD202.Name = "BtnBD202"
    Me.BtnBD202.Size = New System.Drawing.Size(312, 24)
    Me.BtnBD202.TabIndex = 5
    Me.BtnBD202.Text = "Print Permit Report"
    '
    'BtnBD201
    '
    Me.BtnBD201.Location = New System.Drawing.Point(56, 261)
    Me.BtnBD201.Name = "BtnBD201"
    Me.BtnBD201.Size = New System.Drawing.Size(312, 24)
    Me.BtnBD201.TabIndex = 4
    Me.BtnBD201.Text = "Print Missing Inspections"
    '
    'BtnBD101
    '
    Me.BtnBD101.Location = New System.Drawing.Point(56, 82)
    Me.BtnBD101.Name = "BtnBD101"
    Me.BtnBD101.Size = New System.Drawing.Size(312, 24)
    Me.BtnBD101.TabIndex = 3
    Me.BtnBD101.Text = "Maintain Check Endorsement"
    '
    'BtnBD200
    '
    Me.BtnBD200.Location = New System.Drawing.Point(56, 201)
    Me.BtnBD200.Name = "BtnBD200"
    Me.BtnBD200.Size = New System.Drawing.Size(312, 24)
    Me.BtnBD200.TabIndex = 2
    Me.BtnBD200.Text = "Print Permit Receipts Report"
    '
    'BtnBD001
    '
    Me.BtnBD001.Location = New System.Drawing.Point(56, 22)
    Me.BtnBD001.Name = "BtnBD001"
    Me.BtnBD001.Size = New System.Drawing.Size(312, 24)
    Me.BtnBD001.TabIndex = 1
    Me.BtnBD001.Text = "Maintain Master File"
    '
    'BtnBD100
    '
    Me.BtnBD100.Location = New System.Drawing.Point(56, 52)
    Me.BtnBD100.Name = "BtnBD100"
    Me.BtnBD100.Size = New System.Drawing.Size(312, 24)
    Me.BtnBD100.TabIndex = 0
    Me.BtnBD100.Text = "Maintain Rate Codes"
    '
    'Label1
    '
    Me.Label1.BackColor = System.Drawing.SystemColors.Control
    Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.Label1.Font = New System.Drawing.Font("Cooper Black", 21.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.ForeColor = System.Drawing.Color.Black
    Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.Label1.ImageIndex = 4
    Me.Label1.Location = New System.Drawing.Point(11, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(490, 40)
    Me.Label1.TabIndex = 16
    Me.Label1.Text = "Building Dept."
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'FrmMenuBD
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(513, 395)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.tab)
    Me.Name = "FrmMenuBD"
    Me.tab.ResumeLayout(False)
    Me.tabBD.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents tab As System.Windows.Forms.TabControl
  Friend WithEvents tabBD As System.Windows.Forms.TabPage
  Friend WithEvents BtnBD200 As System.Windows.Forms.Button
  Friend WithEvents BtnBD001 As System.Windows.Forms.Button
  Friend WithEvents BtnBD100 As System.Windows.Forms.Button
  Friend WithEvents BtnBD101 As System.Windows.Forms.Button
  Friend WithEvents BtnBD201 As System.Windows.Forms.Button
  Friend WithEvents BtnBD202 As System.Windows.Forms.Button
  Friend WithEvents BtnBD103 As System.Windows.Forms.Button
  Friend WithEvents BtnBD102 As System.Windows.Forms.Button
  Friend WithEvents BtnBD104 As System.Windows.Forms.Button
  Friend WithEvents Label1 As Label
End Class
