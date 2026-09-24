Public Class FrmUB102C
  Inherits System.Windows.Forms.Form
  Dim myUTCUST As UTCUST.MyData
  Dim myUTCUSTMT As UTCUSTMT.MyData
  Dim myUTCUSTRT As UTCUSTRT.MyData
  Dim myUTRATEAS As UTRATEAS.MyData
  Dim myUTMETER As UTMETER.MyData
  Dim myUTTYPE As UTTYPE.MyData
  Dim myUTXREF As UTXREF.MyData
  Dim myTAXCOM As TAXCOM.MyData
  Dim myTXREAL As TXREAL.MyData
  Dim myLOGUT As LOGUT.MyData
  Dim dsTAXCOM As DataSet
  Dim dsLog As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend AddMode As Boolean
  Dim LoadScrn As Boolean
  Friend WithEvents TxtSrvDesc As System.Windows.Forms.TextBox
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents ChkRE As System.Windows.Forms.CheckBox
  Friend WithEvents TxtLong As TextBox
  Friend WithEvents Label20 As Label
  Friend WithEvents TxtLat As TextBox
  Friend WithEvents ChkInactive As CheckBox
  Dim StrDebug As String
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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents Label44 As System.Windows.Forms.Label
  Friend WithEvents TxtDist As System.Windows.Forms.TextBox
  Friend WithEvents TxtPhase As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtContract As System.Windows.Forms.TextBox
  Friend WithEvents TxtAppID As System.Windows.Forms.TextBox
  Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
  Friend WithEvents TxtPrevMeterNo As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents TxtRoute As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents TxtPhone As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TxtSerialNo As System.Windows.Forms.TextBox
  Friend WithEvents TxtMeterNo As System.Windows.Forms.TextBox
  Friend WithEvents TxtLoc As System.Windows.Forms.TextBox
  Friend WithEvents TxtLocNo As System.Windows.Forms.TextBox
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtRegion As System.Windows.Forms.TextBox
  Friend WithEvents Label31 As System.Windows.Forms.Label
  Friend WithEvents TxtBillCycle As System.Windows.Forms.TextBox
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents TxtPage As System.Windows.Forms.TextBox
  Friend WithEvents TxtVol As System.Windows.Forms.TextBox
  Friend WithEvents Label28 As System.Windows.Forms.Label
  Friend WithEvents TxtMap As System.Windows.Forms.TextBox
  Friend WithEvents Label27 As System.Windows.Forms.Label
  Friend WithEvents TxtCrossRef As System.Windows.Forms.TextBox
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents TxtZone As System.Windows.Forms.TextBox
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents TxtPropCat As System.Windows.Forms.TextBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents TxtFund As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents TxtSection As System.Windows.Forms.TextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents LnkDistrict As System.Windows.Forms.LinkLabel
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtZip As System.Windows.Forms.TextBox
  Friend WithEvents TxtCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents TxtAdd2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAdd1 As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtMailZip As System.Windows.Forms.TextBox
  Friend WithEvents TxtMailCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtMailState As System.Windows.Forms.TextBox
  Friend WithEvents TxtMailAdd2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtMailAdd1 As System.Windows.Forms.TextBox
  Friend WithEvents Label89 As System.Windows.Forms.Label
  Friend WithEvents Label90 As System.Windows.Forms.Label
  Friend WithEvents TxtSname As System.Windows.Forms.TextBox
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUB102C))
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.Label44 = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.TxtPhase = New System.Windows.Forms.TextBox()
    Me.TxtContract = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtAppID = New System.Windows.Forms.TextBox()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.TxtPrevMeterNo = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.TxtRoute = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TxtPhone = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtSerialNo = New System.Windows.Forms.TextBox()
    Me.TxtMeterNo = New System.Windows.Forms.TextBox()
    Me.TxtLoc = New System.Windows.Forms.TextBox()
    Me.TxtLocNo = New System.Windows.Forms.TextBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtRegion = New System.Windows.Forms.TextBox()
    Me.Label31 = New System.Windows.Forms.Label()
    Me.TxtBillCycle = New System.Windows.Forms.TextBox()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.TxtPage = New System.Windows.Forms.TextBox()
    Me.TxtVol = New System.Windows.Forms.TextBox()
    Me.Label28 = New System.Windows.Forms.Label()
    Me.TxtMap = New System.Windows.Forms.TextBox()
    Me.Label27 = New System.Windows.Forms.Label()
    Me.TxtCrossRef = New System.Windows.Forms.TextBox()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.TxtZone = New System.Windows.Forms.TextBox()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.TxtPropCat = New System.Windows.Forms.TextBox()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.TxtFund = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TxtSection = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.LnkDistrict = New System.Windows.Forms.LinkLabel()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.TxtZip = New System.Windows.Forms.TextBox()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtAdd2 = New System.Windows.Forms.TextBox()
    Me.TxtAdd1 = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.TxtMailZip = New System.Windows.Forms.TextBox()
    Me.TxtMailCity = New System.Windows.Forms.TextBox()
    Me.TxtMailState = New System.Windows.Forms.TextBox()
    Me.TxtMailAdd2 = New System.Windows.Forms.TextBox()
    Me.TxtMailAdd1 = New System.Windows.Forms.TextBox()
    Me.Label89 = New System.Windows.Forms.Label()
    Me.Label90 = New System.Windows.Forms.Label()
    Me.TxtSname = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.TxtSrvDesc = New System.Windows.Forms.TextBox()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.ChkRE = New System.Windows.Forms.CheckBox()
    Me.TxtLat = New System.Windows.Forms.TextBox()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.TxtLong = New System.Windows.Forms.TextBox()
    Me.ChkInactive = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(16, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(57, 13)
    Me.Label1.TabIndex = 13
    Me.Label1.Text = "Account #"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label44
    '
    Me.Label44.AutoSize = True
    Me.Label44.BackColor = System.Drawing.SystemColors.Control
    Me.Label44.Location = New System.Drawing.Point(284, 12)
    Me.Label44.Name = "Label44"
    Me.Label44.Size = New System.Drawing.Size(37, 13)
    Me.Label44.TabIndex = 11
    Me.Label44.Text = "Phase"
    '
    'TxtDist
    '
    Me.TxtDist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDist.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(232, 8)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(32, 22)
    Me.TxtDist.TabIndex = 1
    '
    'TxtPhase
    '
    Me.TxtPhase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPhase.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhase.Location = New System.Drawing.Point(328, 8)
    Me.TxtPhase.MaxLength = 1
    Me.TxtPhase.Name = "TxtPhase"
    Me.TxtPhase.Size = New System.Drawing.Size(16, 22)
    Me.TxtPhase.TabIndex = 2
    '
    'TxtContract
    '
    Me.TxtContract.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtContract.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtContract.Location = New System.Drawing.Point(104, 272)
    Me.TxtContract.MaxLength = 10
    Me.TxtContract.Name = "TxtContract"
    Me.TxtContract.Size = New System.Drawing.Size(88, 22)
    Me.TxtContract.TabIndex = 7
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(8, 276)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(56, 16)
    Me.Label7.TabIndex = 219
    Me.Label7.Text = "Contract"
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(404, 276)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(80, 16)
    Me.Label8.TabIndex = 1
    Me.Label8.Text = "Application ID"
    '
    'TxtAppID
    '
    Me.TxtAppID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAppID.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAppID.Location = New System.Drawing.Point(488, 272)
    Me.TxtAppID.MaxLength = 10
    Me.TxtAppID.Name = "TxtAppID"
    Me.TxtAppID.Size = New System.Drawing.Size(88, 22)
    Me.TxtAppID.TabIndex = 17
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(104, 8)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(64, 22)
    Me.TxtListNo.TabIndex = 0
    '
    'TxtPrevMeterNo
    '
    Me.TxtPrevMeterNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPrevMeterNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPrevMeterNo.Location = New System.Drawing.Point(488, 344)
    Me.TxtPrevMeterNo.MaxLength = 20
    Me.TxtPrevMeterNo.Name = "TxtPrevMeterNo"
    Me.TxtPrevMeterNo.Size = New System.Drawing.Size(168, 22)
    Me.TxtPrevMeterNo.TabIndex = 20
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(396, 348)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(96, 16)
    Me.Label13.TabIndex = 289
    Me.Label13.Text = "Previous Meter #"
    '
    'TxtRoute
    '
    Me.TxtRoute.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRoute.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRoute.Location = New System.Drawing.Point(488, 320)
    Me.TxtRoute.MaxLength = 15
    Me.TxtRoute.Name = "TxtRoute"
    Me.TxtRoute.Size = New System.Drawing.Size(128, 22)
    Me.TxtRoute.TabIndex = 19
    '
    'Label12
    '
    Me.Label12.BackColor = System.Drawing.SystemColors.Control
    Me.Label12.Location = New System.Drawing.Point(444, 324)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(40, 12)
    Me.Label12.TabIndex = 288
    Me.Label12.Text = "Route"
    '
    'TxtPhone
    '
    Me.TxtPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPhone.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhone.Location = New System.Drawing.Point(488, 296)
    Me.TxtPhone.MaxLength = 15
    Me.TxtPhone.Name = "TxtPhone"
    Me.TxtPhone.Size = New System.Drawing.Size(128, 22)
    Me.TxtPhone.TabIndex = 18
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(444, 300)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(40, 16)
    Me.Label10.TabIndex = 287
    Me.Label10.Text = "Phone"
    '
    'TxtSerialNo
    '
    Me.TxtSerialNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSerialNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSerialNo.Location = New System.Drawing.Point(104, 320)
    Me.TxtSerialNo.MaxLength = 25
    Me.TxtSerialNo.Name = "TxtSerialNo"
    Me.TxtSerialNo.Size = New System.Drawing.Size(208, 22)
    Me.TxtSerialNo.TabIndex = 10
    '
    'TxtMeterNo
    '
    Me.TxtMeterNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMeterNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMeterNo.Location = New System.Drawing.Point(104, 344)
    Me.TxtMeterNo.MaxLength = 20
    Me.TxtMeterNo.Name = "TxtMeterNo"
    Me.TxtMeterNo.Size = New System.Drawing.Size(168, 22)
    Me.TxtMeterNo.TabIndex = 11
    '
    'TxtLoc
    '
    Me.TxtLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLoc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLoc.Location = New System.Drawing.Point(176, 296)
    Me.TxtLoc.MaxLength = 25
    Me.TxtLoc.Name = "TxtLoc"
    Me.TxtLoc.Size = New System.Drawing.Size(208, 22)
    Me.TxtLoc.TabIndex = 9
    '
    'TxtLocNo
    '
    Me.TxtLocNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocNo.Location = New System.Drawing.Point(104, 296)
    Me.TxtLocNo.MaxLength = 7
    Me.TxtLocNo.Name = "TxtLocNo"
    Me.TxtLocNo.Size = New System.Drawing.Size(64, 22)
    Me.TxtLocNo.TabIndex = 8
    '
    'Label17
    '
    Me.Label17.Location = New System.Drawing.Point(8, 324)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(88, 16)
    Me.Label17.TabIndex = 286
    Me.Label17.Text = "Serial # / MTR"
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(8, 348)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(88, 16)
    Me.Label9.TabIndex = 285
    Me.Label9.Text = "Meter # / MIU"
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(8, 300)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(88, 16)
    Me.Label6.TabIndex = 284
    Me.Label6.Text = "Location#/Name"
    '
    'TxtRegion
    '
    Me.TxtRegion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRegion.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRegion.Location = New System.Drawing.Point(488, 440)
    Me.TxtRegion.MaxLength = 2
    Me.TxtRegion.Name = "TxtRegion"
    Me.TxtRegion.Size = New System.Drawing.Size(24, 22)
    Me.TxtRegion.TabIndex = 25
    '
    'Label31
    '
    Me.Label31.AutoSize = True
    Me.Label31.Location = New System.Drawing.Point(441, 444)
    Me.Label31.Name = "Label31"
    Me.Label31.Size = New System.Drawing.Size(41, 13)
    Me.Label31.TabIndex = 283
    Me.Label31.Text = "Region"
    '
    'TxtBillCycle
    '
    Me.TxtBillCycle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBillCycle.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBillCycle.Location = New System.Drawing.Point(104, 440)
    Me.TxtBillCycle.MaxLength = 25
    Me.TxtBillCycle.Name = "TxtBillCycle"
    Me.TxtBillCycle.Size = New System.Drawing.Size(24, 22)
    Me.TxtBillCycle.TabIndex = 15
    '
    'Label30
    '
    Me.Label30.Location = New System.Drawing.Point(8, 444)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(88, 16)
    Me.Label30.TabIndex = 281
    Me.Label30.Text = "Billing Cycle"
    '
    'TxtPage
    '
    Me.TxtPage.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPage.Location = New System.Drawing.Point(544, 416)
    Me.TxtPage.MaxLength = 5
    Me.TxtPage.Name = "TxtPage"
    Me.TxtPage.Size = New System.Drawing.Size(48, 22)
    Me.TxtPage.TabIndex = 24
    '
    'TxtVol
    '
    Me.TxtVol.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVol.Location = New System.Drawing.Point(488, 416)
    Me.TxtVol.MaxLength = 5
    Me.TxtVol.Name = "TxtVol"
    Me.TxtVol.Size = New System.Drawing.Size(48, 22)
    Me.TxtVol.TabIndex = 23
    '
    'Label28
    '
    Me.Label28.AutoSize = True
    Me.Label28.Location = New System.Drawing.Point(424, 420)
    Me.Label28.Name = "Label28"
    Me.Label28.Size = New System.Drawing.Size(52, 13)
    Me.Label28.TabIndex = 279
    Me.Label28.Text = "Vol/Page"
    '
    'TxtMap
    '
    Me.TxtMap.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMap.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMap.Location = New System.Drawing.Point(104, 416)
    Me.TxtMap.MaxLength = 17
    Me.TxtMap.Name = "TxtMap"
    Me.TxtMap.Size = New System.Drawing.Size(144, 22)
    Me.TxtMap.TabIndex = 14
    '
    'Label27
    '
    Me.Label27.Location = New System.Drawing.Point(8, 420)
    Me.Label27.Name = "Label27"
    Me.Label27.Size = New System.Drawing.Size(88, 16)
    Me.Label27.TabIndex = 278
    Me.Label27.Text = "Map"
    '
    'TxtCrossRef
    '
    Me.TxtCrossRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCrossRef.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCrossRef.Location = New System.Drawing.Point(104, 368)
    Me.TxtCrossRef.MaxLength = 20
    Me.TxtCrossRef.Name = "TxtCrossRef"
    Me.TxtCrossRef.Size = New System.Drawing.Size(168, 22)
    Me.TxtCrossRef.TabIndex = 12
    '
    'Label19
    '
    Me.Label19.Location = New System.Drawing.Point(8, 372)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(88, 16)
    Me.Label19.TabIndex = 276
    Me.Label19.Text = "Cross Ref #"
    '
    'TxtZone
    '
    Me.TxtZone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtZone.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZone.Location = New System.Drawing.Point(488, 392)
    Me.TxtZone.MaxLength = 5
    Me.TxtZone.Name = "TxtZone"
    Me.TxtZone.Size = New System.Drawing.Size(48, 22)
    Me.TxtZone.TabIndex = 22
    '
    'Label18
    '
    Me.Label18.AutoSize = True
    Me.Label18.Location = New System.Drawing.Point(444, 396)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(32, 13)
    Me.Label18.TabIndex = 275
    Me.Label18.Text = "Zone"
    '
    'TxtPropCat
    '
    Me.TxtPropCat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPropCat.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPropCat.Location = New System.Drawing.Point(104, 392)
    Me.TxtPropCat.MaxLength = 5
    Me.TxtPropCat.Name = "TxtPropCat"
    Me.TxtPropCat.Size = New System.Drawing.Size(48, 22)
    Me.TxtPropCat.TabIndex = 13
    '
    'Label14
    '
    Me.Label14.Location = New System.Drawing.Point(8, 396)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(96, 16)
    Me.Label14.TabIndex = 274
    Me.Label14.Text = "Property Category"
    '
    'TxtFund
    '
    Me.TxtFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFund.Location = New System.Drawing.Point(104, 464)
    Me.TxtFund.MaxLength = 3
    Me.TxtFund.Name = "TxtFund"
    Me.TxtFund.Size = New System.Drawing.Size(32, 22)
    Me.TxtFund.TabIndex = 16
    '
    'Label11
    '
    Me.Label11.Location = New System.Drawing.Point(8, 468)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(88, 16)
    Me.Label11.TabIndex = 293
    Me.Label11.Text = "Fund"
    '
    'TxtSection
    '
    Me.TxtSection.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSection.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSection.Location = New System.Drawing.Point(584, 440)
    Me.TxtSection.MaxLength = 3
    Me.TxtSection.Name = "TxtSection"
    Me.TxtSection.Size = New System.Drawing.Size(32, 22)
    Me.TxtSection.TabIndex = 26
    '
    'Label15
    '
    Me.Label15.Location = New System.Drawing.Point(538, 444)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(48, 16)
    Me.Label15.TabIndex = 295
    Me.Label15.Text = "Section"
    '
    'LnkDistrict
    '
    Me.LnkDistrict.Location = New System.Drawing.Point(184, 12)
    Me.LnkDistrict.Name = "LnkDistrict"
    Me.LnkDistrict.Size = New System.Drawing.Size(40, 16)
    Me.LnkDistrict.TabIndex = 296
    Me.LnkDistrict.TabStop = True
    Me.LnkDistrict.Text = "District"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.TxtZip)
    Me.GroupBox1.Controls.Add(Me.TxtCity)
    Me.GroupBox1.Controls.Add(Me.TxtState)
    Me.GroupBox1.Controls.Add(Me.TxtAdd2)
    Me.GroupBox1.Controls.Add(Me.TxtAdd1)
    Me.GroupBox1.Controls.Add(Me.Label4)
    Me.GroupBox1.Controls.Add(Me.Label3)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox1.Location = New System.Drawing.Point(8, 88)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(464, 88)
    Me.GroupBox1.TabIndex = 5
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Street Address"
    '
    'TxtZip
    '
    Me.TxtZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtZip.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip.Location = New System.Drawing.Point(368, 64)
    Me.TxtZip.MaxLength = 10
    Me.TxtZip.Name = "TxtZip"
    Me.TxtZip.Size = New System.Drawing.Size(88, 22)
    Me.TxtZip.TabIndex = 4
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(96, 64)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(232, 22)
    Me.TxtCity.TabIndex = 2
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(336, 64)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 22)
    Me.TxtState.TabIndex = 3
    '
    'TxtAdd2
    '
    Me.TxtAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd2.Location = New System.Drawing.Point(96, 40)
    Me.TxtAdd2.MaxLength = 35
    Me.TxtAdd2.Name = "TxtAdd2"
    Me.TxtAdd2.Size = New System.Drawing.Size(288, 22)
    Me.TxtAdd2.TabIndex = 1
    '
    'TxtAdd1
    '
    Me.TxtAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd1.Location = New System.Drawing.Point(96, 16)
    Me.TxtAdd1.MaxLength = 35
    Me.TxtAdd1.Name = "TxtAdd1"
    Me.TxtAdd1.Size = New System.Drawing.Size(288, 22)
    Me.TxtAdd1.TabIndex = 0
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label4.Location = New System.Drawing.Point(8, 68)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(80, 16)
    Me.Label4.TabIndex = 39
    Me.Label4.Text = "City/State/Zip"
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label3.Location = New System.Drawing.Point(8, 20)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(80, 16)
    Me.Label3.TabIndex = 38
    Me.Label3.Text = "Address"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.TxtMailZip)
    Me.GroupBox2.Controls.Add(Me.TxtMailCity)
    Me.GroupBox2.Controls.Add(Me.TxtMailState)
    Me.GroupBox2.Controls.Add(Me.TxtMailAdd2)
    Me.GroupBox2.Controls.Add(Me.TxtMailAdd1)
    Me.GroupBox2.Controls.Add(Me.Label89)
    Me.GroupBox2.Controls.Add(Me.Label90)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox2.Location = New System.Drawing.Point(8, 176)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(464, 88)
    Me.GroupBox2.TabIndex = 6
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Mailing Address"
    '
    'TxtMailZip
    '
    Me.TxtMailZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMailZip.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMailZip.Location = New System.Drawing.Point(330, 64)
    Me.TxtMailZip.MaxLength = 10
    Me.TxtMailZip.Name = "TxtMailZip"
    Me.TxtMailZip.Size = New System.Drawing.Size(88, 22)
    Me.TxtMailZip.TabIndex = 4
    '
    'TxtMailCity
    '
    Me.TxtMailCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMailCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMailCity.Location = New System.Drawing.Point(96, 64)
    Me.TxtMailCity.MaxLength = 20
    Me.TxtMailCity.Name = "TxtMailCity"
    Me.TxtMailCity.Size = New System.Drawing.Size(196, 22)
    Me.TxtMailCity.TabIndex = 2
    '
    'TxtMailState
    '
    Me.TxtMailState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMailState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMailState.Location = New System.Drawing.Point(298, 64)
    Me.TxtMailState.MaxLength = 2
    Me.TxtMailState.Name = "TxtMailState"
    Me.TxtMailState.Size = New System.Drawing.Size(24, 22)
    Me.TxtMailState.TabIndex = 3
    '
    'TxtMailAdd2
    '
    Me.TxtMailAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMailAdd2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMailAdd2.Location = New System.Drawing.Point(96, 40)
    Me.TxtMailAdd2.MaxLength = 35
    Me.TxtMailAdd2.Name = "TxtMailAdd2"
    Me.TxtMailAdd2.Size = New System.Drawing.Size(288, 22)
    Me.TxtMailAdd2.TabIndex = 1
    '
    'TxtMailAdd1
    '
    Me.TxtMailAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMailAdd1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMailAdd1.Location = New System.Drawing.Point(96, 16)
    Me.TxtMailAdd1.MaxLength = 35
    Me.TxtMailAdd1.Name = "TxtMailAdd1"
    Me.TxtMailAdd1.Size = New System.Drawing.Size(288, 22)
    Me.TxtMailAdd1.TabIndex = 0
    '
    'Label89
    '
    Me.Label89.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label89.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label89.Location = New System.Drawing.Point(8, 68)
    Me.Label89.Name = "Label89"
    Me.Label89.Size = New System.Drawing.Size(80, 16)
    Me.Label89.TabIndex = 298
    Me.Label89.Text = "City/State/Zip"
    '
    'Label90
    '
    Me.Label90.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label90.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label90.Location = New System.Drawing.Point(8, 20)
    Me.Label90.Name = "Label90"
    Me.Label90.Size = New System.Drawing.Size(88, 16)
    Me.Label90.TabIndex = 297
    Me.Label90.Text = "Address"
    '
    'TxtSname
    '
    Me.TxtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSname.Location = New System.Drawing.Point(104, 64)
    Me.TxtSname.MaxLength = 35
    Me.TxtSname.Name = "TxtSname"
    Me.TxtSname.Size = New System.Drawing.Size(288, 22)
    Me.TxtSname.TabIndex = 4
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(104, 40)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(288, 22)
    Me.TxtName.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(16, 64)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(80, 16)
    Me.Label2.TabIndex = 302
    Me.Label2.Text = "Second Name"
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(16, 40)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(48, 16)
    Me.Label5.TabIndex = 301
    Me.Label5.Text = "Name"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.C1DataGrdList)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.ForeColor = System.Drawing.Color.Maroon
    Me.GroupBox3.Location = New System.Drawing.Point(512, 8)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(216, 200)
    Me.GroupBox3.TabIndex = 304
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Select Bill Type"
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColMove = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AllowUpdate = False
    Me.C1DataGrdList.AlternatingRows = True
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(8, 16)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.MeasurementDevice = C1.Win.C1TrueDBGrid.PrintInfo.MeasurementDeviceEnum.Screen
    Me.C1DataGrdList.PrintInfo.MeasurementPrinterName = Nothing
    Me.C1DataGrdList.Size = New System.Drawing.Size(200, 176)
    Me.C1DataGrdList.TabIndex = 304
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    '
    'TxtSrvDesc
    '
    Me.TxtSrvDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSrvDesc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSrvDesc.Location = New System.Drawing.Point(488, 368)
    Me.TxtSrvDesc.MaxLength = 35
    Me.TxtSrvDesc.Name = "TxtSrvDesc"
    Me.TxtSrvDesc.Size = New System.Drawing.Size(240, 22)
    Me.TxtSrvDesc.TabIndex = 21
    '
    'Label16
    '
    Me.Label16.AutoSize = True
    Me.Label16.Location = New System.Drawing.Point(404, 372)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(74, 13)
    Me.Label16.TabIndex = 306
    Me.Label16.Text = "Service Descr"
    '
    'ChkRE
    '
    Me.ChkRE.AutoSize = True
    Me.ChkRE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkRE.Location = New System.Drawing.Point(512, 221)
    Me.ChkRE.Name = "ChkRE"
    Me.ChkRE.Size = New System.Drawing.Size(219, 17)
    Me.ChkRE.TabIndex = 307
    Me.ChkRE.Text = "Address updated when checked (Bridge)"
    Me.ChkRE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    Me.ChkRE.UseVisualStyleBackColor = True
    '
    'TxtLat
    '
    Me.TxtLat.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLat.Location = New System.Drawing.Point(488, 464)
    Me.TxtLat.MaxLength = 10
    Me.TxtLat.Name = "TxtLat"
    Me.TxtLat.Size = New System.Drawing.Size(88, 22)
    Me.TxtLat.TabIndex = 27
    '
    'Label20
    '
    Me.Label20.AutoSize = True
    Me.Label20.Location = New System.Drawing.Point(385, 468)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(97, 13)
    Me.Label20.TabIndex = 309
    Me.Label20.Text = "Latitude/Longitude"
    '
    'TxtLong
    '
    Me.TxtLong.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLong.Location = New System.Drawing.Point(582, 464)
    Me.TxtLong.MaxLength = 10
    Me.TxtLong.Name = "TxtLong"
    Me.TxtLong.Size = New System.Drawing.Size(88, 22)
    Me.TxtLong.TabIndex = 28
    '
    'ChkInactive
    '
    Me.ChkInactive.AutoSize = True
    Me.ChkInactive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkInactive.Location = New System.Drawing.Point(414, 13)
    Me.ChkInactive.Name = "ChkInactive"
    Me.ChkInactive.Size = New System.Drawing.Size(70, 17)
    Me.ChkInactive.TabIndex = 310
    Me.ChkInactive.Text = "Inactive?"
    Me.ChkInactive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    Me.ChkInactive.UseVisualStyleBackColor = True
    '
    'FrmUB102C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(742, 493)
    Me.Controls.Add(Me.ChkInactive)
    Me.Controls.Add(Me.TxtLong)
    Me.Controls.Add(Me.Label20)
    Me.Controls.Add(Me.TxtLat)
    Me.Controls.Add(Me.ChkRE)
    Me.Controls.Add(Me.TxtSrvDesc)
    Me.Controls.Add(Me.Label16)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.TxtSname)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.LnkDistrict)
    Me.Controls.Add(Me.TxtSection)
    Me.Controls.Add(Me.Label15)
    Me.Controls.Add(Me.TxtFund)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.TxtPrevMeterNo)
    Me.Controls.Add(Me.TxtRoute)
    Me.Controls.Add(Me.TxtPhone)
    Me.Controls.Add(Me.TxtSerialNo)
    Me.Controls.Add(Me.TxtMeterNo)
    Me.Controls.Add(Me.TxtLoc)
    Me.Controls.Add(Me.TxtLocNo)
    Me.Controls.Add(Me.TxtRegion)
    Me.Controls.Add(Me.TxtBillCycle)
    Me.Controls.Add(Me.TxtPage)
    Me.Controls.Add(Me.TxtVol)
    Me.Controls.Add(Me.TxtMap)
    Me.Controls.Add(Me.TxtCrossRef)
    Me.Controls.Add(Me.TxtZone)
    Me.Controls.Add(Me.TxtPropCat)
    Me.Controls.Add(Me.TxtListNo)
    Me.Controls.Add(Me.TxtAppID)
    Me.Controls.Add(Me.TxtContract)
    Me.Controls.Add(Me.TxtPhase)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.Label17)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label31)
    Me.Controls.Add(Me.Label30)
    Me.Controls.Add(Me.Label28)
    Me.Controls.Add(Me.Label27)
    Me.Controls.Add(Me.Label19)
    Me.Controls.Add(Me.Label18)
    Me.Controls.Add(Me.Label14)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Label44)
    Me.Controls.Add(Me.Label1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmUB102C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Customer "
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmUB102C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkAttachCount As Integer   'added 9-18-25 ken

    myUTCUST = New UTCUST.MyData(myDBConnect)
    myUTCUSTMT = New UTCUSTMT.MyData(myDBConnect)
    myUTCUSTRT = New UTCUSTRT.MyData(myDBConnect)
    myUTRATEAS = New UTRATEAS.MyData(myDBConnect)
    myUTMETER = New UTMETER.MyData(myDBConnect)
    myUTTYPE = New UTTYPE.MyData(myDBConnect)
    myUTXREF = New UTXREF.MyData(myDBConnect)
    myTAXCOM = New TAXCOM.MyData(myDBConnect)
    myTXREAL = New TXREAL.MyData(myDBConnect)
    myLOGUT = New LOGUT.MyData(myDBConnect)

    LoadScrn = True
    MyFrmUB102.TBarNew.Enabled = False
    MyFrmUB102.TBarSave.Enabled = True
    MyFrmUB102.TBarComments.Enabled = False
    MyFrmUB102.TBarAttach.Enabled = True   ' added 9-18-25 ken

    'New record
    If AddMode Then
      Me.Text = "Add " & Me.Text
      MyFrmUB102.TBarDelete.Enabled = False
      LoadScrn = False
      Exit Sub
    End If

    TxtListNo.Text = WrkListNo
    TxtListNo.ReadOnly = True
    TxtListNo.TabStop = False
    TxtListNo.BackColor = Color.Aqua

    If s_chg = False And s_full = False Then  '#sec
      MyFrmUB102.TBarSave.Visible = False  '#sec
    End If  '#sec

    'Fill the dataset with the data
    Me.Text = "Maintain " & Me.Text
    MyFrmUB102.TBarDelete.Enabled = True
    myUTCUST.GetOneRecordP(WrkListNo)

    If myUTCUST.RecordNotFound Then
      MyFrmUB102.TBarNew.Enabled = False
      MyFrmUB102.TBarSave.Enabled = False
      MyFrmUB102.TBarDelete.Enabled = False
      Me.ErrProv.SetError(TxtListNo, "Record not found")
      Exit Sub
    End If
    'begin add 9-18-25 ken
    MyFrmUB102.TBarComments.Enabled = True
    WrkAttachCount = GetAttachcount("UB102", "" & MyUtils.CnvSng(WrkListNo))
    MyFrmUB102.TBarAttach.Text = WrkAttachCount & " Attachment(s)"
    ' end add 9-18-25 ken
    With myUTCUST
      TxtContract.Text = Trim(._CUCNTNO)
      TxtAppID.Text = Trim(._CUAPLNO)
      TxtName.Text = Trim(._CUNAM1)
      TxtSname.Text = Trim(._CUNAM2)
      TxtAdd1.Text = Trim(._CUADD1)
      TxtAdd2.Text = Trim(._CUADD2)
      TxtCity.Text = Trim(._CUCITY)
      TxtState.Text = Trim(._CUST)
      TxtPhone.Text = Trim(._CUTELNO)
      TxtZip.Text = Trim(._CUZIP)
      TxtDist.Text = ._CUDST
      TxtPhase.Text = ._CUPHAS
      TxtMailAdd1.Text = Trim(._CUMAD1)
      TxtMailAdd2.Text = Trim(._CUMAD2)
      TxtMailCity.Text = Trim(._CUMCTY)
      TxtMailState.Text = Trim(._CUMST)
      TxtMailZip.Text = Trim(._CUMZIP)
      TxtLocNo.Text = Trim(._CULOCNO)
      TxtLoc.Text = Trim(._CULOC)
      TxtSerialNo.Text = Trim(._CUSERN)
      TxtRoute.Text = Trim(._CUROUT)
      TxtMeterNo.Text = Trim(._CUMETN)
      TxtPrevMeterNo.Text = Trim(._CUMETP)
      TxtPropCat.Text = Trim(._CUPCAT)
      TxtCrossRef.Text = Trim(._CUXREF)
      TxtZone.Text = Trim(._CUZONE)
      TxtMap.Text = Trim(._CUMAP)
      TxtVol.Text = Trim(._CUVOLM)
      TxtPage.Text = Trim(._CUPAGE)
      TxtBillCycle.Text = Trim(._CYC)
      TxtRegion.Text = Trim(._CUREGN)
      TxtFund.Text = ._CUFUND
      TxtSection.Text = Trim(._CUSECT)
      TxtSrvDesc.Text = Trim(._CUSDES)
      If ._CULAT <> 0 Then
        TxtLat.Text = ._CULAT
      End If
      If ._CULONG <> 0 Then
        TxtLong.Text = ._CULONG
      End If
      'MK 7/17/25 Begin
      ChkInactive.Checked = False
      If ._RCODE = "I" Then
        ChkInactive.Checked = True
      End If
      'MK 7/17/25 End
    End With

    myTXREAL.GetOneRecordP(WrkListNo)
    If Not myTXREAL.RecordNotFound Then
      With myTXREAL
        If ._SEWER = "Y" Then ChkRE.Checked = True
      End With
    End If

    dsTAXCOM = myTAXCOM.Getcomments(WrkListNo, "U", 0)
    MyFrmUB102.TBarComments.ImageKey = ""
    If dsTAXCOM.Tables(0).Rows.Count > 0 Then
      MyFrmUB102.TBarComments.ImageKey = "comment_24.png"
    End If

    FormatGrid()
    LoadScrn = False
  End Sub

  Private Sub FrmUB102C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmUB102.TBarNew.Enabled = True
    MyFrmUB102.TBarSave.Enabled = False
    MyFrmUB102.TBarDelete.Enabled = False
    MyFrmUB102.TBarSave.Visible = True   '#sec
    MyFrmUB102.TBarComments.Enabled = False
    MyFrmUB102.TBarAttach.Enabled = False
    MyFrmUB102.TBarAttach.Text = "Attachments"
    MyFrmUB102.TBarLog.Enabled = False
    MyFrmUB102B.FormatGrid(True, False, False)
    MyFrmUB102B.Show()
    'Memory Cleanup
    myUTCUST = Nothing
    myUTCUSTMT = Nothing
    myUTCUSTRT = Nothing
    myUTRATEAS = Nothing
    myUTMETER = Nothing
    myUTTYPE = Nothing
    myTAXCOM = Nothing
    MyFrmUB102C = Nothing
  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim myUTCUSTAS As UTCUSTAS.MyData
    myUTCUSTAS = New UTCUSTAS.MyData(myDBConnect)

    Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    myLOGUT.GetOneRecordP(WrkListNo, 0, 0)
    MoveToLog("Delete")
    myLOGUT.AddOneRecordP()
    myUTCUSTAS.DeleteListNo(WrkListNo)
    myUTCUSTMT.DeleteListNo(WrkListNo)
    myUTCUSTRT.DeleteListNo(WrkListNo)
    myTAXCOM.DeleteKeyComment(WrkListNo, "U", 0)
    myUTXREF.DeleteAcct(WrkListNo, "")
    myUTCUST.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim dslog As DataSet = New DataSet
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String

    If AddMode Then
      WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    End If

    myUTCUST.GetOneRecordP(WrkListNo)
    If AddMode Then
      If Not myUTCUST.RecordNotFound Then
        Me.ErrProv.SetError(TxtListNo, "Record already exists")
        Exit Sub
      End If
    End If

    If Not AddMode Then
      dsLog = myLOGUT.PosData(WrkListNo, 0, 0, 1)
      If dsLog.Tables(0).Rows.Count = 0 Then
        MoveToLog("Original")
        myLOGUT.AddOneRecordP()
      End If
      MoveToFile()
      MoveToLog("Change")
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myUTCUST.UpdateOneRecordP()
        If myUTCUST.ErrMsg <> "" Then
          WriteErrorLog(myUTCUST.ErrMsg)
          Exit Sub
        End If
        myLOGUT.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      MoveToFile()
      MoveToLog("Add")
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myUTCUST.AddOneRecordP()
        If myUTCUST.ErrMsg <> "" Then
          WriteErrorLog(myUTCUST.ErrMsg)
          Exit Sub
        End If
        myLOGUT.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    myTXREAL.GetOneRecordP(WrkListNo)
    If Not myTXREAL.RecordNotFound Then
      With myTXREAL
        If ChkRE.Checked Then
          ._SEWER = "Y"
        Else
          ._SEWER = "N"
        End If
        .UpdateOneRecordP()
      End With
    End If

    If AddMode Then
      MyFrmUB102.TBarComments.Enabled = True
      'Clear errors and reset default color
      ShowError(ErrorField, ErrorMsg)
      Me.ForeColor = Color.Black
      AddMode = False
      FormatGrid()
    Else
      Me.Close()
    End If

  End Sub
  Private Sub MoveToFile()
    With myUTCUST
      If AddMode Then
        ._CUACCT = MyUtils.CnvSng(TxtListNo.Text)
      End If
      ._CUCNTNO = TxtContract.Text
      ._CUAPLNO = TxtAppID.Text
      ._CUNAM1 = TxtName.Text
      ._CUNAM2 = TxtSname.Text
      ._CUADD1 = TxtAdd1.Text
      ._CUADD2 = TxtAdd2.Text
      ._CUCITY = TxtCity.Text
      ._CUST = TxtState.Text
      ._CUZIP = TxtZip.Text
      ._CUTELNO = TxtPhone.Text
      ._CUDST = MyUtils.CnvSng(TxtDist.Text)
      ._CUPHAS = MyUtils.CnvSng(TxtPhase.Text)
      ._CUMAD1 = TxtMailAdd1.Text
      ._CUMAD2 = TxtMailAdd2.Text
      ._CUMCTY = TxtMailCity.Text
      ._CUMST = TxtMailState.Text
      ._CUMZIP = TxtMailZip.Text
      ._CULOCNO = MyUtils.JustifyRight(TxtLocNo.Text, 7)
      ._CULOC = TxtLoc.Text
      ._CUSERN = TxtSerialNo.Text
      ._CUXREF = TxtCrossRef.Text
      ._CUZONE = TxtZone.Text
      ._CUROUT = TxtRoute.Text
      ._CUMETN = TxtMeterNo.Text
      ._CUMETP = TxtPrevMeterNo.Text
      ._CUPCAT = TxtPropCat.Text
      ._CUMAP = TxtMap.Text
      ._CUVOLM = TxtVol.Text
      ._CUPAGE = TxtPage.Text
      ._CYC = TxtBillCycle.Text
      ._CUREGN = TxtRegion.Text
      ._CUFUND = MyUtils.CnvSng(TxtFund.Text)
      ._CUSECT = TxtSection.Text
      ._CUSDES = TxtSrvDesc.Text
      ._CULAT = MyUtils.CnvSng(TxtLat.Text)
      ._CULONG = MyUtils.CnvSng(TxtLong.Text)
      'MK 7/17/25 Begin
      If ChkInactive.Checked Then
        ._RCODE = "I"
      Else
        ._RCODE = ""
      End If
      'MK 7/17/25 End
    End With
  End Sub
  Private Sub MoveToLog(ByVal WrkMode As String)
CheckFile:
    With myLOGUT
      .GetOneRecordP(WrkListNo, MyUtils.SetDBDate(DateTime.Today), Format(DateTime.Now, "HHmmss"))
      If .RecordNotFound Then
        ._CUACCT = myUTCUST._CUACCT
        ._CUADDX = myUTCUST._CUADDX
        ._CUAPLNO = myUTCUST._CUAPLNO
        ._CUCNTNO = myUTCUST._CUCNTNO
        ._CUNAM1 = myUTCUST._CUNAM1
        ._CUNAM2 = myUTCUST._CUNAM2
        ._CUADD1 = myUTCUST._CUADD1
        ._CUADD2 = myUTCUST._CUADD2
        ._CUCITY = myUTCUST._CUCITY
        ._CUST = myUTCUST._CUST
        ._CUZIP = myUTCUST._CUZIP
        ._CUTELNO = myUTCUST._CUTELNO
        ._CUDST = myUTCUST._CUDST
        ._CUPHAS = myUTCUST._CUPHAS
        ._CUMAD1 = myUTCUST._CUMAD1
        ._CUMAD2 = myUTCUST._CUMAD2
        ._CUMCTY = myUTCUST._CUMCTY
        ._CUMSIZ = myUTCUST._CUMSIZ & ""
        ._CUMST = myUTCUST._CUMST
        ._CUMZIP = myUTCUST._CUMZIP
        ._CULOCNO = myUTCUST._CULOCNO
        ._CULOC = myUTCUST._CULOC
        ._CUSERN = myUTCUST._CUSERN
        ._CUXREF = myUTCUST._CUXREF
        ._CUZONE = myUTCUST._CUZONE
        ._CUROUT = myUTCUST._CUROUT
        ._CUMETN = myUTCUST._CUMETN
        ._CUMETP = myUTCUST._CUMETP
        ._CUPCAT = myUTCUST._CUPCAT
        ._CUMAP = myUTCUST._CUMAP
        ._CUVOLM = myUTCUST._CUVOLM
        ._CUPAGE = myUTCUST._CUPAGE
        ._CYC = myUTCUST._CYC
        ._CUREGN = myUTCUST._CUREGN
        ._CUFUND = myUTCUST._CUFUND
        ._CUSECT = myUTCUST._CUSECT
        ._CUSDES = myUTCUST._CUSDES
        ._LOGDTE = MyUtils.SetDBDate(DateTime.Today)
        ._LOGTIM = Format(DateTime.Now, "HHmmss")
        Select Case WrkMode
          Case "Add"
            ._LOGCMT = "Record Added"
          Case "Change"
            ._LOGCMT = "Record Changed"
          Case "Delete"
            ._LOGCMT = "Record Deleted"
          Case Else
            ._LOGCMT = "Original Record"
        End Select
        ._OID = myUTCUST._OID
      Else
        Threading.Thread.Sleep(1000)
        GoTo CheckFile
      End If
    End With

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtListNo, "")
    ErrProv.SetError(TxtName, "")
    ErrProv.SetError(TxtAdd1, "")
    ErrProv.SetError(TxtCity, "")
    ErrProv.SetError(TxtState, "")
    ErrProv.SetError(TxtZip, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
        Case "cuacct"
          ErrProv.SetError(TxtListNo, ErrorMsg(I))
        Case "cunam1"
          ErrProv.SetError(TxtName, ErrorMsg(I))
        Case "cuadd1"
          ErrProv.SetError(TxtAdd1, ErrorMsg(I))
        Case "cucity"
          ErrProv.SetError(TxtCity, ErrorMsg(I))
        Case "cust"
          ErrProv.SetError(TxtState, ErrorMsg(I))
        Case "cuzip"
          ErrProv.SetError(TxtZip, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtListNo.Text) = 0 Then
      ErrorField(I) = "cuacct"
      ErrorMsg(I) = "Account number cannot be zero"
      I = I + 1
    End If

    If TxtName.Text = "" Then
      ErrorField(I) = "cunam1"
      ErrorMsg(I) = "Name cannot be blank"
      I = I + 1
    End If

    If TxtAdd1.Text = "" Then
      ErrorField(I) = "cuadd1"
      ErrorMsg(I) = "Address 1 cannot be blank"
      I = I + 1
    End If

    If TxtCity.Text = "" Then
      ErrorField(I) = "cucity"
      ErrorMsg(I) = "City cannot be blank"
      I = I + 1
    End If

    'If TxtState.Text = "" Then
    '	ErrorField(I) = "cust"
    '	ErrorMsg(I) = "State is required"
    '	I = I + 1
    'End If

    If TxtZip.Text = "" Then
      ErrorField(I) = "cuzip"
      ErrorMsg(I) = "Zip cannot be blank"
      I = I + 1
    End If
  End Sub
  Private Sub FrmUB102C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    MyFrmUB102.TBarLog.Enabled = False
    dsLog = myLOGUT.GetAllList(WrkListNo)
    If dsLog.Tables(0).Rows.Count > 0 Then
      MyFrmUB102.TBarLog.Enabled = True
    End If
    'change log
    MyFrmLOG = New FrmLOG
    MyFrmLOG.WrkListNo = MyFrmUB102C.WrkListNo
    MyFrmLOG.ds = MyFrmUB102C.dsLog
    MyFrmLOG.WrkType = ""

    MyFrmUB102.SbpScreen.Text = "UB102C"
    MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmUB102
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub TxtDist_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtPhase_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPhase.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFund_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFund.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtLat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLat.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtLong_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLong.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub LnkDistrict_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDistrict.LinkClicked
    MyFrmListDist = New FrmListDist
    MyFrmListDist.MdiParent = Me.ParentForm
    MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
    MyFrmListDist.WrkPhase = MyUtils.CnvSng(TxtPhase.Text)
    MyFrmListDist.Show()
    Me.Hide()
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()

    With C1DataGrdList
      .Rebind(True)
      .Splits(0).DisplayColumns(0).Visible = False
      .Splits(0).DisplayColumns(1).Visible = False
      .Columns(2).Caption = "Description"
      .Splits(0).DisplayColumns(2).Width = 130
      .Columns(3).Caption = "Code"
      .Splits(0).DisplayColumns(3).Width = 35
      '   .Columns(4).Caption = "Bill Amt"
      '   .Splits(0).DisplayColumns(4).Width = 60
      .Splits(0).DisplayColumns(4).Visible = False
    End With

  End Sub
  Public Sub ShowGrid()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim dr As DataRow
    Dim I As Integer

    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Family", Type.GetType("System.String"))
      .Columns.Add("UBType", Type.GetType("System.String"))
      .Columns.Add("BillDesc", Type.GetType("System.String"))
      .Columns.Add("Code", Type.GetType("System.String"))
      .Columns.Add("BillAmt", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)

    ds2 = myUTTYPE.GetAllData
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        myUTCUSTRT.GetOneRecordP(WrkListNo, .Item("tytype"))
        ds.Tables(0).NewRow()
        dr = ds.Tables(0).NewRow
        dr("Family") = .Item("tyuttp")
        dr("UBType") = .Item("tytype")
        dr("BillDesc") = .Item("tydesc")
        If Not myUTCUSTRT.RecordNotFound Then
          dr("Code") = myUTCUSTRT._CRCODE
        Else
          dr("Code") = ""
        End If
        dr("BillAmt") = 0
        ds.Tables(0).Rows.Add(dr)
      End With
    Next

    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Dim WrkType As String

    WrkType = C1DataGrdList.Item(C1DataGrdList.Row, 0)
    Select Case WrkType
      Case "A"
        MyFrmUB102AS = New FrmUB102AS

        MyFrmUB102AS.WrkListNo = WrkListNo
        MyFrmUB102AS.WrkFamily = C1DataGrdList.Item(C1DataGrdList.Row, 0)
        MyFrmUB102AS.WrkUBType = C1DataGrdList.Item(C1DataGrdList.Row, 1)
        MyFrmUB102AS.WrkDesc = C1DataGrdList.Item(C1DataGrdList.Row, 2)
        MyFrmUB102AS.MdiParent = Me.ParentForm
        MyFrmUB102AS.Show()
        Me.Hide()
      Case "M"
        MyFrmUB102MT = New FrmUB102MT

        MyFrmUB102MT.WrkListNo = WrkListNo
        MyFrmUB102MT.WrkFamily = C1DataGrdList.Item(C1DataGrdList.Row, 0)
        MyFrmUB102MT.WrkUBType = C1DataGrdList.Item(C1DataGrdList.Row, 1)
        MyFrmUB102MT.WrkDesc = C1DataGrdList.Item(C1DataGrdList.Row, 2)
        MyFrmUB102MT.MdiParent = Me.ParentForm
        MyFrmUB102MT.Show()
        Me.Hide()
      Case "U"
        MyFrmUB102US = New FrmUB102US

        MyFrmUB102US.WrkListNo = WrkListNo
        MyFrmUB102US.WrkFamily = C1DataGrdList.Item(C1DataGrdList.Row, 0)
        MyFrmUB102US.WrkUBType = C1DataGrdList.Item(C1DataGrdList.Row, 1)
        MyFrmUB102US.WrkDesc = C1DataGrdList.Item(C1DataGrdList.Row, 2)
        MyFrmUB102US.MdiParent = Me.ParentForm
        MyFrmUB102US.Show()
        Me.Hide()
    End Select

  End Sub

End Class
