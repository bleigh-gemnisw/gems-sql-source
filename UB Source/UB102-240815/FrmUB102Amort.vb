Public Class FrmUB102Amort

Inherits System.Windows.Forms.Form
Friend WrkListNo As Integer
Friend WrkUBType As String

Dim myUTTYPE As UTTYPE.myData
Dim myUTCUST As UTCUST.myData
Dim myUTCUSTAS As UTCUSTAS.myData
Dim myUTCUSTRT As UTCUSTRT.myData
Dim myTXINV As TXINV.myData
Dim myUTCNTL As UTCNTL.myData
Dim DsUTCUST As DataSet = New DataSet
Dim dsPrev As DataSet = New DataSet
Dim dsFuture As DataSet = New DataSet

Dim WrkTaxType As String
Dim WrkInterestDate As Date
Dim WrkTaxTotal As Double
Dim WrkCaveat As Decimal
'Assessment Work Fields
Dim WrkOrigAssmnt As Decimal
Dim WrkBillAmt As Decimal
Dim WrkBond As Decimal
Dim WrkBillsLeft As Integer
Dim WrkBillNo As Integer
Dim WrkAssmntLeft As Decimal
Dim WrkAssmntAdjust As Decimal
'Deliquent work fields
Dim WrkDelqInterest As Decimal
Dim WrkDelqLien As Decimal
Dim WrkDelqBond As Decimal
Friend WithEvents LblBalance As System.Windows.Forms.Label
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents LblCaveat As System.Windows.Forms.Label
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents LblPrevBilled As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Dim WrkBalance As Decimal

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
Friend WithEvents LblName As System.Windows.Forms.Label
Friend WithEvents LblListNo As System.Windows.Forms.Label
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents LblOrigAssmnt As System.Windows.Forms.Label
Friend WithEvents Label65 As System.Windows.Forms.Label
Friend WithEvents LblAssmntLeft As System.Windows.Forms.Label
Friend WithEvents Label64 As System.Windows.Forms.Label
Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
Friend WithEvents tpPrevious As System.Windows.Forms.TabPage
Friend WithEvents tpFuture As System.Windows.Forms.TabPage
Friend WithEvents C1DataGrdPrev As C1.Win.C1TrueDBGrid.C1TrueDBGrid
Friend WithEvents C1DataGrdFuture As C1.Win.C1TrueDBGrid.C1TrueDBGrid
Friend WithEvents LblTotBond As System.Windows.Forms.Label
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents LblTotAmt As System.Windows.Forms.Label
Friend WithEvents Label5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUB102Amort))
Me.LblName = New System.Windows.Forms.Label
Me.LblListNo = New System.Windows.Forms.Label
Me.Label1 = New System.Windows.Forms.Label
Me.LblOrigAssmnt = New System.Windows.Forms.Label
Me.Label65 = New System.Windows.Forms.Label
Me.LblAssmntLeft = New System.Windows.Forms.Label
Me.Label64 = New System.Windows.Forms.Label
Me.TabControl1 = New System.Windows.Forms.TabControl
Me.tpPrevious = New System.Windows.Forms.TabPage
Me.C1DataGrdPrev = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
Me.tpFuture = New System.Windows.Forms.TabPage
Me.LblTotAmt = New System.Windows.Forms.Label
Me.Label5 = New System.Windows.Forms.Label
Me.LblTotBond = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.C1DataGrdFuture = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
Me.LblBalance = New System.Windows.Forms.Label
Me.Label4 = New System.Windows.Forms.Label
Me.LblCaveat = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.LblPrevBilled = New System.Windows.Forms.Label
Me.Label7 = New System.Windows.Forms.Label
Me.TabControl1.SuspendLayout()
Me.tpPrevious.SuspendLayout()
CType(Me.C1DataGrdPrev, System.ComponentModel.ISupportInitialize).BeginInit()
Me.tpFuture.SuspendLayout()
CType(Me.C1DataGrdFuture, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'LblName
'
Me.LblName.Location = New System.Drawing.Point(72, 32)
Me.LblName.Name = "LblName"
Me.LblName.Size = New System.Drawing.Size(268, 16)
Me.LblName.TabIndex = 164
Me.LblName.UseMnemonic = False
'
'LblListNo
'
Me.LblListNo.Location = New System.Drawing.Point(72, 8)
Me.LblListNo.Name = "LblListNo"
Me.LblListNo.Size = New System.Drawing.Size(48, 16)
Me.LblListNo.TabIndex = 163
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 8)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(56, 16)
Me.Label1.TabIndex = 162
Me.Label1.Text = "Account #"
'
'LblOrigAssmnt
'
Me.LblOrigAssmnt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblOrigAssmnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblOrigAssmnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblOrigAssmnt.Location = New System.Drawing.Point(96, 56)
Me.LblOrigAssmnt.Name = "LblOrigAssmnt"
Me.LblOrigAssmnt.Size = New System.Drawing.Size(88, 16)
Me.LblOrigAssmnt.TabIndex = 319
Me.LblOrigAssmnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label65
'
Me.Label65.BackColor = System.Drawing.SystemColors.Control
Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label65.Location = New System.Drawing.Point(8, 56)
Me.Label65.Name = "Label65"
Me.Label65.Size = New System.Drawing.Size(88, 16)
Me.Label65.TabIndex = 318
Me.Label65.Text = "Orig Asmnt Amt"
'
'LblAssmntLeft
'
Me.LblAssmntLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblAssmntLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblAssmntLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblAssmntLeft.Location = New System.Drawing.Point(336, 56)
Me.LblAssmntLeft.Name = "LblAssmntLeft"
Me.LblAssmntLeft.Size = New System.Drawing.Size(88, 16)
Me.LblAssmntLeft.TabIndex = 321
Me.LblAssmntLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label64
'
Me.Label64.BackColor = System.Drawing.SystemColors.Control
Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label64.Location = New System.Drawing.Point(243, 56)
Me.Label64.Name = "Label64"
Me.Label64.Size = New System.Drawing.Size(90, 16)
Me.Label64.TabIndex = 320
Me.Label64.Text = "Unbilled Assmnt"
'
'TabControl1
'
Me.TabControl1.Controls.Add(Me.tpPrevious)
Me.TabControl1.Controls.Add(Me.tpFuture)
Me.TabControl1.Location = New System.Drawing.Point(4, 103)
Me.TabControl1.Name = "TabControl1"
Me.TabControl1.SelectedIndex = 0
Me.TabControl1.Size = New System.Drawing.Size(416, 370)
Me.TabControl1.TabIndex = 322
'
'tpPrevious
'
Me.tpPrevious.Controls.Add(Me.C1DataGrdPrev)
Me.tpPrevious.Location = New System.Drawing.Point(4, 22)
Me.tpPrevious.Name = "tpPrevious"
Me.tpPrevious.Size = New System.Drawing.Size(408, 344)
Me.tpPrevious.TabIndex = 0
Me.tpPrevious.Text = "Previous Bills"
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
Me.C1DataGrdPrev.Location = New System.Drawing.Point(4, 3)
Me.C1DataGrdPrev.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
Me.C1DataGrdPrev.Name = "C1DataGrdPrev"
Me.C1DataGrdPrev.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdPrev.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdPrev.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdPrev.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdPrev.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.C1DataGrdPrev.Size = New System.Drawing.Size(404, 336)
Me.C1DataGrdPrev.TabIndex = 162
Me.C1DataGrdPrev.PropBag = resources.GetString("C1DataGrdPrev.PropBag")
'
'tpFuture
'
Me.tpFuture.Controls.Add(Me.LblTotAmt)
Me.tpFuture.Controls.Add(Me.Label5)
Me.tpFuture.Controls.Add(Me.LblTotBond)
Me.tpFuture.Controls.Add(Me.Label3)
Me.tpFuture.Controls.Add(Me.C1DataGrdFuture)
Me.tpFuture.Location = New System.Drawing.Point(4, 22)
Me.tpFuture.Name = "tpFuture"
Me.tpFuture.Size = New System.Drawing.Size(408, 344)
Me.tpFuture.TabIndex = 1
Me.tpFuture.Text = "Future Billing"
'
'LblTotAmt
'
Me.LblTotAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblTotAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblTotAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblTotAmt.Location = New System.Drawing.Point(312, 348)
Me.LblTotAmt.Name = "LblTotAmt"
Me.LblTotAmt.Size = New System.Drawing.Size(88, 16)
Me.LblTotAmt.TabIndex = 325
Me.LblTotAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label5
'
Me.Label5.BackColor = System.Drawing.SystemColors.Control
Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label5.Location = New System.Drawing.Point(248, 348)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(56, 16)
Me.Label5.TabIndex = 324
Me.Label5.Text = "Total Amt"
'
'LblTotBond
'
Me.LblTotBond.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblTotBond.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblTotBond.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblTotBond.Location = New System.Drawing.Point(68, 348)
Me.LblTotBond.Name = "LblTotBond"
Me.LblTotBond.Size = New System.Drawing.Size(88, 16)
Me.LblTotBond.TabIndex = 323
Me.LblTotBond.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label3
'
Me.Label3.BackColor = System.Drawing.SystemColors.Control
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(4, 348)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(60, 16)
Me.Label3.TabIndex = 322
Me.Label3.Text = "Total Bond"
'
'C1DataGrdFuture
'
Me.C1DataGrdFuture.AllowColMove = False
Me.C1DataGrdFuture.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
Me.C1DataGrdFuture.AllowUpdate = False
Me.C1DataGrdFuture.AlternatingRows = True
Me.C1DataGrdFuture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.C1DataGrdFuture.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
Me.C1DataGrdFuture.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.C1DataGrdFuture.GroupByCaption = "Drag a column header here to group by that column"
Me.C1DataGrdFuture.Images.Add(CType(resources.GetObject("C1DataGrdFuture.Images"), System.Drawing.Image))
Me.C1DataGrdFuture.Location = New System.Drawing.Point(2, 3)
Me.C1DataGrdFuture.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
Me.C1DataGrdFuture.Name = "C1DataGrdFuture"
Me.C1DataGrdFuture.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.C1DataGrdFuture.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.C1DataGrdFuture.PreviewInfo.ZoomFactor = 75
Me.C1DataGrdFuture.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdFuture.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.C1DataGrdFuture.Size = New System.Drawing.Size(404, 336)
Me.C1DataGrdFuture.TabIndex = 163
Me.C1DataGrdFuture.PropBag = resources.GetString("C1DataGrdFuture.PropBag")
'
'LblBalance
'
Me.LblBalance.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblBalance.Location = New System.Drawing.Point(336, 72)
Me.LblBalance.Name = "LblBalance"
Me.LblBalance.Size = New System.Drawing.Size(88, 18)
Me.LblBalance.TabIndex = 324
Me.LblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label4
'
Me.Label4.BackColor = System.Drawing.SystemColors.Control
Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label4.Location = New System.Drawing.Point(243, 72)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(93, 18)
Me.Label4.TabIndex = 323
Me.Label4.Text = "Previous Balance"
'
'LblCaveat
'
Me.LblCaveat.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblCaveat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblCaveat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblCaveat.Location = New System.Drawing.Point(336, 90)
Me.LblCaveat.Name = "LblCaveat"
Me.LblCaveat.Size = New System.Drawing.Size(88, 16)
Me.LblCaveat.TabIndex = 345
Me.LblCaveat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(245, 90)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(85, 14)
Me.Label2.TabIndex = 344
Me.Label2.Text = "Caveat Lien"
'
'LblPrevBilled
'
Me.LblPrevBilled.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblPrevBilled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblPrevBilled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblPrevBilled.Location = New System.Drawing.Point(96, 72)
Me.LblPrevBilled.Name = "LblPrevBilled"
Me.LblPrevBilled.Size = New System.Drawing.Size(88, 17)
Me.LblPrevBilled.TabIndex = 346
Me.LblPrevBilled.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label7
'
Me.Label7.BackColor = System.Drawing.SystemColors.Control
Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label7.Location = New System.Drawing.Point(8, 72)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(82, 18)
Me.Label7.TabIndex = 347
Me.Label7.Text = "Prev Billed Amt"
'
'FrmUB102Amort
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(432, 485)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.LblPrevBilled)
Me.Controls.Add(Me.LblCaveat)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.LblBalance)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.TabControl1)
Me.Controls.Add(Me.LblAssmntLeft)
Me.Controls.Add(Me.Label64)
Me.Controls.Add(Me.LblOrigAssmnt)
Me.Controls.Add(Me.Label65)
Me.Controls.Add(Me.LblName)
Me.Controls.Add(Me.LblListNo)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmUB102Amort"
Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
Me.Text = "Amortization Table and previous billings"
Me.TabControl1.ResumeLayout(False)
Me.tpPrevious.ResumeLayout(False)
CType(Me.C1DataGrdPrev, System.ComponentModel.ISupportInitialize).EndInit()
Me.tpFuture.ResumeLayout(False)
CType(Me.C1DataGrdFuture, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)

