Public Class FrmUB102AS
  Inherits System.Windows.Forms.Form
	Dim myUTCUST As UTCUST.myData
	Dim myUTCUSTAS As UTCUSTAS.myData
	Dim myUTCUSTRT As UTCUSTRT.myData
  Dim myLOGUTAS As LOGUTAS.myData
  Dim dsLog As DataSet = New DataSet
  Dim LoadScrn As Boolean
  Dim StrDebug As String

  Friend WrkListNo As Integer
  Friend WrkFamily As String
  Friend WrkUBType As String
  Friend WrkDesc As String
  Friend WithEvents BtnPayoff As System.Windows.Forms.Button
  Dim AddMode As Boolean

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
Friend WithEvents TxtAcreage As System.Windows.Forms.TextBox
Friend WithEvents Label20 As System.Windows.Forms.Label
Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
Friend WithEvents LblBond As System.Windows.Forms.Label
Friend WithEvents Label69 As System.Windows.Forms.Label
Friend WithEvents LblPrincipal As System.Windows.Forms.Label
Friend WithEvents Label67 As System.Windows.Forms.Label
Friend WithEvents LblAssmntLeft As System.Windows.Forms.Label
Friend WithEvents LblOrigAssmnt As System.Windows.Forms.Label
Friend WithEvents Label64 As System.Windows.Forms.Label
Friend WithEvents Label65 As System.Windows.Forms.Label
Friend WithEvents TxtOverride As System.Windows.Forms.TextBox
Friend WithEvents Label60 As System.Windows.Forms.Label
Friend WithEvents TxtPrevBills As System.Windows.Forms.TextBox
Friend WithEvents Label59 As System.Windows.Forms.Label
Friend WithEvents TxtPrevBilled As System.Windows.Forms.TextBox
Friend WithEvents Label58 As System.Windows.Forms.Label
Friend WithEvents TxtAssmntAdj As System.Windows.Forms.TextBox
Friend WithEvents Label57 As System.Windows.Forms.Label
Friend WithEvents TxtDeferAmt As System.Windows.Forms.TextBox
Friend WithEvents Label54 As System.Windows.Forms.Label
Friend WithEvents TxtDeferPct As System.Windows.Forms.TextBox
Friend WithEvents Label55 As System.Windows.Forms.Label
Friend WithEvents TxtPropValue As System.Windows.Forms.TextBox
Friend WithEvents Label52 As System.Windows.Forms.Label
Friend WithEvents TxtFootage As System.Windows.Forms.TextBox
Friend WithEvents Label47 As System.Windows.Forms.Label
Friend WithEvents TxtDwellUnits As System.Windows.Forms.TextBox
Friend WithEvents Label46 As System.Windows.Forms.Label
Friend WithEvents TxtAPermitNo As System.Windows.Forms.TextBox
Friend WithEvents Label50 As System.Windows.Forms.Label
Friend WithEvents TxtCode As System.Windows.Forms.TextBox
Friend WithEvents LblName As System.Windows.Forms.Label
Friend WithEvents LblListNo As System.Windows.Forms.Label
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents LblBillAmt As System.Windows.Forms.Label
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents LnkCode As System.Windows.Forms.LinkLabel
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TxtLateralFee As System.Windows.Forms.TextBox
Friend WithEvents TxtUniformFee As System.Windows.Forms.TextBox
Friend WithEvents LblDesc As System.Windows.Forms.Label
Friend WithEvents BtnAmort As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.TxtAcreage = New System.Windows.Forms.TextBox
Me.Label20 = New System.Windows.Forms.Label
Me.GroupBox4 = New System.Windows.Forms.GroupBox
Me.LblBillAmt = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.LblBond = New System.Windows.Forms.Label
Me.Label69 = New System.Windows.Forms.Label
Me.LblPrincipal = New System.Windows.Forms.Label
Me.Label67 = New System.Windows.Forms.Label
Me.LblAssmntLeft = New System.Windows.Forms.Label
Me.LblOrigAssmnt = New System.Windows.Forms.Label
Me.Label64 = New System.Windows.Forms.Label
Me.Label65 = New System.Windows.Forms.Label
Me.TxtOverride = New System.Windows.Forms.TextBox
Me.Label60 = New System.Windows.Forms.Label
Me.TxtPrevBills = New System.Windows.Forms.TextBox
Me.Label59 = New System.Windows.Forms.Label
Me.TxtPrevBilled = New System.Windows.Forms.TextBox
Me.Label58 = New System.Windows.Forms.Label
Me.TxtAssmntAdj = New System.Windows.Forms.TextBox
Me.Label57 = New System.Windows.Forms.Label
Me.TxtDeferAmt = New System.Windows.Forms.TextBox
Me.Label54 = New System.Windows.Forms.Label
Me.TxtDeferPct = New System.Windows.Forms.TextBox
Me.Label55 = New System.Windows.Forms.Label
Me.TxtPropValue = New System.Windows.Forms.TextBox
Me.Label52 = New System.Windows.Forms.Label
Me.TxtFootage = New System.Windows.Forms.TextBox
Me.Label47 = New System.Windows.Forms.Label
Me.TxtDwellUnits = New System.Windows.Forms.TextBox
Me.Label46 = New System.Windows.Forms.Label
Me.TxtAPermitNo = New System.Windows.Forms.TextBox
Me.Label50 = New System.Windows.Forms.Label
Me.LnkCode = New System.Windows.Forms.LinkLabel
Me.TxtCode = New System.Windows.Forms.TextBox
Me.LblName = New System.Windows.Forms.Label
Me.LblListNo = New System.Windows.Forms.Label
Me.Label1 = New System.Windows.Forms.Label
Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtLateralFee = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.TxtUniformFee = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.LblDesc = New System.Windows.Forms.Label
Me.BtnAmort = New System.Windows.Forms.Button
Me.BtnPayoff = New System.Windows.Forms.Button
Me.GroupBox4.SuspendLayout()
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'TxtAcreage
'
Me.TxtAcreage.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtAcreage.Location = New System.Drawing.Point(240, 56)
Me.TxtAcreage.MaxLength = 8
Me.TxtAcreage.Name = "TxtAcreage"
Me.TxtAcreage.Size = New System.Drawing.Size(72, 22)
Me.TxtAcreage.TabIndex = 3
Me.TxtAcreage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label20
'
Me.Label20.Location = New System.Drawing.Point(184, 60)
Me.Label20.Name = "Label20"
Me.Label20.Size = New System.Drawing.Size(48, 16)
Me.Label20.TabIndex = 317
Me.Label20.Text = "Acreage"
'
'GroupBox4
'
Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
Me.GroupBox4.Controls.Add(Me.LblBillAmt)
Me.GroupBox4.Controls.Add(Me.Label3)
Me.GroupBox4.Controls.Add(Me.LblBond)
Me.GroupBox4.Controls.Add(Me.Label69)
Me.GroupBox4.Controls.Add(Me.LblPrincipal)
Me.GroupBox4.Controls.Add(Me.Label67)
Me.GroupBox4.Controls.Add(Me.LblAssmntLeft)
Me.GroupBox4.Controls.Add(Me.LblOrigAssmnt)
Me.GroupBox4.Controls.Add(Me.Label64)
Me.GroupBox4.Controls.Add(Me.Label65)
Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.GroupBox4.ForeColor = System.Drawing.Color.Black
Me.GroupBox4.Location = New System.Drawing.Point(480, 8)
Me.GroupBox4.Name = "GroupBox4"
Me.GroupBox4.Size = New System.Drawing.Size(200, 168)
Me.GroupBox4.TabIndex = 316
Me.GroupBox4.TabStop = False
Me.GroupBox4.Text = "Bill Calcs (Amortization Table)"
'
'LblBillAmt
'
Me.LblBillAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblBillAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblBillAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblBillAmt.Location = New System.Drawing.Point(96, 144)
Me.LblBillAmt.Name = "LblBillAmt"
Me.LblBillAmt.Size = New System.Drawing.Size(88, 16)
Me.LblBillAmt.TabIndex = 29
Me.LblBillAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label3
'
Me.Label3.BackColor = System.Drawing.SystemColors.Control
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(8, 144)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(88, 16)
Me.Label3.TabIndex = 28
Me.Label3.Text = "Bill Amt"
'
'LblBond
'
Me.LblBond.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblBond.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblBond.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblBond.Location = New System.Drawing.Point(96, 120)
Me.LblBond.Name = "LblBond"
Me.LblBond.Size = New System.Drawing.Size(88, 16)
Me.LblBond.TabIndex = 27
Me.LblBond.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label69
'
Me.Label69.BackColor = System.Drawing.SystemColors.Control
Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label69.Location = New System.Drawing.Point(8, 120)
Me.Label69.Name = "Label69"
Me.Label69.Size = New System.Drawing.Size(88, 16)
Me.Label69.TabIndex = 26
Me.Label69.Text = "Bond Int. Amt"
'
'LblPrincipal
'
Me.LblPrincipal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblPrincipal.Location = New System.Drawing.Point(96, 96)
Me.LblPrincipal.Name = "LblPrincipal"
Me.LblPrincipal.Size = New System.Drawing.Size(88, 16)
Me.LblPrincipal.TabIndex = 25
Me.LblPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label67
'
Me.Label67.BackColor = System.Drawing.SystemColors.Control
Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label67.Location = New System.Drawing.Point(8, 96)
Me.Label67.Name = "Label67"
Me.Label67.Size = New System.Drawing.Size(88, 16)
Me.Label67.TabIndex = 24
Me.Label67.Text = "Principal Amt"
'
'LblAssmntLeft
'
Me.LblAssmntLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblAssmntLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblAssmntLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblAssmntLeft.Location = New System.Drawing.Point(96, 56)
Me.LblAssmntLeft.Name = "LblAssmntLeft"
Me.LblAssmntLeft.Size = New System.Drawing.Size(88, 16)
Me.LblAssmntLeft.TabIndex = 23
Me.LblAssmntLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'LblOrigAssmnt
'
Me.LblOrigAssmnt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblOrigAssmnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblOrigAssmnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblOrigAssmnt.Location = New System.Drawing.Point(96, 32)
Me.LblOrigAssmnt.Name = "LblOrigAssmnt"
Me.LblOrigAssmnt.Size = New System.Drawing.Size(88, 16)
Me.LblOrigAssmnt.TabIndex = 22
Me.LblOrigAssmnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label64
'
Me.Label64.BackColor = System.Drawing.SystemColors.Control
Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label64.Location = New System.Drawing.Point(8, 56)
Me.Label64.Name = "Label64"
Me.Label64.Size = New System.Drawing.Size(88, 16)
Me.Label64.TabIndex = 3
Me.Label64.Text = "Assessment Left"
'
'Label65
'
Me.Label65.BackColor = System.Drawing.SystemColors.Control
Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label65.Location = New System.Drawing.Point(8, 32)
Me.Label65.Name = "Label65"
Me.Label65.Size = New System.Drawing.Size(88, 16)
Me.Label65.TabIndex = 0
Me.Label65.Text = "Orig Asmnt Amt"
'
'TxtOverride
'
Me.TxtOverride.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtOverride.Location = New System.Drawing.Point(104, 288)
Me.TxtOverride.MaxLength = 8
Me.TxtOverride.Name = "TxtOverride"
Me.TxtOverride.Size = New System.Drawing.Size(72, 22)
Me.TxtOverride.TabIndex = 13
Me.TxtOverride.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label60
'
Me.Label60.Location = New System.Drawing.Point(4, 296)
Me.Label60.Name = "Label60"
Me.Label60.Size = New System.Drawing.Size(96, 16)
Me.Label60.TabIndex = 315
Me.Label60.Text = "Override Amount"
'
'TxtPrevBills
'
Me.TxtPrevBills.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtPrevBills.Location = New System.Drawing.Point(104, 264)
Me.TxtPrevBills.MaxLength = 3
Me.TxtPrevBills.Name = "TxtPrevBills"
Me.TxtPrevBills.Size = New System.Drawing.Size(32, 22)
Me.TxtPrevBills.TabIndex = 12
Me.TxtPrevBills.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label59
'
Me.Label59.Location = New System.Drawing.Point(4, 272)
Me.Label59.Name = "Label59"
Me.Label59.Size = New System.Drawing.Size(96, 16)
Me.Label59.TabIndex = 314
Me.Label59.Text = "Prev # of Bills"
'
'TxtPrevBilled
'
Me.TxtPrevBilled.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtPrevBilled.Location = New System.Drawing.Point(104, 240)
Me.TxtPrevBilled.MaxLength = 10
Me.TxtPrevBilled.Name = "TxtPrevBilled"
Me.TxtPrevBilled.Size = New System.Drawing.Size(88, 22)
Me.TxtPrevBilled.TabIndex = 11
Me.TxtPrevBilled.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label58
'
Me.Label58.Location = New System.Drawing.Point(4, 248)
Me.Label58.Name = "Label58"
Me.Label58.Size = New System.Drawing.Size(96, 16)
Me.Label58.TabIndex = 313
Me.Label58.Text = "Prev Billed Amt"
'
'TxtAssmntAdj
'
Me.TxtAssmntAdj.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtAssmntAdj.Location = New System.Drawing.Point(104, 216)
Me.TxtAssmntAdj.MaxLength = 10
Me.TxtAssmntAdj.Name = "TxtAssmntAdj"
Me.TxtAssmntAdj.Size = New System.Drawing.Size(88, 22)
Me.TxtAssmntAdj.TabIndex = 10
Me.TxtAssmntAdj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label57
'
Me.Label57.Location = New System.Drawing.Point(4, 224)
Me.Label57.Name = "Label57"
Me.Label57.Size = New System.Drawing.Size(96, 16)
Me.Label57.TabIndex = 312
Me.Label57.Text = "Asmnt Adjustment"
'
'TxtDeferAmt
'
Me.TxtDeferAmt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDeferAmt.Location = New System.Drawing.Point(104, 192)
Me.TxtDeferAmt.MaxLength = 10
Me.TxtDeferAmt.Name = "TxtDeferAmt"
Me.TxtDeferAmt.Size = New System.Drawing.Size(88, 22)
Me.TxtDeferAmt.TabIndex = 9
Me.TxtDeferAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label54
'
Me.Label54.Location = New System.Drawing.Point(4, 200)
Me.Label54.Name = "Label54"
Me.Label54.Size = New System.Drawing.Size(96, 16)
Me.Label54.TabIndex = 310
Me.Label54.Text = "Deferred Amount"
'
'TxtDeferPct
'
Me.TxtDeferPct.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDeferPct.Location = New System.Drawing.Point(104, 168)
Me.TxtDeferPct.MaxLength = 3
Me.TxtDeferPct.Name = "TxtDeferPct"
Me.TxtDeferPct.Size = New System.Drawing.Size(32, 22)
Me.TxtDeferPct.TabIndex = 8
Me.TxtDeferPct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label55
'
Me.Label55.Location = New System.Drawing.Point(4, 176)
Me.Label55.Name = "Label55"
Me.Label55.Size = New System.Drawing.Size(64, 16)
Me.Label55.TabIndex = 309
Me.Label55.Text = "Deferred %"
'
'TxtPropValue
'
Me.TxtPropValue.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtPropValue.Location = New System.Drawing.Point(88, 56)
Me.TxtPropValue.MaxLength = 9
Me.TxtPropValue.Name = "TxtPropValue"
Me.TxtPropValue.Size = New System.Drawing.Size(80, 22)
Me.TxtPropValue.TabIndex = 2
Me.TxtPropValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label52
'
Me.Label52.Location = New System.Drawing.Point(4, 60)
Me.Label52.Name = "Label52"
Me.Label52.Size = New System.Drawing.Size(64, 16)
Me.Label52.TabIndex = 308
Me.Label52.Text = "Prop Value"
'
'TxtFootage
'
Me.TxtFootage.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFootage.Location = New System.Drawing.Point(240, 32)
Me.TxtFootage.MaxLength = 8
Me.TxtFootage.Name = "TxtFootage"
Me.TxtFootage.Size = New System.Drawing.Size(72, 22)
Me.TxtFootage.TabIndex = 1
Me.TxtFootage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label47
'
Me.Label47.Location = New System.Drawing.Point(184, 36)
Me.Label47.Name = "Label47"
Me.Label47.Size = New System.Drawing.Size(48, 16)
Me.Label47.TabIndex = 307
Me.Label47.Text = "Footage"
'
'TxtDwellUnits
'
Me.TxtDwellUnits.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDwellUnits.Location = New System.Drawing.Point(88, 32)
Me.TxtDwellUnits.MaxLength = 6
Me.TxtDwellUnits.Name = "TxtDwellUnits"
Me.TxtDwellUnits.Size = New System.Drawing.Size(56, 22)
Me.TxtDwellUnits.TabIndex = 0
Me.TxtDwellUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label46
'
Me.Label46.Location = New System.Drawing.Point(4, 36)
Me.Label46.Name = "Label46"
Me.Label46.Size = New System.Drawing.Size(80, 16)
Me.Label46.TabIndex = 306
Me.Label46.Text = "Dwelling Units"
'
'TxtAPermitNo
'
Me.TxtAPermitNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtAPermitNo.Location = New System.Drawing.Point(376, 56)
Me.TxtAPermitNo.MaxLength = 10
Me.TxtAPermitNo.Name = "TxtAPermitNo"
Me.TxtAPermitNo.Size = New System.Drawing.Size(88, 22)
Me.TxtAPermitNo.TabIndex = 4
'
'Label50
'
Me.Label50.Location = New System.Drawing.Point(324, 60)
Me.Label50.Name = "Label50"
Me.Label50.Size = New System.Drawing.Size(48, 16)
Me.Label50.TabIndex = 305
Me.Label50.Text = "Permit #"
'
'LnkCode
'
Me.LnkCode.Location = New System.Drawing.Point(4, 120)
Me.LnkCode.Name = "LnkCode"
Me.LnkCode.Size = New System.Drawing.Size(72, 16)
Me.LnkCode.TabIndex = 304
Me.LnkCode.TabStop = True
Me.LnkCode.Text = "Assmnt Code"
'
'TxtCode
'
Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtCode.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtCode.Location = New System.Drawing.Point(104, 112)
Me.TxtCode.MaxLength = 3
Me.TxtCode.Name = "TxtCode"
Me.TxtCode.Size = New System.Drawing.Size(32, 22)
Me.TxtCode.TabIndex = 5
'
'LblName
'
Me.LblName.Location = New System.Drawing.Point(128, 8)
Me.LblName.Name = "LblName"
Me.LblName.Size = New System.Drawing.Size(280, 16)
Me.LblName.TabIndex = 322
Me.LblName.UseMnemonic = False
'
'LblListNo
'
Me.LblListNo.Location = New System.Drawing.Point(72, 8)
Me.LblListNo.Name = "LblListNo"
Me.LblListNo.Size = New System.Drawing.Size(48, 16)
Me.LblListNo.TabIndex = 321
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 8)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(56, 16)
Me.Label1.TabIndex = 320
Me.Label1.Text = "Account #"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'TxtLateralFee
'
Me.TxtLateralFee.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtLateralFee.Location = New System.Drawing.Point(104, 136)
Me.TxtLateralFee.MaxLength = 5
Me.TxtLateralFee.Name = "TxtLateralFee"
Me.TxtLateralFee.Size = New System.Drawing.Size(48, 22)
Me.TxtLateralFee.TabIndex = 6
Me.TxtLateralFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(4, 144)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(64, 16)
Me.Label2.TabIndex = 324
Me.Label2.Text = "Lateral Fee"
'
'TxtUniformFee
'
Me.TxtUniformFee.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtUniformFee.Location = New System.Drawing.Point(272, 136)
Me.TxtUniformFee.MaxLength = 5
Me.TxtUniformFee.Name = "TxtUniformFee"
Me.TxtUniformFee.Size = New System.Drawing.Size(48, 22)
Me.TxtUniformFee.TabIndex = 7
Me.TxtUniformFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(176, 140)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(96, 16)
Me.Label4.TabIndex = 326
Me.Label4.Text = "Uniform Min. Fee"
'
'LblDesc
'
Me.LblDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblDesc.Location = New System.Drawing.Point(4, 96)
Me.LblDesc.Name = "LblDesc"
Me.LblDesc.Size = New System.Drawing.Size(160, 16)
Me.LblDesc.TabIndex = 327
'
'BtnAmort
'
Me.BtnAmort.Location = New System.Drawing.Point(600, 272)
Me.BtnAmort.Name = "BtnAmort"
Me.BtnAmort.Size = New System.Drawing.Size(80, 40)
Me.BtnAmort.TabIndex = 328
Me.BtnAmort.TabStop = False
Me.BtnAmort.Text = "Amortization"
'
'BtnPayoff
'
Me.BtnPayoff.Location = New System.Drawing.Point(514, 272)
Me.BtnPayoff.Name = "BtnPayoff"
Me.BtnPayoff.Size = New System.Drawing.Size(80, 40)
Me.BtnPayoff.TabIndex = 329
Me.BtnPayoff.TabStop = False
Me.BtnPayoff.Text = "Payoff"
'
'FrmUB102AS
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(688, 319)
Me.Controls.Add(Me.BtnPayoff)
Me.Controls.Add(Me.BtnAmort)
Me.Controls.Add(Me.LblDesc)
Me.Controls.Add(Me.TxtUniformFee)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.TxtLateralFee)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.LblName)
Me.Controls.Add(Me.LblListNo)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtAcreage)
Me.Controls.Add(Me.TxtOverride)
Me.Controls.Add(Me.TxtPrevBills)
Me.Controls.Add(Me.TxtPrevBilled)
Me.Controls.Add(Me.TxtAssmntAdj)
Me.Controls.Add(Me.TxtDeferAmt)
Me.Controls.Add(Me.TxtDeferPct)
Me.Controls.Add(Me.TxtPropValue)
Me.Controls.Add(Me.TxtFootage)
Me.Controls.Add(Me.TxtDwellUnits)
Me.Controls.Add(Me.TxtAPermitNo)
Me.Controls.Add(Me.TxtCode)
Me.Controls.Add(Me.Label20)
Me.Controls.Add(Me.GroupBox4)
Me.Controls.Add(Me.Label60)
Me.Controls.Add(Me.Label59)
Me.Controls.Add(Me.Label58)
Me.Controls.Add(Me.Label57)
Me.Controls.Add(Me.Label54)
Me.Controls.Add(Me.Label55)
Me.Controls.Add(Me.Label52)
Me.Controls.Add(Me.Label47)
Me.Controls.Add(Me.Label46)
Me.Controls.Add(Me.Label50)
Me.Controls.Add(Me.LnkCode)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmUB102AS"
Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
Me.Text = "Maintain Customer - Assessment Data"
Me.GroupBox4.ResumeLayout(False)
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmUB102AS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myUTCUST = New UTCUST.myData(myDBConnect)
	myUTCUSTAS = New UTCUSTAS.myData(myDBConnect)
	myUTCUSTRT = New UTCUSTRT.myData(myDBConnect)
  myLOGUTAS = New LOGUTAS.myData(myDBConnect)

  LoadScrn = True
  MyFrmUB102.TBarDelete.Enabled = False
  MyFrmUB102.TBarSave.Enabled = True

  LblListNo.Text = WrkListNo
  LblName.Text = MyFrmUB102C.TxtName.Text
  LblDesc.Text = WrkDesc

  'New record
  If s_chg = False And s_full = False Then  '#sec
    MyFrmUB102.TBarSave.Visible = False  '#sec
  End If  '#sec

  'change log
  MyFrmUB102.TBarLog.Enabled = False
  dsLog = myLOGUTAS.GetAllList(WrkListNo, WrkUBType)
  If dsLog.Tables(0).Rows.Count > 0 Then
    MyFrmUB102.TBarLog.Enabled = True
  End If

  myUTCUST.GetOneRecordP(WrkListNo)
	With myUTCUST
		TxtDwellUnits.Text = ._CUAUNT
		TxtFootage.Text = ._CUFOOT
		TxtPropValue.Text = ._CUPVAL
		TxtAcreage.Text = ._CUACRE
		TxtAPermitNo.Text = ._CUAPMT
	End With

	TxtCode.Text = GetRateCode(WrkListNo, WrkUBType)
  AddMode = False
  If TxtCode.Text = "" Then
    AddMode = True
  End If
  GetAssmntData()

  SetAssmntCodeTip()
  CalcAssmnt()

  LoadScrn = False
  End Sub
  Private Sub CalcAssmnt()
    Dim MyUBCalcBill As UBCalcBill.BillAssessment
    Dim MyUBCalcBill2 As UBCalcBill.Amort

    MyUBCalcBill = New UBCalcBill.BillAssessment(myDBConnect)
    MyUBCalcBill2 = New UBCalcBill.Amort(myDBConnect)
    With MyUBCalcBill
      .In_RateType = WrkUBType
      .In_RateCode = TxtCode.Text
      .In_DwellUnits = MyUtils.CnvSng(TxtDwellUnits.Text)
      .In_PropVal = MyUtils.CnvSng(TxtPropValue.Text)
      .In_Footage = MyUtils.CnvSng(TxtFootage.Text)
      .In_Acreage = MyUtils.CnvSng(TxtAcreage.Text)
      .In_LateralFee = MyUtils.CnvSng(TxtLateralFee.Text)
      .In_UniformFee = MyUtils.CnvSng(TxtUniformFee.Text)
      .In_AssmntAdjust = MyUtils.CnvSng(TxtAssmntAdj.Text)
      .In_DeferredAmt = MyUtils.CnvSng(TxtDeferAmt.Text)
      .In_PrevBilled = MyUtils.CnvSng(TxtPrevBilled.Text)
      .CalcAssessment()
      LblOrigAssmnt.Text = MyUtils.FmtCurrency(.Out_OrigBill)
      LblAssmntLeft.Text = MyUtils.FmtCurrency(.Out_AmtLeft)
      StrDebug = .Out_Debug
    End With

    With MyUBCalcBill2
      .In_OrigBill = MyUBCalcBill.Out_OrigBill
      .In_AmtLeft = MyUBCalcBill.Out_AmtLeft
      .In_Balance = 0
      .In_RateType = WrkUBType
      .In_RateCode = TxtCode.Text
      .In_NumBills = MyUtils.CnvSng(TxtPrevBills.Text)
      .In_OverrideBill = MyUtils.CnvSng(TxtOverride.Text)
      .In_PctDeferred = MyUtils.CnvSng(TxtDeferPct.Text)
      .CalcAmort()
      LblPrincipal.Text = MyUtils.FmtCurrency(.Out_Bill)
      LblBond.Text = MyUtils.FmtCurrency(.Out_Bond)
      LblBillAmt.Text = MyUtils.FmtCurrency(.Out_Bill + .Out_Bond)
      StrDebug = StrDebug & vbCrLf & .Out_Debug
    End With

  End Sub
