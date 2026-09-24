Public Class FrmTXA09Hist
  Inherits System.Windows.Forms.Form
  Dim myTXHSTL3 As TXHSTL3.myData
  Dim myTXBATCHL1 As TXBATCHL1.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkType As String
  Friend WrkDate As Integer
  Friend WithEvents RbPostedInt As System.Windows.Forms.RadioButton
  Friend WithEvents BtnCheck As System.Windows.Forms.Button
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents LblBond As System.Windows.Forms.Label
  Friend WithEvents LblTotal As System.Windows.Forms.Label
  Friend WithEvents LblLien As System.Windows.Forms.Label
  Friend WithEvents LblInterest As System.Windows.Forms.Label
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents label27 As System.Windows.Forms.Label
  Friend WithEvents label26 As System.Windows.Forms.Label
  Friend WithEvents label25 As System.Windows.Forms.Label
  Friend WithEvents label24 As System.Windows.Forms.Label
  Friend WithEvents LblPrincipal As System.Windows.Forms.Label
  Friend WithEvents LblFee As System.Windows.Forms.Label
  Friend WithEvents RbCashCheck As System.Windows.Forms.RadioButton
  Dim WrkLoadScreen As Boolean
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
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents LblType As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents LblYear As System.Windows.Forms.Label
  Friend WithEvents LblList As System.Windows.Forms.Label
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents RbPosted As System.Windows.Forms.RadioButton
  Friend WithEvents RbUnposted As System.Windows.Forms.RadioButton
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTXA09Hist))
    Me.LblName = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.LblType = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.LblList = New System.Windows.Forms.Label()
    Me.label2 = New System.Windows.Forms.Label()
    Me.label1 = New System.Windows.Forms.Label()
    Me.RbPosted = New System.Windows.Forms.RadioButton()
    Me.RbUnposted = New System.Windows.Forms.RadioButton()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.RbPostedInt = New System.Windows.Forms.RadioButton()
    Me.BtnCheck = New System.Windows.Forms.Button()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.LblBond = New System.Windows.Forms.Label()
    Me.LblTotal = New System.Windows.Forms.Label()
    Me.LblLien = New System.Windows.Forms.Label()
    Me.LblInterest = New System.Windows.Forms.Label()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.label27 = New System.Windows.Forms.Label()
    Me.label26 = New System.Windows.Forms.Label()
    Me.label25 = New System.Windows.Forms.Label()
    Me.label24 = New System.Windows.Forms.Label()
    Me.LblPrincipal = New System.Windows.Forms.Label()
    Me.LblFee = New System.Windows.Forms.Label()
    Me.RbCashCheck = New System.Windows.Forms.RadioButton()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'LblName
    '
    Me.LblName.BackColor = System.Drawing.SystemColors.Control
    Me.LblName.Location = New System.Drawing.Point(328, 24)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(277, 20)
    Me.LblName.TabIndex = 153
    Me.LblName.UseMnemonic = False
    '
    'Label7
    '
    Me.Label7.BackColor = System.Drawing.SystemColors.Control
    Me.Label7.Location = New System.Drawing.Point(338, 4)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(32, 12)
    Me.Label7.TabIndex = 152
    Me.Label7.Text = "Type"
    '
    'LblType
    '
    Me.LblType.BackColor = System.Drawing.SystemColors.Control
    Me.LblType.Location = New System.Drawing.Point(374, 4)
    Me.LblType.Name = "LblType"
    Me.LblType.Size = New System.Drawing.Size(16, 16)
    Me.LblType.TabIndex = 151
    '
    'Label3
    '
    Me.Label3.BackColor = System.Drawing.SystemColors.Control
    Me.Label3.Location = New System.Drawing.Point(398, 4)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(32, 12)
    Me.Label3.TabIndex = 150
    Me.Label3.Text = "Year"
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.SystemColors.Control
    Me.LblYear.Location = New System.Drawing.Point(430, 4)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(48, 16)
    Me.LblYear.TabIndex = 149
    '
    'LblList
    '
    Me.LblList.BackColor = System.Drawing.SystemColors.Control
    Me.LblList.Location = New System.Drawing.Point(278, 4)
    Me.LblList.Name = "LblList"
    Me.LblList.Size = New System.Drawing.Size(48, 16)
    Me.LblList.TabIndex = 148
    '
    'label2
    '
    Me.label2.BackColor = System.Drawing.SystemColors.Control
    Me.label2.Location = New System.Drawing.Point(236, 24)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(84, 12)
    Me.label2.TabIndex = 147
    Me.label2.Text = "Name of Owner"
    '
    'label1
    '
    Me.label1.BackColor = System.Drawing.SystemColors.Control
    Me.label1.Location = New System.Drawing.Point(236, 4)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(36, 12)
    Me.label1.TabIndex = 146
    Me.label1.Text = "List #"
    '
    'RbPosted
    '
    Me.RbPosted.AutoSize = True
    Me.RbPosted.Checked = True
    Me.RbPosted.Location = New System.Drawing.Point(12, 4)
    Me.RbPosted.Name = "RbPosted"
    Me.RbPosted.Size = New System.Drawing.Size(105, 17)
    Me.RbPosted.TabIndex = 0
    Me.RbPosted.TabStop = True
    Me.RbPosted.Text = "Posted Pmt Date"
    '
    'RbUnposted
    '
    Me.RbUnposted.AutoSize = True
    Me.RbUnposted.Location = New System.Drawing.Point(12, 49)
    Me.RbUnposted.Name = "RbUnposted"
    Me.RbUnposted.Size = New System.Drawing.Size(71, 17)
    Me.RbUnposted.TabIndex = 2
    Me.RbUnposted.Text = "Unposted"
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColSelect = False
    Me.C1DataGrdList.AllowRowSelect = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AllowUpdate = False
    Me.C1DataGrdList.AllowUpdateOnBlur = False
    Me.C1DataGrdList.AlternatingRows = True
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FetchRowStyles = True
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(-2, 76)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.MeasurementDevice = C1.Win.C1TrueDBGrid.PrintInfo.MeasurementDeviceEnum.Screen
    Me.C1DataGrdList.PrintInfo.MeasurementPrinterName = Nothing
    Me.C1DataGrdList.RecordSelectors = False
    Me.C1DataGrdList.Size = New System.Drawing.Size(820, 280)
    Me.C1DataGrdList.TabIndex = 157
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    '
    'RbPostedInt
    '
    Me.RbPostedInt.AutoSize = True
    Me.RbPostedInt.Location = New System.Drawing.Point(12, 34)
    Me.RbPostedInt.Name = "RbPostedInt"
    Me.RbPostedInt.Size = New System.Drawing.Size(99, 17)
    Me.RbPostedInt.TabIndex = 1
    Me.RbPostedInt.Text = "Posted Int Date"
    '
    'BtnCheck
    '
    Me.BtnCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnCheck.Location = New System.Drawing.Point(687, 4)
    Me.BtnCheck.Name = "BtnCheck"
    Me.BtnCheck.Size = New System.Drawing.Size(119, 62)
    Me.BtnCheck.TabIndex = 158
    Me.BtnCheck.TabStop = False
    Me.BtnCheck.Text = "Check/Cash Lookup and Receipt Reprint"
    '
    'Label11
    '
    Me.Label11.BackColor = System.Drawing.SystemColors.Control
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.Location = New System.Drawing.Point(487, 367)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(56, 16)
    Me.Label11.TabIndex = 178
    Me.Label11.Text = "Bond Int"
    Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'LblBond
    '
    Me.LblBond.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblBond.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblBond.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBond.Location = New System.Drawing.Point(471, 384)
    Me.LblBond.Name = "LblBond"
    Me.LblBond.Size = New System.Drawing.Size(72, 20)
    Me.LblBond.TabIndex = 179
    Me.LblBond.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotal
    '
    Me.LblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotal.Location = New System.Drawing.Point(552, 384)
    Me.LblTotal.Name = "LblTotal"
    Me.LblTotal.Size = New System.Drawing.Size(72, 20)
    Me.LblTotal.TabIndex = 177
    Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblLien
    '
    Me.LblLien.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLien.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblLien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLien.Location = New System.Drawing.Point(390, 384)
    Me.LblLien.Name = "LblLien"
    Me.LblLien.Size = New System.Drawing.Size(72, 20)
    Me.LblLien.TabIndex = 176
    Me.LblLien.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblInterest
    '
    Me.LblInterest.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblInterest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblInterest.Location = New System.Drawing.Point(233, 384)
    Me.LblInterest.Name = "LblInterest"
    Me.LblInterest.Size = New System.Drawing.Size(72, 20)
    Me.LblInterest.TabIndex = 174
    Me.LblInterest.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label21
    '
    Me.Label21.BackColor = System.Drawing.SystemColors.Control
    Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label21.Location = New System.Drawing.Point(576, 367)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(48, 16)
    Me.Label21.TabIndex = 172
    Me.Label21.Text = "Total"
    Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'label27
    '
    Me.label27.BackColor = System.Drawing.SystemColors.Control
    Me.label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label27.Location = New System.Drawing.Point(414, 367)
    Me.label27.Name = "label27"
    Me.label27.Size = New System.Drawing.Size(48, 16)
    Me.label27.TabIndex = 171
    Me.label27.Text = "Lien"
    Me.label27.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'label26
    '
    Me.label26.BackColor = System.Drawing.SystemColors.Control
    Me.label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label26.Location = New System.Drawing.Point(327, 367)
    Me.label26.Name = "label26"
    Me.label26.Size = New System.Drawing.Size(56, 16)
    Me.label26.TabIndex = 170
    Me.label26.Text = "Fee"
    Me.label26.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'label25
    '
    Me.label25.BackColor = System.Drawing.SystemColors.Control
    Me.label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label25.Location = New System.Drawing.Point(257, 367)
    Me.label25.Name = "label25"
    Me.label25.Size = New System.Drawing.Size(48, 16)
    Me.label25.TabIndex = 169
    Me.label25.Text = "Interest"
    Me.label25.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'label24
    '
    Me.label24.BackColor = System.Drawing.SystemColors.Control
    Me.label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label24.Location = New System.Drawing.Point(176, 367)
    Me.label24.Name = "label24"
    Me.label24.Size = New System.Drawing.Size(48, 16)
    Me.label24.TabIndex = 168
    Me.label24.Text = "Principal"
    '
    'LblPrincipal
    '
    Me.LblPrincipal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPrincipal.Location = New System.Drawing.Point(152, 384)
    Me.LblPrincipal.Name = "LblPrincipal"
    Me.LblPrincipal.Size = New System.Drawing.Size(72, 20)
    Me.LblPrincipal.TabIndex = 173
    Me.LblPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblFee
    '
    Me.LblFee.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblFee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFee.Location = New System.Drawing.Point(311, 384)
    Me.LblFee.Name = "LblFee"
    Me.LblFee.Size = New System.Drawing.Size(72, 20)
    Me.LblFee.TabIndex = 175
    Me.LblFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'RbCashCheck
    '
    Me.RbCashCheck.AutoSize = True
    Me.RbCashCheck.Location = New System.Drawing.Point(12, 19)
    Me.RbCashCheck.Name = "RbCashCheck"
    Me.RbCashCheck.Size = New System.Drawing.Size(153, 17)
    Me.RbCashCheck.TabIndex = 180
    Me.RbCashCheck.Text = "Posted Cash/Check/Credit"
    '
    'FrmTXA09Hist
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(830, 412)
    Me.Controls.Add(Me.RbCashCheck)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.LblBond)
    Me.Controls.Add(Me.LblTotal)
    Me.Controls.Add(Me.LblLien)
    Me.Controls.Add(Me.LblInterest)
    Me.Controls.Add(Me.Label21)
    Me.Controls.Add(Me.label27)
    Me.Controls.Add(Me.label26)
    Me.Controls.Add(Me.label25)
    Me.Controls.Add(Me.label24)
    Me.Controls.Add(Me.LblPrincipal)
    Me.Controls.Add(Me.LblFee)
    Me.Controls.Add(Me.BtnCheck)
    Me.Controls.Add(Me.RbPostedInt)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.Controls.Add(Me.RbUnposted)
    Me.Controls.Add(Me.RbPosted)
    Me.Controls.Add(Me.LblName)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.LblType)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.LblList)
    Me.Controls.Add(Me.label2)
    Me.Controls.Add(Me.label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA09Hist"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Payment History"
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTXA09Hist_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    ds.Clear()
    ds = Nothing

    'Memory Cleanup
    myTXHSTL3.CloseFile()
    myTXBATCHL1.CloseFile()
    myTXHSTL3 = Nothing
    myTXBATCHL1 = Nothing

    MyFrmTXA09B.Show()

    MyFrmTXA09Hist = Nothing
  End Sub

  Private Sub FrmTXA09Hist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXHSTL3 = New TXHSTL3.mydata(MyDBConnect)
    myTXBATCHL1 = New TXBATCHL1.mydata(MyDBConnect)
    LblList.Text = WrkListNo
    LblYear.Text = WrkYear
    LblType.Text = WrkType
    LblName.Text = MyFrmTXA09B.LblName.Text

    WrkLoadScreen = True
    Call FormatGrid()
    WrkLoadScreen = False
  End Sub
  Public Sub FormatGrid()
    If WrkLoadScreen Then Exit Sub

    ShowGrid()
    If RbPosted.Checked Then
      GridListPosted(True, False)
      CalcTotals()
    End If
    If RbCashCheck.Checked Then
      GridListPosted(True, True)
      CalcTotals()
    End If
    If RbPostedInt.Checked Then
      GridListPosted(False, False)
      CalcTotals()
    End If
    If RbUnposted.Checked Then
      GridListUnposted()
    End If
   End Sub
    Public Sub ShowGrid()

      Windows.Forms.Cursor.Current = Cursors.WaitCursor
      If RbPosted.Checked Or RbCashCheck.Checked Or RbPostedInt.Checked Then
        ds = myTXHSTL3.GetViewbyList(WrkYear, WrkListNo, WrkType, WrkDate, 999)
      Else
        ds = myTXBATCHL1.GetViewbyList(WrkListNo, WrkYear, WrkType, 999)
      End If

      C1DataGrdList.DataSource = ds.Tables(0)
      C1DataGrdList.Refresh()
      Windows.Forms.Cursor.Current = Cursors.Default

    End Sub
  Private Sub GridListPosted(ByVal ShowPmtDate As Boolean, ByVal ShowCash As Boolean)
    With C1DataGrdList
      .Rebind(True)
      .FetchRowStyles = True
      .Splits(0).DisplayColumns(0).Visible = False
      .Splits(0).DisplayColumns(1).Visible = False
      .Splits(0).DisplayColumns(2).Visible = False
      If ShowPmtDate Then
        .Columns(3).Caption = "Pmt Date"
        .Columns(3).NumberFormat = "##/##/####"
        .Splits(0).DisplayColumns(3).Width = 65
        .Splits(0).DisplayColumns(4).Visible = False
        .Splits(0).DisplayColumns(5).Visible = False
        .Splits(0).DisplayColumns(6).Visible = False
      Else
        .Splits(0).DisplayColumns(3).Visible = False
        .Splits(0).DisplayColumns(4).Visible = False
        .Columns(5).Caption = "Int Date"
        .Columns(5).NumberFormat = "##/##/####"
        .Splits(0).DisplayColumns(5).Width = 65
        .Splits(0).DisplayColumns(6).Visible = False
      End If
      .Columns(7).Caption = "Pmt Amt"
      .Splits(0).DisplayColumns(7).Width = 60
      .Columns(8).Caption = "Interest"
      .Splits(0).DisplayColumns(8).Width = 50
      .Columns(9).Caption = "Fee/Bond"
      .Splits(0).DisplayColumns(9).Width = 50
      .Columns(10).Caption = "Lien"
      .Splits(0).DisplayColumns(10).Width = 40
      .Columns(11).Caption = "Total Amt"
      .Splits(0).DisplayColumns(11).Width = 60
      .Columns(12).Caption = "Adj"
      .Columns(12).ValueItems.Values.Clear()
      .Columns(12).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("A", "Adjust"))
      .Columns(12).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("R", "Refund"))
      .Columns(12).ValueItems.Translate = True
      .Splits(0).DisplayColumns(12).Width = 40
      .Columns(13).Caption = "FeeCd"
      .Splits(0).DisplayColumns(13).Width = 40
      .Columns(14).Caption = "Batch Ty"
      .Columns(14).ValueItems.Values.Clear()
      .Columns(14).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("B", "LockBox"))
      .Columns(14).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("E", "Escrow"))
      .Columns(14).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("G", "Leasing"))
      .Columns(14).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("K", "BankSvc"))
      .Columns(14).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("L", "Liened"))
      .Columns(14).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("M", "Misc"))
      .Columns(14).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("P", "PC"))
      .Columns(14).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("R", "Regular"))
      .Columns(14).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("S", "Suspense"))
      .Columns(14).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("W", "Web"))
      .Columns(14).ValueItems.Translate = True
      .Splits(0).DisplayColumns(14).Width = 50
      .Columns(15).Caption = "Batch #"
      .Splits(0).DisplayColumns(15).Width = 45
      .Columns(16).Caption = "Method"
      .Columns(16).ValueItems.Values.Clear()
      .Columns(16).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(1, "Cash"))
      .Columns(16).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(2, "Check"))
      .Columns(16).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(3, "Credit"))
      .Columns(16).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("A", "Add"))
      .Columns(16).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("R", "Remove"))
      .Columns(16).ValueItems.Translate = True
      .Splits(0).DisplayColumns(16).Width = 45
      If ShowCash Then
        .Columns(17).Caption = "Cash"
        .Splits(0).DisplayColumns(17).Width = 60
        .Columns(18).Caption = "Check"
        .Splits(0).DisplayColumns(18).Width = 60
        .Columns(19).Caption = "Credit"
        .Splits(0).DisplayColumns(19).Width = 60
        .Splits(0).DisplayColumns(20).Visible = False
        .Splits(0).DisplayColumns(21).Visible = False
      Else
        .Splits(0).DisplayColumns(17).Visible = False
        .Splits(0).DisplayColumns(18).Visible = False
        .Splits(0).DisplayColumns(19).Visible = False
        .Columns(20).Caption = "Ref"
        .Splits(0).DisplayColumns(20).Width = 95
        .Columns(21).Caption = "Comment"
        .Splits(0).DisplayColumns(21).Width = 95
      End If
      .Columns(22).ValueItems.Values.Clear()
      .Columns(22).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("B", "Back Tx"))
      .Columns(22).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("I", "Info"))
      .Columns(22).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("S", "Suspend"))
      .Columns(22).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("V", "Void"))
      .Columns(22).ValueItems.Translate = True
      .Columns(22).Caption = "Status"
      .Splits(0).DisplayColumns(22).Width = 45
      .Splits(0).DisplayColumns(22).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    End With

  End Sub
  Private Sub GridListUnposted()
  With C1DataGrdList
    .Rebind(True)
    .FetchRowStyles = True
    .Columns(0).ValueItems.Values.Clear()
    .Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("B", "Back Tx"))
    .Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("S", "Suspend"))
    .Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("V", "Void"))
    .Columns(0).ValueItems.Translate = True
    .Columns(0).Caption = "Status"
    .Splits(0).DisplayColumns(0).Width = 45
    .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    .Splits(0).DisplayColumns(1).Visible = False
    .Splits(0).DisplayColumns(2).Visible = False
    .Splits(0).DisplayColumns(3).Visible = False
    .Columns(4).Caption = "Pmt Amt"
    .Splits(0).DisplayColumns(4).Width = 60
    .Columns(5).Caption = "Interest"
    .Splits(0).DisplayColumns(5).Width = 50
    .Columns(6).Caption = "Fee/Bond"
    .Splits(0).DisplayColumns(6).Width = 50
    .Columns(7).Caption = "Lien"
    .Splits(0).DisplayColumns(7).Width = 50
    .Columns(8).Caption = "Adj"
    .Columns(8).ValueItems.Values.Clear()
    .Columns(8).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("A", "Adjust"))
    .Columns(8).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("R", "Refund"))
    .Columns(8).ValueItems.Translate = True
    .Splits(0).DisplayColumns(8).Width = 50
    .Columns(9).Caption = "FeeCd"
    .Splits(0).DisplayColumns(9).Width = 45
    .Columns(10).Caption = "Seq No"
    .Splits(0).DisplayColumns(10).Width = 50
    .Columns(11).Caption = "Batch #"
    .Splits(0).DisplayColumns(11).Width = 50
  End With

