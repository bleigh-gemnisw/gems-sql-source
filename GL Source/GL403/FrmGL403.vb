Public Class FrmGL403
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
  Friend WithEvents imageList1 As System.Windows.Forms.ImageList
  Friend WithEvents TbMain As System.Windows.Forms.ToolBar
  Friend WithEvents SbpPgmID As System.Windows.Forms.StatusBarPanel
  Friend WithEvents SbpScreen As System.Windows.Forms.StatusBarPanel
  Friend WithEvents SbMain As System.Windows.Forms.StatusBar
  Friend WithEvents TBarBack As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarSave As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarNew As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarDelete As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarSep1 As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarSep2 As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarPrtEdits As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarPost As System.Windows.Forms.ToolBarButton
  Friend WithEvents SbpFiller As System.Windows.Forms.StatusBarPanel
  Friend WithEvents SbpVersion As System.Windows.Forms.StatusBarPanel
  Friend WithEvents SbpEnvironment As System.Windows.Forms.StatusBarPanel
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents TsOrient As System.Windows.Forms.ToolStripDropDownButton
  Friend WithEvents TsOrientPortrait As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents TsOrientLandscape As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents TsOrientDesc As System.Windows.Forms.ToolStripLabel
  Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
  Friend WithEvents TBarCreate As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarPrinters As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarChange As ToolBarButton
  Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGL403))
    Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarBack = New System.Windows.Forms.ToolBarButton()
    Me.TBarSave = New System.Windows.Forms.ToolBarButton()
    Me.TBarCreate = New System.Windows.Forms.ToolBarButton()
        Me.TBarChange = New System.Windows.Forms.ToolBarButton()
        Me.TBarNew = New System.Windows.Forms.ToolBarButton()
        Me.TBarSep1 = New System.Windows.Forms.ToolBarButton()
        Me.TBarDelete = New System.Windows.Forms.ToolBarButton()
        Me.TBarSep2 = New System.Windows.Forms.ToolBarButton()
        Me.TBarPrtEdits = New System.Windows.Forms.ToolBarButton()
        Me.TBarPost = New System.Windows.Forms.ToolBarButton()
        Me.TBarPrinters = New System.Windows.Forms.ToolBarButton()
        Me.SbMain = New System.Windows.Forms.StatusBar()
        Me.SbpPgmID = New System.Windows.Forms.StatusBarPanel()
        Me.SbpScreen = New System.Windows.Forms.StatusBarPanel()
        Me.SbpEnvironment = New System.Windows.Forms.StatusBarPanel()
        Me.SbpFiller = New System.Windows.Forms.StatusBarPanel()
        Me.SbpVersion = New System.Windows.Forms.StatusBarPanel()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TsOrient = New System.Windows.Forms.ToolStripDropDownButton()
        Me.TsOrientPortrait = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsOrientLandscape = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsOrientDesc = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SbpFiller, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "")
        Me.imageList1.Images.SetKeyName(1, "")
        Me.imageList1.Images.SetKeyName(2, "")
        Me.imageList1.Images.SetKeyName(3, "")
        Me.imageList1.Images.SetKeyName(4, "print_24.png")
        Me.imageList1.Images.SetKeyName(5, "import_png_789.png")
        Me.imageList1.Images.SetKeyName(6, "Printer Setup.png")
        Me.imageList1.Images.SetKeyName(7, "Edit.ico")
        Me.imageList1.Images.SetKeyName(8, "update all_24.png")
        '
        'TbMain
        '
        Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarBack, Me.TBarSave, Me.TBarCreate, Me.TBarChange, Me.TBarNew, Me.TBarSep1, Me.TBarDelete, Me.TBarSep2, Me.TBarPrtEdits, Me.TBarPost, Me.TBarPrinters})
        Me.TbMain.DropDownArrows = True
        Me.TbMain.ImageList = Me.imageList1
        Me.TbMain.Location = New System.Drawing.Point(0, 0)
        Me.TbMain.Name = "TbMain"
        Me.TbMain.ShowToolTips = True
        Me.TbMain.Size = New System.Drawing.Size(848, 50)
        Me.TbMain.TabIndex = 2
        '
        'TBarBack
        '
        Me.TBarBack.ImageIndex = 0
        Me.TBarBack.Name = "TBarBack"
        Me.TBarBack.Text = "&Back"
        '
        'TBarSave
        '
        Me.TBarSave.ImageIndex = 1
        Me.TBarSave.Name = "TBarSave"
        Me.TBarSave.Text = "&Save"
        '
        'TBarCreate
        '
        Me.TBarCreate.ImageIndex = 5
        Me.TBarCreate.Name = "TBarCreate"
        Me.TBarCreate.Text = "Create Batch"
        '
        'TBarChange
        '
        Me.TBarChange.ImageIndex = 7
        Me.TBarChange.Name = "TBarChange"
        Me.TBarChange.Text = "Change Batch"
        '
        'TBarNew
        '
        Me.TBarNew.ImageIndex = 2
        Me.TBarNew.Name = "TBarNew"
        Me.TBarNew.Text = "&New"
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
        Me.TBarDelete.Text = "&Delete Batch"
        '
        'TBarSep2
        '
        Me.TBarSep2.Name = "TBarSep2"
        Me.TBarSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'TBarPrtEdits
        '
        Me.TBarPrtEdits.ImageIndex = 4
        Me.TBarPrtEdits.Name = "TBarPrtEdits"
        Me.TBarPrtEdits.Text = "&Print Edits"
        '
        'TBarPost
        '
        Me.TBarPost.ImageIndex = 8
        Me.TBarPost.Name = "TBarPost"
        Me.TBarPost.Text = "Post Batch"
        '
        'TBarPrinters
        '
        Me.TBarPrinters.ImageIndex = 6
        Me.TBarPrinters.Name = "TBarPrinters"
        Me.TBarPrinters.Text = "Printer Setup"
        '
        'SbMain
        '
        Me.SbMain.Location = New System.Drawing.Point(0, 510)
        Me.SbMain.Name = "SbMain"
        Me.SbMain.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.SbpPgmID, Me.SbpScreen, Me.SbpEnvironment, Me.SbpFiller, Me.SbpVersion})
        Me.SbMain.ShowPanels = True
        Me.SbMain.Size = New System.Drawing.Size(848, 28)
        Me.SbMain.SizingGrip = False
        Me.SbMain.TabIndex = 4
        '
        'SbpPgmID
        '
        Me.SbpPgmID.Name = "SbpPgmID"
        Me.SbpPgmID.Width = 50
        '
        'SbpScreen
        '
        Me.SbpScreen.Name = "SbpScreen"
        Me.SbpScreen.Width = 50
        '
        'SbpEnvironment
        '
        Me.SbpEnvironment.Name = "SbpEnvironment"
        '
        'SbpFiller
        '
        Me.SbpFiller.Name = "SbpFiller"
        Me.SbpFiller.Width = 545
        '
        'SbpVersion
        '
        Me.SbpVersion.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.SbpVersion.Name = "SbpVersion"
        Me.SbpVersion.Text = "About Program"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsOrient, Me.TsOrientDesc, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 50)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(848, 25)
        Me.ToolStrip1.TabIndex = 8
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TsOrient
        '
        Me.TsOrient.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsOrientPortrait, Me.TsOrientLandscape})
        Me.TsOrient.Image = CType(resources.GetObject("TsOrient.Image"), System.Drawing.Image)
        Me.TsOrient.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsOrient.Name = "TsOrient"
        Me.TsOrient.Size = New System.Drawing.Size(96, 22)
        Me.TsOrient.Text = "Orientation"
        '
        'TsOrientPortrait
        '
        Me.TsOrientPortrait.Checked = True
        Me.TsOrientPortrait.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TsOrientPortrait.Name = "TsOrientPortrait"
        Me.TsOrientPortrait.Size = New System.Drawing.Size(130, 22)
        Me.TsOrientPortrait.Text = "Portrait"
        '
        'TsOrientLandscape
        '
        Me.TsOrientLandscape.Name = "TsOrientLandscape"
        Me.TsOrientLandscape.Size = New System.Drawing.Size(130, 22)
        Me.TsOrientLandscape.Text = "Landscape"
        '
        'TsOrientDesc
        '
        Me.TsOrientDesc.Name = "TsOrientDesc"
        Me.TsOrientDesc.Size = New System.Drawing.Size(0, 22)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(0, 22)
        '
        'FrmGL403
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(848, 538)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.SbMain)
        Me.Controls.Add(Me.TbMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Name = "FrmGL403"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Maintain Reoccuring Journal Entries"
        CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SbpFiller, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmGL403_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkProgName As String
    WrkProgName = MyUtils.GetProgramName(False)

    SbpPgmID.Text = WrkProgName
    SbpEnvironment.Text = myDBConnect.PgmDB
    HelpProvider1.HelpNamespace = MyUtils.GetHelpFile(WrkProgName)

    MyBatch = "PGR"
    TBarSave.Enabled = False

    GetReportOrientation()
    ShowReportOrientation()

    MyFrmGL403B = New FrmGL403B
    MyFrmGL403B.MdiParent = Me
    MyFrmGL403B.Show()

  End Sub
  Private Sub set_security()
    ' note: these will change depending on the application program.
    ' change is difficult as the save button will need to be disabled for it but enabled for add
    If s_full = True Then
      Exit Sub
    End If
    If s_edit = False Then
      TBarNew.Visible = False
      TBarDelete.Visible = False
      TBarPost.Visible = False
    End If
  End Sub

  Private Sub tbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
    Dim WrkBatchNo As Integer
    Dim WrkBatchDate As Integer
    'Dim PassSecurity As Boolean
    Dim Answer As Integer
    Dim Errors As Boolean

    If e.Button Is TBarBack Then
      DoBtnBack()
      Exit Sub
    End If

    If e.Button Is TBarSave Then
      If SbpScreen.Text = "GL403D" Then
        MyFrmGL403D.SaveDtl()
        Exit Sub
      End If
    End If

    If e.Button Is TBarCreate Then
      DoBtnCreate()
      Exit Sub
    End If

    If e.Button Is TBarChange Then
      DoBtnChange()
      Exit Sub
    End If

    If e.Button Is TBarNew Then
      DoBtnNew()
      Exit Sub
    End If

    If MyFrmGL403B.C1DataGrdList.VisibleRows = 0 Then Exit Sub

    If e.Button Is TBarDelete Then
      '        PassSecurity = GetFNDSEC(MyFrmGL403B.C1DataGrdList.Item(MyFrmGL403B.C1DataGrdList.Row, 5))
      '        If Not PassSecurity Then Exit Sub
      DoBtnDelete()
      Exit Sub
    End If

    If e.Button Is TBarPrtEdits Then
      '        PassSecurity = GetFNDSEC(MyFrmGL403B.C1DataGrdList.Item(MyFrmGL403B.C1DataGrdList.Row, 5))
      '        If Not PassSecurity Then Exit Sub
      TBarNew.Enabled = False
      TBarDelete.Enabled = False
      TBarPrtEdits.Enabled = False
      TBarPost.Enabled = False
      WrkBatchNo = MyFrmGL403B.C1DataGrdList.Item(MyFrmGL403B.C1DataGrdList.Row, 0)
      Errors = DoBtnPrtEdits(False)
      TBarNew.Enabled = True
      TBarDelete.Enabled = True
      TBarPost.Enabled = True
      TBarPrtEdits.Enabled = True
    End If

    If e.Button Is TBarPost Then
      '        PassSecurity = GetFNDSEC(MyFrmGL403B.C1DataGrdList.Item(MyFrmGL403B.C1DataGrdList.Row, 5))
      '        If Not PassSecurity Then Exit Sub
      TBarNew.Enabled = False
      TBarDelete.Enabled = False
      TBarPost.Enabled = False
      TBarPrtEdits.Enabled = False

      WrkBatchNo = MyFrmGL403B.C1DataGrdList.Item(MyFrmGL403B.C1DataGrdList.Row, 0)
      WrkBatchDate = MyFrmGL403B.C1DataGrdList.Item(MyFrmGL403B.C1DataGrdList.Row, 3)
      Errors = DoBtnPrtEdits(True)
      If Errors Then
        MsgBox("Correct and repost", MsgBoxStyle.Exclamation, "Errors found in batch")
        TBarNew.Enabled = True
        TBarDelete.Enabled = True
        TBarPost.Enabled = True
        TBarPrtEdits.Enabled = True
        Exit Sub
      End If
      Answer = MsgBox("Reports cannot be rerun once batch has posted. Continue with Posting?", MsgBoxStyle.YesNo, "Report print confirmation")
      If Answer = vbNo Then
        MsgBox("Rerun post batch", MsgBoxStyle.Exclamation, "Posting has been aborted")
        TBarNew.Enabled = True
        TBarDelete.Enabled = True
        TBarPost.Enabled = True
        TBarPrtEdits.Enabled = True
        Exit Sub
      End If
      PstBCHHDR(WrkBatchNo, WrkBatchDate)
      TBarNew.Enabled = False
      TBarDelete.Enabled = True
      TBarPost.Enabled = True
      TBarPrtEdits.Enabled = True
      MsgBox("Completed normally", MsgBoxStyle.Information, WrkBatchNo & " - Batch has been posted")
      MyFrmGL403B.FormatGrid()
    End If

    If e.Button Is TBarPrinters Then
      MyFrmPrinters = New FrmPrinters
      MyFrmPrinters.ShowDialog()
    End If

  End Sub

  Private Sub FrmGL403_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    Dim Cancel As Boolean

    If MyFrmGL403.SbpScreen.Text = "GL403C" Then
      If Cancel Then
        e.Cancel = True
      End If
      Exit Sub
    End If

  End Sub
  Private Sub DoBtnBack()
    Dim Answer As Integer

    Select Case Me.SbpScreen.Text
      Case "GL403B"
        Answer = MsgBox("Click on OK to end program", MsgBoxStyle.OkCancel, "Clicking Back on 1st screen ends the program")
        If Answer = MsgBoxResult.Ok Then
          Application.Exit()
        End If
      Case "GL403B"
        MyFrmGL403B.Close()
      Case "GL403B_New"
        MyFrmGL403B_New.Close()
        MyFrmGL403B.Show()
      Case "GL403C"
        MyFrmGL403C.Close()
      Case "GL403D"
        MyFrmGL403D.Close()
      Case "DltBch"
        MyFrmDltBch.Close()
      Case "ListGLAcct"
        MyFrmListGLAcct.Close()
    End Select
  End Sub
  Private Sub DoBtnDelete()
    Dim Cancel As Boolean
    Select Case Me.SbpScreen.Text
      Case "GL403B"
        MyFrmGL403B.DeleteData(Cancel)
      Case "GL403C"
        MyFrmGL403C.DeleteData(Cancel)
    End Select
  End Sub
  Private Sub DoBtnCreate()
    MyFrmGL403B_New = New FrmGL403B_New
    MyFrmGL403B_New.MdiParent = MyFrmGL403B.ParentForm
    MyFrmGL403B_New.WrkMode = "New"
    MyFrmGL403B_New.WrkBatchNo = 0
    MyFrmGL403B_New.Show()
    MyFrmGL403B.Hide()
  End Sub
  Private Sub DoBtnChange()
    If MyFrmGL403B.C1DataGrdList.VisibleRows > 0 Then
      MyFrmGL403B_New = New FrmGL403B_New
      MyFrmGL403B_New.MdiParent = MyFrmGL403B.ParentForm
      MyFrmGL403B_New.WrkMode = "Change"
      MyFrmGL403B_New.WrkBatchNo = MyFrmGL403B.C1DataGrdList.Item(MyFrmGL403B.C1DataGrdList.Row, 0)
      MyFrmGL403B_New.Show()
      MyFrmGL403B.Hide()
    End If
  End Sub
  Private Sub DoBtnNew()
    Select Case Me.SbpScreen.Text
      Case "GL403C"
        MyFrmGL403D = New FrmGL403D
        MyFrmGL403D.MdiParent = MyFrmGL403B.ParentForm
        MyFrmGL403D.WrkBatchNo = MyFrmGL403B.C1DataGrdList.Item(MyFrmGL403B.C1DataGrdList.Row, 0)
        MyFrmGL403D.Show()
        MyFrmGL403C.Hide()
    End Select
  End Sub
  Private Function DoBtnPrtEdits(ByVal Post As Boolean) As Boolean
    Dim WrkBatchNo As Integer
    Dim WrkPostDate As Integer
    Dim Errors As Boolean

    WrkBatchNo = MyFrmGL403B.C1DataGrdList.Item(MyFrmGL403B.C1DataGrdList.Row, 0)
    WrkPostDate = MyFrmGL403B.C1DataGrdList.Item(MyFrmGL403B.C1DataGrdList.Row, 3)
    Errors = PrtEdits(WrkBatchNo, WrkPostDate, Post)

    Return Errors
  End Function

  Private Sub FrmGL403_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub

    If e.KeyCode = Keys.F12 Then
      MyUtils.PrtScreen(Form.ActiveForm)
    End If

    If e.KeyCode = Keys.B And TBarBack.Enabled Then
      DoBtnBack()
    End If

    If e.KeyCode = Keys.D And TBarDelete.Enabled Then
      DoBtnDelete()
    End If

    If e.KeyCode = Keys.N And TBarNew.Enabled Then
      DoBtnNew()
    End If

    If e.KeyCode = Keys.P And TBarPrtEdits.Enabled Then
      DoBtnPrtEdits(False)
    End If

  End Sub
  Private Sub GetReportOrientation()
    MyReportLandscape = False
    If MyAppSettings.PrintOrient = "L" Then
      MyReportLandscape = True
    End If
  End Sub
  Private Sub SetReportOrientation()
    If MyReportLandscape Then
      MyAppSettings.PrintOrient = "L"
    Else
      MyAppSettings.PrintOrient = "P"
    End If
    SaveAppSettings()
  End Sub
  Private Sub ShowReportOrientation()
    If MyReportLandscape Then
      TsOrientLandscape.Checked = True
      TsOrientPortrait.Checked = False
      TsOrientDesc.Text = "Landscape"
    Else
      TsOrientPortrait.Checked = True
      TsOrientLandscape.Checked = False
      TsOrientDesc.Text = "Portrait"
    End If
  End Sub
  Private Sub SbMain_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles SbMain.PanelClick
    If e.StatusBarPanel Is SbpVersion Then
      ShowSplash()
    End If
  End Sub

  Private Sub TsOrientPortrait_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsOrientPortrait.Click
    MyReportLandscape = False
    SetReportOrientation()
    ShowReportOrientation()
  End Sub

  Private Sub TsOrientLandscape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsOrientLandscape.Click
    MyReportLandscape = True
    SetReportOrientation()
    ShowReportOrientation()
  End Sub
End Class