Public Sub GetAssmntData()
  myUTCUSTAS.GetOneRecordP(WrkListNo, WrkUBType)
  If Not myUTCUSTAS.RecordNotFound Then
    With myUTCUSTAS
      TxtLateralFee.Text = ._CALAT
      TxtUniformFee.Text = ._CAUNIF
      TxtDeferPct.Text = ._CADEP
      TxtDeferAmt.Text = ._CADEF
      TxtAssmntAdj.Text = ._CAADJ
      TxtPrevBilled.Text = ._CAAMT
      TxtPrevBills.Text = ._CAPNO
      TxtOverride.Text = ._CAOVR
    End With
  Else
    TxtLateralFee.Text = ""
    TxtUniformFee.Text = ""
    TxtDeferPct.Text = ""
    TxtDeferAmt.Text = ""
    TxtAssmntAdj.Text = ""
    TxtPrevBilled.Text = ""
    TxtPrevBills.Text = ""
    TxtOverride.Text = ""
  End If
End Sub
Private Sub LnkCode_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode.LinkClicked
    MyFrmListRates = New FrmListRates
    MyFrmListRates.MdiParent = Me.ParentForm
    MyFrmListRates.WrkFamily = WrkFamily
    MyFrmListRates.WrkUBType = WrkUBType
    MyFrmListRates.WrkCode = TxtCode.Text
    MyFrmListRates.Show()
    Me.Hide()
