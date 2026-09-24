Public Class FrmAP530B
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
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
Friend WithEvents LblFilePath As System.Windows.Forms.Label
Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents RbAP As System.Windows.Forms.RadioButton
Friend WithEvents TxtBank As System.Windows.Forms.TextBox
Friend WithEvents ChkUpdate As System.Windows.Forms.CheckBox
Friend WithEvents RbWebster As System.Windows.Forms.RadioButton
Friend WithEvents LnkBank As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.RbWebster = New System.Windows.Forms.RadioButton()
    Me.RbAP = New System.Windows.Forms.RadioButton()
    Me.TxtBank = New System.Windows.Forms.TextBox()
    Me.LnkBank = New System.Windows.Forms.LinkLabel()
    Me.ChkUpdate = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LblFilePath)
    Me.GroupBox1.Controls.Add(Me.LnkFilePath)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(8, 126)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(408, 56)
    Me.GroupBox1.TabIndex = 2
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Reconcile from Bank File"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePath.Name = "LblFilePath"
    Me.LblFilePath.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePath.TabIndex = 67
    '
    'LnkFilePath
    '
    Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePath.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePath.Name = "LnkFilePath"
    Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath.TabIndex = 65
    Me.LnkFilePath.TabStop = True
    Me.LnkFilePath.Text = "File Path"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.RbWebster)
    Me.GroupBox3.Controls.Add(Me.RbAP)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(8, 52)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(179, 52)
    Me.GroupBox3.TabIndex = 68
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "File Format"
    '
    'RbWebster
    '
    Me.RbWebster.AutoSize = True
    Me.RbWebster.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbWebster.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbWebster.Location = New System.Drawing.Point(103, 19)
    Me.RbWebster.Name = "RbWebster"
    Me.RbWebster.Size = New System.Drawing.Size(65, 17)
    Me.RbWebster.TabIndex = 5
    Me.RbWebster.Text = "Webster"
    Me.RbWebster.UseVisualStyleBackColor = True
    '
    'RbAP
    '
    Me.RbAP.AutoSize = True
    Me.RbAP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbAP.Checked = True
    Me.RbAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbAP.Location = New System.Drawing.Point(15, 19)
    Me.RbAP.Name = "RbAP"
    Me.RbAP.Size = New System.Drawing.Size(44, 17)
    Me.RbAP.TabIndex = 4
    Me.RbAP.TabStop = True
    Me.RbAP.Text = "A/P"
    Me.RbAP.UseVisualStyleBackColor = True
    '
    'TxtBank
    '
    Me.TxtBank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBank.Location = New System.Drawing.Point(78, 20)
    Me.TxtBank.MaxLength = 5
    Me.TxtBank.Name = "TxtBank"
    Me.TxtBank.Size = New System.Drawing.Size(48, 20)
    Me.TxtBank.TabIndex = 69
    '
    'LnkBank
    '
    Me.LnkBank.AutoSize = True
    Me.LnkBank.Location = New System.Drawing.Point(12, 23)
    Me.LnkBank.Name = "LnkBank"
    Me.LnkBank.Size = New System.Drawing.Size(60, 13)
    Me.LnkBank.TabIndex = 70
    Me.LnkBank.TabStop = True
    Me.LnkBank.Text = "Bank Code"
    '
    'ChkUpdate
    '
    Me.ChkUpdate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkUpdate.Location = New System.Drawing.Point(8, 196)
    Me.ChkUpdate.Name = "ChkUpdate"
    Me.ChkUpdate.Size = New System.Drawing.Size(64, 19)
    Me.ChkUpdate.TabIndex = 71
    Me.ChkUpdate.Text = "Post?"
    '
    'FrmAP530B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(439, 227)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkUpdate)
    Me.Controls.Add(Me.TxtBank)
    Me.Controls.Add(Me.LnkBank)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GroupBox1)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmAP530B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
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
Private Sub FrmAP530B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmAP530.SbpPgmID.Text = "AP530B"
    MyFrmAP530.SbpEnvironment.Text = myDBConnect.PgmDB
    LblFilePath.Text = ""

End Sub
Private Sub FrmAP530B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmAP530.SbpScreen.Text = "AP530B"
End Sub
Private Sub FrmAP530B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtBank, "")
    ErrProv.SetError(LblFilePath, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "bank"
        ErrProv.SetError(TxtBank, ErrorMsg(I))
      Case "path"
        ErrProv.SetError(LblFilePath, ErrorMsg(I))
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

    If TxtBank.Text = String.Empty Then
      ErrorField(I) = "bank"
      ErrorMsg(I) = "Bank Code is required"
      I = I + 1
    End If

    If LblFilePath.Text = "" Then
      ErrorField(I) = "path"
      ErrorMsg(I) = "File Path cannot be blank. Click on link to set."
      I = I + 1
    End If

  End Sub
Private Sub FrmAP530B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub

   If e.KeyCode = Keys.F12 Then
     MyUtils.PrtScreen(Form.ActiveForm)
   End If
End Sub
Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
  With OpenFileDialog1
    .ReadOnlyChecked = True
    .ShowDialog()
    LblFilePath.Text = .FileName
  End With
End Sub
Private Sub LnkBank_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBank.LinkClicked
 MyFrmListApebnk = New FrmListApebnk
 MyFrmListApebnk.TxtPos.Text = TxtBank.Text
 MyFrmListApebnk.MdiParent = Me.ParentForm
 MyFrmListApebnk.Show()
End Sub
End Class
