Public Class FrmGL107
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
  Friend WithEvents TBarSep1 As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarBack As System.Windows.Forms.ToolBarButton
  Friend WithEvents SbMain As System.Windows.Forms.StatusBar
  Friend WithEvents SbpPgmID As System.Windows.Forms.StatusBarPanel
  Friend WithEvents SbpScreen As System.Windows.Forms.StatusBarPanel
  Friend WithEvents SbpEnvironment As System.Windows.Forms.StatusBarPanel
Friend WithEvents SbpFiller1 As System.Windows.Forms.StatusBarPanel
Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
Friend WithEvents TBarDelete As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarPS As System.Windows.Forms.ToolBarButton
Friend WithEvents TbarNew As System.Windows.Forms.ToolBarButton
Friend WithEvents SbpVersion As System.Windows.Forms.StatusBarPanel
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGL107))
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarBack = New System.Windows.Forms.ToolBarButton()
    Me.TBarDelete = New System.Windows.Forms.ToolBarButton()
    Me.TbarNew = New System.Windows.Forms.ToolBarButton()
    Me.TBarSave = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep1 = New System.Windows.Forms.ToolBarButton()
    Me.TBarPS = New System.Windows.Forms.ToolBarButton()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.SbMain = New System.Windows.Forms.StatusBar()
    Me.SbpPgmID = New System.Windows.Forms.StatusBarPanel()
    Me.SbpScreen = New System.Windows.Forms.StatusBarPanel()
    Me.SbpEnvironment = New System.Windows.Forms.StatusBarPanel()
    Me.SbpFiller1 = New System.Windows.Forms.StatusBarPanel()
    Me.SbpVersion = New System.Windows.Forms.StatusBarPanel()
    Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
    CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TbMain
    '
    Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarBack, Me.TBarDelete, Me.TbarNew, Me.TBarSave, Me.TBarSep1, Me.TBarPS})
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
    Me.TBarBack.Text = "Back"
    '
    'TBarDelete
    '
    Me.TBarDelete.ImageIndex = 3
    Me.TBarDelete.Name = "TBarDelete"
    Me.TBarDelete.Text = "Delete"
    '
    'TbarNew
    '
    Me.TbarNew.ImageIndex = 1
    Me.TbarNew.Name = "TbarNew"
    Me.TbarNew.Text = "New"
    '
    'TBarSave
    '
    Me.TBarSave.ImageIndex = 2
    Me.TBarSave.Name = "TBarSave"
    Me.TBarSave.Text = "Save"
    '
    'TBarSep1
    '
    Me.TBarSep1.Name = "TBarSep1"
    Me.TBarSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
    '
    'TBarPS
    '
    Me.TBarPS.ImageIndex = 5
    Me.TBarPS.Name = "TBarPS"
    Me.TBarPS.Text = "Print Screen"
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
    Me.ImageList1.Images.SetKeyName(5, "print_24.png")
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
    Me.SbpScreen.Width = 60
    '
    'SbpEnvironment
    '
    Me.SbpEnvironment.Name = "SbpEnvironment"
    Me.SbpEnvironment.Width = 75
    '
    'SbpFiller1
    '
    Me.SbpFiller1.Name = "SbpFiller1"
    Me.SbpFiller1.Width = 475
    '
    'SbpVersion
    '
    Me.SbpVersion.Alignment = System.Windows.Forms.HorizontalAlignment.Center
    Me.SbpVersion.Name = "SbpVersion"
    Me.SbpVersion.Text = "About Program"
    '
    'FrmGL107
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.BackColor = System.Drawing.SystemColors.Control
    Me.ClientSize = New System.Drawing.Size(768, 622)
    Me.Controls.Add(Me.SbMain)
    Me.Controls.Add(Me.TbMain)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.IsMdiContainer = True
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.Name = "FrmGL107"
    Me.HelpProvider1.SetShowHelp(Me, True)
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Maintain/Inquiry G/L Accounts"
    CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

  Private Sub FrmGL107_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkProgName As String
    WrkProgName = MyUtils.GetProgramName(False)

    SbpPgmID.Text = WrkProgName
    SbpEnvironment.Text = myDBConnect.PgmDB
    HelpProvider1.HelpNamespace = MyUtils.GetHelpFile(WrkProgName)

    set_security()
    TBarSave.Enabled = False
    TBarDelete.Enabled = False
    MyFrmGL107B = New FrmGL107B
    MyFrmGL107B.MdiParent = Me
    MyFrmGL107B.Show()
  End Sub

  Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
     If e.Button Is TBarBack Then
      DoBtnBack()
    End If

    If e.Button Is TBarDelete Then
      DoBtnDelete()
    End If

    If e.Button Is TbarNew Then
      DoBtnNew()
    End If

    If e.Button Is TBarSave Then
      DoBtnSave()
    End If

  If e.Button Is TBarPS Then
   DoBtnPS()
   Exit Sub
  End If

 End Sub

  Private Sub SbMain_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles SbMain.PanelClick
    If e.StatusBarPanel Is SbpVersion Then
      ShowSplash()
    End If

  End Sub

