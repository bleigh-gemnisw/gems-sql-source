Imports System.Data
Public Class FrmTA8102R
  Inherits System.Windows.Forms.Form
	Dim myTXCOEB As TXCOEB.myData
	Dim myTXCOEBL4 As TXCOEBL4.myData
	Dim myTXREALC As TXREALC.myData
  Dim myTXREAA As TXREAA.myData
  Dim myTXINV As TXINV.myData
  Dim myTXBAA As TXBAA.MyData
  Dim MyTXPHIN As TXPHIN.MyData
  Dim MyTXPHCNTL As TXPHCNTL.MyData
  Dim dsTXCOEBL4 As DataSet = New DataSet

  Friend WrkAddMode As Boolean
  Friend WrkCCNo As Integer
  Friend WrkCCDate As Date
  Friend WrkListNo As Integer
	Friend WrkYear As Integer
	Friend WrkType As String
	Dim LoadScrn As Boolean
  Dim WrkPhaseCurrYear As Integer
  Dim WrkPhaseTotalYears As Integer
  Friend WithEvents LblOrigName As System.Windows.Forms.Label
  Friend WithEvents Label28 As System.Windows.Forms.Label
	Friend WithEvents Label27 As System.Windows.Forms.Label

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
	Friend WithEvents TxtVol As System.Windows.Forms.TextBox
	Friend WithEvents TxtPage As System.Windows.Forms.TextBox
	Friend WithEvents Label33 As System.Windows.Forms.Label
	Friend WithEvents TxtMap As System.Windows.Forms.TextBox
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents TxtDist As System.Windows.Forms.TextBox
	Friend WithEvents Label42 As System.Windows.Forms.Label
	Friend WithEvents TxtLoc As System.Windows.Forms.TextBox
	Friend WithEvents TxtLocNo As System.Windows.Forms.TextBox
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
	Friend WithEvents TpMain As System.Windows.Forms.TabPage
	Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
	Friend WithEvents TxtExam4 As System.Windows.Forms.TextBox
	Friend WithEvents TxtExam2 As System.Windows.Forms.TextBox
	Friend WithEvents TxtExam5 As System.Windows.Forms.TextBox
	Friend WithEvents TxtExam3 As System.Windows.Forms.TextBox
	Friend WithEvents TxtExam1 As System.Windows.Forms.TextBox
	Friend WithEvents Label50 As System.Windows.Forms.Label
	Friend WithEvents Label52 As System.Windows.Forms.Label
	Friend WithEvents TxtExam6 As System.Windows.Forms.TextBox
	Friend WithEvents TxtExam7 As System.Windows.Forms.TextBox
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents Label34 As System.Windows.Forms.Label
	Friend WithEvents Label30 As System.Windows.Forms.Label
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
	Friend WithEvents TxtName As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
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
	Friend WithEvents Label8 As System.Windows.Forms.Label
	Friend WithEvents Label9 As System.Windows.Forms.Label
	Friend WithEvents LblYear As System.Windows.Forms.Label
	Friend WithEvents LblType As System.Windows.Forms.Label
	Friend WithEvents Label12 As System.Windows.Forms.Label
	Friend WithEvents Label13 As System.Windows.Forms.Label
	Friend WithEvents TpExemptions As System.Windows.Forms.TabPage
	Friend WithEvents TpAssmnt As System.Windows.Forms.TabPage
	Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
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
	Friend WithEvents TxtUnit2 As System.Windows.Forms.TextBox
	Friend WithEvents Label23 As System.Windows.Forms.Label
	Friend WithEvents Label18 As System.Windows.Forms.Label
	Friend WithEvents TxtAssmt1 As System.Windows.Forms.TextBox
	Friend WithEvents Label17 As System.Windows.Forms.Label
	Friend WithEvents Label16 As System.Windows.Forms.Label
	Friend WithEvents TxtUnit1 As System.Windows.Forms.TextBox
	Friend WithEvents Label10 As System.Windows.Forms.Label
	Friend WithEvents TxtReason As System.Windows.Forms.TextBox
	Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
	Friend WithEvents Label14 As System.Windows.Forms.Label
	Friend WithEvents Label19 As System.Windows.Forms.Label
	Friend WithEvents Label20 As System.Windows.Forms.Label
	Friend WithEvents Label22 As System.Windows.Forms.Label
	Friend WithEvents Label58 As System.Windows.Forms.Label
	Friend WithEvents Label70 As System.Windows.Forms.Label
	Friend WithEvents LblChgAssmt1 As System.Windows.Forms.Label
	Friend WithEvents LblOrigAssmt1 As System.Windows.Forms.Label
	Friend WithEvents LblOrigAssmt2 As System.Windows.Forms.Label
	Friend WithEvents LblOrigAssmt3 As System.Windows.Forms.Label
	Friend WithEvents LblOrigAssmt4 As System.Windows.Forms.Label
	Friend WithEvents LblOrigAssmt5 As System.Windows.Forms.Label
	Friend WithEvents LblOrigAssmt6 As System.Windows.Forms.Label
	Friend WithEvents LblOrigAssmt7 As System.Windows.Forms.Label
	Friend WithEvents LblChgAssmt2 As System.Windows.Forms.Label
	Friend WithEvents LblChgAssmt3 As System.Windows.Forms.Label
	Friend WithEvents LblChgAssmt4 As System.Windows.Forms.Label
	Friend WithEvents LblChgAssmt5 As System.Windows.Forms.Label
	Friend WithEvents LblChgAssmt6 As System.Windows.Forms.Label
	Friend WithEvents LblChgAssmt7 As System.Windows.Forms.Label
	Friend WithEvents LblOrigExam1 As System.Windows.Forms.Label
	Friend WithEvents LblOrigExam7 As System.Windows.Forms.Label
	Friend WithEvents LblOrigExam6 As System.Windows.Forms.Label
	Friend WithEvents LblOrigExam5 As System.Windows.Forms.Label
	Friend WithEvents LblOrigExam4 As System.Windows.Forms.Label
	Friend WithEvents LblOrigExam3 As System.Windows.Forms.Label
	Friend WithEvents LblOrigExam2 As System.Windows.Forms.Label
	Friend WithEvents LblChgExam7 As System.Windows.Forms.Label
	Friend WithEvents LblChgExam6 As System.Windows.Forms.Label
	Friend WithEvents LblChgExam5 As System.Windows.Forms.Label
	Friend WithEvents LblChgExam4 As System.Windows.Forms.Label
	Friend WithEvents LblChgExam3 As System.Windows.Forms.Label
	Friend WithEvents LblChgExam2 As System.Windows.Forms.Label
	Friend WithEvents LblChgExam1 As System.Windows.Forms.Label
	Friend WithEvents LblChgGross As System.Windows.Forms.Label
	Friend WithEvents LblNewGross As System.Windows.Forms.Label
	Friend WithEvents LblOrigGross As System.Windows.Forms.Label
	Friend WithEvents LblOrigExam As System.Windows.Forms.Label
	Friend WithEvents LblNewExam As System.Windows.Forms.Label
	Friend WithEvents LblChgExam As System.Windows.Forms.Label
	Friend WithEvents LblOrigNet As System.Windows.Forms.Label
	Friend WithEvents LblNewNet As System.Windows.Forms.Label
	Friend WithEvents LblChgNet As System.Windows.Forms.Label
	Friend WithEvents LblCCDate As System.Windows.Forms.Label
	Friend WithEvents Label25 As System.Windows.Forms.Label
	Friend WithEvents LblBankCd As System.Windows.Forms.Label
	Friend WithEvents LnkReason As System.Windows.Forms.LinkLabel
	Friend WithEvents LblCCNo As System.Windows.Forms.Label
	Friend WithEvents LblListNo As System.Windows.Forms.Label
	Friend WithEvents LblOrig As System.Windows.Forms.Label
	Friend WithEvents TxtUnit As System.Windows.Forms.TextBox
	Friend WithEvents Label11 As System.Windows.Forms.Label
	Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
	Friend WithEvents LnkExemptCd As System.Windows.Forms.LinkLabel
	Friend WithEvents TxtExemptCd As System.Windows.Forms.TextBox
	Friend WithEvents RbCatExempt As System.Windows.Forms.RadioButton
	Friend WithEvents RbCatTaxable As System.Windows.Forms.RadioButton
	Friend WithEvents TxtSMap As System.Windows.Forms.TextBox
	Friend WithEvents Label15 As System.Windows.Forms.Label
	Friend WithEvents LblBackTxCd As System.Windows.Forms.Label
	Friend WithEvents Label26 As System.Windows.Forms.Label
	Friend WithEvents DtPckPurDate As System.Windows.Forms.DateTimePicker
	Friend WithEvents Label36 As System.Windows.Forms.Label
