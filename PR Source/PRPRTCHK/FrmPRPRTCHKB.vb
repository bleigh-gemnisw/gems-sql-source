Public Class FrmPRPRTCHKB
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
Friend WithEvents LblMsg As System.Windows.Forms.Label
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbPayroll As System.Windows.Forms.RadioButton
Friend WithEvents RbSupport As System.Windows.Forms.RadioButton
Friend WithEvents BtnManual As System.Windows.Forms.Button
Friend WithEvents LnkVendor As System.Windows.Forms.LinkLabel
Friend WithEvents TxtBank As System.Windows.Forms.TextBox
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.LblMsg = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.BtnManual = New System.Windows.Forms.Button()
    Me.RbSupport = New System.Windows.Forms.RadioButton()
    Me.RbPayroll = New System.Windows.Forms.RadioButton()
    Me.LnkVendor = New System.Windows.Forms.LinkLabel()
    Me.TxtBank = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblMsg
    '
    Me.LblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMsg.Location = New System.Drawing.Point(12, 9)
    Me.LblMsg.Name = "LblMsg"
    Me.LblMsg.Size = New System.Drawing.Size(303, 22)
    Me.LblMsg.TabIndex = 3
    Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.BtnManual)
    Me.GroupBox1.Controls.Add(Me.RbSupport)
    Me.GroupBox1.Controls.Add(Me.RbPayroll)
    Me.GroupBox1.Location = New System.Drawing.Point(25, 33)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(428, 53)
    Me.GroupBox1.TabIndex = 4
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Select Payroll Option"
    '
    'BtnManual
    '
    Me.BtnManual.Location = New System.Drawing.Point(297, 19)
    Me.BtnManual.Name = "BtnManual"
    Me.BtnManual.Size = New System.Drawing.Size(114, 25)
    Me.BtnManual.TabIndex = 8
    Me.BtnManual.Text = "Manual Check"
    Me.BtnManual.UseVisualStyleBackColor = True
    '
    'RbSupport
    '
    Me.RbSupport.AutoSize = True
    Me.RbSupport.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSupport.Location = New System.Drawing.Point(164, 19)
    Me.RbSupport.Name = "RbSupport"
    Me.RbSupport.Size = New System.Drawing.Size(96, 17)
    Me.RbSupport.TabIndex = 6
    Me.RbSupport.Text = "Support Check"
    Me.RbSupport.UseVisualStyleBackColor = True
    '
    'RbPayroll
    '
    Me.RbPayroll.AutoSize = True
    Me.RbPayroll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPayroll.Checked = True
    Me.RbPayroll.Location = New System.Drawing.Point(9, 19)
    Me.RbPayroll.Name = "RbPayroll"
    Me.RbPayroll.Size = New System.Drawing.Size(90, 17)
    Me.RbPayroll.TabIndex = 5
    Me.RbPayroll.TabStop = True
    Me.RbPayroll.Text = "Payroll Check"
    Me.RbPayroll.UseVisualStyleBackColor = True
    '
    'LnkVendor
    '
    Me.LnkVendor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkVendor.ForeColor = System.Drawing.Color.Maroon
    Me.LnkVendor.Location = New System.Drawing.Point(22, 103)
    Me.LnkVendor.Name = "LnkVendor"
    Me.LnkVendor.Size = New System.Drawing.Size(87, 17)
    Me.LnkVendor.TabIndex = 76
    Me.LnkVendor.TabStop = True
    Me.LnkVendor.Text = "Bank Account"
    '
    'TxtBank
    '
    Me.TxtBank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBank.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBank.Location = New System.Drawing.Point(115, 99)
    Me.TxtBank.MaxLength = 5
    Me.TxtBank.Name = "TxtBank"
    Me.TxtBank.Size = New System.Drawing.Size(47, 22)
    Me.TxtBank.TabIndex = 75
    '
    'FrmPRPRTCHKB
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(483, 147)
    Me.ControlBox = False
    Me.Controls.Add(Me.LnkVendor)
    Me.Controls.Add(Me.TxtBank)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.LblMsg)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPRPRTCHKB"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
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
Private Sub FrmPRPRTCHKB_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmPRPRTCHK.SbpScreen.Text = "PRPRTCHKB"
End Sub
Private Sub FrmPRPRTCHKB_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtBank, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "bank"
        ErrProv.SetError(TxtBank, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim WrkBankName As String
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    WrkBankName = GetAPEBNKName(TxtBank.Text)
    If WrkBankName = "" Or Mid(WrkBankName, 1, 3) = "***" Then
     ErrorField(I) = "bank"
     ErrorMsg(I) = "Invalid Bank code"
     I = I + 1
    End If

    If Mid(TxtBank.Text, 1, 2) <> "PR" Then
      ErrorField(I) = "bank"
      ErrorMsg(I) = "Cannot use A/P Bank code"
      I = I + 1
    End If
  End Sub
Private Sub FrmPRPRTCHKB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  LblMsg.Text = "Note: Run Option to create Payroll checks"
  TxtBank.Text = "PR"
End Sub
Private Sub RbPayroll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPayroll.Click
  LblMsg.Text = "Note: Run Option to create Payroll checks"
  MyCheckType = "P"
End Sub
Private Sub RbSupport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSupport.Click
  LblMsg.Text = "Note: Run Option to create Support checks"
  MyCheckType = "S"
End Sub
Private Sub BtnManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnManual.Click
  MyCheckType = "M"

  LblMsg.Text = ""
  Me.Hide()

  MyFrmPRPRTCHKC = New FrmPRPRTCHKC
  MyFrmPRPRTCHKC.MdiParent = Me.ParentForm
  MyFrmPRPRTCHKC.Show()
End Sub

Private Sub LnkVendor_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkVendor.LinkClicked
  MyFrmListApebnk = New FrmListApebnk
  MyFrmListApebnk.MdiParent = Me.ParentForm
  MyFrmListApebnk.WrkCode = TxtBank.Text
  MyFrmListApebnk.Show()
End Sub

Private Sub RbPayroll_CheckedChanged(sender As Object, e As EventArgs) Handles RbPayroll.CheckedChanged

End Sub
End Class
