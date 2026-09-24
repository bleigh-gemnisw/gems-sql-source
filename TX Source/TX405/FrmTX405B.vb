Public Class FrmTX405B

  Inherits System.Windows.Forms.Form
  Dim myTXINV As TXINV.MyData
  Dim mytxinvla As TXINVLA.MyData
  Dim mytxinvlc As TXINVLC.MyData
  Dim mytxinvld As TXINVLD.MyData
  Dim mytxinvlm As TXINVLM.MyData
  Dim mytxinvln As TXINVLN.MyData
  Dim mytxinvls As TXINVLS.MyData
  Dim mytxinvlv As TXINVLV.MyData
  Dim mytxinvl8 As TXINVL8.MyData
  Dim ds As DataSet = New DataSet
  Dim WrkListNo As Integer
  Dim WrkYear As Integer
  Dim WrkReadForward As Boolean
  Dim WrkBlocking As Boolean
  Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtType As System.Windows.Forms.TextBox
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents BtnShow As System.Windows.Forms.Button
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents TxtList As System.Windows.Forms.TextBox
  Dim WrkType As String
  'General
  Dim WrkAnd As String
  Friend WithEvents LblSelYear As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents LblTypes As System.Windows.Forms.Label
  Friend WithEvents TbLeft As System.Windows.Forms.ToolBar
  Friend WithEvents TBarSelYear As System.Windows.Forms.ToolBarButton
  Friend WithEvents TbRight As System.Windows.Forms.ToolBar
  Friend WithEvents TBarSelTypes As System.Windows.Forms.ToolBarButton
  Friend WithEvents TbProcess As System.Windows.Forms.ToolBar
  Friend WithEvents TBarProcess As System.Windows.Forms.ToolBarButton
  Friend WithEvents groupBox1 As GroupBox
  Friend WithEvents CboSort As ComboBox
  Friend WithEvents DtPckDOB As DateTimePicker
  Friend WithEvents BtnNext As Button
  Friend WithEvents BtnFind As Button
  Friend WithEvents TxtPos As TextBox
  Friend WithEvents TxtPosNo As TextBox
  Dim WrkOr As String
  Friend WithEvents Label1 As Label
  Friend WithEvents CboBal As ComboBox
  Const CMaxRecs As Integer = 100


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
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTX405B))
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.groupBox2 = New System.Windows.Forms.GroupBox()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.BtnShow = New System.Windows.Forms.Button()
    Me.label2 = New System.Windows.Forms.Label()
    Me.TxtList = New System.Windows.Forms.TextBox()
    Me.LblSelYear = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.LblTypes = New System.Windows.Forms.Label()
    Me.TbLeft = New System.Windows.Forms.ToolBar()
    Me.TBarSelYear = New System.Windows.Forms.ToolBarButton()
    Me.TbRight = New System.Windows.Forms.ToolBar()
    Me.TBarSelTypes = New System.Windows.Forms.ToolBarButton()
    Me.TbProcess = New System.Windows.Forms.ToolBar()
    Me.TBarProcess = New System.Windows.Forms.ToolBarButton()
    Me.groupBox1 = New System.Windows.Forms.GroupBox()
    Me.CboSort = New System.Windows.Forms.ComboBox()
    Me.DtPckDOB = New System.Windows.Forms.DateTimePicker()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.TxtPosNo = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.CboBal = New System.Windows.Forms.ComboBox()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.groupBox2.SuspendLayout()
    Me.groupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColMove = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AllowUpdateOnBlur = False
    Me.C1DataGrdList.AlternatingRows = True
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(12, 66)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.MeasurementDevice = C1.Win.C1TrueDBGrid.PrintInfo.MeasurementDeviceEnum.Screen
    Me.C1DataGrdList.PrintInfo.MeasurementPrinterName = Nothing
    Me.C1DataGrdList.Size = New System.Drawing.Size(799, 310)
    Me.C1DataGrdList.TabIndex = 8
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    Me.ImageList1.Images.SetKeyName(1, "select type_24.png")
    '
    'groupBox2
    '
    Me.groupBox2.Controls.Add(Me.TxtType)
    Me.groupBox2.Controls.Add(Me.TxtYear)
    Me.groupBox2.Controls.Add(Me.BtnShow)
    Me.groupBox2.Controls.Add(Me.label2)
    Me.groupBox2.Controls.Add(Me.TxtList)
    Me.groupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.groupBox2.Location = New System.Drawing.Point(12, 8)
    Me.groupBox2.Name = "groupBox2"
    Me.groupBox2.Size = New System.Drawing.Size(190, 52)
    Me.groupBox2.TabIndex = 0
    Me.groupBox2.TabStop = False
    Me.groupBox2.Text = "Fast Path"
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtType.Location = New System.Drawing.Point(75, 30)
    Me.TxtType.MaxLength = 1
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(16, 20)
    Me.TxtType.TabIndex = 1
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(91, 30)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtYear.TabIndex = 2
    '
    'BtnShow
    '
    Me.BtnShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnShow.Location = New System.Drawing.Point(132, 15)
    Me.BtnShow.Name = "BtnShow"
    Me.BtnShow.Size = New System.Drawing.Size(43, 24)
    Me.BtnShow.TabIndex = 7
    Me.BtnShow.TabStop = False
    Me.BtnShow.Text = "&Show"
    '
    'label2
    '
    Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label2.Location = New System.Drawing.Point(5, 14)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(92, 16)
    Me.label2.TabIndex = 6
    Me.label2.Text = "List #/Type/Year"
    '
    'TxtList
    '
    Me.TxtList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtList.Location = New System.Drawing.Point(8, 30)
    Me.TxtList.MaxLength = 12
    Me.TxtList.Name = "TxtList"
    Me.TxtList.Size = New System.Drawing.Size(67, 20)
    Me.TxtList.TabIndex = 0
    '
    'LblSelYear
    '
    Me.LblSelYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblSelYear.Location = New System.Drawing.Point(637, 40)
    Me.LblSelYear.Name = "LblSelYear"
    Me.LblSelYear.Size = New System.Drawing.Size(102, 18)
    Me.LblSelYear.TabIndex = 201
    Me.LblSelYear.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(674, 8)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(40, 13)
    Me.Label5.TabIndex = 200
    Me.Label5.Text = "Filter(s)"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'LblTypes
    '
    Me.LblTypes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTypes.Location = New System.Drawing.Point(637, 23)
    Me.LblTypes.Name = "LblTypes"
    Me.LblTypes.Size = New System.Drawing.Size(102, 18)
    Me.LblTypes.TabIndex = 199
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
    Me.TbLeft.Location = New System.Drawing.Point(472, 382)
    Me.TbLeft.Name = "TbLeft"
    Me.TbLeft.ShowToolTips = True
    Me.TbLeft.Size = New System.Drawing.Size(104, 36)
    Me.TbLeft.TabIndex = 203
    Me.TbLeft.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
    Me.TbLeft.Wrappable = False
    '
    'TBarSelYear
    '
    Me.TBarSelYear.ImageIndex = 1
    Me.TBarSelYear.Name = "TBarSelYear"
    Me.TBarSelYear.Text = "Select Years"
    '
    'TbRight
    '
    Me.TbRight.AutoSize = False
    Me.TbRight.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarSelTypes})
    Me.TbRight.ButtonSize = New System.Drawing.Size(150, 22)
    Me.TbRight.Dock = System.Windows.Forms.DockStyle.None
    Me.TbRight.DropDownArrows = True
    Me.TbRight.ImageList = Me.ImageList1
    Me.TbRight.Location = New System.Drawing.Point(584, 382)
    Me.TbRight.Name = "TbRight"
    Me.TbRight.ShowToolTips = True
    Me.TbRight.Size = New System.Drawing.Size(104, 36)
    Me.TbRight.TabIndex = 202
    Me.TbRight.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
    Me.TbRight.Wrappable = False
    '
    'TBarSelTypes
    '
    Me.TBarSelTypes.ImageIndex = 1
    Me.TBarSelTypes.Name = "TBarSelTypes"
    Me.TBarSelTypes.Text = "Select Types"
    '
    'TbProcess
    '
    Me.TbProcess.AutoSize = False
    Me.TbProcess.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarProcess})
    Me.TbProcess.ButtonSize = New System.Drawing.Size(150, 22)
    Me.TbProcess.Dock = System.Windows.Forms.DockStyle.None
    Me.TbProcess.DropDownArrows = True
    Me.TbProcess.ImageList = Me.ImageList1
    Me.TbProcess.Location = New System.Drawing.Point(12, 382)
    Me.TbProcess.Name = "TbProcess"
    Me.TbProcess.ShowToolTips = True
    Me.TbProcess.Size = New System.Drawing.Size(165, 36)
    Me.TbProcess.TabIndex = 205
    Me.TbProcess.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
    Me.TbProcess.Wrappable = False
    '
    'TBarProcess
    '
    Me.TBarProcess.ImageIndex = 0
    Me.TBarProcess.Name = "TBarProcess"
    Me.TBarProcess.Text = "Process Selected Items"
    '
    'groupBox1
    '
    Me.groupBox1.Controls.Add(Me.CboSort)
    Me.groupBox1.Controls.Add(Me.DtPckDOB)
    Me.groupBox1.Controls.Add(Me.BtnNext)
    Me.groupBox1.Controls.Add(Me.BtnFind)
    Me.groupBox1.Controls.Add(Me.TxtPos)
    Me.groupBox1.Controls.Add(Me.TxtPosNo)
    Me.groupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.groupBox1.Location = New System.Drawing.Point(208, 6)
    Me.groupBox1.Name = "groupBox1"
    Me.groupBox1.Size = New System.Drawing.Size(423, 52)
    Me.groupBox1.TabIndex = 206
    Me.groupBox1.TabStop = False
    Me.groupBox1.Text = "Sort By"
    '
    'CboSort
    '
    Me.CboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.CboSort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CboSort.FormattingEnabled = True
    Me.CboSort.Location = New System.Drawing.Point(6, 14)
    Me.CboSort.Name = "CboSort"
    Me.CboSort.Size = New System.Drawing.Size(95, 21)
    Me.CboSort.TabIndex = 0
    '
    'DtPckDOB
    '
    Me.DtPckDOB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckDOB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckDOB.Location = New System.Drawing.Point(208, 15)
    Me.DtPckDOB.Name = "DtPckDOB"
    Me.DtPckDOB.Size = New System.Drawing.Size(96, 20)
    Me.DtPckDOB.TabIndex = 3
    '
    'BtnNext
    '
    Me.BtnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnNext.Location = New System.Drawing.Point(360, 15)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(48, 24)
    Me.BtnNext.TabIndex = 5
    Me.BtnNext.TabStop = False
    Me.BtnNext.Text = "Ne&xt"
    '
    'BtnFind
    '
    Me.BtnFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFind.Location = New System.Drawing.Point(310, 15)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(44, 24)
    Me.BtnFind.TabIndex = 4
    Me.BtnFind.TabStop = False
    Me.BtnFind.Text = "&Find"
    '
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPos.Location = New System.Drawing.Point(147, 15)
    Me.TxtPos.MaxLength = 25
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(157, 20)
    Me.TxtPos.TabIndex = 2
    '
    'TxtPosNo
    '
    Me.TxtPosNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPosNo.Location = New System.Drawing.Point(107, 15)
    Me.TxtPosNo.MaxLength = 7
    Me.TxtPosNo.Name = "TxtPosNo"
    Me.TxtPosNo.Size = New System.Drawing.Size(40, 20)
    Me.TxtPosNo.TabIndex = 1
    Me.TxtPosNo.Visible = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(295, 391)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(54, 13)
    Me.Label1.TabIndex = 208
    Me.Label1.Text = "Balances:"
    '
    'CboBal
    '
    Me.CboBal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.CboBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CboBal.FormattingEnabled = True
    Me.CboBal.Location = New System.Drawing.Point(355, 388)
    Me.CboBal.Name = "CboBal"
    Me.CboBal.Size = New System.Drawing.Size(111, 21)
    Me.CboBal.TabIndex = 207
    '
    'FrmTX405B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(823, 421)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.CboBal)
    Me.Controls.Add(Me.groupBox1)
    Me.Controls.Add(Me.TbProcess)
    Me.Controls.Add(Me.TbLeft)
    Me.Controls.Add(Me.TbRight)
    Me.Controls.Add(Me.LblSelYear)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.LblTypes)
    Me.Controls.Add(Me.groupBox2)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX405B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select"
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.groupBox2.ResumeLayout(False)
    Me.groupBox2.PerformLayout()
    Me.groupBox1.ResumeLayout(False)
    Me.groupBox1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTX405B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXINV = New TXINV.MyData(myDBConnect)
    mytxinvla = New TXINVLA.MyData(myDBConnect)
    mytxinvlc = New TXINVLC.MyData(myDBConnect)
    mytxinvld = New TXINVLD.MyData(myDBConnect)
    mytxinvlm = New TXINVLM.MyData(myDBConnect)
    mytxinvln = New TXINVLN.MyData(myDBConnect)
    mytxinvls = New TXINVLS.MyData(myDBConnect)
    mytxinvlv = New TXINVLV.MyData(myDBConnect)
    mytxinvl8 = New TXINVL8.MyData(myDBConnect)

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If
    If MyServer = "SQL" Then
      WrkBlocking = False
    Else
      WrkBlocking = True
    End If
    WrkReadForward = True
    CboSort.Items.Add("Owner's Name")
    CboSort.Items.Add("Second Name")
    CboSort.Items.Add("Location")
    CboSort.Items.Add("Reg #")
    CboSort.Items.Add("VIN")
    CboSort.Items.Add("CustID Primary")
    CboSort.Items.Add("CustID Secondary")
    CboSort.Items.Add("DOB")
    CboSort.SelectedItem = "Owner's Name"

    CboBal.Items.Add("All")
    CboBal.Items.Add("Balance Due")
    CboBal.Items.Add("Credit Balance")
    CboBal.Items.Add("Not Equal to Zero")
    CboBal.SelectedItem = "All"

    MyFrmTX405.TBarAttach.Enabled = False
    MyFrmTX405.TBarDelete.Enabled = False
    Call FormatGrid(True, True)

    If MySelTypes = "" Then
      LblTypes.Text = "* ALL Types *"
    Else
      LblTypes.Text = MySelTypes
    End If
    If MySelFromYear = 0 Then
      LblSelYear.Text = "* ALL Years *"
    Else
      If MySelToYear = 0 Then
        LblSelYear.Text = "Year " & MySelFromYear
      Else
        LblSelYear.Text = "Years " & MySelFromYear & " - " & MySelToYear
      End If
    End If
    If CboSort.SelectedItem.ToString = "Location" Then
      TxtPosNo.Focus()
    Else
      TxtPos.Focus()
    End If
    DtPckDOB.Visible = False
  End Sub
  Public Sub FormatGrid(ByVal WrkFind As Boolean, ByVal WrkNext As Boolean)
    Dim I As Integer

    Call ShowGrid()
    With C1DataGrdList
      .Rebind(True)
      .FetchRowStyles = True
      .AlternatingRows = False
      .MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
      .Columns(0).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
      .Columns(0).ValueItems.Values.Clear()
      .Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(0, False)) ' unchecked
      .Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(1, True)) ' checked
      .Columns(0).ValueItems.Translate = True
      .Columns(0).Caption = "Sel"
      .Splits(0).DisplayColumns(0).Width = 25
      .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      For I = 1 To 10
        .Splits(0).DisplayColumns(I).Locked = True
      Next
    End With

    Select Case CboSort.SelectedItem.ToString
      Case "CustID Primary"
        GridCustID(WrkNext)
      Case "CustID Secondary"
        GridCustID(WrkNext)
      Case "DOB"
        GridDOB(WrkNext)
      Case "Location"
        GridLocName(WrkNext)
      Case "Owner's Name"
        GridName(WrkNext)
      Case "Reg #"
        GridRegno(WrkNext)
      Case "Second Name"
        GridSName(WrkNext)
      Case "VIN"
        GridVIN(WrkNext)
    End Select

    RefreshDS()
    TxtList.Focus()
  End Sub
  Public Sub ShowGrid()
    Dim WrkQrySelect As String
    Dim WrkPos As String
    Dim WrkPosNo As String
    Dim WrkDOB As Integer

    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    mytxinvl8.CloseFile()
    mytxinvla.CloseFile()
    mytxinvlc.CloseFile()
    mytxinvld.CloseFile()
    mytxinvlm.CloseFile()
    mytxinvln.CloseFile()
    mytxinvls.CloseFile()
    mytxinvlv.CloseFile()

    WrkQrySelect = ""
    WrkPos = Replace(TxtPos.Text, "'", "''")

    If MySelFromYear <> 0 Then
      If MySelToYear = 0 Then
        WrkQrySelect = "YEAR=" & MySelFromYear
      Else
        WrkQrySelect = "YEAR>=" & MySelFromYear & WrkAnd & "YEAR<=" & MySelToYear
      End If
    End If
    '----------------------------------
    If CboBal.Items.Count > 0 Then
      Select Case CboBal.SelectedItem.ToString
        Case "Credit Balance"
          If WrkQrySelect = "" Then
            WrkQrySelect = "BALD < 0"
          Else
            WrkQrySelect = WrkQrySelect & WrkAnd & " BALD < 0"
          End If
        Case "Not Equal to Zero"
          If WrkQrySelect = "" Then
            WrkQrySelect = "BALD <> 0"
          Else
            WrkQrySelect = WrkQrySelect & WrkAnd & " BALD <> 0"
          End If
        Case "Balance Due"
          If WrkQrySelect = "" Then
            WrkQrySelect = "BALD > 0"
          Else
            WrkQrySelect = WrkQrySelect & WrkAnd & " BALD > 0"
          End If
        Case Else
      End Select
    End If
    '----------------------------------
    If MySelTypes <> "" Then
      WrkQrySelect = BuildSelectQryPC(WrkQrySelect, MySelTypes)
    End If

    If WrkQrySelect = "" Then ResetFiles()
    ds.Clear()
    ds = Nothing

    Select Case CboSort.SelectedItem.ToString
      Case "CustID Primary"
        ds = mytxinvlm.GetViewbySSNo(MyUtils.CnvSng(WrkPos), WrkQrySelect, CMaxRecs, WrkBlocking)
      Case "CustID Secondary"
        ds = mytxinvln.GetViewbySS2(MyUtils.CnvSng(WrkPos), WrkQrySelect, CMaxRecs, WrkBlocking)
      Case "DOB"
        If myDBConnect.ServerName <> "DB2" And WrkPos = String.Empty Then
          WrkPos = "!"
        End If
        WrkDOB = MyUtils.SetDBDate(DtPckDOB.Value)
        ds = mytxinvld.GetViewbyDOB(WrkDOB, WrkQrySelect, CMaxRecs, WrkBlocking)
      Case "Location"
        WrkPosNo = TxtPosNo.Text
        Do While Len(WrkPosNo) < 7 'Left pad with blanks
          WrkPosNo = " " & WrkPosNo
        Loop
        ds = mytxinvla.GetViewbyLoc(WrkPos, WrkPosNo, WrkListNo, WrkYear, WrkType, WrkQrySelect, CMaxRecs, WrkBlocking)
      Case "Owner's Name"
        ds = mytxinvl8.GetViewbyName(WrkPos, WrkListNo, WrkYear, WrkType, WrkQrySelect, CMaxRecs, WrkBlocking)
      Case "Reg #"
        If myDBConnect.ServerName <> "DB2" And WrkPos = String.Empty Then
          WrkPos = "!"
        End If
        ds = mytxinvlc.GetViewbyRegNo(WrkPos, WrkQrySelect, CMaxRecs, WrkBlocking)
      Case "Second Name"
        ds = mytxinvls.GetViewbySName(WrkPos, WrkListNo, WrkYear, WrkType, WrkQrySelect, CMaxRecs, WrkBlocking)
      Case "VIN"
        If myDBConnect.ServerName <> "DB2" And WrkPos = String.Empty Then
          WrkPos = "!"
        End If
        ds = mytxinvlv.GetViewbyVIN(WrkPos, WrkQrySelect, CMaxRecs, WrkBlocking)
    End Select
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()
    Windows.Forms.Cursor.Current = Cursors.Default


  End Sub
  Private Sub RefreshDS()
  End Sub
  Private Sub GridDOB(ByVal WrkNext As Boolean)
    With C1DataGrdList
      .Rebind(True)
      If WrkNext Then
        .Columns(1).Caption = "DOB"
        .Columns(1).NumberFormat = "##/##/####"
      Else
        .Columns(1).Caption = "DOB (Reverse order)"
        .Columns(1).NumberFormat = "##/##/####"
      End If
      .Splits(0).DisplayColumns(1).Width = 65
      .Columns(2).Caption = "Name"
      .Splits(0).DisplayColumns(2).Width = 165
      .Columns(3).Caption = "List #"
      .Splits(0).DisplayColumns(3).Width = 55
      .Columns(4).Caption = "Type"
      .Splits(0).DisplayColumns(4).Width = 35
      .Columns(5).Caption = "Year"
      .Splits(0).DisplayColumns(5).Width = 35
      .Columns(6).Caption = "Amt Due"
      .Splits(0).DisplayColumns(6).Width = 70
      .Columns(7).Caption = "Amt Pd"
      .Splits(0).DisplayColumns(7).Width = 70
      .Columns(8).Caption = "Balance"
      .Splits(0).DisplayColumns(8).Width = 70
      .Columns(9).Caption = ""
      .Splits(0).DisplayColumns(9).Width = 15
      .Splits(0).DisplayColumns(9).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      .Columns(10).ValueItems.Values.Clear()
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("B", "Back Tax"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("D", "Deferred"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("F", "Foreclose"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("I", "Inactive"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("M", "Mail Rtn"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("S", "Suspend"))
      .Columns(10).ValueItems.Translate = True
      .Columns(10).Caption = "Rec Cd"
      .Splits(0).DisplayColumns(10).Width = 60
    End With

  End Sub
  Private Sub GridLocName(ByVal WrkNext As Boolean)
    With C1DataGrdList
      .Rebind(True)
      .Columns(1).Caption = "Loc #"
      .Splits(0).DisplayColumns(1).Width = 50
      If WrkNext Then
        .Columns(2).Caption = "Location"
      Else
        .Columns(2).Caption = "Location (Reverse order)"
      End If
      .Splits(0).DisplayColumns(2).Width = 150
      .Columns(3).Caption = "List #"
      .Splits(0).DisplayColumns(3).Width = 55
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
      .Columns(9).Caption = ""
      .Splits(0).DisplayColumns(9).Width = 15
      .Splits(0).DisplayColumns(9).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      .Columns(10).ValueItems.Values.Clear()
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("B", "Back Tax"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("D", "Deferred"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("F", "Foreclose"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("I", "Inactive"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("M", "Mail Rtn"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("S", "Suspend"))
      .Columns(10).ValueItems.Translate = True
      .Columns(10).Caption = "Rec Cd"
      .Splits(0).DisplayColumns(10).Width = 60
    End With

  End Sub
  Private Sub GridCustID(ByVal WrkNext As Boolean)
    With C1DataGrdList
      .Rebind(True)
      If WrkNext Then
        .Columns(1).Caption = "CustID"
      Else
        .Columns(1).Caption = "CustID (Reverse order)"
      End If
      .Splits(0).DisplayColumns(1).Width = 70
      .Columns(2).Caption = "Name"
      .Splits(0).DisplayColumns(2).Width = 200
      .Columns(3).Caption = "List #"
      .Splits(0).DisplayColumns(3).Width = 55
      .Columns(4).Caption = "Type"
      .Splits(0).DisplayColumns(4).Width = 35
      .Columns(5).Caption = "Year"
      .Splits(0).DisplayColumns(5).Width = 35
      .Columns(6).Caption = "Amt Due"
      .Splits(0).DisplayColumns(6).Width = 70
      .Columns(7).Caption = "Amt Pd"
      .Splits(0).DisplayColumns(7).Width = 70
      .Columns(8).Caption = "Balance"
      .Splits(0).DisplayColumns(8).Width = 70
      .Columns(9).Caption = ""
      .Splits(0).DisplayColumns(9).Width = 15
      .Splits(0).DisplayColumns(9).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      .Columns(10).ValueItems.Values.Clear()
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("B", "Back Tax"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("D", "Deferred"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("F", "Foreclose"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("I", "Inactive"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("M", "Mail Rtn"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("S", "Suspend"))
      .Columns(10).ValueItems.Translate = True
      .Columns(10).Caption = "Rec Cd"
      .Splits(0).DisplayColumns(10).Width = 60
    End With

  End Sub
  Private Sub GridName(ByVal WrkNext As Boolean)
    Dim I As Integer
    With C1DataGrdList
      .Rebind(True)
      For I = 1 To 10
        .Splits(0).DisplayColumns(I).Locked = True
      Next
      If WrkNext Then
        .Columns(1).Caption = "Name"
      Else
        .Columns(1).Caption = "Name (Reverse order)"
      End If
      .Splits(0).DisplayColumns(1).Width = 200
      .Columns(2).Caption = "Second Name"
      .Splits(0).DisplayColumns(2).Width = 145
      .Columns(3).Caption = "List#"
      .Splits(0).DisplayColumns(3).Width = 55
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
      .Splits(0).DisplayColumns(9).Width = 15
      .Splits(0).DisplayColumns(9).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      .Columns(10).ValueItems.Values.Clear()
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("B", "Back Tax"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("D", "Deferred"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("F", "Foreclose"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("I", "Inactive"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("M", "Mail Rtn"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("S", "Suspend"))
      .Columns(10).ValueItems.Translate = True
      .Columns(10).Caption = "Rec Cd"
      .Splits(0).DisplayColumns(10).Width = 60
    End With

  End Sub
  Private Sub GridSName(ByVal WrkNext As Boolean)
    Dim I As Integer
    With C1DataGrdList
      .Rebind(True)
      For I = 1 To 10
        .Splits(0).DisplayColumns(I).Locked = True
      Next
      If WrkNext Then
        .Columns(1).Caption = "Second Name"
      Else
        .Columns(1).Caption = "Second Name (Reverse order)"
      End If
      .Splits(0).DisplayColumns(1).Width = 200
      .Columns(2).Caption = "Name"
      .Splits(0).DisplayColumns(2).Width = 145
      .Columns(3).Caption = "List#"
      .Splits(0).DisplayColumns(3).Width = 55
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
      .Splits(0).DisplayColumns(9).Width = 15
      .Splits(0).DisplayColumns(9).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      .Columns(10).ValueItems.Values.Clear()
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("B", "Back Tax"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("D", "Deferred"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("F", "Foreclose"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("I", "Inactive"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("M", "Mail Rtn"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("S", "Suspend"))
      .Columns(10).ValueItems.Translate = True
      .Columns(10).Caption = "Rec Cd"
      .Splits(0).DisplayColumns(10).Width = 60
    End With

  End Sub
  Private Sub GridRegno(ByVal WrkNext As Boolean)
    With C1DataGrdList
      .Rebind(True)
      If WrkNext Then
        .Columns(1).Caption = "Reg #"
      Else
        .Columns(1).Caption = "Reg # (Reverse order)"
      End If
      .Splits(0).DisplayColumns(1).Width = 70
      .Columns(2).Caption = "Name"
      .Splits(0).DisplayColumns(2).Width = 165
      .Columns(3).Caption = "List #"
      .Splits(0).DisplayColumns(3).Width = 55
      .Columns(4).Caption = "Type"
      .Splits(0).DisplayColumns(4).Width = 35
      .Columns(5).Caption = "Year"
      .Splits(0).DisplayColumns(5).Width = 35
      .Columns(6).Caption = "Amt Due"
      .Splits(0).DisplayColumns(6).Width = 70
      .Columns(7).Caption = "Amt Pd"
      .Splits(0).DisplayColumns(7).Width = 70
      .Columns(8).Caption = "Balance"
      .Splits(0).DisplayColumns(8).Width = 70
      .Columns(9).Caption = ""
      .Splits(0).DisplayColumns(9).Width = 15
      .Splits(0).DisplayColumns(9).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      .Columns(10).ValueItems.Values.Clear()
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("B", "Back Tax"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("D", "Deferred"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("F", "Foreclose"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("I", "Inactive"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("M", "Mail Rtn"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("S", "Suspend"))
      .Columns(10).ValueItems.Translate = True
      .Columns(10).Caption = "Rec Cd"
      .Splits(0).DisplayColumns(10).Width = 60
    End With

  End Sub
  Private Sub GridVIN(ByVal WrkNext As Boolean)
    With C1DataGrdList
      .Rebind(True)
      If WrkNext Then
        .Columns(1).Caption = "VIN"
      Else
        .Columns(1).Caption = "VIN (Reverse order)"
      End If
      .Splits(0).DisplayColumns(1).Width = 130
      .Columns(2).Caption = "Name"
      .Splits(0).DisplayColumns(2).Width = 165
      .Columns(3).Caption = "List #"
      .Splits(0).DisplayColumns(3).Width = 55
      .Columns(4).Caption = "Type"
      .Splits(0).DisplayColumns(4).Width = 35
      .Columns(5).Caption = "Year"
      .Splits(0).DisplayColumns(5).Width = 35
      .Columns(6).Caption = "Amt Due"
      .Splits(0).DisplayColumns(6).Width = 70
      .Columns(7).Caption = "Amt Pd"
      .Splits(0).DisplayColumns(7).Width = 70
      .Columns(8).Caption = "Balance"
      .Splits(0).DisplayColumns(8).Width = 70
      .Columns(9).Caption = ""
      .Splits(0).DisplayColumns(9).Width = 15
      .Splits(0).DisplayColumns(9).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      .Columns(10).ValueItems.Values.Clear()
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("B", "Back Tax"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("D", "Deferred"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("F", "Foreclose"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("I", "Inactive"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("M", "Mail Rtn"))
      .Columns(10).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("S", "Suspend"))
      .Columns(10).ValueItems.Translate = True
      .Columns(10).Caption = "Rec Cd"
      .Splits(0).DisplayColumns(10).Width = 60
    End With

  End Sub
  Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
    If TxtYear.Text <> "" Then
      ShowFastPath()
    Else
      GetListNoRecords()
    End If
  End Sub
  Private Sub CboSort_SelectedValueChanged(sender As Object, e As EventArgs) Handles CboSort.SelectedValueChanged

    Select Case CboSort.SelectedItem.ToString
      Case "DOB"
        TxtPosNo.Visible = False
        TxtPos.Visible = False
        DtPckDOB.Visible = True
        FormatGrid(True, True)
        DtPckDOB.Focus()
      Case "Location"
        TxtPosNo.Visible = True
        TxtPos.Visible = True
        DtPckDOB.Visible = False
        FormatGrid(True, True)
        TxtPosNo.Focus()
      Case Else
        TxtPosNo.Visible = False
        TxtPos.Visible = True
        DtPckDOB.Visible = False
        FormatGrid(True, True)
        TxtPos.Focus()
    End Select
  End Sub
  Private Sub FrmTX405B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX405.SbpScreen.Text = "TX405B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    WrkReadForward = True
    WrkListNo = 0
    WrkYear = 0
    WrkType = ""
    Call FormatGrid(True, True)
    If CboSort.SelectedItem.ToString = "Location" Then
      TxtPosNo.Focus()
    Else
      TxtPos.Focus()
    End If
  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    ShowGridNext()
  End Sub
  Public Sub ShowGridNext()
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    If TxtPosNo.Visible Then
      TxtPosNo.Text = Trim(C1DataGrdList.Item(I, 1))
      TxtPos.Text = Trim(C1DataGrdList.Item(I, 2))
    Else
      TxtPos.Text = Trim(C1DataGrdList.Item(I, 1))
    End If
    WrkListNo = C1DataGrdList.Item(I, 3)
    WrkType = C1DataGrdList.Item(I, 4)
    WrkYear = C1DataGrdList.Item(I, 5)
    FormatGrid(False, True)
  End Sub
  Public Sub ShowGridPrev()
  End Sub
  Private Sub RbBalances_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Call FormatGrid(True, True)
  End Sub
  Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Dim WrkAcct As String
    WrkAcct = C1DataGrdList.Item(C1DataGrdList.Row, 5) & C1DataGrdList.Item(C1DataGrdList.Row, 4) & C1DataGrdList.Item(C1DataGrdList.Row, 3)
    SelGridItems(WrkAcct)
    ProcessScreen(False)
  End Sub
  Private Sub ShowFastPath()
    Dim WrkAcct As String
    If MyUtils.CnvSng(TxtList.Text) = 0 Then Exit Sub
    If TxtType.Text = "" Then Exit Sub
    If MyUtils.CnvSng(TxtYear.Text) = 0 Then Exit Sub

    myTXINV.GetOneRecordP(MyUtils.CnvSng(TxtList.Text), MyUtils.CnvSng(TxtYear.Text), TxtType.Text)
    If myTXINV.RecordNotFound Then
      MsgBox("List/Year/Type not found", MsgBoxStyle.Exclamation, "Fast Path information is not valid")
      Exit Sub
    End If

    CboSort.SelectedItem = "Owner's Name"
    With myTXINV
      TxtPos.Text = Trim(._NAME)
    End With
    FormatGrid(True, True)

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    TxtList.Focus()

    WrkAcct = TxtYear.Text & TxtType.Text & TxtList.Text
    ClearSelAcct()
    SelAcct(0) = WrkAcct
    MyFrmTX405B.ProcessScreen(False)
    TxtList.Text = ""
    TxtType.Text = ""
    TxtYear.Text = ""
    Windows.Forms.Cursor.Current = Cursors.Default
    Me.Hide()

  End Sub
  Sub GetListNoRecords()
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim myDr As Data.DataRow
    Dim I As Integer

    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("WSel", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Sname", Type.GetType("System.String"))
      .Columns.Add("List#", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Wamtd", Type.GetType("System.Decimal"))
      .Columns.Add("Wamtp", Type.GetType("System.Decimal"))
      .Columns.Add("Wbal", Type.GetType("System.Decimal"))
      .Columns.Add("Wupost", Type.GetType("System.String"))
      .Columns.Add("Icode", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

    ds2 = myTXINV.GetAllListNo(Val(TxtList.Text))
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      If TxtType.Text = ds2.Tables(0).Rows(I).Item("type") Then
        myDr = ds.Tables(0).NewRow
        myDr("WSel") = 0
        myDr("List#") = Val(TxtList.Text)
        myDr("Type") = ds2.Tables(0).Rows(I).Item("type")
        myDr("Year") = ds2.Tables(0).Rows(I).Item("year")
        With myTXINV
          .GetOneRecordP(Val(TxtList.Text), myDr("year"), myDr("type"))
          If Not .RecordNotFound Then
            myDr("Name") = Trim(._NAME)
            myDr("Sname") = Trim(._SNAME)
            If ._CCNO > 0 Then
              myDr("Wamtd") = ._CCETAX
            Else
              myDr("Wamtd") = ._TAXT
            End If
            myDr("Wamtp") = ._PAYREC + ._NEWPAY
            myDr("Wbal") = ._BALD - ._NEWPAY
            If ._NEWPAY = 0 Then
              myDr("Wupost") = ""
            Else
              myDr("Wupost") = "*"
            End If
            myDr("icode") = Trim(._ICODE)
            ds.Tables(0).Rows.Add(myDr)
          End If
        End With
      End If
    Next

    With C1DataGrdList
      .DataSource = ds.Tables(0)
      .Rebind(True)
      .FetchRowStyles = True
      .AlternatingRows = False
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

    CboSort.SelectedItem = "Owner's Name"
    GridName(True)
    TxtList.Text = ""
    TxtType.Text = ""
    TxtList.Focus()

  End Sub
  Private Sub TxtList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtList.KeyPress
    Dim WrkBarCode As String
    Dim WrkLen As Integer

    If Asc(e.KeyChar) = Keys.Return Then
      WrkBarCode = TxtList.Text
      'Check for Bar code entry
      If TxtList.Text.ToLower <> TxtList.Text.ToUpper Then
        WrkLen = Len(Trim(TxtList.Text))
        If WrkLen >= 6 Then
          TxtList.Text = Mid(WrkBarCode, 1, WrkLen - 5)
          TxtType.Text = Mid(WrkBarCode, WrkLen - 4, 1)
          TxtYear.Text = Mid(WrkBarCode, WrkLen - 3, 4)
          ShowFastPath()
        End If
      Else 'Bar Code
        MyUtils.KeyEnter_isTab(Me, e)
      End If
    End If
  End Sub
  Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      ShowFastPath()
      Exit Sub
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtList_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtList.GotFocus
    MyUtils.ShowFocus(Me.ActiveControl)
  End Sub
  Private Sub TxtType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtType.GotFocus
    MyUtils.ShowFocus(Me.ActiveControl)
  End Sub
  Private Sub TxtYear_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtYear.GotFocus
    MyUtils.ShowFocus(Me.ActiveControl)
  End Sub
  Private Sub TxtPosNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    MyUtils.ShowFocus(Me.ActiveControl)
  End Sub
  Private Sub TxtPos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    MyUtils.ShowFocus(Me.ActiveControl)
  End Sub
  Private Sub TxtType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtType.KeyPress
    'Move to next field after anything has been typed since it's only 1 char allowed
    Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
  End Sub
  Private Sub TxtPos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPos.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      WrkReadForward = True
      WrkListNo = 0
      WrkYear = 0
      WrkType = ""
      Call FormatGrid(True, True)
      If CboSort.SelectedItem.ToString = "Location" Then
        TxtPosNo.Focus()
      Else
        TxtPos.Focus()
      End If
    End If
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
    FormatGrid(True, True)
  End Sub
  Private Sub DoBtnSelYear()
    MyFrmSelYear = New FrmSelYear
    MyFrmSelYear.ShowDialog()
    If MySelFromYear = 0 Then
      LblSelYear.Text = "* ALL Years *"
    Else
      If MySelToYear = 0 Then
        LblSelYear.Text = "Year " & MySelFromYear
      Else
        LblSelYear.Text = "Years " & MySelFromYear & " - " & MySelToYear
      End If
    End If
    FormatGrid(True, True)
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
  Private Sub ResetFiles()
  End Sub
  Private Sub SelGridItems(ByVal WrkAcct As String)

    Dim I As Integer
    Dim J As Integer

    Array.Clear(SelAcct, 0, cMax)

    If WrkAcct <> "" Then
      SelAcct(0) = WrkAcct
      Exit Sub
    End If

    J = 0
    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
      If C1DataGrdList.Item(I, 0) = 1 Then
        SelAcct(J) = C1DataGrdList.Item(I, 5) & C1DataGrdList.Item(I, 4) & C1DataGrdList.Item(I, 3)
        J = J + 1
      End If
    Next

    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Public Sub ProcessScreen(ByVal AddMode As Boolean)
    MyFrmTX405C = New FrmTX405C
    MyFrmTX405C.MdiParent = Me.ParentForm
    MyFrmTX405C.AddMode = AddMode
    MyFrmTX405C.Show()
    Me.Hide()
  End Sub
  Private Sub TbProcess_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles TbProcess.ButtonClick
    If e.Button Is TBarProcess Then
      SelGridItems("")
      If SelAcct(0) <> "" Then
        ProcessScreen(False)
      End If
    End If
  End Sub
  Private Sub CboBal_SelectedValueChanged(sender As Object, e As EventArgs) Handles CboBal.SelectedValueChanged
    FormatGrid(True, True)
    If CboSort.SelectedItem.ToString = "Location" Then
      TxtPosNo.Focus()
    Else
      TxtPos.Focus()
    End If
  End Sub
End Class
