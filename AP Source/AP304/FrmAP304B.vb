Public Class FrmAP304B
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
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbName As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbAbbr As System.Windows.Forms.RadioButton
Friend WithEvents RbFull As System.Windows.Forms.RadioButton
Friend WithEvents GrpDownload As System.Windows.Forms.GroupBox
Friend WithEvents LblFilePath As System.Windows.Forms.Label
Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents RbNumeric As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbName = New System.Windows.Forms.RadioButton()
    Me.RbNumeric = New System.Windows.Forms.RadioButton()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbAbbr = New System.Windows.Forms.RadioButton()
    Me.RbFull = New System.Windows.Forms.RadioButton()
    Me.GrpDownload = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.Label1 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GrpDownload.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbName)
    Me.GroupBox1.Controls.Add(Me.RbNumeric)
    Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox1.Location = New System.Drawing.Point(133, 21)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(109, 63)
    Me.GroupBox1.TabIndex = 2
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
    'RbNumeric
    '
    Me.RbNumeric.AutoSize = True
    Me.RbNumeric.ForeColor = System.Drawing.Color.Black
    Me.RbNumeric.Location = New System.Drawing.Point(17, 40)
    Me.RbNumeric.Name = "RbNumeric"
    Me.RbNumeric.Size = New System.Drawing.Size(64, 17)
    Me.RbNumeric.TabIndex = 1
    Me.RbNumeric.Text = "Numeric"
    Me.RbNumeric.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbAbbr)
    Me.GroupBox2.Controls.Add(Me.RbFull)
    Me.GroupBox2.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox2.Location = New System.Drawing.Point(267, 21)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(109, 63)
    Me.GroupBox2.TabIndex = 3
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Report"
    '
    'RbAbbr
    '
    Me.RbAbbr.AutoSize = True
    Me.RbAbbr.Checked = True
    Me.RbAbbr.ForeColor = System.Drawing.Color.Black
    Me.RbAbbr.Location = New System.Drawing.Point(17, 17)
    Me.RbAbbr.Name = "RbAbbr"
    Me.RbAbbr.Size = New System.Drawing.Size(80, 17)
    Me.RbAbbr.TabIndex = 0
    Me.RbAbbr.TabStop = True
    Me.RbAbbr.Text = "Abbrevated"
    Me.RbAbbr.UseVisualStyleBackColor = True
    '
    'RbFull
    '
    Me.RbFull.AutoSize = True
    Me.RbFull.ForeColor = System.Drawing.Color.Black
    Me.RbFull.Location = New System.Drawing.Point(17, 40)
    Me.RbFull.Name = "RbFull"
    Me.RbFull.Size = New System.Drawing.Size(41, 17)
    Me.RbFull.TabIndex = 1
    Me.RbFull.Text = "Full"
    Me.RbFull.UseVisualStyleBackColor = True
    '
    'GrpDownload
    '
    Me.GrpDownload.Controls.Add(Me.LblFilePath)
    Me.GrpDownload.Controls.Add(Me.LnkFilePath)
    Me.GrpDownload.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpDownload.ForeColor = System.Drawing.Color.Black
    Me.GrpDownload.Location = New System.Drawing.Point(22, 115)
    Me.GrpDownload.Name = "GrpDownload"
    Me.GrpDownload.Size = New System.Drawing.Size(420, 55)
    Me.GrpDownload.TabIndex = 6
    Me.GrpDownload.TabStop = False
    Me.GrpDownload.Text = "Download CSV file to PC"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(68, 16)
    Me.LblFilePath.Name = "LblFilePath"
    Me.LblFilePath.Size = New System.Drawing.Size(346, 36)
    Me.LblFilePath.TabIndex = 67
    '
    'LnkFilePath
    '
    Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePath.Location = New System.Drawing.Point(10, 16)
    Me.LnkFilePath.Name = "LnkFilePath"
    Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath.TabIndex = 0
    Me.LnkFilePath.TabStop = True
    Me.LnkFilePath.Text = "File Path"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(231, 99)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(35, 13)
    Me.Label1.TabIndex = 7
    Me.Label1.Text = "- OR -"
    '
    'FrmAP304B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(467, 194)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.GrpDownload)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmAP304B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GrpDownload.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmAP304B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmAP304.SbpScreen.Text = "AP304"
End Sub
Private Sub FrmAP304B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
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

  Windows.Forms.Cursor.Current = Cursors.WaitCursor
  PrtReport()
  Windows.Forms.Cursor.Current = Cursors.Default
End Sub
Private Sub LnkFilePath_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
  With SaveFileDialog1
    .ShowDialog()
    LblFilePath.Text = .FileName
  End With
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      End Select
    Next I

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
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

End Sub

End Class
