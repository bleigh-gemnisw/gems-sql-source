Public Class FrmUB306B
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
Friend WithEvents LnkFilePath1 As System.Windows.Forms.LinkLabel
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents DtPckRead As System.Windows.Forms.DateTimePicker
Friend WithEvents TxtUBType As System.Windows.Forms.TextBox
Friend WithEvents LnkUBType As System.Windows.Forms.LinkLabel
Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
Friend WithEvents LblFilePath4 As System.Windows.Forms.Label
Friend WithEvents LnkFilePath4 As System.Windows.Forms.LinkLabel
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents LblFilePath3 As System.Windows.Forms.Label
Friend WithEvents LnkFilePath3 As System.Windows.Forms.LinkLabel
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents LblFilePath2 As System.Windows.Forms.Label
Friend WithEvents LnkFilePath2 As System.Windows.Forms.LinkLabel
Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
Friend WithEvents RbAquarion As System.Windows.Forms.RadioButton
Friend WithEvents RbRegional As System.Windows.Forms.RadioButton
  Friend WithEvents RbCTWater As RadioButton
  Friend WithEvents LblFilePath1 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath1 = New System.Windows.Forms.Label()
    Me.LnkFilePath1 = New System.Windows.Forms.LinkLabel()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.DtPckRead = New System.Windows.Forms.DateTimePicker()
    Me.TxtUBType = New System.Windows.Forms.TextBox()
    Me.LnkUBType = New System.Windows.Forms.LinkLabel()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath2 = New System.Windows.Forms.Label()
    Me.LnkFilePath2 = New System.Windows.Forms.LinkLabel()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath3 = New System.Windows.Forms.Label()
    Me.LnkFilePath3 = New System.Windows.Forms.LinkLabel()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath4 = New System.Windows.Forms.Label()
    Me.LnkFilePath4 = New System.Windows.Forms.LinkLabel()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.RbAquarion = New System.Windows.Forms.RadioButton()
    Me.RbRegional = New System.Windows.Forms.RadioButton()
    Me.RbCTWater = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LblFilePath1)
    Me.GroupBox1.Controls.Add(Me.LnkFilePath1)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(32, 166)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(408, 56)
    Me.GroupBox1.TabIndex = 5
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Annual or 1st Quarter File Details"
    '
    'LblFilePath1
    '
    Me.LblFilePath1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath1.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePath1.Name = "LblFilePath1"
    Me.LblFilePath1.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePath1.TabIndex = 67
    '
    'LnkFilePath1
    '
    Me.LnkFilePath1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePath1.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePath1.Name = "LnkFilePath1"
    Me.LnkFilePath1.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath1.TabIndex = 65
    Me.LnkFilePath1.TabStop = True
    Me.LnkFilePath1.Text = "File Path"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(32, 57)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(76, 13)
    Me.Label5.TabIndex = 330
    Me.Label5.Text = "Reading Date "
    '
    'DtPckRead
    '
    Me.DtPckRead.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckRead.Location = New System.Drawing.Point(120, 51)
    Me.DtPckRead.Name = "DtPckRead"
    Me.DtPckRead.Size = New System.Drawing.Size(96, 20)
    Me.DtPckRead.TabIndex = 4
    '
    'TxtUBType
    '
    Me.TxtUBType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUBType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUBType.Location = New System.Drawing.Point(120, 23)
    Me.TxtUBType.MaxLength = 2
    Me.TxtUBType.Name = "TxtUBType"
    Me.TxtUBType.Size = New System.Drawing.Size(24, 22)
    Me.TxtUBType.TabIndex = 3
    '
    'LnkUBType
    '
    Me.LnkUBType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkUBType.Location = New System.Drawing.Point(32, 23)
    Me.LnkUBType.Name = "LnkUBType"
    Me.LnkUBType.Size = New System.Drawing.Size(80, 16)
    Me.LnkUBType.TabIndex = 331
    Me.LnkUBType.TabStop = True
    Me.LnkUBType.Text = "Bill Type"
    '
    'ChkPost
    '
    Me.ChkPost.AutoSize = True
    Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPost.Location = New System.Drawing.Point(35, 134)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(101, 17)
    Me.ChkPost.TabIndex = 334
    Me.ChkPost.Text = "Post Readings?"
    Me.ChkPost.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.LblFilePath2)
    Me.GroupBox2.Controls.Add(Me.LnkFilePath2)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(32, 228)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(408, 56)
    Me.GroupBox2.TabIndex = 335
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "2nd Quarter File Details"
    '
    'LblFilePath2
    '
    Me.LblFilePath2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath2.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePath2.Name = "LblFilePath2"
    Me.LblFilePath2.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePath2.TabIndex = 67
    '
    'LnkFilePath2
    '
    Me.LnkFilePath2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePath2.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePath2.Name = "LnkFilePath2"
    Me.LnkFilePath2.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath2.TabIndex = 65
    Me.LnkFilePath2.TabStop = True
    Me.LnkFilePath2.Text = "File Path"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.LblFilePath3)
    Me.GroupBox3.Controls.Add(Me.LnkFilePath3)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(35, 290)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(408, 56)
    Me.GroupBox3.TabIndex = 336
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "3rd Quarter File Details"
    '
    'LblFilePath3
    '
    Me.LblFilePath3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath3.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePath3.Name = "LblFilePath3"
    Me.LblFilePath3.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePath3.TabIndex = 67
    '
    'LnkFilePath3
    '
    Me.LnkFilePath3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePath3.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePath3.Name = "LnkFilePath3"
    Me.LnkFilePath3.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath3.TabIndex = 65
    Me.LnkFilePath3.TabStop = True
    Me.LnkFilePath3.Text = "File Path"
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.LblFilePath4)
    Me.GroupBox4.Controls.Add(Me.LnkFilePath4)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(35, 352)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(408, 56)
    Me.GroupBox4.TabIndex = 337
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "4th Quarter File Details"
    '
    'LblFilePath4
    '
    Me.LblFilePath4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath4.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePath4.Name = "LblFilePath4"
    Me.LblFilePath4.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePath4.TabIndex = 67
    '
    'LnkFilePath4
    '
    Me.LnkFilePath4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePath4.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePath4.Name = "LnkFilePath4"
    Me.LnkFilePath4.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath4.TabIndex = 65
    Me.LnkFilePath4.TabStop = True
    Me.LnkFilePath4.Text = "File Path"
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.RbCTWater)
    Me.GroupBox5.Controls.Add(Me.RbAquarion)
    Me.GroupBox5.Controls.Add(Me.RbRegional)
    Me.GroupBox5.Location = New System.Drawing.Point(35, 77)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(408, 46)
    Me.GroupBox5.TabIndex = 340
    Me.GroupBox5.TabStop = False
    '
    'RbAquarion
    '
    Me.RbAquarion.AutoSize = True
    Me.RbAquarion.Location = New System.Drawing.Point(117, 19)
    Me.RbAquarion.Name = "RbAquarion"
    Me.RbAquarion.Size = New System.Drawing.Size(185, 17)
    Me.RbAquarion.TabIndex = 341
    Me.RbAquarion.Text = "Aquarion (Must be sorted by Acct)"
    Me.RbAquarion.UseVisualStyleBackColor = True
    '
    'RbRegional
    '
    Me.RbRegional.AutoSize = True
    Me.RbRegional.Checked = True
    Me.RbRegional.Location = New System.Drawing.Point(6, 19)
    Me.RbRegional.Name = "RbRegional"
    Me.RbRegional.Size = New System.Drawing.Size(99, 17)
    Me.RbRegional.TabIndex = 340
    Me.RbRegional.Text = "Regional Water"
    Me.RbRegional.UseVisualStyleBackColor = True
    '
    'RbCTWater
    '
    Me.RbCTWater.AutoSize = True
    Me.RbCTWater.Location = New System.Drawing.Point(322, 19)
    Me.RbCTWater.Name = "RbCTWater"
    Me.RbCTWater.Size = New System.Drawing.Size(71, 17)
    Me.RbCTWater.TabIndex = 342
    Me.RbCTWater.Text = "CT Water"
    Me.RbCTWater.UseVisualStyleBackColor = True
    '
    'FrmUB306B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(452, 428)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox5)
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.ChkPost)
    Me.Controls.Add(Me.TxtUBType)
    Me.Controls.Add(Me.LnkUBType)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.DtPckRead)
    Me.Controls.Add(Me.GroupBox1)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmUB306B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
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
    PrtReadings()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmUB306B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmUB306.SbpPgmID.Text = "UB306B"
    MyFrmUB306.SbpEnvironment.Text = myDBConnect.PgmDB

