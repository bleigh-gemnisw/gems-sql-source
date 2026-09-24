Public Class FrmTX412B
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
Friend WithEvents GrpFile As System.Windows.Forms.GroupBox
Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
Friend WithEvents LblFilePath As System.Windows.Forms.Label
Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
Friend WithEvents ChkPeople As System.Windows.Forms.CheckBox
Friend WithEvents ChkBusiness As System.Windows.Forms.CheckBox
Friend WithEvents RbName As System.Windows.Forms.RadioButton
Friend WithEvents RbAddr As System.Windows.Forms.RadioButton
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GrpFile = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.ChkBusiness = New System.Windows.Forms.CheckBox()
    Me.ChkPeople = New System.Windows.Forms.CheckBox()
    Me.RbAddr = New System.Windows.Forms.RadioButton()
    Me.RbName = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpFile.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GrpFile
    '
    Me.GrpFile.Controls.Add(Me.LblFilePath)
    Me.GrpFile.Controls.Add(Me.LnkFilePath)
    Me.GrpFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpFile.Location = New System.Drawing.Point(12, 87)
    Me.GrpFile.Name = "GrpFile"
    Me.GrpFile.Size = New System.Drawing.Size(408, 56)
    Me.GrpFile.TabIndex = 64
    Me.GrpFile.TabStop = False
    Me.GrpFile.Text = "DMV File Details"
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
    'ChkPost
    '
    Me.ChkPost.AutoSize = True
    Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPost.Location = New System.Drawing.Point(12, 53)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(125, 17)
    Me.ChkPost.TabIndex = 69
    Me.ChkPost.Text = "Post changes to file?"
    Me.ChkPost.UseVisualStyleBackColor = True
    '
    'ChkBusiness
    '
    Me.ChkBusiness.AutoSize = True
    Me.ChkBusiness.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkBusiness.Checked = True
    Me.ChkBusiness.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkBusiness.Location = New System.Drawing.Point(12, 30)
    Me.ChkBusiness.Name = "ChkBusiness"
    Me.ChkBusiness.Size = New System.Drawing.Size(123, 17)
    Me.ChkBusiness.TabIndex = 70
    Me.ChkBusiness.Text = "Include Businesses?"
    Me.ChkBusiness.UseVisualStyleBackColor = True
    '
    'ChkPeople
    '
    Me.ChkPeople.AutoSize = True
    Me.ChkPeople.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPeople.Checked = True
    Me.ChkPeople.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkPeople.Location = New System.Drawing.Point(12, 7)
    Me.ChkPeople.Name = "ChkPeople"
    Me.ChkPeople.Size = New System.Drawing.Size(103, 17)
    Me.ChkPeople.TabIndex = 71
    Me.ChkPeople.Text = "Include People?"
    Me.ChkPeople.UseVisualStyleBackColor = True
    '
    'RbAddr
    '
    Me.RbAddr.AutoSize = True
    Me.RbAddr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbAddr.Checked = True
    Me.RbAddr.Location = New System.Drawing.Point(174, 30)
    Me.RbAddr.Name = "RbAddr"
    Me.RbAddr.Size = New System.Drawing.Size(63, 17)
    Me.RbAddr.TabIndex = 72
    Me.RbAddr.TabStop = True
    Me.RbAddr.Text = "Address"
    Me.RbAddr.UseVisualStyleBackColor = True
    '
    'RbName
    '
    Me.RbName.AutoSize = True
    Me.RbName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbName.Location = New System.Drawing.Point(258, 30)
    Me.RbName.Name = "RbName"
    Me.RbName.Size = New System.Drawing.Size(53, 17)
    Me.RbName.TabIndex = 73
    Me.RbName.Text = "Name"
    Me.RbName.UseVisualStyleBackColor = True
    '
    'FrmTX412B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(438, 153)
    Me.ControlBox = False
    Me.Controls.Add(Me.RbName)
    Me.Controls.Add(Me.RbAddr)
    Me.Controls.Add(Me.ChkPeople)
    Me.Controls.Add(Me.ChkBusiness)
    Me.Controls.Add(Me.ChkPost)
    Me.Controls.Add(Me.GrpFile)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX412B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpFile.ResumeLayout(False)
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
Private Sub FrmTX412B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmTX412.SbpPgmID.Text = "TX412B"
    MyFrmTX412.SbpEnvironment.Text = myDBConnect.PgmDB
    LblFilePath.Text = ""
End Sub
Private Sub FrmTX412B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX412.SbpScreen.Text = "TX412B"
End Sub
Private Sub FrmTX412B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(ChkPeople, "")
    ErrProv.SetError(ChkBusiness, "")
    ErrProv.SetError(LblFilePath, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "check"
        ErrProv.SetError(ChkPeople, ErrorMsg(I))
        ErrProv.SetError(ChkBusiness, ErrorMsg(I))
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

    If Not ChkPeople.Checked And Not ChkBusiness.Checked Then
      ErrorField(I) = "check"
      ErrorMsg(I) = "People and/or business must be checked"
      I = I + 1
    End If

    If LblFilePath.Text = String.Empty Then
      ErrorField(I) = "path"
      ErrorMsg(I) = "path is required"
      I = I + 1
    End If

  End Sub
Private Sub FrmTX412B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
  Private Sub RbAddr_Click(sender As Object, e As EventArgs) Handles RbAddr.Click
    ChkPost.Enabled = True
  End Sub
  Private Sub RbName_Click(sender As Object, e As EventArgs) Handles RbName.Click
    ChkPost.Enabled = False
  End Sub
End Class






