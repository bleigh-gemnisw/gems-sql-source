Public Class FrmAP202B
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
Friend WithEvents LnkFromFund As System.Windows.Forms.LinkLabel
Friend WithEvents TxtToFund As System.Windows.Forms.TextBox
Friend WithEvents LnkToFund As System.Windows.Forms.LinkLabel
Friend WithEvents ChkDetail As System.Windows.Forms.CheckBox
Friend WithEvents TxtFromFund As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.LnkFromFund = New System.Windows.Forms.LinkLabel()
    Me.TxtFromFund = New System.Windows.Forms.TextBox()
    Me.ChkDetail = New System.Windows.Forms.CheckBox()
    Me.TxtToFund = New System.Windows.Forms.TextBox()
    Me.LnkToFund = New System.Windows.Forms.LinkLabel()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LnkFromFund
    '
    Me.LnkFromFund.AutoSize = True
    Me.LnkFromFund.Location = New System.Drawing.Point(55, 36)
    Me.LnkFromFund.Name = "LnkFromFund"
    Me.LnkFromFund.Size = New System.Drawing.Size(57, 13)
    Me.LnkFromFund.TabIndex = 3
    Me.LnkFromFund.Text = "From Fund"
    '
    'TxtFromFund
    '
    Me.TxtFromFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFromFund.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFromFund.Location = New System.Drawing.Point(121, 33)
    Me.TxtFromFund.MaxLength = 3
    Me.TxtFromFund.Name = "TxtFromFund"
    Me.TxtFromFund.Size = New System.Drawing.Size(28, 20)
    Me.TxtFromFund.TabIndex = 0
    '
    'ChkDetail
    '
    Me.ChkDetail.AutoSize = True
    Me.ChkDetail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkDetail.Location = New System.Drawing.Point(60, 69)
    Me.ChkDetail.Name = "ChkDetail"
    Me.ChkDetail.Size = New System.Drawing.Size(89, 17)
    Me.ChkDetail.TabIndex = 2
    Me.ChkDetail.Text = "Show Detail?"
    Me.ChkDetail.UseVisualStyleBackColor = True
    '
    'TxtToFund
    '
    Me.TxtToFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtToFund.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtToFund.Location = New System.Drawing.Point(243, 33)
    Me.TxtToFund.MaxLength = 3
    Me.TxtToFund.Name = "TxtToFund"
    Me.TxtToFund.Size = New System.Drawing.Size(26, 20)
    Me.TxtToFund.TabIndex = 1
    '
    'LnkToFund
    '
    Me.LnkToFund.AutoSize = True
    Me.LnkToFund.Location = New System.Drawing.Point(190, 36)
    Me.LnkToFund.Name = "LnkToFund"
    Me.LnkToFund.Size = New System.Drawing.Size(47, 13)
    Me.LnkToFund.TabIndex = 4
    Me.LnkToFund.Text = "To Fund"
    '
    'FrmAP202B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(370, 126)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtToFund)
    Me.Controls.Add(Me.LnkToFund)
    Me.Controls.Add(Me.ChkDetail)
    Me.Controls.Add(Me.TxtFromFund)
    Me.Controls.Add(Me.LnkFromFund)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmAP202B"
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
Private Sub FrmAP202B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MyFrmAP202.SbpPgmID.Text = "AP202B"
  MyFrmAP202.SbpEnvironment.Text = myDBConnect.PgmDB
End Sub
Private Sub FrmAP202B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
 MyFrmAP202.SbpScreen.Text = "AP202B"
End Sub
Private Sub FrmAP202B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
 Me.Refresh()
End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtFromFund, "")
  ErrProv.SetError(TxtToFund, "")

  For I = 0 To ErrorField.GetUpperBound(0)
   Select Case ErrorField(I)
   Case "fund"
    ErrProv.SetError(TxtFromFund, ErrorMsg(I))
    ErrProv.SetError(TxtToFund, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtToFund.Text) > 0 Then
      If MyUtils.CnvSng(TxtFromFund.Text) > MyUtils.CnvSng(TxtToFund.Text) Then
        ErrorField(I) = "fund"
        ErrorMsg(I) = "Invalid Fund Range"
        I = I + 1
      End If
    End If

  End Sub
Private Sub FrmAP202B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
 If Not e.Alt Then Exit Sub

  If e.KeyCode = Keys.F12 Then
   MyUtils.PrtScreen(Form.ActiveForm)
  End If
End Sub
Private Sub LnkFromFund_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFromFund.LinkClicked
 MyFrmListFund = New FrmListFund
 MyFrmListFund.WrkField = "From"
 MyFrmListFund.WrkFund = MyUtils.CnvSng(TxtFromFund.Text)
 MyFrmListFund.MdiParent = Me.ParentForm
 MyFrmListFund.Show()
End Sub
Private Sub LnkToFund_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkToFund.LinkClicked
 MyFrmListFund = New FrmListFund
 MyFrmListFund.WrkField = "To"
 MyFrmListFund.WrkFund = MyUtils.CnvSng(TxtToFund.Text)
 MyFrmListFund.MdiParent = Me.ParentForm
 MyFrmListFund.Show()
End Sub
Private Sub TxtFromFund_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromFund.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToFund_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToFund.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class
