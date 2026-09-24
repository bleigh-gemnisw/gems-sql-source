<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuPS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenuPS))
Me.tab = New System.Windows.Forms.TabControl
Me.tabPS = New System.Windows.Forms.TabPage
Me.BtnPS003 = New System.Windows.Forms.Button
Me.BtnPS002 = New System.Windows.Forms.Button
Me.BtnPS001 = New System.Windows.Forms.Button
Me.label10 = New System.Windows.Forms.Label
Me.BtnPS004 = New System.Windows.Forms.Button
Me.tab.SuspendLayout()
Me.tabPS.SuspendLayout()
Me.SuspendLayout()
'
'tab
'
Me.tab.Appearance = System.Windows.Forms.TabAppearance.Buttons
Me.tab.Controls.Add(Me.tabPS)
Me.tab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.tab.Location = New System.Drawing.Point(34, 57)
Me.tab.Multiline = True
Me.tab.Name = "tab"
Me.tab.SelectedIndex = 0
Me.tab.Size = New System.Drawing.Size(486, 305)
Me.tab.TabIndex = 12
'
'tabPS
'
Me.tabPS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.tabPS.Controls.Add(Me.BtnPS004)
Me.tabPS.Controls.Add(Me.BtnPS003)
Me.tabPS.Controls.Add(Me.BtnPS002)
Me.tabPS.Controls.Add(Me.BtnPS001)
Me.tabPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.tabPS.Location = New System.Drawing.Point(4, 27)
Me.tabPS.Name = "tabPS"
Me.tabPS.Size = New System.Drawing.Size(478, 274)
Me.tabPS.TabIndex = 0
Me.tabPS.Text = "Main"
Me.tabPS.UseVisualStyleBackColor = True
'
'BtnPS003
'
Me.BtnPS003.Location = New System.Drawing.Point(75, 100)
Me.BtnPS003.Name = "BtnPS003"
Me.BtnPS003.Size = New System.Drawing.Size(312, 24)
Me.BtnPS003.TabIndex = 3
Me.BtnPS003.Text = "Print Collection Report"
'
'BtnPS002
'
Me.BtnPS002.Location = New System.Drawing.Point(75, 70)
Me.BtnPS002.Name = "BtnPS002"
Me.BtnPS002.Size = New System.Drawing.Size(312, 24)
Me.BtnPS002.TabIndex = 2
Me.BtnPS002.Text = "Maintain Parking Stickers"
'
'BtnPS001
'
Me.BtnPS001.Location = New System.Drawing.Point(75, 40)
Me.BtnPS001.Name = "BtnPS001"
Me.BtnPS001.Size = New System.Drawing.Size(312, 24)
Me.BtnPS001.TabIndex = 1
Me.BtnPS001.Text = "Maintain Parking Sticker Category"
'
'label10
'
Me.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label10.ForeColor = System.Drawing.Color.Maroon
Me.label10.Image = CType(resources.GetObject("label10.Image"), System.Drawing.Image)
Me.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.label10.Location = New System.Drawing.Point(8, 9)
Me.label10.Name = "label10"
Me.label10.Size = New System.Drawing.Size(512, 40)
Me.label10.TabIndex = 13
'
'BtnPS004
'
Me.BtnPS004.Location = New System.Drawing.Point(75, 130)
Me.BtnPS004.Name = "BtnPS004"
Me.BtnPS004.Size = New System.Drawing.Size(312, 24)
Me.BtnPS004.TabIndex = 4
Me.BtnPS004.Text = "Parking Sticker Listing"
'
'FrmMenuPS
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(539, 371)
Me.Controls.Add(Me.label10)
Me.Controls.Add(Me.tab)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.KeyPreview = True
Me.MaximizeBox = False
Me.Name = "FrmMenuPS"
Me.tab.ResumeLayout(False)
Me.tabPS.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub
    Friend WithEvents tab As System.Windows.Forms.TabControl
    Friend WithEvents tabPS As System.Windows.Forms.TabPage
    Friend WithEvents label10 As System.Windows.Forms.Label
    Friend WithEvents BtnPS003 As System.Windows.Forms.Button
    Friend WithEvents BtnPS002 As System.Windows.Forms.Button
    Friend WithEvents BtnPS001 As System.Windows.Forms.Button
    Friend WithEvents BtnPS004 As System.Windows.Forms.Button
End Class
