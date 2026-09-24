Public Class FrmBD001
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
  Friend WithEvents TBarBack As System.Windows.Forms.ToolBarButton
  Friend WithEvents SbMain As System.Windows.Forms.StatusBar
  Friend WithEvents SbpPgmID As System.Windows.Forms.StatusBarPanel
  Friend WithEvents SbpScreen As System.Windows.Forms.StatusBarPanel
  Friend WithEvents SbpEnvironment As System.Windows.Forms.StatusBarPanel
Friend WithEvents SbpFiller1 As System.Windows.Forms.StatusBarPanel
Friend WithEvents SbpVersion As System.Windows.Forms.StatusBarPanel
Friend WithEvents TBarSettings As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarAuth As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarPending As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarChange As System.Windows.Forms.ToolBarButton
Friend WithEvents TBarCredit As System.Windows.Forms.ToolBarButton
Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBD001))
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarBack = New System.Windows.Forms.ToolBarButton()
    Me.TBarNew = New System.Windows.Forms.ToolBarButton()
    Me.TBarSave = New System.Windows.Forms.ToolBarButton()
    Me.TBarDelete = New System.Windows.Forms.ToolBarButton()
    Me.TBarSep1 = New System.Windows.Forms.ToolBarButton()
    Me.TBarSettings = New System.Windows.Forms.ToolBarButton()
    Me.TBarAuth = New System.Windows.Forms.ToolBarButton()
    Me.TBarPending = New System.Windows.Forms.ToolBarButton()
    Me.TBarChange = New System.Windows.Forms.ToolBarButton()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.SbMain = New System.Windows.Forms.StatusBar()
    Me.SbpPgmID = New System.Windows.Forms.StatusBarPanel()
    Me.SbpScreen = New System.Windows.Forms.StatusBarPanel()
    Me.SbpEnvironment = New System.Windows.Forms.StatusBarPanel()
    Me.SbpFiller1 = New System.Windows.Forms.StatusBarPanel()
    Me.SbpVersion = New System.Windows.Forms.StatusBarPanel()
    Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
    Me.TBarCredit = New System.Windows.Forms.ToolBarButton()
    CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TbMain
    '
    Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarBack, Me.TBarNew, Me.TBarSave, Me.TBarDelete, Me.TBarSep1, Me.TBarSettings, Me.TBarAuth, Me.TBarCredit, Me.TBarPending, Me.TBarChange})
    Me.TbMain.DropDownArrows = True
    Me.TbMain.ImageList = Me.ImageList1
    Me.TbMain.Location = New System.Drawing.Point(0, 0)
    Me.TbMain.Name = "TbMain"
    Me.TbMain.ShowToolTips = True
    Me.TbMain.Size = New System.Drawing.Size(768, 50)
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
    'TBarSettings
    '
    Me.TBarSettings.ImageIndex = 4
    Me.TBarSettings.Name = "TBarSettings"
    Me.TBarSettings.Text = "Settings"
    '
    'TBarAuth
    '
    Me.TBarAuth.Name = "TBarAuth"
    Me.TBarAuth.Text = "Authorize"
    '
    'TBarPending
    '
    Me.TBarPending.ImageIndex = 5
    Me.TBarPending.Name = "TBarPending"
    Me.TBarPending.Text = "Pending"
    '
    'TBarChange
    '
    Me.TBarChange.ImageIndex = 6
    Me.TBarChange.Name = "TBarChange"
    Me.TBarChange.Text = "Chg Permit Type"
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.White
    Me.ImageList1.Images.SetKeyName(0, "")
    Me.ImageList1.Images.SetKeyName(1, "")
    Me.ImageList1.Images.SetKeyName(2, "")
    Me.ImageList1.Images.SetKeyName(3, "")
    Me.ImageList1.Images.SetKeyName(4, "scroll.ico")
    Me.ImageList1.Images.SetKeyName(5, "update address_24.png")
    Me.ImageList1.Images.SetKeyName(6, "comment_edit-128.png")
    Me.ImageList1.Images.SetKeyName(7, "credit card.png")
    '
    'SbMain
    '
    Me.SbMain.Location = New System.Drawing.Point(0, 607)
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
    'TBarCredit
    '
    Me.TBarCredit.ImageIndex = 7
    Me.TBarCredit.Name = "TBarCredit"
    Me.TBarCredit.Text = "Pay Credit "
    '
    'FrmBD001
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.BackColor = System.Drawing.SystemColors.Control
    Me.ClientSize = New System.Drawing.Size(768, 635)
    Me.Controls.Add(Me.SbMain)
    Me.Controls.Add(Me.TbMain)
    Me.ForeColor = System.Drawing.Color.Black
    Me.IsMdiContainer = True
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.Name = "FrmBD001"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Building Dept Permits"
    CType(Me.SbpPgmID, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpScreen, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpFiller1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SbpVersion, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

  Private Sub FrmBD001_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkProgName As String
    WrkProgName = MyUtils.GetProgramName(False)

    SbpPgmID.Text = WrkProgName
    SbpEnvironment.Text = myDBConnect.PgmDB
    HelpProvider1.HelpNamespace = MyUtils.GetHelpFile(WrkProgName)

    If Not MyPayCredit Then
      TBarCredit.Visible = False
    End If

    Me.ControlBox = False
    set_security()   '#sec
    If Not MyPublic Then
      TBarSettings.Enabled = True
      TBarAuth.Visible = False
      TBarSave.Enabled = False
      TBarDelete.Enabled = False
      TBarCredit.Enabled = False
      MyFrmBD001B = New FrmBD001B
      MyFrmBD001B.MdiParent = Me
      MyFrmBD001B.Show()
    Else
      TBarAuth.Enabled = False
      TBarPending.Enabled = True
      TBarNew.Visible = False
      TBarBack.Visible = False
      TBarSave.Visible = False
      TBarDelete.Visible = False
      TBarSettings.Visible = False
      TBarChange.Visible = False
      TBarCredit.Enabled = False
      MyFrmListTypes = New FrmListTypes
      MyFrmListTypes.MdiParent = Me
      MyFrmListTypes.Show()
    End If
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

      If e.Button Is TBarAuth Then
        DoBtnAuthorize()
        Exit Sub
      End If

      If e.Button Is TBarSettings Then
        DoBtnSettings()
        Exit Sub
      End If

      If e.Button Is TBarPending Then
        DoBtnPending()
        Exit Sub
      End If

      If e.Button Is TBarChange Then
        DoBtnPermitType()
        Exit Sub
      End If

      If e.Button Is TBarCredit Then
        DoBtnCreditPay()
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
      TBarSettings.Visible = False
    End If

  End Sub

  Private Sub SbMain_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles SbMain.PanelClick
    If e.StatusBarPanel Is SbpVersion Then
      ShowSplash()
    End If

  End Sub

  Private Sub FrmBD001_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

  Private Sub DoBtnBack()
    Select Case Me.SbpScreen.Text
      Case "ListReal"
        MyFrmListReal.Close()
      Case "ListCon"
        MyFrmListCon.Close()
      Case "ListTypes"
        MyFrmListTypes.Close()
        MyFrmBD001B.FormatGrid()
        MyFrmBD001B.Show()
      Case "BD001B"
        MyFrmBD001.Close()
      Case "BD001C"
        MyFrmBD001C.Close()
        If MyPublic Then
          MyFrmListTypes.Show()
        Else
          MyFrmBD001B.FormatGrid()
          MyFrmBD001B.Show()
        End If
      Case "BD001CD"
        MyFrmBD001CD.Close()
        If MyPublic Then
          MyFrmListTypes.Show()
        Else
          MyFrmBD001B.FormatGrid()
          MyFrmBD001B.Show()
        End If
      Case "BD001CE"
        MyFrmBD001CE.Close()
        If MyPublic Then
          MyFrmListTypes.Show()
        Else
          MyFrmBD001B.FormatGrid()
          MyFrmBD001B.Show()
        End If
      Case "BD001CH"
        MyFrmBD001CH.Close()
        If MyPublic Then
          MyFrmListTypes.Show()
        Else
          MyFrmBD001B.FormatGrid()
          MyFrmBD001B.Show()
        End If
      Case "BD001CZ"
        MyFrmBD001CZ.Close()
        If MyPublic Then
          MyFrmListTypes.Show()
        Else
          MyFrmBD001B.FormatGrid()
          MyFrmBD001B.Show()
        End If
      Case "BD001App"
        MyFrmBD001App.Close()
        If MyPublic Then
          MyFrmBD001.TBarBack.Visible = False
          MyFrmBD001.TBarPending.Enabled = True
          MyFrmBD001.TBarAuth.Enabled = False
          MyFrmListTypes.Show()
        Else
          MyFrmBD001B.Show()
        End If
      Case "BD001D"
        MyFrmBD001D.Close()
        MyFrmBD001B.FormatGrid()
        MyFrmBD001B.Show()
    End Select
  End Sub
  Private Sub DoBtnDelete()
    Dim Answer As Integer

    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Select Case Me.SbpScreen.Text
      Case "BD001C"
        MyFrmBD001C.DeleteData()
        MyFrmBD001C.Close()
      Case "BD001CD"
        MyFrmBD001CD.DeleteData()
        MyFrmBD001CD.Close()
      Case "BD001CE"
        MyFrmBD001CE.DeleteData()
        MyFrmBD001CE.Close()
      Case "BD001CH"
        MyFrmBD001CH.DeleteData()
        MyFrmBD001CH.Close()
      Case "BD001CZ"
        MyFrmBD001CZ.DeleteData()
        MyFrmBD001CZ.Close()
    End Select

    MyFrmBD001B.FormatGrid()
    MyFrmBD001B.Show()
  End Sub

  Private Sub DoBtnNew()
    MyFrmListTypes = New FrmListTypes
    MyFrmListTypes.MdiParent = MyFrmBD001B.ParentForm
    MyFrmListTypes.Show()
    MyFrmBD001B.Hide()
  End Sub
  Private Sub DoBtnSave()
    Select Case Me.SbpScreen.Text
      Case "BD001C"
        MyFrmBD001C.SaveData()
      Case "BD001CD"
        MyFrmBD001CD.SaveData()
      Case "BD001CE"
        MyFrmBD001CE.SaveData()
      Case "BD001CH"
        MyFrmBD001CH.SaveData()
      Case "BD001CZ"
        MyFrmBD001CZ.SaveData()
    End Select
  End Sub
  Private Sub DoBtnSettings()
    MyFrmSettings = New FrmSettings
    MyFrmSettings.ShowDialog()
  End Sub
  Private Sub DoBtnAuthorize()
    Select Case Me.SbpScreen.Text
      Case "BD001C"
        MyFrmBD001C.Authorize()
      Case "BD001CD"
        MyFrmBD001CD.Authorize()
      Case "BD001CE"
        MyFrmBD001CE.Authorize()
      Case "BD001CH"
        MyFrmBD001CH.Authorize()
      Case "BD001CZ"
        MyFrmBD001CZ.Authorize()
    End Select
  End Sub
  Private Sub DoBtnPending()
    Select Case Me.SbpScreen.Text
      Case "BD001C"
        MyFrmBD001C.Close()
      Case "BD001CD"
        MyFrmBD001CD.Close()
      Case "BD001CE"
        MyFrmBD001CE.Close()
      Case "BD001CH"
        MyFrmBD001CH.Close()
      Case "BD001CZ"
        MyFrmBD001CZ.Close()
    End Select

    MyFrmBD001App = New FrmBD001App
    MyFrmBD001App.MdiParent = MyFrmBD001 'C.ParentForm
    MyFrmBD001App.Show()
  End Sub
  Private Sub DoBtnPermitType()
    MyFrmBD001B.PermitType()
  End Sub
  Private Sub DoBtnCreditPay()
    Dim WrkScreen As String
    Dim WrkAcct As String
    Dim WrkAmount As Decimal
    WrkScreen = Me.SbpScreen.Text
    WrkAcct = ""
    Select Case WrkScreen
      Case "BD001C"
        WrkAcct = Replace(MyFrmBD001C.LblRecID.Text, "Record ID ", "") & "-" & MyFrmBD001C.TxtPermitNo.Text
        WrkAmount = MyUtils.CnvSng(MyFrmBD001C.LblTotal.Text)
        MyFrmBD001C.Hide()
      Case "BD001CD"
        WrkAcct = Replace(MyFrmBD001CD.LblRecID.Text, "Record ID ", "") & "-" & MyFrmBD001CD.TxtPermitNo.Text
        WrkAmount = MyUtils.CnvSng(MyFrmBD001CD.LblTotal.Text)
        MyFrmBD001CD.Hide()
      Case "BD001CE"
        WrkAcct = Replace(MyFrmBD001CE.LblRecID.Text, "Record ID ", "") & "-" & MyFrmBD001CE.TxtPermitNo.Text
        WrkAmount = MyUtils.CnvSng(MyFrmBD001CE.LblTotal.Text)
        MyFrmBD001CE.Hide()
      Case "BD001CH"
        WrkAcct = Replace(MyFrmBD001CH.LblRecID.Text, "Record ID ", "") & "-" & MyFrmBD001CH.TxtPermitNo.Text
        WrkAmount = MyUtils.CnvSng(MyFrmBD001CH.LblTotal.Text)
        MyFrmBD001CH.Hide()
      Case "BD001CZ"
        WrkAcct = Replace(MyFrmBD001CZ.LblRecID.Text, "Record ID ", "") & "-" & MyFrmBD001CZ.TxtPermitNo.Text
        WrkAmount = MyUtils.CnvSng(MyFrmBD001CZ.LblTotal.Text)
        MyFrmBD001CZ.Hide()
    End Select

    MyFrmWeb = New FrmWeb
    MyFrmWeb.WrkEmail = ""
    MyFrmWeb.WrkAcct = WrkAcct
    MyFrmWeb.WrkAmount = WrkAmount
    MyFrmWeb.ShowDialog()

    Select Case WrkScreen
      Case "BD001C"
        MyFrmBD001C.Show()
      Case "BD001CD"
        MyFrmBD001CD.Show()
      Case "BD001CE"
        MyFrmBD001CE.Show()
      Case "BD001CH"
        MyFrmBD001CH.Show()
      Case "BD001CZ"
        MyFrmBD001CZ.Show()
    End Select
  End Sub
End Class






