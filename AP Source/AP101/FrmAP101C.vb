Public Class FrmAP101C
  Inherits System.Windows.Forms.Form
  Dim myVENDOR As VENDOR.MyData
  Dim myAPEHSTL1 As APEHSTL1.MyData
  Dim myPOMASTLC As POMASTL1.MyData
  Dim ds2 As DataSet
  Dim WrkDbDate As Integer

  Friend WithEvents TabCtl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpEdit As System.Windows.Forms.TabPage
  Friend WithEvents TpActivity As System.Windows.Forms.TabPage
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtVndnr As System.Windows.Forms.TextBox
  Friend WithEvents ChkF1099 As System.Windows.Forms.CheckBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtVennm As System.Windows.Forms.TextBox

  Friend WrkVndnr As String
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TxtVphon As System.Windows.Forms.TextBox
  Friend WithEvents TxtVzipe As System.Windows.Forms.TextBox
  Friend WithEvents TxtVzip As System.Windows.Forms.TextBox
  Friend WithEvents TxtVadd4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtVadd3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtVadd2 As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtOzipe As System.Windows.Forms.TextBox
  Friend WithEvents TxtOzip As System.Windows.Forms.TextBox
  Friend WithEvents TxtOrad4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtOrad3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtOrad2 As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtOrad1 As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtOrnam As System.Windows.Forms.TextBox
  Friend WithEvents ChkFemcd As System.Windows.Forms.CheckBox
  Friend WithEvents ChkMincd As System.Windows.Forms.CheckBox
  Friend WithEvents TxtPyzipe As System.Windows.Forms.TextBox
  Friend WithEvents TxtPyzip As System.Windows.Forms.TextBox
  Friend WithEvents TxtPyad4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtPyad3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtPyad2 As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TxtPyad1 As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents TxtPynam As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents TxtVsort As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents TxtDuedy As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtContn As System.Windows.Forms.TextBox
  Friend WithEvents TxtVncat As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents TxtPhext As System.Windows.Forms.TextBox
  Friend WithEvents ChkAcrec As System.Windows.Forms.CheckBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents TxtPhalt As System.Windows.Forms.TextBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents TxtFaxno As System.Windows.Forms.TextBox
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents TxtTxtyp As System.Windows.Forms.TextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents TxtTaxid As System.Windows.Forms.TextBox
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents TxtOrdsp As System.Windows.Forms.TextBox
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents TxtOrshp As System.Windows.Forms.TextBox
  Friend WithEvents LnkGLAcctBS As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkGLAcctBD As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtSubfs As System.Windows.Forms.TextBox
  Friend WithEvents TxtFnpgs As System.Windows.Forms.TextBox
  Friend WithEvents TxtObnbs As System.Windows.Forms.TextBox
  Friend WithEvents TxtDpnbs As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfuns As System.Windows.Forms.TextBox
  Friend WithEvents TxtSubfd As System.Windows.Forms.TextBox
  Friend WithEvents TxtFnpgd As System.Windows.Forms.TextBox
  Friend WithEvents TxtObnbd As System.Windows.Forms.TextBox
  Friend WithEvents TxtDpnbd As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfudd As System.Windows.Forms.TextBox
  Friend WithEvents TxtFdnbs As System.Windows.Forms.TextBox
  Friend WithEvents TxtFdnbd As System.Windows.Forms.TextBox
  Friend WithEvents DtPckChk As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents LblFscpr As System.Windows.Forms.Label
  Friend WithEvents Label26 As System.Windows.Forms.Label
  Friend WithEvents LblYtdpr As System.Windows.Forms.Label
  Friend WithEvents Label24 As System.Windows.Forms.Label
  Friend WithEvents LblFscpa As System.Windows.Forms.Label
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents LblYtdpa As System.Windows.Forms.Label
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents LblDtlpd As System.Windows.Forms.Label
  Friend WithEvents LblVennm As System.Windows.Forms.Label
  Friend WithEvents LnkVncat As System.Windows.Forms.LinkLabel
  Friend WithEvents RbInvNo As System.Windows.Forms.RadioButton
  Friend WithEvents RbChkDate As System.Windows.Forms.RadioButton
  Friend WithEvents RbInvDate As System.Windows.Forms.RadioButton
  Friend WithEvents TxtVadd1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtInvNo As System.Windows.Forms.TextBox
  Friend WithEvents DtPckInv As System.Windows.Forms.DateTimePicker
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents TpPO As System.Windows.Forms.TabPage
  Friend WithEvents TxtPONbr As System.Windows.Forms.TextBox
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents TxtFscyr As System.Windows.Forms.TextBox
  Friend WithEvents BtnFindPO As System.Windows.Forms.Button
  Friend WithEvents LblSuspended As System.Windows.Forms.Label
  Friend WithEvents DataGrdView As DataGridView
  Friend WithEvents DataGrdView2 As DataGridView
  Friend WithEvents Label23 As Label
  Friend WithEvents TxtVemail As TextBox
  Dim WrkSort As String

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
    Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TabCtl1 = New System.Windows.Forms.TabControl()
    Me.TpEdit = New System.Windows.Forms.TabPage()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.TxtVemail = New System.Windows.Forms.TextBox()
    Me.LnkVncat = New System.Windows.Forms.LinkLabel()
    Me.LnkGLAcctBS = New System.Windows.Forms.LinkLabel()
    Me.LnkGLAcctBD = New System.Windows.Forms.LinkLabel()
    Me.TxtSubfs = New System.Windows.Forms.TextBox()
    Me.TxtFnpgs = New System.Windows.Forms.TextBox()
    Me.TxtObnbs = New System.Windows.Forms.TextBox()
    Me.TxtDpnbs = New System.Windows.Forms.TextBox()
    Me.TxtSfuns = New System.Windows.Forms.TextBox()
    Me.TxtSubfd = New System.Windows.Forms.TextBox()
    Me.TxtFnpgd = New System.Windows.Forms.TextBox()
    Me.TxtObnbd = New System.Windows.Forms.TextBox()
    Me.TxtDpnbd = New System.Windows.Forms.TextBox()
    Me.TxtSfudd = New System.Windows.Forms.TextBox()
    Me.TxtFdnbs = New System.Windows.Forms.TextBox()
    Me.TxtFdnbd = New System.Windows.Forms.TextBox()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.TxtOrshp = New System.Windows.Forms.TextBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.TxtOrdsp = New System.Windows.Forms.TextBox()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.TxtTxtyp = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.TxtTaxid = New System.Windows.Forms.TextBox()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.TxtFaxno = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.TxtPhalt = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TxtPhext = New System.Windows.Forms.TextBox()
    Me.ChkAcrec = New System.Windows.Forms.CheckBox()
    Me.TxtVncat = New System.Windows.Forms.TextBox()
    Me.TxtPyzipe = New System.Windows.Forms.TextBox()
    Me.TxtPyzip = New System.Windows.Forms.TextBox()
    Me.TxtPyad4 = New System.Windows.Forms.TextBox()
    Me.TxtPyad3 = New System.Windows.Forms.TextBox()
    Me.TxtPyad2 = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtPyad1 = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TxtPynam = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TxtVsort = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtDuedy = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtContn = New System.Windows.Forms.TextBox()
    Me.ChkFemcd = New System.Windows.Forms.CheckBox()
    Me.ChkMincd = New System.Windows.Forms.CheckBox()
    Me.TxtOzipe = New System.Windows.Forms.TextBox()
    Me.TxtOzip = New System.Windows.Forms.TextBox()
    Me.TxtOrad4 = New System.Windows.Forms.TextBox()
    Me.TxtOrad3 = New System.Windows.Forms.TextBox()
    Me.TxtOrad2 = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtOrad1 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtOrnam = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtVphon = New System.Windows.Forms.TextBox()
    Me.TxtVzipe = New System.Windows.Forms.TextBox()
    Me.TxtVzip = New System.Windows.Forms.TextBox()
    Me.TxtVadd4 = New System.Windows.Forms.TextBox()
    Me.TxtVadd3 = New System.Windows.Forms.TextBox()
    Me.TxtVadd2 = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtVadd1 = New System.Windows.Forms.TextBox()
    Me.ChkF1099 = New System.Windows.Forms.CheckBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtVennm = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtVndnr = New System.Windows.Forms.TextBox()
    Me.TpActivity = New System.Windows.Forms.TabPage()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtInvNo = New System.Windows.Forms.TextBox()
    Me.DtPckInv = New System.Windows.Forms.DateTimePicker()
    Me.RbInvDate = New System.Windows.Forms.RadioButton()
    Me.RbInvNo = New System.Windows.Forms.RadioButton()
    Me.RbChkDate = New System.Windows.Forms.RadioButton()
    Me.DtPckChk = New System.Windows.Forms.DateTimePicker()
    Me.TpPO = New System.Windows.Forms.TabPage()
    Me.DataGrdView2 = New System.Windows.Forms.DataGridView()
    Me.TxtPONbr = New System.Windows.Forms.TextBox()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.TxtFscyr = New System.Windows.Forms.TextBox()
    Me.BtnFindPO = New System.Windows.Forms.Button()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.LblYtdpa = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.LblFscpa = New System.Windows.Forms.Label()
    Me.Label22 = New System.Windows.Forms.Label()
    Me.LblYtdpr = New System.Windows.Forms.Label()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.LblFscpr = New System.Windows.Forms.Label()
    Me.Label26 = New System.Windows.Forms.Label()
    Me.LblDtlpd = New System.Windows.Forms.Label()
    Me.LblVennm = New System.Windows.Forms.Label()
    Me.LblSuspended = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TabCtl1.SuspendLayout()
    Me.TpEdit.SuspendLayout()
    Me.TpActivity.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TpPO.SuspendLayout()
    CType(Me.DataGrdView2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TabCtl1
    '
    Me.TabCtl1.Controls.Add(Me.TpEdit)
    Me.TabCtl1.Controls.Add(Me.TpActivity)
    Me.TabCtl1.Controls.Add(Me.TpPO)
    Me.TabCtl1.Location = New System.Drawing.Point(12, 80)
    Me.TabCtl1.Name = "TabCtl1"
    Me.TabCtl1.SelectedIndex = 0
    Me.TabCtl1.Size = New System.Drawing.Size(910, 533)
    Me.TabCtl1.TabIndex = 174
    '
    'TpEdit
    '
    Me.TpEdit.Controls.Add(Me.Label23)
    Me.TpEdit.Controls.Add(Me.TxtVemail)
    Me.TpEdit.Controls.Add(Me.LnkVncat)
    Me.TpEdit.Controls.Add(Me.LnkGLAcctBS)
    Me.TpEdit.Controls.Add(Me.LnkGLAcctBD)
    Me.TpEdit.Controls.Add(Me.TxtSubfs)
    Me.TpEdit.Controls.Add(Me.TxtFnpgs)
    Me.TpEdit.Controls.Add(Me.TxtObnbs)
    Me.TpEdit.Controls.Add(Me.TxtDpnbs)
    Me.TpEdit.Controls.Add(Me.TxtSfuns)
    Me.TpEdit.Controls.Add(Me.TxtSubfd)
    Me.TpEdit.Controls.Add(Me.TxtFnpgd)
    Me.TpEdit.Controls.Add(Me.TxtObnbd)
    Me.TpEdit.Controls.Add(Me.TxtDpnbd)
    Me.TpEdit.Controls.Add(Me.TxtSfudd)
    Me.TpEdit.Controls.Add(Me.TxtFdnbs)
    Me.TpEdit.Controls.Add(Me.TxtFdnbd)
    Me.TpEdit.Controls.Add(Me.Label18)
    Me.TpEdit.Controls.Add(Me.TxtOrshp)
    Me.TpEdit.Controls.Add(Me.Label17)
    Me.TpEdit.Controls.Add(Me.TxtOrdsp)
    Me.TpEdit.Controls.Add(Me.Label16)
    Me.TpEdit.Controls.Add(Me.TxtTxtyp)
    Me.TpEdit.Controls.Add(Me.Label15)
    Me.TpEdit.Controls.Add(Me.TxtTaxid)
    Me.TpEdit.Controls.Add(Me.Label14)
    Me.TpEdit.Controls.Add(Me.TxtFaxno)
    Me.TpEdit.Controls.Add(Me.Label13)
    Me.TpEdit.Controls.Add(Me.TxtPhalt)
    Me.TpEdit.Controls.Add(Me.Label12)
    Me.TpEdit.Controls.Add(Me.TxtPhext)
    Me.TpEdit.Controls.Add(Me.ChkAcrec)
    Me.TpEdit.Controls.Add(Me.TxtVncat)
    Me.TpEdit.Controls.Add(Me.TxtPyzipe)
    Me.TpEdit.Controls.Add(Me.TxtPyzip)
    Me.TpEdit.Controls.Add(Me.TxtPyad4)
    Me.TpEdit.Controls.Add(Me.TxtPyad3)
    Me.TpEdit.Controls.Add(Me.TxtPyad2)
    Me.TpEdit.Controls.Add(Me.Label10)
    Me.TpEdit.Controls.Add(Me.TxtPyad1)
    Me.TpEdit.Controls.Add(Me.Label11)
    Me.TpEdit.Controls.Add(Me.TxtPynam)
    Me.TpEdit.Controls.Add(Me.Label9)
    Me.TpEdit.Controls.Add(Me.TxtVsort)
    Me.TpEdit.Controls.Add(Me.Label7)
    Me.TpEdit.Controls.Add(Me.TxtDuedy)
    Me.TpEdit.Controls.Add(Me.Label6)
    Me.TpEdit.Controls.Add(Me.TxtContn)
    Me.TpEdit.Controls.Add(Me.ChkFemcd)
    Me.TpEdit.Controls.Add(Me.ChkMincd)
    Me.TpEdit.Controls.Add(Me.TxtOzipe)
    Me.TpEdit.Controls.Add(Me.TxtOzip)
    Me.TpEdit.Controls.Add(Me.TxtOrad4)
    Me.TpEdit.Controls.Add(Me.TxtOrad3)
    Me.TpEdit.Controls.Add(Me.TxtOrad2)
    Me.TpEdit.Controls.Add(Me.Label1)
    Me.TpEdit.Controls.Add(Me.TxtOrad1)
    Me.TpEdit.Controls.Add(Me.Label2)
    Me.TpEdit.Controls.Add(Me.TxtOrnam)
    Me.TpEdit.Controls.Add(Me.Label5)
    Me.TpEdit.Controls.Add(Me.TxtVphon)
    Me.TpEdit.Controls.Add(Me.TxtVzipe)
    Me.TpEdit.Controls.Add(Me.TxtVzip)
    Me.TpEdit.Controls.Add(Me.TxtVadd4)
    Me.TpEdit.Controls.Add(Me.TxtVadd3)
    Me.TpEdit.Controls.Add(Me.TxtVadd2)
    Me.TpEdit.Controls.Add(Me.Label3)
    Me.TpEdit.Controls.Add(Me.TxtVadd1)
    Me.TpEdit.Controls.Add(Me.ChkF1099)
    Me.TpEdit.Controls.Add(Me.Label8)
    Me.TpEdit.Controls.Add(Me.TxtVennm)
    Me.TpEdit.Controls.Add(Me.Label4)
    Me.TpEdit.Controls.Add(Me.TxtVndnr)
    Me.TpEdit.Location = New System.Drawing.Point(4, 22)
    Me.TpEdit.Name = "TpEdit"
    Me.TpEdit.Padding = New System.Windows.Forms.Padding(3)
    Me.TpEdit.Size = New System.Drawing.Size(902, 507)
    Me.TpEdit.TabIndex = 0
    Me.TpEdit.Text = "Vendor Edit"
    Me.TpEdit.UseVisualStyleBackColor = True
    '
    'Label23
    '
    Me.Label23.AutoSize = True
    Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label23.ForeColor = System.Drawing.Color.Black
    Me.Label23.Location = New System.Drawing.Point(4, 211)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(73, 13)
    Me.Label23.TabIndex = 253
    Me.Label23.Text = "Email Address"
    '
    'TxtVemail
    '
    Me.TxtVemail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVemail.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVemail.Location = New System.Drawing.Point(91, 207)
    Me.TxtVemail.MaxLength = 75
    Me.TxtVemail.Name = "TxtVemail"
    Me.TxtVemail.Size = New System.Drawing.Size(673, 22)
    Me.TxtVemail.TabIndex = 13
    '
    'LnkVncat
    '
    Me.LnkVncat.AutoSize = True
    Me.LnkVncat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkVncat.ForeColor = System.Drawing.Color.Maroon
    Me.LnkVncat.Location = New System.Drawing.Point(618, 68)
    Me.LnkVncat.Name = "LnkVncat"
    Me.LnkVncat.Size = New System.Drawing.Size(86, 13)
    Me.LnkVncat.TabIndex = 251
    Me.LnkVncat.TabStop = True
    Me.LnkVncat.Text = "Vendor Category"
    '
    'LnkGLAcctBS
    '
    Me.LnkGLAcctBS.AutoSize = True
    Me.LnkGLAcctBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcctBS.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcctBS.Location = New System.Drawing.Point(381, 450)
    Me.LnkGLAcctBS.Name = "LnkGLAcctBS"
    Me.LnkGLAcctBS.Size = New System.Drawing.Size(120, 13)
    Me.LnkGLAcctBS.TabIndex = 250
    Me.LnkGLAcctBS.TabStop = True
    Me.LnkGLAcctBS.Text = "Shipping/Handling Acct"
    '
    'LnkGLAcctBD
    '
    Me.LnkGLAcctBD.AutoSize = True
    Me.LnkGLAcctBD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcctBD.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcctBD.Location = New System.Drawing.Point(407, 424)
    Me.LnkGLAcctBD.Name = "LnkGLAcctBD"
    Me.LnkGLAcctBD.Size = New System.Drawing.Size(74, 13)
    Me.LnkGLAcctBD.TabIndex = 243
    Me.LnkGLAcctBD.TabStop = True
    Me.LnkGLAcctBD.Text = "Discount Acct"
    '
    'TxtSubfs
    '
    Me.TxtSubfs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSubfs.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSubfs.Location = New System.Drawing.Point(721, 446)
    Me.TxtSubfs.MaxLength = 4
    Me.TxtSubfs.Name = "TxtSubfs"
    Me.TxtSubfs.Size = New System.Drawing.Size(45, 22)
    Me.TxtSubfs.TabIndex = 50
    '
    'TxtFnpgs
    '
    Me.TxtFnpgs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFnpgs.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFnpgs.Location = New System.Drawing.Point(670, 446)
    Me.TxtFnpgs.MaxLength = 4
    Me.TxtFnpgs.Name = "TxtFnpgs"
    Me.TxtFnpgs.Size = New System.Drawing.Size(45, 22)
    Me.TxtFnpgs.TabIndex = 49
    '
    'TxtObnbs
    '
    Me.TxtObnbs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObnbs.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObnbs.Location = New System.Drawing.Point(634, 446)
    Me.TxtObnbs.MaxLength = 3
    Me.TxtObnbs.Name = "TxtObnbs"
    Me.TxtObnbs.Size = New System.Drawing.Size(32, 22)
    Me.TxtObnbs.TabIndex = 48
    '
    'TxtDpnbs
    '
    Me.TxtDpnbs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDpnbs.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDpnbs.Location = New System.Drawing.Point(583, 446)
    Me.TxtDpnbs.MaxLength = 4
    Me.TxtDpnbs.Name = "TxtDpnbs"
    Me.TxtDpnbs.Size = New System.Drawing.Size(45, 22)
    Me.TxtDpnbs.TabIndex = 47
    '
    'TxtSfuns
    '
    Me.TxtSfuns.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfuns.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfuns.Location = New System.Drawing.Point(545, 446)
    Me.TxtSfuns.MaxLength = 3
    Me.TxtSfuns.Name = "TxtSfuns"
    Me.TxtSfuns.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfuns.TabIndex = 46
    '
    'TxtSubfd
    '
    Me.TxtSubfd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSubfd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSubfd.Location = New System.Drawing.Point(721, 420)
    Me.TxtSubfd.MaxLength = 4
    Me.TxtSubfd.Name = "TxtSubfd"
    Me.TxtSubfd.Size = New System.Drawing.Size(45, 22)
    Me.TxtSubfd.TabIndex = 42
    '
    'TxtFnpgd
    '
    Me.TxtFnpgd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFnpgd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFnpgd.Location = New System.Drawing.Point(670, 420)
    Me.TxtFnpgd.MaxLength = 4
    Me.TxtFnpgd.Name = "TxtFnpgd"
    Me.TxtFnpgd.Size = New System.Drawing.Size(45, 22)
    Me.TxtFnpgd.TabIndex = 41
    '
    'TxtObnbd
    '
    Me.TxtObnbd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObnbd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObnbd.Location = New System.Drawing.Point(634, 420)
    Me.TxtObnbd.MaxLength = 3
    Me.TxtObnbd.Name = "TxtObnbd"
    Me.TxtObnbd.Size = New System.Drawing.Size(32, 22)
    Me.TxtObnbd.TabIndex = 40
    '
    'TxtDpnbd
    '
    Me.TxtDpnbd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDpnbd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDpnbd.Location = New System.Drawing.Point(583, 420)
    Me.TxtDpnbd.MaxLength = 4
    Me.TxtDpnbd.Name = "TxtDpnbd"
    Me.TxtDpnbd.Size = New System.Drawing.Size(45, 22)
    Me.TxtDpnbd.TabIndex = 39
    '
    'TxtSfudd
    '
    Me.TxtSfudd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfudd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfudd.Location = New System.Drawing.Point(545, 420)
    Me.TxtSfudd.MaxLength = 3
    Me.TxtSfudd.Name = "TxtSfudd"
    Me.TxtSfudd.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfudd.TabIndex = 38
    '
    'TxtFdnbs
    '
    Me.TxtFdnbs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFdnbs.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFdnbs.Location = New System.Drawing.Point(507, 446)
    Me.TxtFdnbs.MaxLength = 3
    Me.TxtFdnbs.Name = "TxtFdnbs"
    Me.TxtFdnbs.Size = New System.Drawing.Size(32, 22)
    Me.TxtFdnbs.TabIndex = 45
    '
    'TxtFdnbd
    '
    Me.TxtFdnbd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFdnbd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFdnbd.Location = New System.Drawing.Point(507, 420)
    Me.TxtFdnbd.MaxLength = 3
    Me.TxtFdnbd.Name = "TxtFdnbd"
    Me.TxtFdnbd.Size = New System.Drawing.Size(32, 22)
    Me.TxtFdnbd.TabIndex = 37
    '
    'Label18
    '
    Me.Label18.AutoSize = True
    Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label18.ForeColor = System.Drawing.Color.Black
    Me.Label18.Location = New System.Drawing.Point(220, 450)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(86, 13)
    Me.Label18.TabIndex = 242
    Me.Label18.Text = "Ship/Handling %"
    '
    'TxtOrshp
    '
    Me.TxtOrshp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOrshp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOrshp.Location = New System.Drawing.Point(320, 446)
    Me.TxtOrshp.MaxLength = 5
    Me.TxtOrshp.Name = "TxtOrshp"
    Me.TxtOrshp.Size = New System.Drawing.Size(51, 22)
    Me.TxtOrshp.TabIndex = 44
    Me.TxtOrshp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label17
    '
    Me.Label17.AutoSize = True
    Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label17.ForeColor = System.Drawing.Color.Black
    Me.Label17.Location = New System.Drawing.Point(220, 425)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(89, 13)
    Me.Label17.TabIndex = 240
    Me.Label17.Text = "Order Discount %"
    '
    'TxtOrdsp
    '
    Me.TxtOrdsp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOrdsp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOrdsp.Location = New System.Drawing.Point(320, 421)
    Me.TxtOrdsp.MaxLength = 5
    Me.TxtOrdsp.Name = "TxtOrdsp"
    Me.TxtOrdsp.Size = New System.Drawing.Size(51, 22)
    Me.TxtOrdsp.TabIndex = 36
    Me.TxtOrdsp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label16
    '
    Me.Label16.AutoSize = True
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.ForeColor = System.Drawing.Color.Black
    Me.Label16.Location = New System.Drawing.Point(4, 452)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(66, 13)
    Me.Label16.TabIndex = 238
    Me.Label16.Text = "Tax ID Type"
    '
    'TxtTxtyp
    '
    Me.TxtTxtyp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTxtyp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTxtyp.Location = New System.Drawing.Point(93, 444)
    Me.TxtTxtyp.MaxLength = 1
    Me.TxtTxtyp.Name = "TxtTxtyp"
    Me.TxtTxtyp.Size = New System.Drawing.Size(22, 22)
    Me.TxtTxtyp.TabIndex = 43
    '
    'Label15
    '
    Me.Label15.AutoSize = True
    Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label15.ForeColor = System.Drawing.Color.Black
    Me.Label15.Location = New System.Drawing.Point(4, 424)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(61, 13)
    Me.Label15.TabIndex = 236
    Me.Label15.Text = "TIN/SS No"
    '
    'TxtTaxid
    '
    Me.TxtTaxid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTaxid.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTaxid.Location = New System.Drawing.Point(91, 416)
    Me.TxtTaxid.MaxLength = 9
    Me.TxtTaxid.Name = "TxtTaxid"
    Me.TxtTaxid.Size = New System.Drawing.Size(88, 22)
    Me.TxtTaxid.TabIndex = 35
    Me.TxtTaxid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label14
    '
    Me.Label14.AutoSize = True
    Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label14.ForeColor = System.Drawing.Color.Black
    Me.Label14.Location = New System.Drawing.Point(497, 183)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(24, 13)
    Me.Label14.TabIndex = 234
    Me.Label14.Text = "Fax"
    '
    'TxtFaxno
    '
    Me.TxtFaxno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFaxno.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFaxno.Location = New System.Drawing.Point(531, 179)
    Me.TxtFaxno.MaxLength = 10
    Me.TxtFaxno.Name = "TxtFaxno"
    Me.TxtFaxno.Size = New System.Drawing.Size(88, 22)
    Me.TxtFaxno.TabIndex = 12
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label13.ForeColor = System.Drawing.Color.Black
    Me.Label13.Location = New System.Drawing.Point(319, 178)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(53, 13)
    Me.Label13.TabIndex = 232
    Me.Label13.Text = "Alt Phone"
    '
    'TxtPhalt
    '
    Me.TxtPhalt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPhalt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhalt.Location = New System.Drawing.Point(375, 174)
    Me.TxtPhalt.MaxLength = 10
    Me.TxtPhalt.Name = "TxtPhalt"
    Me.TxtPhalt.Size = New System.Drawing.Size(88, 22)
    Me.TxtPhalt.TabIndex = 11
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.ForeColor = System.Drawing.Color.Black
    Me.Label12.Location = New System.Drawing.Point(216, 178)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(22, 13)
    Me.Label12.TabIndex = 10
    Me.Label12.Text = "Ext"
    '
    'TxtPhext
    '
    Me.TxtPhext.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPhext.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhext.Location = New System.Drawing.Point(244, 174)
    Me.TxtPhext.MaxLength = 4
    Me.TxtPhext.Name = "TxtPhext"
    Me.TxtPhext.Size = New System.Drawing.Size(41, 22)
    Me.TxtPhext.TabIndex = 229
    '
    'ChkAcrec
    '
    Me.ChkAcrec.AutoSize = True
    Me.ChkAcrec.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAcrec.Location = New System.Drawing.Point(616, 149)
    Me.ChkAcrec.Name = "ChkAcrec"
    Me.ChkAcrec.Size = New System.Drawing.Size(111, 17)
    Me.ChkAcrec.TabIndex = 17
    Me.ChkAcrec.Text = "Suspend Activity?"
    Me.ChkAcrec.UseVisualStyleBackColor = True
    '
    'TxtVncat
    '
    Me.TxtVncat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVncat.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVncat.Location = New System.Drawing.Point(715, 64)
    Me.TxtVncat.MaxLength = 3
    Me.TxtVncat.Name = "TxtVncat"
    Me.TxtVncat.Size = New System.Drawing.Size(32, 22)
    Me.TxtVncat.TabIndex = 14
    '
    'TxtPyzipe
    '
    Me.TxtPyzipe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPyzipe.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPyzipe.Location = New System.Drawing.Point(825, 368)
    Me.TxtPyzipe.MaxLength = 4
    Me.TxtPyzipe.Name = "TxtPyzipe"
    Me.TxtPyzipe.Size = New System.Drawing.Size(41, 22)
    Me.TxtPyzipe.TabIndex = 31
    '
    'TxtPyzip
    '
    Me.TxtPyzip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPyzip.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPyzip.Location = New System.Drawing.Point(768, 368)
    Me.TxtPyzip.MaxLength = 5
    Me.TxtPyzip.Name = "TxtPyzip"
    Me.TxtPyzip.Size = New System.Drawing.Size(51, 22)
    Me.TxtPyzip.TabIndex = 30
    '
    'TxtPyad4
    '
    Me.TxtPyad4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPyad4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPyad4.Location = New System.Drawing.Point(545, 345)
    Me.TxtPyad4.MaxLength = 40
    Me.TxtPyad4.Name = "TxtPyad4"
    Me.TxtPyad4.Size = New System.Drawing.Size(325, 22)
    Me.TxtPyad4.TabIndex = 29
    '
    'TxtPyad3
    '
    Me.TxtPyad3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPyad3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPyad3.Location = New System.Drawing.Point(545, 323)
    Me.TxtPyad3.MaxLength = 40
    Me.TxtPyad3.Name = "TxtPyad3"
    Me.TxtPyad3.Size = New System.Drawing.Size(325, 22)
    Me.TxtPyad3.TabIndex = 28
    '
    'TxtPyad2
    '
    Me.TxtPyad2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPyad2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPyad2.Location = New System.Drawing.Point(545, 301)
    Me.TxtPyad2.MaxLength = 40
    Me.TxtPyad2.Name = "TxtPyad2"
    Me.TxtPyad2.Size = New System.Drawing.Size(325, 22)
    Me.TxtPyad2.TabIndex = 27
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.ForeColor = System.Drawing.Color.Black
    Me.Label10.Location = New System.Drawing.Point(463, 283)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(45, 13)
    Me.Label10.TabIndex = 221
    Me.Label10.Text = "Address"
    '
    'TxtPyad1
    '
    Me.TxtPyad1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPyad1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPyad1.Location = New System.Drawing.Point(545, 279)
    Me.TxtPyad1.MaxLength = 40
    Me.TxtPyad1.Name = "TxtPyad1"
    Me.TxtPyad1.Size = New System.Drawing.Size(325, 22)
    Me.TxtPyad1.TabIndex = 26
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.ForeColor = System.Drawing.Color.Black
    Me.Label11.Location = New System.Drawing.Point(463, 257)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(72, 13)
    Me.Label11.TabIndex = 219
    Me.Label11.Text = "Pay To Name"
    '
    'TxtPynam
    '
    Me.TxtPynam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPynam.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPynam.Location = New System.Drawing.Point(545, 253)
    Me.TxtPynam.MaxLength = 40
    Me.TxtPynam.Name = "TxtPynam"
    Me.TxtPynam.Size = New System.Drawing.Size(325, 22)
    Me.TxtPynam.TabIndex = 25
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.ForeColor = System.Drawing.Color.Black
    Me.Label9.Location = New System.Drawing.Point(615, 125)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(51, 13)
    Me.Label9.TabIndex = 217
    Me.Label9.Text = "Sort Field"
    '
    'TxtVsort
    '
    Me.TxtVsort.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVsort.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVsort.Location = New System.Drawing.Point(715, 121)
    Me.TxtVsort.MaxLength = 7
    Me.TxtVsort.Name = "TxtVsort"
    Me.TxtVsort.Size = New System.Drawing.Size(62, 22)
    Me.TxtVsort.TabIndex = 16
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.ForeColor = System.Drawing.Color.Black
    Me.Label7.Location = New System.Drawing.Point(615, 97)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(36, 13)
    Me.Label7.TabIndex = 215
    Me.Label7.Text = "Terms"
    '
    'TxtDuedy
    '
    Me.TxtDuedy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDuedy.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDuedy.Location = New System.Drawing.Point(715, 93)
    Me.TxtDuedy.MaxLength = 3
    Me.TxtDuedy.Name = "TxtDuedy"
    Me.TxtDuedy.Size = New System.Drawing.Size(32, 22)
    Me.TxtDuedy.TabIndex = 15
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.ForeColor = System.Drawing.Color.Black
    Me.Label6.Location = New System.Drawing.Point(468, 38)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(75, 13)
    Me.Label6.TabIndex = 213
    Me.Label6.Text = "Contact Name"
    '
    'TxtContn
    '
    Me.TxtContn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtContn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtContn.Location = New System.Drawing.Point(545, 34)
    Me.TxtContn.MaxLength = 40
    Me.TxtContn.Name = "TxtContn"
    Me.TxtContn.Size = New System.Drawing.Size(329, 22)
    Me.TxtContn.TabIndex = 13
    '
    'ChkFemcd
    '
    Me.ChkFemcd.AutoSize = True
    Me.ChkFemcd.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkFemcd.Location = New System.Drawing.Point(281, 393)
    Me.ChkFemcd.Name = "ChkFemcd"
    Me.ChkFemcd.Size = New System.Drawing.Size(60, 17)
    Me.ChkFemcd.TabIndex = 34
    Me.ChkFemcd.Text = "Rents?"
    Me.ChkFemcd.UseVisualStyleBackColor = True
    '
    'ChkMincd
    '
    Me.ChkMincd.AutoSize = True
    Me.ChkMincd.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkMincd.Location = New System.Drawing.Point(145, 393)
    Me.ChkMincd.Name = "ChkMincd"
    Me.ChkMincd.Size = New System.Drawing.Size(96, 17)
    Me.ChkMincd.TabIndex = 33
    Me.ChkMincd.Text = "Other Income?"
    Me.ChkMincd.UseVisualStyleBackColor = True
    '
    'TxtOzipe
    '
    Me.TxtOzipe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOzipe.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOzipe.Location = New System.Drawing.Point(381, 368)
    Me.TxtOzipe.MaxLength = 4
    Me.TxtOzipe.Name = "TxtOzipe"
    Me.TxtOzipe.Size = New System.Drawing.Size(41, 22)
    Me.TxtOzipe.TabIndex = 24
    '
    'TxtOzip
    '
    Me.TxtOzip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOzip.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOzip.Location = New System.Drawing.Point(331, 368)
    Me.TxtOzip.MaxLength = 5
    Me.TxtOzip.Name = "TxtOzip"
    Me.TxtOzip.Size = New System.Drawing.Size(51, 22)
    Me.TxtOzip.TabIndex = 23
    '
    'TxtOrad4
    '
    Me.TxtOrad4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOrad4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOrad4.Location = New System.Drawing.Point(93, 345)
    Me.TxtOrad4.MaxLength = 40
    Me.TxtOrad4.Name = "TxtOrad4"
    Me.TxtOrad4.Size = New System.Drawing.Size(327, 22)
    Me.TxtOrad4.TabIndex = 22
    '
    'TxtOrad3
    '
    Me.TxtOrad3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOrad3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOrad3.Location = New System.Drawing.Point(93, 323)
    Me.TxtOrad3.MaxLength = 40
    Me.TxtOrad3.Name = "TxtOrad3"
    Me.TxtOrad3.Size = New System.Drawing.Size(327, 22)
    Me.TxtOrad3.TabIndex = 21
    '
    'TxtOrad2
    '
    Me.TxtOrad2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOrad2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOrad2.Location = New System.Drawing.Point(93, 301)
    Me.TxtOrad2.MaxLength = 40
    Me.TxtOrad2.Name = "TxtOrad2"
    Me.TxtOrad2.Size = New System.Drawing.Size(327, 22)
    Me.TxtOrad2.TabIndex = 20
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.ForeColor = System.Drawing.Color.Black
    Me.Label1.Location = New System.Drawing.Point(6, 283)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(45, 13)
    Me.Label1.TabIndex = 204
    Me.Label1.Text = "Address"
    '
    'TxtOrad1
    '
    Me.TxtOrad1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOrad1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOrad1.Location = New System.Drawing.Point(93, 279)
    Me.TxtOrad1.MaxLength = 40
    Me.TxtOrad1.Name = "TxtOrad1"
    Me.TxtOrad1.Size = New System.Drawing.Size(327, 22)
    Me.TxtOrad1.TabIndex = 19
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.ForeColor = System.Drawing.Color.Black
    Me.Label2.Location = New System.Drawing.Point(6, 257)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(64, 13)
    Me.Label2.TabIndex = 202
    Me.Label2.Text = "Order Name"
    '
    'TxtOrnam
    '
    Me.TxtOrnam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOrnam.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOrnam.Location = New System.Drawing.Point(93, 253)
    Me.TxtOrnam.MaxLength = 40
    Me.TxtOrnam.Name = "TxtOrnam"
    Me.TxtOrnam.Size = New System.Drawing.Size(327, 22)
    Me.TxtOrnam.TabIndex = 18
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.ForeColor = System.Drawing.Color.Black
    Me.Label5.Location = New System.Drawing.Point(4, 178)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(38, 13)
    Me.Label5.TabIndex = 200
    Me.Label5.Text = "Phone"
    '
    'TxtVphon
    '
    Me.TxtVphon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVphon.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVphon.Location = New System.Drawing.Point(91, 174)
    Me.TxtVphon.MaxLength = 10
    Me.TxtVphon.Name = "TxtVphon"
    Me.TxtVphon.Size = New System.Drawing.Size(88, 22)
    Me.TxtVphon.TabIndex = 9
    '
    'TxtVzipe
    '
    Me.TxtVzipe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVzipe.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVzipe.Location = New System.Drawing.Point(503, 132)
    Me.TxtVzipe.MaxLength = 4
    Me.TxtVzipe.Name = "TxtVzipe"
    Me.TxtVzipe.Size = New System.Drawing.Size(41, 22)
    Me.TxtVzipe.TabIndex = 8
    '
    'TxtVzip
    '
    Me.TxtVzip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVzip.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVzip.Location = New System.Drawing.Point(446, 132)
    Me.TxtVzip.MaxLength = 5
    Me.TxtVzip.Name = "TxtVzip"
    Me.TxtVzip.Size = New System.Drawing.Size(51, 22)
    Me.TxtVzip.TabIndex = 7
    '
    'TxtVadd4
    '
    Me.TxtVadd4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVadd4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVadd4.Location = New System.Drawing.Point(93, 132)
    Me.TxtVadd4.MaxLength = 40
    Me.TxtVadd4.Name = "TxtVadd4"
    Me.TxtVadd4.Size = New System.Drawing.Size(327, 22)
    Me.TxtVadd4.TabIndex = 6
    '
    'TxtVadd3
    '
    Me.TxtVadd3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVadd3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVadd3.Location = New System.Drawing.Point(93, 110)
    Me.TxtVadd3.MaxLength = 40
    Me.TxtVadd3.Name = "TxtVadd3"
    Me.TxtVadd3.Size = New System.Drawing.Size(327, 22)
    Me.TxtVadd3.TabIndex = 5
    '
    'TxtVadd2
    '
    Me.TxtVadd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVadd2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVadd2.Location = New System.Drawing.Point(93, 88)
    Me.TxtVadd2.MaxLength = 40
    Me.TxtVadd2.Name = "TxtVadd2"
    Me.TxtVadd2.Size = New System.Drawing.Size(327, 22)
    Me.TxtVadd2.TabIndex = 4
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.ForeColor = System.Drawing.Color.Black
    Me.Label3.Location = New System.Drawing.Point(6, 70)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(45, 13)
    Me.Label3.TabIndex = 193
    Me.Label3.Text = "Address"
    '
    'TxtVadd1
    '
    Me.TxtVadd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVadd1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVadd1.Location = New System.Drawing.Point(93, 66)
    Me.TxtVadd1.MaxLength = 40
    Me.TxtVadd1.Name = "TxtVadd1"
    Me.TxtVadd1.Size = New System.Drawing.Size(327, 22)
    Me.TxtVadd1.TabIndex = 2
    '
    'ChkF1099
    '
    Me.ChkF1099.AutoSize = True
    Me.ChkF1099.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkF1099.Location = New System.Drawing.Point(7, 393)
    Me.ChkF1099.Name = "ChkF1099"
    Me.ChkF1099.Size = New System.Drawing.Size(93, 17)
    Me.ChkF1099.TabIndex = 32
    Me.ChkF1099.Text = "1099 Vendor?"
    Me.ChkF1099.UseVisualStyleBackColor = True
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.ForeColor = System.Drawing.Color.Black
    Me.Label8.Location = New System.Drawing.Point(6, 44)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(72, 13)
    Me.Label8.TabIndex = 187
    Me.Label8.Text = "Vendor Name"
    '
    'TxtVennm
    '
    Me.TxtVennm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVennm.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVennm.Location = New System.Drawing.Point(93, 40)
    Me.TxtVennm.MaxLength = 40
    Me.TxtVennm.Name = "TxtVennm"
    Me.TxtVennm.Size = New System.Drawing.Size(327, 22)
    Me.TxtVennm.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.ForeColor = System.Drawing.Color.Black
    Me.Label4.Location = New System.Drawing.Point(6, 14)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(81, 13)
    Me.Label4.TabIndex = 176
    Me.Label4.Text = "Vendor Number"
    '
    'TxtVndnr
    '
    Me.TxtVndnr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVndnr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVndnr.Location = New System.Drawing.Point(93, 12)
    Me.TxtVndnr.MaxLength = 5
    Me.TxtVndnr.Name = "TxtVndnr"
    Me.TxtVndnr.Size = New System.Drawing.Size(45, 22)
    Me.TxtVndnr.TabIndex = 0
    '
    'TpActivity
    '
    Me.TpActivity.AutoScroll = True
    Me.TpActivity.Controls.Add(Me.DataGrdView)
    Me.TpActivity.Controls.Add(Me.BtnFind)
    Me.TpActivity.Controls.Add(Me.TxtInvNo)
    Me.TpActivity.Controls.Add(Me.DtPckInv)
    Me.TpActivity.Controls.Add(Me.RbInvDate)
    Me.TpActivity.Controls.Add(Me.RbInvNo)
    Me.TpActivity.Controls.Add(Me.RbChkDate)
    Me.TpActivity.Controls.Add(Me.DtPckChk)
    Me.TpActivity.Location = New System.Drawing.Point(4, 22)
    Me.TpActivity.Name = "TpActivity"
    Me.TpActivity.Padding = New System.Windows.Forms.Padding(3)
    Me.TpActivity.Size = New System.Drawing.Size(902, 507)
    Me.TpActivity.TabIndex = 1
    Me.TpActivity.Text = "Activity"
    Me.TpActivity.UseVisualStyleBackColor = True
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGrdView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle8
    Me.DataGrdView.Location = New System.Drawing.Point(15, 61)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGrdView.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(757, 440)
    Me.DataGrdView.TabIndex = 206
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(347, 13)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(57, 40)
    Me.BtnFind.TabIndex = 178
    Me.BtnFind.Text = "Find"
    Me.BtnFind.UseVisualStyleBackColor = True
    '
    'TxtInvNo
    '
    Me.TxtInvNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtInvNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtInvNo.Location = New System.Drawing.Point(114, 33)
    Me.TxtInvNo.MaxLength = 20
    Me.TxtInvNo.Name = "TxtInvNo"
    Me.TxtInvNo.Size = New System.Drawing.Size(124, 22)
    Me.TxtInvNo.TabIndex = 177
    Me.TxtInvNo.Visible = False
    '
    'DtPckInv
    '
    Me.DtPckInv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckInv.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckInv.Location = New System.Drawing.Point(244, 35)
    Me.DtPckInv.Name = "DtPckInv"
    Me.DtPckInv.Size = New System.Drawing.Size(84, 20)
    Me.DtPckInv.TabIndex = 176
    Me.DtPckInv.Visible = False
    '
    'RbInvDate
    '
    Me.RbInvDate.AutoSize = True
    Me.RbInvDate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbInvDate.Location = New System.Drawing.Point(242, 13)
    Me.RbInvDate.Name = "RbInvDate"
    Me.RbInvDate.Size = New System.Drawing.Size(86, 17)
    Me.RbInvDate.TabIndex = 175
    Me.RbInvDate.Text = "Invoice Date"
    Me.RbInvDate.UseVisualStyleBackColor = True
    '
    'RbInvNo
    '
    Me.RbInvNo.AutoSize = True
    Me.RbInvNo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbInvNo.Location = New System.Drawing.Point(136, 13)
    Me.RbInvNo.Name = "RbInvNo"
    Me.RbInvNo.Size = New System.Drawing.Size(77, 17)
    Me.RbInvNo.TabIndex = 174
    Me.RbInvNo.Text = "Invoice No"
    Me.RbInvNo.UseVisualStyleBackColor = True
    '
    'RbChkDate
    '
    Me.RbChkDate.AutoSize = True
    Me.RbChkDate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbChkDate.Checked = True
    Me.RbChkDate.Location = New System.Drawing.Point(24, 13)
    Me.RbChkDate.Name = "RbChkDate"
    Me.RbChkDate.Size = New System.Drawing.Size(82, 17)
    Me.RbChkDate.TabIndex = 173
    Me.RbChkDate.TabStop = True
    Me.RbChkDate.Text = "Check Date"
    Me.RbChkDate.UseVisualStyleBackColor = True
    '
    'DtPckChk
    '
    Me.DtPckChk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckChk.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckChk.Location = New System.Drawing.Point(24, 35)
    Me.DtPckChk.Name = "DtPckChk"
    Me.DtPckChk.Size = New System.Drawing.Size(84, 20)
    Me.DtPckChk.TabIndex = 172
    '
    'TpPO
    '
    Me.TpPO.Controls.Add(Me.DataGrdView2)
    Me.TpPO.Controls.Add(Me.TxtPONbr)
    Me.TpPO.Controls.Add(Me.Label21)
    Me.TpPO.Controls.Add(Me.Label19)
    Me.TpPO.Controls.Add(Me.TxtFscyr)
    Me.TpPO.Controls.Add(Me.BtnFindPO)
    Me.TpPO.Location = New System.Drawing.Point(4, 22)
    Me.TpPO.Name = "TpPO"
    Me.TpPO.Size = New System.Drawing.Size(902, 507)
    Me.TpPO.TabIndex = 2
    Me.TpPO.Text = "PO Inquiry"
    Me.TpPO.UseVisualStyleBackColor = True
    '
    'DataGrdView2
    '
    Me.DataGrdView2.AllowUserToAddRows = False
    Me.DataGrdView2.AllowUserToDeleteRows = False
    Me.DataGrdView2.BackgroundColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGrdView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
    Me.DataGrdView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView2.DefaultCellStyle = DataGridViewCellStyle11
    Me.DataGrdView2.Location = New System.Drawing.Point(19, 35)
    Me.DataGrdView2.MultiSelect = False
    Me.DataGrdView2.Name = "DataGrdView2"
    Me.DataGrdView2.ReadOnly = True
    DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGrdView2.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
    Me.DataGrdView2.RowTemplate.Height = 16
    Me.DataGrdView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView2.Size = New System.Drawing.Size(747, 455)
    Me.DataGrdView2.TabIndex = 206
    '
    'TxtPONbr
    '
    Me.TxtPONbr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPONbr.Location = New System.Drawing.Point(195, 6)
    Me.TxtPONbr.MaxLength = 7
    Me.TxtPONbr.Name = "TxtPONbr"
    Me.TxtPONbr.Size = New System.Drawing.Size(77, 22)
    Me.TxtPONbr.TabIndex = 183
    '
    'Label21
    '
    Me.Label21.AutoSize = True
    Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label21.ForeColor = System.Drawing.Color.Black
    Me.Label21.Location = New System.Drawing.Point(130, 9)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(62, 13)
    Me.Label21.TabIndex = 182
    Me.Label21.Text = "PO Number"
    '
    'Label19
    '
    Me.Label19.AutoSize = True
    Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label19.ForeColor = System.Drawing.Color.Black
    Me.Label19.Location = New System.Drawing.Point(16, 9)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(59, 13)
    Me.Label19.TabIndex = 181
    Me.Label19.Text = "Fiscal Year"
    '
    'TxtFscyr
    '
    Me.TxtFscyr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFscyr.Location = New System.Drawing.Point(81, 5)
    Me.TxtFscyr.MaxLength = 4
    Me.TxtFscyr.Name = "TxtFscyr"
    Me.TxtFscyr.Size = New System.Drawing.Size(43, 22)
    Me.TxtFscyr.TabIndex = 180
    '
    'BtnFindPO
    '
    Me.BtnFindPO.Location = New System.Drawing.Point(278, 4)
    Me.BtnFindPO.Name = "BtnFindPO"
    Me.BtnFindPO.Size = New System.Drawing.Size(57, 25)
    Me.BtnFindPO.TabIndex = 179
    Me.BtnFindPO.Text = "Find"
    Me.BtnFindPO.UseVisualStyleBackColor = True
    '
    'Label20
    '
    Me.Label20.AutoSize = True
    Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label20.ForeColor = System.Drawing.Color.Black
    Me.Label20.Location = New System.Drawing.Point(32, 30)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(71, 13)
    Me.Label20.TabIndex = 173
    Me.Label20.Text = "Last Payment"
    '
    'LblYtdpa
    '
    Me.LblYtdpa.BackColor = System.Drawing.Color.Aqua
    Me.LblYtdpa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblYtdpa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblYtdpa.Location = New System.Drawing.Point(331, 32)
    Me.LblYtdpa.Name = "LblYtdpa"
    Me.LblYtdpa.Size = New System.Drawing.Size(89, 16)
    Me.LblYtdpa.TabIndex = 177
    Me.LblYtdpa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label29
    '
    Me.Label29.AutoSize = True
    Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label29.Location = New System.Drawing.Point(234, 32)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(78, 13)
    Me.Label29.TabIndex = 176
    Me.Label29.Text = "YTD Payments"
    '
    'LblFscpa
    '
    Me.LblFscpa.BackColor = System.Drawing.Color.Aqua
    Me.LblFscpa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblFscpa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFscpa.Location = New System.Drawing.Point(331, 52)
    Me.LblFscpa.Name = "LblFscpa"
    Me.LblFscpa.Size = New System.Drawing.Size(89, 16)
    Me.LblFscpa.TabIndex = 179
    Me.LblFscpa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label22
    '
    Me.Label22.AutoSize = True
    Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label22.Location = New System.Drawing.Point(234, 52)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(83, 13)
    Me.Label22.TabIndex = 178
    Me.Label22.Text = "Fiscal Payments"
    '
    'LblYtdpr
    '
    Me.LblYtdpr.BackColor = System.Drawing.Color.Aqua
    Me.LblYtdpr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblYtdpr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblYtdpr.Location = New System.Drawing.Point(543, 30)
    Me.LblYtdpr.Name = "LblYtdpr"
    Me.LblYtdpr.Size = New System.Drawing.Size(89, 16)
    Me.LblYtdpr.TabIndex = 181
    Me.LblYtdpr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label24
    '
    Me.Label24.AutoSize = True
    Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label24.Location = New System.Drawing.Point(450, 32)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(82, 13)
    Me.Label24.TabIndex = 180
    Me.Label24.Text = "YTD Purchases"
    '
    'LblFscpr
    '
    Me.LblFscpr.BackColor = System.Drawing.Color.Aqua
    Me.LblFscpr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblFscpr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFscpr.Location = New System.Drawing.Point(543, 49)
    Me.LblFscpr.Name = "LblFscpr"
    Me.LblFscpr.Size = New System.Drawing.Size(89, 16)
    Me.LblFscpr.TabIndex = 183
    Me.LblFscpr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label26
    '
    Me.Label26.AutoSize = True
    Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label26.Location = New System.Drawing.Point(450, 51)
    Me.Label26.Name = "Label26"
    Me.Label26.Size = New System.Drawing.Size(87, 13)
    Me.Label26.TabIndex = 182
    Me.Label26.Text = "Fiscal Purchases"
    '
    'LblDtlpd
    '
    Me.LblDtlpd.BackColor = System.Drawing.Color.Aqua
    Me.LblDtlpd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblDtlpd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDtlpd.Location = New System.Drawing.Point(109, 29)
    Me.LblDtlpd.Name = "LblDtlpd"
    Me.LblDtlpd.Size = New System.Drawing.Size(67, 16)
    Me.LblDtlpd.TabIndex = 184
    Me.LblDtlpd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblVennm
    '
    Me.LblVennm.AutoSize = True
    Me.LblVennm.Location = New System.Drawing.Point(13, 9)
    Me.LblVennm.Name = "LblVennm"
    Me.LblVennm.Size = New System.Drawing.Size(84, 13)
    Me.LblVennm.TabIndex = 185
    Me.LblVennm.Text = "<Vendor Name>"
    Me.LblVennm.UseMnemonic = False
    '
    'LblSuspended
    '
    Me.LblSuspended.AutoSize = True
    Me.LblSuspended.ForeColor = System.Drawing.Color.Magenta
    Me.LblSuspended.Location = New System.Drawing.Point(744, 9)
    Me.LblSuspended.Name = "LblSuspended"
    Me.LblSuspended.Size = New System.Drawing.Size(61, 13)
    Me.LblSuspended.TabIndex = 186
    Me.LblSuspended.Text = "Suspended"
    '
    'FrmAP101C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(921, 643)
    Me.Controls.Add(Me.LblSuspended)
    Me.Controls.Add(Me.LblVennm)
    Me.Controls.Add(Me.LblDtlpd)
    Me.Controls.Add(Me.Label20)
    Me.Controls.Add(Me.LblFscpr)
    Me.Controls.Add(Me.Label26)
    Me.Controls.Add(Me.LblYtdpr)
    Me.Controls.Add(Me.Label24)
    Me.Controls.Add(Me.LblFscpa)
    Me.Controls.Add(Me.Label22)
    Me.Controls.Add(Me.LblYtdpa)
    Me.Controls.Add(Me.Label29)
    Me.Controls.Add(Me.TabCtl1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmAP101C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TabCtl1.ResumeLayout(False)
    Me.TpEdit.ResumeLayout(False)
    Me.TpEdit.PerformLayout()
    Me.TpActivity.ResumeLayout(False)
    Me.TpActivity.PerformLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TpPO.ResumeLayout(False)
    Me.TpPO.PerformLayout()
    CType(Me.DataGrdView2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmAP101C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim ds3 As DataSet = New DataSet
    Dim WrkAmount As Decimal
    Dim WrkKey As String
    Dim WrkAttachcount As Integer
    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect
    myAPEHSTL1 = New APEHSTL1.MyData()
    myAPEHSTL1.MyDBConn = myDBConnect
    myPOMASTLC = New POMASTL1.MyData()
    myPOMASTLC.MyDBConn = myDBConnect

    MyFrmAP101.TbarNew.Enabled = False
    MyFrmAP101.TBarSave.Enabled = True
    MyFrmAP101.TBarDelete.Enabled = False
    LblSuspended.Visible = False
    If MyInquiryMode Then
      TpEdit.Text = "View"
    End If
    If WrkVndnr <> "" Then
      MyUtils.SetTxtReadOnly(TxtVndnr)
    End If

    WrkSort = ""
    myVENDOR.GetOneRecordP(WrkVndnr)
    If myVENDOR.RecordNotFound Then
      TabCtl1.TabPages.Remove(TpActivity)
      TabCtl1.TabPages.Remove(TpPO)
      TpEdit.Select()
      MyUtils.ShowFocus(TxtVndnr)
      Exit Sub
    End If

    MyFrmAP101.TBarComments.Enabled = True
    TxtVndnr.Text = WrkVndnr
    WrkSort = Trim(myVENDOR._VSORT)
    WrkKey = MyFrmAP101C.TxtVndnr.Text
    WrkAttachcount = GetAttachcount("VENDOR", WrkKey)
    MyFrmAP101.TBarAttach.Text = WrkAttachcount & " Attachment(s)"
    MyFrmAP101.TBarAttach.Enabled = True

    If s_chg = False And s_full = False Then    '#sec
      MyFrmAP101.TBarSave.Visible = False
    End If

    With myVENDOR
      TxtVndnr.Text = Trim(._VNDNR)
      TxtVennm.Text = Trim(._VENNM)
      TxtVadd1.Text = Trim(._VADD1)
      TxtVadd2.Text = Trim(._VADD2)
      TxtVadd3.Text = Trim(._VADD3)
      TxtVadd4.Text = Trim(._VADD4)
      TxtVzip.Text = Trim(._VZIP)
      TxtVzipe.Text = Trim(._VZIPE)
      If ._VPHON > 0 Then
        TxtVphon.Text = ._VPHON
      End If
      If ._PHEXT > 0 Then
        TxtPhext.Text = ._PHEXT
      End If
      If ._PHALT > 0 Then
        TxtPhalt.Text = ._PHALT
      End If
      If ._FAXNO > 0 Then
        TxtFaxno.Text = ._FAXNO
      End If
      TxtOrnam.Text = Trim(._ORNAM)
      TxtOrad1.Text = Trim(._ORAD1)
      TxtOrad2.Text = Trim(._ORAD2)
      TxtOrad3.Text = Trim(._ORAD3)
      TxtOrad4.Text = Trim(._ORAD4)
      TxtOzip.Text = Trim(._OZIP)
      TxtOzipe.Text = Trim(._OZIPE)
      If ._TAXID > 0 Then
        TxtTaxid.Text = ._TAXID
      End If
      TxtContn.Text = Trim(._CONTN)
      TxtVncat.Text = Trim(._VNCAT)
      If ._DUEDY > 0 Then
        TxtDuedy.Text = ._DUEDY
      End If
      TxtVsort.Text = Trim(._VSORT)
      TxtPynam.Text = Trim(._PYNAM)
      TxtPyad1.Text = Trim(._PYAD1)
      TxtPyad2.Text = Trim(._PYAD2)
      TxtPyad3.Text = Trim(._PYAD3)
      TxtPyad4.Text = Trim(._PYAD4)
      TxtPyzip.Text = Trim(._PYZIP)
      TxtPyzipe.Text = Trim(._PYZIPE)
      TxtOrdsp.Text = ._ORDSP
      TxtOrshp.Text = ._ORSHP
      If ._FDNBD > 0 Then
        TxtFdnbd.Text = ._FDNBD
        TxtSfudd.Text = ._SFUDD
        TxtDpnbd.Text = ._DPNBD
        TxtObnbd.Text = ._OBNBD
        TxtFnpgd.Text = ._FNPGD
        TxtSubfd.Text = ._SUBFD
      End If
      If ._FDNBS > 0 Then
        TxtFdnbs.Text = ._FDNBS
        TxtSfuns.Text = ._SFUNS
        TxtDpnbs.Text = ._DPNBS
        TxtObnbs.Text = ._OBNBS
        TxtFnpgs.Text = ._FNPGS
        TxtSubfs.Text = ._SUBFS
      End If
      If ._ACREC = "S" Then
        ChkAcrec.Checked = True
        LblSuspended.Visible = True
      End If
      If ._F1099 = "Y" Then
        ChkF1099.Checked = True
      End If
      If ._MINCD = "Y" Then
        ChkMincd.Checked = True
      End If
      If ._FEMCD = "Y" Then
        ChkFemcd.Checked = True 'Rents
      End If
      '    TxtTxtyp.Text = 
      WrkAmount = myAPEHSTL1.GetVndnrFTDYTD(WrkVndnr, True, True)
      LblYtdpa.Text = Format(WrkAmount, "fixed")
      WrkAmount = myAPEHSTL1.GetVndnrFTDYTD(WrkVndnr, False, True)
      LblYtdpr.Text = Format(WrkAmount, "fixed")
      WrkAmount = myAPEHSTL1.GetVndnrFTDYTD(WrkVndnr, True, False)
      LblFscpa.Text = Format(WrkAmount, "fixed")
      WrkAmount = myAPEHSTL1.GetVndnrFTDYTD(WrkVndnr, False, False)
      LblFscpr.Text = Format(WrkAmount, "fixed")
      If ._DTLPD > 0 Then
        LblDtlpd.Text = MyUtils.GetDBDate(._DTLPD)
      End If
      LblVennm.Text = TxtVennm.Text
      TxtVemail.Text = Trim(._VEMAIL)

    End With




    ds2 = New DataSet
    BuildDS(ds2)
    RefreshAP()
    RefreshPO()


  End Sub

  Private Sub FrmAP101C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmAP101.TbarNew.Enabled = True
    MyFrmAP101.TBarSave.Enabled = False
    MyFrmAP101.TBarComments.Enabled = False
    MyFrmAP101.TBarAttach.Enabled = False
    MyFrmAP101.TBarAttach.Text = "Attachments"
    With MyFrmAP101B
      '6    .TxtPos.Text = WrkSort
      '    .FormatGrid()
      .Show()
    End With

  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    myVENDOR.GetOneRecordP(TxtVndnr.Text)
    If WrkVndnr = "" Then
      If Not myVENDOR.RecordNotFound Then
        Me.ErrProv.SetError(TxtVndnr, "Record already exists")
        Exit Sub
      End If
    End If

    If WrkVndnr <> "" Then
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myVENDOR.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      myVENDOR._VNDNR = TxtVndnr.Text
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myVENDOR.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()
  End Sub
  Private Sub MoveToFile()
    With myVENDOR
      ._VENNM = TxtVennm.Text
      ._VADD1 = TxtVadd1.Text
      ._VADD2 = TxtVadd2.Text
      ._VADD3 = TxtVadd3.Text
      ._VADD4 = TxtVadd4.Text
      ._VZIP = TxtVzip.Text
      ._VZIPE = TxtVzipe.Text
      ._VPHON = MyUtils.CnvSng(TxtVphon.Text)
      ._PHEXT = MyUtils.CnvSng(TxtPhext.Text)
      ._PHALT = MyUtils.CnvSng(TxtPhalt.Text)
      ._FAXNO = MyUtils.CnvSng(TxtFaxno.Text)
      ._ORNAM = TxtOrnam.Text
      ._ORAD1 = TxtOrad1.Text
      ._ORAD2 = TxtOrad2.Text
      ._ORAD3 = TxtOrad3.Text
      ._ORAD4 = TxtOrad4.Text
      ._OZIP = TxtOzip.Text
      ._OZIPE = TxtOzipe.Text
      ._TAXID = MyUtils.CnvSng(TxtTaxid.Text)
      ._CONTN = TxtContn.Text
      ._VNCAT = TxtVncat.Text
      ._DUEDY = MyUtils.CnvSng(TxtDuedy.Text)
      ._VSORT = TxtVsort.Text
      ._PYNAM = TxtPynam.Text
      ._PYAD1 = TxtPyad1.Text
      ._PYAD2 = TxtPyad2.Text
      ._PYAD3 = TxtPyad3.Text
      ._PYAD4 = TxtPyad4.Text
      ._PYZIP = TxtPyzip.Text
      ._PYZIPE = TxtPyzipe.Text
      ._ORDSP = MyUtils.CnvSng(TxtOrdsp.Text)
      ._ORSHP = MyUtils.CnvSng(TxtOrshp.Text)
      ._FDNBD = MyUtils.CnvSng(TxtFdnbd.Text)
      ._SFUDD = MyUtils.CnvSng(TxtSfudd.Text)
      ._DPNBD = MyUtils.CnvSng(TxtDpnbd.Text)
      ._OBNBD = MyUtils.CnvSng(TxtObnbd.Text)
      ._FNPGD = MyUtils.CnvSng(TxtFnpgd.Text)
      ._SUBFD = MyUtils.CnvSng(TxtSubfd.Text)
      ._FDNBS = MyUtils.CnvSng(TxtFdnbs.Text)
      ._SFUNS = MyUtils.CnvSng(TxtSfuns.Text)
      ._DPNBS = MyUtils.CnvSng(TxtDpnbs.Text)
      ._OBNBS = MyUtils.CnvSng(TxtObnbs.Text)
      ._FNPGS = MyUtils.CnvSng(TxtFnpgs.Text)
      ._SUBFS = MyUtils.CnvSng(TxtSubfs.Text)
      If ChkAcrec.Checked Then
        ._ACREC = "S"
      Else
        ._ACREC = ""
      End If
      If ChkF1099.Checked Then
        ._F1099 = "Y"
      Else
        ._F1099 = ""
      End If
      If ChkMincd.Checked Then
        ._MINCD = "Y"
      Else
        ._MINCD = ""
      End If
      If ChkFemcd.Checked Then
        ._FEMCD = "Y"
      Else
        ._FEMCD = ""
      End If
      ._VEMAIL = TxtVemail.Text
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtVsort.Text = String.Empty Then
      ErrorField(I) = "vsort"
      ErrorMsg(I) = "Vendor Sort is required"
      I = I + 1
    End If

    If InStr(TxtVsort.Text, "'") > 0 Then
      ErrorField(I) = "vsort"
      ErrorMsg(I) = "Single Quote is not allowed"
      I = I + 1
    End If

    If TxtVndnr.Text = String.Empty Then
      ErrorField(I) = "vndnr"
      ErrorMsg(I) = "Vendor Number is required"
      I = I + 1
    End If

    If TxtVennm.Text = String.Empty Then
      ErrorField(I) = "vennm"
      ErrorMsg(I) = "Vendor Name is required"
      I = I + 1
    End If

    If InStr(TxtVennm.Text, "'") > 0 Then
      ErrorField(I) = "vennm"
      ErrorMsg(I) = "Single Quote is not allowed"
      I = I + 1
    End If

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.Clear()
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "vsort"
          ErrProv.SetError(TxtVsort, ErrorMsg(I))
        Case "vndnr"
          ErrProv.SetError(TxtVndnr, ErrorMsg(I))
        Case "vennm"
          ErrProv.SetError(TxtVennm, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub FrmAP101C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmAP101.SbpScreen.Text = "AP101C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub FormatGridAP(ByVal ds As DataSet)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Visible = False
      .Columns(1).Width = 70
      .Columns(1).HeaderText = "Check Date"
      .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(2).Width = 70
      .Columns(2).HeaderText = "Invoice Date"
      .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      '         .Columns(2).DefaultCellStyle.Format = "##/##/####"
      .Columns(3).Width = 70
      .Columns(3).HeaderText = "Check No"
      .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(4).Width = 125
      .Columns(4).HeaderText = "Invoice No"
      .Columns(5).Width = 50
      .Columns(5).HeaderText = "PO No"
      .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(6).Width = 70
      .Columns(6).HeaderText = "Invoice Amt"
      .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(7).HeaderText = "Void"
      .Columns(7).Width = 50
      .Columns(7).Visible = True
    End With
  End Sub
  Public Sub FormatGridPO(ByVal ds As DataSet)
    DataGrdView2.DataSource = ds.Tables(0)
    DataGrdView2.Refresh()
    With DataGrdView2
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Width = 50
      .Columns(0).HeaderText = "Fiscal Yr"
      .Columns(1).Width = 60
      .Columns(1).HeaderText = "PO Nbr"
      .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(2).Visible = False
      .Columns(3).Visible = False
      .Columns(4).Visible = False
      .Columns(5).Width = 60
      .Columns(5).HeaderText = "Total Net"
      .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(6).Width = 60
      .Columns(6).HeaderText = "Total Open"
      .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(7).Width = 60
      .Columns(7).HeaderText = "Status"
      .Columns(8).Visible = False
    End With
  End Sub
  Private Sub RefreshAP()
    Dim ds As DataSet
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    If RbChkDate.Checked Then
      WrkDbDate = MyUtils.SetDBDate(DtPckChk.Value)
      ds = myAPEHSTL1.GetViewbyVndnrL2(TxtVndnr.Text, WrkDbDate, "", 300)
    End If
    If RbInvNo.Checked Then
      ds = myAPEHSTL1.GetViewbyVndnrL3(TxtVndnr.Text, TxtInvNo.Text, 0, 0, 300)
    End If
    If RbInvDate.Checked Then
      WrkDbDate = MyUtils.SetDBDateMDY(DtPckInv.Value)
      ds = myAPEHSTL1.GetViewbyVndnrLB(TxtVndnr.Text, WrkDbDate, "", 300)
    End If
    ds2 = GetData(ds)
    FormatGridAP(ds2)
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Private Sub RefreshPO()
    Dim ds As DataSet
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    ds = myPOMASTLC.GetViewbyVendorLC(TxtVndnr.Text, MyUtils.CnvSng(TxtFscyr.Text),
   MyUtils.CnvSng(TxtPONbr.Text), 250)
    FormatGridPO(ds)
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Private Sub BuildDS(ByRef ds2 As DataSet)
    ' ken- hanged date fields to dates from strign    also checknumber to int32...
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Vndnr", Type.GetType("System.String"))
      .Columns.Add("Chkdate", GetType(DateTime))
      .Columns.Add("Invd8", GetType(DateTime))
      .Columns.Add("Chkpd", Type.GetType("System.Int32"))
      .Columns.Add("Invno", Type.GetType("System.String"))
      .Columns.Add("Ponbr", Type.GetType("System.Int32"))
      .Columns.Add("Amtnt", Type.GetType("System.Decimal"))
      .Columns.Add("Avoid", Type.GetType("System.String"))
    End With
    ds2.Tables.Add(myTable)
  End Sub
  Private Function GetData(ds) As DataSet
    Dim dr As DataRow

    ds2.Clear()
    For I = 0 To ds.Tables(0).Rows.Count - 1
      dr = ds2.Tables(0).NewRow
      dr("vndnr") = ds.Tables(0).Rows(I).item("vndnr")
      If ds.Tables(0).Rows(I).item("chkdate") > 0 Then
        Dim wrkdatechk As Object = ParseDatemdyy(ds.Tables(0).Rows(I).item("chkdate"))
        dr("chkdate") = wrkdatechk
      End If
      Dim wrkdateinv As Object = ParseDatemdyy(ds.Tables(0).Rows(I).item("invd8"))
      dr("invd8") = wrkdateinv
      If ds.Tables(0).Rows(I).item("chkpd") > 0 Then
        dr("chkpd") = ds.Tables(0).Rows(I).Item("chkpd")
      Else
        dr("chkpd") = 0
      End If
      dr("invno") = ds.Tables(0).Rows(I).Item("invno")
      dr("ponbr") = ds.Tables(0).Rows(I).Item("ponbr")
      dr("amtnt") = ds.Tables(0).Rows(I).Item("amtnt")
      dr("avoid") = ds.Tables(0).Rows(I).Item("avoid")
      ds2.Tables(0).Rows.Add(dr)
    Next
    Return ds2
  End Function
  ' Function to parse and validate the date
  Function ParseDatemdyy(number As Integer) As Object
    Try
      Dim month As Integer = number \ 1000000
      Dim day As Integer = (number \ 10000) Mod 100
      Dim year As Integer = number Mod 10000
      Return New DateTime(year, month, day)
    Catch ex As Exception
      Return DBNull.Value
    End Try
  End Function
  Private Sub TabCtl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabCtl1.SelectedIndexChanged
    If TabCtl1.SelectedTab Is TpEdit Then
      MyFrmAP101.TBarSave.Enabled = True
      MyFrmAP101.TBarDelete.Enabled = False
      'If WrkVndnr <> "" Then
      '    MyFrmAP101.TBarDelete.Enabled = True
      'End If
    Else
      MyFrmAP101.TBarSave.Enabled = False
      MyFrmAP101.TBarDelete.Enabled = False
    End If
  End Sub

  Private Sub DataGrdiew_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    If DataGrdView.Rows.Count = 0 Then Exit Sub

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    MyFrmAP101D = New FrmAP101D
    MyFrmAP101D.MdiParent = Me.ParentForm
    MyFrmAP101D.WrkVndnr = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    MyFrmAP101D.WrkVennm = LblVennm.Text
    MyFrmAP101D.WrkInvno = DataGrdView.Item(4, DataGrdView.CurrentRow.Index).Value
    MyFrmAP101D.WrkInvdt = MyUtils.SetDBDate(DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value)
    MyFrmAP101D.WrkChkpd = MyUtils.CnvSng(DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value)
    MyFrmAP101D.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Private Sub DataGrdView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGrdView.CellFormatting
    Dim Temp As String
    If DataGrdView.Columns(e.ColumnIndex).Name = "Avoid" Then
      If e.Value = "V" Then
        DataGrdView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
        Temp = DataGrdView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        Select Case Temp
          Case "V"
            e.Value = "Void"
          Case Else
            e.Value = ""
        End Select
      End If
    End If
  End Sub
  Private Sub DataGrdView2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGrdView2.CellFormatting
    Dim Temp As String

    If (e.ColumnIndex = 7) Then
      Temp = DataGrdView2.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
      Select Case Temp
        Case "C"
          e.Value = "Closed"
        Case "O", " ", ""
          e.Value = "Opened"
        Case Else
      End Select
    End If
  End Sub
  Private Sub DataGrdView2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView2.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    If DataGrdView2.Rows.Count = 0 Then Exit Sub

    MyFrmAP101E = New FrmAP101E
    MyFrmAP101E.MdiParent = Me.ParentForm
    MyFrmAP101E.WrkFscyr = DataGrdView2.Item(0, DataGrdView2.CurrentRow.Index).Value
    MyFrmAP101E.WrkPonbr = DataGrdView2.Item(1, DataGrdView2.CurrentRow.Index).Value
    MyFrmAP101E.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Private Sub LnkGLAcctBD_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkGLAcctBD.LinkClicked
    Dim WrkAcct As String

    WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFdnbd.Text), MyUtils.CnvSng(TxtSfudd.Text), MyUtils.CnvSng(TxtDpnbd.Text),
    MyUtils.CnvSng(TxtObnbd.Text), MyUtils.CnvSng(TxtFnpgd.Text), MyUtils.CnvSng(TxtSubfd.Text))
    MyFrmListGLAcct = New FrmListGLAcct
    MyFrmListGLAcct.MdiParent = Me.ParentForm
    MyFrmListGLAcct.WrkField = "BD"
    MyFrmListGLAcct.WrkCode = WrkAcct
    MyFrmListGLAcct.Show()
    Me.Hide()
  End Sub
  Private Sub LnkGLAcctBS_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkGLAcctBS.LinkClicked
    Dim WrkAcct As String

    WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFdnbs.Text), MyUtils.CnvSng(TxtSfuns.Text), MyUtils.CnvSng(TxtDpnbs.Text),
    MyUtils.CnvSng(TxtObnbs.Text), MyUtils.CnvSng(TxtFnpgs.Text), MyUtils.CnvSng(TxtSubfs.Text))
    MyFrmListGLAcct = New FrmListGLAcct
    MyFrmListGLAcct.MdiParent = Me.ParentForm
    MyFrmListGLAcct.WrkField = "BS"
    MyFrmListGLAcct.WrkCode = WrkAcct
    MyFrmListGLAcct.Show()
    Me.Hide()

  End Sub
  Private Sub RbChkDate_Click(sender As Object, e As EventArgs) Handles RbChkDate.Click
    DtPckChk.Visible = True
    TxtInvNo.Visible = False
    DtPckInv.Visible = False
    RefreshAP()
  End Sub
  Private Sub RbInvNo_Click(sender As Object, e As EventArgs) Handles RbInvNo.Click
    DtPckChk.Visible = False
    TxtInvNo.Visible = True
    DtPckInv.Visible = False
    RefreshAP()
  End Sub
  Private Sub RbInvDate_Click(sender As Object, e As EventArgs) Handles RbInvDate.Click
    DtPckChk.Visible = False
    TxtInvNo.Visible = False
    DtPckInv.Visible = True
    RefreshAP()
  End Sub
  Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles BtnFind.Click
    RefreshAP()
  End Sub
  Private Sub LnkVncat_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkVncat.LinkClicked
    MyFrmListVENCAT = New FrmListVENCAT
    MyFrmListVENCAT.MdiParent = Me.ParentForm
    MyFrmListVENCAT.WrkCode = TxtVncat.Text
    MyFrmListVENCAT.Show()
    Me.Hide()
  End Sub
  Private Sub BtnFindPO_Click(sender As Object, e As EventArgs) Handles BtnFindPO.Click
    RefreshPO()
  End Sub
  Private Sub TxtFscyr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFscyr.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, True)
  End Sub
  Private Sub TxtPONbr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPONbr.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, True)
  End Sub

  Private Sub TpEdit_Click(sender As Object, e As EventArgs) Handles TpEdit.Click

  End Sub

  Private Sub TxtVsort_TextChanged(sender As Object, e As EventArgs) Handles TxtVsort.TextChanged

  End Sub

  Private Sub TpActivity_Click(sender As Object, e As EventArgs) Handles TpActivity.Click

  End Sub

  Private Sub TxtVennm_TextChanged(sender As Object, e As EventArgs) Handles TxtVennm.TextChanged

  End Sub
End Class