End Sub

#End Region

Private Sub FrmUB102Amort_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myUTTYPE = New UTTYPE.myData(myDBConnect)
	myUTCUST = New UTCUST.myData(myDBConnect)
	myUTCUSTAS = New UTCUSTAS.myData(myDBConnect)
	myUTCUSTRT = New UTCUSTRT.myData(myDBConnect)
  myTXINV = New TXINV.myData(myDBConnect)
	myUTCNTL = New UTCNTL.myData(myDBConnect)

  With MyFrmUB102
    .TBarSave.Enabled = False
    .TBarComments.Enabled = False
    .TBarPrint.Enabled = True
  End With

  WrkCaveat = 0
	myUTCNTL.GetOneRecordP(1)
	If Not myUTCNTL.RecordNotFound Then
		WrkCaveat = myUTCNTL._UBCAV
	End If

  LblListNo.Text = WrkListNo
  LblName.Text = MyFrmUB102C.TxtName.Text
  LblOrigAssmnt.Text = MyFrmUB102AS.LblOrigAssmnt.Text
  LblAssmntLeft.Text = MyFrmUB102AS.LblAssmntLeft.Text
  WrkAssmntLeft = MyUtils.CnvSng(MyFrmUB102AS.LblAssmntLeft.Text)
  LblPrevBilled.Text = MyUtils.FmtCurrency(MyUtils.CnvSng(MyFrmUB102AS.TxtPrevBilled.Text))
  If WrkAssmntLeft > 0 Or MyUtils.CnvSng(LblPrevBilled.Text) > 0 Then
    LblCaveat.Text = MyUtils.FmtCurrency(MyUtils.CnvSng(WrkCaveat))
  Else
    LblCaveat.Text = MyUtils.FmtCurrency(0)
  End If
  Call FormatGrid()
  LblBalance.Text = MyUtils.FmtCurrency(WrkBalance)