End Sub
Private Sub CalcTotals()
Dim I As Integer
Dim WrkPrincipal As Decimal
Dim WrkInterest As Decimal
Dim WrkFee As Decimal
Dim WrkBond As Decimal
Dim WrkLien As Decimal
Dim WrkTotal As Decimal

  For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
    If C1DataGrdList.Item(I, 22) = "I" Then Continue For
    If C1DataGrdList.Item(I, 22) = "V" Then Continue For
    WrkPrincipal = WrkPrincipal + C1DataGrdList.Item(I, 7)
    WrkInterest = WrkInterest + C1DataGrdList.Item(I, 8)
    If C1DataGrdList.Item(I, 13) = "BI" Then
      WrkBond = WrkBond + C1DataGrdList.Item(I, 9)
    Else
      WrkFee = WrkFee + C1DataGrdList.Item(I, 9)
    End If
    WrkLien = WrkLien + C1DataGrdList.Item(I, 10)
    WrkTotal = WrkTotal + C1DataGrdList.Item(I, 11)
  Next

  LblPrincipal.Text = Format(WrkPrincipal, "Fixed")
  LblInterest.Text = Format(WrkInterest, "Fixed")
  LblFee.Text = Format(WrkFee, "Fixed")
  LblLien.Text = Format(WrkLien, "Fixed")
  LblBond.Text = Format(WrkBond, "Fixed")
  LblTotal.Text = Format(WrkTotal, "Fixed")

