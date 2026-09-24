Public Class FrmSelInv

Inherits System.Windows.Forms.Form
Friend WrkBatchNo As Integer
Dim MyTXINV As TXINV.myData
Dim MyTSPBCH As TSPBCH.myData
Dim mytxinvla As TXINVLA.myData
Dim mytxinvlc As TXINVLC.MyData
Dim mytxinvls As TXINVLS.MyData
Dim mytxinvl8 As TXINVL8.MyData
Dim ds As DataSet = New DataSet
'General
Dim WrkAnd As String
Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbSName As System.Windows.Forms.RadioButton
Friend WithEvents BtnNext As System.Windows.Forms.Button
Friend WithEvents BtnFind As System.Windows.Forms.Button
Friend WithEvents RbReg As System.Windows.Forms.RadioButton
Friend WithEvents TxtPos As System.Windows.Forms.TextBox
Friend WithEvents RbLoc As System.Windows.Forms.RadioButton
Friend WithEvents RbName As System.Windows.Forms.RadioButton
Friend WithEvents TxtPosNo As System.Windows.Forms.TextBox
Friend WithEvents label1 As System.Windows.Forms.Label
Friend WithEvents LblSelYear As System.Windows.Forms.Label
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents LblTypes As System.Windows.Forms.Label
Friend WithEvents TbLeft As System.Windows.Forms.ToolBar
Friend WithEvents TBarSelYear As System.Windows.Forms.ToolBarButton
Friend WithEvents TbRight As System.Windows.Forms.ToolBar
Friend WithEvents TBarSelTypes As System.Windows.Forms.ToolBarButton
Dim WrkListNo As Integer
Dim WrkYear As Integer
Dim WrkType As String
Friend WithEvents LnkSusp As System.Windows.Forms.LinkLabel
Friend WithEvents TxtSusp As System.Windows.Forms.TextBox
Friend WithEvents TxtComment As System.Windows.Forms.TextBox
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Dim WrkOr As String

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
  Friend WithEvents TbMain As System.Windows.Forms.ToolBar
  Friend WithEvents TBarReturn As System.Windows.Forms.ToolBarButton
Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelInv))
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TbMain = New System.Windows.Forms.ToolBar()
    Me.TBarReturn = New System.Windows.Forms.ToolBarButton()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.groupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbSName = New System.Windows.Forms.RadioButton()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.RbReg = New System.Windows.Forms.RadioButton()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.RbLoc = New System.Windows.Forms.RadioButton()
    Me.RbName = New System.Windows.Forms.RadioButton()
    Me.TxtPosNo = New System.Windows.Forms.TextBox()
    Me.label1 = New System.Windows.Forms.Label()
    Me.LblSelYear = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.LblTypes = New System.Windows.Forms.Label()
    Me.TbLeft = New System.Windows.Forms.ToolBar()
    Me.TBarSelYear = New System.Windows.Forms.ToolBarButton()
    Me.TbRight = New System.Windows.Forms.ToolBar()
    Me.TBarSelTypes = New System.Windows.Forms.ToolBarButton()
    Me.LnkSusp = New System.Windows.Forms.LinkLabel()
    Me.TxtSusp = New System.Windows.Forms.TextBox()
    Me.TxtComment = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.groupBox1.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    Me.ImageList1.Images.SetKeyName(1, "")
    '
    'TbMain
    '
    Me.TbMain.Anchor = System.Windows.Forms.AnchorStyles.Bottom
    Me.TbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarReturn})
    Me.TbMain.ButtonSize = New System.Drawing.Size(150, 44)
    Me.TbMain.Dock = System.Windows.Forms.DockStyle.None
    Me.TbMain.DropDownArrows = True
    Me.TbMain.ImageList = Me.ImageList1
    Me.TbMain.Location = New System.Drawing.Point(12, 337)
    Me.TbMain.Name = "TbMain"
    Me.TbMain.ShowToolTips = True
    Me.TbMain.Size = New System.Drawing.Size(150, 50)
    Me.TbMain.TabIndex = 191
    '
    'TBarReturn
    '
    Me.TBarReturn.ImageIndex = 0
    Me.TBarReturn.Name = "TBarReturn"
    Me.TBarReturn.Text = "&Add selected accounts"
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColSelect = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AlternatingRows = True
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(8, 92)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    Me.C1DataGrdList.Size = New System.Drawing.Size(787, 236)
    Me.C1DataGrdList.TabIndex = 194
    '
    'groupBox1
    '
    Me.groupBox1.Controls.Add(Me.RbSName)
    Me.groupBox1.Controls.Add(Me.BtnNext)
    Me.groupBox1.Controls.Add(Me.BtnFind)
    Me.groupBox1.Controls.Add(Me.RbReg)
    Me.groupBox1.Controls.Add(Me.TxtPos)
    Me.groupBox1.Controls.Add(Me.RbLoc)
    Me.groupBox1.Controls.Add(Me.RbName)
    Me.groupBox1.Controls.Add(Me.TxtPosNo)
    Me.groupBox1.Controls.Add(Me.label1)
    Me.groupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.groupBox1.Location = New System.Drawing.Point(8, 12)
    Me.groupBox1.Name = "groupBox1"
    Me.groupBox1.Size = New System.Drawing.Size(398, 74)
    Me.groupBox1.TabIndex = 0
    Me.groupBox1.TabStop = False
    Me.groupBox1.Text = "Sort By"
    '
    'RbSName
    '
    Me.RbSName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSName.Location = New System.Drawing.Point(126, 32)
    Me.RbSName.Name = "RbSName"
    Me.RbSName.Size = New System.Drawing.Size(94, 16)
    Me.RbSName.TabIndex = 12
    Me.RbSName.Text = "S&econd Name"
    '
    'BtnNext
    '
    Me.BtnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnNext.Location = New System.Drawing.Point(344, 5)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(48, 24)
    Me.BtnNext.TabIndex = 3
    Me.BtnNext.TabStop = False
    Me.BtnNext.Text = "Ne&xt"
    '
    'BtnFind
    '
    Me.BtnFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFind.Location = New System.Drawing.Point(290, 4)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(48, 24)
    Me.BtnFind.TabIndex = 2
    Me.BtnFind.TabStop = False
    Me.BtnFind.Text = "&Find"
    '
    'RbReg
    '
    Me.RbReg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbReg.Location = New System.Drawing.Point(126, 47)
    Me.RbReg.Name = "RbReg"
    Me.RbReg.Size = New System.Drawing.Size(56, 17)
    Me.RbReg.TabIndex = 10
    Me.RbReg.Text = "&Reg #"
    '
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPos.Location = New System.Drawing.Point(112, 8)
    Me.TxtPos.MaxLength = 25
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(172, 20)
    Me.TxtPos.TabIndex = 4
    '
    'RbLoc
    '
    Me.RbLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbLoc.Location = New System.Drawing.Point(8, 47)
    Me.RbLoc.Name = "RbLoc"
    Me.RbLoc.Size = New System.Drawing.Size(112, 16)
    Me.RbLoc.TabIndex = 9
    Me.RbLoc.Text = "&Location#/Name"
    '
    'RbName
    '
    Me.RbName.Checked = True
    Me.RbName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbName.Location = New System.Drawing.Point(8, 32)
    Me.RbName.Name = "RbName"
    Me.RbName.Size = New System.Drawing.Size(98, 16)
    Me.RbName.TabIndex = 8
    Me.RbName.TabStop = True
    Me.RbName.Text = "O&wner's Name"
    '
    'TxtPosNo
    '
    Me.TxtPosNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPosNo.Location = New System.Drawing.Point(72, 8)
    Me.TxtPosNo.MaxLength = 7
    Me.TxtPosNo.Name = "TxtPosNo"
    Me.TxtPosNo.Size = New System.Drawing.Size(40, 20)
    Me.TxtPosNo.TabIndex = 3
    Me.TxtPosNo.Visible = False
    '
    'label1
    '
    Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label1.Location = New System.Drawing.Point(8, 16)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(64, 16)
    Me.label1.TabIndex = 3
    Me.label1.Text = "Position to"
    '
    'LblSelYear
    '
    Me.LblSelYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblSelYear.Location = New System.Drawing.Point(624, 49)
    Me.LblSelYear.Name = "LblSelYear"
    Me.LblSelYear.Size = New System.Drawing.Size(102, 18)
    Me.LblSelYear.TabIndex = 204
    Me.LblSelYear.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(627, 12)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(98, 20)
    Me.Label5.TabIndex = 203
    Me.Label5.Text = "Filter(s)"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'LblTypes
    '
    Me.LblTypes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTypes.Location = New System.Drawing.Point(624, 32)
    Me.LblTypes.Name = "LblTypes"
    Me.LblTypes.Size = New System.Drawing.Size(102, 18)
    Me.LblTypes.TabIndex = 202
    Me.LblTypes.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'TbLeft
    '
    Me.TbLeft.AutoSize = False
    Me.TbLeft.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarSelYear})
    Me.TbLeft.ButtonSize = New System.Drawing.Size(150, 22)
    Me.TbLeft.Dock = System.Windows.Forms.DockStyle.None
    Me.TbLeft.DropDownArrows = True
    Me.TbLeft.ImageList = Me.ImageList1
    Me.TbLeft.Location = New System.Drawing.Point(491, 342)
    Me.TbLeft.Name = "TbLeft"
    Me.TbLeft.ShowToolTips = True
    Me.TbLeft.Size = New System.Drawing.Size(104, 36)
    Me.TbLeft.TabIndex = 206
    Me.TbLeft.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
    Me.TbLeft.Wrappable = False
    '
    'TBarSelYear
    '
    Me.TBarSelYear.ImageIndex = 1
    Me.TBarSelYear.Name = "TBarSelYear"
    Me.TBarSelYear.Text = "Select Year"
    '
    'TbRight
    '
    Me.TbRight.AutoSize = False
    Me.TbRight.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarSelTypes})
    Me.TbRight.ButtonSize = New System.Drawing.Size(150, 22)
    Me.TbRight.Dock = System.Windows.Forms.DockStyle.None
    Me.TbRight.DropDownArrows = True
    Me.TbRight.ImageList = Me.ImageList1
    Me.TbRight.Location = New System.Drawing.Point(603, 342)
    Me.TbRight.Name = "TbRight"
    Me.TbRight.ShowToolTips = True
    Me.TbRight.Size = New System.Drawing.Size(104, 36)
    Me.TbRight.TabIndex = 205
    Me.TbRight.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
    Me.TbRight.Wrappable = False
    '
    'TBarSelTypes
    '
    Me.TBarSelTypes.ImageIndex = 1
    Me.TBarSelTypes.Name = "TBarSelTypes"
    Me.TBarSelTypes.Text = "Select Types"
    '
    'LnkSusp
    '
    Me.LnkSusp.Location = New System.Drawing.Point(180, 342)
    Me.LnkSusp.Name = "LnkSusp"
    Me.LnkSusp.Size = New System.Drawing.Size(89, 21)
    Me.LnkSusp.TabIndex = 241
    Me.LnkSusp.TabStop = True
    Me.LnkSusp.Text = "Suspense Code"
    '
    'TxtSusp
    '
    Me.TxtSusp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSusp.Location = New System.Drawing.Point(275, 341)
    Me.TxtSusp.MaxLength = 1
    Me.TxtSusp.Name = "TxtSusp"
    Me.TxtSusp.Size = New System.Drawing.Size(16, 20)
    Me.TxtSusp.TabIndex = 238
    Me.TxtSusp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtComment
    '
    Me.TxtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtComment.Location = New System.Drawing.Point(275, 367)
    Me.TxtComment.MaxLength = 20
    Me.TxtComment.Name = "TxtComment"
    Me.TxtComment.Size = New System.Drawing.Size(164, 20)
    Me.TxtComment.TabIndex = 239
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(180, 367)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(68, 16)
    Me.Label7.TabIndex = 240
    Me.Label7.Text = "Comment"
    Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'FrmSelInv
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(807, 390)
    Me.Controls.Add(Me.LnkSusp)
    Me.Controls.Add(Me.TxtSusp)
    Me.Controls.Add(Me.TxtComment)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TbLeft)
    Me.Controls.Add(Me.TbRight)
    Me.Controls.Add(Me.LblSelYear)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.LblTypes)
    Me.Controls.Add(Me.groupBox1)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.Controls.Add(Me.TbMain)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmSelInv"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select Accounts"
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.groupBox1.ResumeLayout(False)
    Me.groupBox1.PerformLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmSelInv_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
  mytxinvlc.CloseFile()
  mytxinvls.CloseFile()
  mytxinvl8.CloseFile()
  mytxinvla.CloseFile()
