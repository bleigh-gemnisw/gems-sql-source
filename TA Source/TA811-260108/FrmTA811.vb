Public Class FrmTA811
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
  Friend WithEvents TBarNew As System.Windows.Forms.ToolBarButton
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents TbMain As System.Windows.Forms.ToolBar
  Friend WithEvents TBarSave As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarDelete As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarSep1 As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarPrint As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarBack As System.Windows.Forms.ToolBarButton
  Friend WithEvents SbMain As System.Windows.Forms.StatusBar
  Friend WithEvents SbpPgmID As System.Windows.Forms.StatusBarPanel
  Friend WithEvents SbpScreen As System.Windows.Forms.StatusBarPanel
  Friend WithEvents SbpEnvironment As System.Windows.Forms.StatusBarPanel
Friend WithEvents SbpFiller1 As System.Windows.Forms.StatusBarPanel
Friend WithEvents SbpVersion As System.Windows.Forms.StatusBarPanel
Friend WithEvents TBarHist As System.Windows.Forms.ToolBarButton
Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
Friend WithEvents TBarSettings As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarPS As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarAttach As ToolBarButton
    Friend WithEvents TBarComments As ToolBarButton
    Friend WithEvents TBarSep2 As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTA811))
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarBack = New System.Windows.Forms.ToolBarButton()
    Me.TBarNew = New System.Windows.Forms.ToolBarButton()
    Me.TBarSave = New System.Windows.Forms.ToolBarButton()
    Me.TBarDelete = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep1 = New System.Windows.Forms.ToolBarButton()
        Me.TBarAttach = New System.Windows.Forms.ToolBarButton()
        Me.TBarHist = New System.Windows.Forms.ToolBarButton()
        Me.TBarSep2 = New System.Windows.Forms.ToolBarButton()
        Me.TBarPrint = New System.Windows.Forms.ToolBarButton()
        Me.TBarSettings = New System.Windows.Forms.ToolBarButton()
        Me.TBarPS = New System.Windows.Forms.ToolBarButton()
        Me.TBarComments = New System.Windows.Forms.ToolBarButton()
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
        Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarBack, Me.TBarNew, Me.TBarSave, Me.TBarDelete, Me.TBarSep1, Me.TBarAttach, Me.TBarHist, Me.TBarSep2, Me.TBarPrint, Me.TBarSettings, Me.TBarPS, Me.TBarComments})
        Me.TbMain.DropDownArrows = True
        Me.TbMain.ImageList = Me.ImageList1
        Me.TbMain.Location = New System.Drawing.Point(0, 0)
        Me.TbMain.Name = "TbMain"
        Me.TbMain.ShowToolTips = True
        Me.TbMain.Size = New System.Drawing.Size(947, 50)
        Me.TbMain.TabIndex = 1
        '
        'TBarBack
        '
        Me.TBarBack.ImageIndex = 0
        Me.TBarBack.Name = "TBarBack"
        Me.TBarBack.Text = "&Back"
        '
        'TBarNew
        '
        Me.TBarNew.ImageIndex = 1
        Me.TBarNew.Name = "TBarNew"
        Me.TBarNew.Text = "&New"
        '
        'TBarSave
        '
        Me.TBarSave.ImageIndex = 2
        Me.TBarSave.Name = "TBarSave"
        Me.TBarSave.Text = "&Save"
        '
        'TBarDelete
        '
        Me.TBarDelete.ImageIndex = 3
        Me.TBarDelete.Name = "TBarDelete"
        Me.TBarDelete.Text = "&Delete"
        '
        'TBarSep1
        '
        Me.TBarSep1.Name = "TBarSep1"
        Me.TBarSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'TBarAttach
        '
        Me.TBarAttach.ImageIndex = 5
        Me.TBarAttach.Name = "TBarAttach"
        Me.TBarAttach.Text = "Attachments"
        '
        'TBarHist
        '
        Me.TBarHist.Name = "TBarHist"
        Me.TBarHist.Text = "History"
        '
        'TBarSep2
        '
        Me.TBarSep2.Name = "TBarSep2"
        Me.TBarSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'TBarPrint
        '
        Me.TBarPrint.ImageIndex = 4
        Me.TBarPrint.Name = "TBarPrint"
        Me.TBarPrint.Text = "&Print"
        '
        'TBarSettings
        '
        Me.TBarSettings.Name = "TBarSettings"
        Me.TBarSettings.Text = "Settings"
        '
        'TBarPS
        '
        Me.TBarPS.ImageIndex = 4
        Me.TBarPS.Name = "TBarPS"
        Me.TBarPS.Text = "Print Screen"
        Me.TBarPS.ToolTipText = "Print active window"
        '
        'TBarComments
        '
        Me.TBarComments.ImageIndex = 6
        Me.TBarComments.Name = "TBarComments"
        Me.TBarComments.Text = "Comments"
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
        Me.ImageList1.Images.SetKeyName(5, "Paperclip.png")
        Me.ImageList1.Images.SetKeyName(6, "comment_24.png")
        '
        'SbMain
        '
        Me.SbMain.Location = New System.Drawing.Point(0, 649)
        Me.SbMain.Name = "SbMain"
        Me.SbMain.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.SbpPgmID, Me.SbpScreen, Me.SbpEnvironment, Me.SbpFiller1, Me.SbpVersion})
        Me.SbMain.ShowPanels = True
        Me.SbMain.Size = New System.Drawing.Size(947, 28)
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
        'FrmTA811
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(947, 677)
        Me.Controls.Add(Me.SbMain)
        Me.Controls.Add(Me.TbMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmTA811"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "After Bill C/C Maintainence"
        CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmTA811_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkProgName As String
    WrkProgName = MyUtils.GetProgramName(False)

    SbpPgmID.Text = WrkProgName
    SbpEnvironment.Text = myDBConnect.PgmDB
    HelpProvider1.HelpNamespace = MyUtils.GetHelpFile(WrkProgName)
    TBarSave.Enabled = False
    TBarDelete.Enabled = False
    TBarHist.Enabled = False
    TBarPrint.Enabled = True
    TBarAttach.Enabled = False
    TBarComments.Enabled = False
    If MyOpenCC Then
      Me.Text = Me.Text & " (OPEN C/C)"
    End If
    MyFrmTA8111R = New FrmTA8111R
    MyFrmTA8111R.MdiParent = Me
    MyFrmTA8111R.Show()
  End Sub

  Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick

    If e.Button Is TBarBack Then
      DoBtnBack()
    End If

    If e.Button Is TBarDelete Then
      DoBtnDelete()
    End If

    If e.Button Is TBarHist Then
      DoBtnhist()
    End If

    If e.Button Is TBarNew Then
      DoBtnNew()
    End If

    If e.Button Is TBarPrint Then
      DoBtnPrint()
    End If

    If e.Button Is TBarSettings Then
      MyFrmSettings = New FrmSettings
      MyFrmSettings.ShowDialog()
    End If

    If e.Button Is TBarSave Then
      DoBtnSave()
    End If

    If e.Button Is TBarAttach Then
      DoBtnAttach()
      Exit Sub
    End If

    If e.Button Is TBarPS Then
      DoBtnPS()
      Exit Sub
    End If
    If e.Button Is TBarComments Then
      DoBtnComments()
      Exit Sub
    End If

  End Sub

  Private Sub SbMain_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles SbMain.PanelClick
    If e.StatusBarPanel Is SbpVersion Then
      ShowSplash()
    End If

  End Sub

Private Sub FrmTA811_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

If e.KeyCode = Keys.P Then
  DoBtnPrint()
End If
End Sub
Private Sub DoBtnBack()
    Select Case Me.SbpScreen.Text
      Case "Comments"
        MyFrmComments.Close()
      Case "ListInv"
        MyFrmListInv.Close()
      Case "TA8111R"
        MyFrmTA811.Close()
      Case "TA811_NEW"
        MyFrmTA811_NEW.Close()
      Case "TA8112R"
        MyFrmTA8112R.Close()
        MyFrmTA8111R.FormatGrid(True)
        MyFrmTA811.Show()
      Case "TA8113R"
        MyFrmTA8113R.Close()
        MyFrmTA8111R.FormatGrid(True)
        MyFrmTA811.Show()
      Case "TA8114R"
        MyFrmTA8114R.Close()
        MyFrmTA8111R.FormatGrid(True)
        MyFrmTA811.Show()
      Case "TA8115R"
        MyFrmTA8115R.Close()
        MyFrmTA8111R.FormatGrid(True)
        MyFrmTA811.Show()
    End Select
  End Sub
Private Sub DoBtnDelete()
  Dim Cancel As Boolean

  Select Case Me.SbpScreen.Text
  Case "TA8112R"
    MyFrmTA8112R.DeleteData(Cancel)
    If Cancel Then Exit Sub
    MyFrmTA8112R.Close()
  Case "TA8113R"
    MyFrmTA8113R.DeleteData(Cancel)
    If Cancel Then Exit Sub
    MyFrmTA8113R.Close()
  Case "TA8114R"
    MyFrmTA8114R.DeleteData(Cancel)
    If Cancel Then Exit Sub
    MyFrmTA8114R.Close()
  Case "TA8115R"
    MyFrmTA8115R.DeleteData(Cancel)
    If Cancel Then Exit Sub
    MyFrmTA8115R.Close()
  End Select
	MyFrmTA8111R.ShowGridbyName()
  MyFrmTA8111R.Show()
End Sub
Private Sub DoBtnHist()
  Select Case Me.SbpScreen.Text
  Case "TA8112R"
    MyFrmTA8112R.ShowCCHist()
  Case "TA8113R"
    MyFrmTA8113R.ShowCCHist()
  Case "TA8114R"
    MyFrmTA8114R.ShowCCHist()
  Case "TA8115R"
    MyFrmTA8115R.ShowCCHist()
  End Select
End Sub
Private Sub DoBtnNew()
  MyFrmTA811_NEW = New FrmTA811_NEW
  MyFrmTA811_NEW.MdiParent = MyFrmTA8111R.ParentForm
  MyFrmTA811_NEW.Show()
  MyFrmTA8111R.Hide()
End Sub
Private Sub DoBtnSave()
    Select Case Me.SbpScreen.Text
      Case "Comments"
        MyFrmComments.SaveData()
      Case "TA8112R"
        MyFrmTA8112R.SaveData()
      Case "TA8113R"
        MyFrmTA8113R.SaveData()
      Case "TA8114R"
        MyFrmTA8114R.SaveData()
      Case "TA8115R"
        MyFrmTA8115R.SaveData()
    End Select
  End Sub
  Private Sub DoBtnAttach()
    Dim WrkKey As Integer
    Dim WrkAttachcount As Integer
    Select Case SbpScreen.Text
      Case "TA8112R"
        WrkKey = MyFrmTA8112R.WrkCCNo
      Case "TA8113R"
        WrkKey = MyFrmTA8113R.WrkCCNo
      Case "TA8114R"
        WrkKey = MyFrmTA8114R.WrkCCNo
      Case "TA8115R"
        WrkKey = MyFrmTA8115R.WrkCCNo
    End Select
    ShowAttachit("CCAFTER", WrkKey)
    WrkAttachcount = GetAttachcount("CCAFTER", WrkKey)
    MyFrmTA811.TBarAttach.Text = WrkAttachcount & " Attachment(s)"
  End Sub
  Private Sub DoBtnPrint()
    Select Case Me.SbpScreen.Text
      Case "TA8112R"
        MyFrmTA8112R.PrintData()
      Case "TA8113R"
        MyFrmTA8113R.PrintData()
      Case "TA8114R"
        MyFrmTA8114R.PrintData()
      Case "TA8115R"
        MyFrmTA8115R.PrintData()
    End Select
  End Sub
  Private Sub DoBtnPS()
    MyUtils.PrtScreen(Form.ActiveForm, True)
  End Sub
  Private Sub DoBtnComments()
    Dim WrkcmtListNo As Integer
    Dim WrkcmtType As String
    Dim WrkcmtYear As Integer

    WrkcmtType = ""
    Select Case MyFrmTA811.SbpScreen.Text
      Case "TA8112R"
        WrkcmtListNo = MyUtils.CnvSng(MyFrmTA8112R.LblListNo.Text)
        WrkcmtYear = MyUtils.CnvSng(MyFrmTA8112R.LblYear.Text)
        WrkcmtType = MyFrmTA8112R.LblType.Text
        MyFrmTA8112R.Hide()
      Case "TA8113R"
        WrkcmtListNo = MyUtils.CnvSng(MyFrmTA8113R.LblListNo.Text)
        WrkcmtYear = MyUtils.CnvSng(MyFrmTA8113R.LblYear.Text)
        WrkcmtType = MyFrmTA8113R.LblType.Text
        MyFrmTA8113R.Hide()
      Case "TA8114R"
        WrkcmtListNo = MyUtils.CnvSng(MyFrmTA8114R.LblListNo.Text)
        WrkcmtYear = MyUtils.CnvSng(MyFrmTA8114R.LblYear.Text)
        WrkcmtType = MyFrmTA8114R.LblType.Text
        MyFrmTA8114R.Hide()
      Case "TA8115R"
        WrkcmtListNo = MyUtils.CnvSng(MyFrmTA8115R.LblListNo.Text)
        WrkcmtYear = MyUtils.CnvSng(MyFrmTA8115R.LblYear.Text)
        WrkcmtType = MyFrmTA8115R.LblType.Text
        MyFrmTA8115R.Hide()

    End Select

    MyFrmComments = New FrmComments
    MyFrmComments.MdiParent = MyFrmTA8111R.ParentForm
    MyFrmComments.WrkListNo = WrkcmtListNo
    MyFrmComments.WrkType = WrkcmtType
    MyFrmComments.WrkYear = WrkcmtYear
    MyFrmComments.WrkPrevScreen = MyFrmTA811.SbpScreen.Text
    MyFrmComments.Show()
  End Sub
End Class






