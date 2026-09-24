Public Class FrmAP730B
    Inherits System.Windows.Forms.Form
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblFilePath As System.Windows.Forms.Label
    Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents ChkResubmit As CheckBox
  Friend WithEvents RbMisc As RadioButton
  Friend WithEvents RbNEC As RadioButton
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip

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
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents label3 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.label3 = New System.Windows.Forms.Label()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ChkResubmit = New System.Windows.Forms.CheckBox()
    Me.RbNEC = New System.Windows.Forms.RadioButton()
    Me.RbMisc = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'label3
    '
    Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label3.Location = New System.Drawing.Point(-100, 74)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(89, 23)
    Me.label3.TabIndex = 6
    Me.label3.Text = "New file name"
    Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LblFilePath)
    Me.GroupBox1.Controls.Add(Me.LnkFilePath)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.ForeColor = System.Drawing.Color.Black
    Me.GroupBox1.Location = New System.Drawing.Point(12, 77)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(408, 65)
    Me.GroupBox1.TabIndex = 6
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "File Details"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(70, 24)
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
    Me.LnkFilePath.TabIndex = 29
    Me.LnkFilePath.TabStop = True
    Me.LnkFilePath.Text = "File Path"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(161, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(105, 13)
    Me.Label1.TabIndex = 7
    Me.Label1.Text = "File Format: 1099"
    '
    'ChkResubmit
    '
    Me.ChkResubmit.AutoSize = True
    Me.ChkResubmit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkResubmit.Location = New System.Drawing.Point(27, 54)
    Me.ChkResubmit.Name = "ChkResubmit"
    Me.ChkResubmit.Size = New System.Drawing.Size(76, 17)
    Me.ChkResubmit.TabIndex = 8
    Me.ChkResubmit.Text = "Resubmit?"
    Me.ChkResubmit.UseVisualStyleBackColor = True
    '
    'RbNEC
    '
    Me.RbNEC.AutoSize = True
    Me.RbNEC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbNEC.Checked = True
    Me.RbNEC.Location = New System.Drawing.Point(152, 31)
    Me.RbNEC.Name = "RbNEC"
    Me.RbNEC.Size = New System.Drawing.Size(47, 17)
    Me.RbNEC.TabIndex = 9
    Me.RbNEC.TabStop = True
    Me.RbNEC.Text = "NEC"
    Me.RbNEC.UseVisualStyleBackColor = True
    '
    'RbMisc
    '
    Me.RbMisc.AutoSize = True
    Me.RbMisc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbMisc.Location = New System.Drawing.Point(221, 31)
    Me.RbMisc.Name = "RbMisc"
    Me.RbMisc.Size = New System.Drawing.Size(47, 17)
    Me.RbMisc.TabIndex = 10
    Me.RbMisc.Text = "Misc"
    Me.RbMisc.UseVisualStyleBackColor = True
    '
    'FrmAP730B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(447, 154)
    Me.ControlBox = False
    Me.Controls.Add(Me.RbMisc)
    Me.Controls.Add(Me.RbNEC)
    Me.Controls.Add(Me.ChkResubmit)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmAP730B"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region
  Private Sub AP730_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        MyFrmAP730.SbpScreen.Text = "AP730B"
        MyUtils.CenterForm(Me.ParentForm, Me)
    End Sub
  Public Sub runData()

    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

'    If RbIrstax.Checked Then
      CreateIrstax()
'    End If
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

    If LblFilePath.Text = "" Then
      ErrorField(I) = "path"
      ErrorMsg(I) = "File Path cannot be blank. Click on link to set."
      I = I + 1
    End If

  End Sub
Private Sub FrmAP730B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub

   If e.KeyCode = Keys.F12 Then
     MyUtils.PrtScreen(Form.ActiveForm)
   End If
End Sub
Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
 With SaveFileDialog1
  .ShowDialog()
  LblFilePath.Text = .FileName
 End With
End Sub
Private Sub FrmAP730B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

End Sub
End Class