End Sub

  Private Sub FrmSelInvF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXINV = New TXINV.mydata(MyDBConnect)
    MyTSPBCH = New TSPBCH.mydata(MyDBConnect)
    mytxinvla = New TXINVLA.mydata(MyDBConnect)
    mytxinvlc = New TXINVLC.mydata(MyDBConnect)
    mytxinvls = New TXINVLS.mydata(MyDBConnect)
    mytxinvl8 = New TXINVL8.mydata(MyDBConnect)

    'MyFrmTX404.TBarPrint.Enabled = False
    'MyFrmTX404.TBarSettings.Enabled = False

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If
    If MyServer = "SQL" Then
      MyBlocking = False
    Else
      MyBlocking = True
    End If

    Call FormatGrid()

    If MySelTypes = "" Then
      LblTypes.Text = "* ALL Types *"
    Else
      LblTypes.Text = MySelTypes
    End If
    If MySelYear = 0 Then
      LblSelYear.Text = "* ALL Years *"
    Else
      LblSelYear.Text = "Year " & MySelYear
    End If
    End Sub
    Public Sub FormatGrid()

    Call ShowGrid()

    With C1DataGrdList
      .Rebind(True)
      .MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
      .Columns(0).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
      .Columns(0).ValueItems.Values.Clear()
      .Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(0, False)) ' unchecked
      .Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(1, True)) ' checked
      .Columns(0).ValueItems.Translate = True
      .Columns(0).Caption = "Sel"
      .Splits(0).DisplayColumns(0).Width = 25
      .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
     End With

    If RbName.Checked Then
      GridName()
    End If
    If RbSName.Checked Then
      GridSName()
    End If
    If RbLoc.Checked Then
      GridLocName()
    End If
    If RbReg.Checked Then
      GridRegno()
    End If

    End Sub
    Public Sub ShowGrid()
       Dim WrkQrySelect As String
    Dim WrkPosNo As String
    Dim WrkPos As String
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

       WrkQrySelect = ""
       If MySelYear <> 0 Then
         WrkQrySelect = "YEAR=" & MySelYear
       End If
      '----------------------------------
       If WrkQrySelect = "" Then
         WrkQrySelect = "BALD <> 0" & WrkAnd & "Icode<>'S'"
       Else
         WrkQrySelect = WrkQrySelect & WrkAnd & " BALD <> 0" & WrkAnd & "Icode<>'S'"
       End If
    '----------------------------------
    If MySelTypes <> "" Then
      If WrkQrySelect = "" Then
        WrkQrySelect = BuildSelectQryPC(WrkQrySelect, MySelTypes)
      End If
    End If
    WrkPos = Replace(TxtPos.Text, "'", "''")
    If MyQrySelect <> WrkQrySelect Then
         ResetFiles()
         MyQrySelect = WrkQrySelect
       End If
       If RbName.Checked Then
      ds = mytxinvl8.GetViewbyName(WrkPos, WrkListNo, WrkYear, WrkType, WrkQrySelect, MyGridMax, MyBlocking)
    End If
       If RbSName.Checked Then
      ds = mytxinvls.GetViewbySName(WrkPos, WrkListNo, WrkYear, WrkType, WrkQrySelect, MyGridMax, MyBlocking)
    End If
    If RbLoc.Checked Then
      WrkPosNo = TxtPosNo.Text
      Do While Len(WrkPosNo) < 7 'Left pad with blanks
        WrkPosNo = " " & WrkPosNo
      Loop
      ds = mytxinvla.GetViewbyLoc(WrkPos, WrkPosNo, WrkListNo, WrkYear, WrkType, WrkQrySelect, MyGridMax, MyBlocking)
    End If
    If RbReg.Checked Then
      ds = mytxinvlc.GetViewbyRegNo(WrkPos, WrkQrySelect, MyGridMax, MyBlocking)
    End If

      C1DataGrdList.DataSource = ds.Tables(0)
      C1DataGrdList.Refresh()
      Windows.Forms.Cursor.Current = Cursors.Default

    End Sub
  Private Sub GridName()
  Dim I As Integer

  With C1DataGrdList
    .Rebind(True)
    .Columns(1).Caption = "Name"
    .Splits(0).DisplayColumns(1).Width = 200
    .Columns(2).Caption = "Second Name"
    .Splits(0).DisplayColumns(2).Width = 125
    .Columns(3).Caption = "List#"
      .Splits(0).DisplayColumns(3).Width = 60
      .Columns(4).Caption = "Type"
    .Splits(0).DisplayColumns(4).Width = 30
    .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    .Columns(5).Caption = "Year"
    .Splits(0).DisplayColumns(5).Width = 32
    .Columns(6).Caption = "Amt Due"
    .Splits(0).DisplayColumns(6).Width = 65
    .Columns(7).Caption = "Amt Pd"
    .Splits(0).DisplayColumns(7).Width = 65
    .Columns(8).Caption = "Balance"
    .Splits(0).DisplayColumns(8).Width = 65
    .Columns(9).Caption = ""
    .Splits(0).DisplayColumns(9).Width = 20
    .Columns(10).ValueItems.Values.Clear()
    .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("B", "Back Tax"))
    .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("F", "Foreclose"))
    .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("I", "Inactive"))
    .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("M", "Mail Rtn"))
    .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("S", "Suspend"))
    .Columns(10).ValueItems.Translate = True
    .Columns(10).Caption = "Rec Cd"
    .Splits(0).DisplayColumns(10).Width = 60
    For I = 1 To 10
      .Splits(0).DisplayColumns(I).Locked = True
    Next
  End With

