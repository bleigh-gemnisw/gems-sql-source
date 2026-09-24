Public Class FrmAP305
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
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TbMain As System.Windows.Forms.ToolBar
    Friend WithEvents TBarBack As System.Windows.Forms.ToolBarButton
    Friend WithEvents SbMain As System.Windows.Forms.StatusBar
    Friend WithEvents SbpPgmID As System.Windows.Forms.StatusBarPanel
    Friend WithEvents SbpScreen As System.Windows.Forms.StatusBarPanel
Friend WithEvents SbpFiller1 As System.Windows.Forms.StatusBarPanel
Friend WithEvents SbpVersion As System.Windows.Forms.StatusBarPanel
Friend WithEvents TBarSep1 As System.Windows.Forms.ToolBarButton
Friend WithEvents SbpEnvironment As System.Windows.Forms.StatusBarPanel
Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
Friend WithEvents PreDefinedLabelsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
Friend WithEvents MnuAvery5160 As System.Windows.Forms.ToolStripMenuItem
Friend WithEvents TBarProcess As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAP305))
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarBack = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep1 = New System.Windows.Forms.ToolBarButton()
    Me.TBarProcess = New System.Windows.Forms.ToolBarButton()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.SbMain = New System.Windows.Forms.StatusBar()
    Me.SbpPgmID = New System.Windows.Forms.StatusBarPanel()
    Me.SbpScreen = New System.Windows.Forms.StatusBarPanel()
    Me.SbpEnvironment = New System.Windows.Forms.StatusBarPanel()
    Me.SbpFiller1 = New System.Windows.Forms.StatusBarPanel()
    Me.SbpVersion = New System.Windows.Forms.StatusBarPanel()
    Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
    Me.PreDefinedLabelsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.MnuAvery5160 = New System.Windows.Forms.ToolStripMenuItem()
    CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.MenuStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'TbMain
    '
    Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarBack, Me.TBarSep1, Me.TBarProcess})
    Me.TbMain.DropDownArrows = True
    Me.TbMain.ImageList = Me.ImageList1
    Me.TbMain.Location = New System.Drawing.Point(0, 0)
    Me.TbMain.Name = "TbMain"
    Me.TbMain.ShowToolTips = True
    Me.TbMain.Size = New System.Drawing.Size(768, 50)
    Me.TbMain.TabIndex = 1
    '
    'TBarBack
    '
    Me.TBarBack.ImageIndex = 0
    Me.TBarBack.Name = "TBarBack"
    Me.TBarBack.Text = "&Back"
    '
    'TBarSep1
    '
    Me.TBarSep1.Name = "TBarSep1"
    Me.TBarSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
    '
    'TBarProcess
    '
    Me.TBarProcess.ImageIndex = 1
    Me.TBarProcess.Name = "TBarProcess"
    Me.TBarProcess.Text = "&Process"
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.White
    Me.ImageList1.Images.SetKeyName(0, "")
    Me.ImageList1.Images.SetKeyName(1, "")
    '
    'SbMain
    '
    Me.SbMain.Location = New System.Drawing.Point(0, 586)
    Me.SbMain.Name = "SbMain"
    Me.SbMain.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.SbpPgmID, Me.SbpScreen, Me.SbpEnvironment, Me.SbpFiller1, Me.SbpVersion})
    Me.SbMain.ShowPanels = True
    Me.SbMain.Size = New System.Drawing.Size(768, 28)
    Me.SbMain.SizingGrip = False
    Me.SbMain.TabIndex = 5
    '
    'SbpPgmID
    '
    Me.SbpPgmID.Name = "SbpPgmID"
    Me.SbpPgmID.Width = 50
    '
    'SbpScreen
    '
    Me.SbpScreen.Name = "SbpScreen"
    Me.SbpScreen.Width = 60
    '
    'SbpEnvironment
    '
    Me.SbpEnvironment.Name = "SbpEnvironment"
    '
    'SbpFiller1
    '
    Me.SbpFiller1.Name = "SbpFiller1"
    Me.SbpFiller1.Width = 450
    '
    'SbpVersion
    '
    Me.SbpVersion.Alignment = System.Windows.Forms.HorizontalAlignment.Center
    Me.SbpVersion.Name = "SbpVersion"
    Me.SbpVersion.Text = "About Program"
    '
    'MenuStrip1
    '
    Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PreDefinedLabelsToolStripMenuItem})
    Me.MenuStrip1.Location = New System.Drawing.Point(0, 50)
    Me.MenuStrip1.Name = "MenuStrip1"
    Me.MenuStrip1.Size = New System.Drawing.Size(768, 24)
    Me.MenuStrip1.TabIndex = 10
    Me.MenuStrip1.Text = "MenuStrip1"
    '
    'PreDefinedLabelsToolStripMenuItem
    '
    Me.PreDefinedLabelsToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText
    Me.PreDefinedLabelsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuAvery5160})
    Me.PreDefinedLabelsToolStripMenuItem.ForeColor = System.Drawing.Color.Fuchsia
    Me.PreDefinedLabelsToolStripMenuItem.Name = "PreDefinedLabelsToolStripMenuItem"
    Me.PreDefinedLabelsToolStripMenuItem.Size = New System.Drawing.Size(184, 20)
    Me.PreDefinedLabelsToolStripMenuItem.Text = "Get Label Settings <Click here>"
    '
    'MnuAvery5160
    '
    Me.MnuAvery5160.Name = "MnuAvery5160"
    Me.MnuAvery5160.Size = New System.Drawing.Size(131, 22)
    Me.MnuAvery5160.Text = "Avery 5160"
    '
    'FrmAP305
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.BackColor = System.Drawing.SystemColors.Control
    Me.ClientSize = New System.Drawing.Size(768, 614)
    Me.Controls.Add(Me.MenuStrip1)
    Me.Controls.Add(Me.SbMain)
    Me.Controls.Add(Me.TbMain)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.IsMdiContainer = True
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.Name = "FrmAP305"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Print Vendor Labels"
    CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).EndInit()
    Me.MenuStrip1.ResumeLayout(False)
    Me.MenuStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmAP305_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Me.SbpPgmID.Text = "AP305"
  TBarProcess.Enabled = True
  set_security() '#set

  MyFrmAP305B = New FrmAP305B
  MyFrmAP305B.MdiParent = Me
  MyFrmAP305B.Show()
