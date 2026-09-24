Public Class FrmFA102B
Inherits System.Windows.Forms.Form

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
    Friend WithEvents TabCtl1 As System.Windows.Forms.TabControl
    Friend WithEvents TpMain As System.Windows.Forms.TabPage
    Friend WithEvents GrpFunded As System.Windows.Forms.GroupBox
    Friend WithEvents RbFundBoth As System.Windows.Forms.RadioButton
    Friend WithEvents RbFundBusiness As System.Windows.Forms.RadioButton
    Friend WithEvents RbFundGovernment As System.Windows.Forms.RadioButton
    Friend WithEvents GrpDepr As System.Windows.Forms.GroupBox
    Friend WithEvents RbDeprBoth As System.Windows.Forms.RadioButton
    Friend WithEvents RbDeprNon As System.Windows.Forms.RadioButton
    Friend WithEvents RbDeprYes As System.Windows.Forms.RadioButton
    Friend WithEvents GrpAssets As System.Windows.Forms.GroupBox
    Friend WithEvents RbAssetsBoth As System.Windows.Forms.RadioButton
    Friend WithEvents RbAssetsNon As System.Windows.Forms.RadioButton
    Friend WithEvents RbAssetsReport As System.Windows.Forms.RadioButton
    Friend WithEvents GrpPrimary As System.Windows.Forms.GroupBox
    Friend WithEvents RbPUser5 As System.Windows.Forms.RadioButton
    Friend WithEvents RbPUser4 As System.Windows.Forms.RadioButton
    Friend WithEvents RbPUser3 As System.Windows.Forms.RadioButton
    Friend WithEvents RbPUser2 As System.Windows.Forms.RadioButton
    Friend WithEvents RbPUser1 As System.Windows.Forms.RadioButton
    Friend WithEvents RbPGLGrouping As System.Windows.Forms.RadioButton
    Friend WithEvents RbPVendor As System.Windows.Forms.RadioButton
    Friend WithEvents RbPCondition As System.Windows.Forms.RadioButton
    Friend WithEvents RbPLocation As System.Windows.Forms.RadioButton
    Friend WithEvents RbPAssetType As System.Windows.Forms.RadioButton
    Friend WithEvents RbPDepartment As System.Windows.Forms.RadioButton
    Friend WithEvents RbPClassification As System.Windows.Forms.RadioButton
    Friend WithEvents GrpAcqDates As System.Windows.Forms.GroupBox
    Friend WithEvents DtPckAcqTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtPckAcqFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpSecondary As System.Windows.Forms.GroupBox
    Friend WithEvents RbSUser5 As System.Windows.Forms.RadioButton
    Friend WithEvents RbSUser4 As System.Windows.Forms.RadioButton
    Friend WithEvents RbSUser3 As System.Windows.Forms.RadioButton
    Friend WithEvents RbSUser2 As System.Windows.Forms.RadioButton
    Friend WithEvents RbSUser1 As System.Windows.Forms.RadioButton
    Friend WithEvents RbSGLGrouping As System.Windows.Forms.RadioButton
    Friend WithEvents RbSVendor As System.Windows.Forms.RadioButton
    Friend WithEvents RbSCondition As System.Windows.Forms.RadioButton
    Friend WithEvents RbSLocation As System.Windows.Forms.RadioButton
    Friend WithEvents RbSAssetType As System.Windows.Forms.RadioButton
    Friend WithEvents RbSDepartment As System.Windows.Forms.RadioButton
    Friend WithEvents RbSClassification As System.Windows.Forms.RadioButton
    Friend WithEvents TbSelections As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtDeptTo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtAssetValTo As System.Windows.Forms.TextBox
    Friend WithEvents TxtAssetValFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtDeptFrom As System.Windows.Forms.TextBox
    Friend WithEvents LnkDeptTo As System.Windows.Forms.LinkLabel
    Friend WithEvents LnkDeptFrom As System.Windows.Forms.LinkLabel
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TxtUser1To As System.Windows.Forms.TextBox
    Friend WithEvents TxtUser1From As System.Windows.Forms.TextBox
    Friend WithEvents LnkUser1To As System.Windows.Forms.LinkLabel
    Friend WithEvents LnkUser1From As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtEqupTo As System.Windows.Forms.TextBox
    Friend WithEvents TxtEqupFrom As System.Windows.Forms.TextBox
    Friend WithEvents LnkEqupTo As System.Windows.Forms.LinkLabel
    Friend WithEvents LnkEqupFrom As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtClassTo As System.Windows.Forms.TextBox
    Friend WithEvents TxtClassFrom As System.Windows.Forms.TextBox
    Friend WithEvents LnkClassTo As System.Windows.Forms.LinkLabel
    Friend WithEvents LnkClassFrom As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtUser3To As System.Windows.Forms.TextBox
    Friend WithEvents TxtUser3From As System.Windows.Forms.TextBox
    Friend WithEvents LnkUser3To As System.Windows.Forms.LinkLabel
    Friend WithEvents LnkUser3From As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtUser2To As System.Windows.Forms.TextBox
    Friend WithEvents TxtUser2From As System.Windows.Forms.TextBox
    Friend WithEvents LnkUser2To As System.Windows.Forms.LinkLabel
    Friend WithEvents LnkUser2From As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtAsTypeTo As System.Windows.Forms.TextBox
    Friend WithEvents TxtAsTypeFrom As System.Windows.Forms.TextBox
    Friend WithEvents LnkAsTypeTo As System.Windows.Forms.LinkLabel
    Friend WithEvents LnkAsTypeFrom As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtBldgTo As System.Windows.Forms.TextBox
    Friend WithEvents TxtBldgFrom As System.Windows.Forms.TextBox
    Friend WithEvents LnkBldgTo As System.Windows.Forms.LinkLabel
    Friend WithEvents LnkBldgFrom As System.Windows.Forms.LinkLabel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DtPckExpiration As System.Windows.Forms.DateTimePicker

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFA102B))
Me.TabCtl1 = New System.Windows.Forms.TabControl
Me.TpMain = New System.Windows.Forms.TabPage
Me.GrpFunded = New System.Windows.Forms.GroupBox
Me.RbFundBoth = New System.Windows.Forms.RadioButton
Me.RbFundBusiness = New System.Windows.Forms.RadioButton
Me.RbFundGovernment = New System.Windows.Forms.RadioButton
Me.GrpDepr = New System.Windows.Forms.GroupBox
Me.RbDeprBoth = New System.Windows.Forms.RadioButton
Me.RbDeprNon = New System.Windows.Forms.RadioButton
Me.RbDeprYes = New System.Windows.Forms.RadioButton
Me.GrpAssets = New System.Windows.Forms.GroupBox
Me.RbAssetsBoth = New System.Windows.Forms.RadioButton
Me.RbAssetsNon = New System.Windows.Forms.RadioButton
Me.RbAssetsReport = New System.Windows.Forms.RadioButton
Me.GrpPrimary = New System.Windows.Forms.GroupBox
Me.RbPUser5 = New System.Windows.Forms.RadioButton
Me.RbPUser4 = New System.Windows.Forms.RadioButton
Me.RbPUser3 = New System.Windows.Forms.RadioButton
Me.RbPUser2 = New System.Windows.Forms.RadioButton
Me.RbPUser1 = New System.Windows.Forms.RadioButton
Me.RbPGLGrouping = New System.Windows.Forms.RadioButton
Me.RbPVendor = New System.Windows.Forms.RadioButton
Me.RbPCondition = New System.Windows.Forms.RadioButton
Me.RbPLocation = New System.Windows.Forms.RadioButton
Me.RbPAssetType = New System.Windows.Forms.RadioButton
Me.RbPDepartment = New System.Windows.Forms.RadioButton
Me.RbPClassification = New System.Windows.Forms.RadioButton
Me.GrpAcqDates = New System.Windows.Forms.GroupBox
Me.DtPckAcqTo = New System.Windows.Forms.DateTimePicker
Me.Label2 = New System.Windows.Forms.Label
Me.DtPckAcqFrom = New System.Windows.Forms.DateTimePicker
Me.Label1 = New System.Windows.Forms.Label
Me.GrpSecondary = New System.Windows.Forms.GroupBox
Me.RbSUser5 = New System.Windows.Forms.RadioButton
Me.RbSUser4 = New System.Windows.Forms.RadioButton
Me.RbSUser3 = New System.Windows.Forms.RadioButton
Me.RbSUser2 = New System.Windows.Forms.RadioButton
Me.RbSUser1 = New System.Windows.Forms.RadioButton
Me.RbSGLGrouping = New System.Windows.Forms.RadioButton
Me.RbSVendor = New System.Windows.Forms.RadioButton
Me.RbSCondition = New System.Windows.Forms.RadioButton
Me.RbSLocation = New System.Windows.Forms.RadioButton
Me.RbSAssetType = New System.Windows.Forms.RadioButton
Me.RbSDepartment = New System.Windows.Forms.RadioButton
Me.RbSClassification = New System.Windows.Forms.RadioButton
Me.TbSelections = New System.Windows.Forms.TabPage
Me.TxtBldgTo = New System.Windows.Forms.TextBox
Me.TxtBldgFrom = New System.Windows.Forms.TextBox
Me.LnkBldgTo = New System.Windows.Forms.LinkLabel
Me.LnkBldgFrom = New System.Windows.Forms.LinkLabel
Me.TxtAsTypeTo = New System.Windows.Forms.TextBox
Me.TxtAsTypeFrom = New System.Windows.Forms.TextBox
Me.LnkAsTypeTo = New System.Windows.Forms.LinkLabel
Me.LnkAsTypeFrom = New System.Windows.Forms.LinkLabel
Me.TxtUser3To = New System.Windows.Forms.TextBox
Me.TxtUser3From = New System.Windows.Forms.TextBox
Me.LnkUser3To = New System.Windows.Forms.LinkLabel
Me.LnkUser3From = New System.Windows.Forms.LinkLabel
Me.TxtUser2To = New System.Windows.Forms.TextBox
Me.TxtUser2From = New System.Windows.Forms.TextBox
Me.LnkUser2To = New System.Windows.Forms.LinkLabel
Me.LnkUser2From = New System.Windows.Forms.LinkLabel
Me.TxtUser1To = New System.Windows.Forms.TextBox
Me.TxtUser1From = New System.Windows.Forms.TextBox
Me.LnkUser1To = New System.Windows.Forms.LinkLabel
Me.LnkUser1From = New System.Windows.Forms.LinkLabel
Me.TxtEqupTo = New System.Windows.Forms.TextBox
Me.TxtEqupFrom = New System.Windows.Forms.TextBox
Me.LnkEqupTo = New System.Windows.Forms.LinkLabel
Me.LnkEqupFrom = New System.Windows.Forms.LinkLabel
Me.TxtClassTo = New System.Windows.Forms.TextBox
Me.TxtClassFrom = New System.Windows.Forms.TextBox
Me.LnkClassTo = New System.Windows.Forms.LinkLabel
Me.LnkClassFrom = New System.Windows.Forms.LinkLabel
Me.Label3 = New System.Windows.Forms.Label
Me.TxtDeptTo = New System.Windows.Forms.TextBox
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.TxtAssetValTo = New System.Windows.Forms.TextBox
Me.TxtAssetValFrom = New System.Windows.Forms.TextBox
Me.Label8 = New System.Windows.Forms.Label
Me.Label9 = New System.Windows.Forms.Label
Me.TxtDeptFrom = New System.Windows.Forms.TextBox
Me.LnkDeptTo = New System.Windows.Forms.LinkLabel
Me.LnkDeptFrom = New System.Windows.Forms.LinkLabel
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.DtPckExpiration = New System.Windows.Forms.DateTimePicker
Me.Label4 = New System.Windows.Forms.Label
Me.TabCtl1.SuspendLayout()
Me.TpMain.SuspendLayout()
Me.GrpFunded.SuspendLayout()
Me.GrpDepr.SuspendLayout()
Me.GrpAssets.SuspendLayout()
Me.GrpPrimary.SuspendLayout()
Me.GrpAcqDates.SuspendLayout()
Me.GrpSecondary.SuspendLayout()
Me.TbSelections.SuspendLayout()
Me.GroupBox2.SuspendLayout()
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'TabCtl1
'
Me.TabCtl1.Controls.Add(Me.TpMain)
Me.TabCtl1.Controls.Add(Me.TbSelections)
Me.TabCtl1.Location = New System.Drawing.Point(2, 2)
Me.TabCtl1.Name = "TabCtl1"
Me.TabCtl1.SelectedIndex = 0
Me.TabCtl1.Size = New System.Drawing.Size(668, 298)
Me.TabCtl1.TabIndex = 0
'
'TpMain
'
Me.TpMain.Controls.Add(Me.Label4)
Me.TpMain.Controls.Add(Me.DtPckExpiration)
Me.TpMain.Controls.Add(Me.GrpFunded)
Me.TpMain.Controls.Add(Me.GrpDepr)
Me.TpMain.Controls.Add(Me.GrpAssets)
Me.TpMain.Controls.Add(Me.GrpPrimary)
Me.TpMain.Controls.Add(Me.GrpAcqDates)
Me.TpMain.Controls.Add(Me.GrpSecondary)
Me.TpMain.Location = New System.Drawing.Point(4, 22)
Me.TpMain.Name = "TpMain"
Me.TpMain.Padding = New System.Windows.Forms.Padding(3)
Me.TpMain.Size = New System.Drawing.Size(660, 272)
Me.TpMain.TabIndex = 0
Me.TpMain.Text = "Main"
Me.TpMain.UseVisualStyleBackColor = True
'
'GrpFunded
'
Me.GrpFunded.Controls.Add(Me.RbFundBoth)
Me.GrpFunded.Controls.Add(Me.RbFundBusiness)
Me.GrpFunded.Controls.Add(Me.RbFundGovernment)
Me.GrpFunded.Location = New System.Drawing.Point(340, 179)
Me.GrpFunded.Name = "GrpFunded"
Me.GrpFunded.Size = New System.Drawing.Size(101, 88)
Me.GrpFunded.TabIndex = 4
Me.GrpFunded.TabStop = False
Me.GrpFunded.Text = "Funded"
'
'RbFundBoth
'
Me.RbFundBoth.AutoSize = True
Me.RbFundBoth.Checked = True
Me.RbFundBoth.Location = New System.Drawing.Point(6, 65)
Me.RbFundBoth.Name = "RbFundBoth"
Me.RbFundBoth.Size = New System.Drawing.Size(47, 17)
Me.RbFundBoth.TabIndex = 15
Me.RbFundBoth.TabStop = True
Me.RbFundBoth.Text = "Both"
Me.RbFundBoth.UseVisualStyleBackColor = True
'
'RbFundBusiness
'
Me.RbFundBusiness.AutoSize = True
Me.RbFundBusiness.Location = New System.Drawing.Point(6, 42)
Me.RbFundBusiness.Name = "RbFundBusiness"
Me.RbFundBusiness.Size = New System.Drawing.Size(67, 17)
Me.RbFundBusiness.TabIndex = 14
Me.RbFundBusiness.TabStop = True
Me.RbFundBusiness.Text = "Business"
Me.RbFundBusiness.UseVisualStyleBackColor = True
'
'RbFundGovernment
'
Me.RbFundGovernment.AutoSize = True
Me.RbFundGovernment.Location = New System.Drawing.Point(6, 19)
Me.RbFundGovernment.Name = "RbFundGovernment"
Me.RbFundGovernment.Size = New System.Drawing.Size(83, 17)
Me.RbFundGovernment.TabIndex = 13
Me.RbFundGovernment.TabStop = True
Me.RbFundGovernment.Text = "Government"
Me.RbFundGovernment.UseVisualStyleBackColor = True
'
'GrpDepr
'
Me.GrpDepr.Controls.Add(Me.RbDeprBoth)
Me.GrpDepr.Controls.Add(Me.RbDeprNon)
Me.GrpDepr.Controls.Add(Me.RbDeprYes)
Me.GrpDepr.Location = New System.Drawing.Point(447, 179)
Me.GrpDepr.Name = "GrpDepr"
Me.GrpDepr.Size = New System.Drawing.Size(86, 88)
Me.GrpDepr.TabIndex = 5
Me.GrpDepr.TabStop = False
Me.GrpDepr.Text = "Depreciable"
'
'RbDeprBoth
'
Me.RbDeprBoth.AutoSize = True
Me.RbDeprBoth.Location = New System.Drawing.Point(6, 65)
Me.RbDeprBoth.Name = "RbDeprBoth"
Me.RbDeprBoth.Size = New System.Drawing.Size(47, 17)
Me.RbDeprBoth.TabIndex = 15
Me.RbDeprBoth.Text = "Both"
Me.RbDeprBoth.UseVisualStyleBackColor = True
'
'RbDeprNon
'
Me.RbDeprNon.AutoSize = True
Me.RbDeprNon.Location = New System.Drawing.Point(6, 42)
Me.RbDeprNon.Name = "RbDeprNon"
Me.RbDeprNon.Size = New System.Drawing.Size(45, 17)
Me.RbDeprNon.TabIndex = 14
Me.RbDeprNon.TabStop = True
Me.RbDeprNon.Text = "Non"
Me.RbDeprNon.UseVisualStyleBackColor = True
'
'RbDeprYes
'
Me.RbDeprYes.AutoSize = True
Me.RbDeprYes.Checked = True
Me.RbDeprYes.Location = New System.Drawing.Point(6, 19)
Me.RbDeprYes.Name = "RbDeprYes"
Me.RbDeprYes.Size = New System.Drawing.Size(43, 17)
Me.RbDeprYes.TabIndex = 13
Me.RbDeprYes.TabStop = True
Me.RbDeprYes.Text = "Yes"
Me.RbDeprYes.UseVisualStyleBackColor = True
'
'GrpAssets
'
Me.GrpAssets.Controls.Add(Me.RbAssetsBoth)
Me.GrpAssets.Controls.Add(Me.RbAssetsNon)
Me.GrpAssets.Controls.Add(Me.RbAssetsReport)
Me.GrpAssets.Location = New System.Drawing.Point(539, 179)
Me.GrpAssets.Name = "GrpAssets"
Me.GrpAssets.Size = New System.Drawing.Size(114, 88)
Me.GrpAssets.TabIndex = 6
Me.GrpAssets.TabStop = False
Me.GrpAssets.Text = "Assets"
'
'RbAssetsBoth
'
Me.RbAssetsBoth.AutoSize = True
Me.RbAssetsBoth.Location = New System.Drawing.Point(6, 65)
Me.RbAssetsBoth.Name = "RbAssetsBoth"
Me.RbAssetsBoth.Size = New System.Drawing.Size(47, 17)
Me.RbAssetsBoth.TabIndex = 15
Me.RbAssetsBoth.TabStop = True
Me.RbAssetsBoth.Text = "Both"
Me.RbAssetsBoth.UseVisualStyleBackColor = True
'
'RbAssetsNon
'
Me.RbAssetsNon.AutoSize = True
Me.RbAssetsNon.Location = New System.Drawing.Point(6, 42)
Me.RbAssetsNon.Name = "RbAssetsNon"
Me.RbAssetsNon.Size = New System.Drawing.Size(100, 17)
Me.RbAssetsNon.TabIndex = 14
Me.RbAssetsNon.TabStop = True
Me.RbAssetsNon.Text = "Non-Reportable"
Me.RbAssetsNon.UseVisualStyleBackColor = True
'
'RbAssetsReport
'
Me.RbAssetsReport.AutoSize = True
Me.RbAssetsReport.Checked = True
Me.RbAssetsReport.Location = New System.Drawing.Point(6, 19)
Me.RbAssetsReport.Name = "RbAssetsReport"
Me.RbAssetsReport.Size = New System.Drawing.Size(77, 17)
Me.RbAssetsReport.TabIndex = 13
Me.RbAssetsReport.TabStop = True
Me.RbAssetsReport.Text = "Reportable"
Me.RbAssetsReport.UseVisualStyleBackColor = True
'
'GrpPrimary
'
Me.GrpPrimary.Controls.Add(Me.RbPUser5)
Me.GrpPrimary.Controls.Add(Me.RbPUser4)
Me.GrpPrimary.Controls.Add(Me.RbPUser3)
Me.GrpPrimary.Controls.Add(Me.RbPUser2)
Me.GrpPrimary.Controls.Add(Me.RbPUser1)
Me.GrpPrimary.Controls.Add(Me.RbPGLGrouping)
Me.GrpPrimary.Controls.Add(Me.RbPVendor)
Me.GrpPrimary.Controls.Add(Me.RbPCondition)
Me.GrpPrimary.Controls.Add(Me.RbPLocation)
Me.GrpPrimary.Controls.Add(Me.RbPAssetType)
Me.GrpPrimary.Controls.Add(Me.RbPDepartment)
Me.GrpPrimary.Controls.Add(Me.RbPClassification)
Me.GrpPrimary.Location = New System.Drawing.Point(6, 6)
Me.GrpPrimary.Name = "GrpPrimary"
Me.GrpPrimary.Size = New System.Drawing.Size(277, 163)
Me.GrpPrimary.TabIndex = 0
Me.GrpPrimary.TabStop = False
Me.GrpPrimary.Text = "Primary Sort"
'
'RbPUser5
'
Me.RbPUser5.AutoSize = True
Me.RbPUser5.Location = New System.Drawing.Point(139, 134)
Me.RbPUser5.Name = "RbPUser5"
Me.RbPUser5.Size = New System.Drawing.Size(118, 17)
Me.RbPUser5.TabIndex = 12
Me.RbPUser5.Text = "UD5 - User Defined"
Me.RbPUser5.UseVisualStyleBackColor = True
'
'RbPUser4
'
Me.RbPUser4.AutoSize = True
Me.RbPUser4.Location = New System.Drawing.Point(139, 111)
Me.RbPUser4.Name = "RbPUser4"
Me.RbPUser4.Size = New System.Drawing.Size(118, 17)
Me.RbPUser4.TabIndex = 11
Me.RbPUser4.Text = "UD4 - User Defined"
Me.RbPUser4.UseVisualStyleBackColor = True
'
'RbPUser3
'
Me.RbPUser3.AutoSize = True
Me.RbPUser3.Location = New System.Drawing.Point(139, 88)
Me.RbPUser3.Name = "RbPUser3"
Me.RbPUser3.Size = New System.Drawing.Size(118, 17)
Me.RbPUser3.TabIndex = 10
Me.RbPUser3.Text = "UD3 - User Defined"
Me.RbPUser3.UseVisualStyleBackColor = True
'
'RbPUser2
'
Me.RbPUser2.AutoSize = True
Me.RbPUser2.Location = New System.Drawing.Point(139, 65)
Me.RbPUser2.Name = "RbPUser2"
Me.RbPUser2.Size = New System.Drawing.Size(118, 17)
Me.RbPUser2.TabIndex = 9
Me.RbPUser2.Text = "UD2 - User Defined"
Me.RbPUser2.UseVisualStyleBackColor = True
'
'RbPUser1
'
Me.RbPUser1.AutoSize = True
Me.RbPUser1.Location = New System.Drawing.Point(139, 42)
Me.RbPUser1.Name = "RbPUser1"
Me.RbPUser1.Size = New System.Drawing.Size(118, 17)
Me.RbPUser1.TabIndex = 8
Me.RbPUser1.Text = "UD1 - User Defined"
Me.RbPUser1.UseVisualStyleBackColor = True
'
'RbPGLGrouping
'
Me.RbPGLGrouping.AutoSize = True
Me.RbPGLGrouping.Location = New System.Drawing.Point(139, 19)
Me.RbPGLGrouping.Name = "RbPGLGrouping"
Me.RbPGLGrouping.Size = New System.Drawing.Size(113, 17)
Me.RbPGLGrouping.TabIndex = 6
Me.RbPGLGrouping.Text = "GL Grouping Code"
Me.RbPGLGrouping.UseVisualStyleBackColor = True
'
'RbPVendor
'
Me.RbPVendor.AutoSize = True
Me.RbPVendor.Location = New System.Drawing.Point(8, 134)
Me.RbPVendor.Name = "RbPVendor"
Me.RbPVendor.Size = New System.Drawing.Size(99, 17)
Me.RbPVendor.TabIndex = 5
Me.RbPVendor.Text = "Vendor Number"
Me.RbPVendor.UseVisualStyleBackColor = True
'
'RbPCondition
'
Me.RbPCondition.AutoSize = True
Me.RbPCondition.Location = New System.Drawing.Point(8, 111)
Me.RbPCondition.Name = "RbPCondition"
Me.RbPCondition.Size = New System.Drawing.Size(99, 17)
Me.RbPCondition.TabIndex = 4
Me.RbPCondition.Text = "Equip Condition"
Me.RbPCondition.UseVisualStyleBackColor = True
'
'RbPLocation
'
Me.RbPLocation.AutoSize = True
Me.RbPLocation.Location = New System.Drawing.Point(8, 88)
Me.RbPLocation.Name = "RbPLocation"
Me.RbPLocation.Size = New System.Drawing.Size(69, 17)
Me.RbPLocation.TabIndex = 3
Me.RbPLocation.Text = "Location "
Me.RbPLocation.UseVisualStyleBackColor = True
'
'RbPAssetType
'
Me.RbPAssetType.AutoSize = True
Me.RbPAssetType.Location = New System.Drawing.Point(8, 65)
Me.RbPAssetType.Name = "RbPAssetType"
Me.RbPAssetType.Size = New System.Drawing.Size(78, 17)
Me.RbPAssetType.TabIndex = 2
Me.RbPAssetType.Text = "Asset Type"
Me.RbPAssetType.UseVisualStyleBackColor = True
'
'RbPDepartment
'
Me.RbPDepartment.AutoSize = True
Me.RbPDepartment.Location = New System.Drawing.Point(8, 42)
Me.RbPDepartment.Name = "RbPDepartment"
Me.RbPDepartment.Size = New System.Drawing.Size(80, 17)
Me.RbPDepartment.TabIndex = 1
Me.RbPDepartment.Text = "Department"
Me.RbPDepartment.UseVisualStyleBackColor = True
'
'RbPClassification
'
Me.RbPClassification.AutoSize = True
Me.RbPClassification.Checked = True
Me.RbPClassification.Location = New System.Drawing.Point(8, 19)
Me.RbPClassification.Name = "RbPClassification"
Me.RbPClassification.Size = New System.Drawing.Size(86, 17)
Me.RbPClassification.TabIndex = 0
Me.RbPClassification.TabStop = True
Me.RbPClassification.Text = "Classification"
Me.RbPClassification.UseVisualStyleBackColor = True
'
'GrpAcqDates
'
Me.GrpAcqDates.Controls.Add(Me.DtPckAcqTo)
Me.GrpAcqDates.Controls.Add(Me.Label2)
Me.GrpAcqDates.Controls.Add(Me.DtPckAcqFrom)
Me.GrpAcqDates.Controls.Add(Me.Label1)
Me.GrpAcqDates.Location = New System.Drawing.Point(6, 179)
Me.GrpAcqDates.Name = "GrpAcqDates"
Me.GrpAcqDates.Size = New System.Drawing.Size(296, 50)
Me.GrpAcqDates.TabIndex = 2
Me.GrpAcqDates.TabStop = False
Me.GrpAcqDates.Text = "Acquisition Date Range (optional)"
'
'DtPckAcqTo
'
Me.DtPckAcqTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckAcqTo.Location = New System.Drawing.Point(190, 20)
Me.DtPckAcqTo.Name = "DtPckAcqTo"
Me.DtPckAcqTo.ShowCheckBox = True
Me.DtPckAcqTo.Size = New System.Drawing.Size(100, 20)
Me.DtPckAcqTo.TabIndex = 1
Me.DtPckAcqTo.Value = New Date(2005, 10, 6, 9, 11, 0, 906)
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(164, 24)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(28, 16)
Me.Label2.TabIndex = 9
Me.Label2.Text = "To "
'
'DtPckAcqFrom
'
Me.DtPckAcqFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckAcqFrom.Location = New System.Drawing.Point(52, 20)
Me.DtPckAcqFrom.Name = "DtPckAcqFrom"
Me.DtPckAcqFrom.ShowCheckBox = True
Me.DtPckAcqFrom.Size = New System.Drawing.Size(104, 20)
Me.DtPckAcqFrom.TabIndex = 0
Me.DtPckAcqFrom.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(12, 20)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(36, 16)
Me.Label1.TabIndex = 7
Me.Label1.Text = "From"
'
'GrpSecondary
'
Me.GrpSecondary.Controls.Add(Me.RbSUser5)
Me.GrpSecondary.Controls.Add(Me.RbSUser4)
Me.GrpSecondary.Controls.Add(Me.RbSUser3)
Me.GrpSecondary.Controls.Add(Me.RbSUser2)
Me.GrpSecondary.Controls.Add(Me.RbSUser1)
Me.GrpSecondary.Controls.Add(Me.RbSGLGrouping)
Me.GrpSecondary.Controls.Add(Me.RbSVendor)
Me.GrpSecondary.Controls.Add(Me.RbSCondition)
Me.GrpSecondary.Controls.Add(Me.RbSLocation)
Me.GrpSecondary.Controls.Add(Me.RbSAssetType)
Me.GrpSecondary.Controls.Add(Me.RbSDepartment)
Me.GrpSecondary.Controls.Add(Me.RbSClassification)
Me.GrpSecondary.Location = New System.Drawing.Point(340, 6)
Me.GrpSecondary.Name = "GrpSecondary"
Me.GrpSecondary.Size = New System.Drawing.Size(277, 163)
Me.GrpSecondary.TabIndex = 1
Me.GrpSecondary.TabStop = False
Me.GrpSecondary.Text = "Secondary Sort"
'
'RbSUser5
'
Me.RbSUser5.AutoSize = True
Me.RbSUser5.Location = New System.Drawing.Point(139, 134)
Me.RbSUser5.Name = "RbSUser5"
Me.RbSUser5.Size = New System.Drawing.Size(118, 17)
Me.RbSUser5.TabIndex = 12
Me.RbSUser5.TabStop = True
Me.RbSUser5.Text = "UD5 - User Defined"
Me.RbSUser5.UseVisualStyleBackColor = True
'
'RbSUser4
'
Me.RbSUser4.AutoSize = True
Me.RbSUser4.Location = New System.Drawing.Point(139, 111)
Me.RbSUser4.Name = "RbSUser4"
Me.RbSUser4.Size = New System.Drawing.Size(118, 17)
Me.RbSUser4.TabIndex = 11
Me.RbSUser4.TabStop = True
Me.RbSUser4.Text = "UD4 - User Defined"
Me.RbSUser4.UseVisualStyleBackColor = True
'
'RbSUser3
'
Me.RbSUser3.AutoSize = True
Me.RbSUser3.Location = New System.Drawing.Point(139, 88)
Me.RbSUser3.Name = "RbSUser3"
Me.RbSUser3.Size = New System.Drawing.Size(118, 17)
Me.RbSUser3.TabIndex = 10
Me.RbSUser3.TabStop = True
Me.RbSUser3.Text = "UD3 - User Defined"
Me.RbSUser3.UseVisualStyleBackColor = True
'
'RbSUser2
'
Me.RbSUser2.AutoSize = True
Me.RbSUser2.Location = New System.Drawing.Point(139, 65)
Me.RbSUser2.Name = "RbSUser2"
Me.RbSUser2.Size = New System.Drawing.Size(118, 17)
Me.RbSUser2.TabIndex = 9
Me.RbSUser2.TabStop = True
Me.RbSUser2.Text = "UD2 - User Defined"
Me.RbSUser2.UseVisualStyleBackColor = True
'
'RbSUser1
'
Me.RbSUser1.AutoSize = True
Me.RbSUser1.Location = New System.Drawing.Point(139, 42)
Me.RbSUser1.Name = "RbSUser1"
Me.RbSUser1.Size = New System.Drawing.Size(118, 17)
Me.RbSUser1.TabIndex = 8
Me.RbSUser1.TabStop = True
Me.RbSUser1.Text = "UD1 - User Defined"
Me.RbSUser1.UseVisualStyleBackColor = True
'
'RbSGLGrouping
'
Me.RbSGLGrouping.AutoSize = True
Me.RbSGLGrouping.Location = New System.Drawing.Point(139, 19)
Me.RbSGLGrouping.Name = "RbSGLGrouping"
Me.RbSGLGrouping.Size = New System.Drawing.Size(113, 17)
Me.RbSGLGrouping.TabIndex = 6
Me.RbSGLGrouping.TabStop = True
Me.RbSGLGrouping.Text = "GL Grouping Code"
Me.RbSGLGrouping.UseVisualStyleBackColor = True
'
'RbSVendor
'
Me.RbSVendor.AutoSize = True
Me.RbSVendor.Location = New System.Drawing.Point(8, 134)
Me.RbSVendor.Name = "RbSVendor"
Me.RbSVendor.Size = New System.Drawing.Size(99, 17)
Me.RbSVendor.TabIndex = 5
Me.RbSVendor.TabStop = True
Me.RbSVendor.Text = "Vendor Number"
Me.RbSVendor.UseVisualStyleBackColor = True
'
'RbSCondition
'
Me.RbSCondition.AutoSize = True
Me.RbSCondition.Location = New System.Drawing.Point(8, 111)
Me.RbSCondition.Name = "RbSCondition"
Me.RbSCondition.Size = New System.Drawing.Size(99, 17)
Me.RbSCondition.TabIndex = 4
Me.RbSCondition.TabStop = True
Me.RbSCondition.Text = "Equip Condition"
Me.RbSCondition.UseVisualStyleBackColor = True
'
'RbSLocation
'
Me.RbSLocation.AutoSize = True
Me.RbSLocation.Location = New System.Drawing.Point(8, 88)
Me.RbSLocation.Name = "RbSLocation"
Me.RbSLocation.Size = New System.Drawing.Size(66, 17)
Me.RbSLocation.TabIndex = 3
Me.RbSLocation.TabStop = True
Me.RbSLocation.Text = "Location"
Me.RbSLocation.UseVisualStyleBackColor = True
'
'RbSAssetType
'
Me.RbSAssetType.AutoSize = True
Me.RbSAssetType.Location = New System.Drawing.Point(8, 65)
Me.RbSAssetType.Name = "RbSAssetType"
Me.RbSAssetType.Size = New System.Drawing.Size(78, 17)
Me.RbSAssetType.TabIndex = 2
Me.RbSAssetType.TabStop = True
Me.RbSAssetType.Text = "Asset Type"
Me.RbSAssetType.UseVisualStyleBackColor = True
'
'RbSDepartment
'
Me.RbSDepartment.AutoSize = True
Me.RbSDepartment.Location = New System.Drawing.Point(8, 42)
Me.RbSDepartment.Name = "RbSDepartment"
Me.RbSDepartment.Size = New System.Drawing.Size(80, 17)
Me.RbSDepartment.TabIndex = 1
Me.RbSDepartment.TabStop = True
Me.RbSDepartment.Text = "Department"
Me.RbSDepartment.UseVisualStyleBackColor = True
'
'RbSClassification
'
Me.RbSClassification.AutoSize = True
Me.RbSClassification.Location = New System.Drawing.Point(8, 19)
Me.RbSClassification.Name = "RbSClassification"
Me.RbSClassification.Size = New System.Drawing.Size(86, 17)
Me.RbSClassification.TabIndex = 0
Me.RbSClassification.TabStop = True
Me.RbSClassification.Text = "Classification"
Me.RbSClassification.UseVisualStyleBackColor = True
'
'TbSelections
'
Me.TbSelections.Controls.Add(Me.TxtBldgTo)
Me.TbSelections.Controls.Add(Me.TxtBldgFrom)
Me.TbSelections.Controls.Add(Me.LnkBldgTo)
Me.TbSelections.Controls.Add(Me.LnkBldgFrom)
Me.TbSelections.Controls.Add(Me.TxtAsTypeTo)
Me.TbSelections.Controls.Add(Me.TxtAsTypeFrom)
Me.TbSelections.Controls.Add(Me.LnkAsTypeTo)
Me.TbSelections.Controls.Add(Me.LnkAsTypeFrom)
Me.TbSelections.Controls.Add(Me.TxtUser3To)
Me.TbSelections.Controls.Add(Me.TxtUser3From)
Me.TbSelections.Controls.Add(Me.LnkUser3To)
Me.TbSelections.Controls.Add(Me.LnkUser3From)
Me.TbSelections.Controls.Add(Me.TxtUser2To)
Me.TbSelections.Controls.Add(Me.TxtUser2From)
Me.TbSelections.Controls.Add(Me.LnkUser2To)
Me.TbSelections.Controls.Add(Me.LnkUser2From)
Me.TbSelections.Controls.Add(Me.TxtUser1To)
Me.TbSelections.Controls.Add(Me.TxtUser1From)
Me.TbSelections.Controls.Add(Me.LnkUser1To)
Me.TbSelections.Controls.Add(Me.LnkUser1From)
Me.TbSelections.Controls.Add(Me.TxtEqupTo)
Me.TbSelections.Controls.Add(Me.TxtEqupFrom)
Me.TbSelections.Controls.Add(Me.LnkEqupTo)
Me.TbSelections.Controls.Add(Me.LnkEqupFrom)
Me.TbSelections.Controls.Add(Me.TxtClassTo)
Me.TbSelections.Controls.Add(Me.TxtClassFrom)
Me.TbSelections.Controls.Add(Me.LnkClassTo)
Me.TbSelections.Controls.Add(Me.LnkClassFrom)
Me.TbSelections.Controls.Add(Me.Label3)
Me.TbSelections.Controls.Add(Me.TxtDeptTo)
Me.TbSelections.Controls.Add(Me.GroupBox2)
Me.TbSelections.Controls.Add(Me.TxtDeptFrom)
Me.TbSelections.Controls.Add(Me.LnkDeptTo)
Me.TbSelections.Controls.Add(Me.LnkDeptFrom)
Me.TbSelections.Location = New System.Drawing.Point(4, 22)
Me.TbSelections.Name = "TbSelections"
Me.TbSelections.Padding = New System.Windows.Forms.Padding(3)
Me.TbSelections.Size = New System.Drawing.Size(660, 272)
Me.TbSelections.TabIndex = 1
Me.TbSelections.Text = "Selections"
Me.TbSelections.UseVisualStyleBackColor = True
'
'TxtBldgTo
'
Me.TxtBldgTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtBldgTo.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtBldgTo.Location = New System.Drawing.Point(152, 116)
Me.TxtBldgTo.MaxLength = 20
Me.TxtBldgTo.Name = "TxtBldgTo"
Me.TxtBldgTo.Size = New System.Drawing.Size(43, 20)
Me.TxtBldgTo.TabIndex = 7
'
'TxtBldgFrom
'
Me.TxtBldgFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtBldgFrom.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtBldgFrom.Location = New System.Drawing.Point(77, 115)
Me.TxtBldgFrom.MaxLength = 5
Me.TxtBldgFrom.Name = "TxtBldgFrom"
Me.TxtBldgFrom.Size = New System.Drawing.Size(43, 20)
Me.TxtBldgFrom.TabIndex = 6
'
'LnkBldgTo
'
Me.LnkBldgTo.Location = New System.Drawing.Point(126, 118)
Me.LnkBldgTo.Name = "LnkBldgTo"
Me.LnkBldgTo.Size = New System.Drawing.Size(20, 16)
Me.LnkBldgTo.TabIndex = 83
Me.LnkBldgTo.TabStop = True
Me.LnkBldgTo.Text = "to"
'
'LnkBldgFrom
'
Me.LnkBldgFrom.Location = New System.Drawing.Point(6, 118)
Me.LnkBldgFrom.Name = "LnkBldgFrom"
Me.LnkBldgFrom.Size = New System.Drawing.Size(65, 16)
Me.LnkBldgFrom.TabIndex = 82
Me.LnkBldgFrom.TabStop = True
Me.LnkBldgFrom.Text = "Location"
'
'TxtAsTypeTo
'
Me.TxtAsTypeTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtAsTypeTo.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtAsTypeTo.Location = New System.Drawing.Point(152, 41)
Me.TxtAsTypeTo.MaxLength = 20
Me.TxtAsTypeTo.Name = "TxtAsTypeTo"
Me.TxtAsTypeTo.Size = New System.Drawing.Size(43, 20)
Me.TxtAsTypeTo.TabIndex = 1
'
'TxtAsTypeFrom
'
Me.TxtAsTypeFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtAsTypeFrom.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtAsTypeFrom.Location = New System.Drawing.Point(77, 40)
Me.TxtAsTypeFrom.MaxLength = 5
Me.TxtAsTypeFrom.Name = "TxtAsTypeFrom"
Me.TxtAsTypeFrom.Size = New System.Drawing.Size(43, 20)
Me.TxtAsTypeFrom.TabIndex = 0
'
'LnkAsTypeTo
'
Me.LnkAsTypeTo.Location = New System.Drawing.Point(126, 43)
Me.LnkAsTypeTo.Name = "LnkAsTypeTo"
Me.LnkAsTypeTo.Size = New System.Drawing.Size(20, 16)
Me.LnkAsTypeTo.TabIndex = 79
Me.LnkAsTypeTo.TabStop = True
Me.LnkAsTypeTo.Text = "to"
'
'LnkAsTypeFrom
'
Me.LnkAsTypeFrom.Location = New System.Drawing.Point(6, 43)
Me.LnkAsTypeFrom.Name = "LnkAsTypeFrom"
Me.LnkAsTypeFrom.Size = New System.Drawing.Size(65, 16)
Me.LnkAsTypeFrom.TabIndex = 78
Me.LnkAsTypeFrom.TabStop = True
Me.LnkAsTypeFrom.Text = "Asset Type"
'
'TxtUser3To
'
Me.TxtUser3To.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtUser3To.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtUser3To.Location = New System.Drawing.Point(152, 221)
Me.TxtUser3To.MaxLength = 20
Me.TxtUser3To.Name = "TxtUser3To"
Me.TxtUser3To.Size = New System.Drawing.Size(43, 20)
Me.TxtUser3To.TabIndex = 15
'
'TxtUser3From
'
Me.TxtUser3From.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtUser3From.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtUser3From.Location = New System.Drawing.Point(77, 220)
Me.TxtUser3From.MaxLength = 5
Me.TxtUser3From.Name = "TxtUser3From"
Me.TxtUser3From.Size = New System.Drawing.Size(43, 20)
Me.TxtUser3From.TabIndex = 14
'
'LnkUser3To
'
Me.LnkUser3To.Location = New System.Drawing.Point(126, 223)
Me.LnkUser3To.Name = "LnkUser3To"
Me.LnkUser3To.Size = New System.Drawing.Size(20, 16)
Me.LnkUser3To.TabIndex = 75
Me.LnkUser3To.TabStop = True
Me.LnkUser3To.Text = "to"
'
'LnkUser3From
'
Me.LnkUser3From.Location = New System.Drawing.Point(6, 223)
Me.LnkUser3From.Name = "LnkUser3From"
Me.LnkUser3From.Size = New System.Drawing.Size(65, 16)
Me.LnkUser3From.TabIndex = 74
Me.LnkUser3From.TabStop = True
Me.LnkUser3From.Text = "User 3"
'
'TxtUser2To
'
Me.TxtUser2To.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtUser2To.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtUser2To.Location = New System.Drawing.Point(152, 195)
Me.TxtUser2To.MaxLength = 20
Me.TxtUser2To.Name = "TxtUser2To"
Me.TxtUser2To.Size = New System.Drawing.Size(43, 20)
Me.TxtUser2To.TabIndex = 13
'
'TxtUser2From
'
Me.TxtUser2From.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtUser2From.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtUser2From.Location = New System.Drawing.Point(77, 194)
Me.TxtUser2From.MaxLength = 5
Me.TxtUser2From.Name = "TxtUser2From"
Me.TxtUser2From.Size = New System.Drawing.Size(43, 20)
Me.TxtUser2From.TabIndex = 12
'
'LnkUser2To
'
Me.LnkUser2To.Location = New System.Drawing.Point(126, 197)
Me.LnkUser2To.Name = "LnkUser2To"
Me.LnkUser2To.Size = New System.Drawing.Size(20, 16)
Me.LnkUser2To.TabIndex = 71
Me.LnkUser2To.TabStop = True
Me.LnkUser2To.Text = "to"
'
'LnkUser2From
'
Me.LnkUser2From.Location = New System.Drawing.Point(6, 197)
Me.LnkUser2From.Name = "LnkUser2From"
Me.LnkUser2From.Size = New System.Drawing.Size(65, 16)
Me.LnkUser2From.TabIndex = 70
Me.LnkUser2From.TabStop = True
Me.LnkUser2From.Text = "User 2"
'
'TxtUser1To
'
Me.TxtUser1To.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtUser1To.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtUser1To.Location = New System.Drawing.Point(152, 169)
Me.TxtUser1To.MaxLength = 20
Me.TxtUser1To.Name = "TxtUser1To"
Me.TxtUser1To.Size = New System.Drawing.Size(43, 20)
Me.TxtUser1To.TabIndex = 11
'
'TxtUser1From
'
Me.TxtUser1From.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtUser1From.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtUser1From.Location = New System.Drawing.Point(77, 168)
Me.TxtUser1From.MaxLength = 5
Me.TxtUser1From.Name = "TxtUser1From"
Me.TxtUser1From.Size = New System.Drawing.Size(43, 20)
Me.TxtUser1From.TabIndex = 10
'
'LnkUser1To
'
Me.LnkUser1To.Location = New System.Drawing.Point(126, 171)
Me.LnkUser1To.Name = "LnkUser1To"
Me.LnkUser1To.Size = New System.Drawing.Size(20, 16)
Me.LnkUser1To.TabIndex = 67
Me.LnkUser1To.TabStop = True
Me.LnkUser1To.Text = "to"
'
'LnkUser1From
'
Me.LnkUser1From.Location = New System.Drawing.Point(6, 171)
Me.LnkUser1From.Name = "LnkUser1From"
Me.LnkUser1From.Size = New System.Drawing.Size(65, 16)
Me.LnkUser1From.TabIndex = 66
Me.LnkUser1From.TabStop = True
Me.LnkUser1From.Text = "User 1"
'
'TxtEqupTo
'
Me.TxtEqupTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtEqupTo.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtEqupTo.Location = New System.Drawing.Point(152, 142)
Me.TxtEqupTo.MaxLength = 20
Me.TxtEqupTo.Name = "TxtEqupTo"
Me.TxtEqupTo.Size = New System.Drawing.Size(43, 20)
Me.TxtEqupTo.TabIndex = 9
'
'TxtEqupFrom
'
Me.TxtEqupFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtEqupFrom.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtEqupFrom.Location = New System.Drawing.Point(77, 141)
Me.TxtEqupFrom.MaxLength = 5
Me.TxtEqupFrom.Name = "TxtEqupFrom"
Me.TxtEqupFrom.Size = New System.Drawing.Size(43, 20)
Me.TxtEqupFrom.TabIndex = 8
'
'LnkEqupTo
'
Me.LnkEqupTo.Location = New System.Drawing.Point(126, 144)
Me.LnkEqupTo.Name = "LnkEqupTo"
Me.LnkEqupTo.Size = New System.Drawing.Size(20, 16)
Me.LnkEqupTo.TabIndex = 63
Me.LnkEqupTo.TabStop = True
Me.LnkEqupTo.Text = "to"
'
'LnkEqupFrom
'
Me.LnkEqupFrom.Location = New System.Drawing.Point(6, 144)
Me.LnkEqupFrom.Name = "LnkEqupFrom"
Me.LnkEqupFrom.Size = New System.Drawing.Size(65, 16)
Me.LnkEqupFrom.TabIndex = 62
Me.LnkEqupFrom.TabStop = True
Me.LnkEqupFrom.Text = "Equip Cond"
'
'TxtClassTo
'
Me.TxtClassTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtClassTo.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtClassTo.Location = New System.Drawing.Point(152, 65)
Me.TxtClassTo.MaxLength = 20
Me.TxtClassTo.Name = "TxtClassTo"
Me.TxtClassTo.Size = New System.Drawing.Size(43, 20)
Me.TxtClassTo.TabIndex = 3
'
'TxtClassFrom
'
Me.TxtClassFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtClassFrom.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtClassFrom.Location = New System.Drawing.Point(77, 64)
Me.TxtClassFrom.MaxLength = 5
Me.TxtClassFrom.Name = "TxtClassFrom"
Me.TxtClassFrom.Size = New System.Drawing.Size(43, 20)
Me.TxtClassFrom.TabIndex = 2
'
'LnkClassTo
'
Me.LnkClassTo.Location = New System.Drawing.Point(126, 67)
Me.LnkClassTo.Name = "LnkClassTo"
Me.LnkClassTo.Size = New System.Drawing.Size(20, 16)
Me.LnkClassTo.TabIndex = 59
Me.LnkClassTo.TabStop = True
Me.LnkClassTo.Text = "to"
'
'LnkClassFrom
'
Me.LnkClassFrom.Location = New System.Drawing.Point(6, 67)
Me.LnkClassFrom.Name = "LnkClassFrom"
Me.LnkClassFrom.Size = New System.Drawing.Size(65, 16)
Me.LnkClassFrom.TabIndex = 58
Me.LnkClassFrom.TabStop = True
Me.LnkClassFrom.Text = "Class"
'
'Label3
'
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(194, 14)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(166, 22)
Me.Label3.TabIndex = 56
Me.Label3.Text = "Optional Selections" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
'
'TxtDeptTo
'
Me.TxtDeptTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDeptTo.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDeptTo.Location = New System.Drawing.Point(152, 89)
Me.TxtDeptTo.MaxLength = 20
Me.TxtDeptTo.Name = "TxtDeptTo"
Me.TxtDeptTo.Size = New System.Drawing.Size(43, 20)
Me.TxtDeptTo.TabIndex = 5
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.TxtAssetValTo)
Me.GroupBox2.Controls.Add(Me.TxtAssetValFrom)
Me.GroupBox2.Controls.Add(Me.Label8)
Me.GroupBox2.Controls.Add(Me.Label9)
Me.GroupBox2.Location = New System.Drawing.Point(538, 6)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(116, 73)
Me.GroupBox2.TabIndex = 16
Me.GroupBox2.TabStop = False
Me.GroupBox2.Text = "Asset Value Range"
'
'TxtAssetValTo
'
Me.TxtAssetValTo.Location = New System.Drawing.Point(51, 47)
Me.TxtAssetValTo.MaxLength = 5
Me.TxtAssetValTo.Name = "TxtAssetValTo"
Me.TxtAssetValTo.Size = New System.Drawing.Size(45, 20)
Me.TxtAssetValTo.TabIndex = 1
'
'TxtAssetValFrom
'
Me.TxtAssetValFrom.Location = New System.Drawing.Point(51, 27)
Me.TxtAssetValFrom.MaxLength = 5
Me.TxtAssetValFrom.Name = "TxtAssetValFrom"
Me.TxtAssetValFrom.Size = New System.Drawing.Size(45, 20)
Me.TxtAssetValFrom.TabIndex = 0
'
'Label8
'
Me.Label8.Location = New System.Drawing.Point(13, 47)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(28, 16)
Me.Label8.TabIndex = 9
Me.Label8.Text = "To "
'
'Label9
'
Me.Label9.Location = New System.Drawing.Point(12, 31)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(36, 16)
Me.Label9.TabIndex = 7
Me.Label9.Text = "From"
'
'TxtDeptFrom
'
Me.TxtDeptFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDeptFrom.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDeptFrom.Location = New System.Drawing.Point(77, 88)
Me.TxtDeptFrom.MaxLength = 5
Me.TxtDeptFrom.Name = "TxtDeptFrom"
Me.TxtDeptFrom.Size = New System.Drawing.Size(43, 20)
Me.TxtDeptFrom.TabIndex = 4
'
'LnkDeptTo
'
Me.LnkDeptTo.Location = New System.Drawing.Point(126, 91)
Me.LnkDeptTo.Name = "LnkDeptTo"
Me.LnkDeptTo.Size = New System.Drawing.Size(20, 16)
Me.LnkDeptTo.TabIndex = 52
Me.LnkDeptTo.TabStop = True
Me.LnkDeptTo.Text = "to"
'
'LnkDeptFrom
'
Me.LnkDeptFrom.Location = New System.Drawing.Point(6, 91)
Me.LnkDeptFrom.Name = "LnkDeptFrom"
Me.LnkDeptFrom.Size = New System.Drawing.Size(65, 16)
Me.LnkDeptFrom.TabIndex = 51
Me.LnkDeptFrom.TabStop = True
Me.LnkDeptFrom.Text = "Department"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'ImageList1
'
Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
Me.ImageList1.Images.SetKeyName(0, "")
'
'DtPckExpiration
'
Me.DtPckExpiration.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckExpiration.Location = New System.Drawing.Point(75, 240)
Me.DtPckExpiration.Name = "DtPckExpiration"
Me.DtPckExpiration.Size = New System.Drawing.Size(87, 20)
Me.DtPckExpiration.TabIndex = 7
Me.DtPckExpiration.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(11, 244)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(58, 17)
Me.Label4.TabIndex = 8
Me.Label4.Text = "Expiration"
'
'FrmFA102B
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(674, 300)
Me.ControlBox = False
Me.Controls.Add(Me.TabCtl1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmFA102B"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.TabCtl1.ResumeLayout(False)
Me.TpMain.ResumeLayout(False)
Me.GrpFunded.ResumeLayout(False)
Me.GrpFunded.PerformLayout()
Me.GrpDepr.ResumeLayout(False)
Me.GrpDepr.PerformLayout()
Me.GrpAssets.ResumeLayout(False)
Me.GrpAssets.PerformLayout()
Me.GrpPrimary.ResumeLayout(False)
Me.GrpPrimary.PerformLayout()
Me.GrpAcqDates.ResumeLayout(False)
Me.GrpSecondary.ResumeLayout(False)
Me.GrpSecondary.PerformLayout()
Me.TbSelections.ResumeLayout(False)
Me.TbSelections.PerformLayout()
Me.GroupBox2.ResumeLayout(False)
Me.GroupBox2.PerformLayout()
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)

