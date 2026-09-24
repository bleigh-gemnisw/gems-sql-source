Public Class FrmUB414B
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
Friend WithEvents TxtType As System.Windows.Forms.TextBox
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents GrpRemove As System.Windows.Forms.GroupBox
Friend WithEvents DtPckRemove As System.Windows.Forms.DateTimePicker
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents RbRemove As System.Windows.Forms.RadioButton
Friend WithEvents RbEstimate As System.Windows.Forms.RadioButton
Friend WithEvents GrpEstimate As System.Windows.Forms.GroupBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents ChkUsageSame As System.Windows.Forms.CheckBox
Friend WithEvents DtPckPost As System.Windows.Forms.DateTimePicker
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents DtPckUsage As System.Windows.Forms.DateTimePicker
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
Friend WithEvents DateTimePicker4 As System.Windows.Forms.DateTimePicker
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents TxtRoute As System.Windows.Forms.TextBox
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents DtPckBase As System.Windows.Forms.DateTimePicker
Friend WithEvents LblBase As System.Windows.Forms.Label
Friend WithEvents LblEstimateMsg As System.Windows.Forms.Label
Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TxtType = New System.Windows.Forms.TextBox
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.LnkType = New System.Windows.Forms.LinkLabel
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.ChkPost = New System.Windows.Forms.CheckBox
Me.GrpEstimate = New System.Windows.Forms.GroupBox
Me.LblEstimateMsg = New System.Windows.Forms.Label
Me.DtPckBase = New System.Windows.Forms.DateTimePicker
Me.LblBase = New System.Windows.Forms.Label
Me.Label4 = New System.Windows.Forms.Label
Me.ChkUsageSame = New System.Windows.Forms.CheckBox
Me.DtPckPost = New System.Windows.Forms.DateTimePicker
Me.Label3 = New System.Windows.Forms.Label
Me.DtPckUsage = New System.Windows.Forms.DateTimePicker
Me.Label6 = New System.Windows.Forms.Label
Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker
Me.CheckBox2 = New System.Windows.Forms.CheckBox
Me.DateTimePicker4 = New System.Windows.Forms.DateTimePicker
Me.Label7 = New System.Windows.Forms.Label
Me.RbEstimate = New System.Windows.Forms.RadioButton
Me.RbRemove = New System.Windows.Forms.RadioButton
Me.GrpRemove = New System.Windows.Forms.GroupBox
Me.DtPckRemove = New System.Windows.Forms.DateTimePicker
Me.Label2 = New System.Windows.Forms.Label
Me.TxtRoute = New System.Windows.Forms.TextBox
Me.Label8 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GrpEstimate.SuspendLayout()
Me.GrpRemove.SuspendLayout()
Me.SuspendLayout()
'
'TxtType
'
Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtType.Location = New System.Drawing.Point(238, 15)
Me.TxtType.MaxLength = 1
Me.TxtType.Name = "TxtType"
Me.TxtType.Size = New System.Drawing.Size(16, 20)
Me.TxtType.TabIndex = 0
'
'LnkType
'
Me.LnkType.Location = New System.Drawing.Point(174, 19)
Me.LnkType.Name = "LnkType"
Me.LnkType.Size = New System.Drawing.Size(58, 16)
Me.LnkType.TabIndex = 17
Me.LnkType.TabStop = True
Me.LnkType.Text = "Bill Type"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'ChkPost
'
Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkPost.Location = New System.Drawing.Point(162, 287)
Me.ChkPost.Name = "ChkPost"
Me.ChkPost.Size = New System.Drawing.Size(108, 19)
Me.ChkPost.TabIndex = 2
Me.ChkPost.Text = "Post to file?"
'
'GrpEstimate
'
Me.GrpEstimate.Controls.Add(Me.LblEstimateMsg)
Me.GrpEstimate.Controls.Add(Me.DtPckBase)
Me.GrpEstimate.Controls.Add(Me.LblBase)
Me.GrpEstimate.Controls.Add(Me.Label4)
Me.GrpEstimate.Controls.Add(Me.ChkUsageSame)
Me.GrpEstimate.Controls.Add(Me.DtPckPost)
Me.GrpEstimate.Controls.Add(Me.Label3)
Me.GrpEstimate.Controls.Add(Me.DtPckUsage)
Me.GrpEstimate.Controls.Add(Me.Label6)
Me.GrpEstimate.Controls.Add(Me.DateTimePicker3)
Me.GrpEstimate.Controls.Add(Me.CheckBox2)
Me.GrpEstimate.Controls.Add(Me.DateTimePicker4)
Me.GrpEstimate.Controls.Add(Me.Label7)
Me.GrpEstimate.Location = New System.Drawing.Point(120, 77)
Me.GrpEstimate.Name = "GrpEstimate"
Me.GrpEstimate.Size = New System.Drawing.Size(327, 139)
Me.GrpEstimate.TabIndex = 2
Me.GrpEstimate.TabStop = False
'
'LblEstimateMsg
'
Me.LblEstimateMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblEstimateMsg.Location = New System.Drawing.Point(3, 117)
Me.LblEstimateMsg.Name = "LblEstimateMsg"
Me.LblEstimateMsg.Size = New System.Drawing.Size(312, 20)
Me.LblEstimateMsg.TabIndex = 386
Me.LblEstimateMsg.Text = "BASE + USAGE = ESTIMATE"
Me.LblEstimateMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'DtPckBase
'
Me.DtPckBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.DtPckBase.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckBase.Location = New System.Drawing.Point(227, 16)
Me.DtPckBase.Name = "DtPckBase"
Me.DtPckBase.Size = New System.Drawing.Size(88, 20)
Me.DtPckBase.TabIndex = 0
'
'LblBase
'
Me.LblBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblBase.Location = New System.Drawing.Point(6, 16)
Me.LblBase.Name = "LblBase"
Me.LblBase.Size = New System.Drawing.Size(208, 20)
Me.LblBase.TabIndex = 384
Me.LblBase.Text = "BASE: Previous Meter Reading date"
'
'Label4
'
Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label4.Location = New System.Drawing.Point(6, 68)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(215, 20)
Me.Label4.TabIndex = 378
Me.Label4.Text = "ESTIMATE: Post Meter Readings to "
'
'ChkUsageSame
'
Me.ChkUsageSame.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkUsageSame.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.ChkUsageSame.Location = New System.Drawing.Point(6, 94)
Me.ChkUsageSame.Name = "ChkUsageSame"
Me.ChkUsageSame.Size = New System.Drawing.Size(260, 20)
Me.ChkUsageSame.TabIndex = 3
Me.ChkUsageSame.Text = "Make new Reading same as usage amount?"
'
'DtPckPost
'
Me.DtPckPost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.DtPckPost.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckPost.Location = New System.Drawing.Point(227, 68)
Me.DtPckPost.Name = "DtPckPost"
Me.DtPckPost.Size = New System.Drawing.Size(88, 20)
Me.DtPckPost.TabIndex = 2
'
'Label3
'
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(6, 40)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(208, 20)
Me.Label3.TabIndex = 372
Me.Label3.Text = "USAGE: Meter Reading date"
'
'DtPckUsage
'
Me.DtPckUsage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.DtPckUsage.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckUsage.Location = New System.Drawing.Point(227, 40)
Me.DtPckUsage.Name = "DtPckUsage"
Me.DtPckUsage.Size = New System.Drawing.Size(88, 20)
Me.DtPckUsage.TabIndex = 1
'
'Label6
'
Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label6.Location = New System.Drawing.Point(-269, -59)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(196, 20)
Me.Label6.TabIndex = 367
Me.Label6.Text = "Estimate for Meter Reading based on "
'
'DateTimePicker3
'
Me.DateTimePicker3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DateTimePicker3.Location = New System.Drawing.Point(-67, -59)
Me.DateTimePicker3.Name = "DateTimePicker3"
Me.DateTimePicker3.Size = New System.Drawing.Size(88, 20)
Me.DateTimePicker3.TabIndex = 368
'
'CheckBox2
'
Me.CheckBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.CheckBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.CheckBox2.Location = New System.Drawing.Point(-266, 0)
Me.CheckBox2.Name = "CheckBox2"
Me.CheckBox2.Size = New System.Drawing.Size(260, 20)
Me.CheckBox2.TabIndex = 371
Me.CheckBox2.Text = "Make new Reading same as usage amount?"
'
'DateTimePicker4
'
Me.DateTimePicker4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.DateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DateTimePicker4.Location = New System.Drawing.Point(-67, -33)
Me.DateTimePicker4.Name = "DateTimePicker4"
Me.DateTimePicker4.Size = New System.Drawing.Size(88, 20)
Me.DateTimePicker4.TabIndex = 369
'
'Label7
'
Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label7.Location = New System.Drawing.Point(-269, -33)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(196, 20)
Me.Label7.TabIndex = 370
Me.Label7.Text = "Post new Estimated Meter Readings to "
'
'RbEstimate
'
Me.RbEstimate.AutoSize = True
Me.RbEstimate.Checked = True
Me.RbEstimate.Location = New System.Drawing.Point(25, 126)
Me.RbEstimate.Name = "RbEstimate"
Me.RbEstimate.Size = New System.Drawing.Size(65, 17)
Me.RbEstimate.TabIndex = 375
Me.RbEstimate.TabStop = True
Me.RbEstimate.Text = "Estimate"
Me.RbEstimate.UseVisualStyleBackColor = True
'
'RbRemove
'
Me.RbRemove.AutoSize = True
Me.RbRemove.Location = New System.Drawing.Point(25, 237)
Me.RbRemove.Name = "RbRemove"
Me.RbRemove.Size = New System.Drawing.Size(65, 17)
Me.RbRemove.TabIndex = 376
Me.RbRemove.Text = "Remove"
Me.RbRemove.UseVisualStyleBackColor = True
'
'GrpRemove
'
Me.GrpRemove.Controls.Add(Me.DtPckRemove)
Me.GrpRemove.Controls.Add(Me.Label2)
Me.GrpRemove.Enabled = False
Me.GrpRemove.Location = New System.Drawing.Point(120, 222)
Me.GrpRemove.Name = "GrpRemove"
Me.GrpRemove.Size = New System.Drawing.Size(260, 46)
Me.GrpRemove.TabIndex = 3
Me.GrpRemove.TabStop = False
'
'DtPckRemove
'
Me.DtPckRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.DtPckRemove.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckRemove.Location = New System.Drawing.Point(156, 17)
Me.DtPckRemove.Name = "DtPckRemove"
Me.DtPckRemove.Size = New System.Drawing.Size(88, 20)
Me.DtPckRemove.TabIndex = 0
'
'Label2
'
Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label2.Location = New System.Drawing.Point(14, 17)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(136, 20)
Me.Label2.TabIndex = 374
Me.Label2.Text = "Remove all readings for "
'
'TxtRoute
'
Me.TxtRoute.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtRoute.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtRoute.Location = New System.Drawing.Point(238, 41)
Me.TxtRoute.MaxLength = 2
Me.TxtRoute.Name = "TxtRoute"
Me.TxtRoute.Size = New System.Drawing.Size(24, 22)
Me.TxtRoute.TabIndex = 1
'
'Label8
'
Me.Label8.BackColor = System.Drawing.SystemColors.Control
Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label8.ForeColor = System.Drawing.SystemColors.WindowText
Me.Label8.Location = New System.Drawing.Point(174, 45)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(40, 16)
Me.Label8.TabIndex = 379
Me.Label8.Text = "Route"
'
'FrmUB414B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(459, 319)
Me.ControlBox = False
Me.Controls.Add(Me.TxtRoute)
Me.Controls.Add(Me.Label8)
Me.Controls.Add(Me.GrpRemove)
Me.Controls.Add(Me.RbRemove)
Me.Controls.Add(Me.RbEstimate)
Me.Controls.Add(Me.GrpEstimate)
Me.Controls.Add(Me.ChkPost)
Me.Controls.Add(Me.TxtType)
Me.Controls.Add(Me.LnkType)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmUB414B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GrpEstimate.ResumeLayout(False)
Me.GrpRemove.ResumeLayout(False)
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmUB414B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmUB414.SbpScreen.Text = "UB414"
End Sub

Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
	MyFrmListUBType_Tax = New FrmListUBType_Tax
	MyFrmListUBType_Tax.MdiParent = Me.ParentForm
	MyFrmListUBType_Tax.WrkType = TxtType.Text
	MyFrmListUBType_Tax.Show()
	Me.Hide()
