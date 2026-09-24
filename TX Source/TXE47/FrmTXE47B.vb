Public Class FrmTXE47B
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
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbName As System.Windows.Forms.RadioButton
Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents RbListNo As System.Windows.Forms.RadioButton
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TxtGLYear = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.RbName = New System.Windows.Forms.RadioButton
Me.RbListNo = New System.Windows.Forms.RadioButton
Me.DtPckTo = New System.Windows.Forms.DateTimePicker
Me.Label2 = New System.Windows.Forms.Label
Me.DtPckFrom = New System.Windows.Forms.DateTimePicker
Me.Label1 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
Me.SuspendLayout()
'
'TxtGLYear
'
Me.TxtGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtGLYear.Location = New System.Drawing.Point(104, 25)
Me.TxtGLYear.MaxLength = 4
Me.TxtGLYear.Name = "TxtGLYear"
Me.TxtGLYear.Size = New System.Drawing.Size(36, 20)
Me.TxtGLYear.TabIndex = 0
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(12, 29)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(84, 16)
Me.Label4.TabIndex = 11
Me.Label4.Text = "Grand List Year"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.RbName)
Me.GroupBox1.Controls.Add(Me.RbListNo)
Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
Me.GroupBox1.Location = New System.Drawing.Point(334, 12)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(85, 63)
Me.GroupBox1.TabIndex = 2
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Sort by"
'
'RbName
'
Me.RbName.AutoSize = True
Me.RbName.Checked = True
Me.RbName.ForeColor = System.Drawing.Color.Black
Me.RbName.Location = New System.Drawing.Point(17, 17)
Me.RbName.Name = "RbName"
Me.RbName.Size = New System.Drawing.Size(53, 17)
Me.RbName.TabIndex = 0
Me.RbName.TabStop = True
Me.RbName.Text = "Name"
Me.RbName.UseVisualStyleBackColor = True
'
'RbListNo
'
Me.RbListNo.AutoSize = True
Me.RbListNo.ForeColor = System.Drawing.Color.Black
Me.RbListNo.Location = New System.Drawing.Point(17, 40)
Me.RbListNo.Name = "RbListNo"
Me.RbListNo.Size = New System.Drawing.Size(48, 17)
Me.RbListNo.TabIndex = 1
Me.RbListNo.Text = "List#"
Me.RbListNo.UseVisualStyleBackColor = True
'
'DtPckTo
'
Me.DtPckTo.Checked = False
Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckTo.Location = New System.Drawing.Point(232, 61)
Me.DtPckTo.Name = "DtPckTo"
Me.DtPckTo.ShowCheckBox = True
Me.DtPckTo.Size = New System.Drawing.Size(96, 20)
Me.DtPckTo.TabIndex = 15
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(180, 65)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(52, 16)
Me.Label2.TabIndex = 14
Me.Label2.Text = "To Date"
'
'DtPckFrom
'
Me.DtPckFrom.Checked = False
Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckFrom.Location = New System.Drawing.Point(72, 61)
Me.DtPckFrom.Name = "DtPckFrom"
Me.DtPckFrom.ShowCheckBox = True
Me.DtPckFrom.Size = New System.Drawing.Size(102, 20)
Me.DtPckFrom.TabIndex = 13
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(12, 65)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(60, 16)
Me.Label1.TabIndex = 12
Me.Label1.Text = "From Date"
'
'FrmTXE47B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(430, 102)
Me.ControlBox = False
Me.Controls.Add(Me.DtPckTo)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.DtPckFrom)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.TxtGLYear)
Me.Controls.Add(Me.Label4)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTXE47B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox1.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTXE47B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmTXE47.SbpScreen.Text = "TXE47"
End Sub
Private Sub FrmTXE47B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
	Me.Refresh()
End Sub
	Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer
		ErrProv.SetError(TxtGLYear, "")

		For I = 0 To ErrorField.GetUpperBound(0)
			Select Case ErrorField(I)
			Case "glyear"
				ErrProv.SetError(TxtGLYear, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtGLYear.Text) = 0 Then
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "Year is required"
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
Private Sub FrmTXE47B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
End Sub
Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






