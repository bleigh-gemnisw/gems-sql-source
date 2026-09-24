Public Class FrmTO202B
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
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
Friend WithEvents TxtYear As System.Windows.Forms.TextBox
Friend WithEvents TxtClaimNo As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents LblOPMFile As System.Windows.Forms.Label
Friend WithEvents RbOnly As System.Windows.Forms.RadioButton
Friend WithEvents RbPrev As System.Windows.Forms.RadioButton
Friend WithEvents LblFilePath As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.LblFilePath = New System.Windows.Forms.Label
Me.LnkFilePath = New System.Windows.Forms.LinkLabel
Me.TxtYear = New System.Windows.Forms.TextBox
Me.TxtClaimNo = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.LblOPMFile = New System.Windows.Forms.Label
Me.RbPrev = New System.Windows.Forms.RadioButton
Me.RbOnly = New System.Windows.Forms.RadioButton
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.LblFilePath)
Me.GroupBox1.Controls.Add(Me.LnkFilePath)
Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox1.Location = New System.Drawing.Point(12, 139)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(408, 72)
Me.GroupBox1.TabIndex = 3
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
Me.LnkFilePath.TabIndex = 8
Me.LnkFilePath.TabStop = True
Me.LnkFilePath.Text = "File Path"
'
'TxtYear
'
Me.TxtYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtYear.Location = New System.Drawing.Point(124, 23)
Me.TxtYear.MaxLength = 4
Me.TxtYear.Name = "TxtYear"
Me.TxtYear.Size = New System.Drawing.Size(39, 20)
Me.TxtYear.TabIndex = 0
'
'TxtClaimNo
'
Me.TxtClaimNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtClaimNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtClaimNo.Location = New System.Drawing.Point(124, 49)
Me.TxtClaimNo.MaxLength = 1
Me.TxtClaimNo.Name = "TxtClaimNo"
Me.TxtClaimNo.Size = New System.Drawing.Size(18, 20)
Me.TxtClaimNo.TabIndex = 1
'
'Label1
'
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.Location = New System.Drawing.Point(33, 23)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(85, 20)
Me.Label1.TabIndex = 186
Me.Label1.Text = "Grand List Year"
'
'Label2
'
Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label2.Location = New System.Drawing.Point(33, 49)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(85, 20)
Me.Label2.TabIndex = 187
Me.Label2.Text = "Claim No"
'
'LblOPMFile
'
Me.LblOPMFile.AutoSize = True
Me.LblOPMFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblOPMFile.Location = New System.Drawing.Point(12, 224)
Me.LblOPMFile.Name = "LblOPMFile"
Me.LblOPMFile.Size = New System.Drawing.Size(273, 17)
Me.LblOPMFile.TabIndex = 188
Me.LblOPMFile.Text = "OPM requires that uploaded file is named "
'
'RbPrev
'
Me.RbPrev.AutoSize = True
Me.RbPrev.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbPrev.Checked = True
Me.RbPrev.Location = New System.Drawing.Point(36, 81)
Me.RbPrev.Name = "RbPrev"
Me.RbPrev.Size = New System.Drawing.Size(133, 17)
Me.RbPrev.TabIndex = 189
Me.RbPrev.TabStop = True
Me.RbPrev.Text = "G/L Year and previous"
Me.RbPrev.UseVisualStyleBackColor = True
'
'RbOnly
'
Me.RbOnly.AutoSize = True
Me.RbOnly.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbOnly.Location = New System.Drawing.Point(193, 81)
Me.RbOnly.Name = "RbOnly"
Me.RbOnly.Size = New System.Drawing.Size(101, 17)
Me.RbOnly.TabIndex = 190
Me.RbOnly.Text = "G/L Year ONLY"
Me.RbOnly.UseVisualStyleBackColor = True
'
'FrmTO202B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(454, 256)
Me.ControlBox = False
Me.Controls.Add(Me.RbOnly)
Me.Controls.Add(Me.RbPrev)
Me.Controls.Add(Me.LblOPMFile)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtClaimNo)
Me.Controls.Add(Me.TxtYear)
Me.Controls.Add(Me.GroupBox1)
Me.KeyPreview = True
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTO202B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
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
Private Sub FrmTO202B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Dim WrkTownNo As String

  MyFrmTO202.SbpPgmID.Text = "TO202B"
  MyFrmTO202.SbpEnvironment.Text = myDBConnect.PgmDB
  WrkTownNo = Format(myTOWN._TOWNBR, "000")
  TxtClaimNo.Text = "1"
  LblFilePath.Text = MyUtils.GetDataPath() & "M35_" & WrkTownNo & "01.dat"
  LblOPMFile.Text = LblOPMFile.Text & " M35_" & WrkTownNo & "01.dat"
End Sub
Private Sub FrmTO202B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTO202.SbpScreen.Text = "TO202B"
End Sub
Private Sub FrmTO202B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtYear, "")
    ErrProv.SetError(LblFilePath, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "year"
        ErrProv.SetError(TxtYear, ErrorMsg(I))
      Case "file"
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

    If MyUtils.CnvSng(TxtYear.Text) = 0 Then
      ErrorField(I) = "year"
      ErrorMsg(I) = "Year is required"
      I = I + 1
    End If
    If LblFilePath.Text = String.Empty Then
      ErrorField(I) = "file"
      ErrorMsg(I) = "File Path is required"
      I = I + 1
    End If

  End Sub
Private Sub FrmTO202B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub

   If e.KeyCode = Keys.F12 Then
     MyUtils.PrtScreen(Form.ActiveForm)
   End If
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
  With SaveFileDialog1
    .ShowDialog()
    LblFilePath.Text = .FileName
  End With
End Sub
End Class






