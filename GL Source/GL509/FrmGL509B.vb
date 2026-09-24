Public Class FrmGL509B
Inherits System.Windows.Forms.Form
Dim myglheaD As GLHEAD.MyData
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
Friend WithEvents TxtFund As System.Windows.Forms.TextBox
Friend WithEvents TxtSfund As System.Windows.Forms.TextBox
Friend WithEvents LnkFund As System.Windows.Forms.LinkLabel
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents rb4 As System.Windows.Forms.RadioButton
  Friend WithEvents rb3 As System.Windows.Forms.RadioButton
Friend WithEvents rb2 As System.Windows.Forms.RadioButton
Friend WithEvents rb1 As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents rbt4 As System.Windows.Forms.RadioButton
Friend WithEvents rbt3 As System.Windows.Forms.RadioButton
Friend WithEvents rbt2 As System.Windows.Forms.RadioButton
Friend WithEvents rbt1 As System.Windows.Forms.RadioButton
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtFund = New System.Windows.Forms.TextBox()
    Me.TxtSfund = New System.Windows.Forms.TextBox()
    Me.LnkFund = New System.Windows.Forms.LinkLabel()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.rb4 = New System.Windows.Forms.RadioButton()
    Me.rb3 = New System.Windows.Forms.RadioButton()
    Me.rb2 = New System.Windows.Forms.RadioButton()
    Me.rb1 = New System.Windows.Forms.RadioButton()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.rbt4 = New System.Windows.Forms.RadioButton()
    Me.rbt3 = New System.Windows.Forms.RadioButton()
    Me.rbt2 = New System.Windows.Forms.RadioButton()
    Me.rbt1 = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtFund
    '
    Me.TxtFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFund.Location = New System.Drawing.Point(145, 24)
    Me.TxtFund.MaxLength = 3
    Me.TxtFund.Name = "TxtFund"
    Me.TxtFund.Size = New System.Drawing.Size(30, 22)
    Me.TxtFund.TabIndex = 0
    '
    'TxtSfund
    '
    Me.TxtSfund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfund.Location = New System.Drawing.Point(193, 24)
    Me.TxtSfund.MaxLength = 3
    Me.TxtSfund.Name = "TxtSfund"
    Me.TxtSfund.Size = New System.Drawing.Size(34, 22)
    Me.TxtSfund.TabIndex = 1
    '
    'LnkFund
    '
    Me.LnkFund.AutoSize = True
    Me.LnkFund.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFund.Location = New System.Drawing.Point(93, 28)
    Me.LnkFund.Name = "LnkFund"
    Me.LnkFund.Size = New System.Drawing.Size(31, 13)
    Me.LnkFund.TabIndex = 319
    Me.LnkFund.TabStop = True
    Me.LnkFund.Text = "Fund"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.rb4)
    Me.GroupBox1.Controls.Add(Me.rb3)
    Me.GroupBox1.Controls.Add(Me.rb2)
    Me.GroupBox1.Controls.Add(Me.rb1)
    Me.GroupBox1.Location = New System.Drawing.Point(45, 70)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(168, 123)
    Me.GroupBox1.TabIndex = 320
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Copy From Column"
    '
    'rb4
    '
    Me.rb4.AutoSize = True
    Me.rb4.Location = New System.Drawing.Point(16, 97)
    Me.rb4.Name = "rb4"
    Me.rb4.Size = New System.Drawing.Size(40, 17)
    Me.rb4.TabIndex = 3
    Me.rb4.TabStop = True
    Me.rb4.Text = "rb4"
    Me.rb4.UseVisualStyleBackColor = True
    '
    'rb3
    '
    Me.rb3.AutoSize = True
    Me.rb3.Location = New System.Drawing.Point(16, 74)
    Me.rb3.Name = "rb3"
    Me.rb3.Size = New System.Drawing.Size(40, 17)
    Me.rb3.TabIndex = 2
    Me.rb3.TabStop = True
    Me.rb3.Text = "rb3"
    Me.rb3.UseVisualStyleBackColor = True
    '
    'rb2
    '
    Me.rb2.AutoSize = True
    Me.rb2.Location = New System.Drawing.Point(16, 51)
    Me.rb2.Name = "rb2"
    Me.rb2.Size = New System.Drawing.Size(40, 17)
    Me.rb2.TabIndex = 1
    Me.rb2.TabStop = True
    Me.rb2.Text = "rb2"
    Me.rb2.UseVisualStyleBackColor = True
    '
    'rb1
    '
    Me.rb1.AutoSize = True
    Me.rb1.Location = New System.Drawing.Point(16, 29)
    Me.rb1.Name = "rb1"
    Me.rb1.Size = New System.Drawing.Size(40, 17)
    Me.rb1.TabIndex = 0
    Me.rb1.TabStop = True
    Me.rb1.Text = "rb1"
    Me.rb1.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.rbt4)
    Me.GroupBox2.Controls.Add(Me.rbt3)
    Me.GroupBox2.Controls.Add(Me.rbt2)
    Me.GroupBox2.Controls.Add(Me.rbt1)
    Me.GroupBox2.Location = New System.Drawing.Point(271, 70)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(188, 123)
    Me.GroupBox2.TabIndex = 321
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Copy To  Colum"
    '
    'rbt4
    '
    Me.rbt4.AutoSize = True
    Me.rbt4.Location = New System.Drawing.Point(30, 98)
    Me.rbt4.Name = "rbt4"
    Me.rbt4.Size = New System.Drawing.Size(40, 17)
    Me.rbt4.TabIndex = 3
    Me.rbt4.TabStop = True
    Me.rbt4.Text = "rb4"
    Me.rbt4.UseVisualStyleBackColor = True
    '
    'rbt3
    '
    Me.rbt3.AutoSize = True
    Me.rbt3.Location = New System.Drawing.Point(30, 75)
    Me.rbt3.Name = "rbt3"
    Me.rbt3.Size = New System.Drawing.Size(40, 17)
    Me.rbt3.TabIndex = 2
    Me.rbt3.TabStop = True
    Me.rbt3.Text = "rb3"
    Me.rbt3.UseVisualStyleBackColor = True
    '
    'rbt2
    '
    Me.rbt2.AutoSize = True
    Me.rbt2.Location = New System.Drawing.Point(30, 52)
    Me.rbt2.Name = "rbt2"
    Me.rbt2.Size = New System.Drawing.Size(40, 17)
    Me.rbt2.TabIndex = 1
    Me.rbt2.TabStop = True
    Me.rbt2.Text = "rb2"
    Me.rbt2.UseVisualStyleBackColor = True
    '
    'rbt1
    '
    Me.rbt1.AutoSize = True
    Me.rbt1.Location = New System.Drawing.Point(30, 29)
    Me.rbt1.Name = "rbt1"
    Me.rbt1.Size = New System.Drawing.Size(40, 17)
    Me.rbt1.TabIndex = 0
    Me.rbt1.TabStop = True
    Me.rbt1.Text = "rb1"
    Me.rbt1.UseVisualStyleBackColor = True
    '
    'FrmGL509B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(509, 219)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.LnkFund)
    Me.Controls.Add(Me.TxtSfund)
    Me.Controls.Add(Me.TxtFund)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL509B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
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
    ProcFile()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmGL509B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Getbudgetheaders()