End Sub
  Private Sub GridSName()
  Dim I As Integer

  With C1DataGrdList
    .Rebind(True)
    .Columns(1).Caption = "Second Name"
    .Splits(0).DisplayColumns(1).Width = 200
    .Columns(2).Caption = "Name"
    .Splits(0).DisplayColumns(2).Width = 125
    .Columns(3).Caption = "List#"
      .Splits(0).DisplayColumns(3).Width = 60
      .Columns(4).Caption = "Type"
    .Splits(0).DisplayColumns(4).Width = 30
    .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    .Columns(5).Caption = "Year"
    .Splits(0).DisplayColumns(5).Width = 32
    .Columns(6).Caption = "Amt Due"
    .Splits(0).DisplayColumns(6).Width = 65
    .Columns(7).Caption = "Amt Pd"
    .Splits(0).DisplayColumns(7).Width = 65
    .Columns(8).Caption = "Balance"
    .Splits(0).DisplayColumns(8).Width = 65
    .Columns(9).Caption = ""
    .Splits(0).DisplayColumns(9).Width = 20
    .Columns(10).ValueItems.Values.Clear()
    .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("B", "Back Tax"))
    .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("F", "Foreclose"))
    .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("I", "Inactive"))
    .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("M", "Mail Rtn"))
    .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("S", "Suspend"))
    .Columns(10).ValueItems.Translate = True
    .Columns(10).Caption = "Rec Cd"
    .Splits(0).DisplayColumns(10).Width = 60
    For I = 1 To 10
      .Splits(0).DisplayColumns(I).Locked = True
    Next
  End With