Private Sub FrmGL107_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If e.KeyCode = Keys.F12 Then
    MyUtils.PrtScreen(Form.ActiveForm)
  End If

  If Not e.Alt Then Exit Sub

  If e.KeyCode = Keys.B Then
    DoBtnBack()
  End If

  If e.KeyCode = Keys.D Then
    DoBtnDelete()
  End If

  If e.KeyCode = Keys.N Then
    DoBtnNew()
  End If

  If e.KeyCode = Keys.S Then
    DoBtnSave()
  End If

End Sub
Private Sub DoBtnBack()

    Select Case Me.SbpScreen.Text
    Case "GL107B"
      MyFrmGL107.Close()
    Case "GL107C"
      MyFrmGL107C.Close()
    Case "GL107DAP"
      MyFrmGL107DAP.Close()
    Case "GL107DAR"
      MyFrmGL107DAR.Close()
    Case "GL107DJE"
      MyFrmGL107DJE.Close()
    Case "GL107DPO"
      MyFrmGL107DPO.Close()
    Case "GL107DPR"
      MyFrmGL107DPR.Close()
    Case "GL107DTX"
      MyFrmGL107DTX.Close()
    End Select

End Sub
  Private Sub DoBtnDelete()
    Dim Cancel As Boolean

    MyFrmGL107C.DeleteData(Cancel)
    If Cancel Then Exit Sub

  End Sub
Private Sub DoBtnNew()
  MyFrmGL107C = New FrmGL107C
  MyFrmGL107C.MdiParent = MyFrmGL107B.ParentForm
  MyFrmGL107C.WrkFdnbr = 0
  MyFrmGL107C.WrkSfund = 0
  MyFrmGL107C.WrkDpnbr = 0
  MyFrmGL107C.WrkObnbr = 0
  MyFrmGL107C.WrkFnpgm = 0
  MyFrmGL107C.WrkSubfn = 0
  MyFrmGL107C.Show()
  MyFrmGL107B.Hide()
End Sub
Private Sub DoBtnSave()
  Select Case Me.SbpScreen.Text
  Case "GL107C"
    MyFrmGL107C.SaveData()
  End Select
End Sub
Private Sub DoBtnPS()

 MyUtils.PrtScreen(Form.ActiveForm, True)

End Sub
Private Sub set_security()
  ' note: these will change depending on the application program.
  ' change is difficult as the save button will need to be disabled for it but enabled for add
  If s_full = True Then
    Exit Sub
  End If
  If s_add = False Then
    TBarNew.Visible = False
  End If
  If s_del = False Then
    TBarDelete.Visible = False
  End If
  If s_edit = False Then
    TBarSave.Visible = False
  End If
End Sub
End Class
