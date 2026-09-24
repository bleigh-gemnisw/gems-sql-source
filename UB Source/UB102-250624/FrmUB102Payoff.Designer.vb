<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUB102Payoff
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUB102Payoff))
    Me.LblAddr1 = New System.Windows.Forms.Label()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.C1DataGrdPrev = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblAssmntAdj = New System.Windows.Forms.Label()
    Me.Label57 = New System.Windows.Forms.Label()
    Me.LblOrigAssmnt = New System.Windows.Forms.Label()
    Me.Label65 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.LblDelqFee = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.LblDelqBond = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.LblLiens = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.LblDelqInt = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.LblDelqBal = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.LblPayments = New System.Windows.Forms.Label()
    Me.Label58 = New System.Windows.Forms.Label()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.LblCaveat = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.LblBond = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.LblDeferAmt = New System.Windows.Forms.Label()
    Me.Label54 = New System.Windows.Forms.Label()
    Me.LblAssmntLeft = New System.Windows.Forms.Label()
    Me.Label64 = New System.Windows.Forms.Label()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.LnkPayoff = New System.Windows.Forms.LinkLabel()
    Me.LblAmountDue = New System.Windows.Forms.Label()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.DtPckInterest = New System.Windows.Forms.DateTimePicker()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.BtnRecalc = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.LblAddr2 = New System.Windows.Forms.Label()
    Me.LblAddr3 = New System.Windows.Forms.Label()
    Me.LblAddr4 = New System.Windows.Forms.Label()
    Me.LblAddr5 = New System.Windows.Forms.Label()
    Me.LblLoc = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    CType(Me.C1DataGrdPrev, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.SuspendLayout()
    '
    'LblAddr1
    '
    Me.LblAddr1.Location = New System.Drawing.Point(130, 9)
    Me.LblAddr1.Name = "LblAddr1"
    Me.LblAddr1.Size = New System.Drawing.Size(268, 16)
    Me.LblAddr1.TabIndex = 324
    Me.LblAddr1.Text = "<address 1>"
    Me.LblAddr1.UseMnemonic = False
    '
    'LblListNo
    '
    Me.LblListNo.Location = New System.Drawing.Point(76, 9)
    Me.LblListNo.Name = "LblListNo"
    Me.LblListNo.Size = New System.Drawing.Size(48, 16)
    Me.LblListNo.TabIndex = 323
    Me.LblListNo.Text = "<listno>"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(56, 16)
    Me.Label1.TabIndex = 322
    Me.Label1.Text = "Account #"
    '
    'C1DataGrdPrev
    '
    Me.C1DataGrdPrev.AllowColMove = False
    Me.C1DataGrdPrev.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdPrev.AllowUpdate = False
    Me.C1DataGrdPrev.AlternatingRows = True
    Me.C1DataGrdPrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdPrev.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdPrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.C1DataGrdPrev.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdPrev.Images.Add(CType(resources.GetObject("C1DataGrdPrev.Images"), System.Drawing.Image))
    Me.C1DataGrdPrev.Location = New System.Drawing.Point(12, 150)
    Me.C1DataGrdPrev.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdPrev.Name = "C1DataGrdPrev"
    Me.C1DataGrdPrev.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdPrev.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdPrev.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdPrev.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdPrev.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdPrev.PropBag = resources.GetString("C1DataGrdPrev.PropBag")
    Me.C1DataGrdPrev.Size = New System.Drawing.Size(517, 194)
    Me.C1DataGrdPrev.TabIndex = 338
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LblAssmntAdj)
    Me.GroupBox1.Controls.Add(Me.Label57)
    Me.GroupBox1.Controls.Add(Me.LblOrigAssmnt)
    Me.GroupBox1.Controls.Add(Me.Label65)
    Me.GroupBox1.Location = New System.Drawing.Point(535, 12)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(200, 59)
    Me.GroupBox1.TabIndex = 339
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Assessment "
    '
    'LblAssmntAdj
    '
    Me.LblAssmntAdj.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAssmntAdj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAssmntAdj.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAssmntAdj.Location = New System.Drawing.Point(100, 32)
    Me.LblAssmntAdj.Name = "LblAssmntAdj"
    Me.LblAssmntAdj.Size = New System.Drawing.Size(88, 16)
    Me.LblAssmntAdj.TabIndex = 340
    Me.LblAssmntAdj.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label57
    '
    Me.Label57.Location = New System.Drawing.Point(6, 32)
    Me.Label57.Name = "Label57"
    Me.Label57.Size = New System.Drawing.Size(96, 16)
    Me.Label57.TabIndex = 339
    Me.Label57.Text = "Asmnt Adjustment"
    '
    'LblOrigAssmnt
    '
    Me.LblOrigAssmnt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOrigAssmnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOrigAssmnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOrigAssmnt.Location = New System.Drawing.Point(100, 16)
    Me.LblOrigAssmnt.Name = "LblOrigAssmnt"
    Me.LblOrigAssmnt.Size = New System.Drawing.Size(88, 16)
    Me.LblOrigAssmnt.TabIndex = 338
    Me.LblOrigAssmnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label65
    '
    Me.Label65.BackColor = System.Drawing.SystemColors.Control
    Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label65.Location = New System.Drawing.Point(6, 16)
    Me.Label65.Name = "Label65"
    Me.Label65.Size = New System.Drawing.Size(88, 16)
    Me.Label65.TabIndex = 337
    Me.Label65.Text = "Orig Asmnt Amt"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.LblDelqFee)
    Me.GroupBox2.Controls.Add(Me.Label7)
    Me.GroupBox2.Controls.Add(Me.LblDelqBond)
    Me.GroupBox2.Controls.Add(Me.Label16)
    Me.GroupBox2.Controls.Add(Me.LblLiens)
    Me.GroupBox2.Controls.Add(Me.Label10)
    Me.GroupBox2.Controls.Add(Me.LblDelqInt)
    Me.GroupBox2.Controls.Add(Me.Label8)
    Me.GroupBox2.Controls.Add(Me.LblDelqBal)
    Me.GroupBox2.Controls.Add(Me.Label6)
    Me.GroupBox2.Controls.Add(Me.LblPayments)
    Me.GroupBox2.Controls.Add(Me.Label58)
    Me.GroupBox2.Location = New System.Drawing.Point(535, 77)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(199, 121)
    Me.GroupBox2.TabIndex = 340
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Payments/Balances"
    '
    'LblDelqFee
    '
    Me.LblDelqFee.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblDelqFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblDelqFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDelqFee.Location = New System.Drawing.Point(102, 67)
    Me.LblDelqFee.Name = "LblDelqFee"
    Me.LblDelqFee.Size = New System.Drawing.Size(88, 16)
    Me.LblDelqFee.TabIndex = 349
    Me.LblDelqFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(8, 69)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(88, 16)
    Me.Label7.TabIndex = 348
    Me.Label7.Text = "Fee"
    '
    'LblDelqBond
    '
    Me.LblDelqBond.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblDelqBond.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblDelqBond.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDelqBond.Location = New System.Drawing.Point(102, 83)
    Me.LblDelqBond.Name = "LblDelqBond"
    Me.LblDelqBond.Size = New System.Drawing.Size(88, 16)
    Me.LblDelqBond.TabIndex = 347
    Me.LblDelqBond.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label16
    '
    Me.Label16.Location = New System.Drawing.Point(8, 85)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(88, 14)
    Me.Label16.TabIndex = 346
    Me.Label16.Text = "Bond Int Due"
    '
    'LblLiens
    '
    Me.LblLiens.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLiens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblLiens.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLiens.Location = New System.Drawing.Point(102, 99)
    Me.LblLiens.Name = "LblLiens"
    Me.LblLiens.Size = New System.Drawing.Size(88, 16)
    Me.LblLiens.TabIndex = 345
    Me.LblLiens.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(8, 102)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(88, 16)
    Me.Label10.TabIndex = 344
    Me.Label10.Text = "Liens"
    '
    'LblDelqInt
    '
    Me.LblDelqInt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblDelqInt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblDelqInt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDelqInt.Location = New System.Drawing.Point(102, 51)
    Me.LblDelqInt.Name = "LblDelqInt"
    Me.LblDelqInt.Size = New System.Drawing.Size(88, 16)
    Me.LblDelqInt.TabIndex = 343
    Me.LblDelqInt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(8, 53)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(88, 18)
    Me.Label8.TabIndex = 342
    Me.Label8.Text = "Delq Interest"
    '
    'LblDelqBal
    '
    Me.LblDelqBal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblDelqBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblDelqBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDelqBal.Location = New System.Drawing.Point(102, 35)
    Me.LblDelqBal.Name = "LblDelqBal"
    Me.LblDelqBal.Size = New System.Drawing.Size(88, 16)
    Me.LblDelqBal.TabIndex = 341
    Me.LblDelqBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(8, 35)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(88, 14)
    Me.Label6.TabIndex = 340
    Me.Label6.Text = "Billed Balance"
    '
    'LblPayments
    '
    Me.LblPayments.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPayments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPayments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPayments.Location = New System.Drawing.Point(102, 19)
    Me.LblPayments.Name = "LblPayments"
    Me.LblPayments.Size = New System.Drawing.Size(88, 16)
    Me.LblPayments.TabIndex = 339
    Me.LblPayments.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label58
    '
    Me.Label58.Location = New System.Drawing.Point(8, 19)
    Me.Label58.Name = "Label58"
    Me.Label58.Size = New System.Drawing.Size(88, 16)
    Me.Label58.TabIndex = 338
    Me.Label58.Text = "Payments"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.LblCaveat)
    Me.GroupBox3.Controls.Add(Me.Label5)
    Me.GroupBox3.Controls.Add(Me.LblBond)
    Me.GroupBox3.Controls.Add(Me.Label12)
    Me.GroupBox3.Controls.Add(Me.LblDeferAmt)
    Me.GroupBox3.Controls.Add(Me.Label54)
    Me.GroupBox3.Controls.Add(Me.LblAssmntLeft)
    Me.GroupBox3.Controls.Add(Me.Label64)
    Me.GroupBox3.Location = New System.Drawing.Point(535, 204)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(200, 96)
    Me.GroupBox3.TabIndex = 341
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Unbilled Assessment (Future)"
    '
    'LblCaveat
    '
    Me.LblCaveat.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCaveat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCaveat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCaveat.Location = New System.Drawing.Point(103, 66)
    Me.LblCaveat.Name = "LblCaveat"
    Me.LblCaveat.Size = New System.Drawing.Size(88, 16)
    Me.LblCaveat.TabIndex = 343
    Me.LblCaveat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(6, 66)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(96, 16)
    Me.Label5.TabIndex = 342
    Me.Label5.Text = "Caveat Lien"
    '
    'LblBond
    '
    Me.LblBond.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblBond.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblBond.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBond.Location = New System.Drawing.Point(103, 50)
    Me.LblBond.Name = "LblBond"
    Me.LblBond.Size = New System.Drawing.Size(88, 16)
    Me.LblBond.TabIndex = 341
    Me.LblBond.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label12
    '
    Me.Label12.Location = New System.Drawing.Point(6, 50)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(96, 16)
    Me.Label12.TabIndex = 340
    Me.Label12.Text = "Bond Interest"
    '
    'LblDeferAmt
    '
    Me.LblDeferAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblDeferAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblDeferAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDeferAmt.Location = New System.Drawing.Point(103, 34)
    Me.LblDeferAmt.Name = "LblDeferAmt"
    Me.LblDeferAmt.Size = New System.Drawing.Size(88, 16)
    Me.LblDeferAmt.TabIndex = 339
    Me.LblDeferAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label54
    '
    Me.Label54.Location = New System.Drawing.Point(6, 34)
    Me.Label54.Name = "Label54"
    Me.Label54.Size = New System.Drawing.Size(96, 16)
    Me.Label54.TabIndex = 338
    Me.Label54.Text = "Deferred Amount"
    '
    'LblAssmntLeft
    '
    Me.LblAssmntLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAssmntLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAssmntLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAssmntLeft.Location = New System.Drawing.Point(103, 18)
    Me.LblAssmntLeft.Name = "LblAssmntLeft"
    Me.LblAssmntLeft.Size = New System.Drawing.Size(88, 16)
    Me.LblAssmntLeft.TabIndex = 337
    Me.LblAssmntLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label64
    '
    Me.Label64.BackColor = System.Drawing.SystemColors.Control
    Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label64.Location = New System.Drawing.Point(6, 20)
    Me.Label64.Name = "Label64"
    Me.Label64.Size = New System.Drawing.Size(88, 16)
    Me.Label64.TabIndex = 336
    Me.Label64.Text = "Assessment Left"
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.LnkPayoff)
    Me.GroupBox4.Controls.Add(Me.LblAmountDue)
    Me.GroupBox4.Controls.Add(Me.Label14)
    Me.GroupBox4.Location = New System.Drawing.Point(535, 306)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(200, 38)
    Me.GroupBox4.TabIndex = 342
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Payoff Amount"
    '
    'LnkPayoff
    '
    Me.LnkPayoff.AutoSize = True
    Me.LnkPayoff.Location = New System.Drawing.Point(83, 14)
    Me.LnkPayoff.Name = "LnkPayoff"
    Me.LnkPayoff.Size = New System.Drawing.Size(13, 13)
    Me.LnkPayoff.TabIndex = 342
    Me.LnkPayoff.TabStop = True
    Me.LnkPayoff.Text = "?"
    '
    'LblAmountDue
    '
    Me.LblAmountDue.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAmountDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAmountDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAmountDue.Location = New System.Drawing.Point(102, 14)
    Me.LblAmountDue.Name = "LblAmountDue"
    Me.LblAmountDue.Size = New System.Drawing.Size(88, 16)
    Me.LblAmountDue.TabIndex = 341
    Me.LblAmountDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label14
    '
    Me.Label14.Location = New System.Drawing.Point(8, 16)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(74, 14)
    Me.Label14.TabIndex = 340
    Me.Label14.Text = "Amount Due"
    '
    'DtPckInterest
    '
    Me.DtPckInterest.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckInterest.Location = New System.Drawing.Point(250, 124)
    Me.DtPckInterest.Name = "DtPckInterest"
    Me.DtPckInterest.Size = New System.Drawing.Size(84, 20)
    Me.DtPckInterest.TabIndex = 346
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(102, 124)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(42, 22)
    Me.TxtYear.TabIndex = 345
    '
    'BtnRecalc
    '
    Me.BtnRecalc.Location = New System.Drawing.Point(340, 122)
    Me.BtnRecalc.Name = "BtnRecalc"
    Me.BtnRecalc.Size = New System.Drawing.Size(51, 24)
    Me.BtnRecalc.TabIndex = 345
    Me.BtnRecalc.TabStop = False
    Me.BtnRecalc.Text = "Recalc"
    Me.BtnRecalc.UseVisualStyleBackColor = True
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(12, 128)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(84, 16)
    Me.Label2.TabIndex = 346
    Me.Label2.Text = "Last Year Billed"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(171, 129)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(73, 16)
    Me.Label3.TabIndex = 347
    Me.Label3.Text = "Interest Date"
    '
    'LblAddr2
    '
    Me.LblAddr2.Location = New System.Drawing.Point(130, 27)
    Me.LblAddr2.Name = "LblAddr2"
    Me.LblAddr2.Size = New System.Drawing.Size(268, 16)
    Me.LblAddr2.TabIndex = 348
    Me.LblAddr2.Text = "<address 2>"
    Me.LblAddr2.UseMnemonic = False
    '
    'LblAddr3
    '
    Me.LblAddr3.Location = New System.Drawing.Point(130, 48)
    Me.LblAddr3.Name = "LblAddr3"
    Me.LblAddr3.Size = New System.Drawing.Size(268, 16)
    Me.LblAddr3.TabIndex = 349
    Me.LblAddr3.Text = "<address 3>"
    Me.LblAddr3.UseMnemonic = False
    '
    'LblAddr4
    '
    Me.LblAddr4.Location = New System.Drawing.Point(130, 64)
    Me.LblAddr4.Name = "LblAddr4"
    Me.LblAddr4.Size = New System.Drawing.Size(268, 16)
    Me.LblAddr4.TabIndex = 350
    Me.LblAddr4.Text = "<address 4>"
    Me.LblAddr4.UseMnemonic = False
    '
    'LblAddr5
    '
    Me.LblAddr5.Location = New System.Drawing.Point(130, 80)
    Me.LblAddr5.Name = "LblAddr5"
    Me.LblAddr5.Size = New System.Drawing.Size(268, 16)
    Me.LblAddr5.TabIndex = 351
    Me.LblAddr5.Text = "<address 5>"
    Me.LblAddr5.UseMnemonic = False
    '
    'LblLoc
    '
    Me.LblLoc.Location = New System.Drawing.Point(106, 96)
    Me.LblLoc.Name = "LblLoc"
    Me.LblLoc.Size = New System.Drawing.Size(268, 16)
    Me.LblLoc.TabIndex = 352
    Me.LblLoc.Text = "<property location>"
    Me.LblLoc.UseMnemonic = False
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(12, 96)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(88, 16)
    Me.Label4.TabIndex = 353
    Me.Label4.Text = "Location#/Name"
    '
    'FrmUB102Payoff
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(738, 356)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.LblLoc)
    Me.Controls.Add(Me.LblAddr5)
    Me.Controls.Add(Me.LblAddr4)
    Me.Controls.Add(Me.LblAddr3)
    Me.Controls.Add(Me.LblAddr2)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.BtnRecalc)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.DtPckInterest)
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.C1DataGrdPrev)
    Me.Controls.Add(Me.LblAddr1)
    Me.Controls.Add(Me.LblListNo)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmUB102Payoff"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    Me.Text = "Payoff Calculations"
    CType(Me.C1DataGrdPrev, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub
		Friend WithEvents LblAddr1 As System.Windows.Forms.Label
		Friend WithEvents LblListNo As System.Windows.Forms.Label
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents C1DataGrdPrev As C1.Win.C1TrueDBGrid.C1TrueDBGrid
		Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
		Friend WithEvents LblAssmntAdj As System.Windows.Forms.Label
		Friend WithEvents Label57 As System.Windows.Forms.Label
		Friend WithEvents LblOrigAssmnt As System.Windows.Forms.Label
		Friend WithEvents Label65 As System.Windows.Forms.Label
		Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
		Friend WithEvents LblDelqInt As System.Windows.Forms.Label
		Friend WithEvents Label8 As System.Windows.Forms.Label
		Friend WithEvents LblDelqBal As System.Windows.Forms.Label
		Friend WithEvents Label6 As System.Windows.Forms.Label
		Friend WithEvents LblPayments As System.Windows.Forms.Label
		Friend WithEvents Label58 As System.Windows.Forms.Label
		Friend WithEvents LblLiens As System.Windows.Forms.Label
		Friend WithEvents Label10 As System.Windows.Forms.Label
		Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
		Friend WithEvents LblBond As System.Windows.Forms.Label
		Friend WithEvents Label12 As System.Windows.Forms.Label
		Friend WithEvents LblDeferAmt As System.Windows.Forms.Label
		Friend WithEvents Label54 As System.Windows.Forms.Label
		Friend WithEvents LblAssmntLeft As System.Windows.Forms.Label
		Friend WithEvents Label64 As System.Windows.Forms.Label
		Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
		Friend WithEvents LblAmountDue As System.Windows.Forms.Label
		Friend WithEvents Label14 As System.Windows.Forms.Label
		Friend WithEvents DtPckInterest As System.Windows.Forms.DateTimePicker
		Friend WithEvents LblDelqBond As System.Windows.Forms.Label
		Friend WithEvents Label16 As System.Windows.Forms.Label
		Friend WithEvents TxtYear As System.Windows.Forms.TextBox
		Friend WithEvents BtnRecalc As System.Windows.Forms.Button
		Friend WithEvents Label2 As System.Windows.Forms.Label
		Friend WithEvents Label3 As System.Windows.Forms.Label
		Friend WithEvents LblAddr2 As System.Windows.Forms.Label
		Friend WithEvents LblAddr3 As System.Windows.Forms.Label
		Friend WithEvents LblAddr4 As System.Windows.Forms.Label
		Friend WithEvents LblAddr5 As System.Windows.Forms.Label
		Friend WithEvents LblCaveat As System.Windows.Forms.Label
		Friend WithEvents Label5 As System.Windows.Forms.Label
		Friend WithEvents LblDelqFee As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents LnkPayoff As System.Windows.Forms.LinkLabel
  Friend WithEvents LblLoc As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
