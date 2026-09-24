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
  Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtStartNo As System.Windows.Forms.TextBox
  Friend WithEvents ChkOnlyDMVCust As System.Windows.Forms.CheckBox
  Friend WithEvents LblMinVal As Label
  Friend WithEvents Label1 As Label
  Friend WithEvents Label4 As Label
  Friend WithEvents RbAppend As RadioButton
  Friend WithEvents RbInstall As RadioButton
  Friend WithEvents Label3 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GrpFile = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtStartNo = New System.Windows.Forms.TextBox()
    Me.ChkOnlyDMVCust = New System.Windows.Forms.CheckBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.LblMinVal = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.RbInstall = New System.Windows.Forms.RadioButton()
    Me.RbAppend = New System.Windows.Forms.RadioButton()
    Me.Label4 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpFile.SuspendLayout()
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
    Me.GrpFile.Location = New System.Drawing.Point(20, 86)
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
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(50, 36)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(103, 13)
    Me.Label2.TabIndex = 76
    Me.Label2.Text = "Staring List Number*"
    '
    'TxtStartNo
    '
    Me.TxtStartNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtStartNo.Location = New System.Drawing.Point(164, 33)
    Me.TxtStartNo.MaxLength = 6
    Me.TxtStartNo.Name = "TxtStartNo"
    Me.TxtStartNo.Size = New System.Drawing.Size(56, 20)
    Me.TxtStartNo.TabIndex = 1
    '
    'ChkOnlyDMVCust
    '
    Me.ChkOnlyDMVCust.AutoSize = True
    Me.ChkOnlyDMVCust.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkOnlyDMVCust.Location = New System.Drawing.Point(19, 193)
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
    Me.Label3.Location = New System.Drawing.Point(9, 246)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(419, 17)
    Me.Label3.TabIndex = 82
    Me.Label3.Text = "* NOTICE: DMV File is unsorted. Run Resequence program next. "
    '
    'LblMinVal
    '
    Me.LblMinVal.BackColor = System.Drawing.Color.Aqua
    Me.LblMinVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblMinVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMinVal.Location = New System.Drawing.Point(168, 9)
    Me.LblMinVal.Name = "LblMinVal"
    Me.LblMinVal.Size = New System.Drawing.Size(64, 16)
    Me.LblMinVal.TabIndex = 85
    Me.LblMinVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(16, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(137, 13)
    Me.Label1.TabIndex = 84
    Me.Label1.Text = "Minimum Assessment Value"
    '
    'RbInstall
    '
    Me.RbInstall.AutoSize = True
    Me.RbInstall.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbInstall.Location = New System.Drawing.Point(19, 159)
    Me.RbInstall.Name = "RbInstall"
    Me.RbInstall.Size = New System.Drawing.Size(131, 17)
    Me.RbInstall.TabIndex = 86
    Me.RbInstall.Text = "Install Initial Suppl MV "
    Me.RbInstall.UseVisualStyleBackColor = True
    '
    'RbAppend
    '
    Me.RbAppend.AutoSize = True
    Me.RbAppend.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbAppend.Checked = True
    Me.RbAppend.Location = New System.Drawing.Point(202, 159)
    Me.RbAppend.Name = "RbAppend"
    Me.RbAppend.Size = New System.Drawing.Size(151, 17)
    Me.RbAppend.TabIndex = 87
    Me.RbAppend.TabStop = True
    Me.RbAppend.Text = "Append Monthly Suppl MV"
    Me.RbAppend.UseVisualStyleBackColor = True
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(161, 161)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(35, 13)
    Me.Label4.TabIndex = 88
    Me.Label4.Text = "- OR -"
    '
    'FrmTA502B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(545, 272)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.RbAppend)
    Me.Controls.Add(Me.RbInstall)
    Me.Controls.Add(Me.LblMinVal)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.ChkOnlyDMVCust)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtStartNo)
    Me.Controls.Add(Me.GrpFile)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA502B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpFile.ResumeLayout(False)
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
    Dim myTXMCTL As TXMCTL.MyData
    myTXMCTL = New TXMCTL.MyData(myDBConnect)
    myTXMCTL.GetOneRecordP(1)
    If Not myTXMCTL.RecordNotFound Then
      With myTXMCTL
        MyBookPct = ._VALPER
        MyMinValue = ._VALMIN
      End With
    End If

    MyFrmTA502.SbpPgmID.Text = "TA502B"
    MyFrmTA502.SbpEnvironment.Text = myDBConnect.PgmDB
    TxtStartNo.Text = ""
    TxtStartNo.Enabled = False
    LblMinVal.Text = MyMinValue
    LblFilePath.Text = ""
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
  Private Sub ChkOnlyDMVCust_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkOnlyDMVCust.Click
    TxtStartNo.Enabled = Not TxtStartNo.Enabled
  End Sub

  Private Sub RbInstall_CheckedChanged(sender As Object, e As EventArgs) Handles RbInstall.CheckedChanged
    TxtStartNo.Enabled = Not TxtStartNo.Enabled
    If TxtStartNo.Enabled Then
      TxtStartNo.Text = "10000"
    Else
      TxtStartNo.Text = ""
    End If
  End Sub
End Class






