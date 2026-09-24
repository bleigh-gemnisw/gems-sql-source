Public Class FrmTX802B
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
Friend WithEvents TxtBankSv As System.Windows.Forms.TextBox
Friend WithEvents LnkBankSvc As System.Windows.Forms.LinkLabel
Friend WithEvents TxtBankCd As System.Windows.Forms.TextBox
Friend WithEvents LnkBankCd As System.Windows.Forms.LinkLabel
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents Chkpost As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.TxtBankSv = New System.Windows.Forms.TextBox()
    Me.LnkBankSvc = New System.Windows.Forms.LinkLabel()
    Me.Chkpost = New System.Windows.Forms.CheckBox()
    Me.TxtBankCd = New System.Windows.Forms.TextBox()
    Me.LnkBankCd = New System.Windows.Forms.LinkLabel()
    Me.Label1 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
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
    Me.GroupBox1.Location = New System.Drawing.Point(15, 100)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(408, 56)
    Me.GroupBox1.TabIndex = 3
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Bank File Details"
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
    'TxtBankSv
    '
    Me.TxtBankSv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBankSv.Location = New System.Drawing.Point(103, 22)
    Me.TxtBankSv.MaxLength = 1
    Me.TxtBankSv.Name = "TxtBankSv"
    Me.TxtBankSv.Size = New System.Drawing.Size(16, 20)
    Me.TxtBankSv.TabIndex = 0
    '
    'LnkBankSvc
    '
    Me.LnkBankSvc.Location = New System.Drawing.Point(12, 26)
    Me.LnkBankSvc.Name = "LnkBankSvc"
    Me.LnkBankSvc.Size = New System.Drawing.Size(80, 16)
    Me.LnkBankSvc.TabIndex = 72
    Me.LnkBankSvc.TabStop = True
    Me.LnkBankSvc.Text = "Bank Service"
    '
    'Chkpost
    '
    Me.Chkpost.AutoSize = True
    Me.Chkpost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.Chkpost.Location = New System.Drawing.Point(15, 77)
    Me.Chkpost.Name = "Chkpost"
    Me.Chkpost.Size = New System.Drawing.Size(104, 17)
    Me.Chkpost.TabIndex = 2
    Me.Chkpost.Text = "Post to billing file"
    Me.Chkpost.UseVisualStyleBackColor = True
    '
    'TxtBankCd
    '
    Me.TxtBankCd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBankCd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBankCd.Location = New System.Drawing.Point(103, 45)
    Me.TxtBankCd.MaxLength = 2
    Me.TxtBankCd.Name = "TxtBankCd"
    Me.TxtBankCd.Size = New System.Drawing.Size(24, 20)
    Me.TxtBankCd.TabIndex = 1
    '
    'LnkBankCd
    '
    Me.LnkBankCd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkBankCd.Location = New System.Drawing.Point(12, 48)
    Me.LnkBankCd.Name = "LnkBankCd"
    Me.LnkBankCd.Size = New System.Drawing.Size(80, 18)
    Me.LnkBankCd.TabIndex = 168
    Me.LnkBankCd.TabStop = True
    Me.LnkBankCd.Text = "Bank code"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(146, 48)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(134, 13)
    Me.Label1.TabIndex = 169
    Me.Label1.Text = "(blank = use code from file)"
    '
    'FrmTX802B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(434, 166)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtBankCd)
    Me.Controls.Add(Me.LnkBankCd)
    Me.Controls.Add(Me.Chkpost)
    Me.Controls.Add(Me.LnkBankSvc)
    Me.Controls.Add(Me.TxtBankSv)
    Me.Controls.Add(Me.GroupBox1)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX802B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
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
Private Sub FrmTX802B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmTX802.SbpPgmID.Text = "TX802B"
    MyFrmTX802.SbpEnvironment.Text = myDBConnect.PgmDB
    LblFilePath.Text = ""

End Sub
Private Sub FrmTX802B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX802.SbpScreen.Text = "TX802B"
End Sub
Private Sub FrmTX802B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
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

    If LblFilePath.Text = "" Then
      ErrorField(I) = "path"
      ErrorMsg(I) = "File Path cannot be blank. Click on link to set."
      I = I + 1
    End If

  End Sub
Private Sub FrmTX802B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

Private Sub LnkBankSvc_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBankSvc.LinkClicked
  MyFrmListBser = New FrmListBser
  MyFrmListBser.MdiParent = Me.ParentForm
  MyFrmListBser.WrkCode = TxtBankSv.Text
  MyFrmListBser.Show()
End Sub
Private Sub LnkBankCd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkBankCd.LinkClicked
  MyFrmListBanks = New FrmListBanks
  MyFrmListBanks.MdiParent = Me.ParentForm
  MyFrmListBanks.WrkCode = TxtBankCd.Text
  MyFrmListBanks.Show()
End Sub
End Class