End Sub
Private Sub GridLocName()
  Dim I As Integer

  With C1DataGrdList
    .Rebind(True)
    .Columns(1).Caption = "Loc #"
    .Splits(0).DisplayColumns(1).Width = 50
    .Columns(2).Caption = "Location"
    .Splits(0).DisplayColumns(2).Width = 150
    .Columns(3).Caption = "List #"
      .Splits(0).DisplayColumns(3).Width = 60
      .Columns(4).Caption = "Type"
    .Splits(0).DisplayColumns(4).Width = 40
    .Columns(5).Caption = "Year"
    .Splits(0).DisplayColumns(5).Width = 40
    .Columns(6).Caption = "Amt Due"
    .Splits(0).DisplayColumns(6).Width = 70
    .Columns(7).Caption = "Amt Pd"
    .Splits(0).DisplayColumns(7).Width = 70
    .Columns(8).Caption = "Balance"
    .Splits(0).DisplayColumns(8).Width = 70
    .Splits(0).DisplayColumns(9).Visible = False
    .Columns(10).ValueItems.Values.Clear()
    .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("B", "Back Tax"))
    .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("F", "Foreclose"))
    .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("I", "Inactive"))
    .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("M", "Mail Rtn"))
    .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("S", "Suspend"))
    .Columns(10).ValueItems.Translate = True
    .Columns(10).Caption = "Rec Cd"
    .Splits(0).DisplayColumns(10).Width = 60
     For I = 1 To 10
       .Splits(0).DisplayColumns(I).Locked = True
     Next
  End With

