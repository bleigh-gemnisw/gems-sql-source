Public Class FrmUB501C
  Inherits System.Windows.Forms.Form
	Dim myUTCOEA As UTCOEA.myData
	Dim myUTCOEAL1 As UTCOEAL1.myData
	Dim myTXINV As TXINV.myData
	Dim myUTCUSTRT As UTCUSTRT.myData
	Dim myUTCUSTAS As UTCUSTAS.myData
	Dim myUTCUST As UTCUST.myData
  Dim myTXPROF As TXPROF.myData
  Dim dsUTCOEAL1 As DataSet = New DataSet
  
  Dim LoadScrn As Boolean
  Dim AddMode As Boolean
'Work Fields
  Dim WrkOrigBill As Decimal
  Dim WrkAssmntLeft As Decimal
  Dim WrkCode As String
  Dim WrkUBType As String
  Dim WrkPrevAmt As Decimal
	Dim WrkCCDate As Date
'Passed Parms
  Friend WrkCCNo As Integer
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkType As String
  Friend WithEvents GrpPrevBilled As System.Windows.Forms.GroupBox
  Friend WithEvents LblPrevBilled As System.Windows.Forms.Label
  Friend WithEvents LblChgPrevBilled As System.Windows.Forms.Label
  Friend WithEvents LblOrigPrevBilled As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents Label17 As System.Windows.Forms.Label
 Friend WithEvents TxtDist As System.Windows.Forms.TextBox
	Friend WithEvents Label18 As System.Windows.Forms.Label

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
  Friend WithEvents LblType As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents LblCCNo As System.Windows.Forms.Label
  Friend WithEvents TxtZip4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtCity As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtAdd2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtSname As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents Label34 As System.Windows.Forms.Label
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents LblOrig As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents LblYear As System.Windows.Forms.Label
  Friend WithEvents LblCCDate As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents TxtAdd1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtZip5 As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents LblListNo As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents LnkReason As System.Windows.Forms.LinkLabel
