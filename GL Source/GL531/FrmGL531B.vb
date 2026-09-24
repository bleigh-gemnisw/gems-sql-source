Public Class FrmGL531B
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
Friend WithEvents TxtFund As System.Windows.Forms.TextBox
Friend WithEvents TxtSfund As System.Windows.Forms.TextBox
Friend WithEvents LnkFund As System.Windows.Forms.LinkLabel
  Friend WithEvents Label1 As Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtFund = New System.Windows.Forms.TextBox()
    Me.TxtSfund = New System.Windows.Forms.TextBox()
    Me.LnkFund = New System.Windows.Forms.LinkLabel()
    Me.Label1 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtFund
    '
    Me.TxtFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFund.Location = New System.Drawing.Point(132, 66)
    Me.TxtFund.MaxLength = 3
    Me.TxtFund.Name = "TxtFund"
    Me.TxtFund.Size = New System.Drawing.Size(30, 22)
    Me.TxtFund.TabIndex = 0
    '
    'TxtSfund
    '
    Me.TxtSfund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfund.Location = New System.Drawing.Point(177, 66)
    Me.TxtSfund.MaxLength = 3
    Me.TxtSfund.Name = "TxtSfund"
    Me.TxtSfund.Size = New System.Drawing.Size(34, 22)
    Me.TxtSfund.TabIndex = 1
    '
    'LnkFund
    '
    Me.LnkFund.AutoSize = True
    Me.LnkFund.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFund.Location = New System.Drawing.Point(95, 70)
    Me.LnkFund.Name = "LnkFund"
    Me.LnkFund.Size = New System.Drawing.Size(31, 13)
    Me.LnkFund.TabIndex = 319
    Me.LnkFund.TabStop = True
    Me.LnkFund.Text = "Fund"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(29, 32)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(263, 13)
    Me.Label1.TabIndex = 320
    Me.Label1.Text = "Add budget account numbers and update descriptions"
    '
    'FrmGL531B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(314, 120)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LnkFund)
    Me.Controls.Add(Me.TxtSfund)
    Me.Controls.Add(Me.TxtFund)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL531B"
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
  Private Sub FrmGL531B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  End Sub
  Private Sub FrmGL531B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGL531.SbpScreen.Text = "GL531B"
End Sub
Private Sub FrmGL531B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    ErrProv.SetError(TxtFund, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "fund"
        ErrProv.SetError(TxtFund, ErrorMsg(I))
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

    If TxtFund.Text = "" Then
      ErrorField(I) = "fund"
      ErrorMsg(I) = "Invalid Fund"
      I = I + 1
    End If
  End Sub
Private Sub TxtFund_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFund.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtSfund_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSfund.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LnkFund_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFund.LinkClicked
  MyFrmListFund = New FrmListFund
  MyFrmListFund.MdiParent = Me.ParentForm
  MyFrmListFund.WrkFund = MyUtils.CnvSng(TxtFund.Text)
  MyFrmListFund.WrkID = "From"
  MyFrmListFund.Show()
  Me.Hide()
End Sub
End Class
