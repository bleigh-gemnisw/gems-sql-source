Public Class FrmAP305B
Inherits System.Windows.Forms.Form
Dim myVENCAT As VENCAT.MyData

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
Friend WithEvents LnkVencat As System.Windows.Forms.LinkLabel
Friend WithEvents ChkVenno As System.Windows.Forms.CheckBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TxtMaxLen As System.Windows.Forms.TextBox
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents Rb1Across As System.Windows.Forms.RadioButton
Friend WithEvents Rb3Across As System.Windows.Forms.RadioButton
Friend WithEvents Rb2Across As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents Label10 As System.Windows.Forms.Label
Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
Friend WithEvents TxtVAdjust2 As System.Windows.Forms.TextBox
Friend WithEvents TxtVAdjust1 As System.Windows.Forms.TextBox
Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
Friend WithEvents Label9 As System.Windows.Forms.Label
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
Friend WithEvents TxtHAdjust3 As System.Windows.Forms.TextBox
Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
Friend WithEvents TxtHAdjust2 As System.Windows.Forms.TextBox
Friend WithEvents TxtHAdjust1 As System.Windows.Forms.TextBox
Friend WithEvents TxtVncat As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAP305B))
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.LnkVencat = New System.Windows.Forms.LinkLabel()
    Me.TxtVncat = New System.Windows.Forms.TextBox()
    Me.ChkVenno = New System.Windows.Forms.CheckBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtMaxLen = New System.Windows.Forms.TextBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.Rb1Across = New System.Windows.Forms.RadioButton()
    Me.Rb3Across = New System.Windows.Forms.RadioButton()
    Me.Rb2Across = New System.Windows.Forms.RadioButton()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.PictureBox8 = New System.Windows.Forms.PictureBox()
    Me.PictureBox9 = New System.Windows.Forms.PictureBox()
    Me.TxtVAdjust2 = New System.Windows.Forms.TextBox()
    Me.TxtVAdjust1 = New System.Windows.Forms.TextBox()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.PictureBox4 = New System.Windows.Forms.PictureBox()
    Me.PictureBox5 = New System.Windows.Forms.PictureBox()
    Me.TxtHAdjust3 = New System.Windows.Forms.TextBox()
    Me.PictureBox6 = New System.Windows.Forms.PictureBox()
    Me.TxtHAdjust2 = New System.Windows.Forms.TextBox()
    Me.TxtHAdjust1 = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox4.SuspendLayout()
    CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LnkVencat
    '
    Me.LnkVencat.AutoSize = True
    Me.LnkVencat.Location = New System.Drawing.Point(43, 54)
    Me.LnkVencat.Name = "LnkVencat"
    Me.LnkVencat.Size = New System.Drawing.Size(86, 13)
    Me.LnkVencat.TabIndex = 65
    Me.LnkVencat.TabStop = True
    Me.LnkVencat.Text = "Vendor Category"
    '
    'TxtVncat
    '
    Me.TxtVncat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVncat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVncat.Location = New System.Drawing.Point(139, 51)
    Me.TxtVncat.MaxLength = 5
    Me.TxtVncat.Name = "TxtVncat"
    Me.TxtVncat.Size = New System.Drawing.Size(48, 20)
    Me.TxtVncat.TabIndex = 4
    '
    'ChkVenno
    '
    Me.ChkVenno.AutoSize = True
    Me.ChkVenno.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkVenno.Location = New System.Drawing.Point(46, 86)
    Me.ChkVenno.Name = "ChkVenno"
    Me.ChkVenno.Size = New System.Drawing.Size(136, 17)
    Me.ChkVenno.TabIndex = 80
    Me.ChkVenno.Text = "Show Vendor Number?"
    Me.ChkVenno.UseVisualStyleBackColor = True
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(208, 110)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(88, 13)
    Me.Label4.TabIndex = 84
    Me.Label4.Text = "Max Field Length"
    '
    'TxtMaxLen
    '
    Me.TxtMaxLen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMaxLen.Location = New System.Drawing.Point(302, 106)
    Me.TxtMaxLen.MaxLength = 2
    Me.TxtMaxLen.Name = "TxtMaxLen"
    Me.TxtMaxLen.Size = New System.Drawing.Size(28, 20)
    Me.TxtMaxLen.TabIndex = 81
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.Rb1Across)
    Me.GroupBox1.Controls.Add(Me.Rb3Across)
    Me.GroupBox1.Controls.Add(Me.Rb2Across)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(211, 12)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(127, 81)
    Me.GroupBox1.TabIndex = 83
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Format"
    '
    'Rb1Across
    '
    Me.Rb1Across.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.Rb1Across.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Rb1Across.Location = New System.Drawing.Point(12, 16)
    Me.Rb1Across.Name = "Rb1Across"
    Me.Rb1Across.Size = New System.Drawing.Size(102, 20)
    Me.Rb1Across.TabIndex = 0
    Me.Rb1Across.Text = "1 Across"
    '
    'Rb3Across
    '
    Me.Rb3Across.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.Rb3Across.Checked = True
    Me.Rb3Across.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Rb3Across.Location = New System.Drawing.Point(12, 56)
    Me.Rb3Across.Name = "Rb3Across"
    Me.Rb3Across.Size = New System.Drawing.Size(102, 20)
    Me.Rb3Across.TabIndex = 2
    Me.Rb3Across.TabStop = True
    Me.Rb3Across.Text = "3 Across"
    '
    'Rb2Across
    '
    Me.Rb2Across.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.Rb2Across.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Rb2Across.Location = New System.Drawing.Point(12, 36)
    Me.Rb2Across.Name = "Rb2Across"
    Me.Rb2Across.Size = New System.Drawing.Size(102, 20)
    Me.Rb2Across.TabIndex = 1
    Me.Rb2Across.Text = "2 Across"
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.Label1)
    Me.GroupBox5.Controls.Add(Me.Label6)
    Me.GroupBox5.Controls.Add(Me.Label10)
    Me.GroupBox5.Controls.Add(Me.PictureBox8)
    Me.GroupBox5.Controls.Add(Me.PictureBox9)
    Me.GroupBox5.Controls.Add(Me.TxtVAdjust2)
    Me.GroupBox5.Controls.Add(Me.TxtVAdjust1)
    Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox5.Location = New System.Drawing.Point(321, 134)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(120, 154)
    Me.GroupBox5.TabIndex = 86
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "Vertical  Spacing "
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
    Me.Label1.Location = New System.Drawing.Point(27, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(82, 13)
    Me.Label1.TabIndex = 92
    Me.Label1.Text = "(250 = 1 line)"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(30, 128)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(25, 13)
    Me.Label6.TabIndex = 91
    Me.Label6.Text = "2nd"
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(29, 75)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(21, 13)
    Me.Label10.TabIndex = 90
    Me.Label10.Text = "1st"
    '
    'PictureBox8
    '
    Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
    Me.PictureBox8.Location = New System.Drawing.Point(61, 120)
    Me.PictureBox8.Name = "PictureBox8"
    Me.PictureBox8.Size = New System.Drawing.Size(23, 22)
    Me.PictureBox8.TabIndex = 87
    Me.PictureBox8.TabStop = False
    '
    'PictureBox9
    '
    Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
    Me.PictureBox9.Location = New System.Drawing.Point(56, 66)
    Me.PictureBox9.Name = "PictureBox9"
    Me.PictureBox9.Size = New System.Drawing.Size(23, 22)
    Me.PictureBox9.TabIndex = 84
    Me.PictureBox9.TabStop = False
    '
    'TxtVAdjust2
    '
    Me.TxtVAdjust2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVAdjust2.Location = New System.Drawing.Point(51, 94)
    Me.TxtVAdjust2.MaxLength = 4
    Me.TxtVAdjust2.Name = "TxtVAdjust2"
    Me.TxtVAdjust2.Size = New System.Drawing.Size(35, 20)
    Me.TxtVAdjust2.TabIndex = 83
    '
    'TxtVAdjust1
    '
    Me.TxtVAdjust1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVAdjust1.Location = New System.Drawing.Point(51, 38)
    Me.TxtVAdjust1.MaxLength = 4
    Me.TxtVAdjust1.Name = "TxtVAdjust1"
    Me.TxtVAdjust1.Size = New System.Drawing.Size(33, 20)
    Me.TxtVAdjust1.TabIndex = 81
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.Label9)
    Me.GroupBox4.Controls.Add(Me.Label8)
    Me.GroupBox4.Controls.Add(Me.Label7)
    Me.GroupBox4.Controls.Add(Me.PictureBox4)
    Me.GroupBox4.Controls.Add(Me.PictureBox5)
    Me.GroupBox4.Controls.Add(Me.TxtHAdjust3)
    Me.GroupBox4.Controls.Add(Me.PictureBox6)
    Me.GroupBox4.Controls.Add(Me.TxtHAdjust2)
    Me.GroupBox4.Controls.Add(Me.TxtHAdjust1)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(12, 172)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(292, 68)
    Me.GroupBox4.TabIndex = 85
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Horizontal  Spacing (Enter # of spaces needed)"
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(240, 20)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(22, 13)
    Me.Label9.TabIndex = 92
    Me.Label9.Text = "3rd"
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(153, 20)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(25, 13)
    Me.Label8.TabIndex = 91
    Me.Label8.Text = "2nd"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(63, 17)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(21, 13)
    Me.Label7.TabIndex = 90
    Me.Label7.Text = "1st"
    '
    'PictureBox4
    '
    Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
    Me.PictureBox4.Location = New System.Drawing.Point(242, 36)
    Me.PictureBox4.Name = "PictureBox4"
    Me.PictureBox4.Size = New System.Drawing.Size(23, 22)
    Me.PictureBox4.TabIndex = 89
    Me.PictureBox4.TabStop = False
    '
    'PictureBox5
    '
    Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
    Me.PictureBox5.Location = New System.Drawing.Point(152, 36)
    Me.PictureBox5.Name = "PictureBox5"
    Me.PictureBox5.Size = New System.Drawing.Size(23, 22)
    Me.PictureBox5.TabIndex = 87
    Me.PictureBox5.TabStop = False
    '
    'TxtHAdjust3
    '
    Me.TxtHAdjust3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtHAdjust3.Location = New System.Drawing.Point(191, 36)
    Me.TxtHAdjust3.MaxLength = 2
    Me.TxtHAdjust3.Name = "TxtHAdjust3"
    Me.TxtHAdjust3.Size = New System.Drawing.Size(28, 20)
    Me.TxtHAdjust3.TabIndex = 86
    '
    'PictureBox6
    '
    Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
    Me.PictureBox6.Location = New System.Drawing.Point(66, 36)
    Me.PictureBox6.Name = "PictureBox6"
    Me.PictureBox6.Size = New System.Drawing.Size(23, 22)
    Me.PictureBox6.TabIndex = 84
    Me.PictureBox6.TabStop = False
    '
    'TxtHAdjust2
    '
    Me.TxtHAdjust2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtHAdjust2.Location = New System.Drawing.Point(107, 36)
    Me.TxtHAdjust2.MaxLength = 2
    Me.TxtHAdjust2.Name = "TxtHAdjust2"
    Me.TxtHAdjust2.Size = New System.Drawing.Size(28, 20)
    Me.TxtHAdjust2.TabIndex = 83
    '
    'TxtHAdjust1
    '
    Me.TxtHAdjust1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtHAdjust1.Location = New System.Drawing.Point(20, 36)
    Me.TxtHAdjust1.MaxLength = 2
    Me.TxtHAdjust1.Name = "TxtHAdjust1"
    Me.TxtHAdjust1.Size = New System.Drawing.Size(28, 20)
    Me.TxtHAdjust1.TabIndex = 81
    '
    'FrmAP305B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(449, 312)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox5)
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtMaxLen)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.ChkVenno)
    Me.Controls.Add(Me.TxtVncat)
    Me.Controls.Add(Me.LnkVencat)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmAP305B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
    CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

 Public Sub RunReport()
  myVENCAT = New VENCAT.MyData()
  myVENCAT.MyDBConn = myDBConnect
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
Private Sub FrmAP305B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MyFrmAP305.SbpPgmID.Text = "AP305B"
  MyFrmAP305.SbpEnvironment.Text = myDBConnect.PgmDB
  TxtMaxLen.Text = "35"
