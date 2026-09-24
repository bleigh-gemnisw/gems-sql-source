Public Class FrmTXE08
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
Friend WithEvents SbpVersion As System.Windows.Forms.StatusBarPanel
Friend WithEvents SbpEnvironment As System.Windows.Forms.StatusBarPanel
Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
Friend WithEvents TbMain As System.Windows.Forms.ToolBar
Friend WithEvents TBarBack As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarPrint As System.Windows.Forms.ToolBarButton
Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
Friend WithEvents TsOrient As System.Windows.Forms.ToolStripButton
Friend WithEvents TsOrientDesc As System.Windows.Forms.ToolStripLabel
Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTXE08))
Me.SbMain = New System.Windows.Forms.StatusBar
Me.SbpPgmID = New System.Windows.Forms.StatusBarPanel
Me.SbpScreen = New System.Windows.Forms.StatusBarPanel
Me.SbpEnvironment = New System.Windows.Forms.StatusBarPanel
Me.SbpFiller1 = New System.Windows.Forms.StatusBarPanel
Me.SbpVersion = New System.Windows.Forms.StatusBarPanel
Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.TbMain = New System.Windows.Forms.ToolBar
Me.TBarBack = New System.Windows.Forms.ToolBarButton
Me.TBarPrint = New System.Windows.Forms.ToolBarButton
Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
Me.TsOrient = New System.Windows.Forms.ToolStripButton
Me.TsOrientDesc = New System.Windows.Forms.ToolStripLabel
CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).BeginInit()
Me.ToolStrip1.SuspendLayout()
Me.SuspendLayout()
'
'SbMain
'
Me.SbMain.Location = New System.Drawing.Point(0, 586)
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
Me.SbpVersion.Text = "About Program"
'
'ImageList1
'
Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.ImageList1.TransparentColor = System.Drawing.Color.White
Me.ImageList1.Images.SetKeyName(0, "")
Me.ImageList1.Images.SetKeyName(1, "PRINT.BMP")
Me.ImageList1.Images.SetKeyName(2, "export_png2_129.bmp")
'
'TbMain
'
Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarBack, Me.TBarPrint})
Me.TbMain.DropDownArrows = True
Me.TbMain.ImageList = Me.ImageList1
Me.TbMain.Location = New System.Drawing.Point(0, 0)
Me.TbMain.Name = "TbMain"
Me.TbMain.ShowToolTips = True
Me.TbMain.Size = New System.Drawing.Size(768, 50)
Me.TbMain.TabIndex = 10
'
'TBarBack
'
Me.TBarBack.ImageIndex = 0
Me.TBarBack.Name = "TBarBack"
Me.TBarBack.Text = "&Back"
'
'TBarPrint
'
Me.TBarPrint.ImageIndex = 1
Me.TBarPrint.Name = "TBarPrint"
Me.TBarPrint.Text = "Print"
'
'ToolStrip1
'
Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsOrient, Me.TsOrientDesc})
Me.ToolStrip1.Location = New System.Drawing.Point(0, 50)
Me.ToolStrip1.Name = "ToolStrip1"
Me.ToolStrip1.Size = New System.Drawing.Size(768, 25)
Me.ToolStrip1.TabIndex = 11
Me.ToolStrip1.Text = "ToolStrip1"
'
'TsOrient
'
Me.TsOrient.Image = CType(resources.GetObject("TsOrient.Image"), System.Drawing.Image)
Me.TsOrient.ImageTransparentColor = System.Drawing.Color.Magenta
Me.TsOrient.Name = "TsOrient"
Me.TsOrient.Size = New System.Drawing.Size(90, 22)
Me.TsOrient.Text = "Orientation:"
'
'TsOrientDesc
'
Me.TsOrientDesc.Name = "TsOrientDesc"
Me.TsOrientDesc.Size = New System.Drawing.Size(63, 22)
Me.TsOrientDesc.Text = "Landscape"
'
'FrmTXE08
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.BackColor = System.Drawing.SystemColors.Control
Me.ClientSize = New System.Drawing.Size(768, 614)
Me.Controls.Add(Me.ToolStrip1)
Me.Controls.Add(Me.TbMain)
Me.Controls.Add(Me.SbMain)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.IsMdiContainer = True
Me.KeyPreview = True
Me.MaximizeBox = False
Me.Name = "FrmTXE08"
Me.HelpProvider1.SetShowHelp(Me, True)
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Print Balance Sheet"
CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).EndInit()
Me.ToolStrip1.ResumeLayout(False)
Me.ToolStrip1.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTXE08_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Dim WrkProgName As String
  WrkProgName = MyUtils.GetProgramName(False)

  SbpPgmID.Text = WrkProgName
  SbpEnvironment.Text = myDBConnect.PgmDB
  HelpProvider1.HelpNamespace = MyUtils.GetHelpFile(WrkProgName)

  TBarPrint.Enabled = True
  set_security() '#set
  MyFrmTXE08B = New FrmTXE08B
  MyFrmTXE08B.MdiParent = Me
  MyFrmTXE08B.Show()
End Sub
Private Sub set_security()
' note: these will change depending on the application program.
' change is difficult as the save button will need to be disabled for it but enabled for add
  If s_full = True Then
    Exit Sub
  End If
  If s_edit = False Then
    TBarPrint.Visible = False
  End If
End Sub
Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
  If e.Button Is TBarBack Then
    DoBtnBack()
  End If
  If e.Button Is TBarPrint Then
    DoBtnPrint()
  End If
End Sub
Private Sub FrmTXE08_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub
  If e.KeyCode = Keys.F12 Then
    MyUtils.PrtScreen(Form.ActiveForm)
  End If
  If e.KeyCode = Keys.B Then
    DoBtnBack()
  End If
  If e.KeyCode = Keys.P Then
    DoBtnPrint()
  End If
End Sub
Private Sub DoBtnBack()
  Select Case SbpScreen.Text
  Case "TXE08B"
    MyFrmTXE08.Close()
  End Select
End Sub
Private Sub DoBtnPrint()
   TBarPrint.Enabled = False
   MyFrmTXE08B.RunReport()
   TBarPrint.Enabled = True
End Sub
Private Sub SbMain_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles SbMain.PanelClick
  If e.StatusBarPanel Is SbpVersion Then
    ShowSplash()
  End If
End Sub
End Class
