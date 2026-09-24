Public Class FrmIA002
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
Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
Friend WithEvents TbMain As System.Windows.Forms.ToolBar
Friend WithEvents TBarBack As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarNew As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarSave As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarDelete As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarCopy As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarSep1 As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarPrint As System.Windows.Forms.ToolBarButton
Friend WithEvents SbpVersion As System.Windows.Forms.StatusBarPanel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIA002))
    Me.SbMain = New System.Windows.Forms.StatusBar()
    Me.SbpPgmID = New System.Windows.Forms.StatusBarPanel()
    Me.SbpScreen = New System.Windows.Forms.StatusBarPanel()
    Me.SbpFiller1 = New System.Windows.Forms.StatusBarPanel()
    Me.SbpVersion = New System.Windows.Forms.StatusBarPanel()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarBack = New System.Windows.Forms.ToolBarButton()
    Me.TBarNew = New System.Windows.Forms.ToolBarButton()
    Me.TBarSave = New System.Windows.Forms.ToolBarButton()
    Me.TBarDelete = New System.Windows.Forms.ToolBarButton()
    Me.TBarCopy = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep1 = New System.Windows.Forms.ToolBarButton()
    Me.TBarPrint = New System.Windows.Forms.ToolBarButton()
    CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'SbMain
    '
    Me.SbMain.Location = New System.Drawing.Point(0, 586)
    Me.SbMain.Name = "SbMain"
    Me.SbMain.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.SbpPgmID, Me.SbpScreen, Me.SbpFiller1, Me.SbpVersion})
    Me.SbMain.ShowPanels = True
    Me.SbMain.Size = New System.Drawing.Size(920, 28)
    Me.SbMain.SizingGrip = False
    Me.SbMain.TabIndex = 7
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
    'SbpFiller1
    '
    Me.SbpFiller1.Name = "SbpFiller1"
    Me.SbpFiller1.Width = 710
    '
    'SbpVersion
    '
    Me.SbpVersion.Alignment = System.Windows.Forms.HorizontalAlignment.Center
    Me.SbpVersion.Name = "SbpVersion"
    Me.SbpVersion.Text = "About Program"
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
    Me.ImageList1.Images.SetKeyName(5, "COPY.BMP")
    '
    'TbMain
    '
    Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarBack, Me.TBarNew, Me.TBarSave, Me.TBarDelete, Me.TBarCopy, Me.TBarSep1, Me.TBarPrint})
    Me.TbMain.DropDownArrows = True
    Me.TbMain.ImageList = Me.ImageList1
    Me.TbMain.Location = New System.Drawing.Point(0, 0)
    Me.TbMain.Name = "TbMain"
    Me.TbMain.ShowToolTips = True
    Me.TbMain.Size = New System.Drawing.Size(920, 50)
    Me.TbMain.TabIndex = 9
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
    'TBarCopy
    '
    Me.TBarCopy.ImageIndex = 5
    Me.TBarCopy.Name = "TBarCopy"
    Me.TBarCopy.Text = "Copy"
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
    'FrmIA002
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.BackColor = System.Drawing.SystemColors.Control
    Me.ClientSize = New System.Drawing.Size(920, 614)
    Me.Controls.Add(Me.TbMain)
    Me.Controls.Add(Me.SbMain)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.IsMdiContainer = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmIA002"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Gems Net Security Group Codes"
    CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

    Private Sub FrmIA002_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SbpPgmID.Text = "IA002"
        TBarSave.Enabled = False
        TBarDelete.Enabled = False
        TBarPrint.Enabled = True
        set_security() '#set
        MyFrmIA002B = New FrmIA002B
        MyFrmIA002B.MdiParent = Me
        MyFrmIA002B.Show()
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
Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
  If e.Button Is TBarBack Then
    DoBtnBack()
  End If
  If e.Button Is TBarCopy Then
    DoBtnCopy()
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
End Sub
Private Sub FrmIA001_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub
  If e.KeyCode = Keys.F12 Then
    MyUtils.PrtScreen(Form.ActiveForm)
  End If
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
  Case "IA002B"
    MyFrmIA002.Close()
  Case "IA002C"
    MyFrmIA002C.Close()
    MyFrmIA002B.Show()
  Case "IA002D"
    MyFrmIA002D.Close()
    MyFrmIA002C.Show()
  End Select
End Sub
Private Sub DoBtnCopy()
  MyFrmIA002B.CopyData()
End Sub
Private Sub DoBtnDelete()
  Dim WrkCancel As Boolean
  MyFrmIA002C.DeleteData(WrkCancel)
  If WrkCancel Then Exit Sub
  MyFrmIA002C.Close()
  MyFrmIA002B.FormatGrid()
End Sub
Private Sub DoBtnNew()
  MyFrmIA002C = New FRMIA002C
  MyFrmIA002C.MdiParent = MyFrmIA002B.ParentForm
  MyFrmIA002C.WrkGNETGROUP = ""
  MyFrmIA002C.Show()
  MyFrmIA002B.Hide()
End Sub
Private Sub DoBtnPrint()
  Dim MyCRViewer As FrmCrViewer
  MyCRViewer = New FrmCrViewer
  MyCRViewer.Wrkds = MyFrmIA002B.ds
  MyCRViewer.Show()
End Sub
Private Sub DoBtnSave()
  Select Case Me.SbpScreen.Text
  Case "IA002C"
    MyFrmIA002C.SaveData()
  Case "IA002D"
    MyFrmIA002D.SaveData()
  End Select
End Sub
Private Sub SbMain_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles SbMain.PanelClick
  If e.StatusBarPanel Is SbpVersion Then
    ShowSplash()
  End If
End Sub
End Class
