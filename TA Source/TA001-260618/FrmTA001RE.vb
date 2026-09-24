Imports System.Data
Imports System.Xml
Public Class FrmTA001RE
  Inherits System.Windows.Forms.Form
  Friend WrkListNo As Integer
  Friend WrkFastPath As Boolean
  Dim myTXREAL As TXREAL.MyData
  Dim myTXREALC As TXREALC.MyData
  Dim myTXBTR As TXBTR.MyData
  Dim myTXBTRC As TXBTRC.MyData
  Dim myTXPZ As TXPZ.MyData
  Dim myTXTRANS As TXTRANS.MyData
  Dim myTXPHIN As TXPHIN.MyData
  Dim myTXHOME As TXHOME.MyData
  Dim myUTCUST As UTCUST.MyData
  Dim myTAXCOM As TAXCOM.MyData
  Dim myLOGRE As LOGRE.MyData
  Dim myTXNCAM As TXNCAM.MyData
  Dim LoadScrn As Boolean
  Dim AddMode As Boolean

  Dim logre_ds As DataSet = New DataSet
  Friend WithEvents LblSoftFreeze As System.Windows.Forms.Label
  Friend WithEvents TpPhaseIn As System.Windows.Forms.TabPage
  Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
  Friend WithEvents LblPhaseGross As System.Windows.Forms.Label
  Friend WithEvents LblFullGross As System.Windows.Forms.Label
  Friend WithEvents LblAdjGross As System.Windows.Forms.Label
  Friend WithEvents LblPhaseAssmnt7 As System.Windows.Forms.Label
  Friend WithEvents LblPhaseCode7 As System.Windows.Forms.Label
  Friend WithEvents LblTotAssmnt7 As System.Windows.Forms.Label
  Friend WithEvents LblPhaseAssmnt6 As System.Windows.Forms.Label
  Friend WithEvents LblPhaseCode6 As System.Windows.Forms.Label
  Friend WithEvents LblTotAssmnt6 As System.Windows.Forms.Label
  Friend WithEvents LblPhaseAssmnt5 As System.Windows.Forms.Label
  Friend WithEvents LblPhaseCode5 As System.Windows.Forms.Label
  Friend WithEvents LblTotAssmnt5 As System.Windows.Forms.Label
  Friend WithEvents LblPhaseAssmnt4 As System.Windows.Forms.Label
  Friend WithEvents LblPhaseCode4 As System.Windows.Forms.Label
  Friend WithEvents LblTotAssmnt4 As System.Windows.Forms.Label
  Friend WithEvents LblPhaseAssmnt3 As System.Windows.Forms.Label
  Friend WithEvents LblPhaseCode3 As System.Windows.Forms.Label
  Friend WithEvents LblTotAssmnt3 As System.Windows.Forms.Label
  Friend WithEvents LblPhaseAssmnt2 As System.Windows.Forms.Label
  Friend WithEvents LblPhaseCode2 As System.Windows.Forms.Label
  Friend WithEvents LblTotAssmnt2 As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents LblPhaseAssmnt1 As System.Windows.Forms.Label
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents LblPhaseCode1 As System.Windows.Forms.Label
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents LblTotAssmnt1 As System.Windows.Forms.Label
  Friend WithEvents ChkNoCama As System.Windows.Forms.CheckBox
  Friend WithEvents LblElderly As System.Windows.Forms.Label
  Friend WithEvents BtnNext As System.Windows.Forms.Button
  Friend WithEvents BtnPrevious As System.Windows.Forms.Button
  Friend WithEvents LblLocalBen As System.Windows.Forms.Label
  Friend WithEvents LblLocAmt As System.Windows.Forms.Label
  Friend WithEvents TxtTranMap As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents LblComments As System.Windows.Forms.Label
  Friend WithEvents LblTaxExempt As System.Windows.Forms.Label
  Friend WithEvents LblEldPgm As System.Windows.Forms.Label
  Friend WithEvents LblEldAdj As System.Windows.Forms.Label
  Friend WithEvents LblEldTax As System.Windows.Forms.Label
  Friend WithEvents LblEldMin As System.Windows.Forms.Label
  Friend WithEvents LblEldMax As System.Windows.Forms.Label
  Friend WithEvents LblEldPerc As System.Windows.Forms.Label
  Friend WithEvents Label31 As System.Windows.Forms.Label
  Friend WithEvents TxtEldYear As System.Windows.Forms.TextBox
  Friend WithEvents LnkLocAmt As System.Windows.Forms.LinkLabel
  Friend WithEvents LblSewer As System.Windows.Forms.Label
  Friend WithEvents LblSunit As System.Windows.Forms.Label
  Friend WithEvents LblBeforeCC As System.Windows.Forms.Label
  Friend WithEvents LblNoPhaseIn As Label
  Friend WithEvents Label32 As Label
  Friend WithEvents LblOrigGross As Label
  Friend WithEvents LblCurrGross As Label
  Friend WithEvents LblCurrAssmnt7 As Label
  Friend WithEvents LblCurrAssmnt6 As Label
  Friend WithEvents LblCurrAssmnt5 As Label
  Friend WithEvents LblCurrAssmnt4 As Label
  Friend WithEvents LblCurrAssmnt3 As Label
  Friend WithEvents LblCurrAssmnt2 As Label
  Friend WithEvents Label53 As Label
  Friend WithEvents LblCurrAssmnt1 As Label
  Friend WithEvents LblAdjAssmnt7 As Label
  Friend WithEvents LblAdjAssmnt6 As Label
  Friend WithEvents LblAdjAssmnt5 As Label
  Friend WithEvents LblAdjAssmnt4 As Label
  Friend WithEvents LblAdjAssmnt3 As Label
  Friend WithEvents LblAdjAssmnt2 As Label
  Friend WithEvents LblAdjAssmnt1 As Label
  Friend WithEvents LblAdjCode7 As Label
  Friend WithEvents LblAdjCode6 As Label
  Friend WithEvents LblAdjCode5 As Label
  Friend WithEvents LblAdjCode4 As Label
  Friend WithEvents LblAdjCode3 As Label
  Friend WithEvents LblAdjCode2 As Label
  Friend WithEvents Label48 As Label
  Friend WithEvents LblAdjCode1 As Label
  Friend WithEvents LblTot As Label
  Friend WithEvents Label11 As Label
  Friend WithEvents Label22 As Label
  Const WrkType As String = "R"
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
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TxtUnit As System.Windows.Forms.TextBox
  Friend WithEvents TxtPurPrice As System.Windows.Forms.TextBox
  Friend WithEvents TxtCensus As System.Windows.Forms.TextBox
  Friend WithEvents TxtVol As System.Windows.Forms.TextBox
  Friend WithEvents Label37 As System.Windows.Forms.Label
  Friend WithEvents DtPckPurDate As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtPage As System.Windows.Forms.TextBox
  Friend WithEvents Label36 As System.Windows.Forms.Label
  Friend WithEvents Label35 As System.Windows.Forms.Label
  Friend WithEvents Label33 As System.Windows.Forms.Label
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents RbCatExempt As System.Windows.Forms.RadioButton
  Friend WithEvents RbCatTaxable As System.Windows.Forms.RadioButton
  Friend WithEvents Label27 As System.Windows.Forms.Label
  Friend WithEvents LblSunitHdr As System.Windows.Forms.Label
  Friend WithEvents TxtVetYear As System.Windows.Forms.TextBox
  Friend WithEvents Label26 As System.Windows.Forms.Label
  Friend WithEvents ChkTaxCard As System.Windows.Forms.CheckBox
  Friend WithEvents TxtSmap As System.Windows.Forms.TextBox
  Friend WithEvents TxtMap As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents DtPckBtr As System.Windows.Forms.DateTimePicker
  Friend WithEvents ChkDnbtr As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Label39 As System.Windows.Forms.Label
  Friend WithEvents TxtAcre6 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAcre4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAcre2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAcre7 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAcre5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAcre3 As System.Windows.Forms.TextBox
  Friend WithEvents Label38 As System.Windows.Forms.Label
  Friend WithEvents TxtAcre1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtBaa7 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt7 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnit7 As System.Windows.Forms.TextBox
  Friend WithEvents TxtBaa6 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt6 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnit6 As System.Windows.Forms.TextBox
  Friend WithEvents TxtBaa4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnit4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtBaa5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnit5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtBaa3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnit3 As System.Windows.Forms.TextBox
  Friend WithEvents LblBTR2 As System.Windows.Forms.Label
  Friend WithEvents TxtBaa2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt2 As System.Windows.Forms.TextBox
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents TxtUnit2 As System.Windows.Forms.TextBox
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents LblBTR1 As System.Windows.Forms.Label
  Friend WithEvents TxtBaa1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt1 As System.Windows.Forms.TextBox
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents TxtUnit1 As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents LblDtPckBTR As System.Windows.Forms.Label
  Friend WithEvents TxtDist As System.Windows.Forms.TextBox
  Friend WithEvents Label42 As System.Windows.Forms.Label
  Friend WithEvents Label40 As System.Windows.Forms.Label
  Friend WithEvents TxtOid As System.Windows.Forms.TextBox
  Friend WithEvents TxtPdst As System.Windows.Forms.TextBox
  Friend WithEvents TxtLoc As System.Windows.Forms.TextBox
  Friend WithEvents TxtLocNo As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents TpMain As System.Windows.Forms.TabPage
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtExam4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam2 As System.Windows.Forms.TextBox
  Friend WithEvents Label46 As System.Windows.Forms.Label
  Friend WithEvents Label47 As System.Windows.Forms.Label
  Friend WithEvents TxtExam5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam1 As System.Windows.Forms.TextBox
  Friend WithEvents Label50 As System.Windows.Forms.Label
  Friend WithEvents Label52 As System.Windows.Forms.Label
  Friend WithEvents TxtExam6 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam7 As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
  Friend WithEvents Label55 As System.Windows.Forms.Label
  Friend WithEvents Label57 As System.Windows.Forms.Label
  Friend WithEvents Label58 As System.Windows.Forms.Label
  Friend WithEvents Label95 As System.Windows.Forms.Label
  Friend WithEvents Label60 As System.Windows.Forms.Label
  Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
  Friend WithEvents Label74 As System.Windows.Forms.Label
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents LblNet As System.Windows.Forms.Label
  Friend WithEvents Label34 As System.Windows.Forms.Label
  Friend WithEvents LblExempt As System.Windows.Forms.Label
  Friend WithEvents LblGross As System.Windows.Forms.Label
  Friend WithEvents LblBaa As System.Windows.Forms.Label
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents Label28 As System.Windows.Forms.Label
  Friend WithEvents TxtZip4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents TxtAdd2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAdd1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtSname As System.Windows.Forms.TextBox
  Friend WithEvents TxtZip5 As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TpEld As System.Windows.Forms.TabPage
  Friend WithEvents TpTran As System.Windows.Forms.TabPage
  Friend WithEvents TpPz As System.Windows.Forms.TabPage
  Friend WithEvents Label41 As System.Windows.Forms.Label
  Friend WithEvents Label61 As System.Windows.Forms.Label
  Friend WithEvents Label62 As System.Windows.Forms.Label
  Friend WithEvents Label63 As System.Windows.Forms.Label
  Friend WithEvents Label64 As System.Windows.Forms.Label
  Friend WithEvents Label65 As System.Windows.Forms.Label
  Friend WithEvents Label66 As System.Windows.Forms.Label
  Friend WithEvents Label67 As System.Windows.Forms.Label
  Friend WithEvents Label68 As System.Windows.Forms.Label
  Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
  Friend WithEvents Label70 As System.Windows.Forms.Label
  Friend WithEvents Label71 As System.Windows.Forms.Label
  Friend WithEvents Label75 As System.Windows.Forms.Label
  Friend WithEvents Label76 As System.Windows.Forms.Label
  Friend WithEvents Label77 As System.Windows.Forms.Label
  Friend WithEvents Label78 As System.Windows.Forms.Label
  Friend WithEvents Label79 As System.Windows.Forms.Label
  Friend WithEvents Label80 As System.Windows.Forms.Label
  Friend WithEvents Label81 As System.Windows.Forms.Label
  Friend WithEvents Label82 As System.Windows.Forms.Label
  Friend WithEvents TpAct490 As System.Windows.Forms.TabPage
  Friend WithEvents Label83 As System.Windows.Forms.Label
  Friend WithEvents Label84 As System.Windows.Forms.Label
  Friend WithEvents Label85 As System.Windows.Forms.Label
  Friend WithEvents TxtTranBlock As System.Windows.Forms.TextBox
  Friend WithEvents TxtTranVol As System.Windows.Forms.TextBox
  Friend WithEvents TxtTranPage As System.Windows.Forms.TextBox
  Friend WithEvents TxtTranPrice As System.Windows.Forms.TextBox
  Friend WithEvents RbTranExempt As System.Windows.Forms.RadioButton
  Friend WithEvents DtPckTran As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtTranZip4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtTranCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtTranState As System.Windows.Forms.TextBox
  Friend WithEvents TxtTranAdd2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtTranAdd1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtTranSname As System.Windows.Forms.TextBox
  Friend WithEvents TxtTranZip5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtTranName As System.Windows.Forms.TextBox
  Friend WithEvents TxtTranTract As System.Windows.Forms.TextBox
  Friend WithEvents ChkTranEld As System.Windows.Forms.CheckBox
  Friend WithEvents ChkTranExempt As System.Windows.Forms.CheckBox
  Friend WithEvents TxtPZCard As System.Windows.Forms.TextBox
  Friend WithEvents TxtPZLot As System.Windows.Forms.TextBox
  Friend WithEvents TxtPZMap As System.Windows.Forms.TextBox
  Friend WithEvents TxtPZNon As System.Windows.Forms.TextBox
  Friend WithEvents TxtPZZoning As System.Windows.Forms.TextBox
  Friend WithEvents TxtPZGrossAcre As System.Windows.Forms.TextBox
  Friend WithEvents TxtActAcres As System.Windows.Forms.TextBox
  Friend WithEvents DtPckActInit As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckActExpir As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtPZBldAcre As System.Windows.Forms.TextBox
  Friend WithEvents TxtPZBed As System.Windows.Forms.TextBox
  Friend WithEvents TxtPZSewphs As System.Windows.Forms.TextBox
  Friend WithEvents TxtPZBath As System.Windows.Forms.TextBox
  Friend WithEvents ChkPZSeptic As System.Windows.Forms.CheckBox
  Friend WithEvents RbTranTaxable As System.Windows.Forms.RadioButton
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents LnkCode7 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCode7 As System.Windows.Forms.TextBox
  Friend WithEvents LnkCode5 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCode5 As System.Windows.Forms.TextBox
  Friend WithEvents LnkCode3 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCode3 As System.Windows.Forms.TextBox
  Friend WithEvents LnkCode1 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCode1 As System.Windows.Forms.TextBox
  Friend WithEvents LnkCode6 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCode6 As System.Windows.Forms.TextBox
  Friend WithEvents LnkCode4 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCode4 As System.Windows.Forms.TextBox
  Friend WithEvents LnkCode2 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCode2 As System.Windows.Forms.TextBox
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
  Friend WithEvents LnkExempt7 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtExempt7 As System.Windows.Forms.TextBox
  Friend WithEvents LnkExempt6 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtExempt6 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExemptCd As System.Windows.Forms.TextBox
  Friend WithEvents LnkExemptCd As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtTranExemptCd As System.Windows.Forms.TextBox
  Friend WithEvents LnkTranExemptCd As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkBankCd As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtBankCd As System.Windows.Forms.TextBox
  Friend WithEvents LblAcctn As System.Windows.Forms.Label
  Friend WithEvents LblBaaNet As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TpMain = New System.Windows.Forms.TabPage()
    Me.LblSunit = New System.Windows.Forms.Label()
    Me.ChkNoCama = New System.Windows.Forms.CheckBox()
    Me.LblAcctn = New System.Windows.Forms.Label()
    Me.TxtBankCd = New System.Windows.Forms.TextBox()
    Me.LnkBankCd = New System.Windows.Forms.LinkLabel()
    Me.TxtPurPrice = New System.Windows.Forms.TextBox()
    Me.TxtCensus = New System.Windows.Forms.TextBox()
    Me.TxtVol = New System.Windows.Forms.TextBox()
    Me.Label37 = New System.Windows.Forms.Label()
    Me.DtPckPurDate = New System.Windows.Forms.DateTimePicker()
    Me.TxtPage = New System.Windows.Forms.TextBox()
    Me.Label36 = New System.Windows.Forms.Label()
    Me.Label35 = New System.Windows.Forms.Label()
    Me.Label33 = New System.Windows.Forms.Label()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.LnkExemptCd = New System.Windows.Forms.LinkLabel()
    Me.TxtExemptCd = New System.Windows.Forms.TextBox()
    Me.RbCatExempt = New System.Windows.Forms.RadioButton()
    Me.RbCatTaxable = New System.Windows.Forms.RadioButton()
    Me.Label27 = New System.Windows.Forms.Label()
    Me.LblSunitHdr = New System.Windows.Forms.Label()
    Me.TxtVetYear = New System.Windows.Forms.TextBox()
    Me.Label26 = New System.Windows.Forms.Label()
    Me.ChkTaxCard = New System.Windows.Forms.CheckBox()
    Me.TxtSmap = New System.Windows.Forms.TextBox()
    Me.TxtMap = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.DtPckBtr = New System.Windows.Forms.DateTimePicker()
    Me.ChkDnbtr = New System.Windows.Forms.CheckBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
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
    Me.Label39 = New System.Windows.Forms.Label()
    Me.TxtAcre6 = New System.Windows.Forms.TextBox()
    Me.TxtAcre4 = New System.Windows.Forms.TextBox()
    Me.TxtAcre2 = New System.Windows.Forms.TextBox()
    Me.TxtAcre7 = New System.Windows.Forms.TextBox()
    Me.TxtAcre5 = New System.Windows.Forms.TextBox()
    Me.TxtAcre3 = New System.Windows.Forms.TextBox()
    Me.Label38 = New System.Windows.Forms.Label()
    Me.TxtAcre1 = New System.Windows.Forms.TextBox()
    Me.TxtBaa7 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt7 = New System.Windows.Forms.TextBox()
    Me.TxtUnit7 = New System.Windows.Forms.TextBox()
    Me.TxtBaa6 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt6 = New System.Windows.Forms.TextBox()
    Me.TxtUnit6 = New System.Windows.Forms.TextBox()
    Me.TxtBaa4 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt4 = New System.Windows.Forms.TextBox()
    Me.TxtUnit4 = New System.Windows.Forms.TextBox()
    Me.TxtBaa5 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt5 = New System.Windows.Forms.TextBox()
    Me.TxtUnit5 = New System.Windows.Forms.TextBox()
    Me.TxtBaa3 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt3 = New System.Windows.Forms.TextBox()
    Me.TxtUnit3 = New System.Windows.Forms.TextBox()
    Me.LblBTR2 = New System.Windows.Forms.Label()
    Me.TxtBaa2 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt2 = New System.Windows.Forms.TextBox()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.TxtUnit2 = New System.Windows.Forms.TextBox()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.LblBTR1 = New System.Windows.Forms.Label()
    Me.TxtBaa1 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt1 = New System.Windows.Forms.TextBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.TxtUnit1 = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.LblDtPckBTR = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.Label42 = New System.Windows.Forms.Label()
    Me.Label40 = New System.Windows.Forms.Label()
    Me.TxtOid = New System.Windows.Forms.TextBox()
    Me.TxtPdst = New System.Windows.Forms.TextBox()
    Me.TxtLoc = New System.Windows.Forms.TextBox()
    Me.TxtLocNo = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtUnit = New System.Windows.Forms.TextBox()
    Me.TpEld = New System.Windows.Forms.TabPage()
    Me.GroupBox7 = New System.Windows.Forms.GroupBox()
    Me.LnkLocAmt = New System.Windows.Forms.LinkLabel()
    Me.LblLocAmt = New System.Windows.Forms.Label()
    Me.Label74 = New System.Windows.Forms.Label()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.TxtEldYear = New System.Windows.Forms.TextBox()
    Me.LblEldPgm = New System.Windows.Forms.Label()
    Me.LblEldAdj = New System.Windows.Forms.Label()
    Me.LblEldTax = New System.Windows.Forms.Label()
    Me.LblEldMin = New System.Windows.Forms.Label()
    Me.LblEldMax = New System.Windows.Forms.Label()
    Me.LblEldPerc = New System.Windows.Forms.Label()
    Me.Label31 = New System.Windows.Forms.Label()
    Me.Label60 = New System.Windows.Forms.Label()
    Me.Label95 = New System.Windows.Forms.Label()
    Me.Label58 = New System.Windows.Forms.Label()
    Me.Label57 = New System.Windows.Forms.Label()
    Me.Label55 = New System.Windows.Forms.Label()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
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
    Me.TpTran = New System.Windows.Forms.TabPage()
    Me.TxtTranMap = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.ChkTranExempt = New System.Windows.Forms.CheckBox()
    Me.ChkTranEld = New System.Windows.Forms.CheckBox()
    Me.TxtTranTract = New System.Windows.Forms.TextBox()
    Me.Label75 = New System.Windows.Forms.Label()
    Me.TxtTranBlock = New System.Windows.Forms.TextBox()
    Me.TxtTranVol = New System.Windows.Forms.TextBox()
    Me.TxtTranPage = New System.Windows.Forms.TextBox()
    Me.Label70 = New System.Windows.Forms.Label()
    Me.Label71 = New System.Windows.Forms.Label()
    Me.TxtTranPrice = New System.Windows.Forms.TextBox()
    Me.Label68 = New System.Windows.Forms.Label()
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.LnkTranExemptCd = New System.Windows.Forms.LinkLabel()
    Me.TxtTranExemptCd = New System.Windows.Forms.TextBox()
    Me.RbTranExempt = New System.Windows.Forms.RadioButton()
    Me.RbTranTaxable = New System.Windows.Forms.RadioButton()
    Me.DtPckTran = New System.Windows.Forms.DateTimePicker()
    Me.Label64 = New System.Windows.Forms.Label()
    Me.TxtTranZip4 = New System.Windows.Forms.TextBox()
    Me.TxtTranCity = New System.Windows.Forms.TextBox()
    Me.TxtTranState = New System.Windows.Forms.TextBox()
    Me.TxtTranAdd2 = New System.Windows.Forms.TextBox()
    Me.TxtTranAdd1 = New System.Windows.Forms.TextBox()
    Me.TxtTranSname = New System.Windows.Forms.TextBox()
    Me.TxtTranZip5 = New System.Windows.Forms.TextBox()
    Me.TxtTranName = New System.Windows.Forms.TextBox()
    Me.Label41 = New System.Windows.Forms.Label()
    Me.Label61 = New System.Windows.Forms.Label()
    Me.Label62 = New System.Windows.Forms.Label()
    Me.Label63 = New System.Windows.Forms.Label()
    Me.TpPz = New System.Windows.Forms.TabPage()
    Me.ChkPZSeptic = New System.Windows.Forms.CheckBox()
    Me.TxtPZBath = New System.Windows.Forms.TextBox()
    Me.Label82 = New System.Windows.Forms.Label()
    Me.TxtPZSewphs = New System.Windows.Forms.TextBox()
    Me.Label81 = New System.Windows.Forms.Label()
    Me.TxtPZBed = New System.Windows.Forms.TextBox()
    Me.Label80 = New System.Windows.Forms.Label()
    Me.TxtPZBldAcre = New System.Windows.Forms.TextBox()
    Me.Label79 = New System.Windows.Forms.Label()
    Me.TxtPZGrossAcre = New System.Windows.Forms.TextBox()
    Me.Label78 = New System.Windows.Forms.Label()
    Me.TxtPZZoning = New System.Windows.Forms.TextBox()
    Me.Label77 = New System.Windows.Forms.Label()
    Me.TxtPZNon = New System.Windows.Forms.TextBox()
    Me.Label76 = New System.Windows.Forms.Label()
    Me.TxtPZCard = New System.Windows.Forms.TextBox()
    Me.Label67 = New System.Windows.Forms.Label()
    Me.TxtPZLot = New System.Windows.Forms.TextBox()
    Me.Label66 = New System.Windows.Forms.Label()
    Me.TxtPZMap = New System.Windows.Forms.TextBox()
    Me.Label65 = New System.Windows.Forms.Label()
    Me.TpAct490 = New System.Windows.Forms.TabPage()
    Me.DtPckActExpir = New System.Windows.Forms.DateTimePicker()
    Me.Label85 = New System.Windows.Forms.Label()
    Me.DtPckActInit = New System.Windows.Forms.DateTimePicker()
    Me.Label84 = New System.Windows.Forms.Label()
    Me.TxtActAcres = New System.Windows.Forms.TextBox()
    Me.Label83 = New System.Windows.Forms.Label()
    Me.TpPhaseIn = New System.Windows.Forms.TabPage()
    Me.LblNoPhaseIn = New System.Windows.Forms.Label()
    Me.GroupBox8 = New System.Windows.Forms.GroupBox()
    Me.LblCurrGross = New System.Windows.Forms.Label()
    Me.LblCurrAssmnt7 = New System.Windows.Forms.Label()
    Me.LblCurrAssmnt6 = New System.Windows.Forms.Label()
    Me.LblCurrAssmnt5 = New System.Windows.Forms.Label()
    Me.LblCurrAssmnt4 = New System.Windows.Forms.Label()
    Me.LblCurrAssmnt3 = New System.Windows.Forms.Label()
    Me.LblCurrAssmnt2 = New System.Windows.Forms.Label()
    Me.Label53 = New System.Windows.Forms.Label()
    Me.LblCurrAssmnt1 = New System.Windows.Forms.Label()
    Me.Label32 = New System.Windows.Forms.Label()
    Me.LblOrigGross = New System.Windows.Forms.Label()
    Me.LblPhaseGross = New System.Windows.Forms.Label()
    Me.LblFullGross = New System.Windows.Forms.Label()
    Me.LblAdjGross = New System.Windows.Forms.Label()
    Me.LblPhaseAssmnt7 = New System.Windows.Forms.Label()
    Me.LblPhaseCode7 = New System.Windows.Forms.Label()
    Me.LblTotAssmnt7 = New System.Windows.Forms.Label()
    Me.LblPhaseAssmnt6 = New System.Windows.Forms.Label()
    Me.LblPhaseCode6 = New System.Windows.Forms.Label()
    Me.LblTotAssmnt6 = New System.Windows.Forms.Label()
    Me.LblPhaseAssmnt5 = New System.Windows.Forms.Label()
    Me.LblPhaseCode5 = New System.Windows.Forms.Label()
    Me.LblTotAssmnt5 = New System.Windows.Forms.Label()
    Me.LblPhaseAssmnt4 = New System.Windows.Forms.Label()
    Me.LblPhaseCode4 = New System.Windows.Forms.Label()
    Me.LblTotAssmnt4 = New System.Windows.Forms.Label()
    Me.LblPhaseAssmnt3 = New System.Windows.Forms.Label()
    Me.LblPhaseCode3 = New System.Windows.Forms.Label()
    Me.LblTotAssmnt3 = New System.Windows.Forms.Label()
    Me.LblPhaseAssmnt2 = New System.Windows.Forms.Label()
    Me.LblPhaseCode2 = New System.Windows.Forms.Label()
    Me.LblTotAssmnt2 = New System.Windows.Forms.Label()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.LblPhaseAssmnt1 = New System.Windows.Forms.Label()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.LblPhaseCode1 = New System.Windows.Forms.Label()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.LblTotAssmnt1 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.LblBaaNet = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.LblNet = New System.Windows.Forms.Label()
    Me.Label34 = New System.Windows.Forms.Label()
    Me.LblExempt = New System.Windows.Forms.Label()
    Me.LblGross = New System.Windows.Forms.Label()
    Me.LblBaa = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.Label28 = New System.Windows.Forms.Label()
    Me.TxtZip4 = New System.Windows.Forms.TextBox()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtAdd2 = New System.Windows.Forms.TextBox()
    Me.TxtAdd1 = New System.Windows.Forms.TextBox()
    Me.TxtSname = New System.Windows.Forms.TextBox()
    Me.TxtZip5 = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LblSoftFreeze = New System.Windows.Forms.Label()
    Me.LblElderly = New System.Windows.Forms.Label()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.BtnPrevious = New System.Windows.Forms.Button()
    Me.LblLocalBen = New System.Windows.Forms.Label()
    Me.LblComments = New System.Windows.Forms.Label()
    Me.LblTaxExempt = New System.Windows.Forms.Label()
    Me.LblSewer = New System.Windows.Forms.Label()
    Me.LblBeforeCC = New System.Windows.Forms.Label()
    Me.LblAdjCode7 = New System.Windows.Forms.Label()
    Me.LblAdjCode6 = New System.Windows.Forms.Label()
    Me.LblAdjCode5 = New System.Windows.Forms.Label()
    Me.LblAdjCode4 = New System.Windows.Forms.Label()
    Me.LblAdjCode3 = New System.Windows.Forms.Label()
    Me.LblAdjCode2 = New System.Windows.Forms.Label()
    Me.Label48 = New System.Windows.Forms.Label()
    Me.LblAdjCode1 = New System.Windows.Forms.Label()
    Me.LblAdjAssmnt7 = New System.Windows.Forms.Label()
    Me.LblAdjAssmnt6 = New System.Windows.Forms.Label()
    Me.LblAdjAssmnt5 = New System.Windows.Forms.Label()
    Me.LblAdjAssmnt4 = New System.Windows.Forms.Label()
    Me.LblAdjAssmnt3 = New System.Windows.Forms.Label()
    Me.LblAdjAssmnt2 = New System.Windows.Forms.Label()
    Me.LblAdjAssmnt1 = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.LblTot = New System.Windows.Forms.Label()
    Me.Label22 = New System.Windows.Forms.Label()
    Me.TabControl1.SuspendLayout()
    Me.TpMain.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.TpEld.SuspendLayout()
    Me.GroupBox7.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.TpTran.SuspendLayout()
    Me.GroupBox6.SuspendLayout()
    Me.TpPz.SuspendLayout()
    Me.TpAct490.SuspendLayout()
    Me.TpPhaseIn.SuspendLayout()
    Me.GroupBox8.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons
    Me.TabControl1.Controls.Add(Me.TpMain)
    Me.TabControl1.Controls.Add(Me.TpEld)
    Me.TabControl1.Controls.Add(Me.TpTran)
    Me.TabControl1.Controls.Add(Me.TpPz)
    Me.TabControl1.Controls.Add(Me.TpAct490)
    Me.TabControl1.Controls.Add(Me.TpPhaseIn)
    Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TabControl1.Location = New System.Drawing.Point(0, 152)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(736, 360)
    Me.TabControl1.TabIndex = 9
    '
    'TpMain
    '
    Me.TpMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.TpMain.Controls.Add(Me.LblSunit)
    Me.TpMain.Controls.Add(Me.ChkNoCama)
    Me.TpMain.Controls.Add(Me.LblAcctn)
    Me.TpMain.Controls.Add(Me.TxtBankCd)
    Me.TpMain.Controls.Add(Me.LnkBankCd)
    Me.TpMain.Controls.Add(Me.TxtPurPrice)
    Me.TpMain.Controls.Add(Me.TxtCensus)
    Me.TpMain.Controls.Add(Me.TxtVol)
    Me.TpMain.Controls.Add(Me.Label37)
    Me.TpMain.Controls.Add(Me.DtPckPurDate)
    Me.TpMain.Controls.Add(Me.TxtPage)
    Me.TpMain.Controls.Add(Me.Label36)
    Me.TpMain.Controls.Add(Me.Label35)
    Me.TpMain.Controls.Add(Me.Label33)
    Me.TpMain.Controls.Add(Me.GroupBox3)
    Me.TpMain.Controls.Add(Me.Label27)
    Me.TpMain.Controls.Add(Me.LblSunitHdr)
    Me.TpMain.Controls.Add(Me.TxtVetYear)
    Me.TpMain.Controls.Add(Me.Label26)
    Me.TpMain.Controls.Add(Me.ChkTaxCard)
    Me.TpMain.Controls.Add(Me.TxtSmap)
    Me.TpMain.Controls.Add(Me.TxtMap)
    Me.TpMain.Controls.Add(Me.Label8)
    Me.TpMain.Controls.Add(Me.Label7)
    Me.TpMain.Controls.Add(Me.DtPckBtr)
    Me.TpMain.Controls.Add(Me.ChkDnbtr)
    Me.TpMain.Controls.Add(Me.GroupBox1)
    Me.TpMain.Controls.Add(Me.Label9)
    Me.TpMain.Controls.Add(Me.LblDtPckBTR)
    Me.TpMain.Controls.Add(Me.TxtDist)
    Me.TpMain.Controls.Add(Me.Label42)
    Me.TpMain.Controls.Add(Me.Label40)
    Me.TpMain.Controls.Add(Me.TxtOid)
    Me.TpMain.Controls.Add(Me.TxtPdst)
    Me.TpMain.Controls.Add(Me.TxtLoc)
    Me.TpMain.Controls.Add(Me.TxtLocNo)
    Me.TpMain.Controls.Add(Me.Label6)
    Me.TpMain.Controls.Add(Me.TxtUnit)
    Me.TpMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TpMain.Location = New System.Drawing.Point(4, 25)
    Me.TpMain.Name = "TpMain"
    Me.TpMain.Size = New System.Drawing.Size(728, 331)
    Me.TpMain.TabIndex = 0
    Me.TpMain.Text = "Main"
    Me.TpMain.UseVisualStyleBackColor = True
    '
    'LblSunit
    '
    Me.LblSunit.BackColor = System.Drawing.Color.Aqua
    Me.LblSunit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblSunit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblSunit.Location = New System.Drawing.Point(429, 117)
    Me.LblSunit.Name = "LblSunit"
    Me.LblSunit.Size = New System.Drawing.Size(56, 18)
    Me.LblSunit.TabIndex = 163
    Me.LblSunit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.LblSunit.Visible = False
    '
    'ChkNoCama
    '
    Me.ChkNoCama.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkNoCama.Location = New System.Drawing.Point(531, 164)
    Me.ChkNoCama.Name = "ChkNoCama"
    Me.ChkNoCama.Size = New System.Drawing.Size(150, 18)
    Me.ChkNoCama.TabIndex = 162
    Me.ChkNoCama.Text = "Omit from CAMA Bridge?"
    '
    'LblAcctn
    '
    Me.LblAcctn.Location = New System.Drawing.Point(120, 136)
    Me.LblAcctn.Name = "LblAcctn"
    Me.LblAcctn.Size = New System.Drawing.Size(72, 16)
    Me.LblAcctn.TabIndex = 161
    '
    'TxtBankCd
    '
    Me.TxtBankCd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBankCd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBankCd.Location = New System.Drawing.Point(96, 136)
    Me.TxtBankCd.MaxLength = 2
    Me.TxtBankCd.Name = "TxtBankCd"
    Me.TxtBankCd.Size = New System.Drawing.Size(24, 22)
    Me.TxtBankCd.TabIndex = 16
    Me.TxtBankCd.Visible = False
    '
    'LnkBankCd
    '
    Me.LnkBankCd.Location = New System.Drawing.Point(8, 136)
    Me.LnkBankCd.Name = "LnkBankCd"
    Me.LnkBankCd.Size = New System.Drawing.Size(80, 16)
    Me.LnkBankCd.TabIndex = 160
    Me.LnkBankCd.TabStop = True
    Me.LnkBankCd.Text = "Escrow Bank"
    Me.LnkBankCd.Visible = False
    '
    'TxtPurPrice
    '
    Me.TxtPurPrice.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPurPrice.Location = New System.Drawing.Point(618, 112)
    Me.TxtPurPrice.MaxLength = 9
    Me.TxtPurPrice.Name = "TxtPurPrice"
    Me.TxtPurPrice.Size = New System.Drawing.Size(80, 22)
    Me.TxtPurPrice.TabIndex = 15
    Me.TxtPurPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtCensus
    '
    Me.TxtCensus.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCensus.Location = New System.Drawing.Point(96, 104)
    Me.TxtCensus.MaxLength = 7
    Me.TxtCensus.Name = "TxtCensus"
    Me.TxtCensus.Size = New System.Drawing.Size(64, 22)
    Me.TxtCensus.TabIndex = 13
    Me.TxtCensus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtVol
    '
    Me.TxtVol.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVol.Location = New System.Drawing.Point(618, 88)
    Me.TxtVol.MaxLength = 5
    Me.TxtVol.Name = "TxtVol"
    Me.TxtVol.Size = New System.Drawing.Size(48, 22)
    Me.TxtVol.TabIndex = 11
    Me.TxtVol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label37
    '
    Me.Label37.Location = New System.Drawing.Point(389, 35)
    Me.Label37.Name = "Label37"
    Me.Label37.Size = New System.Drawing.Size(32, 16)
    Me.Label37.TabIndex = 159
    Me.Label37.Text = "Unit"
    '
    'DtPckPurDate
    '
    Me.DtPckPurDate.Checked = False
    Me.DtPckPurDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckPurDate.Location = New System.Drawing.Point(618, 136)
    Me.DtPckPurDate.Name = "DtPckPurDate"
    Me.DtPckPurDate.ShowCheckBox = True
    Me.DtPckPurDate.Size = New System.Drawing.Size(96, 20)
    Me.DtPckPurDate.TabIndex = 17
    '
    'TxtPage
    '
    Me.TxtPage.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPage.Location = New System.Drawing.Point(672, 88)
    Me.TxtPage.MaxLength = 5
    Me.TxtPage.Name = "TxtPage"
    Me.TxtPage.Size = New System.Drawing.Size(48, 22)
    Me.TxtPage.TabIndex = 12
    Me.TxtPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label36
    '
    Me.Label36.Location = New System.Drawing.Point(528, 136)
    Me.Label36.Name = "Label36"
    Me.Label36.Size = New System.Drawing.Size(88, 16)
    Me.Label36.TabIndex = 157
    Me.Label36.Text = "Purchase Date"
    '
    'Label35
    '
    Me.Label35.Location = New System.Drawing.Point(528, 112)
    Me.Label35.Name = "Label35"
    Me.Label35.Size = New System.Drawing.Size(88, 16)
    Me.Label35.TabIndex = 156
    Me.Label35.Text = "Purchase Price"
    '
    'Label33
    '
    Me.Label33.Location = New System.Drawing.Point(528, 88)
    Me.Label33.Name = "Label33"
    Me.Label33.Size = New System.Drawing.Size(88, 16)
    Me.Label33.TabIndex = 152
    Me.Label33.Text = "Vol/Page"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.LnkExemptCd)
    Me.GroupBox3.Controls.Add(Me.TxtExemptCd)
    Me.GroupBox3.Controls.Add(Me.RbCatExempt)
    Me.GroupBox3.Controls.Add(Me.RbCatTaxable)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox3.Location = New System.Drawing.Point(536, 8)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(160, 64)
    Me.GroupBox3.TabIndex = 151
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Category"
    '
    'LnkExemptCd
    '
    Me.LnkExemptCd.Location = New System.Drawing.Point(8, 40)
    Me.LnkExemptCd.Name = "LnkExemptCd"
    Me.LnkExemptCd.Size = New System.Drawing.Size(80, 16)
    Me.LnkExemptCd.TabIndex = 99
    Me.LnkExemptCd.TabStop = True
    Me.LnkExemptCd.Text = "Exempt Code"
    '
    'TxtExemptCd
    '
    Me.TxtExemptCd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExemptCd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExemptCd.Location = New System.Drawing.Point(88, 40)
    Me.TxtExemptCd.MaxLength = 4
    Me.TxtExemptCd.Name = "TxtExemptCd"
    Me.TxtExemptCd.Size = New System.Drawing.Size(40, 22)
    Me.TxtExemptCd.TabIndex = 98
    '
    'RbCatExempt
    '
    Me.RbCatExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCatExempt.ForeColor = System.Drawing.Color.Black
    Me.RbCatExempt.Location = New System.Drawing.Point(88, 16)
    Me.RbCatExempt.Name = "RbCatExempt"
    Me.RbCatExempt.Size = New System.Drawing.Size(64, 24)
    Me.RbCatExempt.TabIndex = 1
    Me.RbCatExempt.Text = "Exempt"
    '
    'RbCatTaxable
    '
    Me.RbCatTaxable.Checked = True
    Me.RbCatTaxable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCatTaxable.ForeColor = System.Drawing.Color.Black
    Me.RbCatTaxable.Location = New System.Drawing.Point(8, 16)
    Me.RbCatTaxable.Name = "RbCatTaxable"
    Me.RbCatTaxable.Size = New System.Drawing.Size(64, 24)
    Me.RbCatTaxable.TabIndex = 0
    Me.RbCatTaxable.TabStop = True
    Me.RbCatTaxable.Text = "Taxable"
    '
    'Label27
    '
    Me.Label27.Location = New System.Drawing.Point(8, 104)
    Me.Label27.Name = "Label27"
    Me.Label27.Size = New System.Drawing.Size(72, 16)
    Me.Label27.TabIndex = 147
    Me.Label27.Text = "Census Tract"
    '
    'LblSunitHdr
    '
    Me.LblSunitHdr.Location = New System.Drawing.Point(349, 117)
    Me.LblSunitHdr.Name = "LblSunitHdr"
    Me.LblSunitHdr.Size = New System.Drawing.Size(72, 16)
    Me.LblSunitHdr.TabIndex = 143
    Me.LblSunitHdr.Text = "Sewer Units"
    Me.LblSunitHdr.Visible = False
    '
    'TxtVetYear
    '
    Me.TxtVetYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVetYear.Location = New System.Drawing.Point(429, 88)
    Me.TxtVetYear.MaxLength = 4
    Me.TxtVetYear.Name = "TxtVetYear"
    Me.TxtVetYear.Size = New System.Drawing.Size(43, 22)
    Me.TxtVetYear.TabIndex = 14
    Me.TxtVetYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label26
    '
    Me.Label26.Location = New System.Drawing.Point(349, 88)
    Me.Label26.Name = "Label26"
    Me.Label26.Size = New System.Drawing.Size(72, 16)
    Me.Label26.TabIndex = 145
    Me.Label26.Text = "Veteran Year"
    '
    'ChkTaxCard
    '
    Me.ChkTaxCard.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkTaxCard.Location = New System.Drawing.Point(8, 80)
    Me.ChkTaxCard.Name = "ChkTaxCard"
    Me.ChkTaxCard.Size = New System.Drawing.Size(104, 16)
    Me.ChkTaxCard.TabIndex = 8
    Me.ChkTaxCard.Text = "Tax Card?"
    '
    'TxtSmap
    '
    Me.TxtSmap.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSmap.Location = New System.Drawing.Point(429, 59)
    Me.TxtSmap.MaxLength = 8
    Me.TxtSmap.Name = "TxtSmap"
    Me.TxtSmap.Size = New System.Drawing.Size(72, 22)
    Me.TxtSmap.TabIndex = 7
    '
    'TxtMap
    '
    Me.TxtMap.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMap.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMap.Location = New System.Drawing.Point(96, 56)
    Me.TxtMap.MaxLength = 17
    Me.TxtMap.Name = "TxtMap"
    Me.TxtMap.Size = New System.Drawing.Size(144, 22)
    Me.TxtMap.TabIndex = 6
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(365, 59)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(56, 16)
    Me.Label8.TabIndex = 139
    Me.Label8.Text = "S. Map"
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(8, 56)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(88, 16)
    Me.Label7.TabIndex = 137
    Me.Label7.Text = "Map Block Lot"
    '
    'DtPckBtr
    '
    Me.DtPckBtr.Checked = False
    Me.DtPckBtr.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckBtr.Location = New System.Drawing.Point(96, 160)
    Me.DtPckBtr.Name = "DtPckBtr"
    Me.DtPckBtr.ShowCheckBox = True
    Me.DtPckBtr.Size = New System.Drawing.Size(96, 20)
    Me.DtPckBtr.TabIndex = 18
    '
    'ChkDnbtr
    '
    Me.ChkDnbtr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkDnbtr.Location = New System.Drawing.Point(200, 160)
    Me.ChkDnbtr.Name = "ChkDnbtr"
    Me.ChkDnbtr.Size = New System.Drawing.Size(72, 16)
    Me.ChkDnbtr.TabIndex = 19
    Me.ChkDnbtr.Text = "Denied?"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LnkCode6)
    Me.GroupBox1.Controls.Add(Me.TxtCode6)
    Me.GroupBox1.Controls.Add(Me.LnkCode4)
    Me.GroupBox1.Controls.Add(Me.TxtCode4)
    Me.GroupBox1.Controls.Add(Me.LnkCode2)
    Me.GroupBox1.Controls.Add(Me.TxtCode2)
    Me.GroupBox1.Controls.Add(Me.LnkCode7)
    Me.GroupBox1.Controls.Add(Me.TxtCode7)
    Me.GroupBox1.Controls.Add(Me.LnkCode5)
    Me.GroupBox1.Controls.Add(Me.TxtCode5)
    Me.GroupBox1.Controls.Add(Me.LnkCode3)
    Me.GroupBox1.Controls.Add(Me.TxtCode3)
    Me.GroupBox1.Controls.Add(Me.LnkCode1)
    Me.GroupBox1.Controls.Add(Me.TxtCode1)
    Me.GroupBox1.Controls.Add(Me.Label39)
    Me.GroupBox1.Controls.Add(Me.TxtAcre6)
    Me.GroupBox1.Controls.Add(Me.TxtAcre4)
    Me.GroupBox1.Controls.Add(Me.TxtAcre2)
    Me.GroupBox1.Controls.Add(Me.TxtAcre7)
    Me.GroupBox1.Controls.Add(Me.TxtAcre5)
    Me.GroupBox1.Controls.Add(Me.TxtAcre3)
    Me.GroupBox1.Controls.Add(Me.Label38)
    Me.GroupBox1.Controls.Add(Me.TxtAcre1)
    Me.GroupBox1.Controls.Add(Me.TxtBaa7)
    Me.GroupBox1.Controls.Add(Me.TxtAssmt7)
    Me.GroupBox1.Controls.Add(Me.TxtUnit7)
    Me.GroupBox1.Controls.Add(Me.TxtBaa6)
    Me.GroupBox1.Controls.Add(Me.TxtAssmt6)
    Me.GroupBox1.Controls.Add(Me.TxtUnit6)
    Me.GroupBox1.Controls.Add(Me.TxtBaa4)
    Me.GroupBox1.Controls.Add(Me.TxtAssmt4)
    Me.GroupBox1.Controls.Add(Me.TxtUnit4)
    Me.GroupBox1.Controls.Add(Me.TxtBaa5)
    Me.GroupBox1.Controls.Add(Me.TxtAssmt5)
    Me.GroupBox1.Controls.Add(Me.TxtUnit5)
    Me.GroupBox1.Controls.Add(Me.TxtBaa3)
    Me.GroupBox1.Controls.Add(Me.TxtAssmt3)
    Me.GroupBox1.Controls.Add(Me.TxtUnit3)
    Me.GroupBox1.Controls.Add(Me.LblBTR2)
    Me.GroupBox1.Controls.Add(Me.TxtBaa2)
    Me.GroupBox1.Controls.Add(Me.TxtAssmt2)
    Me.GroupBox1.Controls.Add(Me.Label20)
    Me.GroupBox1.Controls.Add(Me.Label21)
    Me.GroupBox1.Controls.Add(Me.TxtUnit2)
    Me.GroupBox1.Controls.Add(Me.Label23)
    Me.GroupBox1.Controls.Add(Me.LblBTR1)
    Me.GroupBox1.Controls.Add(Me.TxtBaa1)
    Me.GroupBox1.Controls.Add(Me.TxtAssmt1)
    Me.GroupBox1.Controls.Add(Me.Label17)
    Me.GroupBox1.Controls.Add(Me.Label16)
    Me.GroupBox1.Controls.Add(Me.TxtUnit1)
    Me.GroupBox1.Controls.Add(Me.Label10)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox1.Location = New System.Drawing.Point(0, 200)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(728, 128)
    Me.GroupBox1.TabIndex = 20
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Assessment Property Codes"
    '
    'LnkCode6
    '
    Me.LnkCode6.Location = New System.Drawing.Point(365, 84)
    Me.LnkCode6.Name = "LnkCode6"
    Me.LnkCode6.Size = New System.Drawing.Size(24, 16)
    Me.LnkCode6.TabIndex = 180
    Me.LnkCode6.TabStop = True
    Me.LnkCode6.Text = "6"
    Me.LnkCode6.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'TxtCode6
    '
    Me.TxtCode6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode6.Location = New System.Drawing.Point(392, 80)
    Me.TxtCode6.MaxLength = 3
    Me.TxtCode6.Name = "TxtCode6"
    Me.TxtCode6.Size = New System.Drawing.Size(32, 22)
    Me.TxtCode6.TabIndex = 25
    '
    'LnkCode4
    '
    Me.LnkCode4.Location = New System.Drawing.Point(365, 60)
    Me.LnkCode4.Name = "LnkCode4"
    Me.LnkCode4.Size = New System.Drawing.Size(24, 16)
    Me.LnkCode4.TabIndex = 179
    Me.LnkCode4.TabStop = True
    Me.LnkCode4.Text = "4"
    Me.LnkCode4.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'TxtCode4
    '
    Me.TxtCode4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode4.Location = New System.Drawing.Point(392, 56)
    Me.TxtCode4.MaxLength = 3
    Me.TxtCode4.Name = "TxtCode4"
    Me.TxtCode4.Size = New System.Drawing.Size(32, 22)
    Me.TxtCode4.TabIndex = 15
    '
    'LnkCode2
    '
    Me.LnkCode2.Location = New System.Drawing.Point(365, 36)
    Me.LnkCode2.Name = "LnkCode2"
    Me.LnkCode2.Size = New System.Drawing.Size(24, 16)
    Me.LnkCode2.TabIndex = 178
    Me.LnkCode2.TabStop = True
    Me.LnkCode2.Text = "2"
    Me.LnkCode2.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'TxtCode2
    '
    Me.TxtCode2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode2.Location = New System.Drawing.Point(392, 32)
    Me.TxtCode2.MaxLength = 3
    Me.TxtCode2.Name = "TxtCode2"
    Me.TxtCode2.Size = New System.Drawing.Size(32, 22)
    Me.TxtCode2.TabIndex = 5
    '
    'LnkCode7
    '
    Me.LnkCode7.Location = New System.Drawing.Point(5, 108)
    Me.LnkCode7.Name = "LnkCode7"
    Me.LnkCode7.Size = New System.Drawing.Size(24, 16)
    Me.LnkCode7.TabIndex = 174
    Me.LnkCode7.TabStop = True
    Me.LnkCode7.Text = "7"
    Me.LnkCode7.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'TxtCode7
    '
    Me.TxtCode7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode7.Location = New System.Drawing.Point(32, 104)
    Me.TxtCode7.MaxLength = 3
    Me.TxtCode7.Name = "TxtCode7"
    Me.TxtCode7.Size = New System.Drawing.Size(32, 22)
    Me.TxtCode7.TabIndex = 30
    '
    'LnkCode5
    '
    Me.LnkCode5.Location = New System.Drawing.Point(5, 84)
    Me.LnkCode5.Name = "LnkCode5"
    Me.LnkCode5.Size = New System.Drawing.Size(24, 16)
    Me.LnkCode5.TabIndex = 173
    Me.LnkCode5.TabStop = True
    Me.LnkCode5.Text = "5"
    Me.LnkCode5.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'TxtCode5
    '
    Me.TxtCode5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode5.Location = New System.Drawing.Point(32, 80)
    Me.TxtCode5.MaxLength = 3
    Me.TxtCode5.Name = "TxtCode5"
    Me.TxtCode5.Size = New System.Drawing.Size(32, 22)
    Me.TxtCode5.TabIndex = 20
    '
    'LnkCode3
    '
    Me.LnkCode3.Location = New System.Drawing.Point(5, 60)
    Me.LnkCode3.Name = "LnkCode3"
    Me.LnkCode3.Size = New System.Drawing.Size(24, 16)
    Me.LnkCode3.TabIndex = 172
    Me.LnkCode3.TabStop = True
    Me.LnkCode3.Text = "3"
    Me.LnkCode3.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'TxtCode3
    '
    Me.TxtCode3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode3.Location = New System.Drawing.Point(32, 56)
    Me.TxtCode3.MaxLength = 3
    Me.TxtCode3.Name = "TxtCode3"
    Me.TxtCode3.Size = New System.Drawing.Size(32, 22)
    Me.TxtCode3.TabIndex = 10
    '
    'LnkCode1
    '
    Me.LnkCode1.Location = New System.Drawing.Point(5, 36)
    Me.LnkCode1.Name = "LnkCode1"
    Me.LnkCode1.Size = New System.Drawing.Size(24, 16)
    Me.LnkCode1.TabIndex = 171
    Me.LnkCode1.TabStop = True
    Me.LnkCode1.Text = "1"
    Me.LnkCode1.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'TxtCode1
    '
    Me.TxtCode1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode1.Location = New System.Drawing.Point(32, 32)
    Me.TxtCode1.MaxLength = 3
    Me.TxtCode1.Name = "TxtCode1"
    Me.TxtCode1.Size = New System.Drawing.Size(32, 22)
    Me.TxtCode1.TabIndex = 0
    '
    'Label39
    '
    Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label39.ForeColor = System.Drawing.Color.Black
    Me.Label39.Location = New System.Drawing.Point(480, 16)
    Me.Label39.Name = "Label39"
    Me.Label39.Size = New System.Drawing.Size(48, 16)
    Me.Label39.TabIndex = 72
    Me.Label39.Text = "Acre"
    Me.Label39.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'TxtAcre6
    '
    Me.TxtAcre6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAcre6.Location = New System.Drawing.Point(464, 80)
    Me.TxtAcre6.MaxLength = 8
    Me.TxtAcre6.Name = "TxtAcre6"
    Me.TxtAcre6.Size = New System.Drawing.Size(75, 22)
    Me.TxtAcre6.TabIndex = 27
    Me.TxtAcre6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAcre4
    '
    Me.TxtAcre4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAcre4.Location = New System.Drawing.Point(464, 56)
    Me.TxtAcre4.MaxLength = 8
    Me.TxtAcre4.Name = "TxtAcre4"
    Me.TxtAcre4.Size = New System.Drawing.Size(75, 22)
    Me.TxtAcre4.TabIndex = 17
    Me.TxtAcre4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAcre2
    '
    Me.TxtAcre2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAcre2.Location = New System.Drawing.Point(464, 32)
    Me.TxtAcre2.MaxLength = 8
    Me.TxtAcre2.Name = "TxtAcre2"
    Me.TxtAcre2.Size = New System.Drawing.Size(75, 22)
    Me.TxtAcre2.TabIndex = 7
    Me.TxtAcre2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAcre7
    '
    Me.TxtAcre7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAcre7.Location = New System.Drawing.Point(104, 104)
    Me.TxtAcre7.MaxLength = 8
    Me.TxtAcre7.Name = "TxtAcre7"
    Me.TxtAcre7.Size = New System.Drawing.Size(75, 22)
    Me.TxtAcre7.TabIndex = 32
    Me.TxtAcre7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAcre5
    '
    Me.TxtAcre5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAcre5.Location = New System.Drawing.Point(104, 80)
    Me.TxtAcre5.MaxLength = 8
    Me.TxtAcre5.Name = "TxtAcre5"
    Me.TxtAcre5.Size = New System.Drawing.Size(75, 22)
    Me.TxtAcre5.TabIndex = 22
    Me.TxtAcre5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAcre3
    '
    Me.TxtAcre3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAcre3.Location = New System.Drawing.Point(104, 56)
    Me.TxtAcre3.MaxLength = 8
    Me.TxtAcre3.Name = "TxtAcre3"
    Me.TxtAcre3.Size = New System.Drawing.Size(75, 22)
    Me.TxtAcre3.TabIndex = 12
    Me.TxtAcre3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label38
    '
    Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label38.ForeColor = System.Drawing.Color.Black
    Me.Label38.Location = New System.Drawing.Point(139, 16)
    Me.Label38.Name = "Label38"
    Me.Label38.Size = New System.Drawing.Size(40, 16)
    Me.Label38.TabIndex = 65
    Me.Label38.Text = "Acre"
    Me.Label38.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'TxtAcre1
    '
    Me.TxtAcre1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAcre1.Location = New System.Drawing.Point(104, 32)
    Me.TxtAcre1.MaxLength = 8
    Me.TxtAcre1.Name = "TxtAcre1"
    Me.TxtAcre1.Size = New System.Drawing.Size(75, 22)
    Me.TxtAcre1.TabIndex = 2
    Me.TxtAcre1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtBaa7
    '
    Me.TxtBaa7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBaa7.Location = New System.Drawing.Point(271, 104)
    Me.TxtBaa7.MaxLength = 9
    Me.TxtBaa7.Name = "TxtBaa7"
    Me.TxtBaa7.Size = New System.Drawing.Size(80, 22)
    Me.TxtBaa7.TabIndex = 34
    Me.TxtBaa7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt7
    '
    Me.TxtAssmt7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt7.Location = New System.Drawing.Point(185, 104)
    Me.TxtAssmt7.MaxLength = 9
    Me.TxtAssmt7.Name = "TxtAssmt7"
    Me.TxtAssmt7.Size = New System.Drawing.Size(80, 22)
    Me.TxtAssmt7.TabIndex = 33
    Me.TxtAssmt7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit7
    '
    Me.TxtUnit7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit7.Location = New System.Drawing.Point(67, 104)
    Me.TxtUnit7.MaxLength = 3
    Me.TxtUnit7.Name = "TxtUnit7"
    Me.TxtUnit7.Size = New System.Drawing.Size(32, 22)
    Me.TxtUnit7.TabIndex = 31
    Me.TxtUnit7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtBaa6
    '
    Me.TxtBaa6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBaa6.Location = New System.Drawing.Point(632, 80)
    Me.TxtBaa6.MaxLength = 9
    Me.TxtBaa6.Name = "TxtBaa6"
    Me.TxtBaa6.Size = New System.Drawing.Size(80, 22)
    Me.TxtBaa6.TabIndex = 29
    Me.TxtBaa6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt6
    '
    Me.TxtAssmt6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt6.Location = New System.Drawing.Point(546, 80)
    Me.TxtAssmt6.MaxLength = 9
    Me.TxtAssmt6.Name = "TxtAssmt6"
    Me.TxtAssmt6.Size = New System.Drawing.Size(80, 22)
    Me.TxtAssmt6.TabIndex = 28
    Me.TxtAssmt6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit6
    '
    Me.TxtUnit6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit6.Location = New System.Drawing.Point(429, 80)
    Me.TxtUnit6.MaxLength = 6
    Me.TxtUnit6.Name = "TxtUnit6"
    Me.TxtUnit6.Size = New System.Drawing.Size(32, 22)
    Me.TxtUnit6.TabIndex = 26
    Me.TxtUnit6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtBaa4
    '
    Me.TxtBaa4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBaa4.Location = New System.Drawing.Point(632, 56)
    Me.TxtBaa4.MaxLength = 9
    Me.TxtBaa4.Name = "TxtBaa4"
    Me.TxtBaa4.Size = New System.Drawing.Size(80, 22)
    Me.TxtBaa4.TabIndex = 19
    Me.TxtBaa4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt4
    '
    Me.TxtAssmt4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt4.Location = New System.Drawing.Point(546, 56)
    Me.TxtAssmt4.MaxLength = 9
    Me.TxtAssmt4.Name = "TxtAssmt4"
    Me.TxtAssmt4.Size = New System.Drawing.Size(80, 22)
    Me.TxtAssmt4.TabIndex = 18
    Me.TxtAssmt4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit4
    '
    Me.TxtUnit4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit4.Location = New System.Drawing.Point(429, 56)
    Me.TxtUnit4.MaxLength = 6
    Me.TxtUnit4.Name = "TxtUnit4"
    Me.TxtUnit4.Size = New System.Drawing.Size(32, 22)
    Me.TxtUnit4.TabIndex = 16
    Me.TxtUnit4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtBaa5
    '
    Me.TxtBaa5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBaa5.Location = New System.Drawing.Point(271, 80)
    Me.TxtBaa5.MaxLength = 9
    Me.TxtBaa5.Name = "TxtBaa5"
    Me.TxtBaa5.Size = New System.Drawing.Size(80, 22)
    Me.TxtBaa5.TabIndex = 24
    Me.TxtBaa5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt5
    '
    Me.TxtAssmt5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt5.Location = New System.Drawing.Point(185, 80)
    Me.TxtAssmt5.MaxLength = 9
    Me.TxtAssmt5.Name = "TxtAssmt5"
    Me.TxtAssmt5.Size = New System.Drawing.Size(80, 22)
    Me.TxtAssmt5.TabIndex = 23
    Me.TxtAssmt5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit5
    '
    Me.TxtUnit5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit5.Location = New System.Drawing.Point(67, 80)
    Me.TxtUnit5.MaxLength = 3
    Me.TxtUnit5.Name = "TxtUnit5"
    Me.TxtUnit5.Size = New System.Drawing.Size(32, 22)
    Me.TxtUnit5.TabIndex = 21
    Me.TxtUnit5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtBaa3
    '
    Me.TxtBaa3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBaa3.Location = New System.Drawing.Point(271, 56)
    Me.TxtBaa3.MaxLength = 9
    Me.TxtBaa3.Name = "TxtBaa3"
    Me.TxtBaa3.Size = New System.Drawing.Size(80, 22)
    Me.TxtBaa3.TabIndex = 14
    Me.TxtBaa3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt3
    '
    Me.TxtAssmt3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt3.Location = New System.Drawing.Point(185, 56)
    Me.TxtAssmt3.MaxLength = 9
    Me.TxtAssmt3.Name = "TxtAssmt3"
    Me.TxtAssmt3.Size = New System.Drawing.Size(80, 22)
    Me.TxtAssmt3.TabIndex = 13
    Me.TxtAssmt3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit3
    '
    Me.TxtUnit3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit3.Location = New System.Drawing.Point(67, 56)
    Me.TxtUnit3.MaxLength = 3
    Me.TxtUnit3.Name = "TxtUnit3"
    Me.TxtUnit3.Size = New System.Drawing.Size(32, 22)
    Me.TxtUnit3.TabIndex = 11
    Me.TxtUnit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblBTR2
    '
    Me.LblBTR2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBTR2.ForeColor = System.Drawing.Color.Black
    Me.LblBTR2.Location = New System.Drawing.Point(632, 16)
    Me.LblBTR2.Name = "LblBTR2"
    Me.LblBTR2.Size = New System.Drawing.Size(72, 16)
    Me.LblBTR2.TabIndex = 45
    Me.LblBTR2.Text = "B.A.A Amt"
    Me.LblBTR2.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'TxtBaa2
    '
    Me.TxtBaa2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBaa2.Location = New System.Drawing.Point(632, 32)
    Me.TxtBaa2.MaxLength = 9
    Me.TxtBaa2.Name = "TxtBaa2"
    Me.TxtBaa2.Size = New System.Drawing.Size(80, 22)
    Me.TxtBaa2.TabIndex = 9
    Me.TxtBaa2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt2
    '
    Me.TxtAssmt2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt2.Location = New System.Drawing.Point(546, 32)
    Me.TxtAssmt2.MaxLength = 9
    Me.TxtAssmt2.Name = "TxtAssmt2"
    Me.TxtAssmt2.Size = New System.Drawing.Size(80, 22)
    Me.TxtAssmt2.TabIndex = 8
    Me.TxtAssmt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label20
    '
    Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label20.ForeColor = System.Drawing.Color.Black
    Me.Label20.Location = New System.Drawing.Point(546, 16)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(78, 13)
    Me.Label20.TabIndex = 42
    Me.Label20.Text = "Assessment"
    Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label21
    '
    Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label21.ForeColor = System.Drawing.Color.Black
    Me.Label21.Location = New System.Drawing.Point(430, 16)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(32, 16)
    Me.Label21.TabIndex = 41
    Me.Label21.Text = "Unit"
    Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'TxtUnit2
    '
    Me.TxtUnit2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit2.Location = New System.Drawing.Point(429, 32)
    Me.TxtUnit2.MaxLength = 6
    Me.TxtUnit2.Name = "TxtUnit2"
    Me.TxtUnit2.Size = New System.Drawing.Size(32, 22)
    Me.TxtUnit2.TabIndex = 6
    Me.TxtUnit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label23
    '
    Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label23.ForeColor = System.Drawing.Color.Black
    Me.Label23.Location = New System.Drawing.Point(384, 16)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(40, 16)
    Me.Label23.TabIndex = 37
    Me.Label23.Text = "Code"
    Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'LblBTR1
    '
    Me.LblBTR1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBTR1.ForeColor = System.Drawing.Color.Black
    Me.LblBTR1.Location = New System.Drawing.Point(279, 16)
    Me.LblBTR1.Name = "LblBTR1"
    Me.LblBTR1.Size = New System.Drawing.Size(72, 16)
    Me.LblBTR1.TabIndex = 36
    Me.LblBTR1.Text = "B.A.A Amt"
    Me.LblBTR1.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'TxtBaa1
    '
    Me.TxtBaa1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBaa1.Location = New System.Drawing.Point(271, 32)
    Me.TxtBaa1.MaxLength = 9
    Me.TxtBaa1.Name = "TxtBaa1"
    Me.TxtBaa1.Size = New System.Drawing.Size(80, 22)
    Me.TxtBaa1.TabIndex = 4
    Me.TxtBaa1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt1
    '
    Me.TxtAssmt1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt1.Location = New System.Drawing.Point(185, 32)
    Me.TxtAssmt1.MaxLength = 9
    Me.TxtAssmt1.Name = "TxtAssmt1"
    Me.TxtAssmt1.Size = New System.Drawing.Size(80, 22)
    Me.TxtAssmt1.TabIndex = 3
    Me.TxtAssmt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label17
    '
    Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label17.ForeColor = System.Drawing.Color.Black
    Me.Label17.Location = New System.Drawing.Point(185, 16)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(80, 16)
    Me.Label17.TabIndex = 33
    Me.Label17.Text = "Assessment"
    Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label16
    '
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.ForeColor = System.Drawing.Color.Black
    Me.Label16.Location = New System.Drawing.Point(65, 16)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(34, 13)
    Me.Label16.TabIndex = 32
    Me.Label16.Text = "Unit"
    Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'TxtUnit1
    '
    Me.TxtUnit1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit1.Location = New System.Drawing.Point(67, 32)
    Me.TxtUnit1.MaxLength = 3
    Me.TxtUnit1.Name = "TxtUnit1"
    Me.TxtUnit1.Size = New System.Drawing.Size(32, 22)
    Me.TxtUnit1.TabIndex = 1
    Me.TxtUnit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label10
    '
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.ForeColor = System.Drawing.Color.Black
    Me.Label10.Location = New System.Drawing.Point(24, 16)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(40, 16)
    Me.Label10.TabIndex = 14
    Me.Label10.Text = "Code"
    Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label9
    '
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(280, 8)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(24, 16)
    Me.Label9.TabIndex = 126
    Me.Label9.Text = "I.D."
    '
    'LblDtPckBTR
    '
    Me.LblDtPckBTR.Location = New System.Drawing.Point(8, 160)
    Me.LblDtPckBTR.Name = "LblDtPckBTR"
    Me.LblDtPckBTR.Size = New System.Drawing.Size(72, 16)
    Me.LblDtPckBTR.TabIndex = 134
    Me.LblDtPckBTR.Text = "BTR Applied"
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(96, 8)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(32, 22)
    Me.TxtDist.TabIndex = 0
    Me.TxtDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label42
    '
    Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label42.Location = New System.Drawing.Point(8, 8)
    Me.Label42.Name = "Label42"
    Me.Label42.Size = New System.Drawing.Size(88, 16)
    Me.Label42.TabIndex = 132
    Me.Label42.Text = "District"
    '
    'Label40
    '
    Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label40.Location = New System.Drawing.Point(144, 8)
    Me.Label40.Name = "Label40"
    Me.Label40.Size = New System.Drawing.Size(72, 16)
    Me.Label40.TabIndex = 130
    Me.Label40.Text = "Other District"
    '
    'TxtOid
    '
    Me.TxtOid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOid.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOid.Location = New System.Drawing.Point(312, 8)
    Me.TxtOid.MaxLength = 15
    Me.TxtOid.Name = "TxtOid"
    Me.TxtOid.Size = New System.Drawing.Size(125, 22)
    Me.TxtOid.TabIndex = 2
    '
    'TxtPdst
    '
    Me.TxtPdst.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPdst.Location = New System.Drawing.Point(216, 8)
    Me.TxtPdst.MaxLength = 3
    Me.TxtPdst.Name = "TxtPdst"
    Me.TxtPdst.Size = New System.Drawing.Size(32, 22)
    Me.TxtPdst.TabIndex = 1
    Me.TxtPdst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtLoc
    '
    Me.TxtLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLoc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLoc.Location = New System.Drawing.Point(160, 31)
    Me.TxtLoc.MaxLength = 25
    Me.TxtLoc.Name = "TxtLoc"
    Me.TxtLoc.Size = New System.Drawing.Size(209, 22)
    Me.TxtLoc.TabIndex = 4
    '
    'TxtLocNo
    '
    Me.TxtLocNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocNo.Location = New System.Drawing.Point(96, 32)
    Me.TxtLocNo.MaxLength = 7
    Me.TxtLocNo.Name = "TxtLocNo"
    Me.TxtLocNo.Size = New System.Drawing.Size(62, 22)
    Me.TxtLocNo.TabIndex = 3
    Me.TxtLocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(8, 32)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(88, 16)
    Me.Label6.TabIndex = 125
    Me.Label6.Text = "Location#/Name"
    '
    'TxtUnit
    '
    Me.TxtUnit.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit.Location = New System.Drawing.Point(429, 35)
    Me.TxtUnit.MaxLength = 7
    Me.TxtUnit.Name = "TxtUnit"
    Me.TxtUnit.Size = New System.Drawing.Size(62, 22)
    Me.TxtUnit.TabIndex = 5
    '
    'TpEld
    '
    Me.TpEld.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.TpEld.Controls.Add(Me.GroupBox7)
    Me.TpEld.Controls.Add(Me.GroupBox5)
    Me.TpEld.Controls.Add(Me.GroupBox4)
    Me.TpEld.Location = New System.Drawing.Point(4, 25)
    Me.TpEld.Name = "TpEld"
    Me.TpEld.Size = New System.Drawing.Size(728, 331)
    Me.TpEld.TabIndex = 1
    Me.TpEld.Text = "Elderly/Exemption"
    Me.TpEld.UseVisualStyleBackColor = True
    '
    'GroupBox7
    '
    Me.GroupBox7.Controls.Add(Me.LnkLocAmt)
    Me.GroupBox7.Controls.Add(Me.LblLocAmt)
    Me.GroupBox7.Controls.Add(Me.Label74)
    Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox7.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox7.Location = New System.Drawing.Point(216, 144)
    Me.GroupBox7.Name = "GroupBox7"
    Me.GroupBox7.Size = New System.Drawing.Size(170, 46)
    Me.GroupBox7.TabIndex = 130
    Me.GroupBox7.TabStop = False
    Me.GroupBox7.Text = "Local Benefit"
    '
    'LnkLocAmt
    '
    Me.LnkLocAmt.AutoSize = True
    Me.LnkLocAmt.Location = New System.Drawing.Point(145, 26)
    Me.LnkLocAmt.Name = "LnkLocAmt"
    Me.LnkLocAmt.Size = New System.Drawing.Size(13, 13)
    Me.LnkLocAmt.TabIndex = 177
    Me.LnkLocAmt.TabStop = True
    Me.LnkLocAmt.Text = "?"
    '
    'LblLocAmt
    '
    Me.LblLocAmt.BackColor = System.Drawing.Color.Aqua
    Me.LblLocAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocAmt.ForeColor = System.Drawing.Color.Black
    Me.LblLocAmt.Location = New System.Drawing.Point(75, 24)
    Me.LblLocAmt.Name = "LblLocAmt"
    Me.LblLocAmt.Size = New System.Drawing.Size(64, 16)
    Me.LblLocAmt.TabIndex = 73
    Me.LblLocAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label74
    '
    Me.Label74.AutoSize = True
    Me.Label74.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label74.ForeColor = System.Drawing.Color.Black
    Me.Label74.Location = New System.Drawing.Point(16, 24)
    Me.Label74.Name = "Label74"
    Me.Label74.Size = New System.Drawing.Size(43, 13)
    Me.Label74.TabIndex = 2
    Me.Label74.Text = "Amount"
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.TxtEldYear)
    Me.GroupBox5.Controls.Add(Me.LblEldPgm)
    Me.GroupBox5.Controls.Add(Me.LblEldAdj)
    Me.GroupBox5.Controls.Add(Me.LblEldTax)
    Me.GroupBox5.Controls.Add(Me.LblEldMin)
    Me.GroupBox5.Controls.Add(Me.LblEldMax)
    Me.GroupBox5.Controls.Add(Me.LblEldPerc)
    Me.GroupBox5.Controls.Add(Me.Label31)
    Me.GroupBox5.Controls.Add(Me.Label60)
    Me.GroupBox5.Controls.Add(Me.Label95)
    Me.GroupBox5.Controls.Add(Me.Label58)
    Me.GroupBox5.Controls.Add(Me.Label57)
    Me.GroupBox5.Controls.Add(Me.Label55)
    Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox5.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox5.Location = New System.Drawing.Point(8, 144)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(192, 184)
    Me.GroupBox5.TabIndex = 125
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "Heart/Frozen Program"
    '
    'TxtEldYear
    '
    Me.TxtEldYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtEldYear.Location = New System.Drawing.Point(96, 36)
    Me.TxtEldYear.MaxLength = 4
    Me.TxtEldYear.Name = "TxtEldYear"
    Me.TxtEldYear.Size = New System.Drawing.Size(42, 22)
    Me.TxtEldYear.TabIndex = 184
    '
    'LblEldPgm
    '
    Me.LblEldPgm.AutoSize = True
    Me.LblEldPgm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblEldPgm.ForeColor = System.Drawing.Color.Black
    Me.LblEldPgm.Location = New System.Drawing.Point(64, 16)
    Me.LblEldPgm.Name = "LblEldPgm"
    Me.LblEldPgm.Size = New System.Drawing.Size(92, 13)
    Me.LblEldPgm.TabIndex = 183
    Me.LblEldPgm.Text = "<Elderly Program>"
    '
    'LblEldAdj
    '
    Me.LblEldAdj.BackColor = System.Drawing.Color.Aqua
    Me.LblEldAdj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblEldAdj.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblEldAdj.ForeColor = System.Drawing.Color.Black
    Me.LblEldAdj.Location = New System.Drawing.Point(96, 158)
    Me.LblEldAdj.Name = "LblEldAdj"
    Me.LblEldAdj.Size = New System.Drawing.Size(60, 16)
    Me.LblEldAdj.TabIndex = 182
    Me.LblEldAdj.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblEldTax
    '
    Me.LblEldTax.BackColor = System.Drawing.Color.Aqua
    Me.LblEldTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblEldTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblEldTax.ForeColor = System.Drawing.Color.Black
    Me.LblEldTax.Location = New System.Drawing.Point(96, 133)
    Me.LblEldTax.Name = "LblEldTax"
    Me.LblEldTax.Size = New System.Drawing.Size(60, 16)
    Me.LblEldTax.TabIndex = 181
    Me.LblEldTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblEldMin
    '
    Me.LblEldMin.BackColor = System.Drawing.Color.Aqua
    Me.LblEldMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblEldMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblEldMin.ForeColor = System.Drawing.Color.Black
    Me.LblEldMin.Location = New System.Drawing.Point(96, 110)
    Me.LblEldMin.Name = "LblEldMin"
    Me.LblEldMin.Size = New System.Drawing.Size(60, 16)
    Me.LblEldMin.TabIndex = 180
    Me.LblEldMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblEldMax
    '
    Me.LblEldMax.BackColor = System.Drawing.Color.Aqua
    Me.LblEldMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblEldMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblEldMax.ForeColor = System.Drawing.Color.Black
    Me.LblEldMax.Location = New System.Drawing.Point(96, 88)
    Me.LblEldMax.Name = "LblEldMax"
    Me.LblEldMax.Size = New System.Drawing.Size(60, 16)
    Me.LblEldMax.TabIndex = 179
    Me.LblEldMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblEldPerc
    '
    Me.LblEldPerc.BackColor = System.Drawing.Color.Aqua
    Me.LblEldPerc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblEldPerc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblEldPerc.ForeColor = System.Drawing.Color.Black
    Me.LblEldPerc.Location = New System.Drawing.Point(96, 66)
    Me.LblEldPerc.Name = "LblEldPerc"
    Me.LblEldPerc.Size = New System.Drawing.Size(35, 16)
    Me.LblEldPerc.TabIndex = 178
    Me.LblEldPerc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label31
    '
    Me.Label31.AutoSize = True
    Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label31.ForeColor = System.Drawing.Color.Black
    Me.Label31.Location = New System.Drawing.Point(16, 68)
    Me.Label31.Name = "Label31"
    Me.Label31.Size = New System.Drawing.Size(62, 13)
    Me.Label31.TabIndex = 177
    Me.Label31.Text = "Percentage"
    '
    'Label60
    '
    Me.Label60.AutoSize = True
    Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label60.ForeColor = System.Drawing.Color.Black
    Me.Label60.Location = New System.Drawing.Point(16, 160)
    Me.Label60.Name = "Label60"
    Me.Label60.Size = New System.Drawing.Size(59, 13)
    Me.Label60.TabIndex = 7
    Me.Label60.Text = "Adjustment"
    '
    'Label95
    '
    Me.Label95.AutoSize = True
    Me.Label95.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label95.ForeColor = System.Drawing.Color.Black
    Me.Label95.Location = New System.Drawing.Point(16, 136)
    Me.Label95.Name = "Label95"
    Me.Label95.Size = New System.Drawing.Size(60, 13)
    Me.Label95.TabIndex = 6
    Me.Label95.Text = "Frozen Tax"
    '
    'Label58
    '
    Me.Label58.AutoSize = True
    Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label58.ForeColor = System.Drawing.Color.Black
    Me.Label58.Location = New System.Drawing.Point(16, 112)
    Me.Label58.Name = "Label58"
    Me.Label58.Size = New System.Drawing.Size(48, 13)
    Me.Label58.TabIndex = 5
    Me.Label58.Text = "Minimum"
    '
    'Label57
    '
    Me.Label57.AutoSize = True
    Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label57.ForeColor = System.Drawing.Color.Black
    Me.Label57.Location = New System.Drawing.Point(16, 88)
    Me.Label57.Name = "Label57"
    Me.Label57.Size = New System.Drawing.Size(51, 13)
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
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.LnkExempt6)
    Me.GroupBox4.Controls.Add(Me.TxtExempt6)
    Me.GroupBox4.Controls.Add(Me.LnkExempt7)
    Me.GroupBox4.Controls.Add(Me.TxtExempt7)
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
    Me.GroupBox4.Controls.Add(Me.TxtExam7)
    Me.GroupBox4.Controls.Add(Me.TxtExam6)
    Me.GroupBox4.Controls.Add(Me.TxtExam4)
    Me.GroupBox4.Controls.Add(Me.TxtExam2)
    Me.GroupBox4.Controls.Add(Me.Label46)
    Me.GroupBox4.Controls.Add(Me.Label47)
    Me.GroupBox4.Controls.Add(Me.TxtExam5)
    Me.GroupBox4.Controls.Add(Me.TxtExam3)
    Me.GroupBox4.Controls.Add(Me.TxtExam1)
    Me.GroupBox4.Controls.Add(Me.Label50)
    Me.GroupBox4.Controls.Add(Me.Label52)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox4.Location = New System.Drawing.Point(8, 8)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(720, 132)
    Me.GroupBox4.TabIndex = 124
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Exemptions"
    '
    'LnkExempt6
    '
    Me.LnkExempt6.Location = New System.Drawing.Point(362, 84)
    Me.LnkExempt6.Name = "LnkExempt6"
    Me.LnkExempt6.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt6.TabIndex = 182
    Me.LnkExempt6.TabStop = True
    Me.LnkExempt6.Text = "6"
    '
    'TxtExempt6
    '
    Me.TxtExempt6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt6.Location = New System.Drawing.Point(392, 80)
    Me.TxtExempt6.MaxLength = 3
    Me.TxtExempt6.Name = "TxtExempt6"
    Me.TxtExempt6.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt6.TabIndex = 10
    '
    'LnkExempt7
    '
    Me.LnkExempt7.Location = New System.Drawing.Point(6, 109)
    Me.LnkExempt7.Name = "LnkExempt7"
    Me.LnkExempt7.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt7.TabIndex = 180
    Me.LnkExempt7.TabStop = True
    Me.LnkExempt7.Text = "7"
    '
    'TxtExempt7
    '
    Me.TxtExempt7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt7.Location = New System.Drawing.Point(32, 104)
    Me.TxtExempt7.MaxLength = 3
    Me.TxtExempt7.Name = "TxtExempt7"
    Me.TxtExempt7.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt7.TabIndex = 12
    '
    'LnkExempt5
    '
    Me.LnkExempt5.Location = New System.Drawing.Point(6, 85)
    Me.LnkExempt5.Name = "LnkExempt5"
    Me.LnkExempt5.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt5.TabIndex = 178
    Me.LnkExempt5.TabStop = True
    Me.LnkExempt5.Text = "5"
    '
    'TxtExempt5
    '
    Me.TxtExempt5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt5.Location = New System.Drawing.Point(32, 80)
    Me.TxtExempt5.MaxLength = 3
    Me.TxtExempt5.Name = "TxtExempt5"
    Me.TxtExempt5.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt5.TabIndex = 8
    '
    'LnkExempt3
    '
    Me.LnkExempt3.Location = New System.Drawing.Point(6, 61)
    Me.LnkExempt3.Name = "LnkExempt3"
    Me.LnkExempt3.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt3.TabIndex = 177
    Me.LnkExempt3.TabStop = True
    Me.LnkExempt3.Text = "3"
    '
    'TxtExempt3
    '
    Me.TxtExempt3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt3.Location = New System.Drawing.Point(32, 56)
    Me.TxtExempt3.MaxLength = 3
    Me.TxtExempt3.Name = "TxtExempt3"
    Me.TxtExempt3.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt3.TabIndex = 4
    '
    'LnkExempt4
    '
    Me.LnkExempt4.Location = New System.Drawing.Point(362, 60)
    Me.LnkExempt4.Name = "LnkExempt4"
    Me.LnkExempt4.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt4.TabIndex = 176
    Me.LnkExempt4.TabStop = True
    Me.LnkExempt4.Text = "4"
    '
    'TxtExempt4
    '
    Me.TxtExempt4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt4.Location = New System.Drawing.Point(392, 56)
    Me.TxtExempt4.MaxLength = 3
    Me.TxtExempt4.Name = "TxtExempt4"
    Me.TxtExempt4.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt4.TabIndex = 6
    '
    'LnkExempt2
    '
    Me.LnkExempt2.Location = New System.Drawing.Point(362, 36)
    Me.LnkExempt2.Name = "LnkExempt2"
    Me.LnkExempt2.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt2.TabIndex = 175
    Me.LnkExempt2.TabStop = True
    Me.LnkExempt2.Text = "2"
    '
    'TxtExempt2
    '
    Me.TxtExempt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt2.Location = New System.Drawing.Point(392, 32)
    Me.TxtExempt2.MaxLength = 3
    Me.TxtExempt2.Name = "TxtExempt2"
    Me.TxtExempt2.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt2.TabIndex = 2
    '
    'LnkExempt1
    '
    Me.LnkExempt1.Location = New System.Drawing.Point(6, 37)
    Me.LnkExempt1.Name = "LnkExempt1"
    Me.LnkExempt1.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt1.TabIndex = 174
    Me.LnkExempt1.TabStop = True
    Me.LnkExempt1.Text = "1"
    '
    'TxtExempt1
    '
    Me.TxtExempt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt1.Location = New System.Drawing.Point(32, 32)
    Me.TxtExempt1.MaxLength = 3
    Me.TxtExempt1.Name = "TxtExempt1"
    Me.TxtExempt1.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt1.TabIndex = 0
    '
    'TxtExam7
    '
    Me.TxtExam7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam7.Location = New System.Drawing.Point(72, 104)
    Me.TxtExam7.MaxLength = 7
    Me.TxtExam7.Name = "TxtExam7"
    Me.TxtExam7.Size = New System.Drawing.Size(64, 22)
    Me.TxtExam7.TabIndex = 69
    Me.TxtExam7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam6
    '
    Me.TxtExam6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam6.Location = New System.Drawing.Point(432, 80)
    Me.TxtExam6.MaxLength = 7
    Me.TxtExam6.Name = "TxtExam6"
    Me.TxtExam6.Size = New System.Drawing.Size(62, 22)
    Me.TxtExam6.TabIndex = 66
    Me.TxtExam6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam4
    '
    Me.TxtExam4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam4.Location = New System.Drawing.Point(432, 56)
    Me.TxtExam4.MaxLength = 7
    Me.TxtExam4.Name = "TxtExam4"
    Me.TxtExam4.Size = New System.Drawing.Size(62, 22)
    Me.TxtExam4.TabIndex = 7
    Me.TxtExam4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam2
    '
    Me.TxtExam2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam2.Location = New System.Drawing.Point(432, 32)
    Me.TxtExam2.MaxLength = 7
    Me.TxtExam2.Name = "TxtExam2"
    Me.TxtExam2.Size = New System.Drawing.Size(62, 22)
    Me.TxtExam2.TabIndex = 3
    Me.TxtExam2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label46
    '
    Me.Label46.AutoSize = True
    Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label46.ForeColor = System.Drawing.Color.Black
    Me.Label46.Location = New System.Drawing.Point(446, 16)
    Me.Label46.Name = "Label46"
    Me.Label46.Size = New System.Drawing.Size(49, 13)
    Me.Label46.TabIndex = 48
    Me.Label46.Text = "Amount"
    '
    'Label47
    '
    Me.Label47.AutoSize = True
    Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label47.ForeColor = System.Drawing.Color.Black
    Me.Label47.Location = New System.Drawing.Point(392, 16)
    Me.Label47.Name = "Label47"
    Me.Label47.Size = New System.Drawing.Size(36, 13)
    Me.Label47.TabIndex = 46
    Me.Label47.Text = "Code"
    '
    'TxtExam5
    '
    Me.TxtExam5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam5.Location = New System.Drawing.Point(72, 80)
    Me.TxtExam5.MaxLength = 7
    Me.TxtExam5.Name = "TxtExam5"
    Me.TxtExam5.Size = New System.Drawing.Size(64, 22)
    Me.TxtExam5.TabIndex = 9
    Me.TxtExam5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam3
    '
    Me.TxtExam3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam3.Location = New System.Drawing.Point(72, 56)
    Me.TxtExam3.MaxLength = 7
    Me.TxtExam3.Name = "TxtExam3"
    Me.TxtExam3.Size = New System.Drawing.Size(64, 22)
    Me.TxtExam3.TabIndex = 5
    Me.TxtExam3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam1
    '
    Me.TxtExam1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam1.Location = New System.Drawing.Point(72, 32)
    Me.TxtExam1.MaxLength = 7
    Me.TxtExam1.Name = "TxtExam1"
    Me.TxtExam1.Size = New System.Drawing.Size(64, 22)
    Me.TxtExam1.TabIndex = 1
    Me.TxtExam1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label50
    '
    Me.Label50.AutoSize = True
    Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label50.ForeColor = System.Drawing.Color.Black
    Me.Label50.Location = New System.Drawing.Point(86, 16)
    Me.Label50.Name = "Label50"
    Me.Label50.Size = New System.Drawing.Size(49, 13)
    Me.Label50.TabIndex = 38
    Me.Label50.Text = "Amount"
    '
    'Label52
    '
    Me.Label52.AutoSize = True
    Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label52.ForeColor = System.Drawing.Color.Black
    Me.Label52.Location = New System.Drawing.Point(32, 16)
    Me.Label52.Name = "Label52"
    Me.Label52.Size = New System.Drawing.Size(36, 13)
    Me.Label52.TabIndex = 35
    Me.Label52.Text = "Code"
    '
    'TpTran
    '
    Me.TpTran.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.TpTran.Controls.Add(Me.TxtTranMap)
    Me.TpTran.Controls.Add(Me.Label13)
    Me.TpTran.Controls.Add(Me.ChkTranExempt)
    Me.TpTran.Controls.Add(Me.ChkTranEld)
    Me.TpTran.Controls.Add(Me.TxtTranTract)
    Me.TpTran.Controls.Add(Me.Label75)
    Me.TpTran.Controls.Add(Me.TxtTranBlock)
    Me.TpTran.Controls.Add(Me.TxtTranVol)
    Me.TpTran.Controls.Add(Me.TxtTranPage)
    Me.TpTran.Controls.Add(Me.Label70)
    Me.TpTran.Controls.Add(Me.Label71)
    Me.TpTran.Controls.Add(Me.TxtTranPrice)
    Me.TpTran.Controls.Add(Me.Label68)
    Me.TpTran.Controls.Add(Me.GroupBox6)
    Me.TpTran.Controls.Add(Me.DtPckTran)
    Me.TpTran.Controls.Add(Me.Label64)
    Me.TpTran.Controls.Add(Me.TxtTranZip4)
    Me.TpTran.Controls.Add(Me.TxtTranCity)
    Me.TpTran.Controls.Add(Me.TxtTranState)
    Me.TpTran.Controls.Add(Me.TxtTranAdd2)
    Me.TpTran.Controls.Add(Me.TxtTranAdd1)
    Me.TpTran.Controls.Add(Me.TxtTranSname)
    Me.TpTran.Controls.Add(Me.TxtTranZip5)
    Me.TpTran.Controls.Add(Me.TxtTranName)
    Me.TpTran.Controls.Add(Me.Label41)
    Me.TpTran.Controls.Add(Me.Label61)
    Me.TpTran.Controls.Add(Me.Label62)
    Me.TpTran.Controls.Add(Me.Label63)
    Me.TpTran.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TpTran.Location = New System.Drawing.Point(4, 25)
    Me.TpTran.Name = "TpTran"
    Me.TpTran.Size = New System.Drawing.Size(728, 331)
    Me.TpTran.TabIndex = 2
    Me.TpTran.Text = "Transfer"
    Me.TpTran.UseVisualStyleBackColor = True
    '
    'TxtTranMap
    '
    Me.TxtTranMap.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTranMap.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTranMap.Location = New System.Drawing.Point(96, 155)
    Me.TxtTranMap.MaxLength = 17
    Me.TxtTranMap.Name = "TxtTranMap"
    Me.TxtTranMap.Size = New System.Drawing.Size(144, 22)
    Me.TxtTranMap.TabIndex = 159
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(8, 155)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(88, 16)
    Me.Label13.TabIndex = 170
    Me.Label13.Text = "Map Block Lot"
    '
    'ChkTranExempt
    '
    Me.ChkTranExempt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkTranExempt.Location = New System.Drawing.Point(256, 236)
    Me.ChkTranExempt.Name = "ChkTranExempt"
    Me.ChkTranExempt.Size = New System.Drawing.Size(120, 16)
    Me.ChkTranExempt.TabIndex = 168
    Me.ChkTranExempt.Text = "Delete Exemption?"
    '
    'ChkTranEld
    '
    Me.ChkTranEld.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkTranEld.Location = New System.Drawing.Point(8, 236)
    Me.ChkTranEld.Name = "ChkTranEld"
    Me.ChkTranEld.Size = New System.Drawing.Size(104, 16)
    Me.ChkTranEld.TabIndex = 167
    Me.ChkTranEld.Text = "Delete Elderly?"
    '
    'TxtTranTract
    '
    Me.TxtTranTract.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTranTract.Location = New System.Drawing.Point(344, 204)
    Me.TxtTranTract.MaxLength = 7
    Me.TxtTranTract.Name = "TxtTranTract"
    Me.TxtTranTract.Size = New System.Drawing.Size(64, 22)
    Me.TxtTranTract.TabIndex = 166
    Me.TxtTranTract.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label75
    '
    Me.Label75.Location = New System.Drawing.Point(8, 204)
    Me.Label75.Name = "Label75"
    Me.Label75.Size = New System.Drawing.Size(80, 16)
    Me.Label75.TabIndex = 165
    Me.Label75.Text = "Census Block"
    '
    'TxtTranBlock
    '
    Me.TxtTranBlock.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTranBlock.Location = New System.Drawing.Point(96, 204)
    Me.TxtTranBlock.MaxLength = 5
    Me.TxtTranBlock.Name = "TxtTranBlock"
    Me.TxtTranBlock.Size = New System.Drawing.Size(48, 22)
    Me.TxtTranBlock.TabIndex = 165
    Me.TxtTranBlock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtTranVol
    '
    Me.TxtTranVol.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTranVol.Location = New System.Drawing.Point(96, 180)
    Me.TxtTranVol.MaxLength = 5
    Me.TxtTranVol.Name = "TxtTranVol"
    Me.TxtTranVol.Size = New System.Drawing.Size(48, 22)
    Me.TxtTranVol.TabIndex = 160
    Me.TxtTranVol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtTranPage
    '
    Me.TxtTranPage.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTranPage.Location = New System.Drawing.Point(146, 180)
    Me.TxtTranPage.MaxLength = 5
    Me.TxtTranPage.Name = "TxtTranPage"
    Me.TxtTranPage.Size = New System.Drawing.Size(46, 22)
    Me.TxtTranPage.TabIndex = 161
    Me.TxtTranPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label70
    '
    Me.Label70.Location = New System.Drawing.Point(8, 180)
    Me.Label70.Name = "Label70"
    Me.Label70.Size = New System.Drawing.Size(88, 16)
    Me.Label70.TabIndex = 162
    Me.Label70.Text = "Vol/Page"
    '
    'Label71
    '
    Me.Label71.Location = New System.Drawing.Point(256, 204)
    Me.Label71.Name = "Label71"
    Me.Label71.Size = New System.Drawing.Size(72, 16)
    Me.Label71.TabIndex = 160
    Me.Label71.Text = "Census Tract"
    '
    'TxtTranPrice
    '
    Me.TxtTranPrice.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTranPrice.Location = New System.Drawing.Point(344, 136)
    Me.TxtTranPrice.MaxLength = 9
    Me.TxtTranPrice.Name = "TxtTranPrice"
    Me.TxtTranPrice.Size = New System.Drawing.Size(80, 22)
    Me.TxtTranPrice.TabIndex = 158
    Me.TxtTranPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label68
    '
    Me.Label68.Location = New System.Drawing.Point(256, 136)
    Me.Label68.Name = "Label68"
    Me.Label68.Size = New System.Drawing.Size(88, 16)
    Me.Label68.TabIndex = 159
    Me.Label68.Text = "Sale Price"
    '
    'GroupBox6
    '
    Me.GroupBox6.Controls.Add(Me.LnkTranExemptCd)
    Me.GroupBox6.Controls.Add(Me.TxtTranExemptCd)
    Me.GroupBox6.Controls.Add(Me.RbTranExempt)
    Me.GroupBox6.Controls.Add(Me.RbTranTaxable)
    Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox6.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox6.Location = New System.Drawing.Point(560, 16)
    Me.GroupBox6.Name = "GroupBox6"
    Me.GroupBox6.Size = New System.Drawing.Size(160, 64)
    Me.GroupBox6.TabIndex = 157
    Me.GroupBox6.TabStop = False
    Me.GroupBox6.Text = "Category"
    '
    'LnkTranExemptCd
    '
    Me.LnkTranExemptCd.Location = New System.Drawing.Point(8, 40)
    Me.LnkTranExemptCd.Name = "LnkTranExemptCd"
    Me.LnkTranExemptCd.Size = New System.Drawing.Size(80, 16)
    Me.LnkTranExemptCd.TabIndex = 100
    Me.LnkTranExemptCd.TabStop = True
    Me.LnkTranExemptCd.Text = "Exempt Code"
    '
    'TxtTranExemptCd
    '
    Me.TxtTranExemptCd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTranExemptCd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTranExemptCd.Location = New System.Drawing.Point(88, 40)
    Me.TxtTranExemptCd.MaxLength = 4
    Me.TxtTranExemptCd.Name = "TxtTranExemptCd"
    Me.TxtTranExemptCd.Size = New System.Drawing.Size(40, 22)
    Me.TxtTranExemptCd.TabIndex = 99
    Me.TxtTranExemptCd.TabStop = False
    '
    'RbTranExempt
    '
    Me.RbTranExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbTranExempt.ForeColor = System.Drawing.Color.Black
    Me.RbTranExempt.Location = New System.Drawing.Point(88, 16)
    Me.RbTranExempt.Name = "RbTranExempt"
    Me.RbTranExempt.Size = New System.Drawing.Size(64, 24)
    Me.RbTranExempt.TabIndex = 1
    Me.RbTranExempt.Text = "Exempt"
    '
    'RbTranTaxable
    '
    Me.RbTranTaxable.Checked = True
    Me.RbTranTaxable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbTranTaxable.ForeColor = System.Drawing.Color.Black
    Me.RbTranTaxable.Location = New System.Drawing.Point(8, 16)
    Me.RbTranTaxable.Name = "RbTranTaxable"
    Me.RbTranTaxable.Size = New System.Drawing.Size(64, 24)
    Me.RbTranTaxable.TabIndex = 0
    Me.RbTranTaxable.TabStop = True
    Me.RbTranTaxable.Text = "Taxable"
    '
    'DtPckTran
    '
    Me.DtPckTran.Checked = False
    Me.DtPckTran.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTran.Location = New System.Drawing.Point(96, 132)
    Me.DtPckTran.Name = "DtPckTran"
    Me.DtPckTran.ShowCheckBox = True
    Me.DtPckTran.Size = New System.Drawing.Size(96, 20)
    Me.DtPckTran.TabIndex = 156
    '
    'Label64
    '
    Me.Label64.Location = New System.Drawing.Point(8, 132)
    Me.Label64.Name = "Label64"
    Me.Label64.Size = New System.Drawing.Size(80, 16)
    Me.Label64.TabIndex = 155
    Me.Label64.Text = "Transfer Date"
    '
    'TxtTranZip4
    '
    Me.TxtTranZip4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTranZip4.Location = New System.Drawing.Point(398, 108)
    Me.TxtTranZip4.MaxLength = 4
    Me.TxtTranZip4.Name = "TxtTranZip4"
    Me.TxtTranZip4.Size = New System.Drawing.Size(42, 22)
    Me.TxtTranZip4.TabIndex = 150
    '
    'TxtTranCity
    '
    Me.TxtTranCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTranCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTranCity.Location = New System.Drawing.Point(96, 108)
    Me.TxtTranCity.MaxLength = 25
    Me.TxtTranCity.Name = "TxtTranCity"
    Me.TxtTranCity.Size = New System.Drawing.Size(210, 22)
    Me.TxtTranCity.TabIndex = 147
    '
    'TxtTranState
    '
    Me.TxtTranState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTranState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTranState.Location = New System.Drawing.Point(312, 108)
    Me.TxtTranState.MaxLength = 2
    Me.TxtTranState.Name = "TxtTranState"
    Me.TxtTranState.Size = New System.Drawing.Size(24, 22)
    Me.TxtTranState.TabIndex = 148
    '
    'TxtTranAdd2
    '
    Me.TxtTranAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTranAdd2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTranAdd2.Location = New System.Drawing.Point(96, 84)
    Me.TxtTranAdd2.MaxLength = 35
    Me.TxtTranAdd2.Name = "TxtTranAdd2"
    Me.TxtTranAdd2.Size = New System.Drawing.Size(288, 22)
    Me.TxtTranAdd2.TabIndex = 146
    '
    'TxtTranAdd1
    '
    Me.TxtTranAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTranAdd1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTranAdd1.Location = New System.Drawing.Point(96, 60)
    Me.TxtTranAdd1.MaxLength = 35
    Me.TxtTranAdd1.Name = "TxtTranAdd1"
    Me.TxtTranAdd1.Size = New System.Drawing.Size(288, 22)
    Me.TxtTranAdd1.TabIndex = 145
    '
    'TxtTranSname
    '
    Me.TxtTranSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTranSname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTranSname.Location = New System.Drawing.Point(96, 36)
    Me.TxtTranSname.MaxLength = 35
    Me.TxtTranSname.Name = "TxtTranSname"
    Me.TxtTranSname.Size = New System.Drawing.Size(288, 22)
    Me.TxtTranSname.TabIndex = 144
    '
    'TxtTranZip5
    '
    Me.TxtTranZip5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTranZip5.Location = New System.Drawing.Point(344, 108)
    Me.TxtTranZip5.MaxLength = 5
    Me.TxtTranZip5.Name = "TxtTranZip5"
    Me.TxtTranZip5.Size = New System.Drawing.Size(48, 22)
    Me.TxtTranZip5.TabIndex = 149
    '
    'TxtTranName
    '
    Me.TxtTranName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTranName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTranName.Location = New System.Drawing.Point(96, 12)
    Me.TxtTranName.MaxLength = 35
    Me.TxtTranName.Name = "TxtTranName"
    Me.TxtTranName.Size = New System.Drawing.Size(288, 22)
    Me.TxtTranName.TabIndex = 143
    '
    'Label41
    '
    Me.Label41.Location = New System.Drawing.Point(8, 108)
    Me.Label41.Name = "Label41"
    Me.Label41.Size = New System.Drawing.Size(80, 16)
    Me.Label41.TabIndex = 154
    Me.Label41.Text = "City/State/Zip"
    '
    'Label61
    '
    Me.Label61.Location = New System.Drawing.Point(8, 60)
    Me.Label61.Name = "Label61"
    Me.Label61.Size = New System.Drawing.Size(80, 16)
    Me.Label61.TabIndex = 153
    Me.Label61.Text = "Street Address"
    '
    'Label62
    '
    Me.Label62.Location = New System.Drawing.Point(8, 36)
    Me.Label62.Name = "Label62"
    Me.Label62.Size = New System.Drawing.Size(80, 16)
    Me.Label62.TabIndex = 152
    Me.Label62.Text = "Second Name"
    '
    'Label63
    '
    Me.Label63.Location = New System.Drawing.Point(8, 12)
    Me.Label63.Name = "Label63"
    Me.Label63.Size = New System.Drawing.Size(48, 16)
    Me.Label63.TabIndex = 151
    Me.Label63.Text = "Name"
    '
    'TpPz
    '
    Me.TpPz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.TpPz.Controls.Add(Me.ChkPZSeptic)
    Me.TpPz.Controls.Add(Me.TxtPZBath)
    Me.TpPz.Controls.Add(Me.Label82)
    Me.TpPz.Controls.Add(Me.TxtPZSewphs)
    Me.TpPz.Controls.Add(Me.Label81)
    Me.TpPz.Controls.Add(Me.TxtPZBed)
    Me.TpPz.Controls.Add(Me.Label80)
    Me.TpPz.Controls.Add(Me.TxtPZBldAcre)
    Me.TpPz.Controls.Add(Me.Label79)
    Me.TpPz.Controls.Add(Me.TxtPZGrossAcre)
    Me.TpPz.Controls.Add(Me.Label78)
    Me.TpPz.Controls.Add(Me.TxtPZZoning)
    Me.TpPz.Controls.Add(Me.Label77)
    Me.TpPz.Controls.Add(Me.TxtPZNon)
    Me.TpPz.Controls.Add(Me.Label76)
    Me.TpPz.Controls.Add(Me.TxtPZCard)
    Me.TpPz.Controls.Add(Me.Label67)
    Me.TpPz.Controls.Add(Me.TxtPZLot)
    Me.TpPz.Controls.Add(Me.Label66)
    Me.TpPz.Controls.Add(Me.TxtPZMap)
    Me.TpPz.Controls.Add(Me.Label65)
    Me.TpPz.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TpPz.Location = New System.Drawing.Point(4, 25)
    Me.TpPz.Name = "TpPz"
    Me.TpPz.Size = New System.Drawing.Size(728, 331)
    Me.TpPz.TabIndex = 3
    Me.TpPz.Text = "P & Z"
    Me.TpPz.UseVisualStyleBackColor = True
    '
    'ChkPZSeptic
    '
    Me.ChkPZSeptic.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPZSeptic.Location = New System.Drawing.Point(8, 248)
    Me.ChkPZSeptic.Name = "ChkPZSeptic"
    Me.ChkPZSeptic.Size = New System.Drawing.Size(112, 16)
    Me.ChkPZSeptic.TabIndex = 168
    Me.ChkPZSeptic.Text = "Septic?"
    '
    'TxtPZBath
    '
    Me.TxtPZBath.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPZBath.Location = New System.Drawing.Point(104, 224)
    Me.TxtPZBath.MaxLength = 3
    Me.TxtPZBath.Name = "TxtPZBath"
    Me.TxtPZBath.Size = New System.Drawing.Size(24, 22)
    Me.TxtPZBath.TabIndex = 160
    Me.TxtPZBath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label82
    '
    Me.Label82.Location = New System.Drawing.Point(8, 224)
    Me.Label82.Name = "Label82"
    Me.Label82.Size = New System.Drawing.Size(88, 16)
    Me.Label82.TabIndex = 161
    Me.Label82.Text = "# of Baths"
    '
    'TxtPZSewphs
    '
    Me.TxtPZSewphs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPZSewphs.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPZSewphs.Location = New System.Drawing.Point(104, 200)
    Me.TxtPZSewphs.MaxLength = 2
    Me.TxtPZSewphs.Name = "TxtPZSewphs"
    Me.TxtPZSewphs.Size = New System.Drawing.Size(24, 22)
    Me.TxtPZSewphs.TabIndex = 158
    '
    'Label81
    '
    Me.Label81.Location = New System.Drawing.Point(8, 204)
    Me.Label81.Name = "Label81"
    Me.Label81.Size = New System.Drawing.Size(96, 12)
    Me.Label81.TabIndex = 159
    Me.Label81.Text = "Sewer Phase"
    '
    'TxtPZBed
    '
    Me.TxtPZBed.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPZBed.Location = New System.Drawing.Point(104, 176)
    Me.TxtPZBed.MaxLength = 3
    Me.TxtPZBed.Name = "TxtPZBed"
    Me.TxtPZBed.Size = New System.Drawing.Size(32, 22)
    Me.TxtPZBed.TabIndex = 156
    Me.TxtPZBed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label80
    '
    Me.Label80.Location = New System.Drawing.Point(10, 180)
    Me.Label80.Name = "Label80"
    Me.Label80.Size = New System.Drawing.Size(88, 16)
    Me.Label80.TabIndex = 157
    Me.Label80.Text = "# of Bedrooms"
    '
    'TxtPZBldAcre
    '
    Me.TxtPZBldAcre.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPZBldAcre.Location = New System.Drawing.Point(104, 152)
    Me.TxtPZBldAcre.MaxLength = 8
    Me.TxtPZBldAcre.Name = "TxtPZBldAcre"
    Me.TxtPZBldAcre.Size = New System.Drawing.Size(72, 22)
    Me.TxtPZBldAcre.TabIndex = 154
    Me.TxtPZBldAcre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label79
    '
    Me.Label79.Location = New System.Drawing.Point(8, 156)
    Me.Label79.Name = "Label79"
    Me.Label79.Size = New System.Drawing.Size(96, 16)
    Me.Label79.TabIndex = 155
    Me.Label79.Text = "Building Acreage"
    '
    'TxtPZGrossAcre
    '
    Me.TxtPZGrossAcre.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPZGrossAcre.Location = New System.Drawing.Point(104, 128)
    Me.TxtPZGrossAcre.MaxLength = 8
    Me.TxtPZGrossAcre.Name = "TxtPZGrossAcre"
    Me.TxtPZGrossAcre.Size = New System.Drawing.Size(72, 22)
    Me.TxtPZGrossAcre.TabIndex = 152
    Me.TxtPZGrossAcre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label78
    '
    Me.Label78.Location = New System.Drawing.Point(10, 132)
    Me.Label78.Name = "Label78"
    Me.Label78.Size = New System.Drawing.Size(88, 16)
    Me.Label78.TabIndex = 153
    Me.Label78.Text = "Gross Acreage"
    '
    'TxtPZZoning
    '
    Me.TxtPZZoning.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPZZoning.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPZZoning.Location = New System.Drawing.Point(104, 104)
    Me.TxtPZZoning.MaxLength = 3
    Me.TxtPZZoning.Name = "TxtPZZoning"
    Me.TxtPZZoning.Size = New System.Drawing.Size(32, 22)
    Me.TxtPZZoning.TabIndex = 150
    '
    'Label77
    '
    Me.Label77.Location = New System.Drawing.Point(8, 104)
    Me.Label77.Name = "Label77"
    Me.Label77.Size = New System.Drawing.Size(88, 16)
    Me.Label77.TabIndex = 151
    Me.Label77.Text = "Zoning"
    '
    'TxtPZNon
    '
    Me.TxtPZNon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPZNon.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPZNon.Location = New System.Drawing.Point(104, 80)
    Me.TxtPZNon.MaxLength = 2
    Me.TxtPZNon.Name = "TxtPZNon"
    Me.TxtPZNon.Size = New System.Drawing.Size(24, 22)
    Me.TxtPZNon.TabIndex = 148
    '
    'Label76
    '
    Me.Label76.Location = New System.Drawing.Point(8, 80)
    Me.Label76.Name = "Label76"
    Me.Label76.Size = New System.Drawing.Size(88, 16)
    Me.Label76.TabIndex = 149
    Me.Label76.Text = "Non-conforming"
    '
    'TxtPZCard
    '
    Me.TxtPZCard.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPZCard.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPZCard.Location = New System.Drawing.Point(104, 56)
    Me.TxtPZCard.MaxLength = 5
    Me.TxtPZCard.Name = "TxtPZCard"
    Me.TxtPZCard.Size = New System.Drawing.Size(48, 22)
    Me.TxtPZCard.TabIndex = 146
    '
    'Label67
    '
    Me.Label67.Location = New System.Drawing.Point(8, 56)
    Me.Label67.Name = "Label67"
    Me.Label67.Size = New System.Drawing.Size(88, 16)
    Me.Label67.TabIndex = 147
    Me.Label67.Text = "Property Card#"
    '
    'TxtPZLot
    '
    Me.TxtPZLot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPZLot.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPZLot.Location = New System.Drawing.Point(104, 32)
    Me.TxtPZLot.MaxLength = 25
    Me.TxtPZLot.Name = "TxtPZLot"
    Me.TxtPZLot.Size = New System.Drawing.Size(208, 22)
    Me.TxtPZLot.TabIndex = 144
    '
    'Label66
    '
    Me.Label66.Location = New System.Drawing.Point(8, 32)
    Me.Label66.Name = "Label66"
    Me.Label66.Size = New System.Drawing.Size(80, 16)
    Me.Label66.TabIndex = 145
    Me.Label66.Text = "Lot Size"
    '
    'TxtPZMap
    '
    Me.TxtPZMap.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPZMap.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPZMap.Location = New System.Drawing.Point(104, 8)
    Me.TxtPZMap.MaxLength = 3
    Me.TxtPZMap.Name = "TxtPZMap"
    Me.TxtPZMap.Size = New System.Drawing.Size(32, 22)
    Me.TxtPZMap.TabIndex = 142
    '
    'Label65
    '
    Me.Label65.Location = New System.Drawing.Point(8, 8)
    Me.Label65.Name = "Label65"
    Me.Label65.Size = New System.Drawing.Size(80, 16)
    Me.Label65.TabIndex = 143
    Me.Label65.Text = "Aerial Map#"
    '
    'TpAct490
    '
    Me.TpAct490.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.TpAct490.Controls.Add(Me.DtPckActExpir)
    Me.TpAct490.Controls.Add(Me.Label85)
    Me.TpAct490.Controls.Add(Me.DtPckActInit)
    Me.TpAct490.Controls.Add(Me.Label84)
    Me.TpAct490.Controls.Add(Me.TxtActAcres)
    Me.TpAct490.Controls.Add(Me.Label83)
    Me.TpAct490.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TpAct490.Location = New System.Drawing.Point(4, 25)
    Me.TpAct490.Name = "TpAct490"
    Me.TpAct490.Size = New System.Drawing.Size(728, 331)
    Me.TpAct490.TabIndex = 4
    Me.TpAct490.Text = "Public Act 490"
    Me.TpAct490.UseVisualStyleBackColor = True
    '
    'DtPckActExpir
    '
    Me.DtPckActExpir.Checked = False
    Me.DtPckActExpir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckActExpir.Location = New System.Drawing.Point(112, 56)
    Me.DtPckActExpir.Name = "DtPckActExpir"
    Me.DtPckActExpir.ShowCheckBox = True
    Me.DtPckActExpir.Size = New System.Drawing.Size(96, 20)
    Me.DtPckActExpir.TabIndex = 160
    '
    'Label85
    '
    Me.Label85.Location = New System.Drawing.Point(8, 56)
    Me.Label85.Name = "Label85"
    Me.Label85.Size = New System.Drawing.Size(96, 16)
    Me.Label85.TabIndex = 159
    Me.Label85.Text = "Expiration Date"
    '
    'DtPckActInit
    '
    Me.DtPckActInit.Checked = False
    Me.DtPckActInit.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckActInit.Location = New System.Drawing.Point(112, 32)
    Me.DtPckActInit.Name = "DtPckActInit"
    Me.DtPckActInit.ShowCheckBox = True
    Me.DtPckActInit.Size = New System.Drawing.Size(96, 20)
    Me.DtPckActInit.TabIndex = 158
    '
    'Label84
    '
    Me.Label84.Location = New System.Drawing.Point(8, 32)
    Me.Label84.Name = "Label84"
    Me.Label84.Size = New System.Drawing.Size(96, 16)
    Me.Label84.TabIndex = 157
    Me.Label84.Text = "Initial Acq Date"
    '
    'TxtActAcres
    '
    Me.TxtActAcres.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtActAcres.Location = New System.Drawing.Point(112, 8)
    Me.TxtActAcres.MaxLength = 5
    Me.TxtActAcres.Name = "TxtActAcres"
    Me.TxtActAcres.Size = New System.Drawing.Size(48, 22)
    Me.TxtActAcres.TabIndex = 148
    Me.TxtActAcres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label83
    '
    Me.Label83.Location = New System.Drawing.Point(8, 8)
    Me.Label83.Name = "Label83"
    Me.Label83.Size = New System.Drawing.Size(104, 16)
    Me.Label83.TabIndex = 149
    Me.Label83.Text = "Acres Classification"
    '
    'TpPhaseIn
    '
    Me.TpPhaseIn.Controls.Add(Me.LblNoPhaseIn)
    Me.TpPhaseIn.Controls.Add(Me.GroupBox8)
    Me.TpPhaseIn.Location = New System.Drawing.Point(4, 25)
    Me.TpPhaseIn.Name = "TpPhaseIn"
    Me.TpPhaseIn.Size = New System.Drawing.Size(728, 331)
    Me.TpPhaseIn.TabIndex = 5
    Me.TpPhaseIn.Text = "Phase In"
    Me.TpPhaseIn.UseVisualStyleBackColor = True
    '
    'LblNoPhaseIn
    '
    Me.LblNoPhaseIn.AutoSize = True
    Me.LblNoPhaseIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNoPhaseIn.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblNoPhaseIn.Location = New System.Drawing.Point(17, 263)
    Me.LblNoPhaseIn.Name = "LblNoPhaseIn"
    Me.LblNoPhaseIn.Size = New System.Drawing.Size(256, 15)
    Me.LblNoPhaseIn.TabIndex = 231
    Me.LblNoPhaseIn.Text = "This account is not part of the Phase In"
    Me.LblNoPhaseIn.Visible = False
    '
    'GroupBox8
    '
    Me.GroupBox8.Controls.Add(Me.LblTotAssmnt1)
    Me.GroupBox8.Controls.Add(Me.Label22)
    Me.GroupBox8.Controls.Add(Me.LblTot)
    Me.GroupBox8.Controls.Add(Me.Label11)
    Me.GroupBox8.Controls.Add(Me.LblAdjAssmnt7)
    Me.GroupBox8.Controls.Add(Me.LblAdjAssmnt6)
    Me.GroupBox8.Controls.Add(Me.LblAdjAssmnt5)
    Me.GroupBox8.Controls.Add(Me.LblAdjAssmnt4)
    Me.GroupBox8.Controls.Add(Me.LblAdjAssmnt3)
    Me.GroupBox8.Controls.Add(Me.LblAdjAssmnt2)
    Me.GroupBox8.Controls.Add(Me.LblAdjAssmnt1)
    Me.GroupBox8.Controls.Add(Me.LblAdjCode7)
    Me.GroupBox8.Controls.Add(Me.LblAdjCode6)
    Me.GroupBox8.Controls.Add(Me.LblAdjCode5)
    Me.GroupBox8.Controls.Add(Me.LblAdjCode4)
    Me.GroupBox8.Controls.Add(Me.LblAdjCode3)
    Me.GroupBox8.Controls.Add(Me.LblAdjCode2)
    Me.GroupBox8.Controls.Add(Me.Label48)
    Me.GroupBox8.Controls.Add(Me.LblAdjCode1)
    Me.GroupBox8.Controls.Add(Me.LblCurrGross)
    Me.GroupBox8.Controls.Add(Me.LblCurrAssmnt7)
    Me.GroupBox8.Controls.Add(Me.LblCurrAssmnt6)
    Me.GroupBox8.Controls.Add(Me.LblCurrAssmnt5)
    Me.GroupBox8.Controls.Add(Me.LblCurrAssmnt4)
    Me.GroupBox8.Controls.Add(Me.LblCurrAssmnt3)
    Me.GroupBox8.Controls.Add(Me.LblCurrAssmnt2)
    Me.GroupBox8.Controls.Add(Me.Label53)
    Me.GroupBox8.Controls.Add(Me.LblCurrAssmnt1)
    Me.GroupBox8.Controls.Add(Me.Label32)
    Me.GroupBox8.Controls.Add(Me.LblOrigGross)
    Me.GroupBox8.Controls.Add(Me.LblPhaseGross)
    Me.GroupBox8.Controls.Add(Me.LblFullGross)
    Me.GroupBox8.Controls.Add(Me.LblAdjGross)
    Me.GroupBox8.Controls.Add(Me.LblPhaseAssmnt7)
    Me.GroupBox8.Controls.Add(Me.LblPhaseCode7)
    Me.GroupBox8.Controls.Add(Me.LblTotAssmnt7)
    Me.GroupBox8.Controls.Add(Me.LblPhaseAssmnt6)
    Me.GroupBox8.Controls.Add(Me.LblPhaseCode6)
    Me.GroupBox8.Controls.Add(Me.LblTotAssmnt6)
    Me.GroupBox8.Controls.Add(Me.LblPhaseAssmnt5)
    Me.GroupBox8.Controls.Add(Me.LblPhaseCode5)
    Me.GroupBox8.Controls.Add(Me.LblTotAssmnt5)
    Me.GroupBox8.Controls.Add(Me.LblPhaseAssmnt4)
    Me.GroupBox8.Controls.Add(Me.LblPhaseCode4)
    Me.GroupBox8.Controls.Add(Me.LblTotAssmnt4)
    Me.GroupBox8.Controls.Add(Me.LblPhaseAssmnt3)
    Me.GroupBox8.Controls.Add(Me.LblPhaseCode3)
    Me.GroupBox8.Controls.Add(Me.LblTotAssmnt3)
    Me.GroupBox8.Controls.Add(Me.LblPhaseAssmnt2)
    Me.GroupBox8.Controls.Add(Me.LblPhaseCode2)
    Me.GroupBox8.Controls.Add(Me.LblTotAssmnt2)
    Me.GroupBox8.Controls.Add(Me.Label14)
    Me.GroupBox8.Controls.Add(Me.LblPhaseAssmnt1)
    Me.GroupBox8.Controls.Add(Me.Label18)
    Me.GroupBox8.Controls.Add(Me.LblPhaseCode1)
    Me.GroupBox8.Controls.Add(Me.Label19)
    Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox8.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox8.Location = New System.Drawing.Point(8, 16)
    Me.GroupBox8.Name = "GroupBox8"
    Me.GroupBox8.Size = New System.Drawing.Size(654, 231)
    Me.GroupBox8.TabIndex = 230
    Me.GroupBox8.TabStop = False
    Me.GroupBox8.Text = "Assessment Property Codes"
    '
    'LblCurrGross
    '
    Me.LblCurrGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCurrGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCurrGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCurrGross.ForeColor = System.Drawing.Color.Black
    Me.LblCurrGross.Location = New System.Drawing.Point(241, 199)
    Me.LblCurrGross.Name = "LblCurrGross"
    Me.LblCurrGross.Size = New System.Drawing.Size(72, 18)
    Me.LblCurrGross.TabIndex = 228
    Me.LblCurrGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCurrAssmnt7
    '
    Me.LblCurrAssmnt7.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCurrAssmnt7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCurrAssmnt7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCurrAssmnt7.ForeColor = System.Drawing.Color.Black
    Me.LblCurrAssmnt7.Location = New System.Drawing.Point(241, 167)
    Me.LblCurrAssmnt7.Name = "LblCurrAssmnt7"
    Me.LblCurrAssmnt7.Size = New System.Drawing.Size(73, 18)
    Me.LblCurrAssmnt7.TabIndex = 227
    Me.LblCurrAssmnt7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCurrAssmnt6
    '
    Me.LblCurrAssmnt6.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCurrAssmnt6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCurrAssmnt6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCurrAssmnt6.ForeColor = System.Drawing.Color.Black
    Me.LblCurrAssmnt6.Location = New System.Drawing.Point(241, 145)
    Me.LblCurrAssmnt6.Name = "LblCurrAssmnt6"
    Me.LblCurrAssmnt6.Size = New System.Drawing.Size(73, 18)
    Me.LblCurrAssmnt6.TabIndex = 226
    Me.LblCurrAssmnt6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCurrAssmnt5
    '
    Me.LblCurrAssmnt5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCurrAssmnt5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCurrAssmnt5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCurrAssmnt5.ForeColor = System.Drawing.Color.Black
    Me.LblCurrAssmnt5.Location = New System.Drawing.Point(241, 123)
    Me.LblCurrAssmnt5.Name = "LblCurrAssmnt5"
    Me.LblCurrAssmnt5.Size = New System.Drawing.Size(73, 18)
    Me.LblCurrAssmnt5.TabIndex = 225
    Me.LblCurrAssmnt5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCurrAssmnt4
    '
    Me.LblCurrAssmnt4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCurrAssmnt4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCurrAssmnt4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCurrAssmnt4.ForeColor = System.Drawing.Color.Black
    Me.LblCurrAssmnt4.Location = New System.Drawing.Point(241, 101)
    Me.LblCurrAssmnt4.Name = "LblCurrAssmnt4"
    Me.LblCurrAssmnt4.Size = New System.Drawing.Size(73, 18)
    Me.LblCurrAssmnt4.TabIndex = 224
    Me.LblCurrAssmnt4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCurrAssmnt3
    '
    Me.LblCurrAssmnt3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCurrAssmnt3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCurrAssmnt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCurrAssmnt3.ForeColor = System.Drawing.Color.Black
    Me.LblCurrAssmnt3.Location = New System.Drawing.Point(241, 79)
    Me.LblCurrAssmnt3.Name = "LblCurrAssmnt3"
    Me.LblCurrAssmnt3.Size = New System.Drawing.Size(73, 18)
    Me.LblCurrAssmnt3.TabIndex = 223
    Me.LblCurrAssmnt3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCurrAssmnt2
    '
    Me.LblCurrAssmnt2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCurrAssmnt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCurrAssmnt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCurrAssmnt2.ForeColor = System.Drawing.Color.Black
    Me.LblCurrAssmnt2.Location = New System.Drawing.Point(241, 57)
    Me.LblCurrAssmnt2.Name = "LblCurrAssmnt2"
    Me.LblCurrAssmnt2.Size = New System.Drawing.Size(73, 18)
    Me.LblCurrAssmnt2.TabIndex = 222
    Me.LblCurrAssmnt2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label53
    '
    Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label53.ForeColor = System.Drawing.Color.Black
    Me.Label53.Location = New System.Drawing.Point(246, 17)
    Me.Label53.Name = "Label53"
    Me.Label53.Size = New System.Drawing.Size(68, 16)
    Me.Label53.TabIndex = 221
    Me.Label53.Text = "Current"
    Me.Ttp1.SetToolTip(Me.Label53, "Assessment in Frozen now")
    '
    'LblCurrAssmnt1
    '
    Me.LblCurrAssmnt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCurrAssmnt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCurrAssmnt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCurrAssmnt1.ForeColor = System.Drawing.Color.Black
    Me.LblCurrAssmnt1.Location = New System.Drawing.Point(242, 33)
    Me.LblCurrAssmnt1.Name = "LblCurrAssmnt1"
    Me.LblCurrAssmnt1.Size = New System.Drawing.Size(72, 18)
    Me.LblCurrAssmnt1.TabIndex = 220
    Me.LblCurrAssmnt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label32
    '
    Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label32.ForeColor = System.Drawing.Color.Black
    Me.Label32.Location = New System.Drawing.Point(36, 184)
    Me.Label32.Name = "Label32"
    Me.Label32.Size = New System.Drawing.Size(68, 16)
    Me.Label32.TabIndex = 219
    Me.Label32.Text = "Orig Value"
    Me.Ttp1.SetToolTip(Me.Label32, "Assessment at Freeze Time")
    '
    'LblOrigGross
    '
    Me.LblOrigGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigGross.ForeColor = System.Drawing.Color.Black
    Me.LblOrigGross.Location = New System.Drawing.Point(32, 200)
    Me.LblOrigGross.Name = "LblOrigGross"
    Me.LblOrigGross.Size = New System.Drawing.Size(72, 18)
    Me.LblOrigGross.TabIndex = 218
    Me.LblOrigGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblPhaseGross
    '
    Me.LblPhaseGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPhaseGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPhaseGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPhaseGross.ForeColor = System.Drawing.Color.Black
    Me.LblPhaseGross.Location = New System.Drawing.Point(163, 198)
    Me.LblPhaseGross.Name = "LblPhaseGross"
    Me.LblPhaseGross.Size = New System.Drawing.Size(72, 18)
    Me.LblPhaseGross.TabIndex = 216
    Me.LblPhaseGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblFullGross
    '
    Me.LblFullGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblFullGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblFullGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFullGross.ForeColor = System.Drawing.Color.Black
    Me.LblFullGross.Location = New System.Drawing.Point(542, 198)
    Me.LblFullGross.Name = "LblFullGross"
    Me.LblFullGross.Size = New System.Drawing.Size(72, 18)
    Me.LblFullGross.TabIndex = 215
    Me.LblFullGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblAdjGross
    '
    Me.LblAdjGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAdjGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAdjGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAdjGross.ForeColor = System.Drawing.Color.Black
    Me.LblAdjGross.Location = New System.Drawing.Point(367, 198)
    Me.LblAdjGross.Name = "LblAdjGross"
    Me.LblAdjGross.Size = New System.Drawing.Size(72, 18)
    Me.LblAdjGross.TabIndex = 214
    Me.LblAdjGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblPhaseAssmnt7
    '
    Me.LblPhaseAssmnt7.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPhaseAssmnt7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPhaseAssmnt7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPhaseAssmnt7.ForeColor = System.Drawing.Color.Black
    Me.LblPhaseAssmnt7.Location = New System.Drawing.Point(163, 166)
    Me.LblPhaseAssmnt7.Name = "LblPhaseAssmnt7"
    Me.LblPhaseAssmnt7.Size = New System.Drawing.Size(73, 18)
    Me.LblPhaseAssmnt7.TabIndex = 213
    Me.LblPhaseAssmnt7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblPhaseCode7
    '
    Me.LblPhaseCode7.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPhaseCode7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPhaseCode7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPhaseCode7.ForeColor = System.Drawing.Color.Black
    Me.LblPhaseCode7.Location = New System.Drawing.Point(126, 166)
    Me.LblPhaseCode7.Name = "LblPhaseCode7"
    Me.LblPhaseCode7.Size = New System.Drawing.Size(31, 18)
    Me.LblPhaseCode7.TabIndex = 212
    Me.LblPhaseCode7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotAssmnt7
    '
    Me.LblTotAssmnt7.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotAssmnt7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTotAssmnt7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotAssmnt7.ForeColor = System.Drawing.Color.Black
    Me.LblTotAssmnt7.Location = New System.Drawing.Point(459, 166)
    Me.LblTotAssmnt7.Name = "LblTotAssmnt7"
    Me.LblTotAssmnt7.Size = New System.Drawing.Size(72, 18)
    Me.LblTotAssmnt7.TabIndex = 211
    Me.LblTotAssmnt7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblPhaseAssmnt6
    '
    Me.LblPhaseAssmnt6.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPhaseAssmnt6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPhaseAssmnt6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPhaseAssmnt6.ForeColor = System.Drawing.Color.Black
    Me.LblPhaseAssmnt6.Location = New System.Drawing.Point(163, 144)
    Me.LblPhaseAssmnt6.Name = "LblPhaseAssmnt6"
    Me.LblPhaseAssmnt6.Size = New System.Drawing.Size(73, 18)
    Me.LblPhaseAssmnt6.TabIndex = 209
    Me.LblPhaseAssmnt6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblPhaseCode6
    '
    Me.LblPhaseCode6.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPhaseCode6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPhaseCode6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPhaseCode6.ForeColor = System.Drawing.Color.Black
    Me.LblPhaseCode6.Location = New System.Drawing.Point(126, 144)
    Me.LblPhaseCode6.Name = "LblPhaseCode6"
    Me.LblPhaseCode6.Size = New System.Drawing.Size(31, 18)
    Me.LblPhaseCode6.TabIndex = 208
    Me.LblPhaseCode6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotAssmnt6
    '
    Me.LblTotAssmnt6.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotAssmnt6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTotAssmnt6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotAssmnt6.ForeColor = System.Drawing.Color.Black
    Me.LblTotAssmnt6.Location = New System.Drawing.Point(459, 144)
    Me.LblTotAssmnt6.Name = "LblTotAssmnt6"
    Me.LblTotAssmnt6.Size = New System.Drawing.Size(72, 18)
    Me.LblTotAssmnt6.TabIndex = 207
    Me.LblTotAssmnt6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblPhaseAssmnt5
    '
    Me.LblPhaseAssmnt5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPhaseAssmnt5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPhaseAssmnt5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPhaseAssmnt5.ForeColor = System.Drawing.Color.Black
    Me.LblPhaseAssmnt5.Location = New System.Drawing.Point(163, 122)
    Me.LblPhaseAssmnt5.Name = "LblPhaseAssmnt5"
    Me.LblPhaseAssmnt5.Size = New System.Drawing.Size(73, 18)
    Me.LblPhaseAssmnt5.TabIndex = 205
    Me.LblPhaseAssmnt5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblPhaseCode5
    '
    Me.LblPhaseCode5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPhaseCode5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPhaseCode5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPhaseCode5.ForeColor = System.Drawing.Color.Black
    Me.LblPhaseCode5.Location = New System.Drawing.Point(126, 122)
    Me.LblPhaseCode5.Name = "LblPhaseCode5"
    Me.LblPhaseCode5.Size = New System.Drawing.Size(31, 18)
    Me.LblPhaseCode5.TabIndex = 204
    Me.LblPhaseCode5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotAssmnt5
    '
    Me.LblTotAssmnt5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotAssmnt5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTotAssmnt5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotAssmnt5.ForeColor = System.Drawing.Color.Black
    Me.LblTotAssmnt5.Location = New System.Drawing.Point(459, 122)
    Me.LblTotAssmnt5.Name = "LblTotAssmnt5"
    Me.LblTotAssmnt5.Size = New System.Drawing.Size(72, 18)
    Me.LblTotAssmnt5.TabIndex = 203
    Me.LblTotAssmnt5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblPhaseAssmnt4
    '
    Me.LblPhaseAssmnt4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPhaseAssmnt4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPhaseAssmnt4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPhaseAssmnt4.ForeColor = System.Drawing.Color.Black
    Me.LblPhaseAssmnt4.Location = New System.Drawing.Point(163, 100)
    Me.LblPhaseAssmnt4.Name = "LblPhaseAssmnt4"
    Me.LblPhaseAssmnt4.Size = New System.Drawing.Size(73, 18)
    Me.LblPhaseAssmnt4.TabIndex = 201
    Me.LblPhaseAssmnt4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblPhaseCode4
    '
    Me.LblPhaseCode4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPhaseCode4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPhaseCode4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPhaseCode4.ForeColor = System.Drawing.Color.Black
    Me.LblPhaseCode4.Location = New System.Drawing.Point(126, 100)
    Me.LblPhaseCode4.Name = "LblPhaseCode4"
    Me.LblPhaseCode4.Size = New System.Drawing.Size(31, 18)
    Me.LblPhaseCode4.TabIndex = 200
    Me.LblPhaseCode4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotAssmnt4
    '
    Me.LblTotAssmnt4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotAssmnt4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTotAssmnt4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotAssmnt4.ForeColor = System.Drawing.Color.Black
    Me.LblTotAssmnt4.Location = New System.Drawing.Point(459, 100)
    Me.LblTotAssmnt4.Name = "LblTotAssmnt4"
    Me.LblTotAssmnt4.Size = New System.Drawing.Size(72, 18)
    Me.LblTotAssmnt4.TabIndex = 199
    Me.LblTotAssmnt4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblPhaseAssmnt3
    '
    Me.LblPhaseAssmnt3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPhaseAssmnt3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPhaseAssmnt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPhaseAssmnt3.ForeColor = System.Drawing.Color.Black
    Me.LblPhaseAssmnt3.Location = New System.Drawing.Point(163, 78)
    Me.LblPhaseAssmnt3.Name = "LblPhaseAssmnt3"
    Me.LblPhaseAssmnt3.Size = New System.Drawing.Size(73, 18)
    Me.LblPhaseAssmnt3.TabIndex = 197
    Me.LblPhaseAssmnt3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblPhaseCode3
    '
    Me.LblPhaseCode3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPhaseCode3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPhaseCode3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPhaseCode3.ForeColor = System.Drawing.Color.Black
    Me.LblPhaseCode3.Location = New System.Drawing.Point(126, 78)
    Me.LblPhaseCode3.Name = "LblPhaseCode3"
    Me.LblPhaseCode3.Size = New System.Drawing.Size(31, 18)
    Me.LblPhaseCode3.TabIndex = 196
    Me.LblPhaseCode3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotAssmnt3
    '
    Me.LblTotAssmnt3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotAssmnt3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTotAssmnt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotAssmnt3.ForeColor = System.Drawing.Color.Black
    Me.LblTotAssmnt3.Location = New System.Drawing.Point(459, 78)
    Me.LblTotAssmnt3.Name = "LblTotAssmnt3"
    Me.LblTotAssmnt3.Size = New System.Drawing.Size(72, 18)
    Me.LblTotAssmnt3.TabIndex = 195
    Me.LblTotAssmnt3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblPhaseAssmnt2
    '
    Me.LblPhaseAssmnt2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPhaseAssmnt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPhaseAssmnt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPhaseAssmnt2.ForeColor = System.Drawing.Color.Black
    Me.LblPhaseAssmnt2.Location = New System.Drawing.Point(163, 56)
    Me.LblPhaseAssmnt2.Name = "LblPhaseAssmnt2"
    Me.LblPhaseAssmnt2.Size = New System.Drawing.Size(73, 18)
    Me.LblPhaseAssmnt2.TabIndex = 193
    Me.LblPhaseAssmnt2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblPhaseCode2
    '
    Me.LblPhaseCode2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPhaseCode2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPhaseCode2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPhaseCode2.ForeColor = System.Drawing.Color.Black
    Me.LblPhaseCode2.Location = New System.Drawing.Point(126, 56)
    Me.LblPhaseCode2.Name = "LblPhaseCode2"
    Me.LblPhaseCode2.Size = New System.Drawing.Size(31, 18)
    Me.LblPhaseCode2.TabIndex = 192
    Me.LblPhaseCode2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotAssmnt2
    '
    Me.LblTotAssmnt2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotAssmnt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTotAssmnt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotAssmnt2.ForeColor = System.Drawing.Color.Black
    Me.LblTotAssmnt2.Location = New System.Drawing.Point(459, 56)
    Me.LblTotAssmnt2.Name = "LblTotAssmnt2"
    Me.LblTotAssmnt2.Size = New System.Drawing.Size(72, 18)
    Me.LblTotAssmnt2.TabIndex = 191
    Me.LblTotAssmnt2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label14
    '
    Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label14.ForeColor = System.Drawing.Color.Black
    Me.Label14.Location = New System.Drawing.Point(168, 16)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(68, 16)
    Me.Label14.TabIndex = 189
    Me.Label14.Text = "Phase In"
    Me.Ttp1.SetToolTip(Me.Label14, "Assessment in Frozen now")
    '
    'LblPhaseAssmnt1
    '
    Me.LblPhaseAssmnt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPhaseAssmnt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPhaseAssmnt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPhaseAssmnt1.ForeColor = System.Drawing.Color.Black
    Me.LblPhaseAssmnt1.Location = New System.Drawing.Point(164, 32)
    Me.LblPhaseAssmnt1.Name = "LblPhaseAssmnt1"
    Me.LblPhaseAssmnt1.Size = New System.Drawing.Size(72, 18)
    Me.LblPhaseAssmnt1.TabIndex = 188
    Me.LblPhaseAssmnt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label18
    '
    Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label18.ForeColor = System.Drawing.Color.Black
    Me.Label18.Location = New System.Drawing.Point(123, 16)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(40, 16)
    Me.Label18.TabIndex = 187
    Me.Label18.Text = "Code"
    '
    'LblPhaseCode1
    '
    Me.LblPhaseCode1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPhaseCode1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPhaseCode1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPhaseCode1.ForeColor = System.Drawing.Color.Black
    Me.LblPhaseCode1.Location = New System.Drawing.Point(127, 32)
    Me.LblPhaseCode1.Name = "LblPhaseCode1"
    Me.LblPhaseCode1.Size = New System.Drawing.Size(31, 18)
    Me.LblPhaseCode1.TabIndex = 186
    Me.LblPhaseCode1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label19
    '
    Me.Label19.AutoSize = True
    Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label19.ForeColor = System.Drawing.Color.Black
    Me.Label19.Location = New System.Drawing.Point(458, 16)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(75, 13)
    Me.Label19.TabIndex = 185
    Me.Label19.Text = "Phase Total"
    Me.Ttp1.SetToolTip(Me.Label19, "Assessment at Freeze Time")
    '
    'LblTotAssmnt1
    '
    Me.LblTotAssmnt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotAssmnt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTotAssmnt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotAssmnt1.ForeColor = System.Drawing.Color.Black
    Me.LblTotAssmnt1.Location = New System.Drawing.Point(460, 32)
    Me.LblTotAssmnt1.Name = "LblTotAssmnt1"
    Me.LblTotAssmnt1.Size = New System.Drawing.Size(71, 18)
    Me.LblTotAssmnt1.TabIndex = 184
    Me.LblTotAssmnt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.LblBaaNet)
    Me.GroupBox2.Controls.Add(Me.Label12)
    Me.GroupBox2.Controls.Add(Me.LblNet)
    Me.GroupBox2.Controls.Add(Me.Label34)
    Me.GroupBox2.Controls.Add(Me.LblExempt)
    Me.GroupBox2.Controls.Add(Me.LblGross)
    Me.GroupBox2.Controls.Add(Me.LblBaa)
    Me.GroupBox2.Controls.Add(Me.Label30)
    Me.GroupBox2.Controls.Add(Me.Label29)
    Me.GroupBox2.Controls.Add(Me.Label28)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(570, 36)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(150, 112)
    Me.GroupBox2.TabIndex = 143
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Totals"
    '
    'LblBaaNet
    '
    Me.LblBaaNet.BackColor = System.Drawing.Color.Aqua
    Me.LblBaaNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblBaaNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBaaNet.Location = New System.Drawing.Point(76, 88)
    Me.LblBaaNet.Name = "LblBaaNet"
    Me.LblBaaNet.Size = New System.Drawing.Size(64, 16)
    Me.LblBaaNet.TabIndex = 23
    Me.LblBaaNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label12
    '
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(8, 88)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(48, 16)
    Me.Label12.TabIndex = 22
    Me.Label12.Text = "BAA Net"
    '
    'LblNet
    '
    Me.LblNet.BackColor = System.Drawing.Color.Aqua
    Me.LblNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNet.Location = New System.Drawing.Point(76, 48)
    Me.LblNet.Name = "LblNet"
    Me.LblNet.Size = New System.Drawing.Size(64, 16)
    Me.LblNet.TabIndex = 21
    Me.LblNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label34
    '
    Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label34.Location = New System.Drawing.Point(8, 48)
    Me.Label34.Name = "Label34"
    Me.Label34.Size = New System.Drawing.Size(48, 16)
    Me.Label34.TabIndex = 20
    Me.Label34.Text = "Net"
    '
    'LblExempt
    '
    Me.LblExempt.BackColor = System.Drawing.Color.Aqua
    Me.LblExempt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExempt.Location = New System.Drawing.Point(76, 32)
    Me.LblExempt.Name = "LblExempt"
    Me.LblExempt.Size = New System.Drawing.Size(64, 16)
    Me.LblExempt.TabIndex = 19
    Me.LblExempt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblGross
    '
    Me.LblGross.BackColor = System.Drawing.Color.Aqua
    Me.LblGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblGross.Location = New System.Drawing.Point(76, 16)
    Me.LblGross.Name = "LblGross"
    Me.LblGross.Size = New System.Drawing.Size(64, 16)
    Me.LblGross.TabIndex = 18
    Me.LblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblBaa
    '
    Me.LblBaa.BackColor = System.Drawing.Color.Aqua
    Me.LblBaa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblBaa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBaa.Location = New System.Drawing.Point(76, 72)
    Me.LblBaa.Name = "LblBaa"
    Me.LblBaa.Size = New System.Drawing.Size(64, 16)
    Me.LblBaa.TabIndex = 17
    Me.LblBaa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label30
    '
    Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label30.Location = New System.Drawing.Point(8, 32)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(63, 16)
    Me.Label30.TabIndex = 16
    Me.Label30.Text = "Exemption"
    '
    'Label29
    '
    Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label29.Location = New System.Drawing.Point(8, 16)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(40, 16)
    Me.Label29.TabIndex = 15
    Me.Label29.Text = "Gross"
    '
    'Label28
    '
    Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label28.Location = New System.Drawing.Point(8, 72)
    Me.Label28.Name = "Label28"
    Me.Label28.Size = New System.Drawing.Size(40, 16)
    Me.Label28.TabIndex = 14
    Me.Label28.Text = "B.A.A"
    '
    'TxtZip4
    '
    Me.TxtZip4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip4.Location = New System.Drawing.Point(398, 128)
    Me.TxtZip4.MaxLength = 4
    Me.TxtZip4.Name = "TxtZip4"
    Me.TxtZip4.Size = New System.Drawing.Size(42, 22)
    Me.TxtZip4.TabIndex = 8
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(96, 128)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(210, 22)
    Me.TxtCity.TabIndex = 5
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(312, 128)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 22)
    Me.TxtState.TabIndex = 6
    '
    'TxtAdd2
    '
    Me.TxtAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd2.Location = New System.Drawing.Point(96, 104)
    Me.TxtAdd2.MaxLength = 35
    Me.TxtAdd2.Name = "TxtAdd2"
    Me.TxtAdd2.Size = New System.Drawing.Size(288, 22)
    Me.TxtAdd2.TabIndex = 4
    '
    'TxtAdd1
    '
    Me.TxtAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd1.Location = New System.Drawing.Point(96, 80)
    Me.TxtAdd1.MaxLength = 35
    Me.TxtAdd1.Name = "TxtAdd1"
    Me.TxtAdd1.Size = New System.Drawing.Size(288, 22)
    Me.TxtAdd1.TabIndex = 3
    '
    'TxtSname
    '
    Me.TxtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSname.Location = New System.Drawing.Point(96, 56)
    Me.TxtSname.MaxLength = 35
    Me.TxtSname.Name = "TxtSname"
    Me.TxtSname.Size = New System.Drawing.Size(288, 22)
    Me.TxtSname.TabIndex = 2
    '
    'TxtZip5
    '
    Me.TxtZip5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip5.Location = New System.Drawing.Point(344, 128)
    Me.TxtZip5.MaxLength = 5
    Me.TxtZip5.Name = "TxtZip5"
    Me.TxtZip5.Size = New System.Drawing.Size(48, 22)
    Me.TxtZip5.TabIndex = 7
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(8, 128)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(74, 13)
    Me.Label4.TabIndex = 142
    Me.Label4.Text = "City/State/Zip"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(8, 80)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(76, 13)
    Me.Label3.TabIndex = 141
    Me.Label3.Text = "Street Address"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(8, 56)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(75, 13)
    Me.Label2.TabIndex = 140
    Me.Label2.Text = "Second Name"
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(96, 8)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(61, 22)
    Me.TxtListNo.TabIndex = 0
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(96, 32)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(288, 22)
    Me.TxtName.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(8, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 13)
    Me.Label1.TabIndex = 139
    Me.Label1.Text = "List No"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(8, 32)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(35, 13)
    Me.Label5.TabIndex = 138
    Me.Label5.Text = "Name"
    '
    'LblSoftFreeze
    '
    Me.LblSoftFreeze.AutoSize = True
    Me.LblSoftFreeze.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblSoftFreeze.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblSoftFreeze.Location = New System.Drawing.Point(163, 12)
    Me.LblSoftFreeze.Name = "LblSoftFreeze"
    Me.LblSoftFreeze.Size = New System.Drawing.Size(324, 13)
    Me.LblSoftFreeze.TabIndex = 144
    Me.LblSoftFreeze.Text = "* Soft Freeze - Only BAA && Transfer data will be saved *"
    Me.LblSoftFreeze.Visible = False
    '
    'LblElderly
    '
    Me.LblElderly.AutoSize = True
    Me.LblElderly.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblElderly.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblElderly.Location = New System.Drawing.Point(506, 78)
    Me.LblElderly.Name = "LblElderly"
    Me.LblElderly.Size = New System.Drawing.Size(55, 15)
    Me.LblElderly.TabIndex = 145
    Me.LblElderly.Text = "Elderly "
    Me.LblElderly.Visible = False
    '
    'BtnNext
    '
    Me.BtnNext.ForeColor = System.Drawing.Color.Black
    Me.BtnNext.Location = New System.Drawing.Point(672, 6)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(60, 24)
    Me.BtnNext.TabIndex = 174
    Me.BtnNext.Text = "&Next"
    '
    'BtnPrevious
    '
    Me.BtnPrevious.ForeColor = System.Drawing.Color.Black
    Me.BtnPrevious.Location = New System.Drawing.Point(606, 6)
    Me.BtnPrevious.Name = "BtnPrevious"
    Me.BtnPrevious.Size = New System.Drawing.Size(60, 24)
    Me.BtnPrevious.TabIndex = 173
    Me.BtnPrevious.Text = "&Previous"
    '
    'LblLocalBen
    '
    Me.LblLocalBen.AutoSize = True
    Me.LblLocalBen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocalBen.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblLocalBen.Location = New System.Drawing.Point(470, 98)
    Me.LblLocalBen.Name = "LblLocalBen"
    Me.LblLocalBen.Size = New System.Drawing.Size(91, 15)
    Me.LblLocalBen.TabIndex = 175
    Me.LblLocalBen.Text = "Local Benefit"
    Me.LblLocalBen.Visible = False
    '
    'LblComments
    '
    Me.LblComments.AutoSize = True
    Me.LblComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblComments.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblComments.Location = New System.Drawing.Point(495, 10)
    Me.LblComments.Name = "LblComments"
    Me.LblComments.Size = New System.Drawing.Size(95, 15)
    Me.LblComments.TabIndex = 195
    Me.LblComments.Text = "* Comments *"
    Me.LblComments.Visible = False
    '
    'LblTaxExempt
    '
    Me.LblTaxExempt.AutoSize = True
    Me.LblTaxExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTaxExempt.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblTaxExempt.Location = New System.Drawing.Point(479, 58)
    Me.LblTaxExempt.Name = "LblTaxExempt"
    Me.LblTaxExempt.Size = New System.Drawing.Size(82, 15)
    Me.LblTaxExempt.TabIndex = 196
    Me.LblTaxExempt.Text = "Tax Exempt"
    Me.LblTaxExempt.Visible = False
    '
    'LblSewer
    '
    Me.LblSewer.AutoSize = True
    Me.LblSewer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblSewer.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblSewer.Location = New System.Drawing.Point(514, 118)
    Me.LblSewer.Name = "LblSewer"
    Me.LblSewer.Size = New System.Drawing.Size(47, 15)
    Me.LblSewer.TabIndex = 197
    Me.LblSewer.Text = "Sewer"
    Me.LblSewer.Visible = False
    '
    'LblBeforeCC
    '
    Me.LblBeforeCC.AutoSize = True
    Me.LblBeforeCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBeforeCC.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblBeforeCC.Location = New System.Drawing.Point(417, 36)
    Me.LblBeforeCC.Name = "LblBeforeCC"
    Me.LblBeforeCC.Size = New System.Drawing.Size(144, 15)
    Me.LblBeforeCC.TabIndex = 199
    Me.LblBeforeCC.Text = "Before Bill C/C #####"
    Me.LblBeforeCC.TextAlign = System.Drawing.ContentAlignment.TopRight
    Me.LblBeforeCC.Visible = False
    '
    'LblAdjCode7
    '
    Me.LblAdjCode7.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAdjCode7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAdjCode7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAdjCode7.ForeColor = System.Drawing.Color.Black
    Me.LblAdjCode7.Location = New System.Drawing.Point(329, 166)
    Me.LblAdjCode7.Name = "LblAdjCode7"
    Me.LblAdjCode7.Size = New System.Drawing.Size(31, 18)
    Me.LblAdjCode7.TabIndex = 236
    Me.LblAdjCode7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblAdjCode6
    '
    Me.LblAdjCode6.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAdjCode6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAdjCode6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAdjCode6.ForeColor = System.Drawing.Color.Black
    Me.LblAdjCode6.Location = New System.Drawing.Point(329, 144)
    Me.LblAdjCode6.Name = "LblAdjCode6"
    Me.LblAdjCode6.Size = New System.Drawing.Size(31, 18)
    Me.LblAdjCode6.TabIndex = 235
    Me.LblAdjCode6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblAdjCode5
    '
    Me.LblAdjCode5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAdjCode5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAdjCode5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAdjCode5.ForeColor = System.Drawing.Color.Black
    Me.LblAdjCode5.Location = New System.Drawing.Point(329, 122)
    Me.LblAdjCode5.Name = "LblAdjCode5"
    Me.LblAdjCode5.Size = New System.Drawing.Size(31, 18)
    Me.LblAdjCode5.TabIndex = 234
    Me.LblAdjCode5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblAdjCode4
    '
    Me.LblAdjCode4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAdjCode4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAdjCode4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAdjCode4.ForeColor = System.Drawing.Color.Black
    Me.LblAdjCode4.Location = New System.Drawing.Point(329, 100)
    Me.LblAdjCode4.Name = "LblAdjCode4"
    Me.LblAdjCode4.Size = New System.Drawing.Size(31, 18)
    Me.LblAdjCode4.TabIndex = 233
    Me.LblAdjCode4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblAdjCode3
    '
    Me.LblAdjCode3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAdjCode3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAdjCode3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAdjCode3.ForeColor = System.Drawing.Color.Black
    Me.LblAdjCode3.Location = New System.Drawing.Point(329, 78)
    Me.LblAdjCode3.Name = "LblAdjCode3"
    Me.LblAdjCode3.Size = New System.Drawing.Size(31, 18)
    Me.LblAdjCode3.TabIndex = 232
    Me.LblAdjCode3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblAdjCode2
    '
    Me.LblAdjCode2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAdjCode2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAdjCode2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAdjCode2.ForeColor = System.Drawing.Color.Black
    Me.LblAdjCode2.Location = New System.Drawing.Point(329, 56)
    Me.LblAdjCode2.Name = "LblAdjCode2"
    Me.LblAdjCode2.Size = New System.Drawing.Size(31, 18)
    Me.LblAdjCode2.TabIndex = 231
    Me.LblAdjCode2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label48
    '
    Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label48.ForeColor = System.Drawing.Color.Black
    Me.Label48.Location = New System.Drawing.Point(326, 16)
    Me.Label48.Name = "Label48"
    Me.Label48.Size = New System.Drawing.Size(40, 16)
    Me.Label48.TabIndex = 230
    Me.Label48.Text = "Code"
    '
    'LblAdjCode1
    '
    Me.LblAdjCode1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAdjCode1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAdjCode1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAdjCode1.ForeColor = System.Drawing.Color.Black
    Me.LblAdjCode1.Location = New System.Drawing.Point(330, 32)
    Me.LblAdjCode1.Name = "LblAdjCode1"
    Me.LblAdjCode1.Size = New System.Drawing.Size(31, 18)
    Me.LblAdjCode1.TabIndex = 229
    Me.LblAdjCode1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblAdjAssmnt7
    '
    Me.LblAdjAssmnt7.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAdjAssmnt7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAdjAssmnt7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAdjAssmnt7.ForeColor = System.Drawing.Color.Black
    Me.LblAdjAssmnt7.Location = New System.Drawing.Point(366, 166)
    Me.LblAdjAssmnt7.Name = "LblAdjAssmnt7"
    Me.LblAdjAssmnt7.Size = New System.Drawing.Size(73, 18)
    Me.LblAdjAssmnt7.TabIndex = 243
    Me.LblAdjAssmnt7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblAdjAssmnt6
    '
    Me.LblAdjAssmnt6.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAdjAssmnt6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAdjAssmnt6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAdjAssmnt6.ForeColor = System.Drawing.Color.Black
    Me.LblAdjAssmnt6.Location = New System.Drawing.Point(366, 144)
    Me.LblAdjAssmnt6.Name = "LblAdjAssmnt6"
    Me.LblAdjAssmnt6.Size = New System.Drawing.Size(73, 18)
    Me.LblAdjAssmnt6.TabIndex = 242
    Me.LblAdjAssmnt6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblAdjAssmnt5
    '
    Me.LblAdjAssmnt5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAdjAssmnt5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAdjAssmnt5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAdjAssmnt5.ForeColor = System.Drawing.Color.Black
    Me.LblAdjAssmnt5.Location = New System.Drawing.Point(366, 122)
    Me.LblAdjAssmnt5.Name = "LblAdjAssmnt5"
    Me.LblAdjAssmnt5.Size = New System.Drawing.Size(73, 18)
    Me.LblAdjAssmnt5.TabIndex = 241
    Me.LblAdjAssmnt5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblAdjAssmnt4
    '
    Me.LblAdjAssmnt4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAdjAssmnt4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAdjAssmnt4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAdjAssmnt4.ForeColor = System.Drawing.Color.Black
    Me.LblAdjAssmnt4.Location = New System.Drawing.Point(366, 100)
    Me.LblAdjAssmnt4.Name = "LblAdjAssmnt4"
    Me.LblAdjAssmnt4.Size = New System.Drawing.Size(73, 18)
    Me.LblAdjAssmnt4.TabIndex = 240
    Me.LblAdjAssmnt4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblAdjAssmnt3
    '
    Me.LblAdjAssmnt3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAdjAssmnt3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAdjAssmnt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAdjAssmnt3.ForeColor = System.Drawing.Color.Black
    Me.LblAdjAssmnt3.Location = New System.Drawing.Point(366, 78)
    Me.LblAdjAssmnt3.Name = "LblAdjAssmnt3"
    Me.LblAdjAssmnt3.Size = New System.Drawing.Size(73, 18)
    Me.LblAdjAssmnt3.TabIndex = 239
    Me.LblAdjAssmnt3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblAdjAssmnt2
    '
    Me.LblAdjAssmnt2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAdjAssmnt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAdjAssmnt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAdjAssmnt2.ForeColor = System.Drawing.Color.Black
    Me.LblAdjAssmnt2.Location = New System.Drawing.Point(366, 56)
    Me.LblAdjAssmnt2.Name = "LblAdjAssmnt2"
    Me.LblAdjAssmnt2.Size = New System.Drawing.Size(73, 18)
    Me.LblAdjAssmnt2.TabIndex = 238
    Me.LblAdjAssmnt2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblAdjAssmnt1
    '
    Me.LblAdjAssmnt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAdjAssmnt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAdjAssmnt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAdjAssmnt1.ForeColor = System.Drawing.Color.Black
    Me.LblAdjAssmnt1.Location = New System.Drawing.Point(367, 32)
    Me.LblAdjAssmnt1.Name = "LblAdjAssmnt1"
    Me.LblAdjAssmnt1.Size = New System.Drawing.Size(72, 18)
    Me.LblAdjAssmnt1.TabIndex = 237
    Me.LblAdjAssmnt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label11
    '
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.ForeColor = System.Drawing.Color.Black
    Me.Label11.Location = New System.Drawing.Point(546, 16)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(68, 16)
    Me.Label11.TabIndex = 244
    Me.Label11.Text = "Full Value"
    Me.Ttp1.SetToolTip(Me.Label11, "Assessment at Freeze Time")
    '
    'LblTot
    '
    Me.LblTot.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTot.ForeColor = System.Drawing.Color.Black
    Me.LblTot.Location = New System.Drawing.Point(459, 198)
    Me.LblTot.Name = "LblTot"
    Me.LblTot.Size = New System.Drawing.Size(72, 18)
    Me.LblTot.TabIndex = 245
    Me.LblTot.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label22
    '
    Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label22.ForeColor = System.Drawing.Color.Black
    Me.Label22.Location = New System.Drawing.Point(371, 16)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(68, 16)
    Me.Label22.TabIndex = 246
    Me.Label22.Text = "Adjusted"
    Me.Ttp1.SetToolTip(Me.Label22, "Assessment at Freeze Time")
    '
    'FrmTA001RE
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(736, 518)
    Me.Controls.Add(Me.LblBeforeCC)
    Me.Controls.Add(Me.LblSewer)
    Me.Controls.Add(Me.LblTaxExempt)
    Me.Controls.Add(Me.LblComments)
    Me.Controls.Add(Me.LblLocalBen)
    Me.Controls.Add(Me.BtnNext)
    Me.Controls.Add(Me.BtnPrevious)
    Me.Controls.Add(Me.LblElderly)
    Me.Controls.Add(Me.LblSoftFreeze)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.TxtZip4)
    Me.Controls.Add(Me.TxtCity)
    Me.Controls.Add(Me.TxtState)
    Me.Controls.Add(Me.TxtAdd2)
    Me.Controls.Add(Me.TxtAdd1)
    Me.Controls.Add(Me.TxtSname)
    Me.Controls.Add(Me.TxtZip5)
    Me.Controls.Add(Me.TxtListNo)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TabControl1)
    Me.ForeColor = System.Drawing.Color.Black
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA001RE"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Real Estate"
    Me.TabControl1.ResumeLayout(False)
    Me.TpMain.ResumeLayout(False)
    Me.TpMain.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.TpEld.ResumeLayout(False)
    Me.GroupBox7.ResumeLayout(False)
    Me.GroupBox7.PerformLayout()
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    Me.TpTran.ResumeLayout(False)
    Me.TpTran.PerformLayout()
    Me.GroupBox6.ResumeLayout(False)
    Me.GroupBox6.PerformLayout()
    Me.TpPz.ResumeLayout(False)
    Me.TpPz.PerformLayout()
    Me.TpAct490.ResumeLayout(False)
    Me.TpAct490.PerformLayout()
    Me.TpPhaseIn.ResumeLayout(False)
    Me.TpPhaseIn.PerformLayout()
    Me.GroupBox8.ResumeLayout(False)
    Me.GroupBox8.PerformLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTA001RE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXREAL = New TXREAL.MyData(myDBConnect)
    myTXREALC = New TXREALC.MyData(myDBConnect)
    myTXBTR = New TXBTR.MyData(myDBConnect)
    myTXBTRC = New TXBTRC.MyData(myDBConnect)
    myTXTRANS = New TXTRANS.MyData(myDBConnect)
    myTXPZ = New TXPZ.MyData(myDBConnect)
    myTXPHIN = New TXPHIN.MyData(myDBConnect)
    myTXHOME = New TXHOME.MyData(myDBConnect)
    myTXNCAM = New TXNCAM.MyData(myDBConnect)
    myUTCUST = New UTCUST.MyData(myDBConnect)
    myTAXCOM = New TAXCOM.MyData(myDBConnect)
    myLOGRE = New LOGRE.MyData(myDBConnect)

    If WrkListNo = 0 Then
      Me.Text = "Add " & Me.Text
    Else
      Me.Text = "Maintain " & Me.Text
    End If
    LoadForm()

  End Sub

  Private Sub FrmTA001RE_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTA001.TBarNew.Enabled = True
    MyFrmTA001.TBarSave.Enabled = False
    MyFrmTA001.TBarDelete.Enabled = False
    MyFrmTA001.TBarLog.Enabled = False
    MyFrmTA001.TBarSave.Visible = True   '#sec
    MyFrmTA001.TBarComments.Enabled = False
    MyFrmTA001.TBarAttach.Enabled = False
    MyFrmTA001.TBarAttach.Text = "Attachments"
    MyFrmTA001B.FormatGrid(True, False, False)
    MyFrmTA001B.Show()
    'Memory Cleanup
    myTXREAL = Nothing
    myTXBTR = Nothing
    myLOGRE = Nothing
    myTXPZ = Nothing
    myTXTRANS = Nothing
    myTXHOME = Nothing
    myUTCUST = Nothing
    MyFrmTA001RE = Nothing

  End Sub
  Public Sub LoadForm()
    Dim dsTAXCOM As DataSet = New DataSet
    Dim WrkAttachCount As Integer
    Dim WrkFrozenCode As String

    LoadScrn = True
    MyFrmTA001.TBarNew.Enabled = False
    MyFrmTA001.TBarSave.Enabled = True
    MyFrmTA001.TBarComments.Enabled = True
    If Not MyPhaseIn Then
      TabControl1.TabPages.Remove(TpPhaseIn)
      TabControl1.Refresh()
    End If

    AddMode = False
    'New record
    If WrkListNo = 0 Then
      AddMode = True
      MyFrmTA001.TBarDelete.Enabled = False
      MyFrmTA001.TBarComments.Enabled = False
      LblBaaNet.Visible = False
      LblBaa.Visible = False
      BtnPrevious.Visible = False
      BtnNext.Visible = False
      LoadScrn = False
      If MySoftFreezeRE Then
        MsgBox("Cannot create new record", MsgBoxStyle.Exclamation, "Soft Freeze")
        MyFrmTA001.TBarSave.Enabled = False
      End If
      Exit Sub
    End If

    If WrkFastPath Then
      BtnPrevious.Visible = False
      BtnNext.Visible = False
    End If

    If s_chg = False And s_full = False Then  '#sec
      MyFrmTA001.TBarSave.Visible = False  '#sec
    End If  '#sec

    If s_chg = True Or s_full = True Then  '#sec
      MyFrmTA001.TBarAttach.Enabled = True
      WrkAttachCount = GetAttachcount("TADAILY", "R" & WrkListNo)
      MyFrmTA001.TBarAttach.Text = WrkAttachCount & " Attachment(s)"
    End If

    'change log
    MyFrmTA001.TBarLog.Enabled = False
    logre_ds = myLOGRE.GetAllList(WrkListNo)
    If logre_ds.Tables(0).Rows.Count > 0 Then
      MyFrmTA001.TBarLog.Enabled = True
    End If

    'Fill the dataset with the existing data
    MyFrmTA001.TBarDelete.Enabled = True
    TxtListNo.ReadOnly = True
    TxtListNo.TabStop = False
    TxtListNo.Text = WrkListNo
    myTXREAL.GetOneRecordP(WrkListNo)
    If myTXREAL.RecordNotFound Then
      MyFrmTA001.TBarNew.Enabled = False
      MyFrmTA001.TBarSave.Enabled = False
      MyFrmTA001.TBarDelete.Enabled = False
      MyFrmTA001.TBarComments.Enabled = False
      Me.ErrProv.SetError(TxtListNo, "Record not found")
      Exit Sub
    End If

    With myTXREAL
      TxtName.Text = Trim(._NAME)
      TxtSname.Text = Trim(._SNAME)
      TxtAdd1.Text = Trim(._ADD1)
      TxtAdd2.Text = Trim(._ADD2)
      TxtCity.Text = Trim(._CITY)
      TxtState.Text = Trim(._STATE)
      TxtZip5.Text = Format(._ZIP5, "00000")
      TxtZip4.Text = Format(._ZIP4, "0000")
      TxtLocNo.Text = Trim(._LOCNO)
      TxtLoc.Text = Trim(._LOC)
      TxtPdst.Text = ._PDST
      TxtOid.Text = Trim(._OID)
      TxtDist.Text = ._DIST
      TxtUnit.Text = Trim(._UNITNO)
      TxtVetYear.Text = ._VTYR
      TxtMap.Text = Trim(._MAP)
      TxtVol.Text = Trim(._VOL)
      TxtPage.Text = Trim(._PGE)
      TxtCensus.Text = Trim(._CENTR)
      TxtSmap.Text = Trim(._SMAP)
      If ._CAT = "1" Then
        RbCatTaxable.Checked = True
        LnkExemptCd.Enabled = False
        TxtExemptCd.Enabled = False
        TxtExemptCd.Text = String.Empty
        LblTaxExempt.Visible = False
      Else
        RbCatExempt.Checked = True
        LnkExemptCd.Enabled = True
        TxtExemptCd.Enabled = True
        TxtExemptCd.Text = Trim(._EXMPT)
        LblTaxExempt.Visible = True
      End If
      If ._DTBTR > 0 Then
        DtPckBtr.Value = MyUtils.GetDBDate(._DTBTR)
        DtPckBtr.Checked = True
      Else
        DtPckBtr.Value = Date.Today
        DtPckBtr.Checked = False
      End If
      ChkDnbtr.Checked = False
      If ._DNBTR = "Y" Then
        ChkDnbtr.Checked = True
      End If
      ChkTaxCard.Checked = False
      If ._CARD = "Y" Then
        ChkTaxCard.Checked = True
      End If
      TxtPurPrice.Text = ._PURPR
      If ._PURDT > 0 Then
        DtPckPurDate.Value = MyUtils.GetDBDate(._PURDT)
        DtPckPurDate.Checked = True
      Else
        DtPckPurDate.Value = Date.Today
        DtPckPurDate.Checked = False
      End If
      '			TxtBankCd.Text = Trim(._BKCD)
      LblAcctn.Text = Trim(._ACCTN)
      TxtUnit1.Text = ._UNIT1
      TxtAcre1.Text = ._ACRE1
      TxtAssmt1.Text = ._ASS1
      TxtUnit2.Text = ._UNIT2
      TxtAcre2.Text = ._ACRE2
      TxtAssmt2.Text = ._ASS2
      TxtUnit3.Text = ._UNIT3
      TxtAcre3.Text = ._ACRE3
      TxtAssmt3.Text = ._ASS3
      TxtUnit4.Text = ._UNIT4
      TxtAcre4.Text = ._ACRE4
      TxtAssmt4.Text = ._ASS4
      TxtUnit5.Text = ._UNIT5
      TxtAcre5.Text = ._ACRE5
      TxtAssmt5.Text = ._ASS5
      TxtUnit6.Text = ._UNIT6
      TxtAcre6.Text = ._ACRE6
      TxtAssmt6.Text = ._ASS6
      TxtUnit7.Text = ._UNIT7
      TxtAcre7.Text = ._ACRE7
      TxtAssmt7.Text = ._ASS7
      TxtExam1.Text = ._EXAM1
      TxtExam2.Text = ._EXAM2
      TxtExam3.Text = ._EXAM3
      TxtExam4.Text = ._EXAM4
      TxtExam5.Text = ._EXAM5
      TxtExam6.Text = ._EXAM6
      TxtExam7.Text = ._EXAM7
      LblGross.Text = ._GROSS
      LblExempt.Text = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5 + ._EXAM6 + ._EXAM7
      LblNet.Text = ._NET
      LblBaa.Text = ._BTR + MyUtils.CnvSng(LblExempt.Text)
      ChkNoCama.Checked = False
      myTXNCAM.GetOneRecordP(._LISTNO)
      If Not myTXNCAM.RecordNotFound Then
        ChkNoCama.Checked = True
      End If
      'Elderly
      WrkFrozenCode = Trim(._FCCOD)
      Select Case WrkFrozenCode
        Case Is = "F"
          LblEldPgm.Text = "Frozen"
          LblElderly.Visible = True
        Case Is = "C"
          LblEldPgm.Text = "Heart"
          LblElderly.Visible = True
        Case Else
          LblEldPgm.Text = "N/A"
          LblElderly.Visible = False
      End Select
      TxtEldYear.Text = ._FCYR
      LblEldPerc.Text = ._CPERC
      LblEldMax.Text = ._CMAX
      LblEldMin.Text = ._CMIN
      LblEldTax.Text = ._FTAX
      LblEldAdj.Text = ._CIRAD
      LblLocAmt.Text = ._TWNBN
      If ._TWNBN > 0 Then
        LnkLocAmt.Visible = True
      Else
        LnkLocAmt.Visible = False
      End If
      LblLocalBen.Visible = False
      If ._TWNBN > 0 Then
        LblLocalBen.Visible = True
      End If
      'Public Act 490
      TxtActAcres.Text = ._AACRE
      If ._AIDTE > 0 Then
        DtPckActInit.Value = MyUtils.GetDBDateMDY(._AIDTE)
        DtPckActInit.Checked = True
      Else
        DtPckActInit.Value = Date.Today
        DtPckActInit.Checked = False
      End If
      If ._AEDATE > 0 Then
        DtPckActExpir.Value = MyUtils.GetDBDateMDY(._AEDATE)
        DtPckActExpir.Checked = True
      Else
        DtPckActExpir.Value = Date.Today
        DtPckActExpir.Checked = False
      End If
    End With
    'BTR
    myTXBTR.GetOneRecordP(WrkListNo, WrkType)
    If Not myTXBTR.RecordNotFound Then
      With myTXBTR
        TxtBaa1.Text = MyUtils.CnvSng(TxtAssmt1.Text) + ._BASS1
        TxtBaa2.Text = MyUtils.CnvSng(TxtAssmt2.Text) + ._BASS2
        TxtBaa3.Text = MyUtils.CnvSng(TxtAssmt3.Text) + ._BASS3
        TxtBaa4.Text = MyUtils.CnvSng(TxtAssmt4.Text) + ._BASS4
        TxtBaa5.Text = MyUtils.CnvSng(TxtAssmt5.Text) + ._BASS5
        TxtBaa6.Text = MyUtils.CnvSng(TxtAssmt6.Text) + ._BASS6
        TxtBaa7.Text = MyUtils.CnvSng(TxtAssmt7.Text) + ._BASS7
      End With
    Else
      TxtBaa1.Text = 0
      TxtBaa2.Text = 0
      TxtBaa3.Text = 0
      TxtBaa4.Text = 0
      TxtBaa5.Text = 0
      TxtBaa6.Text = 0
      TxtBaa7.Text = 0
    End If
    CalcBTR()
    'Transfer
    RbTranExempt.Checked = False
    myTXTRANS.GetOneRecordP(WrkListNo)
    If Not myTXTRANS.RecordNotFound Then
      With myTXTRANS
        TxtTranExemptCd.Text = String.Empty
        If ._CAT = 1 Then
          LnkTranExemptCd.Enabled = False
          TxtTranExemptCd.Enabled = False
        Else
          LnkTranExemptCd.Enabled = True
          TxtTranExemptCd.Enabled = True
          TxtTranExemptCd.Text = Trim(._EXMPT)
          RbTranExempt.Checked = True
        End If
        TxtTranName.Text = Trim(._NAME)
        TxtTranSname.Text = Trim(._SNAME)
        TxtTranAdd1.Text = Trim(._ADD1)
        TxtTranAdd2.Text = Trim(._ADD2)
        TxtTranCity.Text = Trim(._CITY)
        TxtTranState.Text = Trim(._STATE)
        TxtTranZip5.Text = Format(._ZIP5, "00000")
        TxtTranZip4.Text = Format(._ZIP4, "0000")
        TxtTranMap.Text = Trim(._MAP)
        TxtTranVol.Text = Trim(._VOL)
        TxtTranPage.Text = Trim(._TPAGE)
        TxtTranBlock.Text = ._CENBK
        TxtTranTract.Text = ._CENTR
        TxtTranPrice.Text = ._PRICE
        If ._TDATE > 0 Then
          DtPckTran.Value = MyUtils.GetDBDate(._TDATE)
          DtPckTran.Checked = True
        Else
          DtPckTran.Value = Date.Today
          DtPckTran.Checked = False
        End If
        ChkTranEld.Checked = False
        If Trim(._ELDCD) = "Y" Then
          ChkTranEld.Checked = True
        End If
        ChkTranExempt.Checked = False
        If Trim(._EXMPT2) = "Y" Then
          ChkTranExempt.Checked = True
        End If
        SetTranExemptCdTip()
      End With
    Else
      RbTranTaxable.Checked = False
      LnkTranExemptCd.Enabled = False
      TxtTranExemptCd.Enabled = False
      TxtTranExemptCd.Text = String.Empty
      TxtTranName.Text = String.Empty
      TxtTranSname.Text = String.Empty
      TxtTranAdd1.Text = String.Empty
      TxtTranAdd2.Text = String.Empty
      TxtTranCity.Text = String.Empty
      TxtTranState.Text = String.Empty
      TxtTranZip5.Text = String.Empty
      TxtTranZip4.Text = String.Empty
      TxtTranVol.Text = String.Empty
      TxtTranPage.Text = String.Empty
      TxtTranBlock.Text = String.Empty
      TxtTranTract.Text = String.Empty
      TxtTranPrice.Text = String.Empty
      DtPckTran.Value = Date.Today
      DtPckTran.Checked = False
      ChkTranEld.Checked = False
      ChkTranExempt.Checked = False
      SetTranExemptCdTip()
    End If
    'P & Z
    myTXPZ.GetOneRecordP(WrkListNo)
    If Not myTXPZ.RecordNotFound Then
      With myTXPZ
        TxtPZMap.Text = Trim(._AERMAP)
        TxtPZLot.Text = Trim(._LTSZ)
        TxtPZCard.Text = Trim(._CARDNO)
        TxtPZNon.Text = Trim(._NONCON)
        TxtPZZoning.Text = Trim(._ZONING)
        TxtPZGrossAcre.Text = ._GRSACR
        TxtPZBldAcre.Text = ._BLDACR
        TxtPZBed.Text = ._BEDRMS
        TxtPZSewphs.Text = Trim(._SEWPHS)
        TxtPZBath.Text = ._BATH
        ChkPZSeptic.Checked = False
        If Trim(._SEP) = "Y" Then
          ChkPZSeptic.Checked = True
        End If
      End With
    Else
      TxtPZMap.Text = String.Empty
      TxtPZLot.Text = String.Empty
      TxtPZCard.Text = String.Empty
      TxtPZNon.Text = String.Empty
      TxtPZZoning.Text = String.Empty
      TxtPZGrossAcre.Text = String.Empty
      TxtPZBldAcre.Text = String.Empty
      TxtPZBed.Text = String.Empty
      TxtPZSewphs.Text = String.Empty
      TxtPZBath.Text = String.Empty
      ChkPZSeptic.Checked = False
    End If

    'Sewer
    LblSunit.Text = String.Empty
    myUTCUST.GetOneRecordP(WrkListNo)
    If Not myUTCUST.RecordNotFound Then
      With myUTCUST
        LblSunit.Text = ._CUUNIT
        If ._CUUNIT > 0 Then
          LblSewer.Visible = True
          LblSunitHdr.Visible = True
          LblSunit.Visible = True
        End If
      End With
    End If

    'PhaseIn
    LblNoPhaseIn.Visible = False
    If MyPhaseIn Then
      myTXPHIN.GetOneRecordP(WrkListNo, MyGLYear)
      With myTXPHIN
        If Not .RecordNotFound Then
          LblOrigGross.Text = ._ORIGRS
          LblPhaseCode1.Text = Format(._CAPC1, "###")
          LblPhaseAssmnt1.Text = ._CAPA1
          LblPhaseCode2.Text = Format(._CAPC2, "###")
          LblPhaseAssmnt2.Text = ._CAPA2
          LblPhaseCode3.Text = Format(._CAPC3, "###")
          LblPhaseAssmnt3.Text = ._CAPA3
          LblPhaseCode4.Text = Format(._CAPC4, "###")
          LblPhaseAssmnt4.Text = ._CAPA4
          LblPhaseCode5.Text = Format(._CAPC5, "###")
          LblPhaseAssmnt5.Text = ._CAPA5
          LblPhaseCode6.Text = Format(._CAPC6, "###")
          LblPhaseAssmnt6.Text = ._CAPA6
          LblPhaseCode7.Text = Format(._CAPC7, "###")
          LblPhaseAssmnt7.Text = ._CAPA7
          LblPhaseGross.Text = ._CAPGRS
          LblAdjCode1.Text = Format(._ADJC1, "###")
          LblAdjAssmnt1.Text = ._ADJA1
          LblAdjCode2.Text = Format(._ADJC2, "###")
          LblAdjAssmnt2.Text = ._ADJA2
          LblAdjCode3.Text = Format(._ADJC3, "###")
          LblAdjAssmnt3.Text = ._ADJA3
          LblAdjCode4.Text = Format(._ADJC4, "###")
          LblAdjAssmnt4.Text = ._ADJA4
          LblAdjCode5.Text = Format(._ADJC5, "###")
          LblAdjAssmnt5.Text = ._ADJA5
          LblAdjCode6.Text = Format(._ADJC6, "###")
          LblAdjAssmnt6.Text = ._ADJA6
          LblAdjCode7.Text = Format(._ADJC7, "###")
          LblAdjAssmnt7.Text = ._ADJA7
          LblAdjGross.Text = ._ADJGRS
          LblFullGross.Text = ._ORIGRS + ._FULGRS
        Else
          LblNoPhaseIn.Visible = True
          LblOrigGross.Text = String.Empty
          LblPhaseCode1.Text = String.Empty
          LblPhaseAssmnt1.Text = String.Empty
          LblPhaseCode2.Text = String.Empty
          LblPhaseAssmnt2.Text = String.Empty
          LblPhaseCode3.Text = String.Empty
          LblPhaseAssmnt3.Text = String.Empty
          LblPhaseCode4.Text = String.Empty
          LblPhaseAssmnt4.Text = String.Empty
          LblPhaseCode5.Text = String.Empty
          LblPhaseAssmnt5.Text = String.Empty
          LblPhaseCode6.Text = String.Empty
          LblPhaseAssmnt6.Text = String.Empty
          LblPhaseCode7.Text = String.Empty
          LblPhaseAssmnt7.Text = String.Empty
          LblPhaseGross.Text = String.Empty
          LblFullGross.Text = String.Empty
        End If

        myTXREALC.GetOneRecordP(WrkListNo)
        If Not .RecordNotFound Then
          With myTXREALC
            myTXBTRC.GetOneRecordP(WrkListNo, "R")
            If myTXBTRC.RecordNotFound Then
              LblCurrAssmnt1.Text = ._ASS1
              LblCurrAssmnt2.Text = ._ASS2
              LblCurrAssmnt3.Text = ._ASS3
              LblCurrAssmnt4.Text = ._ASS4
              LblCurrAssmnt5.Text = ._ASS5
              LblCurrAssmnt6.Text = ._ASS6
              LblCurrAssmnt7.Text = ._ASS7
              LblCurrGross.Text = ._GROSS
            Else
              LblCurrAssmnt1.Text = ._ASS1 + myTXBTRC._BASS1
              LblCurrAssmnt2.Text = ._ASS2 + myTXBTRC._BASS2
              LblCurrAssmnt3.Text = ._ASS3 + myTXBTRC._BASS3
              LblCurrAssmnt4.Text = ._ASS4 + myTXBTRC._BASS4
              LblCurrAssmnt5.Text = ._ASS5 + myTXBTRC._BASS5
              LblCurrAssmnt6.Text = ._ASS6 + myTXBTRC._BASS6
              LblCurrAssmnt7.Text = ._ASS7 + myTXBTRC._BASS7
              LblCurrGross.Text = ._GROSS + ._BTR
            End If
          End With
        Else
          LblCurrAssmnt1.Text = String.Empty
          LblCurrAssmnt2.Text = String.Empty
          LblCurrAssmnt3.Text = String.Empty
          LblCurrAssmnt4.Text = String.Empty
          LblCurrAssmnt5.Text = String.Empty
          LblCurrAssmnt6.Text = String.Empty
          LblCurrAssmnt7.Text = String.Empty
          LblCurrGross.Text = String.Empty
        End If
      End With
      LblTotAssmnt1.Text = MyUtils.CnvSng(LblCurrAssmnt1.Text) + MyUtils.CnvSng(LblAdjAssmnt1.Text)
      LblTotAssmnt2.Text = MyUtils.CnvSng(LblCurrAssmnt2.Text) + MyUtils.CnvSng(LblAdjAssmnt2.Text)
      LblTotAssmnt3.Text = MyUtils.CnvSng(LblCurrAssmnt3.Text) + MyUtils.CnvSng(LblAdjAssmnt3.Text)
      LblTotAssmnt4.Text = MyUtils.CnvSng(LblCurrAssmnt4.Text) + MyUtils.CnvSng(LblAdjAssmnt4.Text)
      LblTotAssmnt5.Text = MyUtils.CnvSng(LblCurrAssmnt5.Text) + MyUtils.CnvSng(LblAdjAssmnt5.Text)
      LblTotAssmnt6.Text = MyUtils.CnvSng(LblCurrAssmnt6.Text) + MyUtils.CnvSng(LblAdjAssmnt6.Text)
      LblTotAssmnt7.Text = MyUtils.CnvSng(LblCurrAssmnt7.Text) + MyUtils.CnvSng(LblAdjAssmnt7.Text)
      LblTot.Text = MyUtils.CnvSng(LblCurrGross.Text) + MyUtils.CnvSng(LblAdjGross.Text)
    End If

    'Assessment Property Codes
    With myTXREAL
      'Assessment Property Codes
      TxtCode1.Text = ._CODE1
      TxtCode2.Text = ._CODE2
      TxtCode3.Text = ._CODE3
      TxtCode4.Text = ._CODE4
      TxtCode5.Text = ._CODE5
      TxtCode6.Text = ._CODE6
      TxtCode7.Text = ._CODE7
      SetCode1Tip()
      SetCode2Tip()
      SetCode3Tip()
      SetCode4Tip()
      SetCode5Tip()
      SetCode6Tip()
      SetCode7Tip()
      'Exemption Codes
      TxtExempt1.Text = Trim(._EXCD1)
      TxtExempt2.Text = Trim(._EXCD2)
      TxtExempt3.Text = Trim(._EXCD3)
      TxtExempt4.Text = Trim(._EXCD4)
      TxtExempt5.Text = Trim(._EXCD5)
      TxtExempt6.Text = Trim(._EXCD6)
      TxtExempt7.Text = Trim(._EXCD7)
      SetExem1Tip()
      SetExem2Tip()
      SetExem3Tip()
      SetExem4Tip()
      SetExem5Tip()
      SetExem6Tip()
      SetExem7Tip()
      'Exempt Property Codes
      SetExemptCdTip()
      'Bank Codes
      SetBankTip()
    End With

    myTXREALC.GetOneRecordP(WrkListNo)
    With myTXREALC
      If Not .RecordNotFound Then
        LblBeforeCC.Visible = False
        If ._CCNO > 0 Then
          LblBeforeCC.Visible = True
          LblBeforeCC.Text = "Before Bill C/C " & myTXREALC._CCNO
        End If
      End If
    End With

    'Comments
    dsTAXCOM = myTAXCOM.Getcomments(WrkListNo, WrkType, 0)
    MyFrmTA001.TBarComments.ImageKey = ""
    LblComments.Visible = False
    If dsTAXCOM.Tables(0).Rows.Count > 0 Then
      LblComments.Visible = True
      MyFrmTA001.TBarComments.ImageKey = "comment_24.png"
    End If

    If MySoftFreezeRE Then
      LblSoftFreeze.Visible = True
      LblDtPckBTR.ForeColor = Color.Fuchsia
      ChkDnbtr.ForeColor = Color.Fuchsia
      LblBTR1.ForeColor = Color.Fuchsia
      LblBTR2.ForeColor = Color.Fuchsia
      TpTran.ForeColor = Color.Fuchsia
    End If
    LoadScrn = False
  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer

    Cancel = True
    If MySoftFreezeRE Then Exit Sub

    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    myLOGRE.GetOneRecordP(WrkListNo, 0, 0)
    MoveToLog("Delete")
    myLOGRE.AddOneRecordP()
    myTXBTR.GetOneRecordP(WrkListNo, WrkType)
    If Not myTXBTR.RecordNotFound Then
      myTXBTR.DeleteOneRecordP()
    End If
    myTXREAL.DeleteOneRecordP()

    myTXTRANS.GetOneRecordP(WrkListNo)
    If Not myTXTRANS.RecordNotFound Then
      myTXTRANS.DeleteOneRecordP()
    End If

    myTXPZ.GetOneRecordP(WrkListNo)
    If Not myTXPZ.RecordNotFound Then
      myTXPZ.DeleteOneRecordP()
    End If

    If MyPhaseIn Then
      myTXPHIN.GetOneRecordP(WrkListNo, MyGLYear)
      If Not myTXPHIN.RecordNotFound Then
        myTXPHIN.DeleteOneRecordP()
      End If
    End If

    myTXNCAM.GetOneRecordP(WrkListNo)
    If Not myTXNCAM.RecordNotFound Then
      myTXNCAM.DeleteOneRecordP()
    End If
  End Sub
  Public Sub SaveData()
    Dim dslog As DataSet = New DataSet
    Dim WrkAutoGen As Boolean
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String

    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)

    myTXREAL.GetOneRecordP(WrkListNo)
    If AddMode Then
      If Not myTXREAL.RecordNotFound Then
        Me.ErrProv.SetError(TxtListNo, "Record already exists")
        Exit Sub
      End If
    End If

    myTXBTR.GetOneRecordP(WrkListNo, WrkType)
    myTXPZ.GetOneRecordP(WrkListNo)
    myTXTRANS.GetOneRecordP(WrkListNo)
    myTXNCAM.GetOneRecordP(WrkListNo)
    myUTCUST.GetOneRecordP(WrkListNo)

    SetCode1Tip()
    SetCode2Tip()
    SetCode3Tip()
    SetCode4Tip()
    SetCode5Tip()
    SetCode6Tip()
    SetCode7Tip()
    SetExem1Tip()
    SetExem2Tip()
    SetExem3Tip()
    SetExem4Tip()
    SetExem5Tip()
    SetExem6Tip()
    SetExem7Tip()
    SetExemptCdTip()
    SetBankTip()

    WrkAutoGen = False
    If Not AddMode Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        dslog = myLOGRE.PosData(WrkListNo, 0, 0, 1)
        If dslog.Tables(0).Rows.Count = 0 Then
          MoveToLog("Original")
          myLOGRE.AddOneRecordP()
        End If
        MoveToFile()
        MoveToLog("Change")
        myTXREAL.UpdateOneRecordP()
        myLOGRE.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        If WrkListNo = 0 Then
          WrkListNo = myTXREAL.AutoGenKey()
          myTXREAL.GetOneRecordP(WrkListNo)
          WrkAutoGen = True
        End If
        MoveToFile()
        MoveToLog("Add")
        myTXREAL.AddOneRecordP()
        myLOGRE.AddOneRecordP()
        If WrkAutoGen Then
          MsgBox("Account has been assigned list number " & WrkListNo, MsgBoxStyle.Information, "System Generated List Number")
        End If
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    If ChkNoCama.Checked Then
      If myTXNCAM.RecordNotFound Then
        myTXNCAM._LISTNO = WrkListNo
        myTXNCAM.AddOneRecordP()
      End If
    Else
      If Not myTXNCAM.RecordNotFound Then
        myTXNCAM.DeleteOneRecordP()
      End If
    End If

    If LblBaa.Visible Then
      If Not myTXBTR.RecordNotFound Then
        myTXBTR.UpdateOneRecordP()
      Else
        myTXBTR.AddOneRecordP()
      End If
    Else
      If Not myTXBTR.RecordNotFound Then
        myTXBTR.DeleteOneRecordP()
      End If
    End If

    If Not myTXPZ.RecordNotFound Then
      myTXPZ.UpdateOneRecordP()
    Else
      myTXPZ.AddOneRecordP()
    End If

    If TxtTranName.Text <> "" Then
      If Not myTXTRANS.RecordNotFound Then
        myTXTRANS.UpdateOneRecordP()
      Else
        myTXTRANS.AddOneRecordP()
      End If
    Else
      If Not myTXTRANS.RecordNotFound Then
        myTXTRANS.DeleteOneRecordP()
      End If
    End If

    'If Not MyNoSwr Then
    '  If Not myUTCUST.RecordNotFound Then
    '    MoveToUTCust()
    '    myUTCUST.UpdateOneRecordP()
    '  Else
    '    MsgBox("Utility Billing record not found. Create using UB Customer Maintainence program.", MsgBoxStyle.Exclamation, "Cannot save Sewer Units")
    '  End If
    'End If

    Me.Close()

  End Sub
  Public Sub SaveSoftFreeze()
    Dim dslog As DataSet = New DataSet
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String

    EditChecksSoft(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If

    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)

    myTXREAL.GetOneRecordP(WrkListNo)
    If Not myTXREAL.RecordNotFound Then
      With myTXREAL
        If LblBaa.Visible Then
          ._BTR = MyUtils.CnvSng(LblBaa.Text)
        Else
          ._BTR = 0
        End If
        If DtPckBtr.Checked Then
          ._DTBTR = MyUtils.SetDBDate(DtPckBtr.Value)
        Else
          ._DTBTR = 0
        End If
        ._DNBTR = "N"
        If ChkDnbtr.Checked Then
          ._DNBTR = "Y"
        End If
        .UpdateOneRecordP()
      End With
    End If

    dslog = myLOGRE.PosData(WrkListNo, 0, 0, 1)
    If dslog.Tables(0).Rows.Count = 0 Then
      MoveToLog("Original")
      myLOGRE.AddOneRecordP()
    End If
    MoveToLog("Change")
    myLOGRE.AddOneRecordP()

    'Save to BTR File
    If LblBaa.Visible Then
      With myTXBTR
        ._LISTNO = WrkListNo
        ._TYPE = WrkType
        ._BASS1 = MyUtils.CnvSng(TxtBaa1.Text) - MyUtils.CnvSng(TxtAssmt1.Text)
        ._BASS2 = MyUtils.CnvSng(TxtBaa2.Text) - MyUtils.CnvSng(TxtAssmt2.Text)
        ._BASS3 = MyUtils.CnvSng(TxtBaa3.Text) - MyUtils.CnvSng(TxtAssmt3.Text)
        ._BASS4 = MyUtils.CnvSng(TxtBaa4.Text) - MyUtils.CnvSng(TxtAssmt4.Text)
        ._BASS5 = MyUtils.CnvSng(TxtBaa5.Text) - MyUtils.CnvSng(TxtAssmt5.Text)
        ._BASS6 = MyUtils.CnvSng(TxtBaa6.Text) - MyUtils.CnvSng(TxtAssmt6.Text)
        ._BASS7 = MyUtils.CnvSng(TxtBaa7.Text) - MyUtils.CnvSng(TxtAssmt7.Text)
      End With
      If Not myTXBTR.RecordNotFound Then
        myTXBTR.UpdateOneRecordP()
      Else
        myTXBTR.AddOneRecordP()
      End If
    Else
      If Not myTXBTR.RecordNotFound Then
        myTXBTR.DeleteOneRecordP()
      End If
    End If

    myTXTRANS.GetOneRecordP(WrkListNo)
    If TxtTranName.Text <> "" Then
      With myTXTRANS
        ._LISTNO = WrkListNo
        ._CAT = 3
        If RbCatTaxable.Checked Then
          ._CAT = 1
        End If
        ._NAME = TxtTranName.Text
        ._SNAME = TxtTranSname.Text
        ._ADD1 = TxtTranAdd1.Text
        ._ADD2 = TxtTranAdd2.Text
        ._CITY = TxtTranCity.Text
        ._STATE = TxtTranState.Text
        ._ZIP5 = MyUtils.CnvSng(TxtTranZip5.Text)
        ._ZIP4 = MyUtils.CnvSng(TxtTranZip4.Text)
        ._CENBK = MyUtils.CnvSng(TxtTranBlock.Text)
        ._CENTR = MyUtils.CnvSng(TxtTranTract.Text)
        ._PRICE = MyUtils.CnvSng(TxtTranPrice.Text)
        ._MAP = TxtTranMap.Text
        ._VOL = TxtTranVol.Text
        ._TPAGE = TxtTranPage.Text
        If DtPckTran.Checked Then
          ._TDATE = MyUtils.SetDBDate(DtPckTran.Value)
        Else
          ._TDATE = 0
        End If
        ._ELDCD = "N"
        If ChkTranEld.Checked Then
          ._ELDCD = "Y"
        End If
        ._EXMPT2 = "N"
        If ChkTranExempt.Checked Then
          ._EXMPT2 = "Y"
        End If
        ._EXMPT = TxtTranExemptCd.Text
        ._CHDATE = MyUtils.SetDBDate(Date.Today)
        ._CHTIME = Format(DateTime.Now, "hhmmss")
      End With
      If Not myTXTRANS.RecordNotFound Then
        myTXTRANS.UpdateOneRecordP()
      Else
        myTXTRANS.AddOneRecordP()
      End If
    Else
      If Not myTXTRANS.RecordNotFound Then
        myTXTRANS.DeleteOneRecordP()
      End If
    End If
    Me.Close()

  End Sub
  Private Sub MoveToLog(ByVal WrkMode As String)
