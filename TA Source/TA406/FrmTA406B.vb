Imports System.Data
Public Class FrmTA406B
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

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents BtnRefresh As System.Windows.Forms.Button
  Friend WithEvents LnkClass As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtFindClass As System.Windows.Forms.TextBox
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents TxtFindMake As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents BtnFast As System.Windows.Forms.Button
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtFindListNo As System.Windows.Forms.TextBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents GrpMV As System.Windows.Forms.GroupBox
  Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents TxtLastYrVal As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents TxtNada As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents TxtMSRP As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtRegno As System.Windows.Forms.TextBox
  Friend WithEvents TxtVIN As System.Windows.Forms.TextBox
  Friend WithEvents TxtClass As System.Windows.Forms.TextBox
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents TxtBody As System.Windows.Forms.TextBox
  Friend WithEvents TxtModel As System.Windows.Forms.TextBox
  Friend WithEvents TxtValue As System.Windows.Forms.TextBox
  Friend WithEvents TxtMake As System.Windows.Forms.TextBox
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TxtLightWeight As System.Windows.Forms.TextBox
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents TxtGrossWeight As System.Windows.Forms.TextBox
  Friend WithEvents DataGrdView As DataGridView
  Friend WithEvents TxtSource As TextBox
  Friend WithEvents LnkSource As LinkLabel
  Friend WithEvents ChkNonTax As CheckBox
  Friend WithEvents ChkComplete As CheckBox
  Friend WithEvents BtnPriceDigest As Button
  Friend WithEvents GrpPD As GroupBox
  Friend WithEvents LblSubType As Label
  Friend WithEvents Label3 As Label
  Friend WithEvents LblClassification As Label
  Friend WithEvents LblClassificationHdr As Label
  Friend WithEvents LblCatName As Label
  Friend WithEvents LblCatNameHdr As Label
  Friend WithEvents LblMfgName As Label
  Friend WithEvents LblMfgNameHdr As Label
  Friend WithEvents LblClassMin As Label
  Friend WithEvents Label5 As Label
  Friend WithEvents LblRetail As Label
  Friend WithEvents Label7 As Label
  Friend WithEvents Label6 As Label
  Friend WithEvents LblClassMax As Label
  Friend WithEvents LblTradeIn As Label
  Friend WithEvents Label24 As Label
  Friend WithEvents Label23 As Label
  Friend WithEvents LblWholesale As Label
  Friend WithEvents Label21 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.BtnRefresh = New System.Windows.Forms.Button()
    Me.LnkClass = New System.Windows.Forms.LinkLabel()
    Me.TxtFindClass = New System.Windows.Forms.TextBox()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TxtFindMake = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.BtnFast = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtFindListNo = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GrpMV = New System.Windows.Forms.GroupBox()
    Me.BtnPriceDigest = New System.Windows.Forms.Button()
    Me.ChkNonTax = New System.Windows.Forms.CheckBox()
    Me.ChkComplete = New System.Windows.Forms.CheckBox()
    Me.TxtSource = New System.Windows.Forms.TextBox()
    Me.LnkSource = New System.Windows.Forms.LinkLabel()
    Me.TxtLightWeight = New System.Windows.Forms.TextBox()
    Me.Label22 = New System.Windows.Forms.Label()
    Me.TxtGrossWeight = New System.Windows.Forms.TextBox()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.TxtLastYrVal = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TxtNada = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TxtMSRP = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtRegno = New System.Windows.Forms.TextBox()
    Me.TxtVIN = New System.Windows.Forms.TextBox()
    Me.TxtClass = New System.Windows.Forms.TextBox()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.TxtBody = New System.Windows.Forms.TextBox()
    Me.TxtModel = New System.Windows.Forms.TextBox()
    Me.TxtValue = New System.Windows.Forms.TextBox()
    Me.TxtMake = New System.Windows.Forms.TextBox()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.GrpPD = New System.Windows.Forms.GroupBox()
    Me.LblTradeIn = New System.Windows.Forms.Label()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.LblWholesale = New System.Windows.Forms.Label()
    Me.LblRetail = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.LblClassMax = New System.Windows.Forms.Label()
    Me.LblClassMin = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.LblSubType = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.LblClassification = New System.Windows.Forms.Label()
    Me.LblClassificationHdr = New System.Windows.Forms.Label()
    Me.LblCatName = New System.Windows.Forms.Label()
    Me.LblCatNameHdr = New System.Windows.Forms.Label()
    Me.LblMfgName = New System.Windows.Forms.Label()
    Me.LblMfgNameHdr = New System.Windows.Forms.Label()
    Me.GroupBox2.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpMV.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpPD.SuspendLayout()
    Me.SuspendLayout()
    '
    'BtnRefresh
    '
    Me.BtnRefresh.Location = New System.Drawing.Point(224, 12)
    Me.BtnRefresh.Name = "BtnRefresh"
    Me.BtnRefresh.Size = New System.Drawing.Size(53, 24)
    Me.BtnRefresh.TabIndex = 2
    Me.BtnRefresh.Text = "Refresh"
    '
    'LnkClass
    '
    Me.LnkClass.AutoSize = True
    Me.LnkClass.Location = New System.Drawing.Point(12, 18)
    Me.LnkClass.Name = "LnkClass"
    Me.LnkClass.Size = New System.Drawing.Size(32, 13)
    Me.LnkClass.TabIndex = 198
    Me.LnkClass.TabStop = True
    Me.LnkClass.Text = "Class"
    '
    'TxtFindClass
    '
    Me.TxtFindClass.Location = New System.Drawing.Point(50, 15)
    Me.TxtFindClass.MaxLength = 2
    Me.TxtFindClass.Name = "TxtFindClass"
    Me.TxtFindClass.Size = New System.Drawing.Size(25, 20)
    Me.TxtFindClass.TabIndex = 0
    '
    'TxtFindMake
    '
    Me.TxtFindMake.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFindMake.Location = New System.Drawing.Point(152, 15)
    Me.TxtFindMake.MaxLength = 5
    Me.TxtFindMake.Name = "TxtFindMake"
    Me.TxtFindMake.Size = New System.Drawing.Size(66, 20)
    Me.TxtFindMake.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(107, 18)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(34, 13)
    Me.Label1.TabIndex = 200
    Me.Label1.Text = "Make"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.BtnFast)
    Me.GroupBox2.Controls.Add(Me.Label2)
    Me.GroupBox2.Controls.Add(Me.TxtFindListNo)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(556, 2)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(179, 48)
    Me.GroupBox2.TabIndex = 204
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Fast Path"
    '
    'BtnFast
    '
    Me.BtnFast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFast.Location = New System.Drawing.Point(108, 12)
    Me.BtnFast.Name = "BtnFast"
    Me.BtnFast.Size = New System.Drawing.Size(53, 24)
    Me.BtnFast.TabIndex = 3
    Me.BtnFast.Text = "S&how"
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(8, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(32, 16)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "List#"
    '
    'TxtFindListNo
    '
    Me.TxtFindListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFindListNo.Location = New System.Drawing.Point(40, 16)
    Me.TxtFindListNo.MaxLength = 7
    Me.TxtFindListNo.Name = "TxtFindListNo"
    Me.TxtFindListNo.Size = New System.Drawing.Size(62, 20)
    Me.TxtFindListNo.TabIndex = 1
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GrpMV
    '
    Me.GrpMV.Controls.Add(Me.BtnPriceDigest)
    Me.GrpMV.Controls.Add(Me.ChkNonTax)
    Me.GrpMV.Controls.Add(Me.ChkComplete)
    Me.GrpMV.Controls.Add(Me.TxtSource)
    Me.GrpMV.Controls.Add(Me.LnkSource)
    Me.GrpMV.Controls.Add(Me.TxtLightWeight)
    Me.GrpMV.Controls.Add(Me.Label22)
    Me.GrpMV.Controls.Add(Me.TxtGrossWeight)
    Me.GrpMV.Controls.Add(Me.Label21)
    Me.GrpMV.Controls.Add(Me.TxtListNo)
    Me.GrpMV.Controls.Add(Me.TxtName)
    Me.GrpMV.Controls.Add(Me.Label19)
    Me.GrpMV.Controls.Add(Me.Label20)
    Me.GrpMV.Controls.Add(Me.TxtLastYrVal)
    Me.GrpMV.Controls.Add(Me.Label11)
    Me.GrpMV.Controls.Add(Me.TxtNada)
    Me.GrpMV.Controls.Add(Me.Label9)
    Me.GrpMV.Controls.Add(Me.TxtMSRP)
    Me.GrpMV.Controls.Add(Me.Label8)
    Me.GrpMV.Controls.Add(Me.TxtRegno)
    Me.GrpMV.Controls.Add(Me.TxtVIN)
    Me.GrpMV.Controls.Add(Me.TxtClass)
    Me.GrpMV.Controls.Add(Me.TxtYear)
    Me.GrpMV.Controls.Add(Me.TxtBody)
    Me.GrpMV.Controls.Add(Me.TxtModel)
    Me.GrpMV.Controls.Add(Me.TxtValue)
    Me.GrpMV.Controls.Add(Me.TxtMake)
    Me.GrpMV.Controls.Add(Me.Label18)
    Me.GrpMV.Controls.Add(Me.Label17)
    Me.GrpMV.Controls.Add(Me.Label16)
    Me.GrpMV.Controls.Add(Me.Label15)
    Me.GrpMV.Controls.Add(Me.Label14)
    Me.GrpMV.Controls.Add(Me.Label13)
    Me.GrpMV.Controls.Add(Me.Label12)
    Me.GrpMV.Controls.Add(Me.Label10)
    Me.GrpMV.Location = New System.Drawing.Point(16, 284)
    Me.GrpMV.Name = "GrpMV"
    Me.GrpMV.Size = New System.Drawing.Size(618, 158)
    Me.GrpMV.TabIndex = 239
    Me.GrpMV.TabStop = False
    '
    'BtnPriceDigest
    '
    Me.BtnPriceDigest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnPriceDigest.Location = New System.Drawing.Point(534, 14)
    Me.BtnPriceDigest.Name = "BtnPriceDigest"
    Me.BtnPriceDigest.Size = New System.Drawing.Size(74, 24)
    Me.BtnPriceDigest.TabIndex = 279
    Me.BtnPriceDigest.Text = "Price Digest"
    '
    'ChkNonTax
    '
    Me.ChkNonTax.AutoSize = True
    Me.ChkNonTax.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkNonTax.Location = New System.Drawing.Point(473, 73)
    Me.ChkNonTax.Name = "ChkNonTax"
    Me.ChkNonTax.Size = New System.Drawing.Size(93, 17)
    Me.ChkNonTax.TabIndex = 249
    Me.ChkNonTax.Text = "Non Taxable?"
    '
    'ChkComplete
    '
    Me.ChkComplete.AutoSize = True
    Me.ChkComplete.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkComplete.Location = New System.Drawing.Point(379, 74)
    Me.ChkComplete.Name = "ChkComplete"
    Me.ChkComplete.Size = New System.Drawing.Size(76, 17)
    Me.ChkComplete.TabIndex = 248
    Me.ChkComplete.Text = "Complete?"
    '
    'TxtSource
    '
    Me.TxtSource.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSource.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSource.Location = New System.Drawing.Point(89, 71)
    Me.TxtSource.MaxLength = 2
    Me.TxtSource.Name = "TxtSource"
    Me.TxtSource.Size = New System.Drawing.Size(19, 22)
    Me.TxtSource.TabIndex = 277
    '
    'LnkSource
    '
    Me.LnkSource.AutoSize = True
    Me.LnkSource.Location = New System.Drawing.Point(76, 55)
    Me.LnkSource.Name = "LnkSource"
    Me.LnkSource.Size = New System.Drawing.Size(41, 13)
    Me.LnkSource.TabIndex = 278
    Me.LnkSource.TabStop = True
    Me.LnkSource.Text = "Source"
    '
    'TxtLightWeight
    '
    Me.TxtLightWeight.Location = New System.Drawing.Point(154, 128)
    Me.TxtLightWeight.MaxLength = 9
    Me.TxtLightWeight.Name = "TxtLightWeight"
    Me.TxtLightWeight.Size = New System.Drawing.Size(64, 20)
    Me.TxtLightWeight.TabIndex = 275
    Me.TxtLightWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label22
    '
    Me.Label22.Location = New System.Drawing.Point(151, 110)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(74, 13)
    Me.Label22.TabIndex = 276
    Me.Label22.Text = "Light Weight"
    '
    'TxtGrossWeight
    '
    Me.TxtGrossWeight.Location = New System.Drawing.Point(79, 128)
    Me.TxtGrossWeight.MaxLength = 9
    Me.TxtGrossWeight.Name = "TxtGrossWeight"
    Me.TxtGrossWeight.Size = New System.Drawing.Size(64, 20)
    Me.TxtGrossWeight.TabIndex = 273
    Me.TxtGrossWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label21
    '
    Me.Label21.Location = New System.Drawing.Point(76, 110)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(74, 13)
    Me.Label21.TabIndex = 274
    Me.Label21.Text = "Gross Weight"
    '
    'TxtListNo
    '
    Me.TxtListNo.Location = New System.Drawing.Point(67, 17)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(56, 20)
    Me.TxtListNo.TabIndex = 269
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Location = New System.Drawing.Point(210, 16)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(280, 20)
    Me.TxtName.TabIndex = 270
    '
    'Label19
    '
    Me.Label19.Location = New System.Drawing.Point(6, 16)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(40, 16)
    Me.Label19.TabIndex = 272
    Me.Label19.Text = "List No"
    '
    'Label20
    '
    Me.Label20.Location = New System.Drawing.Point(161, 17)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(48, 16)
    Me.Label20.TabIndex = 271
    Me.Label20.Text = "Name"
    '
    'TxtLastYrVal
    '
    Me.TxtLastYrVal.Location = New System.Drawing.Point(309, 128)
    Me.TxtLastYrVal.MaxLength = 9
    Me.TxtLastYrVal.Name = "TxtLastYrVal"
    Me.TxtLastYrVal.Size = New System.Drawing.Size(64, 20)
    Me.TxtLastYrVal.TabIndex = 267
    Me.TxtLastYrVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label11
    '
    Me.Label11.Location = New System.Drawing.Point(300, 110)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(91, 13)
    Me.Label11.TabIndex = 268
    Me.Label11.Text = "Last Year Value"
    '
    'TxtNada
    '
    Me.TxtNada.Location = New System.Drawing.Point(6, 128)
    Me.TxtNada.MaxLength = 9
    Me.TxtNada.Name = "TxtNada"
    Me.TxtNada.Size = New System.Drawing.Size(64, 20)
    Me.TxtNada.TabIndex = 265
    Me.TxtNada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(6, 110)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(64, 15)
    Me.Label9.TabIndex = 266
    Me.Label9.Text = "Error Code"
    '
    'TxtMSRP
    '
    Me.TxtMSRP.Location = New System.Drawing.Point(8, 73)
    Me.TxtMSRP.MaxLength = 9
    Me.TxtMSRP.Name = "TxtMSRP"
    Me.TxtMSRP.Size = New System.Drawing.Size(64, 20)
    Me.TxtMSRP.TabIndex = 263
    Me.TxtMSRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(6, 57)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(74, 13)
    Me.Label8.TabIndex = 264
    Me.Label8.Text = "100% MSRP" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
    '
    'TxtRegno
    '
    Me.TxtRegno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRegno.Location = New System.Drawing.Point(534, 125)
    Me.TxtRegno.MaxLength = 8
    Me.TxtRegno.Name = "TxtRegno"
    Me.TxtRegno.Size = New System.Drawing.Size(72, 20)
    Me.TxtRegno.TabIndex = 249
    '
    'TxtVIN
    '
    Me.TxtVIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVIN.Location = New System.Drawing.Point(397, 126)
    Me.TxtVIN.MaxLength = 17
    Me.TxtVIN.Name = "TxtVIN"
    Me.TxtVIN.Size = New System.Drawing.Size(131, 20)
    Me.TxtVIN.TabIndex = 248
    '
    'TxtClass
    '
    Me.TxtClass.Location = New System.Drawing.Point(345, 73)
    Me.TxtClass.MaxLength = 2
    Me.TxtClass.Name = "TxtClass"
    Me.TxtClass.Size = New System.Drawing.Size(28, 20)
    Me.TxtClass.TabIndex = 247
    '
    'TxtYear
    '
    Me.TxtYear.Location = New System.Drawing.Point(305, 73)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(40, 20)
    Me.TxtYear.TabIndex = 246
    '
    'TxtBody
    '
    Me.TxtBody.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBody.Location = New System.Drawing.Point(249, 73)
    Me.TxtBody.MaxLength = 6
    Me.TxtBody.Name = "TxtBody"
    Me.TxtBody.Size = New System.Drawing.Size(56, 20)
    Me.TxtBody.TabIndex = 245
    '
    'TxtModel
    '
    Me.TxtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtModel.Location = New System.Drawing.Point(177, 73)
    Me.TxtModel.MaxLength = 8
    Me.TxtModel.Name = "TxtModel"
    Me.TxtModel.Size = New System.Drawing.Size(68, 20)
    Me.TxtModel.TabIndex = 244
    '
    'TxtValue
    '
    Me.TxtValue.Location = New System.Drawing.Point(230, 129)
    Me.TxtValue.MaxLength = 9
    Me.TxtValue.Name = "TxtValue"
    Me.TxtValue.Size = New System.Drawing.Size(64, 20)
    Me.TxtValue.TabIndex = 242
    Me.TxtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtMake
    '
    Me.TxtMake.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMake.Location = New System.Drawing.Point(125, 73)
    Me.TxtMake.MaxLength = 5
    Me.TxtMake.Name = "TxtMake"
    Me.TxtMake.Size = New System.Drawing.Size(52, 20)
    Me.TxtMake.TabIndex = 243
    '
    'Label18
    '
    Me.Label18.Location = New System.Drawing.Point(531, 108)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(44, 16)
    Me.Label18.TabIndex = 257
    Me.Label18.Text = "Reg #"
    '
    'Label17
    '
    Me.Label17.Location = New System.Drawing.Point(397, 110)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(44, 16)
    Me.Label17.TabIndex = 256
    Me.Label17.Text = "VIN #"
    '
    'Label16
    '
    Me.Label16.Location = New System.Drawing.Point(345, 57)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(44, 16)
    Me.Label16.TabIndex = 255
    Me.Label16.Text = "Class"
    '
    'Label15
    '
    Me.Label15.Location = New System.Drawing.Point(305, 57)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(36, 16)
    Me.Label15.TabIndex = 254
    Me.Label15.Text = "Year"
    '
    'Label14
    '
    Me.Label14.Location = New System.Drawing.Point(249, 57)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(36, 16)
    Me.Label14.TabIndex = 253
    Me.Label14.Text = "Body"
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(177, 57)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(44, 16)
    Me.Label13.TabIndex = 252
    Me.Label13.Text = "Model"
    '
    'Label12
    '
    Me.Label12.Location = New System.Drawing.Point(240, 110)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(44, 16)
    Me.Label12.TabIndex = 251
    Me.Label12.Text = "Value"
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(133, 57)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(44, 16)
    Me.Label10.TabIndex = 250
    Me.Label10.Text = "Make"
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle1
    Me.DataGrdView.Location = New System.Drawing.Point(16, 56)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(719, 222)
    Me.DataGrdView.TabIndex = 240
    '
    'GrpPD
    '
    Me.GrpPD.Controls.Add(Me.LblTradeIn)
    Me.GrpPD.Controls.Add(Me.Label24)
    Me.GrpPD.Controls.Add(Me.Label23)
    Me.GrpPD.Controls.Add(Me.LblWholesale)
    Me.GrpPD.Controls.Add(Me.LblRetail)
    Me.GrpPD.Controls.Add(Me.Label7)
    Me.GrpPD.Controls.Add(Me.Label6)
    Me.GrpPD.Controls.Add(Me.LblClassMax)
    Me.GrpPD.Controls.Add(Me.LblClassMin)
    Me.GrpPD.Controls.Add(Me.Label5)
    Me.GrpPD.Controls.Add(Me.LblSubType)
    Me.GrpPD.Controls.Add(Me.Label3)
    Me.GrpPD.Controls.Add(Me.LblClassification)
    Me.GrpPD.Controls.Add(Me.LblClassificationHdr)
    Me.GrpPD.Controls.Add(Me.LblCatName)
    Me.GrpPD.Controls.Add(Me.LblCatNameHdr)
    Me.GrpPD.Controls.Add(Me.LblMfgName)
    Me.GrpPD.Controls.Add(Me.LblMfgNameHdr)
    Me.GrpPD.Location = New System.Drawing.Point(640, 284)
    Me.GrpPD.Name = "GrpPD"
    Me.GrpPD.Size = New System.Drawing.Size(179, 158)
    Me.GrpPD.TabIndex = 280
    Me.GrpPD.TabStop = False
    '
    'LblTradeIn
    '
    Me.LblTradeIn.AutoSize = True
    Me.LblTradeIn.Location = New System.Drawing.Point(72, 119)
    Me.LblTradeIn.Name = "LblTradeIn"
    Me.LblTradeIn.Size = New System.Drawing.Size(59, 13)
    Me.LblTradeIn.TabIndex = 297
    Me.LblTradeIn.Text = "<Trade In>"
    '
    'Label24
    '
    Me.Label24.AutoSize = True
    Me.Label24.Location = New System.Drawing.Point(2, 119)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(47, 13)
    Me.Label24.TabIndex = 296
    Me.Label24.Text = "Trade In"
    '
    'Label23
    '
    Me.Label23.AutoSize = True
    Me.Label23.Location = New System.Drawing.Point(2, 106)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(57, 13)
    Me.Label23.TabIndex = 295
    Me.Label23.Text = "Wholesale"
    '
    'LblWholesale
    '
    Me.LblWholesale.AutoSize = True
    Me.LblWholesale.Location = New System.Drawing.Point(72, 106)
    Me.LblWholesale.Name = "LblWholesale"
    Me.LblWholesale.Size = New System.Drawing.Size(46, 13)
    Me.LblWholesale.TabIndex = 294
    Me.LblWholesale.Text = "<Retail>"
    '
    'LblRetail
    '
    Me.LblRetail.AutoSize = True
    Me.LblRetail.Location = New System.Drawing.Point(72, 93)
    Me.LblRetail.Name = "LblRetail"
    Me.LblRetail.Size = New System.Drawing.Size(46, 13)
    Me.LblRetail.TabIndex = 293
    Me.LblRetail.Text = "<Retail>"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(2, 93)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(34, 13)
    Me.Label7.TabIndex = 292
    Me.Label7.Text = "Retail"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(2, 80)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(55, 13)
    Me.Label6.TabIndex = 291
    Me.Label6.Text = "Class Max"
    '
    'LblClassMax
    '
    Me.LblClassMax.AutoSize = True
    Me.LblClassMax.Location = New System.Drawing.Point(72, 79)
    Me.LblClassMax.Name = "LblClassMax"
    Me.LblClassMax.Size = New System.Drawing.Size(67, 13)
    Me.LblClassMax.TabIndex = 290
    Me.LblClassMax.Text = "<Class Max>"
    '
    'LblClassMin
    '
    Me.LblClassMin.AutoSize = True
    Me.LblClassMin.Location = New System.Drawing.Point(72, 66)
    Me.LblClassMin.Name = "LblClassMin"
    Me.LblClassMin.Size = New System.Drawing.Size(64, 13)
    Me.LblClassMin.TabIndex = 289
    Me.LblClassMin.Text = "<Class Min>"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(2, 66)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(52, 13)
    Me.Label5.TabIndex = 288
    Me.Label5.Text = "Class Min"
    '
    'LblSubType
    '
    Me.LblSubType.AutoSize = True
    Me.LblSubType.Location = New System.Drawing.Point(72, 53)
    Me.LblSubType.Name = "LblSubType"
    Me.LblSubType.Size = New System.Drawing.Size(62, 13)
    Me.LblSubType.TabIndex = 287
    Me.LblSubType.Text = "<SubType>"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(2, 53)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(50, 13)
    Me.Label3.TabIndex = 286
    Me.Label3.Text = "SubType"
    '
    'LblClassification
    '
    Me.LblClassification.AutoSize = True
    Me.LblClassification.Location = New System.Drawing.Point(72, 40)
    Me.LblClassification.Name = "LblClassification"
    Me.LblClassification.Size = New System.Drawing.Size(80, 13)
    Me.LblClassification.TabIndex = 285
    Me.LblClassification.Text = "<Classification>"
    '
    'LblClassificationHdr
    '
    Me.LblClassificationHdr.AutoSize = True
    Me.LblClassificationHdr.Location = New System.Drawing.Point(2, 40)
    Me.LblClassificationHdr.Name = "LblClassificationHdr"
    Me.LblClassificationHdr.Size = New System.Drawing.Size(68, 13)
    Me.LblClassificationHdr.TabIndex = 284
    Me.LblClassificationHdr.Text = "Classification"
    '
    'LblCatName
    '
    Me.LblCatName.AutoSize = True
    Me.LblCatName.Location = New System.Drawing.Point(72, 27)
    Me.LblCatName.Name = "LblCatName"
    Me.LblCatName.Size = New System.Drawing.Size(61, 13)
    Me.LblCatName.TabIndex = 283
    Me.LblCatName.Text = "<Category>"
    '
    'LblCatNameHdr
    '
    Me.LblCatNameHdr.AutoSize = True
    Me.LblCatNameHdr.Location = New System.Drawing.Point(2, 27)
    Me.LblCatNameHdr.Name = "LblCatNameHdr"
    Me.LblCatNameHdr.Size = New System.Drawing.Size(52, 13)
    Me.LblCatNameHdr.TabIndex = 282
    Me.LblCatNameHdr.Text = "Category "
    '
    'LblMfgName
    '
    Me.LblMfgName.AutoSize = True
    Me.LblMfgName.Location = New System.Drawing.Point(72, 14)
    Me.LblMfgName.Name = "LblMfgName"
    Me.LblMfgName.Size = New System.Drawing.Size(68, 13)
    Me.LblMfgName.TabIndex = 281
    Me.LblMfgName.Text = "<Mfg Name>"
    '
    'LblMfgNameHdr
    '
    Me.LblMfgNameHdr.AutoSize = True
    Me.LblMfgNameHdr.Location = New System.Drawing.Point(2, 14)
    Me.LblMfgNameHdr.Name = "LblMfgNameHdr"
    Me.LblMfgNameHdr.Size = New System.Drawing.Size(64, 13)
    Me.LblMfgNameHdr.TabIndex = 280
    Me.LblMfgNameHdr.Text = "Manfacturer"
    '
    'FrmTA406B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(831, 454)
    Me.ControlBox = False
    Me.Controls.Add(Me.GrpPD)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.GrpMV)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtFindMake)
    Me.Controls.Add(Me.LnkClass)
    Me.Controls.Add(Me.TxtFindClass)
    Me.Controls.Add(Me.BtnRefresh)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmTA406B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpMV.ResumeLayout(False)
    Me.GrpMV.PerformLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpPD.ResumeLayout(False)
    Me.GrpPD.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region
  Dim myTXMCTL As TXMCTL.MyData
  Dim myTXMVD As TXMVD.MyData
  Dim myTXMSRP As TXMSRP.MyData
  Dim myTXMSRPCD As TXMSRPCD.MyData
  Dim myTXMSRPDEP As TXMSRPDEP.MyData
  Dim myTXCODE As TXCODE.MyData
  Dim myPriceDigestVIN As PriceDigestAPI.ApiVIN
  Dim myPriceDigestValue As PriceDigestAPI.ApiValue
  Dim myPriceDigestSpecs As PriceDigestAPI.ApiSpecs
  Dim ds As DataSet = New DataSet
  Private Sub FrmTA406B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXMCTL = New TXMCTL.MyData(myDBConnect)
    myTXMVD = New TXMVD.MyData(myDBConnect)
    myTXMSRP = New TXMSRP.MyData(myDBConnect)
    myTXMSRPCD = New TXMSRPCD.MyData(myDBConnect)
    myTXMSRPDEP = New TXMSRPDEP.MyData(myDBConnect)
    myTXCODE = New TXCODE.MyData(myDBConnect)
    myTXMCTL.GetOneRecordP(1)
    ds = BuildFile(False)

    If Not myTXMCTL.RecordNotFound Then
      With myTXMCTL
        MyBookPct = ._VALPER
        MyMinValue = ._VALMIN
      End With
    End If

    GrpMV.Visible = False
    GrpPD.Visible = False
    MyUtils.SetTxtReadOnly(TxtValue)
    MyFrmTA406.TBarSave.Enabled = False
  End Sub
  Private Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
    RefreshData()
  End Sub
  Public Sub FormatGrid()

    Call ShowGrid()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "List No"
      .Columns(0).Width = 50
      .Columns(1).HeaderText = "Owner Name"
      .Columns(1).Width = 250
      .Columns(2).HeaderText = "Class"
      .Columns(2).Width = 40
      .Columns(3).HeaderText = "Make"
      .Columns(3).Width = 60
      .Columns(4).HeaderText = "Year"
      .Columns(4).Width = 40
      .Columns(5).HeaderText = "VIN"
      .Columns(5).Width = 150
      .Columns(6).HeaderText = "Model"
      .Columns(6).Width = 80
      .Columns(7).Visible = False
      .Columns(8).Visible = False
      .Columns(9).Visible = False
      .Columns(10).Visible = False
    End With
  End Sub
  Public Sub ShowGrid()
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Private Sub FrmTA406C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA406.SbpScreen.Text = "TA406B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    GetMV(DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value)
    GrpPD.Visible = False
  End Sub
  Public Sub PrintData()
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds.Copy
    MyCrViewer.Show()
  End Sub
  Private Sub LnkClass_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkClass.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = "M"
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtFindClass.Text)
    MyFrmListCodes.Show()
    Me.Hide()
  End Sub

  Private Sub BtnFast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFast.Click
    ShowFastPath()
  End Sub
  Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFindListNo.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      ShowFastPath()
      Exit Sub
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub ShowFastPath()
    If TxtFindListNo.Text = "" Then Exit Sub

    GetMV(MyUtils.CnvSng(TxtFindListNo.Text))
  End Sub
  Public Sub RefreshData()
    Dim WrkListNo As Integer

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    ds = BuildFile(True)
    Call FormatGrid()
    If ds.Tables(0).Rows.Count > 0 Then
      WrkListNo = ds.Tables(0).Rows(0).Item("listno")
      GetMV(WrkListNo)
    End If
    MyFrmTA406.TBarPrint.Enabled = True
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Public Sub GetMV(ByVal WrkListNo As Integer)
    Dim K As Integer
    myTXMVD = New TXMVD.MyData(myDBConnect)
    myTXMVD.GetOneRecordP(WrkListNo)
    If myTXMVD.RecordNotFound Then Exit Sub

    MyFrmTA406.TBarSave.Enabled = True
    If s_chg = False And s_full = False Then    '#sec
      MyFrmTA406.TBarSave.Visible = False
    End If
    With myTXMVD
      TxtListNo.Text = WrkListNo
      TxtName.Text = Trim(._NAME)
      TxtMake.Text = Trim(._MAKE)
      TxtModel.Text = Trim(._MODEL)
      TxtBody.Text = Trim(._BODY)
      TxtYear.Text = ._YEAR
      TxtClass.Text = ._CLASS
      TxtVIN.Text = Trim(._VINNO)
      TxtRegno.Text = Trim(._REGNO)
      TxtNada.Text = Trim(._NADA)
      TxtGrossWeight.Text = ._GWT
      TxtLightWeight.Text = ._LWT
      TxtMSRP.Text = String.Empty
      ChkComplete.Checked = False
      ChkNonTax.Checked = False
      If ._MSRP > 0 Then
        TxtMSRP.Text = ._MSRP
      Else
        myTXMSRP.GetOneRecordP(._VINNO)
        With myTXMSRP
          If Not .RecordNotFound Then
            TxtMSRP.Text = ._OVMSRP
            TxtSource.Text = Trim(._OVSOURCE)
            If ._COMPLETE = "Y" Then
              ChkComplete.Checked = True
            End If
            If ._NONTAX = "Y" Then
              ChkNonTax.Checked = True
            End If
          End If
        End With
      End If
      If ._VALUE > 0 Then
        TxtValue.Text = ._VALUE
      Else
        TxtValue.Text = String.Empty
      End If
      K = LookupPrevMVD(._CLASS, ._YEAR, Trim(._MAKE), Trim(._MODEL))
      If K >= 0 Then
        TxtLastYrVal.Text = WrkOValue(K)
      Else
        TxtLastYrVal.Text = 0
      End If
    End With

    GrpMV.Visible = True
    MyUtils.SetTxtReadOnly(TxtListNo)
    MyUtils.SetTxtReadOnly(TxtName)
    MyUtils.SetTxtReadOnly(TxtVIN)
    MyUtils.SetTxtReadOnly(TxtRegno)
    MyUtils.SetTxtReadOnly(TxtNada)
    MyUtils.SetTxtReadOnly(TxtGrossWeight)
    MyUtils.SetTxtReadOnly(TxtLightWeight)
    MyUtils.SetTxtReadOnly(TxtValue)
    MyUtils.SetTxtReadOnly(TxtLastYrVal)
    TxtMSRP.Focus()
  End Sub
  Public Sub SaveData()
    Dim WrkRow As Integer
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    myTXMVD.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text))
    myTXMSRP.GetOneRecordP(myTXMVD._VINNO)
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myTXMVD.UpdateOneRecordP()
      With myTXMSRP
        If .RecordNotFound Then
          ._VINNO = Trim(myTXMVD._VINNO)
          .AddOneRecordP()
        Else
          .UpdateOneRecordP()
        End If
      End With
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
    WrkRow = DataGrdView.CurrentCell.RowIndex
    If WrkRow < DataGrdView.RowCount - 1 Then
      DataGrdView.CurrentCell = DataGrdView(0, WrkRow + 1)
      GetMV(DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value)
    Else
      GrpMV.Visible = False
    End If
    GrpPD.Visible = False
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtMSRP.Text) > 0 Then
      myTXMSRPCD.GetOneRecordP(TxtSource.Text)
      If myTXMSRPCD.RecordNotFound Then
        ErrorField(I) = "source"
        ErrorMsg(I) = "Source is invalid"
        I = I + 1
      End If
    End If

    myTXCODE.GetOneRecordP(MyUtils.CnvSng(TxtClass.Text), "M")
    If myTXCODE.RecordNotFound Then
      ErrorField(I) = "class"
      ErrorMsg(I) = "Class is invalid"
      I = I + 1
    End If
  End Sub
  Private Sub MovetoFile()
    With myTXMVD
      If ChkNonTax.Checked Then
        ._CAT = "2"
      End If
      ._MAKE = TxtMake.Text
      ._MODEL = TxtModel.Text
      ._BODY = TxtBody.Text
      ._YEAR = MyUtils.CnvSng(TxtYear.Text)
      ._CLASS = MyUtils.CnvSng(TxtClass.Text)
      ._VALUE = MyUtils.CnvSng(TxtValue.Text)
    End With
    With myTXMSRP
      ._OVMSRP = MyUtils.CnvSng(TxtMSRP.Text)
      ._OVSOURCE = TxtSource.Text
      If ChkComplete.Checked Then
        ._COMPLETE = "Y"
      Else
        ._COMPLETE = ""
      End If
      If ChkNonTax.Checked Then
        ._NONTAX = "Y"
      Else
        ._NONTAX = ""
      End If
    End With
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.Clear()
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "class"
          ErrProv.SetError(TxtClass, ErrorMsg(I))
        Case "source"
          ErrProv.SetError(TxtSource, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub TxtFindClass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFindClass.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtClass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClass.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Function CalcValue(ByVal WrkMSRP As Integer, ByVal WrkYear As Integer) As Integer
    Dim WrkDeYear As Integer
    Dim WrkValue As Integer
    Dim WrkDepr As Decimal
    'Calculate Assessment Value
    WrkValue = 0
    WrkDeYear = 2024 - WrkYear + 1
    If WrkDeYear < 1 Then
      WrkDeYear = 1
    End If
    WrkDepr = GetTXMSRPDEP(WrkDeYear)
    If WrkMSRP > 0 Then
      WrkValue = WrkMSRP * WrkDepr * MyBookPct
    End If
    WrkValue = MyUtils.Round10(WrkValue, "Normal")
    If WrkValue < MyMinValue Then
      WrkValue = MyMinValue
    End If
    Return WrkValue
  End Function
  Private Sub TxtFindMake_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFindMake.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      RefreshData()
    End If
  End Sub
  Public Function GetTXMSRPDEP(ByVal DeprYear As Integer) As Decimal
    Dim WrkDepr As Decimal
    If DeprYear < 0 Then DeprYear = 1
    WrkDepr = myTXMSRPDEP.GetDepr(DeprYear)
    Return WrkDepr
  End Function

  Private Sub TxtMSRP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMSRP.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      SaveData()
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtMSRP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMSRP.TextChanged
    Dim WrkMSRP As Integer
    Dim WrkYear As Integer
    Dim WrkValue As Integer
    WrkMSRP = MyUtils.CnvSng(TxtMSRP.Text)
    WrkYear = MyUtils.CnvSng(TxtYear.Text)
    WrkValue = CalcValue(WrkMSRP, WrkYear)
    TxtValue.Text = MyUtils.Round10(WrkValue, "Normal")
    With myTXCODE
      .GetOneRecordP(MyUtils.CnvSng(TxtClass.Text), "M")
      If ._MVINST = "M" Then
        TxtValue.Text = MyMinValue
      End If
    End With
  End Sub

  Private Sub LnkSource_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkSource.LinkClicked
    MyFrmListSource = New FrmListSource
    MyFrmListSource.MdiParent = Me.ParentForm
    MyFrmListSource.WrkCode = TxtSource.Text
    MyFrmListSource.Show()
  End Sub

  Private Sub BtnPriceDigest_Click(sender As Object, e As EventArgs) Handles BtnPriceDigest.Click
    myPriceDigestVIN = New PriceDigestAPI.ApiVIN
    myPriceDigestValue = New PriceDigestAPI.ApiValue
    myPriceDigestSpecs = New PriceDigestAPI.ApiSpecs
    GrpPD.Visible = True
    With myPriceDigestVIN
      .GetApiVIN(TxtVIN.Text)
      If MyUtils.CnvSng(TxtYear.Text) <> .modelYear Then 'If Vehicle year don't match it's an error
        .IsError = True
      End If
      If .IsError Then
        LblMfgName.Text = "** No Data **"
        LblCatName.Text = ""
        LblClassification.Text = ""
        LblSubType.Text = ""
        TxtMSRP.Text = ""
        TxtSource.Text = ""
        LblClassMin.Text = ""
        LblClassMax.Text = ""
        LblRetail.Text = ""
        LblWholesale.Text = ""
        LblTradeIn.Text = ""
        Exit Sub
      End If
      LblMfgName.Text = .manufacturerName
      LblCatName.Text = .categoryName
      LblClassification.Text = .classificationName
      LblSubType.Text = .subtypeName
    End With
    With myPriceDigestValue
      .GetApiValue(myPriceDigestVIN.configurationId)
      TxtMSRP.Text = .MSRP
      TxtSource.Text = "P"
      LblClassMin.Text = .sizeClassMin
      LblClassMax.Text = .sizeClassMax
      LblRetail.Text = .unadjustedRetail
      LblWholesale.Text = .unadjustedWholesale
      LblTradeIn.Text = .unadjustedTradeIn
    End With
    With myPriceDigestSpecs
      .GetApiSpecs(myPriceDigestVIN.configurationId)
      If Not ChkComplete.Checked And .Complete = "Y" Then
        ChkComplete.Checked = True
      End If
    End With
    TxtMSRP.Focus()
  End Sub

  Private Sub TxtSource_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSource.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      SaveData()
    End If
  End Sub
End Class
