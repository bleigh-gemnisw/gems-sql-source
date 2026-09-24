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
    Friend WithEvents LblMsg As System.Windows.Forms.Label

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
Friend WithEvents ProgBar1 As System.Windows.Forms.ProgressBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.ProgBar1 = New System.Windows.Forms.ProgressBar
Me.LblMsg = New System.Windows.Forms.Label
Me.SuspendLayout()
'
'ProgBar1
'
Me.ProgBar1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
Me.ProgBar1.Location = New System.Drawing.Point(16, 42)
Me.ProgBar1.Name = "ProgBar1"
Me.ProgBar1.Size = New System.Drawing.Size(264, 16)
Me.ProgBar1.TabIndex = 0
'
'LblMsg
'
Me.LblMsg.Location = New System.Drawing.Point(13, 9)
Me.LblMsg.Name = "LblMsg"
Me.LblMsg.Size = New System.Drawing.Size(267, 20)
Me.LblMsg.TabIndex = 1
Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'FrmProgress
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(292, 70)
Me.ControlBox = False
Me.Controls.Add(Me.LblMsg)
Me.Controls.Add(Me.ProgBar1)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmProgress"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Creating Report..."
Me.ResumeLayout(False)

End Sub

#End Region

End Class






