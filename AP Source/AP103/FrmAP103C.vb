Public Class FrmAP103C
  Inherits System.Windows.Forms.Form
	Dim myAPEBNK As APEBNK.myData
	Dim myAPEBNC As APEBNC.myData
	Friend WrkCode As String
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpDetail As System.Windows.Forms.TabPage
  Friend WithEvents TpCheck As System.Windows.Forms.TabPage
  Friend WithEvents TxtSfund As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtFdnbr As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TxtBnkac As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtBchkn As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtSubfn As System.Windows.Forms.TextBox
  Friend WithEvents TxtFnpgm As System.Windows.Forms.TextBox
  Friend WithEvents TxtObnbr As System.Windows.Forms.TextBox
  Friend WithEvents TxtDpnbr As System.Windows.Forms.TextBox
  Friend WithEvents ChkPetch As System.Windows.Forms.CheckBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtAcdes1 As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents TxtAcdes3 As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents TxtAcdes2 As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtSig3 As System.Windows.Forms.TextBox
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents TxtSig2 As System.Windows.Forms.TextBox
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents TxtSig1 As System.Windows.Forms.TextBox
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtBndes3 As System.Windows.Forms.TextBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents TxtBndes2 As System.Windows.Forms.TextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents TxtBndes1 As System.Windows.Forms.TextBox
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents TxtFract2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtFract1 As System.Windows.Forms.TextBox
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents TxtRout As System.Windows.Forms.TextBox
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents RbMICR20 As System.Windows.Forms.RadioButton
	Friend WithEvents RbMICR6 As System.Windows.Forms.RadioButton
 Friend WithEvents RbMICR6ns As System.Windows.Forms.RadioButton
 Friend WithEvents RbMICR20Webster As System.Windows.Forms.RadioButton
 Dim WrkAddMode2 As Boolean

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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TxtBnkcd As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtBnknm As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.TxtBnkcd = New System.Windows.Forms.TextBox
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Label2 = New System.Windows.Forms.Label
Me.TxtBnknm = New System.Windows.Forms.TextBox
Me.TabControl1 = New System.Windows.Forms.TabControl
Me.TpDetail = New System.Windows.Forms.TabPage
Me.Label10 = New System.Windows.Forms.Label
Me.Label9 = New System.Windows.Forms.Label
Me.Label8 = New System.Windows.Forms.Label
Me.Label7 = New System.Windows.Forms.Label
Me.ChkPetch = New System.Windows.Forms.CheckBox
Me.TxtSubfn = New System.Windows.Forms.TextBox
Me.TxtFnpgm = New System.Windows.Forms.TextBox
Me.TxtObnbr = New System.Windows.Forms.TextBox
Me.TxtDpnbr = New System.Windows.Forms.TextBox
Me.TxtSfund = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
Me.TxtFdnbr = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.TxtBnkac = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.TxtBchkn = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.TpCheck = New System.Windows.Forms.TabPage
Me.RbMICR6ns = New System.Windows.Forms.RadioButton
Me.RbMICR6 = New System.Windows.Forms.RadioButton
Me.RbMICR20 = New System.Windows.Forms.RadioButton
Me.TxtRout = New System.Windows.Forms.TextBox
Me.Label22 = New System.Windows.Forms.Label
Me.Label21 = New System.Windows.Forms.Label
Me.TxtFract2 = New System.Windows.Forms.TextBox
Me.TxtFract1 = New System.Windows.Forms.TextBox
Me.Label20 = New System.Windows.Forms.Label
Me.GroupBox3 = New System.Windows.Forms.GroupBox
Me.TxtSig3 = New System.Windows.Forms.TextBox
Me.Label17 = New System.Windows.Forms.Label
Me.TxtSig2 = New System.Windows.Forms.TextBox
Me.Label18 = New System.Windows.Forms.Label
Me.TxtSig1 = New System.Windows.Forms.TextBox
Me.Label19 = New System.Windows.Forms.Label
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.TxtBndes3 = New System.Windows.Forms.TextBox
Me.Label14 = New System.Windows.Forms.Label
Me.TxtBndes2 = New System.Windows.Forms.TextBox
Me.Label15 = New System.Windows.Forms.Label
Me.TxtBndes1 = New System.Windows.Forms.TextBox
Me.Label16 = New System.Windows.Forms.Label
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.TxtAcdes3 = New System.Windows.Forms.TextBox
Me.Label13 = New System.Windows.Forms.Label
Me.TxtAcdes2 = New System.Windows.Forms.TextBox
Me.Label12 = New System.Windows.Forms.Label
Me.TxtAcdes1 = New System.Windows.Forms.TextBox
Me.Label11 = New System.Windows.Forms.Label
Me.RbMICR20Webster = New System.Windows.Forms.RadioButton
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.TabControl1.SuspendLayout()
Me.TpDetail.SuspendLayout()
Me.TpCheck.SuspendLayout()
Me.GroupBox3.SuspendLayout()
Me.GroupBox2.SuspendLayout()
Me.GroupBox1.SuspendLayout()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 12)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(68, 16)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Bank Code"
'
'TxtBnkcd
'
Me.TxtBnkcd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtBnkcd.Location = New System.Drawing.Point(76, 8)
Me.TxtBnkcd.MaxLength = 5
Me.TxtBnkcd.Name = "TxtBnkcd"
Me.TxtBnkcd.Size = New System.Drawing.Size(44, 20)
Me.TxtBnkcd.TabIndex = 0
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(8, 34)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(68, 19)
Me.Label2.TabIndex = 28
Me.Label2.Text = "Bank Name"
Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TxtBnknm
'
Me.TxtBnknm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtBnknm.Location = New System.Drawing.Point(76, 34)
Me.TxtBnknm.MaxLength = 30
Me.TxtBnknm.Name = "TxtBnknm"
Me.TxtBnknm.Size = New System.Drawing.Size(225, 20)
Me.TxtBnknm.TabIndex = 1
'
'TabControl1
'
Me.TabControl1.Controls.Add(Me.TpDetail)
Me.TabControl1.Controls.Add(Me.TpCheck)
Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TabControl1.Location = New System.Drawing.Point(11, 70)
Me.TabControl1.Name = "TabControl1"
Me.TabControl1.SelectedIndex = 0
Me.TabControl1.Size = New System.Drawing.Size(382, 415)
Me.TabControl1.TabIndex = 2
'
'TpDetail
'
Me.TpDetail.Controls.Add(Me.Label10)
Me.TpDetail.Controls.Add(Me.Label9)
Me.TpDetail.Controls.Add(Me.Label8)
Me.TpDetail.Controls.Add(Me.Label7)
Me.TpDetail.Controls.Add(Me.ChkPetch)
Me.TpDetail.Controls.Add(Me.TxtSubfn)
Me.TpDetail.Controls.Add(Me.TxtFnpgm)
Me.TpDetail.Controls.Add(Me.TxtObnbr)
Me.TpDetail.Controls.Add(Me.TxtDpnbr)
Me.TpDetail.Controls.Add(Me.TxtSfund)
Me.TpDetail.Controls.Add(Me.Label6)
Me.TpDetail.Controls.Add(Me.TxtFdnbr)
Me.TpDetail.Controls.Add(Me.Label5)
Me.TpDetail.Controls.Add(Me.TxtBnkac)
Me.TpDetail.Controls.Add(Me.Label4)
Me.TpDetail.Controls.Add(Me.TxtBchkn)
Me.TpDetail.Controls.Add(Me.Label3)
Me.TpDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TpDetail.Location = New System.Drawing.Point(4, 22)
Me.TpDetail.Name = "TpDetail"
Me.TpDetail.Size = New System.Drawing.Size(374, 389)
Me.TpDetail.TabIndex = 0
Me.TpDetail.Text = "Detail"
Me.TpDetail.UseVisualStyleBackColor = True
'
'Label10
'
Me.Label10.Location = New System.Drawing.Point(18, 233)
Me.Label10.Name = "Label10"
Me.Label10.Size = New System.Drawing.Size(96, 18)
Me.Label10.TabIndex = 334
Me.Label10.Text = "Sub Function"
'
'Label9
'
Me.Label9.Location = New System.Drawing.Point(18, 207)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(105, 19)
Me.Label9.TabIndex = 333
Me.Label9.Text = "Function/Program"
'
'Label8
'
Me.Label8.Location = New System.Drawing.Point(18, 177)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(68, 16)
Me.Label8.TabIndex = 332
Me.Label8.Text = "Object"
'
'Label7
'
Me.Label7.Location = New System.Drawing.Point(18, 151)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(110, 18)
Me.Label7.TabIndex = 331
Me.Label7.Text = "Department Number"
'
'ChkPetch
'
Me.ChkPetch.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkPetch.Location = New System.Drawing.Point(21, 12)
Me.ChkPetch.Name = "ChkPetch"
Me.ChkPetch.Size = New System.Drawing.Size(127, 23)
Me.ChkPetch.TabIndex = 0
Me.ChkPetch.Text = "Petty Cash?"
Me.ChkPetch.UseVisualStyleBackColor = True
'
'TxtSubfn
'
Me.TxtSubfn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtSubfn.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtSubfn.Location = New System.Drawing.Point(128, 229)
Me.TxtSubfn.MaxLength = 4
Me.TxtSubfn.Name = "TxtSubfn"
Me.TxtSubfn.Size = New System.Drawing.Size(36, 20)
Me.TxtSubfn.TabIndex = 8
'
'TxtFnpgm
'
Me.TxtFnpgm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtFnpgm.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFnpgm.Location = New System.Drawing.Point(129, 201)
Me.TxtFnpgm.MaxLength = 4
Me.TxtFnpgm.Name = "TxtFnpgm"
Me.TxtFnpgm.Size = New System.Drawing.Size(36, 20)
Me.TxtFnpgm.TabIndex = 7
'
'TxtObnbr
'
Me.TxtObnbr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtObnbr.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtObnbr.Location = New System.Drawing.Point(129, 173)
Me.TxtObnbr.MaxLength = 3
Me.TxtObnbr.Name = "TxtObnbr"
Me.TxtObnbr.Size = New System.Drawing.Size(28, 20)
Me.TxtObnbr.TabIndex = 6
'
'TxtDpnbr
'
Me.TxtDpnbr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDpnbr.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDpnbr.Location = New System.Drawing.Point(129, 147)
Me.TxtDpnbr.MaxLength = 4
Me.TxtDpnbr.Name = "TxtDpnbr"
Me.TxtDpnbr.Size = New System.Drawing.Size(36, 20)
Me.TxtDpnbr.TabIndex = 5
'
'TxtSfund
'
Me.TxtSfund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtSfund.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtSfund.Location = New System.Drawing.Point(129, 121)
Me.TxtSfund.MaxLength = 3
Me.TxtSfund.Name = "TxtSfund"
Me.TxtSfund.Size = New System.Drawing.Size(28, 20)
Me.TxtSfund.TabIndex = 4
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(18, 125)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(68, 16)
Me.Label6.TabIndex = 8
Me.Label6.Text = "Sub Fund"
'
'TxtFdnbr
'
Me.TxtFdnbr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtFdnbr.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFdnbr.Location = New System.Drawing.Point(129, 93)
Me.TxtFdnbr.MaxLength = 3
Me.TxtFdnbr.Name = "TxtFdnbr"
Me.TxtFdnbr.Size = New System.Drawing.Size(28, 20)
Me.TxtFdnbr.TabIndex = 3
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(18, 96)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(87, 17)
Me.Label5.TabIndex = 6
Me.Label5.Text = "Fund Number"
'
'TxtBnkac
'
Me.TxtBnkac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtBnkac.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtBnkac.Location = New System.Drawing.Point(129, 63)
Me.TxtBnkac.MaxLength = 15
Me.TxtBnkac.Name = "TxtBnkac"
Me.TxtBnkac.Size = New System.Drawing.Size(112, 20)
Me.TxtBnkac.TabIndex = 2
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(18, 67)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(80, 16)
Me.Label4.TabIndex = 4
Me.Label4.Text = "Bank Account"
'
'TxtBchkn
'
Me.TxtBchkn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtBchkn.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtBchkn.Location = New System.Drawing.Point(129, 35)
Me.TxtBchkn.MaxLength = 5
Me.TxtBchkn.Name = "TxtBchkn"
Me.TxtBchkn.Size = New System.Drawing.Size(44, 20)
Me.TxtBchkn.TabIndex = 1
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(18, 39)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(68, 16)
Me.Label3.TabIndex = 2
Me.Label3.Text = "Next Check"
'
'TpCheck
'
Me.TpCheck.Controls.Add(Me.RbMICR20Webster)
Me.TpCheck.Controls.Add(Me.RbMICR6ns)
Me.TpCheck.Controls.Add(Me.RbMICR6)
Me.TpCheck.Controls.Add(Me.RbMICR20)
Me.TpCheck.Controls.Add(Me.TxtRout)
Me.TpCheck.Controls.Add(Me.Label22)
Me.TpCheck.Controls.Add(Me.Label21)
Me.TpCheck.Controls.Add(Me.TxtFract2)
Me.TpCheck.Controls.Add(Me.TxtFract1)
Me.TpCheck.Controls.Add(Me.Label20)
Me.TpCheck.Controls.Add(Me.GroupBox3)
Me.TpCheck.Controls.Add(Me.GroupBox2)
Me.TpCheck.Controls.Add(Me.GroupBox1)
Me.TpCheck.Location = New System.Drawing.Point(4, 22)
Me.TpCheck.Name = "TpCheck"
Me.TpCheck.Size = New System.Drawing.Size(374, 389)
Me.TpCheck.TabIndex = 1
Me.TpCheck.Text = "Check Info"
Me.TpCheck.UseVisualStyleBackColor = True
'
'RbMICR6ns
'
Me.RbMICR6ns.AutoSize = True
Me.RbMICR6ns.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbMICR6ns.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbMICR6ns.Location = New System.Drawing.Point(131, 364)
Me.RbMICR6ns.Name = "RbMICR6ns"
Me.RbMICR6ns.Size = New System.Drawing.Size(165, 17)
Me.RbMICR6ns.TabIndex = 17
Me.RbMICR6ns.TabStop = True
Me.RbMICR6ns.Text = "6 Aux MICR (Acct no spaces)"
Me.RbMICR6ns.UseVisualStyleBackColor = True
'
'RbMICR6
'
Me.RbMICR6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbMICR6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbMICR6.Location = New System.Drawing.Point(14, 364)
Me.RbMICR6.Name = "RbMICR6"
Me.RbMICR6.Size = New System.Drawing.Size(88, 17)
Me.RbMICR6.TabIndex = 16
Me.RbMICR6.TabStop = True
Me.RbMICR6.Text = "6 Aux MICR"
Me.RbMICR6.UseVisualStyleBackColor = True
'
'RbMICR20
'
Me.RbMICR20.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbMICR20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbMICR20.Location = New System.Drawing.Point(14, 346)
Me.RbMICR20.Name = "RbMICR20"
Me.RbMICR20.Size = New System.Drawing.Size(88, 17)
Me.RbMICR20.TabIndex = 15
Me.RbMICR20.TabStop = True
Me.RbMICR20.Text = "20 Aux MICR"
Me.RbMICR20.UseVisualStyleBackColor = True
'
'TxtRout
'
Me.TxtRout.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtRout.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtRout.Location = New System.Drawing.Point(116, 221)
Me.TxtRout.MaxLength = 15
Me.TxtRout.Name = "TxtRout"
Me.TxtRout.Size = New System.Drawing.Size(110, 20)
Me.TxtRout.TabIndex = 3
'
'Label22
'
Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label22.Location = New System.Drawing.Point(11, 224)
Me.Label22.Name = "Label22"
Me.Label22.Size = New System.Drawing.Size(99, 17)
Me.Label22.TabIndex = 14
Me.Label22.Text = "Routing Number"
'
'Label21
'
Me.Label21.AutoSize = True
Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label21.Location = New System.Drawing.Point(188, 201)
Me.Label21.Name = "Label21"
Me.Label21.Size = New System.Drawing.Size(12, 13)
Me.Label21.TabIndex = 1
Me.Label21.Text = "/"
'
'TxtFract2
'
Me.TxtFract2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtFract2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFract2.Location = New System.Drawing.Point(206, 198)
Me.TxtFract2.MaxLength = 10
Me.TxtFract2.Name = "TxtFract2"
Me.TxtFract2.Size = New System.Drawing.Size(69, 20)
Me.TxtFract2.TabIndex = 2
'
'TxtFract1
'
Me.TxtFract1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtFract1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFract1.Location = New System.Drawing.Point(116, 198)
Me.TxtFract1.MaxLength = 10
Me.TxtFract1.Name = "TxtFract1"
Me.TxtFract1.Size = New System.Drawing.Size(69, 20)
Me.TxtFract1.TabIndex = 0
'
'Label20
'
Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label20.Location = New System.Drawing.Point(11, 201)
Me.Label20.Name = "Label20"
Me.Label20.Size = New System.Drawing.Size(99, 17)
Me.Label20.TabIndex = 11
Me.Label20.Text = "Fractional Number"
'
'GroupBox3
'
Me.GroupBox3.Controls.Add(Me.TxtSig3)
Me.GroupBox3.Controls.Add(Me.Label17)
Me.GroupBox3.Controls.Add(Me.TxtSig2)
Me.GroupBox3.Controls.Add(Me.Label18)
Me.GroupBox3.Controls.Add(Me.TxtSig1)
Me.GroupBox3.Controls.Add(Me.Label19)
Me.GroupBox3.ForeColor = System.Drawing.Color.Black
Me.GroupBox3.Location = New System.Drawing.Point(14, 244)
Me.GroupBox3.Name = "GroupBox3"
Me.GroupBox3.Size = New System.Drawing.Size(341, 96)
Me.GroupBox3.TabIndex = 9
Me.GroupBox3.TabStop = False
Me.GroupBox3.Text = "Signatures"
'
'TxtSig3
'
Me.TxtSig3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtSig3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtSig3.Location = New System.Drawing.Point(47, 70)
Me.TxtSig3.MaxLength = 40
Me.TxtSig3.Name = "TxtSig3"
Me.TxtSig3.Size = New System.Drawing.Size(281, 20)
Me.TxtSig3.TabIndex = 2
'
'Label17
'
Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label17.Location = New System.Drawing.Point(6, 74)
Me.Label17.Name = "Label17"
Me.Label17.Size = New System.Drawing.Size(41, 16)
Me.Label17.TabIndex = 12
Me.Label17.Text = "3rd"
'
'TxtSig2
'
Me.TxtSig2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtSig2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtSig2.Location = New System.Drawing.Point(47, 47)
Me.TxtSig2.MaxLength = 40
Me.TxtSig2.Name = "TxtSig2"
Me.TxtSig2.Size = New System.Drawing.Size(281, 20)
Me.TxtSig2.TabIndex = 1
'
'Label18
'
Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label18.Location = New System.Drawing.Point(6, 51)
Me.Label18.Name = "Label18"
Me.Label18.Size = New System.Drawing.Size(41, 16)
Me.Label18.TabIndex = 10
Me.Label18.Text = "2nd"
'
'TxtSig1
'
Me.TxtSig1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtSig1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtSig1.Location = New System.Drawing.Point(47, 24)
Me.TxtSig1.MaxLength = 40
Me.TxtSig1.Name = "TxtSig1"
Me.TxtSig1.Size = New System.Drawing.Size(281, 20)
Me.TxtSig1.TabIndex = 0
'
'Label19
'
Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label19.Location = New System.Drawing.Point(6, 28)
Me.Label19.Name = "Label19"
Me.Label19.Size = New System.Drawing.Size(41, 16)
Me.Label19.TabIndex = 8
Me.Label19.Text = "1st"
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.TxtBndes3)
Me.GroupBox2.Controls.Add(Me.Label14)
Me.GroupBox2.Controls.Add(Me.TxtBndes2)
Me.GroupBox2.Controls.Add(Me.Label15)
Me.GroupBox2.Controls.Add(Me.TxtBndes1)
Me.GroupBox2.Controls.Add(Me.Label16)
Me.GroupBox2.ForeColor = System.Drawing.Color.Black
Me.GroupBox2.Location = New System.Drawing.Point(14, 99)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(341, 96)
Me.GroupBox2.TabIndex = 8
Me.GroupBox2.TabStop = False
Me.GroupBox2.Text = "Bank Description"
'
'TxtBndes3
'
Me.TxtBndes3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtBndes3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtBndes3.Location = New System.Drawing.Point(47, 70)
Me.TxtBndes3.MaxLength = 40
Me.TxtBndes3.Name = "TxtBndes3"
Me.TxtBndes3.Size = New System.Drawing.Size(281, 20)
Me.TxtBndes3.TabIndex = 2
'
'Label14
'
Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label14.Location = New System.Drawing.Point(6, 74)
Me.Label14.Name = "Label14"
Me.Label14.Size = New System.Drawing.Size(41, 16)
Me.Label14.TabIndex = 12
Me.Label14.Text = "Line 3"
'
'TxtBndes2
'
Me.TxtBndes2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtBndes2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtBndes2.Location = New System.Drawing.Point(47, 47)
Me.TxtBndes2.MaxLength = 40
Me.TxtBndes2.Name = "TxtBndes2"
Me.TxtBndes2.Size = New System.Drawing.Size(281, 20)
Me.TxtBndes2.TabIndex = 1
'
'Label15
'
Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label15.Location = New System.Drawing.Point(6, 51)
Me.Label15.Name = "Label15"
Me.Label15.Size = New System.Drawing.Size(41, 16)
Me.Label15.TabIndex = 10
Me.Label15.Text = "Line 2"
'
'TxtBndes1
'
Me.TxtBndes1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtBndes1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtBndes1.Location = New System.Drawing.Point(47, 24)
Me.TxtBndes1.MaxLength = 40
Me.TxtBndes1.Name = "TxtBndes1"
Me.TxtBndes1.Size = New System.Drawing.Size(281, 20)
Me.TxtBndes1.TabIndex = 0
'
'Label16
'
Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label16.Location = New System.Drawing.Point(6, 28)
Me.Label16.Name = "Label16"
Me.Label16.Size = New System.Drawing.Size(41, 16)
Me.Label16.TabIndex = 8
Me.Label16.Text = "Line 1"
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.TxtAcdes3)
Me.GroupBox1.Controls.Add(Me.Label13)
Me.GroupBox1.Controls.Add(Me.TxtAcdes2)
Me.GroupBox1.Controls.Add(Me.Label12)
Me.GroupBox1.Controls.Add(Me.TxtAcdes1)
Me.GroupBox1.Controls.Add(Me.Label11)
Me.GroupBox1.ForeColor = System.Drawing.Color.Black
Me.GroupBox1.Location = New System.Drawing.Point(14, 3)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(341, 96)
Me.GroupBox1.TabIndex = 7
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Account Description"
'
'TxtAcdes3
'
Me.TxtAcdes3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtAcdes3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtAcdes3.ForeColor = System.Drawing.Color.Black
Me.TxtAcdes3.Location = New System.Drawing.Point(47, 70)
Me.TxtAcdes3.MaxLength = 40
Me.TxtAcdes3.Name = "TxtAcdes3"
Me.TxtAcdes3.Size = New System.Drawing.Size(281, 20)
Me.TxtAcdes3.TabIndex = 2
'
'Label13
'
Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label13.ForeColor = System.Drawing.Color.Black
Me.Label13.Location = New System.Drawing.Point(6, 74)
Me.Label13.Name = "Label13"
Me.Label13.Size = New System.Drawing.Size(41, 16)
Me.Label13.TabIndex = 12
Me.Label13.Text = "Line 3"
'
'TxtAcdes2
'
Me.TxtAcdes2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtAcdes2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtAcdes2.ForeColor = System.Drawing.Color.Black
Me.TxtAcdes2.Location = New System.Drawing.Point(47, 47)
Me.TxtAcdes2.MaxLength = 40
Me.TxtAcdes2.Name = "TxtAcdes2"
Me.TxtAcdes2.Size = New System.Drawing.Size(281, 20)
Me.TxtAcdes2.TabIndex = 1
'
'Label12
'
Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label12.ForeColor = System.Drawing.Color.Black
Me.Label12.Location = New System.Drawing.Point(6, 51)
Me.Label12.Name = "Label12"
Me.Label12.Size = New System.Drawing.Size(41, 16)
Me.Label12.TabIndex = 10
Me.Label12.Text = "Line 2"
'
'TxtAcdes1
'
Me.TxtAcdes1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtAcdes1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtAcdes1.ForeColor = System.Drawing.Color.Black
Me.TxtAcdes1.Location = New System.Drawing.Point(47, 24)
Me.TxtAcdes1.MaxLength = 40
Me.TxtAcdes1.Name = "TxtAcdes1"
Me.TxtAcdes1.Size = New System.Drawing.Size(281, 20)
Me.TxtAcdes1.TabIndex = 0
'
'Label11
'
Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label11.ForeColor = System.Drawing.Color.Black
Me.Label11.Location = New System.Drawing.Point(6, 28)
Me.Label11.Name = "Label11"
Me.Label11.Size = New System.Drawing.Size(41, 16)
Me.Label11.TabIndex = 8
Me.Label11.Text = "Line 1"
'
'RbMICR20Webster
'
Me.RbMICR20Webster.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.RbMICR20Webster.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RbMICR20Webster.Location = New System.Drawing.Point(131, 346)
Me.RbMICR20Webster.Name = "RbMICR20Webster"
Me.RbMICR20Webster.Size = New System.Drawing.Size(165, 17)
Me.RbMICR20Webster.TabIndex = 18
Me.RbMICR20Webster.TabStop = True
Me.RbMICR20Webster.Text = "20 Aux MICR (Webster)"
Me.RbMICR20Webster.UseVisualStyleBackColor = True
'
'FrmAP103C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(408, 489)
Me.Controls.Add(Me.TabControl1)
Me.Controls.Add(Me.TxtBnknm)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.TxtBnkcd)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmAP103C"
Me.Text = "Maintain Bank Master"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.TabControl1.ResumeLayout(False)
Me.TpDetail.ResumeLayout(False)
Me.TpDetail.PerformLayout()
Me.TpCheck.ResumeLayout(False)
Me.TpCheck.PerformLayout()
Me.GroupBox3.ResumeLayout(False)
Me.GroupBox3.PerformLayout()
Me.GroupBox2.ResumeLayout(False)
Me.GroupBox2.PerformLayout()
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox1.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

  Private Sub FrmAP103C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myAPEBNK = New APEBNK.MyData()
  myAPEBNK.MyDBConn = myDBConnect
  myAPEBNC = New APEBNC.MyData()
  myAPEBNC.MyDBConn = myDBConnect

  WrkAddMode2 = True
  MyFrmAP103.TBarNew.Enabled = False
  MyFrmAP103.TBarSave.Enabled = True
  If WrkCode <> "" Then
    MyFrmAP103.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtBnkcd)
  End If
  If WrkCode = "" Then
    Me.Text = "Add " & Me.Text
    MyFrmAP103.TBarDelete.Enabled = False
    Exit Sub
  End If

	myAPEBNK.GetOneRecordP(WrkCode)
  TxtBnkcd.Text = WrkCode

	If myAPEBNK.RecordNotFound Then
			MyFrmAP103.TBarNew.Enabled = False
			MyFrmAP103.TBarSave.Enabled = False
			MyFrmAP103.TBarDelete.Enabled = False
			Me.ErrProv.SetError(TxtBnkcd, "Record not found")
			Exit Sub
		End If

    If s_chg = False And s_full = False Then    '#sec
      MyFrmAP103.TBarSave.Visible = False
    End If

		With myAPEBNK
			ChkPetch.Checked = False
			If ._PETCH = "Y" Then
				ChkPetch.Checked = True
			End If
			TxtBnknm.Text = Trim(._BNKNM)
			TxtBchkn.Text = ._BCHKN
			If ._BNKAC > 0 Then
				TxtBnkac.Text = ._BNKAC
			End If
			TxtFdnbr.Text = Format(._FDNBR, "###")
			TxtSfund.Text = Format(._SFUND, "###")
			TxtDpnbr.Text = Format(._DPNBR, "####")
			TxtObnbr.Text = Format(._OBNBR, "###")
			TxtFnpgm.Text = Format(._FNPGM, "####")
			TxtSubfn.Text = Format(._SUBFN, "####")
		End With

		myAPEBNC.GetOneRecordP(TxtBnkcd.Text)
		If myAPEBNC.RecordNotFound Then Exit Sub

    WrkAddMode2 = False
		With myAPEBNC
			TxtAcdes1.Text = Trim(._ACDES1)
			TxtAcdes2.Text = Trim(._ACDES2)
			TxtAcdes3.Text = Trim(._ACDES3)
			TxtBndes1.Text = Trim(._BNDES1)
			TxtBndes2.Text = Trim(._BNDES2)
			TxtBndes3.Text = Trim(._BNDES3)
			TxtFract1.Text = Trim(._FRACT1)
			TxtFract2.Text = Trim(._FRACT2)
			TxtRout.Text = Trim(._ROUT)
			TxtSig1.Text = Trim(._SIG1)
			TxtSig2.Text = Trim(._SIG2)
			TxtSig3.Text = Trim(._SIG3)
			Select Case Trim(._MICR)
			Case "6"
				RbMICR6.Checked = True
			Case "N"
				RbMICR6ns.Checked = True
      Case "W"
        RbMICR20Webster.Checked = True
			Case Else
        RbMICR20.Checked = True
      End Select
		End With

    End Sub
