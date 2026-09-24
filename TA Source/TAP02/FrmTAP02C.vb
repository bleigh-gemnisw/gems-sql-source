Public Class FrmTAP02C
  Inherits System.Windows.Forms.Form
  Dim MyTXDMPP As TXDMPP.myData
  Dim MyTXPPRP As TXPPRP.myData
  Dim AddMode As Boolean
  Dim LoadScrn As Boolean
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer

  Friend WithEvents Label51 As System.Windows.Forms.Label
  Friend WithEvents DtPckRecv As System.Windows.Forms.DateTimePicker
  Friend WithEvents LnkListNo As System.Windows.Forms.LinkLabel
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents TxtZip4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtZip5 As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents TxtAddr As System.Windows.Forms.TextBox
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents TxtBZip4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtBZip5 As System.Windows.Forms.TextBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents TxtBCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtBState As System.Windows.Forms.TextBox
  Friend WithEvents TxtBAddr As System.Windows.Forms.TextBox
  Friend WithEvents TxtBName As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtCFax As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TxtCTitle As System.Windows.Forms.TextBox
  Friend WithEvents TxtCName As System.Windows.Forms.TextBox
  Friend WithEvents TxtCPhone As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtRZip4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtRZip5 As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtRCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtRState As System.Windows.Forms.TextBox
  Friend WithEvents TxtRAddr As System.Windows.Forms.TextBox
  Friend WithEvents TxtRName As System.Windows.Forms.TextBox
  Friend WithEvents ChkExempt As System.Windows.Forms.CheckBox
  Friend WithEvents ChkRcvBen As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents TxtFedID As System.Windows.Forms.TextBox
  Friend WithEvents TxtCTID As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtLZip4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtLZip5 As System.Windows.Forms.TextBox
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents TxtLCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtLState As System.Windows.Forms.TextBox
  Friend WithEvents ChkG1Mfg As System.Windows.Forms.CheckBox
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents TxtBusAct As System.Windows.Forms.TextBox
  Friend WithEvents ChkG5Meas As System.Windows.Forms.CheckBox
  Friend WithEvents ChkG4Prod As System.Windows.Forms.CheckBox
  Friend WithEvents ChkG3Mach As System.Windows.Forms.CheckBox
  Friend WithEvents ChkG2Res As System.Windows.Forms.CheckBox
  Friend WithEvents ChkG9Rec As System.Windows.Forms.CheckBox
  Friend WithEvents ChkG8Bio As System.Windows.Forms.CheckBox
  Friend WithEvents ChkG7Mov As System.Windows.Forms.CheckBox
  Friend WithEvents ChkG6Met As System.Windows.Forms.CheckBox
  Friend WithEvents TxtLoc As System.Windows.Forms.TextBox
  Friend WithEvents TxtLocNo As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents DtPckSigned As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents TxtSigned As System.Windows.Forms.TextBox
  Friend WithEvents LblYear As System.Windows.Forms.Label
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
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.Label51 = New System.Windows.Forms.Label()
    Me.DtPckRecv = New System.Windows.Forms.DateTimePicker()
    Me.LnkListNo = New System.Windows.Forms.LinkLabel()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.TxtAddr = New System.Windows.Forms.TextBox()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtZip5 = New System.Windows.Forms.TextBox()
    Me.TxtZip4 = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtRZip4 = New System.Windows.Forms.TextBox()
    Me.TxtRZip5 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtRCity = New System.Windows.Forms.TextBox()
    Me.TxtRState = New System.Windows.Forms.TextBox()
    Me.TxtRAddr = New System.Windows.Forms.TextBox()
    Me.TxtRName = New System.Windows.Forms.TextBox()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.TxtCFax = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtCTitle = New System.Windows.Forms.TextBox()
    Me.TxtCName = New System.Windows.Forms.TextBox()
    Me.TxtCPhone = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.ChkExempt = New System.Windows.Forms.CheckBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TxtBZip4 = New System.Windows.Forms.TextBox()
    Me.TxtBZip5 = New System.Windows.Forms.TextBox()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.TxtBCity = New System.Windows.Forms.TextBox()
    Me.TxtBState = New System.Windows.Forms.TextBox()
    Me.TxtBAddr = New System.Windows.Forms.TextBox()
    Me.TxtBName = New System.Windows.Forms.TextBox()
    Me.ChkRcvBen = New System.Windows.Forms.CheckBox()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TxtFedID = New System.Windows.Forms.TextBox()
    Me.TxtCTID = New System.Windows.Forms.TextBox()
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.TxtLoc = New System.Windows.Forms.TextBox()
    Me.TxtLocNo = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtLZip4 = New System.Windows.Forms.TextBox()
    Me.TxtLZip5 = New System.Windows.Forms.TextBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.TxtLCity = New System.Windows.Forms.TextBox()
    Me.TxtLState = New System.Windows.Forms.TextBox()
    Me.ChkG1Mfg = New System.Windows.Forms.CheckBox()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.TxtBusAct = New System.Windows.Forms.TextBox()
    Me.ChkG2Res = New System.Windows.Forms.CheckBox()
    Me.ChkG3Mach = New System.Windows.Forms.CheckBox()
    Me.ChkG4Prod = New System.Windows.Forms.CheckBox()
    Me.ChkG5Meas = New System.Windows.Forms.CheckBox()
    Me.ChkG6Met = New System.Windows.Forms.CheckBox()
    Me.ChkG7Mov = New System.Windows.Forms.CheckBox()
    Me.ChkG8Bio = New System.Windows.Forms.CheckBox()
    Me.ChkG9Rec = New System.Windows.Forms.CheckBox()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.TxtSigned = New System.Windows.Forms.TextBox()
    Me.DtPckSigned = New System.Windows.Forms.DateTimePicker()
    Me.LblYear = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.GroupBox6.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
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
    'DtPckRecv
    '
    Me.DtPckRecv.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckRecv.Location = New System.Drawing.Point(375, 6)
    Me.DtPckRecv.Name = "DtPckRecv"
    Me.DtPckRecv.Size = New System.Drawing.Size(88, 20)
    Me.DtPckRecv.TabIndex = 2
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
    Me.Label13.Location = New System.Drawing.Point(172, 9)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(35, 17)
    Me.Label13.TabIndex = 205
    Me.Label13.Text = "Year"
    '
    'TxtListNo
    '
    Me.TxtListNo.Location = New System.Drawing.Point(100, 9)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(66, 20)
    Me.TxtListNo.TabIndex = 0
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(96, 23)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(280, 20)
    Me.TxtName.TabIndex = 226
    '
    'TxtAddr
    '
    Me.TxtAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAddr.Location = New System.Drawing.Point(96, 47)
    Me.TxtAddr.MaxLength = 35
    Me.TxtAddr.Name = "TxtAddr"
    Me.TxtAddr.Size = New System.Drawing.Size(280, 20)
    Me.TxtAddr.TabIndex = 227
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(339, 71)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 20)
    Me.TxtState.TabIndex = 229
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(96, 71)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(232, 20)
    Me.TxtCity.TabIndex = 228
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(6, 26)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(80, 16)
    Me.Label3.TabIndex = 236
    Me.Label3.Text = "Name"
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(6, 75)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(80, 16)
    Me.Label4.TabIndex = 237
    Me.Label4.Text = "City/State/Zip"
    '
    'TxtZip5
    '
    Me.TxtZip5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip5.Location = New System.Drawing.Point(371, 71)
    Me.TxtZip5.MaxLength = 5
    Me.TxtZip5.Name = "TxtZip5"
    Me.TxtZip5.Size = New System.Drawing.Size(40, 20)
    Me.TxtZip5.TabIndex = 230
    '
    'TxtZip4
    '
    Me.TxtZip4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip4.Location = New System.Drawing.Point(419, 71)
    Me.TxtZip4.MaxLength = 4
    Me.TxtZip4.Name = "TxtZip4"
    Me.TxtZip4.Size = New System.Drawing.Size(32, 20)
    Me.TxtZip4.TabIndex = 231
    '
    'Label15
    '
    Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label15.Location = New System.Drawing.Point(6, 51)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(80, 16)
    Me.Label15.TabIndex = 240
    Me.Label15.Text = "Address"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.Label15)
    Me.GroupBox1.Controls.Add(Me.TxtZip4)
    Me.GroupBox1.Controls.Add(Me.TxtZip5)
    Me.GroupBox1.Controls.Add(Me.Label4)
    Me.GroupBox1.Controls.Add(Me.Label3)
    Me.GroupBox1.Controls.Add(Me.TxtCity)
    Me.GroupBox1.Controls.Add(Me.TxtState)
    Me.GroupBox1.Controls.Add(Me.TxtAddr)
    Me.GroupBox1.Controls.Add(Me.TxtName)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(12, 35)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(469, 100)
    Me.GroupBox1.TabIndex = 3
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Manufacturing or Lessee Information"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.Label1)
    Me.GroupBox2.Controls.Add(Me.TxtRZip4)
    Me.GroupBox2.Controls.Add(Me.TxtRZip5)
    Me.GroupBox2.Controls.Add(Me.Label2)
    Me.GroupBox2.Controls.Add(Me.Label6)
    Me.GroupBox2.Controls.Add(Me.TxtRCity)
    Me.GroupBox2.Controls.Add(Me.TxtRState)
    Me.GroupBox2.Controls.Add(Me.TxtRAddr)
    Me.GroupBox2.Controls.Add(Me.TxtRName)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(488, 35)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(469, 100)
    Me.GroupBox2.TabIndex = 4
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Lessor Information"
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(6, 51)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(80, 16)
    Me.Label1.TabIndex = 240
    Me.Label1.Text = "Address"
    '
    'TxtRZip4
    '
    Me.TxtRZip4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRZip4.Location = New System.Drawing.Point(419, 71)
    Me.TxtRZip4.MaxLength = 4
    Me.TxtRZip4.Name = "TxtRZip4"
    Me.TxtRZip4.Size = New System.Drawing.Size(32, 20)
    Me.TxtRZip4.TabIndex = 231
    '
    'TxtRZip5
    '
    Me.TxtRZip5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRZip5.Location = New System.Drawing.Point(371, 71)
    Me.TxtRZip5.MaxLength = 5
    Me.TxtRZip5.Name = "TxtRZip5"
    Me.TxtRZip5.Size = New System.Drawing.Size(40, 20)
    Me.TxtRZip5.TabIndex = 230
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(6, 75)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(80, 16)
    Me.Label2.TabIndex = 237
    Me.Label2.Text = "City/State/Zip"
    '
    'Label6
    '
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(6, 26)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(80, 16)
    Me.Label6.TabIndex = 236
    Me.Label6.Text = "Name"
    '
    'TxtRCity
    '
    Me.TxtRCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRCity.Location = New System.Drawing.Point(96, 71)
    Me.TxtRCity.MaxLength = 25
    Me.TxtRCity.Name = "TxtRCity"
    Me.TxtRCity.Size = New System.Drawing.Size(232, 20)
    Me.TxtRCity.TabIndex = 228
    '
    'TxtRState
    '
    Me.TxtRState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRState.Location = New System.Drawing.Point(339, 71)
    Me.TxtRState.MaxLength = 2
    Me.TxtRState.Name = "TxtRState"
    Me.TxtRState.Size = New System.Drawing.Size(24, 20)
    Me.TxtRState.TabIndex = 229
    '
    'TxtRAddr
    '
    Me.TxtRAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRAddr.Location = New System.Drawing.Point(96, 47)
    Me.TxtRAddr.MaxLength = 35
    Me.TxtRAddr.Name = "TxtRAddr"
    Me.TxtRAddr.Size = New System.Drawing.Size(280, 20)
    Me.TxtRAddr.TabIndex = 227
    '
    'TxtRName
    '
    Me.TxtRName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRName.Location = New System.Drawing.Point(96, 23)
    Me.TxtRName.MaxLength = 35
    Me.TxtRName.Name = "TxtRName"
    Me.TxtRName.Size = New System.Drawing.Size(280, 20)
    Me.TxtRName.TabIndex = 226
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.TxtCFax)
    Me.GroupBox3.Controls.Add(Me.Label8)
    Me.GroupBox3.Controls.Add(Me.Label10)
    Me.GroupBox3.Controls.Add(Me.TxtCTitle)
    Me.GroupBox3.Controls.Add(Me.TxtCName)
    Me.GroupBox3.Controls.Add(Me.TxtCPhone)
    Me.GroupBox3.Controls.Add(Me.Label11)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(488, 141)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(469, 100)
    Me.GroupBox3.TabIndex = 5
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Contact person"
    '
    'TxtCFax
    '
    Me.TxtCFax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCFax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCFax.Location = New System.Drawing.Point(202, 71)
    Me.TxtCFax.MaxLength = 10
    Me.TxtCFax.Name = "TxtCFax"
    Me.TxtCFax.Size = New System.Drawing.Size(98, 20)
    Me.TxtCFax.TabIndex = 233
    '
    'Label8
    '
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(6, 51)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(80, 16)
    Me.Label8.TabIndex = 240
    Me.Label8.Text = "Title"
    '
    'Label10
    '
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(6, 26)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(80, 16)
    Me.Label10.TabIndex = 236
    Me.Label10.Text = "Name"
    '
    'TxtCTitle
    '
    Me.TxtCTitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCTitle.Location = New System.Drawing.Point(96, 47)
    Me.TxtCTitle.MaxLength = 25
    Me.TxtCTitle.Name = "TxtCTitle"
    Me.TxtCTitle.Size = New System.Drawing.Size(204, 20)
    Me.TxtCTitle.TabIndex = 227
    '
    'TxtCName
    '
    Me.TxtCName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCName.Location = New System.Drawing.Point(96, 23)
    Me.TxtCName.MaxLength = 35
    Me.TxtCName.Name = "TxtCName"
    Me.TxtCName.Size = New System.Drawing.Size(280, 20)
    Me.TxtCName.TabIndex = 226
    '
    'TxtCPhone
    '
    Me.TxtCPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCPhone.Location = New System.Drawing.Point(96, 72)
    Me.TxtCPhone.MaxLength = 10
    Me.TxtCPhone.Name = "TxtCPhone"
    Me.TxtCPhone.Size = New System.Drawing.Size(100, 20)
    Me.TxtCPhone.TabIndex = 232
    '
    'Label11
    '
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.Location = New System.Drawing.Point(6, 75)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(80, 16)
    Me.Label11.TabIndex = 235
    Me.Label11.Text = "Phone/Fax"
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.ChkExempt)
    Me.GroupBox4.Controls.Add(Me.Label12)
    Me.GroupBox4.Controls.Add(Me.TxtBZip4)
    Me.GroupBox4.Controls.Add(Me.TxtBZip5)
    Me.GroupBox4.Controls.Add(Me.Label14)
    Me.GroupBox4.Controls.Add(Me.Label16)
    Me.GroupBox4.Controls.Add(Me.TxtBCity)
    Me.GroupBox4.Controls.Add(Me.TxtBState)
    Me.GroupBox4.Controls.Add(Me.TxtBAddr)
    Me.GroupBox4.Controls.Add(Me.TxtBName)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(489, 270)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(459, 127)
    Me.GroupBox4.TabIndex = 9
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Exempt Status"
    '
    'ChkExempt
    '
    Me.ChkExempt.AutoSize = True
    Me.ChkExempt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkExempt.Checked = True
    Me.ChkExempt.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkExempt.Location = New System.Drawing.Point(16, 19)
    Me.ChkExempt.Name = "ChkExempt"
    Me.ChkExempt.Size = New System.Drawing.Size(350, 17)
    Me.ChkExempt.TabIndex = 241
    Me.ChkExempt.Text = "Is Machinery && Equipment exempt status depreciable on your books?"
    Me.ChkExempt.UseVisualStyleBackColor = True
    '
    'Label12
    '
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(9, 78)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(80, 16)
    Me.Label12.TabIndex = 240
    Me.Label12.Text = "Address"
    '
    'TxtBZip4
    '
    Me.TxtBZip4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBZip4.Location = New System.Drawing.Point(422, 98)
    Me.TxtBZip4.MaxLength = 4
    Me.TxtBZip4.Name = "TxtBZip4"
    Me.TxtBZip4.Size = New System.Drawing.Size(32, 20)
    Me.TxtBZip4.TabIndex = 231
    '
    'TxtBZip5
    '
    Me.TxtBZip5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBZip5.Location = New System.Drawing.Point(374, 98)
    Me.TxtBZip5.MaxLength = 5
    Me.TxtBZip5.Name = "TxtBZip5"
    Me.TxtBZip5.Size = New System.Drawing.Size(40, 20)
    Me.TxtBZip5.TabIndex = 230
    '
    'Label14
    '
    Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label14.Location = New System.Drawing.Point(9, 102)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(80, 16)
    Me.Label14.TabIndex = 237
    Me.Label14.Text = "City/State/Zip"
    '
    'Label16
    '
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.Location = New System.Drawing.Point(9, 53)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(80, 16)
    Me.Label16.TabIndex = 236
    Me.Label16.Text = "Name"
    '
    'TxtBCity
    '
    Me.TxtBCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBCity.Location = New System.Drawing.Point(99, 98)
    Me.TxtBCity.MaxLength = 25
    Me.TxtBCity.Name = "TxtBCity"
    Me.TxtBCity.Size = New System.Drawing.Size(232, 20)
    Me.TxtBCity.TabIndex = 228
    '
    'TxtBState
    '
    Me.TxtBState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBState.Location = New System.Drawing.Point(342, 98)
    Me.TxtBState.MaxLength = 2
    Me.TxtBState.Name = "TxtBState"
    Me.TxtBState.Size = New System.Drawing.Size(24, 20)
    Me.TxtBState.TabIndex = 229
    '
    'TxtBAddr
    '
    Me.TxtBAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBAddr.Location = New System.Drawing.Point(99, 74)
    Me.TxtBAddr.MaxLength = 35
    Me.TxtBAddr.Name = "TxtBAddr"
    Me.TxtBAddr.Size = New System.Drawing.Size(280, 20)
    Me.TxtBAddr.TabIndex = 227
    '
    'TxtBName
    '
    Me.TxtBName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBName.Location = New System.Drawing.Point(99, 50)
    Me.TxtBName.MaxLength = 35
    Me.TxtBName.Name = "TxtBName"
    Me.TxtBName.Size = New System.Drawing.Size(280, 20)
    Me.TxtBName.TabIndex = 226
    '
    'ChkRcvBen
    '
    Me.ChkRcvBen.AutoSize = True
    Me.ChkRcvBen.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkRcvBen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkRcvBen.Location = New System.Drawing.Point(489, 247)
    Me.ChkRcvBen.Name = "ChkRcvBen"
    Me.ChkRcvBen.Size = New System.Drawing.Size(361, 17)
    Me.ChkRcvBen.TabIndex = 8
    Me.ChkRcvBen.Text = "Are you receiving benefits under CGS 12-81 or Distressed Municipality?"
    Me.ChkRcvBen.UseVisualStyleBackColor = True
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.Label5)
    Me.GroupBox5.Controls.Add(Me.Label9)
    Me.GroupBox5.Controls.Add(Me.TxtFedID)
    Me.GroupBox5.Controls.Add(Me.TxtCTID)
    Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox5.Location = New System.Drawing.Point(12, 141)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(469, 79)
    Me.GroupBox5.TabIndex = 6
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "Required Identification Numbers"
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(6, 51)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(148, 17)
    Me.Label5.TabIndex = 240
    Me.Label5.Text = "Federal Taxpayer ID No"
    '
    'Label9
    '
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(6, 26)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(148, 18)
    Me.Label9.TabIndex = 236
    Me.Label9.Text = "Connecticut State Tax ID No"
    '
    'TxtFedID
    '
    Me.TxtFedID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFedID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFedID.Location = New System.Drawing.Point(165, 47)
    Me.TxtFedID.MaxLength = 10
    Me.TxtFedID.Name = "TxtFedID"
    Me.TxtFedID.Size = New System.Drawing.Size(128, 20)
    Me.TxtFedID.TabIndex = 227
    '
    'TxtCTID
    '
    Me.TxtCTID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCTID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCTID.Location = New System.Drawing.Point(165, 23)
    Me.TxtCTID.MaxLength = 10
    Me.TxtCTID.Name = "TxtCTID"
    Me.TxtCTID.Size = New System.Drawing.Size(128, 20)
    Me.TxtCTID.TabIndex = 226
    '
    'GroupBox6
    '
    Me.GroupBox6.Controls.Add(Me.TxtLoc)
    Me.GroupBox6.Controls.Add(Me.TxtLocNo)
    Me.GroupBox6.Controls.Add(Me.Label7)
    Me.GroupBox6.Controls.Add(Me.TxtLZip4)
    Me.GroupBox6.Controls.Add(Me.TxtLZip5)
    Me.GroupBox6.Controls.Add(Me.Label17)
    Me.GroupBox6.Controls.Add(Me.TxtLCity)
    Me.GroupBox6.Controls.Add(Me.TxtLState)
    Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox6.Location = New System.Drawing.Point(12, 226)
    Me.GroupBox6.Name = "GroupBox6"
    Me.GroupBox6.Size = New System.Drawing.Size(469, 69)
    Me.GroupBox6.TabIndex = 7
    Me.GroupBox6.TabStop = False
    Me.GroupBox6.Text = "Property Location"
    '
    'TxtLoc
    '
    Me.TxtLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLoc.Location = New System.Drawing.Point(152, 16)
    Me.TxtLoc.MaxLength = 25
    Me.TxtLoc.Name = "TxtLoc"
    Me.TxtLoc.Size = New System.Drawing.Size(200, 20)
    Me.TxtLoc.TabIndex = 239
    '
    'TxtLocNo
    '
    Me.TxtLocNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLocNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocNo.Location = New System.Drawing.Point(97, 16)
    Me.TxtLocNo.MaxLength = 7
    Me.TxtLocNo.Name = "TxtLocNo"
    Me.TxtLocNo.Size = New System.Drawing.Size(49, 20)
    Me.TxtLocNo.TabIndex = 238
    Me.TxtLocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label7
    '
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(6, 19)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(88, 16)
    Me.Label7.TabIndex = 240
    Me.Label7.Text = "Location#/Name"
    '
    'TxtLZip4
    '
    Me.TxtLZip4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLZip4.Location = New System.Drawing.Point(419, 42)
    Me.TxtLZip4.MaxLength = 4
    Me.TxtLZip4.Name = "TxtLZip4"
    Me.TxtLZip4.Size = New System.Drawing.Size(32, 20)
    Me.TxtLZip4.TabIndex = 231
    '
    'TxtLZip5
    '
    Me.TxtLZip5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLZip5.Location = New System.Drawing.Point(371, 42)
    Me.TxtLZip5.MaxLength = 5
    Me.TxtLZip5.Name = "TxtLZip5"
    Me.TxtLZip5.Size = New System.Drawing.Size(40, 20)
    Me.TxtLZip5.TabIndex = 230
    '
    'Label17
    '
    Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label17.Location = New System.Drawing.Point(6, 46)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(80, 16)
    Me.Label17.TabIndex = 237
    Me.Label17.Text = "City/State/Zip"
    '
    'TxtLCity
    '
    Me.TxtLCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLCity.Location = New System.Drawing.Point(96, 42)
    Me.TxtLCity.MaxLength = 25
    Me.TxtLCity.Name = "TxtLCity"
    Me.TxtLCity.Size = New System.Drawing.Size(232, 20)
    Me.TxtLCity.TabIndex = 228
    '
    'TxtLState
    '
    Me.TxtLState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLState.Location = New System.Drawing.Point(339, 42)
    Me.TxtLState.MaxLength = 2
    Me.TxtLState.Name = "TxtLState"
    Me.TxtLState.Size = New System.Drawing.Size(24, 20)
    Me.TxtLState.TabIndex = 229
    '
    'ChkG1Mfg
    '
    Me.ChkG1Mfg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkG1Mfg.Location = New System.Drawing.Point(12, 301)
    Me.ChkG1Mfg.Name = "ChkG1Mfg"
    Me.ChkG1Mfg.Size = New System.Drawing.Size(328, 17)
    Me.ChkG1Mfg.TabIndex = 10
    Me.ChkG1Mfg.Text = "1. Manufacturing, processing or fabrication?"
    Me.ChkG1Mfg.UseVisualStyleBackColor = True
    '
    'Label18
    '
    Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label18.Location = New System.Drawing.Point(7, 487)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(95, 17)
    Me.Label18.TabIndex = 247
    Me.Label18.Text = "Business Activity"
    '
    'TxtBusAct
    '
    Me.TxtBusAct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBusAct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBusAct.Location = New System.Drawing.Point(108, 487)
    Me.TxtBusAct.MaxLength = 100
    Me.TxtBusAct.Name = "TxtBusAct"
    Me.TxtBusAct.Size = New System.Drawing.Size(849, 20)
    Me.TxtBusAct.TabIndex = 19
    '
    'ChkG2Res
    '
    Me.ChkG2Res.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkG2Res.Location = New System.Drawing.Point(12, 321)
    Me.ChkG2Res.Name = "ChkG2Res"
    Me.ChkG2Res.Size = New System.Drawing.Size(328, 17)
    Me.ChkG2Res.TabIndex = 11
    Me.ChkG2Res.Text = "2. Research and development?"
    Me.ChkG2Res.UseVisualStyleBackColor = True
    '
    'ChkG3Mach
    '
    Me.ChkG3Mach.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkG3Mach.Location = New System.Drawing.Point(12, 341)
    Me.ChkG3Mach.Name = "ChkG3Mach"
    Me.ChkG3Mach.Size = New System.Drawing.Size(328, 17)
    Me.ChkG3Mach.TabIndex = 12
    Me.ChkG3Mach.Text = "3. Servicing of Machinery && Equipment for industrial use?"
    Me.ChkG3Mach.UseVisualStyleBackColor = True
    '
    'ChkG4Prod
    '
    Me.ChkG4Prod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkG4Prod.Location = New System.Drawing.Point(12, 361)
    Me.ChkG4Prod.Name = "ChkG4Prod"
    Me.ChkG4Prod.Size = New System.Drawing.Size(328, 17)
    Me.ChkG4Prod.TabIndex = 13
    Me.ChkG4Prod.Text = "4. Overhauling or rebuilding of products?"
    Me.ChkG4Prod.UseVisualStyleBackColor = True
    '
    'ChkG5Meas
    '
    Me.ChkG5Meas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkG5Meas.Location = New System.Drawing.Point(12, 381)
    Me.ChkG5Meas.Name = "ChkG5Meas"
    Me.ChkG5Meas.Size = New System.Drawing.Size(328, 20)
    Me.ChkG5Meas.TabIndex = 14
    Me.ChkG5Meas.Text = "5. Measuring or testing?"
    Me.ChkG5Meas.UseVisualStyleBackColor = True
    '
    'ChkG6Met
    '
    Me.ChkG6Met.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkG6Met.Location = New System.Drawing.Point(12, 401)
    Me.ChkG6Met.Name = "ChkG6Met"
    Me.ChkG6Met.Size = New System.Drawing.Size(328, 20)
    Me.ChkG6Met.TabIndex = 15
    Me.ChkG6Met.Text = "6. Metal finishing?"
    Me.ChkG6Met.UseVisualStyleBackColor = True
    '
    'ChkG7Mov
    '
    Me.ChkG7Mov.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkG7Mov.Location = New System.Drawing.Point(12, 421)
    Me.ChkG7Mov.Name = "ChkG7Mov"
    Me.ChkG7Mov.Size = New System.Drawing.Size(328, 20)
    Me.ChkG7Mov.TabIndex = 16
    Me.ChkG7Mov.Text = "7. Production of motion pictures, video or sound recordings?"
    Me.ChkG7Mov.UseVisualStyleBackColor = True
    '
    'ChkG8Bio
    '
    Me.ChkG8Bio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkG8Bio.Location = New System.Drawing.Point(12, 441)
    Me.ChkG8Bio.Name = "ChkG8Bio"
    Me.ChkG8Bio.Size = New System.Drawing.Size(328, 20)
    Me.ChkG8Bio.TabIndex = 17
    Me.ChkG8Bio.Text = "8. Used with biotechnology?"
    Me.ChkG8Bio.UseVisualStyleBackColor = True
    '
    'ChkG9Rec
    '
    Me.ChkG9Rec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkG9Rec.Location = New System.Drawing.Point(12, 461)
    Me.ChkG9Rec.Name = "ChkG9Rec"
    Me.ChkG9Rec.Size = New System.Drawing.Size(328, 20)
    Me.ChkG9Rec.TabIndex = 18
    Me.ChkG9Rec.Text = "9. Used with recycling?"
    Me.ChkG9Rec.UseVisualStyleBackColor = True
    '
    'Label19
    '
    Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label19.Location = New System.Drawing.Point(485, 453)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(80, 16)
    Me.Label19.TabIndex = 249
    Me.Label19.Text = "Signed Name"
    '
    'TxtSigned
    '
    Me.TxtSigned.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSigned.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSigned.Location = New System.Drawing.Point(575, 450)
    Me.TxtSigned.MaxLength = 35
    Me.TxtSigned.Name = "TxtSigned"
    Me.TxtSigned.Size = New System.Drawing.Size(280, 20)
    Me.TxtSigned.TabIndex = 248
    '
    'DtPckSigned
    '
    Me.DtPckSigned.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckSigned.Location = New System.Drawing.Point(864, 450)
    Me.DtPckSigned.Name = "DtPckSigned"
    Me.DtPckSigned.Size = New System.Drawing.Size(88, 20)
    Me.DtPckSigned.TabIndex = 250
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblYear.Location = New System.Drawing.Point(213, 8)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(33, 18)
    Me.LblYear.TabIndex = 251
    Me.LblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'FrmTAP02C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(969, 515)
    Me.ControlBox = False
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.DtPckSigned)
    Me.Controls.Add(Me.Label19)
    Me.Controls.Add(Me.TxtSigned)
    Me.Controls.Add(Me.ChkG9Rec)
    Me.Controls.Add(Me.ChkG8Bio)
    Me.Controls.Add(Me.ChkG7Mov)
    Me.Controls.Add(Me.ChkG6Met)
    Me.Controls.Add(Me.ChkG5Meas)
    Me.Controls.Add(Me.ChkG4Prod)
    Me.Controls.Add(Me.ChkG3Mach)
    Me.Controls.Add(Me.ChkG2Res)
    Me.Controls.Add(Me.Label18)
    Me.Controls.Add(Me.TxtBusAct)
    Me.Controls.Add(Me.ChkG1Mfg)
    Me.Controls.Add(Me.GroupBox6)
    Me.Controls.Add(Me.GroupBox5)
    Me.Controls.Add(Me.ChkRcvBen)
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label51)
    Me.Controls.Add(Me.DtPckRecv)
    Me.Controls.Add(Me.LnkListNo)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.TxtListNo)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAP02C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Personal Property Declaration"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
    Me.GroupBox6.ResumeLayout(False)
    Me.GroupBox6.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

