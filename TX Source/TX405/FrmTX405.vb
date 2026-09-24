Public Class FrmTX405
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
Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
  Friend WithEvents TBarAttach As ToolBarButton
  Friend WithEvents TBarLog As System.Windows.Forms.ToolBarButton
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTX405))
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarBack = New System.Windows.Forms.ToolBarButton()
    Me.TBarNew = New System.Windows.Forms.ToolBarButton()
    Me.TBarSave = New System.Windows.Forms.ToolBarButton()
    Me.TBarDelete = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep1 = New System.Windows.Forms.ToolBarButton()
    Me.TBarPrint = New System.Windows.Forms.ToolBarButton()
    Me.TBarAttach = New System.Windows.Forms.ToolBarButton()
    Me.TBarLog = New System.Windows.Forms.ToolBarButton()
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
        Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarBack, Me.TBarNew, Me.TBarSave, Me.TBarDelete, Me.TBarSep1, Me.TBarPrint, Me.TBarAttach, Me.TBarLog})
        Me.TbMain.DropDownArrows = True
        Me.TbMain.ImageList = Me.ImageList1
        Me.TbMain.Location = New System.Drawing.Point(0, 0)
        Me.TbMain.Name = "TbMain"
        Me.TbMain.ShowToolTips = True
        Me.TbMain.Size = New System.Drawing.Size(983, 50)
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
        'TBarPrint
        '
        Me.TBarPrint.ImageIndex = 4
        Me.TBarPrint.Name = "TBarPrint"
        Me.TBarPrint.Text = "&Print"
        '
        'TBarAttach
        '
        Me.TBarAttach.ImageIndex = 6
        Me.TBarAttach.Name = "TBarAttach"
        Me.TBarAttach.Text = "Attachments"
        '
        'TBarLog
        '
        Me.TBarLog.ImageIndex = 5
        Me.TBarLog.Name = "TBarLog"
        Me.TBarLog.Text = "Change Log"
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
        Me.ImageList1.Images.SetKeyName(6, "Attach.png")
        '
        'SbMain
        '
        Me.SbMain.Location = New System.Drawing.Point(0, 594)
        Me.SbMain.Name = "SbMain"
        Me.SbMain.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.SbpPgmID, Me.SbpScreen, Me.SbpEnvironment, Me.SbpFiller1, Me.SbpVersion})
        Me.SbMain.ShowPanels = True
        Me.SbMain.Size = New System.Drawing.Size(983, 28)
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
        Me.SbpFiller1.Width = 500
        '
        'SbpVersion
        '
        Me.SbpVersion.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.SbpVersion.Name = "SbpVersion"
        Me.SbpVersion.Text = "About program"
        '
        'FrmTX405
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(983, 622)
        Me.Controls.Add(Me.SbMain)
        Me.Controls.Add(Me.TbMain)
        Me.ForeColor = System.Drawing.Color.Black
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmTX405"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tax Invoice Maintainence"
        CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmTX405_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkProgName As String
    WrkProgName = MyUtils.GetProgramName(False)

    SbpPgmID.Text = WrkProgName
    SbpEnvironment.Text = myDBConnect.PgmDB
    HelpProvider1.HelpNamespace = MyUtils.GetHelpFile(WrkProgName)

    TBarSave.Enabled = False
    TBarDelete.Enabled = False
    TBarPrint.Enabled = False
    TBarLog.Visible = False
    set_security()   '#sec
    MyFrmTX405B = New FrmTX405B
    MyFrmTX405B.MdiParent = Me
    MyFrmTX405B.Show()
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

      If e.Button Is TBarNew Then
        DoBtnNew()
        Exit Sub
      End If

      If e.Button Is TBarDelete Then
        DoBtnDelete()
        Exit Sub
      End If

    If e.Button Is TBarAttach Then
      DoBtnAttach()
      Exit Sub
    End If
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
      TBarPrint.Visible = False
    End If

  End Sub

  Private Sub SbMain_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles SbMain.PanelClick
    If e.StatusBarPanel Is SbpVersion Then
      ShowSplash()
    End If

  End Sub

  Private Sub FrmTX405_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

  Private Sub DoBtnAttach()
    Dim WrkAttachcount As Integer

    ShowAttachit(MyFrmTX405C.WrkAcct)
    WrkAttachcount = GetAttachcount(MyFrmTX405C.WrkAcct)
    MyFrmTX405.SbpScreen.Text = "TX405C"
    MyFrmTX405.TBarAttach.Text = WrkAttachcount & " Attachment(s)"
  End Sub
  Private Sub DoBtnBack()
    Select Case Me.SbpScreen.Text
      Case "TX405_NEW"
        MyFrmTX405_NEW.Close()
      Case "TX405B"
        MyFrmTX405.Close()
      Case "TX405C"
        Array.Clear(SelAcct, 0, cMax)
        MyFrmTX405C.Close()
        MyFrmTX405B.FormatGrid(True, True)
        MyFrmTX405.Show()
    End Select
  End Sub
  Private Sub DoBtnDelete()
    Dim Cancel As Boolean

    MyFrmTX405C.DeleteData(Cancel)
    If Cancel Then Exit Sub

    MyFrmTX405C.Close()
    MyFrmTX405B.FormatGrid(True,true)
    MyFrmTX405B.Show()
  End Sub

  Private Sub DoBtnNew()
    MyFrmTX405_NEW = New FrmTX405_NEW
    MyFrmTX405_NEW.MdiParent = MyFrmTX405B.ParentForm
    MyFrmTX405_NEW.Show()
    MyFrmTX405B.Hide()
  End Sub
  Private Sub DoBtnSave()
    MyFrmTX405C.SaveData()
  End Sub
End Class






