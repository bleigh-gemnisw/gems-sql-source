Public Class FrmTA213B
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
  Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents ChkBAA As System.Windows.Forms.CheckBox
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbSU As System.Windows.Forms.RadioButton
Friend WithEvents RbRE As System.Windows.Forms.RadioButton
Friend WithEvents RbMV As System.Windows.Forms.RadioButton
Friend WithEvents RbPP As System.Windows.Forms.RadioButton
Friend WithEvents ChkFrozenFile As System.Windows.Forms.CheckBox
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents ChkNonExempt As System.Windows.Forms.CheckBox
Friend WithEvents ChkPrtDist As System.Windows.Forms.CheckBox
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTA213B))
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.TxtGLYear = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.ChkBAA = New System.Windows.Forms.CheckBox
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.ChkFrozenFile = New System.Windows.Forms.CheckBox
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.RbSU = New System.Windows.Forms.RadioButton
Me.RbRE = New System.Windows.Forms.RadioButton
Me.RbMV = New System.Windows.Forms.RadioButton
Me.RbPP = New System.Windows.Forms.RadioButton
Me.TxtDist = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.ChkPrtDist = New System.Windows.Forms.CheckBox
Me.ChkNonExempt = New System.Windows.Forms.CheckBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox2.SuspendLayout()
Me.SuspendLayout()
'
'ImageList1
'
Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
Me.ImageList1.Images.SetKeyName(0, "")
'
'TxtGLYear
'
Me.TxtGLYear.Location = New System.Drawing.Point(117, 120)
Me.TxtGLYear.MaxLength = 4
Me.TxtGLYear.Name = "TxtGLYear"
Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
Me.TxtGLYear.TabIndex = 1
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(29, 120)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(84, 16)
Me.Label4.TabIndex = 11
Me.Label4.Text = "Grand List Year"
'
'ChkBAA
'
Me.ChkBAA.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkBAA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.ChkBAA.Location = New System.Drawing.Point(32, 209)
Me.ChkBAA.Name = "ChkBAA"
Me.ChkBAA.Size = New System.Drawing.Size(140, 16)
Me.ChkBAA.TabIndex = 5
Me.ChkBAA.Text = "Include BAA Amounts?"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'ChkFrozenFile
'
Me.ChkFrozenFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkFrozenFile.Location = New System.Drawing.Point(32, 229)
Me.ChkFrozenFile.Name = "ChkFrozenFile"
Me.ChkFrozenFile.Size = New System.Drawing.Size(140, 16)
Me.ChkFrozenFile.TabIndex = 6
Me.ChkFrozenFile.Text = "Use Frozen List?"
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.RbSU)
Me.GroupBox2.Controls.Add(Me.RbRE)
Me.GroupBox2.Controls.Add(Me.RbMV)
Me.GroupBox2.Controls.Add(Me.RbPP)
Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox2.Location = New System.Drawing.Point(20, 8)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(160, 100)
Me.GroupBox2.TabIndex = 0
Me.GroupBox2.TabStop = False
Me.GroupBox2.Text = "Tax Type"
'
'RbSU
'
Me.RbSU.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbSU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbSU.Location = New System.Drawing.Point(12, 76)
Me.RbSU.Name = "RbSU"
Me.RbSU.Size = New System.Drawing.Size(140, 20)
Me.RbSU.TabIndex = 3
Me.RbSU.Text = "Supplemental MV"
'
'RbRE
'
Me.RbRE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbRE.Checked = True
Me.RbRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbRE.Location = New System.Drawing.Point(12, 16)
Me.RbRE.Name = "RbRE"
Me.RbRE.Size = New System.Drawing.Size(140, 20)
Me.RbRE.TabIndex = 0
Me.RbRE.TabStop = True
Me.RbRE.Text = "Real Estate"
'
'RbMV
'
Me.RbMV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbMV.Location = New System.Drawing.Point(12, 56)
Me.RbMV.Name = "RbMV"
Me.RbMV.Size = New System.Drawing.Size(140, 20)
Me.RbMV.TabIndex = 2
Me.RbMV.Text = "Motor Vehicle"
'
'RbPP
'
Me.RbPP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbPP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbPP.Location = New System.Drawing.Point(12, 36)
Me.RbPP.Name = "RbPP"
Me.RbPP.Size = New System.Drawing.Size(140, 20)
Me.RbPP.TabIndex = 1
Me.RbPP.Text = "Personal Property"
'
'TxtDist
'
Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDist.Location = New System.Drawing.Point(117, 144)
Me.TxtDist.MaxLength = 3
Me.TxtDist.Name = "TxtDist"
Me.TxtDist.Size = New System.Drawing.Size(28, 20)
Me.TxtDist.TabIndex = 2
'
'Label1
'
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.Location = New System.Drawing.Point(29, 144)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(44, 16)
Me.Label1.TabIndex = 49
Me.Label1.Text = "District"
'
'ChkPrtDist
'
Me.ChkPrtDist.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkPrtDist.Location = New System.Drawing.Point(32, 191)
Me.ChkPrtDist.Name = "ChkPrtDist"
Me.ChkPrtDist.Size = New System.Drawing.Size(140, 16)
Me.ChkPrtDist.TabIndex = 4
Me.ChkPrtDist.Text = "Use Print Dist?"
'
'ChkNonExempt
'
Me.ChkNonExempt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkNonExempt.Checked = True
Me.ChkNonExempt.CheckState = System.Windows.Forms.CheckState.Checked
Me.ChkNonExempt.Location = New System.Drawing.Point(32, 170)
Me.ChkNonExempt.Name = "ChkNonExempt"
Me.ChkNonExempt.Size = New System.Drawing.Size(140, 17)
Me.ChkNonExempt.TabIndex = 3
Me.ChkNonExempt.Text = "Non Exempt?"
'
'FrmTA213B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(198, 267)
Me.ControlBox = False
Me.Controls.Add(Me.ChkNonExempt)
Me.Controls.Add(Me.ChkPrtDist)
Me.Controls.Add(Me.TxtDist)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.GroupBox2)
Me.Controls.Add(Me.ChkFrozenFile)
Me.Controls.Add(Me.ChkBAA)
Me.Controls.Add(Me.TxtGLYear)
Me.Controls.Add(Me.Label4)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA213B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox2.ResumeLayout(False)
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
		If RbRE.Checked Then
			PrtReportRE()
		End If
		If RbPP.Checked Then
			PrtReportPP()
		End If
		If RbMV.Checked Then
			PrtReportMV()
		End If
		If RbSU.Checked Then
			PrtReportSU()
		End If
		Windows.Forms.Cursor.Current = Cursors.Default

	End Sub
Private Sub FrmTA213B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmTA213.SbpScreen.Text = "TA213B"
End Sub
Private Sub FrmTA213B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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
      ErrorMsg(I) = "Invalid Year"
      I = I + 1
    End If

	End Sub
Private Sub RbMV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbMV.Click
	ChkFrozenFile.Enabled = True
End Sub
Private Sub RbPP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPP.Click
	ChkFrozenFile.Enabled = True
End Sub
Private Sub RbRE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbRE.Click
	ChkFrozenFile.Enabled = True
End Sub
Private Sub RbSU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSU.Click
	ChkFrozenFile.Enabled = False
End Sub
Private Sub FrmTA213B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	Windows.Forms.Cursor.Current = Cursors.WaitCursor
	BufferExem()
	Windows.Forms.Cursor.Current = Cursors.Default
End Sub
Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






