Imports System.Data
Public Class FrmTAD05RE
  Inherits System.Windows.Forms.Form
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkFastPath As Boolean
  Dim myTXREAA As TXREAA.MyData
  Dim myTXBAA As TXBAA.MyData
  Dim LoadScrn As Boolean

  '' LL Update TAD05 for Phase In tab
  Dim myTXPHIA As TXPHIA.MyData

  Dim logre_ds As DataSet = New DataSet
  Friend WithEvents ChkNoCama As System.Windows.Forms.CheckBox
  Friend WithEvents LblElderly As System.Windows.Forms.Label
  Friend WithEvents BtnNext As System.Windows.Forms.Button
  Friend WithEvents BtnPrevious As System.Windows.Forms.Button
  Friend WithEvents LblLocalBen As System.Windows.Forms.Label
  Friend WithEvents LblLocAmt As System.Windows.Forms.Label
  Friend WithEvents LblTaxExempt As System.Windows.Forms.Label
  Friend WithEvents LblEldPgm As System.Windows.Forms.Label
  Friend WithEvents LblEldAdj As System.Windows.Forms.Label
  Friend WithEvents LblEldTax As System.Windows.Forms.Label
  Friend WithEvents LblEldMin As System.Windows.Forms.Label
  Friend WithEvents LblEldMax As System.Windows.Forms.Label
  Friend WithEvents LblEldPerc As System.Windows.Forms.Label
  Friend WithEvents Label31 As System.Windows.Forms.Label
  Friend WithEvents TxtEldYear As System.Windows.Forms.TextBox
  Friend WithEvents LblSunit As System.Windows.Forms.Label
  Friend WithEvents LblBeforeCC As System.Windows.Forms.Label
  Friend WithEvents LblYear As Label
  Friend WithEvents BtnDown As Button
  Const WrkType As String = "R"
  Friend WithEvents BtnUp As Button
  Friend WithEvents TpPhaseIn As TabPage
  Friend WithEvents LblNoPhaseIn As Label
  Friend WithEvents GroupBox8 As GroupBox
  Friend WithEvents LblTotAssmnt1 As Label
  Friend WithEvents Label22 As Label
  Friend WithEvents LblTot As Label
  Friend WithEvents Label11 As Label
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
  Friend WithEvents LblCurrGross As Label
  Friend WithEvents LblCurrAssmnt7 As Label
  Friend WithEvents LblCurrAssmnt6 As Label
  Friend WithEvents LblCurrAssmnt5 As Label
  Friend WithEvents LblCurrAssmnt4 As Label
  Friend WithEvents LblCurrAssmnt3 As Label
  Friend WithEvents LblCurrAssmnt2 As Label
  Friend WithEvents Label53 As Label
  Friend WithEvents LblCurrAssmnt1 As Label
  Friend WithEvents Label32 As Label
  Friend WithEvents LblOrigGross As Label
  Friend WithEvents LblPhaseGross As Label
  Friend WithEvents LblFullGross As Label
  Friend WithEvents LblAdjGross As Label
  Friend WithEvents LblPhaseAssmnt7 As Label
  Friend WithEvents LblPhaseCode7 As Label
  Friend WithEvents LblTotAssmnt7 As Label
  Friend WithEvents LblPhaseAssmnt6 As Label
  Friend WithEvents LblPhaseCode6 As Label
  Friend WithEvents LblTotAssmnt6 As Label
  Friend WithEvents LblPhaseAssmnt5 As Label
  Friend WithEvents LblPhaseCode5 As Label
  Friend WithEvents LblTotAssmnt5 As Label
  Friend WithEvents LblPhaseAssmnt4 As Label
  Friend WithEvents LblPhaseCode4 As Label
  Friend WithEvents LblTotAssmnt4 As Label
  Friend WithEvents LblPhaseAssmnt3 As Label
  Friend WithEvents LblPhaseCode3 As Label
  Friend WithEvents LblTotAssmnt3 As Label
  Friend WithEvents LblPhaseAssmnt2 As Label
  Friend WithEvents LblPhaseCode2 As Label
  Friend WithEvents LblTotAssmnt2 As Label
  Friend WithEvents Label14 As Label
  Friend WithEvents LblPhaseAssmnt1 As Label
  Friend WithEvents Label18 As Label
  Friend WithEvents LblPhaseCode1 As Label
  Friend WithEvents Label19 As Label
  Dim WrkAdjYear As Integer
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
  Friend WithEvents TpAct490 As System.Windows.Forms.TabPage
  Friend WithEvents Label83 As System.Windows.Forms.Label
  Friend WithEvents Label84 As System.Windows.Forms.Label
  Friend WithEvents Label85 As System.Windows.Forms.Label
  Friend WithEvents TxtActAcres As System.Windows.Forms.TextBox
  Friend WithEvents DtPckActInit As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckActExpir As System.Windows.Forms.DateTimePicker
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
    Me.TpAct490 = New System.Windows.Forms.TabPage()
    Me.DtPckActExpir = New System.Windows.Forms.DateTimePicker()
    Me.Label85 = New System.Windows.Forms.Label()
    Me.DtPckActInit = New System.Windows.Forms.DateTimePicker()
    Me.Label84 = New System.Windows.Forms.Label()
    Me.TxtActAcres = New System.Windows.Forms.TextBox()
    Me.Label83 = New System.Windows.Forms.Label()
    Me.TpPhaseIn = New System.Windows.Forms.TabPage()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.LblTotAssmnt1 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.LblTot = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblAdjAssmnt7 = New System.Windows.Forms.Label()
        Me.LblAdjAssmnt6 = New System.Windows.Forms.Label()
        Me.LblAdjAssmnt5 = New System.Windows.Forms.Label()
        Me.LblAdjAssmnt4 = New System.Windows.Forms.Label()
        Me.LblAdjAssmnt3 = New System.Windows.Forms.Label()
        Me.LblAdjAssmnt2 = New System.Windows.Forms.Label()
        Me.LblAdjAssmnt1 = New System.Windows.Forms.Label()
        Me.LblAdjCode7 = New System.Windows.Forms.Label()
        Me.LblAdjCode6 = New System.Windows.Forms.Label()
        Me.LblAdjCode5 = New System.Windows.Forms.Label()
        Me.LblAdjCode4 = New System.Windows.Forms.Label()
        Me.LblAdjCode3 = New System.Windows.Forms.Label()
        Me.LblAdjCode2 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.LblAdjCode1 = New System.Windows.Forms.Label()
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
        Me.LblNoPhaseIn = New System.Windows.Forms.Label()
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
        Me.LblElderly = New System.Windows.Forms.Label()
        Me.BtnNext = New System.Windows.Forms.Button()
        Me.BtnPrevious = New System.Windows.Forms.Button()
        Me.LblLocalBen = New System.Windows.Forms.Label()
        Me.LblTaxExempt = New System.Windows.Forms.Label()
        Me.LblBeforeCC = New System.Windows.Forms.Label()
        Me.LblYear = New System.Windows.Forms.Label()
        Me.BtnDown = New System.Windows.Forms.Button()
        Me.BtnUp = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TpMain.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TpEld.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
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
        Me.TabControl1.Controls.Add(Me.TpAct490)
        Me.TabControl1.Controls.Add(Me.TpPhaseIn)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 196)
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
        Me.TpPhaseIn.Controls.Add(Me.GroupBox8)
        Me.TpPhaseIn.Controls.Add(Me.LblNoPhaseIn)
        Me.TpPhaseIn.Location = New System.Drawing.Point(4, 25)
        Me.TpPhaseIn.Name = "TpPhaseIn"
        Me.TpPhaseIn.Padding = New System.Windows.Forms.Padding(3)
        Me.TpPhaseIn.Size = New System.Drawing.Size(728, 331)
        Me.TpPhaseIn.TabIndex = 5
        Me.TpPhaseIn.Text = "Phase In"
        Me.TpPhaseIn.UseVisualStyleBackColor = True
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
        Me.GroupBox8.Location = New System.Drawing.Point(11, 17)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(654, 231)
        Me.GroupBox8.TabIndex = 233
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Assessment Property Codes"
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
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(371, 16)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 16)
        Me.Label22.TabIndex = 246
        Me.Label22.Text = "CC/BAA"
        Me.Ttp1.SetToolTip(Me.Label22, "Assessment at Freeze Time")
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
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(546, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 244
        Me.Label11.Text = "Full Phase In"
        Me.Ttp1.SetToolTip(Me.Label11, "Assessment at Freeze Time")
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
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.Black
        Me.Label53.Location = New System.Drawing.Point(238, 16)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(73, 13)
        Me.Label53.TabIndex = 221
        Me.Label53.Text = "Assessment"
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
        'LblNoPhaseIn
        '
        Me.LblNoPhaseIn.AutoSize = True
        Me.LblNoPhaseIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNoPhaseIn.ForeColor = System.Drawing.Color.Fuchsia
        Me.LblNoPhaseIn.Location = New System.Drawing.Point(8, 261)
        Me.LblNoPhaseIn.Name = "LblNoPhaseIn"
        Me.LblNoPhaseIn.Size = New System.Drawing.Size(256, 15)
        Me.LblNoPhaseIn.TabIndex = 232
        Me.LblNoPhaseIn.Text = "This account is not part of the Phase In"
        Me.LblNoPhaseIn.Visible = False
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
        Me.Label4.Location = New System.Drawing.Point(8, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 142
        Me.Label4.Text = "City/State/Zip"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 141
        Me.Label3.Text = "Street Address"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "Second Name"
        '
        'TxtListNo
        '
        Me.TxtListNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtListNo.Location = New System.Drawing.Point(96, 8)
        Me.TxtListNo.MaxLength = 7
        Me.TxtListNo.Name = "TxtListNo"
        Me.TxtListNo.Size = New System.Drawing.Size(65, 22)
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
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 139
        Me.Label1.Text = "List No"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 138
        Me.Label5.Text = "Name"
        '
        'LblElderly
        '
        Me.LblElderly.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblElderly.ForeColor = System.Drawing.Color.Fuchsia
        Me.LblElderly.Location = New System.Drawing.Point(505, 78)
        Me.LblElderly.Name = "LblElderly"
        Me.LblElderly.Size = New System.Drawing.Size(59, 20)
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
        Me.LblLocalBen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLocalBen.ForeColor = System.Drawing.Color.Fuchsia
        Me.LblLocalBen.Location = New System.Drawing.Point(470, 98)
        Me.LblLocalBen.Name = "LblLocalBen"
        Me.LblLocalBen.Size = New System.Drawing.Size(94, 20)
        Me.LblLocalBen.TabIndex = 175
        Me.LblLocalBen.Text = "Local Benefit"
        Me.LblLocalBen.Visible = False
        '
        'LblTaxExempt
        '
        Me.LblTaxExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTaxExempt.ForeColor = System.Drawing.Color.Fuchsia
        Me.LblTaxExempt.Location = New System.Drawing.Point(470, 58)
        Me.LblTaxExempt.Name = "LblTaxExempt"
        Me.LblTaxExempt.Size = New System.Drawing.Size(94, 20)
        Me.LblTaxExempt.TabIndex = 196
        Me.LblTaxExempt.Text = "Tax Exempt"
        Me.LblTaxExempt.Visible = False
        '
        'LblBeforeCC
        '
        Me.LblBeforeCC.AutoSize = True
        Me.LblBeforeCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBeforeCC.ForeColor = System.Drawing.Color.Fuchsia
        Me.LblBeforeCC.Location = New System.Drawing.Point(438, 39)
        Me.LblBeforeCC.Name = "LblBeforeCC"
        Me.LblBeforeCC.Size = New System.Drawing.Size(119, 15)
        Me.LblBeforeCC.TabIndex = 200
        Me.LblBeforeCC.Text = "Before C/C #####"
        Me.LblBeforeCC.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.LblBeforeCC.Visible = False
        '
        'LblYear
        '
        Me.LblYear.BackColor = System.Drawing.Color.Aqua
        Me.LblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblYear.Location = New System.Drawing.Point(167, 10)
        Me.LblYear.Name = "LblYear"
        Me.LblYear.Size = New System.Drawing.Size(31, 16)
        Me.LblYear.TabIndex = 202
        Me.LblYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnDown
        '
        Me.BtnDown.ForeColor = System.Drawing.Color.Black
        Me.BtnDown.Location = New System.Drawing.Point(201, 6)
        Me.BtnDown.Name = "BtnDown"
        Me.BtnDown.Size = New System.Drawing.Size(53, 24)
        Me.BtnDown.TabIndex = 203
        Me.BtnDown.Text = "-Year"
        '
        'BtnUp
        '
        Me.BtnUp.ForeColor = System.Drawing.Color.Black
        Me.BtnUp.Location = New System.Drawing.Point(260, 6)
        Me.BtnUp.Name = "BtnUp"
        Me.BtnUp.Size = New System.Drawing.Size(51, 24)
        Me.BtnUp.TabIndex = 204
        Me.BtnUp.Text = "+Year"
        '
        'FrmTAD05RE
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(736, 518)
        Me.Controls.Add(Me.BtnUp)
        Me.Controls.Add(Me.BtnDown)
        Me.Controls.Add(Me.LblYear)
        Me.Controls.Add(Me.LblBeforeCC)
        Me.Controls.Add(Me.LblTaxExempt)
        Me.Controls.Add(Me.LblLocalBen)
        Me.Controls.Add(Me.BtnNext)
        Me.Controls.Add(Me.BtnPrevious)
        Me.Controls.Add(Me.LblElderly)
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
        Me.Name = "FrmTAD05RE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Real Estate  Archive"
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

    Private Sub FrmTAD05RE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXREAA = New TXREAA.MyData(myDBConnect)
    myTXBAA = New TXBAA.MyData(myDBConnect)

    '' LL Update TAD05 for Phase In tab, Using the new TXPHIA
    myTXPHIA = New TXPHIA.MyData(myDBConnect)

    WrkAdjYear = 0
    LoadForm()
  End Sub

  Private Sub FrmTAD05RE_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTAD05B.FormatGrid(True, False, False)
    MyFrmTAD05B.Show()
    'Memory Cleanup
    myTXREAA = Nothing
    myTXBAA = Nothing

    '' LL Update TAD05 for Phase In tab, Using the new TXPHIA
    myTXPHIA = Nothing

    MyFrmTAD05RE = Nothing
  End Sub
  Public Sub LoadForm()
    Dim WrkFrozenCode As String

    LoadScrn = True
    If WrkFastPath Then
      BtnPrevious.Visible = False
      BtnNext.Visible = False
    End If

    '' LL Update TAD05 for Phase In tab, Using the new TXPHIA
    If Not MyPhaseIn Then
      TabControl1.TabPages.Remove(TpPhaseIn)
      TabControl1.Refresh()
    End If

    'Fill the dataset with the existing data
    TxtListNo.ReadOnly = True
    TxtListNo.TabStop = False
    TxtListNo.Text = WrkListNo
    Select Case WrkAdjYear
      Case <> 0
        myTXREAA.GetOneRecordP(WrkListNo, WrkYear + WrkAdjYear)
        If myTXREAA.RecordNotFound Then
          WrkAdjYear = 0
        End If
      Case Else
    End Select
    LblYear.Text = WrkYear + WrkAdjYear
    myTXREAA.GetOneRecordP(WrkListNo, MyUtils.CnvSng(LblYear.Text))
    If myTXREAA.RecordNotFound Then
      Me.ErrProv.SetError(TxtListNo, "Record not found")
      Exit Sub
    End If

    With myTXREAA
      LblBeforeCC.Visible = False
      If ._CCNO > 0 Then
        LblBeforeCC.Visible = True
        LblBeforeCC.Text = "Before C/C " & ._CCNO
      End If
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
      TxtPdst.Text = ._PDST
      TxtOid.Text = Trim(._OID)
      TxtDist.Text = ._DIST
      TxtUnit.Text = Trim(._UNITNo)
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
    myTXBAA.GetOneRecordP(WrkListNo, WrkType, MyUtils.CnvSng(LblYear.Text))
    If Not myTXBAA.RecordNotFound Then
      With myTXBAA
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


    'Assessment Property Codes
    With myTXREAA
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


      'PhaseIn
      LblNoPhaseIn.Visible = False
      If MyPhaseIn Then
        myTXPHIA.GetOneRecordP(WrkListNo, MyUtils.CnvSng(LblYear.Text))
        With myTXPHIA
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

          If Not myTXREAA.RecordNotFound Then
            With myTXREAA
              If myTXBAA.RecordNotFound Then
                LblCurrAssmnt1.Text = ._ASS1
                LblCurrAssmnt2.Text = ._ASS2
                LblCurrAssmnt3.Text = ._ASS3
                LblCurrAssmnt4.Text = ._ASS4
                LblCurrAssmnt5.Text = ._ASS5
                LblCurrAssmnt6.Text = ._ASS6
                LblCurrAssmnt7.Text = ._ASS7
                LblCurrGross.Text = ._GROSS
              Else
                LblCurrAssmnt1.Text = ._ASS1 + myTXBAA._BASS1
                LblCurrAssmnt2.Text = ._ASS2 + myTXBAA._BASS2
                LblCurrAssmnt3.Text = ._ASS3 + myTXBAA._BASS3
                LblCurrAssmnt4.Text = ._ASS4 + myTXBAA._BASS4
                LblCurrAssmnt5.Text = ._ASS5 + myTXBAA._BASS5
                LblCurrAssmnt6.Text = ._ASS6 + myTXBAA._BASS6
                LblCurrAssmnt7.Text = ._ASS7 + myTXBAA._BASS7
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

    End With
    LoadScrn = False
  End Sub
  Private Sub FrmTAD05RE_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    MyFrmTAD05.SbpScreen.Text = "TAD05RE"
    MyUtils.CenterForm(Me.ParentForm, Me)
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
  Private Sub LnkExemptCd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExemptCd.LinkClicked
    MyFrmListExempt = New FrmListExempt
    MyFrmListExempt.MdiParent = Me.ParentForm
    MyFrmListExempt.WrkFile = "RE"
    MyFrmListExempt.WrkCode = TxtExemptCd.Text
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
  Private Sub TxtActAcres_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtActAcres.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click

    With MyFrmTAD05B
      If .C1DataGrdList.Row = .C1DataGrdList.Splits(0).Rows.Count - 1 Then
        MsgBox("No more records in view. You can change the view from the search screen", MsgBoxStyle.Exclamation, "Cannot get next record")
        Exit Sub
      End If
      .C1DataGrdList.Row = .C1DataGrdList.Row + 1
      WrkListNo = .C1DataGrdList.Item(.C1DataGrdList.Row, 0)
    End With
    WrkAdjYear = 0
    LoadForm()

  End Sub
  Private Sub BtnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click
    With MyFrmTAD05B
      If .C1DataGrdList.Row = 0 Then
        MsgBox("No previous records in view. You can change the view from the search screen", MsgBoxStyle.Exclamation, "Cannot get previous record")
        Exit Sub
      End If

      .C1DataGrdList.Row = .C1DataGrdList.Row - 1
      WrkListNo = .C1DataGrdList.Item(.C1DataGrdList.Row, 0)
    End With

    WrkAdjYear = 0
    LoadForm()

  End Sub
  Private Sub DtPckBtr_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtPckBtr.ValueChanged
    CalcBTR()
  End Sub
  Private Sub ChkDnbtr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkDnbtr.Click
    CalcBTR()
  End Sub

  Private Sub BtnDown_Click(sender As Object, e As EventArgs) Handles BtnDown.Click
    WrkAdjYear = WrkAdjYear - 1
    LoadForm()
  End Sub
  Private Sub BtnUp_Click(sender As Object, e As EventArgs) Handles BtnUp.Click
    WrkAdjYear = WrkAdjYear + 1
    LoadForm()
  End Sub

  Private Sub TxtBaa7_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtAssmt7_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtBaa6_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtAssmt6_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtBaa4_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtAssmt4_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtBaa5_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtAssmt5_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtBaa3_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtAssmt3_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtBaa2_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtAssmt2_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtBaa1_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtAssmt1_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub LnkLocAmt_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

  End Sub

  Private Sub TxtExempt6_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtExempt7_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtExempt5_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtExempt3_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtExempt4_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtExempt2_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtExempt1_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtExam7_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtExam6_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtExam4_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtExam2_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtExam5_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtExam3_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtExam1_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtTranTract_KeyPress(sender As Object, e As KeyPressEventArgs)

  End Sub

  Private Sub TxtTranBlock_KeyPress(sender As Object, e As KeyPressEventArgs)

  End Sub

  Private Sub TxtTranPrice_KeyPress(sender As Object, e As KeyPressEventArgs)

  End Sub

  Private Sub LblTransExemptCd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

  End Sub

  Private Sub RbTranExempt_CheckedChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub RbTranTaxable_CheckedChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtTranZip4_KeyPress(sender As Object, e As KeyPressEventArgs)

  End Sub

  Private Sub TxtTranZip5_KeyPress(sender As Object, e As KeyPressEventArgs)

  End Sub

  Private Sub TxtPZBath_KeyPress(sender As Object, e As KeyPressEventArgs)

  End Sub

  Private Sub TxtPZBed_KeyPress(sender As Object, e As KeyPressEventArgs)

  End Sub

  Private Sub TxtPZBldAcre_KeyPress(sender As Object, e As KeyPressEventArgs)

  End Sub

  Private Sub TxtPZGrossAcre_KeyPress(sender As Object, e As KeyPressEventArgs)

  End Sub

  Private Sub LnkPhinCode6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

  End Sub

  Private Sub LnkPhinCode4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

  End Sub

  Private Sub LnkPhinCode2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

  End Sub

  Private Sub LnkPhinCode7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

  End Sub

  Private Sub LnkPhinCode5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

  End Sub

  Private Sub LnkPhinCode3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

  End Sub

  Private Sub LnkPhinCode1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

  End Sub

  Private Sub TxtPhinAssmnt7_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtPhinAssmnt6_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtPhinAssmnt4_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtPhinAssmnt5_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtPhinAssmnt3_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtPhinAssmnt2_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub TxtPhinAssmnt1_TextChanged(sender As Object, e As EventArgs)

  End Sub

  Private Sub LblCurrAssmnt1_Click(sender As Object, e As EventArgs)

  End Sub
End Class