End Sub
Private Sub GridRegno()
  Dim I As Integer

  With C1DataGrdList
    .Rebind(True)
    .Columns(1).Caption = "Reg #"
    .Splits(0).DisplayColumns(1).Width = 60
    .Columns(2).Caption = "Name"
    .Splits(0).DisplayColumns(2).Width = 165
    .Columns(3).Caption = "List #"
      .Splits(0).DisplayColumns(3).Width = 60
      .Columns(4).Caption = "Type"
    .Splits(0).DisplayColumns(4).Width = 40
    .Columns(5).Caption = "Year"
    .Splits(0).DisplayColumns(5).Width = 40
    .Columns(6).Caption = "Amt Due"
    .Splits(0).DisplayColumns(6).Width = 70
    .Columns(7).Caption = "Amt Pd"
    .Splits(0).DisplayColumns(7).Width = 70
    .Columns(8).Caption = "Balance"
    .Splits(0).DisplayColumns(8).Width = 70
    .Splits(0).DisplayColumns(9).Visible = False
    .Columns(10).ValueItems.Values.Clear()
    .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("B", "Back Tax"))
    .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("F", "Foreclose"))
    .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("I", "Inactive"))
    .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("M", "Mail Rtn"))
    .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("S", "Suspend"))
    .Columns(10).ValueItems.Translate = True
    .Columns(10).Caption = "Rec Cd"
    .Splits(0).DisplayColumns(10).Width = 60
     For I = 1 To 10
       .Splits(0).DisplayColumns(I).Locked = True
     Next
  End With

