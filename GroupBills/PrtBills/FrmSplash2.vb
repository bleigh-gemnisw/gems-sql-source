Public Class FrmSplash2
    Inherits System.Windows.Forms.Form
    Dim WrkAssemblies() As System.Reflection.AssemblyName
    Dim dsgems As DataSet = New DataSet
    Dim dssystem As DataSet = New DataSet
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
Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents LblProgName As System.Windows.Forms.Label
Friend WithEvents LblVersion As System.Windows.Forms.Label
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents LblCompany As System.Windows.Forms.Label
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents LblProduct As System.Windows.Forms.Label
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents TabCtl1 As System.Windows.Forms.TabControl
Friend WithEvents TabPgGEMS As System.Windows.Forms.TabPage
Friend WithEvents TabSystem As System.Windows.Forms.TabPage
Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
Friend WithEvents C1DataGrdList2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
Friend WithEvents TbMain As System.Windows.Forms.ToolBar
Friend WithEvents TBarPrint As System.Windows.Forms.ToolBarButton
Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents lblrights As System.Windows.Forms.Label
Friend WithEvents lbluser As System.Windows.Forms.Label
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents PrtDialog As System.Windows.Forms.PrintDialog
Friend WithEvents LblPrtScreen As System.Windows.Forms.Label
Friend WithEvents BntShowPrtScreen As System.Windows.Forms.Button
Friend WithEvents GrpPrtScreen As System.Windows.Forms.GroupBox
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbOrientLandscape As System.Windows.Forms.RadioButton
Friend WithEvents RbOrientPortrait As System.Windows.Forms.RadioButton
Friend WithEvents BtnSave As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSplash2))
Me.PictureBox1 = New System.Windows.Forms.PictureBox
Me.Label1 = New System.Windows.Forms.Label
Me.LblProgName = New System.Windows.Forms.Label
Me.LblVersion = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.LblCompany = New System.Windows.Forms.Label
Me.Label4 = New System.Windows.Forms.Label
Me.LblProduct = New System.Windows.Forms.Label
Me.Label5 = New System.Windows.Forms.Label
Me.TabCtl1 = New System.Windows.Forms.TabControl
Me.TabPgGEMS = New System.Windows.Forms.TabPage
Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
Me.TabSystem = New System.Windows.Forms.TabPage
Me.C1DataGrdList2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
Me.TbMain = New System.Windows.Forms.ToolBar
Me.TBarPrint = New System.Windows.Forms.ToolBarButton
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.Label2 = New System.Windows.Forms.Label
Me.Label6 = New System.Windows.Forms.Label
Me.lblrights = New System.Windows.Forms.Label
Me.lbluser = New System.Windows.Forms.Label
Me.GrpPrtScreen = New System.Windows.Forms.GroupBox
Me.BtnSave = New System.Windows.Forms.Button
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.RbOrientLandscape = New System.Windows.Forms.RadioButton
Me.RbOrientPortrait = New System.Windows.Forms.RadioButton
Me.LblPrtScreen = New System.Windows.Forms.Label
Me.BntShowPrtScreen = New System.Windows.Forms.Button
Me.Label8 = New System.Windows.Forms.Label
Me.PrtDialog = New System.Windows.Forms.PrintDialog
CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
Me.TabCtl1.SuspendLayout()
Me.TabPgGEMS.SuspendLayout()
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
Me.TabSystem.SuspendLayout()
CType(Me.C1DataGrdList2, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GrpPrtScreen.SuspendLayout()
Me.GroupBox2.SuspendLayout()
Me.SuspendLayout()
'
'PictureBox1
'
Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
Me.PictureBox1.Location = New System.Drawing.Point(336, 56)
Me.PictureBox1.Name = "PictureBox1"
Me.PictureBox1.Size = New System.Drawing.Size(80, 56)
Me.PictureBox1.TabIndex = 0
Me.PictureBox1.TabStop = False
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(16, 88)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(88, 16)
Me.Label1.TabIndex = 1
Me.Label1.Text = "Program Name"
'
'LblProgName
'
Me.LblProgName.ForeColor = System.Drawing.Color.Blue
Me.LblProgName.Location = New System.Drawing.Point(104, 88)
Me.LblProgName.Name = "LblProgName"
Me.LblProgName.Size = New System.Drawing.Size(208, 16)
Me.LblProgName.TabIndex = 2
'
'LblVersion
'
Me.LblVersion.ForeColor = System.Drawing.Color.Blue
Me.LblVersion.Location = New System.Drawing.Point(104, 104)
Me.LblVersion.Name = "LblVersion"
Me.LblVersion.Size = New System.Drawing.Size(208, 16)
Me.LblVersion.TabIndex = 4
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(16, 104)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(88, 16)
Me.Label3.TabIndex = 3
Me.Label3.Text = "Version"
'
'LblCompany
'
Me.LblCompany.ForeColor = System.Drawing.Color.Blue
Me.LblCompany.Location = New System.Drawing.Point(104, 56)
Me.LblCompany.Name = "LblCompany"
Me.LblCompany.Size = New System.Drawing.Size(160, 16)
Me.LblCompany.TabIndex = 6
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(16, 56)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(88, 16)
Me.Label4.TabIndex = 5
Me.Label4.Text = "Company Name"
'
'LblProduct
'
Me.LblProduct.ForeColor = System.Drawing.Color.Blue
Me.LblProduct.Location = New System.Drawing.Point(104, 72)
Me.LblProduct.Name = "LblProduct"
Me.LblProduct.Size = New System.Drawing.Size(208, 16)
Me.LblProduct.TabIndex = 9
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(16, 72)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(88, 16)
Me.Label5.TabIndex = 8
Me.Label5.Text = "Product Name"
'
'TabCtl1
'
Me.TabCtl1.Controls.Add(Me.TabPgGEMS)
Me.TabCtl1.Controls.Add(Me.TabSystem)
Me.TabCtl1.Location = New System.Drawing.Point(20, 160)
Me.TabCtl1.Name = "TabCtl1"
Me.TabCtl1.SelectedIndex = 0
Me.TabCtl1.Size = New System.Drawing.Size(380, 236)
Me.TabCtl1.TabIndex = 10
'
'TabPgGEMS
'
Me.TabPgGEMS.Controls.Add(Me.C1DataGrdList)
Me.TabPgGEMS.Location = New System.Drawing.Point(4, 22)
Me.TabPgGEMS.Name = "TabPgGEMS"
Me.TabPgGEMS.Size = New System.Drawing.Size(372, 210)
Me.TabPgGEMS.TabIndex = 0
Me.TabPgGEMS.Text = "GEMS"
'
'C1DataGrdList
'
Me.C1DataGrdList.AllowUpdate = False
Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
Me.C1DataGrdList.Location = New System.Drawing.Point(0, 8)
Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
Me.C1DataGrdList.Name = "C1DataGrdList"
Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.C1DataGrdList.Size = New System.Drawing.Size(368, 200)
Me.C1DataGrdList.TabIndex = 177
Me.C1DataGrdList.Text = "C1TrueDBGrid1"
Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
'
'TabSystem
'
Me.TabSystem.Controls.Add(Me.C1DataGrdList2)
Me.TabSystem.Location = New System.Drawing.Point(4, 22)
Me.TabSystem.Name = "TabSystem"
Me.TabSystem.Size = New System.Drawing.Size(372, 210)
Me.TabSystem.TabIndex = 1
Me.TabSystem.Text = "System"
'
'C1DataGrdList2
'
Me.C1DataGrdList2.AllowUpdate = False
Me.C1DataGrdList2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.C1DataGrdList2.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
Me.C1DataGrdList2.GroupByCaption = "Drag a column header here to group by that column"
Me.C1DataGrdList2.Images.Add(CType(resources.GetObject("C1DataGrdList2.Images"), System.Drawing.Image))
Me.C1DataGrdList2.Location = New System.Drawing.Point(0, 8)
Me.C1DataGrdList2.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
Me.C1DataGrdList2.Name = "C1DataGrdList2"
Me.C1DataGrdList2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdList2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdList2.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdList2.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList2.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.C1DataGrdList2.Size = New System.Drawing.Size(368, 200)
Me.C1DataGrdList2.TabIndex = 178
Me.C1DataGrdList2.Text = "C1TrueDBGrid1"
Me.C1DataGrdList2.PropBag = resources.GetString("C1DataGrdList2.PropBag")
'
'TbMain
'
Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarPrint})
Me.TbMain.DropDownArrows = True
Me.TbMain.ImageList = Me.ImageList1
Me.TbMain.Location = New System.Drawing.Point(0, 0)
Me.TbMain.Name = "TbMain"
Me.TbMain.ShowToolTips = True
Me.TbMain.Size = New System.Drawing.Size(426, 42)
Me.TbMain.TabIndex = 11
'
'TBarPrint
'
Me.TBarPrint.ImageIndex = 0
Me.TBarPrint.Name = "TBarPrint"
Me.TBarPrint.Text = "&Print"
'
'ImageList1
'
Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
Me.ImageList1.Images.SetKeyName(0, "")
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(16, 120)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(88, 16)
Me.Label2.TabIndex = 12
Me.Label2.Text = "User Id"
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(16, 136)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(88, 16)
Me.Label6.TabIndex = 13
Me.Label6.Text = "Access Rights"
'
'lblrights
'
Me.lblrights.ForeColor = System.Drawing.Color.Blue
Me.lblrights.Location = New System.Drawing.Point(104, 136)
Me.lblrights.Name = "lblrights"
Me.lblrights.Size = New System.Drawing.Size(208, 16)
Me.lblrights.TabIndex = 15
'
'lbluser
'
Me.lbluser.ForeColor = System.Drawing.Color.Blue
Me.lbluser.Location = New System.Drawing.Point(104, 120)
Me.lbluser.Name = "lbluser"
Me.lbluser.Size = New System.Drawing.Size(208, 16)
Me.lbluser.TabIndex = 16
'
'GrpPrtScreen
'
Me.GrpPrtScreen.Controls.Add(Me.BtnSave)
Me.GrpPrtScreen.Controls.Add(Me.GroupBox2)
Me.GrpPrtScreen.Controls.Add(Me.LblPrtScreen)
Me.GrpPrtScreen.Controls.Add(Me.BntShowPrtScreen)
Me.GrpPrtScreen.Controls.Add(Me.Label8)
Me.GrpPrtScreen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GrpPrtScreen.Location = New System.Drawing.Point(12, 404)
Me.GrpPrtScreen.Name = "GrpPrtScreen"
Me.GrpPrtScreen.Size = New System.Drawing.Size(392, 84)
Me.GrpPrtScreen.TabIndex = 204
Me.GrpPrtScreen.TabStop = False
Me.GrpPrtScreen.Text = "Print Screen (Alt && F12) Printer Setup"
'
'BtnSave
'
Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.BtnSave.Location = New System.Drawing.Point(192, 56)
Me.BtnSave.Name = "BtnSave"
Me.BtnSave.Size = New System.Drawing.Size(72, 20)
Me.BtnSave.TabIndex = 208
Me.BtnSave.Text = "Save Setup"
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.RbOrientLandscape)
Me.GroupBox2.Controls.Add(Me.RbOrientPortrait)
Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox2.Location = New System.Drawing.Point(288, 16)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(96, 56)
Me.GroupBox2.TabIndex = 207
Me.GroupBox2.TabStop = False
Me.GroupBox2.Text = "Orientation"
'
'RbOrientLandscape
'
Me.RbOrientLandscape.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbOrientLandscape.Location = New System.Drawing.Point(8, 32)
Me.RbOrientLandscape.Name = "RbOrientLandscape"
Me.RbOrientLandscape.Size = New System.Drawing.Size(80, 16)
Me.RbOrientLandscape.TabIndex = 1
Me.RbOrientLandscape.Text = "Landscape"
'
'RbOrientPortrait
'
Me.RbOrientPortrait.Checked = True
Me.RbOrientPortrait.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbOrientPortrait.Location = New System.Drawing.Point(8, 16)
Me.RbOrientPortrait.Name = "RbOrientPortrait"
Me.RbOrientPortrait.Size = New System.Drawing.Size(64, 16)
Me.RbOrientPortrait.TabIndex = 0
Me.RbOrientPortrait.TabStop = True
Me.RbOrientPortrait.Text = "Portrait"
'
'LblPrtScreen
'
Me.LblPrtScreen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblPrtScreen.Location = New System.Drawing.Point(8, 32)
Me.LblPrtScreen.Name = "LblPrtScreen"
Me.LblPrtScreen.Size = New System.Drawing.Size(256, 16)
Me.LblPrtScreen.TabIndex = 206
'
'BntShowPrtScreen
'
Me.BntShowPrtScreen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.BntShowPrtScreen.Location = New System.Drawing.Point(8, 56)
Me.BntShowPrtScreen.Name = "BntShowPrtScreen"
Me.BntShowPrtScreen.Size = New System.Drawing.Size(88, 20)
Me.BntShowPrtScreen.TabIndex = 205
Me.BntShowPrtScreen.Text = "Show Printers"
'
'Label8
'
Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label8.Location = New System.Drawing.Point(8, 16)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(72, 11)
Me.Label8.TabIndex = 204
Me.Label8.Text = "Printer Name"
'
'FrmSplash
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(426, 496)
Me.Controls.Add(Me.GrpPrtScreen)
Me.Controls.Add(Me.lbluser)
Me.Controls.Add(Me.lblrights)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.TabCtl1)
Me.Controls.Add(Me.LblProduct)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.LblCompany)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.LblVersion)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.LblProgName)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.PictureBox1)
Me.Controls.Add(Me.TbMain)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmSplash"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "About"
CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
Me.TabCtl1.ResumeLayout(False)
Me.TabPgGEMS.ResumeLayout(False)
CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
Me.TabSystem.ResumeLayout(False)
CType(Me.C1DataGrdList2, System.ComponentModel.ISupportInitialize).EndInit()
Me.GrpPrtScreen.ResumeLayout(False)
Me.GroupBox2.ResumeLayout(False)
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmSplash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkFileName As String
    Dim WrkStartDate As Date
    Dim WrkDate As Date

    WrkStartDate = #1/1/2000#
    WrkFileName = System.Reflection.Assembly.GetExecutingAssembly.Location

    Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(WrkFileName)
    WrkAssemblies = System.Reflection.Assembly.GetExecutingAssembly.GetReferencedAssemblies

    Me.Text = "About program: " & Application.ProductName
    LblCompany.Text = Application.CompanyName
    LblProduct.Text = Application.ProductName
