Public Class FrmTA403B
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
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents ChkIncr As System.Windows.Forms.CheckBox
Friend WithEvents TxtStartNo As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtStartNo = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.ChkIncr = New System.Windows.Forms.CheckBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'TxtStartNo
'
Me.TxtStartNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtStartNo.Location = New System.Drawing.Point(149, 25)
Me.TxtStartNo.MaxLength = 6
Me.TxtStartNo.Name = "TxtStartNo"
Me.TxtStartNo.Size = New System.Drawing.Size(56, 20)
Me.TxtStartNo.TabIndex = 67
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(44, 28)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(99, 13)
Me.Label1.TabIndex = 68
Me.Label1.Text = "Staring List Number"
'
'ChkIncr
'
Me.ChkIncr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkIncr.Checked = True
Me.ChkIncr.CheckState = System.Windows.Forms.CheckState.Checked
Me.ChkIncr.Location = New System.Drawing.Point(30, 52)
Me.ChkIncr.Name = "ChkIncr"
Me.ChkIncr.Size = New System.Drawing.Size(214, 39)
Me.ChkIncr.TabIndex = 69
Me.ChkIncr.Text = "Start each letter at 10000 increments (IE: A=10000, B=20000, etc."
Me.ChkIncr.UseVisualStyleBackColor = True
'
'FrmTA403B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(256, 103)
Me.ControlBox = False
Me.Controls.Add(Me.ChkIncr)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtStartNo)
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA403B"
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
    ProcFile()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmTA403B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmTA403.SbpPgmID.Text = "TA403B"
    MyFrmTA403.SbpEnvironment.Text = myDBConnect.PgmDB
    TxtStartNo.Text = "10000"
End Sub
Private Sub FrmTA403B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA403.SbpScreen.Text = "TA403B"
End Sub
Private Sub FrmTA403B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
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
  End Sub
Private Sub FrmTA403B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub

   If e.KeyCode = Keys.F12 Then
     MyUtils.PrtScreen(Form.ActiveForm)
   End If
End Sub
Private Sub TxtStartNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtStartNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






