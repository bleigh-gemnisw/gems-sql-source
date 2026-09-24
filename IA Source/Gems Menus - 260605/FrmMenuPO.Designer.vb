<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuPO
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
    Me.tab = New System.Windows.Forms.TabControl()
    Me.TpMaintain = New System.Windows.Forms.TabPage()
    Me.BtnPO105 = New System.Windows.Forms.Button()
    Me.BtnPO104 = New System.Windows.Forms.Button()
    Me.BtnPO101 = New System.Windows.Forms.Button()
    Me.BtnPO103 = New System.Windows.Forms.Button()
    Me.TpReq = New System.Windows.Forms.TabPage()
    Me.BtnPO201app = New System.Windows.Forms.Button()
    Me.BtnPO201 = New System.Windows.Forms.Button()
    Me.TpPO = New System.Windows.Forms.TabPage()
    Me.BtnPO310 = New System.Windows.Forms.Button()
    Me.BtnPO320 = New System.Windows.Forms.Button()
    Me.BtnPO306 = New System.Windows.Forms.Button()
    Me.BtnPO303 = New System.Windows.Forms.Button()
    Me.BtnPO301 = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.BtnPO330 = New System.Windows.Forms.Button()
    Me.tab.SuspendLayout()
    Me.TpMaintain.SuspendLayout()
    Me.TpReq.SuspendLayout()
    Me.TpPO.SuspendLayout()
    Me.SuspendLayout()
    '
    'tab
    '
    Me.tab.Appearance = System.Windows.Forms.TabAppearance.Buttons
    Me.tab.Controls.Add(Me.TpMaintain)
    Me.tab.Controls.Add(Me.TpReq)
    Me.tab.Controls.Add(Me.TpPO)
    Me.tab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.tab.Location = New System.Drawing.Point(34, 57)
    Me.tab.Multiline = True
    Me.tab.Name = "tab"
    Me.tab.SelectedIndex = 0
    Me.tab.Size = New System.Drawing.Size(486, 305)
    Me.tab.TabIndex = 12
    '
    'TpMaintain
    '
    Me.TpMaintain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.TpMaintain.Controls.Add(Me.BtnPO105)
    Me.TpMaintain.Controls.Add(Me.BtnPO104)
    Me.TpMaintain.Controls.Add(Me.BtnPO101)
    Me.TpMaintain.Controls.Add(Me.BtnPO103)
    Me.TpMaintain.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TpMaintain.Location = New System.Drawing.Point(4, 27)
    Me.TpMaintain.Name = "TpMaintain"
    Me.TpMaintain.Size = New System.Drawing.Size(478, 274)
    Me.TpMaintain.TabIndex = 0
    Me.TpMaintain.Text = "Maintain"
    Me.TpMaintain.UseVisualStyleBackColor = True
    '
    'BtnPO105
    '
    Me.BtnPO105.Location = New System.Drawing.Point(13, 101)
    Me.BtnPO105.Name = "BtnPO105"
    Me.BtnPO105.Size = New System.Drawing.Size(259, 24)
    Me.BtnPO105.TabIndex = 9
    Me.BtnPO105.Text = "Location Security"
    '
    'BtnPO104
    '
    Me.BtnPO104.Location = New System.Drawing.Point(13, 71)
    Me.BtnPO104.Name = "BtnPO104"
    Me.BtnPO104.Size = New System.Drawing.Size(259, 24)
    Me.BtnPO104.TabIndex = 8
    Me.BtnPO104.Text = "Purchase Order Memo"
    '
    'BtnPO101
    '
    Me.BtnPO101.Location = New System.Drawing.Point(13, 13)
    Me.BtnPO101.Name = "BtnPO101"
    Me.BtnPO101.Size = New System.Drawing.Size(259, 24)
    Me.BtnPO101.TabIndex = 7
    Me.BtnPO101.Text = "Location Master"
    '
    'BtnPO103
    '
    Me.BtnPO103.Location = New System.Drawing.Point(13, 41)
    Me.BtnPO103.Name = "BtnPO103"
    Me.BtnPO103.Size = New System.Drawing.Size(259, 24)
    Me.BtnPO103.TabIndex = 6
    Me.BtnPO103.Text = "Purchase Order Control "
    '
    'TpReq
    '
    Me.TpReq.Controls.Add(Me.BtnPO201app)
    Me.TpReq.Controls.Add(Me.BtnPO201)
    Me.TpReq.Location = New System.Drawing.Point(4, 27)
    Me.TpReq.Name = "TpReq"
    Me.TpReq.Size = New System.Drawing.Size(478, 274)
    Me.TpReq.TabIndex = 1
    Me.TpReq.Text = "Requistions"
    Me.TpReq.UseVisualStyleBackColor = True
    '
    'BtnPO201app
    '
    Me.BtnPO201app.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnPO201app.Location = New System.Drawing.Point(16, 44)
    Me.BtnPO201app.Name = "BtnPO201app"
    Me.BtnPO201app.Size = New System.Drawing.Size(259, 24)
    Me.BtnPO201app.TabIndex = 14
    Me.BtnPO201app.Text = "Approve Requistions"
    '
    'BtnPO201
    '
    Me.BtnPO201.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnPO201.Location = New System.Drawing.Point(16, 14)
    Me.BtnPO201.Name = "BtnPO201"
    Me.BtnPO201.Size = New System.Drawing.Size(259, 24)
    Me.BtnPO201.TabIndex = 13
    Me.BtnPO201.Text = "Maintain Requistions"
    '
    'TpPO
    '
    Me.TpPO.Controls.Add(Me.BtnPO330)
    Me.TpPO.Controls.Add(Me.BtnPO310)
    Me.TpPO.Controls.Add(Me.BtnPO320)
    Me.TpPO.Controls.Add(Me.BtnPO306)
    Me.TpPO.Controls.Add(Me.BtnPO303)
    Me.TpPO.Controls.Add(Me.BtnPO301)
    Me.TpPO.Location = New System.Drawing.Point(4, 27)
    Me.TpPO.Name = "TpPO"
    Me.TpPO.Size = New System.Drawing.Size(478, 274)
    Me.TpPO.TabIndex = 2
    Me.TpPO.Text = "Purchase Orders"
    Me.TpPO.UseVisualStyleBackColor = True
    '
    'BtnPO310
    '
    Me.BtnPO310.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnPO310.Location = New System.Drawing.Point(16, 139)
    Me.BtnPO310.Name = "BtnPO310"
    Me.BtnPO310.Size = New System.Drawing.Size(259, 24)
    Me.BtnPO310.TabIndex = 20
    Me.BtnPO310.Text = "Print Purchase Order By Acct or Dept"
    '
    'BtnPO320
    '
    Me.BtnPO320.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnPO320.Location = New System.Drawing.Point(16, 172)
    Me.BtnPO320.Name = "BtnPO320"
    Me.BtnPO320.Size = New System.Drawing.Size(259, 24)
    Me.BtnPO320.TabIndex = 19
    Me.BtnPO320.Text = "Print Purchase Order Report"
    '
    'BtnPO306
    '
    Me.BtnPO306.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnPO306.Location = New System.Drawing.Point(16, 109)
    Me.BtnPO306.Name = "BtnPO306"
    Me.BtnPO306.Size = New System.Drawing.Size(259, 24)
    Me.BtnPO306.TabIndex = 18
    Me.BtnPO306.Text = "Print Purchase Orders"
    '
    'BtnPO303
    '
    Me.BtnPO303.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnPO303.Location = New System.Drawing.Point(16, 79)
    Me.BtnPO303.Name = "BtnPO303"
    Me.BtnPO303.Size = New System.Drawing.Size(259, 24)
    Me.BtnPO303.TabIndex = 17
    Me.BtnPO303.Text = "Close Purchase Orders"
    '
    'BtnPO301
    '
    Me.BtnPO301.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnPO301.Location = New System.Drawing.Point(16, 19)
    Me.BtnPO301.Name = "BtnPO301"
    Me.BtnPO301.Size = New System.Drawing.Size(259, 24)
    Me.BtnPO301.TabIndex = 16
    Me.BtnPO301.Text = "Maintain Purchase Order Batches"
    '
    'Label2
    '
    Me.Label2.BackColor = System.Drawing.SystemColors.Control
    Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.Label2.Font = New System.Drawing.Font("Cooper Black", 21.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.ForeColor = System.Drawing.Color.Black
    Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.Label2.ImageIndex = 4
    Me.Label2.Location = New System.Drawing.Point(34, 9)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(482, 40)
    Me.Label2.TabIndex = 16
    Me.Label2.Text = "Purchase Orders"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'BtnPO330
    '
    Me.BtnPO330.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnPO330.Location = New System.Drawing.Point(16, 49)
    Me.BtnPO330.Name = "BtnPO330"
    Me.BtnPO330.Size = New System.Drawing.Size(259, 24)
    Me.BtnPO330.TabIndex = 21
    Me.BtnPO330.Text = "Change Purchase Orders"
    '
    'FrmMenuPO
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(539, 371)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.tab)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.Name = "FrmMenuPO"
    Me.tab.ResumeLayout(False)
    Me.TpMaintain.ResumeLayout(False)
    Me.TpReq.ResumeLayout(False)
    Me.TpPO.ResumeLayout(False)
    Me.ResumeLayout(False)

End Sub
    Friend WithEvents tab As System.Windows.Forms.TabControl
    Friend WithEvents TpMaintain As System.Windows.Forms.TabPage
    Friend WithEvents BtnPO103 As System.Windows.Forms.Button
    Friend WithEvents BtnPO105 As System.Windows.Forms.Button
    Friend WithEvents BtnPO104 As System.Windows.Forms.Button
    Friend WithEvents BtnPO101 As System.Windows.Forms.Button
    Friend WithEvents TpReq As System.Windows.Forms.TabPage
    Friend WithEvents BtnPO201app As System.Windows.Forms.Button
    Friend WithEvents BtnPO201 As System.Windows.Forms.Button
    Friend WithEvents TpPO As System.Windows.Forms.TabPage
    Friend WithEvents BtnPO301 As System.Windows.Forms.Button
    Friend WithEvents BtnPO306 As System.Windows.Forms.Button
    Friend WithEvents BtnPO303 As System.Windows.Forms.Button
    Friend WithEvents BtnPO320 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnPO310 As System.Windows.Forms.Button
    Friend WithEvents BtnPO330 As System.Windows.Forms.Button
End Class
