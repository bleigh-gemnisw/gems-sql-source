Public Class FrmTA904B
    Inherits System.Windows.Forms.Form
		Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
		Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
		Friend WithEvents ChkHeadings As System.Windows.Forms.CheckBox
		Friend WithEvents RbCSV As System.Windows.Forms.RadioButton
		Friend WithEvents RbFixed As System.Windows.Forms.RadioButton
		Friend WithEvents ChkPDist As System.Windows.Forms.CheckBox
		Friend WithEvents TxtDist As System.Windows.Forms.TextBox
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents ChkPublic As System.Windows.Forms.CheckBox
		Friend WithEvents GrpDownload As System.Windows.Forms.GroupBox
		Friend WithEvents LblFilePath As System.Windows.Forms.Label
		Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
		Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog


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
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.ChkHeadings = New System.Windows.Forms.CheckBox()
    Me.RbCSV = New System.Windows.Forms.RadioButton()
    Me.RbFixed = New System.Windows.Forms.RadioButton()
    Me.ChkPDist = New System.Windows.Forms.CheckBox()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ChkPublic = New System.Windows.Forms.CheckBox()
    Me.GrpDownload = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GrpDownload.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.ChkHeadings)
    Me.GroupBox1.Controls.Add(Me.RbCSV)
    Me.GroupBox1.Controls.Add(Me.RbFixed)
    Me.GroupBox1.Location = New System.Drawing.Point(430, 3)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(175, 88)
    Me.GroupBox1.TabIndex = 32
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "File Format"
    '
    'ChkHeadings
    '
    Me.ChkHeadings.AutoSize = True
    Me.ChkHeadings.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkHeadings.Location = New System.Drawing.Point(22, 65)
    Me.ChkHeadings.Name = "ChkHeadings"
    Me.ChkHeadings.Size = New System.Drawing.Size(140, 17)
    Me.ChkHeadings.TabIndex = 20
    Me.ChkHeadings.Text = "Include Field Headings?"
    Me.ChkHeadings.UseVisualStyleBackColor = True
    '
    'RbCSV
    '
    Me.RbCSV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbCSV.Checked = True
    Me.RbCSV.Location = New System.Drawing.Point(6, 42)
    Me.RbCSV.Name = "RbCSV"
    Me.RbCSV.Size = New System.Drawing.Size(156, 17)
    Me.RbCSV.TabIndex = 19
    Me.RbCSV.TabStop = True
    Me.RbCSV.Text = "Comma Seperated (CSV)"
    Me.RbCSV.UseVisualStyleBackColor = True
    '
    'RbFixed
    '
    Me.RbFixed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbFixed.Location = New System.Drawing.Point(6, 19)
    Me.RbFixed.Name = "RbFixed"
    Me.RbFixed.Size = New System.Drawing.Size(156, 17)
    Me.RbFixed.TabIndex = 18
    Me.RbFixed.Text = "Fixed Length (TXT)"
    Me.RbFixed.UseVisualStyleBackColor = True
    '
    'ChkPDist
    '
    Me.ChkPDist.AutoSize = True
    Me.ChkPDist.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkPDist.Location = New System.Drawing.Point(287, 72)
    Me.ChkPDist.Name = "ChkPDist"
    Me.ChkPDist.Size = New System.Drawing.Size(128, 17)
    Me.ChkPDist.TabIndex = 29
    Me.ChkPDist.Text = "Use the Print District?"
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(233, 69)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(32, 20)
    Me.TxtDist.TabIndex = 28
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(24, 72)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(203, 19)
    Me.Label1.TabIndex = 31
    Me.Label1.Text = "For a Specific District, enter the District"
    '
    'ChkPublic
    '
    Me.ChkPublic.AutoSize = True
    Me.ChkPublic.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPublic.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkPublic.Location = New System.Drawing.Point(27, 38)
    Me.ChkPublic.Name = "ChkPublic"
    Me.ChkPublic.Size = New System.Drawing.Size(121, 17)
    Me.ChkPublic.TabIndex = 27
    Me.ChkPublic.Text = "Include MV Regno?"
    '
    'GrpDownload
    '
    Me.GrpDownload.Controls.Add(Me.LblFilePath)
    Me.GrpDownload.Controls.Add(Me.LnkFilePath)
    Me.GrpDownload.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpDownload.ForeColor = System.Drawing.Color.Black
    Me.GrpDownload.Location = New System.Drawing.Point(5, 136)
    Me.GrpDownload.Name = "GrpDownload"
    Me.GrpDownload.Size = New System.Drawing.Size(420, 46)
    Me.GrpDownload.TabIndex = 26
    Me.GrpDownload.TabStop = False
    Me.GrpDownload.Text = "Download to PC"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(64, 19)
    Me.LblFilePath.Name = "LblFilePath"
    Me.LblFilePath.Size = New System.Drawing.Size(346, 16)
    Me.LblFilePath.TabIndex = 67
    '
    'LnkFilePath
    '
    Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePath.Location = New System.Drawing.Point(6, 19)
    Me.LnkFilePath.Name = "LnkFilePath"
    Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath.TabIndex = 0
    Me.LnkFilePath.TabStop = True
    Me.LnkFilePath.Text = "File Path"
    '
    'FrmTA904B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(611, 184)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.ChkPDist)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.ChkPublic)
    Me.Controls.Add(Me.GrpDownload)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA904B"
    Me.Text = "Export Supplemental Motor Vehicle Grand List File"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GrpDownload.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

		Private Sub TA904B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
				MyFrmTA904.SbpScreen.Text = "TA904B"
        MyUtils.CenterForm(Me.ParentForm, Me)
		End Sub
Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
			With SaveFileDialog1
			.ShowDialog()
			LblFilePath.Text = .FileName
		End With
End Sub
	Private Sub RbFixed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbFixed.Click
		ChkHeadings.Enabled = False
	End Sub
	Private Sub RbCSV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbCSV.Click
		ChkHeadings.Enabled = True
	End Sub
Public Sub RunExport()
		Dim ErrorField(25) As String
		Dim ErrorMsg(25) As String

		Array.Clear(ErrorField, 0, 25)
		Array.Clear(ErrorMsg, 0, 25)

		EditChecks(ErrorField, ErrorMsg)
		ShowError(ErrorField, ErrorMsg)
		If Not IsNothing(ErrorMsg(0)) Then
			Exit Sub
		End If

		ProcFile()
End Sub
	Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer
		ErrProv.SetError(LblFilePath, "")

		For I = 0 To ErrorField.GetUpperBound(0)
			Select Case ErrorField(I)
			End Select
		Next I

		For I = 0 To ErrorField.GetUpperBound(0)
			Select Case ErrorField(I)
			Case "path"
				ErrProv.SetError(LblFilePath, ErrorMsg(I))
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

	If MyFrmTA904B.LblFilePath.Text = String.Empty Then
		ErrorField(I) = "path"
		ErrorMsg(I) = "File path cannot be blank"
		I = I + 1
	End If

	End Sub
End Class






