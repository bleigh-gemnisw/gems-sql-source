Public Class FrmTXA09
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
  Friend WithEvents TBarView As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarChange As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarSep1 As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarClose As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarSep2 As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarPrtEdits As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarPost As System.Windows.Forms.ToolBarButton
  Friend WithEvents SbpFiller As System.Windows.Forms.StatusBarPanel
  Friend WithEvents SbpVersion As System.Windows.Forms.StatusBarPanel
  Friend WithEvents SbpEnvironment As System.Windows.Forms.StatusBarPanel
  Friend WithEvents TBarPS As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarSettings As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarContinue As System.Windows.Forms.ToolBarButton
  Friend WithEvents TBarAttach As ToolBarButton
  Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTXA09))
    Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarBack = New System.Windows.Forms.ToolBarButton()
    Me.TBarContinue = New System.Windows.Forms.ToolBarButton()
    Me.TBarSave = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep1 = New System.Windows.Forms.ToolBarButton()
    Me.TBarNew = New System.Windows.Forms.ToolBarButton()
    Me.TBarView = New System.Windows.Forms.ToolBarButton()
    Me.TBarChange = New System.Windows.Forms.ToolBarButton()
    Me.TBarDelete = New System.Windows.Forms.ToolBarButton()
    Me.TBarClose = New System.Windows.Forms.ToolBarButton()
    Me.TBarPrtEdits = New System.Windows.Forms.ToolBarButton()
    Me.TBarPost = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep2 = New System.Windows.Forms.ToolBarButton()
    Me.TBarAttach = New System.Windows.Forms.ToolBarButton()
    Me.TBarPS = New System.Windows.Forms.ToolBarButton()
    Me.TBarSettings = New System.Windows.Forms.ToolBarButton()
    Me.SbMain = New System.Windows.Forms.StatusBar()
    Me.SbpPgmID = New System.Windows.Forms.StatusBarPanel()
    Me.SbpScreen = New System.Windows.Forms.StatusBarPanel()
    Me.SbpEnvironment = New System.Windows.Forms.StatusBarPanel()
    Me.SbpFiller = New System.Windows.Forms.StatusBarPanel()
    Me.SbpVersion = New System.Windows.Forms.StatusBarPanel()
    Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
    CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpFiller, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'imageList1
    '
    Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.imageList1.Images.SetKeyName(0, "")
    Me.imageList1.Images.SetKeyName(1, "")
    Me.imageList1.Images.SetKeyName(2, "")
    Me.imageList1.Images.SetKeyName(3, "print_24.png")
    Me.imageList1.Images.SetKeyName(4, "Close.ico")
    Me.imageList1.Images.SetKeyName(5, "Report.ico")
    Me.imageList1.Images.SetKeyName(6, "Edit.ico")
    Me.imageList1.Images.SetKeyName(7, "Open.ico")
    Me.imageList1.Images.SetKeyName(8, "delete_24.png")
    Me.imageList1.Images.SetKeyName(9, "Post.ico")
    Me.imageList1.Images.SetKeyName(10, "More.ico")
    Me.imageList1.Images.SetKeyName(11, "comment_24.png")
    Me.imageList1.Images.SetKeyName(12, "Paperclip.png")
    '
    'TbMain
    '
    Me.TbMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
    Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarBack, Me.TBarContinue, Me.TBarSave, Me.TBarSep1, Me.TBarNew, Me.TBarView, Me.TBarChange, Me.TBarDelete, Me.TBarClose, Me.TBarPrtEdits, Me.TBarPost, Me.TBarSep2, Me.TBarAttach, Me.TBarPS, Me.TBarSettings})
    Me.TbMain.DropDownArrows = True
    Me.TbMain.ImageList = Me.imageList1
    Me.TbMain.Location = New System.Drawing.Point(0, 0)
    Me.TbMain.Name = "TbMain"
    Me.TbMain.ShowToolTips = True
    Me.TbMain.Size = New System.Drawing.Size(855, 50)
    Me.TbMain.TabIndex = 2
    '
    'TBarBack
    '
    Me.TBarBack.ImageIndex = 0
    Me.TBarBack.Name = "TBarBack"
    Me.TBarBack.Text = "&Back"
    '
    'TBarContinue
    '
    Me.TBarContinue.ImageIndex = 10
    Me.TBarContinue.Name = "TBarContinue"
    Me.TBarContinue.Text = "Continue"
    '
    'TBarSave
    '
    Me.TBarSave.ImageIndex = 1
    Me.TBarSave.Name = "TBarSave"
    Me.TBarSave.Text = "&Save"
    '
    'TBarSep1
    '
    Me.TBarSep1.Name = "TBarSep1"
    Me.TBarSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
    '
    'TBarNew
    '
    Me.TBarNew.ImageIndex = 2
    Me.TBarNew.Name = "TBarNew"
    Me.TBarNew.Text = "&New Batch"
    '
    'TBarView
    '
    Me.TBarView.ImageIndex = 7
    Me.TBarView.Name = "TBarView"
    Me.TBarView.Text = "&View"
    '
    'TBarChange
    '
    Me.TBarChange.ImageIndex = 6
    Me.TBarChange.Name = "TBarChange"
    Me.TBarChange.Text = "C&hange "
    '
    'TBarDelete
    '
    Me.TBarDelete.ImageIndex = 8
    Me.TBarDelete.Name = "TBarDelete"
    Me.TBarDelete.Text = "&Delete "
    '
    'TBarClose
    '
    Me.TBarClose.ImageIndex = 4
    Me.TBarClose.Name = "TBarClose"
    Me.TBarClose.Text = "&Close"
    '
    'TBarPrtEdits
    '
    Me.TBarPrtEdits.ImageIndex = 5
    Me.TBarPrtEdits.Name = "TBarPrtEdits"
    Me.TBarPrtEdits.Text = "&Print Edits"
    '
    'TBarPost
    '
    Me.TBarPost.ImageIndex = 9
    Me.TBarPost.Name = "TBarPost"
    Me.TBarPost.Text = "Post"
    '
    'TBarSep2
    '
    Me.TBarSep2.Name = "TBarSep2"
    Me.TBarSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
    '
    'TBarAttach
    '
    Me.TBarAttach.ImageIndex = 12
    Me.TBarAttach.Name = "TBarAttach"
    Me.TBarAttach.Text = "Attachment(s)"
    '
    'TBarPS
    '
    Me.TBarPS.ImageIndex = 3
    Me.TBarPS.Name = "TBarPS"
    Me.TBarPS.Text = "Print Screen"
    '
    'TBarSettings
    '
    Me.TBarSettings.Name = "TBarSettings"
    Me.TBarSettings.Text = "Settings"
    '
    'SbMain
    '
    Me.SbMain.Location = New System.Drawing.Point(0, 535)
    Me.SbMain.Name = "SbMain"
    Me.SbMain.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.SbpPgmID, Me.SbpScreen, Me.SbpEnvironment, Me.SbpFiller, Me.SbpVersion})
    Me.SbMain.ShowPanels = True
    Me.SbMain.Size = New System.Drawing.Size(855, 28)
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
    Me.SbpScreen.Width = 80
    '
    'SbpEnvironment
    '
    Me.SbpEnvironment.Name = "SbpEnvironment"
    '
    'SbpFiller
    '
    Me.SbpFiller.Name = "SbpFiller"
    Me.SbpFiller.Width = 515
    '
    'SbpVersion
    '
    Me.SbpVersion.Alignment = System.Windows.Forms.HorizontalAlignment.Center
    Me.SbpVersion.Name = "SbpVersion"
    Me.SbpVersion.Text = "About program"
    '
    'FrmTXA09
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(855, 563)
    Me.Controls.Add(Me.SbMain)
    Me.Controls.Add(Me.TbMain)
    Me.IsMdiContainer = True
    Me.KeyPreview = True
    Me.Name = "FrmTXA09"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Cash Register"
    CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpFiller, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTXA09_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable
    Dim WrkProgName As String
    WrkProgName = MyUtils.GetProgramName(False)

    SbpPgmID.Text = WrkProgName
    SbpEnvironment.Text = myDBConnect.PgmDB
    HelpProvider1.HelpNamespace = MyUtils.GetHelpFile(WrkProgName)

    TBarSave.Enabled = False
    TBarChange.Enabled = False
    TBarDelete.Enabled = False
    TBarClose.Enabled = False
    TBarPrtEdits.Enabled = False
    TBarPost.Enabled = False
    TBarContinue.Visible = False
    TBarAttach.Enabled = False

    With myTable2
      .TableName = "mytable"
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Tax", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Fee", Type.GetType("System.Decimal"))
      .Columns.Add("Lien", Type.GetType("System.Decimal"))
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
      .Columns.Add("Balance", Type.GetType("System.Decimal"))
      .Columns.Add("Status", Type.GetType("System.String"))
    End With
    MydsGroupItems = New DataSet
    MydsGroupItems.Tables.Add(myTable2)

    If MyInquiryMode Then
      TBarNew.Visible = False
      TBarView.Visible = False
      TBarSave.Visible = False
      TBarChange.Visible = False
      TBarDelete.Visible = False
      TBarClose.Visible = False
      TBarPrtEdits.Visible = False
      TBarPost.Visible = False
      If MyPublicUser Then
        TBarAttach.Visible = False
        TBarSettings.Visible = False
      End If
      If MyInquiryAssr Then
        TBarAttach.Visible = False
      End If
      SbpScreen.Text = "TXA092"
      MyFrmTXA092 = New FrmTXA092
      MyFrmTXA092.MdiParent = Me
      MyFrmTXA092.Show()
    Else
      SbpScreen.Text = "TXA091"
      With myTable
        .TableName = "mytable"
        .Columns.Add("Desc", Type.GetType("System.String"))
        .Columns.Add("ListNo", Type.GetType("System.Int32"))
        .Columns.Add("Type", Type.GetType("System.String"))
        .Columns.Add("Year", Type.GetType("System.Int32"))
        .Columns.Add("Tax", Type.GetType("System.Decimal"))
        .Columns.Add("Interest", Type.GetType("System.Decimal"))
        .Columns.Add("Fee", Type.GetType("System.Decimal"))
        .Columns.Add("Lien", Type.GetType("System.Decimal"))
        .Columns.Add("Bond", Type.GetType("System.Decimal"))
        .Columns.Add("Total", Type.GetType("System.Decimal"))
        .Columns.Add("Balance", Type.GetType("System.Decimal"))
      End With
      MydsPayCredit = New DataSet
      MydsPayCredit.Tables.Add(myTable)

      MyFrmTXA091 = New FrmTXA091
      MyFrmTXA091.MdiParent = Me
      MyFrmTXA091.Show()
    End If
  End Sub

  Private Sub tbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
    Dim Answer As Integer

    If e.Button Is TBarBack Then
      DoBtnBack()
      Exit Sub
    End If

    If e.Button Is TBarContinue Then
      DoBtnContinue()
      Exit Sub
    End If

    If e.Button Is TBarSave Then
      If SbpScreen.Text = "TXA09Open" Then
        MyFrmTXA09Open.SaveData()
        Exit Sub
      End If
      If SbpScreen.Text = "Comments" Then
        MyFrmComments.SaveData()
        Exit Sub
      End If
    End If

    If e.Button Is TBarNew Then
      DoBtnNew()
      Exit Sub
    End If

    If e.Button Is TBarChange Then
      DoBtnChange()
      Exit Sub
    End If

    If e.Button Is TBarDelete Then
      DoBtnDelete()
      Exit Sub
    End If

    If e.Button Is TBarView Then
      DoBtnView()
      Exit Sub
    End If

    If e.Button Is TBarClose Then
      DoBtnClose()
      Exit Sub
    End If

    If e.Button Is TBarPrtEdits Then
      TBarPrtEdits.Enabled = False
      DoBtnPrtEdits(False)
      TBarPrtEdits.Enabled = True
    End If

    If e.Button Is TBarPost Then
      TBarPost.Enabled = False
      DoBtnPrtEdits(True)
      Answer = MsgBox("Reports cannot be rerun once batch has posted. Continue with Posting?", MsgBoxStyle.YesNo, "Report print confirmation")
      If Answer = vbNo Then
        MsgBox("Rerun post batch", MsgBoxStyle.Exclamation, "Posting has been aborted")
        TBarPost.Enabled = True
        Exit Sub
      End If
      Application.DoEvents()
      PstBatch()
      MsgBox("Completed normally", MsgBoxStyle.Information, MyBatchNo & " - Batch has been posted")
      TBarPost.Enabled = True

      MyFrmTXA09View.WrkBackScreen = "TXA094"
      MyFrmTXA09View.WrkCloseScreen = True
      MyFrmTXA09View.Close()
    End If

    If e.Button Is TBarAttach Then
      DoBtnAttach()
      Exit Sub
    End If

    If e.Button Is TBarPS Then
      DoBtnPS()
      Exit Sub
    End If

    If e.Button Is TBarSettings Then
      MyFrmSettings = New FrmSettings
      MyFrmSettings.ShowDialog()
    End If
  End Sub

  Private Sub FrmTXA09_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    Dim Cancel As Boolean

    If MyFrmTXA09.SbpScreen.Text = "TXA094" Then
      If Cancel Then
        e.Cancel = True
      End If
      Exit Sub
    End If

    If MyInquiryMode Then
      If MyFrmTXA09.SbpScreen.Text <> "TXA094" Then
        MsgBox("You can only end program on Collections-Select (first) screen", MsgBoxStyle.Exclamation, "Program end cancelled")
        e.Cancel = True
      End If
    Else
      If MyFrmTXA09.SbpScreen.Text <> "TXA091" Then
        MsgBox("You can only end program on Collections-Drawers (first) screen", MsgBoxStyle.Exclamation, "Program end cancelled")
        e.Cancel = True
      End If
    End If
  End Sub
  Private Sub DoBtnBack()
    Dim Answer As Integer

    Select Case Me.SbpScreen.Text
      Case "TXA091"
        Answer = MsgBox("Click on OK to end program", MsgBoxStyle.OkCancel, "Clicking Back on 1st screen ends the program")
        If Answer = MsgBoxResult.Ok Then
          Application.Exit()
        End If
      Case "TXA09View"
        MyFrmTXA09View.Close()
      Case "TXA092"
        End
      Case "TXA09Close"
        MyFrmTXA09Close.Close()
      Case "TXA09Open"
        MyFrmTXA09Open.Close()
      Case "TXA094"
        If MyInquiryMode Then
          Answer = MsgBox("Click on OK to end program", MsgBoxStyle.OkCancel, "Clicking Back on 1st screen ends the program")
          If Answer = MsgBoxResult.Ok Then
            Application.Exit()
          End If
        Else
          MyFrmTXA094.Close()
        End If
      Case "TXA094B"
        MydsGroupItems.Clear()
        MyFrmTXA094B.Close()
      Case "TXA094C"
        MydsPayCredit.Clear()
        MyFrmTXA094C.Close()
      Case "TXA099"
        MyFrmTXA099.Close()
      Case "TXA09B"
        MyFrmTXA09B.Close()
      Case "TXA09Ben"
        MyFrmTXA09Ben.Close()
      Case "TXA09Crd"
        MyFrmTXA09Crd.Close()
      Case "TXA09DMV"
        MyFrmTXA09DMV.Close()
      Case "TXA09Hist"
        MyFrmTXA09Hist.Close()
      Case "TXA09Adj"
        MyFrmTXA09Adj.Close()
      Case "TXA09Fees"
        MyFrmTXA09Fees.Close()
      Case "TXA09H"
        MyFrmTXA09H.Close()
      Case "TXA09CC"
        MyFrmTXA09CC.Close()
      Case "TXA09CCUB"
        MyFrmTXA09CCUB.Close()
      Case "TXA09Stat"
        MyFrmTXA09Stat.Close()
      Case "TXA09UBA"
        MyFrmTXA09UBA.Close()
      Case "Web"
        MyFrmWeb.Close()
      Case "Comments"
        MyFrmComments.Close()
      Case "ListPenCd"
        MyFrmListPenCd.Close()
    End Select
  End Sub
  Private Sub DoBtnContinue()
    Select Case Me.SbpScreen.Text
      Case "TXA094B"
        MyFrmTXA094B.Close()
      Case "TXA094C"
        MyFrmTXA094C.Close()
    End Select
  End Sub
  Private Sub DoBtnChange()
    MyFrmTXA09Open = New FrmTXA09Open
    MyFrmTXA09Open.MdiParent = MyFrmTXA091.ParentForm
    MyFrmTXA09Open.WrkBatch = MyBatch
    MyFrmTXA09Open.WrkBatchNo = MyBatchNo
    MyFrmTXA09Open.Show()
    MyFrmTXA09View.Hide()
  End Sub
  Private Sub DoBtnClose()
    If Not s_full And Not s_edit Then
      MsgBox("Not Authorized to close an open batch: " & MyUserID, MsgBoxStyle.Exclamation, "Master Authorization required")
      Exit Sub
    End If

    MyFrmTXA09Close = New FrmTXA09Close
    MyFrmTXA09Close.MdiParent = MyFrmTXA09View.ParentForm
    MyFrmTXA09Close.WrkCash = MyUtils.CnvSng(MyFrmTXA09View.LblCash.Text)
    MyFrmTXA09Close.WrkCheck = MyUtils.CnvSng(MyFrmTXA09View.LblCheck.Text)
    MyFrmTXA09Close.WrkCredit = MyUtils.CnvSng(MyFrmTXA09View.LblCredit.Text)
    MyFrmTXA09Close.Show()
    MyFrmTXA09View.Hide()
  End Sub
  Private Sub DoBtnDelete()
    Dim Cancel As Boolean
    MyFrmTXA09View.DeleteData(Cancel)

    If Cancel Then Exit Sub

  End Sub
  Private Sub DoBtnNew()
    MyFrmTXA09Open = New FrmTXA09Open
    MyFrmTXA09Open.MdiParent = MyFrmTXA091.ParentForm
    MyFrmTXA09Open.WrkBatch = String.Empty
    MyFrmTXA09Open.WrkBatchNo = 0
    MyFrmTXA09Open.Show()
    MyFrmTXA091.Hide()
  End Sub
  Private Sub DoBtnPrtEdits(ByVal Post As Boolean)
    PrtEdits(Post)
  End Sub
  Private Sub DoBtnAttach()
    Dim WrkAcct As String
    Dim WrkAttachcount As Integer
    WrkAcct = MyFrmTXA09B.WrkYear & MyFrmTXA09B.WrkType & MyFrmTXA09B.WrkListNo
    ShowAttachit("CASHREG", WrkAcct)
    WrkAttachcount = GetAttachcount("CASHREG", WrkAcct)
    MyFrmTXA09.TBarAttach.Text = WrkAttachcount & " Attachment(s)"
  End Sub
  Private Sub DoBtnPS()
    MyUtils.PrtScreen(Form.ActiveForm, True)
  End Sub
  Private Sub DoBtnView()
    Select Case Me.SbpScreen.Text
      Case "TXA091"
        If MyFrmTXA091.C1DataGrdList.VisibleRows > 0 Then
          MyBatchNo = MyFrmTXA091.C1DataGrdList.Item(MyFrmTXA091.C1DataGrdList.Row, 1)
          MyReceiptDate = MyFrmTXA091.C1DataGrdList.Item(MyFrmTXA091.C1DataGrdList.Row, 3)
          MyInterestDate = MyFrmTXA091.C1DataGrdList.Item(MyFrmTXA091.C1DataGrdList.Row, 4)
          MyFrmTXA091.ViewBatch()
        End If
      Case "TXA094"
        MyFrmTXA094.ViewBatch(MyFrmTXA09.SbpScreen.Text)
    End Select
  End Sub

  Private Sub FrmTXA09_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Dim WrkFamily As String

    If Not e.Alt Then Exit Sub

    If e.KeyCode = Keys.F12 Then
      If SbpScreen.Text = "TXA09B" Then
        WrkFamily = GetTXTypeFamily(MyFrmTXA09B.LblType.Text)
        MyFrmTXA09B.LblDOBTxt.Visible = False
        MyFrmTXA09B.LblDOB.Visible = False
        If WrkFamily = "M" Or WrkFamily = "S" Then
          MyFrmTXA09B.LblProperty.Visible = False
        End If
        Application.DoEvents()
      End If
      MyUtils.PrtScreen(Form.ActiveForm)
      If SbpScreen.Text = "TXA09B" Then
        MyFrmTXA09B.LblDOBTxt.Visible = True
        MyFrmTXA09B.LblDOB.Visible = True
        MyFrmTXA09B.LblProperty.Visible = True
      End If
    End If

    If e.KeyCode = Keys.B And TBarBack.Enabled Then
      DoBtnBack()
    End If

    If e.KeyCode = Keys.C And TBarClose.Enabled Then
      DoBtnClose()
    End If

    If e.KeyCode = Keys.D And TBarDelete.Enabled Then
      DoBtnDelete()
    End If

    If e.KeyCode = Keys.H And TBarChange.Enabled Then
      DoBtnChange()
    End If

    If e.KeyCode = Keys.N And TBarNew.Enabled Then
      DoBtnNew()
    End If

    If e.KeyCode = Keys.P And TBarPrtEdits.Enabled Then
      DoBtnPrtEdits(False)
    End If

    If e.KeyCode = Keys.S And TBarSave.Enabled Then
      MyFrmTXA09Open.SaveData()
      MyFrmTXA09Open.Close()
    End If

    If e.KeyCode = Keys.V And TBarView.Enabled Then
      DoBtnView()
    End If

  End Sub

  Private Sub SbMain_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles SbMain.PanelClick
    If e.StatusBarPanel Is SbpVersion Then
      ShowSplash()
    End If
  End Sub
  Private Sub FrmTXA09_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
    If Not MyInquiryMode Then Exit Sub

    If IsNothing(MyFrmTXA09) Then Exit Sub

    MyFrmTXA09.Text = "Cash Register:  ** Inquiry **"
    If MyFrmTXA09.WindowState = FormWindowState.Minimized Then
      Me.Text = "CR Inquiry"
    End If
  End Sub

End Class






