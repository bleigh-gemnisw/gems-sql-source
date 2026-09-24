Public Class FrmMain
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
Friend WithEvents BtnCheck As System.Windows.Forms.Button
Friend WithEvents BtnApply As System.Windows.Forms.Button
Friend WithEvents LblTownNo As System.Windows.Forms.Label
Friend WithEvents PicGEMS As System.Windows.Forms.PictureBox
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbHotCustom As System.Windows.Forms.RadioButton
Friend WithEvents RbHotReport As System.Windows.Forms.RadioButton
Friend WithEvents RbHotProgram As System.Windows.Forms.RadioButton
Friend WithEvents TxtHotline As System.Windows.Forms.TextBox
Friend WithEvents RbHotline As System.Windows.Forms.Button
Friend WithEvents BtnSpecial As System.Windows.Forms.Button
Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
Friend WithEvents Label1 As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.BtnCheck = New System.Windows.Forms.Button()
    Me.BtnApply = New System.Windows.Forms.Button()
    Me.LblTownNo = New System.Windows.Forms.Label()
    Me.PicGEMS = New System.Windows.Forms.PictureBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.BtnSpecial = New System.Windows.Forms.Button()
    Me.RbHotCustom = New System.Windows.Forms.RadioButton()
    Me.RbHotReport = New System.Windows.Forms.RadioButton()
    Me.RbHotProgram = New System.Windows.Forms.RadioButton()
    Me.TxtHotline = New System.Windows.Forms.TextBox()
    Me.RbHotline = New System.Windows.Forms.Button()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.PicGEMS, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(48, 16)
    Me.Label1.TabIndex = 4
    Me.Label1.Text = "Town #"
    '
    'BtnCheck
    '
    Me.BtnCheck.AutoSize = True
    Me.BtnCheck.Location = New System.Drawing.Point(189, 6)
    Me.BtnCheck.Name = "BtnCheck"
    Me.BtnCheck.Size = New System.Drawing.Size(104, 24)
    Me.BtnCheck.TabIndex = 0
    Me.BtnCheck.Text = "Check for updates"
    '
    'BtnApply
    '
    Me.BtnApply.Location = New System.Drawing.Point(307, 6)
    Me.BtnApply.Name = "BtnApply"
    Me.BtnApply.Size = New System.Drawing.Size(113, 24)
    Me.BtnApply.TabIndex = 1
    Me.BtnApply.Text = "Apply Changes"
    '
    'LblTownNo
    '
    Me.LblTownNo.Location = New System.Drawing.Point(66, 12)
    Me.LblTownNo.Name = "LblTownNo"
    Me.LblTownNo.Size = New System.Drawing.Size(48, 16)
    Me.LblTownNo.TabIndex = 7
    '
    'PicGEMS
    '
    Me.PicGEMS.Image = CType(resources.GetObject("PicGEMS.Image"), System.Drawing.Image)
    Me.PicGEMS.Location = New System.Drawing.Point(686, 393)
    Me.PicGEMS.Name = "PicGEMS"
    Me.PicGEMS.Size = New System.Drawing.Size(83, 58)
    Me.PicGEMS.TabIndex = 10
    Me.PicGEMS.TabStop = False
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.BtnSpecial)
    Me.GroupBox1.Controls.Add(Me.RbHotCustom)
    Me.GroupBox1.Controls.Add(Me.RbHotReport)
    Me.GroupBox1.Controls.Add(Me.RbHotProgram)
    Me.GroupBox1.Controls.Add(Me.TxtHotline)
    Me.GroupBox1.Controls.Add(Me.RbHotline)
    Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox1.Location = New System.Drawing.Point(15, 387)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(278, 64)
    Me.GroupBox1.TabIndex = 14
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Hotline (use only as instructed)"
    '
    'BtnSpecial
    '
    Me.BtnSpecial.Location = New System.Drawing.Point(120, 36)
    Me.BtnSpecial.Name = "BtnSpecial"
    Me.BtnSpecial.Size = New System.Drawing.Size(67, 24)
    Me.BtnSpecial.TabIndex = 20
    Me.BtnSpecial.Text = "Special"
    '
    'RbHotCustom
    '
    Me.RbHotCustom.AutoSize = True
    Me.RbHotCustom.Location = New System.Drawing.Point(200, 43)
    Me.RbHotCustom.Name = "RbHotCustom"
    Me.RbHotCustom.Size = New System.Drawing.Size(60, 17)
    Me.RbHotCustom.TabIndex = 19
    Me.RbHotCustom.Text = "Custom"
    Me.RbHotCustom.UseVisualStyleBackColor = True
    '
    'RbHotReport
    '
    Me.RbHotReport.AutoSize = True
    Me.RbHotReport.Location = New System.Drawing.Point(200, 27)
    Me.RbHotReport.Name = "RbHotReport"
    Me.RbHotReport.Size = New System.Drawing.Size(57, 17)
    Me.RbHotReport.TabIndex = 18
    Me.RbHotReport.Text = "Report"
    Me.RbHotReport.UseVisualStyleBackColor = True
    '
    'RbHotProgram
    '
    Me.RbHotProgram.AutoSize = True
    Me.RbHotProgram.Checked = True
    Me.RbHotProgram.Location = New System.Drawing.Point(200, 11)
    Me.RbHotProgram.Name = "RbHotProgram"
    Me.RbHotProgram.Size = New System.Drawing.Size(64, 17)
    Me.RbHotProgram.TabIndex = 17
    Me.RbHotProgram.TabStop = True
    Me.RbHotProgram.Text = "Program"
    Me.RbHotProgram.UseVisualStyleBackColor = True
    '
    'TxtHotline
    '
    Me.TxtHotline.Location = New System.Drawing.Point(6, 13)
    Me.TxtHotline.Name = "TxtHotline"
    Me.TxtHotline.Size = New System.Drawing.Size(181, 20)
    Me.TxtHotline.TabIndex = 13
    Me.TxtHotline.TabStop = False
    '
    'RbHotline
    '
    Me.RbHotline.AutoSize = True
    Me.RbHotline.Location = New System.Drawing.Point(6, 36)
    Me.RbHotline.Name = "RbHotline"
    Me.RbHotline.Size = New System.Drawing.Size(108, 24)
    Me.RbHotline.TabIndex = 12
    Me.RbHotline.TabStop = False
    Me.RbHotline.Text = "Get Hotline Update"
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle1
    Me.DataGrdView.Location = New System.Drawing.Point(12, 37)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.Size = New System.Drawing.Size(757, 350)
    Me.DataGrdView.TabIndex = 20
    '
    'FrmMain
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(781, 454)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.PicGEMS)
    Me.Controls.Add(Me.LblTownNo)
    Me.Controls.Add(Me.BtnApply)
    Me.Controls.Add(Me.BtnCheck)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmMain"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "GEMS.NET Program Utility"
    CType(Me.PicGEMS, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub BtnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCheck.Click
	Dim WrkCancel As Boolean

	Windows.Forms.Cursor.Current = Cursors.WaitCursor
	CheckFiles(WrkCancel)
	If Not WrkCancel Then
		If ds.Tables(0).Rows.Count > 0 Then
			BtnApply.Enabled = True
		Else
			MsgBox("Your system is current", MsgBoxStyle.Information, "No updates were found")
		End If
	End If
	Windows.Forms.Cursor.Current = Cursors.Default
End Sub
Private Sub BtnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApply.Click
	Windows.Forms.Cursor.Current = Cursors.WaitCursor
	ApplyFiles()
	Windows.Forms.Cursor.Current = Cursors.Default
End Sub
Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	BtnApply.Enabled = False
	LblTownNo.Text = MyTownNo
End Sub
Private Sub RbHotline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbHotline.Click
	Dim WrkCancel As Boolean

	If TxtHotline.Text <> "" Then
		HotlineUpdate(WrkCancel)
	End If

	TxtHotline.Text = ""
End Sub

Private Sub PicGEMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicGEMS.Click
	Dim WrkCancel As Boolean

	Windows.Forms.Cursor.Current = Cursors.WaitCursor
	DirectoryUpdate("RWA", WrkCancel)
	If WrkCancel Then
		MsgBox("RWA Update was cancelled", MsgBoxStyle.Information, "RWA Programs not updated")
	Else
		MsgBox("RWA Update has finished", MsgBoxStyle.Information, "RWA Programs updated")
	End If
	Windows.Forms.Cursor.Current = Cursors.Default
End Sub

Private Sub BtnSpecial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSpecial.Click

	Dim WrkDatapath As String

	WrkDatapath = GetDataPath()
	Shell(WrkDatapath & "A_Catalogup.exe", AppWinStyle.NormalNoFocus)
	End
End Sub

End Class
