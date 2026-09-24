Public Class FrmPO201
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
Friend WithEvents SbpFiller As System.Windows.Forms.StatusBarPanel
Friend WithEvents SbpVersion As System.Windows.Forms.StatusBarPanel
Friend WithEvents SbpEnvironment As System.Windows.Forms.StatusBarPanel
Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
Friend WithEvents TsOrient As System.Windows.Forms.ToolStripDropDownButton
Friend WithEvents TsOrientPortrait As System.Windows.Forms.ToolStripMenuItem
Friend WithEvents TsOrientLandscape As System.Windows.Forms.ToolStripMenuItem
Friend WithEvents TsOrientDesc As System.Windows.Forms.ToolStripLabel
Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
Friend WithEvents TBarPost As System.Windows.Forms.ToolBarButton
Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPO201))
    Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarBack = New System.Windows.Forms.ToolBarButton()
    Me.TBarSave = New System.Windows.Forms.ToolBarButton()
    Me.TBarNew = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep1 = New System.Windows.Forms.ToolBarButton()
    Me.TBarDelete = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep2 = New System.Windows.Forms.ToolBarButton()
    Me.TBarPrtEdits = New System.Windows.Forms.ToolBarButton()
        Me.TBarPost = New System.Windows.Forms.ToolBarButton()
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
        '
        'TbMain
        '
        Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarBack, Me.TBarSave, Me.TBarNew, Me.TBarSep1, Me.TBarDelete, Me.TBarSep2, Me.TBarPrtEdits, Me.TBarPost})
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
        'TBarNew
        '
        Me.TBarNew.ImageIndex = 2
        Me.TBarNew.Name = "TBarNew"
        Me.TBarNew.Text = "&New Batch"
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
        Me.TBarPost.ImageIndex = 5
        Me.TBarPost.Name = "TBarPost"
        Me.TBarPost.Text = "Post Batch"
        '
        'SbMain
        '
        Me.SbMain.Location = New System.Drawing.Point(0, 633)
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
        'FrmPO201
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(848, 661)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.SbMain)
        Me.Controls.Add(Me.TbMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Name = "FrmPO201"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Maintain Requisitions"
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

    Private Sub FrmPO201_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Dim WrkProgName As String
      WrkProgName = MyUtils.GetProgramName(False)

      SbpPgmID.Text = WrkProgName
      SbpEnvironment.Text = myDBConnect.PgmDB
      HelpProvider1.HelpNamespace = MyUtils.GetHelpFile(WrkProgName)

      MyBatch = "PRQ"
      MyBatchPO = "PPO"
      TBarSave.Enabled = False

      GetReportOrientation()
      ShowReportOrientation()

      MyFrmPO201B = New FrmPO201B
      MyFrmPO201B.MdiParent = Me
      MyFrmPO201B.Show()

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
  End If
End Sub

    Private Sub tbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
      Dim WrkBatchNo As Integer
      Dim WrkLlocn As String
      'Dim PassSecurity As Boolean
      Dim Answer As Integer
      Dim Errors As Boolean

      If e.Button Is TBarBack Then
        DoBtnBack()
        Exit Sub
      End If

      If e.Button Is TBarSave Then
        If SbpScreen.Text = "PO201E" Then
          MyFrmPO201E.SaveData()
          Exit Sub
        End If
      End If

     If e.Button Is TBarNew Then
      DoBtnNew()
      Exit Sub
     End If

    If MyFrmPO201B.DataGrdView.RowCount = 0 Then Exit Sub

    If e.Button Is TBarDelete Then
'        PassSecurity = GetFNDSEC(MyFrmPO201B.C1DataGrdList.Item(MyFrmPO201B.C1DataGrdList.Row, 4))
'        If Not PassSecurity Then Exit Sub
        DoBtnDelete()
        Exit Sub
      End If

    If e.Button Is TBarPrtEdits Then
      '        PassSecurity = GetFNDSEC(MyFrmPO201B.C1DataGrdList.Item(MyFrmPO201B.C1DataGrdList.Row, 4))
      '        If Not PassSecurity Then Exit Sub
      TBarNew.Enabled = False
      TBarDelete.Enabled = False
      TBarPrtEdits.Enabled = False
      WrkBatchNo = MyFrmPO201B.DataGrdView.Item(0, MyFrmPO201B.DataGrdView.CurrentRow.Index).Value()
      MyPostDate = MyUtils.GetDBDateMDY(MyFrmPO201B.DataGrdView.Item(4, MyFrmPO201B.DataGrdView.CurrentRow.Index).Value())
      Errors = DoBtnPrtEdits(False)
      TBarNew.Enabled = True
      TBarDelete.Enabled = True
      TBarPrtEdits.Enabled = True
    End If

    If e.Button Is TBarPost Then
'        PassSecurity = GetFNDSEC(MyFrmPO301B.C1DataGrdList.Item(MyFrmPO301B.C1DataGrdList.Row, 4))
'        If Not PassSecurity Then Exit Sub
        TBarNew.Enabled = False
        TBarDelete.Enabled = False
        TBarPost.Enabled = False
        TBarPrtEdits.Enabled = False

      WrkBatchNo = MyFrmPO201B.DataGrdView.Item(0, MyFrmPO201B.DataGrdView.CurrentRow.Index).Value()
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
        WrkLlocn = MyFrmPO201B.LblLlocn.Text
      MyPostDate = MyUtils.GetDBDateMDY(MyFrmPO201B.DataGrdView.Item(4, MyFrmPO201B.DataGrdView.CurrentRow.Index).Value())
      PstPO(WrkLlocn, WrkBatchNo)
      TBarNew.Enabled = True
        TBarDelete.Enabled = True
        TBarPost.Enabled = True
        TBarPrtEdits.Enabled = True
        MsgBox("Completed normally", MsgBoxStyle.Information, WrkBatchNo & " - Batch has been posted")
        MyFrmPO201B.FormatGrid()
      End If

    End Sub

  Private Sub FrmPO201_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    Dim Cancel As Boolean

    If MyFrmPO201.SbpScreen.Text = "PO201B" Then
      If Cancel Then
        e.Cancel = True
      End If
      Exit Sub
    End If

  End Sub
Private Sub DoBtnBack()
  Dim Answer As Integer

  Select Case Me.SbpScreen.Text
  Case "PO201B"
    Answer = MsgBox("Click on OK to end program", MsgBoxStyle.OkCancel, "Clicking Back on 1st screen ends the program")
    If Answer = MsgBoxResult.Ok Then
      Application.Exit()
    End If
  Case "PO201B"
    MyFrmPO201B.Close()
  Case "PO201D"
    MyFrmPO201D.Close()
  Case "PO201E"
    MyFrmPO201E.Close()
  Case "DltBch"
    MyFrmDltBch.Close()
  Case "ListGLAcct"
    MyFrmListGLAcct.Close()
 End Select
End Sub
Private Sub DoBtnDelete()
  Dim Cancel As Boolean
  Select Case Me.SbpScreen.Text
  Case "PO201B"
    MyFrmPO201B.DeleteData(Cancel)
  Case "PO201E"
    MyFrmPO201E.DeleteData(Cancel)
    If Cancel Then Exit Sub
    MyFrmPO201E.Close()
  End Select

End Sub
Private Sub DoBtnNew()
 Select Case Me.SbpScreen.Text
 Case "PO201B"
  MyFrmPO201B_New = New FrmPO201B_New
  MyFrmPO201B_New.MdiParent = MyFrmPO201B.ParentForm
  MyFrmPO201B_New.Show()
  MyFrmPO201B.Hide()
 Case "PO201D"
  MyFrmPO201E = New FrmPO201E
  MyFrmPO201E.MdiParent = MyFrmPO201D.ParentForm
  MyFrmPO201E.WrkLlocn = MyFrmPO201D.Wrkllocn
  MyFrmPO201E.WrkBatchNo = MyFrmPO201D.WrkBatchNo
  MyFrmPO201E.WrkRqnbr = 0
  MyFrmPO201E.Show()
  MyFrmPO201D.Hide()
 End Select
End Sub
Private Function DoBtnPrtEdits(ByVal Post As Boolean) As Boolean
  Dim WrkLlocn As String
  Dim WrkBatchNo As Integer
  Dim Errors As Boolean

  WrkLlocn = MyFrmPO201B.LblLlocn.Text
    WrkBatchNo = MyFrmPO201B.DataGrdView.Item(0, MyFrmPO201B.DataGrdView.CurrentRow.Index).Value()
    Errors = PrtEdits(WrkLlocn, WrkBatchNo, Post)

    Return Errors
End Function

  Private Sub FrmPO201_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

  If e.KeyCode = Keys.S And TBarSave.Enabled Then
    MyFrmPO201E.SaveData()
    MyFrmPO201E.Close()
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
