Public Class FrmTA331B
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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbSU As System.Windows.Forms.RadioButton
  Friend WithEvents RbMV As System.Windows.Forms.RadioButton
  Friend WithEvents RbPP As System.Windows.Forms.RadioButton
  Friend WithEvents RbRE As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents ChkDeletes As System.Windows.Forms.CheckBox
  Friend WithEvents ChkChanges As System.Windows.Forms.CheckBox
  Friend WithEvents ChkAdds As System.Windows.Forms.CheckBox
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.DtPckFrom = New System.Windows.Forms.DateTimePicker
Me.DtPckTo = New System.Windows.Forms.DateTimePicker
Me.Label2 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.RbSU = New System.Windows.Forms.RadioButton
Me.RbMV = New System.Windows.Forms.RadioButton
Me.RbPP = New System.Windows.Forms.RadioButton
Me.RbRE = New System.Windows.Forms.RadioButton
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.ChkDeletes = New System.Windows.Forms.CheckBox
Me.ChkChanges = New System.Windows.Forms.CheckBox
Me.ChkAdds = New System.Windows.Forms.CheckBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
Me.GroupBox2.SuspendLayout()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(16, 56)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(60, 16)
Me.Label1.TabIndex = 0
Me.Label1.Text = "From Date"
'
'DtPckFrom
'
Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckFrom.Location = New System.Drawing.Point(76, 52)
Me.DtPckFrom.Name = "DtPckFrom"
Me.DtPckFrom.Size = New System.Drawing.Size(88, 20)
Me.DtPckFrom.TabIndex = 4
'
'DtPckTo
'
Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckTo.Location = New System.Drawing.Point(236, 52)
Me.DtPckTo.Name = "DtPckTo"
Me.DtPckTo.Size = New System.Drawing.Size(88, 20)
Me.DtPckTo.TabIndex = 6
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(184, 56)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(52, 16)
Me.Label2.TabIndex = 5
Me.Label2.Text = "To Date"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.RbSU)
Me.GroupBox1.Controls.Add(Me.RbMV)
Me.GroupBox1.Controls.Add(Me.RbPP)
Me.GroupBox1.Controls.Add(Me.RbRE)
Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(464, 32)
Me.GroupBox1.TabIndex = 26
Me.GroupBox1.TabStop = False
'
'RbSU
'
Me.RbSU.Location = New System.Drawing.Point(344, 8)
Me.RbSU.Name = "RbSU"
Me.RbSU.Size = New System.Drawing.Size(112, 16)
Me.RbSU.TabIndex = 7
Me.RbSU.Text = "S&upplemental MV"
'
'RbMV
'
Me.RbMV.Location = New System.Drawing.Point(232, 8)
Me.RbMV.Name = "RbMV"
Me.RbMV.Size = New System.Drawing.Size(96, 16)
Me.RbMV.TabIndex = 6
Me.RbMV.Text = "&Motor Vehicle"
'
'RbPP
'
Me.RbPP.Location = New System.Drawing.Point(104, 8)
Me.RbPP.Name = "RbPP"
Me.RbPP.Size = New System.Drawing.Size(120, 16)
Me.RbPP.TabIndex = 5
Me.RbPP.Text = "P&ersonal Property"
'
'RbRE
'
Me.RbRE.Checked = True
Me.RbRE.Location = New System.Drawing.Point(10, 10)
Me.RbRE.Name = "RbRE"
Me.RbRE.Size = New System.Drawing.Size(88, 16)
Me.RbRE.TabIndex = 4
Me.RbRE.TabStop = True
Me.RbRE.Text = "&Real Estate"
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.ChkDeletes)
Me.GroupBox2.Controls.Add(Me.ChkChanges)
Me.GroupBox2.Controls.Add(Me.ChkAdds)
Me.GroupBox2.Location = New System.Drawing.Point(12, 78)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(291, 40)
Me.GroupBox2.TabIndex = 30
Me.GroupBox2.TabStop = False
Me.GroupBox2.Text = "Include"
'
'ChkDeletes
'
Me.ChkDeletes.AutoSize = True
Me.ChkDeletes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkDeletes.Checked = True
Me.ChkDeletes.CheckState = System.Windows.Forms.CheckState.Checked
Me.ChkDeletes.Location = New System.Drawing.Point(209, 17)
Me.ChkDeletes.Name = "ChkDeletes"
Me.ChkDeletes.Size = New System.Drawing.Size(68, 17)
Me.ChkDeletes.TabIndex = 32
Me.ChkDeletes.Text = "Deletes?"
Me.ChkDeletes.UseVisualStyleBackColor = True
'
'ChkChanges
'
Me.ChkChanges.AutoSize = True
Me.ChkChanges.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkChanges.Checked = True
Me.ChkChanges.CheckState = System.Windows.Forms.CheckState.Checked
Me.ChkChanges.Location = New System.Drawing.Point(99, 17)
Me.ChkChanges.Name = "ChkChanges"
Me.ChkChanges.Size = New System.Drawing.Size(74, 17)
Me.ChkChanges.TabIndex = 31
Me.ChkChanges.Text = "Changes?"
Me.ChkChanges.UseVisualStyleBackColor = True
'
'ChkAdds
'
Me.ChkAdds.AutoSize = True
Me.ChkAdds.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkAdds.Checked = True
Me.ChkAdds.CheckState = System.Windows.Forms.CheckState.Checked
Me.ChkAdds.Location = New System.Drawing.Point(10, 17)
Me.ChkAdds.Name = "ChkAdds"
Me.ChkAdds.Size = New System.Drawing.Size(56, 17)
Me.ChkAdds.TabIndex = 30
Me.ChkAdds.Text = "Adds?"
Me.ChkAdds.UseVisualStyleBackColor = True
'
'FrmTA331B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(516, 131)
Me.ControlBox = False
Me.Controls.Add(Me.GroupBox2)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.DtPckTo)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.DtPckFrom)
Me.Controls.Add(Me.Label1)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTA331B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox2.ResumeLayout(False)
Me.GroupBox2.PerformLayout()
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmTA331B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTA331.SbpScreen.Text = "TA331"
End Sub
Private Sub FrmTA331B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
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
Private Sub FrmTA331B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  DtPckFrom.Value = Date.Today
  DtPckTo.Value = Date.Today
End Sub
Private Sub TxtFromGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