End Sub
Private Sub FrmUB414B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
	Me.Refresh()
End Sub
	Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer
		ErrProv.SetError(TxtType, "")
		ErrProv.SetError(DtPckPost, "")

		For I = 0 To ErrorField.GetUpperBound(0)
			Select Case ErrorField(I)
			Case "type"
				ErrProv.SetError(TxtType, ErrorMsg(I))
			Case "postdt"
				ErrProv.SetError(DtPckPost, ErrorMsg(I))
			Case Nothing
				Exit Sub
			End Select
		Next I
	End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim WrkUBType As String
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

		If RbEstimate.Checked Then
			If DtPckUsage.Value >= DtPckPost.Value Then
				ErrorField(I) = "postdt"
				ErrorMsg(I) = "Post date must be after Reading Date"
				I = I + 1
			End If
		End If

		If TxtType.Text <> String.Empty Then
			WrkUBType = GetUTTypeUBType(TxtType.Text)
			If WrkUBType <> "M" Then
				ErrorField(I) = "type"
				ErrorMsg(I) = "Only Meter types are valid for this option"
				I = I + 1
			End If
		End If

	End Sub
Public Sub RunReport()
		Dim ErrorField(25) As String
		Dim ErrorMsg(25) As String

		Array.Clear(ErrorField, 0, 25)
		Array.Clear(ErrorMsg, 0, 25)

		EditChecks(ErrorField, ErrorMsg)
		ShowError(ErrorField, ErrorMsg)
		If Not IsNothing(ErrorMsg(0)) Then
			Exit Sub
		End If

		Me.Refresh()
		Windows.Forms.Cursor.Current = Cursors.WaitCursor
		PrtReport()

		'Reset screen to defaults
		TxtType.Text = ""
		ChkPost.Checked = False
		Windows.Forms.Cursor.Current = Cursors.Default

End Sub

Private Sub FrmUB414B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	DtPckBase.Value = Date.Today
	DtPckUsage.Value = Date.Today
	DtPckPost.Value = Date.Today
End Sub
Private Sub RbEstimate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbEstimate.Click
	GrpEstimate.Enabled = True
	GrpRemove.Enabled = False
End Sub
Private Sub RbRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbRemove.Click
	GrpEstimate.Enabled = False
	GrpRemove.Enabled = True
	ChkUsageSame.Checked = False
End Sub
	Private Sub ChkUsageSame_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkUsageSame.Click
		LblBase.Enabled = Not LblBase.Enabled
		DtPckBase.Enabled = Not DtPckBase.Enabled
		LblEstimateMsg.Visible = Not LblEstimateMsg.Visible
	End Sub

Private Sub ChkUsageSame_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkUsageSame.CheckedChanged

End Sub

Private Sub RbRemove_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbRemove.CheckedChanged

End Sub
End Class