End Sub
  Public Sub SaveData()
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String

    SetAssmntCodeTip()

    myUTCUST.GetOneRecordP(WrkListNo)
    If Not myUTCUST.RecordNotFound Then
      If Not AddMode And Not MyFrmUB102.TBarLog.Enabled Then
        MoveToLog("")
        myLOGUTAS.AddOneRecordP()
        If myLOGUTAS.ErrMsg <> "" Then
          WriteErrorLog(myLOGUTAS.ErrMsg)
          Exit Sub
        End If
      End If
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myUTCUST.UpdateOneRecordP()
        If myUTCUSTAS.ErrMsg <> "" Then
          WriteErrorLog(myUTCUSTAS.ErrMsg)
          Exit Sub
        End If
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    myUTCUSTAS.GetOneRecordP(WrkListNo, WrkUBType)
    If Not myUTCUSTAS.RecordNotFound Then
      If TxtCode.Text = "" Then
        MoveToLog("Delete")
        myLOGUTAS.AddOneRecordP()
        If myLOGUTAS.ErrMsg <> "" Then
          WriteErrorLog(myLOGUTAS.ErrMsg)
          Exit Sub
        End If
        myUTCUSTAS.DeleteOneRecordP()
      Else
        MoveToFileAS(False)
        MoveToLog("Change")
        myUTCUSTAS.UpdateOneRecordP()
        If myUTCUSTAS.ErrMsg <> "" Then
          WriteErrorLog(myUTCUSTAS.ErrMsg)
          Exit Sub
        End If
        myLOGUTAS.AddOneRecordP()
      End If
    Else
      MoveToFileAS(True)
      MoveToLog("Add")
      myUTCUSTAS.AddOneRecordP()
      If myUTCUSTAS.ErrMsg <> "" Then
        WriteErrorLog(myUTCUSTAS.ErrMsg)
        Exit Sub
      End If
      myLOGUTAS.AddOneRecordP()
    End If


    myUTCUSTRT.GetOneRecordP(WrkListNo, WrkUBType)
    If Not myUTCUSTRT.RecordNotFound Then
      If TxtCode.Text = "" Then
        myUTCUSTRT.DeleteOneRecordP()
      Else
        MoveToFileRT(False)
        myUTCUSTRT.UpdateOneRecordP()
      End If
    Else
      MoveToFileRT(True)
      myUTCUSTRT.AddOneRecordP()
    End If

    Me.Close()

  End Sub
   Private Sub MoveToFile()
      With myUTCUST
        ._CUAUNT = MyUtils.CnvSng(TxtDwellUnits.Text)
        ._CUFOOT = MyUtils.CnvSng(TxtFootage.Text)
        ._CUPVAL = MyUtils.CnvSng(TxtPropValue.Text)
        ._CUACRE = MyUtils.CnvSng(TxtAcreage.Text)
        ._CUAPMT = TxtAPermitNo.Text
      End With
   End Sub
   Private Sub MoveToFileAS(ByVal AddMode As Boolean)
      With myUTCUSTAS
        If AddMode Then
          ._CAACCT = WrkListNo
          ._CATYPE = WrkUBType
        End If
        ._CADEP = MyUtils.CnvSng(TxtDeferPct.Text)
        ._CADEF = MyUtils.CnvSng(TxtDeferAmt.Text)
        ._CAADJ = MyUtils.CnvSng(TxtAssmntAdj.Text)
        ._CAAMT = MyUtils.CnvSng(TxtPrevBilled.Text)
        ._CAPNO = MyUtils.CnvSng(TxtPrevBills.Text)
        ._CAOVR = MyUtils.CnvSng(TxtOverride.Text)
        ._CALAT = MyUtils.CnvSng(TxtLateralFee.Text)
        ._CAUNIF = MyUtils.CnvSng(TxtUniformFee.Text)
      End With
   End Sub
   Private Sub MoveToFileRT(ByVal AddMode As Boolean)
      With myUTCUSTRT
        If AddMode Then
          ._CRACCT = WrkListNo
          ._CRTYPE = WrkUBType
        End If
        ._CRCODE = TxtCode.Text
      End With
   End Sub
  Private Sub MoveToLog(ByVal WrkMode As String)
