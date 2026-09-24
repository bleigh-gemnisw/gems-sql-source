Public Class FrmTO301C
  Inherits System.Windows.Forms.Form
  Dim myTXVEH As TXVEH.MyData
  Dim myTXVEHL2 As TXVEHL2.MyData
  Dim myTXVCUS As TXVCUS.MyData
  Friend WrkVehID As Integer
  Friend WithEvents TxtRegNo As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtVehID As System.Windows.Forms.TextBox
  Friend WithEvents LblChgDate As System.Windows.Forms.Label
  Friend WithEvents GrpValues As System.Windows.Forms.GroupBox
  Friend WithEvents LblMSRP As System.Windows.Forms.Label
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents LblLnval As System.Windows.Forms.Label
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents LblTrval As System.Windows.Forms.Label
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents LblOrig As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents LblVinno As System.Windows.Forms.Label
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents LblSeat As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents LblVsclr As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents LblVpclr As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents LblCyaxl As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents LblClass As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents LblYear As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents LblBody As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents LblVModel As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents LblVMake As System.Windows.Forms.Label
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents GrpDom As System.Windows.Forms.GroupBox
  Friend WithEvents LblDzip As System.Windows.Forms.Label
  Friend WithEvents Label32 As System.Windows.Forms.Label
  Friend WithEvents LblDstate As System.Windows.Forms.Label
  Friend WithEvents Label36 As System.Windows.Forms.Label
  Friend WithEvents LblDcity As System.Windows.Forms.Label
  Friend WithEvents Label40 As System.Windows.Forms.Label
  Friend WithEvents LblDadd2 As System.Windows.Forms.Label
  Friend WithEvents Label44 As System.Windows.Forms.Label
  Friend WithEvents LblDadd1 As System.Windows.Forms.Label
  Friend WithEvents Label48 As System.Windows.Forms.Label
  Friend WithEvents LnkPCust As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtPCust As System.Windows.Forms.TextBox
  Friend WithEvents LblLcustid As System.Windows.Forms.Label
  Friend WithEvents Label50 As System.Windows.Forms.Label
  Friend WithEvents LblLzip As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents LblLstate As System.Windows.Forms.Label
  Friend WithEvents Label52 As System.Windows.Forms.Label
  Friend WithEvents LblLcity As System.Windows.Forms.Label
  Friend WithEvents Label56 As System.Windows.Forms.Label
  Friend WithEvents LblLadd2 As System.Windows.Forms.Label
  Friend WithEvents Label58 As System.Windows.Forms.Label
  Friend WithEvents LblLadd1 As System.Windows.Forms.Label
  Friend WithEvents Label60 As System.Windows.Forms.Label
  Friend WithEvents LblLbus As System.Windows.Forms.Label
  Friend WithEvents Label38 As System.Windows.Forms.Label
  Friend WithEvents LblLname As System.Windows.Forms.Label
  Friend WithEvents Label34 As System.Windows.Forms.Label
  Friend WithEvents LnkSCust As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtSCust As System.Windows.Forms.TextBox
  Friend WithEvents LblSCustName As System.Windows.Forms.Label
  Friend WithEvents LblPCustName As System.Windows.Forms.Label
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
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TxtRegNo = New System.Windows.Forms.TextBox()
    Me.TxtVehID = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.LblChgDate = New System.Windows.Forms.Label()
    Me.GrpValues = New System.Windows.Forms.GroupBox()
    Me.LblMSRP = New System.Windows.Forms.Label()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.LblLnval = New System.Windows.Forms.Label()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.LblTrval = New System.Windows.Forms.Label()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.LblOrig = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.LblVinno = New System.Windows.Forms.Label()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.LblSeat = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.LblVsclr = New System.Windows.Forms.Label()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.LblVpclr = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.LblCyaxl = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.LblClass = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.LblBody = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.LblVModel = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.LblVMake = New System.Windows.Forms.Label()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.GrpDom = New System.Windows.Forms.GroupBox()
    Me.LblDzip = New System.Windows.Forms.Label()
    Me.Label32 = New System.Windows.Forms.Label()
    Me.LblDstate = New System.Windows.Forms.Label()
    Me.Label36 = New System.Windows.Forms.Label()
    Me.LblDcity = New System.Windows.Forms.Label()
    Me.Label40 = New System.Windows.Forms.Label()
    Me.LblDadd2 = New System.Windows.Forms.Label()
    Me.Label44 = New System.Windows.Forms.Label()
    Me.LblDadd1 = New System.Windows.Forms.Label()
    Me.Label48 = New System.Windows.Forms.Label()
    Me.LnkPCust = New System.Windows.Forms.LinkLabel()
    Me.TxtPCust = New System.Windows.Forms.TextBox()
    Me.LblLcustid = New System.Windows.Forms.Label()
    Me.Label50 = New System.Windows.Forms.Label()
    Me.LblLzip = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LblLstate = New System.Windows.Forms.Label()
    Me.Label52 = New System.Windows.Forms.Label()
    Me.LblLcity = New System.Windows.Forms.Label()
    Me.Label56 = New System.Windows.Forms.Label()
    Me.LblLadd2 = New System.Windows.Forms.Label()
    Me.Label58 = New System.Windows.Forms.Label()
    Me.LblLadd1 = New System.Windows.Forms.Label()
    Me.Label60 = New System.Windows.Forms.Label()
    Me.LblLbus = New System.Windows.Forms.Label()
    Me.Label38 = New System.Windows.Forms.Label()
    Me.LblLname = New System.Windows.Forms.Label()
    Me.Label34 = New System.Windows.Forms.Label()
    Me.LnkSCust = New System.Windows.Forms.LinkLabel()
    Me.TxtSCust = New System.Windows.Forms.TextBox()
    Me.LblPCustName = New System.Windows.Forms.Label()
    Me.LblSCustName = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpValues.SuspendLayout()
    Me.GrpDom.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(9, 44)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(44, 13)
    Me.Label5.TabIndex = 9
    Me.Label5.Text = "Reg No"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtRegNo
    '
    Me.TxtRegNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRegNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRegNo.Location = New System.Drawing.Point(108, 41)
    Me.TxtRegNo.MaxLength = 8
    Me.TxtRegNo.Name = "TxtRegNo"
    Me.TxtRegNo.Size = New System.Drawing.Size(62, 20)
    Me.TxtRegNo.TabIndex = 1
    '
    'TxtVehID
    '
    Me.TxtVehID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVehID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVehID.Location = New System.Drawing.Point(108, 12)
    Me.TxtVehID.MaxLength = 9
    Me.TxtVehID.Name = "TxtVehID"
    Me.TxtVehID.Size = New System.Drawing.Size(73, 20)
    Me.TxtVehID.TabIndex = 0
    Me.TxtVehID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(9, 15)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(56, 13)
    Me.Label6.TabIndex = 415
    Me.Label6.Text = "Vehicle ID"
    '
    'LblChgDate
    '
    Me.LblChgDate.AutoSize = True
    Me.LblChgDate.Location = New System.Drawing.Point(359, 9)
    Me.LblChgDate.Name = "LblChgDate"
    Me.LblChgDate.Size = New System.Drawing.Size(64, 13)
    Me.LblChgDate.TabIndex = 419
    Me.LblChgDate.Text = "<Chg Date>"
    '
    'GrpValues
    '
    Me.GrpValues.Controls.Add(Me.LblMSRP)
    Me.GrpValues.Controls.Add(Me.Label23)
    Me.GrpValues.Controls.Add(Me.LblLnval)
    Me.GrpValues.Controls.Add(Me.Label21)
    Me.GrpValues.Controls.Add(Me.LblTrval)
    Me.GrpValues.Controls.Add(Me.Label19)
    Me.GrpValues.Controls.Add(Me.LblOrig)
    Me.GrpValues.Controls.Add(Me.Label16)
    Me.GrpValues.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpValues.Location = New System.Drawing.Point(15, 286)
    Me.GrpValues.Name = "GrpValues"
    Me.GrpValues.Size = New System.Drawing.Size(127, 83)
    Me.GrpValues.TabIndex = 444
    Me.GrpValues.TabStop = False
    Me.GrpValues.Text = "Values"
    '
    'LblMSRP
    '
    Me.LblMSRP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMSRP.Location = New System.Drawing.Point(63, 61)
    Me.LblMSRP.Name = "LblMSRP"
    Me.LblMSRP.Size = New System.Drawing.Size(53, 15)
    Me.LblMSRP.TabIndex = 108
    Me.LblMSRP.Text = "<MSRP>"
    Me.LblMSRP.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label23
    '
    Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label23.Location = New System.Drawing.Point(6, 61)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(51, 15)
    Me.Label23.TabIndex = 107
    Me.Label23.Text = "MSRP"
    '
    'LblLnval
    '
    Me.LblLnval.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLnval.Location = New System.Drawing.Point(63, 46)
    Me.LblLnval.Name = "LblLnval"
    Me.LblLnval.Size = New System.Drawing.Size(53, 15)
    Me.LblLnval.TabIndex = 106
    Me.LblLnval.Text = "<Lnval>"
    Me.LblLnval.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label21
    '
    Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label21.Location = New System.Drawing.Point(6, 46)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(51, 15)
    Me.Label21.TabIndex = 105
    Me.Label21.Text = "Loan"
    '
    'LblTrval
    '
    Me.LblTrval.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTrval.Location = New System.Drawing.Point(63, 31)
    Me.LblTrval.Name = "LblTrval"
    Me.LblTrval.Size = New System.Drawing.Size(53, 15)
    Me.LblTrval.TabIndex = 104
    Me.LblTrval.Text = "<Trval>"
    Me.LblTrval.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label19
    '
    Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label19.Location = New System.Drawing.Point(6, 31)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(51, 15)
    Me.Label19.TabIndex = 103
    Me.Label19.Text = "Trade In"
    '
    'LblOrig
    '
    Me.LblOrig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrig.Location = New System.Drawing.Point(63, 16)
    Me.LblOrig.Name = "LblOrig"
    Me.LblOrig.Size = New System.Drawing.Size(53, 15)
    Me.LblOrig.TabIndex = 102
    Me.LblOrig.Text = "<Orig>"
    Me.LblOrig.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label16
    '
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.Location = New System.Drawing.Point(6, 16)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(51, 15)
    Me.Label16.TabIndex = 101
    Me.Label16.Text = "Orig"
    '
    'LblVinno
    '
    Me.LblVinno.AutoSize = True
    Me.LblVinno.Location = New System.Drawing.Point(70, 196)
    Me.LblVinno.Name = "LblVinno"
    Me.LblVinno.Size = New System.Drawing.Size(46, 13)
    Me.LblVinno.TabIndex = 443
    Me.LblVinno.Text = "<Vinno>"
    '
    'Label17
    '
    Me.Label17.Location = New System.Drawing.Point(13, 196)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(51, 15)
    Me.Label17.TabIndex = 442
    Me.Label17.Text = "VIN"
    '
    'LblSeat
    '
    Me.LblSeat.Location = New System.Drawing.Point(70, 256)
    Me.LblSeat.Name = "LblSeat"
    Me.LblSeat.Size = New System.Drawing.Size(98, 15)
    Me.LblSeat.TabIndex = 439
    Me.LblSeat.Text = "<Seat>"
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(13, 256)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(51, 15)
    Me.Label13.TabIndex = 438
    Me.Label13.Text = "Seat"
    '
    'LblVsclr
    '
    Me.LblVsclr.Location = New System.Drawing.Point(70, 241)
    Me.LblVsclr.Name = "LblVsclr"
    Me.LblVsclr.Size = New System.Drawing.Size(98, 15)
    Me.LblVsclr.TabIndex = 437
    Me.LblVsclr.Text = "<Vsclr>"
    '
    'Label14
    '
    Me.Label14.Location = New System.Drawing.Point(13, 241)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(61, 15)
    Me.Label14.TabIndex = 436
    Me.Label14.Text = "Sec Color"
    '
    'LblVpclr
    '
    Me.LblVpclr.Location = New System.Drawing.Point(70, 226)
    Me.LblVpclr.Name = "LblVpclr"
    Me.LblVpclr.Size = New System.Drawing.Size(98, 15)
    Me.LblVpclr.TabIndex = 435
    Me.LblVpclr.Text = "<Vpclr>"
    '
    'Label12
    '
    Me.Label12.Location = New System.Drawing.Point(13, 226)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(51, 15)
    Me.Label12.TabIndex = 434
    Me.Label12.Text = "Pri Color"
    '
    'LblCyaxl
    '
    Me.LblCyaxl.Location = New System.Drawing.Point(70, 211)
    Me.LblCyaxl.Name = "LblCyaxl"
    Me.LblCyaxl.Size = New System.Drawing.Size(53, 15)
    Me.LblCyaxl.TabIndex = 433
    Me.LblCyaxl.Text = "<Cyaxl>"
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(13, 211)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(51, 15)
    Me.Label10.TabIndex = 432
    Me.Label10.Text = "Cyaxl"
    '
    'LblClass
    '
    Me.LblClass.Location = New System.Drawing.Point(69, 181)
    Me.LblClass.Name = "LblClass"
    Me.LblClass.Size = New System.Drawing.Size(158, 15)
    Me.LblClass.TabIndex = 431
    Me.LblClass.Text = "<Class>"
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(12, 181)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(51, 15)
    Me.Label8.TabIndex = 430
    Me.Label8.Text = "Class "
    '
    'LblYear
    '
    Me.LblYear.Location = New System.Drawing.Point(69, 166)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(43, 15)
    Me.LblYear.TabIndex = 429
    Me.LblYear.Text = "<Year>"
    '
    'Label11
    '
    Me.Label11.Location = New System.Drawing.Point(12, 166)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(51, 15)
    Me.Label11.TabIndex = 428
    Me.Label11.Text = "Year"
    '
    'LblBody
    '
    Me.LblBody.Location = New System.Drawing.Point(69, 151)
    Me.LblBody.Name = "LblBody"
    Me.LblBody.Size = New System.Drawing.Size(53, 15)
    Me.LblBody.TabIndex = 427
    Me.LblBody.Text = "<Body>"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(12, 151)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(51, 15)
    Me.Label2.TabIndex = 426
    Me.Label2.Text = "Body"
    '
    'LblVModel
    '
    Me.LblVModel.Location = New System.Drawing.Point(69, 136)
    Me.LblVModel.Name = "LblVModel"
    Me.LblVModel.Size = New System.Drawing.Size(117, 15)
    Me.LblVModel.TabIndex = 425
    Me.LblVModel.Text = "<VModel>"
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(12, 136)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(51, 15)
    Me.Label4.TabIndex = 424
    Me.Label4.Text = "Model"
    '
    'LblVMake
    '
    Me.LblVMake.Location = New System.Drawing.Point(69, 121)
    Me.LblVMake.Name = "LblVMake"
    Me.LblVMake.Size = New System.Drawing.Size(117, 15)
    Me.LblVMake.TabIndex = 423
    Me.LblVMake.Text = "<VMake>"
    '
    'Label18
    '
    Me.Label18.Location = New System.Drawing.Point(12, 121)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(51, 15)
    Me.Label18.TabIndex = 422
    Me.Label18.Text = "Make"
    '
    'GrpDom
    '
    Me.GrpDom.Controls.Add(Me.LblDzip)
    Me.GrpDom.Controls.Add(Me.Label32)
    Me.GrpDom.Controls.Add(Me.LblDstate)
    Me.GrpDom.Controls.Add(Me.Label36)
    Me.GrpDom.Controls.Add(Me.LblDcity)
    Me.GrpDom.Controls.Add(Me.Label40)
    Me.GrpDom.Controls.Add(Me.LblDadd2)
    Me.GrpDom.Controls.Add(Me.Label44)
    Me.GrpDom.Controls.Add(Me.LblDadd1)
    Me.GrpDom.Controls.Add(Me.Label48)
    Me.GrpDom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpDom.Location = New System.Drawing.Point(161, 286)
    Me.GrpDom.Name = "GrpDom"
    Me.GrpDom.Size = New System.Drawing.Size(262, 83)
    Me.GrpDom.TabIndex = 445
    Me.GrpDom.TabStop = False
    Me.GrpDom.Text = "Domiciled"
    '
    'LblDzip
    '
    Me.LblDzip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDzip.Location = New System.Drawing.Point(150, 62)
    Me.LblDzip.Name = "LblDzip"
    Me.LblDzip.Size = New System.Drawing.Size(89, 15)
    Me.LblDzip.TabIndex = 122
    Me.LblDzip.Text = "<Dzip>"
    '
    'Label32
    '
    Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label32.Location = New System.Drawing.Point(113, 60)
    Me.Label32.Name = "Label32"
    Me.Label32.Size = New System.Drawing.Size(31, 16)
    Me.Label32.TabIndex = 121
    Me.Label32.Text = "Zip"
    '
    'LblDstate
    '
    Me.LblDstate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDstate.Location = New System.Drawing.Point(63, 62)
    Me.LblDstate.Name = "LblDstate"
    Me.LblDstate.Size = New System.Drawing.Size(33, 15)
    Me.LblDstate.TabIndex = 120
    Me.LblDstate.Text = "<Dstate>"
    '
    'Label36
    '
    Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label36.Location = New System.Drawing.Point(6, 62)
    Me.Label36.Name = "Label36"
    Me.Label36.Size = New System.Drawing.Size(51, 15)
    Me.Label36.TabIndex = 119
    Me.Label36.Text = "State"
    '
    'LblDcity
    '
    Me.LblDcity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDcity.Location = New System.Drawing.Point(63, 47)
    Me.LblDcity.Name = "LblDcity"
    Me.LblDcity.Size = New System.Drawing.Size(191, 15)
    Me.LblDcity.TabIndex = 118
    Me.LblDcity.Text = "<Dcity>"
    '
    'Label40
    '
    Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label40.Location = New System.Drawing.Point(6, 47)
    Me.Label40.Name = "Label40"
    Me.Label40.Size = New System.Drawing.Size(51, 15)
    Me.Label40.TabIndex = 117
    Me.Label40.Text = "City"
    '
    'LblDadd2
    '
    Me.LblDadd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDadd2.Location = New System.Drawing.Point(63, 31)
    Me.LblDadd2.Name = "LblDadd2"
    Me.LblDadd2.Size = New System.Drawing.Size(191, 15)
    Me.LblDadd2.TabIndex = 116
    Me.LblDadd2.Text = "<Dadd2>"
    '
    'Label44
    '
    Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label44.Location = New System.Drawing.Point(6, 31)
    Me.Label44.Name = "Label44"
    Me.Label44.Size = New System.Drawing.Size(51, 15)
    Me.Label44.TabIndex = 115
    Me.Label44.Text = "Addr 2"
    '
    'LblDadd1
    '
    Me.LblDadd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDadd1.Location = New System.Drawing.Point(63, 16)
    Me.LblDadd1.Name = "LblDadd1"
    Me.LblDadd1.Size = New System.Drawing.Size(191, 15)
    Me.LblDadd1.TabIndex = 114
    Me.LblDadd1.Text = "<Dadd1>"
    '
    'Label48
    '
    Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label48.Location = New System.Drawing.Point(6, 16)
    Me.Label48.Name = "Label48"
    Me.Label48.Size = New System.Drawing.Size(51, 15)
    Me.Label48.TabIndex = 113
    Me.Label48.Text = "Addr 1"
    '
    'LnkPCust
    '
    Me.LnkPCust.AutoSize = True
    Me.LnkPCust.Location = New System.Drawing.Point(9, 71)
    Me.LnkPCust.Name = "LnkPCust"
    Me.LnkPCust.Size = New System.Drawing.Size(76, 13)
    Me.LnkPCust.TabIndex = 451
    Me.LnkPCust.TabStop = True
    Me.LnkPCust.Text = "Primary CustID"
    '
    'TxtPCust
    '
    Me.TxtPCust.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPCust.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPCust.Location = New System.Drawing.Point(108, 67)
    Me.TxtPCust.MaxLength = 9
    Me.TxtPCust.Name = "TxtPCust"
    Me.TxtPCust.Size = New System.Drawing.Size(76, 21)
    Me.TxtPCust.TabIndex = 450
    Me.TxtPCust.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblLcustid
    '
    Me.LblLcustid.AutoSize = True
    Me.LblLcustid.Location = New System.Drawing.Point(278, 123)
    Me.LblLcustid.Name = "LblLcustid"
    Me.LblLcustid.Size = New System.Drawing.Size(53, 13)
    Me.LblLcustid.TabIndex = 467
    Me.LblLcustid.Text = "<Lcustid>"
    '
    'Label50
    '
    Me.Label50.AutoSize = True
    Me.Label50.Location = New System.Drawing.Point(202, 123)
    Me.Label50.Name = "Label50"
    Me.Label50.Size = New System.Drawing.Size(76, 13)
    Me.Label50.TabIndex = 466
    Me.Label50.Text = "Lessee CustID"
    '
    'LblLzip
    '
    Me.LblLzip.AutoSize = True
    Me.LblLzip.Location = New System.Drawing.Point(367, 215)
    Me.LblLzip.Name = "LblLzip"
    Me.LblLzip.Size = New System.Drawing.Size(38, 13)
    Me.LblLzip.TabIndex = 465
    Me.LblLzip.Text = "<Lzip>"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(336, 215)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(22, 13)
    Me.Label1.TabIndex = 464
    Me.Label1.Text = "Zip"
    '
    'LblLstate
    '
    Me.LblLstate.AutoSize = True
    Me.LblLstate.Location = New System.Drawing.Point(280, 215)
    Me.LblLstate.Name = "LblLstate"
    Me.LblLstate.Size = New System.Drawing.Size(48, 13)
    Me.LblLstate.TabIndex = 463
    Me.LblLstate.Text = "<Lstate>"
    '
    'Label52
    '
    Me.Label52.AutoSize = True
    Me.Label52.Location = New System.Drawing.Point(202, 215)
    Me.Label52.Name = "Label52"
    Me.Label52.Size = New System.Drawing.Size(69, 13)
    Me.Label52.TabIndex = 462
    Me.Label52.Text = "Lessee State"
    '
    'LblLcity
    '
    Me.LblLcity.AutoSize = True
    Me.LblLcity.Location = New System.Drawing.Point(280, 197)
    Me.LblLcity.Name = "LblLcity"
    Me.LblLcity.Size = New System.Drawing.Size(41, 13)
    Me.LblLcity.TabIndex = 461
    Me.LblLcity.Text = "<Lcity>"
    '
    'Label56
    '
    Me.Label56.AutoSize = True
    Me.Label56.Location = New System.Drawing.Point(202, 200)
    Me.Label56.Name = "Label56"
    Me.Label56.Size = New System.Drawing.Size(61, 13)
    Me.Label56.TabIndex = 460
    Me.Label56.Text = "Lessee City"
    '
    'LblLadd2
    '
    Me.LblLadd2.AutoSize = True
    Me.LblLadd2.Location = New System.Drawing.Point(280, 182)
    Me.LblLadd2.Name = "LblLadd2"
    Me.LblLadd2.Size = New System.Drawing.Size(49, 13)
    Me.LblLadd2.TabIndex = 459
    Me.LblLadd2.Text = "<Ladd2>"
    '
    'Label58
    '
    Me.Label58.AutoSize = True
    Me.Label58.Location = New System.Drawing.Point(202, 184)
    Me.Label58.Name = "Label58"
    Me.Label58.Size = New System.Drawing.Size(72, 13)
    Me.Label58.TabIndex = 458
    Me.Label58.Text = "Lessee Add 2"
    '
    'LblLadd1
    '
    Me.LblLadd1.AutoSize = True
    Me.LblLadd1.Location = New System.Drawing.Point(280, 167)
    Me.LblLadd1.Name = "LblLadd1"
    Me.LblLadd1.Size = New System.Drawing.Size(49, 13)
    Me.LblLadd1.TabIndex = 457
    Me.LblLadd1.Text = "<Ladd1>"
    '
    'Label60
    '
    Me.Label60.AutoSize = True
    Me.Label60.Location = New System.Drawing.Point(202, 169)
    Me.Label60.Name = "Label60"
    Me.Label60.Size = New System.Drawing.Size(72, 13)
    Me.Label60.TabIndex = 456
    Me.Label60.Text = "Lessee Add 1"
    '
    'LblLbus
    '
    Me.LblLbus.Location = New System.Drawing.Point(278, 154)
    Me.LblLbus.Name = "LblLbus"
    Me.LblLbus.Size = New System.Drawing.Size(28, 16)
    Me.LblLbus.TabIndex = 455
    Me.LblLbus.Text = "<Lbus>"
    '
    'Label38
    '
    Me.Label38.AutoSize = True
    Me.Label38.Location = New System.Drawing.Point(202, 154)
    Me.Label38.Name = "Label38"
    Me.Label38.Size = New System.Drawing.Size(55, 13)
    Me.Label38.TabIndex = 454
    Me.Label38.Text = "Business?"
    '
    'LblLname
    '
    Me.LblLname.Location = New System.Drawing.Point(278, 139)
    Me.LblLname.Name = "LblLname"
    Me.LblLname.Size = New System.Drawing.Size(169, 15)
    Me.LblLname.TabIndex = 453
    Me.LblLname.Text = "<Lname>"
    '
    'Label34
    '
    Me.Label34.AutoSize = True
    Me.Label34.Location = New System.Drawing.Point(202, 139)
    Me.Label34.Name = "Label34"
    Me.Label34.Size = New System.Drawing.Size(72, 13)
    Me.Label34.TabIndex = 452
    Me.Label34.Text = "Lessee Name"
    '
    'LnkSCust
    '
    Me.LnkSCust.AutoSize = True
    Me.LnkSCust.Location = New System.Drawing.Point(12, 98)
    Me.LnkSCust.Name = "LnkSCust"
    Me.LnkSCust.Size = New System.Drawing.Size(93, 13)
    Me.LnkSCust.TabIndex = 469
    Me.LnkSCust.TabStop = True
    Me.LnkSCust.Text = "Secondary CustID"
    '
    'TxtSCust
    '
    Me.TxtSCust.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSCust.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSCust.Location = New System.Drawing.Point(108, 94)
    Me.TxtSCust.MaxLength = 9
    Me.TxtSCust.Name = "TxtSCust"
    Me.TxtSCust.Size = New System.Drawing.Size(76, 21)
    Me.TxtSCust.TabIndex = 468
    Me.TxtSCust.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblPCustName
    '
    Me.LblPCustName.AutoSize = True
    Me.LblPCustName.Location = New System.Drawing.Point(190, 71)
    Me.LblPCustName.Name = "LblPCustName"
    Me.LblPCustName.Size = New System.Drawing.Size(75, 13)
    Me.LblPCustName.TabIndex = 470
    Me.LblPCustName.Text = "<PCustName>"
    '
    'LblSCustName
    '
    Me.LblSCustName.AutoSize = True
    Me.LblSCustName.Location = New System.Drawing.Point(190, 98)
    Me.LblSCustName.Name = "LblSCustName"
    Me.LblSCustName.Size = New System.Drawing.Size(75, 13)
    Me.LblSCustName.TabIndex = 471
    Me.LblSCustName.Text = "<SCustName>"
    '
    'FrmTO301C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(455, 377)
    Me.Controls.Add(Me.LblSCustName)
    Me.Controls.Add(Me.LblPCustName)
    Me.Controls.Add(Me.LnkSCust)
    Me.Controls.Add(Me.TxtSCust)
    Me.Controls.Add(Me.LblLcustid)
    Me.Controls.Add(Me.Label50)
    Me.Controls.Add(Me.LblLzip)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LblLstate)
    Me.Controls.Add(Me.Label52)
    Me.Controls.Add(Me.LblLcity)
    Me.Controls.Add(Me.Label56)
    Me.Controls.Add(Me.LblLadd2)
    Me.Controls.Add(Me.Label58)
    Me.Controls.Add(Me.LblLadd1)
    Me.Controls.Add(Me.Label60)
    Me.Controls.Add(Me.LblLbus)
    Me.Controls.Add(Me.Label38)
    Me.Controls.Add(Me.LblLname)
    Me.Controls.Add(Me.Label34)
    Me.Controls.Add(Me.LnkPCust)
    Me.Controls.Add(Me.TxtPCust)
    Me.Controls.Add(Me.GrpDom)
    Me.Controls.Add(Me.GrpValues)
    Me.Controls.Add(Me.LblVinno)
    Me.Controls.Add(Me.Label17)
    Me.Controls.Add(Me.LblSeat)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.LblVsclr)
    Me.Controls.Add(Me.Label14)
    Me.Controls.Add(Me.LblVpclr)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.LblCyaxl)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.LblClass)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.LblBody)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.LblVModel)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.LblVMake)
    Me.Controls.Add(Me.Label18)
    Me.Controls.Add(Me.LblChgDate)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtVehID)
    Me.Controls.Add(Me.TxtRegNo)
    Me.Controls.Add(Me.Label5)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTO301C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Maintainence"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpValues.ResumeLayout(False)
    Me.GrpDom.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTO301C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXVEH = New TXVEH.MyData(myDBConnect)
    myTXVEHL2 = New TXVEHL2.MyData(myDBConnect)
    myTXVCUS = New TXVCUS.MyData(myDBConnect)

    MyFrmTO301.TBarNew.Enabled = False
    MyFrmTO301.TBarSave.Enabled = True
    myTXVEH.GetOneRecordP(WrkVehID)
    If myTXVEH.RecordNotFound Then
      LblChgDate.Text = String.Empty
      LblPCustName.Text = String.Empty
      LblSCustName.Text = String.Empty
      LblVMake.Text = String.Empty
      LblVModel.Text = String.Empty
      LblBody.Text = String.Empty
      LblYear.Text = String.Empty
      LblClass.Text = String.Empty
      LblVinno.Text = String.Empty
      LblCyaxl.Text = String.Empty
      LblVpclr.Text = String.Empty
      LblVsclr.Text = String.Empty
      LblSeat.Text = String.Empty
      LblOrig.Text = String.Empty
      LblTrval.Text = String.Empty
      LblLnval.Text = String.Empty
      LblMSRP.Text = String.Empty
      LblDadd1.Text = String.Empty
      LblDadd2.Text = String.Empty
      LblDcity.Text = String.Empty
      LblDstate.Text = String.Empty
      LblDzip.Text = String.Empty
      LblLcustid.Text = String.Empty
      LblLname.Text = String.Empty
      LblLbus.Text = String.Empty
      LblLadd1.Text = String.Empty
      LblLadd2.Text = String.Empty
      LblLcity.Text = String.Empty
      LblLstate.Text = String.Empty
      LblLzip.Text = String.Empty
      Exit Sub
    End If

    If WrkVehID > 0 Then
      MyFrmTO301.TBarDelete.Enabled = True
      MyUtils.SetTxtReadOnly(TxtVehID)
    End If
    If s_chg = False And s_full = False Then    '#sec
      MyFrmTO301.TBarSave.Visible = False
    End If
    With myTXVEH
      .GetOneRecordP(WrkVehID)
      TxtVehID.Text = ._VEHID
      TxtRegNo.Text = Trim(._REGNO)
      TxtPCust.Text = ._PCUST
      LblPCustName.Text = ""
      If ._PCUST > 0 Then
        myTXVCUS.GetOneRecordP(MyUtils.CnvSng(TxtPCust.Text))
        If Not myTXVCUS.RecordNotFound Then
          LblPCustName.Text = Trim(myTXVCUS._NAME)
        End If
      End If
      TxtSCust.Text = ._SCUST
      LblSCustName.Text = ""
      If ._SCUST > 0 Then
        myTXVCUS.GetOneRecordP(MyUtils.CnvSng(TxtSCust.Text))
        If Not myTXVCUS.RecordNotFound Then
          LblSCustName.Text = Trim(myTXVCUS._NAME)
        End If
      End If
      LblVMake.Text = ._VMAKE
      LblVModel.Text = ._VMODEL
      LblBody.Text = ._BODY
      LblYear.Text = ._YEAR
      LblClass.Text = ._CLASS & " - " & ._CLASSD
      LblVinno.Text = ._VINNO
      LblCyaxl.Text = ._CYLAX
      LblVpclr.Text = ._VPCLR
      LblVsclr.Text = ._VSCLR
      LblSeat.Text = ._SEAT
      'Values
      LblOrig.Text = ._ORIG
      LblTrval.Text = ._TRVAL
      LblLnval.Text = ._LNVAL
      LblMSRP.Text = ._MSRP
      'Domiciled
      LblDadd1.Text = ._DADD1
      LblDadd2.Text = ._DADD2
      LblDcity.Text = ._DCITY
      LblDstate.Text = ._DSTATE
      LblDzip.Text = ._DZIPA
      'Lessee
      LblLcustid.Text = ._LCUST
      LblLname.Text = ._LNAME
      LblLbus.Text = ._LBUS
      LblLadd1.Text = ._LADD1
      LblLadd2.Text = ._LADD2
      LblLcity.Text = ._LCITY
      LblLstate.Text = ._LSTATE
      LblLzip.Text = ._LZIPA
      If ._CHDATE > 0 Then
        LblChgDate.Text = MyUtils.GetDBDate(._CHDATE)
      Else
        LblChgDate.Text = "Manual Entry"
      End If
    End With
  End Sub
  Private Sub FrmTO301C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTO301.TBarNew.Enabled = True
    MyFrmTO301.TBarDelete.Enabled = False
    MyFrmTO301.TBarSave.Enabled = False
    MyFrmTO301.TBarSave.Visible = True   '#sec
    MyFrmTO301B.FormatGrid()
    MyFrmTO301B.Show()
    MyFrmTO301C = Nothing
  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    myTXVEH.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String

    myTXVEH.GetOneRecordP(MyUtils.CnvSng(TxtVehID.Text))
    If WrkVehID = 0 Then
      If Not myTXVEH.RecordNotFound Then
        Me.ErrProv.SetError(TxtVehID, "Record already exists")
        Exit Sub
      End If
    End If

    If WrkVehID > 0 Then
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXVEH.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXVEH._VEHID = MyUtils.CnvSng(TxtVehID.Text)
        myTXVEH.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()

  End Sub
  Private Sub MoveToFile()
    With myTXVEH
      ._REGNO = TxtRegNo.Text
      ._PCUST = MyUtils.CnvSng(TxtPCust.Text)
      ._SCUST = MyUtils.CnvSng(TxtSCust.Text)
    End With
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtVehID, "")
    ErrProv.SetError(TxtRegNo, "")
    ErrProv.SetError(TxtPCust, "")
    ErrProv.SetError(TxtSCust, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
        Case "vehid"
          ErrProv.SetError(TxtVehID, ErrorMsg(I))
        Case "regno"
          ErrProv.SetError(TxtRegNo, ErrorMsg(I))
        Case "pcust"
          ErrProv.SetError(TxtPCust, ErrorMsg(I))
        Case "scust"
          ErrProv.SetError(TxtSCust, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim ds2 As DataSet = New DataSet
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtVehID.Text) = 0 Then
      ErrorField(I) = "vehid"
      ErrorMsg(I) = "Vehicle ID is required"
      I = I + 1
    End If

    If TxtRegNo.Text = String.Empty Then
      ErrorField(I) = "regno"
      ErrorMsg(I) = "Reg No cannot be blank"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtPCust.Text) > 0 Then
      myTXVCUS.GetOneRecordP(MyUtils.CnvSng(TxtPCust.Text))
      If myTXVCUS.RecordNotFound Then
        ErrorField(I) = "pcust"
        ErrorMsg(I) = "Invalid Primary CustID"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtSCust.Text) > 0 Then
      myTXVCUS.GetOneRecordP(MyUtils.CnvSng(TxtSCust.Text))
      If myTXVCUS.RecordNotFound Then
        ErrorField(I) = "scust"
        ErrorMsg(I) = "Invalid Secondary CustID"
        I = I + 1
      End If
    End If

  End Sub
  Private Sub FrmTO301C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    MyFrmTO301.SbpScreen.Text = "TO301C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub TxtVehID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVehID.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtPCust_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPCust.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSCust_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSCust.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub LnkPCust_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkPCust.LinkClicked
    MyFrmListVCus = New FrmListVcus
    MyFrmListVCus.MdiParent = Me.ParentForm
    MyFrmListVCus.WrkField = "P"
    MyFrmListVCus.WrkName = LblPCustName.Text
    MyFrmListVCus.Show()
  End Sub
  Private Sub LnkSCust_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkSCust.LinkClicked
    MyFrmListVCus = New FrmListVcus
    MyFrmListVCus.MdiParent = Me.ParentForm
    MyFrmListVCus.WrkField = "S"
    MyFrmListVCus.WrkName = LblSCustName.Text
    MyFrmListVCus.Show()
  End Sub
End Class