Private Sub FrmTAP02C_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP02
      .TbForms.Visible = False
      .TBarDecl.Enabled = True
      .TBarComments.Enabled = False
    End With
End Sub

  Private Sub FrmTAP02C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    MyTXDMPP = New TXDMPP.mydata(MyDBConnect)
    MyTXPPRP = New TXPPRP.mydata(MyDBConnect)

    LoadScrn = True
    TxtListNo.Focus()
    With MyFrmTAP02
      .TBarNew.Enabled = False
      .TBarSave.Enabled = True
      .TbForms.Visible = True
      .TBarDecl.Enabled = False
      .TBarComments.Enabled = True
    End With

    AddMode = False

    'Fill the dataset with the data
    If WrkListNo > 0 Then
      Me.Text = "Maintain " & Me.Text
      MyFrmTAP02.TBarDelete.Enabled = True
      MyFrmTAP02.TBarPrint.Enabled = False
      TxtListNo.Text = WrkListNo
      LnkListNo.Enabled = False
      TxtListNo.ReadOnly = True
      DtPckRecv.Value = Date.Today
      MyTXDMPP.GetOneRecordP(WrkListNo, WrkYear)
      If MyTXDMPP.RecordNotFound Then
         MyFrmTAP02.TBarNew.Enabled = False
         MyFrmTAP02.TBarSave.Enabled = False
         MyFrmTAP02.TBarDelete.Enabled = False
         Me.ErrProv.SetError(TxtListNo, "Record not found")
         Exit Sub
      End If

      With MyTXDMPP
        TxtListNo.Text = ._LISTNO
        LblYear.Text = ._YEAR
        TxtName.Text = Trim(._NAME)
        TxtAddr.Text = Trim(._ADDR)
        TxtCity.Text = Trim(._CITY)
        TxtState.Text = Trim(._STATE)
        If ._ZIP5 > 0 Then
          TxtZip5.Text = Format(._ZIP5, "00000")
        End If
        If ._ZIP4 > 0 Then
          TxtZip4.Text = Format(._ZIP4, "0000")
        End If
        TxtRName.Text = Trim(._RNAME)
        TxtRAddr.Text = Trim(._RADDR)
        TxtRCity.Text = Trim(._RCITY)
        TxtRState.Text = Trim(._RSTATE)
        If ._RZIP5 > 0 Then
          TxtRZip5.Text = Format(._RZIP5, "00000")
        End If
        If ._RZIP4 > 0 Then
          TxtRZip4.Text = Format(._RZIP4, "0000")
        End If
        TxtLocNo.Text = Trim(._LOCNO)
        TxtLoc.Text = Trim(._LOC)
        TxtLCity.Text = Trim(._LCITY)
        TxtLState.Text = Trim(._LSTATE)
        If ._LZIP5 > 0 Then
          TxtLZip5.Text = Format(._LZIP5, "00000")
        End If
        If ._LZIP4 > 0 Then
          TxtLZip4.Text = Format(._LZIP4, "0000")
        End If
        TxtCName.Text = Trim(._CNAME)
        TxtCTitle.Text = Trim(._CTITLE)
        If ._CPHONE > 0 Then
          TxtCPhone.Text = Trim(._CPHONE)
        End If
        If ._CFAX > 0 Then
          TxtCFax.Text = Trim(._CFAX)
        End If
        TxtCTID.Text = Trim(._CTID)
        TxtFedID.Text = Trim(._FEDID)
        If ._RCVBEN = "Y" Then
          ChkRcvBen.Checked = True
        End If
        If ._EXEMPT = "Y" Then
          ChkExempt.Checked = True
          ToggleExemptEnabled()
        Else
          ChkExempt.Checked = False
          TxtBName.Text = Trim(._BNAME)
          TxtBAddr.Text = Trim(._BADDR)
          TxtBCity.Text = Trim(._BCITY)
          TxtBState.Text = Trim(._BSTATE)
          If ._BZIP5 > 0 Then
            TxtBZip5.Text = Format(._BZIP5, "00000")
          End If
          If ._BZIP4 > 0 Then
            TxtBZip4.Text = Format(._BZIP4, "0000")
          End If
        End If
        If ._G1MFG = "Y" Then
          ChkG1Mfg.Checked = True
        End If
        If ._G2RES = "Y" Then
          ChkG2Res.Checked = True
        End If
        If ._G3MACH = "Y" Then
          ChkG3Mach.Checked = True
        End If
        If ._G4PROD = "Y" Then
          ChkG4Prod.Checked = True
        End If
        If ._G5MEAS = "Y" Then
          ChkG5Meas.Checked = True
        End If
        If ._G6MET = "Y" Then
          ChkG6Met.Checked = True
        End If
        If ._G7MOV = "Y" Then
          ChkG7Mov.Checked = True
        End If
        If ._G8BIO = "Y" Then
          ChkG8Bio.Checked = True
        End If
        If ._G9REC = "Y" Then
          ChkG9Rec.Checked = True
        End If
    TxtBusAct.Text = Trim(._BUSACT)
    If ._RECVDT > 0 Then
     DtPckRecv.Value = MyUtils.GetDBDate(._RECVDT)
    Else
     DtPckRecv.Value = Date.Today
    End If
    TxtSigned.Text = Trim(._SIGNED)
    If ._SIGNDT > 0 Then
     DtPckSigned.Value = MyUtils.GetDBDate(._SIGNDT)
    Else
     DtPckSigned.Value = Date.Today
    End If
   End With
    Else
      Me.Text = "Add " & Me.Text
      AddMode = True
      LblYear.Text = MyUtils.CnvSng(MyFrmTAP02B.TxtYear.Text)
      MyFrmTAP02.TBarDelete.Enabled = False
      MyFrmTAP02.TbForms.Visible = False
      MyFrmTAP02.TBarComments.Enabled = False
    End If

    LoadScrn = False
 End Sub

  Private Sub FrmTAP02C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTAP02.TBarNew.Enabled = True
    MyFrmTAP02.TBarSave.Enabled = False
    MyFrmTAP02.TBarDelete.Enabled = False
    MyFrmTAP02.TBarPrint.Enabled = False
    MyFrmTAP02B.FormatGrid()
    MyFrmTAP02B.Show()

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    DeleteListNo()
    MyTXDMPP.DeleteOneRecordP()
  End Sub
  Private Sub DeleteListNo()

  Dim MyTXDMLST As TXDMLST.myData
  Dim MyTXDMSUM As TXDMSUM.myData

  MyTXDMLST = New TXDMLST.mydata(MyDBConnect)
  MyTXDMSUM = New TXDMSUM.mydata(MyDBConnect)

  With MyTXDMLST
    .DeleteListNo(WrkListNo, WrkYear)
  End With

  With MyTXDMSUM
    .DeleteListNo(WrkListNo, WrkYear)
  End With
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    WrkYear = MyUtils.CnvSng(LblYear.Text)
    MyTXDMPP.GetOneRecordP(WrkListNo, WrkYear)
    If AddMode Then
      If Not MyTXDMPP.RecordNotFound Then
        Me.ErrProv.SetError(TxtListNo, "Record already exists")
        Exit Sub
      End If
    End If

    If Not AddMode Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXDMPP.UpdateOneRecordP()
        Me.Close()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXDMPP.AddOneRecordP()
        MyFrmTAP02.TbForms.Visible = True
        AddMode = False
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

  End Sub
   Private Sub MoveToFile()
      With MyTXDMPP
        ._LISTNO = MyUtils.CnvSng(TxtListNo.Text)
        ._YEAR = MyUtils.CnvSng(LblYear.Text)
        ._NAME = TxtName.Text
        ._ADDR = TxtAddr.Text
        ._CITY = TxtCity.Text
        ._STATE = TxtState.Text
        ._ZIP5 = MyUtils.CnvSng(TxtZip5.Text)
        ._ZIP4 = MyUtils.CnvSng(TxtZip4.Text)
        ._RNAME = TxtRName.Text
        ._RADDR = TxtRAddr.Text
        ._RCITY = TxtRCity.Text
        ._RSTATE = TxtRState.Text
        ._RZIP5 = MyUtils.CnvSng(TxtRZip5.Text)
        ._RZIP4 = MyUtils.CnvSng(TxtRZip4.Text)
        ._CNAME = TxtCName.Text
        ._CTITLE = TxtCTitle.Text
        ._CPHONE = MyUtils.CnvSng(TxtCPhone.Text)
        ._CFAX = MyUtils.CnvSng(TxtCFax.Text)
        ._CTID = TxtCTID.Text
        ._FEDID = TxtFedID.Text
        ._LOCNO = TxtLocNo.Text
        ._LOC = TxtLoc.Text
        ._LCITY = TxtLCity.Text
        ._LSTATE = TxtLState.Text
        ._LZIP5 = MyUtils.CnvSng(TxtLZip5.Text)
        ._LZIP4 = MyUtils.CnvSng(TxtLZip4.Text)
        If ChkRcvBen.Checked Then
          ._RCVBEN = "Y"
        Else
          ._RCVBEN = "N"
        End If
        If ChkExempt.Checked Then
          ._EXEMPT = "Y"
        Else
          ._EXEMPT = "N"
        End If
        ._BNAME = TxtBName.Text
        ._BADDR = TxtBAddr.Text
        ._BCITY = TxtBCity.Text
        ._BSTATE = TxtBState.Text
        ._BZIP5 = MyUtils.CnvSng(TxtBZip5.Text)
        ._BZIP4 = MyUtils.CnvSng(TxtBZip4.Text)
        If ChkG1Mfg.Checked Then
          ._G1MFG = "Y"
        Else
          ._G1MFG = "N"
        End If
        If ChkG2Res.Checked Then
          ._G2RES = "Y"
        Else
          ._G2RES = "N"
        End If
        If ChkG3Mach.Checked Then
          ._G3MACH = "Y"
        Else
          ._G3MACH = "N"
        End If
        If ChkG4Prod.Checked Then
          ._G4PROD = "Y"
        Else
          ._G4PROD = "N"
        End If
        If ChkG5Meas.Checked Then
          ._G5MEAS = "Y"
        Else
          ._G5MEAS = "N"
        End If
        If ChkG6Met.Checked Then
          ._G6MET = "Y"
        Else
          ._G6MET = "N"
        End If
        If ChkG7Mov.Checked Then
          ._G7MOV = "Y"
        Else
          ._G7MOV = "N"
        End If
        If ChkG8Bio.Checked Then
          ._G8BIO = "Y"
        Else
          ._G8BIO = "N"
        End If
        If ChkG9Rec.Checked Then
          ._G9REC = "Y"
        Else
          ._G9REC = "N"
        End If
        ._BUSACT = TxtBusAct.Text
        ._RECVDT = MyUtils.SetDBDate(DtPckRecv.Value)
        ._SIGNED = TxtSigned.Text
        ._SIGNDT = MyUtils.SetDBDate(DtPckSigned.Value)
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

    If TxtName.Text = String.Empty Then
      ErrorField(I) = "name"
      ErrorMsg(I) = "Name is required"
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
  Private Sub FrmTAP02C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP02.SbpScreen.Text = "TAP02C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub LnkListNo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkListNo.LinkClicked
    MyFrmListPPRP = New FrmListPPRP
    MyFrmListPPRP.MdiParent = Me.ParentForm
    MyFrmListPPRP.WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    MyFrmListPPRP.Show()
  End Sub
Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtListNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtListNo.LostFocus
  If TxtListNo.Modified Then
    GetTXPPRP()
  End If
