<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuTS
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
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenuTS))
Me.tab = New System.Windows.Forms.TabControl
Me.tabTS = New System.Windows.Forms.TabPage
Me.BtnTS002 = New System.Windows.Forms.Button
Me.BtnTS001 = New System.Windows.Forms.Button
Me.BtnTS003 = New System.Windows.Forms.Button
Me.BtnTS005 = New System.Windows.Forms.Button
Me.BtnTS006 = New System.Windows.Forms.Button
Me.BtnTS004 = New System.Windows.Forms.Button
Me.label10 = New System.Windows.Forms.Label
Me.Label1 = New System.Windows.Forms.Label
Me.tab.SuspendLayout()
Me.tabTS.SuspendLayout()
Me.SuspendLayout()
'
'tab
'
Me.tab.Appearance = System.Windows.Forms.TabAppearance.Buttons
Me.tab.Controls.Add(Me.tabTS)
Me.tab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.tab.Location = New System.Drawing.Point(34, 57)
Me.tab.Multiline = True
Me.tab.Name = "tab"
Me.tab.SelectedIndex = 0
Me.tab.Size = New System.Drawing.Size(486, 305)
Me.tab.TabIndex = 12
'
'tabTS
'
Me.tabTS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.tabTS.Controls.Add(Me.BtnTS002)
Me.tabTS.Controls.Add(Me.BtnTS001)
Me.tabTS.Controls.Add(Me.BtnTS003)
Me.tabTS.Controls.Add(Me.BtnTS005)
Me.tabTS.Controls.Add(Me.BtnTS006)
Me.tabTS.Controls.Add(Me.BtnTS004)
Me.tabTS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.tabTS.Location = New System.Drawing.Point(4, 27)
Me.tabTS.Name = "tabTS"
Me.tabTS.Size = New System.Drawing.Size(478, 274)
Me.tabTS.TabIndex = 0
Me.tabTS.Text = "Main"
Me.tabTS.UseVisualStyleBackColor = True
'
'BtnTS002
'
Me.BtnTS002.Location = New System.Drawing.Point(81, 118)
Me.BtnTS002.Name = "BtnTS002"
Me.BtnTS002.Size = New System.Drawing.Size(312, 24)
Me.BtnTS002.TabIndex = 5
Me.BtnTS002.Text = "Transfer Station Type"
'
'BtnTS001
'
Me.BtnTS001.Location = New System.Drawing.Point(81, 88)
Me.BtnTS001.Name = "BtnTS001"
Me.BtnTS001.Size = New System.Drawing.Size(312, 24)
Me.BtnTS001.TabIndex = 4
Me.BtnTS001.Text = "Transfer Station Classifications"
'
'BtnTS003
'
Me.BtnTS003.Location = New System.Drawing.Point(81, 58)
Me.BtnTS003.Name = "BtnTS003"
Me.BtnTS003.Size = New System.Drawing.Size(312, 24)
Me.BtnTS003.TabIndex = 3
Me.BtnTS003.Text = "Maintain Transfer Station Pay Type"
'
'BtnTS005
'
Me.BtnTS005.Location = New System.Drawing.Point(81, 148)
Me.BtnTS005.Name = "BtnTS005"
Me.BtnTS005.Size = New System.Drawing.Size(312, 24)
Me.BtnTS005.TabIndex = 2
Me.BtnTS005.Text = "Transfer Station Collection Report"
'
'BtnTS006
'
Me.BtnTS006.Location = New System.Drawing.Point(81, 178)
Me.BtnTS006.Name = "BtnTS006"
Me.BtnTS006.Size = New System.Drawing.Size(312, 24)
Me.BtnTS006.TabIndex = 1
Me.BtnTS006.Text = "Transfer Station Listing"
'
'BtnTS004
'
Me.BtnTS004.Location = New System.Drawing.Point(81, 28)
Me.BtnTS004.Name = "BtnTS004"
Me.BtnTS004.Size = New System.Drawing.Size(312, 24)
Me.BtnTS004.TabIndex = 0
Me.BtnTS004.Text = "Transfer Station Entry"
'
'label10
'
Me.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label10.ForeColor = System.Drawing.Color.Maroon
Me.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.label10.Location = New System.Drawing.Point(8, 9)
Me.label10.Name = "label10"
Me.label10.Size = New System.Drawing.Size(512, 40)
Me.label10.TabIndex = 13
'
'Label1
'
Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.ForeColor = System.Drawing.Color.Maroon
Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.Label1.Location = New System.Drawing.Point(8, 9)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(512, 40)
Me.Label1.TabIndex = 14
'
'FrmMenuTS
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(539, 371)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.label10)
Me.Controls.Add(Me.tab)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.KeyPreview = True
Me.MaximizeBox = False
Me.Name = "FrmMenuTS"
Me.tab.ResumeLayout(False)
Me.tabTS.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub
    Friend WithEvents tab As System.Windows.Forms.TabControl
    Friend WithEvents tabTS As System.Windows.Forms.TabPage
    Friend WithEvents BtnTS004 As System.Windows.Forms.Button
    Friend WithEvents label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnTS001 As System.Windows.Forms.Button
    Friend WithEvents BtnTS003 As System.Windows.Forms.Button
    Friend WithEvents BtnTS005 As System.Windows.Forms.Button
    Friend WithEvents BtnTS006 As System.Windows.Forms.Button
    Friend WithEvents BtnTS002 As System.Windows.Forms.Button
End Class
