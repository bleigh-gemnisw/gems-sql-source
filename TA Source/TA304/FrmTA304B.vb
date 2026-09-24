Public Class FrmTA304B
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
    Friend WithEvents TxtPenCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtPenAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPenPct As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtYear As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents RbNonFiler As RadioButton
  Friend WithEvents RbMissing As RadioButton

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.TxtPenCode = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtPenAmount = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtPenPct = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.RbMissing = New System.Windows.Forms.RadioButton()
    Me.RbNonFiler = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ChkPost
    '
    Me.ChkPost.AutoSize = True
    Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPost.Location = New System.Drawing.Point(31, 125)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(81, 17)
    Me.ChkPost.TabIndex = 4
    Me.ChkPost.Text = "Post to file?"
    '
    'TxtPenCode
    '
    Me.TxtPenCode.Location = New System.Drawing.Point(118, 64)
    Me.TxtPenCode.MaxLength = 3
    Me.TxtPenCode.Name = "TxtPenCode"
    Me.TxtPenCode.Size = New System.Drawing.Size(27, 20)
    Me.TxtPenCode.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(31, 67)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(70, 13)
    Me.Label4.TabIndex = 58
    Me.Label4.Text = "Penalty Code"
    '
    'TxtPenAmount
    '
    Me.TxtPenAmount.Location = New System.Drawing.Point(118, 90)
    Me.TxtPenAmount.MaxLength = 9
    Me.TxtPenAmount.Name = "TxtPenAmount"
    Me.TxtPenAmount.Size = New System.Drawing.Size(63, 20)
    Me.TxtPenAmount.TabIndex = 2
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(31, 93)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(81, 13)
    Me.Label1.TabIndex = 60
    Me.Label1.Text = "Penalty Amount"
    '
    'TxtPenPct
    '
    Me.TxtPenPct.Location = New System.Drawing.Point(319, 91)
    Me.TxtPenPct.MaxLength = 4
    Me.TxtPenPct.Name = "TxtPenPct"
    Me.TxtPenPct.Size = New System.Drawing.Size(27, 20)
    Me.TxtPenPct.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(229, 94)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(82, 13)
    Me.Label2.TabIndex = 62
    Me.Label2.Text = "Penalty Percent"
    '
    'Label3
    '
    Me.Label3.ForeColor = System.Drawing.Color.Blue
    Me.Label3.Location = New System.Drawing.Point(187, 94)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(39, 15)
    Me.Label3.TabIndex = 63
    Me.Label3.Text = "- OR -"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(352, 95)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(35, 15)
    Me.Label5.TabIndex = 64
    Me.Label5.Text = "(99.9)"
    '
    'TxtYear
    '
    Me.TxtYear.Location = New System.Drawing.Point(118, 13)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtYear.TabIndex = 0
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.Location = New System.Drawing.Point(28, 16)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(80, 13)
    Me.Label13.TabIndex = 209
    Me.Label13.Text = "Grand List Year"
    '
    'RbMissing
    '
    Me.RbMissing.AutoSize = True
    Me.RbMissing.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbMissing.Checked = True
    Me.RbMissing.Location = New System.Drawing.Point(31, 41)
    Me.RbMissing.Name = "RbMissing"
    Me.RbMissing.Size = New System.Drawing.Size(87, 17)
    Me.RbMissing.TabIndex = 210
    Me.RbMissing.TabStop = True
    Me.RbMissing.Text = "Missing Filers"
    Me.RbMissing.UseVisualStyleBackColor = True
    '
    'RbNonFiler
    '
    Me.RbNonFiler.AutoSize = True
    Me.RbNonFiler.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbNonFiler.Location = New System.Drawing.Point(151, 41)
    Me.RbNonFiler.Name = "RbNonFiler"
    Me.RbNonFiler.Size = New System.Drawing.Size(72, 17)
    Me.RbNonFiler.TabIndex = 211
    Me.RbNonFiler.Text = "Non Filers"
    Me.RbNonFiler.UseVisualStyleBackColor = True
    '
    'FrmTA304B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(401, 150)
    Me.ControlBox = False
    Me.Controls.Add(Me.RbNonFiler)
    Me.Controls.Add(Me.RbMissing)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtPenPct)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtPenAmount)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtPenCode)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.ChkPost)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA304B"
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
    ErrProv.SetError(TxtPenCode, "")
    ErrProv.SetError(TxtPenAmount, "")
    ErrProv.SetError(TxtPenPct, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "code"
        ErrProv.SetError(TxtPenCode, ErrorMsg(I))
      Case "amount"
        ErrProv.SetError(TxtPenAmount, ErrorMsg(I))
      Case "pct"
        ErrProv.SetError(TxtPenPct, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtPenCode.Text) = 0 Then
      ErrorField(I) = "code"
      ErrorMsg(I) = "Penalty Code is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtPenAmount.Text) = 0 And MyUtils.CnvSng(TxtPenPct.Text) = 0 Then
      ErrorField(I) = "amount"
      ErrorMsg(I) = "Either Penalty Amount or percent is required"
      I = I + 1
      ErrorField(I) = "pct"
      ErrorMsg(I) = "Either Penalty Amount or percent is required"
      I = I + 1
    End If

  End Sub
Private Sub FrmTA304B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA304.SbpScreen.Text = "TA304B"
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtPenCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPenCode.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtPenAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPenAmount.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtPenPct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPenPct.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub

Private Sub FrmTA304B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

End Sub
End Class