End Sub
Public Sub GetTXPPRP()

MyTXPPRP.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text))
If MyTXPPRP.RecordNotFound Then Exit Sub

With MyTXPPRP
  TxtName.Text = Trim(._NAME)
  TxtAddr.Text = Trim(._ADD1)
  TxtCity.Text = Trim(._CITY)
  TxtState.Text = Trim(._STATE)
  TxtZip5.Text = Trim(._ZIP5)
  TxtZip4.Text = Trim(._ZIP4)
  TxtLocNo.Text = Trim(._LOCNO)
  TxtLoc.Text = Trim(._LOC)
End With

End Sub
Private Sub ToggleExemptEnabled()
    TxtBName.Enabled = Not TxtBName.Enabled
    TxtBAddr.Enabled = Not TxtBAddr.Enabled
    TxtBCity.Enabled = Not TxtBCity.Enabled
    TxtBState.Enabled = Not TxtBState.Enabled
    TxtBZip5.Enabled = Not TxtBZip5.Enabled
    TxtBZip4.Enabled = Not TxtBZip4.Enabled
End Sub
 Private Sub TxtZip5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZip5.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtZip4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZip4.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtRZip5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRZip5.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtRZip4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRZip4.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtBZip5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBZip5.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtBZip4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBZip4.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtCPhone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCPhone.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtCFax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCFax.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub ChkExempt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkExempt.Click
  ToggleExemptEnabled()
End Sub

Private Sub TxtBZip5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBZip5.TextChanged

End Sub
End Class