Private Sub FrmAP103C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmAP103.SbpScreen.Text = "AP103C"
  MyUtils.CenterForm(Me.ParentForm, Me)
    If WrkCode <> "" Then
    End If
End Sub

Private Sub FrmAP103C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmAP103.TBarNew.Enabled = True
  MyFrmAP103.TBarDelete.Enabled = False
  MyFrmAP103.TBarSave.Enabled = False
  MyFrmAP103B.FormatGrid()
  MyFrmAP103B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
	myAPEBNK.DeleteOneRecordP()

  If Not WrkAddMode2 Then
		myAPEBNC.DeleteOneRecordP()
  End If
  Me.Close()
End Sub

Public Sub SaveData()
	Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
	myAPEBNK.GetOneRecordP(TxtBnkcd.Text)
	myAPEBNC.GetOneRecordP(TxtBnkcd.Text)
  If WrkCode = "" Then
		If Not myAPEBNK.RecordNotFound Then
			Me.ErrProv.SetError(TxtBnkcd, "Record already exists")
			Exit Sub
		End If
  End If
  If WrkCode <> "" Then
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myAPEBNK.UpdateOneRecordP()
			Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
	Else
		MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myAPEBNK.AddOneRecordP()
			Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
  End If

  If Not WrkAddMode2 Then
    MovetoFile2()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myAPEBNC.UpdateOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
  Else
		MovetoFile2()
		EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
			myAPEBNC.AddOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
	With myAPEBNK
	If WrkCode = "" Then
		._BNKCD = TxtBnkcd.Text
	End If
	 ._BNKNM = TxtBnknm.Text
	 If ChkPetch.Checked Then
		 ._PETCH = "Y"
	 Else
		 ._PETCH = "N"
	 End If
   ._BCHKN = MyUtils.CnvSng(TxtBchkn.Text)
   ._BNKAC = MyUtils.CnvSng(TxtBnkac.Text)
   ._FDNBR = MyUtils.CnvSng(TxtFdnbr.Text)
   ._SFUND = MyUtils.CnvSng(TxtSfund.Text)
   ._DPNBR = MyUtils.CnvSng(TxtDpnbr.Text)
   ._OBNBR = MyUtils.CnvSng(TxtObnbr.Text)
   ._FNPGM = MyUtils.CnvSng(TxtFnpgm.Text)
   ._SUBFN = MyUtils.CnvSng(TxtSubfn.Text)
	End With
 End Sub
