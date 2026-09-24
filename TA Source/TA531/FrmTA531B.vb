Public Class FrmTA531B
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
	Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents ChkUpdate As System.Windows.Forms.CheckBox
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbNormal As System.Windows.Forms.RadioButton
Friend WithEvents RbDown As System.Windows.Forms.RadioButton
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTA531B))
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.ChkUpdate = New System.Windows.Forms.CheckBox
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.RbNormal = New System.Windows.Forms.RadioButton
Me.RbDown = New System.Windows.Forms.RadioButton
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
Me.SuspendLayout()
'
'ImageList1
'
Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
Me.ImageList1.Images.SetKeyName(0, "")
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'ChkUpdate
'
Me.ChkUpdate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkUpdate.Location = New System.Drawing.Point(22, 93)
Me.ChkUpdate.Name = "ChkUpdate"
Me.ChkUpdate.Size = New System.Drawing.Size(117, 18)
Me.ChkUpdate.TabIndex = 55
Me.ChkUpdate.Text = "Update File?"
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.RbNormal)
Me.GroupBox1.Controls.Add(Me.RbDown)
Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox1.Location = New System.Drawing.Point(14, 12)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(290, 64)
Me.GroupBox1.TabIndex = 59
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Last Digit handling method"
'
'RbNormal
'
Me.RbNormal.AutoSize = True
Me.RbNormal.Checked = True
Me.RbNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbNormal.Location = New System.Drawing.Point(6, 19)
Me.RbNormal.Name = "RbNormal"
Me.RbNormal.Size = New System.Drawing.Size(258, 17)
Me.RbNormal.TabIndex = 59
Me.RbNormal.TabStop = True
Me.RbNormal.Text = "Normal Rounding (IE: 103 ==> 100, 105 ==> 110)"
Me.RbNormal.UseVisualStyleBackColor = True
'
'RbDown
'
Me.RbDown.AutoSize = True
Me.RbDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbDown.Location = New System.Drawing.Point(6, 41)
Me.RbDown.Name = "RbDown"
Me.RbDown.Size = New System.Drawing.Size(253, 17)
Me.RbDown.TabIndex = 58
Me.RbDown.Text = "Truncate Down (IE: 103 ==> 100,  105 ==> 100)"
Me.RbDown.UseVisualStyleBackColor = True
'
'FrmTA531B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(316, 123)
Me.ControlBox = False
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.ChkUpdate)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA531B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox1.PerformLayout()
Me.ResumeLayout(False)

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

		Windows.Forms.Cursor.Current = Cursors.WaitCursor
		PrtReport()
		Windows.Forms.Cursor.Current = Cursors.Default

	End Sub
Private Sub FrmTA531B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmTA531.SbpScreen.Text = "TA531B"
End Sub
Private Sub FrmTA531B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
	Me.Refresh()
End Sub
	Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			Select Case ErrorField(I)
			End Select
		Next I
	End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim ds As DataSet = New DataSet
		Dim I As Integer
		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

	End Sub
Private Sub TxtPct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub

Private Sub FrmTA531B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

End Sub
End Class






