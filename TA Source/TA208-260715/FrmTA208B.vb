Public Class FrmTA208B
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
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents ChkDouble As System.Windows.Forms.CheckBox
Friend WithEvents RbOnly As System.Windows.Forms.RadioButton
Friend WithEvents RbPrev As System.Windows.Forms.RadioButton
  Friend WithEvents ChkSname As CheckBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTA208B))
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.ChkDouble = New System.Windows.Forms.CheckBox()
    Me.RbOnly = New System.Windows.Forms.RadioButton()
    Me.RbPrev = New System.Windows.Forms.RadioButton()
    Me.ChkSname = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
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
    'TxtGLYear
    '
    Me.TxtGLYear.Location = New System.Drawing.Point(121, 25)
    Me.TxtGLYear.MaxLength = 4
    Me.TxtGLYear.Name = "TxtGLYear"
    Me.TxtGLYear.Size = New System.Drawing.Size(37, 20)
    Me.TxtGLYear.TabIndex = 0
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(12, 27)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(84, 16)
    Me.Label4.TabIndex = 56
    Me.Label4.Text = "Grand List Year"
    '
    'ChkDouble
    '
    Me.ChkDouble.AutoSize = True
    Me.ChkDouble.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkDouble.Location = New System.Drawing.Point(12, 101)
    Me.ChkDouble.Name = "ChkDouble"
    Me.ChkDouble.Size = New System.Drawing.Size(130, 17)
    Me.ChkDouble.TabIndex = 3
    Me.ChkDouble.Text = "Print Double Spaced?"
    Me.ChkDouble.UseVisualStyleBackColor = True
    '
    'RbOnly
    '
    Me.RbOnly.AutoSize = True
    Me.RbOnly.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbOnly.Location = New System.Drawing.Point(169, 51)
    Me.RbOnly.Name = "RbOnly"
    Me.RbOnly.Size = New System.Drawing.Size(101, 17)
    Me.RbOnly.TabIndex = 194
    Me.RbOnly.Text = "G/L Year ONLY"
    Me.RbOnly.UseVisualStyleBackColor = True
    '
    'RbPrev
    '
    Me.RbPrev.AutoSize = True
    Me.RbPrev.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPrev.Checked = True
    Me.RbPrev.Location = New System.Drawing.Point(12, 51)
    Me.RbPrev.Name = "RbPrev"
    Me.RbPrev.Size = New System.Drawing.Size(133, 17)
    Me.RbPrev.TabIndex = 193
    Me.RbPrev.TabStop = True
    Me.RbPrev.Text = "G/L Year and previous"
    Me.RbPrev.UseVisualStyleBackColor = True
    '
    'ChkSname
    '
    Me.ChkSname.AutoSize = True
    Me.ChkSname.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkSname.Location = New System.Drawing.Point(12, 131)
    Me.ChkSname.Name = "ChkSname"
    Me.ChkSname.Size = New System.Drawing.Size(130, 17)
    Me.ChkSname.TabIndex = 195
    Me.ChkSname.Text = "Print Second Name?  "
    Me.ChkSname.UseVisualStyleBackColor = True
    '
    'FrmTA208B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(283, 160)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkSname)
    Me.Controls.Add(Me.RbOnly)
    Me.Controls.Add(Me.RbPrev)
    Me.Controls.Add(Me.ChkDouble)
    Me.Controls.Add(Me.TxtGLYear)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA208B"
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

		Windows.Forms.Cursor.Current = Cursors.WaitCursor
		PrtReport()
		Windows.Forms.Cursor.Current = Cursors.Default

	End Sub
Private Sub FrmTA208B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	SetGLYear()
End Sub
Private Sub FrmTA208B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmTA208.SbpScreen.Text = "TA208B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmTA208B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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
		Dim ds As DataSet = New DataSet
		Dim I As Integer
		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

    If MyUtils.CnvSng(TxtGLYear.Text) = 0 Then
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "Grand List Year is required"
      I = I + 1
    End If

	End Sub
Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub SetGLYear()
    Dim WrkYear As Integer

    WrkYear = Date.Now.Year
    If Date.Now.Month < 10 Then
      WrkYear = WrkYear - 1
    End If
    TxtGLYear.Text = WrkYear
End Sub
End Class






