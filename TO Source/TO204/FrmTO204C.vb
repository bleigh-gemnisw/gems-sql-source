Public Class FrmTO204C
  Inherits System.Windows.Forms.Form
  Dim MyTXM59A As TXM59A.myData
  Dim MyTXM35H As TXM35H.myData
  Dim MyTXREALC As TXREALC.myData
  Dim MyTXPPRPC As TXPPRPC.myData
  Dim MyTXMVD As TXMVD.myData
  Dim MyTXSUPP As TXSupp.myData
  Dim MyTXHOIN As TXHOIN.myData
  Dim MyTXLOCEX As TXLOCEX.myData
  Dim MyTXM59PM As TXM59PM.myData
  Friend WrkListNo As Integer
  Friend WrkType As String
  Friend WrkYear As Integer
  Dim AddMode As Boolean
  Dim LoadScrn As Boolean
  Dim WrkExcludeGross As Integer

  Friend WithEvents Tab1 As System.Windows.Forms.TabControl
  Friend WithEvents TpApplicant As System.Windows.Forms.TabPage
  Friend WithEvents TxtSLName As System.Windows.Forms.TextBox
  Friend WithEvents TxtALName As System.Windows.Forms.TextBox
  Friend WithEvents TxtMZip As System.Windows.Forms.TextBox
  Friend WithEvents TxtMState As System.Windows.Forms.TextBox
  Friend WithEvents TxtMCity As System.Windows.Forms.TextBox
  Friend WithEvents ChkDisRating As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents RbSingle As System.Windows.Forms.RadioButton
  Friend WithEvents RbMarried As System.Windows.Forms.RadioButton
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
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
  Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
  Friend WithEvents RbDisallowed As System.Windows.Forms.RadioButton
  Friend WithEvents RbAllowed As System.Windows.Forms.RadioButton
  Friend WithEvents LblTotal As System.Windows.Forms.Label
  Friend WithEvents LblYear As System.Windows.Forms.Label
  Friend WithEvents LblListNo As System.Windows.Forms.Label
  Friend WithEvents LblAInit As System.Windows.Forms.Label
  Friend WithEvents LblAFName As System.Windows.Forms.Label
  Friend WithEvents LblALName As System.Windows.Forms.Label
  Friend WithEvents Label51 As System.Windows.Forms.Label
  Friend WithEvents DtPckSigned As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtDisallowReason As System.Windows.Forms.TextBox
  Friend WithEvents DtPckAssr As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label54 As System.Windows.Forms.Label
  Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtSName As System.Windows.Forms.TextBox
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents Label55 As System.Windows.Forms.Label
  Friend WithEvents Label48 As System.Windows.Forms.Label
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents Label24 As System.Windows.Forms.Label
  Friend WithEvents GrpType As System.Windows.Forms.GroupBox
  Friend WithEvents RbSU As System.Windows.Forms.RadioButton
  Friend WithEvents RbRE As System.Windows.Forms.RadioButton
  Friend WithEvents RbMV As System.Windows.Forms.RadioButton
  Friend WithEvents RbPP As System.Windows.Forms.RadioButton
  Friend WithEvents LblTypeDesc As System.Windows.Forms.Label
  Friend WithEvents Label26 As System.Windows.Forms.Label
  Friend WithEvents TxtAddlVet As System.Windows.Forms.TextBox
  Friend WithEvents Label37 As System.Windows.Forms.Label
  Friend WithEvents TxtVet As System.Windows.Forms.TextBox
  Friend WithEvents TxtFullAddl As System.Windows.Forms.TextBox
  Friend WithEvents Label58 As System.Windows.Forms.Label
  Friend WithEvents Label33 As System.Windows.Forms.Label
  Friend WithEvents Label34 As System.Windows.Forms.Label
  Friend WithEvents Label36 As System.Windows.Forms.Label
  Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
  Friend WithEvents Label38 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label39 As System.Windows.Forms.Label
  Friend WithEvents Label40 As System.Windows.Forms.Label
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents Label41 As System.Windows.Forms.Label
  Friend WithEvents Label42 As System.Windows.Forms.Label
  Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label43 As System.Windows.Forms.Label
  Friend WithEvents Label44 As System.Windows.Forms.Label
  Friend WithEvents Label45 As System.Windows.Forms.Label
  Friend WithEvents Label46 As System.Windows.Forms.Label
  Friend WithEvents Label47 As System.Windows.Forms.Label
  Friend WithEvents Label49 As System.Windows.Forms.Label
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
  Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
  Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
  Friend WithEvents Label50 As System.Windows.Forms.Label
  Friend WithEvents Label52 As System.Windows.Forms.Label
  Friend WithEvents Label53 As System.Windows.Forms.Label
  Friend WithEvents Label56 As System.Windows.Forms.Label
  Friend WithEvents Label57 As System.Windows.Forms.Label
  Friend WithEvents Label59 As System.Windows.Forms.Label
  Friend WithEvents Label35 As System.Windows.Forms.Label
  Friend WithEvents Label25 As System.Windows.Forms.Label
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents Label60 As System.Windows.Forms.Label
  Friend WithEvents Label61 As System.Windows.Forms.Label
  Friend WithEvents Label62 As System.Windows.Forms.Label
  Friend WithEvents TxtZip As System.Windows.Forms.TextBox
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents TxtCity As System.Windows.Forms.TextBox
  Friend WithEvents Label63 As System.Windows.Forms.Label
  Friend WithEvents Label64 As System.Windows.Forms.Label
  Friend WithEvents Label65 As System.Windows.Forms.Label
  Friend WithEvents Label66 As System.Windows.Forms.Label
  Friend WithEvents TxtPhone As System.Windows.Forms.TextBox
  Friend WithEvents TxtMAddr As System.Windows.Forms.TextBox
  Friend WithEvents TxtLoc As System.Windows.Forms.TextBox
  Friend WithEvents TxtLocNo As System.Windows.Forms.TextBox
  Friend WithEvents TxtFullLoc As System.Windows.Forms.TextBox
  Friend WithEvents Label31 As System.Windows.Forms.Label
  Friend WithEvents Label32 As System.Windows.Forms.Label
  Friend WithEvents TxtLocal As System.Windows.Forms.TextBox
  Friend WithEvents TpLocal As System.Windows.Forms.TabPage
  Friend WithEvents Label67 As System.Windows.Forms.Label
  Friend WithEvents Label68 As System.Windows.Forms.Label
  Friend WithEvents LblLocSingle As System.Windows.Forms.Label
  Friend WithEvents LblLocMarried As System.Windows.Forms.Label
  Friend WithEvents LblLocPgm As System.Windows.Forms.Label
  Friend WithEvents LblLocCredit As System.Windows.Forms.Label
  Friend WithEvents Label81 As System.Windows.Forms.Label
  Friend WithEvents LblLocTotal As System.Windows.Forms.Label
  Friend WithEvents Label79 As System.Windows.Forms.Label
  Friend WithEvents DtPckLocAssr As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label77 As System.Windows.Forms.Label
  Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtLocDisallowReason As System.Windows.Forms.TextBox
  Friend WithEvents RbLocDisallowed As System.Windows.Forms.RadioButton
  Friend WithEvents RbLocAllowed As System.Windows.Forms.RadioButton
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
  Friend WithEvents LblLocTypeDesc As System.Windows.Forms.Label
  Friend WithEvents Label78 As System.Windows.Forms.Label
  Friend WithEvents LblFBCExam As System.Windows.Forms.Label
  Friend WithEvents LblFBCHdr As System.Windows.Forms.Label
  Friend WithEvents DtPckFBCAssr As System.Windows.Forms.DateTimePicker
  Friend WithEvents LblFBCAssr As System.Windows.Forms.Label
  Friend WithEvents GrpFBC As System.Windows.Forms.GroupBox
  Friend WithEvents TxtFBCDisallowReason As System.Windows.Forms.TextBox
  Friend WithEvents RbFBCDisallowed As System.Windows.Forms.RadioButton
  Friend WithEvents RbFBCAllowed As System.Windows.Forms.RadioButton
  Friend WithEvents LblEBCExam As System.Windows.Forms.Label
  Friend WithEvents LblEBCHdr As System.Windows.Forms.Label
  Friend WithEvents DtPckEBCAssr As System.Windows.Forms.DateTimePicker
  Friend WithEvents LblEBCAssr As System.Windows.Forms.Label
  Friend WithEvents GrpEBC As System.Windows.Forms.GroupBox
  Friend WithEvents TxtEBCDisallowReason As System.Windows.Forms.TextBox
  Friend WithEvents RbEBCDisallowed As System.Windows.Forms.RadioButton
  Friend WithEvents RbEBCAllowed As System.Windows.Forms.RadioButton
  Friend WithEvents ChkNotVet As System.Windows.Forms.CheckBox
  Friend WithEvents ChkLocBlind As System.Windows.Forms.CheckBox
  Friend WithEvents MskTxtSSSN As System.Windows.Forms.MaskedTextBox
  Friend WithEvents MskTxtASSN As System.Windows.Forms.MaskedTextBox
  Friend WithEvents RbWidow As System.Windows.Forms.RadioButton
  Friend WithEvents RbDivorced As System.Windows.Forms.RadioButton
  Friend WithEvents RbLegally As System.Windows.Forms.RadioButton
  Friend WithEvents ChkLocDisabled As System.Windows.Forms.CheckBox


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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTO204C))
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.Tab1 = New System.Windows.Forms.TabControl()
    Me.TpApplicant = New System.Windows.Forms.TabPage()
    Me.MskTxtSSSN = New System.Windows.Forms.MaskedTextBox()
    Me.MskTxtASSN = New System.Windows.Forms.MaskedTextBox()
    Me.ChkNotVet = New System.Windows.Forms.CheckBox()
    Me.ChkLocBlind = New System.Windows.Forms.CheckBox()
    Me.ChkLocDisabled = New System.Windows.Forms.CheckBox()
    Me.TxtLoc = New System.Windows.Forms.TextBox()
    Me.TxtLocNo = New System.Windows.Forms.TextBox()
    Me.Label62 = New System.Windows.Forms.Label()
    Me.TxtZip = New System.Windows.Forms.TextBox()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.Label63 = New System.Windows.Forms.Label()
    Me.Label64 = New System.Windows.Forms.Label()
    Me.Label65 = New System.Windows.Forms.Label()
    Me.Label66 = New System.Windows.Forms.Label()
    Me.GrpType = New System.Windows.Forms.GroupBox()
    Me.RbSU = New System.Windows.Forms.RadioButton()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.RbMV = New System.Windows.Forms.RadioButton()
    Me.RbPP = New System.Windows.Forms.RadioButton()
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.TxtSName = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.TxtPhone = New System.Windows.Forms.TextBox()
    Me.Label51 = New System.Windows.Forms.Label()
    Me.DtPckSigned = New System.Windows.Forms.DateTimePicker()
    Me.TxtSLName = New System.Windows.Forms.TextBox()
    Me.TxtALName = New System.Windows.Forms.TextBox()
    Me.TxtMZip = New System.Windows.Forms.TextBox()
    Me.TxtMState = New System.Windows.Forms.TextBox()
    Me.TxtMAddr = New System.Windows.Forms.TextBox()
    Me.TxtMCity = New System.Windows.Forms.TextBox()
    Me.ChkDisRating = New System.Windows.Forms.CheckBox()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.RbLegally = New System.Windows.Forms.RadioButton()
    Me.RbWidow = New System.Windows.Forms.RadioButton()
    Me.RbDivorced = New System.Windows.Forms.RadioButton()
    Me.RbSingle = New System.Windows.Forms.RadioButton()
    Me.RbMarried = New System.Windows.Forms.RadioButton()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
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
    Me.Label61 = New System.Windows.Forms.Label()
    Me.Label60 = New System.Windows.Forms.Label()
    Me.Label59 = New System.Windows.Forms.Label()
    Me.Label35 = New System.Windows.Forms.Label()
    Me.Label25 = New System.Windows.Forms.Label()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.Label18 = New System.Windows.Forms.Label()
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
    Me.TxtFullLoc = New System.Windows.Forms.TextBox()
    Me.Label31 = New System.Windows.Forms.Label()
    Me.Label32 = New System.Windows.Forms.Label()
    Me.TxtLocal = New System.Windows.Forms.TextBox()
    Me.TxtFullAddl = New System.Windows.Forms.TextBox()
    Me.Label58 = New System.Windows.Forms.Label()
    Me.Label33 = New System.Windows.Forms.Label()
    Me.TxtAddlVet = New System.Windows.Forms.TextBox()
    Me.Label37 = New System.Windows.Forms.Label()
    Me.TxtVet = New System.Windows.Forms.TextBox()
    Me.LblTypeDesc = New System.Windows.Forms.Label()
    Me.Label26 = New System.Windows.Forms.Label()
    Me.DtPckAssr = New System.Windows.Forms.DateTimePicker()
    Me.Label54 = New System.Windows.Forms.Label()
    Me.LblAInit = New System.Windows.Forms.Label()
    Me.LblAFName = New System.Windows.Forms.Label()
    Me.LblALName = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.TxtDisallowReason = New System.Windows.Forms.TextBox()
    Me.RbDisallowed = New System.Windows.Forms.RadioButton()
    Me.RbAllowed = New System.Windows.Forms.RadioButton()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.Label22 = New System.Windows.Forms.Label()
    Me.Label27 = New System.Windows.Forms.Label()
    Me.Label28 = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.TpLocal = New System.Windows.Forms.TabPage()
    Me.LblFBCExam = New System.Windows.Forms.Label()
    Me.LblFBCHdr = New System.Windows.Forms.Label()
    Me.DtPckFBCAssr = New System.Windows.Forms.DateTimePicker()
    Me.LblFBCAssr = New System.Windows.Forms.Label()
    Me.GrpFBC = New System.Windows.Forms.GroupBox()
    Me.TxtFBCDisallowReason = New System.Windows.Forms.TextBox()
    Me.RbFBCDisallowed = New System.Windows.Forms.RadioButton()
    Me.RbFBCAllowed = New System.Windows.Forms.RadioButton()
    Me.LblEBCExam = New System.Windows.Forms.Label()
    Me.LblEBCHdr = New System.Windows.Forms.Label()
    Me.DtPckEBCAssr = New System.Windows.Forms.DateTimePicker()
    Me.LblEBCAssr = New System.Windows.Forms.Label()
    Me.GrpEBC = New System.Windows.Forms.GroupBox()
    Me.TxtEBCDisallowReason = New System.Windows.Forms.TextBox()
    Me.RbEBCDisallowed = New System.Windows.Forms.RadioButton()
    Me.RbEBCAllowed = New System.Windows.Forms.RadioButton()
    Me.LblLocTypeDesc = New System.Windows.Forms.Label()
    Me.Label78 = New System.Windows.Forms.Label()
    Me.Label67 = New System.Windows.Forms.Label()
    Me.Label68 = New System.Windows.Forms.Label()
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
    Me.Label34 = New System.Windows.Forms.Label()
    Me.Label36 = New System.Windows.Forms.Label()
    Me.CheckBox2 = New System.Windows.Forms.CheckBox()
    Me.Label38 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label39 = New System.Windows.Forms.Label()
    Me.Label40 = New System.Windows.Forms.Label()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.Label41 = New System.Windows.Forms.Label()
    Me.Label42 = New System.Windows.Forms.Label()
    Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
    Me.Label43 = New System.Windows.Forms.Label()
    Me.Label44 = New System.Windows.Forms.Label()
    Me.Label45 = New System.Windows.Forms.Label()
    Me.Label46 = New System.Windows.Forms.Label()
    Me.Label47 = New System.Windows.Forms.Label()
    Me.Label49 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.TextBox3 = New System.Windows.Forms.TextBox()
    Me.RadioButton1 = New System.Windows.Forms.RadioButton()
    Me.RadioButton2 = New System.Windows.Forms.RadioButton()
    Me.Label50 = New System.Windows.Forms.Label()
    Me.Label52 = New System.Windows.Forms.Label()
    Me.Label53 = New System.Windows.Forms.Label()
    Me.Label56 = New System.Windows.Forms.Label()
    Me.Label57 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Tab1.SuspendLayout()
    Me.TpApplicant.SuspendLayout()
    Me.GrpType.SuspendLayout()
    Me.GroupBox6.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.TpAssessor.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.TpLocal.SuspendLayout()
    Me.GrpFBC.SuspendLayout()
    Me.GrpEBC.SuspendLayout()
    Me.GroupBox8.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
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
    Me.Tab1.Size = New System.Drawing.Size(771, 623)
    Me.Tab1.TabIndex = 0
    '
    'TpApplicant
    '
    Me.TpApplicant.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.TpApplicant.Controls.Add(Me.MskTxtSSSN)
    Me.TpApplicant.Controls.Add(Me.MskTxtASSN)
    Me.TpApplicant.Controls.Add(Me.ChkNotVet)
    Me.TpApplicant.Controls.Add(Me.ChkLocBlind)
    Me.TpApplicant.Controls.Add(Me.ChkLocDisabled)
    Me.TpApplicant.Controls.Add(Me.TxtLoc)
    Me.TpApplicant.Controls.Add(Me.TxtLocNo)
    Me.TpApplicant.Controls.Add(Me.Label62)
    Me.TpApplicant.Controls.Add(Me.TxtZip)
    Me.TpApplicant.Controls.Add(Me.TxtState)
    Me.TpApplicant.Controls.Add(Me.TxtCity)
    Me.TpApplicant.Controls.Add(Me.Label63)
    Me.TpApplicant.Controls.Add(Me.Label64)
    Me.TpApplicant.Controls.Add(Me.Label65)
    Me.TpApplicant.Controls.Add(Me.Label66)
    Me.TpApplicant.Controls.Add(Me.GrpType)
    Me.TpApplicant.Controls.Add(Me.GroupBox6)
    Me.TpApplicant.Controls.Add(Me.TxtPhone)
    Me.TpApplicant.Controls.Add(Me.Label51)
    Me.TpApplicant.Controls.Add(Me.DtPckSigned)
    Me.TpApplicant.Controls.Add(Me.TxtSLName)
    Me.TpApplicant.Controls.Add(Me.TxtALName)
    Me.TpApplicant.Controls.Add(Me.TxtMZip)
    Me.TpApplicant.Controls.Add(Me.TxtMState)
    Me.TpApplicant.Controls.Add(Me.TxtMAddr)
    Me.TpApplicant.Controls.Add(Me.TxtMCity)
    Me.TpApplicant.Controls.Add(Me.ChkDisRating)
    Me.TpApplicant.Controls.Add(Me.GroupBox4)
    Me.TpApplicant.Controls.Add(Me.Label17)
    Me.TpApplicant.Controls.Add(Me.Label16)
    Me.TpApplicant.Controls.Add(Me.Label14)
    Me.TpApplicant.Controls.Add(Me.Label12)
    Me.TpApplicant.Controls.Add(Me.Label11)
    Me.TpApplicant.Controls.Add(Me.Label10)
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
    Me.TpApplicant.Size = New System.Drawing.Size(763, 596)
    Me.TpApplicant.TabIndex = 0
    Me.TpApplicant.Text = "Applicant Information"
    Me.TpApplicant.UseVisualStyleBackColor = True
    '
    'MskTxtSSSN
    '
    Me.MskTxtSSSN.Location = New System.Drawing.Point(415, 132)
    Me.MskTxtSSSN.Mask = "000-00-0000"
    Me.MskTxtSSSN.Name = "MskTxtSSSN"
    Me.MskTxtSSSN.Size = New System.Drawing.Size(71, 20)
    Me.MskTxtSSSN.TabIndex = 11
    Me.MskTxtSSSN.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'MskTxtASSN
    '
    Me.MskTxtASSN.Location = New System.Drawing.Point(415, 86)
    Me.MskTxtASSN.Mask = "000-00-0000"
    Me.MskTxtASSN.Name = "MskTxtASSN"
    Me.MskTxtASSN.Size = New System.Drawing.Size(71, 20)
    Me.MskTxtASSN.TabIndex = 6
    Me.MskTxtASSN.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'ChkNotVet
    '
    Me.ChkNotVet.AutoSize = True
    Me.ChkNotVet.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkNotVet.Location = New System.Drawing.Point(10, 530)
    Me.ChkNotVet.Name = "ChkNotVet"
    Me.ChkNotVet.Size = New System.Drawing.Size(161, 17)
    Me.ChkNotVet.TabIndex = 237
    Me.ChkNotVet.Text = "Applicant is NOT a Veteran?"
    Me.ChkNotVet.UseVisualStyleBackColor = True
    '
    'ChkLocBlind
    '
    Me.ChkLocBlind.AutoSize = True
    Me.ChkLocBlind.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkLocBlind.Location = New System.Drawing.Point(459, 530)
    Me.ChkLocBlind.Name = "ChkLocBlind"
    Me.ChkLocBlind.Size = New System.Drawing.Size(143, 17)
    Me.ChkLocBlind.TabIndex = 236
    Me.ChkLocBlind.Text = "Local: Is applicant blind?"
    Me.ChkLocBlind.UseVisualStyleBackColor = True
    '
    'ChkLocDisabled
    '
    Me.ChkLocDisabled.AutoSize = True
    Me.ChkLocDisabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkLocDisabled.Location = New System.Drawing.Point(233, 530)
    Me.ChkLocDisabled.Name = "ChkLocDisabled"
    Me.ChkLocDisabled.Size = New System.Drawing.Size(191, 17)
    Me.ChkLocDisabled.TabIndex = 182
    Me.ChkLocDisabled.Text = "Local: Is Applicant totally disabled?"
    Me.ChkLocDisabled.UseVisualStyleBackColor = True
    '
    'TxtLoc
    '
    Me.TxtLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
    Me.TxtLoc.Location = New System.Drawing.Point(75, 166)
    Me.TxtLoc.MaxLength = 25
    Me.TxtLoc.Name = "TxtLoc"
    Me.TxtLoc.Size = New System.Drawing.Size(209, 20)
    Me.TxtLoc.TabIndex = 14
    '
    'TxtLocNo
    '
    Me.TxtLocNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocNo.Location = New System.Drawing.Point(11, 167)
    Me.TxtLocNo.MaxLength = 7
    Me.TxtLocNo.Name = "TxtLocNo"
    Me.TxtLocNo.Size = New System.Drawing.Size(62, 20)
    Me.TxtLocNo.TabIndex = 13
    Me.TxtLocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label62
    '
    Me.Label62.Location = New System.Drawing.Point(618, 191)
    Me.Label62.Name = "Label62"
    Me.Label62.Size = New System.Drawing.Size(74, 13)
    Me.Label62.TabIndex = 181
    Me.Label62.Text = "Phone No"
    Me.Label62.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'TxtZip
    '
    Me.TxtZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip.Location = New System.Drawing.Point(572, 168)
    Me.TxtZip.MaxLength = 5
    Me.TxtZip.Name = "TxtZip"
    Me.TxtZip.Size = New System.Drawing.Size(40, 20)
    Me.TxtZip.TabIndex = 17
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(542, 168)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 20)
    Me.TxtState.TabIndex = 16
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(342, 168)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(191, 20)
    Me.TxtCity.TabIndex = 15
    '
    'Label63
    '
    Me.Label63.AutoSize = True
    Me.Label63.Location = New System.Drawing.Point(577, 191)
    Me.Label63.Name = "Label63"
    Me.Label63.Size = New System.Drawing.Size(25, 13)
    Me.Label63.TabIndex = 180
    Me.Label63.Text = "Zip "
    '
    'Label64
    '
    Me.Label64.AutoSize = True
    Me.Label64.Location = New System.Drawing.Point(539, 191)
    Me.Label64.Name = "Label64"
    Me.Label64.Size = New System.Drawing.Size(32, 13)
    Me.Label64.TabIndex = 179
    Me.Label64.Text = "State"
    '
    'Label65
    '
    Me.Label65.AutoSize = True
    Me.Label65.Location = New System.Drawing.Point(339, 191)
    Me.Label65.Name = "Label65"
    Me.Label65.Size = New System.Drawing.Size(66, 13)
    Me.Label65.TabIndex = 178
    Me.Label65.Text = "City or Town"
    '
    'Label66
    '
    Me.Label66.AutoSize = True
    Me.Label66.Location = New System.Drawing.Point(8, 191)
    Me.Label66.Name = "Label66"
    Me.Label66.Size = New System.Drawing.Size(193, 13)
    Me.Label66.TabIndex = 177
    Me.Label66.Text = "Mailing Address (If different from above)"
    '
    'GrpType
    '
    Me.GrpType.Controls.Add(Me.RbSU)
    Me.GrpType.Controls.Add(Me.RbRE)
    Me.GrpType.Controls.Add(Me.RbMV)
    Me.GrpType.Controls.Add(Me.RbPP)
    Me.GrpType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpType.Location = New System.Drawing.Point(15, 3)
    Me.GrpType.Name = "GrpType"
    Me.GrpType.Size = New System.Drawing.Size(279, 60)
    Me.GrpType.TabIndex = 0
    Me.GrpType.TabStop = False
    Me.GrpType.Text = "Bill Type"
    '
    'RbSU
    '
    Me.RbSU.AutoSize = True
    Me.RbSU.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSU.Location = New System.Drawing.Point(151, 36)
    Me.RbSU.Name = "RbSU"
    Me.RbSU.Size = New System.Drawing.Size(108, 17)
    Me.RbSU.TabIndex = 3
    Me.RbSU.Text = "Supplemental MV"
    '
    'RbRE
    '
    Me.RbRE.AutoSize = True
    Me.RbRE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbRE.Checked = True
    Me.RbRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbRE.Location = New System.Drawing.Point(12, 16)
    Me.RbRE.Name = "RbRE"
    Me.RbRE.Size = New System.Drawing.Size(80, 17)
    Me.RbRE.TabIndex = 0
    Me.RbRE.TabStop = True
    Me.RbRE.Text = "Real Estate"
    '
    'RbMV
    '
    Me.RbMV.AutoSize = True
    Me.RbMV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbMV.Location = New System.Drawing.Point(151, 16)
    Me.RbMV.Name = "RbMV"
    Me.RbMV.Size = New System.Drawing.Size(90, 17)
    Me.RbMV.TabIndex = 2
    Me.RbMV.Text = "Motor Vehicle"
    '
    'RbPP
    '
    Me.RbPP.AutoSize = True
    Me.RbPP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPP.Location = New System.Drawing.Point(12, 36)
    Me.RbPP.Name = "RbPP"
    Me.RbPP.Size = New System.Drawing.Size(108, 17)
    Me.RbPP.TabIndex = 1
    Me.RbPP.Text = "Personal Property"
    '
    'GroupBox6
    '
    Me.GroupBox6.Controls.Add(Me.TxtSName)
    Me.GroupBox6.Controls.Add(Me.TxtName)
    Me.GroupBox6.Location = New System.Drawing.Point(518, 12)
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
    'TxtPhone
    '
    Me.TxtPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhone.Location = New System.Drawing.Point(618, 207)
    Me.TxtPhone.MaxLength = 10
    Me.TxtPhone.Name = "TxtPhone"
    Me.TxtPhone.Size = New System.Drawing.Size(73, 20)
    Me.TxtPhone.TabIndex = 22
    '
    'Label51
    '
    Me.Label51.Location = New System.Drawing.Point(502, 504)
    Me.Label51.Name = "Label51"
    Me.Label51.Size = New System.Drawing.Size(80, 16)
    Me.Label51.TabIndex = 163
    Me.Label51.Text = "Date Signed"
    Me.Label51.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'DtPckSigned
    '
    Me.DtPckSigned.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckSigned.Location = New System.Drawing.Point(588, 500)
    Me.DtPckSigned.Name = "DtPckSigned"
    Me.DtPckSigned.Size = New System.Drawing.Size(88, 20)
    Me.DtPckSigned.TabIndex = 25
    '
    'TxtSLName
    '
    Me.TxtSLName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSLName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSLName.Location = New System.Drawing.Point(11, 129)
    Me.TxtSLName.MaxLength = 20
    Me.TxtSLName.Name = "TxtSLName"
    Me.TxtSLName.Size = New System.Drawing.Size(228, 20)
    Me.TxtSLName.TabIndex = 8
    '
    'TxtALName
    '
    Me.TxtALName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtALName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtALName.Location = New System.Drawing.Point(11, 86)
    Me.TxtALName.MaxLength = 20
    Me.TxtALName.Name = "TxtALName"
    Me.TxtALName.Size = New System.Drawing.Size(228, 20)
    Me.TxtALName.TabIndex = 3
    '
    'TxtMZip
    '
    Me.TxtMZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMZip.Location = New System.Drawing.Point(572, 207)
    Me.TxtMZip.MaxLength = 5
    Me.TxtMZip.Name = "TxtMZip"
    Me.TxtMZip.Size = New System.Drawing.Size(40, 20)
    Me.TxtMZip.TabIndex = 21
    '
    'TxtMState
    '
    Me.TxtMState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMState.Location = New System.Drawing.Point(542, 207)
    Me.TxtMState.MaxLength = 2
    Me.TxtMState.Name = "TxtMState"
    Me.TxtMState.Size = New System.Drawing.Size(24, 20)
    Me.TxtMState.TabIndex = 20
    '
    'TxtMAddr
    '
    Me.TxtMAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMAddr.Location = New System.Drawing.Point(11, 207)
    Me.TxtMAddr.MaxLength = 40
    Me.TxtMAddr.Name = "TxtMAddr"
    Me.TxtMAddr.Size = New System.Drawing.Size(325, 20)
    Me.TxtMAddr.TabIndex = 18
    '
    'TxtMCity
    '
    Me.TxtMCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMCity.Location = New System.Drawing.Point(342, 207)
    Me.TxtMCity.MaxLength = 25
    Me.TxtMCity.Name = "TxtMCity"
    Me.TxtMCity.Size = New System.Drawing.Size(191, 20)
    Me.TxtMCity.TabIndex = 19
    '
    'ChkDisRating
    '
    Me.ChkDisRating.AutoSize = True
    Me.ChkDisRating.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkDisRating.Location = New System.Drawing.Point(15, 502)
    Me.ChkDisRating.Name = "ChkDisRating"
    Me.ChkDisRating.Size = New System.Drawing.Size(436, 17)
    Me.ChkDisRating.TabIndex = 24
    Me.ChkDisRating.Text = "6. Are you presently receiving a 100% disability rating from the Veteran's Admini" &
    "stration?"
    Me.ChkDisRating.UseVisualStyleBackColor = True
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.RbLegally)
    Me.GroupBox4.Controls.Add(Me.RbWidow)
    Me.GroupBox4.Controls.Add(Me.RbDivorced)
    Me.GroupBox4.Controls.Add(Me.RbSingle)
    Me.GroupBox4.Controls.Add(Me.RbMarried)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(7, 233)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(584, 38)
    Me.GroupBox4.TabIndex = 18
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "4. Marital Status"
    '
    'RbLegally
    '
    Me.RbLegally.AutoSize = True
    Me.RbLegally.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbLegally.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbLegally.Location = New System.Drawing.Point(467, 15)
    Me.RbLegally.Name = "RbLegally"
    Me.RbLegally.Size = New System.Drawing.Size(108, 17)
    Me.RbLegally.TabIndex = 4
    Me.RbLegally.Text = "Legally seperated"
    '
    'RbWidow
    '
    Me.RbWidow.AutoSize = True
    Me.RbWidow.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbWidow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbWidow.Location = New System.Drawing.Point(335, 15)
    Me.RbWidow.Name = "RbWidow"
    Me.RbWidow.Size = New System.Drawing.Size(105, 17)
    Me.RbWidow.TabIndex = 3
    Me.RbWidow.Text = "Widow/Widower"
    '
    'RbDivorced
    '
    Me.RbDivorced.AutoSize = True
    Me.RbDivorced.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbDivorced.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbDivorced.Location = New System.Drawing.Point(228, 15)
    Me.RbDivorced.Name = "RbDivorced"
    Me.RbDivorced.Size = New System.Drawing.Size(68, 17)
    Me.RbDivorced.TabIndex = 2
    Me.RbDivorced.Text = "Divorced"
    '
    'RbSingle
    '
    Me.RbSingle.AutoSize = True
    Me.RbSingle.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSingle.Location = New System.Drawing.Point(82, 16)
    Me.RbSingle.Name = "RbSingle"
    Me.RbSingle.Size = New System.Drawing.Size(120, 17)
    Me.RbSingle.TabIndex = 1
    Me.RbSingle.Text = "or Unmarried: Single"
    '
    'RbMarried
    '
    Me.RbMarried.AutoSize = True
    Me.RbMarried.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbMarried.Checked = True
    Me.RbMarried.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbMarried.Location = New System.Drawing.Point(8, 16)
    Me.RbMarried.Name = "RbMarried"
    Me.RbMarried.Size = New System.Drawing.Size(60, 17)
    Me.RbMarried.TabIndex = 0
    Me.RbMarried.TabStop = True
    Me.RbMarried.Text = "Married"
    '
    'Label17
    '
    Me.Label17.AutoSize = True
    Me.Label17.Location = New System.Drawing.Point(577, 152)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(25, 13)
    Me.Label17.TabIndex = 155
    Me.Label17.Text = "Zip "
    '
    'Label16
    '
    Me.Label16.AutoSize = True
    Me.Label16.Location = New System.Drawing.Point(539, 152)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(32, 13)
    Me.Label16.TabIndex = 154
    Me.Label16.Text = "State"
    '
    'Label14
    '
    Me.Label14.AutoSize = True
    Me.Label14.Location = New System.Drawing.Point(339, 152)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(66, 13)
    Me.Label14.TabIndex = 153
    Me.Label14.Text = "City or Town"
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(8, 152)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(102, 13)
    Me.Label12.TabIndex = 152
    Me.Label12.Text = "3. Property Location"
    '
    'Label11
    '
    Me.Label11.Location = New System.Drawing.Point(403, 113)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(101, 16)
    Me.Label11.TabIndex = 151
    Me.Label11.Text = "Social Security No"
    Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(403, 70)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(101, 13)
    Me.Label10.TabIndex = 150
    Me.Label10.Text = "Social Security No"
    Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(349, 110)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(44, 13)
    Me.Label5.TabIndex = 147
    Me.Label5.Text = "(Middle)"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(244, 110)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(32, 13)
    Me.Label6.TabIndex = 146
    Me.Label6.Text = "(First)"
    '
    'TxtSFName
    '
    Me.TxtSFName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSFName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSFName.Location = New System.Drawing.Point(245, 129)
    Me.TxtSFName.MaxLength = 10
    Me.TxtSFName.Name = "TxtSFName"
    Me.TxtSFName.Size = New System.Drawing.Size(114, 20)
    Me.TxtSFName.TabIndex = 9
    '
    'TxtSInit
    '
    Me.TxtSInit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSInit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSInit.Location = New System.Drawing.Point(365, 129)
    Me.TxtSInit.MaxLength = 35
    Me.TxtSInit.Name = "TxtSInit"
    Me.TxtSInit.Size = New System.Drawing.Size(17, 20)
    Me.TxtSInit.TabIndex = 10
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(8, 113)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(122, 13)
    Me.Label7.TabIndex = 145
    Me.Label7.Text = "2. Spouse's Name (Last)"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(349, 69)
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
    Me.TxtAFName.Location = New System.Drawing.Point(245, 86)
    Me.TxtAFName.MaxLength = 10
    Me.TxtAFName.Name = "TxtAFName"
    Me.TxtAFName.Size = New System.Drawing.Size(114, 20)
    Me.TxtAFName.TabIndex = 4
    '
    'TxtAInit
    '
    Me.TxtAInit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAInit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAInit.Location = New System.Drawing.Point(365, 86)
    Me.TxtAInit.MaxLength = 35
    Me.TxtAInit.Name = "TxtAInit"
    Me.TxtAInit.Size = New System.Drawing.Size(17, 20)
    Me.TxtAInit.TabIndex = 5
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(8, 70)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(76, 13)
    Me.Label1.TabIndex = 142
    Me.Label1.Text = "1. Name (Last)"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.Label61)
    Me.GroupBox1.Controls.Add(Me.Label60)
    Me.GroupBox1.Controls.Add(Me.Label59)
    Me.GroupBox1.Controls.Add(Me.Label35)
    Me.GroupBox1.Controls.Add(Me.Label25)
    Me.GroupBox1.Controls.Add(Me.Label24)
    Me.GroupBox1.Controls.Add(Me.Label23)
    Me.GroupBox1.Controls.Add(Me.Label18)
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
    Me.GroupBox1.Location = New System.Drawing.Point(7, 277)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(752, 219)
    Me.GroupBox1.TabIndex = 23
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Qualifying Income (Income from All Sources for Last Calendar Year)"
    '
    'Label61
    '
    Me.Label61.AutoSize = True
    Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label61.Location = New System.Drawing.Point(405, 105)
    Me.Label61.Name = "Label61"
    Me.Label61.Size = New System.Drawing.Size(146, 13)
    Me.Label61.TabIndex = 62
    Me.Label61.Text = "Exclude only if 100% disabled"
    '
    'Label60
    '
    Me.Label60.AutoSize = True
    Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label60.Location = New System.Drawing.Point(31, 118)
    Me.Label60.Name = "Label60"
    Me.Label60.Size = New System.Drawing.Size(256, 13)
    Me.Label60.TabIndex = 61
    Me.Label60.Text = "by the United States Department of Veterans Affairs. "
    '
    'Label59
    '
    Me.Label59.AutoSize = True
    Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label59.Location = New System.Drawing.Point(18, 60)
    Me.Label59.Name = "Label59"
    Me.Label59.Size = New System.Drawing.Size(399, 13)
    Me.Label59.TabIndex = 60
    Me.Label59.Text = "Adjusted Gross Income plus any other income and attach a copy to this application" &
    "."
    '
    'Label35
    '
    Me.Label35.AutoSize = True
    Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label35.Location = New System.Drawing.Point(18, 47)
    Me.Label35.Name = "Label35"
    Me.Label35.Size = New System.Drawing.Size(533, 13)
    Me.Label35.TabIndex = 59
    Me.Label35.Text = "Rent or proceeds from sales of property, etc. If you are required to file a Feder" &
    "al Tax Return, enter the amount of"
    '
    'Label25
    '
    Me.Label25.AutoSize = True
    Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label25.Location = New System.Drawing.Point(18, 34)
    Me.Label25.Name = "Label25"
    Me.Label25.Size = New System.Drawing.Size(667, 13)
    Me.Label25.TabIndex = 58
    Me.Label25.Text = "(Excluding travel allowance), Lottery winnings, Taxable portion of Annunities and" &
    " Pensions, Taxable portion of IRA's, Interest, Dividends, Net"
    '
    'Label24
    '
    Me.Label24.AutoSize = True
    Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label24.Location = New System.Drawing.Point(253, 194)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(171, 13)
    Me.Label24.TabIndex = 57
    Me.Label24.Text = "considered income for this program"
    '
    'Label23
    '
    Me.Label23.AutoSize = True
    Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label23.Location = New System.Drawing.Point(212, 194)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(40, 13)
    Me.Label23.TabIndex = 56
    Me.Label23.Text = "are not"
    '
    'Label18
    '
    Me.Label18.AutoSize = True
    Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label18.Location = New System.Drawing.Point(17, 194)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(179, 13)
    Me.Label18.TabIndex = 55
    Me.Label18.Text = "NOTE: Veteran's Disability payments"
    '
    'Label55
    '
    Me.Label55.AutoSize = True
    Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label55.Location = New System.Drawing.Point(17, 170)
    Me.Label55.Name = "Label55"
    Me.Label55.Size = New System.Drawing.Size(85, 13)
    Me.Label55.TabIndex = 54
    Me.Label55.Text = "not listed above."
    '
    'Label48
    '
    Me.Label48.AutoSize = True
    Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label48.Location = New System.Drawing.Point(17, 156)
    Me.Label48.Name = "Label48"
    Me.Label48.Size = New System.Drawing.Size(441, 13)
    Me.Label48.TabIndex = 53
    Me.Label48.Text = "State of Connecticut public assistance payments, General Assistance, and any othe" &
    "r income"
    '
    'LblTotal
    '
    Me.LblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotal.Location = New System.Drawing.Point(672, 187)
    Me.LblTotal.Name = "LblTotal"
    Me.LblTotal.Size = New System.Drawing.Size(64, 18)
    Me.LblTotal.TabIndex = 52
    Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label21
    '
    Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label21.Location = New System.Drawing.Point(585, 187)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(81, 20)
    Me.Label21.TabIndex = 50
    Me.Label21.Text = "E: TOTAL "
    Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'TxtOther
    '
    Me.TxtOther.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOther.Location = New System.Drawing.Point(672, 140)
    Me.TxtOther.MaxLength = 11
    Me.TxtOther.Name = "TxtOther"
    Me.TxtOther.Size = New System.Drawing.Size(66, 20)
    Me.TxtOther.TabIndex = 48
    Me.TxtOther.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label20
    '
    Me.Label20.AutoSize = True
    Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label20.Location = New System.Drawing.Point(6, 140)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(502, 13)
    Me.Label20.TabIndex = 49
    Me.Label20.Text = "D: ANY INCOME NOT REFLECTED IN THE ABOVE - Examples: Federal Supplemental Securit" &
    "y Income,"
    '
    'TxtSSRR
    '
    Me.TxtSSRR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSSRR.Location = New System.Drawing.Point(672, 108)
    Me.TxtSSRR.MaxLength = 11
    Me.TxtSSRR.Name = "TxtSSRR"
    Me.TxtSSRR.Size = New System.Drawing.Size(66, 20)
    Me.TxtSSRR.TabIndex = 46
    Me.TxtSSRR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label15
    '
    Me.Label15.AutoSize = True
    Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label15.Location = New System.Drawing.Point(7, 105)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(392, 13)
    Me.Label15.TabIndex = 47
    Me.Label15.Text = "C: SOCIAL SECURITY OR RAILROAD RETIREMENT INCOME - (Gross Amount)"
    '
    'TxtInterest
    '
    Me.TxtInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtInterest.Location = New System.Drawing.Point(672, 82)
    Me.TxtInterest.MaxLength = 11
    Me.TxtInterest.Name = "TxtInterest"
    Me.TxtInterest.Size = New System.Drawing.Size(66, 20)
    Me.TxtInterest.TabIndex = 44
    Me.TxtInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(6, 82)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(418, 13)
    Me.Label3.TabIndex = 45
    Me.Label3.Text = "B: NON-TAXABLE INTEREST - Example: Interest from Tax Exempt Government Bonds"
    '
    'TxtIncome
    '
    Me.TxtIncome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtIncome.Location = New System.Drawing.Point(672, 56)
    Me.TxtIncome.MaxLength = 11
    Me.TxtIncome.Name = "TxtIncome"
    Me.TxtIncome.Size = New System.Drawing.Size(66, 20)
    Me.TxtIncome.TabIndex = 0
    Me.TxtIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label19
    '
    Me.Label19.AutoSize = True
    Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label19.Location = New System.Drawing.Point(7, 21)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(496, 13)
    Me.Label19.TabIndex = 43
    Me.Label19.Text = "A. GROSS INCOME - Examples: Wages, Bonuses, Commissions, Fees, Gratuties, Payment" &
    " for Jury Duty"
    '
    'LnkListNo
    '
    Me.LnkListNo.Location = New System.Drawing.Point(315, 32)
    Me.LnkListNo.Name = "LnkListNo"
    Me.LnkListNo.Size = New System.Drawing.Size(44, 13)
    Me.LnkListNo.TabIndex = 141
    Me.LnkListNo.TabStop = True
    Me.LnkListNo.Text = "List No"
    '
    'TxtYear
    '
    Me.TxtYear.Location = New System.Drawing.Point(472, 28)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtYear.TabIndex = 2
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(431, 28)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(35, 17)
    Me.Label13.TabIndex = 140
    Me.Label13.Text = "Year"
    '
    'TxtListNo
    '
    Me.TxtListNo.Location = New System.Drawing.Point(369, 28)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(62, 20)
    Me.TxtListNo.TabIndex = 1
    '
    'TpAssessor
    '
    Me.TpAssessor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.TpAssessor.Controls.Add(Me.TxtFullLoc)
    Me.TpAssessor.Controls.Add(Me.Label31)
    Me.TpAssessor.Controls.Add(Me.Label32)
    Me.TpAssessor.Controls.Add(Me.TxtLocal)
    Me.TpAssessor.Controls.Add(Me.TxtFullAddl)
    Me.TpAssessor.Controls.Add(Me.Label58)
    Me.TpAssessor.Controls.Add(Me.Label33)
    Me.TpAssessor.Controls.Add(Me.TxtAddlVet)
    Me.TpAssessor.Controls.Add(Me.Label37)
    Me.TpAssessor.Controls.Add(Me.TxtVet)
    Me.TpAssessor.Controls.Add(Me.LblTypeDesc)
    Me.TpAssessor.Controls.Add(Me.Label26)
    Me.TpAssessor.Controls.Add(Me.DtPckAssr)
    Me.TpAssessor.Controls.Add(Me.Label54)
    Me.TpAssessor.Controls.Add(Me.LblAInit)
    Me.TpAssessor.Controls.Add(Me.LblAFName)
    Me.TpAssessor.Controls.Add(Me.LblALName)
    Me.TpAssessor.Controls.Add(Me.LblYear)
    Me.TpAssessor.Controls.Add(Me.LblListNo)
    Me.TpAssessor.Controls.Add(Me.GroupBox5)
    Me.TpAssessor.Controls.Add(Me.Label30)
    Me.TpAssessor.Controls.Add(Me.Label22)
    Me.TpAssessor.Controls.Add(Me.Label27)
    Me.TpAssessor.Controls.Add(Me.Label28)
    Me.TpAssessor.Controls.Add(Me.Label29)
    Me.TpAssessor.ImageIndex = 0
    Me.TpAssessor.Location = New System.Drawing.Point(4, 23)
    Me.TpAssessor.Name = "TpAssessor"
    Me.TpAssessor.Padding = New System.Windows.Forms.Padding(3)
    Me.TpAssessor.Size = New System.Drawing.Size(763, 596)
    Me.TpAssessor.TabIndex = 1
    Me.TpAssessor.Text = "Assessor"
    Me.TpAssessor.UseVisualStyleBackColor = True
    '
    'TxtFullLoc
    '
    Me.TxtFullLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFullLoc.Location = New System.Drawing.Point(352, 209)
    Me.TxtFullLoc.MaxLength = 8
    Me.TxtFullLoc.Name = "TxtFullLoc"
    Me.TxtFullLoc.Size = New System.Drawing.Size(66, 20)
    Me.TxtFullLoc.TabIndex = 4
    Me.TxtFullLoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label31
    '
    Me.Label31.AutoSize = True
    Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label31.Location = New System.Drawing.Point(32, 212)
    Me.Label31.Name = "Label31"
    Me.Label31.Size = New System.Drawing.Size(304, 13)
    Me.Label31.TabIndex = 211
    Me.Label31.Text = "(if less than full additional exemption used, Note Full Exemption)"
    '
    'Label32
    '
    Me.Label32.AutoSize = True
    Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label32.Location = New System.Drawing.Point(13, 190)
    Me.Label32.Name = "Label32"
    Me.Label32.Size = New System.Drawing.Size(375, 13)
    Me.Label32.TabIndex = 210
    Me.Label32.Text = "10. Additional Exemption Allowed:  PUBLIC ACT 13-224 MUNICIPAL OPTION"
    '
    'TxtLocal
    '
    Me.TxtLocal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocal.Location = New System.Drawing.Point(421, 185)
    Me.TxtLocal.MaxLength = 8
    Me.TxtLocal.Name = "TxtLocal"
    Me.TxtLocal.Size = New System.Drawing.Size(66, 20)
    Me.TxtLocal.TabIndex = 3
    Me.TxtLocal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtFullAddl
    '
    Me.TxtFullAddl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFullAddl.Location = New System.Drawing.Point(352, 159)
    Me.TxtFullAddl.MaxLength = 8
    Me.TxtFullAddl.Name = "TxtFullAddl"
    Me.TxtFullAddl.Size = New System.Drawing.Size(66, 20)
    Me.TxtFullAddl.TabIndex = 2
    Me.TxtFullAddl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label58
    '
    Me.Label58.AutoSize = True
    Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label58.Location = New System.Drawing.Point(32, 162)
    Me.Label58.Name = "Label58"
    Me.Label58.Size = New System.Drawing.Size(304, 13)
    Me.Label58.TabIndex = 207
    Me.Label58.Text = "(if less than full additional exemption used, Note Full Exemption)"
    '
    'Label33
    '
    Me.Label33.AutoSize = True
    Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label33.Location = New System.Drawing.Point(11, 139)
    Me.Label33.Name = "Label33"
    Me.Label33.Size = New System.Drawing.Size(239, 13)
    Me.Label33.TabIndex = 206
    Me.Label33.Text = "9. Additional Exemption Allowed (""B"" Code Used)"
    '
    'TxtAddlVet
    '
    Me.TxtAddlVet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAddlVet.Location = New System.Drawing.Point(421, 134)
    Me.TxtAddlVet.MaxLength = 8
    Me.TxtAddlVet.Name = "TxtAddlVet"
    Me.TxtAddlVet.Size = New System.Drawing.Size(66, 20)
    Me.TxtAddlVet.TabIndex = 1
    Me.TxtAddlVet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label37
    '
    Me.Label37.AutoSize = True
    Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label37.Location = New System.Drawing.Point(11, 108)
    Me.Label37.Name = "Label37"
    Me.Label37.Size = New System.Drawing.Size(354, 13)
    Me.Label37.TabIndex = 199
    Me.Label37.Text = "8. The Applicant is receiving the following veteran's exemption (""A"" Code)"
    '
    'TxtVet
    '
    Me.TxtVet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVet.Location = New System.Drawing.Point(421, 105)
    Me.TxtVet.MaxLength = 8
    Me.TxtVet.Name = "TxtVet"
    Me.TxtVet.Size = New System.Drawing.Size(66, 20)
    Me.TxtVet.TabIndex = 0
    Me.TxtVet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblTypeDesc
    '
    Me.LblTypeDesc.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTypeDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTypeDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTypeDesc.Location = New System.Drawing.Point(50, 22)
    Me.LblTypeDesc.Name = "LblTypeDesc"
    Me.LblTypeDesc.Size = New System.Drawing.Size(134, 18)
    Me.LblTypeDesc.TabIndex = 195
    Me.LblTypeDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label26
    '
    Me.Label26.AutoSize = True
    Me.Label26.Location = New System.Drawing.Point(13, 23)
    Me.Label26.Name = "Label26"
    Me.Label26.Size = New System.Drawing.Size(31, 13)
    Me.Label26.TabIndex = 196
    Me.Label26.Text = "Type"
    '
    'DtPckAssr
    '
    Me.DtPckAssr.Checked = False
    Me.DtPckAssr.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckAssr.Location = New System.Drawing.Point(143, 310)
    Me.DtPckAssr.Name = "DtPckAssr"
    Me.DtPckAssr.ShowCheckBox = True
    Me.DtPckAssr.Size = New System.Drawing.Size(100, 20)
    Me.DtPckAssr.TabIndex = 5
    '
    'Label54
    '
    Me.Label54.Location = New System.Drawing.Point(13, 314)
    Me.Label54.Name = "Label54"
    Me.Label54.Size = New System.Drawing.Size(124, 16)
    Me.Label54.TabIndex = 180
    Me.Label54.Text = "Date Assessor Signed"
    '
    'LblAInit
    '
    Me.LblAInit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAInit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAInit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAInit.Location = New System.Drawing.Point(368, 67)
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
    Me.LblAFName.Location = New System.Drawing.Point(248, 67)
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
    Me.LblALName.Location = New System.Drawing.Point(14, 67)
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
    Me.LblYear.Location = New System.Drawing.Point(352, 23)
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
    Me.LblListNo.Location = New System.Drawing.Point(247, 22)
    Me.LblListNo.Name = "LblListNo"
    Me.LblListNo.Size = New System.Drawing.Size(56, 18)
    Me.LblListNo.TabIndex = 0
    Me.LblListNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.TxtDisallowReason)
    Me.GroupBox5.Controls.Add(Me.RbDisallowed)
    Me.GroupBox5.Controls.Add(Me.RbAllowed)
    Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox5.Location = New System.Drawing.Point(8, 236)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(479, 66)
    Me.GroupBox5.TabIndex = 4
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
    Me.TxtDisallowReason.TabIndex = 0
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
    'Label30
    '
    Me.Label30.AutoSize = True
    Me.Label30.Location = New System.Drawing.Point(201, 25)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(40, 13)
    Me.Label30.TabIndex = 155
    Me.Label30.Text = "List No"
    '
    'Label22
    '
    Me.Label22.AutoSize = True
    Me.Label22.Location = New System.Drawing.Point(349, 54)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(44, 13)
    Me.Label22.TabIndex = 154
    Me.Label22.Text = "(Middle)"
    '
    'Label27
    '
    Me.Label27.AutoSize = True
    Me.Label27.Location = New System.Drawing.Point(244, 54)
    Me.Label27.Name = "Label27"
    Me.Label27.Size = New System.Drawing.Size(32, 13)
    Me.Label27.TabIndex = 153
    Me.Label27.Text = "(First)"
    '
    'Label28
    '
    Me.Label28.AutoSize = True
    Me.Label28.Location = New System.Drawing.Point(11, 54)
    Me.Label28.Name = "Label28"
    Me.Label28.Size = New System.Drawing.Size(64, 13)
    Me.Label28.TabIndex = 152
    Me.Label28.Text = "Name (Last)"
    '
    'Label29
    '
    Me.Label29.AutoSize = True
    Me.Label29.Location = New System.Drawing.Point(315, 24)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(29, 13)
    Me.Label29.TabIndex = 150
    Me.Label29.Text = "Year"
    '
    'TpLocal
    '
    Me.TpLocal.Controls.Add(Me.LblFBCExam)
    Me.TpLocal.Controls.Add(Me.LblFBCHdr)
    Me.TpLocal.Controls.Add(Me.DtPckFBCAssr)
    Me.TpLocal.Controls.Add(Me.LblFBCAssr)
    Me.TpLocal.Controls.Add(Me.GrpFBC)
    Me.TpLocal.Controls.Add(Me.LblEBCExam)
    Me.TpLocal.Controls.Add(Me.LblEBCHdr)
    Me.TpLocal.Controls.Add(Me.DtPckEBCAssr)
    Me.TpLocal.Controls.Add(Me.LblEBCAssr)
    Me.TpLocal.Controls.Add(Me.GrpEBC)
    Me.TpLocal.Controls.Add(Me.LblLocTypeDesc)
    Me.TpLocal.Controls.Add(Me.Label78)
    Me.TpLocal.Controls.Add(Me.Label67)
    Me.TpLocal.Controls.Add(Me.Label68)
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
    Me.TpLocal.Size = New System.Drawing.Size(763, 596)
    Me.TpLocal.TabIndex = 2
    Me.TpLocal.Text = "Local"
    Me.TpLocal.UseVisualStyleBackColor = True
    '
    'LblFBCExam
    '
    Me.LblFBCExam.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblFBCExam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblFBCExam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFBCExam.Location = New System.Drawing.Point(576, 380)
    Me.LblFBCExam.Name = "LblFBCExam"
    Me.LblFBCExam.Size = New System.Drawing.Size(66, 18)
    Me.LblFBCExam.TabIndex = 264
    Me.LblFBCExam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblFBCHdr
    '
    Me.LblFBCHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFBCHdr.Location = New System.Drawing.Point(506, 383)
    Me.LblFBCHdr.Name = "LblFBCHdr"
    Me.LblFBCHdr.Size = New System.Drawing.Size(64, 15)
    Me.LblFBCHdr.TabIndex = 263
    Me.LblFBCHdr.Text = "Exemption"
    '
    'DtPckFBCAssr
    '
    Me.DtPckFBCAssr.Checked = False
    Me.DtPckFBCAssr.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFBCAssr.Location = New System.Drawing.Point(153, 428)
    Me.DtPckFBCAssr.Name = "DtPckFBCAssr"
    Me.DtPckFBCAssr.ShowCheckBox = True
    Me.DtPckFBCAssr.Size = New System.Drawing.Size(100, 20)
    Me.DtPckFBCAssr.TabIndex = 262
    '
    'LblFBCAssr
    '
    Me.LblFBCAssr.Location = New System.Drawing.Point(23, 432)
    Me.LblFBCAssr.Name = "LblFBCAssr"
    Me.LblFBCAssr.Size = New System.Drawing.Size(124, 16)
    Me.LblFBCAssr.TabIndex = 261
    Me.LblFBCAssr.Text = "Date Assessor Signed"
    '
    'GrpFBC
    '
    Me.GrpFBC.Controls.Add(Me.TxtFBCDisallowReason)
    Me.GrpFBC.Controls.Add(Me.RbFBCDisallowed)
    Me.GrpFBC.Controls.Add(Me.RbFBCAllowed)
    Me.GrpFBC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpFBC.Location = New System.Drawing.Point(18, 354)
    Me.GrpFBC.Name = "GrpFBC"
    Me.GrpFBC.Size = New System.Drawing.Size(479, 66)
    Me.GrpFBC.TabIndex = 260
    Me.GrpFBC.TabStop = False
    Me.GrpFBC.Text = "FBC Assessor Affidavit"
    '
    'TxtFBCDisallowReason
    '
    Me.TxtFBCDisallowReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFBCDisallowReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFBCDisallowReason.Location = New System.Drawing.Point(270, 40)
    Me.TxtFBCDisallowReason.MaxLength = 30
    Me.TxtFBCDisallowReason.Name = "TxtFBCDisallowReason"
    Me.TxtFBCDisallowReason.Size = New System.Drawing.Size(180, 20)
    Me.TxtFBCDisallowReason.TabIndex = 167
    '
    'RbFBCDisallowed
    '
    Me.RbFBCDisallowed.AutoSize = True
    Me.RbFBCDisallowed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFBCDisallowed.Location = New System.Drawing.Point(8, 40)
    Me.RbFBCDisallowed.Name = "RbFBCDisallowed"
    Me.RbFBCDisallowed.Size = New System.Drawing.Size(246, 17)
    Me.RbFBCDisallowed.TabIndex = 2
    Me.RbFBCDisallowed.Text = "This claim is disallowed for the following reason"
    '
    'RbFBCAllowed
    '
    Me.RbFBCAllowed.AutoSize = True
    Me.RbFBCAllowed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFBCAllowed.Location = New System.Drawing.Point(8, 16)
    Me.RbFBCAllowed.Name = "RbFBCAllowed"
    Me.RbFBCAllowed.Size = New System.Drawing.Size(442, 17)
    Me.RbFBCAllowed.TabIndex = 0
    Me.RbFBCAllowed.Text = "I am satified that the above name applicant meet all the necessary statutory requ" &
    "irements"
    '
    'LblEBCExam
    '
    Me.LblEBCExam.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblEBCExam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblEBCExam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblEBCExam.Location = New System.Drawing.Point(576, 272)
    Me.LblEBCExam.Name = "LblEBCExam"
    Me.LblEBCExam.Size = New System.Drawing.Size(66, 18)
    Me.LblEBCExam.TabIndex = 259
    Me.LblEBCExam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblEBCHdr
    '
    Me.LblEBCHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblEBCHdr.Location = New System.Drawing.Point(506, 276)
    Me.LblEBCHdr.Name = "LblEBCHdr"
    Me.LblEBCHdr.Size = New System.Drawing.Size(64, 15)
    Me.LblEBCHdr.TabIndex = 258
    Me.LblEBCHdr.Text = "Exemption"
    '
    'DtPckEBCAssr
    '
    Me.DtPckEBCAssr.Checked = False
    Me.DtPckEBCAssr.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckEBCAssr.Location = New System.Drawing.Point(153, 320)
    Me.DtPckEBCAssr.Name = "DtPckEBCAssr"
    Me.DtPckEBCAssr.ShowCheckBox = True
    Me.DtPckEBCAssr.Size = New System.Drawing.Size(100, 20)
    Me.DtPckEBCAssr.TabIndex = 257
    '
    'LblEBCAssr
    '
    Me.LblEBCAssr.Location = New System.Drawing.Point(23, 324)
    Me.LblEBCAssr.Name = "LblEBCAssr"
    Me.LblEBCAssr.Size = New System.Drawing.Size(124, 16)
    Me.LblEBCAssr.TabIndex = 256
    Me.LblEBCAssr.Text = "Date Assessor Signed"
    '
    'GrpEBC
    '
    Me.GrpEBC.Controls.Add(Me.TxtEBCDisallowReason)
    Me.GrpEBC.Controls.Add(Me.RbEBCDisallowed)
    Me.GrpEBC.Controls.Add(Me.RbEBCAllowed)
    Me.GrpEBC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpEBC.Location = New System.Drawing.Point(18, 246)
    Me.GrpEBC.Name = "GrpEBC"
    Me.GrpEBC.Size = New System.Drawing.Size(479, 66)
    Me.GrpEBC.TabIndex = 255
    Me.GrpEBC.TabStop = False
    Me.GrpEBC.Text = "EBC Assessor Affidavit"
    '
    'TxtEBCDisallowReason
    '
    Me.TxtEBCDisallowReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtEBCDisallowReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtEBCDisallowReason.Location = New System.Drawing.Point(270, 40)
    Me.TxtEBCDisallowReason.MaxLength = 30
    Me.TxtEBCDisallowReason.Name = "TxtEBCDisallowReason"
    Me.TxtEBCDisallowReason.Size = New System.Drawing.Size(180, 20)
    Me.TxtEBCDisallowReason.TabIndex = 167
    '
    'RbEBCDisallowed
    '
    Me.RbEBCDisallowed.AutoSize = True
    Me.RbEBCDisallowed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbEBCDisallowed.Location = New System.Drawing.Point(8, 40)
    Me.RbEBCDisallowed.Name = "RbEBCDisallowed"
    Me.RbEBCDisallowed.Size = New System.Drawing.Size(246, 17)
    Me.RbEBCDisallowed.TabIndex = 2
    Me.RbEBCDisallowed.Text = "This claim is disallowed for the following reason"
    '
    'RbEBCAllowed
    '
    Me.RbEBCAllowed.AutoSize = True
    Me.RbEBCAllowed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbEBCAllowed.Location = New System.Drawing.Point(8, 16)
    Me.RbEBCAllowed.Name = "RbEBCAllowed"
    Me.RbEBCAllowed.Size = New System.Drawing.Size(442, 17)
    Me.RbEBCAllowed.TabIndex = 0
    Me.RbEBCAllowed.Text = "I am satified that the above name applicant meet all the necessary statutory requ" &
    "irements"
    '
    'LblLocTypeDesc
    '
    Me.LblLocTypeDesc.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocTypeDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocTypeDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocTypeDesc.Location = New System.Drawing.Point(72, 9)
    Me.LblLocTypeDesc.Name = "LblLocTypeDesc"
    Me.LblLocTypeDesc.Size = New System.Drawing.Size(134, 18)
    Me.LblLocTypeDesc.TabIndex = 253
    Me.LblLocTypeDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label78
    '
    Me.Label78.AutoSize = True
    Me.Label78.Location = New System.Drawing.Point(15, 9)
    Me.Label78.Name = "Label78"
    Me.Label78.Size = New System.Drawing.Size(31, 13)
    Me.Label78.TabIndex = 254
    Me.Label78.Text = "Type"
    '
    'Label67
    '
    Me.Label67.AutoSize = True
    Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label67.Location = New System.Drawing.Point(503, 177)
    Me.Label67.Name = "Label67"
    Me.Label67.Size = New System.Drawing.Size(93, 17)
    Me.Label67.TabIndex = 251
    Me.Label67.Text = "Married Limit "
    '
    'Label68
    '
    Me.Label68.AutoSize = True
    Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label68.Location = New System.Drawing.Point(503, 153)
    Me.Label68.Name = "Label68"
    Me.Label68.Size = New System.Drawing.Size(84, 17)
    Me.Label68.TabIndex = 250
    Me.Label68.Text = "Single Limit "
    '
    'LblLocSingle
    '
    Me.LblLocSingle.AutoSize = True
    Me.LblLocSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocSingle.Location = New System.Drawing.Point(598, 153)
    Me.LblLocSingle.Name = "LblLocSingle"
    Me.LblLocSingle.Size = New System.Drawing.Size(61, 17)
    Me.LblLocSingle.TabIndex = 249
    Me.LblLocSingle.Text = "<single>"
    '
    'LblLocMarried
    '
    Me.LblLocMarried.AutoSize = True
    Me.LblLocMarried.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocMarried.Location = New System.Drawing.Point(596, 177)
    Me.LblLocMarried.Name = "LblLocMarried"
    Me.LblLocMarried.Size = New System.Drawing.Size(72, 17)
    Me.LblLocMarried.TabIndex = 248
    Me.LblLocMarried.Text = "<married>"
    '
    'LblLocPgm
    '
    Me.LblLocPgm.AutoSize = True
    Me.LblLocPgm.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocPgm.Location = New System.Drawing.Point(661, 11)
    Me.LblLocPgm.Name = "LblLocPgm"
    Me.LblLocPgm.Size = New System.Drawing.Size(81, 26)
    Me.LblLocPgm.TabIndex = 247
    Me.LblLocPgm.Text = "<pgm>"
    Me.LblLocPgm.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'LblLocCredit
    '
    Me.LblLocCredit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocCredit.Location = New System.Drawing.Point(278, 93)
    Me.LblLocCredit.Name = "LblLocCredit"
    Me.LblLocCredit.Size = New System.Drawing.Size(66, 18)
    Me.LblLocCredit.TabIndex = 246
    Me.LblLocCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label81
    '
    Me.Label81.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label81.Location = New System.Drawing.Point(196, 96)
    Me.Label81.Name = "Label81"
    Me.Label81.Size = New System.Drawing.Size(76, 16)
    Me.Label81.TabIndex = 245
    Me.Label81.Text = "Credit Amount"
    '
    'LblLocTotal
    '
    Me.LblLocTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocTotal.Location = New System.Drawing.Point(111, 94)
    Me.LblLocTotal.Name = "LblLocTotal"
    Me.LblLocTotal.Size = New System.Drawing.Size(64, 18)
    Me.LblLocTotal.TabIndex = 244
    Me.LblLocTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label79
    '
    Me.Label79.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label79.Location = New System.Drawing.Point(15, 97)
    Me.Label79.Name = "Label79"
    Me.Label79.Size = New System.Drawing.Size(90, 20)
    Me.Label79.TabIndex = 243
    Me.Label79.Text = "TOTAL INCOME"
    Me.Label79.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'DtPckLocAssr
    '
    Me.DtPckLocAssr.Checked = False
    Me.DtPckLocAssr.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckLocAssr.Location = New System.Drawing.Point(153, 211)
    Me.DtPckLocAssr.Name = "DtPckLocAssr"
    Me.DtPckLocAssr.ShowCheckBox = True
    Me.DtPckLocAssr.Size = New System.Drawing.Size(100, 20)
    Me.DtPckLocAssr.TabIndex = 242
    '
    'Label77
    '
    Me.Label77.Location = New System.Drawing.Point(23, 215)
    Me.Label77.Name = "Label77"
    Me.Label77.Size = New System.Drawing.Size(124, 16)
    Me.Label77.TabIndex = 241
    Me.Label77.Text = "Date Assessor Signed"
    '
    'GroupBox8
    '
    Me.GroupBox8.Controls.Add(Me.TxtLocDisallowReason)
    Me.GroupBox8.Controls.Add(Me.RbLocDisallowed)
    Me.GroupBox8.Controls.Add(Me.RbLocAllowed)
    Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox8.Location = New System.Drawing.Point(18, 137)
    Me.GroupBox8.Name = "GroupBox8"
    Me.GroupBox8.Size = New System.Drawing.Size(479, 66)
    Me.GroupBox8.TabIndex = 240
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
    'LblLocAInit
    '
    Me.LblLocAInit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocAInit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocAInit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocAInit.Location = New System.Drawing.Point(372, 53)
    Me.LblLocAInit.Name = "LblLocAInit"
    Me.LblLocAInit.Size = New System.Drawing.Size(15, 18)
    Me.LblLocAInit.TabIndex = 235
    Me.LblLocAInit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblLocAFName
    '
    Me.LblLocAFName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocAFName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocAFName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocAFName.Location = New System.Drawing.Point(252, 53)
    Me.LblLocAFName.Name = "LblLocAFName"
    Me.LblLocAFName.Size = New System.Drawing.Size(114, 18)
    Me.LblLocAFName.TabIndex = 234
    Me.LblLocAFName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblLocALName
    '
    Me.LblLocALName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocALName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocALName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocALName.Location = New System.Drawing.Point(18, 53)
    Me.LblLocALName.Name = "LblLocALName"
    Me.LblLocALName.Size = New System.Drawing.Size(228, 18)
    Me.LblLocALName.TabIndex = 228
    Me.LblLocALName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblLocYear
    '
    Me.LblLocYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocYear.Location = New System.Drawing.Point(386, 9)
    Me.LblLocYear.Name = "LblLocYear"
    Me.LblLocYear.Size = New System.Drawing.Size(33, 18)
    Me.LblLocYear.TabIndex = 227
    Me.LblLocYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblLocListNo
    '
    Me.LblLocListNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLocListNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLocListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocListNo.Location = New System.Drawing.Point(284, 11)
    Me.LblLocListNo.Name = "LblLocListNo"
    Me.LblLocListNo.Size = New System.Drawing.Size(56, 18)
    Me.LblLocListNo.TabIndex = 226
    Me.LblLocListNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label70
    '
    Me.Label70.Location = New System.Drawing.Point(227, 12)
    Me.Label70.Name = "Label70"
    Me.Label70.Size = New System.Drawing.Size(51, 17)
    Me.Label70.TabIndex = 233
    Me.Label70.Text = "List No"
    '
    'Label71
    '
    Me.Label71.AutoSize = True
    Me.Label71.Location = New System.Drawing.Point(356, 34)
    Me.Label71.Name = "Label71"
    Me.Label71.Size = New System.Drawing.Size(44, 13)
    Me.Label71.TabIndex = 232
    Me.Label71.Text = "(Middle)"
    '
    'Label72
    '
    Me.Label72.AutoSize = True
    Me.Label72.Location = New System.Drawing.Point(251, 34)
    Me.Label72.Name = "Label72"
    Me.Label72.Size = New System.Drawing.Size(32, 13)
    Me.Label72.TabIndex = 231
    Me.Label72.Text = "(First)"
    '
    'Label73
    '
    Me.Label73.AutoSize = True
    Me.Label73.Location = New System.Drawing.Point(15, 37)
    Me.Label73.Name = "Label73"
    Me.Label73.Size = New System.Drawing.Size(64, 13)
    Me.Label73.TabIndex = 230
    Me.Label73.Text = "Name (Last)"
    '
    'Label74
    '
    Me.Label74.Location = New System.Drawing.Point(349, 10)
    Me.Label74.Name = "Label74"
    Me.Label74.Size = New System.Drawing.Size(35, 17)
    Me.Label74.TabIndex = 229
    Me.Label74.Text = "Year"
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "scroll.ico")
    '
    'Label34
    '
    Me.Label34.AutoSize = True
    Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label34.Location = New System.Drawing.Point(19, 123)
    Me.Label34.Name = "Label34"
    Me.Label34.Size = New System.Drawing.Size(163, 13)
    Me.Label34.TabIndex = 206
    Me.Label34.Text = "11. Additional Exemption Allowed"
    '
    'Label36
    '
    Me.Label36.AutoSize = True
    Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label36.Location = New System.Drawing.Point(19, 101)
    Me.Label36.Name = "Label36"
    Me.Label36.Size = New System.Drawing.Size(107, 13)
    Me.Label36.TabIndex = 205
    Me.Label36.Text = "10. Qualfying Income"
    '
    'CheckBox2
    '
    Me.CheckBox2.AutoSize = True
    Me.CheckBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.CheckBox2.Location = New System.Drawing.Point(19, 81)
    Me.CheckBox2.Name = "CheckBox2"
    Me.CheckBox2.Size = New System.Drawing.Size(263, 17)
    Me.CheckBox2.TabIndex = 204
    Me.CheckBox2.Text = "9. Indicate Income Level: Disabled Income Level?"
    Me.CheckBox2.UseVisualStyleBackColor = True
    '
    'Label38
    '
    Me.Label38.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label38.Location = New System.Drawing.Point(325, 101)
    Me.Label38.Name = "Label38"
    Me.Label38.Size = New System.Drawing.Size(66, 18)
    Me.Label38.TabIndex = 202
    Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TextBox1
    '
    Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox1.Location = New System.Drawing.Point(325, 123)
    Me.TextBox1.MaxLength = 8
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(66, 20)
    Me.TextBox1.TabIndex = 200
    Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label39
    '
    Me.Label39.AutoSize = True
    Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label39.Location = New System.Drawing.Point(19, 65)
    Me.Label39.Name = "Label39"
    Me.Label39.Size = New System.Drawing.Size(300, 13)
    Me.Label39.TabIndex = 199
    Me.Label39.Text = "8. The Applicant is receiving the following veteran's exemption"
    '
    'Label40
    '
    Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label40.Location = New System.Drawing.Point(15, 175)
    Me.Label40.Name = "Label40"
    Me.Label40.Size = New System.Drawing.Size(141, 20)
    Me.Label40.TabIndex = 198
    Me.Label40.Text = "11. Net Assessment"
    Me.Label40.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'TextBox2
    '
    Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox2.Location = New System.Drawing.Point(325, 62)
    Me.TextBox2.MaxLength = 8
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(66, 20)
    Me.TextBox2.TabIndex = 197
    Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label41
    '
    Me.Label41.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label41.Location = New System.Drawing.Point(50, 22)
    Me.Label41.Name = "Label41"
    Me.Label41.Size = New System.Drawing.Size(134, 18)
    Me.Label41.TabIndex = 195
    Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label42
    '
    Me.Label42.AutoSize = True
    Me.Label42.Location = New System.Drawing.Point(13, 23)
    Me.Label42.Name = "Label42"
    Me.Label42.Size = New System.Drawing.Size(31, 13)
    Me.Label42.TabIndex = 196
    Me.Label42.Text = "Type"
    '
    'DateTimePicker1
    '
    Me.DateTimePicker1.Checked = False
    Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DateTimePicker1.Location = New System.Drawing.Point(154, 460)
    Me.DateTimePicker1.Name = "DateTimePicker1"
    Me.DateTimePicker1.ShowCheckBox = True
    Me.DateTimePicker1.Size = New System.Drawing.Size(100, 20)
    Me.DateTimePicker1.TabIndex = 181
    '
    'Label43
    '
    Me.Label43.Location = New System.Drawing.Point(24, 464)
    Me.Label43.Name = "Label43"
    Me.Label43.Size = New System.Drawing.Size(124, 16)
    Me.Label43.TabIndex = 180
    Me.Label43.Text = "Date Assessor Signed"
    '
    'Label44
    '
    Me.Label44.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label44.Location = New System.Drawing.Point(772, 23)
    Me.Label44.Name = "Label44"
    Me.Label44.Size = New System.Drawing.Size(15, 18)
    Me.Label44.TabIndex = 174
    Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label45
    '
    Me.Label45.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label45.Location = New System.Drawing.Point(652, 23)
    Me.Label45.Name = "Label45"
    Me.Label45.Size = New System.Drawing.Size(114, 18)
    Me.Label45.TabIndex = 173
    Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label46
    '
    Me.Label46.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label46.Location = New System.Drawing.Point(418, 23)
    Me.Label46.Name = "Label46"
    Me.Label46.Size = New System.Drawing.Size(228, 18)
    Me.Label46.TabIndex = 2
    Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label47
    '
    Me.Label47.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label47.Location = New System.Drawing.Point(352, 23)
    Me.Label47.Name = "Label47"
    Me.Label47.Size = New System.Drawing.Size(33, 18)
    Me.Label47.TabIndex = 1
    Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label49
    '
    Me.Label49.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label49.Location = New System.Drawing.Point(247, 22)
    Me.Label49.Name = "Label49"
    Me.Label49.Size = New System.Drawing.Size(56, 18)
    Me.Label49.TabIndex = 0
    Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.TextBox3)
    Me.GroupBox2.Controls.Add(Me.RadioButton1)
    Me.GroupBox2.Controls.Add(Me.RadioButton2)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(19, 386)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(479, 66)
    Me.GroupBox2.TabIndex = 8
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Assessor Affidavit"
    '
    'TextBox3
    '
    Me.TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox3.Location = New System.Drawing.Point(270, 40)
    Me.TextBox3.MaxLength = 30
    Me.TextBox3.Name = "TextBox3"
    Me.TextBox3.Size = New System.Drawing.Size(180, 20)
    Me.TextBox3.TabIndex = 167
    '
    'RadioButton1
    '
    Me.RadioButton1.AutoSize = True
    Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RadioButton1.Location = New System.Drawing.Point(8, 40)
    Me.RadioButton1.Name = "RadioButton1"
    Me.RadioButton1.Size = New System.Drawing.Size(246, 17)
    Me.RadioButton1.TabIndex = 2
    Me.RadioButton1.Text = "This claim is disallowed for the following reason"
    '
    'RadioButton2
    '
    Me.RadioButton2.AutoSize = True
    Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RadioButton2.Location = New System.Drawing.Point(8, 16)
    Me.RadioButton2.Name = "RadioButton2"
    Me.RadioButton2.Size = New System.Drawing.Size(442, 17)
    Me.RadioButton2.TabIndex = 0
    Me.RadioButton2.Text = "I am satified that the above name applicant meet all the necessary statutory requ" &
    "irements"
    '
    'Label50
    '
    Me.Label50.AutoSize = True
    Me.Label50.Location = New System.Drawing.Point(201, 25)
    Me.Label50.Name = "Label50"
    Me.Label50.Size = New System.Drawing.Size(40, 13)
    Me.Label50.TabIndex = 155
    Me.Label50.Text = "List No"
    '
    'Label52
    '
    Me.Label52.AutoSize = True
    Me.Label52.Location = New System.Drawing.Point(756, -1)
    Me.Label52.Name = "Label52"
    Me.Label52.Size = New System.Drawing.Size(44, 13)
    Me.Label52.TabIndex = 154
    Me.Label52.Text = "(Middle)"
    '
    'Label53
    '
    Me.Label53.AutoSize = True
    Me.Label53.Location = New System.Drawing.Point(651, -1)
    Me.Label53.Name = "Label53"
    Me.Label53.Size = New System.Drawing.Size(32, 13)
    Me.Label53.TabIndex = 153
    Me.Label53.Text = "(First)"
    '
    'Label56
    '
    Me.Label56.AutoSize = True
    Me.Label56.Location = New System.Drawing.Point(415, 2)
    Me.Label56.Name = "Label56"
    Me.Label56.Size = New System.Drawing.Size(64, 13)
    Me.Label56.TabIndex = 152
    Me.Label56.Text = "Name (Last)"
    '
    'Label57
    '
    Me.Label57.AutoSize = True
    Me.Label57.Location = New System.Drawing.Point(315, 24)
    Me.Label57.Name = "Label57"
    Me.Label57.Size = New System.Drawing.Size(29, 13)
    Me.Label57.TabIndex = 150
    Me.Label57.Text = "Year"
    '
    'FrmTO204C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(770, 586)
    Me.Controls.Add(Me.Tab1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTO204C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Tab1.ResumeLayout(False)
    Me.TpApplicant.ResumeLayout(False)
    Me.TpApplicant.PerformLayout()
    Me.GrpType.ResumeLayout(False)
    Me.GrpType.PerformLayout()
    Me.GroupBox6.ResumeLayout(False)
    Me.GroupBox6.PerformLayout()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.TpAssessor.ResumeLayout(False)
    Me.TpAssessor.PerformLayout()
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
    Me.TpLocal.ResumeLayout(False)
    Me.TpLocal.PerformLayout()
    Me.GrpFBC.ResumeLayout(False)
    Me.GrpFBC.PerformLayout()
    Me.GrpEBC.ResumeLayout(False)
    Me.GrpEBC.PerformLayout()
    Me.GroupBox8.ResumeLayout(False)
    Me.GroupBox8.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmTO204C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXM59A = New TXM59A.MyData(myDBConnect)
    MyTXM35H = New TXM35H.MyData(myDBConnect)
    MyTXMVD = New TXMVD.MyData(myDBConnect)
    MyTXPPRPC = New TXPPRPC.MyData(myDBConnect)
    MyTXREALC = New TXREALC.MyData(myDBConnect)
    MyTXSUPP = New TXSupp.MyData(myDBConnect)
    MyTXHOIN = New TXHOIN.MyData(myDBConnect)
    MyTXLOCEX = New TXLOCEX.MyData(myDBConnect)
    MyTXM59PM = New TXM59PM.MyData(myDBConnect)

    LoadScrn = True
    TxtListNo.Focus()
    MyFrmTO204.TBarNew.Enabled = False
    MyFrmTO204.TBarSave.Enabled = True
    LblLocPgm.Text = ""

    AddMode = False
    MyFrmTO204.TBarPrint.Enabled = True
    Select Case MyLocEld
      Case Is = "045", "162"
        MyFrmTO204.TBarLocal.Enabled = True
        MyFrmTO204.TBarEBC.Visible = False
        MyFrmTO204.TBarFBC.Visible = False
        MyFrmTO204.TBarPrint.Text = "State"
        GrpEBC.Visible = False
        DtPckEBCAssr.Visible = False
        LblEBCAssr.Visible = False
        LblEBCExam.Visible = False
        LblEBCHdr.Visible = False
        GrpFBC.Visible = False
        DtPckFBCAssr.Visible = False
        LblFBCAssr.Visible = False
        LblFBCExam.Visible = False
        LblFBCHdr.Visible = False
        ChkNotVet.Visible = False
        ChkLocDisabled.Visible = False
        ChkLocBlind.Visible = False
      Case Is = "084"
        MyFrmTO204.TBarLocal.Enabled = True
        MyFrmTO204.TBarEBC.Enabled = True
        MyFrmTO204.TBarFBC.Enabled = True
        MyFrmTO204.TBarPrint.Text = "State"
      Case Else
        Tab1.TabPages.Remove(TpLocal)
        ChkNotVet.Visible = False
        ChkLocDisabled.Visible = False
        ChkLocBlind.Visible = False
    End Select
    If WrkListNo > 0 Then
      Me.Text = "Maintain " & Me.Text
      MyFrmTO204.TBarDelete.Enabled = True
      TxtListNo.Text = WrkListNo
      LnkListNo.Enabled = False
      TxtListNo.ReadOnly = True
      Select Case WrkType
        Case "R"
          RbRE.Checked = True
          RbPP.Enabled = False
          RbMV.Enabled = False
          RbSU.Enabled = False
        Case "P"
          RbPP.Checked = True
          RbRE.Enabled = False
          RbMV.Enabled = False
          RbSU.Enabled = False
        Case "M"
          RbMV.Checked = True
          RbRE.Enabled = False
          RbPP.Enabled = False
          RbSU.Enabled = False
        Case "S"
          RbSU.Checked = True
          RbRE.Enabled = False
          RbPP.Enabled = False
          RbMV.Enabled = False
      End Select
      TxtYear.ReadOnly = True
      DtPckSigned.Value = Date.Today
      DtPckAssr.Value = Date.Today
      MyTXM59A.GetOneRecordP(WrkListNo, WrkType, WrkYear)
      If MyTXM59A.RecordNotFound Then
        MyFrmTO204.TBarNew.Enabled = False
        MyFrmTO204.TBarSave.Enabled = False
        MyFrmTO204.TBarDelete.Enabled = False
        MyFrmTO204.TBarPrint.Enabled = False
        If MyLocEld = "045" Or MyLocEld = "162" Then
          MyFrmTO204.TBarLocal.Enabled = False
        End If
        If MyLocEld = "084" Then
          MyFrmTO204.TBarLocal.Enabled = False
          MyFrmTO204.TBarEBC.Enabled = False
          MyFrmTO204.TBarFBC.Enabled = False
        End If
        Me.ErrProv.SetError(TxtListNo, "Record not found")
        Exit Sub
      End If

      With MyTXM59A
        'Applicant
        TxtListNo.Text = ._LISTNO
        Select Case Trim(._TYPE)
          Case "R"
            GetTXREALC()
            RbRE.Checked = True
          Case "P"
            GetTXPPRPC()
            RbPP.Checked = True
          Case "M"
            GetTXMVD()
            RbMV.Checked = True
          Case "S"
            GetTXSUPP()
            RbSU.Checked = True
        End Select
        TxtYear.Text = ._YEAR
        TxtALName.Text = Trim(._ALNAME)
        TxtAFName.Text = Trim(._AFNAME)
        TxtAInit.Text = Trim(._AINIT)
        If ._ASSN > 0 Then
          MskTxtASSN.Text = Format(._ASSN, "000000000")
        End If
        TxtSLName.Text = Trim(._SLNAME)
        TxtSFName.Text = Trim(._SFNAME)
        TxtSInit.Text = Trim(._SINIT)
        If ._SSSN > 0 Then
          MskTxtSSSN.Text = Format(._SSSN, "000000000")
        End If
        TxtLocNo.Text = Trim(._LOCNO)
        TxtLoc.Text = Trim(._LOC)
        TxtCity.Text = Trim(._CITY)
        TxtState.Text = Trim(._STATE)
        If ._ZIP > 0 Then
          TxtZip.Text = Format(._ZIP, "00000")
        End If
        TxtMAddr.Text = Trim(._MADDR)
        TxtMCity.Text = Trim(._MCITY)
        TxtMState.Text = Trim(._MSTATE)
        If ._MZIP > 0 Then
          TxtMZip.Text = Format(._MZIP, "00000")
        End If
        Select Case Trim(._FILING)
          Case "M"
            RbMarried.Checked = True
          Case "U", "S"
            RbSingle.Checked = True
          Case "D"
            RbDivorced.Checked = True
          Case "W"
            RbWidow.Checked = True
          Case "L"
            RbLegally.Checked = True
        End Select
        ChkDisRating.Checked = False
        If Trim(._RATING) = "Y" Then
          ChkDisRating.Checked = True
        End If
        DtPckSigned.Value = MyUtils.GetDBDate(._DTSIGN)
        If ._PHONE > 0 Then
          TxtPhone.Text = ._PHONE
        End If
        TxtIncome.Text = Format(._INCOME, "Fixed")
        TxtInterest.Text = Format(._INT, "Fixed")
        TxtSSRR.Text = Format(._SSRR, "Fixed")
        TxtOther.Text = Format(._OTHER, "Fixed")
        'Assessor
        LblListNo.Text = ._LISTNO
        LblYear.Text = ._YEAR
        LblALName.Text = Trim(._ALNAME)
        LblAFName.Text = Trim(._AFNAME)
        LblAInit.Text = Trim(._AINIT)
        TxtVet.Text = ._XVET
        TxtAddlVet.Text = ._XADDL
        TxtFullAddl.Text = ._XFULL
        TxtLocal.Text = ._XLOCAL
        TxtFullLoc.Text = ._XFULLO
        If Trim(._ALLOW) = "Y" Then
          RbAllowed.Checked = True
        End If
        If Trim(._ALLOW) = "N" Then
          RbDisallowed.Checked = True
        End If
        TxtDisallowReason.Text = Trim(._DISRSN)
        If ._DTASSR > 0 Then
          DtPckAssr.Value = MyUtils.GetDBDate(._DTASSR)
          DtPckAssr.Checked = True
        End If
      End With
      CalcTotal()
      If MyLocEld = "045" Or MyLocEld = "162" Then
        With MyTXM59PM
          'Local
          .GetOneRecordP(WrkListNo, WrkType, WrkYear, "DAC")
          If Not .RecordNotFound Then
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
        With MyTXM59PM
          'Not Veteran 
          .GetOneRecordP(WrkListNo, WrkType, WrkYear, "NVT")
          If Not .RecordNotFound Then
            ChkNotVet.Checked = True
          End If
          SetVeteran()
          'Local
          If Not ChkNotVet.Checked Then
            .GetOneRecordP(WrkListNo, WrkType, WrkYear, "DAC")
            If .RecordNotFound Then
              .GetOneRecordP(WrkListNo, WrkType, WrkYear, "LOC")
            End If
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
          'EBC 
          LblEBCExam.Text = CalcExPgm("EBC")
          ChkLocDisabled.Checked = False
          .GetOneRecordP(WrkListNo, WrkType, WrkYear, "EBC")
          If Not .RecordNotFound Then
            ChkLocDisabled.Checked = True
            'Local
            If Trim(._ALLOW) = "Y" Then
              RbEBCAllowed.Checked = True
            End If
            If Trim(._ALLOW) = "N" Then
              RbEBCDisallowed.Checked = True
            End If
            TxtEBCDisallowReason.Text = Trim(._DISRSN)
            If ._DTASSR > 0 Then
              DtPckEBCAssr.Value = MyUtils.GetDBDate(._DTASSR)
              DtPckEBCAssr.Checked = True
            End If
          End If
          SetDisabled()
          'FBC 
          LblFBCExam.Text = CalcExPgm("FBC")
          ChkLocBlind.Checked = False
          .GetOneRecordP(WrkListNo, WrkType, WrkYear, "FBC")
          If Not .RecordNotFound Then
            'Local
            ChkLocBlind.Checked = True
            If Trim(._ALLOW) = "Y" Then
              RbFBCAllowed.Checked = True
            End If
            If Trim(._ALLOW) = "N" Then
              RbFBCDisallowed.Checked = True
            End If
            TxtFBCDisallowReason.Text = Trim(._DISRSN)
            If ._DTASSR > 0 Then
              DtPckFBCAssr.Value = MyUtils.GetDBDate(._DTASSR)
              DtPckFBCAssr.Checked = True
            End If
          End If
          SetBlind()
        End With
      End If
    Else
      Me.Text = "Add " & Me.Text
      AddMode = True
      MyFrmTO204.TBarDelete.Enabled = False
    End If

    LoadScrn = False
    If MyLocEld = "084" Then
      CalcLocEld()
    End If
  End Sub

  Private Sub FrmTO204C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTO204.TBarNew.Enabled = True
    MyFrmTO204.TBarSave.Enabled = False
    MyFrmTO204.TBarDelete.Enabled = False
    MyFrmTO204.TBarPrint.Enabled = False
    MyFrmTO204.TBarLocal.Enabled = False
    MyFrmTO204.TBarEBC.Enabled = False
    MyFrmTO204.TBarFBC.Enabled = False
    MyFrmTO204B.FormatGrid()
    MyFrmTO204B.Show()

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    MyTXM59A.DeleteOneRecordP()

    If MyLocEld <> "" Then
      With MyTXM59PM
        If Not .RecordNotFound Then
          .DeleteOneRecordP()
        End If
      End With
    End If
  End Sub
  Public Sub SaveData()
    Dim WrkDevlt As String
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    WrkDevlt = ""
    MyTXM59A.GetOneRecordP(WrkListNo, WrkType, MyUtils.CnvSng(TxtYear.Text))
    If AddMode Then
      If Not MyTXM59A.RecordNotFound Then
        Me.ErrProv.SetError(TxtListNo, "Record already exists")
        Exit Sub
      End If
    End If

    If Not AddMode Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXM59A.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXM59A.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    If MyLocEld = "045" Or MyLocEld = "162" Then
      With MyTXM59PM
        If LblLocPgm.Text <> "" Then
          .GetOneRecordP(WrkListNo, WrkType, WrkYear, LblLocPgm.Text)
          'Local
          ._ALLOW = String.Empty
          If RbLocAllowed.Checked Then
            ._ALLOW = "Y"
          End If
          If RbLocDisallowed.Checked Then
            ._ALLOW = "N"
          End If
          ._LOCPM = LblLocPgm.Text
          ._DISRSN = TxtLocDisallowReason.Text
          If DtPckLocAssr.Checked Then
            ._DTASSR = MyUtils.SetDBDate(DtPckLocAssr.Value)
          Else
            ._DTASSR = 0
          End If
          If .RecordNotFound Then
            ._LISTNO = WrkListNo
            ._TYPE = WrkType
            ._YEAR = WrkYear
            ._LOCPM = LblLocPgm.Text
            .AddOneRecordP()
          Else
            .UpdateOneRecordP()
          End If
        End If
      End With
    End If

    If MyLocEld = "084" Then
      With MyTXM59PM
        If LblLocPgm.Text <> "" Then
          .GetOneRecordP(WrkListNo, WrkType, WrkYear, LblLocPgm.Text)
          'Local
          ._ALLOW = String.Empty
          If RbLocAllowed.Checked Then
            ._ALLOW = "Y"
          End If
          If RbLocDisallowed.Checked Then
            ._ALLOW = "N"
          End If
          ._LOCPM = LblLocPgm.Text
          ._DISRSN = TxtLocDisallowReason.Text
          If DtPckLocAssr.Checked Then
            ._DTASSR = MyUtils.SetDBDate(DtPckLocAssr.Value)
          Else
            ._DTASSR = 0
          End If
          If .RecordNotFound Then
            ._LISTNO = WrkListNo
            ._TYPE = WrkType
            ._YEAR = WrkYear
            ._LOCPM = LblLocPgm.Text
            .AddOneRecordP()
          Else
            .UpdateOneRecordP()
          End If
          'Check for opposite program, if found then delete
          If LblLocPgm.Text = "LOC" Then
            .GetOneRecordP(WrkListNo, WrkType, WrkYear, "DAC")
          Else
            .GetOneRecordP(WrkListNo, WrkType, WrkYear, "LOC")
          End If
          If Not .RecordNotFound Then
            .DeleteOneRecordP()
          End If
        End If
        'Not Veteran 
        .GetOneRecordP(WrkListNo, WrkType, WrkYear, "NVT")
        If .RecordNotFound Then
          If ChkNotVet.Checked Then
            ._LISTNO = WrkListNo
            ._TYPE = WrkType
            ._YEAR = WrkYear
            ._LOCPM = "NVT"
            .AddOneRecordP()
            .GetOneRecordP(WrkListNo, WrkType, WrkYear, "DAC")
            If Not .RecordNotFound Then
              .DeleteOneRecordP()
            End If
            .GetOneRecordP(WrkListNo, WrkType, WrkYear, "LOC")
            If Not .RecordNotFound Then
              .DeleteOneRecordP()
            End If
          End If
        Else
          If Not ChkNotVet.Checked Then
            .DeleteOneRecordP()
          End If
        End If
        'EBC
        .GetOneRecordP(WrkListNo, WrkType, WrkYear, "EBC")
        If ChkLocDisabled.Checked Then
          ._ALLOW = String.Empty
          If RbEBCAllowed.Checked Then
            ._ALLOW = "Y"
          End If
          If RbEBCDisallowed.Checked Then
            ._ALLOW = "N"
          End If
          ._DISRSN = TxtEBCDisallowReason.Text
          If DtPckEBCAssr.Checked Then
            ._DTASSR = MyUtils.SetDBDate(DtPckEBCAssr.Value)
          Else
            ._DTASSR = 0
          End If
          If .RecordNotFound Then
            ._LISTNO = WrkListNo
            ._TYPE = WrkType
            ._YEAR = WrkYear
            ._LOCPM = "EBC"
            .AddOneRecordP()
          Else
            .UpdateOneRecordP()
          End If
        Else
          If Not .RecordNotFound Then
            .DeleteOneRecordP()
          End If
        End If
        'FBC
        .GetOneRecordP(WrkListNo, WrkType, WrkYear, "FBC")
        If ChkLocBlind.Checked Then
          ._ALLOW = String.Empty
          If RbFBCAllowed.Checked Then
            ._ALLOW = "Y"
          End If
          If RbFBCDisallowed.Checked Then
            ._ALLOW = "N"
          End If
          ._DISRSN = TxtFBCDisallowReason.Text
          If DtPckFBCAssr.Checked Then
            ._DTASSR = MyUtils.SetDBDate(DtPckFBCAssr.Value)
          Else
            ._DTASSR = 0
          End If
          If .RecordNotFound Then
            ._LISTNO = WrkListNo
            ._TYPE = WrkType
            ._YEAR = WrkYear
            ._LOCPM = "FBC"
            .AddOneRecordP()
          Else
            .UpdateOneRecordP()
          End If
        Else
          If Not .RecordNotFound Then
            .DeleteOneRecordP()
          End If
        End If
      End With
    End If
    Me.Close()
  End Sub
  Private Sub MoveToFile()
    With MyTXM59A
      'Applicant
      ._LISTNO = MyUtils.CnvSng(TxtListNo.Text)
      If RbRE.Checked Then
        ._TYPE = "R"
      End If
      If RbPP.Checked Then
        ._TYPE = "P"
      End If
      If RbMV.Checked Then
        ._TYPE = "M"
      End If
      If RbSU.Checked Then
        ._TYPE = "S"
      End If
      ._YEAR = MyUtils.CnvSng(TxtYear.Text)
      ._ALNAME = TxtALName.Text
      ._AFNAME = TxtAFName.Text
      ._AINIT = TxtAInit.Text
      ._ASSN = Format(MyUtils.CnvSng(MskTxtASSN.Text), "000000000")
      ._SLNAME = TxtSLName.Text
      ._SFNAME = TxtSFName.Text
      ._SINIT = TxtSInit.Text
      ._SSSN = Format(MyUtils.CnvSng(MskTxtSSSN.Text), "000000000")
      ._LOCNO = MyUtils.JustifyRight(TxtLocNo.Text, 7)
      ._LOC = TxtLoc.Text
      ._CITY = TxtCity.Text
      ._STATE = TxtState.Text
      ._ZIP = MyUtils.CnvSng(TxtZip.Text)
      ._MADDR = TxtMAddr.Text
      ._MCITY = TxtMCity.Text
      ._MSTATE = TxtMState.Text
      ._MZIP = MyUtils.CnvSng(TxtMZip.Text)
      If RbMarried.Checked Then ._FILING = "M"
      If RbSingle.Checked Then ._FILING = "S"
      If RbDivorced.Checked Then ._FILING = "D"
      If RbWidow.Checked Then ._FILING = "W"
      If RbLegally.Checked Then ._FILING = "L"
      If ChkDisRating.Checked Then
        ._RATING = "Y"
      Else
        ._RATING = "N"
      End If
      ._DTSIGN = MyUtils.SetDBDate(DtPckSigned.Value)
      ._PHONE = MyUtils.CnvSng(TxtPhone.Text)
      ._INCOME = MyUtils.CnvSng(TxtIncome.Text)
      ._INT = MyUtils.CnvSng(TxtInterest.Text)
      ._SSRR = MyUtils.CnvSng(TxtSSRR.Text)
      ._OTHER = MyUtils.CnvSng(TxtOther.Text)
      'Assessor
      ._XVET = MyUtils.CnvSng(TxtVet.Text)
      ._XADDL = MyUtils.CnvSng(TxtAddlVet.Text)
      ._XFULL = MyUtils.CnvSng(TxtFullAddl.Text)
      ._XLOCAL = MyUtils.CnvSng(TxtLocal.Text)
      ._XFULLO = MyUtils.CnvSng(TxtFullLoc.Text)
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

    If MskTxtASSN.Text = String.Empty Then
      ErrorField(I) = "assn"
      ErrorMsg(I) = "SSN is required"
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

    If RbSingle.Checked Then
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

    If TxtLoc.Text = String.Empty Then
      ErrorField(I) = "loc"
      ErrorMsg(I) = "Location is required"
      I = I + 1
    End If

    If TxtCity.Text = String.Empty Then
      ErrorField(I) = "city"
      ErrorMsg(I) = "City is required"
      I = I + 1
    End If

    If TxtState.Text = String.Empty Then
      ErrorField(I) = "state"
      ErrorMsg(I) = "State is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtZip.Text) = 0 Then
      ErrorField(I) = "zip"
      ErrorMsg(I) = "Zip is required"
      I = I + 1
    End If

    If RbAllowed.Checked And MyUtils.CnvSng(TxtVet.Text) = 0 Then
      ErrorField(I) = "vet"
      ErrorMsg(I) = "Code A exemption is required"
      I = I + 1
    End If

    If DtPckAssr.Checked Then
      If Not RbAllowed.Checked And Not RbDisallowed.Checked Then
        ErrorField(I) = "assr"
        ErrorMsg(I) = "Allowed or disallowed must be checked"
        I = I + 1
      End If
    End If

    If Not DtPckAssr.Checked Then
      If RbAllowed.Checked Or RbDisallowed.Checked Then
        ErrorField(I) = "assr"
        ErrorMsg(I) = "Assessor signed date is required"
        I = I + 1
      End If
    End If

    If MyLocEld = "084" Then
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
    ErrProv.SetError(TxtLocNo, "")
    ErrProv.SetError(TxtLoc, "")
    ErrProv.SetError(TxtCity, "")
    ErrProv.SetError(TxtState, "")
    ErrProv.SetError(TxtZip, "")
    ErrProv.SetError(TxtVet, "")
    ErrProv.SetError(TxtAddlVet, "")
    ErrProv.SetError(TxtFullAddl, "")
    ErrProv.SetError(DtPckAssr, "")
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
        Case "loc"
          ErrProv.SetError(TxtLoc, ErrorMsg(I))
          ErrProv.SetError(TxtLocNo, ErrorMsg(I))
        Case "city"
          ErrProv.SetError(TxtCity, ErrorMsg(I))
        Case "state"
          ErrProv.SetError(TxtState, ErrorMsg(I))
        Case "zip"
          ErrProv.SetError(TxtZip, ErrorMsg(I))
        Case "vet"
          ErrProv.SetError(TxtVet, ErrorMsg(I))
        Case "addlvet"
          ErrProv.SetError(TxtAddlVet, ErrorMsg(I))
        Case "fulladdl"
          ErrProv.SetError(TxtFullAddl, ErrorMsg(I))
        Case "assr"
          ErrProv.SetError(DtPckAssr, ErrorMsg(I))
        Case "lassr"
          ErrProv.SetError(DtPckLocAssr, ErrorMsg(I))
        Case ""
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub FrmTO204C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTO204.SbpScreen.Text = "TO204C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub LnkListNo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkListNo.LinkClicked
    If RbRE.Checked Then
      MyFrmListRealC = New FrmListRealC
      MyFrmListRealC.MdiParent = Me.ParentForm
      MyFrmListRealC.WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
      MyFrmListRealC.Show()
    End If
    If RbPP.Checked Then
      MyFrmListPPRPC = New FrmListPPRPC
      MyFrmListPPRPC.MdiParent = Me.ParentForm
      MyFrmListPPRPC.WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
      MyFrmListPPRPC.Show()
    End If
    If RbMV.Checked Then
      MyFrmListMVD = New FrmListMVD
      MyFrmListMVD.MdiParent = Me.ParentForm
      MyFrmListMVD.WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
      MyFrmListMVD.Show()
    End If
    If RbSU.Checked Then
      MyFrmListSupp = New FrmListSupp
      MyFrmListSupp.MdiParent = Me.ParentForm
      MyFrmListSupp.WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
      MyFrmListSupp.Show()
    End If
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
  Private Sub TxtVet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVet.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAddlVet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAddlVet.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFullVet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFullAddl.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtListNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtListNo.LostFocus
    If TxtListNo.ReadOnly Then Exit Sub

    GetListNo()
  End Sub
  Private Sub TxtYear_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtYear.LostFocus
    If TxtListNo.ReadOnly Then Exit Sub

    GetTXM59A()
    GetTXM35H()

  End Sub
  Public Sub GetListNo()
    If RbRE.Checked Then
      GetTXREALC()
      WrkType = "R"
    End If
    If RbPP.Checked Then
      GetTXPPRPC()
      WrkType = "P"
    End If
    If RbMV.Checked Then
      GetTXMVD()
      WrkType = "M"
    End If
    If RbSU.Checked Then
      GetTXSUPP()
      WrkType = "S"
    End If
  End Sub

  Private Sub TxtIncome_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIncome.TextChanged
    CalcTotal()
    If MyLocEld <> "" Then
      LblLocCredit.Text = CalcLocEld()
      If MyLocEld = "084" Then
        SetBlind()
        SetDisabled()
      End If
    End If
  End Sub
  Private Sub TxtInterest_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtInterest.TextChanged
    CalcTotal()
    If MyLocEld <> "" Then
      LblLocCredit.Text = CalcLocEld()
      If MyLocEld = "084" Then
        SetBlind()
        SetDisabled()
      End If
    End If
  End Sub
  Private Sub TxtSSRR_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSSRR.TextChanged
    CalcTotal()
    If MyLocEld <> "" Then
      LblLocCredit.Text = CalcLocEld()
      If MyLocEld = "084" Then
        SetBlind()
        SetDisabled()
      End If
    End If
  End Sub
  Private Sub TxtOther_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOther.TextChanged
    CalcTotal()
    If MyLocEld <> "" Then
      LblLocCredit.Text = CalcLocEld()
      If MyLocEld = "084" Then
        SetBlind()
        SetDisabled()
      End If
    End If
  End Sub
  Public Sub GetTXREALC()
    Dim WrkLoc As String
    Dim Pos As Integer
    Dim Pos2 As Integer

    MyTXREALC.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text))
    If MyTXREALC.RecordNotFound Then Exit Sub

    With MyTXREALC
      'Populate First & Last Name
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
      LblALName.Text = Mid(TxtALName.Text, 1, 20)
      LblAFName.Text = Mid(TxtAFName.Text, 1, 10)
      TxtALName.Text = Mid(TxtALName.Text, 1, 20)
      TxtAFName.Text = Mid(TxtAFName.Text, 1, 10)
      'Populate Property & Mailing Address
      WrkLoc = Trim(._LOCNO) & " " & Trim(._LOC)
      TxtLoc.Text = Trim(._LOC)
      TxtLocNo.Text = Trim(._LOCNO)
      If Trim(._ADD1) = WrkLoc Then
        TxtCity.Text = Trim(._CITY)
        TxtState.Text = Trim(._STATE)
        TxtZip.Text = Format(._ZIP5, "00000")
      Else
        TxtMAddr.Text = Trim(._ADD1)
        TxtMCity.Text = Trim(._CITY)
        TxtMState.Text = Trim(._STATE)
        TxtMZip.Text = Format(._ZIP5, "00000")
      End If
    End With

  End Sub
  Public Sub GetTXPPRPC()
    Dim WrkLoc As String
    Dim Pos As Integer
    Dim Pos2 As Integer

    MyTXPPRPC.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text))
    If MyTXPPRPC.RecordNotFound Then Exit Sub

    With MyTXPPRPC
      'Populate First & Last Name
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
      LblALName.Text = Mid(TxtALName.Text, 1, 20)
      LblAFName.Text = Mid(TxtAFName.Text, 1, 10)
      TxtALName.Text = Mid(TxtALName.Text, 1, 20)
      TxtAFName.Text = Mid(TxtAFName.Text, 1, 10)
      'Populate Property & Mailing Address
      WrkLoc = Trim(._LOCNO) & " " & Trim(._LOC)
      TxtLoc.Text = Trim(._LOC)
      TxtLocNo.Text = Trim(._LOCNO)
      If Trim(._ADD1) = WrkLoc Then
        TxtCity.Text = Trim(._CITY)
        TxtState.Text = Trim(._STATE)
        TxtZip.Text = Format(._ZIP5, "00000")
      Else
        TxtMAddr.Text = Trim(._ADD1)
        TxtMCity.Text = Trim(._CITY)
        TxtMState.Text = Trim(._STATE)
        TxtMZip.Text = Format(._ZIP5, "00000")
      End If
    End With

  End Sub
  Public Sub GetTXMVD()
    Dim Pos As Integer
    Dim Pos2 As Integer

    MyTXMVD.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text))
    If MyTXMVD.RecordNotFound Then Exit Sub

    With MyTXMVD
      'Populate First & Last Name
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
      LblALName.Text = Mid(TxtALName.Text, 1, 20)
      LblAFName.Text = Mid(TxtAFName.Text, 1, 10)
      TxtALName.Text = Mid(TxtALName.Text, 1, 20)
      TxtAFName.Text = Mid(TxtAFName.Text, 1, 10)
      'Populate Property & Mailing Address
      TxtMAddr.Text = Trim(._ADD1)
      TxtMCity.Text = Trim(._CITY)
      TxtMState.Text = Trim(._STATE)
      TxtMZip.Text = Format(._ZIP5, "00000")
    End With

  End Sub
  Public Sub GetTXSUPP()
    Dim Pos As Integer
    Dim Pos2 As Integer

    MyTXSUPP.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text))
    If MyTXSUPP.RecordNotFound Then Exit Sub

    With MyTXSUPP
      'Populate First & Last Name
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
      LblALName.Text = Mid(TxtALName.Text, 1, 20)
      LblAFName.Text = Mid(TxtAFName.Text, 1, 10)
      TxtALName.Text = Mid(TxtALName.Text, 1, 20)
      TxtAFName.Text = Mid(TxtAFName.Text, 1, 10)
      'Populate Property & Mailing Address
      TxtMAddr.Text = Trim(._ADD1)
      TxtMCity.Text = Trim(._CITY)
      TxtMState.Text = Trim(._STATE)
      TxtMZip.Text = Format(._ZIP5, "00000")
    End With

  End Sub
  Private Sub CalcTotal()
    Dim WrkTotal As Decimal

    WrkTotal = MyUtils.CnvSng(TxtIncome.Text) + MyUtils.CnvSng(TxtInterest.Text) + MyUtils.CnvSng(TxtSSRR.Text) _
    + MyUtils.CnvSng(TxtOther.Text)
    LblTotal.Text = Format(WrkTotal, "fixed")
  End Sub
  Private Sub GetTXM59A()
    Dim pListNo As Integer
    pListNo = MyUtils.CnvSng(TxtListNo.Text)
    WrkYear = MyUtils.CnvSng(TxtYear.Text)
    MyTXM59A.GetOneRecordP(pListNo, WrkType, WrkYear - 1)
    If MyTXM59A.RecordNotFound Then
      MyTXM59A.GetOneRecordP(pListNo, WrkType, WrkYear - 2)
      If MyTXM59A.RecordNotFound Then
        MyFrmTO204.TBarDelete.Enabled = False
        LoadScrn = False
        Exit Sub
      End If
    End If
    'Get data from previous year
    With MyTXM59A
      TxtALName.Text = Trim(._ALNAME)
      TxtAFName.Text = Trim(._AFNAME)
      TxtAInit.Text = Trim(._AINIT)
      If ._ASSN > 0 Then
        MskTxtASSN.Text = Format(._ASSN, "000000000")
      End If
      TxtSLName.Text = Trim(._SLNAME)
      TxtSFName.Text = Trim(._SFNAME)
      TxtSInit.Text = Trim(._SINIT)
      If ._SSSN > 0 Then
        MskTxtSSSN.Text = Format(._SSSN, "000000000")
      End If
      If Trim(._LOC) <> "" Then
        TxtLoc.Text = Trim(._LOC)
        TxtLocNo.Text = Trim(._LOCNO)
      End If
      TxtCity.Text = Trim(._CITY)
      TxtState.Text = Trim(._STATE)
      If ._ZIP > 0 Then
        TxtZip.Text = Format(._ZIP, "00000")
      End If
      Select Case Trim(._FILING)
        Case "M"
          RbMarried.Checked = True
        Case "U"
          RbSingle.Checked = True
      End Select
      ChkDisRating.Checked = False
      If Trim(._RATING) = "Y" Then
        ChkDisRating.Checked = True
      End If
      If ._PHONE > 0 Then
        TxtPhone.Text = ._PHONE
      End If
    End With
  End Sub
  Private Sub GetTXM35H()
    Dim pListNo As Integer
    pListNo = MyUtils.CnvSng(TxtListNo.Text)
    WrkYear = MyUtils.CnvSng(TxtYear.Text)
    If MyM35HIncome Then
      With MyTXM35H
        .GetOneRecordP(pListNo, WrkYear - 1, 0)
        If Not .RecordNotFound Then
          If Trim(._DISAB) = "Y" Then Exit Sub
          TxtIncome.Text = Format(._INCOME, "Fixed")
          TxtInterest.Text = Format(._INT, "Fixed")
          TxtSSRR.Text = Format(._SSRR, "Fixed")
          TxtOther.Text = Format(._OTHER, "Fixed")
        End If
      End With
    End If
  End Sub
  Private Sub Tab1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tab1.Click
    LblListNo.Text = TxtListNo.Text
    If RbRE.Checked Then
      LblTypeDesc.Text = RbRE.Text
    End If
    If RbPP.Checked Then
      LblTypeDesc.Text = RbPP.Text
    End If
    If RbMV.Checked Then
      LblTypeDesc.Text = RbMV.Text
    End If
    If RbSU.Checked Then
      LblTypeDesc.Text = RbSU.Text
    End If
    LblYear.Text = TxtYear.Text
    If MyLocEld <> "" Then
      If RbRE.Checked Then
        LblLocTypeDesc.Text = RbRE.Text
      End If
      If RbPP.Checked Then
        LblLocTypeDesc.Text = RbPP.Text
      End If
      If RbMV.Checked Then
        LblLocTypeDesc.Text = RbMV.Text
      End If
      If RbSU.Checked Then
        LblLocTypeDesc.Text = RbSU.Text
      End If
      LblLocListNo.Text = TxtListNo.Text
      LblLocYear.Text = TxtYear.Text
      LblLocALName.Text = TxtALName.Text
      LblLocAFName.Text = TxtAFName.Text
      LblLocAInit.Text = TxtAInit.Text
      LblLocTotal.Text = LblTotal.Text
      LblLocCredit.Text = CalcLocEld()
      If MyLocEld = "084" Then
        LblEBCExam.Text = CalcExPgm("EBC")
        LblFBCExam.Text = CalcExPgm("FBC")
      End If
    End If
  End Sub
  Private Sub ChkDisRating_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkDisRating.Click
    CalcTotal()
  End Sub
  Private Function CalcLocEld() As Decimal
    Dim WrkStateSingle As Decimal
    Dim WrkStateMarried As Decimal
    Dim WrkLocalLimit As Decimal
    Dim WrkAmount As Decimal
    Dim WrkYear As Integer

    MyFrmTO204.TBarPrint.Enabled = False
    MyFrmTO204.TBarLocal.Enabled = False
    If myTOWN._TOWNBR = 45 Or myTOWN._TOWNBR = 162 Then 'East Lyme/Winchester
      MyFrmTO204.TBarPrint.Enabled = True
      MyFrmTO204.TBarLocal.Enabled = True
    End If
    LblLocPgm.Text = ""
    LblLocPgm.ForeColor = Color.Black
    If LoadScrn Then Exit Function

    WrkYear = MyUtils.CnvSng(TxtYear.Text)
    With MyTXHOIN
      .GetOneRecordP(WrkYear - 1, 5)
      WrkStateMarried = ._LIMIT
      .GetOneRecordP(WrkYear - 1, 4)
      WrkStateSingle = ._LIMIT
    End With

    If ChkNotVet.Checked Then
      LblLocMarried.Text = WrkStateMarried
      LblLocSingle.Text = WrkStateSingle
      LblLocPgm.Text = ""
      Me.Text = "Local Only"
      Return 0
    End If

    With MyTXLOCEX
      .GetOneRecordP(WrkYear - 1, "DAC")
      If .RecordNotFound Then
        .GetOneRecordP(0, "DAC")
      End If
      If RbMarried.Checked Then
        WrkLocalLimit = ._MRYINC + WrkStateMarried
      Else
        WrkLocalLimit = ._SNGINC + WrkStateSingle
      End If
      LblLocMarried.Text = ._MRYINC + WrkStateMarried
      LblLocSingle.Text = ._SNGINC + WrkStateSingle
      If MyUtils.CnvSng(LblTotal.Text) <= WrkLocalLimit Then
        WrkAmount = ._AMOUNT
        LblLocPgm.Text = "DAC"
        Me.Text = "OPM M59A"
        MyFrmTO204.TBarPrint.Enabled = True
        MyFrmTO204.TBarLocal.Enabled = True
        Return WrkAmount
      End If

      Select Case MyLocEld
        Case "045", "162"
          LblLocPgm.Text = "DAC"
        Case "084"
          .GetOneRecordP(WrkYear - 1, "LOC")
          If .RecordNotFound Then
            .GetOneRecordP(0, "LOC")
          End If
          If RbMarried.Checked Then
            WrkLocalLimit = ._MRYINC + WrkStateMarried
          Else
            WrkLocalLimit = ._SNGINC + WrkStateSingle
          End If
          LblLocMarried.Text = ._MRYINC + WrkStateMarried
          LblLocSingle.Text = ._SNGINC + WrkStateSingle
          If MyUtils.CnvSng(LblTotal.Text) <= WrkLocalLimit Then
            WrkAmount = ._AMOUNT
            LblLocPgm.Text = "LOC"
            MyFrmTO204.TBarLocal.Enabled = True
            Me.Text = "Local Only"
            Return WrkAmount
          End If
        Case Else
          MyFrmTO204.TBarPrint.Enabled = True
          MyFrmTO204.TBarLocal.Enabled = True
      End Select
    End With

    If MyFrmTO204C.RbLocDisallowed.Checked Then
      If MyLocEld = "045" Or MyLocEld = "162" Then
        LblLocPgm.ForeColor = Color.Pink
      Else
        MyFrmTO204.TBarLocal.Enabled = True
      End If
    End If
    Return 0
  End Function
  Private Function CalcExPgm(ByVal WrkPgm As String) As Decimal
    Dim WrkStateSingle As Decimal
    Dim WrkStateMarried As Decimal
    Dim WrkLocalLimit As Decimal
    Dim WrkYear As Integer
    Dim WrkAmount As Decimal

    WrkYear = MyUtils.CnvSng(TxtYear.Text)
    With MyTXHOIN
      .GetOneRecordP(WrkYear - 1, 5)
      WrkStateMarried = ._LIMIT
      .GetOneRecordP(WrkYear - 1, 4)
      WrkStateSingle = ._LIMIT
    End With

    With MyTXLOCEX
      .GetOneRecordP(WrkYear - 1, WrkPgm)
      If .RecordNotFound Then
        .GetOneRecordP(0, WrkPgm)
      End If
      If RbMarried.Checked Then
        WrkLocalLimit = ._MRYINC + WrkStateMarried
      Else
        WrkLocalLimit = ._SNGINC + WrkStateSingle
      End If
      If MyUtils.CnvSng(LblTotal.Text) <= WrkLocalLimit Then
        WrkAmount = ._AMOUNT
        Return WrkAmount
      End If
    End With
    Return 0
  End Function
  Private Sub SetDisabled()
    Dim WrkAmount As Decimal
    WrkAmount = CalcExPgm("DAC")

    If WrkAmount > 0 And ChkLocDisabled.Checked Then
      MyFrmTO204.TBarEBC.Enabled = True
      GrpEBC.Enabled = True
      DtPckEBCAssr.Enabled = True
      LblEBCHdr.Visible = True
      LblEBCExam.Visible = True
    Else
      MyFrmTO204.TBarEBC.Enabled = False
      GrpEBC.Enabled = False
      DtPckEBCAssr.Enabled = False
      LblEBCHdr.Visible = False
      LblEBCExam.Visible = False
    End If
  End Sub
  Private Sub SetBlind()
    Dim WrkAmount As Decimal
    WrkAmount = CalcExPgm("DAC")

    If WrkAmount > 0 And ChkLocBlind.Checked Then
      MyFrmTO204.TBarFBC.Enabled = True
      GrpFBC.Enabled = True
      DtPckFBCAssr.Enabled = True
      LblFBCHdr.Visible = True
      LblFBCExam.Visible = True
    Else
      MyFrmTO204.TBarFBC.Enabled = False
      GrpFBC.Enabled = False
      DtPckFBCAssr.Enabled = False
      LblFBCHdr.Visible = False
      LblFBCExam.Visible = False
    End If
  End Sub
  Private Sub SetVeteran()

    If ChkNotVet.Checked Then
      MyFrmTO204.TBarPrint.Enabled = False
      MyFrmTO204.TBarLocal.Enabled = False
    Else
      MyFrmTO204.TBarPrint.Enabled = True
      MyFrmTO204.TBarLocal.Enabled = True
    End If
  End Sub
  Private Sub ChkLocBlind_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkLocBlind.CheckedChanged
    SetBlind()
  End Sub
  Private Sub ChkDisabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkLocDisabled.CheckedChanged
    SetDisabled()
  End Sub
  Private Sub ChkNotVet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkNotVet.CheckedChanged
    SetVeteran()
  End Sub
  Private Sub RbLocDisallowed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbLocDisallowed.Click
    CalcLocEld()
  End Sub

  Private Sub TpApplicant_Click(sender As Object, e As EventArgs) Handles TpApplicant.Click

  End Sub

  Private Sub TpLocal_Click(sender As Object, e As EventArgs) Handles TpLocal.Click

  End Sub

End Class






