Public Class FrmUB305B
  Inherits System.Windows.Forms.Form
  Dim WrkRoutes As Boolean

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
  Friend WithEvents TxtDist As System.Windows.Forms.TextBox
  Friend WithEvents RbRoutes As System.Windows.Forms.RadioButton
  Friend WithEvents RbReadings As System.Windows.Forms.RadioButton
  Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents DtPckRead As System.Windows.Forms.DateTimePicker
  Friend WithEvents LnkDistrict As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtUBType As System.Windows.Forms.TextBox
  Friend WithEvents LnkUBType As System.Windows.Forms.LinkLabel
  Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
  Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
  Friend WithEvents ChkBillType As System.Windows.Forms.CheckBox
  Friend WithEvents LblFilePath As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.RbRoutes = New System.Windows.Forms.RadioButton()
    Me.RbReadings = New System.Windows.Forms.RadioButton()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.DtPckRead = New System.Windows.Forms.DateTimePicker()
    Me.TxtUBType = New System.Windows.Forms.TextBox()
    Me.LnkUBType = New System.Windows.Forms.LinkLabel()
    Me.LnkDistrict = New System.Windows.Forms.LinkLabel()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.ChkBillType = New System.Windows.Forms.CheckBox()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'TxtDist
        '
        Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDist.Location = New System.Drawing.Point(120, 36)
        Me.TxtDist.MaxLength = 3
        Me.TxtDist.Name = "TxtDist"
        Me.TxtDist.Size = New System.Drawing.Size(32, 20)
        Me.TxtDist.TabIndex = 2
        '
        'RbRoutes
        '
        Me.RbRoutes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbRoutes.Checked = True
        Me.RbRoutes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbRoutes.Location = New System.Drawing.Point(32, 8)
        Me.RbRoutes.Name = "RbRoutes"
        Me.RbRoutes.Size = New System.Drawing.Size(96, 20)
        Me.RbRoutes.TabIndex = 0
        Me.RbRoutes.TabStop = True
        Me.RbRoutes.Text = "Create Routes"
        '
        'RbReadings
        '
        Me.RbReadings.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbReadings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbReadings.Location = New System.Drawing.Point(160, 8)
        Me.RbReadings.Name = "RbReadings"
        Me.RbReadings.Size = New System.Drawing.Size(97, 20)
        Me.RbReadings.TabIndex = 1
        Me.RbReadings.Text = "Get Readings"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblFilePath)
        Me.GroupBox1.Controls.Add(Me.LnkFilePath)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(32, 180)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 56)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Neptune Route File Details"
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
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(32, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 20)
        Me.Label5.TabIndex = 330
        Me.Label5.Text = "Reading Date"
        '
        'DtPckRead
        '
        Me.DtPckRead.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckRead.Location = New System.Drawing.Point(120, 122)
        Me.DtPckRead.Name = "DtPckRead"
        Me.DtPckRead.Size = New System.Drawing.Size(96, 20)
        Me.DtPckRead.TabIndex = 5
        '
        'TxtUBType
        '
        Me.TxtUBType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtUBType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUBType.Location = New System.Drawing.Point(120, 62)
        Me.TxtUBType.MaxLength = 2
        Me.TxtUBType.Name = "TxtUBType"
        Me.TxtUBType.Size = New System.Drawing.Size(24, 22)
        Me.TxtUBType.TabIndex = 3
        '
        'LnkUBType
        '
        Me.LnkUBType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkUBType.Location = New System.Drawing.Point(32, 62)
        Me.LnkUBType.Name = "LnkUBType"
        Me.LnkUBType.Size = New System.Drawing.Size(80, 16)
        Me.LnkUBType.TabIndex = 331
        Me.LnkUBType.TabStop = True
        Me.LnkUBType.Text = "Bill Type"
        '
        'LnkDistrict
        '
        Me.LnkDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkDistrict.Location = New System.Drawing.Point(32, 37)
        Me.LnkDistrict.Name = "LnkDistrict"
        Me.LnkDistrict.Size = New System.Drawing.Size(48, 16)
        Me.LnkDistrict.TabIndex = 333
        Me.LnkDistrict.TabStop = True
        Me.LnkDistrict.Text = "District"
        '
        'ChkPost
        '
        Me.ChkPost.AutoSize = True
        Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkPost.Location = New System.Drawing.Point(35, 148)
        Me.ChkPost.Name = "ChkPost"
        Me.ChkPost.Size = New System.Drawing.Size(101, 17)
        Me.ChkPost.TabIndex = 6
        Me.ChkPost.Text = "Post Readings?"
        Me.ChkPost.UseVisualStyleBackColor = True
        '
        'ChkBillType
        '
        Me.ChkBillType.AutoSize = True
        Me.ChkBillType.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkBillType.Location = New System.Drawing.Point(35, 90)
        Me.ChkBillType.Name = "ChkBillType"
        Me.ChkBillType.Size = New System.Drawing.Size(173, 17)
        Me.ChkBillType.TabIndex = 4
        Me.ChkBillType.Text = "Use Billing Type with readings?"
        Me.ChkBillType.UseVisualStyleBackColor = True
        '
        'FrmUB305B
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(452, 255)
        Me.ControlBox = False
        Me.Controls.Add(Me.ChkBillType)
        Me.Controls.Add(Me.ChkPost)
        Me.Controls.Add(Me.LnkDistrict)
        Me.Controls.Add(Me.TxtUBType)
        Me.Controls.Add(Me.LnkUBType)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DtPckRead)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.RbReadings)
        Me.Controls.Add(Me.RbRoutes)
        Me.Controls.Add(Me.TxtDist)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUB305B"
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

    If WrkRoutes Then
      PrtRoutes()
    Else
      PrtReadings()
    End If
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmUB305B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmUB305.SbpPgmID.Text = "UB305B"
    MyFrmUB305.SbpEnvironment.Text = myDBConnect.PgmDB
    LblFilePath.Text = MyUtils.GetDataPath() & "Neptune.txt"
    RbRoutes.Checked = True
  End Sub
  Private Sub FrmUB305B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmUB305.SbpScreen.Text = "UB305B"
  End Sub
  Private Sub FrmUB305B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtDist, "")

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
  Private Sub FrmUB305B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub

    If e.KeyCode = Keys.F12 Then
      MyUtils.PrtScreen(Form.ActiveForm)
    End If
  End Sub
  Private Sub TxtDistrict_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
    If WrkRoutes Then
      With SaveFileDialog1
        .ShowDialog()
        LblFilePath.Text = .FileName
      End With
    Else
      With OpenFileDialog1
        .ShowDialog()
        LblFilePath.Text = .FileName
      End With
    End If
  End Sub
  Private Sub LnkDistrict_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDistrict.LinkClicked
    MyFrmListDist = New FrmListDist
    MyFrmListDist.MdiParent = Me.ParentForm
    MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
    MyFrmListDist.WrkPhase = 0
    MyFrmListDist.Show()
    Me.Hide()
  End Sub
  Private Sub LnkUBType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkUBType.LinkClicked
    MyFrmListUBType = New FrmListUBType
    MyFrmListUBType.MdiParent = Me.ParentForm
    MyFrmListUBType.WrkType = TxtUBType.Text
    MyFrmListUBType.Show()
    Me.Hide()
  End Sub
  Private Sub RbRoutes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbRoutes.Click
    WrkRoutes = True
    LnkDistrict.Enabled = True
    TxtDist.Enabled = True
    ChkBillType.Enabled = False
    DtPckRead.Enabled = False
    ChkPost.Enabled = False
  End Sub
  Private Sub RbReadings_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbReadings.Click
    WrkRoutes = False
    LnkDistrict.Enabled = False
    TxtDist.Enabled = False
    ChkBillType.Enabled = True
    DtPckRead.Enabled = True
    ChkPost.Enabled = True
  End Sub
End Class