'    lbluser.Text = MyUserID    '#sec
'    lblrights.Text = s_rights  '#sec
    With myFileVersionInfo
      WrkDate = DateAdd(DateInterval.Day, .FileBuildPart(), WrkStartDate)
      LblProgName.Text = .InternalName
      LblVersion.Text = .FileVersion & " (" & WrkDate & ")"
   End With

   BuildDS()
   LoadGrid()

   With C1DataGrdList
     .DataSource = dsgems.Tables(0)
     .Refresh()
     .Rebind(True)
     .Splits(0).DisplayColumns(0).Width = 150
     .Columns(2).NumberFormat = "Short Date"
     .Splits(0).DisplayColumns(2).Width = 70
   End With

   With C1DataGrdList2
     .DataSource = dssystem.Tables(0)
     .Refresh()
     .Rebind(True)
     .Splits(0).DisplayColumns(0).Width = 225
     .Splits(0).DisplayColumns(2).Visible = False
   End With

End Sub

Private Function CheckSystemAssembly(ByVal Name As String) As Boolean
  Dim WrkSystem As Boolean

  WrkSystem = False
  If Mid(Name, 1, 8) = "mscorlib" Then
    WrkSystem = True
  End If

  If Mid(Name, 1, 9) = "Microsoft" Then
    WrkSystem = True
  End If

  If Mid(Name, 1, 6) = "System" Then
    WrkSystem = True
  End If

  If Mid(Name, 1, 7) = "Crystal" Then
    WrkSystem = True
  End If

  If Mid(Name, 1, 2) = "C1" Then
    WrkSystem = True
  End If

  If Mid(Name, 1, 4) = "ASNA" Then
    WrkSystem = True
  End If

  Return WrkSystem