Friend WithEvents GrpFreeze As System.Windows.Forms.GroupBox
Friend WithEvents LblFreezeYear As System.Windows.Forms.Label
Friend WithEvents Label35 As System.Windows.Forms.Label
Friend WithEvents LblFreezeAmt As System.Windows.Forms.Label
Friend WithEvents Label44 As System.Windows.Forms.Label
Friend WithEvents GrpHeart As System.Windows.Forms.GroupBox
Friend WithEvents Label31 As System.Windows.Forms.Label
Friend WithEvents Label24 As System.Windows.Forms.Label
Friend WithEvents LblHeartMax As System.Windows.Forms.Label
Friend WithEvents LblHeartMin As System.Windows.Forms.Label
Friend WithEvents LblHeartPct As System.Windows.Forms.Label
Friend WithEvents Label29 As System.Windows.Forms.Label
Friend WithEvents LblHeartAmt As System.Windows.Forms.Label
Friend WithEvents Label40 As System.Windows.Forms.Label
Friend WithEvents LblChgCred As System.Windows.Forms.Label
Friend WithEvents LblNewCred As System.Windows.Forms.Label
Friend WithEvents LblOrigCred As System.Windows.Forms.Label
Friend WithEvents Label21 As System.Windows.Forms.Label
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TpMain = New System.Windows.Forms.TabPage()
    Me.GrpFreeze = New System.Windows.Forms.GroupBox()
    Me.LblFreezeYear = New System.Windows.Forms.Label()
    Me.Label35 = New System.Windows.Forms.Label()
    Me.LblFreezeAmt = New System.Windows.Forms.Label()
    Me.Label44 = New System.Windows.Forms.Label()
    Me.GrpHeart = New System.Windows.Forms.GroupBox()
    Me.Label31 = New System.Windows.Forms.Label()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.LblHeartMax = New System.Windows.Forms.Label()
    Me.LblHeartMin = New System.Windows.Forms.Label()
    Me.LblHeartPct = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.LblHeartAmt = New System.Windows.Forms.Label()
    Me.Label40 = New System.Windows.Forms.Label()
    Me.DtPckPurDate = New System.Windows.Forms.DateTimePicker()
    Me.Label36 = New System.Windows.Forms.Label()
    Me.LblBackTxCd = New System.Windows.Forms.Label()
    Me.Label26 = New System.Windows.Forms.Label()
    Me.TxtSMap = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.LnkExemptCd = New System.Windows.Forms.LinkLabel()
    Me.TxtExemptCd = New System.Windows.Forms.TextBox()
    Me.RbCatExempt = New System.Windows.Forms.RadioButton()
    Me.RbCatTaxable = New System.Windows.Forms.RadioButton()
    Me.TxtUnit = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.LnkReason = New System.Windows.Forms.LinkLabel()
    Me.LblBankCd = New System.Windows.Forms.Label()
    Me.Label25 = New System.Windows.Forms.Label()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.TxtDesc = New System.Windows.Forms.TextBox()
    Me.TxtReason = New System.Windows.Forms.TextBox()
    Me.TxtVol = New System.Windows.Forms.TextBox()
    Me.TxtPage = New System.Windows.Forms.TextBox()
    Me.Label33 = New System.Windows.Forms.Label()
    Me.TxtMap = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtLoc = New System.Windows.Forms.TextBox()
    Me.TxtLocNo = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TpAssmnt = New System.Windows.Forms.TabPage()
    Me.Label28 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblChgAssmt7 = New System.Windows.Forms.Label()
    Me.LblChgAssmt6 = New System.Windows.Forms.Label()
    Me.LblChgAssmt5 = New System.Windows.Forms.Label()
    Me.LblChgAssmt4 = New System.Windows.Forms.Label()
    Me.LblChgAssmt3 = New System.Windows.Forms.Label()
    Me.LblChgAssmt2 = New System.Windows.Forms.Label()
    Me.LblOrigAssmt7 = New System.Windows.Forms.Label()
    Me.LblOrigAssmt6 = New System.Windows.Forms.Label()
    Me.LblOrigAssmt5 = New System.Windows.Forms.Label()
    Me.LblOrigAssmt4 = New System.Windows.Forms.Label()
    Me.LblOrigAssmt3 = New System.Windows.Forms.Label()
    Me.LblOrigAssmt2 = New System.Windows.Forms.Label()
    Me.LblChgAssmt1 = New System.Windows.Forms.Label()
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
    Me.TxtUnit2 = New System.Windows.Forms.TextBox()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.TxtAssmt1 = New System.Windows.Forms.TextBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.TxtUnit1 = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.LblOrigAssmt1 = New System.Windows.Forms.Label()
    Me.TpExemptions = New System.Windows.Forms.TabPage()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.LblChgExam7 = New System.Windows.Forms.Label()
    Me.LblChgExam6 = New System.Windows.Forms.Label()
    Me.LblChgExam5 = New System.Windows.Forms.Label()
    Me.LblChgExam4 = New System.Windows.Forms.Label()
    Me.LblChgExam3 = New System.Windows.Forms.Label()
    Me.LblChgExam2 = New System.Windows.Forms.Label()
    Me.LblChgExam1 = New System.Windows.Forms.Label()
    Me.Label70 = New System.Windows.Forms.Label()
    Me.LblOrigExam7 = New System.Windows.Forms.Label()
    Me.LblOrigExam6 = New System.Windows.Forms.Label()
    Me.LblOrigExam5 = New System.Windows.Forms.Label()
    Me.LblOrigExam4 = New System.Windows.Forms.Label()
    Me.LblOrigExam3 = New System.Windows.Forms.Label()
    Me.LblOrigExam2 = New System.Windows.Forms.Label()
    Me.Label58 = New System.Windows.Forms.Label()
    Me.LblOrigExam1 = New System.Windows.Forms.Label()
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
    Me.TxtExam5 = New System.Windows.Forms.TextBox()
    Me.TxtExam3 = New System.Windows.Forms.TextBox()
    Me.TxtExam1 = New System.Windows.Forms.TextBox()
    Me.Label50 = New System.Windows.Forms.Label()
    Me.Label52 = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.Label42 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.LblChgNet = New System.Windows.Forms.Label()
    Me.LblNewNet = New System.Windows.Forms.Label()
    Me.LblOrigNet = New System.Windows.Forms.Label()
    Me.LblChgExam = New System.Windows.Forms.Label()
    Me.LblNewExam = New System.Windows.Forms.Label()
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
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.LblType = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.LblCCDate = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.LblCCNo = New System.Windows.Forms.Label()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.LblChgCred = New System.Windows.Forms.Label()
    Me.LblNewCred = New System.Windows.Forms.Label()
    Me.LblOrigCred = New System.Windows.Forms.Label()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.Label27 = New System.Windows.Forms.Label()
    Me.LblOrigName = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TpMain.SuspendLayout()
        Me.GrpFreeze.SuspendLayout()
        Me.GrpHeart.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TpAssmnt.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TpExemptions.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabControl1.Controls.Add(Me.TpMain)
        Me.TabControl1.Controls.Add(Me.TpAssmnt)
        Me.TabControl1.Controls.Add(Me.TpExemptions)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(4, 167)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(720, 240)
        Me.TabControl1.TabIndex = 9
        '
        'TpMain
        '
        Me.TpMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TpMain.Controls.Add(Me.GrpFreeze)
        Me.TpMain.Controls.Add(Me.GrpHeart)
        Me.TpMain.Controls.Add(Me.DtPckPurDate)
        Me.TpMain.Controls.Add(Me.Label36)
        Me.TpMain.Controls.Add(Me.LblBackTxCd)
        Me.TpMain.Controls.Add(Me.Label26)
        Me.TpMain.Controls.Add(Me.TxtSMap)
        Me.TpMain.Controls.Add(Me.Label15)
        Me.TpMain.Controls.Add(Me.GroupBox3)
        Me.TpMain.Controls.Add(Me.TxtUnit)
        Me.TpMain.Controls.Add(Me.Label11)
        Me.TpMain.Controls.Add(Me.LnkReason)
        Me.TpMain.Controls.Add(Me.LblBankCd)
        Me.TpMain.Controls.Add(Me.Label25)
        Me.TpMain.Controls.Add(Me.Label14)
        Me.TpMain.Controls.Add(Me.TxtDesc)
        Me.TpMain.Controls.Add(Me.TxtReason)
        Me.TpMain.Controls.Add(Me.TxtVol)
        Me.TpMain.Controls.Add(Me.TxtPage)
        Me.TpMain.Controls.Add(Me.Label33)
        Me.TpMain.Controls.Add(Me.TxtMap)
        Me.TpMain.Controls.Add(Me.Label7)
        Me.TpMain.Controls.Add(Me.TxtLoc)
        Me.TpMain.Controls.Add(Me.TxtLocNo)
        Me.TpMain.Controls.Add(Me.Label6)
        Me.TpMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TpMain.Location = New System.Drawing.Point(4, 25)
        Me.TpMain.Name = "TpMain"
        Me.TpMain.Size = New System.Drawing.Size(712, 211)
        Me.TpMain.TabIndex = 0
        Me.TpMain.Text = "Main"
        '
        'GrpFreeze
        '
        Me.GrpFreeze.Controls.Add(Me.LblFreezeYear)
        Me.GrpFreeze.Controls.Add(Me.Label35)
        Me.GrpFreeze.Controls.Add(Me.LblFreezeAmt)
        Me.GrpFreeze.Controls.Add(Me.Label44)
        Me.GrpFreeze.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpFreeze.Location = New System.Drawing.Point(478, 139)
        Me.GrpFreeze.Name = "GrpFreeze"
        Me.GrpFreeze.Size = New System.Drawing.Size(136, 56)
        Me.GrpFreeze.TabIndex = 13
        Me.GrpFreeze.TabStop = False
        Me.GrpFreeze.Text = "Freeze"
        '
        'LblFreezeYear
        '
        Me.LblFreezeYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFreezeYear.Location = New System.Drawing.Point(56, 32)
        Me.LblFreezeYear.Name = "LblFreezeYear"
        Me.LblFreezeYear.Size = New System.Drawing.Size(48, 16)
        Me.LblFreezeYear.TabIndex = 191
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(8, 32)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(32, 16)
        Me.Label35.TabIndex = 190
        Me.Label35.Text = "Year"
        '
        'LblFreezeAmt
        '
        Me.LblFreezeAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFreezeAmt.Location = New System.Drawing.Point(56, 16)
        Me.LblFreezeAmt.Name = "LblFreezeAmt"
        Me.LblFreezeAmt.Size = New System.Drawing.Size(48, 16)
        Me.LblFreezeAmt.TabIndex = 184
        '
        'Label44
        '
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(8, 16)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(48, 16)
        Me.Label44.TabIndex = 183
        Me.Label44.Text = "Amount"
        '
        'GrpHeart
        '
        Me.GrpHeart.Controls.Add(Me.Label31)
        Me.GrpHeart.Controls.Add(Me.Label24)
        Me.GrpHeart.Controls.Add(Me.LblHeartMax)
        Me.GrpHeart.Controls.Add(Me.LblHeartMin)
        Me.GrpHeart.Controls.Add(Me.LblHeartPct)
        Me.GrpHeart.Controls.Add(Me.Label29)
        Me.GrpHeart.Controls.Add(Me.LblHeartAmt)
        Me.GrpHeart.Controls.Add(Me.Label40)
        Me.GrpHeart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpHeart.Location = New System.Drawing.Point(326, 131)
        Me.GrpHeart.Name = "GrpHeart"
        Me.GrpHeart.Size = New System.Drawing.Size(136, 72)
        Me.GrpHeart.TabIndex = 12
        Me.GrpHeart.TabStop = False
        Me.GrpHeart.Text = "Heart"
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(8, 32)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(48, 16)
        Me.Label31.TabIndex = 190
        Me.Label31.Text = "Min/Max"
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(80, 32)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(8, 16)
        Me.Label24.TabIndex = 189
        Me.Label24.Text = "/"
        '
        'LblHeartMax
        '
        Me.LblHeartMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHeartMax.Location = New System.Drawing.Point(96, 32)
        Me.LblHeartMax.Name = "LblHeartMax"
        Me.LblHeartMax.Size = New System.Drawing.Size(32, 16)
        Me.LblHeartMax.TabIndex = 188
        '
        'LblHeartMin
        '
        Me.LblHeartMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHeartMin.Location = New System.Drawing.Point(56, 32)
        Me.LblHeartMin.Name = "LblHeartMin"
        Me.LblHeartMin.Size = New System.Drawing.Size(24, 16)
        Me.LblHeartMin.TabIndex = 187
        '
        'LblHeartPct
        '
        Me.LblHeartPct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHeartPct.Location = New System.Drawing.Point(80, 48)
        Me.LblHeartPct.Name = "LblHeartPct"
        Me.LblHeartPct.Size = New System.Drawing.Size(40, 16)
        Me.LblHeartPct.TabIndex = 186
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(8, 48)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(72, 16)
        Me.Label29.TabIndex = 185
        Me.Label29.Text = "Heart Pct%"
        '
        'LblHeartAmt
        '
        Me.LblHeartAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHeartAmt.Location = New System.Drawing.Point(56, 16)
        Me.LblHeartAmt.Name = "LblHeartAmt"
        Me.LblHeartAmt.Size = New System.Drawing.Size(48, 16)
        Me.LblHeartAmt.TabIndex = 184
        '
        'Label40
        '
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(8, 16)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(48, 16)
        Me.Label40.TabIndex = 183
        Me.Label40.Text = "Amount"
        '
        'DtPckPurDate
        '
        Me.DtPckPurDate.Checked = False
        Me.DtPckPurDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckPurDate.Location = New System.Drawing.Point(96, 128)
        Me.DtPckPurDate.Name = "DtPckPurDate"
        Me.DtPckPurDate.ShowCheckBox = True
        Me.DtPckPurDate.Size = New System.Drawing.Size(96, 20)
        Me.DtPckPurDate.TabIndex = 19
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(3, 131)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(80, 16)
        Me.Label36.TabIndex = 181
        Me.Label36.Text = "Purchase Date"
        '
        'LblBackTxCd
        '
        Me.LblBackTxCd.Location = New System.Drawing.Point(408, 88)
        Me.LblBackTxCd.Name = "LblBackTxCd"
        Me.LblBackTxCd.Size = New System.Drawing.Size(24, 16)
        Me.LblBackTxCd.TabIndex = 9
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(320, 88)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(88, 16)
        Me.Label26.TabIndex = 178
        Me.Label26.Text = "Back Tax Code"
        '
        'TxtSMap
        '
        Me.TxtSMap.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSMap.Location = New System.Drawing.Point(392, 32)
        Me.TxtSMap.MaxLength = 8
        Me.TxtSMap.Name = "TxtSMap"
        Me.TxtSMap.Size = New System.Drawing.Size(56, 20)
        Me.TxtSMap.TabIndex = 13
        Me.TxtSMap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(352, 32)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 16)
        Me.Label15.TabIndex = 177
        Me.Label15.Text = "S.Map"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.LnkExemptCd)
        Me.GroupBox3.Controls.Add(Me.TxtExemptCd)
        Me.GroupBox3.Controls.Add(Me.RbCatExempt)
        Me.GroupBox3.Controls.Add(Me.RbCatTaxable)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox3.Location = New System.Drawing.Point(544, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(160, 64)
        Me.GroupBox3.TabIndex = 175
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
        Me.TxtExemptCd.Location = New System.Drawing.Point(88, 40)
        Me.TxtExemptCd.MaxLength = 4
        Me.TxtExemptCd.Name = "TxtExemptCd"
        Me.TxtExemptCd.Size = New System.Drawing.Size(40, 20)
        Me.TxtExemptCd.TabIndex = 16
        Me.TxtExemptCd.TabStop = False
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
        'TxtUnit
        '
        Me.TxtUnit.Location = New System.Drawing.Point(392, 8)
        Me.TxtUnit.MaxLength = 7
        Me.TxtUnit.Name = "TxtUnit"
        Me.TxtUnit.Size = New System.Drawing.Size(48, 20)
        Me.TxtUnit.TabIndex = 11
        Me.TxtUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(360, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 16)
        Me.Label11.TabIndex = 174
        Me.Label11.Text = "Unit"
        '
        'LnkReason
        '
        Me.LnkReason.Location = New System.Drawing.Point(3, 83)
        Me.LnkReason.Name = "LnkReason"
        Me.LnkReason.Size = New System.Drawing.Size(88, 16)
        Me.LnkReason.TabIndex = 17
        Me.LnkReason.TabStop = True
        Me.LnkReason.Text = "Change Reason"
        '
        'LblBankCd
        '
        Me.LblBankCd.Location = New System.Drawing.Point(408, 64)
        Me.LblBankCd.Name = "LblBankCd"
        Me.LblBankCd.Size = New System.Drawing.Size(24, 16)
        Me.LblBankCd.TabIndex = 7
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(344, 64)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(64, 16)
        Me.Label25.TabIndex = 160
        Me.Label25.Text = "Bank Code"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(3, 107)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 16)
        Me.Label14.TabIndex = 156
        Me.Label14.Text = "Description"
        '
        'TxtDesc
        '
        Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDesc.Location = New System.Drawing.Point(96, 104)
        Me.TxtDesc.MaxLength = 50
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.Size = New System.Drawing.Size(310, 20)
        Me.TxtDesc.TabIndex = 18
        '
        'TxtReason
        '
        Me.TxtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtReason.Location = New System.Drawing.Point(96, 81)
        Me.TxtReason.MaxLength = 1
        Me.TxtReason.Name = "TxtReason"
        Me.TxtReason.Size = New System.Drawing.Size(18, 20)
        Me.TxtReason.TabIndex = 17
        Me.TxtReason.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtVol
        '
        Me.TxtVol.Location = New System.Drawing.Point(96, 56)
        Me.TxtVol.MaxLength = 5
        Me.TxtVol.Name = "TxtVol"
        Me.TxtVol.Size = New System.Drawing.Size(40, 20)
        Me.TxtVol.TabIndex = 14
        Me.TxtVol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPage
        '
        Me.TxtPage.Location = New System.Drawing.Point(136, 56)
        Me.TxtPage.MaxLength = 5
        Me.TxtPage.Name = "TxtPage"
        Me.TxtPage.Size = New System.Drawing.Size(40, 20)
        Me.TxtPage.TabIndex = 15
        Me.TxtPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(3, 59)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(56, 16)
        Me.Label33.TabIndex = 152
        Me.Label33.Text = "Vol/Page"
        '
        'TxtMap
        '
        Me.TxtMap.Location = New System.Drawing.Point(96, 32)
        Me.TxtMap.MaxLength = 17
        Me.TxtMap.Name = "TxtMap"
        Me.TxtMap.Size = New System.Drawing.Size(144, 20)
        Me.TxtMap.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(3, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 137
        Me.Label7.Text = "Map Block Lot"
        '
        'TxtLoc
        '
        Me.TxtLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLoc.Location = New System.Drawing.Point(152, 8)
        Me.TxtLoc.MaxLength = 25
        Me.TxtLoc.Name = "TxtLoc"
        Me.TxtLoc.Size = New System.Drawing.Size(184, 20)
        Me.TxtLoc.TabIndex = 10
        '
        'TxtLocNo
        '
        Me.TxtLocNo.Location = New System.Drawing.Point(96, 8)
        Me.TxtLocNo.MaxLength = 7
        Me.TxtLocNo.Name = "TxtLocNo"
        Me.TxtLocNo.Size = New System.Drawing.Size(48, 20)
        Me.TxtLocNo.TabIndex = 9
        Me.TxtLocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(3, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 125
        Me.Label6.Text = "Location#/Name"
        '
        'TpAssmnt
        '
        Me.TpAssmnt.Controls.Add(Me.Label28)
        Me.TpAssmnt.Controls.Add(Me.GroupBox1)
        Me.TpAssmnt.Location = New System.Drawing.Point(4, 25)
        Me.TpAssmnt.Name = "TpAssmnt"
        Me.TpAssmnt.Size = New System.Drawing.Size(712, 211)
        Me.TpAssmnt.TabIndex = 2
        Me.TpAssmnt.Text = "Assessments"
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(357, 94)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(196, 41)
        Me.Label28.TabIndex = 220
        Me.Label28.Text = "Changing codes will effect Grand List.  Workaround is to add new codes instead. D" &
    "o NOT reorder codes. "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblChgAssmt7)
        Me.GroupBox1.Controls.Add(Me.LblChgAssmt6)
        Me.GroupBox1.Controls.Add(Me.LblChgAssmt5)
        Me.GroupBox1.Controls.Add(Me.LblChgAssmt4)
        Me.GroupBox1.Controls.Add(Me.LblChgAssmt3)
        Me.GroupBox1.Controls.Add(Me.LblChgAssmt2)
        Me.GroupBox1.Controls.Add(Me.LblOrigAssmt7)
        Me.GroupBox1.Controls.Add(Me.LblOrigAssmt6)
        Me.GroupBox1.Controls.Add(Me.LblOrigAssmt5)
        Me.GroupBox1.Controls.Add(Me.LblOrigAssmt4)
        Me.GroupBox1.Controls.Add(Me.LblOrigAssmt3)
        Me.GroupBox1.Controls.Add(Me.LblOrigAssmt2)
        Me.GroupBox1.Controls.Add(Me.LblChgAssmt1)
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
        Me.GroupBox1.Controls.Add(Me.TxtAssmt7)
        Me.GroupBox1.Controls.Add(Me.TxtUnit7)
        Me.GroupBox1.Controls.Add(Me.TxtAssmt6)
        Me.GroupBox1.Controls.Add(Me.TxtUnit6)
        Me.GroupBox1.Controls.Add(Me.TxtAssmt4)
        Me.GroupBox1.Controls.Add(Me.TxtUnit4)
        Me.GroupBox1.Controls.Add(Me.TxtAssmt5)
        Me.GroupBox1.Controls.Add(Me.TxtUnit5)
        Me.GroupBox1.Controls.Add(Me.TxtAssmt3)
        Me.GroupBox1.Controls.Add(Me.TxtUnit3)
        Me.GroupBox1.Controls.Add(Me.TxtAssmt2)
        Me.GroupBox1.Controls.Add(Me.TxtUnit2)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.TxtAssmt1)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.TxtUnit1)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.LblOrigAssmt1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(336, 200)
        Me.GroupBox1.TabIndex = 126
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Assessment Property Codes"
        '
        'LblChgAssmt7
        '
        Me.LblChgAssmt7.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgAssmt7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgAssmt7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgAssmt7.ForeColor = System.Drawing.Color.Black
        Me.LblChgAssmt7.Location = New System.Drawing.Point(264, 180)
        Me.LblChgAssmt7.Name = "LblChgAssmt7"
        Me.LblChgAssmt7.Size = New System.Drawing.Size(64, 16)
        Me.LblChgAssmt7.TabIndex = 195
        Me.LblChgAssmt7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblChgAssmt6
        '
        Me.LblChgAssmt6.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgAssmt6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgAssmt6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgAssmt6.ForeColor = System.Drawing.Color.Black
        Me.LblChgAssmt6.Location = New System.Drawing.Point(264, 156)
        Me.LblChgAssmt6.Name = "LblChgAssmt6"
        Me.LblChgAssmt6.Size = New System.Drawing.Size(64, 16)
        Me.LblChgAssmt6.TabIndex = 194
        Me.LblChgAssmt6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblChgAssmt5
        '
        Me.LblChgAssmt5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgAssmt5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgAssmt5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgAssmt5.ForeColor = System.Drawing.Color.Black
        Me.LblChgAssmt5.Location = New System.Drawing.Point(264, 132)
        Me.LblChgAssmt5.Name = "LblChgAssmt5"
        Me.LblChgAssmt5.Size = New System.Drawing.Size(64, 16)
        Me.LblChgAssmt5.TabIndex = 193
        Me.LblChgAssmt5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblChgAssmt4
        '
        Me.LblChgAssmt4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgAssmt4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgAssmt4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgAssmt4.ForeColor = System.Drawing.Color.Black
        Me.LblChgAssmt4.Location = New System.Drawing.Point(264, 108)
        Me.LblChgAssmt4.Name = "LblChgAssmt4"
        Me.LblChgAssmt4.Size = New System.Drawing.Size(64, 16)
        Me.LblChgAssmt4.TabIndex = 192
        Me.LblChgAssmt4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblChgAssmt3
        '
        Me.LblChgAssmt3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgAssmt3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgAssmt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgAssmt3.ForeColor = System.Drawing.Color.Black
        Me.LblChgAssmt3.Location = New System.Drawing.Point(264, 84)
        Me.LblChgAssmt3.Name = "LblChgAssmt3"
        Me.LblChgAssmt3.Size = New System.Drawing.Size(64, 16)
        Me.LblChgAssmt3.TabIndex = 191
        Me.LblChgAssmt3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblChgAssmt2
        '
        Me.LblChgAssmt2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgAssmt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgAssmt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgAssmt2.ForeColor = System.Drawing.Color.Black
        Me.LblChgAssmt2.Location = New System.Drawing.Point(264, 60)
        Me.LblChgAssmt2.Name = "LblChgAssmt2"
        Me.LblChgAssmt2.Size = New System.Drawing.Size(64, 16)
        Me.LblChgAssmt2.TabIndex = 190
        Me.LblChgAssmt2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblOrigAssmt7
        '
        Me.LblOrigAssmt7.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOrigAssmt7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOrigAssmt7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigAssmt7.ForeColor = System.Drawing.Color.Black
        Me.LblOrigAssmt7.Location = New System.Drawing.Point(112, 180)
        Me.LblOrigAssmt7.Name = "LblOrigAssmt7"
        Me.LblOrigAssmt7.Size = New System.Drawing.Size(64, 16)
        Me.LblOrigAssmt7.TabIndex = 189
        Me.LblOrigAssmt7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblOrigAssmt6
        '
        Me.LblOrigAssmt6.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOrigAssmt6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOrigAssmt6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigAssmt6.ForeColor = System.Drawing.Color.Black
        Me.LblOrigAssmt6.Location = New System.Drawing.Point(112, 156)
        Me.LblOrigAssmt6.Name = "LblOrigAssmt6"
        Me.LblOrigAssmt6.Size = New System.Drawing.Size(64, 16)
        Me.LblOrigAssmt6.TabIndex = 188
        Me.LblOrigAssmt6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblOrigAssmt5
        '
        Me.LblOrigAssmt5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOrigAssmt5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOrigAssmt5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigAssmt5.ForeColor = System.Drawing.Color.Black
        Me.LblOrigAssmt5.Location = New System.Drawing.Point(112, 132)
        Me.LblOrigAssmt5.Name = "LblOrigAssmt5"
        Me.LblOrigAssmt5.Size = New System.Drawing.Size(64, 16)
        Me.LblOrigAssmt5.TabIndex = 187
        Me.LblOrigAssmt5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblOrigAssmt4
        '
        Me.LblOrigAssmt4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOrigAssmt4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOrigAssmt4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigAssmt4.ForeColor = System.Drawing.Color.Black
        Me.LblOrigAssmt4.Location = New System.Drawing.Point(112, 108)
        Me.LblOrigAssmt4.Name = "LblOrigAssmt4"
        Me.LblOrigAssmt4.Size = New System.Drawing.Size(64, 16)
        Me.LblOrigAssmt4.TabIndex = 186
        Me.LblOrigAssmt4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblOrigAssmt3
        '
        Me.LblOrigAssmt3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOrigAssmt3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOrigAssmt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigAssmt3.ForeColor = System.Drawing.Color.Black
        Me.LblOrigAssmt3.Location = New System.Drawing.Point(112, 84)
        Me.LblOrigAssmt3.Name = "LblOrigAssmt3"
        Me.LblOrigAssmt3.Size = New System.Drawing.Size(64, 16)
        Me.LblOrigAssmt3.TabIndex = 185
        Me.LblOrigAssmt3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblOrigAssmt2
        '
        Me.LblOrigAssmt2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOrigAssmt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOrigAssmt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigAssmt2.ForeColor = System.Drawing.Color.Black
        Me.LblOrigAssmt2.Location = New System.Drawing.Point(112, 60)
        Me.LblOrigAssmt2.Name = "LblOrigAssmt2"
        Me.LblOrigAssmt2.Size = New System.Drawing.Size(64, 16)
        Me.LblOrigAssmt2.TabIndex = 184
        Me.LblOrigAssmt2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblChgAssmt1
        '
        Me.LblChgAssmt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgAssmt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgAssmt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgAssmt1.ForeColor = System.Drawing.Color.Black
        Me.LblChgAssmt1.Location = New System.Drawing.Point(264, 36)
        Me.LblChgAssmt1.Name = "LblChgAssmt1"
        Me.LblChgAssmt1.Size = New System.Drawing.Size(64, 16)
        Me.LblChgAssmt1.TabIndex = 183
        Me.LblChgAssmt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LnkCode6
        '
        Me.LnkCode6.AutoSize = True
        Me.LnkCode6.Location = New System.Drawing.Point(13, 155)
        Me.LnkCode6.Name = "LnkCode6"
        Me.LnkCode6.Size = New System.Drawing.Size(13, 13)
        Me.LnkCode6.TabIndex = 176
        Me.LnkCode6.TabStop = True
        Me.LnkCode6.Text = "6"
        '
        'TxtCode6
        '
        Me.TxtCode6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCode6.Location = New System.Drawing.Point(32, 152)
        Me.TxtCode6.MaxLength = 3
        Me.TxtCode6.Name = "TxtCode6"
        Me.TxtCode6.Size = New System.Drawing.Size(24, 20)
        Me.TxtCode6.TabIndex = 25
        '
        'LnkCode4
        '
        Me.LnkCode4.AutoSize = True
        Me.LnkCode4.Location = New System.Drawing.Point(13, 107)
        Me.LnkCode4.Name = "LnkCode4"
        Me.LnkCode4.Size = New System.Drawing.Size(13, 13)
        Me.LnkCode4.TabIndex = 174
        Me.LnkCode4.TabStop = True
        Me.LnkCode4.Text = "4"
        '
        'TxtCode4
        '
        Me.TxtCode4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCode4.Location = New System.Drawing.Point(32, 104)
        Me.TxtCode4.MaxLength = 3
        Me.TxtCode4.Name = "TxtCode4"
        Me.TxtCode4.Size = New System.Drawing.Size(24, 20)
        Me.TxtCode4.TabIndex = 15
        '
        'LnkCode2
        '
        Me.LnkCode2.AutoSize = True
        Me.LnkCode2.Location = New System.Drawing.Point(13, 59)
        Me.LnkCode2.Name = "LnkCode2"
        Me.LnkCode2.Size = New System.Drawing.Size(13, 13)
        Me.LnkCode2.TabIndex = 172
        Me.LnkCode2.TabStop = True
        Me.LnkCode2.Text = "2"
        '
        'TxtCode2
        '
        Me.TxtCode2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCode2.Location = New System.Drawing.Point(32, 56)
        Me.TxtCode2.MaxLength = 3
        Me.TxtCode2.Name = "TxtCode2"
        Me.TxtCode2.Size = New System.Drawing.Size(24, 20)
        Me.TxtCode2.TabIndex = 5
        '
        'LnkCode7
        '
        Me.LnkCode7.AutoSize = True
        Me.LnkCode7.Location = New System.Drawing.Point(13, 179)
        Me.LnkCode7.Name = "LnkCode7"
        Me.LnkCode7.Size = New System.Drawing.Size(13, 13)
        Me.LnkCode7.TabIndex = 177
        Me.LnkCode7.TabStop = True
        Me.LnkCode7.Text = "7"
        '
        'TxtCode7
        '
        Me.TxtCode7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCode7.Location = New System.Drawing.Point(32, 176)
        Me.TxtCode7.MaxLength = 3
        Me.TxtCode7.Name = "TxtCode7"
        Me.TxtCode7.Size = New System.Drawing.Size(24, 20)
        Me.TxtCode7.TabIndex = 30
        '
        'LnkCode5
        '
        Me.LnkCode5.AutoSize = True
        Me.LnkCode5.Location = New System.Drawing.Point(13, 131)
        Me.LnkCode5.Name = "LnkCode5"
        Me.LnkCode5.Size = New System.Drawing.Size(13, 13)
        Me.LnkCode5.TabIndex = 175
        Me.LnkCode5.TabStop = True
        Me.LnkCode5.Text = "5"
        '
        'TxtCode5
        '
        Me.TxtCode5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCode5.Location = New System.Drawing.Point(32, 128)
        Me.TxtCode5.MaxLength = 3
        Me.TxtCode5.Name = "TxtCode5"
        Me.TxtCode5.Size = New System.Drawing.Size(24, 20)
        Me.TxtCode5.TabIndex = 20
        '
        'LnkCode3
        '
        Me.LnkCode3.AutoSize = True
        Me.LnkCode3.Location = New System.Drawing.Point(13, 83)
        Me.LnkCode3.Name = "LnkCode3"
        Me.LnkCode3.Size = New System.Drawing.Size(13, 13)
        Me.LnkCode3.TabIndex = 173
        Me.LnkCode3.TabStop = True
        Me.LnkCode3.Text = "3"
        '
        'TxtCode3
        '
        Me.TxtCode3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCode3.Location = New System.Drawing.Point(32, 80)
        Me.TxtCode3.MaxLength = 3
        Me.TxtCode3.Name = "TxtCode3"
        Me.TxtCode3.Size = New System.Drawing.Size(24, 20)
        Me.TxtCode3.TabIndex = 10
        '
        'LnkCode1
        '
        Me.LnkCode1.AutoSize = True
        Me.LnkCode1.Location = New System.Drawing.Point(13, 35)
        Me.LnkCode1.Name = "LnkCode1"
        Me.LnkCode1.Size = New System.Drawing.Size(13, 13)
        Me.LnkCode1.TabIndex = 171
        Me.LnkCode1.TabStop = True
        Me.LnkCode1.Text = "1"
        '
        'TxtCode1
        '
        Me.TxtCode1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCode1.Location = New System.Drawing.Point(32, 32)
        Me.TxtCode1.MaxLength = 3
        Me.TxtCode1.Name = "TxtCode1"
        Me.TxtCode1.Size = New System.Drawing.Size(24, 20)
        Me.TxtCode1.TabIndex = 0
        '
        'TxtAssmt7
        '
        Me.TxtAssmt7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAssmt7.Location = New System.Drawing.Point(184, 176)
        Me.TxtAssmt7.MaxLength = 9
        Me.TxtAssmt7.Name = "TxtAssmt7"
        Me.TxtAssmt7.Size = New System.Drawing.Size(72, 20)
        Me.TxtAssmt7.TabIndex = 35
        Me.TxtAssmt7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtUnit7
        '
        Me.TxtUnit7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUnit7.Location = New System.Drawing.Point(72, 176)
        Me.TxtUnit7.MaxLength = 3
        Me.TxtUnit7.Name = "TxtUnit7"
        Me.TxtUnit7.Size = New System.Drawing.Size(32, 20)
        Me.TxtUnit7.TabIndex = 33
        Me.TxtUnit7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtAssmt6
        '
        Me.TxtAssmt6.Location = New System.Drawing.Point(184, 152)
        Me.TxtAssmt6.MaxLength = 9
        Me.TxtAssmt6.Name = "TxtAssmt6"
        Me.TxtAssmt6.Size = New System.Drawing.Size(72, 20)
        Me.TxtAssmt6.TabIndex = 30
        Me.TxtAssmt6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtUnit6
        '
        Me.TxtUnit6.Location = New System.Drawing.Point(72, 152)
        Me.TxtUnit6.MaxLength = 6
        Me.TxtUnit6.Name = "TxtUnit6"
        Me.TxtUnit6.Size = New System.Drawing.Size(32, 20)
        Me.TxtUnit6.TabIndex = 28
        Me.TxtUnit6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtAssmt4
        '
        Me.TxtAssmt4.Location = New System.Drawing.Point(184, 104)
        Me.TxtAssmt4.MaxLength = 9
        Me.TxtAssmt4.Name = "TxtAssmt4"
        Me.TxtAssmt4.Size = New System.Drawing.Size(72, 20)
        Me.TxtAssmt4.TabIndex = 19
        Me.TxtAssmt4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtUnit4
        '
        Me.TxtUnit4.Location = New System.Drawing.Point(72, 104)
        Me.TxtUnit4.MaxLength = 6
        Me.TxtUnit4.Name = "TxtUnit4"
        Me.TxtUnit4.Size = New System.Drawing.Size(32, 20)
        Me.TxtUnit4.TabIndex = 17
        Me.TxtUnit4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtAssmt5
        '
        Me.TxtAssmt5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAssmt5.Location = New System.Drawing.Point(184, 128)
        Me.TxtAssmt5.MaxLength = 9
        Me.TxtAssmt5.Name = "TxtAssmt5"
        Me.TxtAssmt5.Size = New System.Drawing.Size(72, 20)
        Me.TxtAssmt5.TabIndex = 24
        Me.TxtAssmt5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtUnit5
        '
        Me.TxtUnit5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUnit5.Location = New System.Drawing.Point(72, 128)
        Me.TxtUnit5.MaxLength = 3
        Me.TxtUnit5.Name = "TxtUnit5"
        Me.TxtUnit5.Size = New System.Drawing.Size(32, 20)
        Me.TxtUnit5.TabIndex = 22
        Me.TxtUnit5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtAssmt3
        '
        Me.TxtAssmt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAssmt3.Location = New System.Drawing.Point(184, 80)
        Me.TxtAssmt3.MaxLength = 9
        Me.TxtAssmt3.Name = "TxtAssmt3"
        Me.TxtAssmt3.Size = New System.Drawing.Size(72, 20)
        Me.TxtAssmt3.TabIndex = 13
        Me.TxtAssmt3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtUnit3
        '
        Me.TxtUnit3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUnit3.Location = New System.Drawing.Point(72, 80)
        Me.TxtUnit3.MaxLength = 3
        Me.TxtUnit3.Name = "TxtUnit3"
        Me.TxtUnit3.Size = New System.Drawing.Size(32, 20)
        Me.TxtUnit3.TabIndex = 11
        Me.TxtUnit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtAssmt2
        '
        Me.TxtAssmt2.Location = New System.Drawing.Point(184, 56)
        Me.TxtAssmt2.MaxLength = 9
        Me.TxtAssmt2.Name = "TxtAssmt2"
        Me.TxtAssmt2.Size = New System.Drawing.Size(72, 20)
        Me.TxtAssmt2.TabIndex = 8
        Me.TxtAssmt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtUnit2
        '
        Me.TxtUnit2.Location = New System.Drawing.Point(72, 56)
        Me.TxtUnit2.MaxLength = 6
        Me.TxtUnit2.Name = "TxtUnit2"
        Me.TxtUnit2.Size = New System.Drawing.Size(32, 20)
        Me.TxtUnit2.TabIndex = 6
        Me.TxtUnit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(262, 16)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(66, 16)
        Me.Label23.TabIndex = 37
        Me.Label23.Text = "Change"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(112, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(64, 16)
        Me.Label18.TabIndex = 36
        Me.Label18.Text = "Original"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TxtAssmt1
        '
        Me.TxtAssmt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAssmt1.Location = New System.Drawing.Point(184, 32)
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
        Me.Label17.Location = New System.Drawing.Point(184, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 16)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "New"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(72, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 16)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Unit"
        '
        'TxtUnit1
        '
        Me.TxtUnit1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUnit1.Location = New System.Drawing.Point(72, 32)
        Me.TxtUnit1.MaxLength = 3
        Me.TxtUnit1.Name = "TxtUnit1"
        Me.TxtUnit1.Size = New System.Drawing.Size(32, 20)
        Me.TxtUnit1.TabIndex = 1
        Me.TxtUnit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(26, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 16)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Code"
        '
        'LblOrigAssmt1
        '
        Me.LblOrigAssmt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOrigAssmt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOrigAssmt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigAssmt1.ForeColor = System.Drawing.Color.Black
        Me.LblOrigAssmt1.Location = New System.Drawing.Point(112, 36)
        Me.LblOrigAssmt1.Name = "LblOrigAssmt1"
        Me.LblOrigAssmt1.Size = New System.Drawing.Size(64, 16)
        Me.LblOrigAssmt1.TabIndex = 22
        Me.LblOrigAssmt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TpExemptions
        '
        Me.TpExemptions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TpExemptions.Controls.Add(Me.GroupBox4)
        Me.TpExemptions.Location = New System.Drawing.Point(4, 25)
        Me.TpExemptions.Name = "TpExemptions"
        Me.TpExemptions.Size = New System.Drawing.Size(712, 211)
        Me.TpExemptions.TabIndex = 1
        Me.TpExemptions.Text = "Exemptions"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.LblChgExam7)
        Me.GroupBox4.Controls.Add(Me.LblChgExam6)
        Me.GroupBox4.Controls.Add(Me.LblChgExam5)
        Me.GroupBox4.Controls.Add(Me.LblChgExam4)
        Me.GroupBox4.Controls.Add(Me.LblChgExam3)
        Me.GroupBox4.Controls.Add(Me.LblChgExam2)
        Me.GroupBox4.Controls.Add(Me.LblChgExam1)
        Me.GroupBox4.Controls.Add(Me.Label70)
        Me.GroupBox4.Controls.Add(Me.LblOrigExam7)
        Me.GroupBox4.Controls.Add(Me.LblOrigExam6)
        Me.GroupBox4.Controls.Add(Me.LblOrigExam5)
        Me.GroupBox4.Controls.Add(Me.LblOrigExam4)
        Me.GroupBox4.Controls.Add(Me.LblOrigExam3)
        Me.GroupBox4.Controls.Add(Me.LblOrigExam2)
        Me.GroupBox4.Controls.Add(Me.Label58)
        Me.GroupBox4.Controls.Add(Me.LblOrigExam1)
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
        Me.GroupBox4.Controls.Add(Me.TxtExam5)
        Me.GroupBox4.Controls.Add(Me.TxtExam3)
        Me.GroupBox4.Controls.Add(Me.TxtExam1)
        Me.GroupBox4.Controls.Add(Me.Label50)
        Me.GroupBox4.Controls.Add(Me.Label52)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox4.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(672, 200)
        Me.GroupBox4.TabIndex = 124
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Exemptions"
        '
        'LblChgExam7
        '
        Me.LblChgExam7.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgExam7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgExam7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgExam7.ForeColor = System.Drawing.Color.Black
        Me.LblChgExam7.Location = New System.Drawing.Point(224, 176)
        Me.LblChgExam7.Name = "LblChgExam7"
        Me.LblChgExam7.Size = New System.Drawing.Size(64, 16)
        Me.LblChgExam7.TabIndex = 203
        Me.LblChgExam7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblChgExam6
        '
        Me.LblChgExam6.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgExam6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgExam6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgExam6.ForeColor = System.Drawing.Color.Black
        Me.LblChgExam6.Location = New System.Drawing.Point(224, 152)
        Me.LblChgExam6.Name = "LblChgExam6"
        Me.LblChgExam6.Size = New System.Drawing.Size(64, 16)
        Me.LblChgExam6.TabIndex = 202
        Me.LblChgExam6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.Label70.Location = New System.Drawing.Point(222, 16)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(66, 13)
        Me.Label70.TabIndex = 196
        Me.Label70.Text = "Change"
        Me.Label70.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblOrigExam7
        '
        Me.LblOrigExam7.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOrigExam7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOrigExam7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigExam7.ForeColor = System.Drawing.Color.Black
        Me.LblOrigExam7.Location = New System.Drawing.Point(72, 176)
        Me.LblOrigExam7.Name = "LblOrigExam7"
        Me.LblOrigExam7.Size = New System.Drawing.Size(64, 16)
        Me.LblOrigExam7.TabIndex = 195
        Me.LblOrigExam7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblOrigExam6
        '
        Me.LblOrigExam6.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOrigExam6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOrigExam6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigExam6.ForeColor = System.Drawing.Color.Black
        Me.LblOrigExam6.Location = New System.Drawing.Point(72, 152)
        Me.LblOrigExam6.Name = "LblOrigExam6"
        Me.LblOrigExam6.Size = New System.Drawing.Size(64, 16)
        Me.LblOrigExam6.TabIndex = 194
        Me.LblOrigExam6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.LblOrigExam1.Size = New System.Drawing.Size(64, 16)
        Me.LblOrigExam1.TabIndex = 183
        Me.LblOrigExam1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LnkExempt6
        '
        Me.LnkExempt6.AutoSize = True
        Me.LnkExempt6.Location = New System.Drawing.Point(13, 154)
        Me.LnkExempt6.Name = "LnkExempt6"
        Me.LnkExempt6.Size = New System.Drawing.Size(13, 13)
        Me.LnkExempt6.TabIndex = 179
        Me.LnkExempt6.TabStop = True
        Me.LnkExempt6.Text = "6"
        '
        'TxtExempt6
        '
        Me.TxtExempt6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtExempt6.Location = New System.Drawing.Point(32, 152)
        Me.TxtExempt6.MaxLength = 3
        Me.TxtExempt6.Name = "TxtExempt6"
        Me.TxtExempt6.Size = New System.Drawing.Size(32, 20)
        Me.TxtExempt6.TabIndex = 10
        '
        'LnkExempt7
        '
        Me.LnkExempt7.AutoSize = True
        Me.LnkExempt7.Location = New System.Drawing.Point(13, 178)
        Me.LnkExempt7.Name = "LnkExempt7"
        Me.LnkExempt7.Size = New System.Drawing.Size(13, 13)
        Me.LnkExempt7.TabIndex = 180
        Me.LnkExempt7.TabStop = True
        Me.LnkExempt7.Text = "7"
        '
        'TxtExempt7
        '
        Me.TxtExempt7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtExempt7.Location = New System.Drawing.Point(32, 176)
        Me.TxtExempt7.MaxLength = 3
        Me.TxtExempt7.Name = "TxtExempt7"
        Me.TxtExempt7.Size = New System.Drawing.Size(32, 20)
        Me.TxtExempt7.TabIndex = 12
        '
        'LnkExempt5
        '
        Me.LnkExempt5.AutoSize = True
        Me.LnkExempt5.Location = New System.Drawing.Point(13, 130)
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
        Me.LnkExempt3.Location = New System.Drawing.Point(13, 82)
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
        Me.LnkExempt4.Location = New System.Drawing.Point(13, 106)
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
        Me.LnkExempt2.Location = New System.Drawing.Point(13, 58)
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
        Me.LnkExempt1.Location = New System.Drawing.Point(13, 34)
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
        'TxtExam7
        '
        Me.TxtExam7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtExam7.Location = New System.Drawing.Point(144, 176)
        Me.TxtExam7.MaxLength = 7
        Me.TxtExam7.Name = "TxtExam7"
        Me.TxtExam7.Size = New System.Drawing.Size(72, 20)
        Me.TxtExam7.TabIndex = 69
        Me.TxtExam7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtExam6
        '
        Me.TxtExam6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtExam6.Location = New System.Drawing.Point(144, 152)
        Me.TxtExam6.MaxLength = 7
        Me.TxtExam6.Name = "TxtExam6"
        Me.TxtExam6.Size = New System.Drawing.Size(72, 20)
        Me.TxtExam6.TabIndex = 66
        Me.TxtExam6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.Label50.Location = New System.Drawing.Point(145, 16)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(71, 13)
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
        Me.Label52.Size = New System.Drawing.Size(47, 16)
        Me.Label52.TabIndex = 35
        Me.Label52.Text = "Code"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TxtDist
        '
        Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDist.Location = New System.Drawing.Point(440, 45)
        Me.TxtDist.MaxLength = 3
        Me.TxtDist.Name = "TxtDist"
        Me.TxtDist.Size = New System.Drawing.Size(24, 20)
        Me.TxtDist.TabIndex = 1
        Me.TxtDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label42
        '
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(392, 45)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(48, 16)
        Me.Label42.TabIndex = 132
        Me.Label42.Text = "District"
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LblChgNet)
        Me.GroupBox2.Controls.Add(Me.LblNewNet)
        Me.GroupBox2.Controls.Add(Me.LblOrigNet)
        Me.GroupBox2.Controls.Add(Me.LblChgExam)
        Me.GroupBox2.Controls.Add(Me.LblNewExam)
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
        Me.GroupBox2.Location = New System.Drawing.Point(14, 410)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(338, 88)
        Me.GroupBox2.TabIndex = 143
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Totals"
        '
        'LblChgNet
        '
        Me.LblChgNet.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgNet.Location = New System.Drawing.Point(240, 64)
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
        Me.LblNewNet.Location = New System.Drawing.Point(240, 48)
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
        Me.LblOrigNet.Location = New System.Drawing.Point(240, 32)
        Me.LblOrigNet.Name = "LblOrigNet"
        Me.LblOrigNet.Size = New System.Drawing.Size(80, 16)
        Me.LblOrigNet.TabIndex = 167
        Me.LblOrigNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblChgExam
        '
        Me.LblChgExam.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgExam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgExam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgExam.Location = New System.Drawing.Point(168, 64)
        Me.LblChgExam.Name = "LblChgExam"
        Me.LblChgExam.Size = New System.Drawing.Size(64, 16)
        Me.LblChgExam.TabIndex = 163
        Me.LblChgExam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblNewExam
        '
        Me.LblNewExam.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblNewExam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblNewExam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNewExam.Location = New System.Drawing.Point(168, 48)
        Me.LblNewExam.Name = "LblNewExam"
        Me.LblNewExam.Size = New System.Drawing.Size(64, 16)
        Me.LblNewExam.TabIndex = 162
        Me.LblNewExam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(162, 8)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 16)
        Me.Label20.TabIndex = 34
        Me.Label20.Text = "Exemptions"
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(82, 8)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 16)
        Me.Label19.TabIndex = 33
        Me.Label19.Text = "Gross"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblChgGross
        '
        Me.LblChgGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgGross.Location = New System.Drawing.Point(80, 64)
        Me.LblChgGross.Name = "LblChgGross"
        Me.LblChgGross.Size = New System.Drawing.Size(80, 16)
        Me.LblChgGross.TabIndex = 21
        Me.LblChgGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(8, 64)
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
        Me.LblNewGross.Location = New System.Drawing.Point(80, 48)
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
        Me.LblOrigGross.Location = New System.Drawing.Point(80, 32)
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
        Me.LblOrigExam.Location = New System.Drawing.Point(168, 32)
        Me.LblOrigExam.Name = "LblOrigExam"
        Me.LblOrigExam.Size = New System.Drawing.Size(64, 16)
        Me.LblOrigExam.TabIndex = 17
        Me.LblOrigExam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(8, 48)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(48, 16)
        Me.Label30.TabIndex = 16
        Me.Label30.Text = "New"
        '
        'LblOrig
        '
        Me.LblOrig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrig.Location = New System.Drawing.Point(8, 32)
        Me.LblOrig.Name = "LblOrig"
        Me.LblOrig.Size = New System.Drawing.Size(64, 16)
        Me.LblOrig.TabIndex = 15
        Me.LblOrig.Text = "Original"
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(240, 8)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(80, 16)
        Me.Label22.TabIndex = 160
        Me.Label22.Text = "Net"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TxtZip4
        '
        Me.TxtZip4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtZip4.Location = New System.Drawing.Point(416, 141)
        Me.TxtZip4.MaxLength = 4
        Me.TxtZip4.Name = "TxtZip4"
        Me.TxtZip4.Size = New System.Drawing.Size(32, 20)
        Me.TxtZip4.TabIndex = 8
        '
        'TxtCity
        '
        Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCity.Location = New System.Drawing.Point(96, 141)
        Me.TxtCity.MaxLength = 25
        Me.TxtCity.Name = "TxtCity"
        Me.TxtCity.Size = New System.Drawing.Size(232, 20)
        Me.TxtCity.TabIndex = 5
        '
        'TxtState
        '
        Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtState.Location = New System.Drawing.Point(336, 141)
        Me.TxtState.MaxLength = 2
        Me.TxtState.Name = "TxtState"
        Me.TxtState.Size = New System.Drawing.Size(24, 20)
        Me.TxtState.TabIndex = 6
        '
        'TxtAdd2
        '
        Me.TxtAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAdd2.Location = New System.Drawing.Point(96, 117)
        Me.TxtAdd2.MaxLength = 35
        Me.TxtAdd2.Name = "TxtAdd2"
        Me.TxtAdd2.Size = New System.Drawing.Size(280, 20)
        Me.TxtAdd2.TabIndex = 4
        '
        'TxtAdd1
        '
        Me.TxtAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAdd1.Location = New System.Drawing.Point(96, 93)
        Me.TxtAdd1.MaxLength = 35
        Me.TxtAdd1.Name = "TxtAdd1"
        Me.TxtAdd1.Size = New System.Drawing.Size(280, 20)
        Me.TxtAdd1.TabIndex = 3
        '
        'TxtSname
        '
        Me.TxtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSname.Location = New System.Drawing.Point(96, 69)
        Me.TxtSname.MaxLength = 35
        Me.TxtSname.Name = "TxtSname"
        Me.TxtSname.Size = New System.Drawing.Size(280, 20)
        Me.TxtSname.TabIndex = 2
        '
        'TxtZip5
        '
        Me.TxtZip5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtZip5.Location = New System.Drawing.Point(368, 141)
        Me.TxtZip5.MaxLength = 5
        Me.TxtZip5.Name = "TxtZip5"
        Me.TxtZip5.Size = New System.Drawing.Size(40, 20)
        Me.TxtZip5.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 142
        Me.Label4.Text = "City/State/Zip"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 141
        Me.Label3.Text = "Street Address"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "Second Name"
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Location = New System.Drawing.Point(96, 45)
        Me.TxtName.MaxLength = 35
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(280, 20)
        Me.TxtName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(256, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 139
        Me.Label1.Text = "List No"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 138
        Me.Label5.Text = "Name"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 145
        Me.Label8.Text = "C/C No"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(160, 4)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 146
        Me.Label9.Text = "Tax Year"
        '
        'LblYear
        '
        Me.LblYear.Location = New System.Drawing.Point(216, 4)
        Me.LblYear.Name = "LblYear"
        Me.LblYear.Size = New System.Drawing.Size(32, 16)
        Me.LblYear.TabIndex = 147
        '
        'LblType
        '
        Me.LblType.Location = New System.Drawing.Point(416, 4)
        Me.LblType.Name = "LblType"
        Me.LblType.Size = New System.Drawing.Size(24, 16)
        Me.LblType.TabIndex = 149
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(376, 4)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 16)
        Me.Label12.TabIndex = 148
        Me.Label12.Text = "Type"
        '
        'LblCCDate
        '
        Me.LblCCDate.Location = New System.Drawing.Point(520, 4)
        Me.LblCCDate.Name = "LblCCDate"
        Me.LblCCDate.Size = New System.Drawing.Size(64, 16)
        Me.LblCCDate.TabIndex = 151
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(456, 4)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 16)
        Me.Label13.TabIndex = 150
        Me.Label13.Text = "C/C Date"
        '
        'LblCCNo
        '
        Me.LblCCNo.Location = New System.Drawing.Point(96, 4)
        Me.LblCCNo.Name = "LblCCNo"
        Me.LblCCNo.Size = New System.Drawing.Size(48, 16)
        Me.LblCCNo.TabIndex = 152
        '
        'LblListNo
        '
        Me.LblListNo.Location = New System.Drawing.Point(304, 4)
        Me.LblListNo.Name = "LblListNo"
        Me.LblListNo.Size = New System.Drawing.Size(66, 16)
        Me.LblListNo.TabIndex = 153
        '
        'LblChgCred
        '
        Me.LblChgCred.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgCred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgCred.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgCred.Location = New System.Drawing.Point(358, 474)
        Me.LblChgCred.Name = "LblChgCred"
        Me.LblChgCred.Size = New System.Drawing.Size(64, 16)
        Me.LblChgCred.TabIndex = 170
        Me.LblChgCred.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblChgCred.Visible = False
        '
        'LblNewCred
        '
        Me.LblNewCred.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblNewCred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblNewCred.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNewCred.Location = New System.Drawing.Point(358, 458)
        Me.LblNewCred.Name = "LblNewCred"
        Me.LblNewCred.Size = New System.Drawing.Size(64, 16)
        Me.LblNewCred.TabIndex = 169
        Me.LblNewCred.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblNewCred.Visible = False
        '
        'LblOrigCred
        '
        Me.LblOrigCred.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOrigCred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOrigCred.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigCred.Location = New System.Drawing.Point(358, 442)
        Me.LblOrigCred.Name = "LblOrigCred"
        Me.LblOrigCred.Size = New System.Drawing.Size(64, 16)
        Me.LblOrigCred.TabIndex = 168
        Me.LblOrigCred.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblOrigCred.Visible = False
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(358, 418)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(64, 16)
        Me.Label21.TabIndex = 167
        Me.Label21.Text = "Ben/Cred"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label21.Visible = False
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(7, 24)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(79, 18)
        Me.Label27.TabIndex = 171
        Me.Label27.Text = "Original Name"
        '
        'LblOrigName
        '
        Me.LblOrigName.Location = New System.Drawing.Point(96, 24)
        Me.LblOrigName.Name = "LblOrigName"
        Me.LblOrigName.Size = New System.Drawing.Size(280, 16)
        Me.LblOrigName.TabIndex = 172
        '
        'FrmTA8102R
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(736, 506)
        Me.Controls.Add(Me.LblOrigName)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.LblChgCred)
        Me.Controls.Add(Me.LblNewCred)
        Me.Controls.Add(Me.LblOrigCred)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.LblListNo)
        Me.Controls.Add(Me.LblCCNo)
        Me.Controls.Add(Me.LblCCDate)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.LblType)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.LblYear)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtZip4)
        Me.Controls.Add(Me.TxtCity)
        Me.Controls.Add(Me.TxtState)
        Me.Controls.Add(Me.TxtAdd2)
        Me.Controls.Add(Me.TxtAdd1)
        Me.Controls.Add(Me.TxtSname)
        Me.Controls.Add(Me.TxtZip5)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.TxtDist)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTA8102R"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Certificate of Change - Real Estate "
        Me.TabControl1.ResumeLayout(False)
        Me.TpMain.ResumeLayout(False)
        Me.TpMain.PerformLayout()
        Me.GrpFreeze.ResumeLayout(False)
        Me.GrpHeart.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TpAssmnt.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TpExemptions.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmTA8102R_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkAttachCount As Integer
    Dim WrkDist As Integer
    Dim WrkDesc As String
		Dim WrkDBDate As Integer
		Dim WrkDBTime As Integer
		Dim CoeCCNo As Integer

		myTXCOEB = New TXCOEB.mydata(MyDBConnect)
		myTXCOEBL4 = New TXCOEBL4.mydata(MyDBConnect)
		myTXREALC = New TXREALC.mydata(MyDBConnect)
    myTXREAA = New TXREAA.mydata(MyDBConnect)
    myTXINV = New TXINV.mydata(MyDBConnect)
    myTXBAA = New TXBAA.mydata(MyDBConnect)
    MyTXPHIN = New TXPHIN.MyData(myDBConnect)
    MyTXPHCNTL = New TXPHCNTL.MyData(myDBConnect)
    LoadScrn = True

    With MyFrmTA810
      .TBarNew.Enabled = False
      .TBarSave.Enabled = True
      .TBarHist.Enabled = False
      .TBarPrinters.Enabled = False
      If WrkCCNo > 0 Then
        .TBarAttach.Enabled = True
      End If
    End With

    If MyPhaseIn Then
      With MyTXPHCNTL
        .GetOneRecordP("")
        WrkPhaseCurrYear = ._CURRYEAR
        WrkPhaseTotalYears = ._TOTALYEARS
      End With
    End If

    LnkExemptCd.Enabled = False
    TxtExemptCd.Enabled = False
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
      dsTXCOEBL4 = myTXCOEBL4.GetViewDescList(WrkListNo, WrkYear, WrkType, WrkDBDate, _
        WrkDBTime, 50)
      If dsTXCOEBL4.Tables(0).Rows.Count > 0 Then
        With dsTXCOEBL4.Tables(0).Rows(0)
          If WrkCCNo <> .Item("ccno") Then
            CoeCCNo = .Item("ccno")
          End If
        End With
      End If

    'Current Year
    If WrkYear = MyGLYear Then
      myTXREALC.GetOneRecordP(WrkListNo)
      If Not myTXREALC.RecordNotFound Then
        With myTXREALC
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
          If ._CAT = "1" Then
            RbCatTaxable.Checked = True
            LnkExemptCd.Enabled = False
            TxtExemptCd.Enabled = False
          Else
            RbCatExempt.Checked = True
            LnkExemptCd.Enabled = True
            TxtExemptCd.Enabled = True
            TxtExemptCd.Text = Trim(._EXMPT)
          End If
          TxtMap.Text = Trim(._MAP)
          TxtSMap.Text = Trim(._SMAP)
          TxtVol.Text = Trim(._VOL)
          TxtPage.Text = Trim(._PGE)
          DtPckPurDate.Checked = False
          If ._PURDT > 0 Then
            DtPckPurDate.Value = MyUtils.GetDBDate(._PURDT)
            DtPckPurDate.Checked = True
          End If
          TxtUnit.Text = Trim(._UNITNO)
          TxtUnit1.Text = ._UNIT1
          TxtUnit2.Text = ._UNIT2
          TxtUnit3.Text = ._UNIT3
          TxtUnit4.Text = ._UNIT4
          TxtUnit5.Text = ._UNIT5
          TxtUnit6.Text = ._UNIT6
          TxtUnit7.Text = ._UNIT7
          'Bank Codes
          WrkDesc = GetTXBanksDesc(Trim(._BKCD))
          Ttp1.SetToolTip(LblBankCd, WrkDesc)
          'Heart
          GrpHeart.Visible = False
          If Trim(._FCCOD) = "C" Then
            GrpHeart.Visible = True
            LblHeartPct.Text = ._CPERC
            LblHeartMin.Text = ._CMIN
            LblHeartMax.Text = ._CMAX
          End If
          'Freeze
          GrpFreeze.Visible = False
          If Trim(._FCCOD) = "F" Then
            GrpFreeze.Visible = True
            LblFreezeAmt.Text = ._FTAX
            LblFreezeYear.Text = ._FCYR
          End If
          If ._BTR = 0 Then
            LblOrigGross.Text = FormatNumber(._GROSS, 0)
            LblOrigExam.Text = FormatNumber(._GROSS - ._NET, 0)
            LblOrigNet.Text = FormatNumber(._NET, 0)
            LblOrigAssmt1.Text = ._ASS1
            LblOrigAssmt2.Text = ._ASS2
            LblOrigAssmt3.Text = ._ASS3
            LblOrigAssmt4.Text = ._ASS4
            LblOrigAssmt5.Text = ._ASS5
            LblOrigAssmt6.Text = ._ASS6
            LblOrigAssmt7.Text = ._ASS7
          Else
            myTXBAA.GetOneRecordP(WrkListNo, WrkType, WrkYear)
            LblOrigGross.Text = FormatNumber(._GROSS + ._BTR, 0)
            LblOrigExam.Text = FormatNumber(._GROSS - ._NET, 0)
            LblOrigNet.Text = FormatNumber(._NET + ._BTR, 0)
            LblOrigAssmt1.Text = ._ASS1 + myTXBAA._BASS1
            LblOrigAssmt2.Text = ._ASS2 + myTXBAA._BASS2
            LblOrigAssmt3.Text = ._ASS3 + myTXBAA._BASS3
            LblOrigAssmt4.Text = ._ASS4 + myTXBAA._BASS4
            LblOrigAssmt5.Text = ._ASS5 + myTXBAA._BASS5
            LblOrigAssmt6.Text = ._ASS6 + myTXBAA._BASS6
            LblOrigAssmt7.Text = ._ASS7 + myTXBAA._BASS7
          End If
          LblOrigExam1.Text = ._EXAM1
          LblOrigExam2.Text = ._EXAM2
          LblOrigExam3.Text = ._EXAM3
          LblOrigExam4.Text = ._EXAM4
          LblOrigExam5.Text = ._EXAM5
          LblOrigExam6.Text = ._EXAM6
          LblOrigExam7.Text = ._EXAM7
          TxtAssmt1.Text = ._CASS1
          TxtAssmt2.Text = ._CASS2
          TxtAssmt3.Text = ._CASS3
          TxtAssmt4.Text = ._CASS4
          TxtAssmt5.Text = ._CASS5
          TxtAssmt6.Text = ._CASS6
          TxtAssmt7.Text = ._CASS7
          TxtExam1.Text = ._CEXA1
          TxtExam2.Text = ._CEXA2
          TxtExam3.Text = ._CEXA3
          TxtExam4.Text = ._CEXA4
          TxtExam5.Text = ._CEXA5
          TxtExam6.Text = ._CEXA6
          TxtExam7.Text = ._CEXA7
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
          If Trim(._EXCD6) <> "" Then
            TxtExempt6.Text = Trim(._EXCD6)
          End If
          If Trim(._EXCD7) <> "" Then
            TxtExempt7.Text = Trim(._EXCD7)
          End If
          SetExem1Tip()
          SetExem2Tip()
          SetExem3Tip()
          SetExem4Tip()
          SetExem5Tip()
          SetExem6Tip()
          SetExem7Tip()
        End With
      End If
    End If

    'Previous Years
    If WrkYear <> MyGLYear Then
      myTXREAA.GetOneRecordP(WrkListNo, WrkYear)
      If Not myTXREAA.RecordNotFound Then
      With myTXREAA
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
        If ._CAT = "1" Then
           RbCatTaxable.Checked = True
           LnkExemptCd.Enabled = False
           TxtExemptCd.Enabled = False
        Else
           RbCatExempt.Checked = True
           LnkExemptCd.Enabled = True
           TxtExemptCd.Enabled = True
           TxtExemptCd.Text = Trim(._EXMPT)
        End If
        TxtMap.Text = Trim(._MAP)
        TxtSMap.Text = Trim(._SMAP)
        TxtVol.Text = Trim(._VOL)
        TxtPage.Text = Trim(._PGE)
        DtPckPurDate.Checked = False
        If ._PURDT > 0 Then
          DtPckPurDate.Value = MyUtils.GetDBDate(._PURDT)
          DtPckPurDate.Checked = True
        End If
        TxtUnit.Text = Trim(._UNITNo)
        TxtUnit1.Text = ._UNIT1
        TxtUnit2.Text = ._UNIT2
        TxtUnit3.Text = ._UNIT3
        TxtUnit4.Text = ._UNIT4
        TxtUnit5.Text = ._UNIT5
        TxtUnit6.Text = ._UNIT6
        TxtUnit7.Text = ._UNIT7
        'Bank Codes
        WrkDesc = GetTXBanksDesc(Trim(._BKCD))
        Ttp1.SetToolTip(LblBankCd, WrkDesc)
        'Heart
        GrpHeart.Visible = False
        If Trim(._FCCOD) = "C" Then
          GrpHeart.Visible = True
          LblHeartPct.Text = ._CPERC
          LblHeartMin.Text = ._CMIN
          LblHeartMax.Text = ._CMAX
        End If
        'Freeze
        GrpFreeze.Visible = False
        If Trim(._FCCOD) = "F" Then
          GrpFreeze.Visible = True
          LblFreezeAmt.Text = ._FTAX
          LblFreezeYear.Text = ._FCYR
        End If
        If CoeCCNo = 0 Then
          LblOrigGross.Text = FormatNumber(._GROSS)
          LblOrigExam.Text = FormatNumber(._EXAM1 + ._EXAM2 + ._EXAM3 + _
            ._EXAM4 + ._EXAM5, 0)
          LblOrigNet.Text = FormatNumber(MyUtils.CnvSng(LblOrigGross.Text) - MyUtils.CnvSng(LblOrigExam.Text), 0)
          LblOrigAssmt1.Text = ._GROSS
          LblOrigExam1.Text = ._EXAM1
          LblOrigExam2.Text = ._EXAM2
          LblOrigExam3.Text = ._EXAM3
          LblOrigExam4.Text = ._EXAM4
          LblOrigExam5.Text = ._EXAM5
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
          LblNewExam.Text = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + _
            ._EXAM5
          LblNewNet.Text = MyUtils.CnvSng(LblNewGross.Text) - MyUtils.CnvSng(LblNewExam.Text)
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
          TxtLocNo.Text = Trim(._LOCNo)
          TxtLoc.Text = Trim(._LOC)
          RbCatTaxable.Checked = True
          LnkExemptCd.Enabled = False
          TxtExemptCd.Enabled = False
          TxtMap.Text = Trim(._MAP)
          TxtSMap.Text = ""
          TxtVol.Text = Trim(._VOL)
          TxtPage.Text = Trim(._IPAGE)
          DtPckPurDate.Checked = False
          TxtUnit.Text = ""
          TxtUnit1.Text = ._UNIT1
          TxtUnit2.Text = ._UNIT2
          TxtUnit3.Text = ._UNIT3
          TxtUnit4.Text = ._UNIT4
          TxtUnit5.Text = ._UNIT5
          TxtUnit6.Text = ._UNIT6
          TxtUnit7.Text = ._UNIT7
          'Bank Codes
          WrkDesc = GetTXBanksDesc(Trim(._BKCD))
          Ttp1.SetToolTip(LblBankCd, WrkDesc)
          'Heart
          GrpHeart.Visible = False
          If Trim(._FRCD) = "C" Then
            GrpHeart.Visible = True
            LblHeartPct.Text = ._CPERC
            LblHeartMin.Text = ._CMIN
            LblHeartMax.Text = ._CMAX
          End If
          'Freeze
          GrpFreeze.Visible = False
          If Trim(._FRCD) = "F" Then
            GrpFreeze.Visible = True
            LblFreezeAmt.Text = ._FTAX
            LblFreezeYear.Text = ._FRYR
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
      TxtAssmt2.Text = MyUtils.CnvSng(LblOrigAssmt2.Text)
      TxtAssmt3.Text = MyUtils.CnvSng(LblOrigAssmt3.Text)
      TxtAssmt4.Text = MyUtils.CnvSng(LblOrigAssmt4.Text)
      TxtAssmt5.Text = MyUtils.CnvSng(LblOrigAssmt5.Text)
      TxtAssmt6.Text = MyUtils.CnvSng(LblOrigAssmt6.Text)
      TxtAssmt7.Text = MyUtils.CnvSng(LblOrigAssmt7.Text)
      TxtExam1.Text = MyUtils.CnvSng(LblOrigExam1.Text)
      TxtExam2.Text = MyUtils.CnvSng(LblOrigExam2.Text)
      TxtExam3.Text = MyUtils.CnvSng(LblOrigExam3.Text)
      TxtExam4.Text = MyUtils.CnvSng(LblOrigExam4.Text)
      TxtExam5.Text = MyUtils.CnvSng(LblOrigExam5.Text)
      TxtExam6.Text = MyUtils.CnvSng(LblOrigExam6.Text)
      TxtExam7.Text = MyUtils.CnvSng(LblOrigExam7.Text)
    End If

    dsTXCOEBL4 = myTXCOEBL4.GetViewbyList(WrkListNo, WrkYear, WrkType, 50)
    If dsTXCOEBL4.Tables(0).Rows.Count > 1 Then
      MyFrmTA810.TBarHist.Enabled = True
    End If

    LoadScrn = False
    CalcChg()
  End Sub

  Private Sub FrmTA8102R_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
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
    Dim WrkYearsLeft As Integer
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
    SetCResnTip()

    If Not WrkAddMode Then
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXCOEB.UpdateOneRecordP()
        If myTXCOEB.ErrMsg <> "" Then
          WriteErrorLog(myTXCOEB.ErrMsg)
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
        myTXCOEB.AddOneRecordP()
        If myTXCOEB.ErrMsg <> "" Then
          WriteErrorLog(myTXCOEB.ErrMsg)
          Exit Sub
        End If
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    myTXREALC.GetOneRecordP(WrkListNo)
    If Not myTXREALC.RecordNotFound Then
      MoveToFile()
      If IsNothing(ErrorMsg(0)) Then
        myTXREALC.UpdateOneRecordP()
        If myTXREALC.ErrMsg <> "" Then
          WriteErrorLog(myTXREALC.ErrMsg)
          Exit Sub
        End If
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      WrkListNo = MyUtils.CnvSng(LblListNo.Text)
      WrkYear = MyUtils.CnvSng(LblYear.Text)
      MoveToFile()
      If IsNothing(ErrorMsg(0)) Then
        myTXREALC.AddOneRecordP()
        If myTXREALC.ErrMsg <> "" Then
          WriteErrorLog(myTXREALC.ErrMsg)
          Exit Sub
        End If
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    If MyPhaseIn Then
      With MyTXPHIN
        .GetOneRecordP(WrkListNo, WrkYear)
        If Not .RecordNotFound Then
          ._ADJGRS = MyUtils.CnvSng(LblNewGross.Text) - myTXREALC._GROSS
          ._ADJA1 = MyUtils.CnvSng(TxtAssmt1.Text) - myTXREALC._ASS1
          ._ADJA2 = MyUtils.CnvSng(TxtAssmt2.Text) - myTXREALC._ASS2
          ._ADJA3 = MyUtils.CnvSng(TxtAssmt3.Text) - myTXREALC._ASS3
          ._ADJA4 = MyUtils.CnvSng(TxtAssmt4.Text) - myTXREALC._ASS4
          ._ADJA5 = MyUtils.CnvSng(TxtAssmt5.Text) - myTXREALC._ASS5
          ._ADJA6 = MyUtils.CnvSng(TxtAssmt6.Text) - myTXREALC._ASS6
          ._ADJA7 = MyUtils.CnvSng(TxtAssmt7.Text) - myTXREALC._ASS7
          ._ADJC1 = TxtCode1.Text
          ._ADJC2 = TxtCode2.Text
          ._ADJC3 = TxtCode3.Text
          ._ADJC4 = TxtCode4.Text
          ._ADJC5 = TxtCode5.Text
          ._ADJC6 = TxtCode6.Text
          ._ADJC7 = TxtCode7.Text
          WrkYearsLeft = WrkPhaseTotalYears - WrkPhaseCurrYear + 1
          ._FULGRS = (._CAPGRS + ._ADJGRS) * WrkYearsLeft
          .UpdateOneRecordP()
        End If
      End With
    End If

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
          ._EXEMP = ""
        Else
          ._CATG = "3"
          ._EXEMP = TxtExemptCd.Text
        End If
        'Reason Codes
        WrkDesc = GetTXCResnDesc(._RSNCD)
        Ttp1.SetToolTip(TxtReason, WrkDesc)
        ._CDESC = TxtDesc.Text
        ._CDESC = TxtDesc.Text
        ._NTPCD1 = MyUtils.CnvSng(TxtCode1.Text)
        ._NTASS1 = MyUtils.CnvSng(TxtAssmt1.Text)
        ._NTPCD2 = MyUtils.CnvSng(TxtCode2.Text)
        ._NTASS2 = MyUtils.CnvSng(TxtAssmt2.Text)
        ._NTPCD3 = MyUtils.CnvSng(TxtCode3.Text)
        ._NTASS3 = MyUtils.CnvSng(TxtAssmt3.Text)
        ._NTPCD4 = MyUtils.CnvSng(TxtCode4.Text)
        ._NTASS4 = MyUtils.CnvSng(TxtAssmt4.Text)
        ._NTPCD5 = MyUtils.CnvSng(TxtCode5.Text)
        ._NTASS5 = MyUtils.CnvSng(TxtAssmt5.Text)
        ._NTPCD6 = MyUtils.CnvSng(TxtCode6.Text)
        ._NTASS6 = MyUtils.CnvSng(TxtAssmt6.Text)
        ._NTPCD7 = MyUtils.CnvSng(TxtCode7.Text)
        ._NTASS7 = MyUtils.CnvSng(TxtAssmt7.Text)
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
        ._NTECD6 = TxtExempt6.Text
        ._NTEX6 = MyUtils.CnvSng(TxtExam6.Text)
        ._NTECD7 = TxtExempt7.Text
        ._NTEX7 = MyUtils.CnvSng(TxtExam7.Text)
        ._NTNET = MyUtils.CnvSng(LblNewNet.Text)
      ._PRF = Mid(MyUserID, 1, 10)
      ._CHDATE = MyUtils.SetDBDate(DateTime.Today)
      ._CHTIME = Format(DateTime.Now, "hhmmss")
      End With

      With myTXREALC
        ._TYPE = WrkType
        If RbCatTaxable.Checked Then
          ._CAT = "1"
          ._EXMPT = String.Empty
        Else
          ._CAT = "3"
          ._EXMPT = TxtExemptCd.Text
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
        ._LOCNO = MyUtils.JustifyRight(TxtLocNo.Text, 7)
        ._LOC = TxtLoc.Text
        ._DIST = MyUtils.CnvSng(TxtDist.Text)
        ._MAP = TxtMap.Text
        ._SMAP = TxtSMap.Text
        ._VOL = TxtVol.Text
        ._PGE = TxtPage.Text
        ._UNITNO = TxtUnit.Text
        ._CCNO = WrkCCNo
        ._CDATE = MyUtils.SetDBDate(LblCCDate.Text)
        ._CCGRS = MyUtils.CnvSng(LblNewGross.Text)
        ._CCEX = MyUtils.CnvSng(LblNewExam.Text)
        ._CCRS = TxtReason.Text
        ._CODE1 = MyUtils.CnvSng(TxtCode1.Text)
        ._CASS1 = MyUtils.CnvSng(TxtAssmt1.Text)
        ._CODE2 = MyUtils.CnvSng(TxtCode2.Text)
        ._CASS2 = MyUtils.CnvSng(TxtAssmt2.Text)
        ._CODE3 = MyUtils.CnvSng(TxtCode3.Text)
        ._CASS3 = MyUtils.CnvSng(TxtAssmt3.Text)
        ._CODE4 = MyUtils.CnvSng(TxtCode4.Text)
        ._CASS4 = MyUtils.CnvSng(TxtAssmt4.Text)
        ._CODE5 = MyUtils.CnvSng(TxtCode5.Text)
        ._CASS5 = MyUtils.CnvSng(TxtAssmt5.Text)
        ._CODE6 = MyUtils.CnvSng(TxtCode6.Text)
        ._CASS6 = MyUtils.CnvSng(TxtAssmt6.Text)
        ._CODE7 = MyUtils.CnvSng(TxtCode7.Text)
        ._CASS7 = MyUtils.CnvSng(TxtAssmt7.Text)
        ._UNIT1 = MyUtils.CnvSng(TxtUnit1.Text)
        ._UNIT2 = MyUtils.CnvSng(TxtUnit2.Text)
        ._UNIT3 = MyUtils.CnvSng(TxtUnit3.Text)
        ._UNIT4 = MyUtils.CnvSng(TxtUnit4.Text)
        ._UNIT5 = MyUtils.CnvSng(TxtUnit5.Text)
        ._UNIT6 = MyUtils.CnvSng(TxtUnit6.Text)
        ._UNIT7 = MyUtils.CnvSng(TxtUnit7.Text)
        ._CCCD1 = TxtExempt1.Text
        ._CCCD2 = TxtExempt2.Text
        ._CCCD3 = TxtExempt3.Text
        ._CCCD4 = TxtExempt4.Text
        ._CCCD5 = TxtExempt5.Text
        ._CCCD6 = TxtExempt6.Text
        ._CCCD7 = TxtExempt7.Text
        ._CEXA1 = MyUtils.CnvSng(TxtExam1.Text)
        ._CEXA2 = MyUtils.CnvSng(TxtExam2.Text)
        ._CEXA3 = MyUtils.CnvSng(TxtExam3.Text)
        ._CEXA4 = MyUtils.CnvSng(TxtExam4.Text)
        ._CEXA5 = MyUtils.CnvSng(TxtExam5.Text)
        ._CEXA6 = MyUtils.CnvSng(TxtExam6.Text)
        ._CEXA7 = MyUtils.CnvSng(TxtExam7.Text)
      End With

   End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(LblListNo, "")
    ErrProv.SetError(TxtName, "")
    ErrProv.SetError(TxtReason, "")
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
    ErrProv.SetError(LblNewNet, "")
    ErrProv.SetError(TxtExemptCd, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
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
        Case "rsncd"
          ErrProv.SetError(TxtReason, ErrorMsg(I))
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
        Case "net"
          ErrProv.SetError(LblNewNet, ErrorMsg(I))
        Case "exmpt"
          ErrProv.SetError(LblNewNet, ErrorMsg(I))
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

    WrkTip = Ttp1.GetToolTip(TxtCode1)
    If Mid(WrkTip, 1, 1) = "*" Then
      ErrorField(I) = "code1"
      ErrorMsg(I) = "Invalid Assessment Code"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtCode2.Text) > 0 Or MyUtils.CnvSng(TxtAssmt2.Text) > 0 Then
      WrkTip = Ttp1.GetToolTip(TxtCode2)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "code2"
        ErrorMsg(I) = "Invalid Assessment Code"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtCode3.Text) > 0 Or MyUtils.CnvSng(TxtAssmt3.Text) > 0 Then
      WrkTip = Ttp1.GetToolTip(TxtCode3)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "code3"
        ErrorMsg(I) = "Invalid Assessment Code"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtCode4.Text) > 0 Or MyUtils.CnvSng(TxtAssmt4.Text) > 0 Then
      WrkTip = Ttp1.GetToolTip(TxtCode4)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "code4"
        ErrorMsg(I) = "Invalid Assessment Code"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtCode5.Text) > 0 Or MyUtils.CnvSng(TxtAssmt5.Text) > 0 Then
      WrkTip = Ttp1.GetToolTip(TxtCode5)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "code5"
        ErrorMsg(I) = "Invalid Assessment Code"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtCode6.Text) > 0 Or MyUtils.CnvSng(TxtAssmt6.Text) > 0 Then
      WrkTip = Ttp1.GetToolTip(TxtCode6)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "code6"
        ErrorMsg(I) = "Invalid Assessment Code"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtCode7.Text) > 0 Or MyUtils.CnvSng(TxtAssmt7.Text) > 0 Then
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

    WrkTip = Ttp1.GetToolTip(TxtReason)
    If Trim(TxtReason.Text) = "" Or Mid(WrkTip, 1, 1) = "*" Then
      ErrorField(I) = "rsncd"
      ErrorMsg(I) = "Invalid Reason Code"
      I = I + 1
    End If

    If MyUtils.CnvSng(LblNewNet.Text) < 0 Then
      ErrorField(I) = "net"
      ErrorMsg(I) = "Net cannot be negative"
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

