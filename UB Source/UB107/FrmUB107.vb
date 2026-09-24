Public Class FrmUB107
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
  Friend WithEvents TBarSave As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarBack As System.Windows.Forms.ToolBarButton
  Friend WithEvents SbMain As System.Windows.Forms.StatusBar
  Friend WithEvents SbpPgmID As System.Windows.Forms.StatusBarPanel
  Friend WithEvents SbpScreen As System.Windows.Forms.StatusBarPanel
  Friend WithEvents SbpEnvironment As System.Windows.Forms.StatusBarPanel
Friend WithEvents SbpFiller1 As System.Windows.Forms.StatusBarPanel
Friend WithEvents SbpVersion As System.Windows.Forms.StatusBarPanel
    Friend WithEvents TBarPS As ToolBarButton
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUB107))
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarBack = New System.Windows.Forms.ToolBarButton()
    Me.TBarSave = New System.Windows.Forms.ToolBarButton()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.SbMain = New System.Windows.Forms.StatusBar()
    Me.SbpPgmID = New System.Windows.Forms.StatusBarPanel()
    Me.SbpScreen = New System.Windows.Forms.StatusBarPanel()
    Me.SbpEnvironment = New System.Windows.Forms.StatusBarPanel()
    Me.SbpFiller1 = New System.Windows.Forms.StatusBarPanel()
    Me.SbpVersion = New System.Windows.Forms.StatusBarPanel()
    Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.TBarPS = New System.Windows.Forms.ToolBarButton()
        CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TbMain
        '
        Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarBack, Me.TBarSave, Me.TBarPS})
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
        'TBarSave
        '
        Me.TBarSave.ImageIndex = 2
        Me.TBarSave.Name = "TBarSave"
        Me.TBarSave.Text = "&Save"
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
        Me.ImageList1.Images.SetKeyName(6, "")
        '
        'SbMain
        '
        Me.SbMain.Location = New System.Drawing.Point(0, 594)
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
        Me.SbpScreen.Width = 80
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
        Me.SbpVersion.Text = "About program"
        '
        'TBarPS
        '
        Me.TBarPS.ImageIndex = 4
        Me.TBarPS.Name = "TBarPS"
        Me.TBarPS.Text = "Print Screen"
        '
        'FrmUB107
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(768, 622)
        Me.Controls.Add(Me.SbMain)
        Me.Controls.Add(Me.TbMain)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmUB107"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Meter Readings Maintainence"
        CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmUB107_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkProgName As String
    WrkProgName = MyUtils.GetProgramName(False)

    SbpPgmID.Text = WrkProgName
    SbpEnvironment.Text = myDBConnect.PgmDB
    HelpProvider1.HelpNamespace = MyUtils.GetHelpFile(WrkProgName)

    TBarSave.Enabled = False
    set_security()   '#sec
    MyFrmUB107B = New FrmUB107B
    MyFrmUB107B.MdiParent = Me
    MyFrmUB107B.Show()
  End Sub

  Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick

    If e.Button Is TBarBack Then
      DoBtnBack()
      Exit Sub
    End If

    If e.Button Is TBarSave Then
      DoBtnSave()
      Exit Sub
    End If
    If e.Button Is TBarPS Then
      DoBtnPS()
      Exit Sub
    End If
  End Sub
  Private Sub set_security()
    ' note: these will change depending on the application program.
    ' change is difficult as the save button will need to be disabled for it but enabled for add

    If s_full = True Then
      Exit Sub
    End If
  End Sub

  Private Sub SbMain_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles SbMain.PanelClick
    If e.StatusBarPanel Is SbpVersion Then
      ShowSplash()
    End If

  End Sub

  Private Sub FrmUB107_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub

    If e.KeyCode = Keys.F12 Then
      MyUtils.PrtScreen(Form.ActiveForm)
    End If

    If e.KeyCode = Keys.B Then
      DoBtnBack()
    End If

    If e.KeyCode = Keys.S Then
      DoBtnSave()
    End If
  End Sub

  Private Sub DoBtnBack()
    Select Case Me.SbpScreen.Text
      Case "UB107B"
        MyFrmUB107.Close()
      Case "UB107C"
        MyFrmUB107C.Close()
        MyFrmUB107B.FormatGrid()
        MyFrmUB107B.Show()
      Case "ListMResn"
        MyFrmListMResn.Close()
    End Select
  End Sub
  Private Sub DoBtnSave()
    Select Case Me.SbpScreen.Text
      Case "UB107C"
        MyFrmUB107C.SaveData()
    End Select
  End Sub
  Private Sub DoBtnPS()

    MyUtils.PrtScreen(Form.ActiveForm, True)

  End Sub
End Class






