Public Class FrmTX405C
  Inherits System.Windows.Forms.Form
  Dim myTXINV As TXINV.MyData
  Dim myTXPROF As TXPROF.MyData
  Dim myTXSTS As TXSTS.MyData
  Dim myTXVCUS As TXVCUS.MyData
  Friend WrkAcct As String
  Friend AddMode As Boolean
  Friend WithEvents RbForeclosure As System.Windows.Forms.RadioButton
  Friend WithEvents TxtStatus As System.Windows.Forms.TextBox
  Friend WithEvents LnkStatus As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtSS2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtSSNo As System.Windows.Forms.TextBox
  Friend WithEvents LnkSSno As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkSS2 As System.Windows.Forms.LinkLabel
  Friend WithEvents LblDOB As System.Windows.Forms.Label
  Friend WithEvents DtPckDOB As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtOID As System.Windows.Forms.TextBox
  Friend WithEvents LnkOID As System.Windows.Forms.LinkLabel
  Friend WithEvents GrpDefer As GroupBox
  Friend WithEvents LblDeferT As Label
  Friend WithEvents TxtDefer4 As TextBox
  Friend WithEvents TxtDefer3 As TextBox
  Friend WithEvents TxtDefer2 As TextBox
  Friend WithEvents TxtDefer1 As TextBox
  Friend WithEvents Label20 As Label
  Friend WithEvents Label39 As Label
  Friend WithEvents Label45 As Label
  Friend WithEvents Label48 As Label
  Friend WithEvents Label49 As Label
  Friend WithEvents RbDefer As RadioButton
  Dim WrkListNo As Integer
  Dim WrkType As String
  Dim WrkYear As Integer
  Dim WrkFamily As String
  Friend WithEvents LnkBankCd As LinkLabel
  Friend WithEvents LnkBankSvc As LinkLabel
  Friend WithEvents RbDeferExpire As RadioButton
  Friend WithEvents GroupBox2 As GroupBox
  Friend WithEvents LblPrinDue As Label
  Friend WithEvents Label54 As Label
  Dim LoadScrn As Boolean
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
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents TxtSname As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtAdd1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAdd2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents TxtCity As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtLocNo As System.Windows.Forms.TextBox
  Friend WithEvents TxtLoc As System.Windows.Forms.TextBox
  Friend WithEvents TxtZip5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtZip4 As System.Windows.Forms.TextBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents LblListNo As System.Windows.Forms.Label
  Friend WithEvents LblYear As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
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
  Friend WithEvents LblCCTax4Txt As System.Windows.Forms.Label
  Friend WithEvents LblCCTax3Txt As System.Windows.Forms.Label
  Friend WithEvents LblCCTax2Txt As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
  Friend WithEvents LblTax4Txt As System.Windows.Forms.Label
  Friend WithEvents LblTax3Txt As System.Windows.Forms.Label
  Friend WithEvents LblTax2Txt As System.Windows.Forms.Label
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents LblPayDate As System.Windows.Forms.Label
  Friend WithEvents LblIntPaid As System.Windows.Forms.Label
  Friend WithEvents LblTotpay As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents Label44 As System.Windows.Forms.Label
  Friend WithEvents Label43 As System.Windows.Forms.Label
  Friend WithEvents TxtComment As System.Windows.Forms.TextBox
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents LblStatus As System.Windows.Forms.Label
  Friend WithEvents ChkLien As System.Windows.Forms.CheckBox
  Friend WithEvents TxtDist As System.Windows.Forms.TextBox
  Friend WithEvents TxtPhase As System.Windows.Forms.TextBox
  Friend WithEvents TxtTax1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtTax2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtTax3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtTax4 As System.Windows.Forms.TextBox
  Friend WithEvents TabPgBank As System.Windows.Forms.TabPage
  Friend WithEvents TxtBankServ As System.Windows.Forms.TextBox
  Friend WithEvents TxtMap As System.Windows.Forms.TextBox
  Friend WithEvents LblMap As System.Windows.Forms.Label
  Friend WithEvents TabPgAssmnt As System.Windows.Forms.TabPage
  Friend WithEvents TabPgExempt As System.Windows.Forms.TabPage
  Friend WithEvents TabPgEld As System.Windows.Forms.TabPage
  Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
  Friend WithEvents LnkEldPerc As System.Windows.Forms.LinkLabel
  Friend WithEvents RbEldNA As System.Windows.Forms.RadioButton
  Friend WithEvents TxtEldAdj As System.Windows.Forms.TextBox
  Friend WithEvents TxtEldTax As System.Windows.Forms.TextBox
  Friend WithEvents TxtEldMin As System.Windows.Forms.TextBox
  Friend WithEvents TxtEldMax As System.Windows.Forms.TextBox
  Friend WithEvents TxtEldPerc As System.Windows.Forms.TextBox
  Friend WithEvents TxtEldYear As System.Windows.Forms.TextBox
  Friend WithEvents Label60 As System.Windows.Forms.Label
  Friend WithEvents Label59 As System.Windows.Forms.Label
  Friend WithEvents Label58 As System.Windows.Forms.Label
  Friend WithEvents Label57 As System.Windows.Forms.Label
  Friend WithEvents Label55 As System.Windows.Forms.Label
  Friend WithEvents RbEldFrozen As System.Windows.Forms.RadioButton
  Friend WithEvents RbEldHeart As System.Windows.Forms.RadioButton
  Friend WithEvents TxtVol As System.Windows.Forms.TextBox
  Friend WithEvents TxtPage As System.Windows.Forms.TextBox
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents LnkCode6 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCode6 As System.Windows.Forms.TextBox
  Friend WithEvents LnkCode4 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCode4 As System.Windows.Forms.TextBox
  Friend WithEvents LnkCode2 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCode2 As System.Windows.Forms.TextBox
  Friend WithEvents LnkCode7 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCode7 As System.Windows.Forms.TextBox
  Friend WithEvents LnkCode5 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCode5 As System.Windows.Forms.TextBox
  Friend WithEvents LnkCode3 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCode3 As System.Windows.Forms.TextBox
  Friend WithEvents LnkCode1 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCode1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt7 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnit7 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt6 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnit6 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnit4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnit5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnit3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt2 As System.Windows.Forms.TextBox
  Friend WithEvents Label24 As System.Windows.Forms.Label
  Friend WithEvents Label27 As System.Windows.Forms.Label
  Friend WithEvents TxtUnit2 As System.Windows.Forms.TextBox
  Friend WithEvents Label28 As System.Windows.Forms.Label
  Friend WithEvents TxtAssmt1 As System.Windows.Forms.TextBox
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents Label34 As System.Windows.Forms.Label
  Friend WithEvents TxtUnit1 As System.Windows.Forms.TextBox
  Friend WithEvents Label35 As System.Windows.Forms.Label
  Friend WithEvents LnkExempt6 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtExempt6 As System.Windows.Forms.TextBox
  Friend WithEvents LnkExempt7 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtExempt7 As System.Windows.Forms.TextBox
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
  Friend WithEvents TxtExam7 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam6 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam2 As System.Windows.Forms.TextBox
  Friend WithEvents Label46 As System.Windows.Forms.Label
  Friend WithEvents Label47 As System.Windows.Forms.Label
  Friend WithEvents TxtExam5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam1 As System.Windows.Forms.TextBox
  Friend WithEvents Label50 As System.Windows.Forms.Label
  Friend WithEvents Label52 As System.Windows.Forms.Label
  Friend WithEvents TabPgMV As System.Windows.Forms.TabPage
  Friend WithEvents LnkCode10 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCode10 As System.Windows.Forms.TextBox
  Friend WithEvents LnkCode8 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCode8 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt10 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnit10 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt8 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnit8 As System.Windows.Forms.TextBox
  Friend WithEvents LnkCode9 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCode9 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt9 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnit9 As System.Windows.Forms.TextBox
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents TxtRegno As System.Windows.Forms.TextBox
  Friend WithEvents Label36 As System.Windows.Forms.Label
  Friend WithEvents TxtVIN As System.Windows.Forms.TextBox
  Friend WithEvents Label37 As System.Windows.Forms.Label
  Friend WithEvents TxtClass As System.Windows.Forms.TextBox
  Friend WithEvents Label38 As System.Windows.Forms.Label
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents Label40 As System.Windows.Forms.Label
  Friend WithEvents TxtModel As System.Windows.Forms.TextBox
  Friend WithEvents Label41 As System.Windows.Forms.Label
  Friend WithEvents TxtValue As System.Windows.Forms.TextBox
  Friend WithEvents Label42 As System.Windows.Forms.Label
  Friend WithEvents TxtMake As System.Windows.Forms.TextBox
  Friend WithEvents LnkAsmt As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtAss As System.Windows.Forms.TextBox
  Friend WithEvents TabPgUB As System.Windows.Forms.TabPage
  Friend WithEvents TxtBondPaid As System.Windows.Forms.TextBox
  Friend WithEvents TxtBond As System.Windows.Forms.TextBox
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents TxtBankCd As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents LblNet As System.Windows.Forms.Label
  Friend WithEvents LblExempt As System.Windows.Forms.Label
  Friend WithEvents LblGross As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents LblTaxT As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbBackTax As System.Windows.Forms.RadioButton
  Friend WithEvents RbInactive As System.Windows.Forms.RadioButton
  Friend WithEvents RbSuspense As System.Windows.Forms.RadioButton
  Friend WithEvents RbNA As System.Windows.Forms.RadioButton
  Friend WithEvents GrpCredit As System.Windows.Forms.GroupBox
  Friend WithEvents LnkOAsmt As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtOAss As System.Windows.Forms.TextBox
  Friend WithEvents TxtORegNo As System.Windows.Forms.TextBox
  Friend WithEvents TxtOVIN As System.Windows.Forms.TextBox
  Friend WithEvents TxtOClass As System.Windows.Forms.TextBox
  Friend WithEvents TxtOYear As System.Windows.Forms.TextBox
  Friend WithEvents TxtOModel As System.Windows.Forms.TextBox
  Friend WithEvents TxtOValue As System.Windows.Forms.TextBox
  Friend WithEvents TxtOMake As System.Windows.Forms.TextBox
  Friend WithEvents TabCtl1 As System.Windows.Forms.TabControl
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtSname = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtAdd1 = New System.Windows.Forms.TextBox()
    Me.TxtAdd2 = New System.Windows.Forms.TextBox()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtLocNo = New System.Windows.Forms.TextBox()
    Me.TxtLoc = New System.Windows.Forms.TextBox()
    Me.TxtZip5 = New System.Windows.Forms.TextBox()
    Me.TxtZip4 = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.GrpCC = New System.Windows.Forms.GroupBox()
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
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.LblTaxT = New System.Windows.Forms.Label()
    Me.TxtTax4 = New System.Windows.Forms.TextBox()
    Me.TxtTax3 = New System.Windows.Forms.TextBox()
    Me.TxtTax2 = New System.Windows.Forms.TextBox()
    Me.TxtTax1 = New System.Windows.Forms.TextBox()
    Me.LblTax4Txt = New System.Windows.Forms.Label()
    Me.LblTax3Txt = New System.Windows.Forms.Label()
    Me.LblTax2Txt = New System.Windows.Forms.Label()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.LblPayDate = New System.Windows.Forms.Label()
    Me.LblIntPaid = New System.Windows.Forms.Label()
    Me.LblTotpay = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.Label44 = New System.Windows.Forms.Label()
    Me.Label43 = New System.Windows.Forms.Label()
    Me.TxtComment = New System.Windows.Forms.TextBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.LblStatus = New System.Windows.Forms.Label()
    Me.ChkLien = New System.Windows.Forms.CheckBox()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.TxtPhase = New System.Windows.Forms.TextBox()
    Me.TabCtl1 = New System.Windows.Forms.TabControl()
    Me.TabPgAssmnt = New System.Windows.Forms.TabPage()
    Me.LnkCode9 = New System.Windows.Forms.LinkLabel()
    Me.TxtCode9 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt9 = New System.Windows.Forms.TextBox()
    Me.TxtUnit9 = New System.Windows.Forms.TextBox()
    Me.LnkCode10 = New System.Windows.Forms.LinkLabel()
    Me.TxtCode10 = New System.Windows.Forms.TextBox()
    Me.LnkCode8 = New System.Windows.Forms.LinkLabel()
    Me.TxtCode8 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt10 = New System.Windows.Forms.TextBox()
    Me.TxtUnit10 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt8 = New System.Windows.Forms.TextBox()
    Me.TxtUnit8 = New System.Windows.Forms.TextBox()
    Me.LnkCode6 = New System.Windows.Forms.LinkLabel()
    Me.TxtCode6 = New System.Windows.Forms.TextBox()
    Me.LnkCode4 = New System.Windows.Forms.LinkLabel()
    Me.TxtCode4 = New System.Windows.Forms.TextBox()
    Me.LnkCode2 = New System.Windows.Forms.LinkLabel()
    Me.TxtCode2 = New System.Windows.Forms.TextBox()
    Me.LnkCode7 = New System.Windows.Forms.LinkLabel()
    Me.TxtCode7 = New System.Windows.Forms.TextBox()
    Me.LnkCode5 = New System.Windows.Forms.LinkLabel()
    Me.TxtCode5 = New System.Windows.Forms.TextBox()
    Me.LnkCode3 = New System.Windows.Forms.LinkLabel()
    Me.TxtCode3 = New System.Windows.Forms.TextBox()
    Me.LnkCode1 = New System.Windows.Forms.LinkLabel()
    Me.TxtCode1 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt7 = New System.Windows.Forms.TextBox()
    Me.TxtUnit7 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt6 = New System.Windows.Forms.TextBox()
    Me.TxtUnit6 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt4 = New System.Windows.Forms.TextBox()
    Me.TxtUnit4 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt5 = New System.Windows.Forms.TextBox()
    Me.TxtUnit5 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt3 = New System.Windows.Forms.TextBox()
    Me.TxtUnit3 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt2 = New System.Windows.Forms.TextBox()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.Label27 = New System.Windows.Forms.Label()
    Me.TxtUnit2 = New System.Windows.Forms.TextBox()
    Me.Label28 = New System.Windows.Forms.Label()
    Me.TxtAssmt1 = New System.Windows.Forms.TextBox()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.Label34 = New System.Windows.Forms.Label()
    Me.TxtUnit1 = New System.Windows.Forms.TextBox()
    Me.Label35 = New System.Windows.Forms.Label()
    Me.TabPgExempt = New System.Windows.Forms.TabPage()
    Me.LnkExempt6 = New System.Windows.Forms.LinkLabel()
    Me.TxtExempt6 = New System.Windows.Forms.TextBox()
    Me.LnkExempt7 = New System.Windows.Forms.LinkLabel()
    Me.TxtExempt7 = New System.Windows.Forms.TextBox()
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
    Me.TxtExam7 = New System.Windows.Forms.TextBox()
    Me.TxtExam6 = New System.Windows.Forms.TextBox()
    Me.TxtExam4 = New System.Windows.Forms.TextBox()
    Me.TxtExam2 = New System.Windows.Forms.TextBox()
    Me.Label46 = New System.Windows.Forms.Label()
    Me.Label47 = New System.Windows.Forms.Label()
    Me.TxtExam5 = New System.Windows.Forms.TextBox()
    Me.TxtExam3 = New System.Windows.Forms.TextBox()
    Me.TxtExam1 = New System.Windows.Forms.TextBox()
    Me.Label50 = New System.Windows.Forms.Label()
    Me.Label52 = New System.Windows.Forms.Label()
    Me.TabPgBank = New System.Windows.Forms.TabPage()
    Me.LnkBankCd = New System.Windows.Forms.LinkLabel()
    Me.LnkBankSvc = New System.Windows.Forms.LinkLabel()
    Me.TxtVol = New System.Windows.Forms.TextBox()
    Me.TxtPage = New System.Windows.Forms.TextBox()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.TxtMap = New System.Windows.Forms.TextBox()
    Me.LblMap = New System.Windows.Forms.Label()
    Me.TxtBankServ = New System.Windows.Forms.TextBox()
    Me.TxtBankCd = New System.Windows.Forms.TextBox()
    Me.TabPgEld = New System.Windows.Forms.TabPage()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.LnkEldPerc = New System.Windows.Forms.LinkLabel()
    Me.RbEldNA = New System.Windows.Forms.RadioButton()
    Me.TxtEldAdj = New System.Windows.Forms.TextBox()
    Me.TxtEldTax = New System.Windows.Forms.TextBox()
    Me.TxtEldMin = New System.Windows.Forms.TextBox()
    Me.TxtEldMax = New System.Windows.Forms.TextBox()
    Me.TxtEldPerc = New System.Windows.Forms.TextBox()
    Me.TxtEldYear = New System.Windows.Forms.TextBox()
    Me.Label60 = New System.Windows.Forms.Label()
    Me.Label59 = New System.Windows.Forms.Label()
    Me.Label58 = New System.Windows.Forms.Label()
    Me.Label57 = New System.Windows.Forms.Label()
    Me.Label55 = New System.Windows.Forms.Label()
    Me.RbEldFrozen = New System.Windows.Forms.RadioButton()
    Me.RbEldHeart = New System.Windows.Forms.RadioButton()
    Me.TabPgMV = New System.Windows.Forms.TabPage()
    Me.GrpCredit = New System.Windows.Forms.GroupBox()
    Me.LnkOAsmt = New System.Windows.Forms.LinkLabel()
    Me.TxtOAss = New System.Windows.Forms.TextBox()
    Me.TxtORegNo = New System.Windows.Forms.TextBox()
    Me.TxtOVIN = New System.Windows.Forms.TextBox()
    Me.TxtOClass = New System.Windows.Forms.TextBox()
    Me.TxtOYear = New System.Windows.Forms.TextBox()
    Me.TxtOModel = New System.Windows.Forms.TextBox()
    Me.TxtOValue = New System.Windows.Forms.TextBox()
    Me.TxtOMake = New System.Windows.Forms.TextBox()
    Me.LnkAsmt = New System.Windows.Forms.LinkLabel()
    Me.TxtAss = New System.Windows.Forms.TextBox()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.TxtRegno = New System.Windows.Forms.TextBox()
    Me.Label36 = New System.Windows.Forms.Label()
    Me.TxtVIN = New System.Windows.Forms.TextBox()
    Me.Label37 = New System.Windows.Forms.Label()
    Me.TxtClass = New System.Windows.Forms.TextBox()
    Me.Label38 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label40 = New System.Windows.Forms.Label()
    Me.TxtModel = New System.Windows.Forms.TextBox()
    Me.Label41 = New System.Windows.Forms.Label()
    Me.TxtValue = New System.Windows.Forms.TextBox()
    Me.Label42 = New System.Windows.Forms.Label()
    Me.TxtMake = New System.Windows.Forms.TextBox()
    Me.TabPgUB = New System.Windows.Forms.TabPage()
    Me.TxtBondPaid = New System.Windows.Forms.TextBox()
    Me.TxtBond = New System.Windows.Forms.TextBox()
    Me.Label22 = New System.Windows.Forms.Label()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.LblNet = New System.Windows.Forms.Label()
    Me.LblExempt = New System.Windows.Forms.Label()
    Me.LblGross = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbDeferExpire = New System.Windows.Forms.RadioButton()
    Me.RbDefer = New System.Windows.Forms.RadioButton()
    Me.RbForeclosure = New System.Windows.Forms.RadioButton()
    Me.RbNA = New System.Windows.Forms.RadioButton()
    Me.RbSuspense = New System.Windows.Forms.RadioButton()
    Me.RbInactive = New System.Windows.Forms.RadioButton()
    Me.RbBackTax = New System.Windows.Forms.RadioButton()
    Me.TxtStatus = New System.Windows.Forms.TextBox()
    Me.LnkStatus = New System.Windows.Forms.LinkLabel()
    Me.TxtSSNo = New System.Windows.Forms.TextBox()
    Me.TxtSS2 = New System.Windows.Forms.TextBox()
    Me.LnkSSno = New System.Windows.Forms.LinkLabel()
    Me.LnkSS2 = New System.Windows.Forms.LinkLabel()
    Me.LblDOB = New System.Windows.Forms.Label()
    Me.DtPckDOB = New System.Windows.Forms.DateTimePicker()
    Me.LnkOID = New System.Windows.Forms.LinkLabel()
    Me.TxtOID = New System.Windows.Forms.TextBox()
    Me.GrpDefer = New System.Windows.Forms.GroupBox()
    Me.LblDeferT = New System.Windows.Forms.Label()
    Me.TxtDefer4 = New System.Windows.Forms.TextBox()
    Me.TxtDefer3 = New System.Windows.Forms.TextBox()
    Me.TxtDefer2 = New System.Windows.Forms.TextBox()
    Me.TxtDefer1 = New System.Windows.Forms.TextBox()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.Label39 = New System.Windows.Forms.Label()
    Me.Label45 = New System.Windows.Forms.Label()
    Me.Label48 = New System.Windows.Forms.Label()
    Me.Label49 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.LblPrinDue = New System.Windows.Forms.Label()
    Me.Label54 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpCC.SuspendLayout()
    Me.GroupBox6.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.TabCtl1.SuspendLayout()
    Me.TabPgAssmnt.SuspendLayout()
    Me.TabPgExempt.SuspendLayout()
    Me.TabPgBank.SuspendLayout()
    Me.TabPgEld.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.TabPgMV.SuspendLayout()
    Me.GrpCredit.SuspendLayout()
    Me.TabPgUB.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.GrpDefer.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(104, 48)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(256, 21)
    Me.TxtName.TabIndex = 2
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(16, 48)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(48, 16)
    Me.Label5.TabIndex = 9
    Me.Label5.Text = "Name"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(16, 24)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 16)
    Me.Label1.TabIndex = 13
    Me.Label1.Text = "List No"
    '
    'TxtSname
    '
    Me.TxtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSname.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSname.Location = New System.Drawing.Point(104, 72)
    Me.TxtSname.MaxLength = 35
    Me.TxtSname.Name = "TxtSname"
    Me.TxtSname.Size = New System.Drawing.Size(256, 21)
    Me.TxtSname.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(16, 72)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(80, 16)
    Me.Label2.TabIndex = 22
    Me.Label2.Text = "Second Name"
    '
    'TxtAdd1
    '
    Me.TxtAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd1.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd1.Location = New System.Drawing.Point(104, 96)
    Me.TxtAdd1.MaxLength = 35
    Me.TxtAdd1.Name = "TxtAdd1"
    Me.TxtAdd1.Size = New System.Drawing.Size(256, 21)
    Me.TxtAdd1.TabIndex = 4
    '
    'TxtAdd2
    '
    Me.TxtAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd2.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd2.Location = New System.Drawing.Point(104, 120)
    Me.TxtAdd2.MaxLength = 35
    Me.TxtAdd2.Name = "TxtAdd2"
    Me.TxtAdd2.Size = New System.Drawing.Size(256, 21)
    Me.TxtAdd2.TabIndex = 5
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(296, 144)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 21)
    Me.TxtState.TabIndex = 7
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(104, 144)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(184, 21)
    Me.TxtCity.TabIndex = 6
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(16, 96)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(80, 16)
    Me.Label3.TabIndex = 27
    Me.Label3.Text = "Street Address"
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(16, 144)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(80, 16)
    Me.Label4.TabIndex = 28
    Me.Label4.Text = "City/State/Zip"
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(16, 168)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(88, 16)
    Me.Label6.TabIndex = 29
    Me.Label6.Text = "Location#/Name"
    '
    'TxtLocNo
    '
    Me.TxtLocNo.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocNo.Location = New System.Drawing.Point(104, 168)
    Me.TxtLocNo.MaxLength = 7
    Me.TxtLocNo.Name = "TxtLocNo"
    Me.TxtLocNo.Size = New System.Drawing.Size(56, 21)
    Me.TxtLocNo.TabIndex = 10
    '
    'TxtLoc
    '
    Me.TxtLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLoc.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLoc.Location = New System.Drawing.Point(168, 168)
    Me.TxtLoc.MaxLength = 25
    Me.TxtLoc.Name = "TxtLoc"
    Me.TxtLoc.Size = New System.Drawing.Size(184, 21)
    Me.TxtLoc.TabIndex = 11
    '
    'TxtZip5
    '
    Me.TxtZip5.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip5.Location = New System.Drawing.Point(328, 144)
    Me.TxtZip5.MaxLength = 5
    Me.TxtZip5.Name = "TxtZip5"
    Me.TxtZip5.Size = New System.Drawing.Size(48, 21)
    Me.TxtZip5.TabIndex = 8
    '
    'TxtZip4
    '
    Me.TxtZip4.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip4.Location = New System.Drawing.Point(384, 144)
    Me.TxtZip4.MaxLength = 4
    Me.TxtZip4.Name = "TxtZip4"
    Me.TxtZip4.Size = New System.Drawing.Size(40, 21)
    Me.TxtZip4.TabIndex = 9
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblListNo
    '
    Me.LblListNo.Location = New System.Drawing.Point(86, 24)
    Me.LblListNo.Name = "LblListNo"
    Me.LblListNo.Size = New System.Drawing.Size(76, 16)
    Me.LblListNo.TabIndex = 99
    '
    'LblYear
    '
    Me.LblYear.Location = New System.Drawing.Point(200, 24)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(32, 16)
    Me.LblYear.TabIndex = 157
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(168, 24)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(32, 16)
    Me.Label8.TabIndex = 156
    Me.Label8.Text = "Year"
    '
    'GrpCC
    '
    Me.GrpCC.BackColor = System.Drawing.SystemColors.Control
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
    Me.GrpCC.Controls.Add(Me.Label7)
    Me.GrpCC.Controls.Add(Me.Label10)
    Me.GrpCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpCC.Location = New System.Drawing.Point(544, 152)
    Me.GrpCC.Name = "GrpCC"
    Me.GrpCC.Size = New System.Drawing.Size(184, 184)
    Me.GrpCC.TabIndex = 161
    Me.GrpCC.TabStop = False
    Me.GrpCC.Text = "C/C Information"
    '
    'LblCCDate
    '
    Me.LblCCDate.BackColor = System.Drawing.SystemColors.Control
    Me.LblCCDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCCDate.Location = New System.Drawing.Point(112, 20)
    Me.LblCCDate.Name = "LblCCDate"
    Me.LblCCDate.Size = New System.Drawing.Size(64, 16)
    Me.LblCCDate.TabIndex = 134
    Me.LblCCDate.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'LblCCExempt
    '
    Me.LblCCExempt.BackColor = System.Drawing.SystemColors.Control
    Me.LblCCExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCCExempt.Location = New System.Drawing.Point(76, 160)
    Me.LblCCExempt.Name = "LblCCExempt"
    Me.LblCCExempt.Size = New System.Drawing.Size(84, 16)
    Me.LblCCExempt.TabIndex = 133
    Me.LblCCExempt.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'LblCCGross
    '
    Me.LblCCGross.BackColor = System.Drawing.SystemColors.Control
    Me.LblCCGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCCGross.Location = New System.Drawing.Point(76, 140)
    Me.LblCCGross.Name = "LblCCGross"
    Me.LblCCGross.Size = New System.Drawing.Size(84, 16)
    Me.LblCCGross.TabIndex = 132
    Me.LblCCGross.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'LblCCTax4
    '
    Me.LblCCTax4.BackColor = System.Drawing.SystemColors.Control
    Me.LblCCTax4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCCTax4.Location = New System.Drawing.Point(76, 120)
    Me.LblCCTax4.Name = "LblCCTax4"
    Me.LblCCTax4.Size = New System.Drawing.Size(84, 16)
    Me.LblCCTax4.TabIndex = 131
    Me.LblCCTax4.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'LblCCTax3
    '
    Me.LblCCTax3.BackColor = System.Drawing.SystemColors.Control
    Me.LblCCTax3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCCTax3.Location = New System.Drawing.Point(76, 100)
    Me.LblCCTax3.Name = "LblCCTax3"
    Me.LblCCTax3.Size = New System.Drawing.Size(84, 16)
    Me.LblCCTax3.TabIndex = 130
    Me.LblCCTax3.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'LblCCTax2
    '
    Me.LblCCTax2.BackColor = System.Drawing.SystemColors.Control
    Me.LblCCTax2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCCTax2.Location = New System.Drawing.Point(76, 80)
    Me.LblCCTax2.Name = "LblCCTax2"
    Me.LblCCTax2.Size = New System.Drawing.Size(84, 16)
    Me.LblCCTax2.TabIndex = 129
    Me.LblCCTax2.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'LblCCTax1
    '
    Me.LblCCTax1.BackColor = System.Drawing.SystemColors.Control
    Me.LblCCTax1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCCTax1.Location = New System.Drawing.Point(76, 60)
    Me.LblCCTax1.Name = "LblCCTax1"
    Me.LblCCTax1.Size = New System.Drawing.Size(84, 16)
    Me.LblCCTax1.TabIndex = 128
    Me.LblCCTax1.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'LblCCNo
    '
    Me.LblCCNo.BackColor = System.Drawing.SystemColors.Control
    Me.LblCCNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCCNo.Location = New System.Drawing.Point(64, 20)
    Me.LblCCNo.Name = "LblCCNo"
    Me.LblCCNo.Size = New System.Drawing.Size(40, 16)
    Me.LblCCNo.TabIndex = 127
    Me.LblCCNo.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'LblCCTaxt
    '
    Me.LblCCTaxt.BackColor = System.Drawing.SystemColors.Control
    Me.LblCCTaxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCCTaxt.Location = New System.Drawing.Point(76, 40)
    Me.LblCCTaxt.Name = "LblCCTaxt"
    Me.LblCCTaxt.Size = New System.Drawing.Size(84, 16)
    Me.LblCCTaxt.TabIndex = 126
    Me.LblCCTaxt.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label33
    '
    Me.Label33.BackColor = System.Drawing.SystemColors.Control
    Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label33.Location = New System.Drawing.Point(8, 160)
    Me.Label33.Name = "Label33"
    Me.Label33.Size = New System.Drawing.Size(48, 16)
    Me.Label33.TabIndex = 15
    Me.Label33.Text = "Exempt"
    '
    'Label32
    '
    Me.Label32.BackColor = System.Drawing.SystemColors.Control
    Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label32.Location = New System.Drawing.Point(8, 140)
    Me.Label32.Name = "Label32"
    Me.Label32.Size = New System.Drawing.Size(48, 16)
    Me.Label32.TabIndex = 13
    Me.Label32.Text = "Gross"
    '
    'Label31
    '
    Me.Label31.BackColor = System.Drawing.SystemColors.Control
    Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label31.Location = New System.Drawing.Point(8, 20)
    Me.Label31.Name = "Label31"
    Me.Label31.Size = New System.Drawing.Size(60, 16)
    Me.Label31.TabIndex = 11
    Me.Label31.Text = "No/Date"
    '
    'LblCCTax4Txt
    '
    Me.LblCCTax4Txt.BackColor = System.Drawing.SystemColors.Control
    Me.LblCCTax4Txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCCTax4Txt.Location = New System.Drawing.Point(8, 120)
    Me.LblCCTax4Txt.Name = "LblCCTax4Txt"
    Me.LblCCTax4Txt.Size = New System.Drawing.Size(48, 16)
    Me.LblCCTax4Txt.TabIndex = 9
    Me.LblCCTax4Txt.Text = "4th Due"
    '
    'LblCCTax3Txt
    '
    Me.LblCCTax3Txt.BackColor = System.Drawing.SystemColors.Control
    Me.LblCCTax3Txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCCTax3Txt.Location = New System.Drawing.Point(8, 100)
    Me.LblCCTax3Txt.Name = "LblCCTax3Txt"
    Me.LblCCTax3Txt.Size = New System.Drawing.Size(48, 16)
    Me.LblCCTax3Txt.TabIndex = 7
    Me.LblCCTax3Txt.Text = "3rd Due"
    '
    'LblCCTax2Txt
    '
    Me.LblCCTax2Txt.BackColor = System.Drawing.SystemColors.Control
    Me.LblCCTax2Txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCCTax2Txt.Location = New System.Drawing.Point(8, 80)
    Me.LblCCTax2Txt.Name = "LblCCTax2Txt"
    Me.LblCCTax2Txt.Size = New System.Drawing.Size(48, 16)
    Me.LblCCTax2Txt.TabIndex = 5
    Me.LblCCTax2Txt.Text = "2nd Due"
    '
    'Label7
    '
    Me.Label7.BackColor = System.Drawing.SystemColors.Control
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(8, 60)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(60, 16)
    Me.Label7.TabIndex = 3
    Me.Label7.Text = "1st Due"
    '
    'Label10
    '
    Me.Label10.BackColor = System.Drawing.SystemColors.Control
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(8, 40)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(60, 16)
    Me.Label10.TabIndex = 0
    Me.Label10.Text = "Total Due"
    '
    'GroupBox6
    '
    Me.GroupBox6.BackColor = System.Drawing.SystemColors.Control
    Me.GroupBox6.Controls.Add(Me.LblTaxT)
    Me.GroupBox6.Controls.Add(Me.TxtTax4)
    Me.GroupBox6.Controls.Add(Me.TxtTax3)
    Me.GroupBox6.Controls.Add(Me.TxtTax2)
    Me.GroupBox6.Controls.Add(Me.TxtTax1)
    Me.GroupBox6.Controls.Add(Me.LblTax4Txt)
    Me.GroupBox6.Controls.Add(Me.LblTax3Txt)
    Me.GroupBox6.Controls.Add(Me.LblTax2Txt)
    Me.GroupBox6.Controls.Add(Me.Label18)
    Me.GroupBox6.Controls.Add(Me.Label19)
    Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox6.Location = New System.Drawing.Point(544, 8)
    Me.GroupBox6.Name = "GroupBox6"
    Me.GroupBox6.Size = New System.Drawing.Size(184, 136)
    Me.GroupBox6.TabIndex = 20
    Me.GroupBox6.TabStop = False
    Me.GroupBox6.Text = "Original Amounts"
    '
    'LblTaxT
    '
    Me.LblTaxT.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTaxT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTaxT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTaxT.Location = New System.Drawing.Point(72, 16)
    Me.LblTaxT.Name = "LblTaxT"
    Me.LblTaxT.Size = New System.Drawing.Size(88, 16)
    Me.LblTaxT.TabIndex = 128
    Me.LblTaxT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtTax4
    '
    Me.TxtTax4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTax4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTax4.Location = New System.Drawing.Point(72, 112)
    Me.TxtTax4.MaxLength = 9
    Me.TxtTax4.Name = "TxtTax4"
    Me.TxtTax4.Size = New System.Drawing.Size(88, 20)
    Me.TxtTax4.TabIndex = 14
    Me.TxtTax4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtTax3
    '
    Me.TxtTax3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTax3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTax3.Location = New System.Drawing.Point(72, 88)
    Me.TxtTax3.MaxLength = 9
    Me.TxtTax3.Name = "TxtTax3"
    Me.TxtTax3.Size = New System.Drawing.Size(88, 20)
    Me.TxtTax3.TabIndex = 13
    Me.TxtTax3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtTax2
    '
    Me.TxtTax2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTax2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTax2.Location = New System.Drawing.Point(72, 64)
    Me.TxtTax2.MaxLength = 9
    Me.TxtTax2.Name = "TxtTax2"
    Me.TxtTax2.Size = New System.Drawing.Size(88, 20)
    Me.TxtTax2.TabIndex = 12
    Me.TxtTax2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtTax1
    '
    Me.TxtTax1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTax1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTax1.Location = New System.Drawing.Point(72, 40)
    Me.TxtTax1.MaxLength = 9
    Me.TxtTax1.Name = "TxtTax1"
    Me.TxtTax1.Size = New System.Drawing.Size(88, 20)
    Me.TxtTax1.TabIndex = 11
    Me.TxtTax1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblTax4Txt
    '
    Me.LblTax4Txt.BackColor = System.Drawing.SystemColors.Control
    Me.LblTax4Txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTax4Txt.Location = New System.Drawing.Point(8, 112)
    Me.LblTax4Txt.Name = "LblTax4Txt"
    Me.LblTax4Txt.Size = New System.Drawing.Size(48, 16)
    Me.LblTax4Txt.TabIndex = 9
    Me.LblTax4Txt.Text = "4th Due"
    '
    'LblTax3Txt
    '
    Me.LblTax3Txt.BackColor = System.Drawing.SystemColors.Control
    Me.LblTax3Txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTax3Txt.Location = New System.Drawing.Point(8, 88)
    Me.LblTax3Txt.Name = "LblTax3Txt"
    Me.LblTax3Txt.Size = New System.Drawing.Size(48, 16)
    Me.LblTax3Txt.TabIndex = 7
    Me.LblTax3Txt.Text = "3rd Due"
    '
    'LblTax2Txt
    '
    Me.LblTax2Txt.BackColor = System.Drawing.SystemColors.Control
    Me.LblTax2Txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTax2Txt.Location = New System.Drawing.Point(8, 64)
    Me.LblTax2Txt.Name = "LblTax2Txt"
    Me.LblTax2Txt.Size = New System.Drawing.Size(48, 16)
    Me.LblTax2Txt.TabIndex = 5
    Me.LblTax2Txt.Text = "2nd Due"
    '
    'Label18
    '
    Me.Label18.BackColor = System.Drawing.SystemColors.Control
    Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label18.Location = New System.Drawing.Point(8, 40)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(56, 16)
    Me.Label18.TabIndex = 3
    Me.Label18.Text = "1st Due"
    '
    'Label19
    '
    Me.Label19.BackColor = System.Drawing.SystemColors.Control
    Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label19.Location = New System.Drawing.Point(8, 16)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(60, 16)
    Me.Label19.TabIndex = 0
    Me.Label19.Text = "Total Due"
    '
    'GroupBox4
    '
    Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
    Me.GroupBox4.Controls.Add(Me.LblPayDate)
    Me.GroupBox4.Controls.Add(Me.LblIntPaid)
    Me.GroupBox4.Controls.Add(Me.LblTotpay)
    Me.GroupBox4.Controls.Add(Me.Label12)
    Me.GroupBox4.Controls.Add(Me.Label13)
    Me.GroupBox4.Controls.Add(Me.Label14)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(544, 344)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(160, 84)
    Me.GroupBox4.TabIndex = 21
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Collected"
    '
    'LblPayDate
    '
    Me.LblPayDate.BackColor = System.Drawing.SystemColors.Control
    Me.LblPayDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPayDate.Location = New System.Drawing.Point(84, 60)
    Me.LblPayDate.Name = "LblPayDate"
    Me.LblPayDate.Size = New System.Drawing.Size(68, 16)
    Me.LblPayDate.TabIndex = 2
    Me.LblPayDate.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'LblIntPaid
    '
    Me.LblIntPaid.BackColor = System.Drawing.SystemColors.Control
    Me.LblIntPaid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblIntPaid.Location = New System.Drawing.Point(84, 40)
    Me.LblIntPaid.Name = "LblIntPaid"
    Me.LblIntPaid.Size = New System.Drawing.Size(60, 16)
    Me.LblIntPaid.TabIndex = 1
    Me.LblIntPaid.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'LblTotpay
    '
    Me.LblTotpay.BackColor = System.Drawing.SystemColors.Control
    Me.LblTotpay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotpay.Location = New System.Drawing.Point(72, 20)
    Me.LblTotpay.Name = "LblTotpay"
    Me.LblTotpay.Size = New System.Drawing.Size(80, 16)
    Me.LblTotpay.TabIndex = 0
    Me.LblTotpay.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label12
    '
    Me.Label12.BackColor = System.Drawing.SystemColors.Control
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(8, 60)
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
    'Label44
    '
    Me.Label44.BackColor = System.Drawing.SystemColors.Control
    Me.Label44.Location = New System.Drawing.Point(323, 25)
    Me.Label44.Name = "Label44"
    Me.Label44.Size = New System.Drawing.Size(39, 17)
    Me.Label44.TabIndex = 171
    Me.Label44.Text = "Phase"
    '
    'Label43
    '
    Me.Label43.BackColor = System.Drawing.SystemColors.Control
    Me.Label43.Location = New System.Drawing.Point(238, 26)
    Me.Label43.Name = "Label43"
    Me.Label43.Size = New System.Drawing.Size(40, 12)
    Me.Label43.TabIndex = 169
    Me.Label43.Text = "District"
    '
    'TxtComment
    '
    Me.TxtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtComment.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtComment.Location = New System.Drawing.Point(104, 192)
    Me.TxtComment.MaxLength = 20
    Me.TxtComment.Name = "TxtComment"
    Me.TxtComment.Size = New System.Drawing.Size(152, 21)
    Me.TxtComment.TabIndex = 12
    '
    'Label17
    '
    Me.Label17.Location = New System.Drawing.Point(16, 192)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(88, 16)
    Me.Label17.TabIndex = 174
    Me.Label17.Text = "Comment"
    '
    'LblStatus
    '
    Me.LblStatus.ForeColor = System.Drawing.Color.Magenta
    Me.LblStatus.Location = New System.Drawing.Point(104, 0)
    Me.LblStatus.Name = "LblStatus"
    Me.LblStatus.Size = New System.Drawing.Size(304, 16)
    Me.LblStatus.TabIndex = 176
    '
    'ChkLien
    '
    Me.ChkLien.AutoSize = True
    Me.ChkLien.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkLien.Location = New System.Drawing.Point(448, 152)
    Me.ChkLien.Name = "ChkLien"
    Me.ChkLien.Size = New System.Drawing.Size(64, 17)
    Me.ChkLien.TabIndex = 11
    Me.ChkLien.TabStop = False
    Me.ChkLien.Text = "Liened?"
    '
    'TxtDist
    '
    Me.TxtDist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDist.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(284, 21)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(32, 21)
    Me.TxtDist.TabIndex = 0
    '
    'TxtPhase
    '
    Me.TxtPhase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPhase.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhase.Location = New System.Drawing.Point(368, 22)
    Me.TxtPhase.MaxLength = 1
    Me.TxtPhase.Name = "TxtPhase"
    Me.TxtPhase.Size = New System.Drawing.Size(16, 21)
    Me.TxtPhase.TabIndex = 1
    '
    'TabCtl1
    '
    Me.TabCtl1.Controls.Add(Me.TabPgAssmnt)
    Me.TabCtl1.Controls.Add(Me.TabPgExempt)
    Me.TabCtl1.Controls.Add(Me.TabPgBank)
    Me.TabCtl1.Controls.Add(Me.TabPgEld)
    Me.TabCtl1.Controls.Add(Me.TabPgMV)
    Me.TabCtl1.Controls.Add(Me.TabPgUB)
    Me.TabCtl1.Location = New System.Drawing.Point(8, 295)
    Me.TabCtl1.Name = "TabCtl1"
    Me.TabCtl1.SelectedIndex = 0
    Me.TabCtl1.Size = New System.Drawing.Size(528, 168)
    Me.TabCtl1.TabIndex = 177
    '
    'TabPgAssmnt
    '
    Me.TabPgAssmnt.Controls.Add(Me.LnkCode9)
    Me.TabPgAssmnt.Controls.Add(Me.TxtCode9)
    Me.TabPgAssmnt.Controls.Add(Me.TxtAssmt9)
    Me.TabPgAssmnt.Controls.Add(Me.TxtUnit9)
    Me.TabPgAssmnt.Controls.Add(Me.LnkCode10)
    Me.TabPgAssmnt.Controls.Add(Me.TxtCode10)
    Me.TabPgAssmnt.Controls.Add(Me.LnkCode8)
    Me.TabPgAssmnt.Controls.Add(Me.TxtCode8)
    Me.TabPgAssmnt.Controls.Add(Me.TxtAssmt10)
    Me.TabPgAssmnt.Controls.Add(Me.TxtUnit10)
    Me.TabPgAssmnt.Controls.Add(Me.TxtAssmt8)
    Me.TabPgAssmnt.Controls.Add(Me.TxtUnit8)
    Me.TabPgAssmnt.Controls.Add(Me.LnkCode6)
    Me.TabPgAssmnt.Controls.Add(Me.TxtCode6)
    Me.TabPgAssmnt.Controls.Add(Me.LnkCode4)
    Me.TabPgAssmnt.Controls.Add(Me.TxtCode4)
    Me.TabPgAssmnt.Controls.Add(Me.LnkCode2)
    Me.TabPgAssmnt.Controls.Add(Me.TxtCode2)
    Me.TabPgAssmnt.Controls.Add(Me.LnkCode7)
    Me.TabPgAssmnt.Controls.Add(Me.TxtCode7)
    Me.TabPgAssmnt.Controls.Add(Me.LnkCode5)
    Me.TabPgAssmnt.Controls.Add(Me.TxtCode5)
    Me.TabPgAssmnt.Controls.Add(Me.LnkCode3)
    Me.TabPgAssmnt.Controls.Add(Me.TxtCode3)
    Me.TabPgAssmnt.Controls.Add(Me.LnkCode1)
    Me.TabPgAssmnt.Controls.Add(Me.TxtCode1)
    Me.TabPgAssmnt.Controls.Add(Me.TxtAssmt7)
    Me.TabPgAssmnt.Controls.Add(Me.TxtUnit7)
    Me.TabPgAssmnt.Controls.Add(Me.TxtAssmt6)
    Me.TabPgAssmnt.Controls.Add(Me.TxtUnit6)
    Me.TabPgAssmnt.Controls.Add(Me.TxtAssmt4)
    Me.TabPgAssmnt.Controls.Add(Me.TxtUnit4)
    Me.TabPgAssmnt.Controls.Add(Me.TxtAssmt5)
    Me.TabPgAssmnt.Controls.Add(Me.TxtUnit5)
    Me.TabPgAssmnt.Controls.Add(Me.TxtAssmt3)
    Me.TabPgAssmnt.Controls.Add(Me.TxtUnit3)
    Me.TabPgAssmnt.Controls.Add(Me.TxtAssmt2)
    Me.TabPgAssmnt.Controls.Add(Me.Label24)
    Me.TabPgAssmnt.Controls.Add(Me.Label27)
    Me.TabPgAssmnt.Controls.Add(Me.TxtUnit2)
    Me.TabPgAssmnt.Controls.Add(Me.Label28)
    Me.TabPgAssmnt.Controls.Add(Me.TxtAssmt1)
    Me.TabPgAssmnt.Controls.Add(Me.Label30)
    Me.TabPgAssmnt.Controls.Add(Me.Label34)
    Me.TabPgAssmnt.Controls.Add(Me.TxtUnit1)
    Me.TabPgAssmnt.Controls.Add(Me.Label35)
    Me.TabPgAssmnt.Location = New System.Drawing.Point(4, 22)
    Me.TabPgAssmnt.Name = "TabPgAssmnt"
    Me.TabPgAssmnt.Size = New System.Drawing.Size(520, 142)
    Me.TabPgAssmnt.TabIndex = 1
    Me.TabPgAssmnt.Text = "Assessment"
    Me.TabPgAssmnt.UseVisualStyleBackColor = True
    '
    'LnkCode9
    '
    Me.LnkCode9.Location = New System.Drawing.Point(8, 112)
    Me.LnkCode9.Name = "LnkCode9"
    Me.LnkCode9.Size = New System.Drawing.Size(16, 16)
    Me.LnkCode9.TabIndex = 228
    Me.LnkCode9.TabStop = True
    Me.LnkCode9.Text = "9"
    '
    'TxtCode9
    '
    Me.TxtCode9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode9.Location = New System.Drawing.Point(24, 112)
    Me.TxtCode9.MaxLength = 3
    Me.TxtCode9.Name = "TxtCode9"
    Me.TxtCode9.Size = New System.Drawing.Size(24, 20)
    Me.TxtCode9.TabIndex = 225
    '
    'TxtAssmt9
    '
    Me.TxtAssmt9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt9.Location = New System.Drawing.Point(96, 112)
    Me.TxtAssmt9.MaxLength = 9
    Me.TxtAssmt9.Name = "TxtAssmt9"
    Me.TxtAssmt9.Size = New System.Drawing.Size(72, 20)
    Me.TxtAssmt9.TabIndex = 227
    Me.TxtAssmt9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit9
    '
    Me.TxtUnit9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit9.Location = New System.Drawing.Point(56, 112)
    Me.TxtUnit9.MaxLength = 3
    Me.TxtUnit9.Name = "TxtUnit9"
    Me.TxtUnit9.Size = New System.Drawing.Size(32, 20)
    Me.TxtUnit9.TabIndex = 226
    Me.TxtUnit9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LnkCode10
    '
    Me.LnkCode10.Location = New System.Drawing.Point(184, 112)
    Me.LnkCode10.Name = "LnkCode10"
    Me.LnkCode10.Size = New System.Drawing.Size(24, 16)
    Me.LnkCode10.TabIndex = 224
    Me.LnkCode10.TabStop = True
    Me.LnkCode10.Text = "10"
    '
    'TxtCode10
    '
    Me.TxtCode10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode10.Location = New System.Drawing.Point(208, 112)
    Me.TxtCode10.MaxLength = 3
    Me.TxtCode10.Name = "TxtCode10"
    Me.TxtCode10.Size = New System.Drawing.Size(24, 20)
    Me.TxtCode10.TabIndex = 220
    '
    'LnkCode8
    '
    Me.LnkCode8.Location = New System.Drawing.Point(192, 88)
    Me.LnkCode8.Name = "LnkCode8"
    Me.LnkCode8.Size = New System.Drawing.Size(16, 16)
    Me.LnkCode8.TabIndex = 223
    Me.LnkCode8.TabStop = True
    Me.LnkCode8.Text = "8"
    '
    'TxtCode8
    '
    Me.TxtCode8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode8.Location = New System.Drawing.Point(208, 88)
    Me.TxtCode8.MaxLength = 3
    Me.TxtCode8.Name = "TxtCode8"
    Me.TxtCode8.Size = New System.Drawing.Size(24, 20)
    Me.TxtCode8.TabIndex = 217
    '
    'TxtAssmt10
    '
    Me.TxtAssmt10.Location = New System.Drawing.Point(280, 112)
    Me.TxtAssmt10.MaxLength = 9
    Me.TxtAssmt10.Name = "TxtAssmt10"
    Me.TxtAssmt10.Size = New System.Drawing.Size(72, 20)
    Me.TxtAssmt10.TabIndex = 222
    Me.TxtAssmt10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit10
    '
    Me.TxtUnit10.Location = New System.Drawing.Point(240, 112)
    Me.TxtUnit10.MaxLength = 3
    Me.TxtUnit10.Name = "TxtUnit10"
    Me.TxtUnit10.Size = New System.Drawing.Size(32, 20)
    Me.TxtUnit10.TabIndex = 221
    Me.TxtUnit10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt8
    '
    Me.TxtAssmt8.Location = New System.Drawing.Point(280, 88)
    Me.TxtAssmt8.MaxLength = 9
    Me.TxtAssmt8.Name = "TxtAssmt8"
    Me.TxtAssmt8.Size = New System.Drawing.Size(72, 20)
    Me.TxtAssmt8.TabIndex = 219
    Me.TxtAssmt8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit8
    '
    Me.TxtUnit8.Location = New System.Drawing.Point(240, 88)
    Me.TxtUnit8.MaxLength = 3
    Me.TxtUnit8.Name = "TxtUnit8"
    Me.TxtUnit8.Size = New System.Drawing.Size(32, 20)
    Me.TxtUnit8.TabIndex = 218
    Me.TxtUnit8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LnkCode6
    '
    Me.LnkCode6.Location = New System.Drawing.Point(192, 64)
    Me.LnkCode6.Name = "LnkCode6"
    Me.LnkCode6.Size = New System.Drawing.Size(16, 16)
    Me.LnkCode6.TabIndex = 215
    Me.LnkCode6.TabStop = True
    Me.LnkCode6.Text = "6"
    '
    'TxtCode6
    '
    Me.TxtCode6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode6.Location = New System.Drawing.Point(208, 64)
    Me.TxtCode6.MaxLength = 3
    Me.TxtCode6.Name = "TxtCode6"
    Me.TxtCode6.Size = New System.Drawing.Size(24, 20)
    Me.TxtCode6.TabIndex = 198
    '
    'LnkCode4
    '
    Me.LnkCode4.Location = New System.Drawing.Point(192, 40)
    Me.LnkCode4.Name = "LnkCode4"
    Me.LnkCode4.Size = New System.Drawing.Size(16, 16)
    Me.LnkCode4.TabIndex = 214
    Me.LnkCode4.TabStop = True
    Me.LnkCode4.Text = "4"
    '
    'TxtCode4
    '
    Me.TxtCode4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode4.Location = New System.Drawing.Point(208, 40)
    Me.TxtCode4.MaxLength = 3
    Me.TxtCode4.Name = "TxtCode4"
    Me.TxtCode4.Size = New System.Drawing.Size(24, 20)
    Me.TxtCode4.TabIndex = 192
    '
    'LnkCode2
    '
    Me.LnkCode2.Location = New System.Drawing.Point(192, 16)
    Me.LnkCode2.Name = "LnkCode2"
    Me.LnkCode2.Size = New System.Drawing.Size(16, 16)
    Me.LnkCode2.TabIndex = 213
    Me.LnkCode2.TabStop = True
    Me.LnkCode2.Text = "2"
    '
    'TxtCode2
    '
    Me.TxtCode2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode2.Location = New System.Drawing.Point(208, 16)
    Me.TxtCode2.MaxLength = 3
    Me.TxtCode2.Name = "TxtCode2"
    Me.TxtCode2.Size = New System.Drawing.Size(24, 20)
    Me.TxtCode2.TabIndex = 185
    '
    'LnkCode7
    '
    Me.LnkCode7.Location = New System.Drawing.Point(8, 88)
    Me.LnkCode7.Name = "LnkCode7"
    Me.LnkCode7.Size = New System.Drawing.Size(16, 16)
    Me.LnkCode7.TabIndex = 212
    Me.LnkCode7.TabStop = True
    Me.LnkCode7.Text = "7"
    '
    'TxtCode7
    '
    Me.TxtCode7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode7.Location = New System.Drawing.Point(24, 88)
    Me.TxtCode7.MaxLength = 3
    Me.TxtCode7.Name = "TxtCode7"
    Me.TxtCode7.Size = New System.Drawing.Size(24, 20)
    Me.TxtCode7.TabIndex = 201
    '
    'LnkCode5
    '
    Me.LnkCode5.Location = New System.Drawing.Point(8, 64)
    Me.LnkCode5.Name = "LnkCode5"
    Me.LnkCode5.Size = New System.Drawing.Size(16, 16)
    Me.LnkCode5.TabIndex = 211
    Me.LnkCode5.TabStop = True
    Me.LnkCode5.Text = "5"
    '
    'TxtCode5
    '
    Me.TxtCode5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode5.Location = New System.Drawing.Point(24, 64)
    Me.TxtCode5.MaxLength = 3
    Me.TxtCode5.Name = "TxtCode5"
    Me.TxtCode5.Size = New System.Drawing.Size(24, 20)
    Me.TxtCode5.TabIndex = 195
    '
    'LnkCode3
    '
    Me.LnkCode3.Location = New System.Drawing.Point(8, 40)
    Me.LnkCode3.Name = "LnkCode3"
    Me.LnkCode3.Size = New System.Drawing.Size(16, 16)
    Me.LnkCode3.TabIndex = 210
    Me.LnkCode3.TabStop = True
    Me.LnkCode3.Text = "3"
    '
    'TxtCode3
    '
    Me.TxtCode3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode3.Location = New System.Drawing.Point(24, 40)
    Me.TxtCode3.MaxLength = 3
    Me.TxtCode3.Name = "TxtCode3"
    Me.TxtCode3.Size = New System.Drawing.Size(24, 20)
    Me.TxtCode3.TabIndex = 188
    '
    'LnkCode1
    '
    Me.LnkCode1.Location = New System.Drawing.Point(8, 16)
    Me.LnkCode1.Name = "LnkCode1"
    Me.LnkCode1.Size = New System.Drawing.Size(16, 16)
    Me.LnkCode1.TabIndex = 209
    Me.LnkCode1.TabStop = True
    Me.LnkCode1.Text = "1"
    '
    'TxtCode1
    '
    Me.TxtCode1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode1.Location = New System.Drawing.Point(24, 16)
    Me.TxtCode1.MaxLength = 3
    Me.TxtCode1.Name = "TxtCode1"
    Me.TxtCode1.Size = New System.Drawing.Size(24, 20)
    Me.TxtCode1.TabIndex = 182
    '
    'TxtAssmt7
    '
    Me.TxtAssmt7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt7.Location = New System.Drawing.Point(96, 88)
    Me.TxtAssmt7.MaxLength = 9
    Me.TxtAssmt7.Name = "TxtAssmt7"
    Me.TxtAssmt7.Size = New System.Drawing.Size(72, 20)
    Me.TxtAssmt7.TabIndex = 204
    Me.TxtAssmt7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit7
    '
    Me.TxtUnit7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit7.Location = New System.Drawing.Point(56, 88)
    Me.TxtUnit7.MaxLength = 3
    Me.TxtUnit7.Name = "TxtUnit7"
    Me.TxtUnit7.Size = New System.Drawing.Size(32, 20)
    Me.TxtUnit7.TabIndex = 202
    Me.TxtUnit7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt6
    '
    Me.TxtAssmt6.Location = New System.Drawing.Point(280, 64)
    Me.TxtAssmt6.MaxLength = 9
    Me.TxtAssmt6.Name = "TxtAssmt6"
    Me.TxtAssmt6.Size = New System.Drawing.Size(72, 20)
    Me.TxtAssmt6.TabIndex = 200
    Me.TxtAssmt6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit6
    '
    Me.TxtUnit6.Location = New System.Drawing.Point(240, 64)
    Me.TxtUnit6.MaxLength = 6
    Me.TxtUnit6.Name = "TxtUnit6"
    Me.TxtUnit6.Size = New System.Drawing.Size(32, 20)
    Me.TxtUnit6.TabIndex = 199
    Me.TxtUnit6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt4
    '
    Me.TxtAssmt4.Location = New System.Drawing.Point(280, 40)
    Me.TxtAssmt4.MaxLength = 9
    Me.TxtAssmt4.Name = "TxtAssmt4"
    Me.TxtAssmt4.Size = New System.Drawing.Size(72, 20)
    Me.TxtAssmt4.TabIndex = 194
    Me.TxtAssmt4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit4
    '
    Me.TxtUnit4.Location = New System.Drawing.Point(240, 40)
    Me.TxtUnit4.MaxLength = 6
    Me.TxtUnit4.Name = "TxtUnit4"
    Me.TxtUnit4.Size = New System.Drawing.Size(32, 20)
    Me.TxtUnit4.TabIndex = 193
    Me.TxtUnit4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt5
    '
    Me.TxtAssmt5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt5.Location = New System.Drawing.Point(96, 64)
    Me.TxtAssmt5.MaxLength = 9
    Me.TxtAssmt5.Name = "TxtAssmt5"
    Me.TxtAssmt5.Size = New System.Drawing.Size(72, 20)
    Me.TxtAssmt5.TabIndex = 197
    Me.TxtAssmt5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit5
    '
    Me.TxtUnit5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit5.Location = New System.Drawing.Point(56, 64)
    Me.TxtUnit5.MaxLength = 3
    Me.TxtUnit5.Name = "TxtUnit5"
    Me.TxtUnit5.Size = New System.Drawing.Size(32, 20)
    Me.TxtUnit5.TabIndex = 196
    Me.TxtUnit5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt3
    '
    Me.TxtAssmt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt3.Location = New System.Drawing.Point(96, 40)
    Me.TxtAssmt3.MaxLength = 9
    Me.TxtAssmt3.Name = "TxtAssmt3"
    Me.TxtAssmt3.Size = New System.Drawing.Size(72, 20)
    Me.TxtAssmt3.TabIndex = 190
    Me.TxtAssmt3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit3
    '
    Me.TxtUnit3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit3.Location = New System.Drawing.Point(56, 40)
    Me.TxtUnit3.MaxLength = 3
    Me.TxtUnit3.Name = "TxtUnit3"
    Me.TxtUnit3.Size = New System.Drawing.Size(32, 20)
    Me.TxtUnit3.TabIndex = 189
    Me.TxtUnit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt2
    '
    Me.TxtAssmt2.Location = New System.Drawing.Point(280, 16)
    Me.TxtAssmt2.MaxLength = 9
    Me.TxtAssmt2.Name = "TxtAssmt2"
    Me.TxtAssmt2.Size = New System.Drawing.Size(72, 20)
    Me.TxtAssmt2.TabIndex = 187
    Me.TxtAssmt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label24
    '
    Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label24.ForeColor = System.Drawing.Color.Black
    Me.Label24.Location = New System.Drawing.Point(280, 0)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(81, 16)
    Me.Label24.TabIndex = 208
    Me.Label24.Text = "Assessment"
    '
    'Label27
    '
    Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label27.ForeColor = System.Drawing.Color.Black
    Me.Label27.Location = New System.Drawing.Point(240, 0)
    Me.Label27.Name = "Label27"
    Me.Label27.Size = New System.Drawing.Size(32, 16)
    Me.Label27.TabIndex = 207
    Me.Label27.Text = "Unit"
    '
    'TxtUnit2
    '
    Me.TxtUnit2.Location = New System.Drawing.Point(240, 16)
    Me.TxtUnit2.MaxLength = 6
    Me.TxtUnit2.Name = "TxtUnit2"
    Me.TxtUnit2.Size = New System.Drawing.Size(32, 20)
    Me.TxtUnit2.TabIndex = 186
    Me.TxtUnit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label28
    '
    Me.Label28.AutoSize = True
    Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label28.ForeColor = System.Drawing.Color.Black
    Me.Label28.Location = New System.Drawing.Point(200, 0)
    Me.Label28.Name = "Label28"
    Me.Label28.Size = New System.Drawing.Size(36, 13)
    Me.Label28.TabIndex = 206
    Me.Label28.Text = "Code"
    '
    'TxtAssmt1
    '
    Me.TxtAssmt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt1.Location = New System.Drawing.Point(96, 16)
    Me.TxtAssmt1.MaxLength = 9
    Me.TxtAssmt1.Name = "TxtAssmt1"
    Me.TxtAssmt1.Size = New System.Drawing.Size(72, 20)
    Me.TxtAssmt1.TabIndex = 184
    Me.TxtAssmt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label30
    '
    Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label30.ForeColor = System.Drawing.Color.Black
    Me.Label30.Location = New System.Drawing.Point(96, 0)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(90, 16)
    Me.Label30.TabIndex = 205
    Me.Label30.Text = "Assessment"
    '
    'Label34
    '
    Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label34.ForeColor = System.Drawing.Color.Black
    Me.Label34.Location = New System.Drawing.Point(56, 0)
    Me.Label34.Name = "Label34"
    Me.Label34.Size = New System.Drawing.Size(40, 16)
    Me.Label34.TabIndex = 203
    Me.Label34.Text = "Unit"
    '
    'TxtUnit1
    '
    Me.TxtUnit1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit1.Location = New System.Drawing.Point(56, 16)
    Me.TxtUnit1.MaxLength = 3
    Me.TxtUnit1.Name = "TxtUnit1"
    Me.TxtUnit1.Size = New System.Drawing.Size(32, 20)
    Me.TxtUnit1.TabIndex = 183
    Me.TxtUnit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label35
    '
    Me.Label35.AutoSize = True
    Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label35.ForeColor = System.Drawing.Color.Black
    Me.Label35.Location = New System.Drawing.Point(16, 0)
    Me.Label35.Name = "Label35"
    Me.Label35.Size = New System.Drawing.Size(36, 13)
    Me.Label35.TabIndex = 191
    Me.Label35.Text = "Code"
    '
    'TabPgExempt
    '
    Me.TabPgExempt.Controls.Add(Me.LnkExempt6)
    Me.TabPgExempt.Controls.Add(Me.TxtExempt6)
    Me.TabPgExempt.Controls.Add(Me.LnkExempt7)
    Me.TabPgExempt.Controls.Add(Me.TxtExempt7)
    Me.TabPgExempt.Controls.Add(Me.LnkExempt5)
    Me.TabPgExempt.Controls.Add(Me.TxtExempt5)
    Me.TabPgExempt.Controls.Add(Me.LnkExempt3)
    Me.TabPgExempt.Controls.Add(Me.TxtExempt3)
    Me.TabPgExempt.Controls.Add(Me.LnkExempt4)
    Me.TabPgExempt.Controls.Add(Me.TxtExempt4)
    Me.TabPgExempt.Controls.Add(Me.LnkExempt2)
    Me.TabPgExempt.Controls.Add(Me.TxtExempt2)
    Me.TabPgExempt.Controls.Add(Me.LnkExempt1)
    Me.TabPgExempt.Controls.Add(Me.TxtExempt1)
    Me.TabPgExempt.Controls.Add(Me.TxtExam7)
    Me.TabPgExempt.Controls.Add(Me.TxtExam6)
    Me.TabPgExempt.Controls.Add(Me.TxtExam4)
    Me.TabPgExempt.Controls.Add(Me.TxtExam2)
    Me.TabPgExempt.Controls.Add(Me.Label46)
    Me.TabPgExempt.Controls.Add(Me.Label47)
    Me.TabPgExempt.Controls.Add(Me.TxtExam5)
    Me.TabPgExempt.Controls.Add(Me.TxtExam3)
    Me.TabPgExempt.Controls.Add(Me.TxtExam1)
    Me.TabPgExempt.Controls.Add(Me.Label50)
    Me.TabPgExempt.Controls.Add(Me.Label52)
    Me.TabPgExempt.Location = New System.Drawing.Point(4, 22)
    Me.TabPgExempt.Name = "TabPgExempt"
    Me.TabPgExempt.Size = New System.Drawing.Size(520, 142)
    Me.TabPgExempt.TabIndex = 2
    Me.TabPgExempt.Text = "Exemptions"
    Me.TabPgExempt.UseVisualStyleBackColor = True
    '
    'LnkExempt6
    '
    Me.LnkExempt6.Location = New System.Drawing.Point(192, 72)
    Me.LnkExempt6.Name = "LnkExempt6"
    Me.LnkExempt6.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt6.TabIndex = 207
    Me.LnkExempt6.TabStop = True
    Me.LnkExempt6.Text = "6"
    '
    'TxtExempt6
    '
    Me.TxtExempt6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt6.Location = New System.Drawing.Point(216, 72)
    Me.TxtExempt6.MaxLength = 3
    Me.TxtExempt6.Name = "TxtExempt6"
    Me.TxtExempt6.Size = New System.Drawing.Size(32, 20)
    Me.TxtExempt6.TabIndex = 193
    '
    'LnkExempt7
    '
    Me.LnkExempt7.Location = New System.Drawing.Point(8, 96)
    Me.LnkExempt7.Name = "LnkExempt7"
    Me.LnkExempt7.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt7.TabIndex = 206
    Me.LnkExempt7.TabStop = True
    Me.LnkExempt7.Text = "7"
    '
    'TxtExempt7
    '
    Me.TxtExempt7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt7.Location = New System.Drawing.Point(32, 96)
    Me.TxtExempt7.MaxLength = 3
    Me.TxtExempt7.Name = "TxtExempt7"
    Me.TxtExempt7.Size = New System.Drawing.Size(32, 20)
    Me.TxtExempt7.TabIndex = 194
    '
    'LnkExempt5
    '
    Me.LnkExempt5.Location = New System.Drawing.Point(8, 72)
    Me.LnkExempt5.Name = "LnkExempt5"
    Me.LnkExempt5.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt5.TabIndex = 205
    Me.LnkExempt5.TabStop = True
    Me.LnkExempt5.Text = "5"
    '
    'TxtExempt5
    '
    Me.TxtExempt5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt5.Location = New System.Drawing.Point(32, 72)
    Me.TxtExempt5.MaxLength = 3
    Me.TxtExempt5.Name = "TxtExempt5"
    Me.TxtExempt5.Size = New System.Drawing.Size(32, 20)
    Me.TxtExempt5.TabIndex = 191
    '
    'LnkExempt3
    '
    Me.LnkExempt3.Location = New System.Drawing.Point(8, 48)
    Me.LnkExempt3.Name = "LnkExempt3"
    Me.LnkExempt3.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt3.TabIndex = 204
    Me.LnkExempt3.TabStop = True
    Me.LnkExempt3.Text = "3"
    '
    'TxtExempt3
    '
    Me.TxtExempt3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt3.Location = New System.Drawing.Point(32, 48)
    Me.TxtExempt3.MaxLength = 3
    Me.TxtExempt3.Name = "TxtExempt3"
    Me.TxtExempt3.Size = New System.Drawing.Size(32, 20)
    Me.TxtExempt3.TabIndex = 187
    '
    'LnkExempt4
    '
    Me.LnkExempt4.Location = New System.Drawing.Point(192, 48)
    Me.LnkExempt4.Name = "LnkExempt4"
    Me.LnkExempt4.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt4.TabIndex = 203
    Me.LnkExempt4.TabStop = True
    Me.LnkExempt4.Text = "4"
    '
    'TxtExempt4
    '
    Me.TxtExempt4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt4.Location = New System.Drawing.Point(216, 48)
    Me.TxtExempt4.MaxLength = 3
    Me.TxtExempt4.Name = "TxtExempt4"
    Me.TxtExempt4.Size = New System.Drawing.Size(32, 20)
    Me.TxtExempt4.TabIndex = 189
    '
    'LnkExempt2
    '
    Me.LnkExempt2.Location = New System.Drawing.Point(192, 24)
    Me.LnkExempt2.Name = "LnkExempt2"
    Me.LnkExempt2.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt2.TabIndex = 202
    Me.LnkExempt2.TabStop = True
    Me.LnkExempt2.Text = "2"
    '
    'TxtExempt2
    '
    Me.TxtExempt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt2.Location = New System.Drawing.Point(216, 24)
    Me.TxtExempt2.MaxLength = 3
    Me.TxtExempt2.Name = "TxtExempt2"
    Me.TxtExempt2.Size = New System.Drawing.Size(32, 20)
    Me.TxtExempt2.TabIndex = 185
    '
    'LnkExempt1
    '
    Me.LnkExempt1.Location = New System.Drawing.Point(8, 24)
    Me.LnkExempt1.Name = "LnkExempt1"
    Me.LnkExempt1.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt1.TabIndex = 201
    Me.LnkExempt1.TabStop = True
    Me.LnkExempt1.Text = "1"
    '
    'TxtExempt1
    '
    Me.TxtExempt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt1.Location = New System.Drawing.Point(32, 24)
    Me.TxtExempt1.MaxLength = 3
    Me.TxtExempt1.Name = "TxtExempt1"
    Me.TxtExempt1.Size = New System.Drawing.Size(32, 20)
    Me.TxtExempt1.TabIndex = 183
    '
    'TxtExam7
    '
    Me.TxtExam7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam7.Location = New System.Drawing.Point(72, 96)
    Me.TxtExam7.MaxLength = 7
    Me.TxtExam7.Name = "TxtExam7"
    Me.TxtExam7.Size = New System.Drawing.Size(72, 20)
    Me.TxtExam7.TabIndex = 200
    Me.TxtExam7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam6
    '
    Me.TxtExam6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam6.Location = New System.Drawing.Point(256, 72)
    Me.TxtExam6.MaxLength = 7
    Me.TxtExam6.Name = "TxtExam6"
    Me.TxtExam6.Size = New System.Drawing.Size(72, 20)
    Me.TxtExam6.TabIndex = 199
    Me.TxtExam6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam4
    '
    Me.TxtExam4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam4.Location = New System.Drawing.Point(256, 48)
    Me.TxtExam4.MaxLength = 7
    Me.TxtExam4.Name = "TxtExam4"
    Me.TxtExam4.Size = New System.Drawing.Size(72, 20)
    Me.TxtExam4.TabIndex = 190
    Me.TxtExam4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam2
    '
    Me.TxtExam2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam2.Location = New System.Drawing.Point(256, 24)
    Me.TxtExam2.MaxLength = 7
    Me.TxtExam2.Name = "TxtExam2"
    Me.TxtExam2.Size = New System.Drawing.Size(72, 20)
    Me.TxtExam2.TabIndex = 186
    Me.TxtExam2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label46
    '
    Me.Label46.AutoSize = True
    Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label46.ForeColor = System.Drawing.Color.Black
    Me.Label46.Location = New System.Drawing.Point(280, 8)
    Me.Label46.Name = "Label46"
    Me.Label46.Size = New System.Drawing.Size(49, 13)
    Me.Label46.TabIndex = 198
    Me.Label46.Text = "Amount"
    '
    'Label47
    '
    Me.Label47.AutoSize = True
    Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label47.ForeColor = System.Drawing.Color.Black
    Me.Label47.Location = New System.Drawing.Point(216, 8)
    Me.Label47.Name = "Label47"
    Me.Label47.Size = New System.Drawing.Size(36, 13)
    Me.Label47.TabIndex = 197
    Me.Label47.Text = "Code"
    '
    'TxtExam5
    '
    Me.TxtExam5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam5.Location = New System.Drawing.Point(72, 72)
    Me.TxtExam5.MaxLength = 7
    Me.TxtExam5.Name = "TxtExam5"
    Me.TxtExam5.Size = New System.Drawing.Size(72, 20)
    Me.TxtExam5.TabIndex = 192
    Me.TxtExam5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam3
    '
    Me.TxtExam3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam3.Location = New System.Drawing.Point(72, 48)
    Me.TxtExam3.MaxLength = 7
    Me.TxtExam3.Name = "TxtExam3"
    Me.TxtExam3.Size = New System.Drawing.Size(72, 20)
    Me.TxtExam3.TabIndex = 188
    Me.TxtExam3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam1
    '
    Me.TxtExam1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam1.Location = New System.Drawing.Point(72, 24)
    Me.TxtExam1.MaxLength = 7
    Me.TxtExam1.Name = "TxtExam1"
    Me.TxtExam1.Size = New System.Drawing.Size(72, 20)
    Me.TxtExam1.TabIndex = 184
    Me.TxtExam1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label50
    '
    Me.Label50.AutoSize = True
    Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label50.ForeColor = System.Drawing.Color.Black
    Me.Label50.Location = New System.Drawing.Point(96, 8)
    Me.Label50.Name = "Label50"
    Me.Label50.Size = New System.Drawing.Size(49, 13)
    Me.Label50.TabIndex = 196
    Me.Label50.Text = "Amount"
    '
    'Label52
    '
    Me.Label52.AutoSize = True
    Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label52.ForeColor = System.Drawing.Color.Black
    Me.Label52.Location = New System.Drawing.Point(32, 8)
    Me.Label52.Name = "Label52"
    Me.Label52.Size = New System.Drawing.Size(36, 13)
    Me.Label52.TabIndex = 195
    Me.Label52.Text = "Code"
    '
    'TabPgBank
    '
    Me.TabPgBank.Controls.Add(Me.LnkBankCd)
    Me.TabPgBank.Controls.Add(Me.LnkBankSvc)
    Me.TabPgBank.Controls.Add(Me.TxtVol)
    Me.TabPgBank.Controls.Add(Me.TxtPage)
    Me.TabPgBank.Controls.Add(Me.Label21)
    Me.TabPgBank.Controls.Add(Me.TxtMap)
    Me.TabPgBank.Controls.Add(Me.LblMap)
    Me.TabPgBank.Controls.Add(Me.TxtBankServ)
    Me.TabPgBank.Controls.Add(Me.TxtBankCd)
    Me.TabPgBank.Location = New System.Drawing.Point(4, 22)
    Me.TabPgBank.Name = "TabPgBank"
    Me.TabPgBank.Size = New System.Drawing.Size(520, 142)
    Me.TabPgBank.TabIndex = 0
    Me.TabPgBank.Text = "Bank/Map"
    Me.TabPgBank.UseVisualStyleBackColor = True
    '
    'LnkBankCd
    '
    Me.LnkBankCd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkBankCd.Location = New System.Drawing.Point(8, 11)
    Me.LnkBankCd.Name = "LnkBankCd"
    Me.LnkBankCd.Size = New System.Drawing.Size(80, 18)
    Me.LnkBankCd.TabIndex = 169
    Me.LnkBankCd.TabStop = True
    Me.LnkBankCd.Text = "Bank code"
    '
    'LnkBankSvc
    '
    Me.LnkBankSvc.Location = New System.Drawing.Point(8, 36)
    Me.LnkBankSvc.Name = "LnkBankSvc"
    Me.LnkBankSvc.Size = New System.Drawing.Size(80, 16)
    Me.LnkBankSvc.TabIndex = 156
    Me.LnkBankSvc.TabStop = True
    Me.LnkBankSvc.Text = "Bank Service"
    '
    'TxtVol
    '
    Me.TxtVol.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVol.Location = New System.Drawing.Point(100, 80)
    Me.TxtVol.MaxLength = 5
    Me.TxtVol.Name = "TxtVol"
    Me.TxtVol.Size = New System.Drawing.Size(40, 20)
    Me.TxtVol.TabIndex = 153
    Me.TxtVol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtPage
    '
    Me.TxtPage.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPage.Location = New System.Drawing.Point(148, 80)
    Me.TxtPage.MaxLength = 5
    Me.TxtPage.Name = "TxtPage"
    Me.TxtPage.Size = New System.Drawing.Size(40, 20)
    Me.TxtPage.TabIndex = 154
    Me.TxtPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label21
    '
    Me.Label21.Location = New System.Drawing.Point(8, 80)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(64, 16)
    Me.Label21.TabIndex = 155
    Me.Label21.Text = "Vol/Page"
    '
    'TxtMap
    '
    Me.TxtMap.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMap.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMap.Location = New System.Drawing.Point(100, 56)
    Me.TxtMap.MaxLength = 15
    Me.TxtMap.Name = "TxtMap"
    Me.TxtMap.Size = New System.Drawing.Size(112, 20)
    Me.TxtMap.TabIndex = 19
    '
    'LblMap
    '
    Me.LblMap.Location = New System.Drawing.Point(8, 56)
    Me.LblMap.Name = "LblMap"
    Me.LblMap.Size = New System.Drawing.Size(88, 16)
    Me.LblMap.TabIndex = 18
    Me.LblMap.Text = "Map Block Lot"
    '
    'TxtBankServ
    '
    Me.TxtBankServ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBankServ.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBankServ.Location = New System.Drawing.Point(100, 32)
    Me.TxtBankServ.MaxLength = 1
    Me.TxtBankServ.Name = "TxtBankServ"
    Me.TxtBankServ.Size = New System.Drawing.Size(20, 20)
    Me.TxtBankServ.TabIndex = 6
    '
    'TxtBankCd
    '
    Me.TxtBankCd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBankCd.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBankCd.Location = New System.Drawing.Point(100, 8)
    Me.TxtBankCd.MaxLength = 2
    Me.TxtBankCd.Name = "TxtBankCd"
    Me.TxtBankCd.Size = New System.Drawing.Size(24, 20)
    Me.TxtBankCd.TabIndex = 5
    '
    'TabPgEld
    '
    Me.TabPgEld.Controls.Add(Me.GroupBox5)
    Me.TabPgEld.Location = New System.Drawing.Point(4, 22)
    Me.TabPgEld.Name = "TabPgEld"
    Me.TabPgEld.Size = New System.Drawing.Size(520, 142)
    Me.TabPgEld.TabIndex = 3
    Me.TabPgEld.Text = "Elderly"
    Me.TabPgEld.UseVisualStyleBackColor = True
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.LnkEldPerc)
    Me.GroupBox5.Controls.Add(Me.RbEldNA)
    Me.GroupBox5.Controls.Add(Me.TxtEldAdj)
    Me.GroupBox5.Controls.Add(Me.TxtEldTax)
    Me.GroupBox5.Controls.Add(Me.TxtEldMin)
    Me.GroupBox5.Controls.Add(Me.TxtEldMax)
    Me.GroupBox5.Controls.Add(Me.TxtEldPerc)
    Me.GroupBox5.Controls.Add(Me.TxtEldYear)
    Me.GroupBox5.Controls.Add(Me.Label60)
    Me.GroupBox5.Controls.Add(Me.Label59)
    Me.GroupBox5.Controls.Add(Me.Label58)
    Me.GroupBox5.Controls.Add(Me.Label57)
    Me.GroupBox5.Controls.Add(Me.Label55)
    Me.GroupBox5.Controls.Add(Me.RbEldFrozen)
    Me.GroupBox5.Controls.Add(Me.RbEldHeart)
    Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox5.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox5.Location = New System.Drawing.Point(8, 0)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(504, 136)
    Me.GroupBox5.TabIndex = 126
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "Heart/Frozen Program"
    '
    'LnkEldPerc
    '
    Me.LnkEldPerc.Location = New System.Drawing.Point(16, 64)
    Me.LnkEldPerc.Name = "LnkEldPerc"
    Me.LnkEldPerc.Size = New System.Drawing.Size(64, 16)
    Me.LnkEldPerc.TabIndex = 175
    Me.LnkEldPerc.TabStop = True
    Me.LnkEldPerc.Text = "Percentage"
    '
    'RbEldNA
    '
    Me.RbEldNA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbEldNA.ForeColor = System.Drawing.Color.Black
    Me.RbEldNA.Location = New System.Drawing.Point(136, 16)
    Me.RbEldNA.Name = "RbEldNA"
    Me.RbEldNA.Size = New System.Drawing.Size(48, 16)
    Me.RbEldNA.TabIndex = 128
    Me.RbEldNA.Text = "N/A"
    '
    'TxtEldAdj
    '
    Me.TxtEldAdj.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtEldAdj.Location = New System.Drawing.Point(264, 112)
    Me.TxtEldAdj.MaxLength = 8
    Me.TxtEldAdj.Name = "TxtEldAdj"
    Me.TxtEldAdj.Size = New System.Drawing.Size(72, 20)
    Me.TxtEldAdj.TabIndex = 127
    Me.TxtEldAdj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtEldTax
    '
    Me.TxtEldTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtEldTax.Location = New System.Drawing.Point(264, 88)
    Me.TxtEldTax.MaxLength = 8
    Me.TxtEldTax.Name = "TxtEldTax"
    Me.TxtEldTax.Size = New System.Drawing.Size(72, 20)
    Me.TxtEldTax.TabIndex = 74
    Me.TxtEldTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtEldMin
    '
    Me.TxtEldMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtEldMin.Location = New System.Drawing.Point(96, 112)
    Me.TxtEldMin.MaxLength = 5
    Me.TxtEldMin.Name = "TxtEldMin"
    Me.TxtEldMin.Size = New System.Drawing.Size(56, 20)
    Me.TxtEldMin.TabIndex = 73
    Me.TxtEldMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtEldMax
    '
    Me.TxtEldMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtEldMax.Location = New System.Drawing.Point(96, 88)
    Me.TxtEldMax.MaxLength = 5
    Me.TxtEldMax.Name = "TxtEldMax"
    Me.TxtEldMax.Size = New System.Drawing.Size(56, 20)
    Me.TxtEldMax.TabIndex = 72
    Me.TxtEldMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtEldPerc
    '
    Me.TxtEldPerc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtEldPerc.Location = New System.Drawing.Point(96, 64)
    Me.TxtEldPerc.MaxLength = 3
    Me.TxtEldPerc.Name = "TxtEldPerc"
    Me.TxtEldPerc.Size = New System.Drawing.Size(40, 20)
    Me.TxtEldPerc.TabIndex = 71
    Me.TxtEldPerc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtEldYear
    '
    Me.TxtEldYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtEldYear.Location = New System.Drawing.Point(96, 40)
    Me.TxtEldYear.MaxLength = 4
    Me.TxtEldYear.Name = "TxtEldYear"
    Me.TxtEldYear.Size = New System.Drawing.Size(40, 20)
    Me.TxtEldYear.TabIndex = 70
    Me.TxtEldYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label60
    '
    Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label60.ForeColor = System.Drawing.Color.Black
    Me.Label60.Location = New System.Drawing.Point(184, 112)
    Me.Label60.Name = "Label60"
    Me.Label60.Size = New System.Drawing.Size(64, 16)
    Me.Label60.TabIndex = 7
    Me.Label60.Text = "Adjustment"
    '
    'Label59
    '
    Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label59.ForeColor = System.Drawing.Color.Black
    Me.Label59.Location = New System.Drawing.Point(184, 88)
    Me.Label59.Name = "Label59"
    Me.Label59.Size = New System.Drawing.Size(64, 16)
    Me.Label59.TabIndex = 6
    Me.Label59.Text = "Frozen Tax"
    '
    'Label58
    '
    Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label58.ForeColor = System.Drawing.Color.Black
    Me.Label58.Location = New System.Drawing.Point(16, 112)
    Me.Label58.Name = "Label58"
    Me.Label58.Size = New System.Drawing.Size(56, 16)
    Me.Label58.TabIndex = 5
    Me.Label58.Text = "Minimum"
    '
    'Label57
    '
    Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label57.ForeColor = System.Drawing.Color.Black
    Me.Label57.Location = New System.Drawing.Point(16, 88)
    Me.Label57.Name = "Label57"
    Me.Label57.Size = New System.Drawing.Size(56, 16)
    Me.Label57.TabIndex = 4
    Me.Label57.Text = "Maximum"
    '
    'Label55
    '
    Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label55.ForeColor = System.Drawing.Color.Black
    Me.Label55.Location = New System.Drawing.Point(16, 40)
    Me.Label55.Name = "Label55"
    Me.Label55.Size = New System.Drawing.Size(56, 16)
    Me.Label55.TabIndex = 2
    Me.Label55.Text = "Year"
    '
    'RbEldFrozen
    '
    Me.RbEldFrozen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbEldFrozen.ForeColor = System.Drawing.Color.Black
    Me.RbEldFrozen.Location = New System.Drawing.Point(72, 16)
    Me.RbEldFrozen.Name = "RbEldFrozen"
    Me.RbEldFrozen.Size = New System.Drawing.Size(64, 16)
    Me.RbEldFrozen.TabIndex = 1
    Me.RbEldFrozen.Text = "Frozen"
    '
    'RbEldHeart
    '
    Me.RbEldHeart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbEldHeart.ForeColor = System.Drawing.Color.Black
    Me.RbEldHeart.Location = New System.Drawing.Point(8, 16)
    Me.RbEldHeart.Name = "RbEldHeart"
    Me.RbEldHeart.Size = New System.Drawing.Size(56, 16)
    Me.RbEldHeart.TabIndex = 0
    Me.RbEldHeart.Text = "Heart"
    '
    'TabPgMV
    '
    Me.TabPgMV.Controls.Add(Me.GrpCredit)
    Me.TabPgMV.Controls.Add(Me.LnkAsmt)
    Me.TabPgMV.Controls.Add(Me.TxtAss)
    Me.TabPgMV.Controls.Add(Me.Label29)
    Me.TabPgMV.Controls.Add(Me.TxtRegno)
    Me.TabPgMV.Controls.Add(Me.Label36)
    Me.TabPgMV.Controls.Add(Me.TxtVIN)
    Me.TabPgMV.Controls.Add(Me.Label37)
    Me.TabPgMV.Controls.Add(Me.TxtClass)
    Me.TabPgMV.Controls.Add(Me.Label38)
    Me.TabPgMV.Controls.Add(Me.TxtYear)
    Me.TabPgMV.Controls.Add(Me.Label40)
    Me.TabPgMV.Controls.Add(Me.TxtModel)
    Me.TabPgMV.Controls.Add(Me.Label41)
    Me.TabPgMV.Controls.Add(Me.TxtValue)
    Me.TabPgMV.Controls.Add(Me.Label42)
    Me.TabPgMV.Controls.Add(Me.TxtMake)
    Me.TabPgMV.Location = New System.Drawing.Point(4, 22)
    Me.TabPgMV.Name = "TabPgMV"
    Me.TabPgMV.Size = New System.Drawing.Size(520, 142)
    Me.TabPgMV.TabIndex = 4
    Me.TabPgMV.Text = "MV"
    Me.TabPgMV.UseVisualStyleBackColor = True
    '
    'GrpCredit
    '
    Me.GrpCredit.Controls.Add(Me.LnkOAsmt)
    Me.GrpCredit.Controls.Add(Me.TxtOAss)
    Me.GrpCredit.Controls.Add(Me.TxtORegNo)
    Me.GrpCredit.Controls.Add(Me.TxtOVIN)
    Me.GrpCredit.Controls.Add(Me.TxtOClass)
    Me.GrpCredit.Controls.Add(Me.TxtOYear)
    Me.GrpCredit.Controls.Add(Me.TxtOModel)
    Me.GrpCredit.Controls.Add(Me.TxtOValue)
    Me.GrpCredit.Controls.Add(Me.TxtOMake)
    Me.GrpCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpCredit.Location = New System.Drawing.Point(8, 64)
    Me.GrpCredit.Name = "GrpCredit"
    Me.GrpCredit.Size = New System.Drawing.Size(504, 64)
    Me.GrpCredit.TabIndex = 229
    Me.GrpCredit.TabStop = False
    Me.GrpCredit.Text = "Credit Vehicle"
    '
    'LnkOAsmt
    '
    Me.LnkOAsmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkOAsmt.Location = New System.Drawing.Point(460, 44)
    Me.LnkOAsmt.Name = "LnkOAsmt"
    Me.LnkOAsmt.Size = New System.Drawing.Size(32, 16)
    Me.LnkOAsmt.TabIndex = 237
    Me.LnkOAsmt.TabStop = True
    Me.LnkOAsmt.Text = "Asmt"
    '
    'TxtOAss
    '
    Me.TxtOAss.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOAss.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOAss.Location = New System.Drawing.Point(472, 20)
    Me.TxtOAss.MaxLength = 2
    Me.TxtOAss.Name = "TxtOAss"
    Me.TxtOAss.Size = New System.Drawing.Size(16, 20)
    Me.TxtOAss.TabIndex = 236
    '
    'TxtORegNo
    '
    Me.TxtORegNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtORegNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtORegNo.Location = New System.Drawing.Point(328, 20)
    Me.TxtORegNo.MaxLength = 8
    Me.TxtORegNo.Name = "TxtORegNo"
    Me.TxtORegNo.Size = New System.Drawing.Size(72, 20)
    Me.TxtORegNo.TabIndex = 234
    '
    'TxtOVIN
    '
    Me.TxtOVIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOVIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOVIN.Location = New System.Drawing.Point(208, 20)
    Me.TxtOVIN.MaxLength = 17
    Me.TxtOVIN.Name = "TxtOVIN"
    Me.TxtOVIN.Size = New System.Drawing.Size(120, 20)
    Me.TxtOVIN.TabIndex = 233
    '
    'TxtOClass
    '
    Me.TxtOClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOClass.Location = New System.Drawing.Point(176, 20)
    Me.TxtOClass.MaxLength = 2
    Me.TxtOClass.Name = "TxtOClass"
    Me.TxtOClass.Size = New System.Drawing.Size(28, 20)
    Me.TxtOClass.TabIndex = 232
    '
    'TxtOYear
    '
    Me.TxtOYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOYear.Location = New System.Drawing.Point(136, 20)
    Me.TxtOYear.MaxLength = 4
    Me.TxtOYear.Name = "TxtOYear"
    Me.TxtOYear.Size = New System.Drawing.Size(40, 20)
    Me.TxtOYear.TabIndex = 231
    '
    'TxtOModel
    '
    Me.TxtOModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOModel.Location = New System.Drawing.Point(64, 20)
    Me.TxtOModel.MaxLength = 8
    Me.TxtOModel.Name = "TxtOModel"
    Me.TxtOModel.Size = New System.Drawing.Size(68, 20)
    Me.TxtOModel.TabIndex = 230
    '
    'TxtOValue
    '
    Me.TxtOValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOValue.Location = New System.Drawing.Point(400, 20)
    Me.TxtOValue.MaxLength = 9
    Me.TxtOValue.Name = "TxtOValue"
    Me.TxtOValue.Size = New System.Drawing.Size(64, 20)
    Me.TxtOValue.TabIndex = 235
    '
    'TxtOMake
    '
    Me.TxtOMake.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOMake.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOMake.Location = New System.Drawing.Point(16, 20)
    Me.TxtOMake.MaxLength = 5
    Me.TxtOMake.Name = "TxtOMake"
    Me.TxtOMake.Size = New System.Drawing.Size(52, 20)
    Me.TxtOMake.TabIndex = 229
    '
    'LnkAsmt
    '
    Me.LnkAsmt.Location = New System.Drawing.Point(472, 8)
    Me.LnkAsmt.Name = "LnkAsmt"
    Me.LnkAsmt.Size = New System.Drawing.Size(32, 16)
    Me.LnkAsmt.TabIndex = 227
    Me.LnkAsmt.TabStop = True
    Me.LnkAsmt.Text = "Asmt"
    '
    'TxtAss
    '
    Me.TxtAss.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAss.Location = New System.Drawing.Point(480, 32)
    Me.TxtAss.MaxLength = 2
    Me.TxtAss.Name = "TxtAss"
    Me.TxtAss.Size = New System.Drawing.Size(16, 20)
    Me.TxtAss.TabIndex = 225
    '
    'Label29
    '
    Me.Label29.Location = New System.Drawing.Point(336, 8)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(44, 16)
    Me.Label29.TabIndex = 217
    Me.Label29.Text = "Reg #"
    '
    'TxtRegno
    '
    Me.TxtRegno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRegno.Location = New System.Drawing.Point(336, 32)
    Me.TxtRegno.MaxLength = 8
    Me.TxtRegno.Name = "TxtRegno"
    Me.TxtRegno.Size = New System.Drawing.Size(72, 20)
    Me.TxtRegno.TabIndex = 201
    '
    'Label36
    '
    Me.Label36.Location = New System.Drawing.Point(216, 8)
    Me.Label36.Name = "Label36"
    Me.Label36.Size = New System.Drawing.Size(44, 16)
    Me.Label36.TabIndex = 216
    Me.Label36.Text = "VIN #"
    '
    'TxtVIN
    '
    Me.TxtVIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVIN.Location = New System.Drawing.Point(216, 32)
    Me.TxtVIN.MaxLength = 17
    Me.TxtVIN.Name = "TxtVIN"
    Me.TxtVIN.Size = New System.Drawing.Size(120, 20)
    Me.TxtVIN.TabIndex = 200
    '
    'Label37
    '
    Me.Label37.Location = New System.Drawing.Point(184, 8)
    Me.Label37.Name = "Label37"
    Me.Label37.Size = New System.Drawing.Size(44, 16)
    Me.Label37.TabIndex = 215
    Me.Label37.Text = "Class"
    '
    'TxtClass
    '
    Me.TxtClass.Location = New System.Drawing.Point(184, 32)
    Me.TxtClass.MaxLength = 2
    Me.TxtClass.Name = "TxtClass"
    Me.TxtClass.Size = New System.Drawing.Size(28, 20)
    Me.TxtClass.TabIndex = 199
    '
    'Label38
    '
    Me.Label38.Location = New System.Drawing.Point(144, 8)
    Me.Label38.Name = "Label38"
    Me.Label38.Size = New System.Drawing.Size(36, 16)
    Me.Label38.TabIndex = 214
    Me.Label38.Text = "Year"
    '
    'TxtYear
    '
    Me.TxtYear.Location = New System.Drawing.Point(144, 32)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(40, 20)
    Me.TxtYear.TabIndex = 198
    '
    'Label40
    '
    Me.Label40.Location = New System.Drawing.Point(72, 8)
    Me.Label40.Name = "Label40"
    Me.Label40.Size = New System.Drawing.Size(44, 16)
    Me.Label40.TabIndex = 212
    Me.Label40.Text = "Model"
    '
    'TxtModel
    '
    Me.TxtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtModel.Location = New System.Drawing.Point(72, 32)
    Me.TxtModel.MaxLength = 8
    Me.TxtModel.Name = "TxtModel"
    Me.TxtModel.Size = New System.Drawing.Size(68, 20)
    Me.TxtModel.TabIndex = 196
    '
    'Label41
    '
    Me.Label41.Location = New System.Drawing.Point(408, 8)
    Me.Label41.Name = "Label41"
    Me.Label41.Size = New System.Drawing.Size(44, 16)
    Me.Label41.TabIndex = 211
    Me.Label41.Text = "Value"
    '
    'TxtValue
    '
    Me.TxtValue.Location = New System.Drawing.Point(408, 32)
    Me.TxtValue.MaxLength = 9
    Me.TxtValue.Name = "TxtValue"
    Me.TxtValue.Size = New System.Drawing.Size(64, 20)
    Me.TxtValue.TabIndex = 202
    '
    'Label42
    '
    Me.Label42.Location = New System.Drawing.Point(24, 8)
    Me.Label42.Name = "Label42"
    Me.Label42.Size = New System.Drawing.Size(44, 16)
    Me.Label42.TabIndex = 210
    Me.Label42.Text = "Make"
    '
    'TxtMake
    '
    Me.TxtMake.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMake.Location = New System.Drawing.Point(24, 32)
    Me.TxtMake.MaxLength = 5
    Me.TxtMake.Name = "TxtMake"
    Me.TxtMake.Size = New System.Drawing.Size(52, 20)
    Me.TxtMake.TabIndex = 195
    '
    'TabPgUB
    '
    Me.TabPgUB.Controls.Add(Me.TxtBondPaid)
    Me.TabPgUB.Controls.Add(Me.TxtBond)
    Me.TabPgUB.Controls.Add(Me.Label22)
    Me.TabPgUB.Controls.Add(Me.Label23)
    Me.TabPgUB.Location = New System.Drawing.Point(4, 22)
    Me.TabPgUB.Name = "TabPgUB"
    Me.TabPgUB.Size = New System.Drawing.Size(520, 142)
    Me.TabPgUB.TabIndex = 5
    Me.TabPgUB.Text = "UB"
    Me.TabPgUB.UseVisualStyleBackColor = True
    '
    'TxtBondPaid
    '
    Me.TxtBondPaid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBondPaid.Location = New System.Drawing.Point(88, 32)
    Me.TxtBondPaid.MaxLength = 12
    Me.TxtBondPaid.Name = "TxtBondPaid"
    Me.TxtBondPaid.Size = New System.Drawing.Size(64, 20)
    Me.TxtBondPaid.TabIndex = 6
    '
    'TxtBond
    '
    Me.TxtBond.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBond.Location = New System.Drawing.Point(88, 8)
    Me.TxtBond.MaxLength = 12
    Me.TxtBond.Name = "TxtBond"
    Me.TxtBond.Size = New System.Drawing.Size(64, 20)
    Me.TxtBond.TabIndex = 5
    '
    'Label22
    '
    Me.Label22.BackColor = System.Drawing.SystemColors.Control
    Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label22.Location = New System.Drawing.Point(8, 32)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(72, 16)
    Me.Label22.TabIndex = 7
    Me.Label22.Text = "Bond Paid"
    '
    'Label23
    '
    Me.Label23.BackColor = System.Drawing.SystemColors.Control
    Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label23.Location = New System.Drawing.Point(8, 8)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(72, 16)
    Me.Label23.TabIndex = 4
    Me.Label23.Text = "Bond Interest"
    '
    'GroupBox3
    '
    Me.GroupBox3.BackColor = System.Drawing.SystemColors.Control
    Me.GroupBox3.Controls.Add(Me.LblNet)
    Me.GroupBox3.Controls.Add(Me.LblExempt)
    Me.GroupBox3.Controls.Add(Me.LblGross)
    Me.GroupBox3.Controls.Add(Me.Label11)
    Me.GroupBox3.Controls.Add(Me.Label15)
    Me.GroupBox3.Controls.Add(Me.Label16)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.ForeColor = System.Drawing.Color.Black
    Me.GroupBox3.Location = New System.Drawing.Point(734, 344)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(144, 88)
    Me.GroupBox3.TabIndex = 217
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Property Values"
    '
    'LblNet
    '
    Me.LblNet.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNet.Location = New System.Drawing.Point(72, 64)
    Me.LblNet.Name = "LblNet"
    Me.LblNet.Size = New System.Drawing.Size(64, 16)
    Me.LblNet.TabIndex = 24
    Me.LblNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExempt
    '
    Me.LblExempt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExempt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExempt.Location = New System.Drawing.Point(72, 40)
    Me.LblExempt.Name = "LblExempt"
    Me.LblExempt.Size = New System.Drawing.Size(64, 16)
    Me.LblExempt.TabIndex = 23
    Me.LblExempt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblGross
    '
    Me.LblGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblGross.Location = New System.Drawing.Point(72, 16)
    Me.LblGross.Name = "LblGross"
    Me.LblGross.Size = New System.Drawing.Size(64, 16)
    Me.LblGross.TabIndex = 22
    Me.LblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label11
    '
    Me.Label11.BackColor = System.Drawing.SystemColors.Control
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.Location = New System.Drawing.Point(8, 64)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(48, 16)
    Me.Label11.TabIndex = 5
    Me.Label11.Text = "Net"
    '
    'Label15
    '
    Me.Label15.BackColor = System.Drawing.SystemColors.Control
    Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label15.Location = New System.Drawing.Point(8, 40)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(48, 16)
    Me.Label15.TabIndex = 3
    Me.Label15.Text = "Exempt"
    '
    'Label16
    '
    Me.Label16.BackColor = System.Drawing.SystemColors.Control
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.Location = New System.Drawing.Point(8, 20)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(48, 16)
    Me.Label16.TabIndex = 0
    Me.Label16.Text = "Gross"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbDeferExpire)
    Me.GroupBox1.Controls.Add(Me.RbDefer)
    Me.GroupBox1.Controls.Add(Me.RbForeclosure)
    Me.GroupBox1.Controls.Add(Me.RbNA)
    Me.GroupBox1.Controls.Add(Me.RbSuspense)
    Me.GroupBox1.Controls.Add(Me.RbInactive)
    Me.GroupBox1.Controls.Add(Me.RbBackTax)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(432, 8)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(104, 136)
    Me.GroupBox1.TabIndex = 218
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Record Code"
    '
    'RbDeferExpire
    '
    Me.RbDeferExpire.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbDeferExpire.Location = New System.Drawing.Point(8, 113)
    Me.RbDeferExpire.Name = "RbDeferExpire"
    Me.RbDeferExpire.Size = New System.Drawing.Size(85, 20)
    Me.RbDeferExpire.TabIndex = 6
    Me.RbDeferExpire.Text = "Defer Expire"
    '
    'RbDefer
    '
    Me.RbDefer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbDefer.Location = New System.Drawing.Point(8, 96)
    Me.RbDefer.Name = "RbDefer"
    Me.RbDefer.Size = New System.Drawing.Size(85, 20)
    Me.RbDefer.TabIndex = 5
    Me.RbDefer.Text = "Deferred"
    '
    'RbForeclosure
    '
    Me.RbForeclosure.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbForeclosure.Location = New System.Drawing.Point(8, 80)
    Me.RbForeclosure.Name = "RbForeclosure"
    Me.RbForeclosure.Size = New System.Drawing.Size(85, 20)
    Me.RbForeclosure.TabIndex = 4
    Me.RbForeclosure.Text = "Foreclosure"
    '
    'RbNA
    '
    Me.RbNA.Checked = True
    Me.RbNA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbNA.Location = New System.Drawing.Point(8, 16)
    Me.RbNA.Name = "RbNA"
    Me.RbNA.Size = New System.Drawing.Size(72, 16)
    Me.RbNA.TabIndex = 4
    Me.RbNA.TabStop = True
    Me.RbNA.Text = "N/A"
    '
    'RbSuspense
    '
    Me.RbSuspense.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSuspense.Location = New System.Drawing.Point(8, 64)
    Me.RbSuspense.Name = "RbSuspense"
    Me.RbSuspense.Size = New System.Drawing.Size(80, 16)
    Me.RbSuspense.TabIndex = 3
    Me.RbSuspense.Text = "Suspense"
    '
    'RbInactive
    '
    Me.RbInactive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbInactive.Location = New System.Drawing.Point(8, 48)
    Me.RbInactive.Name = "RbInactive"
    Me.RbInactive.Size = New System.Drawing.Size(72, 16)
    Me.RbInactive.TabIndex = 1
    Me.RbInactive.Text = "Inactive"
    '
    'RbBackTax
    '
    Me.RbBackTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbBackTax.Location = New System.Drawing.Point(8, 32)
    Me.RbBackTax.Name = "RbBackTax"
    Me.RbBackTax.Size = New System.Drawing.Size(72, 16)
    Me.RbBackTax.TabIndex = 0
    Me.RbBackTax.Text = "Back Tax"
    '
    'TxtStatus
    '
    Me.TxtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtStatus.Location = New System.Drawing.Point(104, 264)
    Me.TxtStatus.MaxLength = 5
    Me.TxtStatus.Name = "TxtStatus"
    Me.TxtStatus.Size = New System.Drawing.Size(56, 20)
    Me.TxtStatus.TabIndex = 16
    '
    'LnkStatus
    '
    Me.LnkStatus.Location = New System.Drawing.Point(20, 268)
    Me.LnkStatus.Name = "LnkStatus"
    Me.LnkStatus.Size = New System.Drawing.Size(78, 16)
    Me.LnkStatus.TabIndex = 220
    Me.LnkStatus.TabStop = True
    Me.LnkStatus.Text = "Status Codes"
    '
    'TxtSSNo
    '
    Me.TxtSSNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSSNo.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSSNo.Location = New System.Drawing.Point(104, 216)
    Me.TxtSSNo.MaxLength = 9
    Me.TxtSSNo.Name = "TxtSSNo"
    Me.TxtSSNo.Size = New System.Drawing.Size(76, 21)
    Me.TxtSSNo.TabIndex = 13
    Me.TxtSSNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtSS2
    '
    Me.TxtSS2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSS2.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSS2.Location = New System.Drawing.Point(296, 216)
    Me.TxtSS2.MaxLength = 9
    Me.TxtSS2.Name = "TxtSS2"
    Me.TxtSS2.Size = New System.Drawing.Size(82, 21)
    Me.TxtSS2.TabIndex = 14
    Me.TxtSS2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LnkSSno
    '
    Me.LnkSSno.AutoSize = True
    Me.LnkSSno.Location = New System.Drawing.Point(20, 220)
    Me.LnkSSno.Name = "LnkSSno"
    Me.LnkSSno.Size = New System.Drawing.Size(76, 13)
    Me.LnkSSno.TabIndex = 221
    Me.LnkSSno.TabStop = True
    Me.LnkSSno.Text = "Primary CustID"
    '
    'LnkSS2
    '
    Me.LnkSS2.AutoSize = True
    Me.LnkSS2.Location = New System.Drawing.Point(196, 220)
    Me.LnkSS2.Name = "LnkSS2"
    Me.LnkSS2.Size = New System.Drawing.Size(93, 13)
    Me.LnkSS2.TabIndex = 222
    Me.LnkSS2.TabStop = True
    Me.LnkSS2.Text = "Secondary CustID"
    '
    'LblDOB
    '
    Me.LblDOB.AutoSize = True
    Me.LblDOB.Location = New System.Drawing.Point(196, 268)
    Me.LblDOB.Name = "LblDOB"
    Me.LblDOB.Size = New System.Drawing.Size(66, 13)
    Me.LblDOB.TabIndex = 224
    Me.LblDOB.Text = "Date of Birth"
    '
    'DtPckDOB
    '
    Me.DtPckDOB.Checked = False
    Me.DtPckDOB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckDOB.Location = New System.Drawing.Point(268, 264)
    Me.DtPckDOB.Name = "DtPckDOB"
    Me.DtPckDOB.ShowCheckBox = True
    Me.DtPckDOB.Size = New System.Drawing.Size(96, 20)
    Me.DtPckDOB.TabIndex = 17
    '
    'LnkOID
    '
    Me.LnkOID.AutoSize = True
    Me.LnkOID.Location = New System.Drawing.Point(22, 244)
    Me.LnkOID.Name = "LnkOID"
    Me.LnkOID.Size = New System.Drawing.Size(56, 13)
    Me.LnkOID.TabIndex = 225
    Me.LnkOID.TabStop = True
    Me.LnkOID.Text = "Vehicle ID"
    '
    'TxtOID
    '
    Me.TxtOID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOID.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOID.Location = New System.Drawing.Point(104, 240)
    Me.TxtOID.MaxLength = 9
    Me.TxtOID.Name = "TxtOID"
    Me.TxtOID.Size = New System.Drawing.Size(76, 21)
    Me.TxtOID.TabIndex = 15
    Me.TxtOID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'GrpDefer
    '
    Me.GrpDefer.BackColor = System.Drawing.SystemColors.Control
    Me.GrpDefer.Controls.Add(Me.LblDeferT)
    Me.GrpDefer.Controls.Add(Me.TxtDefer4)
    Me.GrpDefer.Controls.Add(Me.TxtDefer3)
    Me.GrpDefer.Controls.Add(Me.TxtDefer2)
    Me.GrpDefer.Controls.Add(Me.TxtDefer1)
    Me.GrpDefer.Controls.Add(Me.Label20)
    Me.GrpDefer.Controls.Add(Me.Label39)
    Me.GrpDefer.Controls.Add(Me.Label45)
    Me.GrpDefer.Controls.Add(Me.Label48)
    Me.GrpDefer.Controls.Add(Me.Label49)
    Me.GrpDefer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpDefer.Location = New System.Drawing.Point(734, 8)
    Me.GrpDefer.Name = "GrpDefer"
    Me.GrpDefer.Size = New System.Drawing.Size(182, 136)
    Me.GrpDefer.TabIndex = 226
    Me.GrpDefer.TabStop = False
    Me.GrpDefer.Text = "Deferral"
    '
    'LblDeferT
    '
    Me.LblDeferT.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblDeferT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblDeferT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDeferT.Location = New System.Drawing.Point(72, 16)
    Me.LblDeferT.Name = "LblDeferT"
    Me.LblDeferT.Size = New System.Drawing.Size(88, 16)
    Me.LblDeferT.TabIndex = 128
    Me.LblDeferT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtDefer4
    '
    Me.TxtDefer4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDefer4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDefer4.Location = New System.Drawing.Point(72, 112)
    Me.TxtDefer4.MaxLength = 9
    Me.TxtDefer4.Name = "TxtDefer4"
    Me.TxtDefer4.Size = New System.Drawing.Size(88, 20)
    Me.TxtDefer4.TabIndex = 14
    Me.TxtDefer4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtDefer3
    '
    Me.TxtDefer3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDefer3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDefer3.Location = New System.Drawing.Point(72, 88)
    Me.TxtDefer3.MaxLength = 9
    Me.TxtDefer3.Name = "TxtDefer3"
    Me.TxtDefer3.Size = New System.Drawing.Size(88, 20)
    Me.TxtDefer3.TabIndex = 13
    Me.TxtDefer3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtDefer2
    '
    Me.TxtDefer2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDefer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDefer2.Location = New System.Drawing.Point(72, 64)
    Me.TxtDefer2.MaxLength = 9
    Me.TxtDefer2.Name = "TxtDefer2"
    Me.TxtDefer2.Size = New System.Drawing.Size(88, 20)
    Me.TxtDefer2.TabIndex = 12
    Me.TxtDefer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtDefer1
    '
    Me.TxtDefer1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDefer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDefer1.Location = New System.Drawing.Point(72, 40)
    Me.TxtDefer1.MaxLength = 9
    Me.TxtDefer1.Name = "TxtDefer1"
    Me.TxtDefer1.Size = New System.Drawing.Size(88, 20)
    Me.TxtDefer1.TabIndex = 11
    Me.TxtDefer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label20
    '
    Me.Label20.BackColor = System.Drawing.SystemColors.Control
    Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label20.Location = New System.Drawing.Point(8, 112)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(48, 16)
    Me.Label20.TabIndex = 9
    Me.Label20.Text = "4th "
    '
    'Label39
    '
    Me.Label39.BackColor = System.Drawing.SystemColors.Control
    Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label39.Location = New System.Drawing.Point(8, 88)
    Me.Label39.Name = "Label39"
    Me.Label39.Size = New System.Drawing.Size(48, 16)
    Me.Label39.TabIndex = 7
    Me.Label39.Text = "3rd "
    '
    'Label45
    '
    Me.Label45.BackColor = System.Drawing.SystemColors.Control
    Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label45.Location = New System.Drawing.Point(8, 64)
    Me.Label45.Name = "Label45"
    Me.Label45.Size = New System.Drawing.Size(48, 16)
    Me.Label45.TabIndex = 5
    Me.Label45.Text = "2nd "
    '
    'Label48
    '
    Me.Label48.BackColor = System.Drawing.SystemColors.Control
    Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label48.Location = New System.Drawing.Point(8, 40)
    Me.Label48.Name = "Label48"
    Me.Label48.Size = New System.Drawing.Size(56, 16)
    Me.Label48.TabIndex = 3
    Me.Label48.Text = "1st "
    '
    'Label49
    '
    Me.Label49.BackColor = System.Drawing.SystemColors.Control
    Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label49.Location = New System.Drawing.Point(8, 16)
    Me.Label49.Name = "Label49"
    Me.Label49.Size = New System.Drawing.Size(60, 16)
    Me.Label49.TabIndex = 0
    Me.Label49.Text = "Total"
    '
    'GroupBox2
    '
    Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
    Me.GroupBox2.Controls.Add(Me.LblPrinDue)
    Me.GroupBox2.Controls.Add(Me.Label54)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.ForeColor = System.Drawing.Color.Black
    Me.GroupBox2.Location = New System.Drawing.Point(734, 152)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(182, 48)
    Me.GroupBox2.TabIndex = 227
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Calculated Amount"
    '
    'LblPrinDue
    '
    Me.LblPrinDue.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPrinDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPrinDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPrinDue.Location = New System.Drawing.Point(84, 20)
    Me.LblPrinDue.Name = "LblPrinDue"
    Me.LblPrinDue.Size = New System.Drawing.Size(64, 16)
    Me.LblPrinDue.TabIndex = 22
    Me.LblPrinDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label54
    '
    Me.Label54.AutoSize = True
    Me.Label54.BackColor = System.Drawing.SystemColors.Control
    Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label54.Location = New System.Drawing.Point(8, 20)
    Me.Label54.Name = "Label54"
    Me.Label54.Size = New System.Drawing.Size(70, 13)
    Me.Label54.TabIndex = 0
    Me.Label54.Text = "Principal Due"
    '
    'FrmTX405C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(928, 468)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GrpDefer)
    Me.Controls.Add(Me.TxtOID)
    Me.Controls.Add(Me.LnkOID)
    Me.Controls.Add(Me.LblDOB)
    Me.Controls.Add(Me.DtPckDOB)
    Me.Controls.Add(Me.LnkSS2)
    Me.Controls.Add(Me.LnkSSno)
    Me.Controls.Add(Me.TxtSS2)
    Me.Controls.Add(Me.LnkStatus)
    Me.Controls.Add(Me.TxtStatus)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.TabCtl1)
    Me.Controls.Add(Me.TxtPhase)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.TxtComment)
    Me.Controls.Add(Me.TxtSSNo)
    Me.Controls.Add(Me.TxtZip4)
    Me.Controls.Add(Me.TxtZip5)
    Me.Controls.Add(Me.TxtLoc)
    Me.Controls.Add(Me.TxtLocNo)
    Me.Controls.Add(Me.TxtCity)
    Me.Controls.Add(Me.TxtState)
    Me.Controls.Add(Me.TxtAdd2)
    Me.Controls.Add(Me.TxtAdd1)
    Me.Controls.Add(Me.TxtSname)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.ChkLien)
    Me.Controls.Add(Me.LblStatus)
    Me.Controls.Add(Me.Label17)
    Me.Controls.Add(Me.Label44)
    Me.Controls.Add(Me.Label43)
    Me.Controls.Add(Me.GrpCC)
    Me.Controls.Add(Me.GroupBox6)
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.LblListNo)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Label5)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX405C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Maintainence"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpCC.ResumeLayout(False)
    Me.GroupBox6.ResumeLayout(False)
    Me.GroupBox6.PerformLayout()
    Me.GroupBox4.ResumeLayout(False)
    Me.TabCtl1.ResumeLayout(False)
    Me.TabPgAssmnt.ResumeLayout(False)
    Me.TabPgAssmnt.PerformLayout()
    Me.TabPgExempt.ResumeLayout(False)
    Me.TabPgExempt.PerformLayout()
    Me.TabPgBank.ResumeLayout(False)
    Me.TabPgBank.PerformLayout()
    Me.TabPgEld.ResumeLayout(False)
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
    Me.TabPgMV.ResumeLayout(False)
    Me.TabPgMV.PerformLayout()
    Me.GrpCredit.ResumeLayout(False)
    Me.GrpCredit.PerformLayout()
    Me.TabPgUB.ResumeLayout(False)
    Me.TabPgUB.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.GrpDefer.ResumeLayout(False)
    Me.GrpDefer.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTX405C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXPROF = New TXPROF.MyData(myDBConnect)
    myTXSTS = New TXSTS.MyData(myDBConnect)
    myTXVCUS = New TXVCUS.MyData(myDBConnect)

    LoadScrn = True
    MyFrmTX405.TBarNew.Enabled = False
    MyFrmTX405.TBarSave.Enabled = True
    MyFrmTX405.TBarAttach.Enabled = True
    WrkAcct = ProcessSelItems()
    LoadForm(WrkAcct)
  End Sub
  Private Sub LoadForm(ByVal WrkAcct As String)
    Dim WrkAttachCount As Integer
    Dim WrkSuspDesc As String
    Dim WrkICode As String
    Dim WrkFrozenCode As String

    WrkListNo = Mid(WrkAcct, 6, 7)
    WrkType = Mid(WrkAcct, 5, 1)
    WrkYear = Mid(WrkAcct, 1, 4)
    WrkFamily = GetTXTypeFamily(WrkType)
    Me.Text = GetTXTypeDesc(WrkType)
    LblListNo.Text = WrkListNo
    LblYear.Text = WrkYear
    WrkAttachCount = GetAttachcount(WrkAcct)
    MyFrmTX405.TBarAttach.Text = WrkAttachCount & " Attachment(s)"

    GetTxProf()
    LnkCode8.Visible = False
    TxtCode8.Visible = False
    TxtUnit8.Visible = False
    TxtAssmt8.Visible = False
    LnkCode9.Visible = False
    TxtCode9.Visible = False
    TxtUnit9.Visible = False
    TxtAssmt9.Visible = False
    LnkCode10.Visible = False
    TxtCode10.Visible = False
    TxtUnit10.Visible = False
    TxtAssmt10.Visible = False
    LnkExempt6.Visible = False
    TxtExempt6.Visible = False
    TxtExam6.Visible = False
    LnkExempt7.Visible = False
    TxtExempt7.Visible = False
    TxtExam7.Visible = False
    GrpCredit.Visible = False
    LblDOB.Visible = False
    DtPckDOB.Visible = False
    Select Case WrkFamily
      Case "A"
        TabCtl1.TabPages.Remove(TabPgAssmnt)
        TabCtl1.TabPages.Remove(TabPgExempt)
        TabCtl1.TabPages.Remove(TabPgEld)
        TabCtl1.TabPages.Remove(TabPgMV)
        TabCtl1.SelectedTab = TabPgUB
      Case "R"
        TabCtl1.TabPages.Remove(TabPgMV)
        TabCtl1.TabPages.Remove(TabPgUB)
        TabCtl1.SelectedTab = TabPgAssmnt
        LnkExempt6.Visible = True
        TxtExempt6.Visible = True
        TxtExam6.Visible = True
        LnkExempt7.Visible = True
        TxtExempt7.Visible = True
        TxtExam7.Visible = True
      Case "P"
        TabCtl1.TabPages.Remove(TabPgEld)
        TabCtl1.TabPages.Remove(TabPgMV)
        TabCtl1.TabPages.Remove(TabPgUB)
        TabCtl1.SelectedTab = TabPgAssmnt
        LnkCode8.Visible = True
        TxtCode8.Visible = True
        TxtUnit8.Visible = True
        TxtAssmt8.Visible = True
        LnkCode9.Visible = True
        TxtCode9.Visible = True
        TxtUnit9.Visible = True
        TxtAssmt9.Visible = True
        LnkCode10.Visible = True
        TxtCode10.Visible = True
        TxtUnit10.Visible = True
        TxtAssmt10.Visible = True
      Case "M"
        LblDOB.Visible = True
        DtPckDOB.Visible = True
        TabCtl1.TabPages.Remove(TabPgEld)
        TabCtl1.TabPages.Remove(TabPgAssmnt)
        TabCtl1.TabPages.Remove(TabPgUB)
        TabCtl1.SelectedTab = TabPgExempt
      Case "S"
        LblDOB.Visible = True
        DtPckDOB.Visible = True
        TabCtl1.TabPages.Remove(TabPgEld)
        TabCtl1.TabPages.Remove(TabPgAssmnt)
        TabCtl1.TabPages.Remove(TabPgUB)
        TabCtl1.SelectedTab = TabPgExempt
        GrpCredit.Visible = True
      Case "U"
        TabCtl1.TabPages.Remove(TabPgAssmnt)
        TabCtl1.TabPages.Remove(TabPgExempt)
        TabCtl1.TabPages.Remove(TabPgEld)
        TabCtl1.TabPages.Remove(TabPgMV)
        TabCtl1.TabPages.Remove(TabPgUB)
      Case Else
    End Select

    'New record
    If AddMode Then
      Me.Text = "Add " & Me.Text
      RbEldNA.Checked = True
      LockElderly(True)
      LoadScrn = False
      Me.ActiveControl = TxtName
      Exit Sub
    End If

    MyUtils.SetTxtReadOnly(TxtMap)
    MyUtils.SetTxtReadOnly(TxtVol)
    MyUtils.SetTxtReadOnly(TxtPage)
    MyUtils.SetTxtReadOnly(TxtTax1)
    MyUtils.SetTxtReadOnly(TxtTax2)
    MyUtils.SetTxtReadOnly(TxtTax3)
    MyUtils.SetTxtReadOnly(TxtTax4)
    MyUtils.SetTxtReadOnly(TxtCode1)
    MyUtils.SetTxtReadOnly(TxtCode2)
    MyUtils.SetTxtReadOnly(TxtCode3)
    MyUtils.SetTxtReadOnly(TxtCode4)
    MyUtils.SetTxtReadOnly(TxtCode5)
    MyUtils.SetTxtReadOnly(TxtCode6)
    MyUtils.SetTxtReadOnly(TxtCode7)
    MyUtils.SetTxtReadOnly(TxtCode8)
    MyUtils.SetTxtReadOnly(TxtCode9)
    MyUtils.SetTxtReadOnly(TxtCode10)
    MyUtils.SetTxtReadOnly(TxtUnit1)
    MyUtils.SetTxtReadOnly(TxtUnit2)
    MyUtils.SetTxtReadOnly(TxtUnit3)
    MyUtils.SetTxtReadOnly(TxtUnit4)
    MyUtils.SetTxtReadOnly(TxtUnit5)
    MyUtils.SetTxtReadOnly(TxtUnit6)
    MyUtils.SetTxtReadOnly(TxtUnit7)
    MyUtils.SetTxtReadOnly(TxtUnit8)
    MyUtils.SetTxtReadOnly(TxtUnit9)
    MyUtils.SetTxtReadOnly(TxtUnit10)
    MyUtils.SetTxtReadOnly(TxtAssmt1)
    MyUtils.SetTxtReadOnly(TxtAssmt2)
    MyUtils.SetTxtReadOnly(TxtAssmt3)
    MyUtils.SetTxtReadOnly(TxtAssmt4)
    MyUtils.SetTxtReadOnly(TxtAssmt5)
    MyUtils.SetTxtReadOnly(TxtAssmt6)
    MyUtils.SetTxtReadOnly(TxtAssmt7)
    MyUtils.SetTxtReadOnly(TxtAssmt8)
    MyUtils.SetTxtReadOnly(TxtAssmt9)
    MyUtils.SetTxtReadOnly(TxtAssmt10)
    MyUtils.SetTxtReadOnly(TxtExempt1)
    MyUtils.SetTxtReadOnly(TxtExempt2)
    MyUtils.SetTxtReadOnly(TxtExempt3)
    MyUtils.SetTxtReadOnly(TxtExempt4)
    MyUtils.SetTxtReadOnly(TxtExempt5)
    MyUtils.SetTxtReadOnly(TxtExempt6)
    MyUtils.SetTxtReadOnly(TxtExempt7)
    MyUtils.SetTxtReadOnly(TxtExam1)
    MyUtils.SetTxtReadOnly(TxtExam2)
    MyUtils.SetTxtReadOnly(TxtExam3)
    MyUtils.SetTxtReadOnly(TxtExam4)
    MyUtils.SetTxtReadOnly(TxtExam5)
    MyUtils.SetTxtReadOnly(TxtExam6)
    MyUtils.SetTxtReadOnly(TxtExam7)

    'RE
    RbEldNA.Enabled = False
    RbEldHeart.Enabled = False
    RbEldFrozen.Enabled = False
    MyUtils.SetTxtReadOnly(TxtEldYear)
    MyUtils.SetTxtReadOnly(TxtEldPerc)
    MyUtils.SetTxtReadOnly(TxtEldMin)
    MyUtils.SetTxtReadOnly(TxtEldMax)
    MyUtils.SetTxtReadOnly(TxtEldTax)
    MyUtils.SetTxtReadOnly(TxtEldAdj)

    'MV 
    MyUtils.SetTxtReadOnly(TxtMake)
    MyUtils.SetTxtReadOnly(TxtModel)
    MyUtils.SetTxtReadOnly(TxtYear)
    MyUtils.SetTxtReadOnly(TxtVIN)
    MyUtils.SetTxtReadOnly(TxtRegno)
    MyUtils.SetTxtReadOnly(TxtValue)
    MyUtils.SetTxtReadOnly(TxtAss)
    MyUtils.SetTxtReadOnly(TxtOMake)
    MyUtils.SetTxtReadOnly(TxtOModel)
    MyUtils.SetTxtReadOnly(TxtOYear)
    MyUtils.SetTxtReadOnly(TxtOVIN)
    MyUtils.SetTxtReadOnly(TxtORegNo)
    MyUtils.SetTxtReadOnly(TxtOValue)
    MyUtils.SetTxtReadOnly(TxtOAss)

    If s_chg = False And s_full = False Then  '#sec
      MyFrmTX405.TBarSave.Visible = False  '#sec
    End If  '#sec

    'Fill the dataset with the data
    Me.Text = "Maintain " & Me.Text
    myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)

    If myTXINV.RecordNotFound Then
      MyFrmTX405.TBarNew.Enabled = False
      MyFrmTX405.TBarSave.Enabled = False
      Me.ErrProv.SetError(LblListNo, "Record not found")
      Exit Sub
    End If

    With myTXINV
      WrkICode = Trim(._ICODE)
      Select Case WrkICode
        Case "B"
          RbBackTax.Checked = True
          LblStatus.Text = "Back Tax Due"
        Case "D"
          RbDefer.Checked = True
          LblStatus.Text = "Deferred"
        'MK 9/30/25 Begin
        Case "E"
          RbDeferExpire.Checked = True
          LblStatus.Text = "Defer Expire"
        'MK 9/30/25 End
        Case "F"
          RbForeclosure.Checked = True
          LblStatus.Text = "Foreclosure"
        Case "I"
          RbInactive.Checked = True
          LblStatus.Text = "Inactive/Deleted"
        Case "S"
          RbSuspense.Checked = True
          WrkSuspDesc = GetTXSResnDesc(Trim(._SUSCD))
          WrkSuspDesc = Trim(._SUSCD) & "-" & WrkSuspDesc
          LblStatus.Text = "Suspense Item (" & WrkSuspDesc & ""
        Case Else
          RbNA.Checked = True
      End Select
      TxtDist.Text = ._DIST
      TxtPhase.Text = ._PHASE
      TxtName.Text = Trim(._NAME)
      TxtSname.Text = Trim(._SNAME)
      TxtAdd1.Text = Trim(._ADD1)
      TxtAdd2.Text = Trim(._ADD2)
      TxtCity.Text = Trim(._CITY)
      TxtState.Text = Trim(._STATE)
      TxtZip5.Text = Format(._ZIP5, "00000")
      TxtZip4.Text = Format(._ZIP4, "0000")
      TxtLocNo.Text = Trim(._LOCNo)
      TxtLoc.Text = Trim(._LOC)
      TxtSSNo.Text = ._SSNo
      TxtSS2.Text = ._SS2
      TxtOID.Text = Trim(._OID)
      TxtComment.Text = Trim(._CCM)
      If Trim(._LIEN) = "L" Then
        ChkLien.Checked = True
      End If
      TxtMap.Text = Trim(._MAP)
      TxtVol.Text = Trim(._VOL)
      TxtPage.Text = Trim(._IPAGE)
      TxtCode1.Text = ._IPPCD1
      TxtCode2.Text = ._IPPCD2
      TxtCode3.Text = ._IPPCD3
      TxtCode4.Text = ._IPPCD4
      TxtCode5.Text = ._IPPCD5
      TxtCode6.Text = ._IPPCD6
      TxtCode7.Text = ._IPPCD7
      TxtCode8.Text = ._IPPCD8
      TxtCode9.Text = ._IPPCD9
      TxtCode10.Text = ._IPPCDA
      SetCode1Tip()
      SetCode2Tip()
      SetCode3Tip()
      SetCode4Tip()
      SetCode5Tip()
      SetCode6Tip()
      SetCode7Tip()
      SetCode8Tip()
      SetCode9Tip()
      SetCode10Tip()
      TxtUnit1.Text = ._UNIT1
      TxtAssmt1.Text = ._OAS1
      TxtUnit2.Text = ._UNIT2
      TxtAssmt2.Text = ._OAS2
      TxtUnit3.Text = ._UNIT3
      TxtAssmt3.Text = ._OAS3
      TxtUnit4.Text = ._UNIT4
      TxtAssmt4.Text = ._OAS4
      TxtUnit5.Text = ._UNIT5
      TxtAssmt5.Text = ._OAS5
      TxtUnit6.Text = ._UNIT6
      TxtAssmt6.Text = ._OAS6
      TxtUnit7.Text = ._UNIT7
      TxtAssmt7.Text = ._OAS7
      TxtUnit8.Text = ._UNIT8
      TxtAssmt8.Text = ._OAS8
      TxtUnit9.Text = ._UNIT9
      TxtAssmt9.Text = ._OAS9
      TxtUnit10.Text = ._UNITA
      TxtAssmt10.Text = ._OAS10
      'Exemption Codes
      TxtExempt1.Text = Trim(._EXCD1)
      TxtExempt2.Text = Trim(._EXCD2)
      TxtExempt3.Text = Trim(._EXCD3)
      TxtExempt4.Text = Trim(._EXCD4)
      TxtExempt5.Text = Trim(._EXCD5)
      TxtExempt6.Text = Trim(._EXCD6)
      TxtExempt7.Text = Trim(._EXCD7)
      TxtExam1.Text = ._EXAM1
      TxtExam2.Text = ._EXAM2
      TxtExam3.Text = ._EXAM3
      TxtExam4.Text = ._EXAM4
      TxtExam5.Text = ._EXAM5
      TxtExam6.Text = ._EXAM6
      TxtExam7.Text = ._EXAM7
      SetExem1Tip()
      SetExem2Tip()
      SetExem3Tip()
      SetExem4Tip()
      SetExem5Tip()
      SetExem6Tip()
      SetExem7Tip()
      LblGross.Text = ._GROSS
      LblExempt.Text = ._TOTEXP
      LblNet.Text = ._NETASS
      TxtStatus.Text = Trim(._STCD1) & Trim(._STCD2) & Trim(._STCD3) & Trim(._STCD4) & Trim(._STCD5)
      MySts = TxtStatus.Text
      'Elderly
      WrkFrozenCode = Trim(._FRCD)
      Select Case WrkFrozenCode
        Case Is = "F"
          RbEldFrozen.Checked = True
          LockElderly(False)
        Case Is = "C"
          RbEldHeart.Checked = True
          LockElderly(False)
        Case Else
          RbEldNA.Checked = True
          LockElderly(True)
      End Select
      TxtBankCd.Text = Trim(._BKCD)
      TxtBankServ.Text = Trim(._BKSR)
      TxtEldYear.Text = ._FRYR
      TxtEldPerc.Text = ._CPERC
      TxtEldMax.Text = ._CMAX
      TxtEldMin.Text = ._CMIN
      TxtEldTax.Text = ._FTAX
      TxtEldAdj.Text = ._CIRAD
      'MV
      TxtMake.Text = Trim(._MAKE)
      TxtModel.Text = Trim(._MODEL)
      TxtYear.Text = ._MVYR
      TxtClass.Text = ._CLASS
      TxtVIN.Text = Trim(._IMVIDNo)
      TxtRegno.Text = Trim(._IMVREG)
      TxtValue.Text = ._GROSS
      TxtAss.Text = Trim(._ASS)
      TxtOMake.Text = Trim(._ICVMKE)
      TxtOModel.Text = Trim(._ICVMOD)
      TxtOYear.Text = ._ICVYR
      TxtOClass.Text = ._ICVCLS
      TxtOVIN.Text = Trim(._ICVIDNo)
      TxtORegNo.Text = Trim(._ICVREG)
      TxtOValue.Text = ._ICVGRS
      TxtOAss.Text = Trim(._ICVACD)
      If ._DOB > 0 Then
        DtPckDOB.Value = MyUtils.GetDBDate(._DOB)
        DtPckDOB.Checked = True
      End If
      'UB
      TxtBond.Text = ._BOND
      TxtBondPaid.Text = ._BONDP

      LblTotpay.Text = Format(._PAYREC, "standard")
      LblPayDate.Text = ""
      If ._TXIDT > 0 Then
        LblPayDate.Text = MyUtils.GetDBDate(._TXIDT)
      End If
      LblTotpay.Text = Format(._PAYREC, "standard")
      LblTaxT.Text = Format(._TAXT, "standard")
      TxtTax1.Text = Format(._TAX1, "standard")
      TxtTax2.Text = Format(._TAX2, "standard")
      TxtTax3.Text = Format(._TX3RD, "standard")
      TxtTax4.Text = Format(._TX4TH, "standard")
      'MK 9/30/25 Begin
      'If RbDefer.Checked Then
      If RbDefer.Checked Or RbDeferExpire.Checked Then
        'MK 9/30/25 End
        GrpDefer.Visible = True
        LblDeferT.Text = Format(._DEFERT, "standard")
        TxtDefer1.Text = Format(._DEFER1, "standard")
        TxtDefer2.Text = Format(._DEFER2, "standard")
        TxtDefer3.Text = Format(._DEFER3, "standard")
        TxtDefer4.Text = Format(._DEFER4, "standard")
      Else
        GrpDefer.Visible = False
      End If
      'C/C Info
      GrpCC.Visible = True
      If ._CCNO = 0 Then
        GrpCC.Visible = False
      End If
      LblCCNo.Text = ""
      LblCCDate.Text = ""
      LblCCTaxt.Text = ""
      LblCCTax1.Text = ""
      LblCCTax2.Text = ""
      LblCCTax3.Text = ""
      LblCCTax4.Text = ""
      LblCCGross.Text = ""
      LblCCExempt.Text = ""
      If ._CCNO > 0 Then
        LblCCNo.Text = ._CCNO
        LblCCDate.Text = MyUtils.GetDBDate(._CDATE)
        LblCCTaxt.Text = Format(._CCETAX, "standard")
        LblCCTax1.Text = Format(._CCTX1, "standard")
        LblCCTax2.Text = Format(._CCTX2, "standard")
        LblCCTax3.Text = Format(._CCTX3, "standard")
        LblCCTax4.Text = Format(._CCTX4, "standard")
        LblCCGross.Text = Format(._CGRS, "###,###,###")
        LblCCExempt.Text = Format(._CCEXP, "###,###,###")
      End If
      LblGross.Text = Format(._GROSS, "###,###,###")
      LblExempt.Text = Format(._TOTEXP, "###,###,###")
      LblNet.Text = Format(._NETASS, "###,###,###")
    End With
    CalcPrinDue()

    LoadScrn = False
    Me.ActiveControl = TxtName
  End Sub
  'MK 9/30/25 Begin
  Private Sub CalcPrinDue()
    With myTXINV
      LblPrinDue.Text = Format(._TAXT - ._PAYREC, "standard")
      If RbDefer.Checked Then
        LblPrinDue.Text = Format(._TAXT - ._DEFERT - ._PAYREC, "standard")
      End If
      If ._CCNO > 0 Then
        LblPrinDue.Text = Format(._CCETAX - ._PAYREC, "standard")
        If RbDeferExpire.Checked Then
          LblPrinDue.Text = Format(._CCETAX + ._DEFERT - ._PAYREC, "standard")
        End If
      End If
    End With
  End Sub
  'MK 9/30/25 End
  Private Sub FrmTX405C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTX405.TBarNew.Enabled = True
    MyFrmTX405.TBarSave.Enabled = False
    MyFrmTX405.TBarSave.Visible = True   '#sec
    MyFrmTX405.TBarAttach.Enabled = False
    MyFrmTX405.TBarAttach.Text = "Attachments"
    MyFrmTX405B.FormatGrid(True, True)
    MyFrmTX405B.Show()
    MyFrmTX405C = Nothing

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    myTXINV.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String

    myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
    If AddMode Then
      If Not myTXINV.RecordNotFound Then
        Me.ErrProv.SetError(LblListNo, "Record already exists")
        Exit Sub
      End If
    End If

    If Not AddMode Then
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXINV.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXINV.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    Me.Close()

  End Sub
  Private Sub MoveToFile()
    Dim WrkFamily As String

    WrkFamily = GetTXTypeFamily(WrkType)
    With myTXINV
      If RbNA.Checked Then
        ._ICODE = ""
      End If
      If RbBackTax.Checked Then
        ._ICODE = "B"
      End If
      If RbDefer.Checked Then
        ._ICODE = "D"
      End If
      'MK 9/30/25 Begin
      If RbDeferExpire.Checked Then
        ._ICODE = "E"
      End If
      'MK 9/30/25 End
      If RbForeclosure.Checked Then
        ._ICODE = "F"
      End If
      If RbInactive.Checked Then
        ._ICODE = "I"
      End If
      If RbSuspense.Checked Then
        ._ICODE = "S"
      End If
      ._NAME = TxtName.Text
      ._SNAME = TxtSname.Text
      ._ADD1 = TxtAdd1.Text
      ._ADD2 = TxtAdd2.Text
      ._CITY = TxtCity.Text
      ._STATE = TxtState.Text
      ._ZIP5 = MyUtils.CnvSng(TxtZip5.Text)
      ._ZIP4 = MyUtils.CnvSng(TxtZip4.Text)
      ._LOCNo = MyUtils.JustifyRight(TxtLocNo.Text, 7)
      ._LOC = TxtLoc.Text
      ._DIST = MyUtils.CnvSng(TxtDist.Text)
      ._PHASE = MyUtils.CnvSng(TxtPhase.Text)
      If GrpDefer.Visible Then
        ._DEFERT = MyUtils.CnvSng(LblDeferT.Text)
        ._DEFER1 = MyUtils.CnvSng(TxtDefer1.Text)
        ._DEFER2 = MyUtils.CnvSng(TxtDefer2.Text)
        ._DEFER3 = MyUtils.CnvSng(TxtDefer3.Text)
        ._DEFER4 = MyUtils.CnvSng(TxtDefer4.Text)
      Else
        ._DEFERT = 0
        ._DEFER1 = 0
        ._DEFER2 = 0
        ._DEFER3 = 0
        ._DEFER4 = 0
      End If
      ._SSNo = MyUtils.CnvSng(TxtSSNo.Text)
      ._SS2 = MyUtils.CnvSng(TxtSS2.Text)
      ._OID = MyUtils.CnvSng(TxtOID.Text)
      ._CCM = TxtComment.Text
      ._LIEN = ""
      If ChkLien.Checked Then
        ._LIEN = "L"
      End If
      ._LETT = Mid$(TxtName.Text, 1, 1)
      ._PRF = Mid(MyUserID, 1, 10)
      ._CHDATE = MyUtils.SetDBDate(DateTime.Today)
      ._CHTIME = Format(DateTime.Now, "hhmmss")
      ._BKCD = TxtBankCd.Text
      ._BKSR = TxtBankServ.Text
      ._STCD1 = Mid(TxtStatus.Text, 1, 1)
      ._STCD2 = Mid(TxtStatus.Text, 2, 1)
      ._STCD3 = Mid(TxtStatus.Text, 3, 1)
      ._STCD4 = Mid(TxtStatus.Text, 4, 1)
      ._STCD5 = Mid(TxtStatus.Text, 5, 1)
      If DtPckDOB.Visible And DtPckDOB.Checked Then
        ._DOB = MyUtils.SetDBDate(DtPckDOB.Value)
      Else
        ._DOB = 0
      End If
      If TxtBond.Visible Then
        ._BOND = MyUtils.CnvSng(TxtBond.Text)
        ._BONDP = MyUtils.CnvSng(TxtBondPaid.Text)
      End If
      If AddMode Then
        ._LISTNo = WrkListNo
        ._TYPE = WrkType
        ._YEAR = WrkYear
        ._GROSS = MyUtils.CnvSng(LblGross.Text)
        ._TOTEXP = MyUtils.CnvSng(LblExempt.Text)
        ._NETASS = MyUtils.CnvSng(LblNet.Text)
        ._TAXT = MyUtils.CnvSng(LblTaxT.Text)
        ._TAX1 = MyUtils.CnvSng(TxtTax1.Text)
        ._TAX2 = MyUtils.CnvSng(TxtTax2.Text)
        ._TX3RD = MyUtils.CnvSng(TxtTax3.Text)
        ._TX4TH = MyUtils.CnvSng(TxtTax4.Text)
        ._BALD = MyUtils.CnvSng(LblTaxT.Text)
        ._IPPCD1 = MyUtils.CnvSng(TxtCode1.Text)
        ._IPPCD2 = MyUtils.CnvSng(TxtCode2.Text)
        ._IPPCD3 = MyUtils.CnvSng(TxtCode3.Text)
        ._IPPCD4 = MyUtils.CnvSng(TxtCode4.Text)
        ._IPPCD5 = MyUtils.CnvSng(TxtCode5.Text)
        ._IPPCD6 = MyUtils.CnvSng(TxtCode6.Text)
        ._IPPCD7 = MyUtils.CnvSng(TxtCode7.Text)
        ._IPPCD8 = MyUtils.CnvSng(TxtCode8.Text)
        ._IPPCD9 = MyUtils.CnvSng(TxtCode9.Text)
        ._IPPCDA = MyUtils.CnvSng(TxtCode10.Text)
        ._UNIT1 = MyUtils.CnvSng(TxtUnit1.Text)
        ._OAS1 = MyUtils.CnvSng(TxtAssmt1.Text)
        ._UNIT2 = MyUtils.CnvSng(TxtUnit2.Text)
        ._OAS2 = MyUtils.CnvSng(TxtAssmt2.Text)
        ._UNIT3 = MyUtils.CnvSng(TxtUnit3.Text)
        ._OAS3 = MyUtils.CnvSng(TxtAssmt3.Text)
        ._UNIT4 = MyUtils.CnvSng(TxtUnit4.Text)
        ._OAS4 = MyUtils.CnvSng(TxtAssmt4.Text)
        ._UNIT5 = MyUtils.CnvSng(TxtUnit5.Text)
        ._OAS5 = MyUtils.CnvSng(TxtAssmt5.Text)
        ._UNIT6 = MyUtils.CnvSng(TxtUnit6.Text)
        ._OAS6 = MyUtils.CnvSng(TxtAssmt6.Text)
        ._UNIT7 = MyUtils.CnvSng(TxtUnit7.Text)
        ._OAS7 = MyUtils.CnvSng(TxtAssmt7.Text)
        ._UNIT8 = MyUtils.CnvSng(TxtUnit8.Text)
        ._OAS8 = MyUtils.CnvSng(TxtAssmt8.Text)
        ._UNIT9 = MyUtils.CnvSng(TxtUnit9.Text)
        ._OAS9 = MyUtils.CnvSng(TxtAssmt9.Text)
        ._UNITA = MyUtils.CnvSng(TxtUnit10.Text)
        ._OAS10 = MyUtils.CnvSng(TxtAssmt10.Text)
        'Exemption Codes
        ._EXCD1 = TxtExempt1.Text
        ._EXCD2 = TxtExempt2.Text
        ._EXCD3 = TxtExempt3.Text
        ._EXCD4 = TxtExempt4.Text
        ._EXCD5 = TxtExempt5.Text
        ._EXCD6 = TxtExempt6.Text
        ._EXCD7 = TxtExempt7.Text
        ._EXAM1 = MyUtils.CnvSng(TxtExam1.Text)
        ._EXAM2 = MyUtils.CnvSng(TxtExam2.Text)
        ._EXAM3 = MyUtils.CnvSng(TxtExam3.Text)
        ._EXAM4 = MyUtils.CnvSng(TxtExam4.Text)
        ._EXAM5 = MyUtils.CnvSng(TxtExam5.Text)
        ._EXAM6 = MyUtils.CnvSng(TxtExam6.Text)
        ._EXAM7 = MyUtils.CnvSng(TxtExam7.Text)
        ._FRYR = MyUtils.CnvSng(TxtEldYear.Text)
        ._CPERC = MyUtils.CnvSng(TxtEldPerc.Text)
        ._CMAX = MyUtils.CnvSng(TxtEldMax.Text)
        ._CMIN = MyUtils.CnvSng(TxtEldMin.Text)
        ._FTAX = MyUtils.CnvSng(TxtEldTax.Text)
        ._CIRAD = MyUtils.CnvSng(TxtEldAdj.Text)
        ._MAKE = TxtMake.Text
        ._MODEL = TxtModel.Text
        ._MVYR = MyUtils.CnvSng(TxtYear.Text)
        ._CLASS = MyUtils.CnvSng(TxtClass.Text)
        ._IMVIDNo = TxtVIN.Text
        ._IMVREG = TxtRegno.Text
        ._ASS = TxtAss.Text
        ._ICVMKE = TxtOMake.Text
        ._ICVMOD = TxtOModel.Text
        ._ICVYR = MyUtils.CnvSng(TxtOYear.Text)
        ._ICVCLS = MyUtils.CnvSng(TxtOClass.Text)
        ._ICVIDNo = TxtOVIN.Text
        ._ICVREG = TxtORegNo.Text
        ._ICVGRS = MyUtils.CnvSng(TxtOValue.Text)
        ._ICVACD = TxtOAss.Text
      End If
    End With

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(RbSuspense, "")
    ErrProv.SetError(LblListNo, "")
    ErrProv.SetError(TxtName, "")
    ErrProv.SetError(TxtAdd1, "")
    ErrProv.SetError(TxtCity, "")
    ErrProv.SetError(TxtState, "")
    ErrProv.SetError(TxtZip5, "")
    ErrProv.SetError(TxtAssmt1, "")
    ErrProv.SetError(TxtCode1, "")
    ErrProv.SetError(TxtCode2, "")
    ErrProv.SetError(TxtCode3, "")
    ErrProv.SetError(TxtCode4, "")
    ErrProv.SetError(TxtCode5, "")
    ErrProv.SetError(TxtCode6, "")
    ErrProv.SetError(TxtCode7, "")
    ErrProv.SetError(TxtCode8, "")
    ErrProv.SetError(TxtCode9, "")
    ErrProv.SetError(TxtCode10, "")
    ErrProv.SetError(TxtExempt1, "")
    ErrProv.SetError(TxtExempt2, "")
    ErrProv.SetError(TxtExempt3, "")
    ErrProv.SetError(TxtExempt4, "")
    ErrProv.SetError(TxtExempt5, "")
    ErrProv.SetError(TxtExempt6, "")
    ErrProv.SetError(TxtExempt7, "")
    ErrProv.SetError(TxtBankCd, "")
    ErrProv.SetError(TxtAss, "")
    ErrProv.SetError(TxtOAss, "")
    ErrProv.SetError(TxtStatus, "")
    ErrProv.SetError(TxtSSNo, "")
    ErrProv.SetError(TxtSS2, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
        Case "rcode"
          ErrProv.SetError(RbSuspense, ErrorMsg(I))
        Case "list#"
          ErrProv.SetError(LblListNo, ErrorMsg(I))
        Case "name"
          ErrProv.SetError(TxtName, ErrorMsg(I))
        Case "add1"
          ErrProv.SetError(TxtAdd1, ErrorMsg(I))
        Case "city"
          ErrProv.SetError(TxtCity, ErrorMsg(I))
        Case "state"
          ErrProv.SetError(TxtState, ErrorMsg(I))
        Case "zip5"
          ErrProv.SetError(TxtZip5, ErrorMsg(I))
        Case "ass1"
          ErrProv.SetError(TxtAssmt1, ErrorMsg(I))
        Case "code1"
          ErrProv.SetError(TxtCode1, ErrorMsg(I))
        Case "code2"
          ErrProv.SetError(TxtCode2, ErrorMsg(I))
        Case "code3"
          ErrProv.SetError(TxtCode3, ErrorMsg(I))
        Case "code4"
          ErrProv.SetError(TxtCode4, ErrorMsg(I))
        Case "code5"
          ErrProv.SetError(TxtCode5, ErrorMsg(I))
        Case "code6"
          ErrProv.SetError(TxtCode6, ErrorMsg(I))
        Case "code7"
          ErrProv.SetError(TxtCode7, ErrorMsg(I))
        Case "code8"
          ErrProv.SetError(TxtCode8, ErrorMsg(I))
        Case "code9"
          ErrProv.SetError(TxtCode9, ErrorMsg(I))
        Case "code10"
          ErrProv.SetError(TxtCode10, ErrorMsg(I))
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
        Case "excd6"
          ErrProv.SetError(TxtExempt6, ErrorMsg(I))
        Case "excd7"
          ErrProv.SetError(TxtExempt7, ErrorMsg(I))
        Case "bkcd"
          ErrProv.SetError(TxtBankCd, ErrorMsg(I))
        Case "ass"
          ErrProv.SetError(TxtAss, ErrorMsg(I))
        Case "oass"
          ErrProv.SetError(TxtOAss, ErrorMsg(I))
        Case "stscd"
          ErrProv.SetError(TxtStatus, ErrorMsg(I))
        Case "ssno"
          ErrProv.SetError(TxtSSNo, ErrorMsg(I))
        Case "ss2"
          ErrProv.SetError(TxtSS2, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim WrkTip As String
    Dim WrkSts(4) As String
    Dim I As Integer
    Dim J As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtName.Text = String.Empty Then
      I = I + 1
      ErrorField(I) = "name"
      ErrorMsg(I) = "Name cannot be blank"
    End If

    If TxtAdd1.Text = String.Empty Then
      I = I + 1
      ErrorField(I) = "addr1"
      ErrorMsg(I) = "Address1 cannot be blank"
    End If

    If TxtCity.Text = String.Empty Then
      I = I + 1
      ErrorField(I) = "city"
      ErrorMsg(I) = "City cannot be blank"
    End If

    If AddMode Then
      If MyUtils.CnvSng(TxtCode1.Text) > 0 Then
        WrkTip = Ttp1.GetToolTip(TxtCode1)
        If Mid(WrkTip, 1, 1) = "*" Then
          ErrorField(I) = "code1"
          ErrorMsg(I) = "Invalid Assessment Code"
          I = I + 1
        End If
      End If

      If MyUtils.CnvSng(TxtCode2.Text) > 0 Then
        WrkTip = Ttp1.GetToolTip(TxtCode2)
        If Mid(WrkTip, 1, 1) = "*" Then
          ErrorField(I) = "code2"
          ErrorMsg(I) = "Invalid Assessment Code"
          I = I + 1
        End If
      End If

      If MyUtils.CnvSng(TxtCode3.Text) > 0 Then
        WrkTip = Ttp1.GetToolTip(TxtCode3)
        If Mid(WrkTip, 1, 1) = "*" Then
          ErrorField(I) = "code3"
          ErrorMsg(I) = "Invalid Assessment Code"
          I = I + 1
        End If
      End If

      If MyUtils.CnvSng(TxtCode4.Text) > 0 Then
        WrkTip = Ttp1.GetToolTip(TxtCode4)
        If Mid(WrkTip, 1, 1) = "*" Then
          ErrorField(I) = "code4"
          ErrorMsg(I) = "Invalid Assessment Code"
          I = I + 1
        End If
      End If

      If MyUtils.CnvSng(TxtCode5.Text) > 0 Then
        WrkTip = Ttp1.GetToolTip(TxtCode5)
        If Mid(WrkTip, 1, 1) = "*" Then
          ErrorField(I) = "code5"
          ErrorMsg(I) = "Invalid Assessment Code"
          I = I + 1
        End If
      End If

      If MyUtils.CnvSng(TxtCode6.Text) > 0 Then
        WrkTip = Ttp1.GetToolTip(TxtCode6)
        If Mid(WrkTip, 1, 1) = "*" Then
          ErrorField(I) = "code6"
          ErrorMsg(I) = "Invalid Assessment Code"
          I = I + 1
        End If
      End If

      If MyUtils.CnvSng(TxtCode7.Text) > 0 Then
        WrkTip = Ttp1.GetToolTip(TxtCode7)
        If Mid(WrkTip, 1, 1) = "*" Then
          ErrorField(I) = "code7"
          ErrorMsg(I) = "Invalid Assessment Code"
          I = I + 1
        End If
      End If

      If MyUtils.CnvSng(TxtCode8.Text) > 0 Then
        WrkTip = Ttp1.GetToolTip(TxtCode8)
        If Mid(WrkTip, 1, 1) = "*" Then
          ErrorField(I) = "code8"
          ErrorMsg(I) = "Invalid Assessment Code"
          I = I + 1
        End If
      End If

      If MyUtils.CnvSng(TxtCode9.Text) > 0 Then
        WrkTip = Ttp1.GetToolTip(TxtCode9)
        If Mid(WrkTip, 1, 1) = "*" Then
          ErrorField(I) = "code9"
          ErrorMsg(I) = "Invalid Assessment Code"
          I = I + 1
        End If
      End If

      If MyUtils.CnvSng(TxtCode10.Text) > 0 Then
        WrkTip = Ttp1.GetToolTip(TxtCode10)
        If Mid(WrkTip, 1, 1) = "*" Then
          ErrorField(I) = "code10"
          ErrorMsg(I) = "Invalid Assessment Code"
          I = I + 1
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

      If TxtExempt6.Text <> "" Then
        WrkTip = Ttp1.GetToolTip(TxtExempt6)
        If Mid(WrkTip, 1, 1) = "*" Then
          ErrorField(I) = "excd6"
          ErrorMsg(I) = "Invalid Exemption Code"
          I = I + 1
        End If
      End If

      If TxtExempt7.Text <> "" Then
        WrkTip = Ttp1.GetToolTip(TxtExempt7)
        If Mid(WrkTip, 1, 1) = "*" Then
          ErrorField(I) = "excd7"
          ErrorMsg(I) = "Invalid Exemption Code"
          I = I + 1
        End If
      End If

      If TxtAss.Text <> "" Then
        WrkTip = Ttp1.GetToolTip(TxtAss)
        If Mid(WrkTip, 1, 1) = "*" Then
          ErrorField(I) = "ass"
          ErrorMsg(I) = "Invalid Assessment Code"
          I = I + 1
        End If
      End If

      If TxtOAss.Text <> "" Then
        WrkTip = Ttp1.GetToolTip(TxtOAss)
        If Mid(WrkTip, 1, 1) = "*" Then
          ErrorField(I) = "oass"
          ErrorMsg(I) = "Invalid Credit Assessment Code"
          I = I + 1
        End If
      End If
    End If

    If TxtBankCd.Text <> "" Then
      WrkTip = Ttp1.GetToolTip(TxtBankCd)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "bkcd"
        ErrorMsg(I) = "Invalid Bank Code"
        I = I + 1
      End If
    End If

    If Not AddMode Then
      If LblStatus.Text = String.Empty And RbSuspense.Checked Then
        ErrorField(I) = "rcode"
        ErrorMsg(I) = "You cannot suspend account using this program"
        I = I + 1
      End If
    End If

    WrkSts(0) = Mid(TxtStatus.Text, 1, 1)
    WrkSts(1) = Mid(TxtStatus.Text, 2, 1)
    WrkSts(2) = Mid(TxtStatus.Text, 3, 1)
    WrkSts(3) = Mid(TxtStatus.Text, 4, 1)
    WrkSts(4) = Mid(TxtStatus.Text, 5, 1)
    For J = 0 To 4
      If WrkSts(J) = String.Empty Then Continue For
      myTXSTS.GetOneRecordP(WrkSts(J))
      If myTXSTS.RecordNotFound Then
        ErrorField(I) = "stscd"
        ErrorMsg(I) = "Status Code " & WrkSts(J) & " is invalid"
        I = I + 1
      End If
    Next

    If MyUtils.CnvSng(TxtSSNo.Text) > 0 Then
      myTXVCUS.GetOneRecordP(MyUtils.CnvSng(TxtSSNo.Text))
      If myTXVCUS.RecordNotFound Then
        ErrorField(I) = "ssno"
        ErrorMsg(I) = "Invalid Primary CustID"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtSS2.Text) > 0 Then
      myTXVCUS.GetOneRecordP(MyUtils.CnvSng(TxtSS2.Text))
      If myTXVCUS.RecordNotFound Then
        ErrorField(I) = "ss2"
        ErrorMsg(I) = "Invalid Secondary CustID"
        I = I + 1
      End If
    End If
  End Sub
  Private Sub FrmTX405C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX405.SbpScreen.Text = "TX405C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub TxtAssmt1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAssmt1.TextChanged
    CalcAssmt()
  End Sub
  Private Sub TxtAssmt2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAssmt2.TextChanged
    CalcAssmt()
  End Sub
  Private Sub TxtAssmt3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAssmt3.TextChanged
    CalcAssmt()
  End Sub
  Private Sub TxtAssmt4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAssmt4.TextChanged
    CalcAssmt()
  End Sub
  Private Sub TxtAssmt5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAssmt5.TextChanged
    CalcAssmt()
  End Sub
  Private Sub TxtAssmt6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAssmt6.TextChanged
    CalcAssmt()
  End Sub
  Private Sub TxtAssmt7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAssmt7.TextChanged
    CalcAssmt()
  End Sub
  Private Sub TxtAssmt8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAssmt8.TextChanged
    CalcAssmt()
  End Sub
  Private Sub TxtAssmt9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAssmt9.TextChanged
    CalcAssmt()
  End Sub
  Private Sub TxtAssmt10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAssmt10.TextChanged
    CalcAssmt()
  End Sub
  Private Sub TxtValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtValue.TextChanged
    CalcAssmt()
  End Sub
  Private Sub TxtOValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    CalcAssmt()
  End Sub
  Private Sub CalcAssmt()
    Dim TotGross As Long
    Dim TotExempt As Long
    Dim WrkFamily As String

    WrkFamily = GetTXTypeFamily(WrkType)
    Select Case WrkFamily
      Case "M"
        TotGross = MyUtils.CnvSng(TxtValue.Text)
      Case "S"
        TotGross = MyUtils.CnvSng(TxtValue.Text) - MyUtils.CnvSng(TxtOValue.Text)
      Case Else
        TotGross = MyUtils.CnvSng(TxtAssmt1.Text) + MyUtils.CnvSng(TxtAssmt2.Text) + MyUtils.CnvSng(TxtAssmt3.Text) +
        MyUtils.CnvSng(TxtAssmt4.Text) + MyUtils.CnvSng(TxtAssmt5.Text) + MyUtils.CnvSng(TxtAssmt6.Text) + MyUtils.CnvSng(TxtAssmt7.Text) +
        MyUtils.CnvSng(TxtAssmt8.Text) + MyUtils.CnvSng(TxtAssmt9.Text) + MyUtils.CnvSng(TxtAssmt10.Text)
    End Select
    TotExempt = MyUtils.CnvSng(TxtExam1.Text) + MyUtils.CnvSng(TxtExam2.Text) + MyUtils.CnvSng(TxtExam3.Text) + MyUtils.CnvSng(TxtExam4.Text) +
      MyUtils.CnvSng(TxtExam5.Text) + MyUtils.CnvSng(TxtExam6.Text) + MyUtils.CnvSng(TxtExam7.Text)
    LblGross.Text = TotGross
    LblExempt.Text = TotExempt
    LblNet.Text = TotGross - TotExempt
  End Sub
  Private Sub TxtExam1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam1.TextChanged
    CalcAssmt()
  End Sub
  Private Sub TxtExam2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam2.TextChanged
    CalcAssmt()
  End Sub
  Private Sub TxtExam3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam3.TextChanged
    CalcAssmt()
  End Sub
  Private Sub TxtExam4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam4.TextChanged
    CalcAssmt()
  End Sub
  Private Sub TxtExam5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam5.TextChanged
    CalcAssmt()
  End Sub
  Private Sub TxtExam6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam6.TextChanged
    CalcAssmt()
  End Sub
  Private Sub TxtExam7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam7.TextChanged
    CalcAssmt()
  End Sub
  Private Sub GetTxProf()
    Dim WrkPhase As String

    If MyUtils.CnvSng(TxtPhase.Text) = 0 Then
      WrkPhase = ""
    Else
      WrkPhase = MyUtils.CnvSng(MyFrmTX405C.TxtPhase.Text)
    End If
    myTXPROF.GetOneRecordP(WrkType, WrkYear, WrkPhase, MyUtils.CnvSng(TxtDist.Text))

    TxtTax2.Visible = False
    LblTax2Txt.Visible = False
    TxtTax3.Visible = False
    LblTax3Txt.Visible = False
    TxtTax4.Visible = False
    LblTax4Txt.Visible = False
    LblCCTax2.Visible = False
    LblCCTax2Txt.Visible = False
    LblCCTax3.Visible = False
    LblCCTax3Txt.Visible = False
    LblCCTax4.Visible = False
    LblCCTax4Txt.Visible = False

    If myTXPROF.RecordNotFound Then Exit Sub

    With myTXPROF
      If ._PRPERD > 1 Then
        TxtTax2.Visible = True
        LblTax2Txt.Visible = True
        LblCCTax2.Visible = True
        LblCCTax2Txt.Visible = True
      End If
      If ._PRPERD > 2 Then
        TxtTax3.Visible = True
        LblTax3Txt.Visible = True
        LblCCTax3.Visible = True
        LblCCTax3Txt.Visible = True
      End If
      If ._PRPERD > 3 Then
        TxtTax4.Visible = True
        LblTax4Txt.Visible = True
        LblCCTax4.Visible = True
        LblCCTax4Txt.Visible = True
      End If
    End With

  End Sub
  Private Sub TxtZip5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZip5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtZip4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZip4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDist_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtGross_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtExempt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtNet_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDist_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtTax1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTax1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtTax2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTax2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtTax3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTax3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtTax4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTax4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtAssmt1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAssmt1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAssmt2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAssmt2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAssmt3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAssmt3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAssmt4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAssmt4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAssmt5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAssmt5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAssmt6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAssmt6.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAssmt7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAssmt7.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCode1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCode2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCode3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCode4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCode5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCode6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode6.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCode7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode7.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUnit1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUnit1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUnit2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUnit2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUnit3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUnit3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUnit4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUnit4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUnit5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUnit5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUnit6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUnit6.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUnit7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUnit7.KeyPress
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
  Private Sub TxtExam6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtExam6.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtExam7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtExam7.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtEldYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEldYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtEldPerc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEldPerc.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtEldMax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEldMax.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtEldMin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEldMin.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtEldTax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEldTax.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtEldAdj_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEldAdj.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtClass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClass.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtValue.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtOYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtOClass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOClass.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtOValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOValue.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBond_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBond.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtOBondPaid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBondPaid.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub SetCode1Tip()
    Dim WrkDesc As String

    If Not TxtCode1.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode1.Text), WrkType)
    Ttp1.SetToolTip(TxtCode1, WrkDesc)
  End Sub
  Private Sub SetCode2Tip()
    Dim WrkDesc As String

    If Not TxtCode2.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode2.Text), WrkType)
    Ttp1.SetToolTip(TxtCode2, WrkDesc)
  End Sub
  Private Sub SetCode3Tip()
    Dim WrkDesc As String

    If Not TxtCode3.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode3.Text), WrkType)
    Ttp1.SetToolTip(TxtCode3, WrkDesc)
  End Sub
  Private Sub SetCode4Tip()
    Dim WrkDesc As String

    If Not TxtCode4.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode4.Text), WrkType)
    Ttp1.SetToolTip(TxtCode4, WrkDesc)
  End Sub
  Private Sub SetCode5Tip()
    Dim WrkDesc As String

    If Not TxtCode5.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode5.Text), WrkType)
    Ttp1.SetToolTip(TxtCode5, WrkDesc)
  End Sub
  Private Sub SetCode6Tip()
    Dim WrkDesc As String

    If Not TxtCode6.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode6.Text), WrkType)
    Ttp1.SetToolTip(TxtCode6, WrkDesc)
  End Sub
  Private Sub SetCode7Tip()
    Dim WrkDesc As String

    If Not TxtCode7.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode7.Text), WrkType)
    Ttp1.SetToolTip(TxtCode7, WrkDesc)
  End Sub
  Private Sub SetCode8Tip()
    Dim WrkDesc As String

    If Not TxtCode8.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode8.Text), WrkType)
    Ttp1.SetToolTip(TxtCode8, WrkDesc)
  End Sub
  Private Sub SetCode9Tip()
    Dim WrkDesc As String

    If Not TxtCode9.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode9.Text), WrkType)
    Ttp1.SetToolTip(TxtCode9, WrkDesc)
  End Sub
  Private Sub SetCode10Tip()
    Dim WrkDesc As String

    If Not TxtCode10.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode10.Text), WrkType)
    Ttp1.SetToolTip(TxtCode10, WrkDesc)
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
  Private Sub SetExem6Tip()
    Dim WrkTxExem As String()

    If Not TxtExempt6.Modified And Not LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt6.Text)
    Ttp1.SetToolTip(TxtExempt6, WrkTxExem(1))
  End Sub
  Private Sub SetExem7Tip()
    Dim WrkTxExem As String()

    If Not TxtExempt7.Modified And Not LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt7.Text)
    Ttp1.SetToolTip(TxtExempt7, WrkTxExem(1))
  End Sub
  Private Sub SetBankTip()
    Dim WrkDesc As String

    If Not TxtBankCd.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXBanksDesc(TxtBankCd.Text)
    Ttp1.SetToolTip(TxtBankCd, WrkDesc)
  End Sub
  Private Sub LnkCode1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode1.LinkClicked
    If Not AddMode Then Exit Sub
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode1.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode1.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode2.LinkClicked
    If Not AddMode Then Exit Sub
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode2.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode2.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode3.LinkClicked
    If Not AddMode Then Exit Sub
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode3.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode3.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode4.LinkClicked
    If Not AddMode Then Exit Sub
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode4.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode4.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode5.LinkClicked
    If Not AddMode Then Exit Sub
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode5.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode5.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode6.LinkClicked
    If Not AddMode Then Exit Sub
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode6.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode6.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode7.LinkClicked
    If Not AddMode Then Exit Sub
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode7.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode7.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode8.LinkClicked
    If Not AddMode Then Exit Sub
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode8.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode8.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode9_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode9.LinkClicked
    If Not AddMode Then Exit Sub
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode9.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode9.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode10_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode10.LinkClicked
    If Not AddMode Then Exit Sub
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode10.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode10.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub TxtCode1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCode1.Leave
    SetCode1Tip()
  End Sub
  Private Sub TxtCode2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCode2.Leave
    SetCode2Tip()
  End Sub
  Private Sub TxtCode3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCode3.Leave
    SetCode3Tip()
  End Sub
  Private Sub TxtCode4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCode4.Leave
    SetCode4Tip()
  End Sub
  Private Sub TxtCode5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCode5.Leave
    SetCode5Tip()
  End Sub
  Private Sub TxtCode6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCode6.Leave
    SetCode6Tip()
  End Sub
  Private Sub TxtCode7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCode7.Leave
    SetCode7Tip()
  End Sub
  Private Sub TxtCode8_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCode8.Leave
    SetCode8Tip()
  End Sub
  Private Sub TxtCode9_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCode9.Leave
    SetCode9Tip()
  End Sub
  Private Sub TxtCode10_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCode10.Leave
    SetCode10Tip()
  End Sub
  Private Sub LnkExempt1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt1.LinkClicked
    If Not AddMode Then Exit Sub
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt1.Text
    MyFrmListExemption.WrkCode = TxtExempt1.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt2.LinkClicked
    If Not AddMode Then Exit Sub
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt2.Text
    MyFrmListExemption.WrkCode = TxtExempt2.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt3.LinkClicked
    If Not AddMode Then Exit Sub
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt3.Text
    MyFrmListExemption.WrkCode = TxtExempt3.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt4.LinkClicked
    If Not AddMode Then Exit Sub
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt4.Text
    MyFrmListExemption.WrkCode = TxtExempt4.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt5.LinkClicked
    If Not AddMode Then Exit Sub
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt5.Text
    MyFrmListExemption.WrkCode = TxtExempt5.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt6.LinkClicked
    If Not AddMode Then Exit Sub
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt6.Text
    MyFrmListExemption.WrkCode = TxtExempt6.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt7.LinkClicked
    If Not AddMode Then Exit Sub
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt7.Text
    MyFrmListExemption.WrkCode = TxtExempt7.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub TxtExempt1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt1.TextChanged

    Dim WrkTxExem As String()

    If LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt1.Text)
    TxtExam1.Text = WrkTxExem(0)

  End Sub
  Private Sub TxtExempt2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt2.TextChanged
    Dim WrkTxExem As String()

    If LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt2.Text)
    TxtExam2.Text = WrkTxExem(0)
  End Sub
  Private Sub TxtExempt3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt3.TextChanged
    Dim WrkTxExem As String()

    If LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt3.Text)
    TxtExam3.Text = WrkTxExem(0)
  End Sub
  Private Sub TxtExempt4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt4.TextChanged
    Dim WrkTxExem As String()

    If LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt4.Text)
    TxtExam4.Text = WrkTxExem(0)
  End Sub
  Private Sub TxtExempt5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt5.TextChanged
    Dim WrkTxExem As String()

    If LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt5.Text)
    TxtExam5.Text = WrkTxExem(0)
  End Sub
  Private Sub TxtExempt6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt6.TextChanged
    Dim WrkTxExem As String()

    If LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt6.Text)
    TxtExam6.Text = WrkTxExem(0)
  End Sub
  Private Sub TxtExempt7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt7.TextChanged
    Dim WrkTxExem As String()

    If LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt7.Text)
    TxtExam7.Text = WrkTxExem(0)
  End Sub
  Private Sub LockElderly(ByVal Lock As Boolean)

    If Lock Then
      TxtEldYear.ReadOnly = True
      TxtEldPerc.ReadOnly = True
      TxtEldMin.ReadOnly = True
      TxtEldMax.ReadOnly = True
      TxtEldTax.ReadOnly = True
      TxtEldAdj.ReadOnly = True
      LnkEldPerc.Enabled = False
    Else
      TxtEldYear.ReadOnly = False
      TxtEldPerc.ReadOnly = False
      TxtEldMin.ReadOnly = False
      TxtEldMax.ReadOnly = False
      TxtEldTax.ReadOnly = False
      TxtEldAdj.ReadOnly = False
      LnkEldPerc.Enabled = True
    End If

  End Sub
  Private Sub RbEldNA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbEldNA.Click
    LockElderly(True)
  End Sub
  Private Sub RbEldHeart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbEldHeart.Click
    LockElderly(False)
  End Sub
  Private Sub RbEldFrozen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbEldFrozen.Click
    LockElderly(False)
  End Sub
  Private Sub LnkEldPerc_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkEldPerc.LinkClicked
    If Not AddMode Then Exit Sub
    MyFrmListHome = New FrmListHome
    MyFrmListHome.MdiParent = Me.ParentForm
    MyFrmListHome.WrkPct = MyUtils.CnvSng(TxtEldPerc.Text)
    MyFrmListHome.Show()
  End Sub
  Private Sub LnkAsmt_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkAsmt.LinkClicked
    If Not AddMode Then Exit Sub
    MyFrmListSupCd = New FrmListSupCd
    MyFrmListSupCd.MdiParent = Me.ParentForm
    MyFrmListSupCd.WrkFieldNo = ""
    MyFrmListSupCd.WrkCode = TxtAss.Text
    MyFrmListSupCd.Show()
  End Sub

  Private Sub LnkOAsmt_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    If Not AddMode Then Exit Sub
    MyFrmListSupCd = New FrmListSupCd
    MyFrmListSupCd.MdiParent = Me.ParentForm
    MyFrmListSupCd.WrkFieldNo = "Credit"
    MyFrmListSupCd.WrkCode = TxtOAss.Text
    MyFrmListSupCd.Show()

  End Sub
  Private Sub TxtTax1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTax1.TextChanged
    CalcTotTax()
  End Sub
  Private Sub TxtTax2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTax2.TextChanged
    CalcTotTax()
  End Sub
  Private Sub TxtTax3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTax3.TextChanged
    CalcTotTax()
  End Sub
  Private Sub TxtTax4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTax4.TextChanged
    CalcTotTax()
  End Sub
  Private Sub CalcTotTax()
    Dim TotTax As Decimal

    TotTax = MyUtils.CnvSng(TxtTax1.Text) + MyUtils.CnvSng(TxtTax2.Text) + MyUtils.CnvSng(TxtTax3.Text) +
      MyUtils.CnvSng(TxtTax4.Text)
    LblTaxT.Text = Format(TotTax, "fixed")
  End Sub
  Private Sub TxtDefer1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDefer1.TextChanged
    CalcDeferTax()
  End Sub
  Private Sub TxtDefer2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDefer2.TextChanged
    CalcDeferTax()
  End Sub
  Private Sub TxtDefer3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDefer3.TextChanged
    CalcDeferTax()
  End Sub
  Private Sub TxtDefer4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDefer4.TextChanged
    CalcDeferTax()
  End Sub
  Private Sub CalcDeferTax()
    Dim TotTax As Decimal

    TotTax = MyUtils.CnvSng(TxtDefer1.Text) + MyUtils.CnvSng(TxtDefer2.Text) + MyUtils.CnvSng(TxtDefer3.Text) +
      MyUtils.CnvSng(TxtDefer4.Text)
    LblDeferT.Text = Format(TotTax, "fixed")
  End Sub
  Private Sub LnkSSNo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkSSno.LinkClicked
    MyFrmListVcus = New FrmListVcus
    MyFrmListVcus.MdiParent = Me.ParentForm
    MyFrmListVcus.WrkName = TxtName.Text
    MyFrmListVcus.WrkPrimary = True
    MyFrmListVcus.Show()
  End Sub
  Private Sub LnkStatus_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkStatus.LinkClicked
    MySts = TxtStatus.Text
    MyFrmSelStatus = New FrmSelStatus
    MyFrmSelStatus.MdiParent = Me.ParentForm
    MyFrmSelStatus.Show()
  End Sub

  Private Sub LnkSS2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkSS2.LinkClicked
    MyFrmListVcus = New FrmListVcus
    MyFrmListVcus.MdiParent = Me.ParentForm
    MyFrmListVcus.WrkName = TxtName.Text
    MyFrmListVcus.WrkPrimary = False
    MyFrmListVcus.Show()
  End Sub
  Private Sub LnkOID_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkOID.LinkClicked
    MyFrmListVeh = New FrmListVeh
    MyFrmListVeh.MdiParent = Me.ParentForm
    MyFrmListVeh.WrkCustID = MyUtils.CnvSng(TxtSSNo.Text)
    MyFrmListVeh.Show()
  End Sub
  Private Sub FrmTX405_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    Dim WrkAcct As String

    Select Case WrkFamily
      Case "A"
        TabCtl1.TabPages.Add(TabPgAssmnt)
        TabCtl1.TabPages.Add(TabPgExempt)
        TabCtl1.TabPages.Add(TabPgEld)
        TabCtl1.TabPages.Add(TabPgMV)
      Case "R"
        TabCtl1.TabPages.Add(TabPgMV)
        TabCtl1.TabPages.Add(TabPgUB)
      Case "P"
        TabCtl1.TabPages.Add(TabPgEld)
        TabCtl1.TabPages.Add(TabPgMV)
        TabCtl1.TabPages.Add(TabPgUB)
      Case "M"
        TabCtl1.TabPages.Add(TabPgEld)
        TabCtl1.TabPages.Add(TabPgAssmnt)
        TabCtl1.TabPages.Add(TabPgUB)
      Case "S"
        TabCtl1.TabPages.Add(TabPgEld)
        TabCtl1.TabPages.Add(TabPgAssmnt)
        TabCtl1.TabPages.Add(TabPgUB)
      Case "U"
        TabCtl1.TabPages.Add(TabPgAssmnt)
        TabCtl1.TabPages.Add(TabPgExempt)
        TabCtl1.TabPages.Add(TabPgEld)
        TabCtl1.TabPages.Add(TabPgMV)
        TabCtl1.TabPages.Add(TabPgUB)
      Case Else
    End Select

    WrkAcct = ProcessSelItems()
    If WrkAcct <> "" Then
      LoadForm(WrkAcct)
      e.Cancel = True
    End If

  End Sub

  'MK 9/29/25 Add CalcPrinDue to radio button click events
  Private Sub RbNA_Click(sender As Object, e As EventArgs) Handles RbNA.Click
    GrpDefer.Visible = False
    CalcPrinDue()
  End Sub
  Private Sub RbBackTax_Click(sender As Object, e As EventArgs) Handles RbBackTax.Click
    GrpDefer.Visible = False
    CalcPrinDue()
  End Sub
  Private Sub RbForeclosure_Click(sender As Object, e As EventArgs) Handles RbForeclosure.Click
    GrpDefer.Visible = False
    CalcPrinDue()
  End Sub
  Private Sub RbInactive_Click(sender As Object, e As EventArgs) Handles RbInactive.Click
    GrpDefer.Visible = False
    CalcPrinDue()
  End Sub
  Private Sub RbSuspense_Click(sender As Object, e As EventArgs) Handles RbSuspense.Click
    GrpDefer.Visible = False
    CalcPrinDue()
  End Sub
  Private Sub RbDefer_Click(sender As Object, e As EventArgs) Handles RbDefer.Click
    GrpDefer.Visible = True
    CalcPrinDue()
  End Sub
  Private Sub RbDeferExpire_Click(sender As Object, e As EventArgs) Handles RbDeferExpire.Click
    GrpDefer.Visible = True
    CalcPrinDue()
  End Sub
  'MK 9/29/25 End
  Private Sub LnkBankSvc_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBankSvc.LinkClicked
    MyFrmListBser = New FrmListBser
    MyFrmListBser.MdiParent = Me.ParentForm
    MyFrmListBser.WrkCode = TxtBankServ.Text
    MyFrmListBser.Show()
  End Sub
  Private Sub LnkBankCd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkBankCd.LinkClicked
    MyFrmListBanks = New FrmListBanks
    MyFrmListBanks.MdiParent = Me.ParentForm
    MyFrmListBanks.WrkCode = TxtBankCd.Text
    MyFrmListBanks.Show()
  End Sub
End Class