End Sub
   Private Function BuildSelectTypes() As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim StrLen As Integer
    Dim I As Integer

    If MySelTypes = "" Then
      Return ""
    End If

    sbSelect = New System.Text.StringBuilder
    sbSelect.Append("TYPE=%Values(")
    StrLen = Len(MySelTypes)

    For I = 1 To StrLen
      WrkType = Mid(MySelTypes, I, 1)
      sbSelect.Append(Chr(34) & WrkType & Chr(34) & " ")
    Next

    sbSelect.Append(")")
    Return sbSelect.ToString
  End Function
  Private Function BuildSelectQryPC(ByVal WrkStrIn As String, ByVal WrkSelTypes As String) As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim WrkStrOut As String
    Dim StrLen As Integer
    Dim I As Integer

    WrkStrOut = ""
    If WrkSelTypes = "" Then
      Return ""
    End If

    StrLen = Len(WrkSelTypes)
    sbSelect = New System.Text.StringBuilder
    For I = 1 To StrLen
      If I > 1 Then
        sbSelect.Append(",")
      End If
      WrkType = Mid(WrkSelTypes, I, 1)
      sbSelect.Append(MyUtils.Quo(WrkType))
    Next
    If WrkStrIn = "" Then
      WrkStrOut = "TYPE IN(" & sbSelect.ToString & ")"
    Else
      WrkStrOut = WrkStrIn & WrkAnd & "TYPE IN(" & sbSelect.ToString & ")"
    End If
    sbSelect = Nothing
    Return WrkStrOut
  End Function
  Private Sub FrmSelInv_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX901.SbpScreen.Text = "SelInv"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    WrkListNo = 0
    WrkYear = 0
    WrkType = ""
    Call FormatGrid()
  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    If TxtPosNo.Visible Then
      TxtPosNo.Text = C1DataGrdList.Item(I, 1)
      TxtPos.Text = C1DataGrdList.Item(I, 2)
    Else
      TxtPos.Text = C1DataGrdList.Item(I, 1)
    End If

    WrkListNo = C1DataGrdList.Item(I, 3)
    WrkYear = C1DataGrdList.Item(I, 5)
    WrkType = C1DataGrdList.Item(I, 4)

    FormatGrid()
    TxtPos.Text = ""
    TxtPosNo.Text = ""
  End Sub

  Private Sub SelGridItems()

  Dim ListNo As Integer
  Dim Year As Integer
  Dim Type As String
  Dim I As Integer

  SetSResnTip()
  ErrProv.SetError(TxtSusp, "")
  If Mid(Ttp1.GetToolTip(TxtSusp), 1, 3) = "***" Then
    ErrProv.SetError(TxtSusp, "Invalid Suspense Code")
    Exit Sub
  End If

  Windows.Forms.Cursor.Current = Cursors.WaitCursor()
  For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
    If C1DataGrdList.Item(I, 0) = 1 Then
      ListNo = C1DataGrdList.Item(I, 3)
      Year = C1DataGrdList.Item(I, 5)
      Type = C1DataGrdList.Item(I, 4)
      MyTXINV.GetOneRecordP(ListNo, Year, Type)
      If MyTXINV._SUSDT > 0 Then
        MsgBox(ListNo & " " & Type & " " & Year, MsgBoxStyle.Information, "Already suspended")
        Continue For
      End If
      With MyTSPBCH
        .GetOneRecordP(WrkBatchNo, ListNo, Year, Type)
        If Not .RecordNotFound Then
          MsgBox(ListNo & " " & Type & " " & Year, MsgBoxStyle.Information, "Already in batch")
          Continue For
        End If
        ._BCHNO = WrkBatchNo
        ._LISTNo = ListNo
        ._TYPE = Type
        ._YEAR = Year
        ._DIST = MyTXINV._DIST
        ._COMM = TxtComment.Text
        ._SCD = TxtSusp.Text
        ._PDATE = 0
        ._NAME = MyTXINV._NAME
        ._TAXT = MyTXINV._BALD
        .AddOneRecordP()
      End With
    End If
  Next
  Me.Close()
