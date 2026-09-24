Public Class FrmTO208B
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
    Friend WithEvents TxtEldLYear As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
 Friend WithEvents ChkForms As System.Windows.Forms.CheckBox
 Friend WithEvents ChkPrtAllow As System.Windows.Forms.CheckBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtEldLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.ChkForms = New System.Windows.Forms.CheckBox()
    Me.ChkPrtAllow = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtEldLYear
    '
    Me.TxtEldLYear.Location = New System.Drawing.Point(137, 29)
    Me.TxtEldLYear.MaxLength = 4
    Me.TxtEldLYear.Name = "TxtEldLYear"
    Me.TxtEldLYear.Size = New System.Drawing.Size(35, 20)
    Me.TxtEldLYear.TabIndex = 0
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(36, 32)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(84, 16)
    Me.Label4.TabIndex = 58
    Me.Label4.Text = "Eldery Year"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'ChkForms
    '
    Me.ChkForms.AutoSize = True
    Me.ChkForms.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkForms.Checked = True
    Me.ChkForms.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkForms.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkForms.Location = New System.Drawing.Point(3, 129)
    Me.ChkForms.Name = "ChkForms"
    Me.ChkForms.Size = New System.Drawing.Size(81, 17)
    Me.ChkForms.TabIndex = 2
    Me.ChkForms.Text = "Print forms?"
    Me.ChkForms.Visible = False
    '
    'ChkPrtAllow
    '
    Me.ChkPrtAllow.AutoSize = True
    Me.ChkPrtAllow.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPrtAllow.Enabled = False
    Me.ChkPrtAllow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkPrtAllow.Location = New System.Drawing.Point(39, 68)
    Me.ChkPrtAllow.Name = "ChkPrtAllow"
    Me.ChkPrtAllow.Size = New System.Drawing.Size(117, 17)
    Me.ChkPrtAllow.TabIndex = 63
    Me.ChkPrtAllow.Text = "Only Print Allowed?"
    '
    'FrmTO208B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(296, 147)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkPrtAllow)
    Me.Controls.Add(Me.ChkForms)
    Me.Controls.Add(Me.TxtEldLYear)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTO208B"
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
  ErrProv.SetError(TxtEldLYear, "")

  For I = 0 To ErrorField.GetUpperBound(0)
   Select Case ErrorField(I)
   Case "glyear"
    ErrProv.SetError(TxtEldLYear, ErrorMsg(I))
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

  If MyUtils.CnvSng(TxtEldLYear.Text) = 0 Then
   ErrorField(I) = "glyear"
   ErrorMsg(I) = "G/L Year is required"
   I = I + 1
  End If

 End Sub
Private Sub FrmTO208B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
 MyFrmTO208.SbpScreen.Text = "TO208B"
 ChkPrtAllow.Enabled = True
End Sub
Private Sub TxtEldYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEldLYear.KeyPress
 e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
 Private Sub ChkForms_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkForms.Click
  ChkPrtAllow.Enabled = Not ChkPrtAllow.Enabled
 End Sub

Private Sub FrmTO208B_Load(sender As Object, e As EventArgs) Handles MyBase.Load

End Sub
End Class






