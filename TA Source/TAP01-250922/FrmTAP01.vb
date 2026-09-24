Public Class FrmTAP01
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
Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
Friend WithEvents TbForms As System.Windows.Forms.ToolBar
Friend WithEvents TBarDecl As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarDepr As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarMV As System.Windows.Forms.ToolBarButton
Friend WithEvents ToolBarButton4 As System.Windows.Forms.ToolBarButton
Friend WithEvents ToolBarButton5 As System.Windows.Forms.ToolBarButton
Friend WithEvents ToolBarButton6 As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarHor As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarMob As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarAff As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarSep As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarDsp As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarSum As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarSep2 As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarLor As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarLee As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarComments As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarAss As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarBus As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarTowns As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarSep3 As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarAttach As ToolBarButton
  Friend WithEvents SbpVersion As System.Windows.Forms.StatusBarPanel
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTAP01))
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarBack = New System.Windows.Forms.ToolBarButton()
    Me.TBarNew = New System.Windows.Forms.ToolBarButton()
    Me.TBarSave = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep1 = New System.Windows.Forms.ToolBarButton()
    Me.TBarDelete = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep3 = New System.Windows.Forms.ToolBarButton()
        Me.TBarAttach = New System.Windows.Forms.ToolBarButton()
        Me.TBarPrint = New System.Windows.Forms.ToolBarButton()
        Me.TBarComments = New System.Windows.Forms.ToolBarButton()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.SbMain = New System.Windows.Forms.StatusBar()
        Me.SbpPgmID = New System.Windows.Forms.StatusBarPanel()
        Me.SbpScreen = New System.Windows.Forms.StatusBarPanel()
        Me.SbpEnvironment = New System.Windows.Forms.StatusBarPanel()
        Me.SbpFiller1 = New System.Windows.Forms.StatusBarPanel()
        Me.SbpVersion = New System.Windows.Forms.StatusBarPanel()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.TbForms = New System.Windows.Forms.ToolBar()
        Me.TBarDecl = New System.Windows.Forms.ToolBarButton()
        Me.TBarAff = New System.Windows.Forms.ToolBarButton()
        Me.TBarSep = New System.Windows.Forms.ToolBarButton()
        Me.TBarDepr = New System.Windows.Forms.ToolBarButton()
        Me.TBarMV = New System.Windows.Forms.ToolBarButton()
        Me.TBarHor = New System.Windows.Forms.ToolBarButton()
        Me.TBarMob = New System.Windows.Forms.ToolBarButton()
        Me.TBarSep2 = New System.Windows.Forms.ToolBarButton()
        Me.TBarDsp = New System.Windows.Forms.ToolBarButton()
        Me.TBarAss = New System.Windows.Forms.ToolBarButton()
        Me.TBarBus = New System.Windows.Forms.ToolBarButton()
        Me.TBarTowns = New System.Windows.Forms.ToolBarButton()
        Me.TBarLor = New System.Windows.Forms.ToolBarButton()
        Me.TBarLee = New System.Windows.Forms.ToolBarButton()
        Me.TBarSum = New System.Windows.Forms.ToolBarButton()
        CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TbMain
        '
        Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarBack, Me.TBarNew, Me.TBarSave, Me.TBarSep1, Me.TBarDelete, Me.TBarSep3, Me.TBarAttach, Me.TBarPrint, Me.TBarComments})
        Me.TbMain.DropDownArrows = True
        Me.TbMain.ImageList = Me.ImageList1
        Me.TbMain.Location = New System.Drawing.Point(0, 0)
        Me.TbMain.Name = "TbMain"
        Me.TbMain.ShowToolTips = True
        Me.TbMain.Size = New System.Drawing.Size(981, 50)
        Me.TbMain.TabIndex = 1
        '
        'TBarBack
        '
        Me.TBarBack.ImageIndex = 0
        Me.TBarBack.Name = "TBarBack"
        Me.TBarBack.Text = "Back"
        '
        'TBarNew
        '
        Me.TBarNew.ImageIndex = 1
        Me.TBarNew.Name = "TBarNew"
        Me.TBarNew.Text = "New"
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
        'TBarDelete
        '
        Me.TBarDelete.ImageIndex = 3
        Me.TBarDelete.Name = "TBarDelete"
        Me.TBarDelete.Text = "Delete"
        '
        'TBarSep3
        '
        Me.TBarSep3.Name = "TBarSep3"
        Me.TBarSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'TBarAttach
        '
        Me.TBarAttach.Name = "TBarAttach"
        Me.TBarAttach.Text = "Attachments"
        '
        'TBarPrint
        '
        Me.TBarPrint.ImageIndex = 4
        Me.TBarPrint.Name = "TBarPrint"
        Me.TBarPrint.Text = "Print"
        '
        'TBarComments
        '
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
        Me.ImageList1.Images.SetKeyName(5, "comment_24.png")
        Me.ImageList1.Images.SetKeyName(6, "Paperclip.png")
        '
        'SbMain
        '
        Me.SbMain.Location = New System.Drawing.Point(0, 644)
        Me.SbMain.Name = "SbMain"
        Me.SbMain.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.SbpPgmID, Me.SbpScreen, Me.SbpEnvironment, Me.SbpFiller1, Me.SbpVersion})
        Me.SbMain.ShowPanels = True
        Me.SbMain.Size = New System.Drawing.Size(981, 28)
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
        Me.SbpScreen.Width = 70
        '
        'SbpEnvironment
        '
        Me.SbpEnvironment.Name = "SbpEnvironment"
        Me.SbpEnvironment.Width = 75
        '
        'SbpFiller1
        '
        Me.SbpFiller1.Name = "SbpFiller1"
        Me.SbpFiller1.Width = 690
        '
        'SbpVersion
        '
        Me.SbpVersion.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.SbpVersion.Name = "SbpVersion"
        Me.SbpVersion.Text = "About Program"
        '
        'TbForms
        '
        Me.TbForms.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarDecl, Me.TBarAff, Me.TBarSep, Me.TBarDepr, Me.TBarMV, Me.TBarHor, Me.TBarMob, Me.TBarSep2, Me.TBarDsp, Me.TBarAss, Me.TBarBus, Me.TBarTowns, Me.TBarLor, Me.TBarLee, Me.TBarSum})
        Me.TbForms.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TbForms.DropDownArrows = True
        Me.TbForms.ImageList = Me.ImageList1
        Me.TbForms.Location = New System.Drawing.Point(0, 594)
        Me.TbForms.Name = "TbForms"
        Me.TbForms.ShowToolTips = True
        Me.TbForms.Size = New System.Drawing.Size(981, 50)
        Me.TbForms.TabIndex = 7
        Me.TbForms.Visible = False
        '
        'TBarDecl
        '
        Me.TBarDecl.Name = "TBarDecl"
        Me.TBarDecl.Text = "Declaration"
        '
        'TBarAff
        '
        Me.TBarAff.Name = "TBarAff"
        Me.TBarAff.Text = "Closing/Move/Sale"
        '
        'TBarSep
        '
        Me.TBarSep.Name = "TBarSep"
        Me.TBarSep.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'TBarDepr
        '
        Me.TBarDepr.Name = "TBarDepr"
        Me.TBarDepr.Text = "Depreciated Codes"
        '
        'TBarMV
        '
        Me.TBarMV.Name = "TBarMV"
        Me.TBarMV.Text = "Unregistered MV"
        '
        'TBarHor
        '
        Me.TBarHor.Name = "TBarHor"
        Me.TBarHor.Text = "Horses"
        '
        'TBarMob
        '
        Me.TBarMob.Name = "TBarMob"
        Me.TBarMob.Text = "Mobile Homes"
        '
        'TBarSep2
        '
        Me.TBarSep2.Name = "TBarSep2"
        Me.TBarSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'TBarDsp
        '
        Me.TBarDsp.Name = "TBarDsp"
        Me.TBarDsp.Text = "Disposed"
        '
        'TBarAss
        '
        Me.TBarAss.Name = "TBarAss"
        Me.TBarAss.Text = "Asset List"
        '
        'TBarBus
        '
        Me.TBarBus.Name = "TBarBus"
        Me.TBarBus.Text = "Business"
        '
        'TBarTowns
        '
        Me.TBarTowns.Name = "TBarTowns"
        Me.TBarTowns.Text = "Towns"
        '
        'TBarLor
        '
        Me.TBarLor.Name = "TBarLor"
        Me.TBarLor.Text = "Lessor"
        '
        'TBarLee
        '
        Me.TBarLee.Name = "TBarLee"
        Me.TBarLee.Text = "Lessee"
        '
        'TBarSum
        '
        Me.TBarSum.Name = "TBarSum"
        Me.TBarSum.Text = "SUMMARY"
        '
        'FrmTAP01
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(981, 672)
        Me.Controls.Add(Me.TbForms)
        Me.Controls.Add(Me.SbMain)
        Me.Controls.Add(Me.TbMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmTAP01"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Personal Property Declaration"
        CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmTAP01_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    CloseForms()
  End Sub

  Private Sub FrmTAP01_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkProgName As String
    WrkProgName = MyUtils.GetProgramName(False)

    SbpPgmID.Text = WrkProgName
    SbpEnvironment.Text = myDBConnect.PgmDB
    HelpProvider1.HelpNamespace = MyUtils.GetHelpFile(WrkProgName)

    TBarSave.Enabled = False
    TBarDelete.Enabled = False
    TBarAttach.Enabled = False
    TBarPrint.Enabled = False
    TBarComments.Enabled = False
    MyFrmTAP01B = New FrmTAP01B
    MyFrmTAP01B.MdiParent = Me
    MyFrmTAP01B.Show()
  End Sub

  Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
     If e.Button Is TBarBack Then
      DoBtnBack()
    End If

    If e.Button Is TBarDelete Then
      DoBtnDelete()
    End If

    If e.Button Is TBarNew Then
      DoBtnNew()
    End If

    If e.Button Is TBarAttach Then
      DoBtnAttach()
      Exit Sub
    End If

    If e.Button Is TBarPrint Then
      DoBtnPrint()
    End If

    If e.Button Is TBarSave Then
      DoBtnSave()
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

Private Sub FrmTAP01_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

  If e.KeyCode = Keys.P Then
    DoBtnPrint()
  End If

  If e.KeyCode = Keys.S Then
    DoBtnSave()
  End If

End Sub
Private Sub DoBtnBack()

    Select Case Me.SbpScreen.Text
    Case "Comments"
      MyFrmComments.Close()
    Case "ListCodes"
      MyFrmListCodes.Close()
    Case "ListPPRP"
      MyFrmListPPRP.Close()
    Case "TAP01AFF"
      MyFrmTAP01AFF.Close()
    Case "TAP01ASS"
      MyFrmTAP01ASS.Close()
      MyFrmTAP01C.Show()
    Case "TAP01ASS2"
      MyFrmTAP01ASS2.Close()
    Case "TAP01B"
      MyFrmTAP01.Close()
    Case "TAP01BUS"
      MyFrmTAP01BUS.Close()
      MyFrmTAP01C.Show()
    Case "TAP01BUS2"
      MyFrmTAP01BUS2.Close()
    Case "TAP01C"
      MyFrmTAP01C.Close()
    Case "TAP01DEP"
      MyFrmTAP01DEP.Close()
      MyFrmTAP01C.Show()
		Case "TAP01DSP"
			MyFrmTAP01DSP.Close()
			MyFrmTAP01C.Show()
    Case "TAP01DSP2"
      MyFrmTAP01DSP2.Close()
    Case "TAP01HOR"
      MyFrmTAP01HOR.Close()
      MyFrmTAP01C.Show()
    Case "TAP01HOR2"
      MyFrmTAP01HOR2.Close()
    Case "TAP01LEE"
      MyFrmTAP01LEE.Close()
      MyFrmTAP01C.Show()
    Case "TAP01LEE2"
      MyFrmTAP01LEE2.Close()
    Case "TAP01LOR"
      MyFrmTAP01LOR.Close()
      MyFrmTAP01C.Show()
    Case "TAP01LOR2"
      MyFrmTAP01LOR2.Close()
    Case "TAP01MOB"
      MyFrmTAP01MOB.Close()
      MyFrmTAP01C.Show()
    Case "TAP01MOB2"
      MyFrmTAP01MOB2.Close()
    Case "TAP01MV"
      MyFrmTAP01MV.Close()
      MyFrmTAP01C.Show()
    Case "TAP01MV2"
      MyFrmTAP01MV2.Close()
    Case "TAP01SUM"
      MyFrmTAP01SUM.Close()
      MyFrmTAP01C.Show()
      Case "TAP01TWN"
        MyFrmTAP01TWN.Close()
      MyFrmTAP01C.Show()
    Case "TAP01TWN2"
      MyFrmTAP01TWN2.Close()
    End Select

End Sub
Private Sub DoBtnDelete()
    Dim Cancel As Boolean

    Select Case Me.SbpScreen.Text
    Case "TAP01C"
      MyFrmTAP01C.DeleteData(Cancel)
      If Cancel Then Exit Sub
      MyFrmTAP01C.Close()
      MyFrmTAP01B.FormatGrid(True, False, False)
      MyFrmTAP01B.Show()
    Case "TAP01ASS2"
      MyFrmTAP01ASS2.DeleteData(Cancel)
      If Cancel Then Exit Sub
      MyFrmTAP01ASS2.Close()
    Case "TAP01BUS2"
      MyFrmTAP01BUS2.DeleteData(Cancel)
      If Cancel Then Exit Sub
      MyFrmTAP01BUS2.Close()
    Case "TAP01DSP2"
      MyFrmTAP01DSP2.DeleteData(Cancel)
      If Cancel Then Exit Sub
      MyFrmTAP01DSP2.Close()
    Case "TAP01HOR2"
      MyFrmTAP01HOR2.DeleteData(Cancel)
      If Cancel Then Exit Sub
      MyFrmTAP01HOR2.Close()
    Case "TAP01LEE2"
      MyFrmTAP01LEE2.DeleteData(Cancel)
      If Cancel Then Exit Sub
      MyFrmTAP01LEE2.Close()
    Case "TAP01LOR2"
      MyFrmTAP01LOR2.DeleteData(Cancel)
      If Cancel Then Exit Sub
      MyFrmTAP01LOR2.Close()
    Case "TAP01MOB2"
      MyFrmTAP01MOB2.DeleteData(Cancel)
      If Cancel Then Exit Sub
      MyFrmTAP01MOB2.Close()
    Case "TAP01MV2"
      MyFrmTAP01MV2.DeleteData(Cancel)
      If Cancel Then Exit Sub
      MyFrmTAP01MV2.Close()
    Case "TAP01TWN2"
      MyFrmTAP01TWN2.DeleteData(Cancel)
      If Cancel Then Exit Sub
      MyFrmTAP01TWN2.Close()
    End Select

End Sub
Private Sub DoBtnNew()
    Select Case Me.SbpScreen.Text
    Case "TAP01B"
      MyFrmTAP01C = New FrmTAP01C
      MyFrmTAP01C.MdiParent = MyFrmTAP01B.ParentForm
      MyFrmTAP01C.WrkListNo = 0
      MyFrmTAP01C.WrkYear = MyUtils.CnvSng(MyFrmTAP01B.TxtYear.Text)
      MyFrmTAP01C.Show()
      MyFrmTAP01B.Hide()
    Case "TAP01ASS"
      MyFrmTAP01ASS2 = New FrmTAP01ASS2
      With MyFrmTAP01ASS2
        .MdiParent = MyFrmTAP01B.ParentForm
        .WrkListNo = MyFrmTAP01ASS.WrkListNo
        .WrkYear = MyFrmTAP01ASS.WrkYear
        .WrkSeqNo = 0
        .Show()
      End With
      MyFrmTAP01ASS.Hide()
    Case "TAP01BUS"
      MyFrmTAP01BUS2 = New FrmTAP01BUS2
      With MyFrmTAP01BUS2
        .MdiParent = MyFrmTAP01B.ParentForm
        .WrkListNo = MyFrmTAP01BUS.WrkListNo
        .WrkYear = MyFrmTAP01BUS.WrkYear
        .WrkSeqNo = 0
        .Show()
      End With
      MyFrmTAP01BUS.Hide()
    Case "TAP01DSP"
      MyFrmTAP01DSP2 = New FrmTAP01DSP2
      With MyFrmTAP01DSP2
        .MdiParent = MyFrmTAP01B.ParentForm
        .WrkListNo = MyFrmTAP01DSP.WrkListNo
        .WrkYear = MyFrmTAP01DSP.WrkYear
        .WrkSeqNo = 0
        .Show()
      End With
      MyFrmTAP01DSP.Hide()
    Case "TAP01HOR"
      MyFrmTAP01HOR2 = New FrmTAP01HOR2
      With MyFrmTAP01HOR2
        .MdiParent = MyFrmTAP01B.ParentForm
        .WrkListNo = MyFrmTAP01HOR.WrkListNo
        .WrkYear = MyFrmTAP01HOR.WrkYear
        .WrkSeqNo = 0
        .Show()
      End With
      MyFrmTAP01HOR.Hide()
    Case "TAP01LEE"
      MyFrmTAP01LEE2 = New FrmTAP01LEE2
      With MyFrmTAP01LEE2
        .MdiParent = MyFrmTAP01B.ParentForm
        .WrkListNo = MyFrmTAP01LEE.WrkListNo
        .WrkYear = MyFrmTAP01LEE.WrkYear
        .WrkSeqNo = 0
        .Show()
      End With
      MyFrmTAP01LEE.Hide()
    Case "TAP01LOR"
      MyFrmTAP01LOR2 = New FrmTAP01LOR2
      With MyFrmTAP01LOR2
        .MdiParent = MyFrmTAP01B.ParentForm
        .WrkListNo = MyFrmTAP01LOR.WrkListNo
        .WrkYear = MyFrmTAP01LOR.WrkYear
        .WrkSeqNo = 0
        .Show()
      End With
      MyFrmTAP01LOR.Hide()
    Case "TAP01MOB"
      MyFrmTAP01MOB2 = New FrmTAP01MOB2
      With MyFrmTAP01MOB2
        .MdiParent = MyFrmTAP01B.ParentForm
        .WrkListNo = MyFrmTAP01MOB.WrkListNo
        .WrkYear = MyFrmTAP01MOB.WrkYear
        .WrkSeqNo = 0
        .Show()
      End With
      MyFrmTAP01MOB.Hide()
    Case "TAP01MV"
      MyFrmTAP01MV2 = New FrmTAP01MV2
      With MyFrmTAP01MV2
        .MdiParent = MyFrmTAP01B.ParentForm
        .WrkListNo = MyFrmTAP01MV.WrkListNo
        .WrkYear = MyFrmTAP01MV.WrkYear
        .WrkSeqNo = 0
        .Show()
      End With
      MyFrmTAP01MV.Hide()
    Case "TAP01TWN"
      MyFrmTAP01TWN2 = New FrmTAP01TWN2
      With MyFrmTAP01TWN2
        .MdiParent = MyFrmTAP01B.ParentForm
        .WrkListNo = MyFrmTAP01TWN.WrkListNo
        .WrkYear = MyFrmTAP01TWN.WrkYear
        .WrkSeqNo = 0
        .Show()
      End With
      MyFrmTAP01TWN.Hide()
    End Select

End Sub
  Private Sub DoBtnAttach()
    Dim WrkAttachcount As Integer
    ShowAttachit(“PPDECL”, MyFrmTAP01C.WrkListNo)
    WrkAttachcount = GetAttachcount(“PPDECL”, MyFrmTAP01C.WrkListNo)
    MyFrmTAP01.TBarAttach.Text = WrkAttachcount & " Attachment(s)"
  End Sub
  Private Sub DoBtnPrint()
    PrtReport()
  End Sub
  Private Sub DoBtnSave()
  Select Case MyFrmTAP01.SbpScreen.Text
  Case "Comments"
    MyFrmComments.SaveData()
  Case "TAP01AFF"
    MyFrmTAP01AFF.SaveData()
  Case "TAP01ASS2"
    MyFrmTAP01ASS2.SaveData()
  Case "TAP01BUS2"
    MyFrmTAP01BUS2.SaveData()
  Case "TAP01C"
    MyFrmTAP01C.SaveData()
  Case "TAP01DEP"
    MyFrmTAP01DEP.SaveData()
  Case "TAP01DSP2"
    MyFrmTAP01DSP2.SaveData()
  Case "TAP01HOR2"
    MyFrmTAP01HOR2.SaveData()
  Case "TAP01LEE2"
    MyFrmTAP01LEE2.SaveData()
  Case "TAP01LOR2"
    MyFrmTAP01LOR2.SaveData()
  Case "TAP01MOB2"
    MyFrmTAP01MOB2.SaveData()
  Case "TAP01MV2"
    MyFrmTAP01MV2.SaveData()
  Case "TAP01SUM"
    MyFrmTAP01SUM.SaveData()
  'Case "TAP01SUM2"
  '  MyFrmTAP01SUM2.SaveData()
  'Case "TAP01SUMEX"
  '  MyFrmTAP01SUMEX.SaveData()
  Case "TAP01TWN2"
    MyFrmTAP01TWN2.SaveData()
  End Select
End Sub
  Private Sub DoBtnComments()
    MyFrmComments = New FrmComments
    MyFrmComments.MdiParent = MyFrmTAP01C.ParentForm
    MyFrmComments.WrkListNo = MyUtils.CnvSng(MyFrmTAP01C.TxtListNo.Text)
    MyFrmComments.WrkYear = MyUtils.CnvSng(MyFrmTAP01C.LblYear.Text)
    MyFrmComments.Show()
    MyFrmTAP01C.Hide()
  End Sub

Private Sub TbForms_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbForms.ButtonClick
  Select Case MyFrmTAP01.SbpScreen.Text
  Case "ListCodes"
    MyFrmListCodes.Close()
    MyFrmTAP01DEP.Close()
  Case "TAP01C"
    MyFrmTAP01C.Hide()
  Case "TAP01AFF"
    MyFrmTAP01AFF.Close()
  Case "TAP01ASS"
    MyFrmTAP01ASS.Close()
  Case "TAP01BUS"
    MyFrmTAP01BUS.Close()
  Case "TAP01DEP"
    MyFrmTAP01DEP.Close()
  Case "TAP01DSP"
    MyFrmTAP01DSP.Close()
  Case "TAP01HOR"
    MyFrmTAP01HOR.Close()
  Case "TAP01LEE"
    MyFrmTAP01LEE.Close()
  Case "TAP01LOR"
    MyFrmTAP01LOR.Close()
  Case "TAP01MOB"
    MyFrmTAP01MOB.Close()
  Case "TAP01MV"
    MyFrmTAP01MV.Close()
  Case "TAP01SUM"
    MyFrmTAP01SUM.Close()
  Case "TAP01TWN"
    MyFrmTAP01TWN.Close()
  End Select

 TBarComments.Enabled = False
 If e.Button Is TBarDecl Then
  MyFrmTAP01C.Show()
 End If

 If e.Button Is TBarAff Then
  MyFrmTAP01AFF = New FrmTAP01AFF
  MyFrmTAP01AFF.MdiParent = MyFrmTAP01B.ParentForm
  MyFrmTAP01AFF.WrkListNo = MyFrmTAP01C.WrkListNo
  MyFrmTAP01AFF.WrkYear = MyFrmTAP01C.WrkYear
  MyFrmTAP01AFF.Show()
 End If

 If e.Button Is TBarAss Then
  MyFrmTAP01ASS = New FrmTAP01ASS
  MyFrmTAP01ASS.MdiParent = MyFrmTAP01B.ParentForm
  MyFrmTAP01ASS.WrkListNo = MyFrmTAP01C.WrkListNo
  MyFrmTAP01ASS.WrkYear = MyFrmTAP01C.WrkYear
  MyFrmTAP01ASS.Show()
 End If

 If e.Button Is TBarBus Then
  MyFrmTAP01BUS = New FrmTAP01BUS
  MyFrmTAP01BUS.MdiParent = MyFrmTAP01B.ParentForm
  MyFrmTAP01BUS.WrkListNo = MyFrmTAP01C.WrkListNo
  MyFrmTAP01BUS.WrkYear = MyFrmTAP01C.WrkYear
  MyFrmTAP01BUS.Show()
 End If

 If e.Button Is TBarDepr Then
  MyFrmTAP01DEP = New FrmTAP01DEP
  MyFrmTAP01DEP.MdiParent = MyFrmTAP01B.ParentForm
  MyFrmTAP01DEP.WrkListNo = MyFrmTAP01C.WrkListNo
  MyFrmTAP01DEP.WrkYear = MyFrmTAP01C.WrkYear
  MyFrmTAP01DEP.Show()
 End If

 If e.Button Is TBarDsp Then
  MyFrmTAP01DSP = New FrmTAP01DSP
  MyFrmTAP01DSP.MdiParent = MyFrmTAP01B.ParentForm
  MyFrmTAP01DSP.WrkListNo = MyFrmTAP01C.WrkListNo
  MyFrmTAP01DSP.WrkYear = MyFrmTAP01C.WrkYear
  MyFrmTAP01DSP.Show()
 End If

 If e.Button Is TBarHor Then
  MyFrmTAP01HOR = New FrmTAP01HOR
  MyFrmTAP01HOR.MdiParent = MyFrmTAP01B.ParentForm
  MyFrmTAP01HOR.WrkListNo = MyFrmTAP01C.WrkListNo
  MyFrmTAP01HOR.WrkYear = MyFrmTAP01C.WrkYear
  MyFrmTAP01HOR.Show()
 End If

 If e.Button Is TBarLee Then
  MyFrmTAP01LEE = New FrmTAP01LEE
  MyFrmTAP01LEE.MdiParent = MyFrmTAP01B.ParentForm
  MyFrmTAP01LEE.WrkListNo = MyFrmTAP01C.WrkListNo
  MyFrmTAP01LEE.WrkYear = MyFrmTAP01C.WrkYear
  MyFrmTAP01LEE.Show()
 End If

 If e.Button Is TBarLor Then
  MyFrmTAP01LOR = New FrmTAP01LOR
  MyFrmTAP01LOR.MdiParent = MyFrmTAP01B.ParentForm
  MyFrmTAP01LOR.WrkListNo = MyFrmTAP01C.WrkListNo
  MyFrmTAP01LOR.WrkYear = MyFrmTAP01C.WrkYear
  MyFrmTAP01LOR.Show()
 End If

 If e.Button Is TBarMob Then
  MyFrmTAP01MOB = New FrmTAP01MOB
  MyFrmTAP01MOB.MdiParent = MyFrmTAP01B.ParentForm
  MyFrmTAP01MOB.WrkListNo = MyFrmTAP01C.WrkListNo
  MyFrmTAP01MOB.WrkYear = MyFrmTAP01C.WrkYear
  MyFrmTAP01MOB.Show()
 End If

 If e.Button Is TBarMV Then
  MyFrmTAP01MV = New FrmTAP01MV
  MyFrmTAP01MV.MdiParent = MyFrmTAP01B.ParentForm
  MyFrmTAP01MV.WrkListNo = MyFrmTAP01C.WrkListNo
  MyFrmTAP01MV.WrkYear = MyFrmTAP01C.WrkYear
  MyFrmTAP01MV.Show()
 End If

 If e.Button Is TBarSum Then
  MyFrmTAP01SUM = New FrmTAP01SUM
  MyFrmTAP01SUM.MdiParent = MyFrmTAP01B.ParentForm
  MyFrmTAP01SUM.WrkListNo = MyFrmTAP01C.WrkListNo
  MyFrmTAP01SUM.WrkYear = MyFrmTAP01C.WrkYear
  MyFrmTAP01SUM.Show()
 End If

 If e.Button Is TBarTowns Then
  MyFrmTAP01TWN = New FrmTAP01TWN
  MyFrmTAP01TWN.MdiParent = MyFrmTAP01B.ParentForm
  MyFrmTAP01TWN.WrkListNo = MyFrmTAP01C.WrkListNo
  MyFrmTAP01TWN.WrkYear = MyFrmTAP01C.WrkYear
  MyFrmTAP01TWN.Show()
 End If
End Sub
End Class






