Public Class FrmAP501B
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
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'FrmAP501B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(437, 387)
    Me.ControlBox = False
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmAP501B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

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
Private Sub FrmAP501B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MyFrmAP501.SbpPgmID.Text = "AP501B"
  MyFrmAP501.SbpEnvironment.Text = myDBConnect.PgmDB
  MyAP = True
End Sub
Private Sub FrmAP501B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
 MyFrmAP501.SbpScreen.Text = "AP501B"
End Sub
Private Sub FrmAP501B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
 Me.Refresh()
End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
'  ErrProv.SetError(TxtBank, "")

  For I = 0 To ErrorField.GetUpperBound(0)
   Select Case ErrorField(I)
   'Case "date"
   ' ErrProv.SetError(DtPckTo, ErrorMsg(I))
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

  'If TxtBank.Text = String.Empty Then
  ' ErrorField(I) = "bank"
  ' ErrorMsg(I) = "Bank Code is required"
  ' I = I + 1
  'End If
 End Sub
Private Sub FrmAP501B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
 If Not e.Alt Then Exit Sub

  If e.KeyCode = Keys.F12 Then
   MyUtils.PrtScreen(Form.ActiveForm)
  End If
End Sub
Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
 MyFrmListApebnk = New FrmListApebnk
 MyFrmListApebnk.TxtPos.Text = TxtBank.Text
 MyFrmListApebnk.MdiParent = Me.ParentForm
 MyFrmListApebnk.Show()

End Sub
End Class
