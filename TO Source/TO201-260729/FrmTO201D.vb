Public Class FrmTO201D
  Inherits System.Windows.Forms.Form
  Dim MyTXM35H As TXM35H.MyData
  Dim MyTXM35EX As TXM35EX.MyData
  Dim MyTXREALC As TXREALC.MyData
  Dim MyTXREAL As TXREAL.MyData
  Dim MyTXMRATE As TXMRATE.MyData
  Dim MyTXLOCAL As TXLOCAL.MyData
  Dim MyTXLOCDA As TXLOCDA.MyData
  Dim MyTXLOCFRZ As TXLOCFRZ.MyData
  Dim MyTXHOME As TXHOME.MyData
  Dim MyTXHOIN As TXHOIN.MyData
  Dim MyTPAYMNT As TPAYMNT.MyData
  Dim MyTXPROF As TXPROF.MyData
  Dim MyTXLOCIN As TXLOCIN.MyData
  Dim MyTXLOCHB As TXLOCHB.MyData
  Dim MyTXM35PM As TXM35PM.MyData
  Dim MyTXCNTL As TXCNTL.MyData
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkSeq As Integer
  Dim AddMode As Boolean
  'Adjusted Gross - excluded codes
  Dim cExcludeCode1 As Integer
  Dim cExcludeCode2 As Integer
  Dim cExcludeCode3 As Integer
  Dim cExcludeCode4 As Integer

  Friend WithEvents Tab1 As System.Windows.Forms.TabControl
  Friend WithEvents TpApplicant As System.Windows.Forms.TabPage
  Friend WithEvents TxtOwner As System.Windows.Forms.TextBox
  Friend WithEvents TxtSLName As System.Windows.Forms.TextBox
  Friend WithEvents TxtALName As System.Windows.Forms.TextBox
  Friend WithEvents TxtMZip As System.Windows.Forms.TextBox
  Friend WithEvents TxtMState As System.Windows.Forms.TextBox
  Friend WithEvents TxtPState As System.Windows.Forms.TextBox
  Friend WithEvents TxtPZip As System.Windows.Forms.TextBox
  Friend WithEvents TxtPAddr As System.Windows.Forms.TextBox
  Friend WithEvents TxtMAddr As System.Windows.Forms.TextBox
  Friend WithEvents TxtPCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtMCity As System.Windows.Forms.TextBox
  Friend WithEvents ChkDisabled As System.Windows.Forms.CheckBox
  Friend WithEvents ChkNursingHome As System.Windows.Forms.CheckBox
  Friend WithEvents ChkTaxReturn As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents RbSurviving As System.Windows.Forms.RadioButton
  Friend WithEvents RbUnmarried As System.Windows.Forms.RadioButton
  Friend WithEvents RbMarried As System.Windows.Forms.RadioButton
  Friend WithEvents Label26 As System.Windows.Forms.Label
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents Label24 As System.Windows.Forms.Label
  Friend WithEvents Label25 As System.Windows.Forms.Label
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents DtPckSDOB As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents DtPckADOB As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtSFName As System.Windows.Forms.TextBox
  Friend WithEvents TxtSInit As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtAFName As System.Windows.Forms.TextBox
  Friend WithEvents TxtAInit As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents TxtOther As System.Windows.Forms.TextBox
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents TxtSSRR As System.Windows.Forms.TextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents TxtInterest As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtIncome As System.Windows.Forms.TextBox
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents LnkListNo As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
  Friend WithEvents TpAssessor As System.Windows.Forms.TabPage
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents Label27 As System.Windows.Forms.Label
  Friend WithEvents Label28 As System.Windows.Forms.Label
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents Label34 As System.Windows.Forms.Label
  Friend WithEvents TxtPGross As System.Windows.Forms.TextBox
  Friend WithEvents Label33 As System.Windows.Forms.Label
  Friend WithEvents TxtPropPct As System.Windows.Forms.TextBox
  Friend WithEvents Label32 As System.Windows.Forms.Label
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents Label35 As System.Windows.Forms.Label
  Friend WithEvents TxtVet As System.Windows.Forms.TextBox
  Friend WithEvents TxtDisabled As System.Windows.Forms.TextBox
  Friend WithEvents TxtBlind As System.Windows.Forms.TextBox
  Friend WithEvents Label38 As System.Windows.Forms.Label
  Friend WithEvents Label39 As System.Windows.Forms.Label
  Friend WithEvents Label37 As System.Windows.Forms.Label
  Friend WithEvents Label36 As System.Windows.Forms.Label
  Friend WithEvents Label41 As System.Windows.Forms.Label
  Friend WithEvents TxtAddlVet As System.Windows.Forms.TextBox
  Friend WithEvents Label40 As System.Windows.Forms.Label
  Friend WithEvents TxtLocal As System.Windows.Forms.TextBox
  Friend WithEvents Label43 As System.Windows.Forms.Label
  Friend WithEvents Label42 As System.Windows.Forms.Label
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents Label44 As System.Windows.Forms.Label
  Friend WithEvents Label45 As System.Windows.Forms.Label
  Friend WithEvents TxtMinGrant As System.Windows.Forms.TextBox
  Friend WithEvents Label46 As System.Windows.Forms.Label
  Friend WithEvents Label47 As System.Windows.Forms.Label
  Friend WithEvents TxtCeiling As System.Windows.Forms.TextBox
  Friend WithEvents Label49 As System.Windows.Forms.Label
  Friend WithEvents TxtTablePct As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
  Friend WithEvents RbDisallowed As System.Windows.Forms.RadioButton
  Friend WithEvents RbAllowed As System.Windows.Forms.RadioButton
  Friend WithEvents LblTotal As System.Windows.Forms.Label
  Friend WithEvents LblYear As System.Windows.Forms.Label
  Friend WithEvents LblListNo As System.Windows.Forms.Label
  Friend WithEvents LblAInit As System.Windows.Forms.Label
  Friend WithEvents LblAFName As System.Windows.Forms.Label
  Friend WithEvents LblALName As System.Windows.Forms.Label
  Friend WithEvents LblTax As System.Windows.Forms.Label
  Friend WithEvents LblMillRate As System.Windows.Forms.Label
  Friend WithEvents LblNet As System.Windows.Forms.Label
  Friend WithEvents LblCredit As System.Windows.Forms.Label
  Friend WithEvents LblLesser As System.Windows.Forms.Label
  Friend WithEvents LblCreditMax As System.Windows.Forms.Label
  Friend WithEvents LblAppGross As System.Windows.Forms.Label
  Friend WithEvents Label52 As System.Windows.Forms.Label
  Friend WithEvents TxtRelate As System.Windows.Forms.TextBox
  Friend WithEvents Label31 As System.Windows.Forms.Label
  Friend WithEvents Label51 As System.Windows.Forms.Label
  Friend WithEvents DtPckSigned As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtDisallowReason As System.Windows.Forms.TextBox
  Friend WithEvents Label53 As System.Windows.Forms.Label
  Friend WithEvents DtPckReceived As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckAssr As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label54 As System.Windows.Forms.Label
  Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtSName As System.Windows.Forms.TextBox
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
  Friend WithEvents LblExcd6 As System.Windows.Forms.Label
  Friend WithEvents LblExam6 As System.Windows.Forms.Label
  Friend WithEvents LblExcd5 As System.Windows.Forms.Label
  Friend WithEvents LblExam5 As System.Windows.Forms.Label
  Friend WithEvents LblExcd4 As System.Windows.Forms.Label
  Friend WithEvents LblExam4 As System.Windows.Forms.Label
  Friend WithEvents LblExcd3 As System.Windows.Forms.Label
  Friend WithEvents LblExam3 As System.Windows.Forms.Label
  Friend WithEvents LblExcd2 As System.Windows.Forms.Label
  Friend WithEvents LblExam2 As System.Windows.Forms.Label
  Friend WithEvents LblExcd1 As System.Windows.Forms.Label
  Friend WithEvents LblExam1 As System.Windows.Forms.Label
  Friend WithEvents LblExcd7 As System.Windows.Forms.Label
  Friend WithEvents LblExam7 As System.Windows.Forms.Label
  Friend WithEvents Label55 As System.Windows.Forms.Label
  Friend WithEvents Label48 As System.Windows.Forms.Label
  Friend WithEvents LnkTablePct As System.Windows.Forms.LinkLabel
  Friend WithEvents LblGross As System.Windows.Forms.Label
  Friend WithEvents Label56 As System.Windows.Forms.Label
  Dim LoadScrn As Boolean
  Friend WithEvents LblSeq As System.Windows.Forms.Label
  Friend WithEvents Label57 As System.Windows.Forms.Label
  Friend WithEvents Label50 As System.Windows.Forms.Label
  Friend WithEvents Label58 As System.Windows.Forms.Label
  Friend WithEvents LblRE As System.Windows.Forms.Label
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents Label59 As System.Windows.Forms.Label
  Friend WithEvents TxtFrzTax As System.Windows.Forms.TextBox
  Friend WithEvents RbCivil As System.Windows.Forms.RadioButton
  Friend WithEvents LblFrzBenefit As System.Windows.Forms.Label
  Friend WithEvents Label63 As System.Windows.Forms.Label
  Friend WithEvents LblCurBenefit As System.Windows.Forms.Label
  Friend WithEvents Label60 As System.Windows.Forms.Label
  Friend WithEvents Label64 As System.Windows.Forms.Label
  Friend WithEvents TpLocal As System.Windows.Forms.TabPage
  Friend WithEvents Label75 As System.Windows.Forms.Label
  Friend WithEvents Label76 As System.Windows.Forms.Label
  Friend WithEvents LblLocSeq As System.Windows.Forms.Label
  Friend WithEvents Label62 As System.Windows.Forms.Label
  Friend WithEvents LblLocAInit As System.Windows.Forms.Label
  Friend WithEvents LblLocAFName As System.Windows.Forms.Label
  Friend WithEvents LblLocALName As System.Windows.Forms.Label
  Friend WithEvents LblLocYear As System.Windows.Forms.Label
  Friend WithEvents LblLocListNo As System.Windows.Forms.Label
  Friend WithEvents Label70 As System.Windows.Forms.Label
  Friend WithEvents Label71 As System.Windows.Forms.Label
  Friend WithEvents Label72 As System.Windows.Forms.Label
  Friend WithEvents Label73 As System.Windows.Forms.Label
  Friend WithEvents Label74 As System.Windows.Forms.Label
  Friend WithEvents DtPckLocAssr As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label77 As System.Windows.Forms.Label
  Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtLocDisallowReason As System.Windows.Forms.TextBox
  Friend WithEvents RbLocDisallowed As System.Windows.Forms.RadioButton
  Friend WithEvents RbLocAllowed As System.Windows.Forms.RadioButton
  Friend WithEvents LblLocCredit As System.Windows.Forms.Label
  Friend WithEvents Label81 As System.Windows.Forms.Label
  Friend WithEvents LblLocTotal As System.Windows.Forms.Label
  Friend WithEvents Label79 As System.Windows.Forms.Label
  Friend WithEvents LblLocPgm As System.Windows.Forms.Label
  Friend WithEvents LblLocSingle As System.Windows.Forms.Label
  Friend WithEvents LblLocMarried As System.Windows.Forms.Label
  Friend WithEvents LblHdrLocMarried As System.Windows.Forms.Label
  Friend WithEvents LblHdrLocSingle As System.Windows.Forms.Label
  Friend WithEvents LblLocPropPct As System.Windows.Forms.Label
  Friend WithEvents LblHdrStMarried As System.Windows.Forms.Label
  Friend WithEvents LblHdrStSingle As System.Windows.Forms.Label
  Friend WithEvents LblStSingle As System.Windows.Forms.Label
  Friend WithEvents LblStMarried As System.Windows.Forms.Label
  Friend WithEvents MskTxtPhone As System.Windows.Forms.MaskedTextBox
  Friend WithEvents MskTxtASSN As System.Windows.Forms.MaskedTextBox
  Friend WithEvents MskTxtSSSN As System.Windows.Forms.MaskedTextBox
  Friend WithEvents LblTRF As Label
  Friend WithEvents LblTRFHdr As Label
  Friend WithEvents GrpDefer As GroupBox
  Friend WithEvents RbDeferNone As RadioButton
  Friend WithEvents RbDeferPlanB As RadioButton
  Friend WithEvents RbDeferPlanA As RadioButton
  Friend WithEvents GroupBox9 As GroupBox
  Friend WithEvents RbLoc As RadioButton
  Friend WithEvents RbNoLoc As RadioButton
  Friend WithEvents RbLoc250 As RadioButton
  Friend WithEvents RbLoc212 As RadioButton
  Friend WithEvents LblHdrDefMarried As Label
  Friend WithEvents LblHdrDefSingle As Label
  Friend WithEvents LblDefSingle As Label
  Friend WithEvents LblDefMarried As Label
  Friend WithEvents LblLocDeferral As Label
  Friend WithEvents LblHdrLocDeferral As Label
  Friend WithEvents RbDefer25 As RadioButton
  Dim WrkExcludeGross As Integer


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
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTO201D))
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.Tab1 = New System.Windows.Forms.TabControl()
    Me.TpApplicant = New System.Windows.Forms.TabPage()
    Me.MskTxtSSSN = New System.Windows.Forms.MaskedTextBox()
    Me.MskTxtASSN = New System.Windows.Forms.MaskedTextBox()
    Me.MskTxtPhone = New System.Windows.Forms.MaskedTextBox()
    Me.LblSeq = New System.Windows.Forms.Label()
    Me.Label57 = New System.Windows.Forms.Label()
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.TxtSName = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label52 = New System.Windows.Forms.Label()
    Me.TxtRelate = New System.Windows.Forms.TextBox()
    Me.Label31 = New System.Windows.Forms.Label()
    Me.Label51 = New System.Windows.Forms.Label()
    Me.DtPckSigned = New System.Windows.Forms.DateTimePicker()
    Me.TxtOwner = New System.Windows.Forms.TextBox()
    Me.TxtSLName = New System.Windows.Forms.TextBox()
    Me.TxtALName = New System.Windows.Forms.TextBox()
    Me.TxtMZip = New System.Windows.Forms.TextBox()
    Me.TxtMState = New System.Windows.Forms.TextBox()
    Me.TxtPState = New System.Windows.Forms.TextBox()
    Me.TxtPZip = New System.Windows.Forms.TextBox()
    Me.TxtPAddr = New System.Windows.Forms.TextBox()
    Me.TxtMAddr = New System.Windows.Forms.TextBox()
    Me.TxtPCity = New System.Windows.Forms.TextBox()
    Me.TxtMCity = New System.Windows.Forms.TextBox()
    Me.ChkDisabled = New System.Windows.Forms.CheckBox()
    Me.ChkNursingHome = New System.Windows.Forms.CheckBox()
    Me.ChkTaxReturn = New System.Windows.Forms.CheckBox()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.RbCivil = New System.Windows.Forms.RadioButton()
    Me.RbSurviving = New System.Windows.Forms.RadioButton()
    Me.RbUnmarried = New System.Windows.Forms.RadioButton()
    Me.RbMarried = New System.Windows.Forms.RadioButton()
    Me.Label26 = New System.Windows.Forms.Label()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.Label25 = New System.Windows.Forms.Label()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.DtPckSDOB = New System.Windows.Forms.DateTimePicker()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.DtPckADOB = New System.Windows.Forms.DateTimePicker()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtSFName = New System.Windows.Forms.TextBox()
    Me.TxtSInit = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtAFName = New System.Windows.Forms.TextBox()
    Me.TxtAInit = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.Label55 = New System.Windows.Forms.Label()
    Me.Label48 = New System.Windows.Forms.Label()
    Me.LblTotal = New System.Windows.Forms.Label()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.TxtOther = New System.Windows.Forms.TextBox()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.TxtSSRR = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.TxtInterest = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtIncome = New System.Windows.Forms.TextBox()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.LnkListNo = New System.Windows.Forms.LinkLabel()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.TpAssessor = New System.Windows.Forms.TabPage()
    Me.Label64 = New System.Windows.Forms.Label()
    Me.LblFrzBenefit = New System.Windows.Forms.Label()
    Me.Label63 = New System.Windows.Forms.Label()
    Me.LblCurBenefit = New System.Windows.Forms.Label()
    Me.Label60 = New System.Windows.Forms.Label()
    Me.Label59 = New System.Windows.Forms.Label()
    Me.TxtFrzTax = New System.Windows.Forms.TextBox()
    Me.Label50 = New System.Windows.Forms.Label()
    Me.Label58 = New System.Windows.Forms.Label()
    Me.GroupBox7 = New System.Windows.Forms.GroupBox()
    Me.LblExcd7 = New System.Windows.Forms.Label()
    Me.LblExam7 = New System.Windows.Forms.Label()
    Me.LblExcd6 = New System.Windows.Forms.Label()
    Me.LblExam6 = New System.Windows.Forms.Label()
    Me.LblExcd5 = New System.Windows.Forms.Label()
    Me.LblExam5 = New System.Windows.Forms.Label()
    Me.LblExcd4 = New System.Windows.Forms.Label()
    Me.LblExam4 = New System.Windows.Forms.Label()
    Me.LblExcd3 = New System.Windows.Forms.Label()
    Me.LblExam3 = New System.Windows.Forms.Label()
    Me.LblExcd2 = New System.Windows.Forms.Label()
    Me.LblExam2 = New System.Windows.Forms.Label()
    Me.LblExcd1 = New System.Windows.Forms.Label()
    Me.LblExam1 = New System.Windows.Forms.Label()
    Me.DtPckAssr = New System.Windows.Forms.DateTimePicker()
    Me.Label54 = New System.Windows.Forms.Label()
    Me.DtPckReceived = New System.Windows.Forms.DateTimePicker()
    Me.Label53 = New System.Windows.Forms.Label()
    Me.LblTax = New System.Windows.Forms.Label()
    Me.LblMillRate = New System.Windows.Forms.Label()
    Me.LblAInit = New System.Windows.Forms.Label()
    Me.LblAFName = New System.Windows.Forms.Label()
    Me.LblALName = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.TxtDisallowReason = New System.Windows.Forms.TextBox()
    Me.RbDisallowed = New System.Windows.Forms.RadioButton()
    Me.RbAllowed = New System.Windows.Forms.RadioButton()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.LblRE = New System.Windows.Forms.Label()
    Me.LnkTablePct = New System.Windows.Forms.LinkLabel()
    Me.LblCreditMax = New System.Windows.Forms.Label()
    Me.LblCredit = New System.Windows.Forms.Label()
    Me.LblLesser = New System.Windows.Forms.Label()
    Me.Label44 = New System.Windows.Forms.Label()
    Me.Label45 = New System.Windows.Forms.Label()
    Me.TxtMinGrant = New System.Windows.Forms.TextBox()
    Me.Label46 = New System.Windows.Forms.Label()
    Me.Label47 = New System.Windows.Forms.Label()
    Me.TxtCeiling = New System.Windows.Forms.TextBox()
    Me.Label49 = New System.Windows.Forms.Label()
    Me.TxtTablePct = New System.Windows.Forms.TextBox()
    Me.Label43 = New System.Windows.Forms.Label()
    Me.Label42 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.LblGross = New System.Windows.Forms.Label()
    Me.Label56 = New System.Windows.Forms.Label()
    Me.LblAppGross = New System.Windows.Forms.Label()
    Me.LblNet = New System.Windows.Forms.Label()
    Me.Label41 = New System.Windows.Forms.Label()
    Me.TxtAddlVet = New System.Windows.Forms.TextBox()
    Me.Label40 = New System.Windows.Forms.Label()
    Me.TxtLocal = New System.Windows.Forms.TextBox()
    Me.Label37 = New System.Windows.Forms.Label()
    Me.Label36 = New System.Windows.Forms.Label()
    Me.Label35 = New System.Windows.Forms.Label()
    Me.TxtVet = New System.Windows.Forms.TextBox()
    Me.TxtDisabled = New System.Windows.Forms.TextBox()
    Me.TxtBlind = New System.Windows.Forms.TextBox()
    Me.Label38 = New System.Windows.Forms.Label()
    Me.Label39 = New System.Windows.Forms.Label()
    Me.Label34 = New System.Windows.Forms.Label()
    Me.TxtPGross = New System.Windows.Forms.TextBox()
    Me.Label33 = New System.Windows.Forms.Label()
    Me.TxtPropPct = New System.Windows.Forms.TextBox()
    Me.Label32 = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.Label22 = New System.Windows.Forms.Label()
    Me.Label27 = New System.Windows.Forms.Label()
    Me.Label28 = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.TpLocal = New System.Windows.Forms.TabPage()
    Me.LblLocDeferral = New System.Windows.Forms.Label()
    Me.LblHdrLocDeferral = New System.Windows.Forms.Label()
    Me.LblHdrDefMarried = New System.Windows.Forms.Label()
    Me.LblHdrDefSingle = New System.Windows.Forms.Label()
    Me.LblDefSingle = New System.Windows.Forms.Label()
    Me.LblDefMarried = New System.Windows.Forms.Label()
    Me.GrpDefer = New System.Windows.Forms.GroupBox()
    Me.RbDeferNone = New System.Windows.Forms.RadioButton()
    Me.RbDeferPlanB = New System.Windows.Forms.RadioButton()
    Me.RbDeferPlanA = New System.Windows.Forms.RadioButton()
    Me.GroupBox9 = New System.Windows.Forms.GroupBox()
    Me.RbLoc = New System.Windows.Forms.RadioButton()
    Me.RbNoLoc = New System.Windows.Forms.RadioButton()
    Me.RbLoc250 = New System.Windows.Forms.RadioButton()
    Me.RbLoc212 = New System.Windows.Forms.RadioButton()
    Me.LblTRF = New System.Windows.Forms.Label()
    Me.LblTRFHdr = New System.Windows.Forms.Label()
    Me.LblHdrStMarried = New System.Windows.Forms.Label()
    Me.LblHdrStSingle = New System.Windows.Forms.Label()
    Me.LblStSingle = New System.Windows.Forms.Label()
    Me.LblStMarried = New System.Windows.Forms.Label()
    Me.LblLocPropPct = New System.Windows.Forms.Label()
    Me.LblHdrLocMarried = New System.Windows.Forms.Label()
    Me.LblHdrLocSingle = New System.Windows.Forms.Label()
    Me.LblLocSingle = New System.Windows.Forms.Label()
    Me.LblLocMarried = New System.Windows.Forms.Label()
    Me.LblLocPgm = New System.Windows.Forms.Label()
    Me.LblLocCredit = New System.Windows.Forms.Label()
    Me.Label81 = New System.Windows.Forms.Label()
    Me.LblLocTotal = New System.Windows.Forms.Label()
    Me.Label79 = New System.Windows.Forms.Label()
    Me.DtPckLocAssr = New System.Windows.Forms.DateTimePicker()
    Me.Label77 = New System.Windows.Forms.Label()
    Me.GroupBox8 = New System.Windows.Forms.GroupBox()
    Me.TxtLocDisallowReason = New System.Windows.Forms.TextBox()
    Me.RbLocDisallowed = New System.Windows.Forms.RadioButton()
    Me.RbLocAllowed = New System.Windows.Forms.RadioButton()
    Me.Label75 = New System.Windows.Forms.Label()
    Me.Label76 = New System.Windows.Forms.Label()
    Me.LblLocSeq = New System.Windows.Forms.Label()
    Me.Label62 = New System.Windows.Forms.Label()
    Me.LblLocAInit = New System.Windows.Forms.Label()
    Me.LblLocAFName = New System.Windows.Forms.Label()
    Me.LblLocALName = New System.Windows.Forms.Label()
    Me.LblLocYear = New System.Windows.Forms.Label()
    Me.LblLocListNo = New System.Windows.Forms.Label()
    Me.Label70 = New System.Windows.Forms.Label()
    Me.Label71 = New System.Windows.Forms.Label()
    Me.Label72 = New System.Windows.Forms.Label()
    Me.Label73 = New System.Windows.Forms.Label()
    Me.Label74 = New System.Windows.Forms.Label()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.RbDefer25 = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Tab1.SuspendLayout()
    Me.TpApplicant.SuspendLayout()
    Me.GroupBox6.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.TpAssessor.SuspendLayout()
    Me.GroupBox7.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.TpLocal.SuspendLayout()
    Me.GrpDefer.SuspendLayout()
    Me.GroupBox9.SuspendLayout()
    Me.GroupBox8.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Tab1
    '
    Me.Tab1.Controls.Add(Me.TpApplicant)
    Me.Tab1.Controls.Add(Me.TpAssessor)
    Me.Tab1.Controls.Add(Me.TpLocal)
    Me.Tab1.ImageList = Me.ImageList1
    Me.Tab1.Location = New System.Drawing.Point(1, 2)
    Me.Tab1.Name = "Tab1"
    Me.Tab1.SelectedIndex = 0
    Me.Tab1.Size = New System.Drawing.Size(845, 545)
    Me.Tab1.TabIndex = 0
    '
    'TpApplicant
    '
    Me.TpApplicant.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.TpApplicant.Controls.Add(Me.MskTxtSSSN)
    Me.TpApplicant.Controls.Add(Me.MskTxtASSN)
    Me.TpApplicant.Controls.Add(Me.MskTxtPhone)
    Me.TpApplicant.Controls.Add(Me.LblSeq)
    Me.TpApplicant.Controls.Add(Me.Label57)
    Me.TpApplicant.Controls.Add(Me.GroupBox6)
    Me.TpApplicant.Controls.Add(Me.Label52)
    Me.TpApplicant.Controls.Add(Me.TxtRelate)
    Me.TpApplicant.Controls.Add(Me.Label31)
    Me.TpApplicant.Controls.Add(Me.Label51)
    Me.TpApplicant.Controls.Add(Me.DtPckSigned)
    Me.TpApplicant.Controls.Add(Me.TxtOwner)
    Me.TpApplicant.Controls.Add(Me.TxtSLName)
    Me.TpApplicant.Controls.Add(Me.TxtALName)
    Me.TpApplicant.Controls.Add(Me.TxtMZip)
    Me.TpApplicant.Controls.Add(Me.TxtMState)
    Me.TpApplicant.Controls.Add(Me.TxtPState)
    Me.TpApplicant.Controls.Add(Me.TxtPZip)
    Me.TpApplicant.Controls.Add(Me.TxtPAddr)
    Me.TpApplicant.Controls.Add(Me.TxtMAddr)
    Me.TpApplicant.Controls.Add(Me.TxtPCity)
    Me.TpApplicant.Controls.Add(Me.TxtMCity)
    Me.TpApplicant.Controls.Add(Me.ChkDisabled)
    Me.TpApplicant.Controls.Add(Me.ChkNursingHome)
    Me.TpApplicant.Controls.Add(Me.ChkTaxReturn)
    Me.TpApplicant.Controls.Add(Me.GroupBox4)
    Me.TpApplicant.Controls.Add(Me.Label26)
    Me.TpApplicant.Controls.Add(Me.Label18)
    Me.TpApplicant.Controls.Add(Me.Label23)
    Me.TpApplicant.Controls.Add(Me.Label24)
    Me.TpApplicant.Controls.Add(Me.Label25)
    Me.TpApplicant.Controls.Add(Me.Label17)
    Me.TpApplicant.Controls.Add(Me.Label16)
    Me.TpApplicant.Controls.Add(Me.Label14)
    Me.TpApplicant.Controls.Add(Me.Label12)
    Me.TpApplicant.Controls.Add(Me.Label11)
    Me.TpApplicant.Controls.Add(Me.Label10)
    Me.TpApplicant.Controls.Add(Me.Label9)
    Me.TpApplicant.Controls.Add(Me.DtPckSDOB)
    Me.TpApplicant.Controls.Add(Me.Label8)
    Me.TpApplicant.Controls.Add(Me.DtPckADOB)
    Me.TpApplicant.Controls.Add(Me.Label5)
    Me.TpApplicant.Controls.Add(Me.Label6)
    Me.TpApplicant.Controls.Add(Me.TxtSFName)
    Me.TpApplicant.Controls.Add(Me.TxtSInit)
    Me.TpApplicant.Controls.Add(Me.Label7)
    Me.TpApplicant.Controls.Add(Me.Label4)
    Me.TpApplicant.Controls.Add(Me.Label2)
    Me.TpApplicant.Controls.Add(Me.TxtAFName)
    Me.TpApplicant.Controls.Add(Me.TxtAInit)
    Me.TpApplicant.Controls.Add(Me.Label1)
    Me.TpApplicant.Controls.Add(Me.GroupBox1)
    Me.TpApplicant.Controls.Add(Me.LnkListNo)
    Me.TpApplicant.Controls.Add(Me.TxtYear)
    Me.TpApplicant.Controls.Add(Me.Label13)
    Me.TpApplicant.Controls.Add(Me.TxtListNo)
    Me.TpApplicant.ImageIndex = 0
    Me.TpApplicant.Location = New System.Drawing.Point(4, 23)
    Me.TpApplicant.Name = "TpApplicant"
    Me.TpApplicant.Padding = New System.Windows.Forms.Padding(3)
    Me.TpApplicant.Size = New System.Drawing.Size(837, 518)
    Me.TpApplicant.TabIndex = 0
    Me.TpApplicant.Text = "Applicant Information"
    Me.TpApplicant.UseVisualStyleBackColor = True
    '
    'MskTxtSSSN
    '
    Me.MskTxtSSSN.Location = New System.Drawing.Point(536, 112)
    Me.MskTxtSSSN.Mask = "000-00-0000"
    Me.MskTxtSSSN.Name = "MskTxtSSSN"
    Me.MskTxtSSSN.Size = New System.Drawing.Size(71, 20)
    Me.MskTxtSSSN.TabIndex = 125
    Me.MskTxtSSSN.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'MskTxtASSN
    '
    Me.MskTxtASSN.Location = New System.Drawing.Point(536, 69)
    Me.MskTxtASSN.Mask = "000-00-0000"
    Me.MskTxtASSN.Name = "MskTxtASSN"
    Me.MskTxtASSN.Size = New System.Drawing.Size(71, 20)
    Me.MskTxtASSN.TabIndex = 120
    Me.MskTxtASSN.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'MskTxtPhone
    '
    Me.MskTxtPhone.Location = New System.Drawing.Point(124, 473)
    Me.MskTxtPhone.Mask = "(999) 000-0000"
    Me.MskTxtPhone.Name = "MskTxtPhone"
    Me.MskTxtPhone.Size = New System.Drawing.Size(81, 20)
    Me.MskTxtPhone.TabIndex = 162
    Me.MskTxtPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'LblSeq
    '
    Me.LblSeq.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblSeq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblSeq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblSeq.Location = New System.Drawing.Point(303, 22)
    Me.LblSeq.Name = "LblSeq"
    Me.LblSeq.Size = New System.Drawing.Size(24, 18)
    Me.LblSeq.TabIndex = 172
    Me.LblSeq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label57
    '
    Me.Label57.Location = New System.Drawing.Point(246, 23)
    Me.Label57.Name = "Label57"
    Me.Label57.Size = New System.Drawing.Size(51, 17)
    Me.Label57.TabIndex = 173
    Me.Label57.Text = "Seq No"
    '
    'GroupBox6
    '
    Me.GroupBox6.Controls.Add(Me.TxtSName)
    Me.GroupBox6.Controls.Add(Me.TxtName)
    Me.GroupBox6.Location = New System.Drawing.Point(352, 3)
    Me.GroupBox6.Name = "GroupBox6"
    Me.GroupBox6.Size = New System.Drawing.Size(241, 47)
    Me.GroupBox6.TabIndex = 171
    Me.GroupBox6.TabStop = False
    Me.GroupBox6.Text = "Copy && Paste as needed"
    '
    'TxtSName
    '
    Me.TxtSName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TxtSName.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TxtSName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSName.ForeColor = System.Drawing.Color.Navy
    Me.TxtSName.Location = New System.Drawing.Point(6, 30)
    Me.TxtSName.MaxLength = 20
    Me.TxtSName.Name = "TxtSName"
    Me.TxtSName.ReadOnly = True
    Me.TxtSName.Size = New System.Drawing.Size(228, 13)
    Me.TxtSName.TabIndex = 172
    Me.TxtSName.TabStop = False
    '
    'TxtName
    '
    Me.TxtName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TxtName.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.ForeColor = System.Drawing.Color.Navy
    Me.TxtName.Location = New System.Drawing.Point(6, 16)
    Me.TxtName.MaxLength = 20
    Me.TxtName.Name = "TxtName"
    Me.TxtName.ReadOnly = True
    Me.TxtName.Size = New System.Drawing.Size(228, 13)
    Me.TxtName.TabIndex = 171
    Me.TxtName.TabStop = False
    '
    'Label52
    '
    Me.Label52.Location = New System.Drawing.Point(226, 454)
    Me.Label52.Name = "Label52"
    Me.Label52.Size = New System.Drawing.Size(101, 15)
    Me.Label52.TabIndex = 166
    Me.Label52.Text = "Agent Relationship"
    Me.Label52.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'TxtRelate
    '
    Me.TxtRelate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRelate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRelate.Location = New System.Drawing.Point(229, 472)
    Me.TxtRelate.MaxLength = 20
    Me.TxtRelate.Name = "TxtRelate"
    Me.TxtRelate.Size = New System.Drawing.Size(151, 20)
    Me.TxtRelate.TabIndex = 165
    '
    'Label31
    '
    Me.Label31.Location = New System.Drawing.Point(121, 454)
    Me.Label31.Name = "Label31"
    Me.Label31.Size = New System.Drawing.Size(74, 16)
    Me.Label31.TabIndex = 164
    Me.Label31.Text = "Phone No"
    Me.Label31.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label51
    '
    Me.Label51.Location = New System.Drawing.Point(8, 454)
    Me.Label51.Name = "Label51"
    Me.Label51.Size = New System.Drawing.Size(80, 16)
    Me.Label51.TabIndex = 163
    Me.Label51.Text = "Date Signed"
    Me.Label51.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'DtPckSigned
    '
    Me.DtPckSigned.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckSigned.Location = New System.Drawing.Point(11, 472)
    Me.DtPckSigned.Name = "DtPckSigned"
    Me.DtPckSigned.Size = New System.Drawing.Size(88, 20)
    Me.DtPckSigned.TabIndex = 161
    '
    'TxtOwner
    '
    Me.TxtOwner.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOwner.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOwner.Location = New System.Drawing.Point(632, 190)
    Me.TxtOwner.MaxLength = 35
    Me.TxtOwner.Name = "TxtOwner"
    Me.TxtOwner.Size = New System.Drawing.Size(191, 20)
    Me.TxtOwner.TabIndex = 134
    '
    'TxtSLName
    '
    Me.TxtSLName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSLName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSLName.Location = New System.Drawing.Point(11, 112)
    Me.TxtSLName.MaxLength = 20
    Me.TxtSLName.Name = "TxtSLName"
    Me.TxtSLName.Size = New System.Drawing.Size(228, 20)
    Me.TxtSLName.TabIndex = 121
    '
    'TxtALName
    '
    Me.TxtALName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtALName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtALName.Location = New System.Drawing.Point(11, 69)
    Me.TxtALName.MaxLength = 20
    Me.TxtALName.Name = "TxtALName"
    Me.TxtALName.Size = New System.Drawing.Size(228, 20)
    Me.TxtALName.TabIndex = 116
    '
    'TxtMZip
    '
    Me.TxtMZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMZip.Location = New System.Drawing.Point(572, 151)
    Me.TxtMZip.MaxLength = 5
    Me.TxtMZip.Name = "TxtMZip"
    Me.TxtMZip.Size = New System.Drawing.Size(40, 20)
    Me.TxtMZip.TabIndex = 129
    '
    'TxtMState
    '
    Me.TxtMState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMState.Location = New System.Drawing.Point(542, 151)
    Me.TxtMState.MaxLength = 2
    Me.TxtMState.Name = "TxtMState"
    Me.TxtMState.Size = New System.Drawing.Size(24, 20)
    Me.TxtMState.TabIndex = 128
    '
    'TxtPState
    '
    Me.TxtPState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPState.Location = New System.Drawing.Point(542, 190)
    Me.TxtPState.MaxLength = 2
    Me.TxtPState.Name = "TxtPState"
    Me.TxtPState.Size = New System.Drawing.Size(24, 20)
    Me.TxtPState.TabIndex = 132
    '
    'TxtPZip
    '
    Me.TxtPZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPZip.Location = New System.Drawing.Point(572, 190)
    Me.TxtPZip.MaxLength = 5
    Me.TxtPZip.Name = "TxtPZip"
    Me.TxtPZip.Size = New System.Drawing.Size(40, 20)
    Me.TxtPZip.TabIndex = 133
    '
    'TxtPAddr
    '
    Me.TxtPAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPAddr.Location = New System.Drawing.Point(11, 190)
    Me.TxtPAddr.MaxLength = 40
    Me.TxtPAddr.Name = "TxtPAddr"
    Me.TxtPAddr.Size = New System.Drawing.Size(325, 20)
    Me.TxtPAddr.TabIndex = 130
    '
    'TxtMAddr
    '
    Me.TxtMAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMAddr.Location = New System.Drawing.Point(11, 151)
    Me.TxtMAddr.MaxLength = 40
    Me.TxtMAddr.Name = "TxtMAddr"
    Me.TxtMAddr.Size = New System.Drawing.Size(325, 20)
    Me.TxtMAddr.TabIndex = 126
    '
    'TxtPCity
    '
    Me.TxtPCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPCity.Location = New System.Drawing.Point(342, 190)
    Me.TxtPCity.MaxLength = 25
    Me.TxtPCity.Name = "TxtPCity"
    Me.TxtPCity.Size = New System.Drawing.Size(191, 20)
    Me.TxtPCity.TabIndex = 131
    '
    'TxtMCity
    '
    Me.TxtMCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMCity.Location = New System.Drawing.Point(342, 151)
    Me.TxtMCity.MaxLength = 25
    Me.TxtMCity.Name = "TxtMCity"
    Me.TxtMCity.Size = New System.Drawing.Size(191, 20)
    Me.TxtMCity.TabIndex = 127
    '
    'ChkDisabled
    '
    Me.ChkDisabled.AutoSize = True
    Me.ChkDisabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkDisabled.Location = New System.Drawing.Point(482, 257)
    Me.ChkDisabled.Name = "ChkDisabled"
    Me.ChkDisabled.Size = New System.Drawing.Size(158, 17)
    Me.ChkDisabled.TabIndex = 137
    Me.ChkDisabled.Text = "Is applicant totally disabled?"
    Me.ChkDisabled.UseVisualStyleBackColor = True
    '
    'ChkNursingHome
    '
    Me.ChkNursingHome.AutoSize = True
    Me.ChkNursingHome.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkNursingHome.Location = New System.Drawing.Point(11, 257)
    Me.ChkNursingHome.Name = "ChkNursingHome"
    Me.ChkNursingHome.Size = New System.Drawing.Size(429, 17)
    Me.ChkNursingHome.TabIndex = 136
    Me.ChkNursingHome.Text = "Is spouse a resident of a health care or a nursing home facility in CT and on Tit" &
    "le XIX?"
    Me.ChkNursingHome.UseVisualStyleBackColor = True
    '
    'ChkTaxReturn
    '
    Me.ChkTaxReturn.AutoSize = True
    Me.ChkTaxReturn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkTaxReturn.Location = New System.Drawing.Point(11, 277)
    Me.ChkTaxReturn.Name = "ChkTaxReturn"
    Me.ChkTaxReturn.Size = New System.Drawing.Size(258, 17)
    Me.ChkTaxReturn.TabIndex = 138
    Me.ChkTaxReturn.Text = "6. Filed a Federal Tax Return for Grand List year?"
    Me.ChkTaxReturn.UseVisualStyleBackColor = True
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.RbCivil)
    Me.GroupBox4.Controls.Add(Me.RbSurviving)
    Me.GroupBox4.Controls.Add(Me.RbUnmarried)
    Me.GroupBox4.Controls.Add(Me.RbMarried)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(8, 216)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(544, 38)
    Me.GroupBox4.TabIndex = 135
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "5. Filing Status"
    '
    'RbCivil
    '
    Me.RbCivil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCivil.Location = New System.Drawing.Point(170, 16)
    Me.RbCivil.Name = "RbCivil"
    Me.RbCivil.Size = New System.Drawing.Size(91, 18)
    Me.RbCivil.TabIndex = 3
    Me.RbCivil.Text = "Civil Union"
    '
    'RbSurviving
    '
    Me.RbSurviving.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSurviving.Location = New System.Drawing.Point(267, 14)
    Me.RbSurviving.Name = "RbSurviving"
    Me.RbSurviving.Size = New System.Drawing.Size(271, 18)
    Me.RbSurviving.TabIndex = 2
    Me.RbSurviving.Text = "Surviving Spouse (Age 50 to 65) Proof Required"
    '
    'RbUnmarried
    '
    Me.RbUnmarried.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbUnmarried.Location = New System.Drawing.Point(82, 16)
    Me.RbUnmarried.Name = "RbUnmarried"
    Me.RbUnmarried.Size = New System.Drawing.Size(82, 18)
    Me.RbUnmarried.TabIndex = 1
    Me.RbUnmarried.Text = "Unmarried"
    '
    'RbMarried
    '
    Me.RbMarried.Checked = True
    Me.RbMarried.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbMarried.Location = New System.Drawing.Point(8, 16)
    Me.RbMarried.Name = "RbMarried"
    Me.RbMarried.Size = New System.Drawing.Size(68, 18)
    Me.RbMarried.TabIndex = 0
    Me.RbMarried.TabStop = True
    Me.RbMarried.Text = "Married"
    '
    'Label26
    '
    Me.Label26.AutoSize = True
    Me.Label26.Location = New System.Drawing.Point(629, 174)
    Me.Label26.Name = "Label26"
    Me.Label26.Size = New System.Drawing.Size(160, 13)
    Me.Label26.TabIndex = 160
    Me.Label26.Text = "Other Name on property (Owner)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
    '
    'Label18
    '
    Me.Label18.AutoSize = True
    Me.Label18.Location = New System.Drawing.Point(577, 174)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(25, 13)
    Me.Label18.TabIndex = 159
    Me.Label18.Text = "Zip "
    '
    'Label23
    '
    Me.Label23.AutoSize = True
    Me.Label23.Location = New System.Drawing.Point(539, 174)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(32, 13)
    Me.Label23.TabIndex = 158
    Me.Label23.Text = "State"
    '
    'Label24
    '
    Me.Label24.AutoSize = True
    Me.Label24.Location = New System.Drawing.Point(339, 174)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(66, 13)
    Me.Label24.TabIndex = 157
    Me.Label24.Text = "City or Town"
    '
    'Label25
    '
    Me.Label25.AutoSize = True
    Me.Label25.Location = New System.Drawing.Point(8, 174)
    Me.Label25.Name = "Label25"
    Me.Label25.Size = New System.Drawing.Size(176, 13)
    Me.Label25.TabIndex = 156
    Me.Label25.Text = "4. Property Address (only if different)"
    '
    'Label17
    '
    Me.Label17.AutoSize = True
    Me.Label17.Location = New System.Drawing.Point(577, 135)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(25, 13)
    Me.Label17.TabIndex = 155
    Me.Label17.Text = "Zip "
    '
    'Label16
    '
    Me.Label16.AutoSize = True
    Me.Label16.Location = New System.Drawing.Point(539, 135)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(32, 13)
    Me.Label16.TabIndex = 154
    Me.Label16.Text = "State"
    '
    'Label14
    '
    Me.Label14.AutoSize = True
    Me.Label14.Location = New System.Drawing.Point(339, 135)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(66, 13)
    Me.Label14.TabIndex = 153
    Me.Label14.Text = "City or Town"
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(8, 135)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(93, 13)
    Me.Label12.TabIndex = 152
    Me.Label12.Text = "3. Mailing Address"
    '
    'Label11
    '
    Me.Label11.Location = New System.Drawing.Point(524, 95)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(101, 16)
    Me.Label11.TabIndex = 151
    Me.Label11.Text = "Social Security No"
    Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(524, 50)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(101, 16)
    Me.Label10.TabIndex = 150
    Me.Label10.Text = "Social Security No"
    Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(422, 93)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(80, 16)
    Me.Label9.TabIndex = 149
    Me.Label9.Text = "Birth Date"
    Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'DtPckSDOB
    '
    Me.DtPckSDOB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckSDOB.Location = New System.Drawing.Point(425, 112)
    Me.DtPckSDOB.Name = "DtPckSDOB"
    Me.DtPckSDOB.Size = New System.Drawing.Size(88, 20)
    Me.DtPckSDOB.TabIndex = 124
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(422, 50)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(80, 16)
    Me.Label8.TabIndex = 148
    Me.Label8.Text = "Birth Date"
    Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'DtPckADOB
    '
    Me.DtPckADOB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckADOB.Location = New System.Drawing.Point(425, 68)
    Me.DtPckADOB.Name = "DtPckADOB"
    Me.DtPckADOB.Size = New System.Drawing.Size(88, 20)
    Me.DtPckADOB.TabIndex = 119
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(349, 93)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(44, 13)
    Me.Label5.TabIndex = 147
    Me.Label5.Text = "(Middle)"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(244, 93)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(32, 13)
    Me.Label6.TabIndex = 146
    Me.Label6.Text = "(First)"
    '
    'TxtSFName
    '
    Me.TxtSFName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSFName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSFName.Location = New System.Drawing.Point(245, 112)
    Me.TxtSFName.MaxLength = 10
    Me.TxtSFName.Name = "TxtSFName"
    Me.TxtSFName.Size = New System.Drawing.Size(114, 20)
    Me.TxtSFName.TabIndex = 122
    '
    'TxtSInit
    '
    Me.TxtSInit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSInit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSInit.Location = New System.Drawing.Point(365, 112)
    Me.TxtSInit.MaxLength = 35
    Me.TxtSInit.Name = "TxtSInit"
    Me.TxtSInit.Size = New System.Drawing.Size(17, 20)
    Me.TxtSInit.TabIndex = 123
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(8, 96)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(122, 13)
    Me.Label7.TabIndex = 145
    Me.Label7.Text = "2. Spouse's Name (Last)"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(349, 50)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(44, 13)
    Me.Label4.TabIndex = 144
    Me.Label4.Text = "(Middle)"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(244, 50)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(32, 13)
    Me.Label2.TabIndex = 143
    Me.Label2.Text = "(First)"
    '
    'TxtAFName
    '
    Me.TxtAFName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAFName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAFName.Location = New System.Drawing.Point(245, 69)
    Me.TxtAFName.MaxLength = 10
    Me.TxtAFName.Name = "TxtAFName"
    Me.TxtAFName.Size = New System.Drawing.Size(114, 20)
    Me.TxtAFName.TabIndex = 117
    '
    'TxtAInit
    '
    Me.TxtAInit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAInit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAInit.Location = New System.Drawing.Point(365, 69)
    Me.TxtAInit.MaxLength = 35
    Me.TxtAInit.Name = "TxtAInit"
    Me.TxtAInit.Size = New System.Drawing.Size(17, 20)
    Me.TxtAInit.TabIndex = 118
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(8, 53)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(76, 13)
    Me.Label1.TabIndex = 142
    Me.Label1.Text = "1. Name (Last)"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.Label55)
    Me.GroupBox1.Controls.Add(Me.Label48)
    Me.GroupBox1.Controls.Add(Me.LblTotal)
    Me.GroupBox1.Controls.Add(Me.Label21)
    Me.GroupBox1.Controls.Add(Me.TxtOther)
    Me.GroupBox1.Controls.Add(Me.Label20)
    Me.GroupBox1.Controls.Add(Me.TxtSSRR)
    Me.GroupBox1.Controls.Add(Me.Label15)
    Me.GroupBox1.Controls.Add(Me.TxtInterest)
    Me.GroupBox1.Controls.Add(Me.Label3)
    Me.GroupBox1.Controls.Add(Me.TxtIncome)
    Me.GroupBox1.Controls.Add(Me.Label19)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(6, 300)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(817, 151)
    Me.GroupBox1.TabIndex = 139
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "7. Income Received during last calendar year"
    '
    'Label55
    '
    Me.Label55.AutoSize = True
    Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label55.Location = New System.Drawing.Point(17, 123)
    Me.Label55.Name = "Label55"
    Me.Label55.Size = New System.Drawing.Size(286, 13)
    Me.Label55.TabIndex = 54
    Me.Label55.Text = "Disability Payments, and any other income not listed above."
    '
    'Label48
    '
    Me.Label48.AutoSize = True
    Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label48.Location = New System.Drawing.Point(17, 109)
    Me.Label48.Name = "Label48"
    Me.Label48.Size = New System.Drawing.Size(479, 13)
    Me.Label48.TabIndex = 53
    Me.Label48.Text = "State of Connecticut public assistance payments, General Assistance, Veteran's Pe" &
    "nsions, Veteran's"
    '
    'LblTotal
    '
    Me.LblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotal.Location = New System.Drawing.Point(745, 120)
    Me.LblTotal.Name = "LblTotal"
    Me.LblTotal.Size = New System.Drawing.Size(64, 18)
    Me.LblTotal.TabIndex = 52
    Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label21
    '
    Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label21.Location = New System.Drawing.Point(658, 122)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(81, 20)
    Me.Label21.TabIndex = 50
    Me.Label21.Text = "E: TOTAL "
    Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'TxtOther
    '
    Me.TxtOther.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOther.Location = New System.Drawing.Point(745, 93)
    Me.TxtOther.MaxLength = 11
    Me.TxtOther.Name = "TxtOther"
    Me.TxtOther.Size = New System.Drawing.Size(66, 20)
    Me.TxtOther.TabIndex = 48
    Me.TxtOther.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label20
    '
    Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label20.Location = New System.Drawing.Point(6, 93)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(676, 20)
    Me.Label20.TabIndex = 49
    Me.Label20.Text = "D: ANY INCOME NOT REFLECTED IN THE ABOVE - Examples: Federal Supplemental Securit" &
    "y Income,"
    '
    'TxtSSRR
    '
    Me.TxtSSRR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSSRR.Location = New System.Drawing.Point(745, 70)
    Me.TxtSSRR.MaxLength = 11
    Me.TxtSSRR.Name = "TxtSSRR"
    Me.TxtSSRR.Size = New System.Drawing.Size(66, 20)
    Me.TxtSSRR.TabIndex = 46
    Me.TxtSSRR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label15
    '
    Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label15.Location = New System.Drawing.Point(7, 70)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(676, 20)
    Me.Label15.TabIndex = 47
    Me.Label15.Text = "C: SOCIAL SECURITY OR RAILROAD RETIREMENT INCOME - Add Medicare premiums (Attach " &
    "SSA 1099)"
    '
    'TxtInterest
    '
    Me.TxtInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtInterest.Location = New System.Drawing.Point(745, 47)
    Me.TxtInterest.MaxLength = 11
    Me.TxtInterest.Name = "TxtInterest"
    Me.TxtInterest.Size = New System.Drawing.Size(66, 20)
    Me.TxtInterest.TabIndex = 44
    Me.TxtInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(6, 47)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(676, 20)
    Me.Label3.TabIndex = 45
    Me.Label3.Text = "B: NON-TAXABLE INTEREST - Example: Interest from Tax Exempt Government Bonds"
    '
    'TxtIncome
    '
    Me.TxtIncome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtIncome.Location = New System.Drawing.Point(745, 21)
    Me.TxtIncome.MaxLength = 11
    Me.TxtIncome.Name = "TxtIncome"
    Me.TxtIncome.Size = New System.Drawing.Size(66, 20)
    Me.TxtIncome.TabIndex = 0
    Me.TxtIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label19
    '
    Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label19.Location = New System.Drawing.Point(7, 21)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(725, 20)
    Me.Label19.TabIndex = 43
    Me.Label19.Text = "A. GROSS INCOME Includes Federal Gross Income, wages, lottery winnings, taxable p" &
    "ensions, IRA, interest, dividends and rental income"
    '
    'LnkListNo
    '
    Me.LnkListNo.Location = New System.Drawing.Point(12, 20)
    Me.LnkListNo.Name = "LnkListNo"
    Me.LnkListNo.Size = New System.Drawing.Size(48, 16)
    Me.LnkListNo.TabIndex = 141
    Me.LnkListNo.TabStop = True
    Me.LnkListNo.Text = "List No"
    '
    'TxtYear
    '
    Me.TxtYear.Location = New System.Drawing.Point(192, 20)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtYear.TabIndex = 1
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(151, 20)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(35, 17)
    Me.Label13.TabIndex = 140
    Me.Label13.Text = "Year"
    '
    'TxtListNo
    '
    Me.TxtListNo.Location = New System.Drawing.Point(66, 20)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(64, 20)
    Me.TxtListNo.TabIndex = 0
    '
    'TpAssessor
    '
    Me.TpAssessor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.TpAssessor.Controls.Add(Me.Label64)
    Me.TpAssessor.Controls.Add(Me.LblFrzBenefit)
    Me.TpAssessor.Controls.Add(Me.Label63)
    Me.TpAssessor.Controls.Add(Me.LblCurBenefit)
    Me.TpAssessor.Controls.Add(Me.Label60)
    Me.TpAssessor.Controls.Add(Me.Label59)
    Me.TpAssessor.Controls.Add(Me.TxtFrzTax)
    Me.TpAssessor.Controls.Add(Me.Label50)
    Me.TpAssessor.Controls.Add(Me.Label58)
    Me.TpAssessor.Controls.Add(Me.GroupBox7)
    Me.TpAssessor.Controls.Add(Me.DtPckAssr)
    Me.TpAssessor.Controls.Add(Me.Label54)
    Me.TpAssessor.Controls.Add(Me.DtPckReceived)
    Me.TpAssessor.Controls.Add(Me.Label53)
    Me.TpAssessor.Controls.Add(Me.LblTax)
    Me.TpAssessor.Controls.Add(Me.LblMillRate)
    Me.TpAssessor.Controls.Add(Me.LblAInit)
    Me.TpAssessor.Controls.Add(Me.LblAFName)
    Me.TpAssessor.Controls.Add(Me.LblALName)
    Me.TpAssessor.Controls.Add(Me.LblYear)
    Me.TpAssessor.Controls.Add(Me.LblListNo)
    Me.TpAssessor.Controls.Add(Me.GroupBox5)
    Me.TpAssessor.Controls.Add(Me.GroupBox3)
    Me.TpAssessor.Controls.Add(Me.Label43)
    Me.TpAssessor.Controls.Add(Me.Label42)
    Me.TpAssessor.Controls.Add(Me.GroupBox2)
    Me.TpAssessor.Controls.Add(Me.Label34)
    Me.TpAssessor.Controls.Add(Me.TxtPGross)
    Me.TpAssessor.Controls.Add(Me.Label33)
    Me.TpAssessor.Controls.Add(Me.TxtPropPct)
    Me.TpAssessor.Controls.Add(Me.Label32)
    Me.TpAssessor.Controls.Add(Me.Label30)
    Me.TpAssessor.Controls.Add(Me.Label22)
    Me.TpAssessor.Controls.Add(Me.Label27)
    Me.TpAssessor.Controls.Add(Me.Label28)
    Me.TpAssessor.Controls.Add(Me.Label29)
    Me.TpAssessor.ImageIndex = 0
    Me.TpAssessor.Location = New System.Drawing.Point(4, 23)
    Me.TpAssessor.Name = "TpAssessor"
    Me.TpAssessor.Padding = New System.Windows.Forms.Padding(3)
    Me.TpAssessor.Size = New System.Drawing.Size(837, 518)
    Me.TpAssessor.TabIndex = 1
    Me.TpAssessor.Text = "Assessor "
    Me.TpAssessor.UseVisualStyleBackColor = True
    '
    'Label64
    '
    Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label64.Location = New System.Drawing.Point(415, 316)
    Me.Label64.Name = "Label64"
    Me.Label64.Size = New System.Drawing.Size(324, 16)
    Me.Label64.TabIndex = 203
    Me.Label64.Text = "* Save will write Credit Amount to Current & Frozen RE files"
    Me.Label64.UseMnemonic = False
    '
    'LblFrzBenefit
    '
    Me.LblFrzBenefit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblFrzBenefit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblFrzBenefit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFrzBenefit.Location = New System.Drawing.Point(745, 286)
    Me.LblFrzBenefit.Name = "LblFrzBenefit"
    Me.LblFrzBenefit.Size = New System.Drawing.Size(66, 18)
    Me.LblFrzBenefit.TabIndex = 202
    Me.LblFrzBenefit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label63
    '
    Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label63.Location = New System.Drawing.Point(672, 288)
    Me.Label63.Name = "Label63"
    Me.Label63.Size = New System.Drawing.Size(67, 16)
    Me.Label63.TabIndex = 201
    Me.Label63.Text = "Frozen File"
    '
    'LblCurBenefit
    '
    Me.LblCurBenefit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCurBenefit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCurBenefit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCurBenefit.Location = New System.Drawing.Point(745, 264)
    Me.LblCurBenefit.Name = "LblCurBenefit"
    Me.LblCurBenefit.Size = New System.Drawing.Size(66, 18)
    Me.LblCurBenefit.TabIndex = 200
    Me.LblCurBenefit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label60
    '
    Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label60.Location = New System.Drawing.Point(672, 266)
    Me.Label60.Name = "Label60"
    Me.Label60.Size = New System.Drawing.Size(67, 15)
    Me.Label60.TabIndex = 199
    Me.Label60.Text = "Current File"
    '
    'Label59
    '
    Me.Label59.Location = New System.Drawing.Point(226, 326)
    Me.Label59.Name = "Label59"
    Me.Label59.Size = New System.Drawing.Size(94, 17)
    Me.Label59.TabIndex = 198
    Me.Label59.Text = "13a. Frozen Tax"
    '
    'TxtFrzTax
    '
    Me.TxtFrzTax.Location = New System.Drawing.Point(229, 348)
    Me.TxtFrzTax.MaxLength = 9
    Me.TxtFrzTax.Name = "TxtFrzTax"
    Me.TxtFrzTax.Size = New System.Drawing.Size(77, 20)
    Me.TxtFrzTax.TabIndex = 55
    Me.TxtFrzTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label50
    '
    Me.Label50.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label50.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label50.Location = New System.Drawing.Point(302, 24)
    Me.Label50.Name = "Label50"
    Me.Label50.Size = New System.Drawing.Size(24, 18)
    Me.Label50.TabIndex = 195
    Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label58
    '
    Me.Label58.Location = New System.Drawing.Point(245, 25)
    Me.Label58.Name = "Label58"
    Me.Label58.Size = New System.Drawing.Size(51, 17)
    Me.Label58.TabIndex = 196
    Me.Label58.Text = "Seq No"
    '
    'GroupBox7
    '
    Me.GroupBox7.Controls.Add(Me.LblExcd7)
    Me.GroupBox7.Controls.Add(Me.LblExam7)
    Me.GroupBox7.Controls.Add(Me.LblExcd6)
    Me.GroupBox7.Controls.Add(Me.LblExam6)
    Me.GroupBox7.Controls.Add(Me.LblExcd5)
    Me.GroupBox7.Controls.Add(Me.LblExam5)
    Me.GroupBox7.Controls.Add(Me.LblExcd4)
    Me.GroupBox7.Controls.Add(Me.LblExam4)
    Me.GroupBox7.Controls.Add(Me.LblExcd3)
    Me.GroupBox7.Controls.Add(Me.LblExam3)
    Me.GroupBox7.Controls.Add(Me.LblExcd2)
    Me.GroupBox7.Controls.Add(Me.LblExam2)
    Me.GroupBox7.Controls.Add(Me.LblExcd1)
    Me.GroupBox7.Controls.Add(Me.LblExam1)
    Me.GroupBox7.Location = New System.Drawing.Point(10, 167)
    Me.GroupBox7.Name = "GroupBox7"
    Me.GroupBox7.Size = New System.Drawing.Size(122, 146)
    Me.GroupBox7.TabIndex = 194
    Me.GroupBox7.TabStop = False
    Me.GroupBox7.Text = "RE Exemption Info"
    '
    'LblExcd7
    '
    Me.LblExcd7.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExcd7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExcd7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExcd7.Location = New System.Drawing.Point(6, 124)
    Me.LblExcd7.Name = "LblExcd7"
    Me.LblExcd7.Size = New System.Drawing.Size(35, 18)
    Me.LblExcd7.TabIndex = 207
    Me.LblExcd7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExam7
    '
    Me.LblExam7.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExam7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExam7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExam7.Location = New System.Drawing.Point(47, 124)
    Me.LblExam7.Name = "LblExam7"
    Me.LblExam7.Size = New System.Drawing.Size(66, 18)
    Me.LblExam7.TabIndex = 206
    Me.LblExam7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExcd6
    '
    Me.LblExcd6.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExcd6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExcd6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExcd6.Location = New System.Drawing.Point(6, 106)
    Me.LblExcd6.Name = "LblExcd6"
    Me.LblExcd6.Size = New System.Drawing.Size(35, 18)
    Me.LblExcd6.TabIndex = 205
    Me.LblExcd6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExam6
    '
    Me.LblExam6.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExam6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExam6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExam6.Location = New System.Drawing.Point(47, 106)
    Me.LblExam6.Name = "LblExam6"
    Me.LblExam6.Size = New System.Drawing.Size(66, 18)
    Me.LblExam6.TabIndex = 204
    Me.LblExam6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExcd5
    '
    Me.LblExcd5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExcd5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExcd5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExcd5.Location = New System.Drawing.Point(6, 88)
    Me.LblExcd5.Name = "LblExcd5"
    Me.LblExcd5.Size = New System.Drawing.Size(35, 18)
    Me.LblExcd5.TabIndex = 203
    Me.LblExcd5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExam5
    '
    Me.LblExam5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExam5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExam5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExam5.Location = New System.Drawing.Point(47, 88)
    Me.LblExam5.Name = "LblExam5"
    Me.LblExam5.Size = New System.Drawing.Size(66, 18)
    Me.LblExam5.TabIndex = 202
    Me.LblExam5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExcd4
    '
    Me.LblExcd4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExcd4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExcd4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExcd4.Location = New System.Drawing.Point(6, 70)
    Me.LblExcd4.Name = "LblExcd4"
    Me.LblExcd4.Size = New System.Drawing.Size(35, 18)
    Me.LblExcd4.TabIndex = 201
    Me.LblExcd4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExam4
    '
    Me.LblExam4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExam4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExam4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExam4.Location = New System.Drawing.Point(47, 70)
    Me.LblExam4.Name = "LblExam4"
    Me.LblExam4.Size = New System.Drawing.Size(66, 18)
    Me.LblExam4.TabIndex = 200
    Me.LblExam4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExcd3
    '
    Me.LblExcd3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExcd3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExcd3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExcd3.Location = New System.Drawing.Point(6, 52)
    Me.LblExcd3.Name = "LblExcd3"
    Me.LblExcd3.Size = New System.Drawing.Size(35, 18)
    Me.LblExcd3.TabIndex = 199
    Me.LblExcd3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExam3
    '
    Me.LblExam3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExam3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExam3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExam3.Location = New System.Drawing.Point(47, 52)
    Me.LblExam3.Name = "LblExam3"
    Me.LblExam3.Size = New System.Drawing.Size(66, 18)
    Me.LblExam3.TabIndex = 198
    Me.LblExam3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExcd2
    '
    Me.LblExcd2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExcd2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExcd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExcd2.Location = New System.Drawing.Point(6, 34)
    Me.LblExcd2.Name = "LblExcd2"
    Me.LblExcd2.Size = New System.Drawing.Size(35, 18)
    Me.LblExcd2.TabIndex = 197
    Me.LblExcd2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExam2
    '
    Me.LblExam2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExam2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExam2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExam2.Location = New System.Drawing.Point(47, 34)
    Me.LblExam2.Name = "LblExam2"
    Me.LblExam2.Size = New System.Drawing.Size(66, 18)
    Me.LblExam2.TabIndex = 196
    Me.LblExam2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExcd1
    '
    Me.LblExcd1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExcd1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExcd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExcd1.Location = New System.Drawing.Point(6, 16)
    Me.LblExcd1.Name = "LblExcd1"
    Me.LblExcd1.Size = New System.Drawing.Size(35, 18)
    Me.LblExcd1.TabIndex = 195
    Me.LblExcd1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblExam1
    '
    Me.LblExam1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExam1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExam1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExam1.Location = New System.Drawing.Point(47, 16)
    Me.LblExam1.Name = "LblExam1"
    Me.LblExam1.Size = New System.Drawing.Size(66, 18)
    Me.LblExam1.TabIndex = 194
    Me.LblExam1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'DtPckAssr
    '
    Me.DtPckAssr.Checked = False
    Me.DtPckAssr.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckAssr.Location = New System.Drawing.Point(154, 460)
    Me.DtPckAssr.Name = "DtPckAssr"
    Me.DtPckAssr.ShowCheckBox = True
    Me.DtPckAssr.Size = New System.Drawing.Size(100, 20)
    Me.DtPckAssr.TabIndex = 181
    '
    'Label54
    '
    Me.Label54.Location = New System.Drawing.Point(24, 464)
    Me.Label54.Name = "Label54"
    Me.Label54.Size = New System.Drawing.Size(124, 16)
    Me.Label54.TabIndex = 180
    Me.Label54.Text = "Date Assessor Signed"
    '
    'DtPckReceived
    '
    Me.DtPckReceived.Checked = False
    Me.DtPckReceived.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckReceived.Location = New System.Drawing.Point(32, 75)
    Me.DtPckReceived.Name = "DtPckReceived"
    Me.DtPckReceived.ShowCheckBox = True
    Me.DtPckReceived.Size = New System.Drawing.Size(98, 20)
    Me.DtPckReceived.TabIndex = 179
    '
    'Label53
    '
    Me.Label53.Location = New System.Drawing.Point(16, 56)
    Me.Label53.Name = "Label53"
    Me.Label53.Size = New System.Drawing.Size(123, 15)
    Me.Label53.TabIndex = 178
    Me.Label53.Text = "9. Application Received"
    '
    'LblTax
    '
    Me.LblTax.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTax.Location = New System.Drawing.Point(128, 350)
    Me.LblTax.Name = "LblTax"
    Me.LblTax.Size = New System.Drawing.Size(73, 18)
    Me.LblTax.TabIndex = 176
    Me.LblTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblMillRate
    '
    Me.LblMillRate.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblMillRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblMillRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMillRate.Location = New System.Drawing.Point(19, 350)
    Me.LblMillRate.Name = "LblMillRate"
    Me.LblMillRate.Size = New System.Drawing.Size(77, 18)
    Me.LblMillRate.TabIndex = 175
    Me.LblMillRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblAInit
    '
    Me.LblAInit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAInit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAInit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAInit.Location = New System.Drawing.Point(711, 24)
    Me.LblAInit.Name = "LblAInit"
    Me.LblAInit.Size = New System.Drawing.Size(15, 18)
    Me.LblAInit.TabIndex = 174
    Me.LblAInit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblAFName
    '
    Me.LblAFName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAFName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAFName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAFName.Location = New System.Drawing.Point(591, 24)
    Me.LblAFName.Name = "LblAFName"
    Me.LblAFName.Size = New System.Drawing.Size(114, 18)
    Me.LblAFName.TabIndex = 173
    Me.LblAFName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblALName
    '
    Me.LblALName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblALName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblALName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblALName.Location = New System.Drawing.Point(357, 24)
    Me.LblALName.Name = "LblALName"
    Me.LblALName.Size = New System.Drawing.Size(228, 18)
    Me.LblALName.TabIndex = 2
    Me.LblALName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblYear.Location = New System.Drawing.Point(186, 24)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(33, 18)
    Me.LblYear.TabIndex = 1
    Me.LblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblListNo
    '
    Me.LblListNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblListNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblListNo.Location = New System.Drawing.Point(64, 24)
    Me.LblListNo.Name = "LblListNo"
    Me.LblListNo.Size = New System.Drawing.Size(68, 18)
    Me.LblListNo.TabIndex = 0
    Me.LblListNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.TxtDisallowReason)
    Me.GroupBox5.Controls.Add(Me.RbDisallowed)
    Me.GroupBox5.Controls.Add(Me.RbAllowed)
    Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox5.Location = New System.Drawing.Point(19, 386)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(479, 66)
    Me.GroupBox5.TabIndex = 8
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "Assessor Affidavit"
    '
    'TxtDisallowReason
    '
    Me.TxtDisallowReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDisallowReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDisallowReason.Location = New System.Drawing.Point(270, 40)
    Me.TxtDisallowReason.MaxLength = 30
    Me.TxtDisallowReason.Name = "TxtDisallowReason"
    Me.TxtDisallowReason.Size = New System.Drawing.Size(180, 20)
    Me.TxtDisallowReason.TabIndex = 167
    '
    'RbDisallowed
    '
    Me.RbDisallowed.AutoSize = True
    Me.RbDisallowed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbDisallowed.Location = New System.Drawing.Point(8, 40)
    Me.RbDisallowed.Name = "RbDisallowed"
    Me.RbDisallowed.Size = New System.Drawing.Size(246, 17)
    Me.RbDisallowed.TabIndex = 2
    Me.RbDisallowed.Text = "This claim is disallowed for the following reason"
    '
    'RbAllowed
    '
    Me.RbAllowed.AutoSize = True
    Me.RbAllowed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbAllowed.Location = New System.Drawing.Point(8, 16)
    Me.RbAllowed.Name = "RbAllowed"
    Me.RbAllowed.Size = New System.Drawing.Size(442, 17)
    Me.RbAllowed.TabIndex = 0
    Me.RbAllowed.Text = "I am satified that the above name applicant meet all the necessary statutory requ" &
    "irements"
    '
    'GroupBox3
    '
    Me.GroupBox3.BackColor = System.Drawing.Color.Lavender
    Me.GroupBox3.Controls.Add(Me.LblRE)
    Me.GroupBox3.Controls.Add(Me.LnkTablePct)
    Me.GroupBox3.Controls.Add(Me.LblCreditMax)
    Me.GroupBox3.Controls.Add(Me.LblCredit)
    Me.GroupBox3.Controls.Add(Me.LblLesser)
    Me.GroupBox3.Controls.Add(Me.Label44)
    Me.GroupBox3.Controls.Add(Me.Label45)
    Me.GroupBox3.Controls.Add(Me.TxtMinGrant)
    Me.GroupBox3.Controls.Add(Me.Label46)
    Me.GroupBox3.Controls.Add(Me.Label47)
    Me.GroupBox3.Controls.Add(Me.TxtCeiling)
    Me.GroupBox3.Controls.Add(Me.Label49)
    Me.GroupBox3.Controls.Add(Me.TxtTablePct)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(418, 102)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(238, 211)
    Me.GroupBox3.TabIndex = 7
    Me.GroupBox3.TabStop = False
    '
    'LblRE
    '
    Me.LblRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblRE.Location = New System.Drawing.Point(6, 13)
    Me.LblRE.Name = "LblRE"
    Me.LblRE.Size = New System.Drawing.Size(226, 17)
    Me.LblRE.TabIndex = 178
    Me.LblRE.Text = "Real Estate - Elderly Data"
    Me.LblRE.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'LnkTablePct
    '
    Me.LnkTablePct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkTablePct.Location = New System.Drawing.Point(13, 40)
    Me.LnkTablePct.Name = "LnkTablePct"
    Me.LnkTablePct.Size = New System.Drawing.Size(122, 16)
    Me.LnkTablePct.TabIndex = 176
    Me.LnkTablePct.TabStop = True
    Me.LnkTablePct.Text = "14. Table Percentage"
    '
    'LblCreditMax
    '
    Me.LblCreditMax.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCreditMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCreditMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCreditMax.Location = New System.Drawing.Point(166, 61)
    Me.LblCreditMax.Name = "LblCreditMax"
    Me.LblCreditMax.Size = New System.Drawing.Size(66, 18)
    Me.LblCreditMax.TabIndex = 173
    Me.LblCreditMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCredit
    '
    Me.LblCredit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCredit.Location = New System.Drawing.Point(166, 185)
    Me.LblCredit.Name = "LblCredit"
    Me.LblCredit.Size = New System.Drawing.Size(66, 18)
    Me.LblCredit.TabIndex = 172
    Me.LblCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblLesser
    '
    Me.LblLesser.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLesser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLesser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLesser.Location = New System.Drawing.Point(166, 109)
    Me.LblLesser.Name = "LblLesser"
    Me.LblLesser.Size = New System.Drawing.Size(66, 18)
    Me.LblLesser.TabIndex = 171
    Me.LblLesser.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label44
    '
    Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label44.Location = New System.Drawing.Point(10, 187)
    Me.Label44.Name = "Label44"
    Me.Label44.Size = New System.Drawing.Size(138, 16)
    Me.Label44.TabIndex = 57
    Me.Label44.Text = "*17. Credit Amount"
    '
    'Label45
    '
    Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label45.Location = New System.Drawing.Point(10, 135)
    Me.Label45.Name = "Label45"
    Me.Label45.Size = New System.Drawing.Size(138, 16)
    Me.Label45.TabIndex = 55
    Me.Label45.Text = "16b. Minimum Grant"
    '
    'TxtMinGrant
    '
    Me.TxtMinGrant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMinGrant.Location = New System.Drawing.Point(166, 132)
    Me.TxtMinGrant.MaxLength = 7
    Me.TxtMinGrant.Name = "TxtMinGrant"
    Me.TxtMinGrant.Size = New System.Drawing.Size(66, 20)
    Me.TxtMinGrant.TabIndex = 54
    Me.TxtMinGrant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label46
    '
    Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label46.Location = New System.Drawing.Point(10, 111)
    Me.Label46.Name = "Label46"
    Me.Label46.Size = New System.Drawing.Size(138, 16)
    Me.Label46.TabIndex = 53
    Me.Label46.Text = "16a. Lesser of 15a or 15b"
    '
    'Label47
    '
    Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label47.Location = New System.Drawing.Point(10, 87)
    Me.Label47.Name = "Label47"
    Me.Label47.Size = New System.Drawing.Size(138, 16)
    Me.Label47.TabIndex = 52
    Me.Label47.Text = "15b. Table Ceiling"
    '
    'TxtCeiling
    '
    Me.TxtCeiling.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCeiling.Location = New System.Drawing.Point(166, 84)
    Me.TxtCeiling.MaxLength = 7
    Me.TxtCeiling.Name = "TxtCeiling"
    Me.TxtCeiling.Size = New System.Drawing.Size(66, 20)
    Me.TxtCeiling.TabIndex = 46
    Me.TxtCeiling.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label49
    '
    Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label49.Location = New System.Drawing.Point(13, 63)
    Me.Label49.Name = "Label49"
    Me.Label49.Size = New System.Drawing.Size(138, 16)
    Me.Label49.TabIndex = 45
    Me.Label49.Text = "15a. Credit Maximum"
    '
    'TxtTablePct
    '
    Me.TxtTablePct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTablePct.Location = New System.Drawing.Point(195, 36)
    Me.TxtTablePct.MaxLength = 3
    Me.TxtTablePct.Name = "TxtTablePct"
    Me.TxtTablePct.Size = New System.Drawing.Size(37, 20)
    Me.TxtTablePct.TabIndex = 0
    Me.TxtTablePct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label43
    '
    Me.Label43.Location = New System.Drawing.Point(125, 326)
    Me.Label43.Name = "Label43"
    Me.Label43.Size = New System.Drawing.Size(94, 17)
    Me.Label43.TabIndex = 166
    Me.Label43.Text = "13. Property Tax"
    '
    'Label42
    '
    Me.Label42.Location = New System.Drawing.Point(16, 326)
    Me.Label42.Name = "Label42"
    Me.Label42.Size = New System.Drawing.Size(73, 17)
    Me.Label42.TabIndex = 164
    Me.Label42.Text = "12. Mill Rate"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.LblGross)
    Me.GroupBox2.Controls.Add(Me.Label56)
    Me.GroupBox2.Controls.Add(Me.LblAppGross)
    Me.GroupBox2.Controls.Add(Me.LblNet)
    Me.GroupBox2.Controls.Add(Me.Label41)
    Me.GroupBox2.Controls.Add(Me.TxtAddlVet)
    Me.GroupBox2.Controls.Add(Me.Label40)
    Me.GroupBox2.Controls.Add(Me.TxtLocal)
    Me.GroupBox2.Controls.Add(Me.Label37)
    Me.GroupBox2.Controls.Add(Me.Label36)
    Me.GroupBox2.Controls.Add(Me.Label35)
    Me.GroupBox2.Controls.Add(Me.TxtVet)
    Me.GroupBox2.Controls.Add(Me.TxtDisabled)
    Me.GroupBox2.Controls.Add(Me.TxtBlind)
    Me.GroupBox2.Controls.Add(Me.Label38)
    Me.GroupBox2.Controls.Add(Me.Label39)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(145, 102)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(238, 211)
    Me.GroupBox2.TabIndex = 6
    Me.GroupBox2.TabStop = False
    '
    'LblGross
    '
    Me.LblGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblGross.Location = New System.Drawing.Point(166, 13)
    Me.LblGross.Name = "LblGross"
    Me.LblGross.Size = New System.Drawing.Size(66, 18)
    Me.LblGross.TabIndex = 174
    Me.LblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label56
    '
    Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label56.Location = New System.Drawing.Point(10, 18)
    Me.Label56.Name = "Label56"
    Me.Label56.Size = New System.Drawing.Size(150, 13)
    Me.Label56.TabIndex = 173
    Me.Label56.Text = "Gross Assessment"
    '
    'LblAppGross
    '
    Me.LblAppGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAppGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAppGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAppGross.Location = New System.Drawing.Point(166, 37)
    Me.LblAppGross.Name = "LblAppGross"
    Me.LblAppGross.Size = New System.Drawing.Size(66, 18)
    Me.LblAppGross.TabIndex = 172
    Me.LblAppGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblNet
    '
    Me.LblNet.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNet.Location = New System.Drawing.Point(166, 186)
    Me.LblNet.Name = "LblNet"
    Me.LblNet.Size = New System.Drawing.Size(66, 18)
    Me.LblNet.TabIndex = 171
    Me.LblNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label41
    '
    Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label41.Location = New System.Drawing.Point(10, 162)
    Me.Label41.Name = "Label41"
    Me.Label41.Size = New System.Drawing.Size(138, 16)
    Me.Label41.TabIndex = 57
    Me.Label41.Text = "Addl Vets Exemption"
    '
    'TxtAddlVet
    '
    Me.TxtAddlVet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAddlVet.Location = New System.Drawing.Point(166, 159)
    Me.TxtAddlVet.MaxLength = 8
    Me.TxtAddlVet.Name = "TxtAddlVet"
    Me.TxtAddlVet.Size = New System.Drawing.Size(66, 20)
    Me.TxtAddlVet.TabIndex = 56
    Me.TxtAddlVet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label40
    '
    Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label40.Location = New System.Drawing.Point(10, 138)
    Me.Label40.Name = "Label40"
    Me.Label40.Size = New System.Drawing.Size(138, 16)
    Me.Label40.TabIndex = 55
    Me.Label40.Text = "Local  Exemption"
    '
    'TxtLocal
    '
    Me.TxtLocal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocal.Location = New System.Drawing.Point(166, 135)
    Me.TxtLocal.MaxLength = 8
    Me.TxtLocal.Name = "TxtLocal"
    Me.TxtLocal.Size = New System.Drawing.Size(66, 20)
    Me.TxtLocal.TabIndex = 54
    Me.TxtLocal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label37
    '
    Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label37.Location = New System.Drawing.Point(10, 114)
    Me.Label37.Name = "Label37"
    Me.Label37.Size = New System.Drawing.Size(138, 16)
    Me.Label37.TabIndex = 53
    Me.Label37.Text = "Veterans Exemption"
    '
    'Label36
    '
    Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label36.Location = New System.Drawing.Point(10, 90)
    Me.Label36.Name = "Label36"
    Me.Label36.Size = New System.Drawing.Size(138, 16)
    Me.Label36.TabIndex = 52
    Me.Label36.Text = "Disabled Exemption"
    '
    'Label35
    '
    Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label35.Location = New System.Drawing.Point(6, 188)
    Me.Label35.Name = "Label35"
    Me.Label35.Size = New System.Drawing.Size(141, 20)
    Me.Label35.TabIndex = 50
    Me.Label35.Text = "11. Net Assessment"
    Me.Label35.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'TxtVet
    '
    Me.TxtVet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVet.Location = New System.Drawing.Point(166, 111)
    Me.TxtVet.MaxLength = 8
    Me.TxtVet.Name = "TxtVet"
    Me.TxtVet.Size = New System.Drawing.Size(66, 20)
    Me.TxtVet.TabIndex = 48
    Me.TxtVet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtDisabled
    '
    Me.TxtDisabled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDisabled.Location = New System.Drawing.Point(166, 87)
    Me.TxtDisabled.MaxLength = 8
    Me.TxtDisabled.Name = "TxtDisabled"
    Me.TxtDisabled.Size = New System.Drawing.Size(66, 20)
    Me.TxtDisabled.TabIndex = 46
    Me.TxtDisabled.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtBlind
    '
    Me.TxtBlind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBlind.Location = New System.Drawing.Point(166, 63)
    Me.TxtBlind.MaxLength = 8
    Me.TxtBlind.Name = "TxtBlind"
    Me.TxtBlind.Size = New System.Drawing.Size(66, 20)
    Me.TxtBlind.TabIndex = 44
    Me.TxtBlind.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label38
    '
    Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label38.Location = New System.Drawing.Point(10, 63)
    Me.Label38.Name = "Label38"
    Me.Label38.Size = New System.Drawing.Size(138, 16)
    Me.Label38.TabIndex = 45
    Me.Label38.Text = "Blind Exemption"
    '
    'Label39
    '
    Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label39.Location = New System.Drawing.Point(10, 42)
    Me.Label39.Name = "Label39"
    Me.Label39.Size = New System.Drawing.Size(150, 16)
    Me.Label39.TabIndex = 43
    Me.Label39.Text = "Applicant Gross Assessment"
    '
    'Label34
    '
    Me.Label34.Location = New System.Drawing.Point(297, 79)
    Me.Label34.Name = "Label34"
    Me.Label34.Size = New System.Drawing.Size(23, 20)
    Me.Label34.TabIndex = 162
    Me.Label34.Text = "%"
    '
    'TxtPGross
    '
    Me.TxtPGross.Location = New System.Drawing.Point(32, 136)
    Me.TxtPGross.MaxLength = 9
    Me.TxtPGross.Name = "TxtPGross"
    Me.TxtPGross.Size = New System.Drawing.Size(77, 20)
    Me.TxtPGross.TabIndex = 5
    Me.TxtPGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label33
    '
    Me.Label33.Location = New System.Drawing.Point(16, 118)
    Me.Label33.Name = "Label33"
    Me.Label33.Size = New System.Drawing.Size(123, 15)
    Me.Label33.TabIndex = 160
    Me.Label33.Text = "Property Gross Asmnt"
    '
    'TxtPropPct
    '
    Me.TxtPropPct.Location = New System.Drawing.Point(249, 76)
    Me.TxtPropPct.MaxLength = 6
    Me.TxtPropPct.Name = "TxtPropPct"
    Me.TxtPropPct.Size = New System.Drawing.Size(47, 20)
    Me.TxtPropPct.TabIndex = 4
    '
    'Label32
    '
    Me.Label32.AutoSize = True
    Me.Label32.Location = New System.Drawing.Point(163, 56)
    Me.Label32.Name = "Label32"
    Me.Label32.Size = New System.Drawing.Size(255, 13)
    Me.Label32.TabIndex = 158
    Me.Label32.Text = "10. Total Percentage of property owned by applicant"
    '
    'Label30
    '
    Me.Label30.Location = New System.Drawing.Point(7, 25)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(51, 17)
    Me.Label30.TabIndex = 155
    Me.Label30.Text = "List No"
    '
    'Label22
    '
    Me.Label22.AutoSize = True
    Me.Label22.Location = New System.Drawing.Point(695, 0)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(44, 13)
    Me.Label22.TabIndex = 154
    Me.Label22.Text = "(Middle)"
    '
    'Label27
    '
    Me.Label27.AutoSize = True
    Me.Label27.Location = New System.Drawing.Point(590, 0)
    Me.Label27.Name = "Label27"
    Me.Label27.Size = New System.Drawing.Size(32, 13)
    Me.Label27.TabIndex = 153
    Me.Label27.Text = "(First)"
    '
    'Label28
    '
    Me.Label28.AutoSize = True
    Me.Label28.Location = New System.Drawing.Point(354, 3)
    Me.Label28.Name = "Label28"
    Me.Label28.Size = New System.Drawing.Size(64, 13)
    Me.Label28.TabIndex = 152
    Me.Label28.Text = "Name (Last)"
    '
    'Label29
    '
    Me.Label29.Location = New System.Drawing.Point(149, 25)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(35, 17)
    Me.Label29.TabIndex = 150
    Me.Label29.Text = "Year"
    '
    'TpLocal
    '
    Me.TpLocal.Controls.Add(Me.LblLocDeferral)
    Me.TpLocal.Controls.Add(Me.LblHdrLocDeferral)
    Me.TpLocal.Controls.Add(Me.LblHdrDefMarried)
    Me.TpLocal.Controls.Add(Me.LblHdrDefSingle)
    Me.TpLocal.Controls.Add(Me.LblDefSingle)
    Me.TpLocal.Controls.Add(Me.LblDefMarried)
    Me.TpLocal.Controls.Add(Me.GrpDefer)
    Me.TpLocal.Controls.Add(Me.GroupBox9)
    Me.TpLocal.Controls.Add(Me.LblTRF)
    Me.TpLocal.Controls.Add(Me.LblTRFHdr)
    Me.TpLocal.Controls.Add(Me.LblHdrStMarried)
    Me.TpLocal.Controls.Add(Me.LblHdrStSingle)
    Me.TpLocal.Controls.Add(Me.LblStSingle)
    Me.TpLocal.Controls.Add(Me.LblStMarried)
    Me.TpLocal.Controls.Add(Me.LblLocPropPct)
    Me.TpLocal.Controls.Add(Me.LblHdrLocMarried)
    Me.TpLocal.Controls.Add(Me.LblHdrLocSingle)
    Me.TpLocal.Controls.Add(Me.LblLocSingle)
    Me.TpLocal.Controls.Add(Me.LblLocMarried)
    Me.TpLocal.Controls.Add(Me.LblLocPgm)
    Me.TpLocal.Controls.Add(Me.LblLocCredit)
    Me.TpLocal.Controls.Add(Me.Label81)
    Me.TpLocal.Controls.Add(Me.LblLocTotal)
    Me.TpLocal.Controls.Add(Me.Label79)
    Me.TpLocal.Controls.Add(Me.DtPckLocAssr)
    Me.TpLocal.Controls.Add(Me.Label77)
    Me.TpLocal.Controls.Add(Me.GroupBox8)
    Me.TpLocal.Controls.Add(Me.Label75)
    Me.TpLocal.Controls.Add(Me.Label76)
    Me.TpLocal.Controls.Add(Me.LblLocSeq)
    Me.TpLocal.Controls.Add(Me.Label62)
    Me.TpLocal.Controls.Add(Me.LblLocAInit)
    Me.TpLocal.Controls.Add(Me.LblLocAFName)
    Me.TpLocal.Controls.Add(Me.LblLocALName)
    Me.TpLocal.Controls.Add(Me.LblLocYear)
    Me.TpLocal.Controls.Add(Me.LblLocListNo)
    Me.TpLocal.Controls.Add(Me.Label70)
    Me.TpLocal.Controls.Add(Me.Label71)
    Me.TpLocal.Controls.Add(Me.Label72)
    Me.TpLocal.Controls.Add(Me.Label73)
    Me.TpLocal.Controls.Add(Me.Label74)
    Me.TpLocal.Location = New System.Drawing.Point(4, 23)
    Me.TpLocal.Name = "TpLocal"
    Me.TpLocal.Size = New System.Drawing.Size(837, 518)
    Me.TpLocal.TabIndex = 2
    Me.TpLocal.Text = "Local"
    Me.TpLocal.UseVisualStyleBackColor = True
    '
    'LblLocDeferral
    '
    Me.LblLocDeferral.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocDeferral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocDeferral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocDeferral.Location = New System.Drawing.Point(568, 290)
    Me.LblLocDeferral.Name = "LblLocDeferral"
    Me.LblLocDeferral.Size = New System.Drawing.Size(66, 18)
    Me.LblLocDeferral.TabIndex = 254
    Me.LblLocDeferral.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblHdrLocDeferral
    '
    Me.LblHdrLocDeferral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblHdrLocDeferral.Location = New System.Drawing.Point(498, 293)
    Me.LblHdrLocDeferral.Name = "LblHdrLocDeferral"
    Me.LblHdrLocDeferral.Size = New System.Drawing.Size(51, 15)
    Me.LblHdrLocDeferral.TabIndex = 253
    Me.LblHdrLocDeferral.Text = "Deferral"
    '
    'LblHdrDefMarried
    '
    Me.LblHdrDefMarried.AutoSize = True
    Me.LblHdrDefMarried.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblHdrDefMarried.Location = New System.Drawing.Point(643, 160)
    Me.LblHdrDefMarried.Name = "LblHdrDefMarried"
    Me.LblHdrDefMarried.Size = New System.Drawing.Size(95, 17)
    Me.LblHdrDefMarried.TabIndex = 252
    Me.LblHdrDefMarried.Text = "Defer Married"
    '
    'LblHdrDefSingle
    '
    Me.LblHdrDefSingle.AutoSize = True
    Me.LblHdrDefSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblHdrDefSingle.Location = New System.Drawing.Point(643, 142)
    Me.LblHdrDefSingle.Name = "LblHdrDefSingle"
    Me.LblHdrDefSingle.Size = New System.Drawing.Size(86, 17)
    Me.LblHdrDefSingle.TabIndex = 251
    Me.LblHdrDefSingle.Text = "Defer Single"
    '
    'LblDefSingle
    '
    Me.LblDefSingle.AutoSize = True
    Me.LblDefSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDefSingle.Location = New System.Drawing.Point(734, 142)
    Me.LblDefSingle.Name = "LblDefSingle"
    Me.LblDefSingle.Size = New System.Drawing.Size(81, 17)
    Me.LblDefSingle.TabIndex = 250
    Me.LblDefSingle.Text = "<defsingle>"
    '
    'LblDefMarried
    '
    Me.LblDefMarried.AutoSize = True
    Me.LblDefMarried.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDefMarried.Location = New System.Drawing.Point(734, 159)
    Me.LblDefMarried.Name = "LblDefMarried"
    Me.LblDefMarried.Size = New System.Drawing.Size(92, 17)
    Me.LblDefMarried.TabIndex = 249
    Me.LblDefMarried.Text = "<defmarried>"
    '
    'GrpDefer
    '
    Me.GrpDefer.Controls.Add(Me.RbDefer25)
    Me.GrpDefer.Controls.Add(Me.RbDeferNone)
    Me.GrpDefer.Controls.Add(Me.RbDeferPlanB)
    Me.GrpDefer.Controls.Add(Me.RbDeferPlanA)
    Me.GrpDefer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpDefer.Location = New System.Drawing.Point(10, 196)
    Me.GrpDefer.Name = "GrpDefer"
    Me.GrpDefer.Size = New System.Drawing.Size(376, 40)
    Me.GrpDefer.TabIndex = 248
    Me.GrpDefer.TabStop = False
    Me.GrpDefer.Text = "Deferral"
    '
    'RbDeferNone
    '
    Me.RbDeferNone.AutoSize = True
    Me.RbDeferNone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbDeferNone.Location = New System.Drawing.Point(6, 17)
    Me.RbDeferNone.Name = "RbDeferNone"
    Me.RbDeferNone.Size = New System.Drawing.Size(51, 17)
    Me.RbDeferNone.TabIndex = 249
    Me.RbDeferNone.Text = "None"
    '
    'RbDeferPlanB
    '
    Me.RbDeferPlanB.AutoSize = True
    Me.RbDeferPlanB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbDeferPlanB.Location = New System.Drawing.Point(195, 17)
    Me.RbDeferPlanB.Name = "RbDeferPlanB"
    Me.RbDeferPlanB.Size = New System.Drawing.Size(85, 17)
    Me.RbDeferPlanB.TabIndex = 248
    Me.RbDeferPlanB.Text = "Plan B (50%)"
    '
    'RbDeferPlanA
    '
    Me.RbDeferPlanA.AutoSize = True
    Me.RbDeferPlanA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbDeferPlanA.Location = New System.Drawing.Point(85, 17)
    Me.RbDeferPlanA.Name = "RbDeferPlanA"
    Me.RbDeferPlanA.Size = New System.Drawing.Size(85, 17)
    Me.RbDeferPlanA.TabIndex = 247
    Me.RbDeferPlanA.Text = "Plan A (98%)"
    '
    'GroupBox9
    '
    Me.GroupBox9.Controls.Add(Me.RbLoc)
    Me.GroupBox9.Controls.Add(Me.RbNoLoc)
    Me.GroupBox9.Controls.Add(Me.RbLoc250)
    Me.GroupBox9.Controls.Add(Me.RbLoc212)
    Me.GroupBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox9.Location = New System.Drawing.Point(10, 145)
    Me.GroupBox9.Name = "GroupBox9"
    Me.GroupBox9.Size = New System.Drawing.Size(365, 40)
    Me.GroupBox9.TabIndex = 247
    Me.GroupBox9.TabStop = False
    Me.GroupBox9.Text = "Local Program"
    '
    'RbLoc
    '
    Me.RbLoc.AutoSize = True
    Me.RbLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbLoc.Location = New System.Drawing.Point(298, 17)
    Me.RbLoc.Name = "RbLoc"
    Me.RbLoc.Size = New System.Drawing.Size(51, 17)
    Me.RbLoc.TabIndex = 250
    Me.RbLoc.Text = "Local"
    '
    'RbNoLoc
    '
    Me.RbNoLoc.AutoSize = True
    Me.RbNoLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbNoLoc.Location = New System.Drawing.Point(6, 17)
    Me.RbNoLoc.Name = "RbNoLoc"
    Me.RbNoLoc.Size = New System.Drawing.Size(68, 17)
    Me.RbNoLoc.TabIndex = 249
    Me.RbNoLoc.Text = "No Local"
    '
    'RbLoc250
    '
    Me.RbLoc250.AutoSize = True
    Me.RbLoc250.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbLoc250.Location = New System.Drawing.Point(195, 17)
    Me.RbLoc250.Name = "RbLoc250"
    Me.RbLoc250.Size = New System.Drawing.Size(95, 17)
    Me.RbLoc250.TabIndex = 248
    Me.RbLoc250.Text = "Ordinance 250"
    '
    'RbLoc212
    '
    Me.RbLoc212.AutoSize = True
    Me.RbLoc212.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbLoc212.Location = New System.Drawing.Point(85, 17)
    Me.RbLoc212.Name = "RbLoc212"
    Me.RbLoc212.Size = New System.Drawing.Size(95, 17)
    Me.RbLoc212.TabIndex = 247
    Me.RbLoc212.Text = "Ordinance 212"
    '
    'LblTRF
    '
    Me.LblTRF.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTRF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTRF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTRF.Location = New System.Drawing.Point(431, 74)
    Me.LblTRF.Name = "LblTRF"
    Me.LblTRF.Size = New System.Drawing.Size(49, 18)
    Me.LblTRF.TabIndex = 245
    Me.LblTRF.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTRFHdr
    '
    Me.LblTRFHdr.AutoSize = True
    Me.LblTRFHdr.Location = New System.Drawing.Point(337, 76)
    Me.LblTRFHdr.Name = "LblTRFHdr"
    Me.LblTRFHdr.Size = New System.Drawing.Size(88, 13)
    Me.LblTRFHdr.TabIndex = 244
    Me.LblTRFHdr.Text = "Tax Relief Factor"
    '
    'LblHdrStMarried
    '
    Me.LblHdrStMarried.AutoSize = True
    Me.LblHdrStMarried.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblHdrStMarried.Location = New System.Drawing.Point(643, 125)
    Me.LblHdrStMarried.Name = "LblHdrStMarried"
    Me.LblHdrStMarried.Size = New System.Drawing.Size(93, 17)
    Me.LblHdrStMarried.TabIndex = 240
    Me.LblHdrStMarried.Text = "State Married"
    '
    'LblHdrStSingle
    '
    Me.LblHdrStSingle.AutoSize = True
    Me.LblHdrStSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblHdrStSingle.Location = New System.Drawing.Point(643, 107)
    Me.LblHdrStSingle.Name = "LblHdrStSingle"
    Me.LblHdrStSingle.Size = New System.Drawing.Size(84, 17)
    Me.LblHdrStSingle.TabIndex = 239
    Me.LblHdrStSingle.Text = "State Single"
    '
    'LblStSingle
    '
    Me.LblStSingle.AutoSize = True
    Me.LblStSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblStSingle.Location = New System.Drawing.Point(734, 107)
    Me.LblStSingle.Name = "LblStSingle"
    Me.LblStSingle.Size = New System.Drawing.Size(72, 17)
    Me.LblStSingle.TabIndex = 238
    Me.LblStSingle.Text = "<stsingle>"
    '
    'LblStMarried
    '
    Me.LblStMarried.AutoSize = True
    Me.LblStMarried.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblStMarried.Location = New System.Drawing.Point(734, 124)
    Me.LblStMarried.Name = "LblStMarried"
    Me.LblStMarried.Size = New System.Drawing.Size(83, 17)
    Me.LblStMarried.TabIndex = 237
    Me.LblStMarried.Text = "<stmarried>"
    '
    'LblLocPropPct
    '
    Me.LblLocPropPct.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocPropPct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocPropPct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocPropPct.Location = New System.Drawing.Point(248, 74)
    Me.LblLocPropPct.Name = "LblLocPropPct"
    Me.LblLocPropPct.Size = New System.Drawing.Size(49, 18)
    Me.LblLocPropPct.TabIndex = 225
    Me.LblLocPropPct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblHdrLocMarried
    '
    Me.LblHdrLocMarried.AutoSize = True
    Me.LblHdrLocMarried.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblHdrLocMarried.Location = New System.Drawing.Point(643, 90)
    Me.LblHdrLocMarried.Name = "LblHdrLocMarried"
    Me.LblHdrLocMarried.Size = New System.Drawing.Size(94, 17)
    Me.LblHdrLocMarried.TabIndex = 224
    Me.LblHdrLocMarried.Text = "Local Married"
    '
    'LblHdrLocSingle
    '
    Me.LblHdrLocSingle.AutoSize = True
    Me.LblHdrLocSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblHdrLocSingle.Location = New System.Drawing.Point(643, 72)
    Me.LblHdrLocSingle.Name = "LblHdrLocSingle"
    Me.LblHdrLocSingle.Size = New System.Drawing.Size(85, 17)
    Me.LblHdrLocSingle.TabIndex = 223
    Me.LblHdrLocSingle.Text = "Local Single"
    '
    'LblLocSingle
    '
    Me.LblLocSingle.AutoSize = True
    Me.LblLocSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocSingle.Location = New System.Drawing.Point(734, 72)
    Me.LblLocSingle.Name = "LblLocSingle"
    Me.LblLocSingle.Size = New System.Drawing.Size(79, 17)
    Me.LblLocSingle.TabIndex = 222
    Me.LblLocSingle.Text = "<locsingle>"
    '
    'LblLocMarried
    '
    Me.LblLocMarried.AutoSize = True
    Me.LblLocMarried.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocMarried.Location = New System.Drawing.Point(734, 89)
    Me.LblLocMarried.Name = "LblLocMarried"
    Me.LblLocMarried.Size = New System.Drawing.Size(90, 17)
    Me.LblLocMarried.TabIndex = 221
    Me.LblLocMarried.Text = "<locmarried>"
    '
    'LblLocPgm
    '
    Me.LblLocPgm.AutoSize = True
    Me.LblLocPgm.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocPgm.Location = New System.Drawing.Point(732, 20)
    Me.LblLocPgm.Name = "LblLocPgm"
    Me.LblLocPgm.Size = New System.Drawing.Size(96, 26)
    Me.LblLocPgm.TabIndex = 220
    Me.LblLocPgm.Text = "<LH/LL>"
    Me.LblLocPgm.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'LblLocCredit
    '
    Me.LblLocCredit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocCredit.Location = New System.Drawing.Point(568, 272)
    Me.LblLocCredit.Name = "LblLocCredit"
    Me.LblLocCredit.Size = New System.Drawing.Size(66, 18)
    Me.LblLocCredit.TabIndex = 218
    Me.LblLocCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label81
    '
    Me.Label81.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label81.Location = New System.Drawing.Point(498, 272)
    Me.Label81.Name = "Label81"
    Me.Label81.Size = New System.Drawing.Size(51, 15)
    Me.Label81.TabIndex = 217
    Me.Label81.Text = "Benefit"
    '
    'LblLocTotal
    '
    Me.LblLocTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocTotal.Location = New System.Drawing.Point(103, 119)
    Me.LblLocTotal.Name = "LblLocTotal"
    Me.LblLocTotal.Size = New System.Drawing.Size(64, 18)
    Me.LblLocTotal.TabIndex = 216
    Me.LblLocTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label79
    '
    Me.Label79.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label79.Location = New System.Drawing.Point(7, 122)
    Me.Label79.Name = "Label79"
    Me.Label79.Size = New System.Drawing.Size(90, 20)
    Me.Label79.TabIndex = 215
    Me.Label79.Text = "TOTAL INCOME"
    Me.Label79.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'DtPckLocAssr
    '
    Me.DtPckLocAssr.Checked = False
    Me.DtPckLocAssr.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckLocAssr.Location = New System.Drawing.Point(145, 316)
    Me.DtPckLocAssr.Name = "DtPckLocAssr"
    Me.DtPckLocAssr.ShowCheckBox = True
    Me.DtPckLocAssr.Size = New System.Drawing.Size(100, 20)
    Me.DtPckLocAssr.TabIndex = 214
    '
    'Label77
    '
    Me.Label77.Location = New System.Drawing.Point(15, 320)
    Me.Label77.Name = "Label77"
    Me.Label77.Size = New System.Drawing.Size(124, 16)
    Me.Label77.TabIndex = 213
    Me.Label77.Text = "Date Assessor Signed"
    '
    'GroupBox8
    '
    Me.GroupBox8.Controls.Add(Me.TxtLocDisallowReason)
    Me.GroupBox8.Controls.Add(Me.RbLocDisallowed)
    Me.GroupBox8.Controls.Add(Me.RbLocAllowed)
    Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox8.Location = New System.Drawing.Point(10, 242)
    Me.GroupBox8.Name = "GroupBox8"
    Me.GroupBox8.Size = New System.Drawing.Size(479, 66)
    Me.GroupBox8.TabIndex = 212
    Me.GroupBox8.TabStop = False
    Me.GroupBox8.Text = "Assessor Affidavit"
    '
    'TxtLocDisallowReason
    '
    Me.TxtLocDisallowReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLocDisallowReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocDisallowReason.Location = New System.Drawing.Point(270, 40)
    Me.TxtLocDisallowReason.MaxLength = 30
    Me.TxtLocDisallowReason.Name = "TxtLocDisallowReason"
    Me.TxtLocDisallowReason.Size = New System.Drawing.Size(180, 20)
    Me.TxtLocDisallowReason.TabIndex = 167
    '
    'RbLocDisallowed
    '
    Me.RbLocDisallowed.AutoSize = True
    Me.RbLocDisallowed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbLocDisallowed.Location = New System.Drawing.Point(8, 40)
    Me.RbLocDisallowed.Name = "RbLocDisallowed"
    Me.RbLocDisallowed.Size = New System.Drawing.Size(246, 17)
    Me.RbLocDisallowed.TabIndex = 2
    Me.RbLocDisallowed.Text = "This claim is disallowed for the following reason"
    '
    'RbLocAllowed
    '
    Me.RbLocAllowed.AutoSize = True
    Me.RbLocAllowed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbLocAllowed.Location = New System.Drawing.Point(8, 16)
    Me.RbLocAllowed.Name = "RbLocAllowed"
    Me.RbLocAllowed.Size = New System.Drawing.Size(442, 17)
    Me.RbLocAllowed.TabIndex = 0
    Me.RbLocAllowed.Text = "I am satified that the above name applicant meet all the necessary statutory requ" &
    "irements"
    '
    'Label75
    '
    Me.Label75.Location = New System.Drawing.Point(299, 77)
    Me.Label75.Name = "Label75"
    Me.Label75.Size = New System.Drawing.Size(23, 20)
    Me.Label75.TabIndex = 211
    Me.Label75.Text = "%"
    '
    'Label76
    '
    Me.Label76.AutoSize = True
    Me.Label76.Location = New System.Drawing.Point(7, 77)
    Me.Label76.Name = "Label76"
    Me.Label76.Size = New System.Drawing.Size(237, 13)
    Me.Label76.TabIndex = 210
    Me.Label76.Text = "Total Percentage of property owned by applicant"
    '
    'LblLocSeq
    '
    Me.LblLocSeq.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocSeq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocSeq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocSeq.Location = New System.Drawing.Point(302, 26)
    Me.LblLocSeq.Name = "LblLocSeq"
    Me.LblLocSeq.Size = New System.Drawing.Size(24, 18)
    Me.LblLocSeq.TabIndex = 207
    Me.LblLocSeq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label62
    '
    Me.Label62.Location = New System.Drawing.Point(245, 27)
    Me.Label62.Name = "Label62"
    Me.Label62.Size = New System.Drawing.Size(51, 17)
    Me.Label62.TabIndex = 208
    Me.Label62.Text = "Seq No"
    '
    'LblLocAInit
    '
    Me.LblLocAInit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocAInit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocAInit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocAInit.Location = New System.Drawing.Point(711, 26)
    Me.LblLocAInit.Name = "LblLocAInit"
    Me.LblLocAInit.Size = New System.Drawing.Size(15, 18)
    Me.LblLocAInit.TabIndex = 206
    Me.LblLocAInit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblLocAFName
    '
    Me.LblLocAFName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocAFName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocAFName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocAFName.Location = New System.Drawing.Point(591, 26)
    Me.LblLocAFName.Name = "LblLocAFName"
    Me.LblLocAFName.Size = New System.Drawing.Size(114, 18)
    Me.LblLocAFName.TabIndex = 205
    Me.LblLocAFName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblLocALName
    '
    Me.LblLocALName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocALName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocALName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocALName.Location = New System.Drawing.Point(357, 26)
    Me.LblLocALName.Name = "LblLocALName"
    Me.LblLocALName.Size = New System.Drawing.Size(228, 18)
    Me.LblLocALName.TabIndex = 199
    Me.LblLocALName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblLocYear
    '
    Me.LblLocYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocYear.Location = New System.Drawing.Point(186, 24)
    Me.LblLocYear.Name = "LblLocYear"
    Me.LblLocYear.Size = New System.Drawing.Size(33, 18)
    Me.LblLocYear.TabIndex = 198
    Me.LblLocYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblLocListNo
    '
    Me.LblLocListNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocListNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocListNo.Location = New System.Drawing.Point(64, 26)
    Me.LblLocListNo.Name = "LblLocListNo"
    Me.LblLocListNo.Size = New System.Drawing.Size(75, 18)
    Me.LblLocListNo.TabIndex = 197
    Me.LblLocListNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label70
    '
    Me.Label70.Location = New System.Drawing.Point(7, 27)
    Me.Label70.Name = "Label70"
    Me.Label70.Size = New System.Drawing.Size(51, 17)
    Me.Label70.TabIndex = 204
    Me.Label70.Text = "List No"
    '
    'Label71
    '
    Me.Label71.AutoSize = True
    Me.Label71.Location = New System.Drawing.Point(695, 2)
    Me.Label71.Name = "Label71"
    Me.Label71.Size = New System.Drawing.Size(44, 13)
    Me.Label71.TabIndex = 203
    Me.Label71.Text = "(Middle)"
    '
    'Label72
    '
    Me.Label72.AutoSize = True
    Me.Label72.Location = New System.Drawing.Point(590, 2)
    Me.Label72.Name = "Label72"
    Me.Label72.Size = New System.Drawing.Size(32, 13)
    Me.Label72.TabIndex = 202
    Me.Label72.Text = "(First)"
    '
    'Label73
    '
    Me.Label73.AutoSize = True
    Me.Label73.Location = New System.Drawing.Point(354, 5)
    Me.Label73.Name = "Label73"
    Me.Label73.Size = New System.Drawing.Size(64, 13)
    Me.Label73.TabIndex = 201
    Me.Label73.Text = "Name (Last)"
    '
    'Label74
    '
    Me.Label74.Location = New System.Drawing.Point(149, 27)
    Me.Label74.Name = "Label74"
    Me.Label74.Size = New System.Drawing.Size(35, 17)
    Me.Label74.TabIndex = 200
    Me.Label74.Text = "Year"
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "scroll.ico")
    '
    'RbDefer25
    '
    Me.RbDefer25.AutoSize = True
    Me.RbDefer25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbDefer25.Location = New System.Drawing.Point(296, 17)
    Me.RbDefer25.Name = "RbDefer25"
    Me.RbDefer25.Size = New System.Drawing.Size(74, 17)
    Me.RbDefer25.TabIndex = 250
    Me.RbDefer25.Text = "Defer 25%"
    '
    'FrmTO201D
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(845, 547)
    Me.Controls.Add(Me.Tab1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTO201D"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Tab1.ResumeLayout(False)
    Me.TpApplicant.ResumeLayout(False)
    Me.TpApplicant.PerformLayout()
    Me.GroupBox6.ResumeLayout(False)
    Me.GroupBox6.PerformLayout()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.TpAssessor.ResumeLayout(False)
    Me.TpAssessor.PerformLayout()
    Me.GroupBox7.ResumeLayout(False)
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.TpLocal.ResumeLayout(False)
    Me.TpLocal.PerformLayout()
    Me.GrpDefer.ResumeLayout(False)
    Me.GrpDefer.PerformLayout()
    Me.GroupBox9.ResumeLayout(False)
    Me.GroupBox9.PerformLayout()
    Me.GroupBox8.ResumeLayout(False)
    Me.GroupBox8.PerformLayout()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmTO201D_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkDeferral As Decimal
    MyTXM35H = New TXM35H.MyData(myDBConnect)
    MyTXM35EX = New TXM35EX.MyData(myDBConnect)
    MyTXREALC = New TXREALC.MyData(myDBConnect)
    MyTXREAL = New TXREAL.MyData(myDBConnect)
    MyTXLOCAL = New TXLOCAL.MyData(myDBConnect)
    MyTXLOCDA = New TXLOCDA.MyData(myDBConnect)
    MyTXLOCFRZ = New TXLOCFRZ.MyData(myDBConnect)
    MyTXMRATE = New TXMRATE.MyData(myDBConnect)
    MyTXHOME = New TXHOME.MyData(myDBConnect)
    MyTXHOIN = New TXHOIN.MyData(myDBConnect)
    MyTPAYMNT = New TPAYMNT.MyData(myDBConnect)
    MyTXPROF = New TXPROF.MyData(myDBConnect)
    MyTXLOCIN = New TXLOCIN.MyData(myDBConnect)
    MyTXLOCHB = New TXLOCHB.MyData(myDBConnect)
    MyTXM35PM = New TXM35PM.MyData(myDBConnect)
    MyTXCNTL = New TXCNTL.MyData(myDBConnect)

    LoadScrn = True
    TxtListNo.Focus()
    MyFrmTO201.TBarNew.Enabled = False
    MyFrmTO201.TBarSave.Enabled = True
    LblTRF.Visible = False
    LblTRFHdr.Visible = False
    LblHdrDefSingle.Visible = False
    LblHdrDefMarried.Visible = False
    GrpDefer.Visible = False
    LblHdrLocDeferral.Visible = False
    LblLocDeferral.Visible = False
    Select Case MyLocEld
      Case = "032"
        LblHdrLocSingle.Visible = False
        LblHdrLocMarried.Visible = False
        RbLoc.Visible = False
      Case = "035"
        LblTRF.Visible = True
        LblTRFHdr.Visible = True
        GrpDefer.Visible = True
        RbDefer25.Visible = False
        LblHdrLocDeferral.Visible = True
        LblLocDeferral.Visible = True
        LblHdrDefSingle.Visible = True
        LblHdrDefMarried.Visible = True
        RbLoc212.Visible = False
        RbLoc250.Visible = False
        RbLoc.Left = RbLoc212.Left
      Case = "045", "084"
        RbNoLoc.Visible = False
        RbLoc.Visible = False
        RbLoc212.Visible = False
        RbLoc250.Visible = False
      Case Else
    End Select
    cExcludeCode1 = GetTXCDAGCode(1)
    cExcludeCode2 = GetTXCDAGCode(2)
    cExcludeCode3 = GetTXCDAGCode(3)
    cExcludeCode4 = GetTXCDAGCode(4)
    If cExcludeCode1 = 0 Then cExcludeCode1 = 12
    If cExcludeCode2 = 0 Then cExcludeCode2 = 61
    If cExcludeCode3 = 0 Then cExcludeCode3 = 62
    If cExcludeCode4 = 0 Then cExcludeCode4 = 63

    AddMode = False
    LblRE.Text = "Choose Affidavit Decision below ..."

    If MyLocEld = "" Then
      Tab1.TabPages.Remove(TpLocal)
    End If
    'Fill the dataset with the data
    If WrkListNo > 0 Then
      Me.Text = "Maintain " & Me.Text
      MyFrmTO201.TBarDelete.Enabled = True
      MyFrmTO201.TBarPrint.Enabled = True
      If MyLocEld <> "" Then
        MyFrmTO201.TbarLocal.Enabled = True
      End If
      TxtListNo.Text = WrkListNo
      LnkListNo.Enabled = False
      MyUtils.SetTxtReadOnly(TxtListNo)
      MyUtils.SetTxtReadOnly(TxtYear)
      DtPckADOB.Value = Date.Today
      DtPckSDOB.Value = Date.Today
      DtPckSigned.Value = Date.Today
      DtPckReceived.Value = Date.Today
      DtPckAssr.Value = Date.Today
      TxtPropPct.Text = "100"
      MyTXM35H.GetOneRecordP(WrkListNo, WrkYear, WrkSeq)
      If MyTXM35H.RecordNotFound Then
        MyFrmTO201.TBarNew.Enabled = False
        MyFrmTO201.TBarSave.Enabled = False
        MyFrmTO201.TBarDelete.Enabled = False
        MyFrmTO201.TBarPrint.Enabled = False
        MyFrmTO201.TbarLocal.Enabled = False
        Me.ErrProv.SetError(TxtListNo, "Record not found")
        Exit Sub
      End If

      With MyTXM35H
        'Applicant
        GetTXREALC()
        GetTXREAL()
        GetFrozenTax(._LISTNO)
        TxtListNo.Text = ._LISTNO
        TxtYear.Text = ._YEAR
        If ._SEQ > 0 Then
          LblSeq.Text = ._SEQ
        End If
        TxtALName.Text = Trim(._ALNAME)
        TxtAFName.Text = Trim(._AFNAME)
        TxtAInit.Text = Trim(._AINIT)
        DtPckADOB.Value = MyUtils.GetDBDate(._ADOB)
        If ._ASSN > 0 Then
          MskTxtASSN.Text = Format(._ASSN, "000000000")
        End If
        TxtSLName.Text = Trim(._SLNAME)
        TxtSFName.Text = Trim(._SFNAME)
        TxtSInit.Text = Trim(._SINIT)
        If ._SDOB > 0 Then
          DtPckSDOB.Value = MyUtils.GetDBDate(._SDOB)
        End If
        If ._SSSN > 0 Then
          MskTxtSSSN.Text = Format(._SSSN, "000000000")
        End If
        TxtMAddr.Text = Trim(._MADDR)
        TxtMCity.Text = Trim(._MCITY)
        TxtMState.Text = Trim(._MSTATE)
        If ._MZIP > 0 Then
          TxtMZip.Text = Format(._MZIP, "00000")
        End If
        TxtPAddr.Text = Trim(._PADDR)
        TxtPCity.Text = Trim(._PCITY)
        TxtPState.Text = Trim(._PSTATE)
        If ._PZIP > 0 Then
          TxtPZip.Text = Format(._PZIP, "00000")
        End If
        TxtOwner.Text = Trim(._OWNER)
        Select Case Trim(._FILING)
          Case "C"
            RbCivil.Checked = True
          Case "M"
            RbMarried.Checked = True
          Case "U"
            RbUnmarried.Checked = True
          Case "S"
            RbSurviving.Checked = True
        End Select
        ChkNursingHome.Checked = False
        If Trim(._NRSHOM) = "Y" Then
          ChkNursingHome.Checked = True
        End If
        ChkDisabled.Checked = False
        If Trim(._DISAB) = "Y" Then
          ChkDisabled.Checked = True
        End If
        ChkTaxReturn.Checked = False
        If Trim(._TAXRTN) = "Y" Then
          ChkTaxReturn.Checked = True
        End If
        DtPckSigned.Value = MyUtils.GetDBDate(._DTSIGN)
        If ._PHONE > 0 Then
          MskTxtPhone.Text = ._PHONE
        End If
        TxtRelate.Text = Trim(._RELATE)
        TxtIncome.Text = Format(._INCOME, "Fixed")
        TxtInterest.Text = Format(._INT, "Fixed")
        TxtSSRR.Text = Format(._SSRR, "Fixed")
        TxtOther.Text = Format(._OTHER, "Fixed")
        'Assessor
        If ._DTRECV > 0 Then
          DtPckReceived.Value = MyUtils.GetDBDate(._DTRECV)
          DtPckReceived.Checked = True
        End If
        TxtPropPct.Text = ._PROPCT
        TxtPGross.Text = ._PGROSS
        LblGross.Text = MyUtils.Round(._PGROSS * (._PROPCT / 100), 0)
        LblAppGross.Text = ._GROSS
        TxtBlind.Text = ._XBLIND
        TxtDisabled.Text = ._XDISAB
        TxtVet.Text = ._XVET
        TxtLocal.Text = ._XLOCAL
        TxtAddlVet.Text = ._XADDL
        LblNet.Text = ._NET
        TxtTablePct.Text = ._PCT
        TxtCeiling.Text = ._MAX
        TxtMinGrant.Text = ._MIN
        If Trim(._ALLOW) = "Y" Then
          RbAllowed.Checked = True
          LblRE.Text = "Real Estate - Elderly Data"
        End If
        If Trim(._ALLOW) = "N" Then
          RbDisallowed.Checked = True
          LblRE.Text = "Application Disallowed"
        End If
        TxtDisallowReason.Text = Trim(._DISRSN)
        If ._DTASSR > 0 Then
          DtPckAssr.Value = MyUtils.GetDBDate(._DTASSR)
          DtPckAssr.Checked = True
        End If
        TxtFrzTax.Text = Format(._FRZTAX, "fixed")
      End With

      If MyLocEld = "032" Then
        With MyTXM35PM
          LblLocTotal.Text = MyUtils.CnvSng(LblTotal.Text)
          LblLocPropPct.Text = MyTXM35H._PROPCT
          .GetOneRecordP(WrkListNo, WrkYear, WrkSeq, "212")
          If .RecordNotFound Then
            .GetOneRecordP(WrkListNo, WrkYear, WrkSeq, "250")
          Else
            RbLoc212.Checked = True
          End If
          If Not .RecordNotFound Then
            'Local
            If Not RbLoc212.Checked Then RbLoc250.Checked = True
            If Trim(._ALLOW) = "Y" Then
              RbLocAllowed.Checked = True
            End If
            LblLocPgm.Text = Trim(._LOCPM)
            If Trim(._ALLOW) = "N" Then
              RbLocDisallowed.Checked = True
            End If
            TxtLocDisallowReason.Text = Trim(._DISRSN)
            If ._DTASSR > 0 Then
              DtPckLocAssr.Value = MyUtils.GetDBDate(._DTASSR)
              DtPckLocAssr.Checked = True
            End If
            LblLocCredit.Text = CalcLocEld()
          Else
            RbNoLoc.Checked = True
          End If
        End With
      End If

      If MyLocEld = "035" Then
        With MyTXM35PM
          LblLocTotal.Text = MyUtils.CnvSng(LblTotal.Text)
          LblLocPropPct.Text = MyTXM35H._PROPCT
          .GetOneRecordP(WrkListNo, WrkYear, WrkSeq, "LOC")
          If Not .RecordNotFound Then
            RbLoc.Checked = True
            'Local
            If Trim(._ALLOW) = "Y" Then
              RbLocAllowed.Checked = True
            End If
            LblLocPgm.Text = Trim(._LOCPM)
            If Trim(._ALLOW) = "N" Then
              RbLocDisallowed.Checked = True
            End If
            TxtLocDisallowReason.Text = Trim(._DISRSN)
            If ._DTASSR > 0 Then
              DtPckLocAssr.Value = MyUtils.GetDBDate(._DTASSR)
              DtPckLocAssr.Checked = True
            End If
            LblLocCredit.Text = CalcLocEld()
            Select Case ._DEFER
              Case "A"
                RbDeferPlanA.Checked = True
                WrkDeferral = MyUtils.CnvSng(LblTax.Text) - MyUtils.CnvSng(LblCredit.Text) - MyUtils.CnvSng(LblLocCredit.Text)
                WrkDeferral = WrkDeferral - Math.Round(MyUtils.CnvSng(LblTax.Text) * 0.02, 2)
              Case "B"
                RbDeferPlanB.Checked = True
                WrkDeferral = MyUtils.CnvSng(LblTax.Text) - MyUtils.CnvSng(LblCredit.Text) - MyUtils.CnvSng(LblLocCredit.Text)
                WrkDeferral = Math.Round(WrkDeferral * 0.5, 2)
              Case Else
                RbDeferNone.Checked = True
                WrkDeferral = 0
            End Select
            LblLocDeferral.Text = WrkDeferral
          Else
            RbNoLoc.Checked = True
          End If
        End With
      End If

      If MyLocEld = "045" Then
        With MyTXM35PM
          LblLocTotal.Text = MyUtils.CnvSng(LblTotal.Text)
          LblLocPropPct.Text = MyTXM35H._PROPCT
          .GetOneRecordP(WrkListNo, WrkYear, WrkSeq, "LOC")
          If Not .RecordNotFound Then
            'Local
            If Trim(._ALLOW) = "Y" Then
              RbLocAllowed.Checked = True
            End If
            LblLocPgm.Text = Trim(._LOCPM)
            If Trim(._ALLOW) = "N" Then
              RbLocDisallowed.Checked = True
            End If
            TxtLocDisallowReason.Text = Trim(._DISRSN)
            If ._DTASSR > 0 Then
              DtPckLocAssr.Value = MyUtils.GetDBDate(._DTASSR)
              DtPckLocAssr.Checked = True
            End If
            LblLocCredit.Text = CalcLocEld()
          End If
        End With
      End If

      If MyLocEld = "084" Then
        With MyTXM35PM
          LblLocTotal.Text = MyUtils.CnvSng(LblTotal.Text)
          .GetOneRecordP(WrkListNo, WrkYear, WrkSeq, "LL")
          If .RecordNotFound Then
            .GetOneRecordP(WrkListNo, WrkYear, WrkSeq, "LH")
          End If
          If Not .RecordNotFound Then
            'Local
            LblLocPropPct.Text = MyTXM35H._PROPCT
            If Trim(._ALLOW) = "Y" Then
              RbLocAllowed.Checked = True
            End If
            LblLocPgm.Text = Trim(._LOCPM)
            If Trim(._ALLOW) = "N" Then
              RbLocDisallowed.Checked = True
            End If
            TxtLocDisallowReason.Text = Trim(._DISRSN)
            If ._DTASSR > 0 Then
              DtPckLocAssr.Value = MyUtils.GetDBDate(._DTASSR)
              DtPckLocAssr.Checked = True
            End If
            LblLocCredit.Text = CalcLocEld()
          End If
        End With
      End If
    Else
      Me.Text = "Add " & Me.Text
      AddMode = True
      TxtPropPct.Text = "100"
      LblLocPropPct.Text = "100"
      LblLocPgm.Text = ""
      GetTXREALC()
      GetTXREAL()
      MyFrmTO201.TBarDelete.Enabled = False
      LoadScrn = False
    End If

    LoadScrn = False
    CalcTotal()
    CalcCredit(False)
    With MyTXCNTL
      .GetOneRecordP("")
      If AddMode Then
        TxtYear.Text = ._ASRGL
        MyUtils.SetTxtReadOnly(TxtYear)
      End If
      If MyUtils.CnvSng(TxtYear.Text) <> ._ASRGL Then
        MyFrmTO201.TBarSave.Enabled = False
        MyFrmTO201.TBarDelete.Enabled = False
      End If
    End With
  End Sub

  Private Sub FrmTO201D_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTO201.TBarNew.Enabled = True
    MyFrmTO201.TBarSave.Enabled = False
    MyFrmTO201.TBarDelete.Enabled = False
    MyFrmTO201.TBarPrint.Enabled = False
    MyFrmTO201.TbarLocal.Enabled = False
    MyFrmTO201B.FormatGrid()
    MyFrmTO201B.Show()

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    MyTXM35H.DeleteOneRecordP()

    If MyLocEld <> "" Then
      With MyTXM35PM
        If Not .RecordNotFound Then
          .DeleteOneRecordP()
        End If
      End With
    End If
  End Sub
  Public Sub SaveData()
    Dim WrkLocPgm As String
    Dim WrkTax As Decimal
    Dim WrkMin As Decimal
    Dim WrkMax As Decimal
    Dim Answer As Integer
    Dim WrkMsg As String
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    WrkYear = MyUtils.CnvSng(TxtYear.Text)
    MyTXM35H.GetOneRecordP(WrkListNo, WrkYear, WrkSeq)
    If AddMode Then
      If Not MyTXM35H.RecordNotFound Then
        Answer = MsgBox("Do you want to add as another owner?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "List/Year already exists")
        If Answer = vbNo Then
          Me.ErrProv.SetError(TxtListNo, "Record already exists")
          Exit Sub
        End If
NextSeq:
        WrkSeq = WrkSeq + 1
        MyTXM35H.GetOneRecordP(WrkListNo, WrkYear, WrkSeq)
        If Not MyTXM35H.RecordNotFound Then GoTo NextSeq
      End If
    End If

    If Not AddMode Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXM35H.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXM35H.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    If MyLocEld <> "" Then
      With MyTXM35PM
        If LblLocPgm.Text <> "" Then
          .GetOneRecordP(WrkListNo, WrkYear, WrkSeq, LblLocPgm.Text)
          'Local
          ._TRF = MyUtils.CnvSng(LblTRF.Text)
          ._DEFER = ""
          ._DEFPCT = 0
          If RbDeferPlanA.Checked Then
            ._DEFER = "A"
            ._DEFPCT = 0.98
          End If
          If RbDeferPlanB.Checked Then
            ._DEFER = "B"
            ._DEFPCT = 0.5
          End If
          ._ALLOW = String.Empty
          If RbLocAllowed.Checked Then
            ._ALLOW = "Y"
            ._BENAMT = MyUtils.CnvSng(LblLocCredit.Text)
          End If
          If RbLocDisallowed.Checked Then
            ._ALLOW = "N"
            ._BENAMT = 0
          End If
          ._DISRSN = TxtLocDisallowReason.Text
          If DtPckLocAssr.Checked Then
            ._DTASSR = MyUtils.SetDBDate(DtPckLocAssr.Value)
          Else
            ._DTASSR = 0
          End If
          If Trim(._ALLOW) <> String.Empty Or ._DTASSR > 0 Then
            If .RecordNotFound Then
              ._LISTNO = WrkListNo
              ._YEAR = WrkYear
              ._SEQ = WrkSeq
              ._LOCPM = LblLocPgm.Text
              .AddOneRecordP()
            Else
              .UpdateOneRecordP()
            End If
          End If
        End If
        'Check for opposite program, if found then delete
        If MyLocEld = "032" Then
          If LblLocPgm.Text <> "212" Then
            .GetOneRecordP(WrkListNo, WrkYear, WrkSeq, "212")
            If Not .RecordNotFound Then
              .DeleteOneRecordP()
            End If
          End If
          If LblLocPgm.Text <> "250" Then
            .GetOneRecordP(WrkListNo, WrkYear, WrkSeq, "250")
            If Not .RecordNotFound Then
              .DeleteOneRecordP()
            End If
          End If
        End If
        If MyLocEld = "035" Then
          If RbNoLoc.Checked Then
            .GetOneRecordP(WrkListNo, WrkYear, WrkSeq, "LOC")
            If Not .RecordNotFound Then
              .DeleteOneRecordP()
            End If
          End If
        End If
        'Check for opposite program, if found then delete
        If MyLocEld = "084" Then
          If LblLocPgm.Text = "LL" Then
            .GetOneRecordP(WrkListNo, WrkYear, WrkSeq, "LH")
          Else
            .GetOneRecordP(WrkListNo, WrkYear, WrkSeq, "LL")
          End If
          If Not .RecordNotFound Then
            .DeleteOneRecordP()
          End If
        End If
      End With
    End If

    If MyLocEld = "032" Or MyLocEld = "035" Or MyLocEld = "045" Then
      With MyTXLOCAL
        Select Case MyLocEld
          Case "032"
            WrkLocPgm = Mid(LblLocPgm.Text, 2, 2)
          Case "035"
            WrkLocPgm = Mid(LblLocPgm.Text, 1, 2)
          Case "045"
            WrkLocPgm = Mid(LblLocPgm.Text, 1, 2)
          Case Else
            WrkLocPgm = ""
        End Select
        If LblLocPgm.Text <> "" Then
          .GetOneRecordP(WrkListNo, WrkYear, "R", WrkLocPgm)
          If RbLocAllowed.Checked Then
            If .RecordNotFound Then
              ._LISTNo = WrkListNo
              ._TYPE = "R"
              ._BENCDE = WrkLocPgm
              ._BENAMT = CalcLocalSplit()
              .AddOneRecordP()
            Else
              If CalcLocalSplit() > 0 Then
                ._BENAMT = CalcLocalSplit()
                .UpdateOneRecordP()
              Else
                .DeleteOneRecordP()
              End If
            End If
          Else
            If Not .RecordNotFound Then
              .DeleteOneRecordP()
            End If
          End If
        End If
        'Check for opposite program, if found then delete
        If MyLocEld = "032" Then
          If LblLocPgm.Text <> "212" Then
            .GetOneRecordP(WrkListNo, WrkYear, "R", "12")
            If Not .RecordNotFound Then
              .DeleteOneRecordP()
            End If
          End If
          If LblLocPgm.Text <> "250" Then
            .GetOneRecordP(WrkListNo, WrkYear, "R", "50")
            If Not .RecordNotFound Then
              .DeleteOneRecordP()
            End If
          End If
        End If
        'Check for opposite program, if found then delete
        'If MyLocEld = "084" Then
        '  If LblLocPgm.Text = "LL" Then
        '    .GetOneRecordP(WrkListNo, WrkYear, WrkSeq, "LH")
        '  Else
        '    .GetOneRecordP(WrkListNo, WrkYear, WrkSeq, "LL")
        '  End If
        '  If Not .RecordNotFound Then
        '    .DeleteOneRecordP()
        '  End If
        'End If
      End With
    End If

    MyTXREALC.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text))
    If Not MyTXREALC.RecordNotFound Then
      With MyTXREALC
        RecalcTax(MyUtils.CnvSng(TxtListNo.Text), MyUtils.CnvSng(TxtYear.Text), WrkTax, WrkMin, WrkMax)
        If RbAllowed.Checked Then
          ._FCCOD = "C"
          ._FCYR = MyUtils.CnvSng(TxtYear.Text)
        Else
          ._FCCOD = ""
          ._FCYR = 0
        End If
        ._CPERC = MyUtils.CnvSng(TxtTablePct.Text) / 100
        ._CMAX = WrkMax
        ._CMIN = WrkMin
        ._FTAX = WrkTax
        If MyLocEld = "032" Or MyLocEld = "035" Or MyLocEld = "045" Then
          ._TWNBN = CalcTownBenefit()
        End If
        .UpdateOneRecordP()
      End With
    End If

    MyTXREAL.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text))
    If Not MyTXREAL.RecordNotFound Then
      With MyTXREAL
        RecalcTax(MyUtils.CnvSng(TxtListNo.Text), MyUtils.CnvSng(TxtYear.Text), WrkTax, WrkMin, WrkMax)
        If RbAllowed.Checked Then
          ._FCCOD = "C"
          ._FCYR = MyUtils.CnvSng(TxtYear.Text)
        Else
          ._FCCOD = ""
          ._FCYR = 0
        End If
        ._CPERC = MyUtils.CnvSng(TxtTablePct.Text) / 100
        ._CMAX = WrkMax
        ._CMIN = WrkMin
        ._FTAX = WrkTax
        If MyLocEld = "032" Or MyLocEld = "035" Or MyLocEld = "045" Then
          ._TWNBN = CalcTownBenefit()
        End If
        .UpdateOneRecordP()
      End With
    End If

    If MyTXHOIN.RecordNotFound Then
      WrkMsg = "Enter record using Homeowners Qualifying Income program to automate table percentage" & vbCrLf
      MsgBox(WrkMsg, MsgBoxStyle.Exclamation, "WARNING: Missing data for " & WrkYear)
    End If
    If Not MyWarnProf Then
      MyTXPROF.GetOneRecordP("R", WrkYear, "", 0)
      If MyTXPROF.RecordNotFound Then
        WrkMsg = "It is recommended to create a tax profile record" & vbCrLf
        WrkMsg = WrkMsg & "If you decide not to then Elderly status will be cleared" & vbCrLf
        WrkMsg = WrkMsg & "To reset, run a recalc with update elderly code/years"
        MsgBox(WrkMsg, MsgBoxStyle.Exclamation, "WARNING: Missing Tax Profile for " & WrkYear)
        MyWarnProf = True
      End If
    End If
    Me.Close()
  End Sub
  Private Sub MoveToFile()
    With MyTXM35H
      'Applicant
      ._LISTNO = MyUtils.CnvSng(TxtListNo.Text)
      ._YEAR = MyUtils.CnvSng(TxtYear.Text)
      ._SEQ = WrkSeq
      ._ALNAME = TxtALName.Text
      ._AFNAME = TxtAFName.Text
      ._AINIT = TxtAInit.Text
      ._ADOB = MyUtils.SetDBDate(DtPckADOB.Value)
      ._ASSN = Format(MyUtils.CnvSng(MskTxtASSN.Text), "000000000")
      ._SLNAME = TxtSLName.Text
      ._SFNAME = TxtSFName.Text
      ._SINIT = TxtSInit.Text
      If Trim(._SLNAME) <> "" Then
        ._SDOB = MyUtils.SetDBDate(DtPckSDOB.Value)
      Else
        ._SDOB = 0
      End If
      ._SSSN = Format(MyUtils.CnvSng(MskTxtSSSN.Text), "000000000")
      ._MADDR = TxtMAddr.Text
      ._MCITY = TxtMCity.Text
      ._MSTATE = TxtMState.Text
      ._MZIP = MyUtils.CnvSng(TxtMZip.Text)
      ._PADDR = TxtPAddr.Text
      ._PCITY = TxtPCity.Text
      ._PSTATE = TxtPState.Text
      ._PZIP = MyUtils.CnvSng(TxtPZip.Text)
      ._OWNER = TxtOwner.Text
      If RbCivil.Checked Then ._FILING = "C"
      If RbMarried.Checked Then ._FILING = "M"
      If RbUnmarried.Checked Then ._FILING = "U"
      If RbSurviving.Checked Then ._FILING = "S"
      If ChkNursingHome.Checked Then
        ._NRSHOM = "Y"
      Else
        ._NRSHOM = "N"
      End If
      If ChkDisabled.Checked Then
        ._DISAB = "Y"
      Else
        ._DISAB = "N"
      End If
      If ChkTaxReturn.Checked Then
        ._TAXRTN = "Y"
      Else
        ._TAXRTN = "N"
      End If
      ._DTSIGN = MyUtils.SetDBDate(DtPckSigned.Value)
      ._PHONE = MyUtils.CnvSng(MskTxtPhone.Text)
      ._RELATE = TxtRelate.Text
      ._INCOME = MyUtils.CnvSng(TxtIncome.Text)
      ._INT = MyUtils.CnvSng(TxtInterest.Text)
      ._SSRR = MyUtils.CnvSng(TxtSSRR.Text)
      ._OTHER = MyUtils.CnvSng(TxtOther.Text)
      'Assessor
      If DtPckReceived.Checked Then
        ._DTRECV = MyUtils.SetDBDate(DtPckReceived.Value)
      Else
        ._DTRECV = 0
      End If
      ._PROPCT = MyUtils.CnvSng(TxtPropPct.Text)
      ._PGROSS = MyUtils.CnvSng(TxtPGross.Text)
      ._GROSS = MyUtils.CnvSng(LblAppGross.Text)
      ._XBLIND = MyUtils.CnvSng(TxtBlind.Text)
      ._XDISAB = MyUtils.CnvSng(TxtDisabled.Text)
      ._XVET = MyUtils.CnvSng(TxtVet.Text)
      ._XLOCAL = MyUtils.CnvSng(TxtLocal.Text)
      ._XADDL = MyUtils.CnvSng(TxtAddlVet.Text)
      ._NET = MyUtils.CnvSng(LblNet.Text)
      ._PCT = MyUtils.CnvSng(TxtTablePct.Text)
      ._TAX = MyUtils.CnvSng(LblTax.Text)
      ._FRZTAX = MyUtils.CnvSng(TxtFrzTax.Text)
      ._MIN = MyUtils.CnvSng(TxtMinGrant.Text)
      ._MAX = MyUtils.CnvSng(TxtCeiling.Text)
      ._ALLOW = String.Empty
      If RbAllowed.Checked Then
        ._ALLOW = "Y"
      End If
      If RbDisallowed.Checked Then
        ._ALLOW = "N"
      End If
      ._DISRSN = TxtDisallowReason.Text
      If DtPckAssr.Checked Then
        ._DTASSR = MyUtils.SetDBDate(DtPckAssr.Value)
      Else
        ._DTASSR = 0
      End If
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtListNo.Text) = 0 Then
      ErrorField(I) = "listno"
      ErrorMsg(I) = "List Number is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtYear.Text) = 0 Then
      ErrorField(I) = "year"
      ErrorMsg(I) = "Year is required"
      I = I + 1
    End If

    If TxtALName.Text = String.Empty Then
      ErrorField(I) = "alname"
      ErrorMsg(I) = "Last Name is required"
      I = I + 1
    End If

    If TxtAFName.Text = String.Empty Then
      ErrorField(I) = "afname"
      ErrorMsg(I) = "First Name is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(MskTxtASSN.Text) = 0 Then
      ErrorField(I) = "assn"
      ErrorMsg(I) = "Social Security No is required"
      I = I + 1
    End If

    If RbMarried.Checked Then
      If TxtSLName.Text = String.Empty Then
        ErrorField(I) = "slname"
        ErrorMsg(I) = "Last Name is required"
        I = I + 1
      End If
      If TxtSFName.Text = String.Empty Then
        ErrorField(I) = "sfname"
        ErrorMsg(I) = "First Name is required"
        I = I + 1
      End If
      If MskTxtSSSN.Text = String.Empty Then
        ErrorField(I) = "sssn"
        ErrorMsg(I) = "SSN is required"
        I = I + 1
      End If
    End If

    If RbUnmarried.Checked Then
      If TxtSLName.Text <> String.Empty Then
        ErrorField(I) = "slname"
        ErrorMsg(I) = "Last Name is invalid"
        I = I + 1
      End If
      If TxtSFName.Text <> String.Empty Then
        ErrorField(I) = "sfname"
        ErrorMsg(I) = "First Name is invalid"
        I = I + 1
      End If
      If MskTxtSSSN.Text <> String.Empty Then
        ErrorField(I) = "sssn"
        ErrorMsg(I) = "SSN is invalid"
        I = I + 1
      End If
    End If

    If TxtMAddr.Text = String.Empty Then
      ErrorField(I) = "maddr"
      ErrorMsg(I) = "Mailing Address is required"
      I = I + 1
    End If

    If TxtMState.Text = String.Empty Then
      ErrorField(I) = "mstate"
      ErrorMsg(I) = "Mailing State is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtMZip.Text) = 0 Then
      ErrorField(I) = "mzip"
      ErrorMsg(I) = "Mailing Zip is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtPropPct.Text) = 0 And RbAllowed.Checked Then
      ErrorField(I) = "proppct"
      ErrorMsg(I) = "Property Percentage must not be 0 when approved"
      I = I + 1
    End If

    If DtPckAssr.Checked Then
      If Not RbAllowed.Checked And Not RbDisallowed.Checked Then
        ErrorField(I) = "assr"
        ErrorMsg(I) = "Allowed or disallowed must be checked"
        I = I + 1
      End If
    End If

    If RbAllowed.Checked And Trim(TxtDisallowReason.Text) <> "" Then
      ErrorField(I) = "assr"
      ErrorMsg(I) = "Allowed cannot have disallowed reason"
      I = I + 1
    End If

    If RbAllowed.Checked And MyUtils.CnvSng(LblCredit.Text) = 0 Then
      ErrorField(I) = "assr"
      ErrorMsg(I) = "Allowed credit cannot be 0"
      I = I + 1
    End If

    If Not DtPckAssr.Checked Then
      If RbAllowed.Checked Or RbDisallowed.Checked Then
        ErrorField(I) = "assr"
        ErrorMsg(I) = "Assessor signed date is required"
        I = I + 1
      End If
    End If

    If MyLocEld <> "" Then
      If DtPckLocAssr.Checked Then
        If Not RbLocAllowed.Checked And Not RbLocDisallowed.Checked Then
          ErrorField(I) = "lassr"
          ErrorMsg(I) = "Allowed or disallowed must be checked"
          I = I + 1
        End If
      End If
      If Not DtPckLocAssr.Checked Then
        If RbLocAllowed.Checked Or RbLocDisallowed.Checked Then
          ErrorField(I) = "lassr"
          ErrorMsg(I) = "Assessor signed date is required"
          I = I + 1
        End If
      End If
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtListNo, "")
    ErrProv.SetError(TxtYear, "")
    ErrProv.SetError(TxtALName, "")
    ErrProv.SetError(TxtAFName, "")
    ErrProv.SetError(MskTxtASSN, "")
    ErrProv.SetError(TxtSLName, "")
    ErrProv.SetError(TxtSFName, "")
    ErrProv.SetError(MskTxtSSSN, "")
    ErrProv.SetError(TxtMAddr, "")
    ErrProv.SetError(TxtMState, "")
    ErrProv.SetError(TxtMZip, "")
    ErrProv.SetError(TxtPropPct, "")
    ErrProv.SetError(DtPckAssr, "")
    ErrProv.SetError(DtPckLocAssr, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "listno"
          ErrProv.SetError(TxtListNo, ErrorMsg(I))
        Case "year"
          ErrProv.SetError(TxtYear, ErrorMsg(I))
        Case "alname"
          ErrProv.SetError(TxtALName, ErrorMsg(I))
        Case "afname"
          ErrProv.SetError(TxtAFName, ErrorMsg(I))
        Case "assn"
          ErrProv.SetError(MskTxtASSN, ErrorMsg(I))
        Case "slname"
          ErrProv.SetError(TxtSLName, ErrorMsg(I))
        Case "sfname"
          ErrProv.SetError(TxtSFName, ErrorMsg(I))
        Case "sssn"
          ErrProv.SetError(MskTxtSSSN, ErrorMsg(I))
        Case "maddr"
          ErrProv.SetError(TxtMAddr, ErrorMsg(I))
        Case "mcity"
          ErrProv.SetError(TxtMCity, ErrorMsg(I))
        Case "mstate"
          ErrProv.SetError(TxtMState, ErrorMsg(I))
        Case "mzip"
          ErrProv.SetError(TxtMZip, ErrorMsg(I))
        Case "proppct"
          ErrProv.SetError(TxtPropPct, ErrorMsg(I))
        Case "assr"
          ErrProv.SetError(DtPckAssr, ErrorMsg(I))
        Case "lassr"
          ErrProv.SetError(DtPckLocAssr, ErrorMsg(I))
        Case ""
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub FrmTO201D_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTO201.SbpScreen.Text = "TO201D"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub LnkListNo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkListNo.LinkClicked
    MyFrmListRealC = New FrmListRealC
    MyFrmListRealC.MdiParent = Me.ParentForm
    MyFrmListRealC.WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    MyFrmListRealC.Show()
  End Sub
  Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtInterest_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIncome.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtSSRR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSSRR.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtOther_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOther.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtIncome_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIncome.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtPropPct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPropPct.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtGross_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPGross.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBlind_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBlind.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDisabled_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDisabled.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtVet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVet.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtLocal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLocal.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAddlVet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAddlVet.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtTablePct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTablePct.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtCeiling_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCeiling.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtMinGrant_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMinGrant.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub

  Private Sub TxtIncome_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIncome.TextChanged
    CalcTotal()
    CalcTablePct()
    CalcHome()
    CalcCredit(AddMode)
    If MyLocEld <> "" Then
      LblLocCredit.Text = CalcLocEld()
    End If
  End Sub
  Private Sub TxtInterest_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtInterest.TextChanged
    CalcTotal()
    CalcTablePct()
    CalcHome()
    CalcCredit(AddMode)
    If MyLocEld <> "" Then
      LblLocCredit.Text = CalcLocEld()
    End If
  End Sub
  Private Sub TxtSSRR_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSSRR.TextChanged
    CalcTotal()
    CalcTablePct()
    CalcHome()
    CalcCredit(AddMode)
    If MyLocEld <> "" Then
      LblLocCredit.Text = CalcLocEld()
    End If
  End Sub
  Private Sub TxtOther_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOther.TextChanged
    CalcTotal()
    CalcTablePct()
    CalcHome()
    CalcCredit(AddMode)
    If MyLocEld <> "" Then
      LblLocCredit.Text = CalcLocEld()
    End If
  End Sub
  Private Sub TxtBlind_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBlind.TextChanged
    CalcCredit(AddMode)
  End Sub
  Private Sub TxtDisabled_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDisabled.TextChanged
    CalcCredit(AddMode)
  End Sub
  Private Sub TxtVet_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVet.TextChanged
    CalcCredit(AddMode)
  End Sub
  Private Sub TxtLocal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtLocal.TextChanged
    CalcCredit(AddMode)
  End Sub
  Private Sub TxtAddlVet_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAddlVet.TextChanged
    CalcCredit(AddMode)
  End Sub
  Private Sub TxtTablePct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTablePct.TextChanged
    If Not TxtTablePct.Modified Then Exit Sub
    CalcHome()
    CalcCredit(AddMode)
  End Sub
  Private Sub TxtCeiling_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCeiling.TextChanged
    CalcCredit(AddMode)
  End Sub
  Private Sub TxtMinGrant_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMinGrant.TextChanged
    CalcCredit(AddMode)
  End Sub
  Private Sub TxtPropPct_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPropPct.TextChanged
    If Not TxtPropPct.Modified Then Exit Sub
    CalcHome()
    CalcCredit(True)
    If MyLocEld <> "" Then
      LblLocPropPct.Text = TxtPropPct.Text
      LblLocCredit.Text = CalcLocEld()
    End If
  End Sub
  Private Sub TxtPGross_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPGross.TextChanged
    CalcCredit(True)
  End Sub
  Public Sub GetTXREALC()
    Dim WrkAssCode(6) As Integer
    Dim WrkGross(6) As Integer
    Dim WrkLoc As String
    Dim J As Integer
    Dim Pos As Integer
    Dim Pos2 As Integer

    MyTXREALC.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text))
    If MyTXREALC.RecordNotFound Then Exit Sub

    With MyTXREALC
      'Populate First & Last Name
      WrkListNo = ._LISTNO
      TxtName.Text = Trim(._NAME)
      TxtSName.Text = Trim(._SNAME)
      Pos = InStr(TxtName.Text, " ")
      Pos2 = InStr(Pos + 1, TxtName.Text, " ")
      If Pos > 0 Then
        TxtALName.Text = Mid(TxtName.Text, 1, Pos - 1)
        If Pos2 > 0 Then
          TxtAFName.Text = Mid(TxtName.Text, Pos + 1, Pos2 - Pos)
          If Mid(TxtName.Text, Pos2 + 1, 1) <> "&" Then
            TxtAInit.Text = Mid(TxtName.Text, Pos2 + 1, 1)
          End If
        Else
          TxtAFName.Text = Mid(TxtName.Text, Pos + 1, 30)
        End If
      End If
      TxtAFName.Text = Mid(TxtAFName.Text, 1, 10)
      TxtALName.Text = Mid(TxtALName.Text, 1, 20)
      LblALName.Text = TxtALName.Text
      LblAFName.Text = TxtAFName.Text
      LblAInit.Text = TxtAInit.Text
      'Populate Property & Mailing Address
      WrkLoc = Trim(._LOCNO) & " " & Trim(._LOC)
      If Trim(._ADD1) <> WrkLoc Then
        TxtPAddr.Text = WrkLoc
      End If
      TxtMAddr.Text = Trim(._ADD1)
      TxtMCity.Text = Trim(._CITY)
      TxtMState.Text = Trim(._STATE)
      TxtMZip.Text = Format(._ZIP5, "00000")
      If ._CCNO > 0 Then
        TxtPGross.Text = ._CCGRS
        LblGross.Text = MyUtils.Round(._CCGRS * (MyUtils.CnvSng(TxtPropPct.Text) / 100), 0)
      Else
        TxtPGross.Text = ._GROSS
        LblGross.Text = MyUtils.Round(._GROSS * (MyUtils.CnvSng(TxtPropPct.Text) / 100), 0)
      End If
      'Add Gross to Land or Building total
      WrkAssCode(0) = Trim(._CODE1)
      WrkAssCode(1) = Trim(._CODE2)
      WrkAssCode(2) = Trim(._CODE3)
      WrkAssCode(3) = Trim(._CODE4)
      WrkAssCode(4) = Trim(._CODE5)
      WrkAssCode(5) = Trim(._CODE6)
      WrkAssCode(6) = Trim(._CODE7)
      If ._CCNO > 0 Then
        WrkGross(0) = ._CASS1
        WrkGross(1) = ._CASS2
        WrkGross(2) = ._CASS3
        WrkGross(3) = ._CASS4
        WrkGross(4) = ._CASS5
        WrkGross(5) = ._CASS6
        WrkGross(6) = ._CASS7
      Else
        WrkGross(0) = ._ASS1
        WrkGross(1) = ._ASS2
        WrkGross(2) = ._ASS3
        WrkGross(3) = ._ASS4
        WrkGross(4) = ._ASS5
        WrkGross(5) = ._ASS6
        WrkGross(6) = ._ASS7
      End If
      WrkExcludeGross = 0
      For J = 0 To 6
        If WrkAssCode(J) = cExcludeCode1 Or WrkAssCode(J) = cExcludeCode2 _
      Or WrkAssCode(J) = cExcludeCode3 Or WrkAssCode(J) = cExcludeCode4 Then
          WrkExcludeGross = WrkExcludeGross + WrkGross(J)
        End If
      Next J
      If ._CCNO > 0 Then
        LblAppGross.Text = MyUtils.Round((._CCGRS - WrkExcludeGross) * (MyUtils.CnvSng(TxtPropPct.Text) / 100), 0)
        'Exemption Information
        LblExcd1.Text = Trim(._CCCD1)
        LblExcd2.Text = Trim(._CCCD2)
        LblExcd3.Text = Trim(._CCCD3)
        LblExcd4.Text = Trim(._CCCD4)
        LblExcd5.Text = Trim(._CCCD5)
        LblExcd6.Text = Trim(._CCCD6)
        LblExcd7.Text = Trim(._CCCD7)
        If ._CEXA1 > 0 Then
          LblExam1.Text = ._CEXA1
          LblExam2.Text = ._CEXA2
          LblExam3.Text = ._CEXA3
          LblExam4.Text = ._CEXA4
          LblExam5.Text = ._CEXA5
          LblExam6.Text = ._CEXA6
          LblExam7.Text = ._CEXA7
        End If
      Else
        LblAppGross.Text = MyUtils.Round((._GROSS - WrkExcludeGross) * (MyUtils.CnvSng(TxtPropPct.Text) / 100), 0)
        'Exemption Information
        LblExcd1.Text = Trim(._EXCD1)
        LblExcd2.Text = Trim(._EXCD2)
        LblExcd3.Text = Trim(._EXCD3)
        LblExcd4.Text = Trim(._EXCD4)
        LblExcd5.Text = Trim(._EXCD5)
        LblExcd6.Text = Trim(._EXCD6)
        LblExcd7.Text = Trim(._EXCD7)
        If ._EXAM1 > 0 Then
          LblExam1.Text = ._EXAM1
          LblExam2.Text = ._EXAM2
          LblExam3.Text = ._EXAM3
          LblExam4.Text = ._EXAM4
          LblExam5.Text = ._EXAM5
          LblExam6.Text = ._EXAM6
          LblExam7.Text = ._EXAM7
        End If
      End If
      TxtBlind.Text = CalcCat("B")
      TxtDisabled.Text = CalcCat("D")
      TxtVet.Text = CalcCat("V")
      TxtLocal.Text = CalcCat("L") + CalcLocal()
      TxtAddlVet.Text = CalcCat("A")
      LblFrzBenefit.Text = Format(._FTAX, "Fixed")
    End With

  End Sub
  Public Sub GetTXREAL()

    MyTXREAL.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text))
    If MyTXREAL.RecordNotFound Then Exit Sub

    With MyTXREAL
      LblCurBenefit.Text = Format(._FTAX, "Fixed")
    End With

  End Sub
  Private Sub CalcHome()
    Dim WrkTablePct As Decimal
    Dim WrkPropPct As Decimal

    WrkTablePct = MyUtils.CnvSng(TxtTablePct.Text) / 100
    MyTXHOME.GetOneRecordP(WrkTablePct)
    If Not MyTXHOME.RecordNotFound Then
      WrkPropPct = MyUtils.CnvSng(TxtPropPct.Text) / 100
      With MyTXHOME
        TxtCeiling.Text = Format(MyUtils.Round(._CRMAX * WrkPropPct, 2), "Fixed")
        TxtMinGrant.Text = Format(MyUtils.Round(._CRMIN, 2), "Fixed")
      End With
    Else
      TxtCeiling.Text = ""
      TxtMinGrant.Text = ""
    End If
  End Sub
  Private Sub CalcTablePct()
    Dim I As Integer

    For I = 1 To 5
      With MyTXHOIN
        .GetOneRecordP(MyUtils.CnvSng(TxtYear.Text), I)
        If .RecordNotFound Then Exit Sub
        If ._LIMIT >= MyUtils.CnvSng(LblTotal.Text) Then
          If RbMarried.Checked Or RbCivil.Checked Then
            TxtTablePct.Text = MyUtils.Round(._MPERC * 100, 0)
          Else
            TxtTablePct.Text = MyUtils.Round(._UPERC * 100, 0)
          End If
          Exit Sub
        End If
      End With
    Next
    TxtTablePct.Text = String.Empty
  End Sub

  Private Sub CalcTotal()
    Dim WrkTotal As Decimal

    WrkTotal = MyUtils.CnvSng(TxtIncome.Text) + MyUtils.CnvSng(TxtInterest.Text) + MyUtils.CnvSng(TxtSSRR.Text) + MyUtils.CnvSng(TxtOther.Text)
    LblTotal.Text = Format(WrkTotal, "fixed")

  End Sub
  Public Sub CalcCredit(ByVal CalcNet As Boolean)
    Dim WrkAdjGross As Integer
    Dim WrkPropPct As Decimal
    Dim WrkNet As Decimal
    Dim WrkTablePct As Decimal
    Dim WrkTax As Decimal
    Dim WrkCreditMax As Decimal
    Dim WrkLesser As Decimal
    Dim WrkCredit As Decimal
    Dim WrkYear As Decimal

    'If LoadScrn Then Exit Sub
    WrkYear = MyUtils.CnvSng(TxtYear.Text)
    MyTXMRATE.GetOneRecordP(WrkYear, "R", MyUtils.CnvSng(0))
    If MyTXMRATE.RecordNotFound Then
      MyTXMRATE.GetOneRecordP(WrkYear, "", MyUtils.CnvSng(0))
    End If
    If CalcNet Then
      WrkPropPct = MyUtils.CnvSng(TxtPropPct.Text) / 100
      LblGross.Text = MyUtils.Round(MyUtils.CnvSng(TxtPGross.Text) * WrkPropPct, 0)
      WrkAdjGross = MyUtils.CnvSng(LblGross.Text) - (WrkExcludeGross * WrkPropPct)
      LblAppGross.Text = MyUtils.Round(WrkAdjGross, 0)
    Else
      WrkNet = MyUtils.CnvSng(LblNet.Text)
    End If
    WrkNet = MyUtils.CnvSng(LblAppGross.Text) - MyUtils.CnvSng(TxtBlind.Text) - MyUtils.CnvSng(TxtDisabled.Text) -
    MyUtils.CnvSng(TxtVet.Text) - MyUtils.CnvSng(TxtLocal.Text) - MyUtils.CnvSng(TxtAddlVet.Text)
    LblNet.Text = WrkNet
    If MyTXMRATE.RecordNotFound Then Exit Sub

    WrkTablePct = MyUtils.CnvSng(TxtTablePct.Text) / 100
    LblMillRate.Text = Format(MyTXMRATE._MRRATE * 1000, "###.000")

    If MyUtils.CnvSng(TxtFrzTax.Text) > 0 Then
      WrkTax = 0
      LblTax.Text = Format(WrkTax, "fixed")
      WrkCreditMax = MyUtils.CnvSng(TxtFrzTax.Text) * WrkTablePct
    Else
      WrkTax = WrkNet * MyTXMRATE._MRRATE
      With MyTPAYMNT
        .In_Year = WrkYear
        .In_Type = "R"
        .In_Dst = 0
        .In_Phs = ""
        .In_TaxT = WrkTax
        .CalcPaySplit()
        WrkTax = .Out_TaxT
      End With
      LblTax.Text = Format(WrkTax, "fixed")
      WrkCreditMax = WrkTax * WrkTablePct
    End If
    LblCreditMax.Text = Format(WrkCreditMax, "fixed")
    If WrkCreditMax > MyUtils.CnvSng(TxtCeiling.Text) Then
      WrkLesser = MyUtils.CnvSng(TxtCeiling.Text)
    Else
      WrkLesser = WrkCreditMax
    End If
    LblLesser.Text = Format(WrkLesser, "fixed")
    If WrkLesser > MyUtils.CnvSng(TxtMinGrant.Text) Then
      WrkCredit = WrkLesser
    Else
      WrkCredit = MyUtils.CnvSng(TxtMinGrant.Text)
    End If
    With MyTPAYMNT
      .In_Year = WrkYear
      .In_Type = "R"
      .In_Dst = 0
      .In_Phs = ""
      .In_TaxT = WrkCredit
      .CalcPaySplit()
      WrkCredit = .Out_TaxT
    End With
    LblCredit.Text = Format(WrkCredit, "fixed")

  End Sub

  Private Sub LnkTablePct_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTablePct.LinkClicked
    MyFrmListHome = New FrmListHome
    MyFrmListHome.MdiParent = Me.ParentForm
    MyFrmListHome.WrkPct = MyUtils.CnvSng(TxtTablePct.Text)
    MyFrmListHome.WrkPropPct = MyUtils.CnvSng(TxtPropPct.Text)
    MyFrmListHome.Show()
  End Sub
  Private Function CalcCat(ByVal Cat As String) As Integer
    Dim Total As Integer
    Total = 0

    If Trim(MyTXREALC._EXCD1) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, MyTXREALC._EXCD1)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + MyTXREALC._EXAM1
      End If
    End If

    If Trim(MyTXREALC._EXCD2) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, MyTXREALC._EXCD2)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + MyTXREALC._EXAM2
      End If
    End If

    If Trim(MyTXREALC._EXCD3) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, MyTXREALC._EXCD3)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + MyTXREALC._EXAM3
      End If
    End If

    If Trim(MyTXREALC._EXCD4) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, MyTXREALC._EXCD4)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + MyTXREALC._EXAM4
      End If
    End If

    If Trim(MyTXREALC._EXCD5) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, MyTXREALC._EXCD5)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + MyTXREALC._EXAM5
      End If
    End If

    If Trim(MyTXREALC._EXCD6) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, MyTXREALC._EXCD6)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + MyTXREALC._EXAM6
      End If
    End If

    If Trim(MyTXREALC._EXCD7) <> String.Empty Then
      MyTXM35EX.GetOneRecordP(Cat, MyTXREALC._EXCD7)
      If Not MyTXM35EX.RecordNotFound Then
        Total = Total + MyTXREALC._EXAM7
      End If
    End If

    Return Total
  End Function
  Private Function CalcLocal() As Integer
    Dim ds As DataSet = New DataSet
    Dim Total As Integer
    Dim I As Integer

    Total = 0
    ds = MyTXM35EX.GetAllCat("L", String.Empty)
    For I = 0 To ds.Tables(0).Rows.Count - 1
      MyTXLOCAL.GetOneRecordP(WrkListNo, WrkYear, "R", ds.Tables(0).Rows(I).Item("excd"))
      If Not MyTXLOCAL.RecordNotFound Then
        Total = Total + MyTXLOCAL._BENAMT
      End If
    Next

    Return Total
  End Function
  Private Sub CalcLocHB(ByRef WrkLimit As Integer, ByRef WrkBenefit As Decimal)
    Dim I As Integer
    WrkLimit = 0
    WrkBenefit = 0
    For I = 1 To 5
      With MyTXLOCHB
        .GetOneRecordP(MyUtils.CnvSng(TxtYear.Text), I)
        If .RecordNotFound Then Exit Sub
        If ._LIMIT >= MyUtils.CnvSng(LblTotal.Text) Then
          WrkLimit = ._LIMIT
          WrkBenefit = ._BENAMT
          Exit Sub
        End If
      End With
    Next
  End Sub

  Private Sub Tab1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tab1.Click
    LblListNo.Text = TxtListNo.Text
    LblYear.Text = TxtYear.Text
    LblALName.Text = TxtALName.Text
    LblAFName.Text = TxtAFName.Text
    LblAInit.Text = TxtAInit.Text
    If MyLocEld <> "" Then
      LblLocListNo.Text = TxtListNo.Text
      LblLocYear.Text = TxtYear.Text
      LblLocALName.Text = TxtALName.Text
      LblLocAFName.Text = TxtAFName.Text
      LblLocAInit.Text = TxtAInit.Text
      LblLocTotal.Text = LblTotal.Text
      LblLocCredit.Text = CalcLocEld()
    End If

  End Sub
  Private Function CalcLocEld() As Decimal
    Dim WrkStateSingle As Decimal
    Dim WrkStateMarried As Decimal
    Dim WrkMaxTax As Decimal
    Dim WrkTRFAdj As Integer
    Dim WrkTaxLimit As Decimal
    Dim WrkTRF As Decimal
    Dim WrkLocalLimit As Decimal
    Dim WrkDeferLimit As Decimal
    Dim WrkPropPct As Decimal
    Dim WrkYear As Integer
    Dim WrkAmount As Decimal
    Dim WrkAge65by As Integer

    MyFrmTO201.TBarPrint.Enabled = False
    MyFrmTO201.TbarLocal.Enabled = False
    LblLocPgm.Text = ""
    LblLocMarried.Text = ""
    LblLocSingle.Text = ""
    LblDefMarried.Text = ""
    LblDefSingle.Text = ""

    If RbMarried.Checked Then
      LblHdrStSingle.Visible = False
      LblHdrStMarried.Visible = True
      LblHdrDefSingle.Visible = False
      LblHdrDefMarried.Visible = True
      LblLocSingle.Visible = False
      LblLocMarried.Visible = True
      LblStSingle.Visible = False
      LblStMarried.Visible = True
      LblDefSingle.Visible = False
      LblDefMarried.Visible = True
    Else
      LblHdrStSingle.Visible = True
      LblHdrStMarried.Visible = False
      LblHdrDefSingle.Visible = True
      LblHdrDefMarried.Visible = False
      LblLocSingle.Visible = True
      LblLocMarried.Visible = False
      LblStSingle.Visible = True
      LblStMarried.Visible = False
      LblDefSingle.Visible = True
      LblDefMarried.Visible = False
    End If

    WrkYear = MyUtils.CnvSng(TxtYear.Text)
    With MyTXHOIN
      .GetOneRecordP(WrkYear, 5)
      WrkStateMarried = ._LIMIT
      LblStMarried.Text = WrkStateMarried
      .GetOneRecordP(WrkYear, 4)
      WrkStateSingle = ._LIMIT
      LblStSingle.Text = WrkStateSingle
    End With

    If MyLocEld = "032" Then
      MyFrmTO201.TBarPrint.Enabled = True
      If RbNoLoc.Checked Then
        WrkAmount = 0
        LblLocPgm.Text = "LO"
      End If
      If RbLoc212.Checked Then
        WrkAmount = MyUtils.CnvSng(LblCredit.Text)
        LblLocPgm.Text = "212"
        MyFrmTO201.TbarLocal.Enabled = True
      End If
      If RbLoc250.Checked Then
        WrkAmount = Math.Round(MyUtils.CnvSng(LblCredit.Text) * 0.5, 0)
        LblLocPgm.Text = "250"
        MyFrmTO201.TbarLocal.Enabled = True
      End If
      Return WrkAmount
    End If

    If MyLocEld = "035" Then
      MyFrmTO201.TBarPrint.Enabled = True
      With MyTXLOCIN
        LblLocPgm.Text = "LOC"
        .GetOneRecordP(WrkYear, "LOC")
        If RbMarried.Checked Then
          WrkLocalLimit = ._MRYINC + WrkStateMarried
        Else
          WrkLocalLimit = ._SNGINC + WrkStateSingle
        End If
        LblLocMarried.Text = ._MRYINC + WrkStateMarried
        LblLocSingle.Text = ._SNGINC + WrkStateSingle
        WrkPropPct = MyUtils.CnvSng(TxtPropPct.Text) / 100
        If MyUtils.CnvSng(LblTotal.Text) <= WrkLocalLimit Then
          LblLocPgm.Text = "LOC"
          Me.Text = "OPM M35H"
          MyFrmTO201.TbarLocal.Enabled = True
        End If
        'Deferred
        .GetOneRecordP(WrkYear, "DEF")
        If RbMarried.Checked Then
          WrkDeferLimit = ._MRYINC + WrkStateMarried
        Else
          WrkDeferLimit = ._SNGINC + WrkStateSingle
        End If
        LblDefMarried.Text = ._MRYINC + WrkStateMarried
        LblDefSingle.Text = ._SNGINC + WrkStateSingle
      End With

      RbDeferPlanA.Visible = False
      RbDeferPlanB.Visible = False
      If RbNoLoc.Checked Then
        WrkAmount = 0
        RbDeferPlanB.Visible = True
      End If
      If RbLoc.Checked Then
        RbDeferPlanA.Visible = True
      End If
      WrkPropPct = MyUtils.CnvSng(LblLocPropPct.Text) / 100
      With MyTXLOCDA
        .GetOneRecordP(WrkYear)
        If Not .RecordNotFound Then
          WrkMaxTax = ._MAXTAX
          WrkTRFAdj = ._TRFADJ
        Else
          WrkMaxTax = 0
          WrkTRFAdj = 0
        End If
      End With
      If MyUtils.CnvSng(LblTax.Text) > WrkMaxTax Then
        WrkTaxLimit = WrkMaxTax
      Else
        WrkTaxLimit = MyUtils.CnvSng(LblTax.Text)
      End If
      WrkTRF = Math.Round((WrkLocalLimit - MyUtils.CnvSng(LblTotal.Text)) / (WrkLocalLimit - WrkTRFAdj), 3)
      If WrkTRF > 0 Then
        LblTRF.Text = WrkTRF
      Else
        LblTRF.Text = 0
        WrkTRF = 0
      End If
      If RbLoc.Checked Then
        If MyUtils.CnvSng(LblTotal.Text) <= WrkLocalLimit Then
          WrkAmount = Math.Round(WrkTaxLimit * WrkTRF, 2) - MyUtils.CnvSng(LblCredit.Text)
          If WrkAmount > WrkTaxLimit Then
            WrkAmount = Math.Round(WrkTaxLimit * 0.98, 2) - MyUtils.CnvSng(LblCredit.Text) 'Plan A is 2% 
          End If
        Else
          RbDeferPlanA.Visible = False
        End If
      End If
      If RbNoLoc.Checked Then
        If MyUtils.CnvSng(LblTotal.Text) > WrkDeferLimit Then
          RbDeferPlanB.Visible = False
        End If
      End If
      Me.Text = "OPM M35H"
      Return WrkAmount
    End If

    If MyLocEld = "045" Then
      With MyTXLOCHB
        MyFrmTO201.TBarPrint.Enabled = True
        MyFrmTO201.TbarLocal.Enabled = True
        CalcLocHB(WrkLocalLimit, WrkAmount)
        LblLocMarried.Text = WrkLocalLimit
        LblLocSingle.Text = WrkLocalLimit
        LblHdrStSingle.Visible = False
        LblStSingle.Visible = False
        LblHdrStMarried.Visible = False
        LblStMarried.Visible = False
        LblHdrDefMarried.Visible = False
        LblDefMarried.Visible = False
        WrkPropPct = MyUtils.CnvSng(LblLocPropPct.Text) / 100
        WrkAmount = Math.Round(WrkAmount * WrkPropPct, 2)
        LblLocPgm.Text = "LOC"
        Me.Text = "OPM M35H"
        If MyUtils.CnvSng(LblTotal.Text) <= WrkLocalLimit Then
          Return WrkAmount
        End If
      End With
    End If

    If MyLocEld = "084" Then
      'If not disabled then age must be 65 or over for state/local program
      If Not ChkDisabled.Checked Then
        'If Surviving spouse then age must be 50 or over for state/local program
        If RbSurviving.Checked Then
          WrkAge65by = (WrkYear - 50) & 1231
        Else
          WrkAge65by = (WrkYear - 64) & 1231
        End If
        If MyFrmTO201D.TxtSFName.Text = "" Then
          If MyUtils.SetDBDate(MyFrmTO201D.DtPckADOB.Value) > WrkAge65by Then
            Return 0
          End If
        Else
          If MyUtils.SetDBDate(MyFrmTO201D.DtPckADOB.Value) > WrkAge65by And
         MyUtils.SetDBDate(MyFrmTO201D.DtPckSDOB.Value) > WrkAge65by Then
              Return 0
            End If
          End If
        End If

        With MyTXLOCIN
        .GetOneRecordP(WrkYear, "LL")
        If .RecordNotFound Then
          .GetOneRecordP(0, "LL")
        End If
        If RbMarried.Checked Then
          WrkLocalLimit = ._MRYINC + WrkStateMarried
        Else
          WrkLocalLimit = ._SNGINC + WrkStateSingle
        End If
        LblLocMarried.Text = ._MRYINC + WrkStateMarried
        LblLocSingle.Text = ._SNGINC + WrkStateSingle
        WrkPropPct = MyUtils.CnvSng(TxtPropPct.Text) / 100
        If MyUtils.CnvSng(LblTotal.Text) <= WrkLocalLimit Then
          WrkAmount = Math.Round(._AMOUNT * WrkPropPct, 0)
          LblLocPgm.Text = "LL"
          Me.Text = "OPM M35H"
          MyFrmTO201.TBarPrint.Enabled = True
          MyFrmTO201.TbarLocal.Enabled = True
          Return WrkAmount
        End If

        .GetOneRecordP(WrkYear, "LH")
        If .RecordNotFound Then
          .GetOneRecordP(0, "LH")
        End If
        If RbMarried.Checked Then
          WrkLocalLimit = ._MRYINC + WrkStateMarried
        Else
          WrkLocalLimit = ._SNGINC + WrkStateSingle
        End If
        LblLocMarried.Text = ._MRYINC + WrkStateMarried
        LblLocSingle.Text = ._SNGINC + WrkStateSingle
        WrkPropPct = MyUtils.CnvSng(TxtPropPct.Text) / 100
        If MyUtils.CnvSng(LblTotal.Text) <= WrkLocalLimit Then
          WrkAmount = Math.Round(._AMOUNT * WrkPropPct, 0)
          LblLocPgm.Text = "LH"
          MyFrmTO201.TbarLocal.Enabled = True
          Me.Text = "Local Only"
          Return WrkAmount
        End If
      End With

      If MyFrmTO201D.RbLocDisallowed.Checked Then
        LblLocPgm.Text = "LH"
        MyFrmTO201.TbarLocal.Enabled = True
      End If
      Return 0
    End If
  End Function
  Private Function CalcLocalSplit() As Decimal
    Dim dsLocal As DataSet = New DataSet
    Dim WrkYear As Integer
    Dim WrkAmount As Decimal
    Dim I As Integer

    WrkYear = MyUtils.CnvSng(TxtYear.Text)
    WrkAmount = 0
    If MyLocEld <> "" Then
      With MyTXM35PM
        dsLocal = .GetbyListAll(WrkListNo, WrkYear)
        For I = 0 To dsLocal.Tables(0).Rows.Count - 1
          WrkAmount = WrkAmount + dsLocal.Tables(0).Rows(I).Item("benamt")
        Next
      End With
    End If
    Return WrkAmount
  End Function
  Private Function CalcTownBenefit() As Decimal
    Dim ds2 As DataSet = New DataSet
    Dim WrkBenefit As Decimal
    Dim I As Integer

    WrkBenefit = 0
    ds2 = MyTXLOCAL.GetViewbyList(WrkListNo, WrkYear, "R", 100)
    If ds2.Tables(0).Rows.Count > 0 Then
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        WrkBenefit = WrkBenefit + ds2.Tables(0).Rows(I).Item("benamt")
      Next
    End If

    Return WrkBenefit
  End Function
  Private Sub RbAllowed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbAllowed.Click
    LblRE.Text = "Real Estate - Elderly Data"
  End Sub
  Private Sub RbDisallowed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbDisallowed.Click
    LblRE.Text = "Application Disallowed"
  End Sub
  Private Sub RecalcTax(ByVal WrkList As Integer, ByVal WrkYear As Integer,
  ByRef Out_Credit As Decimal, ByRef Out_Min As Decimal, ByRef Out_Max As Decimal)
    Dim ds2 As DataSet = New DataSet
    Dim I As Integer

    Out_Credit = 0
    Out_Min = 0
    Out_Max = 0
    ds2 = MyTXM35H.GetbyList(WrkList, WrkYear)
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        If .Item("allow") = "Y" Then
          Out_Credit = Out_Credit + CalcCreditList(.Item("net"), .Item("pct"), .Item("min"),
          .Item("max"), .Item("frztax"))
          Out_Min = Out_Min + .Item("min")
          Out_Max = Out_Max + .Item("max")
        End If
      End With
    Next
  End Sub
  Private Function CalcCreditList(ByVal WrkNet As Integer, ByVal WrkPct As Integer,
 ByVal WrkMin As Decimal, ByVal WrkMax As Decimal, ByVal WrkFrzTax As Decimal) As Decimal

    Dim WrkTax As Decimal
    Dim WrkCredit As Decimal
    Dim WrkLesser As Decimal
    Dim WrkCreditMax As Decimal

    If WrkFrzTax > 0 Then
      WrkTax = WrkFrzTax
    Else
      WrkTax = WrkNet * MyTXMRATE._MRRATE
    End If
    With MyTPAYMNT
      .In_Year = WrkYear
      .In_Type = "R"
      .In_Dst = 0
      .In_Phs = ""
      .In_TaxT = WrkTax
      .CalcPaySplit()
      WrkTax = .Out_TaxT
    End With

    WrkCreditMax = MyUtils.Round(WrkTax * (WrkPct / 100), 2)
    If WrkCreditMax > WrkMax Then
      WrkLesser = WrkMax
    Else
      WrkLesser = WrkCreditMax
    End If
    If WrkLesser < WrkMin Then
      WrkCredit = WrkMin
    Else
      WrkCredit = WrkLesser
    End If

    With MyTPAYMNT
      .In_Year = WrkYear
      .In_Type = "R"
      .In_Dst = 0
      .In_Phs = ""
      .In_TaxT = WrkCredit
      .CalcPaySplit()
      WrkCredit = .Out_TaxT
    End With

    Return WrkCredit
  End Function
  Private Sub GetFrozenTax(ByVal WrkList As Integer)
    MyTXLOCFRZ.GetOneRecordP(WrkList)
    If MyTXLOCFRZ.RecordNotFound Then Exit Sub

    TxtFrzTax.Text = Format(MyTXLOCFRZ._FRZTAX, "fixed")
  End Sub
  Private Sub TxtListNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtListNo.LostFocus
    Dim WrkListNo As Integer
    Dim WrkYear As Integer
    Dim WrkSeqno As Integer
    GetTXREALC()
    GetTXREAL()
    If Not AddMode Then Exit Sub

    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    WrkYear = MyUtils.CnvSng(TxtYear.Text) - 1
    WrkSeqno = MyUtils.CnvSng(LblSeq.Text)
    MyTXM35H.GetOneRecordP(WrkListNo, WrkYear, WrkSeq)
    If MyTXM35H.RecordNotFound Then
      WrkYear = MyUtils.CnvSng(TxtYear.Text) - 2
      MyTXM35H.GetOneRecordP(WrkListNo, WrkYear, WrkSeq)
    End If
    If Not MyTXM35H.RecordNotFound Then
      With MyTXM35H
        TxtALName.Text = Trim(._ALNAME)
        TxtAFName.Text = Trim(._AFNAME)
        TxtAInit.Text = Trim(._AINIT)
        DtPckADOB.Value = MyUtils.GetDBDate(._ADOB)
        If ._ASSN > 0 Then
          MskTxtASSN.Text = Format(._ASSN, "000000000")
        End If
        TxtSLName.Text = Trim(._SLNAME)
        TxtSFName.Text = Trim(._SFNAME)
        TxtSInit.Text = Trim(._SINIT)
        If ._SDOB > 0 Then
          DtPckSDOB.Value = MyUtils.GetDBDate(._SDOB)
        End If
        If ._SSSN > 0 Then
          MskTxtSSSN.Text = Format(._SSSN, "000000000")
        End If
        TxtPAddr.Text = Trim(._PADDR)
        TxtPCity.Text = Trim(._PCITY)
        TxtPState.Text = Trim(._PSTATE)
        If ._PZIP > 0 Then
          TxtPZip.Text = Format(._PZIP, "00000")
        End If
        TxtOwner.Text = Trim(._OWNER)
        Select Case Trim(._FILING)
          Case "M"
            RbMarried.Checked = True
          Case "U"
            RbUnmarried.Checked = True
          Case "S"
            RbSurviving.Checked = True
        End Select
        ChkNursingHome.Checked = False
        If Trim(._NRSHOM) = "Y" Then
          ChkNursingHome.Checked = True
        End If
        ChkDisabled.Checked = False
        If Trim(._DISAB) = "Y" Then
          ChkDisabled.Checked = True
        End If
        If ._PHONE > 0 Then
          MskTxtPhone.Text = ._PHONE
        End If
        TxtRelate.Text = Trim(._RELATE)
      End With
    End If
    'Local
    If MyLocEld = "032" Then
      With MyTXM35PM
        LblLocTotal.Text = MyUtils.CnvSng(LblTotal.Text)
        LblLocPropPct.Text = MyTXM35H._PROPCT
        .GetOneRecordP(WrkListNo, WrkYear, WrkSeq, "212")
        If .RecordNotFound Then
          .GetOneRecordP(WrkListNo, WrkYear, WrkSeq, "250")
        Else
          RbLoc212.Checked = True
        End If
        If Not .RecordNotFound Then
          'Local
          If Not RbLoc212.Checked Then RbLoc250.Checked = True
          LblLocPgm.Text = Trim(._LOCPM)
          LblLocCredit.Text = ""
        Else
          RbNoLoc.Checked = True
        End If
      End With
    End If
    If MyLocEld = "035" Then
      With MyTXM35PM
        LblLocTotal.Text = MyUtils.CnvSng(LblTotal.Text)
        LblLocPropPct.Text = MyTXM35H._PROPCT
        .GetOneRecordP(WrkListNo, WrkYear, WrkSeq, "LOC")
        If Not .RecordNotFound Then
          'Local
          LblLocPgm.Text = Trim(._LOCPM)
          LblLocCredit.Text = ""
        Else
          RbNoLoc.Checked = True
        End If
      End With
    End If
    MyTXPROF.GetOneRecordP("R", MyUtils.CnvSng(TxtYear.Text), "", 0)
    If Not MyWarnProf Then
      If MyTXPROF.RecordNotFound Then
        MsgBox("Unable to calculate Elderly Benefit", MsgBoxStyle.Exclamation, "WARNING: Missing Tax Profile for R " & MyUtils.CnvSng(TxtYear.Text))
      End If
    End If
  End Sub
  Private Sub RbMarried_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbMarried.Click
    CalcTotal()
    CalcTablePct()
    CalcHome()
    CalcCredit(AddMode)
  End Sub
  Private Sub RbUnmarried_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbUnmarried.Click
    CalcTotal()
    CalcTablePct()
    CalcHome()
    CalcCredit(AddMode)
  End Sub
  Private Sub RbCivil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbCivil.Click
    CalcTotal()
    CalcTablePct()
    CalcHome()
    CalcCredit(AddMode)
  End Sub
  Private Sub RbSurviving_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSurviving.Click
    CalcTotal()
    CalcTablePct()
    CalcHome()
    CalcCredit(AddMode)
  End Sub
  Private Sub RbLocDisallowed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbLocDisallowed.Click
    LblLocCredit.Text = CalcLocEld()
  End Sub
  Private Sub RbNoLoc_Click(sender As Object, e As EventArgs) Handles RbNoLoc.Click
    LblLocCredit.Text = CalcLocEld()
  End Sub
  Private Sub RbLoc_Click(sender As Object, e As EventArgs) Handles RbLoc.Click
    LblLocCredit.Text = CalcLocEld()
  End Sub
  Private Sub RbLoc212_Click(sender As Object, e As EventArgs) Handles RbLoc212.Click
    LblLocCredit.Text = CalcLocEld()
  End Sub
  Private Sub RbLoc250_Click(sender As Object, e As EventArgs) Handles RbLoc250.Click
    LblLocCredit.Text = CalcLocEld()
  End Sub

  Private Sub RbLoc212_CheckedChanged(sender As Object, e As EventArgs) Handles RbLoc212.CheckedChanged

  End Sub
End Class
