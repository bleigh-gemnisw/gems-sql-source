Public Class FrmTA5074B
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
    Friend WithEvents ChkInState As System.Windows.Forms.CheckBox
    Friend WithEvents RbTown As System.Windows.Forms.RadioButton
    Friend WithEvents RbName As System.Windows.Forms.RadioButton
    Friend WithEvents ChkConfid As System.Windows.Forms.CheckBox

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.ChkInState = New System.Windows.Forms.CheckBox()
    Me.RbTown = New System.Windows.Forms.RadioButton()
    Me.RbName = New System.Windows.Forms.RadioButton()
    Me.ChkConfid = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'ChkInState
    '
    Me.ChkInState.AutoSize = True
    Me.ChkInState.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkInState.Location = New System.Drawing.Point(45, 93)
    Me.ChkInState.Name = "ChkInState"
    Me.ChkInState.Size = New System.Drawing.Size(136, 17)
    Me.ChkInState.TabIndex = 6
    Me.ChkInState.Text = "In State Vehicles Only?"
    Me.ChkInState.UseVisualStyleBackColor = True
    '
    'RbTown
    '
    Me.RbTown.AutoSize = True
    Me.RbTown.Location = New System.Drawing.Point(45, 55)
    Me.RbTown.Name = "RbTown"
    Me.RbTown.Size = New System.Drawing.Size(178, 17)
    Me.RbTown.TabIndex = 5
    Me.RbTown.Text = "Sort by Town (with page breaks)"
    Me.RbTown.UseVisualStyleBackColor = True
    '
    'RbName
    '
    Me.RbName.AutoSize = True
    Me.RbName.Checked = True
    Me.RbName.Location = New System.Drawing.Point(45, 32)
    Me.RbName.Name = "RbName"
    Me.RbName.Size = New System.Drawing.Size(143, 17)
    Me.RbName.TabIndex = 4
    Me.RbName.TabStop = True
    Me.RbName.Text = "Sort by List # (no breaks)"
    Me.RbName.UseVisualStyleBackColor = True
    '
    'ChkConfid
    '
    Me.ChkConfid.AutoSize = True
    Me.ChkConfid.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkConfid.Checked = True
    Me.ChkConfid.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkConfid.Location = New System.Drawing.Point(45, 116)
    Me.ChkConfid.Name = "ChkConfid"
    Me.ChkConfid.Size = New System.Drawing.Size(136, 17)
    Me.ChkConfid.TabIndex = 7
    Me.ChkConfid.Text = "Omit DMV Confidental?"
    Me.ChkConfid.UseVisualStyleBackColor = True
    '
    'FrmTA5074B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(261, 167)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkConfid)
    Me.Controls.Add(Me.ChkInState)
    Me.Controls.Add(Me.RbTown)
    Me.Controls.Add(Me.RbName)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA5074B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTA5074B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA5074.SbpScreen.Text = "TA5074"
End Sub
Private Sub FrmTA5074B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
 'Not used normally deleted
    'Dim I As Integer
    'ErrProv.SetError(TxtGLYear, "")

    'For I = 0 To ErrorField.GetUpperBound(0)
    '  Select Case ErrorField(I)
    '  Case "glyear"
    '    ErrProv.SetError(TxtGLYear, ErrorMsg(I))
    '  Case Nothing
    '    Exit Sub
    '  End Select
    'Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next



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
Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub FrmTA5074B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

End Sub
End Class






