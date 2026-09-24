Public Class FrmTAP24B
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
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
Friend WithEvents RBFileAll As System.Windows.Forms.RadioButton
Friend WithEvents RbFileNon As System.Windows.Forms.RadioButton
Friend WithEvents RbFileLate As System.Windows.Forms.RadioButton
Friend WithEvents RbFileExt As System.Windows.Forms.RadioButton
Friend WithEvents RbFileOntime As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
Friend WithEvents RbStatAll As System.Windows.Forms.RadioButton
Friend WithEvents RbStatIncr As System.Windows.Forms.RadioButton
Friend WithEvents RbStatInact As System.Windows.Forms.RadioButton
Friend WithEvents RbStatPend As System.Windows.Forms.RadioButton
Friend WithEvents RbStatActive As System.Windows.Forms.RadioButton
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTAP24B))
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.RbFileNon = New System.Windows.Forms.RadioButton()
    Me.RbFileLate = New System.Windows.Forms.RadioButton()
    Me.RbFileExt = New System.Windows.Forms.RadioButton()
    Me.RbFileOntime = New System.Windows.Forms.RadioButton()
    Me.RBFileAll = New System.Windows.Forms.RadioButton()
    Me.GroupBox7 = New System.Windows.Forms.GroupBox()
    Me.RbStatIncr = New System.Windows.Forms.RadioButton()
    Me.RbStatInact = New System.Windows.Forms.RadioButton()
    Me.RbStatPend = New System.Windows.Forms.RadioButton()
    Me.RbStatActive = New System.Windows.Forms.RadioButton()
    Me.RbStatAll = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox6.SuspendLayout()
    Me.GroupBox7.SuspendLayout()
    Me.SuspendLayout()
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    '
    'TxtGLYear
    '
    Me.TxtGLYear.Location = New System.Drawing.Point(217, 25)
    Me.TxtGLYear.MaxLength = 4
    Me.TxtGLYear.Name = "TxtGLYear"
    Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtGLYear.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(129, 29)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(84, 16)
    Me.Label4.TabIndex = 11
    Me.Label4.Text = "Grand List Year"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox6
    '
    Me.GroupBox6.Controls.Add(Me.RBFileAll)
    Me.GroupBox6.Controls.Add(Me.RbFileNon)
    Me.GroupBox6.Controls.Add(Me.RbFileLate)
    Me.GroupBox6.Controls.Add(Me.RbFileExt)
    Me.GroupBox6.Controls.Add(Me.RbFileOntime)
    Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox6.Location = New System.Drawing.Point(12, 60)
    Me.GroupBox6.Name = "GroupBox6"
    Me.GroupBox6.Size = New System.Drawing.Size(354, 36)
    Me.GroupBox6.TabIndex = 220
    Me.GroupBox6.TabStop = False
    '
    'RbFileNon
    '
    Me.RbFileNon.AutoSize = True
    Me.RbFileNon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFileNon.Location = New System.Drawing.Point(278, 13)
    Me.RbFileNon.Name = "RbFileNon"
    Me.RbFileNon.Size = New System.Drawing.Size(67, 17)
    Me.RbFileNon.TabIndex = 3
    Me.RbFileNon.Text = "Non-Filer"
    '
    'RbFileLate
    '
    Me.RbFileLate.AutoSize = True
    Me.RbFileLate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFileLate.Location = New System.Drawing.Point(216, 13)
    Me.RbFileLate.Name = "RbFileLate"
    Me.RbFileLate.Size = New System.Drawing.Size(46, 17)
    Me.RbFileLate.TabIndex = 2
    Me.RbFileLate.Text = "Late"
    '
    'RbFileExt
    '
    Me.RbFileExt.AutoSize = True
    Me.RbFileExt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFileExt.Location = New System.Drawing.Point(130, 13)
    Me.RbFileExt.Name = "RbFileExt"
    Me.RbFileExt.Size = New System.Drawing.Size(71, 17)
    Me.RbFileExt.TabIndex = 1
    Me.RbFileExt.Text = "Extension"
    '
    'RbFileOntime
    '
    Me.RbFileOntime.AutoSize = True
    Me.RbFileOntime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFileOntime.Location = New System.Drawing.Point(52, 13)
    Me.RbFileOntime.Name = "RbFileOntime"
    Me.RbFileOntime.Size = New System.Drawing.Size(65, 17)
    Me.RbFileOntime.TabIndex = 0
    Me.RbFileOntime.Text = "On Time"
    '
    'RBFileAll
    '
    Me.RBFileAll.AutoSize = True
    Me.RBFileAll.Checked = True
    Me.RBFileAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RBFileAll.Location = New System.Drawing.Point(6, 13)
    Me.RBFileAll.Name = "RBFileAll"
    Me.RBFileAll.Size = New System.Drawing.Size(36, 17)
    Me.RBFileAll.TabIndex = 13
    Me.RBFileAll.Text = "All"
    Me.RBFileAll.UseVisualStyleBackColor = True
    '
    'GroupBox7
    '
    Me.GroupBox7.Controls.Add(Me.RbStatAll)
    Me.GroupBox7.Controls.Add(Me.RbStatIncr)
    Me.GroupBox7.Controls.Add(Me.RbStatInact)
    Me.GroupBox7.Controls.Add(Me.RbStatPend)
    Me.GroupBox7.Controls.Add(Me.RbStatActive)
    Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox7.Location = New System.Drawing.Point(12, 102)
    Me.GroupBox7.Name = "GroupBox7"
    Me.GroupBox7.Size = New System.Drawing.Size(354, 36)
    Me.GroupBox7.TabIndex = 221
    Me.GroupBox7.TabStop = False
    '
    'RbStatIncr
    '
    Me.RbStatIncr.AutoSize = True
    Me.RbStatIncr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbStatIncr.Location = New System.Drawing.Point(126, 10)
    Me.RbStatIncr.Name = "RbStatIncr"
    Me.RbStatIncr.Size = New System.Drawing.Size(66, 17)
    Me.RbStatIncr.TabIndex = 1
    Me.RbStatIncr.Text = "Increase"
    '
    'RbStatInact
    '
    Me.RbStatInact.AutoSize = True
    Me.RbStatInact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbStatInact.Location = New System.Drawing.Point(285, 10)
    Me.RbStatInact.Name = "RbStatInact"
    Me.RbStatInact.Size = New System.Drawing.Size(63, 17)
    Me.RbStatInact.TabIndex = 3
    Me.RbStatInact.Text = "Inactive"
    '
    'RbStatPend
    '
    Me.RbStatPend.AutoSize = True
    Me.RbStatPend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbStatPend.Location = New System.Drawing.Point(208, 10)
    Me.RbStatPend.Name = "RbStatPend"
    Me.RbStatPend.Size = New System.Drawing.Size(64, 17)
    Me.RbStatPend.TabIndex = 2
    Me.RbStatPend.Text = "Pending"
    '
    'RbStatActive
    '
    Me.RbStatActive.AutoSize = True
    Me.RbStatActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbStatActive.Location = New System.Drawing.Point(52, 10)
    Me.RbStatActive.Name = "RbStatActive"
    Me.RbStatActive.Size = New System.Drawing.Size(55, 17)
    Me.RbStatActive.TabIndex = 0
    Me.RbStatActive.Text = "Active"
    '
    'RbStatAll
    '
    Me.RbStatAll.AutoSize = True
    Me.RbStatAll.Checked = True
    Me.RbStatAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbStatAll.Location = New System.Drawing.Point(6, 10)
    Me.RbStatAll.Name = "RbStatAll"
    Me.RbStatAll.Size = New System.Drawing.Size(36, 17)
    Me.RbStatAll.TabIndex = 14
    Me.RbStatAll.Text = "All"
    Me.RbStatAll.UseVisualStyleBackColor = True
    '
    'FrmTAP24B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(378, 149)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox7)
    Me.Controls.Add(Me.GroupBox6)
    Me.Controls.Add(Me.TxtGLYear)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAP24B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox6.ResumeLayout(False)
    Me.GroupBox6.PerformLayout()
    Me.GroupBox7.ResumeLayout(False)
    Me.GroupBox7.PerformLayout()
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
    PrtReportSU()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmTAP24B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTAP24.SbpScreen.Text = "TAP24B"
End Sub
Private Sub FrmTAP24B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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
      ErrorMsg(I) = "Invalid Year"
      I = I + 1
    End If

  End Sub
Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)

End Sub

Private Sub FrmTAP24B_Load(sender As Object, e As EventArgs) Handles MyBase.Load

End Sub
End Class






