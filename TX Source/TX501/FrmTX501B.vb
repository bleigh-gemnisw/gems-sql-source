Public Class FrmTX501B
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
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbSU As System.Windows.Forms.RadioButton
Friend WithEvents RbRE As System.Windows.Forms.RadioButton
Friend WithEvents RbMV As System.Windows.Forms.RadioButton
Friend WithEvents RbPP As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.RbSU = New System.Windows.Forms.RadioButton
Me.RbRE = New System.Windows.Forms.RadioButton
Me.RbMV = New System.Windows.Forms.RadioButton
Me.RbPP = New System.Windows.Forms.RadioButton
Me.GroupBox2.SuspendLayout()
Me.SuspendLayout()
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.RbSU)
Me.GroupBox2.Controls.Add(Me.RbRE)
Me.GroupBox2.Controls.Add(Me.RbMV)
Me.GroupBox2.Controls.Add(Me.RbPP)
Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox2.Location = New System.Drawing.Point(16, 12)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(160, 100)
Me.GroupBox2.TabIndex = 0
Me.GroupBox2.TabStop = False
Me.GroupBox2.Text = "Bill Type"
'
'RbSU
'
Me.RbSU.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbSU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbSU.Location = New System.Drawing.Point(12, 76)
Me.RbSU.Name = "RbSU"
Me.RbSU.Size = New System.Drawing.Size(140, 20)
Me.RbSU.TabIndex = 3
Me.RbSU.Text = "Supplemental MV"
'
'RbRE
'
Me.RbRE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbRE.Checked = True
Me.RbRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbRE.Location = New System.Drawing.Point(12, 16)
Me.RbRE.Name = "RbRE"
Me.RbRE.Size = New System.Drawing.Size(140, 20)
Me.RbRE.TabIndex = 0
Me.RbRE.TabStop = True
Me.RbRE.Text = "Real Estate"
'
'RbMV
'
Me.RbMV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbMV.Location = New System.Drawing.Point(12, 56)
Me.RbMV.Name = "RbMV"
Me.RbMV.Size = New System.Drawing.Size(140, 20)
Me.RbMV.TabIndex = 2
Me.RbMV.Text = "Motor Vehicle"
'
'RbPP
'
Me.RbPP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbPP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbPP.Location = New System.Drawing.Point(12, 36)
Me.RbPP.Name = "RbPP"
Me.RbPP.Size = New System.Drawing.Size(140, 20)
Me.RbPP.TabIndex = 1
Me.RbPP.Text = "Personal Property"
'
'FrmTX501B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(199, 131)
Me.ControlBox = False
Me.Controls.Add(Me.GroupBox2)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX501B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.GroupBox2.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

#End Region

  Public Sub RunReport()
    PrtReport()
  End Sub
Private Sub FrmTX501B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX501.SbpScreen.Text = "TX501B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
End Class