End Sub
Public Sub FormatGrid()
 Call ShowGrid()

 With C1DataGrdPrev
   .Rebind(True)
   .Columns(0).Caption = "Status"
   .Splits(0).DisplayColumns(0).Width = 50
   .Columns(1).Caption = "Year"
   .Splits(0).DisplayColumns(1).Width = 40
   .Columns(2).Caption = "Bill Amt"
   .Splits(0).DisplayColumns(2).Width = 70
   .Columns(3).Caption = "Balance"
   .Splits(0).DisplayColumns(3).Width = 70
   .Columns(4).Caption = "Bond"
   .Splits(0).DisplayColumns(4).Width = 70
   .Columns(5).Caption = "Bond Due"
   .Splits(0).DisplayColumns(5).Width = 70
 End With

 With C1DataGrdFuture
   .Rebind(True)
   .Columns(0).Caption = "Bill #"
   .Splits(0).DisplayColumns(0).Width = 30
   .Columns(1).Caption = "Principal"
   .Splits(0).DisplayColumns(1).Width = 70
   .Columns(2).Caption = "Bond"
   .Splits(0).DisplayColumns(2).Width = 60
   .Columns(3).Caption = "Bill Amt"
   .Splits(0).DisplayColumns(3).Width = 60
   .Columns(4).Caption = "Balance"
   .Splits(0).DisplayColumns(4).Width = 70
   .Columns(5).Caption = "Assmnt Left"
   .Splits(0).DisplayColumns(5).Width = 70
 End With