End Function
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Version", Type.GetType("System.String"))
      .Columns.Add("FileDate", Type.GetType("System.DateTime"))
    End With
    dsgems.Tables.Add(myTable)
    dssystem = dsgems.Clone
  End Sub
Private Sub LoadGrid()
  Dim myDr As Data.DataRow
  Dim WrkSystem As Boolean
  Dim WrkStartDate As Date
  Dim WrkDate As Date
  Dim I As Integer

    WrkStartDate = #1/1/2000#
    For I = 0 To WrkAssemblies.GetUpperBound(0)
      WrkSystem = CheckSystemAssembly(WrkAssemblies(I).Name)
      If Not WrkSystem Then
        WrkDate = DateAdd(DateInterval.Day, WrkAssemblies(I).Version.Build, WrkStartDate)
        myDr = dsgems.Tables(0).NewRow
        myDr("Name") = WrkAssemblies(I).Name
        myDr("Version") = WrkAssemblies(I).Version.ToString
        myDr("FileDate") = Format(WrkDate, "Short Date")
        dsgems.Tables(0).Rows.Add(myDr)
      Else
        myDr = dssystem.Tables(0).NewRow
        myDr("Name") = WrkAssemblies(I).Name
        myDr("Version") = WrkAssemblies(I).Version.ToString
        dssystem.Tables(0).Rows.Add(myDr)
      End If
   Next

End Sub

Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick

  If e.Button Is TBarPrint Then
    If TabCtl1.SelectedTab Is TabPgGEMS Then
      With C1DataGrdList.PrintInfo
        .PageHeader = LblProgName.Text & ": " & LblVersion.Text
        .Print()
      End With
    Else
      With C1DataGrdList2.PrintInfo
        .PageHeader = LblProgName.Text & ": " & LblVersion.Text
        .Print()
      End With
    End If
  End If

End Sub
Private Sub BntShowPrtScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BntShowPrtScreen.Click

  PrtDialog.PrinterSettings = New Printing.PrinterSettings

  Dim result As DialogResult = PrtDialog.ShowDialog()

  If (result = Windows.Forms.DialogResult.OK) Then
    LblPrtScreen.Text = PrtDialog.PrinterSettings.PrinterName()
  End If
End Sub
End Class