Friend WithEvents Label14 As System.Windows.Forms.Label
Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
Friend WithEvents TxtReason As System.Windows.Forms.TextBox
Friend WithEvents TxtLoc As System.Windows.Forms.TextBox
Friend WithEvents TxtLocNo As System.Windows.Forms.TextBox
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents TxtTax2 As System.Windows.Forms.TextBox
Friend WithEvents LblChgTax2 As System.Windows.Forms.Label
Friend WithEvents LblOrigTax2 As System.Windows.Forms.Label
Friend WithEvents TxtTax1 As System.Windows.Forms.TextBox
Friend WithEvents LblChgTax1 As System.Windows.Forms.Label
Friend WithEvents LblOrigTax1 As System.Windows.Forms.Label
Friend WithEvents TxtTax3 As System.Windows.Forms.TextBox
Friend WithEvents Label10 As System.Windows.Forms.Label
Friend WithEvents LblChgTax3 As System.Windows.Forms.Label
Friend WithEvents LblOrigTax3 As System.Windows.Forms.Label
Friend WithEvents TxtTax4 As System.Windows.Forms.TextBox
Friend WithEvents Label16 As System.Windows.Forms.Label
Friend WithEvents LblChgTax4 As System.Windows.Forms.Label
Friend WithEvents LblOrigTax4 As System.Windows.Forms.Label
Friend WithEvents Label20 As System.Windows.Forms.Label
Friend WithEvents LblChgTaxT As System.Windows.Forms.Label
Friend WithEvents LblOrigTaxT As System.Windows.Forms.Label
Friend WithEvents TxtBond As System.Windows.Forms.TextBox
Friend WithEvents LblBond As System.Windows.Forms.Label
Friend WithEvents LblChgBond As System.Windows.Forms.Label
Friend WithEvents LblOrigBond As System.Windows.Forms.Label
Friend WithEvents LblTaxT As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.LblType = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.LblCCNo = New System.Windows.Forms.Label()
    Me.TxtZip4 = New System.Windows.Forms.TextBox()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtAdd2 = New System.Windows.Forms.TextBox()
    Me.TxtSname = New System.Windows.Forms.TextBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.LblTaxT = New System.Windows.Forms.Label()
    Me.TxtBond = New System.Windows.Forms.TextBox()
    Me.LblBond = New System.Windows.Forms.Label()
    Me.LblChgBond = New System.Windows.Forms.Label()
    Me.LblOrigBond = New System.Windows.Forms.Label()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.LblChgTaxT = New System.Windows.Forms.Label()
    Me.LblOrigTaxT = New System.Windows.Forms.Label()
    Me.TxtTax4 = New System.Windows.Forms.TextBox()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.LblChgTax4 = New System.Windows.Forms.Label()
    Me.LblOrigTax4 = New System.Windows.Forms.Label()
    Me.TxtTax3 = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.LblChgTax3 = New System.Windows.Forms.Label()
    Me.LblOrigTax3 = New System.Windows.Forms.Label()
    Me.TxtTax2 = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.LblChgTax2 = New System.Windows.Forms.Label()
    Me.LblOrigTax2 = New System.Windows.Forms.Label()
    Me.TxtTax1 = New System.Windows.Forms.TextBox()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.LblChgTax1 = New System.Windows.Forms.Label()
    Me.Label34 = New System.Windows.Forms.Label()
    Me.LblOrigTax1 = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.LblOrig = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.LblCCDate = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.TxtAdd1 = New System.Windows.Forms.TextBox()
    Me.TxtZip5 = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.LnkReason = New System.Windows.Forms.LinkLabel()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.TxtDesc = New System.Windows.Forms.TextBox()
    Me.TxtReason = New System.Windows.Forms.TextBox()
    Me.TxtLoc = New System.Windows.Forms.TextBox()
    Me.TxtLocNo = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.GrpPrevBilled = New System.Windows.Forms.GroupBox()
    Me.LblPrevBilled = New System.Windows.Forms.Label()
    Me.LblChgPrevBilled = New System.Windows.Forms.Label()
    Me.LblOrigPrevBilled = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.GrpPrevBilled.SuspendLayout()
    Me.SuspendLayout()
    '
    'LblType
    '
    Me.LblType.Location = New System.Drawing.Point(371, 9)
    Me.LblType.Name = "LblType"
    Me.LblType.Size = New System.Drawing.Size(22, 16)
    Me.LblType.TabIndex = 175
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblCCNo
    '
    Me.LblCCNo.Location = New System.Drawing.Point(62, 8)
    Me.LblCCNo.Name = "LblCCNo"
    Me.LblCCNo.Size = New System.Drawing.Size(48, 16)
    Me.LblCCNo.TabIndex = 178
    '
    'TxtZip4
    '
    Me.TxtZip4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtZip4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip4.Location = New System.Drawing.Point(424, 128)
    Me.TxtZip4.MaxLength = 4
    Me.TxtZip4.Name = "TxtZip4"
    Me.TxtZip4.Size = New System.Drawing.Size(40, 22)
    Me.TxtZip4.TabIndex = 8
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(96, 128)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(232, 22)
    Me.TxtCity.TabIndex = 5
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(130, 9)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(50, 15)
    Me.Label9.TabIndex = 172
    Me.Label9.Text = "Tax Year"
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(336, 128)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 22)
    Me.TxtState.TabIndex = 6
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(96, 32)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(280, 22)
    Me.TxtName.TabIndex = 0
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(12, 132)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(80, 16)
    Me.Label4.TabIndex = 169
    Me.Label4.Text = "City/State/Zip"
    '
    'TxtAdd2
    '
    Me.TxtAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd2.Location = New System.Drawing.Point(96, 104)
    Me.TxtAdd2.MaxLength = 35
    Me.TxtAdd2.Name = "TxtAdd2"
    Me.TxtAdd2.Size = New System.Drawing.Size(280, 22)
    Me.TxtAdd2.TabIndex = 4
    '
    'TxtSname
    '
    Me.TxtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSname.Location = New System.Drawing.Point(96, 56)
    Me.TxtSname.MaxLength = 35
    Me.TxtSname.Name = "TxtSname"
    Me.TxtSname.Size = New System.Drawing.Size(280, 22)
    Me.TxtSname.TabIndex = 2
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.LblTaxT)
    Me.GroupBox2.Controls.Add(Me.TxtBond)
    Me.GroupBox2.Controls.Add(Me.LblBond)
    Me.GroupBox2.Controls.Add(Me.LblChgBond)
    Me.GroupBox2.Controls.Add(Me.LblOrigBond)
    Me.GroupBox2.Controls.Add(Me.Label20)
    Me.GroupBox2.Controls.Add(Me.LblChgTaxT)
    Me.GroupBox2.Controls.Add(Me.LblOrigTaxT)
    Me.GroupBox2.Controls.Add(Me.TxtTax4)
    Me.GroupBox2.Controls.Add(Me.Label16)
    Me.GroupBox2.Controls.Add(Me.LblChgTax4)
    Me.GroupBox2.Controls.Add(Me.LblOrigTax4)
    Me.GroupBox2.Controls.Add(Me.TxtTax3)
    Me.GroupBox2.Controls.Add(Me.Label10)
    Me.GroupBox2.Controls.Add(Me.LblChgTax3)
    Me.GroupBox2.Controls.Add(Me.LblOrigTax3)
    Me.GroupBox2.Controls.Add(Me.TxtTax2)
    Me.GroupBox2.Controls.Add(Me.Label7)
    Me.GroupBox2.Controls.Add(Me.LblChgTax2)
    Me.GroupBox2.Controls.Add(Me.LblOrigTax2)
    Me.GroupBox2.Controls.Add(Me.TxtTax1)
    Me.GroupBox2.Controls.Add(Me.Label19)
    Me.GroupBox2.Controls.Add(Me.LblChgTax1)
    Me.GroupBox2.Controls.Add(Me.Label34)
    Me.GroupBox2.Controls.Add(Me.LblOrigTax1)
    Me.GroupBox2.Controls.Add(Me.Label30)
    Me.GroupBox2.Controls.Add(Me.LblOrig)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(4, 236)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(584, 108)
    Me.GroupBox2.TabIndex = 170
    Me.GroupBox2.TabStop = False
    '
    'LblTaxT
    '
    Me.LblTaxT.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTaxT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTaxT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTaxT.Location = New System.Drawing.Point(412, 56)
    Me.LblTaxT.Name = "LblTaxT"
    Me.LblTaxT.Size = New System.Drawing.Size(80, 16)
    Me.LblTaxT.TabIndex = 194
    Me.LblTaxT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtBond
    '
    Me.TxtBond.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBond.Location = New System.Drawing.Point(496, 52)
    Me.TxtBond.MaxLength = 9
    Me.TxtBond.Name = "TxtBond"
    Me.TxtBond.Size = New System.Drawing.Size(80, 20)
    Me.TxtBond.TabIndex = 193
    Me.TxtBond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblBond
    '
    Me.LblBond.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBond.ForeColor = System.Drawing.Color.Black
    Me.LblBond.Location = New System.Drawing.Point(496, 8)
    Me.LblBond.Name = "LblBond"
    Me.LblBond.Size = New System.Drawing.Size(84, 16)
    Me.LblBond.TabIndex = 192
    Me.LblBond.Text = "Bond Interest"
    '
    'LblChgBond
    '
    Me.LblChgBond.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgBond.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgBond.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgBond.Location = New System.Drawing.Point(496, 80)
    Me.LblChgBond.Name = "LblChgBond"
    Me.LblChgBond.Size = New System.Drawing.Size(80, 16)
    Me.LblChgBond.TabIndex = 191
    Me.LblChgBond.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblOrigBond
    '
    Me.LblOrigBond.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigBond.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigBond.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigBond.Location = New System.Drawing.Point(496, 32)
    Me.LblOrigBond.Name = "LblOrigBond"
    Me.LblOrigBond.Size = New System.Drawing.Size(80, 16)
    Me.LblOrigBond.TabIndex = 190
    Me.LblOrigBond.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label20
    '
    Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label20.ForeColor = System.Drawing.Color.Black
    Me.Label20.Location = New System.Drawing.Point(417, 8)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(66, 16)
    Me.Label20.TabIndex = 188
    Me.Label20.Text = "Total Tax"
    '
    'LblChgTaxT
    '
    Me.LblChgTaxT.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgTaxT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgTaxT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgTaxT.Location = New System.Drawing.Point(412, 80)
    Me.LblChgTaxT.Name = "LblChgTaxT"
    Me.LblChgTaxT.Size = New System.Drawing.Size(80, 16)
    Me.LblChgTaxT.TabIndex = 187
    Me.LblChgTaxT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblOrigTaxT
    '
    Me.LblOrigTaxT.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigTaxT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigTaxT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigTaxT.Location = New System.Drawing.Point(412, 32)
    Me.LblOrigTaxT.Name = "LblOrigTaxT"
    Me.LblOrigTaxT.Size = New System.Drawing.Size(80, 16)
    Me.LblOrigTaxT.TabIndex = 186
    Me.LblOrigTaxT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtTax4
    '
    Me.TxtTax4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTax4.Location = New System.Drawing.Point(324, 52)
    Me.TxtTax4.MaxLength = 9
    Me.TxtTax4.Name = "TxtTax4"
    Me.TxtTax4.Size = New System.Drawing.Size(80, 20)
    Me.TxtTax4.TabIndex = 3
    Me.TxtTax4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label16
    '
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.ForeColor = System.Drawing.Color.Black
    Me.Label16.Location = New System.Drawing.Point(326, 8)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(78, 16)
    Me.Label16.TabIndex = 184
    Me.Label16.Text = "4th Payment"
    '
    'LblChgTax4
    '
    Me.LblChgTax4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgTax4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgTax4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgTax4.Location = New System.Drawing.Point(324, 80)
    Me.LblChgTax4.Name = "LblChgTax4"
    Me.LblChgTax4.Size = New System.Drawing.Size(80, 16)
    Me.LblChgTax4.TabIndex = 183
    Me.LblChgTax4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblOrigTax4
    '
    Me.LblOrigTax4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigTax4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigTax4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigTax4.Location = New System.Drawing.Point(324, 32)
    Me.LblOrigTax4.Name = "LblOrigTax4"
    Me.LblOrigTax4.Size = New System.Drawing.Size(80, 16)
    Me.LblOrigTax4.TabIndex = 182
    Me.LblOrigTax4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtTax3
    '
    Me.TxtTax3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTax3.Location = New System.Drawing.Point(240, 52)
    Me.TxtTax3.MaxLength = 9
    Me.TxtTax3.Name = "TxtTax3"
    Me.TxtTax3.Size = New System.Drawing.Size(80, 20)
    Me.TxtTax3.TabIndex = 2
    Me.TxtTax3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label10
    '
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.ForeColor = System.Drawing.Color.Black
    Me.Label10.Location = New System.Drawing.Point(242, 8)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(78, 16)
    Me.Label10.TabIndex = 180
    Me.Label10.Text = "3rd Payment"
    '
    'LblChgTax3
    '
    Me.LblChgTax3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgTax3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgTax3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgTax3.Location = New System.Drawing.Point(240, 80)
    Me.LblChgTax3.Name = "LblChgTax3"
    Me.LblChgTax3.Size = New System.Drawing.Size(80, 16)
    Me.LblChgTax3.TabIndex = 179
    Me.LblChgTax3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblOrigTax3
    '
    Me.LblOrigTax3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigTax3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigTax3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigTax3.Location = New System.Drawing.Point(240, 32)
    Me.LblOrigTax3.Name = "LblOrigTax3"
    Me.LblOrigTax3.Size = New System.Drawing.Size(80, 16)
    Me.LblOrigTax3.TabIndex = 178
    Me.LblOrigTax3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtTax2
    '
    Me.TxtTax2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTax2.Location = New System.Drawing.Point(156, 52)
    Me.TxtTax2.MaxLength = 9
    Me.TxtTax2.Name = "TxtTax2"
    Me.TxtTax2.Size = New System.Drawing.Size(80, 20)
    Me.TxtTax2.TabIndex = 1
    Me.TxtTax2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label7
    '
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.ForeColor = System.Drawing.Color.Black
    Me.Label7.Location = New System.Drawing.Point(156, 8)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(80, 16)
    Me.Label7.TabIndex = 176
    Me.Label7.Text = "2nd Payment"
    '
    'LblChgTax2
    '
    Me.LblChgTax2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgTax2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgTax2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgTax2.Location = New System.Drawing.Point(156, 80)
    Me.LblChgTax2.Name = "LblChgTax2"
    Me.LblChgTax2.Size = New System.Drawing.Size(80, 16)
    Me.LblChgTax2.TabIndex = 175
    Me.LblChgTax2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblOrigTax2
    '
    Me.LblOrigTax2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigTax2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigTax2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigTax2.Location = New System.Drawing.Point(156, 32)
    Me.LblOrigTax2.Name = "LblOrigTax2"
    Me.LblOrigTax2.Size = New System.Drawing.Size(80, 16)
    Me.LblOrigTax2.TabIndex = 174
    Me.LblOrigTax2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtTax1
    '
    Me.TxtTax1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTax1.Location = New System.Drawing.Point(72, 52)
    Me.TxtTax1.MaxLength = 9
    Me.TxtTax1.Name = "TxtTax1"
    Me.TxtTax1.Size = New System.Drawing.Size(80, 20)
    Me.TxtTax1.TabIndex = 0
    Me.TxtTax1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label19
    '
    Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label19.ForeColor = System.Drawing.Color.Black
    Me.Label19.Location = New System.Drawing.Point(69, 8)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(83, 16)
    Me.Label19.TabIndex = 33
    Me.Label19.Text = "1st Payment"
    '
    'LblChgTax1
    '
    Me.LblChgTax1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgTax1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgTax1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgTax1.Location = New System.Drawing.Point(72, 80)
    Me.LblChgTax1.Name = "LblChgTax1"
    Me.LblChgTax1.Size = New System.Drawing.Size(80, 16)
    Me.LblChgTax1.TabIndex = 21
    Me.LblChgTax1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label34
    '
    Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label34.Location = New System.Drawing.Point(8, 80)
    Me.Label34.Name = "Label34"
    Me.Label34.Size = New System.Drawing.Size(48, 16)
    Me.Label34.TabIndex = 20
    Me.Label34.Text = "Change"
    '
    'LblOrigTax1
    '
    Me.LblOrigTax1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigTax1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigTax1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigTax1.Location = New System.Drawing.Point(72, 32)
    Me.LblOrigTax1.Name = "LblOrigTax1"
    Me.LblOrigTax1.Size = New System.Drawing.Size(80, 16)
    Me.LblOrigTax1.TabIndex = 18
    Me.LblOrigTax1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label30
    '
    Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label30.Location = New System.Drawing.Point(8, 56)
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
    'Label12
    '
    Me.Label12.Location = New System.Drawing.Point(333, 8)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(32, 16)
    Me.Label12.TabIndex = 174
    Me.Label12.Text = "Type"
    '
    'LblYear
    '
    Me.LblYear.Location = New System.Drawing.Point(186, 9)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(32, 16)
    Me.LblYear.TabIndex = 173
    '
    'LblCCDate
    '
    Me.LblCCDate.Location = New System.Drawing.Point(520, 8)
    Me.LblCCDate.Name = "LblCCDate"
    Me.LblCCDate.Size = New System.Drawing.Size(64, 16)
    Me.LblCCDate.TabIndex = 177
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(456, 8)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(56, 16)
    Me.Label13.TabIndex = 176
    Me.Label13.Text = "Adj Date"
    '
    'TxtAdd1
    '
    Me.TxtAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd1.Location = New System.Drawing.Point(96, 80)
    Me.TxtAdd1.MaxLength = 35
    Me.TxtAdd1.Name = "TxtAdd1"
    Me.TxtAdd1.Size = New System.Drawing.Size(280, 22)
    Me.TxtAdd1.TabIndex = 3
    '
    'TxtZip5
    '
    Me.TxtZip5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtZip5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip5.Location = New System.Drawing.Point(368, 128)
    Me.TxtZip5.MaxLength = 5
    Me.TxtZip5.Name = "TxtZip5"
    Me.TxtZip5.Size = New System.Drawing.Size(48, 22)
    Me.TxtZip5.TabIndex = 7
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(12, 36)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(48, 16)
    Me.Label5.TabIndex = 165
    Me.Label5.Text = "Name"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(12, 84)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(80, 16)
    Me.Label3.TabIndex = 168
    Me.Label3.Text = "Street Address"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(12, 60)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(80, 16)
    Me.Label2.TabIndex = 167
    Me.Label2.Text = "Second Name"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(226, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 16)
    Me.Label1.TabIndex = 166
    Me.Label1.Text = "List No"
    '
    'LblListNo
    '
    Me.LblListNo.Location = New System.Drawing.Point(274, 9)
    Me.LblListNo.Name = "LblListNo"
    Me.LblListNo.Size = New System.Drawing.Size(48, 16)
    Me.LblListNo.TabIndex = 179
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(8, 8)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(48, 16)
    Me.Label8.TabIndex = 171
    Me.Label8.Text = "Adj No"
    '
    'LnkReason
    '
    Me.LnkReason.Location = New System.Drawing.Point(8, 181)
    Me.LnkReason.Name = "LnkReason"
    Me.LnkReason.Size = New System.Drawing.Size(88, 16)
    Me.LnkReason.TabIndex = 186
    Me.LnkReason.TabStop = True
    Me.LnkReason.Text = "Change Reason"
    '
    'Label14
    '
    Me.Label14.Location = New System.Drawing.Point(8, 204)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(88, 16)
    Me.Label14.TabIndex = 185
    Me.Label14.Text = "Description"
    '
    'TxtDesc
    '
    Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDesc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDesc.Location = New System.Drawing.Point(96, 200)
    Me.TxtDesc.MaxLength = 25
    Me.TxtDesc.Name = "TxtDesc"
    Me.TxtDesc.Size = New System.Drawing.Size(152, 22)
    Me.TxtDesc.TabIndex = 12
    '
    'TxtReason
    '
    Me.TxtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtReason.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtReason.Location = New System.Drawing.Point(96, 176)
    Me.TxtReason.MaxLength = 1
    Me.TxtReason.Name = "TxtReason"
    Me.TxtReason.Size = New System.Drawing.Size(16, 22)
    Me.TxtReason.TabIndex = 11
    Me.TxtReason.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtLoc
    '
    Me.TxtLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLoc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLoc.Location = New System.Drawing.Point(172, 152)
    Me.TxtLoc.MaxLength = 25
    Me.TxtLoc.Name = "TxtLoc"
    Me.TxtLoc.Size = New System.Drawing.Size(184, 22)
    Me.TxtLoc.TabIndex = 10
    '
    'TxtLocNo
    '
    Me.TxtLocNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocNo.Location = New System.Drawing.Point(96, 152)
    Me.TxtLocNo.MaxLength = 7
    Me.TxtLocNo.Name = "TxtLocNo"
    Me.TxtLocNo.Size = New System.Drawing.Size(68, 22)
    Me.TxtLocNo.TabIndex = 9
    Me.TxtLocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(8, 157)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(88, 16)
    Me.Label6.TabIndex = 182
    Me.Label6.Text = "Location#/Name"
    '
    'GrpPrevBilled
    '
    Me.GrpPrevBilled.Controls.Add(Me.LblPrevBilled)
    Me.GrpPrevBilled.Controls.Add(Me.LblChgPrevBilled)
    Me.GrpPrevBilled.Controls.Add(Me.LblOrigPrevBilled)
    Me.GrpPrevBilled.Controls.Add(Me.Label11)
    Me.GrpPrevBilled.Controls.Add(Me.Label15)
    Me.GrpPrevBilled.Controls.Add(Me.Label17)
    Me.GrpPrevBilled.ForeColor = System.Drawing.Color.Blue
    Me.GrpPrevBilled.Location = New System.Drawing.Point(423, 152)
    Me.GrpPrevBilled.Name = "GrpPrevBilled"
    Me.GrpPrevBilled.Size = New System.Drawing.Size(156, 84)
    Me.GrpPrevBilled.TabIndex = 187
    Me.GrpPrevBilled.TabStop = False
    Me.GrpPrevBilled.Text = "Previously Billed Amount"
    '
    'LblPrevBilled
    '
    Me.LblPrevBilled.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPrevBilled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPrevBilled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPrevBilled.ForeColor = System.Drawing.Color.Black
    Me.LblPrevBilled.Location = New System.Drawing.Point(70, 40)
    Me.LblPrevBilled.Name = "LblPrevBilled"
    Me.LblPrevBilled.Size = New System.Drawing.Size(80, 16)
    Me.LblPrevBilled.TabIndex = 197
    Me.LblPrevBilled.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblChgPrevBilled
    '
    Me.LblChgPrevBilled.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblChgPrevBilled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblChgPrevBilled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblChgPrevBilled.ForeColor = System.Drawing.Color.Black
    Me.LblChgPrevBilled.Location = New System.Drawing.Point(70, 64)
    Me.LblChgPrevBilled.Name = "LblChgPrevBilled"
    Me.LblChgPrevBilled.Size = New System.Drawing.Size(80, 16)
    Me.LblChgPrevBilled.TabIndex = 196
    Me.LblChgPrevBilled.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblOrigPrevBilled
    '
    Me.LblOrigPrevBilled.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigPrevBilled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigPrevBilled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigPrevBilled.ForeColor = System.Drawing.Color.Black
    Me.LblOrigPrevBilled.Location = New System.Drawing.Point(70, 16)
    Me.LblOrigPrevBilled.Name = "LblOrigPrevBilled"
    Me.LblOrigPrevBilled.Size = New System.Drawing.Size(80, 16)
    Me.LblOrigPrevBilled.TabIndex = 195
    Me.LblOrigPrevBilled.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label11
    '
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.ForeColor = System.Drawing.Color.Black
    Me.Label11.Location = New System.Drawing.Point(6, 66)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(48, 16)
    Me.Label11.TabIndex = 23
    Me.Label11.Text = "Change"
    '
    'Label15
    '
    Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label15.ForeColor = System.Drawing.Color.Black
    Me.Label15.Location = New System.Drawing.Point(6, 42)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(48, 16)
    Me.Label15.TabIndex = 22
    Me.Label15.Text = "New"
    '
    'Label17
    '
    Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label17.ForeColor = System.Drawing.Color.Black
    Me.Label17.Location = New System.Drawing.Point(6, 18)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(64, 16)
    Me.Label17.TabIndex = 21
    Me.Label17.Text = "Original"
    '
    'Label18
    '
    Me.Label18.Location = New System.Drawing.Point(393, 38)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(32, 16)
    Me.Label18.TabIndex = 188
    Me.Label18.Text = "Dist"
    '
    'TxtDist
    '
    Me.TxtDist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDist.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(423, 34)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(34, 22)
    Me.TxtDist.TabIndex = 1
    '
    'FrmUB501C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(592, 349)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.Label18)
    Me.Controls.Add(Me.GrpPrevBilled)
    Me.Controls.Add(Me.LnkReason)
    Me.Controls.Add(Me.Label14)
    Me.Controls.Add(Me.TxtDesc)
    Me.Controls.Add(Me.TxtReason)
    Me.Controls.Add(Me.TxtLoc)
    Me.Controls.Add(Me.TxtLocNo)
    Me.Controls.Add(Me.TxtZip4)
    Me.Controls.Add(Me.TxtCity)
    Me.Controls.Add(Me.TxtState)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.TxtAdd2)
    Me.Controls.Add(Me.TxtSname)
    Me.Controls.Add(Me.TxtAdd1)
    Me.Controls.Add(Me.TxtZip5)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.LblCCDate)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LblListNo)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.LblType)
    Me.Controls.Add(Me.LblCCNo)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmUB501C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Adjustment"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GrpPrevBilled.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmUB501C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Dim dsUTCOEAL1 As DataSet = New DataSet
		Dim WrkDBDate As Integer
    Dim WrkDBTime As Integer
    Dim WrkDist As Integer
		Dim CoeCCNo As Integer
		Dim ChkDate As Date

		myUTCOEA = New UTCOEA.mydata(MyDBConnect)
		myUTCOEAL1 = New UTCOEAL1.mydata(MyDBConnect)
		myTXINV = New TXINV.mydata(MyDBConnect)
		myUTCUSTRT = New UTCUSTRT.mydata(MyDBConnect)
		myUTCUSTAS = New UTCUSTAS.mydata(MyDBConnect)
		myUTCUST = New UTCUST.mydata(MyDBConnect)
    myTXPROF = New TXPROF.mydata(MyDBConnect)
    LoadScrn = True

    MyFrmUB501.TBarNew.Enabled = False
    MyFrmUB501.TBarSave.Enabled = True
    MyFrmUB501.TBarHist.Enabled = False
    MyFrmUB501.TBarPrint.Enabled = False

    'On New, Check for existing Adjustment done today. If found, then change to update mode. 
    If WrkCCNo = 0 Then
			myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
      TxtDist.Text = myTXINV._DIST
			WrkCCDate = CheckCCDate(Date.Today, WrkType, WrkYear, "", myTXINV._DIST)
			If WrkCCDate = ChkDate Then
				MsgBox("Tax Profile is missing", MsgBoxStyle.Exclamation, "*** WARNING ***")
				WrkCCDate = Date.Today
			End If
			If Date.Today <> WrkCCDate Then
				MsgBox("Changing date to billing date", MsgBoxStyle.Information, "Adjustment Entry date is before billing date")
			End If
      WrkDBDate = MyUtils.SetDBDate(WrkCCDate)
			dsUTCOEAL1 = myUTCOEAL1.GetLastbyDate(WrkListNo, WrkYear, WrkType, WrkDBDate)
			If dsUTCOEAL1.Tables(0).Rows.Count > 0 Then
				With dsUTCOEAL1.Tables(0).Rows(0)
					If WrkDBDate = .Item("cdate") Then
						WrkCCNo = .Item("ccno")
						MsgBox("New Adjustment was not created. Click OK to change existing Adjustment done today instead.", MsgBoxStyle.Information, "Existing Adjustment found with today's date")
					End If
				End With
			End If
    End If

    'Fill the dataset with the data
    If WrkCCNo > 0 Then
      LblCCNo.Text = WrkCCNo
      Me.Text = "Maintain " & Me.Text
			myUTCOEA.GetOneRecordP(WrkCCNo)
			If myUTCOEA.RecordNotFound Then
				 MyFrmUB501.TBarNew.Enabled = False
				 MyFrmUB501.TBarSave.Enabled = False
				 MyFrmUB501.TBarDelete.Enabled = False
				 Me.ErrProv.SetError(LblCCNo, "Record not found")
				 Exit Sub
			End If
      MyFrmUB501.TBarPrint.Enabled = True
      GetUTCOEA()
      If WrkCCDate <> Date.Today Then
         Me.ErrProv.SetError(LblCCNo, "Cannot edit (not same date)")
         MyFrmUB501.TBarSave.Enabled = False
      End If
    Else
      MyFrmUB501.TBarDelete.Enabled = False
      AddMode = True
      Me.Text = "Add " & Me.Text
      LblListNo.Text = WrkListNo
      LblYear.Text = WrkYear
      LblType.Text = WrkType
    End If

    WrkDist = 0

    CoeCCNo = 0
    WrkPrevAmt = 0
    WrkDBDate = MyUtils.SetDBDate(WrkCCDate) - 1
		WrkDBTime = 999999
		LblCCDate.Text = WrkCCDate
		dsUTCOEAL1 = myUTCOEAL1.GetViewDescList(WrkListNo, WrkYear, WrkType, WrkDBDate, _
			WrkDBTime, 50)
		If dsUTCOEAL1.Tables(0).Rows.Count > 0 Then
			With dsUTCOEAL1.Tables(0).Rows(0)
				CoeCCNo = .Item("ccno")
			End With
			GetOrigUTCOEA(CoeCCNo)
		End If

			myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
			If Not myTXINV.RecordNotFound Then
				With myTXINV
          TxtDist.Text = ._DIST
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
					If CoeCCNo = 0 Then
						LblOrigTax1.Text = FormatNumber(._TAX1, 2)
						LblOrigTax2.Text = FormatNumber(._TAX2, 2)
						LblOrigTax3.Text = FormatNumber(._TX3RD, 2)
						LblOrigTax4.Text = FormatNumber(._TX4TH, 2)
						LblOrigTaxT.Text = FormatNumber(._TAXT, 2)
						If AddMode Then
							LblOrigBond.Text = FormatNumber(._BOND, 2)
						End If
					End If
				End With
			End If

		If AddMode Then
      TxtTax1.Text = MyUtils.CnvSng(LblOrigTax1.Text)
      TxtTax2.Text = MyUtils.CnvSng(LblOrigTax2.Text)
      TxtTax3.Text = MyUtils.CnvSng(LblOrigTax3.Text)
      TxtTax4.Text = MyUtils.CnvSng(LblOrigTax4.Text)
      LblTaxT.Text = MyUtils.CnvSng(LblOrigTaxT.Text)
      TxtBond.Text = MyUtils.CnvSng(LblOrigBond.Text)
    End If

    dsUTCOEAL1 = myUTCOEAL1.GetViewbyList(WrkListNo, WrkYear, WrkType, 50)
    If dsUTCOEAL1.Tables(0).Rows.Count > 1 Then
      MyFrmUB501.TBarHist.Enabled = True
    End If

    SetCResnTip()

    LoadScrn = False
    CalcChg()
    WrkPrevAmt = MyUtils.CnvSng(LblTaxT.Text)

    WrkUBType = GetUTTypeUBType(WrkType)
    WrkCode = GetRateCode(WrkType)
    myUTCUSTAS.GetOneRecordP(WrkListNo, WrkUBType)
    If Not myUTCUSTAS.RecordNotFound Then
      CalcAssmnt()
      CalcPrevBilled()
    Else
      GrpPrevBilled.Visible = False
    End If

    If WrkUBType <> "A" And WrkUBType <> "B" Then
      LblBond.Visible = False
      LblOrigBond.Visible = False
      TxtBond.Visible = False
      LblChgBond.Visible = False
    End If
    SetValidPayments()
  End Sub

  Private Sub FrmUB501C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmUB501.TBarNew.Enabled = True
    MyFrmUB501.TBarSave.Enabled = False
    MyFrmUB501.TBarDelete.Enabled = False
    MyFrmUB501.TBarHist.Enabled = False
    MyFrmUB501.TBarPrint.Enabled = False
    If MyFrmUB501B.RbLoc.Checked = True Then
      MyFrmUB501B.FormatGridLoc()
    Else
      MyFrmUB501B.FormatGrid(True)
    End If

    MyFrmUB501B.Show()
    'Memory Cleanup
    myUTCOEA = Nothing
    myUTCOEAL1 = Nothing
    myTXINV = Nothing
    MyFrmUB501C = Nothing

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    myUTCOEA.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String

    If AddMode Then
      WrkCCNo = myUTCOEA.AutoGenKey
    End If

    myUTCOEA.GetOneRecordP(WrkCCNo)
    If AddMode Then
      If Not myUTCOEA.RecordNotFound Then
        Me.ErrProv.SetError(LblCCNo, "Record already exists")
        Exit Sub
      End If
    End If

    SetCResnTip()

    If Not AddMode Then
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myUTCOEA.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myUTCOEA.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
    If Not myTXINV.RecordNotFound Then
      MoveToFile()
      If IsNothing(ErrorMsg(0)) Then
        myTXINV.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      myTXINV._LISTNo = MyUtils.CnvSng(LblListNo.Text)
      myTXINV._TYPE = LblType.Text
      myTXINV._YEAR = MyUtils.CnvSng(LblYear.Text)
      MoveToFile()
      If IsNothing(ErrorMsg(0)) Then
        myTXINV.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    If WrkUBType = "A" Or WrkUBType = "B" Then
      UpdateCUSTAS()
    End If

    If AddMode Then
      MsgBox("Adjustment number is " & WrkCCNo)
    End If
    Me.Close()

  End Sub
  Public Sub PrintData()
    PrtCert(WrkType)
  End Sub
  Public Sub ShowCCHist()
    MyFrmListAdjHist = New FrmListAdjHist
    MyFrmListAdjHist.WrkListNo = WrkListNo
    MyFrmListAdjHist.WrkType = WrkType
    MyFrmListAdjHist.WrkYear = WrkYear
    MyFrmListAdjHist.ShowDialog()

  End Sub
  Private Sub MoveToFile()
      With myUTCOEA
        ._CCNO = WrkCCNo
        ._LISTNO = WrkListNo
        ._YEAR = WrkYear
        ._TYPE = WrkType
        ._DIST = MyUtils.CnvSng(TxtDist.Text)
        ._NAME = TxtName.Text
        ._CETAX1 = MyUtils.CnvSng(TxtTax1.Text)
        ._CETAX2 = MyUtils.CnvSng(TxtTax2.Text)
        ._CETAX3 = MyUtils.CnvSng(TxtTax3.Text)
        ._CETAX4 = MyUtils.CnvSng(TxtTax4.Text)
        ._CETAX = MyUtils.CnvSng(LblTaxT.Text)
        ._COBOND = MyUtils.CnvSng(LblOrigBond.Text)
        ._CNBOND = MyUtils.CnvSng(TxtBond.Text)
        ._CDATE = MyUtils.SetDBDate(LblCCDate.Text)
        ._RSNCD = TxtReason.Text
        'Reason Codes
        SetCResnTip()
        ._CDESC = TxtDesc.Text
      ._PRF = Mid(MyUserID, 1, 10)
      ._CHDATE = MyUtils.SetDBDate(LblCCDate.Text)
      ._CHTIME = Format(DateTime.Now, "hhmmss")
      End With

      With myTXINV
        ._NAME = TxtName.Text
        ._LETT = Mid$(TxtName.Text, 1, 1)
        ._SNAME = TxtSname.Text
        ._ADD1 = TxtAdd1.Text
        ._ADD2 = TxtAdd2.Text
        ._CITY = TxtCity.Text
        ._STATE = TxtState.Text
        ._ZIP5 = MyUtils.CnvSng(TxtZip5.Text)
        ._ZIP4 = MyUtils.CnvSng(TxtZip4.Text)
        ._LOCNo = MyUtils.JustifyRight(TxtLocNo.Text, 7)
        ._LOC = TxtLoc.Text
        ._CCNO = WrkCCNo
        ._CDATE = MyUtils.SetDBDate(LblCCDate.Text)
        ._CCETAX = MyUtils.CnvSng(LblTaxT.Text)
        ._CCTX1 = MyUtils.CnvSng(TxtTax1.Text)
        ._CCTX2 = MyUtils.CnvSng(TxtTax2.Text)
        ._CCTX3 = MyUtils.CnvSng(TxtTax3.Text)
        ._CCTX4 = MyUtils.CnvSng(TxtTax4.Text)
        ._BOND = MyUtils.CnvSng(TxtBond.Text)
        ._CCRSN = TxtReason.Text
        ._BALD = MyUtils.CnvSng(LblTaxT.Text) - ._PAYREC
      End With

   End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtName, "")
    ErrProv.SetError(TxtReason, "")
    ErrProv.SetError(LblTaxT, "")
    ErrProv.SetError(LblPrevBilled, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
      Case "name"
        ErrProv.SetError(TxtName, ErrorMsg(I))
      Case "rsncd"
        ErrProv.SetError(TxtReason, ErrorMsg(I))
      Case "cetax"
        ErrProv.SetError(LblTaxT, ErrorMsg(I))
      Case "prevbilled"
        ErrProv.SetError(LblPrevBilled, ErrorMsg(I))
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

    If TxtReason.Text = "" Then
      ErrorField(I) = "rsncd"
      ErrorMsg(I) = "Reason Code is required"
      I = I + 1
    End If

    WrkTip = Ttp1.GetToolTip(TxtReason)
    If Mid(WrkTip, 1, 1) = "*" Then
      ErrorField(I) = "rsncd"
      ErrorMsg(I) = "Invalid Reason Code"
      I = I + 1
    End If

    If GrpPrevBilled.Visible Then
      If MyUtils.CnvSng(LblPrevBilled.Text) < 0 Then
        ErrorField(I) = "prevbilled"
        ErrorMsg(I) = "Previously Billed cannot be negative"
        I = I + 1
      End If
    End If

  End Sub

   Private Sub FrmUB501C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmUB501.SbpScreen.Text = "UB501C"
    MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmUB501
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub TxtTax1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTax1.TextChanged
    If Not TxtTax1.Modified Then Exit Sub
    CalcChg()
    CalcPrevBilled()
  End Sub
  Private Sub TxtTax2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTax2.TextChanged
    If Not TxtTax2.Modified Then Exit Sub
    CalcChg()
    CalcPrevBilled()
  End Sub
  Private Sub TxtTax3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTax3.TextChanged
    If Not TxtTax3.Modified Then Exit Sub
    CalcChg()
    CalcPrevBilled()
  End Sub
  Private Sub TxtTax4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTax4.TextChanged
    If Not TxtTax4.Modified Then Exit Sub
    CalcChg()
    CalcPrevBilled()
  End Sub
  Private Sub TxtBond_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBond.TextChanged
    If Not TxtBond.Modified Then Exit Sub
    CalcChg()
  End Sub
  Public Sub GetUTCOEA()

      With myUTCOEA
        LblListNo.Text = ._LISTNO
        LblYear.Text = ._YEAR
        LblType.Text = ._TYPE
        WrkListNo = ._LISTNO
        WrkYear = ._YEAR
        WrkType = ._TYPE
        LblCCDate.Text = MyUtils.GetDBDate(._CDATE)
        WrkCCDate = MyUtils.GetDBDate(._CDATE)
        TxtName.Text = Trim(._NAME)
        TxtTax1.Text = ._CETAX1
        TxtTax2.Text = ._CETAX2
        TxtTax3.Text = ._CETAX3
        TxtTax4.Text = ._CETAX4
        LblTaxT.Text = ._CETAX
        TxtBond.Text = ._CNBOND
        LblOrigBond.Text = ._COBOND
        TxtReason.Text = Trim(._RSNCD)
        TxtDesc.Text = Trim(._CDESC)
      End With

End Sub

  Public Sub GetOrigUTCOEA(ByVal WrkCCNo As Integer)
    Dim myOrigCOEA As UTCOEA.myData

    myOrigCOEA = New UTCOEA.mydata(MyDBConnect)
    myOrigCOEA.GetOneRecordP(WrkCCNo)
    If Not myOrigCOEA.RecordNotFound Then
    With myOrigCOEA
      LblOrig.Text = "Adj " & Str$(WrkCCNo)
      LblOrigTax1.Text = FormatNumber(._CETAX1, 2)
      LblOrigTax2.Text = FormatNumber(._CETAX2, 2)
      LblOrigTax3.Text = FormatNumber(._CETAX3, 2)
      LblOrigTax4.Text = FormatNumber(._CETAX4, 2)
      LblOrigTaxT.Text = FormatNumber(._CETAX, 2)
      LblOrigBond.Text = FormatNumber(._CNBOND, 2)
    End With
    End If
End Sub
Private Sub CalcChg()
  Dim WrkTaxT As Double
  If LoadScrn Then Exit Sub

  LblChgTax1.Text = FormatNumber(MyUtils.CnvSng(TxtTax1.Text) - MyUtils.CnvSng(LblOrigTax1.Text), 2)
  LblChgTax2.Text = FormatNumber(MyUtils.CnvSng(TxtTax2.Text) - MyUtils.CnvSng(LblOrigTax2.Text), 2)
  LblChgTax3.Text = FormatNumber(MyUtils.CnvSng(TxtTax3.Text) - MyUtils.CnvSng(LblOrigTax3.Text), 2)
  LblChgTax4.Text = FormatNumber(MyUtils.CnvSng(TxtTax4.Text) - MyUtils.CnvSng(LblOrigTax4.Text), 2)
  WrkTaxT = MyUtils.CnvSng(TxtTax1.Text) + MyUtils.CnvSng(TxtTax2.Text) + _
    MyUtils.CnvSng(TxtTax3.Text) + MyUtils.CnvSng(TxtTax4.Text)
  LblTaxT.Text = FormatNumber(WrkTaxT, 2)
  LblChgTaxT.Text = FormatNumber(MyUtils.CnvSng(LblTaxT.Text) - MyUtils.CnvSng(LblOrigTaxT.Text), 2)
  LblChgBond.Text = FormatNumber(MyUtils.CnvSng(TxtBond.Text) - MyUtils.CnvSng(LblOrigBond.Text), 2)
End Sub
Private Sub CalcPrevBilled()
  If WrkUBType = "A" Or WrkUBType = "B" Then
    LblOrigPrevBilled.Text = FormatNumber(WrkOrigBill - WrkAssmntLeft, 2)
    LblChgPrevBilled.Text = FormatNumber(MyUtils.CnvSng(LblTaxT.Text) - WrkPrevAmt, 2)
    LblPrevBilled.Text = FormatNumber(MyUtils.CnvSng(LblOrigPrevBilled.Text) + _
      MyUtils.CnvSng(LblChgPrevBilled.Text), 2)
  End If
End Sub
  Private Sub LnkReason_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkReason.LinkClicked
    MyFrmListCResn = New FrmListCResn
    MyFrmListCResn.MdiParent = Me.ParentForm
    MyFrmListCResn.WrkCode = TxtReason.Text
    MyFrmListCResn.Show()
  End Sub
Private Sub SetCResnTip()
    Dim WrkDesc As String

    If Not TxtReason.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetUTCRESNDesc(TxtReason.Text)
    Ttp1.SetToolTip(TxtReason, WrkDesc)
End Sub
Public Sub SetValidPayments()
  TxtTax2.Enabled = True
  TxtTax3.Enabled = True
  TxtTax4.Enabled = True
  With myTXPROF
    .GetOneRecordP(WrkType, WrkYear, "", MyUtils.CnvSng(TxtDist.Text))
    Select Case ._PRPERD
    Case 1
      TxtTax2.Enabled = False
      TxtTax3.Enabled = False
      TxtTax4.Enabled = False
    Case 2
      TxtTax3.Enabled = False
      TxtTax4.Enabled = False
    End Select
  End With
End Sub
Private Sub TxtTax1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTax1.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtTax2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTax2.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtTax3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTax3.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtTax4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTax4.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtBond_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBond.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtReason_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
  SetCResnTip()
End Sub
  Private Sub CalcAssmnt()
    Dim MyUBCalcBill As UBCalcBill.BillAssessment

    MyUBCalcBill = New UBCalcBill.BillAssessment(myDBConnect)

    WrkAssmntLeft = 0

    myUTCUST.GetOneRecordP(WrkListNo)
    If myUTCUST.RecordNotFound Then Exit Sub

    With MyUBCalcBill
      .In_RateType = WrkType
      .In_RateCode = WrkCode
      .In_DwellUnits = myUTCUST._CUAUNT
      .In_PropVal = myUTCUST._CUPVAL
      .In_Footage = myUTCUST._CUFOOT
      .In_Acreage = myUTCUST._CUACRE
      .In_LateralFee = myUTCUSTAS._CALAT
      .In_UniformFee = myUTCUSTAS._CAUNIF
      .In_AssmntAdjust = myUTCUSTAS._CAADJ
      .In_DeferredAmt = myUTCUSTAS._CADEF
      .In_PrevBilled = myUTCUSTAS._CAAMT
      .CalcAssessment()
      WrkOrigBill = .Out_OrigBill
      WrkAssmntLeft = .Out_AmtLeft
    End With

  End Sub
  Private Sub UpdateCUSTAS()
    Dim Diff As Decimal

    myUTCUSTAS.GetOneRecordP(WrkListNo, WrkType)
    If myUTCUSTAS.RecordNotFound Then Exit Sub

    Diff = MyUtils.CnvSng(LblChgPrevBilled.Text)
    With myUTCUSTAS
      ._CAAMT = ._CAAMT + Diff
      .UpdateOneRecordP()
    End With
End Sub
Private Function GetRateCode(ByVal WrkType As String) As String
	GetRateCode = ""
	myUTCUSTRT.GetOneRecordP(WrkListNo, WrkType)
	If myUTCUSTRT.RecordNotFound Then Exit Function

	With myUTCUSTRT
		GetRateCode = ._CRCODE
	End With
End Function
Private Sub TxtDist_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDist.KeyPress
  SetValidPayments()
End Sub
End Class