End Sub
Public Sub ShowGrid()
  Windows.Forms.Cursor.Current = Cursors.WaitCursor

  Dim ds2 As DataSet = New DataSet
  Dim dsinv As DataSet = New DataSet
  Dim dr As DataRow
  Dim myTable As New DataTable
  Dim myTable2 As New DataTable
  Dim I As Integer
  Dim WrkPurgedTax As Decimal
  Dim WrkYear As Integer
  Dim WrkTotal As Decimal
  Dim TotBillAmt As Decimal
  Dim TotBond As Decimal
  Dim TotAmt As Decimal
  Dim WrkInactive As Boolean

  With myTable
    .TableName = "mytable"
    .Columns.Add("Status", Type.GetType("System.String"))
    .Columns.Add("Year", Type.GetType("System.Int16"))
    .Columns.Add("BillAmt", Type.GetType("System.Decimal"))
    .Columns.Add("Balance", Type.GetType("System.Decimal"))
    .Columns.Add("Bond", Type.GetType("System.Decimal"))
    .Columns.Add("BondDue", Type.GetType("System.Decimal"))
  End With
  dsPrev.Tables.Add(myTable)

  With myTable2
    .TableName = "mytable2"
    .Columns.Add("BillNo", Type.GetType("System.Int16"))
    .Columns.Add("Principal", Type.GetType("System.Decimal"))
    .Columns.Add("Bond", Type.GetType("System.Decimal"))
    .Columns.Add("BillAmt", Type.GetType("System.Decimal"))
    .Columns.Add("Balance", Type.GetType("System.Decimal"))
    .Columns.Add("AssmntLeft", Type.GetType("System.Decimal"))
  End With
  dsFuture.Tables.Add(myTable2)

  myUTTYPE.GetOneRecordP(WrkUBType)
  If myUTTYPE.RecordNotFound Then Exit Sub

  WrkTaxType = myUTTYPE._TYTXTP

  dsinv = myTXINV.GetAllListNoType(WrkListNo, WrkTaxType)
  If dsinv.Tables(0).Rows.Count = 0 Then GoTo CheckPurged

  For I = 0 To dsinv.Tables(0).Rows.Count - 1
    With dsinv.Tables(0).Rows(I)
      dsPrev.Tables(0).NewRow()
      dr = dsPrev.Tables(0).NewRow
      If .Item("icode") = "I" Then
        dr("Status") = "Inactive"
        WrkInactive = True
      Else
        dr("Status") = "Billed"
        WrkInactive = False
      End If
      dr("Year") = .Item("year")
      If .Item("ccno") > 0 Then
        dr("BillAmt") = .Item("ccetax")
        If Not WrkInactive Then
          WrkBillAmt = WrkBillAmt + .Item("ccetax")
        End If
      Else
        dr("BillAmt") = .Item("taxt")
        If Not WrkInactive Then
          WrkBillAmt = WrkBillAmt + .Item("taxt")
        End If
      End If
      dr("Balance") = .Item("bald")
      If Not WrkInactive Then
        WrkBalance = WrkBalance + .Item("bald")
      End If
      dr("Bond") = .Item("bond")
      If .Item("bald") <> 0 Then
        dr("BondDue") = .Item("bond") - .Item("bondp")
      Else
        dr("BondDue") = 0
      End If
      dsPrev.Tables(0).Rows.Add(dr)
      WrkYear = .Item("year")
    End With
  Next

