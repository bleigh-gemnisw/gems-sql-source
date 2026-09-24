<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMargins
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
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMargins))
Me.Label1 = New System.Windows.Forms.Label
Me.TxtTop = New System.Windows.Forms.TextBox
Me.TxtLeft = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.TbMain = New System.Windows.Forms.ToolBar
Me.TBarBack = New System.Windows.Forms.ToolBarButton
Me.TBarSave1 = New System.Windows.Forms.ToolBarButton
Me.Label3 = New System.Windows.Forms.Label
Me.SuspendLayout()
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(59, 88)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(83, 13)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Left Margin Size"
'
'TxtTop
'
Me.TxtTop.Location = New System.Drawing.Point(151, 58)
Me.TxtTop.Name = "TxtTop"
Me.TxtTop.Size = New System.Drawing.Size(36, 20)
Me.TxtTop.TabIndex = 1
'
'TxtLeft
'
Me.TxtLeft.Location = New System.Drawing.Point(151, 84)
Me.TxtLeft.Name = "TxtLeft"
Me.TxtLeft.Size = New System.Drawing.Size(36, 20)
Me.TxtLeft.TabIndex = 3
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Location = New System.Drawing.Point(59, 62)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(84, 13)
Me.Label2.TabIndex = 2
Me.Label2.Text = "Top Margin Size"
'
'ImageList1
'
Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.ImageList1.TransparentColor = System.Drawing.Color.White
Me.ImageList1.Images.SetKeyName(0, "")
Me.ImageList1.Images.SetKeyName(1, "SAVE.BMP")
'
'TbMain
'
Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarBack, Me.TBarSave1})
Me.TbMain.DropDownArrows = True
Me.TbMain.ImageList = Me.ImageList1
Me.TbMain.Location = New System.Drawing.Point(0, 0)
Me.TbMain.Name = "TbMain"
Me.TbMain.ShowToolTips = True
Me.TbMain.Size = New System.Drawing.Size(251, 50)
Me.TbMain.TabIndex = 4
'
'TBarBack
'
Me.TBarBack.ImageIndex = 0
Me.TBarBack.Name = "TBarBack"
Me.TBarBack.Text = "&Back"
'
'TBarSave1
'
Me.TBarSave1.ImageIndex = 1
Me.TBarSave1.Name = "TBarPrint"
Me.TBarSave1.Text = "Save"
'
'Label3
'
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(58, 117)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(129, 57)
Me.Label3.TabIndex = 5
Me.Label3.Text = "Warning: Numbers too high can cause information to fall off the report"
'
'FrmMargins
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(251, 188)
Me.ControlBox = False
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.TbMain)
Me.Controls.Add(Me.TxtLeft)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.TxtTop)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.Name = "FrmMargins"
Me.ShowIcon = False
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Set Print Margins (this computer only)"
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtTop As System.Windows.Forms.TextBox
    Friend WithEvents TxtLeft As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TbMain As System.Windows.Forms.ToolBar
    Friend WithEvents TBarBack As System.Windows.Forms.ToolBarButton
    Friend WithEvents TBarSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents TBarSave1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class