End Sub
Private Sub CheckType(ByVal Type As String, ByRef Good As Boolean)
  Dim Pos As Integer
  Good = False

  Pos = InStr(MySelTypes, Type)
  If Pos > 0 Then Good = True
End Sub
  Private Sub FrmSelInv_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    Windows.Forms.Cursor.Current = Cursors.Default
    MyFrmTX901C.FormatGrid()
    MyFrmTX901C.Show()
    'Memory Cleanup
    'MyFrmTX404.TBarSettings.Enabled = True
    MyTXINV = Nothing
    MyFrmSelInv = Nothing
  End Sub
  Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
    If e.Button Is TBarReturn Then
      SelGridItems()
    End If
  End Sub
  Private Sub FrmSelInv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub

  If e.KeyCode = Keys.R Then
    SelGridItems()
    Me.Close()
  End If

  End Sub
Private Sub TxtList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtPos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPos.KeyPress
  If Asc(e.KeyChar) = Keys.Return Then
    Call FormatGrid()
  End If
End Sub
  Private Sub RbLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbLoc.Click
    TxtPosNo.Visible = True
    FormatGrid()
  End Sub
  Private Sub RbName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbName.Click
    TxtPosNo.Visible = False
    FormatGrid()
  End Sub
  Private Sub RbSName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbSName.Click
    TxtPosNo.Visible = False
    FormatGrid()
  End Sub
  Private Sub RbReg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbReg.Click
    TxtPosNo.Visible = False
    FormatGrid()
  End Sub
 Private Sub TbLeft_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbLeft.ButtonClick
    If e.Button Is TBarSelYear Then
      DoBtnSelYear()
      Exit Sub
    End If
