<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuPR
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
    Me.tabPR = New System.Windows.Forms.TabPage()
    Me.BtnPRA02 = New System.Windows.Forms.Button()
    Me.BtnPRY10 = New System.Windows.Forms.Button()
    Me.BtnPRFTP = New System.Windows.Forms.Button()
    Me.btnprprtchk = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.tab.SuspendLayout()
    Me.tabPR.SuspendLayout()
    Me.SuspendLayout()
    '
    'tab
    '
    Me.tab.Appearance = System.Windows.Forms.TabAppearance.Buttons
    Me.tab.Controls.Add(Me.tabPR)
    Me.tab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.tab.Location = New System.Drawing.Point(34, 57)
    Me.tab.Multiline = True
    Me.tab.Name = "tab"
    Me.tab.SelectedIndex = 0
    Me.tab.Size = New System.Drawing.Size(486, 305)
    Me.tab.TabIndex = 12
    '
    'tabPR
    '
    Me.tabPR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.tabPR.Controls.Add(Me.BtnPRA02)
    Me.tabPR.Controls.Add(Me.BtnPRY10)
    Me.tabPR.Controls.Add(Me.BtnPRFTP)
    Me.tabPR.Controls.Add(Me.btnprprtchk)
    Me.tabPR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.tabPR.Location = New System.Drawing.Point(4, 27)
    Me.tabPR.Name = "tabPR"
    Me.tabPR.Size = New System.Drawing.Size(478, 274)
    Me.tabPR.TabIndex = 0
    Me.tabPR.Text = "Main"
    Me.tabPR.UseVisualStyleBackColor = True
    '
    'BtnPRA02
    '
    Me.BtnPRA02.Location = New System.Drawing.Point(69, 130)
    Me.BtnPRA02.Name = "BtnPRA02"
    Me.BtnPRA02.Size = New System.Drawing.Size(312, 24)
    Me.BtnPRA02.TabIndex = 9
    Me.BtnPRA02.Text = "Maintain PR G/L Acct Mappings"
    '
    'BtnPRY10
    '
    Me.BtnPRY10.Location = New System.Drawing.Point(69, 72)
    Me.BtnPRY10.Name = "BtnPRY10"
    Me.BtnPRY10.Size = New System.Drawing.Size(312, 24)
    Me.BtnPRY10.TabIndex = 8
    Me.BtnPRY10.Text = "Print W2"
    '
    'BtnPRFTP
    '
    Me.BtnPRFTP.Location = New System.Drawing.Point(69, 101)
    Me.BtnPRFTP.Name = "BtnPRFTP"
    Me.BtnPRFTP.Size = New System.Drawing.Size(312, 24)
    Me.BtnPRFTP.TabIndex = 7
    Me.BtnPRFTP.Text = "Transfer/Download Payroll files"
    '
    'btnprprtchk
    '
    Me.btnprprtchk.Location = New System.Drawing.Point(69, 43)
    Me.btnprprtchk.Name = "btnprprtchk"
    Me.btnprprtchk.Size = New System.Drawing.Size(312, 24)
    Me.btnprprtchk.TabIndex = 6
    Me.btnprprtchk.Text = "Print P/R Checks"
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
    Me.Label2.TabIndex = 17
    Me.Label2.Text = "Payroll"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'FrmMenuPR
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(539, 371)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.tab)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.Name = "FrmMenuPR"
    Me.tab.ResumeLayout(False)
    Me.tabPR.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents tab As System.Windows.Forms.TabControl
		Friend WithEvents tabPR As System.Windows.Forms.TabPage
		Friend WithEvents btnprprtchk As System.Windows.Forms.Button
  Friend WithEvents BtnPRFTP As System.Windows.Forms.Button
  Friend WithEvents BtnPRY10 As System.Windows.Forms.Button
  Friend WithEvents BtnPRA02 As System.Windows.Forms.Button
  Friend WithEvents Label2 As Label
End Class
