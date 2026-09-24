Imports System.Runtime.CompilerServices.RuntimeHelpers

Public Class FrmTA8105R
  Inherits System.Windows.Forms.Form
  Dim myTXCOEB As TXCOEB.MyData
  Dim myTXCOEBL4 As TXCOEBL4.MyData
  Dim myTXSUPPC As TXSUPPC.MyData
  Dim myTXSUPPCL1 As TXSUPPCL1.MyData
  Dim myTXSUPA As TXSUPA.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXVCUS As TXVCUS.MyData
  Dim myTXVEH As TXVEH.MyData
  Dim myTXMCTL As TXMCTL.MyData
  Dim myTXMSRP As TXMSRP.MyData
  Dim myTXMSRPDEP As TXMSRPDEP.MyData
  Dim myTXMSRPCD As TXMSRPCD.MyData
  Dim dsTXCOEBL4 As DataSet = New DataSet
  Dim myPriceDigestVIN As PriceDigestAPI.ApiVIN
  Dim myPriceDigestValue As PriceDigestAPI.ApiValue
  Dim myPriceDigestSpecs As PriceDigestAPI.ApiSpecs
  Friend WrkAddMode As Boolean
  Friend WrkCCNo As Integer
  Friend WrkCCDate As Date
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkType As String
  Dim LoadScrn As Boolean
  Friend WithEvents LblOrigName As System.Windows.Forms.Label
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents TxtSSNo As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents TxtOid As System.Windows.Forms.TextBox
  Friend WithEvents Label24 As System.Windows.Forms.Label
  Friend WithEvents TxtSS2 As System.Windows.Forms.TextBox
  Friend WithEvents Label26 As System.Windows.Forms.Label
  Friend WithEvents LnkSaleMonth As LinkLabel
  Friend WithEvents ChkComplete As CheckBox
  Friend WithEvents TxtSource As TextBox
  Friend WithEvents LnkSource As LinkLabel
  Friend WithEvents Label10 As Label
  Friend WithEvents TxtOVMSRP As TextBox
  Friend WithEvents LblMSRPCalc As Label
  Friend WithEvents LblMSRP As Label
  Friend WithEvents Label28 As Label
  Friend WithEvents LblValue As Label
  Friend WithEvents Label29 As Label
  Friend WithEvents BtnPriceDigest As Button
  Friend WithEvents LblPDMsg As Label
  Friend WithEvents GroupBox6 As GroupBox
  Friend WithEvents LblCRPDMsg As Label
  Friend WithEvents BtnCRPriceDigest As Button
  Friend WithEvents LblCRMSRP As Label
  Friend WithEvents Label33 As Label
  Friend WithEvents LblCRValue As Label
  Friend WithEvents Label36 As Label
  Friend WithEvents LblCRMSRPCalc As Label
  Friend WithEvents ChkCRComplete As CheckBox
  Friend WithEvents TxtCRSource As TextBox
  Friend WithEvents LnkCRSource As LinkLabel
  Friend WithEvents Label38 As Label
  Friend WithEvents TxtCROVMSRP As TextBox
  Friend WithEvents Label39 As Label
  Friend WithEvents Label40 As Label
  Friend WithEvents TxtCRSS2 As TextBox
  Friend WithEvents Label41 As Label
  Friend WithEvents TxtCRSSNo As TextBox
  Friend WithEvents Label43 As Label
  Friend WithEvents TxtCROid As TextBox
  Friend WithEvents LnkCRClass As LinkLabel
  Friend WithEvents TxtCRModel As TextBox
  Friend WithEvents Label44 As Label
  Friend WithEvents TxtCRMake As TextBox
  Friend WithEvents Label45 As Label
  Friend WithEvents TxtCRMVYear As TextBox
  Friend WithEvents TxtCRClass As TextBox
  Friend WithEvents Label46 As Label
  Friend WithEvents TxtCRReg As TextBox
  Friend WithEvents Label47 As Label
  Friend WithEvents TxtCRID As TextBox
  Friend WithEvents LblChgAdjGross As Label
  Friend WithEvents LblNewAdjGross As Label
  Friend WithEvents LblOrigAdjGross As Label
  Friend WithEvents Label53 As Label
  Friend WithEvents LblAdjNet As Label
  Friend WithEvents Label57 As Label
  Friend WithEvents GroupBox7 As GroupBox
  Friend WithEvents LnkCRSaleMonth As LinkLabel
  Friend WithEvents LblChgCRAssmt1 As Label
  Friend WithEvents Label31 As Label
  Friend WithEvents Label35 As Label
  Friend WithEvents LblOrigCRAssmt1 As Label
  Friend WithEvents LblCRSaleNet As Label
  Friend WithEvents LblCRSalePct As Label
  Friend WithEvents TxtCRSaleMonth As TextBox
  Friend WithEvents TxtCRAssmt1 As TextBox
  Friend WithEvents Label32 As Label
  Friend WithEvents LnkPurchMonth As LinkLabel
  Friend WithEvents LblPurchNet As Label
  Friend WithEvents LblPurchPct As Label
  Friend WithEvents TxtPurchMonth As TextBox
  Friend WithEvents TxtResZip4 As TextBox
  Friend WithEvents TxtResZip5 As TextBox
  Friend WithEvents TxtResAdd1 As TextBox
  Friend WithEvents TxtResState As TextBox
  Friend WithEvents TxtResCity As TextBox
  Friend WithEvents Label37 As Label
  Friend WithEvents Label48 As Label
  Friend WithEvents TxtResAdd2 As TextBox
  Friend WithEvents LnkClass As System.Windows.Forms.LinkLabel

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
  Friend WithEvents TxtZip4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents TxtAdd1 As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents LblChgNet As System.Windows.Forms.Label
  Friend WithEvents LblNewNet As System.Windows.Forms.Label
  Friend WithEvents LblOrigNet As System.Windows.Forms.Label
  Friend WithEvents LblChgExam As System.Windows.Forms.Label
  Friend WithEvents LblNewExam As System.Windows.Forms.Label
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents LblChgGross As System.Windows.Forms.Label
  Friend WithEvents Label34 As System.Windows.Forms.Label
  Friend WithEvents LblNewGross As System.Windows.Forms.Label
  Friend WithEvents LblOrigGross As System.Windows.Forms.Label
  Friend WithEvents LblOrigExam As System.Windows.Forms.Label
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents LblOrig As System.Windows.Forms.Label
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents Label42 As System.Windows.Forms.Label
  Friend WithEvents LblType As System.Windows.Forms.Label
  Friend WithEvents LblYear As System.Windows.Forms.Label
  Friend WithEvents TxtAdd2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtSname As System.Windows.Forms.TextBox
  Friend WithEvents TxtZip5 As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpAssmnt As System.Windows.Forms.TabPage
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
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
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents LblCCNo As System.Windows.Forms.Label
  Friend WithEvents LblListNo As System.Windows.Forms.Label
  Friend WithEvents LblCCDate As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtDist As System.Windows.Forms.TextBox
  Friend WithEvents LnkReason As System.Windows.Forms.LinkLabel
  Friend WithEvents LblBankCd As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
  Friend WithEvents TxtReason As System.Windows.Forms.TextBox
  Friend WithEvents TpMain As System.Windows.Forms.TabPage
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtID As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label25 As System.Windows.Forms.Label
  Friend WithEvents TxtReg As System.Windows.Forms.TextBox
  Friend WithEvents TxtClass As System.Windows.Forms.TextBox
  Friend WithEvents Label27 As System.Windows.Forms.Label
  Friend WithEvents TxtMake As System.Windows.Forms.TextBox
  Friend WithEvents TxtModel As System.Windows.Forms.TextBox
  Friend WithEvents TxtSaleMonth As System.Windows.Forms.TextBox
  Friend WithEvents TxtMVYear As System.Windows.Forms.TextBox
  Friend WithEvents LblChgProrate As System.Windows.Forms.Label
  Friend WithEvents LblNewProrate As System.Windows.Forms.Label
  Friend WithEvents LblOrigProrate As System.Windows.Forms.Label
  Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
  Friend WithEvents RbCatExempt As System.Windows.Forms.RadioButton
  Friend WithEvents RbCatTaxable As System.Windows.Forms.RadioButton
  Friend WithEvents LblSaleNet As System.Windows.Forms.Label
  Friend WithEvents LblSalePct As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtZip4 = New System.Windows.Forms.TextBox()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtAdd1 = New System.Windows.Forms.TextBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
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
    Me.Label42 = New System.Windows.Forms.Label()
    Me.LblType = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.TxtAdd2 = New System.Windows.Forms.TextBox()
    Me.TxtSname = New System.Windows.Forms.TextBox()
    Me.TxtZip5 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TpMain = New System.Windows.Forms.TabPage()
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.LblCRPDMsg = New System.Windows.Forms.Label()
    Me.BtnCRPriceDigest = New System.Windows.Forms.Button()
    Me.LblCRMSRP = New System.Windows.Forms.Label()
    Me.Label33 = New System.Windows.Forms.Label()
    Me.LblCRValue = New System.Windows.Forms.Label()
    Me.Label36 = New System.Windows.Forms.Label()
    Me.LblCRMSRPCalc = New System.Windows.Forms.Label()
    Me.ChkCRComplete = New System.Windows.Forms.CheckBox()
    Me.TxtCRSource = New System.Windows.Forms.TextBox()
    Me.LnkCRSource = New System.Windows.Forms.LinkLabel()
    Me.Label38 = New System.Windows.Forms.Label()
    Me.TxtCROVMSRP = New System.Windows.Forms.TextBox()
    Me.Label39 = New System.Windows.Forms.Label()
    Me.Label40 = New System.Windows.Forms.Label()
    Me.TxtCRSS2 = New System.Windows.Forms.TextBox()
    Me.Label41 = New System.Windows.Forms.Label()
    Me.TxtCRSSNo = New System.Windows.Forms.TextBox()
    Me.Label43 = New System.Windows.Forms.Label()
    Me.TxtCROid = New System.Windows.Forms.TextBox()
    Me.LnkCRClass = New System.Windows.Forms.LinkLabel()
    Me.TxtCRModel = New System.Windows.Forms.TextBox()
    Me.Label44 = New System.Windows.Forms.Label()
    Me.TxtCRMake = New System.Windows.Forms.TextBox()
    Me.Label45 = New System.Windows.Forms.Label()
    Me.TxtCRMVYear = New System.Windows.Forms.TextBox()
    Me.TxtCRClass = New System.Windows.Forms.TextBox()
    Me.Label46 = New System.Windows.Forms.Label()
    Me.TxtCRReg = New System.Windows.Forms.TextBox()
    Me.Label47 = New System.Windows.Forms.Label()
    Me.TxtCRID = New System.Windows.Forms.TextBox()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.RbCatExempt = New System.Windows.Forms.RadioButton()
    Me.RbCatTaxable = New System.Windows.Forms.RadioButton()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.LblPDMsg = New System.Windows.Forms.Label()
    Me.BtnPriceDigest = New System.Windows.Forms.Button()
    Me.LblMSRP = New System.Windows.Forms.Label()
    Me.Label28 = New System.Windows.Forms.Label()
    Me.LblValue = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.LblMSRPCalc = New System.Windows.Forms.Label()
    Me.ChkComplete = New System.Windows.Forms.CheckBox()
    Me.TxtSource = New System.Windows.Forms.TextBox()
    Me.LnkSource = New System.Windows.Forms.LinkLabel()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtOVMSRP = New System.Windows.Forms.TextBox()
    Me.Label26 = New System.Windows.Forms.Label()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.TxtSS2 = New System.Windows.Forms.TextBox()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.TxtSSNo = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
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
    Me.LblBankCd = New System.Windows.Forms.Label()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.TxtDesc = New System.Windows.Forms.TextBox()
    Me.TxtReason = New System.Windows.Forms.TextBox()
    Me.TpAssmnt = New System.Windows.Forms.TabPage()
    Me.LblAdjNet = New System.Windows.Forms.Label()
    Me.Label57 = New System.Windows.Forms.Label()
    Me.GroupBox7 = New System.Windows.Forms.GroupBox()
    Me.LnkCRSaleMonth = New System.Windows.Forms.LinkLabel()
    Me.LblChgCRAssmt1 = New System.Windows.Forms.Label()
    Me.Label31 = New System.Windows.Forms.Label()
    Me.Label35 = New System.Windows.Forms.Label()
    Me.LblOrigCRAssmt1 = New System.Windows.Forms.Label()
    Me.LblCRSaleNet = New System.Windows.Forms.Label()
    Me.LblCRSalePct = New System.Windows.Forms.Label()
    Me.TxtCRSaleMonth = New System.Windows.Forms.TextBox()
    Me.TxtCRAssmt1 = New System.Windows.Forms.TextBox()
    Me.Label32 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LnkPurchMonth = New System.Windows.Forms.LinkLabel()
    Me.LblPurchNet = New System.Windows.Forms.Label()
    Me.LblPurchPct = New System.Windows.Forms.Label()
    Me.TxtPurchMonth = New System.Windows.Forms.TextBox()
    Me.LnkSaleMonth = New System.Windows.Forms.LinkLabel()
    Me.LblSaleNet = New System.Windows.Forms.Label()
    Me.LblSalePct = New System.Windows.Forms.Label()
    Me.TxtSaleMonth = New System.Windows.Forms.TextBox()
    Me.LblChgAssmt1 = New System.Windows.Forms.Label()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.TxtAssmt1 = New System.Windows.Forms.TextBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.LblOrigAssmt1 = New System.Windows.Forms.Label()
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
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.LblCCNo = New System.Windows.Forms.Label()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.LblCCDate = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.LblOrigName = New System.Windows.Forms.Label()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.TxtResZip4 = New System.Windows.Forms.TextBox()
    Me.TxtResZip5 = New System.Windows.Forms.TextBox()
    Me.TxtResAdd1 = New System.Windows.Forms.TextBox()
    Me.TxtResState = New System.Windows.Forms.TextBox()
    Me.TxtResCity = New System.Windows.Forms.TextBox()
    Me.Label37 = New System.Windows.Forms.Label()
    Me.Label48 = New System.Windows.Forms.Label()
    Me.TxtResAdd2 = New System.Windows.Forms.TextBox()
    Me.GroupBox2.SuspendLayout()
    Me.TabControl1.SuspendLayout()
    Me.TpMain.SuspendLayout()
    Me.GroupBox6.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.TpAssmnt.SuspendLayout()
    Me.GroupBox7.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.TpExemptions.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtZip4
    '
    Me.TxtZip4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtZip4.Location = New System.Drawing.Point(426, 144)
    Me.TxtZip4.MaxLength = 4
    Me.TxtZip4.Name = "TxtZip4"
    Me.TxtZip4.Size = New System.Drawing.Size(42, 20)
    Me.TxtZip4.TabIndex = 8
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Location = New System.Drawing.Point(100, 144)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(232, 20)
    Me.TxtCity.TabIndex = 5
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Location = New System.Drawing.Point(340, 144)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 20)
    Me.TxtState.TabIndex = 6
    '
    'TxtAdd1
    '
    Me.TxtAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd1.Location = New System.Drawing.Point(100, 96)
    Me.TxtAdd1.MaxLength = 35
    Me.TxtAdd1.Name = "TxtAdd1"
    Me.TxtAdd1.Size = New System.Drawing.Size(280, 20)
    Me.TxtAdd1.TabIndex = 3
    '
    'GroupBox2
    '
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
    Me.GroupBox2.Location = New System.Drawing.Point(590, 12)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(343, 116)
    Me.GroupBox2.TabIndex = 170
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Totals"
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
    Me.Label53.Location = New System.Drawing.Point(12, 75)
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
    Me.Label21.Location = New System.Drawing.Point(12, 43)
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
    Me.Label20.Location = New System.Drawing.Point(12, 59)
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
    Me.Label19.Location = New System.Drawing.Point(12, 27)
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
    Me.Label22.Location = New System.Drawing.Point(12, 91)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(24, 13)
    Me.Label22.TabIndex = 160
    Me.Label22.Text = "Net"
    '
    'Label42
    '
    Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label42.Location = New System.Drawing.Point(396, 48)
    Me.Label42.Name = "Label42"
    Me.Label42.Size = New System.Drawing.Size(48, 16)
    Me.Label42.TabIndex = 164
    Me.Label42.Text = "District"
    '
    'LblType
    '
    Me.LblType.Location = New System.Drawing.Point(416, 4)
    Me.LblType.Name = "LblType"
    Me.LblType.Size = New System.Drawing.Size(24, 16)
    Me.LblType.TabIndex = 175
    '
    'LblYear
    '
    Me.LblYear.Location = New System.Drawing.Point(216, 4)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(32, 16)
    Me.LblYear.TabIndex = 173
    '
    'TxtAdd2
    '
    Me.TxtAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd2.Location = New System.Drawing.Point(100, 120)
    Me.TxtAdd2.MaxLength = 35
    Me.TxtAdd2.Name = "TxtAdd2"
    Me.TxtAdd2.Size = New System.Drawing.Size(280, 20)
    Me.TxtAdd2.TabIndex = 4
    '
    'TxtSname
    '
    Me.TxtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSname.Location = New System.Drawing.Point(100, 72)
    Me.TxtSname.MaxLength = 35
    Me.TxtSname.Name = "TxtSname"
    Me.TxtSname.Size = New System.Drawing.Size(280, 20)
    Me.TxtSname.TabIndex = 2
    '
    'TxtZip5
    '
    Me.TxtZip5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtZip5.Location = New System.Drawing.Point(375, 144)
    Me.TxtZip5.MaxLength = 5
    Me.TxtZip5.Name = "TxtZip5"
    Me.TxtZip5.Size = New System.Drawing.Size(45, 20)
    Me.TxtZip5.TabIndex = 7
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(12, 72)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(80, 16)
    Me.Label2.TabIndex = 167
    Me.Label2.Text = "Second Name"
    '
    'TabControl1
    '
    Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons
    Me.TabControl1.Controls.Add(Me.TpMain)
    Me.TabControl1.Controls.Add(Me.TpAssmnt)
    Me.TabControl1.Controls.Add(Me.TpExemptions)
    Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TabControl1.Location = New System.Drawing.Point(16, 242)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(698, 334)
    Me.TabControl1.TabIndex = 9
    Me.TabControl1.TabStop = False
    '
    'TpMain
    '
    Me.TpMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.TpMain.Controls.Add(Me.GroupBox6)
    Me.TpMain.Controls.Add(Me.GroupBox5)
    Me.TpMain.Controls.Add(Me.GroupBox3)
    Me.TpMain.Controls.Add(Me.LnkReason)
    Me.TpMain.Controls.Add(Me.LblBankCd)
    Me.TpMain.Controls.Add(Me.Label14)
    Me.TpMain.Controls.Add(Me.TxtDesc)
    Me.TpMain.Controls.Add(Me.TxtReason)
    Me.TpMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TpMain.Location = New System.Drawing.Point(4, 25)
    Me.TpMain.Name = "TpMain"
    Me.TpMain.Size = New System.Drawing.Size(690, 305)
    Me.TpMain.TabIndex = 0
    Me.TpMain.Text = "Main"
    '
    'GroupBox6
    '
    Me.GroupBox6.Controls.Add(Me.LblCRPDMsg)
    Me.GroupBox6.Controls.Add(Me.BtnCRPriceDigest)
    Me.GroupBox6.Controls.Add(Me.LblCRMSRP)
    Me.GroupBox6.Controls.Add(Me.Label33)
    Me.GroupBox6.Controls.Add(Me.LblCRValue)
    Me.GroupBox6.Controls.Add(Me.Label36)
    Me.GroupBox6.Controls.Add(Me.LblCRMSRPCalc)
    Me.GroupBox6.Controls.Add(Me.ChkCRComplete)
    Me.GroupBox6.Controls.Add(Me.TxtCRSource)
    Me.GroupBox6.Controls.Add(Me.LnkCRSource)
    Me.GroupBox6.Controls.Add(Me.Label38)
    Me.GroupBox6.Controls.Add(Me.TxtCROVMSRP)
    Me.GroupBox6.Controls.Add(Me.Label39)
    Me.GroupBox6.Controls.Add(Me.Label40)
    Me.GroupBox6.Controls.Add(Me.TxtCRSS2)
    Me.GroupBox6.Controls.Add(Me.Label41)
    Me.GroupBox6.Controls.Add(Me.TxtCRSSNo)
    Me.GroupBox6.Controls.Add(Me.Label43)
    Me.GroupBox6.Controls.Add(Me.TxtCROid)
    Me.GroupBox6.Controls.Add(Me.LnkCRClass)
    Me.GroupBox6.Controls.Add(Me.TxtCRModel)
    Me.GroupBox6.Controls.Add(Me.Label44)
    Me.GroupBox6.Controls.Add(Me.TxtCRMake)
    Me.GroupBox6.Controls.Add(Me.Label45)
    Me.GroupBox6.Controls.Add(Me.TxtCRMVYear)
    Me.GroupBox6.Controls.Add(Me.TxtCRClass)
    Me.GroupBox6.Controls.Add(Me.Label46)
    Me.GroupBox6.Controls.Add(Me.TxtCRReg)
    Me.GroupBox6.Controls.Add(Me.Label47)
    Me.GroupBox6.Controls.Add(Me.TxtCRID)
    Me.GroupBox6.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox6.Location = New System.Drawing.Point(20, 134)
    Me.GroupBox6.Name = "GroupBox6"
    Me.GroupBox6.Size = New System.Drawing.Size(536, 135)
    Me.GroupBox6.TabIndex = 178
    Me.GroupBox6.TabStop = False
    Me.GroupBox6.Text = "Credit Vehicle"
    '
    'LblCRPDMsg
    '
    Me.LblCRPDMsg.AutoSize = True
    Me.LblCRPDMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCRPDMsg.ForeColor = System.Drawing.Color.Black
    Me.LblCRPDMsg.Location = New System.Drawing.Point(454, 40)
    Me.LblCRPDMsg.Name = "LblCRPDMsg"
    Me.LblCRPDMsg.Size = New System.Drawing.Size(57, 13)
    Me.LblCRPDMsg.TabIndex = 296
    Me.LblCRPDMsg.Text = "<PD Msg>"
    '
    'BtnCRPriceDigest
    '
    Me.BtnCRPriceDigest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnCRPriceDigest.ForeColor = System.Drawing.Color.Black
    Me.BtnCRPriceDigest.Location = New System.Drawing.Point(455, 13)
    Me.BtnCRPriceDigest.Name = "BtnCRPriceDigest"
    Me.BtnCRPriceDigest.Size = New System.Drawing.Size(74, 24)
    Me.BtnCRPriceDigest.TabIndex = 295
    Me.BtnCRPriceDigest.Text = "Price Digest"
    '
    'LblCRMSRP
    '
    Me.LblCRMSRP.BackColor = System.Drawing.Color.Aqua
    Me.LblCRMSRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCRMSRP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCRMSRP.ForeColor = System.Drawing.Color.Black
    Me.LblCRMSRP.Location = New System.Drawing.Point(392, 106)
    Me.LblCRMSRP.Name = "LblCRMSRP"
    Me.LblCRMSRP.Size = New System.Drawing.Size(64, 16)
    Me.LblCRMSRP.TabIndex = 294
    Me.LblCRMSRP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label33
    '
    Me.Label33.AutoSize = True
    Me.Label33.ForeColor = System.Drawing.Color.Black
    Me.Label33.Location = New System.Drawing.Point(391, 92)
    Me.Label33.Name = "Label33"
    Me.Label33.Size = New System.Drawing.Size(65, 13)
    Me.Label33.TabIndex = 293
    Me.Label33.Text = "DMV MSRP"
    '
    'LblCRValue
    '
    Me.LblCRValue.BackColor = System.Drawing.Color.Aqua
    Me.LblCRValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCRValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCRValue.ForeColor = System.Drawing.Color.Black
    Me.LblCRValue.Location = New System.Drawing.Point(465, 105)
    Me.LblCRValue.Name = "LblCRValue"
    Me.LblCRValue.Size = New System.Drawing.Size(64, 16)
    Me.LblCRValue.TabIndex = 292
    Me.LblCRValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label36
    '
    Me.Label36.AutoSize = True
    Me.Label36.ForeColor = System.Drawing.Color.Black
    Me.Label36.Location = New System.Drawing.Point(477, 92)
    Me.Label36.Name = "Label36"
    Me.Label36.Size = New System.Drawing.Size(34, 13)
    Me.Label36.TabIndex = 291
    Me.Label36.Text = "Value"
    '
    'LblCRMSRPCalc
    '
    Me.LblCRMSRPCalc.AutoSize = True
    Me.LblCRMSRPCalc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCRMSRPCalc.ForeColor = System.Drawing.Color.Black
    Me.LblCRMSRPCalc.Location = New System.Drawing.Point(246, 108)
    Me.LblCRMSRPCalc.Name = "LblCRMSRPCalc"
    Me.LblCRMSRPCalc.Size = New System.Drawing.Size(74, 13)
    Me.LblCRMSRPCalc.TabIndex = 290
    Me.LblCRMSRPCalc.Text = "<MSRP Calc>"
    '
    'ChkCRComplete
    '
    Me.ChkCRComplete.AutoSize = True
    Me.ChkCRComplete.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkCRComplete.ForeColor = System.Drawing.Color.Black
    Me.ChkCRComplete.Location = New System.Drawing.Point(152, 113)
    Me.ChkCRComplete.Name = "ChkCRComplete"
    Me.ChkCRComplete.Size = New System.Drawing.Size(76, 17)
    Me.ChkCRComplete.TabIndex = 289
    Me.ChkCRComplete.Text = "Complete?"
    '
    'TxtCRSource
    '
    Me.TxtCRSource.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCRSource.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCRSource.Location = New System.Drawing.Point(116, 108)
    Me.TxtCRSource.MaxLength = 2
    Me.TxtCRSource.Name = "TxtCRSource"
    Me.TxtCRSource.Size = New System.Drawing.Size(19, 22)
    Me.TxtCRSource.TabIndex = 287
    '
    'LnkCRSource
    '
    Me.LnkCRSource.AutoSize = True
    Me.LnkCRSource.Location = New System.Drawing.Point(103, 92)
    Me.LnkCRSource.Name = "LnkCRSource"
    Me.LnkCRSource.Size = New System.Drawing.Size(41, 13)
    Me.LnkCRSource.TabIndex = 288
    Me.LnkCRSource.TabStop = True
    Me.LnkCRSource.Text = "Source"
    '
    'Label38
    '
    Me.Label38.AutoSize = True
    Me.Label38.ForeColor = System.Drawing.Color.Black
    Me.Label38.Location = New System.Drawing.Point(19, 92)
    Me.Label38.Name = "Label38"
    Me.Label38.Size = New System.Drawing.Size(67, 13)
    Me.Label38.TabIndex = 286
    Me.Label38.Text = "100% MSRP"
    '
    'TxtCROVMSRP
    '
    Me.TxtCROVMSRP.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCROVMSRP.Location = New System.Drawing.Point(14, 108)
    Me.TxtCROVMSRP.MaxLength = 9
    Me.TxtCROVMSRP.Name = "TxtCROVMSRP"
    Me.TxtCROVMSRP.Size = New System.Drawing.Size(82, 22)
    Me.TxtCROVMSRP.TabIndex = 285
    Me.TxtCROVMSRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label39
    '
    Me.Label39.AutoSize = True
    Me.Label39.ForeColor = System.Drawing.Color.Black
    Me.Label39.Location = New System.Drawing.Point(246, 43)
    Me.Label39.Name = "Label39"
    Me.Label39.Size = New System.Drawing.Size(36, 13)
    Me.Label39.TabIndex = 246
    Me.Label39.Text = "Model"
    '
    'Label40
    '
    Me.Label40.AutoSize = True
    Me.Label40.ForeColor = System.Drawing.Color.Black
    Me.Label40.Location = New System.Drawing.Point(185, 68)
    Me.Label40.Name = "Label40"
    Me.Label40.Size = New System.Drawing.Size(79, 13)
    Me.Label40.TabIndex = 245
    Me.Label40.Text = "SecondCust ID"
    '
    'TxtCRSS2
    '
    Me.TxtCRSS2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCRSS2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
    Me.TxtCRSS2.Location = New System.Drawing.Point(266, 64)
    Me.TxtCRSS2.MaxLength = 9
    Me.TxtCRSS2.Name = "TxtCRSS2"
    Me.TxtCRSS2.Size = New System.Drawing.Size(80, 20)
    Me.TxtCRSS2.TabIndex = 16
    Me.TxtCRSS2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label41
    '
    Me.Label41.AutoSize = True
    Me.Label41.ForeColor = System.Drawing.Color.Black
    Me.Label41.Location = New System.Drawing.Point(8, 68)
    Me.Label41.Name = "Label41"
    Me.Label41.Size = New System.Drawing.Size(76, 13)
    Me.Label41.TabIndex = 243
    Me.Label41.Text = "PrimaryCust ID"
    '
    'TxtCRSSNo
    '
    Me.TxtCRSSNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCRSSNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
    Me.TxtCRSSNo.Location = New System.Drawing.Point(90, 64)
    Me.TxtCRSSNo.MaxLength = 9
    Me.TxtCRSSNo.Name = "TxtCRSSNo"
    Me.TxtCRSSNo.Size = New System.Drawing.Size(80, 20)
    Me.TxtCRSSNo.TabIndex = 15
    Me.TxtCRSSNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label43
    '
    Me.Label43.AutoSize = True
    Me.Label43.ForeColor = System.Drawing.Color.Black
    Me.Label43.Location = New System.Drawing.Point(358, 68)
    Me.Label43.Name = "Label43"
    Me.Label43.Size = New System.Drawing.Size(56, 13)
    Me.Label43.TabIndex = 241
    Me.Label43.Text = "Vehicle ID"
    '
    'TxtCROid
    '
    Me.TxtCROid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCROid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
    Me.TxtCROid.Location = New System.Drawing.Point(420, 64)
    Me.TxtCROid.MaxLength = 15
    Me.TxtCROid.Name = "TxtCROid"
    Me.TxtCROid.Size = New System.Drawing.Size(75, 20)
    Me.TxtCROid.TabIndex = 17
    '
    'LnkCRClass
    '
    Me.LnkCRClass.Location = New System.Drawing.Point(384, 16)
    Me.LnkCRClass.Name = "LnkCRClass"
    Me.LnkCRClass.Size = New System.Drawing.Size(35, 20)
    Me.LnkCRClass.TabIndex = 167
    Me.LnkCRClass.TabStop = True
    Me.LnkCRClass.Text = "Class"
    Me.LnkCRClass.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'TxtCRModel
    '
    Me.TxtCRModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCRModel.Location = New System.Drawing.Point(288, 40)
    Me.TxtCRModel.MaxLength = 8
    Me.TxtCRModel.Name = "TxtCRModel"
    Me.TxtCRModel.Size = New System.Drawing.Size(64, 20)
    Me.TxtCRModel.TabIndex = 14
    '
    'Label44
    '
    Me.Label44.AutoSize = True
    Me.Label44.ForeColor = System.Drawing.Color.Black
    Me.Label44.Location = New System.Drawing.Point(146, 42)
    Me.Label44.Name = "Label44"
    Me.Label44.Size = New System.Drawing.Size(34, 13)
    Me.Label44.TabIndex = 166
    Me.Label44.Text = "Make"
    '
    'TxtCRMake
    '
    Me.TxtCRMake.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCRMake.Location = New System.Drawing.Point(186, 39)
    Me.TxtCRMake.MaxLength = 5
    Me.TxtCRMake.Name = "TxtCRMake"
    Me.TxtCRMake.Size = New System.Drawing.Size(48, 20)
    Me.TxtCRMake.TabIndex = 13
    '
    'Label45
    '
    Me.Label45.AutoSize = True
    Me.Label45.ForeColor = System.Drawing.Color.Black
    Me.Label45.Location = New System.Drawing.Point(8, 40)
    Me.Label45.Name = "Label45"
    Me.Label45.Size = New System.Drawing.Size(29, 13)
    Me.Label45.TabIndex = 164
    Me.Label45.Text = "Year"
    '
    'TxtCRMVYear
    '
    Me.TxtCRMVYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCRMVYear.Location = New System.Drawing.Point(90, 40)
    Me.TxtCRMVYear.MaxLength = 4
    Me.TxtCRMVYear.Name = "TxtCRMVYear"
    Me.TxtCRMVYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtCRMVYear.TabIndex = 12
    '
    'TxtCRClass
    '
    Me.TxtCRClass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCRClass.Location = New System.Drawing.Point(425, 16)
    Me.TxtCRClass.MaxLength = 2
    Me.TxtCRClass.Name = "TxtCRClass"
    Me.TxtCRClass.Size = New System.Drawing.Size(24, 20)
    Me.TxtCRClass.TabIndex = 11
    '
    'Label46
    '
    Me.Label46.ForeColor = System.Drawing.Color.Black
    Me.Label46.Location = New System.Drawing.Point(256, 16)
    Me.Label46.Name = "Label46"
    Me.Label46.Size = New System.Drawing.Size(32, 16)
    Me.Label46.TabIndex = 1
    Me.Label46.Text = "Reg"
    '
    'TxtCRReg
    '
    Me.TxtCRReg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCRReg.Location = New System.Drawing.Point(288, 16)
    Me.TxtCRReg.MaxLength = 8
    Me.TxtCRReg.Name = "TxtCRReg"
    Me.TxtCRReg.Size = New System.Drawing.Size(94, 20)
    Me.TxtCRReg.TabIndex = 10
    '
    'Label47
    '
    Me.Label47.AutoSize = True
    Me.Label47.ForeColor = System.Drawing.Color.Black
    Me.Label47.Location = New System.Drawing.Point(8, 16)
    Me.Label47.Name = "Label47"
    Me.Label47.Size = New System.Drawing.Size(28, 13)
    Me.Label47.TabIndex = 158
    Me.Label47.Text = "VIN "
    '
    'TxtCRID
    '
    Me.TxtCRID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCRID.Location = New System.Drawing.Point(90, 16)
    Me.TxtCRID.MaxLength = 17
    Me.TxtCRID.Name = "TxtCRID"
    Me.TxtCRID.Size = New System.Drawing.Size(144, 20)
    Me.TxtCRID.TabIndex = 9
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.RbCatExempt)
    Me.GroupBox5.Controls.Add(Me.RbCatTaxable)
    Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox5.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox5.Location = New System.Drawing.Point(583, 14)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(83, 62)
    Me.GroupBox5.TabIndex = 177
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "Category"
    '
    'RbCatExempt
    '
    Me.RbCatExempt.AutoSize = True
    Me.RbCatExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCatExempt.ForeColor = System.Drawing.Color.Black
    Me.RbCatExempt.Location = New System.Drawing.Point(8, 35)
    Me.RbCatExempt.Name = "RbCatExempt"
    Me.RbCatExempt.Size = New System.Drawing.Size(60, 17)
    Me.RbCatExempt.TabIndex = 1
    Me.RbCatExempt.Text = "Exempt"
    '
    'RbCatTaxable
    '
    Me.RbCatTaxable.AutoSize = True
    Me.RbCatTaxable.Checked = True
    Me.RbCatTaxable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCatTaxable.ForeColor = System.Drawing.Color.Black
    Me.RbCatTaxable.Location = New System.Drawing.Point(8, 16)
    Me.RbCatTaxable.Name = "RbCatTaxable"
    Me.RbCatTaxable.Size = New System.Drawing.Size(63, 17)
    Me.RbCatTaxable.TabIndex = 0
    Me.RbCatTaxable.TabStop = True
    Me.RbCatTaxable.Text = "Taxable"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.LblPDMsg)
    Me.GroupBox3.Controls.Add(Me.BtnPriceDigest)
    Me.GroupBox3.Controls.Add(Me.LblMSRP)
    Me.GroupBox3.Controls.Add(Me.Label28)
    Me.GroupBox3.Controls.Add(Me.LblValue)
    Me.GroupBox3.Controls.Add(Me.Label29)
    Me.GroupBox3.Controls.Add(Me.LblMSRPCalc)
    Me.GroupBox3.Controls.Add(Me.ChkComplete)
    Me.GroupBox3.Controls.Add(Me.TxtSource)
    Me.GroupBox3.Controls.Add(Me.LnkSource)
    Me.GroupBox3.Controls.Add(Me.Label10)
    Me.GroupBox3.Controls.Add(Me.TxtOVMSRP)
    Me.GroupBox3.Controls.Add(Me.Label26)
    Me.GroupBox3.Controls.Add(Me.Label24)
    Me.GroupBox3.Controls.Add(Me.TxtSS2)
    Me.GroupBox3.Controls.Add(Me.Label16)
    Me.GroupBox3.Controls.Add(Me.TxtSSNo)
    Me.GroupBox3.Controls.Add(Me.Label11)
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
    Me.GroupBox3.Location = New System.Drawing.Point(20, 1)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(536, 130)
    Me.GroupBox3.TabIndex = 9
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Current Vehicle"
    '
    'LblPDMsg
    '
    Me.LblPDMsg.AutoSize = True
    Me.LblPDMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPDMsg.ForeColor = System.Drawing.Color.Black
    Me.LblPDMsg.Location = New System.Drawing.Point(454, 40)
    Me.LblPDMsg.Name = "LblPDMsg"
    Me.LblPDMsg.Size = New System.Drawing.Size(57, 13)
    Me.LblPDMsg.TabIndex = 296
    Me.LblPDMsg.Text = "<PD Msg>"
    '
    'BtnPriceDigest
    '
    Me.BtnPriceDigest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnPriceDigest.ForeColor = System.Drawing.Color.Black
    Me.BtnPriceDigest.Location = New System.Drawing.Point(455, 13)
    Me.BtnPriceDigest.Name = "BtnPriceDigest"
    Me.BtnPriceDigest.Size = New System.Drawing.Size(74, 24)
    Me.BtnPriceDigest.TabIndex = 295
    Me.BtnPriceDigest.Text = "Price Digest"
    '
    'LblMSRP
    '
    Me.LblMSRP.BackColor = System.Drawing.Color.Aqua
    Me.LblMSRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblMSRP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMSRP.ForeColor = System.Drawing.Color.Black
    Me.LblMSRP.Location = New System.Drawing.Point(392, 106)
    Me.LblMSRP.Name = "LblMSRP"
    Me.LblMSRP.Size = New System.Drawing.Size(64, 16)
    Me.LblMSRP.TabIndex = 294
    Me.LblMSRP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label28
    '
    Me.Label28.AutoSize = True
    Me.Label28.ForeColor = System.Drawing.Color.Black
    Me.Label28.Location = New System.Drawing.Point(391, 92)
    Me.Label28.Name = "Label28"
    Me.Label28.Size = New System.Drawing.Size(65, 13)
    Me.Label28.TabIndex = 293
    Me.Label28.Text = "DMV MSRP"
    '
    'LblValue
    '
    Me.LblValue.BackColor = System.Drawing.Color.Aqua
    Me.LblValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblValue.ForeColor = System.Drawing.Color.Black
    Me.LblValue.Location = New System.Drawing.Point(465, 105)
    Me.LblValue.Name = "LblValue"
    Me.LblValue.Size = New System.Drawing.Size(64, 16)
    Me.LblValue.TabIndex = 292
    Me.LblValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label29
    '
    Me.Label29.AutoSize = True
    Me.Label29.ForeColor = System.Drawing.Color.Black
    Me.Label29.Location = New System.Drawing.Point(477, 92)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(34, 13)
    Me.Label29.TabIndex = 291
    Me.Label29.Text = "Value"
    '
    'LblMSRPCalc
    '
    Me.LblMSRPCalc.AutoSize = True
    Me.LblMSRPCalc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMSRPCalc.ForeColor = System.Drawing.Color.Black
    Me.LblMSRPCalc.Location = New System.Drawing.Point(246, 108)
    Me.LblMSRPCalc.Name = "LblMSRPCalc"
    Me.LblMSRPCalc.Size = New System.Drawing.Size(74, 13)
    Me.LblMSRPCalc.TabIndex = 290
    Me.LblMSRPCalc.Text = "<MSRP Calc>"
    '
    'ChkComplete
    '
    Me.ChkComplete.AutoSize = True
    Me.ChkComplete.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkComplete.ForeColor = System.Drawing.Color.Black
    Me.ChkComplete.Location = New System.Drawing.Point(152, 113)
    Me.ChkComplete.Name = "ChkComplete"
    Me.ChkComplete.Size = New System.Drawing.Size(76, 17)
    Me.ChkComplete.TabIndex = 289
    Me.ChkComplete.Text = "Complete?"
    '
    'TxtSource
    '
    Me.TxtSource.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSource.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSource.Location = New System.Drawing.Point(116, 108)
    Me.TxtSource.MaxLength = 2
    Me.TxtSource.Name = "TxtSource"
    Me.TxtSource.Size = New System.Drawing.Size(19, 22)
    Me.TxtSource.TabIndex = 287
    '
    'LnkSource
    '
    Me.LnkSource.AutoSize = True
    Me.LnkSource.Location = New System.Drawing.Point(103, 92)
    Me.LnkSource.Name = "LnkSource"
    Me.LnkSource.Size = New System.Drawing.Size(41, 13)
    Me.LnkSource.TabIndex = 288
    Me.LnkSource.TabStop = True
    Me.LnkSource.Text = "Source"
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.ForeColor = System.Drawing.Color.Black
    Me.Label10.Location = New System.Drawing.Point(19, 92)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(67, 13)
    Me.Label10.TabIndex = 286
    Me.Label10.Text = "100% MSRP"
    '
    'TxtOVMSRP
    '
    Me.TxtOVMSRP.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOVMSRP.Location = New System.Drawing.Point(14, 108)
    Me.TxtOVMSRP.MaxLength = 9
    Me.TxtOVMSRP.Name = "TxtOVMSRP"
    Me.TxtOVMSRP.Size = New System.Drawing.Size(82, 22)
    Me.TxtOVMSRP.TabIndex = 285
    Me.TxtOVMSRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label26
    '
    Me.Label26.AutoSize = True
    Me.Label26.ForeColor = System.Drawing.Color.Black
    Me.Label26.Location = New System.Drawing.Point(246, 43)
    Me.Label26.Name = "Label26"
    Me.Label26.Size = New System.Drawing.Size(36, 13)
    Me.Label26.TabIndex = 246
    Me.Label26.Text = "Model"
    '
    'Label24
    '
    Me.Label24.AutoSize = True
    Me.Label24.ForeColor = System.Drawing.Color.Black
    Me.Label24.Location = New System.Drawing.Point(185, 68)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(79, 13)
    Me.Label24.TabIndex = 245
    Me.Label24.Text = "SecondCust ID"
    '
    'TxtSS2
    '
    Me.TxtSS2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSS2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
    Me.TxtSS2.Location = New System.Drawing.Point(266, 64)
    Me.TxtSS2.MaxLength = 9
    Me.TxtSS2.Name = "TxtSS2"
    Me.TxtSS2.Size = New System.Drawing.Size(80, 20)
    Me.TxtSS2.TabIndex = 16
    Me.TxtSS2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label16
    '
    Me.Label16.AutoSize = True
    Me.Label16.ForeColor = System.Drawing.Color.Black
    Me.Label16.Location = New System.Drawing.Point(8, 68)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(76, 13)
    Me.Label16.TabIndex = 243
    Me.Label16.Text = "PrimaryCust ID"
    '
    'TxtSSNo
    '
    Me.TxtSSNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSSNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
    Me.TxtSSNo.Location = New System.Drawing.Point(90, 64)
    Me.TxtSSNo.MaxLength = 9
    Me.TxtSSNo.Name = "TxtSSNo"
    Me.TxtSSNo.Size = New System.Drawing.Size(80, 20)
    Me.TxtSSNo.TabIndex = 15
    Me.TxtSSNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.ForeColor = System.Drawing.Color.Black
    Me.Label11.Location = New System.Drawing.Point(358, 68)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(56, 13)
    Me.Label11.TabIndex = 241
    Me.Label11.Text = "Vehicle ID"
    '
    'TxtOid
    '
    Me.TxtOid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
    Me.TxtOid.Location = New System.Drawing.Point(420, 64)
    Me.TxtOid.MaxLength = 15
    Me.TxtOid.Name = "TxtOid"
    Me.TxtOid.Size = New System.Drawing.Size(75, 20)
    Me.TxtOid.TabIndex = 17
    '
    'LnkClass
    '
    Me.LnkClass.Location = New System.Drawing.Point(388, 16)
    Me.LnkClass.Name = "LnkClass"
    Me.LnkClass.Size = New System.Drawing.Size(33, 20)
    Me.LnkClass.TabIndex = 167
    Me.LnkClass.TabStop = True
    Me.LnkClass.Text = "Class"
    Me.LnkClass.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'TxtModel
    '
    Me.TxtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtModel.Location = New System.Drawing.Point(288, 40)
    Me.TxtModel.MaxLength = 8
    Me.TxtModel.Name = "TxtModel"
    Me.TxtModel.Size = New System.Drawing.Size(64, 20)
    Me.TxtModel.TabIndex = 14
    '
    'Label27
    '
    Me.Label27.AutoSize = True
    Me.Label27.ForeColor = System.Drawing.Color.Black
    Me.Label27.Location = New System.Drawing.Point(146, 42)
    Me.Label27.Name = "Label27"
    Me.Label27.Size = New System.Drawing.Size(34, 13)
    Me.Label27.TabIndex = 166
    Me.Label27.Text = "Make"
    '
    'TxtMake
    '
    Me.TxtMake.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMake.Location = New System.Drawing.Point(186, 39)
    Me.TxtMake.MaxLength = 5
    Me.TxtMake.Name = "TxtMake"
    Me.TxtMake.Size = New System.Drawing.Size(48, 20)
    Me.TxtMake.TabIndex = 13
    '
    'Label25
    '
    Me.Label25.AutoSize = True
    Me.Label25.ForeColor = System.Drawing.Color.Black
    Me.Label25.Location = New System.Drawing.Point(8, 40)
    Me.Label25.Name = "Label25"
    Me.Label25.Size = New System.Drawing.Size(29, 13)
    Me.Label25.TabIndex = 164
    Me.Label25.Text = "Year"
    '
    'TxtMVYear
    '
    Me.TxtMVYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMVYear.Location = New System.Drawing.Point(90, 40)
    Me.TxtMVYear.MaxLength = 4
    Me.TxtMVYear.Name = "TxtMVYear"
    Me.TxtMVYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtMVYear.TabIndex = 12
    '
    'TxtClass
    '
    Me.TxtClass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtClass.Location = New System.Drawing.Point(427, 16)
    Me.TxtClass.MaxLength = 2
    Me.TxtClass.Name = "TxtClass"
    Me.TxtClass.Size = New System.Drawing.Size(24, 20)
    Me.TxtClass.TabIndex = 11
    '
    'Label7
    '
    Me.Label7.ForeColor = System.Drawing.Color.Black
    Me.Label7.Location = New System.Drawing.Point(256, 16)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(32, 16)
    Me.Label7.TabIndex = 1
    Me.Label7.Text = "Reg"
    '
    'TxtReg
    '
    Me.TxtReg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtReg.Location = New System.Drawing.Point(288, 16)
    Me.TxtReg.MaxLength = 8
    Me.TxtReg.Name = "TxtReg"
    Me.TxtReg.Size = New System.Drawing.Size(94, 20)
    Me.TxtReg.TabIndex = 10
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.ForeColor = System.Drawing.Color.Black
    Me.Label6.Location = New System.Drawing.Point(8, 16)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(28, 13)
    Me.Label6.TabIndex = 158
    Me.Label6.Text = "VIN "
    '
    'TxtID
    '
    Me.TxtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtID.Location = New System.Drawing.Point(90, 16)
    Me.TxtID.MaxLength = 17
    Me.TxtID.Name = "TxtID"
    Me.TxtID.Size = New System.Drawing.Size(144, 20)
    Me.TxtID.TabIndex = 9
    '
    'LnkReason
    '
    Me.LnkReason.Location = New System.Drawing.Point(1, 272)
    Me.LnkReason.Name = "LnkReason"
    Me.LnkReason.Size = New System.Drawing.Size(88, 16)
    Me.LnkReason.TabIndex = 15
    Me.LnkReason.TabStop = True
    Me.LnkReason.Text = "Change Reason"
    '
    'LblBankCd
    '
    Me.LblBankCd.Location = New System.Drawing.Point(408, 32)
    Me.LblBankCd.Name = "LblBankCd"
    Me.LblBankCd.Size = New System.Drawing.Size(24, 16)
    Me.LblBankCd.TabIndex = 161
    '
    'Label14
    '
    Me.Label14.Location = New System.Drawing.Point(137, 273)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(88, 16)
    Me.Label14.TabIndex = 3
    Me.Label14.Text = "Description"
    '
    'TxtDesc
    '
    Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDesc.Location = New System.Drawing.Point(234, 271)
    Me.TxtDesc.MaxLength = 50
    Me.TxtDesc.Name = "TxtDesc"
    Me.TxtDesc.Size = New System.Drawing.Size(310, 20)
    Me.TxtDesc.TabIndex = 19
    '
    'TxtReason
    '
    Me.TxtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtReason.Location = New System.Drawing.Point(95, 272)
    Me.TxtReason.MaxLength = 1
    Me.TxtReason.Name = "TxtReason"
    Me.TxtReason.Size = New System.Drawing.Size(18, 20)
    Me.TxtReason.TabIndex = 18
    '
    'TpAssmnt
    '
    Me.TpAssmnt.Controls.Add(Me.LblAdjNet)
    Me.TpAssmnt.Controls.Add(Me.Label57)
    Me.TpAssmnt.Controls.Add(Me.GroupBox7)
    Me.TpAssmnt.Controls.Add(Me.GroupBox1)
    Me.TpAssmnt.Location = New System.Drawing.Point(4, 25)
    Me.TpAssmnt.Name = "TpAssmnt"
    Me.TpAssmnt.Size = New System.Drawing.Size(690, 305)
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
    Me.LblAdjNet.Location = New System.Drawing.Point(136, 123)
    Me.LblAdjNet.Name = "LblAdjNet"
    Me.LblAdjNet.Size = New System.Drawing.Size(72, 20)
    Me.LblAdjNet.TabIndex = 201
    Me.LblAdjNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label57
    '
    Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label57.ForeColor = System.Drawing.Color.Black
    Me.Label57.Location = New System.Drawing.Point(58, 127)
    Me.Label57.Name = "Label57"
    Me.Label57.Size = New System.Drawing.Size(72, 16)
    Me.Label57.TabIndex = 200
    Me.Label57.Text = "Adjusted Net"
    '
    'GroupBox7
    '
    Me.GroupBox7.Controls.Add(Me.LnkCRSaleMonth)
    Me.GroupBox7.Controls.Add(Me.LblChgCRAssmt1)
    Me.GroupBox7.Controls.Add(Me.Label31)
    Me.GroupBox7.Controls.Add(Me.Label35)
    Me.GroupBox7.Controls.Add(Me.LblOrigCRAssmt1)
    Me.GroupBox7.Controls.Add(Me.LblCRSaleNet)
    Me.GroupBox7.Controls.Add(Me.LblCRSalePct)
    Me.GroupBox7.Controls.Add(Me.TxtCRSaleMonth)
    Me.GroupBox7.Controls.Add(Me.TxtCRAssmt1)
    Me.GroupBox7.Controls.Add(Me.Label32)
    Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox7.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox7.Location = New System.Drawing.Point(270, 8)
    Me.GroupBox7.Name = "GroupBox7"
    Me.GroupBox7.Size = New System.Drawing.Size(248, 112)
    Me.GroupBox7.TabIndex = 194
    Me.GroupBox7.TabStop = False
    Me.GroupBox7.Text = "Credit Vehicle"
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
    'Label31
    '
    Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label31.ForeColor = System.Drawing.Color.Black
    Me.Label31.Location = New System.Drawing.Point(168, 16)
    Me.Label31.Name = "Label31"
    Me.Label31.Size = New System.Drawing.Size(72, 16)
    Me.Label31.TabIndex = 201
    Me.Label31.Text = "Change"
    Me.Label31.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
    'Label32
    '
    Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label32.ForeColor = System.Drawing.Color.Black
    Me.Label32.Location = New System.Drawing.Point(88, 16)
    Me.Label32.Name = "Label32"
    Me.Label32.Size = New System.Drawing.Size(72, 16)
    Me.Label32.TabIndex = 33
    Me.Label32.Text = "New"
    Me.Label32.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LnkPurchMonth)
    Me.GroupBox1.Controls.Add(Me.LblPurchNet)
    Me.GroupBox1.Controls.Add(Me.LblPurchPct)
    Me.GroupBox1.Controls.Add(Me.TxtPurchMonth)
    Me.GroupBox1.Controls.Add(Me.LnkSaleMonth)
    Me.GroupBox1.Controls.Add(Me.LblSaleNet)
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
    'LnkPurchMonth
    '
    Me.LnkPurchMonth.Location = New System.Drawing.Point(8, 67)
    Me.LnkPurchMonth.Name = "LnkPurchMonth"
    Me.LnkPurchMonth.Size = New System.Drawing.Size(88, 16)
    Me.LnkPurchMonth.TabIndex = 204
    Me.LnkPurchMonth.TabStop = True
    Me.LnkPurchMonth.Text = "Purchase Month"
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
    Me.LblPurchNet.TabIndex = 203
    Me.LblPurchNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblPurchPct
    '
    Me.LblPurchPct.ForeColor = System.Drawing.Color.Black
    Me.LblPurchPct.Location = New System.Drawing.Point(208, 68)
    Me.LblPurchPct.Name = "LblPurchPct"
    Me.LblPurchPct.Size = New System.Drawing.Size(40, 16)
    Me.LblPurchPct.TabIndex = 202
    '
    'TxtPurchMonth
    '
    Me.TxtPurchMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPurchMonth.Location = New System.Drawing.Point(96, 64)
    Me.TxtPurchMonth.MaxLength = 2
    Me.TxtPurchMonth.Name = "TxtPurchMonth"
    Me.TxtPurchMonth.Size = New System.Drawing.Size(24, 20)
    Me.TxtPurchMonth.TabIndex = 201
    Me.TxtPurchMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LnkSaleMonth
    '
    Me.LnkSaleMonth.Location = New System.Drawing.Point(16, 88)
    Me.LnkSaleMonth.Name = "LnkSaleMonth"
    Me.LnkSaleMonth.Size = New System.Drawing.Size(74, 16)
    Me.LnkSaleMonth.TabIndex = 200
    Me.LnkSaleMonth.TabStop = True
    Me.LnkSaleMonth.Text = "Sale Month"
    '
    'LblSaleNet
    '
    Me.LblSaleNet.BackColor = System.Drawing.Color.LightCyan
    Me.LblSaleNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblSaleNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblSaleNet.ForeColor = System.Drawing.Color.Black
    Me.LblSaleNet.Location = New System.Drawing.Point(128, 86)
    Me.LblSaleNet.Name = "LblSaleNet"
    Me.LblSaleNet.Size = New System.Drawing.Size(72, 16)
    Me.LblSaleNet.TabIndex = 199
    Me.LblSaleNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblSalePct
    '
    Me.LblSalePct.ForeColor = System.Drawing.Color.Black
    Me.LblSalePct.Location = New System.Drawing.Point(208, 86)
    Me.LblSalePct.Name = "LblSalePct"
    Me.LblSalePct.Size = New System.Drawing.Size(40, 16)
    Me.LblSalePct.TabIndex = 186
    '
    'TxtSaleMonth
    '
    Me.TxtSaleMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSaleMonth.Location = New System.Drawing.Point(96, 86)
    Me.TxtSaleMonth.MaxLength = 9
    Me.TxtSaleMonth.Name = "TxtSaleMonth"
    Me.TxtSaleMonth.Size = New System.Drawing.Size(24, 20)
    Me.TxtSaleMonth.TabIndex = 184
    Me.TxtSaleMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblChgAssmt1
    '
    Me.LblChgAssmt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgAssmt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgAssmt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgAssmt1.ForeColor = System.Drawing.Color.Black
    Me.LblChgAssmt1.Location = New System.Drawing.Point(176, 32)
    Me.LblChgAssmt1.Name = "LblChgAssmt1"
    Me.LblChgAssmt1.Size = New System.Drawing.Size(72, 16)
    Me.LblChgAssmt1.TabIndex = 183
    Me.LblChgAssmt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label23
    '
    Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label23.ForeColor = System.Drawing.Color.Black
    Me.Label23.Location = New System.Drawing.Point(174, 16)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(74, 16)
    Me.Label23.TabIndex = 37
    Me.Label23.Text = "Change"
    Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label18
    '
    Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label18.ForeColor = System.Drawing.Color.Black
    Me.Label18.Location = New System.Drawing.Point(16, 16)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(74, 16)
    Me.Label18.TabIndex = 36
    Me.Label18.Text = "Original"
    Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'TxtAssmt1
    '
    Me.TxtAssmt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt1.Location = New System.Drawing.Point(96, 32)
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
    Me.Label17.Location = New System.Drawing.Point(96, 16)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(72, 16)
    Me.Label17.TabIndex = 33
    Me.Label17.Text = "Value"
    Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'LblOrigAssmt1
    '
    Me.LblOrigAssmt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigAssmt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigAssmt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigAssmt1.ForeColor = System.Drawing.Color.Black
    Me.LblOrigAssmt1.Location = New System.Drawing.Point(16, 32)
    Me.LblOrigAssmt1.Name = "LblOrigAssmt1"
    Me.LblOrigAssmt1.Size = New System.Drawing.Size(72, 16)
    Me.LblOrigAssmt1.TabIndex = 22
    Me.LblOrigAssmt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TpExemptions
    '
    Me.TpExemptions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.TpExemptions.Controls.Add(Me.GroupBox4)
    Me.TpExemptions.Location = New System.Drawing.Point(4, 25)
    Me.TpExemptions.Name = "TpExemptions"
    Me.TpExemptions.Size = New System.Drawing.Size(690, 305)
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
    Me.LblChgExam5.Size = New System.Drawing.Size(64, 16)
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
    Me.LblChgExam4.Size = New System.Drawing.Size(64, 16)
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
    Me.LblChgExam3.Size = New System.Drawing.Size(64, 16)
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
    Me.LblChgExam2.Size = New System.Drawing.Size(64, 16)
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
    Me.LblChgExam1.Size = New System.Drawing.Size(64, 16)
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
    Me.LblOrigExam5.Size = New System.Drawing.Size(64, 16)
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
    Me.LblOrigExam4.Size = New System.Drawing.Size(64, 16)
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
    Me.LblOrigExam3.Size = New System.Drawing.Size(64, 16)
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
    Me.LblOrigExam2.Size = New System.Drawing.Size(64, 16)
    Me.LblOrigExam2.TabIndex = 190
    Me.LblOrigExam2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label58
    '
    Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label58.ForeColor = System.Drawing.Color.Black
    Me.Label58.Location = New System.Drawing.Point(74, 16)
    Me.Label58.Name = "Label58"
    Me.Label58.Size = New System.Drawing.Size(62, 16)
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
    Me.LblOrigExam1.Size = New System.Drawing.Size(64, 16)
    Me.LblOrigExam1.TabIndex = 183
    Me.LblOrigExam1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LnkExempt5
    '
    Me.LnkExempt5.AutoSize = True
    Me.LnkExempt5.Location = New System.Drawing.Point(13, 131)
    Me.LnkExempt5.Name = "LnkExempt5"
    Me.LnkExempt5.Size = New System.Drawing.Size(13, 13)
    Me.LnkExempt5.TabIndex = 178
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
    Me.LnkExempt3.AutoSize = True
    Me.LnkExempt3.Location = New System.Drawing.Point(13, 83)
    Me.LnkExempt3.Name = "LnkExempt3"
    Me.LnkExempt3.Size = New System.Drawing.Size(13, 13)
    Me.LnkExempt3.TabIndex = 176
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
    Me.LnkExempt4.AutoSize = True
    Me.LnkExempt4.Location = New System.Drawing.Point(13, 107)
    Me.LnkExempt4.Name = "LnkExempt4"
    Me.LnkExempt4.Size = New System.Drawing.Size(13, 13)
    Me.LnkExempt4.TabIndex = 177
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
    Me.LnkExempt2.AutoSize = True
    Me.LnkExempt2.Location = New System.Drawing.Point(13, 59)
    Me.LnkExempt2.Name = "LnkExempt2"
    Me.LnkExempt2.Size = New System.Drawing.Size(13, 13)
    Me.LnkExempt2.TabIndex = 175
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
    Me.LnkExempt1.AutoSize = True
    Me.LnkExempt1.Location = New System.Drawing.Point(13, 35)
    Me.LnkExempt1.Name = "LnkExempt1"
    Me.LnkExempt1.Size = New System.Drawing.Size(13, 13)
    Me.LnkExempt1.TabIndex = 174
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
    Me.Label50.Size = New System.Drawing.Size(72, 16)
    Me.Label50.TabIndex = 38
    Me.Label50.Text = "New"
    Me.Label50.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label52
    '
    Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label52.ForeColor = System.Drawing.Color.Black
    Me.Label52.Location = New System.Drawing.Point(23, 16)
    Me.Label52.Name = "Label52"
    Me.Label52.Size = New System.Drawing.Size(43, 13)
    Me.Label52.TabIndex = 35
    Me.Label52.Text = "Code"
    Me.Label52.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(160, 4)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(56, 16)
    Me.Label9.TabIndex = 172
    Me.Label9.Text = "Tax Year"
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Location = New System.Drawing.Point(100, 48)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(280, 20)
    Me.TxtName.TabIndex = 0
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(13, 51)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(48, 16)
    Me.Label5.TabIndex = 165
    Me.Label5.Text = "Name"
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(12, 144)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(80, 16)
    Me.Label4.TabIndex = 169
    Me.Label4.Text = "City/State/Zip"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(256, 4)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 16)
    Me.Label1.TabIndex = 166
    Me.Label1.Text = "List No"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblCCNo
    '
    Me.LblCCNo.Location = New System.Drawing.Point(96, 4)
    Me.LblCCNo.Name = "LblCCNo"
    Me.LblCCNo.Size = New System.Drawing.Size(48, 16)
    Me.LblCCNo.TabIndex = 178
    '
    'LblListNo
    '
    Me.LblListNo.Location = New System.Drawing.Point(304, 4)
    Me.LblListNo.Name = "LblListNo"
    Me.LblListNo.Size = New System.Drawing.Size(66, 16)
    Me.LblListNo.TabIndex = 179
    '
    'LblCCDate
    '
    Me.LblCCDate.Location = New System.Drawing.Point(520, 4)
    Me.LblCCDate.Name = "LblCCDate"
    Me.LblCCDate.Size = New System.Drawing.Size(64, 16)
    Me.LblCCDate.TabIndex = 177
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(12, 96)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(80, 16)
    Me.Label3.TabIndex = 168
    Me.Label3.Text = "Street Address"
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(456, 4)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(56, 16)
    Me.Label13.TabIndex = 176
    Me.Label13.Text = "C/C Date"
    '
    'Label12
    '
    Me.Label12.Location = New System.Drawing.Point(376, 4)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(32, 16)
    Me.Label12.TabIndex = 174
    Me.Label12.Text = "Type"
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(8, 4)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(48, 16)
    Me.Label8.TabIndex = 171
    Me.Label8.Text = "C/C No"
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(444, 48)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(32, 20)
    Me.TxtDist.TabIndex = 1
    Me.TxtDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblOrigName
    '
    Me.LblOrigName.Location = New System.Drawing.Point(102, 24)
    Me.LblOrigName.Name = "LblOrigName"
    Me.LblOrigName.Size = New System.Drawing.Size(280, 16)
    Me.LblOrigName.TabIndex = 181
    '
    'Label15
    '
    Me.Label15.Location = New System.Drawing.Point(13, 24)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(79, 18)
    Me.Label15.TabIndex = 180
    Me.Label15.Text = "Original Name"
    '
    'TxtResZip4
    '
    Me.TxtResZip4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
    Me.TxtResZip4.Location = New System.Drawing.Point(426, 219)
    Me.TxtResZip4.MaxLength = 4
    Me.TxtResZip4.Name = "TxtResZip4"
    Me.TxtResZip4.Size = New System.Drawing.Size(42, 20)
    Me.TxtResZip4.TabIndex = 193
    '
    'TxtResZip5
    '
    Me.TxtResZip5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
    Me.TxtResZip5.Location = New System.Drawing.Point(375, 220)
    Me.TxtResZip5.MaxLength = 5
    Me.TxtResZip5.Name = "TxtResZip5"
    Me.TxtResZip5.Size = New System.Drawing.Size(45, 20)
    Me.TxtResZip5.TabIndex = 192
    '
    'TxtResAdd1
    '
    Me.TxtResAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtResAdd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtResAdd1.Location = New System.Drawing.Point(99, 170)
    Me.TxtResAdd1.MaxLength = 35
    Me.TxtResAdd1.Name = "TxtResAdd1"
    Me.TxtResAdd1.Size = New System.Drawing.Size(281, 20)
    Me.TxtResAdd1.TabIndex = 189
    '
    'TxtResState
    '
    Me.TxtResState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtResState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
    Me.TxtResState.Location = New System.Drawing.Point(340, 219)
    Me.TxtResState.MaxLength = 2
    Me.TxtResState.Name = "TxtResState"
    Me.TxtResState.Size = New System.Drawing.Size(24, 20)
    Me.TxtResState.TabIndex = 191
    '
    'TxtResCity
    '
    Me.TxtResCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtResCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
    Me.TxtResCity.Location = New System.Drawing.Point(100, 219)
    Me.TxtResCity.MaxLength = 25
    Me.TxtResCity.Name = "TxtResCity"
    Me.TxtResCity.Size = New System.Drawing.Size(232, 20)
    Me.TxtResCity.TabIndex = 190
    '
    'Label37
    '
    Me.Label37.Location = New System.Drawing.Point(12, 223)
    Me.Label37.Name = "Label37"
    Me.Label37.Size = New System.Drawing.Size(88, 16)
    Me.Label37.TabIndex = 195
    Me.Label37.Text = "Dom City/St/Zip"
    '
    'Label48
    '
    Me.Label48.Location = New System.Drawing.Point(11, 174)
    Me.Label48.Name = "Label48"
    Me.Label48.Size = New System.Drawing.Size(88, 16)
    Me.Label48.TabIndex = 194
    Me.Label48.Text = "Domicile Addr"
    '
    'TxtResAdd2
    '
    Me.TxtResAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtResAdd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
    Me.TxtResAdd2.Location = New System.Drawing.Point(99, 191)
    Me.TxtResAdd2.MaxLength = 35
    Me.TxtResAdd2.Name = "TxtResAdd2"
    Me.TxtResAdd2.Size = New System.Drawing.Size(281, 20)
    Me.TxtResAdd2.TabIndex = 196
    '
    'FrmTA8105R
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(947, 580)
    Me.Controls.Add(Me.TxtResAdd2)
    Me.Controls.Add(Me.TxtResZip4)
    Me.Controls.Add(Me.TxtResZip5)
    Me.Controls.Add(Me.TxtResAdd1)
    Me.Controls.Add(Me.TxtResState)
    Me.Controls.Add(Me.TxtResCity)
    Me.Controls.Add(Me.Label37)
    Me.Controls.Add(Me.Label48)
    Me.Controls.Add(Me.LblOrigName)
    Me.Controls.Add(Me.Label15)
    Me.Controls.Add(Me.TxtState)
    Me.Controls.Add(Me.TxtAdd1)
    Me.Controls.Add(Me.TxtAdd2)
    Me.Controls.Add(Me.TxtSname)
    Me.Controls.Add(Me.TxtZip5)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.TxtZip4)
    Me.Controls.Add(Me.TxtCity)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Label42)
    Me.Controls.Add(Me.LblType)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TabControl1)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LblCCNo)
    Me.Controls.Add(Me.LblListNo)
    Me.Controls.Add(Me.LblCCDate)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.Label8)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA8105R"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Certificate of Change - Supplemental Motor Vehicle "
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.TabControl1.ResumeLayout(False)
    Me.TpMain.ResumeLayout(False)
    Me.TpMain.PerformLayout()
    Me.GroupBox6.ResumeLayout(False)
    Me.GroupBox6.PerformLayout()
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.TpAssmnt.ResumeLayout(False)
    Me.GroupBox7.ResumeLayout(False)
    Me.GroupBox7.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.TpExemptions.ResumeLayout(False)
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region
  Private Sub FrmTA8105R_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkAttachCount As Integer
    Dim WrkDBDate As Integer
    Dim WrkDBTime As Integer
    Dim WrkDist As Integer
    Dim WrkPurchProrate As Integer
    Dim WrkPurchAdjNet As Integer
    Dim WrkPurchPct As Single
    Dim WrkPurchMonth As Integer
    Dim WrkCRSaleProrate As Integer
    Dim WrkCRSaleAdjNet As Integer
    Dim WrkCRSalePct As Single
    Dim WrkCRSaleMonth As Integer
    'Dim WrkPct As Double
    'Dim WrkSaleMonth As Integer
    Dim CoeCCNo As Integer

    myTXCOEB = New TXCOEB.MyData(myDBConnect)
    myTXCOEBL4 = New TXCOEBL4.MyData(myDBConnect)
    myTXSUPPC = New TXSUPPC.MyData(myDBConnect)
    myTXSUPPCL1 = New TXSUPPCL1.MyData(myDBConnect)
    myTXSUPA = New TXSUPA.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXVCUS = New TXVCUS.MyData(myDBConnect)
    myTXVEH = New TXVEH.MyData(myDBConnect)
    myTXMCTL = New TXMCTL.MyData(myDBConnect)
    myTXMSRP = New TXMSRP.MyData(myDBConnect)
    myTXMSRPDEP = New TXMSRPDEP.MyData(myDBConnect)
    myTXMSRPCD = New TXMSRPCD.MyData(myDBConnect)
    LoadScrn = True
    LblPDMsg.Text = ""
    LblCRPDMsg.Text = ""

    If MyBookPct = 0 Then
      myTXMCTL.GetOneRecordP(1)
      If Not myTXMCTL.RecordNotFound Then
        With myTXMCTL
          MyBookPct = ._VALPER
          MyMinValue = ._VALMIN
        End With
      End If
    End If

    With MyFrmTA810
      .TBarNew.Enabled = False
      .TBarSave.Enabled = True
      .TBarHist.Enabled = False
      .TBarPrinters.Enabled = False
      If WrkCCNo > 0 Then
        .TBarAttach.Enabled = True
      End If
    End With
    WrkAttachCount = GetAttachcount(“CCBEFORE”, WrkCCNo)
    MyFrmTA810.TBarAttach.Text = WrkAttachCount & " Attachment(s)"

    'On New, Check for existing C/C done today. If found, then change to update mode. 
    If WrkCCNo = 0 Then
      WrkDBDate = MyUtils.SetDBDate(Date.Today)
      dsTXCOEBL4 = myTXCOEBL4.GetLastbyDate(WrkListNo, WrkYear, WrkType, WrkDBDate)
      If dsTXCOEBL4.Tables(0).Rows.Count > 0 Then
        With dsTXCOEBL4.Tables(0).Rows(0)
          If WrkDBDate = .Item("cdate") Then
            WrkCCNo = .Item("ccno")
            MsgBox("New C/C was not created. Click OK to change existing C/C done today instead.", MsgBoxStyle.Information, "Existing C/C found with today's date")
            WrkAddMode = False
          End If
        End With
      End If
    End If

    'Fill the dataset with the data
    If Not WrkAddMode Then
      LblCCNo.Text = WrkCCNo
      Me.Text = "Maintain " & Me.Text
      myTXCOEB.GetOneRecordP(WrkCCNo)
      If myTXCOEB.RecordNotFound Then
        MyFrmTA810.TBarNew.Enabled = False
        MyFrmTA810.TBarSave.Enabled = False
        MyFrmTA810.TBarDelete.Enabled = False
        Me.ErrProv.SetError(LblCCNo, "Record not found")
        Exit Sub
      End If
      MyFrmTA810.TBarPrint.Enabled = True
      GetTXCOEB()
      If LblCCDate.Text <> Date.Today Then
        Me.ErrProv.SetError(LblCCNo, "Cannot edit (not same date)")
        MyFrmTA810.TBarSave.Enabled = False
      End If
    Else
      Me.Text = "Add " & Me.Text
      If MyOpenCC Then
        LblCCNo.Text = WrkCCNo
        LblCCDate.Text = WrkCCDate
      Else
        LblCCDate.Text = Date.Today
      End If
      MyFrmTA810.TBarDelete.Enabled = False
      If WrkListNo > 0 Then
        LblListNo.Text = WrkListNo
      End If
      LblYear.Text = WrkYear
      LblType.Text = WrkType
    End If

    WrkDist = MyUtils.CnvSng(TxtDist.Text)
    CoeCCNo = 0
    If WrkCCNo > 0 Then
      WrkDBDate = MyUtils.SetDBDate(LblCCDate.Text) - 1
      WrkDBTime = 999999
    Else
      LblCCDate.Text = Date.Today
      WrkDBDate = MyUtils.SetDBDate(Date.Today) - 1
      WrkDBTime = 999999
    End If
    dsTXCOEBL4 = myTXCOEBL4.GetViewDescList(WrkListNo, WrkYear, WrkType, WrkDBDate,
        WrkDBTime, 50)
    If dsTXCOEBL4.Tables(0).Rows.Count > 0 Then
      With dsTXCOEBL4.Tables(0).Rows(0)
        If WrkCCNo <> .Item("ccno") Then
          CoeCCNo = .Item("ccno")
        End If
      End With
    End If

    'Current Year
    'MK 9/26/25 Begin
    'If WrkYear = MyGLYear Then
    If WrkYear = MySuppYear Then
      'MK 9/26/25 End
      myTXSUPPC.GetOneRecordP(WrkListNo)
      If Not myTXSUPPC.RecordNotFound Then
        With myTXSUPPC
          If ._CAT = "1" Then
            RbCatTaxable.Checked = True
          Else
            RbCatExempt.Checked = True
          End If
          TxtName.Text = Trim(._NAME)
          TxtSname.Text = Trim(._SNAME)
          TxtAdd1.Text = Trim(._ADD1)
          TxtAdd2.Text = Trim(._ADD2)
          TxtCity.Text = Trim(._CITY)
          TxtState.Text = Trim(._STATE)
          TxtZip5.Text = Format(._ZIP5, "00000")
          TxtZip4.Text = Format(._ZIP4, "0000")
          '09/12/25 Ken added 
          TxtResAdd1.Text = Trim(._RAD1)
          TxtResAdd2.Text = Trim(._RAD2)
          TxtResCity.Text = Trim(._RCTY)
          TxtResState.Text = Trim(._RST)
          TxtResZip5.Text = Format(._RZ5, "00000")
          TxtResZip4.Text = Format(._RZ4, "0000")
          'end add 

          'Current Vehicle
          TxtID.Text = Trim(._VINNO)
          TxtReg.Text = Trim(._REGNO)
          TxtClass.Text = ._CLASS
          TxtMVYear.Text = ._YEAR
          TxtMake.Text = Trim(._MAKE)
          TxtModel.Text = Trim(._MODEL)
          If ._SSNO > 0 Then
            TxtSSNo.Text = ._SSNO
          End If
          If ._SS2 > 0 Then
            TxtSS2.Text = ._SS2
          End If
          TxtOid.Text = Trim(._OID)
          'MK Add MSRP calcs
          LblMSRP.Text = ._MSRP
          ChkComplete.Checked = False
          TxtOVMSRP.Text = ""
          myTXMSRP.GetOneRecordP(Trim(._VINNO))
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
          CalcValue(._MSRP, MyUtils.CnvSng(TxtOVMSRP.Text), ._YEAR, False) 'populate LblMSRPCalc

          'Credit Vehicle
          TxtCRID.Text = Trim(._OVIN)
          TxtCRReg.Text = Trim(._OREGNO)
          TxtCRClass.Text = ._OCLS
          TxtCRMVYear.Text = ._OYEAR
          TxtCRMake.Text = Trim(._OMAKE)
          TxtCRModel.Text = Trim(._OMOD)
          'MK Add MSRP calcs
          LblCRMSRP.Text = ""
          ChkCRComplete.Checked = False
          TxtCROVMSRP.Text = ""
          myTXMSRP.GetOneRecordP(Trim(._OVIN))
          With myTXMSRP
            If Not .RecordNotFound Then
              If Trim(._OVSOURCE) <> "" Then
                TxtCROVMSRP.Text = ._OVMSRP
                TxtCRSource.Text = Trim(._OVSOURCE)
              End If
              If ._COMPLETE = "Y" Then
                ChkCRComplete.Checked = True
              End If
            End If
          End With
          LblCRMSRPCalc.Text = ""
          If ._OYEAR > 0 Then
            CalcValue(0, MyUtils.CnvSng(TxtCROVMSRP.Text), ._OYEAR, True) 'populate LblCRMSRPCalc
          End If

          If CoeCCNo = 0 Then
            LblOrigAdjGross.Text = "0"
            If ._OPVAL > 0 Then
              CalcProrateCode("C", Trim(._ASS), ._VALUE, WrkPurchProrate,
                WrkPurchAdjNet, WrkPurchPct, WrkPurchMonth)
            Else
              CalcProrateCode("P", Trim(._ASS), ._VALUE, WrkPurchProrate,
                WrkPurchAdjNet, WrkPurchPct, WrkPurchMonth)
            End If
            LblOrigProrate.Text = FormatNumber(WrkPurchProrate, 0)
            CalcProrateCode("C", Trim(._OASS), ._PVAL, WrkCRSaleProrate,
              WrkCRSaleAdjNet, WrkCRSalePct, WrkCRSaleMonth)
            If WrkCRSaleAdjNet > WrkPurchAdjNet Then
              LblOrigAdjGross.Text = FormatNumber(WrkPurchAdjNet, 0)
            Else
              LblOrigAdjGross.Text = FormatNumber(WrkCRSaleAdjNet, 0)
            End If
            LblOrigGross.Text = FormatNumber(._VALUE + ._BTR, 0)
            LblOrigExam.Text = FormatNumber(._EXAM1 + ._EXAM2 + ._EXAM3 +
                ._EXAM4 + ._EXAM5, 0)
            LblOrigNet.Text = FormatNumber(MyUtils.CnvSng(LblOrigGross.Text) - MyUtils.CnvSng(LblOrigProrate.Text) -
                MyUtils.CnvSng(LblOrigExam.Text), 0)
            LblOrigAssmt1.Text = ._VALUE + ._BTR
            LblOrigExam1.Text = ._EXAM1
            LblOrigExam2.Text = ._EXAM2
            LblOrigExam3.Text = ._EXAM3
            LblOrigExam4.Text = ._EXAM4
            LblOrigExam5.Text = ._EXAM5
            TxtAssmt1.Text = ._CCGRS
            TxtPurchMonth.Text = WrkPurchMonth
            LblPurchPct.Text = WrkPurchPct
            LblPurchNet.Text = WrkPurchAdjNet
            TxtCRSaleMonth.Text = WrkCRSaleMonth
            LblCRSalePct.Text = WrkCRSalePct
            LblCRSaleNet.Text = WrkCRSaleAdjNet
            LblAdjNet.Text = WrkPurchAdjNet - WrkCRSaleAdjNet
            'Only get Exemptions if there was none loaded from the c/c
            If Trim(._EXCD1) <> "" Then
              TxtExempt1.Text = Trim(._EXCD1)
            End If
            If Trim(._EXCD2) <> "" Then
              TxtExempt2.Text = Trim(._EXCD2)
            End If
            If Trim(._EXCD3) <> "" Then
              TxtExempt3.Text = Trim(._EXCD3)
            End If
            If Trim(._EXCD4) <> "" Then
              TxtExempt4.Text = Trim(._EXCD4)
            End If
            If Trim(._EXCD5) <> "" Then
              TxtExempt5.Text = Trim(._EXCD5)
            End If
            SetExem1Tip()
            SetExem2Tip()
            SetExem3Tip()
            SetExem4Tip()
            SetExem5Tip()
            TxtExam1.Text = ._CEXA1
            TxtExam2.Text = ._CEXA2
            TxtExam3.Text = ._CEXA3
            TxtExam4.Text = ._CEXA4
            TxtExam5.Text = ._CEXA5
            LblNewExam.Text = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 +
                ._EXAM5
            LblNewNet.Text = MyUtils.CnvSng(LblNewGross.Text) - MyUtils.CnvSng(LblNewExam.Text)
          End If
        End With
      End If
    End If

    'Previous Years
    'MK 9/26/25 Begin
    'If WrkYear <> MyGLYear Then
    If WrkYear <> MySuppYear Then
      'MK 9/26/25 End
      myTXSUPA.GetOneRecordP(WrkListNo, WrkYear)
      If Not myTXSUPA.RecordNotFound Then
        With myTXSUPA
          If ._CAT = "1" Then
            RbCatTaxable.Checked = True
          Else
            RbCatExempt.Checked = True
          End If
          TxtName.Text = Trim(._NAME)
          TxtSname.Text = Trim(._SNAME)
          TxtAdd1.Text = Trim(._ADD1)
          TxtAdd2.Text = Trim(._ADD2)
          TxtCity.Text = Trim(._CITY)
          TxtState.Text = Trim(._STATE)
          TxtZip5.Text = Format(._ZIP5, "00000")
          TxtZip4.Text = Format(._ZIP4, "0000")
          '09/12/25 Ken added 
          TxtResAdd1.Text = Trim(._RAD1)
          TxtResAdd2.Text = Trim(._RAD2)
          TxtResCity.Text = Trim(._RCTY)
          TxtResState.Text = Trim(._RST)
          TxtResZip5.Text = Format(._RZ5, "00000")
          TxtResZip4.Text = Format(._RZ4, "0000")
          'end add 
          TxtID.Text = Trim(._VINNO)
          TxtReg.Text = Trim(._REGNO)
          TxtClass.Text = ._CLASS
          TxtMVYear.Text = ._YEAR
          TxtMake.Text = Trim(._MAKE)
          TxtModel.Text = Trim(._MODEL)
          If ._SSNo > 0 Then
            TxtSSNo.Text = ._SSNo
          End If
          If ._SS2 > 0 Then
            TxtSS2.Text = ._SS2
          End If
          TxtOid.Text = Trim(._OID)
          LblMSRP.Text = ._MSRP
          ChkComplete.Checked = False
          TxtOVMSRP.Text = ""
          myTXMSRP.GetOneRecordP(Trim(._VINNO))
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
          CalcValue(._MSRP, MyUtils.CnvSng(TxtOVMSRP.Text), ._YEAR, False) 'populate LblMSRPCalc
          If CoeCCNo = 0 Then
            LblOrigAdjGross.Text = "0"
            If ._OPVAL > 0 Then
              CalcProrateCode("C", Trim(._ASS), ._VALUE, WrkPurchProrate,
                WrkPurchAdjNet, WrkPurchPct, WrkPurchMonth)
            Else
              CalcProrateCode("P", Trim(._ASS), ._VALUE, WrkPurchProrate,
                WrkPurchAdjNet, WrkPurchPct, WrkPurchMonth)
            End If
            LblOrigProrate.Text = FormatNumber(WrkPurchProrate, 0)
            CalcProrateCode("C", Trim(._OASS), ._PVAL, WrkCRSaleProrate,
              WrkCRSaleAdjNet, WrkCRSalePct, WrkCRSaleMonth)
            If WrkCRSaleAdjNet > WrkPurchAdjNet Then
              LblOrigAdjGross.Text = FormatNumber(WrkPurchAdjNet, 0)
            Else
              LblOrigAdjGross.Text = FormatNumber(WrkCRSaleAdjNet, 0)
            End If
            LblOrigGross.Text = FormatNumber(._VALUE + ._BTR, 0)
            LblOrigExam.Text = FormatNumber(._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5, 0)
            LblOrigNet.Text = FormatNumber(MyUtils.CnvSng(LblOrigGross.Text) - MyUtils.CnvSng(LblOrigProrate.Text) _
               - MyUtils.CnvSng(LblOrigExam.Text), 0)
            LblOrigAssmt1.Text = ._VALUE + ._BTR
            LblOrigExam1.Text = ._EXAM1
            LblOrigExam2.Text = ._EXAM2
            LblOrigExam3.Text = ._EXAM3
            LblOrigExam4.Text = ._EXAM4
            LblOrigExam5.Text = ._EXAM5
            'Exemption Codes
            If WrkAddMode Then
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
              TxtExam1.Text = ._EXAM1
              TxtExam2.Text = ._EXAM2
              TxtExam3.Text = ._EXAM3
              TxtExam4.Text = ._EXAM4
              TxtExam5.Text = ._EXAM5
              LblNewExam.Text = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 +
                  ._EXAM5
              LblNewNet.Text = MyUtils.CnvSng(LblNewGross.Text) - MyUtils.CnvSng(LblNewExam.Text)
            End If
          End If
        End With
      Else
        myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
        If Not myTXINV.RecordNotFound Then
          With myTXINV
            RbCatTaxable.Checked = True
            TxtName.Text = Trim(._NAME)
            TxtSname.Text = Trim(._SNAME)
            TxtAdd1.Text = Trim(._ADD1)
            TxtAdd2.Text = Trim(._ADD2)
            TxtCity.Text = Trim(._CITY)
            TxtState.Text = Trim(._STATE)
            TxtZip5.Text = Format(._ZIP5, "00000")
            TxtZip4.Text = Format(._ZIP4, "0000")
            '09/12/25 Ken added     would need to add the fields to Txinv
            'TxtResAdd1.Text = Trim(._RAD1)
            'TxtResAdd2.Text = Trim(._RAD2)
            'TxtResCity.Text = Trim(._RCTY)
            'TxtResState.Text = Trim(._RST)
            'TxtResZip5.Text = Format(._RZ5, "00000")
            'TxtResZip4.Text = Format(._RZ4, "0000")
            'end add 
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
            CalcValue(0, MyUtils.CnvSng(TxtOVMSRP.Text), ._YEAR, False) 'populate LblMSRPCalc
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
          End With
        End If
      End If
    End If

    If CoeCCNo > 0 Then
      GetOrigTxCOEB(CoeCCNo)
    End If

    If WrkAddMode Then
      TxtAssmt1.Text = MyUtils.CnvSng(LblOrigAssmt1.Text)
      LblValue.Text = MyUtils.CnvSng(LblOrigAssmt1.Text)
      TxtExam1.Text = MyUtils.CnvSng(LblOrigExam1.Text)
      TxtExam2.Text = MyUtils.CnvSng(LblOrigExam2.Text)
      TxtExam3.Text = MyUtils.CnvSng(LblOrigExam3.Text)
      TxtExam4.Text = MyUtils.CnvSng(LblOrigExam4.Text)
      TxtExam5.Text = MyUtils.CnvSng(LblOrigExam5.Text)
    End If

    dsTXCOEBL4 = myTXCOEBL4.GetViewbyList(WrkListNo, WrkYear, WrkType, 50)
    If dsTXCOEBL4.Tables(0).Rows.Count > 1 Then
      MyFrmTA810.TBarHist.Enabled = True
    End If

    LoadScrn = False
    CalcChg()
  End Sub

  Private Sub FrmTA8105R_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    With MyFrmTA810
      .TBarNew.Enabled = True
      .TBarSave.Enabled = False
      .TBarDelete.Enabled = False
      .TBarHist.Enabled = False
      .TBarPrint.Enabled = False
      .TBarPrinters.Enabled = True
      .TBarAttach.Enabled = False
      .TBarAttach.Text = "Attachments"
    End With
    MyFrmTA8101R.FormatGrid(True)
    MyFrmTA8101R.Show()

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    myTXCOEB.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String

