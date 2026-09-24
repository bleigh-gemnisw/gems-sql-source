Public Class FrmTAD02B
  Inherits System.Windows.Forms.Form

  Friend ds As DataSet = New DataSet

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
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents RbPP As System.Windows.Forms.RadioButton
Friend WithEvents RbRE As System.Windows.Forms.RadioButton
Friend WithEvents RbAll As System.Windows.Forms.RadioButton
Friend WithEvents RbMV As System.Windows.Forms.RadioButton
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Label1 = New System.Windows.Forms.Label
Me.RbRE = New System.Windows.Forms.RadioButton
Me.RbPP = New System.Windows.Forms.RadioButton
Me.RbMV = New System.Windows.Forms.RadioButton
Me.RbAll = New System.Windows.Forms.RadioButton
Me.Label2 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Label1
'
Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.Location = New System.Drawing.Point(20, 24)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(287, 28)
Me.Label1.TabIndex = 0
Me.Label1.Text = "This option will set file(s) to Soft Freeze"
'
'RbRE
'
Me.RbRE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbRE.Location = New System.Drawing.Point(23, 55)
Me.RbRE.Name = "RbRE"
Me.RbRE.Size = New System.Drawing.Size(117, 22)
Me.RbRE.TabIndex = 4
Me.RbRE.Text = "Real Estate?"
Me.RbRE.UseVisualStyleBackColor = True
'
'RbPP
'
Me.RbPP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbPP.Location = New System.Drawing.Point(23, 78)
Me.RbPP.Name = "RbPP"
Me.RbPP.Size = New System.Drawing.Size(117, 17)
Me.RbPP.TabIndex = 5
Me.RbPP.Text = "Personal Property?"
Me.RbPP.UseVisualStyleBackColor = True
'
'RbMV
'
Me.RbMV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbMV.Location = New System.Drawing.Point(23, 101)
Me.RbMV.Name = "RbMV"
Me.RbMV.Size = New System.Drawing.Size(117, 17)
Me.RbMV.TabIndex = 6
Me.RbMV.Text = "Motor Vehicle?"
Me.RbMV.UseVisualStyleBackColor = True
'
'RbAll
'
Me.RbAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbAll.Checked = True
Me.RbAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbAll.Location = New System.Drawing.Point(23, 124)
Me.RbAll.Name = "RbAll"
Me.RbAll.Size = New System.Drawing.Size(117, 19)
Me.RbAll.TabIndex = 7
Me.RbAll.TabStop = True
Me.RbAll.Text = "All the above?"
Me.RbAll.UseVisualStyleBackColor = True
'
'Label2
'
Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label2.Location = New System.Drawing.Point(12, 164)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(306, 52)
Me.Label2.TabIndex = 8
Me.Label2.Text = "NOTICE: All Daily Assessment Information (TA001) screens should be closed now or " & _
    "restarted after processing is complete"
'
'FrmTAD02B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(330, 225)
Me.ControlBox = False
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.RbAll)
Me.Controls.Add(Me.RbMV)
Me.Controls.Add(Me.RbPP)
Me.Controls.Add(Me.RbRE)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
Me.MaximizeBox = False
Me.Name = "FrmTAD02B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmTAD02B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

 End Sub


Private Sub FrmTAD02B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTAD02.SbpScreen.Text = "TAD02B"
  MyFrmTAD02.TBarProcess.Enabled = True
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

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
Public Sub RunProcess()
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

    ProcData()
    Windows.Forms.Cursor.Current = Cursors.Default
End Sub


Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

End Sub
End Class