End Sub
Private Sub TbRight_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbRight.ButtonClick
    If e.Button Is TBarSelTypes Then
      DoBtnSelTypes()
      Exit Sub
    End If
End Sub
  Private Sub DoBtnSelTypes()
    MyFrmSelTypes = New FrmSelTypes
    MyFrmSelTypes.ShowDialog()
    If MySelTypes = "" Then
      LblTypes.Text = "* ALL Types *"
    Else
      LblTypes.Text = MySelTypes
    End If
    FormatGrid()
  End Sub
  Private Sub DoBtnSelYear()
    MyFrmSelYear = New FrmSelYear
    MyFrmSelYear.ShowDialog()
    If MySelYear = 0 Then
      LblSelYear.Text = "* ALL Years *"
    Else
      LblSelYear.Text = "Year " & MySelYear
    End If
    FormatGrid()
  End Sub
Private Sub ResetFiles()
  mytxinvlc.CloseFile()
  mytxinvls.CloseFile()
  mytxinvl8.CloseFile()
  mytxinvla.CloseFile()
  mytxinvlc = Nothing
  mytxinvls = Nothing
  mytxinvl8 = Nothing
  mytxinvla = Nothing
  mytxinvlc = New TXINVLC.mydata(MyDBConnect)
  mytxinvls = New TXINVLS.mydata(MyDBConnect)
  mytxinvl8 = New TXINVL8.mydata(MyDBConnect)
  mytxinvla = New TXINVLA.mydata(MyDBConnect)
End Sub
Private Sub LnkSusp_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkSusp.LinkClicked
    MyFrmListSResn = New FrmListSResn
    MyFrmListSResn.MdiParent = Me.ParentForm
    MyFrmListSResn.WrkCode = TxtSusp.Text
    MyFrmListSResn.WrkScreen = "SelInv"
    MyFrmListSResn.Show()
End Sub
Private Sub TxtSusp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSusp.Leave
  SetSResnTip()
End Sub
Private Sub SetSResnTip()
    Dim WrkDesc As String

    WrkDesc = GetTXSResnDesc(TxtSusp.Text)
    Ttp1.SetToolTip(TxtSusp, WrkDesc)
End Sub

Private Sub TxtSusp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSusp.TextChanged

End Sub
End Class






