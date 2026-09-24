Public Class FrmUB302B
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
Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
Friend WithEvents ChkPost As System.Windows.Forms.CheckBox
Friend WithEvents TxtYear As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents RbReceive As System.Windows.Forms.RadioButton
Friend WithEvents RbCreate As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbRE As System.Windows.Forms.RadioButton
Friend WithEvents RbUB As System.Windows.Forms.RadioButton
Friend WithEvents LblFilePath As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.ChkPost = New System.Windows.Forms.CheckBox()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbUB = New System.Windows.Forms.RadioButton()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.RbReceive = New System.Windows.Forms.RadioButton()
    Me.RbCreate = New System.Windows.Forms.RadioButton()
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
    Me.GroupBox1.Location = New System.Drawing.Point(15, 139)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(421, 56)
    Me.GroupBox1.TabIndex = 5
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "File Details"
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
    'ChkPost
    '
    Me.ChkPost.AutoSize = True
    Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPost.Location = New System.Drawing.Point(30, 108)
    Me.ChkPost.Name = "ChkPost"
    Me.ChkPost.Size = New System.Drawing.Size(72, 17)
    Me.ChkPost.TabIndex = 334
    Me.ChkPost.Text = "Post File?"
    Me.ChkPost.UseVisualStyleBackColor = True
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(103, 80)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(40, 22)
    Me.TxtYear.TabIndex = 335
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(33, 84)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(64, 16)
    Me.Label3.TabIndex = 336
    Me.Label3.Text = "Billing Year"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbUB)
    Me.GroupBox2.Controls.Add(Me.RbRE)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(327, 7)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(110, 64)
    Me.GroupBox2.TabIndex = 337
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Data Source"
    '
    'RbUB
    '
    Me.RbUB.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbUB.Checked = True
    Me.RbUB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbUB.Location = New System.Drawing.Point(6, 38)
    Me.RbUB.Name = "RbUB"
    Me.RbUB.Size = New System.Drawing.Size(90, 20)
    Me.RbUB.TabIndex = 3
    Me.RbUB.TabStop = True
    Me.RbUB.Text = "UB Customer"
    '
    'RbRE
    '
    Me.RbRE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbRE.Location = New System.Drawing.Point(6, 15)
    Me.RbRE.Name = "RbRE"
    Me.RbRE.Size = New System.Drawing.Size(90, 20)
    Me.RbRE.TabIndex = 2
    Me.RbRE.Text = "Real Estate"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.RbReceive)
    Me.GroupBox3.Controls.Add(Me.RbCreate)
    Me.GroupBox3.Location = New System.Drawing.Point(15, 7)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(290, 38)
    Me.GroupBox3.TabIndex = 338
    Me.GroupBox3.TabStop = False
    '
    'RbReceive
    '
    Me.RbReceive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbReceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbReceive.Location = New System.Drawing.Point(157, 15)
    Me.RbReceive.Name = "RbReceive"
    Me.RbReceive.Size = New System.Drawing.Size(118, 20)
    Me.RbReceive.TabIndex = 2
    Me.RbReceive.Text = "Receive Billing File"
    '
    'RbCreate
    '
    Me.RbCreate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbCreate.Checked = True
    Me.RbCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCreate.Location = New System.Drawing.Point(6, 15)
    Me.RbCreate.Name = "RbCreate"
    Me.RbCreate.Size = New System.Drawing.Size(112, 20)
    Me.RbCreate.TabIndex = 1
    Me.RbCreate.TabStop = True
    Me.RbCreate.Text = "Create Billing File"
    '
    'FrmUB302B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(449, 211)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.ChkPost)
    Me.Controls.Add(Me.GroupBox1)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmUB302B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
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
    If RbRE.Checked Then
      If RbCreate.Checked Then
        PrtCreateRE()
      Else
        PrtReceiveRE()
      End If
    Else
      If RbCreate.Checked Then
        PrtCreateUB()
      Else
        PrtReceiveUB()
      End If
    End If
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmUB302B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmUB302.SbpPgmID.Text = "UB302B"
    MyFrmUB302.SbpEnvironment.Text = myDBConnect.PgmDB
End Sub
Private Sub FrmUB302B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB302.SbpScreen.Text = "UB302B"
End Sub
Private Sub FrmUB302B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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

    If RbReceive.Checked Then
      If MyUtils.CnvSng(TxtYear.Text) = 0 Then
        ErrorField(I) = "year"
        ErrorMsg(I) = "Year is required"
        I = I + 1
      End If
    End If

    If LblFilePath.Text = String.Empty Then
      ErrorField(I) = "path"
      ErrorMsg(I) = "File Path is required"
      I = I + 1
    End If
  End Sub
Private Sub FrmUB302B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub

   If e.KeyCode = Keys.F12 Then
     MyUtils.PrtScreen(Form.ActiveForm)
   End If
End Sub
Private Sub TxtDistrict_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
  If MyFrmUB302B.RbCreate.Checked Then
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
Private Sub RbCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
  ChkPost.Visible = False
  TxtYear.Enabled = False
  LblFilePath.Text = String.Empty
End Sub
Private Sub RbReceive_Click(ByVal sender As Object, ByVal e As System.EventArgs)
  ChkPost.Visible = True
  TxtYear.Enabled = True
  LblFilePath.Text = String.Empty
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

End Class