End Sub

   Private Sub FrmTA8102R_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA810.SbpScreen.Text = "TA8102R"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
Private Sub TxtReason_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtReason.Leave
    SetCResnTip()
End Sub
  Private Sub TxtAssmt1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAssmt1.TextChanged
    If Not TxtAssmt1.Modified Then Exit Sub
    CalcChg()
  End Sub
  Private Sub TxtAssmt2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAssmt2.TextChanged
    If Not TxtAssmt2.Modified Then Exit Sub
    CalcChg()
  End Sub
  Private Sub TxtAssmt3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAssmt3.TextChanged
    If Not TxtAssmt3.Modified Then Exit Sub
    CalcChg()
  End Sub
  Private Sub TxtAssmt4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAssmt4.TextChanged
    If Not TxtAssmt4.Modified Then Exit Sub
    CalcChg()
  End Sub
  Private Sub TxtAssmt5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAssmt5.TextChanged
    If Not TxtAssmt5.Modified Then Exit Sub
    CalcChg()
  End Sub
  Private Sub TxtAssmt6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAssmt6.TextChanged
    If Not TxtAssmt6.Modified Then Exit Sub
    CalcChg()
  End Sub
  Private Sub TxtAssmt7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAssmt7.TextChanged
    If Not TxtAssmt7.Modified Then Exit Sub
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
  Private Sub TxtExam6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam6.TextChanged
    If Not TxtExam6.Modified Then Exit Sub
    CalcChg()
  End Sub
  Private Sub TxtExam7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam7.TextChanged
    If Not TxtExam7.Modified Then Exit Sub
    CalcChg()
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
  Private Sub TxtExempt6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt6.TextChanged
    Dim WrkTxExem As String()

    If LoadScrn Then Exit Sub

     WrkTxExem = GetTXExem(TxtExempt6.Text)
     TxtExam6.Text = WrkTxExem(0)
     CalcChg()
  End Sub
  Private Sub TxtExempt7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt7.TextChanged
    Dim WrkTxExem As String()

    If LoadScrn Then Exit Sub

     WrkTxExem = GetTXExem(TxtExempt7.Text)
     TxtExam7.Text = WrkTxExem(0)
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
  Private Sub TxtExempt6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtExempt6.Leave
    SetExem6Tip()
  End Sub
  Private Sub TxtExempt7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtExempt7.Leave
    SetExem7Tip()
  End Sub
  Public Sub GetOrigTxCOEB(ByVal WrkCCNo As Integer)
    Dim MyOrigTXCOEB As TXCOEB.myData
    MyOrigTXCOEB = New TXCOEB.mydata(MyDBConnect)
    MyOrigTXCOEB.GetOneRecordP(WrkCCNo)
    If Not MyOrigTXCOEB.RecordNotFound Then
    With MyOrigTXCOEB
      LblOrig.Text = "C/C " & Str$(WrkCCNo)
      LblOrig.ForeColor = Color.Fuchsia
      LblOrigGross.Text = FormatNumber(._CGRS, 0)
      LblOrigExam.Text = FormatNumber(._NTEX1 + ._NTEX2 + ._NTEX3 + _
        ._NTEX4 + ._NTEX5, 0)
      LblOrigNet.Text = FormatNumber(MyUtils.CnvSng(LblOrigGross.Text) - MyUtils.CnvSng(LblOrigExam.Text), 0)
      'Assessment Property Codes
      TxtCode1.Text = ._NTPCD1
      TxtCode2.Text = ._NTPCD2
      TxtCode3.Text = ._NTPCD3
      TxtCode4.Text = ._NTPCD4
      TxtCode5.Text = ._NTPCD5
      TxtCode6.Text = ._NTPCD6
      TxtCode7.Text = ._NTPCD7
      SetCode1Tip()
      SetCode2Tip()
      SetCode3Tip()
      SetCode4Tip()
      SetCode5Tip()
      SetCode6Tip()
      SetCode7Tip()
      LblOrigAssmt1.Text = ._NTASS1
      LblOrigAssmt2.Text = ._NTASS2
      LblOrigAssmt3.Text = ._NTASS3
      LblOrigAssmt4.Text = ._NTASS4
      LblOrigAssmt5.Text = ._NTASS5
      LblOrigAssmt6.Text = ._NTASS6
      LblOrigAssmt7.Text = ._NTASS7
      'Exemption Codes
      TxtExempt1.Text = Trim(._NTECD1)
      TxtExempt2.Text = Trim(._NTECD2)
      TxtExempt3.Text = Trim(._NTECD3)
      TxtExempt4.Text = Trim(._NTECD4)
      TxtExempt5.Text = Trim(._NTECD5)
      TxtExempt6.Text = Trim(._NTECD6)
      TxtExempt7.Text = Trim(._NTECD7)
      SetExem1Tip()
      SetExem2Tip()
      SetExem3Tip()
      SetExem4Tip()
      SetExem5Tip()
      SetExem6Tip()
      SetExem7Tip()
      LblOrigExam1.Text = ._NTEX1
      LblOrigExam2.Text = ._NTEX2
      LblOrigExam3.Text = ._NTEX3
      LblOrigExam4.Text = ._NTEX4
      LblOrigExam5.Text = ._NTEX5
      LblOrigExam6.Text = ._NTEX6
      LblOrigExam7.Text = ._NTEX7
    End With
    End If
