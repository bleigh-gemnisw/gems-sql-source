Public Class FrmSettings
		Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

		Public Sub New()
				MyBase.New()

				'This call is required by the Windows Form Designer.
				InitializeComponent()

				'Add any initialization after the InitializeComponent() call

		End Sub

		'Form overrides dispose to clean up the component list.
		Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
				If disposing Then
						If Not (components Is Nothing) Then
								components.Dispose()
						End If
				End If
				MyBase.Dispose(disposing)
		End Sub

		'Required by the Windows Form Designer
		Private components As System.ComponentModel.IContainer

		'NOTE: The following procedure is required by the Windows Form Designer
		'It can be modified using the Windows Form Designer.  
		'Do not modify it using the code editor.
Friend WithEvents PrtDialog As System.Windows.Forms.PrintDialog
Friend WithEvents imageList1 As System.Windows.Forms.ImageList
Friend WithEvents TbMain As System.Windows.Forms.ToolBar
Friend WithEvents TBarSave As System.Windows.Forms.ToolBarButton
Friend WithEvents ChkDouble As System.Windows.Forms.CheckBox
Friend WithEvents TBarReturn As System.Windows.Forms.ToolBarButton
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSettings))
Me.PrtDialog = New System.Windows.Forms.PrintDialog
Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.TbMain = New System.Windows.Forms.ToolBar
Me.TBarReturn = New System.Windows.Forms.ToolBarButton
Me.TBarSave = New System.Windows.Forms.ToolBarButton
Me.ChkDouble = New System.Windows.Forms.CheckBox
Me.SuspendLayout()
'
'imageList1
'
Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
Me.imageList1.Images.SetKeyName(0, "")
Me.imageList1.Images.SetKeyName(1, "")
'
'TbMain
'
Me.TbMain.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarReturn, Me.TBarSave})
Me.TbMain.Dock = System.Windows.Forms.DockStyle.None
Me.TbMain.DropDownArrows = True
Me.TbMain.ImageList = Me.imageList1
Me.TbMain.Location = New System.Drawing.Point(8, 43)
Me.TbMain.Name = "TbMain"
Me.TbMain.ShowToolTips = True
Me.TbMain.Size = New System.Drawing.Size(88, 50)
Me.TbMain.TabIndex = 190
'
'TBarReturn
'
Me.TBarReturn.ImageIndex = 0
Me.TBarReturn.Name = "TBarReturn"
Me.TBarReturn.Text = "Return"
'
'TBarSave
'
Me.TBarSave.ImageIndex = 1
Me.TBarSave.Name = "TBarSave"
Me.TBarSave.Text = "Save"
'
'ChkDouble
'
Me.ChkDouble.AutoSize = True
Me.ChkDouble.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkDouble.Location = New System.Drawing.Point(12, 6)
Me.ChkDouble.Name = "ChkDouble"
Me.ChkDouble.Size = New System.Drawing.Size(126, 17)
Me.ChkDouble.TabIndex = 204
Me.ChkDouble.Text = "Print double spaced?"
Me.ChkDouble.UseVisualStyleBackColor = True
'
'FrmSettings
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(506, 91)
Me.Controls.Add(Me.ChkDouble)
Me.Controls.Add(Me.TbMain)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmSettings"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Maintain Settings"
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	MyFrmTA509B.Hide()
  ChkDouble.Checked = MyAppSettings.PrintDouble

  With MyFrmTA509
    .TBarBack.Enabled = False
  End With
End Sub
Public Sub SaveData()
  If ChkDouble.Checked Then
    MyAppSettings.PrintDouble = True
  Else
    MyAppSettings.PrintDouble = False
  End If
  SaveAppSettings()
  Me.Close()
End Sub

Private Sub FrmSettings_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
	With MyFrmTA509
		.TBarBack.Enabled = True
	End With
	MyFrmTA509B.Show()

End Sub

Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
	If e.Button Is TBarReturn Then
		Me.Close()
	End If

	If e.Button Is TBarSave Then
		SaveData()
	End If

End Sub
End Class