End Sub
  Private Sub C1DataGrdList_FetchRowStyle(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles C1DataGrdList.FetchRowStyle
   If RbPosted.Checked Or RbCashCheck.Checked Or RbPostedInt.Checked Then
     If C1DataGrdList.Columns("rcode").CellValue(e.Row) = "I" Then
       If C1DataGrdList.Columns("corc").CellValue(e.Row) <> " " Then
         e.CellStyle.BackColor = System.Drawing.Color.Yellow
       Else
         e.CellStyle.BackColor = System.Drawing.Color.Pink
       End If
     End If
     If C1DataGrdList.Columns("rcode").CellValue(e.Row) = "V" Then
       e.CellStyle.BackColor = System.Drawing.Color.Pink
     End If
   Else
     If C1DataGrdList.Columns("jstat").CellValue(e.Row) = "V" Then
       e.CellStyle.BackColor = System.Drawing.Color.Pink
     End If
   End If

  End Sub
  Private Sub FrmTXA09Hist_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA09.SbpScreen.Text = "TXA09Hist"
    Call MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmTXA09
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub

  Private Sub RbPosted_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPosted.Click
  FormatGrid()
End Sub
Private Sub RbCashCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbCashCheck.Click
  FormatGrid()
End Sub
Private Sub RbPostedInt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPostedInt.Click
  FormatGrid()
End Sub
Private Sub RbUnposted_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbUnposted.Click
  FormatGrid()
End Sub
Private Sub BtnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCheck.Click
    MyFrmTXA09H = New FrmTXA09H
    MyFrmTXA09H.MdiParent = MyFrmTXA09Hist.ParentForm
    MyFrmTXA09H.Show()
    MyFrmTXA09Hist.Hide()
  End Sub

Private Sub LblName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblName.Click

End Sub

Private Sub RbPosted_CheckedChanged(sender As Object, e As EventArgs) Handles RbPosted.CheckedChanged

End Sub
End Class






