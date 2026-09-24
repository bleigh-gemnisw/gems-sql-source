Imports System.Collections.Generic

Public Class FrmTXA094
  Inherits System.Windows.Forms.Form
  Dim mytxbatchl1 As TXBATCHL1.MyData
  Dim myTXINV As TXINV.MyData
  Dim mytxinvla As TXINVLA.MyData
  Dim mytxinvlc As TXINVLC.MyData
  Dim mytxinvld As TXINVLD.MyData
  Dim mytxinvlm As TXINVLM.MyData
  Dim mytxinvln As TXINVLN.MyData
  Dim mytxinvls As TXINVLS.MyData
  Dim mytxinvlv As TXINVLV.myData
  Dim mytxinvl8 As TXINVL8.myData
  Dim ds As DataSet = New DataSet
  Dim WrkListNo As Integer
  Dim WrkYear As Integer
  Dim WrkType As String
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents LblTypes As System.Windows.Forms.Label
  Friend WithEvents TbRight As System.Windows.Forms.ToolBar
  Dim WrkReadForward As Boolean
  'General
  Dim WrkAnd As String
  Friend WithEvents TBarSelTypes As System.Windows.Forms.ToolBarButton
  Friend WithEvents TbLeft As System.Windows.Forms.ToolBar
  Friend WithEvents TBarSelYear As System.Windows.Forms.ToolBarButton
  Friend WithEvents LblSelYear As System.Windows.Forms.Label
  Dim WrkBlocking As Boolean
  Friend WithEvents DtPckDOB As System.Windows.Forms.DateTimePicker
  Friend WithEvents BtnTotal As System.Windows.Forms.Button
  Friend WithEvents BtnPayCredit As System.Windows.Forms.Button
  Friend WithEvents CboSort As System.Windows.Forms.ComboBox
  Const WrkMaxRecs As Integer = 50
  Friend WithEvents CboBal As ComboBox
  Friend WithEvents Label1 As Label
  Friend WithEvents BtnScan As Button
  Dim WrkOr As String
  Dim WrkBalanceOnly As Boolean

  Private InitialLoad As Boolean = True  ' added 6/2/25   t obypas callign formatgrid so many times to start
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
  Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents TxtType As System.Windows.Forms.TextBox
  Friend WithEvents TxtList As System.Windows.Forms.TextBox
  Friend WithEvents TxtPos As System.Windows.Forms.TextBox
  Friend WithEvents BtnShow As System.Windows.Forms.Button
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents TxtPosNo As System.Windows.Forms.TextBox
  Friend WithEvents BtnNext As System.Windows.Forms.Button
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTXA094))
    Me.groupBox2 = New System.Windows.Forms.GroupBox()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.BtnShow = New System.Windows.Forms.Button()
    Me.label2 = New System.Windows.Forms.Label()
    Me.TxtList = New System.Windows.Forms.TextBox()
    Me.groupBox1 = New System.Windows.Forms.GroupBox()
    Me.BtnScan = New System.Windows.Forms.Button()
    Me.CboSort = New System.Windows.Forms.ComboBox()
    Me.DtPckDOB = New System.Windows.Forms.DateTimePicker()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.TxtPosNo = New System.Windows.Forms.TextBox()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.Label5 = New System.Windows.Forms.Label()
    Me.LblTypes = New System.Windows.Forms.Label()
    Me.TbRight = New System.Windows.Forms.ToolBar()
    Me.TBarSelTypes = New System.Windows.Forms.ToolBarButton()
    Me.TbLeft = New System.Windows.Forms.ToolBar()
    Me.TBarSelYear = New System.Windows.Forms.ToolBarButton()
    Me.LblSelYear = New System.Windows.Forms.Label()
    Me.BtnTotal = New System.Windows.Forms.Button()
    Me.BtnPayCredit = New System.Windows.Forms.Button()
    Me.CboBal = New System.Windows.Forms.ComboBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.groupBox2.SuspendLayout()
    Me.groupBox1.SuspendLayout()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'groupBox2
    '
    Me.groupBox2.Controls.Add(Me.TxtType)
    Me.groupBox2.Controls.Add(Me.TxtYear)
    Me.groupBox2.Controls.Add(Me.BtnShow)
    Me.groupBox2.Controls.Add(Me.label2)
    Me.groupBox2.Controls.Add(Me.TxtList)
    Me.groupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.groupBox2.Location = New System.Drawing.Point(8, 0)
    Me.groupBox2.Name = "groupBox2"
    Me.groupBox2.Size = New System.Drawing.Size(173, 52)
    Me.groupBox2.TabIndex = 0
    Me.groupBox2.TabStop = False
    Me.groupBox2.Text = "Fast Path"
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtType.Location = New System.Drawing.Point(64, 30)
    Me.TxtType.MaxLength = 1
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(16, 20)
    Me.TxtType.TabIndex = 1
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(80, 30)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtYear.TabIndex = 2
    '
    'BtnShow
    '
    Me.BtnShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnShow.Location = New System.Drawing.Point(122, 14)
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
    Me.TxtList.Size = New System.Drawing.Size(56, 20)
    Me.TxtList.TabIndex = 0
    '
    'groupBox1
    '
    Me.groupBox1.Controls.Add(Me.BtnScan)
    Me.groupBox1.Controls.Add(Me.CboSort)
    Me.groupBox1.Controls.Add(Me.DtPckDOB)
    Me.groupBox1.Controls.Add(Me.BtnNext)
    Me.groupBox1.Controls.Add(Me.BtnFind)
    Me.groupBox1.Controls.Add(Me.TxtPos)
    Me.groupBox1.Controls.Add(Me.TxtPosNo)
    Me.groupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.groupBox1.Location = New System.Drawing.Point(187, 0)
    Me.groupBox1.Name = "groupBox1"
    Me.groupBox1.Size = New System.Drawing.Size(440, 52)
    Me.groupBox1.TabIndex = 5
    Me.groupBox1.TabStop = False
    Me.groupBox1.Text = "Sort By"
    '
    'BtnScan
    '
    Me.BtnScan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnScan.Location = New System.Drawing.Point(381, 15)
    Me.BtnScan.Name = "BtnScan"
    Me.BtnScan.Size = New System.Drawing.Size(53, 24)
    Me.BtnScan.TabIndex = 198
    Me.BtnScan.Text = "S&can"
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
    Me.DtPckDOB.Location = New System.Drawing.Point(179, 15)
    Me.DtPckDOB.Name = "DtPckDOB"
    Me.DtPckDOB.Size = New System.Drawing.Size(96, 20)
    Me.DtPckDOB.TabIndex = 3
    '
    'BtnNext
    '
    Me.BtnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnNext.Location = New System.Drawing.Point(331, 15)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(48, 24)
    Me.BtnNext.TabIndex = 5
    Me.BtnNext.TabStop = False
    Me.BtnNext.Text = "Ne&xt"
    '
    'BtnFind
    '
    Me.BtnFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFind.Location = New System.Drawing.Point(283, 15)
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
    Me.TxtPos.Size = New System.Drawing.Size(128, 20)
    Me.TxtPos.TabIndex = 2
    Me.Ttp1.SetToolTip(Me.TxtPos, "Double click to clear")
    '
    'TxtPosNo
    '
    Me.TxtPosNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPosNo.Location = New System.Drawing.Point(107, 15)
    Me.TxtPosNo.MaxLength = 7
    Me.TxtPosNo.Name = "TxtPosNo"
    Me.TxtPosNo.Size = New System.Drawing.Size(40, 20)
    Me.TxtPosNo.TabIndex = 1
    Me.Ttp1.SetToolTip(Me.TxtPosNo, "Double click to clear")
    Me.TxtPosNo.Visible = False
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColMove = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AlternatingRows = True
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(8, 56)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.MeasurementDevice = C1.Win.C1TrueDBGrid.PrintInfo.MeasurementDeviceEnum.Screen
    Me.C1DataGrdList.PrintInfo.MeasurementPrinterName = Nothing
    Me.C1DataGrdList.RowHeight = 16
    Me.C1DataGrdList.Size = New System.Drawing.Size(794, 328)
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
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(641, 0)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(98, 20)
    Me.Label5.TabIndex = 195
    Me.Label5.Text = "Filter(s)"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'LblTypes
    '
    Me.LblTypes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTypes.Location = New System.Drawing.Point(638, 20)
    Me.LblTypes.Name = "LblTypes"
    Me.LblTypes.Size = New System.Drawing.Size(102, 18)
    Me.LblTypes.TabIndex = 194
    Me.LblTypes.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'TbRight
    '
    Me.TbRight.AutoSize = False
    Me.TbRight.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarSelTypes})
    Me.TbRight.ButtonSize = New System.Drawing.Size(150, 22)
    Me.TbRight.Dock = System.Windows.Forms.DockStyle.None
    Me.TbRight.DropDownArrows = True
    Me.TbRight.ImageList = Me.ImageList1
    Me.TbRight.Location = New System.Drawing.Point(635, 384)
    Me.TbRight.Name = "TbRight"
    Me.TbRight.ShowToolTips = True
    Me.TbRight.Size = New System.Drawing.Size(104, 36)
    Me.TbRight.TabIndex = 196
    Me.TbRight.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
    Me.TbRight.Wrappable = False
    '
    'TBarSelTypes
    '
    Me.TBarSelTypes.ImageIndex = 1
    Me.TBarSelTypes.Name = "TBarSelTypes"
    Me.TBarSelTypes.Text = "Select Types"
    '
    'TbLeft
    '
    Me.TbLeft.AutoSize = False
    Me.TbLeft.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBarSelYear})
    Me.TbLeft.ButtonSize = New System.Drawing.Size(150, 22)
    Me.TbLeft.Dock = System.Windows.Forms.DockStyle.None
    Me.TbLeft.DropDownArrows = True
    Me.TbLeft.ImageList = Me.ImageList1
    Me.TbLeft.Location = New System.Drawing.Point(523, 384)
    Me.TbLeft.Name = "TbLeft"
    Me.TbLeft.ShowToolTips = True
    Me.TbLeft.Size = New System.Drawing.Size(104, 36)
    Me.TbLeft.TabIndex = 197
    Me.TbLeft.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
    Me.TbLeft.Wrappable = False
    '
    'TBarSelYear
    '
    Me.TBarSelYear.ImageIndex = 1
    Me.TBarSelYear.Name = "TBarSelYear"
    Me.TBarSelYear.Text = "Select Years"
    '
    'LblSelYear
    '
    Me.LblSelYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblSelYear.Location = New System.Drawing.Point(638, 37)
    Me.LblSelYear.Name = "LblSelYear"
    Me.LblSelYear.Size = New System.Drawing.Size(102, 18)
    Me.LblSelYear.TabIndex = 198
    Me.LblSelYear.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'BtnTotal
    '
    Me.BtnTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTotal.Location = New System.Drawing.Point(8, 384)
    Me.BtnTotal.Name = "BtnTotal"
    Me.BtnTotal.Size = New System.Drawing.Size(79, 36)
    Me.BtnTotal.TabIndex = 200
    Me.BtnTotal.TabStop = False
    Me.BtnTotal.Text = "Total Items"
    '
    'BtnPayCredit
    '
    Me.BtnPayCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnPayCredit.Location = New System.Drawing.Point(94, 383)
    Me.BtnPayCredit.Name = "BtnPayCredit"
    Me.BtnPayCredit.Size = New System.Drawing.Size(79, 36)
    Me.BtnPayCredit.TabIndex = 202
    Me.BtnPayCredit.TabStop = False
    Me.BtnPayCredit.Text = "Pay Credit (Web)"
    '
    'CboBal
    '
    Me.CboBal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.CboBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CboBal.FormattingEnabled = True
    Me.CboBal.Location = New System.Drawing.Point(405, 391)
    Me.CboBal.Name = "CboBal"
    Me.CboBal.Size = New System.Drawing.Size(109, 21)
    Me.CboBal.TabIndex = 203
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(345, 396)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(54, 13)
    Me.Label1.TabIndex = 204
    Me.Label1.Text = "Balances:"
    '
    'FrmTXA094
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(813, 419)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.CboBal)
    Me.Controls.Add(Me.BtnPayCredit)
    Me.Controls.Add(Me.BtnTotal)
    Me.Controls.Add(Me.LblSelYear)
    Me.Controls.Add(Me.TbLeft)
    Me.Controls.Add(Me.TbRight)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.LblTypes)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.Controls.Add(Me.groupBox2)
    Me.Controls.Add(Me.groupBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA094"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Collections - Select"
    Me.groupBox2.ResumeLayout(False)
    Me.groupBox2.PerformLayout()
    Me.groupBox1.ResumeLayout(False)
    Me.groupBox1.PerformLayout()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTXA094_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    ' mytxbatchl1 = New TXBATCHL1.MyData(myDBConnect)
    ' myTXINV = New TXINV.MyData(myDBConnect)
    'mytxinvla = New TXINVLA.MyData(myDBConnect)
    'mytxinvlc = New TXINVLC.MyData(myDBConnect)
    'mytxinvld = New TXINVLD.MyData(myDBConnect)
    'mytxinvlm = New TXINVLM.MyData(myDBConnect)
    'mytxinvln = New TXINVLN.MyData(myDBConnect)
    'mytxinvls = New TXINVLS.MyData(myDBConnect)
    'mytxinvlv = New TXINVLV.MyData(myDBConnect)
    'mytxinvl8 = New TXINVL8.MyData(myDBConnect)


    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If
    WrkBlocking = False
    CboSort.Items.Add("Owner's Name")
    CboSort.Items.Add("Second Name")
    CboSort.Items.Add("Both Names")
    CboSort.Items.Add("Location")
    CboSort.Items.Add("Reg #")
    CboSort.Items.Add("VIN")
    CboSort.Items.Add("CustID Primary")
    CboSort.Items.Add("CustID Secondary")
    CboSort.Items.Add("Both CustID")
    CboSort.Items.Add("DOB")
    CboSort.SelectedItem = "Owner's Name"
    MyScanOnly = False

    CboBal.Items.Add("All")
    CboBal.Items.Add("Balance Due")
    CboBal.Items.Add("Credit Balance")
    CboBal.Items.Add("Not Equal to Zero")
    CboBal.SelectedItem = "All"
    Application.DoEvents()

    If MyInquiryMode Then
      MyFrmTXA09.Text = "Cash Register:  ** Inquiry **"
    Else
      MyFrmTXA09.Text = "Cash Register:  " & "Batch - " & MyBatchNo
    End If
    WrkReadForward = True
    Call FormatGrid(True, True, False)
    If Not MyInquiryMode Then
      MyFrmTXA09.TBarSettings.Enabled = False
    End If
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
    If MyPublicUser Then
      CboSort.Items.Remove("Reg #")
      CboSort.Items.Remove("VIN")
    End If
    If Not MyPayCredit Or MyInquiryMode Then
      BtnPayCredit.Visible = False
    End If
    If CboSort.SelectedItem.ToString = "Location" Then
      TxtPosNo.Focus()
    Else
      TxtPos.Focus()
    End If
    DtPckDOB.Visible = False

  End Sub
  '------------------------------------------------------------------------------------
  ' 6/2/25 centralizing these  to try and control since most may not be used at times
  Private Sub EnsureFileReady(ByVal name As String)
    Select Case name
      Case "TXINV"
        If myTXINV Is Nothing Then myTXINV = New TXINV.MyData(myDBConnect)
      Case "TXBATCHL1"
        If mytxbatchl1 Is Nothing Then mytxbatchl1 = New TXBATCHL1.MyData(myDBConnect)
      Case "TXINVLA"
        If mytxinvla Is Nothing Then mytxinvla = New TXINVLA.MyData(myDBConnect)
      Case "TXINVLC"
        If mytxinvlc Is Nothing Then mytxinvlc = New TXINVLC.MyData(myDBConnect)
      Case "TXINVLD"
        If mytxinvld Is Nothing Then mytxinvld = New TXINVLD.MyData(myDBConnect)
      Case "TXINVLM"
        If mytxinvlm Is Nothing Then mytxinvlm = New TXINVLM.MyData(myDBConnect)
      Case "TXINVLN"
        If mytxinvln Is Nothing Then mytxinvln = New TXINVLN.MyData(myDBConnect)
      Case "TXINVLS"
        If mytxinvls Is Nothing Then mytxinvls = New TXINVLS.MyData(myDBConnect)
      Case "TXINVLV"
        If mytxinvlv Is Nothing Then mytxinvlv = New TXINVLV.MyData(myDBConnect)
      Case "TXINVL8"
        If mytxinvl8 Is Nothing Then mytxinvl8 = New TXINVL8.MyData(myDBConnect)
    End Select
  End Sub


  '------------------------------------------------------------------------------------
  Public Sub FormatGrid(ByVal WrkFind As Boolean, ByVal WrkNext As Boolean, ByVal WrkScan As Boolean)
    If InitialLoad = False Then   'added 6/2/25 so it doesnt launch so many times on start up

      Call ShowGrid(WrkScan)
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
      End With

      Select Case CboSort.SelectedItem.ToString
        Case "CustID Primary", "CustID Secondary", "Both CustID"
          GridCustID(WrkNext)
        Case "DOB"
          GridDOB(WrkNext)
        Case "Location"
          GridLocName(WrkNext)
        Case "Owner's Name", "Both Names"
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
    Else
      InitialLoad = False   'added 6/2/25 so it doesnt launch so many times on start up
    End If
  End Sub
  Public Sub ShowGrid(ByVal WrkScan As Boolean)
    Dim WrkQrySelect As String
    Dim WrkPos As String
    Dim WrkPosNo As String
    Dim WrkDOB As Integer

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    '------ -   stopped closefile on all of these
    'mytxinvl8.CloseFile()
    'mytxinvla.CloseFile()
    'mytxinvlc.CloseFile()
    'mytxinvld.CloseFile()
    'mytxinvlm.CloseFile()
    'mytxinvln.CloseFile()
    'mytxinvls.CloseFile()
    'mytxinvlv.CloseFile()


    WrkQrySelect = ""
    WrkPos = TxtPos.Text
    WrkPos = Replace(WrkPos, "'", "''")

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

    If Not WrkScan Then
      Select Case CboSort.SelectedItem.ToString
        Case "CustID Primary"
          EnsureFileReady("TXINVLM")
          ds = mytxinvlm.GetViewbySSNo(MyUtils.CnvSng(WrkPos), WrkQrySelect, WrkMaxRecs, WrkBlocking)
        Case "CustID Secondary"
          EnsureFileReady("TXINVLN")
          ds = mytxinvln.GetViewbySS2(MyUtils.CnvSng(WrkPos), WrkQrySelect, WrkMaxRecs, WrkBlocking)
        Case "DOB"
          If myDBConnect.ServerName <> "DB2" And WrkPos = String.Empty Then
            WrkPos = "!"
          End If
          WrkDOB = MyUtils.SetDBDate(DtPckDOB.Value)
          EnsureFileReady("TXINVLD")
          ds = mytxinvld.GetViewbyDOB(WrkDOB, WrkQrySelect, WrkMaxRecs, WrkBlocking)
        Case "Location"
          WrkPosNo = TxtPosNo.Text
          Do While Len(WrkPosNo) < 7 'Left pad with blanks
            WrkPosNo = " " & WrkPosNo
          Loop
          EnsureFileReady("TXINVLA")
          ds = mytxinvla.GetViewbyLoc(WrkPos, WrkPosNo, WrkListNo, WrkYear, WrkType, WrkQrySelect, WrkMaxRecs, WrkBlocking)
        Case "Owner's Name"
          EnsureFileReady("TXINVL8")
          ds = mytxinvl8.GetViewbyName(WrkPos, WrkListNo, WrkYear, WrkType, WrkQrySelect, WrkMaxRecs, WrkBlocking)
        Case "Reg #"
          If myDBConnect.ServerName <> "DB2" And WrkPos = String.Empty Then
            WrkPos = "!"
          End If
          EnsureFileReady("TXINVLC")
          ds = mytxinvlc.GetViewbyRegNo(WrkPos, WrkQrySelect, WrkMaxRecs, WrkBlocking)
        Case "Second Name"
          EnsureFileReady("TXINVLS")
          ds = mytxinvls.GetViewbySName(WrkPos, WrkListNo, WrkYear, WrkType, WrkQrySelect, WrkMaxRecs, WrkBlocking)
        Case "VIN"
          If myDBConnect.ServerName <> "DB2" And WrkPos = String.Empty Then
            WrkPos = "!"
          End If
          EnsureFileReady("TXINVLV")
          ds = mytxinvlv.GetViewbyVIN(WrkPos, WrkQrySelect, WrkMaxRecs, WrkBlocking)
      End Select
    Else
      Select Case CboSort.SelectedItem.ToString
        Case "Location"
          WrkPosNo = TxtPosNo.Text
          Do While Len(WrkPosNo) < 7 'Left pad with blanks
            WrkPosNo = " " & WrkPosNo
          Loop
          EnsureFileReady("TXINVLA")
          ds = mytxinvla.GetViewbyLocScan(WrkPos, WrkPosNo, WrkListNo, WrkYear, WrkType, WrkQrySelect, WrkMaxRecs, WrkBlocking)
        Case "Owner's Name"
          EnsureFileReady("TXINVL8")
          ds = mytxinvl8.GetViewbyNameScan(WrkPos, WrkListNo, WrkYear, WrkType, WrkQrySelect, WrkMaxRecs, WrkBlocking)
        Case "Both Names"
          EnsureFileReady("TXINVL8")
          ds = mytxinvl8.GetViewbyNamesScan(WrkPos, WrkListNo, WrkYear, WrkType, WrkQrySelect, WrkMaxRecs, WrkBlocking)
        Case "Reg #"
          EnsureFileReady("TXINVLC")
          ds = mytxinvlc.GetViewbyRegNoScan(WrkPos, WrkQrySelect, WrkMaxRecs, WrkBlocking)
        Case "Second Name"
          EnsureFileReady("TXINVLS")
          ds = mytxinvls.GetViewbySNameScan(WrkPos, WrkListNo, WrkYear, WrkType, WrkQrySelect, WrkMaxRecs, WrkBlocking)
        Case "VIN"
          EnsureFileReady("TXINVLV")
          ds = mytxinvlv.GetViewbyVINScan(WrkPos, WrkQrySelect, WrkMaxRecs, WrkBlocking)
        Case "Both CustID"
          EnsureFileReady("TXINVLM")
          ds = mytxinvlm.GetViewbySSNosScan(MyUtils.CnvSng(WrkPos), WrkQrySelect, WrkMaxRecs, WrkBlocking)
      End Select
    End If
    C1DataGrdList.DataSource = ds.Tables(0)

    '============
    'If WrkBalanceOnly = True Then
    ''Dim dv As New DataView(ds.Tables(0))

    ' Apply the filter to the DataView where the 9th column (index 8) has values greater than 0
    'dv'.RowFilter = "WBal > 0"

    ' Bind the filtered DataView to the DataGridView
    'C1DataGrdList.DataSource = dv
    'End If
    '===============

    C1DataGrdList.Refresh()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Public Sub ShowGridNext()
    Dim I As Integer
    If ds.Tables(0).Rows.Count = 0 Then
      Exit Sub
    End If
    I = ds.Tables(0).Rows.Count - 1
    If TxtPosNo.Visible Then
      TxtPosNo.Text = Trim(C1DataGrdList.Item(I, 1))
      TxtPos.Text = Trim(C1DataGrdList.Item(I, 2))
    Else
      TxtPos.Text = Trim(C1DataGrdList.Item(I, 1))
    End If
    WrkListNo = MyUtils.CnvSng(C1DataGrdList.Item(I, 3))
    WrkType = C1DataGrdList.Item(I, 4)
    WrkYear = MyUtils.CnvSng(C1DataGrdList.Item(I, 5))
    FormatGrid(False, True, False)
  End Sub
  Private Sub GridDOB(ByVal WrkNext As Boolean)
    Dim I As Integer
    With C1DataGrdList
      .Rebind(True)
      For I = 1 To 10
        .Splits(0).DisplayColumns(I).Locked = True
      Next
      .Columns(1).Caption = "DOB"
      .Columns(1).NumberFormat = "##/##/####"
      .Splits(0).DisplayColumns(1).Width = 65
      .Columns(2).Caption = "Name"
      .Splits(0).DisplayColumns(2).Width = 165
      .Columns(3).Caption = "List #"
      .Splits(0).DisplayColumns(3).Width = 55
      .Columns(4).Caption = "Type"
      .Splits(0).DisplayColumns(4).Width = 35
      .Columns(5).Caption = "Year"
      .Splits(0).DisplayColumns(5).Width = 35
      .Columns(6).Caption = "Prin Due"
      .Splits(0).DisplayColumns(6).Width = 70
      .Columns(7).Caption = "Amt Pd"
      .Splits(0).DisplayColumns(7).Width = 70
      .Columns(8).Caption = "Balance"
      .Splits(0).DisplayColumns(8).Width = 70
      .Columns(9).Caption = ""
      .Splits(0).DisplayColumns(9).Width = 20
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
    Dim I As Integer
    With C1DataGrdList
      .Rebind(True)
      For I = 1 To 10
        .Splits(0).DisplayColumns(I).Locked = True
      Next
      .Columns(1).Caption = "Loc #"
      .Splits(0).DisplayColumns(1).Width = 50
      .Columns(2).Caption = "Location"
      .Splits(0).DisplayColumns(2).Width = 150
      .Columns(3).Caption = "List #"
      .Splits(0).DisplayColumns(3).Width = 55
      .Columns(4).Caption = "Type"
      .Splits(0).DisplayColumns(4).Width = 40
      .Columns(5).Caption = "Year"
      .Splits(0).DisplayColumns(5).Width = 40
      .Columns(6).Caption = "Prin Due"
      .Splits(0).DisplayColumns(6).Width = 70
      .Columns(7).Caption = "Amt Pd"
      .Splits(0).DisplayColumns(7).Width = 70
      .Columns(8).Caption = "Balance"
      .Splits(0).DisplayColumns(8).Width = 70
      .Columns(9).Caption = ""
      .Splits(0).DisplayColumns(9).Width = 20
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
    Dim I As Integer
    With C1DataGrdList
      .Rebind(True)
      For I = 1 To 10
        .Splits(0).DisplayColumns(I).Locked = True
      Next
      .Columns(1).Caption = "CustID"
      .Splits(0).DisplayColumns(1).Width = 70
      .Columns(2).Caption = "Name"
      .Splits(0).DisplayColumns(2).Width = 200
      .Columns(3).Caption = "List #"
      .Splits(0).DisplayColumns(3).Width = 55
      .Columns(4).Caption = "Type"
      .Splits(0).DisplayColumns(4).Width = 35
      .Columns(5).Caption = "Year"
      .Splits(0).DisplayColumns(5).Width = 35
      .Columns(6).Caption = "Prin Due"
      .Splits(0).DisplayColumns(6).Width = 70
      .Columns(7).Caption = "Amt Pd"
      .Splits(0).DisplayColumns(7).Width = 70
      .Columns(8).Caption = "Balance"
      .Splits(0).DisplayColumns(8).Width = 70
      .Columns(9).Caption = ""
      .Splits(0).DisplayColumns(9).Width = 20
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
      .Columns(1).Caption = "Name"
      .Splits(0).DisplayColumns(1).Width = 200
      .Columns(2).Caption = "Second Name"
      .Splits(0).DisplayColumns(2).Width = 125
      .Columns(3).Caption = "List#"
      .Splits(0).DisplayColumns(3).Width = 55
      .Columns(4).Caption = "Type"
      .Splits(0).DisplayColumns(4).Width = 30
      .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      .Columns(5).Caption = "Year"
      .Splits(0).DisplayColumns(5).Width = 32
      .Columns(6).Caption = "Prin Due"
      .Splits(0).DisplayColumns(6).Width = 65
      .Columns(7).Caption = "Amt Pd"
      .Splits(0).DisplayColumns(7).Width = 65
      .Columns(8).Caption = "Balance"
      .Splits(0).DisplayColumns(8).Width = 65
      .Columns(9).Caption = ""
      .Splits(0).DisplayColumns(9).Width = 20
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
      .Columns(1).Caption = "Second Name"
      .Splits(0).DisplayColumns(1).Width = 200
      .Columns(2).Caption = "Name"
      .Splits(0).DisplayColumns(2).Width = 125
      .Columns(3).Caption = "List#"
      .Splits(0).DisplayColumns(3).Width = 55
      .Columns(4).Caption = "Type"
      .Splits(0).DisplayColumns(4).Width = 30
      .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      .Columns(5).Caption = "Year"
      .Splits(0).DisplayColumns(5).Width = 32
      .Columns(6).Caption = "Prin Due"
      .Splits(0).DisplayColumns(6).Width = 65
      .Columns(7).Caption = "Amt Pd"
      .Splits(0).DisplayColumns(7).Width = 65
      .Columns(8).Caption = "Balance"
      .Splits(0).DisplayColumns(8).Width = 65
      .Columns(9).Caption = ""
      .Splits(0).DisplayColumns(9).Width = 20
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
    Dim I As Integer
    With C1DataGrdList
      .Rebind(True)
      For I = 1 To 10
        .Splits(0).DisplayColumns(I).Locked = True
      Next
      .Columns(1).Caption = "Reg #"
      .Splits(0).DisplayColumns(1).Width = 70
      .Columns(2).Caption = "Name"
      .Splits(0).DisplayColumns(2).Width = 165
      .Columns(3).Caption = "List #"
      .Splits(0).DisplayColumns(3).Width = 55
      .Columns(4).Caption = "Type"
      .Splits(0).DisplayColumns(4).Width = 35
      .Columns(5).Caption = "Year"
      .Splits(0).DisplayColumns(5).Width = 35
      .Columns(6).Caption = "Prin Due"
      .Splits(0).DisplayColumns(6).Width = 70
      .Columns(7).Caption = "Amt Pd"
      .Splits(0).DisplayColumns(7).Width = 70
      .Columns(8).Caption = "Balance"
      .Splits(0).DisplayColumns(8).Width = 70
      .Columns(9).Caption = ""
      .Splits(0).DisplayColumns(9).Width = 20
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
    Dim I As Integer
    With C1DataGrdList
      .Rebind(True)
      For I = 1 To 10
        .Splits(0).DisplayColumns(I).Locked = True
      Next
      .Columns(1).Caption = "VIN"
      .Splits(0).DisplayColumns(1).Width = 130
      .Columns(2).Caption = "Name"
      .Splits(0).DisplayColumns(2).Width = 165
      .Columns(3).Caption = "List #"
      .Splits(0).DisplayColumns(3).Width = 55
      .Columns(4).Caption = "Type"
      .Splits(0).DisplayColumns(4).Width = 35
      .Columns(5).Caption = "Year"
      .Splits(0).DisplayColumns(5).Width = 35
      .Columns(6).Caption = "Prin Due"
      .Splits(0).DisplayColumns(6).Width = 70
      .Columns(7).Caption = "Amt Pd"
      .Splits(0).DisplayColumns(7).Width = 70
      .Columns(8).Caption = "Balance"
      .Splits(0).DisplayColumns(8).Width = 70
      .Columns(9).Caption = ""
      .Splits(0).DisplayColumns(9).Width = 20
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

  Private Sub FrmTXA094_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    If Not MyInquiryMode Then
      With MyFrmTXA09
        .TBarNew.Enabled = True
        .TBarView.Enabled = True
      End With
      MyFrmTXA091.FormatGrid()
      MyFrmTXA091.Show()
    Else
      Application.Exit()
    End If
    'Memory Cleanup
    MyFrmTXA094 = Nothing
  End Sub
  Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
    If TxtList.Text <> "" And TxtType.Text <> "" And TxtYear.Text <> "" Then
      ShowFastPath()
    Else
      GetListNoRecords()
    End If
  End Sub
  Private Sub FrmTXA094_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA09.SbpScreen.Text = "TXA094"
    MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmTXA09
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    WrkReadForward = True
    WrkListNo = 0
    WrkYear = 0
    WrkType = ""
    Call FormatGrid(True, True, False)
    If CboSort.SelectedItem.ToString = "Location" Then
      TxtPosNo.Focus()
    Else
      TxtPos.Focus()
    End If
  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    ShowGridNext()
  End Sub
  Private Sub BtnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnScan.Click
    Call FormatGrid(False, False, True)
    WrkReadForward = True
  End Sub
  Public Sub ViewBatch(ByVal WrkBackScreen As String)
    MyFrmTXA09View = New FrmTXA09View
    MyFrmTXA09View.MdiParent = MyFrmTXA094.ParentForm
    MyFrmTXA09View.WrkBatch = MyBatch
    MyFrmTXA09View.WrkBatchNo = MyBatchNo
    MyFrmTXA09View.WrkBackScreen = WrkBackScreen
    MyFrmTXA09View.Show()
    MyFrmTXA094.Hide()
  End Sub
  Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    MyFrmTXA09B = New FrmTXA09B
    MyFrmTXA09B.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 3)
    MyFrmTXA09B.WrkType = C1DataGrdList.Item(C1DataGrdList.Row, 4)
    MyFrmTXA09B.WrkYear = C1DataGrdList.Item(C1DataGrdList.Row, 5)
    MyFrmTXA09B.MdiParent = Me.ParentForm
    MyFrmTXA09B.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub

  Private Sub groupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupBox2.Enter

  End Sub

  Private Sub FrmTXA094_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    Dim Cancel As Boolean

    If MyInquiryMode Then Exit Sub

    CloseBatch(Cancel, True)
    If Cancel Then
      e.Cancel = True
      Exit Sub
    End If

  End Sub
  Private Sub RefreshDS()
    Dim MyCASHINT As CASHINT.MyData
    Dim dstxbatch As DataSet = New DataSet
    Dim ListNo As Integer
    Dim Year As Integer
    Dim Type As String
    Dim I As Integer

    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    If MyBalTotal Then
      MyCASHINT = New CASHINT.MyData(myDBConnect)
    End If
    For I = 0 To ds.Tables(0).Rows.Count - 1
      ListNo = ds.Tables(0).Rows(I).Item("List#")
      Year = ds.Tables(0).Rows(I).Item("Year")
      Type = ds.Tables(0).Rows(I).Item("Type")
      EnsureFileReady("TXBATCHL1") ' added 6/2/25   
      dstxbatch = mytxbatchl1.GetViewbyList(ListNo, Year, Type, 1)
      If dstxbatch.Tables(0).Rows.Count > 0 Then
        With ds.Tables(0).Rows(I)
          .Item("wupost") = "*"
        End With
      End If
      If MyBalTotal And ds.Tables(0).Rows(I).Item("wbal") >= 0 Then
        With MyCASHINT
          .In_IntDate = MyInterestDate
          .In_ListNo = ListNo
          .In_Type = Type
          .In_Year = Year
          .CalcInterest()
          ds.Tables(0).Rows(I).Item("wbal") = Format(.Out_Tot(), "standard")
        End With
      End If
      mytxbatchl1.CloseFile()
      dstxbatch.Clear()
      dstxbatch = Nothing
    Next
    If MyBalTotal Then
      MyCASHINT = Nothing
    End If
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Public Sub CloseBatch(ByRef Cancel As Boolean, ByVal Prompt As Boolean)
    Dim myTBATCH As TBATCH.MyData
    Dim Answer As Integer

    Cancel = False
    If Prompt Then
      Answer = MsgBox("You must close batch to exit", MsgBoxStyle.OkCancel, "Close Batch requested")
      If Answer = MsgBoxResult.Cancel Then
        Cancel = True
        Exit Sub
      End If
    End If

    myTBATCH = New TBATCH.MyData(myDBConnect)
    myTBATCH.GetOneRecordP(MyBatch, MyBatchNo)
    With myTBATCH
      If Not .RecordNotFound Then
        ._KBSTAT = "C"
        .UpdateOneRecordP()
      End If
    End With
    ' 6/2/25  changed logic here 
    'myTBATCH.CloseFile()
    'mytxinvl8.CloseFile()
    'mytxinvla.CloseFile()
    'mytxinvlc.CloseFile()
    'mytxinvld.CloseFile()
    'mytxinvlm.CloseFile()
    'mytxinvln.CloseFile()
    'mytxinvls.CloseFile()
    'mytxinvlv.CloseFile()
    If myTBATCH IsNot Nothing Then myTBATCH.CloseFile()
    If mytxinvl8 IsNot Nothing Then mytxinvl8.CloseFile()
    If mytxinvla IsNot Nothing Then mytxinvla.CloseFile()
    If mytxinvlc IsNot Nothing Then mytxinvlc.CloseFile()
    If mytxinvld IsNot Nothing Then mytxinvld.CloseFile()
    If mytxinvlm IsNot Nothing Then mytxinvlm.CloseFile()
    If mytxinvln IsNot Nothing Then mytxinvln.CloseFile()
    If mytxinvls IsNot Nothing Then mytxinvls.CloseFile()
    If mytxinvlv IsNot Nothing Then mytxinvlv.CloseFile()

    mytxinvl8 = Nothing
    mytxinvla = Nothing
    mytxinvlc = Nothing
    mytxinvld = Nothing
    mytxinvlm = Nothing
    mytxinvln = Nothing
    mytxinvls = Nothing
    mytxinvlv = Nothing
    Application.DoEvents()

    MySelFromYear = 0
    MySelToYear = 0
    MySelTypes = ""

  End Sub
  Private Sub BtnTotal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTotal.Click
    TotalGridItems(False)
  End Sub
  Private Sub BtnPayCredit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPayCredit.Click
    PayCreditGridItems(False)
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
  Public Sub TotalGridItems(ByRef Complete As Boolean)
    Dim mycashint As CASHINT.MyData
    Dim myDr As DataRow
    Dim I As Integer
    mycashint = New CASHINT.MyData(myDBConnect)

    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
      If C1DataGrdList.Item(I, 0) = 1 And C1DataGrdList.Item(I, 10) <> "I" Then
        myDr = MydsGroupItems.Tables(0).NewRow
        Select Case CboSort.SelectedItem.ToString
          Case "Location", "Reg #"
            myDr("Desc") = C1DataGrdList.Item(I, 1) & " " & C1DataGrdList.Item(I, 2)
            myDr("ListNo") = C1DataGrdList.Item(I, 3)
            myDr("Type") = C1DataGrdList.Item(I, 4)
            myDr("Year") = C1DataGrdList.Item(I, 5)
            myDr("Balance") = C1DataGrdList.Item(I, 8)
          Case "DOB", "CustID Primary", "CustID Secondary", "VIN"
            myDr("Desc") = C1DataGrdList.Item(I, 2)
            myDr("ListNo") = C1DataGrdList.Item(I, 3)
            myDr("Type") = C1DataGrdList.Item(I, 4)
            myDr("Year") = C1DataGrdList.Item(I, 5)
            myDr("Balance") = C1DataGrdList.Item(I, 8)
          Case Else
            myDr("Desc") = C1DataGrdList.Item(I, 1)
            myDr("ListNo") = C1DataGrdList.Item(I, 3)
            myDr("Type") = C1DataGrdList.Item(I, 4)
            myDr("Year") = C1DataGrdList.Item(I, 5)
            myDr("Balance") = C1DataGrdList.Item(I, 8)
        End Select
        With mycashint
          .In_IntDate = MyInterestDate
          .In_ListNo = myDr("ListNo")
          .In_Type = myDr("Type")
          .In_Year = myDr("Year")
          .CalcInterest()
          myDr("Tax") = Format(.Out_Prin(), "standard")
          myDr("Interest") = Format(.Out_Int(), "standard")
          myDr("Fee") = Format(.Out_Fee(), "standard")
          myDr("Lien") = Format(.Out_Lien(), "standard")
          myDr("Bond") = Format(.Out_Bond(), "standard")
          myDr("Total") = Format(.Out_Tot(), "standard")
        End With
        If C1DataGrdList.Item(I, 8) < 0 Then
          myDr("Tax") = C1DataGrdList.Item(I, 8)
        End If
        If C1DataGrdList.Item(I, 8) < 0 Then
          myDr("Total") = C1DataGrdList.Item(I, 8)
        End If
        MydsGroupItems.Tables(0).Rows.Add(myDr)
        C1DataGrdList.Item(I, 0) = 0
      End If
    Next

    MyFrmTXA094B = New FrmTXA094B
    With MyFrmTXA094B
      .MdiParent = Me.ParentForm
      .Show()
    End With

    mycashint.CloseFiles()
    mycashint = Nothing
    Me.Hide()
  End Sub
  Public Sub PayCreditGridItems(ByRef Complete As Boolean)
    Dim mycashint As CASHINT.MyData
    Dim myDr As DataRow
    Dim I As Integer

    mycashint = New CASHINT.MyData(myDBConnect)
    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
      If C1DataGrdList.Item(I, 0) = 1 And C1DataGrdList.Item(I, 10) <> "I" Then
        myDr = MydsPayCredit.Tables(0).NewRow
        Select Case CboSort.SelectedItem.ToString
          Case "Location", "Reg #"
            myDr("Desc") = C1DataGrdList.Item(I, 1) & " " & C1DataGrdList.Item(I, 2)
            myDr("ListNo") = C1DataGrdList.Item(I, 3)
            myDr("Type") = C1DataGrdList.Item(I, 4)
            myDr("Year") = C1DataGrdList.Item(I, 5)
            myDr("Balance") = C1DataGrdList.Item(I, 8)
          Case "DOB", "CustID Primary", "CustID Secondary", "VIN"
            myDr("Desc") = C1DataGrdList.Item(I, 2)
            myDr("ListNo") = C1DataGrdList.Item(I, 3)
            myDr("Type") = C1DataGrdList.Item(I, 4)
            myDr("Year") = C1DataGrdList.Item(I, 5)
            myDr("Balance") = C1DataGrdList.Item(I, 8)
          Case Else
            myDr("Desc") = C1DataGrdList.Item(I, 1)
            myDr("ListNo") = C1DataGrdList.Item(I, 3)
            myDr("Type") = C1DataGrdList.Item(I, 4)
            myDr("Year") = C1DataGrdList.Item(I, 5)
            myDr("Balance") = C1DataGrdList.Item(I, 8)
        End Select
        With mycashint
          .In_IntDate = MyInterestDate
          .In_ListNo = myDr("ListNo")
          .In_Type = myDr("Type")
          .In_Year = myDr("Year")
          .CalcInterest()
          myDr("Tax") = Format(.Out_Prin(), "standard")
          myDr("Interest") = Format(.Out_Int(), "standard")
          myDr("Fee") = Format(.Out_Fee(), "standard")
          myDr("Lien") = Format(.Out_Lien(), "standard")
          myDr("Bond") = Format(.Out_Bond(), "standard")
          myDr("Total") = Format(.Out_Tot(), "standard")
        End With
        MydsPayCredit.Tables(0).Rows.Add(myDr)
        C1DataGrdList.Item(I, 0) = 0
      End If
    Next

    MyFrmTXA094C = New FrmTXA094C
    With MyFrmTXA094C
      .MdiParent = Me.ParentForm
      .Show()
    End With

    mycashint.CloseFiles()
    mycashint = Nothing
    Me.Hide()
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
    If MyScanOnly Then
      FormatGrid(False, False, True)
    Else
      FormatGrid(True, True, False)
    End If
    If CboSort.SelectedItem.ToString = "Location" Then
      TxtPosNo.Focus()
    Else
      TxtPos.Focus()
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
    If MyScanOnly Then
      FormatGrid(False, False, True)
    Else
      FormatGrid(True, True, False)
    End If
    If CboSort.SelectedItem.ToString = "Location" Then
      TxtPosNo.Focus()
    Else
      TxtPos.Focus()
    End If
  End Sub
  Private Sub ShowFastPath()

    If MyUtils.CnvSng(TxtList.Text) = 0 Then Exit Sub
    If TxtType.Text = "" Then Exit Sub
    If MyUtils.CnvSng(TxtYear.Text) = 0 Then Exit Sub
    EnsureFileReady("TXINV") ' added 6/2/25 
    myTXINV.GetOneRecordP(MyUtils.CnvSng(TxtList.Text), MyUtils.CnvSng(TxtYear.Text), TxtType.Text)
    If myTXINV.RecordNotFound Then
      MsgBox("List/Year/Type not found", MsgBoxStyle.Exclamation, "Fast Path information is not valid")
      Exit Sub
    End If

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    MyScanOnly = False
    With myTXINV
      TxtPos.Text = Trim(._NAME)
      CboSort.SelectedItem = "Owner's Name"
    End With
    'MK 7/ 9/25 Begin 
    FormatGrid(True, True, False) 'uncomment
    'TxtPos.Text = "" 'comment
    'TxtPosNo.Text = "" 'comment
    'MK 7/ 9/25 End

    TxtList.Focus()
    MyFrmTXA09B = New FrmTXA09B

    With MyFrmTXA09B
      .WrkListNo = MyUtils.CnvSng(TxtList.Text)
      .WrkType = TxtType.Text
      .WrkYear = MyUtils.CnvSng(TxtYear.Text)
      .MdiParent = Me.ParentForm
      .Show()
    End With

    TxtList.Text = ""
    TxtType.Text = ""
    TxtYear.Text = ""
    Windows.Forms.Cursor.Current = Cursors.Default
    Me.Hide()

  End Sub
  Sub GetListNoRecords()
    Dim MyCASHINT As CASHINT.MyData
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim myDr As Data.DataRow
    Dim I As Integer

    If MyBalTotal Then
      MyCASHINT = New CASHINT.MyData(myDBConnect)
    End If
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
    EnsureFileReady("TXINV")
    ds2 = myTXINV.GetAllListNo(Val(TxtList.Text))
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      If TxtType.Text <> "" And TxtType.Text <> ds2.Tables(0).Rows(I).Item("type") Then
        Continue For
      End If
      If TxtYear.Text <> "" And MyUtils.CnvSng(TxtYear.Text) <> ds2.Tables(0).Rows(I).Item("year") Then
        Continue For
      End If
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
          If MyBalTotal And myDr("wbal") >= 0 Then
            With MyCASHINT
              .In_IntDate = MyInterestDate
              .In_ListNo = Val(TxtList.Text)
              .In_Type = ds2.Tables(0).Rows(I).Item("type")
              .In_Year = ds2.Tables(0).Rows(I).Item("year")
              .CalcInterest()
              myDr("wbal") = Format(.Out_Tot(), "standard")
            End With
          End If
          If MyFastPathBal Then
            Select Case CboBal.SelectedItem.ToString
              Case "Credit Balance"
                If myDr("wbal") >= 0 Then
                  Continue For
                End If
              Case "Not Equal to Zero"
                If myDr("wbal") = 0 Then
                  Continue For
                End If
              Case "Balance Due"
                If myDr("wbal") = 0 Then
                  Continue For
                End If
              Case Else
            End Select
          End If
          ds.Tables(0).Rows.Add(myDr)
        End If
      End With
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
    RefreshDS()
    TxtList.Text = ""
    TxtType.Text = ""
    TxtList.Focus()
    If MyBalTotal Then
      MyCASHINT = Nothing
    End If

  End Sub
  Private Sub TxtList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtList.KeyPress
    Dim WrkBarCode As String
    Dim WrkLen As Integer

    If Asc(e.KeyChar) = Keys.Return Then
      WrkBarCode = TxtList.Text
      'Check for Bar code entry
      If TxtList.Text.ToLower <> TxtList.Text.ToUpper Then
        WrkLen = Len(Trim(TxtList.Text))
        If WrkLen <= 5 Then
          Exit Sub
        End If
        If WrkLen = 12 Then
          TxtList.Text = Mid(WrkBarCode, 1, 7)
          TxtType.Text = Mid(WrkBarCode, 8, 1)
          TxtYear.Text = Mid(WrkBarCode, 9, 4)
        Else
          TxtList.Text = Mid(WrkBarCode, 1, WrkLen - 5)
          TxtType.Text = Mid(WrkBarCode, WrkLen - 4, 1)
          TxtYear.Text = Mid(WrkBarCode, WrkLen - 3, 4)
        End If
        ShowFastPath()
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
  Private Sub TxtPosNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPosNo.GotFocus
    MyUtils.ShowFocus(Me.ActiveControl)
  End Sub
  Private Sub TxtPos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPos.GotFocus
    MyUtils.ShowFocus(Me.ActiveControl)
  End Sub
  Private Sub TxtType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtType.KeyPress
    'Move to next field after anything has been typed since it's only 1 char allowed
    Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
  End Sub
  Private Sub TxtPos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPos.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      WrkListNo = 0
      WrkYear = 0
      WrkType = ""
      If MyScanOnly Then
        Call FormatGrid(False, False, True)
      Else
        Call FormatGrid(True, True, False)
      End If
    End If
  End Sub
  Private Sub TxtPos_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TxtPos.MouseDown
    If e.Clicks = 2 And Windows.Forms.MouseButtons.Left Then
      TxtPos.Text = ""
      TxtPosNo.Text = ""
    End If
  End Sub
  Private Sub TxtPosNo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TxtPosNo.MouseDown
    If e.Clicks = 2 And Windows.Forms.MouseButtons.Left Then
      TxtPos.Text = ""
      TxtPosNo.Text = ""
    End If

  End Sub
  Private Sub C1DataGrdList_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles C1DataGrdList.FetchRowStyle
    If C1DataGrdList.Columns("wbal").CellValue(e.Row) > 0 Then
      If MyAppSettings.StatusColor Then
        If C1DataGrdList.Columns("icode").CellValue(e.Row) = "B" Then
          e.CellStyle.BackColor = System.Drawing.Color.Yellow
        End If
        If C1DataGrdList.Columns("icode").CellValue(e.Row) = "M" Then
          e.CellStyle.BackColor = System.Drawing.Color.Yellow
        End If
        If C1DataGrdList.Columns("icode").CellValue(e.Row) = "S" Then
          e.CellStyle.BackColor = System.Drawing.Color.Yellow
        End If
      End If
      If MyAppSettings.ForeclosureColor Then
        If C1DataGrdList.Columns("icode").CellValue(e.Row) = "F" Then
          e.CellStyle.BackColor = System.Drawing.Color.Pink
        End If
      End If
    End If
    If C1DataGrdList.Columns("icode").CellValue(e.Row) = "I" Then
      e.CellStyle.BackColor = System.Drawing.Color.Pink
    End If
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
    'mytxinvl8 = Nothing
    'mytxinvla = Nothing
    'mytxinvlc = Nothing
    'mytxinvld = Nothing
    'mytxinvlm = Nothing
    'mytxinvln = Nothing
    'mytxinvls = Nothing
    'mytxinvlv = Nothing
    'mytxinvl8 = New TXINVL8.MyData(myDBConnect)
    'mytxinvla = New TXINVLA.MyData(myDBConnect)
    'mytxinvlc = New TXINVLC.MyData(myDBConnect)
    'mytxinvld = New TXINVLD.MyData(myDBConnect)
    'mytxinvlm = New TXINVLM.MyData(myDBConnect)
    'mytxinvln = New TXINVLN.MyData(myDBConnect)
    'mytxinvls = New TXINVLS.MyData(myDBConnect)
    'mytxinvlv = New TXINVLV.MyData(myDBConnect)

    If mytxinvla IsNot Nothing Then
      mytxinvla.CloseFile()
      mytxinvla = Nothing
    End If

    If mytxinvlc IsNot Nothing Then
      mytxinvlc.CloseFile()
      mytxinvlc = Nothing
    End If

    If mytxinvld IsNot Nothing Then
      mytxinvld.CloseFile()
      mytxinvld = Nothing
    End If

    If mytxinvlm IsNot Nothing Then
      mytxinvlm.CloseFile()
      mytxinvlm = Nothing
    End If

    If mytxinvln IsNot Nothing Then
      mytxinvln.CloseFile()
      mytxinvln = Nothing
    End If

    If mytxinvls IsNot Nothing Then
      mytxinvls.CloseFile()
      mytxinvls = Nothing
    End If

    If mytxinvlv IsNot Nothing Then
      mytxinvlv.CloseFile()
      mytxinvlv = Nothing
    End If

    If mytxinvl8 IsNot Nothing Then
      mytxinvl8.CloseFile()
      mytxinvl8 = Nothing
    End If


  End Sub

  Private Sub C1DataGrdList_Click(sender As Object, e As EventArgs) Handles C1DataGrdList.Click

  End Sub
  Private Sub CboSort_SelectedValueChanged(sender As Object, e As EventArgs) Handles CboSort.SelectedValueChanged
    MyScanOnly = False
    BtnFind.Enabled = True
      BtnNext.Enabled = True
      Select Case CboSort.SelectedItem.ToString
        Case "Owner's Name", "Second Name", "Reg #", "VIN"
          TxtPosNo.Visible = False
          TxtPos.Visible = True
          DtPckDOB.Visible = False
          FormatGrid(True, True, False)
          BtnScan.Enabled = True
          TxtPos.Focus()
        Case "Both Names"
          TxtPosNo.Visible = False
          TxtPos.Visible = True
          DtPckDOB.Visible = False
          FormatGrid(False, False, True)
          MyScanOnly = True
          BtnFind.Enabled = False
          BtnNext.Enabled = False
          BtnScan.Enabled = True
          TxtPos.Focus()
        Case "DOB"
          TxtPosNo.Visible = False
          TxtPos.Visible = False
          DtPckDOB.Visible = True
          FormatGrid(True, True, False)
          BtnScan.Enabled = False
          DtPckDOB.Focus()
        Case "Location"
          TxtPosNo.Visible = True
          TxtPos.Visible = True
          DtPckDOB.Visible = False
          FormatGrid(True, True, False)
          BtnScan.Enabled = True
          TxtPosNo.Focus()
        Case "Both CustID"
          TxtPosNo.Visible = False
          TxtPos.Visible = True
          DtPckDOB.Visible = False
          FormatGrid(False, False, True)
          MyScanOnly = True
          BtnFind.Enabled = False
          BtnNext.Enabled = False
          BtnScan.Enabled = True
          TxtPos.Focus()
        Case Else
          TxtPosNo.Visible = False
          TxtPos.Visible = True
          DtPckDOB.Visible = False
          FormatGrid(True, True, False)
          BtnScan.Enabled = False
          TxtPos.Focus()
      End Select


  End Sub
  Private Sub CboBal_SelectedValueChanged(sender As Object, e As EventArgs) Handles CboBal.SelectedValueChanged

    If MyScanOnly Then
        FormatGrid(False, False, True)
      Else
        FormatGrid(True, True, False)
      End If
      If CboSort.SelectedItem.ToString = "Location" Then
        TxtPosNo.Focus()
      Else
        TxtPos.Focus()
      End If



  End Sub
  Private Sub CboBal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboBal.SelectedIndexChanged

    Select Case CboBal.SelectedItem.ToString
        Case "Balance Due"
          WrkBalanceOnly = True
        Case Else
          WrkBalanceOnly = False
      End Select


  End Sub

End Class
