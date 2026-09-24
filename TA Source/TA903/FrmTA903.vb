Public Class FrmTA903
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
    Friend WithEvents SbMain As System.Windows.Forms.StatusBar
    Friend WithEvents SbpPgmID As System.Windows.Forms.StatusBarPanel
    Friend WithEvents SbpScreen As System.Windows.Forms.StatusBarPanel
    Friend WithEvents SbpEnvironment As System.Windows.Forms.StatusBarPanel
    Friend WithEvents SbpFiller1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents SbpVersion As System.Windows.Forms.StatusBarPanel
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents TbMain As System.Windows.Forms.ToolBar
    Friend WithEvents TBarBack As System.Windows.Forms.ToolBarButton
    Friend WithEvents TBarExport As System.Windows.Forms.ToolBarButton
    Friend WithEvents TBarSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents TBarLayout As System.Windows.Forms.ToolBarButton
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTA903))
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
Me.SbMain = New System.Windows.Forms.StatusBar
Me.SbpPgmID = New System.Windows.Forms.StatusBarPanel
Me.SbpScreen = New System.Windows.Forms.StatusBarPanel
Me.SbpEnvironment = New System.Windows.Forms.StatusBarPanel
Me.SbpFiller1 = New System.Windows.Forms.StatusBarPanel
Me.SbpVersion = New System.Windows.Forms.StatusBarPanel
Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
Me.TbMain = New System.Windows.Forms.ToolBar
Me.TBarBack = New System.Windows.Forms.ToolBarButton
Me.TBarExport = New System.Windows.Forms.ToolBarButton
Me.TBarSep1 = New System.Windows.Forms.ToolBarButton
Me.TBarLayout = New System.Windows.Forms.ToolBarButton
CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'ImageList1
'
Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.ImageList1.TransparentColor = System.Drawing.Color.White
Me.ImageList1.Images.SetKeyName(0, "")
Me.ImageList1.Images.SetKeyName(1, "")
Me.ImageList1.Images.SetKeyName(2, "")
Me.ImageList1.Images.SetKeyName(3, "")
Me.ImageList1.Images.SetKeyName(4, "")
Me.ImageList1.Images.SetKeyName(5, "")
'
'SbMain
'
Me.SbMain.Location = New System.Drawing.Point(0, 498)
Me.SbMain.Name = "SbMain"
Me.SbMain.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.SbpPgmID, Me.SbpScreen, Me.SbpEnvironment, Me.SbpFiller1, Me.SbpVersion})
Me.SbMain.ShowPanels = True
Me.SbMain.Size = New System.Drawing.Size(768, 28)
Me.SbMain.SizingGrip = False
Me.SbMain.TabIndex = 11
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
'TbMain
'
Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarBack, Me.TBarExport, Me.TBarSep1, Me.TBarLayout})
Me.TbMain.DropDownArrows = True
Me.TbMain.ImageList = Me.ImageList1
Me.TbMain.Location = New System.Drawing.Point(0, 0)
Me.TbMain.Name = "TbMain"
Me.TbMain.ShowToolTips = True
Me.TbMain.Size = New System.Drawing.Size(768, 50)
Me.TbMain.TabIndex = 13
'
'TBarBack
'
Me.TBarBack.ImageIndex = 0
Me.TBarBack.Name = "TBarBack"
Me.TBarBack.Text = "Back"
'
'TBarExport
'
Me.TBarExport.ImageIndex = 5
Me.TBarExport.Name = "TBarExport"
Me.TBarExport.Text = "Export"
'
'TBarSep1
'
Me.TBarSep1.Name = "TBarSep1"
Me.TBarSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
'
'TBarLayout
'
Me.TBarLayout.Name = "TBarLayout"
Me.TBarLayout.Text = "File Layout"
'
'FrmTA903
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.BackColor = System.Drawing.SystemColors.Control
Me.ClientSize = New System.Drawing.Size(768, 526)
Me.Controls.Add(Me.TbMain)
Me.Controls.Add(Me.SbMain)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.IsMdiContainer = True
Me.MaximizeBox = False
Me.Name = "FrmTA903"
Me.HelpProvider1.SetShowHelp(Me, True)
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Export Motor Vehicle Grand List file"
CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

    Private Sub FrmTA903_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim WrkProgName As String
        WrkProgName = MyUtils.GetProgramName(False)

        SbpPgmID.Text = WrkProgName
        SbpEnvironment.Text = myDBConnect.PgmDB
        HelpProvider1.HelpNamespace = MyUtils.GetHelpFile(WrkProgName)

        MyFrmTA903B = New FrmTA903B
        MyFrmTA903B.MdiParent = Me
        MyFrmTA903B.Show()
    End Sub
Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
  If e.Button Is TBarBack Then
    DoBtnBack()
  End If
  If e.Button Is TBarExport Then
    DoBtnExport()
  End If
  If e.Button Is TBarLayout Then
    DoBtnLayout()
  End If
End Sub
Private Sub DoBtnBack()
  Select Case SbpScreen.Text
  Case "TA903B"
    MyFrmTA903.Close()
  End Select
End Sub
Private Sub DoBtnExport()
   TBarExport.Enabled = False
	 MyFrmTA903B.RunExport()
   TBarExport.Enabled = True
End Sub
Private Sub DoBtnLayout()
   PrntLayout()
End Sub
Private Sub SbMain_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles SbMain.PanelClick
	If e.StatusBarPanel Is SbpVersion Then
    ShowSplash()
  End If
End Sub
End Class






