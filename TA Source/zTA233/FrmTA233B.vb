Public Class FrmTA233B
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
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents TxtPIPct As System.Windows.Forms.TextBox
 Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider

		'NOTE: The following procedure is required by the Windows Form Designer
		'It can be modified using the Windows Form Designer.  
		'Do not modify it using the code editor.
Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ChkPost = New System.Windows.Forms.CheckBox
Me.Label1 = New System.Windows.Forms.Label
Me.TxtPIPct = New System.Windows.Forms.TextBox
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'ChkPost
'
Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkPost.Location = New System.Drawing.Point(54, 81)
Me.ChkPost.Name = "ChkPost"
Me.ChkPost.Size = New System.Drawing.Size(84, 16)
Me.ChkPost.TabIndex = 1
Me.ChkPost.Text = "Post to file?"
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(51, 48)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(106, 13)
Me.Label1.TabIndex = 1
Me.Label1.Text = "Phase in Percentage"
'
'TxtPIPct
'
Me.TxtPIPct.Location = New System.Drawing.Point(163, 45)
Me.TxtPIPct.MaxLength = 3
Me.TxtPIPct.Name = "TxtPIPct"
Me.TxtPIPct.Size = New System.Drawing.Size(24, 20)
Me.TxtPIPct.TabIndex = 0
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'FrmTA233B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(264, 150)
Me.ControlBox = False
Me.Controls.Add(Me.TxtPIPct)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.ChkPost)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA233B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
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
		Dim I As Integer
		ErrProv.SetError(TxtPIPct, "")

		For I = 0 To ErrorField.GetUpperBound(0)
			Select Case ErrorField(I)
			Case "pipct"
				ErrProv.SetError(TxtPIPct, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtPIPct.Text) = 0 Then
      ErrorField(I) = "pipct"
      ErrorMsg(I) = "Percentage cannot be 0"
      I = I + 1
    End If

	End Sub
Private Sub FrmTA233B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmTA233.SbpScreen.Text = "TA233B"
End Sub

	Private Sub TxtPIPct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPIPct.KeyPress
     e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
	End Sub
End Class






