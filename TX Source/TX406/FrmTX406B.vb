Public Class FrmTX406B
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
Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents DtPckAsof As System.Windows.Forms.DateTimePicker
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbBalance As System.Windows.Forms.RadioButton
Friend WithEvents Rb15Year As System.Windows.Forms.RadioButton
Friend WithEvents ChkUpdate As System.Windows.Forms.CheckBox
Friend WithEvents LblWarning As System.Windows.Forms.Label
Friend WithEvents ChkArchive As System.Windows.Forms.CheckBox
Friend WithEvents TxtOmitStatus As System.Windows.Forms.TextBox
Friend WithEvents LnkOmitStatus As System.Windows.Forms.LinkLabel
Friend WithEvents TxtAmount As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.LnkTypes = New System.Windows.Forms.LinkLabel()
    Me.TxtTypes = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.DtPckAsof = New System.Windows.Forms.DateTimePicker()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.TxtAmount = New System.Windows.Forms.TextBox()
    Me.RbBalance = New System.Windows.Forms.RadioButton()
    Me.Rb15Year = New System.Windows.Forms.RadioButton()
    Me.ChkUpdate = New System.Windows.Forms.CheckBox()
    Me.LblWarning = New System.Windows.Forms.Label()
    Me.ChkArchive = New System.Windows.Forms.CheckBox()
    Me.TxtOmitStatus = New System.Windows.Forms.TextBox()
    Me.LnkOmitStatus = New System.Windows.Forms.LinkLabel()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtGLYear
    '
    Me.TxtGLYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGLYear.Location = New System.Drawing.Point(192, 122)
    Me.TxtGLYear.MaxLength = 4
    Me.TxtGLYear.Name = "TxtGLYear"
    Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtGLYear.TabIndex = 2
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(20, 125)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(160, 19)
    Me.Label3.TabIndex = 48
    Me.Label3.Text = "Latest Grand List To Purge"
    '
    'LnkTypes
    '
    Me.LnkTypes.AutoSize = True
    Me.LnkTypes.Location = New System.Drawing.Point(20, 150)
    Me.LnkTypes.Name = "LnkTypes"
    Me.LnkTypes.Size = New System.Drawing.Size(69, 13)
    Me.LnkTypes.TabIndex = 3
    Me.LnkTypes.TabStop = True
    Me.LnkTypes.Text = "Select Types"
    '
    'TxtTypes
    '
    Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTypes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTypes.Location = New System.Drawing.Point(121, 147)
    Me.TxtTypes.MaxLength = 20
    Me.TxtTypes.Name = "TxtTypes"
    Me.TxtTypes.Size = New System.Drawing.Size(129, 20)
    Me.TxtTypes.TabIndex = 4
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(20, 98)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(166, 20)
    Me.Label5.TabIndex = 185
    Me.Label5.Text = "Latest Payment Date To Purge"
    '
    'DtPckAsof
    '
    Me.DtPckAsof.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckAsof.Location = New System.Drawing.Point(192, 98)
    Me.DtPckAsof.Name = "DtPckAsof"
    Me.DtPckAsof.Size = New System.Drawing.Size(88, 20)
    Me.DtPckAsof.TabIndex = 1
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.TxtAmount)
    Me.GroupBox2.Controls.Add(Me.RbBalance)
    Me.GroupBox2.Controls.Add(Me.Rb15Year)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(23, 12)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(300, 69)
    Me.GroupBox2.TabIndex = 0
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Purge Selection"
    '
    'TxtAmount
    '
    Me.TxtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAmount.Location = New System.Drawing.Point(34, 43)
    Me.TxtAmount.MaxLength = 4
    Me.TxtAmount.Name = "TxtAmount"
    Me.TxtAmount.Size = New System.Drawing.Size(57, 20)
    Me.TxtAmount.TabIndex = 1
    Me.TxtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'RbBalance
    '
    Me.RbBalance.AutoSize = True
    Me.RbBalance.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbBalance.Checked = True
    Me.RbBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbBalance.Location = New System.Drawing.Point(20, 21)
    Me.RbBalance.Name = "RbBalance"
    Me.RbBalance.Size = New System.Drawing.Size(96, 17)
    Me.RbBalance.TabIndex = 0
    Me.RbBalance.TabStop = True
    Me.RbBalance.Text = "Balances up to"
    Me.RbBalance.UseVisualStyleBackColor = True
    '
    'Rb15Year
    '
    Me.Rb15Year.AutoSize = True
    Me.Rb15Year.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.Rb15Year.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Rb15Year.Location = New System.Drawing.Point(180, 21)
    Me.Rb15Year.Name = "Rb15Year"
    Me.Rb15Year.Size = New System.Drawing.Size(93, 17)
    Me.Rb15Year.TabIndex = 2
    Me.Rb15Year.Text = "15 Year Purge"
    Me.Rb15Year.UseVisualStyleBackColor = True
    '
    'ChkUpdate
    '
    Me.ChkUpdate.AutoSize = True
    Me.ChkUpdate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkUpdate.Location = New System.Drawing.Point(23, 205)
    Me.ChkUpdate.Name = "ChkUpdate"
    Me.ChkUpdate.Size = New System.Drawing.Size(91, 17)
    Me.ChkUpdate.TabIndex = 7
    Me.ChkUpdate.Text = "Update Files?"
    Me.ChkUpdate.UseVisualStyleBackColor = True
    '
    'LblWarning
    '
    Me.LblWarning.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblWarning.Location = New System.Drawing.Point(68, 270)
    Me.LblWarning.Name = "LblWarning"
    Me.LblWarning.Size = New System.Drawing.Size(303, 40)
    Me.LblWarning.TabIndex = 186
    Me.LblWarning.Text = "Purged records will be copied to archived files only if selected"
    Me.LblWarning.TextAlign = System.Drawing.ContentAlignment.TopCenter
    Me.LblWarning.Visible = False
    '
    'ChkArchive
    '
    Me.ChkArchive.AutoSize = True
    Me.ChkArchive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkArchive.Location = New System.Drawing.Point(23, 228)
    Me.ChkArchive.Name = "ChkArchive"
    Me.ChkArchive.Size = New System.Drawing.Size(109, 17)
    Me.ChkArchive.TabIndex = 8
    Me.ChkArchive.Text = "Archive old data?"
    Me.ChkArchive.UseVisualStyleBackColor = True
    '
    'TxtOmitStatus
    '
    Me.TxtOmitStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOmitStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOmitStatus.Location = New System.Drawing.Point(121, 172)
    Me.TxtOmitStatus.MaxLength = 20
    Me.TxtOmitStatus.Name = "TxtOmitStatus"
    Me.TxtOmitStatus.Size = New System.Drawing.Size(129, 20)
    Me.TxtOmitStatus.TabIndex = 6
    '
    'LnkOmitStatus
    '
    Me.LnkOmitStatus.AutoSize = True
    Me.LnkOmitStatus.Location = New System.Drawing.Point(20, 175)
    Me.LnkOmitStatus.Name = "LnkOmitStatus"
    Me.LnkOmitStatus.Size = New System.Drawing.Size(94, 13)
    Me.LnkOmitStatus.TabIndex = 5
    Me.LnkOmitStatus.TabStop = True
    Me.LnkOmitStatus.Text = "Omit Status Codes"
    '
    'FrmTX406B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(453, 327)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtOmitStatus)
    Me.Controls.Add(Me.LnkOmitStatus)
    Me.Controls.Add(Me.ChkArchive)
    Me.Controls.Add(Me.LblWarning)
    Me.Controls.Add(Me.ChkUpdate)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.DtPckAsof)
    Me.Controls.Add(Me.TxtTypes)
    Me.Controls.Add(Me.LnkTypes)
    Me.Controls.Add(Me.TxtGLYear)
    Me.Controls.Add(Me.Label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX406B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
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
Private Sub FrmTX406B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmTX406.SbpPgmID.Text = "TX406B"
    MyFrmTX406.SbpEnvironment.Text = myDBConnect.PgmDB
    TxtAmount.Text = "0.00"
End Sub
Private Sub FrmTX406B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX406.SbpScreen.Text = "TX406B"
End Sub
Private Sub FrmTX406B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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

    If MyUtils.CnvSng(TxtGLYear.Text) = 0 Then
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "GL Year is required"
      I = I + 1
    End If

  End Sub
Private Sub FrmTX406B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub

   If e.KeyCode = Keys.F12 Then
     MyUtils.PrtScreen(Form.ActiveForm)
   End If
End Sub
Private Sub TxtGLFromYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtGLToYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
  MyTypes = TxtTypes.Text
  MyFrmSelTypes = New FrmSelTypes
  MyFrmSelTypes.MdiParent = Me.ParentForm
  MyFrmSelTypes.Show()

End Sub
Private Sub TxtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAmount.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub ChkUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkUpdate.Click
  LblWarning.Visible = Not LblWarning.Visible
End Sub
Private Sub LnkOmitStatus_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkOmitStatus.LinkClicked
  MyFrmSelStatus = New FrmSelStatus
  MyFrmSelStatus.MdiParent = Me.ParentForm
  MyFrmSelStatus.WrkField = "Omit"
  MyFrmSelStatus.Show()
End Sub
End Class