End Sub
Private Sub set_security()
' note: these will change depending on the application program.
' change is difficult as the save button will need to be disabled for it but enabled for add
  If s_full = True Then
    Exit Sub
  End If
  If s_edit = False Then
    TBarProcess.Visible = False
  End If
End Sub
Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
  If e.Button Is TBarBack Then
    DoBtnBack()
  End If
  If e.Button Is TBarProcess Then
    DoBtnPrint()
  End If
End Sub
Private Sub FrmAP305_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub
  If e.KeyCode = Keys.F12 Then
    MyUtils.PrtScreen(Form.ActiveForm)
  End If
  If e.KeyCode = Keys.B Then
    DoBtnBack()
  End If
  If e.KeyCode = Keys.P Then
    DoBtnPrint()
  End If
End Sub
Private Sub DoBtnBack()
  Select Case SbpScreen.Text
  Case "AP305B"
    MyFrmAP305.Close()
  End Select
End Sub
Private Sub DoBtnPrint()
   MyFrmAP305.TBarProcess.Enabled = False
   MyFrmAP305B.RunReport()
   MyFrmAP305.TBarProcess.Enabled = True
End Sub
Private Sub SbMain_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles SbMain.PanelClick
  If e.StatusBarPanel Is SbpVersion Then
    ShowSplash()
  End If
End Sub
Private Sub MnuAvery5160_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuAvery5160.Click
  With MyFrmAP305B
    .TxtHAdjust1.Text = ""
    .TxtHAdjust2.Text = "6"
    .TxtHAdjust3.Text = "6"
    .TxtVAdjust1.Text = "350"
    .TxtVAdjust2.Text = "50"
  End With
End Sub
End Class