End Sub
Private Sub FrmUB306B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB306.SbpScreen.Text = "UB306B"
End Sub
Private Sub FrmUB306B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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
Private Sub FrmUB306B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub

   If e.KeyCode = Keys.F12 Then
     MyUtils.PrtScreen(Form.ActiveForm)
   End If
End Sub
Private Sub LnkFilePath1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath1.LinkClicked
    With OpenFileDialog1
      .ReadOnlyChecked = True
      .ShowDialog()
      LblFilePath1.Text = .FileName
    End With
End Sub
Private Sub LnkFilePath2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath2.LinkClicked
    With OpenFileDialog1
      .ReadOnlyChecked = True
      .ShowDialog()
      LblFilePath2.Text = .FileName
    End With
End Sub
Private Sub LnkFilePath3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath3.LinkClicked
    With OpenFileDialog1
      .ReadOnlyChecked = True
      .ShowDialog()
      LblFilePath3.Text = .FileName
    End With
End Sub
Private Sub LnkFilePath4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath4.LinkClicked
    With OpenFileDialog1
      .ReadOnlyChecked = True
      .ShowDialog()
      LblFilePath4.Text = .FileName
    End With
End Sub
Private Sub LnkUBType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkUBType.LinkClicked
  MyFrmListUBType = New FrmListUBType
  MyFrmListUBType.MdiParent = Me.ParentForm
  MyFrmListUBType.WrkType = TxtUBType.Text
  MyFrmListUBType.Show()
  Me.Hide()
End Sub
End Class






