Public Class FrmTX505B
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents RbAfter As System.Windows.Forms.RadioButton
Friend WithEvents RbBefore As System.Windows.Forms.RadioButton
Friend WithEvents TxtBankCd As System.Windows.Forms.TextBox
Friend WithEvents LnkBankCd As System.Windows.Forms.LinkLabel
Friend WithEvents TxtBankSv As System.Windows.Forms.TextBox
Friend WithEvents LnkBankSv As System.Windows.Forms.LinkLabel
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.RbBefore = New System.Windows.Forms.RadioButton()
    Me.RbAfter = New System.Windows.Forms.RadioButton()
    Me.TxtBankCd = New System.Windows.Forms.TextBox()
    Me.LnkBankCd = New System.Windows.Forms.LinkLabel()
    Me.TxtBankSv = New System.Windows.Forms.TextBox()
    Me.LnkBankSv = New System.Windows.Forms.LinkLabel()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtGLYear
    '
    Me.TxtGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGLYear.Location = New System.Drawing.Point(112, 90)
    Me.TxtGLYear.MaxLength = 4
    Me.TxtGLYear.Name = "TxtGLYear"
    Me.TxtGLYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtGLYear.TabIndex = 1
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(28, 94)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(84, 16)
    Me.Label7.TabIndex = 31
    Me.Label7.Text = "Grand List Year"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'RbBefore
    '
    Me.RbBefore.AutoSize = True
    Me.RbBefore.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbBefore.Checked = True
    Me.RbBefore.Location = New System.Drawing.Point(25, 65)
    Me.RbBefore.Name = "RbBefore"
    Me.RbBefore.Size = New System.Drawing.Size(77, 17)
    Me.RbBefore.TabIndex = 32
    Me.RbBefore.TabStop = True
    Me.RbBefore.Text = "Before Bills"
    Me.RbBefore.UseVisualStyleBackColor = True
    '
    'RbAfter
    '
    Me.RbAfter.AutoSize = True
    Me.RbAfter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbAfter.Location = New System.Drawing.Point(120, 65)
    Me.RbAfter.Name = "RbAfter"
    Me.RbAfter.Size = New System.Drawing.Size(68, 17)
    Me.RbAfter.TabIndex = 33
    Me.RbAfter.Text = "After Bills"
    Me.RbAfter.UseVisualStyleBackColor = True
    '
    'TxtBankCd
    '
    Me.TxtBankCd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBankCd.Location = New System.Drawing.Point(112, 39)
    Me.TxtBankCd.MaxLength = 2
    Me.TxtBankCd.Name = "TxtBankCd"
    Me.TxtBankCd.Size = New System.Drawing.Size(24, 20)
    Me.TxtBankCd.TabIndex = 163
    '
    'LnkBankCd
    '
    Me.LnkBankCd.Location = New System.Drawing.Point(32, 39)
    Me.LnkBankCd.Name = "LnkBankCd"
    Me.LnkBankCd.Size = New System.Drawing.Size(80, 16)
    Me.LnkBankCd.TabIndex = 164
    Me.LnkBankCd.TabStop = True
    Me.LnkBankCd.Text = "Escrow Bank"
    '
    'TxtBankSv
    '
    Me.TxtBankSv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBankSv.Location = New System.Drawing.Point(112, 9)
    Me.TxtBankSv.MaxLength = 2
    Me.TxtBankSv.Name = "TxtBankSv"
    Me.TxtBankSv.Size = New System.Drawing.Size(24, 20)
    Me.TxtBankSv.TabIndex = 165
    '
    'LnkBankSv
    '
    Me.LnkBankSv.Location = New System.Drawing.Point(32, 9)
    Me.LnkBankSv.Name = "LnkBankSv"
    Me.LnkBankSv.Size = New System.Drawing.Size(80, 16)
    Me.LnkBankSv.TabIndex = 166
    Me.LnkBankSv.TabStop = True
    Me.LnkBankSv.Text = "Bank Service"
    '
    'FrmTX505B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(226, 122)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtBankSv)
    Me.Controls.Add(Me.LnkBankSv)
    Me.Controls.Add(Me.TxtBankCd)
    Me.Controls.Add(Me.LnkBankCd)
    Me.Controls.Add(Me.RbAfter)
    Me.Controls.Add(Me.RbBefore)
    Me.Controls.Add(Me.TxtGLYear)
    Me.Controls.Add(Me.Label7)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX505B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTX505B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX505.SbpScreen.Text = "TX505"
End Sub
Private Sub FrmTX505B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If RbAfter.Checked Then
      If MyUtils.CnvSng(TxtGLYear.Text) = 0 Then
        ErrorField(I) = "glyear"
        ErrorMsg(I) = "Year is required"
        I = I + 1
      End If
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
Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LnkBankCd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBankCd.LinkClicked
  MyFrmListBanks = New FrmListBanks
  MyFrmListBanks.MdiParent = Me.ParentForm
  MyFrmListBanks.WrkCode = TxtBankCd.Text
  MyFrmListBanks.Show()
End Sub

Private Sub FrmTX505B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   TxtGLYear.Enabled = False
End Sub
Private Sub RbBefore_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbBefore.Click
   TxtGLYear.Enabled = False
End Sub
Private Sub RbAfter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbAfter.Click
   TxtGLYear.Enabled = True
End Sub

Private Sub LnkBankSv_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkBankSv.LinkClicked
  MyFrmListBser = New FrmListBser
  MyFrmListBser.MdiParent = Me.ParentForm
  MyFrmListBser.WrkCode = TxtBankSv.Text
  MyFrmListBser.Show()
End Sub
End Class