End Sub
  Public Sub GetTXCOEB()

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
        'Assessment Property Codes
        TxtCode1.Text = ._NTPCD1
        TxtCode2.Text = ._NTPCD2
        TxtCode3.Text = ._NTPCD3
        TxtCode4.Text = ._NTPCD4
        TxtCode5.Text = ._NTPCD5
        TxtCode6.Text = ._NTPCD6
        TxtCode7.Text = ._NTPCD7
        SetCode1Tip()
        SetCode2Tip()
        SetCode3Tip()
        SetCode4Tip()
        SetCode5Tip()
        SetCode6Tip()
        SetCode7Tip()
        TxtAssmt1.Text = ._NTASS1
        TxtAssmt2.Text = ._NTASS2
        TxtAssmt3.Text = ._NTASS3
        TxtAssmt4.Text = ._NTASS4
        TxtAssmt5.Text = ._NTASS5
        TxtAssmt6.Text = ._NTASS6
        TxtAssmt7.Text = ._NTASS7
        'Exemption Codes
        TxtExempt1.Text = Trim(._NTECD1)
        TxtExempt2.Text = Trim(._NTECD2)
        TxtExempt3.Text = Trim(._NTECD3)
        TxtExempt4.Text = Trim(._NTECD4)
        TxtExempt5.Text = Trim(._NTECD5)
        TxtExempt6.Text = Trim(._NTECD6)
        TxtExempt7.Text = Trim(._NTECD7)
        SetExem1Tip()
        SetExem2Tip()
        SetExem3Tip()
        SetExem4Tip()
        SetExem5Tip()
        SetExem6Tip()
        SetExem7Tip()
        TxtExam1.Text = ._NTEX1
        TxtExam2.Text = ._NTEX2
        TxtExam3.Text = ._NTEX3
        TxtExam4.Text = ._NTEX4
        TxtExam5.Text = ._NTEX5
        TxtExam6.Text = ._NTEX6
        TxtExam7.Text = ._NTEX7
      End With

