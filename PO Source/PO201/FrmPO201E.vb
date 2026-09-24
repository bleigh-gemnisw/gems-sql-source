Public Class FrmPO201E
  Inherits System.Windows.Forms.Form
  Dim myBCHHDR As BCHHDR.myData
  Dim myRQEBCH As RQEBCH.myData
  Dim myRQEBCD As RQEBCD.MyData
  Dim myRQEBCDL1 As RQEBCDL1.MyData
  Dim myGLACCT As GLACCT.MyData
  Dim myVENDOR As VENDOR.MyData
  Dim myLOCATN As LOCATN.MyData
  Dim myPURCTL As PURCTL.MyData

  Friend WrkLlocn As String
  Friend WrkBatchNo As Integer
  Friend WrkRqnbr As Integer
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents LnkGLAcct As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtSfcn As System.Windows.Forms.TextBox
  Friend WithEvents TxtFcn As System.Windows.Forms.TextBox
  Friend WithEvents TxtObj As System.Windows.Forms.TextBox
  Friend WithEvents TxtDept As System.Windows.Forms.TextBox
  Friend WithEvents TxtSFund As System.Windows.Forms.TextBox
  Friend WithEvents TxtFund As System.Windows.Forms.TextBox
  Dim AddMode As Boolean
  Friend WithEvents TxtVndnr As System.Windows.Forms.TextBox
  Friend WithEvents LnkVndnr As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtPrj As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents LblTotAmt As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents LblVennm As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Dim WrkRecno As Integer
  Friend WithEvents LblRecno As System.Windows.Forms.Label
  Friend WithEvents TxtLne As System.Windows.Forms.TextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents TxtRzipe As System.Windows.Forms.TextBox
  Friend WithEvents TxtRzip As System.Windows.Forms.TextBox
  Friend WithEvents TxtRadr4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtRadr3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtRadr2 As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtRadr1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtSzipe As System.Windows.Forms.TextBox
  Friend WithEvents TxtSzip As System.Windows.Forms.TextBox
  Friend WithEvents TxtSadr4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtSadr3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtSadr2 As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtSadr1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnmsr As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents TxtUnitp As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents TxtRqqty As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents TxtItdsc As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TxtItnbr As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
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
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents TxtOrshp As System.Windows.Forms.TextBox
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents TxtOrdsp As System.Windows.Forms.TextBox
  Friend WithEvents LblReqnbr As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents LblLlocn As System.Windows.Forms.Label
  Friend WithEvents BtnAddDtl As System.Windows.Forms.Button
  Friend WithEvents BtnRemDtl As System.Windows.Forms.Button
  Friend WithEvents TxtRname As System.Windows.Forms.TextBox
  Friend WithEvents TxtSname As System.Windows.Forms.TextBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents LblShipping As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents LblDiscount As System.Windows.Forms.Label
  Friend WithEvents Lable155 As System.Windows.Forms.Label
  Friend WithEvents LblTotNet As System.Windows.Forms.Label
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents TxtShpdl As System.Windows.Forms.TextBox
  Friend WithEvents TxtDscdl As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents LblOverExpend As System.Windows.Forms.Label
  Dim WrkReceiptDate As Date
  Friend WithEvents DataGrdView As DataGridView
  Friend WithEvents LblRentd As Label
  Dim SaveExval As Decimal
  Friend WithEvents LblExtend As Label
  Friend WithEvents LblOverBal As Label
  Dim WrkOverExpend As Boolean

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
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LnkGLAcct = New System.Windows.Forms.LinkLabel()
    Me.TxtSfcn = New System.Windows.Forms.TextBox()
    Me.TxtFcn = New System.Windows.Forms.TextBox()
    Me.TxtObj = New System.Windows.Forms.TextBox()
    Me.TxtDept = New System.Windows.Forms.TextBox()
    Me.TxtSFund = New System.Windows.Forms.TextBox()
    Me.TxtFund = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtPrj = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.LnkVndnr = New System.Windows.Forms.LinkLabel()
    Me.TxtVndnr = New System.Windows.Forms.TextBox()
    Me.LblTotAmt = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.LblVennm = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.LblRecno = New System.Windows.Forms.Label()
    Me.TxtLne = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.TxtSzipe = New System.Windows.Forms.TextBox()
    Me.TxtSzip = New System.Windows.Forms.TextBox()
    Me.TxtSadr4 = New System.Windows.Forms.TextBox()
    Me.TxtSadr3 = New System.Windows.Forms.TextBox()
    Me.TxtSadr2 = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtSadr1 = New System.Windows.Forms.TextBox()
    Me.TxtRzipe = New System.Windows.Forms.TextBox()
    Me.TxtRzip = New System.Windows.Forms.TextBox()
    Me.TxtRadr4 = New System.Windows.Forms.TextBox()
    Me.TxtRadr3 = New System.Windows.Forms.TextBox()
    Me.TxtRadr2 = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtRadr1 = New System.Windows.Forms.TextBox()
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
    Me.TxtItnbr = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TxtItdsc = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtRqqty = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TxtUnitp = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TxtUnmsr = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.LblReqnbr = New System.Windows.Forms.Label()
    Me.LblLlocn = New System.Windows.Forms.Label()
    Me.BtnAddDtl = New System.Windows.Forms.Button()
    Me.BtnRemDtl = New System.Windows.Forms.Button()
    Me.TxtSname = New System.Windows.Forms.TextBox()
    Me.TxtRname = New System.Windows.Forms.TextBox()
    Me.LblDiscount = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.LblShipping = New System.Windows.Forms.Label()
    Me.LblTotNet = New System.Windows.Forms.Label()
    Me.Lable155 = New System.Windows.Forms.Label()
    Me.TxtDscdl = New System.Windows.Forms.TextBox()
    Me.TxtShpdl = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.LblOverExpend = New System.Windows.Forms.Label()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.LblRentd = New System.Windows.Forms.Label()
    Me.LblExtend = New System.Windows.Forms.Label()
    Me.LblOverBal = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LnkGLAcct
    '
    Me.LnkGLAcct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcct.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcct.Location = New System.Drawing.Point(12, 491)
    Me.LnkGLAcct.Name = "LnkGLAcct"
    Me.LnkGLAcct.Size = New System.Drawing.Size(36, 18)
    Me.LnkGLAcct.TabIndex = 7
    Me.LnkGLAcct.TabStop = True
    Me.LnkGLAcct.Text = "Acct"
    '
    'TxtSfcn
    '
    Me.TxtSfcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfcn.Location = New System.Drawing.Point(273, 487)
    Me.TxtSfcn.MaxLength = 4
    Me.TxtSfcn.Name = "TxtSfcn"
    Me.TxtSfcn.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfcn.TabIndex = 44
    '
    'TxtFcn
    '
    Me.TxtFcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFcn.Location = New System.Drawing.Point(222, 487)
    Me.TxtFcn.MaxLength = 4
    Me.TxtFcn.Name = "TxtFcn"
    Me.TxtFcn.Size = New System.Drawing.Size(45, 22)
    Me.TxtFcn.TabIndex = 43
    '
    'TxtObj
    '
    Me.TxtObj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObj.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObj.Location = New System.Drawing.Point(186, 487)
    Me.TxtObj.MaxLength = 3
    Me.TxtObj.Name = "TxtObj"
    Me.TxtObj.Size = New System.Drawing.Size(32, 22)
    Me.TxtObj.TabIndex = 42
    '
    'TxtDept
    '
    Me.TxtDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDept.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDept.Location = New System.Drawing.Point(135, 487)
    Me.TxtDept.MaxLength = 4
    Me.TxtDept.Name = "TxtDept"
    Me.TxtDept.Size = New System.Drawing.Size(45, 22)
    Me.TxtDept.TabIndex = 41
    '
    'TxtSFund
    '
    Me.TxtSFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSFund.Location = New System.Drawing.Point(97, 487)
    Me.TxtSFund.MaxLength = 3
    Me.TxtSFund.Name = "TxtSFund"
    Me.TxtSFund.Size = New System.Drawing.Size(32, 22)
    Me.TxtSFund.TabIndex = 40
    '
    'TxtFund
    '
    Me.TxtFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFund.Location = New System.Drawing.Point(59, 487)
    Me.TxtFund.MaxLength = 3
    Me.TxtFund.Name = "TxtFund"
    Me.TxtFund.Size = New System.Drawing.Size(32, 22)
    Me.TxtFund.TabIndex = 39
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(127, 9)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(67, 13)
    Me.Label2.TabIndex = 31
    Me.Label2.Text = "Req Number"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtPrj
    '
    Me.TxtPrj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPrj.Location = New System.Drawing.Point(432, 33)
    Me.TxtPrj.MaxLength = 10
    Me.TxtPrj.Name = "TxtPrj"
    Me.TxtPrj.Size = New System.Drawing.Size(45, 20)
    Me.TxtPrj.TabIndex = 2
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(386, 36)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(40, 13)
    Me.Label3.TabIndex = 34
    Me.Label3.Text = "Project"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LnkVndnr
    '
    Me.LnkVndnr.AutoSize = True
    Me.LnkVndnr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkVndnr.ForeColor = System.Drawing.Color.Maroon
    Me.LnkVndnr.Location = New System.Drawing.Point(12, 62)
    Me.LnkVndnr.Name = "LnkVndnr"
    Me.LnkVndnr.Size = New System.Drawing.Size(81, 13)
    Me.LnkVndnr.TabIndex = 100
    Me.LnkVndnr.TabStop = True
    Me.LnkVndnr.Text = "Vendor Number"
    '
    'TxtVndnr
    '
    Me.TxtVndnr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVndnr.Location = New System.Drawing.Point(99, 59)
    Me.TxtVndnr.MaxLength = 5
    Me.TxtVndnr.Name = "TxtVndnr"
    Me.TxtVndnr.Size = New System.Drawing.Size(45, 20)
    Me.TxtVndnr.TabIndex = 3
    '
    'LblTotAmt
    '
    Me.LblTotAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTotAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotAmt.Location = New System.Drawing.Point(578, 10)
    Me.LblTotAmt.Name = "LblTotAmt"
    Me.LblTotAmt.Size = New System.Drawing.Size(64, 16)
    Me.LblTotAmt.TabIndex = 393
    Me.LblTotAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label16
    '
    Me.Label16.AutoSize = True
    Me.Label16.BackColor = System.Drawing.SystemColors.Control
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.Location = New System.Drawing.Point(521, 12)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(52, 13)
    Me.Label16.TabIndex = 392
    Me.Label16.Text = "Total Amt"
    '
    'LblVennm
    '
    Me.LblVennm.AutoSize = True
    Me.LblVennm.Location = New System.Drawing.Point(150, 62)
    Me.LblVennm.Name = "LblVennm"
    Me.LblVennm.Size = New System.Drawing.Size(84, 13)
    Me.LblVennm.TabIndex = 395
    Me.LblVennm.Text = "<Vendor Name>"
    Me.LblVennm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.LblVennm.UseMnemonic = False
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(13, 40)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(80, 13)
    Me.Label7.TabIndex = 398
    Me.Label7.Text = "Req Entry Date"
    Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblRecno
    '
    Me.LblRecno.AutoSize = True
    Me.LblRecno.Location = New System.Drawing.Point(324, 491)
    Me.LblRecno.Name = "LblRecno"
    Me.LblRecno.Size = New System.Drawing.Size(46, 13)
    Me.LblRecno.TabIndex = 402
    Me.LblRecno.Text = "<recno>"
    Me.LblRecno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtLne
    '
    Me.TxtLne.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLne.Location = New System.Drawing.Point(326, 33)
    Me.TxtLne.MaxLength = 10
    Me.TxtLne.Name = "TxtLne"
    Me.TxtLne.Size = New System.Drawing.Size(45, 20)
    Me.TxtLne.TabIndex = 1
    '
    'Label15
    '
    Me.Label15.AutoSize = True
    Me.Label15.Location = New System.Drawing.Point(280, 36)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(36, 13)
    Me.Label15.TabIndex = 404
    Me.Label15.Text = "Memo"
    Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtSzipe
    '
    Me.TxtSzipe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSzipe.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSzipe.Location = New System.Drawing.Point(284, 177)
    Me.TxtSzipe.MaxLength = 4
    Me.TxtSzipe.Name = "TxtSzipe"
    Me.TxtSzipe.Size = New System.Drawing.Size(41, 22)
    Me.TxtSzipe.TabIndex = 10
    '
    'TxtSzip
    '
    Me.TxtSzip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSzip.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSzip.Location = New System.Drawing.Point(227, 177)
    Me.TxtSzip.MaxLength = 5
    Me.TxtSzip.Name = "TxtSzip"
    Me.TxtSzip.Size = New System.Drawing.Size(51, 22)
    Me.TxtSzip.TabIndex = 9
    '
    'TxtSadr4
    '
    Me.TxtSadr4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSadr4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSadr4.Location = New System.Drawing.Point(56, 177)
    Me.TxtSadr4.MaxLength = 20
    Me.TxtSadr4.Name = "TxtSadr4"
    Me.TxtSadr4.Size = New System.Drawing.Size(165, 22)
    Me.TxtSadr4.TabIndex = 8
    '
    'TxtSadr3
    '
    Me.TxtSadr3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSadr3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSadr3.Location = New System.Drawing.Point(56, 155)
    Me.TxtSadr3.MaxLength = 20
    Me.TxtSadr3.Name = "TxtSadr3"
    Me.TxtSadr3.Size = New System.Drawing.Size(165, 22)
    Me.TxtSadr3.TabIndex = 7
    '
    'TxtSadr2
    '
    Me.TxtSadr2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSadr2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSadr2.Location = New System.Drawing.Point(56, 133)
    Me.TxtSadr2.MaxLength = 20
    Me.TxtSadr2.Name = "TxtSadr2"
    Me.TxtSadr2.Size = New System.Drawing.Size(165, 22)
    Me.TxtSadr2.TabIndex = 6
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.ForeColor = System.Drawing.Color.Black
    Me.Label4.Location = New System.Drawing.Point(5, 90)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(44, 13)
    Me.Label4.TabIndex = 411
    Me.Label4.Text = "Ship To"
    '
    'TxtSadr1
    '
    Me.TxtSadr1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSadr1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSadr1.Location = New System.Drawing.Point(56, 111)
    Me.TxtSadr1.MaxLength = 20
    Me.TxtSadr1.Name = "TxtSadr1"
    Me.TxtSadr1.Size = New System.Drawing.Size(165, 22)
    Me.TxtSadr1.TabIndex = 5
    '
    'TxtRzipe
    '
    Me.TxtRzipe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRzipe.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRzipe.Location = New System.Drawing.Point(606, 177)
    Me.TxtRzipe.MaxLength = 4
    Me.TxtRzipe.Name = "TxtRzipe"
    Me.TxtRzipe.Size = New System.Drawing.Size(41, 22)
    Me.TxtRzipe.TabIndex = 17
    '
    'TxtRzip
    '
    Me.TxtRzip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRzip.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRzip.Location = New System.Drawing.Point(549, 177)
    Me.TxtRzip.MaxLength = 5
    Me.TxtRzip.Name = "TxtRzip"
    Me.TxtRzip.Size = New System.Drawing.Size(51, 22)
    Me.TxtRzip.TabIndex = 16
    '
    'TxtRadr4
    '
    Me.TxtRadr4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRadr4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRadr4.Location = New System.Drawing.Point(378, 177)
    Me.TxtRadr4.MaxLength = 20
    Me.TxtRadr4.Name = "TxtRadr4"
    Me.TxtRadr4.Size = New System.Drawing.Size(165, 22)
    Me.TxtRadr4.TabIndex = 15
    '
    'TxtRadr3
    '
    Me.TxtRadr3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRadr3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRadr3.Location = New System.Drawing.Point(378, 155)
    Me.TxtRadr3.MaxLength = 20
    Me.TxtRadr3.Name = "TxtRadr3"
    Me.TxtRadr3.Size = New System.Drawing.Size(165, 22)
    Me.TxtRadr3.TabIndex = 14
    '
    'TxtRadr2
    '
    Me.TxtRadr2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRadr2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRadr2.Location = New System.Drawing.Point(378, 133)
    Me.TxtRadr2.MaxLength = 20
    Me.TxtRadr2.Name = "TxtRadr2"
    Me.TxtRadr2.Size = New System.Drawing.Size(165, 22)
    Me.TxtRadr2.TabIndex = 13
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.ForeColor = System.Drawing.Color.Black
    Me.Label6.Location = New System.Drawing.Point(327, 93)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(36, 13)
    Me.Label6.TabIndex = 418
    Me.Label6.Text = "Bill To"
    '
    'TxtRadr1
    '
    Me.TxtRadr1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRadr1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRadr1.Location = New System.Drawing.Point(378, 111)
    Me.TxtRadr1.MaxLength = 20
    Me.TxtRadr1.Name = "TxtRadr1"
    Me.TxtRadr1.Size = New System.Drawing.Size(165, 22)
    Me.TxtRadr1.TabIndex = 12
    '
    'LnkGLAcctBS
    '
    Me.LnkGLAcctBS.AutoSize = True
    Me.LnkGLAcctBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcctBS.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcctBS.Location = New System.Drawing.Point(244, 238)
    Me.LnkGLAcctBS.Name = "LnkGLAcctBS"
    Me.LnkGLAcctBS.Size = New System.Drawing.Size(120, 13)
    Me.LnkGLAcctBS.TabIndex = 436
    Me.LnkGLAcctBS.TabStop = True
    Me.LnkGLAcctBS.Text = "Shipping/Handling Acct"
    '
    'LnkGLAcctBD
    '
    Me.LnkGLAcctBD.AutoSize = True
    Me.LnkGLAcctBD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcctBD.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcctBD.Location = New System.Drawing.Point(270, 212)
    Me.LnkGLAcctBD.Name = "LnkGLAcctBD"
    Me.LnkGLAcctBD.Size = New System.Drawing.Size(74, 13)
    Me.LnkGLAcctBD.TabIndex = 435
    Me.LnkGLAcctBD.TabStop = True
    Me.LnkGLAcctBD.Text = "Discount Acct"
    '
    'TxtSubfs
    '
    Me.TxtSubfs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSubfs.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSubfs.Location = New System.Drawing.Point(584, 234)
    Me.TxtSubfs.MaxLength = 4
    Me.TxtSubfs.Name = "TxtSubfs"
    Me.TxtSubfs.Size = New System.Drawing.Size(45, 22)
    Me.TxtSubfs.TabIndex = 33
    '
    'TxtFnpgs
    '
    Me.TxtFnpgs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFnpgs.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFnpgs.Location = New System.Drawing.Point(533, 234)
    Me.TxtFnpgs.MaxLength = 4
    Me.TxtFnpgs.Name = "TxtFnpgs"
    Me.TxtFnpgs.Size = New System.Drawing.Size(45, 22)
    Me.TxtFnpgs.TabIndex = 32
    '
    'TxtObnbs
    '
    Me.TxtObnbs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObnbs.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObnbs.Location = New System.Drawing.Point(497, 234)
    Me.TxtObnbs.MaxLength = 3
    Me.TxtObnbs.Name = "TxtObnbs"
    Me.TxtObnbs.Size = New System.Drawing.Size(32, 22)
    Me.TxtObnbs.TabIndex = 31
    '
    'TxtDpnbs
    '
    Me.TxtDpnbs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDpnbs.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDpnbs.Location = New System.Drawing.Point(446, 234)
    Me.TxtDpnbs.MaxLength = 4
    Me.TxtDpnbs.Name = "TxtDpnbs"
    Me.TxtDpnbs.Size = New System.Drawing.Size(45, 22)
    Me.TxtDpnbs.TabIndex = 30
    '
    'TxtSfuns
    '
    Me.TxtSfuns.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfuns.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfuns.Location = New System.Drawing.Point(408, 234)
    Me.TxtSfuns.MaxLength = 3
    Me.TxtSfuns.Name = "TxtSfuns"
    Me.TxtSfuns.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfuns.TabIndex = 29
    '
    'TxtSubfd
    '
    Me.TxtSubfd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSubfd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSubfd.Location = New System.Drawing.Point(584, 208)
    Me.TxtSubfd.MaxLength = 4
    Me.TxtSubfd.Name = "TxtSubfd"
    Me.TxtSubfd.Size = New System.Drawing.Size(45, 22)
    Me.TxtSubfd.TabIndex = 25
    '
    'TxtFnpgd
    '
    Me.TxtFnpgd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFnpgd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFnpgd.Location = New System.Drawing.Point(533, 208)
    Me.TxtFnpgd.MaxLength = 4
    Me.TxtFnpgd.Name = "TxtFnpgd"
    Me.TxtFnpgd.Size = New System.Drawing.Size(45, 22)
    Me.TxtFnpgd.TabIndex = 24
    '
    'TxtObnbd
    '
    Me.TxtObnbd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObnbd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObnbd.Location = New System.Drawing.Point(497, 208)
    Me.TxtObnbd.MaxLength = 3
    Me.TxtObnbd.Name = "TxtObnbd"
    Me.TxtObnbd.Size = New System.Drawing.Size(32, 22)
    Me.TxtObnbd.TabIndex = 23
    '
    'TxtDpnbd
    '
    Me.TxtDpnbd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDpnbd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDpnbd.Location = New System.Drawing.Point(446, 208)
    Me.TxtDpnbd.MaxLength = 4
    Me.TxtDpnbd.Name = "TxtDpnbd"
    Me.TxtDpnbd.Size = New System.Drawing.Size(45, 22)
    Me.TxtDpnbd.TabIndex = 22
    '
    'TxtSfudd
    '
    Me.TxtSfudd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfudd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfudd.Location = New System.Drawing.Point(408, 208)
    Me.TxtSfudd.MaxLength = 3
    Me.TxtSfudd.Name = "TxtSfudd"
    Me.TxtSfudd.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfudd.TabIndex = 21
    '
    'TxtFdnbs
    '
    Me.TxtFdnbs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFdnbs.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFdnbs.Location = New System.Drawing.Point(370, 234)
    Me.TxtFdnbs.MaxLength = 3
    Me.TxtFdnbs.Name = "TxtFdnbs"
    Me.TxtFdnbs.Size = New System.Drawing.Size(32, 22)
    Me.TxtFdnbs.TabIndex = 28
    '
    'TxtFdnbd
    '
    Me.TxtFdnbd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFdnbd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFdnbd.Location = New System.Drawing.Point(370, 208)
    Me.TxtFdnbd.MaxLength = 3
    Me.TxtFdnbd.Name = "TxtFdnbd"
    Me.TxtFdnbd.Size = New System.Drawing.Size(32, 22)
    Me.TxtFdnbd.TabIndex = 20
    '
    'Label18
    '
    Me.Label18.AutoSize = True
    Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label18.ForeColor = System.Drawing.Color.Black
    Me.Label18.Location = New System.Drawing.Point(21, 237)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(86, 13)
    Me.Label18.TabIndex = 434
    Me.Label18.Text = "Ship/Handling %"
    '
    'TxtOrshp
    '
    Me.TxtOrshp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOrshp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOrshp.Location = New System.Drawing.Point(113, 233)
    Me.TxtOrshp.MaxLength = 5
    Me.TxtOrshp.Name = "TxtOrshp"
    Me.TxtOrshp.Size = New System.Drawing.Size(41, 22)
    Me.TxtOrshp.TabIndex = 26
    Me.TxtOrshp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label17
    '
    Me.Label17.AutoSize = True
    Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label17.ForeColor = System.Drawing.Color.Black
    Me.Label17.Location = New System.Drawing.Point(21, 212)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(89, 13)
    Me.Label17.TabIndex = 433
    Me.Label17.Text = "Order Discount %"
    '
    'TxtOrdsp
    '
    Me.TxtOrdsp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOrdsp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOrdsp.Location = New System.Drawing.Point(113, 208)
    Me.TxtOrdsp.MaxLength = 5
    Me.TxtOrdsp.Name = "TxtOrdsp"
    Me.TxtOrdsp.Size = New System.Drawing.Size(41, 22)
    Me.TxtOrdsp.TabIndex = 18
    Me.TxtOrdsp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtItnbr
    '
    Me.TxtItnbr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtItnbr.Location = New System.Drawing.Point(126, 429)
    Me.TxtItnbr.MaxLength = 20
    Me.TxtItnbr.Name = "TxtItnbr"
    Me.TxtItnbr.Size = New System.Drawing.Size(166, 20)
    Me.TxtItnbr.TabIndex = 34
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(37, 432)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(83, 13)
    Me.Label9.TabIndex = 437
    Me.Label9.Text = "Catalog Number"
    Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtItdsc
    '
    Me.TxtItdsc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtItdsc.Location = New System.Drawing.Point(370, 429)
    Me.TxtItdsc.MaxLength = 30
    Me.TxtItdsc.Name = "TxtItdsc"
    Me.TxtItdsc.Size = New System.Drawing.Size(263, 20)
    Me.TxtItdsc.TabIndex = 35
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(305, 432)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(60, 13)
    Me.Label10.TabIndex = 439
    Me.Label10.Text = "Description"
    Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtRqqty
    '
    Me.TxtRqqty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRqqty.Location = New System.Drawing.Point(126, 458)
    Me.TxtRqqty.MaxLength = 10
    Me.TxtRqqty.Name = "TxtRqqty"
    Me.TxtRqqty.Size = New System.Drawing.Size(74, 20)
    Me.TxtRqqty.TabIndex = 36
    Me.TxtRqqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(71, 462)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(46, 13)
    Me.Label11.TabIndex = 441
    Me.Label11.Text = "Quantity"
    Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtUnitp
    '
    Me.TxtUnitp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUnitp.Location = New System.Drawing.Point(284, 458)
    Me.TxtUnitp.MaxLength = 11
    Me.TxtUnitp.Name = "TxtUnitp"
    Me.TxtUnitp.Size = New System.Drawing.Size(81, 20)
    Me.TxtUnitp.TabIndex = 37
    Me.TxtUnitp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(222, 462)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(53, 13)
    Me.Label12.TabIndex = 443
    Me.Label12.Text = "Unit Price"
    Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtUnmsr
    '
    Me.TxtUnmsr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUnmsr.Location = New System.Drawing.Point(467, 458)
    Me.TxtUnmsr.MaxLength = 4
    Me.TxtUnmsr.Name = "TxtUnmsr"
    Me.TxtUnmsr.Size = New System.Drawing.Size(40, 20)
    Me.TxtUnmsr.TabIndex = 38
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.Location = New System.Drawing.Point(378, 462)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(82, 13)
    Me.Label13.TabIndex = 445
    Me.Label13.Text = "Unit of Measure"
    Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(13, 9)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(48, 13)
    Me.Label5.TabIndex = 449
    Me.Label5.Text = "Location"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblReqnbr
    '
    Me.LblReqnbr.AutoSize = True
    Me.LblReqnbr.BackColor = System.Drawing.SystemColors.Control
    Me.LblReqnbr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblReqnbr.Location = New System.Drawing.Point(200, 10)
    Me.LblReqnbr.Name = "LblReqnbr"
    Me.LblReqnbr.Size = New System.Drawing.Size(54, 13)
    Me.LblReqnbr.TabIndex = 450
    Me.LblReqnbr.Text = "<Reqnbr>"
    '
    'LblLlocn
    '
    Me.LblLlocn.AutoSize = True
    Me.LblLlocn.BackColor = System.Drawing.SystemColors.Control
    Me.LblLlocn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLlocn.Location = New System.Drawing.Point(65, 9)
    Me.LblLlocn.Name = "LblLlocn"
    Me.LblLlocn.Size = New System.Drawing.Size(45, 13)
    Me.LblLlocn.TabIndex = 451
    Me.LblLlocn.Text = "<Llocn>"
    '
    'BtnAddDtl
    '
    Me.BtnAddDtl.Location = New System.Drawing.Point(376, 487)
    Me.BtnAddDtl.Name = "BtnAddDtl"
    Me.BtnAddDtl.Size = New System.Drawing.Size(81, 22)
    Me.BtnAddDtl.TabIndex = 45
    Me.BtnAddDtl.TabStop = False
    Me.BtnAddDtl.Text = "Add Item"
    Me.BtnAddDtl.UseVisualStyleBackColor = True
    '
    'BtnRemDtl
    '
    Me.BtnRemDtl.Location = New System.Drawing.Point(463, 487)
    Me.BtnRemDtl.Name = "BtnRemDtl"
    Me.BtnRemDtl.Size = New System.Drawing.Size(81, 22)
    Me.BtnRemDtl.TabIndex = 46
    Me.BtnRemDtl.TabStop = False
    Me.BtnRemDtl.Text = "Remove Item"
    Me.BtnRemDtl.UseVisualStyleBackColor = True
    '
    'TxtSname
    '
    Me.TxtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSname.Location = New System.Drawing.Point(56, 90)
    Me.TxtSname.MaxLength = 25
    Me.TxtSname.Name = "TxtSname"
    Me.TxtSname.Size = New System.Drawing.Size(207, 22)
    Me.TxtSname.TabIndex = 4
    '
    'TxtRname
    '
    Me.TxtRname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRname.Location = New System.Drawing.Point(378, 89)
    Me.TxtRname.MaxLength = 25
    Me.TxtRname.Name = "TxtRname"
    Me.TxtRname.Size = New System.Drawing.Size(207, 22)
    Me.TxtRname.TabIndex = 11
    '
    'LblDiscount
    '
    Me.LblDiscount.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDiscount.Location = New System.Drawing.Point(578, 26)
    Me.LblDiscount.Name = "LblDiscount"
    Me.LblDiscount.Size = New System.Drawing.Size(64, 16)
    Me.LblDiscount.TabIndex = 454
    Me.LblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.BackColor = System.Drawing.SystemColors.Control
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(521, 29)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(49, 13)
    Me.Label8.TabIndex = 455
    Me.Label8.Text = "Discount"
    '
    'Label14
    '
    Me.Label14.AutoSize = True
    Me.Label14.BackColor = System.Drawing.SystemColors.Control
    Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label14.Location = New System.Drawing.Point(521, 45)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(48, 13)
    Me.Label14.TabIndex = 457
    Me.Label14.Text = "Shipping"
    '
    'LblShipping
    '
    Me.LblShipping.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblShipping.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblShipping.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblShipping.Location = New System.Drawing.Point(578, 42)
    Me.LblShipping.Name = "LblShipping"
    Me.LblShipping.Size = New System.Drawing.Size(64, 16)
    Me.LblShipping.TabIndex = 456
    Me.LblShipping.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotNet
    '
    Me.LblTotNet.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTotNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotNet.Location = New System.Drawing.Point(578, 58)
    Me.LblTotNet.Name = "LblTotNet"
    Me.LblTotNet.Size = New System.Drawing.Size(64, 16)
    Me.LblTotNet.TabIndex = 458
    Me.LblTotNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Lable155
    '
    Me.Lable155.AutoSize = True
    Me.Lable155.BackColor = System.Drawing.SystemColors.Control
    Me.Lable155.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Lable155.Location = New System.Drawing.Point(522, 61)
    Me.Lable155.Name = "Lable155"
    Me.Lable155.Size = New System.Drawing.Size(51, 13)
    Me.Lable155.TabIndex = 459
    Me.Lable155.Text = "Total Net"
    '
    'TxtDscdl
    '
    Me.TxtDscdl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDscdl.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDscdl.Location = New System.Drawing.Point(196, 208)
    Me.TxtDscdl.MaxLength = 5
    Me.TxtDscdl.Name = "TxtDscdl"
    Me.TxtDscdl.Size = New System.Drawing.Size(47, 22)
    Me.TxtDscdl.TabIndex = 19
    Me.TxtDscdl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtShpdl
    '
    Me.TxtShpdl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtShpdl.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtShpdl.Location = New System.Drawing.Point(196, 233)
    Me.TxtShpdl.MaxLength = 5
    Me.TxtShpdl.Name = "TxtShpdl"
    Me.TxtShpdl.Size = New System.Drawing.Size(47, 22)
    Me.TxtShpdl.TabIndex = 27
    Me.TxtShpdl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(160, 212)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(31, 13)
    Me.Label1.TabIndex = 462
    Me.Label1.Text = " or  $"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label19
    '
    Me.Label19.AutoSize = True
    Me.Label19.Location = New System.Drawing.Point(160, 237)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(31, 13)
    Me.Label19.TabIndex = 463
    Me.Label19.Text = " or  $"
    Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblOverExpend
    '
    Me.LblOverExpend.AutoSize = True
    Me.LblOverExpend.BackColor = System.Drawing.SystemColors.Control
    Me.LblOverExpend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOverExpend.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblOverExpend.Location = New System.Drawing.Point(550, 491)
    Me.LblOverExpend.Name = "LblOverExpend"
    Me.LblOverExpend.Size = New System.Drawing.Size(112, 13)
    Me.LblOverExpend.TabIndex = 465
    Me.LblOverExpend.Text = "OVER EXPENDED"
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
    Me.DataGrdView.Location = New System.Drawing.Point(56, 261)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(573, 157)
    Me.DataGrdView.TabIndex = 474
    '
    'LblRentd
    '
    Me.LblRentd.AutoSize = True
    Me.LblRentd.BackColor = System.Drawing.SystemColors.Control
    Me.LblRentd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblRentd.Location = New System.Drawing.Point(99, 40)
    Me.LblRentd.Name = "LblRentd"
    Me.LblRentd.Size = New System.Drawing.Size(48, 13)
    Me.LblRentd.TabIndex = 475
    Me.LblRentd.Text = "<Rentd>"
    '
    'LblExtend
    '
    Me.LblExtend.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExtend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExtend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExtend.Location = New System.Drawing.Point(514, 460)
    Me.LblExtend.Name = "LblExtend"
    Me.LblExtend.Size = New System.Drawing.Size(64, 16)
    Me.LblExtend.TabIndex = 476
    Me.LblExtend.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblOverBal
    '
    Me.LblOverBal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOverBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOverBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOverBal.Location = New System.Drawing.Point(596, 460)
    Me.LblOverBal.Name = "LblOverBal"
    Me.LblOverBal.Size = New System.Drawing.Size(64, 16)
    Me.LblOverBal.TabIndex = 477
    Me.LblOverBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'FrmPO201E
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(672, 518)
    Me.Controls.Add(Me.LblOverBal)
    Me.Controls.Add(Me.LblExtend)
    Me.Controls.Add(Me.LblRentd)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LblOverExpend)
    Me.Controls.Add(Me.Label19)
    Me.Controls.Add(Me.TxtShpdl)
    Me.Controls.Add(Me.TxtDscdl)
    Me.Controls.Add(Me.Lable155)
    Me.Controls.Add(Me.LblTotNet)
    Me.Controls.Add(Me.Label14)
    Me.Controls.Add(Me.LblShipping)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.LblDiscount)
    Me.Controls.Add(Me.TxtRname)
    Me.Controls.Add(Me.TxtSname)
    Me.Controls.Add(Me.BtnRemDtl)
    Me.Controls.Add(Me.BtnAddDtl)
    Me.Controls.Add(Me.LblLlocn)
    Me.Controls.Add(Me.LblReqnbr)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtUnmsr)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.TxtUnitp)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.TxtRqqty)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.TxtItdsc)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.TxtItnbr)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.LnkGLAcctBS)
    Me.Controls.Add(Me.LnkGLAcctBD)
    Me.Controls.Add(Me.TxtSubfs)
    Me.Controls.Add(Me.TxtFnpgs)
    Me.Controls.Add(Me.TxtObnbs)
    Me.Controls.Add(Me.TxtDpnbs)
    Me.Controls.Add(Me.TxtSfuns)
    Me.Controls.Add(Me.TxtSubfd)
    Me.Controls.Add(Me.TxtFnpgd)
    Me.Controls.Add(Me.TxtObnbd)
    Me.Controls.Add(Me.TxtDpnbd)
    Me.Controls.Add(Me.TxtSfudd)
    Me.Controls.Add(Me.TxtFdnbs)
    Me.Controls.Add(Me.TxtFdnbd)
    Me.Controls.Add(Me.Label18)
    Me.Controls.Add(Me.TxtOrshp)
    Me.Controls.Add(Me.Label17)
    Me.Controls.Add(Me.TxtOrdsp)
    Me.Controls.Add(Me.TxtRzipe)
    Me.Controls.Add(Me.TxtRzip)
    Me.Controls.Add(Me.TxtRadr4)
    Me.Controls.Add(Me.TxtRadr3)
    Me.Controls.Add(Me.TxtRadr2)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtRadr1)
    Me.Controls.Add(Me.TxtSzipe)
    Me.Controls.Add(Me.TxtSzip)
    Me.Controls.Add(Me.TxtSadr4)
    Me.Controls.Add(Me.TxtSadr3)
    Me.Controls.Add(Me.TxtSadr2)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtSadr1)
    Me.Controls.Add(Me.TxtLne)
    Me.Controls.Add(Me.Label15)
    Me.Controls.Add(Me.LblRecno)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.LblVennm)
    Me.Controls.Add(Me.LblTotAmt)
    Me.Controls.Add(Me.Label16)
    Me.Controls.Add(Me.TxtVndnr)
    Me.Controls.Add(Me.LnkVndnr)
    Me.Controls.Add(Me.TxtPrj)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.LnkGLAcct)
    Me.Controls.Add(Me.TxtSfcn)
    Me.Controls.Add(Me.TxtFcn)
    Me.Controls.Add(Me.TxtObj)
    Me.Controls.Add(Me.TxtDept)
    Me.Controls.Add(Me.TxtSFund)
    Me.Controls.Add(Me.TxtFund)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPO201E"
    Me.Text = "Maintain Requisition Detail"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmPO201E_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myRQEBCH = New RQEBCH.MyData()
    myRQEBCH.MyDBConn = myDBConnect
    myRQEBCD = New RQEBCD.MyData()
    myRQEBCD.MyDBConn = myDBConnect
    myRQEBCDL1 = New RQEBCDL1.MyData()
    myRQEBCDL1.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect
    myLOCATN = New LOCATN.MyData()
    myLOCATN.MyDBConn = myDBConnect
    myPURCTL = New PURCTL.MyData()
    myPURCTL.MyDBConn = myDBConnect

    MyFrmPO201.TBarNew.Enabled = False
    MyFrmPO201.TBarSave.Enabled = True
    BtnRemDtl.Enabled = False
    LblOverExpend.Visible = False
    LblOverBal.Visible = False
    LblLlocn.Text = WrkLlocn

    If WrkRqnbr > 0 Then
      MyFrmPO201.TBarDelete.Enabled = True
    Else
      AddMode = True
      LblReqnbr.Text = "Pending"
      myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
      myRQEBCH.GetOneRecordP(WrkLlocn, WrkBatchNo, WrkRqnbr)
      myLOCATN.GetOneRecordP(WrkLlocn)
      LblRentd.Text = MyPostDate
      With myLOCATN
        TxtSname.Text = Trim(._SNAME)
        TxtSadr1.Text = Trim(._SADR1)
        TxtSadr2.Text = Trim(._SADR2)
        TxtSadr3.Text = Trim(._SADR3)
        TxtSadr4.Text = Trim(._SADR4)
        TxtSzip.Text = Trim(._SZIP)
        TxtSzipe.Text = Trim(._SZIPE)
        TxtRname.Text = Trim(._RNAME)
        TxtRadr1.Text = Trim(._RADR1)
        TxtRadr2.Text = Trim(._RADR2)
        TxtRadr3.Text = Trim(._RADR3)
        TxtRadr4.Text = Trim(._RADR4)
        TxtRzip.Text = Trim(._RZIP)
        TxtRzipe.Text = Trim(._RZIPE)
      End With
    End If

    myRQEBCH.GetOneRecordP(WrkLlocn, WrkBatchNo, WrkRqnbr)
    LblReqnbr.Text = WrkRqnbr
    LblRecno.Text = ""
    LblVennm.Text = ""
    If myRQEBCH.RecordNotFound Then Exit Sub

    With myRQEBCH
      LblRentd.Text = MyUtils.GetDBDate(._RENTD)
      TxtVndnr.Text = Trim(._VNDNR)
      LblVennm.Text = Trim(._VENNM)
      If ._LNE > 0 Then
        TxtLne.Text = ._LNE
      End If
      If ._PRJ > 0 Then
        TxtPrj.Text = ._PRJ
      End If
      TxtSname.Text = Trim(._SNAME)
      TxtSadr1.Text = Trim(._SADR1)
      TxtSadr2.Text = Trim(._SADR2)
      TxtSadr3.Text = Trim(._SADR3)
      TxtSadr4.Text = Trim(._SADR4)
      TxtSzip.Text = Trim(._SZIP)
      TxtSzipe.Text = Trim(._SZIPE)
      TxtRname.Text = Trim(._RNAME)
      TxtRadr1.Text = Trim(._RADR1)
      TxtRadr2.Text = Trim(._RADR2)
      TxtRadr3.Text = Trim(._RADR3)
      TxtRadr4.Text = Trim(._RADR4)
      TxtRzip.Text = Trim(._RZIP)
      TxtRzipe.Text = Trim(._RZIPE)
      If ._ORDSP > 0 Then
        TxtOrdsp.Text = ._ORDSP
      Else
        TxtDscdl.Text = ._DSCDL
      End If
      If ._ORSHP > 0 Then
        TxtOrshp.Text = ._ORSHP
      Else
        TxtShpdl.Text = ._SHPDL
      End If
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
      LblTotAmt.Text = ""
    End With
    FormatGrid()
    CalcTotals()
    Me.Text = "Batch " & WrkBatchNo & " - " & Me.Text
  End Sub
  Private Sub FrmPO201E_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmPO201.SbpScreen.Text = "PO201E"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub

  Private Sub FrmPO201E_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    Dim ds2 As DataSet = New DataSet
    Dim Answer As Integer
    With myRQEBCH
      ds2 = myRQEBCDL1.GetViewbyRqnbr(WrkLlocn, WrkBatchNo, WrkRqnbr, 1)
      If ds2.Tables(0).Rows.Count > 0 Then
        .GetOneRecordP(WrkLlocn, WrkBatchNo, WrkRqnbr)
        If .RecordNotFound Then
          Answer = MsgBox("OK=Abort data entry and don't save" & vbCr & "Cancel=Return to data entry", MsgBoxStyle.OkCancel, "Requistion has not been saved")
          If Answer = MsgBoxResult.Cancel Then
            e.Cancel = True
          End If
          myRQEBCD.DeleteRqnbr(WrkLlocn, WrkBatchNo, WrkRqnbr)
        End If
      End If
    End With
  End Sub
  Private Sub FrmPO201E_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmPO201.TBarNew.Enabled = True
    MyFrmPO201.TBarDelete.Enabled = False
    MyFrmPO201.TBarSave.Enabled = False
    MyFrmPO201D.FormatGrid()
    MyFrmPO201D.Show()
    'Memory Cleanup
    myRQEBCH = Nothing
    MyFrmPO201E = Nothing
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Visible = False
      .Columns(1).Visible = False
      .Columns(2).Visible = False
      .Columns(3).HeaderText = "Seq No"
      .Columns(3).Width = 45
      .Columns(4).HeaderText = "Catalog"
      .Columns(4).Width = 100
      .Columns(5).HeaderText = "Description"
      .Columns(5).Width = 150
      .Columns(6).HeaderText = "Amount"
      .Columns(6).Width = 75
      .Columns(7).HeaderText = "Quantity"
      .Columns(7).Width = 60
      .Columns(8).HeaderText = "Price"
      .Columns(8).Width = 60
      .Columns(9).HeaderText = "UOM"
      .Columns(9).Width = 50
      .Columns(10).HeaderText = "Fund"
      .Columns(10).Width = 40
      .Columns(11).HeaderText = "Sfund"
      .Columns(11).Width = 40
      .Columns(12).HeaderText = "Dept"
      .Columns(12).Width = 40
      .Columns(13).HeaderText = "Obj"
      .Columns(13).Width = 40
      .Columns(14).HeaderText = "Func"
      .Columns(14).Width = 40
      .Columns(15).HeaderText = "Sfcn"
      .Columns(15).Width = 40
    End With
  End Sub
  Public Sub ShowGrid()
    Dim ds As DataSet = New DataSet
    ds = myRQEBCDL1.GetViewbyRqnbr(WrkLlocn, WrkBatchNo, WrkRqnbr, 0)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = False
    Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete Requisition")
    If Answer = vbNo Then
      Cancel = True
      Exit Sub
    End If

    myRQEBCD.DeleteRqnbr(WrkLlocn, WrkBatchNo, WrkRqnbr)
    myRQEBCH.DeleteOneRecordP()
    UpdateHeader()
  End Sub
  Public Sub DeleteDtl()
    Dim WrkRqseq As Integer
    Dim Answer As Integer
    WrkRecno = MyUtils.CnvSng(LblRecno.Text)
    If MyUtils.CnvSng(TxtFund.Text) = 0 Then Exit Sub

    Answer = MsgBox("Remove line item " & WrkRecno & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Remove item")
    If Answer = vbNo Then
      Exit Sub
    End If

    WrkRqseq = MyUtils.CnvSng(LblRecno.Text)
    myRQEBCD.GetOneRecordP(WrkLlocn, WrkBatchNo, WrkRqnbr, WrkRqseq)
    myRQEBCD.DeleteOneRecordP()
    FormatGrid()
    CalcTotals()
    UpdateHeader()
    TxtItnbr.Text = ""
    TxtItdsc.Text = ""
    TxtRqqty.Text = ""
    TxtUnitp.Text = ""
    TxtUnmsr.Text = ""
    LblRecno.Text = ""
  End Sub
  Public Sub SaveData()
    Dim Good As Boolean
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    If WrkRqnbr = 0 Then
      myLOCATN.GetOneRecordP(WrkLlocn)
      WrkRqnbr = myLOCATN._NXTRQ + 1
      myLOCATN._NXTRQ = WrkRqnbr
      myLOCATN.UpdateOneRecordP()
      LblReqnbr.Text = WrkRqnbr
    End If

    myRQEBCH.GetOneRecordP(WrkLlocn, WrkBatchNo, WrkRqnbr)
    If Not AddMode Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myRQEBCH.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      With myRQEBCH
        ._LLOCN = WrkLlocn
        ._BCHNO = WrkBatchNo
        ._RQNBR = WrkRqnbr
      End With
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myRQEBCH.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    If TxtItdsc.Text <> "" Or MyUtils.CnvSng(TxtRqqty.Text) > 0 Or
   MyUtils.CnvSng(TxtUnitp.Text) > 0 Then
      Good = SaveDtl()
      If Not Good Then Exit Sub
    End If
    UpdateHeader()
    Me.Close()
  End Sub
  Private Sub MovetoFile()
    With myRQEBCH
      ._RENTD = MyUtils.SetDBDate(LblRentd.Text)
      ._RENTC = Mid(LblRentd.Text, Len(LblRentd.Text) - 3, 2)
      ._RACTD = MyUtils.SetDBDate(Date.Today)
      ._LNE = MyUtils.CnvSng(TxtLne.Text)
      ._VNDNR = TxtVndnr.Text
      ._VENNM = LblVennm.Text
      ._PRJ = MyUtils.CnvSng(TxtPrj.Text)
      ._FSCYR = MyFiscyr
      ._SNAME = TxtSname.Text
      ._SADR1 = TxtSadr1.Text
      ._SADR2 = TxtSadr2.Text
      ._SADR3 = TxtSadr3.Text
      ._SADR4 = TxtSadr4.Text
      ._SZIP = TxtSzip.Text
      ._SZIPE = TxtSzipe.Text
      ._RNAME = TxtRname.Text
      ._RADR1 = TxtRadr1.Text
      ._RADR2 = TxtRadr2.Text
      ._RADR3 = TxtRadr3.Text
      ._RADR4 = TxtRadr4.Text
      ._RZIP = TxtRzip.Text
      ._RZIPE = TxtRzipe.Text
      ._ORDSP = MyUtils.CnvSng(TxtOrdsp.Text)
      ._DSCDL = MyUtils.CnvSng(LblDiscount.Text)
      ._ORSHP = MyUtils.CnvSng(TxtOrshp.Text)
      ._SHPDL = MyUtils.CnvSng(LblShipping.Text)
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
      ._AMTGR = MyUtils.CnvSng(LblTotAmt.Text)
      ._AMTNT = MyUtils.CnvSng(LblTotNet.Text)
      ._RQPST = MyUtils.SetDBDateMDY(MyPostDate)
    End With
  End Sub

  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.Clear()
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "disacct"
          ErrProv.SetError(TxtFdnbd, ErrorMsg(I))
        Case "shpacct"
          ErrProv.SetError(TxtFdnbs, ErrorMsg(I))
        Case "vndnr"
          ErrProv.SetError(TxtVndnr, ErrorMsg(I))
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

    If GetVendorName(TxtVndnr.Text) = "" Then
      ErrorField(I) = "vndnr"
      ErrorMsg(I) = "Vendor Number is invalid"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtOrdsp.Text) > 0 Or MyUtils.CnvSng(TxtDscdl.Text) > 0 Then
      If MyUtils.CnvSng(TxtFdnbd.Text) = 0 Then
        ErrorField(I) = "disacct"
        ErrorMsg(I) = "Discount Acct is required"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtFdnbd.Text) > 0 Then
      myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFdnbd.Text), MyUtils.CnvSng(TxtSfudd.Text), MyUtils.CnvSng(TxtDpnbd.Text),
          MyUtils.CnvSng(TxtObnbd.Text), MyUtils.CnvSng(TxtFnpgd.Text), MyUtils.CnvSng(TxtSubfd.Text))
      If myGLACCT.RecordNotFound Then
        ErrorField(I) = "disacct"
        ErrorMsg(I) = "Acct is invalid"
        I = I + 1
      Else
        If Trim(myGLACCT._ACREC) = "I" Then
          ErrorField(I) = "disacct"
          ErrorMsg(I) = "Acct is inactive"
          I = I + 1
        End If
        If myGLACCT._GLTYP = "H" Then
          ErrorField(I) = "disacct"
          ErrorMsg(I) = "Acct is header"
          I = I + 1
        End If
      End If
    End If

    If MyUtils.CnvSng(TxtOrshp.Text) > 0 Or MyUtils.CnvSng(TxtShpdl.Text) > 0 Then
      If MyUtils.CnvSng(TxtFdnbd.Text) = 0 Then
        ErrorField(I) = "shpacct"
        ErrorMsg(I) = "Shipping Acct is required"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtFdnbs.Text) > 0 Then
      myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFdnbs.Text), MyUtils.CnvSng(TxtSfuns.Text), MyUtils.CnvSng(TxtDpnbs.Text),
        MyUtils.CnvSng(TxtObnbs.Text), MyUtils.CnvSng(TxtFnpgs.Text), MyUtils.CnvSng(TxtSubfs.Text))
      If myGLACCT.RecordNotFound Then
        ErrorField(I) = "shpacct"
        ErrorMsg(I) = "Acct is invalid"
        I = I + 1
      Else
        If Trim(myGLACCT._ACREC) = "I" Then
          ErrorField(I) = "shpacct"
          ErrorMsg(I) = "Acct is inactive"
          I = I + 1
        End If
        If myGLACCT._GLTYP = "H" Then
          ErrorField(I) = "shpacct"
          ErrorMsg(I) = "Acct is header"
          I = I + 1
        End If
      End If
    End If
  End Sub
  Public Function SaveDtl() As Boolean 'True=Saved, False=Error
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    WrkRecno = MyUtils.CnvSng(LblRecno.Text)

    If WrkRqnbr = 0 Then
      myLOCATN.GetOneRecordP(WrkLlocn)
      WrkRqnbr = myLOCATN._NXTRQ + 1
      myLOCATN._NXTRQ = WrkRqnbr
      myLOCATN.UpdateOneRecordP()
      LblReqnbr.Text = WrkRqnbr
    End If
    If WrkRecno = 0 Then
      WrkRecno = myRQEBCD.AutoGenKey(WrkLlocn, WrkBatchNo, WrkRqnbr)
    End If
    myRQEBCD.GetOneRecordP(WrkLlocn, WrkBatchNo, WrkRqnbr, WrkRecno)
    If Not myRQEBCD.RecordNotFound Then
      MovetoDtl()
      EditChecksDtl(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myRQEBCD.UpdateOneRecordP()
      Else
        ShowErrorDtl(ErrorField, ErrorMsg)
        Return False
      End If
    Else
      With myRQEBCD
        ._LLOCN = WrkLlocn
        ._BCHNO = WrkBatchNo
        ._RQNBR = WrkRqnbr
        ._RQSEQ = WrkRecno
      End With
      MovetoDtl()
      EditChecksDtl(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myRQEBCD.AddOneRecordP()
      Else
        ShowErrorDtl(ErrorField, ErrorMsg)
        Return False
      End If
    End If

    TxtItnbr.Text = ""
    TxtItdsc.Text = ""
    TxtRqqty.Text = ""
    TxtUnitp.Text = ""
    TxtUnmsr.Text = ""
    LblRecno.Text = ""
    CalcTotals()
    FormatGrid()
    BtnAddDtl.Text = "Add Item"
    BtnRemDtl.Enabled = False
    SaveExval = 0
    Return True
  End Function
  Private Sub MovetoDtl()
    With myRQEBCD
      ._FDNBR = MyUtils.CnvSng(TxtFund.Text)
      ._SFUND = MyUtils.CnvSng(TxtSFund.Text)
      ._DPNBR = MyUtils.CnvSng(TxtDept.Text)
      ._OBNBR = MyUtils.CnvSng(TxtObj.Text)
      ._FNPGM = MyUtils.CnvSng(TxtFcn.Text)
      ._SUBFN = MyUtils.CnvSng(TxtSfcn.Text)
      ._ITDSC = TxtItdsc.Text
      ._ITNBR = TxtItnbr.Text
      ._RQQTY = MyUtils.CnvSng(TxtRqqty.Text)
      ._UNITP = MyUtils.CnvSng(TxtUnitp.Text)
      ._UNMSR = TxtUnmsr.Text
      ._EXVAL = ._RQQTY * ._UNITP
    End With
  End Sub
  Private Sub ShowErrorDtl(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    ErrProv.Clear()
    Dim I As Integer
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "acct"
          ErrProv.SetError(TxtFund, ErrorMsg(I))
        Case "itdsc"
          ErrProv.SetError(TxtItdsc, ErrorMsg(I))
        Case "overexp"
          ErrProv.SetError(LblOverExpend, ErrorMsg(I))
        Case "qty"
          ErrProv.SetError(TxtRqqty, ErrorMsg(I))
        Case "unitp"
          ErrProv.SetError(TxtUnitp, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecksDtl(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim WrkOrigBal As Decimal
    Dim WrkBal As Decimal
    Dim WrkDateFrom As Integer
    Dim WrkDateTo As Integer
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtItdsc.Text = "" Then
      ErrorField(I) = "itdsc"
      ErrorMsg(I) = "Description is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtFund.Text) = 0 And MyUtils.CnvSng(TxtRqqty.Text) = 0 _
     And MyUtils.CnvSng(TxtUnitp.Text) = 0 Then
      Exit Sub
    End If

    myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFund.Text), MyUtils.CnvSng(TxtSFund.Text), MyUtils.CnvSng(TxtDept.Text),
      MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFcn.Text), MyUtils.CnvSng(TxtSfcn.Text))
    If myGLACCT.RecordNotFound Then
      ErrorField(I) = "acct"
      ErrorMsg(I) = "Acct is invalid"
      I = I + 1
    Else
      If Trim(myGLACCT._ACREC) = "I" Then
        ErrorField(I) = "acct"
        ErrorMsg(I) = "Acct is inactive"
        I = I + 1
      End If
      If myGLACCT._GLTYP = "H" Then
        ErrorField(I) = "acct"
        ErrorMsg(I) = "Acct is header"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtRqqty.Text) = 0 Then
      ErrorField(I) = "qty"
      ErrorMsg(I) = "Quantity is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtUnitp.Text) = 0 Then
      ErrorField(I) = "unitp"
      ErrorMsg(I) = "Unit Price is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtRqqty.Text) > 9999999.99 Then
      ErrorField(I) = "qty"
      ErrorMsg(I) = "Quantity max is 9,999,999.99"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtUnitp.Text) > 999999.9999 Then
      ErrorField(I) = "unitp"
      ErrorMsg(I) = "Unit Price max is 999,999.9999"
      I = I + 1
    End If

    LblOverExpend.Visible = False
    LblOverBal.Visible = False
    WrkOverExpend = False
    With myPURCTL
      .GetOneRecordP(MyFiscyr)
      If Not .RecordNotFound Then
        WrkDateFrom = ._FSCS8
        WrkDateTo = ._FSCE8
      End If
    End With
    WrkOrigBal = GetAcctBal(myGLACCT._GLTYP, MyUtils.CnvSng(TxtFund.Text), MyUtils.CnvSng(TxtSFund.Text),
     MyUtils.CnvSng(TxtDept.Text), MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFcn.Text),
     MyUtils.CnvSng(TxtSfcn.Text), WrkDateFrom, WrkDateTo)
    WrkBal = WrkOrigBal + SaveExval - (MyUtils.CnvSng(TxtRqqty.Text) * MyUtils.CnvSng(TxtUnitp.Text))
    If WrkBal < 0 Then
      LblOverExpend.Visible = True
      LblOverBal.Visible = True
      LblOverBal.Text = Format(WrkOrigBal, "fixed")
      WrkOverExpend = True
    End If

    If WrkOverExpend And Not MyAllowOverExp Then
      ErrorField(I) = "overexp"
      ErrorMsg(I) = "Account is over Expended"
      I = I + 1
    End If

  End Sub
  Private Sub TxtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
    If Asc(e.KeyChar) = Keys.Return Then
      If LblRecno.Text = "" Then
        LblRecno.Text = myRQEBCD.AutoGenKey(WrkLlocn, WrkBatchNo, WrkRqnbr)
      End If
      SaveDtl()
    End If
  End Sub
  Private Sub LnkGLAcctRC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkGLAcct.LinkClicked
    Dim WrkAcct As String

    WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFund.Text), MyUtils.CnvSng(TxtSFund.Text), MyUtils.CnvSng(TxtDept.Text),
    MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFcn.Text), MyUtils.CnvSng(TxtSfcn.Text))
    MyFrmListGLAcct = New FrmListGLAcct
    MyFrmListGLAcct.MdiParent = Me.ParentForm
    MyFrmListGLAcct.WrkField = ""
    MyFrmListGLAcct.WrkCode = WrkAcct
    MyFrmListGLAcct.Show()
    Me.Hide()
  End Sub
  Private Sub UpdateHeader()
    CalcTotals()
    With myRQEBCH
      .GetOneRecordP(WrkLlocn, WrkBatchNo, WrkRqnbr)
      If Not .RecordNotFound Then
        ._AMTGR = MyUtils.CnvSng(LblTotAmt.Text)
        ._AMTNT = MyUtils.CnvSng(LblTotNet.Text)
        .UpdateOneRecordP()
      End If
    End With
  End Sub
  Private Sub CalcTotals()
    Dim Ds As DataSet = New DataSet
    Dim WrkAmount As Decimal
    Dim WrkDiscPct As Decimal
    Dim WrkDiscount As Decimal
    Dim WrkShipPct As Decimal
    Dim WrkShipping As Decimal
    Dim WrkNet As Decimal
    Dim I As Integer

    WrkAmount = 0
    Ds = myRQEBCDL1.GetViewbyRqnbr(WrkLlocn, WrkBatchNo, WrkRqnbr, 0)
    For I = 0 To Ds.Tables(0).Rows.Count - 1
      WrkAmount = WrkAmount + Ds.Tables(0).Rows(I).Item("exval")
    Next
    WrkDiscPct = MyUtils.CnvSng(TxtOrdsp.Text) / 100
    If WrkDiscPct > 0 Then
      WrkDiscount = Math.Round(WrkDiscPct * WrkAmount, 2)
    Else
      WrkDiscount = MyUtils.CnvSng(TxtDscdl.Text)
    End If
    WrkShipPct = MyUtils.CnvSng(TxtOrshp.Text) / 100
    If WrkShipPct > 0 Then
      WrkShipping = Math.Round(WrkShipPct * WrkAmount, 2)
    Else
      WrkShipping = MyUtils.CnvSng(TxtShpdl.Text)
    End If
    WrkNet = WrkAmount - WrkDiscount + WrkShipping
    LblTotAmt.Text = Format(WrkAmount, "fixed")
    LblDiscount.Text = Format(WrkDiscount, "fixed")
    LblShipping.Text = Format(WrkShipping, "fixed")
    LblTotNet.Text = Format(WrkNet, "fixed")
  End Sub
  Private Sub CalcExtend()
    Dim Ds As DataSet = New DataSet
    Dim WrkAmount As Decimal

    WrkAmount = MyUtils.CnvSng(TxtRqqty.Text) * MyUtils.CnvSng(TxtUnitp.Text)
    LblExtend.Text = Format(WrkAmount, "fixed")
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    If DataGrdView.RowCount = 0 Then Exit Sub
    If DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value <> "" Then
      LblRecno.Text = DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value
      TxtItnbr.Text = Trim(DataGrdView.Item(4, DataGrdView.CurrentRow.Index).Value)
      TxtItdsc.Text = Trim(DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value)
      TxtRqqty.Text = DataGrdView.Item(7, DataGrdView.CurrentRow.Index).Value
      TxtUnitp.Text = DataGrdView.Item(8, DataGrdView.CurrentRow.Index).Value
      TxtUnmsr.Text = Trim(DataGrdView.Item(9, DataGrdView.CurrentRow.Index).Value)
      TxtFund.Text = DataGrdView.Item(10, DataGrdView.CurrentRow.Index).Value
      TxtSFund.Text = DataGrdView.Item(11, DataGrdView.CurrentRow.Index).Value
      TxtDept.Text = DataGrdView.Item(12, DataGrdView.CurrentRow.Index).Value
      TxtObj.Text = DataGrdView.Item(13, DataGrdView.CurrentRow.Index).Value
      TxtFcn.Text = DataGrdView.Item(14, DataGrdView.CurrentRow.Index).Value
      TxtSfcn.Text = DataGrdView.Item(15, DataGrdView.CurrentRow.Index).Value
      SaveExval = MyUtils.CnvSng(TxtRqqty.Text) * MyUtils.CnvSng(TxtUnitp.Text)
      BtnAddDtl.Text = "Update Item"
      BtnRemDtl.Enabled = True
      LblOverExpend.Visible = False
      WrkOverExpend = False
      CalcExtend()
    End If

  End Sub

  Private Sub LnkVndnr_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkVndnr.LinkClicked
    MyFrmListVendor = New FrmListVendor
    MyFrmListVendor.MdiParent = Me.ParentForm
    MyFrmListVendor.WrkCode = TxtVndnr.Text
    MyFrmListVendor.Show()
    Me.Hide()
  End Sub
  Private Function GetVendorName(ByVal Vndnr As String) As String
    myVENDOR.GetOneRecordP(Vndnr)
    With myVENDOR
      If .RecordNotFound Then Return String.Empty
      Return ._VENNM
    End With

  End Function
  Private Sub TxtVndnr_Leave(sender As Object, e As EventArgs) Handles TxtVndnr.Leave
    LblVennm.Text = GetVendorName(TxtVndnr.Text)
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
  Private Sub BtnAddDtl_Click(sender As Object, e As EventArgs) Handles BtnAddDtl.Click
    SaveDtl()
  End Sub

  Private Sub BtnRemDtl_Click(sender As Object, e As EventArgs) Handles BtnRemDtl.Click
    DeleteDtl()
  End Sub
  Private Sub TxtLne_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtLne.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtPrj_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPrj.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtOrdsp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtOrdsp.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtDscdl_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDscdl.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtOrshp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtOrshp.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtShpdl_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtShpdl.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtFdnbd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFdnbd.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfudd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfudd.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDpnbd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDpnbd.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtObnbd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtObnbd.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFnpgd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFnpgd.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSubfd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSubfd.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFdnbs_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFdnbs.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfuns_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfuns.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDpnbs_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDpnbs.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtObnbs_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtObnbs.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFnpgs_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFnpgs.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSubfs_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSubfs.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtRqqty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtRqqty.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtUnitp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtUnitp.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtFund_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFund.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfund_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSFund.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDept_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDept.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtObj_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtObj.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFcn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFcn.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfcn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfcn.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtOrdsp_TextChanged(sender As Object, e As EventArgs) Handles TxtOrdsp.TextChanged
    CalcTotals()
  End Sub
  Private Sub TxtDscdl_TextChanged(sender As Object, e As EventArgs) Handles TxtDscdl.TextChanged
    CalcTotals()
  End Sub
  Private Sub TxtOrshp_TextChanged(sender As Object, e As EventArgs) Handles TxtOrshp.TextChanged
    CalcTotals()
  End Sub
  Private Sub TxtShpdl_TextChanged(sender As Object, e As EventArgs) Handles TxtShpdl.TextChanged
    CalcTotals()
  End Sub

  Private Sub TxtRqqty_TextChanged(sender As Object, e As EventArgs) Handles TxtRqqty.TextChanged
    CalcExtend()
  End Sub

  Private Sub TxtUnitp_TextChanged(sender As Object, e As EventArgs) Handles TxtUnitp.TextChanged
    CalcExtend()
  End Sub

  Private Sub DataGrdView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrdView.CellContentClick

  End Sub
End Class
