Public Class FrmMain
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
    Friend WithEvents SbMain As System.Windows.Forms.StatusBar
    Friend WithEvents SbpPgmID As System.Windows.Forms.StatusBarPanel
    Friend WithEvents SbpScreen As System.Windows.Forms.StatusBarPanel
Friend WithEvents SbpFiller1 As System.Windows.Forms.StatusBarPanel
Friend WithEvents SbpVersion As System.Windows.Forms.StatusBarPanel
Friend WithEvents SbpEnvironment As System.Windows.Forms.StatusBarPanel
Friend WithEvents TbMain As System.Windows.Forms.ToolBar
Friend WithEvents TBarBack As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarSep1 As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarSettings As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarBills As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarPrint As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.SbMain = New System.Windows.Forms.StatusBar()
    Me.SbpPgmID = New System.Windows.Forms.StatusBarPanel()
    Me.SbpScreen = New System.Windows.Forms.StatusBarPanel()
    Me.SbpEnvironment = New System.Windows.Forms.StatusBarPanel()
    Me.SbpFiller1 = New System.Windows.Forms.StatusBarPanel()
    Me.SbpVersion = New System.Windows.Forms.StatusBarPanel()
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarBack = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep1 = New System.Windows.Forms.ToolBarButton()
    Me.TBarBills = New System.Windows.Forms.ToolBarButton()
    Me.TBarSettings = New System.Windows.Forms.ToolBarButton()
    CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.White
    Me.ImageList1.Images.SetKeyName(0, "")
    Me.ImageList1.Images.SetKeyName(1, "")
    Me.ImageList1.Images.SetKeyName(2, "SAVE.BMP")
    '
    'SbMain
    '
    Me.SbMain.Location = New System.Drawing.Point(0, 583)
    Me.SbMain.Name = "SbMain"
    Me.SbMain.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.SbpPgmID, Me.SbpScreen, Me.SbpEnvironment, Me.SbpFiller1, Me.SbpVersion})
    Me.SbMain.ShowPanels = True
    Me.SbMain.Size = New System.Drawing.Size(911, 28)
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
    'TbMain
    '
    Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarBack, Me.TBarSep1, Me.TBarBills, Me.TBarSettings})
    Me.TbMain.DropDownArrows = True
    Me.TbMain.ImageList = Me.ImageList1
    Me.TbMain.Location = New System.Drawing.Point(0, 0)
    Me.TbMain.Name = "TbMain"
    Me.TbMain.ShowToolTips = True
    Me.TbMain.Size = New System.Drawing.Size(911, 50)
    Me.TbMain.TabIndex = 7
    '
    'TBarBack
    '
    Me.TBarBack.ImageIndex = 0
    Me.TBarBack.Name = "TBarBack"
    Me.TBarBack.Text = "&Back"
    '
    'TBarSep1
    '
    Me.TBarSep1.Name = "TBarSep1"
    Me.TBarSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
    '
    'TBarBills
    '
    Me.TBarBills.ImageIndex = 1
    Me.TBarBills.Name = "TBarBills"
    Me.TBarBills.Text = "&Print Bills"
    '
    'TBarSettings
    '
    Me.TBarSettings.ImageIndex = 2
    Me.TBarSettings.Name = "TBarSettings"
    Me.TBarSettings.Text = "Save Settings"
    '
    'FrmMain
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.BackColor = System.Drawing.SystemColors.Control
    Me.ClientSize = New System.Drawing.Size(911, 611)
    Me.Controls.Add(Me.TbMain)
    Me.Controls.Add(Me.SbMain)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.IsMdiContainer = True
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.Name = "FrmMain"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Print Group Tax Bills"
    CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
  TBarBills.Enabled = True

  MyFrmMainB = New FrmMainB
  MyFrmMainB.MdiParent = Me
  MyFrmMainB.Show()
End Sub
Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
  If e.Button Is TBarBack Then
    DoBtnBack()
  End If
  If e.Button Is TBarBills Then
    DoBtnBills()
  End If
  If e.Button Is TBarSettings Then
    DoBtnSettings()
  End If
End Sub
Private Sub FrmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub
  If e.KeyCode = Keys.B Then
    DoBtnBack()
  End If
  If e.KeyCode = Keys.P Then
    DoBtnBills()
  End If
End Sub
Private Sub DoBtnBack()
  Select Case SbpScreen.Text
  Case "MainB"
    MyFrmMain.Close()
  End Select
End Sub
Private Sub DoBtnBills()
   MyFrmMain.TBarBills.Enabled = False
   MyFrmMainB.RunBills()
   MyFrmMain.TBarBills.Enabled = True
End Sub
Private Sub DoBtnSettings()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sw As IO.StreamWriter
    Dim WrkProgName As String
    Dim WrkXMLPath As String

    With MyFrmMainB
      MyAppSettings.DBName = .LblName.Text
      MyAppSettings.MVFile = .LblFilePathMV.Text
      MyAppSettings.REFile = .LblFilePathRE.Text
      MyAppSettings.PPFile = .LblFilePathPP.Text
      MyAppSettings.NCOAFile = .LblFilePathNCOA.Text
      MyAppSettings.ExportFile = .LblFilePathExport.Text
      MyAppSettings.DueDate1 = .DtPckDue1.Value
      MyAppSettings.DueDate2 = .DtPckDue2.Value
      MyAppSettings.GraceDate1 = .DtPckGrace1.Value
      MyAppSettings.GraceDate2 = .DtPckGrace2.Value
      MyAppSettings.TownName = .TxtTownName.Text
      MyAppSettings.PayTo = .TxtPayTo.Text
      MyAppSettings.Line1 = .TxtLine1.Text
      MyAppSettings.Line2 = .TxtLine2.Text
      MyAppSettings.Line3 = .TxtLine3.Text
      MyAppSettings.Line4 = .TxtLine4.Text
      MyAppSettings.Line5 = .TxtLine5.Text
      MyAppSettings.Online = .TxtOnline.Text
      MyAppSettings.AssrPhone = .TxtAssrPhone.Text
    End With

    WrkProgName = Replace(GetProgramName, ".exe", "")
    WrkXMLPath = GetDataPath() & "Settings\" & MyTownNo & ".xml"
    sw = New IO.StreamWriter(WrkXMLPath)
    xs.Serialize(sw, MyAppSettings)
    sw.Close()
End Sub
Private Sub SbMain_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles SbMain.PanelClick
  If e.StatusBarPanel Is SbpVersion Then
'    MyFrmSplash = New FrmSplash2
'    MyFrmSplash.ShowDialog()
  End If
End Sub
End Class