CheckPurged:
  'Check for past purged bills and create entry
  WrkPurgedTax = MyUtils.CnvSng(LblOrigAssmnt.Text) - MyUtils.CnvSng(LblAssmntLeft.Text) - WrkBillAmt
  WrkPurgedTax = MyUtils.Round(WrkPurgedTax, 2)
  If WrkPurgedTax > 0 Then
    dsPrev.Tables(0).NewRow()
    dr = dsPrev.Tables(0).NewRow
    dr("Status") = "Purged"
    dr("BillAmt") = Format(WrkPurgedTax, "fixed")
    dsPrev.Tables(0).Rows.Add(dr)
  End If

'Future Billing
  If WrkAssmntLeft > 1 Then
NextYear:
    WrkBillNo = MyUtils.CnvSng(MyFrmUB102AS.TxtPrevBills.Text)
    Do While WrkAssmntLeft > 1
      CalcAssmnt()
      WrkYear = WrkYear + 1
      WrkBillNo = WrkBillNo + 1
      WrkAssmntLeft = WrkAssmntLeft - WrkBillAmt
      dsFuture.Tables(0).NewRow()
      dr = dsFuture.Tables(0).NewRow
      dr("BillNo") = WrkBillNo
      dr("Principal") = WrkBillAmt
      dr("Bond") = WrkBond
      WrkTotal = WrkBillAmt + WrkBond
      dr("BillAmt") = WrkTotal
      dr("Balance") = WrkAssmntLeft + WrkBalance
      dr("AssmntLeft") = WrkAssmntLeft
      dsFuture.Tables(0).Rows.Add(dr)
      If WrkBillAmt = 0 Then Exit Do
      TotBillAmt = TotBillAmt + WrkBillAmt
      TotBond = TotBond + WrkBond
      TotAmt = TotAmt + WrkTotal
    Loop
  End If

  LblTotBond.Text = MyUtils.FmtCurrency(TotBond)
  LblTotAmt.Text = MyUtils.FmtCurrency(TotAmt)

  CalcAssmnt()

  C1DataGrdPrev.DataSource = dsPrev.Tables(0)
  C1DataGrdPrev.Refresh()
  C1DataGrdFuture.DataSource = dsFuture.Tables(0)
  C1DataGrdFuture.Refresh()
  Windows.Forms.Cursor.Current = Cursors.Default

  CalcAssmnt()

