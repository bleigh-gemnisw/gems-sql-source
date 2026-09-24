Public Class FrmTXA09B
  Inherits System.Windows.Forms.Form
  Dim myTXINV As TXINV.MyData
  Dim myTXINVDTL As TXINVDTL.MyData
  Dim myTXINV2 As TXINV.MyData
  Dim myTXMRATE As TXMRATE.MyData
  Dim myTXPROF As TXPROF.MyData
  Dim myTXCOEA As TXCOEA.MyData
  'MK 9/25/25 Begin
  Dim myTXCOEBL1 As TXCOEBL1.MyData
  'MK 9/25/25 End
  Dim mytxbatchl1 As TXBATCHL1.MyData
  Dim myTAXCOM As TAXCOM.MyData
  Dim ds2 As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkType As String
  Dim WrkICode As String
  Friend WithEvents LnkBenefits As System.Windows.Forms.LinkLabel
  Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
  Friend WithEvents LnkUBA As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkCrVehicle As System.Windows.Forms.LinkLabel
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents LblBond As System.Windows.Forms.Label
  Friend WithEvents LnkStatus As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkFee As System.Windows.Forms.LinkLabel
  Dim WrkCashIntDebug As String
  Friend WithEvents LblUnPostedFee As System.Windows.Forms.Label
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents LblColAgency As System.Windows.Forms.Label
  Friend WithEvents LblProperty3 As System.Windows.Forms.Label
  Friend WithEvents LblPrtDist As System.Windows.Forms.Label
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents LblCAFee As System.Windows.Forms.Label
  Friend WithEvents LnkDMV As System.Windows.Forms.LinkLabel
  Friend WithEvents BtnPayment As System.Windows.Forms.Button
  Friend WithEvents BtnHistory As System.Windows.Forms.Button
  Friend WithEvents BtnCCHistory As System.Windows.Forms.Button
  Friend WithEvents BtnDupBill As System.Windows.Forms.Button
  Friend WithEvents BtnLetter As System.Windows.Forms.Button
  Friend WithEvents BtnLienRel As System.Windows.Forms.Button
  Friend WithEvents BtnTotal As System.Windows.Forms.Button
  Friend WithEvents BtnAdjust As System.Windows.Forms.Button
  Friend WithEvents BtnComments As System.Windows.Forms.Button
  Friend WithEvents BtnPayCredit As System.Windows.Forms.Button
  Friend WithEvents TxtRegno As System.Windows.Forms.TextBox
  Friend WithEvents TxtVIN As System.Windows.Forms.TextBox
  Friend WithEvents LblCCNet As System.Windows.Forms.Label
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents BtnPDFBill As System.Windows.Forms.Button
  Friend WithEvents LnkDeferred As LinkLabel
  Friend WithEvents btndetail As Button
  Friend WithEvents LblCCBillDate As Label
  Friend WithEvents Label23 As Label
  Dim WrkMVFee As Decimal

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
  Friend WithEvents LblProperty2 As System.Windows.Forms.Label
  Friend WithEvents Label47 As System.Windows.Forms.Label
  Friend WithEvents LblBankCd As System.Windows.Forms.Label
  Friend WithEvents GrpCC As System.Windows.Forms.GroupBox
  Friend WithEvents LblCCDate As System.Windows.Forms.Label
  Friend WithEvents LblCCExempt As System.Windows.Forms.Label
  Friend WithEvents LblCCGross As System.Windows.Forms.Label
  Friend WithEvents LblCCTax4 As System.Windows.Forms.Label
  Friend WithEvents LblCCTax3 As System.Windows.Forms.Label
  Friend WithEvents LblCCTax2 As System.Windows.Forms.Label
  Friend WithEvents LblCCTax1 As System.Windows.Forms.Label
  Friend WithEvents LblCCNo As System.Windows.Forms.Label
  Friend WithEvents LblCCTaxt As System.Windows.Forms.Label
  Friend WithEvents Label33 As System.Windows.Forms.Label
  Friend WithEvents Label32 As System.Windows.Forms.Label
  Friend WithEvents Label31 As System.Windows.Forms.Label
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
  Friend WithEvents Label41 As System.Windows.Forms.Label
  Friend WithEvents Label42 As System.Windows.Forms.Label
  Friend WithEvents GrpTax As System.Windows.Forms.GroupBox
  Friend WithEvents LblTax4 As System.Windows.Forms.Label
  Friend WithEvents LblTax3 As System.Windows.Forms.Label
  Friend WithEvents LblTax2 As System.Windows.Forms.Label
  Friend WithEvents LblTax1 As System.Windows.Forms.Label
  Friend WithEvents LblTaxt As System.Windows.Forms.Label
  Friend WithEvents LblTax1Txt As System.Windows.Forms.Label
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
  Friend WithEvents LblRemain As System.Windows.Forms.Label
  Friend WithEvents LblUnposted As System.Windows.Forms.Label
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents LblPayDate As System.Windows.Forms.Label
  Friend WithEvents LblIntPaid As System.Windows.Forms.Label
  Friend WithEvents LblTotpay As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents LblProperty As System.Windows.Forms.Label
  Friend WithEvents LblZip4 As System.Windows.Forms.Label
  Friend WithEvents LblZip5 As System.Windows.Forms.Label
  Friend WithEvents LblState As System.Windows.Forms.Label
  Friend WithEvents LblCity As System.Windows.Forms.Label
  Friend WithEvents LblAdd2 As System.Windows.Forms.Label
  Friend WithEvents LblAdd1 As System.Windows.Forms.Label
  Friend WithEvents LblSname As System.Windows.Forms.Label
  Friend WithEvents LblName As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents LblType As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents LblYear As System.Windows.Forms.Label
  Friend WithEvents LblList As System.Windows.Forms.Label
  Friend WithEvents GrpPropValues As System.Windows.Forms.GroupBox
  Friend WithEvents LblNet As System.Windows.Forms.Label
  Friend WithEvents LblExempt As System.Windows.Forms.Label
  Friend WithEvents LblGross As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents label37 As System.Windows.Forms.Label
  Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents label27 As System.Windows.Forms.Label
  Friend WithEvents label26 As System.Windows.Forms.Label
  Friend WithEvents label25 As System.Windows.Forms.Label
  Friend WithEvents label24 As System.Windows.Forms.Label
  Friend WithEvents label10 As System.Windows.Forms.Label
  Friend WithEvents label9 As System.Windows.Forms.Label
  Friend WithEvents label8 As System.Windows.Forms.Label
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents LblAssmnt As System.Windows.Forms.Label
  Friend WithEvents LblDOB As System.Windows.Forms.Label
  Friend WithEvents LblPuton As System.Windows.Forms.Label
  Friend WithEvents LblStatus As System.Windows.Forms.Label
  Friend WithEvents LblProDate As System.Windows.Forms.Label
  Friend WithEvents LblTax As System.Windows.Forms.Label
  Friend WithEvents LblLien As System.Windows.Forms.Label
  Friend WithEvents LblDue As System.Windows.Forms.Label
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents DtPckInt As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label34 As System.Windows.Forms.Label
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents LblInterest As System.Windows.Forms.Label
  Friend WithEvents LblDist As System.Windows.Forms.Label
  Friend WithEvents Label43 As System.Windows.Forms.Label
  Friend WithEvents LblPhase As System.Windows.Forms.Label
  Friend WithEvents Label44 As System.Windows.Forms.Label
  Friend WithEvents BtnPrevious As System.Windows.Forms.Button
  Friend WithEvents BtnNext As System.Windows.Forms.Button
  Friend WithEvents LblAssmntTxt As System.Windows.Forms.Label
  Friend WithEvents LblDOBTxt As System.Windows.Forms.Label
  Friend WithEvents LblProDateTxt As System.Windows.Forms.Label
  Friend WithEvents LblUnpostedInt As System.Windows.Forms.Label
  Friend WithEvents Label36 As System.Windows.Forms.Label
  Friend WithEvents LblMsg As System.Windows.Forms.Label
  Friend WithEvents LblSuscd As System.Windows.Forms.Label
  Friend WithEvents LblSusdt As System.Windows.Forms.Label
  Friend WithEvents LblUnpostedLien As System.Windows.Forms.Label
  Friend WithEvents Label38 As System.Windows.Forms.Label
  Friend WithEvents LblCCTax4Txt As System.Windows.Forms.Label
  Friend WithEvents LblCCTax3Txt As System.Windows.Forms.Label
  Friend WithEvents LblCCTax2Txt As System.Windows.Forms.Label
  Friend WithEvents LblTax4Txt As System.Windows.Forms.Label
  Friend WithEvents LblTax3Txt As System.Windows.Forms.Label
  Friend WithEvents LblTax2Txt As System.Windows.Forms.Label
  Friend WithEvents LblComment As System.Windows.Forms.Label
  Friend WithEvents LblComments As System.Windows.Forms.Label
  Friend WithEvents LblBeforeCC As System.Windows.Forms.Label
  Friend WithEvents LblFee As System.Windows.Forms.Label
  Friend WithEvents LblBondPaid As System.Windows.Forms.Label
  Friend WithEvents LblBondPaidHdr As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTXA09B))
    Me.LblProperty2 = New System.Windows.Forms.Label()
    Me.Label47 = New System.Windows.Forms.Label()
    Me.LblBankCd = New System.Windows.Forms.Label()
    Me.GrpCC = New System.Windows.Forms.GroupBox()
        Me.LblCCBillDate = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.LblCCNet = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.LblBeforeCC = New System.Windows.Forms.Label()
        Me.LblCCDate = New System.Windows.Forms.Label()
        Me.LblCCExempt = New System.Windows.Forms.Label()
        Me.LblCCGross = New System.Windows.Forms.Label()
        Me.LblCCTax4 = New System.Windows.Forms.Label()
        Me.LblCCTax3 = New System.Windows.Forms.Label()
        Me.LblCCTax2 = New System.Windows.Forms.Label()
        Me.LblCCTax1 = New System.Windows.Forms.Label()
        Me.LblCCNo = New System.Windows.Forms.Label()
        Me.LblCCTaxt = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.LblCCTax4Txt = New System.Windows.Forms.Label()
        Me.LblCCTax3Txt = New System.Windows.Forms.Label()
        Me.LblCCTax2Txt = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.LnkDMV = New System.Windows.Forms.LinkLabel()
        Me.LnkStatus = New System.Windows.Forms.LinkLabel()
        Me.LblSusdt = New System.Windows.Forms.Label()
        Me.LblAssmnt = New System.Windows.Forms.Label()
        Me.LblDOB = New System.Windows.Forms.Label()
        Me.LblPuton = New System.Windows.Forms.Label()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.LblProDate = New System.Windows.Forms.Label()
        Me.LblSuscd = New System.Windows.Forms.Label()
        Me.LblProDateTxt = New System.Windows.Forms.Label()
        Me.LblAssmntTxt = New System.Windows.Forms.Label()
        Me.LblDOBTxt = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.GrpTax = New System.Windows.Forms.GroupBox()
        Me.LblTax4 = New System.Windows.Forms.Label()
        Me.LblTax3 = New System.Windows.Forms.Label()
        Me.LblTax2 = New System.Windows.Forms.Label()
        Me.LblTax1 = New System.Windows.Forms.Label()
        Me.LblTaxt = New System.Windows.Forms.Label()
        Me.LblTax4Txt = New System.Windows.Forms.Label()
        Me.LblTax3Txt = New System.Windows.Forms.Label()
        Me.LblTax2Txt = New System.Windows.Forms.Label()
        Me.LblTax1Txt = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.LblUnPostedFee = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LblUnpostedLien = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.LblUnpostedInt = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.LblRemain = New System.Windows.Forms.Label()
        Me.LblUnposted = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.LblBondPaidHdr = New System.Windows.Forms.Label()
        Me.LblBondPaid = New System.Windows.Forms.Label()
        Me.LblPayDate = New System.Windows.Forms.Label()
        Me.LblIntPaid = New System.Windows.Forms.Label()
        Me.LblTotpay = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LblProperty = New System.Windows.Forms.Label()
        Me.LblZip4 = New System.Windows.Forms.Label()
        Me.LblZip5 = New System.Windows.Forms.Label()
        Me.LblState = New System.Windows.Forms.Label()
        Me.LblCity = New System.Windows.Forms.Label()
        Me.LblAdd2 = New System.Windows.Forms.Label()
        Me.LblAdd1 = New System.Windows.Forms.Label()
        Me.LblSname = New System.Windows.Forms.Label()
        Me.LblName = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblType = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblYear = New System.Windows.Forms.Label()
        Me.LblList = New System.Windows.Forms.Label()
        Me.GrpPropValues = New System.Windows.Forms.GroupBox()
        Me.LblNet = New System.Windows.Forms.Label()
        Me.LblExempt = New System.Windows.Forms.Label()
        Me.LblGross = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.label37 = New System.Windows.Forms.Label()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.LnkFee = New System.Windows.Forms.LinkLabel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblBond = New System.Windows.Forms.Label()
        Me.LblDue = New System.Windows.Forms.Label()
        Me.LblLien = New System.Windows.Forms.Label()
        Me.LblInterest = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.label27 = New System.Windows.Forms.Label()
        Me.label26 = New System.Windows.Forms.Label()
        Me.label25 = New System.Windows.Forms.Label()
        Me.label24 = New System.Windows.Forms.Label()
        Me.LblTax = New System.Windows.Forms.Label()
        Me.LblFee = New System.Windows.Forms.Label()
        Me.label10 = New System.Windows.Forms.Label()
        Me.label9 = New System.Windows.Forms.Label()
        Me.label8 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.DtPckInt = New System.Windows.Forms.DateTimePicker()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.LblDist = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.LblPhase = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.BtnPrevious = New System.Windows.Forms.Button()
        Me.BtnNext = New System.Windows.Forms.Button()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.LblComment = New System.Windows.Forms.Label()
        Me.LblComments = New System.Windows.Forms.Label()
        Me.LnkBenefits = New System.Windows.Forms.LinkLabel()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.LnkUBA = New System.Windows.Forms.LinkLabel()
        Me.LnkCrVehicle = New System.Windows.Forms.LinkLabel()
        Me.LblColAgency = New System.Windows.Forms.Label()
        Me.LblProperty3 = New System.Windows.Forms.Label()
        Me.LblPrtDist = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.LblCAFee = New System.Windows.Forms.Label()
        Me.BtnPayment = New System.Windows.Forms.Button()
        Me.BtnHistory = New System.Windows.Forms.Button()
        Me.BtnCCHistory = New System.Windows.Forms.Button()
        Me.BtnDupBill = New System.Windows.Forms.Button()
        Me.BtnLetter = New System.Windows.Forms.Button()
        Me.BtnLienRel = New System.Windows.Forms.Button()
        Me.BtnTotal = New System.Windows.Forms.Button()
        Me.BtnAdjust = New System.Windows.Forms.Button()
        Me.BtnComments = New System.Windows.Forms.Button()
        Me.BtnPayCredit = New System.Windows.Forms.Button()
        Me.TxtRegno = New System.Windows.Forms.TextBox()
        Me.TxtVIN = New System.Windows.Forms.TextBox()
        Me.BtnPDFBill = New System.Windows.Forms.Button()
        Me.LnkDeferred = New System.Windows.Forms.LinkLabel()
        Me.btndetail = New System.Windows.Forms.Button()
        Me.GrpCC.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GrpTax.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GrpPropValues.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblProperty2
        '
        Me.LblProperty2.BackColor = System.Drawing.SystemColors.Control
        Me.LblProperty2.Location = New System.Drawing.Point(104, 184)
        Me.LblProperty2.Name = "LblProperty2"
        Me.LblProperty2.Size = New System.Drawing.Size(304, 16)
        Me.LblProperty2.TabIndex = 161
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.SystemColors.Control
        Me.Label47.Location = New System.Drawing.Point(360, 56)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(48, 12)
        Me.Label47.TabIndex = 160
        Me.Label47.Text = "Bank Cd"
        '
        'LblBankCd
        '
        Me.LblBankCd.BackColor = System.Drawing.SystemColors.Control
        Me.LblBankCd.Location = New System.Drawing.Point(372, 72)
        Me.LblBankCd.Name = "LblBankCd"
        Me.LblBankCd.Size = New System.Drawing.Size(24, 16)
        Me.LblBankCd.TabIndex = 159
        '
        'GrpCC
        '
        Me.GrpCC.BackColor = System.Drawing.SystemColors.Control
        Me.GrpCC.Controls.Add(Me.LblCCBillDate)
        Me.GrpCC.Controls.Add(Me.Label23)
        Me.GrpCC.Controls.Add(Me.LblCCNet)
        Me.GrpCC.Controls.Add(Me.Label20)
        Me.GrpCC.Controls.Add(Me.LblBeforeCC)
        Me.GrpCC.Controls.Add(Me.LblCCDate)
        Me.GrpCC.Controls.Add(Me.LblCCExempt)
        Me.GrpCC.Controls.Add(Me.LblCCGross)
        Me.GrpCC.Controls.Add(Me.LblCCTax4)
        Me.GrpCC.Controls.Add(Me.LblCCTax3)
        Me.GrpCC.Controls.Add(Me.LblCCTax2)
        Me.GrpCC.Controls.Add(Me.LblCCTax1)
        Me.GrpCC.Controls.Add(Me.LblCCNo)
        Me.GrpCC.Controls.Add(Me.LblCCTaxt)
        Me.GrpCC.Controls.Add(Me.Label33)
        Me.GrpCC.Controls.Add(Me.Label32)
        Me.GrpCC.Controls.Add(Me.Label31)
        Me.GrpCC.Controls.Add(Me.LblCCTax4Txt)
        Me.GrpCC.Controls.Add(Me.LblCCTax3Txt)
        Me.GrpCC.Controls.Add(Me.LblCCTax2Txt)
        Me.GrpCC.Controls.Add(Me.Label29)
        Me.GrpCC.Controls.Add(Me.Label30)
        Me.GrpCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpCC.Location = New System.Drawing.Point(592, 152)
        Me.GrpCC.Name = "GrpCC"
        Me.GrpCC.Size = New System.Drawing.Size(200, 212)
        Me.GrpCC.TabIndex = 157
        Me.GrpCC.TabStop = False
        Me.GrpCC.Text = "C/C Information"
        '
        'LblCCBillDate
        '
        Me.LblCCBillDate.BackColor = System.Drawing.SystemColors.Control
        Me.LblCCBillDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCCBillDate.Location = New System.Drawing.Point(112, 56)
        Me.LblCCBillDate.Name = "LblCCBillDate"
        Me.LblCCBillDate.Size = New System.Drawing.Size(64, 16)
        Me.LblCCBillDate.TabIndex = 178
        Me.LblCCBillDate.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.SystemColors.Control
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(8, 56)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(60, 16)
        Me.Label23.TabIndex = 177
        Me.Label23.Text = " Bill Date"
        '
        'LblCCNet
        '
        Me.LblCCNet.BackColor = System.Drawing.SystemColors.Control
        Me.LblCCNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCCNet.Location = New System.Drawing.Point(80, 193)
        Me.LblCCNet.Name = "LblCCNet"
        Me.LblCCNet.Size = New System.Drawing.Size(84, 16)
        Me.LblCCNet.TabIndex = 176
        Me.LblCCNet.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.Control
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(8, 192)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 16)
        Me.Label20.TabIndex = 175
        Me.Label20.Text = "Net"
        '
        'LblBeforeCC
        '
        Me.LblBeforeCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBeforeCC.ForeColor = System.Drawing.Color.Magenta
        Me.LblBeforeCC.Location = New System.Drawing.Point(8, 16)
        Me.LblBeforeCC.Name = "LblBeforeCC"
        Me.LblBeforeCC.Size = New System.Drawing.Size(184, 13)
        Me.LblBeforeCC.TabIndex = 174
        Me.LblBeforeCC.Text = "Before Bill C/C Applied"
        Me.LblBeforeCC.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblCCDate
        '
        Me.LblCCDate.BackColor = System.Drawing.SystemColors.Control
        Me.LblCCDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCCDate.Location = New System.Drawing.Point(112, 40)
        Me.LblCCDate.Name = "LblCCDate"
        Me.LblCCDate.Size = New System.Drawing.Size(64, 16)
        Me.LblCCDate.TabIndex = 134
        Me.LblCCDate.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblCCExempt
        '
        Me.LblCCExempt.BackColor = System.Drawing.SystemColors.Control
        Me.LblCCExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCCExempt.Location = New System.Drawing.Point(80, 176)
        Me.LblCCExempt.Name = "LblCCExempt"
        Me.LblCCExempt.Size = New System.Drawing.Size(84, 16)
        Me.LblCCExempt.TabIndex = 133
        Me.LblCCExempt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblCCGross
        '
        Me.LblCCGross.BackColor = System.Drawing.SystemColors.Control
        Me.LblCCGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCCGross.Location = New System.Drawing.Point(80, 160)
        Me.LblCCGross.Name = "LblCCGross"
        Me.LblCCGross.Size = New System.Drawing.Size(84, 16)
        Me.LblCCGross.TabIndex = 132
        Me.LblCCGross.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblCCTax4
        '
        Me.LblCCTax4.BackColor = System.Drawing.SystemColors.Control
        Me.LblCCTax4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCCTax4.Location = New System.Drawing.Point(80, 136)
        Me.LblCCTax4.Name = "LblCCTax4"
        Me.LblCCTax4.Size = New System.Drawing.Size(84, 16)
        Me.LblCCTax4.TabIndex = 131
        Me.LblCCTax4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblCCTax3
        '
        Me.LblCCTax3.BackColor = System.Drawing.SystemColors.Control
        Me.LblCCTax3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCCTax3.Location = New System.Drawing.Point(80, 120)
        Me.LblCCTax3.Name = "LblCCTax3"
        Me.LblCCTax3.Size = New System.Drawing.Size(84, 16)
        Me.LblCCTax3.TabIndex = 130
        Me.LblCCTax3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblCCTax2
        '
        Me.LblCCTax2.BackColor = System.Drawing.SystemColors.Control
        Me.LblCCTax2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCCTax2.Location = New System.Drawing.Point(80, 104)
        Me.LblCCTax2.Name = "LblCCTax2"
        Me.LblCCTax2.Size = New System.Drawing.Size(84, 16)
        Me.LblCCTax2.TabIndex = 129
        Me.LblCCTax2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblCCTax1
        '
        Me.LblCCTax1.BackColor = System.Drawing.SystemColors.Control
        Me.LblCCTax1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCCTax1.Location = New System.Drawing.Point(80, 88)
        Me.LblCCTax1.Name = "LblCCTax1"
        Me.LblCCTax1.Size = New System.Drawing.Size(84, 16)
        Me.LblCCTax1.TabIndex = 128
        Me.LblCCTax1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblCCNo
        '
        Me.LblCCNo.BackColor = System.Drawing.SystemColors.Control
        Me.LblCCNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCCNo.Location = New System.Drawing.Point(64, 40)
        Me.LblCCNo.Name = "LblCCNo"
        Me.LblCCNo.Size = New System.Drawing.Size(40, 16)
        Me.LblCCNo.TabIndex = 127
        Me.LblCCNo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblCCTaxt
        '
        Me.LblCCTaxt.BackColor = System.Drawing.SystemColors.Control
        Me.LblCCTaxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCCTaxt.Location = New System.Drawing.Point(80, 72)
        Me.LblCCTaxt.Name = "LblCCTaxt"
        Me.LblCCTaxt.Size = New System.Drawing.Size(84, 16)
        Me.LblCCTaxt.TabIndex = 126
        Me.LblCCTaxt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.SystemColors.Control
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(8, 176)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(48, 16)
        Me.Label33.TabIndex = 15
        Me.Label33.Text = "Exempt"
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.SystemColors.Control
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(8, 160)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(48, 16)
        Me.Label32.TabIndex = 13
        Me.Label32.Text = "Gross"
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.SystemColors.Control
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(8, 40)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(60, 16)
        Me.Label31.TabIndex = 11
        Me.Label31.Text = "No/Date"
        '
        'LblCCTax4Txt
        '
        Me.LblCCTax4Txt.BackColor = System.Drawing.SystemColors.Control
        Me.LblCCTax4Txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCCTax4Txt.Location = New System.Drawing.Point(8, 136)
        Me.LblCCTax4Txt.Name = "LblCCTax4Txt"
        Me.LblCCTax4Txt.Size = New System.Drawing.Size(48, 16)
        Me.LblCCTax4Txt.TabIndex = 9
        Me.LblCCTax4Txt.Text = "4th Due"
        '
        'LblCCTax3Txt
        '
        Me.LblCCTax3Txt.BackColor = System.Drawing.SystemColors.Control
        Me.LblCCTax3Txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCCTax3Txt.Location = New System.Drawing.Point(8, 120)
        Me.LblCCTax3Txt.Name = "LblCCTax3Txt"
        Me.LblCCTax3Txt.Size = New System.Drawing.Size(48, 16)
        Me.LblCCTax3Txt.TabIndex = 7
        Me.LblCCTax3Txt.Text = "3rd Due"
        '
        'LblCCTax2Txt
        '
        Me.LblCCTax2Txt.BackColor = System.Drawing.SystemColors.Control
        Me.LblCCTax2Txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCCTax2Txt.Location = New System.Drawing.Point(8, 104)
        Me.LblCCTax2Txt.Name = "LblCCTax2Txt"
        Me.LblCCTax2Txt.Size = New System.Drawing.Size(48, 16)
        Me.LblCCTax2Txt.TabIndex = 5
        Me.LblCCTax2Txt.Text = "2nd Due"
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.SystemColors.Control
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(8, 88)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(60, 16)
        Me.Label29.TabIndex = 3
        Me.Label29.Text = "1st Due"
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.SystemColors.Control
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(8, 72)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 16)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "Total Due"
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox8.Controls.Add(Me.LnkDMV)
        Me.GroupBox8.Controls.Add(Me.LnkStatus)
        Me.GroupBox8.Controls.Add(Me.LblSusdt)
        Me.GroupBox8.Controls.Add(Me.LblAssmnt)
        Me.GroupBox8.Controls.Add(Me.LblDOB)
        Me.GroupBox8.Controls.Add(Me.LblPuton)
        Me.GroupBox8.Controls.Add(Me.LblStatus)
        Me.GroupBox8.Controls.Add(Me.LblProDate)
        Me.GroupBox8.Controls.Add(Me.LblSuscd)
        Me.GroupBox8.Controls.Add(Me.LblProDateTxt)
        Me.GroupBox8.Controls.Add(Me.LblAssmntTxt)
        Me.GroupBox8.Controls.Add(Me.LblDOBTxt)
        Me.GroupBox8.Controls.Add(Me.Label41)
        Me.GroupBox8.Controls.Add(Me.Label42)
        Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(180, 220)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(176, 140)
        Me.GroupBox8.TabIndex = 158
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Misc"
        '
        'LnkDMV
        '
        Me.LnkDMV.AutoSize = True
        Me.LnkDMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkDMV.Location = New System.Drawing.Point(8, 80)
        Me.LnkDMV.Name = "LnkDMV"
        Me.LnkDMV.Size = New System.Drawing.Size(34, 13)
        Me.LnkDMV.TabIndex = 176
        Me.LnkDMV.TabStop = True
        Me.LnkDMV.Text = "DMV "
        '
        'LnkStatus
        '
        Me.LnkStatus.AutoSize = True
        Me.LnkStatus.Location = New System.Drawing.Point(156, 40)
        Me.LnkStatus.Name = "LnkStatus"
        Me.LnkStatus.Size = New System.Drawing.Size(14, 13)
        Me.LnkStatus.TabIndex = 175
        Me.LnkStatus.TabStop = True
        Me.LnkStatus.Text = "?"
        '
        'LblSusdt
        '
        Me.LblSusdt.BackColor = System.Drawing.SystemColors.Control
        Me.LblSusdt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSusdt.Location = New System.Drawing.Point(104, 60)
        Me.LblSusdt.Name = "LblSusdt"
        Me.LblSusdt.Size = New System.Drawing.Size(66, 16)
        Me.LblSusdt.TabIndex = 134
        Me.LblSusdt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblAssmnt
        '
        Me.LblAssmnt.BackColor = System.Drawing.SystemColors.Control
        Me.LblAssmnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAssmnt.Location = New System.Drawing.Point(80, 120)
        Me.LblAssmnt.Name = "LblAssmnt"
        Me.LblAssmnt.Size = New System.Drawing.Size(20, 16)
        Me.LblAssmnt.TabIndex = 133
        Me.LblAssmnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblDOB
        '
        Me.LblDOB.BackColor = System.Drawing.SystemColors.Control
        Me.LblDOB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDOB.Location = New System.Drawing.Point(80, 100)
        Me.LblDOB.Name = "LblDOB"
        Me.LblDOB.Size = New System.Drawing.Size(68, 16)
        Me.LblDOB.TabIndex = 132
        Me.LblDOB.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblPuton
        '
        Me.LblPuton.BackColor = System.Drawing.SystemColors.Control
        Me.LblPuton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPuton.Location = New System.Drawing.Point(80, 80)
        Me.LblPuton.Name = "LblPuton"
        Me.LblPuton.Size = New System.Drawing.Size(90, 20)
        Me.LblPuton.TabIndex = 131
        '
        'LblStatus
        '
        Me.LblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.LblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStatus.ForeColor = System.Drawing.Color.Magenta
        Me.LblStatus.Location = New System.Drawing.Point(80, 40)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(68, 16)
        Me.LblStatus.TabIndex = 130
        Me.LblStatus.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblProDate
        '
        Me.LblProDate.BackColor = System.Drawing.SystemColors.Control
        Me.LblProDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProDate.Location = New System.Drawing.Point(80, 20)
        Me.LblProDate.Name = "LblProDate"
        Me.LblProDate.Size = New System.Drawing.Size(68, 16)
        Me.LblProDate.TabIndex = 129
        Me.LblProDate.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblSuscd
        '
        Me.LblSuscd.BackColor = System.Drawing.SystemColors.Control
        Me.LblSuscd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSuscd.Location = New System.Drawing.Point(80, 60)
        Me.LblSuscd.Name = "LblSuscd"
        Me.LblSuscd.Size = New System.Drawing.Size(16, 16)
        Me.LblSuscd.TabIndex = 128
        Me.LblSuscd.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblProDateTxt
        '
        Me.LblProDateTxt.BackColor = System.Drawing.SystemColors.Control
        Me.LblProDateTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProDateTxt.Location = New System.Drawing.Point(8, 20)
        Me.LblProDateTxt.Name = "LblProDateTxt"
        Me.LblProDateTxt.Size = New System.Drawing.Size(68, 16)
        Me.LblProDateTxt.TabIndex = 11
        Me.LblProDateTxt.Text = "Prorate Date"
        '
        'LblAssmntTxt
        '
        Me.LblAssmntTxt.BackColor = System.Drawing.SystemColors.Control
        Me.LblAssmntTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAssmntTxt.Location = New System.Drawing.Point(8, 120)
        Me.LblAssmntTxt.Name = "LblAssmntTxt"
        Me.LblAssmntTxt.Size = New System.Drawing.Size(60, 16)
        Me.LblAssmntTxt.TabIndex = 9
        Me.LblAssmntTxt.Text = "Assmnt Cd"
        '
        'LblDOBTxt
        '
        Me.LblDOBTxt.BackColor = System.Drawing.SystemColors.Control
        Me.LblDOBTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDOBTxt.Location = New System.Drawing.Point(8, 100)
        Me.LblDOBTxt.Name = "LblDOBTxt"
        Me.LblDOBTxt.Size = New System.Drawing.Size(56, 16)
        Me.LblDOBTxt.TabIndex = 5
        Me.LblDOBTxt.Text = "Birth Date"
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.SystemColors.Control
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(8, 60)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(72, 16)
        Me.Label41.TabIndex = 3
        Me.Label41.Text = "Sus Cd/Date"
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.SystemColors.Control
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(8, 40)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(72, 16)
        Me.Label42.TabIndex = 0
        Me.Label42.Text = "Status Code"
        '
        'GrpTax
        '
        Me.GrpTax.BackColor = System.Drawing.SystemColors.Control
        Me.GrpTax.Controls.Add(Me.LblTax4)
        Me.GrpTax.Controls.Add(Me.LblTax3)
        Me.GrpTax.Controls.Add(Me.LblTax2)
        Me.GrpTax.Controls.Add(Me.LblTax1)
        Me.GrpTax.Controls.Add(Me.LblTaxt)
        Me.GrpTax.Controls.Add(Me.LblTax4Txt)
        Me.GrpTax.Controls.Add(Me.LblTax3Txt)
        Me.GrpTax.Controls.Add(Me.LblTax2Txt)
        Me.GrpTax.Controls.Add(Me.LblTax1Txt)
        Me.GrpTax.Controls.Add(Me.Label19)
        Me.GrpTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTax.Location = New System.Drawing.Point(592, 32)
        Me.GrpTax.Name = "GrpTax"
        Me.GrpTax.Size = New System.Drawing.Size(200, 120)
        Me.GrpTax.TabIndex = 156
        Me.GrpTax.TabStop = False
        Me.GrpTax.Text = "Original Amounts"
        '
        'LblTax4
        '
        Me.LblTax4.BackColor = System.Drawing.SystemColors.Control
        Me.LblTax4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTax4.Location = New System.Drawing.Point(116, 98)
        Me.LblTax4.Name = "LblTax4"
        Me.LblTax4.Size = New System.Drawing.Size(73, 16)
        Me.LblTax4.TabIndex = 129
        Me.LblTax4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblTax3
        '
        Me.LblTax3.BackColor = System.Drawing.SystemColors.Control
        Me.LblTax3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTax3.Location = New System.Drawing.Point(116, 77)
        Me.LblTax3.Name = "LblTax3"
        Me.LblTax3.Size = New System.Drawing.Size(73, 16)
        Me.LblTax3.TabIndex = 128
        Me.LblTax3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblTax2
        '
        Me.LblTax2.BackColor = System.Drawing.SystemColors.Control
        Me.LblTax2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTax2.Location = New System.Drawing.Point(116, 53)
        Me.LblTax2.Name = "LblTax2"
        Me.LblTax2.Size = New System.Drawing.Size(73, 16)
        Me.LblTax2.TabIndex = 127
        Me.LblTax2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblTax1
        '
        Me.LblTax1.BackColor = System.Drawing.SystemColors.Control
        Me.LblTax1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTax1.Location = New System.Drawing.Point(116, 33)
        Me.LblTax1.Name = "LblTax1"
        Me.LblTax1.Size = New System.Drawing.Size(73, 16)
        Me.LblTax1.TabIndex = 126
        Me.LblTax1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblTaxt
        '
        Me.LblTaxt.BackColor = System.Drawing.SystemColors.Control
        Me.LblTaxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTaxt.Location = New System.Drawing.Point(116, 17)
        Me.LblTaxt.Name = "LblTaxt"
        Me.LblTaxt.Size = New System.Drawing.Size(73, 16)
        Me.LblTaxt.TabIndex = 125
        Me.LblTaxt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblTax4Txt
        '
        Me.LblTax4Txt.AutoSize = True
        Me.LblTax4Txt.BackColor = System.Drawing.SystemColors.Control
        Me.LblTax4Txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTax4Txt.Location = New System.Drawing.Point(8, 96)
        Me.LblTax4Txt.Name = "LblTax4Txt"
        Me.LblTax4Txt.Size = New System.Drawing.Size(25, 13)
        Me.LblTax4Txt.TabIndex = 9
        Me.LblTax4Txt.Text = "4th "
        '
        'LblTax3Txt
        '
        Me.LblTax3Txt.AutoSize = True
        Me.LblTax3Txt.BackColor = System.Drawing.SystemColors.Control
        Me.LblTax3Txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTax3Txt.Location = New System.Drawing.Point(8, 76)
        Me.LblTax3Txt.Name = "LblTax3Txt"
        Me.LblTax3Txt.Size = New System.Drawing.Size(22, 13)
        Me.LblTax3Txt.TabIndex = 7
        Me.LblTax3Txt.Text = "3rd"
        '
        'LblTax2Txt
        '
        Me.LblTax2Txt.AutoSize = True
        Me.LblTax2Txt.BackColor = System.Drawing.SystemColors.Control
        Me.LblTax2Txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTax2Txt.Location = New System.Drawing.Point(8, 56)
        Me.LblTax2Txt.Name = "LblTax2Txt"
        Me.LblTax2Txt.Size = New System.Drawing.Size(28, 13)
        Me.LblTax2Txt.TabIndex = 5
        Me.LblTax2Txt.Text = "2nd "
        '
        'LblTax1Txt
        '
        Me.LblTax1Txt.AutoSize = True
        Me.LblTax1Txt.BackColor = System.Drawing.SystemColors.Control
        Me.LblTax1Txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTax1Txt.Location = New System.Drawing.Point(8, 36)
        Me.LblTax1Txt.Name = "LblTax1Txt"
        Me.LblTax1Txt.Size = New System.Drawing.Size(24, 13)
        Me.LblTax1Txt.TabIndex = 3
        Me.LblTax1Txt.Text = "1st "
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.SystemColors.Control
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(8, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(54, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Total Due"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox5.Controls.Add(Me.LblUnPostedFee)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.LblUnpostedLien)
        Me.GroupBox5.Controls.Add(Me.Label38)
        Me.GroupBox5.Controls.Add(Me.LblUnpostedInt)
        Me.GroupBox5.Controls.Add(Me.Label36)
        Me.GroupBox5.Controls.Add(Me.LblRemain)
        Me.GroupBox5.Controls.Add(Me.LblUnposted)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(424, 260)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(160, 100)
        Me.GroupBox5.TabIndex = 155
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Amount Remaining"
        '
        'LblUnPostedFee
        '
        Me.LblUnPostedFee.BackColor = System.Drawing.SystemColors.Control
        Me.LblUnPostedFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUnPostedFee.Location = New System.Drawing.Point(88, 48)
        Me.LblUnPostedFee.Name = "LblUnPostedFee"
        Me.LblUnPostedFee.Size = New System.Drawing.Size(60, 16)
        Me.LblUnPostedFee.TabIndex = 134
        Me.LblUnPostedFee.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.Control
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(8, 48)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 16)
        Me.Label17.TabIndex = 133
        Me.Label17.Text = "Unposted Fee"
        '
        'LblUnpostedLien
        '
        Me.LblUnpostedLien.BackColor = System.Drawing.SystemColors.Control
        Me.LblUnpostedLien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUnpostedLien.Location = New System.Drawing.Point(88, 64)
        Me.LblUnpostedLien.Name = "LblUnpostedLien"
        Me.LblUnpostedLien.Size = New System.Drawing.Size(60, 16)
        Me.LblUnpostedLien.TabIndex = 132
        Me.LblUnpostedLien.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.SystemColors.Control
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(6, 64)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(80, 16)
        Me.Label38.TabIndex = 131
        Me.Label38.Text = "Unposted Lien"
        '
        'LblUnpostedInt
        '
        Me.LblUnpostedInt.BackColor = System.Drawing.SystemColors.Control
        Me.LblUnpostedInt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUnpostedInt.Location = New System.Drawing.Point(88, 32)
        Me.LblUnpostedInt.Name = "LblUnpostedInt"
        Me.LblUnpostedInt.Size = New System.Drawing.Size(60, 16)
        Me.LblUnpostedInt.TabIndex = 130
        Me.LblUnpostedInt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.SystemColors.Control
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(8, 32)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(76, 16)
        Me.Label36.TabIndex = 129
        Me.Label36.Text = "Unposted Int"
        '
        'LblRemain
        '
        Me.LblRemain.BackColor = System.Drawing.SystemColors.Control
        Me.LblRemain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemain.Location = New System.Drawing.Point(75, 80)
        Me.LblRemain.Name = "LblRemain"
        Me.LblRemain.Size = New System.Drawing.Size(73, 16)
        Me.LblRemain.TabIndex = 128
        Me.LblRemain.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblUnposted
        '
        Me.LblUnposted.BackColor = System.Drawing.SystemColors.Control
        Me.LblUnposted.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUnposted.Location = New System.Drawing.Point(88, 16)
        Me.LblUnposted.Name = "LblUnposted"
        Me.LblUnposted.Size = New System.Drawing.Size(60, 16)
        Me.LblUnposted.TabIndex = 127
        Me.LblUnposted.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 80)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 16)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Remain. Prin."
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(8, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 16)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Unposted Pmt"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.Controls.Add(Me.LblBondPaidHdr)
        Me.GroupBox4.Controls.Add(Me.LblBondPaid)
        Me.GroupBox4.Controls.Add(Me.LblPayDate)
        Me.GroupBox4.Controls.Add(Me.LblIntPaid)
        Me.GroupBox4.Controls.Add(Me.LblTotpay)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(424, 160)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(160, 100)
        Me.GroupBox4.TabIndex = 154
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Collected"
        '
        'LblBondPaidHdr
        '
        Me.LblBondPaidHdr.BackColor = System.Drawing.SystemColors.Control
        Me.LblBondPaidHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBondPaidHdr.Location = New System.Drawing.Point(8, 60)
        Me.LblBondPaidHdr.Name = "LblBondPaidHdr"
        Me.LblBondPaidHdr.Size = New System.Drawing.Size(78, 16)
        Me.LblBondPaidHdr.TabIndex = 128
        Me.LblBondPaidHdr.Text = "Bond Int Paid"
        '
        'LblBondPaid
        '
        Me.LblBondPaid.BackColor = System.Drawing.SystemColors.Control
        Me.LblBondPaid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBondPaid.Location = New System.Drawing.Point(92, 60)
        Me.LblBondPaid.Name = "LblBondPaid"
        Me.LblBondPaid.Size = New System.Drawing.Size(60, 16)
        Me.LblBondPaid.TabIndex = 127
        Me.LblBondPaid.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblPayDate
        '
        Me.LblPayDate.BackColor = System.Drawing.SystemColors.Control
        Me.LblPayDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPayDate.Location = New System.Drawing.Point(84, 80)
        Me.LblPayDate.Name = "LblPayDate"
        Me.LblPayDate.Size = New System.Drawing.Size(68, 16)
        Me.LblPayDate.TabIndex = 126
        Me.LblPayDate.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblIntPaid
        '
        Me.LblIntPaid.BackColor = System.Drawing.SystemColors.Control
        Me.LblIntPaid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIntPaid.Location = New System.Drawing.Point(88, 40)
        Me.LblIntPaid.Name = "LblIntPaid"
        Me.LblIntPaid.Size = New System.Drawing.Size(64, 16)
        Me.LblIntPaid.TabIndex = 125
        Me.LblIntPaid.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblTotpay
        '
        Me.LblTotpay.BackColor = System.Drawing.SystemColors.Control
        Me.LblTotpay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotpay.Location = New System.Drawing.Point(72, 20)
        Me.LblTotpay.Name = "LblTotpay"
        Me.LblTotpay.Size = New System.Drawing.Size(80, 16)
        Me.LblTotpay.TabIndex = 124
        Me.LblTotpay.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 16)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Payment Date"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 16)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Interest Paid"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(8, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(68, 16)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Total Pmnts"
        '
        'LblProperty
        '
        Me.LblProperty.BackColor = System.Drawing.SystemColors.Control
        Me.LblProperty.Location = New System.Drawing.Point(104, 168)
        Me.LblProperty.Name = "LblProperty"
        Me.LblProperty.Size = New System.Drawing.Size(304, 16)
        Me.LblProperty.TabIndex = 153
        '
        'LblZip4
        '
        Me.LblZip4.BackColor = System.Drawing.SystemColors.Control
        Me.LblZip4.Location = New System.Drawing.Point(296, 144)
        Me.LblZip4.Name = "LblZip4"
        Me.LblZip4.Size = New System.Drawing.Size(36, 16)
        Me.LblZip4.TabIndex = 152
        '
        'LblZip5
        '
        Me.LblZip5.BackColor = System.Drawing.SystemColors.Control
        Me.LblZip5.Location = New System.Drawing.Point(256, 144)
        Me.LblZip5.Name = "LblZip5"
        Me.LblZip5.Size = New System.Drawing.Size(36, 16)
        Me.LblZip5.TabIndex = 151
        '
        'LblState
        '
        Me.LblState.BackColor = System.Drawing.SystemColors.Control
        Me.LblState.Location = New System.Drawing.Point(228, 144)
        Me.LblState.Name = "LblState"
        Me.LblState.Size = New System.Drawing.Size(24, 16)
        Me.LblState.TabIndex = 150
        '
        'LblCity
        '
        Me.LblCity.BackColor = System.Drawing.SystemColors.Control
        Me.LblCity.Location = New System.Drawing.Point(104, 144)
        Me.LblCity.Name = "LblCity"
        Me.LblCity.Size = New System.Drawing.Size(146, 16)
        Me.LblCity.TabIndex = 149
        '
        'LblAdd2
        '
        Me.LblAdd2.BackColor = System.Drawing.SystemColors.Control
        Me.LblAdd2.Location = New System.Drawing.Point(104, 128)
        Me.LblAdd2.Name = "LblAdd2"
        Me.LblAdd2.Size = New System.Drawing.Size(256, 16)
        Me.LblAdd2.TabIndex = 148
        '
        'LblAdd1
        '
        Me.LblAdd1.BackColor = System.Drawing.SystemColors.Control
        Me.LblAdd1.Location = New System.Drawing.Point(104, 104)
        Me.LblAdd1.Name = "LblAdd1"
        Me.LblAdd1.Size = New System.Drawing.Size(256, 20)
        Me.LblAdd1.TabIndex = 147
        Me.LblAdd1.UseMnemonic = False
        '
        'LblSname
        '
        Me.LblSname.BackColor = System.Drawing.SystemColors.Control
        Me.LblSname.Location = New System.Drawing.Point(104, 88)
        Me.LblSname.Name = "LblSname"
        Me.LblSname.Size = New System.Drawing.Size(256, 16)
        Me.LblSname.TabIndex = 146
        Me.LblSname.UseMnemonic = False
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.SystemColors.Control
        Me.LblName.Location = New System.Drawing.Point(104, 64)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(256, 16)
        Me.LblName.TabIndex = 145
        Me.LblName.UseMnemonic = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(272, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 12)
        Me.Label7.TabIndex = 144
        Me.Label7.Text = "Type"
        '
        'LblType
        '
        Me.LblType.BackColor = System.Drawing.SystemColors.Control
        Me.LblType.Location = New System.Drawing.Point(308, 48)
        Me.LblType.Name = "LblType"
        Me.LblType.Size = New System.Drawing.Size(16, 16)
        Me.LblType.TabIndex = 143
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(164, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 12)
        Me.Label3.TabIndex = 142
        Me.Label3.Text = "Year"
        '
        'LblYear
        '
        Me.LblYear.BackColor = System.Drawing.SystemColors.Control
        Me.LblYear.Location = New System.Drawing.Point(196, 48)
        Me.LblYear.Name = "LblYear"
        Me.LblYear.Size = New System.Drawing.Size(48, 16)
        Me.LblYear.TabIndex = 141
        '
        'LblList
        '
        Me.LblList.BackColor = System.Drawing.SystemColors.Control
        Me.LblList.Location = New System.Drawing.Point(104, 48)
        Me.LblList.Name = "LblList"
        Me.LblList.Size = New System.Drawing.Size(48, 16)
        Me.LblList.TabIndex = 140
        '
        'GrpPropValues
        '
        Me.GrpPropValues.BackColor = System.Drawing.SystemColors.Control
        Me.GrpPropValues.Controls.Add(Me.LblNet)
        Me.GrpPropValues.Controls.Add(Me.LblExempt)
        Me.GrpPropValues.Controls.Add(Me.LblGross)
        Me.GrpPropValues.Controls.Add(Me.Label4)
        Me.GrpPropValues.Controls.Add(Me.Label5)
        Me.GrpPropValues.Controls.Add(Me.Label6)
        Me.GrpPropValues.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpPropValues.Location = New System.Drawing.Point(12, 220)
        Me.GrpPropValues.Name = "GrpPropValues"
        Me.GrpPropValues.Size = New System.Drawing.Size(162, 80)
        Me.GrpPropValues.TabIndex = 139
        Me.GrpPropValues.TabStop = False
        Me.GrpPropValues.Text = "Property Values"
        '
        'LblNet
        '
        Me.LblNet.BackColor = System.Drawing.SystemColors.Control
        Me.LblNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNet.Location = New System.Drawing.Point(80, 60)
        Me.LblNet.Name = "LblNet"
        Me.LblNet.Size = New System.Drawing.Size(68, 16)
        Me.LblNet.TabIndex = 131
        Me.LblNet.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblExempt
        '
        Me.LblExempt.BackColor = System.Drawing.SystemColors.Control
        Me.LblExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblExempt.Location = New System.Drawing.Point(80, 40)
        Me.LblExempt.Name = "LblExempt"
        Me.LblExempt.Size = New System.Drawing.Size(68, 16)
        Me.LblExempt.TabIndex = 130
        Me.LblExempt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblGross
        '
        Me.LblGross.BackColor = System.Drawing.SystemColors.Control
        Me.LblGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGross.Location = New System.Drawing.Point(80, 20)
        Me.LblGross.Name = "LblGross"
        Me.LblGross.Size = New System.Drawing.Size(68, 16)
        Me.LblGross.TabIndex = 129
        Me.LblGross.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Net"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Exempt"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Gross"
        '
        'label37
        '
        Me.label37.BackColor = System.Drawing.SystemColors.Control
        Me.label37.Location = New System.Drawing.Point(12, 168)
        Me.label37.Name = "label37"
        Me.label37.Size = New System.Drawing.Size(64, 16)
        Me.label37.TabIndex = 138
        Me.label37.Text = "Property"
        '
        'groupBox2
        '
        Me.groupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.groupBox2.Controls.Add(Me.LnkFee)
        Me.groupBox2.Controls.Add(Me.Label11)
        Me.groupBox2.Controls.Add(Me.LblBond)
        Me.groupBox2.Controls.Add(Me.LblDue)
        Me.groupBox2.Controls.Add(Me.LblLien)
        Me.groupBox2.Controls.Add(Me.LblInterest)
        Me.groupBox2.Controls.Add(Me.Label21)
        Me.groupBox2.Controls.Add(Me.label27)
        Me.groupBox2.Controls.Add(Me.label26)
        Me.groupBox2.Controls.Add(Me.label25)
        Me.groupBox2.Controls.Add(Me.label24)
        Me.groupBox2.Controls.Add(Me.LblTax)
        Me.groupBox2.Controls.Add(Me.LblFee)
        Me.groupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox2.Location = New System.Drawing.Point(424, 19)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(160, 141)
        Me.groupBox2.TabIndex = 137
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Amt Due as of Int Date"
        '
        'LnkFee
        '
        Me.LnkFee.AutoSize = True
        Me.LnkFee.Location = New System.Drawing.Point(138, 60)
        Me.LnkFee.Name = "LnkFee"
        Me.LnkFee.Size = New System.Drawing.Size(14, 13)
        Me.LnkFee.TabIndex = 176
        Me.LnkFee.TabStop = True
        Me.LnkFee.Text = "?"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 97)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 166
        Me.Label11.Text = "Bond Int"
        '
        'LblBond
        '
        Me.LblBond.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblBond.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblBond.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBond.Location = New System.Drawing.Point(64, 96)
        Me.LblBond.Name = "LblBond"
        Me.LblBond.Size = New System.Drawing.Size(72, 20)
        Me.LblBond.TabIndex = 167
        Me.LblBond.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblDue
        '
        Me.LblDue.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblDue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDue.Location = New System.Drawing.Point(64, 116)
        Me.LblDue.Name = "LblDue"
        Me.LblDue.Size = New System.Drawing.Size(72, 20)
        Me.LblDue.TabIndex = 165
        Me.LblDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblLien
        '
        Me.LblLien.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblLien.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblLien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLien.Location = New System.Drawing.Point(64, 76)
        Me.LblLien.Name = "LblLien"
        Me.LblLien.Size = New System.Drawing.Size(72, 20)
        Me.LblLien.TabIndex = 164
        Me.LblLien.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblInterest
        '
        Me.LblInterest.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblInterest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInterest.Location = New System.Drawing.Point(64, 36)
        Me.LblInterest.Name = "LblInterest"
        Me.LblInterest.Size = New System.Drawing.Size(72, 20)
        Me.LblInterest.TabIndex = 163
        Me.LblInterest.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.SystemColors.Control
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(8, 117)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 16)
        Me.Label21.TabIndex = 9
        Me.Label21.Text = "Due"
        '
        'label27
        '
        Me.label27.BackColor = System.Drawing.SystemColors.Control
        Me.label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label27.Location = New System.Drawing.Point(8, 80)
        Me.label27.Name = "label27"
        Me.label27.Size = New System.Drawing.Size(48, 16)
        Me.label27.TabIndex = 7
        Me.label27.Text = "Lien"
        '
        'label26
        '
        Me.label26.BackColor = System.Drawing.SystemColors.Control
        Me.label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label26.Location = New System.Drawing.Point(8, 60)
        Me.label26.Name = "label26"
        Me.label26.Size = New System.Drawing.Size(56, 16)
        Me.label26.TabIndex = 5
        Me.label26.Text = "Fee"
        '
        'label25
        '
        Me.label25.BackColor = System.Drawing.SystemColors.Control
        Me.label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label25.Location = New System.Drawing.Point(8, 40)
        Me.label25.Name = "label25"
        Me.label25.Size = New System.Drawing.Size(48, 16)
        Me.label25.TabIndex = 3
        Me.label25.Text = "Interest"
        '
        'label24
        '
        Me.label24.BackColor = System.Drawing.SystemColors.Control
        Me.label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label24.Location = New System.Drawing.Point(8, 20)
        Me.label24.Name = "label24"
        Me.label24.Size = New System.Drawing.Size(48, 16)
        Me.label24.TabIndex = 0
        Me.label24.Text = "Tax"
        '
        'LblTax
        '
        Me.LblTax.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblTax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTax.Location = New System.Drawing.Point(64, 16)
        Me.LblTax.Name = "LblTax"
        Me.LblTax.Size = New System.Drawing.Size(72, 20)
        Me.LblTax.TabIndex = 162
        Me.LblTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblFee
        '
        Me.LblFee.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblFee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFee.Location = New System.Drawing.Point(64, 56)
        Me.LblFee.Name = "LblFee"
        Me.LblFee.Size = New System.Drawing.Size(72, 20)
        Me.LblFee.TabIndex = 163
        Me.LblFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label10
        '
        Me.label10.BackColor = System.Drawing.SystemColors.Control
        Me.label10.Location = New System.Drawing.Point(12, 144)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(84, 12)
        Me.label10.TabIndex = 136
        Me.label10.Text = "City/State/Zip"
        '
        'label9
        '
        Me.label9.BackColor = System.Drawing.SystemColors.Control
        Me.label9.Location = New System.Drawing.Point(12, 104)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(84, 12)
        Me.label9.TabIndex = 135
        Me.label9.Text = "Mail Address"
        '
        'label8
        '
        Me.label8.BackColor = System.Drawing.SystemColors.Control
        Me.label8.Location = New System.Drawing.Point(12, 88)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(84, 12)
        Me.label8.TabIndex = 134
        Me.label8.Text = "Second Name"
        '
        'label2
        '
        Me.label2.BackColor = System.Drawing.SystemColors.Control
        Me.label2.Location = New System.Drawing.Point(12, 64)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(84, 12)
        Me.label2.TabIndex = 133
        Me.label2.Text = "Name of Owner"
        '
        'label1
        '
        Me.label1.BackColor = System.Drawing.SystemColors.Control
        Me.label1.Location = New System.Drawing.Point(12, 48)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(36, 12)
        Me.label1.TabIndex = 132
        Me.label1.Text = "List #"
        '
        'DtPckInt
        '
        Me.DtPckInt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckInt.Location = New System.Drawing.Point(320, 0)
        Me.DtPckInt.Name = "DtPckInt"
        Me.DtPckInt.ShowCheckBox = True
        Me.DtPckInt.Size = New System.Drawing.Size(96, 20)
        Me.DtPckInt.TabIndex = 162
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(248, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(72, 16)
        Me.Label34.TabIndex = 163
        Me.Label34.Text = "Interest Date"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "comment_24.png")
        '
        'LblDist
        '
        Me.LblDist.BackColor = System.Drawing.SystemColors.Control
        Me.LblDist.Location = New System.Drawing.Point(678, 16)
        Me.LblDist.Name = "LblDist"
        Me.LblDist.Size = New System.Drawing.Size(24, 16)
        Me.LblDist.TabIndex = 166
        Me.LblDist.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.SystemColors.Control
        Me.Label43.Location = New System.Drawing.Point(600, 16)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(72, 16)
        Me.Label43.TabIndex = 165
        Me.Label43.Text = "Dist/Phs/Prt"
        '
        'LblPhase
        '
        Me.LblPhase.BackColor = System.Drawing.SystemColors.Control
        Me.LblPhase.Location = New System.Drawing.Point(726, 16)
        Me.LblPhase.Name = "LblPhase"
        Me.LblPhase.Size = New System.Drawing.Size(16, 16)
        Me.LblPhase.TabIndex = 168
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.SystemColors.Control
        Me.Label44.Location = New System.Drawing.Point(708, 16)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(12, 13)
        Me.Label44.TabIndex = 167
        Me.Label44.Text = "/"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.Location = New System.Drawing.Point(702, 377)
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(60, 24)
        Me.BtnPrevious.TabIndex = 169
        Me.BtnPrevious.Text = "Previous"
        '
        'BtnNext
        '
        Me.BtnNext.Location = New System.Drawing.Point(766, 377)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(60, 24)
        Me.BtnNext.TabIndex = 170
        Me.BtnNext.Text = "Next"
        '
        'LblMsg
        '
        Me.LblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMsg.ForeColor = System.Drawing.Color.Magenta
        Me.LblMsg.Location = New System.Drawing.Point(16, 0)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(224, 16)
        Me.LblMsg.TabIndex = 171
        Me.LblMsg.Text = "(alert message)"
        Me.LblMsg.UseMnemonic = False
        '
        'LblComment
        '
        Me.LblComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblComment.ForeColor = System.Drawing.Color.Magenta
        Me.LblComment.Location = New System.Drawing.Point(16, 32)
        Me.LblComment.Name = "LblComment"
        Me.LblComment.Size = New System.Drawing.Size(224, 16)
        Me.LblComment.TabIndex = 172
        '
        'LblComments
        '
        Me.LblComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblComments.ForeColor = System.Drawing.Color.Magenta
        Me.LblComments.Location = New System.Drawing.Point(432, 0)
        Me.LblComments.Name = "LblComments"
        Me.LblComments.Size = New System.Drawing.Size(394, 16)
        Me.LblComments.TabIndex = 173
        Me.LblComments.Text = "(1st line of comments)"
        Me.LblComments.UseMnemonic = False
        '
        'LnkBenefits
        '
        Me.LnkBenefits.AutoSize = True
        Me.LnkBenefits.Location = New System.Drawing.Point(20, 307)
        Me.LnkBenefits.Name = "LnkBenefits"
        Me.LnkBenefits.Size = New System.Drawing.Size(81, 13)
        Me.LnkBenefits.TabIndex = 174
        Me.LnkBenefits.TabStop = True
        Me.LnkBenefits.Text = "Benefits/Elderly"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'LnkUBA
        '
        Me.LnkUBA.AutoSize = True
        Me.LnkUBA.Location = New System.Drawing.Point(20, 343)
        Me.LnkUBA.Name = "LnkUBA"
        Me.LnkUBA.Size = New System.Drawing.Size(118, 13)
        Me.LnkUBA.TabIndex = 175
        Me.LnkUBA.TabStop = True
        Me.LnkUBA.Text = "Assessment Information"
        '
        'LnkCrVehicle
        '
        Me.LnkCrVehicle.AutoSize = True
        Me.LnkCrVehicle.Location = New System.Drawing.Point(20, 324)
        Me.LnkCrVehicle.Name = "LnkCrVehicle"
        Me.LnkCrVehicle.Size = New System.Drawing.Size(91, 13)
        Me.LnkCrVehicle.TabIndex = 176
        Me.LnkCrVehicle.TabStop = True
        Me.LnkCrVehicle.Text = "Prorated Net Calc"
        '
        'LblColAgency
        '
        Me.LblColAgency.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblColAgency.ForeColor = System.Drawing.Color.Magenta
        Me.LblColAgency.Location = New System.Drawing.Point(16, 16)
        Me.LblColAgency.Name = "LblColAgency"
        Me.LblColAgency.Size = New System.Drawing.Size(224, 16)
        Me.LblColAgency.TabIndex = 177
        Me.LblColAgency.Text = "*** Collection Agency ***"
        '
        'LblProperty3
        '
        Me.LblProperty3.BackColor = System.Drawing.SystemColors.Control
        Me.LblProperty3.Location = New System.Drawing.Point(104, 201)
        Me.LblProperty3.Name = "LblProperty3"
        Me.LblProperty3.Size = New System.Drawing.Size(304, 16)
        Me.LblProperty3.TabIndex = 178
        '
        'LblPrtDist
        '
        Me.LblPrtDist.BackColor = System.Drawing.SystemColors.Control
        Me.LblPrtDist.Location = New System.Drawing.Point(760, 16)
        Me.LblPrtDist.Name = "LblPrtDist"
        Me.LblPrtDist.Size = New System.Drawing.Size(24, 16)
        Me.LblPrtDist.TabIndex = 179
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.Control
        Me.Label18.Location = New System.Drawing.Point(742, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(12, 13)
        Me.Label18.TabIndex = 180
        Me.Label18.Text = "/"
        '
        'LblCAFee
        '
        Me.LblCAFee.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblCAFee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblCAFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCAFee.Location = New System.Drawing.Point(374, 336)
        Me.LblCAFee.Name = "LblCAFee"
        Me.LblCAFee.Size = New System.Drawing.Size(42, 20)
        Me.LblCAFee.TabIndex = 181
        Me.LblCAFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblCAFee.Visible = False
        '
        'BtnPayment
        '
        Me.BtnPayment.Location = New System.Drawing.Point(11, 370)
        Me.BtnPayment.Name = "BtnPayment"
        Me.BtnPayment.Size = New System.Drawing.Size(57, 38)
        Me.BtnPayment.TabIndex = 182
        Me.BtnPayment.Text = "Payment"
        Me.BtnPayment.UseVisualStyleBackColor = True
        '
        'BtnHistory
        '
        Me.BtnHistory.Location = New System.Drawing.Point(125, 370)
        Me.BtnHistory.Name = "BtnHistory"
        Me.BtnHistory.Size = New System.Drawing.Size(47, 38)
        Me.BtnHistory.TabIndex = 183
        Me.BtnHistory.Text = "History"
        Me.BtnHistory.UseVisualStyleBackColor = True
        '
        'BtnCCHistory
        '
        Me.BtnCCHistory.Location = New System.Drawing.Point(178, 370)
        Me.BtnCCHistory.Name = "BtnCCHistory"
        Me.BtnCCHistory.Size = New System.Drawing.Size(48, 38)
        Me.BtnCCHistory.TabIndex = 184
        Me.BtnCCHistory.Text = "C/C History"
        Me.BtnCCHistory.UseVisualStyleBackColor = True
        '
        'BtnDupBill
        '
        Me.BtnDupBill.Location = New System.Drawing.Point(232, 370)
        Me.BtnDupBill.Name = "BtnDupBill"
        Me.BtnDupBill.Size = New System.Drawing.Size(39, 38)
        Me.BtnDupBill.TabIndex = 185
        Me.BtnDupBill.Text = "Dup Bill"
        Me.BtnDupBill.UseVisualStyleBackColor = True
        '
        'BtnLetter
        '
        Me.BtnLetter.Location = New System.Drawing.Point(322, 370)
        Me.BtnLetter.Name = "BtnLetter"
        Me.BtnLetter.Size = New System.Drawing.Size(43, 38)
        Me.BtnLetter.TabIndex = 186
        Me.BtnLetter.Text = "Letter"
        Me.BtnLetter.UseVisualStyleBackColor = True
        '
        'BtnLienRel
        '
        Me.BtnLienRel.Location = New System.Drawing.Point(371, 370)
        Me.BtnLienRel.Name = "BtnLienRel"
        Me.BtnLienRel.Size = New System.Drawing.Size(55, 38)
        Me.BtnLienRel.TabIndex = 187
        Me.BtnLienRel.Text = "Lien Release"
        Me.BtnLienRel.UseVisualStyleBackColor = True
        '
        'BtnTotal
        '
        Me.BtnTotal.Location = New System.Drawing.Point(432, 370)
        Me.BtnTotal.Name = "BtnTotal"
        Me.BtnTotal.Size = New System.Drawing.Size(49, 38)
        Me.BtnTotal.TabIndex = 189
        Me.BtnTotal.Text = "Total"
        Me.BtnTotal.UseVisualStyleBackColor = True
        '
        'BtnAdjust
        '
        Me.BtnAdjust.Location = New System.Drawing.Point(488, 370)
        Me.BtnAdjust.Name = "BtnAdjust"
        Me.BtnAdjust.Size = New System.Drawing.Size(69, 38)
        Me.BtnAdjust.TabIndex = 190
        Me.BtnAdjust.Text = "Adjustment"
        Me.BtnAdjust.UseVisualStyleBackColor = True
        '
        'BtnComments
        '
        Me.BtnComments.Location = New System.Drawing.Point(626, 370)
        Me.BtnComments.Name = "BtnComments"
        Me.BtnComments.Size = New System.Drawing.Size(70, 38)
        Me.BtnComments.TabIndex = 191
        Me.BtnComments.Text = "Comments"
        Me.BtnComments.UseVisualStyleBackColor = True
        '
        'BtnPayCredit
        '
        Me.BtnPayCredit.Location = New System.Drawing.Point(74, 370)
        Me.BtnPayCredit.Name = "BtnPayCredit"
        Me.BtnPayCredit.Size = New System.Drawing.Size(45, 38)
        Me.BtnPayCredit.TabIndex = 192
        Me.BtnPayCredit.Text = "Credit (Web)"
        Me.BtnPayCredit.UseVisualStyleBackColor = True
        '
        'TxtRegno
        '
        Me.TxtRegno.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtRegno.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRegno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRegno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRegno.ForeColor = System.Drawing.Color.Navy
        Me.TxtRegno.Location = New System.Drawing.Point(107, 168)
        Me.TxtRegno.MaxLength = 20
        Me.TxtRegno.Name = "TxtRegno"
        Me.TxtRegno.ReadOnly = True
        Me.TxtRegno.Size = New System.Drawing.Size(53, 13)
        Me.TxtRegno.TabIndex = 227
        Me.TxtRegno.TabStop = False
        '
        'TxtVIN
        '
        Me.TxtVIN.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtVIN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtVIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVIN.ForeColor = System.Drawing.Color.Navy
        Me.TxtVIN.Location = New System.Drawing.Point(166, 168)
        Me.TxtVIN.MaxLength = 20
        Me.TxtVIN.Name = "TxtVIN"
        Me.TxtVIN.ReadOnly = True
        Me.TxtVIN.Size = New System.Drawing.Size(133, 13)
        Me.TxtVIN.TabIndex = 228
        Me.TxtVIN.TabStop = False
        '
        'BtnPDFBill
        '
        Me.BtnPDFBill.Location = New System.Drawing.Point(277, 370)
        Me.BtnPDFBill.Name = "BtnPDFBill"
        Me.BtnPDFBill.Size = New System.Drawing.Size(39, 38)
        Me.BtnPDFBill.TabIndex = 229
        Me.BtnPDFBill.Text = "PDF Bill"
        Me.BtnPDFBill.UseVisualStyleBackColor = True
        '
        'LnkDeferred
        '
        Me.LnkDeferred.AutoSize = True
        Me.LnkDeferred.Location = New System.Drawing.Point(122, 307)
        Me.LnkDeferred.Name = "LnkDeferred"
        Me.LnkDeferred.Size = New System.Drawing.Size(48, 13)
        Me.LnkDeferred.TabIndex = 230
        Me.LnkDeferred.TabStop = True
        Me.LnkDeferred.Text = "Deferred"
        '
        'btndetail
        '
        Me.btndetail.Location = New System.Drawing.Point(560, 370)
        Me.btndetail.Name = "btndetail"
        Me.btndetail.Size = New System.Drawing.Size(62, 38)
        Me.btndetail.TabIndex = 232
        Me.btndetail.Text = "Detail"
        Me.btndetail.UseVisualStyleBackColor = True
        Me.btndetail.Visible = False
        '
        'FrmTXA09B
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(830, 423)
        Me.Controls.Add(Me.btndetail)
        Me.Controls.Add(Me.LnkDeferred)
        Me.Controls.Add(Me.BtnPDFBill)
        Me.Controls.Add(Me.TxtVIN)
        Me.Controls.Add(Me.TxtRegno)
        Me.Controls.Add(Me.BtnPayCredit)
        Me.Controls.Add(Me.BtnComments)
        Me.Controls.Add(Me.BtnAdjust)
        Me.Controls.Add(Me.BtnTotal)
        Me.Controls.Add(Me.BtnLienRel)
        Me.Controls.Add(Me.BtnLetter)
        Me.Controls.Add(Me.BtnDupBill)
        Me.Controls.Add(Me.BtnCCHistory)
        Me.Controls.Add(Me.BtnHistory)
        Me.Controls.Add(Me.BtnPayment)
        Me.Controls.Add(Me.LblCAFee)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.LblPrtDist)
        Me.Controls.Add(Me.LblProperty3)
        Me.Controls.Add(Me.LblColAgency)
        Me.Controls.Add(Me.LnkCrVehicle)
        Me.Controls.Add(Me.LnkUBA)
        Me.Controls.Add(Me.LnkBenefits)
        Me.Controls.Add(Me.LblComments)
        Me.Controls.Add(Me.LblComment)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.BtnNext)
        Me.Controls.Add(Me.BtnPrevious)
        Me.Controls.Add(Me.LblPhase)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.LblDist)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.DtPckInt)
        Me.Controls.Add(Me.LblProperty2)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.LblBankCd)
        Me.Controls.Add(Me.GrpCC)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GrpTax)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.LblProperty)
        Me.Controls.Add(Me.LblZip4)
        Me.Controls.Add(Me.LblZip5)
        Me.Controls.Add(Me.LblState)
        Me.Controls.Add(Me.LblCity)
        Me.Controls.Add(Me.LblAdd2)
        Me.Controls.Add(Me.LblAdd1)
        Me.Controls.Add(Me.LblSname)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LblType)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblYear)
        Me.Controls.Add(Me.LblList)
        Me.Controls.Add(Me.GrpPropValues)
        Me.Controls.Add(Me.label37)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.label9)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTXA09B"
        Me.GrpCC.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GrpTax.ResumeLayout(False)
        Me.GrpTax.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GrpPropValues.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmTXA09B_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    ds2.Clear()
    ds2 = Nothing

    'Memory Cleanup
    CloseFiles()
    myTXINV = Nothing
    myTXMRATE = Nothing
    myTXPROF = Nothing
    mytxbatchl1 = Nothing
    myTAXCOM = Nothing
    myTXINVDTL = Nothing
    MyFrmTXA09.TBarAttach.Enabled = False
    MyFrmTXA09.TBarAttach.Text = "Attachments"
    MyFrmTXA09.TBarView.Enabled = True
    MyFrmTXA094.Show()

    MyFrmTXA09B = Nothing

  End Sub

  Private Sub FrmTXA09B_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    InitFiles()
    MyFrmTXA09.TBarView.Enabled = False
    MyFrmTXA09.TBarAttach.Enabled = True
    BtnPDFBill.Visible = False
    If MyAppSettings.PDFBillPrinter <> "" Then
      BtnPDFBill.Visible = True
    End If

    If MyInquiryMode Then
      BtnPayment.Visible = False
      BtnTotal.Visible = False
      BtnAdjust.Visible = False
      If s_full = False And s_add = False And s_chg = False Then
        BtnComments.Visible = False
        BtnLienRel.Visible = False
        BtnPayCredit.Visible = False
      End If
      BtnComments.Left = BtnTotal.Left
    End If

    If MyPublicUser Then
      LblDOB.Visible = False
      If Not MyAppSettings.DupBillPublicUser Then
        BtnDupBill.Visible = False
      End If
    End If
    LoadForm()
    SetColAgency()
    WrkMVFee = 0
    If myTXINV._MVFLAG = "Y" Or myTXINV._MVFLAG = "M" Then
      WrkMVFee = MyMVFee
    End If

  End Sub

  Private Sub FrmTXA09B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA09.SbpScreen.Text = "TXA09B"
    Call MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmTXA09
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub LoadForm()
    'MK 9/25/25 Begin
    Dim dscoeb As DataSet = New DataSet
    'MK 9/25/25 End
    Dim WrkAcct As String
    Dim WrkAttachcount As Integer
    Dim WrkFamily As String
    Dim WrkPrintDist As Integer

    WrkAcct = MyFrmTXA09B.WrkYear & MyFrmTXA09B.WrkType & MyFrmTXA09B.WrkListNo
    WrkAttachcount = GetAttachcount("CASHREG", WrkAcct)
    MyFrmTXA09.TBarAttach.Text = WrkAttachcount & " Attachment(s)"

    LblList.Text = WrkListNo
    LblYear.Text = WrkYear
    LblType.Text = WrkType

    WrkFamily = GetTXTypeFamily(WrkType)
    Me.Text = GetTXTypeDesc(WrkType)

    myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
    With myTXINV
      WrkICode = Trim(._ICODE)
      GrpTax.Text = "Original Amounts"
      LnkDeferred.Visible = False
      If ._DEFERT > 0 Then
        LnkDeferred.Visible = True
      End If
      Select Case WrkICode
        Case "B"
          LblMsg.Text = "*** Back Taxes Due **"
        Case "D"
          LblMsg.Text = "*** Taxes Deferred **"
          GrpTax.Text = "Due Amounts"
        Case "E"
          LblMsg.Text = "*** Defer Expired **"
          GrpTax.Text = "Due Amounts"
        Case "F"
          LblMsg.Text = "*** Foreclosure **"
        Case "I"
          If Trim(._DECD) = "" Then
            LblMsg.Text = "*** Inactive **"
          Else
            LblMsg.Text = "*** Inactive/Deferred **"
          End If
        Case "M"
          LblMsg.Text = "*** Mail Return **"
        Case "S"
          LblMsg.Text = "*** Suspense Item **"
        Case Else
          LblMsg.Text = String.Empty
      End Select
      If WrkFamily = "R" Then
        myTXINV2.GetOneRecordP(WrkListNo, WrkYear, "X")
        If Not myTXINV2.RecordNotFound Then
          LblMsg.Text = "*** Prorated Real Estate Exists **"
        End If
      End If
      LblComment.Text = Trim(._CCM)
      LblDist.Text = ._DIST
      LblPhase.Text = ._PHASE
      LblPrtDist.Text = ._PDST
      LblName.Text = Trim(._NAME)
      LblSname.Text = String.Empty
      If Not IsDBNull(._SNAME) Then
        LblSname.Text = Trim(._SNAME)
      End If
      LblAdd1.Text = Trim(._ADD1)
      LblAdd2.Text = String.Empty
      If Not IsDBNull(._ADD2) Then
        LblAdd2.Text = Trim(._ADD2)
      End If
      LblCity.Text = Trim(._CITY)
      LblState.Text = Trim(._STATE)
      LblZip5.Text = Format(._ZIP5, "00000")
      LblZip4.Text = Format(._ZIP4, "0000")
      LblProperty.Text = String.Empty
      LblProperty2.Text = String.Empty
      BtnCCHistory.Text = "C/C History"
      BtnPayCredit.Visible = False
      If Not MyInquiryMode And MyPayCredit Then
        If MydsPayCredit.Tables(0).Rows.Count > 0 Then
          BtnPayCredit.Text = "Credit " & MydsPayCredit.Tables(0).Rows.Count & " (Web)"
        Else
          BtnPayCredit.Text = "Credit (Web)"
        End If
        BtnPayCredit.Visible = True
      End If
      LnkCrVehicle.Visible = False
      LnkUBA.Visible = False

      LblProperty.Text = String.Empty
      LblProperty2.Text = String.Empty
      LblProperty3.Text = String.Empty
      LblProperty.Visible = True
      TxtRegno.Visible = False
      TxtVIN.Visible = False
      LblBondPaidHdr.Text = "Fee Paid"
      Select Case WrkFamily
        Case "M", "S"
          If MyPublicUser Then
            LblProperty.Text = String.Empty
          Else
            LblProperty.Visible = False
            LblProperty.Text = Trim(._IMVREG) & " - " & Trim(._IMVIDNo) 'Used by print
            TxtRegno.Visible = True
            TxtRegno.Text = Trim(._IMVREG)
            TxtVIN.Visible = True
            TxtVIN.Text = Trim(._IMVIDNo)
          End If
          LblProperty2.Text = Trim(._MAKE) & " - " & Trim(._MODEL) &
         " - " & ._MVYR & " - " & Format(._CLASS, "00")
          If Trim(._LOC) <> String.Empty Then
            LblProperty3.Text = Trim(._LOCNo) & " " & ._LOC
          End If
          If WrkFamily = "S" Then LnkCrVehicle.Visible = True
          TxtRegno.Text = Trim(._IMVREG)
          TxtVIN.Text = Trim(._IMVIDNo)
        Case "P"
          If Not IsDBNull(._LOC) Then
            LblProperty.Text = Trim(._LOCNo) & " " & ._LOC
          End If
          If ._IPPCD1 > 0 Then
            LblProperty2.Text = GetTXCodeDesc(._IPPCD1, "P")
          End If
          If ._IPPCD2 > 0 Then
            LblProperty3.Text = GetTXCodeDesc(._IPPCD2, "P")
          End If
        Case "R"
          If Not IsDBNull(._LOC) Then
            LblProperty.Text = Trim(._LOCNo) & " " & Trim(._LOC)
          End If
          If Not IsDBNull(._MAP) Then
            LblProperty2.Text = Trim(._MAP)
          End If
        Case "A"
          LnkUBA.Visible = True
          LblBondPaidHdr.Text = "Bond Int Paid"
          BtnCCHistory.Text = "Adj History"
          If Not IsDBNull(._LOC) Then
            LblProperty.Text = Trim(._LOCNo) & " " & Trim(._LOC)
          End If
        Case "U"
          BtnCCHistory.Text = "Adj History"
          If Not IsDBNull(._LOC) Then
            LblProperty.Text = Trim(._LOCNo) & " " & Trim(._LOC)
          End If
      End Select

      LblBankCd.Text = String.Empty
      If Not IsDBNull(._BKCD) Then
        LblBankCd.Text = Trim(._BKCD)
      End If
      LblAssmnt.Text = String.Empty
      LblPuton.Text = String.Empty
      LblDOB.Text = String.Empty
      LblProDate.Text = String.Empty
      LblAssmntTxt.Visible = False
      LnkDMV.Visible = False
      LblDOBTxt.Visible = False
      LblProDateTxt.Visible = False
      GrpPropValues.Visible = True
      Select Case WrkFamily
        Case "M", "S"
          LblAssmntTxt.Visible = True
          If ._SSNo > 0 Then
            LnkDMV.Visible = True
          End If
          LblDOBTxt.Visible = True
          If Not IsDBNull(._ASS) Then
            LblAssmnt.Text = Trim(._ASS)
          End If
          If Not IsDBNull(._MVFLAG) Then
            Select Case Trim(._MVFLAG)
              Case "M"
                LblPuton.Text = "Missing CustID"
              Case "P"
                LblPuton.Text = "Paid Fee"
              Case "Y"
                LblPuton.Text = "Put On"
              Case Else
                LblPuton.Text = Trim(._MVFLAG)
            End Select
          End If
          If ._DOB > 0 Then
            LblDOB.Text = MyUtils.GetDBDate(._DOB)
          End If
        Case "R", "P"
          LblProDateTxt.Visible = True
          If ._PDAT > 0 Then
            LblProDate.Text = MyUtils.GetDBDate(._PDAT)
          End If
        Case Else
          GrpPropValues.Visible = False
      End Select
      LblSuscd.Text = Trim(._SUSCD)
      LblSusdt.Text = String.Empty
      If ._SUSDT > 0 Then
        LblSusdt.Text = MyUtils.GetDBDate(._SUSDT)
      End If
      LblStatus.Text = Trim(._STCD1) + Trim(._STCD2) + Trim(._STCD3) + Trim(._STCD4) + Trim(._STCD5)
      If LblStatus.Text <> String.Empty Then
        LnkStatus.Visible = True
      Else
        LnkStatus.Visible = False
      End If
      LblGross.Text = Format(._GROSS, "###,###,###")
      LblExempt.Text = Format(._TOTEXP, "###,###,###")
      LblNet.Text = Format(._NETASS, "###,###,###")
      LblTax.BackColor = Color.Aqua
      Ttp1.SetToolTip(LblTax, String.Empty)
      If Trim(._ICODE) = "B" Then
        LblTax.BackColor = Color.LightPink '255, 128, 128
        Ttp1.SetToolTip(LblTax, "Back Tax Due")
      End If
      If ._CCNO > 0 Then
        'MK 9/29/25 Begin
        'LblTax.Text = ._CCETAX
        If ._ICODE = "E" Then
          LblTax.Text = ._CCETAX + ._DEFERT
        Else
          LblTax.Text = ._CCETAX
        End If
        'MK 9/29/25 End
      Else
        LblTax.Text = ._TAXT
      End If
      LblTotpay.Text = Format(._PAYREC, "standard")
      If WrkFamily = "A" Or WrkFamily = "U" Then
        LblBondPaid.Text = Format(._BONDP, "standard")
      End If
      LblPayDate.Text = String.Empty
      If ._TXIDT > 0 Then
        LblPayDate.Text = MyUtils.GetDBDate(._TXIDT)
      End If
      LblUnposted.Text = Format(._NEWPAY, "standard")
      LblTotpay.Text = Format(._PAYREC, "standard")
      LblRemain.Text = Format(._BALD, "standard")
      If ._ICODE = "D" Then
        LblTaxt.Text = Format(._TAXT - ._DEFERT, "standard")
        LblTax1.Text = Format(._TAX1 - ._DEFER1, "standard")
        LblTax2.Text = Format(._TAX2 - ._DEFER2, "standard")
        LblTax3.Text = Format(._TX3RD - ._DEFER3, "standard")
        LblTax4.Text = Format(._TX4TH - ._DEFER4, "standard")
      Else
        LblTaxt.Text = Format(._TAXT, "standard")
        LblTax1.Text = Format(._TAX1, "standard")
        LblTax2.Text = Format(._TAX2, "standard")
        LblTax3.Text = Format(._TX3RD, "standard")
        LblTax4.Text = Format(._TX4TH, "standard")
      End If
      LblRemain.Text = Format(._BALD, "standard")
      'C/C Info
      BtnCCHistory.Enabled = True
      GrpCC.Visible = True
      If ._CCNO = 0 And Trim(._ETCA) = String.Empty Then
        GrpCC.Visible = False
        BtnCCHistory.Enabled = False
      End If
      LblCCNo.Text = String.Empty
      LblCCDate.Text = String.Empty
      LblCCBillDate.Text = String.Empty
      LblCCTaxt.Text = String.Empty
      LblCCTax1.Text = String.Empty
      LblCCTax2.Text = String.Empty
      LblCCTax3.Text = String.Empty
      LblCCTax4.Text = String.Empty
      LblCCGross.Text = String.Empty
      LblCCExempt.Text = String.Empty
      LblCCNet.Text = String.Empty
      LblBeforeCC.Visible = False
      If Trim(._ETCA) = "Y" Then
        dscoeb = myTXCOEBL1.GetLastbyDate(WrkListNo, WrkYear, WrkType, 99999999)
        LblBeforeCC.Visible = True
        LblBeforeCC.Text = LblBeforeCC.Text & " " & dscoeb.Tables(0).Rows(0).Item("ccno")
      End If
      If ._CCNO > 0 Then
        myTXCOEA.GetOneRecordP(._CCNO)
        LblCCNo.Text = ._CCNO
        LblCCDate.Text = MyUtils.GetDBDate(._CDATE)
        If ._CCINT30 > 0 Then
          LblCCBillDate.Text = MyUtils.GetDBDate(._CCINT30)
        End If
        LblCCTaxt.Text = Format(._CCETAX, "standard")
        LblCCTax1.Text = Format(._CCTX1, "standard")
        LblCCTax2.Text = Format(._CCTX2, "standard")
        LblCCTax3.Text = Format(._CCTX3, "standard")
        LblCCTax4.Text = Format(._CCTX4, "standard")
        If Trim(._ASS) = "" And Trim(myTXCOEA._C1MPCD) = "" And Trim(myTXCOEA._C1MSCD) = "" Then
          LblCCGross.Text = Format(._CGRS, "###,###,###")
          LblCCExempt.Text = Format(._CCEXP, "###,###,###")
          LblCCNet.Text = Format(._CGRS - ._CCEXP, "###,###,###")
        Else
          LblCCGross.Text = Format(._CGRS, "###,###,###")
          LblCCExempt.Text = Format(._CCEXP, "###,###,###")
          LblCCNet.Text = Format(myTXCOEA._CNETAS, "###,###,###")
        End If
      End If
      WrkPrintDist = ._PDST
      If ._FTAX > 0 Or ._TWNBN > 0 Or Trim(._FRCD) <> String.Empty Then
        LnkBenefits.Visible = True
      Else
        LnkBenefits.Visible = False
      End If
    End With

    GetUnpostedInt()
    GetTxProf(WrkPrintDist)
    ShowComments()

    DtPckInt.Value = MyInterestDate
    MyInterestOverrideDate = DtPckInt.Value
    DtPckInt.Checked = False

    If WrkICode = "F" Or WrkICode = "I" Then
      BtnPayment.Enabled = False
      BtnAdjust.Enabled = False
      BtnLienRel.Enabled = False
      BtnPayCredit.Enabled = False
    Else
      BtnPayment.Enabled = True
      BtnAdjust.Enabled = True
      BtnLienRel.Enabled = True
      BtnPayCredit.Enabled = True
    End If


    If MyInvDetail Then
      'added for invdetail check to see if any detail records exist if so display detail button
      myTXINVDTL.GetFirstLYT(WrkListNo, WrkYear, WrkType)
      If myTXINVDTL.RecordNotFound = False Then
        btndetail.Visible = True
      Else
        btndetail.Visible = False
      End If
    End If
  End Sub
  Public Sub ShowComments()
    Dim dsTAXCOM As DataSet = New DataSet

    dsTAXCOM = myTAXCOM.Getcomments(WrkListNo, WrkType, WrkYear)
    BtnComments.ImageKey = ""
    LblComments.Text = String.Empty
    If dsTAXCOM.Tables(0).Rows.Count > 0 Then
      LblComments.Text = dsTAXCOM.Tables(0).Rows(0).Item("cmnt")
      BtnComments.ImageKey = "comment_24.png"
    End If
    myTAXCOM.CloseFile()
    dsTAXCOM.Clear()
    dsTAXCOM = Nothing
  End Sub

  Public Sub CalcInterest()
    Dim mycashint As CASHINT.MyData

    WrkCashIntDebug = String.Empty
    mycashint = New CASHINT.MyData(myDBConnect)
    With mycashint
      .In_IntDate = DtPckInt.Value
      .In_ListNo = MyUtils.CnvSng(LblList.Text)
      .In_Type = LblType.Text
      .In_Year = MyUtils.CnvSng(LblYear.Text)
      .CalcInterest()
      LblInterest.Text = Format(.Out_Int(), "standard")
      LblLien.Text = Format(.Out_Lien(), "standard")
      LblFee.Text = Format(.Out_Fee(), "standard")
      LblCAFee.Text = Format(.Out_CAFee(), "standard")
      LblBond.Text = Format(.Out_Bond(), "standard")
      LblTax.Text = Format(.Out_Prin(), "standard")
      LblDue.Text = Format(.Out_Tot(), "standard")
      LblIntPaid.Text = Format(.Out_IntPaid(), "standard")
      If LblBondPaidHdr.Text = "Fee Paid" Then
        LblBondPaid.Text = Format(.Out_FeePaid(), "standard")
      End If
      WrkCashIntDebug = .Out_Debug
    End With

    If myTXINV._ICODE = "I" Then
      LblInterest.Text = Format(0, "standard")
      LblDue.Text = Format(0, "standard")
      WrkCashIntDebug = WrkCashIntDebug & vbCrLf & "*** INACTIVE ***"
    End If
    If MyUtils.CnvSng(LblFee.Text) > 0 Then
      LnkFee.Visible = True
    Else
      LnkFee.Visible = False
    End If
    If MyUtils.CnvSng(LblUnpostedLien.Text) > 0 Then
      LblLien.Text = Format(MyUtils.CnvSng(LblLien.Text) - MyUtils.CnvSng(LblUnpostedLien.Text), "standard")
      If MyUtils.CnvSng(LblLien.Text) < 0 Then
        LblLien.Text = "0.00"
      End If
      LblDue.Text = Format(MyUtils.CnvSng(LblDue.Text) - MyUtils.CnvSng(LblUnpostedLien.Text), "standard")
      If MyUtils.CnvSng(LblDue.Text) < 0 Then
        LblDue.Text = "0.00"
      End If
    End If
    If MyUtils.CnvSng(LblUnPostedFee.Text) > 0 Then
      LblFee.Text = Format(MyUtils.CnvSng(LblFee.Text) - MyUtils.CnvSng(LblUnPostedFee.Text), "standard")
      If MyUtils.CnvSng(LblFee.Text) < 0 Then
        LblFee.Text = "0.00"
      End If
      LblDue.Text = Format(MyUtils.CnvSng(LblDue.Text) - MyUtils.CnvSng(LblUnPostedFee.Text), "standard")
      If MyUtils.CnvSng(LblDue.Text) < 0 Then
        LblDue.Text = "0.00"
      End If
    End If
    mycashint.CloseFiles()
    mycashint = Nothing
  End Sub
  Public Sub CalcInterest_219SW()
    Dim mycashint As CASHINT.MyData
    Dim WrkType2 As String
    Dim WrkInterest As Decimal
    Dim WrkOrigInterest As Decimal
    Dim WrkIntPaid2 As Boolean
    Dim WrkDiff As Decimal
    'MK 7/16/25 Begin
    Dim WrkNoType2 As Boolean
    'MK 7/16/25 End
    'MK 7/22/25 Begin
    Dim WrkDue As Decimal
    'MK 7/22/25 End

    WrkCashIntDebug = String.Empty
    If LblType.Text = "S" Then
      WrkType2 = "W"
    Else
      WrkType2 = "S"
    End If
    'MK 7/16/25 Begin
    WrkNoType2 = False
    'MK 7/16/25 End
    WrkIntPaid2 = False

    mycashint = New CASHINT.MyData(myDBConnect)
    With mycashint
      .In_IntDate = DtPckInt.Value
      .In_ListNo = MyUtils.CnvSng(LblList.Text)
      .In_Type = LblType.Text
      .In_Year = MyUtils.CnvSng(LblYear.Text)
      .CalcInterest()
      WrkInterest = .Out_Int()
      WrkOrigInterest = .Out_IntOrig()
      LblLien.Text = Format(.Out_Lien(), "standard")
      LblFee.Text = Format(.Out_Fee(), "standard")
      LblCAFee.Text = Format(.Out_CAFee(), "standard")
      LblBond.Text = Format(.Out_Bond(), "standard")
      LblTax.Text = Format(.Out_Prin(), "standard")
      LblDue.Text = Format(.Out_Tot(), "standard")
      LblIntPaid.Text = Format(.Out_IntPaid(), "standard")
      If LblBondPaidHdr.Text = "Fee Paid" Then
        LblBondPaid.Text = Format(.Out_FeePaid(), "standard")
      End If
      WrkCashIntDebug = .Out_Debug
    End With

    If MyUtils.CnvSng(LblIntPaid.Text) = 0 And WrkOrigInterest > 0 And WrkInterest <> WrkOrigInterest Then 'MK 6/4/26 Added: MyUtils.CnvSng(LblIntPaid.Text) = 0 And 
      With mycashint
        .In_IntDate = DtPckInt.Value
        .In_ListNo = MyUtils.CnvSng(LblList.Text)
        .In_Type = WrkType2
        .In_Year = MyUtils.CnvSng(LblYear.Text)
        .CalcInterest()
        WrkIntPaid2 = .Out_IntPaid
        If .Out_IntOrig > 0 And .Out_ProfMinInt > WrkOrigInterest + .Out_IntOrig Then
          WrkDiff = .Out_ProfMinInt * (WrkOrigInterest / (WrkOrigInterest + .Out_IntOrig))
          WrkOrigInterest = WrkDiff
        End If
        'MK 7/16/25 Begin
        'MK 7/23/25 Begin
        'If .Out_Tot = 0 Then
        If .Out_Tot = 0 And .Out_ProfMinInt = 0 Or .Out_Tot = 0 And WrkIntPaid2 = 0 Then
          'MK 7/23/25 End
          WrkNoType2 = True
        End If
        'MK 7/16/25 End
      End With
    End If

    LblInterest.Text = Format(WrkOrigInterest, "standard")
    'MK 7/16/25 Begin
    If WrkNoType2 Then
      LblInterest.Text = Format(WrkInterest, "standard")
    End If
    'MK 7/16/25 End
    If myTXINV._ICODE = "I" Then
      LblInterest.Text = Format(0, "standard")
      LblDue.Text = Format(0, "standard")
      WrkCashIntDebug = WrkCashIntDebug & vbCrLf & "*** INACTIVE ***"
    End If
    'MK 7/22/25 Begin
    WrkDue = MyUtils.CnvSng(LblTax.Text) + MyUtils.CnvSng(LblInterest.Text) + MyUtils.CnvSng(LblLien.Text) _
     + MyUtils.CnvSng(LblFee.Text)
    LblDue.Text = Format(WrkDue, "standard")
    'MK 7/22/25 Begin
    If MyUtils.CnvSng(LblFee.Text) > 0 Then
      LnkFee.Visible = True
    Else
      LnkFee.Visible = False
    End If
    If MyUtils.CnvSng(LblUnpostedLien.Text) > 0 Then
      LblLien.Text = Format(MyUtils.CnvSng(LblLien.Text) - MyUtils.CnvSng(LblUnpostedLien.Text), "standard")
      If MyUtils.CnvSng(LblLien.Text) < 0 Then
        LblLien.Text = "0.00"
      End If
      LblDue.Text = Format(MyUtils.CnvSng(LblDue.Text) - MyUtils.CnvSng(LblUnpostedLien.Text), "standard")
      If MyUtils.CnvSng(LblDue.Text) < 0 Then
        LblDue.Text = "0.00"
      End If
    End If
    If MyUtils.CnvSng(LblUnPostedFee.Text) > 0 Then
      LblFee.Text = Format(MyUtils.CnvSng(LblFee.Text) - MyUtils.CnvSng(LblUnPostedFee.Text), "standard")
      If MyUtils.CnvSng(LblFee.Text) < 0 Then
        LblFee.Text = "0.00"
      End If
      LblDue.Text = Format(MyUtils.CnvSng(LblDue.Text) - MyUtils.CnvSng(LblUnPostedFee.Text), "standard")
      If MyUtils.CnvSng(LblDue.Text) < 0 Then
        LblDue.Text = "0.00"
      End If
    End If
    mycashint.CloseFiles()
    mycashint = Nothing
  End Sub
  Public Sub SetColAgency()
    LblColAgency.Visible = False
    If Trim(myTXINV._AGY) <> String.Empty Then
      If MyUtils.CnvSng(LblDue.Text) > 0 Then
        LblColAgency.Visible = True
      End If
    End If
  End Sub
  Private Sub GetUnpostedInt()
    Dim dstxbatchl1 As DataSet = New DataSet
    Dim I As Integer
    Dim WrkUnpostedInt As Decimal
    Dim WrkUnpostedFee As Decimal
    Dim WrkUnpostedLien As Decimal

    dstxbatchl1 = mytxbatchl1.GetViewbyList(WrkListNo, WrkYear, WrkType, 999)
    For I = 0 To (dstxbatchl1.Tables(0).Rows.Count - 1)
      With dstxbatchl1.Tables(0).Rows(I)
        If .Item("jstat") <> "V" Then
          WrkUnpostedInt = WrkUnpostedInt + .Item("iamt")
          If .Item("cpencd") <> "BI" Then
            WrkUnpostedFee = WrkUnpostedFee + .Item("tcamt")
          End If
          WrkUnpostedLien = WrkUnpostedLien + .Item("lamt")
        End If
      End With
    Next

    LblUnpostedInt.Text = Format(WrkUnpostedInt, "standard")
    LblUnPostedFee.Text = Format(WrkUnpostedFee, "standard")
    LblUnpostedLien.Text = Format(WrkUnpostedLien, "standard")

    mytxbatchl1.CloseFile()
    dstxbatchl1.Clear()
    dstxbatchl1 = Nothing
  End Sub
  Private Function CalcUnpostedFees(ByVal Pencd As String) As Decimal
    Dim WrkFee As Decimal

    WrkFee = mytxbatchl1.CalcListFee(WrkListNo, WrkYear, WrkType, Pencd)
  End Function
  Private Sub DtPckInt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtPckInt.ValueChanged
    If myTOWN._TOWNBR = 219 And {"S", "W"}.Contains(LblType.Text) Then
      CalcInterest_219SW()
    Else
      CalcInterest()
    End If
    MyInterestOverrideDate = DtPckInt.Value
  End Sub
  Private Sub BtnPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPayment.Click
    MyFrmTXA099 = New FrmTXA099
    With MyFrmTXA099
      .WrkListNo = WrkListNo
      .WrkYear = WrkYear
      .WrkType = WrkType
      .WrkICode = WrkICode
      .WrkFee1 = myTXINV._FED1
      .WrkFee2 = myTXINV._FED2
      .WrkFee3 = myTXINV._FED3
      .WrkFee4 = myTXINV._FED4
      .WrkFee5 = myTXINV._FED5
      .WrkFeeCd1 = Trim(myTXINV._FEC1)
      .WrkFeeCd2 = Trim(myTXINV._FEC2)
      .WrkFeeCd3 = Trim(myTXINV._FEC3)
      .WrkFeeCd4 = Trim(myTXINV._FEC4)
      .WrkFeeCd5 = Trim(myTXINV._FEC5)
      .WrkMVFee = WrkMVFee
      .WrkCAFee = MyUtils.CnvSng(MyFrmTXA09B.LblCAFee.Text)
      .MdiParent = Me.ParentForm
      .Show()
    End With
    Me.Hide()
  End Sub
  Private Sub BtnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHistory.Click
    MyFrmTXA09Hist = New FrmTXA09Hist
    MyFrmTXA09Hist.WrkListNo = WrkListNo
    MyFrmTXA09Hist.WrkYear = WrkYear
    MyFrmTXA09Hist.WrkType = WrkType
    MyFrmTXA09Hist.WrkDate = 99999999
    MyFrmTXA09Hist.MdiParent = Me.ParentForm
    MyFrmTXA09Hist.Show()
    Me.Hide()
  End Sub
  Private Sub BtnCCHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCCHistory.Click
    Dim WrkFamily As String
    WrkFamily = GetTXTypeFamily(WrkType)
    Select Case WrkFamily
      Case "A", "U" 'UB Adjustment 
        MyFrmTXA09CCUB = New FrmTXA09CCUB
        MyFrmTXA09CCUB.WrkListNo = WrkListNo
        MyFrmTXA09CCUB.WrkYear = WrkYear
        MyFrmTXA09CCUB.WrkType = WrkType
        MyFrmTXA09CCUB.WrkDate = 99999999
        MyFrmTXA09CCUB.MdiParent = Me.ParentForm
        MyFrmTXA09CCUB.Show()
        Me.Hide()
        Exit Sub
      Case Else
        MyFrmTXA09CC = New FrmTXA09CC
        MyFrmTXA09CC.WrkListNo = WrkListNo
        MyFrmTXA09CC.WrkYear = WrkYear
        MyFrmTXA09CC.WrkType = WrkType
        MyFrmTXA09CC.WrkDate = 99999999
        MyFrmTXA09CC.MdiParent = Me.ParentForm
        MyFrmTXA09CC.Show()
        Me.Hide()
        Exit Sub
    End Select
  End Sub
  Private Sub BtnTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTotal.Click
    MyFrmTXA09B.Close()
    MyFrmTXA094.Hide()
    MyFrmTXA09Total = New FrmTXA09Total
    MyFrmTXA09Total.WrkBatchSeqNo = 0
    MyFrmTXA09Total.WrkPos = String.Empty
    MyFrmTXA09Total.WrkPosNo = String.Empty
    MyFrmTXA09Total.MdiParent = MyFrmTXA091.ParentForm
    MyFrmTXA09Total.Show()
  End Sub
  Private Sub BtnDupBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDupBill.Click
    PrtDupBill(WrkListNo, WrkType, WrkYear, MyFrmTXA09B.DtPckInt.Value, MyAppSettings.DupBillPrinter)
  End Sub
  Private Sub BtnPDFBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPDFBill.Click
    PrtDupBill(WrkListNo, WrkType, WrkYear, MyFrmTXA09B.DtPckInt.Value, MyAppSettings.PDFBillPrinter)
  End Sub
  Private Sub BtnLetter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLetter.Click
    PrtLetter(WrkListNo, WrkType, WrkYear, MyFrmTXA09B.DtPckInt.Value)
  End Sub
  Private Sub BtnAdjust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdjust.Click
    MyFrmTXA09Adj = New FrmTXA09Adj
    MyFrmTXA09Adj.WrkListNo = WrkListNo
    MyFrmTXA09Adj.WrkYear = WrkYear
    MyFrmTXA09Adj.WrkType = WrkType
    MyFrmTXA09Adj.WrkICode = WrkICode
    MyFrmTXA09Adj.ShowDialog()
  End Sub
  Private Sub BtnLienRel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLienRel.Click
    PrtLienRel(WrkListNo, WrkType, WrkYear)
  End Sub
  Private Sub BtnComments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnComments.Click
    MyFrmComments = New FrmComments
    MyFrmComments.WrkListNo = WrkListNo
    MyFrmComments.WrkYear = WrkYear
    MyFrmComments.WrkType = WrkType
    MyFrmComments.WrkName = LblName.Text
    MyFrmComments.MdiParent = Me.ParentForm
    MyFrmComments.Show()
    Me.Hide()
  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    Dim I As Integer
    Dim WrkGridComplete As Boolean

    If Not IsNothing(MyFrmTXA094B) Then
      MyFrmTXA094B.ProcessGridItems(WrkGridComplete, True, I)
      If Not WrkGridComplete Then
        WrkListNo = SelListNo(I)
        WrkType = SelType(I)
        WrkYear = SelYear(I)
        LoadForm()
        If myTOWN._TOWNBR = 219 And {"S", "W"}.Contains(LblType.Text) Then
          CalcInterest_219SW()
        Else
          CalcInterest()
        End If
        SetColAgency()
        Exit Sub
      End If
    End If

    With MyFrmTXA094
      If .C1DataGrdList.Row = .C1DataGrdList.Splits(0).Rows.Count - 1 Then
        MsgBox("No more records in view. You can change the view from the search screen", MsgBoxStyle.Exclamation, "Cannot get next record")
        Exit Sub
      End If

      .C1DataGrdList.Row = .C1DataGrdList.Row + 1
      WrkListNo = .C1DataGrdList.Item(.C1DataGrdList.Row, 3)
      WrkType = .C1DataGrdList.Item(.C1DataGrdList.Row, 4)
      WrkYear = .C1DataGrdList.Item(.C1DataGrdList.Row, 5)
    End With

    LoadForm()
    If myTOWN._TOWNBR = 219 And {"S", "W"}.Contains(LblType.Text) Then
      CalcInterest_219SW()
    Else
      CalcInterest()
    End If
    SetColAgency()
  End Sub
  Private Sub BtnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click
    With MyFrmTXA094
      If .C1DataGrdList.Row = 0 Then
        MsgBox("No previous records in view. You can change the view from the search screen", MsgBoxStyle.Exclamation, "Cannot get previous record")
        Exit Sub
      End If

      .C1DataGrdList.Row = .C1DataGrdList.Row - 1
      WrkListNo = .C1DataGrdList.Item(.C1DataGrdList.Row, 3)
      WrkType = .C1DataGrdList.Item(.C1DataGrdList.Row, 4)
      WrkYear = .C1DataGrdList.Item(.C1DataGrdList.Row, 5)
    End With

    LoadForm()
    If myTOWN._TOWNBR = 219 And {"S", "W"}.Contains(LblType.Text) Then
      CalcInterest_219SW()
    Else
      CalcInterest()
    End If
    SetColAgency()
  End Sub
  Private Sub label25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles label25.Click
    MsgBox(WrkCashIntDebug)
  End Sub
  Private Sub GetTxProf(ByVal PrintDist As Integer)
    'Shows/Hides 2nd, 3rd & 4th payments depending on # of billing periods
    Dim WrkDist As Integer
    Dim WrkPhase As String

    If MyUtils.CnvSng(MyFrmTXA09B.LblPhase.Text) = 0 Then
      WrkPhase = String.Empty
    Else
      WrkPhase = MyUtils.CnvSng(MyFrmTXA09B.LblPhase.Text)
    End If
    If PrintDist > 0 Then
      WrkDist = PrintDist
    Else
      WrkDist = MyUtils.CnvSng(MyFrmTXA09B.LblDist.Text)
    End If
    myTXPROF.GetOneRecordP(WrkType, WrkYear, WrkPhase, WrkDist)

    LblTax2.Visible = False
    LblTax2Txt.Visible = False
    LblTax3.Visible = False
    LblTax3Txt.Visible = False
    LblTax4.Visible = False
    LblTax4Txt.Visible = False
    LblCCTax2.Visible = False
    LblCCTax2Txt.Visible = False
    LblCCTax3.Visible = False
    LblCCTax3Txt.Visible = False
    LblCCTax4.Visible = False
    LblCCTax4Txt.Visible = False

    If myTXPROF.RecordNotFound Then
      If PrintDist > 0 Then
        'If print district record not found use district 0 instead
        myTXPROF.GetOneRecordP(WrkType, WrkYear, WrkPhase, 0)
        If myTXPROF.RecordNotFound Then Exit Sub
      End If
    End If

    With myTXPROF
      LblTax1Txt.Text = "1st  " & Format(MyUtils.GetDBDateMDY(._PRDUE1), "M/d/yyyy")
      If ._PRPERD > 1 Then
        LblTax2.Visible = True
        LblTax2Txt.Visible = True
        LblTax2Txt.Text = "2nd  " & Format(MyUtils.GetDBDateMDY(._PRDUE2), "M/d/yyyy")
        LblCCTax2.Visible = True
        LblCCTax2Txt.Visible = True
      End If
      If ._PRPERD > 2 Then
        LblTax3.Visible = True
        LblTax3Txt.Visible = True
        LblTax3Txt.Text = "3rd  " & Format(MyUtils.GetDBDateMDY(._PRDUE3), "M/d/yyyy")
        LblCCTax3.Visible = True
        LblCCTax3Txt.Visible = True
      End If
      If ._PRPERD > 3 Then
        LblTax4.Visible = True
        LblTax4Txt.Visible = True
        LblTax4Txt.Text = "4th  " & Format(MyUtils.GetDBDateMDY(._PRDUE4), "M/d/yyyy")
        LblCCTax4.Visible = True
        LblCCTax4Txt.Visible = True
      End If
    End With
    If WrkType = "X" Then
      LblTax1Txt.Text = "1st  " & Format(MyUtils.GetDBDate(myTXINV._PDAT), "M/d/yyyy")
    End If

  End Sub
  Private Sub FrmTXA09B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

    If MyInquiryMode Then Exit Sub

    If e.KeyCode = Keys.Enter Then
      MyFrmTXA099 = New FrmTXA099
      MyFrmTXA099.WrkListNo = WrkListNo
      MyFrmTXA099.WrkYear = WrkYear
      MyFrmTXA099.WrkType = WrkType
      MyFrmTXA099.WrkICode = WrkICode
      MyFrmTXA099.MdiParent = Me.ParentForm
      MyFrmTXA099.Show()
      Me.Hide()
      Exit Sub
    End If
  End Sub
  Private Sub LnkBenefits_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBenefits.LinkClicked
    MyFrmTXA09Ben = New FrmTXA09Ben
    MyFrmTXA09Ben.WrkListNo = WrkListNo
    MyFrmTXA09Ben.WrkYear = WrkYear
    MyFrmTXA09Ben.WrkType = WrkType
    MyFrmTXA09Ben.MdiParent = Me.ParentForm
    MyFrmTXA09Ben.Show()
    Me.Hide()
  End Sub

  Private Sub LnkUBA_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkUBA.LinkClicked
    MyFrmTXA09UBA = New FrmTXA09UBA
    MyFrmTXA09UBA.WrkListNo = WrkListNo
    MyFrmTXA09UBA.WrkYear = WrkYear
    MyFrmTXA09UBA.WrkType = WrkType
    MyFrmTXA09UBA.MdiParent = Me.ParentForm
    MyFrmTXA09UBA.Show()
    Me.Hide()
  End Sub

  Private Sub LnkCrVehicle_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCrVehicle.LinkClicked
    MyFrmTXA09Crd = New FrmTXA09Crd
    MyFrmTXA09Crd.WrkListNo = WrkListNo
    MyFrmTXA09Crd.WrkYear = WrkYear
    MyFrmTXA09Crd.WrkType = WrkType
    MyFrmTXA09Crd.MdiParent = Me.ParentForm
    MyFrmTXA09Crd.Show()
    Me.Hide()
  End Sub
  Private Sub InitFiles()
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXINV2 = New TXINV.MyData(myDBConnect)
    myTXMRATE = New TXMRATE.MyData(myDBConnect)
    myTXPROF = New TXPROF.MyData(myDBConnect)
    myTXCOEA = New TXCOEA.MyData(myDBConnect)
    'MK 9/25/25 Begin
    myTXCOEBL1 = New TXCOEBL1.MyData(myDBConnect)
    'MK 9/25/25 End
    mytxbatchl1 = New TXBATCHL1.MyData(myDBConnect)
    myTAXCOM = New TAXCOM.MyData(myDBConnect)
    myTXINVDTL = New TXINVDTL.MyData(myDBConnect)
  End Sub

  Private Sub CloseFiles()
    myTXINV.CloseFile()
    myTXINV2.CloseFile()
    myTXMRATE.CloseFile()
    myTXPROF.CloseFile()
    mytxbatchl1.CloseFile()
    myTAXCOM.CloseFile()
  End Sub

  Private Sub LnkStatus_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkStatus.LinkClicked
    MyFrmTXA09Stat = New FrmTXA09Stat
    With MyFrmTXA09Stat
      .WrkListNo = WrkListNo
      .WrkYear = WrkYear
      .WrkType = WrkType
      .MdiParent = Me.ParentForm
      .Show()
    End With
    Me.Hide()
  End Sub
  Private Sub LnkFees_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFee.LinkClicked

    MyFrmTXA09Fees = New FrmTXA09Fees
    With MyFrmTXA09Fees
      .WrkListNo = WrkListNo
      .WrkYear = WrkYear
      .WrkType = WrkType
      .WrkCode1 = Trim(myTXINV._FEC1)
      .WrkCode2 = Trim(myTXINV._FEC2)
      .WrkCode3 = Trim(myTXINV._FEC3)
      .WrkCode4 = Trim(myTXINV._FEC4)
      .WrkCode5 = Trim(myTXINV._FEC5)
      .WrkAmt1 = Trim(myTXINV._FED1)
      .WrkAmt2 = Trim(myTXINV._FED2)
      .WrkAmt3 = Trim(myTXINV._FED3)
      .WrkAmt4 = Trim(myTXINV._FED4)
      .WrkAmt5 = Trim(myTXINV._FED5)
      .WrkMVFee = WrkMVFee
      .WrkCAFee = MyUtils.CnvSng(LblCAFee.Text)
      .MdiParent = Me.ParentForm
      .Show()
    End With
    Me.Hide()
  End Sub

  Private Sub LblComment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblComment.Click

  End Sub

  Private Sub LnkDMV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDMV.LinkClicked
    MyFrmTXA09DMV = New FrmTXA09DMV
    MyFrmTXA09DMV.WrkRegNo = Trim(myTXINV._IMVREG)
    MyFrmTXA09DMV.MdiParent = Me.ParentForm
    MyFrmTXA09DMV.Show()
    Me.Hide()
  End Sub

  Private Sub BtnPayCredit_Click(sender As Object, e As EventArgs) Handles BtnPayCredit.Click
    Dim myDr As DataRow

    myDr = MydsPayCredit.Tables(0).NewRow
    myDr("Desc") = LblName.Text
    myDr("ListNo") = LblList.Text
    myDr("Type") = LblType.Text
    myDr("Year") = LblYear.Text
    myDr("Balance") = LblRemain.Text
    myDr("Tax") = LblTax.Text
    myDr("Interest") = LblInterest.Text
    myDr("Fee") = LblFee.Text
    myDr("Lien") = LblLien.Text
    myDr("Bond") = LblBond.Text
    myDr("Total") = LblDue.Text
    MydsPayCredit.Tables(0).Rows.Add(myDr)

    BtnPayCredit.Text = "Credit " & MydsPayCredit.Tables(0).Rows.Count & " (Web)"

  End Sub

  Private Sub LnkDeferred_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkDeferred.LinkClicked
    MyFrmTXA09Defer = New FrmTXA09Defer
    MyFrmTXA09Defer.WrkListNo = WrkListNo
    MyFrmTXA09Defer.WrkYear = WrkYear
    MyFrmTXA09Defer.WrkType = WrkType
    MyFrmTXA09Defer.MdiParent = Me.ParentForm
    MyFrmTXA09Defer.Show()
    Me.Hide()
  End Sub
  Private Sub btndetail_Click(sender As Object, e As EventArgs) Handles btndetail.Click
    MyFrmInvDetail = New FrmInvDetail
    MyFrmInvDetail.WrkListNo = WrkListNo
    MyFrmInvDetail.WrkYear = WrkYear
    MyFrmInvDetail.WrkType = WrkType
    MyFrmInvDetail.MdiParent = Me.MdiParent
    MyFrmInvDetail.Show()
  End Sub
End Class
