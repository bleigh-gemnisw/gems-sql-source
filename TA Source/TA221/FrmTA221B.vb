Public Class FrmTA221B
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
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
Friend WithEvents GrpFiles As System.Windows.Forms.GroupBox
Friend WithEvents LnkFile As System.Windows.Forms.LinkLabel
Friend WithEvents LblFile As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
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
'GrpFiles
'
Me.GrpFiles.Controls.Add(Me.LblFile)
Me.GrpFiles.Controls.Add(Me.LnkFile)
Me.GrpFiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GrpFiles.Location = New System.Drawing.Point(26, 23)
Me.GrpFiles.Name = "GrpFiles"
Me.GrpFiles.Size = New System.Drawing.Size(408, 50)
Me.GrpFiles.TabIndex = 5
Me.GrpFiles.TabStop = False
Me.GrpFiles.Text = "Purged Files Details"
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
Me.LnkFile.Text = "Transfers"
'
'FrmTA221B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(446, 100)
Me.ControlBox = False
Me.Controls.Add(Me.GrpFiles)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA221B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GrpFiles.ResumeLayout(False)
Me.ResumeLayout(False)

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
    ProcFile()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmTA221B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmTA221.SbpPgmID.Text = "TA221B"
    MyFrmTA221.SbpEnvironment.Text = myDBConnect.PgmDB
    LblFile.Text = MyUtils.GetDataPath() & "TXTRANS.csv"
End Sub
Private Sub FrmTA221B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA221.SbpScreen.Text = "TA221B"
End Sub
Private Sub FrmTA221B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

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
Private Sub FrmTA221B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub

   If e.KeyCode = Keys.F12 Then
     MyUtils.PrtScreen(Form.ActiveForm)
   End If
End Sub
Private Sub TxtGLFromYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtGLToYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFile.LinkClicked
  With SaveFileDialog1
    .Filter = "Comma Seperated Values (csv)|*.csv"
    .ShowDialog()
    If .FileName <> "" Then
      LblFile.Text = .FileName
    End If
  End With
End Sub
Private Sub ChkUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
  GrpFiles.Enabled = Not GrpFiles.Enabled
End Sub
End Class