End Sub
Private Sub FrmAP305B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
 MyFrmAP305.SbpScreen.Text = "AP305B"
End Sub
Private Sub FrmAP305B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
 Me.Refresh()
End Sub
Private Sub TxtMaxLen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMaxLen.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtHAdjust1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtHAdjust1.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtHAdjust2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtHAdjust2.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtHAdjust3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtHAdjust3.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtVAdjust1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVAdjust1.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtVAdjust2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVAdjust2.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtVncat, "")

  For I = 0 To ErrorField.GetUpperBound(0)
   Select Case ErrorField(I)
   Case "vencat"
    ErrProv.SetError(TxtVncat, ErrorMsg(I))
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

  If TxtVncat.Text <> String.Empty Then
    myVENCAT.GetOneRecordP(TxtVncat.Text)
    If myVENCAT.RecordNotFound Then
      ErrorField(I) = "vencat"
      ErrorMsg(I) = "Vendor Category is invalid"
      I = I + 1
    End If
  End If
 End Sub
Private Sub FrmAP305B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
 If Not e.Alt Then Exit Sub

  If e.KeyCode = Keys.F12 Then
   MyUtils.PrtScreen(Form.ActiveForm)
  End If
End Sub
Private Sub LnkVencat_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkVencat.LinkClicked
  MyFrmListVENCAT = New FrmListVENCAT
  MyFrmListVENCAT.MdiParent = Me.ParentForm
  MyFrmListVENCAT.WrkCode = TxtVncat.Text
  MyFrmListVENCAT.Show()
  Me.Hide()
End Sub
End Class
