Public Class FrmMenu

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
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents BtnGL As System.Windows.Forms.Button
  Friend WithEvents BtnFA As System.Windows.Forms.Button
  Friend WithEvents BtnAP As System.Windows.Forms.Button
  Friend WithEvents BtnPO As System.Windows.Forms.Button
  Friend WithEvents BtnAR As System.Windows.Forms.Button
  Friend WithEvents BtnMR As System.Windows.Forms.Button
  Friend WithEvents BtnFI As System.Windows.Forms.Button
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents BtnPK As Button
  Friend WithEvents BtnPS As Button
  Friend WithEvents BtnUB As Button
  Friend WithEvents BtnTX As Button
  Friend WithEvents BtnTA As Button
  Friend WithEvents BtnTS As Button
  Friend WithEvents BtnBD As Button
  Friend WithEvents BtnPR As Button
  Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenu))
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
    Me.BtnGL = New System.Windows.Forms.Button()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.BtnFA = New System.Windows.Forms.Button()
    Me.BtnAP = New System.Windows.Forms.Button()
    Me.BtnPO = New System.Windows.Forms.Button()
    Me.BtnAR = New System.Windows.Forms.Button()
    Me.BtnMR = New System.Windows.Forms.Button()
    Me.BtnFI = New System.Windows.Forms.Button()
    Me.BtnPK = New System.Windows.Forms.Button()
    Me.BtnTA = New System.Windows.Forms.Button()
    Me.BtnTX = New System.Windows.Forms.Button()
    Me.BtnUB = New System.Windows.Forms.Button()
    Me.BtnPS = New System.Windows.Forms.Button()
    Me.BtnBD = New System.Windows.Forms.Button()
    Me.BtnTS = New System.Windows.Forms.Button()
    Me.BtnPR = New System.Windows.Forms.Button()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'BtnGL
    '
    Me.BtnGL.BackColor = System.Drawing.Color.White
    Me.BtnGL.Font = New System.Drawing.Font("Cooper Black", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnGL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.BtnGL.ImageIndex = 3
    Me.BtnGL.ImageList = Me.ImageList1
    Me.BtnGL.Location = New System.Drawing.Point(459, 83)
    Me.BtnGL.Name = "BtnGL"
    Me.BtnGL.Size = New System.Drawing.Size(212, 64)
    Me.BtnGL.TabIndex = 3
    Me.BtnGL.Text = "General Ledger"
    Me.BtnGL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnGL.UseVisualStyleBackColor = False
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "Diamond-Green.png")
    Me.ImageList1.Images.SetKeyName(1, "Diamond-Blue.png")
    Me.ImageList1.Images.SetKeyName(2, "Diamond-Purple.png")
    Me.ImageList1.Images.SetKeyName(3, "Diamond-Orange.png")
    Me.ImageList1.Images.SetKeyName(4, "Diamond-Red.png")
    Me.ImageList1.Images.SetKeyName(5, "Diamond-White.png")
    Me.ImageList1.Images.SetKeyName(6, "Diamond-Redtr.png")
    Me.ImageList1.Images.SetKeyName(7, "Diamond-LightBlue.png")
    '
    'BtnFA
    '
    Me.BtnFA.BackColor = System.Drawing.Color.White
    Me.BtnFA.Font = New System.Drawing.Font("Cooper Black", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.BtnFA.ImageIndex = 5
    Me.BtnFA.ImageList = Me.ImageList1
    Me.BtnFA.Location = New System.Drawing.Point(459, 153)
    Me.BtnFA.Name = "BtnFA"
    Me.BtnFA.Size = New System.Drawing.Size(212, 64)
    Me.BtnFA.TabIndex = 4
    Me.BtnFA.Text = "Fixed Assets"
    Me.BtnFA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnFA.UseVisualStyleBackColor = False
    '
    'BtnAP
    '
    Me.BtnAP.BackColor = System.Drawing.Color.White
    Me.BtnAP.Font = New System.Drawing.Font("Cooper Black", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnAP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.BtnAP.ImageIndex = 4
    Me.BtnAP.ImageList = Me.ImageList1
    Me.BtnAP.Location = New System.Drawing.Point(241, 12)
    Me.BtnAP.Name = "BtnAP"
    Me.BtnAP.Size = New System.Drawing.Size(212, 64)
    Me.BtnAP.TabIndex = 5
    Me.BtnAP.Text = "Accounts Payable"
    Me.BtnAP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnAP.UseVisualStyleBackColor = False
    '
    'BtnPO
    '
    Me.BtnPO.BackColor = System.Drawing.Color.White
    Me.BtnPO.Font = New System.Drawing.Font("Cooper Black", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnPO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.BtnPO.ImageIndex = 2
    Me.BtnPO.ImageList = Me.ImageList1
    Me.BtnPO.Location = New System.Drawing.Point(459, 13)
    Me.BtnPO.Name = "BtnPO"
    Me.BtnPO.Size = New System.Drawing.Size(212, 64)
    Me.BtnPO.TabIndex = 7
    Me.BtnPO.Text = "Purchase Orders"
    Me.BtnPO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnPO.UseVisualStyleBackColor = False
    '
    'BtnAR
    '
    Me.BtnAR.BackColor = System.Drawing.Color.White
    Me.BtnAR.Font = New System.Drawing.Font("Cooper Black", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.BtnAR.ImageIndex = 1
    Me.BtnAR.ImageList = Me.ImageList1
    Me.BtnAR.Location = New System.Drawing.Point(241, 83)
    Me.BtnAR.Name = "BtnAR"
    Me.BtnAR.Size = New System.Drawing.Size(212, 64)
    Me.BtnAR.TabIndex = 8
    Me.BtnAR.Text = "Accounts Receivable"
    Me.BtnAR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnAR.UseVisualStyleBackColor = False
    '
    'BtnMR
    '
    Me.BtnMR.BackColor = System.Drawing.Color.White
    Me.BtnMR.Font = New System.Drawing.Font("Cooper Black", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnMR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.BtnMR.ImageIndex = 6
    Me.BtnMR.ImageList = Me.ImageList1
    Me.BtnMR.Location = New System.Drawing.Point(241, 153)
    Me.BtnMR.Name = "BtnMR"
    Me.BtnMR.Size = New System.Drawing.Size(212, 64)
    Me.BtnMR.TabIndex = 11
    Me.BtnMR.Text = "Misc. Receipts"
    Me.BtnMR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnMR.UseVisualStyleBackColor = False
    '
    'BtnFI
    '
    Me.BtnFI.BackColor = System.Drawing.Color.White
    Me.BtnFI.Font = New System.Drawing.Font("Cooper Black", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.BtnFI.ImageIndex = 0
    Me.BtnFI.ImageList = Me.ImageList1
    Me.BtnFI.Location = New System.Drawing.Point(241, 223)
    Me.BtnFI.Name = "BtnFI"
    Me.BtnFI.Size = New System.Drawing.Size(212, 64)
    Me.BtnFI.TabIndex = 15
    Me.BtnFI.Text = "Financials Inquiry"
    Me.BtnFI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnFI.UseVisualStyleBackColor = False
    Me.BtnFI.Visible = False
    '
    'BtnPK
    '
    Me.BtnPK.BackColor = System.Drawing.Color.White
    Me.BtnPK.Font = New System.Drawing.Font("Cooper Black", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnPK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.BtnPK.ImageIndex = 7
    Me.BtnPK.ImageList = Me.ImageList1
    Me.BtnPK.Location = New System.Drawing.Point(459, 223)
    Me.BtnPK.Name = "BtnPK"
    Me.BtnPK.Size = New System.Drawing.Size(212, 64)
    Me.BtnPK.TabIndex = 16
    Me.BtnPK.Text = "Parking Tickets"
    Me.BtnPK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnPK.UseVisualStyleBackColor = False
    '
    'BtnTA
    '
    Me.BtnTA.BackColor = System.Drawing.Color.White
    Me.BtnTA.Font = New System.Drawing.Font("Cooper Black", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.BtnTA.ImageIndex = 0
    Me.BtnTA.ImageList = Me.ImageList1
    Me.BtnTA.Location = New System.Drawing.Point(12, 12)
    Me.BtnTA.Name = "BtnTA"
    Me.BtnTA.Size = New System.Drawing.Size(212, 64)
    Me.BtnTA.TabIndex = 23
    Me.BtnTA.Text = "Assessor"
    Me.BtnTA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnTA.UseVisualStyleBackColor = False
    '
    'BtnTX
    '
    Me.BtnTX.BackColor = System.Drawing.Color.White
    Me.BtnTX.Font = New System.Drawing.Font("Cooper Black", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTX.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.BtnTX.ImageIndex = 7
    Me.BtnTX.ImageList = Me.ImageList1
    Me.BtnTX.Location = New System.Drawing.Point(12, 83)
    Me.BtnTX.Name = "BtnTX"
    Me.BtnTX.Size = New System.Drawing.Size(212, 64)
    Me.BtnTX.TabIndex = 24
    Me.BtnTX.Text = "Collector"
    Me.BtnTX.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnTX.UseVisualStyleBackColor = False
    '
    'BtnUB
    '
    Me.BtnUB.BackColor = System.Drawing.Color.White
    Me.BtnUB.Font = New System.Drawing.Font("Cooper Black", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnUB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.BtnUB.ImageIndex = 3
    Me.BtnUB.ImageList = Me.ImageList1
    Me.BtnUB.Location = New System.Drawing.Point(12, 153)
    Me.BtnUB.Name = "BtnUB"
    Me.BtnUB.Size = New System.Drawing.Size(212, 64)
    Me.BtnUB.TabIndex = 25
    Me.BtnUB.Text = "Utilities"
    Me.BtnUB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnUB.UseVisualStyleBackColor = False
    '
    'BtnPS
    '
    Me.BtnPS.BackColor = System.Drawing.Color.White
    Me.BtnPS.Font = New System.Drawing.Font("Cooper Black", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnPS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.BtnPS.ImageIndex = 4
    Me.BtnPS.ImageList = Me.ImageList1
    Me.BtnPS.Location = New System.Drawing.Point(12, 223)
    Me.BtnPS.Name = "BtnPS"
    Me.BtnPS.Size = New System.Drawing.Size(212, 64)
    Me.BtnPS.TabIndex = 26
    Me.BtnPS.Text = "Parking Stickers"
    Me.BtnPS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnPS.UseVisualStyleBackColor = False
    '
    'BtnBD
    '
    Me.BtnBD.BackColor = System.Drawing.Color.White
    Me.BtnBD.Font = New System.Drawing.Font("Cooper Black", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnBD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.BtnBD.ImageIndex = 5
    Me.BtnBD.ImageList = Me.ImageList1
    Me.BtnBD.Location = New System.Drawing.Point(12, 293)
    Me.BtnBD.Name = "BtnBD"
    Me.BtnBD.Size = New System.Drawing.Size(212, 64)
    Me.BtnBD.TabIndex = 27
    Me.BtnBD.Text = "Building Dept."
    Me.BtnBD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnBD.UseVisualStyleBackColor = False
    '
    'BtnTS
    '
    Me.BtnTS.BackColor = System.Drawing.Color.White
    Me.BtnTS.Font = New System.Drawing.Font("Cooper Black", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.BtnTS.ImageIndex = 2
    Me.BtnTS.ImageList = Me.ImageList1
    Me.BtnTS.Location = New System.Drawing.Point(241, 408)
    Me.BtnTS.Name = "BtnTS"
    Me.BtnTS.Size = New System.Drawing.Size(212, 64)
    Me.BtnTS.TabIndex = 28
    Me.BtnTS.Text = "Transfer Station"
    Me.BtnTS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnTS.UseVisualStyleBackColor = False
    Me.BtnTS.Visible = False
    '
    'BtnPR
    '
    Me.BtnPR.BackColor = System.Drawing.Color.White
    Me.BtnPR.Font = New System.Drawing.Font("Cooper Black", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnPR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.BtnPR.ImageIndex = 2
    Me.BtnPR.ImageList = Me.ImageList1
    Me.BtnPR.Location = New System.Drawing.Point(241, 293)
    Me.BtnPR.Name = "BtnPR"
    Me.BtnPR.Size = New System.Drawing.Size(212, 64)
    Me.BtnPR.TabIndex = 29
    Me.BtnPR.Text = "Payroll"
    Me.BtnPR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnPR.UseVisualStyleBackColor = False
    '
    'FrmMenu
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
    Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.ClientSize = New System.Drawing.Size(691, 449)
    Me.ControlBox = False
    Me.Controls.Add(Me.BtnPR)
    Me.Controls.Add(Me.BtnTS)
    Me.Controls.Add(Me.BtnBD)
    Me.Controls.Add(Me.BtnPS)
    Me.Controls.Add(Me.BtnUB)
    Me.Controls.Add(Me.BtnTX)
    Me.Controls.Add(Me.BtnTA)
    Me.Controls.Add(Me.BtnPK)
    Me.Controls.Add(Me.BtnFI)
    Me.Controls.Add(Me.BtnMR)
    Me.Controls.Add(Me.BtnAR)
    Me.Controls.Add(Me.BtnPO)
    Me.Controls.Add(Me.BtnAP)
    Me.Controls.Add(Me.BtnFA)
    Me.Controls.Add(Me.BtnGL)
    Me.Cursor = System.Windows.Forms.Cursors.Default
    Me.DoubleBuffered = True
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.HelpButton = True
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmMenu"
    Me.HelpProvider1.SetShowHelp(Me, True)
    Me.Text = "Main Menu"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region
  Dim myGNETGROUP As GNETGROUP.MyData
  Dim myGNETSEC As GNETSEC.MyData

  Private Sub FrmMenu_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmMain.SbpScreen.Text = "Menu"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub FrmMenu_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    End
  End Sub

  Private Sub FrmMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkApps As String
    Dim WrkFullSecurity As Boolean
    Dim Pos As Integer

    myGNETGROUP = New GNETGROUP.MyData()
    myGNETGROUP.MyDBConn = myDBConnect
    myGNETGROUP.GetOneRecordP(MySecGroup)
    myGNETSEC = New GNETSEC.MyData()
    myGNETSEC.MyDBConn = myDBConnect

    ShowMenus(False)
    WrkFullSecurity = False
    If Not myGNETGROUP.RecordNotFound Then
      WrkApps = Trim(myGNETGROUP._GRIGHT)
      Pos = InStr(WrkApps, "AR")
      If Pos > 0 And Not MyNoFin Then
        BtnAR.Visible = True
      End If
      Pos = InStr(WrkApps, "AP")
      If Pos > 0 And Not MyNoFin Then
        BtnAP.Visible = True
      End If
      Pos = InStr(WrkApps, "BD")
      If Pos > 0 Then
        BtnBD.Visible = True
      End If
      Pos = InStr(WrkApps, "FA")
      If Pos > 0 Then
        BtnFA.Visible = True
      End If
      Pos = InStr(WrkApps, "FI")
      If Pos > 0 And Not MyNoFin Then
        BtnFI.Visible = True
      End If
      Pos = InStr(WrkApps, "GL")
      If Pos > 0 And Not MyNoFin Then
        BtnGL.Visible = True
      End If
      Pos = InStr(WrkApps, "IA")
      If Pos > 0 Then
        WrkFullSecurity = True
      End If
      Pos = InStr(WrkApps, "MR")
      If Pos > 0 Then
        BtnMR.Visible = True
      End If
      Pos = InStr(WrkApps, "PO")
      If Pos > 0 And Not MyNoFin Then
        BtnPO.Visible = True
      End If
      Pos = InStr(WrkApps, "PK")
      If Pos > 0 Then
        BtnPK.Visible = True
      End If
      Pos = InStr(WrkApps, "PR")
      If Pos > 0 And Not MyNoFin Then
        BtnPR.Visible = True
      End If
      Pos = InStr(WrkApps, "PS")
      If Pos > 0 Then
        BtnPS.Visible = True
      End If
      Pos = InStr(WrkApps, "TA")
      If Pos > 0 Then
        BtnTA.Visible = True
      End If
      'Pos = InStr(WrkApps, "TS")
      'If Pos > 0 Then
      '  BtnTS.Visible = True
      'End If
      Pos = InStr(WrkApps, "TX")
      If Pos > 0 Then
        BtnTX.Visible = True
      End If
      Pos = InStr(WrkApps, "UB")
      If Pos > 0 Then
        BtnUB.Visible = True
      End If
      Pos = InStr(WrkApps, "**") 'All Applications
      If Pos > 0 Then
        WrkFullSecurity = True
        ShowMenus(True)
      End If
    End If

    BtnTS.Visible = False
    If Not BtnAR.Visible And Not MyNoFin Then
      BtnAR.Visible = FindAppPgm("AR")
    End If
    If Not BtnAP.Visible And Not MyNoFin Then
      BtnAP.Visible = FindAppPgm("AP")
    End If
    If Not BtnBD.Visible Then
      BtnBD.Visible = FindAppPgm("BD")
    End If
    If Not BtnFA.Visible Then
      BtnFA.Visible = FindAppPgm("FA")
    End If
    If Not BtnGL.Visible And Not MyNoFin Then
      BtnGL.Visible = FindAppPgm("GL")
    End If
    If Not BtnMR.Visible Then
      BtnMR.Visible = FindAppPgm("MR")
    End If
    If Not BtnPO.Visible And Not MyNoFin Then
      BtnPO.Visible = FindAppPgm("PO")
    End If
    If Not BtnPK.Visible Then
      BtnPK.Visible = FindAppPgm("PK")
    End If
    If Not BtnPR.Visible And Not MyNoFin Then
      BtnPR.Visible = FindAppPgm("PR")
    End If
    If Not BtnPS.Visible Then
      BtnPS.Visible = FindAppPgm("PS")
    End If
    If Not BtnTA.Visible Then
      BtnTA.Visible = FindAppPgm("TA")
    End If
    'If Not BtnTS.Visible Then
    '  BtnTS.Visible = FindAppPgm("TS")
    'End If
    If Not BtnTX.Visible Then
      BtnTX.Visible = FindAppPgm("TX")
    End If
    If Not BtnUB.Visible Then
      BtnUB.Visible = FindAppPgm("UB")
    End If

    If Not WrkFullSecurity And MySecGroup <> "ADMIN" Then
      GetSecurity("IA001", False)
      If Not s_sec Then MyFrmMain.MnuUsers.Visible = False
      GetSecurity("IA002", False)
      If Not s_sec Then MyFrmMain.MnuGroups.Visible = False
      GetSecurity("IA003", False)
      If Not s_sec Then MyFrmMain.MnuProgList.Visible = False
      GetSecurity("IA101", False)
      If Not s_sec Then MyFrmMain.MnuControl.Visible = False
    End If
  End Sub
  Private Sub BtnGL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGL.Click
    MyFrmMenuGL = New FrmMenuGL
    MyFrmMenuGL.MdiParent = Me.ParentForm
    MyFrmMenuGL.Show()
    Me.Hide()
  End Sub
  Private Sub BtnFA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFA.Click
    MyFrmMenuFA = New FrmMenuFA
    MyFrmMenuFA.MdiParent = Me.ParentForm
    MyFrmMenuFA.Show()
    Me.Hide()
  End Sub
  Private Sub BtnFI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFI.Click
    MyFrmMenuFI = New FrmMenuFI
    MyFrmMenuFI.MdiParent = Me.ParentForm
    MyFrmMenuFI.Show()
    Me.Hide()
  End Sub
  Private Sub BtnAP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAP.Click
    MyFrmMenuAP = New FrmMenuAP
    MyFrmMenuAP.MdiParent = Me.ParentForm
    MyFrmMenuAP.Show()
    Me.Hide()
  End Sub
  Private Sub BtnAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAR.Click
    MyFrmMenuAR = New FrmMenuAR
    MyFrmMenuAR.MdiParent = Me.ParentForm
    MyFrmMenuAR.Show()
    Me.Hide()
  End Sub
  Private Sub BtnBD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBD.Click
    MyFrmMenuBD = New FrmMenuBD
    MyFrmMenuBD.MdiParent = Me.ParentForm
    MyFrmMenuBD.Show()
    Me.Hide()
  End Sub
  Private Sub BtnPK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPK.Click
    MyFrmMenuPK = New FrmMenuPK
    MyFrmMenuPK.MdiParent = Me.ParentForm
    MyFrmMenuPK.Show()
    Me.Hide()
  End Sub
  Private Sub BtnMR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMR.Click
    MyFrmMenuMR = New FrmMenuMR
    MyFrmMenuMR.MdiParent = Me.ParentForm
    MyFrmMenuMR.Show()
    Me.Hide()
  End Sub
  Private Sub BtnPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPR.Click
    MyFrmMenuPR = New FrmMenuPR
    MyFrmMenuPR.MdiParent = Me.ParentForm
    MyFrmMenuPR.Show()
    Me.Hide()
  End Sub
  Private Sub BtnPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPO.Click
    MyFrmMenuPO = New FrmMenuPO
    MyFrmMenuPO.MdiParent = Me.ParentForm
    MyFrmMenuPO.Show()
    Me.Hide()
  End Sub
  Private Sub BtnPS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPS.Click
    MyFrmMenuPS = New FrmMenuPS
    MyFrmMenuPS.MdiParent = Me.ParentForm
    MyFrmMenuPS.Show()
    Me.Hide()
  End Sub
  Private Sub BtnUB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUB.Click
    MyFrmMenuUB = New FrmMenuUB
    MyFrmMenuUB.MdiParent = Me.ParentForm
    MyFrmMenuUB.Show()
    Me.Hide()
  End Sub

  Private Sub BtnTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTA.Click
    MyFrmMenuTA = New FrmMenuTA
    MyFrmMenuTA.MdiParent = Me.ParentForm
    MyFrmMenuTA.Show()
    Me.Hide()

  End Sub
  Private Sub BtnTX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTX.Click
    MyFrmMenuTX = New FrmMenuTX
    MyFrmMenuTX.MdiParent = Me.ParentForm
    MyFrmMenuTX.Show()
    Me.Hide()
  End Sub
  Private Sub FrmMenu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub
    If e.KeyCode = Keys.F12 Then
      MyUtils.PrtScreen(Form.ActiveForm)
    End If
  End Sub
  Private Sub ShowMenus(ByVal WrkShow As Boolean)
    BtnAR.Visible = WrkShow
    BtnAP.Visible = WrkShow
    BtnBD.Visible = WrkShow
    BtnFA.Visible = WrkShow
    BtnFI.Visible = WrkShow
    BtnGL.Visible = WrkShow
    BtnMR.Visible = WrkShow
    BtnPO.Visible = WrkShow
    BtnPK.Visible = WrkShow
    BtnPR.Visible = WrkShow
    BtnPS.Visible = WrkShow
    BtnTA.Visible = WrkShow
    BtnTS.Visible = WrkShow
    BtnTX.Visible = WrkShow
    BtnUB.Visible = WrkShow
    If MyNoFin Then
      BtnAR.Visible = False
      BtnAP.Visible = False
      BtnFI.Visible = False
      BtnGL.Visible = False
      BtnPO.Visible = False
      BtnPR.Visible = False
    End If
  End Sub
  Private Function FindAppPgm(ByVal WrkApp As String) As Boolean
    With myGNETSEC
      .SetRange(MySecGroup, WrkApp)
      .ReadFileE()
      If Not .IsEOF And Mid(._PGMID, 1, 2) = WrkApp Then
        Return True
      Else
        Return False
      End If
    End With
  End Function
End Class
