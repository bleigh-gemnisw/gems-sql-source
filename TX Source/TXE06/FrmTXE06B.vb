Public Class FrmTXE06B
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
  Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TxtGLYearFrom As System.Windows.Forms.TextBox
Friend WithEvents TxtBankCd As System.Windows.Forms.TextBox
Friend WithEvents LnkBankCd As System.Windows.Forms.LinkLabel
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbName As System.Windows.Forms.RadioButton
Friend WithEvents RbBank As System.Windows.Forms.RadioButton
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtGLYearTo As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtTypes = New System.Windows.Forms.TextBox()
    Me.TxtGLYearFrom = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.LnkTypes = New System.Windows.Forms.LinkLabel()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtBankCd = New System.Windows.Forms.TextBox()
    Me.LnkBankCd = New System.Windows.Forms.LinkLabel()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbName = New System.Windows.Forms.RadioButton()
    Me.RbBank = New System.Windows.Forms.RadioButton()
    Me.TxtGLYearTo = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'TxtTypes
    '
    Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTypes.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTypes.Location = New System.Drawing.Point(127, 42)
    Me.TxtTypes.MaxLength = 20
    Me.TxtTypes.Name = "TxtTypes"
    Me.TxtTypes.Size = New System.Drawing.Size(148, 20)
    Me.TxtTypes.TabIndex = 2
    '
    'TxtGLYearFrom
    '
    Me.TxtGLYearFrom.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGLYearFrom.Location = New System.Drawing.Point(127, 16)
    Me.TxtGLYearFrom.MaxLength = 4
    Me.TxtGLYearFrom.Name = "TxtGLYearFrom"
    Me.TxtGLYearFrom.Size = New System.Drawing.Size(36, 20)
    Me.TxtGLYearFrom.TabIndex = 0
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(35, 20)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(84, 16)
    Me.Label4.TabIndex = 11
    Me.Label4.Text = "Grand List Year"
    '
    'LnkTypes
    '
    Me.LnkTypes.Location = New System.Drawing.Point(43, 46)
    Me.LnkTypes.Name = "LnkTypes"
    Me.LnkTypes.Size = New System.Drawing.Size(80, 16)
    Me.LnkTypes.TabIndex = 17
    Me.LnkTypes.TabStop = True
    Me.LnkTypes.Text = "Types to print"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtBankCd
    '
    Me.TxtBankCd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBankCd.Location = New System.Drawing.Point(127, 144)
    Me.TxtBankCd.MaxLength = 2
    Me.TxtBankCd.Name = "TxtBankCd"
    Me.TxtBankCd.Size = New System.Drawing.Size(24, 20)
    Me.TxtBankCd.TabIndex = 4
    '
    'LnkBankCd
    '
    Me.LnkBankCd.Location = New System.Drawing.Point(43, 148)
    Me.LnkBankCd.Name = "LnkBankCd"
    Me.LnkBankCd.Size = New System.Drawing.Size(80, 16)
    Me.LnkBankCd.TabIndex = 164
    Me.LnkBankCd.TabStop = True
    Me.LnkBankCd.Text = "Escrow Bank"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbName)
    Me.GroupBox1.Controls.Add(Me.RbBank)
    Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox1.Location = New System.Drawing.Point(38, 75)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(163, 63)
    Me.GroupBox1.TabIndex = 3
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Sort by"
    '
    'RbName
    '
    Me.RbName.AutoSize = True
    Me.RbName.Checked = True
    Me.RbName.ForeColor = System.Drawing.Color.Black
    Me.RbName.Location = New System.Drawing.Point(17, 17)
    Me.RbName.Name = "RbName"
    Me.RbName.Size = New System.Drawing.Size(53, 17)
    Me.RbName.TabIndex = 0
    Me.RbName.TabStop = True
    Me.RbName.Text = "Name"
    Me.RbName.UseVisualStyleBackColor = True
    '
    'RbBank
    '
    Me.RbBank.AutoSize = True
    Me.RbBank.ForeColor = System.Drawing.Color.Black
    Me.RbBank.Location = New System.Drawing.Point(17, 40)
    Me.RbBank.Name = "RbBank"
    Me.RbBank.Size = New System.Drawing.Size(140, 17)
    Me.RbBank.TabIndex = 1
    Me.RbBank.Text = "Bank (Only bank coded)"
    Me.RbBank.UseVisualStyleBackColor = True
    '
    'TxtGLYearTo
    '
    Me.TxtGLYearTo.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGLYearTo.Location = New System.Drawing.Point(191, 16)
    Me.TxtGLYearTo.MaxLength = 4
    Me.TxtGLYearTo.Name = "TxtGLYearTo"
    Me.TxtGLYearTo.Size = New System.Drawing.Size(36, 20)
    Me.TxtGLYearTo.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(169, 19)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(16, 13)
    Me.Label1.TabIndex = 166
    Me.Label1.Text = "to"
    '
    'TxtListNo
    '
    Me.TxtListNo.Location = New System.Drawing.Point(103, 172)
    Me.TxtListNo.MaxLength = 6
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(42, 20)
    Me.TxtListNo.TabIndex = 5
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(43, 175)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(44, 16)
    Me.Label5.TabIndex = 168
    Me.Label5.Text = "List #"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(151, 175)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(52, 13)
    Me.Label2.TabIndex = 169
    Me.Label2.Text = "(Optional)"
    '
    'FrmTXE06B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(304, 209)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtListNo)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtGLYearTo)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TxtBankCd)
    Me.Controls.Add(Me.LnkBankCd)
    Me.Controls.Add(Me.TxtGLYearFrom)
    Me.Controls.Add(Me.TxtTypes)
    Me.Controls.Add(Me.LnkTypes)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXE06B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTXE06B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXE06.SbpScreen.Text = "TXE06"
End Sub

Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
  MyTypes = TxtTypes.Text
  MyFrmSelTypes = New FrmSelTypes
  MyFrmSelTypes.MdiParent = Me.ParentForm
  MyFrmSelTypes.Show()
  Me.Hide()
End Sub
Private Sub FrmTXE06B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLYearFrom, "")
    ErrProv.SetError(TxtTypes, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "glyear"
        ErrProv.SetError(TxtGLYearFrom, ErrorMsg(I))
      Case "type"
        ErrProv.SetError(TxtTypes, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtGLYearFrom.Text) = 0 Then
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "Year is required"
      I = I + 1
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

Private Sub FrmTXE06B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   MyTypes = ""
  LnkBankCd.Enabled = False
  TxtBankCd.Enabled = False
End Sub
Private Sub TxtGLYearFrom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYearFrom.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtGLYearTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYearTo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LnkBankCd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBankCd.LinkClicked
  MyFrmListBanks = New FrmListBanks
  MyFrmListBanks.MdiParent = Me.ParentForm
  MyFrmListBanks.WrkCode = TxtBankCd.Text
  MyFrmListBanks.Show()

End Sub
Private Sub RbName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbName.Click
  LnkBankCd.Enabled = False
  TxtBankCd.Enabled = False
End Sub
Private Sub RbBank_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbBank.Click
  LnkBankCd.Enabled = True
  TxtBankCd.Enabled = True
End Sub

Private Sub TxtGLYearFrom_TextChanged(sender As Object, e As EventArgs) Handles TxtGLYearFrom.TextChanged

End Sub
End Class






