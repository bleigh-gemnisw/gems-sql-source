Public Class FrmTA420
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
    Friend WithEvents TBarPrint As System.Windows.Forms.ToolBarButton
    Friend WithEvents TBarBack As System.Windows.Forms.ToolBarButton
    Friend WithEvents SbMain As System.Windows.Forms.StatusBar
    Friend WithEvents SbpPgmID As System.Windows.Forms.StatusBarPanel
    Friend WithEvents SbpScreen As System.Windows.Forms.StatusBarPanel
Friend WithEvents SbpFiller1 As System.Windows.Forms.StatusBarPanel
Friend WithEvents SbpVersion As System.Windows.Forms.StatusBarPanel
Friend WithEvents TBarSep1 As System.Windows.Forms.ToolBarButton
Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
Friend WithEvents TsOrient As System.Windows.Forms.ToolStripDropDownButton
Friend WithEvents TsOrientPortrait As System.Windows.Forms.ToolStripMenuItem
Friend WithEvents TsOrientLandscape As System.Windows.Forms.ToolStripMenuItem
Friend WithEvents TsOrientDesc As System.Windows.Forms.ToolStripLabel
Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
Friend WithEvents SbpEnvironment As System.Windows.Forms.StatusBarPanel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTA420))
Me.TbMain = New System.Windows.Forms.ToolBar
Me.TBarBack = New System.Windows.Forms.ToolBarButton
Me.TBarSep1 = New System.Windows.Forms.ToolBarButton
Me.TBarPrint = New System.Windows.Forms.ToolBarButton
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.SbMain = New System.Windows.Forms.StatusBar
Me.SbpPgmID = New System.Windows.Forms.StatusBarPanel
Me.SbpScreen = New System.Windows.Forms.StatusBarPanel
Me.SbpEnvironment = New System.Windows.Forms.StatusBarPanel
Me.SbpFiller1 = New System.Windows.Forms.StatusBarPanel
Me.SbpVersion = New System.Windows.Forms.StatusBarPanel
Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
Me.TsOrient = New System.Windows.Forms.ToolStripDropDownButton
Me.TsOrientPortrait = New System.Windows.Forms.ToolStripMenuItem
Me.TsOrientLandscape = New System.Windows.Forms.ToolStripMenuItem
Me.TsOrientDesc = New System.Windows.Forms.ToolStripLabel
Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).BeginInit()
Me.ToolStrip1.SuspendLayout()
Me.SuspendLayout()
'
'TbMain
'
Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarBack, Me.TBarSep1, Me.TBarPrint})
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
'TBarPrint
'
Me.TBarPrint.ImageIndex = 1
Me.TBarPrint.Name = "TBarPrint"
Me.TBarPrint.Text = "&Print"
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
'ToolStrip1
'
Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsOrient, Me.TsOrientDesc, Me.ToolStripLabel1})
Me.ToolStrip1.Location = New System.Drawing.Point(0, 50)
Me.ToolStrip1.Name = "ToolStrip1"
Me.ToolStrip1.Size = New System.Drawing.Size(768, 25)
Me.ToolStrip1.TabIndex = 8
Me.ToolStrip1.Text = "ToolStrip1"
'
'TsOrient
'
Me.TsOrient.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsOrientPortrait, Me.TsOrientLandscape})
Me.TsOrient.Image = CType(resources.GetObject("TsOrient.Image"), System.Drawing.Image)
Me.TsOrient.ImageTransparentColor = System.Drawing.Color.Magenta
Me.TsOrient.Name = "TsOrient"
Me.TsOrient.Size = New System.Drawing.Size(90, 22)
Me.TsOrient.Text = "Orientation"
'
'TsOrientPortrait
'
Me.TsOrientPortrait.Checked = True
Me.TsOrientPortrait.CheckState = System.Windows.Forms.CheckState.Checked
Me.TsOrientPortrait.Name = "TsOrientPortrait"
Me.TsOrientPortrait.Size = New System.Drawing.Size(136, 22)
Me.TsOrientPortrait.Text = "Portrait"
'
'TsOrientLandscape
'
Me.TsOrientLandscape.Name = "TsOrientLandscape"
Me.TsOrientLandscape.Size = New System.Drawing.Size(136, 22)
Me.TsOrientLandscape.Text = "Landscape"
'
'TsOrientDesc
'
Me.TsOrientDesc.Name = "TsOrientDesc"
Me.TsOrientDesc.Size = New System.Drawing.Size(0, 22)
'
'ToolStripLabel1
'
Me.ToolStripLabel1.Name = "ToolStripLabel1"
Me.ToolStripLabel1.Size = New System.Drawing.Size(0, 22)
'
'FrmTA420
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.BackColor = System.Drawing.SystemColors.Control
Me.ClientSize = New System.Drawing.Size(768, 614)
Me.Controls.Add(Me.ToolStrip1)
Me.Controls.Add(Me.SbMain)
Me.Controls.Add(Me.TbMain)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.IsMdiContainer = True
Me.KeyPreview = True
Me.MaximizeBox = False
Me.Name = "FrmTA420"
Me.HelpProvider1.SetShowHelp(Me, True)
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Auto Pricing of Unpriced Vehicles"
CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).EndInit()
Me.ToolStrip1.ResumeLayout(False)
Me.ToolStrip1.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTA420_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Dim WrkProgName As String
  WrkProgName = MyUtils.GetProgramName(False)

  SbpPgmID.Text = WrkProgName
  SbpEnvironment.Text = myDBConnect.PgmDB
  HelpProvider1.HelpNamespace = MyUtils.GetHelpFile(WrkProgName)

  TBarPrint.Enabled = True
  set_security() '#set
  GetReportOrientation()
  ShowReportOrientation()

  MyFrmTA420B = New FrmTA420B
  MyFrmTA420B.MdiParent = Me
  MyFrmTA420B.Show()