End Sub

Sub CalcChg()
  If LoadScrn Then Exit Sub

  LblNewGross.Text = FormatNumber(MyUtils.CnvSng(TxtAssmt1.Text) + MyUtils.CnvSng(TxtAssmt2.Text) + MyUtils.CnvSng(TxtAssmt3.Text) + _
    MyUtils.CnvSng(TxtAssmt4.Text) + MyUtils.CnvSng(TxtAssmt5.Text) + MyUtils.CnvSng(TxtAssmt6.Text) + MyUtils.CnvSng(TxtAssmt7.Text), 0)
  LblNewExam.Text = FormatNumber(MyUtils.CnvSng(TxtExam1.Text) + MyUtils.CnvSng(TxtExam2.Text) + MyUtils.CnvSng(TxtExam3.Text) + _
    MyUtils.CnvSng(TxtExam4.Text) + MyUtils.CnvSng(TxtExam5.Text) + MyUtils.CnvSng(TxtExam6.Text) + MyUtils.CnvSng(TxtExam7.Text), 0)
  LblNewCred.Text = FormatNumber(MyUtils.CnvSng(LblOrigCred.Text), 0)
  LblNewNet.Text = FormatNumber(MyUtils.CnvSng(LblNewGross.Text) - MyUtils.CnvSng(LblNewExam.Text), 0)

  If LblOrigGross.Text <> "" Then
    LblChgGross.Text = FormatNumber(MyUtils.CnvSng(LblNewGross.Text) - MyUtils.CnvSng(LblOrigGross.Text), 0)
    LblChgExam.Text = FormatNumber(MyUtils.CnvSng(LblNewExam.Text) - MyUtils.CnvSng(LblOrigExam.Text), 0)
    LblChgCred.Text = FormatNumber(MyUtils.CnvSng(LblNewCred.Text) - MyUtils.CnvSng(LblOrigCred.Text), 0)
    LblChgNet.Text = FormatNumber(MyUtils.CnvSng(LblNewNet.Text) - MyUtils.CnvSng(LblOrigNet.Text), 0)
    LblChgAssmt1.Text = MyUtils.CnvSng(TxtAssmt1.Text) - MyUtils.CnvSng(LblOrigAssmt1.Text)
    LblChgAssmt2.Text = MyUtils.CnvSng(TxtAssmt2.Text) - MyUtils.CnvSng(LblOrigAssmt2.Text)
    LblChgAssmt3.Text = MyUtils.CnvSng(TxtAssmt3.Text) - MyUtils.CnvSng(LblOrigAssmt3.Text)
    LblChgAssmt4.Text = MyUtils.CnvSng(TxtAssmt4.Text) - MyUtils.CnvSng(LblOrigAssmt4.Text)
    LblChgAssmt5.Text = MyUtils.CnvSng(TxtAssmt5.Text) - MyUtils.CnvSng(LblOrigAssmt5.Text)
    LblChgAssmt6.Text = MyUtils.CnvSng(TxtAssmt6.Text) - MyUtils.CnvSng(LblOrigAssmt6.Text)
    LblChgAssmt7.Text = MyUtils.CnvSng(TxtAssmt7.Text) - MyUtils.CnvSng(LblOrigAssmt7.Text)
    LblChgExam1.Text = MyUtils.CnvSng(TxtExam1.Text) - MyUtils.CnvSng(LblOrigExam1.Text)
    LblChgExam2.Text = MyUtils.CnvSng(TxtExam2.Text) - MyUtils.CnvSng(LblOrigExam2.Text)
    LblChgExam3.Text = MyUtils.CnvSng(TxtExam3.Text) - MyUtils.CnvSng(LblOrigExam3.Text)
    LblChgExam4.Text = MyUtils.CnvSng(TxtExam4.Text) - MyUtils.CnvSng(LblOrigExam4.Text)
    LblChgExam5.Text = MyUtils.CnvSng(TxtExam5.Text) - MyUtils.CnvSng(LblOrigExam5.Text)
  End If
End Sub
  Private Sub LnkReason_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkReason.LinkClicked
    MyFrmListCResn = New FrmListCResn
    MyFrmListCResn.MdiParent = Me.ParentForm
    MyFrmListCResn.WrkType = WrkType
    MyFrmListCResn.WrkCode = TxtReason.Text
    MyFrmListCResn.Show()
  End Sub

  Private Sub TpMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpMain.Click

  End Sub
  Private Sub TxtOverAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Call CalcChg()
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
  End Sub
  Private Sub RbCatExempt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbCatExempt.CheckedChanged
    LnkExemptCd.Enabled = True
    TxtExemptCd.Enabled = True
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
Private Sub SetCResnTip()
		Dim WrkDesc As String

		If Not TxtReason.Modified And Not LoadScrn Then Exit Sub

		WrkDesc = GetTXCResnDesc(TxtReason.Text)
		Ttp1.SetToolTip(TxtReason, WrkDesc)
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
Private Sub TxtLocNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLocNo.KeyPress
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
Private Function NextListNo() As Integer
 Dim WrkNextListNo As Integer

 WrkNextListNo = myTXREALC.AutoGenKey()
 Return WrkNextListNo

End Function
End Class