Private Sub MovetoFile2()
	With myAPEBNC
	If WrkAddMode2 Then
		._BNKCD = TxtBnkcd.Text
	End If
	 ._ACDES1 = TxtAcdes1.Text
	 ._ACDES2 = TxtAcdes2.Text
	 ._ACDES3 = TxtAcdes3.Text
	 ._BNDES1 = TxtBndes1.Text
	 ._BNDES2 = TxtBndes2.Text
	 ._BNDES3 = TxtBndes3.Text
	 ._FRACT1 = TxtFract1.Text
	 ._FRACT2 = TxtFract2.Text
	 ._ROUT = TxtRout.Text
	 ._SIG1 = TxtSig1.Text
	 ._SIG2 = TxtSig2.Text
	 ._SIG3 = TxtSig3.Text
	 If RbMICR20.Checked Then
		 ._MICR = ""
	 End If
   If RbMICR20Webster.Checked Then
     ._MICR = "W"
   End If
   If RbMICR6.Checked Then
     ._MICR = "6"
   End If
	 If RbMICR6ns.Checked Then
		 ._MICR = "N"
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

	If TxtBnkcd.Text = String.Empty Then
			ErrorField(I) = "bnkcd"
			ErrorMsg(I) = "Bank Code is required"
			I = I + 1
	End If

	If TxtBnknm.Text = String.Empty Then
			ErrorField(I) = "bnknm"
			ErrorMsg(I) = "Bank Name is required"
			I = I + 1
	End If

	End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
	ErrProv.SetError(TxtBnkcd, "")
	ErrProv.SetError(TxtBnknm, "")
	For I = 0 To ErrorField.GetUpperBound(0)
		Select Case ErrorField(I)
		Case "bnkcd"
			ErrProv.SetError(TxtBnkcd, ErrorMsg(I))
		Case "bnknm"
			ErrProv.SetError(TxtBnknm, ErrorMsg(I))
		Case Nothing
			Exit Sub
		End Select
	Next I
End Sub
Private Sub TxtBchkn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBchkn.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtBnkac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBnkac.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtFdnbr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFdnbr.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtSfund_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSfund.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDpnbr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDpnbr.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtObnbr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtObnbr.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtFnpgm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFnpgm.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtSubfn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSubfn.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class
