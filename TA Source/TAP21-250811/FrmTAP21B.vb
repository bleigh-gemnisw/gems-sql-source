Public Class FrmTAP21B
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
	Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
 Friend WithEvents RbTables As System.Windows.Forms.RadioButton
 Friend WithEvents RbAllFiles As System.Windows.Forms.RadioButton

		'Required by the Windows Form Designer
		Private components As System.ComponentModel.IContainer

		'NOTE: The following procedure is required by the Windows Form Designer
		'It can be modified using the Windows Form Designer.  
		'Do not modify it using the code editor.
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.RbTables = New System.Windows.Forms.RadioButton()
    Me.RbAllFiles = New System.Windows.Forms.RadioButton()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(60, 30)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(87, 17)
    Me.Label1.TabIndex = 17
    Me.Label1.Text = "New G/L Year"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'TxtYear
    '
    Me.TxtYear.Location = New System.Drawing.Point(153, 27)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtYear.TabIndex = 16
    '
    'RbTables
    '
    Me.RbTables.AutoSize = True
    Me.RbTables.Checked = True
    Me.RbTables.Location = New System.Drawing.Point(38, 63)
    Me.RbTables.Name = "RbTables"
    Me.RbTables.Size = New System.Drawing.Size(109, 17)
    Me.RbTables.TabIndex = 18
    Me.RbTables.TabStop = True
    Me.RbTables.Text = "Copy only Tables "
    Me.RbTables.UseVisualStyleBackColor = True
    '
    'RbAllFiles
    '
    Me.RbAllFiles.AutoSize = True
    Me.RbAllFiles.Location = New System.Drawing.Point(192, 63)
    Me.RbAllFiles.Name = "RbAllFiles"
    Me.RbAllFiles.Size = New System.Drawing.Size(86, 17)
    Me.RbAllFiles.TabIndex = 19
    Me.RbAllFiles.Text = "Copy all Files"
    Me.RbAllFiles.UseVisualStyleBackColor = True
    '
    'FrmTAP21B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(313, 92)
    Me.ControlBox = False
    Me.Controls.Add(Me.RbAllFiles)
    Me.Controls.Add(Me.RbTables)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtYear)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAP21B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

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
	Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	End Sub
Private Sub FrmTAP21B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmTAP21.SbpScreen.Text = "TAP21B"
End Sub
	Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
	End Sub
End Class