End Sub
Private Sub FrmUB102Amort_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB102.SbpScreen.Text = "UB102Amort"
  MyUtils.CenterForm(Me.ParentForm, Me)
  With MyFrmUB102
    .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
    .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
  End With
End Sub
Private Sub FrmUB102Amort_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  With MyFrmUB102
    .TBarSave.Enabled = True
    .TBarComments.Enabled = True
    .TBarPrint.Enabled = False
  End With
  MyFrmUB102AS.Show()
  'Memory Cleanup
  myUTTYPE = Nothing
  myUTCUST = Nothing
  myUTCUSTAS = Nothing
  myUTCUSTRT = Nothing
  myTXINV = Nothing
  MyFrmUB102Amort = Nothing
End Sub
  Private Sub CalcAssmnt()
    Dim MyUBCalcBill2 As UBCalcBill.Amort

    MyUBCalcBill2 = New UBCalcBill.Amort(myDBConnect)

    WrkBillAmt = 0
    WrkBond = 0

    If MyUtils.CnvSng(LblOrigAssmnt.Text) = 0 Then Exit Sub

    With MyUBCalcBill2
      .In_OrigBill = MyUtils.CnvSng(LblOrigAssmnt.Text)
      .In_AmtLeft = WrkAssmntLeft
      .In_Balance = WrkBalance
      .In_RateType = WrkUBType
      .In_RateCode = MyFrmUB102AS.TxtCode.Text
      .In_NumBills = WrkBillNo
      .In_OverrideBill = MyUtils.CnvSng(MyFrmUB102AS.TxtOverride.Text)
      .In_PctDeferred = MyUtils.CnvSng(MyFrmUB102AS.TxtDeferPct.Text)
      .CalcAmort()
      WrkBillAmt = MyUtils.FmtCurrency(.Out_Bill)
      WrkBond = MyUtils.FmtCurrency(.Out_Bond)
      WrkBillsLeft = .Out_BillsLeft
    End With
  End Sub
Public Sub PrintReport()
  PrtReport(dsFuture, WrkTaxType, WrkCaveat)
End Sub
End Class