End Sub
Private Sub set_security()
' note: these will change depending on the application program.
' change is difficult as the save button will need to be disabled for it but enabled for add
  If s_full = True Then
    Exit Sub
  End If
  If s_edit = False Then
    TBarPrint.Visible = False
  End If
End Sub
Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
  If e.Button Is TBarBack Then
    DoBtnBack()
  End If
  If e.Button Is TBarPrint Then
    DoBtnPrint()
  End If
End Sub
Private Sub FrmTA420_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
  Case "TA420B"
    MyFrmTA420.Close()
  Case "ListCodes"
    MyFrmListCodes.Close()
  End Select
End Sub
Private Sub DoBtnPrint()
   MyFrmTA420B.RunReport()
End Sub
Private Sub GetReportOrientation()
   MyReportLandscape = False
   If MyAppSettings.PrintOrient = "L" Then
     MyReportLandscape = True
   End If
End Sub
Private Sub SetReportOrientation()
   If MyReportLandscape Then
     MyAppSettings.PrintOrient = "L"
   Else
     MyAppSettings.PrintOrient = "P"
   End If
   SaveAppSettings()
End Sub
Private Sub ShowReportOrientation()
   If MyReportLandscape Then
     TsOrientLandscape.Checked = True
     TsOrientPortrait.Checked = False
     TsOrientDesc.Text = "Landscape"
   Else
     TsOrientPortrait.Checked = True
     TsOrientLandscape.Checked = False
     TsOrientDesc.Text = "Portrait"
   End If
End Sub
Private Sub SbMain_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles SbMain.PanelClick
  If e.StatusBarPanel Is SbpVersion Then
    ShowSplash()
  End If
End Sub

Private Sub TsOrientPortrait_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsOrientPortrait.Click
  MyReportLandscape = False
  SetReportOrientation()
  ShowReportOrientation()
End Sub

Private Sub TsOrientLandscape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsOrientLandscape.Click
   MyReportLandscape = True
   SetReportOrientation()
   ShowReportOrientation()
End Sub
End Class






