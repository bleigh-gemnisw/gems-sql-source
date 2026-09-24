Public Class FrmTX407B
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
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
  Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
  Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
  Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
  Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
  Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
  Friend WithEvents TpFiles As System.Windows.Forms.TabPage
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents GrpDMV As System.Windows.Forms.GroupBox
  Friend WithEvents LblFilePath As System.Windows.Forms.Label
  Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
  Friend WithEvents GrpMiss As GroupBox
  Friend WithEvents LnkCSVPath As LinkLabel
  Friend WithEvents LblCSVPath As Label
  Friend WithEvents Label2 As Label
  Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RadioButton1 = New System.Windows.Forms.RadioButton()
    Me.RadioButton2 = New System.Windows.Forms.RadioButton()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TextBox3 = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.RadioButton3 = New System.Windows.Forms.RadioButton()
    Me.RadioButton4 = New System.Windows.Forms.RadioButton()
    Me.TextBox4 = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.TextBox5 = New System.Windows.Forms.TextBox()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.RadioButton5 = New System.Windows.Forms.RadioButton()
    Me.RadioButton6 = New System.Windows.Forms.RadioButton()
    Me.TextBox6 = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.TabControl2 = New System.Windows.Forms.TabControl()
    Me.TpFiles = New System.Windows.Forms.TabPage()
    Me.GrpMiss = New System.Windows.Forms.GroupBox()
    Me.LnkCSVPath = New System.Windows.Forms.LinkLabel()
    Me.LblCSVPath = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GrpDMV = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.Label2 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.TabControl2.SuspendLayout()
    Me.TpFiles.SuspendLayout()
    Me.GrpMiss.SuspendLayout()
    Me.GrpDMV.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(22, 83)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(84, 16)
    Me.Label7.TabIndex = 77
    Me.Label7.Text = "<Message>"
    '
    'TextBox1
    '
    Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox1.Location = New System.Drawing.Point(112, 28)
    Me.TextBox1.MaxLength = 6
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(44, 20)
    Me.TextBox1.TabIndex = 0
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(24, 32)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(82, 20)
    Me.Label8.TabIndex = 76
    Me.Label8.Text = "List No"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RadioButton1)
    Me.GroupBox1.Controls.Add(Me.RadioButton2)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(184, 15)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(128, 59)
    Me.GroupBox1.TabIndex = 2
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Tax Type"
    '
    'RadioButton1
    '
    Me.RadioButton1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RadioButton1.Checked = True
    Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RadioButton1.Location = New System.Drawing.Point(12, 16)
    Me.RadioButton1.Name = "RadioButton1"
    Me.RadioButton1.Size = New System.Drawing.Size(108, 20)
    Me.RadioButton1.TabIndex = 0
    Me.RadioButton1.TabStop = True
    Me.RadioButton1.Text = "Motor Vehicle"
    '
    'RadioButton2
    '
    Me.RadioButton2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RadioButton2.Location = New System.Drawing.Point(12, 36)
    Me.RadioButton2.Name = "RadioButton2"
    Me.RadioButton2.Size = New System.Drawing.Size(108, 20)
    Me.RadioButton2.TabIndex = 1
    Me.RadioButton2.Text = "Suppl. MV"
    '
    'TextBox2
    '
    Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox2.Location = New System.Drawing.Point(112, 54)
    Me.TextBox2.MaxLength = 4
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(32, 20)
    Me.TextBox2.TabIndex = 1
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(24, 58)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(84, 16)
    Me.Label9.TabIndex = 73
    Me.Label9.Text = "Grand List Year"
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(22, 83)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(84, 16)
    Me.Label10.TabIndex = 77
    Me.Label10.Text = "<Message>"
    '
    'TextBox3
    '
    Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox3.Location = New System.Drawing.Point(112, 28)
    Me.TextBox3.MaxLength = 6
    Me.TextBox3.Name = "TextBox3"
    Me.TextBox3.Size = New System.Drawing.Size(44, 20)
    Me.TextBox3.TabIndex = 0
    '
    'Label11
    '
    Me.Label11.Location = New System.Drawing.Point(24, 32)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(82, 20)
    Me.Label11.TabIndex = 76
    Me.Label11.Text = "List No"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.RadioButton3)
    Me.GroupBox3.Controls.Add(Me.RadioButton4)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(184, 15)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(128, 59)
    Me.GroupBox3.TabIndex = 2
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Tax Type"
    '
    'RadioButton3
    '
    Me.RadioButton3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RadioButton3.Checked = True
    Me.RadioButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RadioButton3.Location = New System.Drawing.Point(12, 16)
    Me.RadioButton3.Name = "RadioButton3"
    Me.RadioButton3.Size = New System.Drawing.Size(108, 20)
    Me.RadioButton3.TabIndex = 0
    Me.RadioButton3.TabStop = True
    Me.RadioButton3.Text = "Motor Vehicle"
    '
    'RadioButton4
    '
    Me.RadioButton4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RadioButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RadioButton4.Location = New System.Drawing.Point(12, 36)
    Me.RadioButton4.Name = "RadioButton4"
    Me.RadioButton4.Size = New System.Drawing.Size(108, 20)
    Me.RadioButton4.TabIndex = 1
    Me.RadioButton4.Text = "Suppl. MV"
    '
    'TextBox4
    '
    Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox4.Location = New System.Drawing.Point(112, 54)
    Me.TextBox4.MaxLength = 4
    Me.TextBox4.Name = "TextBox4"
    Me.TextBox4.Size = New System.Drawing.Size(32, 20)
    Me.TextBox4.TabIndex = 1
    '
    'Label12
    '
    Me.Label12.Location = New System.Drawing.Point(24, 58)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(84, 16)
    Me.Label12.TabIndex = 73
    Me.Label12.Text = "Grand List Year"
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(22, 83)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(84, 16)
    Me.Label13.TabIndex = 77
    Me.Label13.Text = "<Message>"
    '
    'TextBox5
    '
    Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox5.Location = New System.Drawing.Point(112, 28)
    Me.TextBox5.MaxLength = 6
    Me.TextBox5.Name = "TextBox5"
    Me.TextBox5.Size = New System.Drawing.Size(44, 20)
    Me.TextBox5.TabIndex = 0
    '
    'Label14
    '
    Me.Label14.Location = New System.Drawing.Point(24, 32)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(82, 20)
    Me.Label14.TabIndex = 76
    Me.Label14.Text = "List No"
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.RadioButton5)
    Me.GroupBox4.Controls.Add(Me.RadioButton6)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(184, 15)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(128, 59)
    Me.GroupBox4.TabIndex = 2
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Tax Type"
    '
    'RadioButton5
    '
    Me.RadioButton5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RadioButton5.Checked = True
    Me.RadioButton5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RadioButton5.Location = New System.Drawing.Point(12, 16)
    Me.RadioButton5.Name = "RadioButton5"
    Me.RadioButton5.Size = New System.Drawing.Size(108, 20)
    Me.RadioButton5.TabIndex = 0
    Me.RadioButton5.TabStop = True
    Me.RadioButton5.Text = "Motor Vehicle"
    '
    'RadioButton6
    '
    Me.RadioButton6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RadioButton6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RadioButton6.Location = New System.Drawing.Point(12, 36)
    Me.RadioButton6.Name = "RadioButton6"
    Me.RadioButton6.Size = New System.Drawing.Size(108, 20)
    Me.RadioButton6.TabIndex = 1
    Me.RadioButton6.Text = "Suppl. MV"
    '
    'TextBox6
    '
    Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox6.Location = New System.Drawing.Point(112, 54)
    Me.TextBox6.MaxLength = 4
    Me.TextBox6.Name = "TextBox6"
    Me.TextBox6.Size = New System.Drawing.Size(32, 20)
    Me.TextBox6.TabIndex = 1
    '
    'Label15
    '
    Me.Label15.Location = New System.Drawing.Point(24, 58)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(84, 16)
    Me.Label15.TabIndex = 73
    Me.Label15.Text = "Grand List Year"
    '
    'TabControl2
    '
    Me.TabControl2.Controls.Add(Me.TpFiles)
    Me.TabControl2.Location = New System.Drawing.Point(15, 100)
    Me.TabControl2.Name = "TabControl2"
    Me.TabControl2.SelectedIndex = 0
    Me.TabControl2.Size = New System.Drawing.Size(522, 187)
    Me.TabControl2.TabIndex = 11
    '
    'TpFiles
    '
    Me.TpFiles.Controls.Add(Me.GrpMiss)
    Me.TpFiles.Controls.Add(Me.Label1)
    Me.TpFiles.Controls.Add(Me.GrpDMV)
    Me.TpFiles.Location = New System.Drawing.Point(4, 22)
    Me.TpFiles.Name = "TpFiles"
    Me.TpFiles.Padding = New System.Windows.Forms.Padding(3)
    Me.TpFiles.Size = New System.Drawing.Size(514, 161)
    Me.TpFiles.TabIndex = 0
    Me.TpFiles.Text = "Files"
    Me.TpFiles.UseVisualStyleBackColor = True
    '
    'GrpMiss
    '
    Me.GrpMiss.Controls.Add(Me.LnkCSVPath)
    Me.GrpMiss.Controls.Add(Me.LblCSVPath)
    Me.GrpMiss.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpMiss.Location = New System.Drawing.Point(16, 6)
    Me.GrpMiss.Name = "GrpMiss"
    Me.GrpMiss.Size = New System.Drawing.Size(408, 56)
    Me.GrpMiss.TabIndex = 13
    Me.GrpMiss.TabStop = False
    Me.GrpMiss.Text = "CVS File"
    '
    'LnkCSVPath
    '
    Me.LnkCSVPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkCSVPath.Location = New System.Drawing.Point(12, 26)
    Me.LnkCSVPath.Name = "LnkCSVPath"
    Me.LnkCSVPath.Size = New System.Drawing.Size(52, 16)
    Me.LnkCSVPath.TabIndex = 68
    Me.LnkCSVPath.TabStop = True
    Me.LnkCSVPath.Text = "File Path"
    '
    'LblCSVPath
    '
    Me.LblCSVPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCSVPath.Location = New System.Drawing.Point(75, 16)
    Me.LblCSVPath.Name = "LblCSVPath"
    Me.LblCSVPath.Size = New System.Drawing.Size(321, 36)
    Me.LblCSVPath.TabIndex = 67
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(7, 127)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(495, 13)
    Me.Label1.TabIndex = 12
    Me.Label1.Text = "*DMV will only accept file named TC###DTyymmdd.txt where ### is town number and y" &
    "ymmdd is date "
    '
    'GrpDMV
    '
    Me.GrpDMV.Controls.Add(Me.LblFilePath)
    Me.GrpDMV.Controls.Add(Me.LnkFilePath)
    Me.GrpDMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpDMV.Location = New System.Drawing.Point(16, 68)
    Me.GrpDMV.Name = "GrpDMV"
    Me.GrpDMV.Size = New System.Drawing.Size(408, 56)
    Me.GrpDMV.TabIndex = 11
    Me.GrpDMV.TabStop = False
    Me.GrpDMV.Text = "DMV File Details*"
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
    'OpenFileDialog1
    '
    Me.OpenFileDialog1.FileName = "OpenFileDialog1"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(26, 30)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(163, 13)
    Me.Label2.TabIndex = 12
    Me.Label2.Text = "Write Takeoff file from a CSV File"
    '
    'FrmTX407B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(554, 296)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TabControl2)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX407B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox4.ResumeLayout(False)
    Me.TabControl2.ResumeLayout(False)
    Me.TpFiles.ResumeLayout(False)
    Me.TpFiles.PerformLayout()
    Me.GrpMiss.ResumeLayout(False)
    Me.GrpDMV.ResumeLayout(False)
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

    PrtTakeOffs()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmTX407B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkStr As String

    MyFrmTX407.SbpPgmID.Text = "TX407B"
    MyFrmTX407.SbpEnvironment.Text = myDBConnect.PgmDB
    WrkStr = Mid(MyUtils.SetDBDate(Date.Today), 3, 6)
    LblFilePath.Text = MyUtils.GetDataPath() & "TC" & Format(myTOWN._TOWNBR, "000") & "DT" & WrkStr & ".txt"
  End Sub
  Private Sub FrmTX407B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX407.SbpScreen.Text = "TX407B"
  End Sub
  Private Sub FrmTX407B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  End Sub
  Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
    Dim WrkStr As String

    WrkStr = Mid(MyUtils.SetDBDate(Date.Today), 3, 6)
    With SaveFileDialog1
      .FileName = "TC" & Format(myTOWN._TOWNBR, "000") & "DT" & WrkStr & ".txt"
      .ShowDialog()
      If .FileName <> String.Empty Then
        LblFilePath.Text = .FileName
      End If
    End With
  End Sub
  Private Sub LnkCSVPath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCSVPath.LinkClicked
    With OpenFileDialog1
      .ReadOnlyChecked = True
      .FileName = ""
      .ShowDialog()
      LblCSVPath.Text = .FileName
    End With
  End Sub
End Class
