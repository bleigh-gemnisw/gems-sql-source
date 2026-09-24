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
Friend WithEvents imageList1 As System.Windows.Forms.ImageList
Friend WithEvents TbMain As System.Windows.Forms.ToolBar
Friend WithEvents TBarSave As System.Windows.Forms.ToolBarButton
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents LblFilePath As System.Windows.Forms.Label
Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
Friend WithEvents TBarReturn As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSettings))
    Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarReturn = New System.Windows.Forms.ToolBarButton()
    Me.TBarSave = New System.Windows.Forms.ToolBarButton()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.GroupBox1.SuspendLayout()
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
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LblFilePath)
    Me.GroupBox1.Controls.Add(Me.LnkFilePath)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(344, 85)
    Me.GroupBox1.TabIndex = 217
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Directory for Image Files"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(70, 24)
    Me.LblFilePath.Name = "LblFilePath"
    Me.LblFilePath.Size = New System.Drawing.Size(268, 53)
    Me.LblFilePath.TabIndex = 67
    '
    'LnkFilePath
    '
    Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePath.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePath.Name = "LnkFilePath"
    Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath.TabIndex = 8
    Me.LnkFilePath.TabStop = True
    Me.LnkFilePath.Text = "File Path"
    '
    'FrmSettings
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(362, 147)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TbMain)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmSettings"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Program settings"
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmSettings_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
  Me.Dispose()
End Sub

Private Sub FrmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  LblFilePath.Text = MyAppSettings.ImageDir
  With MyFrmFA001
    .TBarBack.Enabled = False
    .TBarSettings.Enabled = False
  End With
End Sub
Public Sub SaveData()
  MyAppSettings.ImageDir = LblFilePath.Text
  SaveAppSettings()
  Me.Close()
End Sub

Private Sub FrmSettings_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  With MyFrmFA001
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

Private Sub LnkFilePath_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
  Dim Pos As Integer

  With SaveFileDialog1
    .FileName = "Save"
    .ShowDialog()
    Pos = InStrRev(.FileName, "\")
    LblFilePath.Text = Mid(.FileName, 1, Pos)
  End With
End Sub
End Class
