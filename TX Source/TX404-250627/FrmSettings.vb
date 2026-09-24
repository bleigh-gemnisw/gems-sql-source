Public Class FrmSettings
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
Friend WithEvents PrtDialog As System.Windows.Forms.PrintDialog
Friend WithEvents imageList1 As System.Windows.Forms.ImageList
Friend WithEvents TbMain As System.Windows.Forms.ToolBar
Friend WithEvents TBarSave As System.Windows.Forms.ToolBarButton
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtGridMax As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TBarReturn As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSettings))
Me.PrtDialog = New System.Windows.Forms.PrintDialog
Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.TbMain = New System.Windows.Forms.ToolBar
Me.TBarReturn = New System.Windows.Forms.ToolBarButton
Me.TBarSave = New System.Windows.Forms.ToolBarButton
Me.Label3 = New System.Windows.Forms.Label
Me.TxtGridMax = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.SuspendLayout()
'
'imageList1
'
Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
Me.imageList1.Images.SetKeyName(0, "")
Me.imageList1.Images.SetKeyName(1, "")
'
'TbMain
'
Me.TbMain.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarReturn, Me.TBarSave})
Me.TbMain.Dock = System.Windows.Forms.DockStyle.None
Me.TbMain.DropDownArrows = True
Me.TbMain.ImageList = Me.imageList1
Me.TbMain.Location = New System.Drawing.Point(8, 99)
Me.TbMain.Name = "TbMain"
Me.TbMain.ShowToolTips = True
Me.TbMain.Size = New System.Drawing.Size(88, 50)
Me.TbMain.TabIndex = 190
'
'TBarReturn
'
Me.TBarReturn.ImageIndex = 0
Me.TBarReturn.Name = "TBarReturn"
Me.TBarReturn.Text = "Return"
'
'TBarSave
'
Me.TBarSave.ImageIndex = 1
Me.TBarSave.Name = "TBarSave"
Me.TBarSave.Text = "Save"
'
'Label3
'
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(12, 25)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(248, 20)
Me.Label3.TabIndex = 202
Me.Label3.Text = "Number of records in Select Accounts screen "
'
'TxtGridMax
'
Me.TxtGridMax.Location = New System.Drawing.Point(266, 25)
Me.TxtGridMax.MaxLength = 4
Me.TxtGridMax.Name = "TxtGridMax"
Me.TxtGridMax.Size = New System.Drawing.Size(44, 20)
Me.TxtGridMax.TabIndex = 205
'
'Label1
'
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.Location = New System.Drawing.Point(12, 57)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(257, 28)
Me.Label1.TabIndex = 206
Me.Label1.Text = "Number range is 13 to 1000. The higher the number the lower the performance. Defa" & _
    "ult is 100."
Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'FrmSettings
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(322, 147)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtGridMax)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.TbMain)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmSettings"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Program settings"
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmSettings_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
	Me.Dispose()
End Sub

Private Sub FrmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  TxtGridMax.Text = MyGridMax

  With MyFrmTX404
    .TBarBack.Enabled = False
    .TBarSettings.Enabled = False
  End With
End Sub
Public Sub SaveData()
  Dim WrkGridMax As Integer

  WrkGridMax = MyUtils.CnvSng(TxtGridMax.Text)
  If WrkGridMax < 13 Or WrkGridMax > 1000 Then
    MsgBox("Number is not within valid range", MsgBoxStyle.Exclamation, "Cannot Save settings")
    Exit Sub
  End If

  MyAppSettings.GridMax = WrkGridMax
  SaveAppSettings()
  MyGridMax = WrkGridMax
  Me.Close()
End Sub

Private Sub FrmSettings_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  With MyFrmTX404
    .TBarBack.Enabled = True
    .TBarSettings.Enabled = True
  End With

End Sub

Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
  If e.Button Is TBarReturn Then
    Me.Close()
  End If

  If e.Button Is TBarSave Then
    SaveData()
  End If

End Sub
Private Sub TxtGridMax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGridMax.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






