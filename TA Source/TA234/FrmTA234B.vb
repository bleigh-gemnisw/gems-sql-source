Public Class FrmTA234B
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
	Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbChanges As System.Windows.Forms.RadioButton
Friend WithEvents RbIncrease As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbPP As System.Windows.Forms.RadioButton
Friend WithEvents RbRE As System.Windows.Forms.RadioButton
Friend WithEvents RbAll As System.Windows.Forms.RadioButton
Friend WithEvents TxtGLYear2 As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtGLYear1 As System.Windows.Forms.TextBox
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TxtGLYear1 = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.RbAll = New System.Windows.Forms.RadioButton
Me.RbChanges = New System.Windows.Forms.RadioButton
Me.RbIncrease = New System.Windows.Forms.RadioButton
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.RbPP = New System.Windows.Forms.RadioButton
Me.RbRE = New System.Windows.Forms.RadioButton
Me.TxtGLYear2 = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
Me.GroupBox2.SuspendLayout()
Me.SuspendLayout()
'
'TxtGLYear1
'
Me.TxtGLYear1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtGLYear1.Location = New System.Drawing.Point(207, 73)
Me.TxtGLYear1.MaxLength = 4
Me.TxtGLYear1.Name = "TxtGLYear1"
Me.TxtGLYear1.Size = New System.Drawing.Size(36, 20)
Me.TxtGLYear1.TabIndex = 1
'
'Label4
'
Me.Label4.AutoSize = True
Me.Label4.Location = New System.Drawing.Point(100, 79)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(97, 13)
Me.Label4.TabIndex = 11
Me.Label4.Text = "1st Grand List Year"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.RbAll)
Me.GroupBox1.Controls.Add(Me.RbChanges)
Me.GroupBox1.Controls.Add(Me.RbIncrease)
Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox1.Location = New System.Drawing.Point(96, 124)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(130, 81)
Me.GroupBox1.TabIndex = 3
Me.GroupBox1.TabStop = False
'
'RbAll
'
Me.RbAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbAll.Location = New System.Drawing.Point(11, 58)
Me.RbAll.Name = "RbAll"
Me.RbAll.Size = New System.Drawing.Size(94, 17)
Me.RbAll.TabIndex = 16
Me.RbAll.Text = "All"
Me.RbAll.UseVisualStyleBackColor = True
'
'RbChanges
'
Me.RbChanges.AutoSize = True
Me.RbChanges.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbChanges.Location = New System.Drawing.Point(11, 38)
Me.RbChanges.Name = "RbChanges"
Me.RbChanges.Size = New System.Drawing.Size(106, 17)
Me.RbChanges.TabIndex = 15
Me.RbChanges.Text = "Changes (1 <> 2)"
Me.RbChanges.UseVisualStyleBackColor = True
'
'RbIncrease
'
Me.RbIncrease.AutoSize = True
Me.RbIncrease.Checked = True
Me.RbIncrease.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbIncrease.Location = New System.Drawing.Point(11, 15)
Me.RbIncrease.Name = "RbIncrease"
Me.RbIncrease.Size = New System.Drawing.Size(99, 17)
Me.RbIncrease.TabIndex = 14
Me.RbIncrease.TabStop = True
Me.RbIncrease.Text = "Increase (1 > 2)"
Me.RbIncrease.UseVisualStyleBackColor = True
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.RbPP)
Me.GroupBox2.Controls.Add(Me.RbRE)
Me.GroupBox2.Location = New System.Drawing.Point(96, 6)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(130, 61)
Me.GroupBox2.TabIndex = 0
Me.GroupBox2.TabStop = False
'
'RbPP
'
Me.RbPP.AutoSize = True
Me.RbPP.Location = New System.Drawing.Point(11, 38)
Me.RbPP.Name = "RbPP"
Me.RbPP.Size = New System.Drawing.Size(108, 17)
Me.RbPP.TabIndex = 15
Me.RbPP.Text = "Personal Property"
Me.RbPP.UseVisualStyleBackColor = True
'
'RbRE
'
Me.RbRE.Checked = True
Me.RbRE.Location = New System.Drawing.Point(11, 15)
Me.RbRE.Name = "RbRE"
Me.RbRE.Size = New System.Drawing.Size(94, 17)
Me.RbRE.TabIndex = 1
Me.RbRE.TabStop = True
Me.RbRE.Text = "Real Estate"
Me.RbRE.UseVisualStyleBackColor = True
'
'TxtGLYear2
'
Me.TxtGLYear2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtGLYear2.Location = New System.Drawing.Point(207, 101)
Me.TxtGLYear2.MaxLength = 4
Me.TxtGLYear2.Name = "TxtGLYear2"
Me.TxtGLYear2.Size = New System.Drawing.Size(36, 20)
Me.TxtGLYear2.TabIndex = 2
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(100, 104)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(101, 13)
Me.Label1.TabIndex = 13
Me.Label1.Text = "2nd Grand List Year"
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label2.Location = New System.Drawing.Point(12, 218)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(273, 13)
Me.Label2.TabIndex = 14
Me.Label2.Text = "List only includes billed accounts with data in both years."
'
'Label3
'
Me.Label3.AutoSize = True
Me.Label3.Location = New System.Drawing.Point(249, 76)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(44, 13)
Me.Label3.TabIndex = 15
Me.Label3.Text = "(Newer)"
'
'FrmTA234B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(315, 245)
Me.ControlBox = False
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.TxtGLYear2)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.GroupBox2)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.TxtGLYear1)
Me.Controls.Add(Me.Label4)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA234B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox1.PerformLayout()
Me.GroupBox2.ResumeLayout(False)
Me.GroupBox2.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTA234B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmTA234.SbpScreen.Text = "TA234"
End Sub
Private Sub FrmTA234B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
	Me.Refresh()
End Sub
	Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer
		ErrProv.SetError(TxtGLYear1, "")
		ErrProv.SetError(TxtGLYear2, "")

		For I = 0 To ErrorField.GetUpperBound(0)
			Select Case ErrorField(I)
			Case "glyear1"
				ErrProv.SetError(TxtGLYear1, ErrorMsg(I))
			Case "glyear2"
				ErrProv.SetError(TxtGLYear2, ErrorMsg(I))
			Case Nothing
				Exit Sub
			End Select
		Next I
	End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

    If MyUtils.CnvSng(TxtGLYear1.Text) = 0 Then
      ErrorField(I) = "glyear1"
      ErrorMsg(I) = "Year1 is required"
      I = I + 1
    End If
    If MyUtils.CnvSng(TxtGLYear2.Text) = 0 Then
      ErrorField(I) = "glyear2"
      ErrorMsg(I) = "Year2 is required"
      I = I + 1
    End If
    If MyUtils.CnvSng(TxtGLYear1.Text) <= MyUtils.CnvSng(TxtGLYear2.Text) Then
      ErrorField(I) = "glyear2"
      ErrorMsg(I) = "Year2 must be before Year1"
      I = I + 1
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
		Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub TxtGLYear1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear1.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtGLYear2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear2.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






