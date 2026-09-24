Public Class FrmTO120B
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
Friend WithEvents ChkFrozenFile As System.Windows.Forms.CheckBox
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
Friend WithEvents GrpFiles As System.Windows.Forms.GroupBox
Friend WithEvents LblFile As System.Windows.Forms.Label
Friend WithEvents LnkFile As System.Windows.Forms.LinkLabel
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.ChkFrozenFile = New System.Windows.Forms.CheckBox
Me.TxtGLYear = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
Me.GrpFiles = New System.Windows.Forms.GroupBox
Me.LblFile = New System.Windows.Forms.Label
Me.LnkFile = New System.Windows.Forms.LinkLabel
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GrpFiles.SuspendLayout()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'ChkFrozenFile
'
Me.ChkFrozenFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkFrozenFile.Location = New System.Drawing.Point(24, 44)
Me.ChkFrozenFile.Name = "ChkFrozenFile"
Me.ChkFrozenFile.Size = New System.Drawing.Size(140, 16)
Me.ChkFrozenFile.TabIndex = 55
Me.ChkFrozenFile.Text = "Use Frozen List?"
'
'TxtGLYear
'
Me.TxtGLYear.Location = New System.Drawing.Point(108, 18)
Me.TxtGLYear.MaxLength = 4
Me.TxtGLYear.Name = "TxtGLYear"
Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
Me.TxtGLYear.TabIndex = 50
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(20, 18)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(84, 16)
Me.Label4.TabIndex = 56
Me.Label4.Text = "Grand List Year"
'
'GrpFiles
'
Me.GrpFiles.Controls.Add(Me.LblFile)
Me.GrpFiles.Controls.Add(Me.LnkFile)
Me.GrpFiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GrpFiles.Location = New System.Drawing.Point(12, 76)
Me.GrpFiles.Name = "GrpFiles"
Me.GrpFiles.Size = New System.Drawing.Size(408, 50)
Me.GrpFiles.TabIndex = 57
Me.GrpFiles.TabStop = False
Me.GrpFiles.Text = "DVA File Details"
'
'LblFile
'
Me.LblFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblFile.Location = New System.Drawing.Point(70, 24)
Me.LblFile.Name = "LblFile"
Me.LblFile.Size = New System.Drawing.Size(324, 16)
Me.LblFile.TabIndex = 67
'
'LnkFile
'
Me.LnkFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkFile.Location = New System.Drawing.Point(12, 24)
Me.LnkFile.Name = "LnkFile"
Me.LnkFile.Size = New System.Drawing.Size(52, 16)
Me.LnkFile.TabIndex = 0
Me.LnkFile.TabStop = True
Me.LnkFile.Text = "File"
'
'FrmTO120B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(429, 142)
Me.ControlBox = False
Me.Controls.Add(Me.GrpFiles)
Me.Controls.Add(Me.ChkFrozenFile)
Me.Controls.Add(Me.TxtGLYear)
Me.Controls.Add(Me.Label4)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTO120B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GrpFiles.ResumeLayout(False)
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

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmTO120B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Windows.Forms.Cursor.Current = Cursors.WaitCursor
  BufferExem()
  SetGLYear()
  LblFile.Text = MyUtils.GetDataPath() & "DVA Vets.csv"
  Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub FrmTO120B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTO120.SbpScreen.Text = "TO120B"
End Sub
Private Sub FrmTO120B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLYear, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "glyear"
        ErrProv.SetError(TxtGLYear, ErrorMsg(I))
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim ds As DataSet = New DataSet
    Dim I As Integer
    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtGLYear.Text) = 0 Then
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "Grand List Year is required"
      I = I + 1
    End If

  End Sub
Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub ChkFrozenFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFrozenFile.CheckedChanged

End Sub
Private Sub SetGLYear()
    Dim WrkYear As Integer

    WrkYear = Date.Now.Year
    If Date.Now.Month < 10 Then
      WrkYear = WrkYear - 1
    End If
    TxtGLYear.Text = WrkYear
End Sub
Private Sub LnkFile_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFile.LinkClicked
  With SaveFileDialog1
    .ShowDialog()
    LblFile.Text = .FileName
  End With
End Sub

End Class






