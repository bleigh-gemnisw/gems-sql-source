Public Class FrmTAP02
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
  Friend WithEvents SbpEnvironment As System.Windows.Forms.StatusBarPanel
Friend WithEvents SbpFiller1 As System.Windows.Forms.StatusBarPanel
Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
Friend WithEvents TbForms As System.Windows.Forms.ToolBar
Friend WithEvents TBarDecl As System.Windows.Forms.ToolBarButton
Friend WithEvents ToolBarButton4 As System.Windows.Forms.ToolBarButton
Friend WithEvents ToolBarButton5 As System.Windows.Forms.ToolBarButton
Friend WithEvents ToolBarButton6 As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarSep As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarSum As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarLst As System.Windows.Forms.ToolBarButton
Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
Friend WithEvents TbMain As System.Windows.Forms.ToolBar
Friend WithEvents TBarBack As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarNew As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarSave As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarDelete As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarSep1 As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarPrint As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarComments As System.Windows.Forms.ToolBarButton
Friend WithEvents SbpVersion As System.Windows.Forms.StatusBarPanel
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTAP02))
    Me.SbMain = New System.Windows.Forms.StatusBar()
    Me.SbpPgmID = New System.Windows.Forms.StatusBarPanel()
    Me.SbpScreen = New System.Windows.Forms.StatusBarPanel()
    Me.SbpEnvironment = New System.Windows.Forms.StatusBarPanel()
    Me.SbpFiller1 = New System.Windows.Forms.StatusBarPanel()
    Me.SbpVersion = New System.Windows.Forms.StatusBarPanel()
    Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
    Me.TbForms = New System.Windows.Forms.ToolBar()
    Me.TBarDecl = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep = New System.Windows.Forms.ToolBarButton()
    Me.TBarLst = New System.Windows.Forms.ToolBarButton()
    Me.TBarSum = New System.Windows.Forms.ToolBarButton()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarBack = New System.Windows.Forms.ToolBarButton()
    Me.TBarNew = New System.Windows.Forms.ToolBarButton()
    Me.TBarSave = New System.Windows.Forms.ToolBarButton()
    Me.TBarDelete = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep1 = New System.Windows.Forms.ToolBarButton()
    Me.TBarPrint = New System.Windows.Forms.ToolBarButton()
    Me.TBarComments = New System.Windows.Forms.ToolBarButton()
    CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
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
    Me.TbForms.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarDecl, Me.TBarSep, Me.TBarLst, Me.TBarSum})
    Me.TbForms.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.TbForms.DropDownArrows = True
    Me.TbForms.Location = New System.Drawing.Point(0, 602)
    Me.TbForms.Name = "TbForms"
    Me.TbForms.ShowToolTips = True
    Me.TbForms.Size = New System.Drawing.Size(981, 42)
    Me.TbForms.TabIndex = 7
    Me.TbForms.Visible = False
    '
    'TBarDecl
    '
    Me.TBarDecl.Name = "TBarDecl"
    Me.TBarDecl.Text = "Declaration"
    '
    'TBarSep
    '
    Me.TBarSep.Name = "TBarSep"
    Me.TBarSep.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
    '
    'TBarLst
    '
    Me.TBarLst.Name = "TBarLst"
    Me.TBarLst.Text = "Asset List"
    '
    'TBarSum
    '
    Me.TBarSum.Name = "TBarSum"
    Me.TBarSum.Text = "SUMMARY"
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
    '
    'TbMain
    '
    Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarBack, Me.TBarNew, Me.TBarSave, Me.TBarDelete, Me.TBarSep1, Me.TBarPrint, Me.TBarComments})
    Me.TbMain.DropDownArrows = True
    Me.TbMain.ImageList = Me.ImageList1
    Me.TbMain.Location = New System.Drawing.Point(0, 0)
    Me.TbMain.Name = "TbMain"
    Me.TbMain.ShowToolTips = True
    Me.TbMain.Size = New System.Drawing.Size(981, 50)
    Me.TbMain.TabIndex = 9
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
    'TBarDelete
    '
    Me.TBarDelete.ImageIndex = 3
    Me.TBarDelete.Name = "TBarDelete"
    Me.TBarDelete.Text = "Delete"
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
    Me.TBarPrint.Text = "Print"
    '
    'TBarComments
    '
    Me.TBarComments.ImageIndex = 5
    Me.TBarComments.Name = "TBarComments"
    Me.TBarComments.Text = "Comments"
    '
    'FrmTAP02
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.BackColor = System.Drawing.SystemColors.Control
    Me.ClientSize = New System.Drawing.Size(981, 672)
    Me.Controls.Add(Me.TbMain)
    Me.Controls.Add(Me.TbForms)
    Me.Controls.Add(Me.SbMain)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.IsMdiContainer = True
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.Name = "FrmTAP02"
    Me.HelpProvider1.SetShowHelp(Me, True)
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Personal Property - Manufacturing  & Equipment (M-65)"
    CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTAP02_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkProgName As String
    WrkProgName = MyUtils.GetProgramName(False)

    SbpPgmID.Text = WrkProgName
    SbpEnvironment.Text = myDBConnect.PgmDB
    HelpProvider1.HelpNamespace = MyUtils.GetHelpFile(WrkProgName)

    TBarSave.Enabled = False
    TBarDelete.Enabled = False
    TBarPrint.Enabled = False
    TBarComments.Enabled = False
    MyFrmTAP02B = New FrmTAP02B
    MyFrmTAP02B.MdiParent = Me
    MyFrmTAP02B.Show()
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

