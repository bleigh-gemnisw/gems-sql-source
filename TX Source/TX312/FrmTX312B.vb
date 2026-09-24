Public Class FrmTX312B
Inherits System.Windows.Forms.Form

Dim WrkTxType As String

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
Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtCode As System.Windows.Forms.TextBox
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents LnkCode As System.Windows.Forms.LinkLabel
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtType As System.Windows.Forms.TextBox
Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
Friend WithEvents ChkBalance As System.Windows.Forms.CheckBox
Friend WithEvents ChkUpdate As System.Windows.Forms.CheckBox
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtFromGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtToGLYear = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ChkUpdate = New System.Windows.Forms.CheckBox()
    Me.TxtCode = New System.Windows.Forms.TextBox()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LnkCode = New System.Windows.Forms.LinkLabel()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.LnkType = New System.Windows.Forms.LinkLabel()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ChkBalance = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtFromGLYear
    '
    Me.TxtFromGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFromGLYear.Location = New System.Drawing.Point(128, 56)
    Me.TxtFromGLYear.MaxLength = 4
    Me.TxtFromGLYear.Name = "TxtFromGLYear"
    Me.TxtFromGLYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtFromGLYear.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(19, 60)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(101, 16)
    Me.Label4.TabIndex = 11
    Me.Label4.Text = "Grand List Year"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtToGLYear
    '
    Me.TxtToGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtToGLYear.Location = New System.Drawing.Point(192, 56)
    Me.TxtToGLYear.MaxLength = 4
    Me.TxtToGLYear.Name = "TxtToGLYear"
    Me.TxtToGLYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtToGLYear.TabIndex = 2
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(168, 60)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(27, 16)
    Me.Label3.TabIndex = 19
    Me.Label3.Text = "to"
    '
    'ChkUpdate
    '
    Me.ChkUpdate.AutoSize = True
    Me.ChkUpdate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkUpdate.Location = New System.Drawing.Point(22, 148)
    Me.ChkUpdate.Name = "ChkUpdate"
    Me.ChkUpdate.Size = New System.Drawing.Size(128, 20)
    Me.ChkUpdate.TabIndex = 4
    Me.ChkUpdate.Text = "Update records?"
    '
    'TxtCode
    '
    Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode.Location = New System.Drawing.Point(128, 30)
    Me.TxtCode.MaxLength = 2
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(22, 20)
    Me.TxtCode.TabIndex = 0
    '
    'LnkCode
    '
    Me.LnkCode.Location = New System.Drawing.Point(19, 34)
    Me.LnkCode.Name = "LnkCode"
    Me.LnkCode.Size = New System.Drawing.Size(72, 16)
    Me.LnkCode.TabIndex = 4
    Me.LnkCode.TabStop = True
    Me.LnkCode.Text = "Status Code"
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Location = New System.Drawing.Point(128, 87)
    Me.TxtType.MaxLength = 1
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(16, 20)
    Me.TxtType.TabIndex = 3
    '
    'LnkType
    '
    Me.LnkType.Location = New System.Drawing.Point(19, 91)
    Me.LnkType.Name = "LnkType"
    Me.LnkType.Size = New System.Drawing.Size(80, 16)
    Me.LnkType.TabIndex = 64
    Me.LnkType.TabStop = True
    Me.LnkType.Text = "Type"
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(150, 89)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(78, 18)
    Me.Label1.TabIndex = 65
    Me.Label1.Text = "(Optional)"
    '
    'ChkBalance
    '
    Me.ChkBalance.AutoSize = True
    Me.ChkBalance.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkBalance.Location = New System.Drawing.Point(22, 123)
    Me.ChkBalance.Name = "ChkBalance"
    Me.ChkBalance.Size = New System.Drawing.Size(152, 20)
    Me.ChkBalance.TabIndex = 66
    Me.ChkBalance.Text = "Only Zero Balances?"
    '
    'FrmTX312B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(264, 183)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkBalance)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtType)
    Me.Controls.Add(Me.LnkType)
    Me.Controls.Add(Me.LnkCode)
    Me.Controls.Add(Me.TxtCode)
    Me.Controls.Add(Me.ChkUpdate)
    Me.Controls.Add(Me.TxtToGLYear)
    Me.Controls.Add(Me.TxtFromGLYear)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX312B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTX312B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmTX312.SbpScreen.Text = "TX312"
End Sub


Private Sub FrmTX312B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
	Me.Refresh()
End Sub
	Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer
		ErrProv.SetError(TxtCode, "")
		ErrProv.SetError(TxtFromGLYear, "")
		ErrProv.SetError(TxtToGLYear, "")

		For I = 0 To ErrorField.GetUpperBound(0)
			Select Case ErrorField(I)
			Case "code"
				ErrProv.SetError(TxtCode, ErrorMsg(I))
			Case "fromglyear"
				ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
			Case "toglyear"
				ErrProv.SetError(TxtToGLYear, ErrorMsg(I))
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

		If TxtCode.Text = "" Then
			ErrorField(I) = "code"
			ErrorMsg(I) = "Code is required"
			I = I + 1
		End If

    If MyUtils.CnvSng(TxtFromGLYear.Text) > MyUtils.CnvSng(TxtToGLYear.Text) Then
      ErrorField(I) = "fromglyear"
      ErrorMsg(I) = "Invalid Year Range"
      I = I + 1
      ErrorField(I) = "toglyear"
      ErrorMsg(I) = "Invalid Year Range"
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

Private Sub groupbox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

End Sub

Private Sub LnkCode_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode.LinkClicked
	MyFrmListSts = New FrmListSts
	MyFrmListSts.MdiParent = Me.ParentForm
	MyFrmListSts.WrkCode = TxtCode.Text
	MyFrmListSts.Show()
End Sub
Private Sub TxtFromGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub FrmTX312B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

End Sub

Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
	MyFrmListTypes = New FrmListTypes
	MyFrmListTypes.MdiParent = Me.ParentForm
	MyFrmListTypes.WrkType = TxtType.Text
	MyFrmListTypes.Show()
End Sub
End Class






