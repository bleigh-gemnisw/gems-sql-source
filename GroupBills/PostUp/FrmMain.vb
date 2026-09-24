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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TbMain As System.Windows.Forms.ToolBar
    Friend WithEvents TBarSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents TBarBack As System.Windows.Forms.ToolBarButton
    Friend WithEvents SbMain As System.Windows.Forms.StatusBar
    Friend WithEvents SbpPgmID As System.Windows.Forms.StatusBarPanel
    Friend WithEvents SbpScreen As System.Windows.Forms.StatusBarPanel
Friend WithEvents SbpFiller1 As System.Windows.Forms.StatusBarPanel
Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
Friend WithEvents SbpEnvironment As System.Windows.Forms.StatusBarPanel
Friend WithEvents TBarExport As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarSetPostal As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarImport As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarBack = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep1 = New System.Windows.Forms.ToolBarButton()
    Me.TBarImport = New System.Windows.Forms.ToolBarButton()
    Me.TBarExport = New System.Windows.Forms.ToolBarButton()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.SbMain = New System.Windows.Forms.StatusBar()
    Me.SbpPgmID = New System.Windows.Forms.StatusBarPanel()
    Me.SbpScreen = New System.Windows.Forms.StatusBarPanel()
    Me.SbpEnvironment = New System.Windows.Forms.StatusBarPanel()
    Me.SbpFiller1 = New System.Windows.Forms.StatusBarPanel()
    Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
    Me.TBarSetPostal = New System.Windows.Forms.ToolBarButton()
    CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TbMain
    '
    Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarBack, Me.TBarSep1, Me.TBarImport, Me.TBarExport, Me.TBarSetPostal})
    Me.TbMain.DropDownArrows = True
    Me.TbMain.ImageList = Me.ImageList1
    Me.TbMain.Location = New System.Drawing.Point(0, 0)
    Me.TbMain.Name = "TbMain"
    Me.TbMain.ShowToolTips = True
    Me.TbMain.Size = New System.Drawing.Size(624, 50)
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
    'TBarImport
    '
    Me.TBarImport.ImageIndex = 5
    Me.TBarImport.Name = "TBarImport"
    Me.TBarImport.Text = "&Import"
    '
    'TBarExport
    '
    Me.TBarExport.ImageIndex = 6
    Me.TBarExport.Name = "TBarExport"
    Me.TBarExport.Text = "&Export"
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
    Me.ImageList1.Images.SetKeyName(6, "export_png_194.png")
    Me.ImageList1.Images.SetKeyName(7, "update row_24.png")
    '
    'SbMain
    '
    Me.SbMain.Location = New System.Drawing.Point(0, 356)
    Me.SbMain.Name = "SbMain"
    Me.SbMain.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.SbpPgmID, Me.SbpScreen, Me.SbpEnvironment, Me.SbpFiller1})
    Me.SbMain.ShowPanels = True
    Me.SbMain.Size = New System.Drawing.Size(624, 28)
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
    'TBarSetPostal
    '
    Me.TBarSetPostal.ImageIndex = 7
    Me.TBarSetPostal.Name = "TBarSetPostal"
    Me.TBarSetPostal.Text = "Set Postal Barcode"
    '
    'FrmMain
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.BackColor = System.Drawing.SystemColors.Control
    Me.ClientSize = New System.Drawing.Size(624, 384)
    Me.Controls.Add(Me.SbMain)
    Me.Controls.Add(Me.TbMain)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.IsMdiContainer = True
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmMain"
    Me.HelpProvider1.SetShowHelp(Me, True)
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Process Postal File"
    CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmFix_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Dim WrkProgName As String
  WrkProgName = GetProgramName(False)

  TBarImport.Enabled = True
  MyFrmMainB = New FrmMainB
  MyFrmMainB.MdiParent = Me
  MyFrmMainB.Show()
End Sub
Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
  If e.Button Is TBarBack Then
    DoBtnBack()
  End If

  If e.Button Is TBarImport Then
    DoBtnImport()
  End If

  If e.Button Is TBarExport Then
    DoBtnExport()
  End If

  If e.Button Is TBarSetPostal Then
    DoBtnSetPostal()
  End If
End Sub
Private Sub FrmFix_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub
  If e.KeyCode = Keys.B Then
    DoBtnBack()
  End If


End Sub
Private Sub DoBtnBack()
  Select Case SbpScreen.Text
  Case "MainB"
    MyFrmMain.Close()
  End Select

End Sub
Private Sub DoBtnImport()
  MyFrmMainB.RunImport()
End Sub
Private Sub DoBtnExport()
  MyFrmMainB.RunExport()
End Sub
Private Sub DoBtnSetPostal()
  MyFrmMainB.RunPostalBarCode()
End Sub

End Class
