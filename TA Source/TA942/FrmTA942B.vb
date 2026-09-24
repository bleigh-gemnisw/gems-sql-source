Public Class FrmTA942B
    Inherits System.Windows.Forms.Form
		Friend WithEvents GrpDownload As System.Windows.Forms.GroupBox
		Friend WithEvents LblFilePath As System.Windows.Forms.Label
		Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents ChkHeadings As System.Windows.Forms.CheckBox
  Friend WithEvents RbCSV As System.Windows.Forms.RadioButton
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
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
    Friend WithEvents label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.label3 = New System.Windows.Forms.Label()
    Me.GrpDownload = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.ChkHeadings = New System.Windows.Forms.CheckBox()
    Me.RbCSV = New System.Windows.Forms.RadioButton()
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GrpDownload.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'label3
    '
    Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label3.Location = New System.Drawing.Point(-100, 74)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(86, 23)
    Me.label3.TabIndex = 6
    Me.label3.Text = "New file name"
    Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'GrpDownload
    '
    Me.GrpDownload.Controls.Add(Me.LblFilePath)
    Me.GrpDownload.Controls.Add(Me.LnkFilePath)
    Me.GrpDownload.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpDownload.ForeColor = System.Drawing.Color.Black
    Me.GrpDownload.Location = New System.Drawing.Point(12, 73)
    Me.GrpDownload.Name = "GrpDownload"
    Me.GrpDownload.Size = New System.Drawing.Size(420, 35)
    Me.GrpDownload.TabIndex = 5
    Me.GrpDownload.TabStop = False
    Me.GrpDownload.Text = "Download to PC"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(68, 16)
    Me.LblFilePath.Name = "LblFilePath"
    Me.LblFilePath.Size = New System.Drawing.Size(346, 16)
    Me.LblFilePath.TabIndex = 67
    '
    'LnkFilePath
    '
    Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePath.Location = New System.Drawing.Point(10, 16)
    Me.LnkFilePath.Name = "LnkFilePath"
    Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath.TabIndex = 0
    Me.LnkFilePath.TabStop = True
    Me.LnkFilePath.Text = "File Path"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.ChkHeadings)
    Me.GroupBox1.Controls.Add(Me.RbCSV)
    Me.GroupBox1.Location = New System.Drawing.Point(434, 3)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(175, 64)
    Me.GroupBox1.TabIndex = 7
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "File Format"
    '
    'ChkHeadings
    '
    Me.ChkHeadings.AutoSize = True
    Me.ChkHeadings.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkHeadings.Checked = True
    Me.ChkHeadings.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkHeadings.Location = New System.Drawing.Point(22, 42)
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
    Me.RbCSV.Location = New System.Drawing.Point(6, 19)
    Me.RbCSV.Name = "RbCSV"
    Me.RbCSV.Size = New System.Drawing.Size(156, 17)
    Me.RbCSV.TabIndex = 19
    Me.RbCSV.TabStop = True
    Me.RbCSV.Text = "Comma Seperated (CSV)"
    Me.RbCSV.UseVisualStyleBackColor = True
    '
    'TxtGLYear
    '
    Me.TxtGLYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGLYear.Location = New System.Drawing.Point(83, 31)
    Me.TxtGLYear.MaxLength = 4
    Me.TxtGLYear.Name = "TxtGLYear"
    Me.TxtGLYear.Size = New System.Drawing.Size(42, 20)
    Me.TxtGLYear.TabIndex = 15
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(22, 35)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(55, 13)
    Me.Label1.TabIndex = 16
    Me.Label1.Text = "Grand List"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'FrmTA942B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(610, 127)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtGLYear)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.GrpDownload)
    Me.Controls.Add(Me.label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA942B"
    Me.Text = "Extract Personal Property Grand List File"
    Me.GrpDownload.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region
    Private Sub TA942B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        MyFrmTA942.SbpScreen.Text = "TA942B"
        MyUtils.CenterForm(Me.ParentForm, Me)
    End Sub
Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
    With SaveFileDialog1
      .ShowDialog()
      LblFilePath.Text = .FileName
    End With
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
    ErrProv.SetError(TxtGLYear, "")
    ErrProv.SetError(LblFilePath, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "path"
        ErrProv.SetError(LblFilePath, ErrorMsg(I))
      Case "year"
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

  If MyUtils.CnvSng(MyFrmTA942B.TxtGLYear.Text) = 0 Then
    ErrorField(I) = "year"
    ErrorMsg(I) = "Year is required"
    I = I + 1
  End If

  If MyFrmTA942B.LblFilePath.Text = String.Empty Then
    ErrorField(I) = "path"
    ErrorMsg(I) = "File path cannot be blank"
    I = I + 1
  End If

  End Sub
  Private Sub TxtGLYear_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

Private Sub FrmTA942B_Load(sender As Object, e As EventArgs) Handles MyBase.Load

End Sub
End Class






