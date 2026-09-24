Public Class FrmAP201E
  Inherits System.Windows.Forms.Form
  Dim myBCHHDR As BCHHDR.myData
  Dim myAPEBCH As APEBCH.myData
  Dim myAPEBCHL1 As APEBCHL1.MyData
  Dim myAPEBCD As APEBCD.MyData
  Dim myAPEBCDL1 As APEBCDL1.MyData
  Dim myAPEOPN As APEOPN.MyData
  Dim myAPEHSTL1 As APEHSTL1.MyData
  Dim myGLACCT As GLACCT.MyData
  Dim myVENDOR As VENDOR.MyData
  Dim myPOMAST As POMAST.MyData
  Dim myPOMASTL1 As POMASTL1.MyData
  Dim myPOSUMFL1 As POSUMFL1.MyData

  Friend WrkBatchNo As Integer
  Friend WrkSeqno As Integer
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
  Friend WithEvents TxtFscyr As System.Windows.Forms.TextBox
  Friend WithEvents TxtPONbr As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtInvno As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents TxtPpamt As System.Windows.Forms.TextBox
  Friend WithEvents TxtPpckn As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents TxtBnkcd As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtDsctx As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents DtPckPpdt8 As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtAmtnt As System.Windows.Forms.TextBox
  Friend WithEvents DtpckAppst As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckDued8 As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckInvd8 As System.Windows.Forms.DateTimePicker
  Friend WithEvents LblPOOpen As System.Windows.Forms.Label
  Friend WithEvents LblMiscHdr As System.Windows.Forms.Label
  Friend WithEvents LblPONet As System.Windows.Forms.Label
  Friend WithEvents LblFeeHdr As System.Windows.Forms.Label
  Friend WithEvents ChkF1099 As System.Windows.Forms.CheckBox
  Friend WithEvents LblDetailAmt As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents LblVennm As System.Windows.Forms.Label
  Friend WithEvents ChkLeopn As System.Windows.Forms.CheckBox
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents LblSeqno As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Dim WrkRecno As Integer
  Friend WithEvents LblRecno As System.Windows.Forms.Label
  Friend WithEvents BtnRemDtl As System.Windows.Forms.Button
  Friend WithEvents BtnAddDtl As System.Windows.Forms.Button
  Friend WithEvents LblOverExpend As System.Windows.Forms.Label
  Dim WrkReceiptDate As Date

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
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents TxtAmount As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAP201E))
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtAmount = New System.Windows.Forms.TextBox()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LnkGLAcct = New System.Windows.Forms.LinkLabel()
    Me.TxtSfcn = New System.Windows.Forms.TextBox()
    Me.TxtFcn = New System.Windows.Forms.TextBox()
    Me.TxtObj = New System.Windows.Forms.TextBox()
    Me.TxtDept = New System.Windows.Forms.TextBox()
    Me.TxtSFund = New System.Windows.Forms.TextBox()
    Me.TxtFund = New System.Windows.Forms.TextBox()
    Me.TxtInvno = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtPONbr = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtFscyr = New System.Windows.Forms.TextBox()
    Me.TxtPrj = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.LnkVndnr = New System.Windows.Forms.LinkLabel()
    Me.TxtVndnr = New System.Windows.Forms.TextBox()
    Me.TxtDsctx = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtBnkcd = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtPpckn = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TxtPpamt = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.LblPOOpen = New System.Windows.Forms.Label()
    Me.LblMiscHdr = New System.Windows.Forms.Label()
    Me.LblPONet = New System.Windows.Forms.Label()
    Me.LblFeeHdr = New System.Windows.Forms.Label()
    Me.DtPckInvd8 = New System.Windows.Forms.DateTimePicker()
    Me.DtPckDued8 = New System.Windows.Forms.DateTimePicker()
    Me.DtpckAppst = New System.Windows.Forms.DateTimePicker()
    Me.TxtAmtnt = New System.Windows.Forms.TextBox()
    Me.DtPckPpdt8 = New System.Windows.Forms.DateTimePicker()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.LblDetailAmt = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.ChkF1099 = New System.Windows.Forms.CheckBox()
    Me.LblVennm = New System.Windows.Forms.Label()
    Me.ChkLeopn = New System.Windows.Forms.CheckBox()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.LblSeqno = New System.Windows.Forms.Label()
    Me.LblRecno = New System.Windows.Forms.Label()
    Me.BtnRemDtl = New System.Windows.Forms.Button()
    Me.BtnAddDtl = New System.Windows.Forms.Button()
    Me.LblOverExpend = New System.Windows.Forms.Label()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(341, 372)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Amount"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtAmount
        '
        Me.TxtAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAmount.Location = New System.Drawing.Point(390, 369)
        Me.TxtAmount.MaxLength = 10
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.Size = New System.Drawing.Size(70, 20)
        Me.TxtAmount.TabIndex = 24
        Me.TxtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LnkGLAcct
        '
        Me.LnkGLAcct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkGLAcct.ForeColor = System.Drawing.Color.Maroon
        Me.LnkGLAcct.Location = New System.Drawing.Point(21, 372)
        Me.LnkGLAcct.Name = "LnkGLAcct"
        Me.LnkGLAcct.Size = New System.Drawing.Size(36, 18)
        Me.LnkGLAcct.TabIndex = 17
        Me.LnkGLAcct.TabStop = True
        Me.LnkGLAcct.Text = "Acct"
        '
        'TxtSfcn
        '
        Me.TxtSfcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSfcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSfcn.Location = New System.Drawing.Point(282, 368)
        Me.TxtSfcn.MaxLength = 4
        Me.TxtSfcn.Name = "TxtSfcn"
        Me.TxtSfcn.Size = New System.Drawing.Size(45, 22)
        Me.TxtSfcn.TabIndex = 23
        '
        'TxtFcn
        '
        Me.TxtFcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFcn.Location = New System.Drawing.Point(231, 368)
        Me.TxtFcn.MaxLength = 4
        Me.TxtFcn.Name = "TxtFcn"
        Me.TxtFcn.Size = New System.Drawing.Size(45, 22)
        Me.TxtFcn.TabIndex = 22
        '
        'TxtObj
        '
        Me.TxtObj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtObj.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtObj.Location = New System.Drawing.Point(195, 368)
        Me.TxtObj.MaxLength = 3
        Me.TxtObj.Name = "TxtObj"
        Me.TxtObj.Size = New System.Drawing.Size(32, 22)
        Me.TxtObj.TabIndex = 21
        '
        'TxtDept
        '
        Me.TxtDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDept.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDept.Location = New System.Drawing.Point(144, 368)
        Me.TxtDept.MaxLength = 4
        Me.TxtDept.Name = "TxtDept"
        Me.TxtDept.Size = New System.Drawing.Size(45, 22)
        Me.TxtDept.TabIndex = 20
        '
        'TxtSFund
        '
        Me.TxtSFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSFund.Location = New System.Drawing.Point(106, 368)
        Me.TxtSFund.MaxLength = 3
        Me.TxtSFund.Name = "TxtSFund"
        Me.TxtSFund.Size = New System.Drawing.Size(32, 22)
        Me.TxtSFund.TabIndex = 19
        '
        'TxtFund
        '
        Me.TxtFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFund.Location = New System.Drawing.Point(68, 368)
        Me.TxtFund.MaxLength = 3
        Me.TxtFund.Name = "TxtFund"
        Me.TxtFund.Size = New System.Drawing.Size(32, 22)
        Me.TxtFund.TabIndex = 18
        '
        'TxtInvno
        '
        Me.TxtInvno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtInvno.Location = New System.Drawing.Point(135, 6)
        Me.TxtInvno.MaxLength = 30
        Me.TxtInvno.Name = "TxtInvno"
        Me.TxtInvno.Size = New System.Drawing.Size(161, 20)
        Me.TxtInvno.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Invoice Number/Date"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtPONbr
        '
        Me.TxtPONbr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPONbr.Location = New System.Drawing.Point(135, 29)
        Me.TxtPONbr.MaxLength = 10
        Me.TxtPONbr.Name = "TxtPONbr"
        Me.TxtPONbr.Size = New System.Drawing.Size(80, 20)
        Me.TxtPONbr.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "PO Number/Fiscal Year"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtFscyr
        '
        Me.TxtFscyr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFscyr.Location = New System.Drawing.Point(222, 29)
        Me.TxtFscyr.MaxLength = 4
        Me.TxtFscyr.Name = "TxtFscyr"
        Me.TxtFscyr.Size = New System.Drawing.Size(32, 20)
        Me.TxtFscyr.TabIndex = 3
        Me.TxtFscyr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPrj
        '
        Me.TxtPrj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPrj.Location = New System.Drawing.Point(392, 110)
        Me.TxtPrj.MaxLength = 10
        Me.TxtPrj.Name = "TxtPrj"
        Me.TxtPrj.Size = New System.Drawing.Size(45, 20)
        Me.TxtPrj.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(346, 112)
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
        Me.LnkVndnr.Location = New System.Drawing.Point(12, 83)
        Me.LnkVndnr.Name = "LnkVndnr"
        Me.LnkVndnr.Size = New System.Drawing.Size(81, 13)
        Me.LnkVndnr.TabIndex = 5
        Me.LnkVndnr.TabStop = True
        Me.LnkVndnr.Text = "Vendor Number"
        '
        'TxtVndnr
        '
        Me.TxtVndnr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtVndnr.Location = New System.Drawing.Point(135, 80)
        Me.TxtVndnr.MaxLength = 5
        Me.TxtVndnr.Name = "TxtVndnr"
        Me.TxtVndnr.Size = New System.Drawing.Size(45, 20)
        Me.TxtVndnr.TabIndex = 6
        '
        'TxtDsctx
        '
        Me.TxtDsctx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDsctx.Location = New System.Drawing.Point(135, 109)
        Me.TxtDsctx.MaxLength = 30
        Me.TxtDsctx.Name = "TxtDsctx"
        Me.TxtDsctx.Size = New System.Drawing.Size(205, 20)
        Me.TxtDsctx.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Description"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtBnkcd
        '
        Me.TxtBnkcd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBnkcd.Location = New System.Drawing.Point(499, 158)
        Me.TxtBnkcd.MaxLength = 5
        Me.TxtBnkcd.Name = "TxtBnkcd"
        Me.TxtBnkcd.Size = New System.Drawing.Size(45, 20)
        Me.TxtBnkcd.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 13)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Invoice Amount"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtPpckn
        '
        Me.TxtPpckn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPpckn.Location = New System.Drawing.Point(135, 158)
        Me.TxtPpckn.MaxLength = 7
        Me.TxtPpckn.Name = "TxtPpckn"
        Me.TxtPpckn.Size = New System.Drawing.Size(45, 20)
        Me.TxtPpckn.TabIndex = 10
        Me.TxtPpckn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 161)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 13)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "Prepaid Check Number"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtPpamt
        '
        Me.TxtPpamt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPpamt.Location = New System.Drawing.Point(379, 158)
        Me.TxtPpamt.MaxLength = 13
        Me.TxtPpamt.Name = "TxtPpamt"
        Me.TxtPpamt.Size = New System.Drawing.Size(45, 20)
        Me.TxtPpamt.TabIndex = 12
        Me.TxtPpamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(330, 161)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "Amount"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(433, 161)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 13)
        Me.Label13.TabIndex = 49
        Me.Label13.Text = "Bank Code"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 191)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 13)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "G/L Posting Date"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblPOOpen
        '
        Me.LblPOOpen.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblPOOpen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblPOOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPOOpen.Location = New System.Drawing.Point(524, 38)
        Me.LblPOOpen.Name = "LblPOOpen"
        Me.LblPOOpen.Size = New System.Drawing.Size(64, 16)
        Me.LblPOOpen.TabIndex = 385
        Me.LblPOOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblMiscHdr
        '
        Me.LblMiscHdr.AutoSize = True
        Me.LblMiscHdr.BackColor = System.Drawing.SystemColors.Control
        Me.LblMiscHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMiscHdr.Location = New System.Drawing.Point(467, 40)
        Me.LblMiscHdr.Name = "LblMiscHdr"
        Me.LblMiscHdr.Size = New System.Drawing.Size(51, 13)
        Me.LblMiscHdr.TabIndex = 384
        Me.LblMiscHdr.Text = "PO Open"
        '
        'LblPONet
        '
        Me.LblPONet.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblPONet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblPONet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPONet.Location = New System.Drawing.Point(524, 22)
        Me.LblPONet.Name = "LblPONet"
        Me.LblPONet.Size = New System.Drawing.Size(64, 16)
        Me.LblPONet.TabIndex = 383
        Me.LblPONet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblFeeHdr
        '
        Me.LblFeeHdr.AutoSize = True
        Me.LblFeeHdr.BackColor = System.Drawing.SystemColors.Control
        Me.LblFeeHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFeeHdr.Location = New System.Drawing.Point(476, 24)
        Me.LblFeeHdr.Name = "LblFeeHdr"
        Me.LblFeeHdr.Size = New System.Drawing.Size(42, 13)
        Me.LblFeeHdr.TabIndex = 382
        Me.LblFeeHdr.Text = "PO Net"
        '
        'DtPckInvd8
        '
        Me.DtPckInvd8.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckInvd8.Location = New System.Drawing.Point(302, 6)
        Me.DtPckInvd8.Name = "DtPckInvd8"
        Me.DtPckInvd8.Size = New System.Drawing.Size(84, 20)
        Me.DtPckInvd8.TabIndex = 1
        '
        'DtPckDued8
        '
        Me.DtPckDued8.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckDued8.Location = New System.Drawing.Point(302, 29)
        Me.DtPckDued8.Name = "DtPckDued8"
        Me.DtPckDued8.Size = New System.Drawing.Size(84, 20)
        Me.DtPckDued8.TabIndex = 4
        '
        'DtpckAppst
        '
        Me.DtpckAppst.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpckAppst.Location = New System.Drawing.Point(135, 185)
        Me.DtpckAppst.Name = "DtpckAppst"
        Me.DtpckAppst.Size = New System.Drawing.Size(84, 20)
        Me.DtpckAppst.TabIndex = 14
        '
        'TxtAmtnt
        '
        Me.TxtAmtnt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAmtnt.Location = New System.Drawing.Point(135, 133)
        Me.TxtAmtnt.MaxLength = 13
        Me.TxtAmtnt.Name = "TxtAmtnt"
        Me.TxtAmtnt.Size = New System.Drawing.Size(80, 20)
        Me.TxtAmtnt.TabIndex = 9
        Me.TxtAmtnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DtPckPpdt8
        '
        Me.DtPckPpdt8.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckPpdt8.Location = New System.Drawing.Point(222, 158)
        Me.DtPckPpdt8.Name = "DtPckPpdt8"
        Me.DtPckPpdt8.Size = New System.Drawing.Size(84, 20)
        Me.DtPckPpdt8.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(186, 161)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(30, 13)
        Me.Label14.TabIndex = 391
        Me.Label14.Text = "Date"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblDetailAmt
        '
        Me.LblDetailAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblDetailAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblDetailAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDetailAmt.Location = New System.Drawing.Point(524, 54)
        Me.LblDetailAmt.Name = "LblDetailAmt"
        Me.LblDetailAmt.Size = New System.Drawing.Size(64, 16)
        Me.LblDetailAmt.TabIndex = 393
        Me.LblDetailAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(444, 57)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 13)
        Me.Label16.TabIndex = 392
        Me.Label16.Text = "Detail Amount"
        '
        'ChkF1099
        '
        Me.ChkF1099.AutoSize = True
        Me.ChkF1099.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkF1099.Location = New System.Drawing.Point(532, 130)
        Me.ChkF1099.Name = "ChkF1099"
        Me.ChkF1099.Size = New System.Drawing.Size(56, 17)
        Me.ChkF1099.TabIndex = 16
        Me.ChkF1099.Text = "1099?"
        Me.ChkF1099.UseVisualStyleBackColor = True
        '
        'LblVennm
        '
        Me.LblVennm.AutoSize = True
        Me.LblVennm.Location = New System.Drawing.Point(186, 83)
        Me.LblVennm.Name = "LblVennm"
        Me.LblVennm.Size = New System.Drawing.Size(84, 13)
        Me.LblVennm.TabIndex = 395
        Me.LblVennm.Text = "<Vendor Name>"
        Me.LblVennm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblVennm.UseMnemonic = False
        '
        'ChkLeopn
        '
        Me.ChkLeopn.AutoSize = True
        Me.ChkLeopn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkLeopn.Checked = True
        Me.ChkLeopn.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkLeopn.Location = New System.Drawing.Point(461, 113)
        Me.ChkLeopn.Name = "ChkLeopn"
        Me.ChkLeopn.Size = New System.Drawing.Size(127, 17)
        Me.ChkLeopn.TabIndex = 15
        Me.ChkLeopn.Text = "Leave Encum Open?"
        Me.ChkLeopn.UseVisualStyleBackColor = True
        '
        'C1DataGrdList
        '
        Me.C1DataGrdList.AllowColSelect = False
        Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.C1DataGrdList.AllowUpdate = False
        Me.C1DataGrdList.AlternatingRows = True
        Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
        Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
        Me.C1DataGrdList.Location = New System.Drawing.Point(15, 214)
        Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
        Me.C1DataGrdList.Name = "C1DataGrdList"
        Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
        Me.C1DataGrdList.PrintInfo.MeasurementDevice = C1.Win.C1TrueDBGrid.PrintInfo.MeasurementDeviceEnum.Screen
        Me.C1DataGrdList.PrintInfo.MeasurementPrinterName = Nothing
        Me.C1DataGrdList.Size = New System.Drawing.Size(576, 148)
        Me.C1DataGrdList.TabIndex = 397
        Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(269, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 398
        Me.Label7.Text = "Due"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 399
        Me.Label10.Text = "Description"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(521, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 13)
        Me.Label8.TabIndex = 400
        Me.Label8.Text = "Seq"
        '
        'LblSeqno
        '
        Me.LblSeqno.AutoSize = True
        Me.LblSeqno.BackColor = System.Drawing.SystemColors.Control
        Me.LblSeqno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeqno.Location = New System.Drawing.Point(553, 6)
        Me.LblSeqno.Name = "LblSeqno"
        Me.LblSeqno.Size = New System.Drawing.Size(38, 13)
        Me.LblSeqno.TabIndex = 401
        Me.LblSeqno.Text = "<Seq>"
        '
        'LblRecno
        '
        Me.LblRecno.AutoSize = True
        Me.LblRecno.Location = New System.Drawing.Point(553, 398)
        Me.LblRecno.Name = "LblRecno"
        Me.LblRecno.Size = New System.Drawing.Size(46, 13)
        Me.LblRecno.TabIndex = 402
        Me.LblRecno.Text = "<recno>"
        Me.LblRecno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnRemDtl
        '
        Me.BtnRemDtl.Location = New System.Drawing.Point(466, 393)
        Me.BtnRemDtl.Name = "BtnRemDtl"
        Me.BtnRemDtl.Size = New System.Drawing.Size(81, 22)
        Me.BtnRemDtl.TabIndex = 26
        Me.BtnRemDtl.TabStop = False
        Me.BtnRemDtl.Text = "Remove Item"
        Me.BtnRemDtl.UseVisualStyleBackColor = True
        '
        'BtnAddDtl
        '
        Me.BtnAddDtl.Location = New System.Drawing.Point(379, 393)
        Me.BtnAddDtl.Name = "BtnAddDtl"
        Me.BtnAddDtl.Size = New System.Drawing.Size(81, 22)
        Me.BtnAddDtl.TabIndex = 25
        Me.BtnAddDtl.TabStop = False
        Me.BtnAddDtl.Text = "Add Item"
        Me.BtnAddDtl.UseVisualStyleBackColor = True
        '
        'LblOverExpend
        '
        Me.LblOverExpend.AutoSize = True
        Me.LblOverExpend.BackColor = System.Drawing.SystemColors.Control
        Me.LblOverExpend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOverExpend.ForeColor = System.Drawing.Color.Fuchsia
        Me.LblOverExpend.Location = New System.Drawing.Point(471, 372)
        Me.LblOverExpend.Name = "LblOverExpend"
        Me.LblOverExpend.Size = New System.Drawing.Size(112, 13)
        Me.LblOverExpend.TabIndex = 466
        Me.LblOverExpend.Text = "OVER EXPENDED"
        '
        'FrmAP201E
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(626, 449)
        Me.Controls.Add(Me.LblOverExpend)
        Me.Controls.Add(Me.BtnRemDtl)
        Me.Controls.Add(Me.BtnAddDtl)
        Me.Controls.Add(Me.LblRecno)
        Me.Controls.Add(Me.LblPONet)
        Me.Controls.Add(Me.LblSeqno)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.C1DataGrdList)
        Me.Controls.Add(Me.ChkLeopn)
        Me.Controls.Add(Me.LblVennm)
        Me.Controls.Add(Me.ChkF1099)
        Me.Controls.Add(Me.LblDetailAmt)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.DtPckPpdt8)
        Me.Controls.Add(Me.TxtAmtnt)
        Me.Controls.Add(Me.DtpckAppst)
        Me.Controls.Add(Me.DtPckDued8)
        Me.Controls.Add(Me.DtPckInvd8)
        Me.Controls.Add(Me.LblPOOpen)
        Me.Controls.Add(Me.LblMiscHdr)
        Me.Controls.Add(Me.LblFeeHdr)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtPpamt)
        Me.Controls.Add(Me.TxtPpckn)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtBnkcd)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtDsctx)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtVndnr)
        Me.Controls.Add(Me.LnkVndnr)
        Me.Controls.Add(Me.TxtPrj)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtFscyr)
        Me.Controls.Add(Me.TxtPONbr)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtInvno)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LnkGLAcct)
        Me.Controls.Add(Me.TxtSfcn)
        Me.Controls.Add(Me.TxtFcn)
        Me.Controls.Add(Me.TxtObj)
        Me.Controls.Add(Me.TxtDept)
        Me.Controls.Add(Me.TxtSFund)
        Me.Controls.Add(Me.TxtFund)
        Me.Controls.Add(Me.TxtAmount)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAP201E"
        Me.Text = "Maintain Accounts Payable Detail"
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmAP201E_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myAPEBCH = New APEBCH.MyData()
    myAPEBCH.MyDBConn = myDBConnect
    myAPEBCHL1 = New APEBCHL1.MyData()
    myAPEBCHL1.MyDBConn = myDBConnect
    myAPEBCD = New APEBCD.MyData()
    myAPEBCD.MyDBConn = myDBConnect
    myAPEBCDL1 = New APEBCDL1.MyData()
    myAPEBCDL1.MyDBConn = myDBConnect
    myAPEOPN = New APEOPN.MyData()
    myAPEOPN.MyDBConn = myDBConnect
    myAPEHSTL1 = New APEHSTL1.MyData()
    myAPEHSTL1.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect
    myPOMAST = New POMAST.MyData()
    myPOMAST.MyDBConn = myDBConnect
    myPOMASTL1 = New POMASTL1.MyData()
    myPOMASTL1.MyDBConn = myDBConnect
    myPOSUMFL1 = New POSUMFL1.MyData()
    myPOSUMFL1.MyDBConn = myDBConnect

    MyFrmAP201.TBarNew.Enabled = False
    MyFrmAP201.TBarSave.Enabled = True

    If WrkSeqno > 0 Then
      MyFrmAP201.TBarDelete.Enabled = True
    Else
      AddMode = True
      WrkSeqno = myAPEBCH.AutoGenKey(WrkBatchNo)
      myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
      myAPEBCH.GetOneRecordP(WrkBatchNo, WrkSeqno)
      With myAPEBCH
        WrkReceiptDate = MyUtils.GetDBDate(._DUED8)
      End With
    End If

    myAPEBCH.GetOneRecordP(WrkBatchNo, WrkSeqno)
    LblOverExpend.Visible = False
    LblSeqno.Text = WrkSeqno
    LblRecno.Text = ""
    LblVennm.Text = ""
    LblPONet.Text = ""
    LblPOOpen.Text = ""
    LblDetailAmt.Text = ""
    If myAPEBCH.RecordNotFound Then Exit Sub

    With myAPEBCH
      TxtInvno.Text = Trim(._INVNO)
      DtPckInvd8.Value = MyUtils.GetDBDate(._INVD8)
      If ._PONBR > 0 Then
        TxtPONbr.Text = ._PONBR
        TxtFscyr.Text = ._FSCYR
        myPOMAST.GetOneRecordP(._FSCYR, ._PONBR, 0, 0, 0)
        LblPONet.Text = Format(myPOMAST._AMTNT, "fixed")
        LblPOOpen.Text = Format(myPOMAST._POPEN, "fixed")
      End If
      TxtFscyr.Text = ._FSCYR
      DtPckDued8.Value = MyUtils.GetDBDate(._DUED8)
      TxtDsctx.Text = Trim(._DSCTX)
      TxtVndnr.Text = Trim(._VNDNR)
      LblVennm.Text = Trim(._VENNM)
      If ._PRJ > 0 Then
        TxtPrj.Text = ._PRJ
      End If
      If ._AMTNT <> 0 Then
        TxtAmtnt.Text = Format(._AMTNT, "fixed")
      End If
      If ._PPCKN > 0 Then
        TxtPpckn.Text = ._PPCKN
      End If
      If ._PPDT8 > 0 Then
        DtPckPpdt8.Value = MyUtils.GetDBDate(._PPDT8)
      End If
      If ._PPAMT <> 0 Then
        TxtPpamt.Text = Format(._PPAMT, "fixed")
      End If
      TxtBnkcd.Text = Trim(._BNKCD)
      DtpckAppst.Value = MyUtils.GetDBDate(._APPST)
      If ._F1099 = "Y" Then
        ChkF1099.Checked = True
      Else
        ChkF1099.Checked = False
      End If
      If ._LEOPN = "P" Then
        ChkLeopn.Checked = True
      Else
        ChkLeopn.Checked = False
      End If
    End With
    FormatGrid()
    LblDetailAmt.Text = Format(CalcTotals(), "fixed")
    If MyUtils.CnvSng(TxtAmtnt.Text) = MyUtils.CnvSng(LblDetailAmt.Text) Then
      LblDetailAmt.BackColor = Color.Aqua
    Else
      LblDetailAmt.BackColor = Color.Pink
    End If
    If C1DataGrdList.VisibleRows = 0 Then
      BtnRemDtl.Enabled = False
    End If
    Me.Text = "Batch " & WrkBatchNo & " - " & Me.Text
  End Sub

  Private Sub FrmAP201E_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmAP201.SbpScreen.Text = "AP201E"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub

  Private Sub FrmAP201E_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmAP201.TBarNew.Enabled = True
    MyFrmAP201.TBarDelete.Enabled = False
    MyFrmAP201.TBarSave.Enabled = False
    MyFrmAP201D.FormatGrid()
    MyFrmAP201D.Show()
    'Memory Cleanup
    myAPEBCH = Nothing
    MyFrmAP201E = Nothing
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()

    With C1DataGrdList
      .Rebind(True)
      .FetchRowStyles = True
      .Splits(0).DisplayColumns(0).Visible = False
      .Splits(0).DisplayColumns(1).Visible = False
      .Columns(2).Caption = "Rec No"
      .Splits(0).DisplayColumns(2).Width = 45
      .Columns(3).Caption = "Fund"
      .Splits(0).DisplayColumns(3).Width = 40
      .Columns(4).Caption = "Sfund"
      .Splits(0).DisplayColumns(4).Width = 40
      .Columns(5).Caption = "Dept"
      .Splits(0).DisplayColumns(5).Width = 40
      .Columns(6).Caption = "Obj"
      .Splits(0).DisplayColumns(6).Width = 40
      .Columns(7).Caption = "Func"
      .Splits(0).DisplayColumns(7).Width = 40
      .Columns(8).Caption = "Sfcn"
      .Splits(0).DisplayColumns(8).Width = 40
      .Columns(9).Caption = "Amount"
      .Splits(0).DisplayColumns(9).Width = 75
      .Splits(0).DisplayColumns(10).Visible = False
    End With

  End Sub
  Public Sub ShowGrid()
    Dim ds As DataSet = New DataSet
    ds = myAPEBCDL1.GetViewbySeqno(WrkBatchNo, WrkSeqno, 0)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()
  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = False
    Answer = MsgBox("Delete this Invoice?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
    If Answer = vbNo Then
      Cancel = True
      Exit Sub
    End If

    myAPEBCD.DeleteSeqno(WrkBatchNo, WrkSeqno)
    myAPEBCH.DeleteOneRecordP()
  End Sub
  Public Function SaveData(ByVal WrkClose As Boolean, ByVal WrkEditDescr As Boolean, WrkPOLiq As String) As Boolean
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    Dim Good As Boolean

    Good = False
    myAPEBCH.GetOneRecordP(WrkBatchNo, WrkSeqno)
    If Not myAPEBCH.RecordNotFound Then
      MovetoFile(WrkPOLiq)
      EditChecks(ErrorField, ErrorMsg, WrkClose, WrkEditDescr)
      If IsNothing(ErrorMsg(0)) Then
        myAPEBCH.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Return False
      End If
    Else
      With myAPEBCH
        ._BCHNO = WrkBatchNo
        ._SEQNO = WrkSeqno
        ._POLIQ = ""
      End With
      MovetoFile(WrkPOLiq)
      EditChecks(ErrorField, ErrorMsg, WrkClose, WrkEditDescr)
      If IsNothing(ErrorMsg(0)) Then
        myAPEBCH.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Return False
      End If
    End If
    If WrkClose Then
      Me.Close()
    End If
    Return True
  End Function
  Private Sub MovetoFile(ByVal WrkPOLiq As String)
    With myAPEBCH
      ._AMTDS = 0
      ._AMTNT = MyUtils.CnvSng(TxtAmtnt.Text)
      ._AMTGR = MyUtils.CnvSng(TxtAmtnt.Text)
      ._AMTSH = 0
      ._APPST = MyUtils.SetDBDate(DtpckAppst.Value)
      ._BNKCD = TxtBnkcd.Text
      ._CSHYN = ""
      ._DSCTX = TxtDsctx.Text
      ._DUED8 = MyUtils.SetDBDate(DtPckDued8.Value)
      If ChkF1099.Checked Then
        ._F1099 = "Y"
      Else
        ._F1099 = ""
      End If
      ._FSCYR = MyUtils.CnvSng(TxtFscyr.Text)
      ._HINV = ""
      ._INVNO = TxtInvno.Text
      ._INVD8 = MyUtils.SetDBDate(DtPckInvd8.Value)
      If ChkLeopn.Checked Then
        ._LEOPN = "P"
      Else
        ._LEOPN = ""
      End If
      If WrkPOLiq = "N" Then ._POLIQ = "N"
      If WrkPOLiq = "Y" Then ._POLIQ = ""
      ._PONBR = MyUtils.CnvSng(TxtPONbr.Text)
      ._PRJ = MyUtils.CnvSng(TxtPrj.Text)
      ._PPAMT = MyUtils.CnvSng(TxtPpamt.Text)
      ._PPCKN = MyUtils.CnvSng(TxtPpckn.Text)
      If ._PPAMT > 0 Then
        ._PPDT8 = MyUtils.SetDBDate(DtPckPpdt8.Value)
      Else
        ._PPDT8 = 0
      End If
      ._VENNM = LblVennm.Text
      ._VNDNR = TxtVndnr.Text
    End With
  End Sub

  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.Clear()
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "invno"
          ErrProv.SetError(TxtInvno, ErrorMsg(I))
        Case "vndnr"
          ErrProv.SetError(TxtVndnr, ErrorMsg(I))
        Case "dsctx"
          ErrProv.SetError(TxtDsctx, ErrorMsg(I))
        Case "ponbr"
          ErrProv.SetError(TxtPONbr, ErrorMsg(I))
        Case "amtnt"
          ErrProv.SetError(TxtAmtnt, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String, WrkClose As Boolean, ByVal WrkEditDescr As Boolean)
    Dim dsChk As DataSet = New DataSet
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtInvno.Text = "" Then
      ErrorField(I) = "invno"
      ErrorMsg(I) = "Invoice Number is required"
      I = I + 1
    Else
      dsChk = myAPEBCHL1.GetInvno(TxtVndnr.Text, TxtInvno.Text)
      If dsChk.Tables(0).Rows.Count > 1 Then
        ErrorField(I) = "invno"
        ErrorMsg(I) = "Invoice Number already in a batch"
        I = I + 1
      End If
      If myTOWN._TOWNBR <> 37 Then 'Derby then
        myAPEOPN.GetOneRecordP(TxtVndnr.Text, TxtInvno.Text, 0)
        If Not myAPEOPN.RecordNotFound Then
          ErrorField(I) = "invno"
          ErrorMsg(I) = "Invoice Number is already used"
          I = I + 1
        End If
      End If
      If myAPEHSTL1.IsInvnoPaid(TxtVndnr.Text, TxtInvno.Text) Then
          ErrorField(I) = "invno"
          ErrorMsg(I) = "Invoice Number has been paid"
          I = I + 1
        End If
      End If

      If GetVendorName(TxtVndnr.Text) = "" Then
      ErrorField(I) = "vndnr"
      ErrorMsg(I) = "Vendor Number is invalid or suspended"
      I = I + 1
    End If

    If WrkEditDescr And Trim(TxtDsctx.Text) = "" Then
      ErrorField(I) = "dsctx"
      ErrorMsg(I) = "Description is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtPONbr.Text) > 0 Then
      With myPOMAST
        .GetOneRecordP(MyUtils.CnvSng(TxtFscyr.Text), MyUtils.CnvSng(TxtPONbr.Text), 0, 0, 0)
        If .RecordNotFound Then
          ErrorField(I) = "ponbr"
          ErrorMsg(I) = "PO Number is invalid"
          I = I + 1
        Else
          If Trim(._CMPCD) = "C" Then
            ErrorField(I) = "ponbr"
            ErrorMsg(I) = "PO Number is closed"
            I = I + 1
          End If
        End If
      End With
    End If

    If WrkClose Then
      If MyUtils.CnvSng(TxtAmount.Text) = 0 Then
        If MyUtils.CnvSng(TxtAmtnt.Text) <> MyUtils.CnvSng(LblDetailAmt.Text) Then
          ErrorField(I) = "amtnt"
          ErrorMsg(I) = "Invoice Amount is not equal to Detail"
          I = I + 1
        End If
      End If
    End If
  End Sub
  Public Sub SaveDtl()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    If MyUtils.CnvSng(TxtFund.Text) = 0 Then Exit Sub

    WrkRecno = MyUtils.CnvSng(LblRecno.Text)
    If WrkRecno = 0 Then
      WrkRecno = myAPEBCD.AutoGenKey(WrkBatchNo, WrkSeqno)
    End If
    myAPEBCD.GetOneRecordP(WrkBatchNo, WrkSeqno, WrkRecno)
    If Not myAPEBCD.RecordNotFound Then
      MovetoDtl()
      EditChecksDtl(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        If MyUtils.CnvSng(TxtAmount.Text) <> 0 Then
          myAPEBCD.UpdateOneRecordP()
        Else
          myAPEBCD.DeleteOneRecordP()
        End If
      Else
        ShowErrorDtl(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      With myAPEBCD
        ._BCHNO = WrkBatchNo
        ._SEQNO = WrkSeqno
        ._RECNO = WrkRecno
      End With
      MovetoDtl()
      EditChecksDtl(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myAPEBCD.AddOneRecordP()
      Else
        ShowErrorDtl(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    TxtFund.Text = ""
    TxtSFund.Text = ""
    TxtDept.Text = ""
    TxtObj.Text = ""
    TxtFcn.Text = ""
    TxtSfcn.Text = ""
    TxtAmount.Text = ""
    LblRecno.Text = ""
    LblDetailAmt.Text = Format(CalcTotals(), "fixed")
    If MyUtils.CnvSng(TxtAmtnt.Text) = MyUtils.CnvSng(LblDetailAmt.Text) Then
      LblDetailAmt.BackColor = Color.Aqua
    Else
      LblDetailAmt.BackColor = Color.Pink
    End If
    FormatGrid()
    BtnAddDtl.Text = "Add Item"
    BtnRemDtl.Enabled = False
  End Sub
  Private Sub MovetoDtl()
    With myAPEBCD
      ._FDNBR = MyUtils.CnvSng(TxtFund.Text)
      ._SFUND = MyUtils.CnvSng(TxtSFund.Text)
      ._DPNBR = MyUtils.CnvSng(TxtDept.Text)
      ._OBNBR = MyUtils.CnvSng(TxtObj.Text)
      ._FNPGM = MyUtils.CnvSng(TxtFcn.Text)
      ._SUBFN = MyUtils.CnvSng(TxtSfcn.Text)
      ._AMTNT = MyUtils.CnvSng(TxtAmount.Text)
      ._FA = ""
    End With
  End Sub
  Public Sub DeleteDtl()
    Dim WrkRec As Integer
    Dim Answer As Integer
    WrkRec = MyUtils.CnvSng(LblRecno.Text)
    If MyUtils.CnvSng(TxtFund.Text) = 0 Then Exit Sub

    Answer = MsgBox("Remove item " & WrkRec & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Remove")
    If Answer = vbNo Then
      Exit Sub
    End If

    myAPEBCD.GetOneRecordP(WrkBatchNo, WrkSeqno, WrkRec)
    myAPEBCD.DeleteOneRecordP()
    TxtFund.Text = ""
    TxtSFund.Text = ""
    TxtDept.Text = ""
    TxtObj.Text = ""
    TxtFcn.Text = ""
    TxtSfcn.Text = ""
    TxtAmount.Text = ""
    LblRecno.Text = ""
    FormatGrid()
    BtnAddDtl.Text = "Add Item"
    BtnRemDtl.Enabled = False
    LblDetailAmt.Text = Format(CalcTotals(), "fixed")
    If MyUtils.CnvSng(TxtAmtnt.Text) = MyUtils.CnvSng(LblDetailAmt.Text) Then
      LblDetailAmt.BackColor = Color.Aqua
    Else
      LblDetailAmt.BackColor = Color.Pink
    End If
  End Sub
  Private Sub ShowErrorDtl(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFund, "")
    ErrProv.SetError(TxtAmount, "")
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "acct"
          ErrProv.SetError(TxtFund, ErrorMsg(I))
        Case "amount"
          ErrProv.SetError(TxtAmount, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecksDtl(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim WrkBal As Decimal
    Dim WrkDateFrom As Integer
    Dim WrkDateTo As Integer
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtAmount.Text) = 0 Then
      ErrorField(I) = "amount"
      ErrorMsg(I) = "Amount cannot be 0"
      I = I + 1
    End If

    myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFund.Text), MyUtils.CnvSng(TxtSFund.Text), MyUtils.CnvSng(TxtDept.Text),
      MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFcn.Text), MyUtils.CnvSng(TxtSfcn.Text))
    If myGLACCT.RecordNotFound Then
      ErrorField(I) = "acct"
      ErrorMsg(I) = "Acct is invalid"
      I = I + 1
    Else
      If myGLACCT._ACREC = "I" Then
        ErrorField(I) = "acct"
        ErrorMsg(I) = "Inactive Acct"
        I = I + 1
      End If
      If myGLACCT._GLTYP = "H" Then
        ErrorField(I) = "acct"
        ErrorMsg(I) = "Header Acct"
        I = I + 1
      End If
    End If

    LblOverExpend.Visible = False
    CalcFyDates(DtPckInvd8.Value, WrkDateFrom, WrkDateTo)
    WrkBal = GetAcctBal(MyUtils.CnvSng(TxtFund.Text), MyUtils.CnvSng(TxtSFund.Text),
     MyUtils.CnvSng(TxtDept.Text), MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFcn.Text),
     MyUtils.CnvSng(TxtSfcn.Text), WrkDateFrom, WrkDateTo)
    WrkBal = WrkBal - MyUtils.CnvSng(TxtAmount.Text)
    If WrkBal < 0 Then
      LblOverExpend.Visible = True
    End If
  End Sub
  Private Sub TxtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAmount.KeyPress
    Dim Good As Boolean
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, True)
    If Asc(e.KeyChar) = Keys.Return Then
      If LblRecno.Text = "" Then
        LblRecno.Text = myAPEBCD.AutoGenKey(WrkBatchNo, WrkSeqno)
      End If
      Good = SaveData(False, True, "")
      If Good Then
        SaveDtl()
      End If
    End If
  End Sub
  Private Sub LnkGLAcctRC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkGLAcct.LinkClicked
    Dim WrkAcct As String

    WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFund.Text), MyUtils.CnvSng(TxtSFund.Text), MyUtils.CnvSng(TxtDept.Text),
    MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFcn.Text), MyUtils.CnvSng(TxtSfcn.Text))
    MyFrmListGLAcct = New FrmListGLAcct
    MyFrmListGLAcct.MdiParent = Me.ParentForm
    MyFrmListGLAcct.WrkCode = WrkAcct
    MyFrmListGLAcct.Show()
    Me.Hide()
  End Sub
  Private Sub UpdateHeader()
    '  CalcTotals()
    With myAPEBCH
      .GetOneRecordP(WrkBatchNo, WrkSeqno)
      'If Not .RecordNotFound Then
      '  ._TOTCR = WrkCredit
      '  ._TOTDR = WrkDebit
      '  .UpdateOneRecordP()
      'Else
      '  ._BCHNO = WrkBatchNo
      '  ._TRNBR = WrkTran
      '  ._JRNSEQ = WrkRecNo
      '  ._JACT8 = MyUtils.SetDBDate(WrkReceiptDate)
      '  ._JENT8 = MyUtils.SetDBDate(WrkReceiptDate)
      '  ._TOTCR = WrkCredit
      '  ._TOTDR = WrkDebit
      '  .AddOneRecordP()
      'End If
    End With
  End Sub
  Private Function CalcTotals() As Decimal
    Dim Ds As DataSet = New DataSet
    Dim WrkAmount As Decimal
    Dim I As Integer

    WrkAmount = 0
    Ds = myAPEBCDL1.GetViewbySeqno(WrkBatchNo, WrkSeqno, 0)
    For I = 0 To Ds.Tables(0).Rows.Count - 1
      WrkAmount = WrkAmount + Ds.Tables(0).Rows(I).Item("amtnt")
    Next
    Return WrkAmount
  End Function
  Private Sub C1DataGrdList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    If C1DataGrdList.VisibleRows = 0 Then
      Exit Sub
    End If

    If C1DataGrdList.Item(C1DataGrdList.Row, 0) > 0 Then
      TxtFund.Text = C1DataGrdList.Item(C1DataGrdList.Row, 3)
      TxtSFund.Text = C1DataGrdList.Item(C1DataGrdList.Row, 4)
      TxtDept.Text = C1DataGrdList.Item(C1DataGrdList.Row, 5)
      TxtObj.Text = C1DataGrdList.Item(C1DataGrdList.Row, 6)
      TxtFcn.Text = C1DataGrdList.Item(C1DataGrdList.Row, 7)
      TxtSfcn.Text = C1DataGrdList.Item(C1DataGrdList.Row, 8)
      TxtAmount.Text = C1DataGrdList.Item(C1DataGrdList.Row, 9)
      LblRecno.Text = C1DataGrdList.Item(C1DataGrdList.Row, 2)
    End If
    BtnAddDtl.Text = "Update Item"
    BtnRemDtl.Enabled = True
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
      If .RecordNotFound Or Trim(._ACREC) <> "" Then Return String.Empty
      Return ._VENNM
    End With
  End Function
  Public Function GetVendor1099(ByVal Vndnr As String) As String
    myVENDOR.GetOneRecordP(Vndnr)
    With myVENDOR
      If .RecordNotFound Or Trim(._ACREC) <> "" Then Return String.Empty
      Return ._F1099
    End With
  End Function
  Private Sub TxtVndnr_Leave(sender As Object, e As EventArgs) Handles TxtVndnr.Leave
    With myVENDOR
      .GetOneRecordP(TxtVndnr.Text)
      LblVennm.Text = ""
      ChkF1099.Checked = False
      If Not .RecordNotFound Then
        LblVennm.Text = ._VENNM
        If ._F1099 = "Y" Then
          ChkF1099.Checked = True
        End If
      End If
    End With
  End Sub
  Private Sub GetPOMAST()
    Dim ds2 As DataSet = New DataSet
    Dim ds3 As DataSet = New DataSet
    Dim SumAcct(25) As Decimal
    Dim SumAmt(25) As Decimal
    Dim SumLiq(25) As String
    Dim WrkStr As String
    Dim WrkAcct As Decimal
    Dim WrkFdnbr As Integer
    Dim WrkSfund As Integer
    Dim WrkDpnbr As Integer
    Dim WrkObnbr As Integer
    Dim WrkFnpgm As Integer
    Dim WrkSubfn As Integer
    Dim Good As Boolean
    Dim WrkLiq As Boolean
    Dim WrkRecno As Integer
    Dim I As Integer
    Dim J As Integer

    WrkLiq = False
    If C1DataGrdList.VisibleRows > 0 Then
      myAPEBCD.DeleteSeqno(WrkBatchNo, WrkSeqno)
    End If

    With myPOMASTL1
      ds2 = .GetAllPONo(MyUtils.CnvSng(TxtFscyr.Text), MyUtils.CnvSng(TxtPONbr.Text), 0)
    End With
    If ds2.Tables(0).Rows.Count = 0 Then
      Exit Sub
    End If

    ds3 = myPOSUMFL1.GetAllPONo(MyUtils.CnvSng(TxtFscyr.Text), MyUtils.CnvSng(TxtPONbr.Text), 0)
    If ds3.Tables(0).Rows.Count > 0 Then
      For J = 0 To ds3.Tables(0).Rows.Count - 1
        SumAcct(J) = ds3.Tables(0).Rows(J).Item("acct")
        SumAmt(J) = ds3.Tables(0).Rows(J).Item("poopn")
        SumLiq(J) = ds3.Tables(0).Rows(J).Item("poliq")
        If SumAmt(J) > 0 And SumLiq(J) = "N" Then
          WrkLiq = True
          Exit For
        End If
      Next
    End If

    If Not WrkLiq Then
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        If I = 0 Then
          If ds2.Tables(0).Rows(I).Item("cmpcd") = "C" Then
            LblPOOpen.Text = "Closed"
            Exit Sub
          End If
          TxtVndnr.Text = ds2.Tables(0).Rows(I).Item("vndnr")
          LblVennm.Text = ds2.Tables(0).Rows(I).Item("vennm")
          Good = SaveData(False, False, "Y")
          If Not Good Then Exit Sub
          If ds2.Tables(0).Rows(I).Item("amtnt") > 0 Then
            TxtAmtnt.Text = Format(ds2.Tables(0).Rows(I).Item("amtnt"), "fixed")
          End If
          DtpckAppst.Value = MyUtils.GetDBDateMDY(ds2.Tables(0).Rows(I).Item("popst"))
          LblPONet.Text = Format(ds2.Tables(0).Rows(I).Item("amtnt"), "fixed")
          LblPOOpen.Text = Format(ds2.Tables(0).Rows(I).Item("popen"), "fixed")
          'Shipping
          If ds2.Tables(0).Rows(I).Item("shpdl") > 0 Then
            With myAPEBCD
              WrkRecno = WrkRecno + 1
              .GetOneRecordP(WrkBatchNo, WrkSeqno, WrkRecno)
              ._BCHNO = WrkBatchNo
              ._SEQNO = WrkSeqno
              ._RECNO = WrkRecno
              ._FDNBR = ds2.Tables(0).Rows(I).Item("fdnbs")
              ._SFUND = ds2.Tables(0).Rows(I).Item("sfuns")
              ._DPNBR = ds2.Tables(0).Rows(I).Item("dpnbs")
              ._OBNBR = ds2.Tables(0).Rows(I).Item("obnbs")
              ._FNPGM = ds2.Tables(0).Rows(I).Item("fnpgs")
              ._SUBFN = ds2.Tables(0).Rows(I).Item("subfs")
              ._AMTNT = ds2.Tables(0).Rows(I).Item("shpdl")
              ._FA = ""
              .AddOneRecordP()
            End With
          End If
          'Discount
          If ds2.Tables(0).Rows(I).Item("dscdl") > 0 Then
            With myAPEBCD
              WrkRecno = WrkRecno + 1
              .GetOneRecordP(WrkBatchNo, WrkSeqno, WrkRecno)
              ._BCHNO = WrkBatchNo
              ._SEQNO = WrkSeqno
              ._RECNO = WrkRecno
              ._FDNBR = ds2.Tables(0).Rows(I).Item("fdnbd")
              ._SFUND = ds2.Tables(0).Rows(I).Item("sfudd")
              ._DPNBR = ds2.Tables(0).Rows(I).Item("dpnbd")
              ._OBNBR = ds2.Tables(0).Rows(I).Item("obnbd")
              ._FNPGM = ds2.Tables(0).Rows(I).Item("fnpgd")
              ._SUBFN = ds2.Tables(0).Rows(I).Item("subfd")
              ._AMTNT = ds2.Tables(0).Rows(I).Item("dscdl")
              ._FA = ""
              .AddOneRecordP()
            End With
          End If
        Else
          With myAPEBCD
            WrkStr = BuildAcct(ds2.Tables(0).Rows(I).Item("fdnbr"),
         ds2.Tables(0).Rows(I).Item("sfund"), ds2.Tables(0).Rows(I).Item("dpnbr"),
         ds2.Tables(0).Rows(I).Item("obnbr"), ds2.Tables(0).Rows(I).Item("fnpgm"),
         ds2.Tables(0).Rows(I).Item("subfn"))
            WrkAcct = Replace(WrkStr, "-", "")
            For J = 0 To SumAcct.GetUpperBound(0)
              If WrkAcct = SumAcct((J)) Then
                Exit For
              End If
            Next

            If SumAcct.GetUpperBound(0) >= J Then
              If SumAmt(J) > 0 Then
                WrkRecno = WrkRecno + 1
                .GetOneRecordP(WrkBatchNo, WrkSeqno, WrkRecno)
                ._BCHNO = WrkBatchNo
                ._SEQNO = WrkSeqno
                ._RECNO = WrkRecno
                ._FDNBR = ds2.Tables(0).Rows(I).Item("fdnbr")
                ._SFUND = ds2.Tables(0).Rows(I).Item("sfund")
                ._DPNBR = ds2.Tables(0).Rows(I).Item("dpnbr")
                ._OBNBR = ds2.Tables(0).Rows(I).Item("obnbr")
                ._FNPGM = ds2.Tables(0).Rows(I).Item("fnpgm")
                ._SUBFN = ds2.Tables(0).Rows(I).Item("subfn")
                If ds2.Tables(0).Rows(I).Item("exval") <= SumAmt(J) Then
                  ._AMTNT = ds2.Tables(0).Rows(I).Item("exval")
                  SumAmt(J) = SumAmt(J) - ds2.Tables(0).Rows(I).Item("exval")
                Else
                  ._AMTNT = SumAmt(J)
                  SumAmt(J) = 0
                End If
                ._FA = ""
                .AddOneRecordP()
              End If
            End If
          End With
        End If
      Next
    Else
      TxtVndnr.Text = ds2.Tables(0).Rows(0).Item("vndnr")
      LblVennm.Text = ds2.Tables(0).Rows(0).Item("vennm")
      Good = SaveData(False, False, "N")
      If Not Good Then Exit Sub
      TxtAmtnt.Text = Format(SumAmt(J), "fixed")
      DtpckAppst.Value = MyUtils.GetDBDateMDY(ds2.Tables(0).Rows(0).Item("popst"))
      LblPONet.Text = Format(ds2.Tables(0).Rows(0).Item("amtnt"), "fixed")
      LblPOOpen.Text = Format(ds2.Tables(0).Rows(0).Item("popen"), "fixed")
      'Shipping
      If ds2.Tables(0).Rows(0).Item("shpdl") > 0 Then
        With myAPEBCD
          WrkRecno = WrkRecno + 1
          .GetOneRecordP(WrkBatchNo, WrkSeqno, WrkRecno)
          ._BCHNO = WrkBatchNo
          ._SEQNO = WrkSeqno
          ._RECNO = WrkRecno
          ._FDNBR = ds2.Tables(0).Rows(0).Item("fdnbs")
          ._SFUND = ds2.Tables(0).Rows(0).Item("sfuns")
          ._DPNBR = ds2.Tables(0).Rows(0).Item("dpnbs")
          ._OBNBR = ds2.Tables(0).Rows(0).Item("obnbs")
          ._FNPGM = ds2.Tables(0).Rows(0).Item("fnpgs")
          ._SUBFN = ds2.Tables(0).Rows(0).Item("subfs")
          ._AMTNT = ds2.Tables(0).Rows(0).Item("shpdl")
          ._FA = ""
          .AddOneRecordP()
        End With
      End If
      'Discount
      If ds2.Tables(0).Rows(0).Item("dscdl") > 0 Then
        With myAPEBCD
          WrkRecno = WrkRecno + 1
          .GetOneRecordP(WrkBatchNo, WrkSeqno, WrkRecno)
          ._BCHNO = WrkBatchNo
          ._SEQNO = WrkSeqno
          ._RECNO = WrkRecno
          ._FDNBR = ds2.Tables(0).Rows(0).Item("fdnbd")
          ._SFUND = ds2.Tables(0).Rows(0).Item("sfudd")
          ._DPNBR = ds2.Tables(0).Rows(0).Item("dpnbd")
          ._OBNBR = ds2.Tables(0).Rows(0).Item("obnbd")
          ._FNPGM = ds2.Tables(0).Rows(0).Item("fnpgd")
          ._SUBFN = ds2.Tables(0).Rows(0).Item("subfd")
          ._AMTNT = ds2.Tables(0).Rows(0).Item("dscdl")
          ._FA = ""
          .AddOneRecordP()
        End With
      End If
      WrkRecno = WrkRecno + 1
      BreakAcct(SumAcct(J), WrkFdnbr, WrkSfund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
      With myAPEBCD
        .GetOneRecordP(WrkBatchNo, WrkSeqno, WrkRecno)
        ._BCHNO = WrkBatchNo
        ._SEQNO = WrkSeqno
        ._RECNO = WrkRecno
        ._FDNBR = WrkFdnbr
        ._SFUND = WrkSfund
        ._DPNBR = WrkDpnbr
        ._OBNBR = WrkObnbr
        ._FNPGM = WrkFnpgm
        ._SUBFN = WrkSubfn
        ._AMTNT = SumAmt(J)
        ._FA = ""
        .AddOneRecordP()
      End With
    End If

  End Sub
  Private Sub TxtFscyr_Leave(sender As Object, e As EventArgs) Handles TxtFscyr.Leave
    GetPOMAST()
    LblDetailAmt.Text = Format(CalcTotals(), "fixed")
    If MyUtils.CnvSng(TxtAmtnt.Text) = MyUtils.CnvSng(LblDetailAmt.Text) Then
      LblDetailAmt.BackColor = Color.Aqua
    Else
      LblDetailAmt.BackColor = Color.Pink
    End If
    FormatGrid()
  End Sub
  Private Sub BtnRemDtl_Click(sender As Object, e As EventArgs) Handles BtnRemDtl.Click
    DeleteDtl()
  End Sub
  Private Sub BtnAddDtl_Click(sender As Object, e As EventArgs) Handles BtnAddDtl.Click
    SaveDtl()
    SaveData(False, True, "")
  End Sub

  Private Sub TxtFscyr_TextChanged(sender As Object, e As EventArgs) Handles TxtFscyr.TextChanged

  End Sub

  Private Sub TxtVndnr_TextChanged(sender As Object, e As EventArgs) Handles TxtVndnr.TextChanged

  End Sub
End Class