Private Sub FrmTAP02_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
    Case "ListLease"
      MyFrmListLease.Close()
    Case "ListPPRP"
      MyFrmListPPRP.Close()
    Case "TAP02B"
      MyFrmTAP02.Close()
    Case "TAP02C"
      MyFrmTAP02C.Close()
    Case "TAP02LST"
      MyFrmTAP02LST.Close()
      MyFrmTAP02C.Show()
    Case "TAP02LST2"
      MyFrmTAP02LST2.Close()
    Case "TAP02SUM"
      MyFrmTAP02SUM.Close()
      MyFrmTAP02C.Show()
		End Select

End Sub
Private Sub DoBtnDelete()
    Dim Cancel As Boolean

    Select Case Me.SbpScreen.Text
    Case "TAP02C"
      MyFrmTAP02C.DeleteData(Cancel)
      If Cancel Then Exit Sub
      MyFrmTAP02C.Close()
      MyFrmTAP02B.FormatGrid()
      MyFrmTAP02B.Show()
    Case "TAP02LST2"
      MyFrmTAP02LST2.DeleteData(Cancel)
      If Cancel Then Exit Sub
      MyFrmTAP02LST2.Close()
    End Select

End Sub
Private Sub DoBtnNew()
    Select Case Me.SbpScreen.Text
    Case "TAP02B"
      MyFrmTAP02C = New FrmTAP02C
      MyFrmTAP02C.MdiParent = MyFrmTAP02B.ParentForm
      MyFrmTAP02C.WrkListNo = 0
      MyFrmTAP02C.Show()
      MyFrmTAP02B.Hide()
    Case "TAP02LST"
      MyFrmTAP02LST2 = New FrmTAP02LST2
      With MyFrmTAP02LST2
        .MdiParent = MyFrmTAP02B.ParentForm
        .WrkListNo = MyFrmTAP02LST.WrkListNo
        .WrkYear = MyFrmTAP02LST.WrkYear
        .WrkSeqNo = 0
        .Show()
      End With
      MyFrmTAP02LST.Hide()
    End Select

End Sub
Private Sub DoBtnPrint()
  PrtReport()
End Sub
Private Sub DoBtnSave()
  Select Case MyFrmTAP02.SbpScreen.Text
  Case "Comments"
    MyFrmComments.SaveData()
  Case "TAP02C"
    MyFrmTAP02C.SaveData()
  Case "TAP02LST2"
    MyFrmTAP02LST2.SaveData()
	End Select
End Sub
  Private Sub DoBtnComments()
    MyFrmComments = New FrmComments
    MyFrmComments.MdiParent = MyFrmTAP02C.ParentForm
    MyFrmComments.WrkListNo = MyUtils.CnvSng(MyFrmTAP02C.TxtListNo.Text)
    MyFrmComments.WrkYear = MyUtils.CnvSng(MyFrmTAP02C.LblYear.Text)
    MyFrmComments.Show()
    MyFrmTAP02C.Hide()
  End Sub
Private Sub TbForms_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbForms.ButtonClick
  Select Case MyFrmTAP02.SbpScreen.Text
  Case "TAP02C"
    MyFrmTAP02C.Hide()
  Case "TAP02LST"
    MyFrmTAP02LST.Close()
  Case "TAP02SUM"
    MyFrmTAP02SUM.Close()
  End Select

 TBarComments.Enabled = False
 If e.Button Is TBarDecl Then
  MyFrmTAP02C.Show()
 End If

 If e.Button Is TBarLst Then
  MyFrmTAP02LST = New FrmTAP02LST
	With MyFrmTAP02LST
		.MdiParent = MyFrmTAP02B.ParentForm
		.WrkListNo = MyFrmTAP02C.WrkListNo
		.WrkYear = MyFrmTAP02C.WrkYear
		.WrkName = MyFrmTAP02C.TxtName.Text
		.Show()
	End With
 End If

 If e.Button Is TBarSum Then
  MyFrmTAP02SUM = New FrmTAP02SUM
	With MyFrmTAP02SUM
		.MdiParent = MyFrmTAP02B.ParentForm
		.WrkListNo = MyFrmTAP02C.WrkListNo
		.WrkYear = MyFrmTAP02C.WrkYear
		.WrkName = MyFrmTAP02C.TxtName.Text
		.Show()
	End With
 End If

End Sub
End Class