End Sub

#End Region

  Public Sub RunReport()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    Me.Refresh()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmFA102B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    DtPckAcqFrom.Value = Date.Today
    DtPckAcqTo.Value = Date.Today
    DtPckAcqFrom.Checked = False
    DtPckAcqTo.Checked = False
    DtPckExpiration.Value = Date.Today

End Sub
Private Sub FrmFA102B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmFA102.SbpScreen.Text = "FA102B"
End Sub
Private Sub FrmFA102B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(DtPckAcqFrom, "")
    ErrProv.SetError(DtPckAcqTo, "")
    ErrProv.SetError(TxtAsTypeFrom, "")
    ErrProv.SetError(TxtAsTypeTo, "")
    ErrProv.SetError(TxtBldgFrom, "")
    ErrProv.SetError(TxtBldgTo, "")
    ErrProv.SetError(TxtClassFrom, "")
    ErrProv.SetError(TxtClassTo, "")
    ErrProv.SetError(TxtDeptFrom, "")
    ErrProv.SetError(TxtDeptTo, "")
    ErrProv.SetError(TxtEqupFrom, "")
    ErrProv.SetError(TxtEqupTo, "")
    ErrProv.SetError(TxtUser1From, "")
    ErrProv.SetError(TxtUser1To, "")
    ErrProv.SetError(TxtUser2From, "")
    ErrProv.SetError(TxtUser2To, "")
    ErrProv.SetError(TxtUser3From, "")
    ErrProv.SetError(TxtUser3To, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "acqfrom"
        ErrProv.SetError(DtPckAcqFrom, ErrorMsg(I))
      Case "acqto"
        ErrProv.SetError(DtPckAcqTo, ErrorMsg(I))
      Case "astype"
        ErrProv.SetError(TxtAsTypeTo, ErrorMsg(I))
      Case "bldg"
        ErrProv.SetError(TxtBldgTo, ErrorMsg(I))
      Case "class"
        ErrProv.SetError(TxtClassTo, ErrorMsg(I))
      Case "dept"
        ErrProv.SetError(TxtDeptTo, ErrorMsg(I))
      Case "equp"
        ErrProv.SetError(TxtEqupTo, ErrorMsg(I))
      Case "user1"
        ErrProv.SetError(TxtUser1To, ErrorMsg(I))
      Case "user2"
        ErrProv.SetError(TxtUser2To, ErrorMsg(I))
      Case "user3"
        ErrProv.SetError(TxtUser3To, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If DtPckAcqFrom.Checked And DtPckAcqTo.Checked Then
      If MyUtils.SetDBDate(DtPckAcqFrom.Value) > MyUtils.SetDBDate(DtPckAcqTo.Value) Then
        ErrorField(I) = "acqto"
        ErrorMsg(I) = "Invalid Acquisition Date Range"
        I = I + 1
      End If
    End If

    If TxtAsTypeFrom.Text <> "" And TxtAsTypeTo.Text <> "" Then
      If TxtAsTypeFrom.Text > TxtAsTypeTo.Text Then
        ErrorField(I) = "astype"
        ErrorMsg(I) = "Invalid Asset Type Range"
        I = I + 1
      End If
    End If

    If TxtBldgFrom.Text <> "" And TxtBldgTo.Text <> "" Then
      If TxtBldgFrom.Text > TxtBldgTo.Text Then
        ErrorField(I) = "bldg"
        ErrorMsg(I) = "Invalid Location Range"
        I = I + 1
      End If
    End If

    If TxtClassFrom.Text <> "" And TxtClassTo.Text <> "" Then
      If TxtClassFrom.Text > TxtClassTo.Text Then
        ErrorField(I) = "class"
        ErrorMsg(I) = "Invalid Class Range"
        I = I + 1
      End If
    End If

    If TxtDeptFrom.Text <> "" And TxtDeptTo.Text <> "" Then
      If TxtDeptFrom.Text > TxtDeptTo.Text Then
        ErrorField(I) = "dept"
        ErrorMsg(I) = "Invalid Department Range"
        I = I + 1
      End If
    End If

    If TxtEqupFrom.Text <> "" And TxtEqupTo.Text <> "" Then
      If TxtEqupFrom.Text > TxtEqupTo.Text Then
        ErrorField(I) = "equp"
        ErrorMsg(I) = "Invalid Equipment Condition Range"
        I = I + 1
      End If
    End If

    If TxtUser1From.Text <> "" And TxtUser1To.Text <> "" Then
      If TxtUser1From.Text > TxtUser1To.Text Then
        ErrorField(I) = "user1"
        ErrorMsg(I) = "Invalid User 1 Range"
        I = I + 1
      End If
    End If

    If TxtUser2From.Text <> "" And TxtUser2To.Text <> "" Then
      If TxtUser2From.Text > TxtUser2To.Text Then
        ErrorField(I) = "user2"
        ErrorMsg(I) = "Invalid User 2 Range"
        I = I + 1
      End If
    End If

    If TxtUser3From.Text <> "" And TxtUser3To.Text <> "" Then
      If TxtUser3From.Text > TxtUser3To.Text Then
        ErrorField(I) = "user3"
        ErrorMsg(I) = "Invalid User 3 Range"
        I = I + 1
      End If
    End If
  End Sub
Private Sub LnkFrmAsType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkAsTypeFrom.LinkClicked
  MyFrmListAsType = New FrmListAsType
  MyFrmListAsType.MdiParent = Me.ParentForm
  MyFrmListAsType.WrkCode = TxtAsTypeFrom.Text
  MyFrmListAsType.WrkField = "From"
  MyFrmListAsType.Show()
End Sub
Private Sub LnkAsTypeTo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkAsTypeTo.LinkClicked
  MyFrmListAsType = New FrmListAsType
  MyFrmListAsType.MdiParent = Me.ParentForm
  MyFrmListAsType.WrkCode = TxtAsTypeTo.Text
  MyFrmListAsType.WrkField = "To"
  MyFrmListAsType.Show()
End Sub
Private Sub LnkFrmBldg_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBldgFrom.LinkClicked
  MyFrmListBldg = New FrmListBldg
  MyFrmListBldg.MdiParent = Me.ParentForm
  MyFrmListBldg.WrkCode = TxtBldgFrom.Text
  MyFrmListBldg.WrkField = "From"
  MyFrmListBldg.Show()
End Sub
Private Sub LnkBldgTo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBldgTo.LinkClicked
  MyFrmListBldg = New FrmListBldg
  MyFrmListBldg.MdiParent = Me.ParentForm
  MyFrmListBldg.WrkCode = TxtBldgTo.Text
  MyFrmListBldg.WrkField = "To"
  MyFrmListBldg.Show()
End Sub
Private Sub LnkFrmClass_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkClassFrom.LinkClicked
  MyFrmListClass = New FrmListClass
  MyFrmListClass.MdiParent = Me.ParentForm
  MyFrmListClass.WrkCode = TxtClassFrom.Text
  MyFrmListClass.WrkField = "From"
  MyFrmListClass.Show()
End Sub
Private Sub LnkClassTo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkClassTo.LinkClicked
  MyFrmListClass = New FrmListClass
  MyFrmListClass.MdiParent = Me.ParentForm
  MyFrmListClass.WrkCode = TxtClassTo.Text
  MyFrmListClass.WrkField = "To"
  MyFrmListClass.Show()
End Sub
Private Sub LnkFrmDept_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDeptFrom.LinkClicked
  MyFrmListDept = New FrmListDept
  MyFrmListDept.MdiParent = Me.ParentForm
  MyFrmListDept.WrkCode = TxtDeptFrom.Text
  MyFrmListDept.WrkField = "From"
  MyFrmListDept.Show()
End Sub
Private Sub LnkDeptTo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDeptTo.LinkClicked
  MyFrmListDept = New FrmListDept
  MyFrmListDept.MdiParent = Me.ParentForm
  MyFrmListDept.WrkCode = TxtDeptTo.Text
  MyFrmListDept.WrkField = "To"
  MyFrmListDept.Show()
End Sub
Private Sub LnkFrmEqup_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkEqupFrom.LinkClicked
  MyFrmListEqup = New FrmListEqup
  MyFrmListEqup.MdiParent = Me.ParentForm
  MyFrmListEqup.WrkCode = TxtEqupFrom.Text
  MyFrmListEqup.WrkField = "From"
  MyFrmListEqup.Show()
End Sub
Private Sub LnkEqupTo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkEqupTo.LinkClicked
  MyFrmListEqup = New FrmListEqup
  MyFrmListEqup.MdiParent = Me.ParentForm
  MyFrmListEqup.WrkCode = TxtEqupTo.Text
  MyFrmListEqup.WrkField = "To"
  MyFrmListEqup.Show()
End Sub
Private Sub LnkFrmUser1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkUser1From.LinkClicked
  MyFrmListUser1 = New FrmListUser1
  MyFrmListUser1.MdiParent = Me.ParentForm
  MyFrmListUser1.WrkCode = TxtUser1From.Text
  MyFrmListUser1.WrkField = "From"
  MyFrmListUser1.Show()
End Sub
Private Sub LnkUser1To_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkUser1To.LinkClicked
  MyFrmListUser1 = New FrmListUser1
  MyFrmListUser1.MdiParent = Me.ParentForm
  MyFrmListUser1.WrkCode = TxtUser1To.Text
  MyFrmListUser1.WrkField = "To"
  MyFrmListUser1.Show()
End Sub
Private Sub LnkFrmUser2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkUser2From.LinkClicked
  MyFrmListUser2 = New FrmListUser2
  MyFrmListUser2.MdiParent = Me.ParentForm
  MyFrmListUser2.WrkCode = TxtUser2From.Text
  MyFrmListUser2.WrkField = "From"
  MyFrmListUser2.Show()
End Sub
Private Sub LnkUser2To_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkUser2To.LinkClicked
  MyFrmListUser2 = New FrmListUser2
  MyFrmListUser2.MdiParent = Me.ParentForm
  MyFrmListUser2.WrkCode = TxtUser2To.Text
  MyFrmListUser2.WrkField = "To"
  MyFrmListUser2.Show()
End Sub
Private Sub LnkFrmUser3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkUser3From.LinkClicked
  MyFrmListUser3 = New FrmListUser3
  MyFrmListUser3.MdiParent = Me.ParentForm
  MyFrmListUser3.WrkCode = TxtUser3From.Text
  MyFrmListUser3.WrkField = "From"
  MyFrmListUser3.Show()
End Sub
Private Sub LnkUser3To_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkUser3To.LinkClicked
  MyFrmListUser3 = New FrmListUser3
  MyFrmListUser3.MdiParent = Me.ParentForm
  MyFrmListUser3.WrkCode = TxtUser3To.Text
  MyFrmListUser3.WrkField = "To"
  MyFrmListUser3.Show()
End Sub

Private Sub TpMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpMain.Click

End Sub

Private Sub RbPClassification_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbPClassification.CheckedChanged

End Sub

End Class