End Sub
Private Sub FrmGL509B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGL509.SbpScreen.Text = "GL509B"
End Sub
Private Sub FrmGL509B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    ErrProv.SetError(TxtFund, "")
    ErrProv.SetError(rb1, "")
    ErrProv.SetError(rbt1, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "fund"
        ErrProv.SetError(TxtFund, ErrorMsg(I))
      Case "copy"
        ErrProv.SetError(rb1, ErrorMsg(I))
      Case "copyto"
        ErrProv.SetError(rbt1, ErrorMsg(I))
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

    If TxtFund.Text = "" Then
      ErrorField(I) = "fund"
      ErrorMsg(I) = "Invalid Fund"
      I = I + 1
    End If

    If rb1.Checked = False And rb2.Checked = False And rb3.Checked = False And rb4.Checked = False Then
      ErrorField(I) = "copy"
      ErrorMsg(I) = "Invalid Copy from selection"
      I = I + 1
    End If

    If rbt1.Checked = False And rbt2.Checked = False And rbt3.Checked = False And rbt4.Checked = False Then
      ErrorField(I) = "copyto"
      ErrorMsg(I) = "Invalid Copy To selection"
      I = I + 1
    End If

    If rb2.Checked = True And rbt1.Checked = True Then
      ErrorField(I) = "copyto"
      ErrorMsg(I) = "Invalid Copy To selection"
      I = I + 1
    End If

    If rb3.Checked Then
      If rbt1.Checked Or rbt2.Checked Then
        ErrorField(I) = "copyto"
        ErrorMsg(I) = "Invalid Copy To selection"
        I = I + 1
      End If
    End If

    If rb4.Checked Then
      If rbt1.Checked Or rbt2.Checked Or rbt3.Checked Then
        ErrorField(I) = "copyto"
        ErrorMsg(I) = "Invalid Copy To selection"
        I = I + 1
      End If
    End If
  End Sub
  Private Sub TxtFund_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFund.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDept_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSfund.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub LnkFund_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFund.LinkClicked
  MyFrmListFund = New FrmListFund
  MyFrmListFund.MdiParent = Me.ParentForm
  MyFrmListFund.WrkFund = MyUtils.CnvSng(TxtFund.Text)
  MyFrmListFund.WrkID = "From"
  MyFrmListFund.Show()
  Me.Hide()
End Sub
Private Sub Getbudgetheaders()
Dim dshead As DataSet = New DataSet
  myglheaD = New GLHEAD.MyData()
  myglheaD.MyDBConn = myDBConnect
  myglheaD.GetOneRecordP(0, 0)
    If Not myglheaD.RecordNotFound Then
      rb1.Text = Trim(myglheaD._BUDC1)
      rb2.Text = Trim(myglheaD._BUDC2)
      rb3.Text = Trim(myglheaD._BUDC3)
      rb4.Text = Trim(myglheaD._BUDC4)
      rbt1.Text = Trim(myglheaD._BUDC2)
      rbt2.Text = Trim(myglheaD._BUDC3)
      rbt3.Text = Trim(myglheaD._BUDC4)
      rbt4.Text = "Adopted Budget"
    Else
      rb1.Text = ""
      rb2.Text = ""
      rb3.Text = ""
      rb4.Text = ""
      rbt1.Text = ""
      rbt2.Text = ""
      rbt3.Text = ""
    End If
    myglheaD.CloseFile()
End Sub
End Class
