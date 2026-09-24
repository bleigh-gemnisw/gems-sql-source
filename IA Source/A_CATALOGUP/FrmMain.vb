Imports System.io
Public Class FrmMain
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
    Friend WithEvents RbCatalog As System.Windows.Forms.RadioButton
    Friend WithEvents RbAll As System.Windows.Forms.RadioButton

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
Friend WithEvents BtnCheck As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.BtnCheck = New System.Windows.Forms.Button
Me.LblMsg = New System.Windows.Forms.Label
Me.RbCatalog = New System.Windows.Forms.RadioButton
Me.RbAll = New System.Windows.Forms.RadioButton
Me.SuspendLayout()
'
'BtnCheck
'
Me.BtnCheck.AutoSize = True
Me.BtnCheck.Location = New System.Drawing.Point(444, 12)
Me.BtnCheck.Name = "BtnCheck"
Me.BtnCheck.Size = New System.Drawing.Size(104, 30)
Me.BtnCheck.TabIndex = 0
Me.BtnCheck.Text = "Get updates"
'
'LblMsg
'
Me.LblMsg.AutoSize = True
Me.LblMsg.Location = New System.Drawing.Point(12, 51)
Me.LblMsg.Name = "LblMsg"
Me.LblMsg.Size = New System.Drawing.Size(0, 13)
Me.LblMsg.TabIndex = 1
'
'RbCatalog
'
Me.RbCatalog.AutoSize = True
Me.RbCatalog.Checked = True
Me.RbCatalog.Location = New System.Drawing.Point(25, 19)
Me.RbCatalog.Name = "RbCatalog"
Me.RbCatalog.Size = New System.Drawing.Size(98, 17)
Me.RbCatalog.TabIndex = 2
Me.RbCatalog.TabStop = True
Me.RbCatalog.Text = "A_Catalog Only"
Me.RbCatalog.UseVisualStyleBackColor = True
'
'RbAll
'
Me.RbAll.AutoSize = True
Me.RbAll.Location = New System.Drawing.Point(167, 19)
Me.RbAll.Name = "RbAll"
Me.RbAll.Size = New System.Drawing.Size(111, 17)
Me.RbAll.TabIndex = 3
Me.RbAll.Text = "All Supporting files"
Me.RbAll.UseVisualStyleBackColor = True
'
'FrmMain
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(560, 158)
Me.Controls.Add(Me.RbAll)
Me.Controls.Add(Me.RbCatalog)
Me.Controls.Add(Me.LblMsg)
Me.Controls.Add(Me.BtnCheck)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmMain"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "GEMS.NET Supporting files Update"
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub BtnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCheck.Click

  WrkMsg = String.Empty
  LblMsg.Text = String.Empty
  Windows.Forms.Cursor.Current = Cursors.WaitCursor
  RunUpdate()
  Windows.Forms.Cursor.Current = Cursors.Default
  LblMsg.Text = WrkMsg
End Sub

Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

End Sub
End Class
