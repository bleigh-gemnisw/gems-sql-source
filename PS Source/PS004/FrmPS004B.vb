Public Class FrmPS004B
Inherits System.Windows.Forms.Form
Dim ds As DataSet = New DataSet

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
Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbName As System.Windows.Forms.RadioButton
Friend WithEvents Rbperno As System.Windows.Forms.RadioButton
Friend WithEvents Rbregno As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TxtFromGLYear = New System.Windows.Forms.TextBox
Me.Label7 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.Rbperno = New System.Windows.Forms.RadioButton
Me.Rbregno = New System.Windows.Forms.RadioButton
Me.RbName = New System.Windows.Forms.RadioButton
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
Me.SuspendLayout()
'
'TxtFromGLYear
'
Me.TxtFromGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFromGLYear.Location = New System.Drawing.Point(118, 170)
Me.TxtFromGLYear.MaxLength = 4
Me.TxtFromGLYear.Name = "TxtFromGLYear"
Me.TxtFromGLYear.Size = New System.Drawing.Size(36, 20)
Me.TxtFromGLYear.TabIndex = 6
'
'Label7
'
Me.Label7.Location = New System.Drawing.Point(34, 174)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(84, 16)
Me.Label7.TabIndex = 31
Me.Label7.Text = "Sticker Year"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.Rbperno)
Me.GroupBox1.Controls.Add(Me.Rbregno)
Me.GroupBox1.Controls.Add(Me.RbName)
Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox1.Location = New System.Drawing.Point(35, 63)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(148, 90)
Me.GroupBox1.TabIndex = 2
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Sort by"
'
'Rbperno
'
Me.Rbperno.AutoSize = True
Me.Rbperno.Location = New System.Drawing.Point(16, 65)
Me.Rbperno.Name = "Rbperno"
Me.Rbperno.Size = New System.Drawing.Size(61, 17)
Me.Rbperno.TabIndex = 4
Me.Rbperno.Text = "Permit#"
Me.Rbperno.UseVisualStyleBackColor = True
'
'Rbregno
'
Me.Rbregno.AutoSize = True
Me.Rbregno.Checked = True
Me.Rbregno.Location = New System.Drawing.Point(16, 19)
Me.Rbregno.Name = "Rbregno"
Me.Rbregno.Size = New System.Drawing.Size(88, 17)
Me.Rbregno.TabIndex = 2
Me.Rbregno.TabStop = True
Me.Rbregno.Text = "Registration#"
Me.Rbregno.UseVisualStyleBackColor = True
'
'RbName
'
Me.RbName.AutoSize = True
Me.RbName.Location = New System.Drawing.Point(16, 42)
Me.RbName.Name = "RbName"
Me.RbName.Size = New System.Drawing.Size(53, 17)
Me.RbName.TabIndex = 1
Me.RbName.Text = "Name"
Me.RbName.UseVisualStyleBackColor = True
'
'FrmPS004B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(352, 300)
Me.ControlBox = False
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.TxtFromGLYear)
Me.Controls.Add(Me.Label7)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmPS004B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox1.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmPS004B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmPS004.SbpScreen.Text = "PS004"
End Sub
Private Sub FrmPS004B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFromGLYear, "")
   
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "fromglyear"
        ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
      

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

    If MyUtils.CnvSng(TxtFromGLYear.Text) = 0 Then
      ErrorField(I) = "fromglyear"
      ErrorMsg(I) = "Invalid Year"
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




Private Sub FrmPS004B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  TxtFromGLYear.Text = Format(Now(), "yyyy")
End Sub
End Class






