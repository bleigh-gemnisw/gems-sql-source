Public Class FrmFixB
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
  Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
  Friend WithEvents DtPckPost As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtToType As TextBox
  Friend WithEvents LinkLabel1 As LinkLabel
  Friend WithEvents TxtToGLYear As TextBox
  Friend WithEvents Label1 As Label
  Friend WithEvents TxtFromGLYear As TextBox
  Friend WithEvents TxtFromType As TextBox
  Friend WithEvents LnkType As LinkLabel
  Friend WithEvents Label4 As Label
  Friend WithEvents GroupBox1 As GroupBox
  Friend WithEvents LblFilePath As Label
  Friend WithEvents LnkFilePath As LinkLabel
  Friend WithEvents OpenFileDialog1 As OpenFileDialog
  Friend WithEvents Label6 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.DtPckPost = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.LnkType = New System.Windows.Forms.LinkLabel()
    Me.TxtFromType = New System.Windows.Forms.TextBox()
    Me.TxtFromGLYear = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtToGLYear = New System.Windows.Forms.TextBox()
    Me.TxtToType = New System.Windows.Forms.TextBox()
    Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'ChkPost
    '
    Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPost.Location = New System.Drawing.Point(25, 176)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(124, 20)
    Me.ChkPost.TabIndex = 4
    Me.ChkPost.Text = "Post to invoice file?"
    '
    'DtPckPost
    '
    Me.DtPckPost.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckPost.Location = New System.Drawing.Point(106, 144)
    Me.DtPckPost.Name = "DtPckPost"
    Me.DtPckPost.Size = New System.Drawing.Size(84, 20)
    Me.DtPckPost.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(22, 148)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(80, 16)
    Me.Label2.TabIndex = 23
    Me.Label2.Text = "Posting Date*"
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(51, 212)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(189, 28)
    Me.Label5.TabIndex = 345
    Me.Label5.Text = "*Accounts with activity after the posting date will be skipped"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(21, 7)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(247, 20)
    Me.Label3.TabIndex = 346
    Me.Label3.Text = "Mass Transfer (Match Regno)"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label6
    '
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(12, 251)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(264, 28)
    Me.Label6.TabIndex = 347
    Me.Label6.Text = "*** NOTICE: Fees are NOT handled, use single transfer if there are fees to pay **" &
    "*"
    Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(22, 119)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(72, 16)
    Me.Label4.TabIndex = 11
    Me.Label4.Text = "From Year"
    '
    'LnkType
    '
    Me.LnkType.Location = New System.Drawing.Point(22, 91)
    Me.LnkType.Name = "LnkType"
    Me.LnkType.Size = New System.Drawing.Size(72, 16)
    Me.LnkType.TabIndex = 17
    Me.LnkType.TabStop = True
    Me.LnkType.Text = "From Type"
    '
    'TxtFromType
    '
    Me.TxtFromType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFromType.Location = New System.Drawing.Point(106, 87)
    Me.TxtFromType.MaxLength = 20
    Me.TxtFromType.Name = "TxtFromType"
    Me.TxtFromType.Size = New System.Drawing.Size(16, 20)
    Me.TxtFromType.TabIndex = 0
    Me.TxtFromType.Text = "S"
    '
    'TxtFromGLYear
    '
    Me.TxtFromGLYear.Location = New System.Drawing.Point(106, 115)
    Me.TxtFromGLYear.MaxLength = 4
    Me.TxtFromGLYear.Name = "TxtFromGLYear"
    Me.TxtFromGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtFromGLYear.TabIndex = 1
    Me.TxtFromGLYear.Text = "2021"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(165, 119)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(59, 16)
    Me.Label1.TabIndex = 305
    Me.Label1.Text = "To Year"
    '
    'TxtToGLYear
    '
    Me.TxtToGLYear.Location = New System.Drawing.Point(230, 115)
    Me.TxtToGLYear.MaxLength = 4
    Me.TxtToGLYear.Name = "TxtToGLYear"
    Me.TxtToGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtToGLYear.TabIndex = 2
    Me.TxtToGLYear.Text = "2022"
    '
    'TxtToType
    '
    Me.TxtToType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtToType.Location = New System.Drawing.Point(230, 87)
    Me.TxtToType.MaxLength = 20
    Me.TxtToType.Name = "TxtToType"
    Me.TxtToType.Size = New System.Drawing.Size(16, 20)
    Me.TxtToType.TabIndex = 348
    Me.TxtToType.Text = "M"
    '
    'LinkLabel1
    '
    Me.LinkLabel1.Location = New System.Drawing.Point(165, 91)
    Me.LinkLabel1.Name = "LinkLabel1"
    Me.LinkLabel1.Size = New System.Drawing.Size(59, 16)
    Me.LinkLabel1.TabIndex = 349
    Me.LinkLabel1.TabStop = True
    Me.LinkLabel1.Text = "To Type"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LblFilePath)
    Me.GroupBox1.Controls.Add(Me.LnkFilePath)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(15, 32)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(408, 49)
    Me.GroupBox1.TabIndex = 350
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "List# File"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePath.Name = "LblFilePath"
    Me.LblFilePath.Size = New System.Drawing.Size(324, 24)
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
    'FrmFixB
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(434, 288)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TxtToType)
    Me.Controls.Add(Me.LinkLabel1)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtToGLYear)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.DtPckPost)
    Me.Controls.Add(Me.ChkPost)
    Me.Controls.Add(Me.TxtFromGLYear)
    Me.Controls.Add(Me.TxtFromType)
    Me.Controls.Add(Me.LnkType)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmFixB"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmFixB_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmFix.SbpScreen.Text = "Fix"
  End Sub

  Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
    MyFrmListTypes = New FrmListTypes
    MyFrmListTypes.MdiParent = Me.ParentForm
    MyFrmListTypes.WrkType = TxtFromType.Text
    MyFrmListTypes.Show()
    Me.Hide()
  End Sub
  Private Sub FrmFixB_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFromGLYear, "")
    ErrProv.SetError(TxtToGLYear, "")
    ErrProv.SetError(TxtFromType, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "fromglyear"
          ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
        Case "toglyear"
          ErrProv.SetError(TxtToGLYear, ErrorMsg(I))
        Case "type"
          ErrProv.SetError(TxtFromType, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim WrkFamily As String
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtFromGLYear.Text) = 0 Then
      ErrorField(I) = "fromglyear"
      ErrorMsg(I) = "Invalid From Year"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtToGLYear.Text) = 0 Then
      ErrorField(I) = "toglyear"
      ErrorMsg(I) = "Invalid To Year"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtToGLYear.Text) = MyUtils.CnvSng(TxtFromGLYear.Text) Then
      ErrorField(I) = "toglyear"
      ErrorMsg(I) = "Years cannot be the same"
      I = I + 1
    End If

    If TxtFromType.Text = "" Then
      ErrorField(I) = "type"
      ErrorMsg(I) = "Type is required"
      I = I + 1
    End If

    WrkFamily = GetTXTypeFamily(TxtFromType.Text)
    If WrkFamily = "A" Then
      ErrorField(I) = "type"
      ErrorMsg(I) = "UB Assessment Tax Types are not valid for this option. Run similar option in UB system."
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
    MassXfer()

    'Reset screen to defaults after posting
    If ChkPost.Checked Then
      ChkPost.Checked = False
    End If
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub

  Private Sub FrmFixB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    InitCASHINT()
    InitTXHSTL4()
    DtPckPost.Value = Date.Today
  End Sub
  Private Sub TxtFromGLYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtToGLYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToGLYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub LnkFilePath_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
    With OpenFileDialog1
      .ReadOnlyChecked = True
      .ShowDialog()
      LblFilePath.Text = .FileName
    End With
  End Sub
End Class






