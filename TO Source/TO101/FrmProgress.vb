Public Class FrmProgress
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
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents ProgBar1 As System.Windows.Forms.ProgressBar
Friend WithEvents LblMsg As System.Windows.Forms.Label
Friend WithEvents BtnCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.ProgBar1 = New System.Windows.Forms.ProgressBar
Me.Label1 = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.BtnCancel = New System.Windows.Forms.Button
Me.LblMsg = New System.Windows.Forms.Label
Me.SuspendLayout()
'
'ProgBar1
'
Me.ProgBar1.Location = New System.Drawing.Point(16, 47)
Me.ProgBar1.Name = "ProgBar1"
Me.ProgBar1.Size = New System.Drawing.Size(264, 16)
Me.ProgBar1.TabIndex = 0
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(16, 23)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(16, 16)
Me.Label1.TabIndex = 1
Me.Label1.Text = "0"
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(136, 23)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(24, 16)
Me.Label2.TabIndex = 2
Me.Label2.Text = "50"
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(257, 23)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(31, 16)
Me.Label3.TabIndex = 3
Me.Label3.Text = "100"
'
'BtnCancel
'
Me.BtnCancel.Location = New System.Drawing.Point(112, 71)
Me.BtnCancel.Name = "BtnCancel"
Me.BtnCancel.Size = New System.Drawing.Size(64, 32)
Me.BtnCancel.TabIndex = 4
Me.BtnCancel.TabStop = False
Me.BtnCancel.Text = "Cancel"
Me.BtnCancel.Visible = False
'
'LblMsg
'
Me.LblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblMsg.ForeColor = System.Drawing.Color.Fuchsia
Me.LblMsg.Location = New System.Drawing.Point(16, 0)
Me.LblMsg.Name = "LblMsg"
Me.LblMsg.Size = New System.Drawing.Size(264, 12)
Me.LblMsg.TabIndex = 5
Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'FrmProgress
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(292, 86)
Me.ControlBox = False
Me.Controls.Add(Me.LblMsg)
Me.Controls.Add(Me.BtnCancel)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.ProgBar1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmProgress"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Creating Report..."
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
'Dim WrkAnswer As Integer

'MyReportCancel = False
'WrkAnswer = MsgBox("Click OK to cancel report", MsgBoxStyle.OKCancel, "Report cancel pending")
'If WrkAnswer = MsgBoxResult.OK Then
'  MyReportCancel = True
'End If

End Sub

Private Sub FrmProgress_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus

End Sub

Private Sub FrmProgress_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

End Sub
End Class






