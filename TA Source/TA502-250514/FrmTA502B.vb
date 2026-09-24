Public Class FrmTA502B
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
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents GrpSave As System.Windows.Forms.GroupBox
Friend WithEvents LblFileSave As System.Windows.Forms.Label
Friend WithEvents LnkFileSave As System.Windows.Forms.LinkLabel
Friend WithEvents RbSave As System.Windows.Forms.RadioButton
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
Friend WithEvents GrpRestore As System.Windows.Forms.GroupBox
Friend WithEvents LblFileRestore As System.Windows.Forms.Label
Friend WithEvents LnkFileRestore As System.Windows.Forms.LinkLabel
Friend WithEvents RbRestore As System.Windows.Forms.RadioButton
Friend WithEvents ChkClear As System.Windows.Forms.CheckBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtStartNo As System.Windows.Forms.TextBox
Friend WithEvents ChkOnlyDMVCust As System.Windows.Forms.CheckBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TxtMinVal As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GrpFile = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.TxtMinVal = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GrpSave = New System.Windows.Forms.GroupBox()
    Me.LblFileSave = New System.Windows.Forms.Label()
    Me.LnkFileSave = New System.Windows.Forms.LinkLabel()
    Me.RbSave = New System.Windows.Forms.RadioButton()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.RbRestore = New System.Windows.Forms.RadioButton()
    Me.GrpRestore = New System.Windows.Forms.GroupBox()
    Me.LblFileRestore = New System.Windows.Forms.Label()
    Me.LnkFileRestore = New System.Windows.Forms.LinkLabel()
    Me.ChkClear = New System.Windows.Forms.CheckBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtStartNo = New System.Windows.Forms.TextBox()
    Me.ChkOnlyDMVCust = New System.Windows.Forms.CheckBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpFile.SuspendLayout()
    Me.GrpSave.SuspendLayout()
    Me.GrpRestore.SuspendLayout()
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
    Me.GrpFile.Location = New System.Drawing.Point(15, 109)
    Me.GrpFile.Name = "GrpFile"
    Me.GrpFile.Size = New System.Drawing.Size(408, 56)
    Me.GrpFile.TabIndex = 3
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
    'TxtMinVal
    '
    Me.TxtMinVal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMinVal.Location = New System.Drawing.Point(164, 25)
    Me.TxtMinVal.MaxLength = 6
    Me.TxtMinVal.Name = "TxtMinVal"
    Me.TxtMinVal.Size = New System.Drawing.Size(56, 20)
    Me.TxtMinVal.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 28)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(137, 13)
    Me.Label1.TabIndex = 68
    Me.Label1.Text = "Minimum Assessment Value"
    '
    'GrpSave
    '
    Me.GrpSave.Controls.Add(Me.LblFileSave)
    Me.GrpSave.Controls.Add(Me.LnkFileSave)
    Me.GrpSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpSave.Location = New System.Drawing.Point(125, 171)
    Me.GrpSave.Name = "GrpSave"
    Me.GrpSave.Size = New System.Drawing.Size(408, 56)
    Me.GrpSave.TabIndex = 5
    Me.GrpSave.TabStop = False
    Me.GrpSave.Text = "Save MV File Details (optional)"
    '
    'LblFileSave
    '
    Me.LblFileSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFileSave.Location = New System.Drawing.Point(72, 16)
    Me.LblFileSave.Name = "LblFileSave"
    Me.LblFileSave.Size = New System.Drawing.Size(324, 36)
    Me.LblFileSave.TabIndex = 67
    '
    'LnkFileSave
    '
    Me.LnkFileSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFileSave.Location = New System.Drawing.Point(6, 25)
    Me.LnkFileSave.Name = "LnkFileSave"
    Me.LnkFileSave.Size = New System.Drawing.Size(52, 16)
    Me.LnkFileSave.TabIndex = 65
    Me.LnkFileSave.TabStop = True
    Me.LnkFileSave.Text = "File Path"
    '
    'RbSave
    '
    Me.RbSave.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSave.Checked = True
    Me.RbSave.Location = New System.Drawing.Point(15, 192)
    Me.RbSave.Name = "RbSave"
    Me.RbSave.Size = New System.Drawing.Size(100, 20)
    Me.RbSave.TabIndex = 4
    Me.RbSave.TabStop = True
    Me.RbSave.Text = "Save MV File"
    Me.RbSave.UseVisualStyleBackColor = True
    '
    'RbRestore
    '
    Me.RbRestore.AutoSize = True
    Me.RbRestore.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbRestore.Location = New System.Drawing.Point(15, 261)
    Me.RbRestore.Name = "RbRestore"
    Me.RbRestore.Size = New System.Drawing.Size(100, 17)
    Me.RbRestore.TabIndex = 6
    Me.RbRestore.Text = "Restore MV File"
    Me.RbRestore.UseVisualStyleBackColor = True
    '
    'GrpRestore
    '
    Me.GrpRestore.Controls.Add(Me.LblFileRestore)
    Me.GrpRestore.Controls.Add(Me.LnkFileRestore)
    Me.GrpRestore.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpRestore.Location = New System.Drawing.Point(125, 238)
    Me.GrpRestore.Name = "GrpRestore"
    Me.GrpRestore.Size = New System.Drawing.Size(408, 56)
    Me.GrpRestore.TabIndex = 7
    Me.GrpRestore.TabStop = False
    Me.GrpRestore.Text = "Restore MV File Details"
    '
    'LblFileRestore
    '
    Me.LblFileRestore.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFileRestore.Location = New System.Drawing.Point(72, 16)
    Me.LblFileRestore.Name = "LblFileRestore"
    Me.LblFileRestore.Size = New System.Drawing.Size(324, 36)
    Me.LblFileRestore.TabIndex = 67
    '
    'LnkFileRestore
    '
    Me.LnkFileRestore.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFileRestore.Location = New System.Drawing.Point(6, 25)
    Me.LnkFileRestore.Name = "LnkFileRestore"
    Me.LnkFileRestore.Size = New System.Drawing.Size(52, 16)
    Me.LnkFileRestore.TabIndex = 65
    Me.LnkFileRestore.TabStop = True
    Me.LnkFileRestore.Text = "File Path"
    '
    'ChkClear
    '
    Me.ChkClear.AutoSize = True
    Me.ChkClear.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkClear.Checked = True
    Me.ChkClear.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkClear.Location = New System.Drawing.Point(12, 303)
    Me.ChkClear.Name = "ChkClear"
    Me.ChkClear.Size = New System.Drawing.Size(369, 17)
    Me.ChkClear.TabIndex = 8
    Me.ChkClear.Text = "Replace Suppl MV file? If unchecked, file will be appended to Suppl MV "
    Me.ChkClear.UseVisualStyleBackColor = True
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(50, 63)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(103, 13)
    Me.Label2.TabIndex = 76
    Me.Label2.Text = "Staring List Number*"
    '
    'TxtStartNo
    '
    Me.TxtStartNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtStartNo.Location = New System.Drawing.Point(164, 60)
    Me.TxtStartNo.MaxLength = 6
    Me.TxtStartNo.Name = "TxtStartNo"
    Me.TxtStartNo.Size = New System.Drawing.Size(56, 20)
    Me.TxtStartNo.TabIndex = 1
    '
    'ChkOnlyDMVCust
    '
    Me.ChkOnlyDMVCust.AutoSize = True
    Me.ChkOnlyDMVCust.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkOnlyDMVCust.Location = New System.Drawing.Point(12, 326)
    Me.ChkOnlyDMVCust.Name = "ChkOnlyDMVCust"
    Me.ChkOnlyDMVCust.Size = New System.Drawing.Size(229, 17)
    Me.ChkOnlyDMVCust.TabIndex = 83
    Me.ChkOnlyDMVCust.Text = "ONLY Refresh DMV Customer Vehicle file?"
    Me.ChkOnlyDMVCust.UseVisualStyleBackColor = True
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.ForeColor = System.Drawing.Color.Black
    Me.Label3.Location = New System.Drawing.Point(12, 364)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(419, 17)
    Me.Label3.TabIndex = 82
    Me.Label3.Text = "* NOTICE: DMV File is unsorted. Run Resequence program next. "
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(109, 5)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(293, 17)
    Me.Label4.TabIndex = 84
    Me.Label4.Text = "ONLY Class 1,2,3,4 & 12 will be priced "
    Me.Label4.UseMnemonic = False
    '
    'FrmTA502B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(545, 391)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.ChkOnlyDMVCust)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtStartNo)
    Me.Controls.Add(Me.ChkClear)
    Me.Controls.Add(Me.GrpRestore)
    Me.Controls.Add(Me.RbRestore)
    Me.Controls.Add(Me.RbSave)
    Me.Controls.Add(Me.GrpSave)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtMinVal)
    Me.Controls.Add(Me.GrpFile)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA502B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpFile.ResumeLayout(False)
    Me.GrpSave.ResumeLayout(False)
    Me.GrpRestore.ResumeLayout(False)
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
Private Sub FrmTA502B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmTA502.SbpPgmID.Text = "TA502B"
    MyFrmTA502.SbpEnvironment.Text = myDBConnect.PgmDB
    TxtStartNo.Text = "10000"
    LblFilePath.Text = ""
    GrpRestore.Enabled = False
  End Sub
