Public Class FrmTXE10B
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
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents TxtToGLYear As System.Windows.Forms.TextBox
Friend WithEvents TxtFromGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents ChkBlank As System.Windows.Forms.CheckBox
Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label6 = New System.Windows.Forms.Label
Me.TxtToGLYear = New System.Windows.Forms.TextBox
Me.TxtFromGLYear = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.Label7 = New System.Windows.Forms.Label
Me.TxtTypes = New System.Windows.Forms.TextBox
Me.LnkTypes = New System.Windows.Forms.LinkLabel
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ChkBlank = New System.Windows.Forms.CheckBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(219, 56)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(56, 16)
Me.Label6.TabIndex = 33
Me.Label6.Text = "(Optional)"
'
'TxtToGLYear
'
Me.TxtToGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtToGLYear.Location = New System.Drawing.Point(177, 52)
Me.TxtToGLYear.MaxLength = 4
Me.TxtToGLYear.Name = "TxtToGLYear"
Me.TxtToGLYear.Size = New System.Drawing.Size(36, 20)
Me.TxtToGLYear.TabIndex = 2
'
'TxtFromGLYear
'
Me.TxtFromGLYear.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFromGLYear.Location = New System.Drawing.Point(105, 52)
Me.TxtFromGLYear.MaxLength = 4
Me.TxtFromGLYear.Name = "TxtFromGLYear"
Me.TxtFromGLYear.Size = New System.Drawing.Size(36, 20)
Me.TxtFromGLYear.TabIndex = 1
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(153, 56)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(16, 16)
Me.Label4.TabIndex = 32
Me.Label4.Text = "to"
'
'Label7
'
Me.Label7.Location = New System.Drawing.Point(21, 56)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(84, 16)
Me.Label7.TabIndex = 31
Me.Label7.Text = "Grand List Year"
'
'TxtTypes
'
Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtTypes.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtTypes.Location = New System.Drawing.Point(105, 16)
Me.TxtTypes.MaxLength = 20
Me.TxtTypes.Name = "TxtTypes"
Me.TxtTypes.Size = New System.Drawing.Size(148, 20)
Me.TxtTypes.TabIndex = 0
'
'LnkTypes
'
Me.LnkTypes.Location = New System.Drawing.Point(21, 20)
Me.LnkTypes.Name = "LnkTypes"
Me.LnkTypes.Size = New System.Drawing.Size(80, 16)
Me.LnkTypes.TabIndex = 35
Me.LnkTypes.TabStop = True
Me.LnkTypes.Text = "Types to print"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'ChkBlank
'
Me.ChkBlank.AutoSize = True
Me.ChkBlank.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkBlank.Location = New System.Drawing.Point(24, 91)
Me.ChkBlank.Name = "ChkBlank"
Me.ChkBlank.Size = New System.Drawing.Size(130, 17)
Me.ChkBlank.TabIndex = 36
Me.ChkBlank.Text = "Exclude blank status?"
Me.ChkBlank.UseVisualStyleBackColor = True
'
'FrmTXE10B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(295, 120)
Me.ControlBox = False
Me.Controls.Add(Me.ChkBlank)
Me.Controls.Add(Me.TxtTypes)
Me.Controls.Add(Me.LnkTypes)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.TxtToGLYear)
Me.Controls.Add(Me.TxtFromGLYear)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Label7)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTXE10B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTXE10B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXE10.SbpScreen.Text = "TXE10"
End Sub
Private Sub FrmTXE10B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFromGLYear, "")
    ErrProv.SetError(TxtToGLYear, "")
    ErrProv.SetError(TxtTypes, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "fromglyear"
        ErrProv.SetError(TxtFromGLYear, ErrorMsg(I))
      Case "toglyear"
        ErrProv.SetError(TxtToGLYear, ErrorMsg(I))
      Case "type"
        ErrProv.SetError(TxtTypes, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtFromGLYear.Text) > MyUtils.CnvSng(TxtToGLYear.Text) Then
      ErrorField(I) = "fromglyear"
      ErrorMsg(I) = "Invalid Year Range"
      I = I + 1
      ErrorField(I) = "toglyear"
      ErrorMsg(I) = "Invalid Year Range"
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
Private Sub FrmTXE10B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MyTypes = ""
End Sub
Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
  MyTypes = TxtTypes.Text
  MyFrmSelTypes = New FrmSelTypes
  MyFrmSelTypes.MdiParent = Me.ParentForm
  MyFrmSelTypes.Show()
  Me.Hide()

End Sub
Private Sub TxtFromGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






