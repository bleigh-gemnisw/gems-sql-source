Public Class FrmTA204B
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
  Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbDenied As System.Windows.Forms.RadioButton
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbPP As System.Windows.Forms.RadioButton
Friend WithEvents RbRE As System.Windows.Forms.RadioButton
Friend WithEvents RbOther As System.Windows.Forms.RadioButton
Friend WithEvents TxtBAAPhone As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents RbMV As System.Windows.Forms.RadioButton
Friend WithEvents ChkFrozenFile As System.Windows.Forms.CheckBox
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbOther = New System.Windows.Forms.RadioButton()
    Me.RbDenied = New System.Windows.Forms.RadioButton()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbMV = New System.Windows.Forms.RadioButton()
    Me.RbPP = New System.Windows.Forms.RadioButton()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.TxtBAAPhone = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ChkFrozenFile = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'TxtGLYear
    '
    Me.TxtGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGLYear.Location = New System.Drawing.Point(115, 21)
    Me.TxtGLYear.MaxLength = 4
    Me.TxtGLYear.Name = "TxtGLYear"
    Me.TxtGLYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtGLYear.TabIndex = 0
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(23, 25)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(84, 16)
    Me.Label4.TabIndex = 11
    Me.Label4.Text = "Grand List Year"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbOther)
    Me.GroupBox1.Controls.Add(Me.RbDenied)
    Me.GroupBox1.Location = New System.Drawing.Point(38, 171)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(153, 44)
    Me.GroupBox1.TabIndex = 3
    Me.GroupBox1.TabStop = False
    '
    'RbOther
    '
    Me.RbOther.Location = New System.Drawing.Point(77, 19)
    Me.RbOther.Name = "RbOther"
    Me.RbOther.Size = New System.Drawing.Size(70, 17)
    Me.RbOther.TabIndex = 14
    Me.RbOther.Text = "All Others"
    Me.RbOther.UseVisualStyleBackColor = True
    '
    'RbDenied
    '
    Me.RbDenied.Checked = True
    Me.RbDenied.Location = New System.Drawing.Point(6, 19)
    Me.RbDenied.Name = "RbDenied"
    Me.RbDenied.Size = New System.Drawing.Size(59, 17)
    Me.RbDenied.TabIndex = 13
    Me.RbDenied.TabStop = True
    Me.RbDenied.Text = "Denied"
    Me.RbDenied.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbMV)
    Me.GroupBox2.Controls.Add(Me.RbPP)
    Me.GroupBox2.Controls.Add(Me.RbRE)
    Me.GroupBox2.Location = New System.Drawing.Point(38, 74)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(125, 91)
    Me.GroupBox2.TabIndex = 2
    Me.GroupBox2.TabStop = False
    '
    'RbMV
    '
    Me.RbMV.Location = New System.Drawing.Point(6, 64)
    Me.RbMV.Name = "RbMV"
    Me.RbMV.Size = New System.Drawing.Size(113, 17)
    Me.RbMV.TabIndex = 15
    Me.RbMV.Text = "Motor Vehicle"
    Me.RbMV.UseVisualStyleBackColor = True
    '
    'RbPP
    '
    Me.RbPP.Location = New System.Drawing.Point(6, 41)
    Me.RbPP.Name = "RbPP"
    Me.RbPP.Size = New System.Drawing.Size(113, 17)
    Me.RbPP.TabIndex = 14
    Me.RbPP.Text = "Personal Property"
    Me.RbPP.UseVisualStyleBackColor = True
    '
    'RbRE
    '
    Me.RbRE.Checked = True
    Me.RbRE.Location = New System.Drawing.Point(6, 18)
    Me.RbRE.Name = "RbRE"
    Me.RbRE.Size = New System.Drawing.Size(87, 17)
    Me.RbRE.TabIndex = 13
    Me.RbRE.TabStop = True
    Me.RbRE.Text = "Real Estate"
    Me.RbRE.UseVisualStyleBackColor = True
    '
    'TxtBAAPhone
    '
    Me.TxtBAAPhone.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBAAPhone.Location = New System.Drawing.Point(115, 46)
    Me.TxtBAAPhone.MaxLength = 15
    Me.TxtBAAPhone.Name = "TxtBAAPhone"
    Me.TxtBAAPhone.Size = New System.Drawing.Size(99, 20)
    Me.TxtBAAPhone.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(23, 50)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(84, 16)
    Me.Label1.TabIndex = 17
    Me.Label1.Text = "BAA Phone No"
    '
    'ChkFrozenFile
    '
    Me.ChkFrozenFile.AutoSize = True
    Me.ChkFrozenFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkFrozenFile.Location = New System.Drawing.Point(12, 221)
    Me.ChkFrozenFile.Name = "ChkFrozenFile"
    Me.ChkFrozenFile.Size = New System.Drawing.Size(105, 17)
    Me.ChkFrozenFile.TabIndex = 18
    Me.ChkFrozenFile.Text = "Use Frozen List?"
    '
    'FrmTA204B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(238, 245)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkFrozenFile)
    Me.Controls.Add(Me.TxtBAAPhone)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TxtGLYear)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA204B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTA204B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA204.SbpScreen.Text = "TA204"
End Sub
Private Sub FrmTA204B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLYear, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "glyear"
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

    If MyUtils.CnvSng(TxtGLYear.Text) = 0 Then
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "Year is required"
      I = I + 1
    End If

  End Sub

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

Private Sub FrmTA204B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MyTypes = ""
End Sub

Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






