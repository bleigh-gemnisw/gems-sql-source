Public Class FrmTA316B
Inherits System.Windows.Forms.Form
Dim ds As DataSet = New DataSet

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
    Friend WithEvents LnkBusty As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtBusty As System.Windows.Forms.TextBox

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.LnkBusty = New System.Windows.Forms.LinkLabel
Me.TxtBusty = New System.Windows.Forms.TextBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'LnkBusty
'
Me.LnkBusty.Location = New System.Drawing.Point(32, 26)
Me.LnkBusty.Name = "LnkBusty"
Me.LnkBusty.Size = New System.Drawing.Size(80, 16)
Me.LnkBusty.TabIndex = 155
Me.LnkBusty.TabStop = True
Me.LnkBusty.Text = "Business Type"
'
'TxtBusty
'
Me.TxtBusty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtBusty.Location = New System.Drawing.Point(120, 26)
Me.TxtBusty.MaxLength = 4
Me.TxtBusty.Name = "TxtBusty"
Me.TxtBusty.Size = New System.Drawing.Size(40, 20)
Me.TxtBusty.TabIndex = 154
'
'FrmTA316B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(192, 69)
Me.ControlBox = False
Me.Controls.Add(Me.LnkBusty)
Me.Controls.Add(Me.TxtBusty)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA316B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTA316B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA316.SbpScreen.Text = "TA316"
End Sub
Private Sub FrmTA316B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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
Private Sub FrmTA316B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
End Sub
Private Sub LnkBusty_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBusty.LinkClicked
    MyFrmListBusty = New FrmListBusty
    MyFrmListBusty.MdiParent = Me.ParentForm
    MyFrmListBusty.WrkCode = TxtBusty.Text
    MyFrmListBusty.Show()
End Sub
End Class






