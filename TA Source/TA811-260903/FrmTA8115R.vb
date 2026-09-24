Imports System.Runtime.CompilerServices.RuntimeHelpers

Public Class FrmTA8115R
  Inherits System.Windows.Forms.Form
  Dim MyTXMCTL As TXMCTL.MyData
  Dim MyTXCOEA As TXCOEA.MyData
  Dim MyTXCOEAL1 As TXCOEAL1.MyData
  Dim MyTXCOEBL4 As TXCOEBL4.MyData
  Dim MyTXINV As TXINV.MyData
  Dim MyTXMRATE As TXMRATE.MyData
  Dim MyTXVCUS As TXVCUS.MyData
  Dim MyTXVEH As TXVEH.MyData
  Dim MyTPAYMNT As TPAYMNT.MyData
  Dim myTXMSRP As TXMSRP.MyData
  Dim myTXMSRPDEP As TXMSRPDEP.MyData
  Dim myTXMSRPCD As TXMSRPCD.MyData
  Dim myPriceDigestVIN As PriceDigestAPI.ApiVIN
  Dim myPriceDigestValue As PriceDigestAPI.ApiValue
  Dim myPriceDigestSpecs As PriceDigestAPI.ApiSpecs
  Dim dsTXCOEAL1 As DataSet = New DataSet
  Friend WrkAddMode As Boolean
  Friend WrkCCNo As Integer
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkType As String
  Friend WrkFamily As String
  Friend WrkDist As Integer
  Friend WrkCCDate As Date
  Dim LoadScrn As Boolean
  Friend WithEvents LblBeforeCC As System.Windows.Forms.Label
  Friend WithEvents LnkClass As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkCRClass As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkPurchMonth As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkSaleMonth As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkCRSaleMonth As System.Windows.Forms.LinkLabel
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TxtSS2 As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents TxtSSNo As System.Windows.Forms.TextBox
  Friend WithEvents Label31 As System.Windows.Forms.Label
  Friend WithEvents TxtOid As System.Windows.Forms.TextBox
  Friend WithEvents Label36 As System.Windows.Forms.Label
  Friend WithEvents Label37 As System.Windows.Forms.Label
  Friend WithEvents GroupBox2 As GroupBox
  Friend WithEvents LblChgAdjGross As Label
  Friend WithEvents LblNewAdjGross As Label
  Friend WithEvents LblOrigAdjGross As Label
  Friend WithEvents Label53 As Label
  Friend WithEvents LblChgNet As Label
  Friend WithEvents LblNewNet As Label
  Friend WithEvents LblOrigNet As Label
  Friend WithEvents LblChgProrate As Label
  Friend WithEvents LblNewProrate As Label
  Friend WithEvents LblOrigProrate As Label
  Friend WithEvents LblChgExam As Label
  Friend WithEvents LblNewExam As Label
  Friend WithEvents Label21 As Label
  Friend WithEvents Label20 As Label
  Friend WithEvents Label19 As Label
  Friend WithEvents LblChgGross As Label
  Friend WithEvents Label34 As Label
  Friend WithEvents LblNewGross As Label
  Friend WithEvents LblOrigGross As Label
  Friend WithEvents LblOrigExam As Label
  Friend WithEvents Label30 As Label
  Friend WithEvents LblOrig As Label
  Friend WithEvents Label22 As Label
  Friend WithEvents Label24 As Label
  Friend WithEvents LblChgAmt As Label
  Friend WithEvents LblNewAmt As Label
  Friend WithEvents LblOrigAmt As Label
  Friend WithEvents LblMSRPCalc As Label
  Friend WithEvents ChkComplete As CheckBox
  Friend WithEvents TxtSource As TextBox
  Friend WithEvents LnkSource As LinkLabel
  Friend WithEvents Label38 As Label
  Friend WithEvents TxtOVMSRP As TextBox
  Friend WithEvents LblMSRP As Label
  Friend WithEvents Label40 As Label
  Friend WithEvents LblValue As Label
  Friend WithEvents Label41 As Label
  Friend WithEvents LblCRMSRP As Label
  Friend WithEvents Label43 As Label
  Friend WithEvents LblCRValue As Label
  Friend WithEvents Label44 As Label
  Friend WithEvents LblCRMSRPCalc As Label
  Friend WithEvents ChkCRComplete As CheckBox
  Friend WithEvents TxtCRSource As TextBox
  Friend WithEvents LnkCRSource As LinkLabel
  Friend WithEvents Label45 As Label
  Friend WithEvents TxtCROVMSRP As TextBox
  Friend WithEvents LblPDMsg As Label
  Friend WithEvents BtnPriceDigest As Button
  Friend WithEvents LblCRPDMsg As Label
  Friend WithEvents BtnCRPriceDigest As Button
  Dim EntryDate As Date

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
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents TxtAdd1 As System.Windows.Forms.TextBox
  Friend WithEvents Label42 As System.Windows.Forms.Label
  Friend WithEvents LblType As System.Windows.Forms.Label
  Friend WithEvents LblYear As System.Windows.Forms.Label
  Friend WithEvents TxtAdd2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtSname As System.Windows.Forms.TextBox
  Friend WithEvents TxtZip5 As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents LblCCNo As System.Windows.Forms.Label
  Friend WithEvents LblListNo As System.Windows.Forms.Label
  Friend WithEvents LblCCDate As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents TxtCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtZip4 As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtDist As System.Windows.Forms.TextBox
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpMain As System.Windows.Forms.TabPage
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtModel As System.Windows.Forms.TextBox
  Friend WithEvents Label27 As System.Windows.Forms.Label
  Friend WithEvents TxtMake As System.Windows.Forms.TextBox
  Friend WithEvents Label25 As System.Windows.Forms.Label
  Friend WithEvents TxtMVYear As System.Windows.Forms.TextBox
  Friend WithEvents TxtClass As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents TxtReg As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtID As System.Windows.Forms.TextBox
  Friend WithEvents LnkReason As System.Windows.Forms.LinkLabel
  Friend WithEvents LblMRate As System.Windows.Forms.Label
  Friend WithEvents Label26 As System.Windows.Forms.Label
  Friend WithEvents LblBankCd As System.Windows.Forms.Label
  Friend WithEvents TxtOverAmt As System.Windows.Forms.TextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents ChkOver As System.Windows.Forms.CheckBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
  Friend WithEvents TxtReason As System.Windows.Forms.TextBox
  Friend WithEvents TpAssmnt As System.Windows.Forms.TabPage
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtSaleMonth As System.Windows.Forms.TextBox
  Friend WithEvents LblChgAssmt1 As System.Windows.Forms.Label
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents TxtAssmt1 As System.Windows.Forms.TextBox
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents LblOrigAssmt1 As System.Windows.Forms.Label
  Friend WithEvents TpExemptions As System.Windows.Forms.TabPage
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents LblChgExam5 As System.Windows.Forms.Label
  Friend WithEvents LblChgExam4 As System.Windows.Forms.Label
  Friend WithEvents LblChgExam3 As System.Windows.Forms.Label
  Friend WithEvents LblChgExam2 As System.Windows.Forms.Label
  Friend WithEvents LblChgExam1 As System.Windows.Forms.Label
  Friend WithEvents Label70 As System.Windows.Forms.Label
  Friend WithEvents LblOrigExam5 As System.Windows.Forms.Label
  Friend WithEvents LblOrigExam4 As System.Windows.Forms.Label
  Friend WithEvents LblOrigExam3 As System.Windows.Forms.Label
  Friend WithEvents LblOrigExam2 As System.Windows.Forms.Label
  Friend WithEvents Label58 As System.Windows.Forms.Label
  Friend WithEvents LblOrigExam1 As System.Windows.Forms.Label
  Friend WithEvents LnkExempt5 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtExempt5 As System.Windows.Forms.TextBox
  Friend WithEvents LnkExempt3 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtExempt3 As System.Windows.Forms.TextBox
  Friend WithEvents LnkExempt4 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtExempt4 As System.Windows.Forms.TextBox
  Friend WithEvents LnkExempt2 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtExempt2 As System.Windows.Forms.TextBox
  Friend WithEvents LnkExempt1 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtExempt1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam1 As System.Windows.Forms.TextBox
  Friend WithEvents Label50 As System.Windows.Forms.Label
  Friend WithEvents Label52 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtCRModel As System.Windows.Forms.TextBox
  Friend WithEvents Label28 As System.Windows.Forms.Label
  Friend WithEvents TxtCRMake As System.Windows.Forms.TextBox
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents TXTCRMVYear As System.Windows.Forms.TextBox
  Friend WithEvents TxtCRClass As System.Windows.Forms.TextBox
  Friend WithEvents Label32 As System.Windows.Forms.Label
  Friend WithEvents TXTCRReg As System.Windows.Forms.TextBox
  Friend WithEvents Label33 As System.Windows.Forms.Label
  Friend WithEvents TxtCRID As System.Windows.Forms.TextBox
  Friend WithEvents LblSalePct As System.Windows.Forms.Label
  Friend WithEvents TxtPurchMonth As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtCRSaleMonth As System.Windows.Forms.TextBox
  Friend WithEvents TxtCRAssmt1 As System.Windows.Forms.TextBox
  Friend WithEvents Label46 As System.Windows.Forms.Label
  Friend WithEvents LblPurchPct As System.Windows.Forms.Label
  Friend WithEvents LblCRSalePct As System.Windows.Forms.Label
  Friend WithEvents LblPurchNet As System.Windows.Forms.Label
  Friend WithEvents LblSaleNet As System.Windows.Forms.Label
  Friend WithEvents LblCRSaleNet As System.Windows.Forms.Label
  Friend WithEvents Label35 As System.Windows.Forms.Label
  Friend WithEvents Label39 As System.Windows.Forms.Label
  Friend WithEvents LblOrigCRAssmt1 As System.Windows.Forms.Label
  Friend WithEvents LblChgCRAssmt1 As System.Windows.Forms.Label
  Friend WithEvents LblAdjNet As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtAdd1 = New System.Windows.Forms.TextBox()
    Me.Label42 = New System.Windows.Forms.Label()
    Me.LblType = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.TxtAdd2 = New System.Windows.Forms.TextBox()
    Me.TxtSname = New System.Windows.Forms.TextBox()
    Me.TxtZip5 = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LblCCNo = New System.Windows.Forms.Label()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.LblCCDate = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.TxtZip4 = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TpMain = New System.Windows.Forms.TabPage()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.LblPDMsg = New System.Windows.Forms.Label()
    Me.BtnPriceDigest = New System.Windows.Forms.Button()
    Me.LblMSRPCalc = New System.Windows.Forms.Label()
    Me.ChkComplete = New System.Windows.Forms.CheckBox()
    Me.TxtSource = New System.Windows.Forms.TextBox()
    Me.LnkSource = New System.Windows.Forms.LinkLabel()
    Me.Label38 = New System.Windows.Forms.Label()
    Me.TxtOVMSRP = New System.Windows.Forms.TextBox()
    Me.LblMSRP = New System.Windows.Forms.Label()
    Me.Label40 = New System.Windows.Forms.Label()
    Me.LblValue = New System.Windows.Forms.Label()
    Me.Label41 = New System.Windows.Forms.Label()
    Me.Label36 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtSS2 = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TxtSSNo = New System.Windows.Forms.TextBox()
    Me.Label31 = New System.Windows.Forms.Label()
    Me.TxtOid = New System.Windows.Forms.TextBox()
    Me.LnkClass = New System.Windows.Forms.LinkLabel()
    Me.TxtModel = New System.Windows.Forms.TextBox()
    Me.Label27 = New System.Windows.Forms.Label()
    Me.TxtMake = New System.Windows.Forms.TextBox()
    Me.Label25 = New System.Windows.Forms.Label()
    Me.TxtMVYear = New System.Windows.Forms.TextBox()
    Me.TxtClass = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtReg = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtID = New System.Windows.Forms.TextBox()
    Me.LnkReason = New System.Windows.Forms.LinkLabel()
    Me.LblMRate = New System.Windows.Forms.Label()
    Me.Label26 = New System.Windows.Forms.Label()
    Me.LblBankCd = New System.Windows.Forms.Label()
    Me.TxtOverAmt = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.ChkOver = New System.Windows.Forms.CheckBox()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.TxtDesc = New System.Windows.Forms.TextBox()
    Me.TxtReason = New System.Windows.Forms.TextBox()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.LblCRPDMsg = New System.Windows.Forms.Label()
    Me.BtnCRPriceDigest = New System.Windows.Forms.Button()
    Me.LblCRMSRP = New System.Windows.Forms.Label()
    Me.Label43 = New System.Windows.Forms.Label()
    Me.LblCRValue = New System.Windows.Forms.Label()
    Me.Label44 = New System.Windows.Forms.Label()
    Me.LblCRMSRPCalc = New System.Windows.Forms.Label()
    Me.ChkCRComplete = New System.Windows.Forms.CheckBox()
    Me.TxtCRSource = New System.Windows.Forms.TextBox()
    Me.LnkCRSource = New System.Windows.Forms.LinkLabel()
    Me.Label45 = New System.Windows.Forms.Label()
    Me.TxtCROVMSRP = New System.Windows.Forms.TextBox()
    Me.Label37 = New System.Windows.Forms.Label()
    Me.LnkCRClass = New System.Windows.Forms.LinkLabel()
    Me.TxtCRModel = New System.Windows.Forms.TextBox()
    Me.Label28 = New System.Windows.Forms.Label()
    Me.TxtCRMake = New System.Windows.Forms.TextBox()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.TXTCRMVYear = New System.Windows.Forms.TextBox()
    Me.TxtCRClass = New System.Windows.Forms.TextBox()
    Me.Label32 = New System.Windows.Forms.Label()
    Me.TXTCRReg = New System.Windows.Forms.TextBox()
    Me.Label33 = New System.Windows.Forms.Label()
    Me.TxtCRID = New System.Windows.Forms.TextBox()
    Me.TpAssmnt = New System.Windows.Forms.TabPage()
    Me.LblAdjNet = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LnkSaleMonth = New System.Windows.Forms.LinkLabel()
    Me.LnkPurchMonth = New System.Windows.Forms.LinkLabel()
    Me.LblSaleNet = New System.Windows.Forms.Label()
    Me.LblPurchNet = New System.Windows.Forms.Label()
    Me.LblPurchPct = New System.Windows.Forms.Label()
    Me.TxtPurchMonth = New System.Windows.Forms.TextBox()
    Me.LblSalePct = New System.Windows.Forms.Label()
    Me.TxtSaleMonth = New System.Windows.Forms.TextBox()
    Me.LblChgAssmt1 = New System.Windows.Forms.Label()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.TxtAssmt1 = New System.Windows.Forms.TextBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.LblOrigAssmt1 = New System.Windows.Forms.Label()
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.LnkCRSaleMonth = New System.Windows.Forms.LinkLabel()
    Me.LblChgCRAssmt1 = New System.Windows.Forms.Label()
    Me.Label39 = New System.Windows.Forms.Label()
    Me.Label35 = New System.Windows.Forms.Label()
    Me.LblOrigCRAssmt1 = New System.Windows.Forms.Label()
    Me.LblCRSaleNet = New System.Windows.Forms.Label()
    Me.LblCRSalePct = New System.Windows.Forms.Label()
    Me.TxtCRSaleMonth = New System.Windows.Forms.TextBox()
    Me.TxtCRAssmt1 = New System.Windows.Forms.TextBox()
    Me.Label46 = New System.Windows.Forms.Label()
    Me.TpExemptions = New System.Windows.Forms.TabPage()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.LblChgExam5 = New System.Windows.Forms.Label()
    Me.LblChgExam4 = New System.Windows.Forms.Label()
    Me.LblChgExam3 = New System.Windows.Forms.Label()
    Me.LblChgExam2 = New System.Windows.Forms.Label()
    Me.LblChgExam1 = New System.Windows.Forms.Label()
    Me.Label70 = New System.Windows.Forms.Label()
    Me.LblOrigExam5 = New System.Windows.Forms.Label()
    Me.LblOrigExam4 = New System.Windows.Forms.Label()
    Me.LblOrigExam3 = New System.Windows.Forms.Label()
    Me.LblOrigExam2 = New System.Windows.Forms.Label()
    Me.Label58 = New System.Windows.Forms.Label()
    Me.LblOrigExam1 = New System.Windows.Forms.Label()
    Me.LnkExempt5 = New System.Windows.Forms.LinkLabel()
    Me.TxtExempt5 = New System.Windows.Forms.TextBox()
    Me.LnkExempt3 = New System.Windows.Forms.LinkLabel()
    Me.TxtExempt3 = New System.Windows.Forms.TextBox()
    Me.LnkExempt4 = New System.Windows.Forms.LinkLabel()
    Me.TxtExempt4 = New System.Windows.Forms.TextBox()
    Me.LnkExempt2 = New System.Windows.Forms.LinkLabel()
    Me.TxtExempt2 = New System.Windows.Forms.TextBox()
    Me.LnkExempt1 = New System.Windows.Forms.LinkLabel()
    Me.TxtExempt1 = New System.Windows.Forms.TextBox()
    Me.TxtExam4 = New System.Windows.Forms.TextBox()
    Me.TxtExam2 = New System.Windows.Forms.TextBox()
    Me.TxtExam5 = New System.Windows.Forms.TextBox()
    Me.TxtExam3 = New System.Windows.Forms.TextBox()
    Me.TxtExam1 = New System.Windows.Forms.TextBox()
    Me.Label50 = New System.Windows.Forms.Label()
    Me.Label52 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.LblBeforeCC = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.LblChgAmt = New System.Windows.Forms.Label()
    Me.LblNewAmt = New System.Windows.Forms.Label()
    Me.LblOrigAmt = New System.Windows.Forms.Label()
    Me.LblChgAdjGross = New System.Windows.Forms.Label()
    Me.LblNewAdjGross = New System.Windows.Forms.Label()
    Me.LblOrigAdjGross = New System.Windows.Forms.Label()
    Me.Label53 = New System.Windows.Forms.Label()
    Me.LblChgNet = New System.Windows.Forms.Label()
    Me.LblNewNet = New System.Windows.Forms.Label()
    Me.LblOrigNet = New System.Windows.Forms.Label()
    Me.LblChgProrate = New System.Windows.Forms.Label()
    Me.LblNewProrate = New System.Windows.Forms.Label()
    Me.LblOrigProrate = New System.Windows.Forms.Label()
    Me.LblChgExam = New System.Windows.Forms.Label()
    Me.LblNewExam = New System.Windows.Forms.Label()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.LblChgGross = New System.Windows.Forms.Label()
    Me.Label34 = New System.Windows.Forms.Label()
    Me.LblNewGross = New System.Windows.Forms.Label()
    Me.LblOrigGross = New System.Windows.Forms.Label()
    Me.LblOrigExam = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.LblOrig = New System.Windows.Forms.Label()
    Me.Label22 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TabControl1.SuspendLayout()
    Me.TpMain.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.TpAssmnt.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox6.SuspendLayout()
    Me.TpExemptions.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Location = New System.Drawing.Point(328, 128)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 20)
    Me.TxtState.TabIndex = 6
    '
    'TxtAdd1
    '
    Me.TxtAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd1.Location = New System.Drawing.Point(96, 80)
    Me.TxtAdd1.MaxLength = 35
    Me.TxtAdd1.Name = "TxtAdd1"
    Me.TxtAdd1.Size = New System.Drawing.Size(280, 20)
    Me.TxtAdd1.TabIndex = 3
    '
    'Label42
    '
    Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label42.Location = New System.Drawing.Point(392, 32)
    Me.Label42.Name = "Label42"
    Me.Label42.Size = New System.Drawing.Size(48, 16)
    Me.Label42.TabIndex = 190
    Me.Label42.Text = "District"
    '
    'LblType
    '
    Me.LblType.Location = New System.Drawing.Point(368, 8)
    Me.LblType.Name = "LblType"
    Me.LblType.Size = New System.Drawing.Size(24, 16)
    Me.LblType.TabIndex = 201
    '
    'LblYear
    '
    Me.LblYear.Location = New System.Drawing.Point(178, 8)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(32, 16)
    Me.LblYear.TabIndex = 199
    '
    'TxtAdd2
    '
    Me.TxtAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd2.Location = New System.Drawing.Point(96, 104)
    Me.TxtAdd2.MaxLength = 35
    Me.TxtAdd2.Name = "TxtAdd2"
    Me.TxtAdd2.Size = New System.Drawing.Size(280, 20)
    Me.TxtAdd2.TabIndex = 4
    '
    'TxtSname
    '
    Me.TxtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSname.Location = New System.Drawing.Point(96, 56)
    Me.TxtSname.MaxLength = 35
    Me.TxtSname.Name = "TxtSname"
    Me.TxtSname.Size = New System.Drawing.Size(280, 20)
    Me.TxtSname.TabIndex = 2
    '
    'TxtZip5
    '
    Me.TxtZip5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtZip5.Location = New System.Drawing.Point(352, 128)
    Me.TxtZip5.MaxLength = 5
    Me.TxtZip5.Name = "TxtZip5"
    Me.TxtZip5.Size = New System.Drawing.Size(40, 20)
    Me.TxtZip5.TabIndex = 7
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(8, 32)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(48, 16)
    Me.Label5.TabIndex = 191
    Me.Label5.Text = "Name"
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(8, 128)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(80, 16)
    Me.Label4.TabIndex = 195
    Me.Label4.Text = "City/State/Zip"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(218, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 16)
    Me.Label1.TabIndex = 192
    Me.Label1.Text = "List No"
    '
    'LblCCNo
    '
    Me.LblCCNo.Location = New System.Drawing.Point(58, 8)
    Me.LblCCNo.Name = "LblCCNo"
    Me.LblCCNo.Size = New System.Drawing.Size(48, 16)
    Me.LblCCNo.TabIndex = 204
    '
    'LblListNo
    '
    Me.LblListNo.Location = New System.Drawing.Point(266, 8)
    Me.LblListNo.Name = "LblListNo"
    Me.LblListNo.Size = New System.Drawing.Size(72, 16)
    Me.LblListNo.TabIndex = 205
    '
    'LblCCDate
    '
    Me.LblCCDate.Location = New System.Drawing.Point(466, 8)
    Me.LblCCDate.Name = "LblCCDate"
    Me.LblCCDate.Size = New System.Drawing.Size(64, 15)
    Me.LblCCDate.TabIndex = 203
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(8, 80)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(80, 16)
    Me.Label3.TabIndex = 194
    Me.Label3.Text = "Street Address"
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(402, 8)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(56, 15)
    Me.Label13.TabIndex = 202
    Me.Label13.Text = "C/C Date"
    '
    'Label12
    '
    Me.Label12.Location = New System.Drawing.Point(338, 8)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(32, 16)
    Me.Label12.TabIndex = 200
    Me.Label12.Text = "Type"
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(122, 8)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(56, 16)
    Me.Label9.TabIndex = 198
    Me.Label9.Text = "Tax Year"
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Location = New System.Drawing.Point(96, 32)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(280, 20)
    Me.TxtName.TabIndex = 0
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Location = New System.Drawing.Point(96, 128)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(232, 20)
    Me.TxtCity.TabIndex = 5
    '
    'TxtZip4
    '
    Me.TxtZip4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtZip4.Location = New System.Drawing.Point(392, 128)
    Me.TxtZip4.MaxLength = 4
    Me.TxtZip4.Name = "TxtZip4"
    Me.TxtZip4.Size = New System.Drawing.Size(32, 20)
    Me.TxtZip4.TabIndex = 8
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(8, 8)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(48, 16)
    Me.Label8.TabIndex = 197
    Me.Label8.Text = "C/C No"
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(448, 32)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(24, 20)
    Me.TxtDist.TabIndex = 1
    Me.TxtDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TabControl1
    '
    Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons
    Me.TabControl1.Controls.Add(Me.TpMain)
    Me.TabControl1.Controls.Add(Me.TpAssmnt)
    Me.TabControl1.Controls.Add(Me.TpExemptions)
    Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TabControl1.Location = New System.Drawing.Point(8, 152)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(609, 346)
    Me.TabControl1.TabIndex = 9
    Me.TabControl1.TabStop = False
    '
    'TpMain
    '
    Me.TpMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.TpMain.Controls.Add(Me.GroupBox3)
    Me.TpMain.Controls.Add(Me.LnkReason)
    Me.TpMain.Controls.Add(Me.LblMRate)
    Me.TpMain.Controls.Add(Me.Label26)
    Me.TpMain.Controls.Add(Me.LblBankCd)
    Me.TpMain.Controls.Add(Me.TxtOverAmt)
    Me.TpMain.Controls.Add(Me.Label15)
    Me.TpMain.Controls.Add(Me.ChkOver)
    Me.TpMain.Controls.Add(Me.Label14)
    Me.TpMain.Controls.Add(Me.TxtDesc)
    Me.TpMain.Controls.Add(Me.TxtReason)
    Me.TpMain.Controls.Add(Me.GroupBox5)
    Me.TpMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TpMain.Location = New System.Drawing.Point(4, 25)
    Me.TpMain.Name = "TpMain"
    Me.TpMain.Size = New System.Drawing.Size(601, 317)
    Me.TpMain.TabIndex = 0
    Me.TpMain.Text = "Main"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.LblPDMsg)
    Me.GroupBox3.Controls.Add(Me.BtnPriceDigest)
    Me.GroupBox3.Controls.Add(Me.LblMSRPCalc)
    Me.GroupBox3.Controls.Add(Me.ChkComplete)
    Me.GroupBox3.Controls.Add(Me.TxtSource)
    Me.GroupBox3.Controls.Add(Me.LnkSource)
    Me.GroupBox3.Controls.Add(Me.Label38)
    Me.GroupBox3.Controls.Add(Me.TxtOVMSRP)
    Me.GroupBox3.Controls.Add(Me.LblMSRP)
    Me.GroupBox3.Controls.Add(Me.Label40)
    Me.GroupBox3.Controls.Add(Me.LblValue)
    Me.GroupBox3.Controls.Add(Me.Label41)
    Me.GroupBox3.Controls.Add(Me.Label36)
    Me.GroupBox3.Controls.Add(Me.Label10)
    Me.GroupBox3.Controls.Add(Me.TxtSS2)
    Me.GroupBox3.Controls.Add(Me.Label11)
    Me.GroupBox3.Controls.Add(Me.TxtSSNo)
    Me.GroupBox3.Controls.Add(Me.Label31)
    Me.GroupBox3.Controls.Add(Me.TxtOid)
    Me.GroupBox3.Controls.Add(Me.LnkClass)
    Me.GroupBox3.Controls.Add(Me.TxtModel)
    Me.GroupBox3.Controls.Add(Me.Label27)
    Me.GroupBox3.Controls.Add(Me.TxtMake)
    Me.GroupBox3.Controls.Add(Me.Label25)
    Me.GroupBox3.Controls.Add(Me.TxtMVYear)
    Me.GroupBox3.Controls.Add(Me.TxtClass)
    Me.GroupBox3.Controls.Add(Me.Label7)
    Me.GroupBox3.Controls.Add(Me.TxtReg)
    Me.GroupBox3.Controls.Add(Me.Label6)
    Me.GroupBox3.Controls.Add(Me.TxtID)
    Me.GroupBox3.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox3.Location = New System.Drawing.Point(8, 0)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(558, 129)
    Me.GroupBox3.TabIndex = 173
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Current Vehicle"
    '
    'LblPDMsg
    '
    Me.LblPDMsg.AutoSize = True
    Me.LblPDMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPDMsg.ForeColor = System.Drawing.Color.Black
    Me.LblPDMsg.Location = New System.Drawing.Point(474, 39)
    Me.LblPDMsg.Name = "LblPDMsg"
    Me.LblPDMsg.Size = New System.Drawing.Size(57, 13)
    Me.LblPDMsg.TabIndex = 330
    Me.LblPDMsg.Text = "<PD Msg>"
    '
    'BtnPriceDigest
    '
    Me.BtnPriceDigest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnPriceDigest.ForeColor = System.Drawing.Color.Black
    Me.BtnPriceDigest.Location = New System.Drawing.Point(475, 12)
    Me.BtnPriceDigest.Name = "BtnPriceDigest"
    Me.BtnPriceDigest.Size = New System.Drawing.Size(74, 24)
    Me.BtnPriceDigest.TabIndex = 329
    Me.BtnPriceDigest.Text = "Price Digest"
    '
    'LblMSRPCalc
    '
    Me.LblMSRPCalc.AutoSize = True
    Me.LblMSRPCalc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMSRPCalc.ForeColor = System.Drawing.Color.Black
    Me.LblMSRPCalc.Location = New System.Drawing.Point(235, 103)
    Me.LblMSRPCalc.Name = "LblMSRPCalc"
    Me.LblMSRPCalc.Size = New System.Drawing.Size(74, 13)
    Me.LblMSRPCalc.TabIndex = 328
    Me.LblMSRPCalc.Text = "<MSRP Calc>"
    '
    'ChkComplete
    '
    Me.ChkComplete.AutoSize = True
    Me.ChkComplete.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkComplete.ForeColor = System.Drawing.Color.Black
    Me.ChkComplete.Location = New System.Drawing.Point(141, 108)
    Me.ChkComplete.Name = "ChkComplete"
    Me.ChkComplete.Size = New System.Drawing.Size(76, 17)
    Me.ChkComplete.TabIndex = 327
    Me.ChkComplete.Text = "Complete?"
    '
    'TxtSource
    '
    Me.TxtSource.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSource.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSource.Location = New System.Drawing.Point(105, 103)
    Me.TxtSource.MaxLength = 2
    Me.TxtSource.Name = "TxtSource"
    Me.TxtSource.Size = New System.Drawing.Size(19, 22)
    Me.TxtSource.TabIndex = 325
    '
    'LnkSource
    '
    Me.LnkSource.AutoSize = True
    Me.LnkSource.Location = New System.Drawing.Point(92, 87)
    Me.LnkSource.Name = "LnkSource"
    Me.LnkSource.Size = New System.Drawing.Size(41, 13)
    Me.LnkSource.TabIndex = 326
    Me.LnkSource.TabStop = True
    Me.LnkSource.Text = "Source"
    '
    'Label38
    '
    Me.Label38.AutoSize = True
    Me.Label38.ForeColor = System.Drawing.Color.Black
    Me.Label38.Location = New System.Drawing.Point(8, 87)
    Me.Label38.Name = "Label38"
    Me.Label38.Size = New System.Drawing.Size(67, 13)
    Me.Label38.TabIndex = 324
    Me.Label38.Text = "100% MSRP"
    '
    'TxtOVMSRP
    '
    Me.TxtOVMSRP.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOVMSRP.Location = New System.Drawing.Point(3, 103)
    Me.TxtOVMSRP.MaxLength = 9
    Me.TxtOVMSRP.Name = "TxtOVMSRP"
    Me.TxtOVMSRP.Size = New System.Drawing.Size(82, 22)
    Me.TxtOVMSRP.TabIndex = 323
    Me.TxtOVMSRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblMSRP
    '
    Me.LblMSRP.BackColor = System.Drawing.Color.Aqua
    Me.LblMSRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblMSRP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMSRP.ForeColor = System.Drawing.Color.Black
    Me.LblMSRP.Location = New System.Drawing.Point(412, 101)
    Me.LblMSRP.Name = "LblMSRP"
    Me.LblMSRP.Size = New System.Drawing.Size(64, 16)
    Me.LblMSRP.TabIndex = 322
    Me.LblMSRP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label40
    '
    Me.Label40.AutoSize = True
    Me.Label40.ForeColor = System.Drawing.Color.Black
    Me.Label40.Location = New System.Drawing.Point(411, 87)
    Me.Label40.Name = "Label40"
    Me.Label40.Size = New System.Drawing.Size(65, 13)
    Me.Label40.TabIndex = 321
    Me.Label40.Text = "DMV MSRP"
    '
    'LblValue
    '
    Me.LblValue.BackColor = System.Drawing.Color.Aqua
    Me.LblValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblValue.ForeColor = System.Drawing.Color.Black
    Me.LblValue.Location = New System.Drawing.Point(485, 100)
    Me.LblValue.Name = "LblValue"
    Me.LblValue.Size = New System.Drawing.Size(64, 16)
    Me.LblValue.TabIndex = 320
    Me.LblValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label41
    '
    Me.Label41.AutoSize = True
    Me.Label41.ForeColor = System.Drawing.Color.Black
    Me.Label41.Location = New System.Drawing.Point(497, 87)
    Me.Label41.Name = "Label41"
    Me.Label41.Size = New System.Drawing.Size(34, 13)
    Me.Label41.TabIndex = 319
    Me.Label41.Text = "Value"
    '
    'Label36
    '
    Me.Label36.ForeColor = System.Drawing.Color.Black
    Me.Label36.Location = New System.Drawing.Point(245, 39)
    Me.Label36.Name = "Label36"
    Me.Label36.Size = New System.Drawing.Size(37, 20)
    Me.Label36.TabIndex = 252
    Me.Label36.Text = "Model"
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.ForeColor = System.Drawing.Color.Black
    Me.Label10.Location = New System.Drawing.Point(186, 64)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(79, 13)
    Me.Label10.TabIndex = 251
    Me.Label10.Text = "SecondCust ID"
    '
    'TxtSS2
    '
    Me.TxtSS2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSS2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
    Me.TxtSS2.Location = New System.Drawing.Point(267, 60)
    Me.TxtSS2.MaxLength = 9
    Me.TxtSS2.Name = "TxtSS2"
    Me.TxtSS2.Size = New System.Drawing.Size(80, 20)
    Me.TxtSS2.TabIndex = 7
    Me.TxtSS2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.ForeColor = System.Drawing.Color.Black
    Me.Label11.Location = New System.Drawing.Point(9, 64)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(76, 13)
    Me.Label11.TabIndex = 250
    Me.Label11.Text = "PrimaryCust ID"
    '
    'TxtSSNo
    '
    Me.TxtSSNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSSNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
    Me.TxtSSNo.Location = New System.Drawing.Point(91, 60)
    Me.TxtSSNo.MaxLength = 9
    Me.TxtSSNo.Name = "TxtSSNo"
    Me.TxtSSNo.Size = New System.Drawing.Size(80, 20)
    Me.TxtSSNo.TabIndex = 6
    Me.TxtSSNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label31
    '
    Me.Label31.AutoSize = True
    Me.Label31.ForeColor = System.Drawing.Color.Black
    Me.Label31.Location = New System.Drawing.Point(359, 64)
    Me.Label31.Name = "Label31"
    Me.Label31.Size = New System.Drawing.Size(56, 13)
    Me.Label31.TabIndex = 249
    Me.Label31.Text = "Vehicle ID"
    '
    'TxtOid
    '
    Me.TxtOid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
    Me.TxtOid.Location = New System.Drawing.Point(421, 60)
    Me.TxtOid.MaxLength = 15
    Me.TxtOid.Name = "TxtOid"
    Me.TxtOid.Size = New System.Drawing.Size(75, 20)
    Me.TxtOid.TabIndex = 8
    '
    'LnkClass
    '
    Me.LnkClass.Location = New System.Drawing.Point(354, 20)
    Me.LnkClass.Name = "LnkClass"
    Me.LnkClass.Size = New System.Drawing.Size(35, 16)
    Me.LnkClass.TabIndex = 173
    Me.LnkClass.TabStop = True
    Me.LnkClass.Text = "Class"
    '
    'TxtModel
    '
    Me.TxtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtModel.Location = New System.Drawing.Point(288, 38)
    Me.TxtModel.MaxLength = 8
    Me.TxtModel.Name = "TxtModel"
    Me.TxtModel.Size = New System.Drawing.Size(72, 20)
    Me.TxtModel.TabIndex = 5
    '
    'Label27
    '
    Me.Label27.ForeColor = System.Drawing.Color.Black
    Me.Label27.Location = New System.Drawing.Point(144, 39)
    Me.Label27.Name = "Label27"
    Me.Label27.Size = New System.Drawing.Size(37, 20)
    Me.Label27.TabIndex = 166
    Me.Label27.Text = "Make"
    '
    'TxtMake
    '
    Me.TxtMake.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMake.Location = New System.Drawing.Point(181, 39)
    Me.TxtMake.MaxLength = 5
    Me.TxtMake.Name = "TxtMake"
    Me.TxtMake.Size = New System.Drawing.Size(48, 20)
    Me.TxtMake.TabIndex = 4
    '
    'Label25
    '
    Me.Label25.ForeColor = System.Drawing.Color.Black
    Me.Label25.Location = New System.Drawing.Point(8, 39)
    Me.Label25.Name = "Label25"
    Me.Label25.Size = New System.Drawing.Size(88, 16)
    Me.Label25.TabIndex = 164
    Me.Label25.Text = "Year"
    '
    'TxtMVYear
    '
    Me.TxtMVYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMVYear.Location = New System.Drawing.Point(96, 39)
    Me.TxtMVYear.MaxLength = 4
    Me.TxtMVYear.Name = "TxtMVYear"
    Me.TxtMVYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtMVYear.TabIndex = 3
    '
    'TxtClass
    '
    Me.TxtClass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtClass.Location = New System.Drawing.Point(400, 16)
    Me.TxtClass.MaxLength = 2
    Me.TxtClass.Name = "TxtClass"
    Me.TxtClass.Size = New System.Drawing.Size(24, 20)
    Me.TxtClass.TabIndex = 2
    '
    'Label7
    '
    Me.Label7.ForeColor = System.Drawing.Color.Black
    Me.Label7.Location = New System.Drawing.Point(256, 16)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(32, 16)
    Me.Label7.TabIndex = 160
    Me.Label7.Text = "Reg"
    '
    'TxtReg
    '
    Me.TxtReg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtReg.Location = New System.Drawing.Point(288, 16)
    Me.TxtReg.MaxLength = 8
    Me.TxtReg.Name = "TxtReg"
    Me.TxtReg.Size = New System.Drawing.Size(58, 20)
    Me.TxtReg.TabIndex = 1
    '
    'Label6
    '
    Me.Label6.ForeColor = System.Drawing.Color.Black
    Me.Label6.Location = New System.Drawing.Point(8, 16)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(88, 16)
    Me.Label6.TabIndex = 158
    Me.Label6.Text = "VIN "
    '
    'TxtID
    '
    Me.TxtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtID.Location = New System.Drawing.Point(96, 16)
    Me.TxtID.MaxLength = 17
    Me.TxtID.Name = "TxtID"
    Me.TxtID.Size = New System.Drawing.Size(144, 20)
    Me.TxtID.TabIndex = 0
    '
    'LnkReason
    '
    Me.LnkReason.Location = New System.Drawing.Point(4, 245)
    Me.LnkReason.Name = "LnkReason"
    Me.LnkReason.Size = New System.Drawing.Size(88, 16)
    Me.LnkReason.TabIndex = 22
    Me.LnkReason.TabStop = True
    Me.LnkReason.Text = "Change Reason"
    '
    'LblMRate
    '
    Me.LblMRate.Location = New System.Drawing.Point(449, 290)
    Me.LblMRate.Name = "LblMRate"
    Me.LblMRate.Size = New System.Drawing.Size(64, 16)
    Me.LblMRate.TabIndex = 3
    Me.LblMRate.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label26
    '
    Me.Label26.AutoSize = True
    Me.Label26.Location = New System.Drawing.Point(395, 293)
    Me.Label26.Name = "Label26"
    Me.Label26.Size = New System.Drawing.Size(48, 13)
    Me.Label26.TabIndex = 162
    Me.Label26.Text = "Mill Rate"
    '
    'LblBankCd
    '
    Me.LblBankCd.Location = New System.Drawing.Point(408, 32)
    Me.LblBankCd.Name = "LblBankCd"
    Me.LblBankCd.Size = New System.Drawing.Size(24, 16)
    Me.LblBankCd.TabIndex = 161
    '
    'TxtOverAmt
    '
    Me.TxtOverAmt.Location = New System.Drawing.Point(228, 293)
    Me.TxtOverAmt.MaxLength = 11
    Me.TxtOverAmt.Name = "TxtOverAmt"
    Me.TxtOverAmt.Size = New System.Drawing.Size(64, 20)
    Me.TxtOverAmt.TabIndex = 2
    Me.TxtOverAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label15
    '
    Me.Label15.Location = New System.Drawing.Point(124, 293)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(96, 16)
    Me.Label15.TabIndex = 159
    Me.Label15.Text = "Override Amount"
    '
    'ChkOver
    '
    Me.ChkOver.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkOver.Location = New System.Drawing.Point(4, 293)
    Me.ChkOver.Name = "ChkOver"
    Me.ChkOver.Size = New System.Drawing.Size(104, 16)
    Me.ChkOver.TabIndex = 25
    Me.ChkOver.Text = "Override Tax?"
    '
    'Label14
    '
    Me.Label14.Location = New System.Drawing.Point(4, 269)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(88, 16)
    Me.Label14.TabIndex = 156
    Me.Label14.Text = "Description"
    '
    'TxtDesc
    '
    Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDesc.Location = New System.Drawing.Point(92, 269)
    Me.TxtDesc.MaxLength = 50
    Me.TxtDesc.Name = "TxtDesc"
    Me.TxtDesc.Size = New System.Drawing.Size(310, 20)
    Me.TxtDesc.TabIndex = 1
    '
    'TxtReason
    '
    Me.TxtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtReason.Location = New System.Drawing.Point(92, 245)
    Me.TxtReason.MaxLength = 1
    Me.TxtReason.Name = "TxtReason"
    Me.TxtReason.Size = New System.Drawing.Size(18, 20)
    Me.TxtReason.TabIndex = 0
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.LblCRPDMsg)
    Me.GroupBox5.Controls.Add(Me.BtnCRPriceDigest)
    Me.GroupBox5.Controls.Add(Me.LblCRMSRP)
    Me.GroupBox5.Controls.Add(Me.Label43)
    Me.GroupBox5.Controls.Add(Me.LblCRValue)
    Me.GroupBox5.Controls.Add(Me.Label44)
    Me.GroupBox5.Controls.Add(Me.LblCRMSRPCalc)
    Me.GroupBox5.Controls.Add(Me.ChkCRComplete)
    Me.GroupBox5.Controls.Add(Me.TxtCRSource)
    Me.GroupBox5.Controls.Add(Me.LnkCRSource)
    Me.GroupBox5.Controls.Add(Me.Label45)
    Me.GroupBox5.Controls.Add(Me.TxtCROVMSRP)
    Me.GroupBox5.Controls.Add(Me.Label37)
    Me.GroupBox5.Controls.Add(Me.LnkCRClass)
    Me.GroupBox5.Controls.Add(Me.TxtCRModel)
    Me.GroupBox5.Controls.Add(Me.Label28)
    Me.GroupBox5.Controls.Add(Me.TxtCRMake)
    Me.GroupBox5.Controls.Add(Me.Label29)
    Me.GroupBox5.Controls.Add(Me.TXTCRMVYear)
    Me.GroupBox5.Controls.Add(Me.TxtCRClass)
    Me.GroupBox5.Controls.Add(Me.Label32)
    Me.GroupBox5.Controls.Add(Me.TXTCRReg)
    Me.GroupBox5.Controls.Add(Me.Label33)
    Me.GroupBox5.Controls.Add(Me.TxtCRID)
    Me.GroupBox5.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox5.Location = New System.Drawing.Point(8, 131)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(561, 108)
    Me.GroupBox5.TabIndex = 174
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "Credit Vehicle"
    '
    'LblCRPDMsg
    '
    Me.LblCRPDMsg.AutoSize = True
    Me.LblCRPDMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCRPDMsg.ForeColor = System.Drawing.Color.Black
    Me.LblCRPDMsg.Location = New System.Drawing.Point(480, 37)
    Me.LblCRPDMsg.Name = "LblCRPDMsg"
    Me.LblCRPDMsg.Size = New System.Drawing.Size(57, 13)
    Me.LblCRPDMsg.TabIndex = 306
    Me.LblCRPDMsg.Text = "<PD Msg>"
    '
    'BtnCRPriceDigest
    '
    Me.BtnCRPriceDigest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnCRPriceDigest.ForeColor = System.Drawing.Color.Black
    Me.BtnCRPriceDigest.Location = New System.Drawing.Point(481, 10)
    Me.BtnCRPriceDigest.Name = "BtnCRPriceDigest"
    Me.BtnCRPriceDigest.Size = New System.Drawing.Size(74, 24)
    Me.BtnCRPriceDigest.TabIndex = 305
    Me.BtnCRPriceDigest.Text = "Price Digest"
    '
    'LblCRMSRP
    '
    Me.LblCRMSRP.BackColor = System.Drawing.Color.Aqua
    Me.LblCRMSRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCRMSRP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCRMSRP.ForeColor = System.Drawing.Color.Black
    Me.LblCRMSRP.Location = New System.Drawing.Point(419, 79)
    Me.LblCRMSRP.Name = "LblCRMSRP"
    Me.LblCRMSRP.Size = New System.Drawing.Size(64, 16)
    Me.LblCRMSRP.TabIndex = 304
    Me.LblCRMSRP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label43
    '
    Me.Label43.AutoSize = True
    Me.Label43.ForeColor = System.Drawing.Color.Black
    Me.Label43.Location = New System.Drawing.Point(418, 65)
    Me.Label43.Name = "Label43"
    Me.Label43.Size = New System.Drawing.Size(65, 13)
    Me.Label43.TabIndex = 303
    Me.Label43.Text = "DMV MSRP"
    '
    'LblCRValue
    '
    Me.LblCRValue.BackColor = System.Drawing.Color.Aqua
    Me.LblCRValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCRValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCRValue.ForeColor = System.Drawing.Color.Black
    Me.LblCRValue.Location = New System.Drawing.Point(492, 78)
    Me.LblCRValue.Name = "LblCRValue"
    Me.LblCRValue.Size = New System.Drawing.Size(64, 16)
    Me.LblCRValue.TabIndex = 302
    Me.LblCRValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label44
    '
    Me.Label44.AutoSize = True
    Me.Label44.ForeColor = System.Drawing.Color.Black
    Me.Label44.Location = New System.Drawing.Point(504, 65)
    Me.Label44.Name = "Label44"
    Me.Label44.Size = New System.Drawing.Size(34, 13)
    Me.Label44.TabIndex = 301
    Me.Label44.Text = "Value"
    '
    'LblCRMSRPCalc
    '
    Me.LblCRMSRPCalc.AutoSize = True
    Me.LblCRMSRPCalc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCRMSRPCalc.ForeColor = System.Drawing.Color.Black
    Me.LblCRMSRPCalc.Location = New System.Drawing.Point(233, 81)
    Me.LblCRMSRPCalc.Name = "LblCRMSRPCalc"
    Me.LblCRMSRPCalc.Size = New System.Drawing.Size(74, 13)
    Me.LblCRMSRPCalc.TabIndex = 300
    Me.LblCRMSRPCalc.Text = "<MSRP Calc>"
    '
    'ChkCRComplete
    '
    Me.ChkCRComplete.AutoSize = True
    Me.ChkCRComplete.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkCRComplete.ForeColor = System.Drawing.Color.Black
    Me.ChkCRComplete.Location = New System.Drawing.Point(139, 86)
    Me.ChkCRComplete.Name = "ChkCRComplete"
    Me.ChkCRComplete.Size = New System.Drawing.Size(76, 17)
    Me.ChkCRComplete.TabIndex = 299
    Me.ChkCRComplete.Text = "Complete?"
    '
    'TxtCRSource
    '
    Me.TxtCRSource.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCRSource.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCRSource.Location = New System.Drawing.Point(103, 81)
    Me.TxtCRSource.MaxLength = 2
    Me.TxtCRSource.Name = "TxtCRSource"
    Me.TxtCRSource.Size = New System.Drawing.Size(19, 22)
    Me.TxtCRSource.TabIndex = 297
    '
    'LnkCRSource
    '
    Me.LnkCRSource.AutoSize = True
    Me.LnkCRSource.Location = New System.Drawing.Point(90, 65)
    Me.LnkCRSource.Name = "LnkCRSource"
    Me.LnkCRSource.Size = New System.Drawing.Size(41, 13)
    Me.LnkCRSource.TabIndex = 298
    Me.LnkCRSource.TabStop = True
    Me.LnkCRSource.Text = "Source"
    '
    'Label45
    '
    Me.Label45.AutoSize = True
    Me.Label45.ForeColor = System.Drawing.Color.Black
    Me.Label45.Location = New System.Drawing.Point(6, 65)
    Me.Label45.Name = "Label45"
    Me.Label45.Size = New System.Drawing.Size(67, 13)
    Me.Label45.TabIndex = 296
    Me.Label45.Text = "100% MSRP"
    '
    'TxtCROVMSRP
    '
    Me.TxtCROVMSRP.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCROVMSRP.Location = New System.Drawing.Point(1, 81)
    Me.TxtCROVMSRP.MaxLength = 9
    Me.TxtCROVMSRP.Name = "TxtCROVMSRP"
    Me.TxtCROVMSRP.Size = New System.Drawing.Size(82, 22)
    Me.TxtCROVMSRP.TabIndex = 295
    Me.TxtCROVMSRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label37
    '
    Me.Label37.ForeColor = System.Drawing.Color.Black
    Me.Label37.Location = New System.Drawing.Point(245, 38)
    Me.Label37.Name = "Label37"
    Me.Label37.Size = New System.Drawing.Size(37, 20)
    Me.Label37.TabIndex = 253
    Me.Label37.Text = "Model"
    '
    'LnkCRClass
    '
    Me.LnkCRClass.Location = New System.Drawing.Point(354, 20)
    Me.LnkCRClass.Name = "LnkCRClass"
    Me.LnkCRClass.Size = New System.Drawing.Size(35, 16)
    Me.LnkCRClass.TabIndex = 174
    Me.LnkCRClass.TabStop = True
    Me.LnkCRClass.Text = "Class"
    '
    'TxtCRModel
    '
    Me.TxtCRModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCRModel.Location = New System.Drawing.Point(288, 38)
    Me.TxtCRModel.MaxLength = 8
    Me.TxtCRModel.Name = "TxtCRModel"
    Me.TxtCRModel.Size = New System.Drawing.Size(72, 20)
    Me.TxtCRModel.TabIndex = 5
    '
    'Label28
    '
    Me.Label28.ForeColor = System.Drawing.Color.Black
    Me.Label28.Location = New System.Drawing.Point(144, 40)
    Me.Label28.Name = "Label28"
    Me.Label28.Size = New System.Drawing.Size(37, 16)
    Me.Label28.TabIndex = 166
    Me.Label28.Text = "Make"
    '
    'TxtCRMake
    '
    Me.TxtCRMake.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCRMake.Location = New System.Drawing.Point(181, 38)
    Me.TxtCRMake.MaxLength = 5
    Me.TxtCRMake.Name = "TxtCRMake"
    Me.TxtCRMake.Size = New System.Drawing.Size(48, 20)
    Me.TxtCRMake.TabIndex = 4
    '
    'Label29
    '
    Me.Label29.ForeColor = System.Drawing.Color.Black
    Me.Label29.Location = New System.Drawing.Point(8, 40)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(88, 16)
    Me.Label29.TabIndex = 164
    Me.Label29.Text = "Year"
    '
    'TXTCRMVYear
    '
    Me.TXTCRMVYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TXTCRMVYear.Location = New System.Drawing.Point(96, 40)
    Me.TXTCRMVYear.MaxLength = 4
    Me.TXTCRMVYear.Name = "TXTCRMVYear"
    Me.TXTCRMVYear.Size = New System.Drawing.Size(32, 20)
    Me.TXTCRMVYear.TabIndex = 3
    '
    'TxtCRClass
    '
    Me.TxtCRClass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCRClass.Location = New System.Drawing.Point(400, 16)
    Me.TxtCRClass.MaxLength = 2
    Me.TxtCRClass.Name = "TxtCRClass"
    Me.TxtCRClass.Size = New System.Drawing.Size(24, 20)
    Me.TxtCRClass.TabIndex = 2
    '
    'Label32
    '
    Me.Label32.ForeColor = System.Drawing.Color.Black
    Me.Label32.Location = New System.Drawing.Point(256, 16)
    Me.Label32.Name = "Label32"
    Me.Label32.Size = New System.Drawing.Size(32, 16)
    Me.Label32.TabIndex = 160
    Me.Label32.Text = "Reg"
    '
    'TXTCRReg
    '
    Me.TXTCRReg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TXTCRReg.Location = New System.Drawing.Point(288, 16)
    Me.TXTCRReg.MaxLength = 8
    Me.TXTCRReg.Name = "TXTCRReg"
    Me.TXTCRReg.Size = New System.Drawing.Size(60, 20)
    Me.TXTCRReg.TabIndex = 1
    '
    'Label33
    '
    Me.Label33.ForeColor = System.Drawing.Color.Black
    Me.Label33.Location = New System.Drawing.Point(8, 16)
    Me.Label33.Name = "Label33"
    Me.Label33.Size = New System.Drawing.Size(88, 16)
    Me.Label33.TabIndex = 158
    Me.Label33.Text = "VIN "
    '
    'TxtCRID
    '
    Me.TxtCRID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCRID.Location = New System.Drawing.Point(96, 16)
    Me.TxtCRID.MaxLength = 25
    Me.TxtCRID.Name = "TxtCRID"
    Me.TxtCRID.Size = New System.Drawing.Size(144, 20)
    Me.TxtCRID.TabIndex = 0
    '
    'TpAssmnt
    '
    Me.TpAssmnt.Controls.Add(Me.LblAdjNet)
    Me.TpAssmnt.Controls.Add(Me.Label16)
    Me.TpAssmnt.Controls.Add(Me.GroupBox1)
    Me.TpAssmnt.Controls.Add(Me.GroupBox6)
    Me.TpAssmnt.Location = New System.Drawing.Point(4, 25)
    Me.TpAssmnt.Name = "TpAssmnt"
    Me.TpAssmnt.Size = New System.Drawing.Size(601, 317)
    Me.TpAssmnt.TabIndex = 2
    Me.TpAssmnt.Text = "Assessments"
    Me.TpAssmnt.Visible = False
    '
    'LblAdjNet
    '
    Me.LblAdjNet.BackColor = System.Drawing.Color.LightCyan
    Me.LblAdjNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAdjNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAdjNet.ForeColor = System.Drawing.Color.Black
    Me.LblAdjNet.Location = New System.Drawing.Point(104, 136)
    Me.LblAdjNet.Name = "LblAdjNet"
    Me.LblAdjNet.Size = New System.Drawing.Size(72, 20)
    Me.LblAdjNet.TabIndex = 199
    Me.LblAdjNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label16
    '
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.ForeColor = System.Drawing.Color.Black
    Me.Label16.Location = New System.Drawing.Point(26, 140)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(72, 16)
    Me.Label16.TabIndex = 198
    Me.Label16.Text = "Adjusted Net"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LnkSaleMonth)
    Me.GroupBox1.Controls.Add(Me.LnkPurchMonth)
    Me.GroupBox1.Controls.Add(Me.LblSaleNet)
    Me.GroupBox1.Controls.Add(Me.LblPurchNet)
    Me.GroupBox1.Controls.Add(Me.LblPurchPct)
    Me.GroupBox1.Controls.Add(Me.TxtPurchMonth)
    Me.GroupBox1.Controls.Add(Me.LblSalePct)
    Me.GroupBox1.Controls.Add(Me.TxtSaleMonth)
    Me.GroupBox1.Controls.Add(Me.LblChgAssmt1)
    Me.GroupBox1.Controls.Add(Me.Label23)
    Me.GroupBox1.Controls.Add(Me.Label18)
    Me.GroupBox1.Controls.Add(Me.TxtAssmt1)
    Me.GroupBox1.Controls.Add(Me.Label17)
    Me.GroupBox1.Controls.Add(Me.LblOrigAssmt1)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(256, 112)
    Me.GroupBox1.TabIndex = 126
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Current Vehicle"
    '
    'LnkSaleMonth
    '
    Me.LnkSaleMonth.Location = New System.Drawing.Point(8, 90)
    Me.LnkSaleMonth.Name = "LnkSaleMonth"
    Me.LnkSaleMonth.Size = New System.Drawing.Size(88, 16)
    Me.LnkSaleMonth.TabIndex = 198
    Me.LnkSaleMonth.TabStop = True
    Me.LnkSaleMonth.Text = "Sale Month"
    '
    'LnkPurchMonth
    '
    Me.LnkPurchMonth.Location = New System.Drawing.Point(8, 67)
    Me.LnkPurchMonth.Name = "LnkPurchMonth"
    Me.LnkPurchMonth.Size = New System.Drawing.Size(88, 16)
    Me.LnkPurchMonth.TabIndex = 197
    Me.LnkPurchMonth.TabStop = True
    Me.LnkPurchMonth.Text = "Purchase Month"
    '
    'LblSaleNet
    '
    Me.LblSaleNet.BackColor = System.Drawing.Color.LightCyan
    Me.LblSaleNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblSaleNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblSaleNet.ForeColor = System.Drawing.Color.Black
    Me.LblSaleNet.Location = New System.Drawing.Point(128, 88)
    Me.LblSaleNet.Name = "LblSaleNet"
    Me.LblSaleNet.Size = New System.Drawing.Size(72, 20)
    Me.LblSaleNet.TabIndex = 196
    Me.LblSaleNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblPurchNet
    '
    Me.LblPurchNet.BackColor = System.Drawing.Color.LightCyan
    Me.LblPurchNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPurchNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPurchNet.ForeColor = System.Drawing.Color.Black
    Me.LblPurchNet.Location = New System.Drawing.Point(128, 64)
    Me.LblPurchNet.Name = "LblPurchNet"
    Me.LblPurchNet.Size = New System.Drawing.Size(72, 20)
    Me.LblPurchNet.TabIndex = 195
    Me.LblPurchNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblPurchPct
    '
    Me.LblPurchPct.ForeColor = System.Drawing.Color.Black
    Me.LblPurchPct.Location = New System.Drawing.Point(208, 68)
    Me.LblPurchPct.Name = "LblPurchPct"
    Me.LblPurchPct.Size = New System.Drawing.Size(40, 16)
    Me.LblPurchPct.TabIndex = 192
    '
    'TxtPurchMonth
    '
    Me.TxtPurchMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPurchMonth.Location = New System.Drawing.Point(96, 64)
    Me.TxtPurchMonth.MaxLength = 2
    Me.TxtPurchMonth.Name = "TxtPurchMonth"
    Me.TxtPurchMonth.Size = New System.Drawing.Size(24, 20)
    Me.TxtPurchMonth.TabIndex = 4
    Me.TxtPurchMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblSalePct
    '
    Me.LblSalePct.ForeColor = System.Drawing.Color.Black
    Me.LblSalePct.Location = New System.Drawing.Point(208, 92)
    Me.LblSalePct.Name = "LblSalePct"
    Me.LblSalePct.Size = New System.Drawing.Size(40, 16)
    Me.LblSalePct.TabIndex = 186
    '
    'TxtSaleMonth
    '
    Me.TxtSaleMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSaleMonth.Location = New System.Drawing.Point(96, 88)
    Me.TxtSaleMonth.MaxLength = 2
    Me.TxtSaleMonth.Name = "TxtSaleMonth"
    Me.TxtSaleMonth.Size = New System.Drawing.Size(24, 20)
    Me.TxtSaleMonth.TabIndex = 5
    Me.TxtSaleMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblChgAssmt1
    '
    Me.LblChgAssmt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgAssmt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgAssmt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgAssmt1.ForeColor = System.Drawing.Color.Black
    Me.LblChgAssmt1.Location = New System.Drawing.Point(168, 32)
    Me.LblChgAssmt1.Name = "LblChgAssmt1"
    Me.LblChgAssmt1.Size = New System.Drawing.Size(72, 20)
    Me.LblChgAssmt1.TabIndex = 183
    Me.LblChgAssmt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label23
    '
    Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label23.ForeColor = System.Drawing.Color.Black
    Me.Label23.Location = New System.Drawing.Point(168, 16)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(72, 16)
    Me.Label23.TabIndex = 37
    Me.Label23.Text = "Change"
    Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label18
    '
    Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label18.ForeColor = System.Drawing.Color.Black
    Me.Label18.Location = New System.Drawing.Point(8, 16)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(72, 16)
    Me.Label18.TabIndex = 36
    Me.Label18.Text = "Original"
    Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'TxtAssmt1
    '
    Me.TxtAssmt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt1.Location = New System.Drawing.Point(88, 32)
    Me.TxtAssmt1.MaxLength = 9
    Me.TxtAssmt1.Name = "TxtAssmt1"
    Me.TxtAssmt1.Size = New System.Drawing.Size(72, 20)
    Me.TxtAssmt1.TabIndex = 3
    Me.TxtAssmt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label17
    '
    Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label17.ForeColor = System.Drawing.Color.Black
    Me.Label17.Location = New System.Drawing.Point(88, 16)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(72, 16)
    Me.Label17.TabIndex = 33
    Me.Label17.Text = "New"
    Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'LblOrigAssmt1
    '
    Me.LblOrigAssmt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigAssmt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigAssmt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigAssmt1.ForeColor = System.Drawing.Color.Black
    Me.LblOrigAssmt1.Location = New System.Drawing.Point(8, 32)
    Me.LblOrigAssmt1.Name = "LblOrigAssmt1"
    Me.LblOrigAssmt1.Size = New System.Drawing.Size(72, 20)
    Me.LblOrigAssmt1.TabIndex = 22
    Me.LblOrigAssmt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'GroupBox6
    '
    Me.GroupBox6.Controls.Add(Me.LnkCRSaleMonth)
    Me.GroupBox6.Controls.Add(Me.LblChgCRAssmt1)
    Me.GroupBox6.Controls.Add(Me.Label39)
    Me.GroupBox6.Controls.Add(Me.Label35)
    Me.GroupBox6.Controls.Add(Me.LblOrigCRAssmt1)
    Me.GroupBox6.Controls.Add(Me.LblCRSaleNet)
    Me.GroupBox6.Controls.Add(Me.LblCRSalePct)
    Me.GroupBox6.Controls.Add(Me.TxtCRSaleMonth)
    Me.GroupBox6.Controls.Add(Me.TxtCRAssmt1)
    Me.GroupBox6.Controls.Add(Me.Label46)
    Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox6.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox6.Location = New System.Drawing.Point(264, 8)
    Me.GroupBox6.Name = "GroupBox6"
    Me.GroupBox6.Size = New System.Drawing.Size(248, 112)
    Me.GroupBox6.TabIndex = 193
    Me.GroupBox6.TabStop = False
    Me.GroupBox6.Text = "Credit Vehicle"
    '
    'LnkCRSaleMonth
    '
    Me.LnkCRSaleMonth.Location = New System.Drawing.Point(8, 88)
    Me.LnkCRSaleMonth.Name = "LnkCRSaleMonth"
    Me.LnkCRSaleMonth.Size = New System.Drawing.Size(68, 20)
    Me.LnkCRSaleMonth.TabIndex = 203
    Me.LnkCRSaleMonth.TabStop = True
    Me.LnkCRSaleMonth.Text = "Sale Month"
    '
    'LblChgCRAssmt1
    '
    Me.LblChgCRAssmt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgCRAssmt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgCRAssmt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgCRAssmt1.ForeColor = System.Drawing.Color.Black
    Me.LblChgCRAssmt1.Location = New System.Drawing.Point(168, 32)
    Me.LblChgCRAssmt1.Name = "LblChgCRAssmt1"
    Me.LblChgCRAssmt1.Size = New System.Drawing.Size(72, 20)
    Me.LblChgCRAssmt1.TabIndex = 202
    Me.LblChgCRAssmt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label39
    '
    Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label39.ForeColor = System.Drawing.Color.Black
    Me.Label39.Location = New System.Drawing.Point(168, 16)
    Me.Label39.Name = "Label39"
    Me.Label39.Size = New System.Drawing.Size(72, 16)
    Me.Label39.TabIndex = 201
    Me.Label39.Text = "Change"
    Me.Label39.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label35
    '
    Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label35.ForeColor = System.Drawing.Color.Black
    Me.Label35.Location = New System.Drawing.Point(8, 16)
    Me.Label35.Name = "Label35"
    Me.Label35.Size = New System.Drawing.Size(72, 16)
    Me.Label35.TabIndex = 200
    Me.Label35.Text = "Original"
    Me.Label35.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'LblOrigCRAssmt1
    '
    Me.LblOrigCRAssmt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigCRAssmt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigCRAssmt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigCRAssmt1.ForeColor = System.Drawing.Color.Black
    Me.LblOrigCRAssmt1.Location = New System.Drawing.Point(8, 32)
    Me.LblOrigCRAssmt1.Name = "LblOrigCRAssmt1"
    Me.LblOrigCRAssmt1.Size = New System.Drawing.Size(72, 20)
    Me.LblOrigCRAssmt1.TabIndex = 199
    Me.LblOrigCRAssmt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCRSaleNet
    '
    Me.LblCRSaleNet.BackColor = System.Drawing.Color.LightCyan
    Me.LblCRSaleNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCRSaleNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCRSaleNet.ForeColor = System.Drawing.Color.Black
    Me.LblCRSaleNet.Location = New System.Drawing.Point(112, 88)
    Me.LblCRSaleNet.Name = "LblCRSaleNet"
    Me.LblCRSaleNet.Size = New System.Drawing.Size(72, 20)
    Me.LblCRSaleNet.TabIndex = 198
    Me.LblCRSaleNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCRSalePct
    '
    Me.LblCRSalePct.ForeColor = System.Drawing.Color.Black
    Me.LblCRSalePct.Location = New System.Drawing.Point(192, 92)
    Me.LblCRSalePct.Name = "LblCRSalePct"
    Me.LblCRSalePct.Size = New System.Drawing.Size(40, 16)
    Me.LblCRSalePct.TabIndex = 186
    '
    'TxtCRSaleMonth
    '
    Me.TxtCRSaleMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCRSaleMonth.Location = New System.Drawing.Point(80, 88)
    Me.TxtCRSaleMonth.MaxLength = 2
    Me.TxtCRSaleMonth.Name = "TxtCRSaleMonth"
    Me.TxtCRSaleMonth.Size = New System.Drawing.Size(24, 20)
    Me.TxtCRSaleMonth.TabIndex = 7
    Me.TxtCRSaleMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtCRAssmt1
    '
    Me.TxtCRAssmt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCRAssmt1.Location = New System.Drawing.Point(88, 32)
    Me.TxtCRAssmt1.MaxLength = 9
    Me.TxtCRAssmt1.Name = "TxtCRAssmt1"
    Me.TxtCRAssmt1.Size = New System.Drawing.Size(72, 20)
    Me.TxtCRAssmt1.TabIndex = 6
    Me.TxtCRAssmt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label46
    '
    Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label46.ForeColor = System.Drawing.Color.Black
    Me.Label46.Location = New System.Drawing.Point(88, 16)
    Me.Label46.Name = "Label46"
    Me.Label46.Size = New System.Drawing.Size(72, 16)
    Me.Label46.TabIndex = 33
    Me.Label46.Text = "New"
    Me.Label46.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'TpExemptions
    '
    Me.TpExemptions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.TpExemptions.Controls.Add(Me.GroupBox4)
    Me.TpExemptions.Location = New System.Drawing.Point(4, 25)
    Me.TpExemptions.Name = "TpExemptions"
    Me.TpExemptions.Size = New System.Drawing.Size(601, 317)
    Me.TpExemptions.TabIndex = 1
    Me.TpExemptions.Text = "Exemptions"
    Me.TpExemptions.Visible = False
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.LblChgExam5)
    Me.GroupBox4.Controls.Add(Me.LblChgExam4)
    Me.GroupBox4.Controls.Add(Me.LblChgExam3)
    Me.GroupBox4.Controls.Add(Me.LblChgExam2)
    Me.GroupBox4.Controls.Add(Me.LblChgExam1)
    Me.GroupBox4.Controls.Add(Me.Label70)
    Me.GroupBox4.Controls.Add(Me.LblOrigExam5)
    Me.GroupBox4.Controls.Add(Me.LblOrigExam4)
    Me.GroupBox4.Controls.Add(Me.LblOrigExam3)
    Me.GroupBox4.Controls.Add(Me.LblOrigExam2)
    Me.GroupBox4.Controls.Add(Me.Label58)
    Me.GroupBox4.Controls.Add(Me.LblOrigExam1)
    Me.GroupBox4.Controls.Add(Me.LnkExempt5)
    Me.GroupBox4.Controls.Add(Me.TxtExempt5)
    Me.GroupBox4.Controls.Add(Me.LnkExempt3)
    Me.GroupBox4.Controls.Add(Me.TxtExempt3)
    Me.GroupBox4.Controls.Add(Me.LnkExempt4)
    Me.GroupBox4.Controls.Add(Me.TxtExempt4)
    Me.GroupBox4.Controls.Add(Me.LnkExempt2)
    Me.GroupBox4.Controls.Add(Me.TxtExempt2)
    Me.GroupBox4.Controls.Add(Me.LnkExempt1)
    Me.GroupBox4.Controls.Add(Me.TxtExempt1)
    Me.GroupBox4.Controls.Add(Me.TxtExam4)
    Me.GroupBox4.Controls.Add(Me.TxtExam2)
    Me.GroupBox4.Controls.Add(Me.TxtExam5)
    Me.GroupBox4.Controls.Add(Me.TxtExam3)
    Me.GroupBox4.Controls.Add(Me.TxtExam1)
    Me.GroupBox4.Controls.Add(Me.Label50)
    Me.GroupBox4.Controls.Add(Me.Label52)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox4.Location = New System.Drawing.Point(8, 8)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(296, 152)
    Me.GroupBox4.TabIndex = 124
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Exemptions"
    '
    'LblChgExam5
    '
    Me.LblChgExam5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgExam5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgExam5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgExam5.ForeColor = System.Drawing.Color.Black
    Me.LblChgExam5.Location = New System.Drawing.Point(224, 128)
    Me.LblChgExam5.Name = "LblChgExam5"
    Me.LblChgExam5.Size = New System.Drawing.Size(64, 20)
    Me.LblChgExam5.TabIndex = 201
    Me.LblChgExam5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblChgExam4
    '
    Me.LblChgExam4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgExam4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgExam4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgExam4.ForeColor = System.Drawing.Color.Black
    Me.LblChgExam4.Location = New System.Drawing.Point(224, 104)
    Me.LblChgExam4.Name = "LblChgExam4"
    Me.LblChgExam4.Size = New System.Drawing.Size(64, 20)
    Me.LblChgExam4.TabIndex = 200
    Me.LblChgExam4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblChgExam3
    '
    Me.LblChgExam3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgExam3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgExam3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgExam3.ForeColor = System.Drawing.Color.Black
    Me.LblChgExam3.Location = New System.Drawing.Point(224, 80)
    Me.LblChgExam3.Name = "LblChgExam3"
    Me.LblChgExam3.Size = New System.Drawing.Size(64, 20)
    Me.LblChgExam3.TabIndex = 199
    Me.LblChgExam3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblChgExam2
    '
    Me.LblChgExam2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgExam2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgExam2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgExam2.ForeColor = System.Drawing.Color.Black
    Me.LblChgExam2.Location = New System.Drawing.Point(224, 56)
    Me.LblChgExam2.Name = "LblChgExam2"
    Me.LblChgExam2.Size = New System.Drawing.Size(64, 20)
    Me.LblChgExam2.TabIndex = 198
    Me.LblChgExam2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblChgExam1
    '
    Me.LblChgExam1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgExam1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgExam1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgExam1.ForeColor = System.Drawing.Color.Black
    Me.LblChgExam1.Location = New System.Drawing.Point(224, 32)
    Me.LblChgExam1.Name = "LblChgExam1"
    Me.LblChgExam1.Size = New System.Drawing.Size(64, 20)
    Me.LblChgExam1.TabIndex = 197
    Me.LblChgExam1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label70
    '
    Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label70.ForeColor = System.Drawing.Color.Black
    Me.Label70.Location = New System.Drawing.Point(224, 16)
    Me.Label70.Name = "Label70"
    Me.Label70.Size = New System.Drawing.Size(64, 16)
    Me.Label70.TabIndex = 196
    Me.Label70.Text = "Change"
    Me.Label70.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'LblOrigExam5
    '
    Me.LblOrigExam5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigExam5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigExam5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigExam5.ForeColor = System.Drawing.Color.Black
    Me.LblOrigExam5.Location = New System.Drawing.Point(72, 128)
    Me.LblOrigExam5.Name = "LblOrigExam5"
    Me.LblOrigExam5.Size = New System.Drawing.Size(64, 20)
    Me.LblOrigExam5.TabIndex = 193
    Me.LblOrigExam5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblOrigExam4
    '
    Me.LblOrigExam4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigExam4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigExam4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigExam4.ForeColor = System.Drawing.Color.Black
    Me.LblOrigExam4.Location = New System.Drawing.Point(72, 104)
    Me.LblOrigExam4.Name = "LblOrigExam4"
    Me.LblOrigExam4.Size = New System.Drawing.Size(64, 20)
    Me.LblOrigExam4.TabIndex = 192
    Me.LblOrigExam4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblOrigExam3
    '
    Me.LblOrigExam3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigExam3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigExam3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigExam3.ForeColor = System.Drawing.Color.Black
    Me.LblOrigExam3.Location = New System.Drawing.Point(72, 80)
    Me.LblOrigExam3.Name = "LblOrigExam3"
    Me.LblOrigExam3.Size = New System.Drawing.Size(64, 20)
    Me.LblOrigExam3.TabIndex = 191
    Me.LblOrigExam3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblOrigExam2
    '
    Me.LblOrigExam2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigExam2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigExam2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigExam2.ForeColor = System.Drawing.Color.Black
    Me.LblOrigExam2.Location = New System.Drawing.Point(72, 56)
    Me.LblOrigExam2.Name = "LblOrigExam2"
    Me.LblOrigExam2.Size = New System.Drawing.Size(64, 20)
    Me.LblOrigExam2.TabIndex = 190
    Me.LblOrigExam2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label58
    '
    Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label58.ForeColor = System.Drawing.Color.Black
    Me.Label58.Location = New System.Drawing.Point(72, 16)
    Me.Label58.Name = "Label58"
    Me.Label58.Size = New System.Drawing.Size(64, 16)
    Me.Label58.TabIndex = 184
    Me.Label58.Text = "Original"
    Me.Label58.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'LblOrigExam1
    '
    Me.LblOrigExam1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigExam1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigExam1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigExam1.ForeColor = System.Drawing.Color.Black
    Me.LblOrigExam1.Location = New System.Drawing.Point(72, 32)
    Me.LblOrigExam1.Name = "LblOrigExam1"
    Me.LblOrigExam1.Size = New System.Drawing.Size(64, 20)
    Me.LblOrigExam1.TabIndex = 183
    Me.LblOrigExam1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LnkExempt5
    '
    Me.LnkExempt5.Location = New System.Drawing.Point(8, 132)
    Me.LnkExempt5.Name = "LnkExempt5"
    Me.LnkExempt5.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt5.TabIndex = 175
    Me.LnkExempt5.TabStop = True
    Me.LnkExempt5.Text = "5"
    '
    'TxtExempt5
    '
    Me.TxtExempt5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt5.Location = New System.Drawing.Point(32, 128)
    Me.TxtExempt5.MaxLength = 3
    Me.TxtExempt5.Name = "TxtExempt5"
    Me.TxtExempt5.Size = New System.Drawing.Size(32, 20)
    Me.TxtExempt5.TabIndex = 8
    '
    'LnkExempt3
    '
    Me.LnkExempt3.Location = New System.Drawing.Point(8, 84)
    Me.LnkExempt3.Name = "LnkExempt3"
    Me.LnkExempt3.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt3.TabIndex = 173
    Me.LnkExempt3.TabStop = True
    Me.LnkExempt3.Text = "3"
    '
    'TxtExempt3
    '
    Me.TxtExempt3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt3.Location = New System.Drawing.Point(32, 80)
    Me.TxtExempt3.MaxLength = 3
    Me.TxtExempt3.Name = "TxtExempt3"
    Me.TxtExempt3.Size = New System.Drawing.Size(32, 20)
    Me.TxtExempt3.TabIndex = 4
    '
    'LnkExempt4
    '
    Me.LnkExempt4.Location = New System.Drawing.Point(8, 108)
    Me.LnkExempt4.Name = "LnkExempt4"
    Me.LnkExempt4.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt4.TabIndex = 174
    Me.LnkExempt4.TabStop = True
    Me.LnkExempt4.Text = "4"
    '
    'TxtExempt4
    '
    Me.TxtExempt4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt4.Location = New System.Drawing.Point(32, 104)
    Me.TxtExempt4.MaxLength = 3
    Me.TxtExempt4.Name = "TxtExempt4"
    Me.TxtExempt4.Size = New System.Drawing.Size(32, 20)
    Me.TxtExempt4.TabIndex = 6
    '
    'LnkExempt2
    '
    Me.LnkExempt2.Location = New System.Drawing.Point(8, 60)
    Me.LnkExempt2.Name = "LnkExempt2"
    Me.LnkExempt2.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt2.TabIndex = 172
    Me.LnkExempt2.TabStop = True
    Me.LnkExempt2.Text = "2"
    '
    'TxtExempt2
    '
    Me.TxtExempt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt2.Location = New System.Drawing.Point(32, 56)
    Me.TxtExempt2.MaxLength = 3
    Me.TxtExempt2.Name = "TxtExempt2"
    Me.TxtExempt2.Size = New System.Drawing.Size(32, 20)
    Me.TxtExempt2.TabIndex = 2
    '
    'LnkExempt1
    '
    Me.LnkExempt1.Location = New System.Drawing.Point(8, 36)
    Me.LnkExempt1.Name = "LnkExempt1"
    Me.LnkExempt1.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt1.TabIndex = 171
    Me.LnkExempt1.TabStop = True
    Me.LnkExempt1.Text = "1"
    '
    'TxtExempt1
    '
    Me.TxtExempt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt1.Location = New System.Drawing.Point(32, 32)
    Me.TxtExempt1.MaxLength = 3
    Me.TxtExempt1.Name = "TxtExempt1"
    Me.TxtExempt1.Size = New System.Drawing.Size(32, 20)
    Me.TxtExempt1.TabIndex = 0
    '
    'TxtExam4
    '
    Me.TxtExam4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam4.Location = New System.Drawing.Point(144, 104)
    Me.TxtExam4.MaxLength = 7
    Me.TxtExam4.Name = "TxtExam4"
    Me.TxtExam4.Size = New System.Drawing.Size(72, 20)
    Me.TxtExam4.TabIndex = 7
    Me.TxtExam4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam2
    '
    Me.TxtExam2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam2.Location = New System.Drawing.Point(144, 56)
    Me.TxtExam2.MaxLength = 7
    Me.TxtExam2.Name = "TxtExam2"
    Me.TxtExam2.Size = New System.Drawing.Size(72, 20)
    Me.TxtExam2.TabIndex = 3
    Me.TxtExam2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam5
    '
    Me.TxtExam5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam5.Location = New System.Drawing.Point(144, 128)
    Me.TxtExam5.MaxLength = 7
    Me.TxtExam5.Name = "TxtExam5"
    Me.TxtExam5.Size = New System.Drawing.Size(72, 20)
    Me.TxtExam5.TabIndex = 9
    Me.TxtExam5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam3
    '
    Me.TxtExam3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam3.Location = New System.Drawing.Point(144, 80)
    Me.TxtExam3.MaxLength = 7
    Me.TxtExam3.Name = "TxtExam3"
    Me.TxtExam3.Size = New System.Drawing.Size(72, 20)
    Me.TxtExam3.TabIndex = 5
    Me.TxtExam3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam1
    '
    Me.TxtExam1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam1.Location = New System.Drawing.Point(144, 32)
    Me.TxtExam1.MaxLength = 7
    Me.TxtExam1.Name = "TxtExam1"
    Me.TxtExam1.Size = New System.Drawing.Size(72, 20)
    Me.TxtExam1.TabIndex = 1
    Me.TxtExam1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label50
    '
    Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label50.ForeColor = System.Drawing.Color.Black
    Me.Label50.Location = New System.Drawing.Point(144, 16)
    Me.Label50.Name = "Label50"
    Me.Label50.Size = New System.Drawing.Size(74, 16)
    Me.Label50.TabIndex = 38
    Me.Label50.Text = "New"
    Me.Label50.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label52
    '
    Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label52.ForeColor = System.Drawing.Color.Black
    Me.Label52.Location = New System.Drawing.Point(24, 16)
    Me.Label52.Name = "Label52"
    Me.Label52.Size = New System.Drawing.Size(42, 16)
    Me.Label52.TabIndex = 35
    Me.Label52.Text = "Code"
    Me.Label52.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(8, 56)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(80, 16)
    Me.Label2.TabIndex = 193
    Me.Label2.Text = "Second Name"
    '
    'LblBeforeCC
    '
    Me.LblBeforeCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBeforeCC.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblBeforeCC.Location = New System.Drawing.Point(382, 60)
    Me.LblBeforeCC.Name = "LblBeforeCC"
    Me.LblBeforeCC.Size = New System.Drawing.Size(149, 16)
    Me.LblBeforeCC.TabIndex = 206
    Me.LblBeforeCC.Text = "*** Before C/C exists ***"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.Label24)
    Me.GroupBox2.Controls.Add(Me.LblChgAmt)
    Me.GroupBox2.Controls.Add(Me.LblNewAmt)
    Me.GroupBox2.Controls.Add(Me.LblOrigAmt)
    Me.GroupBox2.Controls.Add(Me.LblChgAdjGross)
    Me.GroupBox2.Controls.Add(Me.LblNewAdjGross)
    Me.GroupBox2.Controls.Add(Me.LblOrigAdjGross)
    Me.GroupBox2.Controls.Add(Me.Label53)
    Me.GroupBox2.Controls.Add(Me.LblChgNet)
    Me.GroupBox2.Controls.Add(Me.LblNewNet)
    Me.GroupBox2.Controls.Add(Me.LblOrigNet)
    Me.GroupBox2.Controls.Add(Me.LblChgProrate)
    Me.GroupBox2.Controls.Add(Me.LblNewProrate)
    Me.GroupBox2.Controls.Add(Me.LblOrigProrate)
    Me.GroupBox2.Controls.Add(Me.LblChgExam)
    Me.GroupBox2.Controls.Add(Me.LblNewExam)
    Me.GroupBox2.Controls.Add(Me.Label21)
    Me.GroupBox2.Controls.Add(Me.Label20)
    Me.GroupBox2.Controls.Add(Me.Label19)
    Me.GroupBox2.Controls.Add(Me.LblChgGross)
    Me.GroupBox2.Controls.Add(Me.Label34)
    Me.GroupBox2.Controls.Add(Me.LblNewGross)
    Me.GroupBox2.Controls.Add(Me.LblOrigGross)
    Me.GroupBox2.Controls.Add(Me.LblOrigExam)
    Me.GroupBox2.Controls.Add(Me.Label30)
    Me.GroupBox2.Controls.Add(Me.LblOrig)
    Me.GroupBox2.Controls.Add(Me.Label22)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(550, 9)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(343, 135)
    Me.GroupBox2.TabIndex = 207
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Totals"
    '
    'Label24
    '
    Me.Label24.AutoSize = True
    Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label24.ForeColor = System.Drawing.Color.Black
    Me.Label24.Location = New System.Drawing.Point(6, 107)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(67, 13)
    Me.Label24.TabIndex = 213
    Me.Label24.Text = "Tax  Amount"
    Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblChgAmt
    '
    Me.LblChgAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgAmt.Location = New System.Drawing.Point(252, 107)
    Me.LblChgAmt.Name = "LblChgAmt"
    Me.LblChgAmt.Size = New System.Drawing.Size(80, 16)
    Me.LblChgAmt.TabIndex = 212
    Me.LblChgAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblNewAmt
    '
    Me.LblNewAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblNewAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblNewAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNewAmt.Location = New System.Drawing.Point(166, 107)
    Me.LblNewAmt.Name = "LblNewAmt"
    Me.LblNewAmt.Size = New System.Drawing.Size(80, 16)
    Me.LblNewAmt.TabIndex = 211
    Me.LblNewAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblOrigAmt
    '
    Me.LblOrigAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigAmt.Location = New System.Drawing.Point(80, 107)
    Me.LblOrigAmt.Name = "LblOrigAmt"
    Me.LblOrigAmt.Size = New System.Drawing.Size(80, 16)
    Me.LblOrigAmt.TabIndex = 210
    Me.LblOrigAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblChgAdjGross
    '
    Me.LblChgAdjGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgAdjGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgAdjGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgAdjGross.Location = New System.Drawing.Point(252, 73)
    Me.LblChgAdjGross.Name = "LblChgAdjGross"
    Me.LblChgAdjGross.Size = New System.Drawing.Size(80, 16)
    Me.LblChgAdjGross.TabIndex = 173
    Me.LblChgAdjGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblNewAdjGross
    '
    Me.LblNewAdjGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblNewAdjGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblNewAdjGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNewAdjGross.Location = New System.Drawing.Point(166, 73)
    Me.LblNewAdjGross.Name = "LblNewAdjGross"
    Me.LblNewAdjGross.Size = New System.Drawing.Size(80, 16)
    Me.LblNewAdjGross.TabIndex = 172
    Me.LblNewAdjGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblOrigAdjGross
    '
    Me.LblOrigAdjGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigAdjGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigAdjGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigAdjGross.Location = New System.Drawing.Point(80, 73)
    Me.LblOrigAdjGross.Name = "LblOrigAdjGross"
    Me.LblOrigAdjGross.Size = New System.Drawing.Size(80, 16)
    Me.LblOrigAdjGross.TabIndex = 171
    Me.LblOrigAdjGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label53
    '
    Me.Label53.AutoSize = True
    Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label53.ForeColor = System.Drawing.Color.Black
    Me.Label53.Location = New System.Drawing.Point(6, 75)
    Me.Label53.Name = "Label53"
    Me.Label53.Size = New System.Drawing.Size(52, 13)
    Me.Label53.TabIndex = 170
    Me.Label53.Text = "Adj Gross"
    '
    'LblChgNet
    '
    Me.LblChgNet.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgNet.Location = New System.Drawing.Point(252, 89)
    Me.LblChgNet.Name = "LblChgNet"
    Me.LblChgNet.Size = New System.Drawing.Size(80, 16)
    Me.LblChgNet.TabIndex = 169
    Me.LblChgNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblNewNet
    '
    Me.LblNewNet.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblNewNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblNewNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNewNet.Location = New System.Drawing.Point(166, 89)
    Me.LblNewNet.Name = "LblNewNet"
    Me.LblNewNet.Size = New System.Drawing.Size(80, 16)
    Me.LblNewNet.TabIndex = 168
    Me.LblNewNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblOrigNet
    '
    Me.LblOrigNet.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigNet.Location = New System.Drawing.Point(80, 89)
    Me.LblOrigNet.Name = "LblOrigNet"
    Me.LblOrigNet.Size = New System.Drawing.Size(80, 16)
    Me.LblOrigNet.TabIndex = 167
    Me.LblOrigNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblChgProrate
    '
    Me.LblChgProrate.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgProrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgProrate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgProrate.Location = New System.Drawing.Point(252, 41)
    Me.LblChgProrate.Name = "LblChgProrate"
    Me.LblChgProrate.Size = New System.Drawing.Size(80, 16)
    Me.LblChgProrate.TabIndex = 166
    Me.LblChgProrate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblNewProrate
    '
    Me.LblNewProrate.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblNewProrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblNewProrate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNewProrate.Location = New System.Drawing.Point(166, 41)
    Me.LblNewProrate.Name = "LblNewProrate"
    Me.LblNewProrate.Size = New System.Drawing.Size(80, 16)
    Me.LblNewProrate.TabIndex = 165
    Me.LblNewProrate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblOrigProrate
    '
    Me.LblOrigProrate.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigProrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigProrate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigProrate.Location = New System.Drawing.Point(80, 41)
    Me.LblOrigProrate.Name = "LblOrigProrate"
    Me.LblOrigProrate.Size = New System.Drawing.Size(80, 16)
    Me.LblOrigProrate.TabIndex = 164
    Me.LblOrigProrate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblChgExam
    '
    Me.LblChgExam.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgExam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgExam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgExam.Location = New System.Drawing.Point(252, 57)
    Me.LblChgExam.Name = "LblChgExam"
    Me.LblChgExam.Size = New System.Drawing.Size(80, 16)
    Me.LblChgExam.TabIndex = 163
    Me.LblChgExam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblNewExam
    '
    Me.LblNewExam.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblNewExam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblNewExam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNewExam.Location = New System.Drawing.Point(166, 57)
    Me.LblNewExam.Name = "LblNewExam"
    Me.LblNewExam.Size = New System.Drawing.Size(80, 16)
    Me.LblNewExam.TabIndex = 162
    Me.LblNewExam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label21
    '
    Me.Label21.AutoSize = True
    Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label21.ForeColor = System.Drawing.Color.Black
    Me.Label21.Location = New System.Drawing.Point(6, 43)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(41, 13)
    Me.Label21.TabIndex = 35
    Me.Label21.Text = "Prorate"
    '
    'Label20
    '
    Me.Label20.AutoSize = True
    Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label20.ForeColor = System.Drawing.Color.Black
    Me.Label20.Location = New System.Drawing.Point(6, 59)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(61, 13)
    Me.Label20.TabIndex = 34
    Me.Label20.Text = "Exemptions"
    '
    'Label19
    '
    Me.Label19.AutoSize = True
    Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label19.ForeColor = System.Drawing.Color.Black
    Me.Label19.Location = New System.Drawing.Point(6, 27)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(34, 13)
    Me.Label19.TabIndex = 33
    Me.Label19.Text = "Gross"
    '
    'LblChgGross
    '
    Me.LblChgGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgGross.Location = New System.Drawing.Point(252, 25)
    Me.LblChgGross.Name = "LblChgGross"
    Me.LblChgGross.Size = New System.Drawing.Size(80, 16)
    Me.LblChgGross.TabIndex = 21
    Me.LblChgGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label34
    '
    Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label34.Location = New System.Drawing.Point(264, 8)
    Me.Label34.Name = "Label34"
    Me.Label34.Size = New System.Drawing.Size(48, 16)
    Me.Label34.TabIndex = 20
    Me.Label34.Text = "Change"
    '
    'LblNewGross
    '
    Me.LblNewGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblNewGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblNewGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNewGross.Location = New System.Drawing.Point(166, 25)
    Me.LblNewGross.Name = "LblNewGross"
    Me.LblNewGross.Size = New System.Drawing.Size(80, 16)
    Me.LblNewGross.TabIndex = 19
    Me.LblNewGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblOrigGross
    '
    Me.LblOrigGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigGross.Location = New System.Drawing.Point(80, 25)
    Me.LblOrigGross.Name = "LblOrigGross"
    Me.LblOrigGross.Size = New System.Drawing.Size(80, 16)
    Me.LblOrigGross.TabIndex = 18
    Me.LblOrigGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblOrigExam
    '
    Me.LblOrigExam.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigExam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigExam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigExam.Location = New System.Drawing.Point(80, 57)
    Me.LblOrigExam.Name = "LblOrigExam"
    Me.LblOrigExam.Size = New System.Drawing.Size(80, 16)
    Me.LblOrigExam.TabIndex = 17
    Me.LblOrigExam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label30
    '
    Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label30.Location = New System.Drawing.Point(188, 8)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(48, 16)
    Me.Label30.TabIndex = 16
    Me.Label30.Text = "New"
    '
    'LblOrig
    '
    Me.LblOrig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrig.Location = New System.Drawing.Point(96, 8)
    Me.LblOrig.Name = "LblOrig"
    Me.LblOrig.Size = New System.Drawing.Size(64, 16)
    Me.LblOrig.TabIndex = 15
    Me.LblOrig.Text = "Original"
    '
    'Label22
    '
    Me.Label22.AutoSize = True
    Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label22.ForeColor = System.Drawing.Color.Black
    Me.Label22.Location = New System.Drawing.Point(6, 91)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(24, 13)
    Me.Label22.TabIndex = 160
    Me.Label22.Text = "Net"
    '
    'FrmTA8115R
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(905, 510)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.LblBeforeCC)
    Me.Controls.Add(Me.TxtState)
    Me.Controls.Add(Me.TxtAdd1)
    Me.Controls.Add(Me.Label42)
    Me.Controls.Add(Me.LblType)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.TxtAdd2)
    Me.Controls.Add(Me.TxtSname)
    Me.Controls.Add(Me.TxtZip5)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LblCCNo)
    Me.Controls.Add(Me.LblListNo)
    Me.Controls.Add(Me.LblCCDate)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.TxtCity)
    Me.Controls.Add(Me.TxtZip4)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.TabControl1)
    Me.Controls.Add(Me.Label2)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA8115R"
    Me.Text = "Certificate of Change - Suppl Motor Vehicle "
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TabControl1.ResumeLayout(False)
    Me.TpMain.ResumeLayout(False)
    Me.TpMain.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
    Me.TpAssmnt.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox6.ResumeLayout(False)
    Me.GroupBox6.PerformLayout()
    Me.TpExemptions.ResumeLayout(False)
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTA8115R_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim ds As DataSet = New DataSet
    Dim WrkAttachCount As Integer
    Dim WrkDate As Date
    Dim WrkDBDate As Integer
    Dim WrkDBTime As Integer
    Dim WrkAss As String
    Dim WrkPurchProrate As Integer
    Dim WrkPurchAdjNet As Integer
    Dim WrkPurchPct As Single
    Dim WrkPurchMonth As Integer
    Dim WrkCRSaleProrate As Integer
    Dim WrkCRSaleAdjNet As Integer
    Dim WrkCRSalePct As Single
    Dim WrkCRSaleMonth As Integer
    Dim CoeCCNo As Integer

    MyTXMCTL = New TXMCTL.MyData(myDBConnect)
    MyTXCOEA = New TXCOEA.MyData(myDBConnect)
    MyTXCOEAL1 = New TXCOEAL1.MyData(myDBConnect)
    MyTXCOEBL4 = New TXCOEBL4.MyData(myDBConnect)
    MyTXINV = New TXINV.MyData(myDBConnect)
    MyTXMRATE = New TXMRATE.MyData(myDBConnect)
    MyTXVCUS = New TXVCUS.MyData(myDBConnect)
    MyTXVEH = New TXVEH.MyData(myDBConnect)
    MyTPAYMNT = New TPAYMNT.MyData(myDBConnect)
    myTXMSRP = New TXMSRP.MyData(myDBConnect)
    myTXMSRPDEP = New TXMSRPDEP.MyData(myDBConnect)
    myTXMSRPCD = New TXMSRPCD.MyData(myDBConnect)
    LoadScrn = True
    LblPDMsg.Text = ""
    LblCRPDMsg.Text = ""

    If MyBookPct = 0 Then
      MyTXMCTL.GetOneRecordP(1)
      If Not MyTXMCTL.RecordNotFound Then
        With MyTXMCTL
          MyBookPct = ._VALPER
          MyMinValue = ._VALMIN
        End With
      End If
    End If

    With MyFrmTA811
      .TBarComments.Enabled = True
      .TBarNew.Enabled = False
      .TBarSave.Enabled = True
      .TBarHist.Enabled = False
      .TBarSettings.Enabled = False
      If WrkCCNo > 0 Then
        .TBarAttach.Enabled = True
      End If
    End With

    WrkAttachCount = GetAttachcount(“CCAFTER”, WrkCCNo)
    MyFrmTA811.TBarAttach.Text = WrkAttachCount & " Attachment(s)"

    'On New, Check for existing C/C done today. If found, then change to update mode. 
    If WrkCCNo = 0 Then
      WrkDBDate = MyUtils.SetDBDate(Date.Today)
      If Not MyBeforeBillDate Then
        If Date.Today <> WrkCCDate Then
          MsgBox("Changing date to billing date", MsgBoxStyle.Information, "C/C Entry date is before billing date")
          WrkDBDate = MyUtils.SetDBDate(WrkCCDate)
        End If
      End If
      dsTXCOEAL1 = MyTXCOEAL1.GetLastbyDate(WrkListNo, WrkYear, WrkType, WrkDBDate)
      If dsTXCOEAL1.Tables(0).Rows.Count > 0 Then
        With dsTXCOEAL1.Tables(0).Rows(0)
          If WrkDBDate = .Item("chdate") Then
            WrkCCNo = .Item("ccno")
            WrkAddMode = False
            MsgBox("New C/C was not created. Click OK to change existing C/C done today instead.", MsgBoxStyle.Information, "Existing C/C found with today's date")
          End If
        End With
      End If
    End If

    'Fill the dataset with the data
    If Not WrkAddMode Then
      MyFrmTA811.TBarPrint.Enabled = True
      LblCCNo.Text = WrkCCNo
      Me.Text = "Maintain " & Me.Text
      MyTXCOEA.GetOneRecordP(WrkCCNo)
      If MyTXCOEA.RecordNotFound Then
        MyFrmTA811.TBarNew.Enabled = False
        MyFrmTA811.TBarSave.Enabled = False
        MyFrmTA811.TBarDelete.Enabled = False
        Me.ErrProv.SetError(LblCCNo, "Record not found")
        Exit Sub
      End If
      GetTxCOEA()
      If WrkCCDate = WrkDate And LblCCDate.Text = Date.Today Then
        WrkCCDate = LblCCDate.Text
      End If
      If EntryDate <> WrkCCDate Then
        Me.ErrProv.SetError(LblCCNo, "Cannot edit (not same date)")
        MyFrmTA811.TBarSave.Enabled = False
      End If
    Else
      MyFrmTA811.TBarPrint.Enabled = False
      MyFrmTA811.TBarDelete.Enabled = False
      Me.Text = "Add " & Me.Text
      If MyOpenCC Then
        LblCCNo.Text = WrkCCNo
        LblCCDate.Text = WrkCCDate
      Else
        LblCCDate.Text = Date.Today
      End If
      LblListNo.Text = WrkListNo
      LblYear.Text = WrkYear
      LblType.Text = WrkType
      TxtDist.Text = WrkDist
    End If

    MyTXMRATE.GetOneRecordP(WrkYear, "S", WrkDist)
    If MyTXMRATE.RecordNotFound Then
      MyTXMRATE.GetOneRecordP(WrkYear, "", WrkDist)
    End If
    If Not MyTXMRATE.RecordNotFound Then
      With MyTXMRATE
        LblMRate.Text = ._MRRATE
      End With
    End If

    CoeCCNo = 0
    If WrkCCNo > 0 Then
      WrkDBDate = MyUtils.SetDBDate(EntryDate) - 1
      WrkDBTime = 999999
    Else
      LblCCDate.Text = Format(MyUtils.GetDBDate(WrkDBDate), "M/dd/yyyy")
      WrkDBDate = MyUtils.SetDBDate(Date.Today) - 1
      WrkDBTime = 999999
    End If
    dsTXCOEAL1 = MyTXCOEAL1.GetViewDescList(WrkListNo, WrkYear, WrkType, WrkDBDate,
      WrkDBTime, 50)
    If dsTXCOEAL1.Tables(0).Rows.Count > 0 Then
      With dsTXCOEAL1.Tables(0).Rows(0)
        CoeCCNo = .Item("ccno")
      End With
    End If

    LblBeforeCC.Visible = False
    MyTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
    If Not MyTXINV.RecordNotFound Then
      With MyTXINV
        WrkAss = Trim(._ASS)
        If ._ETCA = "Y" Then
          LblBeforeCC.Visible = True
          ds = MyTXCOEBL4.GetDescList(WrkListNo, WrkYear, WrkType, 99999999, 999999, 1)
          If ds.Tables(0).Rows.Count > 0 Then
            WrkAss = ds.Tables(0).Rows(0).Item("ct2mc1")
          End If
        End If
        TxtName.Text = Trim(._NAME)
        TxtSname.Text = Trim(._SNAME)
        TxtAdd1.Text = Trim(._ADD1)
        TxtAdd2.Text = Trim(._ADD2)
        TxtCity.Text = Trim(._CITY)
        TxtState.Text = Trim(._STATE)
        TxtZip5.Text = Format(._ZIP5, "00000")
        TxtZip4.Text = Format(._ZIP4, "0000")
        TxtID.Text = Trim(._IMVIDNo)
        TxtReg.Text = Trim(._IMVREG)
        TxtClass.Text = ._CLASS
        TxtMVYear.Text = ._MVYR
        TxtMake.Text = Trim(._MAKE)
        TxtModel.Text = Trim(._MODEL)
        If ._SSNo > 0 Then
          TxtSSNo.Text = ._SSNo
        End If
        If ._SS2 > 0 Then
          TxtSS2.Text = ._SS2
        End If
        TxtOid.Text = Trim(._OID)
        TxtCRID.Text = Trim(._ICVIDNo)
        TXTCRReg.Text = Trim(._ICVREG)
        TxtCRClass.Text = ._ICVCLS
        TXTCRMVYear.Text = ._ICVYR
        TxtCRMake.Text = Trim(._ICVMKE)
        TxtCRModel.Text = Trim(._ICVMOD)
        TxtOVMSRP.Text = ""
        myTXMSRP.GetOneRecordP(Trim(._IMVIDNo))
        With myTXMSRP
          If Not .RecordNotFound Then
            If Trim(._OVSOURCE) <> "" Then
              TxtOVMSRP.Text = ._OVMSRP
              TxtSource.Text = Trim(._OVSOURCE)
            End If
            If ._COMPLETE = "Y" Then
              ChkComplete.Checked = True
            End If
          End If
        End With
        CalcValue(0, MyUtils.CnvSng(TxtOVMSRP.Text), ._MVYR) 'populate LblMSRPCalc

        If CoeCCNo = 0 Then
          LblOrigAdjGross.Text = "0"
          If ._ICVGRS > 0 Then
            CalcProrateCode("C", Trim(._ASS), ._GROSS, WrkPurchProrate,
              WrkPurchAdjNet, WrkPurchPct, WrkPurchMonth)
          Else
            CalcProrateCode("P", Trim(._ASS), ._GROSS, WrkPurchProrate,
              WrkPurchAdjNet, WrkPurchPct, WrkPurchMonth)
          End If
          LblOrigProrate.Text = FormatNumber(WrkPurchProrate, 0)
          CalcProrateCode("C", Trim(._ICVACD), ._ICVGRS, WrkCRSaleProrate,
            WrkCRSaleAdjNet, WrkCRSalePct, WrkCRSaleMonth)
          If WrkCRSaleAdjNet > WrkPurchAdjNet Then
            LblOrigAdjGross.Text = FormatNumber(WrkPurchAdjNet, 0)
          Else
            LblOrigAdjGross.Text = FormatNumber(WrkCRSaleAdjNet, 0)
          End If
          LblOrigGross.Text = FormatNumber(._GROSS, 0)
          LblOrigExam.Text = FormatNumber(._TOTEXP, 0)
          LblOrigNet.Text = FormatNumber(._NETASS, 0)
          LblOrigProrate.Text = FormatNumber(._GROSS - ._TOTEXP - ._NETASS, 0)
          LblOrigAmt.Text = MyUtils.FmtCurrency(._TAXT)
          LblOrigAssmt1.Text = ._GROSS
          LblOrigCRAssmt1.Text = ._ICVGRS
          LblOrigExam1.Text = ._EXAM1
          LblOrigExam2.Text = ._EXAM2
          LblOrigExam3.Text = ._EXAM3
          LblOrigExam4.Text = ._EXAM4
          LblOrigExam5.Text = ._EXAM5
          If WrkAddMode Then
            'Check for Credit Vehicle Gross
            TxtCRAssmt1.Text = ._ICVGRS
            TxtPurchMonth.Text = WrkPurchMonth
            LblPurchPct.Text = WrkPurchPct
            LblPurchNet.Text = WrkPurchAdjNet
            TxtCRSaleMonth.Text = WrkCRSaleMonth
            LblCRSalePct.Text = WrkCRSalePct
            LblCRSaleNet.Text = WrkCRSaleAdjNet
            LblAdjNet.Text = WrkPurchAdjNet - WrkCRSaleAdjNet
            'Exemption Codes
            TxtExempt1.Text = Trim(._EXCD1)
            TxtExempt2.Text = Trim(._EXCD2)
            TxtExempt3.Text = Trim(._EXCD3)
            TxtExempt4.Text = Trim(._EXCD4)
            TxtExempt5.Text = Trim(._EXCD5)
            SetExem1Tip()
            SetExem2Tip()
            SetExem3Tip()
            SetExem4Tip()
            SetExem5Tip()
          End If
        End If
      End With
    End If

    If CoeCCNo > 0 Then
      GetOrigTxCOEA(CoeCCNo)
    End If

    LblValue.Text = MyUtils.CnvSng(LblOrigAssmt1.Text)
    If WrkAddMode Then
      TxtAssmt1.Text = MyUtils.CnvSng(LblOrigAssmt1.Text)
      TxtExam1.Text = MyUtils.CnvSng(LblOrigExam1.Text)
      TxtExam2.Text = MyUtils.CnvSng(LblOrigExam2.Text)
      TxtExam3.Text = MyUtils.CnvSng(LblOrigExam3.Text)
      TxtExam4.Text = MyUtils.CnvSng(LblOrigExam4.Text)
      TxtExam5.Text = MyUtils.CnvSng(LblOrigExam5.Text)
    End If

    dsTXCOEAL1 = MyTXCOEAL1.GetViewbyList(WrkListNo, WrkYear, WrkType, 50)
    If WrkAddMode Then
      If dsTXCOEAL1.Tables(0).Rows.Count > 0 Then
        MyFrmTA811.TBarHist.Enabled = True
      End If
    Else
      If dsTXCOEAL1.Tables(0).Rows.Count > 1 Then
        MyFrmTA811.TBarHist.Enabled = True
      End If
    End If

    LoadScrn = False
    CalcChg()
  End Sub

  Private Sub FrmTA8115R_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    With MyFrmTA811
      .TBarComments.Enabled = False
      .TBarNew.Enabled = True
      .TBarSave.Enabled = False
      .TBarDelete.Enabled = False
      .TBarHist.Enabled = False
      .TBarPrint.Enabled = False
      .TBarSettings.Enabled = True
      .TBarAttach.Enabled = False
      .TBarAttach.Text = "Attachments"
    End With
    MyFrmTA8111R.FormatGrid(True)
    MyFrmTA8111R.Show()

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    MyTXCOEA.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String

