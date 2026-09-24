<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuPK
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
    Me.tabPK = New System.Windows.Forms.TabPage()
    Me.BtnPK230 = New System.Windows.Forms.Button()
    Me.BtnPK112 = New System.Windows.Forms.Button()
    Me.BtnPK220 = New System.Windows.Forms.Button()
    Me.BtnPK200 = New System.Windows.Forms.Button()
    Me.BtnPK120 = New System.Windows.Forms.Button()
    Me.BtnPK111 = New System.Windows.Forms.Button()
    Me.BtnPK110 = New System.Windows.Forms.Button()
    Me.BtnPK100 = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.tab.SuspendLayout()
    Me.tabPK.SuspendLayout()
    Me.SuspendLayout()
    '
    'tab
    '
    Me.tab.Appearance = System.Windows.Forms.TabAppearance.Buttons
    Me.tab.Controls.Add(Me.tabPK)
    Me.tab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.tab.Location = New System.Drawing.Point(17, 59)
    Me.tab.Multiline = True
    Me.tab.Name = "tab"
    Me.tab.SelectedIndex = 0
    Me.tab.Size = New System.Drawing.Size(486, 305)
    Me.tab.TabIndex = 15
    '
    'tabPK
    '
    Me.tabPK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.tabPK.Controls.Add(Me.BtnPK230)
    Me.tabPK.Controls.Add(Me.BtnPK112)
    Me.tabPK.Controls.Add(Me.BtnPK220)
    Me.tabPK.Controls.Add(Me.BtnPK200)
    Me.tabPK.Controls.Add(Me.BtnPK120)
    Me.tabPK.Controls.Add(Me.BtnPK111)
    Me.tabPK.Controls.Add(Me.BtnPK110)
    Me.tabPK.Controls.Add(Me.BtnPK100)
    Me.tabPK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.tabPK.Location = New System.Drawing.Point(4, 27)
    Me.tabPK.Name = "tabPK"
    Me.tabPK.Size = New System.Drawing.Size(478, 274)
    Me.tabPK.TabIndex = 0
    Me.tabPK.Text = "Main"
    Me.tabPK.UseVisualStyleBackColor = True
    '
    'BtnPK230
    '
    Me.BtnPK230.Location = New System.Drawing.Point(57, 225)
    Me.BtnPK230.Name = "BtnPK230"
    Me.BtnPK230.Size = New System.Drawing.Size(312, 24)
    Me.BtnPK230.TabIndex = 11
    Me.BtnPK230.Text = "Print Parking Delinquent Notices"
    '
    'BtnPK112
    '
    Me.BtnPK112.Location = New System.Drawing.Point(57, 105)
    Me.BtnPK112.Name = "BtnPK112"
    Me.BtnPK112.Size = New System.Drawing.Size(312, 24)
    Me.BtnPK112.TabIndex = 10
    Me.BtnPK112.Text = "Maintain Control File"
    '
    'BtnPK220
    '
    Me.BtnPK220.Location = New System.Drawing.Point(57, 195)
    Me.BtnPK220.Name = "BtnPK220"
    Me.BtnPK220.Size = New System.Drawing.Size(312, 24)
    Me.BtnPK220.TabIndex = 9
    Me.BtnPK220.Text = "Print Parking Receipts"
    '
    'BtnPK200
    '
    Me.BtnPK200.Location = New System.Drawing.Point(57, 165)
    Me.BtnPK200.Name = "BtnPK200"
    Me.BtnPK200.Size = New System.Drawing.Size(312, 24)
    Me.BtnPK200.TabIndex = 8
    Me.BtnPK200.Text = "Print Parking Tickets"
    '
    'BtnPK120
    '
    Me.BtnPK120.Location = New System.Drawing.Point(57, 135)
    Me.BtnPK120.Name = "BtnPK120"
    Me.BtnPK120.Size = New System.Drawing.Size(312, 24)
    Me.BtnPK120.TabIndex = 7
    Me.BtnPK120.Text = "Maintain Parking Receipts"
    '
    'BtnPK111
    '
    Me.BtnPK111.Location = New System.Drawing.Point(57, 75)
    Me.BtnPK111.Name = "BtnPK111"
    Me.BtnPK111.Size = New System.Drawing.Size(312, 24)
    Me.BtnPK111.TabIndex = 6
    Me.BtnPK111.Text = "Maintain Officers"
    '
    'BtnPK110
    '
    Me.BtnPK110.Location = New System.Drawing.Point(57, 45)
    Me.BtnPK110.Name = "BtnPK110"
    Me.BtnPK110.Size = New System.Drawing.Size(312, 24)
    Me.BtnPK110.TabIndex = 3
    Me.BtnPK110.Text = "Maintain Violations"
    '
    'BtnPK100
    '
    Me.BtnPK100.Location = New System.Drawing.Point(57, 15)
    Me.BtnPK100.Name = "BtnPK100"
    Me.BtnPK100.Size = New System.Drawing.Size(312, 24)
    Me.BtnPK100.TabIndex = 0
    Me.BtnPK100.Text = "Maintain Parking Tickets"
    '
    'Label2
    '
    Me.Label2.BackColor = System.Drawing.SystemColors.Control
    Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.Label2.Font = New System.Drawing.Font("Cooper Black", 21.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.ForeColor = System.Drawing.Color.Black
    Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.Label2.ImageIndex = 4
    Me.Label2.Location = New System.Drawing.Point(11, 9)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(492, 40)
    Me.Label2.TabIndex = 16
    Me.Label2.Text = "Parking Tickets"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'FrmMenuPK
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(513, 376)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.tab)
    Me.Name = "FrmMenuPK"
    Me.tab.ResumeLayout(False)
    Me.tabPK.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents tab As System.Windows.Forms.TabControl
  Friend WithEvents tabPK As System.Windows.Forms.TabPage
  Friend WithEvents BtnPK100 As System.Windows.Forms.Button
  Friend WithEvents BtnPK110 As System.Windows.Forms.Button
  Friend WithEvents BtnPK120 As System.Windows.Forms.Button
  Friend WithEvents BtnPK111 As System.Windows.Forms.Button
  Friend WithEvents BtnPK220 As System.Windows.Forms.Button
  Friend WithEvents BtnPK200 As System.Windows.Forms.Button
  Friend WithEvents BtnPK230 As System.Windows.Forms.Button
  Friend WithEvents BtnPK112 As System.Windows.Forms.Button
  Friend WithEvents Label2 As Label
End Class