CheckFile:
    With myLOGUTAS
      .GetOneRecordP(WrkListNo, WrkUBType, MyUtils.SetDBDate(DateTime.Today), Format(DateTime.Now, "HHmmss"))
      If .RecordNotFound Then
        ._CAACCT = myUTCUSTAS._CAACCT
        ._CAADJ = myUTCUSTAS._CAADJ
        ._CAAMT = myUTCUSTAS._CAAMT
        ._CADEF = myUTCUSTAS._CADEF
        ._CADEP = myUTCUSTAS._CADEP
        ._CALAT = myUTCUSTAS._CALAT
        ._CAOVR = myUTCUSTAS._CAOVR
        ._CAPNO = myUTCUSTAS._CAPNO
        ._CATYPE = myUTCUSTAS._CATYPE
        ._CAUNIF = myUTCUSTAS._CAUNIF
        ._CUACRE = myUTCUST._CUACRE
        ._CUAPMT = myUTCUST._CUAPMT
        ._CUAUNT = myUTCUST._CUAUNT
        ._CUFOOT = myUTCUST._CUFOOT
        ._CUPVAL = myUTCUST._CUPVAL
        ._LOGDTE = MyUtils.SetDBDate(DateTime.Today)
        ._LOGTIM = Format(DateTime.Now, "HHmmss")
        Select Case WrkMode
          Case "Add"
            ._LOGCMT = "Record Added"
          Case "Change"
            ._LOGCMT = "Record Changed"
          Case "Delete"
            ._LOGCMT = "Record Deleted"
          Case Else
            ._LOGCMT = ""
        End Select
      Else
        Threading.Thread.Sleep(1000)
        GoTo CheckFile
      End If
    End With

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtCode, "")
    ErrProv.SetError(LblOrigAssmnt, "")
    ErrProv.SetError(LblAssmntLeft, "")
    ErrProv.SetError(LblPrincipal, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
      Case "code"
        ErrProv.SetError(TxtCode, ErrorMsg(I))
      Case "origassmnt"
        ErrProv.SetError(LblOrigAssmnt, ErrorMsg(I))
      Case "assmntleft"
        ErrProv.SetError(LblAssmntLeft, ErrorMsg(I))
      Case "principal"
        ErrProv.SetError(LblPrincipal, ErrorMsg(I))
      Case "bond"
        ErrProv.SetError(LblBond, ErrorMsg(I))
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

    If TxtCode.Text <> "" Then
      WrkTip = Ttp1.GetToolTip(TxtCode)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "code"
        ErrorMsg(I) = "Invalid Assessment Code"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(LblOrigAssmnt.Text) < 0 Then
      ErrorField(I) = "origassmnt"
      ErrorMsg(I) = "Original Assessment cannot be negative"
      I = I + 1
    End If

    If MyUtils.CnvSng(LblAssmntLeft.Text) < 0 Then
      ErrorField(I) = "assmntleft"
      ErrorMsg(I) = "Assessment Left cannot be negative"
      I = I + 1
    End If

    If MyUtils.CnvSng(LblPrincipal.Text) < 0 Then
      ErrorField(I) = "principal"
      ErrorMsg(I) = "Principal Amount cannot be negative"
      I = I + 1
    End If

    If MyUtils.CnvSng(LblBond.Text) < 0 Then
      ErrorField(I) = "bond"
      ErrorMsg(I) = "Bond Amount cannot be negative"
      I = I + 1
    End If
  End Sub
Private Sub SetAssmntCodeTip()
    Dim WrkDesc As String

    If Not TxtCode.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetUTRateASDesc(WrkUBType, TxtCode.Text)
    Ttp1.SetToolTip(TxtCode, WrkDesc)
End Sub
Private Sub FrmUB102AS_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmUB102.TBarSave.Enabled = True
    MyFrmUB102.TBarDelete.Enabled = True
    MyFrmUB102.TBarLog.Enabled = False
    MyFrmUB102C.FormatGrid()
    MyFrmUB102C.Show()
    'Memory Cleanup
    myUTCUST = Nothing
    myUTCUSTAS = Nothing
    myUTCUSTRT = Nothing
    MyFrmUB102AS = Nothing
End Sub
Private Sub FrmUB102AS_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmLOG = New FrmLOG
    MyFrmLOG.WrkListNo = MyFrmUB102C.WrkListNo
    MyFrmLOG.ds = MyFrmUB102AS.dsLog
    MyFrmLOG.WrkType = "A"
    MyFrmUB102.SbpScreen.Text = "UB102AS"
    MyUtils.CenterForm(Me.ParentForm, Me)
  With MyFrmUB102
    .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
    .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
  End With
End Sub
Private Sub TxtDwellUnits_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDwellUnits.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtFootage_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFootage.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtPropValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPropValue.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtAcreage_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAcreage.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtLateralFee_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLateralFee.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, True)
End Sub
Private Sub TxtUniformFee_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUniformFee.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, True)
End Sub
Private Sub TxtDeferPct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDeferPct.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDeferAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDeferAmt.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtAssmntAdj_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAssmntAdj.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, True)
End Sub
Private Sub TxtPrevBilled_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPrevBilled.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtOverride_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOverride.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCode.TextChanged
  CalcAssmnt()
