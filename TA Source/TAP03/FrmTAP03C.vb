Public Class FrmTAP03C
  Inherits System.Windows.Forms.Form
  Dim MyTXDVPP As TXDVPP.myData
  Dim MyTXDVPI As TXDVPI.myData
  Dim MyTXDVPN As TXDVPN.myData
  Dim MyTXPPRP As TXPPRP.MyData
  Dim MyTXMSRPDEP As TXMSRPDEP.MyData
  Dim AddMode As Boolean
  Dim LoadScrn As Boolean
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer

  Friend WithEvents TabCtl2 As System.Windows.Forms.TabControl
  Friend WithEvents TpUnreg As System.Windows.Forms.TabPage
  Friend WithEvents TpImprove As System.Windows.Forms.TabPage
  Friend WithEvents Label51 As System.Windows.Forms.Label
  Friend WithEvents DtPckRecvDt As System.Windows.Forms.DateTimePicker
  Friend WithEvents LnkListNo As System.Windows.Forms.LinkLabel
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents TpAff As System.Windows.Forms.TabPage
  Friend WithEvents Label24 As System.Windows.Forms.Label
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents Label25 As System.Windows.Forms.Label
  Friend WithEvents DtPckWit As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtWitName As System.Windows.Forms.TextBox
  Friend WithEvents Label26 As System.Windows.Forms.Label
  Friend WithEvents Label27 As System.Windows.Forms.Label
  Friend WithEvents DtPckAgent As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtAgentName As System.Windows.Forms.TextBox
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
  Friend WithEvents Label31 As System.Windows.Forms.Label
  Friend WithEvents DtPckOwn As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtOwnName As System.Windows.Forms.TextBox
  Friend WithEvents Label33 As System.Windows.Forms.Label
  Friend WithEvents Label34 As System.Windows.Forms.Label
  Friend WithEvents TxtFax As System.Windows.Forms.TextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents TxtZip4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtZip5 As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents TxtAddr As System.Windows.Forms.TextBox
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents TxtPhone As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TxtCampNo As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtCampNm As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents ChkDeck As System.Windows.Forms.CheckBox
  Friend WithEvents ChkShed As System.Windows.Forms.CheckBox
  Friend WithEvents ChkCanopy As System.Windows.Forms.CheckBox
  Friend WithEvents ChkSun As System.Windows.Forms.CheckBox
  Friend WithEvents ChkScreen As System.Windows.Forms.CheckBox
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents ChkGolf As System.Windows.Forms.CheckBox
  Friend WithEvents ChkScooter As System.Windows.Forms.CheckBox
  Friend WithEvents ChkCycle As System.Windows.Forms.CheckBox
  Friend WithEvents ChkATV As System.Windows.Forms.CheckBox
  Friend WithEvents ChkOther As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents ChkPropYr As System.Windows.Forms.CheckBox
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents ChkFWheel As System.Windows.Forms.CheckBox
  Friend WithEvents ChkSldout As System.Windows.Forms.CheckBox
  Friend WithEvents ChkSldOn As System.Windows.Forms.CheckBox
  Friend WithEvents ChkPChass As System.Windows.Forms.CheckBox
  Friend WithEvents ChkMHome As System.Windows.Forms.CheckBox
  Friend WithEvents ChkPModel As System.Windows.Forms.CheckBox
  Friend WithEvents ChkTTrail As System.Windows.Forms.CheckBox
  Friend WithEvents ChkCTrail As System.Windows.Forms.CheckBox
  Friend WithEvents TxtVYear As System.Windows.Forms.TextBox
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents DtPckPur As System.Windows.Forms.DateTimePicker
  Friend WithEvents ChkReg As System.Windows.Forms.CheckBox
  Friend WithEvents TxtRegWh As System.Windows.Forms.TextBox
  Friend WithEvents Label42 As System.Windows.Forms.Label
  Friend WithEvents TxtRegNo As System.Windows.Forms.TextBox
  Friend WithEvents Label41 As System.Windows.Forms.Label
  Friend WithEvents TxtPurvl As System.Windows.Forms.TextBox
  Friend WithEvents Label40 As System.Windows.Forms.Label
  Friend WithEvents Label39 As System.Windows.Forms.Label
  Friend WithEvents TxtWidth As System.Windows.Forms.TextBox
  Friend WithEvents Label38 As System.Windows.Forms.Label
  Friend WithEvents TxtLength As System.Windows.Forms.TextBox
  Friend WithEvents Label37 As System.Windows.Forms.Label
  Friend WithEvents TxtMake As System.Windows.Forms.TextBox
  Friend WithEvents Label36 As System.Windows.Forms.Label
  Friend WithEvents TxtEngine As System.Windows.Forms.TextBox
  Friend WithEvents Label35 As System.Windows.Forms.Label
  Friend WithEvents TxtModel As System.Windows.Forms.TextBox
  Friend WithEvents Label32 As System.Windows.Forms.Label
  Friend WithEvents TxtChass As System.Windows.Forms.TextBox
  Friend WithEvents Label28 As System.Windows.Forms.Label
  Friend WithEvents TxtModelN As System.Windows.Forms.TextBox
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents TxtLoc As System.Windows.Forms.TextBox
  Friend WithEvents TxtLocNo As System.Windows.Forms.TextBox
  Friend WithEvents Label44 As System.Windows.Forms.Label
  Friend WithEvents GrpDeck As System.Windows.Forms.GroupBox
  Friend WithEvents Label45 As System.Windows.Forms.Label
  Friend WithEvents RbDeckMetal As System.Windows.Forms.RadioButton
  Friend WithEvents RbDeckWood As System.Windows.Forms.RadioButton
  Friend WithEvents TxtDeckValue As System.Windows.Forms.TextBox
  Friend WithEvents TxtDeckSize2 As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtDeckSize1 As System.Windows.Forms.TextBox
  Friend WithEvents GrpScreen As System.Windows.Forms.GroupBox
  Friend WithEvents TxtScreenValue As System.Windows.Forms.TextBox
  Friend WithEvents RbScreenMetal As System.Windows.Forms.RadioButton
  Friend WithEvents RbScreenWood As System.Windows.Forms.RadioButton
  Friend WithEvents TxtScreenSize2 As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TxtScreenSize1 As System.Windows.Forms.TextBox
  Friend WithEvents GrpCanopy As System.Windows.Forms.GroupBox
  Friend WithEvents TxtCanopyValue As System.Windows.Forms.TextBox
  Friend WithEvents RbCanopyMetal As System.Windows.Forms.RadioButton
  Friend WithEvents RbCanopyWood As System.Windows.Forms.RadioButton
  Friend WithEvents TxtCanopySize2 As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents TxtCanopySize1 As System.Windows.Forms.TextBox
  Friend WithEvents GrpShed As System.Windows.Forms.GroupBox
  Friend WithEvents RbShedMetal As System.Windows.Forms.RadioButton
  Friend WithEvents RbShedWood As System.Windows.Forms.RadioButton
  Friend WithEvents TxtShedSize2 As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents TxtShedSize1 As System.Windows.Forms.TextBox
  Friend WithEvents GrpSun As System.Windows.Forms.GroupBox
  Friend WithEvents TxtSunValue As System.Windows.Forms.TextBox
  Friend WithEvents RbSunMetal As System.Windows.Forms.RadioButton
  Friend WithEvents RbSunWood As System.Windows.Forms.RadioButton
  Friend WithEvents TxtSunSize2 As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtSunSize1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtShedValue As System.Windows.Forms.TextBox
  Friend WithEvents GrpATV As System.Windows.Forms.GroupBox
  Friend WithEvents GrpGolf As System.Windows.Forms.GroupBox
  Friend WithEvents TxtGolfModel As System.Windows.Forms.TextBox
  Friend WithEvents TxtGolfValue As System.Windows.Forms.TextBox
  Friend WithEvents TxtGolfMake As System.Windows.Forms.TextBox
  Friend WithEvents TxtGolfYear As System.Windows.Forms.TextBox
  Friend WithEvents GrpOther As System.Windows.Forms.GroupBox
  Friend WithEvents TxtOtherModel As System.Windows.Forms.TextBox
  Friend WithEvents TxtOtherValue As System.Windows.Forms.TextBox
  Friend WithEvents TxtOtherMake As System.Windows.Forms.TextBox
  Friend WithEvents TxtOtherYear As System.Windows.Forms.TextBox
  Friend WithEvents GrpScooter As System.Windows.Forms.GroupBox
  Friend WithEvents TxtScooterModel As System.Windows.Forms.TextBox
  Friend WithEvents TxtScooterValue As System.Windows.Forms.TextBox
  Friend WithEvents TxtScooterMake As System.Windows.Forms.TextBox
  Friend WithEvents TxtScooterYear As System.Windows.Forms.TextBox
  Friend WithEvents GrpCycle As System.Windows.Forms.GroupBox
  Friend WithEvents TxtCycleModel As System.Windows.Forms.TextBox
  Friend WithEvents TxtCycleValue As System.Windows.Forms.TextBox
  Friend WithEvents TxtCycleMake As System.Windows.Forms.TextBox
  Friend WithEvents TxtCycleYear As System.Windows.Forms.TextBox
  Friend WithEvents TxtATVModel As System.Windows.Forms.TextBox
  Friend WithEvents TxtATVValue As System.Windows.Forms.TextBox
  Friend WithEvents TxtATVMake As System.Windows.Forms.TextBox
  Friend WithEvents TxtATVYear As System.Windows.Forms.TextBox
  Friend WithEvents LblTotNonReg As System.Windows.Forms.Label
  Friend WithEvents LblTotImprove As System.Windows.Forms.Label
  Friend WithEvents Label46 As System.Windows.Forms.Label
  Friend WithEvents Label47 As System.Windows.Forms.Label
  Friend WithEvents LblYear As System.Windows.Forms.Label
  Friend WithEvents TxtAddr2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtSname As System.Windows.Forms.TextBox
  Friend WithEvents RbCanopyPlastic As System.Windows.Forms.RadioButton
  Friend WithEvents RbShedPlastic As System.Windows.Forms.RadioButton
  Friend WithEvents RbSunPlastic As System.Windows.Forms.RadioButton
  Friend WithEvents RbScreenPlastic As System.Windows.Forms.RadioButton
  Friend WithEvents RbDeckPlastic As System.Windows.Forms.RadioButton
  Friend WithEvents Label48 As Label
  Friend WithEvents LblValue As Label
  Friend WithEvents TxtMSRP As TextBox
  Friend WithEvents Label49 As Label
  Friend WithEvents TxtListNo As System.Windows.Forms.TextBox



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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTAP03C))
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TabCtl2 = New System.Windows.Forms.TabControl()
    Me.TpUnreg = New System.Windows.Forms.TabPage()
    Me.Label48 = New System.Windows.Forms.Label()
    Me.LblValue = New System.Windows.Forms.Label()
    Me.TxtMSRP = New System.Windows.Forms.TextBox()
    Me.Label49 = New System.Windows.Forms.Label()
    Me.DtPckPur = New System.Windows.Forms.DateTimePicker()
    Me.ChkReg = New System.Windows.Forms.CheckBox()
    Me.TxtRegWh = New System.Windows.Forms.TextBox()
    Me.Label42 = New System.Windows.Forms.Label()
    Me.TxtRegNo = New System.Windows.Forms.TextBox()
    Me.Label41 = New System.Windows.Forms.Label()
    Me.TxtPurvl = New System.Windows.Forms.TextBox()
    Me.Label40 = New System.Windows.Forms.Label()
    Me.Label39 = New System.Windows.Forms.Label()
    Me.TxtWidth = New System.Windows.Forms.TextBox()
    Me.Label38 = New System.Windows.Forms.Label()
    Me.TxtLength = New System.Windows.Forms.TextBox()
    Me.Label37 = New System.Windows.Forms.Label()
    Me.TxtMake = New System.Windows.Forms.TextBox()
    Me.Label36 = New System.Windows.Forms.Label()
    Me.TxtEngine = New System.Windows.Forms.TextBox()
    Me.Label35 = New System.Windows.Forms.Label()
    Me.TxtModel = New System.Windows.Forms.TextBox()
    Me.Label32 = New System.Windows.Forms.Label()
    Me.TxtChass = New System.Windows.Forms.TextBox()
    Me.Label28 = New System.Windows.Forms.Label()
    Me.TxtModelN = New System.Windows.Forms.TextBox()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.TxtVYear = New System.Windows.Forms.TextBox()
    Me.Label22 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.ChkFWheel = New System.Windows.Forms.CheckBox()
    Me.ChkSldout = New System.Windows.Forms.CheckBox()
    Me.ChkSldOn = New System.Windows.Forms.CheckBox()
    Me.ChkPChass = New System.Windows.Forms.CheckBox()
    Me.ChkMHome = New System.Windows.Forms.CheckBox()
    Me.ChkPModel = New System.Windows.Forms.CheckBox()
    Me.ChkTTrail = New System.Windows.Forms.CheckBox()
    Me.ChkCTrail = New System.Windows.Forms.CheckBox()
    Me.ChkPropYr = New System.Windows.Forms.CheckBox()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.TxtCampNo = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtCampNm = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TpImprove = New System.Windows.Forms.TabPage()
    Me.Label47 = New System.Windows.Forms.Label()
    Me.Label46 = New System.Windows.Forms.Label()
    Me.LblTotNonReg = New System.Windows.Forms.Label()
    Me.LblTotImprove = New System.Windows.Forms.Label()
    Me.GrpOther = New System.Windows.Forms.GroupBox()
    Me.TxtOtherModel = New System.Windows.Forms.TextBox()
    Me.TxtOtherValue = New System.Windows.Forms.TextBox()
    Me.TxtOtherMake = New System.Windows.Forms.TextBox()
    Me.TxtOtherYear = New System.Windows.Forms.TextBox()
    Me.GrpScooter = New System.Windows.Forms.GroupBox()
    Me.TxtScooterModel = New System.Windows.Forms.TextBox()
    Me.TxtScooterValue = New System.Windows.Forms.TextBox()
    Me.TxtScooterMake = New System.Windows.Forms.TextBox()
    Me.TxtScooterYear = New System.Windows.Forms.TextBox()
    Me.GrpCycle = New System.Windows.Forms.GroupBox()
    Me.TxtCycleModel = New System.Windows.Forms.TextBox()
    Me.TxtCycleValue = New System.Windows.Forms.TextBox()
    Me.TxtCycleMake = New System.Windows.Forms.TextBox()
    Me.TxtCycleYear = New System.Windows.Forms.TextBox()
    Me.GrpATV = New System.Windows.Forms.GroupBox()
    Me.TxtATVModel = New System.Windows.Forms.TextBox()
    Me.TxtATVValue = New System.Windows.Forms.TextBox()
    Me.TxtATVMake = New System.Windows.Forms.TextBox()
    Me.TxtATVYear = New System.Windows.Forms.TextBox()
    Me.GrpGolf = New System.Windows.Forms.GroupBox()
    Me.TxtGolfModel = New System.Windows.Forms.TextBox()
    Me.TxtGolfValue = New System.Windows.Forms.TextBox()
    Me.TxtGolfMake = New System.Windows.Forms.TextBox()
    Me.TxtGolfYear = New System.Windows.Forms.TextBox()
    Me.GrpCanopy = New System.Windows.Forms.GroupBox()
    Me.RbCanopyPlastic = New System.Windows.Forms.RadioButton()
    Me.TxtCanopyValue = New System.Windows.Forms.TextBox()
    Me.RbCanopyMetal = New System.Windows.Forms.RadioButton()
    Me.RbCanopyWood = New System.Windows.Forms.RadioButton()
    Me.TxtCanopySize2 = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TxtCanopySize1 = New System.Windows.Forms.TextBox()
    Me.GrpShed = New System.Windows.Forms.GroupBox()
    Me.RbShedPlastic = New System.Windows.Forms.RadioButton()
    Me.TxtShedValue = New System.Windows.Forms.TextBox()
    Me.RbShedMetal = New System.Windows.Forms.RadioButton()
    Me.RbShedWood = New System.Windows.Forms.RadioButton()
    Me.TxtShedSize2 = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TxtShedSize1 = New System.Windows.Forms.TextBox()
    Me.GrpSun = New System.Windows.Forms.GroupBox()
    Me.RbSunPlastic = New System.Windows.Forms.RadioButton()
    Me.TxtSunValue = New System.Windows.Forms.TextBox()
    Me.RbSunMetal = New System.Windows.Forms.RadioButton()
    Me.RbSunWood = New System.Windows.Forms.RadioButton()
    Me.TxtSunSize2 = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtSunSize1 = New System.Windows.Forms.TextBox()
    Me.GrpScreen = New System.Windows.Forms.GroupBox()
    Me.RbScreenPlastic = New System.Windows.Forms.RadioButton()
    Me.TxtScreenValue = New System.Windows.Forms.TextBox()
    Me.RbScreenMetal = New System.Windows.Forms.RadioButton()
    Me.RbScreenWood = New System.Windows.Forms.RadioButton()
    Me.TxtScreenSize2 = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtScreenSize1 = New System.Windows.Forms.TextBox()
    Me.Label45 = New System.Windows.Forms.Label()
    Me.GrpDeck = New System.Windows.Forms.GroupBox()
    Me.RbDeckPlastic = New System.Windows.Forms.RadioButton()
    Me.RbDeckMetal = New System.Windows.Forms.RadioButton()
    Me.RbDeckWood = New System.Windows.Forms.RadioButton()
    Me.TxtDeckValue = New System.Windows.Forms.TextBox()
    Me.TxtDeckSize2 = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtDeckSize1 = New System.Windows.Forms.TextBox()
    Me.ChkOther = New System.Windows.Forms.CheckBox()
    Me.ChkScooter = New System.Windows.Forms.CheckBox()
    Me.ChkCycle = New System.Windows.Forms.CheckBox()
    Me.ChkATV = New System.Windows.Forms.CheckBox()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.ChkGolf = New System.Windows.Forms.CheckBox()
    Me.ChkShed = New System.Windows.Forms.CheckBox()
    Me.ChkCanopy = New System.Windows.Forms.CheckBox()
    Me.ChkSun = New System.Windows.Forms.CheckBox()
    Me.ChkScreen = New System.Windows.Forms.CheckBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.ChkDeck = New System.Windows.Forms.CheckBox()
    Me.TpAff = New System.Windows.Forms.TabPage()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.Label25 = New System.Windows.Forms.Label()
    Me.DtPckWit = New System.Windows.Forms.DateTimePicker()
    Me.TxtWitName = New System.Windows.Forms.TextBox()
    Me.Label26 = New System.Windows.Forms.Label()
    Me.Label27 = New System.Windows.Forms.Label()
    Me.DtPckAgent = New System.Windows.Forms.DateTimePicker()
    Me.TxtAgentName = New System.Windows.Forms.TextBox()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.Label31 = New System.Windows.Forms.Label()
    Me.DtPckOwn = New System.Windows.Forms.DateTimePicker()
    Me.TxtOwnName = New System.Windows.Forms.TextBox()
    Me.Label33 = New System.Windows.Forms.Label()
    Me.Label34 = New System.Windows.Forms.Label()
    Me.Label51 = New System.Windows.Forms.Label()
    Me.DtPckRecvDt = New System.Windows.Forms.DateTimePicker()
    Me.LnkListNo = New System.Windows.Forms.LinkLabel()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.TxtFax = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.TxtEmail = New System.Windows.Forms.TextBox()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.TxtZip4 = New System.Windows.Forms.TextBox()
    Me.TxtZip5 = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtAddr = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.TxtPhone = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtLoc = New System.Windows.Forms.TextBox()
    Me.TxtLocNo = New System.Windows.Forms.TextBox()
    Me.Label44 = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.TxtAddr2 = New System.Windows.Forms.TextBox()
    Me.TxtSname = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TabCtl2.SuspendLayout()
    Me.TpUnreg.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.TpImprove.SuspendLayout()
    Me.GrpOther.SuspendLayout()
    Me.GrpScooter.SuspendLayout()
    Me.GrpCycle.SuspendLayout()
    Me.GrpATV.SuspendLayout()
    Me.GrpGolf.SuspendLayout()
    Me.GrpCanopy.SuspendLayout()
    Me.GrpShed.SuspendLayout()
    Me.GrpSun.SuspendLayout()
    Me.GrpScreen.SuspendLayout()
    Me.GrpDeck.SuspendLayout()
    Me.TpAff.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TabCtl2
    '
    Me.TabCtl2.Controls.Add(Me.TpUnreg)
    Me.TabCtl2.Controls.Add(Me.TpImprove)
    Me.TabCtl2.Controls.Add(Me.TpAff)
    Me.TabCtl2.Location = New System.Drawing.Point(12, 187)
    Me.TabCtl2.Name = "TabCtl2"
    Me.TabCtl2.SelectedIndex = 0
    Me.TabCtl2.Size = New System.Drawing.Size(961, 318)
    Me.TabCtl2.TabIndex = 14
    '
    'TpUnreg
    '
    Me.TpUnreg.Controls.Add(Me.Label48)
    Me.TpUnreg.Controls.Add(Me.LblValue)
    Me.TpUnreg.Controls.Add(Me.TxtMSRP)
    Me.TpUnreg.Controls.Add(Me.Label49)
    Me.TpUnreg.Controls.Add(Me.DtPckPur)
    Me.TpUnreg.Controls.Add(Me.ChkReg)
    Me.TpUnreg.Controls.Add(Me.TxtRegWh)
    Me.TpUnreg.Controls.Add(Me.Label42)
    Me.TpUnreg.Controls.Add(Me.TxtRegNo)
    Me.TpUnreg.Controls.Add(Me.Label41)
    Me.TpUnreg.Controls.Add(Me.TxtPurvl)
    Me.TpUnreg.Controls.Add(Me.Label40)
    Me.TpUnreg.Controls.Add(Me.Label39)
    Me.TpUnreg.Controls.Add(Me.TxtWidth)
    Me.TpUnreg.Controls.Add(Me.Label38)
    Me.TpUnreg.Controls.Add(Me.TxtLength)
    Me.TpUnreg.Controls.Add(Me.Label37)
    Me.TpUnreg.Controls.Add(Me.TxtMake)
    Me.TpUnreg.Controls.Add(Me.Label36)
    Me.TpUnreg.Controls.Add(Me.TxtEngine)
    Me.TpUnreg.Controls.Add(Me.Label35)
    Me.TpUnreg.Controls.Add(Me.TxtModel)
    Me.TpUnreg.Controls.Add(Me.Label32)
    Me.TpUnreg.Controls.Add(Me.TxtChass)
    Me.TpUnreg.Controls.Add(Me.Label28)
    Me.TpUnreg.Controls.Add(Me.TxtModelN)
    Me.TpUnreg.Controls.Add(Me.Label23)
    Me.TpUnreg.Controls.Add(Me.TxtVYear)
    Me.TpUnreg.Controls.Add(Me.Label22)
    Me.TpUnreg.Controls.Add(Me.GroupBox1)
    Me.TpUnreg.Controls.Add(Me.ChkPropYr)
    Me.TpUnreg.Controls.Add(Me.Label21)
    Me.TpUnreg.Controls.Add(Me.DtPckTo)
    Me.TpUnreg.Controls.Add(Me.DtPckFrom)
    Me.TpUnreg.Controls.Add(Me.Label20)
    Me.TpUnreg.Controls.Add(Me.TxtCampNo)
    Me.TpUnreg.Controls.Add(Me.Label2)
    Me.TpUnreg.Controls.Add(Me.TxtCampNm)
    Me.TpUnreg.Controls.Add(Me.Label1)
    Me.TpUnreg.Location = New System.Drawing.Point(4, 22)
    Me.TpUnreg.Name = "TpUnreg"
    Me.TpUnreg.Padding = New System.Windows.Forms.Padding(3)
    Me.TpUnreg.Size = New System.Drawing.Size(953, 292)
    Me.TpUnreg.TabIndex = 0
    Me.TpUnreg.Text = "Unregistered MV"
    Me.TpUnreg.UseVisualStyleBackColor = True
    '
    'Label48
    '
    Me.Label48.AutoSize = True
    Me.Label48.Location = New System.Drawing.Point(151, 260)
    Me.Label48.Name = "Label48"
    Me.Label48.Size = New System.Drawing.Size(38, 13)
    Me.Label48.TabIndex = 278
    Me.Label48.Text = "MSRP"
    '
    'LblValue
    '
    Me.LblValue.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblValue.Location = New System.Drawing.Point(336, 260)
    Me.LblValue.Name = "LblValue"
    Me.LblValue.Size = New System.Drawing.Size(54, 18)
    Me.LblValue.TabIndex = 277
    Me.LblValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtMSRP
    '
    Me.TxtMSRP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMSRP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMSRP.Location = New System.Drawing.Point(204, 257)
    Me.TxtMSRP.MaxLength = 9
    Me.TxtMSRP.Name = "TxtMSRP"
    Me.TxtMSRP.Size = New System.Drawing.Size(73, 20)
    Me.TxtMSRP.TabIndex = 20
    Me.TxtMSRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label49
    '
    Me.Label49.AutoSize = True
    Me.Label49.Location = New System.Drawing.Point(296, 262)
    Me.Label49.Name = "Label49"
    Me.Label49.Size = New System.Drawing.Size(34, 13)
    Me.Label49.TabIndex = 276
    Me.Label49.Text = "Value"
    '
    'DtPckPur
    '
    Me.DtPckPur.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckPur.Location = New System.Drawing.Point(387, 195)
    Me.DtPckPur.Name = "DtPckPur"
    Me.DtPckPur.ShowCheckBox = True
    Me.DtPckPur.Size = New System.Drawing.Size(102, 20)
    Me.DtPckPur.TabIndex = 14
    '
    'ChkReg
    '
    Me.ChkReg.AutoSize = True
    Me.ChkReg.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkReg.Location = New System.Drawing.Point(15, 232)
    Me.ChkReg.Name = "ChkReg"
    Me.ChkReg.Size = New System.Drawing.Size(83, 17)
    Me.ChkReg.TabIndex = 17
    Me.ChkReg.Text = "Registered?"
    Me.ChkReg.UseVisualStyleBackColor = True
    '
    'TxtRegWh
    '
    Me.TxtRegWh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRegWh.Location = New System.Drawing.Point(396, 230)
    Me.TxtRegWh.MaxLength = 20
    Me.TxtRegWh.Name = "TxtRegWh"
    Me.TxtRegWh.Size = New System.Drawing.Size(200, 20)
    Me.TxtRegWh.TabIndex = 19
    '
    'Label42
    '
    Me.Label42.Location = New System.Drawing.Point(299, 229)
    Me.Label42.Name = "Label42"
    Me.Label42.Size = New System.Drawing.Size(91, 20)
    Me.Label42.TabIndex = 272
    Me.Label42.Text = "Where registered"
    '
    'TxtRegNo
    '
    Me.TxtRegNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRegNo.Location = New System.Drawing.Point(204, 230)
    Me.TxtRegNo.MaxLength = 8
    Me.TxtRegNo.Name = "TxtRegNo"
    Me.TxtRegNo.Size = New System.Drawing.Size(76, 20)
    Me.TxtRegNo.TabIndex = 18
    '
    'Label41
    '
    Me.Label41.Location = New System.Drawing.Point(143, 232)
    Me.Label41.Name = "Label41"
    Me.Label41.Size = New System.Drawing.Size(55, 20)
    Me.Label41.TabIndex = 270
    Me.Label41.Text = "Marker #"
    '
    'TxtPurvl
    '
    Me.TxtPurvl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPurvl.Location = New System.Drawing.Point(611, 195)
    Me.TxtPurvl.MaxLength = 9
    Me.TxtPurvl.Name = "TxtPurvl"
    Me.TxtPurvl.Size = New System.Drawing.Size(83, 20)
    Me.TxtPurvl.TabIndex = 16
    '
    'Label40
    '
    Me.Label40.Location = New System.Drawing.Point(522, 198)
    Me.Label40.Name = "Label40"
    Me.Label40.Size = New System.Drawing.Size(83, 20)
    Me.Label40.TabIndex = 15
    Me.Label40.Text = "Purchase price"
    '
    'Label39
    '
    Me.Label39.Location = New System.Drawing.Point(299, 195)
    Me.Label39.Name = "Label39"
    Me.Label39.Size = New System.Drawing.Size(82, 20)
    Me.Label39.TabIndex = 266
    Me.Label39.Text = "Purchase Date"
    '
    'TxtWidth
    '
    Me.TxtWidth.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtWidth.Location = New System.Drawing.Point(204, 201)
    Me.TxtWidth.MaxLength = 3
    Me.TxtWidth.Name = "TxtWidth"
    Me.TxtWidth.Size = New System.Drawing.Size(32, 20)
    Me.TxtWidth.TabIndex = 13
    '
    'Label38
    '
    Me.Label38.Location = New System.Drawing.Point(155, 201)
    Me.Label38.Name = "Label38"
    Me.Label38.Size = New System.Drawing.Size(43, 20)
    Me.Label38.TabIndex = 264
    Me.Label38.Text = "Width"
    '
    'TxtLength
    '
    Me.TxtLength.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLength.Location = New System.Drawing.Point(94, 198)
    Me.TxtLength.MaxLength = 3
    Me.TxtLength.Name = "TxtLength"
    Me.TxtLength.Size = New System.Drawing.Size(32, 20)
    Me.TxtLength.TabIndex = 12
    '
    'Label37
    '
    Me.Label37.Location = New System.Drawing.Point(12, 201)
    Me.Label37.Name = "Label37"
    Me.Label37.Size = New System.Drawing.Size(48, 20)
    Me.Label37.TabIndex = 262
    Me.Label37.Text = "Length"
    '
    'TxtMake
    '
    Me.TxtMake.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMake.Location = New System.Drawing.Point(278, 136)
    Me.TxtMake.MaxLength = 15
    Me.TxtMake.Name = "TxtMake"
    Me.TxtMake.Size = New System.Drawing.Size(124, 20)
    Me.TxtMake.TabIndex = 7
    '
    'Label36
    '
    Me.Label36.Location = New System.Drawing.Point(189, 139)
    Me.Label36.Name = "Label36"
    Me.Label36.Size = New System.Drawing.Size(43, 20)
    Me.Label36.TabIndex = 260
    Me.Label36.Text = "Make"
    '
    'TxtEngine
    '
    Me.TxtEngine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtEngine.Location = New System.Drawing.Point(278, 166)
    Me.TxtEngine.MaxLength = 10
    Me.TxtEngine.Name = "TxtEngine"
    Me.TxtEngine.Size = New System.Drawing.Size(83, 20)
    Me.TxtEngine.TabIndex = 10
    '
    'Label35
    '
    Me.Label35.Location = New System.Drawing.Point(189, 166)
    Me.Label35.Name = "Label35"
    Me.Label35.Size = New System.Drawing.Size(95, 20)
    Me.Label35.TabIndex = 258
    Me.Label35.Text = "Make of Engine"
    '
    'TxtModel
    '
    Me.TxtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtModel.Location = New System.Drawing.Point(496, 133)
    Me.TxtModel.MaxLength = 8
    Me.TxtModel.Name = "TxtModel"
    Me.TxtModel.Size = New System.Drawing.Size(124, 20)
    Me.TxtModel.TabIndex = 15
    '
    'Label32
    '
    Me.Label32.Location = New System.Drawing.Point(414, 136)
    Me.Label32.Name = "Label32"
    Me.Label32.Size = New System.Drawing.Size(65, 20)
    Me.Label32.TabIndex = 256
    Me.Label32.Text = "Model"
    '
    'TxtChass
    '
    Me.TxtChass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtChass.Location = New System.Drawing.Point(504, 166)
    Me.TxtChass.MaxLength = 10
    Me.TxtChass.Name = "TxtChass"
    Me.TxtChass.Size = New System.Drawing.Size(92, 20)
    Me.TxtChass.TabIndex = 11
    '
    'Label28
    '
    Me.Label28.Location = New System.Drawing.Point(411, 166)
    Me.Label28.Name = "Label28"
    Me.Label28.Size = New System.Drawing.Size(91, 20)
    Me.Label28.TabIndex = 254
    Me.Label28.Text = "Make of Chassis"
    '
    'TxtModelN
    '
    Me.TxtModelN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtModelN.Location = New System.Drawing.Point(94, 163)
    Me.TxtModelN.MaxLength = 10
    Me.TxtModelN.Name = "TxtModelN"
    Me.TxtModelN.Size = New System.Drawing.Size(89, 20)
    Me.TxtModelN.TabIndex = 9
    '
    'Label23
    '
    Me.Label23.Location = New System.Drawing.Point(12, 166)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(62, 20)
    Me.Label23.TabIndex = 252
    Me.Label23.Text = "Model #"
    '
    'TxtVYear
    '
    Me.TxtVYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVYear.Location = New System.Drawing.Point(94, 136)
    Me.TxtVYear.MaxLength = 4
    Me.TxtVYear.Name = "TxtVYear"
    Me.TxtVYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtVYear.TabIndex = 6
    '
    'Label22
    '
    Me.Label22.Location = New System.Drawing.Point(12, 139)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(76, 20)
    Me.Label22.TabIndex = 250
    Me.Label22.Text = "Vehicle Year"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.ChkFWheel)
    Me.GroupBox1.Controls.Add(Me.ChkSldout)
    Me.GroupBox1.Controls.Add(Me.ChkSldOn)
    Me.GroupBox1.Controls.Add(Me.ChkPChass)
    Me.GroupBox1.Controls.Add(Me.ChkMHome)
    Me.GroupBox1.Controls.Add(Me.ChkPModel)
    Me.GroupBox1.Controls.Add(Me.ChkTTrail)
    Me.GroupBox1.Controls.Add(Me.ChkCTrail)
    Me.GroupBox1.Location = New System.Drawing.Point(9, 63)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(535, 64)
    Me.GroupBox1.TabIndex = 248
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Vehicle Type"
    '
    'ChkFWheel
    '
    Me.ChkFWheel.AutoSize = True
    Me.ChkFWheel.Location = New System.Drawing.Point(443, 19)
    Me.ChkFWheel.Name = "ChkFWheel"
    Me.ChkFWheel.Size = New System.Drawing.Size(80, 17)
    Me.ChkFWheel.TabIndex = 4
    Me.ChkFWheel.Text = "Fifth Wheel"
    Me.ChkFWheel.UseVisualStyleBackColor = True
    '
    'ChkSldout
    '
    Me.ChkSldout.AutoSize = True
    Me.ChkSldout.Location = New System.Drawing.Point(372, 42)
    Me.ChkSldout.Name = "ChkSldout"
    Me.ChkSldout.Size = New System.Drawing.Size(74, 17)
    Me.ChkSldout.TabIndex = 7
    Me.ChkSldout.Text = "Slide Outs"
    Me.ChkSldout.UseVisualStyleBackColor = True
    '
    'ChkSldOn
    '
    Me.ChkSldOn.AutoSize = True
    Me.ChkSldOn.Location = New System.Drawing.Point(6, 42)
    Me.ChkSldOn.Name = "ChkSldOn"
    Me.ChkSldOn.Size = New System.Drawing.Size(143, 17)
    Me.ChkSldOn.TabIndex = 5
    Me.ChkSldOn.Text = "Pick-up Camper, slide-on"
    Me.ChkSldOn.UseVisualStyleBackColor = True
    '
    'ChkPChass
    '
    Me.ChkPChass.AutoSize = True
    Me.ChkPChass.Location = New System.Drawing.Point(183, 42)
    Me.ChkPChass.Name = "ChkPChass"
    Me.ChkPChass.Size = New System.Drawing.Size(143, 17)
    Me.ChkPChass.TabIndex = 6
    Me.ChkPChass.Text = "Pick-up Camper, Chassis" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
    Me.ChkPChass.UseVisualStyleBackColor = True
    '
    'ChkMHome
    '
    Me.ChkMHome.AutoSize = True
    Me.ChkMHome.Location = New System.Drawing.Point(332, 19)
    Me.ChkMHome.Name = "ChkMHome"
    Me.ChkMHome.Size = New System.Drawing.Size(84, 17)
    Me.ChkMHome.TabIndex = 3
    Me.ChkMHome.Text = "Motor Home"
    Me.ChkMHome.UseVisualStyleBackColor = True
    '
    'ChkPModel
    '
    Me.ChkPModel.AutoSize = True
    Me.ChkPModel.Location = New System.Drawing.Point(224, 19)
    Me.ChkPModel.Name = "ChkPModel"
    Me.ChkPModel.Size = New System.Drawing.Size(80, 17)
    Me.ChkPModel.TabIndex = 2
    Me.ChkPModel.Text = "Park Model"
    Me.ChkPModel.UseVisualStyleBackColor = True
    '
    'ChkTTrail
    '
    Me.ChkTTrail.AutoSize = True
    Me.ChkTTrail.Location = New System.Drawing.Point(113, 19)
    Me.ChkTTrail.Name = "ChkTTrail"
    Me.ChkTTrail.Size = New System.Drawing.Size(88, 17)
    Me.ChkTTrail.TabIndex = 1
    Me.ChkTTrail.Text = "Travel Trailer"
    Me.ChkTTrail.UseVisualStyleBackColor = True
    '
    'ChkCTrail
    '
    Me.ChkCTrail.AutoSize = True
    Me.ChkCTrail.Location = New System.Drawing.Point(6, 19)
    Me.ChkCTrail.Name = "ChkCTrail"
    Me.ChkCTrail.Size = New System.Drawing.Size(85, 17)
    Me.ChkCTrail.TabIndex = 0
    Me.ChkCTrail.Text = "Camp Trailer"
    Me.ChkCTrail.UseVisualStyleBackColor = True
    '
    'ChkPropYr
    '
    Me.ChkPropYr.AutoSize = True
    Me.ChkPropYr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPropYr.Location = New System.Drawing.Point(381, 39)
    Me.ChkPropYr.Name = "ChkPropYr"
    Me.ChkPropYr.Size = New System.Drawing.Size(151, 17)
    Me.ChkPropYr.TabIndex = 5
    Me.ChkPropYr.Text = "Property there year round?"
    Me.ChkPropYr.UseVisualStyleBackColor = True
    '
    'Label21
    '
    Me.Label21.Location = New System.Drawing.Point(230, 37)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(22, 20)
    Me.Label21.TabIndex = 3
    Me.Label21.Text = "to"
    '
    'DtPckTo
    '
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(252, 37)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.ShowCheckBox = True
    Me.DtPckTo.Size = New System.Drawing.Size(102, 20)
    Me.DtPckTo.TabIndex = 4
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(122, 37)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.ShowCheckBox = True
    Me.DtPckFrom.Size = New System.Drawing.Size(102, 20)
    Me.DtPckFrom.TabIndex = 2
    '
    'Label20
    '
    Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label20.Location = New System.Drawing.Point(6, 40)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(109, 17)
    Me.Label20.TabIndex = 242
    Me.Label20.Text = "At Campground from"
    '
    'TxtCampNo
    '
    Me.TxtCampNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCampNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCampNo.Location = New System.Drawing.Point(500, 11)
    Me.TxtCampNo.MaxLength = 10
    Me.TxtCampNo.Name = "TxtCampNo"
    Me.TxtCampNo.Size = New System.Drawing.Size(92, 20)
    Me.TxtCampNo.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(384, 14)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(109, 17)
    Me.Label2.TabIndex = 241
    Me.Label2.Text = "Campground Site #"
    '
    'TxtCampNm
    '
    Me.TxtCampNm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCampNm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCampNm.Location = New System.Drawing.Point(122, 11)
    Me.TxtCampNm.MaxLength = 30
    Me.TxtCampNm.Name = "TxtCampNm"
    Me.TxtCampNm.Size = New System.Drawing.Size(245, 20)
    Me.TxtCampNm.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(6, 14)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(109, 17)
    Me.Label1.TabIndex = 239
    Me.Label1.Text = "Campground Name"
    '
    'TpImprove
    '
    Me.TpImprove.Controls.Add(Me.Label47)
    Me.TpImprove.Controls.Add(Me.Label46)
    Me.TpImprove.Controls.Add(Me.LblTotNonReg)
    Me.TpImprove.Controls.Add(Me.LblTotImprove)
    Me.TpImprove.Controls.Add(Me.GrpOther)
    Me.TpImprove.Controls.Add(Me.GrpScooter)
    Me.TpImprove.Controls.Add(Me.GrpCycle)
    Me.TpImprove.Controls.Add(Me.GrpATV)
    Me.TpImprove.Controls.Add(Me.GrpGolf)
    Me.TpImprove.Controls.Add(Me.GrpCanopy)
    Me.TpImprove.Controls.Add(Me.GrpShed)
    Me.TpImprove.Controls.Add(Me.GrpSun)
    Me.TpImprove.Controls.Add(Me.GrpScreen)
    Me.TpImprove.Controls.Add(Me.Label45)
    Me.TpImprove.Controls.Add(Me.GrpDeck)
    Me.TpImprove.Controls.Add(Me.ChkOther)
    Me.TpImprove.Controls.Add(Me.ChkScooter)
    Me.TpImprove.Controls.Add(Me.ChkCycle)
    Me.TpImprove.Controls.Add(Me.ChkATV)
    Me.TpImprove.Controls.Add(Me.Label19)
    Me.TpImprove.Controls.Add(Me.Label18)
    Me.TpImprove.Controls.Add(Me.Label17)
    Me.TpImprove.Controls.Add(Me.Label16)
    Me.TpImprove.Controls.Add(Me.ChkGolf)
    Me.TpImprove.Controls.Add(Me.ChkShed)
    Me.TpImprove.Controls.Add(Me.ChkCanopy)
    Me.TpImprove.Controls.Add(Me.ChkSun)
    Me.TpImprove.Controls.Add(Me.ChkScreen)
    Me.TpImprove.Controls.Add(Me.Label9)
    Me.TpImprove.Controls.Add(Me.Label7)
    Me.TpImprove.Controls.Add(Me.ChkDeck)
    Me.TpImprove.Location = New System.Drawing.Point(4, 22)
    Me.TpImprove.Name = "TpImprove"
    Me.TpImprove.Padding = New System.Windows.Forms.Padding(3)
    Me.TpImprove.Size = New System.Drawing.Size(953, 292)
    Me.TpImprove.TabIndex = 1
    Me.TpImprove.Text = "Improvements & Non Registered"
    Me.TpImprove.UseVisualStyleBackColor = True
    '
    'Label47
    '
    Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label47.Location = New System.Drawing.Point(759, 268)
    Me.Label47.Name = "Label47"
    Me.Label47.Size = New System.Drawing.Size(83, 18)
    Me.Label47.TabIndex = 316
    Me.Label47.Text = "#9 SubTotal "
    '
    'Label46
    '
    Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label46.Location = New System.Drawing.Point(312, 268)
    Me.Label46.Name = "Label46"
    Me.Label46.Size = New System.Drawing.Size(90, 18)
    Me.Label46.TabIndex = 315
    Me.Label46.Text = "#24 SubTotal"
    '
    'LblTotNonReg
    '
    Me.LblTotNonReg.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotNonReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTotNonReg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotNonReg.Location = New System.Drawing.Point(851, 265)
    Me.LblTotNonReg.Name = "LblTotNonReg"
    Me.LblTotNonReg.Size = New System.Drawing.Size(79, 18)
    Me.LblTotNonReg.TabIndex = 314
    Me.LblTotNonReg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotImprove
    '
    Me.LblTotImprove.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotImprove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTotImprove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotImprove.Location = New System.Drawing.Point(414, 268)
    Me.LblTotImprove.Name = "LblTotImprove"
    Me.LblTotImprove.Size = New System.Drawing.Size(79, 18)
    Me.LblTotImprove.TabIndex = 313
    Me.LblTotImprove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'GrpOther
    '
    Me.GrpOther.Controls.Add(Me.TxtOtherModel)
    Me.GrpOther.Controls.Add(Me.TxtOtherValue)
    Me.GrpOther.Controls.Add(Me.TxtOtherMake)
    Me.GrpOther.Controls.Add(Me.TxtOtherYear)
    Me.GrpOther.Location = New System.Drawing.Point(645, 220)
    Me.GrpOther.Name = "GrpOther"
    Me.GrpOther.Size = New System.Drawing.Size(293, 42)
    Me.GrpOther.TabIndex = 9
    Me.GrpOther.TabStop = False
    '
    'TxtOtherModel
    '
    Me.TxtOtherModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOtherModel.Location = New System.Drawing.Point(145, 15)
    Me.TxtOtherModel.MaxLength = 5
    Me.TxtOtherModel.Name = "TxtOtherModel"
    Me.TxtOtherModel.Size = New System.Drawing.Size(52, 20)
    Me.TxtOtherModel.TabIndex = 2
    '
    'TxtOtherValue
    '
    Me.TxtOtherValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOtherValue.Location = New System.Drawing.Point(211, 15)
    Me.TxtOtherValue.MaxLength = 5
    Me.TxtOtherValue.Name = "TxtOtherValue"
    Me.TxtOtherValue.Size = New System.Drawing.Size(73, 20)
    Me.TxtOtherValue.TabIndex = 3
    Me.TxtOtherValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtOtherMake
    '
    Me.TxtOtherMake.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOtherMake.Location = New System.Drawing.Point(79, 15)
    Me.TxtOtherMake.MaxLength = 5
    Me.TxtOtherMake.Name = "TxtOtherMake"
    Me.TxtOtherMake.Size = New System.Drawing.Size(52, 20)
    Me.TxtOtherMake.TabIndex = 1
    '
    'TxtOtherYear
    '
    Me.TxtOtherYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOtherYear.Location = New System.Drawing.Point(6, 15)
    Me.TxtOtherYear.MaxLength = 5
    Me.TxtOtherYear.Name = "TxtOtherYear"
    Me.TxtOtherYear.Size = New System.Drawing.Size(48, 20)
    Me.TxtOtherYear.TabIndex = 0
    '
    'GrpScooter
    '
    Me.GrpScooter.Controls.Add(Me.TxtScooterModel)
    Me.GrpScooter.Controls.Add(Me.TxtScooterValue)
    Me.GrpScooter.Controls.Add(Me.TxtScooterMake)
    Me.GrpScooter.Controls.Add(Me.TxtScooterYear)
    Me.GrpScooter.Location = New System.Drawing.Point(645, 170)
    Me.GrpScooter.Name = "GrpScooter"
    Me.GrpScooter.Size = New System.Drawing.Size(293, 42)
    Me.GrpScooter.TabIndex = 8
    Me.GrpScooter.TabStop = False
    '
    'TxtScooterModel
    '
    Me.TxtScooterModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtScooterModel.Location = New System.Drawing.Point(145, 15)
    Me.TxtScooterModel.MaxLength = 5
    Me.TxtScooterModel.Name = "TxtScooterModel"
    Me.TxtScooterModel.Size = New System.Drawing.Size(52, 20)
    Me.TxtScooterModel.TabIndex = 2
    '
    'TxtScooterValue
    '
    Me.TxtScooterValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtScooterValue.Location = New System.Drawing.Point(211, 15)
    Me.TxtScooterValue.MaxLength = 5
    Me.TxtScooterValue.Name = "TxtScooterValue"
    Me.TxtScooterValue.Size = New System.Drawing.Size(73, 20)
    Me.TxtScooterValue.TabIndex = 3
    Me.TxtScooterValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtScooterMake
    '
    Me.TxtScooterMake.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtScooterMake.Location = New System.Drawing.Point(79, 15)
    Me.TxtScooterMake.MaxLength = 5
    Me.TxtScooterMake.Name = "TxtScooterMake"
    Me.TxtScooterMake.Size = New System.Drawing.Size(52, 20)
    Me.TxtScooterMake.TabIndex = 1
    '
    'TxtScooterYear
    '
    Me.TxtScooterYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtScooterYear.Location = New System.Drawing.Point(6, 15)
    Me.TxtScooterYear.MaxLength = 5
    Me.TxtScooterYear.Name = "TxtScooterYear"
    Me.TxtScooterYear.Size = New System.Drawing.Size(48, 20)
    Me.TxtScooterYear.TabIndex = 0
    '
    'GrpCycle
    '
    Me.GrpCycle.Controls.Add(Me.TxtCycleModel)
    Me.GrpCycle.Controls.Add(Me.TxtCycleValue)
    Me.GrpCycle.Controls.Add(Me.TxtCycleMake)
    Me.GrpCycle.Controls.Add(Me.TxtCycleYear)
    Me.GrpCycle.Location = New System.Drawing.Point(645, 120)
    Me.GrpCycle.Name = "GrpCycle"
    Me.GrpCycle.Size = New System.Drawing.Size(293, 42)
    Me.GrpCycle.TabIndex = 7
    Me.GrpCycle.TabStop = False
    '
    'TxtCycleModel
    '
    Me.TxtCycleModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCycleModel.Location = New System.Drawing.Point(146, 15)
    Me.TxtCycleModel.MaxLength = 5
    Me.TxtCycleModel.Name = "TxtCycleModel"
    Me.TxtCycleModel.Size = New System.Drawing.Size(52, 20)
    Me.TxtCycleModel.TabIndex = 2
    '
    'TxtCycleValue
    '
    Me.TxtCycleValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCycleValue.Location = New System.Drawing.Point(212, 15)
    Me.TxtCycleValue.MaxLength = 5
    Me.TxtCycleValue.Name = "TxtCycleValue"
    Me.TxtCycleValue.Size = New System.Drawing.Size(73, 20)
    Me.TxtCycleValue.TabIndex = 3
    Me.TxtCycleValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtCycleMake
    '
    Me.TxtCycleMake.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCycleMake.Location = New System.Drawing.Point(80, 15)
    Me.TxtCycleMake.MaxLength = 5
    Me.TxtCycleMake.Name = "TxtCycleMake"
    Me.TxtCycleMake.Size = New System.Drawing.Size(52, 20)
    Me.TxtCycleMake.TabIndex = 1
    '
    'TxtCycleYear
    '
    Me.TxtCycleYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCycleYear.Location = New System.Drawing.Point(7, 15)
    Me.TxtCycleYear.MaxLength = 5
    Me.TxtCycleYear.Name = "TxtCycleYear"
    Me.TxtCycleYear.Size = New System.Drawing.Size(48, 20)
    Me.TxtCycleYear.TabIndex = 0
    '
    'GrpATV
    '
    Me.GrpATV.Controls.Add(Me.TxtATVModel)
    Me.GrpATV.Controls.Add(Me.TxtATVValue)
    Me.GrpATV.Controls.Add(Me.TxtATVMake)
    Me.GrpATV.Controls.Add(Me.TxtATVYear)
    Me.GrpATV.Location = New System.Drawing.Point(645, 70)
    Me.GrpATV.Name = "GrpATV"
    Me.GrpATV.Size = New System.Drawing.Size(293, 42)
    Me.GrpATV.TabIndex = 6
    Me.GrpATV.TabStop = False
    '
    'TxtATVModel
    '
    Me.TxtATVModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtATVModel.Location = New System.Drawing.Point(146, 15)
    Me.TxtATVModel.MaxLength = 5
    Me.TxtATVModel.Name = "TxtATVModel"
    Me.TxtATVModel.Size = New System.Drawing.Size(52, 20)
    Me.TxtATVModel.TabIndex = 2
    '
    'TxtATVValue
    '
    Me.TxtATVValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtATVValue.Location = New System.Drawing.Point(212, 15)
    Me.TxtATVValue.MaxLength = 5
    Me.TxtATVValue.Name = "TxtATVValue"
    Me.TxtATVValue.Size = New System.Drawing.Size(73, 20)
    Me.TxtATVValue.TabIndex = 3
    Me.TxtATVValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtATVMake
    '
    Me.TxtATVMake.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtATVMake.Location = New System.Drawing.Point(80, 15)
    Me.TxtATVMake.MaxLength = 5
    Me.TxtATVMake.Name = "TxtATVMake"
    Me.TxtATVMake.Size = New System.Drawing.Size(52, 20)
    Me.TxtATVMake.TabIndex = 1
    '
    'TxtATVYear
    '
    Me.TxtATVYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtATVYear.Location = New System.Drawing.Point(7, 15)
    Me.TxtATVYear.MaxLength = 5
    Me.TxtATVYear.Name = "TxtATVYear"
    Me.TxtATVYear.Size = New System.Drawing.Size(48, 20)
    Me.TxtATVYear.TabIndex = 0
    '
    'GrpGolf
    '
    Me.GrpGolf.Controls.Add(Me.TxtGolfModel)
    Me.GrpGolf.Controls.Add(Me.TxtGolfValue)
    Me.GrpGolf.Controls.Add(Me.TxtGolfMake)
    Me.GrpGolf.Controls.Add(Me.TxtGolfYear)
    Me.GrpGolf.Location = New System.Drawing.Point(645, 20)
    Me.GrpGolf.Name = "GrpGolf"
    Me.GrpGolf.Size = New System.Drawing.Size(293, 42)
    Me.GrpGolf.TabIndex = 5
    Me.GrpGolf.TabStop = False
    '
    'TxtGolfModel
    '
    Me.TxtGolfModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGolfModel.Location = New System.Drawing.Point(145, 14)
    Me.TxtGolfModel.MaxLength = 5
    Me.TxtGolfModel.Name = "TxtGolfModel"
    Me.TxtGolfModel.Size = New System.Drawing.Size(52, 20)
    Me.TxtGolfModel.TabIndex = 2
    '
    'TxtGolfValue
    '
    Me.TxtGolfValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGolfValue.Location = New System.Drawing.Point(211, 14)
    Me.TxtGolfValue.MaxLength = 5
    Me.TxtGolfValue.Name = "TxtGolfValue"
    Me.TxtGolfValue.Size = New System.Drawing.Size(73, 20)
    Me.TxtGolfValue.TabIndex = 3
    Me.TxtGolfValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtGolfMake
    '
    Me.TxtGolfMake.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGolfMake.Location = New System.Drawing.Point(79, 14)
    Me.TxtGolfMake.MaxLength = 5
    Me.TxtGolfMake.Name = "TxtGolfMake"
    Me.TxtGolfMake.Size = New System.Drawing.Size(52, 20)
    Me.TxtGolfMake.TabIndex = 1
    '
    'TxtGolfYear
    '
    Me.TxtGolfYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGolfYear.Location = New System.Drawing.Point(6, 14)
    Me.TxtGolfYear.MaxLength = 5
    Me.TxtGolfYear.Name = "TxtGolfYear"
    Me.TxtGolfYear.Size = New System.Drawing.Size(48, 20)
    Me.TxtGolfYear.TabIndex = 0
    '
    'GrpCanopy
    '
    Me.GrpCanopy.Controls.Add(Me.RbCanopyPlastic)
    Me.GrpCanopy.Controls.Add(Me.TxtCanopyValue)
    Me.GrpCanopy.Controls.Add(Me.RbCanopyMetal)
    Me.GrpCanopy.Controls.Add(Me.RbCanopyWood)
    Me.GrpCanopy.Controls.Add(Me.TxtCanopySize2)
    Me.GrpCanopy.Controls.Add(Me.Label11)
    Me.GrpCanopy.Controls.Add(Me.TxtCanopySize1)
    Me.GrpCanopy.Location = New System.Drawing.Point(105, 170)
    Me.GrpCanopy.Name = "GrpCanopy"
    Me.GrpCanopy.Size = New System.Drawing.Size(399, 42)
    Me.GrpCanopy.TabIndex = 3
    Me.GrpCanopy.TabStop = False
    '
    'RbCanopyPlastic
    '
    Me.RbCanopyPlastic.AutoSize = True
    Me.RbCanopyPlastic.Location = New System.Drawing.Point(199, 16)
    Me.RbCanopyPlastic.Name = "RbCanopyPlastic"
    Me.RbCanopyPlastic.Size = New System.Drawing.Size(56, 17)
    Me.RbCanopyPlastic.TabIndex = 267
    Me.RbCanopyPlastic.Text = "Plastic"
    Me.RbCanopyPlastic.UseVisualStyleBackColor = True
    '
    'TxtCanopyValue
    '
    Me.TxtCanopyValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCanopyValue.Location = New System.Drawing.Point(315, 14)
    Me.TxtCanopyValue.MaxLength = 5
    Me.TxtCanopyValue.Name = "TxtCanopyValue"
    Me.TxtCanopyValue.Size = New System.Drawing.Size(73, 20)
    Me.TxtCanopyValue.TabIndex = 4
    Me.TxtCanopyValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'RbCanopyMetal
    '
    Me.RbCanopyMetal.AutoSize = True
    Me.RbCanopyMetal.Checked = True
    Me.RbCanopyMetal.Location = New System.Drawing.Point(261, 16)
    Me.RbCanopyMetal.Name = "RbCanopyMetal"
    Me.RbCanopyMetal.Size = New System.Drawing.Size(51, 17)
    Me.RbCanopyMetal.TabIndex = 3
    Me.RbCanopyMetal.TabStop = True
    Me.RbCanopyMetal.Text = "Metal"
    Me.RbCanopyMetal.UseVisualStyleBackColor = True
    '
    'RbCanopyWood
    '
    Me.RbCanopyWood.AutoSize = True
    Me.RbCanopyWood.Location = New System.Drawing.Point(141, 16)
    Me.RbCanopyWood.Name = "RbCanopyWood"
    Me.RbCanopyWood.Size = New System.Drawing.Size(54, 17)
    Me.RbCanopyWood.TabIndex = 2
    Me.RbCanopyWood.Text = "Wood"
    Me.RbCanopyWood.UseVisualStyleBackColor = True
    '
    'TxtCanopySize2
    '
    Me.TxtCanopySize2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCanopySize2.Location = New System.Drawing.Point(80, 13)
    Me.TxtCanopySize2.MaxLength = 5
    Me.TxtCanopySize2.Name = "TxtCanopySize2"
    Me.TxtCanopySize2.Size = New System.Drawing.Size(52, 20)
    Me.TxtCanopySize2.TabIndex = 1
    Me.TxtCanopySize2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label11
    '
    Me.Label11.Location = New System.Drawing.Point(61, 17)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(13, 16)
    Me.Label11.TabIndex = 266
    Me.Label11.Text = "X"
    '
    'TxtCanopySize1
    '
    Me.TxtCanopySize1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCanopySize1.Location = New System.Drawing.Point(7, 13)
    Me.TxtCanopySize1.MaxLength = 5
    Me.TxtCanopySize1.Name = "TxtCanopySize1"
    Me.TxtCanopySize1.Size = New System.Drawing.Size(48, 20)
    Me.TxtCanopySize1.TabIndex = 0
    Me.TxtCanopySize1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'GrpShed
    '
    Me.GrpShed.Controls.Add(Me.RbShedPlastic)
    Me.GrpShed.Controls.Add(Me.TxtShedValue)
    Me.GrpShed.Controls.Add(Me.RbShedMetal)
    Me.GrpShed.Controls.Add(Me.RbShedWood)
    Me.GrpShed.Controls.Add(Me.TxtShedSize2)
    Me.GrpShed.Controls.Add(Me.Label12)
    Me.GrpShed.Controls.Add(Me.TxtShedSize1)
    Me.GrpShed.Location = New System.Drawing.Point(106, 220)
    Me.GrpShed.Name = "GrpShed"
    Me.GrpShed.Size = New System.Drawing.Size(398, 42)
    Me.GrpShed.TabIndex = 4
    Me.GrpShed.TabStop = False
    '
    'RbShedPlastic
    '
    Me.RbShedPlastic.AutoSize = True
    Me.RbShedPlastic.Location = New System.Drawing.Point(199, 16)
    Me.RbShedPlastic.Name = "RbShedPlastic"
    Me.RbShedPlastic.Size = New System.Drawing.Size(56, 17)
    Me.RbShedPlastic.TabIndex = 274
    Me.RbShedPlastic.Text = "Plastic"
    Me.RbShedPlastic.UseVisualStyleBackColor = True
    '
    'TxtShedValue
    '
    Me.TxtShedValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtShedValue.Location = New System.Drawing.Point(314, 14)
    Me.TxtShedValue.MaxLength = 5
    Me.TxtShedValue.Name = "TxtShedValue"
    Me.TxtShedValue.Size = New System.Drawing.Size(73, 20)
    Me.TxtShedValue.TabIndex = 4
    Me.TxtShedValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'RbShedMetal
    '
    Me.RbShedMetal.AutoSize = True
    Me.RbShedMetal.Checked = True
    Me.RbShedMetal.Location = New System.Drawing.Point(260, 16)
    Me.RbShedMetal.Name = "RbShedMetal"
    Me.RbShedMetal.Size = New System.Drawing.Size(51, 17)
    Me.RbShedMetal.TabIndex = 3
    Me.RbShedMetal.TabStop = True
    Me.RbShedMetal.Text = "Metal"
    Me.RbShedMetal.UseVisualStyleBackColor = True
    '
    'RbShedWood
    '
    Me.RbShedWood.AutoSize = True
    Me.RbShedWood.Location = New System.Drawing.Point(140, 16)
    Me.RbShedWood.Name = "RbShedWood"
    Me.RbShedWood.Size = New System.Drawing.Size(54, 17)
    Me.RbShedWood.TabIndex = 2
    Me.RbShedWood.Text = "Wood"
    Me.RbShedWood.UseVisualStyleBackColor = True
    '
    'TxtShedSize2
    '
    Me.TxtShedSize2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtShedSize2.Location = New System.Drawing.Point(80, 13)
    Me.TxtShedSize2.MaxLength = 5
    Me.TxtShedSize2.Name = "TxtShedSize2"
    Me.TxtShedSize2.Size = New System.Drawing.Size(52, 20)
    Me.TxtShedSize2.TabIndex = 1
    Me.TxtShedSize2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label12
    '
    Me.Label12.Location = New System.Drawing.Point(61, 17)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(13, 16)
    Me.Label12.TabIndex = 273
    Me.Label12.Text = "X"
    '
    'TxtShedSize1
    '
    Me.TxtShedSize1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtShedSize1.Location = New System.Drawing.Point(7, 13)
    Me.TxtShedSize1.MaxLength = 5
    Me.TxtShedSize1.Name = "TxtShedSize1"
    Me.TxtShedSize1.Size = New System.Drawing.Size(48, 20)
    Me.TxtShedSize1.TabIndex = 0
    Me.TxtShedSize1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'GrpSun
    '
    Me.GrpSun.Controls.Add(Me.RbSunPlastic)
    Me.GrpSun.Controls.Add(Me.TxtSunValue)
    Me.GrpSun.Controls.Add(Me.RbSunMetal)
    Me.GrpSun.Controls.Add(Me.RbSunWood)
    Me.GrpSun.Controls.Add(Me.TxtSunSize2)
    Me.GrpSun.Controls.Add(Me.Label6)
    Me.GrpSun.Controls.Add(Me.TxtSunSize1)
    Me.GrpSun.Location = New System.Drawing.Point(106, 120)
    Me.GrpSun.Name = "GrpSun"
    Me.GrpSun.Size = New System.Drawing.Size(398, 42)
    Me.GrpSun.TabIndex = 2
    Me.GrpSun.TabStop = False
    '
    'RbSunPlastic
    '
    Me.RbSunPlastic.AutoSize = True
    Me.RbSunPlastic.Location = New System.Drawing.Point(198, 16)
    Me.RbSunPlastic.Name = "RbSunPlastic"
    Me.RbSunPlastic.Size = New System.Drawing.Size(56, 17)
    Me.RbSunPlastic.TabIndex = 260
    Me.RbSunPlastic.Text = "Plastic"
    Me.RbSunPlastic.UseVisualStyleBackColor = True
    '
    'TxtSunValue
    '
    Me.TxtSunValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSunValue.Location = New System.Drawing.Point(314, 14)
    Me.TxtSunValue.MaxLength = 5
    Me.TxtSunValue.Name = "TxtSunValue"
    Me.TxtSunValue.Size = New System.Drawing.Size(73, 20)
    Me.TxtSunValue.TabIndex = 4
    Me.TxtSunValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'RbSunMetal
    '
    Me.RbSunMetal.AutoSize = True
    Me.RbSunMetal.Checked = True
    Me.RbSunMetal.Location = New System.Drawing.Point(260, 16)
    Me.RbSunMetal.Name = "RbSunMetal"
    Me.RbSunMetal.Size = New System.Drawing.Size(51, 17)
    Me.RbSunMetal.TabIndex = 3
    Me.RbSunMetal.TabStop = True
    Me.RbSunMetal.Text = "Metal"
    Me.RbSunMetal.UseVisualStyleBackColor = True
    '
    'RbSunWood
    '
    Me.RbSunWood.AutoSize = True
    Me.RbSunWood.Location = New System.Drawing.Point(138, 16)
    Me.RbSunWood.Name = "RbSunWood"
    Me.RbSunWood.Size = New System.Drawing.Size(54, 17)
    Me.RbSunWood.TabIndex = 2
    Me.RbSunWood.Text = "Wood"
    Me.RbSunWood.UseVisualStyleBackColor = True
    '
    'TxtSunSize2
    '
    Me.TxtSunSize2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSunSize2.Location = New System.Drawing.Point(80, 13)
    Me.TxtSunSize2.MaxLength = 5
    Me.TxtSunSize2.Name = "TxtSunSize2"
    Me.TxtSunSize2.Size = New System.Drawing.Size(52, 20)
    Me.TxtSunSize2.TabIndex = 1
    Me.TxtSunSize2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(61, 17)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(13, 16)
    Me.Label6.TabIndex = 259
    Me.Label6.Text = "X"
    '
    'TxtSunSize1
    '
    Me.TxtSunSize1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSunSize1.Location = New System.Drawing.Point(7, 13)
    Me.TxtSunSize1.MaxLength = 5
    Me.TxtSunSize1.Name = "TxtSunSize1"
    Me.TxtSunSize1.Size = New System.Drawing.Size(48, 20)
    Me.TxtSunSize1.TabIndex = 0
    Me.TxtSunSize1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'GrpScreen
    '
    Me.GrpScreen.Controls.Add(Me.RbScreenPlastic)
    Me.GrpScreen.Controls.Add(Me.TxtScreenValue)
    Me.GrpScreen.Controls.Add(Me.RbScreenMetal)
    Me.GrpScreen.Controls.Add(Me.RbScreenWood)
    Me.GrpScreen.Controls.Add(Me.TxtScreenSize2)
    Me.GrpScreen.Controls.Add(Me.Label10)
    Me.GrpScreen.Controls.Add(Me.TxtScreenSize1)
    Me.GrpScreen.Location = New System.Drawing.Point(108, 70)
    Me.GrpScreen.Name = "GrpScreen"
    Me.GrpScreen.Size = New System.Drawing.Size(396, 42)
    Me.GrpScreen.TabIndex = 1
    Me.GrpScreen.TabStop = False
    '
    'RbScreenPlastic
    '
    Me.RbScreenPlastic.AutoSize = True
    Me.RbScreenPlastic.Location = New System.Drawing.Point(196, 16)
    Me.RbScreenPlastic.Name = "RbScreenPlastic"
    Me.RbScreenPlastic.Size = New System.Drawing.Size(56, 17)
    Me.RbScreenPlastic.TabIndex = 252
    Me.RbScreenPlastic.Text = "Plastic"
    Me.RbScreenPlastic.UseVisualStyleBackColor = True
    '
    'TxtScreenValue
    '
    Me.TxtScreenValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtScreenValue.Location = New System.Drawing.Point(312, 14)
    Me.TxtScreenValue.MaxLength = 5
    Me.TxtScreenValue.Name = "TxtScreenValue"
    Me.TxtScreenValue.Size = New System.Drawing.Size(73, 20)
    Me.TxtScreenValue.TabIndex = 4
    Me.TxtScreenValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'RbScreenMetal
    '
    Me.RbScreenMetal.AutoSize = True
    Me.RbScreenMetal.Checked = True
    Me.RbScreenMetal.Location = New System.Drawing.Point(258, 16)
    Me.RbScreenMetal.Name = "RbScreenMetal"
    Me.RbScreenMetal.Size = New System.Drawing.Size(51, 17)
    Me.RbScreenMetal.TabIndex = 3
    Me.RbScreenMetal.TabStop = True
    Me.RbScreenMetal.Text = "Metal"
    Me.RbScreenMetal.UseVisualStyleBackColor = True
    '
    'RbScreenWood
    '
    Me.RbScreenWood.AutoSize = True
    Me.RbScreenWood.Location = New System.Drawing.Point(138, 16)
    Me.RbScreenWood.Name = "RbScreenWood"
    Me.RbScreenWood.Size = New System.Drawing.Size(54, 17)
    Me.RbScreenWood.TabIndex = 2
    Me.RbScreenWood.Text = "Wood"
    Me.RbScreenWood.UseVisualStyleBackColor = True
    '
    'TxtScreenSize2
    '
    Me.TxtScreenSize2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtScreenSize2.Location = New System.Drawing.Point(80, 13)
    Me.TxtScreenSize2.MaxLength = 5
    Me.TxtScreenSize2.Name = "TxtScreenSize2"
    Me.TxtScreenSize2.Size = New System.Drawing.Size(52, 20)
    Me.TxtScreenSize2.TabIndex = 1
    Me.TxtScreenSize2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(61, 17)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(13, 16)
    Me.Label10.TabIndex = 251
    Me.Label10.Text = "X"
    '
    'TxtScreenSize1
    '
    Me.TxtScreenSize1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtScreenSize1.Location = New System.Drawing.Point(7, 13)
    Me.TxtScreenSize1.MaxLength = 5
    Me.TxtScreenSize1.Name = "TxtScreenSize1"
    Me.TxtScreenSize1.Size = New System.Drawing.Size(48, 20)
    Me.TxtScreenSize1.TabIndex = 0
    Me.TxtScreenSize1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label45
    '
    Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label45.Location = New System.Drawing.Point(302, 9)
    Me.Label45.Name = "Label45"
    Me.Label45.Size = New System.Drawing.Size(52, 16)
    Me.Label45.TabIndex = 312
    Me.Label45.Text = "Material"
    '
    'GrpDeck
    '
    Me.GrpDeck.Controls.Add(Me.RbDeckPlastic)
    Me.GrpDeck.Controls.Add(Me.RbDeckMetal)
    Me.GrpDeck.Controls.Add(Me.RbDeckWood)
    Me.GrpDeck.Controls.Add(Me.TxtDeckValue)
    Me.GrpDeck.Controls.Add(Me.TxtDeckSize2)
    Me.GrpDeck.Controls.Add(Me.Label8)
    Me.GrpDeck.Controls.Add(Me.TxtDeckSize1)
    Me.GrpDeck.Location = New System.Drawing.Point(106, 20)
    Me.GrpDeck.Name = "GrpDeck"
    Me.GrpDeck.Size = New System.Drawing.Size(398, 42)
    Me.GrpDeck.TabIndex = 0
    Me.GrpDeck.TabStop = False
    '
    'RbDeckPlastic
    '
    Me.RbDeckPlastic.AutoSize = True
    Me.RbDeckPlastic.Location = New System.Drawing.Point(198, 16)
    Me.RbDeckPlastic.Name = "RbDeckPlastic"
    Me.RbDeckPlastic.Size = New System.Drawing.Size(56, 17)
    Me.RbDeckPlastic.TabIndex = 247
    Me.RbDeckPlastic.Text = "Plastic"
    Me.RbDeckPlastic.UseVisualStyleBackColor = True
    '
    'RbDeckMetal
    '
    Me.RbDeckMetal.AutoSize = True
    Me.RbDeckMetal.Checked = True
    Me.RbDeckMetal.Location = New System.Drawing.Point(260, 16)
    Me.RbDeckMetal.Name = "RbDeckMetal"
    Me.RbDeckMetal.Size = New System.Drawing.Size(51, 17)
    Me.RbDeckMetal.TabIndex = 3
    Me.RbDeckMetal.TabStop = True
    Me.RbDeckMetal.Text = "Metal"
    Me.RbDeckMetal.UseVisualStyleBackColor = True
    '
    'RbDeckWood
    '
    Me.RbDeckWood.AutoSize = True
    Me.RbDeckWood.Location = New System.Drawing.Point(138, 16)
    Me.RbDeckWood.Name = "RbDeckWood"
    Me.RbDeckWood.Size = New System.Drawing.Size(54, 17)
    Me.RbDeckWood.TabIndex = 2
    Me.RbDeckWood.Text = "Wood"
    Me.RbDeckWood.UseVisualStyleBackColor = True
    '
    'TxtDeckValue
    '
    Me.TxtDeckValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDeckValue.Location = New System.Drawing.Point(314, 14)
    Me.TxtDeckValue.MaxLength = 5
    Me.TxtDeckValue.Name = "TxtDeckValue"
    Me.TxtDeckValue.Size = New System.Drawing.Size(73, 20)
    Me.TxtDeckValue.TabIndex = 4
    Me.TxtDeckValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtDeckSize2
    '
    Me.TxtDeckSize2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDeckSize2.Location = New System.Drawing.Point(80, 13)
    Me.TxtDeckSize2.MaxLength = 5
    Me.TxtDeckSize2.Name = "TxtDeckSize2"
    Me.TxtDeckSize2.Size = New System.Drawing.Size(52, 20)
    Me.TxtDeckSize2.TabIndex = 1
    Me.TxtDeckSize2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(61, 17)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(13, 16)
    Me.Label8.TabIndex = 246
    Me.Label8.Text = "X"
    '
    'TxtDeckSize1
    '
    Me.TxtDeckSize1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDeckSize1.Location = New System.Drawing.Point(7, 13)
    Me.TxtDeckSize1.MaxLength = 5
    Me.TxtDeckSize1.Name = "TxtDeckSize1"
    Me.TxtDeckSize1.Size = New System.Drawing.Size(48, 20)
    Me.TxtDeckSize1.TabIndex = 0
    Me.TxtDeckSize1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'ChkOther
    '
    Me.ChkOther.AutoSize = True
    Me.ChkOther.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkOther.Location = New System.Drawing.Point(587, 242)
    Me.ChkOther.Name = "ChkOther"
    Me.ChkOther.Size = New System.Drawing.Size(52, 17)
    Me.ChkOther.TabIndex = 302
    Me.ChkOther.Text = "Other"
    Me.ChkOther.UseVisualStyleBackColor = True
    '
    'ChkScooter
    '
    Me.ChkScooter.AutoSize = True
    Me.ChkScooter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkScooter.Location = New System.Drawing.Point(543, 190)
    Me.ChkScooter.Name = "ChkScooter"
    Me.ChkScooter.Size = New System.Drawing.Size(93, 17)
    Me.ChkScooter.TabIndex = 297
    Me.ChkScooter.Text = "Motor Scooter"
    Me.ChkScooter.UseVisualStyleBackColor = True
    '
    'ChkCycle
    '
    Me.ChkCycle.AutoSize = True
    Me.ChkCycle.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkCycle.Location = New System.Drawing.Point(561, 135)
    Me.ChkCycle.Name = "ChkCycle"
    Me.ChkCycle.Size = New System.Drawing.Size(78, 17)
    Me.ChkCycle.TabIndex = 292
    Me.ChkCycle.Text = "Motorcycle"
    Me.ChkCycle.UseVisualStyleBackColor = True
    '
    'ChkATV
    '
    Me.ChkATV.AutoSize = True
    Me.ChkATV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkATV.Location = New System.Drawing.Point(592, 86)
    Me.ChkATV.Name = "ChkATV"
    Me.ChkATV.Size = New System.Drawing.Size(47, 17)
    Me.ChkATV.TabIndex = 287
    Me.ChkATV.Text = "ATV"
    Me.ChkATV.UseVisualStyleBackColor = True
    '
    'Label19
    '
    Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label19.Location = New System.Drawing.Point(879, 9)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(39, 16)
    Me.Label19.TabIndex = 286
    Me.Label19.Text = "Value"
    '
    'Label18
    '
    Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label18.Location = New System.Drawing.Point(797, 9)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(46, 16)
    Me.Label18.TabIndex = 285
    Me.Label18.Text = "Model"
    '
    'Label17
    '
    Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label17.Location = New System.Drawing.Point(731, 9)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(45, 16)
    Me.Label17.TabIndex = 283
    Me.Label17.Text = "Make"
    '
    'Label16
    '
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.Location = New System.Drawing.Point(661, 9)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(36, 16)
    Me.Label16.TabIndex = 282
    Me.Label16.Text = "Year"
    '
    'ChkGolf
    '
    Me.ChkGolf.AutoSize = True
    Me.ChkGolf.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkGolf.Location = New System.Drawing.Point(573, 37)
    Me.ChkGolf.Name = "ChkGolf"
    Me.ChkGolf.Size = New System.Drawing.Size(67, 17)
    Me.ChkGolf.TabIndex = 275
    Me.ChkGolf.Text = "Golf Cart"
    Me.ChkGolf.UseVisualStyleBackColor = True
    '
    'ChkShed
    '
    Me.ChkShed.AutoSize = True
    Me.ChkShed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkShed.Location = New System.Drawing.Point(47, 235)
    Me.ChkShed.Name = "ChkShed"
    Me.ChkShed.Size = New System.Drawing.Size(51, 17)
    Me.ChkShed.TabIndex = 268
    Me.ChkShed.Text = "Shed"
    Me.ChkShed.UseVisualStyleBackColor = True
    '
    'ChkCanopy
    '
    Me.ChkCanopy.AutoSize = True
    Me.ChkCanopy.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkCanopy.Location = New System.Drawing.Point(37, 185)
    Me.ChkCanopy.Name = "ChkCanopy"
    Me.ChkCanopy.Size = New System.Drawing.Size(62, 17)
    Me.ChkCanopy.TabIndex = 261
    Me.ChkCanopy.Text = "Canopy"
    Me.ChkCanopy.UseVisualStyleBackColor = True
    '
    'ChkSun
    '
    Me.ChkSun.AutoSize = True
    Me.ChkSun.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkSun.Location = New System.Drawing.Point(23, 135)
    Me.ChkSun.Name = "ChkSun"
    Me.ChkSun.Size = New System.Drawing.Size(76, 17)
    Me.ChkSun.TabIndex = 254
    Me.ChkSun.Text = "Sun Room"
    Me.ChkSun.UseVisualStyleBackColor = True
    '
    'ChkScreen
    '
    Me.ChkScreen.AutoSize = True
    Me.ChkScreen.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkScreen.Location = New System.Drawing.Point(8, 85)
    Me.ChkScreen.Name = "ChkScreen"
    Me.ChkScreen.Size = New System.Drawing.Size(91, 17)
    Me.ChkScreen.TabIndex = 245
    Me.ChkScreen.Text = "Screen Porch"
    Me.ChkScreen.UseVisualStyleBackColor = True
    '
    'Label9
    '
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(431, 9)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(39, 16)
    Me.Label9.TabIndex = 243
    Me.Label9.Text = "Value"
    '
    'Label7
    '
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(160, 9)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(36, 16)
    Me.Label7.TabIndex = 238
    Me.Label7.Text = "Size"
    '
    'ChkDeck
    '
    Me.ChkDeck.AutoSize = True
    Me.ChkDeck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkDeck.Location = New System.Drawing.Point(47, 35)
    Me.ChkDeck.Name = "ChkDeck"
    Me.ChkDeck.Size = New System.Drawing.Size(52, 17)
    Me.ChkDeck.TabIndex = 236
    Me.ChkDeck.Text = "Deck"
    Me.ChkDeck.UseVisualStyleBackColor = True
    '
    'TpAff
    '
    Me.TpAff.Controls.Add(Me.Label24)
    Me.TpAff.Controls.Add(Me.GroupBox3)
    Me.TpAff.Controls.Add(Me.GroupBox5)
    Me.TpAff.Location = New System.Drawing.Point(4, 22)
    Me.TpAff.Name = "TpAff"
    Me.TpAff.Size = New System.Drawing.Size(953, 292)
    Me.TpAff.TabIndex = 2
    Me.TpAff.Text = "Affidavit"
    Me.TpAff.UseVisualStyleBackColor = True
    '
    'Label24
    '
    Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label24.Location = New System.Drawing.Point(229, 5)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(338, 18)
    Me.Label24.TabIndex = 223
    Me.Label24.Text = "DECLARATION OF PERSONAL PROPERTY AFFIDAVIT"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.Label25)
    Me.GroupBox3.Controls.Add(Me.DtPckWit)
    Me.GroupBox3.Controls.Add(Me.TxtWitName)
    Me.GroupBox3.Controls.Add(Me.Label26)
    Me.GroupBox3.Controls.Add(Me.Label27)
    Me.GroupBox3.Controls.Add(Me.DtPckAgent)
    Me.GroupBox3.Controls.Add(Me.TxtAgentName)
    Me.GroupBox3.Controls.Add(Me.Label29)
    Me.GroupBox3.Controls.Add(Me.Label30)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(7, 129)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(934, 143)
    Me.GroupBox3.TabIndex = 222
    Me.GroupBox3.TabStop = False
    '
    'Label25
    '
    Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label25.Location = New System.Drawing.Point(426, 107)
    Me.Label25.Name = "Label25"
    Me.Label25.Size = New System.Drawing.Size(43, 22)
    Me.Label25.TabIndex = 234
    Me.Label25.Text = "Dated"
    '
    'DtPckWit
    '
    Me.DtPckWit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckWit.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckWit.Location = New System.Drawing.Point(475, 103)
    Me.DtPckWit.Name = "DtPckWit"
    Me.DtPckWit.Size = New System.Drawing.Size(95, 22)
    Me.DtPckWit.TabIndex = 233
    '
    'TxtWitName
    '
    Me.TxtWitName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtWitName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtWitName.Location = New System.Drawing.Point(129, 107)
    Me.TxtWitName.MaxLength = 35
    Me.TxtWitName.Name = "TxtWitName"
    Me.TxtWitName.Size = New System.Drawing.Size(280, 20)
    Me.TxtWitName.TabIndex = 232
    '
    'Label26
    '
    Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label26.Location = New System.Drawing.Point(11, 105)
    Me.Label26.Name = "Label26"
    Me.Label26.Size = New System.Drawing.Size(73, 22)
    Me.Label26.TabIndex = 231
    Me.Label26.Text = "Witness"
    '
    'Label27
    '
    Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label27.Location = New System.Drawing.Point(424, 72)
    Me.Label27.Name = "Label27"
    Me.Label27.Size = New System.Drawing.Size(43, 22)
    Me.Label27.TabIndex = 230
    Me.Label27.Text = "Dated"
    '
    'DtPckAgent
    '
    Me.DtPckAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckAgent.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckAgent.Location = New System.Drawing.Point(473, 68)
    Me.DtPckAgent.Name = "DtPckAgent"
    Me.DtPckAgent.Size = New System.Drawing.Size(97, 22)
    Me.DtPckAgent.TabIndex = 229
    '
    'TxtAgentName
    '
    Me.TxtAgentName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAgentName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAgentName.Location = New System.Drawing.Point(129, 72)
    Me.TxtAgentName.MaxLength = 35
    Me.TxtAgentName.Name = "TxtAgentName"
    Me.TxtAgentName.Size = New System.Drawing.Size(280, 20)
    Me.TxtAgentName.TabIndex = 227
    '
    'Label29
    '
    Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label29.Location = New System.Drawing.Point(14, 72)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(73, 22)
    Me.Label29.TabIndex = 226
    Me.Label29.Text = "Print Name"
    '
    'Label30
    '
    Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label30.Location = New System.Drawing.Point(11, 16)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(755, 32)
    Me.Label30.TabIndex = 225
    Me.Label30.Text = resources.GetString("Label30.Text")
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.Label31)
    Me.GroupBox5.Controls.Add(Me.DtPckOwn)
    Me.GroupBox5.Controls.Add(Me.TxtOwnName)
    Me.GroupBox5.Controls.Add(Me.Label33)
    Me.GroupBox5.Controls.Add(Me.Label34)
    Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox5.Location = New System.Drawing.Point(7, 17)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(934, 106)
    Me.GroupBox5.TabIndex = 221
    Me.GroupBox5.TabStop = False
    '
    'Label31
    '
    Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label31.Location = New System.Drawing.Point(421, 69)
    Me.Label31.Name = "Label31"
    Me.Label31.Size = New System.Drawing.Size(43, 20)
    Me.Label31.TabIndex = 223
    Me.Label31.Text = "Dated"
    '
    'DtPckOwn
    '
    Me.DtPckOwn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckOwn.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckOwn.Location = New System.Drawing.Point(470, 65)
    Me.DtPckOwn.Name = "DtPckOwn"
    Me.DtPckOwn.Size = New System.Drawing.Size(98, 22)
    Me.DtPckOwn.TabIndex = 222
    '
    'TxtOwnName
    '
    Me.TxtOwnName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOwnName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOwnName.Location = New System.Drawing.Point(129, 69)
    Me.TxtOwnName.MaxLength = 35
    Me.TxtOwnName.Name = "TxtOwnName"
    Me.TxtOwnName.Size = New System.Drawing.Size(280, 20)
    Me.TxtOwnName.TabIndex = 12
    '
    'Label33
    '
    Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label33.Location = New System.Drawing.Point(8, 72)
    Me.Label33.Name = "Label33"
    Me.Label33.Size = New System.Drawing.Size(73, 22)
    Me.Label33.TabIndex = 11
    Me.Label33.Text = "Print Name"
    '
    'Label34
    '
    Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label34.Location = New System.Drawing.Point(8, 16)
    Me.Label34.Name = "Label34"
    Me.Label34.Size = New System.Drawing.Size(920, 41)
    Me.Label34.TabIndex = 6
    Me.Label34.Text = resources.GetString("Label34.Text")
    '
    'Label51
    '
    Me.Label51.Location = New System.Drawing.Point(286, 10)
    Me.Label51.Name = "Label51"
    Me.Label51.Size = New System.Drawing.Size(80, 16)
    Me.Label51.TabIndex = 208
    Me.Label51.Text = "Date Received"
    Me.Label51.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'DtPckRecvDt
    '
    Me.DtPckRecvDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckRecvDt.Location = New System.Drawing.Point(375, 6)
    Me.DtPckRecvDt.Name = "DtPckRecvDt"
    Me.DtPckRecvDt.Size = New System.Drawing.Size(88, 20)
    Me.DtPckRecvDt.TabIndex = 2
    '
    'LnkListNo
    '
    Me.LnkListNo.Location = New System.Drawing.Point(12, 9)
    Me.LnkListNo.Name = "LnkListNo"
    Me.LnkListNo.Size = New System.Drawing.Size(48, 16)
    Me.LnkListNo.TabIndex = 206
    Me.LnkListNo.TabStop = True
    Me.LnkListNo.Text = "List No"
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(167, 9)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(35, 17)
    Me.Label13.TabIndex = 205
    Me.Label13.Text = "Year"
    '
    'TxtListNo
    '
    Me.TxtListNo.Location = New System.Drawing.Point(103, 9)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(58, 20)
    Me.TxtListNo.TabIndex = 0
    '
    'TxtFax
    '
    Me.TxtFax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFax.Location = New System.Drawing.Point(253, 139)
    Me.TxtFax.MaxLength = 35
    Me.TxtFax.Name = "TxtFax"
    Me.TxtFax.Size = New System.Drawing.Size(144, 20)
    Me.TxtFax.TabIndex = 10
    '
    'Label15
    '
    Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label15.Location = New System.Drawing.Point(12, 76)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(80, 16)
    Me.Label15.TabIndex = 234
    Me.Label15.Text = "Address"
    '
    'TxtEmail
    '
    Me.TxtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtEmail.Location = New System.Drawing.Point(103, 164)
    Me.TxtEmail.MaxLength = 35
    Me.TxtEmail.Name = "TxtEmail"
    Me.TxtEmail.Size = New System.Drawing.Size(280, 20)
    Me.TxtEmail.TabIndex = 11
    '
    'Label14
    '
    Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label14.Location = New System.Drawing.Point(13, 168)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(80, 16)
    Me.Label14.TabIndex = 233
    Me.Label14.Text = "Email"
    '
    'TxtZip4
    '
    Me.TxtZip4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip4.Location = New System.Drawing.Point(426, 116)
    Me.TxtZip4.MaxLength = 4
    Me.TxtZip4.Name = "TxtZip4"
    Me.TxtZip4.Size = New System.Drawing.Size(32, 20)
    Me.TxtZip4.TabIndex = 8
    '
    'TxtZip5
    '
    Me.TxtZip5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip5.Location = New System.Drawing.Point(378, 116)
    Me.TxtZip5.MaxLength = 5
    Me.TxtZip5.Name = "TxtZip5"
    Me.TxtZip5.Size = New System.Drawing.Size(40, 20)
    Me.TxtZip5.TabIndex = 7
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(13, 116)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(80, 16)
    Me.Label4.TabIndex = 232
    Me.Label4.Text = "City/State/Zip"
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(13, 39)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(80, 16)
    Me.Label3.TabIndex = 231
    Me.Label3.Text = "Name"
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(103, 116)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(232, 20)
    Me.TxtCity.TabIndex = 5
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(346, 116)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 20)
    Me.TxtState.TabIndex = 6
    '
    'TxtAddr
    '
    Me.TxtAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAddr.Location = New System.Drawing.Point(103, 76)
    Me.TxtAddr.MaxLength = 35
    Me.TxtAddr.Name = "TxtAddr"
    Me.TxtAddr.Size = New System.Drawing.Size(280, 20)
    Me.TxtAddr.TabIndex = 4
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(103, 36)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(280, 20)
    Me.TxtName.TabIndex = 3
    '
    'TxtPhone
    '
    Me.TxtPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhone.Location = New System.Drawing.Point(103, 139)
    Me.TxtPhone.MaxLength = 35
    Me.TxtPhone.Name = "TxtPhone"
    Me.TxtPhone.Size = New System.Drawing.Size(144, 20)
    Me.TxtPhone.TabIndex = 9
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(13, 142)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(80, 16)
    Me.Label5.TabIndex = 230
    Me.Label5.Text = "Phone/Fax"
    '
    'TxtLoc
    '
    Me.TxtLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLoc.Location = New System.Drawing.Point(559, 168)
    Me.TxtLoc.MaxLength = 25
    Me.TxtLoc.Name = "TxtLoc"
    Me.TxtLoc.Size = New System.Drawing.Size(184, 20)
    Me.TxtLoc.TabIndex = 13
    '
    'TxtLocNo
    '
    Me.TxtLocNo.Location = New System.Drawing.Point(503, 168)
    Me.TxtLocNo.MaxLength = 7
    Me.TxtLocNo.Name = "TxtLocNo"
    Me.TxtLocNo.Size = New System.Drawing.Size(48, 20)
    Me.TxtLocNo.TabIndex = 12
    Me.TxtLocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label44
    '
    Me.Label44.Location = New System.Drawing.Point(409, 168)
    Me.Label44.Name = "Label44"
    Me.Label44.Size = New System.Drawing.Size(88, 16)
    Me.Label44.TabIndex = 237
    Me.Label44.Text = "Location#/Name"
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblYear.Location = New System.Drawing.Point(207, 8)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(33, 18)
    Me.LblYear.TabIndex = 252
    Me.LblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtAddr2
    '
    Me.TxtAddr2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAddr2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAddr2.Location = New System.Drawing.Point(103, 96)
    Me.TxtAddr2.MaxLength = 35
    Me.TxtAddr2.Name = "TxtAddr2"
    Me.TxtAddr2.Size = New System.Drawing.Size(280, 20)
    Me.TxtAddr2.TabIndex = 5
    '
    'TxtSname
    '
    Me.TxtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSname.Location = New System.Drawing.Point(103, 56)
    Me.TxtSname.MaxLength = 35
    Me.TxtSname.Name = "TxtSname"
    Me.TxtSname.Size = New System.Drawing.Size(280, 20)
    Me.TxtSname.TabIndex = 4
    '
    'FrmTAP03C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(969, 516)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtSname)
    Me.Controls.Add(Me.TxtAddr2)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.TxtLoc)
    Me.Controls.Add(Me.TxtLocNo)
    Me.Controls.Add(Me.Label44)
    Me.Controls.Add(Me.TxtFax)
    Me.Controls.Add(Me.Label15)
    Me.Controls.Add(Me.TxtEmail)
    Me.Controls.Add(Me.Label14)
    Me.Controls.Add(Me.TxtZip4)
    Me.Controls.Add(Me.TxtZip5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtCity)
    Me.Controls.Add(Me.TxtState)
    Me.Controls.Add(Me.TxtAddr)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.TxtPhone)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TabCtl2)
    Me.Controls.Add(Me.Label51)
    Me.Controls.Add(Me.DtPckRecvDt)
    Me.Controls.Add(Me.LnkListNo)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.TxtListNo)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAP03C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Personal Property MV Form"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TabCtl2.ResumeLayout(False)
    Me.TpUnreg.ResumeLayout(False)
    Me.TpUnreg.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.TpImprove.ResumeLayout(False)
    Me.TpImprove.PerformLayout()
    Me.GrpOther.ResumeLayout(False)
    Me.GrpOther.PerformLayout()
    Me.GrpScooter.ResumeLayout(False)
    Me.GrpScooter.PerformLayout()
    Me.GrpCycle.ResumeLayout(False)
    Me.GrpCycle.PerformLayout()
    Me.GrpATV.ResumeLayout(False)
    Me.GrpATV.PerformLayout()
    Me.GrpGolf.ResumeLayout(False)
    Me.GrpGolf.PerformLayout()
    Me.GrpCanopy.ResumeLayout(False)
    Me.GrpCanopy.PerformLayout()
    Me.GrpShed.ResumeLayout(False)
    Me.GrpShed.PerformLayout()
    Me.GrpSun.ResumeLayout(False)
    Me.GrpSun.PerformLayout()
    Me.GrpScreen.ResumeLayout(False)
    Me.GrpScreen.PerformLayout()
    Me.GrpDeck.ResumeLayout(False)
    Me.GrpDeck.PerformLayout()
    Me.TpAff.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTAP03C_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP03
      .TbForms.Visible = False
      .TBarMV.Enabled = True
      .TBarComments.Enabled = False
    End With
  End Sub

  Private Sub FrmTAP03C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    MyTXDVPP = New TXDVPP.MyData(myDBConnect)
    MyTXDVPI = New TXDVPI.MyData(myDBConnect)
    MyTXDVPN = New TXDVPN.MyData(myDBConnect)
    MyTXPPRP = New TXPPRP.MyData(myDBConnect)
    MyTXMSRPDEP = New TXMSRPDEP.MyData(myDBConnect)

    LoadScrn = True
    TxtListNo.Focus()
    With MyFrmTAP03
      .TBarNew.Enabled = False
      .TBarSave.Enabled = True
      .TbForms.Visible = True
      .TBarMV.Enabled = False
      .TBarComments.Enabled = True
    End With

    AddMode = False

    'Fill the dataset with the data
    If WrkListNo > 0 Then
      Me.Text = "Maintain " & Me.Text
      MyFrmTAP03.TBarDelete.Enabled = True
      MyFrmTAP03.TBarPrint.Enabled = False
      TxtListNo.Text = WrkListNo
      LnkListNo.Enabled = False
      TxtListNo.ReadOnly = True
      DtPckRecvDt.Value = Date.Today
      MyTXDVPP.GetOneRecordP(WrkListNo, WrkYear)
      If MyTXDVPP.RecordNotFound Then
        MyFrmTAP03.TBarNew.Enabled = False
        MyFrmTAP03.TBarSave.Enabled = False
        MyFrmTAP03.TBarDelete.Enabled = False
        Me.ErrProv.SetError(TxtListNo, "Record not found")
        Exit Sub
      End If

      With MyTXDVPP
        TxtListNo.Text = ._LISTNO
        LblYear.Text = ._YEAR
        TxtName.Text = Trim(._NAME)
        TxtSname.Text = Trim(._SNAME)
        TxtAddr.Text = Trim(._ADDR)
        TxtAddr2.Text = Trim(._ADDR2)
        TxtCity.Text = Trim(._CITY)
        TxtState.Text = Trim(._STATE)
        If ._ZIP5 > 0 Then
          TxtZip5.Text = Format(._ZIP5, "00000")
        End If
        If ._ZIP4 > 0 Then
          TxtZip4.Text = Format(._ZIP4, "0000")
        End If
        If ._PHONE > 0 Then
          TxtPhone.Text = ._PHONE
        End If
        If ._FAX > 0 Then
          TxtFax.Text = ._FAX
        End If
        TxtLocNo.Text = Trim(._LOCNO)
        TxtLoc.Text = Trim(._LOC)
        TxtEmail.Text = Trim(._EMAIL)
        TxtCampNm.Text = Trim(._CAMPNM)
        TxtCampNo.Text = Trim(._CAMPNO)
        If ._FROMDT > 0 Then
          DtPckFrom.Value = MyUtils.GetDBDate(._FROMDT)
          DtPckFrom.Checked = True
        Else
          DtPckFrom.Value = Date.Today
          DtPckFrom.Checked = False
        End If
        If ._TODT > 0 Then
          DtPckTo.Value = MyUtils.GetDBDate(._TODT)
          DtPckTo.Checked = True
        Else
          DtPckTo.Value = Date.Today
          DtPckTo.Checked = False
        End If
        If ._PROPYR = "Y" Then
          ChkPropYr.Checked = True
        End If
        If ._CTRAIL = "Y" Then
          ChkCTrail.Checked = True
        End If
        If ._TTRAIL = "Y" Then
          ChkTTrail.Checked = True
        End If
        If ._PMODEL = "Y" Then
          ChkPModel.Checked = True
        End If
        If ._MHOME = "Y" Then
          ChkMHome.Checked = True
        End If
        If ._PCHASS = "Y" Then
          ChkPChass.Checked = True
        End If
        If ._SLDON = "Y" Then
          ChkSldOn.Checked = True
        End If
        If ._SLDOUT = "Y" Then
          ChkSldout.Checked = True
        End If
        TxtVYear.Text = ._VYEAR
        TxtMake.Text = Trim(._MAKE)
        TxtModelN.Text = Trim(._MODELN)
        TxtModel.Text = Trim(._MODEL)
        TxtEngine.Text = Trim(._ENGINE)
        TxtChass.Text = Trim(._CHASS)
        TxtLength.Text = ._LENGTH
        TxtWidth.Text = ._WIDTH
        If ._REG = "Y" Then
          ChkReg.Checked = True
        End If
        TxtRegNo.Text = Trim(._REGNO)
        TxtRegWh.Text = Trim(._REGWH)
        If ._PURDT > 0 Then
          DtPckPur.Value = MyUtils.GetDBDate(._PURDT)
          DtPckPur.Checked = True
        Else
          DtPckPur.Value = Date.Today
          DtPckPur.Checked = False
        End If
        TxtPurvl.Text = ._PURVL
        If ._MSRP > 0 Then
          TxtMSRP.Text = ._MSRP
          'MK 8/18/25 Begin
          LblValue.Text = CalcValue(._MSRP, 0, ._VYEAR)
        Else
          LblValue.Text = ._VALUE
          'MK 8/18/25 End
        End If
        'MK 8/18/25 Begin
        'LblValue.Text = ._VALUE
        'MK 8/18/25 End
        If ._ODATE > 0 Then
          DtPckOwn.Value = MyUtils.GetDBDate(._ODATE)
        Else
          DtPckOwn.Value = Date.Today
        End If
        TxtOwnName.Text = Trim(._ONAME)
        If ._ADATE > 0 Then
          DtPckAgent.Value = MyUtils.GetDBDate(._ADATE)
        Else
          DtPckAgent.Value = Date.Today
        End If
        TxtAgentName.Text = Trim(._ANAME)
        TxtWitName.Text = Trim(._WNAME)
        If ._WDATE > 0 Then
          DtPckWit.Value = MyUtils.GetDBDate(._WDATE)
        Else
          DtPckWit.Value = Date.Today
        End If
      End With
      GetImprovements()
      GetNonRegistered()
      CalcTotals()
    Else
      AddMode = True
      Me.Text = "Add " & Me.Text
      LblYear.Text = MyUtils.CnvSng(MyFrmTAP03B.TxtYear.Text)
      'MK 8/18/25 Begin
      WrkYear = MyUtils.CnvSng(MyFrmTAP03B.TxtYear.Text)
      'MK 8/18/25 End
      MyFrmTAP03.TBarDelete.Enabled = False
      MyFrmTAP03.TBarComments.Enabled = False
      MyFrmTAP03.TbForms.Visible = False
      GrpDeck.Enabled = False
      GrpScreen.Enabled = False
      GrpSun.Enabled = False
      GrpCanopy.Enabled = False
      GrpShed.Enabled = False
      GrpGolf.Enabled = False
      GrpATV.Enabled = False
      GrpCycle.Enabled = False
      GrpScooter.Enabled = False
      GrpOther.Enabled = False
    End If

    LoadScrn = False
  End Sub

  Private Sub FrmTAP03C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTAP03.TBarNew.Enabled = True
    MyFrmTAP03.TBarSave.Enabled = False
    MyFrmTAP03.TBarDelete.Enabled = False
    MyFrmTAP03.TBarPrint.Enabled = False
    MyFrmTAP03B.FormatGrid()
    MyFrmTAP03B.Show()

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    MyTXDVPP.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim cCode As Integer = 9
    Dim cLetter As String = String.Empty
    Dim WrkDiff As Integer
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    WrkYear = MyUtils.CnvSng(LblYear.Text)
    MyTXDVPP.GetOneRecordP(WrkListNo, WrkYear)
    If AddMode Then
      If Not MyTXDVPP.RecordNotFound Then
        Me.ErrProv.SetError(TxtListNo, "Record already exists")
        Exit Sub
      End If
    End If

    If Not AddMode Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        WrkDiff = MyUtils.CnvSng(LblValue.Text) - MyTXDVPP._VALUE
        MoveToFile()
        MyTXDVPP.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        WrkDiff = MyUtils.CnvSng(LblValue.Text)
        MoveToFile()
        MyTXDVPP.AddOneRecordP()
        MyFrmTAP03.TBarComments.Enabled = True
        MyFrmTAP03.TbForms.Visible = True
        AddMode = False
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    If WrkDiff <> 0 Then
      WriteTXDCSUM(WrkListNo, WrkYear, cCode, cLetter, WrkDiff)
    End If

    SaveImprovements()
    SaveNonRegistered()

  End Sub
  Private Sub MoveToFile()
    With MyTXDVPP
      ._LISTNO = MyUtils.CnvSng(TxtListNo.Text)
      ._YEAR = MyUtils.CnvSng(LblYear.Text)
      ._NAME = TxtName.Text
      ._SNAME = TxtSname.Text
      ._ADDR = TxtAddr.Text
      ._ADDR2 = TxtAddr2.Text
      ._CITY = TxtCity.Text
      ._STATE = TxtState.Text
      ._ZIP5 = MyUtils.CnvSng(TxtZip5.Text)
      ._ZIP4 = MyUtils.CnvSng(TxtZip4.Text)
      ._PHONE = MyUtils.CnvSng(TxtPhone.Text)
      ._FAX = MyUtils.CnvSng(TxtFax.Text)
      ._EMAIL = TxtEmail.Text
      ._LOC = TxtLoc.Text
      ._LOCNO = TxtLocNo.Text
      ._CAMPNM = TxtCampNm.Text
      ._CAMPNO = TxtCampNo.Text
      If DtPckFrom.Checked Then
        ._FROMDT = MyUtils.SetDBDate(DtPckFrom.Value)
      Else
        ._FROMDT = 0
      End If
      If DtPckTo.Checked Then
        ._TODT = MyUtils.SetDBDate(DtPckTo.Value)
      Else
        ._TODT = 0
      End If
      If ._PROPYR = "Y" Then
        ChkPropYr.Checked = True
      End If
      If ChkCTrail.Checked Then
        ._CTRAIL = "Y"
      Else
        ._CTRAIL = "N"
      End If
      If ChkTTrail.Checked Then
        ._TTRAIL = "Y"
      Else
        ._TTRAIL = "N"
      End If
      If ChkPModel.Checked Then
        ._PMODEL = "Y"
      Else
        ._PMODEL = "N"
      End If
      If ChkMHome.Checked Then
        ._MHOME = "Y"
      Else
        ._MHOME = "N"
      End If
      If ChkPChass.Checked Then
        ._PCHASS = "Y"
      Else
        ._PCHASS = "N"
      End If
      If ChkSldOn.Checked Then
        ._SLDON = "Y"
      Else
        ._SLDON = "N"
      End If
      If ChkSldout.Checked Then
        ._SLDOUT = "Y"
      Else
        ._SLDOUT = "N"
      End If
      ._VYEAR = MyUtils.CnvSng(TxtVYear.Text)
      ._MAKE = TxtMake.Text
      ._MODELN = TxtModelN.Text
      ._MODEL = TxtModel.Text
      ._ENGINE = TxtEngine.Text
      ._CHASS = TxtChass.Text
      ._LENGTH = MyUtils.CnvSng(TxtLength.Text)
      ._WIDTH = MyUtils.CnvSng(TxtWidth.Text)
      If ChkReg.Checked Then
        ._REG = "Y"
      Else
        ._REG = "N"
      End If
      ._REGNO = TxtRegNo.Text
      ._REGWH = TxtRegWh.Text
      If DtPckPur.Checked Then
        ._PURDT = MyUtils.SetDBDate(DtPckPur.Value)
      Else
        ._PURDT = 0
      End If
      ._PURVL = MyUtils.CnvSng(TxtPurvl.Text)
      ._VALUE = MyUtils.CnvSng(LblValue.Text)
      ._MSRP = MyUtils.CnvSng(TxtMSRP.Text)
      If TxtOwnName.Text <> String.Empty Then
        ._ODATE = MyUtils.SetDBDate(DtPckOwn.Value)
      Else
        ._ODATE = 0
      End If
      ._ONAME = TxtOwnName.Text
      If TxtAgentName.Text <> String.Empty Then
        ._ADATE = MyUtils.SetDBDate(DtPckAgent.Value)
      Else
        ._ADATE = 0
      End If
      ._ANAME = TxtAgentName.Text
      If TxtWitName.Text <> String.Empty Then
        ._WDATE = MyUtils.SetDBDate(DtPckWit.Value)
      Else
        ._WDATE = 0
      End If
      ._WNAME = TxtWitName.Text
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
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtListNo, "")
    ErrProv.SetError(TxtName, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "listno"
          ErrProv.SetError(TxtListNo, ErrorMsg(I))
        Case "name"
          ErrProv.SetError(TxtName, ErrorMsg(I))
        Case ""
          Exit Sub
      End Select
    Next I
  End Sub
  Public Sub GetTXPPRP()

    MyTXPPRP.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text))
    If MyTXPPRP.RecordNotFound Then Exit Sub

    With MyTXPPRP
      TxtName.Text = Trim(._NAME)
      TxtSname.Text = Trim(._SNAME)
      TxtAddr.Text = Trim(._ADD1)
      TxtAddr2.Text = Trim(._ADD2)
      TxtCity.Text = Trim(._CITY)
      TxtState.Text = Trim(._STATE)
      If ._ZIP5 > 0 Then
        TxtZip5.Text = Format(._ZIP5, "00000")
      End If
      If ._ZIP4 > 0 Then
        TxtZip4.Text = Format(._ZIP4, "0000")
      End If
      TxtLocNo.Text = Trim(._LOCNO)
      TxtLoc.Text = Trim(._LOC)
    End With

  End Sub
  Private Sub FrmTAP03C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP03.SbpScreen.Text = "TAP03C"
    MyUtils.CenterForm(Me.ParentForm, Me)
    If Not AddMode Then
      MyFrmTAP03.TBarComments.Enabled = True
    End If
  End Sub
  Private Sub LnkListNo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkListNo.LinkClicked
    MyFrmListPPRP = New FrmListPPRP
    MyFrmListPPRP.MdiParent = Me.ParentForm
    MyFrmListPPRP.WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    MyFrmListPPRP.Show()
  End Sub
  Private Sub GetImprovements()
    Dim ds2 As DataSet = New DataSet
    Dim I As Integer

    GrpDeck.Enabled = False
    GrpScreen.Enabled = False
    GrpSun.Enabled = False
    GrpCanopy.Enabled = False
    GrpShed.Enabled = False

    ds2 = MyTXDVPI.GetByList(WrkListNo, WrkYear)
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        Select Case .Item("cat")
          Case "D"
            ChkDeck.Checked = False
            If .Item("value") > 0 Then
              ChkDeck.Checked = True
              GrpDeck.Enabled = True
            End If
            TxtDeckSize1.Text = .Item("size1")
            TxtDeckSize2.Text = .Item("size2")
            Select Case .Item("metal")
              Case "Y"
                RbDeckMetal.Checked = True
              Case "P"
                RbDeckPlastic.Checked = True
              Case "W"
                RbDeckWood.Checked = True
            End Select
            TxtDeckValue.Text = .Item("value")
          Case "P"
            ChkScreen.Checked = False
            If .Item("value") > 0 Then
              ChkScreen.Checked = True
              GrpScreen.Enabled = True
            End If
            TxtScreenSize1.Text = .Item("size1")
            TxtScreenSize2.Text = .Item("size2")
            Select Case .Item("metal")
              Case "M"
                RbScreenMetal.Checked = True
              Case "P"
                RbScreenPlastic.Checked = True
              Case "W"
                RbScreenWood.Checked = True
            End Select
            TxtScreenValue.Text = .Item("value")
          Case "R"
            ChkSun.Checked = False
            If .Item("value") > 0 Then
              ChkSun.Checked = True
              GrpSun.Enabled = True
            End If
            TxtSunSize1.Text = .Item("size1")
            TxtSunSize2.Text = .Item("size2")
            Select Case .Item("metal")
              Case "M"
                RbSunMetal.Checked = True
              Case "P"
                RbSunPlastic.Checked = True
              Case "W"
                RbSunWood.Checked = True
            End Select
            TxtSunValue.Text = .Item("value")
          Case "C"
            ChkCanopy.Checked = False
            If .Item("value") > 0 Then
              ChkCanopy.Checked = True
              GrpCanopy.Enabled = True
            End If
            TxtCanopySize1.Text = .Item("size1")
            TxtCanopySize2.Text = .Item("size2")
            Select Case .Item("metal")
              Case "M"
                RbCanopyMetal.Checked = True
              Case "P"
                RbCanopyPlastic.Checked = True
              Case "W"
                RbCanopyWood.Checked = True
            End Select
            TxtCanopyValue.Text = .Item("value")
          Case "H"
            ChkShed.Checked = False
            If .Item("value") > 0 Then
              ChkShed.Checked = True
              GrpShed.Enabled = True
            End If
            TxtShedSize1.Text = .Item("size1")
            TxtShedSize2.Text = .Item("size2")
            Select Case .Item("metal")
              Case "M"
                RbShedMetal.Checked = True
              Case "P"
                RbShedPlastic.Checked = True
              Case "W"
                RbShedWood.Checked = True
            End Select
            TxtShedValue.Text = .Item("value")
        End Select
      End With
    Next

  End Sub
  Private Sub SaveImprovements()
    Dim cCode As Integer = 24
    Dim cLetter As String = String.Empty
    Dim WrkSaveValue As Integer
    Dim WrkDiff As Integer

    WrkDiff = 0
    MyTXDVPI.GetOneRecordP(WrkListNo, WrkYear, "D")
    With MyTXDVPI
      WrkSaveValue = 0
      If Not .RecordNotFound Then
        WrkSaveValue = ._VALUE
      End If
      If ChkDeck.Checked Then
        ._SIZE1 = MyUtils.CnvSng(TxtDeckSize1.Text)
        ._SIZE2 = MyUtils.CnvSng(TxtDeckSize2.Text)
        If RbDeckMetal.Checked Then ._METAL = "M"
        If RbDeckPlastic.Checked Then ._METAL = "P"
        If RbDeckWood.Checked Then ._METAL = "W"
        ._VALUE = MyUtils.CnvSng(TxtDeckValue.Text)
        If .RecordNotFound Then
          WrkDiff = WrkDiff + ._VALUE
          ._LISTNO = WrkListNo
          ._YEAR = WrkYear
          ._CAT = "D"
          .AddOneRecordP()
        Else
          WrkDiff = WrkDiff + ._VALUE - WrkSaveValue
          .UpdateOneRecordP()
        End If
      Else
        If Not .RecordNotFound Then
          WrkDiff = WrkDiff - WrkSaveValue
          .DeleteOneRecordP()
        End If
      End If

      MyTXDVPI.GetOneRecordP(WrkListNo, WrkYear, "P")
      WrkSaveValue = 0
      If Not .RecordNotFound Then
        WrkSaveValue = ._VALUE
      End If
      If ChkScreen.Checked Then
        ._SIZE1 = MyUtils.CnvSng(TxtScreenSize1.Text)
        ._SIZE2 = MyUtils.CnvSng(TxtScreenSize2.Text)
        If RbScreenMetal.Checked Then ._METAL = "M"
        If RbScreenPlastic.Checked Then ._METAL = "P"
        If RbScreenWood.Checked Then ._METAL = "W"
        ._VALUE = MyUtils.CnvSng(TxtScreenValue.Text)
        If .RecordNotFound Then
          WrkDiff = WrkDiff + ._VALUE
          ._LISTNO = WrkListNo
          ._YEAR = WrkYear
          ._CAT = "P"
          .AddOneRecordP()
        Else
          WrkDiff = WrkDiff + ._VALUE - WrkSaveValue
          .UpdateOneRecordP()
        End If
      Else
        If Not .RecordNotFound Then
          WrkDiff = WrkDiff - WrkSaveValue
          .DeleteOneRecordP()
        End If
      End If

      MyTXDVPI.GetOneRecordP(WrkListNo, WrkYear, "R")
      WrkSaveValue = 0
      If Not .RecordNotFound Then
        WrkSaveValue = ._VALUE
      End If
      If ChkSun.Checked Then
        ._SIZE1 = MyUtils.CnvSng(TxtSunSize1.Text)
        ._SIZE2 = MyUtils.CnvSng(TxtSunSize2.Text)
        If RbSunMetal.Checked Then ._METAL = "M"
        If RbSunPlastic.Checked Then ._METAL = "P"
        If RbSunWood.Checked Then ._METAL = "W"
        ._VALUE = MyUtils.CnvSng(TxtSunValue.Text)
        If .RecordNotFound Then
          WrkDiff = WrkDiff + ._VALUE
          ._LISTNO = WrkListNo
          ._YEAR = WrkYear
          ._CAT = "R"
          .AddOneRecordP()
        Else
          WrkDiff = WrkDiff + ._VALUE - WrkSaveValue
          .UpdateOneRecordP()
        End If
      Else
        If Not .RecordNotFound Then
          WrkDiff = WrkDiff - WrkSaveValue
          .DeleteOneRecordP()
        End If
      End If

      MyTXDVPI.GetOneRecordP(WrkListNo, WrkYear, "C")
      WrkSaveValue = 0
      If Not .RecordNotFound Then
        WrkSaveValue = ._VALUE
      End If
      If ChkCanopy.Checked Then
        ._SIZE1 = MyUtils.CnvSng(TxtCanopySize1.Text)
        ._SIZE2 = MyUtils.CnvSng(TxtCanopySize2.Text)
        If RbCanopyMetal.Checked Then ._METAL = "M"
        If RbCanopyPlastic.Checked Then ._METAL = "P"
        If RbCanopyWood.Checked Then ._METAL = "W"
        ._VALUE = MyUtils.CnvSng(TxtCanopyValue.Text)
        If .RecordNotFound Then
          WrkDiff = WrkDiff + ._VALUE
          ._LISTNO = WrkListNo
          ._YEAR = WrkYear
          ._CAT = "C"
          .AddOneRecordP()
        Else
          WrkDiff = WrkDiff + ._VALUE - WrkSaveValue
          .UpdateOneRecordP()
        End If
      Else
        If Not .RecordNotFound Then
          WrkDiff = WrkDiff - WrkSaveValue
          .DeleteOneRecordP()
        End If
      End If

      MyTXDVPI.GetOneRecordP(WrkListNo, WrkYear, "H")
      WrkSaveValue = 0
      If Not .RecordNotFound Then
        WrkSaveValue = ._VALUE
      End If
      If ChkShed.Checked Then
        ._SIZE1 = MyUtils.CnvSng(TxtShedSize1.Text)
        ._SIZE2 = MyUtils.CnvSng(TxtShedSize2.Text)
        If RbShedMetal.Checked Then ._METAL = "M"
        If RbShedPlastic.Checked Then ._METAL = "P"
        If RbShedWood.Checked Then ._METAL = "W"
        ._VALUE = MyUtils.CnvSng(TxtShedValue.Text)
        If .RecordNotFound Then
          WrkDiff = WrkDiff + ._VALUE
          ._LISTNO = WrkListNo
          ._YEAR = WrkYear
          ._CAT = "H"
          .AddOneRecordP()
        Else
          WrkDiff = WrkDiff + ._VALUE - WrkSaveValue
          .UpdateOneRecordP()
        End If
      Else
        If Not .RecordNotFound Then
          WrkDiff = WrkDiff - WrkSaveValue
          .DeleteOneRecordP()
        End If
      End If
    End With

    WriteTXDCSUM(WrkListNo, WrkYear, cCode, cLetter, WrkDiff)
  End Sub
  Private Sub GetNonRegistered()
    Dim ds2 As DataSet = New DataSet
    Dim I As Integer

    GrpGolf.Enabled = False
    GrpATV.Enabled = False
    GrpCycle.Enabled = False
    GrpScooter.Enabled = False
    GrpOther.Enabled = False

    ds2 = MyTXDVPN.GetByList(WrkListNo, WrkYear)
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        Select Case .Item("cat")
          Case "G"
            ChkGolf.Checked = False
            If .Item("value") > 0 Then
              ChkGolf.Checked = True
              GrpGolf.Enabled = True
            End If
            TxtGolfYear.Text = .Item("vyear")
            TxtGolfMake.Text = Trim(.Item("make"))
            TxtGolfModel.Text = Trim(.Item("model"))
            TxtGolfValue.Text = .Item("value")
          Case "A"
            ChkATV.Checked = False
            If .Item("value") > 0 Then
              ChkATV.Checked = True
              GrpATV.Enabled = True
            End If
            TxtATVYear.Text = .Item("vyear")
            TxtATVMake.Text = Trim(.Item("make"))
            TxtATVModel.Text = Trim(.Item("model"))
            TxtATVValue.Text = .Item("value")
          Case "C"
            ChkCycle.Checked = False
            If .Item("value") > 0 Then
              ChkCycle.Checked = True
              GrpCycle.Enabled = True
            End If
            TxtCycleYear.Text = .Item("vyear")
            TxtCycleMake.Text = Trim(.Item("make"))
            TxtCycleModel.Text = Trim(.Item("model"))
            TxtCycleValue.Text = .Item("value")
          Case "S"
            ChkScooter.Checked = False
            If .Item("value") > 0 Then
              ChkScooter.Checked = True
              GrpScooter.Enabled = True
            End If
            TxtScooterYear.Text = .Item("vyear")
            TxtScooterMake.Text = Trim(.Item("make"))
            TxtScooterModel.Text = Trim(.Item("model"))
            TxtScooterValue.Text = .Item("value")
          Case "O"
            ChkOther.Checked = False
            If .Item("value") > 0 Then
              ChkOther.Checked = True
              GrpOther.Enabled = True
            End If
            TxtOtherYear.Text = .Item("vyear")
            TxtOtherMake.Text = Trim(.Item("make"))
            TxtOtherModel.Text = Trim(.Item("model"))
            TxtOtherValue.Text = .Item("value")
        End Select
      End With
    Next

  End Sub
  Private Sub SaveNonRegistered()
    Dim cCode As Integer = 9
    Dim cLetter As String = String.Empty
    Dim WrkSaveValue As Integer
    Dim WrkDiff As Integer

    WrkDiff = 0

    MyTXDVPN.GetOneRecordP(WrkListNo, WrkYear, "G")
    With MyTXDVPN
      WrkSaveValue = 0
      If Not .RecordNotFound Then
        WrkSaveValue = ._VALUE
      End If
      If ChkGolf.Checked Then
        ._VYEAR = MyUtils.CnvSng(TxtGolfYear.Text)
        ._MAKE = TxtGolfMake.Text
        ._MODEL = TxtGolfModel.Text
        ._VALUE = MyUtils.CnvSng(TxtGolfValue.Text)
        If .RecordNotFound Then
          WrkDiff = WrkDiff + ._VALUE
          ._LISTNO = WrkListNo
          ._YEAR = WrkYear
          ._CAT = "G"
          .AddOneRecordP()
        Else
          WrkDiff = WrkDiff + ._VALUE - WrkSaveValue
          .UpdateOneRecordP()
        End If
      Else
        If Not .RecordNotFound Then
          WrkDiff = WrkDiff - WrkSaveValue
          .DeleteOneRecordP()
        End If
      End If

      MyTXDVPN.GetOneRecordP(WrkListNo, WrkYear, "A")
      WrkSaveValue = 0
      If Not .RecordNotFound Then
        WrkSaveValue = ._VALUE
      End If
      If ChkATV.Checked Then
        ._VYEAR = MyUtils.CnvSng(TxtATVYear.Text)
        ._MAKE = TxtATVMake.Text
        ._MODEL = TxtATVModel.Text
        ._VALUE = MyUtils.CnvSng(TxtATVValue.Text)
        If .RecordNotFound Then
          WrkDiff = WrkDiff + ._VALUE
          ._LISTNO = WrkListNo
          ._YEAR = WrkYear
          ._CAT = "A"
          .AddOneRecordP()
        Else
          WrkDiff = WrkDiff + ._VALUE - WrkSaveValue
          .UpdateOneRecordP()
        End If
      Else
        If Not .RecordNotFound Then
          WrkDiff = WrkDiff - WrkSaveValue
          .DeleteOneRecordP()
        End If
      End If

      MyTXDVPN.GetOneRecordP(WrkListNo, WrkYear, "C")
      WrkSaveValue = 0
      If Not .RecordNotFound Then
        WrkSaveValue = ._VALUE
      End If
      If ChkCycle.Checked Then
        ._VYEAR = MyUtils.CnvSng(TxtCycleYear.Text)
        ._MAKE = TxtCycleMake.Text
        ._MODEL = TxtCycleModel.Text
        ._VALUE = MyUtils.CnvSng(TxtCycleValue.Text)
        If .RecordNotFound Then
          WrkDiff = WrkDiff + ._VALUE
          ._LISTNO = WrkListNo
          ._YEAR = WrkYear
          ._CAT = "C"
          .AddOneRecordP()
        Else
          WrkDiff = WrkDiff + ._VALUE - WrkSaveValue
          .UpdateOneRecordP()
        End If
      Else
        If Not .RecordNotFound Then
          WrkDiff = WrkDiff - WrkSaveValue
          .DeleteOneRecordP()
        End If
      End If

      MyTXDVPN.GetOneRecordP(WrkListNo, WrkYear, "S")
      WrkSaveValue = 0
      If Not .RecordNotFound Then
        WrkSaveValue = ._VALUE
      End If
      If ChkScooter.Checked Then
        ._VYEAR = MyUtils.CnvSng(TxtScooterYear.Text)
        ._MAKE = TxtScooterMake.Text
        ._MODEL = TxtScooterModel.Text
        ._VALUE = MyUtils.CnvSng(TxtScooterValue.Text)
        If .RecordNotFound Then
          WrkDiff = WrkDiff + ._VALUE
          ._LISTNO = WrkListNo
          ._YEAR = WrkYear
          ._CAT = "S"
          .AddOneRecordP()
        Else
          WrkDiff = WrkDiff + ._VALUE - WrkSaveValue
          .UpdateOneRecordP()
        End If
      Else
        If Not .RecordNotFound Then
          WrkDiff = WrkDiff - WrkSaveValue
          .DeleteOneRecordP()
        End If
      End If

      MyTXDVPN.GetOneRecordP(WrkListNo, WrkYear, "O")
      WrkSaveValue = 0
      If Not .RecordNotFound Then
        WrkSaveValue = ._VALUE
      End If
      If ChkOther.Checked Then
        ._VYEAR = MyUtils.CnvSng(TxtOtherYear.Text)
        ._MAKE = TxtOtherMake.Text
        ._MODEL = TxtOtherModel.Text
        ._VALUE = MyUtils.CnvSng(TxtOtherValue.Text)
        If .RecordNotFound Then
          WrkDiff = WrkDiff + ._VALUE
          ._LISTNO = WrkListNo
          ._YEAR = WrkYear
          ._CAT = "O"
          .AddOneRecordP()
        Else
          WrkDiff = WrkDiff + ._VALUE - WrkSaveValue
          .UpdateOneRecordP()
        End If
      Else
        If Not .RecordNotFound Then
          WrkDiff = WrkDiff - WrkSaveValue
          .DeleteOneRecordP()
        End If
      End If
    End With

    WriteTXDCSUM(WrkListNo, WrkYear, cCode, cLetter, WrkDiff)
  End Sub
  Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtListNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtListNo.LostFocus
    If AddMode And Trim(TxtName.Text) = "" Then
      GetTXPPRP()
    End If
  End Sub
  Private Sub TxtZip5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZip5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtZip4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZip4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtVYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtLength_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLength.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtWidth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtWidth.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtPurvl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPurvl.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDeckSize1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDeckSize1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDeckSize2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDeckSize2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDeckValue_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDeckValue.KeyUp
    CalcTotals()
  End Sub
  Private Sub TxtDeckValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDeckValue.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtScreenSize1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtScreenSize1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtScreenSize2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtScreenSize2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtScreenValue_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtScreenValue.KeyUp
    CalcTotals()
  End Sub
  Private Sub TxtScreenValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtScreenValue.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSunSize1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSunSize1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSunSize2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSunSize2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSunValue_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSunValue.KeyUp
    CalcTotals()
  End Sub
  Private Sub TxtSunValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSunValue.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCanopySize1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCanopySize1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCanopySize2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCanopySize1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCanopyValue_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCanopyValue.KeyUp
    CalcTotals()
  End Sub
  Private Sub TxtCanopyValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCanopySize1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtShedSize1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtShedSize1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtShedSize2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtShedSize2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtShedValue_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtShedValue.KeyUp
    CalcTotals()
  End Sub
  Private Sub TxtShedValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtShedValue.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtGolfYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGolfYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtGolfValue_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtGolfValue.KeyUp
    CalcTotals()
  End Sub
  Private Sub TxtGolfValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGolfValue.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtATVYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtATVYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtATVValue_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtATVValue.KeyUp
    CalcTotals()
  End Sub
  Private Sub TxtATVValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtATVValue.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCycleYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCycleYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCycleValue_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCycleValue.KeyUp
    CalcTotals()
  End Sub
  Private Sub TxtCycleValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCycleValue.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtScooterYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtScooterYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtScooterValue_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtScooterValue.KeyUp
    CalcTotals()
  End Sub
  Private Sub TxtScooterValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtScooterValue.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtOtherYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOtherYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtOtherValue_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtOtherValue.KeyUp
    CalcTotals()
  End Sub
  Private Sub TxtOtherValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOtherValue.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub CalcTotals()
    Dim WrkTotal As Integer

    WrkTotal = 0
    If ChkDeck.Checked Then
      WrkTotal = WrkTotal + MyUtils.CnvSng(TxtDeckValue.Text)
    End If
    If ChkScreen.Checked Then
      WrkTotal = WrkTotal + MyUtils.CnvSng(TxtScreenValue.Text)
    End If
    If ChkSun.Checked Then
      WrkTotal = WrkTotal + MyUtils.CnvSng(TxtSunValue.Text)
    End If
    If ChkCanopy.Checked Then
      WrkTotal = WrkTotal + MyUtils.CnvSng(TxtCanopyValue.Text)
    End If
    If ChkShed.Checked Then
      WrkTotal = WrkTotal + MyUtils.CnvSng(TxtShedValue.Text)
    End If
    LblTotImprove.Text = WrkTotal

    WrkTotal = 0
    If ChkGolf.Checked Then
      WrkTotal = WrkTotal + MyUtils.CnvSng(TxtGolfValue.Text)
    End If
    If ChkATV.Checked Then
      WrkTotal = WrkTotal + MyUtils.CnvSng(TxtATVValue.Text)
    End If
    If ChkCycle.Checked Then
      WrkTotal = WrkTotal + MyUtils.CnvSng(TxtCycleValue.Text)
    End If
    If ChkScooter.Checked Then
      WrkTotal = WrkTotal + MyUtils.CnvSng(TxtScooterValue.Text)
    End If
    If ChkOther.Checked Then
      WrkTotal = WrkTotal + MyUtils.CnvSng(TxtOtherValue.Text)
    End If
    LblTotNonReg.Text = WrkTotal
  End Sub

  Private Sub ChkDeck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkDeck.Click
    GrpDeck.Enabled = Not GrpDeck.Enabled
    CalcTotals()
  End Sub
  Private Sub ChkScreen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkScreen.Click
    GrpScreen.Enabled = Not GrpScreen.Enabled
    CalcTotals()
  End Sub
  Private Sub ChkSun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkSun.Click
    GrpSun.Enabled = Not GrpSun.Enabled
    CalcTotals()
  End Sub
  Private Sub ChkCanopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkCanopy.Click
    GrpCanopy.Enabled = Not GrpCanopy.Enabled
    CalcTotals()
  End Sub
  Private Sub ChkShed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkShed.Click
    GrpShed.Enabled = Not GrpShed.Enabled
    CalcTotals()
  End Sub
  Private Sub ChkGolf_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkGolf.Click
    GrpGolf.Enabled = Not GrpGolf.Enabled
    CalcTotals()
  End Sub
  Private Sub ChkATV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkATV.Click
    GrpATV.Enabled = Not GrpATV.Enabled
    CalcTotals()
  End Sub
  Private Sub ChkCycle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkCycle.Click
    GrpCycle.Enabled = Not GrpCycle.Enabled
    CalcTotals()
  End Sub
  Private Sub ChkScooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkScooter.Click
    GrpScooter.Enabled = Not GrpScooter.Enabled
    CalcTotals()
  End Sub
  Private Sub ChkOther_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkOther.Click
    GrpOther.Enabled = Not GrpOther.Enabled
    CalcTotals()
  End Sub

  Private Sub TxtPhone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPhone.KeyPress
    MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFax.KeyPress
    MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtMSRP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMSRP.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtMSRP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMSRP.TextChanged
    Dim WrkMSRP As Integer
    Dim WrkOvMSRP As Integer
    'MK 8/18/25 Begin
    'Dim WrkYear As Integer
    Dim WrkVehYear As Integer
    'MK 8/18/25 Begin
    WrkMSRP = MyUtils.CnvSng(TxtMSRP.Text)
    WrkOvMSRP = 0
    'MK 8/18/25 Begin
    'WrkYear = MyUtils.CnvSng(TxtVYear.Text)
    WrkVehYear = MyUtils.CnvSng(TxtVYear.Text)
    'LblValue.Text = CalcValue(WrkMSRP, WrkOvMSRP, WrkYear)
    LblValue.Text = CalcValue(WrkMSRP, WrkOvMSRP, WrkVehYear)
  End Sub
  'MK 8/18/25 Begin
  'Private Function CalcValue(ByVal WrkMSRP As Integer, ByVal WrkOvMSRP As Integer, ByVal WrkYear As Integer) As Integer
  Private Function CalcValue(ByVal WrkMSRP As Integer, ByVal WrkOvMSRP As Integer, ByVal WrkVehYear As Integer) As Integer
    'MK 8/18/25 End
    Dim WrkDeYear As Integer
    Dim WrkValue As Integer
    Dim WrkDepr As Decimal
    'Calculate Assessment Value
    WrkValue = 0
    WrkDeYear = WrkYear - WrkVehYear + 1
    If WrkDeYear < 1 Then
      WrkDeYear = 1
    End If
    WrkDepr = GetTXMSRPDEP(WrkDeYear)
    If WrkOvMSRP > 0 Then
      WrkValue = WrkOvMSRP * WrkDepr
    Else
      WrkValue = WrkMSRP * WrkDepr
    End If
    'MK 8/18/25 Begin
    'If WrkValue < MyMinValue Then
    If WrkValue > 0 And WrkValue < MyMinValue Then
      'MK 8/18/25 End
      WrkValue = MyMinValue
    End If
    Return WrkValue
  End Function
  Public Function GetTXMSRPDEP(ByVal DeprYear As Integer) As Decimal
    Dim WrkDepr As Decimal
    If DeprYear < 0 Then DeprYear = 1
    WrkDepr = MyTXMSRPDEP.GetDepr(DeprYear)
    Return WrkDepr
  End Function

  Private Sub TpUnreg_Click(sender As Object, e As EventArgs) Handles TpUnreg.Click

  End Sub
End Class
