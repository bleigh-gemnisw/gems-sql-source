Public Class FrmTXA02B
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
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
Friend WithEvents LblFilePath As System.Windows.Forms.Label
Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
Friend WithEvents DtPckReceipt As System.Windows.Forms.DateTimePicker
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbChase As System.Windows.Forms.RadioButton
Friend WithEvents RbNormal As System.Windows.Forms.RadioButton
Friend WithEvents RbNon As System.Windows.Forms.RadioButton
Friend WithEvents RbAmerica As System.Windows.Forms.RadioButton
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents RbWebster As System.Windows.Forms.RadioButton
  Friend WithEvents RbTaxServ As RadioButton
  Friend WithEvents TxtComm As TextBox
  Friend WithEvents Label2 As Label
  Friend WithEvents DtPckInterest As DateTimePicker
  Friend WithEvents Label3 As Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.DtPckReceipt = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbTaxServ = New System.Windows.Forms.RadioButton()
    Me.RbWebster = New System.Windows.Forms.RadioButton()
    Me.RbAmerica = New System.Windows.Forms.RadioButton()
    Me.RbNon = New System.Windows.Forms.RadioButton()
    Me.RbChase = New System.Windows.Forms.RadioButton()
    Me.RbNormal = New System.Windows.Forms.RadioButton()
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtComm = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.DtPckInterest = New System.Windows.Forms.DateTimePicker()
    Me.Label3 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
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
    Me.GroupBox1.Location = New System.Drawing.Point(15, 88)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(567, 56)
    Me.GroupBox1.TabIndex = 2
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Bank Receipt File Details"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePath.Name = "LblFilePath"
    Me.LblFilePath.Size = New System.Drawing.Size(480, 36)
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
    'DtPckReceipt
    '
    Me.DtPckReceipt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckReceipt.Location = New System.Drawing.Point(86, 41)
    Me.DtPckReceipt.Name = "DtPckReceipt"
    Me.DtPckReceipt.Size = New System.Drawing.Size(84, 20)
    Me.DtPckReceipt.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(10, 45)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(70, 13)
    Me.Label1.TabIndex = 66
    Me.Label1.Text = "Receipt Date"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbTaxServ)
    Me.GroupBox2.Controls.Add(Me.RbWebster)
    Me.GroupBox2.Controls.Add(Me.RbAmerica)
    Me.GroupBox2.Controls.Add(Me.RbNon)
    Me.GroupBox2.Controls.Add(Me.RbChase)
    Me.GroupBox2.Controls.Add(Me.RbNormal)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(15, 150)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(479, 70)
    Me.GroupBox2.TabIndex = 3
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "File Format"
    '
    'RbTaxServ
    '
    Me.RbTaxServ.AutoSize = True
    Me.RbTaxServ.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbTaxServ.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbTaxServ.Location = New System.Drawing.Point(104, 42)
    Me.RbTaxServ.Name = "RbTaxServ"
    Me.RbTaxServ.Size = New System.Drawing.Size(138, 17)
    Me.RbTaxServ.TabIndex = 5
    Me.RbTaxServ.Text = "TaxServ (Bank Service)"
    Me.RbTaxServ.UseVisualStyleBackColor = True
    '
    'RbWebster
    '
    Me.RbWebster.AutoSize = True
    Me.RbWebster.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbWebster.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbWebster.Location = New System.Drawing.Point(6, 42)
    Me.RbWebster.Name = "RbWebster"
    Me.RbWebster.Size = New System.Drawing.Size(65, 17)
    Me.RbWebster.TabIndex = 4
    Me.RbWebster.Text = "Webster"
    Me.RbWebster.UseVisualStyleBackColor = True
    '
    'RbAmerica
    '
    Me.RbAmerica.AutoSize = True
    Me.RbAmerica.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbAmerica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbAmerica.Location = New System.Drawing.Point(364, 19)
    Me.RbAmerica.Name = "RbAmerica"
    Me.RbAmerica.Size = New System.Drawing.Size(103, 17)
    Me.RbAmerica.TabIndex = 3
    Me.RbAmerica.Text = "Bank of America"
    Me.RbAmerica.UseVisualStyleBackColor = True
    '
    'RbNon
    '
    Me.RbNon.AutoSize = True
    Me.RbNon.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbNon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbNon.Location = New System.Drawing.Point(104, 19)
    Me.RbNon.Name = "RbNon"
    Me.RbNon.Size = New System.Drawing.Size(91, 17)
    Me.RbNon.TabIndex = 1
    Me.RbNon.Text = "Non Standard"
    Me.RbNon.UseVisualStyleBackColor = True
    '
    'RbChase
    '
    Me.RbChase.AutoSize = True
    Me.RbChase.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbChase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbChase.Location = New System.Drawing.Point(227, 19)
    Me.RbChase.Name = "RbChase"
    Me.RbChase.Size = New System.Drawing.Size(109, 17)
    Me.RbChase.TabIndex = 2
    Me.RbChase.Text = "Chase/Wachovia"
    Me.RbChase.UseVisualStyleBackColor = True
    '
    'RbNormal
    '
    Me.RbNormal.AutoSize = True
    Me.RbNormal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbNormal.Checked = True
    Me.RbNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbNormal.Location = New System.Drawing.Point(6, 19)
    Me.RbNormal.Name = "RbNormal"
    Me.RbNormal.Size = New System.Drawing.Size(58, 17)
    Me.RbNormal.TabIndex = 0
    Me.RbNormal.TabStop = True
    Me.RbNormal.Text = "Normal"
    Me.RbNormal.UseVisualStyleBackColor = True
    '
    'TxtGLYear
    '
    Me.TxtGLYear.Enabled = False
    Me.TxtGLYear.Location = New System.Drawing.Point(114, 232)
    Me.TxtGLYear.MaxLength = 4
    Me.TxtGLYear.Name = "TxtGLYear"
    Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtGLYear.TabIndex = 4
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(18, 236)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(80, 13)
    Me.Label4.TabIndex = 69
    Me.Label4.Text = "Grand List Year"
    '
    'TxtComm
    '
    Me.TxtComm.Location = New System.Drawing.Point(114, 257)
    Me.TxtComm.MaxLength = 20
    Me.TxtComm.Name = "TxtComm"
    Me.TxtComm.Size = New System.Drawing.Size(149, 20)
    Me.TxtComm.TabIndex = 5
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(18, 261)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(51, 13)
    Me.Label2.TabIndex = 71
    Me.Label2.Text = "Comment"
    '
    'DtPckInterest
    '
    Me.DtPckInterest.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckInterest.Location = New System.Drawing.Point(86, 18)
    Me.DtPckInterest.Name = "DtPckInterest"
    Me.DtPckInterest.Size = New System.Drawing.Size(84, 20)
    Me.DtPckInterest.TabIndex = 0
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 21)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(68, 13)
    Me.Label3.TabIndex = 72
    Me.Label3.Text = "Interest Date"
    '
    'FrmTXA02B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(592, 292)
    Me.ControlBox = False
    Me.Controls.Add(Me.DtPckInterest)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtComm)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtGLYear)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.DtPckReceipt)
    Me.Controls.Add(Me.GroupBox1)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA02B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
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
  Private Sub FrmTXA02B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim myTXMVFee As TXMVFEE.myData
    myTXMVFee = New TXMVFEE.mydata(MyDBConnect)

    MyFrmTXA02.SbpPgmID.Text = "TXA02B"
    MyFrmTXA02.SbpEnvironment.Text = myDBConnect.PgmDB
    LblFilePath.Text = ""
    TxtComm.Text = "LOCK BOX PAYMENT"
    myTXMVFee.GetOneRecordP(1)
    MyMVFee = myTXMVFee._MVFEE
  End Sub
  Private Sub FrmTXA02B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXA02.SbpScreen.Text = "TXA02B"
End Sub
Private Sub FrmTXA02B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    ErrProv.SetError(LblFilePath, "")
    ErrProv.SetError(TxtGLYear, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "path"
        ErrProv.SetError(LblFilePath, ErrorMsg(I))
      Case "year"
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

    If LblFilePath.Text = "" Then
      ErrorField(I) = "path"
      ErrorMsg(I) = "File Path cannot be blank. Click on link to set."
      I = I + 1
    End If

    If RbAmerica.Checked And TxtGLYear.Text = "" Then
      ErrorField(I) = "year"
      ErrorMsg(I) = "G/L year is required"
      I = I + 1
    End If

  End Sub
Private Sub FrmTXA02B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
Private Sub RbNormal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbNormal.Click
  TxtGLYear.Enabled = False
End Sub
Private Sub RbNon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbNon.Click
  TxtGLYear.Enabled = False
End Sub
Private Sub RbChase_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbChase.Click
  TxtGLYear.Enabled = False
End Sub
Private Sub RbAmerica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbAmerica.Click
  TxtGLYear.Enabled = True
End Sub
Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbWebster.Click
  TxtGLYear.Enabled = False
End Sub
End Class