NextCC:
    If WrkAddMode And Not MyOpenCC Then
      WrkCCNo = NextControlCCNo()
    End If

    MyTXCOEA.GetOneRecordP(WrkCCNo)
    If WrkAddMode Then
      If Not MyTXCOEA.RecordNotFound Then
        GoTo NextCC
      End If
    End If

    If WrkAddMode Then
      If MyUtils.CnvSng(LblListNo.Text) = 0 Then
        WrkListNo = NextListNo(WrkYear, WrkType)
        LblListNo.Text = WrkListNo
      End If
    End If

    SetCResnTip()
    SetExem1Tip()
    SetExem2Tip()
    SetExem3Tip()
    SetExem4Tip()
    SetExem5Tip()

    WrkListNo = MyUtils.CnvSng(LblListNo.Text)
    WrkYear = MyUtils.CnvSng(LblYear.Text)
    MyTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
    If Not WrkAddMode Then
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MyTXCOEA.UpdateOneRecordP()
        If MyTXCOEA.ErrMsg <> "" Then
          WriteErrorLog(MyTXCOEA.ErrMsg)
          Exit Sub
        End If
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MyTXCOEA.AddOneRecordP()
        If MyTXCOEA.ErrMsg <> "" Then
          WriteErrorLog(MyTXCOEA.ErrMsg)
          Exit Sub
        End If
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    If Not MyTXINV.RecordNotFound Then
      MyTXINV.UpdateOneRecordP()
      If MyTXINV.ErrMsg <> "" Then
        WriteErrorLog(MyTXINV.ErrMsg)
        Exit Sub
      End If
    Else
      MyTXINV.AddOneRecordP()
      If MyTXINV.ErrMsg <> "" Then
        WriteErrorLog(MyTXINV.ErrMsg)
        Exit Sub
      End If
    End If

    If Trim(TxtSSNo.Text) <> "" Then
      With MyTXVCUS
        .GetOneRecordP(MyUtils.CnvSng(TxtSSNo.Text))
        If .RecordNotFound Then
          ._ADD1 = TxtAdd1.Text
          ._ADD2 = TxtAdd2.Text
          ._BUS = ""
          ._CITY = TxtCity.Text
          ._CHDATE = 0
          ._CONFID = "N"
          ._CUSTID = MyUtils.CnvSng(TxtSSNo.Text)
          ._DOB = 0
          ._NAME = TxtName.Text
          ._SEX = ""
          ._STATE = TxtState.Text
          If TxtZip4.Text = "" Then
            ._ZIPA = TxtZip5.Text
          Else
            ._ZIPA = TxtZip5.Text & "-" & TxtZip4.Text
          End If
          .AddOneRecordP()
        End If
      End With
    End If

    If Trim(TxtSS2.Text) <> "" Then
      With MyTXVCUS
        .GetOneRecordP(MyUtils.CnvSng(TxtSS2.Text))
        If .RecordNotFound Then
          ._ADD1 = TxtAdd1.Text
          ._ADD2 = TxtAdd2.Text
          ._BUS = ""
          ._CHDATE = MyUtils.SetDBDate(Date.Today)
          ._CITY = TxtCity.Text
          ._CONFID = "N"
          ._CUSTID = MyUtils.CnvSng(TxtSS2.Text)
          ._DOB = 0
          ._NAME = TxtSname.Text
          ._SEX = ""
          ._STATE = TxtState.Text
          If TxtZip4.Text = "" Then
            ._ZIPA = TxtZip5.Text
          Else
            ._ZIPA = TxtZip5.Text & "-" & TxtZip4.Text
          End If
          .AddOneRecordP()
        End If
      End With
    End If

    If Trim(TxtOid.Text) <> "" Then
      With MyTXVEH
        .GetOneRecordP(MyUtils.CnvSng(TxtOid.Text))
        If .RecordNotFound Then
          ._BODY = ""
          ._CHDATE = 0
          ._CLASS = MyUtils.CnvSng(TxtClass.Text)
          ._CLASSD = ""
          ._DADD1 = TxtAdd1.Text
          ._DADD2 = TxtAdd2.Text
          ._DCITY = TxtCity.Text
          ._DSTATE = TxtState.Text
          If TxtZip4.Text = "" Then
            ._DZIPA = TxtZip5.Text
          Else
            ._DZIPA = TxtZip5.Text & "-" & TxtZip4.Text
          End If
          ._ENDDT = 0
          ._PCUST = MyUtils.CnvSng(TxtSSNo.Text)
          ._REGNO = TxtReg.Text
          ._SCUST = MyUtils.CnvSng(TxtSS2.Text)
          ._STRDT = 0
          ._VEHID = MyUtils.CnvSng(TxtOid.Text)
          ._VMAKE = TxtMake.Text
          ._VMODEL = TxtModel.Text
          ._YEAR = MyUtils.CnvSng(TxtMVYear.Text)
          .AddOneRecordP()
        End If
      End With
    End If
    'Save to MSRP File
    With myTXMSRP
      .GetOneRecordP(Trim(TxtID.Text))
      ._OVMSRP = MyUtils.CnvSng(TxtOVMSRP.Text)
      ._OVSOURCE = TxtSource.Text
      If ChkComplete.Checked Then
        ._COMPLETE = "Y"
      Else
        ._COMPLETE = ""
      End If
      ._NONTAX = ""
      If .RecordNotFound Then
        ._VINNO = Trim(TxtID.Text)
        .AddOneRecordP()
      Else
        .UpdateOneRecordP()
      End If
    End With
    If WrkAddMode Then
      MsgBox("C/C number is " & WrkCCNo)
      PrtCert(WrkType)
    End If
    Me.Close()

  End Sub
  Public Sub ShowCCHist()
    MyFrmListCCHist = New FrmListCCHist
    MyFrmListCCHist.WrkListNo = WrkListNo
    MyFrmListCCHist.WrkType = WrkType
    MyFrmListCCHist.WrkYear = WrkYear
    MyFrmListCCHist.ShowDialog()
  End Sub
  Public Sub PrintData()
    PrtCert(WrkType)
  End Sub
  Private Sub MoveToFile()
    Dim WrkTXMVPCT As String()

    With MyTXCOEA
      ._CCNO = WrkCCNo
      ._LISTNo = WrkListNo
      ._YEAR = WrkYear
      ._TYPE = WrkType
      ._DIST = MyUtils.CnvSng(TxtDist.Text)
      ._NAME = TxtName.Text
      ._ASS1 = MyUtils.CnvSng(TxtAssmt1.Text)
      ._NEWMVC = MyUtils.CnvSng(TxtCRAssmt1.Text)
      ._C1MSCD = ""
      ._C1CSCD = ""
      WrkTXMVPCT = GetTXMVPCTL1("P", MyUtils.CnvSng(TxtPurchMonth.Text))
      If Mid(WrkTXMVPCT(1), 1, 1) <> "*" Then
        ._C1MPCD = WrkTXMVPCT(1)
      End If
      If MyUtils.CnvSng(TxtSaleMonth.Text) > 0 Then
        WrkTXMVPCT = GetTXMVPCTL1("S", MyUtils.CnvSng(TxtSaleMonth.Text))
        If Mid(WrkTXMVPCT(1), 1, 1) <> "*" Then
          ._C1MSCD = WrkTXMVPCT(1)
        End If
      End If
      If MyUtils.CnvSng(TxtCRAssmt1.Text) > 0 Then
        WrkTXMVPCT = GetTXMVPCTL1("C", MyUtils.CnvSng(TxtCRSaleMonth.Text))
        If Mid(WrkTXMVPCT(1), 1, 1) <> "*" Then
          ._C1CSCD = WrkTXMVPCT(1)
        End If
      End If
      ._EXCD1 = TxtExempt1.Text
      ._EX1 = MyUtils.CnvSng(TxtExam1.Text)
      ._EXCD2 = TxtExempt2.Text
      ._EX2 = MyUtils.CnvSng(TxtExam2.Text)
      ._EXCD3 = TxtExempt3.Text
      ._EX3 = MyUtils.CnvSng(TxtExam3.Text)
      ._EXCD4 = TxtExempt4.Text
      ._EX4 = MyUtils.CnvSng(TxtExam4.Text)
      ._EXCD5 = TxtExempt5.Text
      ._EX5 = MyUtils.CnvSng(TxtExam5.Text)
      ._CTXOV = "N"
      If ChkOver.Checked Then
        ._CTXOV = "Y"
      End If
      ._GRCHG = MyUtils.CnvSng(LblChgGross.Text)
      ._CGRS = MyUtils.CnvSng(LblNewGross.Text)
      ._CNETAS = MyUtils.CnvSng(LblNewNet.Text)
      ._CDATE = MyUtils.SetDBDate(LblCCDate.Text)
      ._RSNCD = TxtReason.Text
      'Reason Codes
      SetCResnTip()
      ._CDESC = TxtDesc.Text
      With MyTPAYMNT
        .In_ListNo = WrkListNo
        .In_Type = WrkType
        .In_Year = WrkYear
        .In_Dst = MyUtils.CnvSng(TxtDist.Text)
        .In_Phs = ""
        .In_TaxT = MyUtils.CnvSng(LblNewAmt.Text)
        ' added 9/20/23  using control file to check if Not to split using marks previous commented out code
        If MyNosb = True Then
          If MyTXINV._TAXT > 0 And MyTXINV._TAX2 = 0 Then
            .In_NoSbil = True
          End If
        End If

        .CalcPaySplit()
      End With
      ._CETAX = MyUtils.Round(MyTPAYMNT.Out_TaxT, 2)
      ._IMVIDNo = TxtID.Text
      ._PRF = Mid(MyUserID, 1, 10)
      ._CHDATE = MyUtils.SetDBDate(LblCCDate.Text)
      ._CHTIME = Format(DateTime.Now, "hhmmss")
    End With

    With MyTXINV
      ._LISTNo = WrkListNo
      ._YEAR = WrkYear
      ._TYPE = WrkType
      ._NAME = TxtName.Text
      ._LETT = Mid$(TxtName.Text, 1, 1)
      ._SNAME = TxtSname.Text
      ._ADD1 = TxtAdd1.Text
      ._ADD2 = TxtAdd2.Text
      ._CITY = TxtCity.Text
      ._STATE = TxtState.Text
      ._ZIP5 = MyUtils.CnvSng(TxtZip5.Text)
      ._ZIP4 = MyUtils.CnvSng(TxtZip4.Text)
      ._DIST = MyUtils.CnvSng(TxtDist.Text)
      ._IMVIDNo = TxtID.Text
      ._IMVREG = TxtReg.Text
      If Trim(._ASS) = "" Then
        ._ASS = Trim(MyTXCOEA._C1MPCD)
      End If
      ._CLASS = MyUtils.CnvSng(TxtClass.Text)
      ._MVYR = MyUtils.CnvSng(TxtMVYear.Text)
      ._MAKE = TxtMake.Text
      ._MODEL = TxtModel.Text
      ._SSNo = MyUtils.CnvSng(TxtSSNo.Text)
      ._SS2 = MyUtils.CnvSng(TxtSS2.Text)
      ._OID = TxtOid.Text
      ._CCNO = WrkCCNo
      ._CDATE = MyUtils.SetDBDate(LblCCDate.Text)
      ._CCETAX = MyUtils.Round(MyTPAYMNT.Out_TaxT, 2)
      ._CCTX1 = MyUtils.Round(MyTPAYMNT.Out_Tax1, 2)
      ._CCTX2 = MyUtils.Round(MyTPAYMNT.Out_Tax2, 2)
      ._CCTX3 = MyUtils.Round(MyTPAYMNT.Out_Tax3, 2)
      ._CCTX4 = MyUtils.Round(MyTPAYMNT.Out_Tax4, 2)
      ._CGRS = MyUtils.CnvSng(LblNewGross.Text)
      ._CCEXP = MyUtils.CnvSng(LblNewExam.Text)
      ._CCRSN = TxtReason.Text
      ._BALD = MyUtils.CnvSng(LblNewAmt.Text) - ._PAYREC
      ._CASS1 = MyUtils.CnvSng(TxtAssmt1.Text)
      ._CCCD1 = TxtExempt1.Text
      ._CCCD2 = TxtExempt2.Text
      ._CCCD3 = TxtExempt3.Text
      ._CCCD4 = TxtExempt4.Text
      ._CCCD5 = TxtExempt5.Text
      ._CEXA1 = MyUtils.CnvSng(TxtExam1.Text)
      ._CEXA2 = MyUtils.CnvSng(TxtExam2.Text)
      ._CEXA3 = MyUtils.CnvSng(TxtExam3.Text)
      ._CEXA4 = MyUtils.CnvSng(TxtExam4.Text)
      ._CEXA5 = MyUtils.CnvSng(TxtExam5.Text)
      If Trim(._ICVACD) = "" Then
        ._ICVACD = Trim(MyTXCOEA._C1CSCD)
      End If
      ._ICVGRS = MyUtils.CnvSng(TxtCRAssmt1.Text)
      ._ICVIDNo = TxtCRID.Text
      ._ICVREG = TXTCRReg.Text
      ._ICVCLS = MyUtils.CnvSng(TxtCRClass.Text)
      ._ICVYR = MyUtils.CnvSng(TXTCRMVYear.Text)
      ._ICVMKE = TxtCRMake.Text
      ._ICVMOD = TxtCRModel.Text
      ._ETC1 = "2"
    End With


  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtName, "")
    ErrProv.SetError(TxtReason, "")
    ErrProv.SetError(LblNewAmt, "")
    ErrProv.SetError(TxtExempt1, "")
    ErrProv.SetError(TxtExempt2, "")
    ErrProv.SetError(TxtExempt3, "")
    ErrProv.SetError(TxtExempt4, "")
    ErrProv.SetError(TxtExempt5, "")
    ErrProv.SetError(LblNewNet, "")
    ErrProv.SetError(LblAdjNet, "")
    ErrProv.SetError(TxtPurchMonth, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
        Case "name"
          ErrProv.SetError(TxtName, ErrorMsg(I))
        Case "rsncd"
          ErrProv.SetError(TxtReason, ErrorMsg(I))
        Case "cetax"
          ErrProv.SetError(LblNewAmt, ErrorMsg(I))
        Case "excd1"
          ErrProv.SetError(TxtExempt1, ErrorMsg(I))
        Case "excd2"
          ErrProv.SetError(TxtExempt2, ErrorMsg(I))
        Case "excd3"
          ErrProv.SetError(TxtExempt3, ErrorMsg(I))
        Case "excd4"
          ErrProv.SetError(TxtExempt4, ErrorMsg(I))
        Case "excd5"
          ErrProv.SetError(TxtExempt5, ErrorMsg(I))
        Case "net"
          ErrProv.SetError(LblNewNet, ErrorMsg(I))
        Case "adjnet"
          ErrProv.SetError(LblAdjNet, ErrorMsg(I))
        Case "purch"
          ErrProv.SetError(TxtPurchMonth, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim WrkTip As String
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtExempt1.Text <> "" Then
      WrkTip = Ttp1.GetToolTip(TxtExempt1)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "excd1"
        ErrorMsg(I) = "Invalid Exemption Code"
        I = I + 1
      End If
    End If

    If TxtExempt2.Text <> "" Then
      WrkTip = Ttp1.GetToolTip(TxtExempt2)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "excd2"
        ErrorMsg(I) = "Invalid Exemption Code"
        I = I + 1
      End If
    End If

    If TxtExempt3.Text <> "" Then
      WrkTip = Ttp1.GetToolTip(TxtExempt3)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "excd3"
        ErrorMsg(I) = "Invalid Exemption Code"
        I = I + 1
      End If
    End If

    If TxtExempt4.Text <> "" Then
      WrkTip = Ttp1.GetToolTip(TxtExempt4)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "excd4"
        ErrorMsg(I) = "Invalid Exemption Code"
        I = I + 1
      End If
    End If

    If TxtExempt5.Text <> "" Then
      WrkTip = Ttp1.GetToolTip(TxtExempt5)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "excd5"
        ErrorMsg(I) = "Invalid Exemption Code"
        I = I + 1
      End If
    End If

    WrkTip = Ttp1.GetToolTip(TxtReason)
    If Mid(WrkTip, 1, 1) = "*" Then
      ErrorField(I) = "rsncd"
      ErrorMsg(I) = "Invalid Reason Code"
      I = I + 1
    End If

    If TxtReason.Text = "" Then
      ErrorField(I) = "rsncd"
      ErrorMsg(I) = "Reason Code is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(LblNewNet.Text) < 0 Then
      ErrorField(I) = "net"
      ErrorMsg(I) = "Net Assessment cannot be negative"
      I = I + 1
    End If

    If MyUtils.CnvSng(LblAdjNet.Text) < 0 Then
      ErrorField(I) = "adjnet"
      ErrorMsg(I) = "Adjusted Net cannot be negative"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtPurchMonth.Text) = 0 Then
      ErrorField(I) = "purch"
      ErrorMsg(I) = "Purchase Month is required"
      I = I + 1
    End If
  End Sub
  Private Sub FrmTA8115R_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA811.SbpScreen.Text = "TA8115R"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub TxtAssmt1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAssmt1.TextChanged
    Dim WrkProrate As Integer
    Dim WrkAdjNet As Integer
    Dim WrkPct As Single
    Dim WrkCode As String

    WrkCode = ""
    If Not TxtAssmt1.Modified Then Exit Sub
    CalcProrateMonth("P", MyUtils.CnvSng(TxtPurchMonth.Text), MyUtils.CnvSng(TxtAssmt1.Text), WrkProrate, WrkAdjNet, WrkPct, WrkCode)
    LblPurchPct.Text = WrkPct
    LblPurchNet.Text = WrkAdjNet
    If MyUtils.CnvSng(TxtSaleMonth.Text) > 0 Then
      CalcProrateMonth("S", MyUtils.CnvSng(TxtSaleMonth.Text), MyUtils.CnvSng(TxtAssmt1.Text), WrkProrate, WrkAdjNet, WrkPct, WrkCode)
      LblSalePct.Text = WrkPct
      LblSaleNet.Text = WrkAdjNet
    End If
    LblAdjNet.Text = MyUtils.CnvSng(LblPurchNet.Text) - MyUtils.CnvSng(LblSaleNet.Text) - MyUtils.CnvSng(LblCRSaleNet.Text)
    CalcChg()
  End Sub
  Private Sub TxtCRAssmt1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCRAssmt1.TextChanged
    Dim WrkProrate As Integer
    Dim WrkAdjNet As Integer
    Dim WrkPct As Single
    Dim WrkCode As String

    WrkCode = ""
    If Not TxtCRAssmt1.Modified Then Exit Sub
    CalcProrateMonth("C", MyUtils.CnvSng(TxtCRSaleMonth.Text), MyUtils.CnvSng(TxtCRAssmt1.Text), WrkProrate, WrkAdjNet, WrkPct, WrkCode)
    LblCRSalePct.Text = WrkPct
    LblCRSaleNet.Text = WrkAdjNet
    LblAdjNet.Text = MyUtils.CnvSng(LblPurchNet.Text) - MyUtils.CnvSng(LblSaleNet.Text) - MyUtils.CnvSng(LblCRSaleNet.Text)
    CalcChg()

  End Sub
  Private Sub TxtExam1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam1.TextChanged
    If Not TxtExam1.Modified Then Exit Sub
    CalcChg()
  End Sub
  Private Sub TxtExam2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam2.TextChanged
    If Not TxtExam2.Modified Then Exit Sub
    CalcChg()
  End Sub
  Private Sub TxtExam3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam3.TextChanged
    If Not TxtExam3.Modified Then Exit Sub
    CalcChg()
  End Sub
  Private Sub TxtExam4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam4.TextChanged
    If Not TxtExam4.Modified Then Exit Sub
    CalcChg()
  End Sub
  Private Sub TxtExam5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam5.TextChanged
    If Not TxtExam5.Modified Then Exit Sub
    CalcChg()
  End Sub
  Private Sub LnkExempt1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt1.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt1.Text
    MyFrmListExemption.WrkCode = TxtExempt1.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt2.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt2.Text
    MyFrmListExemption.WrkCode = TxtExempt2.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt3.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt3.Text
    MyFrmListExemption.WrkCode = TxtExempt3.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt4.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt4.Text
    MyFrmListExemption.WrkCode = TxtExempt4.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt5.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt5.Text
    MyFrmListExemption.WrkCode = TxtExempt5.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub TxtExempt1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt1.TextChanged
    Dim WrkTxExem As String()

    If LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt1.Text)
    TxtExam1.Text = WrkTxExem(0)
    CalcChg()

  End Sub
  Private Sub TxtExempt2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt2.TextChanged
    Dim WrkTxExem As String()

    If LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt2.Text)
    TxtExam2.Text = WrkTxExem(0)
    CalcChg()
  End Sub
  Private Sub TxtExempt3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt3.TextChanged
    Dim WrkTxExem As String()

    If LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt3.Text)
    TxtExam3.Text = WrkTxExem(0)
    CalcChg()
  End Sub
  Private Sub TxtExempt4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt4.TextChanged
    Dim WrkTxExem As String()

    If LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt4.Text)
    TxtExam4.Text = WrkTxExem(0)
    CalcChg()
  End Sub
  Private Sub TxtExempt5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt5.TextChanged
    Dim WrkTxExem As String()

    If LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt5.Text)
    TxtExam5.Text = WrkTxExem(0)
    CalcChg()
  End Sub
  Private Sub TxtExempt1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtExempt1.Leave
    SetExem1Tip()
  End Sub
  Private Sub TxtExempt2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtExempt2.Leave
    SetExem2Tip()
  End Sub
  Private Sub TxtExempt3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtExempt3.Leave
    SetExem3Tip()
  End Sub
  Private Sub TxtExempt4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtExempt4.Leave
    SetExem4Tip()
  End Sub
  Private Sub TxtExempt5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtExempt5.Leave
    SetExem5Tip()
  End Sub
  Private Sub SetExem1Tip()
    Dim WrkTxExem As String()

    If Not TxtExempt1.Modified And Not LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt1.Text)
    Ttp1.SetToolTip(TxtExempt1, WrkTxExem(1))
  End Sub
  Private Sub SetExem2Tip()
    Dim WrkTxExem As String()

    If Not TxtExempt2.Modified And Not LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt2.Text)
    Ttp1.SetToolTip(TxtExempt2, WrkTxExem(1))
  End Sub
  Private Sub SetExem3Tip()
    Dim WrkTxExem As String()

    If Not TxtExempt3.Modified And Not LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt3.Text)
    Ttp1.SetToolTip(TxtExempt3, WrkTxExem(1))
  End Sub
  Private Sub SetExem4Tip()
    Dim WrkTxExem As String()

    If Not TxtExempt4.Modified And Not LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt4.Text)
    Ttp1.SetToolTip(TxtExempt4, WrkTxExem(1))
  End Sub
  Private Sub SetExem5Tip()
    Dim WrkTxExem As String()

    If Not TxtExempt5.Modified And Not LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt5.Text)
    Ttp1.SetToolTip(TxtExempt5, WrkTxExem(1))
  End Sub
  Private Sub SetCResnTip()
    Dim WrkDesc As String

    If Not TxtReason.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCResnDesc(TxtReason.Text)
    Ttp1.SetToolTip(TxtReason, WrkDesc)
  End Sub
  Public Sub GetTxCOEA()
    Dim WrkProrate As Integer
    Dim WrkAdjNet As Integer
    Dim WrkPct As Single
    Dim WrkMonth As Integer

    With MyTXCOEA
      If WrkListNo = 0 Then
        WrkListNo = ._LISTNo
        WrkYear = ._YEAR
        WrkType = ._TYPE
      End If
      WrkDist = ._DIST
      LblListNo.Text = ._LISTNo
      LblYear.Text = ._YEAR
      LblType.Text = ._TYPE
      LblCCDate.Text = MyUtils.GetDBDate(._CDATE)
      TxtName.Text = Trim(._NAME)
      TxtDist.Text = ._DIST
      LblNewGross.Text = FormatNumber(._CGRS, 0)
      LblNewExam.Text = FormatNumber(._EX1 + ._EX2 + ._EX3 +
          ._EX4 + ._EX5, 0)
      LblNewNet.Text = FormatNumber(MyUtils.CnvSng(LblNewGross.Text) - MyUtils.CnvSng(LblNewExam.Text), 0)
      TxtReason.Text = Trim(._RSNCD)
      TxtDesc.Text = Trim(._CDESC)
      TxtOverAmt.Enabled = False
      If Trim(._CTXOV) = "Y" Then
        ChkOver.Checked = True
        TxtOverAmt.Enabled = True
        TxtOverAmt.Text = MyUtils.FmtCurrency(._CETAX)
      End If
      TxtAssmt1.Text = ._CGRS
      TxtCRAssmt1.Text = ._NEWMVC
      CalcProrateCode("P", Trim(._C1MPCD), ._CGRS, WrkProrate, WrkAdjNet, WrkPct, WrkMonth)
      TxtPurchMonth.Text = WrkMonth
      LblPurchPct.Text = WrkPct
      LblPurchNet.Text = WrkAdjNet
      CalcProrateCode("S", Trim(._C1MSCD), ._CGRS, WrkProrate, WrkAdjNet, WrkPct, WrkMonth)
      TxtSaleMonth.Text = WrkMonth
      LblSalePct.Text = WrkPct
      LblSaleNet.Text = WrkAdjNet
      'Check for Credit Vehicle Gross
      If Trim(._C1CSCD) <> "" Then
        CalcProrateCode("C", Trim(._C1CSCD), ._NEWMVC, WrkProrate, WrkAdjNet, WrkPct, WrkMonth)
        TxtCRSaleMonth.Text = WrkMonth
        LblCRSalePct.Text = WrkPct
        LblCRSaleNet.Text = WrkAdjNet
      End If
      LblAdjNet.Text = MyUtils.CnvSng(LblPurchNet.Text) - MyUtils.CnvSng(LblSaleNet.Text) - MyUtils.CnvSng(LblCRSaleNet.Text)
      'Exemption Codes
      TxtExempt1.Text = Trim(._EXCD1)
      TxtExempt2.Text = Trim(._EXCD2)
      TxtExempt3.Text = Trim(._EXCD3)
      TxtExempt4.Text = Trim(._EXCD4)
      TxtExempt5.Text = Trim(._EXCD5)
      SetExem1Tip()
      SetExem2Tip()
      SetExem3Tip()
      SetExem4Tip()
      SetExem5Tip()
      TxtExam1.Text = ._EX1
      TxtExam2.Text = ._EX2
      TxtExam3.Text = ._EX3
      TxtExam4.Text = ._EX4
      TxtExam5.Text = ._EX5
      EntryDate = MyUtils.GetDBDate(._CHDATE)
    End With
  End Sub

  Public Sub GetOrigTxCOEA(ByVal WrkCCNo As Integer)
    Dim MyorigTXCOEA As TXCOEA.MyData
    Dim WrkProrate As Integer
    Dim WrkPurchNet As Integer
    Dim WrkSaleNet As Integer
    Dim WrkCRSaleNet As Integer
    Dim WrkPct As Single
    Dim WrkMonth As Integer

    MyorigTXCOEA = New TXCOEA.MyData(myDBConnect)
    MyorigTXCOEA.GetOneRecordP(WrkCCNo)
    If Not MyorigTXCOEA.RecordNotFound Then
      With MyorigTXCOEA
        LblOrig.Text = "C/C " & Str$(WrkCCNo)
        LblOrig.ForeColor = Color.Fuchsia
        LblOrigGross.Text = FormatNumber(._CGRS, 0)
        CalcProrateCode("P", Trim(._C1MPCD), ._CGRS, WrkProrate, WrkPurchNet, WrkPct, WrkMonth)
        If MyUtils.CnvSng(TxtPurchMonth.Text) = 0 Then
          TxtPurchMonth.Text = WrkMonth
          LblPurchPct.Text = WrkPct
          LblPurchNet.Text = WrkPurchNet
        End If
        CalcProrateCode("S", Trim(._C1MSCD), ._CGRS, WrkProrate, WrkSaleNet, WrkPct, WrkMonth)
        If MyUtils.CnvSng(TxtSaleMonth.Text) = 0 Then
          TxtSaleMonth.Text = WrkMonth
          LblSalePct.Text = WrkPct
          LblSaleNet.Text = WrkSaleNet
        End If
        'Check for Credit Vehicle Gross
        If Trim(._C1CSCD) <> "" Then
          CalcProrateCode("C", Trim(._C1CSCD), ._NEWMVC, WrkProrate, WrkCRSaleNet, WrkPct, WrkMonth)
          If MyUtils.CnvSng(TxtCRSaleMonth.Text) = 0 Then
            TxtCRSaleMonth.Text = WrkMonth
            LblCRSalePct.Text = WrkPct
            LblCRSaleNet.Text = WrkCRSaleNet
            LblOrigAdjGross.Text = FormatNumber(WrkCRSaleNet, 0)
          End If
        End If
        LblOrigProrate.Text = FormatNumber(._CGRS - (WrkPurchNet - WrkSaleNet), 0)
        LblOrigAdjGross.Text = WrkCRSaleNet
        LblOrigExam.Text = FormatNumber(._EX1 + ._EX2 + ._EX3 +
        ._EX4 + ._EX5, 0)
        LblOrigNet.Text = FormatNumber(MyUtils.CnvSng(LblOrigGross.Text) - MyUtils.CnvSng(LblOrigExam.Text) - MyUtils.CnvSng(LblOrigProrate.Text) - MyUtils.CnvSng(LblOrigAdjGross.Text), 0)
        LblOrigAmt.Text = MyUtils.FmtCurrency(._CETAX)
        LblOrigAssmt1.Text = ._CGRS
        LblAdjNet.Text = MyUtils.CnvSng(LblPurchNet.Text) - MyUtils.CnvSng(LblSaleNet.Text) - MyUtils.CnvSng(LblCRSaleNet.Text)
        'Exemption Codes
        TxtExempt1.Text = Trim(._EXCD1)
        TxtExempt2.Text = Trim(._EXCD2)
        TxtExempt3.Text = Trim(._EXCD3)
        TxtExempt4.Text = Trim(._EXCD4)
        TxtExempt5.Text = Trim(._EXCD5)
        SetExem1Tip()
        SetExem2Tip()
        SetExem3Tip()
        SetExem4Tip()
        SetExem5Tip()
        LblOrigExam1.Text = ._EX1
        LblOrigExam2.Text = ._EX2
        LblOrigExam3.Text = ._EX3
        LblOrigExam4.Text = ._EX4
        LblOrigExam5.Text = ._EX5
      End With
    End If

  End Sub
  Sub CalcChg()
    Dim WrkAdjGross As Integer
    Dim WrkNet As Integer
    Dim WrkNewAmt As Decimal
    If LoadScrn Then Exit Sub

    LblNewGross.Text = FormatNumber(MyUtils.CnvSng(TxtAssmt1.Text), 0)
    LblNewProrate.Text = FormatNumber(MyUtils.CnvSng(TxtAssmt1.Text) - MyUtils.CnvSng(LblPurchNet.Text) +
    MyUtils.CnvSng(LblSaleNet.Text), 0)
    LblNewExam.Text = FormatNumber(MyUtils.CnvSng(TxtExam1.Text) + MyUtils.CnvSng(TxtExam2.Text) + MyUtils.CnvSng(TxtExam3.Text) +
    MyUtils.CnvSng(TxtExam4.Text) + MyUtils.CnvSng(TxtExam5.Text), 0)
    WrkAdjGross = MyUtils.CnvSng(LblCRSaleNet.Text)
    If WrkAdjGross > MyUtils.CnvSng(LblPurchNet.Text) - MyUtils.CnvSng(LblSaleNet.Text) Then
      WrkAdjGross = MyUtils.CnvSng(LblPurchNet.Text) - MyUtils.CnvSng(LblSaleNet.Text)
    End If
    LblNewAdjGross.Text = FormatNumber(WrkAdjGross, 0)
    WrkNet = MyUtils.CnvSng(LblNewGross.Text) - MyUtils.CnvSng(LblNewProrate.Text) - MyUtils.CnvSng(LblNewExam.Text) - WrkAdjGross
    LblNewNet.Text = FormatNumber(WrkNet, 0)
    If ChkOver.Checked Then
      WrkNewAmt = MyUtils.CnvSng(TxtOverAmt.Text)
    Else
      WrkNewAmt = MyUtils.CnvSng(LblNewNet.Text) * MyUtils.CnvSng(LblMRate.Text)
    End If

    With MyTPAYMNT
      .In_ListNo = WrkListNo
      .In_Type = WrkType
      .In_Year = WrkYear
      .In_Dst = MyUtils.CnvSng(TxtDist.Text)
      .In_Phs = ""
      If ChkOver.Checked Then
        .In_TaxT = MyUtils.CnvSng(TxtOverAmt.Text)
      Else
        .In_TaxT = MyUtils.Round(WrkNewAmt, 2)
      End If
      .CalcPaySplit()
      LblNewAmt.Text = MyUtils.FmtCurrency(.Out_TaxT)
    End With

    LblChgGross.Text = FormatNumber(MyUtils.CnvSng(LblNewGross.Text) - MyUtils.CnvSng(LblOrigGross.Text), 0)
    LblChgExam.Text = FormatNumber(MyUtils.CnvSng(LblNewExam.Text) - MyUtils.CnvSng(LblOrigExam.Text), 0)
    LblChgProrate.Text = FormatNumber(MyUtils.CnvSng(LblNewProrate.Text) - MyUtils.CnvSng(LblOrigProrate.Text), 0)
    LblChgAdjGross.Text = FormatNumber(MyUtils.CnvSng(LblNewAdjGross.Text) - MyUtils.CnvSng(LblOrigAdjGross.Text), 0)
    LblChgNet.Text = FormatNumber(MyUtils.CnvSng(LblNewNet.Text) - MyUtils.CnvSng(LblOrigNet.Text), 0)
    LblChgAmt.Text = MyUtils.FmtCurrency(MyUtils.CnvSng(LblNewAmt.Text) - MyUtils.CnvSng(LblOrigAmt.Text))
    LblChgAssmt1.Text = MyUtils.CnvSng(TxtAssmt1.Text) - MyUtils.CnvSng(LblOrigAssmt1.Text)
    LblChgCRAssmt1.Text = MyUtils.CnvSng(TxtCRAssmt1.Text) - MyUtils.CnvSng(LblOrigCRAssmt1.Text)
    LblChgExam1.Text = MyUtils.CnvSng(TxtExam1.Text) - MyUtils.CnvSng(LblOrigExam1.Text)
    LblChgExam2.Text = MyUtils.CnvSng(TxtExam2.Text) - MyUtils.CnvSng(LblOrigExam2.Text)
    LblChgExam3.Text = MyUtils.CnvSng(TxtExam3.Text) - MyUtils.CnvSng(LblOrigExam3.Text)
    LblChgExam4.Text = MyUtils.CnvSng(TxtExam4.Text) - MyUtils.CnvSng(LblOrigExam4.Text)
    LblChgExam5.Text = MyUtils.CnvSng(TxtExam5.Text) - MyUtils.CnvSng(LblOrigExam5.Text)
  End Sub
  Public Sub CalcProrateMonth(ByVal In_Type As String, ByVal In_SaleMonth As Integer,
    ByVal In_Value As Integer, ByRef Out_Prorate As Integer, ByRef Out_AdjNet As Integer,
    ByRef Out_Pct As Single, ByRef Out_SaleCode As String)

    Dim WrkTxMVPCT As String()

    WrkTxMVPCT = GetTXMVPCTL1(In_Type, In_SaleMonth)
    Out_SaleCode = WrkTxMVPCT(1)
    Out_Pct = MyUtils.CnvSng(WrkTxMVPCT(0))
    If MyProrateRound Then
      Out_AdjNet = MyUtils.Round10(In_Value * Out_Pct, "Normal")
    Else
      Out_AdjNet = MyUtils.Round(In_Value * Out_Pct, 0)
    End If
    Out_Prorate = In_Value - Out_AdjNet
  End Sub
  Public Sub CalcProrateCode(ByVal In_Type As String, ByVal In_SaleCode As String,
    ByVal In_Value As Integer, ByRef Out_Prorate As Integer, ByRef Out_AdjNet As Integer,
    ByRef Out_Pct As Single, ByRef Out_SaleMonth As Integer)

    Dim WrkTxMVPCT As String()

    WrkTxMVPCT = GetTXMVPCT(In_Type, In_SaleCode)
    Out_SaleMonth = MyUtils.CnvSng(WrkTxMVPCT(1))
    Out_Pct = MyUtils.CnvSng(WrkTxMVPCT(0))
    If MyProrateRound Then
      Out_AdjNet = MyUtils.Round10(In_Value * Out_Pct, "Normal")
    Else
      Out_AdjNet = MyUtils.Round(In_Value * Out_Pct, 0)
    End If
    Out_Prorate = In_Value - Out_AdjNet
  End Sub
  Private Sub LnkReason_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkReason.LinkClicked
    MyFrmListCResn = New FrmListCResn
    MyFrmListCResn.MdiParent = Me.ParentForm
    MyFrmListCResn.WrkType = WrkType
    MyFrmListCResn.WrkCode = TxtReason.Text
    MyFrmListCResn.Show()
  End Sub
  Private Sub TxtOverAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOverAmt.TextChanged
    Call CalcChg()
  End Sub
  Private Sub TxtSaleMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSaleMonth.TextChanged
    CalcSale()
  End Sub
  Private Sub TxtPurchMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPurchMonth.TextChanged
    If Not TxtPurchMonth.Modified Then Exit Sub

    CalcPurch()
  End Sub

  Private Sub TxtCRSaleMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCRSaleMonth.TextChanged
    If Not TxtCRSaleMonth.Modified Then Exit Sub

    CalcSaleCR()
  End Sub
  Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtZip5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZip5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtZip4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZip4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAssmt1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAssmt1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCRAssmt1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCRAssmt1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtExam1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtExam1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtExam2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtExam2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtExam3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtExam3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtExam4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtExam4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtExam5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtExam5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtClass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClass.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtMVYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMVYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtPurchMonth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPurchMonth.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSaleMonth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSaleMonth.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtOverAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOverAmt.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub LnkClass_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkClass.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkFamily = WrkFamily
    MyFrmListCodes.WrkFieldNo = 1
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtClass.Text)
    MyFrmListCodes.Show()
  End Sub

  Private Sub LnkCRClass_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCRClass.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkFamily = WrkFamily
    MyFrmListCodes.WrkFieldNo = 2
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCRClass.Text)
    MyFrmListCodes.Show()
  End Sub

  Private Sub LnkPurchMonth_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkPurchMonth.LinkClicked
    MyFrmListMvpct = New FrmListMvpct
    MyFrmListMvpct.MdiParent = Me.ParentForm
    MyFrmListMvpct.WrkType = "P"
    MyFrmListMvpct.Show()
  End Sub
  Private Sub LnkSaleMonth_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkSaleMonth.LinkClicked
    MyFrmListMvpct = New FrmListMvpct
    MyFrmListMvpct.MdiParent = Me.ParentForm
    MyFrmListMvpct.WrkType = "S"
    MyFrmListMvpct.Show()
  End Sub
  Private Sub LnkCRSaleMonth_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCRSaleMonth.LinkClicked
    MyFrmListMvpct = New FrmListMvpct
    MyFrmListMvpct.MdiParent = Me.ParentForm
    MyFrmListMvpct.WrkType = "C"
    MyFrmListMvpct.Show()
  End Sub
  Public Sub CalcPurch()
    Dim WrkProrate As Integer
    Dim WrkAdjNet As Integer
    Dim WrkCode As String
    Dim WrkPct As Single

    WrkCode = ""
    CalcProrateMonth("P", MyUtils.CnvSng(TxtPurchMonth.Text), MyUtils.CnvSng(TxtAssmt1.Text), WrkProrate, WrkAdjNet, WrkPct, WrkCode)
    LblPurchPct.Text = FormatNumber(WrkPct, 3)
    LblPurchNet.Text = WrkAdjNet
    LblAdjNet.Text = MyUtils.CnvSng(LblPurchNet.Text) - MyUtils.CnvSng(LblSaleNet.Text) - MyUtils.CnvSng(LblCRSaleNet.Text)
    CalcChg()
  End Sub
  Public Sub CalcSale()
    Dim WrkProrate As Integer
    Dim WrkAdjNet As Integer
    Dim WrkPct As Single
    Dim WrkCode As String

    WrkCode = ""
    CalcProrateMonth("S", MyUtils.CnvSng(TxtSaleMonth.Text), MyUtils.CnvSng(TxtAssmt1.Text), WrkProrate, WrkAdjNet, WrkPct, WrkCode)
    LblSalePct.Text = FormatNumber(WrkPct, 3)
    LblSaleNet.Text = WrkAdjNet
    LblAdjNet.Text = MyUtils.CnvSng(LblPurchNet.Text) - MyUtils.CnvSng(LblSaleNet.Text) - MyUtils.CnvSng(LblCRSaleNet.Text)
    CalcChg()
  End Sub
  Public Sub CalcSaleCR()
    Dim WrkProrate As Integer
    Dim WrkAdjNet As Integer
    Dim WrkPct As Single
    Dim WrkCode As String

    WrkCode = ""
    CalcProrateMonth("C", MyUtils.CnvSng(TxtCRSaleMonth.Text), MyUtils.CnvSng(TxtCRAssmt1.Text), WrkProrate, WrkAdjNet, WrkPct, WrkCode)
    LblCRSalePct.Text = FormatNumber(WrkPct, 3)
    LblCRSaleNet.Text = WrkAdjNet
    LblAdjNet.Text = MyUtils.CnvSng(LblPurchNet.Text) - MyUtils.CnvSng(LblSaleNet.Text) - MyUtils.CnvSng(LblCRSaleNet.Text)
    CalcChg()
  End Sub
  Private Sub TxtSSNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSSNo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSS2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSS2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtOid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtOid.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub BtnPriceDigest_Click(sender As Object, e As EventArgs) Handles BtnPriceDigest.Click
    myPriceDigestVIN = New PriceDigestAPI.ApiVIN
    myPriceDigestValue = New PriceDigestAPI.ApiValue
    myPriceDigestSpecs = New PriceDigestAPI.ApiSpecs
    LblPDMsg.Text = ""
    With myPriceDigestVIN
      .GetApiVIN(TxtID.Text)
      If MyUtils.CnvSng(TxtMVYear.Text) <> .modelYear Then 'If Vehicle year don't match it's an error
        .IsError = True
      End If
      If .IsError Then
        LblPDMsg.Text = "** No Data **"
        Exit Sub
      End If
    End With
    With myPriceDigestValue
      .GetApiValue(myPriceDigestVIN.configurationId)
      TxtOVMSRP.Text = .MSRP
      TxtSource.Text = "P"
    End With
    With myPriceDigestSpecs
      .GetApiSpecs(myPriceDigestVIN.configurationId)
      If Not ChkComplete.Checked And .Complete = "Y" Then
        ChkComplete.Checked = True
      End If
    End With
    TxtOVMSRP.Focus()
  End Sub

  Private Sub BtnCRPriceDigest_Click(sender As Object, e As EventArgs) Handles BtnCRPriceDigest.Click
    myPriceDigestVIN = New PriceDigestAPI.ApiVIN
    myPriceDigestValue = New PriceDigestAPI.ApiValue
    myPriceDigestSpecs = New PriceDigestAPI.ApiSpecs
    LblCRPDMsg.Text = ""
    With myPriceDigestVIN
      .GetApiVIN(TxtCRID.Text)
      If MyUtils.CnvSng(TXTCRMVYear.Text) <> .modelYear Then 'If Vehicle year don't match it's an error
        .IsError = True
      End If
      If .IsError Then
        LblCRPDMsg.Text = "** No Data **"
        Exit Sub
      End If
    End With
    With myPriceDigestValue
      .GetApiValue(myPriceDigestVIN.configurationId)
      TxtCROVMSRP.Text = .MSRP
      TxtCRSource.Text = "P"
    End With
    With myPriceDigestSpecs
      .GetApiSpecs(myPriceDigestVIN.configurationId)
      If Not ChkCRComplete.Checked And .Complete = "Y" Then
        ChkCRComplete.Checked = True
      End If
    End With
    TxtCROVMSRP.Focus()
  End Sub
  Private Sub LnkSource_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkSource.LinkClicked
    MyFrmListSource = New FrmListSource
    MyFrmListSource.MdiParent = Me.ParentForm
    MyFrmListSource.WrkScreen = "SU"
    MyFrmListSource.WrkField = ""
    MyFrmListSource.WrkCode = TxtSource.Text
    MyFrmListSource.Show()
  End Sub
  Private Sub LnkCRSource_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkCRSource.LinkClicked
    MyFrmListSource = New FrmListSource
    MyFrmListSource.MdiParent = Me.ParentForm
    MyFrmListSource.WrkScreen = "SU"
    MyFrmListSource.WrkField = "CR"
    MyFrmListSource.WrkCode = TxtCRSource.Text
    MyFrmListSource.Show()
  End Sub
  Private Sub TxtOVMSRP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOVMSRP.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCROVMSRP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCROVMSRP.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtOVMSRP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOVMSRP.TextChanged
    Dim WrkMSRP As Integer
    Dim WrkOvMSRP As Integer
    Dim WrkMVYear As Integer
    Dim WrkValue As Integer
    Dim WrkProrate As Integer
    Dim WrkAdjNet As Integer
    Dim WrkPct As Double
    Dim WrkCode As String

    WrkMSRP = MyUtils.CnvSng(LblMSRP.Text)
    WrkOvMSRP = MyUtils.CnvSng(TxtOVMSRP.Text)
    WrkMVYear = MyUtils.CnvSng(TxtMVYear.Text)
    WrkValue = CalcValue(WrkMSRP, WrkOvMSRP, WrkMVYear)
    LblValue.Text = MyUtils.Round10(WrkValue, "Normal")
    If Not LoadScrn Then
      TxtAssmt1.Text = MyUtils.CnvSng(LblValue.Text)
    End If

    WrkCode = ""
    CalcProrateMonth("P", MyUtils.CnvSng(TxtPurchMonth.Text), MyUtils.CnvSng(TxtAssmt1.Text), WrkProrate, WrkAdjNet, WrkPct, WrkCode)
    LblPurchPct.Text = FormatNumber(WrkPct, 3)
    LblPurchNet.Text = WrkAdjNet
    LblAdjNet.Text = MyUtils.CnvSng(LblPurchNet.Text) - MyUtils.CnvSng(LblSaleNet.Text) - MyUtils.CnvSng(LblCRSaleNet.Text)
    WrkCode = ""
    CalcProrateMonth("S", MyUtils.CnvSng(TxtSaleMonth.Text), MyUtils.CnvSng(TxtAssmt1.Text), WrkProrate, WrkAdjNet, WrkPct, WrkCode)
    LblSalePct.Text = FormatNumber(WrkPct, 3)
    LblSaleNet.Text = WrkAdjNet
    LblAdjNet.Text = MyUtils.CnvSng(LblPurchNet.Text) - MyUtils.CnvSng(LblSaleNet.Text) - MyUtils.CnvSng(LblCRSaleNet.Text)
    WrkCode = ""
    CalcProrateMonth("C", MyUtils.CnvSng(TxtCRSaleMonth.Text), MyUtils.CnvSng(TxtCRAssmt1.Text), WrkProrate, WrkAdjNet, WrkPct, WrkCode)
    LblCRSalePct.Text = FormatNumber(WrkPct, 3)
    LblCRSaleNet.Text = WrkAdjNet
    LblAdjNet.Text = MyUtils.CnvSng(LblPurchNet.Text) - MyUtils.CnvSng(LblSaleNet.Text) - MyUtils.CnvSng(LblCRSaleNet.Text)
    CalcChg()
  End Sub
  Private Sub TxtCROVMSRP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCROVMSRP.TextChanged
    Dim WrkMSRP As Integer
    Dim WrkOvMSRP As Integer
    Dim WrkMVYear As Integer
    Dim WrkValue As Integer
    Dim WrkProrate As Integer
    Dim WrkAdjNet As Integer
    Dim WrkPct As Double
    Dim WrkCode As String
    WrkMSRP = MyUtils.CnvSng(LblCRMSRP.Text)
    WrkOvMSRP = MyUtils.CnvSng(TxtCROVMSRP.Text)
    WrkMVYear = MyUtils.CnvSng(TXTCRMVYear.Text)
    WrkValue = CalcValue(WrkMSRP, WrkOvMSRP, WrkMVYear)
    LblCRValue.Text = MyUtils.Round10(WrkValue, "Normal")
    TxtCRAssmt1.Text = MyUtils.CnvSng(LblCRValue.Text)

    WrkCode = ""
    CalcProrateMonth("C", MyUtils.CnvSng(TxtCRSaleMonth.Text), MyUtils.CnvSng(TxtCRAssmt1.Text), WrkProrate, WrkAdjNet, WrkPct, WrkCode)
    LblCRSalePct.Text = FormatNumber(WrkPct, 3)
    LblCRSaleNet.Text = WrkAdjNet
    LblAdjNet.Text = MyUtils.CnvSng(LblPurchNet.Text) - MyUtils.CnvSng(LblSaleNet.Text) - MyUtils.CnvSng(LblCRSaleNet.Text)
    CalcChg()
  End Sub
  Private Sub ChkOver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkOver.Click
    If ChkOver.Checked Then
      TxtOverAmt.Text = "0"
      TxtOverAmt.Enabled = True
    Else
      TxtOverAmt.Text = ""
      TxtOverAmt.Enabled = False
    End If
  End Sub

  Private Function CalcValue(ByVal WrkMSRP As Integer, ByVal WrkOvMSRP As Integer, ByVal WrkMVYear As Integer) As Integer
    Dim WrkDeYear As Integer
    Dim WrkValue As Integer
    Dim WrkDepr As Decimal
    'Calculate Assessment Value
    WrkValue = 0
    WrkDeYear = WrkYear - WrkMVYear + 1
    If WrkDeYear < 1 Then
      WrkDeYear = 1
    End If
    WrkDepr = GetTXMSRPDEP(WrkDeYear)
    If WrkOvMSRP > 0 Then
      WrkValue = WrkOvMSRP * WrkDepr * MyBookPct
      LblMSRPCalc.Text = WrkOvMSRP & " x " & WrkDepr & "% (" & WrkDeYear & ") x " & MyBookPct & "%"
    Else
      WrkValue = WrkMSRP * WrkDepr * MyBookPct
      LblMSRPCalc.Text = WrkMSRP & " x " & WrkDepr & "% (" & WrkDeYear & ") x " & MyBookPct & "%"
    End If
    WrkValue = MyUtils.Round10(WrkValue, "Normal")
    If WrkValue < MyMinValue Then
      WrkValue = MyMinValue
    End If
    Return WrkValue
  End Function
  Public Function GetTXMSRPDEP(ByVal DeprYear As Integer) As Decimal
    Dim WrkDepr As Decimal
    If DeprYear < 0 Then DeprYear = 1
    WrkDepr = myTXMSRPDEP.GetDepr(DeprYear)
    Return WrkDepr
  End Function
  Private Sub TxtReason_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtReason.Leave
    SetCResnTip()
  End Sub
End Class






