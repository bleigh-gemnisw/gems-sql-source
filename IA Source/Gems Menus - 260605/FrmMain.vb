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
  Friend WithEvents SbMain As System.Windows.Forms.StatusBar
  Friend WithEvents SbpPgmID As System.Windows.Forms.StatusBarPanel
  Friend WithEvents SbpScreen As System.Windows.Forms.StatusBarPanel
  Friend WithEvents SbpFiller1 As System.Windows.Forms.StatusBarPanel
  Friend WithEvents SbpVersion As System.Windows.Forms.StatusBarPanel
  Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
  Friend WithEvents MnuFile As System.Windows.Forms.MenuItem
  Friend WithEvents MnuSecurity As System.Windows.Forms.MenuItem
  Friend WithEvents MnuFastPath As System.Windows.Forms.MenuItem
  Friend WithEvents MnuUsers As System.Windows.Forms.MenuItem
  Friend WithEvents MnuGroups As System.Windows.Forms.MenuItem
  Friend WithEvents MnuProgList As System.Windows.Forms.MenuItem
  Friend WithEvents MnuExit As System.Windows.Forms.MenuItem
  Friend WithEvents MnuMain As System.Windows.Forms.MenuItem
  Friend WithEvents SbpDatabase As System.Windows.Forms.StatusBarPanel
  Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
  Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
  Friend WithEvents MnuSetup As System.Windows.Forms.MenuItem
  Friend WithEvents MnuControl As System.Windows.Forms.MenuItem
  Friend WithEvents MnuTown As System.Windows.Forms.MenuItem
  Friend WithEvents MnuPrtScrn As System.Windows.Forms.MenuItem
  Friend WithEvents MnuPassword As System.Windows.Forms.MenuItem
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
    Me.SbMain = New System.Windows.Forms.StatusBar()
    Me.SbpPgmID = New System.Windows.Forms.StatusBarPanel()
    Me.SbpScreen = New System.Windows.Forms.StatusBarPanel()
    Me.SbpDatabase = New System.Windows.Forms.StatusBarPanel()
    Me.SbpFiller1 = New System.Windows.Forms.StatusBarPanel()
    Me.SbpVersion = New System.Windows.Forms.StatusBarPanel()
    Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
    Me.MnuFile = New System.Windows.Forms.MenuItem()
    Me.MnuExit = New System.Windows.Forms.MenuItem()
    Me.MnuMain = New System.Windows.Forms.MenuItem()
    Me.MnuSetup = New System.Windows.Forms.MenuItem()
    Me.MnuTown = New System.Windows.Forms.MenuItem()
    Me.MnuPrtScrn = New System.Windows.Forms.MenuItem()
    Me.MnuSecurity = New System.Windows.Forms.MenuItem()
    Me.MnuUsers = New System.Windows.Forms.MenuItem()
    Me.MnuGroups = New System.Windows.Forms.MenuItem()
    Me.MnuProgList = New System.Windows.Forms.MenuItem()
    Me.MnuControl = New System.Windows.Forms.MenuItem()
    Me.MnuPassword = New System.Windows.Forms.MenuItem()
    Me.MnuFastPath = New System.Windows.Forms.MenuItem()
    Me.MenuItem1 = New System.Windows.Forms.MenuItem()
    Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
    CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpDatabase, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'SbMain
    '
    Me.SbMain.Location = New System.Drawing.Point(0, 566)
    Me.SbMain.Name = "SbMain"
    Me.SbMain.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.SbpPgmID, Me.SbpScreen, Me.SbpDatabase, Me.SbpFiller1, Me.SbpVersion})
    Me.SbMain.ShowPanels = True
    Me.SbMain.Size = New System.Drawing.Size(762, 28)
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
    'SbpDatabase
    '
    Me.SbpDatabase.Name = "SbpDatabase"
    Me.SbpDatabase.Width = 70
    '
    'SbpFiller1
    '
    Me.SbpFiller1.Name = "SbpFiller1"
    Me.SbpFiller1.Width = 480
    '
    'SbpVersion
    '
    Me.SbpVersion.Alignment = System.Windows.Forms.HorizontalAlignment.Center
    Me.SbpVersion.Name = "SbpVersion"
    Me.SbpVersion.Text = "About Program"
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MnuFile, Me.MnuMain, Me.MnuSetup, Me.MnuSecurity, Me.MnuFastPath, Me.MenuItem1})
    '
    'MnuFile
    '
    Me.MnuFile.Index = 0
    Me.MnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MnuExit})
    Me.MnuFile.Text = "File"
    '
    'MnuExit
    '
    Me.MnuExit.Index = 0
    Me.MnuExit.Text = "Exit"
    '
    'MnuMain
    '
    Me.MnuMain.Index = 1
    Me.MnuMain.Text = "Main Menu"
    '
    'MnuSetup
    '
    Me.MnuSetup.Index = 2
    Me.MnuSetup.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MnuTown, Me.MnuPrtScrn})
    Me.MnuSetup.Text = "Setup"
    '
    'MnuTown
    '
    Me.MnuTown.Index = 0
    Me.MnuTown.Text = "Town File"
    '
    'MnuPrtScrn
    '
    Me.MnuPrtScrn.Index = 1
    Me.MnuPrtScrn.Text = "Print Screen Default"
    '
    'MnuSecurity
    '
    Me.MnuSecurity.Index = 3
    Me.MnuSecurity.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MnuUsers, Me.MnuGroups, Me.MnuProgList, Me.MnuControl, Me.MnuPassword})
    Me.MnuSecurity.Text = "Security"
    '
    'MnuUsers
    '
    Me.MnuUsers.Index = 0
    Me.MnuUsers.Text = "Users"
    '
    'MnuGroups
    '
    Me.MnuGroups.Index = 1
    Me.MnuGroups.Text = "Groups"
    '
    'MnuProgList
    '
    Me.MnuProgList.Index = 2
    Me.MnuProgList.Text = "Program List"
    '
    'MnuControl
    '
    Me.MnuControl.Index = 3
    Me.MnuControl.Text = "Control File"
    '
    'MnuPassword
    '
    Me.MnuPassword.Index = 4
    Me.MnuPassword.Text = "Change Password"
    '
    'MnuFastPath
    '
    Me.MnuFastPath.Index = 4
    Me.MnuFastPath.Text = "Fast Path"
    '
    'MenuItem1
    '
    Me.MenuItem1.Index = 5
    Me.MenuItem1.Text = ""
    '
    'FrmMain
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.BackColor = System.Drawing.SystemColors.Control
    Me.ClientSize = New System.Drawing.Size(762, 594)
    Me.Controls.Add(Me.SbMain)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.HelpButton = True
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.IsMdiContainer = True
    Me.KeyPreview = True
    Me.Menu = Me.MainMenu1
    Me.Name = "FrmMain"
    Me.HelpProvider1.SetShowHelp(Me, True)
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "GEMS"
    CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpDatabase, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    SbpPgmID.Text = "Main"
    SbpDatabase.Text = MyDBName
    set_security() '#set

    HelpProvider1.HelpNamespace = DataPath & "GemsHelp\main.chm"

    MyFrmMenu = New FrmMenu
    MyFrmMenu.MdiParent = Me
    MyFrmMenu.Show()
  End Sub
  Private Sub set_security()
    ' note: these will change depending on the application program.
    ' change is difficult as the save button will need to be disabled for it but enabled for add
  End Sub
  Private Sub FrmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub
    If e.KeyCode = Keys.F12 Then
      MyUtils.PrtScreen(Form.ActiveForm)
    End If
    If e.KeyCode = Keys.B Then
      DoBtnBack()
    End If
  End Sub
  Private Sub DoBtnBack()
    End
  End Sub
  Private Sub SbMain_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles SbMain.PanelClick
    If e.StatusBarPanel Is SbpVersion Then
      ShowSplash()
    End If
  End Sub
  Private Sub MnuFastPath_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuFastPath.Click
    If MyFrmFastPath Is Nothing Then
      MyFrmFastPath = New FrmFastPath
      MyFrmFastPath.MdiParent = Me
    End If
    MyFrmFastPath.Show()
    MyFrmFastPath.BringToFront()
  End Sub
  Private Sub MnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExit.Click
    End
  End Sub
  Private Sub MnuMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuMain.Click
    If Not IsNothing(MyFrmMenuAP) Then
      MyFrmMenuAP.WindowState = FormWindowState.Minimized
    End If
    If Not IsNothing(MyFrmMenuAR) Then
      MyFrmMenuAR.WindowState = FormWindowState.Minimized
    End If
    If Not IsNothing(MyFrmMenuBD) Then
      MyFrmMenuBD.WindowState = FormWindowState.Minimized
    End If
    If Not IsNothing(MyFrmMenuFA) Then
      MyFrmMenuFA.WindowState = FormWindowState.Minimized
    End If
    If Not IsNothing(MyFrmMenuFI) Then
      MyFrmMenuFI.WindowState = FormWindowState.Minimized
    End If
    If Not IsNothing(MyFrmMenuGL) Then
      MyFrmMenuGL.WindowState = FormWindowState.Minimized
    End If
    If Not IsNothing(MyFrmMenuMR) Then
      MyFrmMenuMR.WindowState = FormWindowState.Minimized
    End If
    If Not IsNothing(MyFrmMenuPK) Then
      MyFrmMenuPK.WindowState = FormWindowState.Minimized
    End If
    If Not IsNothing(MyFrmMenuPO) Then
      MyFrmMenuPO.WindowState = FormWindowState.Minimized
    End If
    If Not IsNothing(MyFrmMenuPR) Then
      MyFrmMenuPR.WindowState = FormWindowState.Minimized
    End If
    If Not IsNothing(MyFrmMenuPS) Then
      MyFrmMenuPS.WindowState = FormWindowState.Minimized
    End If
    If Not IsNothing(MyFrmMenuTA) Then
      MyFrmMenuTA.WindowState = FormWindowState.Minimized
    End If
    If Not IsNothing(MyFrmMenuTX) Then
      MyFrmMenuTX.WindowState = FormWindowState.Minimized
    End If
    If Not IsNothing(MyFrmMenuUB) Then
      MyFrmMenuUB.WindowState = FormWindowState.Minimized
    End If
    MyFrmMenu.Show()
  End Sub
  Private Sub MnuUsers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuUsers.Click
    LaunchEXE("IA001")
  End Sub
  Private Sub MnuGroups_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuGroups.Click
    LaunchEXE("IA002")
  End Sub
  Private Sub MnuProgList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuProgList.Click
    LaunchEXE("IA003")
  End Sub
  Private Sub MnuPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPassword.Click
    LaunchEXE("IA001", "password")
  End Sub
  Private Sub MnuControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuControl.Click
    LaunchEXE("IA101")
  End Sub
  Private Sub MnuTown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuTown.Click
    LaunchEXE("IA100")
  End Sub
  Private Sub MnuPrtScrn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPrtScrn.Click
    ShowSplash()
  End Sub
End Class