End Sub
Private Sub TxtDwellUnits_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDwellUnits.TextChanged
  CalcAssmnt()
End Sub
Private Sub TxtFootage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFootage.TextChanged
  CalcAssmnt()
End Sub
Private Sub TxtPropValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPropValue.TextChanged
  CalcAssmnt()
End Sub
Private Sub TxtAcreage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAcreage.TextChanged
  CalcAssmnt()
End Sub
Private Sub TxtLateralFee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLateralFee.TextChanged
  CalcAssmnt()
End Sub
Private Sub TxtUniformFee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtUniformFee.TextChanged
  CalcAssmnt()
End Sub
Private Sub TxtDeferPct_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDeferPct.TextChanged
  CalcAssmnt()
End Sub
Private Sub TxtDeferAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDeferAmt.TextChanged
  CalcAssmnt()
End Sub
Private Sub TxtAssmntAdj_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAssmntAdj.TextChanged
  CalcAssmnt()
End Sub
Private Sub TxtPrevBilled_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrevBilled.TextChanged
  CalcAssmnt()
End Sub
Private Sub TxtPrevBills_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrevBills.TextChanged
  CalcAssmnt()
End Sub
Private Sub TxtOverride_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOverride.TextChanged
  CalcAssmnt()
End Sub
Private Sub TxtCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCode.Leave
  SetAssmntCodeTip()
End Sub
Private Sub GroupBox4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox4.DoubleClick
  MsgBox(StrDebug)
End Sub
Private Sub BtnAmort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAmort.Click
  MyFrmUB102Amort = New FrmUB102Amort
  MyFrmUB102Amort.WrkListNo = WrkListNo
  MyFrmUB102Amort.WrkUBType = WrkUBType
  MyFrmUB102Amort.MdiParent = Me.ParentForm
  MyFrmUB102Amort.Show()
  Me.Hide()

End Sub
Private Sub BtnPayoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPayoff.Click
  MyFrmUB102Payoff = New FrmUB102Payoff
  MyFrmUB102Payoff.WrkListNo = WrkListNo
  MyFrmUB102Payoff.WrkUBType = WrkUBType
  MyFrmUB102Payoff.MdiParent = Me.ParentForm
  MyFrmUB102Payoff.Show()
  Me.Hide()

End Sub

Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

End Sub
End Class
