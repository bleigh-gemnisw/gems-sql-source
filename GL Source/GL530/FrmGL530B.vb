Public Class FrmGL530B
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
  Friend WithEvents LblBamt1 As Label
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
    Me.LblBamt1 = New System.Windows.Forms.Label()
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
    Me.GrpFile.Location = New System.Drawing.Point(12, 46)
    Me.GrpFile.Name = "GrpFile"
    Me.GrpFile.Size = New System.Drawing.Size(408, 56)
    Me.GrpFile.TabIndex = 64
    Me.GrpFile.TabStop = False
    Me.GrpFile.Text = "File Details (GL650 CSV)"
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
    Me.ChkPost.Location = New System.Drawing.Point(12, 12)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(125, 17)
    Me.ChkPost.TabIndex = 69
    Me.ChkPost.Text = "Post changes to file?"
    Me.ChkPost.UseVisualStyleBackColor = True
    '
    'LblBamt1
    '
    Me.LblBamt1.AutoSize = True
    Me.LblBamt1.Location = New System.Drawing.Point(13, 123)
    Me.LblBamt1.Name = "LblBamt1"
    Me.LblBamt1.Size = New System.Drawing.Size(49, 13)
    Me.LblBamt1.TabIndex = 70
    Me.LblBamt1.Text = "<Bamt1>"
    '
    'FrmGL530B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(438, 148)
    Me.ControlBox = False
    Me.Controls.Add(Me.LblBamt1)
    Me.Controls.Add(Me.ChkPost)
    Me.Controls.Add(Me.GrpFile)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL530B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpFile.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region
  Dim MyGLHEAD As GLHEAD.MyData

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
  Private Sub FrmGL530B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyGLHEAD = New GLHEAD.MyData
    MyGLHEAD.MyDBConn = myDBConnect
    MyFrmGL530.SbpPgmID.Text = "GL530B"
    MyFrmGL530.SbpEnvironment.Text = myDBConnect.PgmDB
    LblFilePath.Text = ""

    With MyGLHEAD
      .GetOneRecordP(0, 0)
      LblBamt1.Text = "Updates " & Trim(._BUDA1)
    End With
  End Sub
  Private Sub FrmGL530B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGL530.SbpScreen.Text = "GL530B"
  End Sub
  Private Sub FrmGL530B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(LblFilePath, "")

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

    If LblFilePath.Text = String.Empty Then
      ErrorField(I) = "path"
      ErrorMsg(I) = "path is required"
      I = I + 1
    End If

  End Sub
  Private Sub FrmGL530B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
  Private Sub RbAddr_Click(sender As Object, e As EventArgs)
    ChkPost.Enabled = True
  End Sub
  Private Sub RbName_Click(sender As Object, e As EventArgs)
    ChkPost.Enabled = False
  End Sub
End Class
