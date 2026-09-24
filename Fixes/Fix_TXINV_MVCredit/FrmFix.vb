Public Class FrmFix
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
  Friend WithEvents TBarSep1 As System.Windows.Forms.ToolBarButton
  Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
  Friend WithEvents TBarTransfer As ToolBarButton
  Friend WithEvents SbpFiller1 As StatusBarPanel
  Friend WithEvents SbpEnvironment As StatusBarPanel
  Friend WithEvents SbpScreen As StatusBarPanel
  Friend WithEvents SbpPgmID As StatusBarPanel
  Friend WithEvents SbMain As StatusBar
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFix))
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarBack = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep1 = New System.Windows.Forms.ToolBarButton()
    Me.TBarTransfer = New System.Windows.Forms.ToolBarButton()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
    Me.SbpFiller1 = New System.Windows.Forms.StatusBarPanel()
    Me.SbpEnvironment = New System.Windows.Forms.StatusBarPanel()
    Me.SbpScreen = New System.Windows.Forms.StatusBarPanel()
    Me.SbpPgmID = New System.Windows.Forms.StatusBarPanel()
    Me.SbMain = New System.Windows.Forms.StatusBar()
    CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TbMain
    '
    Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarBack, Me.TBarSep1, Me.TBarTransfer})
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
    'TBarTransfer
    '
    Me.TBarTransfer.ImageIndex = 1
    Me.TBarTransfer.Name = "TBarTransfer"
    Me.TBarTransfer.Text = "Process "
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.White
    Me.ImageList1.Images.SetKeyName(0, "")
    Me.ImageList1.Images.SetKeyName(1, "")
    Me.ImageList1.Images.SetKeyName(2, "new_24.png")
    '
    'SbpFiller1
    '
    Me.SbpFiller1.Name = "SbpFiller1"
    Me.SbpFiller1.Width = 450
    '
    'SbpEnvironment
    '
    Me.SbpEnvironment.Name = "SbpEnvironment"
    '
    'SbpScreen
    '
    Me.SbpScreen.Name = "SbpScreen"
    Me.SbpScreen.Width = 60
    '
    'SbpPgmID
    '
    Me.SbpPgmID.Name = "SbpPgmID"
    Me.SbpPgmID.Width = 50
    '
    'SbMain
    '
    Me.SbMain.Location = New System.Drawing.Point(0, 586)
    Me.SbMain.Name = "SbMain"
    Me.SbMain.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.SbpPgmID, Me.SbpScreen, Me.SbpEnvironment, Me.SbpFiller1})
    Me.SbMain.ShowPanels = True
    Me.SbMain.Size = New System.Drawing.Size(768, 28)
    Me.SbMain.SizingGrip = False
    Me.SbMain.TabIndex = 5
    '
    'FrmFix
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.BackColor = System.Drawing.SystemColors.Control
    Me.ClientSize = New System.Drawing.Size(768, 614)
    Me.Controls.Add(Me.SbMain)
    Me.Controls.Add(Me.TbMain)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.IsMdiContainer = True
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.Name = "FrmFix"
    Me.HelpProvider1.SetShowHelp(Me, True)
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Fix Transfer Credit Balances"
    CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmFix_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkProgName As String
    WrkProgName = MyUtils.GetProgramName(False)

    SbpPgmID.Text = WrkProgName
    SbpEnvironment.Text = myDBConnect.PgmDB
    HelpProvider1.HelpNamespace = MyUtils.GetHelpFile(WrkProgName)

    MyFrmFixB = New FrmFixB
    MyFrmFixB.MdiParent = Me
    MyFrmFixB.Show()
  End Sub
  Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
    If e.Button Is TBarBack Then
      DoBtnBack()
    End If
    If e.Button Is TBarTransfer Then
      DoBtnMass()
    End If
  End Sub
  Private Sub FrmFix_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub
    If e.KeyCode = Keys.F12 Then
      MyUtils.PrtScreen(Form.ActiveForm)
    End If
    If e.KeyCode = Keys.B Then
      DoBtnBack()
    End If
    If e.KeyCode = Keys.M Then
      DoBtnMass()
    End If
  End Sub
  Private Sub DoBtnBack()
    Select Case SbpScreen.Text
      Case "Fix"
        MyFrmFix.Close()
      Case "ListTypes"
        MyFrmListTypes.Close()
        MyFrmFixB.Show()
    End Select
  End Sub
  Private Sub DoBtnMass()
    TBarTransfer.Enabled = False
    Application.DoEvents()
    MyFrmFixB.RunReport()
    TBarTransfer.Enabled = True
  End Sub
End Class






