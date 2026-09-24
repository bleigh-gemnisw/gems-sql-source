Public Class FrmTXA09DMV
  Inherits System.Windows.Forms.Form
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TbPrimary As System.Windows.Forms.TabPage
  Friend WithEvents LblPbus As System.Windows.Forms.Label
  Friend WithEvents Label31 As System.Windows.Forms.Label
  Friend WithEvents LblPconfid As System.Windows.Forms.Label
  Friend WithEvents Label28 As System.Windows.Forms.Label
  Friend WithEvents LblPsex As System.Windows.Forms.Label
  Friend WithEvents Label25 As System.Windows.Forms.Label
  Friend WithEvents LblPDOB As System.Windows.Forms.Label
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents LblPzip As System.Windows.Forms.Label
  Friend WithEvents Label27 As System.Windows.Forms.Label
  Friend WithEvents LblPstate As System.Windows.Forms.Label
  Friend WithEvents Label26 As System.Windows.Forms.Label
  Friend WithEvents LblPcity As System.Windows.Forms.Label
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents LblPadd2 As System.Windows.Forms.Label
  Friend WithEvents Label24 As System.Windows.Forms.Label
  Friend WithEvents LblPadd1 As System.Windows.Forms.Label
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents LblPname As System.Windows.Forms.Label
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents TpSecondary As System.Windows.Forms.TabPage
  Friend WithEvents LblSbus As System.Windows.Forms.Label
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents LblSconfid As System.Windows.Forms.Label
  Friend WithEvents Label33 As System.Windows.Forms.Label
  Friend WithEvents LblSsex As System.Windows.Forms.Label
  Friend WithEvents Label35 As System.Windows.Forms.Label
  Friend WithEvents LblSDOB As System.Windows.Forms.Label
  Friend WithEvents Label37 As System.Windows.Forms.Label
  Friend WithEvents LblSzip As System.Windows.Forms.Label
  Friend WithEvents Label39 As System.Windows.Forms.Label
  Friend WithEvents LblSstate As System.Windows.Forms.Label
  Friend WithEvents Label41 As System.Windows.Forms.Label
  Friend WithEvents LblScity As System.Windows.Forms.Label
  Friend WithEvents Label43 As System.Windows.Forms.Label
  Friend WithEvents LblSadd2 As System.Windows.Forms.Label
  Friend WithEvents Label45 As System.Windows.Forms.Label
  Friend WithEvents LblSadd1 As System.Windows.Forms.Label
  Friend WithEvents Label47 As System.Windows.Forms.Label
  Friend WithEvents LblSname As System.Windows.Forms.Label
  Friend WithEvents Label49 As System.Windows.Forms.Label
  Dim myTXINV As TXINV.MyData
  Dim myTXINVLC As TXINVLC.MyData
  Dim myTXINVLM As TXINVLM.MyData
  Dim myTXVCUS As TXVCUS.MyData
  Dim myTXVEH As TXVEH.MyData
  Dim myTXVEHL2 As TXVEHL2.MyData
  Dim ds As DataSet = New DataSet
  Dim WrkBlocking As Boolean
  Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtDMVVehID As System.Windows.Forms.TextBox
  Friend WithEvents TxtPCust As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtSCust As System.Windows.Forms.TextBox
  Friend WithEvents TpVehicle As System.Windows.Forms.TabPage
  Friend WithEvents LblRegEndDt As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents LblRegStrDt As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents LblClassDesc As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents LblBody As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents Label7 As Label
  Friend WithEvents TxtVehID As TextBox
  Friend WrkRegNo As String

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
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents GrpAddr As System.Windows.Forms.GroupBox
  Friend WithEvents TxtZip4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtZip5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents TxtAdd2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtAdd1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtSname As System.Windows.Forms.TextBox
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTXA09DMV))
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.GrpAddr = New System.Windows.Forms.GroupBox()
    Me.TxtZip4 = New System.Windows.Forms.TextBox()
    Me.TxtZip5 = New System.Windows.Forms.TextBox()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtAdd2 = New System.Windows.Forms.TextBox()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.TxtAdd1 = New System.Windows.Forms.TextBox()
    Me.TxtSname = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.label1 = New System.Windows.Forms.Label()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TbPrimary = New System.Windows.Forms.TabPage()
    Me.LblPbus = New System.Windows.Forms.Label()
    Me.Label31 = New System.Windows.Forms.Label()
    Me.LblPconfid = New System.Windows.Forms.Label()
    Me.Label28 = New System.Windows.Forms.Label()
    Me.LblPsex = New System.Windows.Forms.Label()
    Me.Label25 = New System.Windows.Forms.Label()
    Me.LblPDOB = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.LblPzip = New System.Windows.Forms.Label()
    Me.Label27 = New System.Windows.Forms.Label()
    Me.LblPstate = New System.Windows.Forms.Label()
    Me.Label26 = New System.Windows.Forms.Label()
    Me.LblPcity = New System.Windows.Forms.Label()
    Me.Label22 = New System.Windows.Forms.Label()
    Me.LblPadd2 = New System.Windows.Forms.Label()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.LblPadd1 = New System.Windows.Forms.Label()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.LblPname = New System.Windows.Forms.Label()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.TpSecondary = New System.Windows.Forms.TabPage()
    Me.LblSbus = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.LblSconfid = New System.Windows.Forms.Label()
    Me.Label33 = New System.Windows.Forms.Label()
    Me.LblSsex = New System.Windows.Forms.Label()
    Me.Label35 = New System.Windows.Forms.Label()
    Me.LblSDOB = New System.Windows.Forms.Label()
    Me.Label37 = New System.Windows.Forms.Label()
    Me.LblSzip = New System.Windows.Forms.Label()
    Me.Label39 = New System.Windows.Forms.Label()
    Me.LblSstate = New System.Windows.Forms.Label()
    Me.Label41 = New System.Windows.Forms.Label()
    Me.LblScity = New System.Windows.Forms.Label()
    Me.Label43 = New System.Windows.Forms.Label()
    Me.LblSadd2 = New System.Windows.Forms.Label()
    Me.Label45 = New System.Windows.Forms.Label()
    Me.LblSadd1 = New System.Windows.Forms.Label()
    Me.Label47 = New System.Windows.Forms.Label()
    Me.LblSname = New System.Windows.Forms.Label()
    Me.Label49 = New System.Windows.Forms.Label()
    Me.TpVehicle = New System.Windows.Forms.TabPage()
    Me.LblRegEndDt = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.LblRegStrDt = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.LblClassDesc = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.LblBody = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtSCust = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtDMVVehID = New System.Windows.Forms.TextBox()
    Me.TxtPCust = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtVehID = New System.Windows.Forms.TextBox()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpAddr.SuspendLayout()
    Me.TabControl1.SuspendLayout()
    Me.TbPrimary.SuspendLayout()
    Me.TpSecondary.SuspendLayout()
    Me.TpVehicle.SuspendLayout()
    Me.GroupBox6.SuspendLayout()
    Me.SuspendLayout()
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColMove = False
    Me.C1DataGrdList.AllowColSelect = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AllowUpdate = False
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(8, 199)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.Size = New System.Drawing.Size(782, 214)
    Me.C1DataGrdList.TabIndex = 6
    Me.C1DataGrdList.Text = "C1TrueDBGrid1"
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(5, 111)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(48, 16)
    Me.Label4.TabIndex = 220
    Me.Label4.Text = "City/ST"
    '
    'GrpAddr
    '
    Me.GrpAddr.Controls.Add(Me.TxtZip4)
    Me.GrpAddr.Controls.Add(Me.TxtZip5)
    Me.GrpAddr.Controls.Add(Me.TxtState)
    Me.GrpAddr.Controls.Add(Me.TxtAdd2)
    Me.GrpAddr.Controls.Add(Me.TxtCity)
    Me.GrpAddr.Controls.Add(Me.TxtAdd1)
    Me.GrpAddr.Controls.Add(Me.TxtSname)
    Me.GrpAddr.Controls.Add(Me.TxtName)
    Me.GrpAddr.Location = New System.Drawing.Point(59, 7)
    Me.GrpAddr.Name = "GrpAddr"
    Me.GrpAddr.Size = New System.Drawing.Size(273, 120)
    Me.GrpAddr.TabIndex = 217
    Me.GrpAddr.TabStop = False
    '
    'TxtZip4
    '
    Me.TxtZip4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtZip4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip4.Location = New System.Drawing.Point(216, 96)
    Me.TxtZip4.MaxLength = 4
    Me.TxtZip4.Name = "TxtZip4"
    Me.TxtZip4.ReadOnly = True
    Me.TxtZip4.Size = New System.Drawing.Size(32, 20)
    Me.TxtZip4.TabIndex = 7
    '
    'TxtZip5
    '
    Me.TxtZip5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtZip5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip5.Location = New System.Drawing.Point(168, 96)
    Me.TxtZip5.MaxLength = 5
    Me.TxtZip5.Name = "TxtZip5"
    Me.TxtZip5.ReadOnly = True
    Me.TxtZip5.Size = New System.Drawing.Size(44, 20)
    Me.TxtZip5.TabIndex = 6
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(144, 96)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.ReadOnly = True
    Me.TxtState.Size = New System.Drawing.Size(24, 20)
    Me.TxtState.TabIndex = 5
    '
    'TxtAdd2
    '
    Me.TxtAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd2.Location = New System.Drawing.Point(8, 76)
    Me.TxtAdd2.MaxLength = 35
    Me.TxtAdd2.Name = "TxtAdd2"
    Me.TxtAdd2.ReadOnly = True
    Me.TxtAdd2.Size = New System.Drawing.Size(216, 20)
    Me.TxtAdd2.TabIndex = 3
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(8, 96)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.ReadOnly = True
    Me.TxtCity.Size = New System.Drawing.Size(136, 20)
    Me.TxtCity.TabIndex = 4
    '
    'TxtAdd1
    '
    Me.TxtAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd1.Location = New System.Drawing.Point(8, 56)
    Me.TxtAdd1.MaxLength = 35
    Me.TxtAdd1.Name = "TxtAdd1"
    Me.TxtAdd1.ReadOnly = True
    Me.TxtAdd1.Size = New System.Drawing.Size(216, 20)
    Me.TxtAdd1.TabIndex = 2
    '
    'TxtSname
    '
    Me.TxtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSname.Location = New System.Drawing.Point(8, 36)
    Me.TxtSname.MaxLength = 35
    Me.TxtSname.Name = "TxtSname"
    Me.TxtSname.ReadOnly = True
    Me.TxtSname.Size = New System.Drawing.Size(216, 20)
    Me.TxtSname.TabIndex = 1
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(8, 16)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.ReadOnly = True
    Me.TxtName.Size = New System.Drawing.Size(216, 20)
    Me.TxtName.TabIndex = 0
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(5, 68)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(48, 16)
    Me.Label3.TabIndex = 219
    Me.Label3.Text = "Address"
    '
    'label1
    '
    Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label1.Location = New System.Drawing.Point(5, 28)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(48, 16)
    Me.label1.TabIndex = 218
    Me.label1.Text = "Name"
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.TbPrimary)
    Me.TabControl1.Controls.Add(Me.TpSecondary)
    Me.TabControl1.Controls.Add(Me.TpVehicle)
    Me.TabControl1.Location = New System.Drawing.Point(351, 12)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(273, 181)
    Me.TabControl1.TabIndex = 221
    '
    'TbPrimary
    '
    Me.TbPrimary.Controls.Add(Me.LblPbus)
    Me.TbPrimary.Controls.Add(Me.Label31)
    Me.TbPrimary.Controls.Add(Me.LblPconfid)
    Me.TbPrimary.Controls.Add(Me.Label28)
    Me.TbPrimary.Controls.Add(Me.LblPsex)
    Me.TbPrimary.Controls.Add(Me.Label25)
    Me.TbPrimary.Controls.Add(Me.LblPDOB)
    Me.TbPrimary.Controls.Add(Me.Label29)
    Me.TbPrimary.Controls.Add(Me.LblPzip)
    Me.TbPrimary.Controls.Add(Me.Label27)
    Me.TbPrimary.Controls.Add(Me.LblPstate)
    Me.TbPrimary.Controls.Add(Me.Label26)
    Me.TbPrimary.Controls.Add(Me.LblPcity)
    Me.TbPrimary.Controls.Add(Me.Label22)
    Me.TbPrimary.Controls.Add(Me.LblPadd2)
    Me.TbPrimary.Controls.Add(Me.Label24)
    Me.TbPrimary.Controls.Add(Me.LblPadd1)
    Me.TbPrimary.Controls.Add(Me.Label20)
    Me.TbPrimary.Controls.Add(Me.LblPname)
    Me.TbPrimary.Controls.Add(Me.Label18)
    Me.TbPrimary.Location = New System.Drawing.Point(4, 22)
    Me.TbPrimary.Name = "TbPrimary"
    Me.TbPrimary.Padding = New System.Windows.Forms.Padding(3)
    Me.TbPrimary.Size = New System.Drawing.Size(265, 155)
    Me.TbPrimary.TabIndex = 0
    Me.TbPrimary.Text = "Primary"
    Me.TbPrimary.UseVisualStyleBackColor = True
    '
    'LblPbus
    '
    Me.LblPbus.Location = New System.Drawing.Point(226, 9)
    Me.LblPbus.Name = "LblPbus"
    Me.LblPbus.Size = New System.Drawing.Size(28, 16)
    Me.LblPbus.TabIndex = 92
    Me.LblPbus.Text = "<Pbus>"
    '
    'Label31
    '
    Me.Label31.Location = New System.Drawing.Point(167, 9)
    Me.Label31.Name = "Label31"
    Me.Label31.Size = New System.Drawing.Size(61, 15)
    Me.Label31.TabIndex = 91
    Me.Label31.Text = "Business?"
    '
    'LblPconfid
    '
    Me.LblPconfid.Location = New System.Drawing.Point(63, 129)
    Me.LblPconfid.Name = "LblPconfid"
    Me.LblPconfid.Size = New System.Drawing.Size(47, 15)
    Me.LblPconfid.TabIndex = 90
    Me.LblPconfid.Text = "<Pconfid>"
    '
    'Label28
    '
    Me.Label28.Location = New System.Drawing.Point(6, 129)
    Me.Label28.Name = "Label28"
    Me.Label28.Size = New System.Drawing.Size(51, 15)
    Me.Label28.TabIndex = 89
    Me.Label28.Text = "Confid?"
    '
    'LblPsex
    '
    Me.LblPsex.Location = New System.Drawing.Point(63, 114)
    Me.LblPsex.Name = "LblPsex"
    Me.LblPsex.Size = New System.Drawing.Size(47, 15)
    Me.LblPsex.TabIndex = 88
    Me.LblPsex.Text = "<Psex>"
    '
    'Label25
    '
    Me.Label25.Location = New System.Drawing.Point(6, 114)
    Me.Label25.Name = "Label25"
    Me.Label25.Size = New System.Drawing.Size(51, 15)
    Me.Label25.TabIndex = 87
    Me.Label25.Text = "Sex"
    '
    'LblPDOB
    '
    Me.LblPDOB.Location = New System.Drawing.Point(63, 100)
    Me.LblPDOB.Name = "LblPDOB"
    Me.LblPDOB.Size = New System.Drawing.Size(68, 14)
    Me.LblPDOB.TabIndex = 86
    Me.LblPDOB.Text = "<PDOB>"
    '
    'Label29
    '
    Me.Label29.Location = New System.Drawing.Point(6, 100)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(51, 15)
    Me.Label29.TabIndex = 85
    Me.Label29.Text = "DOB"
    '
    'LblPzip
    '
    Me.LblPzip.Location = New System.Drawing.Point(150, 85)
    Me.LblPzip.Name = "LblPzip"
    Me.LblPzip.Size = New System.Drawing.Size(89, 15)
    Me.LblPzip.TabIndex = 84
    Me.LblPzip.Text = "<Pzip>"
    '
    'Label27
    '
    Me.Label27.Location = New System.Drawing.Point(113, 83)
    Me.Label27.Name = "Label27"
    Me.Label27.Size = New System.Drawing.Size(31, 16)
    Me.Label27.TabIndex = 83
    Me.Label27.Text = "Zip"
    '
    'LblPstate
    '
    Me.LblPstate.Location = New System.Drawing.Point(63, 85)
    Me.LblPstate.Name = "LblPstate"
    Me.LblPstate.Size = New System.Drawing.Size(33, 15)
    Me.LblPstate.TabIndex = 82
    Me.LblPstate.Text = "<Pstate>"
    '
    'Label26
    '
    Me.Label26.Location = New System.Drawing.Point(6, 85)
    Me.Label26.Name = "Label26"
    Me.Label26.Size = New System.Drawing.Size(51, 15)
    Me.Label26.TabIndex = 81
    Me.Label26.Text = "State"
    '
    'LblPcity
    '
    Me.LblPcity.Location = New System.Drawing.Point(63, 70)
    Me.LblPcity.Name = "LblPcity"
    Me.LblPcity.Size = New System.Drawing.Size(191, 15)
    Me.LblPcity.TabIndex = 80
    Me.LblPcity.Text = "<Pcity>"
    '
    'Label22
    '
    Me.Label22.Location = New System.Drawing.Point(6, 70)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(51, 15)
    Me.Label22.TabIndex = 79
    Me.Label22.Text = "City"
    '
    'LblPadd2
    '
    Me.LblPadd2.Location = New System.Drawing.Point(63, 54)
    Me.LblPadd2.Name = "LblPadd2"
    Me.LblPadd2.Size = New System.Drawing.Size(191, 15)
    Me.LblPadd2.TabIndex = 78
    Me.LblPadd2.Text = "<Padd2>"
    '
    'Label24
    '
    Me.Label24.Location = New System.Drawing.Point(6, 54)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(51, 15)
    Me.Label24.TabIndex = 77
    Me.Label24.Text = "Addr 2"
    '
    'LblPadd1
    '
    Me.LblPadd1.Location = New System.Drawing.Point(63, 39)
    Me.LblPadd1.Name = "LblPadd1"
    Me.LblPadd1.Size = New System.Drawing.Size(191, 15)
    Me.LblPadd1.TabIndex = 76
    Me.LblPadd1.Text = "<Padd1>"
    '
    'Label20
    '
    Me.Label20.Location = New System.Drawing.Point(6, 39)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(51, 15)
    Me.Label20.TabIndex = 75
    Me.Label20.Text = "Addr 1"
    '
    'LblPname
    '
    Me.LblPname.Location = New System.Drawing.Point(63, 24)
    Me.LblPname.Name = "LblPname"
    Me.LblPname.Size = New System.Drawing.Size(191, 15)
    Me.LblPname.TabIndex = 74
    Me.LblPname.Text = "<Pname>"
    '
    'Label18
    '
    Me.Label18.Location = New System.Drawing.Point(6, 24)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(51, 15)
    Me.Label18.TabIndex = 73
    Me.Label18.Text = "Name"
    '
    'TpSecondary
    '
    Me.TpSecondary.Controls.Add(Me.LblSbus)
    Me.TpSecondary.Controls.Add(Me.Label30)
    Me.TpSecondary.Controls.Add(Me.LblSconfid)
    Me.TpSecondary.Controls.Add(Me.Label33)
    Me.TpSecondary.Controls.Add(Me.LblSsex)
    Me.TpSecondary.Controls.Add(Me.Label35)
    Me.TpSecondary.Controls.Add(Me.LblSDOB)
    Me.TpSecondary.Controls.Add(Me.Label37)
    Me.TpSecondary.Controls.Add(Me.LblSzip)
    Me.TpSecondary.Controls.Add(Me.Label39)
    Me.TpSecondary.Controls.Add(Me.LblSstate)
    Me.TpSecondary.Controls.Add(Me.Label41)
    Me.TpSecondary.Controls.Add(Me.LblScity)
    Me.TpSecondary.Controls.Add(Me.Label43)
    Me.TpSecondary.Controls.Add(Me.LblSadd2)
    Me.TpSecondary.Controls.Add(Me.Label45)
    Me.TpSecondary.Controls.Add(Me.LblSadd1)
    Me.TpSecondary.Controls.Add(Me.Label47)
    Me.TpSecondary.Controls.Add(Me.LblSname)
    Me.TpSecondary.Controls.Add(Me.Label49)
    Me.TpSecondary.Location = New System.Drawing.Point(4, 22)
    Me.TpSecondary.Name = "TpSecondary"
    Me.TpSecondary.Padding = New System.Windows.Forms.Padding(3)
    Me.TpSecondary.Size = New System.Drawing.Size(265, 155)
    Me.TpSecondary.TabIndex = 1
    Me.TpSecondary.Text = "Secondary"
    Me.TpSecondary.UseVisualStyleBackColor = True
    '
    'LblSbus
    '
    Me.LblSbus.Location = New System.Drawing.Point(226, 9)
    Me.LblSbus.Name = "LblSbus"
    Me.LblSbus.Size = New System.Drawing.Size(20, 15)
    Me.LblSbus.TabIndex = 114
    Me.LblSbus.Text = "<Sbus>"
    '
    'Label30
    '
    Me.Label30.Location = New System.Drawing.Point(167, 8)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(61, 15)
    Me.Label30.TabIndex = 113
    Me.Label30.Text = "Business?"
    '
    'LblSconfid
    '
    Me.LblSconfid.Location = New System.Drawing.Point(63, 129)
    Me.LblSconfid.Name = "LblSconfid"
    Me.LblSconfid.Size = New System.Drawing.Size(47, 15)
    Me.LblSconfid.TabIndex = 112
    Me.LblSconfid.Text = "<Sconfid>"
    '
    'Label33
    '
    Me.Label33.Location = New System.Drawing.Point(6, 129)
    Me.Label33.Name = "Label33"
    Me.Label33.Size = New System.Drawing.Size(51, 15)
    Me.Label33.TabIndex = 111
    Me.Label33.Text = "Confid?"
    '
    'LblSsex
    '
    Me.LblSsex.Location = New System.Drawing.Point(63, 114)
    Me.LblSsex.Name = "LblSsex"
    Me.LblSsex.Size = New System.Drawing.Size(47, 15)
    Me.LblSsex.TabIndex = 110
    Me.LblSsex.Text = "<Ssex>"
    '
    'Label35
    '
    Me.Label35.Location = New System.Drawing.Point(6, 114)
    Me.Label35.Name = "Label35"
    Me.Label35.Size = New System.Drawing.Size(51, 15)
    Me.Label35.TabIndex = 109
    Me.Label35.Text = "Sex"
    '
    'LblSDOB
    '
    Me.LblSDOB.Location = New System.Drawing.Point(63, 100)
    Me.LblSDOB.Name = "LblSDOB"
    Me.LblSDOB.Size = New System.Drawing.Size(68, 14)
    Me.LblSDOB.TabIndex = 108
    Me.LblSDOB.Text = "<SDOB>"
    '
    'Label37
    '
    Me.Label37.Location = New System.Drawing.Point(6, 100)
    Me.Label37.Name = "Label37"
    Me.Label37.Size = New System.Drawing.Size(51, 15)
    Me.Label37.TabIndex = 107
    Me.Label37.Text = "DOB"
    '
    'LblSzip
    '
    Me.LblSzip.Location = New System.Drawing.Point(150, 85)
    Me.LblSzip.Name = "LblSzip"
    Me.LblSzip.Size = New System.Drawing.Size(89, 15)
    Me.LblSzip.TabIndex = 106
    Me.LblSzip.Text = "<Szip>"
    '
    'Label39
    '
    Me.Label39.Location = New System.Drawing.Point(113, 83)
    Me.Label39.Name = "Label39"
    Me.Label39.Size = New System.Drawing.Size(31, 16)
    Me.Label39.TabIndex = 105
    Me.Label39.Text = "Zip"
    '
    'LblSstate
    '
    Me.LblSstate.Location = New System.Drawing.Point(63, 85)
    Me.LblSstate.Name = "LblSstate"
    Me.LblSstate.Size = New System.Drawing.Size(33, 15)
    Me.LblSstate.TabIndex = 104
    Me.LblSstate.Text = "<Sstate>"
    '
    'Label41
    '
    Me.Label41.Location = New System.Drawing.Point(6, 85)
    Me.Label41.Name = "Label41"
    Me.Label41.Size = New System.Drawing.Size(51, 15)
    Me.Label41.TabIndex = 103
    Me.Label41.Text = "State"
    '
    'LblScity
    '
    Me.LblScity.Location = New System.Drawing.Point(63, 70)
    Me.LblScity.Name = "LblScity"
    Me.LblScity.Size = New System.Drawing.Size(191, 15)
    Me.LblScity.TabIndex = 102
    Me.LblScity.Text = "<Scity>"
    '
    'Label43
    '
    Me.Label43.Location = New System.Drawing.Point(6, 70)
    Me.Label43.Name = "Label43"
    Me.Label43.Size = New System.Drawing.Size(51, 15)
    Me.Label43.TabIndex = 101
    Me.Label43.Text = "City"
    '
    'LblSadd2
    '
    Me.LblSadd2.Location = New System.Drawing.Point(63, 54)
    Me.LblSadd2.Name = "LblSadd2"
    Me.LblSadd2.Size = New System.Drawing.Size(191, 15)
    Me.LblSadd2.TabIndex = 100
    Me.LblSadd2.Text = "<Sadd2>"
    '
    'Label45
    '
    Me.Label45.Location = New System.Drawing.Point(6, 54)
    Me.Label45.Name = "Label45"
    Me.Label45.Size = New System.Drawing.Size(51, 15)
    Me.Label45.TabIndex = 99
    Me.Label45.Text = "Addr 2"
    '
    'LblSadd1
    '
    Me.LblSadd1.Location = New System.Drawing.Point(63, 39)
    Me.LblSadd1.Name = "LblSadd1"
    Me.LblSadd1.Size = New System.Drawing.Size(191, 15)
    Me.LblSadd1.TabIndex = 98
    Me.LblSadd1.Text = "<Sadd1>"
    '
    'Label47
    '
    Me.Label47.Location = New System.Drawing.Point(6, 39)
    Me.Label47.Name = "Label47"
    Me.Label47.Size = New System.Drawing.Size(51, 15)
    Me.Label47.TabIndex = 97
    Me.Label47.Text = "Addr 1"
    '
    'LblSname
    '
    Me.LblSname.Location = New System.Drawing.Point(63, 24)
    Me.LblSname.Name = "LblSname"
    Me.LblSname.Size = New System.Drawing.Size(191, 15)
    Me.LblSname.TabIndex = 96
    Me.LblSname.Text = "<Sname>"
    '
    'Label49
    '
    Me.Label49.Location = New System.Drawing.Point(6, 24)
    Me.Label49.Name = "Label49"
    Me.Label49.Size = New System.Drawing.Size(51, 15)
    Me.Label49.TabIndex = 95
    Me.Label49.Text = "Name"
    '
    'TpVehicle
    '
    Me.TpVehicle.Controls.Add(Me.LblRegEndDt)
    Me.TpVehicle.Controls.Add(Me.Label9)
    Me.TpVehicle.Controls.Add(Me.LblRegStrDt)
    Me.TpVehicle.Controls.Add(Me.Label8)
    Me.TpVehicle.Controls.Add(Me.LblClassDesc)
    Me.TpVehicle.Controls.Add(Me.Label10)
    Me.TpVehicle.Controls.Add(Me.LblBody)
    Me.TpVehicle.Controls.Add(Me.Label12)
    Me.TpVehicle.Location = New System.Drawing.Point(4, 22)
    Me.TpVehicle.Name = "TpVehicle"
    Me.TpVehicle.Size = New System.Drawing.Size(265, 155)
    Me.TpVehicle.TabIndex = 2
    Me.TpVehicle.Text = "Vehicle"
    Me.TpVehicle.UseVisualStyleBackColor = True
    '
    'LblRegEndDt
    '
    Me.LblRegEndDt.AutoSize = True
    Me.LblRegEndDt.Location = New System.Drawing.Point(60, 55)
    Me.LblRegEndDt.Name = "LblRegEndDt"
    Me.LblRegEndDt.Size = New System.Drawing.Size(81, 13)
    Me.LblRegEndDt.TabIndex = 108
    Me.LblRegEndDt.Text = "<RegEndDate>"
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(3, 55)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(49, 13)
    Me.Label9.TabIndex = 107
    Me.Label9.Text = "Reg End"
    '
    'LblRegStrDt
    '
    Me.LblRegStrDt.AutoSize = True
    Me.LblRegStrDt.Location = New System.Drawing.Point(60, 42)
    Me.LblRegStrDt.Name = "LblRegStrDt"
    Me.LblRegStrDt.Size = New System.Drawing.Size(84, 13)
    Me.LblRegStrDt.TabIndex = 106
    Me.LblRegStrDt.Text = "<RegStartDate>"
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(3, 42)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(52, 13)
    Me.Label8.TabIndex = 105
    Me.Label8.Text = "Reg Start"
    '
    'LblClassDesc
    '
    Me.LblClassDesc.AutoSize = True
    Me.LblClassDesc.Location = New System.Drawing.Point(60, 27)
    Me.LblClassDesc.Name = "LblClassDesc"
    Me.LblClassDesc.Size = New System.Drawing.Size(69, 13)
    Me.LblClassDesc.TabIndex = 104
    Me.LblClassDesc.Text = "<ClassDesc>"
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(3, 27)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(32, 13)
    Me.Label10.TabIndex = 103
    Me.Label10.Text = "Class"
    '
    'LblBody
    '
    Me.LblBody.AutoSize = True
    Me.LblBody.Location = New System.Drawing.Point(60, 12)
    Me.LblBody.Name = "LblBody"
    Me.LblBody.Size = New System.Drawing.Size(43, 13)
    Me.LblBody.TabIndex = 102
    Me.LblBody.Text = "<Body>"
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(3, 12)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(31, 13)
    Me.Label12.TabIndex = 101
    Me.Label12.Text = "Body"
    '
    'GroupBox6
    '
    Me.GroupBox6.Controls.Add(Me.Label6)
    Me.GroupBox6.Controls.Add(Me.TxtSCust)
    Me.GroupBox6.Controls.Add(Me.Label5)
    Me.GroupBox6.Controls.Add(Me.Label2)
    Me.GroupBox6.Controls.Add(Me.TxtDMVVehID)
    Me.GroupBox6.Controls.Add(Me.TxtPCust)
    Me.GroupBox6.Location = New System.Drawing.Point(641, 117)
    Me.GroupBox6.Name = "GroupBox6"
    Me.GroupBox6.Size = New System.Drawing.Size(149, 72)
    Me.GroupBox6.TabIndex = 225
    Me.GroupBox6.TabStop = False
    Me.GroupBox6.Text = "DMV use only"
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(2, 32)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(57, 13)
    Me.Label6.TabIndex = 225
    Me.Label6.Text = "Sec Cust"
    '
    'TxtSCust
    '
    Me.TxtSCust.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TxtSCust.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TxtSCust.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSCust.ForeColor = System.Drawing.Color.Navy
    Me.TxtSCust.Location = New System.Drawing.Point(68, 31)
    Me.TxtSCust.MaxLength = 20
    Me.TxtSCust.Name = "TxtSCust"
    Me.TxtSCust.ReadOnly = True
    Me.TxtSCust.Size = New System.Drawing.Size(75, 13)
    Me.TxtSCust.TabIndex = 224
    Me.TxtSCust.TabStop = False
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(2, 47)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(37, 13)
    Me.Label5.TabIndex = 223
    Me.Label5.Text = "VehID"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(2, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(57, 13)
    Me.Label2.TabIndex = 173
    Me.Label2.Text = "Prim Cust"
    '
    'TxtDMVVehID
    '
    Me.TxtDMVVehID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TxtDMVVehID.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TxtDMVVehID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDMVVehID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDMVVehID.ForeColor = System.Drawing.Color.Navy
    Me.TxtDMVVehID.Location = New System.Drawing.Point(68, 48)
    Me.TxtDMVVehID.MaxLength = 20
    Me.TxtDMVVehID.Name = "TxtDMVVehID"
    Me.TxtDMVVehID.ReadOnly = True
    Me.TxtDMVVehID.Size = New System.Drawing.Size(75, 13)
    Me.TxtDMVVehID.TabIndex = 172
    Me.TxtDMVVehID.TabStop = False
    '
    'TxtPCust
    '
    Me.TxtPCust.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TxtPCust.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TxtPCust.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPCust.ForeColor = System.Drawing.Color.Navy
    Me.TxtPCust.Location = New System.Drawing.Point(68, 15)
    Me.TxtPCust.MaxLength = 20
    Me.TxtPCust.Name = "TxtPCust"
    Me.TxtPCust.ReadOnly = True
    Me.TxtPCust.Size = New System.Drawing.Size(75, 13)
    Me.TxtPCust.TabIndex = 171
    Me.TxtPCust.TabStop = False
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(663, 23)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(37, 13)
    Me.Label7.TabIndex = 226
    Me.Label7.Text = "VehID"
    '
    'TxtVehID
    '
    Me.TxtVehID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TxtVehID.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TxtVehID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVehID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVehID.ForeColor = System.Drawing.Color.Navy
    Me.TxtVehID.Location = New System.Drawing.Point(709, 23)
    Me.TxtVehID.MaxLength = 20
    Me.TxtVehID.Name = "TxtVehID"
    Me.TxtVehID.ReadOnly = True
    Me.TxtVehID.Size = New System.Drawing.Size(75, 13)
    Me.TxtVehID.TabIndex = 227
    Me.TxtVehID.TabStop = False
    '
    'FrmTXA09DMV
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(802, 426)
    Me.Controls.Add(Me.TxtVehID)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.GroupBox6)
    Me.Controls.Add(Me.TabControl1)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.GrpAddr)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.label1)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA09DMV"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "View DMV Customer"
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpAddr.ResumeLayout(False)
    Me.GrpAddr.PerformLayout()
    Me.TabControl1.ResumeLayout(False)
    Me.TbPrimary.ResumeLayout(False)
    Me.TpSecondary.ResumeLayout(False)
    Me.TpVehicle.ResumeLayout(False)
    Me.TpVehicle.PerformLayout()
    Me.GroupBox6.ResumeLayout(False)
    Me.GroupBox6.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTXA094B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Windows.Forms.Cursor.Current = Cursors.Default

    myTXINV = New TXINV.MyData(myDBConnect)
    myTXINVLC = New TXINVLC.MyData(myDBConnect)
    myTXINVLM = New TXINVLM.MyData(myDBConnect)
    myTXVCUS = New TXVCUS.MyData(myDBConnect)
    myTXVEH = New TXVEH.MyData(myDBConnect)
    myTXVEHL2 = New TXVEHL2.MyData(myDBConnect)
    WrkBlocking = False
    myTXINVLC.CloseFile()
    With MyFrmTXA09
      .TBarView.Enabled = False
    End With
    TxtName.Text = MyFrmTXA09B.LblName.Text
    TxtSname.Text = MyFrmTXA09B.LblSname.Text
    TxtAdd1.Text = MyFrmTXA09B.LblAdd1.Text
    TxtAdd2.Text = MyFrmTXA09B.LblAdd2.Text
    TxtCity.Text = MyFrmTXA09B.LblCity.Text
    TxtState.Text = MyFrmTXA09B.LblState.Text
    TxtZip5.Text = MyFrmTXA09B.LblZip5.Text
    TxtZip4.Text = MyFrmTXA09B.LblZip4.Text
    BuildDS()
    Populate()
    Call FormatGrid()

  End Sub
  Public Sub FormatGrid()

    With C1DataGrdList
      .Rebind(True)
      .DataSource = ds.Tables(0)
    End With

    Call ShowGrid()
  End Sub
  Public Sub ShowGrid()
    With C1DataGrdList
      .Rebind(True)
      .FetchRowStyles = True
      .Columns(0).Caption = "RegNo"
      .Splits(0).DisplayColumns(0).Width = 60
      .Columns(1).Caption = "VehID"
      .Splits(0).DisplayColumns(1).Width = 70
      .Columns(2).Caption = "List #"
      .Splits(0).DisplayColumns(2).Width = 45
      .Columns(3).Caption = "Type"
      .Splits(0).DisplayColumns(3).Width = 35
      .Columns(4).Caption = "Year"
      .Splits(0).DisplayColumns(4).Width = 35
      .Columns(5).Caption = "Description"
      .Splits(0).DisplayColumns(5).Width = 195
      .Columns(6).Caption = "Tax"
      .Splits(0).DisplayColumns(6).Width = 70
      .Columns(7).Caption = "Interest"
      .Splits(0).DisplayColumns(7).Width = 70
      .Columns(8).Caption = "Fee"
      .Splits(0).DisplayColumns(8).Width = 40
      .Columns(9).Caption = "Lien"
      .Splits(0).DisplayColumns(9).Width = 40
      .Columns(10).Caption = "Total"
      .Splits(0).DisplayColumns(10).Width = 70
    End With
  End Sub
  Private Sub FrmTXA09DMV_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA09.SbpScreen.Text = "TXA09DMV"
    With MyFrmTXA09
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub C1DataGrdList_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles C1DataGrdList.FetchRowStyle
    If C1DataGrdList.Columns("Description").CellValue(e.Row) = "* TOTALS *" Then
      e.CellStyle.BackColor = System.Drawing.Color.Aqua
    End If

  End Sub
  Private Sub FrmTXA094B_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTXA09
      .TBarView.Enabled = False
    End With

    MyFrmTXA09B.Show()
    'Memory Cleanup
    ds.Clear()
    ds = Nothing
    MyFrmTXA094B = Nothing
  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("RegNo", Type.GetType("System.String"))
      .Columns.Add("VehID", Type.GetType("System.String"))
      .Columns.Add("List", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int16"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("Tax", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Fee", Type.GetType("System.Decimal"))
      .Columns.Add("Lien", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub Populate()
    Dim mycashint As CASHINT.MyData
    Dim ds2 As DataSet = New DataSet
    Dim ds3 As DataSet = New DataSet
    Dim WrkPcust As Integer
    Dim WrkScust As Integer
    Dim WrkVehID As Integer
    Dim WrkTax As Decimal
    Dim WrkInterest As Decimal
    Dim WrkFee As Decimal
    Dim WrkLien As Decimal
    Dim WrkTotal As Decimal
    Dim myDr As Data.DataRow
    Dim I As Integer
    Dim WrkSVehid As Integer

    mycashint = New CASHINT.MyData(myDBConnect)
    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    myTXINV.GetOneRecordP(MyFrmTXA09B.LblList.Text, MyFrmTXA09B.LblYear.Text, MyFrmTXA09B.LblType.Text)
    WrkPcust = myTXINV._SSNo
    WrkScust = myTXINV._SS2
    WrkVehID = MyUtils.CnvSng(myTXINV._OID)
    TxtPCust.Text = WrkPcust
    TxtVehID.Text = Trim(myTXINV._OID)
    If WrkScust > 0 Then
      TxtSCust.Text = WrkScust
    Else
      TxtSCust.Text = ""
    End If
    WrkSVehid = 0
    ds2 = myTXVEHL2.GetViewbyPcust(WrkPcust, 99999999, 999)
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      If ds2.Tables(0).Rows(I).Item("scust") = WrkScust Then
        WrkSVehid = ds2.Tables(0).Rows(I).Item("vehid")
        Exit For
      End If
    Next
    If ds2.Tables(0).Rows.Count > 0 Then
      If WrkSVehid > 0 Then
        TxtDMVVehID.Text = WrkSVehid
      Else
        TxtDMVVehID.Text = ds2.Tables(0).Rows(0).Item("vehid")
      End If
    End If
    GetDMVPCust(WrkPcust)
    GetDMVSCust(WrkScust)
    GetDMVVeh(WrkVehID)

    ds3 = myTXINVLM.GetAllSSNo(WrkPcust, 100, False)
    For I = 0 To ds3.Tables(0).Rows.Count - 1
      With ds3.Tables(0).Rows(I)
        'If Trim(.Item("mvflag")) = "" And .Item("wbal") <= 0 Then Continue For
        myDr = ds.Tables(0).NewRow
        myDr("List") = .Item("list#")
        myDr("Type") = .Item("type")
        myDr("Year") = .Item("year")
        myTXINV.GetOneRecordP(myDr("list"), myDr("year"), myDr("type"))
        myDr("RegNo") = Trim(myTXINV._IMVREG)
        myDr("VehID") = Trim(myTXINV._OID)
        myDr("Desc") = Trim(myTXINV._MAKE) & " " & Trim(myTXINV._MODEL) & " " & myTXINV._MVYR
      End With
      With mycashint
        .In_IntDate = MyFrmTXA09B.DtPckInt.Value
        .In_ListNo = myDr("list")
        .In_Type = myDr("type")
        .In_Year = myDr("year")
        .CalcInterest()
        myDr("Tax") = Format(.Out_Prin(), "standard")
        myDr("Interest") = Format(.Out_Int(), "standard")
        myDr("Fee") = Format(.Out_Fee(), "standard")
        myDr("Lien") = Format(.Out_Lien(), "standard")
        myDr("Total") = Format(.Out_Tot(), "standard")
      End With
      WrkTax = WrkTax + myDr("Tax")
      WrkInterest = WrkInterest + myDr("Interest")
      WrkFee = WrkFee + myDr("Fee")
      WrkLien = WrkLien + myDr("Lien")
      WrkTotal = WrkTotal + myDr("Total")
      ds.Tables(0).Rows.Add(myDr)
    Next

    'Total Line
    If ds.Tables(0).Rows.Count > 0 Then
      myDr = ds.Tables(0).NewRow
      myDr("Desc") = "* TOTALS *"
      myDr("Tax") = WrkTax
      myDr("Interest") = WrkInterest
      myDr("Lien") = WrkLien
      myDr("Fee") = WrkFee
      myDr("Total") = WrkTotal
      'myDr("Balance") = WrkBalance
      ds.Tables(0).Rows.Add(myDr)
    End If

    ds2 = Nothing
    ds3 = Nothing
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub GetDMVPCust(ByVal WrkPCust As Integer)
    With myTXVCUS
      .GetOneRecordP(WrkPCust)
      LblPname.Text = ._NAME
      LblPbus.Text = ._BUS
      LblPadd1.Text = ._ADD1
      LblPadd2.Text = ._ADD2
      LblPcity.Text = ._CITY
      LblPstate.Text = ._STATE
      LblPzip.Text = ._ZIPA
      If ._DOB > 0 Then
        LblPDOB.Text = MyUtils.GetDBDate(._DOB)
      Else
        LblPDOB.Text = ""
      End If
      LblPsex.Text = ._SEX
      LblPconfid.Text = ._CONFID
    End With
  End Sub
  Private Sub GetDMVSCust(ByVal WrkSCust As Integer)
    With myTXVCUS
      .GetOneRecordP(WrkSCust)
      If .RecordNotFound Then
        TabControl1.TabPages.Remove(TpSecondary)
      Else
        LblSname.Text = ._NAME
        LblSbus.Text = ._BUS
        LblSadd1.Text = ._ADD1
        LblSadd2.Text = ._ADD2
        LblScity.Text = ._CITY
        LblSstate.Text = ._STATE
        LblSzip.Text = ._ZIPA
        If ._DOB > 0 Then
          LblSDOB.Text = MyUtils.GetDBDate(._DOB)
        Else
          LblSDOB.Text = ""
        End If
        LblSsex.Text = ._SEX
        LblSconfid.Text = ._CONFID
      End If
    End With
  End Sub
  Private Sub GetDMVVeh(ByVal WrkVehID As Integer)
    With myTXVEH
      .GetOneRecordP(WrkVehID)
      If .RecordNotFound Then
        TabControl1.TabPages.Remove(TpVehicle)
      Else
        LblBody.Text = ._BODY
        LblClassDesc.Text = ._CLASSD
        If ._STRDT > 0 Then
          LblRegStrDt.Text = MyUtils.GetDBDate(._STRDT)
        Else
          LblRegStrDt.Text = ""
        End If
        If ._ENDDT > 0 Then
          LblRegEndDt.Text = MyUtils.GetDBDate(._ENDDT)
        Else
          LblRegEndDt.Text = ""
        End If
      End If
    End With
  End Sub
End Class






