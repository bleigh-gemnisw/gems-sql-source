Public Class FrmAR101C

  Inherits System.Windows.Forms.Form
  Dim myBCHHDR As BCHHDR.myData
  Dim myCSHBCH As CSHBCH.MyData
  Dim myCSHBCHL1 As CSHBCHL1.MyData
  Dim myGLACCT As GLACCT.MyData
  Dim ds As DataSet = New DataSet
  Friend WithEvents LblAmount As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtDeptd As TextBox
  Friend WithEvents TxtObjd As TextBox
  Friend WithEvents Label1 As Label
  Friend WithEvents LnkGLAcctd As LinkLabel
  Friend WithEvents TxtSfcnd As TextBox
  Friend WithEvents TxtFcnd As TextBox
  Friend WithEvents TxtSFundd As TextBox
  Friend WithEvents TxtFundd As TextBox
  Friend WithEvents LblEnter As Label
  Friend WithEvents DtPckTran As DateTimePicker
  Friend WithEvents LblRecno As Label
  Friend WithEvents Label10 As Label
  Friend WithEvents LnkGLAcct As LinkLabel
  Friend WithEvents TxtSfcn As TextBox
  Friend WithEvents TxtFcn As TextBox
  Friend WithEvents TxtRef As TextBox
  Friend WithEvents TxtObj As TextBox
  Friend WithEvents Label5 As Label
  Friend WithEvents TxtDept As TextBox
  Friend WithEvents TxtSFund As TextBox
  Friend WithEvents TxtFund As TextBox
  Friend WithEvents TxtDescr As TextBox
  Friend WithEvents Label7 As Label
  Friend WithEvents TxtAmount As TextBox
  Friend WithEvents Label8 As Label
  Friend WithEvents BtnRemDtl As Button
  Friend WithEvents BtnAddDtl As Button
  Friend WithEvents ErrProv As ErrorProvider
  Friend WrkBatchNo As Integer

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
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAR101C))
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LblAmount = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtDeptd = New System.Windows.Forms.TextBox()
    Me.TxtObjd = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LnkGLAcctd = New System.Windows.Forms.LinkLabel()
    Me.TxtSfcnd = New System.Windows.Forms.TextBox()
    Me.TxtFcnd = New System.Windows.Forms.TextBox()
    Me.TxtSFundd = New System.Windows.Forms.TextBox()
    Me.TxtFundd = New System.Windows.Forms.TextBox()
    Me.LblEnter = New System.Windows.Forms.Label()
    Me.DtPckTran = New System.Windows.Forms.DateTimePicker()
    Me.LblRecno = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.LnkGLAcct = New System.Windows.Forms.LinkLabel()
    Me.TxtSfcn = New System.Windows.Forms.TextBox()
    Me.TxtFcn = New System.Windows.Forms.TextBox()
    Me.TxtRef = New System.Windows.Forms.TextBox()
    Me.TxtObj = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtDept = New System.Windows.Forms.TextBox()
    Me.TxtSFund = New System.Windows.Forms.TextBox()
    Me.TxtFund = New System.Windows.Forms.TextBox()
    Me.TxtDescr = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtAmount = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.BtnRemDtl = New System.Windows.Forms.Button()
    Me.BtnAddDtl = New System.Windows.Forms.Button()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColMove = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AllowUpdate = False
    Me.C1DataGrdList.AlternatingRows = True
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(12, 28)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    Me.C1DataGrdList.RowHeight = 16
    Me.C1DataGrdList.Size = New System.Drawing.Size(557, 190)
    Me.C1DataGrdList.TabIndex = 8
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    '
    'LblAmount
    '
    Me.LblAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAmount.Location = New System.Drawing.Point(465, 7)
    Me.LblAmount.Name = "LblAmount"
    Me.LblAmount.Size = New System.Drawing.Size(79, 18)
    Me.LblAmount.TabIndex = 223
    Me.LblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(428, 9)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(31, 13)
    Me.Label3.TabIndex = 224
    Me.Label3.Text = "Total"
    '
    'TxtDeptd
    '
    Me.TxtDeptd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDeptd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDeptd.Location = New System.Drawing.Point(202, 352)
    Me.TxtDeptd.MaxLength = 4
    Me.TxtDeptd.Name = "TxtDeptd"
    Me.TxtDeptd.Size = New System.Drawing.Size(45, 22)
    Me.TxtDeptd.TabIndex = 480
    '
    'TxtObjd
    '
    Me.TxtObjd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObjd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObjd.Location = New System.Drawing.Point(253, 352)
    Me.TxtObjd.MaxLength = 3
    Me.TxtObjd.Name = "TxtObjd"
    Me.TxtObjd.Size = New System.Drawing.Size(32, 22)
    Me.TxtObjd.TabIndex = 481
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(199, 336)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(70, 13)
    Me.Label1.TabIndex = 490
    Me.Label1.Text = "--- Optional ---"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LnkGLAcctd
    '
    Me.LnkGLAcctd.AutoSize = True
    Me.LnkGLAcctd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcctd.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcctd.Location = New System.Drawing.Point(63, 356)
    Me.LnkGLAcctd.Name = "LnkGLAcctd"
    Me.LnkGLAcctd.Size = New System.Drawing.Size(57, 13)
    Me.LnkGLAcctd.TabIndex = 477
    Me.LnkGLAcctd.TabStop = True
    Me.LnkGLAcctd.Text = "Debit Acct"
    '
    'TxtSfcnd
    '
    Me.TxtSfcnd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfcnd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfcnd.Location = New System.Drawing.Point(340, 352)
    Me.TxtSfcnd.MaxLength = 4
    Me.TxtSfcnd.Name = "TxtSfcnd"
    Me.TxtSfcnd.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfcnd.TabIndex = 483
    '
    'TxtFcnd
    '
    Me.TxtFcnd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFcnd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFcnd.Location = New System.Drawing.Point(289, 352)
    Me.TxtFcnd.MaxLength = 4
    Me.TxtFcnd.Name = "TxtFcnd"
    Me.TxtFcnd.Size = New System.Drawing.Size(45, 22)
    Me.TxtFcnd.TabIndex = 482
    '
    'TxtSFundd
    '
    Me.TxtSFundd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSFundd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSFundd.Location = New System.Drawing.Point(164, 352)
    Me.TxtSFundd.MaxLength = 3
    Me.TxtSFundd.Name = "TxtSFundd"
    Me.TxtSFundd.Size = New System.Drawing.Size(32, 22)
    Me.TxtSFundd.TabIndex = 479
    '
    'TxtFundd
    '
    Me.TxtFundd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFundd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFundd.Location = New System.Drawing.Point(126, 352)
    Me.TxtFundd.MaxLength = 3
    Me.TxtFundd.Name = "TxtFundd"
    Me.TxtFundd.Size = New System.Drawing.Size(32, 22)
    Me.TxtFundd.TabIndex = 478
    '
    'LblEnter
    '
    Me.LblEnter.AutoSize = True
    Me.LblEnter.Location = New System.Drawing.Point(87, 231)
    Me.LblEnter.Name = "LblEnter"
    Me.LblEnter.Size = New System.Drawing.Size(30, 13)
    Me.LblEnter.TabIndex = 489
    Me.LblEnter.Text = "Date"
    Me.LblEnter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'DtPckTran
    '
    Me.DtPckTran.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTran.Location = New System.Drawing.Point(124, 225)
    Me.DtPckTran.Name = "DtPckTran"
    Me.DtPckTran.Size = New System.Drawing.Size(84, 20)
    Me.DtPckTran.TabIndex = 466
    '
    'LblRecno
    '
    Me.LblRecno.AutoSize = True
    Me.LblRecno.Location = New System.Drawing.Point(273, 231)
    Me.LblRecno.Name = "LblRecno"
    Me.LblRecno.Size = New System.Drawing.Size(51, 13)
    Me.LblRecno.TabIndex = 488
    Me.LblRecno.Text = "<Recno>"
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(230, 231)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(37, 13)
    Me.Label10.TabIndex = 487
    Me.Label10.Text = "Rec #"
    '
    'LnkGLAcct
    '
    Me.LnkGLAcct.AutoSize = True
    Me.LnkGLAcct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcct.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcct.Location = New System.Drawing.Point(87, 255)
    Me.LnkGLAcct.Name = "LnkGLAcct"
    Me.LnkGLAcct.Size = New System.Drawing.Size(29, 13)
    Me.LnkGLAcct.TabIndex = 467
    Me.LnkGLAcct.TabStop = True
    Me.LnkGLAcct.Text = "Acct"
    '
    'TxtSfcn
    '
    Me.TxtSfcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfcn.Location = New System.Drawing.Point(338, 251)
    Me.TxtSfcn.MaxLength = 4
    Me.TxtSfcn.Name = "TxtSfcn"
    Me.TxtSfcn.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfcn.TabIndex = 473
    '
    'TxtFcn
    '
    Me.TxtFcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFcn.Location = New System.Drawing.Point(287, 251)
    Me.TxtFcn.MaxLength = 4
    Me.TxtFcn.Name = "TxtFcn"
    Me.TxtFcn.Size = New System.Drawing.Size(45, 22)
    Me.TxtFcn.TabIndex = 472
    '
    'TxtRef
    '
    Me.TxtRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRef.Location = New System.Drawing.Point(287, 309)
    Me.TxtRef.MaxLength = 7
    Me.TxtRef.Name = "TxtRef"
    Me.TxtRef.Size = New System.Drawing.Size(56, 20)
    Me.TxtRef.TabIndex = 476
    '
    'TxtObj
    '
    Me.TxtObj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObj.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObj.Location = New System.Drawing.Point(251, 251)
    Me.TxtObj.MaxLength = 3
    Me.TxtObj.Name = "TxtObj"
    Me.TxtObj.Size = New System.Drawing.Size(32, 22)
    Me.TxtObj.TabIndex = 471
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(220, 312)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(57, 13)
    Me.Label5.TabIndex = 486
    Me.Label5.Text = "Reference"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtDept
    '
    Me.TxtDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDept.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDept.Location = New System.Drawing.Point(200, 251)
    Me.TxtDept.MaxLength = 4
    Me.TxtDept.Name = "TxtDept"
    Me.TxtDept.Size = New System.Drawing.Size(45, 22)
    Me.TxtDept.TabIndex = 470
    '
    'TxtSFund
    '
    Me.TxtSFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSFund.Location = New System.Drawing.Point(162, 251)
    Me.TxtSFund.MaxLength = 3
    Me.TxtSFund.Name = "TxtSFund"
    Me.TxtSFund.Size = New System.Drawing.Size(32, 22)
    Me.TxtSFund.TabIndex = 469
    '
    'TxtFund
    '
    Me.TxtFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFund.Location = New System.Drawing.Point(124, 251)
    Me.TxtFund.MaxLength = 3
    Me.TxtFund.Name = "TxtFund"
    Me.TxtFund.Size = New System.Drawing.Size(32, 22)
    Me.TxtFund.TabIndex = 468
    '
    'TxtDescr
    '
    Me.TxtDescr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDescr.Location = New System.Drawing.Point(124, 282)
    Me.TxtDescr.MaxLength = 30
    Me.TxtDescr.Name = "TxtDescr"
    Me.TxtDescr.Size = New System.Drawing.Size(259, 20)
    Me.TxtDescr.TabIndex = 474
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(57, 283)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(60, 13)
    Me.Label7.TabIndex = 485
    Me.Label7.Text = "Description"
    Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtAmount
    '
    Me.TxtAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAmount.Location = New System.Drawing.Point(124, 309)
    Me.TxtAmount.MaxLength = 10
    Me.TxtAmount.Name = "TxtAmount"
    Me.TxtAmount.Size = New System.Drawing.Size(80, 20)
    Me.TxtAmount.TabIndex = 475
    Me.TxtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(75, 312)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(43, 13)
    Me.Label8.TabIndex = 484
    Me.Label8.Text = "Amount"
    Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'BtnRemDtl
    '
    Me.BtnRemDtl.Location = New System.Drawing.Point(448, 309)
    Me.BtnRemDtl.Name = "BtnRemDtl"
    Me.BtnRemDtl.Size = New System.Drawing.Size(81, 22)
    Me.BtnRemDtl.TabIndex = 492
    Me.BtnRemDtl.TabStop = False
    Me.BtnRemDtl.Text = "Remove Item"
    Me.BtnRemDtl.UseVisualStyleBackColor = True
    '
    'BtnAddDtl
    '
    Me.BtnAddDtl.Location = New System.Drawing.Point(361, 309)
    Me.BtnAddDtl.Name = "BtnAddDtl"
    Me.BtnAddDtl.Size = New System.Drawing.Size(81, 22)
    Me.BtnAddDtl.TabIndex = 491
    Me.BtnAddDtl.TabStop = False
    Me.BtnAddDtl.Text = "Add Item"
    Me.BtnAddDtl.UseVisualStyleBackColor = True
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'FrmAR101C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(581, 385)
    Me.Controls.Add(Me.BtnRemDtl)
    Me.Controls.Add(Me.BtnAddDtl)
    Me.Controls.Add(Me.TxtDeptd)
    Me.Controls.Add(Me.TxtObjd)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LnkGLAcctd)
    Me.Controls.Add(Me.TxtSfcnd)
    Me.Controls.Add(Me.TxtFcnd)
    Me.Controls.Add(Me.TxtSFundd)
    Me.Controls.Add(Me.TxtFundd)
    Me.Controls.Add(Me.LblEnter)
    Me.Controls.Add(Me.DtPckTran)
    Me.Controls.Add(Me.LblRecno)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.LnkGLAcct)
    Me.Controls.Add(Me.TxtSfcn)
    Me.Controls.Add(Me.TxtFcn)
    Me.Controls.Add(Me.TxtRef)
    Me.Controls.Add(Me.TxtObj)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtDept)
    Me.Controls.Add(Me.TxtSFund)
    Me.Controls.Add(Me.TxtFund)
    Me.Controls.Add(Me.TxtDescr)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtAmount)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.LblAmount)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmAR101C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Batch"
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmAR101B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkReceiptDate As Date
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myCSHBCH = New CSHBCH.MyData()
    myCSHBCH.MyDBConn = myDBConnect
    myCSHBCHL1 = New CSHBCHL1.MyData()
    myCSHBCHL1.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    With MyFrmAR101
      .TBarCreate.Enabled = False
      .TBarDelete.Enabled = False
      .TBarDelete.Text = "Delete"
      .TBarPrtEdits.Enabled = False
      .TBarPost.Enabled = False
    End With

    LblRecno.Text = ""
    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      WrkReceiptDate = MyUtils.GetDBDate(._PSDT)
      DtPckTran.Value = MyUtils.GetDBDate(myBCHHDR._PSDT)
    End With
    Me.Text = Me.Text & " " & WrkBatchNo & " - " & WrkReceiptDate
    Call FormatGrid()
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    FormatGrid()
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()
    With C1DataGrdList
      .Rebind(True)
      .Columns(0).Caption = "Rec #"
      .Splits(0).DisplayColumns(0).Width = 30
      .Columns(1).Caption = "Receipt Date"
      .Columns(1).NumberFormat = "##/##/####"
      .Splits(0).DisplayColumns(1).Width = 60
      .Columns(2).Caption = "Description"
      .Splits(0).DisplayColumns(2).Width = 200
      .Columns(3).Caption = "Account"
      .Splits(0).DisplayColumns(3).Width = 150
      .Columns(4).Caption = "Amount"
      .Columns(4).NumberFormat = "Fixed"
      .Splits(0).DisplayColumns(4).Width = 70
    End With
  End Sub
  Public Sub ShowGrid()
    ds = myCSHBCHL1.GetViewbyBatch(WrkBatchNo, 0)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()
    LblAmount.Text = Format(myCSHBCHL1.GetBatchTot(WrkBatchNo), "Fixed")
  End Sub
  Private Sub FrmAR101C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmAR101.SbpScreen.Text = "AR101C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub C1DataGrdList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    If C1DataGrdList.VisibleRows = 0 Then Exit Sub

    LblRecno.Text = C1DataGrdList.Item(C1DataGrdList.Row, 0)
    myCSHBCH.GetOneRecordP(WrkBatchNo, MyUtils.CnvSng(LblRecno.Text))
    With myCSHBCH
      TxtFund.Text = ._FDNBR
      TxtSFund.Text = ._SFUND
      TxtDept.Text = ._DPNBR
      TxtObj.Text = ._OBNBR
      TxtFcn.Text = ._FNPGM
      TxtSfcn.Text = ._SUBFN
      TxtDescr.Text = Trim(._DSCTX)
      TxtAmount.Text = ._AMTCS
      DtPckTran.Value = MyUtils.GetDBDate(._TRNDT)
      If ._REFNO > 0 Then
        TxtRef.Text = ._REFNO
      Else
        TxtRef.Text = ""
      End If
      If ._FDNBD > 0 Then
        TxtFundd.Text = ._FDNBD
        TxtSFundd.Text = ._SFUDD
        TxtDeptd.Text = ._DPNBD
        TxtObjd.Text = ._OBNBD
        TxtFcnd.Text = ._FNPGD
        TxtSfcnd.Text = ._SUBFD
      Else
        TxtFundd.Text = ""
        TxtSFundd.Text = ""
        TxtDeptd.Text = ""
        TxtObjd.Text = ""
        TxtFcnd.Text = ""
        TxtSfcnd.Text = ""
      End If
    End With
    BtnAddDtl.Text = "Update Item"
    BtnRemDtl.Enabled = True
  End Sub
  Private Sub FrmAR101C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    Dim WrkCount As Integer
    WrkCount = myCSHBCHL1.GetBatchCount(WrkBatchNo)
    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      ._LSTUS = MyUserID
      ._STATS = "S"
      ._NBRRC = WrkCount
      .UpdateOneRecordP()
    End With
    With MyFrmAR101
      .TBarCreate.Enabled = True
      .TBarDelete.Text = "Delete Batch"
      .TBarDelete.Enabled = True
      .TBarPrtEdits.Enabled = True
      .TBarPost.Enabled = True
    End With
    MyFrmAR101B.FormatGrid()
    MyFrmAR101B.Show()

  End Sub
  Private Sub TxtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAmount.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtRef_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtRef.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub LnkGLAcct_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkGLAcct.LinkClicked
    Dim WrkAcct As String

    WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFund.Text), MyUtils.CnvSng(TxtSFund.Text), MyUtils.CnvSng(TxtDept.Text),
    MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFcn.Text), MyUtils.CnvSng(TxtSfcn.Text))
    MyFrmListGLAcct = New FrmListGLAcct
    MyFrmListGLAcct.MdiParent = Me.ParentForm
    MyFrmListGLAcct.WrkField = "Credit"
    MyFrmListGLAcct.WrkCode = WrkAcct
    MyFrmListGLAcct.Show()
    Me.Hide()
  End Sub
  Private Sub LnkGLAcctd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkGLAcctd.LinkClicked
    Dim WrkAcct As String

    WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFundd.Text), MyUtils.CnvSng(TxtSFundd.Text), MyUtils.CnvSng(TxtDeptd.Text),
    MyUtils.CnvSng(TxtObjd.Text), MyUtils.CnvSng(TxtFcnd.Text), MyUtils.CnvSng(TxtSfcnd.Text))
    MyFrmListGLAcct = New FrmListGLAcct
    MyFrmListGLAcct.MdiParent = Me.ParentForm
    MyFrmListGLAcct.WrkField = "Debit"
    MyFrmListGLAcct.WrkCode = WrkAcct
    MyFrmListGLAcct.Show()
    Me.Hide()
  End Sub

  Private Sub BtnAddDtl_Click(sender As Object, e As EventArgs) Handles BtnAddDtl.Click
    SaveData()
  End Sub
  Public Sub SaveData()
    Dim WrkRecNo As Integer
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    WrkRecNo = MyUtils.CnvSng(LblRecno.Text)
    If WrkRecNo = 0 Then
      WrkRecNo = myCSHBCH.AutoGenKey(WrkBatchNo)
    End If
    myCSHBCH.GetOneRecordP(WrkBatchNo, WrkRecNo)
    If Not myCSHBCH.RecordNotFound Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myCSHBCH.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      With myCSHBCH
        ._BCHNO = WrkBatchNo
        ._RECNO = WrkRecNo
      End With
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myCSHBCH.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    LblRecno.Text = ""
    TxtAmount.Text = ""
    TxtRef.Text = ""
    BtnAddDtl.Text = "Add Item"
    BtnRemDtl.Enabled = False
    FormatGrid()
  End Sub
  Private Sub MovetoFile()
    With myCSHBCH
      ._FDNBR = MyUtils.CnvSng(TxtFund.Text)
      ._SFUND = MyUtils.CnvSng(TxtSFund.Text)
      ._DPNBR = MyUtils.CnvSng(TxtDept.Text)
      ._OBNBR = MyUtils.CnvSng(TxtObj.Text)
      ._FNPGM = MyUtils.CnvSng(TxtFcn.Text)
      ._SUBFN = MyUtils.CnvSng(TxtSfcn.Text)
      ._DSCTX = TxtDescr.Text
      ._AMTCS = MyUtils.CnvSng(TxtAmount.Text)
      ._ARPST = 0
      ._TRNDT = MyUtils.SetDBDate(DtPckTran.Value)
      ._REFNO = MyUtils.CnvSng(TxtRef.Text)
      ._FDNBD = MyUtils.CnvSng(TxtFundd.Text)
      ._SFUDD = MyUtils.CnvSng(TxtSFundd.Text)
      ._DPNBD = MyUtils.CnvSng(TxtDeptd.Text)
      ._OBNBD = MyUtils.CnvSng(TxtObjd.Text)
      ._FNPGD = MyUtils.CnvSng(TxtFcnd.Text)
      ._SUBFD = MyUtils.CnvSng(TxtSfcnd.Text)
    End With
  End Sub

  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "acct"
          ErrProv.SetError(TxtFund, ErrorMsg(I))
        Case "descr"
          ErrProv.SetError(TxtDescr, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.Clear()

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If InStr(TxtDescr.Text, "'") > 0 Then
      ErrorField(I) = "descr"
      ErrorMsg(I) = "Single Quote is not allowed"
      I = I + 1
    End If

    myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFund.Text), MyUtils.CnvSng(TxtSFund.Text), MyUtils.CnvSng(TxtDept.Text),
      MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFcn.Text), MyUtils.CnvSng(TxtSfcn.Text))
    If myGLACCT.RecordNotFound Then
      ErrorField(I) = "acct"
      ErrorMsg(I) = "Acct is invalid"
      I = I + 1
    End If
  End Sub
  Public Sub DeleteData()
    Dim WrkRecno As Integer
    Dim Answer As Integer
    WrkRecno = MyUtils.CnvSng(LblRecno.Text)
    If MyUtils.CnvSng(TxtFund.Text) = 0 Then Exit Sub

    Answer = MsgBox("Remove item " & WrkRecno & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Remove")
    If Answer = vbNo Then
      Exit Sub
    End If

    myCSHBCH.GetOneRecordP(WrkBatchNo, WrkRecNo)
    myCSHBCH.DeleteOneRecordP()
    LblRecno.Text = ""
    TxtFund.Text = ""
    TxtSFund.Text = ""
    TxtDept.Text = ""
    TxtObj.Text = ""
    TxtFcn.Text = ""
    TxtSfcn.Text = ""
    TxtAmount.Text = ""
    TxtDescr.Text = ""
    TxtRef.Text = ""
    TxtFundd.Text = ""
    TxtSFundd.Text = ""
    TxtDeptd.Text = ""
    TxtObjd.Text = ""
    TxtFcnd.Text = ""
    TxtSfcnd.Text = ""
    FormatGrid()
    BtnAddDtl.Text = "Add Item"
    BtnRemDtl.Enabled = False
  End Sub

  Private Sub BtnRemDtl_Click(sender As Object, e As EventArgs) Handles BtnRemDtl.Click
    DeleteData()
  End Sub
End Class
