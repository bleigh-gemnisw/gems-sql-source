Public Class FrmTA901B
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
  Friend WithEvents label3 As System.Windows.Forms.Label
  Friend WithEvents ChkNoAssmnt As System.Windows.Forms.CheckBox
  Friend WithEvents ChkTrans As System.Windows.Forms.CheckBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtDist As System.Windows.Forms.TextBox
  Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
  Friend WithEvents ChkFrozenFile As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents ChkHeadings As System.Windows.Forms.CheckBox
  Friend WithEvents RbCSV As System.Windows.Forms.RadioButton
  Friend WithEvents RbFixed As System.Windows.Forms.RadioButton
  Friend WithEvents ChkAll As System.Windows.Forms.CheckBox
  Friend WithEvents GrpDownload As GroupBox
  Friend WithEvents LblFilePath As Label
  Friend WithEvents LnkFilePath As LinkLabel
  Friend WithEvents ErrProv As ErrorProvider
  Friend WithEvents ChkPDist As System.Windows.Forms.CheckBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.label3 = New System.Windows.Forms.Label()
    Me.ChkNoAssmnt = New System.Windows.Forms.CheckBox()
    Me.ChkTrans = New System.Windows.Forms.CheckBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.ChkPDist = New System.Windows.Forms.CheckBox()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.ChkFrozenFile = New System.Windows.Forms.CheckBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.ChkAll = New System.Windows.Forms.CheckBox()
    Me.ChkHeadings = New System.Windows.Forms.CheckBox()
    Me.RbCSV = New System.Windows.Forms.RadioButton()
    Me.RbFixed = New System.Windows.Forms.RadioButton()
    Me.GrpDownload = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox1.SuspendLayout()
    Me.GrpDownload.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'label3
    '
    Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label3.Location = New System.Drawing.Point(-100, 74)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(92, 23)
    Me.label3.TabIndex = 6
    Me.label3.Text = "New file name"
    Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'ChkNoAssmnt
    '
    Me.ChkNoAssmnt.AutoSize = True
    Me.ChkNoAssmnt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkNoAssmnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkNoAssmnt.Location = New System.Drawing.Point(78, 38)
    Me.ChkNoAssmnt.Name = "ChkNoAssmnt"
    Me.ChkNoAssmnt.Size = New System.Drawing.Size(238, 17)
    Me.ChkNoAssmnt.TabIndex = 0
    Me.ChkNoAssmnt.Text = "Remove Assessment Exemption Information?"
    '
    'ChkTrans
    '
    Me.ChkTrans.AutoSize = True
    Me.ChkTrans.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkTrans.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkTrans.Location = New System.Drawing.Point(78, 60)
    Me.ChkTrans.Name = "ChkTrans"
    Me.ChkTrans.Size = New System.Drawing.Size(201, 17)
    Me.ChkTrans.TabIndex = 1
    Me.ChkTrans.Text = "Update file with Transfer information?"
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(76, 128)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(203, 19)
    Me.Label1.TabIndex = 12
    Me.Label1.Text = "For a Specific District, enter the District"
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(285, 125)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(32, 20)
    Me.TxtDist.TabIndex = 2
    '
    'ChkPDist
    '
    Me.ChkPDist.AutoSize = True
    Me.ChkPDist.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkPDist.Location = New System.Drawing.Point(323, 128)
    Me.ChkPDist.Name = "ChkPDist"
    Me.ChkPDist.Size = New System.Drawing.Size(128, 17)
    Me.ChkPDist.TabIndex = 3
    Me.ChkPDist.Text = "Use the Print District?"
    '
    'ChkFrozenFile
    '
    Me.ChkFrozenFile.AutoSize = True
    Me.ChkFrozenFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkFrozenFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkFrozenFile.Location = New System.Drawing.Point(79, 160)
    Me.ChkFrozenFile.Name = "ChkFrozenFile"
    Me.ChkFrozenFile.Size = New System.Drawing.Size(105, 17)
    Me.ChkFrozenFile.TabIndex = 4
    Me.ChkFrozenFile.Text = "Use Frozen List?"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.ChkAll)
    Me.GroupBox1.Controls.Add(Me.ChkHeadings)
    Me.GroupBox1.Controls.Add(Me.RbCSV)
    Me.GroupBox1.Controls.Add(Me.RbFixed)
    Me.GroupBox1.Location = New System.Drawing.Point(455, 8)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(175, 112)
    Me.GroupBox1.TabIndex = 13
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "File Format"
    '
    'ChkAll
    '
    Me.ChkAll.AutoSize = True
    Me.ChkAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAll.Location = New System.Drawing.Point(25, 68)
    Me.ChkAll.Name = "ChkAll"
    Me.ChkAll.Size = New System.Drawing.Size(111, 17)
    Me.ChkAll.TabIndex = 21
    Me.ChkAll.Text = "Include All Fields?"
    Me.ChkAll.UseVisualStyleBackColor = True
    '
    'ChkHeadings
    '
    Me.ChkHeadings.AutoSize = True
    Me.ChkHeadings.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkHeadings.Checked = True
    Me.ChkHeadings.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkHeadings.Location = New System.Drawing.Point(25, 89)
    Me.ChkHeadings.Name = "ChkHeadings"
    Me.ChkHeadings.Size = New System.Drawing.Size(140, 17)
    Me.ChkHeadings.TabIndex = 20
    Me.ChkHeadings.Text = "Include Field Headings?"
    Me.ChkHeadings.UseVisualStyleBackColor = True
    '
    'RbCSV
    '
    Me.RbCSV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbCSV.Checked = True
    Me.RbCSV.Location = New System.Drawing.Point(6, 51)
    Me.RbCSV.Name = "RbCSV"
    Me.RbCSV.Size = New System.Drawing.Size(156, 17)
    Me.RbCSV.TabIndex = 19
    Me.RbCSV.TabStop = True
    Me.RbCSV.Text = "Comma Seperated (CSV)"
    Me.RbCSV.UseVisualStyleBackColor = True
    '
    'RbFixed
    '
    Me.RbFixed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbFixed.Location = New System.Drawing.Point(6, 19)
    Me.RbFixed.Name = "RbFixed"
    Me.RbFixed.Size = New System.Drawing.Size(156, 17)
    Me.RbFixed.TabIndex = 18
    Me.RbFixed.Text = "Fixed Length (TXT)"
    Me.RbFixed.UseVisualStyleBackColor = True
    '
    'GrpDownload
    '
    Me.GrpDownload.Controls.Add(Me.LblFilePath)
    Me.GrpDownload.Controls.Add(Me.LnkFilePath)
    Me.GrpDownload.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpDownload.ForeColor = System.Drawing.Color.Black
    Me.GrpDownload.Location = New System.Drawing.Point(12, 192)
    Me.GrpDownload.Name = "GrpDownload"
    Me.GrpDownload.Size = New System.Drawing.Size(420, 46)
    Me.GrpDownload.TabIndex = 14
    Me.GrpDownload.TabStop = False
    Me.GrpDownload.Text = "Download to PC"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(64, 19)
    Me.LblFilePath.Name = "LblFilePath"
    Me.LblFilePath.Size = New System.Drawing.Size(346, 16)
    Me.LblFilePath.TabIndex = 67
    '
    'LnkFilePath
    '
    Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePath.Location = New System.Drawing.Point(6, 19)
    Me.LnkFilePath.Name = "LnkFilePath"
    Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath.TabIndex = 0
    Me.LnkFilePath.TabStop = True
    Me.LnkFilePath.Text = "File Path"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'FrmTA901B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(632, 250)
    Me.ControlBox = False
    Me.Controls.Add(Me.GrpDownload)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.ChkFrozenFile)
    Me.Controls.Add(Me.ChkPDist)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.ChkTrans)
    Me.Controls.Add(Me.ChkNoAssmnt)
    Me.Controls.Add(Me.label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA901B"
    Me.Text = "Export Real Estate Grand List File"
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GrpDownload.ResumeLayout(False)
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub TA901B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA901.SbpScreen.Text = "TA901B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub

  Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
    With SaveFileDialog1
      .ShowDialog()
      LblFilePath.Text = .FileName
    End With

  End Sub
  Public Sub RunExport()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    If MyFrmTA901B.ChkFrozenFile.Checked Then
      ProcFileFrz()
    Else
      ProcFile()
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(ChkTrans, "")
    ErrProv.SetError(LblFilePath, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      End Select
    Next I

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "trans"
          ErrProv.SetError(ChkTrans, ErrorMsg(I))
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

    If MyFrmTA901B.LblFilePath.Text = String.Empty Then
      ErrorField(I) = "path"
      ErrorMsg(I) = "File path cannot be blank"
      I = I + 1
    End If

    If ChkTrans.Checked And ChkFrozenFile.Checked Then
      ErrorField(I) = "trans"
      ErrorMsg(I) = "Frozen file doesn't have any transfers. Uncheck transfers."
      I = I + 1
    End If
  End Sub
  Private Sub RbFixed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbFixed.Click
    GrpDownload.Enabled = True
    ChkHeadings.Enabled = False
  End Sub
  Private Sub RbCSV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbCSV.Click
    GrpDownload.Enabled = True
    ChkHeadings.Enabled = True
  End Sub

  Private Sub FrmTA901B_Load(sender As Object, e As EventArgs) Handles MyBase.Load

  End Sub
End Class