NextCC:
    If WrkAddMode And Not MyOpenCC Then
      WrkCCNo = NextControlCCNo()
    End If

    myTXCOEB.GetOneRecordP(WrkCCNo)
    If WrkAddMode Then
      If Not myTXCOEB.RecordNotFound Then
        GoTo NextCC
      End If
    End If

    If WrkAddMode Then
      If MyUtils.CnvSng(LblListNo.Text) = 0 Then
        WrkListNo = NextListNo()
        LblListNo.Text = WrkListNo
      End If
    End If

    SetExem1Tip()
    SetExem2Tip()
    SetExem3Tip()
    SetExem4Tip()
    SetExem5Tip()

    EditChecks(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If

    myTXSUPPC.GetOneRecordP(WrkListNo)
    MoveToFile()
    If Not WrkAddMode Then
      myTXCOEB.UpdateOneRecordP()
      If myTXCOEB.ErrMsg <> "" Then
        WriteErrorLog(myTXCOEB.ErrMsg)
        Exit Sub
      End If
    Else
      myTXCOEB.AddOneRecordP()
      If myTXCOEB.ErrMsg <> "" Then
        WriteErrorLog(myTXCOEB.ErrMsg)
        Exit Sub
      End If
    End If

    If Not myTXSUPPC.RecordNotFound Then
      myTXSUPPC.UpdateOneRecordP()
      If myTXSUPPC.ErrMsg <> "" Then
        WriteErrorLog(myTXSUPPC.ErrMsg)
        Exit Sub
      End If
    Else
      WrkListNo = MyUtils.CnvSng(LblListNo.Text)
      WrkYear = MyUtils.CnvSng(LblYear.Text)
      myTXSUPPC.AddOneRecordP()
      If myTXSUPPC.ErrMsg <> "" Then
        WriteErrorLog(myTXSUPPC.ErrMsg)
        Exit Sub
      End If
    End If

    If Trim(TxtSSNo.Text) <> "" Then
      With myTXVCUS
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
          If .ErrMsg <> "" Then
            WriteErrorLog(.ErrMsg)
            Exit Sub
          End If
        End If
      End With
    End If

    If Trim(TxtSS2.Text) <> "" Then
      With myTXVCUS
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
          If .ErrMsg <> "" Then
            WriteErrorLog(.ErrMsg)
            Exit Sub
          End If
        End If
      End With
    End If

    If Trim(TxtOid.Text) <> "" Then
      With myTXVEH
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
          If .ErrMsg <> "" Then
            WriteErrorLog(.ErrMsg)
            Exit Sub
          End If
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
      MsgBox("C/C number is " & WrkCCNo & ", List# " & WrkListNo)
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
    Dim WrkDesc As String
    With myTXCOEB
      ._CCNO = WrkCCNo
      ._LISTNo = WrkListNo
      ._CYEAR = WrkYear
      ._CTYPE = WrkType
      ._NAME = TxtName.Text
      ._CGRSCH = MyUtils.CnvSng(LblChgGross.Text)
      ._EXCHG = MyUtils.CnvSng(LblChgExam.Text) * -1
      ._CGRS = MyUtils.CnvSng(LblNewGross.Text)
      ._CDATE = MyUtils.SetDBDate(LblCCDate.Text)
      ._RSNCD = TxtReason.Text
      If RbCatTaxable.Checked Then
        ._CATG = "1"
      Else
        ._CATG = "3"
      End If
      ._CT2MC1 = ""
      With MyGetTXMVPCT
        .GetTXMVPCTL1("M", MyUtils.CnvSng(TxtSaleMonth.Text))
        myTXCOEB._CT2MC1 = .Code
      End With
      'Reason Codes
      WrkDesc = GetTXCResnDesc(._RSNCD)
      Ttp1.SetToolTip(TxtReason, WrkDesc)
      ._CDESC = TxtDesc.Text
      ._NTASS1 = MyUtils.CnvSng(TxtAssmt1.Text)
      ._NTECD1 = TxtExempt1.Text
      ._NTEX1 = MyUtils.CnvSng(TxtExam1.Text)
      ._NTECD2 = TxtExempt2.Text
      ._NTEX2 = MyUtils.CnvSng(TxtExam2.Text)
      ._NTECD3 = TxtExempt3.Text
      ._NTEX3 = MyUtils.CnvSng(TxtExam3.Text)
      ._NTECD4 = TxtExempt4.Text
      ._NTEX4 = MyUtils.CnvSng(TxtExam4.Text)
      ._NTECD5 = TxtExempt5.Text
      ._NTEX5 = MyUtils.CnvSng(TxtExam5.Text)
      ._NTNET = MyUtils.CnvSng(LblNewNet.Text)
      ._PRF = Mid(MyUserID, 1, 10)
      ._CHDATE = MyUtils.SetDBDate(DateTime.Today)
      ._CHTIME = Format(DateTime.Now, "hhmmss")
    End With

    With myTXSUPPC
      ._TYPE = WrkType
      If RbCatTaxable.Checked Then
        ._CAT = "1"
      Else
        ._CAT = "3"
      End If
      ._LISTNO = WrkListNo
      ._NAME = TxtName.Text
      ._LETT = Mid$(TxtName.Text, 1, 1)
      ._SNAME = TxtSname.Text
      ._ADD1 = TxtAdd1.Text
      ._ADD2 = TxtAdd2.Text
      ._CITY = TxtCity.Text
      ._STATE = TxtState.Text
      ._ZIP5 = MyUtils.CnvSng(TxtZip5.Text)
      ._ZIP4 = MyUtils.CnvSng(TxtZip4.Text)
      'added 09/12/25  ken
      ._RAD1 = TxtResAdd1.Text
      ._RAD2 = TxtResAdd2.Text
      ._RCTY = TxtResCity.Text
      ._RST = TxtResState.Text
      ._RZ5 = MyUtils.CnvSng(TxtResZip5.Text)
      ._RZ4 = MyUtils.CnvSng(TxtResZip4.Text)
      'end add 09/12/25 ken
      ._DIST = MyUtils.CnvSng(TxtDist.Text)
      ._VINNO = TxtID.Text
      ._REGNO = TxtReg.Text
      ._CLASS = MyUtils.CnvSng(TxtClass.Text)
      ._YEAR = MyUtils.CnvSng(TxtMVYear.Text)
      ._MAKE = TxtMake.Text
      ._MODEL = TxtModel.Text
      ._SSNO = MyUtils.CnvSng(TxtSSNo.Text)
      ._SS2 = MyUtils.CnvSng(TxtSS2.Text)
      ._OID = TxtOid.Text
      ._CCNO = WrkCCNo
      ._CDATE = MyUtils.SetDBDate(LblCCDate.Text)
      ._CCGRS = MyUtils.CnvSng(LblNewGross.Text)
      ._CCEX = MyUtils.CnvSng(LblNewExam.Text)
      ._CCRS = TxtReason.Text
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
    End With
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.Clear()

    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
        Case "list#"
          ErrProv.SetError(LblListNo, ErrorMsg(I))
        Case "name"
          ErrProv.SetError(TxtName, ErrorMsg(I))
        Case "rsncd"
          ErrProv.SetError(TxtReason, ErrorMsg(I))
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
        Case "source"
          ErrProv.SetError(TxtSource, ErrorMsg(I))
        Case "vin"
          ErrProv.SetError(TxtID, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I

  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim Answer As Integer
    Dim WrkTip As String
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If WrkAddMode Then
      myTXSUPPCL1.GetOneRecordP(TxtID.Text)
      If Not myTXSUPPCL1.RecordNotFound And MyUtils.CnvSng(LblListNo.Text) <> myTXSUPPCL1._LISTNO Then
        Answer = MsgBox("Are you sure you want to add this record?", MsgBoxStyle.YesNo, "VIN is already in file")
        If Answer = MsgBoxResult.No Then
          ErrorField(I) = "vin"
          ErrorMsg(I) = "VIN already in file"
          I = I + 1
        End If
      End If
    End If

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

    If TxtExempt1.Text = "" And MyUtils.CnvSng(TxtExam1.Text) > 0 Then
      ErrorField(I) = "excd1"
      ErrorMsg(I) = "Exemption Code is required"
      I = I + 1
    End If

    If TxtExempt2.Text = "" And MyUtils.CnvSng(TxtExam2.Text) > 0 Then
      ErrorField(I) = "excd2"
      ErrorMsg(I) = "Exemption Code is required"
      I = I + 1
    End If

    If TxtExempt3.Text = "" And MyUtils.CnvSng(TxtExam3.Text) > 0 Then
      ErrorField(I) = "excd3"
      ErrorMsg(I) = "Exemption Code is required"
      I = I + 1
    End If

    If TxtExempt4.Text = "" And MyUtils.CnvSng(TxtExam4.Text) > 0 Then
      ErrorField(I) = "excd4"
      ErrorMsg(I) = "Exemption Code is required"
      I = I + 1
    End If

    If TxtExempt5.Text = "" And MyUtils.CnvSng(TxtExam5.Text) > 0 Then
      ErrorField(I) = "excd5"
      ErrorMsg(I) = "Exemption Code is required"
      I = I + 1
    End If

    WrkTip = Ttp1.GetToolTip(TxtReason)
    If Mid(WrkTip, 1, 1) = "*" Then
      ErrorField(I) = "rsncd"
      ErrorMsg(I) = "Invalid Reason Code"
      I = I + 1
    End If

    If MyUtils.CnvSng(LblNewNet.Text) < 0 Then
      ErrorField(I) = "net"
      ErrorMsg(I) = "Net cannot be negative"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtOVMSRP.Text) > 0 Then
      myTXMSRPCD.GetOneRecordP(TxtSource.Text)
      If myTXMSRPCD.RecordNotFound Then
        ErrorField(I) = "source"
        ErrorMsg(I) = "Source is invalid"
        I = I + 1
      End If
    End If
  End Sub
  Private Sub FrmTA8105R_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA810.SbpScreen.Text = "TA8105R"
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
    If MyUtils.CnvSng(TxtCRSaleMonth.Text) > 0 Then
      CalcProrateMonth("S", MyUtils.CnvSng(TxtCRSaleMonth.Text), MyUtils.CnvSng(TxtCRAssmt1.Text), WrkProrate, WrkAdjNet, WrkPct, WrkCode)
      LblCRSalePct.Text = WrkPct
      LblCRSaleNet.Text = WrkAdjNet
    End If
    LblAdjNet.Text = MyUtils.CnvSng(LblPurchNet.Text) - MyUtils.CnvSng(LblCRSaleNet.Text) - MyUtils.CnvSng(LblCRSaleNet.Text)
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
  Private Sub LnkClass_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkClass.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = 1
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtClass.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCRClass_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCRClass.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = 2
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCRClass.Text)
    MyFrmListCodes.Show()
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
  Private Sub TxtReason_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtReason.Leave
    SetCResnTip()
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
  Public Sub GetOrigTxCOEB(ByVal WrkCCNo As Integer)
    Dim MyOrigTXCOEB As TXCOEB.MyData
    Dim WrkSaleMonth As Integer
    Dim WrkProrate As Integer
    Dim WrkAdjNet As Integer
    Dim WrkPct As Single

    MyOrigTXCOEB = New TXCOEB.MyData(myDBConnect)
    MyOrigTXCOEB.GetOneRecordP(WrkCCNo)
    If Not MyOrigTXCOEB.RecordNotFound Then
      With MyOrigTXCOEB
        LblOrig.Text = "C/C " & Str$(WrkCCNo)
        LblOrig.ForeColor = Color.Fuchsia
        LblOrigGross.Text = FormatNumber(._CGRS, 0)
        CalcProrateCode("P", Trim(._CT2MC1), ._CGRS, WrkProrate, WrkAdjNet, WrkPct, WrkSaleMonth)
        If MyUtils.CnvSng(TxtSaleMonth.Text) = 0 Then
          TxtSaleMonth.Text = WrkSaleMonth
          LblSalePct.Text = WrkPct
          LblSaleNet.Text = WrkAdjNet
        End If
        LblOrigProrate.Text = FormatNumber(WrkAdjNet, 0)
        LblOrigExam.Text = FormatNumber(._NTEX1 + ._NTEX2 + ._NTEX3 +
        ._NTEX4 + ._NTEX5, 0)
        LblOrigNet.Text = FormatNumber(MyUtils.CnvSng(LblOrigGross.Text) - MyUtils.CnvSng(LblOrigExam.Text) - MyUtils.CnvSng(LblOrigProrate.Text), 0)
        'Assessment Property Codes
        LblOrigAssmt1.Text = ._NTASS1
        'Exemption Codes
        TxtExempt1.Text = Trim(._NTECD1)
        TxtExempt2.Text = Trim(._NTECD2)
        TxtExempt3.Text = Trim(._NTECD3)
        TxtExempt4.Text = Trim(._NTECD4)
        TxtExempt5.Text = Trim(._NTECD5)
        SetExem1Tip()
        SetExem2Tip()
        SetExem3Tip()
        SetExem4Tip()
        SetExem5Tip()
        LblOrigExam1.Text = ._NTEX1
        LblOrigExam2.Text = ._NTEX2
        LblOrigExam3.Text = ._NTEX3
        LblOrigExam4.Text = ._NTEX4
        LblOrigExam5.Text = ._NTEX5
      End With
    End If
  End Sub
  Public Sub GetTXCOEB()
    Dim WrkSaleMonth As Integer
    Dim WrkProrate As Integer
    Dim WrkAdjNet As Integer
    Dim WrkPct As Single

    With myTXCOEB
      LblListNo.Text = ._LISTNo
      LblYear.Text = ._CYEAR
      LblType.Text = ._CTYPE
      WrkListNo = ._LISTNo
      WrkYear = ._CYEAR
      WrkType = ._CTYPE
      LblCCDate.Text = MyUtils.GetDBDate(._CDATE)
      LblOrigName.Text = Trim(._NAME)
      TxtName.Text = Trim(._NAME)
      TxtDist.Text = ._DIST
      LblNewGross.Text = FormatNumber(._CGRS, 0)
      TxtReason.Text = ._RSNCD
      TxtDesc.Text = Trim(._CDESC)
      TxtAssmt1.Text = ._NTASS1
      CalcProrateCode("P", Trim(._CT2MC1), ._CGRS, WrkProrate, WrkAdjNet, WrkPct, WrkSaleMonth)
      TxtSaleMonth.Text = WrkSaleMonth
      LblSalePct.Text = FormatNumber(WrkPct, 3)
      LblSaleNet.Text = WrkAdjNet
      'Exemption Codes
      TxtExempt1.Text = Trim(._NTECD1)
      TxtExempt2.Text = Trim(._NTECD2)
      TxtExempt3.Text = Trim(._NTECD3)
      TxtExempt4.Text = Trim(._NTECD4)
      TxtExempt5.Text = Trim(._NTECD5)
      SetExem1Tip()
      SetExem2Tip()
      SetExem3Tip()
      SetExem4Tip()
      SetExem5Tip()
      TxtExam1.Text = ._NTEX1
      TxtExam2.Text = ._NTEX2
      TxtExam3.Text = ._NTEX3
      TxtExam4.Text = ._NTEX4
      TxtExam5.Text = ._NTEX5
      LblNewGross.Text = ._CGRSCH
      LblNewExam.Text = ._EXCHG
      LblNewNet.Text = ._CGRSCH - ._EXCHG
    End With

  End Sub
  Sub CalcChg()
    Dim WrkAdjGross As Integer
    Dim WrkNet As Integer
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

    LblChgGross.Text = FormatNumber(MyUtils.CnvSng(LblNewGross.Text) - MyUtils.CnvSng(LblOrigGross.Text), 0)
    LblChgExam.Text = FormatNumber(MyUtils.CnvSng(LblNewExam.Text) - MyUtils.CnvSng(LblOrigExam.Text), 0)
    LblChgProrate.Text = FormatNumber(MyUtils.CnvSng(LblNewProrate.Text) - MyUtils.CnvSng(LblOrigProrate.Text), 0)
    LblChgAdjGross.Text = FormatNumber(MyUtils.CnvSng(LblNewAdjGross.Text) - MyUtils.CnvSng(LblOrigAdjGross.Text), 0)
    LblChgNet.Text = FormatNumber(MyUtils.CnvSng(LblNewNet.Text) - MyUtils.CnvSng(LblOrigNet.Text), 0)
    LblChgAssmt1.Text = MyUtils.CnvSng(TxtAssmt1.Text) - MyUtils.CnvSng(LblOrigAssmt1.Text)
    LblChgCRAssmt1.Text = MyUtils.CnvSng(TxtCRAssmt1.Text) - MyUtils.CnvSng(LblOrigCRAssmt1.Text)
    LblChgExam1.Text = MyUtils.CnvSng(TxtExam1.Text) - MyUtils.CnvSng(LblOrigExam1.Text)
    LblChgExam2.Text = MyUtils.CnvSng(TxtExam2.Text) - MyUtils.CnvSng(LblOrigExam2.Text)
    LblChgExam3.Text = MyUtils.CnvSng(TxtExam3.Text) - MyUtils.CnvSng(LblOrigExam3.Text)
    LblChgExam4.Text = MyUtils.CnvSng(TxtExam4.Text) - MyUtils.CnvSng(LblOrigExam4.Text)
    LblChgExam5.Text = MyUtils.CnvSng(TxtExam5.Text) - MyUtils.CnvSng(LblOrigExam5.Text)
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
    Dim WrkPct As Double
    Dim WrkProPct As Decimal
    Dim WrkCode As String

    WrkCode = ""
    CalcProrateMonth("S", MyUtils.CnvSng(TxtSaleMonth.Text), MyUtils.CnvSng(TxtAssmt1.Text), WrkProrate, WrkAdjNet, WrkPct, WrkCode)
    LblSalePct.Text = FormatNumber(WrkPct, 3)
    LblSaleNet.Text = WrkAdjNet
    LblNewProrate.Text = WrkAdjNet
    LblAdjNet.Text = MyUtils.CnvSng(LblPurchNet.Text) - MyUtils.CnvSng(LblSaleNet.Text) - MyUtils.CnvSng(LblCRSaleNet.Text)
    WrkProPct = 1 - WrkPct
    If WrkAddMode Then
      TxtExam1.Text = Math.Round(MyUtils.CnvSng(LblOrigExam1.Text) * WrkProPct, 0)
      TxtExam2.Text = Math.Round(MyUtils.CnvSng(LblOrigExam2.Text) * WrkProPct, 0)
      TxtExam3.Text = Math.Round(MyUtils.CnvSng(LblOrigExam3.Text) * WrkProPct, 0)
      TxtExam4.Text = Math.Round(MyUtils.CnvSng(LblOrigExam4.Text) * WrkProPct, 0)
      TxtExam5.Text = Math.Round(MyUtils.CnvSng(LblOrigExam5.Text) * WrkProPct, 0)
    End If
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

    With MyGetTXMVPCT
      .GetTXMVPCT(In_Type, In_SaleCode)
      Out_SaleMonth = .Month
      Out_Pct = .Pct
    End With
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
  Private Sub TxtOverAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Call CalcChg()
  End Sub
  Private Sub TxtPurchMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPurchMonth.TextChanged
    If Not TxtPurchMonth.Modified Then Exit Sub
    CalcPurch()
  End Sub
  Private Sub TxtSaleMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSaleMonth.TextChanged
    CalcSale()
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
  Private Function NextListNo() As Integer
    Dim WrkNextListNo As Integer

    WrkNextListNo = myTXSUPPC.AutoGenKey()
    Return WrkNextListNo

  End Function
  Private Sub TxtSSNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSSNo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSS2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSS2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtOid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtOid.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
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

  Private Sub TxtOVMSRP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOVMSRP.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCROVMSRP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCROVMSRP.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtOVMSRP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOVMSRP.TextChanged
    Dim WrkMSRP As Integer
    Dim WrkOvMSRP As Integer
    Dim WrkYear As Integer
    Dim WrkValue As Integer
    Dim WrkProrate As Integer
    Dim WrkAdjNet As Integer
    Dim WrkPct As Double
    Dim WrkCode As String
    WrkMSRP = MyUtils.CnvSng(LblMSRP.Text)
    WrkOvMSRP = MyUtils.CnvSng(TxtOVMSRP.Text)
    WrkYear = MyUtils.CnvSng(TxtMVYear.Text)
    WrkValue = CalcValue(WrkMSRP, WrkOvMSRP, WrkYear, False)
    LblValue.Text = MyUtils.Round10(WrkValue, "Normal")
    TxtAssmt1.Text = MyUtils.CnvSng(LblValue.Text)

    WrkCode = ""
    CalcProrateMonth("P", MyUtils.CnvSng(TxtPurchMonth.Text), MyUtils.CnvSng(TxtAssmt1.Text), WrkProrate, WrkAdjNet, WrkPct, WrkCode)
    LblSalePct.Text = FormatNumber(WrkPct, 3)
    LblSaleNet.Text = WrkAdjNet
    LblNewProrate.Text = WrkAdjNet
    CalcChg()
  End Sub
  Private Sub TxtCROVMSRP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOVMSRP.TextChanged
    Dim WrkMSRP As Integer
    Dim WrkOvMSRP As Integer
    Dim WrkYear As Integer
    Dim WrkValue As Integer
    Dim WrkProrate As Integer
    Dim WrkAdjNet As Integer
    Dim WrkPct As Double
    Dim WrkSaleCode As String
    WrkMSRP = MyUtils.CnvSng(LblCRMSRP.Text)
    WrkOvMSRP = MyUtils.CnvSng(TxtCROVMSRP.Text)
    WrkYear = MyUtils.CnvSng(TxtCRMVYear.Text)
    WrkValue = CalcValue(WrkMSRP, WrkOvMSRP, WrkYear, False)
    LblCRValue.Text = MyUtils.Round10(WrkValue, "Normal")
    TxtCRAssmt1.Text = MyUtils.CnvSng(LblCRValue.Text)

    WrkSaleCode = ""
    CalcProrateMonth("P", MyUtils.CnvSng(TxtSaleMonth.Text), MyUtils.CnvSng(TxtAssmt1.Text), WrkProrate,
      WrkAdjNet, WrkPct, WrkSaleCode)
    LblSalePct.Text = FormatNumber(WrkPct, 3)
    LblSaleNet.Text = WrkAdjNet
    LblNewProrate.Text = WrkAdjNet
    CalcChg()
  End Sub

  Private Sub LnkSource_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkSource.LinkClicked
    MyFrmListSource = New FrmListSource
    MyFrmListSource.MdiParent = Me.ParentForm
    MyFrmListSource.WrkScreen = "SU"
    MyFrmListSource.WrkCode = TxtSource.Text
    MyFrmListSource.Show()
  End Sub
  Private Sub LnkCRSource_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkCRSource.LinkClicked
    MyFrmListSource = New FrmListSource
    MyFrmListSource.MdiParent = Me.ParentForm
    MyFrmListSource.WrkScreen = "SU"
    MyFrmListSource.WrkCode = TxtCRSource.Text
    MyFrmListSource.Show()
  End Sub
  Private Function CalcValue(ByVal WrkMSRP As Integer, ByVal WrkOvMSRP As Integer, ByVal WrkYear As Integer,
   ByVal WrkCredit As Boolean) As Integer
    Dim WrkDeYear As Integer
    Dim WrkValue As Integer
    Dim WrkDepr As Decimal
    Dim WrkMsg As String
    'Calculate Assessment Value
    WrkValue = 0
    WrkDeYear = 2024 - WrkYear + 1
    If WrkDeYear < 1 Then
      WrkDeYear = 1
    End If
    WrkDepr = GetTXMSRPDEP(WrkDeYear)
    If WrkOvMSRP > 0 Then
      WrkValue = WrkOvMSRP * WrkDepr * MyBookPct
      WrkMsg = WrkOvMSRP & " x " & WrkDepr & "% (" & WrkDeYear & ") x " & MyBookPct & "%"
    Else
      WrkValue = WrkMSRP * WrkDepr * MyBookPct
      WrkMsg = WrkMSRP & " x " & WrkDepr & "% (" & WrkDeYear & ") x " & MyBookPct & "%"
    End If
    WrkValue = MyUtils.Round10(WrkValue, "Normal")
    If WrkValue < MyMinValue Then
      WrkValue = MyMinValue
    End If
    If WrkCredit Then
      LblCRMSRPCalc.Text = WrkMsg
    Else
      LblMSRPCalc.Text = WrkMsg
    End If
    Return WrkValue
  End Function
  Public Function GetTXMSRPDEP(ByVal DeprYear As Integer) As Decimal
    Dim WrkDepr As Decimal
    If DeprYear < 0 Then DeprYear = 1
    WrkDepr = myTXMSRPDEP.GetDepr(DeprYear)
    Return WrkDepr
  End Function

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
      If MyUtils.CnvSng(TxtCRMVYear.Text) <> .modelYear Then 'If Vehicle year don't match it's an error
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

End Class
