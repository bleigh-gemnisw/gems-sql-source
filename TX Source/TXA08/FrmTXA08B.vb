Public Class FrmTXA08B
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
Friend WithEvents RbCredit As System.Windows.Forms.RadioButton
Friend WithEvents RbCheck As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents RbWebster As System.Windows.Forms.RadioButton
Friend WithEvents RbNormal As System.Windows.Forms.RadioButton
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
    Me.RbCredit = New System.Windows.Forms.RadioButton()
    Me.RbCheck = New System.Windows.Forms.RadioButton()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.RbWebster = New System.Windows.Forms.RadioButton()
    Me.RbNormal = New System.Windows.Forms.RadioButton()
    Me.DtPckInterest = New System.Windows.Forms.DateTimePicker()
    Me.Label3 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
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
    Me.GroupBox1.Location = New System.Drawing.Point(12, 167)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(408, 56)
    Me.GroupBox1.TabIndex = 4
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Web Receipt File Details"
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
    'DtPckReceipt
    '
    Me.DtPckReceipt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckReceipt.Location = New System.Drawing.Point(88, 39)
    Me.DtPckReceipt.Name = "DtPckReceipt"
    Me.DtPckReceipt.Size = New System.Drawing.Size(84, 20)
    Me.DtPckReceipt.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 43)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(72, 12)
    Me.Label1.TabIndex = 66
    Me.Label1.Text = "Receipt Date"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbCredit)
    Me.GroupBox2.Controls.Add(Me.RbCheck)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(12, 123)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(176, 38)
    Me.GroupBox2.TabIndex = 3
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Payment Type"
    '
    'RbCredit
    '
    Me.RbCredit.AutoSize = True
    Me.RbCredit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCredit.Location = New System.Drawing.Point(93, 15)
    Me.RbCredit.Name = "RbCredit"
    Me.RbCredit.Size = New System.Drawing.Size(52, 17)
    Me.RbCredit.TabIndex = 1
    Me.RbCredit.Text = "Credit"
    Me.RbCredit.UseVisualStyleBackColor = True
    '
    'RbCheck
    '
    Me.RbCheck.AutoSize = True
    Me.RbCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbCheck.Checked = True
    Me.RbCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCheck.Location = New System.Drawing.Point(7, 15)
    Me.RbCheck.Name = "RbCheck"
    Me.RbCheck.Size = New System.Drawing.Size(56, 17)
    Me.RbCheck.TabIndex = 0
    Me.RbCheck.TabStop = True
    Me.RbCheck.Text = "Check"
    Me.RbCheck.UseVisualStyleBackColor = True
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.RbWebster)
    Me.GroupBox3.Controls.Add(Me.RbNormal)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(12, 65)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(215, 52)
    Me.GroupBox3.TabIndex = 2
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "File Format"
    '
    'RbWebster
    '
    Me.RbWebster.AutoSize = True
    Me.RbWebster.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbWebster.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbWebster.Location = New System.Drawing.Point(95, 19)
    Me.RbWebster.Name = "RbWebster"
    Me.RbWebster.Size = New System.Drawing.Size(115, 17)
    Me.RbWebster.TabIndex = 4
    Me.RbWebster.Text = "Lockbox (Webster)"
    Me.RbWebster.UseVisualStyleBackColor = True
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
    'DtPckInterest
    '
    Me.DtPckInterest.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckInterest.Location = New System.Drawing.Point(88, 14)
    Me.DtPckInterest.Name = "DtPckInterest"
    Me.DtPckInterest.Size = New System.Drawing.Size(84, 20)
    Me.DtPckInterest.TabIndex = 0
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 18)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(68, 13)
    Me.Label3.TabIndex = 74
    Me.Label3.Text = "Interest Date"
    '
    'FrmTXA08B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(439, 233)
    Me.ControlBox = False
    Me.Controls.Add(Me.DtPckInterest)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.DtPckReceipt)
    Me.Controls.Add(Me.GroupBox1)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA08B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
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
Private Sub FrmTXA08B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Dim myTXMVFee As TXMVFEE.myData
  myTXMVFee = New TXMVFEE.mydata(MyDBConnect)

  MyFrmTXA08.SbpPgmID.Text = "TXA08B"
  MyFrmTXA08.SbpEnvironment.Text = myDBConnect.PgmDB
  LblFilePath.Text = ""
  myTXMVFee.GetOneRecordP(1)
  MyMVFee = myTXMVFee._MVFEE

End Sub
Private Sub FrmTXA08B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXA08.SbpScreen.Text = "TXA08B"
End Sub
Private Sub FrmTXA08B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

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
Private Sub FrmTXA08B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
End Class