CheckFile:
    With myLOGRE
      .GetOneRecordP(WrkListNo, MyUtils.SetDBDate(DateTime.Today), Format(DateTime.Now, "HHmmss"))
      If .RecordNotFound Then
        ._AACRE = myTXREAL._AACRE
        ._ACCTN = myTXREAL._ACCTN
        ._ACRE1 = myTXREAL._ACRE1
        ._ACRE2 = myTXREAL._ACRE2
        ._ACRE3 = myTXREAL._ACRE3
        ._ACRE4 = myTXREAL._ACRE4
        ._ACRE5 = myTXREAL._ACRE5
        ._ACRE6 = myTXREAL._ACRE6
        ._ACRE7 = myTXREAL._ACRE7
        ._ADD1 = myTXREAL._ADD1
        ._ADD2 = myTXREAL._ADD2
        ._AEDATE = myTXREAL._AEDATE
        ._AIDTE = myTXREAL._AIDTE
        ._ASS1 = myTXREAL._ASS1
        ._ASS2 = myTXREAL._ASS2
        ._ASS3 = myTXREAL._ASS3
        ._ASS4 = myTXREAL._ASS4
        ._ASS5 = myTXREAL._ASS5
        ._ASS6 = myTXREAL._ASS6
        ._ASS7 = myTXREAL._ASS7
        ._BKCD = myTXREAL._BKCD
        ._BKSV = myTXREAL._BKSV
        ._BTC = myTXREAL._BTC
        ._BTR = myTXREAL._BTR
        ._CARD = myTXREAL._CARD
        ._CASS1 = myTXREAL._CASS1
        ._CASS2 = myTXREAL._CASS2
        ._CASS3 = myTXREAL._CASS3
        ._CASS4 = myTXREAL._CASS4
        ._CASS5 = myTXREAL._CASS5
        ._CASS6 = myTXREAL._CASS6
        ._CASS7 = myTXREAL._CASS7
        ._CAT = myTXREAL._CAT
        ._CCCD1 = myTXREAL._CCCD1
        ._CCCD2 = myTXREAL._CCCD2
        ._CCCD3 = myTXREAL._CCCD3
        ._CCCD4 = myTXREAL._CCCD4
        ._CCCD5 = myTXREAL._CCCD5
        ._CCEX = myTXREAL._CCEX
        ._CCGRS = myTXREAL._CCGRS
        ._CCNO = myTXREAL._CCNO
        ._CCRS = myTXREAL._CCRS
        ._CDATE = myTXREAL._CDATE
        ._CENBK = myTXREAL._CENBK
        ._CENTR = myTXREAL._CENTR
        ._CEXA1 = myTXREAL._CEXA1
        ._CEXA2 = myTXREAL._CEXA2
        ._CEXA3 = myTXREAL._CEXA3
        ._CEXA4 = myTXREAL._CEXA4
        ._CEXA5 = myTXREAL._CEXA5
        ._CHDATE = myTXREAL._CHDATE
        ._CHTIME = myTXREAL._CHTIME
        ._CIRAD = myTXREAL._CIRAD
        ._CITY = myTXREAL._CITY
        ._CMAX = myTXREAL._CMAX
        ._CMIN = myTXREAL._CMIN
        ._CODE1 = myTXREAL._CODE1
        ._CODE2 = myTXREAL._CODE2
        ._CODE3 = myTXREAL._CODE3
        ._CODE4 = myTXREAL._CODE4
        ._CODE5 = myTXREAL._CODE5
        ._CODE6 = myTXREAL._CODE6
        ._CODE7 = myTXREAL._CODE7
        ._CPERC = myTXREAL._CPERC
        ._DIST = myTXREAL._DIST
        ._DNBTR = myTXREAL._DNBTR
        ._DTBTR = myTXREAL._DTBTR
        ._EXAM1 = myTXREAL._EXAM1
        ._EXAM2 = myTXREAL._EXAM2
        ._EXAM3 = myTXREAL._EXAM3
        ._EXAM4 = myTXREAL._EXAM4
        ._EXAM5 = myTXREAL._EXAM5
        ._EXCD1 = myTXREAL._EXCD1
        ._EXCD2 = myTXREAL._EXCD2
        ._EXCD3 = myTXREAL._EXCD3
        ._EXCD4 = myTXREAL._EXCD4
        ._EXCD5 = myTXREAL._EXCD5
        ._EXMPT = myTXREAL._EXMPT
        ._FASS = myTXREAL._FASS
        ._FCCOD = myTXREAL._FCCOD
        ._FCYR = myTXREAL._FCYR
        ._FTAX = myTXREAL._FTAX
        ._GROSS = myTXREAL._GROSS
        ._LETT = myTXREAL._LETT
        ._LISTNo = myTXREAL._LISTNO
        ._LOC = myTXREAL._LOC
        ._LOCNo = myTXREAL._LOCNO
        ._LOGDTE = MyUtils.SetDBDate(DateTime.Today)
        ._LOGTIM = Format(DateTime.Now, "HHmmss")
        Select Case WrkMode
          Case "Add"
            ._LOGCMT = "Record Added"
          Case "Change"
            ._LOGCMT = "Record Changed"
          Case "Delete"
            ._LOGCMT = "Record Deleted"
          Case "Original"
            ._LOGCMT = "Original Record"
        End Select
        ._MAP = myTXREAL._MAP
        ._NAME = myTXREAL._NAME
        ._NET = myTXREAL._NET
        ._OID = myTXREAL._OID
        ._PDST = myTXREAL._PDST
        ._PERC = myTXREAL._PERC
        ._PGE = myTXREAL._PGE
        ._PRF = myTXREAL._PRF
        ._PURDT = myTXREAL._PURDT
        ._PURPR = myTXREAL._PURPR
        ._RLST = myTXREAL._RLST
        ._SEWER = myTXREAL._SEWER
        ._SMAP = myTXREAL._SMAP
        ._SNAME = myTXREAL._SNAME
        ._SS2 = myTXREAL._SS2
        ._SSNo = myTXREAL._SSNO
        ._STATE = myTXREAL._STATE
        ._TIN = myTXREAL._TIN
        ._TWNBN = myTXREAL._TWNBN
        ._TYPE = myTXREAL._TYPE
        ._UNIT1 = myTXREAL._UNIT1
        ._UNIT2 = myTXREAL._UNIT2
        ._UNIT3 = myTXREAL._UNIT3
        ._UNIT4 = myTXREAL._UNIT4
        ._UNIT5 = myTXREAL._UNIT5
        ._UNIT6 = myTXREAL._UNIT6
        ._UNIT7 = myTXREAL._UNIT7
        ._UNITNo = myTXREAL._UNITNO
        ._VOL = myTXREAL._VOL
        ._VTYR = myTXREAL._VTYR
        ._WMAIL = myTXREAL._WMAIL
        ._ZIP5 = myTXREAL._ZIP5
        ._ZIP4 = myTXREAL._ZIP4
      Else
        Threading.Thread.Sleep(1000)
        GoTo CheckFile
      End If
    End With

  End Sub
  Private Sub MoveToFile()
    With myTXREAL
      ._LISTNO = WrkListNo
      ._NAME = TxtName.Text
      ._SNAME = TxtSname.Text
      ._ADD1 = TxtAdd1.Text
      ._ADD2 = TxtAdd2.Text
      ._CITY = TxtCity.Text
      ._STATE = TxtState.Text
      ._ZIP5 = MyUtils.CnvSng(TxtZip5.Text)
      ._ZIP4 = MyUtils.CnvSng(TxtZip4.Text)
      ._LOCNO = MyUtils.JustifyRight(TxtLocNo.Text, 7)
      ._LOC = TxtLoc.Text
      ._PDST = MyUtils.CnvSng(TxtPdst.Text)
      ._OID = TxtOid.Text
      ._DIST = MyUtils.CnvSng(TxtDist.Text)
      ._UNITNO = TxtUnit.Text
      ._VTYR = MyUtils.CnvSng(TxtVetYear.Text)
      ._MAP = TxtMap.Text
      ._VOL = TxtVol.Text
      ._PGE = TxtPage.Text
      ._CENTR = MyUtils.CnvSng(TxtCensus.Text)
      ._SMAP = TxtSmap.Text
      If RbCatTaxable.Checked Then
        ._CAT = "1"
        ._EXMPT = ""
      Else
        ._CAT = "3"
        ._EXMPT = TxtExemptCd.Text
      End If
      If DtPckBtr.Checked Then
        ._DTBTR = MyUtils.SetDBDate(DtPckBtr.Value)
      Else
        ._DTBTR = 0
      End If
      ._DNBTR = "N"
      If ChkDnbtr.Checked Then
        ._DNBTR = "Y"
      End If
      ._CARD = "N"
      If ChkTaxCard.Checked Then
        ._CARD = "Y"
      End If
      ._PURPR = MyUtils.CnvSng(TxtPurPrice.Text)
      If DtPckPurDate.Checked Then
        ._PURDT = MyUtils.SetDBDate(DtPckPurDate.Value)
      Else
        ._PURDT = 0
      End If
      '				._BKCD = TxtBankCd.Text
      ._CODE1 = MyUtils.CnvSng(TxtCode1.Text)
      ._UNIT1 = MyUtils.CnvSng(TxtUnit1.Text)
      ._ACRE1 = MyUtils.CnvSng(TxtAcre1.Text)
      ._ASS1 = MyUtils.CnvSng(TxtAssmt1.Text)
      ._CODE2 = MyUtils.CnvSng(TxtCode2.Text)
      ._UNIT2 = MyUtils.CnvSng(TxtUnit2.Text)
      ._ACRE2 = MyUtils.CnvSng(TxtAcre2.Text)
      ._ASS2 = MyUtils.CnvSng(TxtAssmt2.Text)
      ._CODE3 = MyUtils.CnvSng(TxtCode3.Text)
      ._UNIT3 = MyUtils.CnvSng(TxtUnit3.Text)
      ._ACRE3 = MyUtils.CnvSng(TxtAcre3.Text)
      ._ASS3 = MyUtils.CnvSng(TxtAssmt3.Text)
      ._CODE4 = MyUtils.CnvSng(TxtCode4.Text)
      ._UNIT4 = MyUtils.CnvSng(TxtUnit4.Text)
      ._ACRE4 = MyUtils.CnvSng(TxtAcre4.Text)
      ._ASS4 = MyUtils.CnvSng(TxtAssmt4.Text)
      ._CODE5 = MyUtils.CnvSng(TxtCode5.Text)
      ._UNIT5 = MyUtils.CnvSng(TxtUnit5.Text)
      ._ACRE5 = MyUtils.CnvSng(TxtAcre5.Text)
      ._ASS5 = MyUtils.CnvSng(TxtAssmt5.Text)
      ._CODE6 = MyUtils.CnvSng(TxtCode6.Text)
      ._UNIT6 = MyUtils.CnvSng(TxtUnit6.Text)
      ._ACRE6 = MyUtils.CnvSng(TxtAcre6.Text)
      ._ASS6 = MyUtils.CnvSng(TxtAssmt6.Text)
      ._CODE7 = MyUtils.CnvSng(TxtCode7.Text)
      ._UNIT7 = MyUtils.CnvSng(TxtUnit7.Text)
      ._ACRE7 = MyUtils.CnvSng(TxtAcre7.Text)
      ._ASS7 = MyUtils.CnvSng(TxtAssmt7.Text)
      If LblBaa.Visible Then
        ._BTR = MyUtils.CnvSng(LblBaa.Text)
      Else
        ._BTR = 0
      End If
      ._GROSS = MyUtils.CnvSng(LblGross.Text)
      ._EXCD1 = TxtExempt1.Text
      ._EXAM1 = MyUtils.CnvSng(TxtExam1.Text)
      ._EXCD2 = TxtExempt2.Text
      ._EXAM2 = MyUtils.CnvSng(TxtExam2.Text)
      ._EXCD3 = TxtExempt3.Text
      ._EXAM3 = MyUtils.CnvSng(TxtExam3.Text)
      ._EXCD4 = TxtExempt4.Text
      ._EXAM4 = MyUtils.CnvSng(TxtExam4.Text)
      ._EXCD5 = TxtExempt5.Text
      ._EXAM5 = MyUtils.CnvSng(TxtExam5.Text)
      ._EXCD6 = TxtExempt6.Text
      ._EXAM6 = MyUtils.CnvSng(TxtExam6.Text)
      ._EXCD7 = TxtExempt7.Text
      ._EXAM7 = MyUtils.CnvSng(TxtExam7.Text)
      ._NET = MyUtils.CnvSng(LblNet.Text)
      ._FCYR = MyUtils.CnvSng(TxtEldYear.Text)
      'Public Act 490
      ._AACRE = MyUtils.CnvSng(TxtActAcres.Text)
      If DtPckActInit.Checked Then
        ._AIDTE = MyUtils.SetDBDateMDY(DtPckActInit.Value)
      Else
        ._AIDTE = 0
      End If
      If DtPckActExpir.Checked Then
        ._AEDATE = MyUtils.SetDBDateMDY(DtPckActExpir.Value)
      Else
        ._AEDATE = 0
      End If
      ._TYPE = "R"
      ._LETT = Mid$(TxtName.Text, 1, 1)
      ._PRF = Mid(MyUserID, 1, 10)
      ._CHDATE = MyUtils.SetDBDate(DateTime.Today)
      ._CHTIME = Format(DateTime.Now, "hhmmss")
    End With

    With myTXBTR
      ._LISTNO = WrkListNo
      ._TYPE = WrkType
      ._BASS1 = MyUtils.CnvSng(TxtBaa1.Text) - MyUtils.CnvSng(TxtAssmt1.Text)
      ._BASS2 = MyUtils.CnvSng(TxtBaa2.Text) - MyUtils.CnvSng(TxtAssmt2.Text)
      ._BASS3 = MyUtils.CnvSng(TxtBaa3.Text) - MyUtils.CnvSng(TxtAssmt3.Text)
      ._BASS4 = MyUtils.CnvSng(TxtBaa4.Text) - MyUtils.CnvSng(TxtAssmt4.Text)
      ._BASS5 = MyUtils.CnvSng(TxtBaa5.Text) - MyUtils.CnvSng(TxtAssmt5.Text)
      ._BASS6 = MyUtils.CnvSng(TxtBaa6.Text) - MyUtils.CnvSng(TxtAssmt6.Text)
      ._BASS7 = MyUtils.CnvSng(TxtBaa7.Text) - MyUtils.CnvSng(TxtAssmt7.Text)
    End With

    With myTXPZ
      ._AERMAP = TxtPZMap.Text
      ._BATH = MyUtils.CnvSng(TxtPZBath.Text)
      ._BLDACR = MyUtils.CnvSng(TxtPZBldAcre.Text)
      ._BEDRMS = MyUtils.CnvSng(TxtPZBed.Text)
      ._CARDNO = TxtPZCard.Text
      ._CAT = "3"
      If RbCatTaxable.Checked Then
        ._CAT = "1"
      End If
      ._CHDATE = MyUtils.SetDBDate(DateTime.Today)
      ._CHTIME = Format(DateTime.Now, "hhmmss")
      ._GRSACR = MyUtils.CnvSng(TxtPZGrossAcre.Text)
      ._LISTNo = WrkListNo
      ._LTSZ = TxtPZLot.Text
      ._NONCON = TxtPZNon.Text
      ._PRF = Mid(MyUserID, 1, 10)
      ._PCY1 = ""
      ._PCY2 = ""
      ._PCY3 = ""
      ._PCY4 = ""
      ._PCY5 = ""
      ._PERCT1 = 0
      ._PERCT2 = 0
      ._PERCT3 = 0
      ._PERCT4 = 0
      ._PERCT5 = 0
      ._PERDT1 = 0
      ._PERDT2 = 0
      ._PERDT3 = 0
      ._PERDT4 = 0
      ._PERDT5 = 0
      ._PERM1 = 0
      ._PERM2 = 0
      ._PERM3 = 0
      ._PERM4 = 0
      ._PERM5 = 0
      ._SEP = "N"
      If ChkPZSeptic.Checked Then
        ._SEP = "Y"
      End If
      ._SEWPHS = TxtPZSewphs.Text
      ._ZONING = TxtPZZoning.Text
    End With

    With myTXTRANS
      ._ADD1 = TxtTranAdd1.Text
      ._ADD2 = TxtTranAdd2.Text
      ._CAT = 3
      If RbCatTaxable.Checked Then
        ._CAT = 1
      End If
      ._CENBK = MyUtils.CnvSng(TxtTranBlock.Text)
      ._CENTR = MyUtils.CnvSng(TxtTranTract.Text)
      ._CITY = TxtTranCity.Text
      ._ELDCD = "N"
      If ChkTranEld.Checked Then
        ._ELDCD = "Y"
      End If
      ._EXMPT = TxtTranExemptCd.Text
      ._EXMPT2 = "N"
      If ChkTranExempt.Checked Then
        ._EXMPT2 = "Y"
      End If
      ._LISTNO = WrkListNo
      ._MAP = TxtTranMap.Text
      ._NAME = TxtTranName.Text
      ._POSTED = ""
      ._PRF = ""
      ._PRICE = MyUtils.CnvSng(TxtTranPrice.Text)
      ._SNAME = TxtTranSname.Text
      ._STATE = TxtTranState.Text
      If DtPckTran.Checked Then
        ._TDATE = MyUtils.SetDBDate(DtPckTran.Value)
      Else
        ._TDATE = 0
      End If
      ._TPAGE = TxtTranPage.Text
      ._VOL = TxtTranVol.Text
      ._ZIP5 = MyUtils.CnvSng(TxtTranZip5.Text)
      ._ZIP4 = MyUtils.CnvSng(TxtTranZip4.Text)
    End With

  End Sub
  Private Sub MoveToUTCust()
    With myUTCUST
      ._CUNAM1 = TxtName.Text
      ._CUNAM2 = TxtSname.Text
      ._CUADD1 = TxtAdd1.Text
      ._CUADD2 = TxtAdd2.Text
      ._CUCITY = TxtCity.Text
      ._CUST = TxtState.Text
      ._CUZIP = TxtZip5.Text
      If TxtZip4.Text <> "" Then
        ._CUZIP = TxtZip5.Text & "-" & TxtZip4.Text
      End If
      ._CUVOLM = MyUtils.CnvSng(TxtVol.Text)
      ._CUPAGE = MyUtils.CnvSng(TxtPage.Text)
      ._CULOCNO = MyUtils.JustifyRight(TxtLocNo.Text, 7)
      ._CULOC = TxtLoc.Text
    End With
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtListNo, "")
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
    ErrProv.SetError(TxtExempt1, "")
    ErrProv.SetError(TxtExempt2, "")
    ErrProv.SetError(TxtExempt3, "")
    ErrProv.SetError(TxtExempt4, "")
    ErrProv.SetError(TxtExempt5, "")
    ErrProv.SetError(TxtExempt6, "")
    ErrProv.SetError(TxtExempt7, "")
    ErrProv.SetError(TxtExemptCd, "")
    ErrProv.SetError(TxtBankCd, "")
    ErrProv.SetError(TxtTranExemptCd, "")
    ErrProv.SetError(LblNet, "")
    ErrProv.SetError(LblBaa, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
        Case "list#"
          ErrProv.SetError(TxtListNo, ErrorMsg(I))
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
        Case "exmpt"
          ErrProv.SetError(TxtExemptCd, ErrorMsg(I))
        Case "trexmpt"
          ErrProv.SetError(TxtTranExemptCd, ErrorMsg(I))
'			Case "bkcd"
'       ErrProv.SetError(TxtBankCd, ErrorMsg(I))
        Case "net"
          ErrProv.SetError(LblNet, ErrorMsg(I))
        Case "baa"
          ErrProv.SetError(LblBaa, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim WrkCode(6) As String
    Dim WrkExcd(6) As String
    Dim WrkTip As String
    'Dim Good As Boolean
    Dim I As Integer
    'Dim J As Integer
    'Dim K As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next
    WrkCode(0) = Trim(TxtCode1.Text)
    WrkCode(1) = Trim(TxtCode2.Text)
    WrkCode(2) = Trim(TxtCode3.Text)
    WrkCode(3) = Trim(TxtCode4.Text)
    WrkCode(4) = Trim(TxtCode5.Text)
    WrkCode(5) = Trim(TxtCode6.Text)
    WrkCode(6) = Trim(TxtCode7.Text)
    WrkExcd(0) = Trim(TxtExempt1.Text)
    WrkExcd(1) = Trim(TxtExempt2.Text)
    WrkExcd(2) = Trim(TxtExempt3.Text)
    WrkExcd(3) = Trim(TxtExempt4.Text)
    WrkExcd(4) = Trim(TxtExempt5.Text)
    WrkExcd(5) = Trim(TxtExempt6.Text)
    WrkExcd(6) = Trim(TxtExempt7.Text)

    If TxtName.Text = String.Empty Then
      ErrorField(I) = "name"
      ErrorMsg(I) = "Name cannot be blank"
      I = I + 1
    End If

    If TxtAdd1.Text = String.Empty Then
      ErrorField(I) = "add1"
      ErrorMsg(I) = "Address 1 cannot be blank"
      I = I + 1
    End If

    If TxtCity.Text = String.Empty Then
      ErrorField(I) = "city"
      ErrorMsg(I) = "City cannot be blank"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtAssmt1.Text) = 0 Then
      ErrorField(I) = "ass1"
      ErrorMsg(I) = "Assessment #1 cannot be 0"
      I = I + 1
    End If

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

    If TxtExempt6.Text = "" And MyUtils.CnvSng(TxtExam6.Text) > 0 Then
      ErrorField(I) = "excd6"
      ErrorMsg(I) = "Exemption Code is required"
      I = I + 1
    End If

    If TxtExempt7.Text = "" And MyUtils.CnvSng(TxtExam7.Text) > 0 Then
      ErrorField(I) = "excd7"
      ErrorMsg(I) = "Exemption Code is required"
      I = I + 1
    End If

    If TxtExemptCd.Enabled Then
      WrkTip = Ttp1.GetToolTip(TxtExemptCd)
      If Mid(WrkTip, 1, 1) = "*" Or WrkTip = "" Then
        ErrorField(I) = "exmpt"
        ErrorMsg(I) = "Invalid Exempt Code"
        I = I + 1
      End If
    End If

    If TxtTranExemptCd.Enabled Then
      WrkTip = Ttp1.GetToolTip(TxtTranExemptCd)
      If Mid(WrkTip, 1, 1) = "*" Or WrkTip = "" Then
        ErrorField(I) = "trexmpt"
        ErrorMsg(I) = "Invalid Transfer Exempt Code"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(LblNet.Text) < 0 Then
      ErrorField(I) = "net"
      ErrorMsg(I) = "Net Assessment cannot be negative"
      I = I + 1
    End If

    If LblBaa.Visible Then
      If DtPckBtr.Checked = False Or ChkDnbtr.Checked Then
        ErrorField(I) = "baa"
        ErrorMsg(I) = "BAA Amount: Date is required and denied must be unchecked"
        I = I + 1
      End If
    End If

    If DtPckBtr.Checked Then
      If Not LblBaa.Visible And Not ChkDnbtr.Checked Then
        ErrorField(I) = "baa"
        ErrorMsg(I) = "BAA must not be 0 or denied must be checked"
        I = I + 1
      End If
    End If

    If ChkDnbtr.Checked Then
      If LblBaa.Visible Or Not DtPckBtr.Checked Then
        ErrorField(I) = "baa"
        ErrorMsg(I) = "If BAA is denied then amount must be 0 and date is required"
        I = I + 1
      End If
    End If

    'For J = 0 To 6
    '  If Wrkexcd(J) = "APA" Then
    '    Good = False
    '    For K = 0 To 6
    '      If WrkCode(K) = "13" Or WrkCode(K) = "15" Or WrkCode(K) = "100" Then
    '        Good = True
    '      End If
    '    Next
    '    If Not Good Then
    '      ErrorField(I) = "excd" & J + 1
    '      ErrorMsg(I) = "Exemption APA requires a Code 13, 15 or 100"
    '      I = I + 1
    '    End If
    '  End If
    'Next

  End Sub
  Private Sub EditChecksSoft(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If LblBaa.Visible Then
      If DtPckBtr.Checked = False Or ChkDnbtr.Checked Then
        ErrorField(I) = "baa"
        ErrorMsg(I) = "BAA Amount: Date is required and denied must be unchecked"
        I = I + 1
      End If
    End If

    If DtPckBtr.Checked Then
      If Not LblBaa.Visible And Not ChkDnbtr.Checked Then
        ErrorField(I) = "baa"
        ErrorMsg(I) = "BAA must not be 0 or denied must be checked"
        I = I + 1
      End If
    End If

    If ChkDnbtr.Checked Then
      If LblBaa.Visible Or Not DtPckBtr.Checked Then
        ErrorField(I) = "baa"
        ErrorMsg(I) = "If BAA is denied then amount must be 0 and date is required"
        I = I + 1
      End If
    End If
  End Sub
  Private Sub FrmTA001RE_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    MyFrmLOG = New FrmLOG
    MyFrmLOG.WrkListNo = MyFrmTA001RE.WrkListNo
    MyFrmLOG.ds = MyFrmTA001RE.logre_ds
    MyFrmLOG.WrkType = WrkType
    MyFrmTA001.SbpScreen.Text = "TA001RE"


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
  Private Sub CalcAssmt()
    Dim TotGross As Long
    Dim TotExempt As Long

    If LoadScrn Then Exit Sub
    TotGross = MyUtils.CnvSng(TxtAssmt1.Text) + MyUtils.CnvSng(TxtAssmt2.Text) + MyUtils.CnvSng(TxtAssmt3.Text) +
      MyUtils.CnvSng(TxtAssmt4.Text) + MyUtils.CnvSng(TxtAssmt5.Text) + MyUtils.CnvSng(TxtAssmt6.Text) + MyUtils.CnvSng(TxtAssmt7.Text)
    TotExempt = MyUtils.CnvSng(TxtExam1.Text) + MyUtils.CnvSng(TxtExam2.Text) + MyUtils.CnvSng(TxtExam3.Text) + MyUtils.CnvSng(TxtExam4.Text) +
      MyUtils.CnvSng(TxtExam5.Text) + MyUtils.CnvSng(TxtExam6.Text) + MyUtils.CnvSng(TxtExam7.Text)
    LblGross.Text = TotGross
    LblExempt.Text = TotExempt
    LblNet.Text = TotGross - TotExempt
    LblBaaNet.Text = TotGross - TotExempt + MyUtils.CnvSng(LblBaa.Text)
  End Sub
  Private Sub CalcBTR()
    Dim TotBTR As Long

    TotBTR = MyUtils.CnvSng(TxtBaa1.Text) + MyUtils.CnvSng(TxtBaa2.Text) + MyUtils.CnvSng(TxtBaa3.Text) +
      MyUtils.CnvSng(TxtBaa4.Text) + MyUtils.CnvSng(TxtBaa5.Text) + MyUtils.CnvSng(TxtBaa6.Text) + MyUtils.CnvSng(TxtBaa7.Text)
    If TotBTR <> 0 Or (DtPckBtr.Checked And Not ChkDnbtr.Checked) Then
      LblBaaNet.Visible = True
      LblBaa.Visible = True
      LblBaaNet.Text = TotBTR - MyUtils.CnvSng(LblExempt.Text)
      LblBaa.Text = TotBTR - MyUtils.CnvSng(LblGross.Text)
    Else
      LblBaaNet.Visible = False
      LblBaa.Visible = False
      LblBaaNet.Text = 0
      LblBaa.Text = MyUtils.CnvSng(LblGross.Text)
    End If
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
  Private Sub TxtBaa1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBaa1.TextChanged
    CalcBTR()
  End Sub
  Private Sub TxtBaa2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBaa2.TextChanged
    CalcBTR()
  End Sub
  Private Sub TxtBaa3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBaa3.TextChanged
    CalcBTR()
  End Sub
  Private Sub TxtBaa4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBaa4.TextChanged
    CalcBTR()
  End Sub
  Private Sub TxtBaa5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBaa5.TextChanged
    CalcBTR()
  End Sub
  Private Sub TxtBaa6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBaa6.TextChanged
    CalcBTR()
  End Sub
  Private Sub TxtBaa7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBaa7.TextChanged
    CalcBTR()
  End Sub
  Private Sub LnkCode1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode1.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode1.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode1.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode2.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode2.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode2.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode3.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode3.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode3.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode4.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode4.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode4.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode5.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode5.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode5.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode6.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode6.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode6.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode7.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode7.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode7.Text)
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
  Private Sub LnkExempt6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt6.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt6.Text
    MyFrmListExemption.WrkCode = TxtExempt6.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt7.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt7.Text
    MyFrmListExemption.WrkCode = TxtExempt7.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub TxtExempt1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt1.TextChanged

    Dim WrkTxExem As String()
    Dim WrkAmt As Integer

    If LoadScrn Then Exit Sub

    If TxtExempt1.Text = "APA" Then
      TxtExam1.Text = CalcExamAPA()
    Else
      WrkTxExem = GetTXExem(TxtExempt1.Text)
      TxtExam1.Text = WrkTxExem(0)
      If MyLocEldDarien Then
        WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
        If MyUtils.CnvSng(WrkTxExem(2)) > 0 Then
          WrkAmt = CalcDarNet() * (MyUtils.CnvSng(WrkTxExem(2)) / 100)
          If MyUtils.CnvSng(WrkTxExem(0)) > WrkAmt Then
            WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
          End If
        End If
        TxtExam1.Text = WrkAmt
      End If
    End If

  End Sub
  Private Sub TxtExempt2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt2.TextChanged
    Dim WrkTxExem As String()
    Dim WrkAmt As Integer

    If LoadScrn Then Exit Sub

    If TxtExempt2.Text = "APA" Then
      TxtExam2.Text = CalcExamAPA()
    Else
      WrkTxExem = GetTXExem(TxtExempt2.Text)
      TxtExam2.Text = WrkTxExem(0)
      If MyLocEldDarien Then
        WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
        If MyUtils.CnvSng(WrkTxExem(2)) > 0 Then
          WrkAmt = CalcDarNet() * (MyUtils.CnvSng(WrkTxExem(2)) / 100)
          If MyUtils.CnvSng(WrkTxExem(0)) > WrkAmt Then
            WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
          End If
        End If
        TxtExam2.Text = WrkAmt
      End If
    End If
  End Sub
  Private Sub TxtExempt3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt3.TextChanged
    Dim WrkTxExem As String()
    Dim WrkAmt As Integer

    If LoadScrn Then Exit Sub

    If TxtExempt3.Text = "APA" Then
      TxtExam3.Text = CalcExamAPA()
    Else
      WrkTxExem = GetTXExem(TxtExempt3.Text)
      TxtExam3.Text = WrkTxExem(0)
      If MyLocEldDarien Then
        WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
        If MyUtils.CnvSng(WrkTxExem(2)) > 0 Then
          WrkAmt = CalcDarNet() * (MyUtils.CnvSng(WrkTxExem(2)) / 100)
          If MyUtils.CnvSng(WrkTxExem(0)) > WrkAmt Then
            WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
          End If
        End If
        TxtExam3.Text = WrkAmt
      End If
    End If
  End Sub
  Private Sub TxtExempt4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt4.TextChanged
    Dim WrkTxExem As String()
    Dim WrkAmt As Integer

    If LoadScrn Then Exit Sub

    If TxtExempt4.Text = "APA" Then
      TxtExam4.Text = CalcExamAPA()
    Else
      WrkTxExem = GetTXExem(TxtExempt4.Text)
      TxtExam4.Text = WrkTxExem(0)
      If MyLocEldDarien Then
        WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
        If MyUtils.CnvSng(WrkTxExem(2)) > 0 Then
          WrkAmt = CalcDarNet() * (MyUtils.CnvSng(WrkTxExem(2)) / 100)
          If MyUtils.CnvSng(WrkTxExem(0)) > WrkAmt Then
            WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
          End If
        End If
        TxtExam4.Text = WrkAmt
      End If
    End If
  End Sub
  Private Sub TxtExempt5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt5.TextChanged
    Dim WrkTxExem As String()
    Dim WrkAmt As Integer

    If LoadScrn Then Exit Sub

    If TxtExempt5.Text = "APA" Then
      TxtExam5.Text = CalcExamAPA()
    Else
      WrkTxExem = GetTXExem(TxtExempt5.Text)
      TxtExam5.Text = WrkTxExem(0)
      If MyLocEldDarien Then
        WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
        If MyUtils.CnvSng(WrkTxExem(2)) > 0 Then
          WrkAmt = CalcDarNet() * (MyUtils.CnvSng(WrkTxExem(2)) / 100)
          If MyUtils.CnvSng(WrkTxExem(0)) > WrkAmt Then
            WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
          End If
        End If
        TxtExam5.Text = WrkAmt
      End If
    End If
  End Sub
  Private Sub TxtExempt6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt6.TextChanged
    Dim WrkTxExem As String()
    Dim WrkAmt As Integer

    If LoadScrn Then Exit Sub

    If TxtExempt6.Text = "APA" Then
      TxtExam6.Text = CalcExamAPA()
    Else
      WrkTxExem = GetTXExem(TxtExempt6.Text)
      TxtExam6.Text = WrkTxExem(0)
      If MyLocEldDarien Then
        WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
        If MyUtils.CnvSng(WrkTxExem(2)) > 0 Then
          WrkAmt = CalcDarNet() * (MyUtils.CnvSng(WrkTxExem(2)) / 100)
          If MyUtils.CnvSng(WrkTxExem(0)) > WrkAmt Then
            WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
          End If
        End If
        TxtExam6.Text = WrkAmt
      End If
    End If
  End Sub
  Private Sub TxtExempt7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt7.TextChanged
    Dim WrkTxExem As String()
    Dim WrkAmt As Integer

    If LoadScrn Then Exit Sub

    If TxtExempt7.Text = "APA" Then
      TxtExam7.Text = CalcExamAPA()
    Else
      WrkTxExem = GetTXExem(TxtExempt7.Text)
      TxtExam7.Text = WrkTxExem(0)
      If MyLocEldDarien Then
        WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
        If MyUtils.CnvSng(WrkTxExem(2)) > 0 Then
          WrkAmt = CalcDarNet() * (MyUtils.CnvSng(WrkTxExem(2)) / 100)
          If MyUtils.CnvSng(WrkTxExem(0)) > WrkAmt Then
            WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
          End If
        End If
        TxtExam7.Text = WrkAmt
      End If
    End If
  End Sub
  Private Sub LnkExemptCd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExemptCd.LinkClicked
    MyFrmListExempt = New FrmListExempt
    MyFrmListExempt.MdiParent = Me.ParentForm
    MyFrmListExempt.WrkFile = "RE"
    MyFrmListExempt.WrkCode = TxtExemptCd.Text
    MyFrmListExempt.Show()
  End Sub
  Private Sub LblTransExemptCd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTranExemptCd.LinkClicked
    MyFrmListExempt = New FrmListExempt
    MyFrmListExempt.MdiParent = Me.ParentForm
    MyFrmListExempt.WrkFile = "Trans"
    MyFrmListExempt.WrkCode = TxtTranExemptCd.Text
    MyFrmListExempt.Show()
  End Sub
  Private Sub RbCatTaxable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbCatTaxable.CheckedChanged
    LnkExemptCd.Enabled = False
    TxtExemptCd.Enabled = False
    LblTaxExempt.Visible = False
  End Sub
  Private Sub RbCatExempt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbCatExempt.CheckedChanged
    LnkExemptCd.Enabled = True
    TxtExemptCd.Enabled = True
    LblTaxExempt.Visible = True
  End Sub
  Private Sub RbTranTaxable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbTranTaxable.CheckedChanged
    LnkTranExemptCd.Enabled = False
    TxtTranExemptCd.Enabled = False
  End Sub
  Private Sub RbTranExempt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbTranExempt.CheckedChanged
    LnkTranExemptCd.Enabled = True
    TxtTranExemptCd.Enabled = True
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
  Private Sub TxtExempt6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtExempt6.Leave
    SetExem6Tip()
  End Sub
  Private Sub TxtExempt7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtExempt7.Leave
    SetExem7Tip()
  End Sub
  Private Sub LnkBankCd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBankCd.LinkClicked
    MyFrmListBanks = New FrmListBanks
    MyFrmListBanks.MdiParent = Me.ParentForm
    MyFrmListBanks.WrkCode = TxtBankCd.Text
    MyFrmListBanks.Show()
  End Sub
  Private Sub TxtBankCd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBankCd.Leave
    SetBankTip()
  End Sub

  Private Sub TpMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpMain.Click

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
  Private Sub SetExemptCdTip()
    Dim WrkDesc As String

    If Not TxtExemptCd.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXXPROPDesc(TxtExemptCd.Text)
    Ttp1.SetToolTip(TxtExemptCd, WrkDesc)
  End Sub
  Private Sub SetTranExemptCdTip()
    Dim WrkDesc As String

    If Not TxtTranExemptCd.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXXPROPDesc(TxtTranExemptCd.Text)
    Ttp1.SetToolTip(TxtTranExemptCd, WrkDesc)
  End Sub

  Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtZip5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZip5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtZip4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZip4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtPdst_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPdst.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSunit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtPurPrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPurPrice.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtVetYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVetYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtLocPerc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
  Private Sub TxtAcre1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAcre1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtAcre2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAcre2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtAcre3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAcre3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtAcre4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAcre4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtAcre5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAcre5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtAcre6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAcre6.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtAcre7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAcre7.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtBaa1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBaa1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBaa2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBaa2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBaa3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBaa3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBaa4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBaa4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBaa5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBaa5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBaa6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBaa6.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBaa7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBaa7.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtEldYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEldYear.KeyPress
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
  Private Sub TxtTranZip5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTranZip5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtTranZip4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTranZip4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtTranPrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTranPrice.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtTranBlock_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTranBlock.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtTranTract_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTranTract.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtPZGrossAcre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPZGrossAcre.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtPZBldAcre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPZBldAcre.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtPZBed_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPZBed.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtPZBath_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPZBath.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtActAcres_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtActAcres.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtPhinAssmnt1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    CalcPhaseIn()
  End Sub
  Private Sub TxtPhinAssmnt2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    CalcPhaseIn()
  End Sub
  Private Sub TxtPhinAssmnt3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    CalcPhaseIn()
  End Sub
  Private Sub TxtPhinAssmnt4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    CalcPhaseIn()
  End Sub
  Private Sub TxtPhinAssmnt5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    CalcPhaseIn()
  End Sub
  Private Sub TxtPhinAssmnt6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    CalcPhaseIn()
  End Sub
  Private Sub TxtPhinAssmnt7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    CalcPhaseIn()
  End Sub
  Private Sub CalcPhaseIn()

    LblAdjGross.Text = MyUtils.CnvSng(LblAdjAssmnt1.Text) + MyUtils.CnvSng(LblAdjAssmnt2.Text) + MyUtils.CnvSng(LblAdjAssmnt3.Text) +
    MyUtils.CnvSng(LblAdjAssmnt4.Text) + MyUtils.CnvSng(LblAdjAssmnt5.Text) + MyUtils.CnvSng(LblAdjAssmnt6.Text) +
    MyUtils.CnvSng(LblAdjAssmnt7.Text)
  End Sub

  Private Sub RbEldFrozen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click

    With MyFrmTA001B
      If .C1DataGrdList.Row = .C1DataGrdList.Splits(0).Rows.Count - 1 Then
        MsgBox("No more records in view. You can change the view from the search screen", MsgBoxStyle.Exclamation, "Cannot get next record")
        Exit Sub
      End If
      .C1DataGrdList.Row = .C1DataGrdList.Row + 1
      WrkListNo = .C1DataGrdList.Item(.C1DataGrdList.Row, 0)
    End With

    LoadForm()

  End Sub
  Private Sub BtnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click
    With MyFrmTA001B
      If .C1DataGrdList.Row = 0 Then
        MsgBox("No previous records in view. You can change the view from the search screen", MsgBoxStyle.Exclamation, "Cannot get previous record")
        Exit Sub
      End If

      .C1DataGrdList.Row = .C1DataGrdList.Row - 1
      WrkListNo = .C1DataGrdList.Item(.C1DataGrdList.Row, 0)
    End With

    LoadForm()

  End Sub
  Private Sub DtPckBtr_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtPckBtr.ValueChanged
    CalcBTR()
  End Sub
  Private Sub ChkDnbtr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkDnbtr.Click
    CalcBTR()
  End Sub
  Private Sub LnkLocAmt_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkLocAmt.LinkClicked
    MyFrmTA001LocAmt = New FrmTA001LocAmt
    With MyFrmTA001LocAmt
      .WrkListNo = WrkListNo
      .WrkType = WrkType
      .MdiParent = Me.ParentForm
      .Show()
    End With
    Me.Hide()
  End Sub
  Private Function CalcDarNet() As Integer
    Dim WrkCode(6) As String
    Dim WrkExam(6) As Integer
    Dim WrkGross As Integer
    Dim WrkTExam As Integer
    Dim J As Integer
    If MyLocEldDarien Then
      WrkCode(0) = TxtExempt1.Text
      WrkCode(1) = TxtExempt2.Text
      WrkCode(2) = TxtExempt3.Text
      WrkCode(3) = TxtExempt4.Text
      WrkCode(4) = TxtExempt5.Text
      WrkCode(5) = TxtExempt6.Text
      WrkCode(6) = TxtExempt7.Text
      WrkGross = MyUtils.CnvSng(LblGross.Text)
      WrkExam(0) = MyUtils.CnvSng(TxtExam1.Text)
      WrkExam(1) = MyUtils.CnvSng(TxtExam2.Text)
      WrkExam(2) = MyUtils.CnvSng(TxtExam3.Text)
      WrkExam(3) = MyUtils.CnvSng(TxtExam4.Text)
      WrkExam(4) = MyUtils.CnvSng(TxtExam5.Text)
      WrkExam(5) = MyUtils.CnvSng(TxtExam6.Text)
      WrkExam(6) = MyUtils.CnvSng(TxtExam7.Text)
      WrkTExam = 0
      For J = 0 To 6
        If WrkCode(J) <> cDarExcd1 And WrkCode(J) <> cDarExcd2 _
        And WrkCode(J) <> cDarExcd3 And WrkCode(J) <> cDarExcd4 Then
          WrkTExam = WrkTExam + WrkExam(J)
        End If
      Next J
      Return (WrkGross - WrkTExam)
    End If

  End Function
  Private Function CalcExamAPA() As Integer
    Dim WrkAmt As Integer
    If Trim(TxtCode1.Text) = "13" Or Trim(TxtCode1.Text) = "15" Then
      WrkAmt = WrkAmt + MyUtils.CnvSng(TxtAssmt1.Text)
    End If
    If Trim(TxtCode2.Text) = "13" Or Trim(TxtCode2.Text) = "15" Then
      WrkAmt = WrkAmt + MyUtils.CnvSng(TxtAssmt2.Text)
    End If
    If Trim(TxtCode3.Text) = "13" Or Trim(TxtCode3.Text) = "15" Then
      WrkAmt = WrkAmt + MyUtils.CnvSng(TxtAssmt3.Text)
    End If
    If Trim(TxtCode4.Text) = "13" Or Trim(TxtCode4.Text) = "15" Then
      WrkAmt = WrkAmt + MyUtils.CnvSng(TxtAssmt4.Text)
    End If
    If Trim(TxtCode5.Text) = "13" Or Trim(TxtCode5.Text) = "15" Then
      WrkAmt = WrkAmt + MyUtils.CnvSng(TxtAssmt5.Text)
    End If
    If Trim(TxtCode6.Text) = "13" Or Trim(TxtCode6.Text) = "15" Then
      WrkAmt = WrkAmt + MyUtils.CnvSng(TxtAssmt6.Text)
    End If
    If Trim(TxtCode7.Text) = "13" Or Trim(TxtCode7.Text) = "15" Then
      WrkAmt = WrkAmt + MyUtils.CnvSng(TxtAssmt7.Text)
    End If
    Return WrkAmt
  End Function

End Class