Private Sub FrmTA502B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA502.SbpScreen.Text = "TA502B"
End Sub
Private Sub FrmTA502B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    ErrProv.SetError(LblFilePath, "")
    ErrProv.SetError(LblFileRestore, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "path"
        ErrProv.SetError(LblFilePath, ErrorMsg(I))
      Case "restore"
        ErrProv.SetError(LblFileRestore, ErrorMsg(I))
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

    If RbSave.Checked Then
      If LblFilePath.Text = "" Then
        ErrorField(I) = "path"
        ErrorMsg(I) = "File Path cannot be blank. Click on link to set."
        I = I + 1
      End If
    Else
      If LblFileRestore.Text = "" Then
        ErrorField(I) = "restore"
        ErrorMsg(I) = "File Restore Path cannot be blank. Click on link to set."
        I = I + 1
      End If
    End If

  End Sub
Private Sub FrmTA502B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

Private Sub LnkFileSave_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFileSave.LinkClicked
  With SaveFileDialog1
    .Filter = "Comma Seperated Values (csv)|*.csv"
    .ShowDialog()
    LblFileSave.Text = .FileName
  End With
End Sub
Private Sub TxtMinVal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMinVal.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub LnkFileRestore_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFileRestore.LinkClicked
  With OpenFileDialog1
    .Filter = "Comma Seperated Values (csv)|*.csv"
    .ShowDialog()
    LblFileRestore.Text = .FileName
  End With
End Sub
Private Sub RbSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSave.Click
  GrpRestore.Enabled = False
  GrpSave.Enabled = True
  GrpFile.Enabled = True
  TxtMinVal.Enabled = True
  MyFrmTA502.Text = "Install New Suppl. MV File"
End Sub
Private Sub RbRestore_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbRestore.Click
  GrpRestore.Enabled = True
  GrpSave.Enabled = False
  GrpFile.Enabled = False
  TxtMinVal.Enabled = False
  MyFrmTA502.Text = "Restore Suppl. MV File"
End Sub
  Private Sub ChkOnlyDMVCust_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkOnlyDMVCust.Click
    TxtMinVal.Enabled = Not TxtMinVal.Enabled
    TxtStartNo.Enabled = Not TxtStartNo.Enabled
    RbSave.Enabled = Not RbSave.Enabled
    RbRestore.Enabled = Not RbRestore.Enabled
    GrpSave.Enabled = Not GrpSave.Enabled
    ChkClear.Enabled = Not ChkClear.Enabled
  End Sub
End Class






