Public Class FrmTX600B
Inherits System.Windows.Forms.Form
Dim WrkCurrYear As Integer
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtCurrYearSU As System.Windows.Forms.TextBox
Friend WithEvents ChkLockbox As System.Windows.Forms.CheckBox
Dim WrkCurrYearSU As Integer
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
    Friend WithEvents TxtCurrYear As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtBatch As System.Windows.Forms.TextBox
    Friend WithEvents ChkFile As System.Windows.Forms.CheckBox
    Friend WithEvents GrpFile As System.Windows.Forms.GroupBox
    Friend WithEvents LblFilePath As System.Windows.Forms.Label
    Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TxtCurrYear = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.TxtBatch = New System.Windows.Forms.TextBox
Me.ChkFile = New System.Windows.Forms.CheckBox
Me.GrpFile = New System.Windows.Forms.GroupBox
Me.LblFilePath = New System.Windows.Forms.Label
Me.LnkFilePath = New System.Windows.Forms.LinkLabel
Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Label3 = New System.Windows.Forms.Label
Me.TxtCurrYearSU = New System.Windows.Forms.TextBox
Me.ChkLockbox = New System.Windows.Forms.CheckBox
Me.GrpFile.SuspendLayout()
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'TxtCurrYear
'
Me.TxtCurrYear.Location = New System.Drawing.Point(176, 17)
Me.TxtCurrYear.MaxLength = 4
Me.TxtCurrYear.Name = "TxtCurrYear"
Me.TxtCurrYear.Size = New System.Drawing.Size(31, 20)
Me.TxtCurrYear.TabIndex = 0
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(74, 20)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(66, 13)
Me.Label1.TabIndex = 1
Me.Label1.Text = "Current Year"
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Location = New System.Drawing.Point(74, 72)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(35, 13)
Me.Label2.TabIndex = 3
Me.Label2.Text = "Batch"
'
'TxtBatch
'
Me.TxtBatch.Location = New System.Drawing.Point(176, 69)
Me.TxtBatch.MaxLength = 5
Me.TxtBatch.Name = "TxtBatch"
Me.TxtBatch.Size = New System.Drawing.Size(39, 20)
Me.TxtBatch.TabIndex = 2
'
'ChkFile
'
Me.ChkFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkFile.Checked = True
Me.ChkFile.CheckState = System.Windows.Forms.CheckState.Checked
Me.ChkFile.Location = New System.Drawing.Point(77, 95)
Me.ChkFile.Name = "ChkFile"
Me.ChkFile.Size = New System.Drawing.Size(121, 17)
Me.ChkFile.TabIndex = 3
Me.ChkFile.Text = "Create File?"
Me.ChkFile.UseVisualStyleBackColor = True
'
'GrpFile
'
Me.GrpFile.Controls.Add(Me.LblFilePath)
Me.GrpFile.Controls.Add(Me.LnkFilePath)
Me.GrpFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GrpFile.Location = New System.Drawing.Point(10, 145)
Me.GrpFile.Name = "GrpFile"
Me.GrpFile.Size = New System.Drawing.Size(408, 72)
Me.GrpFile.TabIndex = 65
Me.GrpFile.TabStop = False
Me.GrpFile.Text = "File Details"
'
'LblFilePath
'
Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblFilePath.Location = New System.Drawing.Point(70, 24)
Me.LblFilePath.Name = "LblFilePath"
Me.LblFilePath.Size = New System.Drawing.Size(324, 36)
Me.LblFilePath.TabIndex = 0
'
'LnkFilePath
'
Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkFilePath.Location = New System.Drawing.Point(12, 35)
Me.LnkFilePath.Name = "LnkFilePath"
Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
Me.LnkFilePath.TabIndex = 8
Me.LnkFilePath.TabStop = True
Me.LnkFilePath.Text = "File Path"
Me.LnkFilePath.Visible = False
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Label3
'
Me.Label3.AutoSize = True
Me.Label3.Location = New System.Drawing.Point(74, 46)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(96, 13)
Me.Label3.TabIndex = 67
Me.Label3.Text = "Current Year Suppl"
'
'TxtCurrYearSU
'
Me.TxtCurrYearSU.Location = New System.Drawing.Point(176, 43)
Me.TxtCurrYearSU.MaxLength = 4
Me.TxtCurrYearSU.Name = "TxtCurrYearSU"
Me.TxtCurrYearSU.Size = New System.Drawing.Size(31, 20)
Me.TxtCurrYearSU.TabIndex = 1
'
'ChkLockbox
'
Me.ChkLockbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkLockbox.Location = New System.Drawing.Point(77, 118)
Me.ChkLockbox.Name = "ChkLockbox"
Me.ChkLockbox.Size = New System.Drawing.Size(121, 17)
Me.ChkLockbox.TabIndex = 68
Me.ChkLockbox.Text = "Lockbox?"
Me.ChkLockbox.UseVisualStyleBackColor = True
'
'FrmTX600B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(430, 229)
Me.ControlBox = False
Me.Controls.Add(Me.ChkLockbox)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.TxtCurrYearSU)
Me.Controls.Add(Me.GrpFile)
Me.Controls.Add(Me.ChkFile)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.TxtBatch)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtCurrYear)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX600B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.GrpFile.ResumeLayout(False)
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

  Public Sub RunReport()
    Dim WrkFileArchive As String
    Dim WrkFileFound As Boolean
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    If MyFrmTX600B.ChkFile.Checked Then
      WrkFileArchive = MyUtils.GetDataPath() & "Archive\" & TxtBatch.Text & ".txt"
      WrkFileFound = MyUtils.CheckFileExists(WrkFileArchive)
      If WrkFileFound Then
        MsgBox("Batch has already been processed", MsgBoxStyle.Critical, "Program cannot continue")
        Exit Sub
      End If
    End If

    Me.Refresh()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default

    If WrkCurrYear <> MyUtils.CnvSng(TxtCurrYear.Text) Then
      MyAppSettings.CurrYear = MyUtils.CnvSng(TxtCurrYear.Text)
      SaveAppSettings()
    End If
    If WrkCurrYearSU <> MyUtils.CnvSng(TxtCurrYearSU.Text) Then
      MyAppSettings.CurrYearSU = MyUtils.CnvSng(TxtCurrYearSU.Text)
      SaveAppSettings()
    End If

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtCurrYear, "")
    ErrProv.SetError(TxtCurrYearSU, "")
    ErrProv.SetError(TxtBatch, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "curryear"
        ErrProv.SetError(TxtCurrYear, ErrorMsg(I))
      Case "curryearsu"
        ErrProv.SetError(TxtCurrYearSU, ErrorMsg(I))
      Case "batch"
        ErrProv.SetError(TxtBatch, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtCurrYear.Text) = 0 Then
      ErrorField(I) = "curryear"
      ErrorMsg(I) = "Current Year is required"
      I = I + 1
    End If
    If MyUtils.CnvSng(TxtCurrYearSU.Text) = 0 Then
      ErrorField(I) = "curryearsu"
      ErrorMsg(I) = "Current Year Suppl is required"
      I = I + 1
    End If
    If MyUtils.CnvSng(TxtBatch.Text) = 0 Then
      ErrorField(I) = "batch"
      ErrorMsg(I) = "Batch is required"
      I = I + 1
    End If

  End Sub
Private Sub FrmTX600B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX600.SbpScreen.Text = "TX600B"
End Sub
Private Sub TxtCurrYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCurrYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtCurrYearSU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCurrYearSU.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtBatch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBatch.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub FrmTX600B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  WrkCurrYear = MyAppSettings.CurrYear
  TxtCurrYear.Text = WrkCurrYear

  WrkCurrYearSU = MyAppSettings.CurrYearSU
  TxtCurrYearSU.Text = WrkCurrYearSU
End Sub
Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
  With SaveFileDialog1
    .Filter = "Text File|*.txt"
    .ShowDialog()
    LblFilePath.Text = .FileName
  End With
End Sub
Private Sub TxtBatch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBatch.TextChanged
  LblFilePath.Text = MyUtils.GetDataPath() & TxtBatch.Text & ".txt"
End Sub

Private Sub ChkFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkFile.Click
  GrpFile.Visible = Not GrpFile.Visible
End Sub
End Class






